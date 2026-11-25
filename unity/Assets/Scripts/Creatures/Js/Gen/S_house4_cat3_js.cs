// house4-cat3.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house4_cat3_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("^tb", "");
        public static void Run()
        {
Call(Named(boot_106 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V X_8 = default;
V K_9 = default;
V H2_10 = default;
V solid_11 = default;
V box_12 = default;
V cyl_13 = default;
V ball_14 = default;
V slab_15 = default;
V disc_16 = default;
V prism_17 = default;
V prismZ_18 = default;
V shade_19 = default;
V mix_20 = default;
V NE_21 = default;
V GOLD_22 = default;
V CH_23 = default;
V CR_24 = default;
V WH_25 = default;
V DK_26 = default;
V TIN_27 = default;
V OLD_28 = default;
V INK_29 = default;
V LEAF_30 = default;
V LEAF2_31 = default;
V RB6_32 = default;
V MT_33 = default;
V starP_34 = default;
V jewel_35 = default;
V spr_36 = default;
V drips_37 = default;
double PI_38 = 0;
V GL_39 = default;
V zr_40 = default;
V P__41 = default;
V D__42 = default;
V E__43 = default;
V T__44 = default;
V A__45 = default;
V star_46 = default;
V bar_47 = default;
V rnd_48 = default;
V FC_49 = default;
V frame_50 = default;
V art_51 = default;
V poster_52 = default;
V gallery_53 = default;
V handsAt_54 = default;
V wallClock_55 = default;
V wallShelf_56 = default;
V glass_57 = default;
V mirror_58 = default;
V BC_59 = default;
V books_60 = default;
V bookcase_61 = default;
V lowShelf_62 = default;
V T_63 = default;
V vaseFlw_64 = default;
V tbVase_65 = default;
V tbBooks_66 = default;
V tbFruit_67 = default;
V tbCake_68 = default;
V tbTeapot_69 = default;
V tbToaster_70 = default;
V tbMixer_71 = default;
V tbJar_72 = default;
V tbClock_73 = default;
V tbRadio_74 = default;
V tbGlobe_75 = default;
V tbSnow_76 = default;
V tbTrophy_77 = default;
V tbCandles_78 = default;
V tbBox_79 = default;
V tbCup_80 = default;
V duck_81 = default;
V tbDuck_82 = default;
V tbPerfume_83 = default;
V tbSoap_84 = default;
V A3_85 = default;
V L_86 = default;
V Kt_87 = default;
V B_88 = default;
V R_89 = default;
V Dn_90 = default;
V Y_91 = default;
V NEW_92 = default;
V WT_93 = default;
V AA_94 = default;
V BK_95 = default;
V HOSTA_96 = default;
V TOPS_97 = default;
V TVZ_98 = default;
V TVLV_99 = default;
V DECZ_100 = default;
V ROOMFIX_101 = default;
if (_self1.IsNullish) _self1 = GlobalV;
X_8 = Get(G("window"), "House3D");
if (!(Truthy(((((X_8 is var _t102 && !Truthy(_t102) ? _t102 : Get(X_8, "A2")) is var _t103 && !Truthy(_t103) ? _t103 : Get(X_8, "ITEMS")) is var _t104 && !Truthy(_t104) ? _t104 : Get(X_8, "bandOf")) is var _t105 && !Truthy(_t105) ? _t105 : Get(X_8, "pal"))))) {
Call(G("setTimeout"), V.Undef, boot_106.v, ((V)(20D)));
return default;
}
if (Truthy(Get(X_8, "EXT"))) {
return default;
}
K_9 = Get(X_8, "K");
H2_10 = Get(X_8, "H2");
{ V _t107 = K_9;
if (_t107.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t107));
{ V _t108 = Get(_t107, "solid");
solid_11 = _t108; }
{ V _t109 = Get(_t107, "box");
box_12 = _t109; }
{ V _t110 = Get(_t107, "cyl");
cyl_13 = _t110; }
{ V _t111 = Get(_t107, "ball");
ball_14 = _t111; }
{ V _t112 = Get(_t107, "slab");
slab_15 = _t112; }
{ V _t113 = Get(_t107, "disc");
disc_16 = _t113; }
{ V _t114 = Get(_t107, "prism");
prism_17 = _t114; }
{ V _t115 = Get(_t107, "prismZ");
prismZ_18 = _t115; }
{ V _t116 = Get(_t107, "shade");
shade_19 = _t116; }
{ V _t117 = Get(_t107, "mix");
mix_20 = _t117; } }
{ V _t118 = H2_10;
if (_t118.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t118));
{ V _t119 = Get(_t118, "NE");
NE_21 = _t119; }
{ V _t120 = Get(_t118, "GOLD");
GOLD_22 = _t120; }
{ V _t121 = Get(_t118, "CH");
CH_23 = _t121; }
{ V _t122 = Get(_t118, "CR");
CR_24 = _t122; }
{ V _t123 = Get(_t118, "WH");
WH_25 = _t123; }
{ V _t124 = Get(_t118, "DK");
DK_26 = _t124; }
{ V _t125 = Get(_t118, "TIN");
TIN_27 = _t125; }
{ V _t126 = Get(_t118, "OLD");
OLD_28 = _t126; }
{ V _t127 = Get(_t118, "INK");
INK_29 = _t127; }
{ V _t128 = Get(_t118, "LEAF");
LEAF_30 = _t128; }
{ V _t129 = Get(_t118, "LEAF2");
LEAF2_31 = _t129; }
{ V _t130 = Get(_t118, "RB6");
RB6_32 = _t130; }
{ V _t131 = Get(_t118, "MT");
MT_33 = _t131; }
{ V _t132 = Get(_t118, "starP");
starP_34 = _t132; }
{ V _t133 = Get(_t118, "jewel");
jewel_35 = _t133; }
{ V _t134 = Get(_t118, "spr");
spr_36 = _t134; }
{ V _t135 = Get(_t118, "drips");
drips_37 = _t135; } }
PI_38 = System.Math.PI;
GL_39 = ((V)("#cfeaf5"));
zr_40 = Fn((V _arrowThis143, int _argc136, V n_142, V _a139, V _a140, V _a141, V[] _rest137) => {
return Arr(Arr(((V)(((ToNum(n_142) * 0.5) - 0.25))), ((V)(0D))), Arr(((V)(((ToNum(n_142) * 0.5) + 0.25))), ((V)(0D))));
}, 1, "", true);
P__41 = Fn((V _arrowThis158, int _argc144, V x_150, V y_151, V w_152, V h_153, V[] _rest145) => {
V n_154 = default;
V col_155 = default;
V o_157 = default;
n_154 = (_argc144 > 4 ? _rest145[0] : V.Undef);
col_155 = (_argc144 > 5 ? _rest145[1] : V.Undef);
{ V _t156 = (_argc144 > 6 ? _rest145[2] : V.Undef); if (_t156.IsUndef) _t156 = NewObj(0).V;
o_157 = _t156; }
return Call(slab_15, V.Undef, x_150, y_151, ((V)((ToNum(n_154) * 0.5))), w_152, h_153, ((V)(0.5)), col_155, Object_assign(NewObj(2).Put("r", ((V)(2D))).Put("zb", ((V)((ToNum(n_154) * 140D)))).V, o_157));
}, 7, "", true);
D__42 = Fn((V _arrowThis172, int _argc159, V x_165, V y_166, V r_167, V n_168, V[] _rest160) => {
V col_169 = default;
V o_171 = default;
col_169 = (_argc159 > 4 ? _rest160[0] : V.Undef);
{ V _t170 = (_argc159 > 5 ? _rest160[1] : V.Undef); if (_t170.IsUndef) _t170 = NewObj(0).V;
o_171 = _t170; }
return Call(disc_16, V.Undef, x_165, y_166, ((V)(((ToNum(n_168) * 0.5) - 0.25))), r_167, ((V)(0.5)), col_169, Object_assign(NewObj(1).Put("zb", ((V)((ToNum(n_168) * 140D)))).V, o_171));
}, 6, "", true);
E__43 = Fn((V _arrowThis187, int _argc173, V x_179, V y_180, V a_181, V b_182, V[] _rest174) => {
V n_183 = default;
V col_184 = default;
V o_186 = default;
n_183 = (_argc173 > 4 ? _rest174[0] : V.Undef);
col_184 = (_argc173 > 5 ? _rest174[1] : V.Undef);
{ V _t185 = (_argc173 > 6 ? _rest174[2] : V.Undef); if (_t185.IsUndef) _t185 = NewObj(0).V;
o_186 = _t185; }
return Call(solid_11, V.Undef, Object_assign(NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(x_179, y_180)).Put("a", a_181).Put("b", b_182).Put("n", ((V)(20D))).Put("rings", Call(zr_40, V.Undef, n_183)).Put("col", col_184).Put("zb", ((V)((ToNum(n_183) * 140D)))).V, o_186));
}, 7, "", true);
T__44 = Fn((V _arrowThis199, int _argc188, V pts_194, V n_195, V col_196, V _a193, V[] _rest189) => {
V o_198 = default;
{ V _t197 = _a193; if (_t197.IsUndef) _t197 = NewObj(0).V;
o_198 = _t197; }
return Call(prismZ_18, V.Undef, ((V)(((ToNum(n_195) * 0.5) - 0.25))), ((V)(((ToNum(n_195) * 0.5) + 0.25))), pts_194, col_196, Object_assign(NewObj(1).Put("zb", ((V)((ToNum(n_195) * 140D)))).V, o_198));
}, 4, "", true);
A__45 = Fn((V _arrowThis214, int _argc200, V x_206, V y_207, V r_208, V th_209, V[] _rest201) => {
V a0_210 = default;
V a1_211 = default;
V n_212 = default;
V col_213 = default;
a0_210 = (_argc200 > 4 ? _rest201[0] : V.Undef);
a1_211 = (_argc200 > 5 ? _rest201[1] : V.Undef);
n_212 = (_argc200 > 6 ? _rest201[2] : V.Undef);
col_213 = (_argc200 > 7 ? _rest201[3] : V.Undef);
return Call(solid_11, V.Undef, NewObj(12).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(x_206, y_207)).Put("a", r_208).Put("b", r_208).Put("th", th_209).Put("a0", a0_210).Put("a1", a1_211).Put("n", ((V)(18D))).Put("rings", Call(zr_40, V.Undef, n_212)).Put("col", col_213).Put("zb", ((V)((ToNum(n_212) * 140D)))).V);
}, 8, "", true);
star_46 = Fn((V _arrowThis226, int _argc215, V x_221, V y_222, V R_223, V n_224, V[] _rest216) => {
V col_225 = default;
col_225 = (_argc215 > 4 ? _rest216[0] : V.Undef);
return Call(T__44, V.Undef, Invoke(Call(starP_34, V.Undef, ((V)(5D)), R_223, ((V)((ToNum(R_223) * 0.45))), ((V)(1D)), ((V)((PI_38 / 2D)))), "map", Fn((V _arrowThis238, int _argc227, V _a229, V _a230, V _a231, V _a232, V[] _rest228) => {
V a_235 = default;
V b_237 = default;
{ V _t233 = ListOf(_a229);
{ V _t234 = GetIdx(_t233, 0D);
a_235 = _t234; }
{ V _t236 = GetIdx(_t233, 1D);
b_237 = _t236; }
}
return Arr(Add(x_221, a_235), Add(y_222, b_237));
}, 1, "", true)), n_224, col_225);
}, 5, "", true);
bar_47 = Fn((V _arrowThis253, int _argc239, V x0_245, V y0_246, V x1_247, V y1_248, V[] _rest240) => {
double dx_254 = 0;
double dy_255 = 0;
V L_256 = default;
double nx_257 = 0;
double ny_258 = 0;
V t_249 = default;
V n_250 = default;
V col_251 = default;
V o_252 = default;
t_249 = (_argc239 > 4 ? _rest240[0] : V.Undef);
n_250 = (_argc239 > 5 ? _rest240[1] : V.Undef);
col_251 = (_argc239 > 6 ? _rest240[2] : V.Undef);
o_252 = (_argc239 > 7 ? _rest240[3] : V.Undef);
dx_254 = (ToNum(x1_247) - ToNum(x0_245));
dy_255 = (ToNum(y1_248) - ToNum(y0_246));
L_256 = (((V)(Hypot(dx_254, dy_255))) is var _t259 && Truthy(_t259) ? _t259 : ((V)(1D)));
nx_257 = ((((-dy_255) / ToNum(L_256)) * ToNum(t_249)) / 2D);
ny_258 = (((dx_254 / ToNum(L_256)) * ToNum(t_249)) / 2D);
return Call(T__44, V.Undef, Arr(Arr(Add(x0_245, ((V)(nx_257))), Add(y0_246, ((V)(ny_258)))), Arr(Add(x1_247, ((V)(nx_257))), Add(y1_248, ((V)(ny_258)))), Arr(((V)((ToNum(x1_247) - nx_257))), ((V)((ToNum(y1_248) - ny_258)))), Arr(((V)((ToNum(x0_245) - nx_257))), ((V)((ToNum(y0_246) - ny_258))))), n_250, col_251, o_252);
return default;
}, 8, "", true);
rnd_48 = Fn((V _arrowThis267, int _argc260, V s_266, V _a263, V _a264, V _a265, V[] _rest261) => {
V v_268 = default;
v_268 = s_266;
return Fn((V _arrowThis275, int _argc269, V _a271, V _a272, V _a273, V _a274, V[] _rest270) => {
return ((V)((ToNum((v_268 = ((V)((((ToNum(v_268) * 9301D) + 49297D) % 233280D))))) / 233280D)));
}, 0, "", true);
return default;
}, 1, "", true);
FC_49 = Fn((V _arrowThis284, int _argc276, V k_282, V P_283, V _a280, V _a281, V[] _rest277) => {
return (SEqS(k_282, "junk") ? OLD_28 : (SEqS(k_282, "cot") ? Get(P_283, "w") : (SEqS(k_282, "retro") ? CH_23 : (SEqS(k_282, "mod") ? DK_26 : (SEqS(k_282, "candy") ? Get(P_283, "b") : GOLD_22)))));
}, 2, "", true);
frame_50 = Fn((V _arrowThis297, int _argc285, V k_291, V P_292, V W_293, V H_294, V[] _rest286) => {
V o_298 = default;
V fc_299 = default;
double t_300 = 0;
V y0_296 = default;
{ V _t295 = (_argc285 > 4 ? _rest286[0] : V.Undef); if (_t295.IsUndef) _t295 = ((V)(0D));
y0_296 = _t295; }
o_298 = Arr();
fc_299 = Call(FC_49, V.Undef, k_291, P_292);
if (SEqS(k_291, "junk")) {
InvokeSpread(o_298, "push", new ArrBuilder().Add(Call(slab_15, V.Undef, ((V)(0D)), y0_296, ((V)((-1D))), W_293, H_294, ((V)(2D)), ((V)("#f3ead2")), NewObj(1).Put("r", ((V)(1D))).V)).Spread(Invoke(Arr(Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D))), Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D))))), "map", Fn((V _arrowThis312, int _argc301, V _a303, V _a304, V _a305, V _a306, V[] _rest302) => {
V a_309 = default;
V b_311 = default;
{ V _t307 = ListOf(_a303);
{ V _t308 = GetIdx(_t307, 0D);
a_309 = _t308; }
{ V _t310 = GetIdx(_t307, 1D);
b_311 = _t310; }
}
return Call(P__41, V.Undef, ((V)((ToNum(a_309) * ((ToNum(W_293) / 2D) - 4D)))), Add(y0_296, ((V)((GtN(b_311, 0D) ? (ToNum(H_294) - 7D) : (-1D))))), ((V)(12D)), ((V)(8D)), ((V)(9D)), ((V)("#f6e7a8")), NewObj(1).Put("r", ((V)(1D))).V);
}, 1, "", true))).V);
return o_298;
}
t_300 = ((SEqS(k_291, "cot") || SEqS(k_291, "royal")) ? 5D : 3D);
Invoke(o_298, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)((ToNum(y0_296) - t_300))), ((V)((-2D))), Add(W_293, ((V)((t_300 * 2D)))), Add(H_294, ((V)((t_300 * 2D)))), ((V)(4D)), fc_299, NewObj(1).Put("r", ((V)((SEqS(k_291, "retro") ? 8D : (SEqS(k_291, "candy") ? 10D : 2D))))).V));
if (SEqS(k_291, "mod")) {
Invoke(o_298, "push", Call(P__41, V.Undef, ((V)(0D)), y0_296, W_293, H_294, ((V)(0.6)), WH_25, NewObj(1).Put("r", ((V)(0D))).V));
}
if (SEqS(k_291, "candy")) {
double n_313 = 0;
n_313 = Round((ToNum(Add(W_293, H_294)) / 7D));
{
double i_314 = 0;
i_314 = 0D;
while (true) {
if (!((i_314 < n_313))) break;
double u_316 = 0;
double p_317 = 0;
double x_318 = 0;
V y_319 = default;
u_316 = (i_314 / n_313);
p_317 = ((u_316 * 2D) * ToNum(Add(W_293, H_294)));
x_318 = (Lt(((V)(p_317)), W_293) ? (((-ToNum(W_293)) / 2D) + p_317) : (Lt(((V)(p_317)), Add(W_293, H_294)) ? (ToNum(W_293) / 2D) : (Lt(((V)(p_317)), Add(((V)((2D * ToNum(W_293)))), H_294)) ? ((ToNum(W_293) / 2D) - ((p_317 - ToNum(W_293)) - ToNum(H_294))) : ((-ToNum(W_293)) / 2D))));
y_319 = (Lt(((V)(p_317)), W_293) ? ((V)((ToNum(y0_296) - t_300))) : (Lt(((V)(p_317)), Add(W_293, H_294)) ? ((V)(((ToNum(y0_296) - t_300) + (p_317 - ToNum(W_293))))) : (Lt(((V)(p_317)), Add(((V)((2D * ToNum(W_293)))), H_294)) ? Add(Add(y0_296, H_294), ((V)(t_300))) : ((V)((ToNum(Add(Add(y0_296, H_294), ((V)(t_300)))) - ((p_317 - (2D * ToNum(W_293))) - ToNum(H_294))))))));
Invoke(o_298, "push", Call(ball_14, V.Undef, ((V)(x_318)), ((V)((ToNum(y_319) - 3D))), ((V)(1D)), ((V)(3.4)), GetIdx(NE_21, (i_314 % 6D)), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("zb", ((V)(1400D))).V));
i_314++;
}
}
}
if (SEqS(k_291, "royal")) {
InvokeSpread(o_298, "push", new ArrBuilder().Spread(Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "map", Fn((V _arrowThis331, int _argc320, V _a322, V _a323, V _a324, V _a325, V[] _rest321) => {
V a_328 = default;
V b_330 = default;
{ V _t326 = ListOf(_a322);
{ V _t327 = GetIdx(_t326, 0D);
a_328 = _t327; }
{ V _t329 = GetIdx(_t326, 1D);
b_330 = _t329; }
}
return Call(ball_14, V.Undef, ((V)((ToNum(a_328) * ((ToNum(W_293) / 2D) + 2D)))), ((V)((ToNum(Add(y0_296, (GtN(b_330, 0D) ? Add(H_294, ((V)(2D))) : ((V)((-2D)))))) - 3D))), ((V)(1D)), ((V)(4D)), GOLD_22, NewObj(1).Put("zb", ((V)(1400D))).V);
}, 1, "", true))).Add(Call(ball_14, V.Undef, ((V)(0D)), Add(Add(y0_296, H_294), ((V)(4D))), ((V)(1D)), ((V)(4.5)), ((V)("#7a1e2c")), NewObj(1).Put("zb", ((V)(1500D))).V)).V);
}
return o_298;
return default;
}, 5, "", true);
art_51 = Fn((V _arrowThis343, int _argc332, V v_338, V P_339, V W_340, V H_341, V[] _rest333) => {
V o_344 = default;
double cx_345 = 0;
V Y_346 = default;
V X__347 = default;
V y0_342 = default;
y0_342 = (_argc332 > 4 ? _rest333[0] : V.Undef);
o_344 = Arr();
cx_345 = 0D;
Y_346 = Fn((V _arrowThis355, int _argc348, V f_354, V _a351, V _a352, V _a353, V[] _rest349) => {
return Add(y0_342, ((V)((ToNum(H_341) * ToNum(f_354)))));
}, 1, "", true);
X__347 = Fn((V _arrowThis363, int _argc356, V f_362, V _a359, V _a360, V _a361, V[] _rest357) => {
return ((V)((ToNum(W_340) * ToNum(f_362))));
}, 1, "", true);
if (SEqS(v_338, "pal")) {
Invoke(o_344, "push", Call(P__41, V.Undef, ((V)(0D)), y0_342, W_340, H_341, ((V)(1D)), Get(P_339, "aL")), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)((-0.22)))), Call(Y_346, V.Undef, ((V)(0.62))), ((V)((ToNum(W_340) * 0.11))), ((V)(2D)), Get(P_339, "b")), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)(0.22))), Call(Y_346, V.Undef, ((V)(0.62))), ((V)((ToNum(W_340) * 0.11))), ((V)(2D)), Get(P_339, "b")), Call(D__42, V.Undef, ((V)(0D)), Call(Y_346, V.Undef, ((V)(0.44))), ((V)((ToNum(W_340) * 0.32))), ((V)(3D)), Get(P_339, "b")), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)((-0.11)))), Call(Y_346, V.Undef, ((V)(0.48))), ((V)(2.6)), ((V)(4D)), INK_29), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)(0.11))), Call(Y_346, V.Undef, ((V)(0.48))), ((V)(2.6)), ((V)(4D)), INK_29), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)((-0.1)))), Call(Y_346, V.Undef, ((V)(0.5))), ((V)(0.9)), ((V)(5D)), WH_25), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)(0.12))), Call(Y_346, V.Undef, ((V)(0.5))), ((V)(0.9)), ((V)(5D)), WH_25), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)((-0.2)))), Call(Y_346, V.Undef, ((V)(0.4))), ((V)(3D)), ((V)(4D)), ((V)("#ffa36a"))), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)(0.2))), Call(Y_346, V.Undef, ((V)(0.4))), ((V)(3D)), ((V)(4D)), ((V)("#ffa36a"))), Call(A__45, V.Undef, ((V)(0D)), Call(Y_346, V.Undef, ((V)(0.42))), ((V)(4D)), ((V)(1.4)), ((V)((PI_38 * 1.15))), ((V)((PI_38 * 1.85))), ((V)(4D)), INK_29), Call(P__41, V.Undef, ((V)(0D)), Call(Y_346, V.Undef, ((V)(0.06))), ((V)((ToNum(W_340) * 0.7))), ((V)((ToNum(H_341) * 0.1))), ((V)(2D)), Get(P_339, "a")));
return o_344;
}
if (SEqS(v_338, "stars")) {
Invoke(o_344, "push", Call(P__41, V.Undef, ((V)(0D)), y0_342, W_340, H_341, ((V)(1D)), ((V)("#2b3a6a"))), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)(0.22))), Call(Y_346, V.Undef, ((V)(0.76))), ((V)((ToNum(W_340) * 0.15))), ((V)(2D)), ((V)("#ffe9a8"))), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)(0.29))), Call(Y_346, V.Undef, ((V)(0.8))), ((V)((ToNum(W_340) * 0.13))), ((V)(3D)), ((V)("#2b3a6a"))));
Invoke(Arr(Arr(((V)((-0.25))), ((V)(0.7)), ((V)(5D))), Arr(((V)((-0.05))), ((V)(0.5)), ((V)(3.5))), Arr(((V)(0.2)), ((V)(0.36)), ((V)(4.5))), Arr(((V)((-0.28))), ((V)(0.24)), ((V)(3D))), Arr(((V)(0.02)), ((V)(0.16)), ((V)(2.6))), Arr(((V)(0.3)), ((V)(0.12)), ((V)(2.6)))), "forEach", Fn((V _arrowThis377, int _argc364, V _a366, V _a367, V _a368, V _a369, V[] _rest365) => {
V a_372 = default;
V b_374 = default;
V r_376 = default;
{ V _t370 = ListOf(_a366);
{ V _t371 = GetIdx(_t370, 0D);
a_372 = _t371; }
{ V _t373 = GetIdx(_t370, 1D);
b_374 = _t373; }
{ V _t375 = GetIdx(_t370, 2D);
r_376 = _t375; }
}
return Invoke(o_344, "push", Call(star_46, V.Undef, Call(X__347, V.Undef, a_372), Call(Y_346, V.Undef, b_374), r_376, ((V)(2D)), ((V)("#ffd23f"))));
}, 1, "", true));
Invoke(o_344, "push", Call(P__41, V.Undef, ((V)(0D)), y0_342, W_340, ((V)((ToNum(H_341) * 0.12))), ((V)(2D)), ((V)("#3e5a3a")), NewObj(1).Put("r", ((V)(0D))).V));
return o_344;
}
if (SEqS(v_338, "rainbow")) {
Invoke(o_344, "push", Call(P__41, V.Undef, ((V)(0D)), y0_342, W_340, H_341, ((V)(1D)), CR_24));
Invoke(RB6_32, "forEach", Fn((V _arrowThis386, int _argc378, V c_384, V i_385, V _a382, V _a383, V[] _rest379) => {
return Invoke(o_344, "push", Call(A__45, V.Undef, ((V)(0D)), Call(Y_346, V.Undef, ((V)(0.34))), ((V)(((ToNum(W_340) * 0.42) - (ToNum(i_385) * 3.2)))), ((V)(3.2)), ((V)(0D)), ((V)(PI_38)), ((V)(2D)), c_384));
}, 2, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis394, int _argc387, V s_393, V _a390, V _a391, V _a392, V[] _rest388) => {
return Invoke(o_344, "push", Call(D__42, V.Undef, ((V)(((ToNum(s_393) * ToNum(W_340)) * 0.32))), Call(Y_346, V.Undef, ((V)(0.32))), ((V)(5D)), ((V)(3D)), WH_25), Call(D__42, V.Undef, ((V)(((ToNum(s_393) * ToNum(W_340)) * 0.22))), Call(Y_346, V.Undef, ((V)(0.3))), ((V)(4D)), ((V)(3D)), WH_25));
}, 1, "", true));
return o_344;
}
if (SEqS(v_338, "music")) {
Invoke(o_344, "push", Call(P__41, V.Undef, ((V)(0D)), y0_342, W_340, H_341, ((V)(1D)), ((V)("#3b2e5a"))), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)((-0.08)))), Call(Y_346, V.Undef, ((V)(0.42))), ((V)((ToNum(W_340) * 0.13))), ((V)(2D)), ((V)("#ffd23f"))), Call(P__41, V.Undef, Call(X__347, V.Undef, ((V)(0.03))), Call(Y_346, V.Undef, ((V)(0.42))), ((V)(3D)), ((V)((ToNum(H_341) * 0.4))), ((V)(2D)), ((V)("#ffd23f")), NewObj(1).Put("r", ((V)(1D))).V), Call(T__44, V.Undef, Arr(Arr(Call(X__347, V.Undef, ((V)(0.03))), Call(Y_346, V.Undef, ((V)(0.82)))), Arr(Call(X__347, V.Undef, ((V)(0.25))), Call(Y_346, V.Undef, ((V)(0.72)))), Arr(Call(X__347, V.Undef, ((V)(0.25))), Call(Y_346, V.Undef, ((V)(0.64)))), Arr(Call(X__347, V.Undef, ((V)(0.03))), Call(Y_346, V.Undef, ((V)(0.72))))), ((V)(2D)), ((V)("#ffd23f"))), Call(star_46, V.Undef, Call(X__347, V.Undef, ((V)((-0.3)))), Call(Y_346, V.Undef, ((V)(0.82))), ((V)(3.4)), ((V)(2D)), ((V)("#4fe0d0"))), Call(star_46, V.Undef, Call(X__347, V.Undef, ((V)(0.3))), Call(Y_346, V.Undef, ((V)(0.36))), ((V)(2.8)), ((V)(2D)), ((V)("#ff9d4a"))));
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis402, int _argc395, V i_401, V _a398, V _a399, V _a400, V[] _rest396) => {
return Invoke(o_344, "push", Call(P__41, V.Undef, ((V)(0D)), Add(Call(Y_346, V.Undef, ((V)(0.08))), ((V)((ToNum(i_401) * 4D)))), ((V)((ToNum(W_340) * (0.7 - (ToNum(i_401) * 0.15))))), ((V)(2.4)), ((V)(2D)), GetIdx(NE_21, (ToNum(i_401) * 2D)), NewObj(1).Put("r", ((V)(1D))).V));
}, 1, "", true));
return o_344;
}
if (SEqS(v_338, "sunset")) {
Invoke(Arr(((V)("#ffcf6a")), ((V)("#ffa94a")), ((V)("#ff8a5a"))), "forEach", Fn((V _arrowThis411, int _argc403, V c_409, V i_410, V _a407, V _a408, V[] _rest404) => {
return Invoke(o_344, "push", Call(P__41, V.Undef, ((V)(0D)), Add(y0_342, ((V)((ToNum(H_341) * (0.45 + (ToNum(i_410) * 0.18)))))), W_340, ((V)((ToNum(H_341) * (0.55 - (ToNum(i_410) * 0.18))))), ((V)((1D + (ToNum(i_410) * 0.3)))), c_409, NewObj(1).Put("r", ((V)(1D))).V));
}, 2, "", true));
Invoke(o_344, "push", Call(D__42, V.Undef, ((V)(0D)), Call(Y_346, V.Undef, ((V)(0.48))), ((V)((ToNum(W_340) * 0.2))), ((V)(2.2)), ((V)("#fff1a0"))), Call(P__41, V.Undef, ((V)(0D)), y0_342, W_340, ((V)((ToNum(H_341) * 0.46))), ((V)(3D)), ((V)("#4a8ad6")), NewObj(1).Put("r", ((V)(1D))).V), Call(P__41, V.Undef, ((V)(0D)), Call(Y_346, V.Undef, ((V)(0.3))), ((V)((ToNum(W_340) * 0.6))), ((V)(1.6)), ((V)(4D)), ((V)("#9fd0ff"))), Call(P__41, V.Undef, Call(X__347, V.Undef, ((V)((-0.1)))), Call(Y_346, V.Undef, ((V)(0.18))), ((V)((ToNum(W_340) * 0.4))), ((V)(1.6)), ((V)(4D)), ((V)("#9fd0ff"))));
return o_344;
}
if (SEqS(v_338, "fruit")) {
Invoke(o_344, "push", Call(P__41, V.Undef, ((V)(0D)), y0_342, W_340, H_341, ((V)(1D)), CR_24), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)((-0.16)))), Call(Y_346, V.Undef, ((V)(0.62))), ((V)((ToNum(W_340) * 0.17))), ((V)(2D)), ((V)("#ffa940"))), Call(T__44, V.Undef, Arr(Arr(Call(X__347, V.Undef, ((V)((-0.16)))), Call(Y_346, V.Undef, ((V)(0.75)))), Arr(Call(X__347, V.Undef, ((V)((-0.02)))), Call(Y_346, V.Undef, ((V)(0.83)))), Arr(Call(X__347, V.Undef, ((V)((-0.1)))), Call(Y_346, V.Undef, ((V)(0.74))))), ((V)(3D)), LEAF_30), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)(0.16))), Call(Y_346, V.Undef, ((V)(0.36))), ((V)((ToNum(W_340) * 0.17))), ((V)(2D)), ((V)("#e2554a"))), Call(P__41, V.Undef, Call(X__347, V.Undef, ((V)(0.16))), Call(Y_346, V.Undef, ((V)(0.46))), ((V)(1.6)), ((V)(6D)), ((V)(3D)), ((V)("#8a5a34"))), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)((-0.18)))), Call(Y_346, V.Undef, ((V)(0.26))), ((V)((ToNum(W_340) * 0.12))), ((V)(2D)), ((V)("#a6d65a"))), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)((-0.18)))), Call(Y_346, V.Undef, ((V)(0.35))), ((V)((ToNum(W_340) * 0.08))), ((V)(2D)), ((V)("#a6d65a"))));
return o_344;
}
if (SEqS(v_338, "movie")) {
Invoke(o_344, "push", Call(P__41, V.Undef, ((V)(0D)), y0_342, W_340, H_341, ((V)(1D)), INK_29));
{
V i_412 = default;
i_412 = ((V)(0D));
while (true) {
V i_412_it = i_412;
if (!(LtN(i_412_it, 7D))) break;
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis421, int _argc414, V s_420, V _a417, V _a418, V _a419, V[] _rest415) => {
return Invoke(o_344, "push", Call(P__41, V.Undef, ((V)((ToNum(s_420) * ((ToNum(W_340) / 2D) - 4D)))), Add(Add(y0_342, ((V)(4D))), ((V)(((ToNum(i_412_it) * (ToNum(H_341) - 10D)) / 6D)))), ((V)(4D)), ((V)(3D)), ((V)(2D)), WH_25, NewObj(1).Put("r", ((V)(0.5))).V));
}, 1, "", true));
i_412 = i_412_it;
PostInc(ref i_412, 1D);
}
}
Invoke(o_344, "push", Call(P__41, V.Undef, ((V)(0D)), Call(Y_346, V.Undef, ((V)(0.22))), ((V)((ToNum(W_340) - 18D))), ((V)((ToNum(H_341) * 0.62))), ((V)(2D)), ((V)("#ffa940"))), Call(D__42, V.Undef, ((V)(0D)), Call(Y_346, V.Undef, ((V)(0.44))), ((V)((ToNum(W_340) * 0.17))), ((V)(3D)), INK_29), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)((-0.12)))), Call(Y_346, V.Undef, ((V)(0.6))), ((V)((ToNum(W_340) * 0.07))), ((V)(3D)), INK_29), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)(0.12))), Call(Y_346, V.Undef, ((V)(0.6))), ((V)((ToNum(W_340) * 0.07))), ((V)(3D)), INK_29), Call(P__41, V.Undef, ((V)(0D)), Call(Y_346, V.Undef, ((V)(0.06))), ((V)((ToNum(W_340) * 0.56))), ((V)((ToNum(H_341) * 0.08))), ((V)(2D)), ((V)("#ffd23f"))));
return o_344;
}
if (SEqS(v_338, "map")) {
Invoke(o_344, "push", Call(P__41, V.Undef, ((V)(0D)), y0_342, W_340, H_341, ((V)(1D)), ((V)("#f1e3c0"))), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)((-0.18)))), Call(Y_346, V.Undef, ((V)(0.66))), ((V)((ToNum(W_340) * 0.18))), ((V)(2D)), ((V)("#9fc684"))), Call(D__42, V.Undef, Call(X__347, V.Undef, ((V)(0.2))), Call(Y_346, V.Undef, ((V)(0.3))), ((V)((ToNum(W_340) * 0.16))), ((V)(2D)), ((V)("#9fc684"))));
{
double i_422 = 0;
i_422 = 0D;
while (true) {
if (!((i_422 < 5D))) break;
double u_424 = 0;
u_424 = (i_422 / 4D);
Invoke(o_344, "push", Call(P__41, V.Undef, Call(X__347, V.Undef, ((V)(((-0.12) + (u_424 * 0.3))))), Call(Y_346, V.Undef, ((V)((0.56 - (u_424 * 0.24))))), ((V)(3.4)), ((V)(1.6)), ((V)(3D)), ((V)("#b8714a")), NewObj(1).Put("r", ((V)(0.5))).V));
i_422++;
}
}
Invoke(o_344, "push", Call(bar_47, V.Undef, Call(X__347, V.Undef, ((V)(0.14))), Call(Y_346, V.Undef, ((V)(0.24))), Call(X__347, V.Undef, ((V)(0.26))), Call(Y_346, V.Undef, ((V)(0.36))), ((V)(2.4)), ((V)(4D)), ((V)("#e2554a"))), Call(bar_47, V.Undef, Call(X__347, V.Undef, ((V)(0.14))), Call(Y_346, V.Undef, ((V)(0.36))), Call(X__347, V.Undef, ((V)(0.26))), Call(Y_346, V.Undef, ((V)(0.24))), ((V)(2.4)), ((V)(4D)), ((V)("#e2554a"))), Call(star_46, V.Undef, Call(X__347, V.Undef, ((V)((-0.3)))), Call(Y_346, V.Undef, ((V)(0.16))), ((V)(4D)), ((V)(3D)), ((V)("#4a6fd6"))));
return o_344;
}
return Arr(Call(P__41, V.Undef, ((V)(0D)), y0_342, W_340, H_341, ((V)(1D)), Get(P_339, "aL")));
return default;
}, 5, "", true);
poster_52 = Fn((V _arrowThis432, int _argc425, V S_431, V _a428, V _a429, V _a430, V[] _rest426) => {
V k_433 = default;
double W_434 = 0;
double Hh_435 = 0;
k_433 = Get(S_431, "k");
W_434 = 62D;
Hh_435 = 82D;
return NewObj(5).Put("w", ((V)(76D))).Put("d", ((V)(8D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(36D))).Put("build", Fn((V _arrowThis443, int _argc436, V P_442, V _a439, V _a440, V _a441, V[] _rest437) => {
return new ArrBuilder().Spread(Call(frame_50, V.Undef, k_433, P_442, ((V)(W_434)), ((V)(Hh_435)), ((V)(6D)))).Spread(Call(art_51, V.Undef, Get(S_431, "v"), P_442, ((V)(W_434)), ((V)(Hh_435)), ((V)(6D)))).V;
}, 1, "build", true)).V;
return default;
}, 1, "", true);
gallery_53 = Fn((V _arrowThis451, int _argc444, V S_450, V _a447, V _a448, V _a449, V[] _rest445) => {
return NewObj(5).Put("w", ((V)(110D))).Put("d", ((V)(8D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(44D))).Put("build", Fn((V _arrowThis459, int _argc452, V P_458, V _a455, V _a456, V _a457, V[] _rest453) => {
V k_460 = default;
V o_461 = default;
k_460 = Get(S_450, "k");
o_461 = Arr();
Invoke(Arr(Arr(((V)((-36D))), ((V)(12D)), ((V)(26D)), ((V)(32D)), ((V)("sun"))), Arr(((V)(2D)), ((V)(4D)), ((V)(34D)), ((V)(44D)), ((V)("pal"))), Arr(((V)(38D)), ((V)(18D)), ((V)(24D)), ((V)(28D)), ((V)("heart")))), "forEach", Fn((V _arrowThis479, int _argc462, V _a464, V _a465, V _a466, V _a467, V[] _rest463) => {
V fr_480 = default;
V x_470 = default;
V y_472 = default;
V w_474 = default;
V h_476 = default;
V v_478 = default;
{ V _t468 = ListOf(_a464);
{ V _t469 = GetIdx(_t468, 0D);
x_470 = _t469; }
{ V _t471 = GetIdx(_t468, 1D);
y_472 = _t471; }
{ V _t473 = GetIdx(_t468, 2D);
w_474 = _t473; }
{ V _t475 = GetIdx(_t468, 3D);
h_476 = _t475; }
{ V _t477 = GetIdx(_t468, 4D);
v_478 = _t477; }
}
fr_480 = Call(frame_50, V.Undef, k_460, P_458, w_474, h_476, y_472);
Invoke(fr_480, "forEach", Fn((V _arrowThis488, int _argc481, V s_487, V _a484, V _a485, V _a486, V[] _rest482) => {
V U_489 = default;
U_489 = New(G("Set"), Get(s_487, "pts"));
Invoke(Get(s_487, "faces"), "forEach", Fn((V _arrowThis497, int _argc490, V F_496, V _a493, V _a494, V _a495, V[] _rest491) => {
return Invoke(Get(F_496, "q"), "forEach", Fn((V _arrowThis505, int _argc498, V p_504, V _a501, V _a502, V _a503, V[] _rest499) => {
return Invoke(U_489, "add", p_504);
}, 1, "", true));
}, 1, "", true));
Invoke(U_489, "forEach", Fn((V _arrowThis513, int _argc506, V p_512, V _a509, V _a510, V _a511, V[] _rest507) => {
return OpSetK(p_512, ((V)(0D)), 0, x_470);
}, 1, "", true));
return default;
}, 1, "", true));
InvokeSpread(o_461, "push", new ArrBuilder().Spread(fr_480).V);
if (SEqS(v_478, "sun")) {
Invoke(o_461, "push", Call(P__41, V.Undef, x_470, y_472, w_474, h_476, ((V)(1D)), ((V)("#bfe4ff"))), Call(D__42, V.Undef, x_470, Add(y_472, ((V)((ToNum(h_476) * 0.6)))), ((V)((ToNum(w_474) * 0.2))), ((V)(2D)), ((V)("#ffd23f"))), Call(P__41, V.Undef, x_470, y_472, w_474, ((V)((ToNum(h_476) * 0.3))), ((V)(2D)), LEAF2_31, NewObj(1).Put("r", ((V)(1D))).V));
} else {
if (SEqS(v_478, "pal")) {
Invoke(o_461, "push", Call(P__41, V.Undef, x_470, y_472, w_474, h_476, ((V)(1D)), Get(P_458, "aL")), Call(D__42, V.Undef, x_470, Add(y_472, ((V)((ToNum(h_476) * 0.42)))), ((V)((ToNum(w_474) * 0.3))), ((V)(2D)), Get(P_458, "b")), Call(D__42, V.Undef, ((V)((ToNum(x_470) - 4D))), Add(y_472, ((V)((ToNum(h_476) * 0.46)))), ((V)(1.8)), ((V)(3D)), INK_29), Call(D__42, V.Undef, Add(x_470, ((V)(4D))), Add(y_472, ((V)((ToNum(h_476) * 0.46)))), ((V)(1.8)), ((V)(3D)), INK_29), Call(A__45, V.Undef, x_470, Add(y_472, ((V)((ToNum(h_476) * 0.4)))), ((V)(3D)), ((V)(1.1)), ((V)((PI_38 * 1.15))), ((V)((PI_38 * 1.85))), ((V)(3D)), INK_29));
} else {
Invoke(o_461, "push", Call(P__41, V.Undef, x_470, y_472, w_474, h_476, ((V)(1D)), CR_24), Call(D__42, V.Undef, ((V)((ToNum(x_470) - 3.6))), Add(y_472, ((V)((ToNum(h_476) * 0.56)))), ((V)(4.4)), ((V)(2D)), ((V)("#e2554a"))), Call(D__42, V.Undef, Add(x_470, ((V)(3.6))), Add(y_472, ((V)((ToNum(h_476) * 0.56)))), ((V)(4.4)), ((V)(2D)), ((V)("#e2554a"))), Call(T__44, V.Undef, Arr(Arr(((V)((ToNum(x_470) - 8D))), Add(y_472, ((V)((ToNum(h_476) * 0.53))))), Arr(Add(x_470, ((V)(8D))), Add(y_472, ((V)((ToNum(h_476) * 0.53))))), Arr(x_470, Add(y_472, ((V)((ToNum(h_476) * 0.26)))))), ((V)(2D)), ((V)("#e2554a"))));
}
}
return default;
}, 1, "", true));
return o_461;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
handsAt_54 = Fn((V _arrowThis523, int _argc514, V cy_520, V R_521, V z_522, V _a519, V[] _rest515) => {
return Arr(Call(bar_47, V.Undef, ((V)(0D)), cy_520, ((V)(0D)), Add(cy_520, ((V)((ToNum(R_521) * 0.5)))), ((V)(2.6)), z_522, INK_29, NewObj(1).Put("part", ((V)(1D))).V), Call(bar_47, V.Undef, ((V)(0D)), cy_520, ((V)((ToNum(R_521) * 0.62))), Add(cy_520, ((V)((ToNum(R_521) * 0.36)))), ((V)(1.8)), Add(z_522, ((V)(1D))), INK_29, NewObj(1).Put("part", ((V)(1D))).V), Call(D__42, V.Undef, ((V)(0D)), cy_520, ((V)(2.2)), Add(z_522, ((V)(2D))), ((V)("#e2554a")), NewObj(1).Put("part", ((V)(1D))).V));
}, 3, "", true);
wallClock_55 = Fn((V _arrowThis531, int _argc524, V S_530, V _a527, V _a528, V _a529, V[] _rest525) => {
V k_532 = default;
double cy_533 = 0;
double R_534 = 0;
k_532 = Get(S_530, "k");
cy_533 = (SEqS(k_532, "cot") ? 60D : 26D);
R_534 = (SEqS(k_532, "cot") ? 13D : 22D);
return NewObj(7).Put("w", ((V)(((SEqS(k_532, "retro") || SEqS(k_532, "royal")) ? 76D : 54D)))).Put("d", ((V)(8D))).Put("mount", ((V)("wall"))).Put("elev", ((V)((SEqS(k_532, "cot") ? 16D : 64D)))).Put("anim", ((V)("clock"))).Put("pivot", Arr(((V)(0D)), ((V)(cy_533)), ((V)(4D)))).Put("build", Fn((V _arrowThis542, int _argc535, V P_541, V _a538, V _a539, V _a540, V[] _rest536) => {
V o_543 = default;
o_543 = Arr();
if (SEqS(k_532, "cot")) {
Invoke(o_543, "push", Call(prismZ_18, V.Undef, ((V)((-4D))), ((V)(0D)), Arr(Arr(((V)((-24D))), ((V)(36D))), Arr(((V)(24D)), ((V)(36D))), Arr(((V)(24D)), ((V)(72D))), Arr(((V)(0D)), ((V)(92D))), Arr(((V)((-24D))), ((V)(72D)))), Get(P_541, "w")), Call(T__44, V.Undef, Arr(Arr(((V)((-28D))), ((V)(70D))), Arr(((V)(0D)), ((V)(96D))), Arr(((V)(0D)), ((V)(90D))), Arr(((V)((-24D))), ((V)(68D)))), ((V)(1D)), Get(P_541, "b")), Call(T__44, V.Undef, Arr(Arr(((V)(28D)), ((V)(70D))), Arr(((V)(0D)), ((V)(96D))), Arr(((V)(0D)), ((V)(90D))), Arr(((V)(24D)), ((V)(68D)))), ((V)(1D)), Get(P_541, "b")), Call(P__41, V.Undef, ((V)(0D)), ((V)(76D)), ((V)(10D)), ((V)(9D)), ((V)(1D)), Call(shade_19, V.Undef, Get(P_541, "w"), ((V)(0.7))), NewObj(1).Put("r", ((V)(1D))).V), Call(D__42, V.Undef, ((V)(0D)), ((V)(82D)), ((V)(2.6)), ((V)(2D)), ((V)("#ffd23f"))));
Invoke(Arr(Arr(((V)((-8D))), ((V)(8D))), Arr(((V)(8D)), ((V)(14D)))), "forEach", Fn((V _arrowThis555, int _argc544, V _a546, V _a547, V _a548, V _a549, V[] _rest545) => {
V x_552 = default;
V y_554 = default;
{ V _t550 = ListOf(_a546);
{ V _t551 = GetIdx(_t550, 0D);
x_552 = _t551; }
{ V _t553 = GetIdx(_t550, 1D);
y_554 = _t553; }
}
return Invoke(o_543, "push", Call(P__41, V.Undef, x_552, y_554, ((V)(1.2)), ((V)((36D - ToNum(y_554)))), ((V)(0.5)), ((V)("#8a8f94")), NewObj(1).Put("r", ((V)(0D))).V), Call(E__43, V.Undef, x_552, y_554, ((V)(3.4)), ((V)(6D)), ((V)(1D)), ((V)("#8a5a34"))));
}, 1, "", true));
{
V i_556 = default;
i_556 = ((V)(0D));
while (true) {
V i_556_it = i_556;
if (!(LtN(i_556_it, 4D))) break;
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis565, int _argc558, V s_564, V _a561, V _a562, V _a563, V[] _rest559) => {
return Invoke(o_543, "push", Call(T__44, V.Undef, Arr(Arr(((V)((ToNum(s_564) * 22D))), ((V)((40D + (ToNum(i_556_it) * 6D))))), Arr(((V)((ToNum(s_564) * 28D))), ((V)((43D + (ToNum(i_556_it) * 6D))))), Arr(((V)((ToNum(s_564) * 22D))), ((V)((46D + (ToNum(i_556_it) * 6D)))))), ((V)(1D)), LEAF2_31));
}, 1, "", true));
i_556 = i_556_it;
PostInc(ref i_556, 1D);
}
}
Invoke(o_543, "push", Call(D__42, V.Undef, ((V)(0D)), ((V)(cy_533)), ((V)(R_534)), ((V)(1D)), CR_24));
} else {
if ((SEqS(k_532, "retro") || SEqS(k_532, "royal"))) {
V rc_566 = default;
rc_566 = (SEqS(k_532, "royal") ? GOLD_22 : CH_23);
{
double i_567 = 0;
i_567 = 0D;
while (true) {
if (!((i_567 < 12D))) break;
double a_569 = 0;
double L_570 = 0;
a_569 = (((i_567 / 12D) * PI_38) * 2D);
L_570 = (NumTruthy((i_567 % 2D)) ? 30D : 36D);
Invoke(o_543, "push", Call(bar_47, V.Undef, ((V)((FdLibm.Cos(a_569) * 12D))), ((V)((cy_533 + (FdLibm.Sin(a_569) * 12D)))), ((V)((FdLibm.Cos(a_569) * L_570))), ((V)((cy_533 + (FdLibm.Sin(a_569) * L_570)))), ((V)(3D)), ((V)(0D)), rc_566), Call(ball_14, V.Undef, ((V)((FdLibm.Cos(a_569) * L_570))), ((V)(((cy_533 + (FdLibm.Sin(a_569) * L_570)) - 3D))), ((V)(0D)), ((V)(3D)), (NumTruthy((i_567 % 2D)) ? rc_566 : ((V)((SEqS(k_532, "royal") ? "#7a1e2c" : "#e2554a")))), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("zb", ((V)(100D))).V));
i_567++;
}
}
Invoke(o_543, "push", Call(disc_16, V.Undef, ((V)(0D)), ((V)(cy_533)), ((V)((-4D))), ((V)(17D)), ((V)(4D)), rc_566), Call(D__42, V.Undef, ((V)(0D)), ((V)(cy_533)), ((V)(14D)), ((V)(1D)), ((V)((SEqS(k_532, "royal") ? "#f4f1ea" : "#5cc8c0")))));
} else {
V rim_571 = default;
rim_571 = (SEqS(k_532, "junk") ? TIN_27 : (SEqS(k_532, "mod") ? DK_26 : ((V)("#c98d52"))));
Invoke(o_543, "push", Call(disc_16, V.Undef, ((V)(0D)), ((V)(cy_533)), ((V)((-4D))), ((V)(R_534)), ((V)(4D)), rim_571), Call(D__42, V.Undef, ((V)(0D)), ((V)(cy_533)), ((V)((R_534 - 3D))), ((V)(1D)), (SEqS(k_532, "candy") ? ((V)("#d9a066")) : (SEqS(k_532, "mod") ? WH_25 : ((V)("#f3ead2"))))));
if (SEqS(k_532, "candy")) {
Invoke(o_543, "push", Call(A__45, V.Undef, ((V)(0D)), ((V)(cy_533)), ((V)((R_534 - 2D))), ((V)(3.4)), ((V)(0D)), ((V)((PI_38 * 2D))), ((V)(2D)), Get(P_541, "a")));
Invoke(Arr(Arr(((V)((-8D))), ((V)(6D))), Arr(((V)(9D)), ((V)(4D))), Arr(((V)((-4D))), ((V)((-9D)))), Arr(((V)(8D)), ((V)((-8D)))), Arr(((V)((-11D))), ((V)((-3D))))), "forEach", Fn((V _arrowThis583, int _argc572, V _a574, V _a575, V _a576, V _a577, V[] _rest573) => {
V x_580 = default;
V y_582 = default;
{ V _t578 = ListOf(_a574);
{ V _t579 = GetIdx(_t578, 0D);
x_580 = _t579; }
{ V _t581 = GetIdx(_t578, 1D);
y_582 = _t581; }
}
return Invoke(o_543, "push", Call(D__42, V.Undef, x_580, Add(((V)(cy_533)), y_582), ((V)(1.8)), ((V)(2D)), ((V)("#6b3f22"))));
}, 1, "", true));
InvokeSpread(o_543, "push", new ArrBuilder().Spread(Call(spr_36, V.Undef, ((V)(0D)), ((V)((cy_533 + R_534))), ((V)(1D)), ((V)(R_534)), ((V)(1D)), ((V)(5D)))).V);
}
if (SEqS(k_532, "junk")) {
Invoke(o_543, "push", Call(bar_47, V.Undef, ((V)((-10D))), ((V)((cy_533 + 14D))), ((V)((-2D))), ((V)((cy_533 + 4D))), ((V)(0.8)), ((V)(2D)), ((V)("#8a8f94"))), Call(ball_14, V.Undef, ((V)(0D)), ((V)(((cy_533 + R_534) - 2D))), ((V)(0D)), ((V)(3D)), TIN_27, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}
}
}
{
double i_584 = 0;
i_584 = 0D;
while (true) {
if (!((i_584 < 12D))) break;
double a_586 = 0;
double rr_587 = 0;
a_586 = (((i_584 / 12D) * PI_38) * 2D);
rr_587 = ((SEqS(k_532, "retro") || SEqS(k_532, "royal")) ? 11D : (R_534 - 6.5));
Invoke(o_543, "push", (Truthy(((SEqS(k_532, "mod") ? V.True : V.False) is var _t588 && !Truthy(_t588) ? _t588 : ((V)((i_584 % 3D))))) ? V.Null : Call(D__42, V.Undef, ((V)((FdLibm.Cos(a_586) * rr_587))), ((V)((cy_533 + (FdLibm.Sin(a_586) * rr_587)))), ((V)((NumTruthy((i_584 % 3D)) ? 0.9 : 1.5))), ((V)(2D)), INK_29)));
i_584++;
}
}
InvokeSpread(o_543, "push", new ArrBuilder().Spread(Call(handsAt_54, V.Undef, ((V)(cy_533)), ((V)(((SEqS(k_532, "retro") || SEqS(k_532, "royal")) ? 14D : (R_534 - 3D)))), ((V)(3D)))).V);
return Invoke(o_543, "filter", G("Boolean"));
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true);
wallShelf_56 = Fn((V _arrowThis596, int _argc589, V S_595, V _a592, V _a593, V _a594, V[] _rest590) => {
return NewObj(6).Put("w", ((V)(98D))).Put("d", ((V)(26D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(46D))).Put("top", ((V)(19D))).Put("build", Fn((V _arrowThis604, int _argc597, V P_603, V _a600, V _a601, V _a602, V[] _rest598) => {
V k_605 = default;
V c_606 = default;
V o_607 = default;
k_605 = Get(S_595, "k");
c_606 = (SEqS(k_605, "junk") ? OLD_28 : (SEqS(k_605, "cot") ? Get(P_603, "w") : (SEqS(k_605, "retro") ? CH_23 : (SEqS(k_605, "mod") ? ((V)("#e0bb86")) : (SEqS(k_605, "candy") ? Get(P_603, "a") : ((V)("#f4f1ea")))))));
o_607 = Arr();
if (SEqS(k_605, "candy")) {
{
double i_608 = 0;
i_608 = 0D;
while (true) {
if (!((i_608 < 6D))) break;
Invoke(o_607, "push", Call(ball_14, V.Undef, ((V)(((-40D) + (i_608 * 16D)))), ((V)((8D + ((i_608 % 2D) * 2D)))), ((V)(0D)), ((V)(10D)), (NumTruthy((i_608 % 2D)) ? WH_25 : Get(P_603, "aL")), NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V));
i_608++;
}
}
Invoke(o_607, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(96D)), ((V)(5D)), ((V)(24D)), WH_25, NewObj(1).Put("r", ((V)(8D))).V));
return o_607;
}
Invoke(o_607, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(94D)), ((V)((SEqS(k_605, "mod") ? 6D : 5D))), ((V)(24D)), c_606, NewObj(2).Put("r", ((V)((SEqS(k_605, "retro") ? 6D : 2D)))).Put("bev", ((V)(1D))).V));
if (!SEqS(k_605, "mod")) {
Invoke(Arr(((V)((-34D))), ((V)(34D))), "forEach", Fn((V _arrowThis617, int _argc610, V x_616, V _a613, V _a614, V _a615, V[] _rest611) => {
return Invoke(o_607, "push", Call(prism_17, V.Undef, ((V)((ToNum(x_616) - 1.6))), Add(x_616, ((V)(1.6))), Arr(Arr(((V)((-12D))), ((V)(14D))), Arr(((V)(8D)), ((V)(14D))), Arr(((V)((-12D))), ((V)((SEqS(k_605, "royal") ? (-4D) : 0D))))), (SEqS(k_605, "royal") ? GOLD_22 : (SEqS(k_605, "retro") ? CH_23 : (SEqS(k_605, "junk") ? ((V)("#8a8f94")) : Call(shade_19, V.Undef, c_606, ((V)(0.8))))))));
}, 1, "", true));
}
if (SEqS(k_605, "royal")) {
Invoke(o_607, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(13D)), ((V)(0D)), ((V)(98D)), ((V)(2D)), ((V)(26D)), GOLD_22, NewObj(1).Put("r", ((V)(3D))).V), Call(jewel_35, V.Undef, ((V)(0D)), ((V)(15D)), ((V)(12D)), ((V)(2.6))));
}
if (SEqS(k_605, "cot")) {
{
double i_618 = 0;
i_618 = 0D;
while (true) {
if (!((i_618 < 9D))) break;
Invoke(o_607, "push", Call(D__42, V.Undef, ((V)(((-40D) + (i_618 * 10D)))), ((V)(11.5)), ((V)(2.6)), ((V)(((12D * 2D) + 1D))), Call(shade_19, V.Undef, c_606, ((V)(0.9)))));
i_618++;
}
}
}
return o_607;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
glass_57 = Fn((V _arrowThis632, int _argc620, V o_626, V x_627, V y_628, V a_629, V[] _rest621) => {
V b_630 = default;
V n_631 = default;
b_630 = (_argc620 > 4 ? _rest621[0] : V.Undef);
n_631 = (_argc620 > 5 ? _rest621[1] : V.Undef);
Invoke(o_626, "push", Call(E__43, V.Undef, x_627, y_628, a_629, b_630, n_631, GL_39, NewObj(1).Put("emit", ((V)(1D))).V), Call(bar_47, V.Undef, ((V)((ToNum(x_627) - (ToNum(a_629) * 0.5)))), ((V)((ToNum(y_628) - (ToNum(b_630) * 0.1)))), ((V)((ToNum(x_627) - (ToNum(a_629) * 0.05)))), Add(y_628, ((V)((ToNum(b_630) * 0.55)))), ((V)(Max(2D, (ToNum(a_629) * 0.14)))), Add(n_631, ((V)(1D))), WH_25), Call(bar_47, V.Undef, ((V)((ToNum(x_627) - (ToNum(a_629) * 0.15)))), ((V)((ToNum(y_628) - (ToNum(b_630) * 0.35)))), Add(x_627, ((V)((ToNum(a_629) * 0.18)))), Add(y_628, ((V)((ToNum(b_630) * 0.2)))), ((V)(Max(1.2, (ToNum(a_629) * 0.07)))), Add(n_631, ((V)(1D))), WH_25));
return o_626;
return default;
}, 6, "", true);
mirror_58 = Fn((V _arrowThis640, int _argc633, V S_639, V _a636, V _a637, V _a638, V[] _rest634) => {
V k_641 = default;
k_641 = Get(S_639, "k");
return NewObj(5).Put("w", ((V)((SEqS(k_641, "retro") ? 80D : 60D)))).Put("d", ((V)(8D))).Put("mount", ((V)("wall"))).Put("elev", ((V)((SEqS(k_641, "mod") ? 16D : 36D)))).Put("build", Fn((V _arrowThis649, int _argc642, V P_648, V _a645, V _a646, V _a647, V[] _rest643) => {
V o_650 = default;
o_650 = Arr();
if (SEqS(k_641, "junk")) {
Invoke(o_650, "push", Call(disc_16, V.Undef, ((V)(0D)), ((V)(26D)), ((V)((-4D))), ((V)(24D)), ((V)(4D)), TIN_27));
Call(glass_57, V.Undef, o_650, ((V)(0D)), ((V)(26D)), ((V)(21D)), ((V)(21D)), ((V)(1D)));
Invoke(o_650, "push", Call(bar_47, V.Undef, ((V)((-6D))), ((V)(40D)), ((V)(4D)), ((V)(22D)), ((V)(0.9)), ((V)(3D)), ((V)("#7a8a94"))), Call(bar_47, V.Undef, ((V)(4D)), ((V)(22D)), ((V)((-2D))), ((V)(12D)), ((V)(0.9)), ((V)(3D)), ((V)("#7a8a94"))), Call(P__41, V.Undef, ((V)(14D)), ((V)(38D)), ((V)(12D)), ((V)(4D)), ((V)(4D)), ((V)("#f6e7a8")), NewObj(1).Put("r", ((V)(1D))).V));
return o_650;
}
if (SEqS(k_641, "cot")) {
Invoke(o_650, "push", Call(solid_11, V.Undef, NewObj(8).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(32D)))).Put("a", ((V)(24D))).Put("b", ((V)(32D))).Put("n", ((V)(22D))).Put("rings", Arr(Arr(((V)((-4D))), ((V)(0D))), Arr(((V)(0D)), ((V)(0D))))).Put("col", Get(P_648, "w")).V));
Call(glass_57, V.Undef, o_650, ((V)(0D)), ((V)(32D)), ((V)(19D)), ((V)(27D)), ((V)(1D)));
Invoke(o_650, "push", Call(D__42, V.Undef, ((V)(0D)), ((V)(66D)), ((V)(3.4)), ((V)(2D)), Get(P_648, "b")));
return o_650;
}
if (SEqS(k_641, "retro")) {
Invoke(o_650, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-2D))), ((V)(76D)), ((V)(64D)), ((V)(4D)), CH_23, NewObj(1).Put("r", ((V)(12D))).V), Call(P__41, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(60D)), ((V)(52D)), ((V)(1D)), GL_39, NewObj(2).Put("r", ((V)(8D))).Put("emit", ((V)(1D))).V), Call(bar_47, V.Undef, ((V)((-20D))), ((V)(14D)), ((V)((-6D))), ((V)(48D)), ((V)(5D)), ((V)(2D)), WH_25), Call(bar_47, V.Undef, ((V)((-6D))), ((V)(16D)), ((V)(2D)), ((V)(34D)), ((V)(2.4)), ((V)(2D)), WH_25));
{
double i_651 = 0;
i_651 = 0D;
while (true) {
if (!((i_651 < 12D))) break;
double p_653 = 0;
double x_654 = 0;
double y_655 = 0;
p_653 = (i_651 / 12D);
x_654 = ((p_653 < 0.25) ? (-34D) : ((p_653 < 0.5) ? ((-30D) + (((p_653 - 0.25) * 4D) * 60D)) : ((p_653 < 0.75) ? 34D : (30D - (((p_653 - 0.75) * 4D) * 60D)))));
y_655 = ((p_653 < 0.25) ? (6D + ((p_653 * 4D) * 52D)) : ((p_653 < 0.5) ? 60D : ((p_653 < 0.75) ? (60D - (((p_653 - 0.5) * 4D) * 52D)) : 3D)));
Invoke(o_650, "push", Call(ball_14, V.Undef, ((V)(x_654)), ((V)((y_655 - 3D))), ((V)(1D)), ((V)(3.2)), ((V)("#fff3c4")), NewObj(4).Put("emit", ((V)(1D))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("zb", ((V)(600D))).V));
i_651++;
}
}
return o_650;
}
if (SEqS(k_641, "mod")) {
Invoke(o_650, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-2D))), ((V)(46D)), ((V)(96D)), ((V)(4D)), DK_26, NewObj(1).Put("r", ((V)(22D))).V), Call(P__41, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(40D)), ((V)(90D)), ((V)(1D)), GL_39, NewObj(2).Put("r", ((V)(19D))).Put("emit", ((V)(1D))).V), Call(bar_47, V.Undef, ((V)((-12D))), ((V)(16D)), ((V)(0D)), ((V)(70D)), ((V)(4D)), ((V)(2D)), WH_25), Call(bar_47, V.Undef, ((V)((-2D))), ((V)(30D)), ((V)(6D)), ((V)(52D)), ((V)(2D)), ((V)(2D)), WH_25));
return o_650;
}
if (SEqS(k_641, "candy")) {
{
double i_656 = 0;
i_656 = 0D;
while (true) {
if (!((i_656 < 10D))) break;
double a_658 = 0;
a_658 = (((i_656 / 10D) * PI_38) * 2D);
Invoke(o_650, "push", Call(ball_14, V.Undef, ((V)((FdLibm.Cos(a_658) * 24D))), ((V)(((30D + (FdLibm.Sin(a_658) * 24D)) - 8D))), ((V)((-1D))), ((V)(9D)), (NumTruthy((i_656 % 2D)) ? WH_25 : Get(P_648, "aL")), NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V));
i_656++;
}
}
Call(glass_57, V.Undef, o_650, ((V)(0D)), ((V)(30D)), ((V)(20D)), ((V)(20D)), ((V)(3D)));
return o_650;
}
Invoke(o_650, "push", Call(solid_11, V.Undef, NewObj(8).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(32D)))).Put("a", ((V)(26D))).Put("b", ((V)(34D))).Put("n", ((V)(22D))).Put("rings", Arr(Arr(((V)((-4D))), ((V)(0D))), Arr(((V)(0D)), ((V)(0D))))).Put("col", GOLD_22).V));
Call(glass_57, V.Undef, o_650, ((V)(0D)), ((V)(32D)), ((V)(20D)), ((V)(28D)), ((V)(1D)));
Invoke(o_650, "push", Call(T__44, V.Undef, Arr(Arr(((V)((-12D))), ((V)(64D))), Arr(((V)((-12D))), ((V)(76D))), Arr(((V)((-6D))), ((V)(70D))), Arr(((V)(0D)), ((V)(80D))), Arr(((V)(6D)), ((V)(70D))), Arr(((V)(12D)), ((V)(76D))), Arr(((V)(12D)), ((V)(64D)))), ((V)(2D)), GOLD_22), Call(D__42, V.Undef, ((V)(0D)), ((V)(72D)), ((V)(2.6)), ((V)(3D)), ((V)("#7a1e2c"))), Call(D__42, V.Undef, ((V)((-26D))), ((V)(32D)), ((V)(3D)), ((V)(2D)), ((V)("#7a1e2c"))), Call(D__42, V.Undef, ((V)(26D)), ((V)(32D)), ((V)(3D)), ((V)(2D)), ((V)("#7a1e2c"))));
return o_650;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true);
BC_59 = Arr(((V)("#e2554a")), ((V)("#4a6fd6")), ((V)("#ffd23f")), ((V)("#7fc66a")), ((V)("#8f7bff")), ((V)("#ffa940")), ((V)("#5cc8c0")), ((V)("#f4f1ea")));
books_60 = Fn((V _arrowThis673, int _argc659, V o_665, V x0_666, V x1_667, V y_668, V[] _rest660) => {
V x_674 = default;
V z_669 = default;
V hMax_670 = default;
V r_671 = default;
V cols_672 = default;
z_669 = (_argc659 > 4 ? _rest660[0] : V.Undef);
hMax_670 = (_argc659 > 5 ? _rest660[1] : V.Undef);
r_671 = (_argc659 > 6 ? _rest660[2] : V.Undef);
cols_672 = (_argc659 > 7 ? _rest660[3] : V.Undef);
x_674 = x0_666;
while (LtN(x_674, (ToNum(x1_667) - 4D))) {
double w_675 = 0;
double h_676 = 0;
w_675 = (4D + System.Math.Floor((ToNum(Call(r_671, V.Undef)) * 5D)));
h_676 = (ToNum(hMax_670) * (0.72 + (ToNum(Call(r_671, V.Undef)) * 0.28)));
if (Gt(Add(x_674, ((V)(w_675))), x1_667)) {
break;
}
if ((LtN(Call(r_671, V.Undef), 0.12) && Lt(Add(x_674, ((V)(12D))), x1_667))) {
Invoke(o_665, "push", Call(box_12, V.Undef, Add(x_674, ((V)(6D))), y_668, z_669, ((V)(12D)), ((V)(5D)), ((V)((h_676 * 0.7))), GetIdx(cols_672, System.Math.Floor((ToNum(Call(r_671, V.Undef)) * ToNum(Get(cols_672, "length"))))), NewObj(1).Put("r", ((V)(1D))).V));
x_674 = Add(x_674, ((V)(14D)));
continue;
}
Invoke(o_665, "push", Call(box_12, V.Undef, Add(x_674, ((V)((w_675 / 2D)))), y_668, z_669, ((V)(w_675)), ((V)(h_676)), ((V)(18D)), GetIdx(cols_672, System.Math.Floor((ToNum(Call(r_671, V.Undef)) * ToNum(Get(cols_672, "length"))))), NewObj(1).Put("r", ((V)(1D))).V));
x_674 = Add(x_674, ((V)((w_675 + 0.6))));
}
return default;
}, 8, "", true);
bookcase_61 = Fn((V _arrowThis684, int _argc677, V S_683, V _a680, V _a681, V _a682, V[] _rest678) => {
V k_685 = default;
double Hh_686 = 0;
double W_687 = 0;
k_685 = Get(S_683, "k");
Hh_686 = (SEqS(k_685, "royal") ? 166D : (SEqS(k_685, "mod") ? 132D : 150D));
W_687 = (SEqS(k_685, "mod") ? 120D : 96D);
return NewObj(4).Put("w", ((V)((W_687 + 8D)))).Put("d", ((V)(36D))).Put("top", ((V)((Hh_686 + 1D)))).Put("build", Fn((V _arrowThis695, int _argc688, V P_694, V _a691, V _a692, V _a693, V[] _rest689) => {
V c_696 = default;
V r_697 = default;
V cols_698 = default;
V o_699 = default;
double n_700 = 0;
double gap_701 = 0;
c_696 = (SEqS(k_685, "junk") ? OLD_28 : (SEqS(k_685, "cot") ? Get(P_694, "w") : (SEqS(k_685, "retro") ? Get(P_694, "a") : (SEqS(k_685, "mod") ? ((V)("#e0bb86")) : (SEqS(k_685, "candy") ? Get(P_694, "a") : ((V)("#f4f1ea")))))));
r_697 = Call(rnd_48, V.Undef, ((V)((7D + Hh_686))));
cols_698 = (SEqS(k_685, "candy") ? Invoke(NE_21, "concat", Arr(WH_25)) : (SEqS(k_685, "royal") ? Arr(((V)("#7a1e2c")), ((V)("#1f5a44")), ((V)("#4b2763")), GOLD_22, ((V)("#f3ead6"))) : BC_59));
o_699 = Arr();
if (SEqS(k_685, "mod")) {
Invoke(o_699, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-15D))), ((V)(W_687)), ((V)(Hh_686)), ((V)(4D)), Call(shade_19, V.Undef, c_696, ((V)(0.88)))));
{
double i_702 = 0;
i_702 = 0D;
while (true) {
if (!((i_702 <= 3D))) break;
Invoke(o_699, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(((i_702 * (Hh_686 - 4D)) / 3D))), ((V)(0D)), ((V)(W_687)), ((V)(4D)), ((V)(32D)), c_696, NewObj(1).Put("r", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(((((-W_687) / 2D) + 2D) + ((i_702 * (W_687 - 4D)) / 3D)))), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(Hh_686)), ((V)(32D)), c_696));
i_702++;
}
}
Invoke(Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2D)), ((V)(1D))), Arr(((V)(1D)), ((V)(2D)))), "forEach", Fn((V _arrowThis715, int _argc704, V _a706, V _a707, V _a708, V _a709, V[] _rest705) => {
V a_712 = default;
V b_714 = default;
{ V _t710 = ListOf(_a706);
{ V _t711 = GetIdx(_t710, 0D);
a_712 = _t711; }
{ V _t713 = GetIdx(_t710, 1D);
b_714 = _t713; }
}
return Call(books_60, V.Undef, o_699, ((V)(((((-W_687) / 2D) + 6D) + ((ToNum(a_712) * (W_687 - 4D)) / 3D)))), ((V)((((-W_687) / 2D) + ((ToNum(Add(a_712, ((V)(1D)))) * (W_687 - 4D)) / 3D)))), ((V)((4D + ((ToNum(b_714) * (Hh_686 - 4D)) / 3D)))), ((V)(2D)), ((V)(30D)), r_697, Arr(((V)("#c46a4a")), ((V)("#d9d5cd")), ((V)("#2c2d31")), WH_25, ((V)("#8e9a84"))));
}, 1, "", true));
Invoke(o_699, "push", Call(ball_14, V.Undef, ((V)(((((-W_687) / 2D) + 2D) + ((W_687 - 4D) / 6D)))), ((V)((4D + ((Hh_686 - 4D) / 3D)))), ((V)(0D)), ((V)(9D)), ((V)("#d8d4cc")), NewObj(1).Put("sy", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(((((-W_687) / 2D) + 2D) + ((W_687 - 4D) / 6D)))), ((V)((20D + ((Hh_686 - 4D) / 3D)))), ((V)(0D)), ((V)(9D)), LEAF_30, NewObj(1).Put("sy", ((V)(0.8))).V), Call(ball_14, V.Undef, ((V)(((W_687 / 2D) - ((W_687 - 4D) / 6D)))), ((V)(4D)), ((V)(0D)), ((V)(10D)), ((V)("#e8b04a")), NewObj(1).Put("sy", ((V)(0.9))).V));
return o_699;
}
Invoke(o_699, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-15D))), ((V)(W_687)), ((V)(Hh_686)), ((V)(4D)), Call(shade_19, V.Undef, c_696, ((V)(0.85)))), Call(box_12, V.Undef, ((V)((((-W_687) / 2D) - 2D))), ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(Hh_686)), ((V)(34D)), c_696, NewObj(1).Put("r", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(((W_687 / 2D) + 2D))), ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(Hh_686)), ((V)(34D)), c_696, NewObj(1).Put("r", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)((Hh_686 - 5D))), ((V)(0D)), ((V)((W_687 + 10D))), ((V)(6D)), ((V)(36D)), c_696, NewObj(2).Put("r", ((V)(2D))).Put("bev", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((W_687 + 8D))), ((V)(8D)), ((V)(34D)), Call(shade_19, V.Undef, c_696, ((V)(0.9))), NewObj(1).Put("r", ((V)(1D))).V));
n_700 = 4D;
gap_701 = ((Hh_686 - 13D) / n_700);
{
double i_716 = 0;
i_716 = 0D;
while (true) {
if (!((i_716 < n_700))) break;
double y_718 = 0;
y_718 = (8D + (i_716 * gap_701));
if (NumTruthy(i_716)) {
Invoke(o_699, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((y_718 - 3D))), ((V)(0D)), ((V)(W_687)), ((V)(3D)), ((V)(32D)), c_696));
}
Call(books_60, V.Undef, o_699, ((V)((((-W_687) / 2D) + 2D))), ((V)(((W_687 / 2D) - 2D))), ((V)(y_718)), ((V)(2D)), ((V)((gap_701 - 8D))), r_697, cols_698);
i_716++;
}
}
if (SEqS(k_685, "junk")) {
Invoke(o_699, "push", Call(box_12, V.Undef, ((V)((-20D))), ((V)((Hh_686 + 1D))), ((V)(2D)), ((V)(14D)), ((V)(10D)), ((V)(1D)), ((V)("#c9a85a")), NewObj(1).Put("r", ((V)(1D))).V));
}
if (SEqS(k_685, "cot")) {
{
double i_719 = 0;
i_719 = 0D;
while (true) {
if (!((i_719 < 7D))) break;
Invoke(o_699, "push", Call(D__42, V.Undef, ((V)(((((-W_687) / 2D) + 8D) + ((i_719 * (W_687 - 16D)) / 6D)))), ((V)((Hh_686 - 9D))), ((V)(3D)), ((V)(37D)), Call(shade_19, V.Undef, c_696, ((V)(0.92)))));
i_719++;
}
}
}
if (SEqS(k_685, "retro")) {
Invoke(o_699, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(Hh_686)), ((V)(0D)), ((V)((W_687 + 12D))), ((V)(3D)), ((V)(38D)), CH_23, NewObj(1).Put("r", ((V)(4D))).V));
}
if (SEqS(k_685, "candy")) {
InvokeSpread(o_699, "push", new ArrBuilder().Spread(Call(drips_37, V.Undef, ((V)(0D)), ((V)(Hh_686)), ((V)(18D)), ((V)(W_687)), Get(P_694, "b"), ((V)(6D)))).Spread(Call(spr_36, V.Undef, ((V)(0D)), ((V)((Hh_686 + 1D))), ((V)(0D)), ((V)((W_687 - 10D))), ((V)(26D)), ((V)(7D)))).V);
}
if (SEqS(k_685, "royal")) {
Invoke(o_699, "push", Call(prismZ_18, V.Undef, ((V)((-4D))), ((V)(4D)), Arr(Arr(((V)((-30D))), ((V)(Hh_686))), Arr(((V)((-20D))), ((V)((Hh_686 + 14D)))), Arr(((V)((-8D))), ((V)((Hh_686 + 6D)))), Arr(((V)(0D)), ((V)((Hh_686 + 20D)))), Arr(((V)(8D)), ((V)((Hh_686 + 6D)))), Arr(((V)(20D)), ((V)((Hh_686 + 14D)))), Arr(((V)(30D)), ((V)(Hh_686)))), GOLD_22), Call(jewel_35, V.Undef, ((V)(0D)), ((V)((Hh_686 + 20D))), ((V)(0D)), ((V)(4D))), Call(box_12, V.Undef, ((V)(0D)), ((V)((Hh_686 - 6D))), ((V)(0D)), ((V)((W_687 + 12D))), ((V)(2D)), ((V)(38D)), GOLD_22, NewObj(1).Put("r", ((V)(2D))).V));
}
return o_699;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true);
lowShelf_62 = Fn((V _arrowThis728, int _argc721, V S_727, V _a724, V _a725, V _a726, V[] _rest722) => {
return NewObj(4).Put("w", ((V)(128D))).Put("d", ((V)(40D))).Put("top", ((V)(56D))).Put("build", Fn((V _arrowThis736, int _argc729, V P_735, V _a732, V _a733, V _a734, V[] _rest730) => {
V k_737 = default;
V c_738 = default;
V o_739 = default;
k_737 = Get(S_727, "k");
c_738 = (SEqS(k_737, "cot") ? Get(P_735, "w") : (SEqS(k_737, "mod") ? ((V)("#e9e5dc")) : (SEqS(k_737, "candy") ? WH_25 : Get(P_735, "w"))));
o_739 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(124D)), ((V)(56D)), ((V)(38D)), c_738, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(2D))).V));
{
double i_740 = 0;
i_740 = 0D;
while (true) {
if (!((i_740 < 4D))) break;
{
double j_742 = 0;
j_742 = 0D;
while (true) {
if (!((j_742 < 2D))) break;
double x_744 = 0;
double y_745 = 0;
x_744 = ((-45D) + (i_740 * 30D));
y_745 = (5D + (j_742 * 25D));
Invoke(o_739, "push", Call(box_12, V.Undef, ((V)(x_744)), ((V)(y_745)), ((V)(17.4)), ((V)(26D)), ((V)(21D)), ((V)(1D)), Call(shade_19, V.Undef, c_738, ((V)(0.72))), NewObj(1).Put("r", ((V)(2D))).V));
if (NumTruthy(((i_740 + j_742) % 2D))) {
Invoke(o_739, "push", Call(box_12, V.Undef, ((V)(x_744)), ((V)(y_745)), ((V)(14.4)), ((V)(24D)), ((V)(16D)), ((V)(9D)), (SEqS(k_737, "candy") ? GetIdx(NE_21, ((i_740 + (j_742 * 4D)) % 6D)) : GetIdx(Arr(Get(P_735, "a"), Get(P_735, "b"), ((V)("#7fc66a")), ((V)("#ffa940"))), ((i_740 + j_742) % 4D))), NewObj(1).Put("r", ((V)(3D))).V), Call(box_12, V.Undef, ((V)(x_744)), ((V)((y_745 + 10D))), ((V)(19.2)), ((V)(10D)), ((V)(3D)), ((V)(0.6)), WH_25, NewObj(1).Put("r", ((V)(1D))).V));
} else {
Invoke(o_739, "push", Call(ball_14, V.Undef, ((V)((x_744 - 4D))), ((V)(y_745)), ((V)(12D)), ((V)(6D)), GetIdx(NE_21, (((i_740 * 2D) + j_742) % 6D)), NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V), Call(box_12, V.Undef, ((V)((x_744 + 6D))), ((V)(y_745)), ((V)(12D)), ((V)(8D)), ((V)(8D)), ((V)(8D)), GetIdx(RB6_32, ((i_740 + (j_742 * 3D)) % 6D)), NewObj(1).Put("r", ((V)(1D))).V));
}
j_742++;
}
}
i_740++;
}
}
if (SEqS(k_737, "candy")) {
InvokeSpread(o_739, "push", new ArrBuilder().Spread(Call(drips_37, V.Undef, ((V)(0D)), ((V)(56D)), ((V)(19D)), ((V)(110D)), Get(P_735, "a"), ((V)(7D)))).V);
}
return o_739;
return default;
}, 1, "build", true)).V;
}, 1, "", true);
T_63 = Fn((V _arrowThis757, int _argc746, V w_752, V d_753, V b_754, V _a751, V[] _rest747) => {
V o_756 = default;
{ V _t755 = _a751; if (_t755.IsUndef) _t755 = NewObj(0).V;
o_756 = _t755; }
return Object_assign(NewObj(5).Put("w", w_752).Put("d", d_753).Put("small", ((V)(1D))).Put("round", ((V)(1D))).Put("build", b_754).V, o_756);
}, 4, "", true);
vaseFlw_64 = Fn((V _arrowThis767, int _argc758, V o_764, V y_765, V cols_766, V _a763, V[] _rest759) => {
return Invoke(Arr(Arr(((V)((-5D))), ((V)(12D)), ((V)(2D))), Arr(((V)(5D)), ((V)(14D)), ((V)((-2D)))), Arr(((V)(0D)), ((V)(18D)), ((V)(3D)))), "forEach", Fn((V _arrowThis782, int _argc768, V _a770, V i_774, V _a772, V _a773, V[] _rest769) => {
V x_777 = default;
V h_779 = default;
V z_781 = default;
{ V _t775 = ListOf(_a770);
{ V _t776 = GetIdx(_t775, 0D);
x_777 = _t776; }
{ V _t778 = GetIdx(_t775, 1D);
h_779 = _t778; }
{ V _t780 = GetIdx(_t775, 2D);
z_781 = _t780; }
}
return Invoke(o_764, "push", Call(cyl_13, V.Undef, ((V)((ToNum(x_777) * 0.4))), y_765, ((V)((ToNum(z_781) * 0.4))), ((V)(0.9)), h_779, ((V)("#4a8a46")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_14, V.Undef, x_777, Add(y_765, h_779), z_781, ((V)(4D)), GetIdx(cols_766, (ToNum(i_774) % ToNum(Get(cols_766, "length")))), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, x_777, Add(Add(y_765, h_779), ((V)(1D))), Add(z_781, ((V)(2D))), ((V)(1.6)), ((V)("#ffd23f")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
}, 2, "", true));
}, 3, "", true);
tbVase_65 = Fn((V _arrowThis790, int _argc783, V S_789, V _a786, V _a787, V _a788, V[] _rest784) => {
return Call(T_63, V.Undef, ((V)(26D)), ((V)(26D)), Fn((V _arrowThis798, int _argc791, V P_797, V _a794, V _a795, V _a796, V[] _rest792) => {
V k_799 = default;
V o_800 = default;
k_799 = Get(S_789, "k");
o_800 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(8D)), ((V)(22D)), (SEqS(k_799, "royal") ? ((V)("#f4f1ea")) : Get(P_797, "a")), NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))), Arr(((V)(18D)), ((V)(0D)), ((V)(0.5))), Arr(((V)(22D)), ((V)(0D)), ((V)(0.7))))).V));
if (SEqS(k_799, "royal")) {
Invoke(o_800, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(8.2)), ((V)(3D)), ((V)("#7a1e2c")), NewObj(1).Put("n", ((V)(14D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(0D)), ((V)(4.4)), ((V)(2D)), GOLD_22, NewObj(1).Put("n", ((V)(12D))).V));
}
Call(vaseFlw_64, V.Undef, o_800, ((V)(20D)), (SEqS(k_799, "royal") ? Arr(((V)("#7a1e2c")), WH_25, ((V)("#e2b14a"))) : Arr(Get(P_797, "b"), ((V)("#ffa940")), ((V)("#e2554a")))));
return o_800;
return default;
}, 1, "", true));
}, 1, "", true);
tbBooks_66 = Fn((V _arrowThis808, int _argc801, V S_807, V _a804, V _a805, V _a806, V[] _rest802) => {
return Call(T_63, V.Undef, ((V)(32D)), ((V)(24D)), Fn((V _arrowThis816, int _argc809, V P_815, V _a812, V _a813, V _a814, V[] _rest810) => {
V c_817 = default;
c_817 = (SEqS(Get(S_807, "k"), "royal") ? Arr(((V)("#7a2a3a")), ((V)("#2f6a4a")), ((V)("#7a1e2c"))) : Arr(Get(P_815, "a"), Get(P_815, "b"), ((V)("#ffa940"))));
return new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(28D)), ((V)(5D)), ((V)(20D)), GetIdx(c_817, 0D), NewObj(1).Put("r", ((V)(1D))).V)).Add(Call(box_12, V.Undef, ((V)(1D)), ((V)(5D)), ((V)(0D)), ((V)(26D)), ((V)(5D)), ((V)(19D)), GetIdx(c_817, 1D), NewObj(1).Put("r", ((V)(1D))).V)).Add(Call(box_12, V.Undef, ((V)((-1D))), ((V)(10D)), ((V)(0D)), ((V)(24D)), ((V)(4D)), ((V)(18D)), GetIdx(c_817, 2D), NewObj(1).Put("r", ((V)(1D))).V)).Spread((SEqS(Get(S_807, "k"), "royal") ? Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0.5)), ((V)(10.2)), ((V)(22D)), ((V)(4D)), ((V)(0.4)), GOLD_22), Call(box_12, V.Undef, ((V)(1D)), ((V)(5.5)), ((V)(9.7)), ((V)(20D)), ((V)(4D)), ((V)(0.4)), GOLD_22)) : Arr())).Add(Call(ball_14, V.Undef, ((V)(4D)), ((V)(14D)), ((V)(2D)), ((V)(4D)), Get(P_815, "b"), NewObj(1).Put("sy", ((V)(0.6))).V)).V;
return default;
}, 1, "", true), NewObj(1).Put("round", ((V)(0D))).V);
}, 1, "", true);
tbFruit_67 = Fn((V _arrowThis825, int _argc818, V S_824, V _a821, V _a822, V _a823, V[] _rest819) => {
return Call(T_63, V.Undef, ((V)(40D)), ((V)(40D)), Fn((V _arrowThis833, int _argc826, V P_832, V _a829, V _a830, V _a831, V[] _rest827) => {
V k_834 = default;
V o_835 = default;
k_834 = Get(S_824, "k");
o_835 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(7D)), ((V)(3D)), (SEqS(k_834, "mod") ? ((V)("#d8eef4")) : Get(P_832, "a")), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(18D)), ((V)(9D)), (SEqS(k_834, "mod") ? ((V)("#d8eef4")) : Get(P_832, "a")), NewObj(2).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.45))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.85))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V));
Invoke(Arr(Arr(((V)((-7D))), ((V)(0D)), ((V)("#e2554a"))), Arr(((V)(6D)), ((V)((-3D))), ((V)("#ffa940"))), Arr(((V)(0D)), ((V)(6D)), ((V)("#a6d65a"))), Arr(((V)((-2D))), ((V)((-6D))), ((V)("#ffd23f")))), "forEach", Fn((V _arrowThis849, int _argc836, V _a838, V _a839, V _a840, V _a841, V[] _rest837) => {
V x_844 = default;
V z_846 = default;
V c_848 = default;
{ V _t842 = ListOf(_a838);
{ V _t843 = GetIdx(_t842, 0D);
x_844 = _t843; }
{ V _t845 = GetIdx(_t842, 1D);
z_846 = _t845; }
{ V _t847 = GetIdx(_t842, 2D);
c_848 = _t847; }
}
return Invoke(o_835, "push", Call(ball_14, V.Undef, x_844, ((V)(7D)), z_846, ((V)(6D)), c_848, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V));
}, 1, "", true));
Invoke(o_835, "push", Call(ball_14, V.Undef, ((V)(2D)), ((V)(13D)), ((V)(0D)), ((V)(4D)), ((V)("#8f7bff")), NewObj(3).Put("sy", ((V)(1.4))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V), Call(cyl_13, V.Undef, ((V)((-7D))), ((V)(18D)), ((V)(0D)), ((V)(0.6)), ((V)(3D)), ((V)("#6b4a2a")), NewObj(1).Put("n", ((V)(4D))).V));
return o_835;
return default;
}, 1, "", true));
}, 1, "", true);
tbCake_68 = Fn((V _arrowThis857, int _argc850, V S_856, V _a853, V _a854, V _a855, V[] _rest851) => {
return Call(T_63, V.Undef, ((V)(40D)), ((V)(40D)), Fn((V _arrowThis865, int _argc858, V P_864, V _a861, V _a862, V _a863, V[] _rest859) => {
V k_866 = default;
V o_867 = default;
k_866 = Get(S_856, "k");
o_867 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(5D)), ((V)(12D)), (SEqS(k_866, "royal") ? GOLD_22 : CR_24), NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.4))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(12D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(18D)), ((V)(2D)), (SEqS(k_866, "royal") ? GOLD_22 : CR_24), NewObj(1).Put("n", ((V)(18D))).V));
if (SEqS(k_866, "candy")) {
Invoke(Arr(Arr(((V)((-8D))), ((V)(0D))), Arr(((V)(8D)), ((V)(0D))), Arr(((V)(0D)), ((V)(8D))), Arr(((V)(0D)), ((V)((-8D))))), "forEach", Fn((V _arrowThis880, int _argc868, V _a870, V i_874, V _a872, V _a873, V[] _rest869) => {
V x_877 = default;
V z_879 = default;
{ V _t875 = ListOf(_a870);
{ V _t876 = GetIdx(_t875, 0D);
x_877 = _t876; }
{ V _t878 = GetIdx(_t875, 1D);
z_879 = _t878; }
}
return Invoke(o_867, "push", Call(cyl_13, V.Undef, x_877, ((V)(14D)), z_879, ((V)(5D)), ((V)(5D)), ((V)("#d9a066")), NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))))).V), Call(ball_14, V.Undef, x_877, ((V)(18D)), z_879, ((V)(5.5)), GetK(NE_21, i_874), NewObj(3).Put("sy", ((V)(0.8))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V));
}, 2, "", true));
Invoke(o_867, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(5D)), ((V)(5D)), ((V)("#d9a066")), NewObj(1).Put("n", ((V)(10D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(6D)), GetIdx(NE_21, 4D), NewObj(1).Put("sy", ((V)(0.8))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(32D)), ((V)(0D)), ((V)(2.4)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
return o_867;
}
InvokeSpread(o_867, "push", new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(14D)), ((V)(10D)), ((V)("#f3d9a6")), NewObj(1).Put("n", ((V)(18D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(14.4)), ((V)(3D)), (SEqS(k_866, "retro") ? ((V)("#e2554a")) : Get(P_864, "b")), NewObj(1).Put("n", ((V)(18D))).V)).Spread(Call(drips_37, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(13D)), ((V)(20D)), (SEqS(k_866, "retro") ? ((V)("#e2554a")) : Get(P_864, "b")), ((V)(4D)))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(0D)), ((V)(9D)), ((V)(7D)), ((V)("#f3d9a6")), NewObj(1).Put("n", ((V)(16D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(9.4)), ((V)(2D)), CR_24, NewObj(1).Put("n", ((V)(16D))).V)).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(32D)), ((V)(0D)), ((V)(2.6)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).V);
if (SEqS(k_866, "royal")) {
Invoke(o_867, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(18.4)), ((V)(1.4)), ((V)("#7a1e2c")), NewObj(1).Put("n", ((V)(18D))).V), Call(jewel_35, V.Undef, ((V)(0D)), ((V)(35D)), ((V)(0D)), ((V)(3D))));
}
return o_867;
return default;
}, 1, "", true));
}, 1, "", true);
tbTeapot_69 = Fn((V _arrowThis888, int _argc881, V S_887, V _a884, V _a885, V _a886, V[] _rest882) => {
return Call(T_63, V.Undef, ((V)(36D)), ((V)(26D)), Fn((V _arrowThis896, int _argc889, V P_895, V _a892, V _a893, V _a894, V[] _rest890) => {
V k_897 = default;
V c_898 = default;
V o_899 = default;
k_897 = Get(S_887, "k");
c_898 = (SEqS(k_897, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_897, "junk") ? ((V)("#b7c9c4")) : Get(P_895, "a")));
o_899 = Arr(Call(ball_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(11D)), c_898, NewObj(1).Put("sy", ((V)(0.85))).V), Call(prism_17, V.Undef, ((V)(9D)), ((V)(18D)), Arr(Arr(((V)((-1.5))), ((V)(6D))), Arr(((V)(1.5)), ((V)(6D))), Arr(((V)(1D)), ((V)(16D))), Arr(((V)((-1D))), ((V)(16D)))), c_898), Call(solid_11, V.Undef, NewObj(11).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)((-11D))), ((V)(9D)))).Put("a", ((V)(6D))).Put("b", ((V)(6D))).Put("th", ((V)(2D))).Put("a0", ((V)((PI_38 * 0.5)))).Put("a1", ((V)((PI_38 * 1.5)))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)((-1.2))), ((V)(0D))), Arr(((V)(1.2)), ((V)(0D))))).Put("col", c_898).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(17D)), ((V)(0D)), ((V)(5D)), ((V)(2D)), c_898, NewObj(1).Put("n", ((V)(12D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(19D)), ((V)(0D)), ((V)(2.4)), (SEqS(k_897, "royal") ? GOLD_22 : Get(P_895, "b")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
if (SEqS(k_897, "royal")) {
Invoke(o_899, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(7D)), ((V)(0D)), ((V)(10.4)), ((V)(1.6)), GOLD_22, NewObj(1).Put("n", ((V)(16D))).V));
}
if (SEqS(k_897, "junk")) {
Invoke(o_899, "push", Call(D__42, V.Undef, ((V)(4D)), ((V)(6D)), ((V)(2D)), ((V)(25D)), ((V)("#8a9a96"))));
}
if (!SEqS(k_897, "junk")) {
Invoke(o_899, "push", Call(cyl_13, V.Undef, ((V)(14D)), ((V)(0D)), ((V)(8D)), ((V)(4D)), ((V)(5D)), c_898, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))))).V));
}
return o_899;
return default;
}, 1, "", true), NewObj(1).Put("round", ((V)(0D))).V);
}, 1, "", true);
tbToaster_70 = Fn((V _arrowThis907, int _argc900, V S_906, V _a903, V _a904, V _a905, V[] _rest901) => {
return Call(T_63, V.Undef, ((V)(34D)), ((V)(22D)), Fn((V _arrowThis916, int _argc908, V P_914, V v_915, V _a912, V _a913, V[] _rest909) => {
V k_917 = default;
V c_918 = default;
V o_919 = default;
k_917 = Get(S_906, "k");
c_918 = (SEqS(k_917, "junk") ? TIN_27 : (SEqS(k_917, "retro") ? CH_23 : Get(P_914, "a")));
o_919 = Arr(Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(20D)), ((V)(18D)), c_918, NewObj(1).Put("r", ((V)(8D))).V), Call(box_12, V.Undef, ((V)((-5D))), ((V)(20D)), ((V)(0D)), ((V)(4D)), ((V)(0.6)), ((V)(12D)), DK_26, NewObj(1).Put("r", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(5D)), ((V)(20D)), ((V)(0D)), ((V)(4D)), ((V)(0.6)), ((V)(12D)), DK_26, NewObj(1).Put("r", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(15.4)), ((V)(6D)), ((V)(0D)), ((V)(2D)), ((V)(8D)), ((V)(3D)), DK_26, NewObj(1).Put("r", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)((-14D))), ((V)(2D)), ((V)(9D)), ((V)(1.6)), DK_26, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V), Call(ball_14, V.Undef, ((V)(14D)), ((V)(2D)), ((V)(9D)), ((V)(1.6)), DK_26, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
Invoke(o_919, "push", Call(box_12, V.Undef, ((V)((-5D))), ((V)(14D)), ((V)(0D)), ((V)(3D)), ((V)(10D)), ((V)(11D)), ((V)("#e0a65a")), NewObj(1).Put("r", ((V)(2D))).V), Call(box_12, V.Undef, ((V)(5D)), ((V)(16D)), ((V)(0D)), ((V)(3D)), ((V)(10D)), ((V)(11D)), ((V)("#d0904a")), NewObj(1).Put("r", ((V)(2D))).V));
if (SEqS(k_917, "junk")) {
Invoke(o_919, "push", Call(D__42, V.Undef, ((V)((-6D))), ((V)(10D)), ((V)(2.4)), ((V)(19D)), ((V)("#8a8f94"))));
}
return o_919;
return default;
}, 2, "", true), NewObj(1).Put("round", ((V)(0D))).V);
}, 1, "", true);
tbMixer_71 = Fn((V _arrowThis927, int _argc920, V S_926, V _a923, V _a924, V _a925, V[] _rest921) => {
return Call(T_63, V.Undef, ((V)(38D)), ((V)(26D)), Fn((V _arrowThis935, int _argc928, V P_934, V _a931, V _a932, V _a933, V[] _rest929) => {
V c_936 = default;
c_936 = (SEqS(Get(S_926, "k"), "mod") ? ((V)("#6a707c")) : Get(P_934, "a"));
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(34D)), ((V)(4D)), ((V)(22D)), c_936, NewObj(1).Put("r", ((V)(5D))).V), Call(box_12, V.Undef, ((V)((-12D))), ((V)(4D)), ((V)(0D)), ((V)(10D)), ((V)(26D)), ((V)(14D)), c_936, NewObj(1).Put("r", ((V)(4D))).V), Call(ball_14, V.Undef, ((V)((-2D))), ((V)(26D)), ((V)(0D)), ((V)(9D)), c_936, NewObj(3).Put("sx", ((V)(2.1))).Put("sy", ((V)(0.7))).Put("sz", ((V)(0.9))).V), Call(cyl_13, V.Undef, ((V)(8D)), ((V)(4D)), ((V)(0D)), ((V)(9D)), ((V)(14D)), CH_23, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_13, V.Undef, ((V)(8D)), ((V)(18D)), ((V)(0D)), ((V)(0.8)), ((V)(8D)), CH_23, NewObj(1).Put("n", ((V)(4D))).V), Call(ball_14, V.Undef, ((V)((-14D))), ((V)(30D)), ((V)(7D)), ((V)(1.6)), CR_24, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
return default;
}, 1, "", true), NewObj(1).Put("round", ((V)(0D))).V);
}, 1, "", true);
tbJar_72 = Fn((V _arrowThis944, int _argc937, V S_943, V _a940, V _a941, V _a942, V[] _rest938) => {
return Call(T_63, V.Undef, ((V)(28D)), ((V)(28D)), Fn((V _arrowThis952, int _argc945, V P_951, V _a948, V _a949, V _a950, V[] _rest946) => {
V k_953 = default;
V cand_954 = default;
V o_955 = default;
k_953 = Get(S_943, "k");
cand_954 = (SEqS(k_953, "candy") ? V.True : V.False);
o_955 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(11D)), ((V)(22D)), (SEqS(k_953, "junk") ? TIN_27 : ((V)("#e6f6ff"))), NewObj(4).Put("n", ((V)(16D))).Put("zb", ((V)((-500D)))).Put("emit", ((V)((SEqS(k_953, "junk") ? 0D : 1D)))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(3D)), ((V)(0D)), ((V)(1D))), Arr(((V)(20D)), ((V)(0D)), ((V)(1D))), Arr(((V)(22D)), ((V)(0D)), ((V)(0.8))))).V));
if (!SEqS(k_953, "junk")) {
{
double i_956 = 0;
i_956 = 0D;
while (true) {
if (!((i_956 < 6D))) break;
Invoke(o_955, "push", (Truthy(cand_954) ? Call(ball_14, V.Undef, ((V)(((-5D) + ((i_956 % 3D) * 5D)))), ((V)((3D + (System.Math.Floor((i_956 / 3D)) * 7D)))), ((V)(6D)), ((V)(3.4)), GetIdx(NE_21, i_956), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V) : Call(disc_16, V.Undef, ((V)(((-5D) + ((i_956 % 3D) * 5D)))), ((V)((5D + (System.Math.Floor((i_956 / 3D)) * 7D)))), ((V)(9D)), ((V)(3.6)), ((V)(1.4)), ((V)("#d9a066")))));
i_956++;
}
}
}
Invoke(o_955, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(9D)), ((V)(4D)), (SEqS(k_953, "junk") ? ((V)("#c9a85a")) : Get(P_951, "b")), NewObj(1).Put("n", ((V)(14D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(3D)), (SEqS(k_953, "junk") ? ((V)("#c9a85a")) : Get(P_951, "b")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
if (SEqS(k_953, "junk")) {
Invoke(o_955, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(11D)), ((V)(12D)), ((V)(8D)), ((V)(0.6)), ((V)("#e2554a")), NewObj(1).Put("r", ((V)(1D))).V));
}
return o_955;
return default;
}, 1, "", true));
}, 1, "", true);
tbClock_73 = Fn((V _arrowThis965, int _argc958, V S_964, V _a961, V _a962, V _a963, V[] _rest959) => {
return Call(T_63, V.Undef, ((V)(28D)), ((V)(18D)), Fn((V _arrowThis973, int _argc966, V P_972, V _a969, V _a970, V _a971, V[] _rest967) => {
return Arr(Call(ball_14, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(10D)), Get(P_972, "a"), NewObj(1).Put("sz", ((V)(0.6))).V), Call(D__42, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(7.4)), ((V)(13D)), CR_24), Call(D__42, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(1.2)), ((V)(15D)), INK_29), Call(bar_47, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)), ((V)(21D)), ((V)(1.2)), ((V)(15D)), INK_29), Call(bar_47, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(4D)), ((V)(16D)), ((V)(1D)), ((V)(15D)), INK_29), Call(ball_14, V.Undef, ((V)((-7D))), ((V)(23D)), ((V)(0D)), ((V)(4D)), Get(P_972, "b"), NewObj(1).Put("sy", ((V)(0.7))).V), Call(ball_14, V.Undef, ((V)(7D)), ((V)(23D)), ((V)(0D)), ((V)(4D)), Get(P_972, "b"), NewObj(1).Put("sy", ((V)(0.7))).V), Call(box_12, V.Undef, ((V)((-6D))), ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(6D)), ((V)(2D)), DK_26, NewObj(1).Put("yaw", ((V)(0.3))).V), Call(box_12, V.Undef, ((V)(6D)), ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(6D)), ((V)(2D)), DK_26));
}, 1, "", true));
}, 1, "", true);
tbRadio_74 = Fn((V _arrowThis981, int _argc974, V S_980, V _a977, V _a978, V _a979, V[] _rest975) => {
return Call(T_63, V.Undef, ((V)(36D)), ((V)(18D)), Fn((V _arrowThis989, int _argc982, V P_988, V _a985, V _a986, V _a987, V[] _rest983) => {
return Arr(Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(34D)), ((V)(22D)), ((V)(14D)), Get(P_988, "a"), NewObj(1).Put("r", ((V)(9D))).V), Call(D__42, V.Undef, ((V)((-7D))), ((V)(11D)), ((V)(6D)), ((V)(15D)), Call(shade_19, V.Undef, Get(P_988, "a"), ((V)(0.7)))), Call(D__42, V.Undef, ((V)((-7D))), ((V)(11D)), ((V)(4D)), ((V)(16D)), ((V)("#c9b48e"))), Call(P__41, V.Undef, ((V)(9D)), ((V)(13D)), ((V)(10D)), ((V)(5D)), ((V)(15D)), ((V)("#fff1a8")), NewObj(1).Put("emit", ((V)(1D))).V), Call(D__42, V.Undef, ((V)(6D)), ((V)(6D)), ((V)(1.8)), ((V)(16D)), CH_23), Call(D__42, V.Undef, ((V)(12D)), ((V)(6D)), ((V)(1.8)), ((V)(16D)), CH_23), Call(cyl_13, V.Undef, ((V)(12D)), ((V)(22D)), ((V)(0D)), ((V)(0.6)), ((V)(14D)), CH_23, NewObj(1).Put("n", ((V)(4D))).V));
}, 1, "", true), NewObj(1).Put("round", ((V)(0D))).V);
}, 1, "", true);
tbGlobe_75 = Fn((V _arrowThis997, int _argc990, V S_996, V _a993, V _a994, V _a995, V[] _rest991) => {
return Call(T_63, V.Undef, ((V)(28D)), ((V)(28D)), Fn((V _arrowThis1005, int _argc998, V P_1004, V _a1001, V _a1002, V _a1003, V[] _rest999) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(8D)), ((V)(3D)), (SEqS(Get(S_996, "k"), "royal") ? GOLD_22 : ((V)("#c98d52"))), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(1.4)), ((V)(6D)), ((V)("#c98d52")), NewObj(1).Put("n", ((V)(6D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(11D)), ((V)("#5cc8f0"))), Call(ball_14, V.Undef, ((V)((-4D))), ((V)(18D)), ((V)(7D)), ((V)(4D)), ((V)("#7fc66a")), NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, ((V)(5D)), ((V)(12D)), ((V)(8D)), ((V)(3.4)), ((V)("#7fc66a")), NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(solid_11, V.Undef, NewObj(11).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)(19D)))).Put("a", ((V)(13D))).Put("b", ((V)(13D))).Put("th", ((V)(1.6))).Put("a0", ((V)((PI_38 * 0.6)))).Put("a1", ((V)((PI_38 * 1.6)))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((-0.8))), ((V)(0D))), Arr(((V)(0.8)), ((V)(0D))))).Put("col", (SEqS(Get(S_996, "k"), "royal") ? GOLD_22 : CH_23)).V));
}, 1, "", true));
}, 1, "", true);
tbSnow_76 = Fn((V _arrowThis1013, int _argc1006, V S_1012, V _a1009, V _a1010, V _a1011, V[] _rest1007) => {
return Call(T_63, V.Undef, ((V)(26D)), ((V)(26D)), Fn((V _arrowThis1021, int _argc1014, V P_1020, V _a1017, V _a1018, V _a1019, V[] _rest1015) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(7D)), Get(P_1020, "b"), NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(7D)), ((V)(0D)), ((V)(0.8))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(7D)), ((V)(0D)), ((V)(7D)), ((V)(2D)), WH_25, NewObj(1).Put("n", ((V)(12D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(2D)), ((V)(3D)), ((V)("#8a5a34")), NewObj(1).Put("n", ((V)(6D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(5D)), ((V)(10D)), LEAF_30, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(10D)), ((V)(0D)), ((V)(0D))), Arr(((V)(10D)), ((V)(0D)), ((V)(0D))))).V)).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(11D)), ((V)("#e8f6ff")), NewObj(2).Put("emit", ((V)(1D))).Put("zb", ((V)((-500D)))).V)).Spread(Invoke(Arr(Arr(((V)((-4D))), ((V)(14D))), Arr(((V)(3D)), ((V)(18D))), Arr(((V)(5D)), ((V)(10D))), Arr(((V)((-2D))), ((V)(22D)))), "map", Fn((V _arrowThis1033, int _argc1022, V _a1024, V _a1025, V _a1026, V _a1027, V[] _rest1023) => {
V x_1030 = default;
V y_1032 = default;
{ V _t1028 = ListOf(_a1024);
{ V _t1029 = GetIdx(_t1028, 0D);
x_1030 = _t1029; }
{ V _t1031 = GetIdx(_t1028, 1D);
y_1032 = _t1031; }
}
return Call(D__42, V.Undef, x_1030, y_1032, ((V)(1D)), ((V)(22D)), WH_25);
}, 1, "", true))).V;
}, 1, "", true));
}, 1, "", true);
tbTrophy_77 = Fn((V _arrowThis1041, int _argc1034, V S_1040, V _a1037, V _a1038, V _a1039, V[] _rest1035) => {
return Call(T_63, V.Undef, ((V)(26D)), ((V)(22D)), Fn((V _arrowThis1049, int _argc1042, V P_1048, V _a1045, V _a1046, V _a1047, V[] _rest1043) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(18D)), ((V)(6D)), ((V)(14D)), ((V)("#5a4030")), NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(2D)), ((V)(8D)), GOLD_22, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(10D)), ((V)(14D)), GOLD_22, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.3))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))))).V), Call(solid_11, V.Undef, NewObj(11).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)((-10D))), ((V)(22D)))).Put("a", ((V)(5D))).Put("b", ((V)(5D))).Put("th", ((V)(1.8))).Put("a0", ((V)((PI_38 * 0.5)))).Put("a1", ((V)((PI_38 * 1.5)))).Put("n", ((V)(8D))).Put("rings", Arr(Arr(((V)((-1D))), ((V)(0D))), Arr(((V)(1D)), ((V)(0D))))).Put("col", GOLD_22).V), Call(solid_11, V.Undef, NewObj(11).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(10D)), ((V)(22D)))).Put("a", ((V)(5D))).Put("b", ((V)(5D))).Put("th", ((V)(1.8))).Put("a0", ((V)(((-PI_38) * 0.5)))).Put("a1", ((V)((PI_38 * 0.5)))).Put("n", ((V)(8D))).Put("rings", Arr(Arr(((V)((-1D))), ((V)(0D))), Arr(((V)(1D)), ((V)(0D))))).Put("col", GOLD_22).V), Call(star_46, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(3D)), ((V)(16D)), ((V)("#ffd23f"))));
}, 1, "", true));
}, 1, "", true);
tbCandles_78 = Fn((V _arrowThis1057, int _argc1050, V S_1056, V _a1053, V _a1054, V _a1055, V[] _rest1051) => {
return Call(T_63, V.Undef, ((V)(32D)), ((V)(22D)), Fn((V _arrowThis1065, int _argc1058, V P_1064, V _a1061, V _a1062, V _a1063, V[] _rest1059) => {
V o_1066 = default;
o_1066 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(3D)), ((V)(18D)), (SEqS(Get(S_1056, "k"), "royal") ? GOLD_22 : Get(P_1064, "b")), NewObj(1).Put("r", ((V)(6D))).V));
Invoke(Arr(Arr(((V)((-9D))), ((V)(16D))), Arr(((V)(0D)), ((V)(24D))), Arr(((V)(9D)), ((V)(12D)))), "forEach", Fn((V _arrowThis1078, int _argc1067, V _a1069, V _a1070, V _a1071, V _a1072, V[] _rest1068) => {
V x_1075 = default;
V h_1077 = default;
{ V _t1073 = ListOf(_a1069);
{ V _t1074 = GetIdx(_t1073, 0D);
x_1075 = _t1074; }
{ V _t1076 = GetIdx(_t1073, 1D);
h_1077 = _t1076; }
}
return Invoke(o_1066, "push", Call(cyl_13, V.Undef, x_1075, ((V)(3D)), ((V)(0D)), ((V)(3.4)), h_1077, CR_24, NewObj(1).Put("n", ((V)(10D))).V), Call(ball_14, V.Undef, x_1075, Add(Add(((V)(3D)), h_1077), ((V)(1D))), ((V)(0D)), ((V)(2.4)), ((V)("#ffb340")), NewObj(4).Put("sy", ((V)(1.7))).Put("emit", ((V)(1D))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
return o_1066;
return default;
}, 1, "", true), NewObj(2).Put("glow", Fn((V _arrowThis1085, int _argc1079, V _a1081, V _a1082, V _a1083, V _a1084, V[] _rest1080) => {
return NewObj(2).Put("y", ((V)(30D))).Put("r", ((V)(34D))).V;
}, 0, "glow", true)).Put("round", ((V)(0D))).V);
}, 1, "", true);
tbBox_79 = Fn((V _arrowThis1093, int _argc1086, V S_1092, V _a1089, V _a1090, V _a1091, V[] _rest1087) => {
return Call(T_63, V.Undef, ((V)(30D)), ((V)(22D)), Fn((V _arrowThis1101, int _argc1094, V P_1100, V _a1097, V _a1098, V _a1099, V[] _rest1095) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(28D)), ((V)(12D)), ((V)(18D)), (SEqS(Get(S_1092, "k"), "royal") ? ((V)("#7a1e2c")) : Get(P_1100, "a")), NewObj(1).Put("r", ((V)(2D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(29D)), ((V)(2D)), ((V)(19D)), GOLD_22, NewObj(1).Put("r", ((V)(2D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(9.2)), ((V)(4D)), ((V)(4D)), ((V)(0.6)), GOLD_22, NewObj(1).Put("r", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(0.8)), ((V)(6D)), GOLD_22, NewObj(2).Put("n", ((V)(4D))).Put("part", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(0D)), ((V)(2.6)), ((V)("#f4f1ea")), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("part", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(4D)), ((V)(3D)), ((V)("#cdb8f5")), NewObj(3).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.3))))).Put("part", ((V)(1D))).V));
}, 1, "", true), NewObj(1).Put("round", ((V)(0D))).V);
}, 1, "", true);
tbCup_80 = Fn((V _arrowThis1109, int _argc1102, V S_1108, V _a1105, V _a1106, V _a1107, V[] _rest1103) => {
return Call(T_63, V.Undef, ((V)(22D)), ((V)(22D)), Fn((V _arrowThis1117, int _argc1110, V P_1116, V _a1113, V _a1114, V _a1115, V[] _rest1111) => {
return Invoke(Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(12D)), Get(P_1116, "a"), NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.85))), Arr(((V)(12D)), ((V)(0D)), ((V)(1D))))).V), Call(box_12, V.Undef, ((V)((-2D))), ((V)(10D)), ((V)(0D)), ((V)(1.6)), ((V)(14D)), ((V)(1.6)), ((V)("#4fe0d0")), NewObj(1).Put("yaw", ((V)(0.2))).V), Call(box_12, V.Undef, ((V)((-2.6))), ((V)(24D)), ((V)(0D)), ((V)(2.6)), ((V)(4D)), ((V)(2.4)), WH_25, NewObj(1).Put("r", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(2D)), ((V)(10D)), ((V)(0D)), ((V)(1.6)), ((V)(12D)), ((V)(1.6)), ((V)("#ffa940")), NewObj(1).Put("yaw", ((V)((-0.2)))).V), Call(box_12, V.Undef, ((V)(2.4)), ((V)(22D)), ((V)(0D)), ((V)(2.6)), ((V)(4D)), ((V)(2.4)), WH_25, NewObj(1).Put("r", ((V)(1D))).V), (SEqS(Get(S_1108, "k"), "junk") ? Call(D__42, V.Undef, ((V)(3D)), ((V)(5D)), ((V)(1.6)), ((V)(13D)), Call(shade_19, V.Undef, Get(P_1116, "a"), ((V)(0.8)))) : V.Null)), "filter", G("Boolean"));
}, 1, "", true));
}, 1, "", true);
duck_81 = Fn((V _arrowThis1128, int _argc1118, V x_1124, V z_1125, V s_1126, V col_1127, V[] _rest1119) => {
return Arr(Call(ball_14, V.Undef, x_1124, ((V)(0D)), z_1125, ((V)((6D * ToNum(s_1126)))), col_1127, NewObj(1).Put("sx", ((V)(1.25))).V), Call(ball_14, V.Undef, Add(x_1124, ((V)((3D * ToNum(s_1126))))), ((V)((8D * ToNum(s_1126)))), z_1125, ((V)((4D * ToNum(s_1126)))), col_1127), Call(box_12, V.Undef, Add(x_1124, ((V)((7.4 * ToNum(s_1126))))), ((V)((9D * ToNum(s_1126)))), z_1125, ((V)((3.6 * ToNum(s_1126)))), ((V)((1.6 * ToNum(s_1126)))), ((V)((2.6 * ToNum(s_1126)))), ((V)("#ff9d4a")), NewObj(1).Put("r", ((V)(0.8))).V), Call(D__42, V.Undef, Add(x_1124, ((V)((4D * ToNum(s_1126))))), ((V)((11D * ToNum(s_1126)))), ((V)(0.8)), ((V)(Round(((2D * ToNum(Add(z_1125, ((V)((4D * ToNum(s_1126))))))) + 1.5)))), INK_29));
}, 4, "", true);
tbDuck_82 = Fn((V _arrowThis1136, int _argc1129, V S_1135, V _a1132, V _a1133, V _a1134, V[] _rest1130) => {
return Call(T_63, V.Undef, ((V)(40D)), ((V)(22D)), Fn((V _arrowThis1144, int _argc1137, V P_1143, V _a1140, V _a1141, V _a1142, V[] _rest1138) => {
return (SEqS(Get(S_1135, "k"), "candy") ? new ArrBuilder().Spread(Call(duck_81, V.Undef, ((V)((-12D))), ((V)((-2D))), ((V)(1.1)), GetIdx(NE_21, 1D))).Spread(Call(duck_81, V.Undef, ((V)(2D)), ((V)(2D)), ((V)(0.9)), GetIdx(NE_21, 4D))).Spread(Call(duck_81, V.Undef, ((V)(14D)), ((V)((-1D))), ((V)(0.75)), GetIdx(NE_21, 3D))).V : new ArrBuilder().Spread(Call(duck_81, V.Undef, ((V)((-12D))), ((V)((-2D))), ((V)(1.1)), ((V)("#ffd23f")))).Spread(Call(duck_81, V.Undef, ((V)(2D)), ((V)(2D)), ((V)(0.9)), ((V)("#ffd23f")))).Spread(Call(duck_81, V.Undef, ((V)(13D)), ((V)((-1D))), ((V)(0.7)), ((V)("#ffe680")))).V);
}, 1, "", true), NewObj(1).Put("round", ((V)(0D))).V);
}, 1, "", true);
tbPerfume_83 = Fn((V _arrowThis1152, int _argc1145, V S_1151, V _a1148, V _a1149, V _a1150, V[] _rest1146) => {
return Call(T_63, V.Undef, ((V)(34D)), ((V)(20D)), Fn((V _arrowThis1160, int _argc1153, V P_1159, V _a1156, V _a1157, V _a1158, V[] _rest1154) => {
V g_1161 = default;
g_1161 = ((V)((SEqS(Get(S_1151, "k"), "royal") ? "#f6e2e6" : "#e8f6ff")));
return Arr(Call(cyl_13, V.Undef, ((V)((-10D))), ((V)(0D)), ((V)(0D)), ((V)(5D)), ((V)(12D)), g_1161, NewObj(2).Put("n", ((V)(10D))).Put("emit", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)((-10D))), ((V)(12D)), ((V)(0D)), ((V)(2D)), ((V)(3D)), GOLD_22, NewObj(1).Put("n", ((V)(6D))).V), Call(ball_14, V.Undef, ((V)((-10D))), ((V)(15D)), ((V)(0D)), ((V)(2.4)), (SEqS(Get(S_1151, "k"), "royal") ? ((V)("#7a1e2c")) : Get(P_1159, "a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(box_12, V.Undef, ((V)(2D)), ((V)(0D)), ((V)(0D)), ((V)(9D)), ((V)(16D)), ((V)(6D)), g_1161, NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(2D)), ((V)(16D)), ((V)(0D)), ((V)(1.6)), ((V)(3D)), GOLD_22, NewObj(1).Put("n", ((V)(6D))).V), Call(ball_14, V.Undef, ((V)(2D)), ((V)(19D)), ((V)(0D)), ((V)(3D)), GOLD_22, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, ((V)(13D)), ((V)(0D)), ((V)(0D)), ((V)(5D)), Get(P_1159, "b"), NewObj(2).Put("sy", ((V)(1.1))).Put("emit", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(13D)), ((V)(10D)), ((V)(0D)), ((V)(1.4)), ((V)(4D)), GOLD_22, NewObj(1).Put("n", ((V)(6D))).V));
return default;
}, 1, "", true), NewObj(1).Put("round", ((V)(0D))).V);
}, 1, "", true);
tbSoap_84 = Fn((V _arrowThis1169, int _argc1162, V S_1168, V _a1165, V _a1166, V _a1167, V[] _rest1163) => {
return Call(T_63, V.Undef, ((V)(22D)), ((V)(22D)), Fn((V _arrowThis1177, int _argc1170, V P_1176, V _a1173, V _a1174, V _a1175, V[] _rest1171) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(16D)), Get(P_1176, "a"), NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))), Arr(((V)(16D)), ((V)(0D)), ((V)(0.7))))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)), ((V)(1.6)), ((V)(4D)), DK_26, NewObj(1).Put("n", ((V)(6D))).V), Call(box_12, V.Undef, ((V)(3D)), ((V)(20D)), ((V)(0D)), ((V)(7D)), ((V)(2D)), ((V)(2D)), DK_26, NewObj(1).Put("r", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(6D)), ((V)(7D)), ((V)(5D)), ((V)(0.6)), WH_25, NewObj(1).Put("r", ((V)(1D))).V));
}, 1, "", true));
}, 1, "", true);
A3_85 = NewObj(26).Put("poster", poster_52).Put("gallery", gallery_53).Put("wallClock", wallClock_55).Put("wallShelf", wallShelf_56).Put("mirror", mirror_58).Put("bookcase", bookcase_61).Put("lowShelf", lowShelf_62).Put("tbVase", tbVase_65).Put("tbBooks", tbBooks_66).Put("tbFruit", tbFruit_67).Put("tbCake", tbCake_68).Put("tbTeapot", tbTeapot_69).Put("tbToaster", tbToaster_70).Put("tbMixer", tbMixer_71).Put("tbJar", tbJar_72).Put("tbClock", tbClock_73).Put("tbRadio", tbRadio_74).Put("tbGlobe", tbGlobe_75).Put("tbSnow", tbSnow_76).Put("tbTrophy", tbTrophy_77).Put("tbCandles", tbCandles_78).Put("tbBox", tbBox_79).Put("tbCup", tbCup_80).Put("tbDuck", tbDuck_82).Put("tbPerfume", tbPerfume_83).Put("tbSoap", tbSoap_84).V;
L_86 = ((V)("living"));
Kt_87 = ((V)("kitchen"));
B_88 = ((V)("bathroom"));
R_89 = ((V)("bedroom"));
Dn_90 = ((V)("dance"));
Y_91 = ((V)("backyard"));
NEW_92 = Arr(Arr(((V)(1D)), ((V)("x_pPal")), ((V)("Taped Comic Poster")), L_86, ((V)("poster")), NewObj(1).Put("v", ((V)("pal"))).V), Arr(((V)(1D)), ((V)("x_rRunner")), ((V)("Rag Runner")), L_86, ((V)("rug2")), NewObj(1).Put("v", ((V)("runner"))).V), Arr(((V)(1D)), ((V)("x_jarLamp")), ((V)("Jar Table Lamp")), L_86, ((V)("tableLamp"))), Arr(((V)(2D)), ((V)("x_tinClock")), ((V)("Tin Wall Clock")), L_86, ((V)("wallClock"))), Arr(((V)(2D)), ((V)("x_toastJ")), ((V)("Dented Toaster")), Kt_87, ((V)("tbToaster"))), Arr(((V)(2D)), ((V)("x_sackPile")), ((V)("Sack Bean Pile")), L_86, ((V)("beanpile"))), Arr(((V)(2D)), ((V)("x_telly")), ((V)("Tiny Telly")), L_86, ((V)("miniTV"))), Arr(((V)(2D)), ((V)("x_canCactus")), ((V)("Tin Can Cactus")), L_86, ((V)("cactus"))), Arr(((V)(3D)), ((V)("x_plank")), ((V)("Plank Shelf")), L_86, ((V)("wallShelf"))), Arr(((V)(3D)), ((V)("x_teaJ")), ((V)("Chipped Teapot")), Kt_87, ((V)("tbTeapot"))), Arr(((V)(3D)), ((V)("x_kRag")), ((V)("Kitchen Rag Mat")), Kt_87, ((V)("rug2")), NewObj(1).Put("v", ((V)("stripe"))).V), Arr(((V)(3D)), ((V)("x_crateBooks")), ((V)("Crate Bookcase")), L_86, ((V)("bookcase"))), Arr(((V)(3D)), ((V)("x_tinSconce")), ((V)("Tin Sconce")), L_86, ((V)("sconce"))), Arr(((V)(4D)), ((V)("x_crackMir")), ((V)("Cracked Mirror")), B_88, ((V)("mirror"))), Arr(((V)(4D)), ((V)("x_mug")), ((V)("Toothbrush Mug")), B_88, ((V)("tbCup"))), Arr(((V)(4D)), ((V)("x_bRag")), ((V)("Bath Rag Rug")), B_88, ((V)("rug2")), NewObj(1).Put("v", ((V)("oval"))).V), Arr(((V)(4D)), ((V)("x_jamBowl")), ((V)("Jam Jar Fishbowl")), L_86, ((V)("tankSmall"))), Arr(((V)(4D)), ((V)("x_tinJar")), ((V)("Cookie Tin")), Kt_87, ((V)("tbJar"))), Arr(((V)(5D)), ((V)("x_oldBox")), ((V)("Old Party Box")), L_86, ((V)("partyBox"))), Arr(((V)(5D)), ((V)("x_crateTV")), ((V)("TV Crate Stand")), L_86, ((V)("tvstand"))), Arr(((V)(5D)), ((V)("x_lumpBed")), ((V)("Lumpy Daybed")), R_89, ((V)("chaise"))), Arr(((V)(5D)), ((V)("x_pMap")), ((V)("Old Map Poster")), L_86, ((V)("poster")), NewObj(1).Put("v", ((V)("map"))).V), Arr(((V)(5D)), ((V)("x_bookJ")), ((V)("Book Stack")), L_86, ((V)("tbBooks"))), Arr(((V)(5D)), ((V)("x_snaps")), ((V)("Snapshot Wall")), L_86, ((V)("gallery"))), Arr(((V)(6D)), ((V)("x_cotL")), ((V)("Cottage Corner Sofa")), L_86, ((V)("lsofa"))), Arr(((V)(6D)), ((V)("x_pFruit")), ((V)("Fruit Print")), Kt_87, ((V)("poster")), NewObj(1).Put("v", ((V)("fruit"))).V), Arr(((V)(6D)), ((V)("x_braidR")), ((V)("Braided Round Rug")), R_89, ((V)("rug2")), NewObj(1).Put("v", ((V)("round"))).V), Arr(((V)(6D)), ((V)("x_pleatLamp")), ((V)("Pleated Lamp")), R_89, ((V)("tableLamp"))), Arr(((V)(6D)), ((V)("x_alarm")), ((V)("Twin-Bell Alarm")), R_89, ((V)("tbClock"))), Arr(((V)(7D)), ((V)("x_cotEnd")), ((V)("Cottage Sofa End")), L_86, ((V)("modEnd"))), Arr(((V)(7D)), ((V)("x_cotMid")), ((V)("Cottage Sofa Middle")), L_86, ((V)("modMid"))), Arr(((V)(7D)), ((V)("x_cotCorner")), ((V)("Cottage Sofa Corner")), L_86, ((V)("modCorner"))), Arr(((V)(7D)), ((V)("x_cuckoo")), ((V)("Cuckoo Clock")), L_86, ((V)("wallClock"))), Arr(((V)(7D)), ((V)("x_cakeC")), ((V)("Cake Stand")), Kt_87, ((V)("tbCake"))), Arr(((V)(7D)), ((V)("x_fruitC")), ((V)("Fruit Bowl")), Kt_87, ((V)("tbFruit"))), Arr(((V)(8D)), ((V)("x_cotDay")), ((V)("Cottage Daybed")), R_89, ((V)("chaise"))), Arr(((V)(8D)), ((V)("x_ovalMir")), ((V)("Oval Wood Mirror")), R_89, ((V)("mirror"))), Arr(((V)(8D)), ((V)("x_monst")), ((V)("Monstera")), L_86, ((V)("monstera"))), Arr(((V)(8D)), ((V)("x_sunfl")), ((V)("Sunflower Pot")), Y_91, ((V)("sunflower"))), Arr(((V)(8D)), ((V)("x_gLantern")), ((V)("Garden Lantern")), Y_91, ((V)("lantern"))), Arr(((V)(8D)), ((V)("x_picnicRad")), ((V)("Picnic Radio")), Y_91, ((V)("partyBox"))), Arr(((V)(9D)), ((V)("x_cotTV")), ((V)("Cottage TV Cabinet")), L_86, ((V)("tvstand"))), Arr(((V)(9D)), ((V)("x_spiceSh")), ((V)("Spice Shelf")), Kt_87, ((V)("wallShelf"))), Arr(((V)(9D)), ((V)("x_mixerC")), ((V)("Stand Mixer")), Kt_87, ((V)("tbMixer"))), Arr(((V)(9D)), ((V)("x_toyCub")), ((V)("Toy Cubby")), R_89, ((V)("lowShelf"))), Arr(((V)(9D)), ((V)("x_ducks")), ((V)("Rubber Duck Trio")), B_88, ((V)("tbDuck"))), Arr(((V)(9D)), ((V)("x_daisyR")), ((V)("Daisy Bath Rug")), B_88, ((V)("rug2")), NewObj(1).Put("v", ((V)("flower"))).V), Arr(((V)(10D)), ((V)("x_cotLib")), ((V)("Cottage Library")), L_86, ((V)("bookcase"))), Arr(((V)(10D)), ((V)("x_famPics")), ((V)("Family Photos")), L_86, ((V)("gallery"))), Arr(((V)(10D)), ((V)("x_goldfish")), ((V)("Goldfish Bowl")), L_86, ((V)("tankSmall"))), Arr(((V)(10D)), ((V)("x_bedTV")), ((V)("Bedside TV")), R_89, ((V)("miniTV"))), Arr(((V)(10D)), ((V)("x_candSc")), ((V)("Candle Sconce")), L_86, ((V)("sconce"))), Arr(((V)(10D)), ((V)("x_succC")), ((V)("Succulent")), R_89, ((V)("succulent"))), Arr(((V)(11D)), ((V)("x_horse")), ((V)("Diner Horseshoe Sofa")), L_86, ((V)("usofa"))), Arr(((V)(11D)), ((V)("x_pRock")), ((V)("Rock Concert Poster")), L_86, ((V)("poster")), NewObj(1).Put("v", ((V)("music"))).V), Arr(((V)(11D)), ((V)("x_recRug")), ((V)("Record Rug")), Dn_90, ((V)("rug2")), NewObj(1).Put("v", ((V)("record"))).V), Arr(((V)(11D)), ((V)("x_spkWall")), ((V)("Speaker Wall")), Dn_90, ((V)("spkWall"))), Arr(((V)(11D)), ((V)("x_burstClk")), ((V)("Starburst Clock")), L_86, ((V)("wallClock"))), Arr(((V)(12D)), ((V)("x_chkRun")), ((V)("Checker Runner")), Kt_87, ((V)("rug2")), NewObj(1).Put("v", ((V)("check"))).V), Arr(((V)(12D)), ((V)("x_chromeToast")), ((V)("Chrome Toaster")), Kt_87, ((V)("tbToaster"))), Arr(((V)(12D)), ((V)("x_chromeSh")), ((V)("Chrome Shelf")), Kt_87, ((V)("wallShelf"))), Arr(((V)(12D)), ((V)("x_cookieJar")), ((V)("Cookie Jar")), Kt_87, ((V)("tbJar"))), Arr(((V)(12D)), ((V)("x_retroCon")), ((V)("Retro TV Console")), L_86, ((V)("tvstand"))), Arr(((V)(12D)), ((V)("x_atomCact")), ((V)("Atomic Cactus")), L_86, ((V)("cactus"))), Arr(((V)(13D)), ((V)("x_pinball")), ((V)("Pinball Machine")), Dn_90, ((V)("pinball"))), Arr(((V)(13D)), ((V)("x_neonStar")), ((V)("Neon Star Sign")), Dn_90, ((V)("neonSign"))), Arr(((V)(13D)), ((V)("x_boothRow")), ((V)("Diner Booth Row")), L_86, ((V)("longSofa")), NewObj(1).Put("n", ((V)(4D))).V), Arr(((V)(13D)), ((V)("x_lobbyPalm")), ((V)("Lobby Palm")), L_86, ((V)("pottedPalm"))), Arr(((V)(13D)), ((V)("x_atomLamp")), ((V)("Atomic Lamp")), L_86, ((V)("tableLamp"))), Arr(((V)(14D)), ((V)("x_hollyMir")), ((V)("Hollywood Mirror")), B_88, ((V)("mirror"))), Arr(((V)(14D)), ((V)("x_perfR")), ((V)("Perfume Bottles")), B_88, ((V)("tbPerfume"))), Arr(((V)(14D)), ((V)("x_pMovie")), ((V)("Movie Poster")), R_89, ((V)("poster")), NewObj(1).Put("v", ((V)("movie"))).V), Arr(((V)(14D)), ((V)("x_radioR")), ((V)("Tabletop Radio")), R_89, ((V)("tbRadio"))), Arr(((V)(14D)), ((V)("x_starRug")), ((V)("Star Rug")), R_89, ((V)("rug2")), NewObj(1).Put("v", ((V)("star"))).V), Arr(((V)(14D)), ((V)("x_jetDay")), ((V)("Jet-Age Daybed")), R_89, ((V)("chaise"))), Arr(((V)(15D)), ((V)("x_driveIn")), ((V)("Drive-In Screen")), Y_91, ((V)("projector"))), Arr(((V)(15D)), ((V)("x_rWallTV")), ((V)("Rounded Wall TV")), L_86, ((V)("wallTV"))), Arr(((V)(15D)), ((V)("x_bubPost")), ((V)("Bubble Lamp Post")), Dn_90, ((V)("lantern"))), Arr(((V)(15D)), ((V)("x_recCovers")), ((V)("Record Covers")), L_86, ((V)("gallery"))), Arr(((V)(15D)), ((V)("x_chromeSc")), ((V)("Chrome Sconce")), L_86, ((V)("sconce"))), Arr(((V)(15D)), ((V)("x_cakeDome")), ((V)("Diner Cake Dome")), Kt_87, ((V)("tbCake"))), Arr(((V)(16D)), ((V)("x_modBench")), ((V)("Modern Bench Sofa")), L_86, ((V)("longSofa")), NewObj(1).Put("n", ((V)(3D))).V), Arr(((V)(16D)), ((V)("x_bigWallTV")), ((V)("Big Wall TV")), L_86, ((V)("wallTV"))), Arr(((V)(16D)), ((V)("x_hexRug")), ((V)("Hex Rug")), L_86, ((V)("rug2")), NewObj(1).Put("v", ((V)("hex"))).V), Arr(((V)(16D)), ((V)("x_tallMonst")), ((V)("Tall Monstera")), L_86, ((V)("monstera"))), Arr(((V)(16D)), ((V)("x_budVase")), ((V)("Bud Vase")), L_86, ((V)("tbVase"))), Arr(((V)(17D)), ((V)("x_modEnd")), ((V)("Modular Sofa End")), L_86, ((V)("modEnd"))), Arr(((V)(17D)), ((V)("x_modMid")), ((V)("Modular Sofa Middle")), L_86, ((V)("modMid"))), Arr(((V)(17D)), ((V)("x_modCorner")), ((V)("Modular Sofa Corner")), L_86, ((V)("modCorner"))), Arr(((V)(17D)), ((V)("x_modL")), ((V)("L-Shape Sofa")), L_86, ((V)("lsofa"))), Arr(((V)(17D)), ((V)("x_floatSh")), ((V)("Floating Shelf")), L_86, ((V)("wallShelf"))), Arr(((V)(17D)), ((V)("x_bonsai")), ((V)("Bonsai")), L_86, ((V)("bonsai"))), Arr(((V)(18D)), ((V)("x_screen")), ((V)("Movie Screen")), L_86, ((V)("projector"))), Arr(((V)(18D)), ((V)("x_aqua")), ((V)("Big Aquarium")), L_86, ((V)("aquaBig"))), Arr(((V)(18D)), ((V)("x_console")), ((V)("Game Console")), L_86, ((V)("consoleSet"))), Arr(((V)(18D)), ((V)("x_racer")), ((V)("Racing Sim")), Dn_90, ((V)("racer"))), Arr(((V)(18D)), ((V)("x_sub")), ((V)("Subwoofer")), Dn_90, ((V)("sub"))), Arr(((V)(18D)), ((V)("x_cubeLib")), ((V)("Cube Library")), L_86, ((V)("bookcase"))), Arr(((V)(19D)), ((V)("x_pitM")), ((V)("Round Pit Sofa")), L_86, ((V)("pit"))), Arr(((V)(19D)), ((V)("x_pSunset")), ((V)("Gallery Print")), R_89, ((V)("poster")), NewObj(1).Put("v", ((V)("sunset"))).V), Arr(((V)(19D)), ((V)("x_archMir")), ((V)("Arch Mirror")), R_89, ((V)("mirror"))), Arr(((V)(19D)), ((V)("x_zigRug")), ((V)("Zigzag Rug")), R_89, ((V)("rug2")), NewObj(1).Put("v", ((V)("zig"))).V), Arr(((V)(19D)), ((V)("x_orbLamp")), ((V)("Orb Lamp")), R_89, ((V)("tableLamp"))), Arr(((V)(19D)), ((V)("x_globe")), ((V)("Desk Globe")), R_89, ((V)("tbGlobe"))), Arr(((V)(20D)), ((V)("x_fogSpk")), ((V)("Fog Speaker")), Dn_90, ((V)("smokeSpk"))), Arr(((V)(20D)), ((V)("x_lightBar")), ((V)("Light Bar")), L_86, ((V)("sconce"))), Arr(((V)(20D)), ((V)("x_galM")), ((V)("Gallery Frames")), L_86, ((V)("gallery"))), Arr(((V)(20D)), ((V)("x_glassFruit")), ((V)("Glass Fruit Bowl")), Kt_87, ((V)("tbFruit"))), Arr(((V)(20D)), ((V)("x_soap")), ((V)("Soap Pump")), B_88, ((V)("tbSoap"))), Arr(((V)(20D)), ((V)("x_lowSh")), ((V)("Low Shelf")), R_89, ((V)("lowShelf"))), Arr(((V)(20D)), ((V)("x_minClk")), ((V)("Minimal Clock")), L_86, ((V)("wallClock"))), Arr(((V)(21D)), ((V)("x_candyU")), ((V)("Candy U-Sofa")), L_86, ((V)("usofa"))), Arr(((V)(21D)), ((V)("x_rainRug")), ((V)("Rainbow Rug")), L_86, ((V)("rug2")), NewObj(1).Put("v", ((V)("rainbow"))).V), Arr(((V)(21D)), ((V)("x_gumTV")), ((V)("Gumdrop Wall TV")), L_86, ((V)("wallTV"))), Arr(((V)(21D)), ((V)("x_pSweet")), ((V)("Sweet Pal Poster")), L_86, ((V)("poster")), NewObj(1).Put("v", ((V)("pal"))).V), Arr(((V)(21D)), ((V)("x_mushLamp")), ((V)("Mushroom Lamp")), R_89, ((V)("mushLamp"))), Arr(((V)(22D)), ((V)("x_marshPit")), ((V)("Marshmallow Pit")), L_86, ((V)("pit"))), Arr(((V)(22D)), ((V)("x_gumPile")), ((V)("Gumdrop Bean Pile")), L_86, ((V)("beanpile"))), Arr(((V)(22D)), ((V)("x_taffyDay")), ((V)("Taffy Daybed")), R_89, ((V)("chaise"))), Arr(((V)(22D)), ((V)("x_shag")), ((V)("Shaggy Rug")), R_89, ((V)("rug2")), NewObj(1).Put("v", ((V)("shag"))).V), Arr(((V)(22D)), ((V)("x_tubeTank")), ((V)("Bubble Tube Tank")), L_86, ((V)("aquaCol"))), Arr(((V)(22D)), ((V)("x_cupTower")), ((V)("Cupcake Tower")), Kt_87, ((V)("tbCake"))), Arr(((V)(23D)), ((V)("x_claw")), ((V)("Claw Machine")), Dn_90, ((V)("claw"))), Arr(((V)(23D)), ((V)("x_neonLolly")), ((V)("Neon Lollipop")), Dn_90, ((V)("neonSign"))), Arr(((V)(23D)), ((V)("x_jellyBox")), ((V)("Jelly Party Box")), Dn_90, ((V)("partyBox"))), Arr(((V)(23D)), ((V)("x_handheld")), ((V)("Handheld Game")), L_86, ((V)("handheld"))), Arr(((V)(23D)), ((V)("x_snowG")), ((V)("Snow Globe")), R_89, ((V)("tbSnow"))), Arr(((V)(23D)), ((V)("x_cookieClk")), ((V)("Cookie Clock")), R_89, ((V)("wallClock"))), Arr(((V)(24D)), ((V)("x_faceRug")), ((V)("Pal Face Rug")), R_89, ((V)("rug2")), NewObj(1).Put("v", ((V)("face"))).V), Arr(((V)(24D)), ((V)("x_cloudMir")), ((V)("Cloud Mirror")), R_89, ((V)("mirror"))), Arr(((V)(24D)), ((V)("x_cloudSh")), ((V)("Cloud Shelf")), R_89, ((V)("wallShelf"))), Arr(((V)(24D)), ((V)("x_candyCub")), ((V)("Candy Cubby")), R_89, ((V)("lowShelf"))), Arr(((V)(24D)), ((V)("x_duckPar")), ((V)("Duck Parade")), B_88, ((V)("tbDuck"))), Arr(((V)(24D)), ((V)("x_candyJar")), ((V)("Candy Jar")), Kt_87, ((V)("tbJar"))), Arr(((V)(24D)), ((V)("x_lollyFl")), ((V)("Lolly Flowers")), L_86, ((V)("flowerPot"))), Arr(((V)(25D)), ((V)("x_candyLib")), ((V)("Candy Bookcase")), L_86, ((V)("bookcase"))), Arr(((V)(25D)), ((V)("x_candyTV")), ((V)("Candy TV Stand")), L_86, ((V)("tvstand"))), Arr(((V)(25D)), ((V)("x_doodles")), ((V)("Doodle Frames")), L_86, ((V)("gallery"))), Arr(((V)(25D)), ((V)("x_spiral")), ((V)("Spiral Rug")), Dn_90, ((V)("rug2")), NewObj(1).Put("v", ((V)("spiral"))).V), Arr(((V)(25D)), ((V)("x_gumSc")), ((V)("Gumdrop Sconce")), L_86, ((V)("sconce"))), Arr(((V)(25D)), ((V)("x_sugSucc")), ((V)("Sugar Succulent")), L_86, ((V)("succulent"))), Arr(((V)(25D)), ((V)("x_gumLamp")), ((V)("Gumdrop Lamp")), L_86, ((V)("tableLamp"))), Arr(((V)(26D)), ((V)("x_grand")), ((V)("Royal Settee")), L_86, ((V)("longSofa")), NewObj(1).Put("n", ((V)(3D))).V), Arr(((V)(26D)), ((V)("x_royOval")), ((V)("Royal Oval Rug")), L_86, ((V)("rug2")), NewObj(1).Put("v", ((V)("oval"))).V), Arr(((V)(26D)), ((V)("x_sunClk")), ((V)("Sunburst Clock")), L_86, ((V)("wallClock"))), Arr(((V)(26D)), ((V)("x_porcVase")), ((V)("Porcelain Vase")), L_86, ((V)("tbVase"))), Arr(((V)(26D)), ((V)("x_pStars")), ((V)("Starry Sky Painting")), L_86, ((V)("poster")), NewObj(1).Put("v", ((V)("stars"))).V), Arr(((V)(27D)), ((V)("x_palU")), ((V)("Palace U-Sofa")), L_86, ((V)("usofa"))), Arr(((V)(27D)), ((V)("x_gildTV")), ((V)("Gilded Wall TV")), L_86, ((V)("wallTV"))), Arr(((V)(27D)), ((V)("x_palAqua")), ((V)("Palace Aquarium")), L_86, ((V)("aquaBig"))), Arr(((V)(27D)), ((V)("x_palPalm")), ((V)("Palace Palm")), L_86, ((V)("pottedPalm"))), Arr(((V)(27D)), ((V)("x_crysLamp")), ((V)("Crystal Lamp")), L_86, ((V)("tableLamp"))), Arr(((V)(27D)), ((V)("x_trophy")), ((V)("Golden Trophy")), R_89, ((V)("tbTrophy"))), Arr(((V)(28D)), ((V)("x_royDay")), ((V)("Royal Daybed")), R_89, ((V)("chaise"))), Arr(((V)(28D)), ((V)("x_gildMir")), ((V)("Gilded Mirror")), R_89, ((V)("mirror"))), Arr(((V)(28D)), ((V)("x_royStar")), ((V)("Royal Star Rug")), R_89, ((V)("rug2")), NewObj(1).Put("v", ((V)("star"))).V), Arr(((V)(28D)), ((V)("x_candles")), ((V)("Candle Trio")), R_89, ((V)("tbCandles"))), Arr(((V)(28D)), ((V)("x_musicBox")), ((V)("Music Box")), R_89, ((V)("tbBox"))), Arr(((V)(28D)), ((V)("x_crysPerf")), ((V)("Crystal Perfumes")), B_88, ((V)("tbPerfume"))), Arr(((V)(29D)), ((V)("x_cinema")), ((V)("Royal Cinema")), Dn_90, ((V)("projector"))), Arr(((V)(29D)), ((V)("x_royTower")), ((V)("Royal Speaker Tower")), Dn_90, ((V)("spkTower"))), Arr(((V)(29D)), ((V)("x_royPit")), ((V)("Royal Pit Sofa")), L_86, ((V)("pit"))), Arr(((V)(29D)), ((V)("x_palLib")), ((V)("Palace Library")), L_86, ((V)("bookcase"))), Arr(((V)(29D)), ((V)("x_royGal")), ((V)("Royal Gallery")), L_86, ((V)("gallery"))), Arr(((V)(29D)), ((V)("x_goldTea")), ((V)("Gold Tea Set")), Kt_87, ((V)("tbTeapot"))), Arr(((V)(30D)), ((V)("x_goldSh")), ((V)("Gold Shelf")), L_86, ((V)("wallShelf"))), Arr(((V)(30D)), ((V)("x_gildSc")), ((V)("Gilded Sconce")), L_86, ((V)("sconce"))), Arr(((V)(30D)), ((V)("x_royBouq")), ((V)("Royal Bouquet")), L_86, ((V)("flowerPot"))), Arr(((V)(30D)), ((V)("x_mapRug")), ((V)("Treasure Map Rug")), R_89, ((V)("rug2")), NewObj(1).Put("v", ((V)("map"))).V), Arr(((V)(30D)), ((V)("x_royCake")), ((V)("Royal Cake Dome")), Kt_87, ((V)("tbCake"))), Arr(((V)(30D)), ((V)("x_leather")), ((V)("Leather Books")), L_86, ((V)("tbBooks"))));
WT_93 = NewObj(46).Put("lsofa", ((V)(2.6))).Put("usofa", ((V)(3.2))).Put("longSofa", ((V)(3D))).Put("modEnd", ((V)(1D))).Put("modMid", ((V)(0.8))).Put("modCorner", ((V)(0.9))).Put("pit", ((V)(3D))).Put("beanpile", ((V)(1.6))).Put("chaise", ((V)(1.6))).Put("tvstand", ((V)(1.6))).Put("miniTV", ((V)(0.7))).Put("wallTV", ((V)(1.8))).Put("projector", ((V)(2.4))).Put("spkWall", ((V)(2D))).Put("sub", ((V)(1.2))).Put("smokeSpk", ((V)(1.4))).Put("partyBox", ((V)(0.9))).Put("spkTower", ((V)(1.2))).Put("tableLamp", ((V)(0.5))).Put("sconce", ((V)(0.5))).Put("lantern", ((V)(0.8))).Put("neonSign", ((V)(1D))).Put("mushLamp", ((V)(0.8))).Put("cactus", ((V)(0.5))).Put("monstera", ((V)(0.8))).Put("sunflower", ((V)(0.5))).Put("bonsai", ((V)(0.6))).Put("flowerPot", ((V)(0.5))).Put("pottedPalm", ((V)(0.9))).Put("succulent", ((V)(0.3))).Put("tankSmall", ((V)(0.6))).Put("aquaBig", ((V)(2.2))).Put("aquaCol", ((V)(1.8))).Put("pinball", ((V)(2D))).Put("claw", ((V)(2.2))).Put("racer", ((V)(2.4))).Put("consoleSet", ((V)(0.9))).Put("handheld", ((V)(0.6))).Put("rug2", ((V)(0.7))).Put("poster", ((V)(0.4))).Put("wallClock", ((V)(0.5))).Put("wallShelf", ((V)(0.5))).Put("mirror", ((V)(0.6))).Put("gallery", ((V)(0.6))).Put("bookcase", ((V)(1.3))).Put("lowShelf", ((V)(1D))).V;
AA_94 = Object_assign(NewObj(0).V, Get(X_8, "A2"), A3_85);
BK_95 = NewObj(0).V;
Invoke(Get(X_8, "BANDS"), "forEach", Fn((V _arrowThis1185, int _argc1178, V b_1184, V _a1181, V _a1182, V _a1183, V[] _rest1179) => {
return SetK(BK_95, Get(b_1184, "k"), b_1184);
}, 1, "", true));
Invoke(NEW_92, "forEach", Fn((V _arrowThis1205, int _argc1186, V _a1188, V _a1189, V _a1190, V _a1191, V[] _rest1187) => {
V band_1206 = default;
V S_1207 = default;
V D_1208 = default;
double price_1209 = 0;
V lv_1194 = default;
V id_1196 = default;
V n_1198 = default;
V room_1200 = default;
V arch_1202 = default;
V ex_1204 = default;
{ V _t1192 = ListOf(_a1188);
{ V _t1193 = GetIdx(_t1192, 0D);
lv_1194 = _t1193; }
{ V _t1195 = GetIdx(_t1192, 1D);
id_1196 = _t1195; }
{ V _t1197 = GetIdx(_t1192, 2D);
n_1198 = _t1197; }
{ V _t1199 = GetIdx(_t1192, 3D);
room_1200 = _t1199; }
{ V _t1201 = GetIdx(_t1192, 4D);
arch_1202 = _t1201; }
{ V _t1203 = GetIdx(_t1192, 5D);
ex_1204 = _t1203; }
}
band_1206 = Get(Invoke(X_8, "bandOf", lv_1194), "k");
S_1207 = Object_assign(NewObj(1).Put("k", band_1206).V, (ex_1204 is var _t1210 && Truthy(_t1210) ? _t1210 : NewObj(0).V));
D_1208 = InvokeK(AA_94, arch_1202, S_1207);
price_1209 = (Round((((50D + (ToNum(lv_1194) * 28D)) * ToNum((GetK(WT_93, arch_1202) is var _t1211 && Truthy(_t1211) ? _t1211 : ((V)(0.3))))) / 10D)) * 10D);
Object_assign(D_1208, NewObj(10).Put("n", n_1198).Put("cat", room_1200).Put("price", ((V)(price_1209))).Put("cols", Get(GetK(BK_95, band_1206), "cols")).Put("lv", lv_1194).Put("band", band_1206).Put("arch", arch_1202).Put("room", room_1200).Put("start", (false ? V.True : V.False)).Put("id", id_1196).V);
if (Truthy((Get(D_1208, "mount") is var _t1212 && Truthy(_t1212) ? _t1212 : Get(D_1208, "small")))) {
Set(D_1208, "noBlock", ((V)(1D)));
}
SetK(Get(X_8, "CAT"), id_1196, D_1208);
Invoke(Get(X_8, "ITEMS"), "push", NewObj(10).Put("id", id_1196).Put("n", n_1198).Put("room", room_1200).Put("lv", lv_1194).Put("band", band_1206).Put("arch", arch_1202).Put("price", ((V)(price_1209))).Put("start", (false ? V.True : V.False)).Put("hidden", (false ? V.True : V.False)).Put("surf", (false ? V.True : V.False)).V);
return default;
}, 1, "", true));
Invoke(Get(X_8, "ITEMS"), "sort", Fn((V _arrowThis1221, int _argc1213, V a_1219, V b_1220, V _a1217, V _a1218, V[] _rest1214) => {
return ((V)((ToNum(Get(a_1219, "lv")) - ToNum(Get(b_1220, "lv")))));
}, 2, "", true));
Object_assign(Get(X_8, "ARCH"), AA_94);
HOSTA_96 = Arr(((V)("coffee")), ((V)("table")), ((V)("counter")), ((V)("nightstand")), ((V)("dresser")), ((V)("desk")), ((V)("chest")), ((V)("shelf")), ((V)("bar")), ((V)("bookcase")), ((V)("lowShelf")), ((V)("wallShelf")));
TOPS_97 = NewObj(0).V;
Set(X_8, "topOf", Fn((V _arrowThis1229, int _argc1222, V t_1228, V _a1225, V _a1226, V _a1227, V[] _rest1223) => {
V D_1230 = default;
V v_1231 = default;
if (HasProperty(TOPS_97, t_1228)) {
return GetK(TOPS_97, t_1228);
}
D_1230 = GetK(Get(X_8, "CAT"), t_1228);
v_1231 = ((V)(0D));
if (Truthy((D_1230 is var _t1232 && !Truthy(_t1232) ? _t1232 : Invoke(HOSTA_96, "includes", Get(D_1230, "arch"))))) {
if (Truthy(Get(D_1230, "top"))) {
v_1231 = Get(D_1230, "top");
} else {
try {
Invoke(Invoke(D_1230, "build", Invoke(X_8, "pal", D_1230, ((V)(0D))), ((V)(""))), "forEach", Fn((V _arrowThis1240, int _argc1233, V S_1239, V _a1236, V _a1237, V _a1238, V[] _rest1234) => {
double a_1241 = 0;
double b_1242 = 0;
double c_1243 = 0;
double d_1244 = 0;
double y_1245 = 0;
a_1241 = 1000000000D;
b_1242 = (-1000000000D);
c_1243 = 1000000000D;
d_1244 = (-1000000000D);
y_1245 = (-1000000000D);
Invoke(Get(S_1239, "pts"), "forEach", Fn((V _arrowThis1253, int _argc1246, V p_1252, V _a1249, V _a1250, V _a1251, V[] _rest1247) => {
a_1241 = Min(a_1241, ToNum(GetIdx(p_1252, 0D)));
b_1242 = Max(b_1242, ToNum(GetIdx(p_1252, 0D)));
c_1243 = Min(c_1243, ToNum(GetIdx(p_1252, 2D)));
d_1244 = Max(d_1244, ToNum(GetIdx(p_1252, 2D)));
y_1245 = Max(y_1245, ToNum(GetIdx(p_1252, 1D)));
return default;
}, 1, "", true));
if (((((b_1242 - a_1241) >= (ToNum(Get(D_1230, "w")) * 0.45)) && ((d_1244 - c_1243) >= (ToNum(Get(D_1230, "d")) * 0.3))) && (y_1245 < 200D))) {
v_1231 = ((V)(Max(ToNum(v_1231), y_1245)));
}
return default;
}, 1, "", true));
} catch (System.Exception _ex1254) {
V e_1255 = default;
e_1255 = Caught(_ex1254);

}
}
}
return SetK(TOPS_97, t_1228, ((V)((ToNum(v_1231) * ToNum(((D_1230 is var _t1256 && !Truthy(_t1256) ? _t1256 : Get(D_1230, "zs")) is var _t1257 && Truthy(_t1257) ? _t1257 : ((V)(1D))))))));
return default;
}, 1, "", true));
TVZ_98 = NewObj(5).Put("tv", ((V)(1.35))).Put("tvstand", ((V)(1.35))).Put("miniTV", ((V)(1.6))).Put("wallTV", ((V)(1.4))).Put("projector", ((V)(1.2))).V;
TVLV_99 = Fn((V _arrowThis1265, int _argc1258, V D_1264, V _a1261, V _a1262, V _a1263, V[] _rest1259) => {
return ((V)((Truthy(Get(D_1264, "small")) ? 1D : (1D + (Max(0D, Min(1D, ((ToNum((Get(D_1264, "lv") is var _t1266 && Truthy(_t1266) ? _t1266 : ((V)(1D)))) - 6D) / 24D))) * 0.9)))));
}, 1, "", true);
Invoke(Object_values(Get(X_8, "CAT")), "forEach", Fn((V _arrowThis1274, int _argc1267, V D_1273, V _a1270, V _a1271, V _a1272, V[] _rest1268) => {
double f_1275 = 0;
if (Truthy((((!(Truthy(GetK(TVZ_98, Get(D_1273, "arch")))) ? V.True : V.False) is var _t1276 && Truthy(_t1276) ? _t1276 : Get(D_1273, "zs")) is var _t1277 && Truthy(_t1277) ? _t1277 : ((SEqS(Get(D_1273, "arch"), "tv") && SEqS(Get(D_1273, "id"), "radio")) ? V.True : V.False)))) {
return default;
}
f_1275 = (ToNum(GetK(TVZ_98, Get(D_1273, "arch"))) * ToNum(Call(TVLV_99, V.Undef, D_1273)));
Set(D_1273, "zs", ((V)(f_1275)));
if (Truthy((Get(D_1273, "mount") is var _t1278 && !Truthy(_t1278) ? _t1278 : Get(D_1273, "elev")))) {
Set(D_1273, "elev", ((V)(Round((ToNum(Get(D_1273, "elev")) / System.Math.Sqrt(ToNum(Call(TVLV_99, V.Undef, D_1273))))))));
}
OpSet(D_1273, "w", 2, ((V)(f_1275)));
OpSet(D_1273, "d", 2, ((V)(f_1275)));
if (Truthy(Get(D_1273, "use"))) {
Set(D_1273, "use", Object_assign(NewObj(0).V, Get(D_1273, "use"), NewObj(2).Put("x", ((V)((ToNum(Get(Get(D_1273, "use"), "x")) * f_1275)))).Put("z", ((V)((ToNum(Get(Get(D_1273, "use"), "z")) * f_1275)))).V));
}
return default;
}, 1, "", true));
DECZ_100 = NewObj(13).Put("poster", ((V)(1.5))).Put("gallery", ((V)(1.5))).Put("wallClock", ((V)(1.5))).Put("mirror", ((V)(1.45))).Put("wallShelf", ((V)(1.35))).Put("sconce", ((V)(1.4))).Put("neonSign", ((V)(1.4))).Put("tableLamp", ((V)(1.3))).Put("bonsai", ((V)(1.4))).Put("succulent", ((V)(1.6))).Put("tankSmall", ((V)(1.35))).Put("consoleSet", ((V)(1.5))).Put("handheld", ((V)(1.6))).V;
Invoke(Object_values(Get(X_8, "CAT")), "forEach", Fn((V _arrowThis1286, int _argc1279, V D_1285, V _a1282, V _a1283, V _a1284, V[] _rest1280) => {
V f_1287 = default;
if (Truthy((Get(D_1285, "zs") is var _t1289 && Truthy(_t1289) ? _t1289 : (!(Truthy((Get(D_1285, "mount") is var _t1288 && Truthy(_t1288) ? _t1288 : Get(D_1285, "small")))) ? V.True : V.False)))) {
return default;
}
f_1287 = (GetK(DECZ_100, Get(D_1285, "arch")) is var _t1291 && Truthy(_t1291) ? _t1291 : ((V)((Truthy(Invoke(NewRegExp(RX0, "^tb", ""), "test", (Get(D_1285, "arch") is var _t1290 && Truthy(_t1290) ? _t1290 : ((V)(""))))) ? 1.55 : 0D))));
if (!(Truthy(f_1287))) {
return default;
}
Set(D_1285, "zs", f_1287);
OpSet(D_1285, "w", 2, f_1287);
OpSet(D_1285, "d", 2, f_1287);
if (Truthy(Get(D_1285, "use"))) {
Set(D_1285, "use", Object_assign(NewObj(0).V, Get(D_1285, "use"), NewObj(2).Put("x", ((V)((ToNum(Get(Get(D_1285, "use"), "x")) * ToNum(f_1287))))).Put("z", ((V)((ToNum(Get(Get(D_1285, "use"), "z")) * ToNum(f_1287))))).V));
}
return default;
}, 1, "", true));
ROOMFIX_101 = NewObj(2).Put("bowl", ((V)("kitchen"))).Put("bar", ((V)("kitchen"))).V;
Invoke(Object_values(Get(X_8, "CAT")), "forEach", Fn((V _arrowThis1299, int _argc1292, V D_1298, V _a1295, V _a1296, V _a1297, V[] _rest1293) => {
V r_1300 = default;
r_1300 = GetK(ROOMFIX_101, Get(D_1298, "arch"));
if (Truthy((r_1300 is var _t1301 && !Truthy(_t1301) ? _t1301 : (!SEq(Get(D_1298, "room"), r_1300) ? V.True : V.False)))) {
Set(D_1298, "room", r_1300);
if (Truthy((Get(D_1298, "cat") is var _t1302 && !Truthy(_t1302) ? _t1302 : (!SEqS(Get(D_1298, "cat"), "style") ? V.True : V.False)))) {
Set(D_1298, "cat", r_1300);
}
}
return default;
}, 1, "", true));
Invoke(Get(X_8, "ITEMS"), "forEach", Fn((V _arrowThis1310, int _argc1303, V m_1309, V _a1306, V _a1307, V _a1308, V[] _rest1304) => {
V r_1311 = default;
r_1311 = ((!(Truthy(Get(m_1309, "surf"))) ? V.True : V.False) is var _t1312 && !Truthy(_t1312) ? _t1312 : GetK(ROOMFIX_101, Get(m_1309, "arch")));
if (Truthy(r_1311)) {
Set(m_1309, "room", r_1311);
}
return default;
}, 1, "", true));
{
double i_1313 = 0;
i_1313 = (ToNum(Get(Get(X_8, "ITEMS"), "length")) - 1D);
while (true) {
if (!((i_1313 >= 0D))) break;
V m_1315 = default;
V S_1316 = default;
m_1315 = GetIdx(Get(X_8, "ITEMS"), i_1313);
S_1316 = GetK(Get(X_8, "SURF"), Get(m_1315, "id"));
if (Truthy((S_1316 is var _t1317 && !Truthy(_t1317) ? _t1317 : (SEqS(Get(S_1316, "arch"), "door") ? V.True : V.False)))) {
Invoke(Get(X_8, "ITEMS"), "splice", ((V)(i_1313)), ((V)(1D)));
}
i_1313--;
}
}
Invoke(Object_values(Get(X_8, "SURF")), "forEach", Fn((V _arrowThis1325, int _argc1318, V S_1324, V _a1321, V _a1322, V _a1323, V[] _rest1319) => {
if (SEqS(Get(S_1324, "arch"), "door")) {
Set(S_1324, "hidden", ((V)(1D)));
}
return default;
}, 1, "", true));
Set(X_8, "EXT", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
