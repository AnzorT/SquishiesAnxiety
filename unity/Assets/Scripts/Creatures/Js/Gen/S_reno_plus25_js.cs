// reno-plus25.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus25_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("^#([0-9a-f]{6})$", "i");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("^#[6-8]", "");
        public static void Run()
        {
Call(Named(boot_121 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V solid_11 = default;
V ball_12 = default;
V box_13 = default;
V cyl_14 = default;
V cush_15 = default;
V arcW_16 = default;
V pillowZ_17 = default;
V shade_18 = default;
V mix_19 = default;
V f1_20 = default;
V N_21 = default;
double PI_22 = 0;
V GOLD_23 = default;
V dec_24 = default;
V spot_25 = default;
V at_26 = default;
V glue_27 = default;
V R0_28 = default;
V rep_29 = default;
V add_30 = default;
V sub_31 = default;
V mul_32 = default;
V dt_33 = default;
V cr_34 = default;
V nz_35 = default;
V X3_36 = default;
V Y3_37 = default;
V bbS_38 = default;
V fr2_39 = default;
V area_40 = default;
V shrinkP_41 = default;
V clip_42 = default;
V inP_43 = default;
V ext2_44 = default;
V hatch_45 = default;
V wavy_46 = default;
V outline_47 = default;
V dots_48 = default;
V ringL_49 = default;
V caps_50 = default;
V sides_51 = default;
V isFab_52 = default;
V padFx_53 = default;
V splitL_54 = default;
V mergeBB_55 = default;
V knit_56 = default;
V levTex_57 = default;
V velvet_58 = default;
V chesTex_59 = default;
V apronTex_60 = default;
V CF_61 = default;
V thrTex_62 = default;
V gyro_63 = default;
V mvPts_64 = default;
V thrFix_65 = default;
V thrGlue_66 = default;
V grain_67 = default;
V chesWrap_68 = default;
V F0of_69 = default;
V leaTex_70 = default;
V leaBase_71 = default;
V bouTex_72 = default;
V bouBase_73 = default;
V shearTex_74 = default;
V isDec_75 = default;
V lumOf_76 = default;
V mtex_77 = default;
V texWrap_78 = default;
V pitPil_79 = default;
V roles_80 = default;
V UPH_81 = default;
V bigF_82 = default;
V fleck_83 = default;
V WH2_84 = default;
V crease_85 = default;
V frontF_86 = default;
V stitchRing_87 = default;
V sideOf_88 = default;
V armThrow_89 = default;
V rsWrap_90 = default;
V plaidTex_91 = default;
V scanTex_92 = default;
V cogTex_93 = default;
V velTex_94 = default;
V foldTex_95 = default;
V wingGlue_96 = default;
V wingTex_97 = default;
V cylPt_98 = default;
V ringD_99 = default;
V chesRA_100 = default;
V rollTop_101 = default;
V velX_102 = default;
V leaX_103 = default;
V bouX_104 = default;
V chesX_105 = default;
V AL62_106 = default;
V PF_107 = default;
V pfP_108 = default;
V pfL_109 = default;
V POUFK_110 = default;
V hexRGB_111 = default;
V pfKind_112 = default;
V luxFix_113 = default;
V edit24_114 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((((RD_8 is var _t115 && !Truthy(_t115) ? _t115 : Get(RD_8, "PLUS24")) is var _t116 && !Truthy(_t116) ? _t116 : Get(RD_8, "H24")) is var _t117 && !Truthy(_t117) ? _t117 : Get(RD_8, "H22")) is var _t118 && !Truthy(_t118) ? _t118 : Get(RD_8, "H16")) is var _t119 && !Truthy(_t119) ? _t119 : X_9) is var _t120 && !Truthy(_t120) ? _t120 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_121.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS25"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t122 = K_10;
if (_t122.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t122));
{ V _t123 = Get(_t122, "solid");
solid_11 = _t123; }
{ V _t124 = Get(_t122, "ball");
ball_12 = _t124; }
{ V _t125 = Get(_t122, "box");
box_13 = _t125; }
{ V _t126 = Get(_t122, "cyl");
cyl_14 = _t126; }
{ V _t127 = Get(_t122, "cush");
cush_15 = _t127; }
{ V _t128 = Get(_t122, "arcW");
arcW_16 = _t128; }
{ V _t129 = Get(_t122, "pillowZ");
pillowZ_17 = _t129; }
{ V _t130 = Get(_t122, "shade");
shade_18 = _t130; }
{ V _t131 = Get(_t122, "mix");
mix_19 = _t131; }
{ V _t132 = Get(_t122, "f1");
f1_20 = _t132; } }
N_21 = Get(RD_8, "N");
PI_22 = System.Math.PI;
GOLD_23 = ((V)("#e2b14a"));
{ V _t133 = Get(RD_8, "H24");
if (_t133.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t133));
{ V _t134 = Get(_t133, "dec");
dec_24 = _t134; }
{ V _t135 = Get(_t133, "spot");
spot_25 = _t135; }
{ V _t136 = Get(_t133, "at");
at_26 = _t136; } }
{ V _t137 = Get(RD_8, "H22");
if (_t137.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t137));
{ V _t138 = Get(_t137, "glue");
glue_27 = _t138; }
{ V _t139 = Get(_t137, "R0");
R0_28 = _t139; } }
{ V _t140 = Get(RD_8, "H16");
if (_t140.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t140));
{ V _t141 = Get(_t140, "rep");
rep_29 = _t141; } }
add_30 = Fn((V _arrowThis150, int _argc142, V a_148, V b_149, V _a146, V _a147, V[] _rest143) => {
return Arr(Add(GetIdx(a_148, 0D), GetIdx(b_149, 0D)), Add(GetIdx(a_148, 1D), GetIdx(b_149, 1D)), Add(GetIdx(a_148, 2D), GetIdx(b_149, 2D)));
}, 2, "", true);
sub_31 = Fn((V _arrowThis159, int _argc151, V a_157, V b_158, V _a155, V _a156, V[] _rest152) => {
return Arr(((V)((ToNum(GetIdx(a_157, 0D)) - ToNum(GetIdx(b_158, 0D))))), ((V)((ToNum(GetIdx(a_157, 1D)) - ToNum(GetIdx(b_158, 1D))))), ((V)((ToNum(GetIdx(a_157, 2D)) - ToNum(GetIdx(b_158, 2D))))));
}, 2, "", true);
mul_32 = Fn((V _arrowThis168, int _argc160, V a_166, V k_167, V _a164, V _a165, V[] _rest161) => {
return Arr(((V)((ToNum(GetIdx(a_166, 0D)) * ToNum(k_167)))), ((V)((ToNum(GetIdx(a_166, 1D)) * ToNum(k_167)))), ((V)((ToNum(GetIdx(a_166, 2D)) * ToNum(k_167)))));
}, 2, "", true);
dt_33 = Fn((V _arrowThis177, int _argc169, V a_175, V b_176, V _a173, V _a174, V[] _rest170) => {
return ((V)((((ToNum(GetIdx(a_175, 0D)) * ToNum(GetIdx(b_176, 0D))) + (ToNum(GetIdx(a_175, 1D)) * ToNum(GetIdx(b_176, 1D)))) + (ToNum(GetIdx(a_175, 2D)) * ToNum(GetIdx(b_176, 2D))))));
}, 2, "", true);
cr_34 = Fn((V _arrowThis186, int _argc178, V a_184, V b_185, V _a182, V _a183, V[] _rest179) => {
return Arr(((V)(((ToNum(GetIdx(a_184, 1D)) * ToNum(GetIdx(b_185, 2D))) - (ToNum(GetIdx(a_184, 2D)) * ToNum(GetIdx(b_185, 1D)))))), ((V)(((ToNum(GetIdx(a_184, 2D)) * ToNum(GetIdx(b_185, 0D))) - (ToNum(GetIdx(a_184, 0D)) * ToNum(GetIdx(b_185, 2D)))))), ((V)(((ToNum(GetIdx(a_184, 0D)) * ToNum(GetIdx(b_185, 1D))) - (ToNum(GetIdx(a_184, 1D)) * ToNum(GetIdx(b_185, 0D)))))));
}, 2, "", true);
nz_35 = Fn((V _arrowThis194, int _argc187, V a_193, V _a190, V _a191, V _a192, V[] _rest188) => {
V L_195 = default;
L_195 = (((V)(Hypot(ToNum(GetIdx(a_193, 0D)), ToNum(GetIdx(a_193, 1D)), ToNum(GetIdx(a_193, 2D))))) is var _t196 && Truthy(_t196) ? _t196 : ((V)(1D)));
return Arr(((V)((ToNum(GetIdx(a_193, 0D)) / ToNum(L_195)))), ((V)((ToNum(GetIdx(a_193, 1D)) / ToNum(L_195)))), ((V)((ToNum(GetIdx(a_193, 2D)) / ToNum(L_195)))));
return default;
}, 1, "", true);
X3_36 = Arr(((V)(1D)), ((V)(0D)), ((V)(0D)));
Y3_37 = Arr(((V)(0D)), ((V)(1D)), ((V)(0D)));
bbS_38 = Fn((V _arrowThis204, int _argc197, V S_203, V _a200, V _a201, V _a202, V[] _rest198) => {
V L_205 = default;
L_205 = Arr(((V)(1000000000D)), ((V)((-1000000000D))), ((V)(1000000000D)), ((V)((-1000000000D))), ((V)(1000000000D)), ((V)((-1000000000D))));
Invoke(Get(S_203, "pts"), "forEach", Fn((V _arrowThis213, int _argc206, V p_212, V _a209, V _a210, V _a211, V[] _rest207) => {
{
double k_214 = 0;
k_214 = 0D;
while (true) {
if (!((k_214 < 3D))) break;
if (Lt(GetIdx(p_212, k_214), GetIdx(L_205, (2D * k_214)))) {
SetIdx(L_205, (2D * k_214), GetIdx(p_212, k_214));
}
if (Gt(GetIdx(p_212, k_214), GetIdx(L_205, ((2D * k_214) + 1D)))) {
SetIdx(L_205, ((2D * k_214) + 1D), GetIdx(p_212, k_214));
}
k_214++;
}
}
return default;
}, 1, "", true));
return L_205;
return default;
}, 1, "", true);
fr2_39 = Fn((V _arrowThis223, int _argc216, V F_222, V _a219, V _a220, V _a221, V[] _rest217) => {
V n_224 = default;
V u_225 = default;
V v_226 = default;
V o_227 = default;
n_224 = Get(F_222, "n");
u_225 = ((System.Math.Abs(ToNum(GetIdx(n_224, 1D))) > 0.9) ? X3_36 : Call(nz_35, V.Undef, Call(cr_34, V.Undef, Y3_37, n_224)));
v_226 = Call(nz_35, V.Undef, Call(cr_34, V.Undef, n_224, u_225));
o_227 = Invoke(Get(F_222, "q"), "reduce", Fn((V _arrowThis236, int _argc228, V a_234, V p_235, V _a232, V _a233, V[] _rest229) => {
return Call(add_30, V.Undef, a_234, Call(mul_32, V.Undef, p_235, ((V)((1D / ToNum(Get(Get(F_222, "q"), "length")))))));
}, 2, "", true), Arr(((V)(0D)), ((V)(0D)), ((V)(0D))));
return NewObj(6).Put("n", n_224).Put("u", u_225).Put("v", v_226).Put("o", o_227).Put("P", Invoke(Get(F_222, "q"), "map", Fn((V _arrowThis244, int _argc237, V p_243, V _a240, V _a241, V _a242, V[] _rest238) => {
V d_245 = default;
d_245 = Call(sub_31, V.Undef, p_243, o_227);
return Arr(Call(dt_33, V.Undef, d_245, u_225), Call(dt_33, V.Undef, d_245, v_226));
return default;
}, 1, "", true))).Put("at", Fn((V _arrowThis254, int _argc246, V a_252, V b_253, V _a250, V _a251, V[] _rest247) => {
return Call(add_30, V.Undef, o_227, Call(add_30, V.Undef, Call(mul_32, V.Undef, u_225, a_252), Call(mul_32, V.Undef, v_226, b_253)));
}, 2, "at", true)).V;
return default;
}, 1, "", true);
area_40 = Fn((V _arrowThis262, int _argc255, V P_261, V _a258, V _a259, V _a260, V[] _rest256) => {
double s_263 = 0;
s_263 = 0D;
{
double i_264 = 0;
i_264 = 0D;
while (true) {
if (!(Lt(((V)(i_264)), Get(P_261, "length")))) break;
V a_266 = default;
V b_267 = default;
a_266 = GetIdx(P_261, i_264);
b_267 = GetIdx(P_261, ((i_264 + 1D) % ToNum(Get(P_261, "length"))));
s_263 = (s_263 + ((ToNum(GetIdx(a_266, 0D)) * ToNum(GetIdx(b_267, 1D))) - (ToNum(GetIdx(b_267, 0D)) * ToNum(GetIdx(a_266, 1D)))));
i_264++;
}
}
return ((V)((s_263 / 2D)));
return default;
}, 1, "", true);
shrinkP_41 = Fn((V _arrowThis276, int _argc268, V P_274, V k_275, V _a272, V _a273, V[] _rest269) => {
return Invoke(P_274, "map", Fn((V _arrowThis284, int _argc277, V p_283, V _a280, V _a281, V _a282, V[] _rest278) => {
return Arr(((V)((ToNum(GetIdx(p_283, 0D)) * ToNum(k_275)))), ((V)((ToNum(GetIdx(p_283, 1D)) * ToNum(k_275)))));
}, 1, "", true));
}, 2, "", true);
clip_42 = Fn((V _arrowThis294, int _argc285, V P_291, V A_292, V B_293, V _a290, V[] _rest286) => {
double t0_295 = 0;
double t1_296 = 0;
V d_297 = default;
double sg_298 = 0;
t0_295 = 0D;
t1_296 = 1D;
d_297 = Arr(((V)((ToNum(GetIdx(B_293, 0D)) - ToNum(GetIdx(A_292, 0D))))), ((V)((ToNum(GetIdx(B_293, 1D)) - ToNum(GetIdx(A_292, 1D))))));
sg_298 = (GtN(Call(area_40, V.Undef, P_291), 0D) ? 1D : (-1D));
{
double i_299 = 0;
i_299 = 0D;
while (true) {
if (!(Lt(((V)(i_299)), Get(P_291, "length")))) break;
V p_301 = default;
V q_302 = default;
V e_303 = default;
V nn_304 = default;
double num_305 = 0;
double den_306 = 0;
double t_307 = 0;
p_301 = GetIdx(P_291, i_299);
q_302 = GetIdx(P_291, ((i_299 + 1D) % ToNum(Get(P_291, "length"))));
e_303 = Arr(((V)((ToNum(GetIdx(q_302, 0D)) - ToNum(GetIdx(p_301, 0D))))), ((V)((ToNum(GetIdx(q_302, 1D)) - ToNum(GetIdx(p_301, 1D))))));
nn_304 = ((sg_298 > 0D) ? Arr(((V)((-ToNum(GetIdx(e_303, 1D))))), GetIdx(e_303, 0D)) : Arr(GetIdx(e_303, 1D), ((V)((-ToNum(GetIdx(e_303, 0D)))))));
num_305 = ((ToNum(GetIdx(nn_304, 0D)) * (ToNum(GetIdx(A_292, 0D)) - ToNum(GetIdx(p_301, 0D)))) + (ToNum(GetIdx(nn_304, 1D)) * (ToNum(GetIdx(A_292, 1D)) - ToNum(GetIdx(p_301, 1D)))));
den_306 = ((ToNum(GetIdx(nn_304, 0D)) * ToNum(GetIdx(d_297, 0D))) + (ToNum(GetIdx(nn_304, 1D)) * ToNum(GetIdx(d_297, 1D))));
if ((System.Math.Abs(den_306) < 1.0e-9)) {
if ((num_305 < 0D)) {
return V.Null;
}
goto _cont300;
}
t_307 = ((-num_305) / den_306);
if ((den_306 > 0D)) {
t0_295 = Max(t0_295, t_307);
} else {
t1_296 = Min(t1_296, t_307);
}
if ((t0_295 >= t1_296)) {
return V.Null;
}
_cont300: ;
i_299++;
}
}
return Arr(Arr(Add(GetIdx(A_292, 0D), ((V)((ToNum(GetIdx(d_297, 0D)) * t0_295)))), Add(GetIdx(A_292, 1D), ((V)((ToNum(GetIdx(d_297, 1D)) * t0_295))))), Arr(Add(GetIdx(A_292, 0D), ((V)((ToNum(GetIdx(d_297, 0D)) * t1_296)))), Add(GetIdx(A_292, 1D), ((V)((ToNum(GetIdx(d_297, 1D)) * t1_296))))));
return default;
}, 3, "", true);
inP_43 = Fn((V _arrowThis316, int _argc308, V P_314, V x_315, V _a312, V _a313, V[] _rest309) => {
double sg_317 = 0;
sg_317 = (GtN(Call(area_40, V.Undef, P_314), 0D) ? 1D : (-1D));
{
double i_318 = 0;
i_318 = 0D;
while (true) {
if (!(Lt(((V)(i_318)), Get(P_314, "length")))) break;
V p_320 = default;
V q_321 = default;
p_320 = GetIdx(P_314, i_318);
q_321 = GetIdx(P_314, ((i_318 + 1D) % ToNum(Get(P_314, "length"))));
if (((sg_317 * (((ToNum(GetIdx(q_321, 0D)) - ToNum(GetIdx(p_320, 0D))) * (ToNum(GetIdx(x_315, 1D)) - ToNum(GetIdx(p_320, 1D)))) - ((ToNum(GetIdx(q_321, 1D)) - ToNum(GetIdx(p_320, 1D))) * (ToNum(GetIdx(x_315, 0D)) - ToNum(GetIdx(p_320, 0D)))))) < 0D)) {
return (false ? V.True : V.False);
}
i_318++;
}
}
return (true ? V.True : V.False);
return default;
}, 2, "", true);
ext2_44 = Fn((V _arrowThis329, int _argc322, V P_328, V _a325, V _a326, V _a327, V[] _rest323) => {
return Invoke(P_328, "reduce", Fn((V _arrowThis338, int _argc330, V m_336, V p_337, V _a334, V _a335, V[] _rest331) => {
return ((V)(Max(ToNum(m_336), Hypot(ToNum(GetIdx(p_337, 0D)), ToNum(GetIdx(p_337, 1D))))));
}, 2, "", true), ((V)(0D)));
}, 1, "", true);
hatch_45 = Fn((V _arrowThis351, int _argc339, V Ds_345, V F_346, V ang_347, V sp_348, V[] _rest340) => {
V G_352 = default;
V P_353 = default;
V R_354 = default;
V dir_355 = default;
V m_356 = default;
V m3_357 = default;
double off_358 = 0;
V L_359 = default;
double k_360 = 0;
double c_361 = 0;
V w_349 = default;
V o_350 = default;
w_349 = (_argc339 > 4 ? _rest340[0] : V.Undef);
o_350 = (_argc339 > 5 ? _rest340[1] : V.Undef);
o_350 = (o_350 is var _t362 && Truthy(_t362) ? _t362 : NewObj(0).V);
G_352 = Call(fr2_39, V.Undef, F_346);
P_353 = Call(shrinkP_41, V.Undef, Get(G_352, "P"), (Get(o_350, "sh") is var _t363 && Truthy(_t363) ? _t363 : ((V)(0.96))));
R_354 = Add(Call(ext2_44, V.Undef, P_353), sp_348);
dir_355 = Arr(((V)(FdLibm.Cos(ToNum(ang_347)))), ((V)(FdLibm.Sin(ToNum(ang_347)))));
m_356 = Arr(((V)((-ToNum(GetIdx(dir_355, 1D))))), GetIdx(dir_355, 0D));
m3_357 = Call(add_30, V.Undef, Call(mul_32, V.Undef, Get(G_352, "u"), GetIdx(m_356, 0D)), Call(mul_32, V.Undef, Get(G_352, "v"), GetIdx(m_356, 1D)));
off_358 = (ToNum(Add(((V)((ToNum(Add(Call(dt_33, V.Undef, Get(G_352, "o"), m3_357), (Get(o_350, "ph") is var _t364 && Truthy(_t364) ? _t364 : ((V)(0D))))) % ToNum(sp_348)))), sp_348)) % ToNum(sp_348));
L_359 = ((Ds_345.O is JsArray) ? Ds_345 : Arr(Ds_345));
k_360 = System.Math.Floor((ToNum(Add(Call(dt_33, V.Undef, Get(G_352, "o"), m3_357), (Get(o_350, "ph") is var _t365 && Truthy(_t365) ? _t365 : ((V)(0D))))) / ToNum(sp_348)));
c_361 = 0D;
{
V s_366 = default;
s_366 = ((V)(((-ToNum(R_354)) - off_358)));
while (true) {
if (!(Le(s_366, R_354))) break;
V A_368 = default;
V B_369 = default;
V C_370 = default;
A_368 = Arr(((V)(((ToNum(GetIdx(m_356, 0D)) * ToNum(s_366)) - (ToNum(GetIdx(dir_355, 0D)) * ToNum(R_354))))), ((V)(((ToNum(GetIdx(m_356, 1D)) * ToNum(s_366)) - (ToNum(GetIdx(dir_355, 1D)) * ToNum(R_354))))));
B_369 = Arr(((V)(((ToNum(GetIdx(m_356, 0D)) * ToNum(s_366)) + (ToNum(GetIdx(dir_355, 0D)) * ToNum(R_354))))), ((V)(((ToNum(GetIdx(m_356, 1D)) * ToNum(s_366)) + (ToNum(GetIdx(dir_355, 1D)) * ToNum(R_354))))));
C_370 = Call(clip_42, V.Undef, P_353, A_368, B_369);
if (!(Truthy(C_370))) {
goto _cont367;
}
if (Lt(((V)(Hypot((ToNum(GetIdx(GetIdx(C_370, 1D), 0D)) - ToNum(GetIdx(GetIdx(C_370, 0D), 0D))), (ToNum(GetIdx(GetIdx(C_370, 1D), 1D)) - ToNum(GetIdx(GetIdx(C_370, 0D), 1D)))))), (Get(o_350, "min") is var _t371 && Truthy(_t371) ? _t371 : ((V)(0.6))))) {
goto _cont367;
}
Invoke(GetIdx(L_359, (ToNum(Add(((V)((k_360 % ToNum(Get(L_359, "length"))))), Get(L_359, "length"))) % ToNum(Get(L_359, "length")))), "line", Arr(InvokeSpread(G_352, "at", new ArrBuilder().Spread(GetIdx(C_370, 0D)).V), InvokeSpread(G_352, "at", new ArrBuilder().Spread(GetIdx(C_370, 1D)).V)), Get(G_352, "n"), w_349);
c_361++;
_cont367: ;
s_366 = Add(s_366, sp_348);
k_360++;
}
}
return ((V)(c_361));
return default;
}, 6, "", true);
wavy_46 = Fn((V _arrowThis384, int _argc372, V D_378, V F_379, V f_380, V m_381, V[] _rest373) => {
V G_385 = default;
V P_386 = default;
V run_387 = default;
V flush_388 = default;
V w_382 = default;
V taper_383 = default;
w_382 = (_argc372 > 4 ? _rest373[0] : V.Undef);
taper_383 = (_argc372 > 5 ? _rest373[1] : V.Undef);
G_385 = Call(fr2_39, V.Undef, F_379);
P_386 = Call(shrinkP_41, V.Undef, Get(G_385, "P"), ((V)(0.94)));
run_387 = Arr();
flush_388 = Fn((V _arrowThis395, int _argc389, V _a391, V _a392, V _a393, V _a394, V[] _rest390) => {
if (GtN(Get(run_387, "length"), 1D)) {
Invoke(D_378, "line", run_387, Get(G_385, "n"), w_382, taper_383);
}
run_387 = Arr();
return default;
}, 0, "", true);
{
double i_396 = 0;
i_396 = 0D;
while (true) {
if (!(Le(((V)(i_396)), m_381))) break;
V q_398 = default;
q_398 = Call(f_380, V.Undef, ((V)((i_396 / ToNum(m_381)))), G_385);
if (Truthy((q_398 is var _t399 && !Truthy(_t399) ? _t399 : Call(inP_43, V.Undef, P_386, q_398)))) {
Invoke(run_387, "push", Invoke(G_385, "at", GetIdx(q_398, 0D), GetIdx(q_398, 1D)));
} else {
Call(flush_388, V.Undef);
}
i_396++;
}
}
Call(flush_388, V.Undef);
return default;
}, 6, "", true);
outline_47 = Fn((V _arrowThis410, int _argc400, V D_406, V F_407, V k_408, V w_409, V[] _rest401) => {
V G_411 = default;
V P_412 = default;
G_411 = Call(fr2_39, V.Undef, F_407);
P_412 = Call(shrinkP_41, V.Undef, Get(G_411, "P"), k_408);
Invoke(D_406, "line", Invoke(Invoke(P_412, "concat", Arr(GetIdx(P_412, 0D))), "map", Fn((V _arrowThis420, int _argc413, V p_419, V _a416, V _a417, V _a418, V[] _rest414) => {
return Invoke(G_411, "at", GetIdx(p_419, 0D), GetIdx(p_419, 1D));
}, 1, "", true)), Get(G_411, "n"), w_409);
return default;
}, 4, "", true);
dots_48 = Fn((V _arrowThis432, int _argc421, V D_427, V F_428, V sp_429, V r_430, V[] _rest422) => {
V G_433 = default;
V P_434 = default;
V R_435 = default;
double c_436 = 0;
V o_431 = default;
o_431 = (_argc421 > 4 ? _rest422[0] : V.Undef);
o_431 = (o_431 is var _t437 && Truthy(_t437) ? _t437 : NewObj(0).V);
G_433 = Call(fr2_39, V.Undef, F_428);
P_434 = Call(shrinkP_41, V.Undef, Get(G_433, "P"), (Get(o_431, "sh") is var _t438 && Truthy(_t438) ? _t438 : ((V)(0.9))));
R_435 = Call(ext2_44, V.Undef, P_434);
c_436 = 0D;
{
V a_439 = default;
a_439 = ((V)((-ToNum(R_435))));
while (true) {
if (!(Le(a_439, R_435))) break;
{
double b_441 = 0;
b_441 = (-ToNum(R_435));
while (true) {
if (!(Le(((V)(b_441)), R_435))) break;
V q_443 = default;
q_443 = Arr(Add(Add(a_439, ((V)((Truthy((((V)((Round((ToNum(Add(((V)(b_441)), R_435)) / (ToNum(sp_429) * ToNum((Get(o_431, "ry") is var _t444 && Truthy(_t444) ? _t444 : ((V)(1D))))))) % 2D))) is var _t445 && !Truthy(_t445) ? _t445 : Get(o_431, "stag"))) ? (ToNum(sp_429) / 2D) : 0D)))), (Truthy(Get(o_431, "off")) ? GetIdx(Get(o_431, "off"), 0D) : ((V)(0D)))), Add(((V)(b_441)), (Truthy(Get(o_431, "off")) ? GetIdx(Get(o_431, "off"), 1D) : ((V)(0D)))));
if (!(Truthy(Call(inP_43, V.Undef, P_434, q_443)))) {
goto _cont442;
}
Call(spot_25, V.Undef, D_427, Invoke(G_433, "at", GetIdx(q_443, 0D), GetIdx(q_443, 1D)), Get(G_433, "n"), r_430, r_430, ((V)(0D)), (Get(o_431, "m") is var _t446 && Truthy(_t446) ? _t446 : ((V)(6D))));
c_436++;
_cont442: ;
b_441 = (b_441 + (ToNum(sp_429) * ToNum((Get(o_431, "ry") is var _t447 && Truthy(_t447) ? _t447 : ((V)(1D))))));
}
}
a_439 = Add(a_439, sp_429);
}
}
return ((V)(c_436));
return default;
}, 5, "", true);
ringL_49 = Fn((V _arrowThis460, int _argc448, V D_454, V S_455, V k_456, V nr_457, V[] _rest449) => {
double n_461 = 0;
V R_462 = default;
V c_463 = default;
V Nn_464 = default;
V P_465 = default;
V w_458 = default;
V up_459 = default;
w_458 = (_argc448 > 4 ? _rest449[0] : V.Undef);
up_459 = (_argc448 > 5 ? _rest449[1] : V.Undef);
n_461 = (ToNum(Get(Get(S_455, "pts"), "length")) / ToNum(nr_457));
R_462 = Invoke(Get(S_455, "pts"), "slice", ((V)((ToNum(k_456) * n_461))), ((V)((ToNum(Add(k_456, ((V)(1D)))) * n_461))));
if (LtN(Get(R_462, "length"), 3D)) {
return default;
}
c_463 = Invoke(R_462, "reduce", Fn((V _arrowThis474, int _argc466, V a_472, V p_473, V _a470, V _a471, V[] _rest467) => {
return Call(add_30, V.Undef, a_472, Call(mul_32, V.Undef, p_473, ((V)((1D / ToNum(Get(R_462, "length")))))));
}, 2, "", true), Arr(((V)(0D)), ((V)(0D)), ((V)(0D))));
Nn_464 = Invoke(R_462, "map", Fn((V _arrowThis482, int _argc475, V p_481, V _a478, V _a479, V _a480, V[] _rest476) => {
return Call(nz_35, V.Undef, Call(add_30, V.Undef, Call(sub_31, V.Undef, p_481, c_463), Call(mul_32, V.Undef, Y3_37, (up_459.IsNullish ? ((V)(0.4)) : up_459))));
}, 1, "", true));
P_465 = Invoke(R_462, "map", Fn((V _arrowThis491, int _argc483, V p_489, V i_490, V _a487, V _a488, V[] _rest484) => {
return Call(add_30, V.Undef, p_489, Call(mul_32, V.Undef, GetK(Nn_464, i_490), ((V)(0.12))));
}, 2, "", true));
Invoke(D_454, "line", Invoke(P_465, "concat", Arr(GetIdx(P_465, 0D))), Invoke(Nn_464, "concat", Arr(GetIdx(Nn_464, 0D))), w_458);
return default;
}, 6, "", true);
caps_50 = Fn((V _arrowThis500, int _argc492, V S_498, V c_499, V _a496, V _a497, V[] _rest493) => {
return Invoke(Get(S_498, "faces"), "filter", Fn((V _arrowThis508, int _argc501, V F_507, V _a504, V _a505, V _a506, V[] _rest502) => {
return (SEq(Get(F_507, "cap"), c_499) ? V.True : V.False);
}, 1, "", true));
}, 2, "", true);
sides_51 = Fn((V _arrowThis517, int _argc509, V S_515, V minV_516, V _a513, V _a514, V[] _rest510) => {
return Invoke(Get(S_515, "faces"), "filter", Fn((V _arrowThis525, int _argc518, V F_524, V _a521, V _a522, V _a523, V[] _rest519) => {
return (((!(Truthy(Get(F_524, "cap"))) && SEqN(Get(Get(F_524, "q"), "length"), 4D)) && Ge(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(F_524, "q"), 3D), GetIdx(Get(F_524, "q"), 0D))).V), (minV_516 is var _t526 && Truthy(_t526) ? _t526 : ((V)(0D))))) ? V.True : V.False);
}, 1, "", true));
}, 2, "", true);
isFab_52 = Fn((V _arrowThis535, int _argc527, V S_533, V P_534, V _a531, V _a532, V[] _rest528) => {
return (((SEq(Get(S_533, "col"), Get(P_534, "a")) || SEq(Get(S_533, "col"), Get(P_534, "aL"))) || SEq(Get(S_533, "col"), Get(P_534, "aD"))) ? V.True : V.False);
}, 2, "", true);
padFx_53 = Fn((V _arrowThis548, int _argc536, V c_542, V a_543, V b_544, V lift_545, V[] _rest537) => {
V p_549 = default;
double m_550 = 0;
V E_551 = default;
V path_552 = default;
V O_553 = default;
V PD_554 = default;
V IN_555 = default;
V q0_556 = default;
V q1_557 = default;
V dy_558 = default;
JsStrBuf s_559 = null;
V xs_560 = default;
V ys_561 = default;
V id_546 = default;
V col_547 = default;
id_546 = (_argc536 > 4 ? _rest537[0] : V.Undef);
col_547 = (_argc536 > 5 ? _rest537[1] : V.Undef);
p_549 = Get(c_542, "p");
m_550 = 40D;
E_551 = Fn((V _arrowThis570, int _argc562, V s_568, V y_569, V _a566, V _a567, V[] _rest563) => {
return Call(rep_29, V.Undef, ((V)(m_550)), Fn((V _arrowThis578, int _argc571, V i_577, V _a574, V _a575, V _a576, V[] _rest572) => {
double t_579 = 0;
t_579 = (((ToNum(i_577) / m_550) * 2D) * PI_22);
return Call(p_549, V.Undef, ((V)(((FdLibm.Cos(t_579) * ToNum(a_543)) * ToNum(s_568)))), y_569, ((V)(((FdLibm.Sin(t_579) * ToNum(b_544)) * ToNum(s_568)))));
return default;
}, 1, "", true));
}, 2, "", true);
path_552 = Fn((V _arrowThis587, int _argc580, V Q_586, V _a583, V _a584, V _a585, V[] _rest581) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Q_586, "map", Fn((V _arrowThis595, int _argc588, V q_594, V _a591, V _a592, V _a593, V[] _rest589) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(q_594, 0D))).S(" ").V(Call(f1_20, V.Undef, GetIdx(q_594, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
O_553 = Call(E_551, V.Undef, ((V)(1.18)), ((V)(0D)));
PD_554 = Call(E_551, V.Undef, ((V)(1D)), ((V)(0D)));
IN_555 = Call(E_551, V.Undef, ((V)(0.8)), ((V)(0.4)));
q0_556 = Call(p_549, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
q1_557 = Call(p_549, V.Undef, ((V)(0D)), lift_545, ((V)(0D)));
dy_558 = Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q1_557, 1D)) - ToNum(GetIdx(q0_556, 1D))))));
s_559 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Call(path_552, V.Undef, O_553)).S("\" fill=\"url(#").V(id_546).S("gl)\" opacity=\"0.6\"><animate attributeName=\"opacity\" values=\"0.35;0.75;0.35\" dur=\"3.2s\" repeatCount=\"indefinite\"/></path>").S("<path d=\"").V(Call(path_552, V.Undef, PD_554)).S("\" fill=\"url(#").V(id_546).S("pd)\" stroke=\"#0d0f14\" stroke-width=\"0.8\"/><path d=\"").V(Call(path_552, V.Undef, IN_555)).S("\" fill=\"none\" stroke=\"").V(col_547).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(c_542, "k")) * 0.9))))).S("\" opacity=\"0.9\"/>").S("<path d=\"").V(Call(path_552, V.Undef, Call(E_551, V.Undef, ((V)(0.62)), ((V)(0.4))))).S("\" fill=\"none\" stroke=\"").V(col_547).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(c_542, "k")) * 0.35))))).S("\" stroke-dasharray=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(c_542, "k")) * 2D))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(c_542, "k")) * 3D))))).S("\" opacity=\"0.7\"><animate attributeName=\"stroke-dashoffset\" values=\"0;").V(Call(f1_20, V.Undef, ((V)(((-ToNum(Get(c_542, "k"))) * 25D))))).S("\" dur=\"2.4s\" repeatCount=\"indefinite\"/></path>").End());
Invoke(Arr(((V)(0D)), ((V)(1D))), "forEach", Fn((V _arrowThis603, int _argc596, V i_602, V _a599, V _a600, V _a601, V[] _rest597) => {
s_559.S("<path d=\"").V(Call(path_552, V.Undef, Call(E_551, V.Undef, ((V)((0.7 - (ToNum(i_602) * 0.12)))), ((V)(0.6))))).S("\" fill=\"none\" stroke=\"").V(col_547).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(c_542, "k")) * 0.5))))).S("\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0.7;0\" dur=\"2.6s\" begin=\"").N(((-ToNum(i_602)) * 1.3)).S("s\" repeatCount=\"indefinite\"/><animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;0 ").V(dy_558).S("\" dur=\"2.6s\" begin=\"").N(((-ToNum(i_602)) * 1.3)).S("s\" repeatCount=\"indefinite\"/></path>");
return default;
}, 1, "", true));
xs_560 = Invoke(O_553, "map", Fn((V _arrowThis611, int _argc604, V q_610, V _a607, V _a608, V _a609, V[] _rest605) => {
return GetIdx(q_610, 0D);
}, 1, "", true));
ys_561 = Invoke(O_553, "map", Fn((V _arrowThis619, int _argc612, V q_618, V _a615, V _a616, V _a617, V[] _rest613) => {
return GetIdx(q_618, 1D);
}, 1, "", true));
return NewObj(3).Put("svg", ((V)(s_559.Str))).Put("bb", Arr(((V)((ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_560).V)) - 2D))), ((V)((ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_561).V)) - 2D))), Add(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_560).V), ((V)(2D))), Add(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_561).V), ((V)(2D))))).Put("defs", ((V)(JsStrBuf.Begin().S("<radialGradient id=\"").V(id_546).S("gl\"><stop offset=\"0.55\" stop-color=\"").V(col_547).S("\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"").V(col_547).S("\" stop-opacity=\"0\"/></radialGradient>").S("<radialGradient id=\"").V(id_546).S("pd\" cx=\"42%\" cy=\"38%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#3a3f4a\"/><stop offset=\"0.6\" stop-color=\"#1b1e25\"/><stop offset=\"1\" stop-color=\"#0b0c10\"/></radialGradient>").End()))).V;
return default;
}, 6, "", true);
splitL_54 = Fn((V _arrowThis627, int _argc620, V B_626, V _a623, V _a624, V _a625, V[] _rest621) => {
V L0_628 = default;
L0_628 = (Truthy((Get(B_626, "layers") is var _t629 && !Truthy(_t629) ? _t629 : (SEqN(Get(Get(B_626, "layers"), "length"), 1D) ? V.True : V.False))) ? GetIdx(Get(B_626, "layers"), 0D) : V.Null);
return (Truthy(L0_628) ? Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis637, int _argc630, V k_636, V _a633, V _a634, V _a635, V[] _rest631) => {
return Object_assign(NewObj(0).V, L0_628, NewObj(1).Put("build", Fn((V _arrowThis645, int _argc638, V P_644, V _a641, V _a642, V _a643, V[] _rest639) => {
V all_646 = default;
V isS_647 = default;
V inS_648 = default;
all_646 = Invoke(L0_628, "build", P_644);
isS_647 = Fn((V _arrowThis656, int _argc649, V Q_655, V _a652, V _a653, V _a654, V[] _rest650) => {
return ((SEq(Get(Q_655, "col"), Get(P_644, "a")) && ((ToNum(GetIdx(Call(bbS_38, V.Undef, Q_655), 1D)) - ToNum(GetIdx(Call(bbS_38, V.Undef, Q_655), 0D))) > 34D)) ? V.True : V.False);
}, 1, "", true);
inS_648 = Fn((V _arrowThis664, int _argc657, V Q_663, V _a660, V _a661, V _a662, V[] _rest658) => {
return (Call(isS_647, V.Undef, Q_663) is var _t666 && Truthy(_t666) ? _t666 : (Get(Q_663, "par") is var _t665 && !Truthy(_t665) ? _t665 : Call(isS_647, V.Undef, Get(Q_663, "par"))));
}, 1, "", true);
return Invoke(all_646, "filter", Fn((V _arrowThis674, int _argc667, V Q_673, V _a670, V _a671, V _a672, V[] _rest668) => {
return (Truthy(k_636) ? (!(Truthy(Call(inS_648, V.Undef, Q_673))) ? V.True : V.False) : Call(inS_648, V.Undef, Q_673));
}, 1, "", true));
return default;
}, 1, "build", true)).V);
}, 1, "", true)) : (Get(B_626, "layers") is var _t675 && Truthy(_t675) ? _t675 : Arr()));
return default;
}, 1, "", true);
mergeBB_55 = Fn((V _arrowThis684, int _argc676, V A_682, V B_683, V _a680, V _a681, V[] _rest677) => {
return (!(Truthy(A_682)) ? B_683 : Arr(((V)(Min(ToNum(GetIdx(A_682, 0D)), ToNum(GetIdx(B_683, 0D))))), ((V)(Min(ToNum(GetIdx(A_682, 1D)), ToNum(GetIdx(B_683, 1D))))), ((V)(Max(ToNum(GetIdx(A_682, 2D)), ToNum(GetIdx(B_683, 2D))))), ((V)(Max(ToNum(GetIdx(A_682, 3D)), ToNum(GetIdx(B_683, 3D)))))));
}, 2, "", true);
knit_56 = Fn((V _arrowThis696, int _argc685, V o_691, V P_692, V on_693, V S_694, V[] _rest686) => {
V lt_697 = default;
V dk_698 = default;
V R_695 = default;
R_695 = (_argc685 > 4 ? _rest686[0] : V.Undef);
lt_697 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_694, "col"), ((V)(1.1))), NewObj(1).Put("op", ((V)(0.42))).V);
dk_698 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_694, "col"), ((V)(0.84))), NewObj(1).Put("op", ((V)(0.42))).V);
Invoke(Call(sides_51, V.Undef, S_694, ((V)(2.5))), "forEach", Fn((V _arrowThis706, int _argc699, V F_705, V _a702, V _a703, V _a704, V[] _rest700) => {
if ((System.Math.Abs(ToNum(GetIdx(Get(F_705, "n"), 1D))) < 0.6)) {
Call(hatch_45, V.Undef, Arr(lt_697, dk_698), F_705, ((V)((PI_22 / 2D))), ((V)(1.5)), ((V)(0.42)), NewObj(1).Put("sh", ((V)(0.98))).V);
}
return default;
}, 1, "", true));
Call(on_693, V.Undef, S_694, Arr(lt_697, dk_698));
return default;
}, 5, "", true);
levTex_57 = Fn((V _arrowThis716, int _argc707, V o_713, V P_714, V sofa_715, V _a712, V[] _rest708) => {
V on_717 = default;
V R_718 = default;
V B_719 = default;
V fab_720 = default;
V rolls_721 = default;
on_717 = Call(glue_27, V.Undef, o_713);
R_718 = Call(R0_28, V.Undef, ((V)("lev25")));
B_719 = Invoke(o_713, "map", Fn((V _arrowThis729, int _argc722, V S_728, V _a725, V _a726, V _a727, V[] _rest723) => {
return NewObj(2).Put("S", S_728).Put("L", Call(bbS_38, V.Undef, S_728)).V;
}, 1, "", true));
fab_720 = Invoke(B_719, "filter", Fn((V _arrowThis737, int _argc730, V b_736, V _a733, V _a734, V _a735, V[] _rest731) => {
return (Call(isFab_52, V.Undef, Get(b_736, "S"), P_714) is var _t738 && !Truthy(_t738) ? _t738 : (!(Truthy(Get(Get(b_736, "S"), "par"))) ? V.True : V.False));
}, 1, "", true));
Invoke(fab_720, "forEach", Fn((V _arrowThis746, int _argc739, V b_745, V _a742, V _a743, V _a744, V[] _rest740) => {
return Call(knit_56, V.Undef, o_713, P_714, on_717, Get(b_745, "S"), R_718);
}, 1, "", true));
Invoke(fab_720, "forEach", Fn((V _arrowThis757, int _argc747, V _a749, V _a750, V _a751, V _a752, V[] _rest748) => {
double h_758 = 0;
double d_759 = 0;
double w_760 = 0;
V S_754 = default;
V L_756 = default;
if (_a749.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a749));
{ V _t753 = Get(_a749, "S");
S_754 = _t753; }
{ V _t755 = Get(_a749, "L");
L_756 = _t755; }
h_758 = (ToNum(GetIdx(L_756, 3D)) - ToNum(GetIdx(L_756, 2D)));
d_759 = (ToNum(GetIdx(L_756, 5D)) - ToNum(GetIdx(L_756, 4D)));
w_760 = (ToNum(GetIdx(L_756, 1D)) - ToNum(GetIdx(L_756, 0D)));
if ((((SEq(Get(S_754, "col"), Get(P_714, "aL")) && GtN(GetIdx(L_756, 5D), 15D)) && (h_758 < 22D)) && (w_760 > 40D))) {
V G1_761 = default;
V G2_762 = default;
V HT_763 = default;
V WL_764 = default;
G1_761 = Call(dec_24, V.Undef, ((V)("#a9d8ec")), NewObj(1).Put("op", ((V)(0.75))).V);
G2_762 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.55))).V);
HT_763 = Call(dec_24, V.Undef, ((V)("#ffb784")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.7))).V);
WL_764 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_754, "col"), ((V)(0.8))), NewObj(1).Put("op", ((V)(0.7))).V);
Invoke(Call(caps_50, V.Undef, S_754, ((V)(2D))), "forEach", Fn((V _arrowThis772, int _argc765, V F_771, V _a768, V _a769, V _a770, V[] _rest766) => {
Call(hatch_45, V.Undef, G1_761, F_771, ((V)(0.9)), ((V)(4.6)), ((V)(0.45)));
Call(hatch_45, V.Undef, G1_761, F_771, ((V)((PI_22 - 0.9))), ((V)(4.6)), ((V)(0.45)));
Call(hatch_45, V.Undef, G2_762, F_771, ((V)(0.9)), ((V)(4.6)), ((V)(0.2)), NewObj(1).Put("ph", ((V)(0.4))).V);
Call(hatch_45, V.Undef, G2_762, F_771, ((V)((PI_22 - 0.9))), ((V)(4.6)), ((V)(0.2)), NewObj(1).Put("ph", ((V)(0.4))).V);
Call(dots_48, V.Undef, HT_763, F_771, ((V)(6.2)), ((V)(0.55)), NewObj(2).Put("stag", ((V)(1D))).Put("sh", ((V)(0.86))).V);
return default;
}, 1, "", true));
if (((ToNum(Get(Get(S_754, "pts"), "length")) % 6D) == 0D)) {
Call(ringL_49, V.Undef, WL_764, S_754, ((V)(4D)), ((V)(6D)), ((V)(0.55)), ((V)(0.6)));
}
Call(on_717, V.Undef, S_754, Arr(G1_761, G2_762, HT_763, WL_764));
} else {
if (((SEq(Get(S_754, "col"), Get(P_714, "aL")) && LtN(GetIdx(L_756, 5D), 0D)) && (h_758 > 30D))) {
V CB_773 = default;
V CL_774 = default;
CB_773 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_754, "col"), ((V)(0.74))), NewObj(1).Put("op", ((V)(0.75))).V);
CL_774 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_754, "col"), ((V)(1.16))), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Call(caps_50, V.Undef, S_754, ((V)(2D))), "forEach", Fn((V _arrowThis782, int _argc775, V F_781, V _a778, V _a779, V _a780, V[] _rest776) => {
Invoke(Arr(((V)((-0.25))), ((V)(0.25))), "forEach", Fn((V _arrowThis790, int _argc783, V cx_789, V _a786, V _a787, V _a788, V[] _rest784) => {
V fx_791 = default;
fx_791 = Fn((V _arrowThis800, int _argc792, V ph_798, V D_799, V _a796, V _a797, V[] _rest793) => {
return Call(wavy_46, V.Undef, D_799, F_781, Fn((V _arrowThis809, int _argc801, V t_807, V G_808, V _a805, V _a806, V[] _rest802) => {
V Pw_810 = default;
V xs_811 = default;
V ys_812 = default;
double W_813 = 0;
double H_814 = 0;
Pw_810 = Get(G_808, "P");
xs_811 = Invoke(Pw_810, "map", Fn((V _arrowThis822, int _argc815, V q_821, V _a818, V _a819, V _a820, V[] _rest816) => {
return GetIdx(q_821, 0D);
}, 1, "", true));
ys_812 = Invoke(Pw_810, "map", Fn((V _arrowThis830, int _argc823, V q_829, V _a826, V _a827, V _a828, V[] _rest824) => {
return GetIdx(q_829, 1D);
}, 1, "", true));
W_813 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_811).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_811).V)));
H_814 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_812).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_812).V)));
return Arr(((V)(((ToNum(cx_789) * W_813) + ((FdLibm.Sin(ToNum(Add(((V)(((ToNum(t_807) * PI_22) * 7D))), ph_798))) * W_813) * 0.06)))), ((V)((((-H_814) / 2D) + (H_814 * ToNum(t_807))))));
return default;
}, 2, "", true), ((V)(42D)), ((V)(1.2)));
}, 2, "", true);
Call(fx_791, V.Undef, ((V)(0D)), CB_773);
Call(fx_791, V.Undef, ((V)(PI_22)), CB_773);
Call(fx_791, V.Undef, ((V)(0.35)), CL_774);
return default;
}, 1, "", true));
Call(hatch_45, V.Undef, CL_774, F_781, ((V)((PI_22 / 2D))), ((V)(2.2)), ((V)(0.3)));
return default;
}, 1, "", true));
Call(on_717, V.Undef, S_754, Arr(CB_773, CL_774));
}
}
return default;
}, 1, "", true));
Invoke(Invoke(B_719, "filter", Fn((V _arrowThis856, int _argc849, V b_855, V _a852, V _a853, V _a854, V[] _rest850) => {
return ((((!(Truthy(Get(Get(b_855, "S"), "par"))) && !(Truthy(Call(isFab_52, V.Undef, Get(b_855, "S"), P_714)))) && (System.Math.Abs(((ToNum(GetIdx(Get(b_855, "L"), 3D)) - ToNum(GetIdx(Get(b_855, "L"), 2D))) - 24D)) < 3D)) && ((ToNum(GetIdx(Get(b_855, "L"), 5D)) - ToNum(GetIdx(Get(b_855, "L"), 4D))) < 11D)) ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis839, int _argc831, V b_837, V i_838, V _a835, V _a836, V[] _rest832) => {
V CB_840 = default;
Set(Get(b_837, "S"), "col", ((V)((NumTruthy((ToNum(i_838) % 2D)) ? "#d9c3a0" : "#c79a6b"))));
Set(Get(b_837, "S"), "mat", ((V)("fab")));
Call(knit_56, V.Undef, o_713, P_714, on_717, Get(b_837, "S"), R_718);
CB_840 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(Get(b_837, "S"), "col"), ((V)(0.8))), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Call(caps_50, V.Undef, Get(b_837, "S"), ((V)(2D))), "forEach", Fn((V _arrowThis848, int _argc841, V F_847, V _a844, V _a845, V _a846, V[] _rest842) => {
return Call(outline_47, V.Undef, CB_840, F_847, ((V)(0.86)), ((V)(0.5)));
}, 1, "", true));
Call(on_717, V.Undef, Get(b_837, "S"), Arr(CB_840));
return default;
}, 2, "", true));
if (!(Truthy(sofa_715))) {
return default;
}
rolls_721 = Invoke(B_719, "filter", Fn((V _arrowThis864, int _argc857, V b_863, V _a860, V _a861, V _a862, V[] _rest858) => {
return (((((SEq(Get(Get(b_863, "S"), "col"), Get(P_714, "a")) && !(Truthy(Get(Get(b_863, "S"), "par")))) && ((ToNum(GetIdx(Get(b_863, "L"), 1D)) - ToNum(GetIdx(Get(b_863, "L"), 0D))) < 34D)) && ((ToNum(GetIdx(Get(b_863, "L"), 5D)) - ToNum(GetIdx(Get(b_863, "L"), 4D))) > 60D)) && GtN(GetIdx(Get(b_863, "L"), 2D), 30D)) ? V.True : V.False);
}, 1, "", true));
Invoke(rolls_721, "forEach", Fn((V _arrowThis875, int _argc865, V _a867, V _a868, V _a869, V _a870, V[] _rest866) => {
V left_876 = default;
double zc_877 = 0;
V S_872 = default;
V L_874 = default;
if (_a867.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a867));
{ V _t871 = Get(_a867, "S");
S_872 = _t871; }
{ V _t873 = Get(_a867, "L");
L_874 = _t873; }
left_876 = (((ToNum(Add(GetIdx(L_874, 0D), GetIdx(L_874, 1D))) / 2D) < 0D) ? V.True : V.False);
zc_877 = (ToNum(Add(GetIdx(L_874, 4D), GetIdx(L_874, 5D))) / 2D);
if (Truthy(left_876)) {
V TC_878 = default;
V TH_879 = default;
V TL_880 = default;
V TD_881 = default;
V FR_882 = default;
double z0_883 = 0;
double z1_884 = 0;
V AB_885 = default;
TC_878 = ((V)("#b98d5e"));
TH_879 = Call(dec_24, V.Undef, TC_878);
TL_880 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, TC_878, ((V)(1.12))), NewObj(1).Put("op", ((V)(0.5))).V);
TD_881 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, TC_878, ((V)(0.8))), NewObj(1).Put("op", ((V)(0.5))).V);
FR_882 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, TC_878, ((V)(0.9))));
z0_883 = (zc_877 - 2D);
z1_884 = (zc_877 + 20D);
Invoke(Get(S_872, "faces"), "forEach", Fn((V _arrowThis893, int _argc886, V F_892, V _a889, V _a890, V _a891, V[] _rest887) => {
V zs_894 = default;
V q_895 = default;
if (Truthy(Get(F_892, "cap"))) {
return default;
}
zs_894 = Invoke(Get(F_892, "q"), "map", Fn((V _arrowThis903, int _argc896, V q_902, V _a899, V _a900, V _a901, V[] _rest897) => {
return GetIdx(q_902, 2D);
}, 1, "", true));
if ((LtN(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(zs_894).V), z0_883) || GtN(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(zs_894).V), z1_884))) {
return default;
}
if (GtN(GetIdx(Get(F_892, "n"), 0D), 0.3)) {
return default;
}
q_895 = Invoke(Get(F_892, "q"), "map", Fn((V _arrowThis911, int _argc904, V p_910, V _a907, V _a908, V _a909, V[] _rest905) => {
return Arr(GetIdx(p_910, 0D), GetIdx(p_910, 1D), ((V)(Max(z0_883, Min(z1_884, ToNum(GetIdx(p_910, 2D)))))));
}, 1, "", true));
if (((System.Math.Abs((ToNum(GetIdx(GetIdx(q_895, 0D), 2D)) - ToNum(GetIdx(GetIdx(q_895, 3D), 2D)))) + System.Math.Abs((ToNum(GetIdx(GetIdx(q_895, 1D), 2D)) - ToNum(GetIdx(GetIdx(q_895, 2D), 2D))))) < 0.5)) {
return default;
}
Invoke(TH_879, "poly", q_895, Get(F_892, "n"));
return default;
}, 1, "", true));
Call(on_717, V.Undef, S_872, Arr(TH_879));
AB_885 = Invoke(B_719, "find", Fn((V _arrowThis919, int _argc912, V b_918, V _a915, V _a916, V _a917, V[] _rest913) => {
return (((((((SEq(Get(Get(b_918, "S"), "col"), Get(P_714, "a")) && !(Truthy(Get(Get(b_918, "S"), "par")))) && !SEq(b_918, GetIdx(rolls_721, 0D))) && ((ToNum(GetIdx(Get(b_918, "L"), 1D)) - ToNum(GetIdx(Get(b_918, "L"), 0D))) < 34D)) && ((ToNum(GetIdx(Get(b_918, "L"), 5D)) - ToNum(GetIdx(Get(b_918, "L"), 4D))) > 60D)) && LtN(GetIdx(Get(b_918, "L"), 2D), 30D)) && ((ToNum(Add(GetIdx(Get(b_918, "L"), 0D), GetIdx(Get(b_918, "L"), 1D))) / 2D) < 0D)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(AB_885)) {
V x_920 = default;
V y1_921 = default;
double y0_922 = 0;
V wv_923 = default;
V Q_924 = default;
V TH2_925 = default;
x_920 = GetIdx(Get(AB_885, "L"), 0D);
y1_921 = GetIdx(Get(AB_885, "L"), 3D);
y0_922 = (ToNum(y1_921) - 17D);
wv_923 = Fn((V _arrowThis933, int _argc926, V z_932, V _a929, V _a930, V _a931, V[] _rest927) => {
return ((V)((y0_922 + (FdLibm.Sin((ToNum(z_932) * 0.7)) * 1.2))));
}, 1, "", true);
Q_924 = Arr(Arr(x_920, y1_921, ((V)(z0_883))), Arr(x_920, y1_921, ((V)(z1_884))), Arr(x_920, Call(wv_923, V.Undef, ((V)(z1_884))), ((V)((z1_884 - 1.5)))), Arr(x_920, Call(wv_923, V.Undef, ((V)(z0_883))), ((V)((z0_883 + 1.5)))));
TH2_925 = Call(dec_24, V.Undef, TC_878);
Invoke(TH2_925, "poly", Q_924, Arr(((V)((-1D))), ((V)(0D)), ((V)(0D))));
Call(on_717, V.Undef, Get(AB_885, "S"), Arr(TH2_925));
Call(rep_29, V.Undef, ((V)(9D)), Fn((V _arrowThis941, int _argc934, V i_940, V _a937, V _a938, V _a939, V[] _rest935) => {
double z_942 = 0;
z_942 = ((z0_883 + 2D) + ((ToNum(i_940) * ((z1_884 - z0_883) - 4D)) / 8D));
Invoke((NumTruthy((ToNum(i_940) % 2D)) ? TL_880 : TD_881), "line", Arr(Arr(x_920, ((V)((ToNum(y1_921) - 1D))), ((V)(z_942))), Arr(x_920, Add(Call(wv_923, V.Undef, ((V)(z_942))), ((V)(1D))), ((V)(z_942)))), Arr(((V)((-1D))), ((V)(0D)), ((V)(0D))), ((V)(0.5)));
return default;
}, 1, "", true));
Call(rep_29, V.Undef, ((V)(14D)), Fn((V _arrowThis950, int _argc943, V i_949, V _a946, V _a947, V _a948, V[] _rest944) => {
double z_951 = 0;
z_951 = ((z0_883 + 2D) + ((ToNum(i_949) * ((z1_884 - z0_883) - 4D)) / 13D));
Invoke(FR_882, "line", Arr(Arr(x_920, Add(Call(wv_923, V.Undef, ((V)(z_951))), ((V)(0.5))), ((V)(z_951))), Arr(x_920, ((V)((ToNum(Call(wv_923, V.Undef, ((V)(z_951)))) - 2.6))), ((V)((z_951 + 0.2))))), Arr(((V)((-1D))), ((V)(0D)), ((V)(0D))), ((V)(0.32)));
return default;
}, 1, "", true));
Call(on_717, V.Undef, Get(AB_885, "S"), Arr(TL_880, TD_881, FR_882));
}
} else {
V DL_952 = default;
V DR_953 = default;
V DW_954 = default;
V top_955 = default;
double x_956 = 0;
double z_957 = 0;
V Nn_958 = default;
DL_952 = Call(dec_24, V.Undef, ((V)("#1f2227")));
DR_953 = Call(dec_24, V.Undef, ((V)("#ffcf9a")), NewObj(1).Put("emit", ((V)(1D))).V);
DW_954 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.8))).V);
top_955 = GetIdx(L_874, 3D);
x_956 = (ToNum(Add(GetIdx(L_874, 0D), GetIdx(L_874, 1D))) / 2D);
z_957 = (zc_877 + 14D);
Nn_958 = Y3_37;
Invoke(DL_952, "poly", Call(rep_29, V.Undef, ((V)(18D)), Fn((V _arrowThis966, int _argc959, V i_965, V _a962, V _a963, V _a964, V[] _rest960) => {
double a_967 = 0;
a_967 = (((ToNum(i_965) / 18D) * 2D) * PI_22);
return Arr(((V)((x_956 + (FdLibm.Cos(a_967) * 4.2)))), Add(top_955, ((V)(0.1))), ((V)((z_957 + (FdLibm.Sin(a_967) * 4.2)))));
return default;
}, 1, "", true)), Nn_958);
Invoke(DR_953, "line", Call(rep_29, V.Undef, ((V)(15D)), Fn((V _arrowThis975, int _argc968, V i_974, V _a971, V _a972, V _a973, V[] _rest969) => {
double a_976 = 0;
a_976 = ((PI_22 * 0.75) + (((ToNum(i_974) / 14D) * PI_22) * 1.1));
return Arr(((V)((x_956 + (FdLibm.Cos(a_976) * 3.4)))), Add(top_955, ((V)(0.15))), ((V)((z_957 + (FdLibm.Sin(a_976) * 3.4)))));
return default;
}, 1, "", true)), Nn_958, ((V)(0.55)));
Call(spot_25, V.Undef, DW_954, Arr(((V)(x_956)), Add(top_955, ((V)(0.2))), ((V)(z_957))), Nn_958, ((V)(0.9)), ((V)(0.9)), ((V)(0D)), ((V)(8D)));
Call(rep_29, V.Undef, ((V)(3D)), Fn((V _arrowThis984, int _argc977, V i_983, V _a980, V _a981, V _a982, V[] _rest978) => {
return Call(spot_25, V.Undef, DR_953, Arr(((V)(((x_956 - 2D) + (ToNum(i_983) * 2D)))), Add(top_955, ((V)(0.15))), ((V)((z_957 + 6.2)))), Nn_958, ((V)(0.35)), ((V)(0.35)), ((V)(0D)), ((V)(6D)));
}, 1, "", true));
Call(on_717, V.Undef, S_872, Arr(DL_952, DR_953, DW_954));
}
return default;
}, 1, "", true));
return default;
}, 3, "", true);
Set(N_21, "lev25", Fn((V _arrowThis992, int _argc985, V S_991, V _a988, V _a989, V _a990, V[] _rest986) => {
V B_993 = default;
V D_994 = default;
double by_995 = 0;
B_993 = Invoke(N_21, "rsofa", Object_assign(NewObj(0).V, S_991, NewObj(1).Put("float", ((V)(1D))).V));
D_994 = Object_assign(NewObj(0).V, B_993);
by_995 = 23D;
Set(D_994, "build", Fn((V _arrowThis1003, int _argc996, V P_1002, V _a999, V _a1000, V _a1001, V[] _rest997) => {
V o_1004 = default;
o_1004 = Invoke(B_993, "build", P_1002);
Call(levTex_57, V.Undef, o_1004, P_1002, ((V)(1D)));
return o_1004;
return default;
}, 1, "", true));
Set(D_994, "layers", Invoke(Call(splitL_54, V.Undef, B_993), "map", Fn((V _arrowThis1012, int _argc1005, V L_1011, V _a1008, V _a1009, V _a1010, V[] _rest1006) => {
return Object_assign(NewObj(0).V, L_1011, NewObj(1).Put("build", Fn((V _arrowThis1020, int _argc1013, V P_1019, V _a1016, V _a1017, V _a1018, V[] _rest1014) => {
V o_1021 = default;
o_1021 = Invoke(L_1011, "build", P_1019);
Call(levTex_57, V.Undef, o_1021, P_1019, ((V)(1D)));
return o_1021;
return default;
}, 1, "build", true)).V);
}, 1, "", true)));
Set(D_994, "fx", Fn((V _arrowThis1029, int _argc1022, V c_1028, V _a1025, V _a1026, V _a1027, V[] _rest1023) => {
V A_1030 = default;
V p_1031 = default;
JsStrBuf fr_1032 = null;
A_1030 = Call(padFx_53, V.Undef, c_1028, ((V)((ToNum(Get(D_994, "w")) * 0.36))), ((V)((ToNum(Get(D_994, "d")) * 0.3))), ((V)((by_995 - 8D))), ((V)("lv25")), ((V)("#9fe6ff")));
p_1031 = Get(c_1028, "p");
fr_1032 = new JsStrBuf("");
Invoke((Get(D_994, "seats") is var _t1051 && Truthy(_t1051) ? _t1051 : Arr()), "forEach", Fn((V _arrowThis1041, int _argc1033, V s_1039, V i_1040, V _a1037, V _a1038, V[] _rest1034) => {
return Call(rep_29, V.Undef, ((V)(2D)), Fn((V _arrowThis1049, int _argc1042, V j_1048, V _a1045, V _a1046, V _a1047, V[] _rest1043) => {
V q_1050 = default;
q_1050 = Call(p_1031, V.Undef, ((V)(((ToNum(Get(s_1039, "x")) - 8D) + (ToNum(j_1048) * 16D)))), Add(Get(s_1039, "h"), ((V)(3D))), ((V)((ToNum(Get(s_1039, "z")) - 6D))));
fr_1032.S("<g transform=\"translate(").V(Call(f1_20, V.Undef, GetIdx(q_1050, 0D))).S(" ").V(Call(f1_20, V.Undef, GetIdx(q_1050, 1D))).S(") scale(").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(c_1028, "k")) * 0.9))))).S(")\"><path d=\"M0 0q-2 -4 0 -8t0 -8\" fill=\"none\" stroke=\"#ffd2a6\" stroke-width=\"0.8\" stroke-linecap=\"round\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0.55;0\" dur=\"3s\" begin=\"").V(Call(f1_20, V.Undef, ((V)((-((ToNum(i_1040) * 0.9) + (ToNum(j_1048) * 1.5))))))).S("s\" repeatCount=\"indefinite\"/><animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;0 -7\" dur=\"3s\" begin=\"").V(Call(f1_20, V.Undef, ((V)((-((ToNum(i_1040) * 0.9) + (ToNum(j_1048) * 1.5))))))).S("s\" repeatCount=\"indefinite\"/></path></g>");
return default;
}, 1, "", true));
}, 2, "", true));
return NewObj(4).Put("defs", Get(A_1030, "defs")).Put("under", Get(A_1030, "svg")).Put("front", ((V)(fr_1032.Str))).Put("bb", Get(A_1030, "bb")).V;
return default;
}, 1, "", true));
return D_994;
return default;
}, 1, "", true));
velvet_58 = Fn((V _arrowThis1063, int _argc1052, V D1_1058, V D2_1059, V F_1060, V R_1061, V[] _rest1053) => {
V n_1062 = default;
n_1062 = (_argc1052 > 4 ? _rest1053[0] : V.Undef);
return Call(rep_29, V.Undef, n_1062, Fn((V _arrowThis1071, int _argc1064, V i_1070, V _a1067, V _a1068, V _a1069, V[] _rest1065) => {
double ph_1072 = 0;
double yy_1073 = 0;
double amp_1074 = 0;
ph_1072 = (ToNum(Call(R_1061, V.Undef)) * 6D);
yy_1073 = ((ToNum(Call(R_1061, V.Undef)) * 0.8) - 0.4);
amp_1074 = (0.05 + (ToNum(Call(R_1061, V.Undef)) * 0.08));
Call(wavy_46, V.Undef, (NumTruthy((ToNum(i_1070) % 2D)) ? D2_1059 : D1_1058), F_1060, Fn((V _arrowThis1083, int _argc1075, V t_1081, V G_1082, V _a1079, V _a1080, V[] _rest1076) => {
V xs_1084 = default;
V ys_1085 = default;
double W_1086 = 0;
double H_1087 = 0;
xs_1084 = Invoke(Get(G_1082, "P"), "map", Fn((V _arrowThis1095, int _argc1088, V q_1094, V _a1091, V _a1092, V _a1093, V[] _rest1089) => {
return GetIdx(q_1094, 0D);
}, 1, "", true));
ys_1085 = Invoke(Get(G_1082, "P"), "map", Fn((V _arrowThis1103, int _argc1096, V q_1102, V _a1099, V _a1100, V _a1101, V[] _rest1097) => {
return GetIdx(q_1102, 1D);
}, 1, "", true));
W_1086 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_1084).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_1084).V)));
H_1087 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_1085).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_1085).V)));
return Arr(((V)((((-W_1086) / 2D) + (W_1086 * ToNum(t_1081))))), ((V)(((yy_1073 * H_1087) + ((FdLibm.Sin(((ToNum(t_1081) * 5D) + ph_1072)) * H_1087) * amp_1074)))));
return default;
}, 2, "", true), ((V)(24D)), ((V)((1.8 + (ToNum(Call(R_1061, V.Undef)) * 2.2)))), ((V)(1D)));
return default;
}, 1, "", true));
}, 5, "", true);
chesTex_59 = Fn((V _arrowThis1113, int _argc1104, V o_1110, V P_1111, V li_1112, V _a1109, V[] _rest1105) => {
V on_1114 = default;
V R_1115 = default;
V F0_1116 = default;
V B_1117 = default;
V sheen_1118 = default;
on_1114 = Call(glue_27, V.Undef, o_1110);
R_1115 = Call(R0_28, V.Undef, ((V)(JsStrBuf.Begin().S("ch25").V(li_1112).End())));
F0_1116 = ((Get(P_1111, "c") is var _t1119 && !Truthy(_t1119) ? _t1119 : Get(Get(P_1111, "c"), "a")) is var _t1120 && Truthy(_t1120) ? _t1120 : Get(P_1111, "a"));
B_1117 = Invoke(Invoke(o_1110, "map", Fn((V _arrowThis1136, int _argc1129, V S_1135, V _a1132, V _a1133, V _a1134, V[] _rest1130) => {
return NewObj(2).Put("S", S_1135).Put("L", Call(bbS_38, V.Undef, S_1135)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis1128, int _argc1121, V b_1127, V _a1124, V _a1125, V _a1126, V[] _rest1122) => {
return (!(Truthy(Get(Get(b_1127, "S"), "par"))) ? V.True : V.False);
}, 1, "", true));
sheen_1118 = Fn((V _arrowThis1144, int _argc1137, V S_1143, V _a1140, V _a1141, V _a1142, V[] _rest1138) => {
V D1_1145 = default;
V D2_1146 = default;
D1_1145 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_1143, "col"), ((V)("#ffffff")), ((V)(0.2))), NewObj(1).Put("op", ((V)(0.26))).V);
D2_1146 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_1143, "col"), ((V)(0.9))), NewObj(1).Put("op", ((V)(0.22))).V);
return Arr(D1_1145, D2_1146);
return default;
}, 1, "", true);
Invoke(B_1117, "forEach", Fn((V _arrowThis1157, int _argc1147, V _a1149, V _a1150, V _a1151, V _a1152, V[] _rest1148) => {
double w_1158 = 0;
double h_1159 = 0;
double d_1160 = 0;
V S_1154 = default;
V L_1156 = default;
if (_a1149.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a1149));
{ V _t1153 = Get(_a1149, "S");
S_1154 = _t1153; }
{ V _t1155 = Get(_a1149, "L");
L_1156 = _t1155; }
w_1158 = (ToNum(GetIdx(L_1156, 1D)) - ToNum(GetIdx(L_1156, 0D)));
h_1159 = (ToNum(GetIdx(L_1156, 3D)) - ToNum(GetIdx(L_1156, 2D)));
d_1160 = (ToNum(GetIdx(L_1156, 5D)) - ToNum(GetIdx(L_1156, 4D)));
if (Truthy(((SEq(Get(S_1154, "col"), GOLD_23) ? V.True : V.False) is var _t1161 && Truthy(_t1161) ? _t1161 : Get(S_1154, "emit")))) {
return default;
}
if (((((SEqN(li_1112, 2D) && ((ToNum(Get(Get(S_1154, "pts"), "length")) % 6D) == 0D)) && (w_1158 > 50D)) && (w_1158 < 60D)) && (d_1160 > 60D))) {
V D1_1162 = default;
V D2_1163 = default;
V WG_1164 = default;
V WD_1165 = default;
{ V _t1166 = Call(sheen_1118, V.Undef, S_1154);
{ V _t1167 = ListOf(_t1166);
{ V _t1168 = GetIdx(_t1167, 0D);
D1_1162 = _t1168; }
{ V _t1169 = GetIdx(_t1167, 1D);
D2_1163 = _t1169; }
} }
WG_1164 = Call(dec_24, V.Undef, ((V)("#f0c24a")), NewObj(1).Put("op", ((V)(0.95))).V);
WD_1165 = Call(dec_24, V.Undef, ((V)("#9a6a14")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Call(caps_50, V.Undef, S_1154, ((V)(2D))), "forEach", Fn((V _arrowThis1177, int _argc1170, V F_1176, V _a1173, V _a1174, V _a1175, V[] _rest1171) => {
return Call(velvet_58, V.Undef, D1_1162, D2_1163, F_1176, R_1115, ((V)(5D)));
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, S_1154, ((V)(3D))), "forEach", Fn((V _arrowThis1185, int _argc1178, V F_1184, V _a1181, V _a1182, V _a1183, V[] _rest1179) => {
if (((System.Math.Abs(ToNum(GetIdx(Get(F_1184, "n"), 2D))) > 0.7) && GtN(GetIdx(Get(F_1184, "n"), 2D), 0D))) {
Call(velvet_58, V.Undef, D1_1162, D2_1163, F_1184, R_1115, ((V)(2D)));
}
return default;
}, 1, "", true));
Call(ringL_49, V.Undef, WG_1164, S_1154, ((V)(4D)), ((V)(6D)), ((V)(0.75)), ((V)(0.6)));
Call(ringL_49, V.Undef, WD_1165, S_1154, ((V)(3D)), ((V)(6D)), ((V)(0.35)), ((V)(0D)));
Call(on_1114, V.Undef, S_1154, Arr(D1_1162, D2_1163, WD_1165, WG_1164));
return default;
}
if (((SEqN(li_1112, 2D) && (System.Math.Abs((w_1158 - 24D)) < 3D)) && (System.Math.Abs((h_1159 - 24D)) < 3D))) {
V DM_1186 = default;
V DL_1187 = default;
V TS_1188 = default;
DM_1186 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_1154, "col"), ((V)(0.72))), NewObj(1).Put("op", ((V)(0.6))).V);
DL_1187 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_1154, "col"), ((V)("#ffffff")), ((V)(0.4))), NewObj(1).Put("op", ((V)(0.5))).V);
TS_1188 = Call(dec_24, V.Undef, ((V)("#9a6a14")), NewObj(1).Put("op", ((V)(0.7))).V);
Invoke(Call(caps_50, V.Undef, S_1154, ((V)(2D))), "forEach", Fn((V _arrowThis1196, int _argc1189, V F_1195, V _a1192, V _a1193, V _a1194, V[] _rest1190) => {
Call(hatch_45, V.Undef, DM_1186, F_1195, ((V)((PI_22 / 4D))), ((V)(5.2)), ((V)(0.3)), NewObj(1).Put("sh", ((V)(0.86))).V);
Call(hatch_45, V.Undef, DM_1186, F_1195, ((V)(((-PI_22) / 4D))), ((V)(5.2)), ((V)(0.3)), NewObj(1).Put("sh", ((V)(0.86))).V);
Call(dots_48, V.Undef, DL_1187, F_1195, ((V)(3.7)), ((V)(0.6)), NewObj(2).Put("sh", ((V)(0.8))).Put("stag", ((V)(1D))).V);
Call(outline_47, V.Undef, TS_1188, F_1195, ((V)(0.95)), ((V)(0.5)));
return default;
}, 1, "", true));
Call(on_1114, V.Undef, S_1154, Arr(DM_1186, DL_1187, TS_1188));
return default;
}
if ((((SEqN(li_1112, 2D) && (w_1158 > 30D)) && (w_1158 < 40D)) && (h_1159 < 18D))) {
V CG_1197 = default;
V CD_1198 = default;
V zf_1199 = default;
CG_1197 = Call(dec_24, V.Undef, ((V)("#f0c24a")), NewObj(1).Put("op", ((V)(0.95))).V);
CD_1198 = Call(dec_24, V.Undef, ((V)("#0f2c22")), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Call(caps_50, V.Undef, S_1154, ((V)(2D))), "forEach", Fn((V _arrowThis1207, int _argc1200, V F_1206, V _a1203, V _a1204, V _a1205, V[] _rest1201) => {
V G_1208 = default;
V Q_1209 = default;
G_1208 = Call(fr2_39, V.Undef, F_1206);
Q_1209 = Fn((V _arrowThis1218, int _argc1210, V a_1216, V b_1217, V _a1214, V _a1215, V[] _rest1211) => {
return Invoke(G_1208, "at", a_1216, b_1217);
}, 2, "", true);
Invoke(CG_1197, "line", Arr(Call(Q_1209, V.Undef, ((V)((-5D))), ((V)((-2D)))), Call(Q_1209, V.Undef, ((V)((-5D))), ((V)(2.6))), Call(Q_1209, V.Undef, ((V)((-2.5))), ((V)(0.6))), Call(Q_1209, V.Undef, ((V)(0D)), ((V)(3.6))), Call(Q_1209, V.Undef, ((V)(2.5)), ((V)(0.6))), Call(Q_1209, V.Undef, ((V)(5D)), ((V)(2.6))), Call(Q_1209, V.Undef, ((V)(5D)), ((V)((-2D)))), Call(Q_1209, V.Undef, ((V)((-5D))), ((V)((-2D))))), Get(G_1208, "n"), ((V)(0.6)));
Invoke(CG_1197, "line", Arr(Call(Q_1209, V.Undef, ((V)((-5.4))), ((V)((-3.2)))), Call(Q_1209, V.Undef, ((V)(5.4)), ((V)((-3.2))))), Get(G_1208, "n"), ((V)(0.7)));
Invoke(Arr(((V)((-5D))), ((V)(0D)), ((V)(5D))), "forEach", Fn((V _arrowThis1226, int _argc1219, V a_1225, V _a1222, V _a1223, V _a1224, V[] _rest1220) => {
return Call(spot_25, V.Undef, CG_1197, Call(Q_1209, V.Undef, a_1225, ((V)((Truthy(a_1225) ? 3.3 : 4.4)))), Get(G_1208, "n"), ((V)(0.55)), ((V)(0.55)), ((V)(0D)), ((V)(6D)));
}, 1, "", true));
Call(hatch_45, V.Undef, CD_1198, F_1206, ((V)((PI_22 / 2D))), ((V)(1.8)), ((V)(0.25)), NewObj(1).Put("sh", ((V)(0.9))).V);
return default;
}, 1, "", true));
if (((ToNum(Get(Get(S_1154, "pts"), "length")) % 5D) == 0D)) {
Call(ringL_49, V.Undef, CG_1197, S_1154, ((V)(3D)), ((V)(5D)), ((V)(0.5)), ((V)(0D)));
}
Call(on_1114, V.Undef, S_1154, Arr(CD_1198, CG_1197));
zf_1199 = GetIdx(L_1156, 5D);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1234, int _argc1227, V sg_1233, V _a1230, V _a1231, V _a1232, V[] _rest1228) => {
double x_1235 = 0;
V y_1236 = default;
V T_1237 = default;
x_1235 = (ToNum(sg_1233) * ((w_1158 / 2D) - 1.5));
y_1236 = Add(GetIdx(L_1156, 2D), ((V)(1.5)));
T_1237 = Arr(Call(ball_12, V.Undef, ((V)(x_1235)), ((V)((ToNum(y_1236) - 1.4))), ((V)((ToNum(zf_1199) - 1.2))), ((V)(1.2)), ((V)("#f0c24a")), NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).Put("noOut", ((V)(1D))).V), Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("y"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(x_1235)), ((V)((ToNum(zf_1199) - 1.2))))).Put("a", ((V)(0.4))).Put("b", ((V)(1.5))).Put("n", ((V)(8D))).Put("rings", Arr(Arr(((V)((ToNum(y_1236) - 7D))), ((V)(0D)), ((V)(1.6))), Arr(((V)((ToNum(y_1236) - 3.2))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(y_1236) - 2.4))), ((V)(0D)), ((V)(0.5))))).Put("col", ((V)("#d9a83a"))).Put("mat", ((V)("metal"))).Put("noOut", ((V)(1D))).V));
Call(on_1114, V.Undef, S_1154, T_1237, Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
return default;
}
if ((SEq(Get(S_1154, "col"), F0_1116) || SEq(Get(S_1154, "col"), Call(shade_18, V.Undef, F0_1116, ((V)(0.86)))))) {
V D1_1238 = default;
V D2_1239 = default;
{ V _t1240 = Call(sheen_1118, V.Undef, S_1154);
{ V _t1241 = ListOf(_t1240);
{ V _t1242 = GetIdx(_t1241, 0D);
D1_1238 = _t1242; }
{ V _t1243 = GetIdx(_t1241, 1D);
D2_1239 = _t1243; }
} }
Invoke(Call(sides_51, V.Undef, S_1154, ((V)(6D))), "forEach", Fn((V _arrowThis1251, int _argc1244, V F_1250, V _a1247, V _a1248, V _a1249, V[] _rest1245) => {
if ((GtN(GetIdx(Get(F_1250, "n"), 1D), (-0.3)) && GtN(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(F_1250, "q"), 1D), GetIdx(Get(F_1250, "q"), 0D))).V), 6D))) {
Call(velvet_58, V.Undef, D1_1238, D2_1239, F_1250, R_1115, ((V)(2D)));
}
return default;
}, 1, "", true));
Invoke(Call(caps_50, V.Undef, S_1154, ((V)(2D))), "forEach", Fn((V _arrowThis1259, int _argc1252, V F_1258, V _a1255, V _a1256, V _a1257, V[] _rest1253) => {
return Call(velvet_58, V.Undef, D1_1238, D2_1239, F_1258, R_1115, ((V)(2D)));
}, 1, "", true));
Call(on_1114, V.Undef, S_1154, Arr(D1_1238, D2_1239));
}
return default;
}, 1, "", true));
if ((SEqN(li_1112, 1D) || SEqN(li_1112, 3D))) {
V rl_1260 = default;
V ab_1261 = default;
rl_1260 = Invoke(B_1117, "find", Fn((V _arrowThis1269, int _argc1262, V b_1268, V _a1265, V _a1266, V _a1267, V[] _rest1263) => {
return ((((SEq(Get(Get(b_1268, "S"), "col"), F0_1116) ? V.True : V.False) is var _t1270 && !Truthy(_t1270) ? _t1270 : Get(Get(Get(b_1268, "S"), "pts"), "length")) is var _t1271 && !Truthy(_t1271) ? _t1271 : Get(Call(caps_50, V.Undef, Get(b_1268, "S"), ((V)(2D))), "length")) is var _t1272 && !Truthy(_t1272) ? _t1272 : (GtN(GetIdx(Get(b_1268, "L"), 2D), 50D) ? V.True : V.False));
}, 1, "", true));
ab_1261 = Invoke(B_1117, "find", Fn((V _arrowThis1280, int _argc1273, V b_1279, V _a1276, V _a1277, V _a1278, V[] _rest1274) => {
return ((SEq(Get(Get(b_1279, "S"), "col"), F0_1116) && LtN(GetIdx(Get(b_1279, "L"), 2D), 30D)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(rl_1260)) {
V PG_1281 = default;
PG_1281 = Call(dec_24, V.Undef, ((V)("#f0c24a")));
Invoke(Call(caps_50, V.Undef, Get(rl_1260, "S"), ((V)(2D))), "forEach", Fn((V _arrowThis1289, int _argc1282, V F_1288, V _a1285, V _a1286, V _a1287, V[] _rest1283) => {
return Call(outline_47, V.Undef, PG_1281, F_1288, ((V)(0.93)), ((V)(0.75)));
}, 1, "", true));
Call(on_1114, V.Undef, Get(rl_1260, "S"), Arr(PG_1281));
}
if (Truthy(ab_1261)) {
V NL_1290 = default;
V z_1291 = default;
V x0_1292 = default;
double x1_1293 = 0;
V y0_1294 = default;
double y1_1295 = 0;
NL_1290 = Call(dec_24, V.Undef, ((V)("#f3cf62")), NewObj(1).Put("shine", ((V)(1D))).V);
z_1291 = Add(GetIdx(Get(ab_1261, "L"), 5D), ((V)(0.06)));
x0_1292 = Add(GetIdx(Get(ab_1261, "L"), 0D), ((V)(2D)));
x1_1293 = (ToNum(GetIdx(Get(ab_1261, "L"), 1D)) - 2D);
y0_1294 = Add(GetIdx(Get(ab_1261, "L"), 2D), ((V)(2D)));
y1_1295 = (ToNum(GetIdx(Get(ab_1261, "L"), 3D)) - 2D);
{
V y_1296 = default;
y_1296 = y0_1294;
while (true) {
V y_1296_it = y_1296;
if (!(LeN(y_1296_it, y1_1295))) break;
Invoke(Arr(x0_1292, ((V)(x1_1293))), "forEach", Fn((V _arrowThis1305, int _argc1298, V x_1304, V _a1301, V _a1302, V _a1303, V[] _rest1299) => {
return Call(spot_25, V.Undef, NL_1290, Arr(x_1304, y_1296_it, z_1291), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(0.62)), ((V)(0.62)), ((V)(0D)), ((V)(6D)));
}, 1, "", true));
y_1296 = y_1296_it;
y_1296 = Add(y_1296, ((V)(2.7)));
}
}
Call(on_1114, V.Undef, Get(ab_1261, "S"), Arr(NL_1290));
}
}
if (SEqN(li_1112, 0D)) {
V rl_1306 = default;
rl_1306 = Invoke(B_1117, "find", Fn((V _arrowThis1314, int _argc1307, V b_1313, V _a1310, V _a1311, V _a1312, V[] _rest1308) => {
return (((SEq(Get(Get(b_1313, "S"), "col"), F0_1116) && ((ToNum(GetIdx(Get(b_1313, "L"), 1D)) - ToNum(GetIdx(Get(b_1313, "L"), 0D))) > 200D)) && ((ToNum(GetIdx(Get(b_1313, "L"), 3D)) - ToNum(GetIdx(Get(b_1313, "L"), 2D))) < 14D)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(rl_1306)) {
V L_1315 = default;
double zc_1316 = 0;
V y0_1317 = default;
double a_1318 = 0;
double bb_1319 = 0;
V CR_1320 = default;
V FN_1321 = default;
V FL_1322 = default;
V HL_1323 = default;
V SC_1324 = default;
L_1315 = Get(rl_1306, "L");
zc_1316 = (ToNum(Add(GetIdx(L_1315, 4D), GetIdx(L_1315, 5D))) / 2D);
y0_1317 = Add(GetIdx(L_1315, 3D), ((V)(0.3)));
a_1318 = 14D;
bb_1319 = 10D;
CR_1320 = Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), Add(y0_1317, ((V)(bb_1319))))).Put("a", ((V)(a_1318))).Put("b", ((V)(bb_1319))).Put("n", ((V)(22D))).Put("rings", Arr(Arr(((V)((zc_1316 - 1.1))), ((V)(0.7)), ((V)(0.9))), Arr(((V)((zc_1316 - 0.5))), ((V)(0D))), Arr(((V)((zc_1316 + 0.5))), ((V)(0D))), Arr(((V)((zc_1316 + 1.1))), ((V)(0.7)), ((V)(0.9))))).Put("col", GOLD_23).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V);
FN_1321 = Call(ball_12, V.Undef, ((V)(0D)), ((V)((ToNum(Add(y0_1317, ((V)((bb_1319 * 2D))))) - 0.6))), ((V)(zc_1316)), ((V)(1.7)), ((V)("#f0c24a")), NewObj(4).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).Put("mat", ((V)("metal"))).V);
FL_1322 = Call(dec_24, V.Undef, ((V)("#9a6a14")), NewObj(1).Put("op", ((V)(0.75))).V);
HL_1323 = Call(dec_24, V.Undef, ((V)("#fff1b0")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Arr(((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis1332, int _argc1325, V c0_1331, V _a1328, V _a1329, V _a1330, V[] _rest1326) => {
return Invoke(Call(caps_50, V.Undef, CR_1320, c0_1331), "forEach", Fn((V _arrowThis1340, int _argc1333, V F_1339, V _a1336, V _a1337, V _a1338, V[] _rest1334) => {
V G_1341 = default;
G_1341 = Call(fr2_39, V.Undef, F_1339);
Call(rep_29, V.Undef, ((V)(9D)), Fn((V _arrowThis1349, int _argc1342, V i_1348, V _a1345, V _a1346, V _a1347, V[] _rest1343) => {
double t_1350 = 0;
double r0_1351 = 0;
double r1_1352 = 0;
t_1350 = (PI_22 * (0.1 + ((0.8 * ToNum(i_1348)) / 8D)));
r0_1351 = 2.2;
r1_1352 = 9.4;
Invoke((NumTruthy((ToNum(i_1348) % 2D)) ? HL_1323 : FL_1322), "line", Arr(Invoke(G_1341, "at", ((V)(((FdLibm.Cos(t_1350) * r0_1351) * (SEqN(c0_1331, 1D) ? (-1D) : 1D)))), ((V)((((-bb_1319) + 1.4) + (FdLibm.Sin(t_1350) * r0_1351))))), Invoke(G_1341, "at", ((V)(((FdLibm.Cos(t_1350) * r1_1352) * (SEqN(c0_1331, 1D) ? (-1D) : 1D)))), ((V)((((-bb_1319) + 1.4) + (FdLibm.Sin(t_1350) * r1_1352)))))), Get(G_1341, "n"), ((V)(0.42)), ((V)(1D)));
return default;
}, 1, "", true));
Invoke(FL_1322, "line", Call(rep_29, V.Undef, ((V)(13D)), Fn((V _arrowThis1360, int _argc1353, V i_1359, V _a1356, V _a1357, V _a1358, V[] _rest1354) => {
double t_1361 = 0;
t_1361 = ((PI_22 * ToNum(i_1359)) / 12D);
return Invoke(G_1341, "at", ((V)((FdLibm.Cos(t_1361) * 11D))), ((V)((((-bb_1319) + 1.2) + (FdLibm.Sin(t_1361) * 8.8)))));
return default;
}, 1, "", true)), Get(G_1341, "n"), ((V)(0.5)));
Call(spot_25, V.Undef, FL_1322, Invoke(G_1341, "at", ((V)(0D)), ((V)(((-bb_1319) + 2D)))), Get(G_1341, "n"), ((V)(1.5)), ((V)(1.1)), ((V)(0D)), ((V)(8D)));
return default;
}, 1, "", true));
}, 1, "", true));
SC_1324 = Call(dec_24, V.Undef, ((V)("#f0c24a")), NewObj(1).Put("op", ((V)(0.95))).V);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1369, int _argc1362, V sg_1368, V _a1365, V _a1366, V _a1367, V[] _rest1363) => {
Invoke(SC_1324, "line", Call(rep_29, V.Undef, ((V)(16D)), Fn((V _arrowThis1377, int _argc1370, V i_1376, V _a1373, V _a1374, V _a1375, V[] _rest1371) => {
double t_1378 = 0;
double x_1379 = 0;
t_1378 = (ToNum(i_1376) / 15D);
x_1379 = (ToNum(sg_1368) * (15D + (t_1378 * 30D)));
return Arr(((V)(x_1379)), Add(GetIdx(L_1315, 3D), ((V)(0.08))), ((V)((zc_1316 + (FdLibm.Sin(((t_1378 * PI_22) * 2.2)) * 2.4)))));
return default;
}, 1, "", true)), Y3_37, ((V)(0.65)), ((V)(1D)));
Call(rep_29, V.Undef, ((V)(4D)), Fn((V _arrowThis1387, int _argc1380, V j_1386, V _a1383, V _a1384, V _a1385, V[] _rest1381) => {
return Call(spot_25, V.Undef, SC_1324, Arr(((V)((ToNum(sg_1368) * (19D + (ToNum(j_1386) * 7.5))))), Add(GetIdx(L_1315, 3D), ((V)(0.1))), ((V)((zc_1316 + (NumTruthy((ToNum(j_1386) % 2D)) ? 2.6 : (-2.6)))))), Y3_37, ((V)(0.9)), ((V)(0.5)), ((V)((0.5 * ToNum(sg_1368)))), ((V)(6D)));
}, 1, "", true));
return default;
}, 1, "", true));
Call(on_1114, V.Undef, Get(rl_1306, "S"), Arr(CR_1320, FN_1321, SC_1324, FL_1322, HL_1323));
}
}
return default;
}, 3, "", true);
apronTex_60 = Fn((V _arrowThis1396, int _argc1388, V o_1394, V P_1395, V _a1392, V _a1393, V[] _rest1389) => {
V on_1397 = default;
V AP_1398 = default;
V L_1399 = default;
V R_1400 = default;
V LS_1401 = default;
V BO_1402 = default;
V SH_1403 = default;
V FA_1404 = default;
V FB_1405 = default;
V y_1406 = default;
V fr_1407 = default;
on_1397 = Call(glue_27, V.Undef, o_1394);
AP_1398 = Call(at_26, V.Undef, o_1394, Arr(((V)(0D)), ((V)(15D)), ((V)(0D))), GOLD_23);
if (!(Truthy(AP_1398))) {
return default;
}
L_1399 = Call(bbS_38, V.Undef, AP_1398);
R_1400 = Call(R0_28, V.Undef, ((V)("ap25")));
LS_1401 = Call(dec_24, V.Undef, ((V)("#b8862a")), NewObj(1).Put("op", ((V)(0.32))).V);
BO_1402 = Call(dec_24, V.Undef, ((V)("#8a2f22")), NewObj(1).Put("op", ((V)(0.55))).V);
SH_1403 = Call(dec_24, V.Undef, ((V)("#fff1b0")), NewObj(1).Put("op", ((V)(0.35))).V);
FA_1404 = Call(dec_24, V.Undef, ((V)("#e9b94a")));
FB_1405 = Call(dec_24, V.Undef, ((V)("#b8862a")));
Invoke(Call(sides_51, V.Undef, AP_1398, ((V)(3D))), "forEach", Fn((V _arrowThis1415, int _argc1408, V F_1414, V _a1411, V _a1412, V _a1413, V[] _rest1409) => {
V fl_1416 = default;
V G_1417 = default;
V P2_1418 = default;
V xs_1419 = default;
V ys_1420 = default;
double W_1421 = 0;
double H_1422 = 0;
fl_1416 = InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(F_1414, "q"), 1D), GetIdx(Get(F_1414, "q"), 0D))).V);
if (LtN(fl_1416, 4D)) {
return default;
}
Call(hatch_45, V.Undef, LS_1401, F_1414, ((V)(0D)), ((V)(3.6)), ((V)(0.18)), NewObj(1).Put("sh", ((V)(0.99))).V);
Call(hatch_45, V.Undef, LS_1401, F_1414, ((V)((PI_22 / 2D))), ((V)(4.2)), ((V)(0.18)), NewObj(2).Put("sh", ((V)(0.99))).Put("ph", ((V)(1.3))).V);
G_1417 = Call(fr2_39, V.Undef, F_1414);
P2_1418 = Get(G_1417, "P");
xs_1419 = Invoke(P2_1418, "map", Fn((V _arrowThis1430, int _argc1423, V q_1429, V _a1426, V _a1427, V _a1428, V[] _rest1424) => {
return GetIdx(q_1429, 0D);
}, 1, "", true));
ys_1420 = Invoke(P2_1418, "map", Fn((V _arrowThis1438, int _argc1431, V q_1437, V _a1434, V _a1435, V _a1436, V[] _rest1432) => {
return GetIdx(q_1437, 1D);
}, 1, "", true));
W_1421 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_1419).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_1419).V)));
H_1422 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_1420).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_1420).V)));
Call(rep_29, V.Undef, ((V)(Round((W_1421 / 14D)))), Fn((V _arrowThis1445, int _argc1439, V _a1441, V _a1442, V _a1443, V _a1444, V[] _rest1440) => {
double a_1446 = 0;
double b_1447 = 0;
a_1446 = (((-W_1421) / 2D) + (ToNum(Call(R_1400, V.Undef)) * W_1421));
b_1447 = ((LtN(Call(R_1400, V.Undef), 0.5) ? (-1D) : 1D) * ((H_1422 / 2D) - 0.7));
Call(spot_25, V.Undef, BO_1402, Invoke(G_1417, "at", ((V)(a_1446)), ((V)(b_1447))), Get(G_1417, "n"), ((V)((0.6 + (ToNum(Call(R_1400, V.Undef)) * 1.4)))), ((V)((0.35 + (ToNum(Call(R_1400, V.Undef)) * 0.3)))), ((V)(0D)), ((V)(6D)));
return default;
}, 0, "", true));
Invoke(SH_1403, "line", Arr(Invoke(G_1417, "at", ((V)((((-W_1421) / 2D) + 1D))), ((V)(((H_1422 / 2D) - 0.6)))), Invoke(G_1417, "at", ((V)(((W_1421 / 2D) - 1D))), ((V)(((H_1422 / 2D) - 0.6))))), Get(G_1417, "n"), ((V)(0.3)));
return default;
}, 1, "", true));
y_1406 = GetIdx(L_1399, 2D);
fr_1407 = Fn((V _arrowThis1457, int _argc1448, V P0_1454, V P1_1455, V n_1456, V _a1453, V[] _rest1449) => {
double cnt_1458 = 0;
cnt_1458 = Round((ToNum(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, P1_1455, P0_1454)).V)) / 1.15));
Call(rep_29, V.Undef, ((V)(cnt_1458)), Fn((V _arrowThis1466, int _argc1459, V i_1465, V _a1462, V _a1463, V _a1464, V[] _rest1460) => {
V p_1467 = default;
V lift_1468 = default;
p_1467 = Call(add_30, V.Undef, P0_1454, Call(mul_32, V.Undef, Call(sub_31, V.Undef, P1_1455, P0_1454), ((V)((ToNum(Add(i_1465, ((V)(0.5)))) / cnt_1458)))));
lift_1468 = Call(add_30, V.Undef, p_1467, Call(mul_32, V.Undef, n_1456, ((V)(0.25))));
Invoke((NumTruthy((ToNum(i_1465) % 2D)) ? FB_1405 : FA_1404), "line", Arr(Arr(GetIdx(lift_1468, 0D), Add(y_1406, ((V)(0.2))), GetIdx(lift_1468, 2D)), Arr(GetIdx(lift_1468, 0D), ((V)((ToNum(y_1406) - 3.4))), GetIdx(lift_1468, 2D))), n_1456, ((V)(0.62)));
return default;
}, 1, "", true));
return default;
}, 3, "", true);
Call(fr_1407, V.Undef, Arr(Add(GetIdx(L_1399, 0D), ((V)(2D))), ((V)(0D)), GetIdx(L_1399, 5D)), Arr(((V)((ToNum(GetIdx(L_1399, 1D)) - 2D))), ((V)(0D)), GetIdx(L_1399, 5D)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(fr_1407, V.Undef, Arr(((V)((ToNum(GetIdx(L_1399, 1D)) - 2D))), ((V)(0D)), GetIdx(L_1399, 4D)), Arr(Add(GetIdx(L_1399, 0D), ((V)(2D))), ((V)(0D)), GetIdx(L_1399, 4D)), Arr(((V)(0D)), ((V)(0D)), ((V)((-1D)))));
Call(fr_1407, V.Undef, Arr(GetIdx(L_1399, 1D), ((V)(0D)), ((V)((ToNum(GetIdx(L_1399, 5D)) - 2D)))), Arr(GetIdx(L_1399, 1D), ((V)(0D)), Add(GetIdx(L_1399, 4D), ((V)(2D)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))));
Call(fr_1407, V.Undef, Arr(GetIdx(L_1399, 0D), ((V)(0D)), Add(GetIdx(L_1399, 4D), ((V)(2D)))), Arr(GetIdx(L_1399, 0D), ((V)(0D)), ((V)((ToNum(GetIdx(L_1399, 5D)) - 2D)))), Arr(((V)((-1D))), ((V)(0D)), ((V)(0D))));
Call(on_1397, V.Undef, AP_1398, Arr(LS_1401, BO_1402, SH_1403, FA_1404, FB_1405));
return default;
}, 2, "", true);
Set(N_21, "chester25", Fn((V _arrowThis1476, int _argc1469, V S_1475, V _a1472, V _a1473, V _a1474, V[] _rest1470) => {
V B_1477 = default;
V D_1478 = default;
B_1477 = Invoke(N_21, "chester", S_1475);
D_1478 = Object_assign(NewObj(0).V, B_1477);
Set(D_1478, "layers", Invoke(Get(B_1477, "layers"), "map", Fn((V _arrowThis1487, int _argc1479, V L_1485, V i_1486, V _a1483, V _a1484, V[] _rest1480) => {
return Object_assign(NewObj(0).V, L_1485, NewObj(1).Put("build", Fn((V _arrowThis1495, int _argc1488, V P_1494, V _a1491, V _a1492, V _a1493, V[] _rest1489) => {
V o_1496 = default;
o_1496 = Invoke(L_1485, "build", P_1494);
Call(chesTex_59, V.Undef, o_1496, P_1494, i_1486);
return o_1496;
return default;
}, 1, "build", true)).V);
}, 2, "", true)));
Set(D_1478, "build", Fn((V _arrowThis1504, int _argc1497, V P_1503, V _a1500, V _a1501, V _a1502, V[] _rest1498) => {
V o_1505 = default;
o_1505 = Invoke(B_1477, "build", P_1503);
if (Truthy(Get(S_1475, "gold"))) {
Call(apronTex_60, V.Undef, o_1505, P_1503);
}
return o_1505;
return default;
}, 1, "", true));
return D_1478;
return default;
}, 1, "", true));
CF_61 = ((V)("#26282e"));
thrTex_62 = Fn((V _arrowThis1514, int _argc1506, V o_1512, V P_1513, V _a1510, V _a1511, V[] _rest1507) => {
V on_1515 = default;
V R_1516 = default;
V B_1517 = default;
on_1515 = Call(glue_27, V.Undef, o_1512);
R_1516 = Call(R0_28, V.Undef, ((V)("th25")));
B_1517 = Invoke(Invoke(o_1512, "map", Fn((V _arrowThis1533, int _argc1526, V S_1532, V _a1529, V _a1530, V _a1531, V[] _rest1527) => {
return NewObj(2).Put("S", S_1532).Put("L", Call(bbS_38, V.Undef, S_1532)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis1525, int _argc1518, V b_1524, V _a1521, V _a1522, V _a1523, V[] _rest1519) => {
return ((!(Truthy(Get(Get(b_1524, "S"), "par"))) && !(Truthy(Get(Get(b_1524, "S"), "emit")))) ? V.True : V.False);
}, 1, "", true));
Invoke(B_1517, "forEach", Fn((V _arrowThis1544, int _argc1534, V _a1536, V _a1537, V _a1538, V _a1539, V[] _rest1535) => {
double w_1545 = 0;
double h_1546 = 0;
double d_1547 = 0;
V S_1541 = default;
V L_1543 = default;
if (_a1536.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a1536));
{ V _t1540 = Get(_a1536, "S");
S_1541 = _t1540; }
{ V _t1542 = Get(_a1536, "L");
L_1543 = _t1542; }
w_1545 = (ToNum(GetIdx(L_1543, 1D)) - ToNum(GetIdx(L_1543, 0D)));
h_1546 = (ToNum(GetIdx(L_1543, 3D)) - ToNum(GetIdx(L_1543, 2D)));
d_1547 = (ToNum(GetIdx(L_1543, 5D)) - ToNum(GetIdx(L_1543, 4D)));
if (SEq(Get(S_1541, "col"), Get(P_1513, "a"))) {
V T1_1548 = default;
V T2_1549 = default;
V CC_1550 = default;
V fc_1551 = default;
Set(S_1541, "col", CF_61);
Set(S_1541, "mat", ((V)("pl")));
Set(S_1541, "shine", ((V)(1D)));
Set(S_1541, "soft", ((V)(0D)));
T1_1548 = Call(dec_24, V.Undef, ((V)("#4a4e57")), NewObj(1).Put("op", ((V)(0.55))).V);
T2_1549 = Call(dec_24, V.Undef, ((V)("#0d0e11")), NewObj(1).Put("op", ((V)(0.6))).V);
CC_1550 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.22))).V);
Invoke(Get(S_1541, "faces"), "forEach", Fn((V _arrowThis1559, int _argc1552, V F_1558, V _a1555, V _a1556, V _a1557, V[] _rest1553) => {
V G_1560 = default;
G_1560 = Call(fr2_39, V.Undef, F_1558);
if ((System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(G_1560, "P")))) < 4D)) {
return default;
}
Call(hatch_45, V.Undef, T1_1548, F_1558, ((V)((PI_22 / 4D))), ((V)(1.7)), ((V)(0.4)), NewObj(1).Put("sh", ((V)(0.98))).V);
Call(hatch_45, V.Undef, T2_1549, F_1558, ((V)(((-PI_22) / 4D))), ((V)(1.7)), ((V)(0.4)), NewObj(2).Put("sh", ((V)(0.98))).Put("ph", ((V)(0.85))).V);
return default;
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, S_1541, ((V)(4D))), "forEach", Fn((V _arrowThis1568, int _argc1561, V F_1567, V _a1564, V _a1565, V _a1566, V[] _rest1562) => {
if ((GtN(GetIdx(Get(F_1567, "n"), 1D), 0.25) || ((System.Math.Abs(ToNum(GetIdx(Get(F_1567, "n"), 2D))) > 0.8) && LtN(Call(R_1516, V.Undef), 0.5)))) {
Call(wavy_46, V.Undef, CC_1550, F_1567, Fn((V _arrowThis1577, int _argc1569, V t_1575, V G_1576, V _a1573, V _a1574, V[] _rest1570) => {
V xs_1578 = default;
V ys_1579 = default;
double W_1580 = 0;
double H_1581 = 0;
xs_1578 = Invoke(Get(G_1576, "P"), "map", Fn((V _arrowThis1589, int _argc1582, V q_1588, V _a1585, V _a1586, V _a1587, V[] _rest1583) => {
return GetIdx(q_1588, 0D);
}, 1, "", true));
ys_1579 = Invoke(Get(G_1576, "P"), "map", Fn((V _arrowThis1597, int _argc1590, V q_1596, V _a1593, V _a1594, V _a1595, V[] _rest1591) => {
return GetIdx(q_1596, 1D);
}, 1, "", true));
W_1580 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_1578).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_1578).V)));
H_1581 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_1579).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_1579).V)));
return Arr(((V)((((-W_1580) / 2D) + (W_1580 * ToNum(t_1575))))), ((V)((H_1581 * 0.25))));
return default;
}, 2, "", true), ((V)(6D)), ((V)(0.9)), ((V)(1D)));
}
return default;
}, 1, "", true));
Call(on_1515, V.Undef, S_1541, Arr(T1_1548, T2_1549, CC_1550));
fc_1551 = Invoke(Call(caps_50, V.Undef, S_1541, ((V)(2D))), "filter", Fn((V _arrowThis1605, int _argc1598, V F_1604, V _a1601, V _a1602, V _a1603, V[] _rest1599) => {
return (GtN(GetIdx(Get(F_1604, "n"), 2D), 0.9) ? V.True : V.False);
}, 1, "", true));
if (Truthy((Get(fc_1551, "length") is var _t1606 && !Truthy(_t1606) ? _t1606 : (GtN(GetIdx(L_1543, 2D), 40D) ? V.True : V.False)))) {
V LD_1607 = default;
LD_1607 = Call(dec_24, V.Undef, ((V)("#5fe6ff")), NewObj(1).Put("emit", ((V)(1D))).V);
Invoke(fc_1551, "forEach", Fn((V _arrowThis1615, int _argc1608, V F_1614, V _a1611, V _a1612, V _a1613, V[] _rest1609) => {
return Call(outline_47, V.Undef, LD_1607, F_1614, ((V)(0.9)), ((V)(0.55)));
}, 1, "", true));
if ((h_1546 > 20D)) {
V GR_1616 = default;
V GD_1617 = default;
GR_1616 = Call(dec_24, V.Undef, ((V)("#0a0b0d")));
GD_1617 = Call(dec_24, V.Undef, ((V)("#6d7380")), NewObj(1).Put("op", ((V)(0.8))).V);
Invoke(fc_1551, "forEach", Fn((V _arrowThis1625, int _argc1618, V F_1624, V _a1621, V _a1622, V _a1623, V[] _rest1619) => {
V G_1626 = default;
G_1626 = Call(fr2_39, V.Undef, F_1624);
Invoke(GR_1616, "poly", Call(rep_29, V.Undef, ((V)(16D)), Fn((V _arrowThis1634, int _argc1627, V i_1633, V _a1630, V _a1631, V _a1632, V[] _rest1628) => {
double a_1635 = 0;
a_1635 = (((ToNum(i_1633) / 16D) * 2D) * PI_22);
return Invoke(G_1626, "at", ((V)((FdLibm.Cos(a_1635) * 5.2))), ((V)((2D + (FdLibm.Sin(a_1635) * 5.2)))));
return default;
}, 1, "", true)), Get(G_1626, "n"));
Call(rep_29, V.Undef, ((V)(5D)), Fn((V _arrowThis1643, int _argc1636, V i_1642, V _a1639, V _a1640, V _a1641, V[] _rest1637) => {
return Call(rep_29, V.Undef, ((V)(5D)), Fn((V _arrowThis1651, int _argc1644, V j_1650, V _a1647, V _a1648, V _a1649, V[] _rest1645) => {
double a_1652 = 0;
double b_1653 = 0;
a_1652 = ((-4D) + (ToNum(i_1642) * 2D));
b_1653 = ((-2D) + (ToNum(j_1650) * 2D));
if ((((a_1652 * a_1652) + (b_1653 * b_1653)) < 19D)) {
Call(spot_25, V.Undef, GD_1617, Invoke(G_1626, "at", ((V)(a_1652)), ((V)((2D + b_1653)))), Get(G_1626, "n"), ((V)(0.38)), ((V)(0.38)), ((V)(0D)), ((V)(5D)));
}
return default;
}, 1, "", true));
}, 1, "", true));
return default;
}, 1, "", true));
Call(on_1515, V.Undef, S_1541, Arr(GR_1616, GD_1617));
}
Call(on_1515, V.Undef, S_1541, Arr(LD_1607));
}
if (((w_1545 > 50D) && (h_1546 > 40D))) {
V EM_1654 = default;
EM_1654 = Call(dec_24, V.Undef, ((V)("#5fe6ff")), NewObj(1).Put("emit", ((V)(1D))).V);
Invoke(Call(caps_50, V.Undef, S_1541, ((V)(1D))), "forEach", Fn((V _arrowThis1662, int _argc1655, V F_1661, V _a1658, V _a1659, V _a1660, V[] _rest1656) => {
V G_1663 = default;
V Q_1664 = default;
double yy_1665 = 0;
if (GtN(GetIdx(Get(F_1661, "n"), 2D), (-0.9))) {
return default;
}
G_1663 = Call(fr2_39, V.Undef, F_1661);
Q_1664 = Fn((V _arrowThis1674, int _argc1666, V a_1672, V b_1673, V _a1670, V _a1671, V[] _rest1667) => {
return Invoke(G_1663, "at", a_1672, b_1673);
}, 2, "", true);
yy_1665 = 6D;
Invoke(EM_1654, "line", Arr(Call(Q_1664, V.Undef, ((V)((-9D))), ((V)((yy_1665 - 4D)))), Call(Q_1664, V.Undef, ((V)(0D)), ((V)((yy_1665 + 4D)))), Call(Q_1664, V.Undef, ((V)(9D)), ((V)((yy_1665 - 4D))))), Get(G_1663, "n"), ((V)(0.9)));
Invoke(EM_1654, "line", Arr(Call(Q_1664, V.Undef, ((V)((-6D))), ((V)((yy_1665 - 8D)))), Call(Q_1664, V.Undef, ((V)(0D)), ((V)((yy_1665 - 2.5)))), Call(Q_1664, V.Undef, ((V)(6D)), ((V)((yy_1665 - 8D))))), Get(G_1663, "n"), ((V)(0.7)));
Call(spot_25, V.Undef, EM_1654, Call(Q_1664, V.Undef, ((V)(0D)), ((V)((yy_1665 + 7D)))), Get(G_1663, "n"), ((V)(1D)), ((V)(1D)), ((V)(0D)), ((V)(8D)));
return default;
}, 1, "", true));
Call(on_1515, V.Undef, S_1541, Arr(EM_1654));
}
return default;
}
if (SEq(Get(S_1541, "col"), Get(P_1513, "aL"))) {
V QD_1675 = default;
V QL_1676 = default;
V PF_1677 = default;
V WL_1678 = default;
double nr_1679 = 0;
Set(S_1541, "mat", ((V)("lea")));
QD_1675 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_1541, "col"), ((V)(0.7))), NewObj(1).Put("op", ((V)(0.6))).V);
QL_1676 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_1541, "col"), ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.4))).V);
PF_1677 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_1541, "col"), ((V)(0.55))), NewObj(1).Put("op", ((V)(0.7))).V);
WL_1678 = Call(dec_24, V.Undef, ((V)("#d5dde2")), NewObj(1).Put("op", ((V)(0.8))).V);
Invoke(Call(caps_50, V.Undef, S_1541, ((V)(2D))), "forEach", Fn((V _arrowThis1687, int _argc1680, V F_1686, V _a1683, V _a1684, V _a1685, V[] _rest1681) => {
Call(hatch_45, V.Undef, QD_1675, F_1686, ((V)((PI_22 / 4D))), ((V)(5.5)), ((V)(0.5)), NewObj(1).Put("sh", ((V)(0.9))).V);
Call(hatch_45, V.Undef, QD_1675, F_1686, ((V)(((-PI_22) / 4D))), ((V)(5.5)), ((V)(0.5)), NewObj(1).Put("sh", ((V)(0.9))).V);
Call(hatch_45, V.Undef, QL_1676, F_1686, ((V)((PI_22 / 4D))), ((V)(5.5)), ((V)(0.18)), NewObj(2).Put("sh", ((V)(0.9))).Put("ph", ((V)(0.5))).V);
Call(hatch_45, V.Undef, QL_1676, F_1686, ((V)(((-PI_22) / 4D))), ((V)(5.5)), ((V)(0.18)), NewObj(2).Put("sh", ((V)(0.9))).Put("ph", ((V)(0.5))).V);
Call(dots_48, V.Undef, PF_1677, F_1686, ((V)(1.9)), ((V)(0.24)), NewObj(3).Put("sh", ((V)(0.82))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).V);
return default;
}, 1, "", true));
nr_1679 = ((h_1546 < 22D) ? 6D : 5D);
if (((ToNum(Get(Get(S_1541, "pts"), "length")) % nr_1679) == 0D)) {
Call(ringL_49, V.Undef, WL_1678, S_1541, ((V)((nr_1679 - 2D))), ((V)(nr_1679)), ((V)(0.35)), ((V)(((nr_1679 == 6D) ? 0.6 : 0D))));
}
Call(on_1515, V.Undef, S_1541, Arr(QD_1675, QL_1676, PF_1677, WL_1678));
return default;
}
if (SEq(Get(S_1541, "col"), Get(P_1513, "aD"))) {
Set(S_1541, "col", ((V)("#1b1d22")));
Set(S_1541, "mat", ((V)("pl")));
}
return default;
}, 1, "", true));
return default;
}, 2, "", true);
gyro_63 = Fn((V _arrowThis1702, int _argc1688, V c_1694, V R_1695, V y_1696, V zc_1697, V[] _rest1689) => {
V p_1703 = default;
double m_1704 = 0;
V Q_1705 = default;
V cy_1706 = default;
V runs_1707 = default;
V cur_1708 = default;
V kind_1709 = default;
V mk_1710 = default;
V xs_1711 = default;
V ys_1712 = default;
V col_1698 = default;
V dur_1699 = default;
V rev_1700 = default;
V tilt_1701 = default;
col_1698 = (_argc1688 > 4 ? _rest1689[0] : V.Undef);
dur_1699 = (_argc1688 > 5 ? _rest1689[1] : V.Undef);
rev_1700 = (_argc1688 > 6 ? _rest1689[2] : V.Undef);
tilt_1701 = (_argc1688 > 7 ? _rest1689[3] : V.Undef);
p_1703 = Get(c_1694, "p");
m_1704 = 56D;
Q_1705 = Call(rep_29, V.Undef, ((V)((m_1704 + 1D))), Fn((V _arrowThis1720, int _argc1713, V i_1719, V _a1716, V _a1717, V _a1718, V[] _rest1714) => {
double t_1721 = 0;
t_1721 = (((ToNum(i_1719) / m_1704) * 2D) * PI_22);
return Call(p_1703, V.Undef, ((V)((FdLibm.Cos(t_1721) * ToNum(R_1695)))), Add(Add(y_1696, ((V)((FdLibm.Sin((t_1721 * 2D)) * 0D)))), ((V)((FdLibm.Sin(t_1721) * ToNum((tilt_1701 is var _t1722 && Truthy(_t1722) ? _t1722 : ((V)(0D)))))))), Add(zc_1697, ((V)((FdLibm.Sin(t_1721) * ToNum(R_1695))))));
return default;
}, 1, "", true));
cy_1706 = GetIdx(Call(p_1703, V.Undef, ((V)(0D)), y_1696, zc_1697), 1D);
runs_1707 = NewObj(2).Put("b", Arr()).Put("f", Arr()).V;
cur_1708 = V.Null;
kind_1709 = V.Null;
Invoke(Q_1705, "forEach", Fn((V _arrowThis1730, int _argc1723, V q_1729, V _a1726, V _a1727, V _a1728, V[] _rest1724) => {
V k_1731 = default;
k_1731 = ((V)((Lt(GetIdx(q_1729, 1D), cy_1706) ? "b" : "f")));
if (!SEq(k_1731, kind_1709)) {
if (Truthy((cur_1708 is var _t1732 && !Truthy(_t1732) ? _t1732 : (GtN(Get(cur_1708, "length"), 1D) ? V.True : V.False)))) {
Invoke(GetK(runs_1707, kind_1709), "push", cur_1708);
}
cur_1708 = (Truthy(cur_1708) ? Arr(GetIdx(cur_1708, (ToNum(Get(cur_1708, "length")) - 1D))) : Arr());
kind_1709 = k_1731;
}
Invoke(cur_1708, "push", q_1729);
return default;
}, 1, "", true));
if (Truthy((cur_1708 is var _t1733 && !Truthy(_t1733) ? _t1733 : (GtN(Get(cur_1708, "length"), 1D) ? V.True : V.False)))) {
Invoke(GetK(runs_1707, kind_1709), "push", cur_1708);
}
mk_1710 = Fn((V _arrowThis1742, int _argc1734, V L_1740, V op_1741, V _a1738, V _a1739, V[] _rest1735) => {
return Invoke(Invoke(L_1740, "map", Fn((V _arrowThis1750, int _argc1743, V P_1749, V _a1746, V _a1747, V _a1748, V[] _rest1744) => {
V d_1751 = default;
d_1751 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(P_1749, "map", Fn((V _arrowThis1759, int _argc1752, V q_1758, V _a1755, V _a1756, V _a1757, V[] _rest1753) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(q_1758, 0D))).S(" ").V(Call(f1_20, V.Undef, GetIdx(q_1758, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).End()));
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(d_1751).S("\" fill=\"none\" stroke=\"#0d0f14\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(c_1694, "k")) * 1.5))))).S("\" stroke-linecap=\"round\" opacity=\"").N((ToNum(op_1741) * 0.55)).S("\"/><path d=\"").V(d_1751).S("\" fill=\"none\" stroke=\"").V(col_1698).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(c_1694, "k")) * 0.6))))).S("\" stroke-linecap=\"round\" opacity=\"").N((ToNum(op_1741) * 0.6)).S("\"/><path d=\"").V(d_1751).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(c_1694, "k")) * 0.75))))).S("\" stroke-linecap=\"round\" stroke-dasharray=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(c_1694, "k")) * 1.6))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(c_1694, "k")) * 10.4))))).S("\" opacity=\"").V(op_1741).S("\"><animate attributeName=\"stroke-dashoffset\" values=\"0;").V(Call(f1_20, V.Undef, ((V)((((Truthy(rev_1700) ? 1D : (-1D)) * ToNum(Get(c_1694, "k"))) * 36D))))).S("\" dur=\"").V(dur_1699).S("s\" repeatCount=\"indefinite\"/></path>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
}, 2, "", true);
xs_1711 = Invoke(Q_1705, "map", Fn((V _arrowThis1767, int _argc1760, V q_1766, V _a1763, V _a1764, V _a1765, V[] _rest1761) => {
return GetIdx(q_1766, 0D);
}, 1, "", true));
ys_1712 = Invoke(Q_1705, "map", Fn((V _arrowThis1775, int _argc1768, V q_1774, V _a1771, V _a1772, V _a1773, V[] _rest1769) => {
return GetIdx(q_1774, 1D);
}, 1, "", true));
return NewObj(3).Put("back", Call(mk_1710, V.Undef, Get(runs_1707, "b"), ((V)(0.55)))).Put("front", Call(mk_1710, V.Undef, Get(runs_1707, "f"), ((V)(0.95)))).Put("bb", Arr(((V)((ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_1711).V)) - 3D))), ((V)((ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_1712).V)) - 3D))), Add(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_1711).V), ((V)(3D))), Add(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_1712).V), ((V)(3D))))).V;
return default;
}, 8, "", true);
mvPts_64 = Fn((V _arrowThis1784, int _argc1776, V S_1782, V f_1783, V _a1780, V _a1781, V[] _rest1777) => {
V seen_1785 = default;
seen_1785 = New(G("Set"));
Invoke(Get(S_1782, "pts"), "forEach", Fn((V _arrowThis1793, int _argc1786, V p_1792, V _a1789, V _a1790, V _a1791, V[] _rest1787) => {
V q_1794 = default;
if (Truthy(Invoke(seen_1785, "has", p_1792))) {
return default;
}
Invoke(seen_1785, "add", p_1792);
q_1794 = Call(f_1783, V.Undef, p_1792);
SetIdx(p_1792, 0D, GetIdx(q_1794, 0D));
SetIdx(p_1792, 1D, GetIdx(q_1794, 1D));
SetIdx(p_1792, 2D, GetIdx(q_1794, 2D));
return default;
}, 1, "", true));
return default;
}, 2, "", true);
thrFix_65 = Fn((V _arrowThis1803, int _argc1795, V o_1801, V P_1802, V _a1799, V _a1800, V[] _rest1796) => {
V B_1804 = default;
V bc_1805 = default;
V st_1806 = default;
B_1804 = Invoke(o_1801, "map", Fn((V _arrowThis1814, int _argc1807, V S_1813, V _a1810, V _a1811, V _a1812, V[] _rest1808) => {
return NewObj(2).Put("S", S_1813).Put("L", Call(bbS_38, V.Undef, S_1813)).V;
}, 1, "", true));
bc_1805 = Invoke(B_1804, "find", Fn((V _arrowThis1822, int _argc1815, V b_1821, V _a1818, V _a1819, V _a1820, V[] _rest1816) => {
return (((SEq(Get(Get(b_1821, "S"), "col"), Get(P_1802, "aL")) && LtN(GetIdx(Get(b_1821, "L"), 5D), 0D)) && ((ToNum(GetIdx(Get(b_1821, "L"), 3D)) - ToNum(GetIdx(Get(b_1821, "L"), 2D))) > 30D)) ? V.True : V.False);
}, 1, "", true));
st_1806 = Invoke(B_1804, "find", Fn((V _arrowThis1830, int _argc1823, V b_1829, V _a1826, V _a1827, V _a1828, V[] _rest1824) => {
return ((SEq(Get(Get(b_1829, "S"), "col"), Get(P_1802, "aL")) && GtN(GetIdx(Get(b_1829, "L"), 5D), 15D)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(bc_1805)) {
V L_1831 = default;
V z0_1832 = default;
double zt_1833 = 0;
double kz_1834 = 0;
double kx_1835 = 0;
double cx_1836 = 0;
L_1831 = Get(bc_1805, "L");
z0_1832 = GetIdx(L_1831, 4D);
zt_1833 = Min(ToNum(GetIdx(L_1831, 5D)), (ToNum((Truthy(st_1806) ? GetIdx(Get(st_1806, "L"), 4D) : GetIdx(L_1831, 5D))) - 0.3));
kz_1834 = ((zt_1833 - ToNum(z0_1832)) / (ToNum(GetIdx(L_1831, 5D)) - ToNum(GetIdx(L_1831, 4D))));
kx_1835 = (26.6 / Max(26.6, ((ToNum(GetIdx(L_1831, 1D)) - ToNum(GetIdx(L_1831, 0D))) / 2D)));
cx_1836 = (ToNum(Add(GetIdx(L_1831, 0D), GetIdx(L_1831, 1D))) / 2D);
Call(mvPts_64, V.Undef, Get(bc_1805, "S"), Fn((V _arrowThis1844, int _argc1837, V p_1843, V _a1840, V _a1841, V _a1842, V[] _rest1838) => {
return Arr(((V)((cx_1836 + ((ToNum(GetIdx(p_1843, 0D)) - cx_1836) * kx_1835)))), GetIdx(p_1843, 1D), Add(z0_1832, ((V)(((ToNum(GetIdx(p_1843, 2D)) - ToNum(z0_1832)) * kz_1834)))));
}, 1, "", true));
}
if (Truthy(st_1806)) {
V L_1845 = default;
double cx_1846 = 0;
double kx_1847 = 0;
L_1845 = Get(st_1806, "L");
cx_1846 = (ToNum(Add(GetIdx(L_1845, 0D), GetIdx(L_1845, 1D))) / 2D);
kx_1847 = (26.4 / Max(26.4, ((ToNum(GetIdx(L_1845, 1D)) - ToNum(GetIdx(L_1845, 0D))) / 2D)));
Call(mvPts_64, V.Undef, Get(st_1806, "S"), Fn((V _arrowThis1855, int _argc1848, V p_1854, V _a1851, V _a1852, V _a1853, V[] _rest1849) => {
return Arr(((V)((cx_1846 + ((ToNum(GetIdx(p_1854, 0D)) - cx_1846) * kx_1847)))), GetIdx(p_1854, 1D), GetIdx(p_1854, 2D));
}, 1, "", true));
}
return default;
}, 2, "", true);
thrGlue_66 = Fn((V _arrowThis1864, int _argc1856, V o_1862, V P_1863, V _a1860, V _a1861, V[] _rest1857) => {
V B_1865 = default;
B_1865 = Invoke(Invoke(o_1862, "map", Fn((V _arrowThis1881, int _argc1874, V S_1880, V _a1877, V _a1878, V _a1879, V[] _rest1875) => {
return NewObj(2).Put("S", S_1880).Put("L", Call(bbS_38, V.Undef, S_1880)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis1873, int _argc1866, V b_1872, V _a1869, V _a1870, V _a1871, V[] _rest1867) => {
return (!(Truthy(Get(Get(b_1872, "S"), "par"))) ? V.True : V.False);
}, 1, "", true));
Invoke(Invoke(B_1865, "filter", Fn((V _arrowThis1906, int _argc1899, V b_1905, V _a1902, V _a1903, V _a1904, V[] _rest1900) => {
return (((SEq(Get(Get(b_1905, "S"), "col"), CF_61) && GtN(GetIdx(Get(b_1905, "L"), 2D), 65D)) && ((ToNum(GetIdx(Get(b_1905, "L"), 1D)) - ToNum(GetIdx(Get(b_1905, "L"), 0D))) < 26D)) ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis1889, int _argc1882, V w_1888, V _a1885, V _a1886, V _a1887, V[] _rest1883) => {
V r_1890 = default;
r_1890 = Invoke(B_1865, "find", Fn((V _arrowThis1898, int _argc1891, V b_1897, V _a1894, V _a1895, V _a1896, V[] _rest1892) => {
return ((((!SEq(b_1897, w_1888) && SEq(Get(Get(b_1897, "S"), "col"), CF_61)) && (System.Math.Abs((ToNum(GetIdx(Get(b_1897, "L"), 3D)) - ToNum(GetIdx(Get(w_1888, "L"), 2D)))) < 1.5)) && (Sign(ToNum(Add(GetIdx(Get(b_1897, "L"), 0D), GetIdx(Get(b_1897, "L"), 1D)))) == Sign(ToNum(Add(GetIdx(Get(w_1888, "L"), 0D), GetIdx(Get(w_1888, "L"), 1D)))))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(r_1890)) {
Set(Get(w_1888, "S"), "par", Get(r_1890, "S"));
}
return default;
}, 1, "", true));
return default;
}, 2, "", true);
Set(N_21, "throne25", Fn((V _arrowThis1914, int _argc1907, V S_1913, V _a1910, V _a1911, V _a1912, V[] _rest1908) => {
V B_1915 = default;
V D_1916 = default;
double by_1917 = 0;
B_1915 = Invoke(N_21, "rsofa", Object_assign(NewObj(0).V, S_1913, NewObj(2).Put("n", ((V)(1D))).Put("float", ((V)(1D))).V));
D_1916 = Object_assign(NewObj(0).V, B_1915);
by_1917 = 23D;
Set(D_1916, "build", Fn((V _arrowThis1925, int _argc1918, V P_1924, V _a1921, V _a1922, V _a1923, V[] _rest1919) => {
V o_1926 = default;
o_1926 = Invoke(B_1915, "build", P_1924);
Call(thrFix_65, V.Undef, o_1926, P_1924);
Call(thrTex_62, V.Undef, o_1926, P_1924);
Call(thrGlue_66, V.Undef, o_1926, P_1924);
return o_1926;
return default;
}, 1, "", true));
Set(D_1916, "layers", Invoke(Call(splitL_54, V.Undef, B_1915), "map", Fn((V _arrowThis1934, int _argc1927, V L_1933, V _a1930, V _a1931, V _a1932, V[] _rest1928) => {
return Object_assign(NewObj(0).V, L_1933, NewObj(1).Put("build", Fn((V _arrowThis1942, int _argc1935, V P_1941, V _a1938, V _a1939, V _a1940, V[] _rest1936) => {
V o_1943 = default;
o_1943 = Invoke(L_1933, "build", P_1941);
Call(thrFix_65, V.Undef, o_1943, P_1941);
Call(thrTex_62, V.Undef, o_1943, P_1941);
Call(thrGlue_66, V.Undef, o_1943, P_1941);
return o_1943;
return default;
}, 1, "build", true)).V);
}, 1, "", true)));
Set(D_1916, "fx", Fn((V _arrowThis1951, int _argc1944, V c_1950, V _a1947, V _a1948, V _a1949, V[] _rest1945) => {
V A_1952 = default;
V G1_1953 = default;
V G2_1954 = default;
A_1952 = Call(padFx_53, V.Undef, c_1950, ((V)((ToNum(Get(D_1916, "w")) * 0.55))), ((V)((ToNum(Get(D_1916, "d")) * 0.42))), ((V)((by_1917 - 8D))), ((V)("th25")), ((V)("#5fe6ff")));
G1_1953 = Call(gyro_63, V.Undef, c_1950, ((V)((ToNum(Get(D_1916, "w")) * 0.62))), ((V)((by_1917 + 22D))), ((V)(0D)), ((V)("#5fe6ff")), ((V)(2.2)), ((V)(0D)), ((V)(4D)));
G2_1954 = Call(gyro_63, V.Undef, c_1950, ((V)((ToNum(Get(D_1916, "w")) * 0.54))), ((V)((by_1917 + 46D))), ((V)((-6D))), ((V)("#d5dde2")), ((V)(3.1)), ((V)(1D)), ((V)((-5D))));
return NewObj(5).Put("defs", Get(A_1952, "defs")).Put("under", Get(A_1952, "svg")).Put("back", Add(Get(G1_1953, "back"), Get(G2_1954, "back"))).Put("front", Add(Get(G1_1953, "front"), Get(G2_1954, "front"))).Put("bb", Call(mergeBB_55, V.Undef, Call(mergeBB_55, V.Undef, Get(A_1952, "bb"), Get(G1_1953, "bb")), Get(G2_1954, "bb"))).V;
return default;
}, 1, "", true));
return D_1916;
return default;
}, 1, "", true));
grain_67 = Fn((V _arrowThis1967, int _argc1955, V D1_1961, V D2_1962, V F_1963, V R_1964, V[] _rest1956) => {
V G_1968 = default;
double best_1969 = 0;
double th_1970 = 0;
V dir_1971 = default;
V m_1972 = default;
V E_1973 = default;
double n_1974 = 0;
V sp_1965 = default;
V KN_1966 = default;
sp_1965 = (_argc1955 > 4 ? _rest1956[0] : V.Undef);
KN_1966 = (_argc1955 > 5 ? _rest1956[1] : V.Undef);
G_1968 = Call(fr2_39, V.Undef, F_1963);
best_1969 = 0D;
th_1970 = 0D;
Invoke(Get(G_1968, "P"), "forEach", Fn((V _arrowThis1983, int _argc1975, V p_1981, V i_1982, V _a1979, V _a1980, V[] _rest1976) => {
V q_1984 = default;
double L_1985 = 0;
q_1984 = GetIdx(Get(G_1968, "P"), (ToNum(Add(i_1982, ((V)(1D)))) % ToNum(Get(Get(G_1968, "P"), "length"))));
L_1985 = Hypot((ToNum(GetIdx(q_1984, 0D)) - ToNum(GetIdx(p_1981, 0D))), (ToNum(GetIdx(q_1984, 1D)) - ToNum(GetIdx(p_1981, 1D))));
if ((L_1985 > best_1969)) {
best_1969 = L_1985;
th_1970 = FdLibm.Atan2((ToNum(GetIdx(q_1984, 1D)) - ToNum(GetIdx(p_1981, 1D))), (ToNum(GetIdx(q_1984, 0D)) - ToNum(GetIdx(p_1981, 0D))));
}
return default;
}, 2, "", true));
dir_1971 = Arr(((V)(FdLibm.Cos(th_1970))), ((V)(FdLibm.Sin(th_1970))));
m_1972 = Arr(((V)((-ToNum(GetIdx(dir_1971, 1D))))), GetIdx(dir_1971, 0D));
E_1973 = Call(ext2_44, V.Undef, Get(G_1968, "P"));
n_1974 = Max(1D, System.Math.Floor(((2D * ToNum(E_1973)) / ToNum(sp_1965))));
Call(rep_29, V.Undef, ((V)(n_1974)), Fn((V _arrowThis1993, int _argc1986, V k_1992, V _a1989, V _a1990, V _a1991, V[] _rest1987) => {
double s_1994 = 0;
double ph_1995 = 0;
double amp_1996 = 0;
s_1994 = (((-ToNum(E_1973)) + (ToNum(Add(k_1992, ((V)(0.5)))) * ToNum(sp_1965))) + (((ToNum(Call(R_1964, V.Undef)) - 0.5) * ToNum(sp_1965)) * 0.5));
ph_1995 = (ToNum(Call(R_1964, V.Undef)) * 6D);
amp_1996 = (0.2 + (ToNum(Call(R_1964, V.Undef)) * 0.5));
Call(wavy_46, V.Undef, (NumTruthy((ToNum(k_1992) % 2D)) ? D2_1962 : D1_1961), F_1963, Fn((V _arrowThis2004, int _argc1997, V t_2003, V _a2000, V _a2001, V _a2002, V[] _rest1998) => {
double u_2005 = 0;
double off_2006 = 0;
u_2005 = ((-ToNum(E_1973)) + ((2D * ToNum(E_1973)) * ToNum(t_2003)));
off_2006 = ((s_1994 + (amp_1996 * FdLibm.Sin(((u_2005 * 0.12) + ph_1995)))) + (0.25 * FdLibm.Sin(((u_2005 * 0.41) + (ph_1995 * 2D)))));
return Arr(((V)(((ToNum(GetIdx(dir_1971, 0D)) * u_2005) + (ToNum(GetIdx(m_1972, 0D)) * off_2006)))), ((V)(((ToNum(GetIdx(dir_1971, 1D)) * u_2005) + (ToNum(GetIdx(m_1972, 1D)) * off_2006)))));
return default;
}, 1, "", true), ((V)(30D)), ((V)((0.28 * (0.7 + (ToNum(Call(R_1964, V.Undef)) * 0.6))))), ((V)(1D)));
return default;
}, 1, "", true));
if (Truthy(((KN_1966 is var _t2007 && !Truthy(_t2007) ? _t2007 : ((best_1969 > 20D) ? V.True : V.False)) is var _t2008 && !Truthy(_t2008) ? _t2008 : (LtN(Call(R_1964, V.Undef), 0.6) ? V.True : V.False)))) {
double u_2009 = 0;
double v_2010 = 0;
V c_2011 = default;
u_2009 = (((ToNum(Call(R_1964, V.Undef)) - 0.5) * best_1969) * 0.6);
v_2010 = ((ToNum(Call(R_1964, V.Undef)) - 0.5) * 2D);
c_2011 = Invoke(G_1968, "at", ((V)(((ToNum(GetIdx(dir_1971, 0D)) * u_2009) + (ToNum(GetIdx(m_1972, 0D)) * v_2010)))), ((V)(((ToNum(GetIdx(dir_1971, 1D)) * u_2009) + (ToNum(GetIdx(m_1972, 1D)) * v_2010)))));
Call(spot_25, V.Undef, KN_1966, c_2011, Get(G_1968, "n"), ((V)(1.3)), ((V)(0.7)), ((V)(th_1970)), ((V)(8D)));
}
return default;
}, 6, "", true);
chesWrap_68 = Fn((V _arrowThis2021, int _argc2012, V S_2018, V lf_2019, V bf_2020, V _a2017, V[] _rest2013) => {
V B_2022 = default;
V D_2023 = default;
B_2022 = Invoke(N_21, "chester", S_2018);
D_2023 = Object_assign(NewObj(0).V, B_2022);
Set(D_2023, "layers", Invoke(Get(B_2022, "layers"), "map", Fn((V _arrowThis2032, int _argc2024, V L_2030, V i_2031, V _a2028, V _a2029, V[] _rest2025) => {
return Object_assign(NewObj(0).V, L_2030, NewObj(1).Put("build", Fn((V _arrowThis2040, int _argc2033, V P_2039, V _a2036, V _a2037, V _a2038, V[] _rest2034) => {
V o_2041 = default;
o_2041 = Invoke(L_2030, "build", P_2039);
Call(lf_2019, V.Undef, o_2041, P_2039, i_2031);
return o_2041;
return default;
}, 1, "build", true)).V);
}, 2, "", true)));
Set(D_2023, "build", Fn((V _arrowThis2049, int _argc2042, V P_2048, V _a2045, V _a2046, V _a2047, V[] _rest2043) => {
V o_2050 = default;
o_2050 = Invoke(B_2022, "build", P_2048);
Call(bf_2020, V.Undef, o_2050, P_2048);
return o_2050;
return default;
}, 1, "", true));
return D_2023;
return default;
}, 3, "", true);
F0of_69 = Fn((V _arrowThis2058, int _argc2051, V P_2057, V _a2054, V _a2055, V _a2056, V[] _rest2052) => {
return ((Get(P_2057, "c") is var _t2059 && !Truthy(_t2059) ? _t2059 : Get(Get(P_2057, "c"), "a")) is var _t2060 && Truthy(_t2060) ? _t2060 : Get(P_2057, "a"));
}, 1, "", true);
leaTex_70 = Fn((V _arrowThis2070, int _argc2061, V o_2067, V P_2068, V li_2069, V _a2066, V[] _rest2062) => {
V on_2071 = default;
V R_2072 = default;
V F0_2073 = default;
V B_2074 = default;
on_2071 = Call(glue_27, V.Undef, o_2067);
R_2072 = Call(R0_28, V.Undef, ((V)(JsStrBuf.Begin().S("le25").V(li_2069).End())));
F0_2073 = Call(F0of_69, V.Undef, P_2068);
B_2074 = Invoke(Invoke(o_2067, "map", Fn((V _arrowThis2090, int _argc2083, V S_2089, V _a2086, V _a2087, V _a2088, V[] _rest2084) => {
return NewObj(2).Put("S", S_2089).Put("L", Call(bbS_38, V.Undef, S_2089)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis2082, int _argc2075, V b_2081, V _a2078, V _a2079, V _a2080, V[] _rest2076) => {
return ((!(Truthy(Get(Get(b_2081, "S"), "par"))) && !(Truthy(Get(Get(b_2081, "S"), "emit")))) ? V.True : V.False);
}, 1, "", true));
Invoke(B_2074, "forEach", Fn((V _arrowThis2101, int _argc2091, V _a2093, V _a2094, V _a2095, V _a2096, V[] _rest2092) => {
double w_2102 = 0;
double h_2103 = 0;
double d_2104 = 0;
V S_2098 = default;
V L_2100 = default;
if (_a2093.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a2093));
{ V _t2097 = Get(_a2093, "S");
S_2098 = _t2097; }
{ V _t2099 = Get(_a2093, "L");
L_2100 = _t2099; }
w_2102 = (ToNum(GetIdx(L_2100, 1D)) - ToNum(GetIdx(L_2100, 0D)));
h_2103 = (ToNum(GetIdx(L_2100, 3D)) - ToNum(GetIdx(L_2100, 2D)));
d_2104 = (ToNum(GetIdx(L_2100, 5D)) - ToNum(GetIdx(L_2100, 4D)));
if (((((SEqN(li_2069, 2D) && ((ToNum(Get(Get(S_2098, "pts"), "length")) % 6D) == 0D)) && (w_2102 > 50D)) && (w_2102 < 60D)) && (d_2104 > 60D))) {
V PA_2105 = default;
V CRD_2106 = default;
V FL_2107 = default;
V WL_2108 = default;
V ST_2109 = default;
PA_2105 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_2098, "col"), ((V)("#ffe2b8")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.28))).V);
CRD_2106 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2098, "col"), ((V)(0.84))), NewObj(1).Put("op", ((V)(0.3))).V);
FL_2107 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2098, "col"), ((V)(0.75))), NewObj(1).Put("op", ((V)(0.35))).V);
WL_2108 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2098, "col"), ((V)(0.55))), NewObj(1).Put("op", ((V)(0.85))).V);
ST_2109 = Call(dec_24, V.Undef, ((V)("#f2e2c0")), NewObj(1).Put("op", ((V)(0.75))).V);
Invoke(Call(caps_50, V.Undef, S_2098, ((V)(2D))), "forEach", Fn((V _arrowThis2117, int _argc2110, V F_2116, V _a2113, V _a2114, V _a2115, V[] _rest2111) => {
V G_2118 = default;
G_2118 = Call(fr2_39, V.Undef, F_2116);
Call(spot_25, V.Undef, PA_2105, Invoke(G_2118, "at", ((V)(0D)), ((V)((-2D)))), Get(G_2118, "n"), ((V)(11D)), ((V)(13D)), ((V)(0.2)), ((V)(14D)));
Call(spot_25, V.Undef, PA_2105, Invoke(G_2118, "at", ((V)(0D)), ((V)((-2D)))), Get(G_2118, "n"), ((V)(6D)), ((V)(8D)), ((V)(0.2)), ((V)(10D)));
Call(rep_29, V.Undef, ((V)(7D)), Fn((V _arrowThis2125, int _argc2119, V _a2121, V _a2122, V _a2123, V _a2124, V[] _rest2120) => {
double a_2126 = 0;
double b_2127 = 0;
double th_2128 = 0;
double l_2129 = 0;
a_2126 = ((ToNum(Call(R_2072, V.Undef)) - 0.5) * 30D);
b_2127 = ((ToNum(Call(R_2072, V.Undef)) - 0.5) * 36D);
th_2128 = (ToNum(Call(R_2072, V.Undef)) * PI_22);
l_2129 = (3D + (ToNum(Call(R_2072, V.Undef)) * 5D));
Call(wavy_46, V.Undef, CRD_2106, F_2116, Fn((V _arrowThis2137, int _argc2130, V t_2136, V _a2133, V _a2134, V _a2135, V[] _rest2131) => {
return Arr(((V)(((a_2126 + ((FdLibm.Cos(th_2128) * l_2129) * (ToNum(t_2136) - 0.5))) + (FdLibm.Sin((ToNum(t_2136) * PI_22)) * 1.2)))), ((V)((b_2127 + ((FdLibm.Sin(th_2128) * l_2129) * (ToNum(t_2136) - 0.5))))));
}, 1, "", true), ((V)(10D)), ((V)(0.7)), ((V)(1D)));
return default;
}, 0, "", true));
Call(dots_48, V.Undef, FL_2107, F_2116, ((V)(2.6)), ((V)(0.22)), NewObj(3).Put("sh", ((V)(0.85))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).V);
return default;
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, S_2098, ((V)(3D))), "forEach", Fn((V _arrowThis2145, int _argc2138, V F_2144, V _a2141, V _a2142, V _a2143, V[] _rest2139) => {
if (GtN(GetIdx(Get(F_2144, "n"), 2D), 0.7)) {
Call(wavy_46, V.Undef, PA_2105, F_2144, Fn((V _arrowThis2154, int _argc2146, V t_2152, V G_2153, V _a2150, V _a2151, V[] _rest2147) => {
V xs_2155 = default;
V ys_2156 = default;
double W_2157 = 0;
double H_2158 = 0;
xs_2155 = Invoke(Get(G_2153, "P"), "map", Fn((V _arrowThis2166, int _argc2159, V q_2165, V _a2162, V _a2163, V _a2164, V[] _rest2160) => {
return GetIdx(q_2165, 0D);
}, 1, "", true));
ys_2156 = Invoke(Get(G_2153, "P"), "map", Fn((V _arrowThis2174, int _argc2167, V q_2173, V _a2170, V _a2171, V _a2172, V[] _rest2168) => {
return GetIdx(q_2173, 1D);
}, 1, "", true));
W_2157 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_2155).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_2155).V)));
H_2158 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_2156).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_2156).V)));
return Arr(((V)((((-W_2157) / 2D) + (W_2157 * ToNum(t_2152))))), ((V)((H_2158 * 0.3))));
return default;
}, 2, "", true), ((V)(16D)), ((V)(2.4)), ((V)(1D)));
}
return default;
}, 1, "", true));
Call(ringL_49, V.Undef, WL_2108, S_2098, ((V)(4D)), ((V)(6D)), ((V)(0.7)), ((V)(0.6)));
{
double n_2175 = 0;
V RG_2176 = default;
V c_2177 = default;
n_2175 = (ToNum(Get(Get(S_2098, "pts"), "length")) / 6D);
RG_2176 = Invoke(Get(S_2098, "pts"), "slice", ((V)((3D * n_2175))), ((V)((4D * n_2175))));
c_2177 = Invoke(RG_2176, "reduce", Fn((V _arrowThis2186, int _argc2178, V a_2184, V p_2185, V _a2182, V _a2183, V[] _rest2179) => {
return Call(add_30, V.Undef, a_2184, Call(mul_32, V.Undef, p_2185, ((V)((1D / ToNum(Get(RG_2176, "length")))))));
}, 2, "", true), Arr(((V)(0D)), ((V)(0D)), ((V)(0D))));
{
double i_2187 = 0;
i_2187 = 0D;
while (true) {
if (!((i_2187 < n_2175))) break;
V p_2189 = default;
V q_2190 = default;
V nn_2191 = default;
p_2189 = GetIdx(RG_2176, i_2187);
q_2190 = GetIdx(RG_2176, ((i_2187 + 1D) % n_2175));
nn_2191 = Call(nz_35, V.Undef, Call(sub_31, V.Undef, p_2189, c_2177));
Invoke(ST_2109, "line", Arr(Call(add_30, V.Undef, p_2189, Call(mul_32, V.Undef, nn_2191, ((V)(0.15)))), Call(add_30, V.Undef, q_2190, Call(mul_32, V.Undef, nn_2191, ((V)(0.15))))), nn_2191, ((V)(0.22)));
i_2187 = (i_2187 + 2D);
}
}
}
Call(on_2071, V.Undef, S_2098, Arr(PA_2105, FL_2107, CRD_2106, WL_2108, ST_2109));
return default;
}
if (((SEqN(li_2069, 2D) && (System.Math.Abs((w_2102 - 24D)) < 3D)) && (System.Math.Abs((h_2103 - 24D)) < 3D))) {
V T1_2192 = default;
V T2_2193 = default;
V T3_2194 = default;
V ED_2195 = default;
Set(S_2098, "col", ((V)("#8e2f2a")));
Set(S_2098, "mat", ((V)("fab")));
T1_2192 = Call(dec_24, V.Undef, ((V)("#2f4a36")), NewObj(1).Put("op", ((V)(0.7))).V);
T2_2193 = Call(dec_24, V.Undef, ((V)("#1d2a22")), NewObj(1).Put("op", ((V)(0.6))).V);
T3_2194 = Call(dec_24, V.Undef, ((V)("#f2c94a")), NewObj(1).Put("op", ((V)(0.7))).V);
ED_2195 = Call(dec_24, V.Undef, ((V)("#5a1c18")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Invoke(Get(S_2098, "faces"), "filter", Fn((V _arrowThis2211, int _argc2204, V F_2210, V _a2207, V _a2208, V _a2209, V[] _rest2205) => {
return ((System.Math.Abs(ToNum(GetIdx(Get(F_2210, "n"), 2D))) > 0.35) ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis2203, int _argc2196, V F_2202, V _a2199, V _a2200, V _a2201, V[] _rest2197) => {
Call(hatch_45, V.Undef, T1_2192, F_2202, ((V)(0D)), ((V)(4.2)), ((V)(1.1)), NewObj(1).Put("sh", ((V)(0.86))).V);
Call(hatch_45, V.Undef, T1_2192, F_2202, ((V)((PI_22 / 2D))), ((V)(4.2)), ((V)(1.1)), NewObj(1).Put("sh", ((V)(0.86))).V);
Call(hatch_45, V.Undef, T2_2193, F_2202, ((V)(0D)), ((V)(4.2)), ((V)(0.45)), NewObj(2).Put("sh", ((V)(0.86))).Put("ph", ((V)(2.1))).V);
Call(hatch_45, V.Undef, T2_2193, F_2202, ((V)((PI_22 / 2D))), ((V)(4.2)), ((V)(0.45)), NewObj(2).Put("sh", ((V)(0.86))).Put("ph", ((V)(2.1))).V);
Call(hatch_45, V.Undef, T3_2194, F_2202, ((V)(0D)), ((V)(8.4)), ((V)(0.18)), NewObj(2).Put("sh", ((V)(0.86))).Put("ph", ((V)(1D))).V);
Call(hatch_45, V.Undef, T3_2194, F_2202, ((V)((PI_22 / 2D))), ((V)(8.4)), ((V)(0.18)), NewObj(2).Put("sh", ((V)(0.86))).Put("ph", ((V)(1D))).V);
if (Truthy(Get(F_2202, "cap"))) {
Call(outline_47, V.Undef, ED_2195, F_2202, ((V)(0.92)), ((V)(0.4)));
}
return default;
}, 1, "", true));
Call(on_2071, V.Undef, S_2098, Arr(T1_2192, T2_2193, T3_2194, ED_2195));
return default;
}
if (SEq(Get(S_2098, "col"), F0_2073)) {
V PA_2212 = default;
V FL_2213 = default;
double any_2214 = 0;
PA_2212 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_2098, "col"), ((V)("#ffe2b8")), ((V)(0.32))), NewObj(1).Put("op", ((V)(0.3))).V);
FL_2213 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2098, "col"), ((V)(0.72))), NewObj(1).Put("op", ((V)(0.3))).V);
any_2214 = 0D;
Invoke(Call(sides_51, V.Undef, S_2098, ((V)(5D))), "forEach", Fn((V _arrowThis2222, int _argc2215, V F_2221, V _a2218, V _a2219, V _a2220, V[] _rest2216) => {
if ((GtN(GetIdx(Get(F_2221, "n"), 1D), 0.55) && GtN(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(F_2221, "q"), 3D), GetIdx(Get(F_2221, "q"), 0D))).V), 30D))) {
Call(wavy_46, V.Undef, PA_2212, F_2221, Fn((V _arrowThis2231, int _argc2223, V t_2229, V G_2230, V _a2227, V _a2228, V[] _rest2224) => {
V ys_2232 = default;
V xs_2233 = default;
double H_2234 = 0;
double W_2235 = 0;
ys_2232 = Invoke(Get(G_2230, "P"), "map", Fn((V _arrowThis2243, int _argc2236, V q_2242, V _a2239, V _a2240, V _a2241, V[] _rest2237) => {
return GetIdx(q_2242, 1D);
}, 1, "", true));
xs_2233 = Invoke(Get(G_2230, "P"), "map", Fn((V _arrowThis2251, int _argc2244, V q_2250, V _a2247, V _a2248, V _a2249, V[] _rest2245) => {
return GetIdx(q_2250, 0D);
}, 1, "", true));
H_2234 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_2232).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_2232).V)));
W_2235 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_2233).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_2233).V)));
return ((W_2235 > H_2234) ? Arr(((V)((((-W_2235) / 2D) + (W_2235 * ToNum(t_2229))))), ((V)(((FdLibm.Sin((ToNum(t_2229) * 9D)) * H_2234) * 0.12)))) : Arr(((V)(((FdLibm.Sin((ToNum(t_2229) * 9D)) * W_2235) * 0.12))), ((V)((((-H_2234) / 2D) + (H_2234 * ToNum(t_2229)))))));
return default;
}, 2, "", true), ((V)(20D)), ((V)(2.6)), ((V)(1D)));
any_2214 = 1D;
}
return default;
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, S_2098, ((V)(8D))), "forEach", Fn((V _arrowThis2259, int _argc2252, V F_2258, V _a2255, V _a2256, V _a2257, V[] _rest2253) => {
if (((System.Math.Abs(ToNum(GetIdx(Get(F_2258, "n"), 1D))) < 0.5) && GtN(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(F_2258, "q"), 1D), GetIdx(Get(F_2258, "q"), 0D))).V), 10D))) {
Call(dots_48, V.Undef, FL_2213, F_2258, ((V)(3.4)), ((V)(0.24)), NewObj(3).Put("sh", ((V)(0.9))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).V);
any_2214 = 1D;
}
return default;
}, 1, "", true));
if (NumTruthy(any_2214)) {
Call(on_2071, V.Undef, S_2098, Arr(PA_2212, FL_2213));
}
}
return default;
}, 1, "", true));
return default;
}, 3, "", true);
leaBase_71 = Fn((V _arrowThis2268, int _argc2260, V o_2266, V P_2267, V _a2264, V _a2265, V[] _rest2261) => {
V on_2269 = default;
V R_2270 = default;
V B_2271 = default;
on_2269 = Call(glue_27, V.Undef, o_2266);
R_2270 = Call(R0_28, V.Undef, ((V)("lb25")));
B_2271 = Invoke(Invoke(o_2266, "map", Fn((V _arrowThis2287, int _argc2280, V S_2286, V _a2283, V _a2284, V _a2285, V[] _rest2281) => {
return NewObj(2).Put("S", S_2286).Put("L", Call(bbS_38, V.Undef, S_2286)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis2279, int _argc2272, V b_2278, V _a2275, V _a2276, V _a2277, V[] _rest2273) => {
return (!(Truthy(Get(Get(b_2278, "S"), "par"))) ? V.True : V.False);
}, 1, "", true));
Invoke(B_2271, "forEach", Fn((V _arrowThis2298, int _argc2288, V _a2290, V _a2291, V _a2292, V _a2293, V[] _rest2289) => {
V S_2295 = default;
V L_2297 = default;
if (_a2290.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a2290));
{ V _t2294 = Get(_a2290, "S");
S_2295 = _t2294; }
{ V _t2296 = Get(_a2290, "L");
L_2297 = _t2296; }
if (((LtN(GetIdx(L_2297, 3D), 9D) && ((ToNum(GetIdx(L_2297, 1D)) - ToNum(GetIdx(L_2297, 0D))) < 10D)) && GtN(Get(Get(S_2295, "pts"), "length"), 20D))) {
double cx_2299 = 0;
double cz_2300 = 0;
V RN_2301 = default;
V HL_2302 = default;
double yc_2303 = 0;
double r_2304 = 0;
cx_2299 = (ToNum(Add(GetIdx(L_2297, 0D), GetIdx(L_2297, 1D))) / 2D);
cz_2300 = (ToNum(Add(GetIdx(L_2297, 4D), GetIdx(L_2297, 5D))) / 2D);
RN_2301 = Call(dec_24, V.Undef, ((V)("#1f140b")), NewObj(1).Put("op", ((V)(0.6))).V);
HL_2302 = Call(dec_24, V.Undef, ((V)("#c48a5a")), NewObj(1).Put("op", ((V)(0.5))).V);
yc_2303 = (ToNum(Add(GetIdx(L_2297, 2D), GetIdx(L_2297, 3D))) / 2D);
r_2304 = ((ToNum(GetIdx(L_2297, 1D)) - ToNum(GetIdx(L_2297, 0D))) / 2D);
if ((r_2304 > 3D)) {
Invoke(Arr(Arr(((V)(yc_2303)), ((V)((r_2304 + 0.04))), RN_2301, ((V)(0.45))), Arr(((V)((yc_2303 + (r_2304 * 0.5)))), ((V)((r_2304 * 0.88))), HL_2302, ((V)(0.3)))), "forEach", Fn((V _arrowThis2320, int _argc2305, V _a2307, V _a2308, V _a2309, V _a2310, V[] _rest2306) => {
V y_2313 = default;
V rr_2315 = default;
V Dd_2317 = default;
V w_2319 = default;
{ V _t2311 = ListOf(_a2307);
{ V _t2312 = GetIdx(_t2311, 0D);
y_2313 = _t2312; }
{ V _t2314 = GetIdx(_t2311, 1D);
rr_2315 = _t2314; }
{ V _t2316 = GetIdx(_t2311, 2D);
Dd_2317 = _t2316; }
{ V _t2318 = GetIdx(_t2311, 3D);
w_2319 = _t2318; }
}
return Invoke(Dd_2317, "line", Call(rep_29, V.Undef, ((V)(29D)), Fn((V _arrowThis2328, int _argc2321, V i_2327, V _a2324, V _a2325, V _a2326, V[] _rest2322) => {
double a_2329 = 0;
a_2329 = (((ToNum(i_2327) / 28D) * 2D) * PI_22);
return Arr(((V)((cx_2299 + (FdLibm.Cos(a_2329) * ToNum(rr_2315))))), y_2313, ((V)((cz_2300 + (FdLibm.Sin(a_2329) * ToNum(rr_2315))))));
return default;
}, 1, "", true)), Call(rep_29, V.Undef, ((V)(29D)), Fn((V _arrowThis2337, int _argc2330, V i_2336, V _a2333, V _a2334, V _a2335, V[] _rest2331) => {
double a_2338 = 0;
a_2338 = (((ToNum(i_2336) / 28D) * 2D) * PI_22);
return Arr(((V)(FdLibm.Cos(a_2338))), ((V)(0D)), ((V)(FdLibm.Sin(a_2338))));
return default;
}, 1, "", true)), w_2319);
}, 1, "", true));
Call(on_2269, V.Undef, S_2295, Arr(RN_2301, HL_2302));
}
}
return default;
}, 1, "", true));
return default;
}, 2, "", true);
Set(N_21, "chester25L", Fn((V _arrowThis2346, int _argc2339, V S_2345, V _a2342, V _a2343, V _a2344, V[] _rest2340) => {
return Call(chesWrap_68, V.Undef, S_2345, leaTex_70, leaBase_71);
}, 1, "", true));
bouTex_72 = Fn((V _arrowThis2356, int _argc2347, V o_2353, V P_2354, V li_2355, V _a2352, V[] _rest2348) => {
V on_2357 = default;
V R_2358 = default;
V F0_2359 = default;
V B_2360 = default;
V loops_2361 = default;
on_2357 = Call(glue_27, V.Undef, o_2353);
R_2358 = Call(R0_28, V.Undef, ((V)(JsStrBuf.Begin().S("bo25").V(li_2355).End())));
F0_2359 = Call(F0of_69, V.Undef, P_2354);
B_2360 = Invoke(Invoke(o_2353, "map", Fn((V _arrowThis2377, int _argc2370, V S_2376, V _a2373, V _a2374, V _a2375, V[] _rest2371) => {
return NewObj(2).Put("S", S_2376).Put("L", Call(bbS_38, V.Undef, S_2376)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis2369, int _argc2362, V b_2368, V _a2365, V _a2366, V _a2367, V[] _rest2363) => {
return ((!(Truthy(Get(Get(b_2368, "S"), "par"))) && !(Truthy(Get(Get(b_2368, "S"), "emit")))) ? V.True : V.False);
}, 1, "", true));
loops_2361 = Fn((V _arrowThis2387, int _argc2378, V S_2384, V F_2385, V sp_2386, V _a2383, V[] _rest2379) => {
V D1_2388 = default;
V D2_2389 = default;
V G_2390 = default;
D1_2388 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_2384, "col"), ((V)("#ffffff")), ((V)(0.55))), NewObj(1).Put("op", ((V)(0.55))).V);
D2_2389 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2384, "col"), ((V)(0.86))), NewObj(1).Put("op", ((V)(0.45))).V);
Call(dots_48, V.Undef, D1_2388, F_2385, sp_2386, ((V)(0.55)), NewObj(3).Put("sh", ((V)(0.92))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).V);
G_2390 = Call(fr2_39, V.Undef, F_2385);
Call(rep_29, V.Undef, ((V)(Round((System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(G_2390, "P")))) / ((ToNum(sp_2386) * ToNum(sp_2386)) * 2.2))))), Fn((V _arrowThis2397, int _argc2391, V _a2393, V _a2394, V _a2395, V _a2396, V[] _rest2392) => {
V P2_2398 = default;
V E_2399 = default;
V q_2400 = default;
P2_2398 = Call(shrinkP_41, V.Undef, Get(G_2390, "P"), ((V)(0.9)));
E_2399 = Call(ext2_44, V.Undef, P2_2398);
q_2400 = Arr(((V)((((ToNum(Call(R_2358, V.Undef)) - 0.5) * 2D) * ToNum(E_2399)))), ((V)((((ToNum(Call(R_2358, V.Undef)) - 0.5) * 2D) * ToNum(E_2399)))));
if (Truthy(Call(inP_43, V.Undef, P2_2398, q_2400))) {
Call(spot_25, V.Undef, D2_2389, Invoke(G_2390, "at", GetIdx(q_2400, 0D), GetIdx(q_2400, 1D)), Get(G_2390, "n"), ((V)(0.45)), ((V)(0.45)), ((V)(0D)), ((V)(5D)));
}
return default;
}, 0, "", true));
return Arr(D1_2388, D2_2389);
return default;
}, 3, "", true);
Invoke(B_2360, "forEach", Fn((V _arrowThis2411, int _argc2401, V _a2403, V _a2404, V _a2405, V _a2406, V[] _rest2402) => {
double w_2412 = 0;
double h_2413 = 0;
double d_2414 = 0;
V S_2408 = default;
V L_2410 = default;
if (_a2403.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a2403));
{ V _t2407 = Get(_a2403, "S");
S_2408 = _t2407; }
{ V _t2409 = Get(_a2403, "L");
L_2410 = _t2409; }
w_2412 = (ToNum(GetIdx(L_2410, 1D)) - ToNum(GetIdx(L_2410, 0D)));
h_2413 = (ToNum(GetIdx(L_2410, 3D)) - ToNum(GetIdx(L_2410, 2D)));
d_2414 = (ToNum(GetIdx(L_2410, 5D)) - ToNum(GetIdx(L_2410, 4D)));
if (((((SEqN(li_2355, 2D) && ((ToNum(Get(Get(S_2408, "pts"), "length")) % 6D) == 0D)) && (w_2412 > 50D)) && (w_2412 < 60D)) && (d_2414 > 60D))) {
V Ls_2415 = default;
V WL_2416 = default;
Ls_2415 = Arr();
Invoke(Call(caps_50, V.Undef, S_2408, ((V)(2D))), "forEach", Fn((V _arrowThis2424, int _argc2417, V F_2423, V _a2420, V _a2421, V _a2422, V[] _rest2418) => {
return InvokeSpread(Ls_2415, "push", new ArrBuilder().Spread(Call(loops_2361, V.Undef, S_2408, F_2423, ((V)(2.6)))).V);
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, S_2408, ((V)(3D))), "forEach", Fn((V _arrowThis2432, int _argc2425, V F_2431, V _a2428, V _a2429, V _a2430, V[] _rest2426) => {
if ((GtN(GetIdx(Get(F_2431, "n"), 2D), 0.7) && GtN(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(F_2431, "q"), 1D), GetIdx(Get(F_2431, "q"), 0D))).V), 10D))) {
InvokeSpread(Ls_2415, "push", new ArrBuilder().Spread(Call(loops_2361, V.Undef, S_2408, F_2431, ((V)(2.6)))).V);
}
return default;
}, 1, "", true));
WL_2416 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2408, "col"), ((V)(0.8))), NewObj(1).Put("op", ((V)(0.6))).V);
Call(ringL_49, V.Undef, WL_2416, S_2408, ((V)(4D)), ((V)(6D)), ((V)(0.6)), ((V)(0.6)));
Call(on_2357, V.Undef, S_2408, Invoke(Ls_2415, "concat", Arr(WL_2416)));
return default;
}
if (((SEqN(li_2355, 2D) && (System.Math.Abs((w_2412 - 24D)) < 3D)) && (System.Math.Abs((h_2413 - 24D)) < 3D))) {
V D1_2433 = default;
V D2_2434 = default;
V PG_2435 = default;
{ V _t2436 = Arr(Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_2408, "col"), ((V)("#ffffff")), ((V)(0.25))), NewObj(1).Put("op", ((V)(0.3))).V), Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2408, "col"), ((V)(0.82))), NewObj(1).Put("op", ((V)(0.25))).V));
{ V _t2437 = ListOf(_t2436);
{ V _t2438 = GetIdx(_t2437, 0D);
D1_2433 = _t2438; }
{ V _t2439 = GetIdx(_t2437, 1D);
D2_2434 = _t2439; }
} }
PG_2435 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2408, "col"), ((V)(0.7))), NewObj(1).Put("op", ((V)(0.8))).V);
Invoke(Call(caps_50, V.Undef, S_2408, ((V)(2D))), "forEach", Fn((V _arrowThis2447, int _argc2440, V F_2446, V _a2443, V _a2444, V _a2445, V[] _rest2441) => {
Call(velvet_58, V.Undef, D1_2433, D2_2434, F_2446, R_2358, ((V)(3D)));
Call(outline_47, V.Undef, PG_2435, F_2446, ((V)(0.94)), ((V)(0.55)));
return default;
}, 1, "", true));
Call(on_2357, V.Undef, S_2408, Arr(D1_2433, D2_2434, PG_2435));
return default;
}
if (SEq(Get(S_2408, "col"), F0_2359)) {
V Ls_2448 = default;
Ls_2448 = Arr();
Invoke(Get(S_2408, "faces"), "forEach", Fn((V _arrowThis2456, int _argc2449, V F_2455, V _a2452, V _a2453, V _a2454, V[] _rest2450) => {
V G_2457 = default;
G_2457 = Call(fr2_39, V.Undef, F_2455);
if ((System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(G_2457, "P")))) < 60D)) {
return default;
}
if ((GtN(GetIdx(Get(F_2455, "n"), 1D), 0.4) || ((System.Math.Abs(ToNum(GetIdx(Get(F_2455, "n"), 1D))) < 0.5) && (SEqN(li_2355, 1D) || SEqN(li_2355, 3D))))) {
InvokeSpread(Ls_2448, "push", new ArrBuilder().Spread(Call(loops_2361, V.Undef, S_2408, F_2455, ((V)(3D)))).V);
}
return default;
}, 1, "", true));
if (Truthy(Get(Ls_2448, "length"))) {
Call(on_2357, V.Undef, S_2408, Ls_2448);
}
}
return default;
}, 1, "", true));
return default;
}, 3, "", true);
bouBase_73 = Fn((V _arrowThis2466, int _argc2458, V o_2464, V P_2465, V _a2462, V _a2463, V[] _rest2459) => {
V on_2467 = default;
V R_2468 = default;
V B_2469 = default;
V pl_2470 = default;
V br_2471 = default;
on_2467 = Call(glue_27, V.Undef, o_2464);
R_2468 = Call(R0_28, V.Undef, ((V)("bb25")));
B_2469 = Invoke(Invoke(o_2464, "map", Fn((V _arrowThis2487, int _argc2480, V S_2486, V _a2483, V _a2484, V _a2485, V[] _rest2481) => {
return NewObj(2).Put("S", S_2486).Put("L", Call(bbS_38, V.Undef, S_2486)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis2479, int _argc2472, V b_2478, V _a2475, V _a2476, V _a2477, V[] _rest2473) => {
return (!(Truthy(Get(Get(b_2478, "S"), "par"))) ? V.True : V.False);
}, 1, "", true));
pl_2470 = Invoke(B_2469, "find", Fn((V _arrowThis2495, int _argc2488, V b_2494, V _a2491, V _a2492, V _a2493, V[] _rest2489) => {
return (((LtN(GetIdx(Get(b_2494, "L"), 2D), 0.5) && ((ToNum(GetIdx(Get(b_2494, "L"), 1D)) - ToNum(GetIdx(Get(b_2494, "L"), 0D))) > 150D)) && LtN(GetIdx(Get(b_2494, "L"), 3D), 12D)) ? V.True : V.False);
}, 1, "", true));
br_2471 = Invoke(B_2469, "find", Fn((V _arrowThis2503, int _argc2496, V b_2502, V _a2499, V _a2500, V _a2501, V[] _rest2497) => {
return ((SEq(Get(Get(b_2502, "S"), "col"), GOLD_23) && ((ToNum(GetIdx(Get(b_2502, "L"), 1D)) - ToNum(GetIdx(Get(b_2502, "L"), 0D))) > 150D)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(pl_2470)) {
V VG_2504 = default;
V VL_2505 = default;
V VY_2506 = default;
VG_2504 = Call(dec_24, V.Undef, ((V)("#9a958e")), NewObj(1).Put("op", ((V)(0.42))).V);
VL_2505 = Call(dec_24, V.Undef, ((V)("#b8b2aa")), NewObj(1).Put("op", ((V)(0.3))).V);
VY_2506 = Call(dec_24, V.Undef, ((V)("#c9a35a")), NewObj(1).Put("op", ((V)(0.55))).V);
Invoke(Get(Get(pl_2470, "S"), "faces"), "forEach", Fn((V _arrowThis2514, int _argc2507, V F_2513, V _a2510, V _a2511, V _a2512, V[] _rest2508) => {
V G_2515 = default;
V E_2516 = default;
V up_2517 = default;
if (LtN(GetIdx(Get(F_2513, "n"), 1D), (-0.5))) {
return default;
}
G_2515 = Call(fr2_39, V.Undef, F_2513);
if ((System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(G_2515, "P")))) < 20D)) {
return default;
}
E_2516 = Call(ext2_44, V.Undef, Get(G_2515, "P"));
up_2517 = (GtN(GetIdx(Get(F_2513, "n"), 1D), 0.5) ? V.True : V.False);
Call(rep_29, V.Undef, ((V)((Truthy(up_2517) ? 3D : Max(2D, Round((ToNum(E_2516) / 22D)))))), Fn((V _arrowThis2525, int _argc2518, V k_2524, V _a2521, V _a2522, V _a2523, V[] _rest2519) => {
double ph_2526 = 0;
double s_2527 = 0;
double th_2528 = 0;
V Dd_2529 = default;
ph_2526 = (ToNum(Call(R_2468, V.Undef)) * 6D);
s_2527 = ((ToNum(Call(R_2468, V.Undef)) - 0.5) * (Truthy(up_2517) ? (1.6 * ToNum(E_2516)) : 6D));
th_2528 = ((ToNum(Call(R_2468, V.Undef)) - 0.5) * 0.9);
Dd_2529 = (((ToNum(k_2524) % 3D) == 2D) ? VY_2506 : (NumTruthy((ToNum(k_2524) % 2D)) ? VL_2505 : VG_2504));
Call(wavy_46, V.Undef, Dd_2529, F_2513, Fn((V _arrowThis2537, int _argc2530, V t_2536, V _a2533, V _a2534, V _a2535, V[] _rest2531) => {
double u_2538 = 0;
u_2538 = ((-ToNum(E_2516)) + ((2D * ToNum(E_2516)) * ToNum(t_2536)));
return Arr(((V)(((u_2538 * FdLibm.Cos(th_2528)) - ((s_2527 + (FdLibm.Sin(((u_2538 * 0.15) + ph_2526)) * 1.6)) * FdLibm.Sin(th_2528))))), ((V)(((u_2538 * FdLibm.Sin(th_2528)) + ((s_2527 + (FdLibm.Sin(((u_2538 * 0.15) + ph_2526)) * 1.6)) * FdLibm.Cos(th_2528))))));
return default;
}, 1, "", true), ((V)(36D)), ((V)((SEq(Dd_2529, VY_2506) ? 0.45 : (0.35 + (ToNum(Call(R_2468, V.Undef)) * 0.3))))), ((V)(1D)));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Call(on_2467, V.Undef, Get(pl_2470, "S"), Arr(VL_2505, VG_2504, VY_2506));
}
if (Truthy(br_2471)) {
V BL_2539 = default;
V BD_2540 = default;
BL_2539 = Call(dec_24, V.Undef, ((V)("#fff1c0")), NewObj(1).Put("op", ((V)(0.3))).V);
BD_2540 = Call(dec_24, V.Undef, ((V)("#9a7424")), NewObj(1).Put("op", ((V)(0.25))).V);
Invoke(Call(sides_51, V.Undef, Get(br_2471, "S"), ((V)(1D))), "forEach", Fn((V _arrowThis2548, int _argc2541, V F_2547, V _a2544, V _a2545, V _a2546, V[] _rest2542) => {
if ((System.Math.Abs(ToNum(GetIdx(Get(F_2547, "n"), 1D))) < 0.5)) {
Call(hatch_45, V.Undef, Arr(BL_2539, BD_2540), F_2547, ((V)(0D)), ((V)(0.7)), ((V)(0.16)), NewObj(1).Put("sh", ((V)(0.98))).V);
}
return default;
}, 1, "", true));
Call(on_2467, V.Undef, Get(br_2471, "S"), Arr(BL_2539, BD_2540));
}
return default;
}, 2, "", true);
Set(N_21, "chester25B", Fn((V _arrowThis2556, int _argc2549, V S_2555, V _a2552, V _a2553, V _a2554, V[] _rest2550) => {
return Call(chesWrap_68, V.Undef, S_2555, bouTex_72, bouBase_73);
}, 1, "", true));
shearTex_74 = Fn((V _arrowThis2566, int _argc2557, V o_2563, V P_2564, V li_2565, V _a2562, V[] _rest2558) => {
V on_2567 = default;
V R_2568 = default;
V WAL_2569 = default;
V SHE_2570 = default;
V B_2571 = default;
on_2567 = Call(glue_27, V.Undef, o_2563);
R_2568 = Call(R0_28, V.Undef, ((V)(JsStrBuf.Begin().S("sh25").V(li_2565).End())));
WAL_2569 = ((V)("#5b3820"));
SHE_2570 = ((V)("#efe6d6"));
B_2571 = Invoke(Invoke(o_2563, "map", Fn((V _arrowThis2587, int _argc2580, V S_2586, V _a2583, V _a2584, V _a2585, V[] _rest2581) => {
return NewObj(2).Put("S", S_2586).Put("L", Call(bbS_38, V.Undef, S_2586)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis2579, int _argc2572, V b_2578, V _a2575, V _a2576, V _a2577, V[] _rest2573) => {
return (!(Truthy(Get(Get(b_2578, "S"), "par"))) ? V.True : V.False);
}, 1, "", true));
Invoke(B_2571, "forEach", Fn((V _arrowThis2598, int _argc2588, V _a2590, V _a2591, V _a2592, V _a2593, V[] _rest2589) => {
V wood_2599 = default;
V S_2595 = default;
V L_2597 = default;
if (_a2590.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a2590));
{ V _t2594 = Get(_a2590, "S");
S_2595 = _t2594; }
{ V _t2596 = Get(_a2590, "L");
L_2597 = _t2596; }
wood_2599 = ((SEq(Get(S_2595, "col"), WAL_2569) || SEq(Get(S_2595, "col"), Call(shade_18, V.Undef, WAL_2569, ((V)(1.08))))) ? V.True : V.False);
if (Truthy(wood_2599)) {
V G1_2600 = default;
V G2_2601 = default;
V KN_2602 = default;
V ER_2603 = default;
G1_2600 = Call(dec_24, V.Undef, ((V)("#3a2312")), NewObj(1).Put("op", ((V)(0.5))).V);
G2_2601 = Call(dec_24, V.Undef, ((V)("#8a5a36")), NewObj(1).Put("op", ((V)(0.4))).V);
KN_2602 = Call(dec_24, V.Undef, ((V)("#2a180c")), NewObj(1).Put("op", ((V)(0.7))).V);
ER_2603 = Call(dec_24, V.Undef, ((V)("#3a2312")), NewObj(1).Put("op", ((V)(0.45))).V);
Invoke(Get(S_2595, "faces"), "forEach", Fn((V _arrowThis2611, int _argc2604, V F_2610, V _a2607, V _a2608, V _a2609, V[] _rest2605) => {
V G_2612 = default;
double A_2613 = 0;
G_2612 = Call(fr2_39, V.Undef, F_2610);
A_2613 = System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(G_2612, "P"))));
if ((A_2613 < 6D)) {
return default;
}
if (Truthy(Get(F_2610, "cap"))) {
if ((System.Math.Abs(ToNum(GetIdx(Get(F_2610, "n"), 0D))) > 0.9)) {
Call(grain_67, V.Undef, G1_2600, G2_2601, F_2610, R_2568, ((V)(1.4)), KN_2602);
}
} else {
V E_2614 = default;
V V_2615 = default;
double m_2616 = 0;
E_2614 = InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(F_2610, "q"), 1D), GetIdx(Get(F_2610, "q"), 0D))).V);
V_2615 = InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(F_2610, "q"), 3D), GetIdx(Get(F_2610, "q"), 0D))).V);
m_2616 = Max(1D, Round((ToNum(V_2615) / 1.3)));
if (GtN(E_2614, 6D)) {
Call(rep_29, V.Undef, ((V)(m_2616)), Fn((V _arrowThis2624, int _argc2617, V k_2623, V _a2620, V _a2621, V _a2622, V[] _rest2618) => {
double f_2625 = 0;
f_2625 = ((ToNum(Add(k_2623, ((V)(0.5)))) / m_2616) + ((ToNum(Call(R_2568, V.Undef)) - 0.5) * 0.15));
Invoke(ER_2603, "line", Arr(Call(add_30, V.Undef, GetIdx(Get(F_2610, "q"), 0D), Call(mul_32, V.Undef, Call(sub_31, V.Undef, GetIdx(Get(F_2610, "q"), 3D), GetIdx(Get(F_2610, "q"), 0D)), ((V)(f_2625)))), Call(add_30, V.Undef, GetIdx(Get(F_2610, "q"), 1D), Call(mul_32, V.Undef, Call(sub_31, V.Undef, GetIdx(Get(F_2610, "q"), 2D), GetIdx(Get(F_2610, "q"), 1D)), ((V)(f_2625))))), Get(F_2610, "n"), ((V)(0.18)));
return default;
}, 1, "", true));
}
}
return default;
}, 1, "", true));
Call(on_2567, V.Undef, S_2595, Arr(G1_2600, G2_2601, KN_2602, ER_2603));
return default;
}
if (((SEq(Get(S_2595, "col"), SHE_2570) || SEq(Get(S_2595, "col"), Call(mix_19, V.Undef, SHE_2570, ((V)("#ffffff")), ((V)(0.15))))) || SEq(Get(S_2595, "col"), Call(mix_19, V.Undef, SHE_2570, ((V)("#ffffff")), ((V)(0.12)))))) {
V T1_2626 = default;
V T2_2627 = default;
V Ls_2628 = default;
T1_2626 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.55))).V);
T2_2627 = Call(dec_24, V.Undef, ((V)("#cbbfa8")), NewObj(1).Put("op", ((V)(0.4))).V);
Ls_2628 = Arr(T1_2626, T2_2627);
Invoke(Get(S_2595, "faces"), "forEach", Fn((V _arrowThis2636, int _argc2629, V F_2635, V _a2632, V _a2633, V _a2634, V[] _rest2630) => {
V G_2637 = default;
double A_2638 = 0;
if (Truthy(Get(F_2635, "cap"))) {
return default;
}
G_2637 = Call(fr2_39, V.Undef, F_2635);
A_2638 = System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(G_2637, "P"))));
if ((A_2638 < 40D)) {
return default;
}
Call(dots_48, V.Undef, T1_2626, F_2635, ((V)(3D)), ((V)(0.8)), NewObj(3).Put("sh", ((V)(0.94))).Put("stag", ((V)(1D))).Put("m", ((V)(6D))).V);
Call(dots_48, V.Undef, T2_2627, F_2635, ((V)(3D)), ((V)(0.45)), NewObj(4).Put("sh", ((V)(0.94))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).Put("off", Arr(((V)(1.5)), ((V)(1.2)))).V);
Call(wavy_46, V.Undef, T2_2627, F_2635, Fn((V _arrowThis2647, int _argc2639, V t_2645, V G2_2646, V _a2643, V _a2644, V[] _rest2640) => {
V E_2648 = default;
E_2648 = Call(ext2_44, V.Undef, Get(G2_2646, "P"));
return Arr(((V)(((-ToNum(E_2648)) + ((2D * ToNum(E_2648)) * ToNum(t_2645))))), ((V)(((FdLibm.Sin((ToNum(t_2645) * 40D)) * 0.7) + ((ToNum(Call(R_2568, V.Undef)) - 0.5) * 4D)))));
return default;
}, 2, "", true), ((V)(40D)), ((V)(0.3)));
return default;
}, 1, "", true));
if ((GtN(GetIdx(L_2597, 3D), 40D) && ((ToNum(GetIdx(L_2597, 1D)) - ToNum(GetIdx(L_2597, 0D))) > 55D))) {
V LS_2649 = default;
V LH_2650 = default;
V BK_2651 = default;
LS_2649 = Call(dec_24, V.Undef, ((V)("#8a4a22")));
LH_2650 = Call(dec_24, V.Undef, ((V)("#c27a45")), NewObj(1).Put("op", ((V)(0.6))).V);
BK_2651 = Call(dec_24, V.Undef, ((V)("#e2b14a")), NewObj(1).Put("shine", ((V)(1D))).V);
Invoke(Arr(((V)((-17D))), ((V)(17D))), "forEach", Fn((V _arrowThis2659, int _argc2652, V xc_2658, V _a2655, V _a2656, V _a2657, V[] _rest2653) => {
double x0_2660 = 0;
V x1_2661 = default;
V fc_2662 = default;
x0_2660 = (ToNum(xc_2658) - 2.6);
x1_2661 = Add(xc_2658, ((V)(2.6)));
Invoke(Get(S_2595, "faces"), "forEach", Fn((V _arrowThis2670, int _argc2663, V F_2669, V _a2666, V _a2667, V _a2668, V[] _rest2664) => {
V xs_2671 = default;
V q_2672 = default;
if (Truthy(Get(F_2669, "cap"))) {
return default;
}
xs_2671 = Invoke(Get(F_2669, "q"), "map", Fn((V _arrowThis2680, int _argc2673, V q_2679, V _a2676, V _a2677, V _a2678, V[] _rest2674) => {
return GetIdx(q_2679, 0D);
}, 1, "", true));
if ((Lt(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_2671).V), x1_2661) || GtN(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_2671).V), x0_2660))) {
return default;
}
q_2672 = Invoke(Get(F_2669, "q"), "map", Fn((V _arrowThis2688, int _argc2681, V p_2687, V _a2684, V _a2685, V _a2686, V[] _rest2682) => {
return Arr(((V)(Max(x0_2660, Min(ToNum(x1_2661), ToNum(GetIdx(p_2687, 0D)))))), GetIdx(p_2687, 1D), GetIdx(p_2687, 2D));
}, 1, "", true));
Invoke(LS_2649, "poly", q_2672, Get(F_2669, "n"));
Invoke(LH_2650, "line", Invoke(Arr(GetIdx(q_2672, 0D), GetIdx(q_2672, 1D)), "map", Fn((V _arrowThis2696, int _argc2689, V p_2695, V _a2692, V _a2693, V _a2694, V[] _rest2690) => {
return Arr(((V)((x0_2660 + 0.6))), GetIdx(p_2695, 1D), GetIdx(p_2695, 2D));
}, 1, "", true)), Get(F_2669, "n"), ((V)(0.25)));
return default;
}, 1, "", true));
fc_2662 = GetIdx(Invoke(Invoke(Get(S_2595, "faces"), "filter", Fn((V _arrowThis2713, int _argc2706, V F_2712, V _a2709, V _a2710, V _a2711, V[] _rest2707) => {
return (((!(Truthy(Get(F_2712, "cap"))) && (System.Math.Abs(ToNum(GetIdx(Get(F_2712, "n"), 0D))) < 0.01)) && GtN(GetIdx(Get(F_2712, "n"), 2D), 0.5)) ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _arrowThis2705, int _argc2697, V a_2703, V b_2704, V _a2701, V _a2702, V[] _rest2698) => {
return ((V)((ToNum(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(b_2704, "q"), 1D), GetIdx(Get(b_2704, "q"), 0D))).V)) - ToNum(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(a_2703, "q"), 1D), GetIdx(Get(a_2703, "q"), 0D))).V)))));
}, 2, "", true)), 0D);
if (Truthy(fc_2662)) {
V m0_2714 = default;
V v_2715 = default;
V c_2716 = default;
V u_2717 = default;
m0_2714 = Call(add_30, V.Undef, GetIdx(Get(fc_2662, "q"), 0D), Call(mul_32, V.Undef, Call(sub_31, V.Undef, GetIdx(Get(fc_2662, "q"), 1D), GetIdx(Get(fc_2662, "q"), 0D)), ((V)(0.62))));
v_2715 = Call(nz_35, V.Undef, Call(sub_31, V.Undef, GetIdx(Get(fc_2662, "q"), 1D), GetIdx(Get(fc_2662, "q"), 0D)));
c_2716 = Arr(xc_2658, GetIdx(m0_2714, 1D), GetIdx(m0_2714, 2D));
u_2717 = Arr(((V)(1D)), ((V)(0D)), ((V)(0D)));
Invoke(BK_2651, "line", Arr(Call(add_30, V.Undef, c_2716, Call(add_30, V.Undef, Call(mul_32, V.Undef, u_2717, ((V)((-3.2)))), Call(mul_32, V.Undef, v_2715, ((V)((-2D)))))), Call(add_30, V.Undef, c_2716, Call(add_30, V.Undef, Call(mul_32, V.Undef, u_2717, ((V)(3.2))), Call(mul_32, V.Undef, v_2715, ((V)((-2D)))))), Call(add_30, V.Undef, c_2716, Call(add_30, V.Undef, Call(mul_32, V.Undef, u_2717, ((V)(3.2))), Call(mul_32, V.Undef, v_2715, ((V)(2D))))), Call(add_30, V.Undef, c_2716, Call(add_30, V.Undef, Call(mul_32, V.Undef, u_2717, ((V)((-3.2)))), Call(mul_32, V.Undef, v_2715, ((V)(2D))))), Call(add_30, V.Undef, c_2716, Call(add_30, V.Undef, Call(mul_32, V.Undef, u_2717, ((V)((-3.2)))), Call(mul_32, V.Undef, v_2715, ((V)((-2D))))))), Get(fc_2662, "n"), ((V)(0.6)));
Invoke(BK_2651, "line", Arr(Call(add_30, V.Undef, c_2716, Call(mul_32, V.Undef, v_2715, ((V)((-2D))))), Call(add_30, V.Undef, c_2716, Call(mul_32, V.Undef, v_2715, ((V)(2D))))), Get(fc_2662, "n"), ((V)(0.4)));
}
return default;
}, 1, "", true));
Invoke(Ls_2628, "push", LS_2649, LH_2650, BK_2651);
}
Call(on_2567, V.Undef, S_2595, Ls_2628);
}
return default;
}, 1, "", true));
return default;
}, 3, "", true);
Set(N_21, "shear25", Fn((V _arrowThis2725, int _argc2718, V S_2724, V _a2721, V _a2722, V _a2723, V[] _rest2719) => {
V B_2726 = default;
V D_2727 = default;
B_2726 = Invoke(N_21, "shearChair", S_2724);
D_2727 = Object_assign(NewObj(0).V, B_2726);
Set(D_2727, "layers", Invoke(Get(B_2726, "layers"), "map", Fn((V _arrowThis2736, int _argc2728, V L_2734, V i_2735, V _a2732, V _a2733, V[] _rest2729) => {
return Object_assign(NewObj(0).V, L_2734, NewObj(1).Put("build", Fn((V _arrowThis2744, int _argc2737, V P_2743, V _a2740, V _a2741, V _a2742, V[] _rest2738) => {
V o_2745 = default;
o_2745 = Invoke(L_2734, "build", P_2743);
Call(shearTex_74, V.Undef, o_2745, P_2743, i_2735);
return o_2745;
return default;
}, 1, "build", true)).V);
}, 2, "", true)));
return D_2727;
return default;
}, 1, "", true));
isDec_75 = Fn((V _arrowThis2753, int _argc2746, V S_2752, V _a2749, V _a2750, V _a2751, V[] _rest2747) => {
return (((SEqN(Get(S_2752, "cv"), 0D) ? V.True : V.False) is var _t2754 && !Truthy(_t2754) ? _t2754 : Get(S_2752, "noOut")) is var _t2755 && !Truthy(_t2755) ? _t2755 : (!(Truthy(Get(S_2752, "mat"))) ? V.True : V.False));
}, 1, "", true);
lumOf_76 = Fn((V _arrowThis2763, int _argc2756, V c_2762, V _a2759, V _a2760, V _a2761, V[] _rest2757) => {
V m_2764 = default;
double n_2765 = 0;
m_2764 = Invoke(NewRegExp(RX0, "^#([0-9a-f]{6})$", "i"), "exec", (c_2762 is var _t2766 && Truthy(_t2766) ? _t2766 : ((V)(""))));
if (!(Truthy(m_2764))) {
return ((V)(0.5));
}
n_2765 = ParseInt(GetIdx(m_2764, 1D), ((V)(16D)));
return ((V)(((((((double)(ToInt32(((double)(ToInt32(n_2765) >> (int)(ToUint32(16D) & 31)))) & ToInt32(255D))) * 0.3) + (((double)(ToInt32(((double)(ToInt32(n_2765) >> (int)(ToUint32(8D) & 31)))) & ToInt32(255D))) * 0.59)) + (((double)(ToInt32(n_2765) & ToInt32(255D))) * 0.11)) / 255D)));
return default;
}, 1, "", true);
mtex_77 = Fn((V _arrowThis2776, int _argc2767, V o_2773, V tag_2774, V opt_2775, V _a2772, V[] _rest2768) => {
V on_2777 = default;
V R_2778 = default;
V list_2779 = default;
opt_2775 = (opt_2775 is var _t2780 && Truthy(_t2780) ? _t2780 : NewObj(0).V);
on_2777 = Call(glue_27, V.Undef, o_2773);
R_2778 = Call(R0_28, V.Undef, ((V)(JsStrBuf.Begin().S("mt25").V(tag_2774).End())));
list_2779 = Invoke(o_2773, "slice");
Invoke(list_2779, "forEach", Fn((V _arrowThis2788, int _argc2781, V S_2787, V _a2784, V _a2785, V _a2786, V[] _rest2782) => {
if (Truthy((((((((S_2787 is var _t2789 && !Truthy(_t2789) ? _t2789 : Get(S_2787, "faces")) is var _t2790 && !Truthy(_t2790) ? _t2790 : (!(Truthy(Get(S_2787, "par"))) ? V.True : V.False)) is var _t2791 && !Truthy(_t2791) ? _t2791 : (!(Truthy(Get(S_2787, "emit"))) ? V.True : V.False)) is var _t2792 && !Truthy(_t2792) ? _t2792 : (!Get(S_2787, "op").IsNullish ? V.True : V.False)) is var _t2793 && !Truthy(_t2793) ? _t2793 : (LtN(Get(S_2787, "op"), 0.95) ? V.True : V.False)) is var _t2794 && !Truthy(_t2794) ? _t2794 : (!(Truthy(Call(isDec_75, V.Undef, S_2787))) ? V.True : V.False)) is var _t2795 && !Truthy(_t2795) ? _t2795 : (!SEqN(Get(S_2787, "cv"), 0D) ? V.True : V.False)))) {
V L_2796 = default;
double h_2797 = 0;
double w_2798 = 0;
L_2796 = Call(bbS_38, V.Undef, S_2787);
h_2797 = (ToNum(GetIdx(L_2796, 3D)) - ToNum(GetIdx(L_2796, 2D)));
w_2798 = Max((ToNum(GetIdx(L_2796, 1D)) - ToNum(GetIdx(L_2796, 0D))), (ToNum(GetIdx(L_2796, 5D)) - ToNum(GetIdx(L_2796, 4D))));
if (((h_2797 > 6D) && (w_2798 > 3D))) {
V GL_2799 = default;
V GD_2800 = default;
GL_2799 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.6))).V);
GD_2800 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.35))).V);
Invoke(Call(sides_51, V.Undef, S_2787, ((V)(2D))), "forEach", Fn((V _arrowThis2808, int _argc2801, V F_2807, V _a2804, V _a2805, V _a2806, V[] _rest2802) => {
V G_2809 = default;
V xs_2810 = default;
V ys_2811 = default;
double W_2812 = 0;
double H_2813 = 0;
double fz_2814 = 0;
G_2809 = Call(fr2_39, V.Undef, F_2807);
xs_2810 = Invoke(Get(G_2809, "P"), "map", Fn((V _arrowThis2822, int _argc2815, V q_2821, V _a2818, V _a2819, V _a2820, V[] _rest2816) => {
return GetIdx(q_2821, 0D);
}, 1, "", true));
ys_2811 = Invoke(Get(G_2809, "P"), "map", Fn((V _arrowThis2830, int _argc2823, V q_2829, V _a2826, V _a2827, V _a2828, V[] _rest2824) => {
return GetIdx(q_2829, 1D);
}, 1, "", true));
W_2812 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_2810).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_2810).V)));
H_2813 = (ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_2811).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_2811).V)));
if (((H_2813 < 5D) || (W_2812 < 0.8))) {
return default;
}
fz_2814 = (ToNum(GetIdx(Get(F_2807, "n"), 2D)) - (ToNum(GetIdx(Get(F_2807, "n"), 0D)) * 0.6));
if ((fz_2814 > 0.75)) {
Invoke(GL_2799, "line", Arr(Invoke(G_2809, "at", ((V)(0D)), ((V)(((-H_2813) * 0.42)))), Invoke(G_2809, "at", ((V)(0D)), ((V)((H_2813 * 0.42))))), Get(G_2809, "n"), ((V)(Min((W_2812 * 0.5), 0.9))));
} else {
if (((fz_2814 > 0.2) && (fz_2814 < 0.45))) {
Invoke(GD_2800, "line", Arr(Invoke(G_2809, "at", ((V)(0D)), ((V)(((-H_2813) * 0.3)))), Invoke(G_2809, "at", ((V)(0D)), ((V)((H_2813 * 0.38))))), Get(G_2809, "n"), ((V)(Min((W_2812 * 0.4), 0.45))));
}
}
return default;
}, 1, "", true));
Call(on_2777, V.Undef, S_2787, Arr(GL_2799, GD_2800));
}
}
return default;
}, 1, "", true));
Invoke(list_2779, "forEach", Fn((V _arrowThis2838, int _argc2831, V S_2837, V _a2834, V _a2835, V _a2836, V[] _rest2832) => {
V L_2839 = default;
double sz_2840 = 0;
V mat_2841 = default;
V lu_2842 = default;
V big_2843 = default;
V Ls_2844 = default;
V hiC_2845 = default;
V loC_2846 = default;
if (Truthy(((((((((!(Truthy(S_2837)) || !(Truthy(Get(S_2837, "faces")))) ? V.True : V.False) is var _t2847 && Truthy(_t2847) ? _t2847 : Get(S_2837, "par")) is var _t2848 && Truthy(_t2848) ? _t2848 : Get(S_2837, "emit")) is var _t2849 && Truthy(_t2849) ? _t2849 : Get(S_2837, "noTex")) is var _t2850 && Truthy(_t2850) ? _t2850 : ((!Get(S_2837, "op").IsNullish && LtN(Get(S_2837, "op"), 0.95)) ? V.True : V.False)) is var _t2851 && Truthy(_t2851) ? _t2851 : Call(isDec_75, V.Undef, S_2837)) is var _t2852 && Truthy(_t2852) ? _t2852 : (SEqN(Get(S_2837, "cv"), 0D) ? V.True : V.False)))) {
return default;
}
L_2839 = Call(bbS_38, V.Undef, S_2837);
sz_2840 = Max((ToNum(GetIdx(L_2839, 1D)) - ToNum(GetIdx(L_2839, 0D))), (ToNum(GetIdx(L_2839, 3D)) - ToNum(GetIdx(L_2839, 2D))), (ToNum(GetIdx(L_2839, 5D)) - ToNum(GetIdx(L_2839, 4D))));
if (Lt(((V)(sz_2840)), (Get(opt_2775, "min") is var _t2853 && Truthy(_t2853) ? _t2853 : ((V)(3.5))))) {
return default;
}
mat_2841 = (Get(S_2837, "mat") is var _t2854 && Truthy(_t2854) ? _t2854 : ((V)((Truthy(Get(S_2837, "shine")) ? "metal" : ""))));
lu_2842 = Call(lumOf_76, V.Undef, Get(S_2837, "col"));
big_2843 = Fn((V _arrowThis2862, int _argc2855, V F_2861, V _a2858, V _a2859, V _a2860, V[] _rest2856) => {
return (Gt(((V)(System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(Call(fr2_39, V.Undef, F_2861), "P")))))), (Get(opt_2775, "amin") is var _t2863 && Truthy(_t2863) ? _t2863 : ((V)(14D)))) ? V.True : V.False);
}, 1, "", true);
Ls_2844 = Arr();
hiC_2845 = Call(mix_19, V.Undef, Get(S_2837, "col"), ((V)("#ffffff")), ((V)(0.55)));
loC_2846 = Call(shade_18, V.Undef, Get(S_2837, "col"), ((V)((GtN(lu_2842, 0.6) ? 0.78 : 0.6))));
if (SEqS(mat_2841, "metal")) {
V BR1_2864 = default;
V BR2_2865 = default;
V CL_2866 = default;
BR1_2864 = Call(dec_24, V.Undef, hiC_2845, NewObj(1).Put("op", ((V)(0.32))).V);
BR2_2865 = Call(dec_24, V.Undef, loC_2846, NewObj(1).Put("op", ((V)(0.28))).V);
CL_2866 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.55))).V);
Invoke(Get(S_2837, "faces"), "forEach", Fn((V _arrowThis2874, int _argc2867, V F_2873, V _a2870, V _a2871, V _a2872, V[] _rest2868) => {
if (!(Truthy(Call(big_2843, V.Undef, F_2873)))) {
return default;
}
Call(grain_67, V.Undef, BR1_2864, BR2_2865, F_2873, R_2778, ((V)(Max(0.8, (sz_2840 / 26D)))));
return default;
}, 1, "", true));
Invoke(Call(caps_50, V.Undef, S_2837, ((V)(2D))), "forEach", Fn((V _arrowThis2882, int _argc2875, V F_2881, V _a2878, V _a2879, V _a2880, V[] _rest2876) => {
if (Truthy(((GtN(GetIdx(Get(F_2881, "n"), 1D), 0.6) ? V.True : V.False) is var _t2883 && !Truthy(_t2883) ? _t2883 : Call(big_2843, V.Undef, F_2881)))) {
Call(outline_47, V.Undef, CL_2866, F_2881, ((V)(0.94)), ((V)(0.3)));
}
return default;
}, 1, "", true));
Invoke(Ls_2844, "push", BR1_2864, BR2_2865, CL_2866);
} else {
if (SEqS(mat_2841, "wood")) {
V G1_2884 = default;
V G2_2885 = default;
V KN_2886 = default;
G1_2884 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2837, "col"), ((V)(0.7))), NewObj(1).Put("op", ((V)(0.45))).V);
G2_2885 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_2837, "col"), ((V)("#ffffff")), ((V)(0.25))), NewObj(1).Put("op", ((V)(0.35))).V);
KN_2886 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2837, "col"), ((V)(0.5))), NewObj(1).Put("op", ((V)(0.65))).V);
Invoke(Get(S_2837, "faces"), "forEach", Fn((V _arrowThis2894, int _argc2887, V F_2893, V _a2890, V _a2891, V _a2892, V[] _rest2888) => {
if (Truthy(Call(big_2843, V.Undef, F_2893))) {
Call(grain_67, V.Undef, G1_2884, G2_2885, F_2893, R_2778, ((V)(1.5)), KN_2886);
}
return default;
}, 1, "", true));
Invoke(Ls_2844, "push", G1_2884, G2_2885, KN_2886);
} else {
if ((SEqS(mat_2841, "cer") || SEqS(mat_2841, "stone"))) {
V SP1_2895 = default;
V SP2_2896 = default;
V VN_2897 = default;
V CL_2898 = default;
SP1_2895 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2837, "col"), ((V)(0.7))), NewObj(1).Put("op", ((V)(0.5))).V);
SP2_2896 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_2837, "col"), ((V)("#ffffff")), ((V)(0.5))), NewObj(1).Put("op", ((V)(0.5))).V);
VN_2897 = Call(dec_24, V.Undef, (GtN(lu_2842, 0.55) ? Call(shade_18, V.Undef, Get(S_2837, "col"), ((V)(0.72))) : Call(mix_19, V.Undef, Get(S_2837, "col"), ((V)("#ffffff")), ((V)(0.35)))), NewObj(1).Put("op", ((V)(0.4))).V);
CL_2898 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.4))).V);
Invoke(Get(S_2837, "faces"), "forEach", Fn((V _arrowThis2906, int _argc2899, V F_2905, V _a2902, V _a2903, V _a2904, V[] _rest2900) => {
V G_2907 = default;
double A_2908 = 0;
V P2_2909 = default;
V E_2910 = default;
double n_2911 = 0;
G_2907 = Call(fr2_39, V.Undef, F_2905);
A_2908 = System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(G_2907, "P"))));
if (Lt(((V)(A_2908)), (Get(opt_2775, "amin") is var _t2912 && Truthy(_t2912) ? _t2912 : ((V)(14D))))) {
return default;
}
P2_2909 = Call(shrinkP_41, V.Undef, Get(G_2907, "P"), ((V)(0.9)));
E_2910 = Call(ext2_44, V.Undef, P2_2909);
n_2911 = Min(26D, Round((A_2908 / 9D)));
Call(rep_29, V.Undef, ((V)(n_2911)), Fn((V _arrowThis2920, int _argc2913, V k_2919, V _a2916, V _a2917, V _a2918, V[] _rest2914) => {
V q_2921 = default;
q_2921 = Arr(((V)((((ToNum(Call(R_2778, V.Undef)) - 0.5) * 2D) * ToNum(E_2910)))), ((V)((((ToNum(Call(R_2778, V.Undef)) - 0.5) * 2D) * ToNum(E_2910)))));
if (Truthy(Call(inP_43, V.Undef, P2_2909, q_2921))) {
Call(spot_25, V.Undef, (NumTruthy((ToNum(k_2919) % 3D)) ? SP1_2895 : SP2_2896), Invoke(G_2907, "at", GetIdx(q_2921, 0D), GetIdx(q_2921, 1D)), Get(G_2907, "n"), ((V)((0.18 + (ToNum(Call(R_2778, V.Undef)) * 0.32)))), ((V)((0.15 + (ToNum(Call(R_2778, V.Undef)) * 0.2)))), ((V)((ToNum(Call(R_2778, V.Undef)) * 3D))), ((V)(5D)));
}
return default;
}, 1, "", true));
if (((A_2908 > 60D) && LtN(Call(R_2778, V.Undef), 0.7))) {
double ph_2922 = 0;
double s_2923 = 0;
double th_2924 = 0;
ph_2922 = (ToNum(Call(R_2778, V.Undef)) * 6D);
s_2923 = ((ToNum(Call(R_2778, V.Undef)) - 0.5) * ToNum(E_2910));
th_2924 = (ToNum(Call(R_2778, V.Undef)) * PI_22);
Call(wavy_46, V.Undef, VN_2897, F_2905, Fn((V _arrowThis2932, int _argc2925, V t_2931, V _a2928, V _a2929, V _a2930, V[] _rest2926) => {
double u_2933 = 0;
double w_2934 = 0;
u_2933 = ((-ToNum(E_2910)) + ((2D * ToNum(E_2910)) * ToNum(t_2931)));
w_2934 = (s_2923 + ((FdLibm.Sin(((u_2933 * 0.2) + ph_2922)) * ToNum(E_2910)) * 0.12));
return Arr(((V)(((u_2933 * FdLibm.Cos(th_2924)) - (w_2934 * FdLibm.Sin(th_2924))))), ((V)(((u_2933 * FdLibm.Sin(th_2924)) + (w_2934 * FdLibm.Cos(th_2924))))));
return default;
}, 1, "", true), ((V)(24D)), ((V)(0.3)), ((V)(1D)));
}
return default;
}, 1, "", true));
Invoke(Call(caps_50, V.Undef, S_2837, ((V)(2D))), "forEach", Fn((V _arrowThis2942, int _argc2935, V F_2941, V _a2938, V _a2939, V _a2940, V[] _rest2936) => {
if (Truthy(((GtN(GetIdx(Get(F_2941, "n"), 1D), 0.6) ? V.True : V.False) is var _t2943 && !Truthy(_t2943) ? _t2943 : Call(big_2843, V.Undef, F_2941)))) {
Call(outline_47, V.Undef, CL_2898, F_2941, ((V)(0.95)), ((V)(0.25)));
}
return default;
}, 1, "", true));
Invoke(Ls_2844, "push", SP1_2895, SP2_2896, VN_2897, CL_2898);
} else {
if ((SEqS(mat_2841, "fab") || SEqS(mat_2841, "lea"))) {
if (Truthy((Get(opt_2775, "boucle") is var _t2944 && !Truthy(_t2944) ? _t2944 : (SEqS(mat_2841, "fab") ? V.True : V.False)))) {
V D1_2945 = default;
V D2_2946 = default;
D1_2945 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_2837, "col"), ((V)("#ffffff")), ((V)(0.6))), NewObj(1).Put("op", ((V)(0.6))).V);
D2_2946 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2837, "col"), ((V)(0.84))), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Get(S_2837, "faces"), "forEach", Fn((V _arrowThis2954, int _argc2947, V F_2953, V _a2950, V _a2951, V _a2952, V[] _rest2948) => {
if ((!(Truthy(Call(big_2843, V.Undef, F_2953))) || LtN(GetIdx(Get(F_2953, "n"), 1D), (-0.3)))) {
return default;
}
Call(dots_48, V.Undef, D1_2945, F_2953, ((V)(2.8)), ((V)(0.6)), NewObj(3).Put("sh", ((V)(0.92))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).V);
Call(dots_48, V.Undef, D2_2946, F_2953, ((V)(2.8)), ((V)(0.42)), NewObj(4).Put("sh", ((V)(0.92))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).Put("off", Arr(((V)(1.4)), ((V)(1.1)))).V);
return default;
}, 1, "", true));
Invoke(Ls_2844, "push", D1_2945, D2_2946);
} else {
V W1_2955 = default;
V W2_2956 = default;
W1_2955 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_2837, "col"), ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.28))).V);
W2_2956 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2837, "col"), ((V)(0.8))), NewObj(1).Put("op", ((V)(0.28))).V);
Invoke(Get(S_2837, "faces"), "forEach", Fn((V _arrowThis2964, int _argc2957, V F_2963, V _a2960, V _a2961, V _a2962, V[] _rest2958) => {
if (!(Truthy(Call(big_2843, V.Undef, F_2963)))) {
return default;
}
Call(hatch_45, V.Undef, W1_2955, F_2963, ((V)(0D)), ((V)(1.4)), ((V)(0.22)), NewObj(1).Put("sh", ((V)(0.97))).V);
Call(hatch_45, V.Undef, W2_2956, F_2963, ((V)((PI_22 / 2D))), ((V)(1.4)), ((V)(0.22)), NewObj(1).Put("sh", ((V)(0.97))).V);
return default;
}, 1, "", true));
Invoke(Ls_2844, "push", W1_2955, W2_2956);
}
} else {
if ((sz_2840 > 6D)) {
V SH_2965 = default;
V SD_2966 = default;
SH_2965 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)((GtN(lu_2842, 0.6) ? 0.45 : 0.25)))).V);
SD_2966 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_2837, "col"), ((V)(0.8))), NewObj(1).Put("op", ((V)(0.25))).V);
Invoke(Call(caps_50, V.Undef, S_2837, ((V)(2D))), "forEach", Fn((V _arrowThis2974, int _argc2967, V F_2973, V _a2970, V _a2971, V _a2972, V[] _rest2968) => {
if (Truthy(((GtN(GetIdx(Get(F_2973, "n"), 1D), 0.6) ? V.True : V.False) is var _t2975 && !Truthy(_t2975) ? _t2975 : Call(big_2843, V.Undef, F_2973)))) {
Call(outline_47, V.Undef, SH_2965, F_2973, ((V)(0.93)), ((V)(0.3)));
Call(wavy_46, V.Undef, SH_2965, F_2973, Fn((V _arrowThis2984, int _argc2976, V t_2982, V G_2983, V _a2980, V _a2981, V[] _rest2977) => {
V E_2985 = default;
E_2985 = Call(ext2_44, V.Undef, Get(G_2983, "P"));
return Arr(((V)((((-ToNum(E_2985)) * 0.6) + ((ToNum(E_2985) * 0.9) * ToNum(t_2982))))), ((V)((((-ToNum(E_2985)) * 0.25) + ((ToNum(E_2985) * 0.5) * ToNum(t_2982))))));
return default;
}, 2, "", true), ((V)(8D)), ((V)(0.7)), ((V)(1D)));
}
return default;
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, S_2837, ((V)(2D))), "forEach", Fn((V _arrowThis2993, int _argc2986, V F_2992, V _a2989, V _a2990, V _a2991, V[] _rest2987) => {
if (Truthy(((((System.Math.Abs(ToNum(GetIdx(Get(F_2992, "n"), 1D))) < 0.3) ? V.True : V.False) is var _t2994 && !Truthy(_t2994) ? _t2994 : Call(big_2843, V.Undef, F_2992)) is var _t2995 && !Truthy(_t2995) ? _t2995 : (GtN(GetIdx(Get(F_2992, "n"), 2D), 0.3) ? V.True : V.False)))) {
Call(wavy_46, V.Undef, SD_2966, F_2992, Fn((V _arrowThis3004, int _argc2996, V t_3002, V G_3003, V _a3000, V _a3001, V[] _rest2997) => {
V xs_3005 = default;
V ys_3006 = default;
xs_3005 = Invoke(Get(G_3003, "P"), "map", Fn((V _arrowThis3014, int _argc3007, V q_3013, V _a3010, V _a3011, V _a3012, V[] _rest3008) => {
return GetIdx(q_3013, 0D);
}, 1, "", true));
ys_3006 = Invoke(Get(G_3003, "P"), "map", Fn((V _arrowThis3022, int _argc3015, V q_3021, V _a3018, V _a3019, V _a3020, V[] _rest3016) => {
return GetIdx(q_3021, 1D);
}, 1, "", true));
return Arr(((V)(((ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_3005).V)) * 0.9) + (((ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_3005).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_3005).V))) * 0.9) * ToNum(t_3002))))), ((V)((ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_3006).V)) * 0.7))));
return default;
}, 2, "", true), ((V)(4D)), ((V)(0.5)), ((V)(1D)));
}
return default;
}, 1, "", true));
Invoke(Ls_2844, "push", SH_2965, SD_2966);
}
}
}
}
}
if (Truthy(Get(Ls_2844, "length"))) {
Call(on_2777, V.Undef, S_2837, Ls_2844);
}
return default;
}, 1, "", true));
return default;
}, 3, "", true);
texWrap_78 = Fn((V _arrowThis3033, int _argc3023, V src_3029, V tag_3030, V opt_3031, V more_3032, V[] _rest3024) => {
return Fn((V _arrowThis3041, int _argc3034, V S_3040, V _a3037, V _a3038, V _a3039, V[] _rest3035) => {
V B_3042 = default;
V D_3043 = default;
B_3042 = InvokeK(N_21, src_3029, S_3040);
D_3043 = Object_assign(NewObj(0).V, B_3042);
if (Truthy(Get(B_3042, "build"))) {
Set(D_3043, "build", Fn((V _arrowThis3051, int _argc3044, V _a3046, V _a3047, V _a3048, V _a3049, V[] _rest3045) => {
V o_3052 = default;
V a_3050 = default;
a_3050 = RestArgs(0, _argc3044, _a3046, _a3047, _a3048, _a3049, _rest3045);
o_3052 = InvokeSpread(B_3042, "build", new ArrBuilder().Spread(a_3050).V);
Call(mtex_77, V.Undef, o_3052, tag_3030, opt_3031);
if (Truthy(more_3032)) {
Call(more_3032, V.Undef, o_3052, GetIdx(a_3050, 0D));
}
return o_3052;
return default;
}, 1, "", true));
}
if (Truthy(Get(B_3042, "layers"))) {
Set(D_3043, "layers", Invoke(Get(B_3042, "layers"), "map", Fn((V _arrowThis3061, int _argc3053, V L_3059, V i_3060, V _a3057, V _a3058, V[] _rest3054) => {
return Object_assign(NewObj(0).V, L_3059, NewObj(1).Put("build", Fn((V _arrowThis3069, int _argc3062, V _a3064, V _a3065, V _a3066, V _a3067, V[] _rest3063) => {
V o_3070 = default;
V a_3068 = default;
a_3068 = RestArgs(0, _argc3062, _a3064, _a3065, _a3066, _a3067, _rest3063);
o_3070 = InvokeSpread(L_3059, "build", new ArrBuilder().Spread(a_3068).V);
Call(mtex_77, V.Undef, o_3070, Add(tag_3030, i_3060), opt_3031);
if (Truthy(more_3032)) {
Call(more_3032, V.Undef, o_3070, GetIdx(a_3068, 0D), i_3060);
}
return o_3070;
return default;
}, 1, "build", true)).V);
}, 2, "", true)));
}
return D_3043;
return default;
}, 1, "", true);
}, 4, "", true);
Set(N_21, "bio25", Call(texWrap_78, V.Undef, ((V)("bio24")), ((V)("bio"))));
Set(N_21, "terra25x", Call(texWrap_78, V.Undef, ((V)("terra25")), ((V)("ter")), NewObj(1).Put("min", ((V)(3D))).V));
Set(N_21, "chrono25x", Call(texWrap_78, V.Undef, ((V)("chrono25")), ((V)("chr")), NewObj(1).Put("min", ((V)(3D))).V));
Set(N_21, "lev25x", Call(texWrap_78, V.Undef, ((V)("lev24")), ((V)("lev"))));
Set(N_21, "ikebana25x", Call(texWrap_78, V.Undef, ((V)("ikebana25")), ((V)("ike")), NewObj(2).Put("min", ((V)(2.5))).Put("amin", ((V)(8D))).V));
Set(N_21, "alab25", Call(texWrap_78, V.Undef, ((V)("alab24")), ((V)("ala"))));
Set(N_21, "cloudPitP", Fn((V _arrowThis3078, int _argc3071, V S_3077, V _a3074, V _a3075, V _a3076, V[] _rest3072) => {
V B_3079 = default;
V D_3080 = default;
V pk_3081 = default;
B_3079 = Invoke(N_21, "cloudPit", S_3077);
D_3080 = Object_assign(NewObj(0).V, B_3079);
pk_3081 = Fn((V _arrowThis3089, int _argc3082, V o_3088, V _a3085, V _a3086, V _a3087, V[] _rest3083) => {
Invoke(Invoke(Invoke(Invoke(Invoke(o_3088, "filter", Fn((V _arrowThis3132, int _argc3125, V S2_3131, V _a3128, V _a3129, V _a3130, V[] _rest3126) => {
return ((S2_3131 is var _t3133 && !Truthy(_t3133) ? _t3133 : Get(S2_3131, "pts")) is var _t3134 && !Truthy(_t3134) ? _t3134 : (SEqS(Get(S2_3131, "mat"), "fab") ? V.True : V.False));
}, 1, "", true)), "map", Fn((V _arrowThis3124, int _argc3117, V S2_3123, V _a3120, V _a3121, V _a3122, V[] _rest3118) => {
return NewObj(2).Put("S", S2_3123).Put("L", Call(bbS_38, V.Undef, S2_3123)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis3115, int _argc3108, V b_3114, V _a3111, V _a3112, V _a3113, V[] _rest3109) => {
return (Get(Get(b_3114, "S"), "par") is var _t3116 && !Truthy(_t3116) ? _t3116 : ((System.Math.Abs(((ToNum(GetIdx(Get(b_3114, "L"), 3D)) - ToNum(GetIdx(Get(b_3114, "L"), 2D))) - 18.4)) < 2D) ? V.True : V.False));
}, 1, "", true)), "sort", Fn((V _arrowThis3107, int _argc3099, V a_3105, V b_3106, V _a3103, V _a3104, V[] _rest3100) => {
return ((V)((ToNum(GetIdx(Get(a_3105, "L"), 0D)) - ToNum(GetIdx(Get(b_3106, "L"), 0D)))));
}, 2, "", true)), "forEach", Fn((V _arrowThis3098, int _argc3090, V b_3096, V i_3097, V _a3094, V _a3095, V[] _rest3091) => {
Set(Get(b_3096, "S"), "noTex", ((V)(1D)));
Set(Get(b_3096, "S"), "col", ((V)((Truthy(i_3097) ? "#f3ede2" : "#b5562f"))));
Set(Get(b_3096, "S"), "pk", ((V)((Truthy(i_3097) ? "fur" : "cable"))));
return default;
}, 2, "", true));
return o_3088;
return default;
}, 1, "", true);
if (Truthy(Get(B_3079, "build"))) {
Set(D_3080, "build", Fn((V _arrowThis3142, int _argc3135, V P_3141, V _a3138, V _a3139, V _a3140, V[] _rest3136) => {
return Call(pk_3081, V.Undef, Invoke(B_3079, "build", P_3141));
}, 1, "", true));
}
if (Truthy(Get(B_3079, "layers"))) {
Set(D_3080, "layers", Invoke(Get(B_3079, "layers"), "map", Fn((V _arrowThis3150, int _argc3143, V L_3149, V _a3146, V _a3147, V _a3148, V[] _rest3144) => {
return Object_assign(NewObj(0).V, L_3149, NewObj(1).Put("build", Fn((V _arrowThis3158, int _argc3151, V P_3157, V _a3154, V _a3155, V _a3156, V[] _rest3152) => {
return Call(pk_3081, V.Undef, Invoke(L_3149, "build", P_3157));
}, 1, "build", true)).V);
}, 1, "", true)));
}
return D_3080;
return default;
}, 1, "", true));
pitPil_79 = Fn((V _arrowThis3166, int _argc3159, V o_3165, V _a3162, V _a3163, V _a3164, V[] _rest3160) => {
V on_3167 = default;
V R_3168 = default;
on_3167 = Call(glue_27, V.Undef, o_3165);
R_3168 = Call(R0_28, V.Undef, ((V)("pk25")));
Invoke(Invoke(o_3165, "filter", Fn((V _arrowThis3206, int _argc3199, V S_3205, V _a3202, V _a3203, V _a3204, V[] _rest3200) => {
return (S_3205 is var _t3207 && !Truthy(_t3207) ? _t3207 : Get(S_3205, "pk"));
}, 1, "", true)), "forEach", Fn((V _arrowThis3176, int _argc3169, V S_3175, V _a3172, V _a3173, V _a3174, V[] _rest3170) => {
V L_3177 = default;
L_3177 = Call(bbS_38, V.Undef, S_3175);
if (SEqS(Get(S_3175, "pk"), "cable")) {
V CB_3178 = default;
V CL_3179 = default;
V RB_3180 = default;
CB_3178 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_3175, "col"), ((V)(0.72))), NewObj(1).Put("op", ((V)(0.75))).V);
CL_3179 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_3175, "col"), ((V)("#ffffff")), ((V)(0.25))), NewObj(1).Put("op", ((V)(0.6))).V);
RB_3180 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_3175, "col"), ((V)(0.85))), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Get(S_3175, "faces"), "forEach", Fn((V _arrowThis3188, int _argc3181, V F_3187, V _a3184, V _a3185, V _a3186, V[] _rest3182) => {
if (!(Truthy(Call(bigF_82, V.Undef, F_3187, ((V)(2D)))))) {
return default;
}
Call(hatch_45, V.Undef, RB_3180, F_3187, ((V)((PI_22 / 2D))), ((V)(1.2)), ((V)(0.3)), NewObj(1).Put("sh", ((V)(0.95))).V);
Call(hatch_45, V.Undef, CB_3178, F_3187, ((V)(((PI_22 / 2D) - 0.7))), ((V)(2.4)), ((V)(0.5)), NewObj(1).Put("sh", ((V)(0.95))).V);
Call(hatch_45, V.Undef, CL_3179, F_3187, ((V)(((PI_22 / 2D) + 0.7))), ((V)(2.4)), ((V)(0.4)), NewObj(2).Put("sh", ((V)(0.95))).Put("ph", ((V)(1.2))).V);
return default;
}, 1, "", true));
Call(on_3167, V.Undef, S_3175, Arr(RB_3180, CB_3178, CL_3179));
} else {
V F1_3189 = default;
V F2_3190 = default;
F1_3189 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.7))).V);
F2_3190 = Call(dec_24, V.Undef, ((V)("#d9cfbe")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Get(S_3175, "faces"), "forEach", Fn((V _arrowThis3198, int _argc3191, V F_3197, V _a3194, V _a3195, V _a3196, V[] _rest3192) => {
if (!(Truthy(Call(bigF_82, V.Undef, F_3197, ((V)(3D)))))) {
return default;
}
Call(dots_48, V.Undef, F1_3189, F_3197, ((V)(1.1)), ((V)(0.5)), NewObj(3).Put("sh", ((V)(0.96))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).V);
Call(dots_48, V.Undef, F2_3190, F_3197, ((V)(1.1)), ((V)(0.35)), NewObj(4).Put("sh", ((V)(0.96))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).Put("off", Arr(((V)(0.55)), ((V)(0.45)))).V);
return default;
}, 1, "", true));
Call(on_3167, V.Undef, S_3175, Arr(F1_3189, F2_3190));
}
return default;
}, 1, "", true));
return default;
}, 1, "", true);
Set(N_21, "cloudPit25", Call(texWrap_78, V.Undef, ((V)("cloudPitP")), ((V)("pit")), NewObj(2).Put("boucle", ((V)(1D))).Put("amin", ((V)(30D))).V, Fn((V _arrowThis3217, int _argc3208, V o_3214, V P_3215, V li_3216, V _a3213, V[] _rest3209) => {
V on_3218 = default;
Call(pitPil_79, V.Undef, o_3214);
if (!li_3216.IsNullish) {
return default;
}
on_3218 = Call(glue_27, V.Undef, o_3214);
Invoke(Invoke(o_3214, "filter", Fn((V _arrowThis3236, int _argc3229, V S_3235, V _a3232, V _a3233, V _a3234, V[] _rest3230) => {
return ((((!(Truthy(Get(S_3235, "par"))) && SEqS(Get(S_3235, "mat"), "fab")) ? V.True : V.False) is var _t3237 && !Truthy(_t3237) ? _t3237 : Get(S_3235, "pts")) is var _t3238 && !Truthy(_t3238) ? _t3238 : (((ToNum(Get(Get(S_3235, "pts"), "length")) % 5D) == 0D) ? V.True : V.False));
}, 1, "", true)), "forEach", Fn((V _arrowThis3226, int _argc3219, V S_3225, V _a3222, V _a3223, V _a3224, V[] _rest3220) => {
V L_3227 = default;
V WL_3228 = default;
L_3227 = Call(bbS_38, V.Undef, S_3225);
if (((ToNum(GetIdx(L_3227, 3D)) - ToNum(GetIdx(L_3227, 2D))) > 25D)) {
return default;
}
WL_3228 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_3225, "col"), ((V)(0.8))), NewObj(1).Put("op", ((V)(0.6))).V);
Call(ringL_49, V.Undef, WL_3228, S_3225, ((V)(3D)), ((V)(5D)), ((V)(0.6)), ((V)(0.6)));
Call(on_3218, V.Undef, S_3225, Arr(WL_3228));
return default;
}, 1, "", true));
{
V bp_3239 = default;
bp_3239 = GetIdx(Invoke(Invoke(Invoke(Invoke(o_3214, "filter", Fn((V _arrowThis3272, int _argc3265, V S_3271, V _a3268, V _a3269, V _a3270, V[] _rest3266) => {
return ((!(Truthy(Get(S_3271, "par"))) && SEqS(Get(S_3271, "mat"), "fab")) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis3264, int _argc3257, V S_3263, V _a3260, V _a3261, V _a3262, V[] _rest3258) => {
return NewObj(2).Put("S", S_3263).Put("L", Call(bbS_38, V.Undef, S_3263)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis3256, int _argc3249, V b_3255, V _a3252, V _a3253, V _a3254, V[] _rest3250) => {
return (((ToNum(GetIdx(Get(b_3255, "L"), 3D)) - ToNum(GetIdx(Get(b_3255, "L"), 2D))) > 25D) ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _arrowThis3248, int _argc3240, V a_3246, V b_3247, V _a3244, V _a3245, V[] _rest3241) => {
return ((V)((System.Math.Abs((ToNum(Add(GetIdx(Get(a_3246, "L"), 0D), GetIdx(Get(a_3246, "L"), 1D))) / 2D)) - System.Math.Abs((ToNum(Add(GetIdx(Get(b_3247, "L"), 0D), GetIdx(Get(b_3247, "L"), 1D))) / 2D)))));
}, 2, "", true)), 0D);
if (Truthy(bp_3239)) {
V TC_3273 = default;
V TH_3274 = default;
V K1_3275 = default;
V K2_3276 = default;
double cx_3277 = 0;
double x0_3278 = 0;
double x1_3279 = 0;
TC_3273 = ((V)("#c9a35a"));
TH_3274 = Call(dec_24, V.Undef, TC_3273);
K1_3275 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, TC_3273, ((V)(0.78))), NewObj(1).Put("op", ((V)(0.7))).V);
K2_3276 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, TC_3273, ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.55))).V);
cx_3277 = (ToNum(Add(GetIdx(Get(bp_3239, "L"), 0D), GetIdx(Get(bp_3239, "L"), 1D))) / 2D);
x0_3278 = (cx_3277 - 11D);
x1_3279 = (cx_3277 + 11D);
Invoke(Get(Get(bp_3239, "S"), "faces"), "forEach", Fn((V _arrowThis3287, int _argc3280, V F_3286, V _a3283, V _a3284, V _a3285, V[] _rest3281) => {
V xs_3288 = default;
V q_3289 = default;
if (LtN(GetIdx(Get(F_3286, "n"), 1D), (-0.2))) {
return default;
}
xs_3288 = Invoke(Get(F_3286, "q"), "map", Fn((V _arrowThis3297, int _argc3290, V q_3296, V _a3293, V _a3294, V _a3295, V[] _rest3291) => {
return GetIdx(q_3296, 0D);
}, 1, "", true));
if ((LtN(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_3288).V), x0_3278) || GtN(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_3288).V), x1_3279))) {
return default;
}
if ((LtN(GetIdx(Get(F_3286, "n"), 1D), 0.5) && LtN(GetIdx(Get(F_3286, "n"), 2D), 0.2))) {
return default;
}
q_3289 = Invoke(Get(F_3286, "q"), "map", Fn((V _arrowThis3305, int _argc3298, V p_3304, V _a3301, V _a3302, V _a3303, V[] _rest3299) => {
return Arr(((V)(Max(x0_3278, Min(x1_3279, ToNum(GetIdx(p_3304, 0D)))))), GetIdx(p_3304, 1D), GetIdx(p_3304, 2D));
}, 1, "", true));
Invoke(TH_3274, "poly", q_3289, Get(F_3286, "n"));
Call(hatch_45, V.Undef, Arr(K1_3275, K2_3276), NewObj(2).Put("q", q_3289).Put("n", Get(F_3286, "n")).V, ((V)((PI_22 / 2D))), ((V)(1.8)), ((V)(0.7)), NewObj(1).Put("sh", ((V)(0.95))).V);
return default;
}, 1, "", true));
Call(on_3218, V.Undef, Get(bp_3239, "S"), Arr(TH_3274, K1_3275, K2_3276));
}
}
return default;
}, 3, "", true)));
roles_80 = Fn((V _arrowThis3314, int _argc3306, V o_3312, V P_3313, V _a3310, V _a3311, V[] _rest3307) => {
return Invoke(Invoke(o_3312, "filter", Fn((V _arrowThis3335, int _argc3328, V S_3334, V _a3331, V _a3332, V _a3333, V[] _rest3329) => {
return ((((S_3334 is var _t3336 && !Truthy(_t3336) ? _t3336 : Get(S_3334, "pts")) is var _t3337 && !Truthy(_t3337) ? _t3337 : Get(Get(S_3334, "pts"), "length")) is var _t3338 && !Truthy(_t3338) ? _t3338 : (!(Truthy(Get(S_3334, "par"))) ? V.True : V.False)) is var _t3339 && !Truthy(_t3339) ? _t3339 : (!(Truthy(Get(S_3334, "emit"))) ? V.True : V.False));
}, 1, "", true)), "map", Fn((V _arrowThis3322, int _argc3315, V S_3321, V _a3318, V _a3319, V _a3320, V[] _rest3316) => {
V L_3323 = default;
double w_3324 = 0;
double h_3325 = 0;
double d_3326 = 0;
V r_3327 = default;
L_3323 = Call(bbS_38, V.Undef, S_3321);
w_3324 = (ToNum(GetIdx(L_3323, 1D)) - ToNum(GetIdx(L_3323, 0D)));
h_3325 = (ToNum(GetIdx(L_3323, 3D)) - ToNum(GetIdx(L_3323, 2D)));
d_3326 = (ToNum(GetIdx(L_3323, 5D)) - ToNum(GetIdx(L_3323, 4D)));
r_3327 = ((V)((((SEq(Get(S_3321, "col"), Get(P_3313, "aL")) && GtN(GetIdx(L_3323, 5D), 15D)) && (h_3325 < 22D)) ? "seat" : (((SEq(Get(S_3321, "col"), Get(P_3313, "aL")) && LtN(GetIdx(L_3323, 5D), 0D)) && (h_3325 > 30D)) ? "back" : (SEq(Get(S_3321, "col"), Get(P_3313, "a")) ? ((((h_3325 < 16D) && (d_3326 > 50D)) && (w_3324 < 34D)) ? "roll" : (((w_3324 < 34D) && (d_3326 > 50D)) ? "arm" : "slab")) : (((((!(Truthy(Call(isFab_52, V.Undef, S_3321, P_3313))) && SEqS(Get(S_3321, "mat"), "fab")) && (w_3324 > 17D)) && (w_3324 < 28D)) && (d_3326 < 11D)) ? "pil" : (((SEqS(Get(S_3321, "mat"), "metal") && LtN(GetIdx(L_3323, 2D), 0.5)) && (w_3324 < 8D)) ? "leg" : (((SEqS(Get(S_3321, "mat"), "metal") && (w_3324 > 40D)) && (h_3325 < 4D)) ? "rail" : ""))))))));
return NewObj(3).Put("S", S_3321).Put("L", L_3323).Put("r", r_3327).V;
return default;
}, 1, "", true));
}, 2, "", true);
UPH_81 = NewObj(5).Put("seat", ((V)(1D))).Put("back", ((V)(1D))).Put("roll", ((V)(1D))).Put("arm", ((V)(1D))).Put("slab", ((V)(1D))).V;
bigF_82 = Fn((V _arrowThis3348, int _argc3340, V F_3346, V a_3347, V _a3344, V _a3345, V[] _rest3341) => {
return (Gt(((V)(System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(Call(fr2_39, V.Undef, F_3346), "P")))))), a_3347) ? V.True : V.False);
}, 2, "", true);
fleck_83 = Fn((V _arrowThis3361, int _argc3349, V D1_3355, V D2_3356, V F_3357, V R_3358, V[] _rest3350) => {
V G_3362 = default;
V P2_3363 = default;
V E_3364 = default;
double n_3365 = 0;
V dens_3359 = default;
V r_3360 = default;
dens_3359 = (_argc3349 > 4 ? _rest3350[0] : V.Undef);
r_3360 = (_argc3349 > 5 ? _rest3350[1] : V.Undef);
G_3362 = Call(fr2_39, V.Undef, F_3357);
P2_3363 = Call(shrinkP_41, V.Undef, Get(G_3362, "P"), ((V)(0.92)));
E_3364 = Call(ext2_44, V.Undef, P2_3363);
n_3365 = Min(40D, Round((System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(G_3362, "P")))) * ToNum(dens_3359))));
Call(rep_29, V.Undef, ((V)(n_3365)), Fn((V _arrowThis3373, int _argc3366, V k_3372, V _a3369, V _a3370, V _a3371, V[] _rest3367) => {
V q_3374 = default;
q_3374 = Arr(((V)((((ToNum(Call(R_3358, V.Undef)) - 0.5) * 2D) * ToNum(E_3364)))), ((V)((((ToNum(Call(R_3358, V.Undef)) - 0.5) * 2D) * ToNum(E_3364)))));
if (Truthy(Call(inP_43, V.Undef, P2_3363, q_3374))) {
double rr_3375 = 0;
rr_3375 = (ToNum(r_3360) * (0.7 + (ToNum(Call(R_3358, V.Undef)) * 0.6)));
Call(spot_25, V.Undef, (NumTruthy((ToNum(k_3372) % 2D)) ? D2_3356 : D1_3355), Invoke(G_3362, "at", GetIdx(q_3374, 0D), GetIdx(q_3374, 1D)), Get(G_3362, "n"), ((V)(rr_3375)), ((V)((rr_3375 * 0.85))), ((V)(0D)), ((V)(6D)));
}
return default;
}, 1, "", true));
return default;
}, 6, "", true);
WH2_84 = Fn((V _arrowThis3383, int _argc3376, V G_3382, V _a3379, V _a3380, V _a3381, V[] _rest3377) => {
V xs_3384 = default;
V ys_3385 = default;
xs_3384 = Invoke(Get(G_3382, "P"), "map", Fn((V _arrowThis3393, int _argc3386, V q_3392, V _a3389, V _a3390, V _a3391, V[] _rest3387) => {
return GetIdx(q_3392, 0D);
}, 1, "", true));
ys_3385 = Invoke(Get(G_3382, "P"), "map", Fn((V _arrowThis3401, int _argc3394, V q_3400, V _a3397, V _a3398, V _a3399, V[] _rest3395) => {
return GetIdx(q_3400, 1D);
}, 1, "", true));
return Arr(((V)((ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_3384).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_3384).V))))), ((V)((ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_3385).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_3385).V))))));
return default;
}, 1, "", true);
crease_85 = Fn((V _arrowThis3415, int _argc3402, V D_3408, V F_3409, V R_3410, V n_3411, V[] _rest3403) => {
V sx_3412 = default;
V sy_3413 = default;
V l_3414 = default;
sx_3412 = (_argc3402 > 4 ? _rest3403[0] : V.Undef);
sy_3413 = (_argc3402 > 5 ? _rest3403[1] : V.Undef);
l_3414 = (_argc3402 > 6 ? _rest3403[2] : V.Undef);
return Call(rep_29, V.Undef, n_3411, Fn((V _arrowThis3422, int _argc3416, V _a3418, V _a3419, V _a3420, V _a3421, V[] _rest3417) => {
double a_3423 = 0;
double b_3424 = 0;
double th_3425 = 0;
double ll_3426 = 0;
a_3423 = ((ToNum(Call(R_3410, V.Undef)) - 0.5) * ToNum(sx_3412));
b_3424 = ((ToNum(Call(R_3410, V.Undef)) - 0.5) * ToNum(sy_3413));
th_3425 = (ToNum(Call(R_3410, V.Undef)) * PI_22);
ll_3426 = (ToNum(l_3414) * (0.6 + (ToNum(Call(R_3410, V.Undef)) * 0.8)));
Call(wavy_46, V.Undef, D_3408, F_3409, Fn((V _arrowThis3434, int _argc3427, V t_3433, V _a3430, V _a3431, V _a3432, V[] _rest3428) => {
return Arr(((V)(((a_3423 + ((FdLibm.Cos(th_3425) * ll_3426) * (ToNum(t_3433) - 0.5))) + (FdLibm.Sin((ToNum(t_3433) * PI_22)) * 1.1)))), ((V)((b_3424 + ((FdLibm.Sin(th_3425) * ll_3426) * (ToNum(t_3433) - 0.5))))));
}, 1, "", true), ((V)(10D)), ((V)(0.55)), ((V)(1D)));
return default;
}, 0, "", true));
}, 7, "", true);
frontF_86 = Fn((V _arrowThis3442, int _argc3435, V S_3441, V _a3438, V _a3439, V _a3440, V[] _rest3436) => {
return GetIdx(Invoke(Invoke(Call(sides_51, V.Undef, S_3441, ((V)(3D))), "filter", Fn((V _arrowThis3459, int _argc3452, V F_3458, V _a3455, V _a3456, V _a3457, V[] _rest3453) => {
return (GtN(GetIdx(Get(F_3458, "n"), 2D), 0.7) ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _arrowThis3451, int _argc3443, V a_3449, V b_3450, V _a3447, V _a3448, V[] _rest3444) => {
return ((V)((System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(Call(fr2_39, V.Undef, b_3450), "P")))) - System.Math.Abs(ToNum(Call(area_40, V.Undef, Get(Call(fr2_39, V.Undef, a_3449), "P")))))));
}, 2, "", true)), 0D);
}, 1, "", true);
stitchRing_87 = Fn((V _arrowThis3471, int _argc3460, V D_3466, V S_3467, V k_3468, V nr_3469, V[] _rest3461) => {
double n_3472 = 0;
V RG_3473 = default;
V c_3474 = default;
V w_3470 = default;
w_3470 = (_argc3460 > 4 ? _rest3461[0] : V.Undef);
n_3472 = (ToNum(Get(Get(S_3467, "pts"), "length")) / ToNum(nr_3469));
RG_3473 = Invoke(Get(S_3467, "pts"), "slice", ((V)((ToNum(k_3468) * n_3472))), ((V)((ToNum(Add(k_3468, ((V)(1D)))) * n_3472))));
c_3474 = Invoke(RG_3473, "reduce", Fn((V _arrowThis3483, int _argc3475, V a_3481, V p_3482, V _a3479, V _a3480, V[] _rest3476) => {
return Call(add_30, V.Undef, a_3481, Call(mul_32, V.Undef, p_3482, ((V)((1D / ToNum(Get(RG_3473, "length")))))));
}, 2, "", true), Arr(((V)(0D)), ((V)(0D)), ((V)(0D))));
{
double i_3484 = 0;
i_3484 = 0D;
while (true) {
if (!((i_3484 < n_3472))) break;
V p_3486 = default;
V q_3487 = default;
V nn_3488 = default;
p_3486 = GetIdx(RG_3473, i_3484);
q_3487 = GetIdx(RG_3473, ((i_3484 + 1D) % n_3472));
nn_3488 = Call(nz_35, V.Undef, Call(sub_31, V.Undef, p_3486, c_3474));
Invoke(D_3466, "line", Arr(Call(add_30, V.Undef, p_3486, Call(mul_32, V.Undef, nn_3488, ((V)(0.15)))), Call(add_30, V.Undef, q_3487, Call(mul_32, V.Undef, nn_3488, ((V)(0.15))))), nn_3488, (w_3470 is var _t3489 && Truthy(_t3489) ? _t3489 : ((V)(0.22))));
i_3484 = (i_3484 + 2D);
}
}
return default;
}, 5, "", true);
sideOf_88 = Fn((V _arrowThis3497, int _argc3490, V b_3496, V _a3493, V _a3494, V _a3495, V[] _rest3491) => {
return ((V)(Sign(ToNum(Add(GetIdx(Get(b_3496, "L"), 0D), GetIdx(Get(b_3496, "L"), 1D))))));
}, 1, "", true);
armThrow_89 = Fn((V _arrowThis3509, int _argc3498, V o_3504, V B_3505, V sg_3506, V TC_3507, V[] _rest3499) => {
V on_3510 = default;
V roll_3511 = default;
V S_3512 = default;
V L_3513 = default;
double zc_3514 = 0;
double z0_3515 = 0;
double z1_3516 = 0;
V TH_3517 = default;
V K1_3518 = default;
V ab_3519 = default;
V x_3520 = default;
V y1_3521 = default;
double y0_3522 = 0;
V wv_3523 = default;
V nn_3524 = default;
V Q_3525 = default;
V T2_3526 = default;
V K2_3527 = default;
V FD_3528 = default;
V FR_3529 = default;
V wk_3508 = default;
wk_3508 = (_argc3498 > 4 ? _rest3499[0] : V.Undef);
on_3510 = Call(glue_27, V.Undef, o_3504);
roll_3511 = Invoke(B_3505, "find", Fn((V _arrowThis3537, int _argc3530, V b_3536, V _a3533, V _a3534, V _a3535, V[] _rest3531) => {
return ((SEqS(Get(b_3536, "r"), "roll") && SEq(Call(sideOf_88, V.Undef, b_3536), sg_3506)) ? V.True : V.False);
}, 1, "", true));
if (!(Truthy(roll_3511))) {
return default;
}
{ V _t3538 = roll_3511;
if (_t3538.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3538));
{ V _t3539 = Get(_t3538, "S");
S_3512 = _t3539; }
{ V _t3540 = Get(_t3538, "L");
L_3513 = _t3540; } }
zc_3514 = (ToNum(Add(GetIdx(L_3513, 4D), GetIdx(L_3513, 5D))) / 2D);
z0_3515 = (zc_3514 - 2D);
z1_3516 = (zc_3514 + 20D);
TH_3517 = Call(dec_24, V.Undef, TC_3507);
K1_3518 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, TC_3507, ((V)(0.8))), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Get(S_3512, "faces"), "forEach", Fn((V _arrowThis3548, int _argc3541, V F_3547, V _a3544, V _a3545, V _a3546, V[] _rest3542) => {
V zs_3549 = default;
V q_3550 = default;
if (Truthy(Get(F_3547, "cap"))) {
return default;
}
zs_3549 = Invoke(Get(F_3547, "q"), "map", Fn((V _arrowThis3558, int _argc3551, V q_3557, V _a3554, V _a3555, V _a3556, V[] _rest3552) => {
return GetIdx(q_3557, 2D);
}, 1, "", true));
if (((LtN(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(zs_3549).V), z0_3515) || GtN(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(zs_3549).V), z1_3516)) || ((ToNum(GetIdx(Get(F_3547, "n"), 0D)) * ToNum(sg_3506)) < (-0.3)))) {
return default;
}
q_3550 = Invoke(Get(F_3547, "q"), "map", Fn((V _arrowThis3566, int _argc3559, V p_3565, V _a3562, V _a3563, V _a3564, V[] _rest3560) => {
return Arr(GetIdx(p_3565, 0D), GetIdx(p_3565, 1D), ((V)(Max(z0_3515, Min(z1_3516, ToNum(GetIdx(p_3565, 2D)))))));
}, 1, "", true));
if (((System.Math.Abs((ToNum(GetIdx(GetIdx(q_3550, 0D), 2D)) - ToNum(GetIdx(GetIdx(q_3550, 3D), 2D)))) + System.Math.Abs((ToNum(GetIdx(GetIdx(q_3550, 1D), 2D)) - ToNum(GetIdx(GetIdx(q_3550, 2D), 2D))))) < 0.5)) {
return default;
}
Invoke(TH_3517, "poly", q_3550, Get(F_3547, "n"));
if (SEqS(wk_3508, "fur")) {
Call(dots_48, V.Undef, K1_3518, NewObj(2).Put("q", q_3550).Put("n", Get(F_3547, "n")).V, ((V)(1.3)), ((V)(0.55)), NewObj(3).Put("sh", ((V)(0.97))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).V);
} else {
if (Truthy(wk_3508)) {
Call(hatch_45, V.Undef, K1_3518, NewObj(2).Put("q", q_3550).Put("n", Get(F_3547, "n")).V, ((V)(0D)), ((V)(1.7)), ((V)(0.35)), NewObj(1).Put("sh", ((V)(0.97))).V);
Call(hatch_45, V.Undef, K1_3518, NewObj(2).Put("q", q_3550).Put("n", Get(F_3547, "n")).V, ((V)((PI_22 / 2D))), ((V)(1.7)), ((V)(0.35)), NewObj(1).Put("sh", ((V)(0.97))).V);
}
}
return default;
}, 1, "", true));
Call(on_3510, V.Undef, S_3512, Arr(TH_3517, K1_3518));
ab_3519 = Invoke(B_3505, "find", Fn((V _arrowThis3574, int _argc3567, V b_3573, V _a3570, V _a3571, V _a3572, V[] _rest3568) => {
return ((SEqS(Get(b_3573, "r"), "arm") && SEq(Call(sideOf_88, V.Undef, b_3573), sg_3506)) ? V.True : V.False);
}, 1, "", true));
if (!(Truthy(ab_3519))) {
return default;
}
x_3520 = (LtN(sg_3506, 0D) ? GetIdx(Get(ab_3519, "L"), 0D) : GetIdx(Get(ab_3519, "L"), 1D));
y1_3521 = GetIdx(Get(ab_3519, "L"), 3D);
y0_3522 = (ToNum(y1_3521) - 18D);
wv_3523 = Fn((V _arrowThis3582, int _argc3575, V z_3581, V _a3578, V _a3579, V _a3580, V[] _rest3576) => {
return ((V)((y0_3522 + (FdLibm.Sin((ToNum(z_3581) * 0.7)) * 1.2))));
}, 1, "", true);
nn_3524 = Arr(sg_3506, ((V)(0D)), ((V)(0D)));
Q_3525 = Arr(Arr(x_3520, y1_3521, ((V)(z0_3515))), Arr(x_3520, y1_3521, ((V)(z1_3516))), Arr(x_3520, Call(wv_3523, V.Undef, ((V)(z1_3516))), ((V)((z1_3516 - 1.5)))), Arr(x_3520, Call(wv_3523, V.Undef, ((V)(z0_3515))), ((V)((z0_3515 + 1.5)))));
T2_3526 = Call(dec_24, V.Undef, TC_3507);
K2_3527 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, TC_3507, ((V)(0.8))), NewObj(1).Put("op", ((V)(0.5))).V);
FD_3528 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, TC_3507, ((V)(0.72))), NewObj(1).Put("op", ((V)(0.45))).V);
FR_3529 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, TC_3507, ((V)(0.86))));
Invoke(T2_3526, "poly", Q_3525, nn_3524);
if (SEqS(wk_3508, "fur")) {
Call(dots_48, V.Undef, K2_3527, NewObj(2).Put("q", Q_3525).Put("n", nn_3524).V, ((V)(1.3)), ((V)(0.55)), NewObj(3).Put("sh", ((V)(0.96))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).V);
} else {
if (Truthy(wk_3508)) {
Call(hatch_45, V.Undef, K2_3527, NewObj(2).Put("q", Q_3525).Put("n", nn_3524).V, ((V)(0D)), ((V)(1.7)), ((V)(0.35)), NewObj(1).Put("sh", ((V)(0.96))).V);
Call(hatch_45, V.Undef, K2_3527, NewObj(2).Put("q", Q_3525).Put("n", nn_3524).V, ((V)((PI_22 / 2D))), ((V)(1.7)), ((V)(0.35)), NewObj(1).Put("sh", ((V)(0.96))).V);
}
}
Call(rep_29, V.Undef, ((V)(5D)), Fn((V _arrowThis3590, int _argc3583, V i_3589, V _a3586, V _a3587, V _a3588, V[] _rest3584) => {
double z_3591 = 0;
z_3591 = ((z0_3515 + 3D) + ((ToNum(i_3589) * ((z1_3516 - z0_3515) - 6D)) / 4D));
Invoke(FD_3528, "line", Arr(Arr(x_3520, ((V)((ToNum(y1_3521) - 1D))), ((V)(z_3591))), Arr(x_3520, Add(Call(wv_3523, V.Undef, ((V)(z_3591))), ((V)(1.5))), ((V)(z_3591)))), nn_3524, ((V)(0.5)));
return default;
}, 1, "", true));
Call(rep_29, V.Undef, ((V)(13D)), Fn((V _arrowThis3599, int _argc3592, V i_3598, V _a3595, V _a3596, V _a3597, V[] _rest3593) => {
double z_3600 = 0;
z_3600 = ((z0_3515 + 2D) + ((ToNum(i_3598) * ((z1_3516 - z0_3515) - 4D)) / 12D));
Invoke(FR_3529, "line", Arr(Arr(x_3520, Add(Call(wv_3523, V.Undef, ((V)(z_3600))), ((V)(0.4))), ((V)(z_3600))), Arr(x_3520, ((V)((ToNum(Call(wv_3523, V.Undef, ((V)(z_3600)))) - 2.4))), ((V)((z_3600 + 0.2))))), nn_3524, ((V)(0.4)));
return default;
}, 1, "", true));
Call(on_3510, V.Undef, Get(ab_3519, "S"), Arr(T2_3526, K2_3527, FD_3528, FR_3529));
return default;
}, 5, "", true);
rsWrap_90 = Fn((V _arrowThis3609, int _argc3601, V S_3607, V f_3608, V _a3605, V _a3606, V[] _rest3602) => {
V B_3610 = default;
V D_3611 = default;
B_3610 = Invoke(N_21, "rsofa", S_3607);
D_3611 = Object_assign(NewObj(0).V, B_3610);
Set(D_3611, "build", Fn((V _arrowThis3619, int _argc3612, V P_3618, V _a3615, V _a3616, V _a3617, V[] _rest3613) => {
V o_3620 = default;
o_3620 = Invoke(B_3610, "build", P_3618);
Call(f_3608, V.Undef, o_3620, P_3618);
return o_3620;
return default;
}, 1, "", true));
Set(D_3611, "layers", Invoke(Call(splitL_54, V.Undef, B_3610), "map", Fn((V _arrowThis3629, int _argc3621, V L_3627, V i_3628, V _a3625, V _a3626, V[] _rest3622) => {
return Object_assign(NewObj(0).V, L_3627, NewObj(1).Put("build", Fn((V _arrowThis3637, int _argc3630, V P_3636, V _a3633, V _a3634, V _a3635, V[] _rest3631) => {
V o_3638 = default;
o_3638 = Invoke(L_3627, "build", P_3636);
Call(f_3608, V.Undef, o_3638, P_3636, i_3628);
return o_3638;
return default;
}, 1, "build", true)).V);
}, 2, "", true)));
return D_3611;
return default;
}, 2, "", true);
plaidTex_91 = Fn((V _arrowThis3648, int _argc3639, V o_3645, V P_3646, V li_3647, V _a3644, V[] _rest3640) => {
V on_3649 = default;
V R_3650 = default;
V B_3651 = default;
V seats_3652 = default;
V backs_3653 = default;
on_3649 = Call(glue_27, V.Undef, o_3645);
R_3650 = Call(R0_28, V.Undef, ((V)(JsStrBuf.Begin().S("pl25").V((li_3647.IsNullish ? ((V)("m")) : li_3647)).End())));
B_3651 = Call(roles_80, V.Undef, o_3645, P_3646);
Invoke(B_3651, "forEach", Fn((V _arrowThis3664, int _argc3654, V _a3656, V _a3657, V _a3658, V _a3659, V[] _rest3655) => {
V DK_3665 = default;
V LT_3666 = default;
V AC_3667 = default;
V PF_3668 = default;
V Ls_3669 = default;
V S_3661 = default;
V r_3663 = default;
if (_a3656.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a3656));
{ V _t3660 = Get(_a3656, "S");
S_3661 = _t3660; }
{ V _t3662 = Get(_a3656, "r");
r_3663 = _t3662; }
if (!(Truthy(GetK(UPH_81, r_3663)))) {
return default;
}
DK_3665 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Call(shade_18, V.Undef, Get(S_3661, "col"), ((V)(0.55))), ((V)("#2f4a36")), ((V)(0.5))), NewObj(1).Put("op", ((V)(0.42))).V);
LT_3666 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_3661, "col"), ((V)("#fff3d6")), ((V)(0.6))), NewObj(1).Put("op", ((V)(0.5))).V);
AC_3667 = Call(dec_24, V.Undef, ((V)("#e7b648")), NewObj(1).Put("op", ((V)(0.55))).V);
PF_3668 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_3661, "col"), ((V)("#ffffff")), ((V)(0.45))), NewObj(1).Put("op", ((V)(0.32))).V);
Invoke(Get(S_3661, "faces"), "forEach", Fn((V _arrowThis3677, int _argc3670, V F_3676, V _a3673, V _a3674, V _a3675, V[] _rest3671) => {
if (!(Truthy(Call(bigF_82, V.Undef, F_3676, ((V)(5D)))))) {
return default;
}
Invoke(Arr(((V)(0D)), ((V)((PI_22 / 2D)))), "forEach", Fn((V _arrowThis3685, int _argc3678, V a_3684, V _a3681, V _a3682, V _a3683, V[] _rest3679) => {
Call(hatch_45, V.Undef, DK_3665, F_3676, a_3684, ((V)(9D)), ((V)(2.8)), NewObj(1).Put("sh", ((V)(0.99))).V);
Call(hatch_45, V.Undef, LT_3666, F_3676, a_3684, ((V)(9D)), ((V)(0.35)), NewObj(2).Put("sh", ((V)(0.99))).Put("ph", ((V)(4.5))).V);
Call(hatch_45, V.Undef, AC_3667, F_3676, a_3684, ((V)(18D)), ((V)(0.3)), NewObj(2).Put("sh", ((V)(0.99))).Put("ph", ((V)(1.2))).V);
return default;
}, 1, "", true));
if (Truthy((Call(bigF_82, V.Undef, F_3676, ((V)(40D))) is var _t3686 && !Truthy(_t3686) ? _t3686 : (GtN(GetIdx(Get(F_3676, "n"), 1D), (-0.2)) ? V.True : V.False)))) {
Call(fleck_83, V.Undef, PF_3668, PF_3668, F_3676, R_3650, ((V)(0.05)), ((V)(0.35)));
}
return default;
}, 1, "", true));
Ls_3669 = Arr(DK_3665, LT_3666, AC_3667, PF_3668);
if (SEqS(r_3663, "seat")) {
V HL_3687 = default;
V DN_3688 = default;
V CR_3689 = default;
V fc_3690 = default;
HL_3687 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_3661, "col"), ((V)("#ffffff")), ((V)(0.35))), NewObj(1).Put("op", ((V)(0.16))).V);
DN_3688 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_3661, "col"), ((V)(0.6))), NewObj(1).Put("op", ((V)(0.22))).V);
CR_3689 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_3661, "col"), ((V)(0.5))), NewObj(1).Put("op", ((V)(0.45))).V);
Invoke(Call(caps_50, V.Undef, S_3661, ((V)(2D))), "forEach", Fn((V _arrowThis3698, int _argc3691, V F_3697, V _a3694, V _a3695, V _a3696, V[] _rest3692) => {
V G_3699 = default;
G_3699 = Call(fr2_39, V.Undef, F_3697);
Call(spot_25, V.Undef, HL_3687, Invoke(G_3699, "at", ((V)((-9D))), ((V)(6D))), Get(G_3699, "n"), ((V)(11D)), ((V)(9D)), ((V)(0.3)), ((V)(14D)));
Call(spot_25, V.Undef, HL_3687, Invoke(G_3699, "at", ((V)(10D)), ((V)((-8D)))), Get(G_3699, "n"), ((V)(9D)), ((V)(8D)), ((V)((-0.4))), ((V)(14D)));
Call(spot_25, V.Undef, DN_3688, Invoke(G_3699, "at", ((V)(2D)), ((V)((-1D)))), Get(G_3699, "n"), ((V)(8D)), ((V)(6D)), ((V)(0.2)), ((V)(12D)));
Call(spot_25, V.Undef, DN_3688, Invoke(G_3699, "at", ((V)(2D)), ((V)((-1D)))), Get(G_3699, "n"), ((V)(4D)), ((V)(3D)), ((V)(0.2)), ((V)(10D)));
Call(crease_85, V.Undef, CR_3689, F_3697, R_3650, ((V)(5D)), ((V)(34D)), ((V)(36D)), ((V)(7D)));
return default;
}, 1, "", true));
fc_3690 = Call(frontF_86, V.Undef, S_3661);
if (Truthy(fc_3690)) {
Call(wavy_46, V.Undef, CR_3689, fc_3690, Fn((V _arrowThis3708, int _argc3700, V t_3706, V G_3707, V _a3704, V _a3705, V[] _rest3701) => {
V W_3709 = default;
V H_3710 = default;
{ V _t3711 = Call(WH2_84, V.Undef, G_3707);
{ V _t3712 = ListOf(_t3711);
{ V _t3713 = GetIdx(_t3712, 0D);
W_3709 = _t3713; }
{ V _t3714 = GetIdx(_t3712, 1D);
H_3710 = _t3714; }
} }
return Arr(((V)((((-ToNum(W_3709)) / 2D) + (ToNum(W_3709) * ToNum(t_3706))))), ((V)(((ToNum(H_3710) * 0.32) - ((FdLibm.Sin((ToNum(t_3706) * PI_22)) * ToNum(H_3710)) * 0.18)))));
return default;
}, 2, "", true), ((V)(16D)), ((V)(0.5)), ((V)(1D)));
}
Invoke(Ls_3669, "push", HL_3687, DN_3688, CR_3689);
}
Call(on_3649, V.Undef, S_3661, Ls_3669);
return default;
}, 1, "", true));
seats_3652 = Invoke(Invoke(B_3651, "filter", Fn((V _arrowThis3731, int _argc3724, V b_3730, V _a3727, V _a3728, V _a3729, V[] _rest3725) => {
return (SEqS(Get(b_3730, "r"), "seat") ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _arrowThis3723, int _argc3715, V a_3721, V b_3722, V _a3719, V _a3720, V[] _rest3716) => {
return ((V)((ToNum(GetIdx(Get(a_3721, "L"), 0D)) - ToNum(GetIdx(Get(b_3722, "L"), 0D)))));
}, 2, "", true));
backs_3653 = Invoke(Invoke(B_3651, "filter", Fn((V _arrowThis3748, int _argc3741, V b_3747, V _a3744, V _a3745, V _a3746, V[] _rest3742) => {
return (SEqS(Get(b_3747, "r"), "back") ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _arrowThis3740, int _argc3732, V a_3738, V b_3739, V _a3736, V _a3737, V[] _rest3733) => {
return ((V)((ToNum(GetIdx(Get(a_3738, "L"), 0D)) - ToNum(GetIdx(Get(b_3739, "L"), 0D)))));
}, 2, "", true));
if (Truthy(Get(seats_3652, "length"))) {
V sl_3749 = default;
V fc_3750 = default;
V sr_3751 = default;
V fr_3752 = default;
sl_3749 = GetIdx(seats_3652, 0D);
fc_3750 = Call(frontF_86, V.Undef, Get(sl_3749, "S"));
if (Truthy(fc_3750)) {
V G_3753 = default;
V W_3754 = default;
double x0_3755 = 0;
V HO_3756 = default;
V SP_3757 = default;
V FY_3758 = default;
G_3753 = Call(fr2_39, V.Undef, fc_3750);
{ V _t3759 = Call(WH2_84, V.Undef, G_3753);
{ V _t3760 = ListOf(_t3759);
{ V _t3761 = GetIdx(_t3760, 0D);
W_3754 = _t3761; }
} }
x0_3755 = ((ToNum(W_3754) / 2D) - 8D);
HO_3756 = Call(dec_24, V.Undef, ((V)("#3a2a20")), NewObj(1).Put("op", ((V)(0.85))).V);
SP_3757 = Call(dec_24, V.Undef, ((V)("#c3c8cc")), NewObj(1).Put("shine", ((V)(1D))).V);
FY_3758 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(Get(sl_3749, "S"), "col"), ((V)("#fff3d6")), ((V)(0.5))), NewObj(1).Put("op", ((V)(0.8))).V);
Call(spot_25, V.Undef, HO_3756, Invoke(G_3753, "at", ((V)(x0_3755)), ((V)(0.5))), Get(G_3753, "n"), ((V)(2.2)), ((V)(1.3)), ((V)(0D)), ((V)(10D)));
Invoke(SP_3757, "line", Call(rep_29, V.Undef, ((V)(25D)), Fn((V _arrowThis3769, int _argc3762, V i_3768, V _a3765, V _a3766, V _a3767, V[] _rest3763) => {
double t_3770 = 0;
t_3770 = (ToNum(i_3768) / 24D);
return Invoke(G_3753, "at", ((V)(((x0_3755 + (FdLibm.Sin(((t_3770 * PI_22) * 6D)) * 1.3)) + ((t_3770 - 0.5) * 1.2)))), ((V)(((0.5 + (t_3770 * 1.4)) + (FdLibm.Cos(((t_3770 * PI_22) * 6D)) * 0.55)))));
return default;
}, 1, "", true)), Get(G_3753, "n"), ((V)(0.32)));
Call(rep_29, V.Undef, ((V)(6D)), Fn((V _arrowThis3778, int _argc3771, V i_3777, V _a3774, V _a3775, V _a3776, V[] _rest3772) => {
double a_3779 = 0;
a_3779 = (((ToNum(i_3777) / 6D) * 2D) * PI_22);
Invoke(FY_3758, "line", Arr(Invoke(G_3753, "at", ((V)((x0_3755 + (FdLibm.Cos(a_3779) * 2D)))), ((V)((0.5 + (FdLibm.Sin(a_3779) * 1.2))))), Invoke(G_3753, "at", ((V)((x0_3755 + (FdLibm.Cos(a_3779) * 3D)))), ((V)((0.5 + (FdLibm.Sin(a_3779) * 1.8)))))), Get(G_3753, "n"), ((V)(0.22)));
return default;
}, 1, "", true));
Call(on_3649, V.Undef, Get(sl_3749, "S"), Arr(HO_3756, SP_3757, FY_3758));
}
sr_3751 = GetIdx(seats_3652, (ToNum(Get(seats_3652, "length")) - 1D));
fr_3752 = Call(frontF_86, V.Undef, Get(sr_3751, "S"));
if (Truthy((fr_3752 is var _t3780 && !Truthy(_t3780) ? _t3780 : (!SEq(sr_3751, sl_3749) ? V.True : V.False)))) {
V G_3781 = default;
V TP_3782 = default;
V TL_3783 = default;
V TE_3784 = default;
G_3781 = Call(fr2_39, V.Undef, fr_3752);
TP_3782 = Call(dec_24, V.Undef, ((V)("#b9bec4")));
TL_3783 = Call(dec_24, V.Undef, ((V)("#e8ecef")), NewObj(1).Put("op", ((V)(0.6))).V);
TE_3784 = Call(dec_24, V.Undef, ((V)("#80868c")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Arr(((V)(0.55)), ((V)((-0.55)))), "forEach", Fn((V _arrowThis3792, int _argc3785, V a_3791, V _a3788, V _a3789, V _a3790, V[] _rest3786) => {
double c_3793 = 0;
double s_3794 = 0;
V Q_3795 = default;
c_3793 = FdLibm.Cos(ToNum(a_3791));
s_3794 = FdLibm.Sin(ToNum(a_3791));
Q_3795 = Invoke(Arr(Arr(((V)((-5.5))), ((V)((-1.3)))), Arr(((V)(5.5)), ((V)((-1.3)))), Arr(((V)(5.8)), ((V)(1.3))), Arr(((V)((-5.2))), ((V)(1.3)))), "map", Fn((V _arrowThis3807, int _argc3796, V _a3798, V _a3799, V _a3800, V _a3801, V[] _rest3797) => {
V x_3804 = default;
V y_3806 = default;
{ V _t3802 = ListOf(_a3798);
{ V _t3803 = GetIdx(_t3802, 0D);
x_3804 = _t3803; }
{ V _t3805 = GetIdx(_t3802, 1D);
y_3806 = _t3805; }
}
return Invoke(G_3781, "at", ((V)((((-6D) + (ToNum(x_3804) * c_3793)) - (ToNum(y_3806) * s_3794)))), ((V)(((0.3 + (ToNum(x_3804) * s_3794)) + (ToNum(y_3806) * c_3793)))));
}, 1, "", true));
Invoke(TP_3782, "poly", Q_3795, Get(G_3781, "n"));
Invoke(TL_3783, "line", Arr(GetIdx(Q_3795, 3D), GetIdx(Q_3795, 2D)), Get(G_3781, "n"), ((V)(0.25)));
Invoke(TE_3784, "line", Arr(GetIdx(Q_3795, 1D), GetIdx(Q_3795, 2D)), Get(G_3781, "n"), ((V)(0.2)));
return default;
}, 1, "", true));
Call(on_3649, V.Undef, Get(sr_3751, "S"), Arr(TP_3782, TL_3783, TE_3784));
}
if (!SEq(sr_3751, sl_3749)) {
V CF_3808 = default;
V CS_3809 = default;
CF_3808 = Call(dec_24, V.Undef, ((V)("#6b3f22")), NewObj(1).Put("op", ((V)(0.45))).V);
CS_3809 = Call(dec_24, V.Undef, ((V)("#7a4a2a")), NewObj(1).Put("op", ((V)(0.14))).V);
Invoke(Call(caps_50, V.Undef, Get(sr_3751, "S"), ((V)(2D))), "forEach", Fn((V _arrowThis3817, int _argc3810, V F_3816, V _a3813, V _a3814, V _a3815, V[] _rest3811) => {
V G_3818 = default;
G_3818 = Call(fr2_39, V.Undef, F_3816);
Invoke(CF_3808, "line", Call(rep_29, V.Undef, ((V)(23D)), Fn((V _arrowThis3826, int _argc3819, V i_3825, V _a3822, V _a3823, V _a3824, V[] _rest3820) => {
double a_3827 = 0;
a_3827 = ((((ToNum(i_3825) / 22D) * 2D) * PI_22) * 0.9);
return Invoke(G_3818, "at", ((V)((9D + (FdLibm.Cos(a_3827) * 3.2)))), ((V)((10D + (FdLibm.Sin(a_3827) * 2.8)))));
return default;
}, 1, "", true)), Get(G_3818, "n"), ((V)(0.45)));
Call(spot_25, V.Undef, CS_3809, Invoke(G_3818, "at", ((V)(9.5)), ((V)(9.6))), Get(G_3818, "n"), ((V)(3D)), ((V)(2.6)), ((V)(0D)), ((V)(10D)));
return default;
}, 1, "", true));
Call(on_3649, V.Undef, Get(sr_3751, "S"), Arr(CF_3808, CS_3809));
}
}
if (Truthy(Get(backs_3653, "length"))) {
V bl_3828 = default;
V CD_3829 = default;
V CW_3830 = default;
V SN_3831 = default;
bl_3828 = GetIdx(backs_3653, 0D);
CD_3829 = Call(dec_24, V.Undef, ((V)("#c98f3a")));
CW_3830 = Call(dec_24, V.Undef, ((V)("#9a6a26")), NewObj(1).Put("op", ((V)(0.55))).V);
SN_3831 = Call(dec_24, V.Undef, ((V)("#f4ead2")), NewObj(1).Put("op", ((V)(0.9))).V);
Invoke(Call(caps_50, V.Undef, Get(bl_3828, "S"), ((V)(2D))), "forEach", Fn((V _arrowThis3839, int _argc3832, V F_3838, V _a3835, V _a3836, V _a3837, V[] _rest3833) => {
V G_3840 = default;
V Q_3841 = default;
G_3840 = Call(fr2_39, V.Undef, F_3838);
Q_3841 = Invoke(Arr(Arr(((V)((-13D))), ((V)(1D))), Arr(((V)((-4D))), ((V)(1.6))), Arr(((V)((-4.4))), ((V)(10D))), Arr(((V)((-13.4))), ((V)(9.4)))), "map", Fn((V _arrowThis3853, int _argc3842, V _a3844, V _a3845, V _a3846, V _a3847, V[] _rest3843) => {
V a_3850 = default;
V b_3852 = default;
{ V _t3848 = ListOf(_a3844);
{ V _t3849 = GetIdx(_t3848, 0D);
a_3850 = _t3849; }
{ V _t3851 = GetIdx(_t3848, 1D);
b_3852 = _t3851; }
}
return Invoke(G_3840, "at", a_3850, b_3852);
}, 1, "", true));
Invoke(CD_3829, "poly", Q_3841, Get(G_3840, "n"));
Call(hatch_45, V.Undef, CW_3830, NewObj(2).Put("q", Q_3841).Put("n", Get(G_3840, "n")).V, ((V)((PI_22 / 2D))), ((V)(1D)), ((V)(0.3)), NewObj(1).Put("sh", ((V)(0.92))).V);
Call(rep_29, V.Undef, ((V)(4D)), Fn((V _arrowThis3861, int _argc3854, V e_3860, V _a3857, V _a3858, V _a3859, V[] _rest3855) => {
V A_3862 = default;
V Bq_3863 = default;
A_3862 = GetK(Q_3841, e_3860);
Bq_3863 = GetIdx(Q_3841, (ToNum(Add(e_3860, ((V)(1D)))) % 4D));
Call(rep_29, V.Undef, ((V)(5D)), Fn((V _arrowThis3871, int _argc3864, V k_3870, V _a3867, V _a3868, V _a3869, V[] _rest3865) => {
double t0_3872 = 0;
double t1_3873 = 0;
t0_3872 = (ToNum(Add(k_3870, ((V)(0.2)))) / 5D);
t1_3873 = (ToNum(Add(k_3870, ((V)(0.6)))) / 5D);
Invoke(SN_3831, "line", Arr(Call(add_30, V.Undef, A_3862, Call(mul_32, V.Undef, Call(sub_31, V.Undef, Bq_3863, A_3862), ((V)(t0_3872)))), Call(add_30, V.Undef, A_3862, Call(mul_32, V.Undef, Call(sub_31, V.Undef, Bq_3863, A_3862), ((V)(t1_3873))))), Get(G_3840, "n"), ((V)(0.28)));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Call(on_3649, V.Undef, Get(bl_3828, "S"), Arr(CD_3829, CW_3830, SN_3831));
}
Invoke(Invoke(B_3651, "filter", Fn((V _arrowThis3919, int _argc3912, V b_3918, V _a3915, V _a3916, V _a3917, V[] _rest3913) => {
return ((SEqS(Get(b_3918, "r"), "roll") && GtN(Call(sideOf_88, V.Undef, b_3918), 0D)) ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis3882, int _argc3874, V _a3876, V _a3877, V _a3878, V _a3879, V[] _rest3875) => {
V TB_3883 = default;
V TF_3884 = default;
V S_3881 = default;
if (_a3876.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a3876));
{ V _t3880 = Get(_a3876, "S");
S_3881 = _t3880; }
TB_3883 = Call(dec_24, V.Undef, ((V)("#efe2c4")), NewObj(1).Put("op", ((V)(0.42))).V);
TF_3884 = Call(dec_24, V.Undef, ((V)("#8a6a48")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Get(S_3881, "faces"), "forEach", Fn((V _arrowThis3892, int _argc3885, V F_3891, V _a3888, V _a3889, V _a3890, V[] _rest3886) => {
V zs_3893 = default;
V G_3894 = default;
if (Truthy((Get(F_3891, "cap") is var _t3895 && Truthy(_t3895) ? _t3895 : (LtN(GetIdx(Get(F_3891, "n"), 1D), 0.8) ? V.True : V.False)))) {
return default;
}
zs_3893 = Invoke(Get(F_3891, "q"), "map", Fn((V _arrowThis3903, int _argc3896, V q_3902, V _a3899, V _a3900, V _a3901, V[] _rest3897) => {
return GetIdx(q_3902, 2D);
}, 1, "", true));
if ((LtN(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(zs_3893).V), 10D) || GtN(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(zs_3893).V), 34D))) {
return default;
}
G_3894 = Call(fr2_39, V.Undef, F_3891);
Call(spot_25, V.Undef, TB_3883, Invoke(G_3894, "at", ((V)(0D)), ((V)(0D))), Get(G_3894, "n"), ((V)(3.5)), ((V)(5.5)), ((V)(0.1)), ((V)(12D)));
Call(rep_29, V.Undef, ((V)(5D)), Fn((V _arrowThis3911, int _argc3904, V i_3910, V _a3907, V _a3908, V _a3909, V[] _rest3905) => {
return Invoke(TF_3884, "line", Arr(Invoke(G_3894, "at", Add(((V)((-2D))), i_3910), ((V)((-3D)))), Invoke(G_3894, "at", Add(((V)((-2.2))), i_3910), ((V)(3D)))), Get(G_3894, "n"), ((V)(0.16)));
}, 1, "", true));
return default;
}, 1, "", true));
Call(on_3649, V.Undef, S_3881, Arr(TB_3883, TF_3884));
return default;
}, 1, "", true));
Invoke(Invoke(B_3651, "filter", Fn((V _arrowThis3997, int _argc3990, V b_3996, V _a3993, V _a3994, V _a3995, V[] _rest3991) => {
return (SEqS(Get(b_3996, "r"), "pil") ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis3928, int _argc3920, V _a3922, V _a3923, V _a3924, V _a3925, V[] _rest3921) => {
V GC_3929 = default;
V DS_3930 = default;
V IN_3931 = default;
V S_3927 = default;
if (_a3922.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a3922));
{ V _t3926 = Get(_a3922, "S");
S_3927 = _t3926; }
Set(S_3927, "col", ((V)("#3b3340")));
GC_3929 = Arr(((V)("#e2554a")), ((V)("#f2c94c")), ((V)("#5b8fd0")), ((V)("#7ab86a")), ((V)("#e3946a")), ((V)("#c77dd4")));
DS_3930 = Invoke(GC_3929, "map", Fn((V _arrowThis3939, int _argc3932, V c_3938, V _a3935, V _a3936, V _a3937, V[] _rest3933) => {
return Call(dec_24, V.Undef, c_3938);
}, 1, "", true));
IN_3931 = Call(dec_24, V.Undef, ((V)("#f4ead2")));
Invoke(Arr(((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis3947, int _argc3940, V c0_3946, V _a3943, V _a3944, V _a3945, V[] _rest3941) => {
return Invoke(Call(caps_50, V.Undef, S_3927, c0_3946), "forEach", Fn((V _arrowThis3955, int _argc3948, V F_3954, V _a3951, V _a3952, V _a3953, V[] _rest3949) => {
V G_3956 = default;
G_3956 = Call(fr2_39, V.Undef, F_3954);
Call(rep_29, V.Undef, ((V)(9D)), Fn((V _arrowThis3964, int _argc3957, V k_3963, V _a3960, V _a3961, V _a3962, V[] _rest3958) => {
double i_3965 = 0;
double j_3966 = 0;
double cx_3967 = 0;
double cy_3968 = 0;
V sq_3969 = default;
i_3965 = (ToNum(k_3963) % 3D);
j_3966 = System.Math.Floor((ToNum(k_3963) / 3D));
cx_3967 = ((-5.6) + (i_3965 * 5.6));
cy_3968 = ((-5.6) + (j_3966 * 5.6));
sq_3969 = Fn((V _arrowThis3977, int _argc3970, V s_3976, V _a3973, V _a3974, V _a3975, V[] _rest3971) => {
return Invoke(Arr(Arr(((V)((-ToNum(s_3976)))), ((V)((-ToNum(s_3976))))), Arr(s_3976, ((V)((-ToNum(s_3976))))), Arr(s_3976, s_3976), Arr(((V)((-ToNum(s_3976)))), s_3976)), "map", Fn((V _arrowThis3989, int _argc3978, V _a3980, V _a3981, V _a3982, V _a3983, V[] _rest3979) => {
V a_3986 = default;
V b_3988 = default;
{ V _t3984 = ListOf(_a3980);
{ V _t3985 = GetIdx(_t3984, 0D);
a_3986 = _t3985; }
{ V _t3987 = GetIdx(_t3984, 1D);
b_3988 = _t3987; }
}
return Invoke(G_3956, "at", Add(((V)(cx_3967)), a_3986), Add(((V)(cy_3968)), b_3988));
}, 1, "", true));
}, 1, "", true);
Invoke(GetIdx(DS_3930, (ToNum(Add(k_3963, c0_3946)) % 6D)), "poly", Call(sq_3969, V.Undef, ((V)(2.45))), Get(G_3956, "n"));
Invoke(IN_3931, "poly", Call(sq_3969, V.Undef, ((V)(1.1))), Get(G_3956, "n"));
Invoke(GetIdx(DS_3930, (ToNum(Add(Add(k_3963, c0_3946), ((V)(3D)))) % 6D)), "poly", Call(sq_3969, V.Undef, ((V)(0.5))), Get(G_3956, "n"));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
}, 1, "", true));
Call(on_3649, V.Undef, S_3927, Invoke(DS_3930, "concat", Arr(IN_3931)));
return default;
}, 1, "", true));
if (li_3647.IsNullish) {
V lg_3998 = default;
lg_3998 = GetIdx(Invoke(Invoke(B_3651, "filter", Fn((V _arrowThis4016, int _argc4009, V b_4015, V _a4012, V _a4013, V _a4014, V[] _rest4010) => {
return (SEqS(Get(b_4015, "r"), "leg") ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _arrowThis4007, int _argc3999, V a_4005, V b_4006, V _a4003, V _a4004, V[] _rest4000) => {
return (((V)((ToNum(GetIdx(Get(b_4006, "L"), 4D)) - ToNum(GetIdx(Get(a_4005, "L"), 4D))))) is var _t4008 && Truthy(_t4008) ? _t4008 : ((V)((ToNum(GetIdx(Get(b_4006, "L"), 0D)) - ToNum(GetIdx(Get(a_4005, "L"), 0D))))));
}, 2, "", true)), 0D);
if (Truthy(lg_3998)) {
Set(Get(lg_3998, "S"), "col", ((V)("#8a5a34")));
Set(Get(lg_3998, "S"), "mat", ((V)("wood")));
}
}
return default;
}, 3, "", true);
Set(N_21, "plaid25", Fn((V _arrowThis4024, int _argc4017, V S_4023, V _a4020, V _a4021, V _a4022, V[] _rest4018) => {
return Call(rsWrap_90, V.Undef, S_4023, plaidTex_91);
}, 1, "", true));
scanTex_92 = Fn((V _arrowThis4034, int _argc4025, V o_4031, V P_4032, V li_4033, V _a4030, V[] _rest4026) => {
V on_4035 = default;
V R_4036 = default;
V B_4037 = default;
on_4035 = Call(glue_27, V.Undef, o_4031);
R_4036 = Call(R0_28, V.Undef, ((V)(JsStrBuf.Begin().S("sc25").V((li_4033.IsNullish ? ((V)("m")) : li_4033)).End())));
B_4037 = Call(roles_80, V.Undef, o_4031, P_4032);
Invoke(B_4037, "forEach", Fn((V _arrowThis4048, int _argc4038, V _a4040, V _a4041, V _a4042, V _a4043, V[] _rest4039) => {
V W1_4049 = default;
V W2_4050 = default;
V H1_4051 = default;
V H2_4052 = default;
V WL_4053 = default;
V Ls_4054 = default;
V S_4045 = default;
V r_4047 = default;
if (_a4040.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a4040));
{ V _t4044 = Get(_a4040, "S");
S_4045 = _t4044; }
{ V _t4046 = Get(_a4040, "r");
r_4047 = _t4046; }
if ((SEqS(r_4047, "leg") || SEqS(r_4047, "rail"))) {
V G1_4055 = default;
V G2_4056 = default;
Set(S_4045, "col", ((V)("#c99a62")));
Set(S_4045, "mat", ((V)("wood")));
Set(S_4045, "shine", ((V)(0D)));
G1_4055 = Call(dec_24, V.Undef, ((V)("#9a6c3e")), NewObj(1).Put("op", ((V)(0.5))).V);
G2_4056 = Call(dec_24, V.Undef, ((V)("#e0bb88")), NewObj(1).Put("op", ((V)(0.4))).V);
Invoke(Get(S_4045, "faces"), "forEach", Fn((V _arrowThis4064, int _argc4057, V F_4063, V _a4060, V _a4061, V _a4062, V[] _rest4058) => {
if (Truthy((Call(bigF_82, V.Undef, F_4063, ((V)((SEqS(r_4047, "rail") ? 10D : 2D)))) is var _t4065 && !Truthy(_t4065) ? _t4065 : ((System.Math.Abs(ToNum(GetIdx(Get(F_4063, "n"), 1D))) < 0.5) ? V.True : V.False)))) {
Call(grain_67, V.Undef, G1_4055, G2_4056, F_4063, R_4036, ((V)((SEqS(r_4047, "rail") ? 0.9 : 0.7))));
}
return default;
}, 1, "", true));
Call(on_4035, V.Undef, S_4045, Arr(G1_4055, G2_4056));
return default;
}
if (SEqS(r_4047, "pil")) {
return default;
}
if (!(Truthy(GetK(UPH_81, r_4047)))) {
return default;
}
W1_4049 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_4045, "col"), ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.3))).V);
W2_4050 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4045, "col"), ((V)(0.8))), NewObj(1).Put("op", ((V)(0.3))).V);
H1_4051 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4045, "col"), ((V)(0.8))), NewObj(1).Put("op", ((V)(0.22))).V);
H2_4052 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_4045, "col"), ((V)("#ffffff")), ((V)(0.55))), NewObj(1).Put("op", ((V)(0.3))).V);
WL_4053 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4045, "col"), ((V)(0.74))), NewObj(1).Put("op", ((V)(0.7))).V);
Ls_4054 = Arr(W1_4049, W2_4050, H1_4051, H2_4052, WL_4053);
Invoke(Get(S_4045, "faces"), "forEach", Fn((V _arrowThis4073, int _argc4066, V F_4072, V _a4069, V _a4070, V _a4071, V[] _rest4067) => {
if (!(Truthy(Call(bigF_82, V.Undef, F_4072, ((V)(6D)))))) {
return default;
}
Call(hatch_45, V.Undef, W1_4049, F_4072, ((V)(0D)), ((V)(1.3)), ((V)(0.22)), NewObj(1).Put("sh", ((V)(0.98))).V);
Call(hatch_45, V.Undef, W2_4050, F_4072, ((V)((PI_22 / 2D))), ((V)(1.3)), ((V)(0.22)), NewObj(1).Put("sh", ((V)(0.98))).V);
Call(fleck_83, V.Undef, H1_4051, H2_4052, F_4072, R_4036, ((V)(0.07)), ((V)(0.22)));
return default;
}, 1, "", true));
if (SEqS(r_4047, "seat")) {
V CR_4074 = default;
Call(ringL_49, V.Undef, WL_4053, S_4045, ((V)(4D)), ((V)(6D)), ((V)(0.5)), ((V)(0.6)));
CR_4074 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4045, "col"), ((V)(0.84))), NewObj(1).Put("op", ((V)(0.22))).V);
Invoke(Call(caps_50, V.Undef, S_4045, ((V)(2D))), "forEach", Fn((V _arrowThis4082, int _argc4075, V F_4081, V _a4078, V _a4079, V _a4080, V[] _rest4076) => {
return Call(crease_85, V.Undef, CR_4074, F_4081, R_4036, ((V)(2D)), ((V)(26D)), ((V)(26D)), ((V)(6D)));
}, 1, "", true));
Invoke(Ls_4054, "push", CR_4074);
}
if ((SEqS(r_4047, "back") && ((ToNum(Get(Get(S_4045, "pts"), "length")) % 5D) == 0D))) {
Call(ringL_49, V.Undef, WL_4053, S_4045, ((V)(3D)), ((V)(5D)), ((V)(0.5)), ((V)(0D)));
}
if ((SEqS(r_4047, "roll") && ((ToNum(Get(Get(S_4045, "pts"), "length")) % 4D) == 0D))) {
Call(ringL_49, V.Undef, WL_4053, S_4045, ((V)(0D)), ((V)(4D)), ((V)(0.45)), ((V)(0D)));
Call(ringL_49, V.Undef, WL_4053, S_4045, ((V)(3D)), ((V)(4D)), ((V)(0.45)), ((V)(0D)));
}
Call(on_4035, V.Undef, S_4045, Ls_4054);
return default;
}, 1, "", true));
Invoke(Invoke(B_4037, "filter", Fn((V _arrowThis4147, int _argc4140, V b_4146, V _a4143, V _a4144, V _a4145, V[] _rest4141) => {
return (SEqS(Get(b_4146, "r"), "pil") ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis4092, int _argc4083, V _a4085, V i_4089, V _a4087, V _a4088, V[] _rest4084) => {
V S_4091 = default;
if (_a4085.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a4085));
{ V _t4090 = Get(_a4085, "S");
S_4091 = _t4090; }
if (SEqN(i_4089, 0D)) {
V RB_4093 = default;
V RL_4094 = default;
V ED_4095 = default;
Set(S_4091, "col", ((V)("#d9a441")));
RB_4093 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4091, "col"), ((V)(0.8))), NewObj(1).Put("op", ((V)(0.5))).V);
RL_4094 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_4091, "col"), ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.4))).V);
ED_4095 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4091, "col"), ((V)(0.7))), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Get(S_4091, "faces"), "forEach", Fn((V _arrowThis4103, int _argc4096, V F_4102, V _a4099, V _a4100, V _a4101, V[] _rest4097) => {
if (Truthy(Call(bigF_82, V.Undef, F_4102, ((V)(4D))))) {
Call(hatch_45, V.Undef, Arr(RB_4093, RL_4094), F_4102, ((V)((PI_22 / 2D))), ((V)(1.2)), ((V)(0.4)), NewObj(1).Put("sh", ((V)(0.96))).V);
}
if (Truthy(Get(F_4102, "cap"))) {
Call(outline_47, V.Undef, ED_4095, F_4102, ((V)(0.93)), ((V)(0.4)));
}
return default;
}, 1, "", true));
Call(on_4035, V.Undef, S_4091, Arr(RB_4093, RL_4094, ED_4095));
} else {
V BK_4104 = default;
V ED_4105 = default;
Set(S_4091, "col", ((V)("#f1eee6")));
BK_4104 = Call(dec_24, V.Undef, ((V)("#2b2b2e")), NewObj(1).Put("op", ((V)(0.85))).V);
ED_4105 = Call(dec_24, V.Undef, ((V)("#c9c4b8")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Arr(((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis4113, int _argc4106, V c0_4112, V _a4109, V _a4110, V _a4111, V[] _rest4107) => {
return Invoke(Call(caps_50, V.Undef, S_4091, c0_4112), "forEach", Fn((V _arrowThis4121, int _argc4114, V F_4120, V _a4117, V _a4118, V _a4119, V[] _rest4115) => {
Call(rep_29, V.Undef, ((V)(4D)), Fn((V _arrowThis4129, int _argc4122, V j_4128, V _a4125, V _a4126, V _a4127, V[] _rest4123) => {
return Call(wavy_46, V.Undef, BK_4104, F_4120, Fn((V _arrowThis4137, int _argc4130, V t_4136, V _a4133, V _a4134, V _a4135, V[] _rest4131) => {
double s_4138 = 0;
double z_4139 = 0;
s_4138 = ((ToNum(t_4136) * 7D) % 1D);
z_4139 = ((s_4138 < 0.5) ? (s_4138 * 2D) : ((1D - s_4138) * 2D));
return Arr(((V)(((-8D) + (16D * ToNum(t_4136))))), ((V)((((-6.3) + (ToNum(j_4128) * 4.2)) + (z_4139 * 1.7)))));
return default;
}, 1, "", true), ((V)(42D)), ((V)(0.42)));
}, 1, "", true));
Call(outline_47, V.Undef, ED_4105, F_4120, ((V)(0.93)), ((V)(0.4)));
return default;
}, 1, "", true));
}, 1, "", true));
Call(on_4035, V.Undef, S_4091, Arr(BK_4104, ED_4105));
}
return default;
}, 2, "", true));
Invoke(o_4031, "forEach", Fn((V _arrowThis4155, int _argc4148, V S_4154, V _a4151, V _a4152, V _a4153, V[] _rest4149) => {
if (Truthy(((((S_4154 is var _t4156 && !Truthy(_t4156) ? _t4156 : (SEqS(Get(S_4154, "mat"), "metal") ? V.True : V.False)) is var _t4157 && !Truthy(_t4157) ? _t4157 : (!(Truthy(Get(S_4154, "emit"))) ? V.True : V.False)) is var _t4158 && !Truthy(_t4158) ? _t4158 : Get(S_4154, "par")) is var _t4159 && !Truthy(_t4159) ? _t4159 : (!SEqS(Get(S_4154, "col"), "#c99a62") ? V.True : V.False)))) {
Set(S_4154, "col", ((V)("#b88a55")));
Set(S_4154, "mat", ((V)("wood")));
Set(S_4154, "shine", ((V)(0D)));
}
return default;
}, 1, "", true));
if (SEqN(li_4033, 1D)) {
Call(armThrow_89, V.Undef, o_4031, B_4037, ((V)((-1D))), ((V)("#e3d8c4")), ((V)(1D)));
}
return default;
}, 3, "", true);
Set(N_21, "scandi25", Fn((V _arrowThis4167, int _argc4160, V S_4166, V _a4163, V _a4164, V _a4165, V[] _rest4161) => {
return Call(rsWrap_90, V.Undef, S_4166, scanTex_92);
}, 1, "", true));
cogTex_93 = Fn((V _arrowThis4177, int _argc4168, V o_4174, V P_4175, V li_4176, V _a4173, V[] _rest4169) => {
V on_4178 = default;
V R_4179 = default;
V B_4180 = default;
on_4178 = Call(glue_27, V.Undef, o_4174);
R_4179 = Call(R0_28, V.Undef, ((V)(JsStrBuf.Begin().S("cg25").V((li_4176.IsNullish ? ((V)("m")) : li_4176)).End())));
B_4180 = Call(roles_80, V.Undef, o_4174, P_4175);
Invoke(B_4180, "forEach", Fn((V _arrowThis4191, int _argc4181, V _a4183, V _a4184, V _a4185, V _a4186, V[] _rest4182) => {
V PA_4192 = default;
V FL_4193 = default;
V FL2_4194 = default;
V WL_4195 = default;
V ST_4196 = default;
V CR_4197 = default;
V Ls_4198 = default;
V S_4188 = default;
V r_4190 = default;
if (_a4183.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a4183));
{ V _t4187 = Get(_a4183, "S");
S_4188 = _t4187; }
{ V _t4189 = Get(_a4183, "r");
r_4190 = _t4189; }
if (!(Truthy(GetK(UPH_81, r_4190)))) {
return default;
}
Set(S_4188, "mat", ((V)("lea")));
PA_4192 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_4188, "col"), ((V)("#ffe2b8")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.26))).V);
FL_4193 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4188, "col"), ((V)(0.85))), NewObj(1).Put("op", ((V)(0.22))).V);
FL2_4194 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_4188, "col"), ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.18))).V);
WL_4195 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4188, "col"), ((V)(0.5))), NewObj(1).Put("op", ((V)(0.85))).V);
ST_4196 = Call(dec_24, V.Undef, ((V)("#f2e2c0")), NewObj(1).Put("op", ((V)(0.75))).V);
CR_4197 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4188, "col"), ((V)(0.86))), NewObj(1).Put("op", ((V)(0.2))).V);
Ls_4198 = Arr(PA_4192, FL_4193, FL2_4194, CR_4197);
Invoke(Get(S_4188, "faces"), "forEach", Fn((V _arrowThis4206, int _argc4199, V F_4205, V _a4202, V _a4203, V _a4204, V[] _rest4200) => {
if (Truthy(Call(bigF_82, V.Undef, F_4205, ((V)(30D))))) {
Call(fleck_83, V.Undef, FL_4193, FL2_4194, F_4205, R_4179, ((V)(0.06)), ((V)(0.25)));
}
return default;
}, 1, "", true));
if (SEqS(r_4190, "seat")) {
V fc_4207 = default;
Invoke(Call(caps_50, V.Undef, S_4188, ((V)(2D))), "forEach", Fn((V _arrowThis4215, int _argc4208, V F_4214, V _a4211, V _a4212, V _a4213, V[] _rest4209) => {
V G_4216 = default;
G_4216 = Call(fr2_39, V.Undef, F_4214);
Call(spot_25, V.Undef, PA_4192, Invoke(G_4216, "at", ((V)(0D)), ((V)(2D))), Get(G_4216, "n"), ((V)(12D)), ((V)(12D)), ((V)(0.2)), ((V)(14D)));
Call(spot_25, V.Undef, PA_4192, Invoke(G_4216, "at", ((V)(0D)), ((V)(2D))), Get(G_4216, "n"), ((V)(6D)), ((V)(7D)), ((V)(0.2)), ((V)(10D)));
Call(crease_85, V.Undef, CR_4197, F_4214, R_4179, ((V)(3D)), ((V)(26D)), ((V)(30D)), ((V)(7D)));
return default;
}, 1, "", true));
fc_4207 = Call(frontF_86, V.Undef, S_4188);
if (Truthy(fc_4207)) {
Call(wavy_46, V.Undef, PA_4192, fc_4207, Fn((V _arrowThis4225, int _argc4217, V t_4223, V G_4224, V _a4221, V _a4222, V[] _rest4218) => {
V W_4226 = default;
V H_4227 = default;
{ V _t4228 = Call(WH2_84, V.Undef, G_4224);
{ V _t4229 = ListOf(_t4228);
{ V _t4230 = GetIdx(_t4229, 0D);
W_4226 = _t4230; }
{ V _t4231 = GetIdx(_t4229, 1D);
H_4227 = _t4231; }
} }
return Arr(((V)((((-ToNum(W_4226)) / 2D) + (ToNum(W_4226) * ToNum(t_4223))))), ((V)((ToNum(H_4227) * 0.3))));
return default;
}, 2, "", true), ((V)(16D)), ((V)(2.2)), ((V)(1D)));
}
Call(ringL_49, V.Undef, WL_4195, S_4188, ((V)(4D)), ((V)(6D)), ((V)(0.65)), ((V)(0.6)));
Call(stitchRing_87, V.Undef, ST_4196, S_4188, ((V)(3D)), ((V)(6D)));
Invoke(Ls_4198, "push", WL_4195, ST_4196);
}
if (SEqS(r_4190, "back")) {
Invoke(Call(caps_50, V.Undef, S_4188, ((V)(2D))), "forEach", Fn((V _arrowThis4239, int _argc4232, V F_4238, V _a4235, V _a4236, V _a4237, V[] _rest4233) => {
V G_4240 = default;
G_4240 = Call(fr2_39, V.Undef, F_4238);
Call(spot_25, V.Undef, PA_4192, Invoke(G_4240, "at", ((V)(0D)), ((V)(6D))), Get(G_4240, "n"), ((V)(14D)), ((V)(10D)), ((V)(0D)), ((V)(14D)));
Call(crease_85, V.Undef, CR_4197, F_4238, R_4179, ((V)(2D)), ((V)(32D)), ((V)(16D)), ((V)(9D)));
return default;
}, 1, "", true));
if (((ToNum(Get(Get(S_4188, "pts"), "length")) % 5D) == 0D)) {
Call(ringL_49, V.Undef, WL_4195, S_4188, ((V)(3D)), ((V)(5D)), ((V)(0.6)), ((V)(0D)));
Call(stitchRing_87, V.Undef, ST_4196, S_4188, ((V)(2D)), ((V)(5D)));
}
Invoke(Ls_4198, "push", WL_4195, ST_4196);
}
if (SEqS(r_4190, "roll")) {
Invoke(Get(S_4188, "faces"), "forEach", Fn((V _arrowThis4248, int _argc4241, V F_4247, V _a4244, V _a4245, V _a4246, V[] _rest4242) => {
if (((!(Truthy(Get(F_4247, "cap"))) && GtN(GetIdx(Get(F_4247, "n"), 1D), 0.55)) && GtN(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(F_4247, "q"), 3D), GetIdx(Get(F_4247, "q"), 0D))).V), 30D))) {
Call(wavy_46, V.Undef, PA_4192, F_4247, Fn((V _arrowThis4257, int _argc4249, V t_4255, V G_4256, V _a4253, V _a4254, V[] _rest4250) => {
V W_4258 = default;
V H_4259 = default;
{ V _t4260 = Call(WH2_84, V.Undef, G_4256);
{ V _t4261 = ListOf(_t4260);
{ V _t4262 = GetIdx(_t4261, 0D);
W_4258 = _t4262; }
{ V _t4263 = GetIdx(_t4261, 1D);
H_4259 = _t4263; }
} }
return (Gt(W_4258, H_4259) ? Arr(((V)((((-ToNum(W_4258)) / 2D) + (ToNum(W_4258) * ToNum(t_4255))))), ((V)(((FdLibm.Sin((ToNum(t_4255) * 9D)) * ToNum(H_4259)) * 0.12)))) : Arr(((V)(((FdLibm.Sin((ToNum(t_4255) * 9D)) * ToNum(W_4258)) * 0.12))), ((V)((((-ToNum(H_4259)) / 2D) + (ToNum(H_4259) * ToNum(t_4255)))))));
return default;
}, 2, "", true), ((V)(20D)), ((V)(2.4)), ((V)(1D)));
}
return default;
}, 1, "", true));
if (((ToNum(Get(Get(S_4188, "pts"), "length")) % 4D) == 0D)) {
Call(ringL_49, V.Undef, WL_4195, S_4188, ((V)(0D)), ((V)(4D)), ((V)(0.5)), ((V)(0D)));
Call(ringL_49, V.Undef, WL_4195, S_4188, ((V)(3D)), ((V)(4D)), ((V)(0.5)), ((V)(0D)));
}
Invoke(Ls_4198, "push", WL_4195);
}
Call(on_4178, V.Undef, S_4188, Ls_4198);
return default;
}, 1, "", true));
Invoke(Invoke(B_4180, "filter", Fn((V _arrowThis4324, int _argc4317, V b_4323, V _a4320, V _a4321, V _a4322, V[] _rest4318) => {
return (SEqS(Get(b_4323, "r"), "pil") ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis4273, int _argc4264, V _a4266, V i_4270, V _a4268, V _a4269, V[] _rest4265) => {
V S_4272 = default;
if (_a4266.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a4266));
{ V _t4271 = Get(_a4266, "S");
S_4272 = _t4271; }
if (SEqN(i_4270, 0D)) {
V D1_4274 = default;
V D2_4275 = default;
Set(S_4272, "col", ((V)("#ebe3d4")));
D1_4274 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.6))).V);
D2_4275 = Call(dec_24, V.Undef, ((V)("#c9bfae")), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Get(S_4272, "faces"), "forEach", Fn((V _arrowThis4283, int _argc4276, V F_4282, V _a4279, V _a4280, V _a4281, V[] _rest4277) => {
if (!(Truthy(Call(bigF_82, V.Undef, F_4282, ((V)(6D)))))) {
return default;
}
Call(dots_48, V.Undef, D1_4274, F_4282, ((V)(1.9)), ((V)(0.5)), NewObj(3).Put("sh", ((V)(0.92))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).V);
Call(dots_48, V.Undef, D2_4275, F_4282, ((V)(1.9)), ((V)(0.36)), NewObj(4).Put("sh", ((V)(0.92))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).Put("off", Arr(((V)(0.95)), ((V)(0.8)))).V);
return default;
}, 1, "", true));
Call(on_4178, V.Undef, S_4272, Arr(D1_4274, D2_4275));
} else {
V H1_4284 = default;
V H2_4285 = default;
V ED_4286 = default;
Set(S_4272, "col", ((V)("#4a4a50")));
H1_4284 = Call(dec_24, V.Undef, ((V)("#6a6a72")), NewObj(1).Put("op", ((V)(0.6))).V);
H2_4285 = Call(dec_24, V.Undef, ((V)("#34343a")), NewObj(1).Put("op", ((V)(0.6))).V);
ED_4286 = Call(dec_24, V.Undef, ((V)("#2a2a2e")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Get(S_4272, "faces"), "forEach", Fn((V _arrowThis4294, int _argc4287, V F_4293, V _a4290, V _a4291, V _a4292, V[] _rest4288) => {
V G_4295 = default;
V E_4296 = default;
if (!(Truthy(Call(bigF_82, V.Undef, F_4293, ((V)(6D)))))) {
return default;
}
G_4295 = Call(fr2_39, V.Undef, F_4293);
E_4296 = Call(ext2_44, V.Undef, Get(G_4295, "P"));
{
V c_4297 = default;
c_4297 = ((V)((-ToNum(E_4296))));
while (true) {
V c_4297_it = c_4297;
if (!(Lt(c_4297_it, E_4296))) break;
Invoke(Arr(((V)((PI_22 / 4D))), ((V)(((-PI_22) / 4D)))), "forEach", Fn((V _arrowThis4307, int _argc4299, V a_4305, V j_4306, V _a4303, V _a4304, V[] _rest4300) => {
V x0_4308 = default;
x0_4308 = Add(c_4297_it, ((V)((ToNum(j_4306) * 1.5))));
Call(wavy_46, V.Undef, (Truthy(j_4306) ? H2_4285 : H1_4284), F_4293, Fn((V _arrowThis4316, int _argc4309, V t_4315, V _a4312, V _a4313, V _a4314, V[] _rest4310) => {
return Arr(Add(x0_4308, ((V)(((Truthy(j_4306) ? (-1D) : 1D) * 0.5)))), ((V)(((-ToNum(E_4296)) + ((2D * ToNum(E_4296)) * ToNum(t_4315))))));
}, 1, "", true), ((V)(6D)), ((V)(0.5)));
return default;
}, 2, "", true));
c_4297 = c_4297_it;
c_4297 = Add(c_4297, ((V)(3D)));
}
}
Call(hatch_45, V.Undef, H1_4284, F_4293, ((V)((PI_22 / 4D))), ((V)(3D)), ((V)(0.35)), NewObj(1).Put("sh", ((V)(0.92))).V);
Call(hatch_45, V.Undef, H2_4285, F_4293, ((V)(((-PI_22) / 4D))), ((V)(3D)), ((V)(0.35)), NewObj(2).Put("sh", ((V)(0.92))).Put("ph", ((V)(1.5))).V);
if (Truthy(Get(F_4293, "cap"))) {
Call(outline_47, V.Undef, ED_4286, F_4293, ((V)(0.93)), ((V)(0.4)));
}
return default;
}, 1, "", true));
Call(on_4178, V.Undef, S_4272, Arr(H1_4284, H2_4285, ED_4286));
}
return default;
}, 2, "", true));
if (li_4176.IsNullish) {
V ch_4325 = default;
ch_4325 = GetIdx(Invoke(Invoke(B_4180, "filter", Fn((V _arrowThis4342, int _argc4335, V b_4341, V _a4338, V _a4339, V _a4340, V[] _rest4336) => {
return (SEqS(Get(b_4341, "r"), "seat") ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _arrowThis4334, int _argc4326, V a_4332, V b_4333, V _a4330, V _a4331, V[] _rest4327) => {
return ((V)(((ToNum(GetIdx(Get(b_4333, "L"), 5D)) - ToNum(GetIdx(Get(b_4333, "L"), 4D))) - (ToNum(GetIdx(Get(a_4332, "L"), 5D)) - ToNum(GetIdx(Get(a_4332, "L"), 4D))))));
}, 2, "", true)), 0D);
if (Truthy((ch_4325 is var _t4343 && !Truthy(_t4343) ? _t4343 : (((ToNum(GetIdx(Get(ch_4325, "L"), 5D)) - ToNum(GetIdx(Get(ch_4325, "L"), 4D))) > 75D) ? V.True : V.False)))) {
V BC_4344 = default;
V BL_4345 = default;
V BK_4346 = default;
V BS_4347 = default;
V BF_4348 = default;
V FR_4349 = default;
BC_4344 = ((V)("#7b8088"));
BL_4345 = Call(dec_24, V.Undef, BC_4344);
BK_4346 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, BC_4344, ((V)(0.82))), NewObj(1).Put("op", ((V)(0.5))).V);
BS_4347 = Call(dec_24, V.Undef, ((V)("#efe6d6")), NewObj(1).Put("op", ((V)(0.9))).V);
BF_4348 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, BC_4344, ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.7))).V);
FR_4349 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, BC_4344, ((V)(0.9))));
Invoke(Call(caps_50, V.Undef, Get(ch_4325, "S"), ((V)(2D))), "forEach", Fn((V _arrowThis4357, int _argc4350, V F_4356, V _a4353, V _a4354, V _a4355, V[] _rest4351) => {
V G_4358 = default;
V W_4359 = default;
V H_4360 = default;
double a0_4361 = 0;
double a1_4362 = 0;
double b0_4363 = 0;
double b1_4364 = 0;
V Q_4365 = default;
G_4358 = Call(fr2_39, V.Undef, F_4356);
{ V _t4366 = Call(WH2_84, V.Undef, G_4358);
{ V _t4367 = ListOf(_t4366);
{ V _t4368 = GetIdx(_t4367, 0D);
W_4359 = _t4368; }
{ V _t4369 = GetIdx(_t4367, 1D);
H_4360 = _t4369; }
} }
a0_4361 = (((-ToNum(W_4359)) / 2D) + 2.5);
a1_4362 = ((ToNum(W_4359) / 2D) - 2.5);
b0_4363 = (((-ToNum(H_4360)) / 2D) + 3D);
b1_4364 = (b0_4363 + 22D);
Q_4365 = Arr(Invoke(G_4358, "at", ((V)(a0_4361)), ((V)(b0_4363))), Invoke(G_4358, "at", ((V)(a1_4362)), ((V)(b0_4363))), Invoke(G_4358, "at", ((V)((a1_4362 - 0.6))), ((V)(b1_4364))), Invoke(G_4358, "at", ((V)((a0_4361 + 0.6))), ((V)(b1_4364))));
Invoke(BL_4345, "poly", Q_4365, Get(G_4358, "n"));
Call(hatch_45, V.Undef, BK_4346, NewObj(2).Put("q", Q_4365).Put("n", Get(G_4358, "n")).V, ((V)((PI_22 / 4D))), ((V)(1.4)), ((V)(0.3)), NewObj(1).Put("sh", ((V)(0.95))).V);
Invoke(Arr(((V)(3D)), ((V)(4.6))), "forEach", Fn((V _arrowThis4377, int _argc4370, V y_4376, V _a4373, V _a4374, V _a4375, V[] _rest4371) => {
return Invoke(BS_4347, "line", Arr(Invoke(G_4358, "at", ((V)((a0_4361 + 0.3))), Add(((V)(b0_4363)), y_4376)), Invoke(G_4358, "at", ((V)((a1_4362 - 0.3))), Add(((V)(b0_4363)), y_4376))), Get(G_4358, "n"), ((V)(0.7)));
}, 1, "", true));
Invoke(BF_4348, "line", Arr(Invoke(G_4358, "at", ((V)((a0_4361 + 0.5))), ((V)((b0_4363 + 11D)))), Invoke(G_4358, "at", ((V)((a1_4362 - 0.5))), ((V)((b0_4363 + 11.4))))), Get(G_4358, "n"), ((V)(0.45)));
Call(rep_29, V.Undef, ((V)(Round(((a1_4362 - a0_4361) / 1.3)))), Fn((V _arrowThis4385, int _argc4378, V i_4384, V _a4381, V _a4382, V _a4383, V[] _rest4379) => {
double a_4386 = 0;
a_4386 = ((a0_4361 + 0.6) + (ToNum(i_4384) * 1.3));
Invoke(FR_4349, "line", Arr(Invoke(G_4358, "at", ((V)(a_4386)), ((V)((b0_4363 + 0.2)))), Invoke(G_4358, "at", ((V)((a_4386 + 0.2))), ((V)((b0_4363 - 2D))))), Get(G_4358, "n"), ((V)(0.35)));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Call(on_4178, V.Undef, Get(ch_4325, "S"), Arr(BL_4345, BK_4346, BS_4347, BF_4348, FR_4349));
}
}
return default;
}, 3, "", true);
Set(N_21, "cognac25", Fn((V _arrowThis4394, int _argc4387, V S_4393, V _a4390, V _a4391, V _a4392, V[] _rest4388) => {
return Call(rsWrap_90, V.Undef, S_4393, cogTex_93);
}, 1, "", true));
velTex_94 = Fn((V _arrowThis4404, int _argc4395, V o_4401, V P_4402, V li_4403, V _a4400, V[] _rest4396) => {
V on_4405 = default;
V R_4406 = default;
V F0_4407 = default;
V B_4408 = default;
V nap_4409 = default;
on_4405 = Call(glue_27, V.Undef, o_4401);
R_4406 = Call(R0_28, V.Undef, ((V)(JsStrBuf.Begin().S("vl25").V(li_4403).End())));
F0_4407 = Call(F0of_69, V.Undef, P_4402);
B_4408 = Invoke(Invoke(o_4401, "map", Fn((V _arrowThis4428, int _argc4421, V S_4427, V _a4424, V _a4425, V _a4426, V[] _rest4422) => {
return NewObj(2).Put("S", S_4427).Put("L", Call(bbS_38, V.Undef, S_4427)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis4417, int _argc4410, V b_4416, V _a4413, V _a4414, V _a4415, V[] _rest4411) => {
return (((Get(Get(b_4416, "S"), "pts") is var _t4418 && !Truthy(_t4418) ? _t4418 : Get(Get(Get(b_4416, "S"), "pts"), "length")) is var _t4419 && !Truthy(_t4419) ? _t4419 : (!(Truthy(Get(Get(b_4416, "S"), "par"))) ? V.True : V.False)) is var _t4420 && !Truthy(_t4420) ? _t4420 : (!(Truthy(Get(Get(b_4416, "S"), "emit"))) ? V.True : V.False));
}, 1, "", true));
nap_4409 = Fn((V _arrowThis4436, int _argc4429, V S_4435, V _a4432, V _a4433, V _a4434, V[] _rest4430) => {
return Arr(Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_4435, "col"), ((V)("#ffffff")), ((V)(0.22))), NewObj(1).Put("op", ((V)(0.18))).V), Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4435, "col"), ((V)(0.88))), NewObj(1).Put("op", ((V)(0.13))).V));
}, 1, "", true);
Invoke(B_4408, "forEach", Fn((V _arrowThis4447, int _argc4437, V _a4439, V _a4440, V _a4441, V _a4442, V[] _rest4438) => {
double w_4448 = 0;
double h_4449 = 0;
double d_4450 = 0;
V S_4444 = default;
V L_4446 = default;
if (_a4439.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a4439));
{ V _t4443 = Get(_a4439, "S");
S_4444 = _t4443; }
{ V _t4445 = Get(_a4439, "L");
L_4446 = _t4445; }
w_4448 = (ToNum(GetIdx(L_4446, 1D)) - ToNum(GetIdx(L_4446, 0D)));
h_4449 = (ToNum(GetIdx(L_4446, 3D)) - ToNum(GetIdx(L_4446, 2D)));
d_4450 = (ToNum(GetIdx(L_4446, 5D)) - ToNum(GetIdx(L_4446, 4D)));
if (((((SEqN(li_4403, 2D) && ((ToNum(Get(Get(S_4444, "pts"), "length")) % 6D) == 0D)) && (w_4448 > 50D)) && (w_4448 < 60D)) && (d_4450 > 60D))) {
V D1_4451 = default;
V D2_4452 = default;
V WL_4453 = default;
V WS_4454 = default;
{ V _t4455 = Call(nap_4409, V.Undef, S_4444);
{ V _t4456 = ListOf(_t4455);
{ V _t4457 = GetIdx(_t4456, 0D);
D1_4451 = _t4457; }
{ V _t4458 = GetIdx(_t4456, 1D);
D2_4452 = _t4458; }
} }
WL_4453 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4444, "col"), ((V)(0.7))), NewObj(1).Put("op", ((V)(0.8))).V);
WS_4454 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4444, "col"), ((V)(0.55))), NewObj(1).Put("op", ((V)(0.4))).V);
Invoke(Call(caps_50, V.Undef, S_4444, ((V)(2D))), "forEach", Fn((V _arrowThis4466, int _argc4459, V F_4465, V _a4462, V _a4463, V _a4464, V[] _rest4460) => {
return Call(velvet_58, V.Undef, D1_4451, D2_4452, F_4465, R_4406, ((V)(4D)));
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, S_4444, ((V)(3D))), "forEach", Fn((V _arrowThis4474, int _argc4467, V F_4473, V _a4470, V _a4471, V _a4472, V[] _rest4468) => {
if (GtN(GetIdx(Get(F_4473, "n"), 2D), 0.7)) {
Call(velvet_58, V.Undef, D1_4451, D2_4452, F_4473, R_4406, ((V)(2D)));
}
return default;
}, 1, "", true));
Call(ringL_49, V.Undef, WL_4453, S_4444, ((V)(4D)), ((V)(6D)), ((V)(0.7)), ((V)(0.6)));
Call(ringL_49, V.Undef, WS_4454, S_4444, ((V)(3D)), ((V)(6D)), ((V)(0.4)), ((V)(0D)));
Call(on_4405, V.Undef, S_4444, Arr(D1_4451, D2_4452, WS_4454, WL_4453));
return default;
}
if (((SEqN(li_4403, 2D) && (System.Math.Abs((w_4448 - 24D)) < 3D)) && (System.Math.Abs((h_4449 - 24D)) < 3D))) {
V D1_4475 = default;
V D2_4476 = default;
V PG_4477 = default;
V TC_4478 = default;
double zf_4479 = 0;
{ V _t4480 = Call(nap_4409, V.Undef, S_4444);
{ V _t4481 = ListOf(_t4480);
{ V _t4482 = GetIdx(_t4481, 0D);
D1_4475 = _t4482; }
{ V _t4483 = GetIdx(_t4481, 1D);
D2_4476 = _t4483; }
} }
PG_4477 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4444, "col"), ((V)(0.68))), NewObj(1).Put("op", ((V)(0.85))).V);
TC_4478 = Call(shade_18, V.Undef, Get(S_4444, "col"), ((V)(0.82)));
Invoke(Call(caps_50, V.Undef, S_4444, ((V)(2D))), "forEach", Fn((V _arrowThis4491, int _argc4484, V F_4490, V _a4487, V _a4488, V _a4489, V[] _rest4485) => {
Call(velvet_58, V.Undef, D1_4475, D2_4476, F_4490, R_4406, ((V)(3D)));
Call(outline_47, V.Undef, PG_4477, F_4490, ((V)(0.95)), ((V)(0.55)));
return default;
}, 1, "", true));
Invoke(Call(caps_50, V.Undef, S_4444, ((V)(1D))), "forEach", Fn((V _arrowThis4499, int _argc4492, V F_4498, V _a4495, V _a4496, V _a4497, V[] _rest4493) => {
return Call(outline_47, V.Undef, PG_4477, F_4498, ((V)(0.95)), ((V)(0.55)));
}, 1, "", true));
zf_4479 = (ToNum(GetIdx(L_4446, 5D)) - 3D);
Invoke(Arr(Arr(Add(GetIdx(L_4446, 0D), ((V)(2D))), Add(GetIdx(L_4446, 2D), ((V)(2D))), ((V)(1D))), Arr(((V)((ToNum(GetIdx(L_4446, 1D)) - 2D))), Add(GetIdx(L_4446, 2D), ((V)(2D))), ((V)(1D))), Arr(Add(GetIdx(L_4446, 0D), ((V)(2.4))), ((V)((ToNum(GetIdx(L_4446, 3D)) - 2.4))), ((V)(0D))), Arr(((V)((ToNum(GetIdx(L_4446, 1D)) - 2.4))), ((V)((ToNum(GetIdx(L_4446, 3D)) - 2.4))), ((V)(0D)))), "forEach", Fn((V _arrowThis4513, int _argc4500, V _a4502, V _a4503, V _a4504, V _a4505, V[] _rest4501) => {
V T_4514 = default;
V x_4508 = default;
V y_4510 = default;
V tl_4512 = default;
{ V _t4506 = ListOf(_a4502);
{ V _t4507 = GetIdx(_t4506, 0D);
x_4508 = _t4507; }
{ V _t4509 = GetIdx(_t4506, 1D);
y_4510 = _t4509; }
{ V _t4511 = GetIdx(_t4506, 2D);
tl_4512 = _t4511; }
}
T_4514 = Arr(Call(ball_12, V.Undef, x_4508, y_4510, ((V)(zf_4479)), ((V)(1.1)), TC_4478, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V));
if (Truthy(tl_4512)) {
Invoke(T_4514, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("y"))).Put("sh", ((V)("el"))).Put("c", Arr(x_4508, ((V)(zf_4479)))).Put("a", ((V)(0.5))).Put("b", ((V)(0.5))).Put("n", ((V)(6D))).Put("rings", Arr(Arr(((V)((ToNum(y_4510) - 4.2))), ((V)(0D)), ((V)(1.4))), Arr(((V)((ToNum(y_4510) - 1.4))), ((V)(0D)), ((V)(0.8))), Arr(((V)((ToNum(y_4510) - 0.8))), ((V)(0D)), ((V)(0.5))))).Put("col", TC_4478).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V));
}
Call(on_4405, V.Undef, S_4444, T_4514, Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
Call(on_4405, V.Undef, S_4444, Arr(D1_4475, D2_4476, PG_4477));
return default;
}
if (((SEq(Get(S_4444, "col"), F0_4407) || SEq(Get(S_4444, "col"), Call(shade_18, V.Undef, F0_4407, ((V)(0.86))))) || SEq(Get(S_4444, "col"), Call(mix_19, V.Undef, F0_4407, ((V)("#ffffff")), ((V)(0.09)))))) {
V D1_4515 = default;
V D2_4516 = default;
{ V _t4517 = Call(nap_4409, V.Undef, S_4444);
{ V _t4518 = ListOf(_t4517);
{ V _t4519 = GetIdx(_t4518, 0D);
D1_4515 = _t4519; }
{ V _t4520 = GetIdx(_t4518, 1D);
D2_4516 = _t4520; }
} }
Invoke(Call(sides_51, V.Undef, S_4444, ((V)(6D))), "forEach", Fn((V _arrowThis4528, int _argc4521, V F_4527, V _a4524, V _a4525, V _a4526, V[] _rest4522) => {
if ((GtN(GetIdx(Get(F_4527, "n"), 1D), (-0.3)) && GtN(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(F_4527, "q"), 1D), GetIdx(Get(F_4527, "q"), 0D))).V), 6D))) {
Call(velvet_58, V.Undef, D1_4515, D2_4516, F_4527, R_4406, ((V)(2D)));
}
return default;
}, 1, "", true));
if (LtN(GetIdx(L_4446, 2D), 40D)) {
Invoke(Call(caps_50, V.Undef, S_4444, ((V)(2D))), "forEach", Fn((V _arrowThis4536, int _argc4529, V F_4535, V _a4532, V _a4533, V _a4534, V[] _rest4530) => {
return Call(velvet_58, V.Undef, D1_4515, D2_4516, F_4535, R_4406, ((V)(2D)));
}, 1, "", true));
}
Call(on_4405, V.Undef, S_4444, Arr(D1_4515, D2_4516));
}
return default;
}, 1, "", true));
if ((SEqN(li_4403, 1D) || SEqN(li_4403, 3D))) {
V rl_4537 = default;
rl_4537 = Invoke(B_4408, "find", Fn((V _arrowThis4545, int _argc4538, V b_4544, V _a4541, V _a4542, V _a4543, V[] _rest4539) => {
return (((SEq(Get(Get(b_4544, "S"), "col"), F0_4407) ? V.True : V.False) is var _t4546 && !Truthy(_t4546) ? _t4546 : Get(Call(caps_50, V.Undef, Get(b_4544, "S"), ((V)(2D))), "length")) is var _t4547 && !Truthy(_t4547) ? _t4547 : (GtN(GetIdx(Get(b_4544, "L"), 2D), 40D) ? V.True : V.False));
}, 1, "", true));
if (Truthy(rl_4537)) {
{
V PD_4548 = default;
V PL_4549 = default;
V BT_4550 = default;
PD_4548 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, F0_4407, ((V)(0.62))), NewObj(1).Put("op", ((V)(0.7))).V);
PL_4549 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, F0_4407, ((V)("#ffffff")), ((V)(0.25))), NewObj(1).Put("op", ((V)(0.4))).V);
BT_4550 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, F0_4407, ((V)(0.55))));
Invoke(Call(caps_50, V.Undef, Get(rl_4537, "S"), ((V)(2D))), "forEach", Fn((V _arrowThis4558, int _argc4551, V F_4557, V _a4554, V _a4555, V _a4556, V[] _rest4552) => {
V G_4559 = default;
V W_4560 = default;
V H_4561 = default;
G_4559 = Call(fr2_39, V.Undef, F_4557);
{ V _t4562 = Call(WH2_84, V.Undef, G_4559);
{ V _t4563 = ListOf(_t4562);
{ V _t4564 = GetIdx(_t4563, 0D);
W_4560 = _t4564; }
{ V _t4565 = GetIdx(_t4563, 1D);
H_4561 = _t4565; }
} }
Call(rep_29, V.Undef, ((V)(14D)), Fn((V _arrowThis4573, int _argc4566, V i_4572, V _a4569, V _a4570, V _a4571, V[] _rest4567) => {
double a_4574 = 0;
double cx_4575 = 0;
double cy_4576 = 0;
a_4574 = (((ToNum(i_4572) / 14D) * 2D) * PI_22);
cx_4575 = FdLibm.Cos(a_4574);
cy_4576 = FdLibm.Sin(a_4574);
Invoke(PD_4548, "line", Arr(Invoke(G_4559, "at", ((V)((cx_4575 * 1.4))), ((V)((cy_4576 * 1.4)))), Invoke(G_4559, "at", ((V)(((cx_4575 * ToNum(W_4560)) * 0.44))), ((V)(((cy_4576 * ToNum(H_4561)) * 0.44))))), Get(G_4559, "n"), ((V)(0.35)), ((V)(1D)));
Invoke(PL_4549, "line", Arr(Invoke(G_4559, "at", ((V)((FdLibm.Cos((a_4574 + 0.12)) * 1.6))), ((V)((FdLibm.Sin((a_4574 + 0.12)) * 1.6)))), Invoke(G_4559, "at", ((V)(((FdLibm.Cos((a_4574 + 0.12)) * ToNum(W_4560)) * 0.42))), ((V)(((FdLibm.Sin((a_4574 + 0.12)) * ToNum(H_4561)) * 0.42))))), Get(G_4559, "n"), ((V)(0.3)), ((V)(1D)));
return default;
}, 1, "", true));
Call(spot_25, V.Undef, BT_4550, Invoke(G_4559, "at", ((V)(0D)), ((V)(0D))), Get(G_4559, "n"), ((V)(1.5)), ((V)(1.5)), ((V)(0D)), ((V)(10D)));
return default;
}, 1, "", true));
Call(on_4405, V.Undef, Get(rl_4537, "S"), Arr(PD_4548, PL_4549, BT_4550));
}
if (SEqN(li_4403, 3D)) {
V L_4577 = default;
double x_4578 = 0;
double y_4579 = 0;
double z_4580 = 0;
double yw_4581 = 0;
double c_4582 = 0;
double s_4583 = 0;
V Pt_4584 = default;
V CV_4585 = default;
V PG1_4586 = default;
V TX_4587 = default;
V SP_4588 = default;
L_4577 = Get(rl_4537, "L");
x_4578 = (ToNum(Add(GetIdx(L_4577, 0D), GetIdx(L_4577, 1D))) / 2D);
y_4579 = (ToNum(GetIdx(L_4577, 3D)) - 0.15);
z_4580 = 6D;
yw_4581 = 0.35;
c_4582 = FdLibm.Cos(yw_4581);
s_4583 = FdLibm.Sin(yw_4581);
Pt_4584 = Fn((V _arrowThis4598, int _argc4589, V a_4595, V b_4596, V yy_4597, V _a4594, V[] _rest4590) => {
return Arr(((V)(((x_4578 + (ToNum(a_4595) * c_4582)) + (ToNum(b_4596) * s_4583)))), yy_4597, ((V)(((z_4580 - (ToNum(a_4595) * s_4583)) + (ToNum(b_4596) * c_4582)))));
}, 3, "", true);
CV_4585 = Call(box_13, V.Undef, ((V)(x_4578)), ((V)(y_4579)), ((V)(z_4580)), ((V)(13D)), ((V)(0.9)), ((V)(17D)), ((V)("#7a2a2a")), NewObj(3).Put("r", ((V)(0.4))).Put("yaw", ((V)(yw_4581))).Put("mat", ((V)("fab"))).V);
PG1_4586 = Call(box_13, V.Undef, ((V)(x_4578)), ((V)((y_4579 + 0.9))), ((V)(z_4580)), ((V)(12D)), ((V)(0.8)), ((V)(16D)), ((V)("#f4ecd8")), NewObj(3).Put("r", ((V)(0.3))).Put("yaw", ((V)(yw_4581))).Put("mat", ((V)("fab"))).V);
TX_4587 = Call(dec_24, V.Undef, ((V)("#8a8072")), NewObj(1).Put("op", ((V)(0.6))).V);
SP_4588 = Call(dec_24, V.Undef, ((V)("#c9bfa8")), NewObj(1).Put("op", ((V)(0.9))).V);
Invoke(SP_4588, "line", Arr(Call(Pt_4584, V.Undef, ((V)(0D)), ((V)((-8D))), ((V)((y_4579 + 1.75)))), Call(Pt_4584, V.Undef, ((V)(0D)), ((V)(8D)), ((V)((y_4579 + 1.75))))), Y3_37, ((V)(0.35)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis4606, int _argc4599, V sg_4605, V _a4602, V _a4603, V _a4604, V[] _rest4600) => {
return Call(rep_29, V.Undef, ((V)(7D)), Fn((V _arrowThis4614, int _argc4607, V i_4613, V _a4610, V _a4611, V _a4612, V[] _rest4608) => {
double b_4615 = 0;
b_4615 = ((-6D) + (ToNum(i_4613) * 1.9));
Invoke(TX_4587, "line", Arr(Call(Pt_4584, V.Undef, ((V)((ToNum(sg_4605) * 1.2))), ((V)(b_4615)), ((V)((y_4579 + 1.75)))), Call(Pt_4584, V.Undef, ((V)((ToNum(sg_4605) * (SEqN(i_4613, 6D) ? 3.5 : 5.2)))), ((V)(b_4615)), ((V)((y_4579 + 1.75))))), Y3_37, ((V)(0.28)));
return default;
}, 1, "", true));
}, 1, "", true));
Call(on_4405, V.Undef, Get(rl_4537, "S"), Arr(CV_4585, PG1_4586, TX_4587, SP_4588));
}
}
}
return default;
}, 3, "", true);
Set(N_21, "chester25V", Fn((V _arrowThis4623, int _argc4616, V S_4622, V _a4619, V _a4620, V _a4621, V[] _rest4617) => {
return Call(chesWrap_68, V.Undef, S_4622, velTex_94, leaBase_71);
}, 1, "", true));
foldTex_95 = Fn((V _arrowThis4632, int _argc4624, V o_4630, V P_4631, V _a4628, V _a4629, V[] _rest4625) => {
V on_4633 = default;
V R_4634 = default;
V B_4635 = default;
double feet_4636 = 0;
on_4633 = Call(glue_27, V.Undef, o_4630);
R_4634 = Call(R0_28, V.Undef, ((V)("fd25")));
B_4635 = Invoke(Invoke(o_4630, "filter", Fn((V _arrowThis4652, int _argc4645, V S_4651, V _a4648, V _a4649, V _a4650, V[] _rest4646) => {
return (((S_4651 is var _t4653 && !Truthy(_t4653) ? _t4653 : Get(S_4651, "pts")) is var _t4654 && !Truthy(_t4654) ? _t4654 : Get(Get(S_4651, "pts"), "length")) is var _t4655 && !Truthy(_t4655) ? _t4655 : (!(Truthy(Get(S_4651, "par"))) ? V.True : V.False));
}, 1, "", true)), "map", Fn((V _arrowThis4644, int _argc4637, V S_4643, V _a4640, V _a4641, V _a4642, V[] _rest4638) => {
return NewObj(2).Put("S", S_4643).Put("L", Call(bbS_38, V.Undef, S_4643)).V;
}, 1, "", true));
feet_4636 = 0D;
Invoke(B_4635, "forEach", Fn((V _arrowThis4666, int _argc4656, V _a4658, V _a4659, V _a4660, V _a4661, V[] _rest4657) => {
double w_4667 = 0;
double h_4668 = 0;
double d_4669 = 0;
V S_4663 = default;
V L_4665 = default;
if (_a4658.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a4658));
{ V _t4662 = Get(_a4658, "S");
S_4663 = _t4662; }
{ V _t4664 = Get(_a4658, "L");
L_4665 = _t4664; }
w_4667 = (ToNum(GetIdx(L_4665, 1D)) - ToNum(GetIdx(L_4665, 0D)));
h_4668 = (ToNum(GetIdx(L_4665, 3D)) - ToNum(GetIdx(L_4665, 2D)));
d_4669 = (ToNum(GetIdx(L_4665, 5D)) - ToNum(GetIdx(L_4665, 4D)));
if ((SEqS(Get(S_4663, "mat"), "wood") && (h_4668 < 5D))) {
V G1_4670 = default;
V G2_4671 = default;
V KN_4672 = default;
V SC_4673 = default;
V CV_4674 = default;
V WR_4675 = default;
G1_4670 = Call(dec_24, V.Undef, ((V)("#8e6a3e")), NewObj(1).Put("op", ((V)(0.5))).V);
G2_4671 = Call(dec_24, V.Undef, ((V)("#e2c08e")), NewObj(1).Put("op", ((V)(0.4))).V);
KN_4672 = Call(dec_24, V.Undef, ((V)("#6b4a26")), NewObj(1).Put("op", ((V)(0.7))).V);
SC_4673 = Call(dec_24, V.Undef, ((V)("#f2deb8")), NewObj(1).Put("op", ((V)(0.6))).V);
CV_4674 = Call(dec_24, V.Undef, ((V)("#5a3a1c")), NewObj(1).Put("op", ((V)(0.75))).V);
WR_4675 = Call(dec_24, V.Undef, ((V)("#7a5a34")), NewObj(1).Put("op", ((V)(0.35))).V);
Invoke(Get(S_4663, "faces"), "forEach", Fn((V _arrowThis4683, int _argc4676, V F_4682, V _a4679, V _a4680, V _a4681, V[] _rest4677) => {
if (Truthy(Call(bigF_82, V.Undef, F_4682, ((V)(6D))))) {
Call(grain_67, V.Undef, G1_4670, G2_4671, F_4682, R_4634, ((V)(1.1)), KN_4672);
}
return default;
}, 1, "", true));
Invoke(Invoke(Get(S_4663, "faces"), "filter", Fn((V _arrowThis4729, int _argc4722, V F_4728, V _a4725, V _a4726, V _a4727, V[] _rest4723) => {
return ((GtN(GetIdx(Get(F_4728, "n"), 1D), 0.9) ? V.True : V.False) is var _t4730 && !Truthy(_t4730) ? _t4730 : Call(bigF_82, V.Undef, F_4728, ((V)(200D))));
}, 1, "", true)), "forEach", Fn((V _arrowThis4691, int _argc4684, V F_4690, V _a4687, V _a4688, V _a4689, V[] _rest4685) => {
V G_4692 = default;
G_4692 = Call(fr2_39, V.Undef, F_4690);
Call(rep_29, V.Undef, ((V)(7D)), Fn((V _arrowThis4699, int _argc4693, V _a4695, V _a4696, V _a4697, V _a4698, V[] _rest4694) => {
double a_4700 = 0;
double b_4701 = 0;
double th_4702 = 0;
double l_4703 = 0;
a_4700 = ((ToNum(Call(R_4634, V.Undef)) - 0.5) * 30D);
b_4701 = ((ToNum(Call(R_4634, V.Undef)) - 0.5) * 28D);
th_4702 = (ToNum(Call(R_4634, V.Undef)) * PI_22);
l_4703 = (2D + (ToNum(Call(R_4634, V.Undef)) * 5D));
Invoke(SC_4673, "line", Arr(Invoke(G_4692, "at", ((V)(a_4700)), ((V)(b_4701))), Invoke(G_4692, "at", ((V)((a_4700 + (FdLibm.Cos(th_4702) * l_4703)))), ((V)((b_4701 + (FdLibm.Sin(th_4702) * l_4703)))))), Get(G_4692, "n"), ((V)(0.22)));
return default;
}, 0, "", true));
Invoke(CV_4674, "line", Call(rep_29, V.Undef, ((V)(17D)), Fn((V _arrowThis4711, int _argc4704, V i_4710, V _a4707, V _a4708, V _a4709, V[] _rest4705) => {
double t_4712 = 0;
t_4712 = (((ToNum(i_4710) / 16D) * 2D) * PI_22);
return Invoke(G_4692, "at", ((V)((10D + ((((1.8 * 16D) * Pow(FdLibm.Sin(t_4712), 3D)) / 16D) * 1.6)))), ((V)(((-10D) + ((((((13D * FdLibm.Cos(t_4712)) - (5D * FdLibm.Cos((2D * t_4712)))) - (2D * FdLibm.Cos((3D * t_4712)))) - FdLibm.Cos((4D * t_4712))) / 16D) * 2.6)))));
return default;
}, 1, "", true)), Get(G_4692, "n"), ((V)(0.3)));
Invoke(CV_4674, "line", Arr(Invoke(G_4692, "at", ((V)(7.4)), ((V)((-7.6)))), Invoke(G_4692, "at", ((V)(8.4)), ((V)((-7.6)))), Invoke(G_4692, "at", ((V)(7.9)), ((V)((-7.6)))), Invoke(G_4692, "at", ((V)(7.9)), ((V)((-6.2))))), Get(G_4692, "n"), ((V)(0.25)));
Invoke(CV_4674, "line", Arr(Invoke(G_4692, "at", ((V)(11.6)), ((V)((-6.2)))), Invoke(G_4692, "at", ((V)(11.6)), ((V)((-7.6)))), Invoke(G_4692, "at", ((V)(12.6)), ((V)((-7.6))))), Get(G_4692, "n"), ((V)(0.25)));
Invoke(WR_4675, "line", Call(rep_29, V.Undef, ((V)(21D)), Fn((V _arrowThis4720, int _argc4713, V i_4719, V _a4716, V _a4717, V _a4718, V[] _rest4714) => {
double t_4721 = 0;
t_4721 = ((((ToNum(i_4719) / 20D) * 2D) * PI_22) * 0.92);
return Invoke(G_4692, "at", ((V)(((-11D) + (FdLibm.Cos(t_4721) * 3D)))), ((V)(((-10D) + (FdLibm.Sin(t_4721) * 3D)))));
return default;
}, 1, "", true)), Get(G_4692, "n"), ((V)(0.45)));
return default;
}, 1, "", true));
Call(on_4633, V.Undef, S_4663, Arr(G1_4670, G2_4671, KN_4672, SC_4673, CV_4674, WR_4675));
return default;
}
if (SEqS(Get(S_4663, "mat"), "wood")) {
V CH_4731 = default;
V CG_4732 = default;
V PE_4733 = default;
V ST_4734 = default;
V SL_4735 = default;
V bf_4736 = default;
Set(S_4663, "col", ((V)("#4f8f8a")));
Set(S_4663, "mat", ((V)("paint")));
CH_4731 = Call(dec_24, V.Undef, ((V)("#c49a62")));
CG_4732 = Call(dec_24, V.Undef, ((V)("#8e6a3e")), NewObj(1).Put("op", ((V)(0.5))).V);
PE_4733 = Call(dec_24, V.Undef, ((V)("#3b6f6b")), NewObj(1).Put("op", ((V)(0.6))).V);
ST_4734 = Call(dec_24, V.Undef, ((V)("#f2c94c")));
SL_4735 = Call(dec_24, V.Undef, ((V)("#fff3b0")), NewObj(1).Put("op", ((V)(0.8))).V);
Invoke(Get(S_4663, "faces"), "forEach", Fn((V _arrowThis4744, int _argc4737, V F_4743, V _a4740, V _a4741, V _a4742, V[] _rest4738) => {
V G_4745 = default;
V P2_4746 = default;
V E_4747 = default;
if (!(Truthy(Call(bigF_82, V.Undef, F_4743, ((V)(40D)))))) {
return default;
}
G_4745 = Call(fr2_39, V.Undef, F_4743);
P2_4746 = Call(shrinkP_41, V.Undef, Get(G_4745, "P"), ((V)(0.86)));
E_4747 = Call(ext2_44, V.Undef, P2_4746);
Call(rep_29, V.Undef, ((V)(6D)), Fn((V _arrowThis4754, int _argc4748, V _a4750, V _a4751, V _a4752, V _a4753, V[] _rest4749) => {
V q_4755 = default;
double rx_4756 = 0;
double ry_4757 = 0;
double th_4758 = 0;
q_4755 = Arr(((V)((((ToNum(Call(R_4634, V.Undef)) - 0.5) * 2D) * ToNum(E_4747)))), ((V)((((ToNum(Call(R_4634, V.Undef)) - 0.5) * 2D) * ToNum(E_4747)))));
if (!(Truthy(Call(inP_43, V.Undef, P2_4746, q_4755)))) {
return default;
}
rx_4756 = (0.8 + (ToNum(Call(R_4634, V.Undef)) * 2.2));
ry_4757 = (0.5 + (ToNum(Call(R_4634, V.Undef)) * 1.1));
th_4758 = (ToNum(Call(R_4634, V.Undef)) * PI_22);
Call(spot_25, V.Undef, PE_4733, Invoke(G_4745, "at", GetIdx(q_4755, 0D), GetIdx(q_4755, 1D)), Get(G_4745, "n"), ((V)((rx_4756 + 0.35))), ((V)((ry_4757 + 0.35))), ((V)(th_4758)), ((V)(9D)));
Call(spot_25, V.Undef, CH_4731, Invoke(G_4745, "at", GetIdx(q_4755, 0D), GetIdx(q_4755, 1D)), Get(G_4745, "n"), ((V)(rx_4756)), ((V)(ry_4757)), ((V)(th_4758)), ((V)(9D)));
Invoke(CG_4732, "line", Arr(Invoke(G_4745, "at", ((V)((ToNum(GetIdx(q_4755, 0D)) - (rx_4756 * 0.7)))), GetIdx(q_4755, 1D)), Invoke(G_4745, "at", Add(GetIdx(q_4755, 0D), ((V)((rx_4756 * 0.7)))), GetIdx(q_4755, 1D))), Get(G_4745, "n"), ((V)(0.15)));
return default;
}, 0, "", true));
return default;
}, 1, "", true));
bf_4736 = GetIdx(Invoke(Get(S_4663, "faces"), "filter", Fn((V _arrowThis4766, int _argc4759, V F_4765, V _a4762, V _a4763, V _a4764, V[] _rest4760) => {
return ((GtN(GetIdx(Get(F_4765, "n"), 2D), 0.9) ? V.True : V.False) is var _t4767 && !Truthy(_t4767) ? _t4767 : Call(bigF_82, V.Undef, F_4765, ((V)(100D))));
}, 1, "", true)), 0D);
if (Truthy(bf_4736)) {
V G_4768 = default;
V c_4769 = default;
G_4768 = Call(fr2_39, V.Undef, bf_4736);
c_4769 = Arr(((V)(11D)), ((V)(2D)));
Invoke(ST_4734, "poly", Call(rep_29, V.Undef, ((V)(10D)), Fn((V _arrowThis4777, int _argc4770, V i_4776, V _a4773, V _a4774, V _a4775, V[] _rest4771) => {
double a_4778 = 0;
double r_4779 = 0;
a_4778 = (((-PI_22) / 2D) + (((ToNum(i_4776) / 10D) * 2D) * PI_22));
r_4779 = (NumTruthy((ToNum(i_4776) % 2D)) ? 1.1 : 2.6);
return Invoke(G_4768, "at", Add(GetIdx(c_4769, 0D), ((V)((FdLibm.Cos(a_4778) * r_4779)))), ((V)((ToNum(GetIdx(c_4769, 1D)) - (FdLibm.Sin(a_4778) * r_4779)))));
return default;
}, 1, "", true)), Get(G_4768, "n"));
Call(spot_25, V.Undef, SL_4735, Invoke(G_4768, "at", ((V)((ToNum(GetIdx(c_4769, 0D)) - 0.5))), Add(GetIdx(c_4769, 1D), ((V)(0.6)))), Get(G_4768, "n"), ((V)(0.6)), ((V)(0.4)), ((V)(0D)), ((V)(6D)));
}
Call(on_4633, V.Undef, S_4663, Arr(PE_4733, CH_4731, CG_4732, ST_4734, SL_4735));
return default;
}
if (SEqS(Get(S_4663, "mat"), "metal")) {
V RU_4780 = default;
V RL_4781 = default;
V SF_4782 = default;
RU_4780 = Call(dec_24, V.Undef, ((V)("#9a5a2e")), NewObj(1).Put("op", ((V)(0.55))).V);
RL_4781 = Call(dec_24, V.Undef, ((V)("#c9874a")), NewObj(1).Put("op", ((V)(0.45))).V);
SF_4782 = Call(dec_24, V.Undef, ((V)("#b9bec4")), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Call(sides_51, V.Undef, S_4663, ((V)(2D))), "forEach", Fn((V _arrowThis4790, int _argc4783, V F_4789, V _a4786, V _a4787, V _a4788, V[] _rest4784) => {
V G_4791 = default;
V W_4792 = default;
V H_4793 = default;
if ((!(Truthy(Call(bigF_82, V.Undef, F_4789, ((V)(3D))))) || LtN(Call(R_4634, V.Undef), 0.55))) {
return default;
}
G_4791 = Call(fr2_39, V.Undef, F_4789);
{ V _t4794 = Call(WH2_84, V.Undef, G_4791);
{ V _t4795 = ListOf(_t4794);
{ V _t4796 = GetIdx(_t4795, 0D);
W_4792 = _t4796; }
{ V _t4797 = GetIdx(_t4795, 1D);
H_4793 = _t4797; }
} }
Call(rep_29, V.Undef, ((V)(2D)), Fn((V _arrowThis4805, int _argc4798, V k_4804, V _a4801, V _a4802, V _a4803, V[] _rest4799) => {
double b_4806 = 0;
b_4806 = (((ToNum(Call(R_4634, V.Undef)) - 0.5) * ToNum(H_4793)) * 0.8);
Call(spot_25, V.Undef, (Truthy(k_4804) ? RL_4781 : RU_4780), Invoke(G_4791, "at", ((V)(0D)), ((V)(b_4806))), Get(G_4791, "n"), ((V)(Min((ToNum(W_4792) * 0.4), 0.5))), ((V)((0.6 + (ToNum(Call(R_4634, V.Undef)) * 1.2)))), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
if (LtN(Call(R_4634, V.Undef), 0.4)) {
Invoke(SF_4782, "line", Arr(Invoke(G_4791, "at", ((V)(0D)), ((V)(((-ToNum(H_4793)) * 0.3)))), Invoke(G_4791, "at", ((V)(0D)), ((V)((((-ToNum(H_4793)) * 0.3) + 2.4))))), Get(G_4791, "n"), ((V)(Min((ToNum(W_4792) * 0.3), 0.35))));
}
return default;
}, 1, "", true));
Call(on_4633, V.Undef, S_4663, Arr(RU_4780, RL_4781, SF_4782));
if (((LtN(GetIdx(L_4665, 2D), 0.5) && (w_4667 < 5D)) && (h_4668 > 30D))) {
feet_4636++;
if ((feet_4636 != 3D)) {
double cx_4807 = 0;
double cz_4808 = 0;
cx_4807 = (ToNum(Add(GetIdx(L_4665, 0D), GetIdx(L_4665, 1D))) / 2D);
cz_4808 = (ToNum(Add(GetIdx(L_4665, 4D), GetIdx(L_4665, 5D))) / 2D);
Call(on_4633, V.Undef, S_4663, Arr(Call(cyl_14, V.Undef, ((V)(cx_4807)), ((V)(0D)), ((V)(cz_4808)), ((V)(((w_4667 / 2D) + 0.45))), ((V)(1.8)), ((V)("#242428")), NewObj(2).Put("n", ((V)(8D))).Put("mat", ((V)("pl"))).V)));
}
}
if (((GtN(GetIdx(L_4665, 2D), 30D) && (w_4667 < 5D)) && (h_4668 > 30D))) {
double cx_4809 = 0;
double cz_4810 = 0;
V pc_4811 = default;
double sg_4812 = 0;
cx_4809 = (ToNum(Add(GetIdx(L_4665, 0D), GetIdx(L_4665, 1D))) / 2D);
cz_4810 = (ToNum(Add(GetIdx(L_4665, 4D), GetIdx(L_4665, 5D))) / 2D);
pc_4811 = Get(P_4631, "a");
sg_4812 = Sign(cx_4809);
Call(on_4633, V.Undef, S_4663, Arr(Call(ball_12, V.Undef, ((V)(cx_4809)), ((V)(43D)), ((V)((cz_4810 + 0.4))), ((V)(1.5)), pc_4811, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("mat", ((V)("fab"))).V), Call(ball_12, V.Undef, ((V)((cx_4809 - (sg_4812 * 0.4)))), ((V)(43.6)), ((V)((cz_4810 + 1.6))), ((V)(1.1)), pc_4811, NewObj(5).Put("sx", ((V)(1.5))).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("mat", ((V)("fab"))).V), Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("y"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((cx_4809 + (sg_4812 * 0.6)))), ((V)((cz_4810 + 1.4))))).Put("a", ((V)(0.45))).Put("b", ((V)(0.45))).Put("n", ((V)(6D))).Put("rings", Arr(Arr(((V)(37.5)), ((V)(0D)), ((V)(1D))), Arr(((V)(42.4)), ((V)(0D)), ((V)(1D))))).Put("col", Call(shade_18, V.Undef, pc_4811, ((V)(0.9)))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V)));
}
return default;
}
if (SEq(Get(S_4663, "col"), Get(P_4631, "a"))) {
V GW_4813 = default;
V GD_4814 = default;
V ED_4815 = default;
Set(S_4663, "col", ((V)("#c8393b")));
GW_4813 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_4663, "col"), ((V)("#ffffff")), ((V)(0.85))), NewObj(1).Put("op", ((V)(0.5))).V);
GD_4814 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4663, "col"), ((V)(0.7))), NewObj(1).Put("op", ((V)(0.35))).V);
ED_4815 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4663, "col"), ((V)(0.6))), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Get(S_4663, "faces"), "forEach", Fn((V _arrowThis4823, int _argc4816, V F_4822, V _a4819, V _a4820, V _a4821, V[] _rest4817) => {
if (!(Truthy(Call(bigF_82, V.Undef, F_4822, ((V)(3D)))))) {
return default;
}
Call(hatch_45, V.Undef, GW_4813, F_4822, ((V)(0D)), ((V)(3.4)), ((V)(1.5)), NewObj(1).Put("sh", ((V)(0.97))).V);
Call(hatch_45, V.Undef, GW_4813, F_4822, ((V)((PI_22 / 2D))), ((V)(3.4)), ((V)(1.5)), NewObj(1).Put("sh", ((V)(0.97))).V);
Call(hatch_45, V.Undef, GD_4814, F_4822, ((V)(0D)), ((V)(3.4)), ((V)(0.25)), NewObj(2).Put("sh", ((V)(0.97))).Put("ph", ((V)(1.7))).V);
return default;
}, 1, "", true));
Invoke(Call(caps_50, V.Undef, S_4663, ((V)(2D))), "forEach", Fn((V _arrowThis4831, int _argc4824, V F_4830, V _a4827, V _a4828, V _a4829, V[] _rest4825) => {
return Call(outline_47, V.Undef, ED_4815, F_4830, ((V)(0.95)), ((V)(0.4)));
}, 1, "", true));
Call(on_4633, V.Undef, S_4663, Arr(GW_4813, GD_4814, ED_4815));
}
return default;
}, 1, "", true));
return default;
}, 2, "", true);
Set(N_21, "fold25", Fn((V _arrowThis4839, int _argc4832, V S_4838, V _a4835, V _a4836, V _a4837, V[] _rest4833) => {
V B_4840 = default;
V D_4841 = default;
B_4840 = Invoke(N_21, "rchair", S_4838);
D_4841 = Object_assign(NewObj(0).V, B_4840);
Set(D_4841, "build", Fn((V _arrowThis4849, int _argc4842, V P_4848, V _a4845, V _a4846, V _a4847, V[] _rest4843) => {
V o_4850 = default;
o_4850 = Invoke(B_4840, "build", P_4848);
Call(foldTex_95, V.Undef, o_4850, P_4848);
return o_4850;
return default;
}, 1, "", true));
return D_4841;
return default;
}, 1, "", true));
wingGlue_96 = Fn((V _arrowThis4859, int _argc4851, V o_4857, V col_4858, V _a4855, V _a4856, V[] _rest4852) => {
V B_4860 = default;
B_4860 = Invoke(Invoke(Invoke(o_4857, "filter", Fn((V _arrowThis4884, int _argc4877, V S_4883, V _a4880, V _a4881, V _a4882, V[] _rest4878) => {
return ((S_4883 is var _t4885 && !Truthy(_t4885) ? _t4885 : Get(S_4883, "pts")) is var _t4886 && !Truthy(_t4886) ? _t4886 : Get(Get(S_4883, "pts"), "length"));
}, 1, "", true)), "map", Fn((V _arrowThis4876, int _argc4869, V S_4875, V _a4872, V _a4873, V _a4874, V[] _rest4870) => {
return NewObj(2).Put("S", S_4875).Put("L", Call(bbS_38, V.Undef, S_4875)).V;
}, 1, "", true)), "filter", Fn((V _arrowThis4868, int _argc4861, V b_4867, V _a4864, V _a4865, V _a4866, V[] _rest4862) => {
return (!(Truthy(Get(Get(b_4867, "S"), "par"))) ? V.True : V.False);
}, 1, "", true));
Invoke(Invoke(B_4860, "filter", Fn((V _arrowThis4911, int _argc4904, V b_4910, V _a4907, V _a4908, V _a4909, V[] _rest4905) => {
return (((SEq(Get(Get(b_4910, "S"), "col"), col_4858) && GtN(GetIdx(Get(b_4910, "L"), 2D), 50D)) && ((ToNum(GetIdx(Get(b_4910, "L"), 1D)) - ToNum(GetIdx(Get(b_4910, "L"), 0D))) < 26D)) ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis4894, int _argc4887, V w_4893, V _a4890, V _a4891, V _a4892, V[] _rest4888) => {
V r_4895 = default;
r_4895 = Invoke(B_4860, "find", Fn((V _arrowThis4903, int _argc4896, V b_4902, V _a4899, V _a4900, V _a4901, V[] _rest4897) => {
return ((((!SEq(b_4902, w_4893) && SEq(Get(Get(b_4902, "S"), "col"), col_4858)) && (System.Math.Abs((ToNum(GetIdx(Get(b_4902, "L"), 3D)) - ToNum(GetIdx(Get(w_4893, "L"), 2D)))) < 1.5)) && (Sign(ToNum(Add(GetIdx(Get(b_4902, "L"), 0D), GetIdx(Get(b_4902, "L"), 1D)))) == Sign(ToNum(Add(GetIdx(Get(w_4893, "L"), 0D), GetIdx(Get(w_4893, "L"), 1D)))))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(r_4895)) {
Set(Get(w_4893, "S"), "par", Get(r_4895, "S"));
}
return default;
}, 1, "", true));
return default;
}, 2, "", true);
wingTex_97 = Fn((V _arrowThis4921, int _argc4912, V o_4918, V P_4919, V li_4920, V _a4917, V[] _rest4913) => {
V on_4922 = default;
V R_4923 = default;
V B_4924 = default;
V legC_4925 = default;
V mc_4926 = default;
V WAL_4927 = default;
Call(thrFix_65, V.Undef, o_4918, P_4919);
on_4922 = Call(glue_27, V.Undef, o_4918);
R_4923 = Call(R0_28, V.Undef, ((V)(JsStrBuf.Begin().S("wg25").V((li_4920.IsNullish ? ((V)("m")) : li_4920)).End())));
B_4924 = Call(roles_80, V.Undef, o_4918, P_4919);
legC_4925 = Get((Invoke(B_4924, "find", Fn((V _arrowThis4935, int _argc4928, V b_4934, V _a4931, V _a4932, V _a4933, V[] _rest4929) => {
return (SEqS(Get(b_4934, "r"), "leg") ? V.True : V.False);
}, 1, "", true)) is var _t4936 && Truthy(_t4936) ? _t4936 : NewObj(0).V), "S");
mc_4926 = (Truthy(legC_4925) ? Get(legC_4925, "col") : V.Null);
WAL_4927 = ((V)("#6b4426"));
Invoke(B_4924, "forEach", Fn((V _arrowThis4949, int _argc4937, V _a4939, V _a4940, V _a4941, V _a4942, V[] _rest4938) => {
V W1_4950 = default;
V W2_4951 = default;
V F1_4952 = default;
V F2_4953 = default;
V F3_4954 = default;
V WL_4955 = default;
V Ls_4956 = default;
V S_4944 = default;
V L_4946 = default;
V r_4948 = default;
if (_a4939.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a4939));
{ V _t4943 = Get(_a4939, "S");
S_4944 = _t4943; }
{ V _t4945 = Get(_a4939, "L");
L_4946 = _t4945; }
{ V _t4947 = Get(_a4939, "r");
r_4948 = _t4947; }
if ((SEqS(r_4948, "leg") || SEqS(r_4948, "rail"))) {
V G1_4957 = default;
V G2_4958 = default;
Set(S_4944, "col", WAL_4927);
Set(S_4944, "mat", ((V)("wood")));
Set(S_4944, "shine", ((V)(0D)));
G1_4957 = Call(dec_24, V.Undef, ((V)("#3e2614")), NewObj(1).Put("op", ((V)(0.5))).V);
G2_4958 = Call(dec_24, V.Undef, ((V)("#9a6a42")), NewObj(1).Put("op", ((V)(0.4))).V);
Invoke(Get(S_4944, "faces"), "forEach", Fn((V _arrowThis4966, int _argc4959, V F_4965, V _a4962, V _a4963, V _a4964, V[] _rest4960) => {
if (Truthy((Call(bigF_82, V.Undef, F_4965, ((V)((SEqS(r_4948, "rail") ? 10D : 2D)))) is var _t4967 && !Truthy(_t4967) ? _t4967 : ((System.Math.Abs(ToNum(GetIdx(Get(F_4965, "n"), 1D))) < 0.5) ? V.True : V.False)))) {
Call(grain_67, V.Undef, G1_4957, G2_4958, F_4965, R_4923, ((V)((SEqS(r_4948, "rail") ? 0.9 : 0.7))));
}
return default;
}, 1, "", true));
Call(on_4922, V.Undef, S_4944, Arr(G1_4957, G2_4958));
if (SEqS(r_4948, "leg")) {
double cx_4968 = 0;
double cz_4969 = 0;
cx_4968 = (ToNum(Add(GetIdx(L_4946, 0D), GetIdx(L_4946, 1D))) / 2D);
cz_4969 = (ToNum(Add(GetIdx(L_4946, 4D), GetIdx(L_4946, 5D))) / 2D);
Call(on_4922, V.Undef, S_4944, Arr(Call(cyl_14, V.Undef, ((V)(cx_4968)), ((V)((-0.3))), ((V)(cz_4969)), ((V)(((ToNum(GetIdx(L_4946, 1D)) - ToNum(GetIdx(L_4946, 0D))) * 0.36))), ((V)(2.2)), ((V)("#d9a84a")), NewObj(3).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).Put("mat", ((V)("metal"))).V)));
}
return default;
}
if (!(Truthy(GetK(UPH_81, r_4948)))) {
return default;
}
W1_4950 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S_4944, "col"), ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.28))).V);
W2_4951 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4944, "col"), ((V)(0.78))), NewObj(1).Put("op", ((V)(0.3))).V);
F1_4952 = Call(dec_24, V.Undef, ((V)("#a04a2a")), NewObj(1).Put("op", ((V)(0.32))).V);
F2_4953 = Call(dec_24, V.Undef, ((V)("#fff3d6")), NewObj(1).Put("op", ((V)(0.35))).V);
F3_4954 = Call(dec_24, V.Undef, ((V)("#6a6a2a")), NewObj(1).Put("op", ((V)(0.28))).V);
WL_4955 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4944, "col"), ((V)(0.7))), NewObj(1).Put("op", ((V)(0.75))).V);
Ls_4956 = Arr(W1_4950, W2_4951, F1_4952, F2_4953, F3_4954, WL_4955);
Invoke(Get(S_4944, "faces"), "forEach", Fn((V _arrowThis4977, int _argc4970, V F_4976, V _a4973, V _a4974, V _a4975, V[] _rest4971) => {
if (!(Truthy(Call(bigF_82, V.Undef, F_4976, ((V)(6D)))))) {
return default;
}
Call(hatch_45, V.Undef, W1_4950, F_4976, ((V)((PI_22 / 4D))), ((V)(1.2)), ((V)(0.22)), NewObj(1).Put("sh", ((V)(0.98))).V);
Call(hatch_45, V.Undef, W2_4951, F_4976, ((V)(((-PI_22) / 4D))), ((V)(1.2)), ((V)(0.22)), NewObj(1).Put("sh", ((V)(0.98))).V);
Call(fleck_83, V.Undef, F1_4952, F2_4953, F_4976, R_4923, ((V)(0.05)), ((V)(0.22)));
Call(fleck_83, V.Undef, F3_4954, F2_4953, F_4976, R_4923, ((V)(0.03)), ((V)(0.2)));
return default;
}, 1, "", true));
if (SEqS(r_4948, "seat")) {
V CR_4978 = default;
Call(ringL_49, V.Undef, WL_4955, S_4944, ((V)(4D)), ((V)(6D)), ((V)(0.55)), ((V)(0.6)));
CR_4978 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S_4944, "col"), ((V)(0.82))), NewObj(1).Put("op", ((V)(0.22))).V);
Invoke(Call(caps_50, V.Undef, S_4944, ((V)(2D))), "forEach", Fn((V _arrowThis4986, int _argc4979, V F_4985, V _a4982, V _a4983, V _a4984, V[] _rest4980) => {
return Call(crease_85, V.Undef, CR_4978, F_4985, R_4923, ((V)(2D)), ((V)(26D)), ((V)(26D)), ((V)(6D)));
}, 1, "", true));
Invoke(Ls_4956, "push", CR_4978);
}
if ((SEqS(r_4948, "back") && ((ToNum(Get(Get(S_4944, "pts"), "length")) % 5D) == 0D))) {
Call(ringL_49, V.Undef, WL_4955, S_4944, ((V)(3D)), ((V)(5D)), ((V)(0.55)), ((V)(0D)));
}
if ((SEqS(r_4948, "roll") && ((ToNum(Get(Get(S_4944, "pts"), "length")) % 4D) == 0D))) {
Call(ringL_49, V.Undef, WL_4955, S_4944, ((V)(0D)), ((V)(4D)), ((V)(0.45)), ((V)(0D)));
Call(ringL_49, V.Undef, WL_4955, S_4944, ((V)(3D)), ((V)(4D)), ((V)(0.45)), ((V)(0D)));
}
if ((SEqS(r_4948, "slab") && ((ToNum(GetIdx(L_4946, 1D)) - ToNum(GetIdx(L_4946, 0D))) < 30D))) {
Invoke(Get(S_4944, "faces"), "forEach", Fn((V _arrowThis4994, int _argc4987, V F_4993, V _a4990, V _a4991, V _a4992, V[] _rest4988) => {
if (Truthy((Get(F_4993, "cap") is var _t4995 && !Truthy(_t4995) ? _t4995 : ((System.Math.Abs(ToNum(GetIdx(Get(F_4993, "n"), 2D))) > 0.8) ? V.True : V.False)))) {
Call(outline_47, V.Undef, WL_4955, F_4993, ((V)(0.94)), ((V)(0.5)));
}
return default;
}, 1, "", true));
}
Call(on_4922, V.Undef, S_4944, Ls_4956);
return default;
}, 1, "", true));
Invoke(o_4918, "forEach", Fn((V _arrowThis5003, int _argc4996, V S_5002, V _a4999, V _a5000, V _a5001, V[] _rest4997) => {
if (Truthy(((((S_5002 is var _t5004 && !Truthy(_t5004) ? _t5004 : Get(S_5002, "par")) is var _t5005 && !Truthy(_t5005) ? _t5005 : (!(Truthy(Get(S_5002, "emit"))) ? V.True : V.False)) is var _t5006 && !Truthy(_t5006) ? _t5006 : (SEqS(Get(S_5002, "mat"), "metal") ? V.True : V.False)) is var _t5007 && !Truthy(_t5007) ? _t5007 : (SEq(Get(S_5002, "col"), mc_4926) ? V.True : V.False)))) {
Set(S_5002, "col", Call(shade_18, V.Undef, WAL_4927, ((V)(1.1))));
Set(S_5002, "mat", ((V)("wood")));
Set(S_5002, "shine", ((V)(0D)));
}
return default;
}, 1, "", true));
if (li_4920.IsNullish) {
Call(armThrow_89, V.Undef, o_4918, B_4924, ((V)(1D)), ((V)("#a24a2c")), ((V)(1D)));
}
Call(wingGlue_96, V.Undef, o_4918, Get(P_4919, "a"));
return default;
}, 3, "", true);
Set(N_21, "wing25", Fn((V _arrowThis5015, int _argc5008, V S_5014, V _a5011, V _a5012, V _a5013, V[] _rest5009) => {
return Call(rsWrap_90, V.Undef, S_5014, wingTex_97);
}, 1, "", true));
{
V rs0_5016 = default;
rs0_5016 = Get(N_21, "rsofa");
Set(N_21, "rsofa", Fn((V _arrowThis5024, int _argc5017, V S_5023, V _a5020, V _a5021, V _a5022, V[] _rest5018) => {
V D_5025 = default;
D_5025 = Call(rs0_5016, V.Undef, S_5023);
if (Truthy((Get(D_5025, "layers") is var _t5026 && !Truthy(_t5026) ? _t5026 : (SEqN(Get(Get(D_5025, "layers"), "length"), 1D) ? V.True : V.False)))) {
Set(D_5025, "layers", Call(splitL_54, V.Undef, D_5025));
}
return D_5025;
return default;
}, 1, "", true));
}
cylPt_98 = Fn((V _arrowThis5039, int _argc5027, V cx_5033, V cz_5034, V r_5035, V a_5036, V[] _rest5028) => {
V y_5037 = default;
V k_5038 = default;
y_5037 = (_argc5027 > 4 ? _rest5028[0] : V.Undef);
k_5038 = (_argc5027 > 5 ? _rest5028[1] : V.Undef);
return Arr(Arr(Add(cx_5033, ((V)((FdLibm.Cos(ToNum(a_5036)) * ToNum(Add(r_5035, (k_5038 is var _t5040 && Truthy(_t5040) ? _t5040 : ((V)(0.06))))))))), y_5037, Add(cz_5034, ((V)((FdLibm.Sin(ToNum(a_5036)) * ToNum(Add(r_5035, (k_5038 is var _t5041 && Truthy(_t5041) ? _t5041 : ((V)(0.06)))))))))), Arr(((V)(FdLibm.Cos(ToNum(a_5036)))), ((V)(0D)), ((V)(FdLibm.Sin(ToNum(a_5036))))));
}, 6, "", true);
ringD_99 = Fn((V _arrowThis5057, int _argc5042, V D_5048, V cx_5049, V cz_5050, V r_5051, V[] _rest5043) => {
V A_5058 = default;
V B2_5059 = default;
V pts_5060 = default;
V nn_5061 = default;
V y_5052 = default;
V w_5053 = default;
V m_5054 = default;
V a0_5055 = default;
V a1_5056 = default;
y_5052 = (_argc5042 > 4 ? _rest5043[0] : V.Undef);
w_5053 = (_argc5042 > 5 ? _rest5043[1] : V.Undef);
m_5054 = (_argc5042 > 6 ? _rest5043[2] : V.Undef);
a0_5055 = (_argc5042 > 7 ? _rest5043[3] : V.Undef);
a1_5056 = (_argc5042 > 8 ? _rest5043[4] : V.Undef);
m_5054 = (m_5054 is var _t5062 && Truthy(_t5062) ? _t5062 : ((V)(28D)));
A_5058 = (a0_5055.IsNullish ? ((V)(0D)) : a0_5055);
B2_5059 = (a1_5056.IsNullish ? ((V)((2D * PI_22))) : a1_5056);
pts_5060 = Arr();
nn_5061 = Arr();
Call(rep_29, V.Undef, Add(m_5054, ((V)(1D))), Fn((V _arrowThis5070, int _argc5063, V i_5069, V _a5066, V _a5067, V _a5068, V[] _rest5064) => {
V p_5071 = default;
V n_5072 = default;
{ V _t5073 = Call(cylPt_98, V.Undef, cx_5049, cz_5050, r_5051, Add(A_5058, ((V)((((ToNum(B2_5059) - ToNum(A_5058)) * ToNum(i_5069)) / ToNum(m_5054))))), y_5052);
{ V _t5074 = ListOf(_t5073);
{ V _t5075 = GetIdx(_t5074, 0D);
p_5071 = _t5075; }
{ V _t5076 = GetIdx(_t5074, 1D);
n_5072 = _t5076; }
} }
Invoke(pts_5060, "push", p_5071);
Invoke(nn_5061, "push", n_5072);
return default;
}, 1, "", true));
Invoke(D_5048, "line", pts_5060, nn_5061, w_5053);
return default;
}, 9, "", true);
Set(N_21, "box25", Fn((V _arrowThis5084, int _argc5077, V S_5083, V _a5080, V _a5081, V _a5082, V[] _rest5078) => {
return NewObj(3).Put("w", ((V)(60D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis5092, int _argc5085, V P_5091, V _a5088, V _a5089, V _a5090, V[] _rest5086) => {
V CB_5093 = default;
V o_5094 = default;
V on_5095 = default;
V R_5096 = default;
double W_5097 = 0;
double H_5098 = 0;
double Dz_5099 = 0;
double E_5100 = 0;
V BX_5101 = default;
V BF_5102 = default;
V BN_5103 = default;
V fp_5104 = default;
V fl_5105 = default;
V FLU_5106 = default;
V FLL_5107 = default;
V SEAM_5108 = default;
V FOLD_5109 = default;
V TP_5110 = default;
V TL_5111 = default;
V TD_5112 = default;
V tape_5113 = default;
V DN_5114 = default;
V DC_5115 = default;
V INK_5116 = default;
V LB_5117 = default;
V BC_5118 = default;
V LT_5119 = default;
V LR_5120 = default;
double bx_5121 = 0;
V HO_5122 = default;
V HR_5123 = default;
V FR_5124 = default;
V MK_5125 = default;
V WS_5126 = default;
V CF_5127 = default;
V FC_5128 = default;
V BL_5129 = default;
V FW_5130 = default;
V FD_5131 = default;
V RM_5132 = default;
V RB_5133 = default;
V RG_5134 = default;
CB_5093 = ((V)("#c49a62"));
o_5094 = Arr();
on_5095 = Call(glue_27, V.Undef, o_5094);
R_5096 = Call(R0_28, V.Undef, ((V)("bx25")));
W_5097 = 28D;
H_5098 = 28D;
Dz_5099 = 21D;
E_5100 = 0.07;
BX_5101 = Call(box_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(56D)), ((V)(H_5098)), ((V)(42D)), CB_5093, NewObj(1).Put("r", ((V)(1D))).V);
Invoke(o_5094, "push", BX_5101);
BF_5102 = NewObj(5).Put("f", Fn((V _arrowThis5143, int _argc5135, V u_5141, V v_5142, V _a5139, V _a5140, V[] _rest5136) => {
return Arr(u_5141, v_5142, ((V)((Dz_5099 + E_5100))));
}, 2, "f", true)).Put("b", Fn((V _arrowThis5152, int _argc5144, V u_5150, V v_5151, V _a5148, V _a5149, V[] _rest5145) => {
return Arr(((V)((-ToNum(u_5150)))), v_5151, ((V)(((-Dz_5099) - E_5100))));
}, 2, "b", true)).Put("r", Fn((V _arrowThis5161, int _argc5153, V u_5159, V v_5160, V _a5157, V _a5158, V[] _rest5154) => {
return Arr(((V)((W_5097 + E_5100))), v_5160, ((V)((-ToNum(u_5159)))));
}, 2, "r", true)).Put("l", Fn((V _arrowThis5170, int _argc5162, V u_5168, V v_5169, V _a5166, V _a5167, V[] _rest5163) => {
return Arr(((V)(((-W_5097) - E_5100))), v_5169, u_5168);
}, 2, "l", true)).Put("t", Fn((V _arrowThis5179, int _argc5171, V u_5177, V w_5178, V _a5175, V _a5176, V[] _rest5172) => {
return Arr(u_5177, ((V)((H_5098 + E_5100))), w_5178);
}, 2, "t", true)).V;
BN_5103 = NewObj(5).Put("f", Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))).Put("b", Arr(((V)(0D)), ((V)(0D)), ((V)((-1D))))).Put("r", Arr(((V)(1D)), ((V)(0D)), ((V)(0D)))).Put("l", Arr(((V)((-1D))), ((V)(0D)), ((V)(0D)))).Put("t", Arr(((V)(0D)), ((V)(1D)), ((V)(0D)))).V;
fp_5104 = Fn((V _arrowThis5189, int _argc5180, V D_5186, V s_5187, V Q_5188, V _a5185, V[] _rest5181) => {
return Invoke(D_5186, "poly", Invoke(Q_5188, "map", Fn((V _arrowThis5197, int _argc5190, V q_5196, V _a5193, V _a5194, V _a5195, V[] _rest5191) => {
return InvokeK(BF_5102, s_5187, GetIdx(q_5196, 0D), GetIdx(q_5196, 1D));
}, 1, "", true)), GetK(BN_5103, s_5187));
}, 3, "", true);
fl_5105 = Fn((V _arrowThis5209, int _argc5198, V D_5204, V s_5205, V Q_5206, V w_5207, V[] _rest5199) => {
V tp_5208 = default;
tp_5208 = (_argc5198 > 4 ? _rest5199[0] : V.Undef);
return Invoke(D_5204, "line", Invoke(Q_5206, "map", Fn((V _arrowThis5217, int _argc5210, V q_5216, V _a5213, V _a5214, V _a5215, V[] _rest5211) => {
return InvokeK(BF_5102, s_5205, GetIdx(q_5216, 0D), GetIdx(q_5216, 1D));
}, 1, "", true)), GetK(BN_5103, s_5205), w_5207, tp_5208);
}, 5, "", true);
FLU_5106 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, CB_5093, ((V)(0.86))), NewObj(1).Put("op", ((V)(0.35))).V);
FLL_5107 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, CB_5093, ((V)("#ffffff")), ((V)(0.25))), NewObj(1).Put("op", ((V)(0.25))).V);
Invoke(Get(BX_5101, "faces"), "forEach", Fn((V _arrowThis5225, int _argc5218, V F_5224, V _a5221, V _a5222, V _a5223, V[] _rest5219) => {
if (Truthy(((Get(F_5224, "cap") is var _t5226 && Truthy(_t5226) ? _t5226 : ((System.Math.Abs(ToNum(GetIdx(Get(F_5224, "n"), 1D))) > 0.5) ? V.True : V.False)) is var _t5227 && Truthy(_t5227) ? _t5227 : (!(Truthy(Call(bigF_82, V.Undef, F_5224, ((V)(60D))))) ? V.True : V.False)))) {
return default;
}
Call(hatch_45, V.Undef, Arr(FLU_5106, FLL_5107), F_5224, ((V)((PI_22 / 2D))), ((V)(1.1)), ((V)(0.18)), NewObj(1).Put("sh", ((V)(0.99))).V);
return default;
}, 1, "", true));
SEAM_5108 = Call(dec_24, V.Undef, ((V)("#6b4a26")), NewObj(1).Put("op", ((V)(0.75))).V);
FOLD_5109 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, CB_5093, ((V)(0.8))), NewObj(1).Put("op", ((V)(0.6))).V);
Call(fl_5105, V.Undef, SEAM_5108, ((V)("t")), Arr(Arr(((V)((-27D))), ((V)(0D))), Arr(((V)(27D)), ((V)(0D)))), ((V)(0.5)));
Invoke(Arr(Arr(((V)("f")), ((V)(20D))), Arr(((V)("b")), ((V)(20D))), Arr(((V)("r")), ((V)(15D))), Arr(((V)("l")), ((V)(15D)))), "forEach", Fn((V _arrowThis5239, int _argc5228, V _a5230, V _a5231, V _a5232, V _a5233, V[] _rest5229) => {
V s_5236 = default;
V a_5238 = default;
{ V _t5234 = ListOf(_a5230);
{ V _t5235 = GetIdx(_t5234, 0D);
s_5236 = _t5235; }
{ V _t5237 = GetIdx(_t5234, 1D);
a_5238 = _t5237; }
}
return Call(fl_5105, V.Undef, FOLD_5109, s_5236, Arr(Arr(((V)(((-ToNum(a_5238)) - 6D))), ((V)(26.6))), Arr(Add(a_5238, ((V)(6D))), ((V)(26.6)))), ((V)(0.3)));
}, 1, "", true));
TP_5110 = Call(dec_24, V.Undef, ((V)("#aeb4ba")));
TL_5111 = Call(dec_24, V.Undef, ((V)("#e6ebee")), NewObj(1).Put("op", ((V)(0.6))).V);
TD_5112 = Call(dec_24, V.Undef, ((V)("#6f767c")), NewObj(1).Put("op", ((V)(0.55))).V);
tape_5113 = Fn((V _arrowThis5249, int _argc5240, V s_5246, V Q_5247, V cr_5248, V _a5245, V[] _rest5241) => {
V a_5250 = default;
V b_5251 = default;
V c_5252 = default;
V d_5253 = default;
Call(fp_5104, V.Undef, TP_5110, s_5246, Q_5247);
{ V _t5254 = Q_5247;
{ V _t5255 = ListOf(_t5254);
{ V _t5256 = GetIdx(_t5255, 0D);
a_5250 = _t5256; }
{ V _t5257 = GetIdx(_t5255, 1D);
b_5251 = _t5257; }
{ V _t5258 = GetIdx(_t5255, 2D);
c_5252 = _t5258; }
{ V _t5259 = GetIdx(_t5255, 3D);
d_5253 = _t5259; }
} }
Call(rep_29, V.Undef, cr_5248, Fn((V _arrowThis5267, int _argc5260, V i_5266, V _a5263, V _a5264, V _a5265, V[] _rest5261) => {
double t_5268 = 0;
V p0_5269 = default;
V p1_5270 = default;
t_5268 = (ToNum(Add(i_5266, ((V)(0.5)))) / ToNum(cr_5248));
p0_5269 = Arr(Add(GetIdx(a_5250, 0D), ((V)(((ToNum(GetIdx(b_5251, 0D)) - ToNum(GetIdx(a_5250, 0D))) * t_5268)))), Add(GetIdx(a_5250, 1D), ((V)(((ToNum(GetIdx(b_5251, 1D)) - ToNum(GetIdx(a_5250, 1D))) * t_5268)))));
p1_5270 = Arr(Add(GetIdx(d_5253, 0D), ((V)(((ToNum(GetIdx(c_5252, 0D)) - ToNum(GetIdx(d_5253, 0D))) * t_5268)))), Add(GetIdx(d_5253, 1D), ((V)(((ToNum(GetIdx(c_5252, 1D)) - ToNum(GetIdx(d_5253, 1D))) * t_5268)))));
Call(fl_5105, V.Undef, (NumTruthy((ToNum(i_5266) % 2D)) ? TL_5111 : TD_5112), s_5246, Arr(p0_5269, Arr(((V)(((ToNum(Add(GetIdx(p0_5269, 0D), GetIdx(p1_5270, 0D))) / 2D) + ((ToNum(Call(R_5096, V.Undef)) - 0.5) * 0.8)))), ((V)((ToNum(Add(GetIdx(p0_5269, 1D), GetIdx(p1_5270, 1D))) / 2D)))), p1_5270), ((V)(0.14)));
return default;
}, 1, "", true));
Call(fl_5105, V.Undef, TL_5111, s_5246, Arr(d_5253, c_5252), ((V)(0.22)));
return default;
}, 3, "", true);
Call(tape_5113, V.Undef, ((V)("t")), Arr(Arr(((V)((-28D))), ((V)((-2.7)))), Arr(((V)(28D)), ((V)((-2.7)))), Arr(((V)(28D)), ((V)(2.7))), Arr(((V)((-28D))), ((V)(2.7)))), ((V)(46D)));
Call(tape_5113, V.Undef, ((V)("r")), Invoke(Invoke(Arr(Arr(((V)((-2.7))), ((V)(28D))), Arr(((V)(2.7)), ((V)(28D))), Arr(((V)(2.7)), ((V)(19.5))), Arr(((V)(1.3)), ((V)(20.6))), Arr(((V)(0D)), ((V)(19D))), Arr(((V)((-1.4))), ((V)(20.4))), Arr(((V)((-2.7))), ((V)(19.2)))), "slice", ((V)(0D)), ((V)(4D))), "concat", Arr()), ((V)(6D)));
Call(fp_5104, V.Undef, TP_5110, ((V)("r")), Arr(Arr(((V)(2.7)), ((V)(19.5))), Arr(((V)(1.3)), ((V)(20.6))), Arr(((V)(0D)), ((V)(19D))), Arr(((V)((-1.4))), ((V)(20.4))), Arr(((V)((-2.7))), ((V)(19.2))), Arr(((V)((-2.7))), ((V)(21D))), Arr(((V)(2.7)), ((V)(21D)))));
Call(tape_5113, V.Undef, ((V)("l")), Arr(Arr(((V)((-2.7))), ((V)(28D))), Arr(((V)(2.7)), ((V)(28D))), Arr(((V)(2.7)), ((V)(20D))), Arr(((V)((-2.7))), ((V)(20D)))), ((V)(6D)));
Call(fp_5104, V.Undef, TP_5110, ((V)("l")), Arr(Arr(((V)(2.7)), ((V)(20D))), Arr(((V)(1.6)), ((V)(18.8))), Arr(((V)(0.2)), ((V)(20.2))), Arr(((V)((-1.2))), ((V)(18.7))), Arr(((V)((-2.7))), ((V)(19.6))), Arr(((V)((-2.7))), ((V)(21D))), Arr(((V)(2.7)), ((V)(21D)))));
DN_5114 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, CB_5093, ((V)(0.72))), NewObj(1).Put("op", ((V)(0.45))).V);
DC_5115 = Call(dec_24, V.Undef, ((V)("#6b4a26")), NewObj(1).Put("op", ((V)(0.5))).V);
Call(fp_5104, V.Undef, DN_5114, ((V)("f")), Arr(Arr(((V)(20D)), ((V)(28D))), Arr(((V)(28D)), ((V)(28D))), Arr(((V)(28D)), ((V)(19D))), Arr(((V)(24D)), ((V)(22.5)))));
Call(fl_5105, V.Undef, DC_5115, ((V)("f")), Arr(Arr(((V)(20.5)), ((V)(27.6))), Arr(((V)(24.2)), ((V)(22.8))), Arr(((V)(27.6)), ((V)(19.6)))), ((V)(0.3)));
Call(fl_5105, V.Undef, DC_5115, ((V)("f")), Arr(Arr(((V)(23D)), ((V)(27.6))), Arr(((V)(25.2)), ((V)(24.6))), Arr(((V)(27.6)), ((V)(23.6)))), ((V)(0.22)));
Call(fp_5104, V.Undef, DN_5114, ((V)("t")), Arr(Arr(((V)(20D)), ((V)(21D))), Arr(((V)(28D)), ((V)(21D))), Arr(((V)(28D)), ((V)(15D))), Arr(((V)(23.5)), ((V)(18D)))));
Call(fl_5105, V.Undef, DC_5115, ((V)("t")), Arr(Arr(((V)(21D)), ((V)(20.6))), Arr(((V)(27.6)), ((V)(15.6)))), ((V)(0.25)));
Call(tape_5113, V.Undef, ((V)("f")), Arr(Arr(((V)(15.5)), ((V)(25.6))), Arr(((V)(17.4)), ((V)(27.8))), Arr(((V)(27.8)), ((V)(18.4))), Arr(((V)(25.9)), ((V)(16.2)))), ((V)(14D)));
Call(tape_5113, V.Undef, ((V)("f")), Arr(Arr(((V)(17D)), ((V)(17.4))), Arr(((V)(27.6)), ((V)(26.8))), Arr(((V)(26.2)), ((V)(28D))), Arr(((V)(15.6)), ((V)(18.8)))), ((V)(14D)));
INK_5116 = Call(dec_24, V.Undef, ((V)("#3a2a1c")), NewObj(1).Put("op", ((V)(0.85))).V);
Invoke(Arr(((V)((-17D))), ((V)((-9D)))), "forEach", Fn((V _arrowThis5278, int _argc5271, V x_5277, V _a5274, V _a5275, V _a5276, V[] _rest5272) => {
Call(fl_5105, V.Undef, INK_5116, ((V)("f")), Arr(Arr(x_5277, ((V)(14D))), Arr(x_5277, ((V)(21.5)))), ((V)(0.75)));
Call(fp_5104, V.Undef, INK_5116, ((V)("f")), Arr(Arr(((V)((ToNum(x_5277) - 2D))), ((V)(21D))), Arr(Add(x_5277, ((V)(2D))), ((V)(21D))), Arr(x_5277, ((V)(24D)))));
return default;
}, 1, "", true));
Call(rep_29, V.Undef, ((V)(8D)), Fn((V _arrowThis5286, int _argc5279, V i_5285, V _a5282, V _a5283, V _a5284, V[] _rest5280) => {
return Call(fl_5105, V.Undef, INK_5116, ((V)("f")), Arr(Arr(((V)(((-20D) + (ToNum(i_5285) * 1.6)))), ((V)(11.6))), Arr(((V)(((-19.1) + (ToNum(i_5285) * 1.6)))), ((V)(11.6)))), ((V)(0.55)));
}, 1, "", true));
LB_5117 = Call(dec_24, V.Undef, ((V)("#f6f2e6")));
BC_5118 = Call(dec_24, V.Undef, ((V)("#1f1f22")));
LT_5119 = Call(dec_24, V.Undef, ((V)("#8a8a8e")), NewObj(1).Put("op", ((V)(0.8))).V);
LR_5120 = Call(dec_24, V.Undef, ((V)("#d9483b")));
Call(fp_5104, V.Undef, LB_5117, ((V)("f")), Arr(Arr(((V)((-6D))), ((V)(4D))), Arr(((V)(10D)), ((V)(4D))), Arr(((V)(10D)), ((V)(15D))), Arr(((V)((-6D))), ((V)(15D)))));
Call(fp_5104, V.Undef, LR_5120, ((V)("f")), Arr(Arr(((V)((-6D))), ((V)(13.6))), Arr(((V)(10D)), ((V)(13.6))), Arr(((V)(10D)), ((V)(15D))), Arr(((V)((-6D))), ((V)(15D)))));
bx_5121 = (-5D);
while ((bx_5121 < 3D)) {
double w_5287 = 0;
w_5287 = (0.15 + (ToNum(Call(R_5096, V.Undef)) * 0.45));
Call(fp_5104, V.Undef, BC_5118, ((V)("f")), Arr(Arr(((V)(bx_5121)), ((V)(5D))), Arr(((V)((bx_5121 + w_5287))), ((V)(5D))), Arr(((V)((bx_5121 + w_5287))), ((V)(9D))), Arr(((V)(bx_5121)), ((V)(9D)))));
bx_5121 = (bx_5121 + ((w_5287 + 0.2) + (ToNum(Call(R_5096, V.Undef)) * 0.35)));
}
Call(rep_29, V.Undef, ((V)(3D)), Fn((V _arrowThis5295, int _argc5288, V i_5294, V _a5291, V _a5292, V _a5293, V[] _rest5289) => {
return Call(fl_5105, V.Undef, LT_5119, ((V)("f")), Arr(Arr(((V)((-5D))), ((V)((11.8 - (ToNum(i_5294) * 1.1))))), Arr(((V)((8.5 - (ToNum(i_5294) * 1.6)))), ((V)((11.8 - (ToNum(i_5294) * 1.1)))))), ((V)(0.4)));
}, 1, "", true));
Call(fp_5104, V.Undef, BC_5118, ((V)("f")), Arr(Arr(((V)(4.4)), ((V)(5D))), Arr(((V)(9D)), ((V)(5D))), Arr(((V)(9D)), ((V)(9.6))), Arr(((V)(4.4)), ((V)(9.6)))));
Call(fp_5104, V.Undef, LB_5117, ((V)("f")), Arr(Arr(((V)(5.4)), ((V)(6D))), Arr(((V)(8D)), ((V)(6D))), Arr(((V)(8D)), ((V)(8.6))), Arr(((V)(5.4)), ((V)(8.6)))));
HO_5122 = Call(dec_24, V.Undef, ((V)("#2a1a0e")));
HR_5123 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, CB_5093, ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.7))).V);
Invoke(Arr(((V)("r")), ((V)("l"))), "forEach", Fn((V _arrowThis5303, int _argc5296, V s_5302, V _a5299, V _a5300, V _a5301, V[] _rest5297) => {
V Q_5304 = default;
Q_5304 = Call(rep_29, V.Undef, ((V)(14D)), Fn((V _arrowThis5312, int _argc5305, V i_5311, V _a5308, V _a5309, V _a5310, V[] _rest5306) => {
double a_5313 = 0;
double c_5314 = 0;
double sn_5315 = 0;
a_5313 = (((ToNum(i_5311) / 14D) * 2D) * PI_22);
c_5314 = FdLibm.Cos(a_5313);
sn_5315 = FdLibm.Sin(a_5313);
return Arr(((V)(((c_5314 * 4.6) + (Sign(c_5314) * 1.4)))), ((V)((20.5 + (sn_5315 * 1.6)))));
return default;
}, 1, "", true));
Call(fp_5104, V.Undef, HO_5122, s_5302, Q_5304);
Call(fl_5105, V.Undef, HR_5123, s_5302, Invoke(Invoke(Q_5304, "slice", ((V)(7D))), "concat", Arr(GetIdx(Q_5304, 0D))), ((V)(0.3)));
return default;
}, 1, "", true));
FR_5124 = Call(dec_24, V.Undef, ((V)("#c8393b")), NewObj(1).Put("op", ((V)(0.85))).V);
Call(fl_5105, V.Undef, FR_5124, ((V)("r")), Arr(Arr(((V)((-11D))), ((V)(6D))), Arr(((V)(9D)), ((V)(6D))), Arr(((V)(9D)), ((V)(14D))), Arr(((V)((-11D))), ((V)(14D))), Arr(((V)((-11D))), ((V)(6D)))), ((V)(0.55)));
Call(rep_29, V.Undef, ((V)(7D)), Fn((V _arrowThis5323, int _argc5316, V i_5322, V _a5319, V _a5320, V _a5321, V[] _rest5317) => {
double x_5324 = 0;
x_5324 = ((-9.4) + (ToNum(i_5322) * 2.6));
Call(fl_5105, V.Undef, FR_5124, ((V)("r")), Arr(Arr(((V)(x_5324)), ((V)(8.2))), Arr(((V)(x_5324)), ((V)(11.8)))), ((V)(0.7)));
Call(fl_5105, V.Undef, FR_5124, ((V)("r")), Arr(Arr(((V)(x_5324)), ((V)(11.8))), Arr(((V)((x_5324 + 1.3))), ((V)(11.8)))), ((V)(0.6)));
if (NumTruthy((ToNum(i_5322) % 2D))) {
Call(fl_5105, V.Undef, FR_5124, ((V)("r")), Arr(Arr(((V)(x_5324)), ((V)(10D))), Arr(((V)((x_5324 + 1D))), ((V)(10D)))), ((V)(0.5)));
}
return default;
}, 1, "", true));
Call(fl_5105, V.Undef, FR_5124, ((V)("r")), Arr(Arr(((V)(11.5)), ((V)(14D))), Arr(((V)(14.5)), ((V)(14D))), Arr(((V)(13.6)), ((V)(10.5))), Arr(((V)(12.4)), ((V)(10.5))), Arr(((V)(11.5)), ((V)(14D)))), ((V)(0.4)));
Call(fl_5105, V.Undef, FR_5124, ((V)("r")), Arr(Arr(((V)(13D)), ((V)(10.5))), Arr(((V)(13D)), ((V)(7.4)))), ((V)(0.4)));
Call(fl_5105, V.Undef, FR_5124, ((V)("r")), Arr(Arr(((V)(11.8)), ((V)(7.2))), Arr(((V)(14.2)), ((V)(7.2)))), ((V)(0.4)));
MK_5125 = Call(dec_24, V.Undef, ((V)("#1a1a1e")), NewObj(1).Put("op", ((V)(0.85))).V);
Call(rep_29, V.Undef, ((V)(9D)), Fn((V _arrowThis5332, int _argc5325, V i_5331, V _a5328, V _a5329, V _a5330, V[] _rest5326) => {
double x_5333 = 0;
x_5333 = ((-14D) + (ToNum(i_5331) * 3.1));
Call(fl_5105, V.Undef, MK_5125, ((V)("b")), Arr(Arr(((V)(x_5333)), ((V)((15D + ((ToNum(i_5331) % 2D) * 0.6))))), Arr(((V)((x_5333 + 1.2))), ((V)((18.5 + ((ToNum(i_5331) % 3D) * 0.3))))), Arr(((V)((x_5333 + 2.2))), ((V)(15.4)))), ((V)(0.55)), ((V)(1D)));
return default;
}, 1, "", true));
Call(fl_5105, V.Undef, MK_5125, ((V)("b")), Arr(Arr(((V)((-15D))), ((V)(13.2))), Arr(((V)(14D)), ((V)(13.6)))), ((V)(0.4)), ((V)(1D)));
WS_5126 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, CB_5093, ((V)(0.7))), NewObj(1).Put("op", ((V)(0.4))).V);
Invoke(Arr(((V)("f")), ((V)("r")), ((V)("b"))), "forEach", Fn((V _arrowThis5341, int _argc5334, V s_5340, V _a5337, V _a5338, V _a5339, V[] _rest5335) => {
double a_5342 = 0;
a_5342 = ((SEqS(s_5340, "f") || SEqS(s_5340, "b")) ? 28D : 21D);
Call(fp_5104, V.Undef, WS_5126, s_5340, Invoke(Arr(Arr(((V)((-a_5342))), ((V)(0.2)))), "concat", Call(rep_29, V.Undef, ((V)(13D)), Fn((V _arrowThis5350, int _argc5343, V i_5349, V _a5346, V _a5347, V _a5348, V[] _rest5344) => {
return Arr(((V)(((-a_5342) + (((ToNum(i_5349) * 2D) * a_5342) / 12D)))), ((V)((2.4 + (FdLibm.Sin((ToNum(i_5349) * 1.7)) * 0.9)))));
}, 1, "", true)), Arr(Arr(((V)(a_5342)), ((V)(0.2))))));
return default;
}, 1, "", true));
CF_5127 = Call(dec_24, V.Undef, ((V)("#6b3f22")), NewObj(1).Put("op", ((V)(0.5))).V);
Call(fl_5105, V.Undef, CF_5127, ((V)("t")), Call(rep_29, V.Undef, ((V)(23D)), Fn((V _arrowThis5358, int _argc5351, V i_5357, V _a5354, V _a5355, V _a5356, V[] _rest5352) => {
double a_5359 = 0;
a_5359 = ((((ToNum(i_5357) / 22D) * 2D) * PI_22) * 0.9);
return Arr(((V)((15D + (FdLibm.Cos(a_5359) * 3.3)))), ((V)(((-12D) + (FdLibm.Sin(a_5359) * 3.3)))));
return default;
}, 1, "", true)), ((V)(0.5)));
Call(on_5095, V.Undef, BX_5101, Arr(FLU_5106, FLL_5107, WS_5126, FOLD_5109, SEAM_5108, DN_5114, DC_5115, TP_5110, TD_5112, TL_5111, INK_5116, LB_5117, LR_5120, BC_5118, LT_5119, HO_5122, HR_5123, FR_5124, MK_5125, CF_5127));
FC_5128 = ((V)("#7fa8cf"));
BL_5129 = Call(box_13, V.Undef, ((V)((-8D))), ((V)(H_5098)), ((V)(5D)), ((V)(30D)), ((V)(3.2)), ((V)(24D)), FC_5128, NewObj(4).Put("r", ((V)(1.4))).Put("bev", ((V)(1.2))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V);
FW_5130 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.75))).V);
FD_5131 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, FC_5128, ((V)(0.78))), NewObj(1).Put("op", ((V)(0.6))).V);
Call(on_5095, V.Undef, BX_5101, Arr(BL_5129));
Invoke(Call(caps_50, V.Undef, BL_5129, ((V)(2D))), "forEach", Fn((V _arrowThis5367, int _argc5360, V F_5366, V _a5363, V _a5364, V _a5365, V[] _rest5361) => {
V G_5368 = default;
Call(dots_48, V.Undef, FW_5130, F_5366, ((V)(4.2)), ((V)(0.55)), NewObj(3).Put("sh", ((V)(0.86))).Put("stag", ((V)(1D))).Put("m", ((V)(5D))).V);
G_5368 = Call(fr2_39, V.Undef, F_5366);
Invoke(FD_5131, "line", Arr(Invoke(G_5368, "at", ((V)((-14D))), ((V)(2D))), Invoke(G_5368, "at", ((V)(14D)), ((V)(2.5)))), Get(G_5368, "n"), ((V)(0.35)));
return default;
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, BL_5129, ((V)(1D))), "forEach", Fn((V _arrowThis5376, int _argc5369, V F_5375, V _a5372, V _a5373, V _a5374, V[] _rest5370) => {
if (GtN(GetIdx(Get(F_5375, "n"), 2D), 0.7)) {
Call(wavy_46, V.Undef, FD_5131, F_5375, Fn((V _arrowThis5385, int _argc5377, V t_5383, V G_5384, V _a5381, V _a5382, V[] _rest5378) => {
V Wd_5386 = default;
{ V _t5387 = Call(WH2_84, V.Undef, G_5384);
{ V _t5388 = ListOf(_t5387);
{ V _t5389 = GetIdx(_t5388, 0D);
Wd_5386 = _t5389; }
} }
return Arr(((V)((((-ToNum(Wd_5386)) / 2D) + (ToNum(Wd_5386) * ToNum(t_5383))))), ((V)((FdLibm.Sin((ToNum(t_5383) * 20D)) * 0.4))));
return default;
}, 2, "", true), ((V)(24D)), ((V)(0.3)));
}
return default;
}, 1, "", true));
RM_5132 = Call(box_13, V.Undef, ((V)((-4D))), ((V)((H_5098 + 3.2))), ((V)(0D)), ((V)(4.4)), ((V)(1.5)), ((V)(12D)), ((V)("#2a2b30")), NewObj(3).Put("r", ((V)(1D))).Put("yaw", ((V)(0.45))).Put("mat", ((V)("pl"))).V);
RB_5133 = Call(dec_24, V.Undef, ((V)("#d9483b")));
RG_5134 = Call(dec_24, V.Undef, ((V)("#9aa1a6")));
Call(on_5095, V.Undef, BL_5129, Arr(FW_5130, FD_5131, RM_5132));
{
double c_5390 = 0;
double s_5391 = 0;
V Pt_5392 = default;
c_5390 = FdLibm.Cos(0.45);
s_5391 = FdLibm.Sin(0.45);
Pt_5392 = Fn((V _arrowThis5401, int _argc5393, V a_5399, V b_5400, V _a5397, V _a5398, V[] _rest5394) => {
return Arr(((V)((((-4D) + (ToNum(a_5399) * c_5390)) + (ToNum(b_5400) * s_5391)))), ((V)((H_5098 + 4.78))), ((V)((((-ToNum(a_5399)) * s_5391) + (ToNum(b_5400) * c_5390)))));
}, 2, "", true);
Call(spot_25, V.Undef, RB_5133, Call(Pt_5392, V.Undef, ((V)(0D)), ((V)((-4D)))), Y3_37, ((V)(0.7)), ((V)(0.7)), ((V)(0D)), ((V)(8D)));
Call(rep_29, V.Undef, ((V)(6D)), Fn((V _arrowThis5409, int _argc5402, V i_5408, V _a5405, V _a5406, V _a5407, V[] _rest5403) => {
return Call(spot_25, V.Undef, RG_5134, Call(Pt_5392, V.Undef, ((V)((NumTruthy((ToNum(i_5408) % 2D)) ? 0.9 : (-0.9)))), ((V)(((-1D) + (System.Math.Floor((ToNum(i_5408) / 2D)) * 1.6))))), Y3_37, ((V)(0.45)), ((V)(0.4)), ((V)(0D)), ((V)(6D)));
}, 1, "", true));
Call(on_5095, V.Undef, RM_5132, Arr(RB_5133, RG_5134));
}
return o_5094;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_21, "papasan25", Fn((V _arrowThis5417, int _argc5410, V S_5416, V _a5413, V _a5414, V _a5415, V[] _rest5411) => {
return NewObj(6).Put("w", ((V)(84D))).Put("d", ((V)(80D))).Put("round", ((V)(1D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(6D))).Put("h", ((V)(40D))).V)).Put("build", Fn((V _arrowThis5425, int _argc5418, V P_5424, V _a5421, V _a5422, V _a5423, V[] _rest5419) => {
V V_5426 = default;
V RT_5427 = default;
V BK_5428 = default;
V BR_5429 = default;
V o_5430 = default;
V on_5431 = default;
V R_5432 = default;
V BW_5433 = default;
V RIM_5434 = default;
V CU_5435 = default;
V PL_5436 = default;
V W1_5437 = default;
V W2_5438 = default;
V BD_5439 = default;
V RB1_5440 = default;
double ca_5441 = 0;
double cb_5442 = 0;
double cc_5443 = 0;
double cy0_5444 = 0;
V sp_5445 = default;
V D1_5446 = default;
V D2_5447 = default;
V PLT_5448 = default;
V PLL_5449 = default;
V BTN_5450 = default;
V BTH_5451 = default;
V WL_5452 = default;
V PG_5453 = default;
V CH_5454 = default;
V E1_5455 = default;
V E2_5456 = default;
V_5426 = Get(P_5424, "a");
RT_5427 = ((V)("#c99a5a"));
BK_5428 = ((V)("#2c2d31"));
BR_5429 = ((V)("#d9a84a"));
o_5430 = Arr();
on_5431 = Call(glue_27, V.Undef, o_5430);
R_5432 = Call(R0_28, V.Undef, ((V)("pp25")));
Invoke(o_5430, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(3D)), BK_5428, NewObj(3).Put("n", ((V)(22D))).Put("mat", ((V)("metal"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(2D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.88))))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(8D)), ((V)(2.4)), BR_5429, NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(5.4)), ((V)(0D)), ((V)(3.4)), ((V)(8D)), BK_5428, NewObj(2).Put("n", ((V)(10D))).Put("mat", ((V)("metal"))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(13.4)), ((V)(2D)), ((V)(12D)), ((V)(2.6)), BR_5429, NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V));
BW_5433 = Call(cyl_14, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(2D)), ((V)(38D)), ((V)(22D)), RT_5427, NewObj(4).Put("n", ((V)(28D))).Put("rz", ((V)(34D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.32))), Arr(((V)(8D)), ((V)(0D)), ((V)(0.72))), Arr(((V)(16D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(22D)), ((V)(0D)), ((V)(1D))))).Put("mat", ((V)("wood"))).V);
RIM_5434 = Call(arcW_16, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(2D)), ((V)(39D)), ((V)(35D)), ((V)(2.4)), ((V)(2.4)), ((V)(0D)), ((V)((2D * PI_22))), Call(shade_18, V.Undef, RT_5427, ((V)(0.8))), NewObj(2).Put("n", ((V)(28D))).Put("mat", ((V)("wood"))).V);
CU_5435 = Call(ball_12, V.Undef, ((V)(0D)), ((V)(32D)), ((V)(4D)), ((V)(33D)), V_5426, NewObj(7).Put("sy", ((V)(0.32))).Put("sz", ((V)(0.85))).Put("k", ((V)(6D))).Put("n", ((V)(24D))).Put("soft", ((V)(1D))).Put("shine", ((V)(0D))).Put("mat", ((V)("fab"))).V);
PL_5436 = Call(pillowZ_17, V.Undef, ((V)(0D)), ((V)(40D)), ((V)((-18D))), ((V)(46D)), ((V)(22D)), ((V)(12D)), Call(shade_18, V.Undef, V_5426, ((V)(1.08))), NewObj(2).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V);
Invoke(o_5430, "push", BW_5433);
Call(on_5431, V.Undef, BW_5433, Arr(RIM_5434, CU_5435));
Call(on_5431, V.Undef, CU_5435, Arr(PL_5436));
W1_5437 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, RT_5427, ((V)(0.72))), NewObj(1).Put("op", ((V)(0.55))).V);
W2_5438 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, RT_5427, ((V)("#fff1d0")), ((V)(0.35))), NewObj(1).Put("op", ((V)(0.5))).V);
BD_5439 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, RT_5427, ((V)(0.62))), NewObj(1).Put("op", ((V)(0.7))).V);
Invoke(Get(BW_5433, "faces"), "forEach", Fn((V _arrowThis5464, int _argc5457, V F_5463, V _a5460, V _a5461, V _a5462, V[] _rest5458) => {
if (Truthy((Get(F_5463, "cap") is var _t5465 && Truthy(_t5465) ? _t5465 : (!(Truthy(Call(bigF_82, V.Undef, F_5463, ((V)(6D))))) ? V.True : V.False)))) {
return default;
}
Call(hatch_45, V.Undef, W1_5437, F_5463, ((V)((PI_22 / 4D))), ((V)(1.8)), ((V)(0.5)), NewObj(1).Put("sh", ((V)(0.98))).V);
Call(hatch_45, V.Undef, W2_5438, F_5463, ((V)(((-PI_22) / 4D))), ((V)(1.8)), ((V)(0.5)), NewObj(2).Put("sh", ((V)(0.98))).Put("ph", ((V)(0.9))).V);
return default;
}, 1, "", true));
Invoke(Arr(((V)(21D)), ((V)(25.5)), ((V)(30D))), "forEach", Fn((V _arrowThis5473, int _argc5466, V y_5472, V _a5469, V _a5470, V _a5471, V[] _rest5467) => {
double t_5474 = 0;
double k_5475 = 0;
V pts_5476 = default;
V nn_5477 = default;
t_5474 = ((ToNum(y_5472) - 16D) / 22D);
k_5475 = ((t_5474 < 0.36) ? (0.32 + (((0.72 - 0.32) * t_5474) / 0.36)) : ((t_5474 < 0.73) ? (0.72 + ((0.22 * (t_5474 - 0.36)) / 0.37)) : (0.94 + ((0.06 * (t_5474 - 0.73)) / 0.27))));
pts_5476 = Arr();
nn_5477 = Arr();
Call(rep_29, V.Undef, ((V)(49D)), Fn((V _arrowThis5485, int _argc5478, V i_5484, V _a5481, V _a5482, V _a5483, V[] _rest5479) => {
double a_5486 = 0;
a_5486 = (((ToNum(i_5484) / 48D) * 2D) * PI_22);
Invoke(pts_5476, "push", Arr(((V)((((FdLibm.Cos(a_5486) * 38D) * k_5475) * 1.012))), y_5472, ((V)((2D + (((FdLibm.Sin(a_5486) * 34D) * k_5475) * 1.012))))));
Invoke(nn_5477, "push", Arr(((V)(FdLibm.Cos(a_5486))), ((V)((-0.3))), ((V)(FdLibm.Sin(a_5486)))));
return default;
}, 1, "", true));
Invoke(BD_5439, "line", pts_5476, nn_5477, ((V)(0.8)));
return default;
}, 1, "", true));
RB1_5440 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, RT_5427, ((V)(0.6))), NewObj(1).Put("op", ((V)(0.7))).V);
Invoke(Get(RIM_5434, "faces"), "forEach", Fn((V _arrowThis5494, int _argc5487, V F_5493, V _a5490, V _a5491, V _a5492, V[] _rest5488) => {
if (Truthy(Call(bigF_82, V.Undef, F_5493, ((V)(1D))))) {
Call(hatch_45, V.Undef, RB1_5440, F_5493, ((V)((PI_22 / 2.6))), ((V)(0.9)), ((V)(0.22)), NewObj(1).Put("sh", ((V)(0.99))).V);
}
return default;
}, 1, "", true));
Call(on_5431, V.Undef, BW_5433, Arr(W1_5437, W2_5438, BD_5439));
Call(on_5431, V.Undef, RIM_5434, Arr(RB1_5440));
ca_5441 = 33D;
cb_5442 = 28.05;
cc_5443 = 10.56;
cy0_5444 = (32D + cc_5443);
sp_5445 = Fn((V _arrowThis5504, int _argc5495, V x_5501, V z_5502, V k_5503, V _a5500, V[] _rest5496) => {
double e_5505 = 0;
double y_5506 = 0;
V n_5507 = default;
e_5505 = ((1D - Pow((ToNum(x_5501) / ca_5441), 2D)) - Pow(((ToNum(z_5502) - 4D) / cb_5442), 2D));
y_5506 = (cy0_5444 + (cc_5443 * System.Math.Sqrt(Max(0D, e_5505))));
n_5507 = Call(nz_35, V.Undef, Arr(((V)(((ToNum(x_5501) / ca_5441) / ca_5441))), ((V)((((y_5506 - cy0_5444) / cc_5443) / cc_5443))), ((V)((((ToNum(z_5502) - 4D) / cb_5442) / cb_5442)))));
return Arr(Call(add_30, V.Undef, Arr(x_5501, ((V)(y_5506)), z_5502), Call(mul_32, V.Undef, n_5507, (k_5503 is var _t5508 && Truthy(_t5508) ? _t5508 : ((V)(0.1))))), n_5507);
return default;
}, 3, "", true);
{ V _t5509 = Arr(Call(dec_24, V.Undef, Call(mix_19, V.Undef, V_5426, ((V)("#ffffff")), ((V)(0.22))), NewObj(1).Put("op", ((V)(0.2))).V), Call(dec_24, V.Undef, Call(shade_18, V.Undef, V_5426, ((V)(0.86))), NewObj(1).Put("op", ((V)(0.18))).V));
{ V _t5510 = ListOf(_t5509);
{ V _t5511 = GetIdx(_t5510, 0D);
D1_5446 = _t5511; }
{ V _t5512 = GetIdx(_t5510, 1D);
D2_5447 = _t5512; }
} }
PLT_5448 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, V_5426, ((V)(0.68))), NewObj(1).Put("op", ((V)(0.55))).V);
PLL_5449 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, V_5426, ((V)("#ffffff")), ((V)(0.25))), NewObj(1).Put("op", ((V)(0.35))).V);
BTN_5450 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, V_5426, ((V)(0.5))));
BTH_5451 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, V_5426, ((V)("#ffffff")), ((V)(0.4))), NewObj(1).Put("op", ((V)(0.7))).V);
WL_5452 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, V_5426, ((V)(0.7))), NewObj(1).Put("op", ((V)(0.8))).V);
Invoke(Get(CU_5435, "faces"), "forEach", Fn((V _arrowThis5520, int _argc5513, V F_5519, V _a5516, V _a5517, V _a5518, V[] _rest5514) => {
if (Truthy(((GtN(GetIdx(Get(F_5519, "n"), 1D), 0.5) ? V.True : V.False) is var _t5521 && !Truthy(_t5521) ? _t5521 : Call(bigF_82, V.Undef, F_5519, ((V)(20D)))))) {
Call(velvet_58, V.Undef, D1_5446, D2_5447, F_5519, R_5432, ((V)(1D)));
}
return default;
}, 1, "", true));
Call(rep_29, V.Undef, ((V)(8D)), Fn((V _arrowThis5529, int _argc5522, V i_5528, V _a5525, V _a5526, V _a5527, V[] _rest5523) => {
double a_5530 = 0;
double bx_5531 = 0;
double bz_5532 = 0;
V L_5533 = default;
V L2_5534 = default;
V q_5535 = default;
V L3_5536 = default;
a_5530 = ((((ToNum(i_5528) / 8D) * 2D) * PI_22) + 0.2);
bx_5531 = (FdLibm.Cos(a_5530) * 15D);
bz_5532 = (6D + (FdLibm.Sin(a_5530) * 12D));
L_5533 = Call(rep_29, V.Undef, ((V)(9D)), Fn((V _arrowThis5544, int _argc5537, V j_5543, V _a5540, V _a5541, V _a5542, V[] _rest5538) => {
return Call(sp_5445, V.Undef, ((V)(((bx_5531 * ToNum(j_5543)) / 8D))), ((V)((6D + (((bz_5532 - 6D) * ToNum(j_5543)) / 8D)))));
}, 1, "", true));
Invoke(PLT_5448, "line", Invoke(L_5533, "map", Fn((V _arrowThis5552, int _argc5545, V q_5551, V _a5548, V _a5549, V _a5550, V[] _rest5546) => {
return GetIdx(q_5551, 0D);
}, 1, "", true)), Invoke(L_5533, "map", Fn((V _arrowThis5560, int _argc5553, V q_5559, V _a5556, V _a5557, V _a5558, V[] _rest5554) => {
return GetIdx(q_5559, 1D);
}, 1, "", true)), ((V)(0.5)), ((V)(1D)));
L2_5534 = Call(rep_29, V.Undef, ((V)(9D)), Fn((V _arrowThis5568, int _argc5561, V j_5567, V _a5564, V _a5565, V _a5566, V[] _rest5562) => {
return Call(sp_5445, V.Undef, ((V)((((bx_5531 * ToNum(j_5567)) / 8D) + 0.8))), ((V)(((6D + (((bz_5532 - 6D) * ToNum(j_5567)) / 8D)) + 0.6))));
}, 1, "", true));
Invoke(PLL_5449, "line", Invoke(L2_5534, "map", Fn((V _arrowThis5576, int _argc5569, V q_5575, V _a5572, V _a5573, V _a5574, V[] _rest5570) => {
return GetIdx(q_5575, 0D);
}, 1, "", true)), Invoke(L2_5534, "map", Fn((V _arrowThis5584, int _argc5577, V q_5583, V _a5580, V _a5581, V _a5582, V[] _rest5578) => {
return GetIdx(q_5583, 1D);
}, 1, "", true)), ((V)(0.3)), ((V)(1D)));
q_5535 = Call(sp_5445, V.Undef, ((V)(bx_5531)), ((V)(bz_5532)), ((V)(0.15)));
Call(spot_25, V.Undef, BTN_5450, GetIdx(q_5535, 0D), GetIdx(q_5535, 1D), ((V)(1.2)), ((V)(1.2)), ((V)(0D)), ((V)(8D)));
Call(spot_25, V.Undef, BTH_5451, Call(add_30, V.Undef, GetIdx(q_5535, 0D), Arr(((V)((-0.3))), ((V)(0.05)), ((V)((-0.3))))), GetIdx(q_5535, 1D), ((V)(0.45)), ((V)(0.4)), ((V)(0D)), ((V)(6D)));
L3_5536 = Call(rep_29, V.Undef, ((V)(7D)), Fn((V _arrowThis5592, int _argc5585, V j_5591, V _a5588, V _a5589, V _a5590, V[] _rest5586) => {
double t_5593 = 0;
double r_5594 = 0;
t_5593 = ((a_5530 + (PI_22 / 8D)) + ((ToNum(j_5591) - 3D) * 0.07));
r_5594 = (1D + (ToNum(j_5591) * 0D));
return Call(sp_5445, V.Undef, ((V)((FdLibm.Cos(t_5593) * 22D))), ((V)((6D + (FdLibm.Sin(t_5593) * 17.6)))));
return default;
}, 1, "", true));
Invoke(PLT_5448, "line", Invoke(L3_5536, "map", Fn((V _arrowThis5602, int _argc5595, V q2_5601, V _a5598, V _a5599, V _a5600, V[] _rest5596) => {
return GetIdx(q2_5601, 0D);
}, 1, "", true)), Invoke(L3_5536, "map", Fn((V _arrowThis5610, int _argc5603, V q2_5609, V _a5606, V _a5607, V _a5608, V[] _rest5604) => {
return GetIdx(q2_5609, 1D);
}, 1, "", true)), ((V)(0.3)), ((V)(1D)));
return default;
}, 1, "", true));
{
V q_5611 = default;
q_5611 = Call(sp_5445, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0.15)));
Call(spot_25, V.Undef, BTN_5450, GetIdx(q_5611, 0D), GetIdx(q_5611, 1D), ((V)(1.8)), ((V)(1.8)), ((V)(0D)), ((V)(10D)));
Call(spot_25, V.Undef, BTH_5451, Call(add_30, V.Undef, GetIdx(q_5611, 0D), Arr(((V)((-0.4))), ((V)(0.05)), ((V)((-0.4))))), GetIdx(q_5611, 1D), ((V)(0.6)), ((V)(0.5)), ((V)(0D)), ((V)(6D)));
}
if (((ToNum(Get(Get(CU_5435, "pts"), "length")) % 7D) == 0D)) {
Call(ringL_49, V.Undef, WL_5452, CU_5435, ((V)(3D)), ((V)(7D)), ((V)(0.75)), ((V)(0.2)));
}
Call(on_5431, V.Undef, CU_5435, Arr(D1_5446, D2_5447, PLT_5448, PLL_5449, BTN_5450, BTH_5451, WL_5452));
PG_5453 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, V_5426, ((V)(0.62))), NewObj(1).Put("op", ((V)(0.85))).V);
CH_5454 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, V_5426, ((V)(0.8))), NewObj(1).Put("op", ((V)(0.45))).V);
{ V _t5612 = Arr(Call(dec_24, V.Undef, Call(mix_19, V.Undef, V_5426, ((V)("#ffffff")), ((V)(0.22))), NewObj(1).Put("op", ((V)(0.2))).V), Call(dec_24, V.Undef, Call(shade_18, V.Undef, V_5426, ((V)(0.86))), NewObj(1).Put("op", ((V)(0.16))).V));
{ V _t5613 = ListOf(_t5612);
{ V _t5614 = GetIdx(_t5613, 0D);
E1_5455 = _t5614; }
{ V _t5615 = GetIdx(_t5613, 1D);
E2_5456 = _t5615; }
} }
Invoke(Get(PL_5436, "faces"), "forEach", Fn((V _arrowThis5623, int _argc5616, V F_5622, V _a5619, V _a5620, V _a5621, V[] _rest5617) => {
if (!(Truthy(Call(bigF_82, V.Undef, F_5622, ((V)(20D)))))) {
return default;
}
if (Truthy(Get(F_5622, "cap"))) {
V G_5624 = default;
Call(velvet_58, V.Undef, E1_5455, E2_5456, F_5622, R_5432, ((V)(2D)));
Call(outline_47, V.Undef, PG_5453, F_5622, ((V)(0.93)), ((V)(0.6)));
G_5624 = Call(fr2_39, V.Undef, F_5622);
Invoke(Arr(((V)((-11D))), ((V)(0D)), ((V)(11D))), "forEach", Fn((V _arrowThis5632, int _argc5625, V a_5631, V _a5628, V _a5629, V _a5630, V[] _rest5626) => {
return Invoke(CH_5454, "line", Arr(Invoke(G_5624, "at", a_5631, ((V)((-8D)))), Invoke(G_5624, "at", a_5631, ((V)(8D)))), Get(G_5624, "n"), ((V)(0.45)), ((V)(1D)));
}, 1, "", true));
}
return default;
}, 1, "", true));
Call(on_5431, V.Undef, PL_5436, Arr(E1_5455, E2_5456, PG_5453, CH_5454));
{
double a_5633 = 0;
double x_5634 = 0;
double z_5635 = 0;
V TS_5636 = default;
a_5633 = (PI_22 * 0.72);
x_5634 = (FdLibm.Cos(a_5633) * 39.6);
z_5635 = (2D + (FdLibm.Sin(a_5633) * 35.6));
TS_5636 = ((V)("#e0b34a"));
Call(on_5431, V.Undef, RIM_5434, Arr(Call(ball_12, V.Undef, ((V)(x_5634)), ((V)(35.4)), ((V)(z_5635)), ((V)(1.3)), TS_5636, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("mat", ((V)("fab"))).V), Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("y"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(x_5634)), ((V)(z_5635)))).Put("a", ((V)(0.6))).Put("b", ((V)(0.6))).Put("n", ((V)(6D))).Put("rings", Arr(Arr(((V)(29.2)), ((V)(0D)), ((V)(1.8))), Arr(((V)(33.4)), ((V)(0D)), ((V)(0.9))), Arr(((V)(35.6)), ((V)(0D)), ((V)(0.5))))).Put("col", Call(shade_18, V.Undef, TS_5636, ((V)(0.9)))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V)));
}
return o_5430;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_21, "cattree25", Fn((V _arrowThis5644, int _argc5637, V S_5643, V _a5640, V _a5641, V _a5642, V[] _rest5638) => {
return NewObj(3).Put("w", ((V)(70D))).Put("d", ((V)(60D))).Put("build", Fn((V _arrowThis5652, int _argc5645, V P_5651, V _a5648, V _a5649, V _a5650, V[] _rest5646) => {
V FE_5653 = default;
V BI_5654 = default;
V o_5655 = default;
V on_5656 = default;
V R_5657 = default;
V felt_5658 = default;
V BASE_5659 = default;
V logs_5660 = default;
V LG_5661 = default;
V SI_5662 = default;
V SD_5663 = default;
V SL_5664 = default;
V POD_5665 = default;
V PC_5666 = default;
V PT_5667 = default;
V BED_5668 = default;
FE_5653 = Get(P_5651, "a");
BI_5654 = ((V)("#ece6da"));
o_5655 = Arr();
on_5656 = Call(glue_27, V.Undef, o_5655);
R_5657 = Call(R0_28, V.Undef, ((V)("ct25")));
felt_5658 = Fn((V _arrowThis5677, int _argc5669, V S0_5675, V d0_5676, V _a5673, V _a5674, V[] _rest5670) => {
V F1_5678 = default;
V F2_5679 = default;
F1_5678 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, Get(S0_5675, "col"), ((V)(0.86))), NewObj(1).Put("op", ((V)(0.35))).V);
F2_5679 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, Get(S0_5675, "col"), ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.3))).V);
Invoke(Get(S0_5675, "faces"), "forEach", Fn((V _arrowThis5687, int _argc5680, V F_5686, V _a5683, V _a5684, V _a5685, V[] _rest5681) => {
if (Truthy(Call(bigF_82, V.Undef, F_5686, ((V)(8D))))) {
Call(fleck_83, V.Undef, F1_5678, F2_5679, F_5686, R_5657, (d0_5676 is var _t5688 && Truthy(_t5688) ? _t5688 : ((V)(0.12))), ((V)(0.25)));
}
return default;
}, 1, "", true));
return Arr(F1_5678, F2_5679);
return default;
}, 2, "", true);
BASE_5659 = Call(box_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(66D)), ((V)(6D)), ((V)(56D)), FE_5653, NewObj(3).Put("r", ((V)(6D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V);
Invoke(o_5655, "push", BASE_5659);
{
V ST_5689 = default;
ST_5689 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, FE_5653, ((V)("#ffffff")), ((V)(0.55))), NewObj(1).Put("op", ((V)(0.85))).V);
Invoke(Call(caps_50, V.Undef, BASE_5659, ((V)(2D))), "forEach", Fn((V _arrowThis5697, int _argc5690, V F_5696, V _a5693, V _a5694, V _a5695, V[] _rest5691) => {
V G_5698 = default;
V P2_5699 = default;
G_5698 = Call(fr2_39, V.Undef, F_5696);
P2_5699 = Call(shrinkP_41, V.Undef, Get(G_5698, "P"), ((V)(0.9)));
Invoke(P2_5699, "forEach", Fn((V _arrowThis5708, int _argc5700, V p_5706, V i_5707, V _a5704, V _a5705, V[] _rest5701) => {
V q_5709 = default;
double L_5710 = 0;
double n_5711 = 0;
q_5709 = GetIdx(P2_5699, (ToNum(Add(i_5707, ((V)(1D)))) % ToNum(Get(P2_5699, "length"))));
L_5710 = Hypot((ToNum(GetIdx(q_5709, 0D)) - ToNum(GetIdx(p_5706, 0D))), (ToNum(GetIdx(q_5709, 1D)) - ToNum(GetIdx(p_5706, 1D))));
n_5711 = Max(1D, System.Math.Floor((L_5710 / 1.6)));
Call(rep_29, V.Undef, ((V)(n_5711)), Fn((V _arrowThis5719, int _argc5712, V k_5718, V _a5715, V _a5716, V _a5717, V[] _rest5713) => {
double t0_5720 = 0;
double t1_5721 = 0;
t0_5720 = (ToNum(k_5718) / n_5711);
t1_5721 = (t0_5720 + (0.55 / n_5711));
Invoke(ST_5689, "line", Arr(Invoke(G_5698, "at", Add(GetIdx(p_5706, 0D), ((V)(((ToNum(GetIdx(q_5709, 0D)) - ToNum(GetIdx(p_5706, 0D))) * t0_5720)))), Add(GetIdx(p_5706, 1D), ((V)(((ToNum(GetIdx(q_5709, 1D)) - ToNum(GetIdx(p_5706, 1D))) * t0_5720))))), Invoke(G_5698, "at", Add(GetIdx(p_5706, 0D), ((V)(((ToNum(GetIdx(q_5709, 0D)) - ToNum(GetIdx(p_5706, 0D))) * t1_5721)))), Add(GetIdx(p_5706, 1D), ((V)(((ToNum(GetIdx(q_5709, 1D)) - ToNum(GetIdx(p_5706, 1D))) * t1_5721)))))), Get(G_5698, "n"), ((V)(0.3)));
return default;
}, 1, "", true));
return default;
}, 2, "", true));
return default;
}, 1, "", true));
Call(on_5656, V.Undef, BASE_5659, Invoke(Call(felt_5658, V.Undef, BASE_5659), "concat", Arr(ST_5689)));
}
logs_5660 = Arr(Arr(((V)((-20D))), ((V)(6D)), ((V)(5.5)), ((V)(6D)), ((V)(34D))), Arr(((V)(18D)), ((V)((-8D))), ((V)(6D)), ((V)(6D)), ((V)(94D))), Arr(((V)(22D)), ((V)(16D)), ((V)(4D)), ((V)(6D)), ((V)(50D))));
LG_5661 = Invoke(logs_5660, "map", Fn((V _arrowThis5739, int _argc5722, V _a5724, V _a5725, V _a5726, V _a5727, V[] _rest5723) => {
V x_5730 = default;
V z_5732 = default;
V r_5734 = default;
V y_5736 = default;
V h_5738 = default;
{ V _t5728 = ListOf(_a5724);
{ V _t5729 = GetIdx(_t5728, 0D);
x_5730 = _t5729; }
{ V _t5731 = GetIdx(_t5728, 1D);
z_5732 = _t5731; }
{ V _t5733 = GetIdx(_t5728, 2D);
r_5734 = _t5733; }
{ V _t5735 = GetIdx(_t5728, 3D);
y_5736 = _t5735; }
{ V _t5737 = GetIdx(_t5728, 4D);
h_5738 = _t5737; }
}
return Call(cyl_14, V.Undef, x_5730, y_5736, z_5732, r_5734, h_5738, BI_5654, NewObj(2).Put("n", ((V)(16D))).Put("mat", ((V)("wood"))).V);
}, 1, "", true));
InvokeSpread(o_5655, "push", new ArrBuilder().Spread(LG_5661).V);
Invoke(LG_5661, "forEach", Fn((V _arrowThis5748, int _argc5740, V S0_5746, V i_5747, V _a5744, V _a5745, V[] _rest5741) => {
V x_5749 = default;
V z_5750 = default;
V r_5751 = default;
V y_5752 = default;
V h_5753 = default;
V LN_5754 = default;
V LS_5755 = default;
V PE_5756 = default;
V KN_5757 = default;
{ V _t5758 = GetK(logs_5660, i_5747);
{ V _t5759 = ListOf(_t5758);
{ V _t5760 = GetIdx(_t5759, 0D);
x_5749 = _t5760; }
{ V _t5761 = GetIdx(_t5759, 1D);
z_5750 = _t5761; }
{ V _t5762 = GetIdx(_t5759, 2D);
r_5751 = _t5762; }
{ V _t5763 = GetIdx(_t5759, 3D);
y_5752 = _t5763; }
{ V _t5764 = GetIdx(_t5759, 4D);
h_5753 = _t5764; }
} }
LN_5754 = Call(dec_24, V.Undef, ((V)("#2e2a26")), NewObj(1).Put("op", ((V)(0.85))).V);
LS_5755 = Call(dec_24, V.Undef, ((V)("#8a8278")), NewObj(1).Put("op", ((V)(0.5))).V);
PE_5756 = Call(dec_24, V.Undef, ((V)("#fffaf0")), NewObj(1).Put("op", ((V)(0.9))).V);
KN_5757 = Call(dec_24, V.Undef, ((V)("#3a332c")));
Call(rep_29, V.Undef, ((V)(Round((ToNum(h_5753) * 0.9)))), Fn((V _arrowThis5771, int _argc5765, V _a5767, V _a5768, V _a5769, V _a5770, V[] _rest5766) => {
double a_5772 = 0;
V yy_5773 = default;
V p_5774 = default;
V n_5775 = default;
a_5772 = ((ToNum(Call(R_5657, V.Undef)) * 2D) * PI_22);
yy_5773 = Add(Add(y_5752, ((V)(1D))), ((V)((ToNum(Call(R_5657, V.Undef)) * (ToNum(h_5753) - 2D)))));
{ V _t5776 = Call(cylPt_98, V.Undef, x_5749, z_5750, r_5751, ((V)(a_5772)), yy_5773);
{ V _t5777 = ListOf(_t5776);
{ V _t5778 = GetIdx(_t5777, 0D);
p_5774 = _t5778; }
{ V _t5779 = GetIdx(_t5777, 1D);
n_5775 = _t5779; }
} }
Call(spot_25, V.Undef, (LtN(Call(R_5657, V.Undef), 0.7) ? LN_5754 : LS_5755), p_5774, n_5775, ((V)((0.6 + (ToNum(Call(R_5657, V.Undef)) * 1.6)))), ((V)((0.16 + (ToNum(Call(R_5657, V.Undef)) * 0.16)))), ((V)(0D)), ((V)(6D)));
return default;
}, 0, "", true));
Call(rep_29, V.Undef, ((V)(Max(1D, Round((ToNum(h_5753) / 30D))))), Fn((V _arrowThis5786, int _argc5780, V _a5782, V _a5783, V _a5784, V _a5785, V[] _rest5781) => {
double a_5787 = 0;
V yy_5788 = default;
V p_5789 = default;
V n_5790 = default;
V p2_5791 = default;
V p3_5792 = default;
a_5787 = ((ToNum(Call(R_5657, V.Undef)) * 2D) * PI_22);
yy_5788 = Add(Add(y_5752, ((V)(6D))), ((V)((ToNum(Call(R_5657, V.Undef)) * (ToNum(h_5753) - 12D)))));
{ V _t5793 = Call(cylPt_98, V.Undef, x_5749, z_5750, r_5751, ((V)(a_5787)), yy_5788);
{ V _t5794 = ListOf(_t5793);
{ V _t5795 = GetIdx(_t5794, 0D);
p_5789 = _t5795; }
{ V _t5796 = GetIdx(_t5794, 1D);
n_5790 = _t5796; }
} }
Call(spot_25, V.Undef, KN_5757, p_5789, n_5790, ((V)(1.8)), ((V)(0.9)), ((V)(0D)), ((V)(10D)));
{ V _t5797 = Call(cylPt_98, V.Undef, x_5749, z_5750, r_5751, ((V)((a_5787 - 0.25))), Add(yy_5788, ((V)(1.4))));
{ V _t5798 = ListOf(_t5797);
{ V _t5799 = GetIdx(_t5798, 0D);
p2_5791 = _t5799; }
} }
{ V _t5800 = Call(cylPt_98, V.Undef, x_5749, z_5750, r_5751, ((V)((a_5787 + 0.25))), Add(yy_5788, ((V)(1.4))));
{ V _t5801 = ListOf(_t5800);
{ V _t5802 = GetIdx(_t5801, 0D);
p3_5792 = _t5802; }
} }
Invoke(KN_5757, "line", Arr(p2_5791, Call(add_30, V.Undef, p_5789, Arr(((V)(0D)), ((V)(0.4)), ((V)(0D)))), p3_5792), n_5790, ((V)(0.35)));
return default;
}, 0, "", true));
Call(rep_29, V.Undef, ((V)(Round((ToNum(h_5753) / 16D)))), Fn((V _arrowThis5809, int _argc5803, V _a5805, V _a5806, V _a5807, V _a5808, V[] _rest5804) => {
double a_5810 = 0;
V yy_5811 = default;
a_5810 = ((ToNum(Call(R_5657, V.Undef)) * 2D) * PI_22);
yy_5811 = Add(Add(y_5752, ((V)(4D))), ((V)((ToNum(Call(R_5657, V.Undef)) * (ToNum(h_5753) - 8D)))));
Call(ringD_99, V.Undef, PE_5756, x_5749, z_5750, Add(r_5751, ((V)(0.05))), yy_5811, ((V)(0.45)), ((V)(6D)), ((V)(a_5810)), ((V)((a_5810 + 0.7))));
return default;
}, 0, "", true));
Call(on_5656, V.Undef, S0_5746, Arr(LS_5755, LN_5754, KN_5757, PE_5756));
return default;
}, 2, "", true));
SI_5662 = Call(cyl_14, V.Undef, ((V)(18D)), ((V)(10D)), ((V)((-8D))), ((V)(6.9)), ((V)(44D)), ((V)("#cdb58a")), NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("fab"))).V);
SD_5663 = Call(dec_24, V.Undef, ((V)("#9a8456")), NewObj(1).Put("op", ((V)(0.7))).V);
SL_5664 = Call(dec_24, V.Undef, ((V)("#efe0bc")), NewObj(1).Put("op", ((V)(0.5))).V);
Call(on_5656, V.Undef, GetIdx(LG_5661, 1D), Arr(SI_5662));
{
V y_5812 = default;
y_5812 = ((V)(10.6));
while (true) {
V y_5812_it = y_5812;
if (!(LtN(y_5812_it, 54D))) break;
V pts_5814 = default;
V nn_5815 = default;
pts_5814 = Arr();
nn_5815 = Arr();
Call(rep_29, V.Undef, ((V)(25D)), Fn((V _arrowThis5823, int _argc5816, V i_5822, V _a5819, V _a5820, V _a5821, V[] _rest5817) => {
double a_5824 = 0;
V p_5825 = default;
V n_5826 = default;
a_5824 = (((ToNum(i_5822) / 24D) * 2D) * PI_22);
{ V _t5827 = Call(cylPt_98, V.Undef, ((V)(18D)), ((V)((-8D))), ((V)(6.9)), ((V)(a_5824)), Add(y_5812_it, ((V)(((ToNum(i_5822) / 24D) * 0.9)))));
{ V _t5828 = ListOf(_t5827);
{ V _t5829 = GetIdx(_t5828, 0D);
p_5825 = _t5829; }
{ V _t5830 = GetIdx(_t5828, 1D);
n_5826 = _t5830; }
} }
Invoke(pts_5814, "push", p_5825);
Invoke(nn_5815, "push", n_5826);
return default;
}, 1, "", true));
Invoke((NumTruthy((Round((ToNum(y_5812_it) / 0.9)) % 2D)) ? SD_5663 : SL_5664), "line", pts_5814, nn_5815, ((V)(0.3)));
y_5812 = y_5812_it;
y_5812 = Add(y_5812, ((V)(0.9)));
}
}
Call(on_5656, V.Undef, SI_5662, Arr(SD_5663, SL_5664));
POD_5665 = Call(box_13, V.Undef, ((V)((-20D))), ((V)(40D)), ((V)(5D)), ((V)(30D)), ((V)(24D)), ((V)(28D)), FE_5653, NewObj(3).Put("r", ((V)(10D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V);
PC_5666 = Call(box_13, V.Undef, ((V)(22D)), ((V)(56D)), ((V)(16D)), ((V)(24D)), ((V)(3D)), ((V)(24D)), Call(shade_18, V.Undef, FE_5653, ((V)(1.05))), NewObj(2).Put("r", ((V)(11D))).Put("mat", ((V)("fab"))).V);
PT_5667 = Call(cyl_14, V.Undef, ((V)(18D)), ((V)(100D)), ((V)((-8D))), ((V)(17D)), ((V)(4D)), Call(shade_18, V.Undef, FE_5653, ((V)(1.05))), NewObj(2).Put("n", ((V)(22D))).Put("mat", ((V)("fab"))).V);
Invoke(o_5655, "push", POD_5665, PC_5666, PT_5667);
{
V HO_5831 = default;
V HR_5832 = default;
V STc_5833 = default;
double zf_5834 = 0;
V Q_5835 = default;
HO_5831 = Call(dec_24, V.Undef, ((V)("#2a2420")));
HR_5832 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, FE_5653, ((V)("#ffffff")), ((V)(0.35))));
STc_5833 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, FE_5653, ((V)("#ffffff")), ((V)(0.6))), NewObj(1).Put("op", ((V)(0.85))).V);
zf_5834 = ((5D + 14D) + 0.08);
Q_5835 = Call(rep_29, V.Undef, ((V)(20D)), Fn((V _arrowThis5843, int _argc5836, V i_5842, V _a5839, V _a5840, V _a5841, V[] _rest5837) => {
double a_5844 = 0;
a_5844 = (((ToNum(i_5842) / 20D) * 2D) * PI_22);
return Arr(((V)(((-20D) + (FdLibm.Cos(a_5844) * 7.5)))), ((V)((51D + (FdLibm.Sin(a_5844) * 7.8)))), ((V)(zf_5834)));
return default;
}, 1, "", true));
Invoke(HO_5831, "poly", Q_5835, Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(HR_5832, "line", Invoke(Q_5835, "concat", Arr(GetIdx(Q_5835, 0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(1.2)));
Call(rep_29, V.Undef, ((V)(20D)), Fn((V _arrowThis5852, int _argc5845, V i_5851, V _a5848, V _a5849, V _a5850, V[] _rest5846) => {
double a_5853 = 0;
double b_5854 = 0;
a_5853 = (((ToNum(Add(i_5851, ((V)(0.3)))) / 20D) * 2D) * PI_22);
b_5854 = (((ToNum(Add(i_5851, ((V)(0.7)))) / 20D) * 2D) * PI_22);
Invoke(STc_5833, "line", Arr(Arr(((V)(((-20D) + (FdLibm.Cos(a_5853) * 9.4)))), ((V)((51D + (FdLibm.Sin(a_5853) * 9.7)))), ((V)(zf_5834))), Arr(((V)(((-20D) + (FdLibm.Cos(b_5854) * 9.4)))), ((V)((51D + (FdLibm.Sin(b_5854) * 9.7)))), ((V)(zf_5834)))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(0.3)));
return default;
}, 1, "", true));
Call(on_5656, V.Undef, POD_5665, Invoke(Call(felt_5658, V.Undef, POD_5665), "concat", Arr(HO_5831, HR_5832, STc_5833)));
}
Call(on_5656, V.Undef, PC_5666, Call(felt_5658, V.Undef, PC_5666));
Call(on_5656, V.Undef, PT_5667, Call(felt_5658, V.Undef, PT_5667));
{
V ST_5855 = default;
ST_5855 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, FE_5653, ((V)("#ffffff")), ((V)(0.55))), NewObj(1).Put("op", ((V)(0.85))).V);
Call(rep_29, V.Undef, ((V)(36D)), Fn((V _arrowThis5863, int _argc5856, V i_5862, V _a5859, V _a5860, V _a5861, V[] _rest5857) => {
if (NumTruthy((ToNum(i_5862) % 2D))) {
return default;
}
Call(ringD_99, V.Undef, ST_5855, ((V)(18D)), ((V)((-8D))), ((V)(17D)), ((V)(101.8)), ((V)(0.3)), ((V)(2D)), ((V)((((ToNum(i_5862) / 36D) * 2D) * PI_22))), ((V)((((ToNum(Add(i_5862, ((V)(0.8)))) / 36D) * 2D) * PI_22))));
return default;
}, 1, "", true));
Call(on_5656, V.Undef, PT_5667, Arr(ST_5855));
}
BED_5668 = Fn((V _arrowThis5876, int _argc5864, V x_5870, V y_5871, V z_5872, V w_5873, V[] _rest5865) => {
V C_5877 = default;
V PW_5878 = default;
V d_5874 = default;
V c_5875 = default;
d_5874 = (_argc5864 > 4 ? _rest5865[0] : V.Undef);
c_5875 = (_argc5864 > 5 ? _rest5865[1] : V.Undef);
C_5877 = Call(cush_15, V.Undef, x_5870, y_5871, z_5872, w_5873, ((V)(5D)), d_5874, c_5875, NewObj(2).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V);
PW_5878 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, c_5875, ((V)(0.78))), NewObj(1).Put("op", ((V)(0.7))).V);
Invoke(Call(caps_50, V.Undef, C_5877, ((V)(2D))), "forEach", Fn((V _arrowThis5886, int _argc5879, V F_5885, V _a5882, V _a5883, V _a5884, V[] _rest5880) => {
V G_5887 = default;
G_5887 = Call(fr2_39, V.Undef, F_5885);
Call(spot_25, V.Undef, PW_5878, Invoke(G_5887, "at", ((V)(0D)), ((V)((-1D)))), Get(G_5887, "n"), ((V)(2.4)), ((V)(2D)), ((V)(0D)), ((V)(10D)));
Invoke(Arr(Arr(((V)((-2.6))), ((V)(2D))), Arr(((V)((-0.9))), ((V)(3.3))), Arr(((V)(0.9)), ((V)(3.3))), Arr(((V)(2.6)), ((V)(2D)))), "forEach", Fn((V _arrowThis5899, int _argc5888, V _a5890, V _a5891, V _a5892, V _a5893, V[] _rest5889) => {
V a_5896 = default;
V b_5898 = default;
{ V _t5894 = ListOf(_a5890);
{ V _t5895 = GetIdx(_t5894, 0D);
a_5896 = _t5895; }
{ V _t5897 = GetIdx(_t5894, 1D);
b_5898 = _t5897; }
}
return Call(spot_25, V.Undef, PW_5878, Invoke(G_5887, "at", a_5896, b_5898), Get(G_5887, "n"), ((V)(0.85)), ((V)(0.95)), ((V)(0D)), ((V)(8D)));
}, 1, "", true));
return default;
}, 1, "", true));
return new ArrBuilder().Add(C_5877).Add(PW_5878).Spread(Call(felt_5658, V.Undef, C_5877, ((V)(0.1)))).V;
return default;
}, 6, "", true);
{
V C1_5900 = default;
V d1_5901 = default;
V C2_5902 = default;
V d2_5903 = default;
{ V _t5904 = Call(BED_5668, V.Undef, ((V)(18D)), ((V)(104D)), ((V)((-8D))), ((V)(26D)), ((V)(24D)), Call(shade_18, V.Undef, FE_5653, ((V)(1.16))));
{ V _t5905 = ListOf(_t5904);
{ V _t5906 = GetIdx(_t5905, 0D);
C1_5900 = _t5906; }
d1_5901 = RestFrom(_t5905, 1);
} }
{ V _t5907 = Call(BED_5668, V.Undef, ((V)((-20D))), ((V)(64D)), ((V)(5D)), ((V)(24D)), ((V)(22D)), Call(shade_18, V.Undef, FE_5653, ((V)(1.16))));
{ V _t5908 = ListOf(_t5907);
{ V _t5909 = GetIdx(_t5908, 0D);
C2_5902 = _t5909; }
d2_5903 = RestFrom(_t5908, 1);
} }
Call(on_5656, V.Undef, PT_5667, Arr(C1_5900));
Call(on_5656, V.Undef, C1_5900, d1_5901);
Call(on_5656, V.Undef, POD_5665, Arr(C2_5902));
Call(on_5656, V.Undef, C2_5902, d2_5903);
}
Invoke(Arr(Arr(((V)(0.3)), ((V)(64D)), ((V)("#7aa35a"))), Arr(((V)(1.2)), ((V)(74D)), ((V)("#d9a441"))), Arr(((V)(2.4)), ((V)(60D)), ((V)("#c0603a"))), Arr(((V)(3.6)), ((V)(82D)), ((V)("#7aa35a"))), Arr(((V)(4.9)), ((V)(70D)), ((V)("#d9a441")))), "forEach", Fn((V _arrowThis5923, int _argc5910, V _a5912, V _a5913, V _a5914, V _a5915, V[] _rest5911) => {
V L_5924 = default;
V M_5925 = default;
V p0_5926 = default;
V n_5927 = default;
V t_5928 = default;
V up_5929 = default;
V Q_5930 = default;
V a_5918 = default;
V y_5920 = default;
V c_5922 = default;
{ V _t5916 = ListOf(_a5912);
{ V _t5917 = GetIdx(_t5916, 0D);
a_5918 = _t5917; }
{ V _t5919 = GetIdx(_t5916, 1D);
y_5920 = _t5919; }
{ V _t5921 = GetIdx(_t5916, 2D);
c_5922 = _t5921; }
}
L_5924 = Call(dec_24, V.Undef, c_5922);
M_5925 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, c_5922, ((V)(0.7))), NewObj(1).Put("op", ((V)(0.8))).V);
{ V _t5931 = Call(cylPt_98, V.Undef, ((V)(18D)), ((V)((-8D))), ((V)(6D)), a_5918, y_5920, ((V)(0.12)));
{ V _t5932 = ListOf(_t5931);
{ V _t5933 = GetIdx(_t5932, 0D);
p0_5926 = _t5933; }
{ V _t5934 = GetIdx(_t5932, 1D);
n_5927 = _t5934; }
} }
t_5928 = Call(nz_35, V.Undef, Call(cr_34, V.Undef, n_5927, Y3_37));
up_5929 = Arr(((V)(0D)), ((V)(1D)), ((V)(0D)));
Q_5930 = Call(rep_29, V.Undef, ((V)(12D)), Fn((V _arrowThis5942, int _argc5935, V i_5941, V _a5938, V _a5939, V _a5940, V[] _rest5936) => {
double s_5943 = 0;
double k_5944 = 0;
s_5943 = (((ToNum(i_5941) / 11D) * 2D) * PI_22);
k_5944 = Pow(FdLibm.Sin((s_5943 / 2D)), 1.2);
return Call(add_30, V.Undef, p0_5926, Call(add_30, V.Undef, Call(mul_32, V.Undef, up_5929, ((V)((((-FdLibm.Cos((s_5943 / 2D))) * 3.4) + 3.4)))), Call(mul_32, V.Undef, t_5928, ((V)(((FdLibm.Sin(s_5943) * 1.6) * (0.5 + (0.5 * k_5944))))))));
return default;
}, 1, "", true));
Invoke(L_5924, "poly", Q_5930, n_5927);
Invoke(M_5925, "line", Arr(p0_5926, Call(add_30, V.Undef, p0_5926, Call(mul_32, V.Undef, up_5929, ((V)(6.4))))), n_5927, ((V)(0.25)));
Call(on_5656, V.Undef, GetIdx(LG_5661, 1D), Arr(L_5924, M_5925));
return default;
}, 1, "", true));
{
V CO_5945 = default;
V BA_5946 = default;
V BS_5947 = default;
CO_5945 = Call(cyl_14, V.Undef, ((V)(30D)), ((V)(82.4)), ((V)(4D)), ((V)(0.35)), ((V)(17.6)), ((V)("#6b4a2a")), NewObj(1).Put("n", ((V)(5D))).V);
BA_5946 = Call(ball_12, V.Undef, ((V)(30D)), ((V)(76D)), ((V)(4D)), ((V)(3.4)), ((V)("#d9483b")), NewObj(4).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("mat", ((V)("fab"))).Put("shine", ((V)(0D))).V);
BS_5947 = Call(dec_24, V.Undef, ((V)("#f6e7c8")), NewObj(1).Put("op", ((V)(0.8))).V);
Invoke(o_5655, "push", CO_5945);
Call(on_5656, V.Undef, CO_5945, Arr(BA_5946));
Call(spot_25, V.Undef, BS_5947, Arr(((V)(30D)), ((V)(81D)), ((V)(7.3))), Call(nz_35, V.Undef, Arr(((V)(0D)), ((V)(0.4)), ((V)(1D)))), ((V)(0.9)), ((V)(0.9)), ((V)(0D)), ((V)(6D)));
Invoke(BS_5947, "line", Arr(Arr(((V)(27.5)), ((V)(78D)), ((V)(6.3))), Arr(((V)(32.5)), ((V)(79.5)), ((V)(6.3)))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(0.3)));
Call(on_5656, V.Undef, BA_5946, Arr(BS_5947));
}
return o_5655;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
chesRA_100 = Fn((V _arrowThis5956, int _argc5948, V o_5954, V P_5955, V _a5952, V _a5953, V[] _rest5949) => {
V F0_5957 = default;
V B_5958 = default;
V @out_5959 = default;
V rl_5960 = default;
V ab_5961 = default;
F0_5957 = Call(F0of_69, V.Undef, P_5955);
B_5958 = Invoke(Invoke(o_5954, "filter", Fn((V _arrowThis5977, int _argc5970, V S_5976, V _a5973, V _a5974, V _a5975, V[] _rest5971) => {
return (((S_5976 is var _t5978 && !Truthy(_t5978) ? _t5978 : Get(S_5976, "pts")) is var _t5979 && !Truthy(_t5979) ? _t5979 : Get(Get(S_5976, "pts"), "length")) is var _t5980 && !Truthy(_t5980) ? _t5980 : (!(Truthy(Get(S_5976, "par"))) ? V.True : V.False));
}, 1, "", true)), "map", Fn((V _arrowThis5969, int _argc5962, V S_5968, V _a5965, V _a5966, V _a5967, V[] _rest5963) => {
return NewObj(2).Put("S", S_5968).Put("L", Call(bbS_38, V.Undef, S_5968)).V;
}, 1, "", true));
@out_5959 = Arr();
rl_5960 = Invoke(B_5958, "find", Fn((V _arrowThis5988, int _argc5981, V b_5987, V _a5984, V _a5985, V _a5986, V[] _rest5982) => {
return (((SEq(Get(Get(b_5987, "S"), "col"), F0_5957) && GtN(GetIdx(Get(b_5987, "L"), 2D), 40D)) && ((ToNum(GetIdx(Get(b_5987, "L"), 1D)) - ToNum(GetIdx(Get(b_5987, "L"), 0D))) < 40D)) ? V.True : V.False);
}, 1, "", true));
ab_5961 = Invoke(B_5958, "find", Fn((V _arrowThis5996, int _argc5989, V b_5995, V _a5992, V _a5993, V _a5994, V[] _rest5990) => {
return (((SEq(Get(Get(b_5995, "S"), "col"), F0_5957) && LtN(GetIdx(Get(b_5995, "L"), 2D), 30D)) && ((ToNum(GetIdx(Get(b_5995, "L"), 1D)) - ToNum(GetIdx(Get(b_5995, "L"), 0D))) < 30D)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(rl_5960)) {
Invoke(@out_5959, "push", Object_assign(NewObj(1).Put("r", ((V)("roll"))).V, rl_5960));
}
if (Truthy(ab_5961)) {
Invoke(@out_5959, "push", Object_assign(NewObj(1).Put("r", ((V)("arm"))).V, ab_5961));
}
return @out_5959;
return default;
}, 2, "", true);
rollTop_101 = Fn((V _arrowThis6006, int _argc5997, V rl_6003, V z_6004, V yw_6005, V _a6002, V[] _rest5998) => {
V L_6007 = default;
double x_6008 = 0;
double y_6009 = 0;
double c_6010 = 0;
double s_6011 = 0;
L_6007 = Get(rl_6003, "L");
x_6008 = (ToNum(Add(GetIdx(L_6007, 0D), GetIdx(L_6007, 1D))) / 2D);
y_6009 = (ToNum(GetIdx(L_6007, 3D)) - 0.15);
c_6010 = FdLibm.Cos(ToNum((yw_6005 is var _t6012 && Truthy(_t6012) ? _t6012 : ((V)(0D)))));
s_6011 = FdLibm.Sin(ToNum((yw_6005 is var _t6013 && Truthy(_t6013) ? _t6013 : ((V)(0D)))));
return NewObj(3).Put("x", ((V)(x_6008))).Put("y", ((V)(y_6009))).Put("Pt", Fn((V _arrowThis6023, int _argc6014, V a_6020, V b_6021, V yy_6022, V _a6019, V[] _rest6015) => {
return Arr(((V)(((x_6008 + (ToNum(a_6020) * c_6010)) + (ToNum(b_6021) * s_6011)))), (yy_6022.IsNullish ? ((V)(y_6009)) : yy_6022), ((V)(((ToNum(z_6004) - (ToNum(a_6020) * s_6011)) + (ToNum(b_6021) * c_6010)))));
}, 3, "Pt", true)).V;
return default;
}, 3, "", true);
velX_102 = Fn((V _arrowThis6033, int _argc6024, V o_6030, V P_6031, V li_6032, V _a6029, V[] _rest6025) => {
if (SEqN(li_6032, 1D)) {
Call(armThrow_89, V.Undef, o_6030, Call(chesRA_100, V.Undef, o_6030, P_6031), ((V)((-1D))), ((V)("#e2d3b8")), ((V)(1D)));
}
return default;
}, 3, "", true);
leaX_103 = Fn((V _arrowThis6043, int _argc6034, V o_6040, V P_6041, V li_6042, V _a6039, V[] _rest6035) => {
if (SEqN(li_6042, 1D)) {
V ab_6044 = default;
Call(armThrow_89, V.Undef, o_6040, Call(chesRA_100, V.Undef, o_6040, P_6041), ((V)((-1D))), ((V)("#8e2f2a")), ((V)(1D)));
ab_6044 = Invoke(Call(chesRA_100, V.Undef, o_6040, P_6041), "find", Fn((V _arrowThis6052, int _argc6045, V b_6051, V _a6048, V _a6049, V _a6050, V[] _rest6046) => {
return (SEqS(Get(b_6051, "r"), "arm") ? V.True : V.False);
}, 1, "", true));
}
if (SEqN(li_6042, 3D)) {
V rl_6053 = default;
V on_6054 = default;
V T_6055 = default;
V BK_6056 = default;
V PG_6057 = default;
V GD_6058 = default;
V GL_6059 = default;
V LN_6060 = default;
V yt_6061 = default;
rl_6053 = Invoke(Call(chesRA_100, V.Undef, o_6040, P_6041), "find", Fn((V _arrowThis6069, int _argc6062, V b_6068, V _a6065, V _a6066, V _a6067, V[] _rest6063) => {
return (SEqS(Get(b_6068, "r"), "roll") ? V.True : V.False);
}, 1, "", true));
if (!(Truthy(rl_6053))) {
return default;
}
on_6054 = Call(glue_27, V.Undef, o_6040);
T_6055 = Call(rollTop_101, V.Undef, rl_6053, ((V)(8D)), ((V)((-0.3))));
BK_6056 = Call(box_13, V.Undef, Get(T_6055, "x"), Get(T_6055, "y"), ((V)(8D)), ((V)(11D)), ((V)(3.2)), ((V)(15D)), ((V)("#3a2418")), NewObj(3).Put("r", ((V)(0.6))).Put("yaw", ((V)((-0.3)))).Put("mat", ((V)("lea"))).V);
PG_6057 = Call(dec_24, V.Undef, ((V)("#f1e6cc")));
GD_6058 = Call(dec_24, V.Undef, ((V)("#e2b14a")), NewObj(1).Put("shine", ((V)(1D))).V);
GL_6059 = Call(dec_24, V.Undef, ((V)("#2a2a2e")));
LN_6060 = Call(dec_24, V.Undef, ((V)("#cfe8f2")), NewObj(1).Put("op", ((V)(0.5))).V);
yt_6061 = Add(Get(T_6055, "y"), ((V)(3.25)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis6077, int _argc6070, V sg_6076, V _a6073, V _a6074, V _a6075, V[] _rest6071) => {
return Call(rep_29, V.Undef, ((V)(2D)), Fn((V _arrowThis6085, int _argc6078, V k_6084, V _a6081, V _a6082, V _a6083, V[] _rest6079) => {
return Invoke(GD_6058, "line", Arr(Invoke(T_6055, "Pt", ((V)((-5.4))), ((V)((ToNum(sg_6076) * (5D - (ToNum(k_6084) * 1.2))))), yt_6061), Invoke(T_6055, "Pt", ((V)(5.4)), ((V)((ToNum(sg_6076) * (5D - (ToNum(k_6084) * 1.2))))), yt_6061)), Y3_37, ((V)(0.3)));
}, 1, "", true));
}, 1, "", true));
Call(spot_25, V.Undef, GD_6058, Invoke(T_6055, "Pt", ((V)(0D)), ((V)(0D)), yt_6061), Y3_37, ((V)(2D)), ((V)(2.4)), ((V)(0D)), ((V)(10D)));
Invoke(Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(0D)), ((V)(0D)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D)))), "forEach", Fn((V _arrowThis6092, int _argc6086, V _a6088, V _a6089, V _a6090, V _a6091, V[] _rest6087) => {

return default;
}, 0, "", true));
Invoke(Call(sides_51, V.Undef, BK_6056, ((V)(1D))), "forEach", Fn((V _arrowThis6100, int _argc6093, V F_6099, V _a6096, V _a6097, V _a6098, V[] _rest6094) => {
if (((System.Math.Abs(ToNum(GetIdx(Get(F_6099, "n"), 1D))) < 0.3) && GtN(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_31, V.Undef, GetIdx(Get(F_6099, "q"), 1D), GetIdx(Get(F_6099, "q"), 0D))).V), 3D))) {
Call(hatch_45, V.Undef, PG_6057, F_6099, ((V)(0D)), ((V)(0.5)), ((V)(0.18)), NewObj(1).Put("sh", ((V)(0.8))).V);
}
return default;
}, 1, "", true));
Invoke(Arr(((V)((-2.2))), ((V)(2.2))), "forEach", Fn((V _arrowThis6108, int _argc6101, V a_6107, V _a6104, V _a6105, V _a6106, V[] _rest6102) => {
V c0_6109 = default;
c0_6109 = Invoke(T_6055, "Pt", Add(a_6107, ((V)(0.5))), ((V)((-2D))), Add(yt_6061, ((V)(0.1))));
Call(spot_25, V.Undef, LN_6060, c0_6109, Y3_37, ((V)(1.6)), ((V)(1.3)), ((V)(0D)), ((V)(12D)));
Invoke(GL_6059, "line", Call(rep_29, V.Undef, ((V)(13D)), Fn((V _arrowThis6117, int _argc6110, V i_6116, V _a6113, V _a6114, V _a6115, V[] _rest6111) => {
double t_6118 = 0;
t_6118 = (((ToNum(i_6116) / 12D) * 2D) * PI_22);
return Call(add_30, V.Undef, c0_6109, Arr(((V)((FdLibm.Cos(t_6118) * 1.7))), ((V)(0D)), ((V)((FdLibm.Sin(t_6118) * 1.4)))));
return default;
}, 1, "", true)), Y3_37, ((V)(0.3)));
return default;
}, 1, "", true));
Invoke(GL_6059, "line", Arr(Invoke(T_6055, "Pt", ((V)((-0.6))), ((V)((-2D))), Add(yt_6061, ((V)(0.1)))), Invoke(T_6055, "Pt", ((V)(0.6)), ((V)((-2D))), Add(yt_6061, ((V)(0.1))))), Y3_37, ((V)(0.25)));
Invoke(GL_6059, "line", Arr(Invoke(T_6055, "Pt", ((V)((-3.8))), ((V)((-2D))), Add(yt_6061, ((V)(0.1)))), Invoke(T_6055, "Pt", ((V)((-4.6))), ((V)(4D)), Add(yt_6061, ((V)(0.1))))), Y3_37, ((V)(0.22)));
Invoke(GL_6059, "line", Arr(Invoke(T_6055, "Pt", ((V)(4.4)), ((V)((-2D))), Add(yt_6061, ((V)(0.1)))), Invoke(T_6055, "Pt", ((V)(5.2)), ((V)(4D)), Add(yt_6061, ((V)(0.1))))), Y3_37, ((V)(0.22)));
Call(on_6054, V.Undef, Get(rl_6053, "S"), Arr(BK_6056));
Call(on_6054, V.Undef, BK_6056, Arr(PG_6057, GD_6058, LN_6060, GL_6059));
}
return default;
}, 3, "", true);
bouX_104 = Fn((V _arrowThis6128, int _argc6119, V o_6125, V P_6126, V li_6127, V _a6124, V[] _rest6120) => {
if (SEqN(li_6127, 1D)) {
Call(armThrow_89, V.Undef, o_6125, Call(chesRA_100, V.Undef, o_6125, P_6126), ((V)((-1D))), ((V)("#f4efe4")), ((V)("fur")));
}
if (SEqN(li_6127, 3D)) {
V rl_6129 = default;
V on_6130 = default;
V T_6131 = default;
V TR_6132 = default;
V CA_6133 = default;
V MB_6134 = default;
V PO_6135 = default;
V FL_6136 = default;
V FC_6137 = default;
V WK_6138 = default;
V MS_6139 = default;
V top_6140 = default;
rl_6129 = Invoke(Call(chesRA_100, V.Undef, o_6125, P_6126), "find", Fn((V _arrowThis6148, int _argc6141, V b_6147, V _a6144, V _a6145, V _a6146, V[] _rest6142) => {
return (SEqS(Get(b_6147, "r"), "roll") ? V.True : V.False);
}, 1, "", true));
if (!(Truthy(rl_6129))) {
return default;
}
on_6130 = Call(glue_27, V.Undef, o_6125);
T_6131 = Call(rollTop_101, V.Undef, rl_6129, ((V)(10D)), ((V)(0.2)));
TR_6132 = Call(box_13, V.Undef, Get(T_6131, "x"), Get(T_6131, "y"), ((V)(10D)), ((V)(12D)), ((V)(1.4)), ((V)(16D)), ((V)("#e3d6bf")), NewObj(3).Put("r", ((V)(1.5))).Put("yaw", ((V)(0.2))).Put("mat", ((V)("stone"))).V);
CA_6133 = Call(cyl_14, V.Undef, ((V)((ToNum(Get(T_6131, "x")) - 1.5))), Add(Get(T_6131, "y"), ((V)(1.4))), ((V)(7D)), ((V)(2.6)), ((V)(4.6)), ((V)("#f7f2e8")), NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("cer"))).V);
MB_6134 = Call(box_13, V.Undef, Add(Get(T_6131, "x"), ((V)(2.2))), Add(Get(T_6131, "y"), ((V)(1.4))), ((V)(13D)), ((V)(3.4)), ((V)(1.2)), ((V)(5D)), ((V)("#2a2a2e")), NewObj(2).Put("r", ((V)(0.4))).Put("yaw", ((V)(0.5))).V);
PO_6135 = Call(dec_24, V.Undef, ((V)("#b8a888")), NewObj(1).Put("op", ((V)(0.6))).V);
FL_6136 = Call(dec_24, V.Undef, ((V)("#ffcf7a")), NewObj(1).Put("emit", ((V)(1D))).V);
FC_6137 = Call(dec_24, V.Undef, ((V)("#fff4d0")), NewObj(1).Put("emit", ((V)(1D))).V);
WK_6138 = Call(dec_24, V.Undef, ((V)("#3a2a1c")));
MS_6139 = Call(dec_24, V.Undef, ((V)("#c9a35a")));
Invoke(Call(caps_50, V.Undef, TR_6132, ((V)(2D))), "forEach", Fn((V _arrowThis6156, int _argc6149, V F_6155, V _a6152, V _a6153, V _a6154, V[] _rest6150) => {
return Call(fleck_83, V.Undef, PO_6135, PO_6135, F_6155, Call(R0_28, V.Undef, ((V)("tr25"))), ((V)(0.25)), ((V)(0.3)));
}, 1, "", true));
top_6140 = Add(Get(T_6131, "y"), ((V)(6.05)));
Call(spot_25, V.Undef, WK_6138, Arr(((V)((ToNum(Get(T_6131, "x")) - 1.5))), top_6140, ((V)(7D))), Y3_37, ((V)(0.25)), ((V)(0.25)), ((V)(0D)), ((V)(5D)));
Invoke(FL_6136, "poly", Call(rep_29, V.Undef, ((V)(10D)), Fn((V _arrowThis6164, int _argc6157, V i_6163, V _a6160, V _a6161, V _a6162, V[] _rest6158) => {
double a_6165 = 0;
a_6165 = (((ToNum(i_6163) / 10D) * 2D) * PI_22);
return Arr(((V)(((ToNum(Get(T_6131, "x")) - 1.5) + (FdLibm.Sin(a_6165) * 0.8)))), ((V)(((ToNum(Add(top_6140, ((V)(1.6)))) - (FdLibm.Cos(a_6165) * 1.6)) + ((FdLibm.Cos(a_6165) < 0D) ? ((-FdLibm.Cos(a_6165)) * 1.2) : 0D)))), ((V)(7.3)));
return default;
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(spot_25, V.Undef, FC_6137, Arr(((V)((ToNum(Get(T_6131, "x")) - 1.5))), Add(top_6140, ((V)(0.9))), ((V)(7.35))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(0.4)), ((V)(0.7)), ((V)(0D)), ((V)(8D)));
Invoke(MS_6139, "line", Arr(Arr(Add(Get(T_6131, "x"), ((V)(1.2))), Add(Get(T_6131, "y"), ((V)(2.65))), ((V)(12D))), Arr(Add(Get(T_6131, "x"), ((V)(3.4))), Add(Get(T_6131, "y"), ((V)(2.65))), ((V)(14D)))), Y3_37, ((V)(0.6)));
Call(on_6130, V.Undef, Get(rl_6129, "S"), Arr(TR_6132));
Call(on_6130, V.Undef, TR_6132, Arr(PO_6135, CA_6133, MB_6134));
Call(on_6130, V.Undef, CA_6133, Arr(WK_6138, FL_6136, FC_6137));
Call(on_6130, V.Undef, MB_6134, Arr(MS_6139));
}
return default;
}, 3, "", true);
chesX_105 = Fn((V _arrowThis6174, int _argc6166, V lf_6172, V xf_6173, V _a6170, V _a6171, V[] _rest6167) => {
return Fn((V _arrowThis6184, int _argc6175, V o_6181, V P_6182, V li_6183, V _a6180, V[] _rest6176) => {
Call(lf_6172, V.Undef, o_6181, P_6182, li_6183);
Call(xf_6173, V.Undef, o_6181, P_6182, li_6183);
return default;
}, 3, "", true);
}, 2, "", true);
Set(N_21, "chester25V2", Fn((V _arrowThis6192, int _argc6185, V S_6191, V _a6188, V _a6189, V _a6190, V[] _rest6186) => {
return Call(chesWrap_68, V.Undef, S_6191, Call(chesX_105, V.Undef, velTex_94, velX_102), leaBase_71);
}, 1, "", true));
Set(N_21, "chester25L2", Fn((V _arrowThis6200, int _argc6193, V S_6199, V _a6196, V _a6197, V _a6198, V[] _rest6194) => {
return Call(chesWrap_68, V.Undef, S_6199, Call(chesX_105, V.Undef, leaTex_70, leaX_103), leaBase_71);
}, 1, "", true));
Set(N_21, "chester25B2", Fn((V _arrowThis6208, int _argc6201, V S_6207, V _a6204, V _a6205, V _a6206, V[] _rest6202) => {
return Call(chesWrap_68, V.Undef, S_6207, Call(chesX_105, V.Undef, bouTex_72, bouX_104), bouBase_73);
}, 1, "", true));
AL62_106 = Arr(((V)("#fbe8c8")), ((V)("#f7dcb6")), ((V)("#fdeed6")));
Set(N_21, "alab25b", Call(texWrap_78, V.Undef, ((V)("alab24")), ((V)("ala")), NewObj(0).V, Fn((V _arrowThis6217, int _argc6209, V o_6215, V P_6216, V _a6213, V _a6214, V[] _rest6210) => {
V on_6218 = default;
V R_6219 = default;
V @base_6220 = default;
on_6218 = Call(glue_27, V.Undef, o_6215);
R_6219 = Call(R0_28, V.Undef, ((V)("al25b")));
Invoke(Invoke(o_6215, "filter", Fn((V _arrowThis6275, int _argc6268, V S_6274, V _a6271, V _a6272, V _a6273, V[] _rest6269) => {
return (((S_6274 is var _t6276 && !Truthy(_t6276) ? _t6276 : Get(S_6274, "pts")) is var _t6277 && !Truthy(_t6277) ? _t6277 : (!(Truthy(Get(S_6274, "par"))) ? V.True : V.False)) is var _t6278 && !Truthy(_t6278) ? _t6278 : Invoke(AL62_106, "includes", Get(S_6274, "col")));
}, 1, "", true)), "forEach", Fn((V _arrowThis6229, int _argc6221, V S_6227, V i_6228, V _a6225, V _a6226, V[] _rest6222) => {
V VA_6230 = default;
V VW_6231 = default;
V CK_6232 = default;
V CL_6233 = default;
V GC_6234 = default;
VA_6230 = Call(dec_24, V.Undef, ((V)("#d9a066")), NewObj(1).Put("op", ((V)(0.55))).V);
VW_6231 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.6))).V);
CK_6232 = Call(dec_24, V.Undef, ((V)("#c4a47c")), NewObj(1).Put("op", ((V)(0.45))).V);
CL_6233 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.45))).V);
GC_6234 = Call(dec_24, V.Undef, ((V)("#ffd9a0")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.35))).V);
Invoke(Get(S_6227, "faces"), "forEach", Fn((V _arrowThis6242, int _argc6235, V F_6241, V _a6238, V _a6239, V _a6240, V[] _rest6236) => {
if (!(Truthy(Call(bigF_82, V.Undef, F_6241, ((V)(4D)))))) {
return default;
}
Call(hatch_45, V.Undef, VA_6230, F_6241, ((V)((0.35 + (ToNum(i_6228) * 0.4)))), ((V)(6.5)), ((V)(0.32)), NewObj(2).Put("sh", ((V)(0.97))).Put("ph", ((V)((ToNum(i_6228) * 1.7)))).V);
Call(hatch_45, V.Undef, VW_6231, F_6241, ((V)(((-0.5) + (ToNum(i_6228) * 0.3)))), ((V)(9D)), ((V)(0.42)), NewObj(2).Put("sh", ((V)(0.97))).Put("ph", ((V)((ToNum(i_6228) * 2.3)))).V);
Call(fleck_83, V.Undef, CL_6233, CL_6233, F_6241, R_6219, ((V)(0.03)), ((V)(0.9)));
if (LtN(Call(R_6219, V.Undef), 0.12)) {
Call(wavy_46, V.Undef, CK_6232, F_6241, Fn((V _arrowThis6251, int _argc6243, V t_6249, V G_6250, V _a6247, V _a6248, V[] _rest6244) => {
V W_6252 = default;
V H_6253 = default;
{ V _t6254 = Call(WH2_84, V.Undef, G_6250);
{ V _t6255 = ListOf(_t6254);
{ V _t6256 = GetIdx(_t6255, 0D);
W_6252 = _t6256; }
{ V _t6257 = GetIdx(_t6255, 1D);
H_6253 = _t6257; }
} }
return Arr(((V)((((-ToNum(W_6252)) * 0.4) + ((ToNum(W_6252) * 0.8) * ToNum(t_6249))))), ((V)((((ToNum(Call(R_6219, V.Undef)) - 0.5) * 0.4) + (FdLibm.Sin((ToNum(t_6249) * 9D)) * 0.5)))));
return default;
}, 2, "", true), ((V)(10D)), ((V)(0.18)));
}
return default;
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, S_6227, ((V)(2D))), "forEach", Fn((V _arrowThis6265, int _argc6258, V F_6264, V _a6261, V _a6262, V _a6263, V[] _rest6259) => {
if (Truthy(((GtN(GetIdx(Get(F_6264, "n"), 2D), 0.6) ? V.True : V.False) is var _t6266 && !Truthy(_t6266) ? _t6266 : Call(bigF_82, V.Undef, F_6264, ((V)(20D)))))) {
V G_6267 = default;
G_6267 = Call(fr2_39, V.Undef, F_6264);
Call(spot_25, V.Undef, GC_6234, Invoke(G_6267, "at", ((V)(0D)), ((V)(0D))), Get(G_6267, "n"), ((V)(2.2)), ((V)(3D)), ((V)(0D)), ((V)(10D)));
}
return default;
}, 1, "", true));
Call(on_6218, V.Undef, S_6227, Arr(GC_6234, VA_6230, VW_6231, CL_6233, CK_6232));
return default;
}, 2, "", true));
@base_6220 = GetIdx(Invoke(Invoke(Invoke(o_6215, "filter", Fn((V _arrowThis6303, int _argc6296, V S_6302, V _a6299, V _a6300, V _a6301, V[] _rest6297) => {
return (((S_6302 is var _t6304 && !Truthy(_t6304) ? _t6304 : Get(S_6302, "pts")) is var _t6305 && !Truthy(_t6305) ? _t6305 : (!(Truthy(Get(S_6302, "par"))) ? V.True : V.False)) is var _t6306 && !Truthy(_t6306) ? _t6306 : (SEqS(Get(S_6302, "mat"), "metal") ? V.True : V.False));
}, 1, "", true)), "map", Fn((V _arrowThis6295, int _argc6288, V S_6294, V _a6291, V _a6292, V _a6293, V[] _rest6289) => {
return NewObj(2).Put("S", S_6294).Put("L", Call(bbS_38, V.Undef, S_6294)).V;
}, 1, "", true)), "sort", Fn((V _arrowThis6287, int _argc6279, V a_6285, V b_6286, V _a6283, V _a6284, V[] _rest6280) => {
return ((V)(((ToNum(GetIdx(Get(b_6286, "L"), 1D)) - ToNum(GetIdx(Get(b_6286, "L"), 0D))) - (ToNum(GetIdx(Get(a_6285, "L"), 1D)) - ToNum(GetIdx(Get(a_6285, "L"), 0D))))));
}, 2, "", true)), 0D);
if (Truthy(@base_6220)) {
V PT_6307 = default;
V CH_6308 = default;
V L_6309 = default;
double r_6310 = 0;
double cx_6311 = 0;
double cz_6312 = 0;
V CD_6313 = default;
V DM_6314 = default;
V DK_6315 = default;
double a0_6316 = 0;
V p0_6317 = default;
V dm_6318 = default;
PT_6307 = Call(dec_24, V.Undef, ((V)("#5f8a72")), NewObj(1).Put("op", ((V)(0.35))).V);
CH_6308 = Call(dec_24, V.Undef, ((V)("#4a321e")), NewObj(1).Put("op", ((V)(0.5))).V);
L_6309 = Get(@base_6220, "L");
r_6310 = ((ToNum(GetIdx(L_6309, 1D)) - ToNum(GetIdx(L_6309, 0D))) / 2D);
cx_6311 = (ToNum(Add(GetIdx(L_6309, 0D), GetIdx(L_6309, 1D))) / 2D);
cz_6312 = (ToNum(Add(GetIdx(L_6309, 4D), GetIdx(L_6309, 5D))) / 2D);
Invoke(Get(Get(@base_6220, "S"), "faces"), "forEach", Fn((V _arrowThis6326, int _argc6319, V F_6325, V _a6322, V _a6323, V _a6324, V[] _rest6320) => {
if (Truthy(Call(bigF_82, V.Undef, F_6325, ((V)(3D))))) {
Call(fleck_83, V.Undef, PT_6307, PT_6307, F_6325, R_6219, ((V)(0.12)), ((V)(0.45)));
}
return default;
}, 1, "", true));
Call(rep_29, V.Undef, ((V)(28D)), Fn((V _arrowThis6334, int _argc6327, V i_6333, V _a6330, V _a6331, V _a6332, V[] _rest6328) => {
double a_6335 = 0;
V p_6336 = default;
V n_6337 = default;
a_6335 = (((ToNum(i_6333) / 28D) * 2D) * PI_22);
{ V _t6338 = Call(cylPt_98, V.Undef, ((V)(cx_6311)), ((V)(cz_6312)), ((V)((r_6310 - 0.2))), ((V)(a_6335)), ((V)((ToNum(Add(GetIdx(L_6309, 2D), GetIdx(L_6309, 3D))) / 2D))));
{ V _t6339 = ListOf(_t6338);
{ V _t6340 = GetIdx(_t6339, 0D);
p_6336 = _t6340; }
{ V _t6341 = GetIdx(_t6339, 1D);
n_6337 = _t6341; }
} }
Invoke(CH_6308, "line", Arr(Call(add_30, V.Undef, p_6336, Arr(((V)(0D)), ((V)((-0.8))), ((V)(0D)))), Call(add_30, V.Undef, p_6336, Arr(((V)(0D)), ((V)(0.8)), ((V)(0D))))), n_6337, ((V)(0.2)));
return default;
}, 1, "", true));
CD_6313 = Call(dec_24, V.Undef, ((V)("#2a2a2e")));
DM_6314 = Call(dec_24, V.Undef, ((V)("#f4f2ee")));
DK_6315 = Call(dec_24, V.Undef, ((V)("#9aa1a6")));
a0_6316 = (PI_22 * 0.25);
{ V _t6342 = Call(cylPt_98, V.Undef, ((V)(cx_6311)), ((V)(cz_6312)), ((V)(r_6310)), ((V)(a0_6316)), Add(GetIdx(L_6309, 2D), ((V)(0.6))));
{ V _t6343 = ListOf(_t6342);
{ V _t6344 = GetIdx(_t6343, 0D);
p0_6317 = _t6344; }
} }
Invoke(CD_6313, "line", Arr(p0_6317, Call(add_30, V.Undef, p0_6317, Arr(((V)(3D)), ((V)((-0.55))), ((V)(3D)))), Call(add_30, V.Undef, p0_6317, Arr(((V)(9D)), ((V)((-0.55))), ((V)(6D)))), Call(add_30, V.Undef, p0_6317, Arr(((V)(14D)), ((V)((-0.55))), ((V)(12D))))), Y3_37, ((V)(0.6)));
dm_6318 = Call(add_30, V.Undef, p0_6317, Arr(((V)(9D)), ((V)((-0.5))), ((V)(6D))));
Invoke(DM_6314, "poly", Arr(Call(add_30, V.Undef, dm_6318, Arr(((V)((-1.6))), ((V)(0D)), ((V)((-1D))))), Call(add_30, V.Undef, dm_6318, Arr(((V)(1.6)), ((V)(0D)), ((V)((-1D))))), Call(add_30, V.Undef, dm_6318, Arr(((V)(1.6)), ((V)(0D)), ((V)(1.4)))), Call(add_30, V.Undef, dm_6318, Arr(((V)((-1.6))), ((V)(0D)), ((V)(1.4))))), Y3_37);
Call(spot_25, V.Undef, DK_6315, Call(add_30, V.Undef, dm_6318, Arr(((V)(0D)), ((V)(0.05)), ((V)(0.2)))), Y3_37, ((V)(0.7)), ((V)(0.7)), ((V)(0D)), ((V)(8D)));
Call(on_6218, V.Undef, Get(@base_6220, "S"), Arr(PT_6307, CH_6308, CD_6313, DM_6314, DK_6315));
}
return default;
}, 2, "", true)));
Set(N_21, "spool25", Call(texWrap_78, V.Undef, ((V)("spool22")), ((V)("spl")), NewObj(0).V, Fn((V _arrowThis6353, int _argc6345, V o_6351, V P_6352, V _a6349, V _a6350, V[] _rest6346) => {
V on_6354 = default;
V R_6355 = default;
V B_6356 = default;
V discs_6357 = default;
V top_6358 = default;
V TY_6359 = default;
V RS_6360 = default;
V SPL_6361 = default;
V CN_6362 = default;
V SO_6363 = default;
V LB_6364 = default;
V LW_6365 = default;
V RB_6366 = default;
V SU_6367 = default;
V NP_6368 = default;
V NT_6369 = default;
V NH_6370 = default;
V CS_6371 = default;
on_6354 = Call(glue_27, V.Undef, o_6351);
R_6355 = Call(R0_28, V.Undef, ((V)("sp25b")));
{
V mg_6372 = default;
mg_6372 = Invoke(Invoke(Invoke(o_6351, "filter", Fn((V _arrowThis6397, int _argc6390, V S_6396, V _a6393, V _a6394, V _a6395, V[] _rest6391) => {
return (((S_6396 is var _t6398 && !Truthy(_t6398) ? _t6398 : Get(S_6396, "pts")) is var _t6399 && !Truthy(_t6399) ? _t6399 : (!(Truthy(Get(S_6396, "par"))) ? V.True : V.False)) is var _t6400 && !Truthy(_t6400) ? _t6400 : (SEqS(Get(S_6396, "col"), "#3f7fc8") ? V.True : V.False));
}, 1, "", true)), "map", Fn((V _arrowThis6389, int _argc6382, V S_6388, V _a6385, V _a6386, V _a6387, V[] _rest6383) => {
return NewObj(2).Put("S", S_6388).Put("L", Call(bbS_38, V.Undef, S_6388)).V;
}, 1, "", true)), "sort", Fn((V _arrowThis6381, int _argc6373, V a_6379, V b_6380, V _a6377, V _a6378, V[] _rest6374) => {
return ((V)((((ToNum(GetIdx(Get(b_6380, "L"), 1D)) - ToNum(GetIdx(Get(b_6380, "L"), 0D))) * (ToNum(GetIdx(Get(b_6380, "L"), 3D)) - ToNum(GetIdx(Get(b_6380, "L"), 2D)))) - ((ToNum(GetIdx(Get(a_6379, "L"), 1D)) - ToNum(GetIdx(Get(a_6379, "L"), 0D))) * (ToNum(GetIdx(Get(a_6379, "L"), 3D)) - ToNum(GetIdx(Get(a_6379, "L"), 2D)))))));
}, 2, "", true));
Invoke(Invoke(mg_6372, "slice", ((V)(1D))), "forEach", Fn((V _arrowThis6408, int _argc6401, V b_6407, V _a6404, V _a6405, V _a6406, V[] _rest6402) => {
Set(Get(b_6407, "S"), "par", Get(GetIdx(mg_6372, 0D), "S"));
return default;
}, 1, "", true));
}
B_6356 = Invoke(Invoke(o_6351, "filter", Fn((V _arrowThis6424, int _argc6417, V S_6423, V _a6420, V _a6421, V _a6422, V[] _rest6418) => {
return ((S_6423 is var _t6425 && !Truthy(_t6425) ? _t6425 : Get(S_6423, "pts")) is var _t6426 && !Truthy(_t6426) ? _t6426 : (!(Truthy(Get(S_6423, "par"))) ? V.True : V.False));
}, 1, "", true)), "map", Fn((V _arrowThis6416, int _argc6409, V S_6415, V _a6412, V _a6413, V _a6414, V[] _rest6410) => {
return NewObj(2).Put("S", S_6415).Put("L", Call(bbS_38, V.Undef, S_6415)).V;
}, 1, "", true));
discs_6357 = Invoke(Invoke(B_6356, "filter", Fn((V _arrowThis6443, int _argc6436, V b_6442, V _a6439, V _a6440, V _a6441, V[] _rest6437) => {
return (((ToNum(GetIdx(Get(b_6442, "L"), 1D)) - ToNum(GetIdx(Get(b_6442, "L"), 0D))) > 80D) ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _arrowThis6435, int _argc6427, V a_6433, V b_6434, V _a6431, V _a6432, V[] _rest6428) => {
return ((V)((ToNum(GetIdx(Get(b_6434, "L"), 3D)) - ToNum(GetIdx(Get(a_6433, "L"), 3D)))));
}, 2, "", true));
top_6358 = GetIdx(discs_6357, 0D);
if (!(Truthy(top_6358))) {
return default;
}
Invoke(discs_6357, "forEach", Fn((V _arrowThis6452, int _argc6444, V _a6446, V _a6447, V _a6448, V _a6449, V[] _rest6445) => {
V PL_6453 = default;
V PH_6454 = default;
V S_6451 = default;
if (_a6446.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a6446));
{ V _t6450 = Get(_a6446, "S");
S_6451 = _t6450; }
PL_6453 = Call(dec_24, V.Undef, ((V)("#8a6438")), NewObj(1).Put("op", ((V)(0.45))).V);
PH_6454 = Call(dec_24, V.Undef, ((V)("#f0d29e")), NewObj(1).Put("op", ((V)(0.35))).V);
Invoke(Call(sides_51, V.Undef, S_6451, ((V)(1D))), "forEach", Fn((V _arrowThis6462, int _argc6455, V F_6461, V _a6458, V _a6459, V _a6460, V[] _rest6456) => {
if ((System.Math.Abs(ToNum(GetIdx(Get(F_6461, "n"), 1D))) < 0.4)) {
Call(hatch_45, V.Undef, Arr(PL_6453, PH_6454), F_6461, ((V)(0D)), ((V)(0.9)), ((V)(0.16)), NewObj(1).Put("sh", ((V)(0.99))).V);
}
return default;
}, 1, "", true));
Call(on_6354, V.Undef, S_6451, Arr(PL_6453, PH_6454));
return default;
}, 1, "", true));
TY_6359 = GetIdx(Get(top_6358, "L"), 3D);
RS_6360 = Call(dec_24, V.Undef, ((V)("#8a4a22")), NewObj(1).Put("op", ((V)(0.35))).V);
SPL_6361 = Call(dec_24, V.Undef, ((V)("#f4dcae")), NewObj(1).Put("op", ((V)(0.75))).V);
Invoke(Invoke(o_6351, "filter", Fn((V _arrowThis6479, int _argc6472, V S_6478, V _a6475, V _a6476, V _a6477, V[] _rest6473) => {
return ((S_6478 is var _t6480 && !Truthy(_t6480) ? _t6480 : (SEqS(Get(S_6478, "mat"), "metal") ? V.True : V.False)) is var _t6481 && !Truthy(_t6481) ? _t6481 : Get(S_6478, "pts"));
}, 1, "", true)), "forEach", Fn((V _arrowThis6470, int _argc6463, V S_6469, V _a6466, V _a6467, V _a6468, V[] _rest6464) => {
V L_6471 = default;
L_6471 = Call(bbS_38, V.Undef, S_6469);
if (((System.Math.Abs((ToNum(GetIdx(L_6471, 3D)) - ToNum(TY_6359))) < 2.5) && ((ToNum(GetIdx(L_6471, 1D)) - ToNum(GetIdx(L_6471, 0D))) < 5D))) {
Call(spot_25, V.Undef, RS_6360, Arr(((V)(((ToNum(Add(GetIdx(L_6471, 0D), GetIdx(L_6471, 1D))) / 2D) + 0.6))), Add(TY_6359, ((V)(0.06))), ((V)(((ToNum(Add(GetIdx(L_6471, 4D), GetIdx(L_6471, 5D))) / 2D) + 0.5)))), Y3_37, ((V)(2.1)), ((V)(1.6)), ((V)(0.4)), ((V)(10D)));
}
return default;
}, 1, "", true));
Call(rep_29, V.Undef, ((V)(5D)), Fn((V _arrowThis6488, int _argc6482, V _a6484, V _a6485, V _a6486, V _a6487, V[] _rest6483) => {
double a_6489 = 0;
double r_6490 = 0;
V p_6491 = default;
V n_6492 = default;
a_6489 = ((ToNum(Call(R_6355, V.Undef)) * 2D) * PI_22);
r_6490 = 44.6;
{ V _t6493 = Call(cylPt_98, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(r_6490)), ((V)(a_6489)), ((V)((ToNum(TY_6359) - 1.5))));
{ V _t6494 = ListOf(_t6493);
{ V _t6495 = GetIdx(_t6494, 0D);
p_6491 = _t6495; }
{ V _t6496 = GetIdx(_t6494, 1D);
n_6492 = _t6496; }
} }
Invoke(SPL_6361, "line", Arr(p_6491, Call(add_30, V.Undef, p_6491, Arr(((V)(((-FdLibm.Sin(a_6489)) * 2.2))), ((V)(0.3)), ((V)((FdLibm.Cos(a_6489) * 2.2)))))), n_6492, ((V)(0.3)));
return default;
}, 0, "", true));
CN_6362 = Call(cyl_14, V.Undef, ((V)((-20D))), TY_6359, ((V)((-14D))), ((V)(4.2)), ((V)(8D)), ((V)("#b9bec4")), NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("metal"))).V);
SO_6363 = Call(dec_24, V.Undef, ((V)("#4a3426")));
LB_6364 = Call(dec_24, V.Undef, ((V)("#d9483b")));
LW_6365 = Call(dec_24, V.Undef, ((V)("#f4ead2")));
RB_6366 = Call(dec_24, V.Undef, ((V)("#8a8f94")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(spot_25, V.Undef, SO_6363, Arr(((V)((-20D))), Add(TY_6359, ((V)(8.06))), ((V)((-14D)))), Y3_37, ((V)(3.8)), ((V)(3.8)), ((V)(0D)), ((V)(12D)));
Call(rep_29, V.Undef, ((V)(14D)), Fn((V _arrowThis6504, int _argc6497, V i_6503, V _a6500, V _a6501, V _a6502, V[] _rest6498) => {
double a_6505 = 0;
a_6505 = (((ToNum(i_6503) / 14D) * 2D) * PI_22);
Invoke(LB_6364, "line", Arr(Arr(((V)(((-20D) + (FdLibm.Cos(a_6505) * 4.26)))), Add(TY_6359, ((V)(2.4))), ((V)(((-14D) + (FdLibm.Sin(a_6505) * 4.26))))), Arr(((V)(((-20D) + (FdLibm.Cos((a_6505 + ((2D * PI_22) / 14D))) * 4.26)))), Add(TY_6359, ((V)(2.4))), ((V)(((-14D) + (FdLibm.Sin((a_6505 + ((2D * PI_22) / 14D))) * 4.26)))))), Arr(((V)(FdLibm.Cos(a_6505))), ((V)(0D)), ((V)(FdLibm.Sin(a_6505)))), ((V)(3.2)));
return default;
}, 1, "", true));
Call(ringD_99, V.Undef, LW_6365, ((V)((-20D))), ((V)((-14D))), ((V)(4.24)), Add(TY_6359, ((V)(2.6))), ((V)(0.6)), ((V)(16D)), ((V)((PI_22 * 0.25))), ((V)((PI_22 * 0.75))));
Invoke(Arr(((V)(1D)), ((V)(7.4))), "forEach", Fn((V _arrowThis6513, int _argc6506, V y_6512, V _a6509, V _a6510, V _a6511, V[] _rest6507) => {
return Call(ringD_99, V.Undef, RB_6366, ((V)((-20D))), ((V)((-14D))), ((V)(4.24)), Add(TY_6359, y_6512), ((V)(0.3)), ((V)(20D)));
}, 1, "", true));
SU_6367 = Invoke(Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(2.6)), ((V)("#6f9a6a"))), Arr(((V)((-1.8))), ((V)(1.2)), ((V)(1.8)), ((V)("#86b07a"))), Arr(((V)(1.9)), ((V)((-1D))), ((V)(1.7)), ((V)("#5f8a5a"))), Arr(((V)(0.6)), ((V)(2D)), ((V)(1.4)), ((V)("#9ac08a")))), "map", Fn((V _arrowThis6529, int _argc6514, V _a6516, V _a6517, V _a6518, V _a6519, V[] _rest6515) => {
V dx_6522 = default;
V dz_6524 = default;
V r_6526 = default;
V c_6528 = default;
{ V _t6520 = ListOf(_a6516);
{ V _t6521 = GetIdx(_t6520, 0D);
dx_6522 = _t6521; }
{ V _t6523 = GetIdx(_t6520, 1D);
dz_6524 = _t6523; }
{ V _t6525 = GetIdx(_t6520, 2D);
r_6526 = _t6525; }
{ V _t6527 = GetIdx(_t6520, 3D);
c_6528 = _t6527; }
}
return Call(ball_12, V.Undef, Add(((V)((-20D))), dx_6522), Add(TY_6359, ((V)(7.8))), Add(((V)((-14D))), dz_6524), r_6526, c_6528, NewObj(4).Put("sy", ((V)(0.75))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("mat", ((V)("pl"))).V);
}, 1, "", true));
NP_6368 = Call(box_13, V.Undef, ((V)(14D)), TY_6359, ((V)(18D)), ((V)(16D)), ((V)(0.9)), ((V)(11D)), ((V)("#ece7dc")), NewObj(2).Put("r", ((V)(0.3))).Put("yaw", ((V)((-0.35)))).V);
NT_6369 = Call(dec_24, V.Undef, ((V)("#4a4a50")), NewObj(1).Put("op", ((V)(0.6))).V);
NH_6370 = Call(dec_24, V.Undef, ((V)("#1f1f22")), NewObj(1).Put("op", ((V)(0.85))).V);
{
double c_6530 = 0;
double s2_6531 = 0;
V Pt_6532 = default;
c_6530 = FdLibm.Cos((-0.35));
s2_6531 = FdLibm.Sin((-0.35));
Pt_6532 = Fn((V _arrowThis6541, int _argc6533, V a_6539, V b_6540, V _a6537, V _a6538, V[] _rest6534) => {
return Arr(((V)(((14D + (ToNum(a_6539) * c_6530)) + (ToNum(b_6540) * s2_6531)))), Add(TY_6359, ((V)(0.96))), ((V)(((18D - (ToNum(a_6539) * s2_6531)) + (ToNum(b_6540) * c_6530)))));
}, 2, "", true);
Invoke(NH_6370, "line", Arr(Call(Pt_6532, V.Undef, ((V)((-6.5))), ((V)((-3.8)))), Call(Pt_6532, V.Undef, ((V)(6.5)), ((V)((-3.8))))), Y3_37, ((V)(1.1)));
Call(rep_29, V.Undef, ((V)(6D)), Fn((V _arrowThis6549, int _argc6542, V i_6548, V _a6545, V _a6546, V _a6547, V[] _rest6543) => {
return Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis6557, int _argc6550, V sg_6556, V _a6553, V _a6554, V _a6555, V[] _rest6551) => {
return Invoke(NT_6369, "line", Arr(Call(Pt_6532, V.Undef, ((V)((GtN(sg_6556, 0D) ? 0.6 : (-6.6)))), ((V)(((-1.6) + (ToNum(i_6548) * 0.95))))), Call(Pt_6532, V.Undef, ((V)((GtN(sg_6556, 0D) ? 6.6 : (-0.6)))), ((V)(((-1.6) + (ToNum(i_6548) * 0.95)))))), Y3_37, ((V)(0.3)));
}, 1, "", true));
}, 1, "", true));
Invoke(NT_6369, "line", Arr(Call(Pt_6532, V.Undef, ((V)(0D)), ((V)((-3D)))), Call(Pt_6532, V.Undef, ((V)(0D)), ((V)(4.8)))), Y3_37, ((V)(0.2)));
}
CS_6371 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis6565, int _argc6558, V i_6564, V _a6561, V _a6562, V _a6563, V[] _rest6559) => {
return Call(cyl_14, V.Undef, ((V)(24D)), Add(TY_6359, ((V)((ToNum(i_6564) * 0.9)))), ((V)(((-12D) + (ToNum(i_6564) * 0.3)))), ((V)(3.6)), ((V)(0.9)), ((V)((NumTruthy((ToNum(i_6564) % 2D)) ? "#b98a58" : "#c9a46a"))), NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("wood"))).V);
}, 1, "", true));
Call(on_6354, V.Undef, Get(top_6358, "S"), Arr(CN_6362, NP_6368, GetIdx(CS_6371, 0D)));
Call(on_6354, V.Undef, CN_6362, new ArrBuilder().Add(SO_6363).Add(LB_6364).Add(LW_6365).Add(RB_6366).Spread(SU_6367).V);
Call(on_6354, V.Undef, NP_6368, Arr(NT_6369, NH_6370));
Call(on_6354, V.Undef, GetIdx(CS_6371, 0D), Arr(GetIdx(CS_6371, 1D)));
Call(on_6354, V.Undef, GetIdx(CS_6371, 1D), Arr(GetIdx(CS_6371, 2D)));
return default;
}, 2, "", true)));
Set(N_21, "torch25", Fn((V _arrowThis6573, int _argc6566, V S_6572, V _a6569, V _a6570, V _a6571, V[] _rest6567) => {
V B_6574 = default;
V D_6575 = default;
B_6574 = Invoke(N_21, "torch24", S_6572);
D_6575 = Object_assign(NewObj(0).V, B_6574);
Set(D_6575, "fx", Fn((V _arrowThis6583, int _argc6576, V c_6582, V _a6579, V _a6580, V _a6581, V[] _rest6577) => {
V b_6584 = default;
V q_6585 = default;
V k_6586 = default;
V m_6587 = default;
b_6584 = (Truthy(Get(B_6574, "fx")) ? (Invoke(B_6574, "fx", c_6582) is var _t6588 && Truthy(_t6588) ? _t6588 : NewObj(0).V) : NewObj(0).V);
q_6585 = Invoke(c_6582, "p", ((V)(8D)), ((V)(136D)), ((V)(12D)));
k_6586 = Get(c_6582, "k");
m_6587 = ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(f1_20, V.Undef, GetIdx(q_6585, 0D))).S(" ").V(Call(f1_20, V.Undef, GetIdx(q_6585, 1D))).S(")\"><g><animateMotion dur=\"5.2s\" repeatCount=\"indefinite\" path=\"M0 0C").V(Call(f1_20, V.Undef, ((V)((16D * ToNum(k_6586)))))).S(" ").V(Call(f1_20, V.Undef, ((V)(((-8D) * ToNum(k_6586)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((14D * ToNum(k_6586)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((10D * ToNum(k_6586)))))).S(" 0 ").V(Call(f1_20, V.Undef, ((V)((6D * ToNum(k_6586)))))).S("S").V(Call(f1_20, V.Undef, ((V)(((-18D) * ToNum(k_6586)))))).S(" ").V(Call(f1_20, V.Undef, ((V)(((-10D) * ToNum(k_6586)))))).S(" 0 0\"/><g transform=\"scale(").V(Call(f1_20, V.Undef, ((V)((ToNum(k_6586) * 0.7))))).S(")\"><ellipse rx=\"0.8\" ry=\"2\" fill=\"#5a4a3a\"/>").V(Invoke(Invoke(Arr(((V)("-1")), ((V)("1"))), "map", Fn((V _arrowThis6596, int _argc6589, V sg_6595, V _a6592, V _a6593, V _a6594, V[] _rest6590) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 -0.6C").N((ToNum(sg_6595) * 4D)).S(" -4 ").N((ToNum(sg_6595) * 5D)).S(" 0 ").N((ToNum(sg_6595) * 0.6)).S(" 1Z\" fill=\"#b8a88e\" stroke=\"#6b5a46\" stroke-width=\"0.3\"><animateTransform attributeName=\"transform\" type=\"scale\" values=\"1 1;0.25 1;1 1\" dur=\"0.14s\" repeatCount=\"indefinite\"/></path>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g></g></g>").End()));
return Object_assign(NewObj(0).V, b_6584, NewObj(2).Put("front", Add((Get(b_6584, "front") is var _t6597 && Truthy(_t6597) ? _t6597 : ((V)(""))), m_6587)).Put("bb", Call(mergeBB_55, V.Undef, Get(b_6584, "bb"), Arr(((V)((ToNum(GetIdx(q_6585, 0D)) - (24D * ToNum(k_6586))))), ((V)((ToNum(GetIdx(q_6585, 1D)) - (16D * ToNum(k_6586))))), Add(GetIdx(q_6585, 0D), ((V)((24D * ToNum(k_6586))))), Add(GetIdx(q_6585, 1D), ((V)((16D * ToNum(k_6586)))))))).V);
return default;
}, 1, "", true));
return D_6575;
return default;
}, 1, "", true));
PF_107 = NewObj(3).Put("rx", ((V)(33D))).Put("ry", ((V)(21.12))).Put("cy", ((V)(21.12))).V;
pfP_108 = Fn((V _arrowThis6607, int _argc6598, V th_6604, V ph_6605, V k_6606, V _a6603, V[] _rest6599) => {
double c_6608 = 0;
V p_6609 = default;
V n_6610 = default;
c_6608 = FdLibm.Cos(ToNum(ph_6605));
p_6609 = Arr(((V)(((ToNum(Get(PF_107, "rx")) * c_6608) * FdLibm.Cos(ToNum(th_6604))))), Add(Get(PF_107, "cy"), ((V)((ToNum(Get(PF_107, "ry")) * FdLibm.Sin(ToNum(ph_6605)))))), ((V)(((ToNum(Get(PF_107, "rx")) * c_6608) * FdLibm.Sin(ToNum(th_6604))))));
n_6610 = Call(nz_35, V.Undef, Arr(((V)(((c_6608 * FdLibm.Cos(ToNum(th_6604))) / ToNum(Get(PF_107, "rx"))))), ((V)((FdLibm.Sin(ToNum(ph_6605)) / ToNum(Get(PF_107, "ry"))))), ((V)(((c_6608 * FdLibm.Sin(ToNum(th_6604))) / ToNum(Get(PF_107, "rx")))))));
return Arr(Call(add_30, V.Undef, p_6609, Call(mul_32, V.Undef, n_6610, (k_6606.IsNullish ? ((V)(0.12)) : k_6606))), n_6610);
return default;
}, 3, "", true);
pfL_109 = Fn((V _arrowThis6622, int _argc6611, V D_6617, V f_6618, V m_6619, V w_6620, V[] _rest6612) => {
V L_6623 = default;
V tp_6621 = default;
tp_6621 = (_argc6611 > 4 ? _rest6612[0] : V.Undef);
L_6623 = Call(rep_29, V.Undef, Add(m_6619, ((V)(1D))), Fn((V _arrowThis6631, int _argc6624, V i_6630, V _a6627, V _a6628, V _a6629, V[] _rest6625) => {
return Call(f_6618, V.Undef, ((V)((ToNum(i_6630) / ToNum(m_6619)))));
}, 1, "", true));
Invoke(D_6617, "line", Invoke(L_6623, "map", Fn((V _arrowThis6639, int _argc6632, V q_6638, V _a6635, V _a6636, V _a6637, V[] _rest6633) => {
return GetIdx(q_6638, 0D);
}, 1, "", true)), Invoke(L_6623, "map", Fn((V _arrowThis6647, int _argc6640, V q_6646, V _a6643, V _a6644, V _a6645, V[] _rest6641) => {
return GetIdx(q_6646, 1D);
}, 1, "", true)), w_6620, tp_6621);
return default;
}, 5, "", true);
POUFK_110 = NewObj(6).Put("#efe6d4", ((V)("mac"))).Put("#1f6a4c", ((V)("vel"))).Put("#2f4870", ((V)("vel"))).Put("#a8592b", ((V)("lea"))).Put("#b9a6e0", ((V)("bou"))).Put("#d8a531", ((V)("knit"))).V;
hexRGB_111 = Fn((V _arrowThis6655, int _argc6648, V h_6654, V _a6651, V _a6652, V _a6653, V[] _rest6649) => {
double n_6656 = 0;
n_6656 = ParseInt(Invoke(((V)(ToStrS(h_6654))), "slice", ((V)(1D)), ((V)(7D))), ((V)(16D)));
return Arr(((V)(((double)(ToInt32(((double)(ToInt32(n_6656) >> (int)(ToUint32(16D) & 31)))) & ToInt32(255D))))), ((V)(((double)(ToInt32(((double)(ToInt32(n_6656) >> (int)(ToUint32(8D) & 31)))) & ToInt32(255D))))), ((V)(((double)(ToInt32(n_6656) & ToInt32(255D))))));
return default;
}, 1, "", true);
pfKind_112 = Fn((V _arrowThis6664, int _argc6657, V c_6663, V _a6660, V _a6661, V _a6662, V[] _rest6658) => {
V q_6665 = default;
V best_6666 = default;
double bd_6667 = 0;
q_6665 = Call(hexRGB_111, V.Undef, c_6663);
best_6666 = ((V)("knit"));
bd_6667 = 1000000000D;
Invoke(Object_keys(POUFK_110), "forEach", Fn((V _arrowThis6675, int _argc6668, V k_6674, V _a6671, V _a6672, V _a6673, V[] _rest6669) => {
V p_6676 = default;
double d_6677 = 0;
p_6676 = Call(hexRGB_111, V.Undef, Call(mix_19, V.Undef, k_6674, ((V)("#ffffff")), ((V)(0.1))));
d_6677 = ((Pow((ToNum(GetIdx(p_6676, 0D)) - ToNum(GetIdx(q_6665, 0D))), 2D) + Pow((ToNum(GetIdx(p_6676, 1D)) - ToNum(GetIdx(q_6665, 1D))), 2D)) + Pow((ToNum(GetIdx(p_6676, 2D)) - ToNum(GetIdx(q_6665, 2D))), 2D));
if ((d_6677 < bd_6667)) {
bd_6667 = d_6677;
best_6666 = GetK(POUFK_110, k_6674);
}
return default;
}, 1, "", true));
return best_6666;
return default;
}, 1, "", true);
Set(N_21, "pouf25", Fn((V _arrowThis6685, int _argc6678, V S_6684, V _a6681, V _a6682, V _a6683, V[] _rest6679) => {
V B_6686 = default;
V D_6687 = default;
B_6686 = Invoke(N_21, "puffPouf", S_6684);
D_6687 = Object_assign(NewObj(0).V, B_6686);
Set(D_6687, "build", Fn((V _arrowThis6695, int _argc6688, V P_6694, V _a6691, V _a6692, V _a6693, V[] _rest6689) => {
V o_6696 = default;
V on_6697 = default;
V R_6698 = default;
V c_6699 = default;
V kd_6700 = default;
V BL_6701 = default;
double top_6702 = 0;
double lo_6703 = 0;
double hi_6704 = 0;
V Ls_6705 = default;
V WL_6706 = default;
V WH_6707 = default;
V GA_6708 = default;
V LP_6709 = default;
o_6696 = Invoke(B_6686, "build", P_6694);
on_6697 = Call(glue_27, V.Undef, o_6696);
R_6698 = Call(R0_28, V.Undef, ((V)("pf25")));
c_6699 = Get(P_6694, "a");
kd_6700 = Call(pfKind_112, V.Undef, c_6699);
BL_6701 = GetIdx(o_6696, 0D);
top_6702 = (System.Math.PI / 2D);
{
double i_6710 = 0;
i_6710 = (ToNum(Get(o_6696, "length")) - 1D);
while (true) {
if (!((i_6710 > 0D))) break;
V L_6712 = default;
L_6712 = Call(bbS_38, V.Undef, GetIdx(o_6696, i_6710));
if (((((ToNum(GetIdx(L_6712, 1D)) - ToNum(GetIdx(L_6712, 0D))) < 4.5) && GtN(GetIdx(L_6712, 2D), 36D)) && LtN(GetIdx(L_6712, 2D), 39D))) {
Invoke(o_6696, "splice", ((V)(i_6710)), ((V)(1D)));
}
i_6710--;
}
}
Invoke(Invoke(o_6696, "slice", ((V)(1D))), "forEach", Fn((V _arrowThis6720, int _argc6713, V S2_6719, V _a6716, V _a6717, V _a6718, V[] _rest6714) => {
Set(S2_6719, "par", BL_6701);
return default;
}, 1, "", true));
lo_6703 = (-0.25);
hi_6704 = 1.32;
Ls_6705 = Arr();
if ((SEqS(kd_6700, "knit") || SEqS(kd_6700, "mac"))) {
V D1_6721 = default;
V D2_6722 = default;
V D3_6723 = default;
D1_6721 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, c_6699, ((V)(0.72))), NewObj(1).Put("op", ((V)(0.7))).V);
D2_6722 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, c_6699, ((V)("#ffffff")), ((V)(0.35))), NewObj(1).Put("op", ((V)(0.6))).V);
D3_6723 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, c_6699, ((V)(0.86))), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Ls_6705, "push", D1_6721, D2_6722, D3_6723);
if (SEqS(kd_6700, "knit")) {
double cols_6724 = 0;
double rows_6725 = 0;
cols_6724 = 30D;
rows_6725 = 11D;
Call(rep_29, V.Undef, ((V)(cols_6724)), Fn((V _arrowThis6733, int _argc6726, V i_6732, V _a6729, V _a6730, V _a6731, V[] _rest6727) => {
double t0_6734 = 0;
t0_6734 = (((ToNum(i_6732) / cols_6724) * 2D) * PI_22);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis6742, int _argc6735, V sg_6741, V _a6738, V _a6739, V _a6740, V[] _rest6736) => {
return Call(pfL_109, V.Undef, (LtN(sg_6741, 0D) ? D1_6721 : D2_6722), Fn((V _arrowThis6750, int _argc6743, V u_6749, V _a6746, V _a6747, V _a6748, V[] _rest6744) => {
double ph_6751 = 0;
double wob_6752 = 0;
ph_6751 = (lo_6703 + ((hi_6704 - lo_6703) * ToNum(u_6749)));
wob_6752 = (((((ToNum(u_6749) * rows_6725) % 1D) < 0.5) ? ((ToNum(u_6749) * rows_6725) % 1D) : (1D - ((ToNum(u_6749) * rows_6725) % 1D))) * 2D);
return Call(pfP_108, V.Undef, ((V)((t0_6734 + ((ToNum(sg_6741) * (0.035 + (wob_6752 * 0.05))) * Pow(FdLibm.Cos(ph_6751), (-0.2)))))), ((V)(ph_6751)));
return default;
}, 1, "", true), ((V)((rows_6725 * 4D))), ((V)(0.95)));
}, 1, "", true));
return default;
}, 1, "", true));
Call(rep_29, V.Undef, ((V)(3D)), Fn((V _arrowThis6760, int _argc6753, V j_6759, V _a6756, V _a6757, V _a6758, V[] _rest6754) => {
return Call(pfL_109, V.Undef, D3_6723, Fn((V _arrowThis6768, int _argc6761, V u_6767, V _a6764, V _a6765, V _a6766, V[] _rest6762) => {
return Call(pfP_108, V.Undef, ((V)(((ToNum(u_6767) * 2D) * PI_22))), ((V)(((-0.05) - (ToNum(j_6759) * 0.08)))));
}, 1, "", true), ((V)(96D)), ((V)(0.7)));
}, 1, "", true));
} else {
double n_6769 = 0;
n_6769 = 18D;
Call(rep_29, V.Undef, ((V)(n_6769)), Fn((V _arrowThis6777, int _argc6770, V i_6776, V _a6773, V _a6774, V _a6775, V[] _rest6771) => {
return Invoke(Arr(((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis6785, int _argc6778, V sg_6784, V _a6781, V _a6782, V _a6783, V[] _rest6779) => {
return Call(pfL_109, V.Undef, D2_6722, Fn((V _arrowThis6793, int _argc6786, V u_6792, V _a6789, V _a6790, V _a6791, V[] _rest6787) => {
double ph_6794 = 0;
ph_6794 = ((-0.3) + (1.5 * ToNum(u_6792)));
return Call(pfP_108, V.Undef, ((V)(((((ToNum(i_6776) / n_6769) * 2D) * PI_22) + ((ToNum(sg_6784) * ToNum(u_6792)) * 1.4)))), ((V)(ph_6794)));
return default;
}, 1, "", true), ((V)(40D)), ((V)(0.8)));
}, 1, "", true));
}, 1, "", true));
Call(rep_29, V.Undef, ((V)(n_6769)), Fn((V _arrowThis6802, int _argc6795, V i_6801, V _a6798, V _a6799, V _a6800, V[] _rest6796) => {
return Call(rep_29, V.Undef, ((V)(3D)), Fn((V _arrowThis6810, int _argc6803, V j_6809, V _a6806, V _a6807, V _a6808, V[] _rest6804) => {
double ph_6811 = 0;
double th_6812 = 0;
V p_6813 = default;
V nn_6814 = default;
ph_6811 = ((-0.3) + ((1.5 * ToNum(Add(j_6809, ((V)(0.5))))) / 3.1));
th_6812 = (((((ToNum(i_6801) / n_6769) * 2D) * PI_22) + (NumTruthy((ToNum(j_6809) % 2D)) ? (PI_22 / n_6769) : 0D)) + (((0.7 * ToNum(Add(j_6809, ((V)(0.5))))) / 3.1) * 0D));
{ V _t6815 = Call(pfP_108, V.Undef, ((V)((th_6812 + ((0.7 * (ToNum(Add(j_6809, ((V)(0.5)))) / 3.1)) * 0D)))), ((V)(ph_6811)), ((V)(0.2)));
{ V _t6816 = ListOf(_t6815);
{ V _t6817 = GetIdx(_t6816, 0D);
p_6813 = _t6817; }
{ V _t6818 = GetIdx(_t6816, 1D);
nn_6814 = _t6818; }
} }
Call(spot_25, V.Undef, D1_6721, p_6813, nn_6814, ((V)(1.3)), ((V)(1.1)), ((V)(0D)), ((V)(8D)));
Call(spot_25, V.Undef, D2_6722, Call(add_30, V.Undef, p_6813, Call(mul_32, V.Undef, nn_6814, ((V)(0.05)))), nn_6814, ((V)(0.6)), ((V)(0.5)), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
}, 1, "", true));
Call(rep_29, V.Undef, ((V)((n_6769 * 2D))), Fn((V _arrowThis6826, int _argc6819, V i_6825, V _a6822, V _a6823, V _a6824, V[] _rest6820) => {
V p_6827 = default;
V nn_6828 = default;
{ V _t6829 = Call(pfP_108, V.Undef, ((V)((((ToNum(i_6825) / (n_6769 * 2D)) * 2D) * PI_22))), ((V)((-0.42))), ((V)(0.1)));
{ V _t6830 = ListOf(_t6829);
{ V _t6831 = GetIdx(_t6830, 0D);
p_6827 = _t6831; }
{ V _t6832 = GetIdx(_t6830, 1D);
nn_6828 = _t6832; }
} }
Invoke(D3_6723, "line", Arr(p_6827, Call(add_30, V.Undef, p_6827, Arr(((V)(0D)), ((V)((-2.6))), ((V)(0D))))), nn_6828, ((V)(0.5)));
return default;
}, 1, "", true));
}
} else {
if (SEqS(kd_6700, "vel")) {
V D1_6833 = default;
V D2_6834 = default;
V PL_6835 = default;
D1_6833 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, c_6699, ((V)("#ffffff")), ((V)(0.25))), NewObj(1).Put("op", ((V)(0.22))).V);
D2_6834 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, c_6699, ((V)(0.82))), NewObj(1).Put("op", ((V)(0.2))).V);
PL_6835 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, c_6699, ((V)(0.68))), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Ls_6705, "push", D1_6833, D2_6834, PL_6835);
Call(rep_29, V.Undef, ((V)(7D)), Fn((V _arrowThis6843, int _argc6836, V i_6842, V _a6839, V _a6840, V _a6841, V[] _rest6837) => {
double ph_6844 = 0;
double ph2_6845 = 0;
ph_6844 = ((ToNum(Call(R_6698, V.Undef)) * 0.9) - 0.1);
ph2_6845 = (ToNum(Call(R_6698, V.Undef)) * 6D);
Call(pfL_109, V.Undef, (NumTruthy((ToNum(i_6842) % 2D)) ? D2_6834 : D1_6833), Fn((V _arrowThis6853, int _argc6846, V u_6852, V _a6849, V _a6850, V _a6851, V[] _rest6847) => {
return Call(pfP_108, V.Undef, ((V)(((((ToNum(u_6852) * 2D) * PI_22) * 0.45) + ph2_6845))), ((V)((ph_6844 + (FdLibm.Sin(((ToNum(u_6852) * 7D) + ph2_6845)) * 0.08)))));
}, 1, "", true), ((V)(30D)), ((V)((2D + (ToNum(Call(R_6698, V.Undef)) * 2D)))), ((V)(1D)));
return default;
}, 1, "", true));
Call(rep_29, V.Undef, ((V)(12D)), Fn((V _arrowThis6861, int _argc6854, V i_6860, V _a6857, V _a6858, V _a6859, V[] _rest6855) => {
return Call(pfL_109, V.Undef, PL_6835, Fn((V _arrowThis6869, int _argc6862, V u_6868, V _a6865, V _a6866, V _a6867, V[] _rest6863) => {
return Call(pfP_108, V.Undef, ((V)(((((ToNum(i_6860) / 12D) * 2D) * PI_22) + (FdLibm.Sin((ToNum(u_6868) * 3D)) * 0.05)))), ((V)(((top_6702 - 0.08) - (ToNum(u_6868) * 0.62)))));
}, 1, "", true), ((V)(12D)), ((V)(0.6)), ((V)(1D)));
}, 1, "", true));
} else {
if (SEqS(kd_6700, "lea")) {
V PA_6870 = default;
V FL_6871 = default;
V SM_6872 = default;
V ST_6873 = default;
PA_6870 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, c_6699, ((V)("#ffe2b8")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.25))).V);
FL_6871 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, c_6699, ((V)(0.75))), NewObj(1).Put("op", ((V)(0.28))).V);
SM_6872 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, c_6699, ((V)(0.55))), NewObj(1).Put("op", ((V)(0.8))).V);
ST_6873 = Call(dec_24, V.Undef, ((V)("#f2e2c0")), NewObj(1).Put("op", ((V)(0.85))).V);
Invoke(Ls_6705, "push", PA_6870, FL_6871, SM_6872, ST_6873);
Call(rep_29, V.Undef, ((V)(6D)), Fn((V _arrowThis6881, int _argc6874, V i_6880, V _a6877, V _a6878, V _a6879, V[] _rest6875) => {
double t0_6882 = 0;
t0_6882 = (((ToNum(i_6880) / 6D) * 2D) * PI_22);
Call(pfL_109, V.Undef, SM_6872, Fn((V _arrowThis6890, int _argc6883, V u_6889, V _a6886, V _a6887, V _a6888, V[] _rest6884) => {
return Call(pfP_108, V.Undef, ((V)(t0_6882)), ((V)(((-0.35) + (((top_6702 - 0.06) + 0.35) * ToNum(u_6889))))));
}, 1, "", true), ((V)(24D)), ((V)(0.6)));
Call(rep_29, V.Undef, ((V)(18D)), Fn((V _arrowThis6898, int _argc6891, V k_6897, V _a6894, V _a6895, V _a6896, V[] _rest6892) => {
double ph_6899 = 0;
ph_6899 = ((-0.3) + ((((top_6702 - 0.15) + 0.3) * ToNum(k_6897)) / 18D));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis6907, int _argc6900, V sg_6906, V _a6903, V _a6904, V _a6905, V[] _rest6901) => {
V a_6908 = default;
V b_6909 = default;
V nn_6910 = default;
{ V _t6911 = Call(pfP_108, V.Undef, ((V)((t0_6882 + ((ToNum(sg_6906) * 0.035) / Max(0.2, FdLibm.Cos(ph_6899)))))), ((V)(ph_6899)), ((V)(0.16)));
{ V _t6912 = ListOf(_t6911);
{ V _t6913 = GetIdx(_t6912, 0D);
a_6908 = _t6913; }
} }
{ V _t6914 = Call(pfP_108, V.Undef, ((V)((t0_6882 + ((ToNum(sg_6906) * 0.035) / Max(0.2, FdLibm.Cos(ph_6899)))))), ((V)((ph_6899 + 0.045))), ((V)(0.16)));
{ V _t6915 = ListOf(_t6914);
{ V _t6916 = GetIdx(_t6915, 0D);
b_6909 = _t6916; }
{ V _t6917 = GetIdx(_t6915, 1D);
nn_6910 = _t6917; }
} }
Invoke(ST_6873, "line", Arr(a_6908, b_6909), nn_6910, ((V)(0.3)));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Call(rep_29, V.Undef, ((V)(4D)), Fn((V _arrowThis6924, int _argc6918, V _a6920, V _a6921, V _a6922, V _a6923, V[] _rest6919) => {
double th_6925 = 0;
th_6925 = ((ToNum(Call(R_6698, V.Undef)) * 2D) * PI_22);
Call(pfL_109, V.Undef, PA_6870, Fn((V _arrowThis6933, int _argc6926, V u_6932, V _a6929, V _a6930, V _a6931, V[] _rest6927) => {
return Call(pfP_108, V.Undef, ((V)((th_6925 + (ToNum(u_6932) * 0.8)))), ((V)((0.5 + (FdLibm.Sin((ToNum(u_6932) * 4D)) * 0.1)))));
}, 1, "", true), ((V)(12D)), ((V)(3D)), ((V)(1D)));
return default;
}, 0, "", true));
Call(rep_29, V.Undef, ((V)(90D)), Fn((V _arrowThis6940, int _argc6934, V _a6936, V _a6937, V _a6938, V _a6939, V[] _rest6935) => {
V p_6941 = default;
V nn_6942 = default;
{ V _t6943 = Call(pfP_108, V.Undef, ((V)(((ToNum(Call(R_6698, V.Undef)) * 2D) * PI_22))), ((V)(((-0.2) + (ToNum(Call(R_6698, V.Undef)) * 1.4)))), ((V)(0.1)));
{ V _t6944 = ListOf(_t6943);
{ V _t6945 = GetIdx(_t6944, 0D);
p_6941 = _t6945; }
{ V _t6946 = GetIdx(_t6944, 1D);
nn_6942 = _t6946; }
} }
Call(spot_25, V.Undef, FL_6871, p_6941, nn_6942, ((V)(0.3)), ((V)(0.25)), ((V)(0D)), ((V)(5D)));
return default;
}, 0, "", true));
} else {
V D1_6947 = default;
V D2_6948 = default;
D1_6947 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, c_6699, ((V)("#ffffff")), ((V)(0.55))), NewObj(1).Put("op", ((V)(0.65))).V);
D2_6948 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, c_6699, ((V)(0.82))), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Ls_6705, "push", D1_6947, D2_6948);
{
V ph_6949 = default;
ph_6949 = ((V)((-0.3)));
while (true) {
V ph_6949_it = ph_6949;
if (!(LtN(ph_6949_it, (top_6702 - 0.1)))) break;
double n_6951 = 0;
n_6951 = Max(6D, Round((FdLibm.Cos(ToNum(ph_6949_it)) * 74D)));
Call(rep_29, V.Undef, ((V)(n_6951)), Fn((V _arrowThis6959, int _argc6952, V i_6958, V _a6955, V _a6956, V _a6957, V[] _rest6953) => {
double th_6960 = 0;
V p_6961 = default;
V nn_6962 = default;
th_6960 = (((ToNum(Add(i_6958, ((V)(((Round((ToNum(ph_6949_it) / 0.085)) % 2D) * 0.5))))) / n_6951) * 2D) * PI_22);
{ V _t6963 = Call(pfP_108, V.Undef, ((V)(th_6960)), ph_6949_it, ((V)(0.16)));
{ V _t6964 = ListOf(_t6963);
{ V _t6965 = GetIdx(_t6964, 0D);
p_6961 = _t6965; }
{ V _t6966 = GetIdx(_t6964, 1D);
nn_6962 = _t6966; }
} }
Call(spot_25, V.Undef, (NumTruthy((ToNum(i_6958) % 3D)) ? D1_6947 : D2_6948), p_6961, nn_6962, ((V)(0.7)), ((V)(0.6)), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
ph_6949 = ph_6949_it;
ph_6949 = Add(ph_6949, ((V)(0.085)));
}
}
}
}
}
WL_6706 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, c_6699, ((V)(0.66))), NewObj(1).Put("op", ((V)(0.85))).V);
WH_6707 = Call(dec_24, V.Undef, Call(mix_19, V.Undef, c_6699, ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.5))).V);
GA_6708 = Call(dec_24, V.Undef, Call(shade_18, V.Undef, c_6699, ((V)(0.7))), NewObj(1).Put("op", ((V)(0.55))).V);
Call(pfL_109, V.Undef, WL_6706, Fn((V _arrowThis6974, int _argc6967, V u_6973, V _a6970, V _a6971, V _a6972, V[] _rest6968) => {
return Call(pfP_108, V.Undef, ((V)(((ToNum(u_6973) * 2D) * PI_22))), ((V)(0D)), ((V)(0.3)));
}, 1, "", true), ((V)(96D)), ((V)(1.1)));
Call(pfL_109, V.Undef, WH_6707, Fn((V _arrowThis6982, int _argc6975, V u_6981, V _a6978, V _a6979, V _a6980, V[] _rest6976) => {
return Call(pfP_108, V.Undef, ((V)(((ToNum(u_6981) * 2D) * PI_22))), ((V)(0.035)), ((V)(0.32)));
}, 1, "", true), ((V)(96D)), ((V)(0.35)));
Call(rep_29, V.Undef, ((V)(16D)), Fn((V _arrowThis6990, int _argc6983, V i_6989, V _a6986, V _a6987, V _a6988, V[] _rest6984) => {
return Call(pfL_109, V.Undef, GA_6708, Fn((V _arrowThis6998, int _argc6991, V u_6997, V _a6994, V _a6995, V _a6996, V[] _rest6992) => {
return Call(pfP_108, V.Undef, ((V)((((ToNum(i_6989) / 16D) * 2D) * PI_22))), ((V)(((top_6702 - 0.02) - (ToNum(u_6997) * 0.28)))), ((V)(0.14)));
}, 1, "", true), ((V)(6D)), ((V)(0.45)), ((V)(1D)));
}, 1, "", true));
Call(on_6697, V.Undef, BL_6701, Invoke(Ls_6705, "concat", Arr(WL_6706, WH_6707, GA_6708)));
LP_6709 = Call(solid_11, V.Undef, NewObj(13).Put("ax", ((V)("x"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)((ToNum(Get(PF_107, "cy")) - 0.6))))).Put("a", ((V)(2.2))).Put("b", ((V)(2.8))).Put("th", ((V)(0.7))).Put("a0", ((V)(PI_22))).Put("a1", ((V)((PI_22 * 2D)))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)((ToNum(Get(PF_107, "rx")) - 0.2))), ((V)(0D))), Arr(Add(Get(PF_107, "rx"), ((V)(0.8))), ((V)(0D))))).Put("col", Call(shade_18, V.Undef, c_6699, ((V)(0.7)))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V);
Call(on_6697, V.Undef, BL_6701, Arr(LP_6709));
return o_6696;
return default;
}, 1, "", true));
return D_6687;
return default;
}, 1, "", true));
luxFix_113 = Fn((V _arrowThis7006, int _argc6999, V o_7005, V _a7002, V _a7003, V _a7004, V[] _rest7000) => {
V B_7007 = default;
V top_7008 = default;
V ap_7009 = default;
V rim_7010 = default;
B_7007 = Invoke(Invoke(o_7005, "filter", Fn((V _arrowThis7026, int _argc7019, V S_7025, V _a7022, V _a7023, V _a7024, V[] _rest7020) => {
return (((S_7025 is var _t7027 && !Truthy(_t7027) ? _t7027 : Get(S_7025, "pts")) is var _t7028 && !Truthy(_t7028) ? _t7028 : Get(Get(S_7025, "pts"), "length")) is var _t7029 && !Truthy(_t7029) ? _t7029 : (!(Truthy(Get(S_7025, "par"))) ? V.True : V.False));
}, 1, "", true)), "map", Fn((V _arrowThis7018, int _argc7011, V S_7017, V _a7014, V _a7015, V _a7016, V[] _rest7012) => {
return NewObj(2).Put("S", S_7017).Put("L", Call(bbS_38, V.Undef, S_7017)).V;
}, 1, "", true));
top_7008 = Invoke(B_7007, "find", Fn((V _arrowThis7037, int _argc7030, V b_7036, V _a7033, V _a7034, V _a7035, V[] _rest7031) => {
return (((SEqS(Get(Get(b_7036, "S"), "mat"), "cer") && (System.Math.Abs((ToNum(GetIdx(Get(b_7036, "L"), 3D)) - 40.8)) < 0.8)) && ((ToNum(GetIdx(Get(b_7036, "L"), 1D)) - ToNum(GetIdx(Get(b_7036, "L"), 0D))) > 100D)) ? V.True : V.False);
}, 1, "", true));
ap_7009 = Invoke(B_7007, "find", Fn((V _arrowThis7045, int _argc7038, V b_7044, V _a7041, V _a7042, V _a7043, V[] _rest7039) => {
return (((SEq(Get(Get(b_7044, "S"), "col"), GOLD_23) && (System.Math.Abs((ToNum(GetIdx(Get(b_7044, "L"), 2D)) - 28D)) < 0.6)) && ((ToNum(GetIdx(Get(b_7044, "L"), 1D)) - ToNum(GetIdx(Get(b_7044, "L"), 0D))) > 100D)) ? V.True : V.False);
}, 1, "", true));
rim_7010 = Invoke(B_7007, "find", Fn((V _arrowThis7053, int _argc7046, V b_7052, V _a7049, V _a7050, V _a7051, V[] _rest7047) => {
return (((SEq(Get(Get(b_7052, "S"), "col"), GOLD_23) && (System.Math.Abs((ToNum(GetIdx(Get(b_7052, "L"), 2D)) - 35D)) < 0.5)) && ((ToNum(GetIdx(Get(b_7052, "L"), 1D)) - ToNum(GetIdx(Get(b_7052, "L"), 0D))) > 110D)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(top_7008)) {
Invoke(B_7007, "forEach", Fn((V _arrowThis7061, int _argc7054, V b_7060, V _a7057, V _a7058, V _a7059, V[] _rest7055) => {
if ((!SEq(b_7060, top_7008) && GtN(GetIdx(Get(b_7060, "L"), 2D), 40.3))) {
Set(Get(b_7060, "S"), "par", Get(top_7008, "S"));
}
return default;
}, 1, "", true));
}
if (Truthy(ap_7009)) {
Invoke(B_7007, "forEach", Fn((V _arrowThis7069, int _argc7062, V b_7068, V _a7065, V _a7066, V _a7067, V[] _rest7063) => {
if (((((((SEq(Get(Get(b_7068, "S"), "col"), GOLD_23) && !SEq(b_7068, ap_7009)) && !SEq(b_7068, rim_7010)) && GtN(GetIdx(Get(b_7068, "L"), 2D), 20D)) && LtN(GetIdx(Get(b_7068, "L"), 3D), 36D)) && ((ToNum(GetIdx(Get(b_7068, "L"), 1D)) - ToNum(GetIdx(Get(b_7068, "L"), 0D))) < 14D)) && (Max(System.Math.Abs(ToNum(Add(GetIdx(Get(b_7068, "L"), 0D), GetIdx(Get(b_7068, "L"), 1D)))), System.Math.Abs(ToNum(Add(GetIdx(Get(b_7068, "L"), 4D), GetIdx(Get(b_7068, "L"), 5D))))) > 40D))) {
Set(Get(b_7068, "S"), "par", Get(ap_7009, "S"));
}
return default;
}, 1, "", true));
}
Invoke(B_7007, "forEach", Fn((V _arrowThis7077, int _argc7070, V b_7076, V _a7073, V _a7074, V _a7075, V[] _rest7071) => {
if ((((SEq(Get(Get(b_7076, "S"), "col"), GOLD_23) && GtN(GetIdx(Get(b_7076, "L"), 2D), 2D)) && LtN(GetIdx(Get(b_7076, "L"), 2D), 4D)) && GtN(GetIdx(Get(b_7076, "L"), 3D), 29D))) {
V y0_7078 = default;
double k_7079 = 0;
y0_7078 = GetIdx(Get(b_7076, "L"), 2D);
k_7079 = ((27.6 - ToNum(y0_7078)) / (ToNum(GetIdx(Get(b_7076, "L"), 3D)) - ToNum(y0_7078)));
Call(mvPts_64, V.Undef, Get(b_7076, "S"), Fn((V _arrowThis7087, int _argc7080, V p_7086, V _a7083, V _a7084, V _a7085, V[] _rest7081) => {
return Arr(GetIdx(p_7086, 0D), Add(y0_7078, ((V)(((ToNum(GetIdx(p_7086, 1D)) - ToNum(y0_7078)) * k_7079)))), GetIdx(p_7086, 2D));
}, 1, "", true));
}
return default;
}, 1, "", true));
return default;
}, 1, "", true);
Set(N_21, "luxCoffeeF", Fn((V _arrowThis7095, int _argc7088, V S_7094, V _a7091, V _a7092, V _a7093, V[] _rest7089) => {
V B_7096 = default;
V D_7097 = default;
B_7096 = Invoke(N_21, "luxCoffee", S_7094);
D_7097 = Object_assign(NewObj(0).V, B_7096);
Set(D_7097, "build", Fn((V _arrowThis7105, int _argc7098, V P_7104, V _a7101, V _a7102, V _a7103, V[] _rest7099) => {
V o_7106 = default;
o_7106 = Invoke(B_7096, "build", P_7104);
Call(luxFix_113, V.Undef, o_7106);
return o_7106;
return default;
}, 1, "", true));
return D_7097;
return default;
}, 1, "", true));
Set(N_21, "lux25", Call(texWrap_78, V.Undef, ((V)("luxCoffeeF")), ((V)("lx")), NewObj(0).V, Fn((V _arrowThis7115, int _argc7107, V o_7113, V P_7114, V _a7111, V _a7112, V[] _rest7108) => {
V on_7116 = default;
V R_7117 = default;
V B_7118 = default;
V ap_7119 = default;
V top_7120 = default;
V bk_7121 = default;
on_7116 = Call(glue_27, V.Undef, o_7113);
R_7117 = Call(R0_28, V.Undef, ((V)("lx25")));
B_7118 = Invoke(Invoke(o_7113, "filter", Fn((V _arrowThis7137, int _argc7130, V S_7136, V _a7133, V _a7134, V _a7135, V[] _rest7131) => {
return (((S_7136 is var _t7138 && !Truthy(_t7138) ? _t7138 : Get(S_7136, "pts")) is var _t7139 && !Truthy(_t7139) ? _t7139 : Get(Get(S_7136, "pts"), "length")) is var _t7140 && !Truthy(_t7140) ? _t7140 : (!(Truthy(Get(S_7136, "par"))) ? V.True : V.False));
}, 1, "", true)), "map", Fn((V _arrowThis7129, int _argc7122, V S_7128, V _a7125, V _a7126, V _a7127, V[] _rest7123) => {
return NewObj(2).Put("S", S_7128).Put("L", Call(bbS_38, V.Undef, S_7128)).V;
}, 1, "", true));
ap_7119 = Invoke(B_7118, "find", Fn((V _arrowThis7148, int _argc7141, V b_7147, V _a7144, V _a7145, V _a7146, V[] _rest7142) => {
return (((SEq(Get(Get(b_7147, "S"), "col"), GOLD_23) && (System.Math.Abs((ToNum(GetIdx(Get(b_7147, "L"), 2D)) - 28D)) < 0.6)) && ((ToNum(GetIdx(Get(b_7147, "L"), 1D)) - ToNum(GetIdx(Get(b_7147, "L"), 0D))) > 100D)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(ap_7119)) {
V SC_7149 = default;
V HL_7150 = default;
V BD_7151 = default;
double a_7152 = 0;
double b_7153 = 0;
double y0_7154 = 0;
double y1_7155 = 0;
V Pp_7156 = default;
V ln_7157 = default;
SC_7149 = Call(dec_24, V.Undef, ((V)("#9a6a14")), NewObj(1).Put("op", ((V)(0.75))).V);
HL_7150 = Call(dec_24, V.Undef, ((V)("#fff1b0")), NewObj(1).Put("op", ((V)(0.6))).V);
BD_7151 = Call(dec_24, V.Undef, ((V)("#fff1b0")), NewObj(1).Put("op", ((V)(0.85))).V);
a_7152 = 54D;
b_7153 = 30D;
y0_7154 = 28D;
y1_7155 = 35D;
Pp_7156 = Fn((V _arrowThis7167, int _argc7158, V t_7164, V y_7165, V k_7166, V _a7163, V[] _rest7159) => {
return Arr(Arr(((V)((FdLibm.Cos(ToNum(t_7164)) * ToNum(Add(((V)(a_7152)), (k_7166 is var _t7168 && Truthy(_t7168) ? _t7168 : ((V)(0.12)))))))), y_7165, ((V)((FdLibm.Sin(ToNum(t_7164)) * ToNum(Add(((V)(b_7153)), (k_7166 is var _t7169 && Truthy(_t7169) ? _t7169 : ((V)(0.12))))))))), Invoke(Arr(((V)((FdLibm.Cos(ToNum(t_7164)) * b_7153))), ((V)(0D)), ((V)((FdLibm.Sin(ToNum(t_7164)) * a_7152)))), "map", Fn((V _arrowThis7179, int _argc7170, V v_7176, V i_7177, V A_7178, V _a7175, V[] _rest7171) => {
return ((V)((ToNum(v_7176) / ToNum(InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(A_7178).V)))));
}, 3, "", true)));
}, 3, "", true);
ln_7157 = Fn((V _arrowThis7190, int _argc7180, V D_7186, V f_7187, V m_7188, V w_7189, V[] _rest7181) => {
V L_7191 = default;
L_7191 = Call(rep_29, V.Undef, Add(m_7188, ((V)(1D))), Fn((V _arrowThis7199, int _argc7192, V i_7198, V _a7195, V _a7196, V _a7197, V[] _rest7193) => {
return Call(f_7187, V.Undef, ((V)((ToNum(i_7198) / ToNum(m_7188)))));
}, 1, "", true));
Invoke(D_7186, "line", Invoke(L_7191, "map", Fn((V _arrowThis7207, int _argc7200, V q_7206, V _a7203, V _a7204, V _a7205, V[] _rest7201) => {
return GetIdx(q_7206, 0D);
}, 1, "", true)), Invoke(L_7191, "map", Fn((V _arrowThis7215, int _argc7208, V q_7214, V _a7211, V _a7212, V _a7213, V[] _rest7209) => {
return GetIdx(q_7214, 1D);
}, 1, "", true)), w_7189);
return default;
}, 4, "", true);
Call(rep_29, V.Undef, ((V)(14D)), Fn((V _arrowThis7223, int _argc7216, V i_7222, V _a7219, V _a7220, V _a7221, V[] _rest7217) => {
double t0_7224 = 0;
double dt2_7225 = 0;
t0_7224 = (((ToNum(i_7222) / 14D) * 2D) * PI_22);
dt2_7225 = ((2D * PI_22) / 14D);
Call(ln_7157, V.Undef, SC_7149, Fn((V _arrowThis7233, int _argc7226, V u_7232, V _a7229, V _a7230, V _a7231, V[] _rest7227) => {
return Call(Pp_7156, V.Undef, ((V)(((t0_7224 + (dt2_7225 * 0.1)) + ((ToNum(u_7232) * dt2_7225) * 0.8)))), ((V)(((y0_7154 + 3.5) + (FdLibm.Sin(((ToNum(u_7232) * PI_22) * 2D)) * 1.6)))));
}, 1, "", true), ((V)(14D)), ((V)(0.45)));
Call(ln_7157, V.Undef, HL_7150, Fn((V _arrowThis7241, int _argc7234, V u_7240, V _a7237, V _a7238, V _a7239, V[] _rest7235) => {
return Call(Pp_7156, V.Undef, ((V)(((t0_7224 + (dt2_7225 * 0.12)) + ((ToNum(u_7240) * dt2_7225) * 0.76)))), ((V)(((y0_7154 + 3.9) + (FdLibm.Sin(((ToNum(u_7240) * PI_22) * 2D)) * 1.6)))));
}, 1, "", true), ((V)(14D)), ((V)(0.25)));
Invoke(Arr(((V)(0.25)), ((V)(0.75))), "forEach", Fn((V _arrowThis7249, int _argc7242, V f_7248, V _a7245, V _a7246, V _a7247, V[] _rest7243) => {
V p_7250 = default;
V n_7251 = default;
{ V _t7252 = Call(Pp_7156, V.Undef, ((V)((t0_7224 + (dt2_7225 * ToNum(f_7248))))), ((V)(((y0_7154 + 3.5) + (LtN(f_7248, 0.5) ? 1.6 : (-1.6))))), ((V)(0.15)));
{ V _t7253 = ListOf(_t7252);
{ V _t7254 = GetIdx(_t7253, 0D);
p_7250 = _t7254; }
{ V _t7255 = GetIdx(_t7253, 1D);
n_7251 = _t7255; }
} }
Call(spot_25, V.Undef, SC_7149, p_7250, n_7251, ((V)(1D)), ((V)(0.8)), ((V)(0D)), ((V)(8D)));
Call(spot_25, V.Undef, HL_7150, Call(add_30, V.Undef, p_7250, Arr(((V)(0D)), ((V)(0.2)), ((V)(0D)))), n_7251, ((V)(0.4)), ((V)(0.3)), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(((V)((y0_7154 + 0.8))), ((V)((y1_7155 - 0.8)))), "forEach", Fn((V _arrowThis7263, int _argc7256, V y_7262, V _a7259, V _a7260, V _a7261, V[] _rest7257) => {
return Call(rep_29, V.Undef, ((V)(90D)), Fn((V _arrowThis7271, int _argc7264, V i_7270, V _a7267, V _a7268, V _a7269, V[] _rest7265) => {
V p_7272 = default;
V n_7273 = default;
{ V _t7274 = Call(Pp_7156, V.Undef, ((V)((((ToNum(i_7270) / 90D) * 2D) * PI_22))), y_7262, ((V)(0.14)));
{ V _t7275 = ListOf(_t7274);
{ V _t7276 = GetIdx(_t7275, 0D);
p_7272 = _t7276; }
{ V _t7277 = GetIdx(_t7275, 1D);
n_7273 = _t7277; }
} }
Call(spot_25, V.Undef, BD_7151, p_7272, n_7273, ((V)(0.42)), ((V)(0.42)), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
}, 1, "", true));
Call(on_7116, V.Undef, Get(ap_7119, "S"), Arr(SC_7149, HL_7150, BD_7151));
}
Invoke(Invoke(B_7118, "filter", Fn((V _arrowThis7345, int _argc7338, V b_7344, V _a7341, V _a7342, V _a7343, V[] _rest7339) => {
return (((SEq(Get(Get(b_7344, "S"), "col"), GOLD_23) && ((ToNum(GetIdx(Get(b_7344, "L"), 3D)) - ToNum(GetIdx(Get(b_7344, "L"), 2D))) > 20D)) && ((ToNum(GetIdx(Get(b_7344, "L"), 1D)) - ToNum(GetIdx(Get(b_7344, "L"), 0D))) < 8D)) ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis7288, int _argc7278, V _a7280, V _a7281, V _a7282, V _a7283, V[] _rest7279) => {
V FD_7289 = default;
V FH_7290 = default;
double cx_7291 = 0;
double cz_7292 = 0;
V S_7285 = default;
V L_7287 = default;
if (_a7280.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a7280));
{ V _t7284 = Get(_a7280, "S");
S_7285 = _t7284; }
{ V _t7286 = Get(_a7280, "L");
L_7287 = _t7286; }
FD_7289 = Call(dec_24, V.Undef, ((V)("#9a6a14")), NewObj(1).Put("op", ((V)(0.6))).V);
FH_7290 = Call(dec_24, V.Undef, ((V)("#fff1b0")), NewObj(1).Put("op", ((V)(0.5))).V);
cx_7291 = (ToNum(Add(GetIdx(L_7287, 0D), GetIdx(L_7287, 1D))) / 2D);
cz_7292 = (ToNum(Add(GetIdx(L_7287, 4D), GetIdx(L_7287, 5D))) / 2D);
Call(rep_29, V.Undef, ((V)(8D)), Fn((V _arrowThis7300, int _argc7293, V i_7299, V _a7296, V _a7297, V _a7298, V[] _rest7294) => {
double a_7301 = 0;
V k_7302 = default;
a_7301 = (((ToNum(i_7299) / 8D) * 2D) * PI_22);
k_7302 = Fn((V _arrowThis7310, int _argc7303, V y_7309, V _a7306, V _a7307, V _a7308, V[] _rest7304) => {
double t_7311 = 0;
t_7311 = ((ToNum(y_7309) - 3D) / 28D);
return ((V)((2.8 * ((t_7311 < 0.25) ? (0.9 - ((0.28 * t_7311) / 0.25)) : ((t_7311 < 0.64) ? (0.62 + ((0.28 * (t_7311 - 0.25)) / 0.39)) : (0.9 + ((0.7 * (t_7311 - 0.64)) / 0.25)))))));
return default;
}, 1, "", true);
Invoke(FD_7289, "line", Invoke(Arr(((V)(5D)), ((V)(9D)), ((V)(13D)), ((V)(17D)), ((V)(20D))), "map", Fn((V _arrowThis7319, int _argc7312, V y_7318, V _a7315, V _a7316, V _a7317, V[] _rest7313) => {
return Arr(((V)((cx_7291 + (FdLibm.Cos(a_7301) * ToNum(Add(Call(k_7302, V.Undef, y_7318), ((V)(0.06)))))))), y_7318, ((V)((cz_7292 + (FdLibm.Sin(a_7301) * ToNum(Add(Call(k_7302, V.Undef, y_7318), ((V)(0.06)))))))));
}, 1, "", true)), Arr(((V)(FdLibm.Cos(a_7301))), ((V)(0D)), ((V)(FdLibm.Sin(a_7301)))), ((V)(0.35)));
Invoke(FH_7290, "line", Invoke(Arr(((V)(5D)), ((V)(9D)), ((V)(13D)), ((V)(17D)), ((V)(20D))), "map", Fn((V _arrowThis7327, int _argc7320, V y_7326, V _a7323, V _a7324, V _a7325, V[] _rest7321) => {
return Arr(((V)((cx_7291 + (FdLibm.Cos((a_7301 + 0.2)) * ToNum(Add(Call(k_7302, V.Undef, y_7326), ((V)(0.06)))))))), y_7326, ((V)((cz_7292 + (FdLibm.Sin((a_7301 + 0.2)) * ToNum(Add(Call(k_7302, V.Undef, y_7326), ((V)(0.06)))))))));
}, 1, "", true)), Arr(((V)(FdLibm.Cos((a_7301 + 0.2)))), ((V)(0D)), ((V)(FdLibm.Sin((a_7301 + 0.2))))), ((V)(0.2)));
return default;
}, 1, "", true));
Call(rep_29, V.Undef, ((V)(5D)), Fn((V _arrowThis7335, int _argc7328, V i_7334, V _a7331, V _a7332, V _a7333, V[] _rest7329) => {
double a_7336 = 0;
double aa_7337 = 0;
a_7336 = ((((-PI_22) / 2D) + ((ToNum(i_7334) - 2D) * 0.35)) + (((cz_7292 > 0D) ? PI_22 : 0D) * 0D));
aa_7337 = (FdLibm.Atan2(cz_7292, cx_7291) + ((ToNum(i_7334) - 2D) * 0.45));
Invoke(FD_7289, "line", Arr(Arr(((V)((cx_7291 + (FdLibm.Cos(aa_7337) * 4.2)))), ((V)(26.5)), ((V)((cz_7292 + (FdLibm.Sin(aa_7337) * 4.2))))), Arr(((V)((cx_7291 + (FdLibm.Cos(aa_7337) * 3.4)))), ((V)(23D)), ((V)((cz_7292 + (FdLibm.Sin(aa_7337) * 3.4)))))), Arr(((V)(FdLibm.Cos(aa_7337))), ((V)(0D)), ((V)(FdLibm.Sin(aa_7337)))), ((V)(0.5)), ((V)(1D)));
return default;
}, 1, "", true));
Call(on_7116, V.Undef, S_7285, Arr(FD_7289, FH_7290));
return default;
}, 1, "", true));
top_7120 = Invoke(B_7118, "find", Fn((V _arrowThis7353, int _argc7346, V b_7352, V _a7349, V _a7350, V _a7351, V[] _rest7347) => {
return (((SEqS(Get(Get(b_7352, "S"), "mat"), "cer") && (System.Math.Abs((ToNum(GetIdx(Get(b_7352, "L"), 3D)) - 40.8)) < 0.8)) && ((ToNum(GetIdx(Get(b_7352, "L"), 1D)) - ToNum(GetIdx(Get(b_7352, "L"), 0D))) > 100D)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(top_7120)) {
V GW_7354 = default;
V GR_7355 = default;
GW_7354 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.55))).V);
GR_7355 = Call(dec_24, V.Undef, ((V)("#d9a84a")), NewObj(1).Put("op", ((V)(0.45))).V);
Invoke(Call(caps_50, V.Undef, Get(top_7120, "S"), ((V)(2D))), "forEach", Fn((V _arrowThis7363, int _argc7356, V F_7362, V _a7359, V _a7360, V _a7361, V[] _rest7357) => {
V G_7364 = default;
G_7364 = Call(fr2_39, V.Undef, F_7362);
Invoke(GW_7354, "line", Arr(Invoke(G_7364, "at", ((V)((-40D))), ((V)((-14D)))), Invoke(G_7364, "at", ((V)((-22D))), ((V)((-20D))))), Get(G_7364, "n"), ((V)(1.2)), ((V)(1D)));
Invoke(GW_7354, "line", Arr(Invoke(G_7364, "at", ((V)(26D)), ((V)(16D))), Invoke(G_7364, "at", ((V)(40D)), ((V)(10D)))), Get(G_7364, "n"), ((V)(0.8)), ((V)(1D)));
return default;
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, Get(top_7120, "S"), ((V)(1D))), "forEach", Fn((V _arrowThis7372, int _argc7365, V F_7371, V _a7368, V _a7369, V _a7370, V[] _rest7366) => {
if ((System.Math.Abs(ToNum(GetIdx(Get(F_7371, "n"), 1D))) < 0.3)) {
Invoke(GR_7355, "line", Invoke(Arr(GetIdx(Get(F_7371, "q"), 0D), GetIdx(Get(F_7371, "q"), 1D)), "map", Fn((V _arrowThis7380, int _argc7373, V p_7379, V _a7376, V _a7377, V _a7378, V[] _rest7374) => {
return Call(add_30, V.Undef, p_7379, Arr(((V)(0D)), ((V)(0.4)), ((V)(0D))));
}, 1, "", true)), Get(F_7371, "n"), ((V)(0.25)));
}
return default;
}, 1, "", true));
Call(on_7116, V.Undef, Get(top_7120, "S"), Arr(GW_7354, GR_7355));
}
Invoke(Invoke(o_7113, "filter", Fn((V _arrowThis7411, int _argc7404, V S_7410, V _a7407, V _a7408, V _a7409, V[] _rest7405) => {
return ((((S_7410 is var _t7412 && !Truthy(_t7412) ? _t7412 : Get(S_7410, "pts")) is var _t7413 && !Truthy(_t7413) ? _t7413 : (!Get(S_7410, "op").IsNullish ? V.True : V.False)) is var _t7414 && !Truthy(_t7414) ? _t7414 : (LtN(Get(S_7410, "op"), 0.6) ? V.True : V.False)) is var _t7415 && !Truthy(_t7415) ? _t7415 : (SEqS(Get(S_7410, "mat"), "cer") ? V.True : V.False));
}, 1, "", true)), "forEach", Fn((V _arrowThis7388, int _argc7381, V S_7387, V _a7384, V _a7385, V _a7386, V[] _rest7382) => {
V L_7389 = default;
double cx_7390 = 0;
double cz_7391 = 0;
double r_7392 = 0;
V FC_7393 = default;
V FD_7394 = default;
L_7389 = Call(bbS_38, V.Undef, S_7387);
cx_7390 = (ToNum(Add(GetIdx(L_7389, 0D), GetIdx(L_7389, 1D))) / 2D);
cz_7391 = (ToNum(Add(GetIdx(L_7389, 4D), GetIdx(L_7389, 5D))) / 2D);
r_7392 = ((ToNum(GetIdx(L_7389, 1D)) - ToNum(GetIdx(L_7389, 0D))) / 2D);
if (((r_7392 > 7D) || ((ToNum(GetIdx(L_7389, 3D)) - ToNum(GetIdx(L_7389, 2D))) < 3D))) {
return default;
}
FC_7393 = Call(dec_24, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.6))).V);
FD_7394 = Call(dec_24, V.Undef, ((V)("#9ab8c8")), NewObj(1).Put("op", ((V)(0.45))).V);
Call(rep_29, V.Undef, ((V)(10D)), Fn((V _arrowThis7402, int _argc7395, V i_7401, V _a7398, V _a7399, V _a7400, V[] _rest7396) => {
double a_7403 = 0;
a_7403 = (((ToNum(i_7401) / 10D) * 2D) * PI_22);
Invoke((NumTruthy((ToNum(i_7401) % 2D)) ? FD_7394 : FC_7393), "line", Arr(Arr(((V)((cx_7390 + (FdLibm.Cos(a_7403) * ((r_7392 * 0.92) + 0.05))))), Add(GetIdx(L_7389, 2D), ((V)(0.6))), ((V)((cz_7391 + (FdLibm.Sin(a_7403) * ((r_7392 * 0.92) + 0.05)))))), Arr(((V)((cx_7390 + (FdLibm.Cos(a_7403) * ((r_7392 * 0.98) + 0.05))))), Add(GetIdx(L_7389, 2D), ((V)(((ToNum(GetIdx(L_7389, 3D)) - ToNum(GetIdx(L_7389, 2D))) * 0.55)))), ((V)((cz_7391 + (FdLibm.Sin(a_7403) * ((r_7392 * 0.98) + 0.05))))))), Arr(((V)(FdLibm.Cos(a_7403))), ((V)(0D)), ((V)(FdLibm.Sin(a_7403)))), ((V)(0.28)));
return default;
}, 1, "", true));
Call(ringD_99, V.Undef, FC_7393, ((V)(cx_7390)), ((V)(cz_7391)), ((V)((r_7392 * 0.96))), ((V)((ToNum(GetIdx(L_7389, 3D)) - 0.2))), ((V)(0.3)), ((V)(20D)));
Call(on_7116, V.Undef, S_7387, Arr(FD_7394, FC_7393));
return default;
}, 1, "", true));
Invoke(Invoke(o_7113, "filter", Fn((V _arrowThis7433, int _argc7426, V S_7432, V _a7429, V _a7430, V _a7431, V[] _rest7427) => {
return ((S_7432 is var _t7434 && !Truthy(_t7434) ? _t7434 : Get(S_7432, "pts")) is var _t7435 && !Truthy(_t7435) ? _t7435 : (SEqS(Get(S_7432, "col"), "#b8692a") ? V.True : V.False));
}, 1, "", true)), "forEach", Fn((V _arrowThis7423, int _argc7416, V S_7422, V _a7419, V _a7420, V _a7421, V[] _rest7417) => {
V L_7424 = default;
V WS_7425 = default;
L_7424 = Call(bbS_38, V.Undef, S_7422);
WS_7425 = Call(dec_24, V.Undef, ((V)("#e8a660")), NewObj(1).Put("op", ((V)(0.8))).V);
Call(spot_25, V.Undef, WS_7425, Arr(((V)(((ToNum(Add(GetIdx(L_7424, 0D), GetIdx(L_7424, 1D))) / 2D) - 0.5))), Add(GetIdx(L_7424, 3D), ((V)(0.05))), ((V)(((ToNum(Add(GetIdx(L_7424, 4D), GetIdx(L_7424, 5D))) / 2D) - 0.4)))), Y3_37, ((V)(((ToNum(GetIdx(L_7424, 1D)) - ToNum(GetIdx(L_7424, 0D))) * 0.3))), ((V)(((ToNum(GetIdx(L_7424, 5D)) - ToNum(GetIdx(L_7424, 4D))) * 0.22))), ((V)(0D)), ((V)(10D)));
Call(on_7116, V.Undef, S_7422, Arr(WS_7425));
return default;
}, 1, "", true));
bk_7121 = Invoke(Invoke(Invoke(o_7113, "filter", Fn((V _arrowThis7462, int _argc7455, V S_7461, V _a7458, V _a7459, V _a7460, V[] _rest7456) => {
return (((S_7461 is var _t7463 && !Truthy(_t7463) ? _t7463 : Get(S_7461, "pts")) is var _t7464 && !Truthy(_t7464) ? _t7464 : Get(Get(S_7461, "pts"), "length")) is var _t7465 && !Truthy(_t7465) ? _t7465 : (!SEqN(Get(S_7461, "cv"), 0D) ? V.True : V.False));
}, 1, "", true)), "map", Fn((V _arrowThis7454, int _argc7447, V S_7453, V _a7450, V _a7451, V _a7452, V[] _rest7448) => {
return NewObj(2).Put("S", S_7453).Put("L", Call(bbS_38, V.Undef, S_7453)).V;
}, 1, "", true)), "find", Fn((V _arrowThis7443, int _argc7436, V b_7442, V _a7439, V _a7440, V _a7441, V[] _rest7437) => {
return (((Invoke(NewRegExp(RX1, "^#[6-8]", ""), "test", Get(Get(b_7442, "S"), "col")) is var _t7444 && !Truthy(_t7444) ? _t7444 : (((ToNum(GetIdx(Get(b_7442, "L"), 3D)) - ToNum(GetIdx(Get(b_7442, "L"), 2D))) < 5D) ? V.True : V.False)) is var _t7445 && !Truthy(_t7445) ? _t7445 : (((ToNum(GetIdx(Get(b_7442, "L"), 1D)) - ToNum(GetIdx(Get(b_7442, "L"), 0D))) > 14D) ? V.True : V.False)) is var _t7446 && !Truthy(_t7446) ? _t7446 : (GtN(GetIdx(Get(b_7442, "L"), 2D), 40D) ? V.True : V.False));
}, 1, "", true));
if (Truthy(bk_7121)) {
V GT_7466 = default;
GT_7466 = Call(dec_24, V.Undef, ((V)("#f0c24a")), NewObj(1).Put("shine", ((V)(1D))).V);
Invoke(Call(caps_50, V.Undef, Get(bk_7121, "S"), ((V)(2D))), "forEach", Fn((V _arrowThis7474, int _argc7467, V F_7473, V _a7470, V _a7471, V _a7472, V[] _rest7468) => {
V G_7475 = default;
G_7475 = Call(fr2_39, V.Undef, F_7473);
Invoke(GT_7466, "line", Arr(Invoke(G_7475, "at", ((V)((-5D))), ((V)(3D))), Invoke(G_7475, "at", ((V)(5D)), ((V)(3D)))), Get(G_7475, "n"), ((V)(0.6)));
Invoke(GT_7466, "line", Arr(Invoke(G_7475, "at", ((V)((-4D))), ((V)(1.6))), Invoke(G_7475, "at", ((V)(4D)), ((V)(1.6)))), Get(G_7475, "n"), ((V)(0.3)));
Call(spot_25, V.Undef, GT_7466, Invoke(G_7475, "at", ((V)(0D)), ((V)((-1.2)))), Get(G_7475, "n"), ((V)(1.6)), ((V)(1.6)), ((V)(0D)), ((V)(10D)));
Invoke(GT_7466, "line", Invoke(Invoke(Call(rep_29, V.Undef, ((V)(9D)), Fn((V _arrowThis7483, int _argc7476, V i_7482, V _a7479, V _a7480, V _a7481, V[] _rest7477) => {
return Invoke(G_7475, "at", ((V)(((-6.5) + (ToNum(i_7482) * 0D)))), ((V)(0D)));
}, 1, "", true)), "slice", ((V)(0D)), ((V)(0D))), "concat", Arr(Invoke(G_7475, "at", ((V)((-6.6))), ((V)((-5D)))), Invoke(G_7475, "at", ((V)(6.6)), ((V)((-5D)))), Invoke(G_7475, "at", ((V)(6.6)), ((V)(5.4))), Invoke(G_7475, "at", ((V)((-6.6))), ((V)(5.4))), Invoke(G_7475, "at", ((V)((-6.6))), ((V)((-5D)))))), Get(G_7475, "n"), ((V)(0.25)));
return default;
}, 1, "", true));
Call(on_7116, V.Undef, Get(bk_7121, "S"), Arr(GT_7466));
}
return default;
}, 2, "", true)));
Set(RD_8, "SET25", NewObj(26).Put("LIV-033", NewObj(2).Put("spec", ((V)("pouf25"))).Put("note", ((V)("A round floor pouf that squishes when you sit on it, with a piped welt round the middle, a gathered button on top and a little pull loop. Each colour has its own fabric: chunky cable knit, macram\u00e9 cord with knots and fringe, soft velvet, stitched leather panels or nubby boucl\u00e9."))).V).Put("LIV-111", NewObj(2).Put("spec", ((V)("lux25"))).Put("note", ((V)("A gilded rococo coffee table: an oval white marble top with polished glints over a gold-leaf apron carved with C-scrolls and bead rows, on fluted cabriole legs. A cut-crystal whisky decanter and tumblers on a gold tray, roses, and a leather book with a gilt title."))).V).Put("LIV-107", NewObj(2).Put("spec", ((V)("chester25V2"))).Put("note", ((V)("A deep-buttoned chesterfield in emerald crushed velvet with a soft nap, self piping on the seats and scroll fronts, on ringed walnut bun feet. Two mustard velvet pillows with piping and corner tassels, a chunky oatmeal knit throw over one arm and a paperback left open on the other."))).V).Put("LIV-108", NewObj(2).Put("spec", ((V)("chester25L2"))).Put("note", ((V)("A deep-buttoned chesterfield in pebbled cognac leather, rubbed to a warm patina on the seat fronts and scroll tops, with soft creases where you sit. Dark welts with cream saddle stitching, brass nailheads, turned walnut bun feet, tartan pillows, a red tartan wool throw over one arm and a gilt-banded leather book with reading glasses on the other."))).V).Put("LIV-109", NewObj(2).Put("spec", ((V)("chester25B2"))).Put("note", ((V)("An ivory channel-tufted sofa in nubby boucl\u00e9 on a Calacatta marble plinth with grey and gold veins and a brushed brass band. Mustard velvet pillows, a fluffy sheepskin over one arm and a travertine tray with a lit candle and matches on the other."))).V).Put("LIV-062", NewObj(2).Put("spec", ((V)("alab25b"))).Put("note", ((V)("A totem of six alabaster stones with amber and white veins running round them, cloudy inclusions, hairline cracks and a warm glow from inside, on grooved bronze spacers over a patinated, hand-chiselled bronze base, with a cord and inline dimmer."))).V).Put("LIV-016", NewObj(2).Put("spec", ((V)("spool25"))).Put("note", ((V)("An old cable spool coffee table: layered plywood with rust round the bolts, splinters and stencilled letters, black cable still wound round the drum. A succulent in a tomato tin, a folded newspaper, a stack of wooden coasters and a mug on top."))).V).Put("LIV-002", NewObj(1).Put("spec", ((V)("torch25"))).V).Put("LIV-066", NewObj(2).Put("spec", ((V)("cloudPit25"))).Put("note", ((V)("A curved pit sofa of five puffy boucl\u00e9 modules on oak plinths, each seat with a piped welt, nubby loops all over, a chunky-knit mustard throw over the middle back cushion, a rust cable-knit pillow with pompoms and a fluffy faux-fur pillow."))).V).Put("LIV-013", NewObj(2).Put("spec", ((V)("box25"))).Put("note", ((V)("An old moving box turned footrest: corrugated cardboard held shut with silver duct tape, THIS SIDE UP arrows, a red FRAGILE stamp, a shipping label with a barcode, a crushed corner taped back up, a coffee ring and a water-stained bottom. A folded fleece blanket and the TV remote sit on top."))).V).Put("LIV-050", NewObj(2).Put("spec", ((V)("papasan25"))).Put("note", ((V)("A papasan on a black and brass swivel base: a woven rattan bowl with wrapped rim, a deep velvet cushion with pleats running into buttons, a welt round the edge and a piped velvet back pillow. A gold tassel hangs off the rim."))).V).Put("LIV-054", NewObj(2).Put("spec", ((V)("cattree25"))).Put("note", ((V)("A pet climbing tree of real birch logs with white bark and black marks on a felt base: a sisal-wrapped scratching post, a felt cave with a round door, felt beds with paw prints on the platforms, felt leaves on the logs and a red felt ball on a cord."))).V).Put("LIV-010", NewObj(2).Put("spec", ((V)("fold25"))).Put("note", ((V)("A grey metal folding chair that doesn\u2019t match anything: a scratched pine seat with a carved heart and a water ring, a back slat painted teal and chipped down to the wood with a star sticker, rusty spots on the legs, rubber feet (one is missing) and a red gingham pillow tied on with bows."))).V).Put("LIV-030", NewObj(2).Put("spec", ((V)("wing25"))).Put("note", ((V)("A mid-century wingback in mustard wool tweed flecked with rust, cream and olive, with button-tufted back, self piping on every edge and tapered walnut legs with brass tips. A rust knit throw hangs over one arm."))).V).Put("LIV-006", NewObj(2).Put("spec", ((V)("plaid25"))).Put("note", ((V)("A lumpy thrift-store two-seater in faded brown tartan with green bands and mustard lines, pilled all over. Saggy seats with dents and creases, a spring poking out of one cushion, a duct-tape X, a coffee ring, a corduroy patch sewn on the back, a threadbare arm, one odd wooden leg and a granny-square pillow."))).V).Put("LIV-026", NewObj(2).Put("spec", ((V)("scandi25"))).Put("note", ((V)("A clean Scandinavian three-seater in heathered grey woven fabric with piped welts, button-tufted back cushions and tapered oak legs on an oak rail. A mustard rib-knit pillow, a white pillow with a black zigzag print and an oatmeal waffle-knit throw over one arm."))).V).Put("LIV-046", NewObj(2).Put("spec", ((V)("cognac25"))).Put("note", ((V)("An L-shaped sectional in full-grain cognac leather with a chaise, rubbed to a warm patina on the seats and arms, soft creases, dark welts with cream saddle stitching. A cream boucl\u00e9 pillow, a charcoal herringbone wool pillow and a striped grey wool blanket folded across the chaise."))).V).Put("LIV-082", NewObj(1).Put("spec", ((V)("bio25"))).V).Put("LIV-100", NewObj(1).Put("spec", ((V)("terra25x"))).V).Put("LIV-088", NewObj(1).Put("spec", ((V)("chrono25x"))).V).Put("LIV-099", NewObj(1).Put("spec", ((V)("lev25x"))).V).Put("LIV-068", NewObj(1).Put("spec", ((V)("ikebana25x"))).V).Put("LIV-070", NewObj(2).Put("spec", ((V)("shear25"))).Put("note", ((V)("A low lounge chair in sculpted walnut with flowing grain, little knots and fine edge grain on every piece, holding fluffy cream shearling cushions. Two cognac leather straps run over the back with brass buckles."))).V).Put("LIV-086", NewObj(3).Put("spec", ((V)("lev25"))).Put("live", ((V)("Levitating"))).Put("note", ((V)("A cloud-soft cashmere sofa in fine rib-knit with cable-knit back cushions, floating above a black-glass magnetic pad. The smart-gel seats glow with warm heat nodes and a touch dial sets the warmth; a caramel cashmere throw with fringe drapes over one arm. Magnetic rings rise under it and warm air shimmers over the seats."))).V).Put("LIV-110", NewObj(2).Put("spec", ((V)("chester25"))).Put("note", ((V)("A grand four-seat chesterfield in crushed royal velvet with deep tufting, gold piping and gold nailheads, on a gold-leaf apron with bullion fringe and gilded bun feet. A carved gilt shell crest with acanthus scrolls crowns the back; gold damask pillows and an emerald bolster embroidered with a crown and gold tassels."))).V).Put("LIV-090", NewObj(3).Put("spec", ((V)("throne25"))).Put("live", ((V)("Floating"))).Put("note", ((V)("A floating lounge throne with a gloss carbon-fibre twill shell, quilted perforated leather seat and back with stitched welts, cyan LED loops on the scrolls and wings, speakers in the wings and a glowing crest on the back. Two gyro rings orbit it over a black-glass magnetic pad."))).V).V);
edit24_114 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis7491, int _argc7484, V rows_7490, V _a7487, V _a7488, V _a7489, V[] _rest7485) => {
return Invoke(Call(edit24_114, V.Undef, rows_7490), "map", Fn((V _arrowThis7499, int _argc7492, V r_7498, V _a7495, V _a7496, V _a7497, V[] _rest7493) => {
return (Truthy(GetK(Get(RD_8, "SET25"), Get(r_7498, "id"))) ? Object_assign(NewObj(0).V, r_7498, GetK(Get(RD_8, "SET25"), Get(r_7498, "id"))) : r_7498);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H25", NewObj(12).Put("fr2", fr2_39).Put("clip", clip_42).Put("hatch", hatch_45).Put("wavy", wavy_46).Put("outline", outline_47).Put("dots", dots_48).Put("ringL", ringL_49).Put("caps", caps_50).Put("sides", sides_51).Put("padFx", padFx_53).Put("gyro", gyro_63).Put("bbS", bbS_38).V);
Set(RD_8, "PLUS25", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
