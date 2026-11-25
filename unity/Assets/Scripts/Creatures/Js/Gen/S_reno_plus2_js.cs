// reno-plus2.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus2_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("(-?[\\d.]+) (-?[\\d.]+)", "g");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("fill=\"#", "g");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("pit sofa|curved|conversation", "");
        static readonly System.Text.RegularExpressions.Regex RX3 = JsRegExp.Compile("horseshoe|u-shaped|booth", "");
        static readonly System.Text.RegularExpressions.Regex RX4 = JsRegExp.Compile("l-shaped|sectional|banquette", "");
        static readonly System.Text.RegularExpressions.Regex RX5 = JsRegExp.Compile("two-seater|loveseat|2-seat|pair|bench", "");
        static readonly System.Text.RegularExpressions.Regex RX6 = JsRegExp.Compile("levitat|floating|anti-grav|zero-g|hover", "");
        static readonly System.Text.RegularExpressions.Regex RX7 = JsRegExp.Compile("wingback|throne", "");
        static readonly System.Text.RegularExpressions.Regex RX8 = JsRegExp.Compile("tufted|chesterfield|wingback", "");
        static readonly System.Text.RegularExpressions.Regex RX9 = JsRegExp.Compile("^#(e|f|d)", "i");
        static readonly System.Text.RegularExpressions.Regex RX10 = JsRegExp.Compile("^#(e|f)", "i");
        static readonly System.Text.RegularExpressions.Regex RX11 = JsRegExp.Compile("mascot|dancer|idol|stage", "");
        static readonly System.Text.RegularExpressions.Regex RX12 = JsRegExp.Compile("<\\/svg>\\s*$", "");
        static readonly System.Text.RegularExpressions.Regex RX13 = JsRegExp.Compile("^(rug2|rug|mat)$", "");
        public static void Run()
        {
Call(Named(boot_511 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
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
V pillowZ_20 = default;
V shade_21 = default;
V mix_22 = default;
V f1_23 = default;
V N_24 = default;
V em_25 = default;
V NE_26 = default;
V GOLD_27 = default;
V CH_28 = default;
V WH_29 = default;
V GL_30 = default;
double PI_31 = 0;
V IRON_32 = default;
V metal_33 = default;
V mt_34 = default;
V wd_35 = default;
V cer_36 = default;
V fb_37 = default;
V pt_38 = default;
V rep_39 = default;
V an_40 = default;
V at_41 = default;
V P2_42 = default;
V n4_43 = default;
V mtx_44 = default;
V plane_45 = default;
V planeH_46 = default;
V bob_47 = default;
V GLOW_48 = default;
V hash_49 = default;
V rng_50 = default;
V steam_51 = default;
V spark_52 = default;
V NEV_53 = default;
V seatC_54 = default;
V backC_55 = default;
V throwP_56 = default;
V pitSofa_57 = default;
V POP_58 = default;
V kern_59 = default;
V heap_60 = default;
V plateF_61 = default;
V SPR_62 = default;
V sprinkles_63 = default;
V apple_64 = default;
V orange_65 = default;
V straw_66 = default;
V donut_67 = default;
V cupcake_68 = default;
V cookie_69 = default;
V arcPoly_70 = default;
V bucket_71 = default;
V holoFig_72 = default;
V ringH_73 = default;
V holo0_74 = default;
V VEL_75 = default;
V VELD_76 = default;
V IVORY_77 = default;
V MARB_78 = default;
V veins_79 = default;
V goldPost_80 = default;
V tuftGrid_81 = default;
V LED_DEFS_82 = default;
V ledFloor_83 = default;
V ledWall_84 = default;
V draw0_85 = default;
V SET2_86 = default;
V ROYAL_87 = default;
V ADD2_88 = default;
V BUMP_89 = default;
V edit1_90 = default;
V FOOD2_91 = default;
if (_self1.IsNullish) _self1 = GlobalV;
pitSofa_57 = Fn((V _self92, int _argc93, V S_99, V n_100, V fl_101, V met_102, V[] _rest94) => {
double DK_106 = 0;
double R0_107 = 0;
double Rz_108 = 0;
double a0_109 = 0;
double a1_110 = 0;
double zc_111 = 0;
double aw_112 = 0;
double b0_113 = 0;
double b1_114 = 0;
V segs_115 = default;
V mid_116 = default;
double rs_117 = 0;
V nn_118 = default;
V L1_119 = default;
V L2_120 = default;
V by_103 = default;
V anim_104 = default;
V pad_105 = default;
if (_self92.IsNullish) _self92 = GlobalV;
by_103 = (_argc93 > 4 ? _rest94[0] : V.Undef);
anim_104 = (_argc93 > 5 ? _rest94[1] : V.Undef);
pad_105 = (_argc93 > 6 ? _rest94[2] : V.Undef);
DK_106 = 12D;
R0_107 = (34D + (ToNum(n_100) * 16D));
Rz_108 = (R0_107 * 0.75);
a0_109 = (PI_31 * 1.02);
a1_110 = (PI_31 * 1.98);
zc_111 = (R0_107 * 0.35);
aw_112 = 0.07;
b0_113 = (a0_109 + aw_112);
b1_114 = (a1_110 - aw_112);
segs_115 = Call(rep_39, V.Undef, n_100, Fn((V _arrowThis128, int _argc121, V i_127, V _a124, V _a125, V _a126, V[] _rest122) => {
return Arr(((V)((b0_113 + (((b1_114 - b0_113) * ToNum(i_127)) / ToNum(n_100))))), ((V)((b0_113 + (((b1_114 - b0_113) * ToNum(Add(i_127, ((V)(1D))))) / ToNum(n_100))))));
}, 1, "", true));
mid_116 = Fn((V _arrowThis136, int _argc129, V s_135, V _a132, V _a133, V _a134, V[] _rest130) => {
return ((V)((ToNum(Add(GetIdx(s_135, 0D), GetIdx(s_135, 1D))) / 2D)));
}, 1, "", true);
rs_117 = (((R0_107 - 13D) - 11D) - 18D);
nn_118 = Fn((V _arrowThis144, int _argc137, V a_143, V _a140, V _a141, V _a142, V[] _rest138) => {
return ((V)(Max(3D, Round((ToNum(a_143) / 0.1)))));
}, 1, "", true);
L1_119 = Fn((V _arrowThis152, int _argc145, V P_151, V _a148, V _a149, V _a150, V[] _rest146) => {
V o_153 = default;
o_153 = Arr();
if (!(Truthy(fl_101))) {
Call(rep_39, V.Undef, Add(n_100, ((V)(1D))), Fn((V _arrowThis161, int _argc154, V i_160, V _a157, V _a158, V _a159, V[] _rest155) => {
double a_162 = 0;
a_162 = (a0_109 + (((a1_110 - a0_109) * ToNum(i_160)) / ToNum(n_100)));
Invoke(o_153, "push", Call(cyl_14, V.Undef, ((V)((FdLibm.Cos(a_162) * (R0_107 - 22D)))), ((V)(0D)), ((V)((zc_111 + (FdLibm.Sin(a_162) * (Rz_108 - 22D))))), ((V)(2.6)), ((V)((ToNum(by_103) - 3D))), met_102, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
return default;
}, 1, "", true));
}
Invoke(o_153, "push", Call(arcW_18, V.Undef, ((V)(0D)), ((V)((ToNum(by_103) - 3D))), ((V)(zc_111)), ((V)((R0_107 - 2D))), ((V)((Rz_108 - 2D))), ((V)(56D)), ((V)(3D)), ((V)(a0_109)), ((V)(a1_110)), met_102, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(arcW_18, V.Undef, ((V)(0D)), by_103, ((V)(zc_111)), ((V)(R0_107)), ((V)(Rz_108)), ((V)(13D)), ((V)((DK_106 + 48D))), ((V)(b0_113)), ((V)(b1_114)), Get(P_151, "a"), Call(fb_37, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
return o_153;
return default;
}, 1, "", true);
L2_120 = Fn((V _arrowThis170, int _argc163, V P_169, V _a166, V _a167, V _a168, V[] _rest164) => {
return Invoke(segs_115, "map", Fn((V _arrowThis182, int _argc171, V _a173, V _a174, V _a175, V _a176, V[] _rest172) => {
V s0_179 = default;
V s1_181 = default;
{ V _t177 = ListOf(_a173);
{ V _t178 = GetIdx(_t177, 0D);
s0_179 = _t178; }
{ V _t180 = GetIdx(_t177, 1D);
s1_181 = _t180; }
}
return Call(arcW_18, V.Undef, ((V)(0D)), Add(by_103, ((V)(DK_106))), ((V)(zc_111)), ((V)((R0_107 - 13D))), ((V)((Rz_108 - 13D))), ((V)(11D)), ((V)(42D)), Add(s0_179, ((V)(0.012))), ((V)((ToNum(s1_181) - 0.012))), Get(P_169, "aL"), Call(fb_37, V.Undef, NewObj(1).Put("n", Call(nn_118, V.Undef, ((V)((ToNum(s1_181) - ToNum(s0_179)))))).V));
}, 1, "", true));
}, 1, "", true);
return NewObj(8).Put("w", ((V)(((R0_107 * 2D) + 10D)))).Put("d", ((V)((Rz_108 * 2D)))).Put("act", ((V)("sit"))).Put("seats", Invoke(segs_115, "map", Fn((V _arrowThis190, int _argc183, V s_189, V _a186, V _a187, V _a188, V[] _rest184) => {
return NewObj(3).Put("x", ((V)((FdLibm.Cos(ToNum(Call(mid_116, V.Undef, s_189))) * rs_117)))).Put("z", ((V)((zc_111 + ((FdLibm.Sin(ToNum(Call(mid_116, V.Undef, s_189))) * rs_117) * 0.75))))).Put("h", Add(Add(by_103, ((V)(DK_106))), ((V)(17D)))).V;
}, 1, "", true))).Put("anim", anim_104).Put("pad", pad_105).Put("layers", Arr(NewObj(2).Put("back", ((V)(1D))).Put("build", L1_119).V, NewObj(2).Put("back", ((V)(1D))).Put("build", L2_120).V)).Put("build", Fn((V _arrowThis198, int _argc191, V P_197, V _a194, V _a195, V _a196, V[] _rest192) => {
V o_199 = default;
V fab_200 = default;
V fL_201 = default;
V fD_202 = default;
o_199 = Arr();
fab_200 = Get(P_197, "a");
fL_201 = Get(P_197, "aL");
fD_202 = Get(P_197, "aD");
if (Truthy(fl_101)) {
Invoke(o_199, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)((ToNum(by_103) - 7D))), ((V)((zc_111 - (Rz_108 * 0.4)))), ((V)((R0_107 * 0.7))), ((V)(2D)), ((V)("#8fe8ff")), Call(em_25, V.Undef, NewObj(3).Put("rz", ((V)((Rz_108 * 0.4)))).Put("op", ((V)(0.5))).Put("n", ((V)(20D))).V)));
}
Invoke(o_199, "push", Call(arcW_18, V.Undef, ((V)(0D)), by_103, ((V)(zc_111)), ((V)((R0_107 - 13D))), ((V)((Rz_108 - 13D))), ((V)(46D)), ((V)(DK_106)), ((V)(b0_113)), ((V)(b1_114)), fD_202, Call(fb_37, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
Invoke(Arr(Arr(((V)(a0_109)), ((V)(b0_113))), Arr(((V)(b1_114)), ((V)(a1_110)))), "forEach", Fn((V _arrowThis214, int _argc203, V _a205, V _a206, V _a207, V _a208, V[] _rest204) => {
V s0_211 = default;
V s1_213 = default;
{ V _t209 = ListOf(_a205);
{ V _t210 = GetIdx(_t209, 0D);
s0_211 = _t210; }
{ V _t212 = GetIdx(_t209, 1D);
s1_213 = _t212; }
}
return Invoke(o_199, "push", Call(arcW_18, V.Undef, ((V)(0D)), ((V)((ToNum(by_103) - 3D))), ((V)(zc_111)), ((V)(R0_107)), ((V)(Rz_108)), ((V)(59D)), ((V)((DK_106 + 34D))), s0_211, s1_213, fab_200, Call(fb_37, V.Undef, NewObj(1).Put("n", ((V)(2D))).V)));
}, 1, "", true));
Invoke(segs_115, "forEach", Fn((V _arrowThis227, int _argc215, V _a217, V i_221, V _a219, V _a220, V[] _rest216) => {
double g_228 = 0;
V s0_224 = default;
V s1_226 = default;
{ V _t222 = ListOf(_a217);
{ V _t223 = GetIdx(_t222, 0D);
s0_224 = _t223; }
{ V _t225 = GetIdx(_t222, 1D);
s1_226 = _t225; }
}
g_228 = 0.012;
Invoke(o_199, "push", Call(arcW_18, V.Undef, ((V)(0D)), Add(by_103, ((V)(DK_106))), ((V)(zc_111)), ((V)((R0_107 - 24D))), ((V)((Rz_108 - 24D))), ((V)(34D)), ((V)(15D)), Add(s0_224, ((V)(g_228))), ((V)((ToNum(s1_226) - g_228))), fL_201, Call(fb_37, V.Undef, NewObj(1).Put("n", Call(nn_118, V.Undef, ((V)((ToNum(s1_226) - ToNum(s0_224)))))).V)));
return default;
}, 2, "", true));
Invoke(Arr(GetIdx(segs_115, 0D), GetIdx(segs_115, (ToNum(n_100) - 1D))), "forEach", Fn((V _arrowThis237, int _argc229, V s_235, V i_236, V _a233, V _a234, V[] _rest230) => {
V a_238 = default;
double r_239 = 0;
a_238 = (Truthy(i_236) ? ((V)((ToNum(GetIdx(s_235, 1D)) - 0.18))) : Add(GetIdx(s_235, 0D), ((V)(0.18))));
r_239 = (R0_107 - 30D);
Invoke(o_199, "push", Call(throwP_56, V.Undef, ((V)((FdLibm.Cos(ToNum(a_238)) * r_239))), Add(Add(by_103, ((V)(DK_106))), ((V)(13D))), ((V)(((zc_111 + ((FdLibm.Sin(ToNum(a_238)) * r_239) * 0.75)) + 4D))), ((V)(22D)), (Truthy(i_236) ? Call(shade_21, V.Undef, (Get(P_197, "bL") is var _t240 && Truthy(_t240) ? _t240 : ((V)("#e9d9b0"))), ((V)(0.92))) : (Get(P_197, "bL") is var _t241 && Truthy(_t241) ? _t241 : ((V)("#e9d9b0"))))));
return default;
}, 2, "", true));
return o_199;
return default;
}, 1, "build", true)).V;
return default;
}, 7, "pitSofa", false);
ledFloor_83 = Fn((V _self242, int _argc243, V t_249, V _a246, V _a247, V _a248, V[] _rest244) => {
V FLT_250 = default;
V px_251 = default;
V P_252 = default;
V T_253 = default;
V quad_254 = default;
JsStrBuf s_255 = null;
V rope_256 = default;
if (_self242.IsNullish) _self242 = GlobalV;
FLT_250 = (!(!(Truthy(Get(RD_8, "_FLAT")))) ? V.True : V.False);
px_251 = Fn((V _arrowThis265, int _argc257, V u_263, V v_264, V _a261, V _a262, V[] _rest258) => {
return (Truthy(FLT_250) ? Arr(((V)((80D * ToNum(u_263)))), ((V)((56D * ToNum(v_264))))) : Arr(((V)(((14D - (14D * ToNum(v_264))) + ((52D + (28D * ToNum(v_264))) * ToNum(u_263))))), ((V)((ToNum(v_264) * 56D)))));
}, 2, "", true);
P_252 = Fn((V _arrowThis274, int _argc266, V u_272, V v_273, V _a270, V _a271, V[] _rest267) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(Call(px_251, V.Undef, u_272, v_273), 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(Call(px_251, V.Undef, u_272, v_273), 1D))).End()));
}, 2, "", true);
T_253 = ((V)((Truthy(FLT_250) ? "M0 0H80V56H0Z" : "M14 0H66L80 56H0Z")));
quad_254 = Fn((V _arrowThis285, int _argc275, V u0_281, V v0_282, V u1_283, V v1_284, V[] _rest276) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(P_252, V.Undef, u0_281, v0_282)).S("L").V(Call(P_252, V.Undef, u1_283, v0_282)).S("L").V(Call(P_252, V.Undef, u1_283, v1_284)).S("L").V(Call(P_252, V.Undef, u0_281, v1_284)).S("Z").End()));
}, 4, "", true);
s_255 = new JsStrBuf(JsStrBuf.Begin().S("<defs>").V(LED_DEFS_82).S("<clipPath id=\"lfc\"><path d=\"").V(T_253).S("\"/></clipPath></defs><g clip-path=\"url(#lfc)\">").End());
rope_256 = Fn((V _arrowThis294, int _argc286, V w_292, V op_293, V _a290, V _a291, V[] _rest287) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M15 1H65L78.6 55.2H1.4Z\" fill=\"none\" stroke=\"").V(GetIdx(NE_26, 0D)).S("\" stroke-width=\"").V(w_292).S("\" stroke-dasharray=\"2 2.6\" stroke-linejoin=\"round\" opacity=\"").V(op_293).S("\">").V(Call(an_40, V.Undef, ((V)("stroke")), NEV_53, ((V)(3D)))).V(Call(an_40, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-18.4")), ((V)(1.1)))).S("</path>").End()));
}, 2, "", true);
if (LeN(t_249, 2D)) {
if (SEqN(t_249, 2D)) {
{
double v_295 = 0;
v_295 = 0D;
while (true) {
if (!((v_295 < 5D))) break;
{
double u_297 = 0;
u_297 = 0D;
while (true) {
if (!((u_297 < 6D))) break;
if ((((u_297 + v_295) % 2D) == 0D)) {
s_255.S("<path d=\"").V(Call(quad_254, V.Undef, ((V)(((u_297 / 6D) + 0.012))), ((V)(((v_295 / 5D) + 0.02))), ((V)((((u_297 + 1D) / 6D) - 0.012))), ((V)((((v_295 + 1D) / 5D) - 0.02))))).S("\" fill=\"").V(GetIdx(NE_26, ((u_297 + v_295) % 6D))).S("\" opacity=\"0\">").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0;0.55;0")), ((V)(2.4)), ((V)((-ToNum(Invoke(((V)(((u_297 + v_295) * 0.3))), "toFixed", ((V)(2D))))))))).V(Call(an_40, V.Undef, ((V)("fill")), NEV_53, ((V)(4.2)), ((V)((-ToNum(Invoke(((V)((u_297 * 0.5))), "toFixed", ((V)(2D))))))))).S("</path>");
} else {
Invoke(Arr(Arr(((V)(0.3)), ((V)(0.45)), ((V)(10D))), Arr(((V)(0.7)), ((V)(0.62)), ((V)(12D))), Arr(((V)(0.5)), ((V)(0.86)), ((V)(14D)))), "forEach", Fn((V _arrowThis313, int _argc299, V _a301, V i_305, V _a303, V _a304, V[] _rest300) => {
V q_314 = default;
V u_308 = default;
V v_310 = default;
V r_312 = default;
{ V _t306 = ListOf(_a301);
{ V _t307 = GetIdx(_t306, 0D);
u_308 = _t307; }
{ V _t309 = GetIdx(_t306, 1D);
v_310 = _t309; }
{ V _t311 = GetIdx(_t306, 2D);
r_312 = _t311; }
}
q_314 = Call(px_251, V.Undef, u_308, v_310);
s_255.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_314, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_314, 1D))).S("\" rx=\"").V(r_312).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(r_312) * 0.42))))).S("\" fill=\"").V(GetIdx(NE_26, (ToNum(i_305) * 2D))).S("\" opacity=\"0.2\" filter=\"url(#lgp)\">").V(Call(an_40, V.Undef, ((V)("fill")), NEV_53, ((V)(3D)), ((V)((-ToNum(i_305)))))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.1;0.32;0.1")), ((V)(1.4)), ((V)(((-ToNum(i_305)) * 0.45))))).S("</ellipse>");
return default;
}, 2, "", true));
}
u_297++;
}
}
v_295++;
}
}
}
s_255.S("<g filter=\"url(#lgb)\">").V(Call(rope_256, V.Undef, ((V)(3D)), ((V)(0.7)))).S("</g>").V(Call(rope_256, V.Undef, ((V)(1.2)), ((V)(1D))));
} else {
V NEO_315 = default;
double nx_316 = 0;
double ny_317 = 0;
double gu_318 = 0;
double gv_319 = 0;
double lift_320 = 0;
V tile_321 = default;
JsStrBuf tl_322 = null;
JsStrBuf sh_323 = null;
JsStrBuf ov_324 = null;
NEO_315 = Arr(((V)("#ff3fb4")), ((V)("#a64dff")), ((V)("#3f8cff")), ((V)("#2fe0ff")), ((V)("#3fff9a")), ((V)("#ffe23f")), ((V)("#ff8a2f")));
nx_316 = (SEqN(t_249, 3D) ? 5D : (SEqN(t_249, 4D) ? 8D : 10D));
ny_317 = (SEqN(t_249, 3D) ? 4D : (SEqN(t_249, 4D) ? 6D : 7D));
gu_318 = ((SEqN(t_249, 3D) ? 0.16 : 0.09) / nx_316);
gv_319 = ((SEqN(t_249, 3D) ? 0.18 : 0.1) / ny_317);
s_255.S("<defs><filter id=\"lfn\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"1.2\"/></filter><linearGradient id=\"lf0\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#0d0d10\"/><stop offset=\"1\" stop-color=\"#050506\"/></linearGradient>").S("<linearGradient id=\"lfs\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.2\"/><stop offset=\"0.55\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient></defs><path d=\"").V(T_253).S("\" fill=\"url(#lf0)\"/>");
lift_320 = (SEqN(t_249, 5D) ? 1.1 : 0D);
tile_321 = Fn((V _arrowThis334, int _argc325, V i_331, V j_332, V dy_333, V _a330, V[] _rest326) => {
double a_335 = 0;
double b_336 = 0;
double c_337 = 0;
double d_338 = 0;
a_335 = ((ToNum(i_331) / nx_316) + gu_318);
b_336 = ((ToNum(j_332) / ny_317) + gv_319);
c_337 = ((ToNum(Add(i_331, ((V)(1D)))) / nx_316) - gu_318);
d_338 = ((ToNum(Add(j_332, ((V)(1D)))) / ny_317) - gv_319);
return (Truthy(dy_333) ? Invoke(Call(quad_254, V.Undef, ((V)(a_335)), ((V)(b_336)), ((V)(c_337)), ((V)(d_338))), "replace", NewRegExp(RX0, "(-?[\\d.]+) (-?[\\d.]+)", "g"), Fn((V _arrowThis348, int _argc339, V m_345, V x_346, V y_347, V _a344, V[] _rest340) => {
return ((V)(JsStrBuf.Begin().V(x_346).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(y_347) - ToNum(dy_333)))))).End()));
}, 3, "", true)) : Call(quad_254, V.Undef, ((V)(a_335)), ((V)(b_336)), ((V)(c_337)), ((V)(d_338))));
return default;
}, 3, "", true);
tl_322 = new JsStrBuf("");
sh_323 = new JsStrBuf("");
ov_324 = new JsStrBuf("");
{
double j_349 = 0;
j_349 = 0D;
while (true) {
if (!((j_349 < ny_317))) break;
{
double i_351 = 0;
i_351 = 0D;
while (true) {
if (!((i_351 < nx_316))) break;
double k_353 = 0;
V seq_354 = default;
double b_355 = 0;
k_353 = ((i_351 + (j_349 * 2D)) % ToNum(Get(NEO_315, "length")));
seq_354 = Invoke(Invoke(Call(rep_39, V.Undef, Get(NEO_315, "length"), Fn((V _arrowThis363, int _argc356, V m_362, V _a359, V _a360, V _a361, V[] _rest357) => {
return GetIdx(NEO_315, (ToNum(Add(((V)(k_353)), m_362)) % ToNum(Get(NEO_315, "length"))));
}, 1, "", true)), "concat", GetIdx(NEO_315, k_353)), "join", ((V)(";")));
b_355 = (-ToNum(Invoke(((V)(((i_351 + j_349) * 0.18))), "toFixed", ((V)(2D)))));
tl_322.S("<path d=\"").V(Call(tile_321, V.Undef, ((V)(i_351)), ((V)(j_349)), ((V)(lift_320)))).S("\" fill=\"").V(GetIdx(NEO_315, k_353)).S("\">").V(Call(an_40, V.Undef, ((V)("fill")), seq_354, ((V)(5.6)), ((V)(b_355)))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("1;0.3;1")), ((V)(1.4)), Invoke(((V)((b_355 * 0.5))), "toFixed", ((V)(2D))))).S("</path>");
if (SEqN(t_249, 3D)) {
double a_364 = 0;
double bb_365 = 0;
double c_366 = 0;
double d_367 = 0;
double ia_368 = 0;
double ib_369 = 0;
double ic_370 = 0;
double id_371 = 0;
a_364 = ((i_351 / nx_316) + gu_318);
bb_365 = ((j_349 / ny_317) + gv_319);
c_366 = (((i_351 + 1D) / nx_316) - gu_318);
d_367 = (((j_349 + 1D) / ny_317) - gv_319);
ia_368 = (a_364 + (0.18 / nx_316));
ib_369 = (bb_365 + (0.18 / ny_317));
ic_370 = (c_366 - (0.18 / nx_316));
id_371 = (d_367 - (0.18 / ny_317));
ov_324.S("<path d=\"").V(Call(quad_254, V.Undef, ((V)(a_364)), ((V)(bb_365)), ((V)(c_366)), ((V)(d_367)))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.45\" opacity=\"0.45\"/><path d=\"").V(Call(quad_254, V.Undef, ((V)(ia_368)), ((V)(ib_369)), ((V)(ic_370)), ((V)(id_371)))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.3\" opacity=\"0.25\"/>").S("<path d=\"M").V(Call(P_252, V.Undef, ((V)(a_364)), ((V)(bb_365)))).S("L").V(Call(P_252, V.Undef, ((V)((a_364 + ((c_366 - a_364) * 0.55)))), ((V)(bb_365)))).S("L").V(Call(P_252, V.Undef, ((V)(a_364)), ((V)((bb_365 + ((d_367 - bb_365) * 0.6)))))).S("Z\" fill=\"#ffffff\" opacity=\"0.16\"/>");
}
if (SEqN(t_249, 5D)) {
sh_323.S("<path d=\"").V(Call(tile_321, V.Undef, ((V)(i_351)), ((V)(j_349)), ((V)(0D)))).S("\" fill=\"#000000\" opacity=\"0.85\"/>");
}
i_351++;
}
}
j_349++;
}
}
if (SEqN(t_249, 3D)) {
{
double i_372 = 0;
i_372 = 0D;
while (true) {
if (!((i_372 <= nx_316))) break;
s_255.S("<path d=\"M").V(Call(P_252, V.Undef, ((V)((i_372 / nx_316))), ((V)(0D)))).S("L").V(Call(P_252, V.Undef, ((V)((i_372 / nx_316))), ((V)(1D)))).S("\" stroke=\"#b8bcc4\" stroke-width=\"0.9\"/>");
i_372++;
}
}
{
double j_374 = 0;
j_374 = 0D;
while (true) {
if (!((j_374 <= ny_317))) break;
s_255.S("<path d=\"M").V(Call(P_252, V.Undef, ((V)(0D)), ((V)((j_374 / ny_317))))).S("L").V(Call(P_252, V.Undef, ((V)(1D)), ((V)((j_374 / ny_317))))).S("\" stroke=\"#b8bcc4\" stroke-width=\"0.9\"/>");
j_374++;
}
}
}
if (SEqN(t_249, 4D)) {
double N_376 = 0;
N_376 = 3D;
{
double i_377 = 0;
i_377 = 1D;
while (true) {
if (!((i_377 < (nx_316 * N_376)))) break;
if (NumTruthy((i_377 % N_376))) {
ov_324.S("<path d=\"M").V(Call(P_252, V.Undef, ((V)((i_377 / (nx_316 * N_376)))), ((V)(0D)))).S("L").V(Call(P_252, V.Undef, ((V)((i_377 / (nx_316 * N_376)))), ((V)(1D)))).S("\" stroke=\"#000000\" stroke-width=\"0.28\" opacity=\"0.6\"/>");
}
i_377++;
}
}
{
double j_379 = 0;
j_379 = 1D;
while (true) {
if (!((j_379 < (ny_317 * N_376)))) break;
if (NumTruthy((j_379 % N_376))) {
ov_324.S("<path d=\"M").V(Call(P_252, V.Undef, ((V)(0D)), ((V)((j_379 / (ny_317 * N_376)))))).S("L").V(Call(P_252, V.Undef, ((V)(1D)), ((V)((j_379 / (ny_317 * N_376)))))).S("\" stroke=\"#000000\" stroke-width=\"0.28\" opacity=\"0.6\"/>");
}
j_379++;
}
}
}
if (SEqN(t_249, 5D)) {
{
double i_381 = 0;
i_381 = 0D;
while (true) {
if (!((i_381 <= nx_316))) break;
s_255.S("<path d=\"M").V(Call(P_252, V.Undef, ((V)((i_381 / nx_316))), ((V)(0D)))).S("L").V(Call(P_252, V.Undef, ((V)((i_381 / nx_316))), ((V)(1D)))).S("\" stroke=\"#3a3d48\" stroke-width=\"0.35\"/>");
i_381++;
}
}
{
double j_383 = 0;
j_383 = 0D;
while (true) {
if (!((j_383 <= ny_317))) break;
s_255.S("<path d=\"M").V(Call(P_252, V.Undef, ((V)(0D)), ((V)((j_383 / ny_317))))).S("L").V(Call(P_252, V.Undef, ((V)(1D)), ((V)((j_383 / ny_317))))).S("\" stroke=\"#3a3d48\" stroke-width=\"0.35\"/>");
j_383++;
}
}
ov_324.S("<g opacity=\"0.5\">").V(Invoke(((V)(tl_322.Str)), "replace", NewRegExp(RX1, "fill=\"#", "g"), ((V)("stroke-width=\"0.3\" stroke=\"#ffffff\" fill-opacity=\"0\" data-f=\"#")))).S("</g>");
}
s_255.S(sh_323.Str).S("<g filter=\"url(#lfn)\" opacity=\"0.5\">").S(tl_322.Str).S("</g>").S(tl_322.Str).S(ov_324.Str).S((Truthy(FLT_250) ? "" : JsStrBuf.Begin().S("<path d=\"").V(T_253).S("\" fill=\"url(#lfs)\"/><path d=\"").V(T_253).S("\" fill=\"none\" stroke=\"#000000\" stroke-width=\"0.35\"/>").End()));
}
return ((V)(string.Concat(s_255.Str, "</g>")));
return default;
}, 1, "ledFloor", false);
ledWall_84 = Fn((V _self385, int _argc386, V t_392, V _a389, V _a390, V _a391, V[] _rest387) => {
JsStrBuf s_393 = null;
if (_self385.IsNullish) _self385 = GlobalV;
s_393 = new JsStrBuf(JsStrBuf.Begin().S("<defs>").V(LED_DEFS_82).S("<clipPath id=\"lwc\"><rect x=\"0\" y=\"0\" width=\"80\" height=\"56\" rx=\"4\"/></clipPath></defs><g clip-path=\"url(#lwc)\">").End());
if (SEqN(t_392, 1D)) {
Invoke(Arr(Arr(((V)(4D)), ((V)(4D))), Arr(((V)(16D)), ((V)(3.4)))), "forEach", Fn((V _arrowThis406, int _argc394, V _a396, V k_400, V _a398, V _a399, V[] _rest395) => {
JsStrBuf d_407 = null;
V y0_403 = default;
V sag_405 = default;
{ V _t401 = ListOf(_a396);
{ V _t402 = GetIdx(_t401, 0D);
y0_403 = _t402; }
{ V _t404 = GetIdx(_t401, 1D);
sag_405 = _t404; }
}
d_407 = new JsStrBuf(JsStrBuf.Begin().S("M0 ").V(y0_403).End());
{
double x_408 = 0;
x_408 = 0D;
while (true) {
if (!((x_408 <= 80D))) break;
d_407.S("L").N(x_408).S(" ").V(Call(f1_23, V.Undef, Add(y0_403, ((V)((ToNum(sag_405) * System.Math.Abs(FdLibm.Sin(((PI_31 * x_408) / 40D)))))))));
x_408 = (x_408 + 2D);
}
}
s_393.S("<path d=\"").S(d_407.Str).S("\" fill=\"none\" stroke=\"#2c2d31\" stroke-width=\"0.5\"/>");
Call(rep_39, V.Undef, ((V)(14D)), Fn((V _arrowThis417, int _argc410, V i_416, V _a413, V _a414, V _a415, V[] _rest411) => {
double x_418 = 0;
V y_419 = default;
V c_420 = default;
double b_421 = 0;
x_418 = (2.8 + (ToNum(i_416) * 5.6));
y_419 = Add(Add(y0_403, ((V)((ToNum(sag_405) * System.Math.Abs(FdLibm.Sin(((PI_31 * x_418) / 40D))))))), ((V)(1.4)));
c_420 = GetIdx(NE_26, (ToNum(Add(i_416, ((V)((ToNum(k_400) * 3D))))) % 6D));
b_421 = ((-(((ToNum(i_416) * 7D) + (ToNum(k_400) * 3D)) % 10D)) * 0.18);
s_393.S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)(x_418)))).S("\" cy=\"").V(Call(f1_23, V.Undef, y_419)).S("\" r=\"3.2\" fill=\"").V(c_420).S("\" filter=\"url(#lgb)\" opacity=\"0.6\">").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.15;0.8;0.15")), ((V)(1.8)), Invoke(((V)(b_421)), "toFixed", ((V)(2D))))).S("</circle><circle cx=\"").V(Call(f1_23, V.Undef, ((V)(x_418)))).S("\" cy=\"").V(Call(f1_23, V.Undef, y_419)).S("\" r=\"1.2\" fill=\"").V(c_420).S("\">").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.4;1;0.4")), ((V)(1.8)), Invoke(((V)(b_421)), "toFixed", ((V)(2D))))).S("</circle>");
return default;
}, 1, "", true));
return default;
}, 2, "", true));
} else {
if (SEqN(t_392, 2D)) {
s_393.S("<rect x=\"0\" y=\"0\" width=\"80\" height=\"56\" fill=\"").V(GetIdx(NE_26, 0D)).S("\" opacity=\"0.12\">").V(Call(an_40, V.Undef, ((V)("fill")), NEV_53, ((V)(5D)))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.06;0.18;0.06")), ((V)(1.6)))).S("</rect>");
Invoke(Arr(((V)(2D)), ((V)(54D))), "forEach", Fn((V _arrowThis430, int _argc422, V y_428, V i_429, V _a426, V _a427, V[] _rest423) => {
return ((V)(s_393.S("<path d=\"M0 ").V(y_428).S("H80\" stroke=\"").V(GetK(NE_26, i_429)).S("\" stroke-width=\"5\" filter=\"url(#lgb)\" opacity=\"0.7\">").V(Call(an_40, V.Undef, ((V)("stroke")), NEV_53, ((V)(3D)), ((V)(((-ToNum(i_429)) * 1.5))))).S("</path><path d=\"M0 ").V(y_428).S("H80\" stroke=\"#ffffff\" stroke-width=\"1.2\" stroke-dasharray=\"1.6 1.4\">").V(Call(an_40, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-6")), ((V)(0.6)))).S("</path>").Str));
}, 2, "", true));
Call(rep_39, V.Undef, ((V)(10D)), Fn((V _arrowThis438, int _argc431, V i_437, V _a434, V _a435, V _a436, V[] _rest432) => {
return ((V)(s_393.S("<circle cx=\"").N((6D + (ToNum(i_437) * 7.6))).S("\" cy=\"").N((NumTruthy((ToNum(i_437) % 2D)) ? 22D : 38D)).S("\" r=\"0.9\" fill=\"").V(GetIdx(NE_26, (ToNum(i_437) % 6D))).S("\">").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0;1;0")), ((V)(1.2)), Invoke(((V)(((-ToNum(i_437)) * 0.23))), "toFixed", ((V)(2D))))).S("</circle>").Str));
}, 1, "", true));
} else {
if (SEqN(t_392, 3D)) {
Invoke(Arr(Arr(((V)(14D)), ((V)("#ff6ad5"))), Arr(((V)(44D)), ((V)("#4fe0d0")))), "forEach", Fn((V _arrowThis451, int _argc439, V _a441, V i_445, V _a443, V _a444, V[] _rest440) => {
V y_448 = default;
V c_450 = default;
{ V _t446 = ListOf(_a441);
{ V _t447 = GetIdx(_t446, 0D);
y_448 = _t447; }
{ V _t449 = GetIdx(_t446, 1D);
c_450 = _t449; }
}
return ((V)(s_393.S("<path d=\"M0 ").V(y_448).S("H80\" stroke=\"").V(c_450).S("\" stroke-width=\"5\" filter=\"url(#lgb)\">").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.5;1;0.5;1;0.2;1")), ((V)(2.6)), ((V)(((-ToNum(i_445)) * 0.7))), ((V)("0;0.3;0.5;0.8;0.84;1")))).V(Call(an_40, V.Undef, ((V)("stroke")), ((V)((Truthy(i_445) ? "#4fe0d0;#6ac8ff;#a6f06a;#4fe0d0" : "#ff6ad5;#b48cff;#ff9d4a;#ff6ad5"))), ((V)(5D)))).S("</path>").Str));
}, 2, "", true));
s_393.S("<path d=\"M2 29Q12 21 22 29T42 29T62 29T82 29\" fill=\"none\" stroke=\"#ffd66b\" stroke-width=\"4\" filter=\"url(#lgb)\" opacity=\"0.8\">").V(Call(an_40, V.Undef, ((V)("stroke")), NEV_53, ((V)(4D)))).S("</path><path d=\"M2 29Q12 21 22 29T42 29T62 29T82 29\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.1\" stroke-dasharray=\"6 4\">").V(Call(an_40, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-20")), ((V)(1D)))).S("</path>");
} else {
V R_452 = default;
double @base_453 = 0;
double hi_454 = 0;
double nc_455 = 0;
R_452 = Call(rng_50, V.Undef, ((V)(JsStrBuf.Begin().S("eq").V(t_392).End())));
@base_453 = (SEqN(t_392, 5D) ? 54D : 52D);
hi_454 = (SEqN(t_392, 5D) ? 24D : 40D);
nc_455 = 16D;
if (SEqN(t_392, 5D)) {
s_393.S("<rect x=\"0\" y=\"0\" width=\"80\" height=\"56\" fill=\"#120e24\"/><g filter=\"url(#lgp)\" opacity=\"0.8\">");
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis463, int _argc456, V i_462, V _a459, V _a460, V _a461, V[] _rest457) => {
V cx_464 = default;
V cy_465 = default;
V r_466 = default;
cx_464 = GetK(Arr(((V)(16D)), ((V)(40D)), ((V)(64D)), ((V)(28D)), ((V)(54D))), i_462);
cy_465 = GetK(Arr(((V)(18D)), ((V)(30D)), ((V)(16D)), ((V)(40D)), ((V)(42D))), i_462);
r_466 = GetK(Arr(((V)(16D)), ((V)(18D)), ((V)(14D)), ((V)(13D)), ((V)(15D))), i_462);
s_393.S("<circle cx=\"").V(cx_464).S("\" cy=\"").V(cy_465).S("\" r=\"").V(r_466).S("\" fill=\"").V(GetK(NE_26, i_462)).S("\">").V(Call(an_40, V.Undef, ((V)("fill")), NEV_53, ((V)(5D)), ((V)((-ToNum(i_462)))))).V(Call(an_40, V.Undef, ((V)("cx")), ((V)(JsStrBuf.Begin().V(cx_464).S(";").V(Add(cx_464, ((V)((NumTruthy((ToNum(i_462) % 2D)) ? 10D : (-10D)))))).S(";").V(cx_464).End())), ((V)((4D + (ToNum(i_462) * 0.6)))))).V(Call(an_40, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(cy_465).S(";").V(Add(cy_465, ((V)((NumTruthy((ToNum(i_462) % 2D)) ? (-6D) : 6D))))).S(";").V(cy_465).End())), ((V)((3.4 + (ToNum(i_462) * 0.5)))))).S("</circle>");
return default;
}, 1, "", true));
s_393.S("</g>");
s_393.S("<rect x=\"0\" y=\"0\" width=\"80\" height=\"3\" fill=\"#ffffff\" opacity=\"0.35\">").V(Call(an_40, V.Undef, ((V)("y")), ((V)("-3;56")), ((V)(2.6)))).S("</rect>");
} else {
s_393.S("<rect x=\"2\" y=\"6\" width=\"76\" height=\"48\" rx=\"2\" fill=\"#0a0b10\" opacity=\"0.72\"/>");
}
Call(rep_39, V.Undef, ((V)(nc_455)), Fn((V _arrowThis474, int _argc467, V i_473, V _a470, V _a471, V _a472, V[] _rest468) => {
double x_475 = 0;
V hs_476 = default;
x_475 = (3D + (ToNum(i_473) * 4.6));
hs_476 = Call(rep_39, V.Undef, ((V)(6D)), Fn((V _arrowThis483, int _argc477, V _a479, V _a480, V _a481, V _a482, V[] _rest478) => {
return Call(f1_23, V.Undef, ((V)((4D + (ToNum(Call(R_452, V.Undef)) * hi_454)))));
}, 0, "", true));
Invoke(hs_476, "push", GetIdx(hs_476, 0D));
s_393.S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)(x_475)))).S("\" width=\"3.6\" fill=\"").V(GetIdx(NE_26, (ToNum(i_473) % 6D))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((@base_453 - ToNum(GetIdx(hs_476, 0D))))))).S("\" height=\"").V(GetIdx(hs_476, 0D)).S("\">").V(Call(an_40, V.Undef, ((V)("height")), Invoke(hs_476, "join", ((V)(";"))), ((V)((1.8 + ((ToNum(i_473) % 3D) * 0.2)))))).V(Call(an_40, V.Undef, ((V)("y")), Invoke(Invoke(hs_476, "map", Fn((V _arrowThis491, int _argc484, V h_490, V _a487, V _a488, V _a489, V[] _rest485) => {
return Call(f1_23, V.Undef, ((V)((@base_453 - ToNum(h_490)))));
}, 1, "", true)), "join", ((V)(";"))), ((V)((1.8 + ((ToNum(i_473) % 3D) * 0.2)))))).V(Call(an_40, V.Undef, ((V)("fill")), NEV_53, ((V)(6D)), ((V)(((-ToNum(i_473)) * 0.3))))).S("</rect>");
return default;
}, 1, "", true));
s_393.S("<g opacity=\"0.6\">").V(Invoke(Call(rep_39, V.Undef, ((V)((System.Math.Ceiling((hi_454 / 3D)) + 2D))), Fn((V _arrowThis499, int _argc492, V j_498, V _a495, V _a496, V _a497, V[] _rest493) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"0\" y=\"").V(Call(f1_23, V.Undef, ((V)(((@base_453 - (3D * ToNum(j_498))) - 0.7))))).S("\" width=\"80\" height=\"0.7\" fill=\"#0a0b10\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Call(rep_39, V.Undef, ((V)(nc_455)), Fn((V _arrowThis507, int _argc500, V i_506, V _a503, V _a504, V _a505, V[] _rest501) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)(((3D + (ToNum(i_506) * 4.6)) + 3.6))))).S("\" y=\"0\" width=\"1\" height=\"56\" fill=\"#0a0b10\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
if (SEqN(t_392, 4D)) {
s_393.S("<rect x=\"0\" y=\"0\" width=\"80\" height=\"56\" fill=\"url(#lws)\"/><defs><linearGradient id=\"lws\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0.3\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.35\"/><stop offset=\"0.7\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"-1 -1;1 1\" dur=\"3s\" repeatCount=\"indefinite\"/></linearGradient></defs>");
}
}
}
}
return ((V)(string.Concat(s_393.Str, "</g>")));
return default;
}, 1, "ledWall", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((RD_8 is var _t508 && !Truthy(_t508) ? _t508 : Get(RD_8, "PLUS")) is var _t509 && !Truthy(_t509) ? _t509 : X_9) is var _t510 && !Truthy(_t510) ? _t510 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_511.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS2"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t512 = K_10;
if (_t512.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t512));
{ V _t513 = Get(_t512, "solid");
solid_11 = _t513; }
{ V _t514 = Get(_t512, "box");
box_12 = _t514; }
{ V _t515 = Get(_t512, "cush");
cush_13 = _t515; }
{ V _t516 = Get(_t512, "cyl");
cyl_14 = _t516; }
{ V _t517 = Get(_t512, "ball");
ball_15 = _t517; }
{ V _t518 = Get(_t512, "slab");
slab_16 = _t518; }
{ V _t519 = Get(_t512, "slabX");
slabX_17 = _t519; }
{ V _t520 = Get(_t512, "arcW");
arcW_18 = _t520; }
{ V _t521 = Get(_t512, "disc");
disc_19 = _t521; }
{ V _t522 = Get(_t512, "pillowZ");
pillowZ_20 = _t522; }
{ V _t523 = Get(_t512, "shade");
shade_21 = _t523; }
{ V _t524 = Get(_t512, "mix");
mix_22 = _t524; }
{ V _t525 = Get(_t512, "f1");
f1_23 = _t525; } }
N_24 = Get(RD_8, "N");
em_25 = Get(Get(RD_8, "H"), "em");
NE_26 = Get(K_10, "NEON");
GOLD_27 = ((V)("#e2b14a"));
CH_28 = ((V)("#d5dde2"));
WH_29 = ((V)("#ffffff"));
GL_30 = ((V)("#cfe8f2"));
PI_31 = System.Math.PI;
IRON_32 = ((V)("#3b3c40"));
metal_33 = Fn((V _arrowThis533, int _argc526, V k_532, V _a529, V _a530, V _a531, V[] _rest527) => {
return (SEqS(k_532, "royal") ? GOLD_27 : (SEqS(k_532, "candy") ? ((V)("#e9ecef")) : (SEqS(k_532, "junk") ? ((V)("#7d7f84")) : (SEqS(k_532, "mod") ? ((V)("#2c2d31")) : (SEqS(k_532, "retro") ? CH_28 : IRON_32)))));
}, 1, "", true);
mt_34 = Fn((V _arrowThis541, int _argc534, V o_540, V _a537, V _a538, V _a539, V[] _rest535) => {
return Object_assign(NewObj(1).Put("mat", ((V)("metal"))).V, (o_540 is var _t542 && Truthy(_t542) ? _t542 : NewObj(0).V));
}, 1, "", true);
wd_35 = Fn((V _arrowThis550, int _argc543, V o_549, V _a546, V _a547, V _a548, V[] _rest544) => {
return Object_assign(NewObj(1).Put("mat", ((V)("wood"))).V, (o_549 is var _t551 && Truthy(_t551) ? _t551 : NewObj(0).V));
}, 1, "", true);
cer_36 = Fn((V _arrowThis559, int _argc552, V o_558, V _a555, V _a556, V _a557, V[] _rest553) => {
return Object_assign(NewObj(1).Put("mat", ((V)("cer"))).V, (o_558 is var _t560 && Truthy(_t560) ? _t560 : NewObj(0).V));
}, 1, "", true);
fb_37 = Fn((V _arrowThis568, int _argc561, V o_567, V _a564, V _a565, V _a566, V[] _rest562) => {
return Object_assign(NewObj(2).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V, (o_567 is var _t569 && Truthy(_t569) ? _t569 : NewObj(0).V));
}, 1, "", true);
pt_38 = Fn((V _arrowThis577, int _argc570, V o_576, V _a573, V _a574, V _a575, V[] _rest571) => {
return Object_assign(NewObj(1).Put("mat", ((V)("paint"))).V, (o_576 is var _t578 && Truthy(_t578) ? _t578 : NewObj(0).V));
}, 1, "", true);
rep_39 = Fn((V _arrowThis587, int _argc579, V n_585, V f_586, V _a583, V _a584, V[] _rest580) => {
return Array_from(NewObj(1).Put("length", n_585).V, Fn((V _arrowThis596, int _argc588, V __594, V i_595, V _a592, V _a593, V[] _rest589) => {
return Call(f_586, V.Undef, i_595);
}, 2, "", true));
}, 2, "", true);
an_40 = Fn((V _arrowThis608, int _argc597, V a_603, V v_604, V d_605, V b_606, V[] _rest598) => {
V kt_607 = default;
kt_607 = (_argc597 > 4 ? _rest598[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"").V(a_603).S("\" values=\"").V(v_604).S("\" dur=\"").V(d_605).S("s\"").S((Truthy(kt_607) ? JsStrBuf.Begin().S(" keyTimes=\"").V(kt_607).S("\"").End() : "")).S((Truthy(b_606) ? JsStrBuf.Begin().S(" begin=\"").V(b_606).S("s\"").End() : "")).S(" repeatCount=\"indefinite\"/>").End()));
}, 5, "", true);
at_41 = Fn((V _arrowThis620, int _argc609, V t_615, V v_616, V d_617, V b_618, V[] _rest610) => {
V kt_619 = default;
kt_619 = (_argc609 > 4 ? _rest610[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"").V(t_615).S("\" values=\"").V(v_616).S("\" dur=\"").V(d_617).S("s\"").S((Truthy(kt_619) ? JsStrBuf.Begin().S(" keyTimes=\"").V(kt_619).S("\"").End() : "")).S((Truthy(b_618) ? JsStrBuf.Begin().S(" begin=\"").V(b_618).S("s\"").End() : "")).S(" repeatCount=\"indefinite\"/>").End()));
}, 5, "", true);
P2_42 = Fn((V _arrowThis628, int _argc621, V q_627, V _a624, V _a625, V _a626, V[] _rest622) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(q_627, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_627, 1D))).End()));
}, 1, "", true);
n4_43 = Fn((V _arrowThis636, int _argc629, V v_635, V _a632, V _a633, V _a634, V[] _rest630) => {
return ((V)((Round((ToNum(v_635) * 10000D)) / 10000D)));
}, 1, "", true);
mtx_44 = Fn((V _arrowThis646, int _argc637, V o_643, V a_644, V b_645, V _a642, V[] _rest638) => {
return ((V)(JsStrBuf.Begin().S("matrix(").V(Invoke(Invoke(Arr(((V)((ToNum(GetIdx(a_644, 0D)) - ToNum(GetIdx(o_643, 0D))))), ((V)((ToNum(GetIdx(a_644, 1D)) - ToNum(GetIdx(o_643, 1D))))), ((V)((ToNum(GetIdx(b_645, 0D)) - ToNum(GetIdx(o_643, 0D))))), ((V)((ToNum(GetIdx(b_645, 1D)) - ToNum(GetIdx(o_643, 1D))))), GetIdx(o_643, 0D), GetIdx(o_643, 1D)), "map", n4_43), "join", ((V)(" ")))).S(")").End()));
}, 3, "", true);
plane_45 = Fn((V _arrowThis656, int _argc647, V p_653, V z_654, V y_655, V _a652, V[] _rest648) => {
return Call(mtx_44, V.Undef, Call(p_653, V.Undef, ((V)(0D)), y_655, z_654), Call(p_653, V.Undef, ((V)(1D)), y_655, z_654), Call(p_653, V.Undef, ((V)(0D)), ((V)((ToNum(y_655) - 1D))), z_654));
}, 3, "", true);
planeH_46 = Fn((V _arrowThis665, int _argc657, V p_663, V y_664, V _a661, V _a662, V[] _rest658) => {
return Call(mtx_44, V.Undef, Call(p_663, V.Undef, ((V)(0D)), y_664, ((V)(0D))), Call(p_663, V.Undef, ((V)(1D)), y_664, ((V)(0D))), Call(p_663, V.Undef, ((V)(0D)), y_664, ((V)(1D))));
}, 2, "", true);
bob_47 = Fn((V _arrowThis674, int _argc666, V a_672, V d_673, V _a670, V _a671, V[] _rest667) => {
return Call(at_41, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 ").N((-ToNum(a_672))).S(";0 0").End())), d_673);
}, 2, "", true);
GLOW_48 = ((V)("<filter id=\"gw2\" x=\"-40%\" y=\"-80%\" width=\"180%\" height=\"260%\"><feGaussianBlur stdDeviation=\"1.6\" result=\"b\"/><feMerge><feMergeNode in=\"b\"/><feMergeNode in=\"SourceGraphic\"/></feMerge></filter>"));
hash_49 = Fn((V _arrowThis682, int _argc675, V s_681, V _a678, V _a679, V _a680, V[] _rest676) => {
double h_683 = 0;
h_683 = 7D;
{
foreach (V _k684 in new JsIter(((V)(ToStrS(s_681))))) {
V ch_685 = default;
ch_685 = _k684;
h_683 = ((double)(ToInt32(ToNum(Add(((V)((h_683 * 31D))), Invoke(ch_685, "charCodeAt", ((V)(0D)))))) | ToInt32(0D)));
}
}
return ((V)(System.Math.Abs(h_683)));
return default;
}, 1, "", true);
rng_50 = Fn((V _arrowThis693, int _argc686, V s_692, V _a689, V _a690, V _a691, V[] _rest687) => {
V h_694 = default;
h_694 = (Call(hash_49, V.Undef, s_692) is var _t695 && Truthy(_t695) ? _t695 : ((V)(1D)));
return Fn((V _arrowThis702, int _argc696, V _a698, V _a699, V _a700, V _a701, V[] _rest697) => {
h_694 = ((V)(((double)(ToInt32(((ToNum(h_694) * 1103515245D) + 12345D)) | ToInt32(0D)))));
return ((V)((((double)(ToInt32(((double)(ToUint32(ToNum(h_694)) >> (int)(ToUint32(8D) & 31)))) & ToInt32(65535D))) / 65536D)));
return default;
}, 0, "", true);
return default;
}, 1, "", true);
steam_51 = Fn((V _arrowThis716, int _argc703, V c_709, V x_710, V y_711, V z_712, V[] _rest704) => {
V q_717 = default;
JsStrBuf o_718 = null;
V s_713 = default;
V n_714 = default;
V col_715 = default;
s_713 = (_argc703 > 4 ? _rest704[0] : V.Undef);
n_714 = (_argc703 > 5 ? _rest704[1] : V.Undef);
col_715 = (_argc703 > 6 ? _rest704[2] : V.Undef);
q_717 = Invoke(c_709, "p", x_710, y_711, z_712);
o_718 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_42, V.Undef, q_717)).S(") scale(").V(Call(f1_23, V.Undef, ((V)((ToNum(Get(c_709, "k")) * ToNum((s_713 is var _t719 && Truthy(_t719) ? _t719 : ((V)(1D))))))))).S(")\">").End());
{
double i_720 = 0;
i_720 = 0D;
while (true) {
if (!(Lt(((V)(i_720)), (n_714 is var _t722 && Truthy(_t722) ? _t722 : ((V)(3D)))))) break;
double dx_723 = 0;
dx_723 = ((i_720 - ((ToNum((n_714 is var _t724 && Truthy(_t724) ? _t724 : ((V)(3D)))) - 1D) / 2D)) * 4D);
o_718.S("<path d=\"M").N(dx_723).S(" 0q-3 -5 0 -10t0 -10\" fill=\"none\" stroke=\"").V((col_715 is var _t725 && Truthy(_t725) ? _t725 : ((V)("#ffffff")))).S("\" stroke-width=\"1.5\" stroke-linecap=\"round\" opacity=\"0\">").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0;0.8;0")), ((V)(2.4)), ((V)(((-i_720) * 0.8))))).V(Call(at_41, V.Undef, ((V)("translate")), ((V)("0 0;0 -9")), ((V)(2.4)), ((V)(((-i_720) * 0.8))))).S("</path>");
i_720++;
}
}
return ((V)(string.Concat(o_718.Str, "</g>")));
return default;
}, 7, "", true);
spark_52 = Fn((V _arrowThis740, int _argc726, V c_732, V x_733, V y_734, V z_735, V[] _rest727) => {
V s_736 = default;
V b_737 = default;
V col_738 = default;
V d_739 = default;
s_736 = (_argc726 > 4 ? _rest727[0] : V.Undef);
b_737 = (_argc726 > 5 ? _rest727[1] : V.Undef);
col_738 = (_argc726 > 6 ? _rest727[2] : V.Undef);
d_739 = (_argc726 > 7 ? _rest727[3] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_42, V.Undef, Invoke(c_732, "p", x_733, y_734, z_735))).S(") scale(").V(Call(f1_23, V.Undef, ((V)((ToNum(Get(c_732, "k")) * ToNum((s_736 is var _t741 && Truthy(_t741) ? _t741 : ((V)(1D))))))))).S(")\"><path d=\"M0 -4L1 -1L4 0L1 1L0 4L-1 1L-4 0L-1 -1Z\" fill=\"").V((col_738 is var _t742 && Truthy(_t742) ? _t742 : ((V)("#ffffff")))).S("\" opacity=\"0\">").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0;1;0;0")), (d_739 is var _t743 && Truthy(_t743) ? _t743 : ((V)(1.8))), b_737)).S("</path></g>").End()));
}, 8, "", true);
NEV_53 = Invoke(Invoke(NE_26, "concat", GetIdx(NE_26, 0D)), "join", ((V)(";")));
seatC_54 = Fn((V _arrowThis758, int _argc744, V x_750, V y_751, V z_752, V w_753, V[] _rest745) => {
V h_754 = default;
V d_755 = default;
V col_756 = default;
V o_757 = default;
h_754 = (_argc744 > 4 ? _rest745[0] : V.Undef);
d_755 = (_argc744 > 5 ? _rest745[1] : V.Undef);
col_756 = (_argc744 > 6 ? _rest745[2] : V.Undef);
o_757 = (_argc744 > 7 ? _rest745[3] : V.Undef);
return Call(solid_11, V.Undef, Object_assign(NewObj(10).Put("ax", ((V)("y"))).Put("sh", ((V)("rr"))).Put("c", Arr(x_750, z_752)).Put("a", ((V)((ToNum(w_753) / 2D)))).Put("b", ((V)((ToNum(d_755) / 2D)))).Put("r", ((V)((Min(ToNum(w_753), ToNum(d_755)) * 0.16)))).Put("rings", Arr(Arr(y_751, ((V)(1.6)), ((V)(0.97))), Arr(Add(y_751, ((V)(1.6))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(Add(y_751, h_754)) - 3.2))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(Add(y_751, h_754)) - 1D))), ((V)(1.6)), ((V)(0.99))), Arr(Add(y_751, h_754), ((V)(4.5)), ((V)(0.96))), Arr(Add(Add(y_751, h_754), ((V)(1.4))), ((V)(11D)), ((V)(0.88))))).Put("col", col_756).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V, (o_757 is var _t759 && Truthy(_t759) ? _t759 : NewObj(0).V)));
}, 8, "", true);
backC_55 = Fn((V _arrowThis774, int _argc760, V x_766, V y0_767, V y1_768, V z0_769, V[] _rest761) => {
double h_775 = 0;
V z1_770 = default;
V w_771 = default;
V col_772 = default;
V o_773 = default;
z1_770 = (_argc760 > 4 ? _rest761[0] : V.Undef);
w_771 = (_argc760 > 5 ? _rest761[1] : V.Undef);
col_772 = (_argc760 > 6 ? _rest761[2] : V.Undef);
o_773 = (_argc760 > 7 ? _rest761[3] : V.Undef);
h_775 = (ToNum(y1_768) - ToNum(y0_767));
return Call(solid_11, V.Undef, Object_assign(NewObj(10).Put("ax", ((V)("z"))).Put("sh", ((V)("rr"))).Put("c", Arr(x_766, Add(y0_767, ((V)((h_775 / 2D)))))).Put("a", ((V)((ToNum(w_771) / 2D)))).Put("b", ((V)((h_775 / 2D)))).Put("r", ((V)((Min(ToNum(w_771), h_775) * 0.2)))).Put("rings", Arr(Arr(z0_769, ((V)(0D)), ((V)(0.98))), Arr(((V)((ToNum(z1_770) - 3.5))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(z1_770) - 1.2))), ((V)(1.6)), ((V)(0.99))), Arr(z1_770, ((V)(4.5)), ((V)(0.95))), Arr(Add(z1_770, ((V)(1.6))), ((V)(10D)), ((V)(0.86))))).Put("col", col_772).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V, (o_773 is var _t776 && Truthy(_t776) ? _t776 : NewObj(0).V)));
return default;
}, 8, "", true);
throwP_56 = Fn((V _arrowThis789, int _argc777, V x_783, V y_784, V z_785, V s_786, V[] _rest778) => {
V col_787 = default;
V o_788 = default;
col_787 = (_argc777 > 4 ? _rest778[0] : V.Undef);
o_788 = (_argc777 > 5 ? _rest778[1] : V.Undef);
return Call(solid_11, V.Undef, Object_assign(NewObj(10).Put("ax", ((V)("z"))).Put("sh", ((V)("rr"))).Put("c", Arr(x_783, Add(y_784, ((V)((ToNum(s_786) / 2D)))))).Put("a", ((V)((ToNum(s_786) / 2D)))).Put("b", ((V)((ToNum(s_786) / 2D)))).Put("r", ((V)((ToNum(s_786) * 0.3)))).Put("rings", Arr(Arr(((V)((ToNum(z_785) - 4.5))), ((V)(4D)), ((V)(0.82))), Arr(((V)((ToNum(z_785) - 2.6))), ((V)(1D)), ((V)(0.97))), Arr(z_785, ((V)(0D)), ((V)(1D))), Arr(Add(z_785, ((V)(2.6))), ((V)(1D)), ((V)(0.97))), Arr(Add(z_785, ((V)(4.5))), ((V)(4D)), ((V)(0.82))))).Put("col", col_787).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V, (o_788 is var _t790 && Truthy(_t790) ? _t790 : NewObj(0).V)));
}, 6, "", true);
Set(N_24, "rsofa", Fn((V _arrowThis798, int _argc791, V S_797, V _a794, V _a795, V _a796, V[] _rest792) => {
V nm_799 = default;
V k_800 = default;
V v_801 = default;
V shp_802 = default;
V n_803 = default;
V fl_804 = default;
V met_805 = default;
double SW_806 = 0;
double AW_807 = 0;
double Dp_808 = 0;
double ext_809 = 0;
double by_810 = 0;
V wing_811 = default;
V tuft_812 = default;
V anim_813 = default;
V pad_814 = default;
double DK_815 = 0;
double SH_816 = 0;
double top_817 = 0;
double bz0_818 = 0;
double bz1_819 = 0;
double cz1_820 = 0;
double fr_821 = 0;
double frC_822 = 0;
double bh_823 = 0;
V cols_824 = default;
double Wd_825 = 0;
V xs_826 = default;
V eL_827 = default;
V eR_828 = default;
V chaise_829 = default;
V seats_830 = default;
V parts_831 = default;
nm_799 = Get(S_797, "nm");
k_800 = Get(S_797, "k");
v_801 = Get(S_797, "v");
shp_802 = (Get(S_797, "shape") is var _t835 && Truthy(_t835) ? _t835 : ((V)((Truthy(((SEqS(v_801, "L") ? V.True : V.False) is var _t834 && Truthy(_t834) ? _t834 : Invoke(NewRegExp(RX4, "l-shaped|sectional|banquette", ""), "test", nm_799))) ? "L" : (Truthy(((SEqS(v_801, "U") ? V.True : V.False) is var _t833 && Truthy(_t833) ? _t833 : Invoke(NewRegExp(RX3, "horseshoe|u-shaped|booth", ""), "test", nm_799))) ? "U" : (Truthy(((SEqS(v_801, "pit") ? V.True : V.False) is var _t832 && Truthy(_t832) ? _t832 : Invoke(NewRegExp(RX2, "pit sofa|curved|conversation", ""), "test", nm_799))) ? "pit" : ""))))));
n_803 = (Get(S_797, "n") is var _t836 && Truthy(_t836) ? _t836 : ((V)((SEqS(v_801, "1") ? 1D : (Truthy(Invoke(NewRegExp(RX5, "two-seater|loveseat|2-seat|pair|bench", ""), "test", nm_799)) ? 2D : (SEqS(shp_802, "L") ? 4D : (Truthy(shp_802) ? 5D : 3D)))))));
if (SEqN(n_803, 1D)) {
shp_802 = ((V)(""));
}
if ((SEqS(shp_802, "L") && LtN(n_803, 3D))) {
n_803 = ((V)(3D));
}
if ((SEqS(shp_802, "U") && LtN(n_803, 4D))) {
n_803 = ((V)(4D));
}
fl_804 = (Get(S_797, "float") is var _t837 && Truthy(_t837) ? _t837 : Invoke(NewRegExp(RX6, "levitat|floating|anti-grav|zero-g|hover", ""), "test", nm_799));
met_805 = Call(metal_33, V.Undef, k_800);
SW_806 = 58D;
AW_807 = (SEqN(n_803, 1D) ? 18D : 20D);
Dp_808 = 88D;
ext_809 = 62D;
by_810 = (9D + (Truthy(fl_804) ? 14D : 0D));
wing_811 = Invoke(NewRegExp(RX7, "wingback|throne", ""), "test", nm_799);
tuft_812 = (((SEqS(k_800, "royal") || SEqS(k_800, "cot")) ? V.True : V.False) is var _t838 && Truthy(_t838) ? _t838 : Invoke(NewRegExp(RX8, "tufted|chesterfield|wingback", ""), "test", nm_799));
anim_813 = (Truthy(fl_804) ? Call(bob_47, V.Undef, ((V)(5D)), ((V)(3.2))) : ((V)("")));
pad_814 = (Truthy(fl_804) ? Arr(((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(0D))) : V.Null);
if (SEqS(shp_802, "pit")) {
return Call(pitSofa_57, V.Undef, S_797, n_803, fl_804, met_805, ((V)(by_810)), anim_813, pad_814);
}
DK_815 = 12D;
SH_816 = 15D;
top_817 = ((by_810 + DK_815) + SH_816);
bz0_818 = (((-Dp_808) / 2D) + 2D);
bz1_819 = (bz0_818 + 13D);
cz1_820 = (bz1_819 + 12D);
fr_821 = ((Dp_808 / 2D) - 3D);
frC_822 = (((Dp_808 / 2D) + ext_809) - 3D);
bh_823 = (Truthy(wing_811) ? 60D : (SEqS(k_800, "mod") ? 40D : 48D));
cols_824 = (SEqS(shp_802, "L") ? ((V)((ToNum(n_803) - 1D))) : (SEqS(shp_802, "U") ? ((V)((ToNum(n_803) - 2D))) : n_803));
Wd_825 = ((ToNum(cols_824) * SW_806) + (AW_807 * 2D));
xs_826 = Call(rep_39, V.Undef, cols_824, Fn((V _arrowThis846, int _argc839, V i_845, V _a842, V _a843, V _a844, V[] _rest840) => {
return ((V)(((((-Wd_825) / 2D) + AW_807) + (SW_806 * ToNum(Add(i_845, ((V)(0.5))))))));
}, 1, "", true));
eL_827 = ((SEqS(shp_802, "L") || SEqS(shp_802, "U")) ? V.True : V.False);
eR_828 = (SEqS(shp_802, "U") ? V.True : V.False);
chaise_829 = Fn((V _arrowThis854, int _argc847, V i_853, V _a850, V _a851, V _a852, V[] _rest848) => {
return ((eL_827 is var _t855 && !Truthy(_t855) ? _t855 : (SEqN(i_853, 0D) ? V.True : V.False)) is var _t857 && Truthy(_t857) ? _t857 : (eR_828 is var _t856 && !Truthy(_t856) ? _t856 : (SEqN(i_853, (ToNum(cols_824) - 1D)) ? V.True : V.False)));
}, 1, "", true);
seats_830 = Arr();
Invoke(xs_826, "forEach", Fn((V _arrowThis866, int _argc858, V x_864, V i_865, V _a862, V _a863, V[] _rest859) => {
Invoke(seats_830, "push", NewObj(3).Put("x", x_864).Put("z", ((V)(((cz1_820 + fr_821) / 2D)))).Put("h", ((V)((top_817 + 2D)))).V);
if (Truthy(Call(chaise_829, V.Undef, i_865))) {
Invoke(seats_830, "push", NewObj(3).Put("x", x_864).Put("z", ((V)(((Dp_808 / 2D) + (ext_809 / 2D))))).Put("h", ((V)((top_817 + 2D)))).V);
}
return default;
}, 2, "", true));
parts_831 = Fn((V _arrowThis874, int _argc867, V P_873, V _a870, V _a871, V _a872, V[] _rest868) => {
V o_875 = default;
V bk_876 = default;
V fab_877 = default;
V fL_878 = default;
V fD_879 = default;
double xl_880 = 0;
double xr_881 = 0;
double ze_882 = 0;
V acc_883 = default;
V spans_884 = default;
V ma_885 = default;
double mb_886 = 0;
V on_887 = default;
V mdk_888 = default;
o_875 = Arr();
bk_876 = Arr();
fab_877 = Get(P_873, "a");
fL_878 = Get(P_873, "aL");
fD_879 = Get(P_873, "aD");
xl_880 = (((-Wd_825) / 2D) + AW_807);
xr_881 = ((Wd_825 / 2D) - AW_807);
ze_882 = (((Dp_808 / 2D) + ext_809) - 2D);
acc_883 = (SEqS(k_800, "royal") ? ((V)("#e9c66a")) : (SEqS(k_800, "junk") ? ((V)("#c9b48a")) : (SEqS(k_800, "mod") ? ((V)("#d9c7a4")) : Call(mix_22, V.Undef, (Get(P_873, "b") is var _t889 && Truthy(_t889) ? _t889 : ((V)("#e9d9b0"))), ((V)("#ffffff")), ((V)(0.35))))));
if (!(Truthy(fl_804))) {
double lx_890 = 0;
double lz_891 = 0;
V L_892 = default;
lx_890 = ((Wd_825 / 2D) - 7D);
lz_891 = ((Dp_808 / 2D) - 9D);
L_892 = Arr(Arr(((V)((-lx_890))), ((V)((-lz_891)))), Arr(((V)(lx_890)), ((V)((-lz_891)))), Arr(((V)((-lx_890))), ((V)(lz_891))), Arr(((V)(lx_890)), ((V)(lz_891))));
if (Truthy(eL_827)) {
Invoke(L_892, "push", Arr(((V)((-lx_890))), ((V)((lz_891 + ext_809)))));
}
if (Truthy(eR_828)) {
Invoke(L_892, "push", Arr(((V)(lx_890)), ((V)((lz_891 + ext_809)))));
}
if ((Wd_825 > 200D)) {
Invoke(L_892, "push", Arr(((V)(0D)), ((V)((-lz_891)))), Arr(((V)(0D)), ((V)(lz_891))));
}
Invoke(L_892, "forEach", Fn((V _arrowThis904, int _argc893, V _a895, V _a896, V _a897, V _a898, V[] _rest894) => {
V x_901 = default;
V z_903 = default;
{ V _t899 = ListOf(_a895);
{ V _t900 = GetIdx(_t899, 0D);
x_901 = _t900; }
{ V _t902 = GetIdx(_t899, 1D);
z_903 = _t902; }
}
return Invoke(o_875, "push", (SEqS(k_800, "royal") ? Call(ball_15, V.Undef, x_901, ((V)(0D)), z_903, ((V)(4.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)) : Call(cyl_14, V.Undef, x_901, ((V)(0D)), z_903, ((V)(2.6)), ((V)((by_810 - 3D))), met_805, Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.65))), Arr(((V)((by_810 - 3D))), ((V)(0D)), ((V)(1.1))))).V))));
}, 1, "", true));
} else {
Invoke(o_875, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)((by_810 - 7D))), ((V)(0D)), ((V)(((Wd_825 / 2D) - 16D))), ((V)(2D)), ((V)("#8fe8ff")), Call(em_25, V.Undef, NewObj(3).Put("rz", ((V)(((Dp_808 / 2D) - 14D)))).Put("op", ((V)(0.55))).Put("n", ((V)(20D))).V)));
}
spans_884 = Arr();
ma_885 = ((V)(xl_880));
mb_886 = xr_881;
if (Truthy(eL_827)) {
Invoke(spans_884, "push", Arr(((V)(xl_880)), Add(GetIdx(xs_826, 0D), ((V)((SW_806 / 2D)))), ((V)(ze_882))));
ma_885 = Add(GetIdx(xs_826, 0D), ((V)((SW_806 / 2D))));
}
if (Truthy(eR_828)) {
Invoke(spans_884, "push", Arr(((V)((ToNum(GetIdx(xs_826, (ToNum(cols_824) - 1D))) - (SW_806 / 2D)))), ((V)(xr_881)), ((V)(ze_882))));
mb_886 = (ToNum(GetIdx(xs_826, (ToNum(cols_824) - 1D))) - (SW_806 / 2D));
}
if (((mb_886 - ToNum(ma_885)) > 1D)) {
Invoke(spans_884, "push", Arr(ma_885, ((V)(mb_886)), ((V)(((Dp_808 / 2D) - 2D)))));
}
on_887 = Fn((V _arrowThis914, int _argc905, V p_911, V S_912, V fn_913, V _a910, V[] _rest906) => {
Set(S_912, "par", p_911);
if (Truthy(fn_913)) {
Set(S_912, "fn", fn_913);
}
return S_912;
return default;
}, 3, "", true);
mdk_888 = V.Null;
Invoke(spans_884, "forEach", Fn((V _arrowThis928, int _argc915, V _a917, V _a918, V _a919, V _a920, V[] _rest916) => {
V dk_929 = default;
V rl_930 = default;
V a_923 = default;
V b_925 = default;
V zf_927 = default;
{ V _t921 = ListOf(_a917);
{ V _t922 = GetIdx(_t921, 0D);
a_923 = _t922; }
{ V _t924 = GetIdx(_t921, 1D);
b_925 = _t924; }
{ V _t926 = GetIdx(_t921, 2D);
zf_927 = _t926; }
}
dk_929 = Call(box_12, V.Undef, ((V)((ToNum(Add(a_923, b_925)) / 2D))), ((V)(by_810)), ((V)((ToNum(Add(((V)(bz1_819)), zf_927)) / 2D))), ((V)((ToNum(b_925) - ToNum(a_923)))), ((V)(DK_815)), ((V)((ToNum(zf_927) - bz1_819))), fD_879, NewObj(4).Put("r", ((V)(3D))).Put("bev", ((V)(2D))).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V);
rl_930 = Call(box_12, V.Undef, ((V)((ToNum(Add(a_923, b_925)) / 2D))), ((V)((by_810 - 3D))), ((V)((ToNum(Add(((V)(bz0_818)), zf_927)) / 2D))), ((V)((ToNum(b_925) - ToNum(a_923)))), ((V)(3D)), ((V)((ToNum(zf_927) - bz0_818))), met_805, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V));
Invoke(o_875, "push", rl_930, Call(on_887, V.Undef, rl_930, dk_929));
if (SEqN(zf_927, ((Dp_808 / 2D) - 2D))) {
mdk_888 = dk_929;
}
return default;
}, 1, "", true));
Invoke(bk_876, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)(by_810)), ((V)(((bz0_818 + bz1_819) / 2D))), ((V)((xr_881 - xl_880))), ((V)((DK_815 + bh_823))), ((V)((bz1_819 - bz0_818))), fab_877, NewObj(4).Put("r", ((V)((SEqS(k_800, "mod") ? 6D : 10D)))).Put("rb", ((V)(0D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(xs_826, "forEach", Fn((V _arrowThis939, int _argc931, V x_937, V i_938, V _a935, V _a936, V[] _rest932) => {
V bc_940 = default;
double zf_941 = 0;
bc_940 = Call(backC_55, V.Undef, x_937, ((V)((by_810 + DK_815))), ((V)((((by_810 + DK_815) + bh_823) - 3D))), ((V)(bz1_819)), ((V)(cz1_820)), ((V)((SW_806 - 3D))), fL_878);
Invoke(o_875, "push", bc_940);
if (Truthy(tuft_812)) {
Invoke(Arr(((V)((-14D))), ((V)(0D)), ((V)(14D))), "forEach", Fn((V _arrowThis949, int _argc942, V t_948, V _a945, V _a946, V _a947, V[] _rest943) => {
return Invoke(o_875, "push", Call(on_887, V.Undef, bc_940, Call(ball_15, V.Undef, Add(x_937, t_948), ((V)(((by_810 + DK_815) + ((bh_823 - 3D) * 0.62)))), ((V)((cz1_820 + 0.8))), ((V)(1.5)), (SEqS(k_800, "royal") ? GOLD_27 : Call(shade_21, V.Undef, fab_877, ((V)(0.68)))), Call(mt_34, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))));
}, 1, "", true));
}
zf_941 = (Truthy(Call(chaise_829, V.Undef, i_938)) ? frC_822 : fr_821);
Invoke(o_875, "push", Call(seatC_54, V.Undef, x_937, ((V)((by_810 + DK_815))), ((V)(((cz1_820 + zf_941) / 2D))), ((V)((SW_806 - 3D))), ((V)(SH_816)), ((V)((zf_941 - cz1_820))), fL_878));
return default;
}, 2, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis957, int _argc950, V sg_956, V _a953, V _a954, V _a955, V[] _rest951) => {
V e_958 = default;
double z0_959 = 0;
double z1_960 = 0;
double x_961 = 0;
double ah_962 = 0;
V t_963 = default;
V ab_964 = default;
e_958 = (LtN(sg_956, 0D) ? eL_827 : eR_828);
z0_959 = bz0_818;
z1_960 = (Truthy(e_958) ? ze_882 : ((Dp_808 / 2D) - 2D));
x_961 = (ToNum(sg_956) * ((Wd_825 / 2D) - (AW_807 / 2D)));
ah_962 = (Truthy(wing_811) ? 40D : 32D);
t_963 = (LtN(sg_956, 0D) ? bk_876 : o_875);
ab_964 = Call(box_12, V.Undef, ((V)(x_961)), ((V)((by_810 - 3D))), ((V)(((z0_959 + z1_960) / 2D))), ((V)(AW_807)), ((V)((ah_962 - 4D))), ((V)((z1_960 - z0_959))), fab_877, NewObj(3).Put("r", ((V)(6D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V);
Invoke(t_963, "push", ab_964, Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(x_961)), ((V)((by_810 + ah_962))))).Put("a", ((V)(((AW_807 / 2D) + 2D)))).Put("b", ((V)(7D))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)(z0_959)), ((V)(2.5)), ((V)(0.85))), Arr(((V)((z0_959 + 2.5))), ((V)(0D))), Arr(((V)((z1_960 - 2.5))), ((V)(0D))), Arr(((V)(z1_960)), ((V)(2.5)), ((V)(0.85))))).Put("col", fab_877).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(on_887, V.Undef, ab_964, Call(disc_19, V.Undef, ((V)(x_961)), ((V)((by_810 + (ah_962 * 0.45)))), ((V)((z1_960 + 0.2))), ((V)(((AW_807 / 2D) - 3D))), ((V)(1.4)), met_805, Call(mt_34, V.Undef)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))));
if (Truthy(wing_811)) {
Invoke(t_963, "push", Call(slab_16, V.Undef, ((V)(x_961)), ((V)(((by_810 + ah_962) + 7D))), ((V)((bz0_818 + 9D))), ((V)(AW_807)), ((V)(26D)), ((V)(14D)), fab_877, NewObj(3).Put("r", ((V)(12D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
}
return default;
}, 1, "", true));
if (GeN(n_803, 2D)) {
Invoke(o_875, "push", Call(throwP_56, V.Undef, ((V)(((ToNum(GetIdx(xs_826, 0D)) - (SW_806 / 2D)) + 15D))), ((V)((top_817 - 2D))), ((V)((cz1_820 + 5D))), ((V)((SEqS(k_800, "junk") ? 21D : 24D))), acc_883));
if (!SEqS(k_800, "junk")) {
Invoke(o_875, "push", Call(throwP_56, V.Undef, ((V)((ToNum(Add(GetIdx(xs_826, (ToNum(cols_824) - 1D)), ((V)((SW_806 / 2D))))) - 15D))), ((V)((top_817 - 2D))), ((V)((cz1_820 + 5D))), ((V)(24D)), Call(shade_21, V.Undef, acc_883, ((V)(0.9)))));
}
}
if (((mb_886 - ToNum(ma_885)) > 1D)) {
V sx_965 = default;
sx_965 = Call(slabX_17, V.Undef, ((V)((ToNum(Add(ma_885, ((V)(mb_886)))) / 2D))), ((V)((by_810 + 1D))), ((V)(((Dp_808 / 2D) - 1.6))), ((V)((mb_886 - ToNum(ma_885)))), ((V)(2D)), ((V)(1.4)), met_805, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V));
Invoke(o_875, "push", (Truthy(mdk_888) ? Call(on_887, V.Undef, mdk_888, sx_965, Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))) : sx_965));
}
return NewObj(2).Put("o", o_875).Put("bk", bk_876).V;
return default;
}, 1, "", true);
return NewObj(8).Put("w", ((V)(Wd_825))).Put("d", ((V)((Dp_808 + (Truthy(eL_827) ? ext_809 : 0D))))).Put("act", ((V)("sit"))).Put("seats", seats_830).Put("anim", anim_813).Put("pad", pad_814).Put("layers", Arr(NewObj(2).Put("back", ((V)(1D))).Put("build", Fn((V _arrowThis973, int _argc966, V P_972, V _a969, V _a970, V _a971, V[] _rest967) => {
return Get(Call(parts_831, V.Undef, P_972), "bk");
}, 1, "build", true)).V)).Put("build", Fn((V _arrowThis981, int _argc974, V P_980, V _a977, V _a978, V _a979, V[] _rest975) => {
return Get(Call(parts_831, V.Undef, P_980), "o");
}, 1, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "luxSofa", Fn((V _arrowThis989, int _argc982, V S_988, V _a985, V _a986, V _a987, V[] _rest983) => {
V n_990 = default;
V st_991 = default;
V gold_992 = default;
V legc_993 = default;
double SW_994 = 0;
double AW_995 = 0;
double Dp_996 = 0;
double Wd_997 = 0;
double by_998 = 0;
V xs_999 = default;
double ah_1000 = 0;
double bh_1001 = 0;
double bz_1002 = 0;
V brass_1003 = default;
double bf_1004 = 0;
double cz_1005 = 0;
double cd_1006 = 0;
double cf_1007 = 0;
double st0_1008 = 0;
n_990 = (Get(S_988, "n") is var _t1009 && Truthy(_t1009) ? _t1009 : ((V)(3D)));
st_991 = (Get(S_988, "st") is var _t1010 && Truthy(_t1010) ? _t1010 : ((V)("chester")));
gold_992 = (!(!(Truthy(Get(S_988, "gold")))) ? V.True : V.False);
legc_993 = (Truthy(gold_992) ? GOLD_27 : (Get(S_988, "wood") is var _t1011 && Truthy(_t1011) ? _t1011 : ((V)("#4a2c1a"))));
SW_994 = 56D;
AW_995 = 24D;
Dp_996 = 88D;
Wd_997 = ((ToNum(n_990) * SW_994) + (AW_995 * 2D));
by_998 = 16D;
xs_999 = Call(rep_39, V.Undef, n_990, Fn((V _arrowThis1019, int _argc1012, V i_1018, V _a1015, V _a1016, V _a1017, V[] _rest1013) => {
return ((V)(((((-Wd_997) / 2D) + AW_995) + (SW_994 * ToNum(Add(i_1018, ((V)(0.5))))))));
}, 1, "", true));
ah_1000 = (SEqS(st_991, "chester") ? 40D : 30D);
bh_1001 = (SEqS(st_991, "chester") ? 40D : 54D);
bz_1002 = (((-Dp_996) / 2D) + 9D);
brass_1003 = (gold_992 is var _t1020 && Truthy(_t1020) ? _t1020 : Get(S_988, "brass"));
bf_1004 = (SEqS(st_991, "chester") ? (bz_1002 + 8D) : (bz_1002 + 13D));
cz_1005 = (((bf_1004 + (Dp_996 / 2D)) - 4D) / 2D);
cd_1006 = (((Dp_996 / 2D) - 4D) - bf_1004);
cf_1007 = (cz_1005 + (cd_1006 / 2D));
st0_1008 = (by_998 + 30D);
return NewObj(5).Put("w", ((V)((Wd_997 + 8D)))).Put("d", ((V)(Dp_996))).Put("act", ((V)("sit"))).Put("seats", Invoke(xs_999, "map", Fn((V _arrowThis1028, int _argc1021, V x_1027, V _a1024, V _a1025, V _a1026, V[] _rest1022) => {
return NewObj(3).Put("x", x_1027).Put("z", ((V)(cz_1005))).Put("h", ((V)((st0_1008 + 1D)))).V;
}, 1, "", true))).Put("build", Fn((V _arrowThis1036, int _argc1029, V P_1035, V _a1032, V _a1033, V _a1034, V[] _rest1030) => {
V o_1037 = default;
V fab_1038 = default;
V fL_1039 = default;
V fD_1040 = default;
V pip_1041 = default;
V plc_1042 = default;
V lm_1043 = default;
V pil_1044 = default;
V thr_1045 = default;
o_1037 = Arr();
fab_1038 = Get(P_1035, "a");
fL_1039 = Call(shade_21, V.Undef, fab_1038, ((V)(1.07)));
fD_1040 = Call(shade_21, V.Undef, fab_1038, ((V)(0.82)));
pip_1041 = (Truthy(brass_1003) ? GOLD_27 : Call(shade_21, V.Undef, fab_1038, ((V)(0.68))));
plc_1042 = Get(S_988, "plinth");
lm_1043 = (Truthy(gold_992) ? Call(mt_34, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V) : NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("mat", ((V)("wood"))).V);
pil_1044 = (Get(S_988, "pil") is var _t1046 && Truthy(_t1046) ? _t1046 : ((V)((Truthy(Invoke(NewRegExp(RX9, "^#(e|f|d)", "i"), "test", fab_1038)) ? "#8a6a48" : "#e9d9b0"))));
thr_1045 = ((V)((Truthy(Invoke(NewRegExp(RX10, "^#(e|f)", "i"), "test", fab_1038)) ? "#6b4426" : "#efe4cc")));
if (Truthy(plc_1042)) {
V R_1047 = default;
Invoke(o_1037, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((Wd_997 - 8D))), ((V)((by_998 - 2D))), ((V)((Dp_996 - 10D))), plc_1042, NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("cer"))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)((by_998 - 2.4))), ((V)(0D)), ((V)((Wd_997 - 7D))), ((V)(1.2)), ((V)((Dp_996 - 9D))), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)));
R_1047 = Call(rng_50, V.Undef, Get(S_988, "nm"));
Call(rep_39, V.Undef, ((V)(6D)), Fn((V _arrowThis1054, int _argc1048, V _a1050, V _a1051, V _a1052, V _a1053, V[] _rest1049) => {
return Invoke(o_1037, "push", Call(box_12, V.Undef, ((V)(((ToNum(Call(R_1047, V.Undef)) - 0.5) * (Wd_997 - 30D)))), ((V)(((by_998 - 6D) - (ToNum(Call(R_1047, V.Undef)) * 6D)))), ((V)(((Dp_996 / 2D) - 4.9))), ((V)((18D + (ToNum(Call(R_1047, V.Undef)) * 20D)))), ((V)(0.6)), ((V)(0.2)), ((V)("#c9b98a")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 0, "", true));
} else {
double lx_1055 = 0;
double lz_1056 = 0;
V L_1057 = default;
double nb_1058 = 0;
lx_1055 = ((Wd_997 / 2D) - 9D);
lz_1056 = ((Dp_996 / 2D) - 11D);
L_1057 = Arr(Arr(((V)((-lx_1055))), ((V)((-lz_1056)))), Arr(((V)(lx_1055)), ((V)((-lz_1056)))), Arr(((V)((-lx_1055))), ((V)(lz_1056))), Arr(((V)(lx_1055)), ((V)(lz_1056))));
if (GeN(n_990, 4D)) {
Invoke(L_1057, "push", Arr(((V)(0D)), ((V)(lz_1056))), Arr(((V)(0D)), ((V)((-lz_1056)))));
}
Invoke(L_1057, "forEach", Fn((V _arrowThis1070, int _argc1059, V _a1061, V _a1062, V _a1063, V _a1064, V[] _rest1060) => {
V x_1067 = default;
V z_1069 = default;
{ V _t1065 = ListOf(_a1061);
{ V _t1066 = GetIdx(_t1065, 0D);
x_1067 = _t1066; }
{ V _t1068 = GetIdx(_t1065, 1D);
z_1069 = _t1068; }
}
return Invoke(o_1037, "push", Call(ball_15, V.Undef, x_1067, ((V)(2.4)), z_1069, ((V)(3.6)), legc_993, (Truthy(gold_992) ? Call(mt_34, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V) : NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("mat", ((V)("wood"))).V)), Call(cyl_14, V.Undef, x_1067, ((V)(4D)), z_1069, ((V)(3D)), ((V)((by_998 - 8D))), legc_993, Object_assign(NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(((by_998 - 8D) * 0.5))), ((V)(0D)), ((V)(1.15))), Arr(((V)((by_998 - 8D))), ((V)(0D)), ((V)(0.8))))).V, (Truthy(gold_992) ? NewObj(1).Put("mat", ((V)("metal"))).V : NewObj(1).Put("mat", ((V)("wood"))).V))), Call(cyl_14, V.Undef, x_1067, ((V)(0D)), z_1069, ((V)(2.6)), ((V)(1.4)), (Truthy(brass_1003) ? GOLD_27 : ((V)("#2a1a10"))), Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
Invoke(o_1037, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((by_998 - 6D))), ((V)(0D)), ((V)((Wd_997 - 6D))), ((V)(5D)), ((V)((Dp_996 - 8D))), legc_993, (Truthy(gold_992) ? Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(3D))).V) : NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("wood"))).V)));
nb_1058 = System.Math.Floor(((Wd_997 - 16D) / 7D));
Call(rep_39, V.Undef, ((V)(nb_1058)), Fn((V _arrowThis1078, int _argc1071, V i_1077, V _a1074, V _a1075, V _a1076, V[] _rest1072) => {
return Invoke(o_1037, "push", Call(ball_15, V.Undef, ((V)(((((-Wd_997) / 2D) + 8D) + ((ToNum(Add(i_1077, ((V)(0.5)))) * (Wd_997 - 16D)) / nb_1058)))), ((V)((by_998 - 4.8))), ((V)(((Dp_996 / 2D) - 3.6))), ((V)(1.3)), (Truthy(gold_992) ? GOLD_27 : Call(shade_21, V.Undef, legc_993, ((V)(1.25)))), Object_assign(NewObj(2).Put("sz", ((V)(0.6))).Put("noOut", ((V)(1D))).V, lm_1043)));
}, 1, "", true));
Invoke(o_1037, "push", Call(ball_15, V.Undef, ((V)(0D)), ((V)((by_998 - 5D))), ((V)(((Dp_996 / 2D) - 3.2))), ((V)(4.2)), (Truthy(gold_992) ? GOLD_27 : Call(shade_21, V.Undef, legc_993, ((V)(1.2)))), Object_assign(NewObj(2).Put("sy", ((V)(0.7))).Put("sz", ((V)(0.5))).V, lm_1043)));
if (Truthy(gold_992)) {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1086, int _argc1079, V sg_1085, V _a1082, V _a1083, V _a1084, V[] _rest1080) => {
return Invoke(o_1037, "push", Call(ball_15, V.Undef, ((V)((ToNum(sg_1085) * 14D))), ((V)((by_998 - 5D))), ((V)(((Dp_996 / 2D) - 3.4))), ((V)(2.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(4).Put("sy", ((V)(0.6))).Put("sz", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
}, 1, "", true));
}
}
Invoke(o_1037, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(by_998)), ((V)((((bf_1004 + (Dp_996 / 2D)) - 3D) / 2D))), ((V)((Wd_997 - (AW_995 * 2D)))), ((V)(16D)), ((V)((((Dp_996 / 2D) - 3D) - bf_1004))), fD_1040, NewObj(3).Put("r", ((V)(4D))).Put("bev", ((V)(3D))).Put("mat", ((V)("fab"))).V), Call(slabX_17, V.Undef, ((V)(0D)), ((V)((by_998 + 0.6))), ((V)(((Dp_996 / 2D) - 2.6))), ((V)((Wd_997 - 10D))), ((V)(1.6)), ((V)(1.6)), pip_1041, (Truthy(brass_1003) ? Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V) : NewObj(2).Put("r", ((V)(0.8))).Put("mat", ((V)("fab"))).V)));
if (Truthy(brass_1003)) {
double nn_1087 = 0;
nn_1087 = System.Math.Floor(((Wd_997 - 20D) / 5D));
Call(rep_39, V.Undef, ((V)(nn_1087)), Fn((V _arrowThis1095, int _argc1088, V i_1094, V _a1091, V _a1092, V _a1093, V[] _rest1089) => {
return Invoke(o_1037, "push", Call(ball_15, V.Undef, ((V)(((((-Wd_997) / 2D) + 10D) + ((ToNum(Add(i_1094, ((V)(0.5)))) * (Wd_997 - 20D)) / nn_1087)))), ((V)((by_998 + 4D))), ((V)(((Dp_996 / 2D) - 2D))), ((V)(0.95)), GOLD_27, Call(mt_34, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
}
Invoke(xs_999, "forEach", Fn((V _arrowThis1103, int _argc1096, V x_1102, V _a1099, V _a1100, V _a1101, V[] _rest1097) => {
Invoke(o_1037, "push", Call(seatC_54, V.Undef, x_1102, ((V)((by_998 + 16D))), ((V)(cz_1005)), ((V)((SW_994 - 3D))), ((V)(14D)), ((V)(cd_1006)), fL_1039));
Invoke(Arr(((V)((by_998 + 17D))), ((V)((by_998 + 28.2)))), "forEach", Fn((V _arrowThis1111, int _argc1104, V y_1110, V _a1107, V _a1108, V _a1109, V[] _rest1105) => {
return Invoke(o_1037, "push", Call(slabX_17, V.Undef, x_1102, y_1110, ((V)((cf_1007 + 0.2))), ((V)((SW_994 - 9D))), ((V)(1.1)), ((V)(1.1)), pip_1041, (Truthy(brass_1003) ? Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("noOut", ((V)(1D))).V) : NewObj(3).Put("r", ((V)(0.5))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
if (SEqS(st_991, "chester")) {
Invoke(o_1037, "push", Call(ball_15, V.Undef, x_1102, ((V)((st0_1008 + 0.6))), ((V)((cz_1005 + 2D))), ((V)(1.6)), (Truthy(brass_1003) ? GOLD_27 : Call(shade_21, V.Undef, fab_1038, ((V)(0.6)))), Call(mt_34, V.Undef, NewObj(4).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V)));
}
return default;
}, 1, "", true));
Invoke(o_1037, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)(by_998)), ((V)(bz_1002)), ((V)((Wd_997 - (AW_995 * 2D)))), ((V)((12D + bh_1001))), ((V)(16D)), fab_1038, NewObj(4).Put("r", ((V)((SEqS(st_991, "chester") ? 6D : 14D)))).Put("rb", ((V)(0D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
if (SEqS(st_991, "chester")) {
double rows_1112 = 0;
double cols_1113 = 0;
rows_1112 = 3D;
cols_1113 = ((ToNum(n_990) * 3D) + 1D);
Call(rep_39, V.Undef, ((V)(rows_1112)), Fn((V _arrowThis1121, int _argc1114, V j_1120, V _a1117, V _a1118, V _a1119, V[] _rest1115) => {
return Call(rep_39, V.Undef, ((V)((cols_1113 - (ToNum(j_1120) % 2D)))), Fn((V _arrowThis1129, int _argc1122, V i_1128, V _a1125, V _a1126, V _a1127, V[] _rest1123) => {
double x_1130 = 0;
double y_1131 = 0;
x_1130 = ((((-Wd_997) / 2D) + AW_995) + (((Wd_997 - (AW_995 * 2D)) * ToNum(Add(i_1128, ((V)((NumTruthy((ToNum(j_1120) % 2D)) ? 1D : 0.5)))))) / cols_1113));
y_1131 = ((by_998 + 34D) + (ToNum(j_1120) * 9D));
Invoke(o_1037, "push", Call(ball_15, V.Undef, ((V)(x_1130)), ((V)(y_1131)), ((V)((bz_1002 + 8.1))), ((V)(3.6)), Call(shade_21, V.Undef, fab_1038, ((V)(0.8))), NewObj(5).Put("sz", ((V)(0.22))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).Put("shine", ((V)(0D))).V), Call(ball_15, V.Undef, ((V)(x_1130)), ((V)(y_1131)), ((V)((bz_1002 + 8.7))), ((V)(1.8)), (Truthy(brass_1003) ? GOLD_27 : Call(shade_21, V.Undef, fab_1038, ((V)(0.58)))), Call(mt_34, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V)));
return default;
}, 1, "", true));
}, 1, "", true));
Invoke(o_1037, "push", Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((bz_1002 + 2D))), ((V)(((by_998 + 12D) + bh_1001))))).Put("a", ((V)(9D))).Put("b", ((V)(6D))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)(((((-Wd_997) / 2D) + AW_995) - 2D))), ((V)(2.5)), ((V)(0.85))), Arr(((V)(((((-Wd_997) / 2D) + AW_995) + 1D))), ((V)(0D))), Arr(((V)((((Wd_997 / 2D) - AW_995) - 1D))), ((V)(0D))), Arr(((V)((((Wd_997 / 2D) - AW_995) + 2D))), ((V)(2.5)), ((V)(0.85))))).Put("col", fab_1038).Put("soft", ((V)(1D))).V), Call(slabX_17, V.Undef, ((V)(0D)), ((V)((((by_998 + 12D) + bh_1001) - 5.4))), ((V)((bz_1002 + 9.4))), ((V)(((Wd_997 - (AW_995 * 2D)) - 2D))), ((V)(1.4)), ((V)(1.2)), pip_1041, (Truthy(brass_1003) ? Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V) : NewObj(2).Put("r", ((V)(0.6))).Put("mat", ((V)("fab"))).V)));
if (Truthy(gold_992)) {
Invoke(o_1037, "push", Call(ball_15, V.Undef, ((V)(0D)), ((V)((((by_998 + 12D) + bh_1001) + 6D))), ((V)((bz_1002 + 2D))), ((V)(4D)), GOLD_27, Call(mt_34, V.Undef, NewObj(4).Put("sy", ((V)(0.8))).Put("sz", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)));
}
} else {
Invoke(xs_999, "forEach", Fn((V _arrowThis1139, int _argc1132, V x_1138, V _a1135, V _a1136, V _a1137, V[] _rest1133) => {
return Invoke(Arr(((V)((-1D))), ((V)(0D)), ((V)(1D))), "forEach", Fn((V _arrowThis1147, int _argc1140, V t_1146, V _a1143, V _a1144, V _a1145, V[] _rest1141) => {
return Invoke(o_1037, "push", Call(pillowZ_20, V.Undef, Add(x_1138, ((V)((ToNum(t_1146) * 17D)))), ((V)((by_998 + 16D))), ((V)((bz_1002 + 9D))), ((V)(16D)), ((V)((bh_1001 - 6D))), ((V)(8D)), (Truthy(t_1146) ? fab_1038 : fL_1039)));
}, 1, "", true));
}, 1, "", true));
}
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1155, int _argc1148, V sg_1154, V _a1151, V _a1152, V _a1153, V[] _rest1149) => {
double x_1156 = 0;
double z0_1157 = 0;
double z1_1158 = 0;
double xr_1159 = 0;
double bx_1160 = 0;
double bc_1161 = 0;
double zA_1162 = 0;
double zB_1163 = 0;
x_1156 = (ToNum(sg_1154) * ((Wd_997 / 2D) - (AW_995 / 2D)));
z0_1157 = (((-Dp_996) / 2D) + 3D);
z1_1158 = ((Dp_996 / 2D) - 3D);
xr_1159 = (x_1156 + (ToNum(sg_1154) * 2D));
Invoke(o_1037, "push", Call(box_12, V.Undef, ((V)(x_1156)), ((V)(by_998)), ((V)(((z0_1157 + z1_1158) / 2D))), ((V)(AW_995)), ((V)(ah_1000)), ((V)((z1_1158 - z0_1157))), fab_1038, NewObj(3).Put("r", ((V)(6D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(xr_1159)), ((V)((by_998 + ah_1000))))).Put("a", ((V)(((AW_995 / 2D) + 4D)))).Put("b", ((V)(8D))).Put("n", ((V)(16D))).Put("rings", Arr(Arr(((V)(z0_1157)), ((V)(2.5)), ((V)(0.85))), Arr(((V)((z0_1157 + 2.5))), ((V)(0D))), Arr(((V)((z1_1158 - 2.5))), ((V)(0D))), Arr(((V)(z1_1158)), ((V)(2.5)), ((V)(0.85))))).Put("col", fab_1038).Put("soft", ((V)(1D))).V));
Invoke(o_1037, "push", Call(box_12, V.Undef, ((V)(x_1156)), ((V)((by_998 + 2D))), ((V)((z1_1158 + 0.1))), ((V)((AW_995 - 7D))), ((V)((ah_1000 - 8D))), ((V)(1D)), Call(shade_21, V.Undef, fab_1038, ((V)(0.92))), NewObj(3).Put("r", ((V)(3D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(disc_19, V.Undef, ((V)(xr_1159)), ((V)((by_998 + ah_1000))), ((V)((z1_1158 + 0.3))), ((V)(((AW_995 / 2D) + 1D))), ((V)(1.2)), Call(shade_21, V.Undef, fab_1038, ((V)(0.9))), NewObj(1).Put("mat", ((V)("fab"))).V));
Invoke(o_1037, "push", Call(solid_11, V.Undef, Object_assign(NewObj(12).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(xr_1159)), ((V)((by_998 + ah_1000))))).Put("a", ((V)(((AW_995 / 2D) + 1.6)))).Put("b", ((V)(8.6))).Put("th", ((V)(1D))).Put("a0", ((V)(0D))).Put("a1", ((V)((2D * PI_31)))).Put("n", ((V)(18D))).Put("rings", Arr(Arr(((V)((z1_1158 + 0.9))), ((V)(0D))), Arr(((V)((z1_1158 + 1.7))), ((V)(0D))))).Put("col", pip_1041).Put("noOut", ((V)(1D))).V, (Truthy(brass_1003) ? NewObj(1).Put("mat", ((V)("metal"))).V : NewObj(1).Put("mat", ((V)("fab"))).V))));
Invoke(o_1037, "push", Call(ball_15, V.Undef, ((V)(xr_1159)), ((V)((by_998 + ah_1000))), ((V)((z1_1158 + 1.6))), ((V)(2.8)), (Truthy(gold_992) ? GOLD_27 : Call(shade_21, V.Undef, fab_1038, ((V)(0.75)))), Object_assign(NewObj(1).Put("sz", ((V)(0.5))).V, (Truthy(gold_992) ? Call(mt_34, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V) : NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("mat", ((V)("fab"))).V))));
if (Truthy(brass_1003)) {
Call(rep_39, V.Undef, ((V)(6D)), Fn((V _arrowThis1171, int _argc1164, V i_1170, V _a1167, V _a1168, V _a1169, V[] _rest1165) => {
return Invoke(o_1037, "push", Call(ball_15, V.Undef, ((V)(x_1156)), ((V)(((by_998 + 4D) + ((ToNum(i_1170) * (ah_1000 - 12D)) / 5D)))), ((V)((z1_1158 + 0.8))), ((V)(1.1)), GOLD_27, Call(mt_34, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
}
bx_1160 = (ToNum(sg_1154) * (((Wd_997 / 2D) - AW_995) - 7.5));
bc_1161 = (st0_1008 + 6.6);
zA_1162 = (bf_1004 + 4D);
zB_1163 = ((Dp_996 / 2D) - 10D);
Invoke(o_1037, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(bx_1160)), ((V)(bc_1161)))).Put("a", ((V)(7D))).Put("b", ((V)(7D))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)(zA_1162)), ((V)(0D)), ((V)(0.72))), Arr(((V)((zA_1162 + 1.6))), ((V)(0D)), ((V)(1D))), Arr(((V)((zB_1163 - 1.6))), ((V)(0D)), ((V)(1D))), Arr(((V)(zB_1163)), ((V)(0D)), ((V)(0.72))))).Put("col", Call(shade_21, V.Undef, fab_1038, ((V)(1.14)))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(disc_19, V.Undef, ((V)(bx_1160)), ((V)(bc_1161)), ((V)(zB_1163)), ((V)(4.8)), ((V)(0.5)), pip_1041, (Truthy(brass_1003) ? Call(mt_34, V.Undef) : NewObj(1).Put("mat", ((V)("fab"))).V)), Call(ball_15, V.Undef, ((V)(bx_1160)), ((V)((bc_1161 - 1.6))), ((V)((zB_1163 + 0.4))), ((V)(1.6)), (Truthy(brass_1003) ? GOLD_27 : pip_1041), Call(mt_34, V.Undef, NewObj(3).Put("sz", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1179, int _argc1172, V sg_1178, V _a1175, V _a1176, V _a1177, V[] _rest1173) => {
double px_1180 = 0;
V pc_1181 = default;
px_1180 = (ToNum(sg_1178) * (((Wd_997 / 2D) - AW_995) - 31D));
pc_1181 = (LtN(sg_1178, 0D) ? pil_1044 : Call(shade_21, V.Undef, pil_1044, ((V)(0.88))));
Invoke(o_1037, "push", Call(throwP_56, V.Undef, ((V)(px_1180)), ((V)((st0_1008 - 1.6))), ((V)((bf_1004 + 5.6))), ((V)(26D)), pc_1181), Call(slabX_17, V.Undef, ((V)(px_1180)), ((V)((st0_1008 + 23.4))), ((V)((bf_1004 + 7.2))), ((V)(22D)), ((V)(1D)), ((V)(1D)), Call(shade_21, V.Undef, pc_1181, ((V)(0.7))), NewObj(3).Put("r", ((V)(0.5))).Put("noOut", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(Arr(((V)((-12D))), ((V)(12D))), "forEach", Fn((V _arrowThis1189, int _argc1182, V t_1188, V _a1185, V _a1186, V _a1187, V[] _rest1183) => {
return Invoke(o_1037, "push", Call(ball_15, V.Undef, Add(((V)(px_1180)), t_1188), ((V)((st0_1008 + 22D))), ((V)((bf_1004 + 6D))), ((V)(1.6)), (Truthy(brass_1003) ? GOLD_27 : Call(shade_21, V.Undef, pc_1181, ((V)(0.7)))), NewObj(3).Put("sy", ((V)(1.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
return default;
}, 1, "", true));
if (GeN(n_990, 3D)) {
V lc_1190 = default;
lc_1190 = (Truthy(Get(S_988, "pil")) ? Call(shade_21, V.Undef, Get(S_988, "pil"), ((V)(1.1))) : Call(shade_21, V.Undef, fab_1038, ((V)(1.18))));
Invoke(o_1037, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("z"))).Put("sh", ((V)("rr"))).Put("c", Arr(((V)(0D)), ((V)((st0_1008 + 6.6))))).Put("a", ((V)(18D))).Put("b", ((V)(8D))).Put("r", ((V)(7D))).Put("rings", Arr(Arr(((V)((bf_1004 + 1D))), ((V)(3D)), ((V)(0.82))), Arr(((V)((bf_1004 + 3D))), ((V)(0.6)), ((V)(0.97))), Arr(((V)((bf_1004 + 5D))), ((V)(0D)), ((V)(1D))), Arr(((V)((bf_1004 + 7D))), ((V)(0.6)), ((V)(0.97))), Arr(((V)((bf_1004 + 9D))), ((V)(3D)), ((V)(0.82))))).Put("col", lc_1190).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(slabX_17, V.Undef, ((V)(0D)), ((V)((st0_1008 + 6D))), ((V)((bf_1004 + 9.2))), ((V)(30D)), ((V)(1.2)), ((V)(0.5)), pip_1041, (Truthy(brass_1003) ? Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).V) : NewObj(3).Put("r", ((V)(0.4))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V)));
}
{
double x_1191 = 0;
double tz_1192 = 0;
x_1191 = ((-((Wd_997 / 2D) - (AW_995 / 2D))) - 2D);
tz_1192 = 2D;
Invoke(o_1037, "push", Call(box_12, V.Undef, ((V)(x_1191)), ((V)(((by_998 + ah_1000) + 5.6))), ((V)(tz_1192)), ((V)((AW_995 + 6D))), ((V)(3.2)), ((V)(30D)), thr_1045, NewObj(4).Put("r", ((V)(1.6))).Put("bev", ((V)(1.4))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(box_12, V.Undef, ((V)((((-Wd_997) / 2D) - 2.6))), ((V)(((by_998 + ah_1000) - 16D))), ((V)(tz_1192)), ((V)(2.6)), ((V)(24D)), ((V)(30D)), thr_1045, NewObj(3).Put("r", ((V)(1.2))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(Arr(((V)((-9D))), ((V)(9D))), "forEach", Fn((V _arrowThis1200, int _argc1193, V dz_1199, V _a1196, V _a1197, V _a1198, V[] _rest1194) => {
return Invoke(o_1037, "push", Call(box_12, V.Undef, ((V)(x_1191)), ((V)(((by_998 + ah_1000) + 8.9))), Add(((V)(tz_1192)), dz_1199), ((V)((AW_995 + 6.4))), ((V)(0.3)), ((V)(3D)), pil_1044, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(box_12, V.Undef, ((V)((((-Wd_997) / 2D) - 4D))), ((V)(((by_998 + ah_1000) - 16D))), Add(((V)(tz_1192)), dz_1199), ((V)(0.3)), ((V)(24.4)), ((V)(3D)), pil_1044, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(8D)), Fn((V _arrowThis1208, int _argc1201, V i_1207, V _a1204, V _a1205, V _a1206, V[] _rest1202) => {
return Invoke(o_1037, "push", Call(box_12, V.Undef, ((V)((((-Wd_997) / 2D) - 2.6))), ((V)(((by_998 + ah_1000) - 20D))), ((V)(((tz_1192 - 13D) + (ToNum(i_1207) * 3.7)))), ((V)(1D)), ((V)(4D)), ((V)(1D)), Call(shade_21, V.Undef, thr_1045, ((V)(0.9))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
}
return o_1037;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true));
POP_58 = Arr(((V)("#fff6dc")), ((V)("#fbeab8")), ((V)("#fffaf0")), ((V)("#f6dc94")));
kern_59 = Fn((V _arrowThis1220, int _argc1209, V x_1215, V y_1216, V z_1217, V s_1218, V[] _rest1210) => {
V i_1219 = default;
i_1219 = (_argc1209 > 4 ? _rest1210[0] : V.Undef);
return Arr(Call(ball_15, V.Undef, x_1215, y_1216, z_1217, ((V)((1.8 * ToNum(s_1218)))), GetIdx(POP_58, (ToNum(i_1219) % 4D)), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(7D))).Put("shine", ((V)(0D))).V), Call(ball_15, V.Undef, Add(x_1215, ((V)(((1.15 * ToNum(s_1218)) * FdLibm.Cos(ToNum(i_1219)))))), Add(y_1216, ((V)((0.9 * ToNum(s_1218))))), Add(z_1217, ((V)(((1.15 * ToNum(s_1218)) * FdLibm.Sin(ToNum(i_1219)))))), ((V)((1.35 * ToNum(s_1218)))), GetIdx(POP_58, (ToNum(Add(i_1219, ((V)(1D)))) % 4D)), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("shine", ((V)(0D))).V));
}, 5, "", true);
heap_60 = Fn((V _arrowThis1237, int _argc1221, V o_1227, V x_1228, V y_1229, V z_1230, V[] _rest1222) => {
V R_1238 = default;
V rx_1231 = default;
V rz_1232 = default;
V h_1233 = default;
V n_1234 = default;
V seed_1235 = default;
V s_1236 = default;
rx_1231 = (_argc1221 > 4 ? _rest1222[0] : V.Undef);
rz_1232 = (_argc1221 > 5 ? _rest1222[1] : V.Undef);
h_1233 = (_argc1221 > 6 ? _rest1222[2] : V.Undef);
n_1234 = (_argc1221 > 7 ? _rest1222[3] : V.Undef);
seed_1235 = (_argc1221 > 8 ? _rest1222[4] : V.Undef);
s_1236 = (_argc1221 > 9 ? _rest1222[5] : V.Undef);
R_1238 = Call(rng_50, V.Undef, seed_1235);
Invoke(o_1227, "push", Call(ball_15, V.Undef, x_1228, ((V)((ToNum(y_1229) - ToNum(h_1233)))), z_1230, rx_1231, ((V)("#f8e8b8")), NewObj(5).Put("sz", ((V)((ToNum(rz_1232) / ToNum(rx_1231))))).Put("sy", ((V)((ToNum(h_1233) / ToNum(rx_1231))))).Put("k", ((V)(4D))).Put("n", ((V)(14D))).Put("shine", ((V)(0D))).V));
Call(rep_39, V.Undef, n_1234, Fn((V _arrowThis1246, int _argc1239, V i_1245, V _a1242, V _a1243, V _a1244, V[] _rest1240) => {
double a_1247 = 0;
double t_1248 = 0;
a_1247 = ((ToNum(Call(R_1238, V.Undef)) * 2D) * PI_31);
t_1248 = (System.Math.Sqrt(ToNum(Call(R_1238, V.Undef))) * 0.9);
InvokeSpread(o_1227, "push", new ArrBuilder().Spread(Call(kern_59, V.Undef, Add(x_1228, ((V)(((ToNum(rx_1231) * t_1248) * FdLibm.Cos(a_1247))))), ((V)((ToNum(Add(y_1229, ((V)((ToNum(h_1233) * System.Math.Sqrt((1D - (t_1248 * t_1248)))))))) - (1.6 * ToNum((s_1236 is var _t1249 && Truthy(_t1249) ? _t1249 : ((V)(1D)))))))), Add(z_1230, ((V)(((ToNum(rz_1232) * t_1248) * FdLibm.Sin(a_1247))))), (s_1236 is var _t1250 && Truthy(_t1250) ? _t1250 : ((V)(1D))), i_1245)).V);
return default;
}, 1, "", true));
return default;
}, 10, "", true);
plateF_61 = Fn((V _arrowThis1263, int _argc1251, V x_1257, V y_1258, V z_1259, V r_1260, V[] _rest1252) => {
V col_1261 = default;
V o_1262 = default;
col_1261 = (_argc1251 > 4 ? _rest1252[0] : V.Undef);
o_1262 = (_argc1251 > 5 ? _rest1252[1] : V.Undef);
return Call(cyl_14, V.Undef, x_1257, y_1258, z_1259, r_1260, ((V)(2.2)), (col_1261 is var _t1264 && Truthy(_t1264) ? _t1264 : ((V)("#fbf8f2"))), Object_assign(NewObj(3).Put("n", ((V)(22D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(0.9)), ((V)(0D)), ((V)(0.64))), Arr(((V)(1.6)), ((V)(0D)), ((V)(1D))), Arr(((V)(2.2)), ((V)(0D)), ((V)(1D))))).V, (o_1262 is var _t1265 && Truthy(_t1265) ? _t1265 : NewObj(0).V)));
}, 6, "", true);
SPR_62 = Arr(((V)("#ff6ad5")), ((V)("#ffd66b")), ((V)("#6ac8ff")), ((V)("#a6f06a")), ((V)("#ffffff")), ((V)("#ff9d4a")));
sprinkles_63 = Fn((V _arrowThis1279, int _argc1266, V o_1272, V x_1273, V y_1274, V z_1275, V[] _rest1267) => {
V R_1280 = default;
V r_1276 = default;
V n_1277 = default;
V seed_1278 = default;
r_1276 = (_argc1266 > 4 ? _rest1267[0] : V.Undef);
n_1277 = (_argc1266 > 5 ? _rest1267[1] : V.Undef);
seed_1278 = (_argc1266 > 6 ? _rest1267[2] : V.Undef);
R_1280 = Call(rng_50, V.Undef, seed_1278);
Call(rep_39, V.Undef, n_1277, Fn((V _arrowThis1288, int _argc1281, V i_1287, V _a1284, V _a1285, V _a1286, V[] _rest1282) => {
double a_1289 = 0;
double t_1290 = 0;
a_1289 = ((ToNum(Call(R_1280, V.Undef)) * 2D) * PI_31);
t_1290 = (0.35 + (ToNum(Call(R_1280, V.Undef)) * 0.6));
Invoke(o_1272, "push", Call(box_12, V.Undef, Add(x_1273, ((V)(((FdLibm.Cos(a_1289) * ToNum(r_1276)) * t_1290)))), y_1274, Add(z_1275, ((V)(((FdLibm.Sin(a_1289) * ToNum(r_1276)) * t_1290)))), ((V)(2D)), ((V)(0.5)), ((V)(0.7)), GetIdx(SPR_62, (ToNum(i_1287) % 6D)), NewObj(3).Put("yaw", ((V)((ToNum(Call(R_1280, V.Undef)) * PI_31)))).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).V));
return default;
}, 1, "", true));
return default;
}, 7, "", true);
apple_64 = Fn((V _arrowThis1302, int _argc1291, V x_1297, V y_1298, V z_1299, V col_1300, V[] _rest1292) => {
V s_1301 = default;
s_1301 = (_argc1291 > 4 ? _rest1292[0] : V.Undef);
s_1301 = (s_1301 is var _t1303 && Truthy(_t1303) ? _t1303 : ((V)(1D)));
return Arr(Call(ball_15, V.Undef, x_1297, y_1298, z_1299, ((V)((6.4 * ToNum(s_1301)))), col_1300, NewObj(3).Put("sy", ((V)(0.9))).Put("k", ((V)(6D))).Put("n", ((V)(14D))).V), Call(ball_15, V.Undef, x_1297, Add(y_1298, ((V)((10.6 * ToNum(s_1301))))), z_1299, ((V)((2.2 * ToNum(s_1301)))), Call(shade_21, V.Undef, col_1300, ((V)(0.82))), NewObj(4).Put("sy", ((V)(0.35))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).V), Call(cyl_14, V.Undef, x_1297, Add(y_1298, ((V)((10.8 * ToNum(s_1301))))), z_1299, ((V)(0.6)), ((V)((3D * ToNum(s_1301)))), ((V)("#5a3a20")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_15, V.Undef, Add(x_1297, ((V)((2.2 * ToNum(s_1301))))), Add(y_1298, ((V)((12.6 * ToNum(s_1301))))), z_1299, ((V)((2.2 * ToNum(s_1301)))), ((V)("#5fa84a")), NewObj(4).Put("sx", ((V)(1.5))).Put("sy", ((V)(0.35))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
return default;
}, 5, "", true);
orange_65 = Fn((V _arrowThis1314, int _argc1304, V x_1310, V y_1311, V z_1312, V s_1313, V[] _rest1305) => {
s_1313 = (s_1313 is var _t1315 && Truthy(_t1315) ? _t1315 : ((V)(1D)));
return Arr(Call(ball_15, V.Undef, x_1310, y_1311, z_1312, ((V)((6.6 * ToNum(s_1313)))), ((V)("#f2932c")), NewObj(2).Put("k", ((V)(6D))).Put("n", ((V)(14D))).V), Call(ball_15, V.Undef, x_1310, Add(y_1311, ((V)((12.8 * ToNum(s_1313))))), Add(z_1312, ((V)(0.6))), ((V)((1.1 * ToNum(s_1313)))), ((V)("#6a8a3a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V), Call(ball_15, V.Undef, Add(x_1310, ((V)(1.4))), Add(y_1311, ((V)((12.4 * ToNum(s_1313))))), z_1312, ((V)((1.8 * ToNum(s_1313)))), ((V)("#5fa84a")), NewObj(4).Put("sx", ((V)(1.4))).Put("sy", ((V)(0.35))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
return default;
}, 4, "", true);
straw_66 = Fn((V _arrowThis1326, int _argc1316, V x_1322, V y_1323, V z_1324, V s_1325, V[] _rest1317) => {
s_1325 = (s_1325 is var _t1327 && Truthy(_t1327) ? _t1327 : ((V)(1D)));
return Arr(Call(ball_15, V.Undef, x_1322, y_1323, z_1324, ((V)((2.6 * ToNum(s_1325)))), ((V)("#d9283b")), NewObj(3).Put("sy", ((V)(1.25))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V), Call(ball_15, V.Undef, x_1322, Add(y_1323, ((V)((5.6 * ToNum(s_1325))))), z_1324, ((V)((2D * ToNum(s_1325)))), ((V)("#4f9a3a")), NewObj(4).Put("sy", ((V)(0.35))).Put("k", ((V)(2D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).V));
return default;
}, 4, "", true);
Set(N_24, "fFruitBowl", Fn((V _arrowThis1335, int _argc1328, V S_1334, V _a1331, V _a1332, V _a1333, V[] _rest1329) => {
return NewObj(3).Put("w", ((V)(56D))).Put("d", ((V)(52D))).Put("build", Fn((V _arrowThis1343, int _argc1336, V P_1342, V _a1339, V _a1340, V _a1341, V[] _rest1337) => {
V o_1344 = default;
o_1344 = Arr(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(9D)), ((V)(3D)), ((V)("#f4f1ea")), Call(cer_36, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(24D)), ((V)(11D)), ((V)("#f4f1ea")), Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.42))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.78))), Arr(((V)(9D)), ((V)(0D)), ((V)(0.98))), Arr(((V)(11D)), ((V)(0D)), ((V)(1D))))).V)), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(24.4)), ((V)(24.4)), ((V)(1.4)), ((V)(1D)), ((V)(0D)), ((V)((2D * PI_31))), ((V)("#6b8fb8")), Call(cer_36, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)));
InvokeSpread(o_1344, "push", new ArrBuilder().Spread(Call(apple_64, V.Undef, ((V)((-9D))), ((V)(10D)), ((V)((-6D))), ((V)("#d9363b")))).Spread(Call(orange_65, V.Undef, ((V)(8D)), ((V)(10D)), ((V)((-7D))))).Spread(Call(apple_64, V.Undef, ((V)(1D)), ((V)(10D)), ((V)(8D)), ((V)("#9fcf4a")))).Spread(Call(orange_65, V.Undef, ((V)((-11D))), ((V)(9D)), ((V)(7D)), ((V)(0.9)))).Spread(Call(apple_64, V.Undef, ((V)(2D)), ((V)(19D)), ((V)((-2D))), ((V)("#c42a30")), ((V)(0.95)))).V);
Invoke(Arr(Arr(((V)((-2D))), ((V)(22D)), ((V)(10D))), Arr(((V)(4D)), ((V)(21D)), ((V)(11D))), Arr(((V)(10D)), ((V)(19D)), ((V)(10D)))), "forEach", Fn((V _arrowThis1358, int _argc1345, V _a1347, V _a1348, V _a1349, V _a1350, V[] _rest1346) => {
V a_1353 = default;
V y_1355 = default;
V r_1357 = default;
{ V _t1351 = ListOf(_a1347);
{ V _t1352 = GetIdx(_t1351, 0D);
a_1353 = _t1352; }
{ V _t1354 = GetIdx(_t1351, 1D);
y_1355 = _t1354; }
{ V _t1356 = GetIdx(_t1351, 2D);
r_1357 = _t1356; }
}
return Invoke(o_1344, "push", Call(arcW_18, V.Undef, ((V)(12D)), y_1355, ((V)(4D)), r_1357, r_1357, ((V)(3.2)), ((V)(3.6)), ((V)((PI_31 * (1.05 + (ToNum(a_1353) * 0.01))))), ((V)((PI_31 * 1.85))), ((V)("#f6d24a")), NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(o_1344, "push", Call(cyl_14, V.Undef, ((V)((12D + (FdLibm.Cos((PI_31 * 1.05)) * 9D)))), ((V)(20D)), ((V)((4D + (FdLibm.Sin((PI_31 * 1.05)) * 9D)))), ((V)(1.1)), ((V)(4D)), ((V)("#6b4a20")), NewObj(1).Put("n", ((V)(6D))).V));
Call(rep_39, V.Undef, ((V)(12D)), Fn((V _arrowThis1366, int _argc1359, V i_1365, V _a1362, V _a1363, V _a1364, V[] _rest1360) => {
return Invoke(o_1344, "push", Call(ball_15, V.Undef, ((V)(((19D + ((ToNum(i_1365) % 3D) * 2.8)) - (GtN(i_1365, 8D) ? (-1D) : 0D)))), ((V)((6D + (System.Math.Floor((ToNum(i_1365) / 3D)) * 3D)))), ((V)((8D + ((ToNum(i_1365) % 2D) * 2.4)))), ((V)(2.1)), ((V)((NumTruthy((ToNum(i_1365) % 2D)) ? "#6b3a8a" : "#7d4a9a"))), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(o_1344, "push", Call(cyl_14, V.Undef, ((V)(20D)), ((V)(18D)), ((V)(9D)), ((V)(0.6)), ((V)(3D)), ((V)("#6b4a20")), NewObj(1).Put("n", ((V)(4D))).V));
return o_1344;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_24, "fCake", Fn((V _arrowThis1374, int _argc1367, V S_1373, V _a1370, V _a1371, V _a1372, V[] _rest1368) => {
return NewObj(3).Put("w", ((V)(58D))).Put("d", ((V)(50D))).Put("build", Fn((V _arrowThis1382, int _argc1375, V P_1381, V _a1378, V _a1379, V _a1380, V[] _rest1376) => {
V o_1383 = default;
V fr_1384 = default;
V pk_1385 = default;
double sx_1386 = 0;
double sz_1387 = 0;
double a0_1388 = 0;
double a1_1389 = 0;
o_1383 = Arr();
fr_1384 = ((V)("#fdf3f0"));
pk_1385 = ((V)("#f6c6d2"));
Invoke(o_1383, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(9D)), ((V)(1.6)), ((V)("#f4f1ea")), Call(cer_36, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(1.6)), ((V)(0D)), ((V)(2.4)), ((V)(7D)), ((V)("#f4f1ea")), Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3.5)), ((V)(0D)), ((V)(0.65))), Arr(((V)(7D)), ((V)(0D)), ((V)(1.3))))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(8.6)), ((V)(0D)), ((V)(21D)), ((V)(1.6)), ((V)("#f4f1ea")), Call(cer_36, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(10.2)), ((V)(0D)), ((V)(21D)), ((V)(21D)), ((V)(1D)), ((V)(0.8)), ((V)(0D)), ((V)((2D * PI_31))), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)));
Invoke(o_1383, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(10.2)), ((V)(0D)), ((V)(17D)), ((V)(12D)), fr_1384, Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(22.2)), ((V)(0D)), ((V)(11D)), ((V)(10D)), pk_1385, Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)));
Call(rep_39, V.Undef, ((V)(16D)), Fn((V _arrowThis1397, int _argc1390, V i_1396, V _a1393, V _a1394, V _a1395, V[] _rest1391) => {
double a_1398 = 0;
a_1398 = (((ToNum(i_1396) / 16D) * 2D) * PI_31);
Invoke(o_1383, "push", Call(ball_15, V.Undef, ((V)((FdLibm.Cos(a_1398) * 17D))), ((V)(10.2)), ((V)((FdLibm.Sin(a_1398) * 17D))), ((V)(1.4)), ((V)("#ffffff")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
return default;
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(11D)), Fn((V _arrowThis1406, int _argc1399, V i_1405, V _a1402, V _a1403, V _a1404, V[] _rest1400) => {
double a_1407 = 0;
a_1407 = (((ToNum(i_1405) / 11D) * 2D) * PI_31);
Invoke(o_1383, "push", Call(ball_15, V.Undef, ((V)((FdLibm.Cos(a_1407) * 11D))), ((V)(22.2)), ((V)((FdLibm.Sin(a_1407) * 11D))), ((V)(1.2)), ((V)("#fff6ea")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V), Call(ball_15, V.Undef, ((V)((FdLibm.Cos((a_1407 + 0.3)) * 11.2))), ((V)((28.6 - (ToNum(i_1405) % 3D)))), ((V)((FdLibm.Sin((a_1407 + 0.3)) * 11.2))), ((V)(1D)), ((V)("#e98aa4")), NewObj(4).Put("sy", ((V)(2.2))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V));
return default;
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(8D)), Fn((V _arrowThis1415, int _argc1408, V i_1414, V _a1411, V _a1412, V _a1413, V[] _rest1409) => {
double a_1416 = 0;
a_1416 = ((((ToNum(i_1414) / 8D) * 2D) * PI_31) + 0.2);
InvokeSpread(o_1383, "push", new ArrBuilder().Add(Call(ball_15, V.Undef, ((V)((FdLibm.Cos(a_1416) * 14D))), ((V)(22.2)), ((V)((FdLibm.Sin(a_1416) * 14D))), ((V)(2.2)), ((V)("#ffffff")), NewObj(3).Put("sy", ((V)(0.7))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).Spread(Call(straw_66, V.Undef, ((V)((FdLibm.Cos(a_1416) * 14D))), ((V)(24.6)), ((V)((FdLibm.Sin(a_1416) * 14D))), ((V)(0.7)))).V);
return default;
}, 1, "", true));
InvokeSpread(o_1383, "push", new ArrBuilder().Add(Call(ball_15, V.Undef, ((V)(0D)), ((V)(32.2)), ((V)(0D)), ((V)(3.6)), ((V)("#ffffff")), NewObj(3).Put("sy", ((V)(0.8))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)).Spread(Call(straw_66, V.Undef, ((V)(0D)), ((V)(37.4)), ((V)(0D)), ((V)(1.05)))).Add(Call(ball_15, V.Undef, ((V)((-4D))), ((V)(32.4)), ((V)(3D)), ((V)(1.8)), ((V)("#2c1a10")), NewObj(3).Put("sy", ((V)(1.6))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V)).V);
sx_1386 = 26D;
sz_1387 = 14D;
a0_1388 = (PI_31 * 0.62);
a1_1389 = ((PI_31 * 0.62) + 0.75);
Invoke(o_1383, "push", Call(plateF_61, V.Undef, ((V)((sx_1386 - 2D))), ((V)(0D)), ((V)((sz_1387 - 3D))), ((V)(10D)), ((V)("#fbf8f2"))));
Invoke(Arr(Arr(((V)(2.2)), ((V)(4.6)), ((V)("#efc88a"))), Arr(((V)(6.8)), ((V)(1.2)), ((V)("#c8303a"))), Arr(((V)(8D)), ((V)(1.4)), ((V)("#fff6ea"))), Arr(((V)(9.4)), ((V)(4.6)), ((V)("#efc88a"))), Arr(((V)(14D)), ((V)(1.6)), pk_1385)), "forEach", Fn((V _arrowThis1430, int _argc1417, V _a1419, V _a1420, V _a1421, V _a1422, V[] _rest1418) => {
V y_1425 = default;
V h_1427 = default;
V col_1429 = default;
{ V _t1423 = ListOf(_a1419);
{ V _t1424 = GetIdx(_t1423, 0D);
y_1425 = _t1424; }
{ V _t1426 = GetIdx(_t1423, 1D);
h_1427 = _t1426; }
{ V _t1428 = GetIdx(_t1423, 2D);
col_1429 = _t1428; }
}
return Invoke(o_1383, "push", Call(arcW_18, V.Undef, ((V)((sx_1386 + 7D))), y_1425, ((V)((sz_1387 - 8D))), ((V)(13D)), ((V)(13D)), ((V)(13D)), h_1427, ((V)(a0_1388)), ((V)(a1_1389)), col_1429, Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)));
}, 1, "", true));
Invoke(o_1383, "push", Call(cyl_14, V.Undef, ((V)((sx_1386 + 6D))), ((V)(2.2)), ((V)((sz_1387 + 5D))), ((V)(0.7)), ((V)(0.6)), CH_28, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)), Call(box_12, V.Undef, ((V)((sx_1386 + 6D))), ((V)(2.2)), ((V)((sz_1387 + 1D))), ((V)(1.4)), ((V)(0.5)), ((V)(9D)), CH_28, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
return o_1383;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
donut_67 = Fn((V _arrowThis1443, int _argc1431, V o_1437, V x_1438, V y_1439, V z_1440, V[] _rest1432) => {
V ic_1441 = default;
V seed_1442 = default;
ic_1441 = (_argc1431 > 4 ? _rest1432[0] : V.Undef);
seed_1442 = (_argc1431 > 5 ? _rest1432[1] : V.Undef);
Invoke(o_1437, "push", Call(arcW_18, V.Undef, x_1438, y_1439, z_1440, ((V)(7.4)), ((V)(7.4)), ((V)(4D)), ((V)(1.2)), ((V)(0D)), ((V)((2D * PI_31))), ((V)("#c98a46")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(arcW_18, V.Undef, x_1438, Add(y_1439, ((V)(1.2))), z_1440, ((V)(8.2)), ((V)(8.2)), ((V)(5.6)), ((V)(2.6)), ((V)(0D)), ((V)((2D * PI_31))), ((V)("#d9a35a")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(arcW_18, V.Undef, x_1438, Add(y_1439, ((V)(3.8))), z_1440, ((V)(8D)), ((V)(8D)), ((V)(5.4)), ((V)(1.4)), ((V)(0D)), ((V)((2D * PI_31))), ic_1441, Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
Call(rep_39, V.Undef, ((V)(4D)), Fn((V _arrowThis1451, int _argc1444, V i_1450, V _a1447, V _a1448, V _a1449, V[] _rest1445) => {
V a_1452 = default;
a_1452 = Add(((V)((((ToNum(i_1450) / 4D) * 2D) * PI_31))), seed_1442);
Invoke(o_1437, "push", Call(ball_15, V.Undef, Add(x_1438, ((V)((FdLibm.Cos(ToNum(a_1452)) * 8D)))), Add(y_1439, ((V)(3.4))), Add(z_1440, ((V)((FdLibm.Sin(ToNum(a_1452)) * 8D)))), ((V)(1.2)), ic_1441, NewObj(4).Put("sy", ((V)(1.4))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V));
return default;
}, 1, "", true));
Call(sprinkles_63, V.Undef, o_1437, x_1438, Add(y_1439, ((V)(5.3))), z_1440, ((V)(7D)), ((V)(9D)), ((V)(JsStrBuf.Begin().S("d").V(seed_1442).V(x_1438).End())));
return default;
}, 6, "", true);
Set(N_24, "fDonuts", Fn((V _arrowThis1460, int _argc1453, V S_1459, V _a1456, V _a1457, V _a1458, V[] _rest1454) => {
return NewObj(3).Put("w", ((V)(56D))).Put("d", ((V)(50D))).Put("build", Fn((V _arrowThis1468, int _argc1461, V P_1467, V _a1464, V _a1465, V _a1466, V[] _rest1462) => {
V o_1469 = default;
o_1469 = Arr(Call(plateF_61, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(24D))));
Call(donut_67, V.Undef, o_1469, ((V)((-9D))), ((V)(2.2)), ((V)((-4D))), ((V)("#f6a8c4")), ((V)(1D)));
Call(donut_67, V.Undef, o_1469, ((V)(9D)), ((V)(2.2)), ((V)((-5D))), ((V)("#6b3a22")), ((V)(2D)));
Call(donut_67, V.Undef, o_1469, ((V)(0D)), ((V)(2.2)), ((V)(9D)), ((V)("#fff6ea")), ((V)(3D)));
Call(donut_67, V.Undef, o_1469, ((V)(1D)), ((V)(7.6)), ((V)((-1D))), ((V)("#f6a8c4")), ((V)(4D)));
return o_1469;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
cupcake_68 = Fn((V _arrowThis1482, int _argc1470, V o_1476, V x_1477, V z_1478, V liner_1479, V[] _rest1471) => {
V frost_1480 = default;
V seed_1481 = default;
frost_1480 = (_argc1470 > 4 ? _rest1471[0] : V.Undef);
seed_1481 = (_argc1470 > 5 ? _rest1471[1] : V.Undef);
Invoke(o_1476, "push", Call(cyl_14, V.Undef, x_1477, ((V)(2.2)), z_1478, ((V)(5.4)), ((V)(7D)), liner_1479, Call(pt_38, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.78))), Arr(((V)(7D)), ((V)(0D)), ((V)(1D))))).V)));
Call(rep_39, V.Undef, ((V)(8D)), Fn((V _arrowThis1490, int _argc1483, V i_1489, V _a1486, V _a1487, V _a1488, V[] _rest1484) => {
double a_1491 = 0;
a_1491 = (((ToNum(i_1489) / 8D) * 2D) * PI_31);
Invoke(o_1476, "push", Call(box_12, V.Undef, Add(x_1477, ((V)((FdLibm.Cos(a_1491) * 4.9)))), ((V)(2.4)), Add(z_1478, ((V)((FdLibm.Sin(a_1491) * 4.9)))), ((V)(0.6)), ((V)(6.6)), ((V)(0.6)), Call(shade_21, V.Undef, liner_1479, ((V)(0.8))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
return default;
}, 1, "", true));
Invoke(o_1476, "push", Call(ball_15, V.Undef, x_1477, ((V)(7.4)), z_1478, ((V)(6.2)), ((V)("#e0a85a")), NewObj(3).Put("sy", ((V)(0.45))).Put("k", ((V)(3D))).Put("n", ((V)(14D))).V), Call(ball_15, V.Undef, x_1477, ((V)(9D)), z_1478, ((V)(6D)), frost_1480, NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(14D))).V), Call(ball_15, V.Undef, x_1477, ((V)(12.6)), z_1478, ((V)(4.6)), frost_1480, NewObj(3).Put("sy", ((V)(0.55))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V), Call(ball_15, V.Undef, x_1477, ((V)(15.6)), z_1478, ((V)(3D)), frost_1480, NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V), Call(ball_15, V.Undef, x_1477, ((V)(18.2)), z_1478, ((V)(1.4)), frost_1480, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
Invoke(o_1476, "push", Call(ball_15, V.Undef, Add(x_1477, ((V)(0.8))), ((V)(19.2)), z_1478, ((V)(2D)), ((V)("#c8243a")), NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V), Call(cyl_14, V.Undef, Add(x_1477, ((V)(1.2))), ((V)(23D)), z_1478, ((V)(0.4)), ((V)(3D)), ((V)("#5a3a20")), NewObj(1).Put("n", ((V)(4D))).V));
Call(sprinkles_63, V.Undef, o_1476, x_1477, ((V)(13.6)), z_1478, ((V)(5D)), ((V)(6D)), ((V)(JsStrBuf.Begin().S("c").V(seed_1481).End())));
return default;
}, 6, "", true);
Set(N_24, "fCupcakes", Fn((V _arrowThis1499, int _argc1492, V S_1498, V _a1495, V _a1496, V _a1497, V[] _rest1493) => {
return NewObj(3).Put("w", ((V)(56D))).Put("d", ((V)(50D))).Put("build", Fn((V _arrowThis1507, int _argc1500, V P_1506, V _a1503, V _a1504, V _a1505, V[] _rest1501) => {
V o_1508 = default;
o_1508 = Arr(Call(plateF_61, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(24D))));
Call(cupcake_68, V.Undef, o_1508, ((V)((-10D))), ((V)((-4D))), ((V)("#6ac8ff")), ((V)("#fff2f6")), ((V)(1D)));
Call(cupcake_68, V.Undef, o_1508, ((V)(10D)), ((V)((-5D))), ((V)("#ffd66b")), ((V)("#f6a8c4")), ((V)(2D)));
Call(cupcake_68, V.Undef, o_1508, ((V)(0D)), ((V)(9D)), ((V)("#a6f06a")), ((V)("#c9a6f0")), ((V)(3D)));
return o_1508;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
cookie_69 = Fn((V _arrowThis1520, int _argc1509, V o_1515, V x_1516, V y_1517, V z_1518, V[] _rest1510) => {
V c0_1521 = default;
V ch_1522 = default;
V dark_1519 = default;
dark_1519 = (_argc1509 > 4 ? _rest1510[0] : V.Undef);
c0_1521 = ((V)((Truthy(dark_1519) ? "#6b3a22" : "#c98a46")));
ch_1522 = ((V)((Truthy(dark_1519) ? "#f4e2b8" : "#3a2010")));
Invoke(o_1515, "push", Call(cyl_14, V.Undef, x_1516, y_1517, z_1518, ((V)(6.4)), ((V)(1.8)), c0_1521, Call(pt_38, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(0.9)), ((V)(0D)), ((V)(1D))), Arr(((V)(1.8)), ((V)(0D)), ((V)(0.9))))).V)));
Call(rep_39, V.Undef, ((V)(4D)), Fn((V _arrowThis1530, int _argc1523, V i_1529, V _a1526, V _a1527, V _a1528, V[] _rest1524) => {
V a_1531 = default;
a_1531 = Add(((V)((ToNum(i_1529) * 1.7))), x_1516);
Invoke(o_1515, "push", Call(ball_15, V.Undef, Add(x_1516, ((V)((FdLibm.Cos(ToNum(a_1531)) * 3.4)))), Add(y_1517, ((V)(1.5))), Add(z_1518, ((V)((FdLibm.Sin(ToNum(a_1531)) * 3.4)))), ((V)(1.1)), ch_1522, NewObj(4).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V));
return default;
}, 1, "", true));
return default;
}, 5, "", true);
Set(N_24, "fCookies", Fn((V _arrowThis1539, int _argc1532, V S_1538, V _a1535, V _a1536, V _a1537, V[] _rest1533) => {
return NewObj(3).Put("w", ((V)(56D))).Put("d", ((V)(48D))).Put("build", Fn((V _arrowThis1547, int _argc1540, V P_1546, V _a1543, V _a1544, V _a1545, V[] _rest1541) => {
V o_1548 = default;
o_1548 = Arr(Call(plateF_61, V.Undef, ((V)((-4D))), ((V)(0D)), ((V)(2D)), ((V)(20D))));
Call(rep_39, V.Undef, ((V)(4D)), Fn((V _arrowThis1556, int _argc1549, V i_1555, V _a1552, V _a1553, V _a1554, V[] _rest1550) => {
return Call(cookie_69, V.Undef, o_1548, ((V)(((-10D) + ((ToNum(i_1555) % 2D) * 0.8)))), ((V)((2.2 + (ToNum(i_1555) * 1.9)))), ((V)((-2D))), (SEqN(i_1555, 2D) ? V.True : V.False));
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(2D)), Fn((V _arrowThis1564, int _argc1557, V i_1563, V _a1560, V _a1561, V _a1562, V[] _rest1558) => {
return Call(cookie_69, V.Undef, o_1548, ((V)(4D)), ((V)((2.2 + (ToNum(i_1563) * 1.9)))), ((V)((-5D))), (SEqN(i_1563, 1D) ? V.True : V.False));
}, 1, "", true));
Call(cookie_69, V.Undef, o_1548, ((V)(0D)), ((V)(2.2)), ((V)(10D)), (false ? V.True : V.False));
Invoke(o_1548, "push", Call(cyl_14, V.Undef, ((V)(18D)), ((V)(0D)), ((V)((-2D))), ((V)(5D)), ((V)(18D)), GL_30, Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("op", ((V)(0.32))).V)), Call(cyl_14, V.Undef, ((V)(18D)), ((V)(0.4)), ((V)((-2D))), ((V)(4.5)), ((V)(13D)), ((V)("#fffdf6")), NewObj(1).Put("n", ((V)(16D))).V), Call(cyl_14, V.Undef, ((V)(18D)), ((V)(13.4)), ((V)((-2D))), ((V)(4.3)), ((V)(0.4)), ((V)("#ffffff")), NewObj(1).Put("n", ((V)(14D))).V));
return o_1548;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_24, "fPizza", Fn((V _arrowThis1572, int _argc1565, V S_1571, V _a1568, V _a1569, V _a1570, V[] _rest1566) => {
return NewObj(4).Put("w", ((V)(70D))).Put("d", ((V)(54D))).Put("build", Fn((V _arrowThis1580, int _argc1573, V P_1579, V _a1576, V _a1577, V _a1578, V[] _rest1574) => {
V o_1581 = default;
o_1581 = Arr(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(25D)), ((V)(2.4)), ((V)("#c8925a")), Call(wd_35, V.Undef, NewObj(1).Put("n", ((V)(26D))).V)), Call(box_12, V.Undef, ((V)(30D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(2.4)), ((V)(8D)), ((V)("#c8925a")), Call(wd_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(2.4)), ((V)(0D)), ((V)(21D)), ((V)(1.4)), ((V)("#e8c07a")), NewObj(1).Put("n", ((V)(26D))).V), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(2.4)), ((V)(0D)), ((V)(21.6)), ((V)(21.6)), ((V)(3.6)), ((V)(3.4)), ((V)(0D)), ((V)((2D * PI_31))), ((V)("#d6974a")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(26D))).V)));
Invoke(o_1581, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(3.8)), ((V)(0D)), ((V)(18.2)), ((V)(0.5)), ((V)("#d9483b")), NewObj(1).Put("n", ((V)(24D))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(4.3)), ((V)(0D)), ((V)(17.6)), ((V)(0.6)), ((V)("#f8d872")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)));
Invoke(Arr(Arr(((V)((-8D))), ((V)((-6D)))), Arr(((V)(6D)), ((V)((-9D)))), Arr(((V)(10D)), ((V)(3D))), Arr(((V)((-2D))), ((V)(8D))), Arr(((V)((-11D))), ((V)(5D))), Arr(((V)(2D)), ((V)((-1D)))), Arr(((V)(12D)), ((V)((-4D)))), Arr(((V)((-5D))), ((V)((-12D))))), "forEach", Fn((V _arrowThis1593, int _argc1582, V _a1584, V _a1585, V _a1586, V _a1587, V[] _rest1583) => {
V x_1590 = default;
V z_1592 = default;
{ V _t1588 = ListOf(_a1584);
{ V _t1589 = GetIdx(_t1588, 0D);
x_1590 = _t1589; }
{ V _t1591 = GetIdx(_t1588, 1D);
z_1592 = _t1591; }
}
return Invoke(o_1581, "push", Call(cyl_14, V.Undef, x_1590, ((V)(4.9)), z_1592, ((V)(2.8)), ((V)(0.6)), ((V)("#b8382e")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-4D))), ((V)((-3D)))), Arr(((V)(8D)), ((V)(7D))), Arr(((V)((-12D))), ((V)((-2D)))), Arr(((V)(4D)), ((V)(12D)))), "forEach", Fn((V _arrowThis1606, int _argc1594, V _a1596, V i_1600, V _a1598, V _a1599, V[] _rest1595) => {
V x_1603 = default;
V z_1605 = default;
{ V _t1601 = ListOf(_a1596);
{ V _t1602 = GetIdx(_t1601, 0D);
x_1603 = _t1602; }
{ V _t1604 = GetIdx(_t1601, 1D);
z_1605 = _t1604; }
}
return Invoke(o_1581, "push", Call(ball_15, V.Undef, x_1603, ((V)(5D)), z_1605, ((V)(1.8)), ((V)("#3f8a3a")), NewObj(5).Put("sx", ((V)(1.5))).Put("sy", ((V)(0.25))).Put("k", ((V)(2D))).Put("n", ((V)(8D))).Put("yaw", i_1600).V));
}, 2, "", true));
Invoke(Arr(Arr(((V)(0D)), ((V)((-14D)))), Arr(((V)((-14D))), ((V)(9D)))), "forEach", Fn((V _arrowThis1618, int _argc1607, V _a1609, V _a1610, V _a1611, V _a1612, V[] _rest1608) => {
V x_1615 = default;
V z_1617 = default;
{ V _t1613 = ListOf(_a1609);
{ V _t1614 = GetIdx(_t1613, 0D);
x_1615 = _t1614; }
{ V _t1616 = GetIdx(_t1613, 1D);
z_1617 = _t1616; }
}
return Invoke(o_1581, "push", Call(ball_15, V.Undef, x_1615, ((V)(4.8)), z_1617, ((V)(1.6)), ((V)("#3a3a3a")), NewObj(3).Put("sy", ((V)(0.4))).Put("k", ((V)(2D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
return o_1581;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1626, int _argc1619, V c_1625, V _a1622, V _a1623, V _a1624, V[] _rest1620) => {
JsStrBuf f_1627 = null;
f_1627 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"").V(Call(planeH_46, V.Undef, Get(c_1625, "p"), ((V)(4.95)))).S("\">").End());
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "forEach", Fn((V _arrowThis1635, int _argc1628, V i_1634, V _a1631, V _a1632, V _a1633, V[] _rest1629) => {
double a_1636 = 0;
a_1636 = ((ToNum(i_1634) * PI_31) / 4D);
f_1627.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((FdLibm.Cos(a_1636) * 18D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((FdLibm.Sin(a_1636) * 18D))))).S("L").V(Call(f1_23, V.Undef, ((V)(((-FdLibm.Cos(a_1636)) * 18D))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-FdLibm.Sin(a_1636)) * 18D))))).S("\" stroke=\"#c98a3a\" stroke-width=\"0.6\" opacity=\"0.7\"/>");
return default;
}, 1, "", true));
f_1627.S("</g>");
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S(f_1627.Str).V(Call(steam_51, V.Undef, c_1625, ((V)((-3D))), ((V)(6D)), ((V)(0D)), ((V)(0.7)), ((V)(3D)))).End()))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
arcPoly_70 = Fn((V _arrowThis1654, int _argc1637, V x_1643, V y_1644, V z_1645, V R_1646, V[] _rest1638) => {
V pts_1655 = default;
V th_1647 = default;
V a0_1648 = default;
V a1_1649 = default;
V h_1650 = default;
V sc0_1651 = default;
V col_1652 = default;
V o_1653 = default;
th_1647 = (_argc1637 > 4 ? _rest1638[0] : V.Undef);
a0_1648 = (_argc1637 > 5 ? _rest1638[1] : V.Undef);
a1_1649 = (_argc1637 > 6 ? _rest1638[2] : V.Undef);
h_1650 = (_argc1637 > 7 ? _rest1638[3] : V.Undef);
sc0_1651 = (_argc1637 > 8 ? _rest1638[4] : V.Undef);
col_1652 = (_argc1637 > 9 ? _rest1638[5] : V.Undef);
o_1653 = (_argc1637 > 10 ? _rest1638[6] : V.Undef);
pts_1655 = Arr();
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis1663, int _argc1656, V i_1662, V _a1659, V _a1660, V _a1661, V[] _rest1657) => {
V t_1664 = default;
t_1664 = Add(a0_1648, ((V)((((ToNum(a1_1649) - ToNum(a0_1648)) * ToNum(i_1662)) / 4D))));
Invoke(pts_1655, "push", Arr(((V)((ToNum(R_1646) * FdLibm.Cos(ToNum(t_1664))))), ((V)((ToNum(R_1646) * FdLibm.Sin(ToNum(t_1664)))))));
return default;
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis1672, int _argc1665, V i_1671, V _a1668, V _a1669, V _a1670, V[] _rest1666) => {
double t_1673 = 0;
t_1673 = (ToNum(a1_1649) - (((ToNum(a1_1649) - ToNum(a0_1648)) * ToNum(i_1671)) / 4D));
Invoke(pts_1655, "push", Arr(((V)(((ToNum(R_1646) - ToNum(th_1647)) * FdLibm.Cos(t_1673)))), ((V)(((ToNum(R_1646) - ToNum(th_1647)) * FdLibm.Sin(t_1673))))));
return default;
}, 1, "", true));
return Call(solid_11, V.Undef, Object_assign(NewObj(7).Put("ax", ((V)("y"))).Put("sh", ((V)("poly"))).Put("c", Arr(x_1643, z_1645)).Put("pts", pts_1655).Put("rings", Arr(Arr(y_1644, ((V)(0D)), sc0_1651), Arr(Add(y_1644, h_1650), ((V)(0D)), ((V)(1D))))).Put("col", col_1652).Put("mat", ((V)("paint"))).V, (o_1653 is var _t1674 && Truthy(_t1674) ? _t1674 : NewObj(0).V)));
return default;
}, 11, "", true);
bucket_71 = Fn((V _arrowThis1688, int _argc1675, V o_1681, V x_1682, V y_1683, V z_1684, V[] _rest1676) => {
V R_1685 = default;
V h_1686 = default;
V seed_1687 = default;
R_1685 = (_argc1675 > 4 ? _rest1676[0] : V.Undef);
h_1686 = (_argc1675 > 5 ? _rest1676[1] : V.Undef);
seed_1687 = (_argc1675 > 6 ? _rest1676[2] : V.Undef);
Call(rep_39, V.Undef, ((V)(14D)), Fn((V _arrowThis1696, int _argc1689, V i_1695, V _a1692, V _a1693, V _a1694, V[] _rest1690) => {
return Invoke(o_1681, "push", Call(arcPoly_70, V.Undef, x_1682, y_1683, z_1684, R_1685, ((V)(1.2)), ((V)((((ToNum(i_1695) / 14D) * 2D) * PI_31))), ((V)((((ToNum(Add(i_1695, ((V)(1D)))) / 14D) * 2D) * PI_31))), h_1686, ((V)(0.74)), ((V)((NumTruthy((ToNum(i_1695) % 2D)) ? "#ffffff" : "#d9363b")))));
}, 1, "", true));
Invoke(o_1681, "push", Call(cyl_14, V.Undef, x_1682, Add(y_1683, ((V)(0.2))), z_1684, ((V)((ToNum(R_1685) - 1.1))), ((V)((ToNum(h_1686) - 0.6))), ((V)("#f8e8b8")), NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.74))), Arr(((V)((ToNum(h_1686) - 0.6))), ((V)(0D)), ((V)(1D))))).V), Call(arcW_18, V.Undef, x_1682, ((V)((ToNum(Add(y_1683, h_1686)) - 2.4))), z_1684, Add(R_1685, ((V)(0.5))), Add(R_1685, ((V)(0.5))), ((V)(1.6)), ((V)(2.4)), ((V)(0D)), ((V)((2D * PI_31))), ((V)("#d9363b")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)));
Call(heap_60, V.Undef, o_1681, x_1682, Add(y_1683, h_1686), z_1684, ((V)((ToNum(R_1685) * 0.92))), ((V)((ToNum(R_1685) * 0.92))), ((V)((ToNum(R_1685) * 0.42))), ((V)(22D)), seed_1687, ((V)(0.9)));
return default;
}, 7, "", true);
Set(N_24, "popBucket", Fn((V _arrowThis1704, int _argc1697, V S_1703, V _a1700, V _a1701, V _a1702, V[] _rest1698) => {
return NewObj(3).Put("w", ((V)(56D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis1712, int _argc1705, V P_1711, V _a1708, V _a1709, V _a1710, V[] _rest1706) => {
V o_1713 = default;
o_1713 = Arr();
Call(bucket_71, V.Undef, o_1713, ((V)((-6D))), ((V)(0D)), ((V)(0D)), ((V)(13D)), ((V)(24D)), ((V)(JsStrBuf.Begin().S("pb").V(Get(S_1703, "nm")).End())));
Invoke(Arr(Arr(((V)(14D)), ((V)(10D)), ((V)(0.4))), Arr(((V)(20D)), ((V)(2D)), ((V)((-0.3))))), "forEach", Fn((V _arrowThis1727, int _argc1714, V _a1716, V _a1717, V _a1718, V _a1719, V[] _rest1715) => {
V x_1722 = default;
V z_1724 = default;
V yw_1726 = default;
{ V _t1720 = ListOf(_a1716);
{ V _t1721 = GetIdx(_t1720, 0D);
x_1722 = _t1721; }
{ V _t1723 = GetIdx(_t1720, 1D);
z_1724 = _t1723; }
{ V _t1725 = GetIdx(_t1720, 2D);
yw_1726 = _t1725; }
}
return Invoke(o_1713, "push", Call(box_12, V.Undef, x_1722, ((V)(0D)), z_1724, ((V)(16D)), ((V)(0.6)), ((V)(7D)), ((V)("#f2932c")), NewObj(2).Put("yaw", yw_1726).Put("r", ((V)(0.6))).V), Call(box_12, V.Undef, ((V)((ToNum(x_1722) - 4D))), ((V)(0.6)), z_1724, ((V)(0.6)), ((V)(0.2)), ((V)(6.6)), ((V)("#ffffff")), NewObj(3).Put("yaw", yw_1726).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis1735, int _argc1728, V i_1734, V _a1731, V _a1732, V _a1733, V[] _rest1729) => {
return InvokeSpread(o_1713, "push", new ArrBuilder().Spread(Call(kern_59, V.Undef, ((V)((8D + (ToNum(i_1734) * 3.2)))), ((V)(1.2)), ((V)((14D - (ToNum(i_1734) * 1.6)))), ((V)(0.9)), i_1734)).V);
}, 1, "", true));
return o_1713;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_24, "candyBox", Fn((V _arrowThis1743, int _argc1736, V S_1742, V _a1739, V _a1740, V _a1741, V[] _rest1737) => {
return NewObj(3).Put("w", ((V)(66D))).Put("d", ((V)(44D))).Put("build", Fn((V _arrowThis1751, int _argc1744, V P_1750, V _a1747, V _a1748, V _a1749, V[] _rest1745) => {
V o_1752 = default;
V CC_1753 = default;
o_1752 = Arr(Call(box_12, V.Undef, ((V)((-10D))), ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(9D)), ((V)(20D)), ((V)("#d9363b")), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slab_16, V.Undef, ((V)((-10D))), ((V)(9D)), ((V)((-9.6))), ((V)(30D)), ((V)(11D)), ((V)(0.8)), ((V)("#f2c94c")), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(slab_16, V.Undef, ((V)((-10D))), ((V)(2D)), ((V)(10.2)), ((V)(26D)), ((V)(4.4)), ((V)(0.4)), ((V)("#f2c94c")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V));
CC_1753 = Arr(((V)("#d9363b")), ((V)("#f2c94c")), ((V)("#3f7fc8")), ((V)("#4f9a4a")), ((V)("#ff9d4a")), ((V)("#8a4f2c")));
Call(rep_39, V.Undef, ((V)(14D)), Fn((V _arrowThis1761, int _argc1754, V i_1760, V _a1757, V _a1758, V _a1759, V[] _rest1755) => {
return Invoke(o_1752, "push", Call(ball_15, V.Undef, ((V)(((-21D) + ((ToNum(i_1760) % 7D) * 3.6)))), ((V)(9D)), ((V)((((-6D) + (System.Math.Floor((ToNum(i_1760) / 7D)) * 5D)) + (ToNum(i_1760) % 2D)))), ((V)(1.9)), GetIdx(CC_1753, (ToNum(i_1760) % 6D)), NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V));
}, 1, "", true));
Invoke(Arr(Arr(((V)(8D)), ((V)(12D))), Arr(((V)(11D)), ((V)(8D))), Arr(((V)(4D)), ((V)(16D)))), "forEach", Fn((V _arrowThis1774, int _argc1762, V _a1764, V i_1768, V _a1766, V _a1767, V[] _rest1763) => {
V x_1771 = default;
V z_1773 = default;
{ V _t1769 = ListOf(_a1764);
{ V _t1770 = GetIdx(_t1769, 0D);
x_1771 = _t1770; }
{ V _t1772 = GetIdx(_t1769, 1D);
z_1773 = _t1772; }
}
return Invoke(o_1752, "push", Call(ball_15, V.Undef, x_1771, ((V)(0D)), z_1773, ((V)(1.9)), GetIdx(CC_1753, (ToNum(Add(i_1768, ((V)(2D)))) % 6D)), NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V));
}, 2, "", true));
Invoke(o_1752, "push", Call(box_12, V.Undef, ((V)(22D)), ((V)(0D)), ((V)(0D)), ((V)(24D)), ((V)(0.8)), ((V)(9D)), ((V)("#f4f1ea")), NewObj(1).Put("r", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(16.5)), ((V)(0.8)), ((V)(0.4)), ((V)(8D)), ((V)(0.3)), ((V)(5D)), ((V)("#e2554a")), NewObj(2).Put("r", ((V)(1D))).Put("op", ((V)(0.85))).V), Call(box_12, V.Undef, ((V)(27.5)), ((V)(0.8)), ((V)(0.4)), ((V)(8D)), ((V)(0.3)), ((V)(5D)), ((V)("#4fc8e0")), NewObj(2).Put("r", ((V)(1D))).Put("op", ((V)(0.85))).V), Call(box_12, V.Undef, ((V)(22D)), ((V)(0.8)), ((V)((-6D))), ((V)(24D)), ((V)(0.6)), ((V)(2D)), ((V)("#f4f1ea")), NewObj(1).Put("r", ((V)(0.4))).V));
return o_1752;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_24, "cereal", Fn((V _arrowThis1782, int _argc1775, V S_1781, V _a1778, V _a1779, V _a1780, V[] _rest1776) => {
return NewObj(3).Put("w", ((V)(66D))).Put("d", ((V)(50D))).Put("build", Fn((V _arrowThis1790, int _argc1783, V P_1789, V _a1786, V _a1787, V _a1788, V[] _rest1784) => {
V o_1791 = default;
o_1791 = Arr(Call(box_12, V.Undef, ((V)((-16D))), ((V)(0D)), ((V)((-4D))), ((V)(24D)), ((V)(36D)), ((V)(10D)), ((V)("#f2c14a")), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slab_16, V.Undef, ((V)((-16D))), ((V)(25D)), ((V)(1.2)), ((V)(22D)), ((V)(7D)), ((V)(0.4)), ((V)("#d9483b")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V), Call(disc_19, V.Undef, ((V)((-16D))), ((V)(13D)), ((V)(1.2)), ((V)(7D)), ((V)(0.4)), ((V)("#ffffff")), NewObj(1).Put("noOut", ((V)(1D))).V));
Invoke(Arr(((V)("#ff6ad5")), ((V)("#6ac8ff")), ((V)("#a6f06a")), ((V)("#ff9d4a"))), "forEach", Fn((V _arrowThis1800, int _argc1792, V cc_1798, V i_1799, V _a1796, V _a1797, V[] _rest1793) => {
return Invoke(o_1791, "push", Call(disc_19, V.Undef, ((V)(((-19D) + ((ToNum(i_1799) % 2D) * 6D)))), ((V)((11D + (System.Math.Floor((ToNum(i_1799) / 2D)) * 4D)))), ((V)(1.7)), ((V)(1.6)), ((V)(0.3)), cc_1798, NewObj(1).Put("noOut", ((V)(1D))).V));
}, 2, "", true));
Invoke(o_1791, "push", Call(cyl_14, V.Undef, ((V)((-4D))), ((V)(0D)), ((V)(16D)), ((V)(10D)), ((V)(6D)), ((V)("#6ac8ff")), Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.62))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_14, V.Undef, ((V)((-4D))), ((V)(5.4)), ((V)(16D)), ((V)(9.2)), ((V)(0.6)), ((V)("#fffdf6")), NewObj(1).Put("n", ((V)(20D))).V));
Call(rep_39, V.Undef, ((V)(11D)), Fn((V _arrowThis1808, int _argc1801, V i_1807, V _a1804, V _a1805, V _a1806, V[] _rest1802) => {
double a_1809 = 0;
double r_1810 = 0;
a_1809 = (ToNum(i_1807) * 2.3);
r_1810 = (2D + ((ToNum(i_1807) % 4D) * 1.6));
Invoke(o_1791, "push", Call(arcW_18, V.Undef, ((V)(((-4D) + (FdLibm.Cos(a_1809) * r_1810)))), ((V)(6D)), ((V)((16D + (FdLibm.Sin(a_1809) * r_1810)))), ((V)(1.7)), ((V)(1.7)), ((V)(0.9)), ((V)(0.9)), ((V)(0D)), ((V)((2D * PI_31))), GetIdx(Arr(((V)("#ff6ad5")), ((V)("#ffd66b")), ((V)("#a6f06a")), ((V)("#ff9d4a"))), (ToNum(i_1807) % 4D)), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
return default;
}, 1, "", true));
Invoke(o_1791, "push", Call(box_12, V.Undef, ((V)(5D)), ((V)(6.4)), ((V)(18D)), ((V)(12D)), ((V)(0.6)), ((V)(1.4)), CH_28, Call(mt_34, V.Undef, NewObj(2).Put("yaw", ((V)((-0.5)))).Put("r", ((V)(0.5))).V)), Call(ball_15, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)(19D)), ((V)(2D)), CH_28, Call(mt_34, V.Undef, NewObj(3).Put("sy", ((V)(0.35))).Put("k", ((V)(2D))).Put("n", ((V)(8D))).V)));
Invoke(o_1791, "push", Call(cyl_14, V.Undef, ((V)(16D)), ((V)(0D)), ((V)((-2D))), ((V)(5.4)), ((V)(18D)), ((V)("#7ad08a")), NewObj(3).Put("n", ((V)(16D))).Put("op", ((V)(0.85))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))), Arr(((V)(18D)), ((V)(0D)), ((V)(0.5))))).V), Call(cyl_14, V.Undef, ((V)(16D)), ((V)(18D)), ((V)((-2D))), ((V)(2D)), ((V)(3D)), ((V)("#ffffff")), NewObj(1).Put("n", ((V)(10D))).V), Call(box_12, V.Undef, ((V)(18D)), ((V)(20D)), ((V)((-2D))), ((V)(5D)), ((V)(1.4)), ((V)(1.6)), ((V)("#ffffff")), NewObj(1).Put("r", ((V)(0.6))).V), Call(slab_16, V.Undef, ((V)(16D)), ((V)(5D)), ((V)(3.4)), ((V)(6D)), ((V)(7D)), ((V)(0.3)), ((V)("#ffffff")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V));
return o_1791;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_24, "microPop", Fn((V _arrowThis1818, int _argc1811, V S_1817, V _a1814, V _a1815, V _a1816, V[] _rest1812) => {
return NewObj(4).Put("w", ((V)(60D))).Put("d", ((V)(54D))).Put("build", Fn((V _arrowThis1826, int _argc1819, V P_1825, V _a1822, V _a1823, V _a1824, V[] _rest1820) => {
V o_1827 = default;
V wdc_1828 = default;
o_1827 = Arr();
wdc_1828 = ((V)("#b98a58"));
Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis1836, int _argc1829, V i_1835, V _a1832, V _a1833, V _a1834, V[] _rest1830) => {
double a_1837 = 0;
a_1837 = ((((ToNum(i_1835) / 3D) * 2D) * PI_31) + 0.5);
Invoke(o_1827, "push", Call(cyl_14, V.Undef, ((V)((FdLibm.Cos(a_1837) * 13D))), ((V)(0D)), ((V)((FdLibm.Sin(a_1837) * 13D))), ((V)(1.8)), ((V)(38D)), wdc_1828, Call(wd_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
return default;
}, 1, "", true));
Invoke(o_1827, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(0D)), ((V)(19D)), ((V)(4D)), wdc_1828, Call(wd_35, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(0D)), ((V)(44D)), ((V)(26D)), ((V)(30D)), ((V)("#ece8e0")), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(slab_16, V.Undef, ((V)((-6D))), ((V)(46D)), ((V)(15.2)), ((V)(28D)), ((V)(18D)), ((V)(0.6)), ((V)("#2c2d31")), NewObj(2).Put("r", ((V)(2D))).Put("op", ((V)(0.9))).V), Call(slab_16, V.Undef, ((V)((-6D))), ((V)(47D)), ((V)(15.6)), ((V)(24D)), ((V)(15D)), ((V)(0.2)), ((V)("#ffd66b")), NewObj(3).Put("r", ((V)(2D))).Put("op", ((V)(0.18))).Put("noOut", ((V)(1D))).V), Call(slab_16, V.Undef, ((V)(14D)), ((V)(46D)), ((V)(15.2)), ((V)(9D)), ((V)(18D)), ((V)(0.6)), ((V)("#d5dde2")), NewObj(1).Put("r", ((V)(1D))).V));
Call(rep_39, V.Undef, ((V)(4D)), Fn((V _arrowThis1845, int _argc1838, V i_1844, V _a1841, V _a1842, V _a1843, V[] _rest1839) => {
return Invoke(o_1827, "push", Call(ball_15, V.Undef, ((V)(14D)), ((V)((58D - (ToNum(i_1844) * 3.4)))), ((V)(15.8)), ((V)(0.9)), ((V)((Truthy(i_1844) ? "#9aa1a6" : "#d9483b"))), NewObj(2).Put("k", ((V)(2D))).Put("n", ((V)(6D))).V));
}, 1, "", true));
Invoke(o_1827, "push", Call(box_12, V.Undef, ((V)(4D)), ((V)(68D)), ((V)((-2D))), ((V)(22D)), ((V)(7D)), ((V)(14D)), ((V)("#f4f1ea")), NewObj(2).Put("r", ((V)(4D))).Put("soft", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(4D)), ((V)(68D)), ((V)(5.2)), ((V)(22D)), ((V)(6.6)), ((V)(0.3)), ((V)("#d9483b")), NewObj(2).Put("r", ((V)(2D))).Put("noOut", ((V)(1D))).V), Call(ball_15, V.Undef, ((V)((-2D))), ((V)(74.6)), ((V)((-1D))), ((V)(3D)), ((V)("#7a4a28")), NewObj(4).Put("sy", ((V)(0.3))).Put("k", ((V)(2D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V), Call(ball_15, V.Undef, ((V)(9D)), ((V)(74.6)), ((V)((-4D))), ((V)(2.2)), ((V)("#5a3a20")), NewObj(4).Put("sy", ((V)(0.3))).Put("k", ((V)(2D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V));
return o_1827;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1853, int _argc1846, V c_1852, V _a1849, V _a1850, V _a1851, V[] _rest1847) => {
return NewObj(1).Put("front", Call(steam_51, V.Undef, c_1852, ((V)(4D)), ((V)(76D)), ((V)((-2D))), ((V)(0.8)), ((V)(3D)), ((V)("#9aa1a6")))).V;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "popper", Fn((V _arrowThis1861, int _argc1854, V S_1860, V _a1857, V _a1858, V _a1859, V[] _rest1855) => {
return NewObj(4).Put("w", ((V)(52D))).Put("d", ((V)(64D))).Put("build", Fn((V _arrowThis1869, int _argc1862, V P_1868, V _a1865, V _a1866, V _a1867, V[] _rest1863) => {
V o_1870 = default;
o_1870 = Arr(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-6D))), ((V)(13D)), ((V)(16D)), ((V)("#d9363b")), Call(pt_38, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(16D)), ((V)(0D)), ((V)(0.88))))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(6.6)), ((V)(6D)), ((V)(3D)), ((V)(2D)), ((V)("#ffffff")), NewObj(1).Put("r", ((V)(1D))).V));
Invoke(o_1870, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(7D)), ((V)(10D)), ((V)(4D)), ((V)(12D)), ((V)("#d9363b")), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(16D)), ((V)((-6D))), ((V)(11D)), ((V)(20D)), GL_30, Call(cer_36, V.Undef, NewObj(3).Put("n", ((V)(20D))).Put("op", ((V)(0.22))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))), Arr(((V)(20D)), ((V)(0D)), ((V)(0.55))))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(36D)), ((V)((-6D))), ((V)(6D)), ((V)(4D)), ((V)("#f2c94c")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(ball_15, V.Undef, ((V)(0D)), ((V)(40D)), ((V)((-6D))), ((V)(2D)), ((V)("#ffffff")), NewObj(1).Put("k", ((V)(3D))).V));
Call(heap_60, V.Undef, o_1870, ((V)(0D)), ((V)(18D)), ((V)((-6D))), ((V)(9D)), ((V)(9D)), ((V)(3D)), ((V)(10D)), ((V)("ppd")), ((V)(0.8)));
Invoke(o_1870, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(15D)), ((V)(9D)), ((V)("#ffffff")), Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.62))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V)), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(20D)), ((V)(15.2)), ((V)(15.2)), ((V)(0.8)), ((V)(1.6)), ((V)(0D)), ((V)((2D * PI_31))), ((V)("#d9363b")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)));
Call(heap_60, V.Undef, o_1870, ((V)(0D)), ((V)(9D)), ((V)(20D)), ((V)(13.6)), ((V)(13.6)), ((V)(6D)), ((V)(22D)), ((V)("ppb")), ((V)(0.9)));
return o_1870;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1878, int _argc1871, V c_1877, V _a1874, V _a1875, V _a1876, V[] _rest1872) => {
JsStrBuf f_1879 = null;
f_1879 = new JsStrBuf("");
Call(rep_39, V.Undef, ((V)(6D)), Fn((V _arrowThis1887, int _argc1880, V i_1886, V _a1883, V _a1884, V _a1885, V[] _rest1881) => {
V a_1888 = default;
V b_1889 = default;
V d_1890 = default;
double bg_1891 = 0;
V mx_1892 = default;
V my_1893 = default;
a_1888 = Invoke(c_1877, "p", ((V)(0D)), ((V)(16D)), ((V)(13D)));
b_1889 = Invoke(c_1877, "p", ((V)(((ToNum(i_1886) - 2.5) * 3D))), ((V)(10D)), ((V)((20D + ((ToNum(i_1886) % 3D) * 2D)))));
d_1890 = Invoke(((V)((1.4 + ((ToNum(i_1886) % 3D) * 0.2)))), "toFixed", ((V)(1D)));
bg_1891 = (-ToNum(Invoke(((V)((ToNum(i_1886) * 0.37))), "toFixed", ((V)(2D)))));
mx_1892 = Call(f1_23, V.Undef, ((V)((ToNum(Add(GetIdx(a_1888, 0D), GetIdx(b_1889, 0D))) / 2D))));
my_1893 = Call(f1_23, V.Undef, ((V)((Min(ToNum(GetIdx(a_1888, 1D)), ToNum(GetIdx(b_1889, 1D))) - (10D * ToNum(Get(c_1877, "k")))))));
f_1879.S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(Get(c_1877, "k"))))))).S("\" fill=\"#fff6dc\" stroke=\"#e8c870\" stroke-width=\"0.3\"><animateMotion dur=\"").V(d_1890).S("s\" begin=\"").N(bg_1891).S("s\" repeatCount=\"indefinite\" path=\"M").V(Call(P2_42, V.Undef, a_1888)).S("Q").V(mx_1892).S(" ").V(my_1893).S(" ").V(Call(P2_42, V.Undef, b_1889)).S("\"/>").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("1;1;0")), d_1890, ((V)(bg_1891)))).S("</circle>");
return default;
}, 1, "", true));
return NewObj(1).Put("front", ((V)(f_1879.Str))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "popCart", Fn((V _arrowThis1901, int _argc1894, V S_1900, V _a1897, V _a1898, V _a1899, V[] _rest1895) => {
V royal_1902 = default;
V conc_1903 = default;
V fr_1904 = default;
V body_1905 = default;
double CX_1906 = 0;
double BH_1907 = 0;
double BY_1908 = 0;
double Y0_1909 = 0;
double W_1910 = 0;
double D_1911 = 0;
double H_1912 = 0;
royal_1902 = (!(!(Truthy(Get(S_1900, "royal")))) ? V.True : V.False);
conc_1903 = (!(!(Truthy(Get(S_1900, "conc")))) ? V.True : V.False);
fr_1904 = (Truthy(royal_1902) ? GOLD_27 : (Truthy(conc_1903) ? GOLD_27 : ((V)("#d5dde2"))));
body_1905 = ((V)((Truthy(royal_1902) ? "#7f2030" : (Truthy(conc_1903) ? "#f2efea" : "#d9363b"))));
CX_1906 = (Truthy(conc_1903) ? (-24D) : 0D);
BH_1907 = (Truthy(conc_1903) ? 46D : 40D);
BY_1908 = (Truthy(conc_1903) ? 0D : (Truthy(royal_1902) ? 10D : 7D));
Y0_1909 = (BY_1908 + BH_1907);
W_1910 = 46D;
D_1911 = 34D;
H_1912 = 42D;
return NewObj(5).Put("w", ((V)((Truthy(conc_1903) ? 116D : (Truthy(royal_1902) ? 84D : 64D))))).Put("d", ((V)((Truthy(conc_1903) ? 50D : 46D)))).Put("glow", Fn((V _arrowThis1919, int _argc1913, V _a1915, V _a1916, V _a1917, V _a1918, V[] _rest1914) => {
return NewObj(3).Put("y", ((V)((Y0_1909 + 26D)))).Put("r", ((V)(44D))).Put("c", ((V)("url(#gWarm)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1927, int _argc1920, V P_1926, V _a1923, V _a1924, V _a1925, V[] _rest1921) => {
V o_1928 = default;
o_1928 = Arr();
if (Truthy(conc_1903)) {
V R_1929 = default;
Invoke(o_1928, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(112D)), ((V)(4D)), ((V)(46D)), ((V)("#1d1d20")), NewObj(1).Put("r", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(110D)), ((V)((BH_1907 - 6D))), ((V)(44D)), body_1905, Call(cer_36, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((BH_1907 - 2D))), ((V)(0D)), ((V)(114D)), ((V)(2D)), ((V)(48D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Invoke(Arr(((V)((-36D))), ((V)(0D)), ((V)(36D))), "forEach", Fn((V _arrowThis1937, int _argc1930, V x_1936, V _a1933, V _a1934, V _a1935, V[] _rest1931) => {
return Invoke(o_1928, "push", Call(slab_16, V.Undef, x_1936, ((V)(9D)), ((V)(22.4)), ((V)(30D)), ((V)((BH_1907 - 18D))), ((V)(0.8)), Call(shade_21, V.Undef, body_1905, ((V)(0.95))), Call(cer_36, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, x_1936, ((V)(10D)), ((V)(23D)), ((V)(30D)), ((V)(0.6)), ((V)(0.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
R_1929 = Call(rng_50, V.Undef, ((V)("conc")));
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis1944, int _argc1938, V _a1940, V _a1941, V _a1942, V _a1943, V[] _rest1939) => {
return Invoke(o_1928, "push", Call(box_12, V.Undef, ((V)(((ToNum(Call(R_1929, V.Undef)) - 0.5) * 90D))), ((V)((6D + (ToNum(Call(R_1929, V.Undef)) * 30D)))), ((V)(22.2)), ((V)((20D + (ToNum(Call(R_1929, V.Undef)) * 20D)))), ((V)(0.5)), ((V)(0.2)), ((V)("#c9b98a")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 0, "", true));
} else {
if (Truthy(royal_1902)) {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1952, int _argc1945, V sg_1951, V _a1948, V _a1949, V _a1950, V[] _rest1946) => {
double x_1953 = 0;
x_1953 = (ToNum(sg_1951) * 30D);
Invoke(o_1928, "push", Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(13D)))).Put("a", ((V)(13D))).Put("b", ((V)(13D))).Put("n", ((V)(18D))).Put("rings", Arr(Arr(((V)((x_1953 - 1.6))), ((V)(0D))), Arr(((V)((x_1953 + 1.6))), ((V)(0D))))).Put("col", ((V)("#2c2420"))).Put("mat", ((V)("wood"))).V), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(13D)))).Put("a", ((V)(11.4))).Put("b", ((V)(11.4))).Put("n", ((V)(18D))).Put("rings", Arr(Arr(((V)(((x_1953 + (ToNum(sg_1951) * 1.7)) - 0.1))), ((V)(0D))), Arr(((V)(((x_1953 + (ToNum(sg_1951) * 1.7)) + 0.1))), ((V)(0D))))).Put("col", GOLD_27).Put("mat", ((V)("metal"))).V), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(13D)))).Put("a", ((V)(2.4))).Put("b", ((V)(2.4))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)((x_1953 - 3D))), ((V)(0D))), Arr(((V)((x_1953 + 3D))), ((V)(0D))))).Put("col", GOLD_27).Put("mat", ((V)("metal"))).V));
Call(rep_39, V.Undef, ((V)(6D)), Fn((V _arrowThis1961, int _argc1954, V i_1960, V _a1957, V _a1958, V _a1959, V[] _rest1955) => {
double a_1962 = 0;
a_1962 = (((ToNum(i_1960) / 6D) * 2D) * PI_31);
Invoke(Arr(((V)(4.4)), ((V)(7.4)), ((V)(10.2))), "forEach", Fn((V _arrowThis1970, int _argc1963, V rr_1969, V _a1966, V _a1967, V _a1968, V[] _rest1964) => {
return Invoke(o_1928, "push", Call(ball_15, V.Undef, ((V)((x_1953 + (ToNum(sg_1951) * 1.9)))), ((V)(((13D + (FdLibm.Sin(a_1962) * ToNum(rr_1969))) - 0.9))), ((V)((FdLibm.Cos(a_1962) * ToNum(rr_1969)))), ((V)(0.9)), GOLD_27, Call(mt_34, V.Undef, NewObj(3).Put("k", ((V)(2D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
} else {
Invoke(Arr(Arr(((V)((-22D))), ((V)((-14D)))), Arr(((V)(22D)), ((V)((-14D)))), Arr(((V)((-22D))), ((V)(14D))), Arr(((V)(22D)), ((V)(14D)))), "forEach", Fn((V _arrowThis1982, int _argc1971, V _a1973, V _a1974, V _a1975, V _a1976, V[] _rest1972) => {
V x_1979 = default;
V z_1981 = default;
{ V _t1977 = ListOf(_a1973);
{ V _t1978 = GetIdx(_t1977, 0D);
x_1979 = _t1978; }
{ V _t1980 = GetIdx(_t1977, 1D);
z_1981 = _t1980; }
}
return Invoke(o_1928, "push", Call(solid_11, V.Undef, NewObj(8).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(z_1981, ((V)(4D)))).Put("a", ((V)(4D))).Put("b", ((V)(4D))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((ToNum(x_1979) - 1.5))), ((V)(0D))), Arr(Add(x_1979, ((V)(1.5))), ((V)(0D))))).Put("col", ((V)("#1d1d20"))).V), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(z_1981, ((V)(4D)))).Put("a", ((V)(1.6))).Put("b", ((V)(1.6))).Put("n", ((V)(8D))).Put("rings", Arr(Arr(((V)((ToNum(x_1979) - 1.7))), ((V)(0D))), Arr(Add(x_1979, ((V)(1.7))), ((V)(0D))))).Put("col", CH_28).Put("mat", ((V)("metal"))).V));
}, 1, "", true));
}
Invoke(o_1928, "push", Call(box_12, V.Undef, ((V)(CX_1906)), ((V)(BY_1908)), ((V)(0D)), ((V)(52D)), ((V)(BH_1907)), ((V)(38D)), body_1905, Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(CX_1906)), ((V)((Y0_1909 - 3D))), ((V)(0D)), ((V)(54D)), ((V)(3D)), ((V)(40D)), fr_1904, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slab_16, V.Undef, ((V)(CX_1906)), ((V)((BY_1908 + 5D))), ((V)(19.4)), ((V)(40D)), ((V)((BH_1907 - 13D))), ((V)(0.8)), Call(shade_21, V.Undef, body_1905, ((V)(1.08))), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(CX_1906)), ((V)((BY_1908 + 2D))), ((V)(19.6)), ((V)(52D)), ((V)(1.4)), ((V)(0.6)), fr_1904, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
if (Truthy(royal_1902)) {
Invoke(o_1928, "push", Call(slab_16, V.Undef, ((V)(CX_1906)), ((V)((BY_1908 + 9D))), ((V)(20.2)), ((V)(30D)), ((V)((BH_1907 - 21D))), ((V)(0.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(6D))).Put("noOut", ((V)(1D))).V)), Call(slab_16, V.Undef, ((V)(CX_1906)), ((V)((BY_1908 + 11D))), ((V)(20.5)), ((V)(26D)), ((V)((BH_1907 - 25D))), ((V)(0.4)), body_1905, NewObj(2).Put("r", ((V)(5D))).Put("noOut", ((V)(1D))).V));
Invoke(Arr(Arr(((V)((-26D))), ((V)((-19D)))), Arr(((V)(26D)), ((V)((-19D)))), Arr(((V)((-26D))), ((V)(19D))), Arr(((V)(26D)), ((V)(19D)))), "forEach", Fn((V _arrowThis1994, int _argc1983, V _a1985, V _a1986, V _a1987, V _a1988, V[] _rest1984) => {
V x_1991 = default;
V z_1993 = default;
{ V _t1989 = ListOf(_a1985);
{ V _t1990 = GetIdx(_t1989, 0D);
x_1991 = _t1990; }
{ V _t1992 = GetIdx(_t1989, 1D);
z_1993 = _t1992; }
}
return Invoke(o_1928, "push", Call(ball_15, V.Undef, x_1991, ((V)((Y0_1909 - 2D))), z_1993, ((V)(2.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
}, 1, "", true));
}
}
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis2006, int _argc1995, V _a1997, V _a1998, V _a1999, V _a2000, V[] _rest1996) => {
V a_2003 = default;
V b_2005 = default;
{ V _t2001 = ListOf(_a1997);
{ V _t2002 = GetIdx(_t2001, 0D);
a_2003 = _t2002; }
{ V _t2004 = GetIdx(_t2001, 1D);
b_2005 = _t2004; }
}
return Invoke(o_1928, "push", Call(cyl_14, V.Undef, ((V)((CX_1906 + ((ToNum(a_2003) * W_1910) / 2D)))), ((V)(Y0_1909)), ((V)(((ToNum(b_2005) * D_1911) / 2D))), ((V)(1.4)), ((V)(H_1912)), fr_1904, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
Invoke(o_1928, "push", Call(box_12, V.Undef, ((V)(CX_1906)), ((V)(Y0_1909)), ((V)(0D)), ((V)((W_1910 + 4D))), ((V)(1.6)), ((V)((D_1911 + 4D))), fr_1904, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Call(heap_60, V.Undef, o_1928, ((V)((CX_1906 + 1D))), ((V)((Y0_1909 + 7D))), ((V)(2D)), ((V)(18D)), ((V)(12D)), ((V)(7D)), ((V)(26D)), ((V)(JsStrBuf.Begin().S("pc").V(Get(S_1900, "nm")).End())), ((V)(1D)));
Invoke(o_1928, "push", Call(cyl_14, V.Undef, ((V)((CX_1906 - 4D))), ((V)((Y0_1909 + 34D))), ((V)((-4D))), ((V)(0.8)), ((V)(8D)), CH_28, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)), Call(cyl_14, V.Undef, ((V)((CX_1906 - 4D))), ((V)((Y0_1909 + 23D))), ((V)((-4D))), ((V)(8.6)), ((V)(9D)), (Truthy(royal_1902) ? GOLD_27 : ((V)("#c9d3d8"))), Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.82))), Arr(((V)(4D)), ((V)(0D)), ((V)(1D))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_14, V.Undef, ((V)((CX_1906 - 4D))), ((V)((Y0_1909 + 32D))), ((V)((-4D))), ((V)(9D)), ((V)(1.2)), ((V)("#9aa3a8")), Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)));
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis2014, int _argc2007, V i_2013, V _a2010, V _a2011, V _a2012, V[] _rest2008) => {
return InvokeSpread(o_1928, "push", new ArrBuilder().Spread(Call(kern_59, V.Undef, ((V)(((CX_1906 - 4D) + ((ToNum(i_2013) - 2D) * 2.6)))), ((V)((Y0_1909 + 32.4))), ((V)(((-4D) + ((ToNum(i_2013) % 2D) * 2D)))), ((V)(0.85)), i_2013)).V);
}, 1, "", true));
Invoke(o_1928, "push", Call(ball_15, V.Undef, ((V)((CX_1906 + 12D))), ((V)((Y0_1909 + 36D))), ((V)(6D)), ((V)(2.6)), ((V)("#ffe9a0")), Call(em_25, V.Undef, NewObj(1).Put("k", ((V)(3D))).V)));
Invoke(o_1928, "push", Call(box_12, V.Undef, ((V)(CX_1906)), ((V)((Y0_1909 + 1.6))), ((V)(0D)), ((V)(W_1910)), ((V)((H_1912 - 1.6))), ((V)(D_1911)), GL_30, Call(cer_36, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("op", ((V)(0.16))).V)));
Invoke(o_1928, "push", Call(box_12, V.Undef, ((V)(CX_1906)), ((V)((Y0_1909 + H_1912))), ((V)(0D)), ((V)((W_1910 + 6D))), ((V)(3D)), ((V)((D_1911 + 6D))), fr_1904, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(CX_1906)), ((V)(((Y0_1909 + H_1912) + 3D))), ((V)(0D)), ((V)((W_1910 + 2D))), ((V)(4D)), ((V)((D_1911 + 2D))), body_1905, Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slab_16, V.Undef, ((V)(CX_1906)), ((V)(((Y0_1909 + H_1912) + 7D))), ((V)(0D)), ((V)((W_1910 - 4D))), ((V)(13D)), ((V)(3D)), ((V)((Truthy(royal_1902) ? "#7f2030" : "#d9363b"))), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(slab_16, V.Undef, ((V)(CX_1906)), ((V)(((Y0_1909 + H_1912) + 8.2))), ((V)(1.6)), ((V)((W_1910 - 7D))), ((V)(10.6)), ((V)(0.4)), (Truthy(royal_1902) ? GOLD_27 : ((V)("#ffffff"))), NewObj(2).Put("r", ((V)(2D))).Put("noOut", ((V)(1D))).V));
if (Truthy(royal_1902)) {
InvokeSpread(o_1928, "push", new ArrBuilder().Add(Call(ball_15, V.Undef, ((V)(CX_1906)), ((V)(((Y0_1909 + H_1912) + 22D))), ((V)(0D)), ((V)(3.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("k", ((V)(4D))).V))).Spread(Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis2022, int _argc2015, V s_2021, V _a2018, V _a2019, V _a2020, V[] _rest2016) => {
return Call(ball_15, V.Undef, ((V)((CX_1906 + (ToNum(s_2021) * 20D)))), ((V)(((Y0_1909 + H_1912) + 20D))), ((V)(0D)), ((V)(2.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("k", ((V)(3D))).V));
}, 1, "", true))).V);
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis2030, int _argc2023, V i_2029, V _a2026, V _a2027, V _a2028, V[] _rest2024) => {
return Invoke(o_1928, "push", Call(cyl_14, V.Undef, ((V)(((CX_1906 - 8D) + (ToNum(i_2029) * 4D)))), ((V)(((Y0_1909 + H_1912) + 19.6))), ((V)(0D)), ((V)(1D)), ((V)((4D + ((ToNum(i_2029) % 2D) * 2D)))), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(6D))).Put("top", ((V)(0.9))).V)));
}, 1, "", true));
}
if (Truthy(conc_1903)) {
double nx_2031 = 0;
V R_2032 = default;
nx_2031 = 28D;
Invoke(o_1928, "push", Call(box_12, V.Undef, ((V)(nx_2031)), ((V)(BH_1907)), ((V)(0D)), ((V)(34D)), ((V)(3D)), ((V)(26D)), ((V)("#2c2d31")), Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(nx_2031)), ((V)((BH_1907 + 3D))), ((V)(0D)), ((V)(32D)), ((V)(1D)), ((V)(24D)), ((V)("#3a3c48")), Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
R_2032 = Call(rng_50, V.Undef, ((V)("nacho")));
Call(rep_39, V.Undef, ((V)(16D)), Fn((V _arrowThis2040, int _argc2033, V i_2039, V _a2036, V _a2037, V _a2038, V[] _rest2034) => {
return Invoke(o_1928, "push", Call(solid_11, V.Undef, NewObj(8).Put("ax", ((V)("y"))).Put("sh", ((V)("poly"))).Put("c", Arr(((V)(((nx_2031 - 12D) + ((ToNum(i_2039) % 6D) * 4.8)))), ((V)((((-8D) + (System.Math.Floor((ToNum(i_2039) / 6D)) * 7D)) + (ToNum(Call(R_2032, V.Undef)) * 2D)))))).Put("pts", Arr(Arr(((V)(0D)), ((V)(3.4))), Arr(((V)(3D)), ((V)((-2D)))), Arr(((V)((-3D))), ((V)((-2D)))))).Put("yaw", ((V)(((ToNum(Call(R_2032, V.Undef)) * PI_31) * 2D)))).Put("rings", Arr(Arr(((V)(((BH_1907 + 4D) + ((ToNum(i_2039) % 3D) * 0.7)))), ((V)(0D))), Arr(((V)(((BH_1907 + 4.6) + ((ToNum(i_2039) % 3D) * 0.7)))), ((V)(0D))))).Put("col", ((V)((NumTruthy((ToNum(i_2039) % 4D)) ? "#f2c14a" : "#e8a83a")))).Put("mat", ((V)("paint"))).V));
}, 1, "", true));
Invoke(o_1928, "push", Call(cyl_14, V.Undef, ((V)((nx_2031 + 8D))), ((V)((BH_1907 + 4D))), ((V)(4D)), ((V)(4.4)), ((V)(2.6)), ((V)("#ffffff")), Call(cer_36, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_14, V.Undef, ((V)((nx_2031 + 8D))), ((V)((BH_1907 + 6.2))), ((V)(4D)), ((V)(3.8)), ((V)(0.6)), ((V)("#f6b62c")), NewObj(1).Put("n", ((V)(12D))).V));
Invoke(o_1928, "push", Call(cyl_14, V.Undef, ((V)((nx_2031 + 12D))), ((V)((BH_1907 + 4D))), ((V)((-8D))), ((V)(6D)), ((V)(16D)), ((V)("#f2d64a")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_14, V.Undef, ((V)((nx_2031 + 12D))), ((V)((BH_1907 + 20D))), ((V)((-8D))), ((V)(4D)), ((V)(3D)), CH_28, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_14, V.Undef, ((V)((nx_2031 + 12D))), ((V)((BH_1907 + 23D))), ((V)((-8D))), ((V)(1D)), ((V)(6D)), CH_28, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(box_12, V.Undef, ((V)((nx_2031 + 12D))), ((V)((BH_1907 + 28D))), ((V)((-4D))), ((V)(3D)), ((V)(2.4)), ((V)(9D)), ((V)("#2c2d31")), Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((nx_2031 + 12D))), ((V)((BH_1907 + 25D))), ((V)(1D)), ((V)(1.6)), ((V)(4D)), ((V)(1.6)), CH_28, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}
return o_1928;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2048, int _argc2041, V c_2047, V _a2044, V _a2045, V _a2046, V[] _rest2042) => {
V top_2049 = default;
JsStrBuf f_2050 = null;
V g_2051 = default;
top_2049 = Invoke(c_2047, "p", ((V)((CX_1906 - 4D))), ((V)((Y0_1909 + 33.4))), ((V)((-4D))));
f_2050 = new JsStrBuf("");
f_2050.S("<g transform=\"").V(Call(plane_45, V.Undef, Get(c_2047, "p"), ((V)(1.9)), ((V)(((Y0_1909 + H_1912) + 18.8))))).S(" translate(").N(CX_1906).S(" 0)\"><text x=\"0\" y=\"8.2\" text-anchor=\"middle\" font-family=\"Georgia, 'Times New Roman', serif\" font-weight=\"700\" font-size=\"7.4\" textLength=\"").N((W_1910 - 12D)).S("\" lengthAdjust=\"spacingAndGlyphs\" fill=\"").S((Truthy(royal_1902) ? "#7f2030" : "#d9363b")).S("\">POPCORN</text></g>");
Call(rep_39, V.Undef, ((V)(7D)), Fn((V _arrowThis2059, int _argc2052, V i_2058, V _a2055, V _a2056, V _a2057, V[] _rest2053) => {
V end_2060 = default;
V d_2061 = default;
double bg_2062 = 0;
V mid_2063 = default;
end_2060 = Invoke(c_2047, "p", ((V)((CX_1906 + ((ToNum(i_2058) - 3D) * 4.4)))), ((V)((Y0_1909 + 12D))), ((V)((((ToNum(i_2058) % 3D) * 3D) - 1D))));
d_2061 = Invoke(((V)((1.5 + ((ToNum(i_2058) % 3D) * 0.25)))), "toFixed", ((V)(2D)));
bg_2062 = (-ToNum(Invoke(((V)((ToNum(i_2058) * 0.31))), "toFixed", ((V)(2D)))));
mid_2063 = Arr(Call(f1_23, V.Undef, ((V)((ToNum(Add(GetIdx(top_2049, 0D), GetIdx(end_2060, 0D))) / 2D)))), Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(top_2049, 1D)) - ((10D + ((ToNum(i_2058) % 2D) * 6D)) * ToNum(Get(c_2047, "k"))))))));
f_2050.S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)((1.5 * ToNum(Get(c_2047, "k"))))))).S("\" fill=\"#fff6dc\" stroke=\"#e8c870\" stroke-width=\"0.3\"><animateMotion dur=\"").V(d_2061).S("s\" begin=\"").N(bg_2062).S("s\" repeatCount=\"indefinite\" keyPoints=\"0;1\" keyTimes=\"0;1\" path=\"M").V(Call(P2_42, V.Undef, top_2049)).S("Q").V(GetIdx(mid_2063, 0D)).S(" ").V(GetIdx(mid_2063, 1D)).S(" ").V(Call(P2_42, V.Undef, end_2060)).S("\"/>").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0;1;1;0")), d_2061, ((V)(bg_2062)), ((V)("0;0.1;0.85;1")))).S("</circle>");
return default;
}, 1, "", true));
g_2051 = Invoke(c_2047, "p", ((V)(CX_1906)), ((V)((Y0_1909 + 24D))), ((V)(0D)));
f_2050.S("<ellipse cx=\"").V(GetIdx(Invoke(Call(P2_42, V.Undef, g_2051), "split", ((V)(" "))), 0D)).S("\" cy=\"").V(GetIdx(Invoke(Call(P2_42, V.Undef, g_2051), "split", ((V)(" "))), 1D)).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((22D * ToNum(Get(c_2047, "k"))))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((18D * ToNum(Get(c_2047, "k"))))))).S("\" fill=\"#ffd66b\" opacity=\"0.1\">").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.05;0.18;0.05")), ((V)(1.6)))).S("</ellipse>");
if (Truthy(royal_1902)) {
Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis2071, int _argc2064, V i_2070, V _a2067, V _a2068, V _a2069, V[] _rest2065) => {
return ((V)(f_2050.V(Call(spark_52, V.Undef, c_2047, ((V)(((CX_1906 - 18D) + (ToNum(i_2070) * 18D)))), ((V)(((Y0_1909 + H_1912) + 18D))), ((V)(2D)), ((V)(0.7)), ((V)(((-ToNum(i_2070)) * 0.6))), ((V)("#fff1c4")))).Str));
}, 1, "", true));
}
if (Truthy(conc_1903)) {
f_2050.V(Call(steam_51, V.Undef, c_2047, ((V)(28D)), ((V)((BH_1907 + 6D))), ((V)(0D)), ((V)(0.7)), ((V)(3D))));
}
return NewObj(1).Put("front", ((V)(f_2050.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "candyBar", Fn((V _arrowThis2079, int _argc2072, V S_2078, V _a2075, V _a2076, V _a2077, V[] _rest2073) => {
return NewObj(5).Put("w", ((V)(120D))).Put("d", ((V)(48D))).Put("glow", Fn((V _arrowThis2086, int _argc2080, V _a2082, V _a2083, V _a2084, V _a2085, V[] _rest2081) => {
return NewObj(3).Put("y", ((V)(70D))).Put("r", ((V)(60D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis2094, int _argc2087, V P_2093, V _a2090, V _a2091, V _a2092, V[] _rest2088) => {
V o_2095 = default;
V CC_2096 = default;
o_2095 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(116D)), ((V)(6D)), ((V)(42D)), ((V)("#2c2d31")), Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)((-4D))), ((V)(112D)), ((V)(44D)), ((V)(34D)), ((V)("#f1eee8")), Call(cer_36, V.Undef, NewObj(1).Put("r", ((V)(4D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(50D)), ((V)((-2D))), ((V)(116D)), ((V)(3D)), ((V)(40D)), CH_28, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
CC_2096 = Arr(Arr(((V)("#ff6ad5")), ((V)("#ffd66b"))), Arr(((V)("#6ac8ff")), ((V)("#ffffff"))), Arr(((V)("#a6f06a")), ((V)("#ff9d4a"))), Arr(((V)("#d9363b")), ((V)("#7a4a28"))));
Invoke(CC_2096, "forEach", Fn((V _arrowThis2109, int _argc2097, V _a2099, V i_2103, V _a2101, V _a2102, V[] _rest2098) => {
double x_2110 = 0;
V a_2106 = default;
V b_2108 = default;
{ V _t2104 = ListOf(_a2099);
{ V _t2105 = GetIdx(_t2104, 0D);
a_2106 = _t2105; }
{ V _t2107 = GetIdx(_t2104, 1D);
b_2108 = _t2107; }
}
x_2110 = ((-42D) + (ToNum(i_2103) * 18D));
Invoke(o_2095, "push", Call(cyl_14, V.Undef, ((V)(x_2110)), ((V)(53D)), ((V)((-8D))), ((V)(7D)), ((V)(4D)), ((V)("#3a3c48")), Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_14, V.Undef, ((V)(x_2110)), ((V)(57D)), ((V)((-8D))), ((V)(6.6)), ((V)(38D)), GL_30, Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("op", ((V)(0.25))).V)), Call(cyl_14, V.Undef, ((V)(x_2110)), ((V)(95D)), ((V)((-8D))), ((V)(7.2)), ((V)(3D)), ((V)("#3a3c48")), Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)));
Call(rep_39, V.Undef, ((V)(13D)), Fn((V _arrowThis2118, int _argc2111, V j_2117, V _a2114, V _a2115, V _a2116, V[] _rest2112) => {
return Invoke(o_2095, "push", Call(ball_15, V.Undef, ((V)((x_2110 + (((ToNum(j_2117) % 3D) - 1D) * 3.4)))), ((V)(((57.4 + (System.Math.Floor((ToNum(j_2117) / 3D)) * 5.2)) + (ToNum(j_2117) % 2D)))), ((V)(((-8D) + ((((ToNum(j_2117) * 7D) % 3D) - 1D) * 2.6)))), ((V)(2.2)), (NumTruthy((ToNum(j_2117) % 2D)) ? a_2106 : b_2108), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(o_2095, "push", Call(box_12, V.Undef, ((V)(x_2110)), ((V)(40D)), ((V)(13.6)), ((V)(7D)), ((V)(6D)), ((V)(3D)), CH_28, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
return default;
}, 2, "", true));
Call(bucket_71, V.Undef, o_2095, ((V)(36D)), ((V)(53D)), ((V)((-6D))), ((V)(10D)), ((V)(18D)), ((V)("cbb")));
Call(bucket_71, V.Undef, o_2095, ((V)(18D)), ((V)(53D)), ((V)(8D)), ((V)(7D)), ((V)(13D)), ((V)("cbs")));
Invoke(o_2095, "push", Call(slab_16, V.Undef, ((V)(40D)), ((V)(18D)), ((V)(13.2)), ((V)(30D)), ((V)(20D)), ((V)(0.6)), ((V)("#1d2030")), NewObj(1).Put("r", ((V)(2D))).V), Call(slab_16, V.Undef, ((V)(40D)), ((V)(19.5)), ((V)(13.6)), ((V)(26D)), ((V)(17D)), ((V)(0.2)), ((V)("#6ac8ff")), Call(em_25, V.Undef, NewObj(2).Put("r", ((V)(1.5))).Put("op", ((V)(0.6))).V)));
return o_2095;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2126, int _argc2119, V c_2125, V _a2122, V _a2123, V _a2124, V[] _rest2120) => {
JsStrBuf f_2127 = null;
f_2127 = new JsStrBuf("");
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "forEach", Fn((V _arrowThis2135, int _argc2128, V i_2134, V _a2131, V _a2132, V _a2133, V[] _rest2129) => {
double x_2136 = 0;
V a_2137 = default;
V b_2138 = default;
x_2136 = ((-42D) + (ToNum(i_2134) * 18D));
a_2137 = Invoke(c_2125, "p", ((V)(x_2136)), ((V)(44D)), ((V)(14D)));
b_2138 = Invoke(c_2125, "p", ((V)(x_2136)), ((V)(38D)), ((V)(16D)));
f_2127.S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(Get(c_2125, "k"))))))).S("\" fill=\"").V(GetK(Arr(((V)("#ff6ad5")), ((V)("#6ac8ff")), ((V)("#a6f06a")), ((V)("#d9363b"))), i_2134)).S("\"><animateMotion dur=\"2.4s\" begin=\"").N(((-ToNum(i_2134)) * 0.6)).S("s\" repeatCount=\"indefinite\" path=\"M").V(Call(P2_42, V.Undef, a_2137)).S("L").V(Call(P2_42, V.Undef, b_2138)).S("\"/>").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("1;1;0")), ((V)(2.4)), ((V)(((-ToNum(i_2134)) * 0.6))))).S("</circle>");
return default;
}, 1, "", true));
f_2127.S("<g transform=\"").V(Call(plane_45, V.Undef, Get(c_2125, "p"), ((V)(14D)), ((V)(35D)))).S(" translate(40 0)\"><text x=\"0\" y=\"0\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"4\" fill=\"#ffffff\">PICK A TREAT").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("1;0.4;1")), ((V)(1.6)))).S("</text></g>");
return NewObj(1).Put("front", ((V)(f_2127.Str))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
holoFig_72 = Fn((V _arrowThis2151, int _argc2139, V c_2145, V x_2146, V y_2147, V z_2148, V[] _rest2140) => {
V q_2152 = default;
double u_2153 = 0;
V body_2154 = default;
V scan_2155 = default;
V s_2149 = default;
V dur_2150 = default;
s_2149 = (_argc2139 > 4 ? _rest2140[0] : V.Undef);
dur_2150 = (_argc2139 > 5 ? _rest2140[1] : V.Undef);
q_2152 = Invoke(c_2145, "p", x_2146, y_2147, z_2148);
u_2153 = (ToNum(Get(c_2145, "k")) * ToNum(s_2149));
body_2154 = ((V)(JsStrBuf.Begin().S("<ellipse cx=\"0\" cy=\"0\" rx=\"").V(Call(f1_23, V.Undef, ((V)((15D * u_2153))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((13D * u_2153))))).S("\" fill=\"url(#hgB)\" stroke=\"#d8fbff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.7 * u_2153))))).S("\"/>").V(Invoke(Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis2163, int _argc2156, V sg_2162, V _a2159, V _a2160, V _a2161, V[] _rest2157) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)(((ToNum(sg_2162) * 9D) * u_2153))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-13D) * u_2153))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((4D * u_2153))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((6.5 * u_2153))))).S("\" fill=\"url(#hgB)\" stroke=\"#d8fbff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * u_2153))))).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<ellipse cx=\"0\" cy=\"").V(Call(f1_23, V.Undef, ((V)((4D * u_2153))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((8D * u_2153))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((6D * u_2153))))).S("\" fill=\"#e8fdff\" opacity=\"0.35\"/>").V(Invoke(Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis2171, int _argc2164, V sg_2170, V _a2167, V _a2168, V _a2169, V[] _rest2165) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)(((ToNum(sg_2170) * 5D) * u_2153))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-3D) * u_2153))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * u_2153))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((2.2 * u_2153))))).S("\" fill=\"#0a3a52\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)(((-3D) * u_2153))))).S(" ").V(Call(f1_23, V.Undef, ((V)((2D * u_2153))))).S("Q0 ").V(Call(f1_23, V.Undef, ((V)((5D * u_2153))))).S(" ").V(Call(f1_23, V.Undef, ((V)((3D * u_2153))))).S(" ").V(Call(f1_23, V.Undef, ((V)((2D * u_2153))))).S("\" fill=\"none\" stroke=\"#0a3a52\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.8 * u_2153))))).S("\" stroke-linecap=\"round\"/>").V(Invoke(Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis2179, int _argc2172, V sg_2178, V _a2175, V _a2176, V _a2177, V[] _rest2173) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(f1_23, V.Undef, ((V)(((ToNum(sg_2178) * 14D) * u_2153))))).S(" ").V(Call(f1_23, V.Undef, ((V)((2D * u_2153))))).S(")\"><g>").V(Call(at_41, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().N((ToNum(sg_2178) * 10D)).S(";").N((ToNum(sg_2178) * (-40D))).S(";").N((ToNum(sg_2178) * 10D)).End())), ((V)(0.8)), ((V)((GtN(sg_2178, 0D) ? (-0.4) : 0D))))).S("<ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)(((ToNum(sg_2178) * 3D) * u_2153))))).S("\" cy=\"0\" rx=\"").V(Call(f1_23, V.Undef, ((V)((4D * u_2153))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * u_2153))))).S("\" fill=\"url(#hgB)\" stroke=\"#d8fbff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.5 * u_2153))))).S("\"/></g></g>").End()));
}, 1, "", true)), "join", ((V)("")))).End()));
scan_2155 = ((V)(JsStrBuf.Begin().S("<g clip-path=\"url(#hgC)\" opacity=\"0.5\"><g>").V(Call(at_41, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 ").V(Call(f1_23, V.Undef, ((V)(((-14D) * u_2153))))).S(";0 ").V(Call(f1_23, V.Undef, ((V)((14D * u_2153))))).End())), ((V)(1.6)))).V(Invoke(Call(rep_39, V.Undef, ((V)(8D)), Fn((V _arrowThis2187, int _argc2180, V i_2186, V _a2183, V _a2184, V _a2185, V[] _rest2181) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)(((-20D) * u_2153))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((((-28D) + (ToNum(i_2186) * 7D)) * u_2153))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((40D * u_2153))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((0.9 * u_2153))))).S("\" fill=\"#ffffff\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g></g>").End()));
return NewObj(2).Put("defs", ((V)(JsStrBuf.Begin().S("<radialGradient id=\"hgB\" cx=\"40%\" cy=\"35%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#e8fdff\" stop-opacity=\"0.8\"/><stop offset=\"1\" stop-color=\"#4fc8f0\" stop-opacity=\"0.35\"/></radialGradient><clipPath id=\"hgC\"><ellipse cx=\"0\" cy=\"0\" rx=\"").V(Call(f1_23, V.Undef, ((V)((15D * u_2153))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((13D * u_2153))))).S("\"/><ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)(((-9D) * u_2153))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-13D) * u_2153))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((4D * u_2153))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((6.5 * u_2153))))).S("\"/><ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)((9D * u_2153))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-13D) * u_2153))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((4D * u_2153))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((6.5 * u_2153))))).S("\"/></clipPath>").End()))).Put("svg", ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_42, V.Undef, q_2152)).S(")\"><g>").V(Call(at_41, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 ").V(Call(f1_23, V.Undef, ((V)(((-5D) * u_2153))))).S(";0 0").End())), ((V)(1.6)))).S("<g>").V(Call(at_41, V.Undef, ((V)("scale")), ((V)("1 1;0.12 1;-1 1;0.12 1;1 1")), (dur_2150 is var _t2188 && Truthy(_t2188) ? _t2188 : ((V)(6D))))).S("<g>").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.9;0.9;0.4;0.9;0.9;0.6;0.9")), ((V)(3.2)), ((V)(0D)), ((V)("0;0.42;0.45;0.48;0.8;0.82;1")))).V(body_2154).V(scan_2155).S("</g></g></g></g>").End()))).V;
return default;
}, 6, "", true);
ringH_73 = Fn((V _arrowThis2204, int _argc2189, V c_2195, V y_2196, V cz_2197, V r_2198, V[] _rest2190) => {
V col_2199 = default;
V w_2200 = default;
V dash_2201 = default;
V d_2202 = default;
V rev_2203 = default;
col_2199 = (_argc2189 > 4 ? _rest2190[0] : V.Undef);
w_2200 = (_argc2189 > 5 ? _rest2190[1] : V.Undef);
dash_2201 = (_argc2189 > 6 ? _rest2190[2] : V.Undef);
d_2202 = (_argc2189 > 7 ? _rest2190[3] : V.Undef);
rev_2203 = (_argc2189 > 8 ? _rest2190[4] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(planeH_46, V.Undef, Get(c_2195, "p"), y_2196)).S(" translate(0 ").V(cz_2197).S(")\"><ellipse rx=\"").V(r_2198).S("\" ry=\"").V(r_2198).S("\" fill=\"none\" stroke=\"").V(col_2199).S("\" stroke-width=\"").V(w_2200).S("\" stroke-dasharray=\"").V(dash_2201).S("\" filter=\"url(#gw2)\">").V(Call(an_40, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;").S((Truthy(rev_2203) ? "" : "-")).V(Call(f1_23, V.Undef, ((V)(((2D * PI_31) * ToNum(r_2198)))))).End())), d_2202)).S("</ellipse></g>").End()));
}, 9, "", true);
holo0_74 = Get(N_24, "holo");
Set(N_24, "holo", Fn((V _arrowThis2212, int _argc2205, V S_2211, V _a2208, V _a2209, V _a2210, V[] _rest2206) => {
V D_2213 = default;
V f0_2214 = default;
D_2213 = Call(holo0_74, V.Undef, S_2211);
f0_2214 = Get(D_2213, "fx");
Set(D_2213, "fx", Fn((V _arrowThis2222, int _argc2215, V c_2221, V _a2218, V _a2219, V _a2220, V[] _rest2216) => {
V F_2223 = default;
JsStrBuf f_2224 = null;
V a_2225 = default;
V b_2226 = default;
V defs_2227 = default;
F_2223 = (Truthy(f0_2214) ? (Call(f0_2214, V.Undef, c_2221) is var _t2228 && Truthy(_t2228) ? _t2228 : NewObj(0).V) : NewObj(0).V);
f_2224 = new JsStrBuf("");
f_2224.V(Add(Add(Call(ringH_73, V.Undef, c_2221, ((V)(30D)), ((V)(0D)), ((V)(26D)), ((V)("#c9f4ff")), ((V)(0.9)), ((V)("6 4")), ((V)(4D))), Call(ringH_73, V.Undef, c_2221, ((V)(60D)), ((V)(0D)), ((V)(30D)), ((V)("#8fe8ff")), ((V)(0.9)), ((V)("3 5")), ((V)(3D)), ((V)(1D)))), Call(ringH_73, V.Undef, c_2221, ((V)(84D)), ((V)(0D)), ((V)(31D)), ((V)("#e8fdff")), ((V)(0.6)), ((V)("10 8")), ((V)(5D)))));
a_2225 = Invoke(c_2221, "p", ((V)(0D)), ((V)(8D)), ((V)(0D)));
b_2226 = Invoke(c_2221, "p", ((V)(0D)), ((V)(86D)), ((V)(0D)));
f_2224.S("<g transform=\"translate(").V(Call(P2_42, V.Undef, a_2225)).S(")\"><ellipse cx=\"0\" cy=\"0\" rx=\"").V(Call(f1_23, V.Undef, ((V)((24D * ToNum(Get(c_2221, "k"))))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((24D * ToNum(Get(c_2221, "k"))) * ToNum(Get(X_9, "SA"))))))).S("\" fill=\"#c9f4ff\" opacity=\"0.5\">").V(Call(at_41, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(b_2226, 1D)) - ToNum(GetIdx(a_2225, 1D))))))).End())), ((V)(2.4)))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.6;0.6;0")), ((V)(2.4)))).V(Call(an_40, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((24D * ToNum(Get(c_2221, "k"))))))).S(";").V(Call(f1_23, V.Undef, ((V)((32D * ToNum(Get(c_2221, "k"))))))).End())), ((V)(2.4)))).S("</ellipse></g>");
Call(rep_39, V.Undef, ((V)(6D)), Fn((V _arrowThis2236, int _argc2229, V i_2235, V _a2232, V _a2233, V _a2234, V[] _rest2230) => {
return ((V)(f_2224.V(Call(spark_52, V.Undef, c_2221, ((V)((((ToNum(i_2235) % 3D) - 1D) * 18D))), ((V)((20D + (ToNum(i_2235) * 11D)))), ((V)(((NumTruthy((ToNum(i_2235) % 2D)) ? 1D : (-1D)) * 8D))), ((V)(0.6)), ((V)(((-ToNum(i_2235)) * 0.5))), ((V)("#e8fdff")), ((V)(2.4)))).Str));
}, 1, "", true));
defs_2227 = Add((Get(F_2223, "defs") is var _t2237 && Truthy(_t2237) ? _t2237 : ((V)(""))), GLOW_48);
if (Truthy(Invoke(NewRegExp(RX11, "mascot|dancer|idol|stage", ""), "test", Get(S_2211, "nm")))) {
V H_2238 = default;
H_2238 = Call(holoFig_72, V.Undef, c_2221, ((V)(0D)), ((V)(48D)), ((V)(0D)), ((V)(1.15)), ((V)(5D)));
defs_2227 = Add(defs_2227, Get(H_2238, "defs"));
f_2224.V(Get(H_2238, "svg"));
}
return Object_assign(NewObj(0).V, F_2223, NewObj(2).Put("defs", defs_2227).Put("front", ((V)(JsStrBuf.Begin().V((Get(F_2223, "front") is var _t2239 && Truthy(_t2239) ? _t2239 : ((V)("")))).S(f_2224.Str).End()))).V);
return default;
}, 1, "", true));
return D_2213;
return default;
}, 1, "", true));
Set(N_24, "holoStage", Fn((V _arrowThis2247, int _argc2240, V S_2246, V _a2243, V _a2244, V _a2245, V[] _rest2241) => {
return NewObj(5).Put("w", ((V)(160D))).Put("d", ((V)(120D))).Put("glow", Fn((V _arrowThis2254, int _argc2248, V _a2250, V _a2251, V _a2252, V _a2253, V[] _rest2249) => {
return NewObj(3).Put("y", ((V)(60D))).Put("r", ((V)(92D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis2262, int _argc2255, V P_2261, V _a2258, V _a2259, V _a2260, V[] _rest2256) => {
V o_2263 = default;
o_2263 = Arr();
Invoke(o_2263, "push", Call(arcW_18, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(76D)), ((V)(58D)), ((V)(10D)), ((V)(4D)), ((V)((PI_31 * 1.02))), ((V)((PI_31 * 1.98))), ((V)("#23252e")), Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)));
Call(rep_39, V.Undef, ((V)(11D)), Fn((V _arrowThis2271, int _argc2264, V i_2270, V _a2267, V _a2268, V _a2269, V[] _rest2265) => {
double t_2272 = 0;
double x_2273 = 0;
double z_2274 = 0;
double h_2275 = 0;
t_2272 = (PI_31 * (1.06 + ((0.88 * ToNum(i_2270)) / 10D)));
x_2273 = (FdLibm.Cos(t_2272) * 70D);
z_2274 = (4D + (FdLibm.Sin(t_2272) * 53D));
h_2275 = ((52D + (62D * Pow(FdLibm.Sin(((PI_31 * ToNum(Add(i_2270, ((V)(0.5))))) / 11D)), 1.4))) + ((ToNum(i_2270) % 2D) * 8D));
Invoke(o_2263, "push", Call(box_12, V.Undef, ((V)(x_2273)), ((V)(4D)), ((V)(z_2274)), ((V)(16D)), ((V)(h_2275)), ((V)(3.2)), ((V)((NumTruthy((ToNum(i_2270) % 2D)) ? "#6b4226" : "#7d5232"))), Call(wd_35, V.Undef, NewObj(2).Put("yaw", ((V)(t_2272))).Put("r", ((V)(1.4))).V)), Call(box_12, V.Undef, ((V)(x_2273)), ((V)((4D + h_2275))), ((V)(z_2274)), ((V)(16.4)), ((V)(1.4)), ((V)(3.6)), ((V)("#8fe8ff")), Call(em_25, V.Undef, NewObj(2).Put("yaw", ((V)(t_2272))).Put("r", ((V)(0.6))).V)));
return default;
}, 1, "", true));
Invoke(o_2263, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(48D)), ((V)(6D)), ((V)("#1d1f28")), Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(30D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(14D)), ((V)(47D)), ((V)(1.2)), CH_28, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(30D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(7.2)), ((V)(14D)), ((V)(44D)), ((V)(4D)), ((V)("#2a2d3a")), Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(30D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(11.2)), ((V)(14D)), ((V)(36D)), ((V)(0.8)), ((V)("#8fe8ff")), Call(em_25, V.Undef, NewObj(2).Put("n", ((V)(30D))).Put("op", ((V)(0.9))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(11.2)), ((V)(14D)), ((V)(22D)), ((V)(1.4)), ((V)("#c9f4ff")), Call(em_25, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)));
Call(rep_39, V.Undef, ((V)(12D)), Fn((V _arrowThis2283, int _argc2276, V i_2282, V _a2279, V _a2280, V _a2281, V[] _rest2277) => {
double a_2284 = 0;
a_2284 = (((ToNum(i_2282) / 12D) * 2D) * PI_31);
Invoke(o_2263, "push", Call(ball_15, V.Undef, ((V)((FdLibm.Cos(a_2284) * 41D))), ((V)(11.2)), ((V)((14D + (FdLibm.Sin(a_2284) * 41D)))), ((V)(1.3)), ((V)("#8fe8ff")), Call(em_25, V.Undef, NewObj(2).Put("k", ((V)(2D))).Put("n", ((V)(6D))).V)));
return default;
}, 1, "", true));
return o_2263;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2292, int _argc2285, V c_2291, V _a2288, V _a2289, V _a2290, V[] _rest2286) => {
V e_2293 = default;
V tp_2294 = default;
V u_2295 = default;
JsStrBuf f_2296 = null;
JsStrBuf under_2297 = null;
V H_2298 = default;
e_2293 = Invoke(c_2291, "p", ((V)(0D)), ((V)(12D)), ((V)(14D)));
tp_2294 = Invoke(c_2291, "p", ((V)(0D)), ((V)(104D)), ((V)(14D)));
u_2295 = Get(c_2291, "k");
f_2296 = new JsStrBuf("");
under_2297 = new JsStrBuf("");
f_2296.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(e_2293, 0D)) - (30D * ToNum(u_2295))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(e_2293, 1D))).S("L").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(tp_2294, 0D)) - (40D * ToNum(u_2295))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(tp_2294, 1D))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(tp_2294, 0D), ((V)((40D * ToNum(u_2295))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(tp_2294, 1D))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(e_2293, 0D), ((V)((30D * ToNum(u_2295))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(e_2293, 1D))).S("Z\" fill=\"url(#hgCone)\" opacity=\"0.7\">").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.55;0.85;0.6;0.8;0.55")), ((V)(2.2)))).S("</path>");
f_2296.V(Add(Add(Call(ringH_73, V.Undef, c_2291, ((V)(22D)), ((V)(14D)), ((V)(30D)), ((V)("#c9f4ff")), ((V)(1D)), ((V)("8 5")), ((V)(4D))), Call(ringH_73, V.Undef, c_2291, ((V)(58D)), ((V)(14D)), ((V)(34D)), ((V)("#8fe8ff")), ((V)(1D)), ((V)("4 6")), ((V)(3D)), ((V)(1D)))), Call(ringH_73, V.Undef, c_2291, ((V)(94D)), ((V)(14D)), ((V)(38D)), ((V)("#e8fdff")), ((V)(0.7)), ((V)("14 9")), ((V)(6D)))));
H_2298 = Call(holoFig_72, V.Undef, c_2291, ((V)(0D)), ((V)(60D)), ((V)(14D)), ((V)(2.1)), ((V)(6D)));
f_2296.V(Get(H_2298, "svg"));
Call(rep_39, V.Undef, ((V)(10D)), Fn((V _arrowThis2306, int _argc2299, V i_2305, V _a2302, V _a2303, V _a2304, V[] _rest2300) => {
double x_2307 = 0;
double z_2308 = 0;
V a_2309 = default;
V b_2310 = default;
V d_2311 = default;
x_2307 = (((ToNum(i_2305) % 5D) - 2D) * 12D);
z_2308 = (14D + (NumTruthy((ToNum(i_2305) % 2D)) ? 10D : (-10D)));
a_2309 = Invoke(c_2291, "p", ((V)(x_2307)), ((V)(14D)), ((V)(z_2308)));
b_2310 = Invoke(c_2291, "p", ((V)(x_2307)), ((V)(96D)), ((V)(z_2308)));
d_2311 = Invoke(((V)((2.6 + ((ToNum(i_2305) % 3D) * 0.5)))), "toFixed", ((V)(1D)));
f_2296.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(a_2309, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(a_2309, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.9 * ToNum(u_2295)))))).S("\" fill=\"#e8fdff\">").V(Call(an_40, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(a_2309, 1D))).S(";").V(Call(f1_23, V.Undef, GetIdx(b_2310, 1D))).End())), d_2311, ((V)(((-ToNum(i_2305)) * 0.41))))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0;1;0")), d_2311, ((V)(((-ToNum(i_2305)) * 0.41))))).S("</circle>");
return default;
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(11D)), Fn((V _arrowThis2319, int _argc2312, V i_2318, V _a2315, V _a2316, V _a2317, V[] _rest2313) => {
double t_2320 = 0;
double h_2321 = 0;
double x_2322 = 0;
double z_2323 = 0;
V a_2324 = default;
V b_2325 = default;
t_2320 = (PI_31 * (1.06 + ((0.88 * ToNum(i_2318)) / 10D)));
h_2321 = ((52D + (62D * Pow(FdLibm.Sin(((PI_31 * ToNum(Add(i_2318, ((V)(0.5))))) / 11D)), 1.4))) + ((ToNum(i_2318) % 2D) * 8D));
x_2322 = (FdLibm.Cos(t_2320) * 70D);
z_2323 = (4D + (FdLibm.Sin(t_2320) * 53D));
a_2324 = Invoke(c_2291, "p", ((V)((x_2322 - (FdLibm.Cos(t_2320) * 8D)))), ((V)(((4D + h_2321) + 1.4))), ((V)((z_2323 - (FdLibm.Sin(t_2320) * 8D)))));
b_2325 = Invoke(c_2291, "p", ((V)((x_2322 + (FdLibm.Cos(t_2320) * 8D)))), ((V)(((4D + h_2321) + 1.4))), ((V)((z_2323 + (FdLibm.Sin(t_2320) * 8D)))));
f_2296.S("<path d=\"M").V(Call(P2_42, V.Undef, a_2324)).S("L").V(Call(P2_42, V.Undef, b_2325)).S("\" stroke=\"#e8fdff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(u_2295)))))).S("\" stroke-linecap=\"round\" filter=\"url(#gw2)\" opacity=\"0.2\">").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.15;1;0.15")), ((V)(1.2)), ((V)(((-System.Math.Abs((ToNum(i_2318) - 5D))) * 0.12))))).V(Call(an_40, V.Undef, ((V)("stroke")), ((V)("#e8fdff;#8fe8ff;#b48cff;#e8fdff")), ((V)(4.8)))).S("</path>");
return default;
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis2333, int _argc2326, V i_2332, V _a2329, V _a2330, V _a2331, V[] _rest2327) => {
return ((V)(under_2297.S("<g transform=\"").V(Call(planeH_46, V.Undef, Get(c_2291, "p"), ((V)(0.4)))).S(" translate(0 14)\"><ellipse rx=\"50\" ry=\"50\" fill=\"none\" stroke=\"#8fe8ff\" stroke-width=\"1.4\">").V(Call(an_40, V.Undef, ((V)("rx")), ((V)("48;92")), ((V)(3D)), ((V)((-ToNum(i_2332)))))).V(Call(an_40, V.Undef, ((V)("ry")), ((V)("48;92")), ((V)(3D)), ((V)((-ToNum(i_2332)))))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.7;0")), ((V)(3D)), ((V)((-ToNum(i_2332)))))).S("</ellipse></g>").Str));
}, 1, "", true));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(Add(GLOW_48, Get(H_2298, "defs"))).S("<linearGradient id=\"hgCone\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8fe8ff\" stop-opacity=\"0.45\"/><stop offset=\"1\" stop-color=\"#8fe8ff\" stop-opacity=\"0\"/></linearGradient>").End()))).Put("under", ((V)(under_2297.Str))).Put("front", ((V)(f_2296.Str))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
VEL_75 = ((V)("#7f2030"));
VELD_76 = ((V)("#5e1622"));
IVORY_77 = ((V)("#f6efe0"));
MARB_78 = ((V)("#f2efea"));
veins_79 = Fn((V _arrowThis2349, int _argc2334, V o_2340, V R_2341, V x_2342, V y_2343, V[] _rest2335) => {
V z_2344 = default;
V w_2345 = default;
V d_2346 = default;
V n_2347 = default;
V col_2348 = default;
z_2344 = (_argc2334 > 4 ? _rest2335[0] : V.Undef);
w_2345 = (_argc2334 > 5 ? _rest2335[1] : V.Undef);
d_2346 = (_argc2334 > 6 ? _rest2335[2] : V.Undef);
n_2347 = (_argc2334 > 7 ? _rest2335[3] : V.Undef);
col_2348 = (_argc2334 > 8 ? _rest2335[4] : V.Undef);
return Call(rep_39, V.Undef, n_2347, Fn((V _arrowThis2356, int _argc2350, V _a2352, V _a2353, V _a2354, V _a2355, V[] _rest2351) => {
return Invoke(o_2340, "push", Call(box_12, V.Undef, Add(x_2342, ((V)((((ToNum(Call(R_2341, V.Undef)) - 0.5) * ToNum(w_2345)) * 0.8)))), y_2343, Add(z_2344, ((V)((((ToNum(Call(R_2341, V.Undef)) - 0.5) * ToNum(d_2346)) * 0.7)))), ((V)((18D + (ToNum(Call(R_2341, V.Undef)) * 26D)))), ((V)(0.15)), ((V)(0.8)), (col_2348 is var _t2357 && Truthy(_t2357) ? _t2357 : ((V)("#c9b98a"))), NewObj(3).Put("yaw", ((V)(((ToNum(Call(R_2341, V.Undef)) - 0.5) * 1.6)))).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 0, "", true));
}, 9, "", true);
goldPost_80 = Fn((V _arrowThis2370, int _argc2358, V o_2364, V x_2365, V z_2366, V y_2367, V[] _rest2359) => {
V h_2368 = default;
V r_2369 = default;
h_2368 = (_argc2358 > 4 ? _rest2359[0] : V.Undef);
r_2369 = (_argc2358 > 5 ? _rest2359[1] : V.Undef);
return Invoke(o_2364, "push", Call(cyl_14, V.Undef, x_2365, y_2367, z_2366, r_2369, h_2368, GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.5))), Arr(((V)((ToNum(h_2368) * 0.06))), ((V)(0D)), ((V)(1.1))), Arr(((V)((ToNum(h_2368) * 0.12))), ((V)(0D)), ((V)(1.5))), Arr(((V)((ToNum(h_2368) * 0.16))), ((V)(0D)), ((V)(0.9))), Arr(((V)((ToNum(h_2368) * 0.84))), ((V)(0D)), ((V)(0.9))), Arr(((V)((ToNum(h_2368) * 0.9))), ((V)(0D)), ((V)(1.4))), Arr(h_2368, ((V)(0D)), ((V)(1D))))).V)), Call(ball_15, V.Undef, x_2365, Add(y_2367, h_2368), z_2366, ((V)((ToNum(r_2369) * 1.5))), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)));
}, 6, "", true);
tuftGrid_81 = Fn((V _arrowThis2387, int _argc2371, V o_2377, V x0_2378, V x1_2379, V y0_2380, V[] _rest2372) => {
V y1_2381 = default;
V z_2382 = default;
V cols_2383 = default;
V rows_2384 = default;
V col_2385 = default;
V btn_2386 = default;
y1_2381 = (_argc2371 > 4 ? _rest2372[0] : V.Undef);
z_2382 = (_argc2371 > 5 ? _rest2372[1] : V.Undef);
cols_2383 = (_argc2371 > 6 ? _rest2372[2] : V.Undef);
rows_2384 = (_argc2371 > 7 ? _rest2372[3] : V.Undef);
col_2385 = (_argc2371 > 8 ? _rest2372[4] : V.Undef);
btn_2386 = (_argc2371 > 9 ? _rest2372[5] : V.Undef);
return Call(rep_39, V.Undef, rows_2384, Fn((V _arrowThis2395, int _argc2388, V j_2394, V _a2391, V _a2392, V _a2393, V[] _rest2389) => {
return Call(rep_39, V.Undef, ((V)((ToNum(cols_2383) - (ToNum(j_2394) % 2D)))), Fn((V _arrowThis2403, int _argc2396, V i_2402, V _a2399, V _a2400, V _a2401, V[] _rest2397) => {
V x_2404 = default;
V y_2405 = default;
x_2404 = Add(x0_2378, ((V)((((ToNum(x1_2379) - ToNum(x0_2378)) * ToNum(Add(i_2402, ((V)((NumTruthy((ToNum(j_2394) % 2D)) ? 1D : 0.5)))))) / ToNum(cols_2383)))));
y_2405 = Add(y0_2380, ((V)((((ToNum(y1_2381) - ToNum(y0_2380)) * ToNum(Add(j_2394, ((V)(0.5))))) / ToNum(rows_2384)))));
Invoke(o_2377, "push", Call(ball_15, V.Undef, x_2404, y_2405, z_2382, ((V)(3D)), Call(shade_21, V.Undef, col_2385, ((V)(0.78))), NewObj(5).Put("sz", ((V)(0.22))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).Put("shine", ((V)(0D))).V), Call(ball_15, V.Undef, x_2404, y_2405, Add(z_2382, ((V)(0.6))), ((V)(1.4)), btn_2386, Call(mt_34, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V)));
return default;
}, 1, "", true));
}, 1, "", true));
}, 10, "", true);
Set(N_24, "luxCoffee", Fn((V _arrowThis2413, int _argc2406, V S_2412, V _a2409, V _a2410, V _a2411, V[] _rest2407) => {
return NewObj(6).Put("w", ((V)(132D))).Put("d", ((V)(80D))).Put("topH", ((V)(41.2))).Put("topW", ((V)(96D))).Put("build", Fn((V _arrowThis2421, int _argc2414, V P_2420, V _a2417, V _a2418, V _a2419, V[] _rest2415) => {
V o_2422 = default;
V R_2423 = default;
o_2422 = Arr();
R_2423 = Call(rng_50, V.Undef, ((V)("rococo")));
Invoke(Arr(Arr(((V)((-46D))), ((V)((-22D)))), Arr(((V)(46D)), ((V)((-22D)))), Arr(((V)((-46D))), ((V)(22D))), Arr(((V)(46D)), ((V)(22D)))), "forEach", Fn((V _arrowThis2435, int _argc2424, V _a2426, V _a2427, V _a2428, V _a2429, V[] _rest2425) => {
V x_2432 = default;
V z_2434 = default;
{ V _t2430 = ListOf(_a2426);
{ V _t2431 = GetIdx(_t2430, 0D);
x_2432 = _t2431; }
{ V _t2433 = GetIdx(_t2430, 1D);
z_2434 = _t2433; }
}
return Invoke(o_2422, "push", Call(ball_15, V.Undef, ((V)((ToNum(x_2432) * 1.06))), ((V)(0D)), ((V)((ToNum(z_2434) * 1.1))), ((V)(3.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)), Call(cyl_14, V.Undef, x_2432, ((V)(3D)), z_2434, ((V)(2.8)), ((V)(28D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(7D)), ((V)(0D)), ((V)(0.62))), Arr(((V)(18D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(25D)), ((V)(0D)), ((V)(1.6))), Arr(((V)(28D)), ((V)(0D)), ((V)(1.3))))).V)));
}, 1, "", true));
Invoke(o_2422, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(0D)), ((V)(54D)), ((V)(7D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("rz", ((V)(30D))).Put("n", ((V)(30D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(10D)), ((V)(6D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.4))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))))).V)));
Invoke(Arr(Arr(((V)(0D)), ((V)(30.6))), Arr(((V)(0D)), ((V)((-30.6))))), "forEach", Fn((V _arrowThis2447, int _argc2436, V _a2438, V _a2439, V _a2440, V _a2441, V[] _rest2437) => {
V x_2444 = default;
V z_2446 = default;
{ V _t2442 = ListOf(_a2438);
{ V _t2443 = GetIdx(_t2442, 0D);
x_2444 = _t2443; }
{ V _t2445 = GetIdx(_t2442, 1D);
z_2446 = _t2445; }
}
return Invoke(o_2422, "push", Call(ball_15, V.Undef, x_2444, ((V)(27D)), z_2446, ((V)(6D)), GOLD_27, Call(mt_34, V.Undef, NewObj(4).Put("sy", ((V)(0.7))).Put("sz", ((V)(0.35))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-54D))), ((V)(0D))), Arr(((V)(54D)), ((V)(0D)))), "forEach", Fn((V _arrowThis2459, int _argc2448, V _a2450, V _a2451, V _a2452, V _a2453, V[] _rest2449) => {
V x_2456 = default;
V z_2458 = default;
{ V _t2454 = ListOf(_a2450);
{ V _t2455 = GetIdx(_t2454, 0D);
x_2456 = _t2455; }
{ V _t2457 = GetIdx(_t2454, 1D);
z_2458 = _t2457; }
}
return Invoke(o_2422, "push", Call(ball_15, V.Undef, x_2456, ((V)(28D)), z_2458, ((V)(4.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(4).Put("sx", ((V)(0.35))).Put("sy", ((V)(0.8))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)));
}, 1, "", true));
Invoke(o_2422, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(35D)), ((V)(0D)), ((V)(62D)), ((V)(1.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("rz", ((V)(36D))).Put("n", ((V)(32D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(36.4)), ((V)(0D)), ((V)(61D)), ((V)(4.4)), MARB_78, Call(cer_36, V.Undef, NewObj(2).Put("rz", ((V)(35D))).Put("n", ((V)(32D))).V)));
Call(veins_79, V.Undef, o_2422, R_2423, ((V)(0D)), ((V)(40.85)), ((V)(0D)), ((V)(100D)), ((V)(56D)), ((V)(7D)));
Invoke(o_2422, "push", Call(cyl_14, V.Undef, ((V)((-20D))), ((V)(40.8)), ((V)((-2D))), ((V)(18D)), ((V)(1.2)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("rz", ((V)(11D))).Put("n", ((V)(20D))).V)), Call(arcW_18, V.Undef, ((V)((-20D))), ((V)(42D)), ((V)((-2D))), ((V)(18D)), ((V)(11D)), ((V)(1D)), ((V)(1.4)), ((V)(0D)), ((V)((2D * PI_31))), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)));
Invoke(o_2422, "push", Call(cyl_14, V.Undef, ((V)((-24D))), ((V)(42D)), ((V)((-4D))), ((V)(5.4)), ((V)(9D)), GL_30, Call(cer_36, V.Undef, NewObj(3).Put("n", ((V)(16D))).Put("op", ((V)(0.38))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))), Arr(((V)(9D)), ((V)(0D)), ((V)(0.42))))).V)), Call(cyl_14, V.Undef, ((V)((-24D))), ((V)(42.3)), ((V)((-4D))), ((V)(4.8)), ((V)(5.2)), ((V)("#b8692a")), NewObj(2).Put("n", ((V)(14D))).Put("op", ((V)(0.85))).V), Call(cyl_14, V.Undef, ((V)((-24D))), ((V)(51D)), ((V)((-4D))), ((V)(1.7)), ((V)(5D)), GL_30, Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("op", ((V)(0.45))).V)), Call(ball_15, V.Undef, ((V)((-24D))), ((V)(55.6)), ((V)((-4D))), ((V)(2.4)), ((V)("#e8f6ff")), Call(cer_36, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("op", ((V)(0.7))).V)));
Invoke(Arr(Arr(((V)((-12D))), ((V)(2D))), Arr(((V)((-16D))), ((V)(5D)))), "forEach", Fn((V _arrowThis2471, int _argc2460, V _a2462, V _a2463, V _a2464, V _a2465, V[] _rest2461) => {
V x_2468 = default;
V z_2470 = default;
{ V _t2466 = ListOf(_a2462);
{ V _t2467 = GetIdx(_t2466, 0D);
x_2468 = _t2467; }
{ V _t2469 = GetIdx(_t2466, 1D);
z_2470 = _t2469; }
}
return Invoke(o_2422, "push", Call(cyl_14, V.Undef, x_2468, ((V)(42D)), z_2470, ((V)(2.8)), ((V)(5.6)), GL_30, Call(cer_36, V.Undef, NewObj(3).Put("n", ((V)(12D))).Put("op", ((V)(0.35))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(5.6)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_14, V.Undef, x_2468, ((V)(42.3)), z_2470, ((V)(2.4)), ((V)(2.2)), ((V)("#b8692a")), NewObj(2).Put("n", ((V)(12D))).Put("op", ((V)(0.85))).V));
}, 1, "", true));
Invoke(o_2422, "push", Call(cyl_14, V.Undef, ((V)(22D)), ((V)(40.8)), ((V)((-4D))), ((V)(6D)), ((V)(12D)), IVORY_77, Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))), Arr(((V)(12D)), ((V)(0D)), ((V)(0.6))))).V)), Call(cyl_14, V.Undef, ((V)(22D)), ((V)(52.8)), ((V)((-4D))), ((V)(4.4)), ((V)(1.2)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)));
Invoke(Arr(Arr(((V)(0D)), ((V)(0D)), ((V)("#c8243a"))), Arr(((V)((-4D))), ((V)(3D)), ((V)("#f6a8c4"))), Arr(((V)(4D)), ((V)(2D)), ((V)("#fff2f6"))), Arr(((V)((-2D))), ((V)((-4D))), ((V)("#e94a6a"))), Arr(((V)(3D)), ((V)((-3D))), ((V)("#f6a8c4"))), Arr(((V)(0D)), ((V)(1D)), ((V)("#c8243a")))), "forEach", Fn((V _arrowThis2486, int _argc2472, V _a2474, V i_2478, V _a2476, V _a2477, V[] _rest2473) => {
V dx_2481 = default;
V dz_2483 = default;
V cc_2485 = default;
{ V _t2479 = ListOf(_a2474);
{ V _t2480 = GetIdx(_t2479, 0D);
dx_2481 = _t2480; }
{ V _t2482 = GetIdx(_t2479, 1D);
dz_2483 = _t2482; }
{ V _t2484 = GetIdx(_t2479, 2D);
cc_2485 = _t2484; }
}
return Invoke(o_2422, "push", Call(ball_15, V.Undef, Add(((V)(22D)), dx_2481), ((V)(((54D + (SEqN(i_2478, 5D) ? 5D : 0D)) + ((ToNum(i_2478) % 2D) * 2D)))), Add(((V)((-4D))), dz_2483), ((V)(3D)), cc_2485, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V));
}, 2, "", true));
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis2494, int _argc2487, V i_2493, V _a2490, V _a2491, V _a2492, V[] _rest2488) => {
double a_2495 = 0;
a_2495 = (((ToNum(i_2493) / 5D) * 2D) * PI_31);
Invoke(o_2422, "push", Call(ball_15, V.Undef, ((V)((22D + (FdLibm.Cos(a_2495) * 7D)))), ((V)(54D)), ((V)(((-4D) + (FdLibm.Sin(a_2495) * 6D)))), ((V)(2.4)), ((V)("#4f8a3a")), NewObj(5).Put("sx", ((V)(1.6))).Put("sy", ((V)(0.3))).Put("k", ((V)(2D))).Put("n", ((V)(8D))).Put("yaw", ((V)(a_2495))).V));
return default;
}, 1, "", true));
Invoke(o_2422, "push", Call(box_12, V.Undef, ((V)(30D)), ((V)(40.8)), ((V)(14D)), ((V)(22D)), ((V)(2.6)), ((V)(15D)), ((V)("#1f4f3e")), NewObj(3).Put("r", ((V)(1D))).Put("mat", ((V)("paint"))).Put("yaw", ((V)(0.25))).V), Call(box_12, V.Undef, ((V)(30D)), ((V)(43.4)), ((V)(14D)), ((V)(20D)), ((V)(2.2)), ((V)(14D)), VEL_75, NewObj(3).Put("r", ((V)(1D))).Put("mat", ((V)("paint"))).Put("yaw", ((V)(0.1))).V));
return o_2422;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2503, int _argc2496, V c_2502, V _a2499, V _a2500, V _a2501, V[] _rest2497) => {
return NewObj(1).Put("front", Invoke(Arr(Call(spark_52, V.Undef, c_2502, ((V)((-24D))), ((V)(50D)), ((V)((-4D))), ((V)(0.6)), ((V)(0D)), ((V)("#ffffff"))), Call(spark_52, V.Undef, c_2502, ((V)(0D)), ((V)(38D)), ((V)(36D)), ((V)(0.7)), ((V)((-0.9))), ((V)("#fff1c4"))), Call(spark_52, V.Undef, c_2502, ((V)((-46D))), ((V)(32D)), ((V)(24D)), ((V)(0.6)), ((V)((-1.4))), ((V)("#fff1c4")))), "join", ((V)("")))).V;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "luxPatis", Fn((V _arrowThis2511, int _argc2504, V S_2510, V _a2507, V _a2508, V _a2509, V[] _rest2505) => {
return NewObj(5).Put("w", ((V)(128D))).Put("d", ((V)(60D))).Put("glow", Fn((V _arrowThis2518, int _argc2512, V _a2514, V _a2515, V _a2516, V _a2517, V[] _rest2513) => {
return NewObj(3).Put("y", ((V)(74D))).Put("r", ((V)(64D))).Put("c", ((V)("url(#gWarm)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis2526, int _argc2519, V P_2525, V _a2522, V _a2523, V _a2524, V[] _rest2520) => {
V o_2527 = default;
V R_2528 = default;
double Y_2529 = 0;
double W_2530 = 0;
double D_2531 = 0;
V cake_2532 = default;
V MAC_2533 = default;
V croissant_2534 = default;
o_2527 = Arr();
R_2528 = Call(rng_50, V.Undef, ((V)("patis")));
Y_2529 = 42D;
W_2530 = 112D;
D_2531 = 44D;
Invoke(o_2527, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(120D)), ((V)(4D)), ((V)(54D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(116D)), ((V)((Y_2529 - 6D))), ((V)(52D)), MARB_78, Call(cer_36, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((Y_2529 - 2D))), ((V)(0D)), ((V)(120D)), ((V)(2D)), ((V)(56D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Call(veins_79, V.Undef, o_2527, R_2528, ((V)(0D)), ((V)(20D)), ((V)(26.2)), ((V)(100D)), ((V)(0.1)), ((V)(0D)));
Invoke(Arr(((V)((-38D))), ((V)(0D)), ((V)(38D))), "forEach", Fn((V _arrowThis2542, int _argc2535, V x_2541, V _a2538, V _a2539, V _a2540, V[] _rest2536) => {
return Invoke(o_2527, "push", Call(slab_16, V.Undef, x_2541, ((V)(9D)), ((V)(26.4)), ((V)(32D)), ((V)((Y_2529 - 18D))), ((V)(0.8)), ((V)("#f8f5ef")), Call(cer_36, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, x_2541, ((V)(9D)), ((V)(26.9)), ((V)(32D)), ((V)(0.6)), ((V)(0.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Call(box_12, V.Undef, x_2541, ((V)((Y_2529 - 9D))), ((V)(26.9)), ((V)(32D)), ((V)(0.6)), ((V)(0.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Call(ball_15, V.Undef, x_2541, ((V)((Y_2529 - 16D))), ((V)(27.2)), ((V)(2.2)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("sz", ((V)(0.5))).Put("k", ((V)(3D))).V)));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis2554, int _argc2543, V _a2545, V _a2546, V _a2547, V _a2548, V[] _rest2544) => {
V a_2551 = default;
V b_2553 = default;
{ V _t2549 = ListOf(_a2545);
{ V _t2550 = GetIdx(_t2549, 0D);
a_2551 = _t2550; }
{ V _t2552 = GetIdx(_t2549, 1D);
b_2553 = _t2552; }
}
return Invoke(o_2527, "push", Call(cyl_14, V.Undef, ((V)(((ToNum(a_2551) * W_2530) / 2D))), ((V)(Y_2529)), ((V)(((ToNum(b_2553) * D_2531) / 2D))), ((V)(1.6)), ((V)(54D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
cake_2532 = Fn((V _arrowThis2565, int _argc2555, V x_2561, V z_2562, V c1_2563, V c2_2564, V[] _rest2556) => {
Invoke(o_2527, "push", Call(cyl_14, V.Undef, x_2561, ((V)(Y_2529)), z_2562, ((V)(10D)), ((V)(1D)), ((V)("#f4f1ea")), Call(cer_36, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_14, V.Undef, x_2561, ((V)((Y_2529 + 1D))), z_2562, ((V)(8.4)), ((V)(8D)), c1_2563, Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_14, V.Undef, x_2561, ((V)((Y_2529 + 9D))), z_2562, ((V)(8.4)), ((V)(1.2)), c2_2564, Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
Call(rep_39, V.Undef, ((V)(6D)), Fn((V _arrowThis2573, int _argc2566, V i_2572, V _a2569, V _a2570, V _a2571, V[] _rest2567) => {
double a_2574 = 0;
a_2574 = (((ToNum(i_2572) / 6D) * 2D) * PI_31);
Invoke(o_2527, "push", Call(ball_15, V.Undef, Add(x_2561, ((V)((FdLibm.Cos(a_2574) * 6D)))), ((V)((Y_2529 + 10.2))), Add(z_2562, ((V)((FdLibm.Sin(a_2574) * 6D)))), ((V)(1.6)), ((V)("#ffffff")), NewObj(3).Put("sy", ((V)(0.8))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
return default;
}, 1, "", true));
InvokeSpread(o_2527, "push", new ArrBuilder().Spread(Call(straw_66, V.Undef, x_2561, ((V)((Y_2529 + 10.6))), z_2562, ((V)(0.75)))).V);
return default;
}, 4, "", true);
Call(cake_2532, V.Undef, ((V)((-34D))), ((V)((-4D))), ((V)("#6b3a22")), ((V)("#3a2010")));
Call(cake_2532, V.Undef, ((V)(32D)), ((V)((-4D))), ((V)("#fdf3f0")), ((V)("#f6c6d2")));
Invoke(o_2527, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(Y_2529)), ((V)(0D)), ((V)(12D)), ((V)(3D)), ((V)("#e0a85a")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)((Y_2529 + 3D))), ((V)(0D)), ((V)(10.4)), ((V)(0.6)), ((V)("#fff2c8")), NewObj(1).Put("n", ((V)(18D))).V));
Call(rep_39, V.Undef, ((V)(9D)), Fn((V _arrowThis2582, int _argc2575, V i_2581, V _a2578, V _a2579, V _a2580, V[] _rest2576) => {
double a_2583 = 0;
a_2583 = (((ToNum(i_2581) / 9D) * 2D) * PI_31);
InvokeSpread(o_2527, "push", new ArrBuilder().Spread(Call(straw_66, V.Undef, ((V)((FdLibm.Cos(a_2583) * 6.6))), ((V)((Y_2529 + 3.4))), ((V)((FdLibm.Sin(a_2583) * 6.6))), ((V)(0.7)))).V);
return default;
}, 1, "", true));
InvokeSpread(o_2527, "push", new ArrBuilder().Spread(Call(straw_66, V.Undef, ((V)(0D)), ((V)((Y_2529 + 3.4))), ((V)(0D)), ((V)(0.8)))).V);
Invoke(o_2527, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((Y_2529 + 18D))), ((V)(0D)), ((V)((W_2530 - 2D))), ((V)(0.8)), ((V)((D_2531 - 2D))), GL_30, Call(cer_36, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("op", ((V)(0.35))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((Y_2529 + 36D))), ((V)(0D)), ((V)((W_2530 - 2D))), ((V)(0.8)), ((V)((D_2531 - 2D))), GL_30, Call(cer_36, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("op", ((V)(0.35))).V)));
MAC_2533 = Arr(((V)("#f6a8c4")), ((V)("#a6e0c8")), ((V)("#c9a6f0")), ((V)("#ffd66b")), ((V)("#f6c69a")), ((V)("#bfe4ff")));
Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis2591, int _argc2584, V j_2590, V _a2587, V _a2588, V _a2589, V[] _rest2585) => {
return Call(rep_39, V.Undef, ((V)(6D)), Fn((V _arrowThis2599, int _argc2592, V i_2598, V _a2595, V _a2596, V _a2597, V[] _rest2593) => {
double x_2600 = 0;
double z_2601 = 0;
V cc_2602 = default;
x_2600 = ((-36D) + (ToNum(i_2598) * 14.4));
z_2601 = ((-10D) + (ToNum(j_2590) * 10D));
cc_2602 = GetIdx(MAC_2533, (ToNum(Add(i_2598, ((V)((ToNum(j_2590) * 2D))))) % 6D));
Invoke(o_2527, "push", Call(cyl_14, V.Undef, ((V)(x_2600)), ((V)((Y_2529 + 18.8))), ((V)(z_2601)), ((V)(3.4)), ((V)(1.6)), cc_2602, Call(pt_38, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(1.6)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_14, V.Undef, ((V)(x_2600)), ((V)((Y_2529 + 20.4))), ((V)(z_2601)), ((V)(3D)), ((V)(1D)), ((V)("#fff6ea")), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_14, V.Undef, ((V)(x_2600)), ((V)((Y_2529 + 21.4))), ((V)(z_2601)), ((V)(3.4)), ((V)(1.8)), cc_2602, Call(pt_38, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(1.8)), ((V)(0D)), ((V)(0.82))))).V)));
return default;
}, 1, "", true));
}, 1, "", true));
croissant_2534 = Fn((V _arrowThis2612, int _argc2603, V x_2609, V z_2610, V yw_2611, V _a2608, V[] _rest2604) => {
return Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis2620, int _argc2613, V i_2619, V _a2616, V _a2617, V _a2618, V[] _rest2614) => {
double t_2621 = 0;
double r_2622 = 0;
t_2621 = ((ToNum(i_2619) - 2D) * 0.5);
r_2622 = 6D;
Invoke(o_2527, "push", Call(ball_15, V.Undef, Add(x_2609, ((V)((FdLibm.Sin(ToNum(Add(((V)(t_2621)), yw_2611))) * r_2622)))), ((V)((Y_2529 + 36.8))), Add(Add(z_2610, ((V)((((FdLibm.Cos(t_2621) * r_2622) - r_2622) * 0.8)))), ((V)((FdLibm.Cos(ToNum(yw_2611)) * 0D)))), ((V)((3.6 - (System.Math.Abs((ToNum(i_2619) - 2D)) * 0.9)))), ((V)((NumTruthy((ToNum(i_2619) % 2D)) ? "#d99a4a" : "#c8803a"))), NewObj(3).Put("sy", ((V)(0.75))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V));
return default;
}, 1, "", true));
}, 3, "", true);
Call(rep_39, V.Undef, ((V)(4D)), Fn((V _arrowThis2630, int _argc2623, V i_2629, V _a2626, V _a2627, V _a2628, V[] _rest2624) => {
return Call(croissant_2534, V.Undef, ((V)(((-36D) + (ToNum(i_2629) * 22D)))), ((V)((-4D))), ((V)(0D)));
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis2638, int _argc2631, V i_2637, V _a2634, V _a2635, V _a2636, V[] _rest2632) => {
return Invoke(o_2527, "push", Call(box_12, V.Undef, ((V)(((-26D) + (ToNum(i_2637) * 22D)))), ((V)((Y_2529 + 36.8))), ((V)(10D)), ((V)(12D)), ((V)(4D)), ((V)(7D)), ((V)("#d9a35a")), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(((-26D) + (ToNum(i_2637) * 22D)))), ((V)((Y_2529 + 40.8))), ((V)(10D)), ((V)(2D)), ((V)(0.5)), ((V)(6D)), ((V)("#3a2010")), NewObj(2).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
Invoke(o_2527, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((Y_2529 + 1D))), ((V)(0D)), ((V)(W_2530)), ((V)(53D)), ((V)(D_2531)), GL_30, Call(cer_36, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("op", ((V)(0.13))).V)));
Invoke(o_2527, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((Y_2529 + 54D))), ((V)(0D)), ((V)((W_2530 + 8D))), ((V)(3D)), ((V)((D_2531 + 8D))), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((Y_2529 + 57D))), ((V)(0D)), ((V)((W_2530 + 4D))), ((V)(5D)), ((V)((D_2531 + 4D))), MARB_78, Call(cer_36, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slab_16, V.Undef, ((V)(0D)), ((V)((Y_2529 + 62D))), ((V)(0D)), ((V)(44D)), ((V)(10D)), ((V)(3D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(5D))).V)), Call(ball_15, V.Undef, ((V)(0D)), ((V)((Y_2529 + 72D))), ((V)(0D)), ((V)(4D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("k", ((V)(4D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2646, int _argc2639, V s_2645, V _a2642, V _a2643, V _a2644, V[] _rest2640) => {
return Invoke(o_2527, "push", Call(ball_15, V.Undef, ((V)((ToNum(s_2645) * 28D))), ((V)((Y_2529 + 62D))), ((V)(0D)), ((V)(2.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("k", ((V)(3D))).V)));
}, 1, "", true));
Invoke(o_2527, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((Y_2529 + 52.4))), ((V)(0D)), ((V)((W_2530 - 6D))), ((V)(1D)), ((V)(4D)), ((V)("#fff2b0")), Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
return o_2527;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2654, int _argc2647, V c_2653, V _a2650, V _a2651, V _a2652, V[] _rest2648) => {
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_45, V.Undef, Get(c_2653, "p"), ((V)(1.6)), ((V)(113D)))).S("\"><text x=\"0\" y=\"0\" text-anchor=\"middle\" font-family=\"Georgia, serif\" font-style=\"italic\" font-weight=\"700\" font-size=\"5.4\" fill=\"#7f2030\">P\u00e2tisserie</text></g>").V(Invoke(Call(rep_39, V.Undef, ((V)(4D)), Fn((V _arrowThis2662, int _argc2655, V i_2661, V _a2658, V _a2659, V _a2660, V[] _rest2656) => {
return Call(spark_52, V.Undef, c_2653, ((V)(((-40D) + (ToNum(i_2661) * 26D)))), ((V)((60D + ((ToNum(i_2661) % 2D) * 18D)))), ((V)(22D)), ((V)(0.6)), ((V)(((-ToNum(i_2661)) * 0.5))), ((V)("#ffffff")));
}, 1, "", true)), "join", ((V)("")))).End()))).V;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "luxRecliner", Fn((V _arrowThis2670, int _argc2663, V S_2669, V _a2666, V _a2667, V _a2668, V[] _rest2664) => {
double n_2671 = 0;
double SW_2672 = 0;
double AW_2673 = 0;
double Wd_2674 = 0;
V xs_2675 = default;
n_2671 = 3D;
SW_2672 = 60D;
AW_2673 = 16D;
Wd_2674 = ((n_2671 * SW_2672) + ((n_2671 + 1D) * AW_2673));
xs_2675 = Call(rep_39, V.Undef, ((V)(n_2671)), Fn((V _arrowThis2683, int _argc2676, V i_2682, V _a2679, V _a2680, V _a2681, V[] _rest2677) => {
return ((V)((((((-Wd_2674) / 2D) + AW_2673) + (SW_2672 / 2D)) + (ToNum(i_2682) * (SW_2672 + AW_2673)))));
}, 1, "", true));
return NewObj(6).Put("w", ((V)((Wd_2674 + 6D)))).Put("d", ((V)(104D))).Put("act", ((V)("sit"))).Put("seats", Invoke(xs_2675, "map", Fn((V _arrowThis2691, int _argc2684, V x_2690, V _a2687, V _a2688, V _a2689, V[] _rest2685) => {
return NewObj(3).Put("x", x_2690).Put("z", ((V)(6D))).Put("h", ((V)(44D))).V;
}, 1, "", true))).Put("build", Fn((V _arrowThis2699, int _argc2692, V P_2698, V _a2695, V _a2696, V _a2697, V[] _rest2693) => {
V o_2700 = default;
V v_2701 = default;
V vL_2702 = default;
V vD_2703 = default;
o_2700 = Arr();
v_2701 = VEL_75;
vL_2702 = Call(shade_21, V.Undef, VEL_75, ((V)(1.12)));
vD_2703 = VELD_76;
Invoke(o_2700, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((Wd_2674 + 6D))), ((V)(6D)), ((V)(98D)), ((V)("#1d1d20")), NewObj(1).Put("r", ((V)(2D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(1.4)), ((V)(48.6)), ((V)(Wd_2674)), ((V)(1.4)), ((V)(1D)), ((V)("#ffd66b")), Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
Invoke(xs_2675, "forEach", Fn((V _arrowThis2711, int _argc2704, V x_2710, V _a2707, V _a2708, V _a2709, V[] _rest2705) => {
Invoke(o_2700, "push", Call(box_12, V.Undef, x_2710, ((V)(6D)), ((V)(4D)), ((V)(SW_2672)), ((V)(26D)), ((V)(86D)), vD_2703, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)), Call(seatC_54, V.Undef, x_2710, ((V)(32D)), ((V)(8D)), ((V)((SW_2672 - 4D))), ((V)(10D)), ((V)(62D)), vL_2702), Call(box_12, V.Undef, x_2710, ((V)(8D)), ((V)(47.4)), ((V)((SW_2672 - 6D))), ((V)(22D)), ((V)(3D)), vD_2703, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)));
Invoke(o_2700, "push", Call(slab_16, V.Undef, x_2710, ((V)(6D)), ((V)((-38D))), ((V)(SW_2672)), ((V)(82D)), ((V)(16D)), v_2701, Call(fb_37, V.Undef, NewObj(2).Put("r", ((V)(14D))).Put("rb", ((V)(0D))).V)), Call(backC_55, V.Undef, x_2710, ((V)(32D)), ((V)(84D)), ((V)((-30D))), ((V)((-18D))), ((V)((SW_2672 - 8D))), vL_2702));
Invoke(Arr(((V)(0.3)), ((V)(0.55))), "forEach", Fn((V _arrowThis2719, int _argc2712, V t_2718, V _a2715, V _a2716, V _a2717, V[] _rest2713) => {
return Invoke(o_2700, "push", Call(slabX_17, V.Undef, x_2710, ((V)((32D + (52D * ToNum(t_2718))))), ((V)((-17.6))), ((V)((SW_2672 - 14D))), ((V)(0.8)), ((V)(0.8)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_2700, "push", Call(pillowZ_20, V.Undef, x_2710, ((V)(76D)), ((V)((-14D))), ((V)((SW_2672 - 22D))), ((V)(14D)), ((V)(8D)), Call(shade_21, V.Undef, VEL_75, ((V)(1.25)))), Call(slabX_17, V.Undef, x_2710, ((V)(86.4)), ((V)((-36D))), ((V)((SW_2672 - 10D))), ((V)(1.4)), ((V)(6D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)((ToNum(x_2710) - 6D))), ((V)(26D)), ((V)(48D)), ((V)(12D)), ((V)(2.6)), ((V)(1D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("noOut", ((V)(1D))).V)));
return default;
}, 1, "", true));
Call(rep_39, V.Undef, ((V)((n_2671 + 1D))), Fn((V _arrowThis2727, int _argc2720, V i_2726, V _a2723, V _a2724, V _a2725, V[] _rest2721) => {
double x_2728 = 0;
x_2728 = ((((-Wd_2674) / 2D) + (AW_2673 / 2D)) + (ToNum(i_2726) * (SW_2672 + AW_2673)));
Invoke(o_2700, "push", Call(box_12, V.Undef, ((V)(x_2728)), ((V)(6D)), ((V)(2D)), ((V)(AW_2673)), ((V)(40D)), ((V)(92D)), v_2701, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)), Call(box_12, V.Undef, ((V)(x_2728)), ((V)(46D)), ((V)(2D)), ((V)((AW_2673 + 2D))), ((V)(3D)), ((V)(94D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(arcW_18, V.Undef, ((V)(x_2728)), ((V)(49D)), ((V)(30D)), ((V)(5D)), ((V)(5D)), ((V)(1D)), ((V)(1.6)), ((V)(0D)), ((V)((2D * PI_31))), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_14, V.Undef, ((V)(x_2728)), ((V)(49D)), ((V)(30D)), ((V)(4D)), ((V)(0.4)), ((V)("#1d1d20")), NewObj(1).Put("n", ((V)(12D))).V));
if ((SEqN(i_2726, 1D) || SEqN(i_2726, 2D))) {
Call(bucket_71, V.Undef, o_2700, ((V)(x_2728)), ((V)(49.4)), ((V)(30D)), ((V)(4.4)), ((V)(9D)), ((V)(JsStrBuf.Begin().S("rc").V(i_2726).End())));
} else {
Invoke(o_2700, "push", Call(cyl_14, V.Undef, ((V)(x_2728)), ((V)(49.4)), ((V)(30D)), ((V)(3.4)), ((V)(10D)), ((V)("#d9363b")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_14, V.Undef, ((V)(x_2728)), ((V)(59.4)), ((V)(30D)), ((V)(3.6)), ((V)(1.2)), ((V)("#ffffff")), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_14, V.Undef, ((V)((x_2728 + 1D))), ((V)(60.6)), ((V)(30D)), ((V)(0.5)), ((V)(6D)), ((V)("#ffffff")), NewObj(1).Put("n", ((V)(4D))).V));
}
return default;
}, 1, "", true));
return o_2700;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2736, int _argc2729, V c_2735, V _a2732, V _a2733, V _a2734, V[] _rest2730) => {
return NewObj(1).Put("front", Invoke(Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis2744, int _argc2737, V i_2743, V _a2740, V _a2741, V _a2742, V[] _rest2738) => {
return Call(spark_52, V.Undef, c_2735, ((V)(((-60D) + (ToNum(i_2743) * 60D)))), ((V)(48D)), ((V)(46D)), ((V)(0.6)), ((V)(((-ToNum(i_2743)) * 0.7))), ((V)("#fff1c4")));
}, 1, "", true)), "join", ((V)("")))).V;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "luxTub", Fn((V _arrowThis2752, int _argc2745, V S_2751, V _a2748, V _a2749, V _a2750, V[] _rest2746) => {
return NewObj(6).Put("w", ((V)(120D))).Put("d", ((V)(64D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(4D))).Put("z", ((V)(0D))).Put("h", ((V)(30D))).V)).Put("build", Fn((V _arrowThis2760, int _argc2753, V P_2759, V _a2756, V _a2757, V _a2758, V[] _rest2754) => {
V o_2761 = default;
V R_2762 = default;
o_2761 = Arr();
Invoke(Arr(Arr(((V)((-34D))), ((V)((-14D)))), Arr(((V)(34D)), ((V)((-14D)))), Arr(((V)((-34D))), ((V)(14D))), Arr(((V)(34D)), ((V)(14D)))), "forEach", Fn((V _arrowThis2774, int _argc2763, V _a2765, V _a2766, V _a2767, V _a2768, V[] _rest2764) => {
V x_2771 = default;
V z_2773 = default;
{ V _t2769 = ListOf(_a2765);
{ V _t2770 = GetIdx(_t2769, 0D);
x_2771 = _t2770; }
{ V _t2772 = GetIdx(_t2769, 1D);
z_2773 = _t2772; }
}
Invoke(o_2761, "push", Call(cyl_14, V.Undef, x_2771, ((V)(3D)), z_2773, ((V)(3D)), ((V)(9D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.2))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(9D)), ((V)(0D)), ((V)(1.2))))).V)));
Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis2782, int _argc2775, V i_2781, V _a2778, V _a2779, V _a2780, V[] _rest2776) => {
return Invoke(o_2761, "push", Call(ball_15, V.Undef, Add(x_2771, ((V)(((ToNum(i_2781) - 1D) * 2.6)))), ((V)(0D)), Add(z_2773, ((V)((Sign(ToNum(z_2773)) * 2.4)))), ((V)(1.8)), GOLD_27, Call(mt_34, V.Undef, NewObj(3).Put("sy", ((V)(0.8))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(o_2761, "push", Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("y"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("a", ((V)(47D))).Put("b", ((V)(25D))).Put("n", ((V)(32D))).Put("rings", Arr(Arr(((V)(10D)), ((V)(0D)), ((V)(0.82))), Arr(((V)(14D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(26D)), ((V)(0D)), ((V)(0.98))), Arr(((V)(33D)), ((V)(0D)), ((V)(1D))))).Put("col", VEL_75).Put("mat", ((V)("paint"))).V), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(33D)), ((V)(0D)), ((V)(48.4)), ((V)(26.4)), ((V)(4.4)), ((V)(2D)), ((V)(0D)), ((V)((2D * PI_31))), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(32D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(33.4)), ((V)(0D)), ((V)(43D)), ((V)(1.2)), ((V)("#a9dcef")), NewObj(3).Put("rz", ((V)(21.6))).Put("n", ((V)(30D))).Put("op", ((V)(0.92))).V));
Call(rep_39, V.Undef, ((V)(4D)), Fn((V _arrowThis2790, int _argc2783, V i_2789, V _a2786, V _a2787, V _a2788, V[] _rest2784) => {
double a_2791 = 0;
a_2791 = (PI_31 * (0.1 + (ToNum(i_2789) * 0.27)));
Invoke(o_2761, "push", Call(ball_15, V.Undef, ((V)((FdLibm.Cos(a_2791) * 46D))), ((V)(22D)), ((V)((FdLibm.Sin(a_2791) * 25D))), ((V)(2.2)), GOLD_27, Call(mt_34, V.Undef, NewObj(4).Put("sz", ((V)(0.5))).Put("sx", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
return default;
}, 1, "", true));
R_2762 = Call(rng_50, V.Undef, ((V)("foam")));
Call(rep_39, V.Undef, ((V)(18D)), Fn((V _arrowThis2799, int _argc2792, V i_2798, V _a2795, V _a2796, V _a2797, V[] _rest2793) => {
double a_2800 = 0;
double t_2801 = 0;
a_2800 = ((ToNum(Call(R_2762, V.Undef)) * 2D) * PI_31);
t_2801 = (0.3 + (ToNum(Call(R_2762, V.Undef)) * 0.6));
Invoke(o_2761, "push", Call(ball_15, V.Undef, ((V)((10D + ((FdLibm.Cos(a_2800) * 30D) * t_2801)))), ((V)(33.6)), ((V)(((FdLibm.Sin(a_2800) * 15D) * t_2801))), ((V)((2.4 + (ToNum(Call(R_2762, V.Undef)) * 2.4)))), ((V)("#ffffff")), NewObj(3).Put("sy", ((V)(0.65))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V));
return default;
}, 1, "", true));
InvokeSpread(o_2761, "push", new ArrBuilder().Add(Call(cyl_14, V.Undef, ((V)((-50D))), ((V)(0D)), ((V)(0D)), ((V)(2.2)), ((V)(46D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))).Add(Call(box_12, V.Undef, ((V)((-45D))), ((V)(44D)), ((V)(0D)), ((V)(10D)), ((V)(2.4)), ((V)(2.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Add(Call(cyl_14, V.Undef, ((V)((-40D))), ((V)(40D)), ((V)(0D)), ((V)(1.6)), ((V)(4D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(8D))).V))).Spread(Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis2809, int _argc2802, V s_2808, V _a2805, V _a2806, V _a2807, V[] _rest2803) => {
return Call(ball_15, V.Undef, ((V)((-50D))), ((V)(40D)), ((V)((ToNum(s_2808) * 4D))), ((V)(2D)), ((V)("#fffaf1")), Call(cer_36, V.Undef, NewObj(1).Put("k", ((V)(3D))).V));
}, 1, "", true))).Add(Call(cyl_14, V.Undef, ((V)((-50D))), ((V)(46D)), ((V)(0D)), ((V)(3D)), ((V)(1.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))).V);
Invoke(o_2761, "push", Call(box_12, V.Undef, ((V)(16D)), ((V)(35.2)), ((V)(0D)), ((V)(10D)), ((V)(1.4)), ((V)(54D)), ((V)("#6b4226")), Call(wd_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(cyl_14, V.Undef, ((V)(16D)), ((V)(36.6)), ((V)((-12D))), ((V)(2.4)), ((V)(5D)), IVORY_77, NewObj(1).Put("n", ((V)(10D))).V), Call(ball_15, V.Undef, ((V)(16D)), ((V)(41.6)), ((V)((-12D))), ((V)(1D)), ((V)("#ffd66b")), Call(em_25, V.Undef, NewObj(1).Put("sy", ((V)(1.6))).V)), Call(box_12, V.Undef, ((V)(16D)), ((V)(36.6)), ((V)(8D)), ((V)(7D)), ((V)(1.6)), ((V)(9D)), ((V)("#2f4870")), NewObj(2).Put("r", ((V)(0.6))).Put("mat", ((V)("paint"))).V));
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis2817, int _argc2810, V i_2816, V _a2813, V _a2814, V _a2815, V[] _rest2811) => {
return Invoke(o_2761, "push", Call(ball_15, V.Undef, ((V)(((-10D) + (ToNum(i_2816) * 8D)))), ((V)(34.6)), ((V)(((NumTruthy((ToNum(i_2816) % 2D)) ? 1D : (-1D)) * 6D))), ((V)(1.4)), ((V)("#c8243a")), NewObj(4).Put("sy", ((V)(0.3))).Put("k", ((V)(2D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
return o_2761;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2825, int _argc2818, V c_2824, V _a2821, V _a2822, V _a2823, V[] _rest2819) => {
V f_2826 = default;
f_2826 = Call(steam_51, V.Undef, c_2824, ((V)((-6D))), ((V)(36D)), ((V)(0D)), ((V)(0.9)), ((V)(4D)));
Call(rep_39, V.Undef, ((V)(8D)), Fn((V _arrowThis2834, int _argc2827, V i_2833, V _a2830, V _a2831, V _a2832, V[] _rest2828) => {
V a_2835 = default;
V d_2836 = default;
a_2835 = Invoke(c_2824, "p", ((V)(((-12D) + (ToNum(i_2833) * 6D)))), ((V)(36D)), ((V)((((ToNum(i_2833) % 3D) - 1D) * 6D))));
d_2836 = Invoke(((V)((2D + ((ToNum(i_2833) % 3D) * 0.4)))), "toFixed", ((V)(1D)));
f_2826 = ((V)(JsStrBuf.Begin().V(f_2826).S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(a_2835, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(a_2835, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)(((1D + ((ToNum(i_2833) % 3D) * 0.5)) * ToNum(Get(c_2824, "k"))))))).S("\" fill=\"#ffffff\" fill-opacity=\"0.25\" stroke=\"#ffffff\" stroke-width=\"0.4\">").V(Call(an_40, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(a_2835, 1D))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(a_2835, 1D)) - (26D * ToNum(Get(c_2824, "k")))))))).End())), d_2836, ((V)(((-ToNum(i_2833)) * 0.43))))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0;1;0")), d_2836, ((V)(((-ToNum(i_2833)) * 0.43))))).S("</circle>").End()));
return default;
}, 1, "", true));
f_2826 = ((V)(JsStrBuf.Begin().V(f_2826).S("<g transform=\"").V(Call(planeH_46, V.Undef, Get(c_2824, "p"), ((V)(34.7)))).S("\">").V(Invoke(Call(rep_39, V.Undef, ((V)(2D)), Fn((V _arrowThis2844, int _argc2837, V i_2843, V _a2840, V _a2841, V _a2842, V[] _rest2838) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"-30\" cy=\"0\" rx=\"3\" ry=\"2\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.5\">").V(Call(an_40, V.Undef, ((V)("rx")), ((V)("2;12")), ((V)(2D)), ((V)((-ToNum(i_2843)))))).V(Call(an_40, V.Undef, ((V)("ry")), ((V)("1.4;8")), ((V)(2D)), ((V)((-ToNum(i_2843)))))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.8;0")), ((V)(2D)), ((V)((-ToNum(i_2843)))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>").End()));
return NewObj(1).Put("front", f_2826).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "luxVanity", Fn((V _arrowThis2852, int _argc2845, V S_2851, V _a2848, V _a2849, V _a2850, V[] _rest2846) => {
return NewObj(5).Put("w", ((V)(146D))).Put("d", ((V)(54D))).Put("build", Fn((V _arrowThis2860, int _argc2853, V P_2859, V _a2856, V _a2857, V _a2858, V[] _rest2854) => {
V o_2861 = default;
V ON_2862 = default;
V R_2863 = default;
o_2861 = Arr();
ON_2862 = ((V)("#26232b"));
R_2863 = Call(rng_50, V.Undef, ((V)("vanity")));
Invoke(Arr(Arr(((V)((-64D))), ((V)((-18D)))), Arr(((V)(64D)), ((V)((-18D)))), Arr(((V)((-64D))), ((V)(18D))), Arr(((V)(64D)), ((V)(18D)))), "forEach", Fn((V _arrowThis2875, int _argc2864, V _a2866, V _a2867, V _a2868, V _a2869, V[] _rest2865) => {
V x_2872 = default;
V z_2874 = default;
{ V _t2870 = ListOf(_a2866);
{ V _t2871 = GetIdx(_t2870, 0D);
x_2872 = _t2871; }
{ V _t2873 = GetIdx(_t2870, 1D);
z_2874 = _t2873; }
}
return Invoke(o_2861, "push", Call(cyl_14, V.Undef, x_2872, ((V)(0D)), z_2874, ((V)(2.2)), ((V)(30D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.4))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(30D)), ((V)(0D)), ((V)(1D))))).V)));
}, 1, "", true));
Invoke(o_2861, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(128D)), ((V)(2D)), ((V)(40D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slab_16, V.Undef, ((V)(0D)), ((V)(36D)), ((V)((-21.6))), ((V)(140D)), ((V)(64D)), ((V)(3D)), ON_2862, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("cer"))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(140D)), ((V)(6D)), ((V)(46D)), ON_2862, Call(cer_36, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(29.4)), ((V)(0D)), ((V)(141.4)), ((V)(1.2)), ((V)(47.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slabX_17, V.Undef, ((V)(0D)), ((V)(99.4)), ((V)((-22.6))), ((V)(142D)), ((V)(2D)), ((V)(4D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Call(veins_79, V.Undef, o_2861, R_2863, ((V)(0D)), ((V)(36.05)), ((V)(0D)), ((V)(130D)), ((V)(40D)), ((V)(8D)), GOLD_27);
Invoke(Arr(((V)((-34D))), ((V)(34D))), "forEach", Fn((V _arrowThis2883, int _argc2876, V x_2882, V _a2879, V _a2880, V _a2881, V[] _rest2877) => {
Invoke(o_2861, "push", Call(cyl_14, V.Undef, x_2882, ((V)(36D)), ((V)(4D)), ((V)(13D)), ((V)(9D)), ((V)("#fbf8f2")), Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.55))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V)), Call(arcW_18, V.Undef, x_2882, ((V)(44.4)), ((V)(4D)), ((V)(13D)), ((V)(13D)), ((V)(1.4)), ((V)(0.6)), ((V)(0D)), ((V)((2D * PI_31))), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)), Call(cyl_14, V.Undef, x_2882, ((V)(43.6)), ((V)(4D)), ((V)(11D)), ((V)(0.6)), ((V)("#bfe4f2")), NewObj(2).Put("n", ((V)(20D))).Put("op", ((V)(0.9))).V));
InvokeSpread(o_2861, "push", new ArrBuilder().Add(Call(cyl_14, V.Undef, x_2882, ((V)(36D)), ((V)((-16D))), ((V)(1.8)), ((V)(24D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(8D))).V))).Add(Call(box_12, V.Undef, x_2882, ((V)(58D)), ((V)((-11D))), ((V)(2.4)), ((V)(2.4)), ((V)(11D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Add(Call(cyl_14, V.Undef, x_2882, ((V)(54D)), ((V)((-6D))), ((V)(1.2)), ((V)(4D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(6D))).V))).Spread(Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis2891, int _argc2884, V s_2890, V _a2887, V _a2888, V _a2889, V[] _rest2885) => {
return Call(ball_15, V.Undef, Add(x_2882, ((V)((ToNum(s_2890) * 4D)))), ((V)(36D)), ((V)((-16D))), ((V)(1.8)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("k", ((V)(3D))).V));
}, 1, "", true))).V);
InvokeSpread(o_2861, "push", new ArrBuilder().Add(Call(disc_19, V.Undef, x_2882, ((V)(74D)), ((V)((-21D))), ((V)(19D)), ((V)(1.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(26D))).V))).Add(Call(disc_19, V.Undef, x_2882, ((V)(74D)), ((V)((-19.6))), ((V)(17D)), ((V)(0.6)), ((V)("#d8eef5")), Call(cer_36, V.Undef, NewObj(1).Put("n", ((V)(24D))).V))).Spread(Call(rep_39, V.Undef, ((V)(8D)), Fn((V _arrowThis2899, int _argc2892, V i_2898, V _a2895, V _a2896, V _a2897, V[] _rest2893) => {
double a_2900 = 0;
a_2900 = (((ToNum(i_2898) / 8D) * 2D) * PI_31);
return Call(ball_15, V.Undef, Add(x_2882, ((V)((FdLibm.Cos(a_2900) * 19D)))), ((V)((74D + (FdLibm.Sin(a_2900) * 19D)))), ((V)((-19.6))), ((V)(1.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
return default;
}, 1, "", true))).V);
return default;
}, 1, "", true));
Invoke(Arr(((V)((-66D))), ((V)(0D)), ((V)(66D))), "forEach", Fn((V _arrowThis2908, int _argc2901, V x_2907, V _a2904, V _a2905, V _a2906, V[] _rest2902) => {
return Invoke(o_2861, "push", Call(cyl_14, V.Undef, x_2907, ((V)(72D)), ((V)((-20D))), ((V)(1.4)), ((V)(6D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(cyl_14, V.Undef, x_2907, ((V)(78D)), ((V)((-16D))), ((V)(3.6)), ((V)(7D)), ((V)("#fff6e2")), NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(7D)), ((V)(0D)), ((V)(1D))))).V), Call(ball_15, V.Undef, x_2907, ((V)(79D)), ((V)((-16D))), ((V)(1.6)), ((V)("#ffe9a0")), Call(em_25, V.Undef, NewObj(1).Put("k", ((V)(3D))).V)));
}, 1, "", true));
Invoke(o_2861, "push", Call(cush_13, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(30D)), ((V)(6D)), ((V)(22D)), ((V)("#fffaf1"))), Call(cush_13, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)), ((V)(28D)), ((V)(5D)), ((V)(20D)), ((V)("#f6efe0"))), Call(box_12, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(12D)), ((V)(10D)), ((V)(1.6)), ((V)(7D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(ball_15, V.Undef, ((V)(0D)), ((V)(37.6)), ((V)(12D)), ((V)(3D)), ((V)("#f6a8c4")), NewObj(2).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).V));
Invoke(Arr(Arr(((V)((-8D))), ((V)(0D)), ((V)("#f6a8c4"))), Arr(((V)(8D)), ((V)((-4D))), ((V)("#d8a03a")))), "forEach", Fn((V _arrowThis2922, int _argc2909, V _a2911, V _a2912, V _a2913, V _a2914, V[] _rest2910) => {
V x_2917 = default;
V z_2919 = default;
V cc_2921 = default;
{ V _t2915 = ListOf(_a2911);
{ V _t2916 = GetIdx(_t2915, 0D);
x_2917 = _t2916; }
{ V _t2918 = GetIdx(_t2915, 1D);
z_2919 = _t2918; }
{ V _t2920 = GetIdx(_t2915, 2D);
cc_2921 = _t2920; }
}
return Invoke(o_2861, "push", Call(cyl_14, V.Undef, x_2917, ((V)(36D)), ((V)((ToNum(z_2919) - 10D))), ((V)(3D)), ((V)(8D)), cc_2921, Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("op", ((V)(0.7))).V)), Call(cyl_14, V.Undef, x_2917, ((V)(44D)), ((V)((ToNum(z_2919) - 10D))), ((V)(1.4)), ((V)(3D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
return o_2861;
return default;
}, 1, "build", true)).Put("glow", Fn((V _arrowThis2929, int _argc2923, V _a2925, V _a2926, V _a2927, V _a2928, V[] _rest2924) => {
return NewObj(3).Put("y", ((V)(80D))).Put("r", ((V)(72D))).Put("c", ((V)("url(#gWarm)"))).V;
}, 0, "glow", true)).Put("fx", Fn((V _arrowThis2937, int _argc2930, V c_2936, V _a2933, V _a2934, V _a2935, V[] _rest2931) => {
return NewObj(1).Put("front", Invoke(Invoke(Arr(((V)((-34D))), ((V)(34D))), "map", Fn((V _arrowThis2946, int _argc2938, V x_2944, V i_2945, V _a2942, V _a2943, V[] _rest2939) => {
return Call(spark_52, V.Undef, c_2936, ((V)((ToNum(x_2944) - 6D))), ((V)(82D)), ((V)((-19D))), ((V)(0.8)), ((V)(((-ToNum(i_2945)) * 0.9))), ((V)("#ffffff")));
}, 2, "", true)), "join", ((V)("")))).V;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "luxBed", Fn((V _arrowThis2954, int _argc2947, V S_2953, V _a2950, V _a2951, V _a2952, V[] _rest2948) => {
return NewObj(6).Put("w", ((V)(140D))).Put("d", ((V)(156D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-26D)))).Put("z", ((V)((-10D)))).Put("h", ((V)(44D))).V, NewObj(3).Put("x", ((V)(26D))).Put("z", ((V)((-10D)))).Put("h", ((V)(44D))).V)).Put("build", Fn((V _arrowThis2962, int _argc2955, V P_2961, V _a2958, V _a2959, V _a2960, V[] _rest2956) => {
V o_2963 = default;
V EB_2964 = default;
V IV_2965 = default;
double HB_2966 = 0;
double PH_2967 = 0;
o_2963 = Arr();
EB_2964 = ((V)("#2c2420"));
IV_2965 = ((V)("#fffaf1"));
HB_2966 = 76D;
PH_2967 = 150D;
Invoke(Arr(Arr(((V)((-62D))), ((V)((-72D)))), Arr(((V)(62D)), ((V)((-72D)))), Arr(((V)((-62D))), ((V)(74D))), Arr(((V)(62D)), ((V)(74D)))), "forEach", Fn((V _arrowThis2979, int _argc2968, V _a2970, V _a2971, V _a2972, V _a2973, V[] _rest2969) => {
V x_2976 = default;
V z_2978 = default;
{ V _t2974 = ListOf(_a2970);
{ V _t2975 = GetIdx(_t2974, 0D);
x_2976 = _t2975; }
{ V _t2977 = GetIdx(_t2974, 1D);
z_2978 = _t2977; }
}
return Call(goldPost_80, V.Undef, o_2963, x_2976, z_2978, ((V)(0D)), ((V)(PH_2967)), ((V)(3D)));
}, 1, "", true));
Invoke(o_2963, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(1D)), ((V)(120D)), ((V)(16D)), ((V)(142D)), EB_2964, Call(wd_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(72.4)), ((V)(120D)), ((V)(1.2)), ((V)(1D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(20.6)), ((V)(72.4)), ((V)(120D)), ((V)(1.2)), ((V)(1D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(2D)), ((V)(116D)), ((V)(14D)), ((V)(138D)), IV_2965, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)));
Invoke(o_2963, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)(22D)), ((V)((-71D))), ((V)(118D)), ((V)(HB_2966)), ((V)(6D)), VEL_75, Call(fb_37, V.Undef, NewObj(2).Put("r", ((V)(16D))).Put("rb", ((V)(0D))).V)));
Call(tuftGrid_81, V.Undef, o_2963, ((V)((-52D))), ((V)(52D)), ((V)(40D)), ((V)(92D)), ((V)((-67.6))), ((V)(7D)), ((V)(4D)), VEL_75, GOLD_27);
Invoke(o_2963, "push", Call(solid_11, V.Undef, NewObj(12).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)(((22D + HB_2966) - 30D))))).Put("a", ((V)(60D))).Put("b", ((V)(34D))).Put("th", ((V)(3D))).Put("a0", ((V)(0.12))).Put("a1", ((V)((PI_31 - 0.12)))).Put("n", ((V)(16D))).Put("rings", Arr(Arr(((V)((-74.6))), ((V)(0D))), Arr(((V)((-67.4))), ((V)(0D))))).Put("col", GOLD_27).Put("mat", ((V)("metal"))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)(((22D + HB_2966) + 3D))), ((V)((-71D))), ((V)(5D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("sz", ((V)(0.5))).Put("k", ((V)(4D))).V)));
Invoke(o_2963, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(18D)), ((V)(122D)), ((V)(6D)), ((V)(106D)), IVORY_77, Call(fb_37, V.Undef, NewObj(2).Put("r", ((V)(8D))).Put("bev", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(42D)), ((V)((-30D))), ((V)(122D)), ((V)(2.6)), ((V)(12D)), VEL_75, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(52D)), ((V)(124D)), ((V)(2.4)), ((V)(26D)), VEL_75, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(43.6)), ((V)(39.6)), ((V)(124D)), ((V)(0.8)), ((V)(1.2)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2987, int _argc2980, V sg_2986, V _a2983, V _a2984, V _a2985, V[] _rest2981) => {
Invoke(o_2963, "push", Call(box_12, V.Undef, ((V)((ToNum(sg_2986) * 62.6))), ((V)(24D)), ((V)(52D)), ((V)(1.6)), ((V)(20D)), ((V)(26D)), VEL_75, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((ToNum(sg_2986) * 62.8))), ((V)(22.6)), ((V)(52D)), ((V)(1.8)), ((V)(1.6)), ((V)(26.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
Call(rep_39, V.Undef, ((V)(7D)), Fn((V _arrowThis2995, int _argc2988, V i_2994, V _a2991, V _a2992, V _a2993, V[] _rest2989) => {
return Invoke(o_2963, "push", Call(box_12, V.Undef, ((V)((ToNum(sg_2986) * 62.8))), ((V)(19.6)), ((V)((41D + (ToNum(i_2994) * 3.6)))), ((V)(0.8)), ((V)(3D)), ((V)(0.8)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3003, int _argc2996, V sg_3002, V _a2999, V _a3000, V _a3001, V[] _rest2997) => {
return Invoke(o_2963, "push", Call(pillowZ_20, V.Undef, ((V)((ToNum(sg_3002) * 28D))), ((V)(36D)), ((V)((-60D))), ((V)(50D)), ((V)(30D)), ((V)(12D)), IV_2965), Call(throwP_56, V.Undef, ((V)((ToNum(sg_3002) * 18D))), ((V)(36D)), ((V)((-48.4))), ((V)(22D)), (LtN(sg_3002, 0D) ? VEL_75 : ((V)("#1f4f3e")))));
}, 1, "", true));
Invoke(o_2963, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("z"))).Put("sh", ((V)("rr"))).Put("c", Arr(((V)(0D)), ((V)(44D)))).Put("a", ((V)(16D))).Put("b", ((V)(8D))).Put("r", ((V)(7D))).Put("rings", Arr(Arr(((V)((-48.4))), ((V)(3D)), ((V)(0.82))), Arr(((V)((-46.4))), ((V)(0.6)), ((V)(0.97))), Arr(((V)((-44D))), ((V)(0D)), ((V)(1D))), Arr(((V)((-41.6))), ((V)(0.6)), ((V)(0.97))), Arr(((V)((-39.6))), ((V)(3D)), ((V)(0.82))))).Put("col", GOLD_27).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3011, int _argc3004, V sg_3010, V _a3007, V _a3008, V _a3009, V[] _rest3005) => {
Invoke(o_2963, "push", Call(slabX_17, V.Undef, ((V)(0D)), ((V)((PH_2967 - 2D))), ((V)((ToNum(sg_3010) * 73D))), ((V)(128D)), ((V)(4D)), ((V)(4D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((ToNum(sg_3010) * 62D))), ((V)((PH_2967 - 2D))), ((V)(1D)), ((V)(4D)), ((V)(4D)), ((V)(146D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
return default;
}, 1, "", true));
Invoke(o_2963, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)((PH_2967 - 14D))), ((V)(76D)), ((V)(122D)), ((V)(12D)), ((V)(1.4)), VEL_75, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((PH_2967 - 15D))), ((V)(76.8)), ((V)(122D)), ((V)(1.4)), ((V)(1D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Call(slab_16, V.Undef, ((V)(0D)), ((V)((PH_2967 - 14D))), ((V)((-76D))), ((V)(122D)), ((V)(12D)), ((V)(1.4)), VEL_75, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3019, int _argc3012, V sg_3018, V _a3015, V _a3016, V _a3017, V[] _rest3013) => {
return Invoke(o_2963, "push", Call(slabX_17, V.Undef, ((V)((ToNum(sg_3018) * 64D))), ((V)((PH_2967 - 14D))), ((V)(0D)), ((V)(1.4)), ((V)(12D)), ((V)(146D)), VEL_75, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)((ToNum(sg_3018) * 64.8))), ((V)((PH_2967 - 15D))), ((V)(0D)), ((V)(1D)), ((V)(1.4)), ((V)(146D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-56D))), ((V)(74D))), Arr(((V)(56D)), ((V)(74D))), Arr(((V)((-56D))), ((V)((-70D)))), Arr(((V)(56D)), ((V)((-70D))))), "forEach", Fn((V _arrowThis3032, int _argc3020, V _a3022, V i_3026, V _a3024, V _a3025, V[] _rest3021) => {
V x_3029 = default;
V z_3031 = default;
{ V _t3027 = ListOf(_a3022);
{ V _t3028 = GetIdx(_t3027, 0D);
x_3029 = _t3028; }
{ V _t3030 = GetIdx(_t3027, 1D);
z_3031 = _t3030; }
}
Invoke(o_2963, "push", Call(cyl_14, V.Undef, x_3029, ((V)(16D)), z_3031, ((V)(6D)), ((V)((PH_2967 - 30D))), VEL_75, Call(fb_37, V.Undef, NewObj(3).Put("rz", ((V)(3.4))).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.7))), Arr(((V)(40D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(52D)), ((V)(0D)), ((V)(0.5))), Arr(((V)(62D)), ((V)(0D)), ((V)(0.8))), Arr(((V)((PH_2967 - 30D))), ((V)(0D)), ((V)(1.2))))).V)), Call(ball_15, V.Undef, x_3029, ((V)(66D)), Add(z_3031, ((V)((GtN(z_3031, 0D) ? 3D : 0D)))), ((V)(2.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("sy", ((V)(1.6))).Put("k", ((V)(3D))).V)));
return default;
}, 2, "", true));
return o_2963;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis3040, int _argc3033, V c_3039, V _a3036, V _a3037, V _a3038, V[] _rest3034) => {
return NewObj(1).Put("front", Invoke(Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis3048, int _argc3041, V i_3047, V _a3044, V _a3045, V _a3046, V[] _rest3042) => {
return Call(spark_52, V.Undef, c_3039, ((V)(((-40D) + (ToNum(i_3047) * 40D)))), ((V)(148D)), ((V)(76D)), ((V)(0.7)), ((V)(((-ToNum(i_3047)) * 0.6))), ((V)("#fff1c4")));
}, 1, "", true)), "join", ((V)("")))).V;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "luxDresser", Fn((V _arrowThis3056, int _argc3049, V S_3055, V _a3052, V _a3053, V _a3054, V[] _rest3050) => {
return NewObj(6).Put("w", ((V)(116D))).Put("d", ((V)(52D))).Put("topH", ((V)(66D))).Put("topW", ((V)(80D))).Put("build", Fn((V _arrowThis3064, int _argc3057, V P_3063, V _a3060, V _a3061, V _a3062, V[] _rest3058) => {
V o_3065 = default;
V MIR_3066 = default;
V R_3067 = default;
o_3065 = Arr();
MIR_3066 = ((V)("#d4e2e8"));
R_3067 = Call(rng_50, V.Undef, ((V)("dresser")));
Invoke(Arr(Arr(((V)((-50D))), ((V)((-18D)))), Arr(((V)(50D)), ((V)((-18D)))), Arr(((V)((-50D))), ((V)(18D))), Arr(((V)(50D)), ((V)(18D)))), "forEach", Fn((V _arrowThis3079, int _argc3068, V _a3070, V _a3071, V _a3072, V _a3073, V[] _rest3069) => {
V x_3076 = default;
V z_3078 = default;
{ V _t3074 = ListOf(_a3070);
{ V _t3075 = GetIdx(_t3074, 0D);
x_3076 = _t3075; }
{ V _t3077 = GetIdx(_t3074, 1D);
z_3078 = _t3077; }
}
return Invoke(o_3065, "push", Call(cyl_14, V.Undef, x_3076, ((V)(0D)), z_3078, ((V)(2.6)), ((V)(10D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(4D)), ((V)(0D)), ((V)(1.2))), Arr(((V)(10D)), ((V)(0D)), ((V)(1D))))).V)));
}, 1, "", true));
Invoke(o_3065, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(108D)), ((V)(52D)), ((V)(44D)), MIR_3066, Call(cer_36, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(62D)), ((V)(0D)), ((V)(112D)), ((V)(4D)), ((V)(48D)), MARB_78, Call(cer_36, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(61.4)), ((V)(0D)), ((V)(112.8)), ((V)(1D)), ((V)(48.8)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Call(veins_79, V.Undef, o_3065, R_3067, ((V)(0D)), ((V)(66.05)), ((V)(0D)), ((V)(100D)), ((V)(40D)), ((V)(5D)));
Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis3087, int _argc3080, V j_3086, V _a3083, V _a3084, V _a3085, V[] _rest3081) => {
return Call(rep_39, V.Undef, ((V)(2D)), Fn((V _arrowThis3095, int _argc3088, V i_3094, V _a3091, V _a3092, V _a3093, V[] _rest3089) => {
double x_3096 = 0;
double y_3097 = 0;
x_3096 = ((Truthy(i_3094) ? 1D : (-1D)) * 26D);
y_3097 = (14D + (ToNum(j_3086) * 16D));
Invoke(o_3065, "push", Call(slab_16, V.Undef, ((V)(x_3096)), ((V)(y_3097)), ((V)(22.4)), ((V)(50D)), ((V)(14D)), ((V)(0.8)), Call(shade_21, V.Undef, MIR_3066, ((V)(1.04))), Call(cer_36, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(x_3096)), ((V)((y_3097 + 13.6))), ((V)(22.9)), ((V)(50D)), ((V)(0.6)), ((V)(0.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Call(ball_15, V.Undef, ((V)(x_3096)), ((V)((y_3097 + 6.4))), ((V)(23.6)), ((V)(2D)), ((V)("#f4fbff")), Call(cer_36, V.Undef, NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("op", ((V)(0.92))).V)), Call(ball_15, V.Undef, ((V)(x_3096)), ((V)((y_3097 + 6.4))), ((V)(23.2)), ((V)(2.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(3).Put("sz", ((V)(0.3))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V)));
return default;
}, 1, "", true));
}, 1, "", true));
Invoke(o_3065, "push", Call(slab_16, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(22.6)), ((V)(1D)), ((V)(48D)), ((V)(0.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
Invoke(o_3065, "push", Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(102D)))).Put("a", ((V)(26D))).Put("b", ((V)(34D))).Put("n", ((V)(26D))).Put("rings", Arr(Arr(((V)((-20D))), ((V)(0D))), Arr(((V)((-17.6))), ((V)(0D))))).Put("col", GOLD_27).Put("mat", ((V)("metal"))).V), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(102D)))).Put("a", ((V)(22.6))).Put("b", ((V)(30.6))).Put("n", ((V)(24D))).Put("rings", Arr(Arr(((V)((-17.6))), ((V)(0D))), Arr(((V)((-17D))), ((V)(0D))))).Put("col", ((V)("#dbeef5"))).Put("mat", ((V)("cer"))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)(135D)), ((V)((-19D))), ((V)(4.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("sz", ((V)(0.5))).Put("k", ((V)(4D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(66D)), ((V)((-18.6))), ((V)(14D)), ((V)(4D)), ((V)(4D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(o_3065, "push", Call(box_12, V.Undef, ((V)((-34D))), ((V)(66D)), ((V)(2D)), ((V)(20D)), ((V)(9D)), ((V)(14D)), VEL_75, Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(1.4))).V)), Call(box_12, V.Undef, ((V)((-34D))), ((V)(75D)), ((V)(2D)), ((V)(21D)), ((V)(1.6)), ((V)(15D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(ball_15, V.Undef, ((V)((-34D))), ((V)(76.6)), ((V)(2D)), ((V)(1.6)), ((V)("#f4fbff")), Call(cer_36, V.Undef, NewObj(1).Put("k", ((V)(3D))).V)));
Invoke(Arr(Arr(((V)(26D)), ((V)(4D)), ((V)("#f6a8c4"))), Arr(((V)(36D)), ((V)((-4D))), ((V)("#d8a03a"))), Arr(((V)(34D)), ((V)(10D)), ((V)("#bfe4ff")))), "forEach", Fn((V _arrowThis3112, int _argc3098, V _a3100, V i_3104, V _a3102, V _a3103, V[] _rest3099) => {
V x_3107 = default;
V z_3109 = default;
V cc_3111 = default;
{ V _t3105 = ListOf(_a3100);
{ V _t3106 = GetIdx(_t3105, 0D);
x_3107 = _t3106; }
{ V _t3108 = GetIdx(_t3105, 1D);
z_3109 = _t3108; }
{ V _t3110 = GetIdx(_t3105, 2D);
cc_3111 = _t3110; }
}
return Invoke(o_3065, "push", Call(cyl_14, V.Undef, x_3107, ((V)(66D)), z_3109, ((V)(3.4)), ((V)((7D + (ToNum(i_3104) * 2D)))), cc_3111, Call(cer_36, V.Undef, NewObj(3).Put("n", ((V)(12D))).Put("op", ((V)(0.72))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))), Arr(((V)((7D + (ToNum(i_3104) * 2D)))), ((V)(0D)), ((V)(0.6))))).V)), Call(ball_15, V.Undef, x_3107, ((V)((73D + (ToNum(i_3104) * 2D)))), z_3109, ((V)(2D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("k", ((V)(3D))).V)));
}, 2, "", true));
Call(rep_39, V.Undef, ((V)(14D)), Fn((V _arrowThis3120, int _argc3113, V i_3119, V _a3116, V _a3117, V _a3118, V[] _rest3114) => {
double a_3121 = 0;
a_3121 = (PI_31 * (0.15 + (ToNum(i_3119) * 0.05)));
Invoke(o_3065, "push", Call(ball_15, V.Undef, ((V)(((-12D) + (FdLibm.Cos(a_3121) * 10D)))), ((V)(66D)), ((V)((10D + (FdLibm.Sin(a_3121) * 6D)))), ((V)(1.1)), ((V)("#fffaf1")), Call(cer_36, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V)));
return default;
}, 1, "", true));
return o_3065;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis3129, int _argc3122, V c_3128, V _a3125, V _a3126, V _a3127, V[] _rest3123) => {
return NewObj(1).Put("front", Invoke(Arr(Call(spark_52, V.Undef, c_3128, ((V)((-8D))), ((V)(112D)), ((V)((-17D))), ((V)(0.9)), ((V)(0D)), ((V)("#ffffff"))), Call(spark_52, V.Undef, c_3128, ((V)(10D)), ((V)(92D)), ((V)((-17D))), ((V)(0.6)), ((V)((-0.8))), ((V)("#ffffff"))), Call(spark_52, V.Undef, c_3128, ((V)(26D)), ((V)(30D)), ((V)(23D)), ((V)(0.6)), ((V)((-1.3))), ((V)("#ffffff")))), "join", ((V)("")))).V;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "luxFountain", Fn((V _arrowThis3137, int _argc3130, V S_3136, V _a3133, V _a3134, V _a3135, V[] _rest3131) => {
return NewObj(4).Put("w", ((V)(124D))).Put("d", ((V)(100D))).Put("build", Fn((V _arrowThis3145, int _argc3138, V P_3144, V _a3141, V _a3142, V _a3143, V[] _rest3139) => {
V o_3146 = default;
V WT_3147 = default;
V swan_3148 = default;
o_3146 = Arr();
WT_3147 = ((V)("#7ec8e3"));
Invoke(o_3146, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(51D)), ((V)(13D)), WT_3147, NewObj(3).Put("rz", ((V)(39D))).Put("n", ((V)(32D))).Put("op", ((V)(0.95))).V), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(56D)), ((V)(44D)), ((V)(6D)), ((V)(16D)), ((V)(0D)), ((V)((2D * PI_31))), MARB_78, Call(cer_36, V.Undef, NewObj(1).Put("n", ((V)(32D))).V)), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)), ((V)(57D)), ((V)(45D)), ((V)(8D)), ((V)(1.8)), ((V)(0D)), ((V)((2D * PI_31))), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(32D))).V)));
Invoke(o_3146, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(13D)), ((V)(0D)), ((V)(9D)), ((V)(24D)), MARB_78, Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.3))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(18D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(24D)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(37D)), ((V)(0D)), ((V)(27D)), ((V)(7D)), MARB_78, Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.35))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.85))), Arr(((V)(7D)), ((V)(0D)), ((V)(1D))))).V)), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(0D)), ((V)(27.6)), ((V)(27.6)), ((V)(2.4)), ((V)(1.2)), ((V)(0D)), ((V)((2D * PI_31))), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(43.2)), ((V)(0D)), ((V)(25D)), ((V)(0.8)), WT_3147, NewObj(2).Put("n", ((V)(22D))).Put("op", ((V)(0.95))).V));
Invoke(o_3146, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(0D)), ((V)(4.6)), ((V)(18D)), MARB_78, Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.2))), Arr(((V)(9D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(18D)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(62D)), ((V)(0D)), ((V)(14D)), ((V)(5D)), MARB_78, Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.35))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))))).V)), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(67D)), ((V)(0D)), ((V)(14.6)), ((V)(14.6)), ((V)(1.8)), ((V)(1D)), ((V)(0D)), ((V)((2D * PI_31))), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(66.4)), ((V)(0D)), ((V)(12.6)), ((V)(0.6)), WT_3147, NewObj(2).Put("n", ((V)(16D))).Put("op", ((V)(0.95))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)(67D)), ((V)(0D)), ((V)(4.2)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("sy", ((V)(1.4))).Put("k", ((V)(5D))).V)), Call(ball_15, V.Undef, ((V)(0D)), ((V)(78.4)), ((V)(0D)), ((V)(1.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("k", ((V)(3D))).V)));
swan_3148 = Fn((V _arrowThis3158, int _argc3149, V x_3155, V z_3156, V d_3157, V _a3154, V[] _rest3150) => {
Invoke(o_3146, "push", Call(ball_15, V.Undef, x_3155, ((V)(11.4)), z_3156, ((V)(7.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(4).Put("sx", ((V)(1.35))).Put("sy", ((V)(0.62))).Put("k", ((V)(5D))).Put("n", ((V)(14D))).V)), Call(ball_15, V.Undef, ((V)((ToNum(x_3155) - (ToNum(d_3157) * 7D)))), ((V)(15.4)), z_3156, ((V)(3.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(4).Put("sx", ((V)(1.2))).Put("sy", ((V)(1.2))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V)));
Invoke(Arr(Arr(((V)(3D)), ((V)(17D))), Arr(((V)(4.6)), ((V)(21D))), Arr(((V)(4.4)), ((V)(25D))), Arr(((V)(3.2)), ((V)(28.6)))), "forEach", Fn((V _arrowThis3171, int _argc3159, V _a3161, V i_3165, V _a3163, V _a3164, V[] _rest3160) => {
V dx_3168 = default;
V y_3170 = default;
{ V _t3166 = ListOf(_a3161);
{ V _t3167 = GetIdx(_t3166, 0D);
dx_3168 = _t3167; }
{ V _t3169 = GetIdx(_t3166, 1D);
y_3170 = _t3169; }
}
return Invoke(o_3146, "push", Call(ball_15, V.Undef, Add(x_3155, ((V)((ToNum(d_3157) * ToNum(dx_3168))))), y_3170, z_3156, ((V)((1.9 - (ToNum(i_3165) * 0.12)))), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
}, 2, "", true));
Invoke(o_3146, "push", Call(ball_15, V.Undef, Add(x_3155, ((V)((ToNum(d_3157) * 1.6)))), ((V)(30.6)), z_3156, ((V)(2.2)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)), Call(cyl_14, V.Undef, ((V)((ToNum(x_3155) - (ToNum(d_3157) * 0.4)))), ((V)(30.6)), z_3156, ((V)(0.7)), ((V)(1.8)), ((V)("#2c2420")), NewObj(1).Put("n", ((V)(4D))).V));
return default;
}, 3, "", true);
Call(swan_3148, V.Undef, ((V)((-30D))), ((V)(16D)), ((V)(1D)));
Call(swan_3148, V.Undef, ((V)(30D)), ((V)((-14D))), ((V)((-1D))));
Call(swan_3148, V.Undef, ((V)(26D)), ((V)(18D)), ((V)((-1D))));
Call(swan_3148, V.Undef, ((V)((-26D))), ((V)((-16D))), ((V)(1D)));
return o_3146;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis3179, int _argc3172, V c_3178, V _a3175, V _a3176, V _a3177, V[] _rest3173) => {
V u_3180 = default;
JsStrBuf f_3181 = null;
V t0_3182 = default;
u_3180 = Get(c_3178, "k");
f_3181 = new JsStrBuf("");
Call(rep_39, V.Undef, ((V)(10D)), Fn((V _arrowThis3190, int _argc3183, V i_3189, V _a3186, V _a3187, V _a3188, V[] _rest3184) => {
double a_3191 = 0;
V s_3192 = default;
V e_3193 = default;
a_3191 = (PI_31 * (0.1 + (ToNum(i_3189) * 0.09)));
s_3192 = Invoke(c_3178, "p", ((V)((FdLibm.Cos(a_3191) * 27.6))), ((V)(44D)), ((V)((FdLibm.Sin(a_3191) * 27.6))));
e_3193 = Invoke(c_3178, "p", ((V)((FdLibm.Cos(a_3191) * 32D))), ((V)(13.4)), ((V)((FdLibm.Sin(a_3191) * 32D))));
f_3181.S("<path d=\"M").V(Call(P2_42, V.Undef, s_3192)).S("Q").V(Call(f1_23, V.Undef, Add(GetIdx(s_3192, 0D), ((V)(((ToNum(GetIdx(e_3193, 0D)) - ToNum(GetIdx(s_3192, 0D))) * 0.9)))))).S(" ").V(Call(f1_23, V.Undef, Add(GetIdx(s_3192, 1D), ((V)((2D * ToNum(u_3180))))))).S(" ").V(Call(P2_42, V.Undef, e_3193)).S("\" fill=\"none\" stroke=\"#e6f6ff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1.2 * ToNum(u_3180)))))).S("\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((3D * ToNum(u_3180)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(u_3180)))))).S("\" opacity=\"0.85\">").V(Call(an_40, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_23, V.Undef, ((V)((10D * ToNum(u_3180)))))).End())), ((V)(0.5)))).S("</path>");
return default;
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(6D)), Fn((V _arrowThis3201, int _argc3194, V i_3200, V _a3197, V _a3198, V _a3199, V[] _rest3195) => {
double a_3202 = 0;
V s_3203 = default;
V e_3204 = default;
a_3202 = (PI_31 * (0.15 + (ToNum(i_3200) * 0.13)));
s_3203 = Invoke(c_3178, "p", ((V)((FdLibm.Cos(a_3202) * 14.6))), ((V)(67D)), ((V)((FdLibm.Sin(a_3202) * 14.6))));
e_3204 = Invoke(c_3178, "p", ((V)((FdLibm.Cos(a_3202) * 24D))), ((V)(44D)), ((V)((FdLibm.Sin(a_3202) * 24D))));
f_3181.S("<path d=\"M").V(Call(P2_42, V.Undef, s_3203)).S("Q").V(Call(f1_23, V.Undef, Add(GetIdx(s_3203, 0D), ((V)(((ToNum(GetIdx(e_3204, 0D)) - ToNum(GetIdx(s_3203, 0D))) * 0.9)))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(s_3203, 1D))).S(" ").V(Call(P2_42, V.Undef, e_3204)).S("\" fill=\"none\" stroke=\"#e6f6ff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1D * ToNum(u_3180)))))).S("\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(u_3180)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(u_3180)))))).S("\" opacity=\"0.85\">").V(Call(an_40, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_23, V.Undef, ((V)((8D * ToNum(u_3180)))))).End())), ((V)(0.45)))).S("</path>");
return default;
}, 1, "", true));
t0_3182 = Invoke(c_3178, "p", ((V)(0D)), ((V)(80D)), ((V)(0D)));
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis3212, int _argc3205, V i_3211, V _a3208, V _a3209, V _a3210, V[] _rest3206) => {
V e_3213 = default;
e_3213 = Invoke(c_3178, "p", ((V)((FdLibm.Cos((ToNum(i_3211) * 1.26)) * 10D))), ((V)(67D)), ((V)((FdLibm.Sin((ToNum(i_3211) * 1.26)) * 10D))));
f_3181.S("<path d=\"M").V(Call(P2_42, V.Undef, t0_3182)).S("Q").V(Call(f1_23, V.Undef, ((V)((ToNum(Add(GetIdx(t0_3182, 0D), GetIdx(e_3213, 0D))) / 2D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(t0_3182, 1D)) - (10D * ToNum(u_3180))))))).S(" ").V(Call(P2_42, V.Undef, e_3213)).S("\" fill=\"none\" stroke=\"#e6f6ff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.9 * ToNum(u_3180)))))).S("\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(u_3180)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(u_3180)))))).S("\">").V(Call(an_40, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_23, V.Undef, ((V)((7D * ToNum(u_3180)))))).End())), ((V)(0.5)))).S("</path>");
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-30D))), ((V)(16D)), ((V)(1D))), Arr(((V)(30D)), ((V)((-14D))), ((V)((-1D)))), Arr(((V)(26D)), ((V)(18D)), ((V)((-1D)))), Arr(((V)((-26D))), ((V)((-16D))), ((V)(1D)))), "forEach", Fn((V _arrowThis3228, int _argc3214, V _a3216, V i_3220, V _a3218, V _a3219, V[] _rest3215) => {
V s_3229 = default;
V e_3230 = default;
V x_3223 = default;
V z_3225 = default;
V d_3227 = default;
{ V _t3221 = ListOf(_a3216);
{ V _t3222 = GetIdx(_t3221, 0D);
x_3223 = _t3222; }
{ V _t3224 = GetIdx(_t3221, 1D);
z_3225 = _t3224; }
{ V _t3226 = GetIdx(_t3221, 2D);
d_3227 = _t3226; }
}
s_3229 = Invoke(c_3178, "p", Add(x_3223, ((V)((ToNum(d_3227) * 3D)))), ((V)(30.6)), z_3225);
e_3230 = Invoke(c_3178, "p", Add(x_3223, ((V)((ToNum(d_3227) * 16D)))), ((V)(13.4)), z_3225);
f_3181.S("<path d=\"M").V(Call(P2_42, V.Undef, s_3229)).S("Q").V(Call(f1_23, V.Undef, Add(GetIdx(s_3229, 0D), ((V)(((ToNum(GetIdx(e_3230, 0D)) - ToNum(GetIdx(s_3229, 0D))) * 0.5)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(s_3229, 1D)) - (6D * ToNum(u_3180))))))).S(" ").V(Call(P2_42, V.Undef, e_3230)).S("\" fill=\"none\" stroke=\"#e6f6ff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.8 * ToNum(u_3180)))))).S("\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(u_3180)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((1.4 * ToNum(u_3180)))))).S("\">").V(Call(an_40, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_23, V.Undef, ((V)((6.8 * ToNum(u_3180)))))).End())), ((V)(0.5)), ((V)(((-ToNum(i_3220)) * 0.1))))).S("</path>");
return default;
}, 2, "", true));
f_3181.S("<g transform=\"").V(Call(planeH_46, V.Undef, Get(c_3178, "p"), ((V)(13.2)))).S("\">").V(Invoke(Call(rep_39, V.Undef, ((V)(4D)), Fn((V _arrowThis3238, int _argc3231, V i_3237, V _a3234, V _a3235, V _a3236, V[] _rest3232) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(GetK(Arr(((V)((-34D))), ((V)(34D)), ((V)(0D)), ((V)(10D))), i_3237)).S("\" cy=\"").V(GetK(Arr(((V)(10D)), ((V)((-6D))), ((V)(30D)), ((V)((-30D)))), i_3237)).S("\" rx=\"2\" ry=\"2\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.7\">").V(Call(an_40, V.Undef, ((V)("rx")), ((V)("2;12")), ((V)(2.2)), ((V)(((-ToNum(i_3237)) * 0.55))))).V(Call(an_40, V.Undef, ((V)("ry")), ((V)("2;12")), ((V)(2.2)), ((V)(((-ToNum(i_3237)) * 0.55))))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.9;0")), ((V)(2.2)), ((V)(((-ToNum(i_3237)) * 0.55))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
f_3181.V(Invoke(Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis3246, int _argc3239, V i_3245, V _a3242, V _a3243, V _a3244, V[] _rest3240) => {
return Call(spark_52, V.Undef, c_3178, GetK(Arr(((V)((-30D))), ((V)(30D)), ((V)(0D))), i_3245), GetK(Arr(((V)(28D)), ((V)(28D)), ((V)(76D))), i_3245), GetK(Arr(((V)(16D)), ((V)((-14D))), ((V)(0D))), i_3245), ((V)(0.6)), ((V)(((-ToNum(i_3245)) * 0.6))), ((V)("#fff1c4")));
}, 1, "", true)), "join", ((V)(""))));
return NewObj(1).Put("front", ((V)(f_3181.Str))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "luxDaybed", Fn((V _arrowThis3254, int _argc3247, V S_3253, V _a3250, V _a3251, V _a3252, V[] _rest3248) => {
return NewObj(6).Put("w", ((V)(132D))).Put("d", ((V)(112D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-24D)))).Put("z", ((V)(8D))).Put("h", ((V)(26D))).V, NewObj(3).Put("x", ((V)(24D))).Put("z", ((V)(8D))).Put("h", ((V)(26D))).V)).Put("build", Fn((V _arrowThis3262, int _argc3255, V P_3261, V _a3258, V _a3259, V _a3260, V[] _rest3256) => {
V o_3263 = default;
double PH_3264 = 0;
V SILK_3265 = default;
double hp_3266 = 0;
o_3263 = Arr();
PH_3264 = 124D;
SILK_3265 = ((V)("#f8f3ea"));
hp_3266 = (PH_3264 - 11.2);
Invoke(o_3263, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(126D)), ((V)(10D)), ((V)(106D)), MARB_78, Call(cer_36, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(127D)), ((V)(1.2)), ((V)(107D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(11.2)), ((V)(0D)), ((V)(106D)), ((V)(12D)), ((V)(84D)), SILK_3265, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(8D))).V)));
Invoke(Arr(Arr(((V)((-58D))), ((V)((-45D)))), Arr(((V)(58D)), ((V)((-45D)))), Arr(((V)((-58D))), ((V)(45D))), Arr(((V)(58D)), ((V)(45D)))), "forEach", Fn((V _arrowThis3278, int _argc3267, V _a3269, V _a3270, V _a3271, V _a3272, V[] _rest3268) => {
V x_3275 = default;
V z_3277 = default;
{ V _t3273 = ListOf(_a3269);
{ V _t3274 = GetIdx(_t3273, 0D);
x_3275 = _t3274; }
{ V _t3276 = GetIdx(_t3273, 1D);
z_3277 = _t3276; }
}
return Invoke(o_3263, "push", Call(cyl_14, V.Undef, x_3275, ((V)(11.2)), z_3277, ((V)(2.4)), ((V)(hp_3266)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.5))), Arr(((V)((hp_3266 * 0.06))), ((V)(0D)), ((V)(1.1))), Arr(((V)((hp_3266 * 0.12))), ((V)(0D)), ((V)(1.5))), Arr(((V)((hp_3266 * 0.16))), ((V)(0D)), ((V)(0.9))), Arr(((V)((hp_3266 * 0.84))), ((V)(0D)), ((V)(0.9))), Arr(((V)((hp_3266 * 0.9))), ((V)(0D)), ((V)(1.4))), Arr(((V)(hp_3266)), ((V)(0D)), ((V)(1D))))).V)));
}, 1, "", true));
Invoke(o_3263, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((-34D))), ((V)(31.2)))).Put("a", ((V)(8D))).Put("b", ((V)(8D))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)((-52D))), ((V)(0D)), ((V)(0.75))), Arr(((V)((-50D))), ((V)(0D)), ((V)(1D))), Arr(((V)(50D)), ((V)(0D)), ((V)(1D))), Arr(((V)(52D)), ((V)(0D)), ((V)(0.75))))).Put("col", ((V)("#1f4f3e"))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(Arr(Arr(((V)((-34D))), ((V)("#e9c66a"))), Arr(((V)((-12D))), IVORY_77), Arr(((V)(12D)), ((V)("#1f4f3e"))), Arr(((V)(34D)), ((V)("#e9c66a")))), "forEach", Fn((V _arrowThis3290, int _argc3279, V _a3281, V _a3282, V _a3283, V _a3284, V[] _rest3280) => {
V x_3287 = default;
V cc_3289 = default;
{ V _t3285 = ListOf(_a3281);
{ V _t3286 = GetIdx(_t3285, 0D);
x_3287 = _t3286; }
{ V _t3288 = GetIdx(_t3285, 1D);
cc_3289 = _t3288; }
}
return Invoke(o_3263, "push", Call(throwP_56, V.Undef, x_3287, ((V)(23.2)), ((V)((-21.5))), ((V)(22D)), cc_3289));
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3298, int _argc3291, V sg_3297, V _a3294, V _a3295, V _a3296, V[] _rest3292) => {
Invoke(o_3263, "push", Call(slabX_17, V.Undef, ((V)(0D)), ((V)(PH_3264)), ((V)((ToNum(sg_3297) * 48D))), ((V)(120D)), ((V)(3D)), ((V)(3D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((ToNum(sg_3297) * 58D))), ((V)(PH_3264)), ((V)(0D)), ((V)(3D)), ((V)(3D)), ((V)(98D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
return default;
}, 1, "", true));
Invoke(o_3263, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("y"))).Put("sh", ((V)("rr"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("a", ((V)(64D))).Put("b", ((V)(54D))).Put("r", ((V)(10D))).Put("rings", Arr(Arr(((V)((PH_3264 + 3D))), ((V)(0D)), ((V)(1D))), Arr(((V)((PH_3264 + 7D))), ((V)(0D)), ((V)(0.92))), Arr(((V)((PH_3264 + 20D))), ((V)(0D)), ((V)(0.42))), Arr(((V)((PH_3264 + 25D))), ((V)(0D)), ((V)(0.12))))).Put("col", SILK_3265).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)((PH_3264 + 24D))), ((V)(0D)), ((V)(4D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("k", ((V)(4D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)((PH_3264 + 31D))), ((V)(0D)), ((V)(0.8)), ((V)(6D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)));
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis3306, int _argc3299, V i_3305, V _a3302, V _a3303, V _a3304, V[] _rest3300) => {
double x_3307 = 0;
x_3307 = ((-48D) + (ToNum(i_3305) * 24D));
Invoke(o_3263, "push", Call(slab_16, V.Undef, ((V)(x_3307)), ((V)((PH_3264 - 8D))), ((V)(54.6)), ((V)(22D)), ((V)(10.8)), ((V)(1D)), SILK_3265, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3315, int _argc3308, V sg_3314, V _a3311, V _a3312, V _a3313, V[] _rest3309) => {
return Call(rep_39, V.Undef, ((V)(4D)), Fn((V _arrowThis3323, int _argc3316, V i_3322, V _a3319, V _a3320, V _a3321, V[] _rest3317) => {
return Invoke(o_3263, "push", Call(slabX_17, V.Undef, ((V)((ToNum(sg_3314) * 64.6))), ((V)((PH_3264 - 8D))), ((V)(((-36D) + (ToNum(i_3322) * 24D)))), ((V)(1D)), ((V)(10.8)), ((V)(22D)), SILK_3265, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-59.5))), ((V)(51.7))), Arr(((V)(59.5)), ((V)(51.7))), Arr(((V)((-59.5))), ((V)((-51.7)))), Arr(((V)(59.5)), ((V)((-51.7))))), "forEach", Fn((V _arrowThis3335, int _argc3324, V _a3326, V _a3327, V _a3328, V _a3329, V[] _rest3325) => {
V C_3336 = default;
V T_3337 = default;
V x_3332 = default;
V z_3334 = default;
{ V _t3330 = ListOf(_a3326);
{ V _t3331 = GetIdx(_t3330, 0D);
x_3332 = _t3331; }
{ V _t3333 = GetIdx(_t3330, 1D);
z_3334 = _t3333; }
}
C_3336 = Call(cyl_14, V.Undef, x_3332, ((V)(11.2)), z_3334, ((V)(5D)), ((V)((PH_3264 - 19.2))), SILK_3265, Call(fb_37, V.Undef, NewObj(4).Put("rz", ((V)(2.2))).Put("n", ((V)(12D))).Put("op", ((V)(0.82))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.3))), Arr(((V)(37D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(47D)), ((V)(0D)), ((V)(0.45))), Arr(((V)(57D)), ((V)(0D)), ((V)(0.8))), Arr(((V)((PH_3264 - 19.2))), ((V)(0D)), ((V)(1.4))))).V));
T_3337 = Call(ball_15, V.Undef, x_3332, ((V)(54.6)), z_3334, ((V)(2.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(3).Put("sy", ((V)(1.5))).Put("sz", ((V)(0.6))).Put("k", ((V)(3D))).V));
Set(T_3337, "par", C_3336);
Invoke(o_3263, "push", C_3336, T_3337);
return default;
}, 1, "", true));
return o_3263;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis3345, int _argc3338, V c_3344, V _a3341, V _a3342, V _a3343, V[] _rest3339) => {
return NewObj(1).Put("front", Invoke(Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis3353, int _argc3346, V i_3352, V _a3349, V _a3350, V _a3351, V[] _rest3347) => {
return Call(spark_52, V.Undef, c_3344, ((V)(((-40D) + (ToNum(i_3352) * 40D)))), ((V)(128D)), ((V)(50D)), ((V)(0.6)), ((V)(((-ToNum(i_3352)) * 0.7))), ((V)("#fff1c4")));
}, 1, "", true)), "join", ((V)("")))).V;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "luxBooth", Fn((V _arrowThis3361, int _argc3354, V S_3360, V _a3357, V _a3358, V _a3359, V[] _rest3355) => {
double R0_3362 = 0;
double Rz_3363 = 0;
double a0_3364 = 0;
double a1_3365 = 0;
double zc_3366 = 0;
double n_3367 = 0;
V segs_3368 = default;
V PL_3369 = default;
V LB1_3370 = default;
V LB2_3371 = default;
R0_3362 = 84D;
Rz_3363 = 62D;
a0_3364 = (PI_31 * 1.04);
a1_3365 = (PI_31 * 1.96);
zc_3366 = 20D;
n_3367 = 4D;
segs_3368 = Call(rep_39, V.Undef, ((V)(n_3367)), Fn((V _arrowThis3379, int _argc3372, V i_3378, V _a3375, V _a3376, V _a3377, V[] _rest3373) => {
return Arr(((V)((a0_3364 + (((a1_3365 - a0_3364) * ToNum(i_3378)) / n_3367)))), ((V)((a0_3364 + (((a1_3365 - a0_3364) * ToNum(Add(i_3378, ((V)(1D))))) / n_3367)))));
}, 1, "", true));
PL_3369 = ((V)("#5a2a5e"));
LB1_3370 = Fn((V _arrowThis3387, int _argc3380, V P_3386, V _a3383, V _a3384, V _a3385, V[] _rest3381) => {
return Arr(Call(arcW_18, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(zc_3366)), ((V)(R0_3362)), ((V)(Rz_3363)), ((V)(46D)), ((V)(3D)), ((V)(a0_3364)), ((V)(a1_3365)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(zc_3366)), ((V)(R0_3362)), ((V)(Rz_3363)), ((V)(12D)), ((V)(62D)), ((V)(a0_3364)), ((V)(a1_3365)), PL_3369, Call(fb_37, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(arcW_18, V.Undef, ((V)(0D)), ((V)(65D)), ((V)(zc_3366)), ((V)((R0_3362 + 0.6))), ((V)((Rz_3363 + 0.6))), ((V)(13.2)), ((V)(2D)), ((V)(a0_3364)), ((V)(a1_3365)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)));
}, 1, "", true);
LB2_3371 = Fn((V _arrowThis3395, int _argc3388, V P_3394, V _a3391, V _a3392, V _a3393, V[] _rest3389) => {
return Call(rep_39, V.Undef, ((V)(12D)), Fn((V _arrowThis3403, int _argc3396, V i_3402, V _a3399, V _a3400, V _a3401, V[] _rest3397) => {
double s0_3404 = 0;
double s1_3405 = 0;
s0_3404 = ((a0_3364 + (((a1_3365 - a0_3364) * ToNum(i_3402)) / 12D)) + 0.008);
s1_3405 = ((a0_3364 + (((a1_3365 - a0_3364) * ToNum(Add(i_3402, ((V)(1D))))) / 12D)) - 0.008);
return Call(arcW_18, V.Undef, ((V)(0D)), ((V)(19D)), ((V)(zc_3366)), ((V)((R0_3362 - 12D))), ((V)((Rz_3363 - 12D))), ((V)(6D)), ((V)(42D)), ((V)(s0_3404)), ((V)(s1_3405)), Call(shade_21, V.Undef, PL_3369, ((V)(1.16))), Call(fb_37, V.Undef, NewObj(1).Put("n", ((V)(2D))).V));
return default;
}, 1, "", true));
}, 1, "", true);
return NewObj(7).Put("w", ((V)(((R0_3362 * 2D) + 8D)))).Put("d", ((V)(((Rz_3363 * 2D) + 10D)))).Put("act", ((V)("sit"))).Put("layers", Arr(NewObj(2).Put("back", ((V)(1D))).Put("build", LB1_3370).V, NewObj(2).Put("back", ((V)(1D))).Put("build", LB2_3371).V)).Put("seats", Invoke(segs_3368, "map", Fn((V _arrowThis3413, int _argc3406, V s_3412, V _a3409, V _a3410, V _a3411, V[] _rest3407) => {
double m_3414 = 0;
m_3414 = (ToNum(Add(GetIdx(s_3412, 0D), GetIdx(s_3412, 1D))) / 2D);
return NewObj(3).Put("x", ((V)((FdLibm.Cos(m_3414) * 50D)))).Put("z", ((V)((zc_3366 + (FdLibm.Sin(m_3414) * 37D))))).Put("h", ((V)(28D))).V;
return default;
}, 1, "", true))).Put("build", Fn((V _arrowThis3422, int _argc3415, V P_3421, V _a3418, V _a3419, V _a3420, V[] _rest3416) => {
V o_3423 = default;
V TT_3424 = default;
V RIM_3425 = default;
V coupe_3426 = default;
V BK_3427 = default;
o_3423 = Arr();
Invoke(o_3423, "push", Call(arcW_18, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(zc_3366)), ((V)((R0_3362 - 12D))), ((V)((Rz_3363 - 12D))), ((V)(34D)), ((V)(16D)), ((V)(a0_3364)), ((V)(a1_3365)), Call(shade_21, V.Undef, PL_3369, ((V)(0.85))), Call(fb_37, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)));
Invoke(segs_3368, "forEach", Fn((V _arrowThis3439, int _argc3428, V _a3430, V _a3431, V _a3432, V _a3433, V[] _rest3429) => {
V s0_3436 = default;
V s1_3438 = default;
{ V _t3434 = ListOf(_a3430);
{ V _t3435 = GetIdx(_t3434, 0D);
s0_3436 = _t3435; }
{ V _t3437 = GetIdx(_t3434, 1D);
s1_3438 = _t3437; }
}
return Invoke(o_3423, "push", Call(arcW_18, V.Undef, ((V)(0D)), ((V)(19D)), ((V)(zc_3366)), ((V)((R0_3362 - 18D))), ((V)((Rz_3363 - 18D))), ((V)(28D)), ((V)(8D)), Add(s0_3436, ((V)(0.01))), ((V)((ToNum(s1_3438) - 0.01))), Call(shade_21, V.Undef, PL_3369, ((V)(1.1))), Call(fb_37, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)));
}, 1, "", true));
TT_3424 = Call(cyl_14, V.Undef, ((V)(0D)), ((V)(28D)), ((V)((zc_3366 + 8D))), ((V)(24D)), ((V)(3D)), ((V)("#1a181e")), Call(cer_36, V.Undef, NewObj(1).Put("n", ((V)(26D))).V));
RIM_3425 = Call(arcW_18, V.Undef, ((V)(0D)), ((V)(28D)), ((V)((zc_3366 + 8D))), ((V)(24.6)), ((V)(24.6)), ((V)(1.2)), ((V)(3D)), ((V)(0D)), ((V)((2D * PI_31))), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(26D))).V));
Set(RIM_3425, "par", TT_3424);
Invoke(o_3423, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((zc_3366 + 8D))), ((V)(12D)), ((V)(2D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((zc_3366 + 8D))), ((V)(3D)), ((V)(26D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), TT_3424, RIM_3425);
coupe_3426 = Fn((V _arrowThis3449, int _argc3440, V x_3446, V y_3447, V z_3448, V _a3445, V[] _rest3441) => {
Invoke(o_3423, "push", Call(cyl_14, V.Undef, x_3446, y_3447, z_3448, ((V)(1.6)), ((V)(0.6)), GL_30, Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("op", ((V)(0.6))).V)), Call(cyl_14, V.Undef, x_3446, Add(y_3447, ((V)(0.6))), z_3448, ((V)(0.4)), ((V)(3D)), GL_30, Call(cer_36, V.Undef, NewObj(2).Put("n", ((V)(4D))).Put("op", ((V)(0.6))).V)), Call(cyl_14, V.Undef, x_3446, Add(y_3447, ((V)(3.6))), z_3448, ((V)(3.4)), ((V)(2.2)), ((V)("#f2d27a")), NewObj(3).Put("n", ((V)(12D))).Put("op", ((V)(0.7))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.3))), Arr(((V)(2.2)), ((V)(0D)), ((V)(1D))))).V));
return default;
}, 3, "", true);
Call(rep_39, V.Undef, ((V)(6D)), Fn((V _arrowThis3457, int _argc3450, V i_3456, V _a3453, V _a3454, V _a3455, V[] _rest3451) => {
double a_3458 = 0;
a_3458 = (((ToNum(i_3456) / 6D) * 2D) * PI_31);
Call(coupe_3426, V.Undef, ((V)((FdLibm.Cos(a_3458) * 9D))), ((V)(31D)), ((V)(((zc_3366 + 8D) + (FdLibm.Sin(a_3458) * 9D)))));
return default;
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis3466, int _argc3459, V i_3465, V _a3462, V _a3463, V _a3464, V[] _rest3460) => {
double a_3467 = 0;
a_3467 = ((((ToNum(i_3465) / 3D) * 2D) * PI_31) + 0.5);
Call(coupe_3426, V.Undef, ((V)((FdLibm.Cos(a_3467) * 5.2))), ((V)(36.8)), ((V)(((zc_3366 + 8D) + (FdLibm.Sin(a_3467) * 5.2)))));
return default;
}, 1, "", true));
Call(coupe_3426, V.Undef, ((V)(0D)), ((V)(42.6)), ((V)((zc_3366 + 8D))));
BK_3427 = Call(cyl_14, V.Undef, ((V)(16D)), ((V)(31D)), ((V)((zc_3366 - 2D))), ((V)(5D)), ((V)(9D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V));
Invoke(o_3423, "push", BK_3427, Call(cyl_14, V.Undef, ((V)(16D)), ((V)(40D)), ((V)((zc_3366 - 2D))), ((V)(2.4)), ((V)(7.4)), ((V)("#1f3a2a")), NewObj(1).Put("n", ((V)(10D))).V), Call(cyl_14, V.Undef, ((V)(16D)), ((V)(47.4)), ((V)((zc_3366 - 2D))), ((V)(1D)), ((V)(5D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis3475, int _argc3468, V i_3474, V _a3471, V _a3472, V _a3473, V[] _rest3469) => {
V c_3476 = default;
c_3476 = Call(ball_15, V.Undef, ((V)((13.4 + ((ToNum(i_3474) % 3D) * 2.6)))), ((V)(39.4)), ((V)(((zc_3366 - 4D) + ((ToNum(i_3474) % 2D) * 4D)))), ((V)(1.4)), ((V)("#e8f6ff")), Call(cer_36, V.Undef, NewObj(3).Put("k", ((V)(2D))).Put("n", ((V)(6D))).Put("op", ((V)(0.8))).V));
Set(c_3476, "par", BK_3427);
Set(c_3476, "fn", Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Invoke(o_3423, "push", c_3476);
return default;
}, 1, "", true));
return o_3423;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis3484, int _argc3477, V c_3483, V _a3480, V _a3481, V _a3482, V[] _rest3478) => {
JsStrBuf f_3485 = null;
JsStrBuf under_3486 = null;
f_3485 = new JsStrBuf("");
under_3486 = new JsStrBuf("");
Call(rep_39, V.Undef, ((V)(9D)), Fn((V _arrowThis3494, int _argc3487, V i_3493, V _a3490, V _a3491, V _a3492, V[] _rest3488) => {
V a_3495 = default;
V d_3496 = default;
a_3495 = Invoke(c_3483, "p", ((V)((((ToNum(i_3493) % 3D) - 1D) * 4D))), ((V)((34D + (System.Math.Floor((ToNum(i_3493) / 3D)) * 5D)))), ((V)(((zc_3366 + 8D) + (NumTruthy((ToNum(i_3493) % 2D)) ? 2D : (-2D))))));
d_3496 = Invoke(((V)((1.4 + ((ToNum(i_3493) % 3D) * 0.3)))), "toFixed", ((V)(1D)));
f_3485.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(a_3495, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(a_3495, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.5 * ToNum(Get(c_3483, "k"))))))).S("\" fill=\"#fffbe0\">").V(Call(an_40, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(a_3495, 1D))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(a_3495, 1D)) - (8D * ToNum(Get(c_3483, "k")))))))).End())), d_3496, ((V)(((-ToNum(i_3493)) * 0.21))))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0;1;0")), d_3496, ((V)(((-ToNum(i_3493)) * 0.21))))).S("</circle>");
return default;
}, 1, "", true));
f_3485.V(Invoke(Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis3504, int _argc3497, V i_3503, V _a3500, V _a3501, V _a3502, V[] _rest3498) => {
return Call(spark_52, V.Undef, c_3483, ((V)(((ToNum(i_3503) - 1D) * 6D))), ((V)(46D)), ((V)((zc_3366 + 8D))), ((V)(0.7)), ((V)(((-ToNum(i_3503)) * 0.5))), ((V)("#fff1c4")));
}, 1, "", true)), "join", ((V)(""))));
under_3486.Set(JsStrBuf.Begin().S("<g transform=\"").V(Call(planeH_46, V.Undef, Get(c_3483, "p"), ((V)(0.3)))).S(" translate(0 ").N(zc_3366).S(")\"><ellipse rx=\"").N((R0_3362 + 8D)).S("\" ry=\"").N((Rz_3363 + 8D)).S("\" fill=\"#b48cff\" opacity=\"0.25\">").V(Call(an_40, V.Undef, ((V)("fill")), ((V)("#b48cff;#ff6ad5;#6ac8ff;#b48cff")), ((V)(4D)))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.15;0.35;0.15")), ((V)(1.4)))).S("</ellipse></g>").End());
return NewObj(2).Put("under", ((V)(under_3486.Str))).Put("front", ((V)(f_3485.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "luxDJ", Fn((V _arrowThis3512, int _argc3505, V S_3511, V _a3508, V _a3509, V _a3510, V[] _rest3506) => {
return NewObj(5).Put("w", ((V)(160D))).Put("d", ((V)(96D))).Put("pad", Arr(((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(0D)))).Put("build", Fn((V _arrowThis3520, int _argc3513, V P_3519, V _a3516, V _a3517, V _a3518, V[] _rest3514) => {
V o_3521 = default;
V BK_3522 = default;
o_3521 = Arr();
BK_3522 = ((V)("#16161b"));
Invoke(o_3521, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(156D)), ((V)(10D)), ((V)(90D)), BK_3522, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(9.4)), ((V)(0D)), ((V)(157D)), ((V)(1.2)), ((V)(91D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Invoke(o_3521, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(10.6)), ((V)(14D)), ((V)(132D)), ((V)(46D)), ((V)(30D)), ((V)("#1d1d22")), Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Call(rep_39, V.Undef, ((V)(5D)), Fn((V _arrowThis3530, int _argc3523, V j_3529, V _a3526, V _a3527, V _a3528, V[] _rest3524) => {
return Call(rep_39, V.Undef, ((V)(14D)), Fn((V _arrowThis3538, int _argc3531, V i_3537, V _a3534, V _a3535, V _a3536, V[] _rest3532) => {
return Invoke(o_3521, "push", Call(slab_16, V.Undef, ((V)(((-61D) + (ToNum(i_3537) * 9.4)))), ((V)((13D + (ToNum(j_3529) * 8.6)))), ((V)(29.4)), ((V)(8.6)), ((V)(7.8)), ((V)(0.6)), ((V)((NumTruthy((ToNum(Add(i_3537, j_3529)) % 3D)) ? "#cfd6e0" : "#e8eef4"))), Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(o_3521, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(56.6)), ((V)(14D)), ((V)(138D)), ((V)(3D)), ((V)(34D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(Arr(((V)((-40D))), ((V)(40D))), "forEach", Fn((V _arrowThis3546, int _argc3539, V x_3545, V _a3542, V _a3543, V _a3544, V[] _rest3540) => {
Invoke(o_3521, "push", Call(box_12, V.Undef, x_3545, ((V)(59.6)), ((V)(14D)), ((V)(34D)), ((V)(4D)), ((V)(28D)), ((V)("#2c2d31")), Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(cyl_14, V.Undef, ((V)((ToNum(x_3545) - 2D))), ((V)(63.6)), ((V)(15D)), ((V)(11D)), ((V)(1.2)), ((V)("#111114")), NewObj(1).Put("n", ((V)(22D))).V), Call(cyl_14, V.Undef, ((V)((ToNum(x_3545) - 2D))), ((V)(64.8)), ((V)(15D)), ((V)(3D)), ((V)(0.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(box_12, V.Undef, Add(x_3545, ((V)(12D))), ((V)(63.6)), ((V)(6D)), ((V)(1.4)), ((V)(1.4)), ((V)(14D)), CH_28, Call(mt_34, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("yaw", ((V)(0.4))).V)));
return default;
}, 1, "", true));
Invoke(o_3521, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(59.6)), ((V)(14D)), ((V)(26D)), ((V)(5D)), ((V)(24D)), ((V)("#2c2d31")), Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Call(rep_39, V.Undef, ((V)(12D)), Fn((V _arrowThis3554, int _argc3547, V i_3553, V _a3550, V _a3551, V _a3552, V[] _rest3548) => {
return Invoke(o_3521, "push", Call(ball_15, V.Undef, ((V)(((-8D) + ((ToNum(i_3553) % 4D) * 5.4)))), ((V)(64.6)), ((V)((5D + (System.Math.Floor((ToNum(i_3553) / 4D)) * 5D)))), ((V)(1.1)), (((ToNum(i_3553) % 4D) == 3D) ? ((V)("#ff6ad5")) : CH_28), Call(mt_34, V.Undef, NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(2D))).Put("n", ((V)(6D))).V)));
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis3562, int _argc3555, V i_3561, V _a3558, V _a3559, V _a3560, V[] _rest3556) => {
return Invoke(o_3521, "push", Call(box_12, V.Undef, ((V)(((-6D) + (ToNum(i_3561) * 6D)))), ((V)(64.6)), ((V)(20D)), ((V)(1.6)), ((V)(1D)), ((V)(6D)), ((V)("#9aa3a8")), Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
}, 1, "", true));
Invoke(o_3521, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(10.6)), ((V)((-24D))), ((V)(36D)), ((V)(22D)), ((V)(30D)), VEL_75, Call(fb_37, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)), Call(slab_16, V.Undef, ((V)(0D)), ((V)(32.6)), ((V)((-36D))), ((V)(38D)), ((V)(64D)), ((V)(8D)), VEL_75, Call(fb_37, V.Undef, NewObj(2).Put("r", ((V)(16D))).Put("rb", ((V)(0D))).V)));
Call(tuftGrid_81, V.Undef, o_3521, ((V)((-14D))), ((V)(14D)), ((V)(40D)), ((V)(90D)), ((V)((-31.6))), ((V)(4D)), ((V)(4D)), VEL_75, GOLD_27);
Invoke(o_3521, "push", Call(solid_11, V.Undef, NewObj(12).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)(80D)))).Put("a", ((V)(21D))).Put("b", ((V)(18D))).Put("th", ((V)(2.4))).Put("a0", ((V)(0.15))).Put("a1", ((V)((PI_31 - 0.15)))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((-40.4))), ((V)(0D))), Arr(((V)((-31.6))), ((V)(0D))))).Put("col", GOLD_27).Put("mat", ((V)("metal"))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)(99D)), ((V)((-36D))), ((V)(3.6)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("k", ((V)(4D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3570, int _argc3563, V s_3569, V _a3566, V _a3567, V _a3568, V[] _rest3564) => {
return Invoke(o_3521, "push", Call(box_12, V.Undef, ((V)((ToNum(s_3569) * 20D))), ((V)(10.6)), ((V)((-24D))), ((V)(4D)), ((V)(30D)), ((V)(30D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-72D))), ((V)(72D))), "forEach", Fn((V _arrowThis3578, int _argc3571, V x_3577, V _a3574, V _a3575, V _a3576, V[] _rest3572) => {
return Invoke(o_3521, "push", Call(cyl_14, V.Undef, x_3577, ((V)(10.6)), ((V)((-36D))), ((V)(2.4)), ((V)(128D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(ball_15, V.Undef, x_3577, ((V)(138D)), ((V)((-36D))), ((V)(3.4)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("k", ((V)(4D))).V)));
}, 1, "", true));
Invoke(o_3521, "push", Call(slabX_17, V.Undef, ((V)(0D)), ((V)(136D)), ((V)((-36D))), ((V)(148D)), ((V)(3D)), ((V)(3D)), GOLD_27, Call(mt_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(118D)), ((V)((-36D))), ((V)(0.5)), ((V)(18D)), ((V)("#9aa3a8")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_15, V.Undef, ((V)(0D)), ((V)(94D)), ((V)((-36D))), ((V)(12D)), ((V)("#cfd6e0")), Call(mt_34, V.Undef, NewObj(2).Put("k", ((V)(8D))).Put("n", ((V)(18D))).V)));
Invoke(o_3521, "push", Call(ball_15, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(30.6)), ((V)(6D)), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("sz", ((V)(0.3))).Put("k", ((V)(4D))).V)));
Call(rep_39, V.Undef, ((V)(3D)), Fn((V _arrowThis3586, int _argc3579, V i_3585, V _a3582, V _a3583, V _a3584, V[] _rest3580) => {
return Invoke(o_3521, "push", Call(cyl_14, V.Undef, ((V)(((-6D) + (ToNum(i_3585) * 6D)))), ((V)(40D)), ((V)(30.6)), ((V)(1.4)), ((V)((7D + ((ToNum(i_3585) % 2D) * 3D)))), GOLD_27, Call(mt_34, V.Undef, NewObj(2).Put("n", ((V)(6D))).Put("top", ((V)(0.9))).V)));
}, 1, "", true));
return o_3521;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis3594, int _argc3587, V c_3593, V _a3590, V _a3591, V _a3592, V[] _rest3588) => {
V u_3595 = default;
JsStrBuf f_3596 = null;
JsStrBuf under_3597 = null;
V bc_3598 = default;
V e0_3599 = default;
V e1_3600 = default;
u_3595 = Get(c_3593, "k");
f_3596 = new JsStrBuf("");
under_3597 = new JsStrBuf("");
Invoke(Arr(((V)((-42D))), ((V)(38D))), "forEach", Fn((V _arrowThis3609, int _argc3601, V x_3607, V i_3608, V _a3605, V _a3606, V[] _rest3602) => {
f_3596.S("<g transform=\"").V(Call(planeH_46, V.Undef, Get(c_3593, "p"), ((V)(65D)))).S(" translate(").V(x_3607).S(" 15)\"><g>").V(Call(at_41, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(1.8)))).S("<path d=\"M0 -10A10 10 0 0 1 10 0\" fill=\"none\" stroke=\"#9aa3a8\" stroke-width=\"0.8\"/><path d=\"M0 7A7 7 0 0 1 -7 0\" fill=\"none\" stroke=\"#6b6f7a\" stroke-width=\"0.6\"/><rect x=\"-0.6\" y=\"-10\" width=\"1.2\" height=\"3\" fill=\"").V(GOLD_27).S("\"/></g></g>");
return default;
}, 2, "", true));
bc_3598 = Invoke(c_3593, "p", ((V)(0D)), ((V)(106D)), ((V)((-36D))));
Call(rep_39, V.Undef, ((V)(6D)), Fn((V _arrowThis3617, int _argc3610, V i_3616, V _a3613, V _a3614, V _a3615, V[] _rest3611) => {
f_3596.S("<g transform=\"translate(").V(Call(P2_42, V.Undef, bc_3598)).S(")\"><g>").V(Call(at_41, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().N(((-40D) + (ToNum(i_3616) * 16D))).S(";").N((40D - (ToNum(i_3616) * 16D))).S(";").N(((-40D) + (ToNum(i_3616) * 16D))).End())), ((V)((3D + (ToNum(i_3616) * 0.35)))))).S("<path d=\"M0 0L").V(Call(f1_23, V.Undef, ((V)(((-6D) * ToNum(u_3595)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((130D * ToNum(u_3595)))))).S("L").V(Call(f1_23, V.Undef, ((V)((6D * ToNum(u_3595)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((130D * ToNum(u_3595)))))).S("Z\" fill=\"").V(GetIdx(NE_26, (ToNum(i_3616) % 6D))).S("\" opacity=\"0.16\">").V(Call(an_40, V.Undef, ((V)("fill")), NEV_53, ((V)(4D)), ((V)(((-ToNum(i_3616)) * 0.6))))).S("</path></g></g>");
return default;
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(8D)), Fn((V _arrowThis3625, int _argc3618, V i_3624, V _a3621, V _a3622, V _a3623, V[] _rest3619) => {
double a_3626 = 0;
V q_3627 = default;
a_3626 = (((ToNum(i_3624) / 8D) * 2D) * PI_31);
q_3627 = Invoke(c_3593, "p", ((V)((FdLibm.Cos(a_3626) * 9D))), ((V)((106D + (FdLibm.Sin(a_3626) * 9D)))), ((V)(((-36D) + 10D))));
f_3596.S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_3627, 0D)) - (1.2 * ToNum(u_3595))))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_3627, 1D)) - (1.2 * ToNum(u_3595))))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(u_3595)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(u_3595)))))).S("\" fill=\"#ffffff\" opacity=\"0\">").V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0;1;0;0")), ((V)(1.6)), ((V)(((-ToNum(i_3624)) * 0.2))))).S("</rect>");
return default;
}, 1, "", true));
Call(rep_39, V.Undef, ((V)(10D)), Fn((V _arrowThis3635, int _argc3628, V i_3634, V _a3631, V _a3632, V _a3633, V[] _rest3629) => {
return ((V)(f_3596.V(Call(spark_52, V.Undef, c_3593, ((V)(((-60D) + ((ToNum(i_3634) % 5D) * 30D)))), ((V)((18D + (System.Math.Floor((ToNum(i_3634) / 5D)) * 22D)))), ((V)(30.2)), ((V)(0.55)), ((V)(((-ToNum(i_3634)) * 0.29))), ((V)("#ffffff")), ((V)(1.4)))).Str));
}, 1, "", true));
e0_3599 = Invoke(c_3593, "p", ((V)((-78D))), ((V)(10.4)), ((V)(45.6)));
e1_3600 = Invoke(c_3593, "p", ((V)(78D)), ((V)(10.4)), ((V)(45.6)));
f_3596.S("<path d=\"M").V(Call(P2_42, V.Undef, e0_3599)).S("L").V(Call(P2_42, V.Undef, e1_3600)).S("\" stroke=\"#ff6ad5\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(u_3595)))))).S("\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((4D * ToNum(u_3595)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((3D * ToNum(u_3595)))))).S("\" filter=\"url(#gw2)\">").V(Call(an_40, V.Undef, ((V)("stroke")), NEV_53, ((V)(3D)))).V(Call(an_40, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_23, V.Undef, ((V)((14D * ToNum(u_3595)))))).End())), ((V)(0.8)))).S("</path>");
under_3597.Set(JsStrBuf.Begin().S("<g transform=\"").V(Call(planeH_46, V.Undef, Get(c_3593, "p"), ((V)(0.3)))).S("\"><ellipse rx=\"96\" ry=\"66\" fill=\"#8f7bff\" opacity=\"0.25\">").V(Call(an_40, V.Undef, ((V)("fill")), NEV_53, ((V)(4D)))).V(Call(an_40, V.Undef, ((V)("opacity")), ((V)("0.12;0.32;0.12")), ((V)(0.9)))).S("</ellipse></g>").End());
return NewObj(3).Put("defs", GLOW_48).Put("under", ((V)(under_3597.Str))).Put("front", ((V)(f_3596.Str))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
LED_DEFS_82 = ((V)("<filter id=\"lgb\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"1.4\"/></filter><filter id=\"lgp\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"5\"/></filter>"));
Set(RD_8, "H2LED", ledFloor_83);
draw0_85 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis3644, int _argc3636, V r_3642, V o_3643, V _a3640, V _a3641, V[] _rest3637) => {
V res_3645 = default;
res_3645 = Call(draw0_85, V.Undef, r_3642, o_3643);
if (Truthy(((!(Truthy(res_3645)) ? V.True : V.False) is var _t3646 && Truthy(_t3646) ? _t3646 : Get(res_3645, "_p2")))) {
return res_3645;
}
Set(res_3645, "_p2", ((V)(1D)));
try {
if (Truthy(((((SEqS(Get(r_3642, "room"), "CLB") ? V.True : V.False) is var _t3647 && !Truthy(_t3647) ? _t3647 : Get(res_3645, "surf")) is var _t3648 && !Truthy(_t3648) ? _t3648 : Get(res_3645, "svg")) is var _t3649 && !Truthy(_t3649) ? _t3649 : ((SEqS(Get(res_3645, "kind"), "floor") || SEqS(Get(res_3645, "kind"), "wall")) ? V.True : V.False)))) {
V add_3650 = default;
add_3650 = (SEqS(Get(res_3645, "kind"), "floor") ? Call(ledFloor_83, V.Undef, Get(r_3642, "tier")) : Call(ledWall_84, V.Undef, Get(r_3642, "tier")));
Set(res_3645, "svg", Invoke(Get(res_3645, "svg"), "replace", NewRegExp(RX12, "<\\/svg>\\s*$", ""), ((V)(JsStrBuf.Begin().V(add_3650).S("</svg>").End()))));
Set(res_3645, "src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Get(res_3645, "svg"))).End())));
Set(res_3645, "led", ((V)(1D)));
} else {
if (!(Truthy(Get(res_3645, "surf")))) {
V D_3651 = default;
D_3651 = GetK(Get(X_9, "CAT"), ((V)(JsStrBuf.Begin().S("rv_").V(Get(r_3642, "id")).S("_").V(Get(r_3642, "tier")).S("_").N(((double)(ToInt32(ToNum((o_3643 is var _t3652 && !Truthy(_t3652) ? _t3652 : Get(o_3643, "ci")))) | ToInt32(0D)))).S("_").V(((o_3643 is var _t3653 && !Truthy(_t3653) ? _t3653 : Get(o_3643, "st")) is var _t3654 && Truthy(_t3654) ? _t3654 : ((V)("")))).End())));
if (Truthy(((D_3651 is var _t3655 && !Truthy(_t3655) ? _t3655 : Get(D_3651, "flat")) is var _t3657 && Truthy(_t3657) ? _t3657 : Invoke(NewRegExp(RX13, "^(rug2|rug|mat)$", ""), "test", GetIdx(Invoke((Get(res_3645, "arch") is var _t3656 && Truthy(_t3656) ? _t3656 : ((V)(""))), "split", ((V)("."))), 0D))))) {
Set(res_3645, "flat", (true ? V.True : V.False));
}
}
}
} catch (System.Exception _ex3658) {
V e_3659 = default;
e_3659 = Caught(_ex3658);
Invoke(G("console"), "warn", ((V)("reno plus2")), Get(r_3642, "id"), e_3659);
}
return res_3645;
return default;
}, 2, "", true));
SET2_86 = NewObj(9).Put("MOV-011", NewObj(1).Put("spec", ((V)("microPop"))).V).Put("MOV-031", NewObj(2).Put("spec", ((V)("popper"))).Put("live", ((V)("Pops live"))).V).Put("MOV-051", NewObj(2).Put("spec", ((V)("popCart"))).Put("live", ((V)("Pops live"))).V).Put("MOV-071", NewObj(3).Put("spec", ((V)("popCart"))).Put("sx", NewObj(1).Put("conc", ((V)(1D))).V).Put("live", ((V)("Pops live"))).V).Put("MOV-091", NewObj(2).Put("spec", ((V)("candyBar"))).Put("live", ((V)("Live dispenser"))).V).Put("MOV-028", NewObj(1).Put("spec", ((V)("popBucket"))).V).Put("MOV-008", NewObj(1).Put("spec", ((V)("candyBox"))).V).Put("KIT-008", NewObj(1).Put("spec", ((V)("cereal"))).V).Put("LIV-091", NewObj(3).Put("spec", ((V)("holoStage"))).Put("live", ((V)("Live hologram"))).Put("note", ((V)("A dancing hologram on a glowing emitter, inside a ring of walnut acoustic fins that pulse with the music. Loops forever."))).V).V;
ROYAL_87 = NewObj(5).Put("cost", ((V)(0D))).Put("lv", ((V)(30D))).Put("rarity", ((V)("Legendary"))).Put("live", ((V)("Royal Collection"))).Put("note", ((V)("Royal Collection: the most expensive piece in this room."))).V;
ADD2_88 = Arr(Arr(((V)("LIV")), ((V)(111D)), ((V)(11D)), ((V)(11D)), ((V)("Center Table")), ((V)("Gilded Rococo Marble Coffee Table with Crystal Decanters")), ((V)("luxCoffee")), ((V)(62000D))), Arr(((V)("KIT")), ((V)(108D)), ((V)(13D)), ((V)(23D)), ((V)("Patisserie Display")), ((V)("Royal Patisserie Display Case with Cakes, Macarons & Croissants")), ((V)("luxPatis")), ((V)(70000D))), Arr(((V)("MOV")), ((V)(101D)), ((V)(10D)), ((V)(10D)), ((V)("Primary Sofa / Row")), ((V)("Royal Velvet Cinema Recliner Row with Gold Cup Holders")), ((V)("luxRecliner")), ((V)(72000D))), Arr(((V)("MOV")), ((V)(102D)), ((V)(15D)), ((V)(15D)), ((V)("Snack Station")), ((V)("Gilded Grand Cinema Popcorn Carriage")), ((V)("popCart")), ((V)(64000D)), NewObj(1).Put("sx", NewObj(1).Put("royal", ((V)(1D))).V).V), Arr(((V)("BTH")), ((V)(101D)), ((V)(5D)), ((V)(5D)), ((V)("Primary Tub")), ((V)("Royal Burgundy & 24K Gold Clawfoot Soaking Tub")), ((V)("luxTub")), ((V)(74000D))), Arr(((V)("BTH")), ((V)(102D)), ((V)(8D)), ((V)(8D)), ((V)("Washbasin")), ((V)("Black Onyx & Gold Double Vanity with Round Mirrors")), ((V)("luxVanity")), ((V)(62000D))), Arr(((V)("BED")), ((V)(101D)), ((V)(5D)), ((V)(5D)), ((V)("Primary Bed")), ((V)("Royal Gold Four-Poster Canopy Bed with Velvet Drapes")), ((V)("luxBed")), ((V)(75000D))), Arr(((V)("BED")), ((V)(102D)), ((V)(11D)), ((V)(11D)), ((V)("Drawer Chest")), ((V)("Mirrored Gold Vanity Dresser with Crystal Knobs")), ((V)("luxDresser")), ((V)(62000D))), Arr(((V)("YRD")), ((V)(106D)), ((V)(5D)), ((V)(5D)), ((V)("Aquatic Centerpiece")), ((V)("Carrara Marble Tiered Fountain with Gold Swans")), ((V)("luxFountain")), ((V)(70000D))), Arr(((V)("YRD")), ((V)(107D)), ((V)(8D)), ((V)(8D)), ((V)("Primary Outdoor Seating")), ((V)("Gilded Garden Gazebo Daybed with Silk Drapes")), ((V)("luxDaybed")), ((V)(64000D))), Arr(((V)("CLB")), ((V)(111D)), ((V)(11D)), ((V)(11D)), ((V)("VIP Lounge Sofa")), ((V)("Royal VIP Velvet Booth with Gold Champagne Tower")), ((V)("luxBooth")), ((V)(75000D))), Arr(((V)("CLB")), ((V)(112D)), ((V)(5D)), ((V)(5D)), ((V)("DJ Console")), ((V)("Gold Mirror-Ball DJ Throne Booth")), ((V)("luxDJ")), ((V)(68000D))));
BUMP_89 = NewObj(2).Put("LIV-110", ((V)(68000D))).Put("KIT-104", ((V)(66000D))).V;
edit1_90 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis3667, int _argc3660, V rows_3666, V _a3663, V _a3664, V _a3665, V[] _rest3661) => {
V R_3668 = default;
V bon_3669 = default;
R_3668 = Invoke(Call(edit1_90, V.Undef, rows_3666), "map", Fn((V _arrowThis3677, int _argc3670, V r_3676, V _a3673, V _a3674, V _a3675, V[] _rest3671) => {
return (Truthy(GetK(SET2_86, Get(r_3676, "id"))) ? Object_assign(NewObj(0).V, r_3676, GetK(SET2_86, Get(r_3676, "id"))) : r_3676);
}, 1, "", true));
bon_3669 = Fn((V _arrowThis3685, int _argc3678, V r_3684, V _a3681, V _a3682, V _a3683, V[] _rest3679) => {
return ((V)(JsStrBuf.Begin().S("+45 ").V(Get(r_3684, "stat")).End()));
}, 1, "", true);
R_3668 = Invoke(R_3668, "map", Fn((V _arrowThis3693, int _argc3686, V r_3692, V _a3689, V _a3690, V _a3691, V[] _rest3687) => {
return (Truthy(GetK(BUMP_89, Get(r_3692, "id"))) ? Object_assign(NewObj(0).V, r_3692, ROYAL_87, NewObj(2).Put("cost", GetK(BUMP_89, Get(r_3692, "id"))).Put("bonus", Call(bon_3669, V.Undef, r_3692)).V) : r_3692);
}, 1, "", true));
Invoke(ADD2_88, "forEach", Fn((V _arrowThis3719, int _argc3694, V _a3696, V _a3697, V _a3698, V _a3699, V[] _rest3695) => {
V same_3720 = default;
V b_3721 = default;
V room_3702 = default;
V num_3704 = default;
V bs_3706 = default;
V slot_3708 = default;
V slotName_3710 = default;
V name_3712 = default;
V spec_3714 = default;
V cost_3716 = default;
V ex_3718 = default;
{ V _t3700 = ListOf(_a3696);
{ V _t3701 = GetIdx(_t3700, 0D);
room_3702 = _t3701; }
{ V _t3703 = GetIdx(_t3700, 1D);
num_3704 = _t3703; }
{ V _t3705 = GetIdx(_t3700, 2D);
bs_3706 = _t3705; }
{ V _t3707 = GetIdx(_t3700, 3D);
slot_3708 = _t3707; }
{ V _t3709 = GetIdx(_t3700, 4D);
slotName_3710 = _t3709; }
{ V _t3711 = GetIdx(_t3700, 5D);
name_3712 = _t3711; }
{ V _t3713 = GetIdx(_t3700, 6D);
spec_3714 = _t3713; }
{ V _t3715 = GetIdx(_t3700, 7D);
cost_3716 = _t3715; }
{ V _t3717 = GetIdx(_t3700, 8D);
ex_3718 = _t3717; }
}
same_3720 = Invoke(rows_3666, "filter", Fn((V _arrowThis3729, int _argc3722, V r_3728, V _a3725, V _a3726, V _a3727, V[] _rest3723) => {
return (SEq(Get(r_3728, "room"), room_3702) ? V.True : V.False);
}, 1, "", true));
b_3721 = (Invoke(same_3720, "find", Fn((V _arrowThis3737, int _argc3730, V r_3736, V _a3733, V _a3734, V _a3735, V[] _rest3731) => {
return ((SEqN(Get(r_3736, "tier"), 5D) && SEq(Get(r_3736, "slot"), bs_3706)) ? V.True : V.False);
}, 1, "", true)) is var _t3746 && Truthy(_t3746) ? _t3746 : Invoke(same_3720, "find", Fn((V _arrowThis3745, int _argc3738, V r_3744, V _a3741, V _a3742, V _a3743, V[] _rest3739) => {
return (SEqN(Get(r_3744, "tier"), 5D) ? V.True : V.False);
}, 1, "", true)));
if (Truthy(b_3721)) {
Invoke(R_3668, "push", Object_assign(NewObj(0).V, b_3721, ROYAL_87, NewObj(8).Put("id", ((V)(JsStrBuf.Begin().V(room_3702).S("-").V(num_3704).End()))).Put("slot", slot_3708).Put("slotName", slotName_3710).Put("name", name_3712).Put("spec", spec_3714).Put("cost", cost_3716).Put("bonus", Call(bon_3669, V.Undef, b_3721)).Put("add", ((V)(1D))).V, (ex_3718 is var _t3747 && Truthy(_t3747) ? _t3747 : NewObj(0).V)));
}
return default;
}, 1, "", true));
return R_3668;
return default;
}, 1, "", true));
FOOD2_91 = Arr(((V)("fFruitBowl")), ((V)("fCake")), ((V)("fDonuts")), ((V)("fCupcakes")), ((V)("fCookies")), ((V)("fPizza")));
Set(RD_8, "food", Fn((V _arrowThis3755, int _argc3748, V i_3754, V _a3751, V _a3752, V _a3753, V[] _rest3749) => {
return Invoke(RD_8, "draw", NewObj(6).Put("id", ((V)(JsStrBuf.Begin().S("FOOD2-").V(i_3754).End()))).Put("name", ((V)("snack"))).Put("tier", ((V)(2D))).Put("room", ((V)("KIT"))).Put("slot", ((V)(0D))).Put("spec", GetIdx(FOOD2_91, (ToNum(i_3754) % ToNum(Get(FOOD2_91, "length"))))).V);
}, 1, "", true));
Object_assign(RD_8, NewObj(3).Put("PLUS2", ((V)(1D))).Put("ledFloor", ledFloor_83).Put("ledWall", ledWall_84).V);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
