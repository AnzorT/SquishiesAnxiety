// house4-cat2.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house4_cat2_js
    {

        public static void Run()
        {
Call(Named(boot_106 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V X_8 = default;
V K_9 = default;
V solid_10 = default;
V box_11 = default;
V cyl_12 = default;
V ball_13 = default;
V slab_14 = default;
V slabX_15 = default;
V arcW_16 = default;
V disc_17 = default;
V pillowY_18 = default;
V pillowZ_19 = default;
V mix_20 = default;
V shade_21 = default;
V prism_22 = default;
V prismZ_23 = default;
V NE_24 = default;
V GOLD_25 = default;
V CH_26 = default;
V CR_27 = default;
V WH_28 = default;
V DK_29 = default;
V TIN_30 = default;
V OLD_31 = default;
V OLD2_32 = default;
V INK_33 = default;
V LEAF_34 = default;
V LEAF2_35 = default;
V RB6_36 = default;
V MT_37 = default;
V FR_38 = default;
V polyY_39 = default;
V starP_40 = default;
V rotS_41 = default;
V lg_42 = default;
V jewel_43 = default;
V spr_44 = default;
V drips_45 = default;
V scr_46 = default;
V pot_47 = default;
V cone_48 = default;
V fish_49 = default;
V RUGD_50 = default;
V rugB_51 = default;
double SD_52 = 0;
V sH_53 = default;
V seatXs_54 = default;
V sty_55 = default;
V glue_56 = default;
V seg_57 = default;
V corner_58 = default;
V sit_59 = default;
V sect_60 = default;
V lsofa_61 = default;
V usofa_62 = default;
V longSofa_63 = default;
V modEnd_64 = default;
V modMid_65 = default;
V modCorner_66 = default;
V pit_67 = default;
V beanpile_68 = default;
V chaise_69 = default;
V tvGlow_70 = default;
V tvstand_71 = default;
V miniTV_72 = default;
V wallTV_73 = default;
V projector_74 = default;
V SPB_75 = default;
V RING_76 = default;
V spk_77 = default;
V spkTower_78 = default;
V spkWall_79 = default;
V sub_80 = default;
V smokeSpk_81 = default;
V partyBox_82 = default;
V tableLamp_83 = default;
V sconce_84 = default;
V lantern_85 = default;
V neonSign_86 = default;
V mushLamp_87 = default;
V leafB_88 = default;
V cactus_89 = default;
V monstera_90 = default;
V sunflower_91 = default;
V bonsai_92 = default;
V flowerPot_93 = default;
V pottedPalm_94 = default;
V succulent_95 = default;
V tankSmall_96 = default;
V aquaBig_97 = default;
V aquaCol_98 = default;
V pinball_99 = default;
V claw_100 = default;
V racer_101 = default;
V consoleSet_102 = default;
V handheld_103 = default;
if (_self1.IsNullish) _self1 = GlobalV;
X_8 = Get(G("window"), "House3D");
if (!(Truthy(((X_8 is var _t104 && !Truthy(_t104) ? _t104 : Get(X_8, "ITEMS")) is var _t105 && !Truthy(_t105) ? _t105 : Get(X_8, "ARCH"))))) {
Call(G("setTimeout"), V.Undef, boot_106.v, ((V)(20D)));
return default;
}
if (Truthy(Get(X_8, "A2"))) {
return default;
}
K_9 = Get(X_8, "K");
{ V _t107 = K_9;
if (_t107.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t107));
{ V _t108 = Get(_t107, "solid");
solid_10 = _t108; }
{ V _t109 = Get(_t107, "box");
box_11 = _t109; }
{ V _t110 = Get(_t107, "cyl");
cyl_12 = _t110; }
{ V _t111 = Get(_t107, "ball");
ball_13 = _t111; }
{ V _t112 = Get(_t107, "slab");
slab_14 = _t112; }
{ V _t113 = Get(_t107, "slabX");
slabX_15 = _t113; }
{ V _t114 = Get(_t107, "arcW");
arcW_16 = _t114; }
{ V _t115 = Get(_t107, "disc");
disc_17 = _t115; }
{ V _t116 = Get(_t107, "pillowY");
pillowY_18 = _t116; }
{ V _t117 = Get(_t107, "pillowZ");
pillowZ_19 = _t117; }
{ V _t118 = Get(_t107, "mix");
mix_20 = _t118; }
{ V _t119 = Get(_t107, "shade");
shade_21 = _t119; }
{ V _t120 = Get(_t107, "prism");
prism_22 = _t120; }
{ V _t121 = Get(_t107, "prismZ");
prismZ_23 = _t121; } }
NE_24 = Get(K_9, "NEON");
GOLD_25 = ((V)("#e2b14a"));
CH_26 = ((V)("#d5dde2"));
CR_27 = ((V)("#fffaf1"));
WH_28 = ((V)("#ffffff"));
DK_29 = ((V)("#36373c"));
TIN_30 = ((V)("#a9b0b4"));
OLD_31 = ((V)("#9b7f62"));
OLD2_32 = ((V)("#a88660"));
INK_33 = ((V)("#2b2f3a"));
LEAF_34 = ((V)("#5fa556"));
LEAF2_35 = ((V)("#7cbd62"));
RB6_36 = Arr(((V)("#e2554a")), ((V)("#ffa940")), ((V)("#ffd23f")), ((V)("#7fc66a")), ((V)("#5cc8f0")), ((V)("#8f7bff")));
MT_37 = NewObj(6).Put("junk", TIN_30).Put("cot", ((V)("#c9b48e"))).Put("retro", CH_26).Put("mod", DK_29).Put("candy", ((V)("#fff1a0"))).Put("royal", GOLD_25).V;
FR_38 = Fn((V _arrowThis130, int _argc122, V k_128, V P_129, V _a126, V _a127, V[] _rest123) => {
return (SEqS(k_128, "junk") ? OLD_31 : (SEqS(k_128, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_128, "candy") ? Get(P_129, "b") : (SEqS(k_128, "retro") ? CR_27 : Get(P_129, "w")))));
}, 2, "", true);
polyY_39 = Fn((V _arrowThis143, int _argc131, V pts_137, V y_138, V h_139, V col_140, V[] _rest132) => {
V o_142 = default;
{ V _t141 = (_argc131 > 4 ? _rest132[0] : V.Undef); if (_t141.IsUndef) _t141 = NewObj(0).V;
o_142 = _t141; }
return Call(solid_10, V.Undef, Object_assign(NewObj(7).Put("ax", ((V)("y"))).Put("sh", ((V)("poly"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("pts", pts_137).Put("rings", Arr(Arr(y_138, ((V)(0D))), Arr(Add(y_138, h_139), ((V)(0D))))).Put("col", col_140).Put("cv", ((V)(0D))).V, o_142));
}, 5, "", true);
starP_40 = Fn((V _arrowThis157, int _argc144, V n_150, V R_151, V r_152, V _a149, V[] _rest145) => {
V rz_154 = default;
V a0_156 = default;
{ V _t153 = _a149; if (_t153.IsUndef) _t153 = ((V)(1D));
rz_154 = _t153; }
{ V _t155 = (_argc144 > 4 ? _rest145[0] : V.Undef); if (_t155.IsUndef) _t155 = ((V)(((-System.Math.PI) / 2D)));
a0_156 = _t155; }
return Array_from(NewObj(1).Put("length", ((V)((ToNum(n_150) * 2D)))).V, Fn((V _arrowThis166, int _argc158, V __164, V i_165, V _a162, V _a163, V[] _rest159) => {
V a_167 = default;
V q_168 = default;
a_167 = Add(a0_156, ((V)(((ToNum(i_165) * System.Math.PI) / ToNum(n_150)))));
q_168 = (NumTruthy((ToNum(i_165) % 2D)) ? r_152 : R_151);
return Arr(((V)((ToNum(q_168) * FdLibm.Cos(ToNum(a_167))))), ((V)(((ToNum(q_168) * FdLibm.Sin(ToNum(a_167))) * ToNum(rz_154)))));
return default;
}, 2, "", true));
}, 5, "", true);
rotS_41 = Fn((V _arrowThis181, int _argc169, V list_175, V deg_176, V _a173, V _a174, V[] _rest170) => {
double t_182 = 0;
double c_183 = 0;
double s_184 = 0;
V P_185 = default;
V N_186 = default;
V dx_178 = default;
V dz_180 = default;
{ V _t177 = _a173; if (_t177.IsUndef) _t177 = ((V)(0D));
dx_178 = _t177; }
{ V _t179 = _a174; if (_t179.IsUndef) _t179 = ((V)(0D));
dz_180 = _t179; }
t_182 = ((ToNum(deg_176) * System.Math.PI) / 180D);
c_183 = FdLibm.Cos(t_182);
s_184 = FdLibm.Sin(t_182);
P_185 = Fn((V _arrowThis194, int _argc187, V p_193, V _a190, V _a191, V _a192, V[] _rest188) => {
return Arr(Add(((V)(((ToNum(GetIdx(p_193, 0D)) * c_183) + (ToNum(GetIdx(p_193, 2D)) * s_184)))), dx_178), GetIdx(p_193, 1D), Add(((V)((((-ToNum(GetIdx(p_193, 0D))) * s_184) + (ToNum(GetIdx(p_193, 2D)) * c_183)))), dz_180));
}, 1, "", true);
N_186 = Fn((V _arrowThis202, int _argc195, V n_201, V _a198, V _a199, V _a200, V[] _rest196) => {
return Arr(((V)(((ToNum(GetIdx(n_201, 0D)) * c_183) + (ToNum(GetIdx(n_201, 2D)) * s_184)))), GetIdx(n_201, 1D), ((V)((((-ToNum(GetIdx(n_201, 0D))) * s_184) + (ToNum(GetIdx(n_201, 2D)) * c_183)))));
}, 1, "", true);
Invoke(list_175, "forEach", Fn((V _arrowThis210, int _argc203, V S_209, V _a206, V _a207, V _a208, V[] _rest204) => {
Set(S_209, "pts", Invoke(Get(S_209, "pts"), "map", P_185));
Invoke(Get(S_209, "faces"), "forEach", Fn((V _arrowThis218, int _argc211, V F_217, V _a214, V _a215, V _a216, V[] _rest212) => {
Set(F_217, "q", Invoke(Get(F_217, "q"), "map", P_185));
Set(F_217, "n", Call(N_186, V.Undef, Get(F_217, "n")));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
return list_175;
return default;
}, 4, "", true);
lg_42 = Fn((V _arrowThis232, int _argc219, V k_225, V P_226, V x_227, V z_228, V[] _rest220) => {
V h_229 = default;
V r_231 = default;
h_229 = (_argc219 > 4 ? _rest220[0] : V.Undef);
{ V _t230 = (_argc219 > 5 ? _rest220[1] : V.Undef); if (_t230.IsUndef) _t230 = ((V)(3.5));
r_231 = _t230; }
return Invoke(Arr(Arr(((V)((-ToNum(x_227)))), ((V)((-ToNum(z_228))))), Arr(x_227, ((V)((-ToNum(z_228))))), Arr(((V)((-ToNum(x_227)))), z_228), Arr(x_227, z_228)), "map", Fn((V _arrowThis245, int _argc233, V _a235, V i_239, V _a237, V _a238, V[] _rest234) => {
V a_242 = default;
V b_244 = default;
{ V _t240 = ListOf(_a235);
{ V _t241 = GetIdx(_t240, 0D);
a_242 = _t241; }
{ V _t243 = GetIdx(_t240, 1D);
b_244 = _t243; }
}
return (SEqS(k_225, "junk") ? Call(box_11, V.Undef, a_242, ((V)(0D)), b_244, ((V)((ToNum(r_231) * 2.2))), h_229, ((V)((ToNum(r_231) * 2.2))), OLD_31, NewObj(1).Put("r", ((V)(1D))).V) : (SEqS(k_225, "retro") ? Call(cyl_12, V.Undef, a_242, ((V)(0D)), b_244, ((V)((ToNum(r_231) * 0.7))), h_229, CH_26, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.5))), Arr(h_229, ((V)(0D)), ((V)(1D))))).V) : (SEqS(k_225, "mod") ? Call(cyl_12, V.Undef, a_242, ((V)(0D)), b_244, ((V)((ToNum(r_231) * 0.5))), h_229, DK_29, NewObj(1).Put("n", ((V)(6D))).V) : (SEqS(k_225, "candy") ? Call(ball_13, V.Undef, a_242, ((V)(0D)), b_244, ((V)(Max(4D, (ToNum(r_231) * 1.2)))), GetIdx(NE_24, (ToNum(Add(i_239, ((V)(1D)))) % 6D)), NewObj(3).Put("sy", ((V)(Max(0.6, (ToNum(h_229) / (2D * Max(4D, (ToNum(r_231) * 1.2)))))))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V) : (SEqS(k_225, "royal") ? Call(cyl_12, V.Undef, a_242, ((V)(0D)), b_244, ((V)((ToNum(r_231) * 0.8))), h_229, GOLD_25, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(h_229, ((V)(0D)), ((V)(1.15))))).V) : Call(cyl_12, V.Undef, a_242, ((V)(0D)), b_244, r_231, h_229, Get(P_226, "wD"), NewObj(1).Put("n", ((V)(10D))).V))))));
}, 2, "", true));
}, 6, "", true);
jewel_43 = Fn((V _arrowThis257, int _argc246, V x_252, V y_253, V z_254, V _a251, V[] _rest247) => {
V r_256 = default;
{ V _t255 = _a251; if (_t255.IsUndef) _t255 = ((V)(4D));
r_256 = _t255; }
return Call(ball_13, V.Undef, x_252, y_253, z_254, r_256, GOLD_25);
}, 4, "", true);
spr_44 = Fn((V _arrowThis271, int _argc258, V x_264, V y_265, V z_266, V w_267, V[] _rest259) => {
V d_268 = default;
V n_270 = default;
d_268 = (_argc258 > 4 ? _rest259[0] : V.Undef);
{ V _t269 = (_argc258 > 5 ? _rest259[1] : V.Undef); if (_t269.IsUndef) _t269 = ((V)(8D));
n_270 = _t269; }
return Array_from(NewObj(1).Put("length", n_270).V, Fn((V _arrowThis280, int _argc272, V __278, V i_279, V _a276, V _a277, V[] _rest273) => {
return Call(ball_13, V.Undef, Add(x_264, ((V)((((((ToNum(i_279) * 37D) % 100D) / 100D) - 0.5) * ToNum(w_267))))), y_265, Add(z_266, ((V)((((((ToNum(i_279) * 61D) % 100D) / 100D) - 0.5) * ToNum(d_268))))), ((V)(2D)), GetIdx(NE_24, (ToNum(i_279) % 6D)), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sy", ((V)(0.6))).V);
}, 2, "", true));
}, 6, "", true);
drips_45 = Fn((V _arrowThis294, int _argc281, V x_287, V y_288, V z_289, V w_290, V[] _rest282) => {
V col_291 = default;
V n_293 = default;
col_291 = (_argc281 > 4 ? _rest282[0] : V.Undef);
{ V _t292 = (_argc281 > 5 ? _rest282[1] : V.Undef); if (_t292.IsUndef) _t292 = ((V)(5D));
n_293 = _t292; }
return Array_from(NewObj(1).Put("length", n_293).V, Fn((V _arrowThis303, int _argc295, V __301, V i_302, V _a299, V _a300, V[] _rest296) => {
return Call(ball_13, V.Undef, ((V)(((ToNum(x_287) - (ToNum(w_290) / 2D)) + ((ToNum(w_290) * ToNum(Add(i_302, ((V)(0.5))))) / ToNum(n_293))))), ((V)(((ToNum(y_288) - 7D) - ((ToNum(i_302) % 2D) * 4D)))), z_289, ((V)(4D)), col_291, NewObj(3).Put("sy", ((V)(1.5))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V);
}, 2, "", true));
}, 6, "", true);
scr_46 = Fn((V _arrowThis317, int _argc304, V x_310, V y_311, V z_312, V w_313, V[] _rest305) => {
double r_318 = 0;
V h_314 = default;
V on_315 = default;
V c1_316 = default;
h_314 = (_argc304 > 4 ? _rest305[0] : V.Undef);
on_315 = (_argc304 > 5 ? _rest305[1] : V.Undef);
c1_316 = (_argc304 > 6 ? _rest305[2] : V.Undef);
if (!(Truthy(on_315))) {
return Arr(Call(box_11, V.Undef, x_310, y_311, z_312, w_313, h_314, ((V)(0.8)), ((V)("#2b3140")), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)((ToNum(x_310) - (ToNum(w_313) * 0.22)))), Add(y_311, ((V)((ToNum(h_314) * 0.64)))), Add(z_312, ((V)(0.5))), ((V)((ToNum(w_313) * 0.3))), ((V)((ToNum(h_314) * 0.1))), ((V)(0.3)), ((V)("#46516a")), NewObj(1).Put("r", ((V)(2D))).V));
}
r_318 = Min(ToNum(w_313), ToNum(h_314));
return Arr(Call(box_11, V.Undef, x_310, y_311, z_312, w_313, h_314, ((V)(0.8)), ((V)("#a8e2ff")), NewObj(3).Put("r", ((V)(3D))).Put("emit", ((V)(1D))).Put("scr", ((V)(1D))).V), Call(box_11, V.Undef, x_310, y_311, Add(z_312, ((V)(0.5))), w_313, ((V)((ToNum(h_314) * 0.34))), ((V)(0.4)), ((V)("#8fd17a")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V), Call(disc_17, V.Undef, Add(x_310, ((V)((ToNum(w_313) * 0.3)))), Add(y_311, ((V)((ToNum(h_314) * 0.72)))), Add(z_312, ((V)(0.9))), ((V)((r_318 * 0.13))), ((V)(0.3)), ((V)("#ffe066")), NewObj(1).Put("emit", ((V)(1D))).V), Call(disc_17, V.Undef, ((V)((ToNum(x_310) - (ToNum(w_313) * 0.1)))), Add(y_311, ((V)((ToNum(h_314) * 0.3)))), Add(z_312, ((V)(1.2))), ((V)((r_318 * 0.2))), ((V)(0.5)), (c1_316 is var _t319 && Truthy(_t319) ? _t319 : ((V)("#ffa940"))), NewObj(2).Put("emit", ((V)(1D))).Put("part", ((V)(1D))).V), Call(disc_17, V.Undef, ((V)(((ToNum(x_310) - (ToNum(w_313) * 0.1)) - (r_318 * 0.07)))), Add(y_311, ((V)((ToNum(h_314) * 0.34)))), Add(z_312, ((V)(1.9))), ((V)((r_318 * 0.035))), ((V)(0.3)), INK_33, NewObj(1).Put("part", ((V)(1D))).V), Call(disc_17, V.Undef, ((V)(((ToNum(x_310) - (ToNum(w_313) * 0.1)) + (r_318 * 0.07)))), Add(y_311, ((V)((ToNum(h_314) * 0.34)))), Add(z_312, ((V)(1.9))), ((V)((r_318 * 0.035))), ((V)(0.3)), INK_33, NewObj(1).Put("part", ((V)(1D))).V));
return default;
}, 7, "", true);
pot_47 = Fn((V _arrowThis332, int _argc320, V k_326, V P_327, V r_328, V h_329, V[] _rest321) => {
V o_333 = default;
V y_331 = default;
{ V _t330 = (_argc320 > 4 ? _rest321[0] : V.Undef); if (_t330.IsUndef) _t330 = ((V)(0D));
y_331 = _t330; }
o_333 = Arr();
if (SEqS(k_326, "junk")) {
Invoke(o_333, "push", Call(cyl_12, V.Undef, ((V)(0D)), y_331, ((V)(0D)), r_328, h_329, TIN_30, NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_12, V.Undef, ((V)(0D)), Add(y_331, ((V)((ToNum(h_329) * 0.3)))), ((V)(0D)), Add(r_328, ((V)(0.4))), ((V)((ToNum(h_329) * 0.35))), ((V)("#c9a85a")), NewObj(1).Put("n", ((V)(12D))).V));
} else {
if (SEqS(k_326, "cot")) {
Invoke(o_333, "push", Call(cyl_12, V.Undef, ((V)(0D)), y_331, ((V)(0D)), ((V)((ToNum(r_328) * 0.8))), h_329, ((V)("#c97a4a")), NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(h_329, ((V)(0D)), ((V)(1D))))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)((ToNum(Add(y_331, h_329)) - 4D))), ((V)(0D)), Add(r_328, ((V)(1.5))), ((V)(5D)), ((V)("#d68a58")), NewObj(1).Put("n", ((V)(12D))).V));
} else {
if (SEqS(k_326, "retro")) {
Invoke(o_333, "push", Call(cyl_12, V.Undef, ((V)(0D)), y_331, ((V)(0D)), r_328, h_329, CR_27, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.75))), Arr(h_329, ((V)(0D)), ((V)(1D))))).V), Call(cyl_12, V.Undef, ((V)(0D)), Add(y_331, ((V)((ToNum(h_329) * 0.55)))), ((V)(0D)), ((V)((ToNum(r_328) * 0.95))), ((V)(4D)), ((V)("#e2554a")), NewObj(1).Put("n", ((V)(12D))).V));
} else {
if (SEqS(k_326, "mod")) {
Invoke(o_333, "push", Call(cyl_12, V.Undef, ((V)(0D)), y_331, ((V)(0D)), r_328, h_329, ((V)("#d8d4cc")), NewObj(1).Put("n", ((V)(14D))).V));
} else {
if (SEqS(k_326, "candy")) {
Invoke(o_333, "push", Call(cyl_12, V.Undef, ((V)(0D)), y_331, ((V)(0D)), ((V)((ToNum(r_328) * 0.82))), h_329, Get(P_327, "a"), NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.82))), Arr(h_329, ((V)(0D)), ((V)(1D))))).V));
{
double i_334 = 0;
i_334 = 0D;
while (true) {
if (!((i_334 < 6D))) break;
double a_336 = 0;
a_336 = (((i_334 / 6D) * System.Math.PI) * 2D);
Invoke(o_333, "push", Call(box_11, V.Undef, ((V)(((ToNum(r_328) * 0.95) * FdLibm.Cos(a_336)))), Add(y_331, ((V)(2D))), ((V)(((ToNum(r_328) * 0.95) * FdLibm.Sin(a_336)))), ((V)(2D)), ((V)((ToNum(h_329) - 4D))), ((V)(2D)), WH_28, NewObj(1).Put("r", ((V)(1D))).V));
i_334++;
}
}
} else {
Invoke(o_333, "push", Call(cyl_12, V.Undef, ((V)(0D)), y_331, ((V)(0D)), ((V)((ToNum(r_328) * 0.7))), ((V)((ToNum(h_329) * 0.3))), ((V)("#f4f1ea")), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_12, V.Undef, ((V)(0D)), Add(y_331, ((V)((ToNum(h_329) * 0.3)))), ((V)(0D)), r_328, ((V)((ToNum(h_329) * 0.7))), ((V)("#f4f1ea")), NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)((ToNum(h_329) * 0.7))), ((V)(0D)), ((V)(1D))))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)((ToNum(Add(y_331, h_329)) - 3D))), ((V)(0D)), Add(r_328, ((V)(1D))), ((V)(3D)), GOLD_25, NewObj(1).Put("n", ((V)(14D))).V));
}
}
}
}
}
return o_333;
return default;
}, 5, "", true);
cone_48 = Fn((V _arrowThis350, int _argc337, V x_343, V y_344, V z_345, V r_346, V[] _rest338) => {
V cc_347 = default;
V ring_348 = default;
V on_349 = default;
cc_347 = (_argc337 > 4 ? _rest338[0] : V.Undef);
ring_348 = (_argc337 > 5 ? _rest338[1] : V.Undef);
on_349 = (_argc337 > 6 ? _rest338[2] : V.Undef);
return Arr(Call(disc_17, V.Undef, x_343, y_344, z_345, r_346, ((V)(2D)), cc_347, NewObj(2).Put("top", ((V)(3D))).Put("part", ((V)(1D))).V), Call(disc_17, V.Undef, x_343, y_344, Add(z_345, ((V)(2.2))), ((V)((ToNum(r_346) * 0.36))), ((V)(1.2)), ring_348, NewObj(2).Put("part", ((V)(1D))).Put("emit", ((V)((Truthy(on_349) ? 1D : 0D)))).V));
}, 7, "", true);
fish_49 = Fn((V _arrowThis362, int _argc351, V x_357, V y_358, V z_359, V s_360, V[] _rest352) => {
V col_361 = default;
col_361 = (_argc351 > 4 ? _rest352[0] : V.Undef);
return Arr(Call(ball_13, V.Undef, x_357, y_358, z_359, ((V)((5D * ToNum(s_360)))), col_361, NewObj(6).Put("sx", ((V)(1.6))).Put("sy", ((V)(0.9))).Put("sz", ((V)(0.7))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("part", ((V)(1D))).V), Call(disc_17, V.Undef, ((V)((ToNum(x_357) - (8D * ToNum(s_360))))), Add(y_358, ((V)((4.5 * ToNum(s_360))))), z_359, ((V)((3.6 * ToNum(s_360)))), ((V)(1D)), col_361, NewObj(1).Put("part", ((V)(1D))).V), Call(disc_17, V.Undef, Add(x_357, ((V)((3.5 * ToNum(s_360))))), Add(y_358, ((V)((5.5 * ToNum(s_360))))), Add(z_359, ((V)((3.2 * ToNum(s_360))))), ((V)((1.1 * ToNum(s_360)))), ((V)(0.4)), INK_33, NewObj(1).Put("part", ((V)(1D))).V));
}, 5, "", true);
RUGD_50 = NewObj(11).Put("runner", Arr(((V)(250D)), ((V)(70D)))).Put("round", Arr(((V)(180D)), ((V)(180D)))).Put("face", Arr(((V)(170D)), ((V)(150D)))).Put("record", Arr(((V)(170D)), ((V)(170D)))).Put("hex", Arr(((V)(180D)), ((V)(160D)))).Put("star", Arr(((V)(180D)), ((V)(170D)))).Put("flower", Arr(((V)(180D)), ((V)(170D)))).Put("shag", Arr(((V)(180D)), ((V)(130D)))).Put("oval", Arr(((V)(200D)), ((V)(130D)))).Put("rainbow", Arr(((V)(200D)), ((V)(120D)))).Put("spiral", Arr(((V)(176D)), ((V)(176D)))).V;
rugB_51 = Fn((V _arrowThis374, int _argc363, V v_369, V k_370, V P_371, V W_372, V[] _rest364) => {
V a_375 = default;
V b_376 = default;
V c3_377 = default;
double R_378 = 0;
double Rz_379 = 0;
V o_380 = default;
V D_373 = default;
D_373 = (_argc363 > 4 ? _rest364[0] : V.Undef);
a_375 = Get(P_371, "a");
b_376 = Get(P_371, "b");
c3_377 = (SEqS(k_370, "royal") ? GOLD_25 : (SEqS(k_370, "candy") ? GetIdx(NE_24, 2D) : Get(P_371, "w")));
R_378 = (ToNum(W_372) / 2D);
Rz_379 = (ToNum(D_373) / 2D);
o_380 = Arr();
if ((SEqS(v_369, "oval") || SEqS(v_369, "round"))) {
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(R_378)), ((V)(2D)), a_375, NewObj(2).Put("rz", ((V)(Rz_379))).Put("n", ((V)(24D))).V));
Invoke(Arr(((V)(0.84)), ((V)(0.66)), ((V)(0.48)), ((V)(0.28))), "forEach", Fn((V _arrowThis389, int _argc381, V f_387, V i_388, V _a385, V _a386, V[] _rest382) => {
return Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)((2D + (ToNum(i_388) * 0.6)))), ((V)(0D)), ((V)((R_378 * ToNum(f_387)))), ((V)(0.6)), GetK(Arr(b_376, CR_27, c3_377, a_375), i_388), NewObj(2).Put("rz", ((V)((Rz_379 * ToNum(f_387))))).Put("n", ((V)(22D))).V));
}, 2, "", true));
if (SEqS(v_369, "round")) {
{
double i_390 = 0;
i_390 = 0D;
while (true) {
if (!((i_390 < 14D))) break;
double t_392 = 0;
t_392 = (((i_390 / 14D) * System.Math.PI) * 2D);
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(((R_378 * 0.92) * FdLibm.Cos(t_392)))), ((V)(2D)), ((V)(((Rz_379 * 0.92) * FdLibm.Sin(t_392)))), ((V)(4D)), ((V)(0.6)), c3_377, NewObj(1).Put("n", ((V)(8D))).V));
i_390++;
}
}
}
if (SEqS(k_370, "royal")) {
InvokeSpread(o_380, "push", new ArrBuilder().Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "map", Fn((V _arrowThis400, int _argc393, V i_399, V _a396, V _a397, V _a398, V[] _rest394) => {
return Call(jewel_43, V.Undef, ((V)(((R_378 * 0.66) * FdLibm.Cos(((ToNum(i_399) * 1.571) + 0.785))))), ((V)(2D)), ((V)(((Rz_379 * 0.66) * FdLibm.Sin(((ToNum(i_399) * 1.571) + 0.785))))), ((V)(3.5)));
}, 1, "", true))).V);
}
return o_380;
}
if (SEqS(v_369, "runner")) {
Invoke(o_380, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), W_372, ((V)(2D)), D_373, a_375, NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(((-ToNum(D_373)) * 0.36))), ((V)((ToNum(W_372) - 12D))), ((V)(0.6)), ((V)(6D)), b_376, NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((ToNum(D_373) * 0.36))), ((V)((ToNum(W_372) - 12D))), ((V)(0.6)), ((V)(6D)), b_376, NewObj(1).Put("r", ((V)(1D))).V));
{
V i_401 = default;
i_401 = ((V)((-2D)));
while (true) {
V i_401_it = i_401;
if (!(LeN(i_401_it, 2D))) break;
Invoke(o_380, "push", Call(polyY_39, V.Undef, Invoke(Arr(Arr(((V)((-16D))), ((V)(0D))), Arr(((V)(0D)), ((V)((-16D)))), Arr(((V)(16D)), ((V)(0D))), Arr(((V)(0D)), ((V)(16D)))), "map", Fn((V _arrowThis414, int _argc403, V _a405, V _a406, V _a407, V _a408, V[] _rest404) => {
V x_411 = default;
V z_413 = default;
{ V _t409 = ListOf(_a405);
{ V _t410 = GetIdx(_t409, 0D);
x_411 = _t410; }
{ V _t412 = GetIdx(_t409, 1D);
z_413 = _t412; }
}
return Arr(Add(x_411, ((V)((ToNum(i_401_it) * 46D)))), z_413);
}, 1, "", true)), ((V)(2D)), ((V)(0.6)), (NumTruthy((ToNum(i_401_it) % 2D)) ? c3_377 : CR_27)));
i_401 = i_401_it;
PostInc(ref i_401, 1D);
}
}
{
V i_415 = default;
i_415 = ((V)(0D));
while (true) {
V i_415_it = i_415;
if (!(LtN(i_415_it, 9D))) break;
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis424, int _argc417, V s_423, V _a420, V _a421, V _a422, V[] _rest418) => {
return Invoke(o_380, "push", Call(box_11, V.Undef, ((V)((ToNum(s_423) * ((ToNum(W_372) / 2D) + 3D)))), ((V)(0D)), ((V)(((((-ToNum(D_373)) / 2D) + 5D) + ((ToNum(i_415_it) * (ToNum(D_373) - 10D)) / 8D)))), ((V)(6D)), ((V)(1.2)), ((V)(2.4)), CR_27, NewObj(1).Put("r", ((V)(0.5))).V));
}, 1, "", true));
i_415 = i_415_it;
PostInc(ref i_415, 1D);
}
}
return o_380;
}
if (SEqS(v_369, "check")) {
Invoke(o_380, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), W_372, ((V)(2D)), D_373, a_375, NewObj(1).Put("r", ((V)(4D))).V));
{
double i_425 = 0;
i_425 = 0D;
while (true) {
if (!((i_425 < 6D))) break;
{
double j_427 = 0;
j_427 = 0D;
while (true) {
if (!((j_427 < 4D))) break;
if (NumTruthy(((i_425 + j_427) % 2D))) {
Invoke(o_380, "push", Call(box_11, V.Undef, ((V)(((((-ToNum(W_372)) / 2D) + (ToNum(W_372) / 12D)) + ((i_425 * ToNum(W_372)) / 6D)))), ((V)(2D)), ((V)(((((-ToNum(D_373)) / 2D) + (ToNum(D_373) / 8D)) + ((j_427 * ToNum(D_373)) / 4D)))), ((V)(((ToNum(W_372) / 6D) - 2D))), ((V)(0.6)), ((V)(((ToNum(D_373) / 4D) - 2D))), (SEqS(k_370, "retro") ? INK_33 : b_376), NewObj(1).Put("r", ((V)(1D))).V));
}
j_427++;
}
}
i_425++;
}
}
return o_380;
}
if (SEqS(v_369, "stripe")) {
Invoke(o_380, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), W_372, ((V)(2D)), D_373, CR_27, NewObj(1).Put("r", ((V)(4D))).V));
{
double i_429 = 0;
i_429 = 0D;
while (true) {
if (!((i_429 < 7D))) break;
Invoke(o_380, "push", Call(box_11, V.Undef, ((V)(((((-ToNum(W_372)) / 2D) + (ToNum(W_372) / 14D)) + ((i_429 * ToNum(W_372)) / 7D)))), ((V)(2D)), ((V)(0D)), ((V)(((ToNum(W_372) / 7D) - 4D))), ((V)(0.6)), ((V)((ToNum(D_373) - 8D))), GetIdx(Arr(a_375, b_376, c3_377), (i_429 % 3D)), NewObj(1).Put("r", ((V)(1D))).V));
i_429++;
}
}
return o_380;
}
if (SEqS(v_369, "shag")) {
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(R_378)), ((V)(2D)), a_375, NewObj(2).Put("rz", ((V)(Rz_379))).Put("n", ((V)(22D))).V));
{
double i_431 = 0;
i_431 = 0D;
while (true) {
if (!((i_431 < 44D))) break;
double t_433 = 0;
double rr_434 = 0;
t_433 = (i_431 * 2.4);
rr_434 = (System.Math.Sqrt(((i_431 + 0.5) / 44D)) * 0.9);
Invoke(o_380, "push", Call(ball_13, V.Undef, ((V)(((rr_434 * R_378) * FdLibm.Cos(t_433)))), ((V)(1D)), ((V)(((rr_434 * Rz_379) * FdLibm.Sin(t_433)))), ((V)(6.5)), (SEqS(k_370, "candy") ? GetIdx(NE_24, (i_431 % 6D)) : (NumTruthy((i_431 % 3D)) ? a_375 : Get(P_371, "aL"))), NewObj(3).Put("sy", ((V)(0.45))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
i_431++;
}
}
return o_380;
}
if (SEqS(v_369, "rainbow")) {
Invoke(o_380, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), W_372, ((V)(2D)), D_373, CR_27, NewObj(1).Put("r", ((V)(12D))).V));
{
double i_435 = 0;
i_435 = 0D;
while (true) {
if (!((i_435 < 6D))) break;
double rO_437 = 0;
rO_437 = ((R_378 - 10D) - (i_435 * 12D));
Invoke(o_380, "push", Call(arcW_16, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((Rz_379 - 10D))), ((V)(rO_437)), ((V)((((ToNum(D_373) - 22D) * rO_437) / (R_378 - 10D)))), ((V)(11D)), ((V)(0.6)), ((V)(System.Math.PI)), ((V)((System.Math.PI * 2D))), GetIdx(RB6_36, i_435), NewObj(1).Put("n", ((V)(16D))).V));
i_435++;
}
}
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis445, int _argc438, V s_444, V _a441, V _a442, V _a443, V[] _rest439) => {
return Invoke(o_380, "push", Call(ball_13, V.Undef, ((V)((ToNum(s_444) * (R_378 - 26D)))), ((V)(2D)), ((V)((Rz_379 - 18D))), ((V)(12D)), WH_28, NewObj(2).Put("sy", ((V)(0.3))).Put("k", ((V)(3D))).V), Call(ball_13, V.Undef, ((V)((ToNum(s_444) * (R_378 - 40D)))), ((V)(2D)), ((V)((Rz_379 - 12D))), ((V)(10D)), WH_28, NewObj(2).Put("sy", ((V)(0.3))).Put("k", ((V)(3D))).V));
}, 1, "", true));
return o_380;
}
if (SEqS(v_369, "star")) {
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(R_378)), ((V)(2D)), a_375, NewObj(2).Put("rz", ((V)(Rz_379))).Put("n", ((V)(24D))).V), Call(polyY_39, V.Undef, Call(starP_40, V.Undef, ((V)(5D)), ((V)((R_378 * 0.8))), ((V)((R_378 * 0.34))), ((V)((Rz_379 / R_378)))), ((V)(2D)), ((V)(0.6)), b_376), Call(polyY_39, V.Undef, Call(starP_40, V.Undef, ((V)(5D)), ((V)((R_378 * 0.3))), ((V)((R_378 * 0.13))), ((V)((Rz_379 / R_378)))), ((V)(2.6)), ((V)(0.6)), c3_377));
{
double i_446 = 0;
i_446 = 0D;
while (true) {
if (!((i_446 < 10D))) break;
double t_448 = 0;
t_448 = ((((i_446 / 10D) * System.Math.PI) * 2D) + 0.3);
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(((R_378 * 0.9) * FdLibm.Cos(t_448)))), ((V)(2D)), ((V)(((Rz_379 * 0.9) * FdLibm.Sin(t_448)))), ((V)(3D)), ((V)(0.6)), CR_27, NewObj(1).Put("n", ((V)(8D))).V));
i_446++;
}
}
return o_380;
}
if (SEqS(v_369, "face")) {
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(((-R_378) * 0.6))), ((V)(0D)), ((V)(((-Rz_379) * 0.72))), ((V)((R_378 * 0.3))), ((V)(2D)), a_375, NewObj(2).Put("rz", ((V)((Rz_379 * 0.28)))).Put("n", ((V)(14D))).V), Call(cyl_12, V.Undef, ((V)((R_378 * 0.6))), ((V)(0D)), ((V)(((-Rz_379) * 0.72))), ((V)((R_378 * 0.3))), ((V)(2D)), a_375, NewObj(2).Put("rz", ((V)((Rz_379 * 0.28)))).Put("n", ((V)(14D))).V), Call(cyl_12, V.Undef, ((V)(((-R_378) * 0.6))), ((V)(2D)), ((V)(((-Rz_379) * 0.72))), ((V)((R_378 * 0.16))), ((V)(0.6)), Get(P_371, "b"), NewObj(2).Put("rz", ((V)((Rz_379 * 0.15)))).Put("n", ((V)(12D))).V), Call(cyl_12, V.Undef, ((V)((R_378 * 0.6))), ((V)(2D)), ((V)(((-Rz_379) * 0.72))), ((V)((R_378 * 0.16))), ((V)(0.6)), Get(P_371, "b"), NewObj(2).Put("rz", ((V)((Rz_379 * 0.15)))).Put("n", ((V)(12D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(R_378)), ((V)(2D)), a_375, NewObj(2).Put("rz", ((V)(Rz_379))).Put("n", ((V)(26D))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis456, int _argc449, V s_455, V _a452, V _a453, V _a454, V[] _rest450) => {
return Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(((ToNum(s_455) * R_378) * 0.34))), ((V)(2D)), ((V)(((-Rz_379) * 0.08))), ((V)((R_378 * 0.14))), ((V)(0.6)), INK_33, NewObj(2).Put("rz", ((V)((Rz_379 * 0.18)))).Put("n", ((V)(14D))).V), Call(cyl_12, V.Undef, ((V)((((ToNum(s_455) * R_378) * 0.34) - 3D))), ((V)(2.6)), ((V)(((-Rz_379) * 0.16))), ((V)((R_378 * 0.05))), ((V)(0.6)), WH_28, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_12, V.Undef, ((V)(((ToNum(s_455) * R_378) * 0.58))), ((V)(2D)), ((V)((Rz_379 * 0.26))), ((V)((R_378 * 0.12))), ((V)(0.6)), ((V)("#ffa36a")), NewObj(2).Put("rz", ((V)((Rz_379 * 0.08)))).Put("n", ((V)(12D))).V));
}, 1, "", true));
Invoke(o_380, "push", Call(arcW_16, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((Rz_379 * 0.12))), ((V)((R_378 * 0.2))), ((V)((Rz_379 * 0.17))), ((V)(4D)), ((V)(0.6)), ((V)((System.Math.PI * 0.12))), ((V)((System.Math.PI * 0.88))), INK_33, NewObj(1).Put("n", ((V)(10D))).V));
return o_380;
}
if (SEqS(v_369, "map")) {
Invoke(o_380, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), W_372, ((V)(2D)), D_373, ((V)("#f1e3c0")), NewObj(1).Put("r", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((((-ToNum(D_373)) / 2D) + 4D))), ((V)((ToNum(W_372) - 8D))), ((V)(0.6)), ((V)(3D)), ((V)("#c9a86a"))), Call(box_11, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(((ToNum(D_373) / 2D) - 4D))), ((V)((ToNum(W_372) - 8D))), ((V)(0.6)), ((V)(3D)), ((V)("#c9a86a"))));
Invoke(Arr(Arr(((V)((-46D))), ((V)((-12D))), ((V)(40D)), ((V)(28D))), Arr(((V)(48D)), ((V)(20D)), ((V)(34D)), ((V)(24D)))), "forEach", Fn((V _arrowThis472, int _argc457, V _a459, V _a460, V _a461, V _a462, V[] _rest458) => {
V x_465 = default;
V z_467 = default;
V r_469 = default;
V rz_471 = default;
{ V _t463 = ListOf(_a459);
{ V _t464 = GetIdx(_t463, 0D);
x_465 = _t464; }
{ V _t466 = GetIdx(_t463, 1D);
z_467 = _t466; }
{ V _t468 = GetIdx(_t463, 2D);
r_469 = _t468; }
{ V _t470 = GetIdx(_t463, 3D);
rz_471 = _t470; }
}
return Invoke(o_380, "push", Call(cyl_12, V.Undef, x_465, ((V)(2D)), z_467, r_469, ((V)(0.6)), ((V)("#e8cf8a")), NewObj(2).Put("rz", rz_471).Put("n", ((V)(16D))).V), Call(cyl_12, V.Undef, x_465, ((V)(2.6)), z_467, ((V)((ToNum(r_469) * 0.78))), ((V)(0.6)), ((V)("#9fc684")), NewObj(2).Put("rz", ((V)((ToNum(rz_471) * 0.75)))).Put("n", ((V)(16D))).V), Call(ball_13, V.Undef, ((V)((ToNum(x_465) - 6D))), ((V)(3.2)), ((V)((ToNum(z_467) - 4D))), ((V)(7D)), ((V)("#6f9e50")), NewObj(2).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).V));
}, 1, "", true));
{
double i_473 = 0;
i_473 = 0D;
while (true) {
if (!((i_473 < 6D))) break;
double u_475 = 0;
double x_476 = 0;
double z_477 = 0;
u_475 = (i_473 / 5D);
x_476 = ((-26D) + (u_475 * 60D));
z_477 = (((-2D) + (FdLibm.Sin((u_475 * 3.1)) * 14D)) + (u_475 * 12D));
Invoke(o_380, "push", Call(box_11, V.Undef, ((V)(x_476)), ((V)(2D)), ((V)(z_477)), ((V)(7D)), ((V)(0.6)), ((V)(2.6)), ((V)("#b8714a")), NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)(0.5))).V));
i_473++;
}
}
Invoke(o_380, "push", Call(box_11, V.Undef, ((V)(52D)), ((V)(3.2)), ((V)(16D)), ((V)(18D)), ((V)(0.6)), ((V)(3.4)), ((V)("#e2554a")), NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)(0.785))).V), Call(box_11, V.Undef, ((V)(52D)), ((V)(3.2)), ((V)(16D)), ((V)(18D)), ((V)(0.6)), ((V)(3.4)), ((V)("#e2554a")), NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)((-0.785)))).V), Call(polyY_39, V.Undef, Invoke(Call(starP_40, V.Undef, ((V)(4D)), ((V)(14D)), ((V)(4D))), "map", Fn((V _arrowThis489, int _argc478, V _a480, V _a481, V _a482, V _a483, V[] _rest479) => {
V x_486 = default;
V z_488 = default;
{ V _t484 = ListOf(_a480);
{ V _t485 = GetIdx(_t484, 0D);
x_486 = _t485; }
{ V _t487 = GetIdx(_t484, 1D);
z_488 = _t487; }
}
return Arr(((V)((ToNum(x_486) - 76D))), Add(z_488, ((V)(34D))));
}, 1, "", true)), ((V)(2D)), ((V)(0.6)), ((V)("#4a6fd6"))));
return o_380;
}
if (SEqS(v_369, "flower")) {
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(R_378)), ((V)(2D)), CR_27, NewObj(2).Put("rz", ((V)(Rz_379))).Put("n", ((V)(24D))).V));
{
double i_490 = 0;
i_490 = 0D;
while (true) {
if (!((i_490 < 6D))) break;
double t_492 = 0;
t_492 = (((i_490 / 6D) * System.Math.PI) * 2D);
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(((R_378 * 0.5) * FdLibm.Cos(t_492)))), ((V)(2D)), ((V)(((Rz_379 * 0.5) * FdLibm.Sin(t_492)))), ((V)((R_378 * 0.3))), ((V)(0.6)), (NumTruthy((i_490 % 2D)) ? a_375 : b_376), NewObj(3).Put("rz", ((V)((R_378 * 0.17)))).Put("n", ((V)(14D))).Put("yaw", ((V)(t_492))).V));
i_490++;
}
}
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(2.6)), ((V)(0D)), ((V)((R_378 * 0.22))), ((V)(0.6)), c3_377, NewObj(2).Put("rz", ((V)((Rz_379 * 0.22)))).Put("n", ((V)(16D))).V));
return o_380;
}
if ((SEqS(v_369, "record") || SEqS(v_369, "spiral"))) {
V rec_493 = default;
rec_493 = (SEqS(v_369, "record") ? V.True : V.False);
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(R_378)), ((V)(2D)), (Truthy(rec_493) ? INK_33 : a_375), NewObj(2).Put("rz", ((V)(Rz_379))).Put("n", ((V)(26D))).V));
{
double i_494 = 0;
i_494 = 0D;
while (true) {
if (!((i_494 < 5D))) break;
double f_496 = 0;
f_496 = (0.9 - (i_494 * 0.12));
Invoke(o_380, "push", Call(arcW_16, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)), ((V)((R_378 * f_496))), ((V)((Rz_379 * f_496))), ((V)((Truthy(rec_493) ? 1.4 : 9D))), ((V)(0.6)), ((V)((i_494 * 0.8))), ((V)(((i_494 * 0.8) + (Truthy(rec_493) ? (System.Math.PI * 2D) : (System.Math.PI * 1.5))))), (Truthy(rec_493) ? ((V)("#4a4f58")) : GetIdx(Arr(b_376, c3_377, CR_27), (i_494 % 3D))), NewObj(1).Put("n", ((V)(18D))).V));
i_494++;
}
}
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(2.6)), ((V)(0D)), ((V)((R_378 * 0.26))), ((V)(0.6)), (Truthy(rec_493) ? ((V)("#e2554a")) : b_376), NewObj(2).Put("rz", ((V)((Rz_379 * 0.26)))).Put("n", ((V)(16D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(3.2)), ((V)(0D)), ((V)(3D)), ((V)(0.4)), CR_27, NewObj(1).Put("n", ((V)(8D))).V));
return o_380;
}
if (SEqS(v_369, "hex")) {
V hx_497 = default;
hx_497 = Fn((V _arrowThis505, int _argc498, V f_504, V _a501, V _a502, V _a503, V[] _rest499) => {
return Array_from(NewObj(1).Put("length", ((V)(6D))).V, Fn((V _arrowThis514, int _argc506, V __512, V i_513, V _a510, V _a511, V[] _rest507) => {
return Arr(((V)(((R_378 * ToNum(f_504)) * FdLibm.Cos(((ToNum(i_513) * System.Math.PI) / 3D))))), ((V)(((Rz_379 * ToNum(f_504)) * FdLibm.Sin(((ToNum(i_513) * System.Math.PI) / 3D))))));
}, 2, "", true));
}, 1, "", true);
Invoke(o_380, "push", Call(polyY_39, V.Undef, Call(hx_497, V.Undef, ((V)(1D))), ((V)(0D)), ((V)(2D)), a_375, NewObj(1).Put("cv", ((V)(1D))).V), Call(polyY_39, V.Undef, Call(hx_497, V.Undef, ((V)(0.72))), ((V)(2D)), ((V)(0.6)), b_376), Call(polyY_39, V.Undef, Call(hx_497, V.Undef, ((V)(0.36))), ((V)(2.6)), ((V)(0.6)), c3_377));
{
double i_515 = 0;
i_515 = 0D;
while (true) {
if (!((i_515 < 6D))) break;
double t_517 = 0;
t_517 = (((i_515 * System.Math.PI) / 3D) + (System.Math.PI / 6D));
Invoke(o_380, "push", Call(cyl_12, V.Undef, ((V)(((R_378 * 0.62) * FdLibm.Cos(t_517)))), ((V)(2.6)), ((V)(((Rz_379 * 0.62) * FdLibm.Sin(t_517)))), ((V)(6D)), ((V)(0.6)), CR_27, NewObj(1).Put("n", ((V)(6D))).V));
i_515++;
}
}
return o_380;
}
if (SEqS(v_369, "zig")) {
Invoke(o_380, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), W_372, ((V)(2D)), D_373, CR_27, NewObj(1).Put("r", ((V)(4D))).V));
{
double r_518 = 0;
r_518 = 0D;
while (true) {
if (!((r_518 < 4D))) break;
double z0_520 = 0;
V top_521 = default;
V bot_522 = default;
z0_520 = ((((-ToNum(D_373)) / 2D) + 16D) + ((r_518 * (ToNum(D_373) - 24D)) / 4D));
top_521 = Arr();
bot_522 = Arr();
{
double i_523 = 0;
i_523 = 0D;
while (true) {
if (!((i_523 <= 8D))) break;
double x_525 = 0;
double zz_526 = 0;
x_525 = ((((-ToNum(W_372)) / 2D) + 8D) + ((i_523 * (ToNum(W_372) - 16D)) / 8D));
zz_526 = (z0_520 + (NumTruthy((i_523 % 2D)) ? (-7D) : 7D));
Invoke(top_521, "push", Arr(((V)(x_525)), ((V)(zz_526))));
Invoke(bot_522, "push", Arr(((V)(x_525)), ((V)((zz_526 + 9D)))));
i_523++;
}
}
Invoke(o_380, "push", Call(polyY_39, V.Undef, Invoke(top_521, "concat", Invoke(bot_522, "reverse")), ((V)(2D)), ((V)(0.6)), GetIdx(Arr(a_375, b_376, c3_377, a_375), r_518)));
r_518++;
}
}
return o_380;
}
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), W_372, ((V)(2D)), D_373, a_375, NewObj(1).Put("r", ((V)(6D))).V));
return default;
}, 5, "", true);
SD_52 = 86D;
sH_53 = Fn((V _arrowThis534, int _argc527, V k_533, V _a530, V _a531, V _a532, V[] _rest528) => {
return ((V)((SEqS(k_533, "junk") ? 34D : 40D)));
}, 1, "", true);
seatXs_54 = Fn((V _arrowThis545, int _argc535, V len_541, V n_542, V aL_543, V aR_544, V[] _rest536) => {
double x0_546 = 0;
double sw_547 = 0;
x0_546 = (((-ToNum(len_541)) / 2D) + (Truthy(aL_543) ? 24D : 0D));
sw_547 = ((ToNum(len_541) - (Truthy(aL_543) ? 24D : 0D)) - (Truthy(aR_544) ? 24D : 0D));
return Array_from(NewObj(1).Put("length", n_542).V, Fn((V _arrowThis556, int _argc548, V __554, V i_555, V _a552, V _a553, V[] _rest549) => {
return ((V)((x0_546 + ((sw_547 / ToNum(n_542)) * ToNum(Add(i_555, ((V)(0.5))))))));
}, 2, "", true));
return default;
}, 4, "", true);
sty_55 = Fn((V _arrowThis564, int _argc557, V k_563, V _a560, V _a561, V _a562, V[] _rest558) => {
return NewObj(3).Put("by", ((V)((SEqS(k_563, "junk") ? 0D : 7D)))).Put("bh", ((V)((SEqS(k_563, "mod") ? 44D : (SEqS(k_563, "royal") ? 66D : 56D))))).Put("br", ((V)((SEqS(k_563, "mod") ? 8D : (SEqS(k_563, "candy") ? 26D : (SEqS(k_563, "retro") ? 12D : 20D)))))).V;
}, 1, "", true);
glue_56 = Fn((V _arrowThis572, int _argc565, V o_571, V _a568, V _a569, V _a570, V[] _rest566) => {
return Fn((V _arrowThis582, int _argc573, V p_579, V L_580, V fn_581, V _a578, V[] _rest574) => {
return Invoke(L_580, "map", Fn((V _arrowThis590, int _argc583, V q_589, V _a586, V _a587, V _a588, V[] _rest584) => {
Set(q_589, "par", p_579);
if (Truthy(fn_581)) {
Set(q_589, "fn", fn_581);
}
Invoke(o_571, "push", q_589);
return q_589;
return default;
}, 1, "", true));
}, 3, "", true);
}, 1, "", true);
seg_57 = Fn((V _arrowThis603, int _argc591, V S_597, V P_598, V len_599, V n_600, V[] _rest592) => {
V k_604 = default;
V by_605 = default;
V bh_606 = default;
V br_607 = default;
V o_608 = default;
V on_609 = default;
V F_610 = default;
double bH_611 = 0;
double AI_612 = 0;
double xa_613 = 0;
double xb_614 = 0;
double xm_615 = 0;
double cw_616 = 0;
V BS_617 = default;
V BK_618 = default;
V aL_601 = default;
V aR_602 = default;
aL_601 = (_argc591 > 4 ? _rest592[0] : V.Undef);
aR_602 = (_argc591 > 5 ? _rest592[1] : V.Undef);
k_604 = Get(S_597, "k");
{ V _t619 = Call(sty_55, V.Undef, k_604);
if (_t619.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t619));
{ V _t620 = Get(_t619, "by");
by_605 = _t620; }
{ V _t621 = Get(_t619, "bh");
bh_606 = _t621; }
{ V _t622 = Get(_t619, "br");
br_607 = _t622; } }
o_608 = Arr();
on_609 = Call(glue_56, V.Undef, o_608);
F_610 = Arr(((V)(0D)), ((V)(0D)), ((V)(1D)));
bH_611 = (SEqS(k_604, "junk") ? 14D : 18D);
AI_612 = (SEqS(k_604, "candy") ? 26D : 24D);
if (!SEqS(k_604, "junk")) {
InvokeSpread(o_608, "push", new ArrBuilder().Spread(Call(lg_42, V.Undef, k_604, P_598, ((V)(((ToNum(len_599) / 2D) - 12D))), ((V)(32D)), ((V)(7D)))).V);
}
xa_613 = (((-ToNum(len_599)) / 2D) + (Truthy(aL_601) ? AI_612 : 2D));
xb_614 = ((ToNum(len_599) / 2D) - (Truthy(aR_602) ? AI_612 : 2D));
xm_615 = ((xa_613 + xb_614) / 2D);
cw_616 = ((xb_614 - xa_613) / ToNum(n_600));
BS_617 = Call(box_11, V.Undef, ((V)(xm_615)), by_605, ((V)(7D)), ((V)((xb_614 - xa_613))), ((V)(bH_611)), ((V)(70D)), Get(P_598, "aD"), NewObj(2).Put("r", ((V)((SEqS(k_604, "mod") ? 5D : 10D)))).Put("bev", ((V)(4D))).V);
BK_618 = Call(slab_14, V.Undef, ((V)(xm_615)), by_605, ((V)((-35D))), ((V)((xb_614 - xa_613))), Add(bh_606, ((V)(7D))), ((V)(14D)), Get(P_598, "a"), NewObj(2).Put("r", br_607).Put("soft", ((V)(1D))).V);
Invoke(o_608, "push", BS_617, BK_618);
if (SEqS(k_604, "royal")) {
Invoke(o_608, "push", Call(slab_14, V.Undef, ((V)(0D)), Add(by_605, ((V)(5D))), ((V)((-43D))), len_599, Add(bh_606, ((V)(6D))), ((V)(2D)), GOLD_25, NewObj(1).Put("r", Add(br_607, ((V)(3D)))).V));
}
if (SEqS(k_604, "retro")) {
Call(on_609, V.Undef, BK_618, Arr(Call(box_11, V.Undef, ((V)(xm_615)), Add(Add(by_605, ((V)(7D))), bh_606), ((V)((-35D))), ((V)(((xb_614 - xa_613) - 20D))), ((V)(1.4)), ((V)(12D)), CH_26, NewObj(1).Put("r", ((V)(1D))).V)));
}
{
double i_623 = 0;
i_623 = 0D;
while (true) {
if (!(Lt(((V)(i_623)), n_600))) break;
double x_625 = 0;
V BC_626 = default;
x_625 = (xa_613 + (cw_616 * (i_623 + 0.5)));
Invoke(o_608, "push", Call(pillowY_18, V.Undef, ((V)(x_625)), Add(by_605, ((V)(bH_611))), ((V)(16D)), ((V)((cw_616 - 2D))), ((V)((SEqS(k_604, "mod") ? 13D : 16D))), ((V)(52D)), (Truthy(((SEqS(k_604, "junk") ? V.True : V.False) is var _t627 && !Truthy(_t627) ? _t627 : ((V)((i_623 % 2D))))) ? Get(P_598, "b") : Get(P_598, "aL"))));
BC_626 = (SEqS(k_604, "mod") ? Call(box_11, V.Undef, ((V)(x_625)), Add(by_605, ((V)(bH_611))), ((V)((-21D))), ((V)((cw_616 - 4D))), ((V)(38D)), ((V)(14D)), Get(P_598, "aL"), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(3D))).V) : Call(pillowZ_19, V.Undef, ((V)(x_625)), Add(by_605, ((V)(bH_611))), ((V)((-19D))), ((V)((cw_616 - 2D))), ((V)(44D)), ((V)(18D)), Get(P_598, "aL")));
Invoke(o_608, "push", BC_626);
if (SEqS(k_604, "royal")) {
Call(on_609, V.Undef, BC_626, Invoke(Arr(((V)((-0.25))), ((V)(0.25))), "map", Fn((V _arrowThis635, int _argc628, V f_634, V _a631, V _a632, V _a633, V[] _rest629) => {
return Call(ball_13, V.Undef, ((V)((x_625 + (cw_616 * ToNum(f_634))))), Add(by_605, ((V)(40D))), ((V)((-9.6))), ((V)(2.2)), GOLD_25, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sz", ((V)(0.5))).V);
}, 1, "", true)), F_610);
}
i_623++;
}
}
Invoke(Arr(Arr(aL_601, ((V)((-1D)))), Arr(aR_602, ((V)(1D)))), "forEach", Fn((V _arrowThis647, int _argc636, V _a638, V _a639, V _a640, V _a641, V[] _rest637) => {
double x_648 = 0;
V a_644 = default;
V s_646 = default;
{ V _t642 = ListOf(_a638);
{ V _t643 = GetIdx(_t642, 0D);
a_644 = _t643; }
{ V _t645 = GetIdx(_t642, 1D);
s_646 = _t645; }
}
if (!(Truthy(a_644))) {
return default;
}
x_648 = (ToNum(s_646) * ((ToNum(len_599) / 2D) - 12D));
Invoke(o_608, "push", (SEqS(k_604, "candy") ? Call(ball_13, V.Undef, ((V)(x_648)), ((V)((ToNum(by_605) - 2D))), ((V)(2D)), ((V)(20D)), Get(P_598, "b"), NewObj(5).Put("sx", ((V)(0.7))).Put("sy", ((V)(1.05))).Put("sz", ((V)(2.1))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).V) : Call(slab_14, V.Undef, ((V)(x_648)), by_605, ((V)(2D)), ((V)(24D)), ((V)((SEqS(k_604, "mod") ? 32D : 42D))), ((V)(86D)), Get(P_598, "a"), NewObj(2).Put("r", ((V)((SEqS(k_604, "mod") ? 4D : 12D)))).Put("soft", ((V)(1D))).V)));
return default;
}, 1, "", true));
if (SEqS(k_604, "candy")) {
Call(on_609, V.Undef, BK_618, Call(spr_44, V.Undef, ((V)(xm_615)), Add(Add(by_605, ((V)(5D))), bh_606), ((V)((-35D))), ((V)(((xb_614 - xa_613) - 30D))), ((V)(6D)), ((V)(Max(4D, Round((ToNum(len_599) / 34D)))))));
}
if (SEqS(k_604, "junk")) {
Call(on_609, V.Undef, BS_617, Arr(Call(box_11, V.Undef, ((V)(((-ToNum(len_599)) * 0.2))), Add(by_605, ((V)(4D))), ((V)(42.6)), ((V)(16D)), ((V)(8D)), ((V)(1D)), ((V)("#c9a85a")), NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((ToNum(len_599) * 0.26))), Add(by_605, ((V)(5D))), ((V)(42.6)), ((V)(12D)), ((V)(7D)), ((V)(1D)), ((V)("#8fa8a0")), NewObj(1).Put("r", ((V)(1D))).V)), F_610);
}
return o_608;
return default;
}, 6, "", true);
corner_58 = Fn((V _arrowThis657, int _argc649, V S_655, V P_656, V _a653, V _a654, V[] _rest650) => {
V k_658 = default;
V by_659 = default;
V bh_660 = default;
V br_661 = default;
V o_662 = default;
k_658 = Get(S_655, "k");
{ V _t663 = Call(sty_55, V.Undef, k_658);
if (_t663.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t663));
{ V _t664 = Get(_t663, "by");
by_659 = _t664; }
{ V _t665 = Get(_t663, "bh");
bh_660 = _t665; }
{ V _t666 = Get(_t663, "br");
br_661 = _t666; } }
o_662 = Arr();
if (!SEqS(k_658, "junk")) {
InvokeSpread(o_662, "push", new ArrBuilder().Spread(Call(lg_42, V.Undef, k_658, P_656, ((V)(30D)), ((V)(30D)), ((V)(7D)))).V);
}
Invoke(o_662, "push", Call(box_11, V.Undef, ((V)(0D)), by_659, ((V)(0D)), ((V)(SD_52)), ((V)((SEqS(k_658, "junk") ? 14D : 18D))), ((V)(SD_52)), Get(P_656, "aD"), NewObj(2).Put("r", ((V)(10D))).Put("bev", ((V)(4D))).V), Call(slab_14, V.Undef, ((V)((-3D))), Add(by_659, ((V)(7D))), ((V)((-35D))), ((V)((SD_52 - 6D))), bh_660, ((V)(14D)), Get(P_656, "a"), NewObj(2).Put("r", br_661).Put("soft", ((V)(1D))).V), Call(slabX_15, V.Undef, ((V)(35D)), Add(by_659, ((V)(7D))), ((V)(4D)), ((V)(14D)), bh_660, ((V)((SD_52 - 8D))), Get(P_656, "a"), NewObj(1).Put("r", ((V)(Min(ToNum(br_661), 10D)))).V), Call(pillowY_18, V.Undef, ((V)((-4D))), Add(by_659, ((V)(16D))), ((V)(4D)), ((V)(62D)), ((V)((SEqS(k_658, "mod") ? 13D : 16D))), ((V)(62D)), Get(P_656, "aL")), Call(pillowZ_19, V.Undef, ((V)((-6D))), Add(by_659, ((V)(26D))), ((V)((-22D))), ((V)(56D)), ((V)(36D)), ((V)(16D)), Get(P_656, "aL")), Call(box_11, V.Undef, ((V)(22D)), Add(by_659, ((V)(26D))), ((V)(4D)), ((V)(14D)), ((V)(32D)), ((V)(54D)), Get(P_656, "aL"), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(3D))).V));
if (SEqS(k_658, "royal")) {
Invoke(o_662, "push", Call(jewel_43, V.Undef, ((V)(36D)), Add(Add(by_659, bh_660), ((V)(6D))), ((V)((-36D))), ((V)(5D))));
}
if (SEqS(k_658, "candy")) {
InvokeSpread(o_662, "push", new ArrBuilder().Spread(Call(spr_44, V.Undef, ((V)(0D)), Add(Add(by_659, bh_660), ((V)(4D))), ((V)((-35D))), ((V)(60D)), ((V)(6D)), ((V)(4D)))).V);
}
return o_662;
return default;
}, 2, "", true);
sit_59 = Fn((V _arrowThis677, int _argc667, V x_673, V z_674, V f_675, V k_676, V[] _rest668) => {
return NewObj(4).Put("x", x_673).Put("z", z_674).Put("h", Call(sH_53, V.Undef, k_676)).Put("f", f_675).V;
}, 4, "", true);
sect_60 = Fn((V _arrowThis689, int _argc678, V S_684, V W_685, V D_686, V nM_687, V[] _rest679) => {
V k_690 = default;
V by_691 = default;
V bh_692 = default;
double bH_693 = 0;
double aH_694 = 0;
V hasL_695 = default;
double wl_696 = 0;
double wz_697 = 0;
double T_698 = 0;
double BCd_699 = 0;
double AW_700 = 0;
double x0_701 = 0;
double x1_702 = 0;
double cw_703 = 0;
V mx_704 = default;
V seats_705 = default;
double z0_706 = 0;
double zB_707 = 0;
double zC_708 = 0;
double z1_709 = 0;
double zA_710 = 0;
V sides_688 = default;
sides_688 = (_argc678 > 4 ? _rest679[0] : V.Undef);
k_690 = Get(S_684, "k");
{ V _t711 = Call(sty_55, V.Undef, k_690);
if (_t711.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t711));
{ V _t712 = Get(_t711, "by");
by_691 = _t712; }
{ V _t713 = Get(_t711, "bh");
bh_692 = _t713; } }
bH_693 = (SEqS(k_690, "junk") ? 14D : 18D);
aH_694 = (SEqS(k_690, "mod") ? 32D : 42D);
hasL_695 = Invoke(sides_688, "includes", ((V)((-1D))));
wl_696 = ((ToNum(D_686) - SD_52) - 24D);
wz_697 = ((((-ToNum(D_686)) / 2D) + SD_52) + (wl_696 / 2D));
T_698 = 14D;
BCd_699 = 18D;
AW_700 = 24D;
x0_701 = (Truthy(hasL_695) ? (((-ToNum(W_685)) / 2D) + SD_52) : (((-ToNum(W_685)) / 2D) + AW_700));
x1_702 = ((ToNum(W_685) / 2D) - SD_52);
cw_703 = ((x1_702 - x0_701) / ToNum(nM_687));
mx_704 = Array_from(NewObj(1).Put("length", nM_687).V, Fn((V _arrowThis722, int _argc714, V __720, V i_721, V _a718, V _a719, V[] _rest715) => {
return ((V)((x0_701 + (cw_703 * ToNum(Add(i_721, ((V)(0.5))))))));
}, 2, "", true));
seats_705 = Invoke(mx_704, "map", Fn((V _arrowThis730, int _argc723, V x_729, V _a726, V _a727, V _a728, V[] _rest724) => {
return Call(sit_59, V.Undef, x_729, ((V)((((-ToNum(D_686)) / 2D) + 53D))), ((V)(0D)), k_690);
}, 1, "", true));
Invoke(sides_688, "forEach", Fn((V _arrowThis738, int _argc731, V s_737, V _a734, V _a735, V _a736, V[] _rest732) => {
return Invoke(seats_705, "push", Call(sit_59, V.Undef, ((V)((ToNum(s_737) * ((ToNum(W_685) / 2D) - 50D)))), ((V)((((-ToNum(D_686)) / 2D) + 50D))), ((V)(((-45D) * ToNum(s_737)))), k_690), Call(sit_59, V.Undef, ((V)((ToNum(s_737) * ((ToNum(W_685) / 2D) - 53D)))), ((V)(wz_697)), ((V)(((-90D) * ToNum(s_737)))), k_690));
}, 1, "", true));
z0_706 = ((-ToNum(D_686)) / 2D);
zB_707 = (z0_706 + T_698);
zC_708 = (zB_707 + BCd_699);
z1_709 = (z0_706 + SD_52);
zA_710 = ((ToNum(D_686) / 2D) - AW_700);
return NewObj(5).Put("w", W_685).Put("d", D_686).Put("act", ((V)("sit"))).Put("seats", seats_705).Put("build", Fn((V _arrowThis746, int _argc739, V P_745, V _a742, V _a743, V _a744, V[] _rest740) => {
V o_747 = default;
V on_748 = default;
V F_749 = default;
double sm_750 = 0;
V yb_751 = default;
V BH_752 = default;
V span_753 = default;
V back_754 = default;
V @base_755 = default;
V seat_756 = default;
V bcush_757 = default;
V scush_758 = default;
V arm_759 = default;
V MB_760 = default;
o_747 = Arr();
on_748 = Call(glue_56, V.Undef, o_747);
F_749 = Arr(((V)(0D)), ((V)(0D)), ((V)(1D)));
sm_750 = (SEqS(k_690, "mod") ? 13D : 16D);
yb_751 = Add(by_691, ((V)(bH_693)));
BH_752 = Add(bh_692, ((V)(7D)));
span_753 = Fn((V _arrowThis769, int _argc761, V a_767, V b_768, V _a765, V _a766, V[] _rest762) => {
return Arr(((V)(Min(ToNum(a_767), ToNum(b_768)))), ((V)(Max(ToNum(a_767), ToNum(b_768)))));
}, 2, "", true);
back_754 = Fn((V _arrowThis780, int _argc770, V xa_776, V xb_777, V za_778, V zb_779, V[] _rest771) => {
V B_781 = default;
B_781 = Call(box_11, V.Undef, ((V)((ToNum(Add(xa_776, xb_777)) / 2D))), by_691, ((V)((ToNum(Add(za_778, zb_779)) / 2D))), ((V)((ToNum(xb_777) - ToNum(xa_776)))), BH_752, ((V)((ToNum(zb_779) - ToNum(za_778)))), Get(P_745, "a"), NewObj(2).Put("r", ((V)(2D))).Put("soft", ((V)(1D))).V);
Invoke(o_747, "push", B_781);
if (SEqS(k_690, "royal")) {
Call(on_748, V.Undef, B_781, Arr(Call(box_11, V.Undef, ((V)((ToNum(Add(xa_776, xb_777)) / 2D))), Add(by_691, BH_752), ((V)((ToNum(Add(za_778, zb_779)) / 2D))), ((V)((ToNum(xb_777) - ToNum(xa_776)))), ((V)(3D)), ((V)((ToNum(zb_779) - ToNum(za_778)))), GOLD_25, NewObj(1).Put("r", ((V)(1D))).V)));
}
if (SEqS(k_690, "retro")) {
Call(on_748, V.Undef, B_781, Arr(Call(box_11, V.Undef, ((V)((ToNum(Add(xa_776, xb_777)) / 2D))), Add(by_691, BH_752), ((V)((ToNum(Add(za_778, zb_779)) / 2D))), ((V)(Max(2D, ((ToNum(xb_777) - ToNum(xa_776)) - 6D)))), ((V)(1.4)), ((V)(Max(2D, ((ToNum(zb_779) - ToNum(za_778)) - 6D)))), CH_26, NewObj(1).Put("r", ((V)(1D))).V)));
}
if (SEqS(k_690, "candy")) {
Call(on_748, V.Undef, B_781, Call(spr_44, V.Undef, ((V)((ToNum(Add(xa_776, xb_777)) / 2D))), ((V)((ToNum(Add(by_691, BH_752)) - 2D))), ((V)((ToNum(Add(za_778, zb_779)) / 2D))), ((V)(Max(4D, ((ToNum(xb_777) - ToNum(xa_776)) - 8D)))), ((V)(Max(2D, ((ToNum(zb_779) - ToNum(za_778)) - 6D)))), ((V)(Max(2D, Round((Max((ToNum(xb_777) - ToNum(xa_776)), (ToNum(zb_779) - ToNum(za_778))) / 34D)))))));
}
return B_781;
return default;
}, 4, "", true);
@base_755 = Fn((V _arrowThis792, int _argc782, V xa_788, V xb_789, V za_790, V zb_791, V[] _rest783) => {
V B_793 = default;
B_793 = Call(box_11, V.Undef, ((V)((ToNum(Add(xa_788, xb_789)) / 2D))), by_691, ((V)((ToNum(Add(za_790, zb_791)) / 2D))), ((V)((ToNum(xb_789) - ToNum(xa_788)))), ((V)(bH_693)), ((V)((ToNum(zb_791) - ToNum(za_790)))), Get(P_745, "aD"), NewObj(1).Put("r", ((V)(1D))).V);
Invoke(o_747, "push", B_793);
return B_793;
return default;
}, 4, "", true);
seat_756 = Fn((V _arrowThis805, int _argc794, V xa_800, V xb_801, V za_802, V zb_803, V[] _rest795) => {
V col_804 = default;
col_804 = (_argc794 > 4 ? _rest795[0] : V.Undef);
return Invoke(o_747, "push", Call(pillowY_18, V.Undef, ((V)((ToNum(Add(xa_800, xb_801)) / 2D))), yb_751, ((V)((ToNum(Add(za_802, zb_803)) / 2D))), ((V)(((ToNum(xb_801) - ToNum(xa_800)) - 1D))), ((V)(sm_750)), ((V)(((ToNum(zb_803) - ToNum(za_802)) - 1D))), (col_804 is var _t806 && Truthy(_t806) ? _t806 : Get(P_745, "aL"))));
}, 5, "", true);
bcush_757 = Fn((V _arrowThis815, int _argc807, V xa_813, V xb_814, V _a811, V _a812, V[] _rest808) => {
double x_816 = 0;
double w_817 = 0;
V C_818 = default;
x_816 = (ToNum(Add(xa_813, xb_814)) / 2D);
w_817 = (ToNum(xb_814) - ToNum(xa_813));
C_818 = (SEqS(k_690, "mod") ? Call(box_11, V.Undef, ((V)(x_816)), yb_751, ((V)((((zB_707 + zC_708) / 2D) - 2D))), ((V)((w_817 - 4D))), ((V)(38D)), ((V)((BCd_699 - 4D))), Get(P_745, "aL"), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(3D))).V) : Call(pillowZ_19, V.Undef, ((V)(x_816)), yb_751, ((V)(((zB_707 + zC_708) / 2D))), ((V)((w_817 - 1D))), ((V)(44D)), ((V)(BCd_699)), Get(P_745, "aL")));
Invoke(o_747, "push", C_818);
return C_818;
return default;
}, 2, "", true);
scush_758 = Fn((V _arrowThis828, int _argc819, V xc_825, V za_826, V zb_827, V _a824, V[] _rest820) => {
return Invoke(o_747, "push", (SEqS(k_690, "mod") ? Call(box_11, V.Undef, xc_825, yb_751, ((V)((ToNum(Add(za_826, zb_827)) / 2D))), ((V)((BCd_699 - 4D))), ((V)(38D)), ((V)(((ToNum(zb_827) - ToNum(za_826)) - 4D))), Get(P_745, "aL"), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(3D))).V) : GetIdx(Call(rotS_41, V.Undef, Arr(Call(pillowZ_19, V.Undef, ((V)(0D)), yb_751, ((V)(0D)), ((V)(((ToNum(zb_827) - ToNum(za_826)) - 1D))), ((V)(44D)), ((V)(BCd_699)), Get(P_745, "aL"))), ((V)((-90D))), xc_825, ((V)((ToNum(Add(za_826, zb_827)) / 2D)))), 0D)));
}, 3, "", true);
arm_759 = Fn((V _arrowThis839, int _argc829, V xa_835, V xb_836, V za_837, V zb_838, V[] _rest830) => {
double x_840 = 0;
double z_841 = 0;
double w_842 = 0;
double d_843 = 0;
V A_844 = default;
x_840 = (ToNum(Add(xa_835, xb_836)) / 2D);
z_841 = (ToNum(Add(za_837, zb_838)) / 2D);
w_842 = (ToNum(xb_836) - ToNum(xa_835));
d_843 = (ToNum(zb_838) - ToNum(za_837));
A_844 = (SEqS(k_690, "candy") ? Call(ball_13, V.Undef, ((V)(x_840)), ((V)((ToNum(by_691) - 2D))), ((V)(z_841)), ((V)(20D)), Get(P_745, "b"), NewObj(5).Put("sx", ((V)((w_842 / 40D)))).Put("sy", ((V)(1.05))).Put("sz", ((V)((d_843 / 40D)))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).V) : Call(slab_14, V.Undef, ((V)(x_840)), by_691, ((V)(z_841)), ((V)(w_842)), ((V)(aH_694)), ((V)(d_843)), Get(P_745, "a"), NewObj(2).Put("r", ((V)((SEqS(k_690, "mod") ? 4D : 12D)))).Put("soft", ((V)(1D))).V));
Invoke(o_747, "push", A_844);
return A_844;
return default;
}, 4, "", true);
if (!SEqS(k_690, "junk")) {
InvokeSpread(o_747, "push", new ArrBuilder().Spread(Call(rotS_41, V.Undef, Call(lg_42, V.Undef, k_690, P_745, ((V)(((ToNum(W_685) / 2D) - 20D))), ((V)(((SD_52 / 2D) - 10D))), ((V)(7D))), ((V)(0D)), ((V)(0D)), ((V)((((-ToNum(D_686)) / 2D) + (SD_52 / 2D)))))).V);
Invoke(sides_688, "forEach", Fn((V _arrowThis852, int _argc845, V s_851, V _a848, V _a849, V _a850, V[] _rest846) => {
return InvokeSpread(o_747, "push", new ArrBuilder().Spread(Call(rotS_41, V.Undef, Call(lg_42, V.Undef, k_690, P_745, ((V)((((SD_52 - T_698) / 2D) - 8D))), ((V)(((wl_696 / 2D) + 2D))), ((V)(7D))), ((V)(0D)), ((V)((ToNum(s_851) * ((ToNum(W_685) / 2D) - ((SD_52 + T_698) / 2D))))), ((V)((wz_697 + 12D))))).V);
}, 1, "", true));
}
if (!(Truthy(hasL_695))) {
Call(arm_759, V.Undef, ((V)(((-ToNum(W_685)) / 2D))), ((V)((((-ToNum(W_685)) / 2D) + AW_700))), ((V)(z0_706)), ((V)(z1_709)));
}
MB_760 = Invoke(mx_704, "map", Fn((V _arrowThis861, int _argc853, V x_859, V i_860, V _a857, V _a858, V[] _rest854) => {
double xa_862 = 0;
V xb_863 = default;
V B_864 = default;
V C_865 = default;
xa_862 = (ToNum(x_859) - (cw_703 / 2D));
xb_863 = Add(x_859, ((V)((cw_703 / 2D))));
Call(back_754, V.Undef, ((V)(xa_862)), xb_863, ((V)(z0_706)), ((V)(zB_707)));
B_864 = Call(@base_755, V.Undef, ((V)(xa_862)), xb_863, ((V)(zB_707)), ((V)(z1_709)));
C_865 = Call(bcush_757, V.Undef, ((V)(xa_862)), xb_863);
Call(seat_756, V.Undef, ((V)(xa_862)), xb_863, ((V)(zC_708)), ((V)(z1_709)), (Truthy(((SEqS(k_690, "junk") ? V.True : V.False) is var _t866 && !Truthy(_t866) ? _t866 : ((V)((ToNum(i_860) % 2D))))) ? Get(P_745, "b") : Get(P_745, "aL")));
if (SEqS(k_690, "royal")) {
Call(on_748, V.Undef, C_865, Invoke(Arr(((V)((-0.25))), ((V)(0.25))), "map", Fn((V _arrowThis874, int _argc867, V f_873, V _a870, V _a871, V _a872, V[] _rest868) => {
return Call(ball_13, V.Undef, Add(x_859, ((V)((cw_703 * ToNum(f_873))))), Add(by_691, ((V)(40D))), ((V)((zC_708 + 0.4))), ((V)(2.2)), GOLD_25, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sz", ((V)(0.5))).V);
}, 1, "", true)), F_749);
}
return B_864;
return default;
}, 2, "", true));
Invoke(sides_688, "forEach", Fn((V _arrowThis882, int _argc875, V s_881, V _a878, V _a879, V _a880, V[] _rest876) => {
V ca_883 = default;
V cb_884 = default;
V ba_885 = default;
V bb_886 = default;
V ka_887 = default;
V kb_888 = default;
double xs_889 = 0;
V A_890 = default;
{ V _t891 = Call(span_753, V.Undef, ((V)((ToNum(s_881) * ((ToNum(W_685) / 2D) - SD_52)))), ((V)((ToNum(s_881) * (ToNum(W_685) / 2D)))));
{ V _t892 = ListOf(_t891);
{ V _t893 = GetIdx(_t892, 0D);
ca_883 = _t893; }
{ V _t894 = GetIdx(_t892, 1D);
cb_884 = _t894; }
} }
{ V _t895 = Call(span_753, V.Undef, ((V)((ToNum(s_881) * ((ToNum(W_685) / 2D) - SD_52)))), ((V)((ToNum(s_881) * ((ToNum(W_685) / 2D) - T_698)))));
{ V _t896 = ListOf(_t895);
{ V _t897 = GetIdx(_t896, 0D);
ba_885 = _t897; }
{ V _t898 = GetIdx(_t896, 1D);
bb_886 = _t898; }
} }
{ V _t899 = Call(span_753, V.Undef, ((V)((ToNum(s_881) * ((ToNum(W_685) / 2D) - SD_52)))), ((V)((ToNum(s_881) * (((ToNum(W_685) / 2D) - T_698) - BCd_699)))));
{ V _t900 = ListOf(_t899);
{ V _t901 = GetIdx(_t900, 0D);
ka_887 = _t901; }
{ V _t902 = GetIdx(_t900, 1D);
kb_888 = _t902; }
} }
xs_889 = (ToNum(s_881) * (((ToNum(W_685) / 2D) - T_698) - (BCd_699 / 2D)));
Call(back_754, V.Undef, ca_883, cb_884, ((V)(z0_706)), ((V)(zB_707)));
CallSpread(back_754, V.Undef, new ArrBuilder().Spread(Call(span_753, V.Undef, ((V)((ToNum(s_881) * ((ToNum(W_685) / 2D) - T_698)))), ((V)((ToNum(s_881) * (ToNum(W_685) / 2D)))))).Add(((V)(zB_707))).Add(((V)(zA_710))).V);
Call(@base_755, V.Undef, ba_885, bb_886, ((V)(zB_707)), ((V)(z1_709)));
Call(@base_755, V.Undef, ba_885, bb_886, ((V)(z1_709)), ((V)(zA_710)));
Call(bcush_757, V.Undef, ka_887, kb_888);
A_890 = Call(arm_759, V.Undef, ca_883, cb_884, ((V)(zA_710)), ((V)((ToNum(D_686) / 2D))));
if (SEqS(k_690, "royal")) {
Call(on_748, V.Undef, A_890, Arr(Call(ball_13, V.Undef, ((V)((ToNum(s_881) * ((ToNum(W_685) / 2D) - (SD_52 / 2D))))), ((V)((ToNum(Add(by_691, ((V)(aH_694)))) - 2D))), ((V)(((ToNum(D_686) / 2D) - 12D))), ((V)(4D)), GOLD_25)));
}
return default;
}, 1, "", true));
if (SEqS(k_690, "junk")) {
Invoke(Arr(Arr(((V)(((-ToNum(W_685)) * 0.18))), ((V)(16D)), ((V)(8D)), ((V)("#c9a85a"))), Arr(((V)((ToNum(W_685) * 0.1))), ((V)(12D)), ((V)(7D)), ((V)("#8fa8a0")))), "forEach", Fn((V _arrowThis918, int _argc903, V _a905, V _a906, V _a907, V _a908, V[] _rest904) => {
V j_919 = default;
double bd_920 = 0;
V x_911 = default;
V w_913 = default;
V h_915 = default;
V col_917 = default;
{ V _t909 = ListOf(_a905);
{ V _t910 = GetIdx(_t909, 0D);
x_911 = _t910; }
{ V _t912 = GetIdx(_t909, 1D);
w_913 = _t912; }
{ V _t914 = GetIdx(_t909, 2D);
h_915 = _t914; }
{ V _t916 = GetIdx(_t909, 3D);
col_917 = _t916; }
}
j_919 = ((V)(0D));
bd_920 = 1000000000D;
Invoke(mx_704, "forEach", Fn((V _arrowThis929, int _argc921, V m_927, V i_928, V _a925, V _a926, V[] _rest922) => {
if ((System.Math.Abs((ToNum(m_927) - ToNum(x_911))) < bd_920)) {
bd_920 = System.Math.Abs((ToNum(m_927) - ToNum(x_911)));
j_919 = i_928;
}
return default;
}, 2, "", true));
Call(on_748, V.Undef, GetK(MB_760, j_919), Arr(Call(box_11, V.Undef, ((V)(Max((((ToNum(GetK(mx_704, j_919)) - (cw_703 / 2D)) + (ToNum(w_913) / 2D)) + 1D), Min(((ToNum(Add(GetK(mx_704, j_919), ((V)((cw_703 / 2D))))) - (ToNum(w_913) / 2D)) - 1D), ToNum(x_911))))), Add(by_691, ((V)(4D))), ((V)((z1_709 + 0.6))), w_913, h_915, ((V)(1D)), col_917, NewObj(1).Put("r", ((V)(1D))).V)), F_749);
return default;
}, 1, "", true));
}
return o_747;
return default;
}, 1, "build", true)).V;
return default;
}, 5, "", true);
lsofa_61 = Fn((V _arrowThis937, int _argc930, V S_936, V _a933, V _a934, V _a935, V[] _rest931) => {
return Call(sect_60, V.Undef, S_936, ((V)(270D)), ((V)(182D)), ((V)(2D)), Arr(((V)(1D))));
}, 1, "", true);
usofa_62 = Fn((V _arrowThis945, int _argc938, V S_944, V _a941, V _a942, V _a943, V[] _rest939) => {
return Call(sect_60, V.Undef, S_944, ((V)(330D)), ((V)(182D)), ((V)(2D)), Arr(((V)((-1D))), ((V)(1D))));
}, 1, "", true);
longSofa_63 = Fn((V _arrowThis953, int _argc946, V S_952, V _a949, V _a950, V _a951, V[] _rest947) => {
double n_954 = 0;
double len_955 = 0;
n_954 = Min(4D, ToNum((Get(S_952, "n") is var _t956 && Truthy(_t956) ? _t956 : ((V)(4D)))));
len_955 = ((n_954 * 50D) + 48D);
return NewObj(5).Put("w", ((V)(len_955))).Put("d", ((V)(90D))).Put("act", ((V)("sit"))).Put("seats", Invoke(Call(seatXs_54, V.Undef, ((V)(len_955)), ((V)(n_954)), ((V)(1D)), ((V)(1D))), "map", Fn((V _arrowThis964, int _argc957, V x_963, V _a960, V _a961, V _a962, V[] _rest958) => {
return Call(sit_59, V.Undef, x_963, ((V)(12D)), ((V)(0D)), Get(S_952, "k"));
}, 1, "", true))).Put("build", Fn((V _arrowThis972, int _argc965, V P_971, V _a968, V _a969, V _a970, V[] _rest966) => {
return Call(seg_57, V.Undef, S_952, P_971, ((V)(len_955)), ((V)(n_954)), ((V)(1D)), ((V)(1D)));
}, 1, "build", true)).V;
return default;
}, 1, "", true);
modEnd_64 = Fn((V _arrowThis980, int _argc973, V S_979, V _a976, V _a977, V _a978, V[] _rest974) => {
return NewObj(5).Put("w", ((V)(98D))).Put("d", ((V)(90D))).Put("act", ((V)("sit"))).Put("seats", Arr(Call(sit_59, V.Undef, ((V)(12D)), ((V)(12D)), ((V)(0D)), Get(S_979, "k")))).Put("build", Fn((V _arrowThis988, int _argc981, V P_987, V _a984, V _a985, V _a986, V[] _rest982) => {
return Call(seg_57, V.Undef, S_979, P_987, ((V)(98D)), ((V)(1D)), ((V)(1D)), ((V)(0D)));
}, 1, "build", true)).V;
}, 1, "", true);
modMid_65 = Fn((V _arrowThis996, int _argc989, V S_995, V _a992, V _a993, V _a994, V[] _rest990) => {
return NewObj(5).Put("w", ((V)(74D))).Put("d", ((V)(90D))).Put("act", ((V)("sit"))).Put("seats", Arr(Call(sit_59, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), Get(S_995, "k")))).Put("build", Fn((V _arrowThis1004, int _argc997, V P_1003, V _a1000, V _a1001, V _a1002, V[] _rest998) => {
return Call(seg_57, V.Undef, S_995, P_1003, ((V)(74D)), ((V)(1D)), ((V)(0D)), ((V)(0D)));
}, 1, "build", true)).V;
}, 1, "", true);
modCorner_66 = Fn((V _arrowThis1012, int _argc1005, V S_1011, V _a1008, V _a1009, V _a1010, V[] _rest1006) => {
return NewObj(5).Put("w", ((V)(SD_52))).Put("d", ((V)(SD_52))).Put("act", ((V)("sit"))).Put("seats", Arr(Call(sit_59, V.Undef, ((V)((-6D))), ((V)(8D)), ((V)((-45D))), Get(S_1011, "k")))).Put("build", Fn((V _arrowThis1020, int _argc1013, V P_1019, V _a1016, V _a1017, V _a1018, V[] _rest1014) => {
return Call(corner_58, V.Undef, S_1011, P_1019);
}, 1, "build", true)).V;
}, 1, "", true);
pit_67 = Fn((V _arrowThis1028, int _argc1021, V S_1027, V _a1024, V _a1025, V _a1026, V[] _rest1022) => {
V k_1029 = default;
double R_1030 = 0;
double Rz_1031 = 0;
double a0_1032 = 0;
double a1_1033 = 0;
double N_1034 = 0;
V by_1035 = default;
V ph_1036 = default;
k_1029 = Get(S_1027, "k");
R_1030 = 124D;
Rz_1031 = 100D;
a0_1032 = (System.Math.PI * 0.82);
a1_1033 = (System.Math.PI * 2.18);
N_1034 = 7D;
{ V _t1037 = Call(sty_55, V.Undef, k_1029);
if (_t1037.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1037));
{ V _t1038 = Get(_t1037, "by");
by_1035 = _t1038; } }
ph_1036 = Invoke(Arr(((V)(0.92)), ((V)(1.18)), ((V)(1.5)), ((V)(1.82)), ((V)(2.08))), "map", Fn((V _arrowThis1046, int _argc1039, V f_1045, V _a1042, V _a1043, V _a1044, V[] _rest1040) => {
return ((V)((ToNum(f_1045) * System.Math.PI)));
}, 1, "", true));
return NewObj(6).Put("w", ((V)((R_1030 * 2D)))).Put("d", ((V)((Rz_1031 * 2D)))).Put("round", ((V)(1D))).Put("act", ((V)("sit"))).Put("seats", Invoke(ph_1036, "map", Fn((V _arrowThis1054, int _argc1047, V t_1053, V _a1050, V _a1051, V _a1052, V[] _rest1048) => {
return NewObj(4).Put("x", ((V)(((R_1030 - 30D) * FdLibm.Cos(ToNum(t_1053)))))).Put("z", ((V)(((Rz_1031 - 28D) * FdLibm.Sin(ToNum(t_1053)))))).Put("h", ((V)((ToNum(Call(sH_53, V.Undef, k_1029)) - 4D)))).Put("f", ((V)(((FdLibm.Atan2((-FdLibm.Cos(ToNum(t_1053))), (-FdLibm.Sin(ToNum(t_1053)))) * 180D) / System.Math.PI)))).V;
}, 1, "", true))).Put("build", Fn((V _arrowThis1062, int _argc1055, V P_1061, V _a1058, V _a1059, V _a1060, V[] _rest1056) => {
V o_1063 = default;
V on_1064 = default;
V TB_1065 = default;
o_1063 = Arr();
on_1064 = Call(glue_56, V.Undef, o_1063);
{
double i_1066 = 0;
i_1066 = 0D;
while (true) {
if (!((i_1066 < N_1034))) break;
double t0_1068 = 0;
double t1_1069 = 0;
t0_1068 = (a0_1032 + (((a1_1033 - a0_1032) * i_1066) / N_1034));
t1_1069 = (a0_1032 + (((a1_1033 - a0_1032) * (i_1066 + 1D)) / N_1034));
Invoke(o_1063, "push", Call(arcW_16, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(R_1030)), ((V)(Rz_1031)), ((V)(42D)), Add(by_1035, ((V)(14D))), ((V)(t0_1068)), ((V)(t1_1069)), Get(P_1061, "aD"), NewObj(1).Put("n", ((V)(3D))).V), Call(arcW_16, V.Undef, ((V)(0D)), Add(by_1035, ((V)(14D))), ((V)(0D)), ((V)(R_1030)), ((V)(Rz_1031)), ((V)(42D)), ((V)(10D)), ((V)((t0_1068 + 0.01))), ((V)((t1_1069 - 0.01))), Get(P_1061, "aL"), NewObj(2).Put("n", ((V)(3D))).Put("soft", ((V)(1D))).V), Call(arcW_16, V.Undef, ((V)(0D)), Add(by_1035, ((V)(24D))), ((V)(0D)), ((V)(R_1030)), ((V)(Rz_1031)), ((V)(13D)), ((V)(28D)), ((V)(t0_1068)), ((V)(t1_1069)), Get(P_1061, "a"), NewObj(1).Put("n", ((V)(3D))).V));
i_1066++;
}
}
TB_1065 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(34D)), ((V)(26D)), Get(P_1061, "b"), NewObj(3).Put("rz", ((V)(26D))).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(22D)), ((V)(0D)), ((V)(1D))), Arr(((V)(26D)), ((V)(0D)), ((V)(0.85))))).V);
Invoke(o_1063, "push", TB_1065);
if (SEqS(k_1029, "royal")) {
Invoke(o_1063, "push", Call(arcW_16, V.Undef, ((V)(0D)), Add(by_1035, ((V)(52D))), ((V)(0D)), ((V)((R_1030 + 1D))), ((V)((Rz_1031 + 1D))), ((V)(4D)), ((V)(3D)), ((V)(a0_1032)), ((V)(a1_1033)), GOLD_25, NewObj(1).Put("n", ((V)(14D))).V));
Call(on_1064, V.Undef, TB_1065, Arr(Call(jewel_43, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(4D)), ((V)(6D)))));
}
if (SEqS(k_1029, "candy")) {
Call(on_1064, V.Undef, TB_1065, Call(spr_44, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(4D)), ((V)(40D)), ((V)(30D)), ((V)(6D))));
}
return o_1063;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true);
beanpile_68 = Fn((V _arrowThis1077, int _argc1070, V S_1076, V _a1073, V _a1074, V _a1075, V[] _rest1071) => {
V k_1078 = default;
V B_1079 = default;
k_1078 = Get(S_1076, "k");
B_1079 = Arr(Arr(((V)((-52D))), ((V)((-18D))), ((V)(32D))), Arr(((V)(44D)), ((V)((-24D))), ((V)(30D))), Arr(((V)((-6D))), ((V)(20D)), ((V)(28D))), Arr(((V)(62D)), ((V)(30D)), ((V)(24D))));
return NewObj(5).Put("w", ((V)(200D))).Put("d", ((V)(130D))).Put("act", ((V)("sit"))).Put("seats", Invoke(B_1079, "map", Fn((V _arrowThis1093, int _argc1080, V _a1082, V _a1083, V _a1084, V _a1085, V[] _rest1081) => {
V x_1088 = default;
V z_1090 = default;
V r_1092 = default;
{ V _t1086 = ListOf(_a1082);
{ V _t1087 = GetIdx(_t1086, 0D);
x_1088 = _t1087; }
{ V _t1089 = GetIdx(_t1086, 1D);
z_1090 = _t1089; }
{ V _t1091 = GetIdx(_t1086, 2D);
r_1092 = _t1091; }
}
return NewObj(3).Put("x", x_1088).Put("z", Add(z_1090, ((V)(4D)))).Put("h", ((V)((ToNum(r_1092) * 0.95)))).V;
}, 1, "", true))).Put("build", Fn((V _arrowThis1101, int _argc1094, V P_1100, V _a1097, V _a1098, V _a1099, V[] _rest1095) => {
return Invoke(Invoke(B_1079, "map", Fn((V _arrowThis1116, int _argc1102, V _a1104, V i_1108, V _a1106, V _a1107, V[] _rest1103) => {
V x_1111 = default;
V z_1113 = default;
V r_1115 = default;
{ V _t1109 = ListOf(_a1104);
{ V _t1110 = GetIdx(_t1109, 0D);
x_1111 = _t1110; }
{ V _t1112 = GetIdx(_t1109, 1D);
z_1113 = _t1112; }
{ V _t1114 = GetIdx(_t1109, 2D);
r_1115 = _t1114; }
}
return Call(ball_13, V.Undef, x_1111, ((V)(0D)), z_1113, r_1115, (SEqS(k_1078, "candy") ? GetK(NE_24, GetK(Arr(((V)(0D)), ((V)(2D)), ((V)(4D)), ((V)(1D))), i_1108)) : GetK(Arr(Get(P_1100, "a"), Get(P_1100, "b"), Get(P_1100, "aL"), Get(P_1100, "w")), i_1108)), NewObj(4).Put("sy", ((V)(0.62))).Put("k", ((V)(7D))).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V);
}, 2, "", true)), "concat", (SEqS(k_1078, "junk") ? Arr(Call(box_11, V.Undef, ((V)((-40D))), ((V)(24D)), ((V)(10D)), ((V)(14D)), ((V)(8D)), ((V)(1D)), ((V)("#c9a85a")), NewObj(1).Put("r", ((V)(1D))).V)) : Arr()));
}, 1, "build", true)).V;
return default;
}, 1, "", true);
chaise_69 = Fn((V _arrowThis1124, int _argc1117, V S_1123, V _a1120, V _a1121, V _a1122, V[] _rest1118) => {
V k_1125 = default;
V by_1126 = default;
k_1125 = Get(S_1123, "k");
{ V _t1127 = Call(sty_55, V.Undef, k_1125);
if (_t1127.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1127));
{ V _t1128 = Get(_t1127, "by");
by_1126 = _t1128; } }
return NewObj(5).Put("w", ((V)(176D))).Put("d", ((V)(74D))).Put("act", ((V)("nap"))).Put("seats", Arr(NewObj(4).Put("x", ((V)(14D))).Put("z", ((V)(2D))).Put("h", ((V)(32D))).Put("k", ((V)("nap"))).V)).Put("build", Fn((V _arrowThis1136, int _argc1129, V P_1135, V _a1132, V _a1133, V _a1134, V[] _rest1130) => {
V o_1137 = default;
o_1137 = Arr();
if (!SEqS(k_1125, "junk")) {
InvokeSpread(o_1137, "push", new ArrBuilder().Spread(Call(lg_42, V.Undef, k_1125, P_1135, ((V)(76D)), ((V)(28D)), ((V)(8D)))).V);
}
Invoke(o_1137, "push", Call(box_11, V.Undef, ((V)(0D)), by_1126, ((V)(0D)), ((V)(172D)), ((V)(14D)), ((V)(70D)), Get(P_1135, "aD"), NewObj(2).Put("r", ((V)(10D))).Put("bev", ((V)(3D))).V), Call(pillowY_18, V.Undef, ((V)(6D)), Add(by_1126, ((V)(12D))), ((V)(0D)), ((V)(156D)), ((V)(14D)), ((V)(64D)), Get(P_1135, "aL")), Call(slab_14, V.Undef, ((V)((-76D))), Add(by_1126, ((V)(4D))), ((V)(0D)), ((V)(24D)), ((V)(56D)), ((V)(72D)), Get(P_1135, "a"), NewObj(2).Put("r", ((V)(14D))).Put("soft", ((V)(1D))).V), Call(pillowZ_19, V.Undef, ((V)((-56D))), Add(by_1126, ((V)(22D))), ((V)(0D)), ((V)(26D)), ((V)(26D)), ((V)(60D)), Get(P_1135, "b")));
if (SEqS(k_1125, "royal")) {
InvokeSpread(o_1137, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)((ToNum(by_1126) - 1D))), ((V)(0D)), ((V)(176D)), ((V)(3D)), ((V)(74D)), GOLD_25, NewObj(1).Put("r", ((V)(10D))).V)).Spread(Invoke(Arr(((V)((-40D))), ((V)(0D)), ((V)(40D))), "map", Fn((V _arrowThis1145, int _argc1138, V x_1144, V _a1141, V _a1142, V _a1143, V[] _rest1139) => {
return Call(ball_13, V.Undef, x_1144, Add(by_1126, ((V)(26D))), ((V)(32D)), ((V)(2.4)), GOLD_25, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 1, "", true))).V);
}
if (SEqS(k_1125, "junk")) {
InvokeSpread(o_1137, "push", new ArrBuilder().Spread(Invoke(Arr(((V)((-60D))), ((V)(0D)), ((V)(60D))), "map", Fn((V _arrowThis1153, int _argc1146, V x_1152, V _a1149, V _a1150, V _a1151, V[] _rest1147) => {
return Call(box_11, V.Undef, x_1152, ((V)(0D)), ((V)(0D)), ((V)(6D)), Add(by_1126, ((V)(6D))), ((V)(70D)), OLD_31, NewObj(1).Put("r", ((V)(1D))).V);
}, 1, "", true))).V);
}
return o_1137;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true);
tvGlow_70 = Fn((V _arrowThis1161, int _argc1154, V v_1160, V _a1157, V _a1158, V _a1159, V[] _rest1155) => {
return (SEqS(v_1160, "on") ? NewObj(3).Put("y", ((V)(76D))).Put("r", ((V)(70D))).Put("c", ((V)("url(#gNeon)"))).V : V.Null);
}, 1, "", true);
tvstand_71 = Fn((V _arrowThis1169, int _argc1162, V S_1168, V _a1165, V _a1166, V _a1167, V[] _rest1163) => {
return NewObj(7).Put("w", ((V)(150D))).Put("d", ((V)(56D))).Put("act", ((V)("watch"))).Put("anim", ((V)("tv"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(118D))).V).Put("glow", tvGlow_70).Put("build", Fn((V _arrowThis1178, int _argc1170, V P_1176, V v_1177, V _a1174, V _a1175, V[] _rest1171) => {
V k_1179 = default;
V on_1180 = default;
V o_1181 = default;
k_1179 = Get(S_1168, "k");
on_1180 = (SEqS(v_1177, "on") ? V.True : V.False);
o_1181 = Arr();
if (SEqS(k_1179, "junk")) {
InvokeSpread(o_1181, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(110D)), ((V)(34D)), ((V)(46D)), OLD_31, NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(23.4)), ((V)(104D)), ((V)(4D)), ((V)(1D)), Call(shade_21, V.Undef, OLD_31, ((V)(0.8))))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(23.4)), ((V)(104D)), ((V)(4D)), ((V)(1D)), Call(shade_21, V.Undef, OLD_31, ((V)(0.8))))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(34D)), ((V)((-2D))), ((V)(76D)), ((V)(58D)), ((V)(44D)), ((V)("#7a7066")), NewObj(2).Put("r", ((V)(8D))).Put("bev", ((V)(2D))).V)).Spread(Call(scr_46, V.Undef, ((V)((-6D))), ((V)(42D)), ((V)(20.6)), ((V)(52D)), ((V)(40D)), on_1180, Get(P_1176, "b"))).Add(Call(box_11, V.Undef, ((V)(26D)), ((V)(46D)), ((V)(20.8)), ((V)(8D)), ((V)(30D)), ((V)(1D)), ((V)("#5a5048")), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(ball_13, V.Undef, ((V)(26D)), ((V)(74D)), ((V)(21D)), ((V)(2.6)), ((V)("#c9a85a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).Add(Call(box_11, V.Undef, ((V)((-8D))), ((V)(92D)), ((V)((-2D))), ((V)(2D)), ((V)(24D)), ((V)(2D)), DK_29, NewObj(1).Put("yaw", ((V)(0.4))).V)).Add(Call(box_11, V.Undef, ((V)(8D)), ((V)(92D)), ((V)((-2D))), ((V)(2D)), ((V)(22D)), ((V)(2D)), DK_29)).Add(Call(ball_13, V.Undef, ((V)((-10D))), ((V)(114D)), ((V)((-2D))), ((V)(2.4)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).V);
return o_1181;
}
if (SEqS(k_1179, "cot")) {
InvokeSpread(o_1181, "push", new ArrBuilder().Spread(Call(lg_42, V.Undef, k_1179, P_1176, ((V)(62D)), ((V)(20D)), ((V)(8D)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(140D)), ((V)(38D)), ((V)(50D)), Get(P_1176, "w"), NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)((-34D))), ((V)(12D)), ((V)(25.4)), ((V)(62D)), ((V)(30D)), ((V)(1D)), Call(shade_21, V.Undef, Get(P_1176, "w"), ((V)(0.9))), NewObj(1).Put("r", ((V)(3D))).V)).Add(Call(box_11, V.Undef, ((V)(34D)), ((V)(12D)), ((V)(25.4)), ((V)(62D)), ((V)(30D)), ((V)(1D)), Call(shade_21, V.Undef, Get(P_1176, "w"), ((V)(0.9))), NewObj(1).Put("r", ((V)(3D))).V)).Add(Call(ball_13, V.Undef, ((V)((-6D))), ((V)(26D)), ((V)(26D)), ((V)(2D)), GOLD_25)).Add(Call(ball_13, V.Undef, ((V)(6D)), ((V)(26D)), ((V)(26D)), ((V)(2D)), GOLD_25)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(0D)), ((V)(20D)), ((V)(6D)), ((V)(14D)), Call(shade_21, V.Undef, Get(P_1176, "w"), ((V)(0.7))))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(52D)), ((V)(0D)), ((V)(104D)), ((V)(66D)), ((V)(8D)), Call(shade_21, V.Undef, Get(P_1176, "w"), ((V)(0.78))), NewObj(1).Put("r", ((V)(4D))).V)).Spread(Call(scr_46, V.Undef, ((V)(0D)), ((V)(57D)), ((V)(4.4)), ((V)(92D)), ((V)(56D)), on_1180, Get(P_1176, "b"))).Add(Call(ball_13, V.Undef, ((V)((-40D))), ((V)(46D)), ((V)(14D)), ((V)(8D)), LEAF_34, NewObj(1).Put("sy", ((V)(0.8))).V)).V);
return o_1181;
}
if (SEqS(k_1179, "retro")) {
InvokeSpread(o_1181, "push", new ArrBuilder().Spread(Call(lg_42, V.Undef, k_1179, P_1176, ((V)(60D)), ((V)(18D)), ((V)(16D)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)), ((V)(140D)), ((V)(36D)), ((V)(48D)), Get(P_1176, "a"), NewObj(2).Put("r", ((V)(10D))).Put("bev", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(42D)), ((V)(20D)), ((V)(24.4)), ((V)(44D)), ((V)(28D)), ((V)(0.8)), ((V)("#c9b48e")), NewObj(1).Put("r", ((V)(4D))).V)).Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "map", Fn((V _arrowThis1189, int _argc1182, V i_1188, V _a1185, V _a1186, V _a1187, V[] _rest1183) => {
return Call(box_11, V.Undef, ((V)(42D)), ((V)((23D + (ToNum(i_1188) * 6D)))), ((V)(25D)), ((V)(40D)), ((V)(1.4)), ((V)(0.4)), ((V)("#a88660")));
}, 1, "", true))).Add(Call(slab_14, V.Undef, ((V)((-14D))), ((V)(52D)), ((V)(0D)), ((V)(92D)), ((V)(66D)), ((V)(40D)), CR_27, NewObj(1).Put("r", ((V)(18D))).V)).Spread(Call(scr_46, V.Undef, ((V)((-14D))), ((V)(59D)), ((V)(20.4)), ((V)(74D)), ((V)(50D)), on_1180, Get(P_1176, "b"))).Spread(Invoke(Arr(((V)((-34D))), ((V)((-22D)))), "map", Fn((V _arrowThis1197, int _argc1190, V x_1196, V _a1193, V _a1194, V _a1195, V[] _rest1191) => {
return Call(box_11, V.Undef, x_1196, ((V)(118D)), ((V)(0D)), ((V)(2D)), ((V)(20D)), ((V)(2D)), CH_26, NewObj(1).Put("yaw", ((V)((LtN(x_1196, (-30D)) ? 0.5 : (-0.5))))).V);
}, 1, "", true))).V);
return o_1181;
}
if (SEqS(k_1179, "mod")) {
InvokeSpread(o_1181, "push", new ArrBuilder().Spread(Call(lg_42, V.Undef, k_1179, P_1176, ((V)(66D)), ((V)(18D)), ((V)(10D)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(150D)), ((V)(26D)), ((V)(46D)), Get(P_1176, "a"), NewObj(1).Put("r", ((V)(3D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(23.4)), ((V)(140D)), ((V)(18D)), ((V)(0.6)), Call(shade_21, V.Undef, Get(P_1176, "a"), ((V)(0.9))), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(36D)), ((V)((-6D))), ((V)(30D)), ((V)(4D)), ((V)(18D)), DK_29, NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)((-6D))), ((V)(6D)), ((V)(10D)), ((V)(4D)), DK_29)).Add(Call(slab_14, V.Undef, ((V)(0D)), ((V)(46D)), ((V)((-6D))), ((V)(136D)), ((V)(80D)), ((V)(4D)), ((V)("#24262c")), NewObj(1).Put("r", ((V)(3D))).V)).Spread(Call(scr_46, V.Undef, ((V)(0D)), ((V)(50D)), ((V)((-3.6))), ((V)(128D)), ((V)(72D)), on_1180, Get(P_1176, "b"))).V);
return o_1181;
}
if (SEqS(k_1179, "candy")) {
InvokeSpread(o_1181, "push", new ArrBuilder().Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(66D)), ((V)(22D)), Get(P_1176, "a"), NewObj(2).Put("rz", ((V)(26D))).Put("n", ((V)(20D))).V)).Spread(Call(drips_45, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(26D)), ((V)(110D)), CR_27, ((V)(7D)))).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(56D)), ((V)(16D)), Get(P_1176, "b"), NewObj(2).Put("rz", ((V)(22D))).Put("n", ((V)(20D))).V)).Spread(Call(spr_44, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(0D)), ((V)(90D)), ((V)(20D)), ((V)(8D)))).Add(Call(slab_14, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(100D)), ((V)(70D)), ((V)(22D)), Get(P_1176, "b"), NewObj(1).Put("r", ((V)(26D))).V)).Spread(Call(scr_46, V.Undef, ((V)(0D)), ((V)(48D)), ((V)(11.4)), ((V)(80D)), ((V)(52D)), on_1180, Get(P_1176, "a"))).Add(Call(ball_13, V.Undef, ((V)((-40D))), ((V)(104D)), ((V)(0D)), ((V)(9D)), Get(P_1176, "a"))).Add(Call(ball_13, V.Undef, ((V)(40D)), ((V)(104D)), ((V)(0D)), ((V)(9D)), Get(P_1176, "a"))).V);
return o_1181;
}
InvokeSpread(o_1181, "push", new ArrBuilder().Spread(Call(lg_42, V.Undef, k_1179, P_1176, ((V)(62D)), ((V)(20D)), ((V)(10D)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(144D)), ((V)(40D)), ((V)(50D)), ((V)("#f4f1ea")), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(148D)), ((V)(3D)), ((V)(54D)), GOLD_25, NewObj(1).Put("r", ((V)(6D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(48D)), ((V)(0D)), ((V)(148D)), ((V)(3D)), ((V)(54D)), GOLD_25, NewObj(1).Put("r", ((V)(6D))).V)).Add(Call(jewel_43, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(26D)), ((V)(4D)))).Add(Call(slab_14, V.Undef, ((V)(0D)), ((V)(54D)), ((V)((-2D))), ((V)(116D)), ((V)(76D)), ((V)(8D)), GOLD_25, NewObj(1).Put("r", ((V)(6D))).V)).Spread(Call(scr_46, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(2.4)), ((V)(100D)), ((V)(62D)), on_1180, ((V)("#8f7bff")))).Add(Call(jewel_43, V.Undef, ((V)(0D)), ((V)(134D)), ((V)((-2D))), ((V)(6D)))).V);
return o_1181;
return default;
}, 2, "build", true)).V;
}, 1, "", true);
miniTV_72 = Fn((V _arrowThis1205, int _argc1198, V S_1204, V _a1201, V _a1202, V _a1203, V[] _rest1199) => {
return NewObj(8).Put("w", ((V)(48D))).Put("d", ((V)(36D))).Put("small", ((V)(1D))).Put("act", ((V)("watch"))).Put("anim", ((V)("tv"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(70D))).V).Put("glow", tvGlow_70).Put("build", Fn((V _arrowThis1214, int _argc1206, V P_1212, V v_1213, V _a1210, V _a1211, V[] _rest1207) => {
V k_1215 = default;
V on_1216 = default;
V c_1217 = default;
k_1215 = Get(S_1204, "k");
on_1216 = (SEqS(v_1213, "on") ? V.True : V.False);
c_1217 = (SEqS(k_1215, "junk") ? ((V)("#7a7066")) : (SEqS(k_1215, "royal") ? GOLD_25 : Get(P_1212, "a")));
return new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)(36D)), ((V)(32D)), c_1217, NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V)).Spread(Call(scr_46, V.Undef, ((V)((-4D))), ((V)(6D)), ((V)(16.2)), ((V)(28D)), ((V)(24D)), on_1216, Get(P_1212, "b"))).Add(Call(ball_13, V.Undef, ((V)(14D)), ((V)(20D)), ((V)(16.4)), ((V)(2.2)), CR_27, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).Add(Call(ball_13, V.Undef, ((V)(14D)), ((V)(12D)), ((V)(16.4)), ((V)(2.2)), CR_27, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).Add(Call(box_11, V.Undef, ((V)((-6D))), ((V)(36D)), ((V)(0D)), ((V)(1.6)), ((V)(16D)), ((V)(1.6)), DK_29, NewObj(1).Put("yaw", ((V)(0.5))).V)).Add(Call(box_11, V.Undef, ((V)(6D)), ((V)(36D)), ((V)(0D)), ((V)(1.6)), ((V)(14D)), ((V)(1.6)), DK_29)).V;
return default;
}, 2, "build", true)).V;
}, 1, "", true);
wallTV_73 = Fn((V _arrowThis1225, int _argc1218, V S_1224, V _a1221, V _a1222, V _a1223, V[] _rest1219) => {
return NewObj(9).Put("w", ((V)(150D))).Put("d", ((V)(10D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(40D))).Put("act", ((V)("watch"))).Put("anim", ((V)("tv"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(150D))).V).Put("glow", tvGlow_70).Put("build", Fn((V _arrowThis1234, int _argc1226, V P_1232, V v_1233, V _a1230, V _a1231, V[] _rest1227) => {
V k_1235 = default;
V on_1236 = default;
V fc_1237 = default;
V o_1238 = default;
k_1235 = Get(S_1224, "k");
on_1236 = (SEqS(v_1233, "on") ? V.True : V.False);
fc_1237 = (SEqS(k_1235, "royal") ? GOLD_25 : (SEqS(k_1235, "candy") ? Get(P_1232, "b") : (SEqS(k_1235, "cot") ? Call(shade_21, V.Undef, Get(P_1232, "w"), ((V)(0.8))) : (SEqS(k_1235, "retro") ? CR_27 : ((V)("#24262c"))))));
o_1238 = new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(20D)), ((V)((-4D))), ((V)(34D)), ((V)(34D)), ((V)(3D)), DK_29, NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)(140D)), ((V)(80D)), ((V)(5D)), fc_1237, NewObj(1).Put("r", ((V)((SEqS(k_1235, "candy") ? 18D : (SEqS(k_1235, "retro") ? 12D : 4D))))).V)).Spread(Call(scr_46, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(3.8)), ((V)(128D)), ((V)(70D)), on_1236, Get(P_1232, "a"))).V;
if (SEqS(k_1235, "royal")) {
Invoke(o_1238, "push", Call(jewel_43, V.Undef, ((V)(0D)), ((V)(82D)), ((V)(1D)), ((V)(5D))));
}
if (SEqS(k_1235, "candy")) {
InvokeSpread(o_1238, "push", new ArrBuilder().Spread(Invoke(Arr(((V)((-50D))), ((V)((-20D))), ((V)(20D)), ((V)(50D))), "map", Fn((V _arrowThis1247, int _argc1239, V x_1245, V i_1246, V _a1243, V _a1244, V[] _rest1240) => {
return Call(ball_13, V.Undef, x_1245, ((V)(74D)), ((V)(3D)), ((V)(4D)), GetK(NE_24, i_1246));
}, 2, "", true))).V);
}
return o_1238;
return default;
}, 2, "build", true)).V;
}, 1, "", true);
projector_74 = Fn((V _arrowThis1255, int _argc1248, V S_1254, V _a1251, V _a1252, V _a1253, V[] _rest1249) => {
return NewObj(9).Put("w", ((V)(236D))).Put("d", ((V)(10D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(24D))).Put("act", ((V)("watch"))).Put("anim", ((V)("tv"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(170D))).V).Put("glow", Fn((V _arrowThis1263, int _argc1256, V v_1262, V _a1259, V _a1260, V _a1261, V[] _rest1257) => {
return (SEqS(v_1262, "on") ? NewObj(3).Put("y", ((V)(60D))).Put("r", ((V)(110D))).Put("c", ((V)("url(#gNeon)"))).V : V.Null);
}, 1, "glow", true)).Put("build", Fn((V _arrowThis1272, int _argc1264, V P_1270, V v_1271, V _a1268, V _a1269, V[] _rest1265) => {
V k_1273 = default;
V on_1274 = default;
V mt_1275 = default;
V o_1276 = default;
k_1273 = Get(S_1254, "k");
on_1274 = (SEqS(v_1271, "on") ? V.True : V.False);
mt_1275 = GetK(MT_37, k_1273);
o_1276 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(110D)), ((V)(2D)), ((V)(232D)), ((V)(9D)), ((V)(9D)), (SEqS(k_1273, "mod") ? DK_29 : mt_1275), NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(1D)), ((V)(214D)), ((V)(104D)), ((V)(1D)), ((V)("#f4f4f0")), NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(218D)), ((V)(5D)), ((V)(4D)), mt_1275, NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)((-10D))), ((V)(3D)), ((V)(3D)), ((V)(10D)), mt_1275, NewObj(1).Put("n", ((V)(6D))).V));
if (Truthy(on_1274)) {
InvokeSpread(o_1276, "push", new ArrBuilder().Spread(Call(scr_46, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(2.2)), ((V)(204D)), ((V)(96D)), (true ? V.True : V.False), Get(P_1270, "b"))).V);
} else {
Invoke(o_1276, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(1.8)), ((V)(200D)), ((V)(92D)), ((V)(0.4)), ((V)("#e8e8e2")), NewObj(1).Put("r", ((V)(2D))).V));
}
if (SEqS(k_1273, "retro")) {
InvokeSpread(o_1276, "push", new ArrBuilder().Spread(Invoke(Arr(((V)((-90D))), ((V)((-60D))), ((V)((-30D))), ((V)(0D)), ((V)(30D)), ((V)(60D)), ((V)(90D))), "map", Fn((V _arrowThis1285, int _argc1277, V x_1283, V i_1284, V _a1281, V _a1282, V[] _rest1278) => {
return Call(ball_13, V.Undef, x_1283, ((V)(118D)), ((V)(6D)), ((V)(3.5)), GetIdx(NE_24, (ToNum(i_1284) % 6D)), NewObj(3).Put("emit", ((V)(1D))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 2, "", true))).V);
}
if (SEqS(k_1273, "royal")) {
Invoke(o_1276, "push", Call(slab_14, V.Undef, ((V)((-112D))), ((V)(0D)), ((V)(4D)), ((V)(12D)), ((V)(118D)), ((V)(4D)), ((V)("#7a2a3a")), NewObj(1).Put("r", ((V)(4D))).V), Call(slab_14, V.Undef, ((V)(112D)), ((V)(0D)), ((V)(4D)), ((V)(12D)), ((V)(118D)), ((V)(4D)), ((V)("#7a2a3a")), NewObj(1).Put("r", ((V)(4D))).V), Call(jewel_43, V.Undef, ((V)(0D)), ((V)(120D)), ((V)(6D)), ((V)(5D))));
}
return o_1276;
return default;
}, 2, "build", true)).V;
}, 1, "", true);
SPB_75 = Fn((V _arrowThis1294, int _argc1286, V k_1292, V P_1293, V _a1290, V _a1291, V[] _rest1287) => {
return (SEqS(k_1292, "junk") ? ((V)("#5a5f6a")) : (SEqS(k_1292, "cot") ? Get(P_1293, "w") : (SEqS(k_1292, "retro") ? CR_27 : (SEqS(k_1292, "mod") ? ((V)("#2f2f3a")) : (SEqS(k_1292, "candy") ? Get(P_1293, "a") : ((V)("#f4f1ea")))))));
}, 2, "", true);
RING_76 = Fn((V _arrowThis1302, int _argc1295, V k_1301, V _a1298, V _a1299, V _a1300, V[] _rest1296) => {
return (SEqS(k_1301, "royal") ? GOLD_25 : ((V)((SEqS(k_1301, "candy") ? "#fff1a0" : (SEqS(k_1301, "retro") ? "#e2554a" : "#4fe0d0")))));
}, 1, "", true);
spk_77 = Fn((V _arrowThis1310, int _argc1303, V o_1309, V _a1306, V _a1307, V _a1308, V[] _rest1304) => {
return Object_assign(NewObj(5).Put("act", ((V)("party"))).Put("anim", ((V)("pulse"))).Put("party", ((V)(1D))).Put("bass", ((V)(1D))).Put("glow", Fn((V _arrowThis1318, int _argc1311, V v_1317, V _a1314, V _a1315, V _a1316, V[] _rest1312) => {
return (SEqS(v_1317, "on") ? NewObj(3).Put("y", ((V)(70D))).Put("r", ((V)(90D))).Put("c", ((V)("url(#gNeon)"))).V : V.Null);
}, 1, "glow", true)).V, o_1309);
}, 1, "", true);
spkTower_78 = Fn((V _arrowThis1326, int _argc1319, V S_1325, V _a1322, V _a1323, V _a1324, V[] _rest1320) => {
return Call(spk_77, V.Undef, NewObj(4).Put("w", ((V)(70D))).Put("d", ((V)(50D))).Put("pivot", Arr(((V)(0D)), ((V)(75D)), ((V)(24D)))).Put("build", Fn((V _arrowThis1335, int _argc1327, V P_1333, V v_1334, V _a1331, V _a1332, V[] _rest1328) => {
V k_1336 = default;
V on_1337 = default;
V b_1338 = default;
V rg_1339 = default;
V o_1340 = default;
k_1336 = Get(S_1325, "k");
on_1337 = (SEqS(v_1334, "on") ? V.True : V.False);
b_1338 = Call(SPB_75, V.Undef, k_1336, P_1333);
rg_1339 = Call(RING_76, V.Undef, k_1336);
o_1340 = Arr();
Invoke(o_1340, "push", (SEqS(k_1336, "candy") ? Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(64D)), ((V)(150D)), ((V)(46D)), b_1338, NewObj(1).Put("r", ((V)(30D))).V) : Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(64D)), ((V)(150D)), ((V)(46D)), b_1338, NewObj(2).Put("r", ((V)((SEqS(k_1336, "retro") ? 14D : 6D)))).Put("bev", ((V)(2D))).V)));
InvokeSpread(o_1340, "push", new ArrBuilder().Spread(Call(cone_48, V.Undef, ((V)(0D)), ((V)(124D)), ((V)(23.2)), ((V)(11D)), ((V)("#3b3e46")), rg_1339, on_1337)).Spread(Call(cone_48, V.Undef, ((V)(0D)), ((V)(86D)), ((V)(23.2)), ((V)(19D)), ((V)("#3b3e46")), rg_1339, on_1337)).Spread(Call(cone_48, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(23.2)), ((V)(24D)), ((V)("#3b3e46")), rg_1339, on_1337)).V);
Invoke(Arr(((V)((-29D))), ((V)(29D))), "forEach", Fn((V _arrowThis1348, int _argc1341, V x_1347, V _a1344, V _a1345, V _a1346, V[] _rest1342) => {
return Invoke(o_1340, "push", Call(box_11, V.Undef, x_1347, ((V)(6D)), ((V)(23.6)), ((V)(2.6)), ((V)(138D)), ((V)(0.6)), (Truthy(on_1337) ? GetIdx(NE_24, (GtN(x_1347, 0D) ? 4D : 0D)) : Call(shade_21, V.Undef, b_1338, ((V)(0.8)))), NewObj(1).Put("emit", ((V)((Truthy(on_1337) ? 1D : 0D)))).V));
}, 1, "", true));
if (SEqS(k_1336, "royal")) {
Invoke(o_1340, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(68D)), ((V)(4D)), ((V)(50D)), GOLD_25, NewObj(1).Put("r", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(146D)), ((V)(0D)), ((V)(68D)), ((V)(4D)), ((V)(50D)), GOLD_25, NewObj(1).Put("r", ((V)(6D))).V), Call(jewel_43, V.Undef, ((V)(0D)), ((V)(150D)), ((V)(0D)), ((V)(7D))));
}
if (SEqS(k_1336, "candy")) {
InvokeSpread(o_1340, "push", new ArrBuilder().Add(Call(ball_13, V.Undef, ((V)(0D)), ((V)(140D)), ((V)(0D)), ((V)(16D)), ((V)("#e2554a")))).Spread(Call(spr_44, V.Undef, ((V)(0D)), ((V)(150D)), ((V)(0D)), ((V)(30D)), ((V)(20D)), ((V)(5D)))).V);
}
if (SEqS(k_1336, "retro")) {
Invoke(o_1340, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(146D)), ((V)(0D)), ((V)(66D)), ((V)(4D)), ((V)(48D)), CH_26, NewObj(1).Put("r", ((V)(8D))).V));
}
if (SEqS(k_1336, "junk")) {
Invoke(o_1340, "push", Call(box_11, V.Undef, ((V)((-18D))), ((V)(102D)), ((V)(23.6)), ((V)(12D)), ((V)(8D)), ((V)(0.6)), ((V)("#c9a85a")), NewObj(1).Put("r", ((V)(1D))).V));
}
return o_1340;
return default;
}, 2, "build", true)).V);
}, 1, "", true);
spkWall_79 = Fn((V _arrowThis1356, int _argc1349, V S_1355, V _a1352, V _a1353, V _a1354, V[] _rest1350) => {
return Call(spk_77, V.Undef, NewObj(4).Put("w", ((V)(214D))).Put("d", ((V)(52D))).Put("pivot", Arr(((V)(0D)), ((V)(70D)), ((V)(26D)))).Put("build", Fn((V _arrowThis1365, int _argc1357, V P_1363, V v_1364, V _a1361, V _a1362, V[] _rest1358) => {
V k_1366 = default;
V on_1367 = default;
V b_1368 = default;
V rg_1369 = default;
V o_1370 = default;
k_1366 = Get(S_1355, "k");
on_1367 = (SEqS(v_1364, "on") ? V.True : V.False);
b_1368 = Call(SPB_75, V.Undef, k_1366, P_1363);
rg_1369 = Call(RING_76, V.Undef, k_1366);
o_1370 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(0D)), ((V)(1D))), "forEach", Fn((V _arrowThis1378, int _argc1371, V i_1377, V _a1374, V _a1375, V _a1376, V[] _rest1372) => {
return Invoke(Arr(((V)(0D)), ((V)(1D))), "forEach", Fn((V _arrowThis1386, int _argc1379, V j_1385, V _a1382, V _a1383, V _a1384, V[] _rest1380) => {
double x_1387 = 0;
double y_1388 = 0;
V big_1389 = default;
x_1387 = (ToNum(i_1377) * 70D);
y_1388 = (ToNum(j_1385) * 72D);
big_1389 = (SEqN(j_1385, 0D) ? V.True : V.False);
InvokeSpread(o_1370, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(x_1387)), ((V)(y_1388)), ((V)(0D)), ((V)(68D)), ((V)(70D)), ((V)(48D)), (SEqS(k_1366, "junk") ? ((V)((NumTruthy((ToNum(Add(i_1377, j_1385)) % 2D)) ? "#b89a74" : "#a88660"))) : b_1368), NewObj(2).Put("r", ((V)(5D))).Put("bev", ((V)(2D))).V)).Spread(Call(cone_48, V.Undef, ((V)(x_1387)), ((V)((y_1388 + 35D))), ((V)(24.2)), ((V)((Truthy(big_1389) ? 26D : 18D))), ((V)("#3b3e46")), rg_1369, on_1367)).V);
if (!(Truthy(big_1389))) {
InvokeSpread(o_1370, "push", new ArrBuilder().Spread(Call(cone_48, V.Undef, ((V)((x_1387 + 22D))), ((V)((y_1388 + 58D))), ((V)(24.2)), ((V)(6D)), ((V)("#3b3e46")), rg_1369, on_1367)).V);
}
return default;
}, 1, "", true));
}, 1, "", true));
Invoke(o_1370, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(144D)), ((V)(0D)), ((V)(206D)), ((V)(5D)), ((V)(48D)), (SEqS(k_1366, "royal") ? GOLD_25 : Call(shade_21, V.Undef, b_1368, ((V)(0.8)))), NewObj(1).Put("r", ((V)(3D))).V));
{
double i_1390 = 0;
i_1390 = 0D;
while (true) {
if (!((i_1390 < 9D))) break;
Invoke(o_1370, "push", Call(ball_13, V.Undef, ((V)(((-96D) + (i_1390 * 24D)))), ((V)(149D)), ((V)(18D)), ((V)(3.4)), (Truthy(on_1367) ? GetIdx(NE_24, (i_1390 % 6D)) : ((V)("#6a6f78"))), NewObj(3).Put("emit", ((V)((Truthy(on_1367) ? 1D : 0D)))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
i_1390++;
}
}
if (SEqS(k_1366, "royal")) {
Invoke(o_1370, "push", Call(jewel_43, V.Undef, ((V)(0D)), ((V)(150D)), ((V)(0D)), ((V)(8D))));
}
if (SEqS(k_1366, "junk")) {
Invoke(o_1370, "push", Call(box_11, V.Undef, ((V)(70D)), ((V)(138D)), ((V)(0D)), ((V)(60D)), ((V)(6D)), ((V)(44D)), ((V)("#c9b48e")), NewObj(1).Put("r", ((V)(1D))).V));
}
return o_1370;
return default;
}, 2, "build", true)).V);
}, 1, "", true);
sub_80 = Fn((V _arrowThis1399, int _argc1392, V S_1398, V _a1395, V _a1396, V _a1397, V[] _rest1393) => {
return Call(spk_77, V.Undef, NewObj(5).Put("w", ((V)(104D))).Put("d", ((V)(92D))).Put("pivot", Arr(((V)(0D)), ((V)(48D)), ((V)(46D)))).Put("pk", ((V)(2.2))).Put("build", Fn((V _arrowThis1408, int _argc1400, V P_1406, V v_1407, V _a1404, V _a1405, V[] _rest1401) => {
V k_1409 = default;
V on_1410 = default;
V b_1411 = default;
V o_1412 = default;
k_1409 = Get(S_1398, "k");
on_1410 = (SEqS(v_1407, "on") ? V.True : V.False);
b_1411 = Call(SPB_75, V.Undef, k_1409, P_1406);
o_1412 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(98D)), ((V)(96D)), ((V)(88D)), b_1411, NewObj(2).Put("r", ((V)(9D))).Put("bev", ((V)(3D))).V), Call(disc_17, V.Undef, ((V)(0D)), ((V)(48D)), ((V)(44D)), ((V)(42D)), ((V)(1.4)), Call(shade_21, V.Undef, b_1411, ((V)(0.7)))), Call(disc_17, V.Undef, ((V)(0D)), ((V)(48D)), ((V)(45.2)), ((V)(38D)), ((V)(3D)), ((V)("#30333a")), NewObj(2).Put("top", ((V)(6D))).Put("part", ((V)(1D))).V), Call(disc_17, V.Undef, ((V)(0D)), ((V)(48D)), ((V)(48.6)), ((V)(15D)), ((V)(3D)), Call(RING_76, V.Undef, k_1409), NewObj(3).Put("part", ((V)(1D))).Put("emit", ((V)((Truthy(on_1410) ? 1D : 0D)))).Put("top", ((V)(2D))).V));
Invoke(Arr(((V)((-36D))), ((V)(36D))), "forEach", Fn((V _arrowThis1420, int _argc1413, V x_1419, V _a1416, V _a1417, V _a1418, V[] _rest1414) => {
return Invoke(o_1412, "push", Call(disc_17, V.Undef, x_1419, ((V)(12D)), ((V)(44.2)), ((V)(5D)), ((V)(1D)), ((V)("#1e2026"))));
}, 1, "", true));
if (SEqS(k_1409, "royal")) {
Invoke(o_1412, "push", Call(prismZ_23, V.Undef, ((V)((-6D))), ((V)(6D)), Arr(Arr(((V)((-22D))), ((V)(96D))), Arr(((V)((-14D))), ((V)(118D))), Arr(((V)((-6D))), ((V)(104D))), Arr(((V)(0D)), ((V)(122D))), Arr(((V)(6D)), ((V)(104D))), Arr(((V)(14D)), ((V)(118D))), Arr(((V)(22D)), ((V)(96D)))), GOLD_25), Call(jewel_43, V.Undef, ((V)(0D)), ((V)(120D)), ((V)(0D)), ((V)(4D))));
}
if (SEqS(k_1409, "candy")) {
InvokeSpread(o_1412, "push", new ArrBuilder().Spread(Call(drips_45, V.Undef, ((V)(0D)), ((V)(96D)), ((V)(44D)), ((V)(80D)), Get(P_1406, "b"), ((V)(6D)))).V);
}
return o_1412;
return default;
}, 2, "build", true)).V);
}, 1, "", true);
smokeSpk_81 = Fn((V _arrowThis1428, int _argc1421, V S_1427, V _a1424, V _a1425, V _a1426, V[] _rest1422) => {
return Call(spk_77, V.Undef, NewObj(5).Put("w", ((V)(82D))).Put("d", ((V)(58D))).Put("pivot", Arr(((V)(0D)), ((V)(60D)), ((V)(26D)))).Put("smoke", ((V)(1D))).Put("build", Fn((V _arrowThis1437, int _argc1429, V P_1435, V v_1436, V _a1433, V _a1434, V[] _rest1430) => {
V k_1438 = default;
V on_1439 = default;
V b_1440 = default;
V rg_1441 = default;
V o_1442 = default;
k_1438 = Get(S_1427, "k");
on_1439 = (SEqS(v_1436, "on") ? V.True : V.False);
b_1440 = Call(SPB_75, V.Undef, k_1438, P_1435);
rg_1441 = Call(RING_76, V.Undef, k_1438);
o_1442 = new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(76D)), ((V)(120D)), ((V)(52D)), b_1440, NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V)).Spread(Call(cone_48, V.Undef, ((V)(0D)), ((V)(84D)), ((V)(26.2)), ((V)(18D)), ((V)("#3b3e46")), rg_1441, on_1439)).Spread(Call(cone_48, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(26.2)), ((V)(26D)), ((V)("#3b3e46")), rg_1441, on_1439)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(120D)), ((V)(0D)), ((V)(66D)), ((V)(10D)), ((V)(40D)), DK_29, NewObj(1).Put("r", ((V)(3D))).V)).V;
{
double i_1443 = 0;
i_1443 = 0D;
while (true) {
if (!((i_1443 < 4D))) break;
Invoke(o_1442, "push", Call(ball_13, V.Undef, ((V)(((-24D) + (i_1443 * 16D)))), ((V)(130D)), ((V)(6D)), ((V)(5.5)), (Truthy(on_1439) ? GetIdx(NE_24, ((i_1443 * 2D) % 6D)) : ((V)("#7a7f88"))), NewObj(4).Put("emit", ((V)((Truthy(on_1439) ? 1D : 0D)))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("part", ((V)(1D))).V));
i_1443++;
}
}
Invoke(o_1442, "push", Call(cyl_12, V.Undef, ((V)((-30D))), ((V)(120D)), ((V)((-12D))), ((V)(5D)), ((V)(18D)), ((V)("#8a8f94")), NewObj(1).Put("n", ((V)(8D))).V), Call(ball_13, V.Undef, ((V)((-30D))), ((V)(138D)), ((V)((-12D))), ((V)(5D)), CR_27, NewObj(1).Put("sy", ((V)(0.8))).V));
if (SEqS(k_1438, "royal")) {
Invoke(o_1442, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(4D)), ((V)(56D)), GOLD_25, NewObj(1).Put("r", ((V)(6D))).V), Call(jewel_43, V.Undef, ((V)(0D)), ((V)(118D)), ((V)(26D)), ((V)(4D))));
}
return o_1442;
return default;
}, 2, "build", true)).V);
}, 1, "", true);
partyBox_82 = Fn((V _arrowThis1452, int _argc1445, V S_1451, V _a1448, V _a1449, V _a1450, V[] _rest1446) => {
return Call(spk_77, V.Undef, NewObj(4).Put("w", ((V)(96D))).Put("d", ((V)(62D))).Put("pivot", Arr(((V)(0D)), ((V)(50D)), ((V)(30D)))).Put("build", Fn((V _arrowThis1461, int _argc1453, V P_1459, V v_1460, V _a1457, V _a1458, V[] _rest1454) => {
V k_1462 = default;
V on_1463 = default;
V b_1464 = default;
V o_1465 = default;
k_1462 = Get(S_1451, "k");
on_1463 = (SEqS(v_1460, "on") ? V.True : V.False);
b_1464 = Call(SPB_75, V.Undef, k_1462, P_1459);
o_1465 = new ArrBuilder().Add(Call(ball_13, V.Undef, ((V)((-34D))), ((V)(0D)), ((V)(0D)), ((V)(9D)), DK_29, NewObj(1).Put("sy", ((V)(0.9))).V)).Add(Call(ball_13, V.Undef, ((V)(34D)), ((V)(0D)), ((V)(0D)), ((V)(9D)), DK_29, NewObj(1).Put("sy", ((V)(0.9))).V)).Add(Call(slab_14, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(92D)), ((V)(86D)), ((V)(56D)), b_1464, NewObj(1).Put("r", ((V)(22D))).V)).Add(Call(disc_17, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(28D)), ((V)(32D)), ((V)(1D)), (Truthy(on_1463) ? GetIdx(NE_24, 5D) : Call(shade_21, V.Undef, b_1464, ((V)(0.8)))), NewObj(2).Put("emit", ((V)((Truthy(on_1463) ? 1D : 0D)))).Put("part", ((V)(1D))).V)).Spread(Call(cone_48, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(29.2)), ((V)(26D)), ((V)("#30333a")), Call(RING_76, V.Undef, k_1462), on_1463)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(94D)), ((V)(0D)), ((V)(54D)), ((V)(6D)), ((V)(10D)), DK_29, NewObj(1).Put("r", ((V)(3D))).V)).Add(Call(box_11, V.Undef, ((V)((-26D))), ((V)(86D)), ((V)(0D)), ((V)(4D)), ((V)(12D)), ((V)(6D)), DK_29)).Add(Call(box_11, V.Undef, ((V)(26D)), ((V)(86D)), ((V)(0D)), ((V)(4D)), ((V)(12D)), ((V)(6D)), DK_29)).V;
if (SEqS(k_1462, "candy")) {
InvokeSpread(o_1465, "push", new ArrBuilder().Spread(Call(spr_44, V.Undef, ((V)(0D)), ((V)(94D)), ((V)(0D)), ((V)(70D)), ((V)(30D)), ((V)(6D)))).V);
}
return o_1465;
return default;
}, 2, "build", true)).V);
}, 1, "", true);
tableLamp_83 = Fn((V _arrowThis1473, int _argc1466, V S_1472, V _a1469, V _a1470, V _a1471, V[] _rest1467) => {
return NewObj(6).Put("w", ((V)(34D))).Put("d", ((V)(34D))).Put("small", ((V)(1D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis1480, int _argc1474, V _a1476, V _a1477, V _a1478, V _a1479, V[] _rest1475) => {
return NewObj(2).Put("y", ((V)(52D))).Put("r", ((V)(54D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1488, int _argc1481, V P_1487, V _a1484, V _a1485, V _a1486, V[] _rest1482) => {
V k_1489 = default;
k_1489 = Get(S_1472, "k");
if (SEqS(k_1489, "junk")) {
return Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(9D)), ((V)(22D)), ((V)("#bfe0e4")), NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(18D)), ((V)(0D)), ((V)(1D))), Arr(((V)(22D)), ((V)(0D)), ((V)(0.6))))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(1.4)), ((V)(18D)), ((V)("#8a8f94")), NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(0D)), ((V)(15D)), ((V)(18D)), ((V)("#e8dcc0")), NewObj(3).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(18D)), ((V)(0D)), ((V)(0.6))))).Put("emit", ((V)(1D))).V));
}
if (SEqS(k_1489, "cot")) {
return Arr(Call(ball_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(11D)), Get(P_1487, "a"), NewObj(1).Put("sy", ((V)(1.1))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(1.6)), ((V)(12D)), Get(P_1487, "wD"), NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(17D)), ((V)(20D)), ((V)("#fff6dc")), NewObj(3).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(20D)), ((V)(0D)), ((V)(0.62))))).Put("emit", ((V)(1D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(17.4)), ((V)(2.4)), Get(P_1487, "b"), NewObj(1).Put("n", ((V)(14D))).V));
}
if (SEqS(k_1489, "retro")) {
return Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(3D)), CH_26, NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(2D)), ((V)(26D)), CH_26, NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(16D)), ((V)(18D)), ((V)("#ffd23f")), NewObj(3).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.5))), Arr(((V)(18D)), ((V)(0D)), ((V)(1D))))).Put("emit", ((V)(1D))).V), Call(ball_13, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(3D)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}
if (SEqS(k_1489, "mod")) {
return Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(9D)), ((V)(14D)), DK_29, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(14D)), ((V)(0D)), ((V)(0.5))))).V), Call(ball_13, V.Undef, ((V)(0D)), ((V)(13D)), ((V)(0D)), ((V)(13D)), ((V)("#fff6dc")), NewObj(1).Put("emit", ((V)(1D))).V));
}
if (SEqS(k_1489, "candy")) {
return new ArrBuilder().Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(14D)), Get(P_1487, "a"), NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(ball_13, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(13D)), ((V)("#fff6dc")), NewObj(2).Put("sy", ((V)(0.8))).Put("emit", ((V)(1D))).V)).Add(Call(ball_13, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(4D)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).Spread(Call(spr_44, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(14D)), ((V)(14D)), ((V)(4D)))).V;
}
return new ArrBuilder().Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(4D)), GOLD_25, NewObj(1).Put("n", ((V)(12D))).V)).Spread(Invoke(Arr(((V)(8D)), ((V)(14D)), ((V)(20D))), "map", Fn((V _arrowThis1497, int _argc1490, V y_1496, V _a1493, V _a1494, V _a1495, V[] _rest1491) => {
return Call(ball_13, V.Undef, ((V)(0D)), y_1496, ((V)(0D)), ((V)(5D)), ((V)("#dff2fb")), NewObj(3).Put("emit", ((V)(1D))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V);
}, 1, "", true))).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(0D)), ((V)(1.6)), ((V)(8D)), GOLD_25, NewObj(1).Put("n", ((V)(6D))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)(16D)), ((V)(18D)), ((V)("#7a1e2c")), NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(18D)), ((V)(0D)), ((V)(0.6))))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)(16.4)), ((V)(2D)), GOLD_25, NewObj(1).Put("n", ((V)(14D))).V)).V;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
sconce_84 = Fn((V _arrowThis1505, int _argc1498, V S_1504, V _a1501, V _a1502, V _a1503, V[] _rest1499) => {
return NewObj(6).Put("w", ((V)(40D))).Put("d", ((V)(12D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(62D))).Put("glow", Fn((V _arrowThis1512, int _argc1506, V _a1508, V _a1509, V _a1510, V _a1511, V[] _rest1507) => {
return NewObj(2).Put("y", ((V)(22D))).Put("r", ((V)(50D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1520, int _argc1513, V P_1519, V _a1516, V _a1517, V _a1518, V[] _rest1514) => {
V k_1521 = default;
V mt_1522 = default;
k_1521 = Get(S_1504, "k");
mt_1522 = GetK(MT_37, k_1521);
if (SEqS(k_1521, "mod")) {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(90D)), ((V)(8D)), ((V)(6D)), DK_29, NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(3.4)), ((V)(86D)), ((V)(4D)), ((V)(1D)), ((V)("#fff6dc")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V));
}
return new ArrBuilder().Add(Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1D))), ((V)(14D)), ((V)(26D)), ((V)(3D)), mt_1522, NewObj(1).Put("r", ((V)(6D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(4D)), ((V)(3D)), ((V)(3D)), ((V)(12D)), mt_1522)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(10D)), ((V)(9D)), ((V)(14D)), (SEqS(k_1521, "candy") ? Get(P_1519, "a") : ((V)((SEqS(k_1521, "cot") ? "#fff6dc" : "#fff1c8")))), NewObj(3).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))))).Put("emit", ((V)(1D))).V)).Spread((SEqS(k_1521, "royal") ? Arr(Call(jewel_43, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(10D)), ((V)(3D)))) : Arr())).V;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
lantern_85 = Fn((V _arrowThis1530, int _argc1523, V S_1529, V _a1526, V _a1527, V _a1528, V[] _rest1524) => {
return NewObj(5).Put("w", ((V)(44D))).Put("d", ((V)(44D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis1537, int _argc1531, V _a1533, V _a1534, V _a1535, V _a1536, V[] _rest1532) => {
return NewObj(2).Put("y", ((V)(120D))).Put("r", ((V)(80D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1545, int _argc1538, V P_1544, V _a1541, V _a1542, V _a1543, V[] _rest1539) => {
V k_1546 = default;
V mt_1547 = default;
k_1546 = Get(S_1529, "k");
mt_1547 = GetK(MT_37, k_1546);
if (SEqS(k_1546, "retro")) {
return new ArrBuilder().Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(4D)), CH_26, NewObj(1).Put("n", ((V)(12D))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(1.8)), ((V)(112D)), CH_26, NewObj(1).Put("n", ((V)(6D))).V)).Spread(Invoke(Arr(Arr(((V)((-14D))), ((V)(108D))), Arr(((V)(12D)), ((V)(124D))), Arr(((V)(0D)), ((V)(140D)))), "map", Fn((V _arrowThis1560, int _argc1548, V _a1550, V i_1554, V _a1552, V _a1553, V[] _rest1549) => {
V x_1557 = default;
V y_1559 = default;
{ V _t1555 = ListOf(_a1550);
{ V _t1556 = GetIdx(_t1555, 0D);
x_1557 = _t1556; }
{ V _t1558 = GetIdx(_t1555, 1D);
y_1559 = _t1558; }
}
return Call(ball_13, V.Undef, x_1557, y_1559, ((V)(0D)), ((V)(8D)), GetK(Arr(((V)("#ffd23f")), ((V)("#5cc8f0")), ((V)("#e2554a"))), i_1554), NewObj(1).Put("emit", ((V)(1D))).V);
}, 2, "", true))).Add(Call(cyl_12, V.Undef, ((V)((-6D))), ((V)(104D)), ((V)(0D)), ((V)(1D)), ((V)(10D)), CH_26, NewObj(1).Put("n", ((V)(4D))).V)).Add(Call(cyl_12, V.Undef, ((V)(6D)), ((V)(118D)), ((V)(0D)), ((V)(1D)), ((V)(10D)), CH_26, NewObj(1).Put("n", ((V)(4D))).V)).V;
}
return Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(4D)), mt_1547, NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(2D)), ((V)(104D)), (SEqS(k_1546, "cot") ? Get(P_1544, "wD") : mt_1547), NewObj(1).Put("n", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(108D)), ((V)(0D)), ((V)(22D)), ((V)(26D)), ((V)(22D)), ((V)("#fff2b8")), NewObj(2).Put("r", ((V)(3D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(106D)), ((V)(0D)), ((V)(26D)), ((V)(3D)), ((V)(26D)), mt_1547, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(134D)), ((V)(0D)), ((V)(26D)), ((V)(3D)), ((V)(26D)), mt_1547, NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(137D)), ((V)(0D)), ((V)(8D)), ((V)(6D)), mt_1547, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.3))))).V));
return default;
}, 1, "build", true)).V;
}, 1, "", true);
neonSign_86 = Fn((V _arrowThis1568, int _argc1561, V S_1567, V _a1564, V _a1565, V _a1566, V[] _rest1562) => {
return NewObj(6).Put("w", ((V)(110D))).Put("d", ((V)(10D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(50D))).Put("glow", Fn((V _arrowThis1575, int _argc1569, V _a1571, V _a1572, V _a1573, V _a1574, V[] _rest1570) => {
return NewObj(3).Put("y", ((V)(30D))).Put("r", ((V)(70D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1583, int _argc1576, V P_1582, V _a1579, V _a1580, V _a1581, V[] _rest1577) => {
V k_1584 = default;
V o_1585 = default;
V c_1586 = default;
V st_1587 = default;
k_1584 = Get(S_1567, "k");
o_1585 = Arr(Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1D))), ((V)(104D)), ((V)(62D)), ((V)(3D)), (SEqS(k_1584, "candy") ? ((V)("#3b2e5a")) : INK_33), NewObj(1).Put("r", ((V)(8D))).V));
c_1586 = ((V)((SEqS(k_1584, "candy") ? "#ffd23f" : "#4fe0d0")));
if (SEqS(k_1584, "candy")) {
{
double i_1588 = 0;
i_1588 = 0D;
while (true) {
if (!((i_1588 < 16D))) break;
double t_1590 = 0;
t_1590 = (((i_1588 / 16D) * System.Math.PI) * 2D);
Invoke(o_1585, "push", Call(ball_13, V.Undef, ((V)(((-14D) + (16D * FdLibm.Cos(t_1590))))), ((V)(((34D + (16D * FdLibm.Sin(t_1590))) - 3D))), ((V)(2D)), ((V)(2.6)), GetIdx(NE_24, (i_1588 % 6D)), NewObj(3).Put("emit", ((V)(1D))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
i_1588++;
}
}
{
double i_1591 = 0;
i_1591 = 0D;
while (true) {
if (!((i_1591 < 5D))) break;
Invoke(o_1585, "push", Call(ball_13, V.Undef, ((V)((-14D))), ((V)((6D + (i_1591 * 3D)))), ((V)(2D)), ((V)(2D)), WH_28, NewObj(3).Put("emit", ((V)(1D))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
i_1591++;
}
}
InvokeSpread(o_1585, "push", new ArrBuilder().Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis1600, int _argc1593, V i_1599, V _a1596, V _a1597, V _a1598, V[] _rest1594) => {
return Call(ball_13, V.Undef, ((V)((18D + (ToNum(i_1599) * 10D)))), ((V)(30D)), ((V)(2D)), ((V)(3D)), ((V)("#4fe0d0")), NewObj(3).Put("emit", ((V)(1D))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 1, "", true))).V);
return o_1585;
}
st_1587 = Call(starP_40, V.Undef, ((V)(5D)), ((V)(22D)), ((V)(9D)));
{
double i_1601 = 0;
i_1601 = 0D;
while (true) {
if (!((i_1601 < 10D))) break;
V a_1603 = default;
V b_1604 = default;
a_1603 = GetIdx(st_1587, i_1601);
b_1604 = GetIdx(st_1587, ((i_1601 + 1D) % 10D));
{
double j_1605 = 0;
j_1605 = 0D;
while (true) {
if (!((j_1605 < 3D))) break;
double u_1607 = 0;
u_1607 = (j_1605 / 3D);
Invoke(o_1585, "push", Call(ball_13, V.Undef, Add(Add(((V)((-24D))), GetIdx(a_1603, 0D)), ((V)(((ToNum(GetIdx(b_1604, 0D)) - ToNum(GetIdx(a_1603, 0D))) * u_1607)))), ((V)(((31D - ToNum(Add(GetIdx(a_1603, 1D), ((V)(((ToNum(GetIdx(b_1604, 1D)) - ToNum(GetIdx(a_1603, 1D))) * u_1607)))))) - 2.5))), ((V)(2D)), ((V)(2.2)), c_1586, NewObj(3).Put("emit", ((V)(1D))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
j_1605++;
}
}
i_1601++;
}
}
{
double i_1608 = 0;
i_1608 = 0D;
while (true) {
if (!((i_1608 < 6D))) break;
Invoke(o_1585, "push", Call(ball_13, V.Undef, ((V)((14D + (i_1608 * 6D)))), ((V)((26D + (FdLibm.Sin((i_1608 * 1.4)) * 8D)))), ((V)(2D)), ((V)(2.2)), ((V)("#ffa940")), NewObj(3).Put("emit", ((V)(1D))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
i_1608++;
}
}
return o_1585;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
mushLamp_87 = Fn((V _arrowThis1617, int _argc1610, V S_1616, V _a1613, V _a1614, V _a1615, V[] _rest1611) => {
return NewObj(5).Put("w", ((V)(56D))).Put("d", ((V)(56D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis1624, int _argc1618, V _a1620, V _a1621, V _a1622, V _a1623, V[] _rest1619) => {
return NewObj(2).Put("y", ((V)(40D))).Put("r", ((V)(70D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1632, int _argc1625, V P_1631, V _a1628, V _a1629, V _a1630, V[] _rest1626) => {
return new ArrBuilder().Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(40D)), CR_27, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.3))), Arr(((V)(20D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(40D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(ball_13, V.Undef, ((V)(0D)), ((V)(32D)), ((V)(0D)), ((V)(30D)), ((V)("#fff6dc")), NewObj(2).Put("sy", ((V)(0.18))).Put("emit", ((V)(1D))).V)).Add(Call(ball_13, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)(30D)), Get(P_1631, "a"), NewObj(1).Put("sy", ((V)(0.62))).V)).Spread(Invoke(Arr(Arr(((V)((-14D))), ((V)(44D)), ((V)(18D))), Arr(((V)(12D)), ((V)(50D)), ((V)(16D))), Arr(((V)(0D)), ((V)(56D)), ((V)(4D))), Arr(((V)(22D)), ((V)(40D)), ((V)(10D)))), "map", Fn((V _arrowThis1646, int _argc1633, V _a1635, V _a1636, V _a1637, V _a1638, V[] _rest1634) => {
V x_1641 = default;
V y_1643 = default;
V z_1645 = default;
{ V _t1639 = ListOf(_a1635);
{ V _t1640 = GetIdx(_t1639, 0D);
x_1641 = _t1640; }
{ V _t1642 = GetIdx(_t1639, 1D);
y_1643 = _t1642; }
{ V _t1644 = GetIdx(_t1639, 2D);
z_1645 = _t1644; }
}
return Call(ball_13, V.Undef, x_1641, y_1643, z_1645, ((V)(4D)), WH_28, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 1, "", true))).V;
}, 1, "build", true)).V;
}, 1, "", true);
leafB_88 = Fn((V _arrowThis1659, int _argc1647, V x_1653, V y_1654, V z_1655, V s_1656, V[] _rest1648) => {
V yaw_1657 = default;
V col_1658 = default;
yaw_1657 = (_argc1647 > 4 ? _rest1648[0] : V.Undef);
col_1658 = (_argc1647 > 5 ? _rest1648[1] : V.Undef);
return Call(ball_13, V.Undef, x_1653, y_1654, z_1655, ((V)((12D * ToNum(s_1656)))), col_1658, NewObj(6).Put("sx", ((V)(1.8))).Put("sy", ((V)(0.18))).Put("sz", ((V)(0.9))).Put("yaw", yaw_1657).Put("k", ((V)(3D))).Put("n", ((V)(12D))).V);
}, 6, "", true);
cactus_89 = Fn((V _arrowThis1667, int _argc1660, V S_1666, V _a1663, V _a1664, V _a1665, V[] _rest1661) => {
return NewObj(4).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis1675, int _argc1668, V P_1674, V _a1671, V _a1672, V _a1673, V[] _rest1669) => {
return new ArrBuilder().Spread(Call(pot_47, V.Undef, Get(S_1666, "k"), P_1674, ((V)(14D)), ((V)(18D)))).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)), ((V)(9D)), ((V)(50D)), ((V)("#5fa556")), NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(44D)), ((V)(0D)), ((V)(1D))), Arr(((V)(50D)), ((V)(0D)), ((V)(0.5))))).V)).Add(Call(cyl_12, V.Undef, ((V)((-12D))), ((V)(34D)), ((V)(0D)), ((V)(4D)), ((V)(14D)), ((V)("#5fa556")), NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(12D)), ((V)(0D)), ((V)(1D))), Arr(((V)(14D)), ((V)(0D)), ((V)(0.4))))).V)).Add(Call(box_11, V.Undef, ((V)((-8D))), ((V)(34D)), ((V)(0D)), ((V)(8D)), ((V)(6D)), ((V)(6D)), ((V)("#5fa556")), NewObj(1).Put("r", ((V)(3D))).V)).Add(Call(cyl_12, V.Undef, ((V)(11D)), ((V)(42D)), ((V)(0D)), ((V)(4D)), ((V)(12D)), ((V)("#5fa556")), NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(10D)), ((V)(0D)), ((V)(1D))), Arr(((V)(12D)), ((V)(0D)), ((V)(0.4))))).V)).Add(Call(box_11, V.Undef, ((V)(8D)), ((V)(40D)), ((V)(0D)), ((V)(7D)), ((V)(5D)), ((V)(6D)), ((V)("#5fa556")), NewObj(1).Put("r", ((V)(3D))).V)).Add(Call(ball_13, V.Undef, ((V)(0D)), ((V)(64D)), ((V)(0D)), ((V)(4.5)), ((V)((SEqS(Get(S_1666, "k"), "retro") ? "#ffd23f" : "#ffa940"))), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).V;
}, 1, "build", true)).V;
}, 1, "", true);
monstera_90 = Fn((V _arrowThis1683, int _argc1676, V S_1682, V _a1679, V _a1680, V _a1681, V[] _rest1677) => {
return NewObj(4).Put("w", ((V)(70D))).Put("d", ((V)(70D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis1691, int _argc1684, V P_1690, V _a1687, V _a1688, V _a1689, V[] _rest1685) => {
V o_1692 = default;
o_1692 = new ArrBuilder().Spread(Call(pot_47, V.Undef, Get(S_1682, "k"), P_1690, ((V)(22D)), ((V)(30D)))).V;
Invoke(Arr(Arr(((V)(0D)), ((V)(60D)), ((V)(0D)), ((V)(1.3)), ((V)(0D))), Arr(((V)((-24D))), ((V)(52D)), ((V)(8D)), ((V)(1.1)), ((V)(0.6))), Arr(((V)(24D)), ((V)(54D)), ((V)(6D)), ((V)(1.1)), ((V)((-0.6)))), Arr(((V)((-14D))), ((V)(76D)), ((V)((-8D))), ((V)(1D)), ((V)(1.2))), Arr(((V)(16D)), ((V)(80D)), ((V)((-6D))), ((V)(1.05)), ((V)((-1.1)))), Arr(((V)(0D)), ((V)(92D)), ((V)(4D)), ((V)(0.9)), ((V)(0.2))), Arr(((V)((-30D))), ((V)(70D)), ((V)((-4D))), ((V)(0.85)), ((V)(2D)))), "forEach", Fn((V _arrowThis1711, int _argc1693, V _a1695, V i_1699, V _a1697, V _a1698, V[] _rest1694) => {
V x_1702 = default;
V y_1704 = default;
V z_1706 = default;
V s_1708 = default;
V a_1710 = default;
{ V _t1700 = ListOf(_a1695);
{ V _t1701 = GetIdx(_t1700, 0D);
x_1702 = _t1701; }
{ V _t1703 = GetIdx(_t1700, 1D);
y_1704 = _t1703; }
{ V _t1705 = GetIdx(_t1700, 2D);
z_1706 = _t1705; }
{ V _t1707 = GetIdx(_t1700, 3D);
s_1708 = _t1707; }
{ V _t1709 = GetIdx(_t1700, 4D);
a_1710 = _t1709; }
}
return Invoke(o_1692, "push", Call(cyl_12, V.Undef, ((V)((ToNum(x_1702) * 0.4))), ((V)(28D)), ((V)((ToNum(z_1706) * 0.4))), ((V)(1.4)), ((V)((ToNum(y_1704) - 28D))), ((V)("#4a8a46")), NewObj(1).Put("n", ((V)(5D))).V), Call(leafB_88, V.Undef, x_1702, y_1704, z_1706, s_1708, a_1710, (NumTruthy((ToNum(i_1699) % 2D)) ? LEAF_34 : LEAF2_35)));
}, 2, "", true));
return o_1692;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
sunflower_91 = Fn((V _arrowThis1719, int _argc1712, V S_1718, V _a1715, V _a1716, V _a1717, V[] _rest1713) => {
return NewObj(4).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis1727, int _argc1720, V P_1726, V _a1723, V _a1724, V _a1725, V[] _rest1721) => {
return new ArrBuilder().Spread(Call(pot_47, V.Undef, Get(S_1718, "k"), P_1726, ((V)(13D)), ((V)(18D)))).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(0D)), ((V)(1.8)), ((V)(76D)), ((V)("#4a8a46")), NewObj(1).Put("n", ((V)(6D))).V)).Add(Call(leafB_88, V.Undef, ((V)((-10D))), ((V)(46D)), ((V)(4D)), ((V)(0.7)), ((V)(0.4)), LEAF_34)).Add(Call(leafB_88, V.Undef, ((V)(10D)), ((V)(62D)), ((V)(2D)), ((V)(0.7)), ((V)((-0.4))), LEAF2_35)).Add(Call(disc_17, V.Undef, ((V)(0D)), ((V)(100D)), ((V)(4D)), ((V)(18D)), ((V)(2D)), ((V)("#ffd23f")), NewObj(1).Put("top", ((V)(1D))).V)).Add(Call(disc_17, V.Undef, ((V)(0D)), ((V)(100D)), ((V)(6D)), ((V)(9D)), ((V)(2D)), ((V)("#8a5a34")), NewObj(1).Put("top", ((V)(1D))).V)).Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis1735, int _argc1728, V i_1734, V _a1731, V _a1732, V _a1733, V[] _rest1729) => {
return Call(disc_17, V.Undef, ((V)(((-3D) + (ToNum(i_1734) * 3D)))), ((V)((102D - ((ToNum(i_1734) % 2D) * 3D)))), ((V)(8.2)), ((V)(1D)), ((V)(0.4)), ((V)("#5b3b22")));
}, 1, "", true))).V;
}, 1, "build", true)).V;
}, 1, "", true);
bonsai_92 = Fn((V _arrowThis1743, int _argc1736, V S_1742, V _a1739, V _a1740, V _a1741, V[] _rest1737) => {
return NewObj(4).Put("w", ((V)(46D))).Put("d", ((V)(30D))).Put("small", ((V)(1D))).Put("build", Fn((V _arrowThis1751, int _argc1744, V P_1750, V _a1747, V _a1748, V _a1749, V[] _rest1745) => {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)(8D)), ((V)(28D)), ((V)((SEqS(Get(S_1742, "k"), "royal") ? "#f4f1ea" : "#6a8ab0"))), NewObj(1).Put("r", ((V)(4D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(3D)), ((V)(20D)), ((V)("#8a5a34")), NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.4))), Arr(((V)(20D)), ((V)(0D)), ((V)(0.8))))).V), Call(ball_13, V.Undef, ((V)((-10D))), ((V)(24D)), ((V)(0D)), ((V)(10D)), LEAF_34, NewObj(1).Put("sy", ((V)(0.6))).V), Call(ball_13, V.Undef, ((V)(10D)), ((V)(30D)), ((V)(2D)), ((V)(9D)), LEAF2_35, NewObj(1).Put("sy", ((V)(0.6))).V), Call(ball_13, V.Undef, ((V)(0D)), ((V)(34D)), ((V)((-2D))), ((V)(8D)), LEAF_34, NewObj(1).Put("sy", ((V)(0.6))).V));
}, 1, "build", true)).V;
}, 1, "", true);
flowerPot_93 = Fn((V _arrowThis1759, int _argc1752, V S_1758, V _a1755, V _a1756, V _a1757, V[] _rest1753) => {
return NewObj(4).Put("w", ((V)(46D))).Put("d", ((V)(46D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis1767, int _argc1760, V P_1766, V _a1763, V _a1764, V _a1765, V[] _rest1761) => {
V k_1768 = default;
V o_1769 = default;
k_1768 = Get(S_1758, "k");
o_1769 = new ArrBuilder().Spread(Call(pot_47, V.Undef, k_1768, P_1766, ((V)(16D)), ((V)(22D)))).V;
Invoke(Arr(Arr(((V)((-8D))), ((V)(50D)), ((V)(2D))), Arr(((V)(8D)), ((V)(54D)), ((V)((-2D)))), Arr(((V)(0D)), ((V)(62D)), ((V)(4D))), Arr(((V)((-14D))), ((V)(42D)), ((V)((-4D)))), Arr(((V)(14D)), ((V)(44D)), ((V)(4D)))), "forEach", Fn((V _arrowThis1784, int _argc1770, V _a1772, V i_1776, V _a1774, V _a1775, V[] _rest1771) => {
V x_1779 = default;
V y_1781 = default;
V z_1783 = default;
{ V _t1777 = ListOf(_a1772);
{ V _t1778 = GetIdx(_t1777, 0D);
x_1779 = _t1778; }
{ V _t1780 = GetIdx(_t1777, 1D);
y_1781 = _t1780; }
{ V _t1782 = GetIdx(_t1777, 2D);
z_1783 = _t1782; }
}
Invoke(o_1769, "push", Call(cyl_12, V.Undef, ((V)((ToNum(x_1779) * 0.5))), ((V)(20D)), ((V)((ToNum(z_1783) * 0.5))), ((V)(1.2)), ((V)((ToNum(y_1781) - 20D))), ((V)("#4a8a46")), NewObj(1).Put("n", ((V)(5D))).V));
if (SEqS(k_1768, "candy")) {
Invoke(o_1769, "push", Call(disc_17, V.Undef, x_1779, y_1781, z_1783, ((V)(8D)), ((V)(2.4)), GetK(NE_24, i_1776), NewObj(1).Put("top", ((V)(1D))).V), Call(disc_17, V.Undef, x_1779, y_1781, Add(z_1783, ((V)(2.6))), ((V)(4D)), ((V)(0.6)), WH_28));
} else {
InvokeSpread(o_1769, "push", new ArrBuilder().Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D))), "map", Fn((V _arrowThis1792, int _argc1785, V j_1791, V _a1788, V _a1789, V _a1790, V[] _rest1786) => {
return Call(ball_13, V.Undef, Add(x_1779, ((V)((4.5 * FdLibm.Cos((ToNum(j_1791) * 1.26)))))), ((V)((ToNum(y_1781) - 3D))), Add(z_1783, ((V)((4.5 * FdLibm.Sin((ToNum(j_1791) * 1.26)))))), ((V)(3.6)), (SEqS(k_1768, "royal") ? GetIdx(Arr(((V)("#f4f1ea")), ((V)("#7a1e2c"))), (ToNum(i_1776) % 2D)) : GetIdx(RB6_36, (ToNum(Add(i_1776, ((V)(1D)))) % 6D))), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 1, "", true))).Add(Call(ball_13, V.Undef, x_1779, ((V)((ToNum(y_1781) - 2D))), z_1783, ((V)(2.6)), ((V)("#ffd23f")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).V);
}
return default;
}, 2, "", true));
Invoke(o_1769, "push", Call(leafB_88, V.Undef, ((V)((-10D))), ((V)(26D)), ((V)(6D)), ((V)(0.6)), ((V)(0.6)), LEAF_34), Call(leafB_88, V.Undef, ((V)(10D)), ((V)(26D)), ((V)((-4D))), ((V)(0.6)), ((V)((-0.6))), LEAF2_35));
return o_1769;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
pottedPalm_94 = Fn((V _arrowThis1800, int _argc1793, V S_1799, V _a1796, V _a1797, V _a1798, V[] _rest1794) => {
return NewObj(4).Put("w", ((V)(70D))).Put("d", ((V)(70D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis1808, int _argc1801, V P_1807, V _a1804, V _a1805, V _a1806, V[] _rest1802) => {
V o_1809 = default;
o_1809 = new ArrBuilder().Spread(Call(pot_47, V.Undef, Get(S_1799, "k"), P_1807, ((V)(22D)), ((V)(28D)))).V;
{
double i_1810 = 0;
i_1810 = 0D;
while (true) {
if (!((i_1810 < 5D))) break;
Invoke(o_1809, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)((28D + (i_1810 * 16D)))), ((V)(0D)), ((V)((6D - (i_1810 * 0.4)))), ((V)(16D)), ((V)((NumTruthy((i_1810 % 2D)) ? "#a8804a" : "#b8925a"))), NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.15))), Arr(((V)(16D)), ((V)(0D)), ((V)(0.9))))).V));
i_1810++;
}
}
{
double i_1812 = 0;
i_1812 = 0D;
while (true) {
if (!((i_1812 < 7D))) break;
double a_1814 = 0;
a_1814 = (((i_1812 / 7D) * System.Math.PI) * 2D);
Invoke(o_1809, "push", Call(ball_13, V.Undef, ((V)((30D * FdLibm.Cos(a_1814)))), ((V)((98D - ((i_1812 % 2D) * 8D)))), ((V)((20D * FdLibm.Sin(a_1814)))), ((V)(16D)), (NumTruthy((i_1812 % 2D)) ? LEAF_34 : LEAF2_35), NewObj(6).Put("sx", ((V)(2D))).Put("sy", ((V)(0.16))).Put("sz", ((V)(0.6))).Put("yaw", ((V)((-a_1814)))).Put("k", ((V)(3D))).Put("n", ((V)(12D))).V));
i_1812++;
}
}
Invoke(o_1809, "push", Call(ball_13, V.Undef, ((V)(0D)), ((V)(104D)), ((V)(0D)), ((V)(7D)), LEAF2_35));
return o_1809;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
succulent_95 = Fn((V _arrowThis1822, int _argc1815, V S_1821, V _a1818, V _a1819, V _a1820, V[] _rest1816) => {
return NewObj(5).Put("w", ((V)(30D))).Put("d", ((V)(30D))).Put("small", ((V)(1D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis1830, int _argc1823, V P_1829, V _a1826, V _a1827, V _a1828, V[] _rest1824) => {
return new ArrBuilder().Spread(Call(pot_47, V.Undef, Get(S_1821, "k"), P_1829, ((V)(10D)), ((V)(12D)))).Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D)), ((V)(5D)), ((V)(6D))), "map", Fn((V _arrowThis1838, int _argc1831, V i_1837, V _a1834, V _a1835, V _a1836, V[] _rest1832) => {
return Call(ball_13, V.Undef, ((V)((6D * FdLibm.Cos((ToNum(i_1837) * 0.9))))), ((V)((12D + ((ToNum(i_1837) % 2D) * 2D)))), ((V)((6D * FdLibm.Sin((ToNum(i_1837) * 0.9))))), ((V)(4.5)), ((V)((NumTruthy((ToNum(i_1837) % 2D)) ? "#8fc9a0" : "#a8d8b0"))), NewObj(3).Put("sy", ((V)(0.9))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V);
}, 1, "", true))).Add(Call(ball_13, V.Undef, ((V)(0D)), ((V)(15D)), ((V)(0D)), ((V)(4D)), ((V)("#c8e8c0")), NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)).V;
}, 1, "build", true)).V;
}, 1, "", true);
tankSmall_96 = Fn((V _arrowThis1846, int _argc1839, V S_1845, V _a1842, V _a1843, V _a1844, V[] _rest1840) => {
return NewObj(6).Put("w", ((V)(46D))).Put("d", ((V)(40D))).Put("small", ((V)(1D))).Put("round", ((V)(1D))).Put("anim", ((V)("fish"))).Put("build", Fn((V _arrowThis1854, int _argc1847, V P_1853, V _a1850, V _a1851, V _a1852, V[] _rest1848) => {
return new ArrBuilder().Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(12D)), ((V)(4D)), (SEqS(Get(S_1845, "k"), "royal") ? GOLD_25 : ((V)("#d8d4cc"))), NewObj(1).Put("n", ((V)(12D))).V)).Add(Call(ball_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(20D)), ((V)("#bfe8f6")), NewObj(2).Put("sy", ((V)(0.92))).Put("emit", ((V)(1D))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(0D)), ((V)(13D)), ((V)(4D)), ((V)("#e8cf8a")), NewObj(1).Put("n", ((V)(12D))).V)).Add(Call(ball_13, V.Undef, ((V)((-8D))), ((V)(8D)), ((V)(4D)), ((V)(4D)), LEAF_34, NewObj(3).Put("sy", ((V)(2.2))).Put("k", ((V)(4D))).Put("n", ((V)(8D))).V)).Spread(Call(fish_49, V.Undef, ((V)(2D)), ((V)(18D)), ((V)(10D)), ((V)(1D)), (SEqS(Get(S_1845, "k"), "candy") ? GetIdx(NE_24, 1D) : ((V)("#ffa940"))))).V;
}, 1, "build", true)).V;
}, 1, "", true);
aquaBig_97 = Fn((V _arrowThis1862, int _argc1855, V S_1861, V _a1858, V _a1859, V _a1860, V[] _rest1856) => {
return NewObj(4).Put("w", ((V)(150D))).Put("d", ((V)(56D))).Put("anim", ((V)("fish"))).Put("build", Fn((V _arrowThis1870, int _argc1863, V P_1869, V _a1866, V _a1867, V _a1868, V[] _rest1864) => {
V k_1871 = default;
V c_1872 = default;
V o_1873 = default;
k_1871 = Get(S_1861, "k");
c_1872 = Call(FR_38, V.Undef, k_1871, P_1869);
o_1873 = Arr();
Invoke(o_1873, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(146D)), ((V)(44D)), ((V)(52D)), c_1872, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)((-36D))), ((V)(6D)), ((V)(26.4)), ((V)(64D)), ((V)(32D)), ((V)(1D)), Call(shade_21, V.Undef, c_1872, ((V)(0.9))), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(36D)), ((V)(6D)), ((V)(26.4)), ((V)(64D)), ((V)(32D)), ((V)(1D)), Call(shade_21, V.Undef, c_1872, ((V)(0.9))), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(0D)), ((V)(140D)), ((V)(66D)), ((V)(46D)), ((V)("#8fd8f2")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(0D)), ((V)(140D)), ((V)(8D)), ((V)(46D)), ((V)("#e8cf8a")), NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(110D)), ((V)(0D)), ((V)(146D)), ((V)(6D)), ((V)(52D)), (SEqS(k_1871, "royal") ? GOLD_25 : Call(shade_21, V.Undef, c_1872, ((V)(0.85)))), NewObj(1).Put("r", ((V)(3D))).V));
Invoke(Arr(Arr(((V)((-52D))), ((V)(4D))), Arr(((V)((-38D))), ((V)((-6D)))), Arr(((V)(44D)), ((V)(2D))), Arr(((V)(56D)), ((V)((-8D))))), "forEach", Fn((V _arrowThis1886, int _argc1874, V _a1876, V i_1880, V _a1878, V _a1879, V[] _rest1875) => {
V x_1883 = default;
V z_1885 = default;
{ V _t1881 = ListOf(_a1876);
{ V _t1882 = GetIdx(_t1881, 0D);
x_1883 = _t1882; }
{ V _t1884 = GetIdx(_t1881, 1D);
z_1885 = _t1884; }
}
return Invoke(o_1873, "push", Call(ball_13, V.Undef, x_1883, ((V)(52D)), z_1885, ((V)(6D)), (NumTruthy((ToNum(i_1880) % 2D)) ? LEAF_34 : LEAF2_35), NewObj(3).Put("sy", ((V)(3.2))).Put("k", ((V)(4D))).Put("n", ((V)(8D))).V));
}, 2, "", true));
Invoke(o_1873, "push", Call(ball_13, V.Undef, ((V)(10D)), ((V)(52D)), ((V)((-8D))), ((V)(8D)), ((V)("#c9a86a")), NewObj(1).Put("sy", ((V)(0.7))).V), Call(box_11, V.Undef, ((V)(18D)), ((V)(52D)), ((V)((-10D))), ((V)(14D)), ((V)(12D)), ((V)(8D)), ((V)("#b8925a")), NewObj(1).Put("r", ((V)(2D))).V));
InvokeSpread(o_1873, "push", new ArrBuilder().Spread(Call(fish_49, V.Undef, ((V)((-24D))), ((V)(78D)), ((V)(24D)), ((V)(1.2)), ((V)("#ffa940")))).Spread(Call(fish_49, V.Undef, ((V)(20D)), ((V)(66D)), ((V)(24D)), ((V)(1D)), ((V)("#5cc8f0")))).Spread(Call(fish_49, V.Undef, ((V)((-4D))), ((V)(92D)), ((V)(24D)), ((V)(0.9)), ((V)("#ffd23f")))).Spread(Call(fish_49, V.Undef, ((V)(34D)), ((V)(86D)), ((V)(24D)), ((V)(0.8)), (SEqS(k_1871, "royal") ? GOLD_25 : ((V)("#8f7bff"))))).V);
if (SEqS(k_1871, "royal")) {
Invoke(o_1873, "push", Call(jewel_43, V.Undef, ((V)(0D)), ((V)(116D)), ((V)(0D)), ((V)(6D))));
}
return o_1873;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
aquaCol_98 = Fn((V _arrowThis1894, int _argc1887, V S_1893, V _a1890, V _a1891, V _a1892, V[] _rest1888) => {
return NewObj(5).Put("w", ((V)(60D))).Put("d", ((V)(60D))).Put("round", ((V)(1D))).Put("anim", ((V)("fish"))).Put("build", Fn((V _arrowThis1902, int _argc1895, V P_1901, V _a1898, V _a1899, V _a1900, V[] _rest1896) => {
return new ArrBuilder().Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(26D)), ((V)(14D)), Get(P_1901, "b"), NewObj(1).Put("n", ((V)(16D))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(22D)), ((V)(104D)), ((V)("#9fdcf4")), NewObj(2).Put("n", ((V)(18D))).Put("emit", ((V)(1D))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(22D)), ((V)(8D)), ((V)("#fff1a0")), NewObj(1).Put("n", ((V)(18D))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(118D)), ((V)(0D)), ((V)(26D)), ((V)(10D)), Get(P_1901, "b"), NewObj(1).Put("n", ((V)(16D))).V)).Spread(Call(spr_44, V.Undef, ((V)(0D)), ((V)(128D)), ((V)(0D)), ((V)(30D)), ((V)(30D)), ((V)(6D)))).Spread(Call(fish_49, V.Undef, ((V)((-4D))), ((V)(50D)), ((V)(20D)), ((V)(1D)), GetIdx(NE_24, 0D))).Spread(Call(fish_49, V.Undef, ((V)(4D)), ((V)(80D)), ((V)(20D)), ((V)(0.9)), GetIdx(NE_24, 3D))).Spread(Call(fish_49, V.Undef, ((V)((-2D))), ((V)(100D)), ((V)(20D)), ((V)(0.8)), GetIdx(NE_24, 4D))).V;
}, 1, "build", true)).V;
}, 1, "", true);
pinball_99 = Fn((V _arrowThis1910, int _argc1903, V S_1909, V _a1906, V _a1907, V _a1908, V[] _rest1904) => {
return NewObj(5).Put("w", ((V)(76D))).Put("d", ((V)(128D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(80D))).V).Put("build", Fn((V _arrowThis1918, int _argc1911, V P_1917, V _a1914, V _a1915, V _a1916, V[] _rest1912) => {
V k_1919 = default;
V b_1920 = default;
V o_1921 = default;
k_1919 = Get(S_1909, "k");
b_1920 = Call(FR_38, V.Undef, k_1919, P_1917);
o_1921 = new ArrBuilder().Spread(Call(lg_42, V.Undef, k_1919, P_1917, ((V)(30D)), ((V)(52D)), ((V)(38D)), ((V)(3D)))).V;
Invoke(o_1921, "push", Call(prism_22, V.Undef, ((V)((-34D))), ((V)(34D)), Arr(Arr(((V)((-60D))), ((V)(38D))), Arr(((V)(60D)), ((V)(50D))), Arr(((V)(60D)), ((V)(58D))), Arr(((V)((-60D))), ((V)(46D)))), b_1920), Call(prism_22, V.Undef, ((V)((-30D))), ((V)(30D)), Arr(Arr(((V)((-56D))), ((V)(46.4))), Arr(((V)(56D)), ((V)(58.4))), Arr(((V)(56D)), ((V)(59.4))), Arr(((V)((-56D))), ((V)(47.4)))), (SEqS(k_1919, "candy") ? Get(P_1917, "a") : ((V)("#2b4a8a"))), NewObj(1).Put("emit", ((V)(1D))).V));
Invoke(Arr(Arr(((V)((-12D))), ((V)((-30D)))), Arr(((V)(12D)), ((V)((-24D)))), Arr(((V)(0D)), ((V)((-6D))))), "forEach", Fn((V _arrowThis1934, int _argc1922, V _a1924, V i_1928, V _a1926, V _a1927, V[] _rest1923) => {
V x_1931 = default;
V z_1933 = default;
{ V _t1929 = ListOf(_a1924);
{ V _t1930 = GetIdx(_t1929, 0D);
x_1931 = _t1930; }
{ V _t1932 = GetIdx(_t1929, 1D);
z_1933 = _t1932; }
}
return Invoke(o_1921, "push", Call(cyl_12, V.Undef, x_1931, ((V)(((52D + (ToNum(Add(z_1933, ((V)(60D)))) * 0.1)) - 5D))), z_1933, ((V)(6D)), ((V)(6D)), GetIdx(NE_24, (ToNum(i_1928) * 2D)), NewObj(2).Put("n", ((V)(10D))).Put("emit", ((V)(1D))).V));
}, 2, "", true));
Invoke(o_1921, "push", Call(ball_13, V.Undef, ((V)(6D)), ((V)(56D)), ((V)(24D)), ((V)(3D)), CH_26, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
Invoke(o_1921, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(50D)), ((V)((-62D))), ((V)(68D)), ((V)(60D)), ((V)(12D)), b_1920, NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(58D)), ((V)((-55.6))), ((V)(58D)), ((V)(44D)), ((V)(0.8)), ((V)((SEqS(k_1919, "royal") ? "#8f7bff" : "#ffa940"))), NewObj(2).Put("r", ((V)(3D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(70D)), ((V)((-55D))), ((V)(40D)), ((V)(10D)), ((V)(0.6)), ((V)("#fff1a8")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V));
if (SEqS(k_1919, "royal")) {
Invoke(o_1921, "push", Call(jewel_43, V.Undef, ((V)(0D)), ((V)(112D)), ((V)((-62D))), ((V)(5D))));
}
return o_1921;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
claw_100 = Fn((V _arrowThis1942, int _argc1935, V S_1941, V _a1938, V _a1939, V _a1940, V[] _rest1936) => {
return NewObj(5).Put("w", ((V)(84D))).Put("d", ((V)(84D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(64D))).V).Put("build", Fn((V _arrowThis1950, int _argc1943, V P_1949, V _a1946, V _a1947, V _a1948, V[] _rest1944) => {
V k_1951 = default;
V b_1952 = default;
V o_1953 = default;
k_1951 = Get(S_1941, "k");
b_1952 = (SEqS(k_1951, "candy") ? Get(P_1949, "a") : (SEqS(k_1951, "royal") ? ((V)("#f4f1ea")) : Get(P_1949, "a")));
o_1953 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(44D)), ((V)(80D)), b_1952, NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(0D)), ((V)(74D)), ((V)(74D)), ((V)(74D)), ((V)("#d8f3ff")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V));
{
double i_1954 = 0;
i_1954 = 0D;
while (true) {
if (!((i_1954 < 9D))) break;
Invoke(o_1953, "push", Call(ball_13, V.Undef, ((V)(((-24D) + ((i_1954 % 3D) * 22D)))), ((V)((44D + (((i_1954 * 7D) % 3D) * 4D)))), ((V)(((-18D) + (System.Math.Floor((i_1954 / 3D)) * 18D)))), ((V)(9D)), GetIdx(NE_24, (i_1954 % 6D)), NewObj(2).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V));
i_1954++;
}
}
Invoke(o_1953, "push", Call(cyl_12, V.Undef, ((V)(8D)), ((V)(82D)), ((V)(4D)), ((V)(0.8)), ((V)(32D)), CH_26, NewObj(1).Put("n", ((V)(4D))).V), Call(ball_13, V.Undef, ((V)(8D)), ((V)(78D)), ((V)(4D)), ((V)(4D)), CH_26, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(118D)), ((V)(0D)), ((V)(84D)), ((V)(18D)), ((V)(84D)), b_1952, NewObj(1).Put("r", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(122D)), ((V)(42.4)), ((V)(60D)), ((V)(10D)), ((V)(0.8)), ((V)("#fff1a8")), NewObj(2).Put("r", ((V)(3D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((-20D))), ((V)(30D)), ((V)(40.4)), ((V)(20D)), ((V)(8D)), ((V)(3D)), DK_29, NewObj(1).Put("r", ((V)(2D))).V), Call(ball_13, V.Undef, ((V)((-20D))), ((V)(38D)), ((V)(40D)), ((V)(3D)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(22D)), ((V)(22D)), ((V)(40.4)), ((V)(14D)), ((V)(14D)), ((V)(1D)), ((V)("#3b3b3b")), NewObj(1).Put("r", ((V)(2D))).V));
if (SEqS(k_1951, "candy")) {
InvokeSpread(o_1953, "push", new ArrBuilder().Spread(Call(drips_45, V.Undef, ((V)(0D)), ((V)(136D)), ((V)(42D)), ((V)(70D)), Get(P_1949, "b"), ((V)(6D)))).V);
}
return o_1953;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
racer_101 = Fn((V _arrowThis1963, int _argc1956, V S_1962, V _a1959, V _a1960, V _a1961, V[] _rest1957) => {
return NewObj(5).Put("w", ((V)(120D))).Put("d", ((V)(120D))).Put("act", ((V)("ride"))).Put("seats", Arr(NewObj(5).Put("x", ((V)(0D))).Put("z", ((V)(26D))).Put("h", ((V)(30D))).Put("k", ((V)("ride"))).Put("f", ((V)(180D))).V)).Put("build", Fn((V _arrowThis1971, int _argc1964, V P_1970, V _a1967, V _a1968, V _a1969, V[] _rest1965) => {
V k_1972 = default;
V b_1973 = default;
k_1972 = Get(S_1962, "k");
b_1973 = (SEqS(k_1972, "royal") ? ((V)("#f4f1ea")) : Get(P_1970, "a"));
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(116D)), ((V)(10D)), ((V)(100D)), DK_29, NewObj(1).Put("r", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(30D)), ((V)(50D)), ((V)(18D)), ((V)(44D)), b_1973, NewObj(2).Put("r", ((V)(8D))).Put("bev", ((V)(2D))).V), Call(slab_14, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(54D)), ((V)(50D)), ((V)(50D)), ((V)(12D)), b_1973, NewObj(2).Put("r", ((V)(14D))).Put("soft", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)((-30D))), ((V)(100D)), ((V)(88D)), ((V)(40D)), b_1973, NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(44D)), ((V)((-9.6))), ((V)(84D)), ((V)(48D)), ((V)(1D)), ((V)("#5ad0ff")), NewObj(2).Put("r", ((V)(3D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(58D)), ((V)((-9D))), ((V)(40D)), ((V)(6D)), ((V)(0.6)), ((V)("#ffd23f")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V), Call(disc_17, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(12D)), ((V)(3D)), ((V)("#30333a")), NewObj(1).Put("top", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(98D)), ((V)((-30D))), ((V)(104D)), ((V)(12D)), ((V)(44D)), (SEqS(k_1972, "royal") ? GOLD_25 : ((V)("#e2554a"))), NewObj(1).Put("r", ((V)(4D))).V));
return default;
}, 1, "build", true)).V;
}, 1, "", true);
consoleSet_102 = Fn((V _arrowThis1981, int _argc1974, V S_1980, V _a1977, V _a1978, V _a1979, V[] _rest1975) => {
return NewObj(4).Put("w", ((V)(46D))).Put("d", ((V)(34D))).Put("small", ((V)(1D))).Put("build", Fn((V _arrowThis1989, int _argc1982, V P_1988, V _a1985, V _a1986, V _a1987, V[] _rest1983) => {
return Arr(Call(box_11, V.Undef, ((V)((-6D))), ((V)(0D)), ((V)((-4D))), ((V)(30D)), ((V)(10D)), ((V)(22D)), ((V)((SEqS(Get(S_1980, "k"), "mod") ? "#e9e5dc" : "#5a5f6a"))), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)((-6D))), ((V)(10D)), ((V)((-4D))), ((V)(26D)), ((V)(1D)), ((V)(18D)), ((V)("#4fe0d0")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V), Call(ball_13, V.Undef, ((V)(14D)), ((V)(0D)), ((V)(10D)), ((V)(7D)), DK_29, NewObj(4).Put("sx", ((V)(1.4))).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V), Call(ball_13, V.Undef, ((V)(10D)), ((V)(3.4)), ((V)(13D)), ((V)(1.6)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V), Call(ball_13, V.Undef, ((V)(18D)), ((V)(3.4)), ((V)(13D)), ((V)(1.6)), ((V)("#5cc8f0")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
}, 1, "build", true)).V;
}, 1, "", true);
handheld_103 = Fn((V _arrowThis1997, int _argc1990, V S_1996, V _a1993, V _a1994, V _a1995, V[] _rest1991) => {
return NewObj(4).Put("w", ((V)(26D))).Put("d", ((V)(16D))).Put("small", ((V)(1D))).Put("build", Fn((V _arrowThis2005, int _argc1998, V P_2004, V _a2001, V _a2002, V _a2003, V[] _rest1999) => {
return Arr(Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(36D)), ((V)(6D)), Get(P_2004, "a"), NewObj(1).Put("r", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(3.2)), ((V)(16D)), ((V)(14D)), ((V)(0.6)), ((V)("#9fe0a0")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V), Call(ball_13, V.Undef, ((V)((-5D))), ((V)(6D)), ((V)(3D)), ((V)(2.4)), DK_29, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_13, V.Undef, ((V)(5D)), ((V)(8D)), ((V)(3D)), ((V)(2D)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V), Call(ball_13, V.Undef, ((V)(8D)), ((V)(4D)), ((V)(3D)), ((V)(2D)), ((V)("#ffd23f")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
}, 1, "build", true)).V;
}, 1, "", true);
Set(X_8, "A2", NewObj(39).Put("rug2", Fn((V _arrowThis2013, int _argc2006, V S_2012, V _a2009, V _a2010, V _a2011, V[] _rest2007) => {
V v_2014 = default;
V dm_2015 = default;
v_2014 = Get(S_2012, "v");
dm_2015 = (GetK(RUGD_50, v_2014) is var _t2016 && Truthy(_t2016) ? _t2016 : Arr(((V)(200D)), ((V)(130D))));
return NewObj(6).Put("w", GetIdx(dm_2015, 0D)).Put("d", GetIdx(dm_2015, 1D)).Put("round", ((V)((Truthy(Invoke(Arr(((V)("round")), ((V)("face")), ((V)("record")), ((V)("spiral")), ((V)("flower")), ((V)("shag")), ((V)("oval")), ((V)("star")), ((V)("hex"))), "includes", v_2014)) ? 1D : 0D)))).Put("flat", ((V)(1D))).Put("noBlock", ((V)(1D))).Put("build", Fn((V _arrowThis2024, int _argc2017, V P_2023, V _a2020, V _a2021, V _a2022, V[] _rest2018) => {
return Call(rugB_51, V.Undef, v_2014, Get(S_2012, "k"), P_2023, GetIdx(dm_2015, 0D), GetIdx(dm_2015, 1D));
}, 1, "build", true)).V;
return default;
}, 1, "rug2", true)).Put("lsofa", lsofa_61).Put("usofa", usofa_62).Put("longSofa", longSofa_63).Put("modEnd", modEnd_64).Put("modMid", modMid_65).Put("modCorner", modCorner_66).Put("pit", pit_67).Put("beanpile", beanpile_68).Put("chaise", chaise_69).Put("tvstand", tvstand_71).Put("miniTV", miniTV_72).Put("wallTV", wallTV_73).Put("projector", projector_74).Put("spkTower", spkTower_78).Put("spkWall", spkWall_79).Put("sub", sub_80).Put("smokeSpk", smokeSpk_81).Put("partyBox", partyBox_82).Put("tableLamp", tableLamp_83).Put("sconce", sconce_84).Put("lantern", lantern_85).Put("neonSign", neonSign_86).Put("mushLamp", mushLamp_87).Put("cactus", cactus_89).Put("monstera", monstera_90).Put("sunflower", sunflower_91).Put("bonsai", bonsai_92).Put("flowerPot", flowerPot_93).Put("pottedPalm", pottedPalm_94).Put("succulent", succulent_95).Put("tankSmall", tankSmall_96).Put("aquaBig", aquaBig_97).Put("aquaCol", aquaCol_98).Put("pinball", pinball_99).Put("claw", claw_100).Put("racer", racer_101).Put("consoleSet", consoleSet_102).Put("handheld", handheld_103).V);
Set(X_8, "H2", NewObj(27).Put("NE", NE_24).Put("GOLD", GOLD_25).Put("CH", CH_26).Put("CR", CR_27).Put("WH", WH_28).Put("DK", DK_29).Put("TIN", TIN_30).Put("OLD", OLD_31).Put("OLD2", OLD2_32).Put("INK", INK_33).Put("LEAF", LEAF_34).Put("LEAF2", LEAF2_35).Put("RB6", RB6_36).Put("MT", MT_37).Put("FR", FR_38).Put("polyY", polyY_39).Put("starP", starP_40).Put("rotS", rotS_41).Put("lg", lg_42).Put("jewel", jewel_43).Put("spr", spr_44).Put("drips", drips_45).Put("pot", pot_47).Put("leafB", leafB_88).Put("fish", fish_49).Put("cone", cone_48).Put("scr", scr_46).V);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
