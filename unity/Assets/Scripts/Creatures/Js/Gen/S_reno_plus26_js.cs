// reno-plus26.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus26_js
    {

        public static void Run()
        {
Call(Named(boot_97 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V solid_11 = default;
V ball_12 = default;
V box_13 = default;
V cyl_14 = default;
V arcW_15 = default;
V disc_16 = default;
V pillowZ_17 = default;
V shade_18 = default;
V mix_19 = default;
V f1_20 = default;
V N_21 = default;
double PI_22 = 0;
V GOLD_23 = default;
V BR_24 = default;
V SA_25 = default;
V CA_26 = default;
V dec_27 = default;
V spot_28 = default;
V elP_29 = default;
V wv_30 = default;
V at_31 = default;
V ringY_32 = default;
V glue_33 = default;
V R0_34 = default;
V rep_35 = default;
V rod_36 = default;
V pipe_37 = default;
V tilt_38 = default;
V M__39 = default;
V W__40 = default;
V F__41 = default;
V PL_42 = default;
V em_43 = default;
V bobA_44 = default;
V fr2_45 = default;
V hatch_46 = default;
V wavy_47 = default;
V outline_48 = default;
V dots_49 = default;
V caps_50 = default;
V sides_51 = default;
V bbS_52 = default;
V add_53 = default;
V sub_54 = default;
V mul_55 = default;
V cr_56 = default;
V nz_57 = default;
V X3_58 = default;
V Y3_59 = default;
V Z3_60 = default;
V mvPts_61 = default;
V drop_62 = default;
V cen_63 = default;
V eS_64 = default;
V lineOn_65 = default;
V plane_66 = default;
V WH2_67 = default;
V nap_68 = default;
V fleck_69 = default;
V grainF_70 = default;
V roots_71 = default;
V btn_72 = default;
V tuftGrid_73 = default;
V GLY_74 = default;
V SHP_75 = default;
V ABC_ORDER_76 = default;
double SXc_77 = 0;
double SYc_78 = 0;
double SRc_79 = 0;
double MXc_80 = 0;
V CRG_81 = default;
V ringsSVG_82 = default;
V fruitDecor_83 = default;
V leaf_84 = default;
V mkFruit_85 = default;
V ikeMore_86 = default;
V terraMore_87 = default;
V big_88 = default;
V edit25_89 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((((((RD_8 is var _t90 && !Truthy(_t90) ? _t90 : Get(RD_8, "PLUS25")) is var _t91 && !Truthy(_t91) ? _t91 : Get(RD_8, "H25")) is var _t92 && !Truthy(_t92) ? _t92 : Get(RD_8, "H24")) is var _t93 && !Truthy(_t93) ? _t93 : Get(RD_8, "H22")) is var _t94 && !Truthy(_t94) ? _t94 : Get(RD_8, "H16")) is var _t95 && !Truthy(_t95) ? _t95 : X_9) is var _t96 && !Truthy(_t96) ? _t96 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_97.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS26"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t98 = K_10;
if (_t98.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t98));
{ V _t99 = Get(_t98, "solid");
solid_11 = _t99; }
{ V _t100 = Get(_t98, "ball");
ball_12 = _t100; }
{ V _t101 = Get(_t98, "box");
box_13 = _t101; }
{ V _t102 = Get(_t98, "cyl");
cyl_14 = _t102; }
{ V _t103 = Get(_t98, "arcW");
arcW_15 = _t103; }
{ V _t104 = Get(_t98, "disc");
disc_16 = _t104; }
{ V _t105 = Get(_t98, "pillowZ");
pillowZ_17 = _t105; }
{ V _t106 = Get(_t98, "shade");
shade_18 = _t106; }
{ V _t107 = Get(_t98, "mix");
mix_19 = _t107; }
{ V _t108 = Get(_t98, "f1");
f1_20 = _t108; } }
N_21 = Get(RD_8, "N");
PI_22 = System.Math.PI;
GOLD_23 = ((V)("#e2b14a"));
BR_24 = ((V)("#d4a548"));
SA_25 = Get(X_9, "SA");
CA_26 = Get(X_9, "CA");
{ V _t109 = Get(RD_8, "H24");
if (_t109.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t109));
{ V _t110 = Get(_t109, "dec");
dec_27 = _t110; }
{ V _t111 = Get(_t109, "spot");
spot_28 = _t111; }
{ V _t112 = Get(_t109, "elP");
elP_29 = _t112; }
{ V _t113 = Get(_t109, "wv");
wv_30 = _t113; }
{ V _t114 = Get(_t109, "at");
at_31 = _t114; }
{ V _t115 = Get(_t109, "ringY");
ringY_32 = _t115; } }
{ V _t116 = Get(RD_8, "H22");
if (_t116.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t116));
{ V _t117 = Get(_t116, "glue");
glue_33 = _t117; }
{ V _t118 = Get(_t116, "R0");
R0_34 = _t118; } }
{ V _t119 = Get(RD_8, "H16");
if (_t119.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t119));
{ V _t120 = Get(_t119, "rep");
rep_35 = _t120; }
{ V _t121 = Get(_t119, "rod");
rod_36 = _t121; }
{ V _t122 = Get(_t119, "pipe");
pipe_37 = _t122; }
{ V _t123 = Get(_t119, "tilt");
tilt_38 = _t123; }
{ V _t124 = Get(_t119, "M_");
M__39 = _t124; }
{ V _t125 = Get(_t119, "W_");
W__40 = _t125; }
{ V _t126 = Get(_t119, "F_");
F__41 = _t126; }
{ V _t127 = Get(_t119, "PL");
PL_42 = _t127; }
{ V _t128 = Get(_t119, "em");
em_43 = _t128; }
{ V _t129 = Get(_t119, "bobA");
bobA_44 = _t129; } }
{ V _t130 = Get(RD_8, "H25");
if (_t130.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t130));
{ V _t131 = Get(_t130, "fr2");
fr2_45 = _t131; }
{ V _t132 = Get(_t130, "hatch");
hatch_46 = _t132; }
{ V _t133 = Get(_t130, "wavy");
wavy_47 = _t133; }
{ V _t134 = Get(_t130, "outline");
outline_48 = _t134; }
{ V _t135 = Get(_t130, "dots");
dots_49 = _t135; }
{ V _t136 = Get(_t130, "caps");
caps_50 = _t136; }
{ V _t137 = Get(_t130, "sides");
sides_51 = _t137; }
{ V _t138 = Get(_t130, "bbS");
bbS_52 = _t138; } }
add_53 = Fn((V _arrowThis147, int _argc139, V a_145, V b_146, V _a143, V _a144, V[] _rest140) => {
return Arr(Add(GetIdx(a_145, 0D), GetIdx(b_146, 0D)), Add(GetIdx(a_145, 1D), GetIdx(b_146, 1D)), Add(GetIdx(a_145, 2D), GetIdx(b_146, 2D)));
}, 2, "", true);
sub_54 = Fn((V _arrowThis156, int _argc148, V a_154, V b_155, V _a152, V _a153, V[] _rest149) => {
return Arr(((V)((ToNum(GetIdx(a_154, 0D)) - ToNum(GetIdx(b_155, 0D))))), ((V)((ToNum(GetIdx(a_154, 1D)) - ToNum(GetIdx(b_155, 1D))))), ((V)((ToNum(GetIdx(a_154, 2D)) - ToNum(GetIdx(b_155, 2D))))));
}, 2, "", true);
mul_55 = Fn((V _arrowThis165, int _argc157, V a_163, V k_164, V _a161, V _a162, V[] _rest158) => {
return Arr(((V)((ToNum(GetIdx(a_163, 0D)) * ToNum(k_164)))), ((V)((ToNum(GetIdx(a_163, 1D)) * ToNum(k_164)))), ((V)((ToNum(GetIdx(a_163, 2D)) * ToNum(k_164)))));
}, 2, "", true);
cr_56 = Fn((V _arrowThis174, int _argc166, V a_172, V b_173, V _a170, V _a171, V[] _rest167) => {
return Arr(((V)(((ToNum(GetIdx(a_172, 1D)) * ToNum(GetIdx(b_173, 2D))) - (ToNum(GetIdx(a_172, 2D)) * ToNum(GetIdx(b_173, 1D)))))), ((V)(((ToNum(GetIdx(a_172, 2D)) * ToNum(GetIdx(b_173, 0D))) - (ToNum(GetIdx(a_172, 0D)) * ToNum(GetIdx(b_173, 2D)))))), ((V)(((ToNum(GetIdx(a_172, 0D)) * ToNum(GetIdx(b_173, 1D))) - (ToNum(GetIdx(a_172, 1D)) * ToNum(GetIdx(b_173, 0D)))))));
}, 2, "", true);
nz_57 = Fn((V _arrowThis182, int _argc175, V a_181, V _a178, V _a179, V _a180, V[] _rest176) => {
V L_183 = default;
L_183 = (((V)(Hypot(ToNum(GetIdx(a_181, 0D)), ToNum(GetIdx(a_181, 1D)), ToNum(GetIdx(a_181, 2D))))) is var _t184 && Truthy(_t184) ? _t184 : ((V)(1D)));
return Arr(((V)((ToNum(GetIdx(a_181, 0D)) / ToNum(L_183)))), ((V)((ToNum(GetIdx(a_181, 1D)) / ToNum(L_183)))), ((V)((ToNum(GetIdx(a_181, 2D)) / ToNum(L_183)))));
return default;
}, 1, "", true);
X3_58 = Arr(((V)(1D)), ((V)(0D)), ((V)(0D)));
Y3_59 = Arr(((V)(0D)), ((V)(1D)), ((V)(0D)));
Z3_60 = Arr(((V)(0D)), ((V)(0D)), ((V)(1D)));
mvPts_61 = Fn((V _arrowThis193, int _argc185, V S_191, V f_192, V _a189, V _a190, V[] _rest186) => {
V seen_194 = default;
V mv_195 = default;
seen_194 = New(G("Set"));
mv_195 = Fn((V _arrowThis203, int _argc196, V p_202, V _a199, V _a200, V _a201, V[] _rest197) => {
V q_204 = default;
if (Truthy(Invoke(seen_194, "has", p_202))) {
return default;
}
Invoke(seen_194, "add", p_202);
q_204 = Call(f_192, V.Undef, p_202);
SetIdx(p_202, 0D, GetIdx(q_204, 0D));
SetIdx(p_202, 1D, GetIdx(q_204, 1D));
SetIdx(p_202, 2D, GetIdx(q_204, 2D));
return default;
}, 1, "", true);
Invoke(Get(S_191, "pts"), "forEach", mv_195);
Invoke(Get(S_191, "faces"), "forEach", Fn((V _arrowThis212, int _argc205, V F_211, V _a208, V _a209, V _a210, V[] _rest206) => {
return Invoke(Get(F_211, "q"), "forEach", mv_195);
}, 1, "", true));
return default;
}, 2, "", true);
drop_62 = Fn((V _arrowThis221, int _argc213, V o_219, V pred_220, V _a217, V _a218, V[] _rest214) => {
V del_222 = default;
double g_223 = 0;
del_222 = New(G("Set"), Invoke(o_219, "filter", pred_220));
g_223 = 1D;
while (NumTruthy(g_223)) {
g_223 = 0D;
Invoke(o_219, "forEach", Fn((V _arrowThis231, int _argc224, V S_230, V _a227, V _a228, V _a229, V[] _rest225) => {
if (Truthy(((Get(S_230, "par") is var _t232 && !Truthy(_t232) ? _t232 : Invoke(del_222, "has", Get(S_230, "par"))) is var _t233 && !Truthy(_t233) ? _t233 : (!(Truthy(Invoke(del_222, "has", S_230))) ? V.True : V.False)))) {
Invoke(del_222, "add", S_230);
g_223 = 1D;
}
return default;
}, 1, "", true));
}
{
double i_234 = 0;
i_234 = (ToNum(Get(o_219, "length")) - 1D);
while (true) {
if (!((i_234 >= 0D))) break;
if (Truthy(Invoke(del_222, "has", GetIdx(o_219, i_234)))) {
Invoke(o_219, "splice", ((V)(i_234)), ((V)(1D)));
}
i_234--;
}
}
return default;
}, 2, "", true);
cen_63 = Fn((V _arrowThis243, int _argc236, V S_242, V _a239, V _a240, V _a241, V[] _rest237) => {
V L_244 = default;
L_244 = Call(bbS_52, V.Undef, S_242);
return Arr(((V)((ToNum(Add(GetIdx(L_244, 0D), GetIdx(L_244, 1D))) / 2D))), ((V)((ToNum(Add(GetIdx(L_244, 2D), GetIdx(L_244, 3D))) / 2D))), ((V)((ToNum(Add(GetIdx(L_244, 4D), GetIdx(L_244, 5D))) / 2D))));
return default;
}, 1, "", true);
eS_64 = Fn((V _arrowThis255, int _argc245, V c_251, V a_252, V b_253, V cz_254, V[] _rest246) => {
return Fn((V _arrowThis263, int _argc256, V d_262, V _a259, V _a260, V _a261, V[] _rest257) => {
V u_264 = default;
u_264 = Call(nz_57, V.Undef, d_262);
return Arr(Call(add_53, V.Undef, c_251, Arr(((V)((ToNum(GetIdx(u_264, 0D)) * ToNum(a_252)))), ((V)((ToNum(GetIdx(u_264, 1D)) * ToNum(b_253)))), ((V)((ToNum(GetIdx(u_264, 2D)) * ToNum(cz_254)))))), Call(nz_57, V.Undef, Arr(((V)((ToNum(GetIdx(u_264, 0D)) / ToNum(a_252)))), ((V)((ToNum(GetIdx(u_264, 1D)) / ToNum(b_253)))), ((V)((ToNum(GetIdx(u_264, 2D)) / ToNum(cz_254)))))));
return default;
}, 1, "", true);
}, 4, "", true);
lineOn_65 = Fn((V _arrowThis276, int _argc265, V D_271, V f_272, V m_273, V w_274, V[] _rest266) => {
V Q_277 = default;
V tp_275 = default;
tp_275 = (_argc265 > 4 ? _rest266[0] : V.Undef);
Q_277 = Call(rep_35, V.Undef, Add(m_273, ((V)(1D))), Fn((V _arrowThis285, int _argc278, V i_284, V _a281, V _a282, V _a283, V[] _rest279) => {
return Call(f_272, V.Undef, ((V)((ToNum(i_284) / ToNum(m_273)))));
}, 1, "", true));
Invoke(D_271, "line", Invoke(Q_277, "map", Fn((V _arrowThis293, int _argc286, V q_292, V _a289, V _a290, V _a291, V[] _rest287) => {
return GetIdx(q_292, 0D);
}, 1, "", true)), Invoke(Q_277, "map", Fn((V _arrowThis301, int _argc294, V q_300, V _a297, V _a298, V _a299, V[] _rest295) => {
return GetIdx(q_300, 1D);
}, 1, "", true)), w_274, tp_275);
return default;
}, 5, "", true);
plane_66 = Fn((V _arrowThis311, int _argc302, V c_308, V u_309, V v_310, V _a307, V[] _rest303) => {
return Fn((V _arrowThis320, int _argc312, V a_318, V b_319, V _a316, V _a317, V[] _rest313) => {
return Call(add_53, V.Undef, c_308, Call(add_53, V.Undef, Call(mul_55, V.Undef, u_309, a_318), Call(mul_55, V.Undef, v_310, b_319)));
}, 2, "", true);
}, 3, "", true);
WH2_67 = Fn((V _arrowThis328, int _argc321, V G_327, V _a324, V _a325, V _a326, V[] _rest322) => {
V xs_329 = default;
V ys_330 = default;
xs_329 = Invoke(Get(G_327, "P"), "map", Fn((V _arrowThis338, int _argc331, V q_337, V _a334, V _a335, V _a336, V[] _rest332) => {
return GetIdx(q_337, 0D);
}, 1, "", true));
ys_330 = Invoke(Get(G_327, "P"), "map", Fn((V _arrowThis346, int _argc339, V q_345, V _a342, V _a343, V _a344, V[] _rest340) => {
return GetIdx(q_345, 1D);
}, 1, "", true));
return Arr(((V)((ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_329).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_329).V))))), ((V)((ToNum(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_330).V)) - ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_330).V))))));
return default;
}, 1, "", true);
nap_68 = Fn((V _arrowThis358, int _argc347, V D1_353, V D2_354, V F_355, V R_356, V[] _rest348) => {
V n_357 = default;
n_357 = (_argc347 > 4 ? _rest348[0] : V.Undef);
return Call(rep_35, V.Undef, n_357, Fn((V _arrowThis366, int _argc359, V i_365, V _a362, V _a363, V _a364, V[] _rest360) => {
double ph_367 = 0;
double yy_368 = 0;
double amp_369 = 0;
ph_367 = (ToNum(Call(R_356, V.Undef)) * 6D);
yy_368 = ((ToNum(Call(R_356, V.Undef)) * 0.8) - 0.4);
amp_369 = (0.05 + (ToNum(Call(R_356, V.Undef)) * 0.08));
Call(wavy_47, V.Undef, (NumTruthy((ToNum(i_365) % 2D)) ? D2_354 : D1_353), F_355, Fn((V _arrowThis378, int _argc370, V t_376, V G_377, V _a374, V _a375, V[] _rest371) => {
V W_379 = default;
V H_380 = default;
{ V _t381 = Call(WH2_67, V.Undef, G_377);
{ V _t382 = ListOf(_t381);
{ V _t383 = GetIdx(_t382, 0D);
W_379 = _t383; }
{ V _t384 = GetIdx(_t382, 1D);
H_380 = _t384; }
} }
return Arr(((V)((((-ToNum(W_379)) / 2D) + (ToNum(W_379) * ToNum(t_376))))), ((V)(((yy_368 * ToNum(H_380)) + ((FdLibm.Sin(((ToNum(t_376) * 5D) + ph_367)) * ToNum(H_380)) * amp_369)))));
return default;
}, 2, "", true), ((V)(24D)), ((V)((1.6 + (ToNum(Call(R_356, V.Undef)) * 2D)))), ((V)(1D)));
return default;
}, 1, "", true));
}, 5, "", true);
fleck_69 = Fn((V _arrowThis397, int _argc385, V D1_391, V D2_392, V F_393, V R_394, V[] _rest386) => {
V G_398 = default;
V W_399 = default;
V H_400 = default;
V n_395 = default;
V r_396 = default;
n_395 = (_argc385 > 4 ? _rest386[0] : V.Undef);
r_396 = (_argc385 > 5 ? _rest386[1] : V.Undef);
G_398 = Call(fr2_45, V.Undef, F_393);
{ V _t401 = Call(WH2_67, V.Undef, G_398);
{ V _t402 = ListOf(_t401);
{ V _t403 = GetIdx(_t402, 0D);
W_399 = _t403; }
{ V _t404 = GetIdx(_t402, 1D);
H_400 = _t404; }
} }
Call(rep_35, V.Undef, n_395, Fn((V _arrowThis412, int _argc405, V k_411, V _a408, V _a409, V _a410, V[] _rest406) => {
double a_413 = 0;
double b_414 = 0;
double rr_415 = 0;
a_413 = (((ToNum(Call(R_394, V.Undef)) - 0.5) * ToNum(W_399)) * 0.9);
b_414 = (((ToNum(Call(R_394, V.Undef)) - 0.5) * ToNum(H_400)) * 0.9);
rr_415 = (ToNum(r_396) * (0.6 + (ToNum(Call(R_394, V.Undef)) * 0.8)));
Call(spot_28, V.Undef, (NumTruthy((ToNum(k_411) % 2D)) ? D2_392 : D1_391), Invoke(G_398, "at", ((V)(a_413)), ((V)(b_414))), Get(G_398, "n"), ((V)(rr_415)), ((V)((rr_415 * 0.8))), ((V)((ToNum(Call(R_394, V.Undef)) * 3D))), ((V)(6D)));
return default;
}, 1, "", true));
return default;
}, 6, "", true);
grainF_70 = Fn((V _arrowThis428, int _argc416, V D1_422, V D2_423, V F_424, V R_425, V[] _rest417) => {
V G_429 = default;
double best_430 = 0;
double th_431 = 0;
V dir_432 = default;
V m_433 = default;
V E_434 = default;
double n_435 = 0;
V sp_426 = default;
V w_427 = default;
sp_426 = (_argc416 > 4 ? _rest417[0] : V.Undef);
w_427 = (_argc416 > 5 ? _rest417[1] : V.Undef);
G_429 = Call(fr2_45, V.Undef, F_424);
best_430 = 0D;
th_431 = 0D;
Invoke(Get(G_429, "P"), "forEach", Fn((V _arrowThis444, int _argc436, V p_442, V i_443, V _a440, V _a441, V[] _rest437) => {
V q_445 = default;
double L_446 = 0;
q_445 = GetIdx(Get(G_429, "P"), (ToNum(Add(i_443, ((V)(1D)))) % ToNum(Get(Get(G_429, "P"), "length"))));
L_446 = Hypot((ToNum(GetIdx(q_445, 0D)) - ToNum(GetIdx(p_442, 0D))), (ToNum(GetIdx(q_445, 1D)) - ToNum(GetIdx(p_442, 1D))));
if ((L_446 > best_430)) {
best_430 = L_446;
th_431 = FdLibm.Atan2((ToNum(GetIdx(q_445, 1D)) - ToNum(GetIdx(p_442, 1D))), (ToNum(GetIdx(q_445, 0D)) - ToNum(GetIdx(p_442, 0D))));
}
return default;
}, 2, "", true));
dir_432 = Arr(((V)(FdLibm.Cos(th_431))), ((V)(FdLibm.Sin(th_431))));
m_433 = Arr(((V)((-ToNum(GetIdx(dir_432, 1D))))), GetIdx(dir_432, 0D));
E_434 = InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(Invoke(Get(G_429, "P"), "map", Fn((V _arrowThis454, int _argc447, V q_453, V _a450, V _a451, V _a452, V[] _rest448) => {
return ((V)(Hypot(ToNum(GetIdx(q_453, 0D)), ToNum(GetIdx(q_453, 1D)))));
}, 1, "", true))).V);
n_435 = Max(1D, System.Math.Floor(((2D * ToNum(E_434)) / ToNum(sp_426))));
Call(rep_35, V.Undef, ((V)(n_435)), Fn((V _arrowThis462, int _argc455, V k_461, V _a458, V _a459, V _a460, V[] _rest456) => {
double s_463 = 0;
double ph_464 = 0;
s_463 = (((-ToNum(E_434)) + (ToNum(Add(k_461, ((V)(0.5)))) * ToNum(sp_426))) + (((ToNum(Call(R_425, V.Undef)) - 0.5) * ToNum(sp_426)) * 0.5));
ph_464 = (ToNum(Call(R_425, V.Undef)) * 6D);
Call(wavy_47, V.Undef, (NumTruthy((ToNum(k_461) % 2D)) ? D2_423 : D1_422), F_424, Fn((V _arrowThis472, int _argc465, V t_471, V _a468, V _a469, V _a470, V[] _rest466) => {
double u_473 = 0;
double off_474 = 0;
u_473 = ((-ToNum(E_434)) + ((2D * ToNum(E_434)) * ToNum(t_471)));
off_474 = (s_463 + (0.4 * FdLibm.Sin(((u_473 * 0.13) + ph_464))));
return Arr(((V)(((ToNum(GetIdx(dir_432, 0D)) * u_473) + (ToNum(GetIdx(m_433, 0D)) * off_474)))), ((V)(((ToNum(GetIdx(dir_432, 1D)) * u_473) + (ToNum(GetIdx(m_433, 1D)) * off_474)))));
return default;
}, 1, "", true), ((V)(26D)), ((V)((ToNum((w_427 is var _t475 && Truthy(_t475) ? _t475 : ((V)(0.25)))) * (0.7 + (ToNum(Call(R_425, V.Undef)) * 0.6))))), ((V)(1D)));
return default;
}, 1, "", true));
return default;
}, 6, "", true);
roots_71 = Fn((V _arrowThis483, int _argc476, V o_482, V _a479, V _a480, V _a481, V[] _rest477) => {
return Invoke(o_482, "filter", Fn((V _arrowThis491, int _argc484, V S_490, V _a487, V _a488, V _a489, V[] _rest485) => {
return (((S_490 is var _t492 && !Truthy(_t492) ? _t492 : Get(S_490, "pts")) is var _t493 && !Truthy(_t493) ? _t493 : Get(Get(S_490, "pts"), "length")) is var _t494 && !Truthy(_t494) ? _t494 : (!(Truthy(Get(S_490, "par"))) ? V.True : V.False));
}, 1, "", true));
}, 1, "", true);
{
V ch0_495 = default;
ch0_495 = Get(N_21, "chester");
Set(N_21, "chester", Fn((V _arrowThis503, int _argc496, V S_502, V _a499, V _a500, V _a501, V[] _rest497) => {
V D_504 = default;
V n_505 = default;
V chn_506 = default;
double AW_507 = 0;
double Wd_508 = 0;
double BZ0_509 = 0;
double z0_510 = 0;
double ZF_511 = 0;
double xr_512 = 0;
double kx_513 = 0;
double kz_514 = 0;
V L0_515 = default;
D_504 = Call(ch0_495, V.Undef, S_502);
n_505 = (Get(S_502, "n") is var _t516 && Truthy(_t516) ? _t516 : ((V)(3D)));
chn_506 = (SEqS(Get(S_502, "st"), "channel") ? V.True : V.False);
AW_507 = (Truthy(chn_506) ? 21D : 24D);
Wd_508 = ((ToNum(n_505) * 58D) + (AW_507 * 2D));
BZ0_509 = (-47D);
z0_510 = (BZ0_509 + 3D);
ZF_511 = 47D;
xr_512 = ((Wd_508 / 2D) - AW_507);
kx_513 = ((xr_512 - 0.45) / ((Wd_508 / 2D) - 1D));
kz_514 = ((ZF_511 - BZ0_509) / (ZF_511 - z0_510));
L0_515 = Get(D_504, "layers");
Set(D_504, "layers", Invoke(L0_515, "map", Fn((V _arrowThis525, int _argc517, V L_523, V i_524, V _a521, V _a522, V[] _rest518) => {
return (SEqN(i_524, 0D) ? Object_assign(NewObj(0).V, L_523, NewObj(1).Put("build", Fn((V _arrowThis533, int _argc526, V P_532, V _a529, V _a530, V _a531, V[] _rest527) => {
V o_534 = default;
o_534 = Invoke(L_523, "build", P_532);
Invoke(Call(roots_71, V.Undef, o_534), "forEach", Fn((V _arrowThis542, int _argc535, V S0_541, V _a538, V _a539, V _a540, V[] _rest536) => {
return Call(mvPts_61, V.Undef, S0_541, Fn((V _arrowThis550, int _argc543, V p_549, V _a546, V _a547, V _a548, V[] _rest544) => {
return Arr(((V)((ToNum(GetIdx(p_549, 0D)) * kx_513))), GetIdx(p_549, 1D), GetIdx(p_549, 2D));
}, 1, "", true));
}, 1, "", true));
return o_534;
return default;
}, 1, "build", true)).V) : ((SEqN(i_524, 1D) || SEqN(i_524, 3D)) ? Object_assign(NewObj(0).V, L_523, NewObj(1).Put("build", Fn((V _arrowThis558, int _argc551, V P_557, V _a554, V _a555, V _a556, V[] _rest552) => {
V o_559 = default;
o_559 = Invoke(L_523, "build", P_557);
Invoke(Call(roots_71, V.Undef, o_559), "forEach", Fn((V _arrowThis567, int _argc560, V S0_566, V _a563, V _a564, V _a565, V[] _rest561) => {
return Call(mvPts_61, V.Undef, S0_566, Fn((V _arrowThis575, int _argc568, V p_574, V _a571, V _a572, V _a573, V[] _rest569) => {
return Arr(GetIdx(p_574, 0D), GetIdx(p_574, 1D), (LtN(GetIdx(p_574, 2D), ZF_511) ? ((V)((ZF_511 - ((ZF_511 - ToNum(GetIdx(p_574, 2D))) * kz_514)))) : GetIdx(p_574, 2D)));
}, 1, "", true));
}, 1, "", true));
return o_559;
return default;
}, 1, "build", true)).V) : L_523));
}, 2, "", true)));
Set(D_504, "geo26", NewObj(14).Put("n", n_505).Put("AW", ((V)(AW_507))).Put("Wd", ((V)(Wd_508))).Put("xl", ((V)((-xr_512)))).Put("xr", ((V)(xr_512))).Put("BZ0", ((V)(BZ0_509))).Put("BZ1", ((V)((BZ0_509 + 18D)))).Put("ZF", ((V)(ZF_511))).Put("RT", ((V)(22D))).Put("ST", ((V)(31D))).Put("CT", ((V)(44D))).Put("TOP", ((V)((22D + (Truthy(chn_506) ? 50D : 46D))))).Put("rollY", ((V)(((22D + (Truthy(chn_506) ? 50D : 46D)) - (Truthy(chn_506) ? 5D : 6D))))).Put("rB", ((V)((Truthy(chn_506) ? 6D : 7.6)))).V);
return D_504;
return default;
}, 1, "", true));
}
btn_72 = Fn((V _arrowThis586, int _argc576, V c_582, V n_583, V col_584, V r_585, V[] _rest577) => {
return Call(ball_12, V.Undef, GetIdx(c_582, 0D), ((V)((ToNum(GetIdx(c_582, 1D)) - ToNum(r_585)))), GetIdx(c_582, 2D), r_585, col_584, Object_assign(NewObj(5).Put("k", ((V)(3D))).Put("n", ((V)(9D))).Put("mat", ((V)("fab"))).Put("shine", ((V)(0D))).Put("noOut", ((V)(1D))).V, ((System.Math.Abs(ToNum(GetIdx(n_583, 0D))) > 0.5) ? NewObj(1).Put("sx", ((V)(0.45))).V : NewObj(1).Put("sz", ((V)(0.45))).V)));
}, 4, "", true);
tuftGrid_73 = Fn((V _arrowThis603, int _argc587, V on_593, V host_594, V PT_595, V n_596, V[] _rest588) => {
V DK_604 = default;
V DM_605 = default;
V HL_606 = default;
V HL2_607 = default;
double cols_608 = 0;
double rows_609 = 0;
double da_610 = 0;
double db_611 = 0;
V G_612 = default;
V B_613 = default;
V BH_614 = default;
V a0_597 = default;
V a1_598 = default;
V b0_599 = default;
V b1_600 = default;
V F0_601 = default;
V pleat_602 = default;
a0_597 = (_argc587 > 4 ? _rest588[0] : V.Undef);
a1_598 = (_argc587 > 5 ? _rest588[1] : V.Undef);
b0_599 = (_argc587 > 6 ? _rest588[2] : V.Undef);
b1_600 = (_argc587 > 7 ? _rest588[3] : V.Undef);
F0_601 = (_argc587 > 8 ? _rest588[4] : V.Undef);
pleat_602 = (_argc587 > 9 ? _rest588[5] : V.Undef);
DK_604 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, F0_601, ((V)(0.5))), NewObj(1).Put("op", ((V)(0.6))).V);
DM_605 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, F0_601, ((V)(0.38))), NewObj(1).Put("op", ((V)(0.55))).V);
HL_606 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, F0_601, ((V)("#ffffff")), ((V)(0.32))), NewObj(1).Put("op", ((V)(0.24))).V);
HL2_607 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, F0_601, ((V)("#ffffff")), ((V)(0.18))), NewObj(1).Put("op", ((V)(0.2))).V);
cols_608 = Max(2D, Round(((ToNum(a1_598) - ToNum(a0_597)) / 9.2)));
rows_609 = Max(1D, Round(((ToNum(b1_600) - ToNum(b0_599)) / 7.4)));
da_610 = ((ToNum(a1_598) - ToNum(a0_597)) / cols_608);
db_611 = ((ToNum(b1_600) - ToNum(b0_599)) / rows_609);
G_612 = New(G("Map"));
B_613 = Arr();
{
double j_615 = 0;
j_615 = 0D;
while (true) {
if (!((j_615 <= rows_609))) break;
{
double i_617 = 0;
i_617 = 0D;
while (true) {
if (!((i_617 <= cols_608))) break;
if ((((i_617 + j_615) % 2D) == 0D)) {
V q_619 = default;
q_619 = Arr(Add(a0_597, ((V)((i_617 * da_610)))), Add(b0_599, ((V)((j_615 * db_611)))));
Invoke(G_612, "set", ((V)(JsStrBuf.Begin().N(i_617).S(",").N(j_615).End())), q_619);
Invoke(B_613, "push", Arr(q_619, ((V)(i_617)), ((V)(j_615))));
}
i_617++;
}
}
j_615++;
}
}
{
double j_620 = 0;
j_620 = 0D;
while (true) {
if (!((j_620 <= rows_609))) break;
{
double i_622 = 0;
i_622 = 0D;
while (true) {
if (!((i_622 <= cols_608))) break;
if ((((((((i_622 + j_620) % 2D) == 1D) && (i_622 > 0D)) && (i_622 < cols_608)) && (j_620 > 0D)) && (j_620 < rows_609))) {
Call(spot_28, V.Undef, HL_606, Call(PT_595, V.Undef, ((V)((ToNum(Add(a0_597, ((V)((i_622 * da_610))))) - 0.6))), Add(Add(b0_599, ((V)((j_620 * db_611)))), ((V)(0.5)))), n_596, ((V)((da_610 * 0.32))), ((V)((db_611 * 0.26))), ((V)(0D)), ((V)(10D)));
Call(spot_28, V.Undef, HL2_607, Call(PT_595, V.Undef, ((V)((ToNum(Add(a0_597, ((V)((i_622 * da_610))))) - 0.3))), Add(Add(b0_599, ((V)((j_620 * db_611)))), ((V)(0.3)))), n_596, ((V)((da_610 * 0.5))), ((V)((db_611 * 0.42))), ((V)(0D)), ((V)(12D)));
}
i_622++;
}
}
j_620++;
}
}
Invoke(B_613, "forEach", Fn((V _arrowThis637, int _argc624, V _a626, V _a627, V _a628, V _a629, V[] _rest625) => {
V q_632 = default;
V i_634 = default;
V j_636 = default;
{ V _t630 = ListOf(_a626);
{ V _t631 = GetIdx(_t630, 0D);
q_632 = _t631; }
{ V _t633 = GetIdx(_t630, 1D);
i_634 = _t633; }
{ V _t635 = GetIdx(_t630, 2D);
j_636 = _t635; }
}
Call(spot_28, V.Undef, DM_605, Call(PT_595, V.Undef, GetIdx(q_632, 0D), GetIdx(q_632, 1D)), n_596, ((V)(2.5)), ((V)(2.1)), ((V)(0D)), ((V)(12D)));
Invoke(Arr(Arr(((V)(1D)), ((V)(1D))), Arr(((V)(1D)), ((V)((-1D))))), "forEach", Fn((V _arrowThis649, int _argc638, V _a640, V _a641, V _a642, V _a643, V[] _rest639) => {
V t_650 = default;
V di_646 = default;
V dj_648 = default;
{ V _t644 = ListOf(_a640);
{ V _t645 = GetIdx(_t644, 0D);
di_646 = _t645; }
{ V _t647 = GetIdx(_t644, 1D);
dj_648 = _t647; }
}
t_650 = Invoke(G_612, "get", ((V)(JsStrBuf.Begin().V(Add(i_634, di_646)).S(",").V(Add(j_636, dj_648)).End())));
if (!(Truthy(t_650))) {
return default;
}
Invoke(DK_604, "line", Arr(Call(PT_595, V.Undef, GetIdx(q_632, 0D), GetIdx(q_632, 1D)), Call(PT_595, V.Undef, GetIdx(t_650, 0D), GetIdx(t_650, 1D))), n_596, ((V)(0.42)));
Invoke(HL_606, "line", Arr(Call(PT_595, V.Undef, Add(GetIdx(q_632, 0D), ((V)(0.45))), Add(GetIdx(q_632, 1D), ((V)(0.4)))), Call(PT_595, V.Undef, Add(GetIdx(t_650, 0D), ((V)(0.45))), Add(GetIdx(t_650, 1D), ((V)(0.4))))), n_596, ((V)(0.3)));
return default;
}, 1, "", true));
if ((!pleat_602.IsNullish && SEqN(j_636, 0D))) {
Invoke(DK_604, "line", Arr(Call(PT_595, V.Undef, GetIdx(q_632, 0D), GetIdx(q_632, 1D)), Call(PT_595, V.Undef, GetIdx(q_632, 0D), pleat_602)), n_596, ((V)(0.36)));
Invoke(HL_606, "line", Arr(Call(PT_595, V.Undef, Add(GetIdx(q_632, 0D), ((V)(0.5))), GetIdx(q_632, 1D)), Call(PT_595, V.Undef, Add(GetIdx(q_632, 0D), ((V)(0.5))), pleat_602)), n_596, ((V)(0.25)));
}
return default;
}, 1, "", true));
Call(on_593, V.Undef, host_594, Arr(HL2_607, HL_606, DM_605, DK_604));
Call(on_593, V.Undef, host_594, Invoke(B_613, "map", Fn((V _arrowThis660, int _argc651, V _a653, V _a654, V _a655, V _a656, V[] _rest652) => {
V q_659 = default;
{ V _t657 = ListOf(_a653);
{ V _t658 = GetIdx(_t657, 0D);
q_659 = _t658; }
}
return Call(btn_72, V.Undef, Call(add_53, V.Undef, Call(PT_595, V.Undef, GetIdx(q_659, 0D), GetIdx(q_659, 1D)), Call(mul_55, V.Undef, n_596, ((V)(0.2)))), n_596, Call(shade_18, V.Undef, F0_601, ((V)(0.42))), ((V)(1.25)));
}, 1, "", true)), n_596);
BH_614 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, F0_601, ((V)("#ffffff")), ((V)(0.5))), NewObj(1).Put("op", ((V)(0.8))).V);
Invoke(B_613, "forEach", Fn((V _arrowThis670, int _argc661, V _a663, V _a664, V _a665, V _a666, V[] _rest662) => {
V q_669 = default;
{ V _t667 = ListOf(_a663);
{ V _t668 = GetIdx(_t667, 0D);
q_669 = _t668; }
}
return Call(spot_28, V.Undef, BH_614, Call(add_53, V.Undef, Call(PT_595, V.Undef, ((V)((ToNum(GetIdx(q_669, 0D)) - 0.35))), Add(GetIdx(q_669, 1D), ((V)(0.35)))), Call(mul_55, V.Undef, n_596, ((V)(0.78)))), n_596, ((V)(0.4)), ((V)(0.3)), ((V)(0D)), ((V)(6D)));
}, 1, "", true));
Call(on_593, V.Undef, host_594, Arr(BH_614));
return default;
}, 10, "", true);
Set(N_21, "chester26V", Fn((V _arrowThis678, int _argc671, V S_677, V _a674, V _a675, V _a676, V[] _rest672) => {
V B_679 = default;
V g_680 = default;
V D_681 = default;
B_679 = Invoke(N_21, "chester25V2", S_677);
g_680 = Get(Invoke(N_21, "chester", S_677), "geo26");
D_681 = Object_assign(NewObj(0).V, B_679);
Set(D_681, "layers", Invoke(Get(B_679, "layers"), "map", Fn((V _arrowThis690, int _argc682, V L_688, V i_689, V _a686, V _a687, V[] _rest683) => {
return Object_assign(NewObj(0).V, L_688, NewObj(2).Put("wrap", Fn((V _arrowThis699, int _argc691, V p_697, V s_698, V _a695, V _a696, V[] _rest692) => {
return s_698;
}, 2, "wrap", true)).Put("build", Fn((V _arrowThis707, int _argc700, V P_706, V _a703, V _a704, V _a705, V[] _rest701) => {
V o_708 = default;
V on_709 = default;
V F0_710 = default;
V rs_711 = default;
o_708 = Invoke(L_688, "build", P_706);
on_709 = Call(glue_33, V.Undef, o_708);
F0_710 = ((Get(P_706, "c") is var _t712 && !Truthy(_t712) ? _t712 : Get(Get(P_706, "c"), "a")) is var _t713 && Truthy(_t713) ? _t713 : Get(P_706, "a"));
rs_711 = Invoke(Call(roots_71, V.Undef, o_708), "map", Fn((V _arrowThis721, int _argc714, V S0_720, V _a717, V _a718, V _a719, V[] _rest715) => {
return NewObj(2).Put("S", S0_720).Put("L", Call(bbS_52, V.Undef, S0_720)).V;
}, 1, "", true));
if (SEqN(i_689, 0D)) {
V bk_722 = default;
bk_722 = Invoke(rs_711, "find", Fn((V _arrowThis730, int _argc723, V b_729, V _a726, V _a727, V _a728, V[] _rest724) => {
return ((SEq(Get(Get(b_729, "S"), "col"), F0_710) && ((ToNum(GetIdx(Get(b_729, "L"), 3D)) - ToNum(GetIdx(Get(b_729, "L"), 2D))) > 20D)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(bk_722)) {
Call(tuftGrid_73, V.Undef, on_709, Get(bk_722, "S"), Call(plane_66, V.Undef, Arr(((V)(0D)), ((V)(0D)), Add(Get(g_680, "BZ1"), ((V)(0.05)))), X3_58, Y3_59), Z3_60, Add(Get(g_680, "xl"), ((V)(3.5))), ((V)((ToNum(Get(g_680, "xr")) - 3.5))), Add(Get(g_680, "ST"), ((V)(4D))), ((V)((ToNum(Get(g_680, "TOP")) - 9.5))), F0_710, Add(Get(g_680, "ST"), ((V)(1D))));
}
}
if ((SEqN(i_689, 1D) || SEqN(i_689, 3D))) {
double sg_731 = 0;
V ab_732 = default;
sg_731 = (SEqN(i_689, 1D) ? (-1D) : 1D);
ab_732 = Invoke(rs_711, "find", Fn((V _arrowThis740, int _argc733, V b_739, V _a736, V _a737, V _a738, V[] _rest734) => {
return (((SEq(Get(Get(b_739, "S"), "col"), F0_710) && LtN(GetIdx(Get(b_739, "L"), 2D), 30D)) && ((ToNum(GetIdx(Get(b_739, "L"), 1D)) - ToNum(GetIdx(Get(b_739, "L"), 0D))) < 30D)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(ab_732)) {
V x_741 = default;
x_741 = ((sg_731 < 0D) ? Add(GetIdx(Get(ab_732, "L"), 1D), ((V)(0.05))) : ((V)((ToNum(GetIdx(Get(ab_732, "L"), 0D)) - 0.05))));
Call(tuftGrid_73, V.Undef, on_709, Get(ab_732, "S"), Call(plane_66, V.Undef, Arr(x_741, ((V)(0D)), ((V)(0D))), Z3_60, Y3_59), Arr(((V)((-sg_731))), ((V)(0D)), ((V)(0D))), Add(Get(g_680, "BZ1"), ((V)(3.5))), ((V)((ToNum(Get(g_680, "ZF")) - 5D))), Add(Get(g_680, "CT"), ((V)(2.5))), ((V)(((ToNum(Get(g_680, "rollY")) - ToNum(Get(g_680, "rB"))) - 1.2))), F0_710, V.Null);
}
}
return o_708;
return default;
}, 1, "build", true)).V);
}, 2, "", true)));
Set(D_681, "build", Fn((V _arrowThis749, int _argc742, V P_748, V _a745, V _a746, V _a747, V[] _rest743) => {
V o_750 = default;
o_750 = Invoke(B_679, "build", P_748);
Invoke(o_750, "forEach", Fn((V _arrowThis758, int _argc751, V S0_757, V _a754, V _a755, V _a756, V[] _rest752) => {
if (SEqS(Get(S0_757, "col"), "#1d140c")) {
Set(S0_757, "col", ((V)("#c9a24a")));
Set(S0_757, "mat", ((V)("metal")));
Set(S0_757, "shine", ((V)(1D)));
}
return default;
}, 1, "", true));
return o_750;
return default;
}, 1, "", true));
return D_681;
return default;
}, 1, "", true));
Set(N_21, "papasan26", Fn((V _arrowThis766, int _argc759, V S_765, V _a762, V _a763, V _a764, V[] _rest760) => {
return NewObj(6).Put("w", ((V)(88D))).Put("d", ((V)(88D))).Put("round", ((V)(1D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(6D))).Put("h", ((V)(40D))).V)).Put("build", Fn((V _arrowThis774, int _argc767, V P_773, V _a770, V _a771, V _a772, V[] _rest768) => {
V V_775 = default;
V RT_776 = default;
V BK_777 = default;
V BRs_778 = default;
V o_779 = default;
V on_780 = default;
V R_781 = default;
double TL_782 = 0;
V PV_783 = default;
V T_784 = default;
V BW_785 = default;
V OUT_786 = default;
V W1_787 = default;
V W2_788 = default;
V BD_789 = default;
V BDh_790 = default;
V prof_791 = default;
V CU_792 = default;
V cc_793 = default;
V sp_794 = default;
V RIM_795 = default;
V RB1_796 = default;
V RB2_797 = default;
V PLW_798 = default;
V D1_799 = default;
V D2_800 = default;
V PLT_801 = default;
V PLL_802 = default;
V BTN_803 = default;
V BTH_804 = default;
V WL_805 = default;
V WH_806 = default;
V SH_807 = default;
V E1_808 = default;
V E2_809 = default;
V PG_810 = default;
V CH_811 = default;
V TS_812 = default;
double ta_813 = 0;
double tx_814 = 0;
double tz_815 = 0;
V TA_816 = default;
V_775 = Get(P_773, "a");
RT_776 = ((V)("#c99a5a"));
BK_777 = ((V)("#2c2d31"));
BRs_778 = ((V)("#d9a84a"));
o_779 = Arr();
on_780 = Call(glue_33, V.Undef, o_779);
R_781 = Call(R0_34, V.Undef, ((V)("pp26")));
TL_782 = (-0.38);
PV_783 = Arr(((V)(0D)), ((V)(24D)), ((V)(2D)));
T_784 = Fn((V _arrowThis824, int _argc817, V S0_823, V _a820, V _a821, V _a822, V[] _rest818) => {
return Call(tilt_38, V.Undef, S0_823, X3_58, ((V)(TL_782)), PV_783);
}, 1, "", true);
Invoke(o_779, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(3D)), BK_777, NewObj(3).Put("n", ((V)(22D))).Put("mat", ((V)("metal"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(2D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.88))))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(8D)), ((V)(2.4)), BRs_778, NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(5.4)), ((V)(0D)), ((V)(3.4)), ((V)(9.6)), BK_777, NewObj(2).Put("n", ((V)(10D))).Put("mat", ((V)("metal"))).V), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(15D)), ((V)(2D)), ((V)(13D)), ((V)(4D)), BRs_778, NewObj(4).Put("n", ((V)(18D))).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(2D)), ((V)(0D)), ((V)(1D))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.92))))).V));
{
V BB_825 = default;
V ST_826 = default;
V HL_827 = default;
BB_825 = GetIdx(o_779, 0D);
ST_826 = Call(dec_27, V.Undef, ((V)("#5a5c62")), NewObj(1).Put("op", ((V)(0.6))).V);
HL_827 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.35))).V);
Invoke(Arr(((V)(8D)), ((V)(12D)), ((V)(16D)), ((V)(20D))), "forEach", Fn((V _arrowThis836, int _argc828, V r_834, V k_835, V _a832, V _a833, V[] _rest829) => {
return Call(ringY_32, V.Undef, (NumTruthy((ToNum(k_835) % 2D)) ? ST_826 : HL_827), ((V)(0D)), ((V)(0D)), r_834, ((V)(3.02)), ((V)(0.2)), ((V)(40D)));
}, 2, "", true));
Call(on_780, V.Undef, BB_825, Arr(ST_826, HL_827));
}
BW_785 = Call(cyl_14, V.Undef, ((V)(0D)), ((V)(23D)), ((V)(2D)), ((V)(38D)), ((V)(22D)), RT_776, NewObj(4).Put("n", ((V)(30D))).Put("rz", ((V)(34D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.32))), Arr(((V)(8D)), ((V)(0D)), ((V)(0.72))), Arr(((V)(16D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(22D)), ((V)(0D)), ((V)(1D))))).Put("mat", ((V)("wood"))).V);
Invoke(o_779, "push", BW_785);
OUT_786 = NewObj(6).Put("faces", Invoke(Invoke(Get(BW_785, "faces"), "filter", Fn((V _arrowThis860, int _argc853, V F_859, V _a856, V _a857, V _a858, V[] _rest854) => {
return (!(Truthy(Get(F_859, "cap"))) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis844, int _argc837, V F_843, V _a840, V _a841, V _a842, V[] _rest838) => {
return NewObj(2).Put("q", Invoke(Get(F_843, "q"), "map", Fn((V _arrowThis852, int _argc845, V p_851, V _a848, V _a849, V _a850, V[] _rest846) => {
return Invoke(p_851, "slice");
}, 1, "", true))).Put("n", Invoke(Get(F_843, "n"), "slice")).V;
}, 1, "", true))).Put("pts", Arr()).Put("col", RT_776).Put("cv", ((V)(0D))).Put("zb", ((V)(0D))).Put("mat", ((V)("wood"))).V;
Invoke(Get(OUT_786, "faces"), "forEach", Fn((V _arrowThis868, int _argc861, V F_867, V _a864, V _a865, V _a866, V[] _rest862) => {
return Invoke(Get(F_867, "q"), "forEach", Fn((V _arrowThis876, int _argc869, V p_875, V _a872, V _a873, V _a874, V[] _rest870) => {
return Invoke(Get(OUT_786, "pts"), "push", p_875);
}, 1, "", true));
}, 1, "", true));
W1_787 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, RT_776, ((V)(0.68))), NewObj(1).Put("op", ((V)(0.6))).V);
W2_788 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, RT_776, ((V)("#fff1d0")), ((V)(0.4))), NewObj(1).Put("op", ((V)(0.55))).V);
BD_789 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, RT_776, ((V)(0.6))), NewObj(1).Put("op", ((V)(0.8))).V);
BDh_790 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, RT_776, ((V)("#fff1d0")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Get(OUT_786, "faces"), "forEach", Fn((V _arrowThis884, int _argc877, V F_883, V _a880, V _a881, V _a882, V[] _rest878) => {
if (!((System.Math.Abs(ToNum(Invoke(Get(Call(fr2_45, V.Undef, F_883), "P"), "reduce", Fn((V _arrowThis895, int _argc885, V s_891, V p_892, V i_893, V A_894, V[] _rest886) => {
return ((V)((ToNum(Add(s_891, ((V)((ToNum(GetIdx(p_892, 0D)) * ToNum(GetIdx(GetIdx(A_894, (ToNum(Add(i_893, ((V)(1D)))) % ToNum(Get(A_894, "length")))), 1D))))))) - (ToNum(GetIdx(GetIdx(A_894, (ToNum(Add(i_893, ((V)(1D)))) % ToNum(Get(A_894, "length")))), 0D)) * ToNum(GetIdx(p_892, 1D))))));
}, 4, "", true), ((V)(0D))))) > 4D))) {
return default;
}
Call(hatch_46, V.Undef, W1_787, F_883, ((V)((PI_22 / 4D))), ((V)(1.7)), ((V)(0.55)), NewObj(1).Put("sh", ((V)(0.98))).V);
Call(hatch_46, V.Undef, W2_788, F_883, ((V)(((-PI_22) / 4D))), ((V)(1.7)), ((V)(0.5)), NewObj(2).Put("sh", ((V)(0.98))).Put("ph", ((V)(0.85))).V);
return default;
}, 1, "", true));
prof_791 = Fn((V _arrowThis903, int _argc896, V y_902, V _a899, V _a900, V _a901, V[] _rest897) => {
double t_904 = 0;
t_904 = ((ToNum(y_902) - 23D) / 22D);
return ((V)(((t_904 < 0.36) ? (0.32 + ((0.4 * t_904) / 0.36)) : ((t_904 < 0.73) ? (0.72 + ((0.22 * (t_904 - 0.36)) / 0.37)) : (0.94 + ((0.06 * (t_904 - 0.73)) / 0.27))))));
return default;
}, 1, "", true);
Invoke(Arr(((V)(27.5)), ((V)(31.5)), ((V)(36D)), ((V)(40.5))), "forEach", Fn((V _arrowThis912, int _argc905, V y_911, V _a908, V _a909, V _a910, V[] _rest906) => {
double k_913 = 0;
V Q_914 = default;
V Nn_915 = default;
k_913 = (ToNum(Call(prof_791, V.Undef, y_911)) * 1.014);
Q_914 = Call(rep_35, V.Undef, ((V)(61D)), Fn((V _arrowThis923, int _argc916, V i_922, V _a919, V _a920, V _a921, V[] _rest917) => {
double a_924 = 0;
a_924 = (((ToNum(i_922) / 60D) * 2D) * PI_22);
return Arr(((V)(((FdLibm.Cos(a_924) * 38D) * k_913))), y_911, ((V)((2D + ((FdLibm.Sin(a_924) * 34D) * k_913)))));
return default;
}, 1, "", true));
Nn_915 = Call(rep_35, V.Undef, ((V)(61D)), Fn((V _arrowThis932, int _argc925, V i_931, V _a928, V _a929, V _a930, V[] _rest926) => {
return Call(nz_57, V.Undef, Arr(((V)(FdLibm.Cos((((ToNum(i_931) / 60D) * 2D) * PI_22)))), ((V)((-0.3))), ((V)(FdLibm.Sin((((ToNum(i_931) / 60D) * 2D) * PI_22))))));
}, 1, "", true));
Invoke(BD_789, "line", Q_914, Nn_915, ((V)(1.1)));
Invoke(BDh_790, "line", Invoke(Q_914, "map", Fn((V _arrowThis940, int _argc933, V q_939, V _a936, V _a937, V _a938, V[] _rest934) => {
return Arr(GetIdx(q_939, 0D), Add(GetIdx(q_939, 1D), ((V)(0.45))), GetIdx(q_939, 2D));
}, 1, "", true)), Nn_915, ((V)(0.3)));
return default;
}, 1, "", true));
CU_792 = Call(ball_12, V.Undef, ((V)(0D)), ((V)(37.4)), ((V)(3D)), ((V)(38.6)), V_775, NewObj(7).Put("sy", ((V)(0.2))).Put("sz", ((V)(0.88))).Put("k", ((V)(6D))).Put("n", ((V)(28D))).Put("soft", ((V)(1D))).Put("shine", ((V)(0D))).Put("mat", ((V)("fab"))).V);
cc_793 = Arr(((V)(0D)), ((V)((37.4 + 7.72))), ((V)(3D)));
sp_794 = Fn((V _arrowThis950, int _argc941, V x_947, V z_948, V k_949, V _a946, V[] _rest942) => {
double e_951 = 0;
V y_952 = default;
V n_953 = default;
e_951 = ((1D - Pow((ToNum(x_947) / 38.6), 2D)) - Pow(((ToNum(z_948) - 3D) / 33.97), 2D));
y_952 = Add(GetIdx(cc_793, 1D), ((V)((7.72 * System.Math.Sqrt(Max(0D, e_951))))));
n_953 = Call(nz_57, V.Undef, Arr(((V)(((ToNum(x_947) / 38.6) / 38.6))), ((V)((((ToNum(y_952) - ToNum(GetIdx(cc_793, 1D))) / 7.72) / 7.72))), ((V)((((ToNum(z_948) - 3D) / 33.97) / 33.97)))));
return Arr(Call(add_53, V.Undef, Arr(x_947, y_952, z_948), Call(mul_55, V.Undef, n_953, (k_949 is var _t954 && Truthy(_t954) ? _t954 : ((V)(0.1))))), n_953);
return default;
}, 3, "", true);
RIM_795 = Call(arcW_15, V.Undef, ((V)(0D)), ((V)(43.4)), ((V)(2D)), ((V)(39.4)), ((V)(35.4)), ((V)(2.8)), ((V)(2.8)), ((V)(0D)), ((V)((2D * PI_22))), Call(shade_18, V.Undef, RT_776, ((V)(0.84))), NewObj(2).Put("n", ((V)(36D))).Put("mat", ((V)("wood"))).V);
RB1_796 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, RT_776, ((V)(0.55))), NewObj(1).Put("op", ((V)(0.75))).V);
RB2_797 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, RT_776, ((V)("#fff1d0")), ((V)(0.35))), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Get(RIM_795, "faces"), "forEach", Fn((V _arrowThis962, int _argc955, V F_961, V _a958, V _a959, V _a960, V[] _rest956) => {
if ((System.Math.Abs(ToNum(Invoke(Get(Call(fr2_45, V.Undef, F_961), "P"), "reduce", Fn((V _arrowThis973, int _argc963, V s_969, V p_970, V i_971, V A_972, V[] _rest964) => {
return ((V)((ToNum(Add(s_969, ((V)((ToNum(GetIdx(p_970, 0D)) * ToNum(GetIdx(GetIdx(A_972, (ToNum(Add(i_971, ((V)(1D)))) % ToNum(Get(A_972, "length")))), 1D))))))) - (ToNum(GetIdx(GetIdx(A_972, (ToNum(Add(i_971, ((V)(1D)))) % ToNum(Get(A_972, "length")))), 0D)) * ToNum(GetIdx(p_970, 1D))))));
}, 4, "", true), ((V)(0D))))) > 0.6)) {
Call(hatch_46, V.Undef, RB1_796, F_961, ((V)((PI_22 / 2.5))), ((V)(0.9)), ((V)(0.24)), NewObj(1).Put("sh", ((V)(0.99))).V);
Call(hatch_46, V.Undef, RB2_797, F_961, ((V)((PI_22 / 2.5))), ((V)(0.9)), ((V)(0.12)), NewObj(2).Put("sh", ((V)(0.99))).Put("ph", ((V)(0.45))).V);
}
return default;
}, 1, "", true));
PLW_798 = Call(pillowZ_17, V.Undef, ((V)(0D)), ((V)(49D)), ((V)((-21D))), ((V)(36D)), ((V)(13D)), ((V)(9D)), Call(shade_18, V.Undef, V_775, ((V)(1.08))), NewObj(2).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V);
D1_799 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, V_775, ((V)("#ffffff")), ((V)(0.24))), NewObj(1).Put("op", ((V)(0.22))).V);
D2_800 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, V_775, ((V)(0.84))), NewObj(1).Put("op", ((V)(0.2))).V);
PLT_801 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, V_775, ((V)(0.62))), NewObj(1).Put("op", ((V)(0.6))).V);
PLL_802 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, V_775, ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.38))).V);
BTN_803 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, V_775, ((V)(0.45))));
BTH_804 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, V_775, ((V)("#ffffff")), ((V)(0.45))), NewObj(1).Put("op", ((V)(0.7))).V);
WL_805 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, V_775, ((V)(0.62))), NewObj(1).Put("op", ((V)(0.85))).V);
WH_806 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, V_775, ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("op", ((V)(0.5))).V);
SH_807 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.16))).V);
Invoke(Get(CU_792, "faces"), "forEach", Fn((V _arrowThis981, int _argc974, V F_980, V _a977, V _a978, V _a979, V[] _rest975) => {
if ((GtN(GetIdx(Get(F_980, "n"), 1D), 0.4) && (System.Math.Abs(ToNum(Invoke(Get(Call(fr2_45, V.Undef, F_980), "P"), "reduce", Fn((V _arrowThis992, int _argc982, V s_988, V p_989, V i_990, V A_991, V[] _rest983) => {
return ((V)((ToNum(Add(s_988, ((V)((ToNum(GetIdx(p_989, 0D)) * ToNum(GetIdx(GetIdx(A_991, (ToNum(Add(i_990, ((V)(1D)))) % ToNum(Get(A_991, "length")))), 1D))))))) - (ToNum(GetIdx(GetIdx(A_991, (ToNum(Add(i_990, ((V)(1D)))) % ToNum(Get(A_991, "length")))), 0D)) * ToNum(GetIdx(p_989, 1D))))));
}, 4, "", true), ((V)(0D))))) > 40D))) {
Call(nap_68, V.Undef, D1_799, D2_800, F_980, R_781, ((V)(1D)));
}
return default;
}, 1, "", true));
Call(rep_35, V.Undef, ((V)(10D)), Fn((V _arrowThis1000, int _argc993, V i_999, V _a996, V _a997, V _a998, V[] _rest994) => {
double a_1001 = 0;
double ex_1002 = 0;
double ez_1003 = 0;
double bx_1004 = 0;
double bz_1005 = 0;
V q_1006 = default;
V q2_1007 = default;
a_1001 = ((((ToNum(i_999) / 10D) * 2D) * PI_22) + 0.15);
ex_1002 = (FdLibm.Cos(a_1001) * 33D);
ez_1003 = (3D + (FdLibm.Sin(a_1001) * 29D));
Call(lineOn_65, V.Undef, PLT_801, Fn((V _arrowThis1015, int _argc1008, V t_1014, V _a1011, V _a1012, V _a1013, V[] _rest1009) => {
return Call(sp_794, V.Undef, ((V)((ex_1002 * ToNum(t_1014)))), ((V)((3D + ((ez_1003 - 3D) * ToNum(t_1014))))));
}, 1, "", true), ((V)(12D)), ((V)(0.55)), ((V)(1D)));
Call(lineOn_65, V.Undef, PLL_802, Fn((V _arrowThis1023, int _argc1016, V t_1022, V _a1019, V _a1020, V _a1021, V[] _rest1017) => {
return Call(sp_794, V.Undef, ((V)(((ex_1002 * ToNum(t_1022)) + 0.9))), ((V)(((3D + ((ez_1003 - 3D) * ToNum(t_1022))) + 0.6))));
}, 1, "", true), ((V)(12D)), ((V)(0.3)), ((V)(1D)));
bx_1004 = (FdLibm.Cos((a_1001 + (PI_22 / 10D))) * 18D);
bz_1005 = (3D + (FdLibm.Sin((a_1001 + (PI_22 / 10D))) * 15.8));
q_1006 = Call(sp_794, V.Undef, ((V)(bx_1004)), ((V)(bz_1005)), ((V)(0.15)));
Call(spot_28, V.Undef, BTN_803, GetIdx(q_1006, 0D), GetIdx(q_1006, 1D), ((V)(1.2)), ((V)(1.2)), ((V)(0D)), ((V)(8D)));
Call(spot_28, V.Undef, BTH_804, Call(add_53, V.Undef, GetIdx(q_1006, 0D), Arr(((V)((-0.3))), ((V)(0.06)), ((V)((-0.3))))), GetIdx(q_1006, 1D), ((V)(0.45)), ((V)(0.38)), ((V)(0D)), ((V)(6D)));
q2_1007 = Call(sp_794, V.Undef, ((V)((FdLibm.Cos((a_1001 + (PI_22 / 10D))) * 9D))), ((V)((3D + (FdLibm.Sin((a_1001 + (PI_22 / 10D))) * 7.9)))), ((V)(0.12)));
Call(spot_28, V.Undef, SH_807, GetIdx(q2_1007, 0D), GetIdx(q2_1007, 1D), ((V)(3.4)), ((V)(2.4)), ((V)(a_1001)), ((V)(10D)));
return default;
}, 1, "", true));
{
V q_1024 = default;
q_1024 = Call(sp_794, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0.15)));
Call(spot_28, V.Undef, BTN_803, GetIdx(q_1024, 0D), GetIdx(q_1024, 1D), ((V)(1.8)), ((V)(1.8)), ((V)(0D)), ((V)(10D)));
Call(spot_28, V.Undef, BTH_804, Call(add_53, V.Undef, GetIdx(q_1024, 0D), Arr(((V)((-0.4))), ((V)(0.06)), ((V)((-0.4))))), GetIdx(q_1024, 1D), ((V)(0.6)), ((V)(0.5)), ((V)(0D)), ((V)(6D)));
}
{
V Q_1025 = default;
Q_1025 = Call(rep_35, V.Undef, ((V)(73D)), Fn((V _arrowThis1033, int _argc1026, V i_1032, V _a1029, V _a1030, V _a1031, V[] _rest1027) => {
double a_1034 = 0;
a_1034 = (((ToNum(i_1032) / 72D) * 2D) * PI_22);
return Arr(Arr(((V)((FdLibm.Cos(a_1034) * 38.8))), Add(GetIdx(cc_793, 1D), ((V)(0.3))), ((V)((3D + (FdLibm.Sin(a_1034) * 34.15))))), Call(nz_57, V.Undef, Arr(((V)(FdLibm.Cos(a_1034))), ((V)(0.25)), ((V)(FdLibm.Sin(a_1034))))));
return default;
}, 1, "", true));
Invoke(WL_805, "line", Invoke(Q_1025, "map", Fn((V _arrowThis1042, int _argc1035, V q_1041, V _a1038, V _a1039, V _a1040, V[] _rest1036) => {
return GetIdx(q_1041, 0D);
}, 1, "", true)), Invoke(Q_1025, "map", Fn((V _arrowThis1050, int _argc1043, V q_1049, V _a1046, V _a1047, V _a1048, V[] _rest1044) => {
return GetIdx(q_1049, 1D);
}, 1, "", true)), ((V)(1.1)));
Invoke(WH_806, "line", Invoke(Q_1025, "map", Fn((V _arrowThis1058, int _argc1051, V q_1057, V _a1054, V _a1055, V _a1056, V[] _rest1052) => {
return Call(add_53, V.Undef, GetIdx(q_1057, 0D), Arr(((V)(0D)), ((V)(0.5)), ((V)(0D))));
}, 1, "", true)), Invoke(Q_1025, "map", Fn((V _arrowThis1066, int _argc1059, V q_1065, V _a1062, V _a1063, V _a1064, V[] _rest1060) => {
return GetIdx(q_1065, 1D);
}, 1, "", true)), ((V)(0.3)));
}
E1_808 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, V_775, ((V)("#ffffff")), ((V)(0.25))), NewObj(1).Put("op", ((V)(0.22))).V);
E2_809 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, V_775, ((V)(0.84))), NewObj(1).Put("op", ((V)(0.18))).V);
PG_810 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, V_775, ((V)(0.6))), NewObj(1).Put("op", ((V)(0.85))).V);
CH_811 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, V_775, ((V)(0.78))), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Get(PLW_798, "faces"), "forEach", Fn((V _arrowThis1074, int _argc1067, V F_1073, V _a1070, V _a1071, V _a1072, V[] _rest1068) => {
if (Truthy(Get(F_1073, "cap"))) {
V G_1075 = default;
Call(nap_68, V.Undef, E1_808, E2_809, F_1073, R_781, ((V)(2D)));
Call(outline_48, V.Undef, PG_810, F_1073, ((V)(0.93)), ((V)(0.6)));
G_1075 = Call(fr2_45, V.Undef, F_1073);
Invoke(Arr(((V)((-9D))), ((V)((-3D))), ((V)(3D)), ((V)(9D))), "forEach", Fn((V _arrowThis1083, int _argc1076, V a_1082, V _a1079, V _a1080, V _a1081, V[] _rest1077) => {
return Invoke(CH_811, "line", Arr(Invoke(G_1075, "at", a_1082, ((V)((-5.5)))), Invoke(G_1075, "at", a_1082, ((V)(5.5)))), Get(G_1075, "n"), ((V)(0.45)), ((V)(1D)));
}, 1, "", true));
}
return default;
}, 1, "", true));
TS_812 = ((V)("#e0b34a"));
ta_813 = (PI_22 * 0.74);
tx_814 = (FdLibm.Cos(ta_813) * 39.9);
tz_815 = (2D + (FdLibm.Sin(ta_813) * 35.9));
TA_816 = Arr(Call(ball_12, V.Undef, ((V)(tx_814)), ((V)(42.9)), ((V)(tz_815)), ((V)(1.3)), TS_812, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("mat", ((V)("fab"))).V), Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("y"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(tx_814)), ((V)(tz_815)))).Put("a", ((V)(0.6))).Put("b", ((V)(0.6))).Put("n", ((V)(6D))).Put("rings", Arr(Arr(((V)(36.6)), ((V)(0D)), ((V)(1.8))), Arr(((V)(40.8)), ((V)(0D)), ((V)(0.9))), Arr(((V)(43D)), ((V)(0D)), ((V)(0.5))))).Put("col", Call(shade_18, V.Undef, TS_812, ((V)(0.9)))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V));
Invoke(Invoke(Arr(OUT_786, W1_787, W2_788, BD_789, BDh_790, CU_792, D1_799, D2_800, PLT_801, PLL_802, SH_807, BTN_803, BTH_804, WL_805, WH_806, RIM_795, RB1_796, RB2_797, PLW_798, E1_808, E2_809, PG_810, CH_811), "concat", TA_816), "forEach", T_784);
Call(T_784, V.Undef, BW_785);
Call(on_780, V.Undef, BW_785, Arr(CU_792));
Call(on_780, V.Undef, CU_792, Arr(D1_799, D2_800, SH_807, PLT_801, PLL_802, BTN_803, BTH_804, WL_805, WH_806));
Call(on_780, V.Undef, BW_785, Arr(OUT_786));
Call(on_780, V.Undef, OUT_786, Arr(W1_787, W2_788, BD_789, BDh_790));
Call(on_780, V.Undef, BW_785, Arr(RIM_795));
Call(on_780, V.Undef, RIM_795, Invoke(Arr(RB1_796, RB2_797), "concat", TA_816));
Call(on_780, V.Undef, BW_785, Arr(PLW_798));
Call(on_780, V.Undef, PLW_798, Arr(E1_808, E2_809, PG_810, CH_811));
return o_779;
return default;
}, 1, "build", true)).V;
}, 1, "", true));
Set(N_21, "alab26", Fn((V _arrowThis1091, int _argc1084, V S_1090, V _a1087, V _a1088, V _a1089, V[] _rest1085) => {
V BRZ_1092 = default;
V AL_1093 = default;
V lay_1094 = default;
BRZ_1092 = ((V)("#6e4a2c"));
AL_1093 = Arr(((V)("#f6dfba")), ((V)("#fbe9cc")), ((V)("#f3d4a6")), ((V)("#fcecd2")), ((V)("#f7e0bc")), ((V)("#fbe6c4")));
lay_1094 = Fn((V _arrowThis1101, int _argc1095, V _a1097, V _a1098, V _a1099, V _a1100, V[] _rest1096) => {
V y_1102 = default;
V Lr_1103 = default;
y_1102 = ((V)(5.6));
Lr_1103 = Arr();
Invoke(Arr(Arr(((V)("blk")), ((V)(17D)), ((V)(0D))), Arr(((V)("disc")), ((V)(7D)), ((V)(1D))), Arr(((V)("ball")), ((V)(18D)), ((V)(2D))), Arr(((V)("drum")), ((V)(22D)), ((V)(3D))), Arr(((V)("peb")), ((V)(8.4)), ((V)(4D))), Arr(((V)("bowl")), ((V)(12D)), ((V)(5D)))), "forEach", Fn((V _arrowThis1117, int _argc1104, V _a1106, V _a1107, V _a1108, V _a1109, V[] _rest1105) => {
V k_1112 = default;
V h_1114 = default;
V i_1116 = default;
{ V _t1110 = ListOf(_a1106);
{ V _t1111 = GetIdx(_t1110, 0D);
k_1112 = _t1111; }
{ V _t1113 = GetIdx(_t1110, 1D);
h_1114 = _t1113; }
{ V _t1115 = GetIdx(_t1110, 2D);
i_1116 = _t1115; }
}
Invoke(Lr_1103, "push", NewObj(4).Put("k", k_1112).Put("h", h_1114).Put("i", i_1116).Put("y", y_1102).V);
y_1102 = Add(y_1102, Add(h_1114, ((V)((LtN(i_1116, 5D) ? 2.4 : 0D)))));
return default;
}, 1, "", true));
return Lr_1103;
return default;
}, 0, "", true);
return NewObj(6).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis1124, int _argc1118, V _a1120, V _a1121, V _a1122, V _a1123, V[] _rest1119) => {
return NewObj(2).Put("y", ((V)(112D))).Put("r", ((V)(80D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1131, int _argc1125, V _a1127, V _a1128, V _a1129, V _a1130, V[] _rest1126) => {
V o_1132 = default;
V on_1133 = default;
V R_1134 = default;
V PB_1135 = default;
V PB2_1136 = default;
V Lr_1137 = default;
V parts_1138 = default;
o_1132 = Arr();
on_1133 = Call(glue_33, V.Undef, o_1132);
R_1134 = Call(R0_34, V.Undef, ((V)("alab26")));
PB_1135 = Call(box_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(26D)), ((V)(3.2)), ((V)(26D)), BRZ_1092, Call(M__39, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("bev", ((V)(0.8))).V));
PB2_1136 = Call(box_13, V.Undef, ((V)(0D)), ((V)(3.2)), ((V)(0D)), ((V)(18D)), ((V)(2.4)), ((V)(18D)), Call(shade_18, V.Undef, BRZ_1092, ((V)(1.1))), Call(M__39, V.Undef, NewObj(1).Put("r", ((V)(2D))).V));
Invoke(o_1132, "push", PB_1135, PB2_1136);
{
V PT_1139 = default;
V BRh_1140 = default;
V CD_1141 = default;
V DM_1142 = default;
V DK_1143 = default;
PT_1139 = Call(dec_27, V.Undef, ((V)("#5f8a72")), NewObj(1).Put("op", ((V)(0.3))).V);
BRh_1140 = Call(dec_27, V.Undef, ((V)("#c9925a")), NewObj(1).Put("op", ((V)(0.45))).V);
CD_1141 = Call(dec_27, V.Undef, ((V)("#2a2a2e")));
DM_1142 = Call(dec_27, V.Undef, ((V)("#f4f2ee")));
DK_1143 = Call(dec_27, V.Undef, ((V)("#9aa1a6")));
Invoke(Call(caps_50, V.Undef, PB_1135, ((V)(2D))), "forEach", Fn((V _arrowThis1151, int _argc1144, V F_1150, V _a1147, V _a1148, V _a1149, V[] _rest1145) => {
Call(fleck_69, V.Undef, PT_1139, PT_1139, F_1150, R_1134, ((V)(30D)), ((V)(0.5)));
Call(outline_48, V.Undef, BRh_1140, F_1150, ((V)(0.94)), ((V)(0.3)));
return default;
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, PB_1135, ((V)(1D))), "forEach", Fn((V _arrowThis1159, int _argc1152, V F_1158, V _a1155, V _a1156, V _a1157, V[] _rest1153) => {
if ((System.Math.Abs(ToNum(GetIdx(Get(F_1158, "n"), 1D))) < 0.3)) {
Call(hatch_46, V.Undef, BRh_1140, F_1158, ((V)(0D)), ((V)(0.8)), ((V)(0.1)), NewObj(1).Put("sh", ((V)(0.97))).V);
}
return default;
}, 1, "", true));
Invoke(CD_1141, "line", Arr(Arr(((V)(13.1)), ((V)(0.6)), ((V)(6D))), Arr(((V)(18D)), ((V)(0.4)), ((V)(9D))), Arr(((V)(24D)), ((V)(0.4)), ((V)(16D)))), Y3_59, ((V)(0.6)));
Invoke(DM_1142, "poly", Arr(Arr(((V)(17.6)), ((V)(0.5)), ((V)(8D))), Arr(((V)(20.4)), ((V)(0.5)), ((V)(8D))), Arr(((V)(20.4)), ((V)(0.5)), ((V)(10.6))), Arr(((V)(17.6)), ((V)(0.5)), ((V)(10.6)))), Y3_59);
Call(spot_28, V.Undef, DK_1143, Arr(((V)(19D)), ((V)(0.56)), ((V)(9.3))), Y3_59, ((V)(0.7)), ((V)(0.7)), ((V)(0D)), ((V)(8D)));
Call(on_1133, V.Undef, PB_1135, Arr(PT_1139, BRh_1140, CD_1141, DM_1142, DK_1143));
}
Lr_1137 = Call(lay_1094, V.Undef);
parts_1138 = Arr();
Invoke(Lr_1137, "forEach", Fn((V _arrowThis1167, int _argc1160, V s_1166, V _a1163, V _a1164, V _a1165, V[] _rest1161) => {
V c_1168 = default;
V y_1169 = default;
V P0_1170 = default;
c_1168 = GetK(AL_1093, Get(s_1166, "i"));
y_1169 = Get(s_1166, "y");
P0_1170 = V.Undef;
if (SEqS(Get(s_1166, "k"), "blk")) {
P0_1170 = Call(box_13, V.Undef, ((V)(0.6)), y_1169, ((V)(0D)), ((V)(19D)), Get(s_1166, "h"), ((V)(15D)), c_1168, NewObj(4).Put("r", ((V)(3.2))).Put("bev", ((V)(1.6))).Put("yaw", ((V)(0.22))).Put("mat", ((V)("cer"))).V);
} else {
if (SEqS(Get(s_1166, "k"), "disc")) {
P0_1170 = Call(cyl_14, V.Undef, ((V)((-0.4))), y_1169, ((V)(0D)), ((V)(11.6)), Get(s_1166, "h"), c_1168, NewObj(3).Put("n", ((V)(26D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.86))), Arr(((V)(1.4)), ((V)(0D)), ((V)(0.98))), Arr(((V)((ToNum(Get(s_1166, "h")) - 1.4))), ((V)(0D)), ((V)(1D))), Arr(Get(s_1166, "h"), ((V)(0D)), ((V)(0.88))))).V);
} else {
if (SEqS(Get(s_1166, "k"), "ball")) {
P0_1170 = Call(ball_12, V.Undef, ((V)(0.8)), y_1169, ((V)(0D)), ((V)(9D)), c_1168, NewObj(4).Put("k", ((V)(8D))).Put("n", ((V)(22D))).Put("mat", ((V)("cer"))).Put("shine", ((V)(0D))).V);
} else {
if (SEqS(Get(s_1166, "k"), "drum")) {
P0_1170 = Call(cyl_14, V.Undef, ((V)(0D)), y_1169, ((V)(0D)), ((V)(6.8)), Get(s_1166, "h"), c_1168, NewObj(4).Put("n", ((V)(8D))).Put("mat", ((V)("cer"))).Put("yaw", ((V)(0.2))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(1.2)), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(Get(s_1166, "h")) - 1.2))), ((V)(0D)), ((V)(1D))), Arr(Get(s_1166, "h"), ((V)(0D)), ((V)(0.9))))).V);
} else {
if (SEqS(Get(s_1166, "k"), "peb")) {
P0_1170 = Call(ball_12, V.Undef, ((V)((-0.6))), y_1169, ((V)(0.4)), ((V)(10.6)), c_1168, NewObj(6).Put("sy", ((V)(0.4))).Put("sz", ((V)(0.86))).Put("k", ((V)(6D))).Put("n", ((V)(22D))).Put("mat", ((V)("cer"))).Put("shine", ((V)(0D))).V);
} else {
P0_1170 = Call(cyl_14, V.Undef, ((V)(0D)), y_1169, ((V)(0D)), ((V)(13D)), Get(s_1166, "h"), c_1168, NewObj(3).Put("n", ((V)(28D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.36))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.62))), Arr(((V)(7D)), ((V)(0D)), ((V)(0.88))), Arr(Get(s_1166, "h"), ((V)(0D)), ((V)(1D))))).V);
}
}
}
}
}
Invoke(o_1132, "push", P0_1170);
Invoke(parts_1138, "push", P0_1170);
if (LtN(Get(s_1166, "i"), 5D)) {
Invoke(o_1132, "push", Call(cyl_14, V.Undef, ((V)(0D)), Add(y_1169, Get(s_1166, "h")), ((V)(0D)), ((V)(3.2)), ((V)(2.4)), BRZ_1092, Call(M__39, V.Undef, NewObj(3).Put("n", ((V)(12D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(0.6)), ((V)(0D)), ((V)(0.8))), Arr(((V)(1.8)), ((V)(0D)), ((V)(0.8))), Arr(((V)(2.4)), ((V)(0D)), ((V)(1D))))).V)));
}
return default;
}, 1, "", true));
Invoke(parts_1138, "forEach", Fn((V _arrowThis1179, int _argc1171, V P0_1177, V i_1178, V _a1175, V _a1176, V[] _rest1172) => {
V s_1180 = default;
V VA_1181 = default;
V VW_1182 = default;
V CL_1183 = default;
V CK_1184 = default;
V GC_1185 = default;
s_1180 = GetK(Lr_1137, i_1178);
VA_1181 = Call(dec_27, V.Undef, ((V)("#c98a4e")), NewObj(1).Put("op", ((V)(0.38))).V);
VW_1182 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.55))).V);
CL_1183 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.42))).V);
CK_1184 = Call(dec_27, V.Undef, ((V)("#b0906a")), NewObj(1).Put("op", ((V)(0.5))).V);
GC_1185 = Call(dec_27, V.Undef, ((V)("#ffd9a0")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.3))).V);
Invoke(Get(P0_1177, "faces"), "forEach", Fn((V _arrowThis1193, int _argc1186, V F_1192, V _a1189, V _a1190, V _a1191, V[] _rest1187) => {
V G_1194 = default;
double A_1195 = 0;
G_1194 = Call(fr2_45, V.Undef, F_1192);
A_1195 = (System.Math.Abs(ToNum(Invoke(Get(G_1194, "P"), "reduce", Fn((V _arrowThis1206, int _argc1196, V a_1202, V p_1203, V j_1204, V Q_1205, V[] _rest1197) => {
return ((V)((ToNum(Add(a_1202, ((V)((ToNum(GetIdx(p_1203, 0D)) * ToNum(GetIdx(GetIdx(Q_1205, (ToNum(Add(j_1204, ((V)(1D)))) % ToNum(Get(Q_1205, "length")))), 1D))))))) - (ToNum(GetIdx(GetIdx(Q_1205, (ToNum(Add(j_1204, ((V)(1D)))) % ToNum(Get(Q_1205, "length")))), 0D)) * ToNum(GetIdx(p_1203, 1D))))));
}, 4, "", true), ((V)(0D))))) / 2D);
if ((A_1195 < 3D)) {
return default;
}
if (SEqS(Get(s_1180, "k"), "blk")) {
V W_1207 = default;
V H_1208 = default;
double E_1209 = 0;
{ V _t1210 = Call(WH2_67, V.Undef, G_1194);
{ V _t1211 = ListOf(_t1210);
{ V _t1212 = GetIdx(_t1211, 0D);
W_1207 = _t1212; }
{ V _t1213 = GetIdx(_t1211, 1D);
H_1208 = _t1213; }
} }
E_1209 = Max(ToNum(W_1207), ToNum(H_1208));
Call(rep_35, V.Undef, ((V)(Min(3D, (1D + Round((A_1195 / 60D)))))), Fn((V _arrowThis1221, int _argc1214, V v_1220, V _a1217, V _a1218, V _a1219, V[] _rest1215) => {
double ph_1222 = 0;
double s_1223 = 0;
double th_1224 = 0;
V D0_1225 = default;
ph_1222 = (ToNum(Call(R_1134, V.Undef)) * 6D);
s_1223 = (((ToNum(Call(R_1134, V.Undef)) - 0.5) * E_1209) * 0.7);
th_1224 = ((0.5 + (ToNum(i_1178) * 0.6)) + (ToNum(v_1220) * 1.1));
D0_1225 = (NumTruthy((ToNum(v_1220) % 2D)) ? VW_1182 : VA_1181);
Call(wavy_47, V.Undef, D0_1225, F_1192, Fn((V _arrowThis1233, int _argc1226, V t_1232, V _a1229, V _a1230, V _a1231, V[] _rest1227) => {
double u_1234 = 0;
double w_1235 = 0;
u_1234 = ((-E_1209) + ((2D * E_1209) * ToNum(t_1232)));
w_1235 = ((s_1223 + ((FdLibm.Sin(((u_1234 * 0.35) + ph_1222)) * E_1209) * 0.1)) + (FdLibm.Sin(((u_1234 * 0.9) + ph_1222)) * 0.3));
return Arr(((V)(((u_1234 * FdLibm.Cos(th_1224)) - (w_1235 * FdLibm.Sin(th_1224))))), ((V)(((u_1234 * FdLibm.Sin(th_1224)) + (w_1235 * FdLibm.Cos(th_1224))))));
return default;
}, 1, "", true), ((V)(26D)), ((V)((NumTruthy((ToNum(v_1220) % 2D)) ? 0.4 : 0.26))), ((V)(1D)));
return default;
}, 1, "", true));
}
if ((A_1195 > 12D)) {
Call(fleck_69, V.Undef, CL_1183, CL_1183, F_1192, R_1134, ((V)(Min(6D, Round((A_1195 / 12D))))), ((V)(0.8)));
}
if ((SEqS(Get(s_1180, "k"), "blk") || SEqS(Get(s_1180, "k"), "drum"))) {
Call(rep_35, V.Undef, ((V)(Min(5D, Round((A_1195 / 20D))))), Fn((V _arrowThis1242, int _argc1236, V _a1238, V _a1239, V _a1240, V _a1241, V[] _rest1237) => {
V W_1243 = default;
V H_1244 = default;
double a_1245 = 0;
double b_1246 = 0;
{ V _t1247 = Call(WH2_67, V.Undef, G_1194);
{ V _t1248 = ListOf(_t1247);
{ V _t1249 = GetIdx(_t1248, 0D);
W_1243 = _t1249; }
{ V _t1250 = GetIdx(_t1248, 1D);
H_1244 = _t1250; }
} }
a_1245 = (((ToNum(Call(R_1134, V.Undef)) - 0.5) * ToNum(W_1243)) * 0.8);
b_1246 = (((ToNum(Call(R_1134, V.Undef)) - 0.5) * ToNum(H_1244)) * 0.8);
Invoke(CK_1184, "line", Arr(Invoke(G_1194, "at", ((V)(a_1245)), ((V)(b_1246))), Invoke(G_1194, "at", ((V)((a_1245 + 1.4))), ((V)((b_1246 + 0.5))))), Get(G_1194, "n"), ((V)(0.22)));
return default;
}, 0, "", true));
}
if ((GtN(GetIdx(Get(F_1192, "n"), 2D), 0.6) && (A_1195 > 20D))) {
Call(spot_28, V.Undef, GC_1185, Invoke(G_1194, "at", ((V)(0D)), ((V)(0D))), Get(G_1194, "n"), ((V)(2.6)), ((V)(3.2)), ((V)(0D)), ((V)(10D)));
}
return default;
}, 1, "", true));
if (!SEqS(Get(s_1180, "k"), "blk")) {
V ip_1251 = default;
V h_1252 = default;
V y0_1253 = default;
V RF_1254 = default;
V sp_1255 = default;
ip_1251 = Fn((V _arrowThis1264, int _argc1256, V Q_1262, V y_1263, V _a1260, V _a1261, V[] _rest1257) => {
{
double j_1265 = 0;
j_1265 = 0D;
while (true) {
if (!((j_1265 < (ToNum(Get(Q_1262, "length")) - 1D)))) break;
if (Le(y_1263, GetIdx(GetIdx(Q_1262, (j_1265 + 1D)), 0D))) {
return Add(GetIdx(GetIdx(Q_1262, j_1265), 1D), ((V)((((ToNum(GetIdx(GetIdx(Q_1262, (j_1265 + 1D)), 1D)) - ToNum(GetIdx(GetIdx(Q_1262, j_1265), 1D))) * (ToNum(y_1263) - ToNum(GetIdx(GetIdx(Q_1262, j_1265), 0D)))) / (ToNum(GetIdx(GetIdx(Q_1262, (j_1265 + 1D)), 0D)) - ToNum(GetIdx(GetIdx(Q_1262, j_1265), 0D)))))));
}
j_1265++;
}
}
return GetIdx(GetIdx(Q_1262, (ToNum(Get(Q_1262, "length")) - 1D)), 1D);
return default;
}, 2, "", true);
h_1252 = Get(s_1180, "h");
y0_1253 = Get(s_1180, "y");
RF_1254 = (SEqS(Get(s_1180, "k"), "disc") ? Arr(((V)((-0.4))), ((V)(0D)), Fn((V _arrowThis1274, int _argc1267, V y_1273, V _a1270, V _a1271, V _a1272, V[] _rest1268) => {
return ((V)((11.6 * ToNum(Call(ip_1251, V.Undef, Arr(Arr(((V)(0D)), ((V)(0.86))), Arr(((V)(1.4)), ((V)(0.98))), Arr(((V)((ToNum(h_1252) - 1.4))), ((V)(1D))), Arr(h_1252, ((V)(0.88)))), ((V)((ToNum(y_1273) - ToNum(y0_1253)))))))));
}, 1, "", true), ((V)(1D))) : (SEqS(Get(s_1180, "k"), "ball") ? Arr(((V)(0.8)), ((V)(0D)), Fn((V _arrowThis1282, int _argc1275, V y_1281, V _a1278, V _a1279, V _a1280, V[] _rest1276) => {
return ((V)(System.Math.Sqrt(Max(0.01, (81D - Pow(((ToNum(y_1281) - ToNum(y0_1253)) - 9D), 2D))))));
}, 1, "", true), ((V)(1D))) : (SEqS(Get(s_1180, "k"), "drum") ? Arr(((V)(0D)), ((V)(0D)), Fn((V _arrowThis1289, int _argc1283, V _a1285, V _a1286, V _a1287, V _a1288, V[] _rest1284) => {
return ((V)(6.45));
}, 0, "", true), ((V)(1D))) : (SEqS(Get(s_1180, "k"), "peb") ? Arr(((V)((-0.6))), ((V)(0.4)), Fn((V _arrowThis1297, int _argc1290, V y_1296, V _a1293, V _a1294, V _a1295, V[] _rest1291) => {
return ((V)((10.6 * System.Math.Sqrt(Max(0.01, (1D - Pow((((ToNum(y_1296) - ToNum(y0_1253)) - 4.24) / 4.24), 2D)))))));
}, 1, "", true), ((V)(0.86))) : Arr(((V)(0D)), ((V)(0D)), Fn((V _arrowThis1305, int _argc1298, V y_1304, V _a1301, V _a1302, V _a1303, V[] _rest1299) => {
return ((V)((13D * ToNum(Call(ip_1251, V.Undef, Arr(Arr(((V)(0D)), ((V)(0.36))), Arr(((V)(3D)), ((V)(0.62))), Arr(((V)(7D)), ((V)(0.88))), Arr(h_1252, ((V)(1D)))), ((V)((ToNum(y_1304) - ToNum(y0_1253)))))))));
}, 1, "", true), ((V)(1D)))))));
sp_1255 = Fn((V _arrowThis1314, int _argc1306, V a_1312, V y_1313, V _a1310, V _a1311, V[] _rest1307) => {
V r_1315 = default;
r_1315 = Add(InvokeK(RF_1254, ((V)(2D)), y_1313), ((V)(0.06)));
return Arr(Arr(Add(GetIdx(RF_1254, 0D), ((V)((FdLibm.Cos(ToNum(a_1312)) * ToNum(r_1315))))), y_1313, Add(GetIdx(RF_1254, 1D), ((V)(((FdLibm.Sin(ToNum(a_1312)) * ToNum(r_1315)) * ToNum(GetIdx(RF_1254, 3D))))))), Call(nz_57, V.Undef, Arr(((V)(FdLibm.Cos(ToNum(a_1312)))), ((V)(0.15)), ((V)((FdLibm.Sin(ToNum(a_1312)) / ToNum(GetIdx(RF_1254, 3D))))))));
return default;
}, 2, "", true);
Call(rep_35, V.Undef, ((V)(((SEqS(Get(s_1180, "k"), "disc") || SEqS(Get(s_1180, "k"), "peb")) ? 2D : 3D))), Fn((V _arrowThis1323, int _argc1316, V v_1322, V _a1319, V _a1320, V _a1321, V[] _rest1317) => {
double ph_1324 = 0;
double f2_1325 = 0;
V D0_1326 = default;
ph_1324 = (ToNum(Call(R_1134, V.Undef)) * 6D);
f2_1325 = (1D + System.Math.Floor((ToNum(Call(R_1134, V.Undef)) * 2D)));
D0_1326 = (NumTruthy((ToNum(v_1322) % 2D)) ? VW_1182 : VA_1181);
Call(lineOn_65, V.Undef, D0_1326, Fn((V _arrowThis1334, int _argc1327, V u_1333, V _a1330, V _a1331, V _a1332, V[] _rest1328) => {
double a_1335 = 0;
V yy_1336 = default;
a_1335 = ((ToNum(u_1333) * 2D) * PI_22);
yy_1336 = Add(y0_1253, ((V)((ToNum(h_1252) * ((0.5 + (0.32 * FdLibm.Sin(((a_1335 * f2_1325) + ph_1324)))) + (0.08 * FdLibm.Sin(((a_1335 * 5D) + (ph_1324 * 2D)))))))));
return Call(sp_1255, V.Undef, ((V)(a_1335)), ((V)(Max(ToNum(Add(y0_1253, ((V)(0.4)))), Min((ToNum(Add(y0_1253, h_1252)) - 0.4), ToNum(yy_1336))))));
return default;
}, 1, "", true), ((V)(64D)), ((V)((NumTruthy((ToNum(v_1322) % 2D)) ? 0.45 : 0.3))), ((V)(0D)));
return default;
}, 1, "", true));
Call(rep_35, V.Undef, ((V)(2D)), Fn((V _arrowThis1343, int _argc1337, V _a1339, V _a1340, V _a1341, V _a1342, V[] _rest1338) => {
double a0_1344 = 0;
V yy_1345 = default;
a0_1344 = ((ToNum(Call(R_1134, V.Undef)) * 2D) * PI_22);
yy_1345 = Add(y0_1253, ((V)((ToNum(h_1252) * (0.25 + (ToNum(Call(R_1134, V.Undef)) * 0.5))))));
Call(lineOn_65, V.Undef, CK_1184, Fn((V _arrowThis1353, int _argc1346, V u_1352, V _a1349, V _a1350, V _a1351, V[] _rest1347) => {
return Call(sp_1255, V.Undef, ((V)((a0_1344 + (ToNum(u_1352) * 0.5)))), Add(yy_1345, ((V)((FdLibm.Sin((ToNum(u_1352) * 9D)) * 0.25)))));
}, 1, "", true), ((V)(8D)), ((V)(0.14)), ((V)(1D)));
return default;
}, 0, "", true));
}
Call(on_1133, V.Undef, P0_1177, Arr(GC_1185, VA_1181, VW_1182, CL_1183, CK_1184));
return default;
}, 2, "", true));
{
V s_1354 = default;
V BW_1355 = default;
s_1354 = GetIdx(Lr_1137, 5D);
BW_1355 = GetIdx(parts_1138, 5D);
Call(on_1133, V.Undef, BW_1355, Arr(Call(cyl_14, V.Undef, ((V)(0D)), ((V)((ToNum(Add(Get(s_1354, "y"), Get(s_1354, "h"))) - 0.6))), ((V)(0D)), ((V)(12.2)), ((V)(0.3)), ((V)("#fff1d0")), Call(em_43, V.Undef, NewObj(1).Put("n", ((V)(28D))).V))), Y3_59);
}
return o_1132;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1363, int _argc1356, V c_1362, V _a1359, V _a1360, V _a1361, V[] _rest1357) => {
V k_1364 = default;
JsStrBuf f_1365 = null;
V t_1366 = default;
k_1364 = Get(c_1362, "k");
f_1365 = new JsStrBuf("");
Invoke(Call(lay_1094, V.Undef), "forEach", Fn((V _arrowThis1375, int _argc1367, V s_1373, V i_1374, V _a1371, V _a1372, V[] _rest1368) => {
V q_1376 = default;
double rx_1377 = 0;
double ry_1378 = 0;
q_1376 = Invoke(c_1362, "p", ((V)(0D)), Add(Get(s_1373, "y"), ((V)((ToNum(Get(s_1373, "h")) / 2D)))), ((V)(0D)));
rx_1377 = ((SEqS(Get(s_1373, "k"), "drum") ? 6D : (SEqS(Get(s_1373, "k"), "ball") ? 8D : 10D)) * ToNum(k_1364));
ry_1378 = ((ToNum(Get(s_1373, "h")) * 0.4) * ToNum(k_1364));
f_1365.S("<ellipse cx=\"").V(Call(f1_20, V.Undef, GetIdx(q_1376, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(q_1376, 1D))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)(rx_1377)))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)(ry_1378)))).S("\" fill=\"url(#q26al)\" opacity=\"0.3\"><animate attributeName=\"opacity\" values=\"0.15;0.6;0.15\" dur=\"4.6s\" begin=\"").V(Call(f1_20, V.Undef, ((V)(((-ToNum(i_1374)) * 0.75))))).S("s\" repeatCount=\"indefinite\"/></ellipse>");
return default;
}, 2, "", true));
t_1366 = Invoke(c_1362, "p", ((V)(0D)), ((V)(112D)), ((V)(0D)));
f_1365.S("<ellipse cx=\"").V(Call(f1_20, V.Undef, GetIdx(t_1366, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(t_1366, 1D)) - (6D * ToNum(k_1364))))))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((16D * ToNum(k_1364)))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((14D * ToNum(k_1364)))))).S("\" fill=\"url(#q26al)\" opacity=\"0.45\"/>");
return NewObj(2).Put("defs", ((V)("<radialGradient id=\"q26al\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.9\"/><stop offset=\"0.45\" stop-color=\"#ffe2b0\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#ffd08a\" stop-opacity=\"0\"/></radialGradient>"))).Put("front", ((V)(f_1365.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
GLY_74 = NewObj(9).Put("A", Arr(Arr(Arr(((V)((-0.7))), ((V)((-1D)))), Arr(((V)(0D)), ((V)(1D))), Arr(((V)(0.7)), ((V)((-1D))))), Arr(Arr(((V)((-0.38))), ((V)((-0.18)))), Arr(((V)(0.38)), ((V)((-0.18))))))).Put("B", Arr(Arr(Arr(((V)((-0.6))), ((V)((-1D)))), Arr(((V)((-0.6))), ((V)(1D))), Arr(((V)(0.25)), ((V)(1D))), Arr(((V)(0.56)), ((V)(0.76))), Arr(((V)(0.56)), ((V)(0.3))), Arr(((V)(0.25)), ((V)(0.04))), Arr(((V)((-0.6))), ((V)(0.04)))), Arr(Arr(((V)(0.25)), ((V)(0.04))), Arr(((V)(0.66)), ((V)((-0.22)))), Arr(((V)(0.66)), ((V)((-0.74)))), Arr(((V)(0.3)), ((V)((-1D)))), Arr(((V)((-0.6))), ((V)((-1D))))))).Put("C", Arr(Call(rep_35, V.Undef, ((V)(15D)), Fn((V _arrowThis1386, int _argc1379, V i_1385, V _a1382, V _a1383, V _a1384, V[] _rest1380) => {
double a_1387 = 0;
a_1387 = (PI_22 * (0.27 + ((1.46 * ToNum(i_1385)) / 14D)));
return Arr(((V)((0.72 * FdLibm.Cos(a_1387)))), ((V)(FdLibm.Sin(a_1387))));
return default;
}, 1, "", true)))).Put("D", Arr(Arr(Arr(((V)((-0.6))), ((V)((-1D)))), Arr(((V)((-0.6))), ((V)(1D))), Arr(((V)(0.05)), ((V)(1D))), Arr(((V)(0.5)), ((V)(0.72))), Arr(((V)(0.68)), ((V)(0D))), Arr(((V)(0.5)), ((V)((-0.72)))), Arr(((V)(0.05)), ((V)((-1D)))), Arr(((V)((-0.6))), ((V)((-1D))))))).Put("E", Arr(Arr(Arr(((V)(0.6)), ((V)(1D))), Arr(((V)((-0.6))), ((V)(1D))), Arr(((V)((-0.6))), ((V)((-1D)))), Arr(((V)(0.6)), ((V)((-1D))))), Arr(Arr(((V)((-0.6))), ((V)(0D))), Arr(((V)(0.35)), ((V)(0D)))))).Put("F", Arr(Arr(Arr(((V)(0.6)), ((V)(1D))), Arr(((V)((-0.6))), ((V)(1D))), Arr(((V)((-0.6))), ((V)((-1D))))), Arr(Arr(((V)((-0.6))), ((V)(0.05))), Arr(((V)(0.35)), ((V)(0.05)))))).Put("1", Arr(Arr(Arr(((V)((-0.35))), ((V)(0.62))), Arr(((V)(0.08)), ((V)(1D))), Arr(((V)(0.08)), ((V)((-1D))))), Arr(Arr(((V)((-0.45))), ((V)((-1D)))), Arr(((V)(0.55)), ((V)((-1D))))))).Put("2", Arr(Arr(Arr(((V)((-0.6))), ((V)(0.55))), Arr(((V)((-0.35))), ((V)(0.92))), Arr(((V)(0.05)), ((V)(1D))), Arr(((V)(0.45)), ((V)(0.88))), Arr(((V)(0.62)), ((V)(0.5))), Arr(((V)(0.45)), ((V)(0.08))), Arr(((V)((-0.62))), ((V)((-1D)))), Arr(((V)(0.66)), ((V)((-1D))))))).Put("3", Arr(Arr(Arr(((V)((-0.6))), ((V)(0.78))), Arr(((V)((-0.2))), ((V)(1D))), Arr(((V)(0.3)), ((V)(1D))), Arr(((V)(0.6)), ((V)(0.72))), Arr(((V)(0.5)), ((V)(0.25))), Arr(((V)(0D)), ((V)(0.04))), Arr(((V)(0.52)), ((V)((-0.2)))), Arr(((V)(0.65)), ((V)((-0.62)))), Arr(((V)(0.35)), ((V)((-1D)))), Arr(((V)((-0.2))), ((V)((-1D)))), Arr(((V)((-0.62))), ((V)((-0.78))))))).V;
SHP_75 = NewObj(2).Put("star", Call(rep_35, V.Undef, ((V)(10D)), Fn((V _arrowThis1395, int _argc1388, V i_1394, V _a1391, V _a1392, V _a1393, V[] _rest1389) => {
double a_1396 = 0;
double r_1397 = 0;
a_1396 = ((PI_22 / 2D) + (((ToNum(i_1394) / 10D) * 2D) * PI_22));
r_1397 = (NumTruthy((ToNum(i_1394) % 2D)) ? 0.42 : 1D);
return Arr(((V)((FdLibm.Cos(a_1396) * r_1397))), ((V)((FdLibm.Sin(a_1396) * r_1397))));
return default;
}, 1, "", true))).Put("heart", Call(rep_35, V.Undef, ((V)(28D)), Fn((V _arrowThis1405, int _argc1398, V i_1404, V _a1401, V _a1402, V _a1403, V[] _rest1399) => {
double t_1406 = 0;
t_1406 = (((ToNum(i_1404) / 28D) * 2D) * PI_22);
return Arr(((V)((Pow(FdLibm.Sin(t_1406), 3D) * 0.95))), ((V)((((((((13D * FdLibm.Cos(t_1406)) - (5D * FdLibm.Cos((2D * t_1406)))) - (2D * FdLibm.Cos((3D * t_1406)))) - FdLibm.Cos((4D * t_1406))) / 16D) * 0.95) + 0.12))));
return default;
}, 1, "", true))).V;
ABC_ORDER_76 = Arr(((V)("A")), ((V)("B")), ((V)("C")), ((V)("star")), ((V)("D")), ((V)("E")), ((V)("F")), ((V)("heart")), ((V)("1")), ((V)("2")), ((V)("3")), ((V)("star")), ((V)("A")), ((V)("B")), ((V)("heart")), ((V)("C")), ((V)("D")), ((V)("1")), ((V)("E")), ((V)("star")), ((V)("2")), ((V)("F")), ((V)("3")), ((V)("heart")), ((V)("A")), ((V)("C")), ((V)("B")), ((V)("star")), ((V)("E")), ((V)("D")));
Set(N_21, "abc26", Fn((V _arrowThis1414, int _argc1407, V S_1413, V _a1410, V _a1411, V _a1412, V[] _rest1408) => {
return NewObj(5).Put("w", ((V)(90D))).Put("d", ((V)(66D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(56D))).Put("z", ((V)(14D))).V).Put("build", Fn((V _arrowThis1421, int _argc1415, V _a1417, V _a1418, V _a1419, V _a1420, V[] _rest1416) => {
V o_1422 = default;
V on_1423 = default;
V R_1424 = default;
V WD_1425 = default;
V PC_1426 = default;
V BL_1427 = default;
double gi_1428 = 0;
o_1422 = Arr();
on_1423 = Call(glue_33, V.Undef, o_1422);
R_1424 = Call(R0_34, V.Undef, ((V)("abc26")));
WD_1425 = ((V)("#edcb92"));
PC_1426 = Arr(((V)("#e8504a")), ((V)("#3f86d6")), ((V)("#f2b92a")), ((V)("#4caf62")), ((V)("#f08a2e")), ((V)("#8f62cc")));
BL_1427 = Arr(Arr(((V)((-26D))), ((V)(0D)), ((V)((-4D))), ((V)(26D)), ((V)(0.1))), Arr(((V)(5D)), ((V)(0D)), ((V)((-6D))), ((V)(26D)), ((V)((-0.15)))), Arr(((V)((-10D))), ((V)(26D)), ((V)((-5D))), ((V)(26D)), ((V)(0.35))), Arr(((V)((-10D))), ((V)(52D)), ((V)((-5D))), ((V)(16D)), ((V)((-0.3)))), Arr(((V)((-14D))), ((V)(0D)), ((V)(24D)), ((V)(18D)), ((V)((-0.5)))), Arr(((V)(18D)), ((V)(0D)), ((V)(22D)), ((V)(16D)), ((V)(0.25))));
gi_1428 = 0D;
Invoke(BL_1427, "forEach", Fn((V _arrowThis1447, int _argc1429, V _a1431, V bi_1435, V _a1433, V _a1434, V[] _rest1430) => {
V B_1448 = default;
double cy_1449 = 0;
double sy_1450 = 0;
V LX_1451 = default;
V LZ_1452 = default;
double h_1453 = 0;
V C_1454 = default;
V FACES_1455 = default;
V Ds_1456 = default;
V x_1438 = default;
V y_1440 = default;
V z_1442 = default;
V s_1444 = default;
V yw_1446 = default;
{ V _t1436 = ListOf(_a1431);
{ V _t1437 = GetIdx(_t1436, 0D);
x_1438 = _t1437; }
{ V _t1439 = GetIdx(_t1436, 1D);
y_1440 = _t1439; }
{ V _t1441 = GetIdx(_t1436, 2D);
z_1442 = _t1441; }
{ V _t1443 = GetIdx(_t1436, 3D);
s_1444 = _t1443; }
{ V _t1445 = GetIdx(_t1436, 4D);
yw_1446 = _t1445; }
}
B_1448 = Call(box_13, V.Undef, x_1438, y_1440, z_1442, s_1444, s_1444, s_1444, WD_1425, NewObj(4).Put("r", ((V)((ToNum(s_1444) * 0.1)))).Put("bev", ((V)((ToNum(s_1444) * 0.07)))).Put("yaw", yw_1446).Put("mat", ((V)("wood"))).V);
Invoke(o_1422, "push", B_1448);
cy_1449 = FdLibm.Cos(ToNum(yw_1446));
sy_1450 = FdLibm.Sin(ToNum(yw_1446));
LX_1451 = Arr(((V)(cy_1449)), ((V)(0D)), ((V)(sy_1450)));
LZ_1452 = Arr(((V)((-sy_1450))), ((V)(0D)), ((V)(cy_1449)));
h_1453 = (ToNum(s_1444) / 2D);
C_1454 = Arr(x_1438, Add(y_1440, ((V)(h_1453))), z_1442);
FACES_1455 = Invoke(Invoke(Arr(Arr(LZ_1452, LX_1451), Arr(Call(mul_55, V.Undef, LZ_1452, ((V)((-1D)))), Call(mul_55, V.Undef, LX_1451, ((V)((-1D))))), Arr(LX_1451, Call(mul_55, V.Undef, LZ_1452, ((V)((-1D))))), Arr(Call(mul_55, V.Undef, LX_1451, ((V)((-1D)))), LZ_1452)), "map", Fn((V _arrowThis1468, int _argc1457, V _a1459, V _a1460, V _a1461, V _a1462, V[] _rest1458) => {
V n_1465 = default;
V r_1467 = default;
{ V _t1463 = ListOf(_a1459);
{ V _t1464 = GetIdx(_t1463, 0D);
n_1465 = _t1464; }
{ V _t1466 = GetIdx(_t1463, 1D);
r_1467 = _t1466; }
}
return NewObj(4).Put("n", n_1465).Put("r", r_1467).Put("u", Y3_59).Put("c", Call(add_53, V.Undef, C_1454, Call(mul_55, V.Undef, n_1465, ((V)(h_1453))))).V;
}, 1, "", true)), "concat", Arr(NewObj(4).Put("n", Y3_59).Put("r", LX_1451).Put("u", Call(mul_55, V.Undef, LZ_1452, ((V)((-1D))))).Put("c", Arr(x_1438, Add(y_1440, s_1444), z_1442)).V));
Ds_1456 = Arr();
Invoke(FACES_1455, "forEach", Fn((V _arrowThis1477, int _argc1469, V Fc_1475, V fi_1476, V _a1473, V _a1474, V[] _rest1470) => {
V P_1478 = default;
V col_1479 = default;
V gc_1480 = default;
V g_1481 = default;
V n_1482 = default;
V GR_1483 = default;
V GL_1484 = default;
V FR_1485 = default;
V FRh_1486 = default;
V SHd_1487 = default;
V GM_1488 = default;
V GH_1489 = default;
V CHp_1490 = default;
V DN_1491 = default;
V sq_1492 = default;
double gs_1493 = 0;
P_1478 = Fn((V _arrowThis1502, int _argc1494, V a_1500, V b_1501, V _a1498, V _a1499, V[] _rest1495) => {
return Call(add_53, V.Undef, Get(Fc_1475, "c"), Call(add_53, V.Undef, Call(mul_55, V.Undef, Get(Fc_1475, "r"), ((V)((ToNum(a_1500) * h_1453)))), Call(mul_55, V.Undef, Get(Fc_1475, "u"), ((V)((ToNum(b_1501) * h_1453))))));
}, 2, "", true);
col_1479 = GetIdx(PC_1426, (ToNum(Add(((V)((ToNum(bi_1435) * 2D))), fi_1476)) % 6D));
gc_1480 = GetIdx(PC_1426, (ToNum(Add(Add(((V)((ToNum(bi_1435) * 2D))), fi_1476), ((V)(3D)))) % 6D));
g_1481 = GetIdx(ABC_ORDER_76, (gi_1428++ % ToNum(Get(ABC_ORDER_76, "length"))));
n_1482 = Get(Fc_1475, "n");
GR_1483 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, WD_1425, ((V)(0.78))), NewObj(1).Put("op", ((V)(0.45))).V);
GL_1484 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, WD_1425, ((V)("#ffffff")), ((V)(0.35))), NewObj(1).Put("op", ((V)(0.4))).V);
FR_1485 = Call(dec_27, V.Undef, col_1479);
FRh_1486 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, col_1479, ((V)("#ffffff")), ((V)(0.4))), NewObj(1).Put("op", ((V)(0.6))).V);
SHd_1487 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, gc_1480, ((V)(0.55))), NewObj(1).Put("op", ((V)(0.75))).V);
GM_1488 = Call(dec_27, V.Undef, gc_1480);
GH_1489 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, gc_1480, ((V)("#ffffff")), ((V)(0.5))), NewObj(1).Put("op", ((V)(0.7))).V);
CHp_1490 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, WD_1425, ((V)("#ffffff")), ((V)(0.5))), NewObj(1).Put("op", ((V)(0.8))).V);
DN_1491 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, WD_1425, ((V)(0.6))), NewObj(1).Put("op", ((V)(0.4))).V);
Call(rep_35, V.Undef, ((V)(5D)), Fn((V _arrowThis1510, int _argc1503, V k_1509, V _a1506, V _a1507, V _a1508, V[] _rest1504) => {
double b_1511 = 0;
double ph_1512 = 0;
b_1511 = (((-0.8) + (ToNum(k_1509) * 0.4)) + ((ToNum(Call(R_1424, V.Undef)) - 0.5) * 0.12));
ph_1512 = (ToNum(Call(R_1424, V.Undef)) * 6D);
Invoke((NumTruthy((ToNum(k_1509) % 2D)) ? GL_1484 : GR_1483), "line", Call(rep_35, V.Undef, ((V)(9D)), Fn((V _arrowThis1520, int _argc1513, V i_1519, V _a1516, V _a1517, V _a1518, V[] _rest1514) => {
double a_1521 = 0;
a_1521 = ((-0.86) + (ToNum(i_1519) * 0.215));
return Call(P_1478, V.Undef, ((V)(a_1521)), ((V)((b_1511 + (0.04 * FdLibm.Sin(((a_1521 * 5D) + ph_1512)))))));
return default;
}, 1, "", true)), n_1482, ((V)((h_1453 * 0.035))), ((V)(1D)));
return default;
}, 1, "", true));
sq_1492 = Invoke(Call(rep_35, V.Undef, ((V)(5D)), Fn((V _arrowThis1541, int _argc1534, V i_1540, V _a1537, V _a1538, V _a1539, V[] _rest1535) => {
return GetK(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(1D))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)((-1D))), ((V)((-1D))))), i_1540);
}, 1, "", true)), "map", Fn((V _arrowThis1533, int _argc1522, V _a1524, V _a1525, V _a1526, V _a1527, V[] _rest1523) => {
V a_1530 = default;
V b_1532 = default;
{ V _t1528 = ListOf(_a1524);
{ V _t1529 = GetIdx(_t1528, 0D);
a_1530 = _t1529; }
{ V _t1531 = GetIdx(_t1528, 1D);
b_1532 = _t1531; }
}
return Call(P_1478, V.Undef, ((V)((ToNum(a_1530) * 0.74))), ((V)((ToNum(b_1532) * 0.74))));
}, 1, "", true));
Invoke(FR_1485, "line", sq_1492, n_1482, ((V)((h_1453 * 0.11))));
Invoke(FRh_1486, "line", Invoke(sq_1492, "map", Fn((V _arrowThis1550, int _argc1542, V p_1548, V i_1549, V _a1546, V _a1547, V[] _rest1543) => {
return Call(P_1478, V.Undef, ((V)((ToNum(GetIdx(GetK(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(1D))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)((-1D))), ((V)((-1D))))), i_1549), 0D)) * 0.66))), ((V)((ToNum(GetIdx(GetK(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(1D))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)((-1D))), ((V)((-1D))))), i_1549), 1D)) * 0.66))));
}, 2, "", true)), n_1482, ((V)((h_1453 * 0.025))));
gs_1493 = 0.44;
if (Truthy(GetK(SHP_75, g_1481))) {
V Q_1551 = default;
Q_1551 = GetK(SHP_75, g_1481);
Invoke(SHd_1487, "poly", Invoke(Q_1551, "map", Fn((V _arrowThis1563, int _argc1552, V _a1554, V _a1555, V _a1556, V _a1557, V[] _rest1553) => {
V a_1560 = default;
V b_1562 = default;
{ V _t1558 = ListOf(_a1554);
{ V _t1559 = GetIdx(_t1558, 0D);
a_1560 = _t1559; }
{ V _t1561 = GetIdx(_t1558, 1D);
b_1562 = _t1561; }
}
return Call(P_1478, V.Undef, ((V)(((ToNum(a_1560) * gs_1493) + 0.05))), ((V)(((ToNum(b_1562) * gs_1493) - 0.05))));
}, 1, "", true)), n_1482);
Invoke(GM_1488, "poly", Invoke(Q_1551, "map", Fn((V _arrowThis1575, int _argc1564, V _a1566, V _a1567, V _a1568, V _a1569, V[] _rest1565) => {
V a_1572 = default;
V b_1574 = default;
{ V _t1570 = ListOf(_a1566);
{ V _t1571 = GetIdx(_t1570, 0D);
a_1572 = _t1571; }
{ V _t1573 = GetIdx(_t1570, 1D);
b_1574 = _t1573; }
}
return Call(P_1478, V.Undef, ((V)((ToNum(a_1572) * gs_1493))), ((V)((ToNum(b_1574) * gs_1493))));
}, 1, "", true)), n_1482);
Invoke(GH_1489, "line", Invoke(Invoke(Q_1551, "slice", ((V)(0D)), ((V)(System.Math.Ceiling((ToNum(Get(Q_1551, "length")) / 2D))))), "map", Fn((V _arrowThis1587, int _argc1576, V _a1578, V _a1579, V _a1580, V _a1581, V[] _rest1577) => {
V a_1584 = default;
V b_1586 = default;
{ V _t1582 = ListOf(_a1578);
{ V _t1583 = GetIdx(_t1582, 0D);
a_1584 = _t1583; }
{ V _t1585 = GetIdx(_t1582, 1D);
b_1586 = _t1585; }
}
return Call(P_1478, V.Undef, ((V)((((ToNum(a_1584) * gs_1493) * 0.8) - 0.02))), ((V)((((ToNum(b_1586) * gs_1493) * 0.8) + 0.02))));
}, 1, "", true)), n_1482, ((V)((h_1453 * 0.03))));
} else {
Invoke(GetK(GLY_74, g_1481), "forEach", Fn((V _arrowThis1595, int _argc1588, V L_1594, V _a1591, V _a1592, V _a1593, V[] _rest1589) => {
Invoke(SHd_1487, "line", Invoke(L_1594, "map", Fn((V _arrowThis1607, int _argc1596, V _a1598, V _a1599, V _a1600, V _a1601, V[] _rest1597) => {
V a_1604 = default;
V b_1606 = default;
{ V _t1602 = ListOf(_a1598);
{ V _t1603 = GetIdx(_t1602, 0D);
a_1604 = _t1603; }
{ V _t1605 = GetIdx(_t1602, 1D);
b_1606 = _t1605; }
}
return Call(P_1478, V.Undef, ((V)(((ToNum(a_1604) * gs_1493) + 0.05))), ((V)(((ToNum(b_1606) * gs_1493) - 0.05))));
}, 1, "", true)), n_1482, ((V)((h_1453 * 0.17))));
Invoke(GM_1488, "line", Invoke(L_1594, "map", Fn((V _arrowThis1619, int _argc1608, V _a1610, V _a1611, V _a1612, V _a1613, V[] _rest1609) => {
V a_1616 = default;
V b_1618 = default;
{ V _t1614 = ListOf(_a1610);
{ V _t1615 = GetIdx(_t1614, 0D);
a_1616 = _t1615; }
{ V _t1617 = GetIdx(_t1614, 1D);
b_1618 = _t1617; }
}
return Call(P_1478, V.Undef, ((V)((ToNum(a_1616) * gs_1493))), ((V)((ToNum(b_1618) * gs_1493))));
}, 1, "", true)), n_1482, ((V)((h_1453 * 0.15))));
Invoke(GH_1489, "line", Invoke(L_1594, "map", Fn((V _arrowThis1631, int _argc1620, V _a1622, V _a1623, V _a1624, V _a1625, V[] _rest1621) => {
V a_1628 = default;
V b_1630 = default;
{ V _t1626 = ListOf(_a1622);
{ V _t1627 = GetIdx(_t1626, 0D);
a_1628 = _t1627; }
{ V _t1629 = GetIdx(_t1626, 1D);
b_1630 = _t1629; }
}
return Call(P_1478, V.Undef, ((V)(((ToNum(a_1628) * gs_1493) - 0.025))), ((V)(((ToNum(b_1630) * gs_1493) + 0.03))));
}, 1, "", true)), n_1482, ((V)((h_1453 * 0.035))));
return default;
}, 1, "", true));
}
Call(rep_35, V.Undef, ((V)(2D)), Fn((V _arrowThis1638, int _argc1632, V _a1634, V _a1635, V _a1636, V _a1637, V[] _rest1633) => {
double e_1639 = 0;
double t_1640 = 0;
e_1639 = (LtN(Call(R_1424, V.Undef), 0.5) ? (-0.9) : 0.9);
t_1640 = ((ToNum(Call(R_1424, V.Undef)) - 0.5) * 1.6);
Call(spot_28, V.Undef, CHp_1490, (LtN(Call(R_1424, V.Undef), 0.5) ? Call(P_1478, V.Undef, ((V)(e_1639)), ((V)(t_1640))) : Call(P_1478, V.Undef, ((V)(t_1640)), ((V)(e_1639)))), n_1482, ((V)((h_1453 * 0.05))), ((V)((h_1453 * 0.035))), ((V)((ToNum(Call(R_1424, V.Undef)) * 3D))), ((V)(6D)));
return default;
}, 0, "", true));
if (LtN(Call(R_1424, V.Undef), 0.5)) {
Call(spot_28, V.Undef, DN_1491, Call(P_1478, V.Undef, ((V)(((ToNum(Call(R_1424, V.Undef)) - 0.5) * 1.1))), ((V)(((ToNum(Call(R_1424, V.Undef)) - 0.5) * 1.1)))), n_1482, ((V)((h_1453 * 0.05))), ((V)((h_1453 * 0.03))), ((V)((ToNum(Call(R_1424, V.Undef)) * 3D))), ((V)(6D)));
}
Invoke(Ds_1456, "push", GR_1483, GL_1484, FR_1485, FRh_1486, SHd_1487, GM_1488, GH_1489, CHp_1490, DN_1491);
return default;
}, 2, "", true));
Call(on_1423, V.Undef, B_1448, Ds_1456);
return default;
}, 2, "", true));
return o_1422;
return default;
}, 0, "build", true)).V;
}, 1, "", true));
SXc_77 = (-11D);
SYc_78 = 24D;
SRc_79 = 5.6;
MXc_80 = 15D;
CRG_81 = Arr(NewObj(6).Put("r", ((V)(8.8))).Put("e1", X3_58).Put("e2", Z3_60).Put("col", ((V)("#e2b14a"))).Put("w", ((V)(1.25))).Put("tk", ((V)(24D))).V, NewObj(5).Put("r", ((V)(8D))).Put("e1", Y3_59).Put("e2", Call(nz_57, V.Undef, Arr(((V)(FdLibm.Cos(0.75))), ((V)(0D)), ((V)(FdLibm.Sin(0.75)))))).Put("col", ((V)("#d5dbe0"))).Put("w", ((V)(0.8))).V, NewObj(6).Put("r", ((V)(10.2))).Put("e1", Call(nz_57, V.Undef, Arr(((V)(FdLibm.Cos(0.3))), ((V)(0D)), ((V)(FdLibm.Sin(0.3)))))).Put("e2", Call(nz_57, V.Undef, Arr(((V)(((-FdLibm.Sin(0.3)) * FdLibm.Cos(0.42)))), ((V)(FdLibm.Sin(0.42))), ((V)((FdLibm.Cos(0.3) * FdLibm.Cos(0.42))))))).Put("col", ((V)("#c9932e"))).Put("w", ((V)(0.65))).Put("dots", ((V)(12D))).V);
ringsSVG_82 = Fn((V _arrowThis1649, int _argc1641, V p_1647, V k_1648, V _a1645, V _a1646, V[] _rest1642) => {
V o0_1650 = default;
V dep_1651 = default;
V C_1652 = default;
V dc_1653 = default;
V @out_1654 = default;
V pth_1655 = default;
o0_1650 = Call(p_1647, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
dep_1651 = Fn((V _arrowThis1663, int _argc1656, V P_1662, V _a1659, V _a1660, V _a1661, V[] _rest1657) => {
return ((V)(((ToNum(GetIdx(P_1662, 1D)) * ToNum(SA_25)) + (((ToNum(GetIdx(Call(p_1647, V.Undef, GetIdx(P_1662, 0D), ((V)(0D)), GetIdx(P_1662, 2D)), 1D)) - ToNum(GetIdx(o0_1650, 1D))) * ToNum(CA_26)) / (ToNum(SA_25) * ToNum(k_1648))))));
}, 1, "", true);
C_1652 = Arr(((V)(SXc_77)), ((V)(SYc_78)), ((V)(0D)));
dc_1653 = Call(dep_1651, V.Undef, C_1652);
@out_1654 = NewObj(2).Put("b", ((V)(""))).Put("f", ((V)(""))).V;
pth_1655 = Fn((V _arrowThis1671, int _argc1664, V L_1670, V _a1667, V _a1668, V _a1669, V[] _rest1665) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(L_1670, "map", Fn((V _arrowThis1679, int _argc1672, V q_1678, V _a1675, V _a1676, V _a1677, V[] _rest1673) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(q_1678, 0D))).S(" ").V(Call(f1_20, V.Undef, GetIdx(q_1678, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).End()));
}, 1, "", true);
Invoke(CRG_81, "forEach", Fn((V _arrowThis1688, int _argc1680, V Rg_1686, V ri_1687, V _a1684, V _a1685, V[] _rest1681) => {
double m_1689 = 0;
V P3_1690 = default;
V runs_1691 = default;
V cur_1692 = default;
V kd_1693 = default;
V nR_1694 = default;
m_1689 = 80D;
P3_1690 = Call(rep_35, V.Undef, ((V)((m_1689 + 1D))), Fn((V _arrowThis1702, int _argc1695, V i_1701, V _a1698, V _a1699, V _a1700, V[] _rest1696) => {
double t_1703 = 0;
t_1703 = (((ToNum(i_1701) / m_1689) * 2D) * PI_22);
return Call(add_53, V.Undef, C_1652, Call(add_53, V.Undef, Call(mul_55, V.Undef, Get(Rg_1686, "e1"), ((V)((FdLibm.Cos(t_1703) * ToNum(Get(Rg_1686, "r")))))), Call(mul_55, V.Undef, Get(Rg_1686, "e2"), ((V)((FdLibm.Sin(t_1703) * ToNum(Get(Rg_1686, "r"))))))));
return default;
}, 1, "", true));
runs_1691 = NewObj(2).Put("b", Arr()).Put("f", Arr()).V;
cur_1692 = V.Null;
kd_1693 = V.Null;
Invoke(P3_1690, "forEach", Fn((V _arrowThis1711, int _argc1704, V P_1710, V _a1707, V _a1708, V _a1709, V[] _rest1705) => {
V q_1712 = default;
V kk_1713 = default;
q_1712 = Call(p_1647, V.Undef, GetIdx(P_1710, 0D), GetIdx(P_1710, 1D), GetIdx(P_1710, 2D));
kk_1713 = ((V)((Gt(Call(dep_1651, V.Undef, P_1710), dc_1653) ? "f" : "b")));
if (!SEq(kk_1713, kd_1693)) {
if (Truthy((cur_1692 is var _t1714 && !Truthy(_t1714) ? _t1714 : (GtN(Get(cur_1692, "length"), 1D) ? V.True : V.False)))) {
Invoke(GetK(runs_1691, kd_1693), "push", cur_1692);
}
cur_1692 = (Truthy(cur_1692) ? Arr(GetIdx(cur_1692, (ToNum(Get(cur_1692, "length")) - 1D))) : Arr());
kd_1693 = kk_1713;
}
Invoke(cur_1692, "push", q_1712);
return default;
}, 1, "", true));
if (Truthy((cur_1692 is var _t1715 && !Truthy(_t1715) ? _t1715 : (GtN(Get(cur_1692, "length"), 1D) ? V.True : V.False)))) {
Invoke(GetK(runs_1691, kd_1693), "push", cur_1692);
}
Invoke(Arr(((V)("b")), ((V)("f"))), "forEach", Fn((V _arrowThis1723, int _argc1716, V s_1722, V _a1719, V _a1720, V _a1721, V[] _rest1717) => {
return Invoke(GetK(runs_1691, s_1722), "forEach", Fn((V _arrowThis1731, int _argc1724, V L_1730, V _a1727, V _a1728, V _a1729, V[] _rest1725) => {
V d_1732 = default;
double op_1733 = 0;
d_1732 = Call(pth_1655, V.Undef, L_1730);
op_1733 = (SEqS(s_1722, "b") ? 0.75 : 1D);
OpSetK(@out_1654, s_1722, 0, ((V)(JsStrBuf.Begin().S("<path d=\"").V(d_1732).S("\" fill=\"none\" stroke=\"#3a2a10\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Add(Get(Rg_1686, "w"), ((V)(0.55)))) * ToNum(k_1648)))))).S("\" stroke-linecap=\"round\" opacity=\"").N(op_1733).S("\"/><path d=\"").V(d_1732).S("\" fill=\"none\" stroke=\"").V(Get(Rg_1686, "col")).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(Rg_1686, "w")) * ToNum(k_1648)))))).S("\" stroke-linecap=\"round\" opacity=\"").N(op_1733).S("\"/><path d=\"").V(d_1732).S("\" fill=\"none\" stroke=\"#fff6d0\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)(((ToNum(Get(Rg_1686, "w")) * 0.28) * ToNum(k_1648)))))).S("\" stroke-linecap=\"round\" opacity=\"").N((op_1733 * 0.7)).S("\"/>").S("<path d=\"").V(d_1732).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)(((ToNum(Get(Rg_1686, "w")) * 0.5) * ToNum(k_1648)))))).S("\" stroke-linecap=\"round\" stroke-dasharray=\"").V(Call(f1_20, V.Undef, ((V)((1.4 * ToNum(k_1648)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((14D * ToNum(k_1648)))))).S("\" opacity=\"").N((SEqS(s_1722, "f") ? 0.9 : 0.4)).S("\"><animate attributeName=\"stroke-dashoffset\" values=\"0;").V(Call(f1_20, V.Undef, ((V)((((NumTruthy((ToNum(ri_1687) % 2D)) ? 1D : (-1D)) * 15.4) * ToNum(k_1648)))))).S("\" dur=\"").V(Add(((V)(2.6)), ri_1687)).S("s\" repeatCount=\"indefinite\"/></path>").End())));
return default;
}, 1, "", true));
}, 1, "", true));
nR_1694 = Call(nz_57, V.Undef, Call(cr_56, V.Undef, Get(Rg_1686, "e1"), Get(Rg_1686, "e2")));
if (Truthy(Get(Rg_1686, "tk"))) {
Call(rep_35, V.Undef, Get(Rg_1686, "tk"), Fn((V _arrowThis1741, int _argc1734, V i_1740, V _a1737, V _a1738, V _a1739, V[] _rest1735) => {
double t_1742 = 0;
V P_1743 = default;
V a_1744 = default;
V b_1745 = default;
t_1742 = (((ToNum(i_1740) / ToNum(Get(Rg_1686, "tk"))) * 2D) * PI_22);
P_1743 = Call(add_53, V.Undef, C_1652, Call(add_53, V.Undef, Call(mul_55, V.Undef, Get(Rg_1686, "e1"), ((V)((FdLibm.Cos(t_1742) * ToNum(Get(Rg_1686, "r")))))), Call(mul_55, V.Undef, Get(Rg_1686, "e2"), ((V)((FdLibm.Sin(t_1742) * ToNum(Get(Rg_1686, "r"))))))));
a_1744 = CallSpread(p_1647, V.Undef, new ArrBuilder().Spread(Call(add_53, V.Undef, P_1743, Call(mul_55, V.Undef, nR_1694, ((V)((ToNum(Get(Rg_1686, "w")) * 0.48)))))).V);
b_1745 = CallSpread(p_1647, V.Undef, new ArrBuilder().Spread(Call(sub_54, V.Undef, P_1743, Call(mul_55, V.Undef, nR_1694, ((V)((ToNum(Get(Rg_1686, "w")) * 0.48)))))).V);
OpSetK(@out_1654, ((V)((Gt(Call(dep_1651, V.Undef, P_1743), dc_1653) ? "f" : "b"))), 0, ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_20, V.Undef, GetIdx(a_1744, 0D))).S(" ").V(Call(f1_20, V.Undef, GetIdx(a_1744, 1D))).S("L").V(Call(f1_20, V.Undef, GetIdx(b_1745, 0D))).S(" ").V(Call(f1_20, V.Undef, GetIdx(b_1745, 1D))).S("\" stroke=\"#5a3a0c\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)(((NumTruthy((ToNum(i_1740) % 6D)) ? 0.18 : 0.36) * ToNum(k_1648)))))).S("\"/>").End())));
return default;
}, 1, "", true));
}
if (Truthy(Get(Rg_1686, "dots"))) {
Call(rep_35, V.Undef, Get(Rg_1686, "dots"), Fn((V _arrowThis1753, int _argc1746, V i_1752, V _a1749, V _a1750, V _a1751, V[] _rest1747) => {
double t_1754 = 0;
V P_1755 = default;
V q_1756 = default;
t_1754 = (((ToNum(Add(i_1752, ((V)(0.5)))) / ToNum(Get(Rg_1686, "dots"))) * 2D) * PI_22);
P_1755 = Call(add_53, V.Undef, C_1652, Call(add_53, V.Undef, Call(mul_55, V.Undef, Get(Rg_1686, "e1"), ((V)((FdLibm.Cos(t_1754) * ToNum(Get(Rg_1686, "r")))))), Call(mul_55, V.Undef, Get(Rg_1686, "e2"), ((V)((FdLibm.Sin(t_1754) * ToNum(Get(Rg_1686, "r"))))))));
q_1756 = CallSpread(p_1647, V.Undef, new ArrBuilder().Spread(P_1755).V);
OpSetK(@out_1654, ((V)((Gt(Call(dep_1651, V.Undef, P_1755), dc_1653) ? "f" : "b"))), 0, ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_20, V.Undef, GetIdx(q_1756, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(q_1756, 1D))).S("\" r=\"").V(Call(f1_20, V.Undef, ((V)((0.55 * ToNum(k_1648)))))).S("\" fill=\"#fff1b0\" stroke=\"#7a5a1e\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.15 * ToNum(k_1648)))))).S("\"/>").End())));
return default;
}, 1, "", true));
}
if (SEqN(ri_1687, 1D)) {
Invoke(Arr(((V)(0D)), ((V)(PI_22))), "forEach", Fn((V _arrowThis1764, int _argc1757, V t_1763, V _a1760, V _a1761, V _a1762, V[] _rest1758) => {
V P_1765 = default;
V q_1766 = default;
P_1765 = Call(add_53, V.Undef, C_1652, Call(mul_55, V.Undef, Get(Rg_1686, "e2"), ((V)((FdLibm.Cos(ToNum(t_1763)) * ToNum(Get(Rg_1686, "r")))))));
q_1766 = CallSpread(p_1647, V.Undef, new ArrBuilder().Spread(P_1765).V);
OpSetK(@out_1654, ((V)((Gt(Call(dep_1651, V.Undef, P_1765), dc_1653) ? "f" : "b"))), 0, ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_20, V.Undef, GetIdx(q_1766, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(q_1766, 1D))).S("\" r=\"").V(Call(f1_20, V.Undef, ((V)((0.8 * ToNum(k_1648)))))).S("\" fill=\"#f0c24a\" stroke=\"#6a4a12\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.2 * ToNum(k_1648)))))).S("\"/>").End())));
return default;
}, 1, "", true));
}
return default;
}, 2, "", true));
return @out_1654;
return default;
}, 2, "", true);
Set(N_21, "chrono26", Fn((V _arrowThis1774, int _argc1767, V S_1773, V _a1770, V _a1771, V _a1772, V[] _rest1768) => {
double zf_1775 = 0;
zf_1775 = System.Math.Sqrt(((SRc_79 * SRc_79) - (3.6 * 3.6)));
return NewObj(7).Put("w", ((V)(62D))).Put("d", ((V)(36D))).Put("small", ((V)(1D))).Put("topH", ((V)(5D))).Put("build", Fn((V _arrowThis1782, int _argc1776, V _a1778, V _a1779, V _a1780, V _a1781, V[] _rest1777) => {
V o_1783 = default;
V on_1784 = default;
V R_1785 = default;
V BS_1786 = default;
V PD_1787 = default;
V STd_1788 = default;
V MC_1789 = default;
V MT_1790 = default;
V LU_1791 = default;
o_1783 = Arr();
on_1784 = Call(glue_33, V.Undef, o_1783);
R_1785 = Call(R0_34, V.Undef, ((V)("chr26")));
BS_1786 = Call(box_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(56D)), ((V)(4.4)), ((V)(28D)), ((V)("#17171b")), NewObj(4).Put("r", ((V)(2D))).Put("mat", ((V)("cer"))).Put("shine", ((V)(1D))).Put("bev", ((V)(0.8))).V);
Invoke(o_1783, "push", BS_1786);
{
V V1_1792 = default;
V V2_1793 = default;
V IN_1794 = default;
V GL_1795 = default;
V PQ_1796 = default;
V EN_1797 = default;
V1_1792 = Call(dec_27, V.Undef, ((V)("#e8e6e2")), NewObj(1).Put("op", ((V)(0.42))).V);
V2_1793 = Call(dec_27, V.Undef, ((V)("#8a8a90")), NewObj(1).Put("op", ((V)(0.5))).V);
IN_1794 = Call(dec_27, V.Undef, BR_24);
GL_1795 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.12))).V);
Invoke(Call(caps_50, V.Undef, BS_1786, ((V)(2D))), "forEach", Fn((V _arrowThis1805, int _argc1798, V F_1804, V _a1801, V _a1802, V _a1803, V[] _rest1799) => {
Call(rep_35, V.Undef, ((V)(4D)), Fn((V _arrowThis1813, int _argc1806, V i_1812, V _a1809, V _a1810, V _a1811, V[] _rest1807) => {
double ph_1814 = 0;
double z0_1815 = 0;
ph_1814 = (ToNum(Call(R_1785, V.Undef)) * 6D);
z0_1815 = ((-10D) + (ToNum(i_1812) * 6.5));
Invoke((NumTruthy((ToNum(i_1812) % 2D)) ? V2_1793 : V1_1792), "line", Call(wv_30, V.Undef, ((V)(24D)), Fn((V _arrowThis1823, int _argc1816, V t_1822, V _a1819, V _a1820, V _a1821, V[] _rest1817) => {
return Arr(((V)(((-27D) + (54D * ToNum(t_1822))))), ((V)(4.45)), ((V)(((z0_1815 + (2.4 * FdLibm.Sin(((ToNum(t_1822) * 5D) + ph_1814)))) + ((ToNum(t_1822) - 0.5) * 5D)))));
}, 1, "", true)), Y3_59, ((V)((0.25 + (ToNum(Call(R_1785, V.Undef)) * 0.25)))), ((V)(1D)));
return default;
}, 1, "", true));
Call(outline_48, V.Undef, IN_1794, F_1804, ((V)(0.93)), ((V)(0.32)));
Invoke(GL_1795, "poly", Arr(Arr(((V)((-26D))), ((V)(4.46)), ((V)((-6D)))), Arr(((V)((-20D))), ((V)(4.46)), ((V)((-13D)))), Arr(((V)((-16D))), ((V)(4.46)), ((V)((-13D)))), Arr(((V)((-22D))), ((V)(4.46)), ((V)((-6D))))), Y3_59);
return default;
}, 1, "", true));
Invoke(Call(sides_51, V.Undef, BS_1786, ((V)(1D))), "forEach", Fn((V _arrowThis1831, int _argc1824, V F_1830, V _a1827, V _a1828, V _a1829, V[] _rest1825) => {
if (GtN(GetIdx(Get(F_1830, "n"), 2D), 0.9)) {
Call(wavy_47, V.Undef, V1_1792, F_1830, Fn((V _arrowThis1840, int _argc1832, V t_1838, V G_1839, V _a1836, V _a1837, V[] _rest1833) => {
V W_1841 = default;
{ V _t1842 = Call(WH2_67, V.Undef, G_1839);
{ V _t1843 = ListOf(_t1842);
{ V _t1844 = GetIdx(_t1843, 0D);
W_1841 = _t1844; }
} }
return Arr(((V)((((-ToNum(W_1841)) / 2D) + (ToNum(W_1841) * ToNum(t_1838))))), ((V)((FdLibm.Sin((ToNum(t_1838) * 7D)) * 0.8))));
return default;
}, 2, "", true), ((V)(30D)), ((V)(0.22)), ((V)(1D)));
}
return default;
}, 1, "", true));
Call(on_1784, V.Undef, BS_1786, Arr(GL_1795, V1_1792, V2_1793, IN_1794));
PQ_1796 = GetIdx(Call(on_1784, V.Undef, BS_1786, Arr(Call(box_13, V.Undef, ((V)(2D)), ((V)(0.9)), ((V)(14.05)), ((V)(14D)), ((V)(2.6)), ((V)(0.34)), BR_24, Call(M__39, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("shine", ((V)(1D))).V))), Z3_60), 0D);
EN_1797 = Call(dec_27, V.Undef, ((V)("#5a4214")), NewObj(1).Put("op", ((V)(0.85))).V);
Invoke(EN_1797, "line", Arr(Arr(((V)((-3.6))), ((V)(2.8)), ((V)(14.42))), Arr(((V)(7.6)), ((V)(2.8)), ((V)(14.42)))), Z3_60, ((V)(0.32)));
Invoke(EN_1797, "line", Arr(Arr(((V)((-2.4))), ((V)(1.9)), ((V)(14.42))), Arr(((V)(6.4)), ((V)(1.9)), ((V)(14.42)))), Z3_60, ((V)(0.18)));
Invoke(Arr(Arr(((V)((-4.4))), ((V)(1.4))), Arr(((V)(8.4)), ((V)(1.4))), Arr(((V)((-4.4))), ((V)(3.2))), Arr(((V)(8.4)), ((V)(3.2)))), "forEach", Fn((V _arrowThis1856, int _argc1845, V _a1847, V _a1848, V _a1849, V _a1850, V[] _rest1846) => {
V x_1853 = default;
V y_1855 = default;
{ V _t1851 = ListOf(_a1847);
{ V _t1852 = GetIdx(_t1851, 0D);
x_1853 = _t1852; }
{ V _t1854 = GetIdx(_t1851, 1D);
y_1855 = _t1854; }
}
return Call(spot_28, V.Undef, EN_1797, Arr(x_1853, y_1855, ((V)(14.42))), Z3_60, ((V)(0.22)), ((V)(0.22)), ((V)(0D)), ((V)(6D)));
}, 1, "", true));
Call(on_1784, V.Undef, PQ_1796, Arr(EN_1797));
}
PD_1787 = Call(cyl_14, V.Undef, ((V)(SXc_77)), ((V)(4.4)), ((V)(0D)), ((V)(8.6)), ((V)(1.8)), ((V)("#c9a24a")), Call(M__39, V.Undef, NewObj(3).Put("n", ((V)(30D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(1.2)), ((V)(0D)), ((V)(1D))), Arr(((V)(1.8)), ((V)(0D)), ((V)(0.94))))).V));
Invoke(o_1783, "push", PD_1787);
{
V TK_1857 = default;
V HL_1858 = default;
TK_1857 = Call(dec_27, V.Undef, ((V)("#5a3a0c")), NewObj(1).Put("op", ((V)(0.8))).V);
HL_1858 = Call(dec_27, V.Undef, ((V)("#fff6d0")), NewObj(1).Put("op", ((V)(0.5))).V);
Call(rep_35, V.Undef, ((V)(36D)), Fn((V _arrowThis1866, int _argc1859, V i_1865, V _a1862, V _a1863, V _a1864, V[] _rest1860) => {
double a_1867 = 0;
a_1867 = (((ToNum(i_1865) / 36D) * 2D) * PI_22);
Invoke(TK_1857, "line", Arr(Arr(((V)((SXc_77 + (FdLibm.Cos(a_1867) * 7D)))), ((V)(6.22)), ((V)((FdLibm.Sin(a_1867) * 7D)))), Arr(((V)((SXc_77 + (FdLibm.Cos(a_1867) * (NumTruthy((ToNum(i_1865) % 3D)) ? 7.7 : 8.2))))), ((V)(6.22)), ((V)((FdLibm.Sin(a_1867) * (NumTruthy((ToNum(i_1865) % 3D)) ? 7.7 : 8.2)))))), Y3_59, ((V)((NumTruthy((ToNum(i_1865) % 3D)) ? 0.14 : 0.24))));
return default;
}, 1, "", true));
Call(ringY_32, V.Undef, HL_1858, ((V)(SXc_77)), ((V)(0D)), ((V)(8.3)), ((V)(6.22)), ((V)(0.2)), ((V)(48D)));
Call(on_1784, V.Undef, PD_1787, Arr(TK_1857, HL_1858, Call(cyl_14, V.Undef, ((V)(SXc_77)), ((V)(6.2)), ((V)(0D)), ((V)(6.2)), ((V)(0.22)), ((V)("#6ac8ff")), Call(em_43, V.Undef, NewObj(1).Put("n", ((V)(28D))).V))));
}
STd_1788 = Call(cyl_14, V.Undef, ((V)(MXc_80)), ((V)(4.4)), ((V)(0D)), ((V)(7.8)), ((V)(2.8)), ((V)("#4a2c18")), Call(W__40, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(2D)), ((V)(0D)), ((V)(1D))), Arr(((V)(2.8)), ((V)(0D)), ((V)(0.9))))).V));
Invoke(o_1783, "push", STd_1788);
{
V G1_1868 = default;
V G2_1869 = default;
V LBp_1870 = default;
V EN_1871 = default;
G1_1868 = Call(dec_27, V.Undef, ((V)("#24160c")), NewObj(1).Put("op", ((V)(0.55))).V);
G2_1869 = Call(dec_27, V.Undef, ((V)("#7a4e2e")), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Arr(((V)(1.6)), ((V)(2.8)), ((V)(4D)), ((V)(5.2)), ((V)(6.4))), "forEach", Fn((V _arrowThis1880, int _argc1872, V r_1878, V i_1879, V _a1876, V _a1877, V[] _rest1873) => {
return Invoke((NumTruthy((ToNum(i_1879) % 2D)) ? G2_1869 : G1_1868), "line", Call(wv_30, V.Undef, ((V)(30D)), Fn((V _arrowThis1888, int _argc1881, V t_1887, V _a1884, V _a1885, V _a1886, V[] _rest1882) => {
double a_1889 = 0;
a_1889 = ((ToNum(t_1887) * 2D) * PI_22);
return Arr(((V)((MXc_80 + ((FdLibm.Cos(a_1889) * ToNum(r_1878)) * (1D + (0.05 * FdLibm.Sin(ToNum(Add(((V)((a_1889 * 4D))), i_1879))))))))), ((V)(7.22)), ((V)((FdLibm.Sin(a_1889) * ToNum(r_1878)))));
return default;
}, 1, "", true)), Y3_59, ((V)(0.16)));
}, 2, "", true));
LBp_1870 = GetIdx(Call(on_1784, V.Undef, STd_1788, Arr(Call(box_13, V.Undef, ((V)(MXc_80)), ((V)(5D)), ((V)(7.6)), ((V)(6D)), ((V)(1.6)), ((V)(0.3)), BR_24, Call(M__39, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("shine", ((V)(1D))).V))), Z3_60), 0D);
EN_1871 = Call(dec_27, V.Undef, ((V)("#5a4214")), NewObj(1).Put("op", ((V)(0.85))).V);
Invoke(EN_1871, "line", Arr(Arr(((V)((MXc_80 - 2.4))), ((V)(6D)), ((V)(7.92))), Arr(((V)((MXc_80 + 2.4))), ((V)(6D)), ((V)(7.92)))), Z3_60, ((V)(0.2)));
Invoke(EN_1871, "line", Arr(Arr(((V)((MXc_80 - 1.6))), ((V)(5.5)), ((V)(7.92))), Arr(((V)((MXc_80 + 1.6))), ((V)(5.5)), ((V)(7.92)))), Z3_60, ((V)(0.14)));
Call(on_1784, V.Undef, LBp_1870, Arr(EN_1871));
Call(on_1784, V.Undef, STd_1788, Arr(G1_1868, G2_1869, Call(rod_36, V.Undef, Arr(((V)(MXc_80)), ((V)(7.2)), ((V)(0D))), Arr(((V)(MXc_80)), ((V)(9.6)), ((V)(0D))), ((V)(0.55)), ((V)("#9aa3a8")), Call(M__39, V.Undef, NewObj(1).Put("n", ((V)(8D))).V))));
}
MC_1789 = Arr(((V)(MXc_80)), ((V)((8.8 + (6D * 0.82)))), ((V)(0D)));
MT_1790 = Call(ball_12, V.Undef, ((V)(MXc_80)), ((V)(8.8)), ((V)(0D)), ((V)(6D)), ((V)("#3b393c")), NewObj(4).Put("sy", ((V)(0.82))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).Put("mat", ((V)("metal"))).V);
Invoke(o_1783, "push", MT_1790);
LU_1791 = Invoke(Arr(Arr(((V)((-2.8))), ((V)(1.8)), ((V)(1.2)), ((V)(4.2))), Arr(((V)(2.8)), ((V)(2.4)), ((V)((-1.4))), ((V)(4D))), Arr(((V)(0.2)), ((V)(3.4)), ((V)((-0.6))), ((V)(3.6)))), "map", Fn((V _arrowThis1905, int _argc1890, V _a1892, V _a1893, V _a1894, V _a1895, V[] _rest1891) => {
V c_1906 = default;
V S1_1907 = default;
V dx_1898 = default;
V dy_1900 = default;
V dz_1902 = default;
V r_1904 = default;
{ V _t1896 = ListOf(_a1892);
{ V _t1897 = GetIdx(_t1896, 0D);
dx_1898 = _t1897; }
{ V _t1899 = GetIdx(_t1896, 1D);
dy_1900 = _t1899; }
{ V _t1901 = GetIdx(_t1896, 2D);
dz_1902 = _t1901; }
{ V _t1903 = GetIdx(_t1896, 3D);
r_1904 = _t1903; }
}
c_1906 = Call(add_53, V.Undef, MC_1789, Arr(dx_1898, dy_1900, dz_1902));
S1_1907 = Call(ball_12, V.Undef, GetIdx(c_1906, 0D), ((V)((ToNum(GetIdx(c_1906, 1D)) - (ToNum(r_1904) * 0.85)))), GetIdx(c_1906, 2D), r_1904, ((V)("#403e41")), NewObj(4).Put("sy", ((V)(0.85))).Put("k", ((V)(5D))).Put("n", ((V)(12D))).Put("mat", ((V)("metal"))).V);
Set(S1_1907, "fn", Call(nz_57, V.Undef, Arr(dx_1898, dy_1900, dz_1902)));
return NewObj(4).Put("S", S1_1907).Put("c", c_1906).Put("r", r_1904).Put("ry", ((V)((ToNum(r_1904) * 0.85)))).V;
return default;
}, 1, "", true));
Call(on_1784, V.Undef, MT_1790, Invoke(LU_1791, "map", Fn((V _arrowThis1915, int _argc1908, V l_1914, V _a1911, V _a1912, V _a1913, V[] _rest1909) => {
return Get(l_1914, "S");
}, 1, "", true)));
Invoke(LU_1791, "forEach", Fn((V _arrowThis1923, int _argc1916, V l_1922, V _a1919, V _a1920, V _a1921, V[] _rest1917) => {
Set(Get(l_1922, "S"), "fn", Call(nz_57, V.Undef, Call(sub_54, V.Undef, Get(l_1922, "c"), MC_1789)));
return default;
}, 1, "", true));
Invoke(Invoke(Arr(NewObj(4).Put("S", MT_1790).Put("c", MC_1789).Put("r", ((V)(6D))).Put("ry", ((V)((6D * 0.82)))).V), "concat", LU_1791), "forEach", Fn((V _arrowThis1932, int _argc1924, V l_1930, V li_1931, V _a1928, V _a1929, V[] _rest1925) => {
V f_1933 = default;
V TP_1934 = default;
V TR_1935 = default;
V RS_1936 = default;
V MG_1937 = default;
V FC_1938 = default;
f_1933 = Call(eS_64, V.Undef, Get(l_1930, "c"), Get(l_1930, "r"), Get(l_1930, "ry"), Get(l_1930, "r"));
TP_1934 = Call(dec_27, V.Undef, ((V)("#1f1e21")), NewObj(1).Put("op", ((V)(0.55))).V);
TR_1935 = Call(dec_27, V.Undef, ((V)("#57555a")), NewObj(1).Put("op", ((V)(0.28))).V);
RS_1936 = Call(dec_27, V.Undef, ((V)("#8a4e26")), NewObj(1).Put("op", ((V)(0.55))).V);
MG_1937 = Call(dec_27, V.Undef, ((V)("#e6ebf0")), NewObj(1).Put("op", ((V)(0.9))).V);
FC_1938 = Call(dec_27, V.Undef, ((V)("#2a2629")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(rep_35, V.Undef, ((V)(Round((ToNum(Get(l_1930, "r")) * 2.2)))), Fn((V _arrowThis1945, int _argc1939, V _a1941, V _a1942, V _a1943, V _a1944, V[] _rest1940) => {
V p0_1946 = default;
V n0_1947 = default;
double rr_1948 = 0;
{ V _t1949 = Call(f_1933, V.Undef, Arr(((V)(((ToNum(Call(R_1785, V.Undef)) - 0.5) * 2D))), Add(((V)(0.1)), Call(R_1785, V.Undef)), ((V)(((ToNum(Call(R_1785, V.Undef)) - 0.4) * 2D)))));
{ V _t1950 = ListOf(_t1949);
{ V _t1951 = GetIdx(_t1950, 0D);
p0_1946 = _t1951; }
{ V _t1952 = GetIdx(_t1950, 1D);
n0_1947 = _t1952; }
} }
rr_1948 = (ToNum(Get(l_1930, "r")) * (0.12 + (ToNum(Call(R_1785, V.Undef)) * 0.1)));
Call(spot_28, V.Undef, TP_1934, p0_1946, n0_1947, ((V)(rr_1948)), ((V)((rr_1948 * 0.8))), ((V)((ToNum(Call(R_1785, V.Undef)) * 3D))), ((V)(9D)));
Call(spot_28, V.Undef, TR_1935, Call(add_53, V.Undef, p0_1946, Call(mul_55, V.Undef, n0_1947, ((V)((-0.01))))), n0_1947, ((V)((rr_1948 * 1.35))), ((V)((rr_1948 * 1.1))), ((V)((ToNum(Call(R_1785, V.Undef)) * 3D))), ((V)(10D)));
return default;
}, 0, "", true));
Call(rep_35, V.Undef, ((V)(3D)), Fn((V _arrowThis1959, int _argc1953, V _a1955, V _a1956, V _a1957, V _a1958, V[] _rest1954) => {
V p0_1960 = default;
V n0_1961 = default;
{ V _t1962 = Call(f_1933, V.Undef, Arr(((V)(((ToNum(Call(R_1785, V.Undef)) - 0.5) * 2D))), ((V)((ToNum(Call(R_1785, V.Undef)) * 0.8))), Add(((V)(0.3)), Call(R_1785, V.Undef))));
{ V _t1963 = ListOf(_t1962);
{ V _t1964 = GetIdx(_t1963, 0D);
p0_1960 = _t1964; }
{ V _t1965 = GetIdx(_t1963, 1D);
n0_1961 = _t1965; }
} }
Call(spot_28, V.Undef, RS_1936, p0_1960, n0_1961, ((V)((0.4 + (ToNum(Call(R_1785, V.Undef)) * 0.5)))), ((V)((0.3 + (ToNum(Call(R_1785, V.Undef)) * 0.3)))), ((V)((ToNum(Call(R_1785, V.Undef)) * 3D))), ((V)(7D)));
return default;
}, 0, "", true));
Call(rep_35, V.Undef, ((V)(10D)), Fn((V _arrowThis1972, int _argc1966, V _a1968, V _a1969, V _a1970, V _a1971, V[] _rest1967) => {
V p0_1973 = default;
V n0_1974 = default;
{ V _t1975 = Call(f_1933, V.Undef, Arr(((V)(((ToNum(Call(R_1785, V.Undef)) - 0.5) * 2D))), ((V)(((ToNum(Call(R_1785, V.Undef)) - 0.3) * 2D))), ((V)(((ToNum(Call(R_1785, V.Undef)) - 0.5) * 2D)))));
{ V _t1976 = ListOf(_t1975);
{ V _t1977 = GetIdx(_t1976, 0D);
p0_1973 = _t1977; }
{ V _t1978 = GetIdx(_t1976, 1D);
n0_1974 = _t1978; }
} }
Call(spot_28, V.Undef, FC_1938, p0_1973, n0_1974, ((V)(0.25)), ((V)(0.18)), ((V)((ToNum(Call(R_1785, V.Undef)) * 3D))), ((V)(5D)));
return default;
}, 0, "", true));
if (LtN(li_1931, 2D)) {
Call(rep_35, V.Undef, ((V)(2D)), Fn((V _arrowThis1985, int _argc1979, V _a1981, V _a1982, V _a1983, V _a1984, V[] _rest1980) => {
V p0_1986 = default;
V n0_1987 = default;
{ V _t1988 = Call(f_1933, V.Undef, Arr(((V)(((-0.5) + (ToNum(Call(R_1785, V.Undef)) - 0.5)))), ((V)((0.7 + (ToNum(Call(R_1785, V.Undef)) * 0.4)))), ((V)((0.3 + (ToNum(Call(R_1785, V.Undef)) - 0.5))))));
{ V _t1989 = ListOf(_t1988);
{ V _t1990 = GetIdx(_t1989, 0D);
p0_1986 = _t1990; }
{ V _t1991 = GetIdx(_t1989, 1D);
n0_1987 = _t1991; }
} }
Call(spot_28, V.Undef, MG_1937, p0_1986, n0_1987, ((V)(0.14)), ((V)(0.09)), ((V)((ToNum(Call(R_1785, V.Undef)) * 3D))), ((V)(5D)));
return default;
}, 0, "", true));
}
Call(on_1784, V.Undef, Get(l_1930, "S"), Arr(TR_1935, TP_1934, RS_1936, FC_1938, MG_1937));
return default;
}, 2, "", true));
{
V nC_1992 = default;
V u_1993 = default;
V v_1994 = default;
V c0_1995 = default;
V CF_1996 = default;
V W1_1997 = default;
V W2_1998 = default;
V RM_1999 = default;
V GL_2000 = default;
V Q_2001 = default;
nC_1992 = Call(nz_57, V.Undef, Arr(((V)(0.45)), ((V)(0.2)), ((V)(0.87))));
u_1993 = Call(nz_57, V.Undef, Call(cr_56, V.Undef, Y3_59, nC_1992));
v_1994 = Call(cr_56, V.Undef, nC_1992, u_1993);
c0_1995 = Call(add_53, V.Undef, MC_1789, Call(mul_55, V.Undef, nC_1992, ((V)(4.6))));
CF_1996 = Call(dec_27, V.Undef, ((V)("#a9b0ba")));
W1_1997 = Call(dec_27, V.Undef, ((V)("#545b66")), NewObj(1).Put("op", ((V)(0.85))).V);
W2_1998 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.8))).V);
RM_1999 = Call(dec_27, V.Undef, ((V)("#5a585e")), NewObj(1).Put("op", ((V)(0.9))).V);
GL_2000 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.6))).V);
Q_2001 = Call(rep_35, V.Undef, ((V)(22D)), Fn((V _arrowThis2009, int _argc2002, V i_2008, V _a2005, V _a2006, V _a2007, V[] _rest2003) => {
double a_2010 = 0;
double rr_2011 = 0;
a_2010 = (((ToNum(i_2008) / 22D) * 2D) * PI_22);
rr_2011 = (3.7 * ((1D + (0.08 * FdLibm.Sin(((a_2010 * 3D) + 1D)))) + (0.05 * FdLibm.Cos((a_2010 * 5D)))));
return Call(add_53, V.Undef, c0_1995, Call(add_53, V.Undef, Call(mul_55, V.Undef, u_1993, ((V)((FdLibm.Cos(a_2010) * rr_2011)))), Call(mul_55, V.Undef, v_1994, ((V)(((FdLibm.Sin(a_2010) * rr_2011) * 0.85))))));
return default;
}, 1, "", true));
Invoke(CF_1996, "poly", Q_2001, nC_1992);
Invoke(Arr(((V)(0.3)), ((V)((0.3 + (PI_22 / 3D)))), ((V)((0.3 + ((2D * PI_22) / 3D))))), "forEach", Fn((V _arrowThis2020, int _argc2012, V a_2018, V j_2019, V _a2016, V _a2017, V[] _rest2013) => {
Call(hatch_46, V.Undef, W1_1997, NewObj(2).Put("q", Q_2001).Put("n", nC_1992).V, a_2018, ((V)(0.95)), ((V)(0.24)), NewObj(2).Put("sh", ((V)(0.94))).Put("ph", ((V)((ToNum(j_2019) * 0.3)))).V);
Call(hatch_46, V.Undef, W2_1998, NewObj(2).Put("q", Q_2001).Put("n", nC_1992).V, a_2018, ((V)(0.95)), ((V)(0.14)), NewObj(2).Put("sh", ((V)(0.94))).Put("ph", ((V)(((ToNum(j_2019) * 0.3) + 0.45)))).V);
return default;
}, 2, "", true));
Invoke(RM_1999, "line", Invoke(Q_2001, "concat", Arr(GetIdx(Q_2001, 0D))), nC_1992, ((V)(0.4)));
Invoke(GL_2000, "line", Arr(Call(add_53, V.Undef, c0_1995, Call(add_53, V.Undef, Call(mul_55, V.Undef, u_1993, ((V)((-2.6)))), Call(mul_55, V.Undef, v_1994, ((V)(1.6))))), Call(add_53, V.Undef, c0_1995, Call(add_53, V.Undef, Call(mul_55, V.Undef, u_1993, ((V)(1.2))), Call(mul_55, V.Undef, v_1994, ((V)((-2.2))))))), nC_1992, ((V)(0.5)), ((V)(1D)));
Call(on_1784, V.Undef, MT_1790, Arr(CF_1996, W1_1997, W2_1998, RM_1999, GL_2000));
}
return o_1783;
return default;
}, 0, "build", true)).Put("layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis2027, int _argc2021, V _a2023, V _a2024, V _a2025, V _a2026, V[] _rest2022) => {
V o_2028 = default;
V on_2029 = default;
V R_2030 = default;
V c_2031 = default;
V SP_2032 = default;
V gp_2033 = default;
V ML_2034 = default;
V STr_2035 = default;
V CN_2036 = default;
V HL_2037 = default;
V stars_2038 = default;
V DL_2039 = default;
V TK_2040 = default;
V BZ_2041 = default;
double zz_2042 = 0;
o_2028 = Arr();
on_2029 = Call(glue_33, V.Undef, o_2028);
R_2030 = Call(R0_34, V.Undef, ((V)("chr26s")));
c_2031 = Arr(((V)(SXc_77)), ((V)(SYc_78)), ((V)(0D)));
SP_2032 = Call(ball_12, V.Undef, ((V)(SXc_77)), ((V)((SYc_78 - SRc_79))), ((V)(0D)), ((V)(SRc_79)), ((V)("#1c2b52")), NewObj(4).Put("k", ((V)(8D))).Put("n", ((V)(22D))).Put("shine", ((V)(1D))).Put("mat", ((V)("metal"))).V);
Invoke(o_2028, "push", SP_2032);
gp_2033 = Fn((V _arrowThis2050, int _argc2043, V d_2049, V _a2046, V _a2047, V _a2048, V[] _rest2044) => {
d_2049 = Call(nz_57, V.Undef, d_2049);
return Arr(Call(add_53, V.Undef, c_2031, Call(mul_55, V.Undef, d_2049, ((V)((SRc_79 + 0.02))))), d_2049);
return default;
}, 1, "", true);
ML_2034 = Call(dec_27, V.Undef, ((V)("#c9a24a")), NewObj(1).Put("op", ((V)(0.7))).V);
STr_2035 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.9))).V);
CN_2036 = Call(dec_27, V.Undef, ((V)("#9fb4e0")), NewObj(1).Put("op", ((V)(0.5))).V);
HL_2037 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.45))).V);
Call(rep_35, V.Undef, ((V)(6D)), Fn((V _arrowThis2058, int _argc2051, V m_2057, V _a2054, V _a2055, V _a2056, V[] _rest2052) => {
double ph_2059 = 0;
ph_2059 = ((ToNum(m_2057) * PI_22) / 6D);
Call(lineOn_65, V.Undef, ML_2034, Fn((V _arrowThis2067, int _argc2060, V t_2066, V _a2063, V _a2064, V _a2065, V[] _rest2061) => {
return Call(gp_2033, V.Undef, Arr(((V)((FdLibm.Sin((ToNum(t_2066) * PI_22)) * FdLibm.Cos(ph_2059)))), ((V)(FdLibm.Cos((ToNum(t_2066) * PI_22)))), ((V)((FdLibm.Sin((ToNum(t_2066) * PI_22)) * FdLibm.Sin(ph_2059))))));
}, 1, "", true), ((V)(24D)), ((V)(0.12)));
return default;
}, 1, "", true));
Call(lineOn_65, V.Undef, ML_2034, Fn((V _arrowThis2075, int _argc2068, V t_2074, V _a2071, V _a2072, V _a2073, V[] _rest2069) => {
return Call(gp_2033, V.Undef, Arr(((V)(FdLibm.Cos(((ToNum(t_2074) * 2D) * PI_22)))), ((V)(0D)), ((V)(FdLibm.Sin(((ToNum(t_2074) * 2D) * PI_22))))));
}, 1, "", true), ((V)(40D)), ((V)(0.3)));
stars_2038 = Call(rep_35, V.Undef, ((V)(26D)), Fn((V _arrowThis2082, int _argc2076, V _a2078, V _a2079, V _a2080, V _a2081, V[] _rest2077) => {
return Arr(((V)(((ToNum(Call(R_2030, V.Undef)) - 0.5) * 2D))), ((V)(((ToNum(Call(R_2030, V.Undef)) - 0.4) * 2D))), ((V)(((ToNum(Call(R_2030, V.Undef)) - 0.5) * 2D))));
}, 0, "", true));
Invoke(stars_2038, "forEach", Fn((V _arrowThis2090, int _argc2083, V d_2089, V _a2086, V _a2087, V _a2088, V[] _rest2084) => {
V p0_2091 = default;
V n0_2092 = default;
{ V _t2093 = Call(gp_2033, V.Undef, d_2089);
{ V _t2094 = ListOf(_t2093);
{ V _t2095 = GetIdx(_t2094, 0D);
p0_2091 = _t2095; }
{ V _t2096 = GetIdx(_t2094, 1D);
n0_2092 = _t2096; }
} }
Call(spot_28, V.Undef, STr_2035, p0_2091, n0_2092, ((V)(0.13)), ((V)(0.13)), ((V)(0D)), ((V)(5D)));
return default;
}, 1, "", true));
Call(rep_35, V.Undef, ((V)(4D)), Fn((V _arrowThis2104, int _argc2097, V i_2103, V _a2100, V _a2101, V _a2102, V[] _rest2098) => {
V a_2105 = default;
V b_2106 = default;
a_2105 = Call(gp_2033, V.Undef, GetIdx(stars_2038, (ToNum(i_2103) * 3D)));
b_2106 = Call(gp_2033, V.Undef, GetIdx(stars_2038, ((ToNum(i_2103) * 3D) + 1D)));
Invoke(CN_2036, "line", Arr(GetIdx(a_2105, 0D), GetIdx(b_2106, 0D)), Arr(GetIdx(a_2105, 1D), GetIdx(b_2106, 1D)), ((V)(0.08)));
return default;
}, 1, "", true));
{
V p0_2107 = default;
V n0_2108 = default;
{ V _t2109 = Call(gp_2033, V.Undef, Arr(((V)((-0.5))), ((V)(0.72)), ((V)(0.45))));
{ V _t2110 = ListOf(_t2109);
{ V _t2111 = GetIdx(_t2110, 0D);
p0_2107 = _t2111; }
{ V _t2112 = GetIdx(_t2110, 1D);
n0_2108 = _t2112; }
} }
Call(spot_28, V.Undef, HL_2037, p0_2107, n0_2108, ((V)(1.4)), ((V)(0.8)), ((V)(0.6)), ((V)(12D)));
}
Call(on_2029, V.Undef, SP_2032, Arr(ML_2034, CN_2036, STr_2035, HL_2037));
DL_2039 = Call(disc_16, V.Undef, ((V)(SXc_77)), ((V)(SYc_78)), ((V)(zf_1775)), ((V)(3.6)), ((V)(0.3)), ((V)("#fbf6ea")), NewObj(1).Put("n", ((V)(24D))).V);
TK_2040 = Call(dec_27, V.Undef, ((V)("#2a2a30")));
BZ_2041 = Call(dec_27, V.Undef, ((V)("#e2b14a")));
zz_2042 = (zf_1775 + 0.31);
Call(on_2029, V.Undef, SP_2032, Arr(DL_2039), Z3_60);
Call(rep_35, V.Undef, ((V)(12D)), Fn((V _arrowThis2120, int _argc2113, V i_2119, V _a2116, V _a2117, V _a2118, V[] _rest2114) => {
double a_2121 = 0;
double r0_2122 = 0;
a_2121 = (((ToNum(i_2119) / 12D) * 2D) * PI_22);
r0_2122 = (NumTruthy((ToNum(i_2119) % 3D)) ? 2.9 : 2.5);
Invoke(TK_2040, "line", Arr(Arr(((V)((SXc_77 + (FdLibm.Sin(a_2121) * r0_2122)))), ((V)((SYc_78 + (FdLibm.Cos(a_2121) * r0_2122)))), ((V)(zz_2042))), Arr(((V)((SXc_77 + (FdLibm.Sin(a_2121) * 3.25)))), ((V)((SYc_78 + (FdLibm.Cos(a_2121) * 3.25)))), ((V)(zz_2042)))), Z3_60, ((V)((NumTruthy((ToNum(i_2119) % 3D)) ? 0.16 : 0.32))));
return default;
}, 1, "", true));
Invoke(BZ_2041, "line", Call(rep_35, V.Undef, ((V)(41D)), Fn((V _arrowThis2130, int _argc2123, V i_2129, V _a2126, V _a2127, V _a2128, V[] _rest2124) => {
double a_2131 = 0;
a_2131 = (((ToNum(i_2129) / 40D) * 2D) * PI_22);
return Arr(((V)((SXc_77 + (FdLibm.Cos(a_2131) * 3.55)))), ((V)((SYc_78 + (FdLibm.Sin(a_2131) * 3.55)))), ((V)(zz_2042)));
return default;
}, 1, "", true)), Z3_60, ((V)(0.36)));
Call(on_2029, V.Undef, DL_2039, Arr(TK_2040, BZ_2041));
return o_2028;
return default;
}, 0, "build", true)).Put("wrap", Fn((V _arrowThis2140, int _argc2132, V p_2138, V s_2139, V _a2136, V _a2137, V[] _rest2133) => {
double k_2141 = 0;
V RS_2142 = default;
V O_2143 = default;
V o0_2144 = default;
JsStrBuf hd_2145 = null;
k_2141 = ((ToNum(GetIdx(Call(p_2138, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D))), 1D)) - ToNum(GetIdx(Call(p_2138, V.Undef, ((V)(0D)), ((V)(1D)), ((V)(0D))), 1D))) / ToNum(CA_26));
RS_2142 = Call(ringsSVG_82, V.Undef, p_2138, ((V)(k_2141)));
O_2143 = Arr(((V)(SXc_77)), ((V)(SYc_78)), ((V)((zf_1775 + 0.35))));
o0_2144 = CallSpread(p_2138, V.Undef, new ArrBuilder().Spread(O_2143).V);
hd_2145 = new JsStrBuf("");
if (((ToNum(GetIdx(Call(p_2138, V.Undef, GetIdx(O_2143, 0D), GetIdx(O_2143, 1D), Add(GetIdx(O_2143, 2D), ((V)(1D)))), 1D)) - ToNum(GetIdx(o0_2144, 1D))) > 0.002)) {
V mtx_2146 = default;
V M_2147 = default;
V hand_2148 = default;
mtx_2146 = Fn((V _arrowThis2157, int _argc2149, V a_2155, V b_2156, V _a2153, V _a2154, V[] _rest2150) => {
return ((V)(JsStrBuf.Begin().S("matrix(").V(Invoke(Invoke(Arr(((V)((ToNum(GetIdx(a_2155, 0D)) - ToNum(GetIdx(o0_2144, 0D))))), ((V)((ToNum(GetIdx(a_2155, 1D)) - ToNum(GetIdx(o0_2144, 1D))))), ((V)((ToNum(GetIdx(b_2156, 0D)) - ToNum(GetIdx(o0_2144, 0D))))), ((V)((ToNum(GetIdx(b_2156, 1D)) - ToNum(GetIdx(o0_2144, 1D))))), GetIdx(o0_2144, 0D), GetIdx(o0_2144, 1D)), "map", Fn((V _arrowThis2165, int _argc2158, V v_2164, V _a2161, V _a2162, V _a2163, V[] _rest2159) => {
return ((V)((Round((ToNum(v_2164) * 10000D)) / 10000D)));
}, 1, "", true)), "join", ((V)(" ")))).S(")").End()));
}, 2, "", true);
M_2147 = Call(mtx_2146, V.Undef, Call(p_2138, V.Undef, Add(GetIdx(O_2143, 0D), ((V)(1D))), GetIdx(O_2143, 1D), GetIdx(O_2143, 2D)), Call(p_2138, V.Undef, GetIdx(O_2143, 0D), ((V)((ToNum(GetIdx(O_2143, 1D)) - 1D))), GetIdx(O_2143, 2D)));
hand_2148 = Fn((V _arrowThis2176, int _argc2166, V L_2172, V w_2173, V col_2174, V d_2175, V[] _rest2167) => {
return ((V)(JsStrBuf.Begin().S("<line x1=\"0\" y1=\"0.4\" x2=\"0\" y2=\"").N((-ToNum(L_2172))).S("\" stroke=\"").V(col_2174).S("\" stroke-width=\"").V(w_2173).S("\" stroke-linecap=\"round\"><animateTransform attributeName=\"transform\" type=\"rotate\" values=\"0;360\" dur=\"").V(d_2175).S("s\" repeatCount=\"indefinite\"/></line>").End()));
}, 4, "", true);
hd_2145.Set(JsStrBuf.Begin().S("<g transform=\"").V(M_2147).S("\">").V(Call(hand_2148, V.Undef, ((V)(1.8)), ((V)(0.34)), ((V)("#1f2230")), ((V)(120D)))).V(Call(hand_2148, V.Undef, ((V)(2.7)), ((V)(0.22)), ((V)("#1f2230")), ((V)(12D)))).V(Call(hand_2148, V.Undef, ((V)(2.9)), ((V)(0.1)), ((V)("#c8303a")), ((V)(3D)))).S("<circle r=\"0.32\" fill=\"#c9a24a\"/></g>").End());
}
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(bobA_44, V.Undef, Call(f1_20, V.Undef, ((V)((2.2 * k_2141)))), ((V)(3.4)))).V(Get(RS_2142, "b")).V(s_2139).S(hd_2145.Str).V(Get(RS_2142, "f")).S("</g>").End()));
return default;
}, 2, "wrap", true)).V)).Put("fx", Fn((V _arrowThis2184, int _argc2177, V c_2183, V _a2180, V _a2181, V _a2182, V[] _rest2178) => {
V p_2185 = default;
V k_2186 = default;
V top_2187 = default;
V q0_2188 = default;
V q1_2189 = default;
V q2_2190 = default;
V q3_2191 = default;
JsStrBuf f_2192 = null;
p_2185 = Get(c_2183, "p");
k_2186 = Get(c_2183, "k");
top_2187 = Call(p_2185, V.Undef, ((V)(SXc_77)), ((V)(6.3)), ((V)(0D)));
q0_2188 = Call(p_2185, V.Undef, ((V)((SXc_77 - 5.5))), ((V)(6.3)), ((V)(0D)));
q1_2189 = Call(p_2185, V.Undef, ((V)((SXc_77 + 5.5))), ((V)(6.3)), ((V)(0D)));
q2_2190 = Call(p_2185, V.Undef, ((V)((SXc_77 + 3D))), ((V)(((SYc_78 - SRc_79) - 1D))), ((V)(0D)));
q3_2191 = Call(p_2185, V.Undef, ((V)((SXc_77 - 3D))), ((V)(((SYc_78 - SRc_79) - 1D))), ((V)(0D)));
f_2192 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"M").V(Invoke(Invoke(Arr(q0_2188, q1_2189, q2_2190, q3_2191), "map", Fn((V _arrowThis2200, int _argc2193, V q_2199, V _a2196, V _a2197, V _a2198, V[] _rest2194) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(q_2199, 0D))).S(" ").V(Call(f1_20, V.Undef, GetIdx(q_2199, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z\" fill=\"url(#q26bm)\" opacity=\"0.5\"><animate attributeName=\"opacity\" values=\"0.25;0.6;0.25\" dur=\"3.4s\" repeatCount=\"indefinite\"/></path>").End());
Call(rep_35, V.Undef, ((V)(2D)), Fn((V _arrowThis2208, int _argc2201, V i_2207, V _a2204, V _a2205, V _a2206, V[] _rest2202) => {
f_2192.S("<ellipse cx=\"").V(Call(f1_20, V.Undef, GetIdx(top_2187, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(top_2187, 1D))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((3D * ToNum(k_2186)))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)(((3D * ToNum(k_2186)) * ToNum(SA_25)))))).S("\" fill=\"none\" stroke=\"#9fe6ff\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(k_2186)))))).S("\" opacity=\"0\"><animate attributeName=\"rx\" values=\"").V(Call(f1_20, V.Undef, ((V)((2D * ToNum(k_2186)))))).S(";").V(Call(f1_20, V.Undef, ((V)((8D * ToNum(k_2186)))))).S("\" dur=\"2.4s\" begin=\"").N(((-ToNum(i_2207)) * 1.2)).S("s\" repeatCount=\"indefinite\"/><animate attributeName=\"ry\" values=\"").V(Call(f1_20, V.Undef, ((V)(((2D * ToNum(k_2186)) * ToNum(SA_25)))))).S(";").V(Call(f1_20, V.Undef, ((V)(((8D * ToNum(k_2186)) * ToNum(SA_25)))))).S("\" dur=\"2.4s\" begin=\"").N(((-ToNum(i_2207)) * 1.2)).S("s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.8;0\" dur=\"2.4s\" begin=\"").N(((-ToNum(i_2207)) * 1.2)).S("s\" repeatCount=\"indefinite\"/></ellipse>");
return default;
}, 1, "", true));
Call(rep_35, V.Undef, ((V)(3D)), Fn((V _arrowThis2216, int _argc2209, V i_2215, V _a2212, V _a2213, V _a2214, V[] _rest2210) => {
V s_2217 = default;
s_2217 = Call(p_2185, V.Undef, ((V)(((MXc_80 + 2D) + ((ToNum(i_2215) - 1D) * 2.4)))), ((V)((12D + (ToNum(i_2215) * 1.4)))), ((V)(5.2)));
f_2192.S("<circle cx=\"").V(Call(f1_20, V.Undef, GetIdx(s_2217, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(s_2217, 1D))).S("\" r=\"").V(Call(f1_20, V.Undef, ((V)((0.45 * ToNum(k_2186)))))).S("\" fill=\"#ffffff\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;1;0;0\" dur=\"2.6s\" begin=\"").N(((-ToNum(i_2215)) * 0.85)).S("s\" repeatCount=\"indefinite\"/></circle>");
return default;
}, 1, "", true));
return NewObj(3).Put("defs", ((V)("<linearGradient id=\"q26bm\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#9fe6ff\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#9fe6ff\" stop-opacity=\"0\"/></linearGradient>"))).Put("under", ((V)(""))).Put("front", ((V)(f_2192.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
fruitDecor_83 = Fn((V _arrowThis2230, int _argc2218, V D_2224, V f_2225, V R_2226, V n_2227, V[] _rest2219) => {
V r0_2228 = default;
V r1_2229 = default;
r0_2228 = (_argc2218 > 4 ? _rest2219[0] : V.Undef);
r1_2229 = (_argc2218 > 5 ? _rest2219[1] : V.Undef);
return Call(rep_35, V.Undef, n_2227, Fn((V _arrowThis2237, int _argc2231, V _a2233, V _a2234, V _a2235, V _a2236, V[] _rest2232) => {
V p0_2238 = default;
V n0_2239 = default;
{ V _t2240 = Call(f_2225, V.Undef, Arr(((V)(((ToNum(Call(R_2226, V.Undef)) - 0.5) * 2D))), ((V)(((ToNum(Call(R_2226, V.Undef)) - 0.2) * 2D))), ((V)(((ToNum(Call(R_2226, V.Undef)) - 0.5) * 2D)))));
{ V _t2241 = ListOf(_t2240);
{ V _t2242 = GetIdx(_t2241, 0D);
p0_2238 = _t2242; }
{ V _t2243 = GetIdx(_t2241, 1D);
n0_2239 = _t2243; }
} }
Call(spot_28, V.Undef, D_2224, p0_2238, n0_2239, Add(r0_2228, ((V)((ToNum(Call(R_2226, V.Undef)) * (ToNum(r1_2229) - ToNum(r0_2228)))))), ((V)((ToNum(Add(r0_2228, ((V)((ToNum(Call(R_2226, V.Undef)) * (ToNum(r1_2229) - ToNum(r0_2228))))))) * 0.8))), ((V)((ToNum(Call(R_2226, V.Undef)) * 3D))), ((V)(5D)));
return default;
}, 0, "", true));
}, 6, "", true);
leaf_84 = Fn((V _arrowThis2256, int _argc2244, V c_2250, V d_2251, V sd_2252, V L_2253, V[] _rest2245) => {
V n_2257 = default;
V Q_2258 = default;
V A_2259 = default;
V B2_2260 = default;
V V_2261 = default;
V W_2254 = default;
V col_2255 = default;
W_2254 = (_argc2244 > 4 ? _rest2245[0] : V.Undef);
col_2255 = (_argc2244 > 5 ? _rest2245[1] : V.Undef);
n_2257 = Call(nz_57, V.Undef, Call(cr_56, V.Undef, d_2251, sd_2252));
Q_2258 = Invoke(Call(rep_35, V.Undef, ((V)(14D)), Fn((V _arrowThis2278, int _argc2271, V i_2277, V _a2274, V _a2275, V _a2276, V[] _rest2272) => {
double t_2279 = 0;
t_2279 = (ToNum(i_2277) / 13D);
return Call(add_53, V.Undef, c_2250, Call(add_53, V.Undef, Call(mul_55, V.Undef, d_2251, ((V)((ToNum(L_2253) * t_2279)))), Call(mul_55, V.Undef, sd_2252, ((V)(((ToNum(W_2254) * FdLibm.Sin((t_2279 * PI_22))) * (0.9 + (0.1 * FdLibm.Sin((t_2279 * 9D))))))))));
return default;
}, 1, "", true)), "concat", Call(rep_35, V.Undef, ((V)(12D)), Fn((V _arrowThis2269, int _argc2262, V i_2268, V _a2265, V _a2266, V _a2267, V[] _rest2263) => {
double t_2270 = 0;
t_2270 = (1D - (ToNum(Add(i_2268, ((V)(1D)))) / 13D));
return Call(add_53, V.Undef, c_2250, Call(add_53, V.Undef, Call(mul_55, V.Undef, d_2251, ((V)((ToNum(L_2253) * t_2270)))), Call(mul_55, V.Undef, sd_2252, ((V)(((-ToNum(W_2254)) * FdLibm.Sin((t_2270 * PI_22))))))));
return default;
}, 1, "", true)));
A_2259 = Call(dec_27, V.Undef, col_2255);
B2_2260 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, col_2255, ((V)(0.8))));
V_2261 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, col_2255, ((V)("#ffffff")), ((V)(0.35))), NewObj(1).Put("op", ((V)(0.7))).V);
Invoke(A_2259, "poly", Q_2258, n_2257);
Invoke(B2_2260, "poly", Invoke(Invoke(Q_2258, "slice"), "reverse"), Call(mul_55, V.Undef, n_2257, ((V)((-1D)))));
Invoke(V_2261, "line", Arr(c_2250, Call(add_53, V.Undef, c_2250, Call(mul_55, V.Undef, d_2251, ((V)((ToNum(L_2253) * 0.92)))))), n_2257, ((V)(Max(0.1, (ToNum(W_2254) * 0.12)))));
Call(rep_35, V.Undef, ((V)(3D)), Fn((V _arrowThis2287, int _argc2280, V i_2286, V _a2283, V _a2284, V _a2285, V[] _rest2281) => {
double t_2288 = 0;
V b_2289 = default;
t_2288 = (0.25 + (ToNum(i_2286) * 0.22));
b_2289 = Call(add_53, V.Undef, c_2250, Call(mul_55, V.Undef, d_2251, ((V)((ToNum(L_2253) * t_2288)))));
Invoke(V_2261, "line", Arr(b_2289, Call(add_53, V.Undef, b_2289, Call(add_53, V.Undef, Call(mul_55, V.Undef, d_2251, ((V)((ToNum(L_2253) * 0.12)))), Call(mul_55, V.Undef, sd_2252, ((V)((ToNum(W_2254) * 0.6))))))), n_2257, ((V)(0.08)));
Invoke(V_2261, "line", Arr(b_2289, Call(add_53, V.Undef, b_2289, Call(add_53, V.Undef, Call(mul_55, V.Undef, d_2251, ((V)((ToNum(L_2253) * 0.12)))), Call(mul_55, V.Undef, sd_2252, ((V)(((-ToNum(W_2254)) * 0.6))))))), n_2257, ((V)(0.08)));
return default;
}, 1, "", true));
return Arr(A_2259, B2_2260, V_2261);
return default;
}, 6, "", true);
mkFruit_85 = Fn((V _arrowThis2304, int _argc2290, V o_2296, V on_2297, V R_2298, V kind_2299, V[] _rest2291) => {
V x_2300 = default;
V y0_2301 = default;
V z_2302 = default;
V r_2303 = default;
x_2300 = (_argc2290 > 4 ? _rest2291[0] : V.Undef);
y0_2301 = (_argc2290 > 5 ? _rest2291[1] : V.Undef);
z_2302 = (_argc2290 > 6 ? _rest2291[2] : V.Undef);
r_2303 = (_argc2290 > 7 ? _rest2291[3] : V.Undef);
if (SEqS(kind_2299, "apple")) {
double sy_2305 = 0;
V A_2306 = default;
V c_2307 = default;
V f_2308 = default;
V ST_2309 = default;
V LT_2310 = default;
V HL_2311 = default;
V DP_2312 = default;
V sT_2313 = default;
sy_2305 = 0.9;
A_2306 = Call(ball_12, V.Undef, x_2300, y0_2301, z_2302, r_2303, ((V)("#c42f2c")), NewObj(4).Put("sy", ((V)(sy_2305))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).Put("mat", ((V)("pl"))).V);
c_2307 = Arr(x_2300, Add(y0_2301, ((V)((ToNum(r_2303) * sy_2305)))), z_2302);
f_2308 = Call(eS_64, V.Undef, c_2307, r_2303, ((V)((ToNum(r_2303) * sy_2305))), r_2303);
ST_2309 = Call(dec_27, V.Undef, ((V)("#f0b040")), NewObj(1).Put("op", ((V)(0.35))).V);
LT_2310 = Call(dec_27, V.Undef, ((V)("#ffe8b0")), NewObj(1).Put("op", ((V)(0.7))).V);
HL_2311 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.5))).V);
DP_2312 = Call(dec_27, V.Undef, ((V)("#6a1a14")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(o_2296, "push", A_2306);
Call(rep_35, V.Undef, ((V)(12D)), Fn((V _arrowThis2321, int _argc2314, V i_2320, V _a2317, V _a2318, V _a2319, V[] _rest2315) => {
double a_2322 = 0;
a_2322 = ((((ToNum(i_2320) / 12D) * 2D) * PI_22) + (ToNum(Call(R_2298, V.Undef)) * 0.2));
Call(lineOn_65, V.Undef, ST_2309, Fn((V _arrowThis2330, int _argc2323, V t_2329, V _a2326, V _a2327, V _a2328, V[] _rest2324) => {
return Call(f_2308, V.Undef, Arr(((V)((FdLibm.Cos(a_2322) * FdLibm.Sin((0.25 + (ToNum(t_2329) * 2.4)))))), ((V)(FdLibm.Cos((0.25 + (ToNum(t_2329) * 2.4))))), ((V)((FdLibm.Sin(a_2322) * FdLibm.Sin((0.25 + (ToNum(t_2329) * 2.4))))))));
}, 1, "", true), ((V)(8D)), ((V)(0.35)), ((V)(1D)));
return default;
}, 1, "", true));
Call(fruitDecor_83, V.Undef, LT_2310, f_2308, R_2298, ((V)(14D)), ((V)(0.05)), ((V)(0.08)));
{
V p0_2331 = default;
V n0_2332 = default;
{ V _t2333 = Call(f_2308, V.Undef, Arr(((V)((-0.5))), ((V)(0.65)), ((V)(0.45))));
{ V _t2334 = ListOf(_t2333);
{ V _t2335 = GetIdx(_t2334, 0D);
p0_2331 = _t2335; }
{ V _t2336 = GetIdx(_t2334, 1D);
n0_2332 = _t2336; }
} }
Call(spot_28, V.Undef, HL_2311, p0_2331, n0_2332, ((V)((ToNum(r_2303) * 0.32))), ((V)((ToNum(r_2303) * 0.2))), ((V)(0.6)), ((V)(10D)));
}
Call(spot_28, V.Undef, DP_2312, Arr(x_2300, ((V)((ToNum(Add(GetIdx(c_2307, 1D), ((V)((ToNum(r_2303) * sy_2305))))) - 0.15))), z_2302), Y3_59, ((V)((ToNum(r_2303) * 0.22))), ((V)((ToNum(r_2303) * 0.22))), ((V)(0D)), ((V)(10D)));
sT_2313 = Arr(x_2300, ((V)((ToNum(Add(GetIdx(c_2307, 1D), ((V)((ToNum(r_2303) * sy_2305))))) - 0.2))), z_2302);
Call(on_2297, V.Undef, A_2306, Invoke(Arr(ST_2309, LT_2310, HL_2311, DP_2312, Call(rod_36, V.Undef, sT_2313, Call(add_53, V.Undef, sT_2313, Arr(((V)(0.4)), ((V)(1.8)), ((V)(0.2)))), ((V)(0.16)), ((V)("#5a3a1a")), NewObj(1).Put("n", ((V)(5D))).V)), "concat", Call(leaf_84, V.Undef, Call(add_53, V.Undef, sT_2313, Arr(((V)(0.35)), ((V)(1.3)), ((V)(0.15)))), Call(nz_57, V.Undef, Arr(((V)(0.8)), ((V)(0.35)), ((V)(0.3)))), Call(nz_57, V.Undef, Arr(((V)((-0.3))), ((V)(0D)), ((V)(0.9)))), ((V)(2.6)), ((V)(0.9)), ((V)("#4f8a2e")))));
return A_2306;
}
if (SEqS(kind_2299, "orange")) {
V A_2337 = default;
V c_2338 = default;
V f_2339 = default;
V P1_2340 = default;
V P2_2341 = default;
V HL_2342 = default;
V NV_2343 = default;
V tp_2344 = default;
A_2337 = Call(ball_12, V.Undef, x_2300, y0_2301, z_2302, r_2303, ((V)("#f08a1e")), NewObj(4).Put("sy", ((V)(0.95))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).Put("mat", ((V)("pl"))).V);
c_2338 = Arr(x_2300, Add(y0_2301, ((V)((ToNum(r_2303) * 0.95)))), z_2302);
f_2339 = Call(eS_64, V.Undef, c_2338, r_2303, ((V)((ToNum(r_2303) * 0.95))), r_2303);
P1_2340 = Call(dec_27, V.Undef, ((V)("#d07214")), NewObj(1).Put("op", ((V)(0.3))).V);
P2_2341 = Call(dec_27, V.Undef, ((V)("#ffc070")), NewObj(1).Put("op", ((V)(0.3))).V);
HL_2342 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.45))).V);
NV_2343 = Call(dec_27, V.Undef, ((V)("#6a7a2a")));
Invoke(o_2296, "push", A_2337);
Call(fruitDecor_83, V.Undef, P1_2340, f_2339, R_2298, ((V)(34D)), ((V)(0.05)), ((V)(0.08)));
Call(fruitDecor_83, V.Undef, P2_2341, f_2339, R_2298, ((V)(12D)), ((V)(0.04)), ((V)(0.06)));
{
V p0_2345 = default;
V n0_2346 = default;
{ V _t2347 = Call(f_2339, V.Undef, Arr(((V)((-0.5))), ((V)(0.6)), ((V)(0.5))));
{ V _t2348 = ListOf(_t2347);
{ V _t2349 = GetIdx(_t2348, 0D);
p0_2345 = _t2349; }
{ V _t2350 = GetIdx(_t2348, 1D);
n0_2346 = _t2350; }
} }
Call(spot_28, V.Undef, HL_2342, p0_2345, n0_2346, ((V)((ToNum(r_2303) * 0.3))), ((V)((ToNum(r_2303) * 0.18))), ((V)(0.6)), ((V)(10D)));
}
tp_2344 = Arr(x_2300, Add(Add(GetIdx(c_2338, 1D), ((V)((ToNum(r_2303) * 0.95)))), ((V)(0.02))), z_2302);
Invoke(NV_2343, "poly", Call(rep_35, V.Undef, ((V)(10D)), Fn((V _arrowThis2358, int _argc2351, V i_2357, V _a2354, V _a2355, V _a2356, V[] _rest2352) => {
double a_2359 = 0;
double rr_2360 = 0;
a_2359 = (((ToNum(i_2357) / 10D) * 2D) * PI_22);
rr_2360 = (NumTruthy((ToNum(i_2357) % 2D)) ? 0.25 : 0.6);
return Call(add_53, V.Undef, tp_2344, Arr(((V)((FdLibm.Cos(a_2359) * rr_2360))), ((V)(0D)), ((V)((FdLibm.Sin(a_2359) * rr_2360)))));
return default;
}, 1, "", true)), Y3_59);
Call(on_2297, V.Undef, A_2337, Arr(P1_2340, P2_2341, HL_2342, NV_2343));
return A_2337;
}
if (SEqS(kind_2299, "lemon")) {
V A_2361 = default;
V c_2362 = default;
V f_2363 = default;
V P1_2364 = default;
V HL_2365 = default;
A_2361 = Call(ball_12, V.Undef, x_2300, y0_2301, z_2302, r_2303, ((V)("#f4d43a")), NewObj(5).Put("sy", ((V)(0.88))).Put("sz", ((V)(1.22))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).Put("mat", ((V)("pl"))).V);
c_2362 = Arr(x_2300, Add(y0_2301, ((V)((ToNum(r_2303) * 0.88)))), z_2302);
f_2363 = Call(eS_64, V.Undef, c_2362, r_2303, ((V)((ToNum(r_2303) * 0.88))), ((V)((ToNum(r_2303) * 1.22))));
P1_2364 = Call(dec_27, V.Undef, ((V)("#d8b020")), NewObj(1).Put("op", ((V)(0.3))).V);
HL_2365 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(o_2296, "push", A_2361);
Call(fruitDecor_83, V.Undef, P1_2364, f_2363, R_2298, ((V)(26D)), ((V)(0.04)), ((V)(0.07)));
{
V p0_2366 = default;
V n0_2367 = default;
{ V _t2368 = Call(f_2363, V.Undef, Arr(((V)((-0.5))), ((V)(0.65)), ((V)(0.4))));
{ V _t2369 = ListOf(_t2368);
{ V _t2370 = GetIdx(_t2369, 0D);
p0_2366 = _t2370; }
{ V _t2371 = GetIdx(_t2369, 1D);
n0_2367 = _t2371; }
} }
Call(spot_28, V.Undef, HL_2365, p0_2366, n0_2367, ((V)((ToNum(r_2303) * 0.3))), ((V)((ToNum(r_2303) * 0.2))), ((V)(0.3)), ((V)(10D)));
}
Call(on_2297, V.Undef, A_2361, Arr(P1_2364, HL_2365, Call(ball_12, V.Undef, x_2300, ((V)((ToNum(GetIdx(c_2362, 1D)) - 0.6))), Add(z_2302, ((V)((ToNum(r_2303) * 1.18)))), ((V)(0.75)), ((V)("#e8c42a")), NewObj(5).Put("sz", ((V)(1.3))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("mat", ((V)("pl"))).Put("noOut", ((V)(1D))).V), Call(ball_12, V.Undef, x_2300, ((V)((ToNum(GetIdx(c_2362, 1D)) - 0.6))), ((V)((ToNum(z_2302) - (ToNum(r_2303) * 1.18)))), ((V)(0.7)), ((V)("#e8c42a")), NewObj(5).Put("sz", ((V)(1.3))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("mat", ((V)("pl"))).Put("noOut", ((V)(1D))).V)));
return A_2361;
}
if (SEqS(kind_2299, "pear")) {
V A_2372 = default;
V c_2373 = default;
V f_2374 = default;
V SPk_2375 = default;
V BLs_2376 = default;
V HL_2377 = default;
V T_2378 = default;
V tc_2379 = default;
V ft_2380 = default;
V sT_2381 = default;
A_2372 = Call(ball_12, V.Undef, x_2300, y0_2301, z_2302, r_2303, ((V)("#a8c84a")), NewObj(4).Put("sy", ((V)(0.92))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).Put("mat", ((V)("pl"))).V);
c_2373 = Arr(x_2300, Add(y0_2301, ((V)((ToNum(r_2303) * 0.92)))), z_2302);
f_2374 = Call(eS_64, V.Undef, c_2373, r_2303, ((V)((ToNum(r_2303) * 0.92))), r_2303);
SPk_2375 = Call(dec_27, V.Undef, ((V)("#7a5a2a")), NewObj(1).Put("op", ((V)(0.35))).V);
BLs_2376 = Call(dec_27, V.Undef, ((V)("#d8603a")), NewObj(1).Put("op", ((V)(0.3))).V);
HL_2377 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.45))).V);
Invoke(o_2296, "push", A_2372);
T_2378 = Call(ball_12, V.Undef, ((V)((ToNum(x_2300) - 0.2))), Add(y0_2301, ((V)((ToNum(r_2303) * 1.35)))), Add(z_2302, ((V)(0.1))), ((V)((ToNum(r_2303) * 0.62))), ((V)("#b2cc52")), NewObj(3).Put("k", ((V)(5D))).Put("n", ((V)(14D))).Put("mat", ((V)("pl"))).V);
tc_2379 = Arr(((V)((ToNum(x_2300) - 0.2))), Add(Add(y0_2301, ((V)((ToNum(r_2303) * 1.35)))), ((V)((ToNum(r_2303) * 0.62)))), Add(z_2302, ((V)(0.1))));
ft_2380 = Call(eS_64, V.Undef, tc_2379, ((V)((ToNum(r_2303) * 0.62))), ((V)((ToNum(r_2303) * 0.62))), ((V)((ToNum(r_2303) * 0.62))));
Call(fruitDecor_83, V.Undef, SPk_2375, f_2374, R_2298, ((V)(14D)), ((V)(0.04)), ((V)(0.07)));
Call(fruitDecor_83, V.Undef, SPk_2375, ft_2380, R_2298, ((V)(6D)), ((V)(0.04)), ((V)(0.06)));
{
V p0_2382 = default;
V n0_2383 = default;
V p1_2384 = default;
V n1_2385 = default;
{ V _t2386 = Call(f_2374, V.Undef, Arr(((V)(0.6)), ((V)(0.3)), ((V)(0.7))));
{ V _t2387 = ListOf(_t2386);
{ V _t2388 = GetIdx(_t2387, 0D);
p0_2382 = _t2388; }
{ V _t2389 = GetIdx(_t2387, 1D);
n0_2383 = _t2389; }
} }
Call(spot_28, V.Undef, BLs_2376, p0_2382, n0_2383, ((V)((ToNum(r_2303) * 0.5))), ((V)((ToNum(r_2303) * 0.4))), ((V)(0.4)), ((V)(12D)));
{ V _t2390 = Call(f_2374, V.Undef, Arr(((V)((-0.6))), ((V)(0.5)), ((V)(0.5))));
{ V _t2391 = ListOf(_t2390);
{ V _t2392 = GetIdx(_t2391, 0D);
p1_2384 = _t2392; }
{ V _t2393 = GetIdx(_t2391, 1D);
n1_2385 = _t2393; }
} }
Call(spot_28, V.Undef, HL_2377, p1_2384, n1_2385, ((V)((ToNum(r_2303) * 0.28))), ((V)((ToNum(r_2303) * 0.18))), ((V)(0.6)), ((V)(10D)));
}
sT_2381 = Arr(GetIdx(tc_2379, 0D), Add(GetIdx(tc_2379, 1D), ((V)((ToNum(r_2303) * 0.6)))), GetIdx(tc_2379, 2D));
Call(on_2297, V.Undef, A_2372, Arr(SPk_2375, BLs_2376, HL_2377, T_2378));
Call(on_2297, V.Undef, T_2378, Arr(Call(rod_36, V.Undef, sT_2381, Call(add_53, V.Undef, sT_2381, Arr(((V)((-0.5))), ((V)(1.8)), ((V)(0D)))), ((V)(0.17)), ((V)("#5a3a1a")), NewObj(1).Put("n", ((V)(5D))).V)));
return A_2372;
}
return V.Null;
return default;
}, 8, "", true);
Set(N_21, "live26", Fn((V _arrowThis2401, int _argc2394, V S_2400, V _a2397, V _a2398, V _a2399, V[] _rest2395) => {
V B_2402 = default;
V D_2403 = default;
B_2402 = Invoke(N_21, "live24", S_2400);
D_2403 = Object_assign(NewObj(0).V, B_2402);
Set(D_2403, "build", Fn((V _arrowThis2411, int _argc2404, V _a2406, V _a2407, V _a2408, V _a2409, V[] _rest2405) => {
V o_2412 = default;
V on_2413 = default;
V R_2414 = default;
double TY_2415 = 0;
double YT_2416 = 0;
double yb_2417 = 0;
V SW_2418 = default;
V HW_2419 = default;
V a_2410 = default;
a_2410 = RestArgs(0, _argc2404, _a2406, _a2407, _a2408, _a2409, _rest2405);
o_2412 = InvokeSpread(B_2402, "build", new ArrBuilder().Spread(a_2410).V);
on_2413 = Call(glue_33, V.Undef, o_2412);
R_2414 = Call(R0_34, V.Undef, ((V)("live26")));
TY_2415 = 26.4;
YT_2416 = (TY_2415 + 4D);
Call(drop_62, V.Undef, o_2412, Fn((V _arrowThis2427, int _argc2420, V S0_2426, V _a2423, V _a2424, V _a2425, V[] _rest2421) => {
return ((Invoke(Arr(((V)("#5f9a4a")), ((V)("#7fb25a")), ((V)("#4f8a3e"))), "includes", Get(S0_2426, "col")) is var _t2428 && !Truthy(_t2428) ? _t2428 : (!(Truthy(Get(S0_2426, "par"))) ? V.True : V.False)) is var _t2429 && !Truthy(_t2429) ? _t2429 : (!(Truthy(Get(S0_2426, "emit"))) ? V.True : V.False));
}, 1, "", true));
{
V BWl_2430 = default;
BWl_2430 = Invoke(o_2412, "find", Fn((V _arrowThis2438, int _argc2431, V S0_2437, V _a2434, V _a2435, V _a2436, V[] _rest2432) => {
return ((SEqS(Get(S0_2437, "col"), "#8a5a34") && !(Truthy(Get(S0_2437, "par")))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(BWl_2430)) {
V fam_2439 = default;
double g2_2440 = 0;
fam_2439 = New(G("Set"), Arr(BWl_2430));
g2_2440 = 1D;
while (NumTruthy(g2_2440)) {
g2_2440 = 0D;
Invoke(o_2412, "forEach", Fn((V _arrowThis2448, int _argc2441, V S0_2447, V _a2444, V _a2445, V _a2446, V[] _rest2442) => {
if (Truthy(((Get(S0_2447, "par") is var _t2449 && !Truthy(_t2449) ? _t2449 : Invoke(fam_2439, "has", Get(S0_2447, "par"))) is var _t2450 && !Truthy(_t2450) ? _t2450 : (!(Truthy(Invoke(fam_2439, "has", S0_2447))) ? V.True : V.False)))) {
Invoke(fam_2439, "add", S0_2447);
g2_2440 = 1D;
}
return default;
}, 1, "", true));
}
Invoke(fam_2439, "forEach", Fn((V _arrowThis2458, int _argc2451, V S0_2457, V _a2454, V _a2455, V _a2456, V[] _rest2452) => {
return Call(mvPts_61, V.Undef, S0_2457, Fn((V _arrowThis2466, int _argc2459, V p_2465, V _a2462, V _a2463, V _a2464, V[] _rest2460) => {
return Arr(((V)((26D + ((ToNum(GetIdx(p_2465, 0D)) - 26D) * 1.22)))), GetIdx(p_2465, 1D), ((V)(((-4D) + (ToNum(Add(GetIdx(p_2465, 2D), ((V)(4D)))) * 1.22)))));
}, 1, "", true));
}, 1, "", true));
}
}
yb_2417 = (TY_2415 + 8.4);
Invoke(Arr(Arr(((V)("apple")), ((V)(22.6)), ((V)((-7.4)))), Arr(((V)("orange")), ((V)(29.4)), ((V)((-7.4)))), Arr(((V)("pear")), ((V)(22.6)), ((V)((-0.6)))), Arr(((V)("lemon")), ((V)(29.4)), ((V)((-0.6))))), "forEach", Fn((V _arrowThis2480, int _argc2467, V _a2469, V _a2470, V _a2471, V _a2472, V[] _rest2468) => {
V kd_2475 = default;
V x_2477 = default;
V z_2479 = default;
{ V _t2473 = ListOf(_a2469);
{ V _t2474 = GetIdx(_t2473, 0D);
kd_2475 = _t2474; }
{ V _t2476 = GetIdx(_t2473, 1D);
x_2477 = _t2476; }
{ V _t2478 = GetIdx(_t2473, 2D);
z_2479 = _t2478; }
}
return Call(mkFruit_85, V.Undef, o_2412, on_2413, R_2414, kd_2475, x_2477, ((V)(yb_2417)), z_2479, ((V)((SEqS(kd_2475, "lemon") ? 2.75 : 3.3))));
}, 1, "", true));
Call(rep_35, V.Undef, ((V)(2D)), Fn((V _arrowThis2488, int _argc2481, V j_2487, V _a2484, V _a2485, V _a2486, V[] _rest2482) => {
double yc_2489 = 0;
double zc_2490 = 0;
double xc_2491 = 0;
double rB_2492 = 0;
V BN_2493 = default;
V cb_2494 = default;
V L_2495 = default;
V xe_2496 = default;
V RGl_2497 = default;
V RGh_2498 = default;
V SPk_2499 = default;
yc_2489 = ((TY_2415 + 15.4) + (ToNum(j_2487) * 0.15));
zc_2490 = ((-4.6) + (ToNum(j_2487) * 0.25));
xc_2491 = (26D + (ToNum(j_2487) * 0.8));
rB_2492 = (1.3 - (ToNum(j_2487) * 0.08));
BN_2493 = Call(ball_12, V.Undef, ((V)(xc_2491)), ((V)(yc_2489)), ((V)(zc_2490)), ((V)(rB_2492)), ((V)((Truthy(j_2487) ? "#f2cf3e" : "#f6d84e"))), NewObj(6).Put("sx", ((V)(4.3))).Put("sy", ((V)(0.92))).Put("k", ((V)(5D))).Put("n", ((V)(14D))).Put("mat", ((V)("pl"))).Put("shine", ((V)(1D))).V);
cb_2494 = Fn((V _arrowThis2507, int _argc2500, V x_2506, V _a2503, V _a2504, V _a2505, V[] _rest2501) => {
return ((V)(((ToNum(x_2506) - xc_2491) * (ToNum(x_2506) - xc_2491))));
}, 1, "", true);
Call(mvPts_61, V.Undef, BN_2493, Fn((V _arrowThis2515, int _argc2508, V p_2514, V _a2511, V _a2512, V _a2513, V[] _rest2509) => {
return Arr(GetIdx(p_2514, 0D), Add(GetIdx(p_2514, 1D), ((V)((ToNum(Call(cb_2494, V.Undef, GetIdx(p_2514, 0D))) * 0.045)))), Add(GetIdx(p_2514, 2D), ((V)((ToNum(Call(cb_2494, V.Undef, GetIdx(p_2514, 0D))) * 0.02)))));
}, 1, "", true));
Invoke(o_2412, "push", BN_2493);
L_2495 = Call(bbS_52, V.Undef, BN_2493);
xe_2496 = Arr(Add(GetIdx(L_2495, 0D), ((V)(0.5))), ((V)((ToNum(GetIdx(L_2495, 1D)) - 0.5))));
RGl_2497 = Call(dec_27, V.Undef, ((V)("#c8a028")), NewObj(1).Put("op", ((V)(0.55))).V);
RGh_2498 = Call(dec_27, V.Undef, ((V)("#fff4b0")), NewObj(1).Put("op", ((V)(0.6))).V);
SPk_2499 = Call(dec_27, V.Undef, ((V)("#7a5a20")), NewObj(1).Put("op", ((V)(0.45))).V);
Invoke(RGl_2497, "line", Call(rep_35, V.Undef, ((V)(13D)), Fn((V _arrowThis2523, int _argc2516, V i_2522, V _a2519, V _a2520, V _a2521, V[] _rest2517) => {
V x_2524 = default;
x_2524 = Add(GetIdx(xe_2496, 0D), ((V)((((ToNum(GetIdx(xe_2496, 1D)) - ToNum(GetIdx(xe_2496, 0D))) * ToNum(i_2522)) / 12D))));
return Arr(x_2524, ((V)(((yc_2489 + (rB_2492 * 1.82)) + (ToNum(Call(cb_2494, V.Undef, x_2524)) * 0.045)))), ((V)(((zc_2490 + (ToNum(Call(cb_2494, V.Undef, x_2524)) * 0.02)) + 0.15))));
return default;
}, 1, "", true)), Call(nz_57, V.Undef, Arr(((V)(0D)), ((V)(1D)), ((V)(0.3)))), ((V)(0.18)));
Invoke(RGh_2498, "line", Call(rep_35, V.Undef, ((V)(13D)), Fn((V _arrowThis2532, int _argc2525, V i_2531, V _a2528, V _a2529, V _a2530, V[] _rest2526) => {
V x_2533 = default;
x_2533 = Add(Add(GetIdx(xe_2496, 0D), ((V)(1D))), ((V)(((((ToNum(GetIdx(xe_2496, 1D)) - ToNum(GetIdx(xe_2496, 0D))) - 2D) * ToNum(i_2531)) / 12D))));
return Arr(x_2533, ((V)(((yc_2489 + (rB_2492 * 1.6)) + (ToNum(Call(cb_2494, V.Undef, x_2533)) * 0.045)))), ((V)(((zc_2490 + (ToNum(Call(cb_2494, V.Undef, x_2533)) * 0.02)) + (rB_2492 * 0.6)))));
return default;
}, 1, "", true)), Call(nz_57, V.Undef, Arr(((V)(0D)), ((V)(0.6)), ((V)(1D)))), ((V)(0.3)));
Call(rep_35, V.Undef, ((V)(5D)), Fn((V _arrowThis2541, int _argc2534, V i_2540, V _a2537, V _a2538, V _a2539, V[] _rest2535) => {
double x_2542 = 0;
x_2542 = ((xc_2491 - 3.5) + (ToNum(i_2540) * 1.8));
Call(spot_28, V.Undef, SPk_2499, Arr(((V)(x_2542)), ((V)(((yc_2489 + (rB_2492 * 1.4)) + (ToNum(Call(cb_2494, V.Undef, ((V)(x_2542)))) * 0.045)))), ((V)(((zc_2490 + (ToNum(Call(cb_2494, V.Undef, ((V)(x_2542)))) * 0.02)) + (rB_2492 * 0.75))))), Call(nz_57, V.Undef, Arr(((V)(0D)), ((V)(0.5)), ((V)(1D)))), ((V)(0.18)), ((V)(0.12)), ((V)(0D)), ((V)(5D)));
return default;
}, 1, "", true));
Call(on_2413, V.Undef, BN_2493, Arr(RGl_2497, RGh_2498, SPk_2499, Call(ball_12, V.Undef, Add(GetIdx(L_2495, 0D), ((V)(0.2))), ((V)((((yc_2489 + (rB_2492 * 0.7)) + (ToNum(Call(cb_2494, V.Undef, GetIdx(L_2495, 0D))) * 0.045)) - 0.4))), ((V)((zc_2490 + (ToNum(Call(cb_2494, V.Undef, GetIdx(L_2495, 0D))) * 0.02)))), ((V)(0.5)), ((V)("#4a3014")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V), Call(ball_12, V.Undef, ((V)((ToNum(GetIdx(L_2495, 1D)) - 0.3))), ((V)((((yc_2489 + (rB_2492 * 0.7)) + (ToNum(Call(cb_2494, V.Undef, GetIdx(L_2495, 1D))) * 0.045)) - 0.2))), ((V)((zc_2490 + (ToNum(Call(cb_2494, V.Undef, GetIdx(L_2495, 1D))) * 0.02)))), ((V)(0.45)), ((V)("#6a4a1a")), NewObj(3).Put("sx", ((V)(1.6))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V)));
return default;
}, 1, "", true));
Invoke(o_2412, "forEach", Fn((V _arrowThis2550, int _argc2543, V S0_2549, V _a2546, V _a2547, V _a2548, V[] _rest2544) => {
if (Truthy(((((SEqN(Get(S0_2549, "cv"), 0D) ? V.True : V.False) is var _t2551 && !Truthy(_t2551) ? _t2551 : Get(S0_2549, "noOut")) is var _t2552 && !Truthy(_t2552) ? _t2552 : ((SEqS(Get(S0_2549, "col"), "#3a1f0e") || SEqS(Get(S0_2549, "col"), "#a06a3c")) ? V.True : V.False)) is var _t2553 && !Truthy(_t2553) ? _t2553 : (GeN(Get(S0_2549, "op"), 0.45) ? V.True : V.False)))) {
Set(S0_2549, "op", ((V)(0.3)));
}
return default;
}, 1, "", true));
SW_2418 = Call(at_31, V.Undef, o_2412, Arr(((V)(40D)), ((V)((TY_2415 + 1.5))), ((V)(0D))), ((V)("#d9b07c")));
HW_2419 = (SW_2418 is var _t2562 && !Truthy(_t2562) ? _t2562 : Invoke(o_2412, "find", Fn((V _arrowThis2561, int _argc2554, V S0_2560, V _a2557, V _a2558, V _a2559, V[] _rest2555) => {
return ((SEqS(Get(S0_2560, "col"), "#6e4226") && SEq(Get(S0_2560, "par"), SW_2418)) ? V.True : V.False);
}, 1, "", true)));
if (Truthy(HW_2419)) {
V PO_2563 = default;
V RF_2564 = default;
V WH_2565 = default;
V inside_2566 = default;
V ED_2567 = default;
V EL_2568 = default;
PO_2563 = Call(dec_27, V.Undef, ((V)("#3a1f0e")), NewObj(1).Put("op", ((V)(0.28))).V);
RF_2564 = Call(dec_27, V.Undef, ((V)("#c08a58")), NewObj(1).Put("op", ((V)(0.35))).V);
WH_2565 = Call(dec_27, V.Undef, ((V)("#1a0c04")), NewObj(1).Put("op", ((V)(0.85))).V);
inside_2566 = Fn((V _arrowThis2577, int _argc2569, V x_2575, V z_2576, V _a2573, V _a2574, V[] _rest2570) => {
return (((Pow((System.Math.Abs(ToNum(x_2575)) / 52D), 3D) + Pow((System.Math.Abs(ToNum(z_2576)) / 22D), 2D)) < 1D) ? V.True : V.False);
}, 2, "", true);
Call(rep_35, V.Undef, ((V)(160D)), Fn((V _arrowThis2584, int _argc2578, V _a2580, V _a2581, V _a2582, V _a2583, V[] _rest2579) => {
double x_2585 = 0;
double z_2586 = 0;
x_2585 = ((ToNum(Call(R_2414, V.Undef)) - 0.5) * 104D);
z_2586 = ((ToNum(Call(R_2414, V.Undef)) - 0.5) * 44D);
if (!(Truthy(Call(inside_2566, V.Undef, ((V)(x_2585)), ((V)(z_2586)))))) {
return default;
}
Invoke(PO_2563, "line", Arr(Arr(((V)(x_2585)), ((V)(YT_2416)), ((V)(z_2586))), Arr(((V)(((x_2585 + 0.5) + (ToNum(Call(R_2414, V.Undef)) * 0.8)))), ((V)(YT_2416)), ((V)((z_2586 + ((ToNum(Call(R_2414, V.Undef)) - 0.5) * 0.1)))))), Y3_59, ((V)(0.07)));
return default;
}, 0, "", true));
Call(rep_35, V.Undef, ((V)(26D)), Fn((V _arrowThis2593, int _argc2587, V _a2589, V _a2590, V _a2591, V _a2592, V[] _rest2588) => {
double x_2594 = 0;
double z_2595 = 0;
x_2594 = ((ToNum(Call(R_2414, V.Undef)) - 0.5) * 96D);
z_2595 = ((ToNum(Call(R_2414, V.Undef)) - 0.5) * 40D);
if (!(Truthy(Call(inside_2566, V.Undef, ((V)(x_2594)), ((V)(z_2595)))))) {
return default;
}
Call(spot_28, V.Undef, RF_2564, Arr(((V)(x_2594)), ((V)(YT_2416)), ((V)(z_2595))), Y3_59, ((V)((0.9 + (ToNum(Call(R_2414, V.Undef)) * 1.2)))), ((V)(0.18)), ((V)(0.05)), ((V)(6D)));
return default;
}, 0, "", true));
Invoke(Arr(Arr(((V)((-26D))), ((V)(12D))), Arr(((V)(38D)), ((V)((-14D)))), Arr(((V)(8D)), ((V)(16D)))), "forEach", Fn((V _arrowThis2607, int _argc2596, V _a2598, V _a2599, V _a2600, V _a2601, V[] _rest2597) => {
V x_2604 = default;
V z_2606 = default;
{ V _t2602 = ListOf(_a2598);
{ V _t2603 = GetIdx(_t2602, 0D);
x_2604 = _t2603; }
{ V _t2605 = GetIdx(_t2602, 1D);
z_2606 = _t2605; }
}
return Call(spot_28, V.Undef, WH_2565, Arr(x_2604, ((V)(YT_2416)), z_2606), Y3_59, ((V)(0.32)), ((V)(0.28)), ((V)(0D)), ((V)(6D)));
}, 1, "", true));
Call(on_2413, V.Undef, HW_2419, Arr(RF_2564, PO_2563, WH_2565));
ED_2567 = Call(dec_27, V.Undef, ((V)("#3a1f0e")), NewObj(1).Put("op", ((V)(0.45))).V);
EL_2568 = Call(dec_27, V.Undef, ((V)("#a87448")), NewObj(1).Put("op", ((V)(0.4))).V);
Invoke(Get(HW_2419, "faces"), "forEach", Fn((V _arrowThis2615, int _argc2608, V F_2614, V _a2611, V _a2612, V _a2613, V[] _rest2609) => {
if ((System.Math.Abs(ToNum(GetIdx(Get(F_2614, "n"), 1D))) < 0.3)) {
Call(hatch_46, V.Undef, Arr(ED_2567, EL_2568), F_2614, ((V)(0D)), ((V)(0.42)), ((V)(0.1)), NewObj(1).Put("sh", ((V)(0.98))).V);
}
return default;
}, 1, "", true));
Call(on_2413, V.Undef, HW_2419, Arr(ED_2567, EL_2568));
}
if (Truthy(SW_2418)) {
V SD_2616 = default;
V SL_2617 = default;
SD_2616 = Call(dec_27, V.Undef, ((V)("#a87a48")), NewObj(1).Put("op", ((V)(0.5))).V);
SL_2617 = Call(dec_27, V.Undef, ((V)("#f4dcb0")), NewObj(1).Put("op", ((V)(0.45))).V);
Invoke(Get(SW_2418, "faces"), "forEach", Fn((V _arrowThis2625, int _argc2618, V F_2624, V _a2621, V _a2622, V _a2623, V[] _rest2619) => {
if ((System.Math.Abs(ToNum(GetIdx(Get(F_2624, "n"), 1D))) < 0.3)) {
Call(hatch_46, V.Undef, SD_2616, F_2624, ((V)(0D)), ((V)(0.7)), ((V)(0.12)), NewObj(1).Put("sh", ((V)(0.98))).V);
Call(hatch_46, V.Undef, SL_2617, F_2624, ((V)(((PI_22 / 2D) + 0.2))), ((V)(2.6)), ((V)(0.1)), NewObj(2).Put("sh", ((V)(0.95))).Put("ph", ((V)(1.1))).V);
}
return default;
}, 1, "", true));
Call(on_2413, V.Undef, SW_2418, Arr(SD_2616, SL_2617));
}
Invoke(Invoke(o_2412, "filter", Fn((V _arrowThis2668, int _argc2661, V S0_2667, V _a2664, V _a2665, V _a2666, V[] _rest2662) => {
return (((SEqS(Get(S0_2667, "col"), "#232428") && !(Truthy(Get(S0_2667, "par")))) ? V.True : V.False) is var _t2669 && !Truthy(_t2669) ? _t2669 : Get(S0_2667, "pts"));
}, 1, "", true)), "forEach", Fn((V _arrowThis2633, int _argc2626, V S0_2632, V _a2629, V _a2630, V _a2631, V[] _rest2627) => {
V BRu_2634 = default;
V WLd_2635 = default;
V L_2636 = default;
BRu_2634 = Call(dec_27, V.Undef, ((V)("#6a6d74")), NewObj(1).Put("op", ((V)(0.45))).V);
WLd_2635 = Call(dec_27, V.Undef, ((V)("#4a4c52")), NewObj(1).Put("op", ((V)(0.85))).V);
L_2636 = Call(bbS_52, V.Undef, S0_2632);
Invoke(Call(sides_51, V.Undef, S0_2632, ((V)(1D))), "forEach", Fn((V _arrowThis2644, int _argc2637, V F_2643, V _a2640, V _a2641, V _a2642, V[] _rest2638) => {
if ((System.Math.Abs(ToNum(GetIdx(Get(F_2643, "n"), 1D))) < 0.4)) {
Call(hatch_46, V.Undef, BRu_2634, F_2643, ((V)((((ToNum(GetIdx(L_2636, 3D)) - ToNum(GetIdx(L_2636, 2D))) > 10D) ? (PI_22 / 2D) : 0D))), ((V)(0.7)), ((V)(0.08)), NewObj(1).Put("sh", ((V)(0.96))).V);
}
return default;
}, 1, "", true));
if ((((ToNum(GetIdx(L_2636, 3D)) - ToNum(GetIdx(L_2636, 2D))) < 3D) && ((ToNum(GetIdx(L_2636, 5D)) - ToNum(GetIdx(L_2636, 4D))) > 30D))) {
Invoke(Arr(Add(GetIdx(L_2636, 4D), ((V)(1.6))), ((V)((ToNum(GetIdx(L_2636, 5D)) - 1.6)))), "forEach", Fn((V _arrowThis2652, int _argc2645, V z_2651, V _a2648, V _a2649, V _a2650, V[] _rest2646) => {
return Call(rep_35, V.Undef, ((V)(4D)), Fn((V _arrowThis2660, int _argc2653, V i_2659, V _a2656, V _a2657, V _a2658, V[] _rest2654) => {
return Call(spot_28, V.Undef, WLd_2635, Arr(((V)(((ToNum(Add(GetIdx(L_2636, 0D), GetIdx(L_2636, 1D))) / 2D) + 1.55))), Add(Add(GetIdx(L_2636, 2D), ((V)(0.6))), ((V)((ToNum(i_2659) * 0.45)))), z_2651), X3_58, ((V)(0.4)), ((V)(0.3)), ((V)(0D)), ((V)(6D)));
}, 1, "", true));
}, 1, "", true));
}
Call(on_2413, V.Undef, S0_2632, Arr(BRu_2634, WLd_2635));
return default;
}, 1, "", true));
return o_2412;
return default;
}, 1, "", true));
return D_2403;
return default;
}, 1, "", true));
{
V lc0_2670 = default;
lc0_2670 = Get(N_21, "luxCoffee");
Set(N_21, "luxCoffee", Fn((V _arrowThis2678, int _argc2671, V S_2677, V _a2674, V _a2675, V _a2676, V[] _rest2672) => {
V B_2679 = default;
V D_2680 = default;
B_2679 = Call(lc0_2670, V.Undef, S_2677);
D_2680 = Object_assign(NewObj(0).V, B_2679);
Set(D_2680, "build", Fn((V _arrowThis2688, int _argc2681, V P_2687, V _a2684, V _a2685, V _a2686, V[] _rest2682) => {
V o_2689 = default;
V on_2690 = default;
V R_2691 = default;
V WAT_2692 = default;
V liq_2693 = default;
V VA_2694 = default;
o_2689 = Invoke(B_2679, "build", P_2687);
on_2690 = Call(glue_33, V.Undef, o_2689);
R_2691 = Call(R0_34, V.Undef, ((V)("lux26")));
WAT_2692 = ((V)("#cfeaf6"));
Invoke(o_2689, "forEach", Fn((V _arrowThis2702, int _argc2695, V S0_2701, V _a2698, V _a2699, V _a2700, V[] _rest2696) => {
V L_2703 = default;
double cx_2704 = 0;
double cz_2705 = 0;
if ((!SEq(Get(S0_2701, "col"), GOLD_23) || !(Truthy(Get(S0_2701, "pts"))))) {
return default;
}
L_2703 = Call(bbS_52, V.Undef, S0_2701);
cx_2704 = (ToNum(Add(GetIdx(L_2703, 0D), GetIdx(L_2703, 1D))) / 2D);
cz_2705 = (ToNum(Add(GetIdx(L_2703, 4D), GetIdx(L_2703, 5D))) / 2D);
if ((((System.Math.Abs((ToNum(GetIdx(L_2703, 2D)) - 3D)) < 0.3) && (System.Math.Abs((System.Math.Abs(cx_2704) - 46D)) < 1D)) && (System.Math.Abs((System.Math.Abs(cz_2705) - 22D)) < 1D))) {
Call(mvPts_61, V.Undef, S0_2701, Fn((V _arrowThis2713, int _argc2706, V p_2712, V _a2709, V _a2710, V _a2711, V[] _rest2707) => {
return Arr(((V)((ToNum(GetIdx(p_2712, 0D)) - (Sign(cx_2704) * 6D)))), GetIdx(p_2712, 1D), ((V)((ToNum(GetIdx(p_2712, 2D)) - (Sign(cz_2705) * 4.4)))));
}, 1, "", true));
} else {
if (((LtN(GetIdx(L_2703, 2D), 0.3) && (System.Math.Abs((System.Math.Abs(cx_2704) - 48.8)) < 1D)) && (System.Math.Abs((System.Math.Abs(cz_2705) - 24.2)) < 1D))) {
Call(mvPts_61, V.Undef, S0_2701, Fn((V _arrowThis2721, int _argc2714, V p_2720, V _a2717, V _a2718, V _a2719, V[] _rest2715) => {
return Arr(((V)((ToNum(GetIdx(p_2720, 0D)) - (Sign(cx_2704) * 6.6)))), GetIdx(p_2720, 1D), ((V)((ToNum(GetIdx(p_2720, 2D)) - (Sign(cz_2705) * 5D)))));
}, 1, "", true));
}
}
return default;
}, 1, "", true));
liq_2693 = Invoke(o_2689, "filter", Fn((V _arrowThis2729, int _argc2722, V S0_2728, V _a2725, V _a2726, V _a2727, V[] _rest2723) => {
return (SEqS(Get(S0_2728, "col"), "#b8692a") ? V.True : V.False);
}, 1, "", true));
Invoke(liq_2693, "forEach", Fn((V _arrowThis2737, int _argc2730, V S0_2736, V _a2733, V _a2734, V _a2735, V[] _rest2731) => {
Set(S0_2736, "col", WAT_2692);
Set(S0_2736, "op", ((V)(0.55)));
Set(S0_2736, "shine", ((V)(1D)));
return default;
}, 1, "", true));
Call(drop_62, V.Undef, o_2689, Fn((V _arrowThis2745, int _argc2738, V S0_2744, V _a2741, V _a2742, V _a2743, V[] _rest2739) => {
return Invoke(Arr(((V)("#c8243a")), ((V)("#f6a8c4")), ((V)("#fff2f6")), ((V)("#e94a6a")), ((V)("#4f8a3a"))), "includes", Get(S0_2744, "col"));
}, 1, "", true));
Invoke(liq_2693, "forEach", Fn((V _arrowThis2753, int _argc2746, V S0_2752, V _a2749, V _a2750, V _a2751, V[] _rest2747) => {
V L_2754 = default;
double cx_2755 = 0;
double cz_2756 = 0;
double r_2757 = 0;
V top_2758 = default;
V SU_2759 = default;
V RI_2760 = default;
V ex_2761 = default;
L_2754 = Call(bbS_52, V.Undef, S0_2752);
cx_2755 = (ToNum(Add(GetIdx(L_2754, 0D), GetIdx(L_2754, 1D))) / 2D);
cz_2756 = (ToNum(Add(GetIdx(L_2754, 4D), GetIdx(L_2754, 5D))) / 2D);
r_2757 = ((ToNum(GetIdx(L_2754, 1D)) - ToNum(GetIdx(L_2754, 0D))) / 2D);
top_2758 = GetIdx(L_2754, 3D);
SU_2759 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.5))).V);
RI_2760 = Call(dec_27, V.Undef, ((V)("#9fd0e6")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(spot_28, V.Undef, SU_2759, Arr(((V)((cx_2755 - (r_2757 * 0.3)))), Add(top_2758, ((V)(0.02))), ((V)((cz_2756 - (r_2757 * 0.2))))), Y3_59, ((V)((r_2757 * 0.4))), ((V)((r_2757 * 0.18))), ((V)(0.4)), ((V)(10D)));
Call(ringY_32, V.Undef, RI_2760, ((V)(cx_2755)), ((V)(cz_2756)), ((V)((r_2757 * 0.92))), Add(top_2758, ((V)(0.02))), ((V)(0.18)), ((V)(24D)));
ex_2761 = Arr(SU_2759, RI_2760);
if ((r_2757 < 3D)) {
Invoke(ex_2761, "push", Call(box_13, V.Undef, ((V)((cx_2755 - 0.6))), ((V)((ToNum(top_2758) - 1.1))), ((V)((cz_2756 + 0.4))), ((V)(1.5)), ((V)(1.5)), ((V)(1.5)), ((V)("#eef9ff")), NewObj(5).Put("r", ((V)(0.3))).Put("yaw", ((V)(0.5))).Put("op", ((V)(0.6))).Put("mat", ((V)("cer"))).Put("noOut", ((V)(1D))).V), Call(box_13, V.Undef, ((V)((cx_2755 + 0.7))), ((V)((ToNum(top_2758) - 0.9))), ((V)((cz_2756 - 0.4))), ((V)(1.3)), ((V)(1.3)), ((V)(1.3)), ((V)("#eef9ff")), NewObj(5).Put("r", ((V)(0.3))).Put("yaw", ((V)((-0.3)))).Put("op", ((V)(0.6))).Put("mat", ((V)("cer"))).Put("noOut", ((V)(1D))).V), Call(cyl_14, V.Undef, ((V)((cx_2755 + 0.2))), Add(top_2758, ((V)(0.05))), ((V)((cz_2756 + 0.9))), ((V)(1.1)), ((V)(0.25)), ((V)("#f4d43a")), NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V));
}
Call(on_2690, V.Undef, S0_2752, ex_2761);
return default;
}, 1, "", true));
VA_2694 = Invoke(o_2689, "find", Fn((V _arrowThis2769, int _argc2762, V S0_2768, V _a2765, V _a2766, V _a2767, V[] _rest2763) => {
return ((SEqS(Get(S0_2768, "col"), "#f4efe6") ? V.True : V.False) is var _t2774 && Truthy(_t2774) ? _t2774 : (((((SEqS(Get(S0_2768, "mat"), "cer") ? V.True : V.False) is var _t2770 && !Truthy(_t2770) ? _t2770 : Get(S0_2768, "pts")) is var _t2771 && !Truthy(_t2771) ? _t2771 : ((System.Math.Abs((ToNum(GetIdx(Call(cen_63, V.Undef, S0_2768), 0D)) - 22D)) < 1D) ? V.True : V.False)) is var _t2772 && !Truthy(_t2772) ? _t2772 : ((System.Math.Abs((ToNum(GetIdx(Call(bbS_52, V.Undef, S0_2768), 2D)) - 40.8)) < 0.3) ? V.True : V.False)) is var _t2773 && !Truthy(_t2773) ? _t2773 : (((ToNum(GetIdx(Call(bbS_52, V.Undef, S0_2768), 3D)) - ToNum(GetIdx(Call(bbS_52, V.Undef, S0_2768), 2D))) > 10D) ? V.True : V.False)));
}, 1, "", true));
if (Truthy(VA_2694)) {
double vx_2775 = 0;
double vz_2776 = 0;
double vy_2777 = 0;
V kids_2778 = default;
V RO_2779 = default;
V RC_2780 = default;
vx_2775 = 22D;
vz_2776 = (-4D);
vy_2777 = 54D;
kids_2778 = Arr();
Call(rep_35, V.Undef, ((V)(9D)), Fn((V _arrowThis2788, int _argc2781, V i_2787, V _a2784, V _a2785, V _a2786, V[] _rest2782) => {
double a_2789 = 0;
V d_2790 = default;
V sd_2791 = default;
V c_2792 = default;
a_2789 = ((((ToNum(i_2787) / 9D) * 2D) * PI_22) + 0.2);
d_2790 = Call(nz_57, V.Undef, Arr(((V)(FdLibm.Cos(a_2789))), ((V)((-0.35))), ((V)(FdLibm.Sin(a_2789)))));
sd_2791 = Call(nz_57, V.Undef, Call(cr_56, V.Undef, Y3_59, d_2790));
c_2792 = Arr(((V)((vx_2775 + (FdLibm.Cos(a_2789) * 2.6)))), ((V)((vy_2777 + 0.8))), ((V)((vz_2776 + (FdLibm.Sin(a_2789) * 2.6)))));
InvokeSpread(kids_2778, "push", new ArrBuilder().Spread(Call(leaf_84, V.Undef, c_2792, d_2790, sd_2791, ((V)(5.2)), ((V)(1.7)), ((V)((NumTruthy((ToNum(i_2787) % 2D)) ? "#3f7a32" : "#4f8a3a"))))).V);
return default;
}, 1, "", true));
Call(rep_35, V.Undef, ((V)(7D)), Fn((V _arrowThis2800, int _argc2793, V i_2799, V _a2796, V _a2797, V _a2798, V[] _rest2794) => {
double a_2801 = 0;
V b_2802 = default;
V t_2803 = default;
a_2801 = ((((ToNum(i_2799) / 7D) * 2D) * PI_22) + 0.6);
b_2802 = Arr(((V)((vx_2775 + (FdLibm.Cos(a_2801) * 1.4)))), ((V)((vy_2777 + 0.5))), ((V)((vz_2776 + (FdLibm.Sin(a_2801) * 1.4)))));
t_2803 = Arr(((V)((vx_2775 + (FdLibm.Cos(a_2801) * 6.4)))), ((V)(((vy_2777 + 4.6) + (ToNum(i_2799) % 3D)))), ((V)((vz_2776 + (FdLibm.Sin(a_2801) * 5.4)))));
Invoke(kids_2778, "push", Call(rod_36, V.Undef, b_2802, t_2803, ((V)(0.1)), ((V)("#6a8a4a")), NewObj(1).Put("n", ((V)(4D))).V));
Call(rep_35, V.Undef, ((V)(4D)), Fn((V _arrowThis2811, int _argc2804, V j_2810, V _a2807, V _a2808, V _a2809, V[] _rest2805) => {
return Invoke(kids_2778, "push", Call(ball_12, V.Undef, Add(GetIdx(t_2803, 0D), ((V)(((ToNum(Call(R_2691, V.Undef)) - 0.5) * 1.6)))), Add(GetIdx(t_2803, 1D), ((V)(((ToNum(Call(R_2691, V.Undef)) - 0.3) * 1.2)))), Add(GetIdx(t_2803, 2D), ((V)(((ToNum(Call(R_2691, V.Undef)) - 0.5) * 1.6)))), ((V)(0.42)), ((V)("#fbfaf4")), NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("shine", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
return default;
}, 1, "", true));
RO_2779 = Invoke(Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(2.5)), ((V)("#b8182e"))), Arr(((V)((-3.4))), ((V)((-0.6))), ((V)((-2D))), ((V)(2.1)), ((V)("#e05070"))), Arr(((V)(3.2)), ((V)((-0.8))), ((V)((-1.6))), ((V)(2.1)), ((V)("#f2a8bc"))), Arr(((V)((-2.6))), ((V)((-1D))), ((V)(2.6)), ((V)(2D)), ((V)("#f6c8d4"))), Arr(((V)(2.8)), ((V)((-0.9))), ((V)(2.4)), ((V)(2.2)), ((V)("#c8243a"))), Arr(((V)(0.4)), ((V)(2.2)), ((V)((-3D))), ((V)(1.6)), ((V)("#e94a6a")))), "sort", Fn((V _arrowThis2820, int _argc2812, V a_2818, V b_2819, V _a2816, V _a2817, V[] _rest2813) => {
return ((V)((ToNum(GetIdx(a_2818, 2D)) - ToNum(GetIdx(b_2819, 2D)))));
}, 2, "", true));
Invoke(RO_2779, "forEach", Fn((V _arrowThis2838, int _argc2821, V _a2823, V _a2824, V _a2825, V _a2826, V[] _rest2822) => {
V c_2839 = default;
V CTR_2840 = default;
V PE_2841 = default;
V SPd_2842 = default;
V EDl_2843 = default;
V dx_2829 = default;
V dy_2831 = default;
V dz_2833 = default;
V r_2835 = default;
V col_2837 = default;
{ V _t2827 = ListOf(_a2823);
{ V _t2828 = GetIdx(_t2827, 0D);
dx_2829 = _t2828; }
{ V _t2830 = GetIdx(_t2827, 1D);
dy_2831 = _t2830; }
{ V _t2832 = GetIdx(_t2827, 2D);
dz_2833 = _t2832; }
{ V _t2834 = GetIdx(_t2827, 3D);
r_2835 = _t2834; }
{ V _t2836 = GetIdx(_t2827, 4D);
col_2837 = _t2836; }
}
c_2839 = Arr(Add(((V)(vx_2775)), dx_2829), Add(((V)((vy_2777 + 2.6))), dy_2831), Add(((V)(vz_2776)), dz_2833));
CTR_2840 = Call(ball_12, V.Undef, GetIdx(c_2839, 0D), ((V)((ToNum(GetIdx(c_2839, 1D)) - (ToNum(r_2835) * 0.45)))), GetIdx(c_2839, 2D), ((V)((ToNum(r_2835) * 0.55))), Call(shade_18, V.Undef, col_2837, ((V)(0.85))), NewObj(4).Put("sy", ((V)(0.85))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("shine", ((V)(0D))).V);
PE_2841 = Arr();
Call(rep_35, V.Undef, ((V)(7D)), Fn((V _arrowThis2851, int _argc2844, V i_2850, V _a2847, V _a2848, V _a2849, V[] _rest2845) => {
V a_2852 = default;
V q_2853 = default;
a_2852 = Add(((V)((((ToNum(i_2850) / 7D) * 2D) * PI_22))), dx_2829);
q_2853 = Arr(Add(GetIdx(c_2839, 0D), ((V)(((FdLibm.Cos(ToNum(a_2852)) * ToNum(r_2835)) * 0.62)))), ((V)((ToNum(GetIdx(c_2839, 1D)) - (ToNum(r_2835) * 0.55)))), Add(GetIdx(c_2839, 2D), ((V)(((FdLibm.Sin(ToNum(a_2852)) * ToNum(r_2835)) * 0.62)))));
Invoke(PE_2841, "push", Call(ball_12, V.Undef, GetIdx(q_2853, 0D), GetIdx(q_2853, 1D), GetIdx(q_2853, 2D), ((V)((ToNum(r_2835) * 0.5))), (NumTruthy((ToNum(i_2850) % 2D)) ? col_2837 : Call(mix_19, V.Undef, col_2837, ((V)("#ffffff")), ((V)(0.12)))), NewObj(4).Put("sy", ((V)(0.7))).Put("k", ((V)(4D))).Put("n", ((V)(9D))).Put("shine", ((V)(0D))).V));
return default;
}, 1, "", true));
Invoke(PE_2841, "sort", Fn((V _arrowThis2862, int _argc2854, V p1_2860, V p2_2861, V _a2858, V _a2859, V[] _rest2855) => {
return ((V)((ToNum(GetIdx(Call(cen_63, V.Undef, p1_2860), 2D)) - ToNum(GetIdx(Call(cen_63, V.Undef, p2_2861), 2D)))));
}, 2, "", true));
SPd_2842 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, col_2837, ((V)(0.55))), NewObj(1).Put("op", ((V)(0.75))).V);
EDl_2843 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, col_2837, ((V)("#ffffff")), ((V)(0.4))), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(SPd_2842, "line", Call(rep_35, V.Undef, ((V)(18D)), Fn((V _arrowThis2870, int _argc2863, V i_2869, V _a2866, V _a2867, V _a2868, V[] _rest2864) => {
double t_2871 = 0;
double a_2872 = 0;
double rr_2873 = 0;
t_2871 = (ToNum(i_2869) / 17D);
a_2872 = ((t_2871 * 4D) * PI_22);
rr_2873 = (0.15 + ((t_2871 * ToNum(r_2835)) * 0.45));
return Arr(Add(GetIdx(c_2839, 0D), ((V)((FdLibm.Cos(a_2872) * rr_2873)))), Add(Add(GetIdx(c_2839, 1D), ((V)(0.03))), ((V)(((1D - t_2871) * 0.2)))), Add(GetIdx(c_2839, 2D), ((V)((FdLibm.Sin(a_2872) * rr_2873)))));
return default;
}, 1, "", true)), Y3_59, ((V)(0.16)));
Invoke(EDl_2843, "line", Call(rep_35, V.Undef, ((V)(18D)), Fn((V _arrowThis2881, int _argc2874, V i_2880, V _a2877, V _a2878, V _a2879, V[] _rest2875) => {
double t_2882 = 0;
double a_2883 = 0;
double rr_2884 = 0;
t_2882 = (ToNum(i_2880) / 17D);
a_2883 = (((t_2882 * 4D) * PI_22) + 0.4);
rr_2884 = (0.25 + ((t_2882 * ToNum(r_2835)) * 0.45));
return Arr(Add(GetIdx(c_2839, 0D), ((V)((FdLibm.Cos(a_2883) * rr_2884)))), Add(Add(GetIdx(c_2839, 1D), ((V)(0.05))), ((V)(((1D - t_2882) * 0.2)))), Add(GetIdx(c_2839, 2D), ((V)((FdLibm.Sin(a_2883) * rr_2884)))));
return default;
}, 1, "", true)), Y3_59, ((V)(0.08)));
InvokeSpread(kids_2778, "push", new ArrBuilder().Spread(Invoke(PE_2841, "filter", Fn((V _arrowThis2892, int _argc2885, V p1_2891, V _a2888, V _a2889, V _a2890, V[] _rest2886) => {
return (Lt(GetIdx(Call(cen_63, V.Undef, p1_2891), 2D), GetIdx(c_2839, 2D)) ? V.True : V.False);
}, 1, "", true))).Add(CTR_2840).Spread(Invoke(PE_2841, "filter", Fn((V _arrowThis2900, int _argc2893, V p1_2899, V _a2896, V _a2897, V _a2898, V[] _rest2894) => {
return (Ge(GetIdx(Call(cen_63, V.Undef, p1_2899), 2D), GetIdx(c_2839, 2D)) ? V.True : V.False);
}, 1, "", true))).V);
Call(on_2690, V.Undef, CTR_2840, Arr(SPd_2842, EDl_2843));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)(4.6)), ((V)(3.6)), ((V)((-0.6)))), Arr(((V)((-4.4))), ((V)(4D)), ((V)(0.8)))), "forEach", Fn((V _arrowThis2914, int _argc2901, V _a2903, V _a2904, V _a2905, V _a2906, V[] _rest2902) => {
V c_2915 = default;
V dx_2909 = default;
V dy_2911 = default;
V dz_2913 = default;
{ V _t2907 = ListOf(_a2903);
{ V _t2908 = GetIdx(_t2907, 0D);
dx_2909 = _t2908; }
{ V _t2910 = GetIdx(_t2907, 1D);
dy_2911 = _t2910; }
{ V _t2912 = GetIdx(_t2907, 2D);
dz_2913 = _t2912; }
}
c_2915 = Arr(Add(((V)(vx_2775)), dx_2909), Add(((V)(vy_2777)), dy_2911), Add(((V)(vz_2776)), dz_2913));
Invoke(kids_2778, "push", Call(rod_36, V.Undef, Arr(((V)((vx_2775 + (ToNum(dx_2909) * 0.4)))), ((V)((vy_2777 + 0.6))), ((V)((vz_2776 + (ToNum(dz_2913) * 0.4))))), c_2915, ((V)(0.12)), ((V)("#4f7a32")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_12, V.Undef, GetIdx(c_2915, 0D), GetIdx(c_2915, 1D), GetIdx(c_2915, 2D), ((V)(0.8)), ((V)("#c8243a")), NewObj(4).Put("sy", ((V)(1.4))).Put("k", ((V)(4D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).V), Call(ball_12, V.Undef, GetIdx(c_2915, 0D), ((V)((ToNum(GetIdx(c_2915, 1D)) - 0.3))), GetIdx(c_2915, 2D), ((V)(0.75)), ((V)("#3f7a32")), NewObj(4).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).V));
return default;
}, 1, "", true));
RC_2780 = Invoke(o_2689, "find", Fn((V _arrowThis2923, int _argc2916, V S0_2922, V _a2919, V _a2920, V _a2921, V[] _rest2917) => {
return ((((SEq(Get(S0_2922, "col"), GOLD_23) ? V.True : V.False) is var _t2924 && !Truthy(_t2924) ? _t2924 : Get(S0_2922, "pts")) is var _t2925 && !Truthy(_t2925) ? _t2925 : ((System.Math.Abs((ToNum(GetIdx(Call(bbS_52, V.Undef, S0_2922), 2D)) - 52.8)) < 0.3) ? V.True : V.False)) is var _t2926 && !Truthy(_t2926) ? _t2926 : ((System.Math.Abs((ToNum(GetIdx(Call(cen_63, V.Undef, S0_2922), 0D)) - 22D)) < 1D) ? V.True : V.False));
}, 1, "", true));
Call(on_2690, V.Undef, (RC_2780 is var _t2927 && Truthy(_t2927) ? _t2927 : VA_2694), kids_2778);
}
return o_2689;
return default;
}, 1, "", true));
return D_2680;
return default;
}, 1, "", true));
}
Set(N_21, "liquid26", Fn((V _arrowThis2935, int _argc2928, V S_2934, V _a2931, V _a2932, V _a2933, V[] _rest2929) => {
return Object_assign(NewObj(0).V, Invoke(N_21, "liquid24", S_2934), NewObj(1).Put("fx", V.Undef).V);
}, 1, "", true));
ikeMore_86 = Fn((V _arrowThis2943, int _argc2936, V o_2942, V _a2939, V _a2940, V _a2941, V[] _rest2937) => {
V on_2944 = default;
V R_2945 = default;
V KB_2946 = default;
V TR_2947 = default;
V VS_2948 = default;
V IB_2949 = default;
on_2944 = Call(glue_33, V.Undef, o_2942);
R_2945 = Call(R0_34, V.Undef, ((V)("ike26")));
Invoke(Invoke(o_2942, "filter", Fn((V _arrowThis2997, int _argc2990, V S0_2996, V _a2993, V _a2994, V _a2995, V[] _rest2991) => {
return ((((SEqS(Get(S0_2996, "col"), "#f6c2d0") || SEqS(Get(S0_2996, "col"), "#fbe4ea")) ? V.True : V.False) is var _t2998 && !Truthy(_t2998) ? _t2998 : Get(S0_2996, "par")) is var _t2999 && !Truthy(_t2999) ? _t2999 : Get(S0_2996, "pts"));
}, 1, "", true)), "forEach", Fn((V _arrowThis2958, int _argc2950, V S0_2956, V i_2957, V _a2954, V _a2955, V[] _rest2951) => {
V c_2959 = default;
V PE_2960 = default;
V ST_2961 = default;
V CT_2962 = default;
c_2959 = Call(cen_63, V.Undef, S0_2956);
Set(S0_2956, "col", ((V)("#fff2f5")));
PE_2960 = Call(rep_35, V.Undef, ((V)(5D)), Fn((V _arrowThis2970, int _argc2963, V j_2969, V _a2966, V _a2967, V _a2968, V[] _rest2964) => {
V a_2971 = default;
a_2971 = Add(((V)((((ToNum(j_2969) / 5D) * 2D) * PI_22))), i_2957);
return Call(ball_12, V.Undef, Add(GetIdx(c_2959, 0D), ((V)((FdLibm.Cos(ToNum(a_2971)) * 0.85)))), ((V)((ToNum(GetIdx(c_2959, 1D)) - 0.25))), Add(GetIdx(c_2959, 2D), ((V)((FdLibm.Sin(ToNum(a_2971)) * 0.85)))), ((V)(0.62)), ((V)((NumTruthy((ToNum(j_2969) % 2D)) ? "#fbd0dc" : "#f8bccd"))), NewObj(5).Put("sy", ((V)(0.45))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).Put("noOut", ((V)(1D))).V);
return default;
}, 1, "", true));
ST_2961 = Call(dec_27, V.Undef, ((V)("#f2c040")));
CT_2962 = Call(dec_27, V.Undef, ((V)("#e86a92")));
Call(rep_35, V.Undef, ((V)(6D)), Fn((V _arrowThis2979, int _argc2972, V j_2978, V _a2975, V _a2976, V _a2977, V[] _rest2973) => {
double a_2980 = 0;
a_2980 = (((ToNum(j_2978) / 6D) * 2D) * PI_22);
Call(spot_28, V.Undef, ST_2961, Arr(Add(GetIdx(c_2959, 0D), ((V)((FdLibm.Cos(a_2980) * 0.5)))), Add(GetIdx(c_2959, 1D), ((V)(0.45))), Add(GetIdx(c_2959, 2D), ((V)((FdLibm.Sin(a_2980) * 0.5))))), Y3_59, ((V)(0.12)), ((V)(0.12)), ((V)(0D)), ((V)(5D)));
return default;
}, 1, "", true));
Call(spot_28, V.Undef, CT_2962, Arr(GetIdx(c_2959, 0D), Add(GetIdx(c_2959, 1D), ((V)(0.47))), GetIdx(c_2959, 2D)), Y3_59, ((V)(0.16)), ((V)(0.16)), ((V)(0D)), ((V)(6D)));
Call(on_2944, V.Undef, S0_2956, Invoke(Invoke(PE_2960, "sort", Fn((V _arrowThis2989, int _argc2981, V p1_2987, V p2_2988, V _a2985, V _a2986, V[] _rest2982) => {
return ((V)((ToNum(GetIdx(Call(cen_63, V.Undef, p1_2987), 2D)) - ToNum(GetIdx(Call(cen_63, V.Undef, p2_2988), 2D)))));
}, 2, "", true)), "concat", Arr(CT_2962, ST_2961)));
return default;
}, 2, "", true));
Invoke(Invoke(o_2942, "filter", Fn((V _arrowThis3030, int _argc3023, V S0_3029, V _a3026, V _a3027, V _a3028, V[] _rest3024) => {
return ((Invoke(Arr(((V)("#5a4030")), ((V)("#4a5a2a")), ((V)("#3f6a2e"))), "includes", Get(S0_3029, "col")) is var _t3031 && !Truthy(_t3031) ? _t3031 : Get(S0_3029, "pts")) is var _t3032 && !Truthy(_t3032) ? _t3032 : (!(Truthy(Get(S0_3029, "emit"))) ? V.True : V.False));
}, 1, "", true)), "forEach", Fn((V _arrowThis3007, int _argc3000, V S0_3006, V _a3003, V _a3004, V _a3005, V[] _rest3001) => {
V BK_3008 = default;
V BL_3009 = default;
V LN_3010 = default;
BK_3008 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, Get(S0_3006, "col"), ((V)(0.6))), NewObj(1).Put("op", ((V)(0.7))).V);
BL_3009 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, Get(S0_3006, "col"), ((V)("#ffffff")), ((V)(0.35))), NewObj(1).Put("op", ((V)(0.5))).V);
LN_3010 = Call(dec_27, V.Undef, ((V)("#d8c8a8")), NewObj(1).Put("op", ((V)(0.7))).V);
Invoke(Call(sides_51, V.Undef, S0_3006, ((V)(1D))), "forEach", Fn((V _arrowThis3019, int _argc3011, V F_3017, V j_3018, V _a3015, V _a3016, V[] _rest3012) => {
V m0_3020 = default;
V m1_3021 = default;
V L_3022 = default;
if (!SEqN(Get(Get(F_3017, "q"), "length"), 4D)) {
return default;
}
m0_3020 = Call(add_53, V.Undef, GetIdx(Get(F_3017, "q"), 0D), Call(mul_55, V.Undef, Call(sub_54, V.Undef, GetIdx(Get(F_3017, "q"), 1D), GetIdx(Get(F_3017, "q"), 0D)), ((V)(0.5))));
m1_3021 = Call(add_53, V.Undef, GetIdx(Get(F_3017, "q"), 3D), Call(mul_55, V.Undef, Call(sub_54, V.Undef, GetIdx(Get(F_3017, "q"), 2D), GetIdx(Get(F_3017, "q"), 3D)), ((V)(0.5))));
L_3022 = InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(Call(sub_54, V.Undef, m1_3021, m0_3020)).V);
if (LtN(L_3022, 1.2)) {
return default;
}
Invoke((NumTruthy((ToNum(j_3018) % 2D)) ? BL_3009 : BK_3008), "line", Arr(Call(add_53, V.Undef, m0_3020, Call(mul_55, V.Undef, Call(sub_54, V.Undef, m1_3021, m0_3020), ((V)(0.1)))), Call(add_53, V.Undef, m0_3020, Call(mul_55, V.Undef, Call(sub_54, V.Undef, m1_3021, m0_3020), ((V)(0.55)))), Call(add_53, V.Undef, m0_3020, Call(mul_55, V.Undef, Call(sub_54, V.Undef, m1_3021, m0_3020), ((V)(0.9))))), Get(F_3017, "n"), ((V)(0.1)));
if ((((ToNum(j_3018) % 3D) == 0D) && LtN(Call(R_2945, V.Undef), 0.6))) {
Call(spot_28, V.Undef, LN_3010, Call(add_53, V.Undef, m0_3020, Call(mul_55, V.Undef, Call(sub_54, V.Undef, m1_3021, m0_3020), ((V)((0.3 + (ToNum(Call(R_2945, V.Undef)) * 0.4)))))), Get(F_3017, "n"), ((V)(0.16)), ((V)(0.07)), ((V)(0D)), ((V)(5D)));
}
return default;
}, 2, "", true));
Call(on_2944, V.Undef, S0_3006, Arr(BK_3008, BL_3009, LN_3010));
return default;
}, 1, "", true));
Invoke(Invoke(o_2942, "filter", Fn((V _arrowThis3084, int _argc3077, V S0_3083, V _a3080, V _a3081, V _a3082, V[] _rest3078) => {
return (Invoke(Arr(((V)("#3f7a34")), ((V)("#5a9a44")), ((V)("#2f5a2a"))), "includes", Get(S0_3083, "col")) is var _t3085 && !Truthy(_t3085) ? _t3085 : Get(S0_3083, "pts"));
}, 1, "", true)), "forEach", Fn((V _arrowThis3040, int _argc3033, V S0_3039, V _a3036, V _a3037, V _a3038, V[] _rest3034) => {
V L_3041 = default;
V c_3042 = default;
double a_3043 = 0;
double b_3044 = 0;
V y_3045 = default;
V MR_3046 = default;
V VN_3047 = default;
V HL_3048 = default;
V ax_3049 = default;
V P_3050 = default;
L_3041 = Call(bbS_52, V.Undef, S0_3039);
c_3042 = Call(cen_63, V.Undef, S0_3039);
a_3043 = ((ToNum(GetIdx(L_3041, 1D)) - ToNum(GetIdx(L_3041, 0D))) / 2D);
b_3044 = ((ToNum(GetIdx(L_3041, 5D)) - ToNum(GetIdx(L_3041, 4D))) / 2D);
y_3045 = Add(GetIdx(L_3041, 3D), ((V)(0.02)));
MR_3046 = Call(dec_27, V.Undef, Call(mix_19, V.Undef, Get(S0_3039, "col"), ((V)("#ffffff")), ((V)(0.35))), NewObj(1).Put("op", ((V)(0.75))).V);
VN_3047 = Call(dec_27, V.Undef, Call(shade_18, V.Undef, Get(S0_3039, "col"), ((V)(0.7))), NewObj(1).Put("op", ((V)(0.6))).V);
HL_3048 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.25))).V);
ax_3049 = ((a_3043 > b_3044) ? V.True : V.False);
P_3050 = Fn((V _arrowThis3059, int _argc3051, V u_3057, V v_3058, V _a3055, V _a3056, V[] _rest3052) => {
return (Truthy(ax_3049) ? Arr(Add(GetIdx(c_3042, 0D), ((V)((ToNum(u_3057) * a_3043)))), y_3045, Add(GetIdx(c_3042, 2D), ((V)((ToNum(v_3058) * b_3044))))) : Arr(Add(GetIdx(c_3042, 0D), ((V)((ToNum(v_3058) * a_3043)))), y_3045, Add(GetIdx(c_3042, 2D), ((V)((ToNum(u_3057) * b_3044))))));
}, 2, "", true);
Invoke(MR_3046, "line", Arr(Call(P_3050, V.Undef, ((V)((-0.9))), ((V)(0D))), Call(P_3050, V.Undef, ((V)(0.9)), ((V)(0D)))), Y3_59, ((V)(0.14)));
Call(rep_35, V.Undef, ((V)(4D)), Fn((V _arrowThis3067, int _argc3060, V i_3066, V _a3063, V _a3064, V _a3065, V[] _rest3061) => {
double u_3068 = 0;
u_3068 = ((-0.6) + (ToNum(i_3066) * 0.4));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3076, int _argc3069, V sg_3075, V _a3072, V _a3073, V _a3074, V[] _rest3070) => {
return Invoke(VN_3047, "line", Arr(Call(P_3050, V.Undef, ((V)(u_3068)), ((V)(0D))), Call(P_3050, V.Undef, ((V)((u_3068 + 0.25))), ((V)((ToNum(sg_3075) * 0.7))))), Y3_59, ((V)(0.07)));
}, 1, "", true));
return default;
}, 1, "", true));
Call(spot_28, V.Undef, HL_3048, Call(P_3050, V.Undef, ((V)((-0.3))), ((V)((-0.3)))), Y3_59, ((V)((Max(a_3043, b_3044) * 0.3))), ((V)((Min(a_3043, b_3044) * 0.25))), ((V)(0D)), ((V)(8D)));
Call(on_2944, V.Undef, S0_3039, Arr(VN_3047, MR_3046, HL_3048));
return default;
}, 1, "", true));
Invoke(Invoke(o_2942, "filter", Fn((V _arrowThis3114, int _argc3107, V S0_3113, V _a3110, V _a3111, V _a3112, V[] _rest3108) => {
return (((SEqS(Get(S0_3113, "col"), "#d8283e") || SEqS(Get(S0_3113, "col"), "#e8344a")) ? V.True : V.False) is var _t3115 && !Truthy(_t3115) ? _t3115 : Get(S0_3113, "pts"));
}, 1, "", true)), "forEach", Fn((V _arrowThis3093, int _argc3086, V S0_3092, V _a3089, V _a3090, V _a3091, V[] _rest3087) => {
V c_3094 = default;
V L_3095 = default;
V VN_3096 = default;
V HL_3097 = default;
c_3094 = Call(cen_63, V.Undef, S0_3092);
L_3095 = Call(bbS_52, V.Undef, S0_3092);
VN_3096 = Call(dec_27, V.Undef, ((V)("#8a1424")), NewObj(1).Put("op", ((V)(0.55))).V);
HL_3097 = Call(dec_27, V.Undef, ((V)("#ff8a9a")), NewObj(1).Put("op", ((V)(0.45))).V);
Call(rep_35, V.Undef, ((V)(3D)), Fn((V _arrowThis3105, int _argc3098, V i_3104, V _a3101, V _a3102, V _a3103, V[] _rest3099) => {
double a_3106 = 0;
a_3106 = (ToNum(i_3104) * 2.1);
Invoke(VN_3096, "line", Arr(Arr(GetIdx(c_3094, 0D), Add(GetIdx(L_3095, 3D), ((V)(0.02))), GetIdx(c_3094, 2D)), Arr(Add(GetIdx(c_3094, 0D), ((V)((FdLibm.Cos(a_3106) * 0.9)))), Add(GetIdx(L_3095, 3D), ((V)(0.02))), Add(GetIdx(c_3094, 2D), ((V)((FdLibm.Sin(a_3106) * 0.9)))))), Y3_59, ((V)(0.07)));
return default;
}, 1, "", true));
Call(spot_28, V.Undef, HL_3097, Arr(((V)((ToNum(GetIdx(c_3094, 0D)) - 0.3))), Add(GetIdx(L_3095, 3D), ((V)(0.03))), ((V)((ToNum(GetIdx(c_3094, 2D)) - 0.2)))), Y3_59, ((V)(0.4)), ((V)(0.2)), ((V)(0.5)), ((V)(6D)));
Call(on_2944, V.Undef, S0_3092, Arr(VN_3096, HL_3097));
return default;
}, 1, "", true));
Invoke(Invoke(o_2942, "filter", Fn((V _arrowThis3143, int _argc3136, V S0_3142, V _a3139, V _a3140, V _a3141, V[] _rest3137) => {
return ((SEqS(Get(S0_3142, "col"), "#b81e34") ? V.True : V.False) is var _t3144 && !Truthy(_t3144) ? _t3144 : Get(S0_3142, "pts"));
}, 1, "", true)), "forEach", Fn((V _arrowThis3123, int _argc3116, V S0_3122, V _a3119, V _a3120, V _a3121, V[] _rest3117) => {
V c_3124 = default;
V L_3125 = default;
V SM_3126 = default;
c_3124 = Call(cen_63, V.Undef, S0_3122);
L_3125 = Call(bbS_52, V.Undef, S0_3122);
SM_3126 = Call(dec_27, V.Undef, ((V)("#f2c230")));
Call(rep_35, V.Undef, ((V)(10D)), Fn((V _arrowThis3134, int _argc3127, V i_3133, V _a3130, V _a3131, V _a3132, V[] _rest3128) => {
double a_3135 = 0;
a_3135 = (((ToNum(i_3133) / 10D) * 2D) * PI_22);
Call(spot_28, V.Undef, SM_3126, Arr(Add(GetIdx(c_3124, 0D), ((V)((FdLibm.Cos(a_3135) * 0.95)))), Add(GetIdx(L_3125, 3D), ((V)(0.02))), Add(GetIdx(c_3124, 2D), ((V)((FdLibm.Sin(a_3135) * 0.95))))), Y3_59, ((V)(0.16)), ((V)(0.16)), ((V)(0D)), ((V)(5D)));
return default;
}, 1, "", true));
Call(on_2944, V.Undef, S0_3122, Arr(SM_3126));
return default;
}, 1, "", true));
KB_2946 = Invoke(o_2942, "find", Fn((V _arrowThis3152, int _argc3145, V S0_3151, V _a3148, V _a3149, V _a3150, V[] _rest3146) => {
return ((SEqS(Get(S0_3151, "col"), "#4f7a3a") && !(Truthy(Get(S0_3151, "par")))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(KB_2946)) {
V c_3153 = default;
V T_3154 = default;
c_3153 = Call(cen_63, V.Undef, KB_2946);
T_3154 = Call(rep_35, V.Undef, ((V)(14D)), Fn((V _arrowThis3162, int _argc3155, V i_3161, V _a3158, V _a3159, V _a3160, V[] _rest3156) => {
double a_3163 = 0;
double el_3164 = 0;
V d_3165 = default;
V q_3166 = default;
a_3163 = (ToNum(i_3161) * 2.4);
el_3164 = ((-0.3) + ((ToNum(i_3161) % 5D) * 0.32));
d_3165 = Call(nz_57, V.Undef, Arr(((V)((FdLibm.Cos(a_3163) * FdLibm.Cos(el_3164)))), ((V)((FdLibm.Sin(el_3164) + 0.3))), ((V)((FdLibm.Sin(a_3163) * FdLibm.Cos(el_3164))))));
q_3166 = Call(add_53, V.Undef, c_3153, Call(mul_55, V.Undef, d_3165, ((V)(2.9))));
return Call(ball_12, V.Undef, GetIdx(q_3166, 0D), ((V)((ToNum(GetIdx(q_3166, 1D)) - 0.3))), GetIdx(q_3166, 2D), ((V)(0.55)), GetIdx(Arr(((V)("#5f9a3e")), ((V)("#3f6f2e")), ((V)("#7ab84a"))), (ToNum(i_3161) % 3D)), NewObj(6).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(7D))).Put("shine", ((V)(0D))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V);
return default;
}, 1, "", true));
Invoke(T_3154, "forEach", Fn((V _arrowThis3174, int _argc3167, V S1_3173, V _a3170, V _a3171, V _a3172, V[] _rest3168) => {
Set(S1_3173, "fn", Call(nz_57, V.Undef, Call(sub_54, V.Undef, Call(cen_63, V.Undef, S1_3173), c_3153)));
return default;
}, 1, "", true));
Call(on_2944, V.Undef, KB_2946, T_3154);
}
TR_2947 = Invoke(o_2942, "find", Fn((V _arrowThis3182, int _argc3175, V S0_3181, V _a3178, V _a3179, V _a3180, V[] _rest3176) => {
return ((SEqS(Get(S0_3181, "col"), "#2c2f35") && !(Truthy(Get(S0_3181, "par")))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(TR_2947)) {
V RS_3183 = default;
V MI_3184 = default;
V CH_3185 = default;
RS_3183 = Call(dec_27, V.Undef, ((V)("#a8643a")), NewObj(1).Put("op", ((V)(0.4))).V);
MI_3184 = Call(dec_27, V.Undef, ((V)("#c8d0da")), NewObj(1).Put("op", ((V)(0.35))).V);
CH_3185 = Call(dec_27, V.Undef, ((V)("#5a5f68")), NewObj(1).Put("op", ((V)(0.9))).V);
Invoke(Call(caps_50, V.Undef, TR_2947, ((V)(2D))), "forEach", Fn((V _arrowThis3193, int _argc3186, V F_3192, V _a3189, V _a3190, V _a3191, V[] _rest3187) => {
Call(fleck_69, V.Undef, RS_3183, RS_3183, F_3192, R_2945, ((V)(7D)), ((V)(1.4)));
Call(fleck_69, V.Undef, MI_3184, MI_3184, F_3192, R_2945, ((V)(14D)), ((V)(0.07)));
return default;
}, 1, "", true));
Call(rep_35, V.Undef, ((V)(16D)), Fn((V _arrowThis3201, int _argc3194, V i_3200, V _a3197, V _a3198, V _a3199, V[] _rest3195) => {
V x_3202 = default;
x_3202 = Add(((V)(((-25D) + (ToNum(i_3200) * 3.3)))), Call(R_2945, V.Undef));
Invoke(CH_3185, "line", Arr(Arr(x_3202, ((V)(1.42)), ((V)(13.9))), Arr(Add(Add(x_3202, ((V)(1.2))), Call(R_2945, V.Undef)), ((V)(1.42)), ((V)((13.2 + (ToNum(Call(R_2945, V.Undef)) * 0.5)))))), Y3_59, ((V)(0.22)));
Invoke(CH_3185, "line", Arr(Arr(x_3202, ((V)(1.42)), ((V)((-13.9)))), Arr(Add(x_3202, ((V)(1.4))), ((V)(1.42)), ((V)(((-13.3) - (ToNum(Call(R_2945, V.Undef)) * 0.4)))))), Y3_59, ((V)(0.2)));
return default;
}, 1, "", true));
Call(on_2944, V.Undef, TR_2947, Arr(RS_3183, MI_3184, CH_3185));
}
VS_2948 = Invoke(o_2942, "find", Fn((V _arrowThis3210, int _argc3203, V S0_3209, V _a3206, V _a3207, V _a3208, V[] _rest3204) => {
return ((SEqS(Get(S0_3209, "col"), "#e3f3fa") && !(Truthy(Get(S0_3209, "par")))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(VS_2948)) {
V L_3211 = default;
V c_3212 = default;
V SP_3213 = default;
L_3211 = Call(bbS_52, V.Undef, VS_2948);
c_3212 = Call(cen_63, V.Undef, VS_2948);
SP_3213 = Call(dec_27, V.Undef, ((V)("#ffffff")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.95))).V);
Invoke(Arr(Arr(((V)((-0.4))), ((V)(0.3))), Arr(((V)(0.5)), ((V)((-0.2)))), Arr(((V)(0.1)), ((V)(0.55))), Arr(((V)((-0.6))), ((V)((-0.4))))), "forEach", Fn((V _arrowThis3225, int _argc3214, V _a3216, V _a3217, V _a3218, V _a3219, V[] _rest3215) => {
V a_3226 = default;
V y_3227 = default;
double r_3228 = 0;
V p0_3229 = default;
V n0_3230 = default;
V u_3222 = default;
V v_3224 = default;
{ V _t3220 = ListOf(_a3216);
{ V _t3221 = GetIdx(_t3220, 0D);
u_3222 = _t3221; }
{ V _t3223 = GetIdx(_t3220, 1D);
v_3224 = _t3223; }
}
a_3226 = Add(((V)((PI_22 / 2D))), u_3222);
y_3227 = Add(GetIdx(c_3212, 1D), ((V)(((ToNum(v_3224) * (ToNum(GetIdx(L_3211, 3D)) - ToNum(GetIdx(L_3211, 2D)))) * 0.4))));
r_3228 = (((ToNum(GetIdx(L_3211, 1D)) - ToNum(GetIdx(L_3211, 0D))) / 2D) * 0.95);
p0_3229 = Arr(Add(GetIdx(c_3212, 0D), ((V)((FdLibm.Cos(ToNum(a_3226)) * r_3228)))), y_3227, Add(GetIdx(c_3212, 2D), ((V)((FdLibm.Sin(ToNum(a_3226)) * r_3228)))));
n0_3230 = Arr(((V)(FdLibm.Cos(ToNum(a_3226)))), ((V)(0D)), ((V)(FdLibm.Sin(ToNum(a_3226)))));
Invoke(SP_3213, "line", Arr(Call(add_53, V.Undef, p0_3229, Arr(((V)(0D)), ((V)((-0.7))), ((V)(0D)))), Call(add_53, V.Undef, p0_3229, Arr(((V)(0D)), ((V)(0.7)), ((V)(0D))))), n0_3230, ((V)(0.12)));
Invoke(SP_3213, "line", Arr(Call(add_53, V.Undef, p0_3229, Call(mul_55, V.Undef, Call(nz_57, V.Undef, Call(cr_56, V.Undef, Y3_59, n0_3230)), ((V)((-0.6))))), Call(add_53, V.Undef, p0_3229, Call(mul_55, V.Undef, Call(nz_57, V.Undef, Call(cr_56, V.Undef, Y3_59, n0_3230)), ((V)(0.6))))), n0_3230, ((V)(0.12)));
return default;
}, 1, "", true));
Call(on_2944, V.Undef, VS_2948, Arr(SP_3213));
}
IB_2949 = Invoke(o_2942, "find", Fn((V _arrowThis3238, int _argc3231, V S0_3237, V _a3234, V _a3235, V _a3236, V[] _rest3232) => {
return ((SEqS(Get(S0_3237, "col"), "#d8b88a") && !(Truthy(Get(S0_3237, "par")))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(IB_2949)) {
V L_3239 = default;
L_3239 = Call(bbS_52, V.Undef, IB_2949);
Call(on_2944, V.Undef, IB_2949, Arr(Call(box_13, V.Undef, ((V)((ToNum(Add(GetIdx(L_3239, 0D), GetIdx(L_3239, 1D))) / 2D))), Add(GetIdx(L_3239, 2D), ((V)(0.7))), Add(GetIdx(L_3239, 5D), ((V)(0.05))), ((V)(1.6)), ((V)(1.1)), ((V)(0.25)), BR_24, Call(M__39, V.Undef, NewObj(3).Put("r", ((V)(0.15))).Put("shine", ((V)(1D))).Put("noOut", ((V)(1D))).V))), Z3_60);
}
return o_2942;
return default;
}, 1, "", true);
Set(N_21, "ikebana26", Fn((V _arrowThis3247, int _argc3240, V S_3246, V _a3243, V _a3244, V _a3245, V[] _rest3241) => {
V B_3248 = default;
V D_3249 = default;
B_3248 = Invoke(N_21, "ikebana25x", S_3246);
D_3249 = Object_assign(NewObj(0).V, B_3248);
Set(D_3249, "build", Fn((V _arrowThis3257, int _argc3250, V _a3252, V _a3253, V _a3254, V _a3255, V[] _rest3251) => {
V a_3256 = default;
a_3256 = RestArgs(0, _argc3250, _a3252, _a3253, _a3254, _a3255, _rest3251);
return Call(ikeMore_86, V.Undef, InvokeSpread(B_3248, "build", new ArrBuilder().Spread(a_3256).V));
}, 1, "", true));
return D_3249;
return default;
}, 1, "", true));
terraMore_87 = Fn((V _arrowThis3265, int _argc3258, V o_3264, V _a3261, V _a3262, V _a3263, V[] _rest3259) => {
V on_3266 = default;
V R_3267 = default;
V GRb_3268 = default;
V RK_3269 = default;
double GY_3270 = 0;
double GRr_3271 = 0;
V gH_3272 = default;
V ok_3273 = default;
on_3266 = Call(glue_33, V.Undef, o_3264);
R_3267 = Call(R0_34, V.Undef, ((V)("ter26")));
GRb_3268 = Invoke(o_3264, "find", Fn((V _arrowThis3281, int _argc3274, V S0_3280, V _a3277, V _a3278, V _a3279, V[] _rest3275) => {
return ((SEqS(Get(S0_3280, "col"), "#5a8f3a") && !(Truthy(Get(S0_3280, "par")))) ? V.True : V.False);
}, 1, "", true));
RK_3269 = Invoke(o_3264, "find", Fn((V _arrowThis3289, int _argc3282, V S0_3288, V _a3285, V _a3286, V _a3287, V[] _rest3283) => {
return ((SEqS(Get(S0_3288, "col"), "#7a6a5a") && !(Truthy(Get(S0_3288, "par")))) ? V.True : V.False);
}, 1, "", true));
GY_3270 = 40.5;
GRr_3271 = 15.6;
gH_3272 = Fn((V _arrowThis3298, int _argc3290, V x_3296, V z_3297, V _a3294, V _a3295, V[] _rest3291) => {
return ((V)(((GY_3270 + ((GRr_3271 * 0.16) * System.Math.Sqrt(Max(0D, (1D - (((ToNum(x_3296) * ToNum(x_3296)) + (ToNum(z_3297) * ToNum(z_3297))) / (GRr_3271 * GRr_3271))))))) + 0.05)));
}, 2, "", true);
ok_3273 = Fn((V _arrowThis3307, int _argc3299, V x_3305, V z_3306, V _a3303, V _a3304, V[] _rest3300) => {
return ((((((Hypot((ToNum(x_3305) - 10.2), (ToNum(z_3306) - 5.2)) > 4.2) && (Hypot(ToNum(Add(x_3305, ((V)(9D)))), (ToNum(z_3306) - 6.5)) > 3.2)) && (Hypot(ToNum(x_3305), ToNum(z_3306)) > 4D)) && (Hypot(ToNum(x_3305), ToNum(z_3306)) < 14D)) && !(((LtN(x_3305, 2D) && GtN(x_3305, (-13D))) && (System.Math.Abs((ToNum(z_3306) - (9D - ((11D * ToNum(Add(x_3305, ((V)(12D))))) / 13D)))) < 2D)))) ? V.True : V.False);
}, 2, "", true);
if (Truthy(GRb_3268)) {
V kids_3308 = default;
V pts_3309 = default;
double tries_3310 = 0;
V PB_3311 = default;
kids_3308 = Arr();
pts_3309 = Arr();
tries_3310 = 0D;
while ((LtN(Get(pts_3309, "length"), 16D) && (tries_3310++ < 400D))) {
double a_3312 = 0;
double r_3313 = 0;
double x_3314 = 0;
double z_3315 = 0;
a_3312 = ((ToNum(Call(R_3267, V.Undef)) * 2D) * PI_22);
r_3313 = (4D + (ToNum(Call(R_3267, V.Undef)) * 10D));
x_3314 = (FdLibm.Cos(a_3312) * r_3313);
z_3315 = (FdLibm.Sin(a_3312) * r_3313);
if (Truthy((Call(ok_3273, V.Undef, ((V)(x_3314)), ((V)(z_3315))) is var _t3324 && !Truthy(_t3324) ? _t3324 : Invoke(pts_3309, "every", Fn((V _arrowThis3323, int _argc3316, V q_3322, V _a3319, V _a3320, V _a3321, V[] _rest3317) => {
return ((Hypot((ToNum(GetIdx(q_3322, 0D)) - x_3314), (ToNum(GetIdx(q_3322, 1D)) - z_3315)) > 2.6) ? V.True : V.False);
}, 1, "", true))))) {
Invoke(pts_3309, "push", Arr(((V)(x_3314)), ((V)(z_3315))));
}
}
Invoke(Invoke(pts_3309, "sort", Fn((V _arrowThis3388, int _argc3380, V a_3386, V b_3387, V _a3384, V _a3385, V[] _rest3381) => {
return ((V)((ToNum(GetIdx(a_3386, 1D)) - ToNum(GetIdx(b_3387, 1D)))));
}, 2, "", true)), "forEach", Fn((V _arrowThis3337, int _argc3325, V _a3327, V i_3331, V _a3329, V _a3330, V[] _rest3326) => {
V y_3338 = default;
double kd_3339 = 0;
V x_3334 = default;
V z_3336 = default;
{ V _t3332 = ListOf(_a3327);
{ V _t3333 = GetIdx(_t3332, 0D);
x_3334 = _t3333; }
{ V _t3335 = GetIdx(_t3332, 1D);
z_3336 = _t3335; }
}
y_3338 = Call(gH_3272, V.Undef, x_3334, z_3336);
kd_3339 = (ToNum(i_3331) % 4D);
if ((kd_3339 < 2D)) {
double r_3340 = 0;
V M_3341 = default;
V D1_3342 = default;
r_3340 = (0.8 + (ToNum(Call(R_3267, V.Undef)) * 0.6));
M_3341 = Call(ball_12, V.Undef, x_3334, ((V)((ToNum(y_3338) - (r_3340 * 0.3)))), z_3336, ((V)(r_3340)), GetIdx(Arr(((V)("#4f8a30")), ((V)("#6fa83e")), ((V)("#3f7a2a")), ((V)("#86b84a"))), (ToNum(i_3331) % 4D)), NewObj(6).Put("sy", ((V)(0.55))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("shine", ((V)(0D))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V);
D1_3342 = Call(dec_27, V.Undef, ((V)("#a8d070")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(dots_49, V.Undef, D1_3342, (GetIdx(Call(caps_50, V.Undef, M_3341, ((V)(2D))), 0D) is var _t3343 && Truthy(_t3343) ? _t3343 : GetIdx(Get(M_3341, "faces"), 0D)), ((V)(0.6)), ((V)(0.12)), NewObj(1).Put("sh", ((V)(0.8))).V);
Invoke(kids_3308, "push", M_3341, D1_3342);
} else {
if ((kd_3339 == 2D)) {
V FN_3344 = default;
V FL_3345 = default;
FN_3344 = Call(dec_27, V.Undef, ((V)("#3f8a34")));
FL_3345 = Call(dec_27, V.Undef, ((V)("#6fb84a")), NewObj(1).Put("op", ((V)(0.9))).V);
Call(rep_35, V.Undef, ((V)(5D)), Fn((V _arrowThis3353, int _argc3346, V j_3352, V _a3349, V _a3350, V _a3351, V[] _rest3347) => {
V a_3354 = default;
V e_3355 = default;
a_3354 = Add(((V)((((ToNum(j_3352) / 5D) * 2D) * PI_22))), i_3331);
e_3355 = Arr(Add(x_3334, ((V)((FdLibm.Cos(ToNum(a_3354)) * 2.2)))), Add(y_3338, ((V)(0.9))), Add(z_3336, ((V)((FdLibm.Sin(ToNum(a_3354)) * 2.2)))));
Invoke(FN_3344, "line", Arr(Arr(x_3334, y_3338, z_3336), Arr(Add(x_3334, ((V)((FdLibm.Cos(ToNum(a_3354)) * 1.1)))), Add(y_3338, ((V)(0.8))), Add(z_3336, ((V)((FdLibm.Sin(ToNum(a_3354)) * 1.1))))), e_3355), Y3_59, ((V)(0.12)));
Call(rep_35, V.Undef, ((V)(4D)), Fn((V _arrowThis3363, int _argc3356, V k2_3362, V _a3359, V _a3360, V _a3361, V[] _rest3357) => {
double t_3364 = 0;
V b_3365 = default;
V sd_3366 = default;
t_3364 = (0.3 + (ToNum(k2_3362) * 0.17));
b_3365 = Arr(Add(x_3334, ((V)(((FdLibm.Cos(ToNum(a_3354)) * 2.2) * t_3364)))), Add(y_3338, ((V)((0.9 * Min(1D, (t_3364 * 1.6)))))), Add(z_3336, ((V)(((FdLibm.Sin(ToNum(a_3354)) * 2.2) * t_3364)))));
sd_3366 = Arr(((V)((-FdLibm.Sin(ToNum(a_3354))))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(a_3354)))));
Invoke(FL_3345, "line", Arr(Call(add_53, V.Undef, b_3365, Call(mul_55, V.Undef, sd_3366, ((V)((-0.4))))), Call(add_53, V.Undef, b_3365, Call(mul_55, V.Undef, sd_3366, ((V)(0.4))))), Y3_59, ((V)(0.14)));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(kids_3308, "push", FN_3344, FL_3345);
} else {
double h_3367 = 0;
V STm_3368 = default;
V CP_3369 = default;
V WD_3370 = default;
h_3367 = (1.3 + (ToNum(Call(R_3267, V.Undef)) * 0.5));
STm_3368 = Call(cyl_14, V.Undef, x_3334, ((V)((ToNum(y_3338) - 0.1))), z_3336, ((V)(0.28)), ((V)(h_3367)), ((V)("#f2ead8")), NewObj(2).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V);
CP_3369 = Call(ball_12, V.Undef, x_3334, ((V)((ToNum(Add(y_3338, ((V)(h_3367)))) - 0.35))), z_3336, ((V)(0.85)), ((V)("#d8342a")), NewObj(3).Put("sy", ((V)(0.55))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V);
WD_3370 = Call(dec_27, V.Undef, ((V)("#ffffff")));
Call(rep_35, V.Undef, ((V)(5D)), Fn((V _arrowThis3378, int _argc3371, V j_3377, V _a3374, V _a3375, V _a3376, V[] _rest3372) => {
V a_3379 = default;
a_3379 = Add(((V)((ToNum(j_3377) * 1.3))), i_3331);
Call(spot_28, V.Undef, WD_3370, Arr(Add(x_3334, ((V)((FdLibm.Cos(ToNum(a_3379)) * 0.45)))), Add(Add(y_3338, ((V)(h_3367))), ((V)(0.12))), Add(z_3336, ((V)((FdLibm.Sin(ToNum(a_3379)) * 0.45))))), Call(nz_57, V.Undef, Arr(((V)((FdLibm.Cos(ToNum(a_3379)) * 0.5))), ((V)(1D)), ((V)((FdLibm.Sin(ToNum(a_3379)) * 0.5))))), ((V)(0.13)), ((V)(0.13)), ((V)(0D)), ((V)(5D)));
return default;
}, 1, "", true));
Invoke(kids_3308, "push", STm_3368, CP_3369, WD_3370);
}
}
return default;
}, 2, "", true));
PB_3311 = Invoke(Call(rep_35, V.Undef, ((V)(12D)), Fn((V _arrowThis3405, int _argc3398, V i_3404, V _a3401, V _a3402, V _a3403, V[] _rest3399) => {
double a_3406 = 0;
double x_3407 = 0;
double z_3408 = 0;
a_3406 = (((ToNum(i_3404) / 12D) * 2D) * PI_22);
x_3407 = (10.2 + (FdLibm.Cos(a_3406) * 3.2));
z_3408 = (5.2 + (FdLibm.Sin(a_3406) * 2.4));
return Call(ball_12, V.Undef, ((V)(x_3407)), ((V)((ToNum(Call(gH_3272, V.Undef, ((V)(x_3407)), ((V)(z_3408)))) - 0.2))), ((V)(z_3408)), ((V)((0.38 + (ToNum(Call(R_3267, V.Undef)) * 0.2)))), GetIdx(Arr(((V)("#c9c4ba")), ((V)("#a8a399")), ((V)("#e2ddd2"))), (ToNum(i_3404) % 3D)), NewObj(5).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(7D))).Put("shine", ((V)(0D))).Put("noOut", ((V)(1D))).V);
return default;
}, 1, "", true)), "sort", Fn((V _arrowThis3397, int _argc3389, V a_3395, V b_3396, V _a3393, V _a3394, V[] _rest3390) => {
return ((V)((ToNum(GetIdx(Call(cen_63, V.Undef, a_3395), 2D)) - ToNum(GetIdx(Call(cen_63, V.Undef, b_3396), 2D)))));
}, 2, "", true));
Call(on_3266, V.Undef, GRb_3268, Invoke(kids_3308, "concat", PB_3311));
}
Invoke(Invoke(o_3264, "filter", Fn((V _arrowThis3460, int _argc3453, V S0_3459, V _a3456, V _a3457, V _a3458, V[] _rest3454) => {
return ((Invoke(Arr(((V)("#7a6a5a")), ((V)("#6a5a4a")), ((V)("#5a4a3a")), ((V)("#4e4034"))), "includes", Get(S0_3459, "col")) is var _t3461 && !Truthy(_t3461) ? _t3461 : (!(Truthy(Get(S0_3459, "par"))) ? V.True : V.False)) is var _t3462 && !Truthy(_t3462) ? _t3462 : Get(S0_3459, "pts"));
}, 1, "", true)), "forEach", Fn((V _arrowThis3416, int _argc3409, V S0_3415, V _a3412, V _a3413, V _a3414, V[] _rest3410) => {
V L_3417 = default;
V c_3418 = default;
V f_3419 = default;
V LC_3420 = default;
V LY_3421 = default;
V CK_3422 = default;
L_3417 = Call(bbS_52, V.Undef, S0_3415);
c_3418 = Call(cen_63, V.Undef, S0_3415);
f_3419 = Call(eS_64, V.Undef, c_3418, ((V)(((ToNum(GetIdx(L_3417, 1D)) - ToNum(GetIdx(L_3417, 0D))) / 2D))), ((V)(((ToNum(GetIdx(L_3417, 3D)) - ToNum(GetIdx(L_3417, 2D))) / 2D))), ((V)(((ToNum(GetIdx(L_3417, 5D)) - ToNum(GetIdx(L_3417, 4D))) / 2D))));
LC_3420 = Call(dec_27, V.Undef, ((V)("#c9d08a")), NewObj(1).Put("op", ((V)(0.7))).V);
LY_3421 = Call(dec_27, V.Undef, ((V)("#e8d890")), NewObj(1).Put("op", ((V)(0.6))).V);
CK_3422 = Call(dec_27, V.Undef, ((V)("#3a2e24")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(rep_35, V.Undef, ((V)(10D)), Fn((V _arrowThis3430, int _argc3423, V i_3429, V _a3426, V _a3427, V _a3428, V[] _rest3424) => {
V p0_3431 = default;
V n0_3432 = default;
{ V _t3433 = Call(f_3419, V.Undef, Arr(((V)(((ToNum(Call(R_3267, V.Undef)) - 0.5) * 2D))), ((V)(((ToNum(Call(R_3267, V.Undef)) - 0.5) * 1.6))), ((V)(((ToNum(Call(R_3267, V.Undef)) - 0.5) * 2D)))));
{ V _t3434 = ListOf(_t3433);
{ V _t3435 = GetIdx(_t3434, 0D);
p0_3431 = _t3435; }
{ V _t3436 = GetIdx(_t3434, 1D);
n0_3432 = _t3436; }
} }
Call(spot_28, V.Undef, (NumTruthy((ToNum(i_3429) % 2D)) ? LC_3420 : LY_3421), p0_3431, n0_3432, ((V)((0.35 + (ToNum(Call(R_3267, V.Undef)) * 0.4)))), ((V)((0.25 + (ToNum(Call(R_3267, V.Undef)) * 0.3)))), ((V)((ToNum(Call(R_3267, V.Undef)) * 3D))), ((V)(7D)));
return default;
}, 1, "", true));
Call(rep_35, V.Undef, ((V)(4D)), Fn((V _arrowThis3443, int _argc3437, V _a3439, V _a3440, V _a3441, V _a3442, V[] _rest3438) => {
V d0_3444 = default;
d0_3444 = Arr(((V)(((ToNum(Call(R_3267, V.Undef)) - 0.5) * 2D))), ((V)((ToNum(Call(R_3267, V.Undef)) - 0.7))), ((V)(((ToNum(Call(R_3267, V.Undef)) - 0.5) * 2D))));
Call(lineOn_65, V.Undef, CK_3422, Fn((V _arrowThis3452, int _argc3445, V t_3451, V _a3448, V _a3449, V _a3450, V[] _rest3446) => {
return Call(f_3419, V.Undef, Call(add_53, V.Undef, d0_3444, Arr(((V)((ToNum(t_3451) * 0.3))), ((V)((ToNum(t_3451) * 0.4))), ((V)(0D)))));
}, 1, "", true), ((V)(4D)), ((V)(0.12)));
return default;
}, 0, "", true));
Call(on_3266, V.Undef, S0_3415, Arr(LC_3420, LY_3421, CK_3422));
return default;
}, 1, "", true));
if (Truthy(RK_3269)) {
V vines_3463 = default;
vines_3463 = Call(rep_35, V.Undef, ((V)(6D)), Fn((V _arrowThis3471, int _argc3464, V i_3470, V _a3467, V _a3468, V _a3469, V[] _rest3465) => {
double a_3472 = 0;
double r0_3473 = 0;
V p0_3474 = default;
double L_3475 = 0;
V P3_3476 = default;
V VP_3477 = default;
a_3472 = ((((ToNum(i_3470) / 6D) * 2D) * PI_22) + 0.4);
r0_3473 = 9.6;
p0_3474 = Arr(((V)((FdLibm.Cos(a_3472) * r0_3473))), ((V)(29.6)), ((V)((FdLibm.Sin(a_3472) * r0_3473))));
L_3475 = (5D + ((ToNum(i_3470) % 3D) * 2.2));
P3_3476 = Arr(p0_3474, Arr(((V)((ToNum(GetIdx(p0_3474, 0D)) * 1.06))), ((V)((ToNum(GetIdx(p0_3474, 1D)) - (L_3475 * 0.5)))), ((V)((ToNum(GetIdx(p0_3474, 2D)) * 1.06)))), Arr(((V)(((ToNum(GetIdx(p0_3474, 0D)) * 1.02) + 0.6))), ((V)((ToNum(GetIdx(p0_3474, 1D)) - L_3475))), ((V)((ToNum(GetIdx(p0_3474, 2D)) * 1.02)))));
VP_3477 = Call(pipe_37, V.Undef, P3_3476, ((V)(0.16)), ((V)("#4f7a32")), NewObj(1).Put("n", ((V)(4D))).V);
return Invoke(VP_3477, "concat", Call(rep_35, V.Undef, ((V)(3D)), Fn((V _arrowThis3485, int _argc3478, V j_3484, V _a3481, V _a3482, V _a3483, V[] _rest3479) => {
V q_3486 = default;
q_3486 = GetIdx(P3_3476, (1D + (ToNum(j_3484) % 2D)));
return Call(ball_12, V.Undef, Add(GetIdx(q_3486, 0D), ((V)(((ToNum(j_3484) - 1D) * 0.6)))), ((V)((ToNum(Add(GetIdx(q_3486, 1D), ((V)(0.6)))) - (ToNum(j_3484) * 0.9)))), GetIdx(q_3486, 2D), ((V)(0.65)), ((V)((NumTruthy((ToNum(j_3484) % 2D)) ? "#5f9a3e" : "#3f7a2a"))), NewObj(6).Put("sx", ((V)(1.3))).Put("sy", ((V)(0.4))).Put("k", ((V)(3D))).Put("n", ((V)(7D))).Put("shine", ((V)(0D))).Put("noOut", ((V)(1D))).V);
return default;
}, 1, "", true)));
return default;
}, 1, "", true));
Call(on_3266, V.Undef, RK_3269, InvokeSpread(Arr(), "concat", new ArrBuilder().Spread(vines_3463).V));
}
return o_3264;
return default;
}, 1, "", true);
Set(N_21, "terra26", Fn((V _arrowThis3494, int _argc3487, V S_3493, V _a3490, V _a3491, V _a3492, V[] _rest3488) => {
V B_3495 = default;
V D_3496 = default;
V fx0_3497 = default;
B_3495 = Invoke(N_21, "terra25x", S_3493);
D_3496 = Object_assign(NewObj(0).V, B_3495);
if (Truthy(Get(B_3495, "layers"))) {
Set(D_3496, "layers", Invoke(Get(B_3495, "layers"), "map", Fn((V _arrowThis3506, int _argc3498, V L_3504, V i_3505, V _a3502, V _a3503, V[] _rest3499) => {
return Object_assign(NewObj(0).V, L_3504, NewObj(1).Put("build", Fn((V _arrowThis3514, int _argc3507, V _a3509, V _a3510, V _a3511, V _a3512, V[] _rest3508) => {
V o_3515 = default;
V a_3513 = default;
a_3513 = RestArgs(0, _argc3507, _a3509, _a3510, _a3511, _a3512, _rest3508);
o_3515 = InvokeSpread(L_3504, "build", new ArrBuilder().Spread(a_3513).V);
return (SEqN(i_3505, 0D) ? Call(terraMore_87, V.Undef, o_3515) : o_3515);
return default;
}, 1, "build", true)).V);
}, 2, "", true)));
}
fx0_3497 = Get(B_3495, "fx");
Set(D_3496, "fx", Fn((V _arrowThis3523, int _argc3516, V c_3522, V _a3519, V _a3520, V _a3521, V[] _rest3517) => {
V F_3524 = default;
V p_3525 = default;
V k_3526 = default;
JsStrBuf f_3527 = null;
F_3524 = (Truthy(fx0_3497) ? Object_assign(NewObj(0).V, (Call(fx0_3497, V.Undef, c_3522) is var _t3528 && Truthy(_t3528) ? _t3528 : NewObj(0).V)) : NewObj(0).V);
p_3525 = Get(c_3522, "p");
k_3526 = Get(c_3522, "k");
f_3527 = new JsStrBuf("");
Call(rep_35, V.Undef, ((V)(3D)), Fn((V _arrowThis3536, int _argc3529, V i_3535, V _a3532, V _a3533, V _a3534, V[] _rest3530) => {
double a_3537 = 0;
double x_3538 = 0;
double z_3539 = 0;
V q0_3540 = default;
V q1_3541 = default;
V d_3542 = default;
V dx_3543 = default;
a_3537 = ((ToNum(i_3535) * 2.1) + 0.5);
x_3538 = (FdLibm.Cos(a_3537) * 9D);
z_3539 = (FdLibm.Sin(a_3537) * 9D);
q0_3540 = Call(p_3525, V.Undef, ((V)(x_3538)), ((V)(25D)), ((V)(z_3539)));
q1_3541 = Call(p_3525, V.Undef, ((V)((FdLibm.Cos(a_3537) * 13.8))), ((V)(2.2)), ((V)((FdLibm.Sin(a_3537) * 13.8))));
d_3542 = Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q1_3541, 1D)) - ToNum(GetIdx(q0_3540, 1D))))));
dx_3543 = Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q1_3541, 0D)) - ToNum(GetIdx(q0_3540, 0D))))));
f_3527.S("<ellipse cx=\"").V(Call(f1_20, V.Undef, GetIdx(q0_3540, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(q0_3540, 1D))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(k_3526)))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((0.55 * ToNum(k_3526)))))).S("\" fill=\"#bfe8ff\" stroke=\"#5aa8d8\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.12 * ToNum(k_3526)))))).S("\" opacity=\"0\"><animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;").V(dx_3543).S(" ").V(d_3542).S("\" dur=\"1.6s\" begin=\"").V(Call(f1_20, V.Undef, ((V)(((-ToNum(i_3535)) * 1.1))))).S("s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0;0.95;0.95;0\" keyTimes=\"0;0.1;0.9;1\" dur=\"1.6s\" begin=\"").V(Call(f1_20, V.Undef, ((V)(((-ToNum(i_3535)) * 1.1))))).S("s\" repeatCount=\"indefinite\"/></ellipse>");
f_3527.S("<ellipse cx=\"").V(Call(f1_20, V.Undef, GetIdx(q1_3541, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(q1_3541, 1D))).S("\" rx=\"1\" ry=\"1\" fill=\"none\" stroke=\"#e8fbff\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.18 * ToNum(k_3526)))))).S("\" opacity=\"0\"><animate attributeName=\"rx\" values=\"").V(Call(f1_20, V.Undef, ((V)((0.3 * ToNum(k_3526)))))).S(";").V(Call(f1_20, V.Undef, ((V)((2.4 * ToNum(k_3526)))))).S("\" dur=\"1.6s\" begin=\"").V(Call(f1_20, V.Undef, ((V)((((-ToNum(i_3535)) * 1.1) + 1.5))))).S("s\" repeatCount=\"indefinite\"/><animate attributeName=\"ry\" values=\"").V(Call(f1_20, V.Undef, ((V)(((0.3 * ToNum(k_3526)) * ToNum(SA_25)))))).S(";").V(Call(f1_20, V.Undef, ((V)(((2.4 * ToNum(k_3526)) * ToNum(SA_25)))))).S("\" dur=\"1.6s\" begin=\"").V(Call(f1_20, V.Undef, ((V)((((-ToNum(i_3535)) * 1.1) + 1.5))))).S("s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.9;0\" dur=\"1.6s\" begin=\"").V(Call(f1_20, V.Undef, ((V)((((-ToNum(i_3535)) * 1.1) + 1.5))))).S("s\" repeatCount=\"indefinite\"/></ellipse>");
return default;
}, 1, "", true));
Set(F_3524, "front", ((V)(JsStrBuf.Begin().V((Get(F_3524, "front") is var _t3544 && Truthy(_t3544) ? _t3544 : ((V)("")))).S(f_3527.Str).End())));
return F_3524;
return default;
}, 1, "", true));
return D_3496;
return default;
}, 1, "", true));
big_88 = Fn((V _arrowThis3553, int _argc3545, V src_3551, V k_3552, V _a3549, V _a3550, V[] _rest3546) => {
return Fn((V _arrowThis3561, int _argc3554, V S_3560, V _a3557, V _a3558, V _a3559, V[] _rest3555) => {
V D_3562 = default;
V E_3563 = default;
D_3562 = InvokeK(N_21, src_3551, S_3560);
E_3563 = Object_assign(NewObj(0).V, D_3562, NewObj(3).Put("zs", ((V)((ToNum((Get(D_3562, "zs") is var _t3564 && Truthy(_t3564) ? _t3564 : ((V)(1D)))) * ToNum(k_3552))))).Put("w", ((V)((ToNum(Get(D_3562, "w")) * ToNum(k_3552))))).Put("d", ((V)((ToNum(Get(D_3562, "d")) * ToNum(k_3552))))).V);
if (Truthy(Get(D_3562, "use"))) {
Set(E_3563, "use", Object_assign(NewObj(0).V, Get(D_3562, "use"), NewObj(2).Put("x", ((V)((ToNum(Get(Get(D_3562, "use"), "x")) * ToNum(k_3552))))).Put("z", ((V)((ToNum(Get(Get(D_3562, "use"), "z")) * ToNum(k_3552))))).V));
}
if (Truthy(Get(D_3562, "seats"))) {
Set(E_3563, "seats", Invoke(Get(D_3562, "seats"), "map", Fn((V _arrowThis3572, int _argc3565, V q_3571, V _a3568, V _a3569, V _a3570, V[] _rest3566) => {
return Object_assign(NewObj(0).V, q_3571, NewObj(3).Put("x", ((V)((ToNum(Get(q_3571, "x")) * ToNum(k_3552))))).Put("z", ((V)((ToNum(Get(q_3571, "z")) * ToNum(k_3552))))).Put("h", ((V)((ToNum(Get(q_3571, "h")) * ToNum(k_3552))))).V);
}, 1, "", true)));
}
return E_3563;
return default;
}, 1, "", true);
}, 2, "", true);
Set(N_21, "cube26", Call(big_88, V.Undef, ((V)("cube23")), ((V)(1.25))));
Set(N_21, "arch26", Call(big_88, V.Undef, ((V)("arch23")), ((V)(1.18))));
Set(N_21, "lib26", Call(big_88, V.Undef, ((V)("lib23")), ((V)(1.18))));
Set(N_21, "arc26", Call(big_88, V.Undef, ((V)("arc23")), ((V)(1.2))));
Set(RD_8, "SET26", NewObj(14).Put("LIV-120", NewObj(2).Put("spec", ((V)("abc26"))).Put("note", ((V)("Chunky beech toy blocks with painted borders and embossed letters, numbers, stars and hearts on every face, a little chipped from play. Four stacked in a wobbly tower and two loose ones on the floor."))).V).Put("LIV-050", NewObj(3).Put("spec", ((V)("papasan26"))).Put("colors", Arr(NewObj(2).Put("n", ((V)("Blush Velvet"))).Put("c", ((V)("#d98c95"))).V, NewObj(2).Put("n", ((V)("Mustard Velvet"))).Put("c", ((V)("#c99a2e"))).V, NewObj(2).Put("n", ((V)("Emerald Velvet"))).Put("c", ((V)("#1f6a4c"))).V, NewObj(2).Put("n", ((V)("Navy Velvet"))).Put("c", ((V)("#2b3f7a"))).V, NewObj(2).Put("n", ((V)("Rust Velvet"))).Put("c", ((V)("#a8492b"))).V, NewObj(2).Put("n", ((V)("Ivory Boucl\u00e9"))).Put("c", ((V)("#ece5d6"))).V)).Put("note", ((V)("A papasan on a black and brass swivel base: the woven rattan bowl tilts back so its high back holds you, with binding bands and a wrapped rim. A deep round velvet cushion with pleats running into buttons and a piped edge, a plump channelled head pillow against the back and a gold tassel on the rim."))).V).Put("LIV-062", NewObj(2).Put("spec", ((V)("alab26"))).Put("note", ((V)("A sculptural totem of six hand-carved alabaster pieces (a rough block, a soft disc, a sphere, a chiselled drum, a river pebble and an open bowl shade) on bronze spacers over a square bronze plinth. Amber and white veins wrap round every stone and the light glows from inside, breathing from stone to stone."))).V).Put("LIV-107", NewObj(3).Put("spec", ((V)("chester26V"))).Put("colors", Arr(NewObj(2).Put("n", ((V)("Midnight Sapphire Velvet"))).Put("c", ((V)("#22306a"))).V, NewObj(2).Put("n", ((V)("Oxblood Velvet"))).Put("c", ((V)("#6a1c26"))).V, NewObj(2).Put("n", ((V)("Deep Emerald Velvet"))).Put("c", ((V)("#145c40"))).V, NewObj(2).Put("n", ((V)("Plum Velvet"))).Put("c", ((V)("#4e2052"))).V, NewObj(2).Put("n", ((V)("Old Gold Velvet"))).Put("c", ((V)("#b8862a"))).V, NewObj(2).Put("n", ((V)("Dusty Rose Velvet"))).Put("c", ((V)("#c98a8e"))).V, NewObj(2).Put("n", ((V)("Charcoal Velvet"))).Put("c", ((V)("#3a3a40"))).V)).Put("note", ((V)("A classic chesterfield in soft velvet with real deep buttoning across the back and inside both arms: buttons in a diamond grid, pleats folding between them and down to the seat. Rolled scroll arms, piped seat cushions, walnut bun feet on brass castors, two velvet pillows with tassels, a knit throw and an open paperback."))).V).Put("LIV-056", NewObj(2).Put("spec", ((V)("live26"))).Put("note", ((V)("A thick walnut slab with flowing grain, fine pores and ray flecks round two knots, a resin-filled crack held by bowties and a pale sapwood rim with bark, on brushed black steel frames. A turned bowl heaped with a red apple, an orange, a lemon, a green pear and two bananas, a latte and a book."))).V).Put("LIV-007", NewObj(1).Put("spec", ((V)("cube26"))).V).Put("LIV-047", NewObj(1).Put("spec", ((V)("arch26"))).V).Put("LIV-067", NewObj(1).Put("spec", ((V)("lib26"))).V).Put("LIV-087", NewObj(1).Put("spec", ((V)("arc26"))).V).Put("LIV-068", NewObj(1).Put("spec", ((V)("ikebana26"))).V).Put("LIV-111", NewObj(1).Put("note", ((V)("A gilded rococo coffee table: an oval white marble top over a gold-leaf apron carved with C-scrolls and bead rows, on fluted cabriole legs. A cut-crystal carafe of water and two tumblers with ice and lemon on a gold tray, a vase of layered roses with buds, leaves and baby\u2019s breath, and a leather book with a gilt title."))).V).Put("LIV-083", NewObj(3).Put("spec", ((V)("liquid26"))).Put("live", ((V)(""))).Put("note", ((V)("A mirror-chrome console that looks poured: its legs flow up like liquid metal into the top, reflecting the room, with drips frozen under the edge. A dark glass vase with a dried branch and a chrome droplet on top."))).V).Put("LIV-088", NewObj(2).Put("spec", ((V)("chrono26"))).Put("note", ((V)("A black marble plinth with white veins and a brass inlay. On the left a navy enamel clock sphere with a white dial and ticking hands floats over a glowing magnetic pad, held in three brass armillary rings that circle it. On the right a real iron meteorite, pitted and rusty, with a polished cut face showing its silver crystal pattern, on a walnut stand."))).V).Put("LIV-100", NewObj(1).Put("spec", ((V)("terra26"))).V).V);
edit25_89 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis3580, int _argc3573, V rows_3579, V _a3576, V _a3577, V _a3578, V[] _rest3574) => {
return Invoke(Call(edit25_89, V.Undef, rows_3579), "map", Fn((V _arrowThis3588, int _argc3581, V r_3587, V _a3584, V _a3585, V _a3586, V[] _rest3582) => {
return (Truthy(GetK(Get(RD_8, "SET26"), Get(r_3587, "id"))) ? Object_assign(NewObj(0).V, r_3587, GetK(Get(RD_8, "SET26"), Get(r_3587, "id"))) : r_3587);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "PLUS26", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
