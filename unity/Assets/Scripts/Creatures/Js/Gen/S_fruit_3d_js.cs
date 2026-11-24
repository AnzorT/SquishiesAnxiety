// fruit-3d.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_fruit_3d_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("^url\\(#l", "");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V SN_8 = default;
V M_9 = default;
V el_10 = default;
V pt_11 = default;
V polyD_12 = default;
V polyW_13 = default;
V circD_14 = default;
V runs_15 = default;
V clamp_16 = default;
V SM_17 = default;
V r2_18 = default;
V rnd_19 = default;
V subs_20 = default;
V decD_21 = default;
double TAU_22 = 0;
V SA_23 = default;
V REV_24 = default;
V SIL_25 = default;
V PEL_26 = default;
V fade_27 = default;
V ROLLF_28 = default;
V DECS_29 = default;
V decDraw_30 = default;
V FIX_31 = default;
V fixDraw_32 = default;
V SHINE_33 = default;
V SCAT_34 = default;
V faceAvoid_35 = default;
V dotsDraw_36 = default;
V fibDraw_37 = default;
V ridgeDraw_38 = default;
V TOPS_39 = default;
V topDraw_40 = default;
V FRUIT_41 = default;
V isTag_42 = default;
V SEPALS_43 = default;
V sepalDraw_44 = default;
double NTF_45 = 0;
V NC_46 = default;
V NW_47 = default;
V NT_48 = default;
V inDc_49 = default;
if (_self1.IsNullish) _self1 = GlobalV;
inDc_49 = Fn((V _self50, int _argc51, V q_57, V _a54, V _a55, V _a56, V[] _rest52) => {
if (_self50.IsNullish) _self50 = GlobalV;
return (!(!(Truthy((Get(Get(q_57, "e"), "closest") is var _t58 && !Truthy(_t58) ? _t58 : Invoke(Get(q_57, "e"), "closest", ((V)("[data-k=\"dc\"]"))))))) ? V.True : V.False);
return default;
}, 1, "inDc", false);
SN_8 = Get(G("window"), "SN3D");
if (Truthy(((!(Truthy(SN_8)) ? V.True : V.False) is var _t59 && Truthy(_t59) ? _t59 : Get(SN_8, "FRUIT")))) {
return default;
}
Set(SN_8, "FRUIT", ((V)(1D)));
M_9 = Get(SN_8, "MODELS");
{ V _t60 = Get(SN_8, "h");
if (_t60.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t60));
{ V _t61 = Get(_t60, "el");
el_10 = _t61; }
{ V _t62 = Get(_t60, "pt");
pt_11 = _t62; }
{ V _t63 = Get(_t60, "polyD");
polyD_12 = _t63; }
{ V _t64 = Get(_t60, "polyW");
polyW_13 = _t64; }
{ V _t65 = Get(_t60, "circD");
circD_14 = _t65; }
{ V _t66 = Get(_t60, "runs");
runs_15 = _t66; }
{ V _t67 = Get(_t60, "clamp");
clamp_16 = _t67; }
{ V _t68 = Get(_t60, "SM");
SM_17 = _t68; }
{ V _t69 = Get(_t60, "r2");
r2_18 = _t69; }
{ V _t70 = Get(_t60, "rnd");
rnd_19 = _t70; }
{ V _t71 = Get(_t60, "subs");
subs_20 = _t71; }
{ V _t72 = Get(_t60, "decD");
decD_21 = _t72; } }
TAU_22 = (System.Math.PI * 2D);
SA_23 = Fn((V _self1, int _argc73, V e_79, V k_80, V v_81, V _a78, V[] _rest74) => {
if (!SEq(GetK(e_79, ((V)(string.Concat("_", ToStr(k_80))))), v_81)) {
SetK(e_79, ((V)(string.Concat("_", ToStr(k_80)))), v_81);
Invoke(e_79, "setAttribute", k_80, v_81);
}
return default;
}, 3, "", true);
REV_24 = Fn((V _self1, int _argc82, V S_88, V o_89, V _a86, V _a87, V[] _rest83) => {
V O_90 = default;
V yT_91 = default;
V yB_92 = default;
V ext_93 = default;
double N_94 = 0;
V RR_95 = default;
V CX_96 = default;
V look_97 = default;
V kz_98 = default;
V cx_99 = default;
V rT_100 = default;
V dr_101 = default;
V rmax_102 = default;
V zAt_103 = default;
V at_104 = default;
V fOf_105 = default;
O_90 = Invoke(S_88, "outline", Get(S_88, "sk"), (Get(o_89, "n") is var _t106 && Truthy(_t106) ? _t106 : ((V)(96D))));
yT_91 = ((V)(1000000000D));
yB_92 = ((V)((-1000000000D)));
Invoke(O_90, "forEach", Fn((V _self1, int _argc107, V p_113, V _a110, V _a111, V _a112, V[] _rest108) => {
if (Lt(GetIdx(p_113, 1D), yT_91)) {
yT_91 = GetIdx(p_113, 1D);
}
if (Gt(GetIdx(p_113, 1D), yB_92)) {
yB_92 = GetIdx(p_113, 1D);
}
return default;
}, 1, "", true));
ext_93 = Fn((V _self1, int _argc114, V y_120, V _a117, V _a118, V _a119, V[] _rest115) => {
V lo_121 = default;
V hi_122 = default;
lo_121 = ((V)(1000000000D));
hi_122 = ((V)((-1000000000D)));
{
double i_123 = 0;
i_123 = 0D;
while (true) {
if (!(Lt(((V)(i_123)), Get(O_90, "length")))) break;
V a_125 = default;
V b_126 = default;
a_125 = GetIdx(O_90, i_123);
b_126 = GetIdx(O_90, ((i_123 + 1D) % ToNum(Get(O_90, "length"))));
if (((((ToNum(GetIdx(a_125, 1D)) - ToNum(y_120)) * (ToNum(GetIdx(b_126, 1D)) - ToNum(y_120))) <= 0D) && !SEq(GetIdx(a_125, 1D), GetIdx(b_126, 1D)))) {
V x_127 = default;
x_127 = Add(GetIdx(a_125, 0D), ((V)((((ToNum(GetIdx(b_126, 0D)) - ToNum(GetIdx(a_125, 0D))) * (ToNum(y_120) - ToNum(GetIdx(a_125, 1D)))) / (ToNum(GetIdx(b_126, 1D)) - ToNum(GetIdx(a_125, 1D)))))));
if (Lt(x_127, lo_121)) {
lo_121 = x_127;
}
if (Gt(x_127, hi_122)) {
hi_122 = x_127;
}
}
i_123++;
}
}
return (Lt(hi_122, lo_121) ? Arr(((V)(50D)), ((V)(50D))) : Arr(lo_121, hi_122));
return default;
}, 1, "", true);
N_94 = System.Math.Ceiling(((ToNum(yB_92) - ToNum(yT_91)) / 0.5));
RR_95 = Arr();
CX_96 = Arr();
{
double i_128 = 0;
i_128 = 0D;
while (true) {
if (!((i_128 <= N_94))) break;
V e_130 = default;
e_130 = Call(ext_93, V.Undef, ((V)(Min(ToNum(yB_92), ToNum(Add(yT_91, ((V)((i_128 * 0.5)))))))));
Invoke(RR_95, "push", ((V)(((ToNum(GetIdx(e_130, 1D)) - ToNum(GetIdx(e_130, 0D))) / 2D))));
Invoke(CX_96, "push", ((V)((ToNum(Add(GetIdx(e_130, 0D), GetIdx(e_130, 1D))) / 2D))));
i_128++;
}
}
look_97 = Fn((V _self1, int _argc131, V A_137, V y_138, V _a135, V _a136, V[] _rest132) => {
V u_139 = default;
double i_140 = 0;
double f_141 = 0;
u_139 = Call(clamp_16, V.Undef, ((V)(((ToNum(y_138) - ToNum(yT_91)) / 0.5))), ((V)(0D)), ((V)(N_94)));
i_140 = Min((N_94 - 1D), System.Math.Floor(ToNum(u_139)));
f_141 = (ToNum(u_139) - i_140);
return Add(GetIdx(A_137, i_140), ((V)(((ToNum(GetIdx(A_137, (i_140 + 1D))) - ToNum(GetIdx(A_137, i_140))) * f_141))));
return default;
}, 2, "", true);
kz_98 = (Get(o_89, "kz") is var _t142 && Truthy(_t142) ? _t142 : ((V)(1D)));
cx_99 = (SEqS(Get(o_89, "cx"), "mid") ? Fn((V _self1, int _argc143, V y_149, V _a146, V _a147, V _a148, V[] _rest144) => {
return Call(look_97, V.Undef, CX_96, y_149);
}, 1, "", true) : Fn((V _self1, int _argc150, V _a152, V _a153, V _a154, V _a155, V[] _rest151) => {
return (Get(o_89, "cx") is var _t156 && Truthy(_t156) ? _t156 : ((V)(50D)));
}, 0, "", true));
rT_100 = Fn((V _self1, int _argc157, V y_163, V _a160, V _a161, V _a162, V[] _rest158) => {
return Call(look_97, V.Undef, RR_95, y_163);
}, 1, "", true);
dr_101 = Fn((V _self1, int _argc164, V y_170, V _a167, V _a168, V _a169, V[] _rest165) => {
return ((V)((ToNum(Call(rT_100, V.Undef, Add(y_170, ((V)(0.5))))) - ToNum(Call(rT_100, V.Undef, ((V)((ToNum(y_170) - 0.5))))))));
}, 1, "", true);
rmax_102 = ((V)(0D));
Invoke(RR_95, "forEach", Fn((V _self1, int _argc171, V r_177, V _a174, V _a175, V _a176, V[] _rest172) => {
if (Gt(r_177, rmax_102)) {
rmax_102 = r_177;
}
return default;
}, 1, "", true));
zAt_103 = Fn((V _self1, int _argc178, V x_184, V y_185, V _a182, V _a183, V[] _rest179) => {
V r_186 = default;
double d_187 = 0;
r_186 = Call(rT_100, V.Undef, y_185);
d_187 = (ToNum(x_184) - ToNum(Call(cx_99, V.Undef, y_185)));
return ((V)((((d_187 * d_187) < (ToNum(r_186) * ToNum(r_186))) ? (ToNum(kz_98) * System.Math.Sqrt(((ToNum(r_186) * ToNum(r_186)) - (d_187 * d_187)))) : 0D)));
return default;
}, 2, "", true);
at_104 = Fn((V _self1, int _argc188, V f_194, V y_195, V lift_196, V _a193, V[] _rest189) => {
V r_197 = default;
double s_198 = 0;
double c_199 = 0;
double nx_200 = 0;
double nz_201 = 0;
double ny_202 = 0;
V L_203 = default;
r_197 = Add(Call(rT_100, V.Undef, y_195), (lift_196 is var _t204 && Truthy(_t204) ? _t204 : ((V)(0D))));
s_198 = FdLibm.Sin(ToNum(f_194));
c_199 = FdLibm.Cos(ToNum(f_194));
nx_200 = s_198;
nz_201 = (c_199 / ToNum(kz_98));
ny_202 = (-ToNum(Call(dr_101, V.Undef, y_195)));
L_203 = (((V)(Hypot(nx_200, ny_202, nz_201))) is var _t205 && Truthy(_t205) ? _t205 : ((V)(1D)));
return Arr(Add(Call(cx_99, V.Undef, y_195), ((V)((ToNum(r_197) * s_198)))), y_195, ((V)(((ToNum(kz_98) * ToNum(r_197)) * c_199))), ((V)((nx_200 / ToNum(L_203)))), ((V)((ny_202 / ToNum(L_203)))), ((V)((nz_201 / ToNum(L_203)))));
return default;
}, 3, "", true);
fOf_105 = Fn((V _self1, int _argc206, V x_212, V y_213, V _a210, V _a211, V[] _rest207) => {
V r_214 = default;
r_214 = Call(rT_100, V.Undef, y_213);
return ((V)(FdLibm.Asin(ToNum(Call(clamp_16, V.Undef, ((V)(((ToNum(x_212) - ToNum(Call(cx_99, V.Undef, y_213))) / ToNum((r_214 is var _t215 && Truthy(_t215) ? _t215 : ((V)(1D))))))), ((V)((-1D))), ((V)(1D)))))));
return default;
}, 2, "", true);
return NewObj(10).Put("O", O_90).Put("yT", yT_91).Put("yB", yB_92).Put("rT", rT_100).Put("cx", cx_99).Put("kz", kz_98).Put("zAt", zAt_103).Put("at", at_104).Put("fOf", fOf_105).Put("rmax", rmax_102).V;
return default;
}, 2, "", true);
SIL_25 = Fn((V _self1, int _argc216, V D_222, V R_223, V _a220, V _a221, V[] _rest217) => {
V P3_224 = default;
double n_225 = 0;
double st_226 = 0;
V G_227 = default;
P3_224 = Get(D_222, "P3");
n_225 = Max(2D, System.Math.Ceiling(((ToNum(Get(R_223, "yB")) - ToNum(Get(R_223, "yT"))) / 2.5)));
st_226 = ((ToNum(Get(R_223, "yB")) - ToNum(Get(R_223, "yT"))) / n_225);
G_227 = Arr();
{
double i_228 = 0;
i_228 = 0D;
while (true) {
if (!((i_228 <= n_225))) break;
V y_230 = default;
V cx_231 = default;
V c_232 = default;
V e1_233 = default;
V e2_234 = default;
V a_235 = default;
double E1x_236 = 0;
double E1y_237 = 0;
double E2x_238 = 0;
double E2y_239 = 0;
double Ax_240 = 0;
double Ay_241 = 0;
V L_242 = default;
double nx_243 = 0;
double ny_244 = 0;
double an_245 = 0;
double ca_246 = 0;
double sa_247 = 0;
y_230 = Add(Get(R_223, "yT"), ((V)((i_228 * st_226))));
cx_231 = Invoke(R_223, "cx", y_230);
c_232 = Call(P3_224, V.Undef, cx_231, y_230, ((V)(0D)));
e1_233 = Call(P3_224, V.Undef, Add(cx_231, ((V)(1D))), y_230, ((V)(0D)));
e2_234 = Call(P3_224, V.Undef, cx_231, y_230, Get(R_223, "kz"));
a_235 = Call(P3_224, V.Undef, cx_231, Add(y_230, ((V)(1D))), ((V)(0D)));
E1x_236 = (ToNum(GetIdx(e1_233, 0D)) - ToNum(GetIdx(c_232, 0D)));
E1y_237 = (ToNum(GetIdx(e1_233, 1D)) - ToNum(GetIdx(c_232, 1D)));
E2x_238 = (ToNum(GetIdx(e2_234, 0D)) - ToNum(GetIdx(c_232, 0D)));
E2y_239 = (ToNum(GetIdx(e2_234, 1D)) - ToNum(GetIdx(c_232, 1D)));
Ax_240 = (ToNum(GetIdx(a_235, 0D)) - ToNum(GetIdx(c_232, 0D)));
Ay_241 = (ToNum(GetIdx(a_235, 1D)) - ToNum(GetIdx(c_232, 1D)));
L_242 = (((V)(Hypot(Ax_240, Ay_241))) is var _t248 && Truthy(_t248) ? _t248 : ((V)(1D)));
nx_243 = (Ay_241 / ToNum(L_242));
ny_244 = ((-Ax_240) / ToNum(L_242));
an_245 = FdLibm.Atan2(((nx_243 * E2x_238) + (ny_244 * E2y_239)), ((nx_243 * E1x_236) + (ny_244 * E1y_237)));
ca_246 = FdLibm.Cos(an_245);
sa_247 = FdLibm.Sin(an_245);
Invoke(G_227, "push", Arr(GetIdx(c_232, 0D), GetIdx(c_232, 1D), ((V)(((E1x_236 * ca_246) + (E2x_238 * sa_247)))), ((V)(((E1y_237 * ca_246) + (E2y_239 * sa_247))))));
i_228++;
}
}
return Call(polyD_12, V.Undef, Invoke(Get(R_223, "O"), "map", Fn((V _self1, int _argc249, V p_255, V _a252, V _a253, V _a254, V[] _rest250) => {
V u_256 = default;
double i_257 = 0;
double f_258 = 0;
V A_259 = default;
V B_260 = default;
double d_261 = 0;
V q_262 = default;
u_256 = Call(clamp_16, V.Undef, ((V)(((ToNum(GetIdx(p_255, 1D)) - ToNum(Get(R_223, "yT"))) / st_226))), ((V)(0D)), ((V)(n_225)));
i_257 = Min((n_225 - 1D), System.Math.Floor(ToNum(u_256)));
f_258 = (ToNum(u_256) - i_257);
A_259 = GetIdx(G_227, i_257);
B_260 = GetIdx(G_227, (i_257 + 1D));
d_261 = (ToNum(GetIdx(p_255, 0D)) - ToNum(Invoke(R_223, "cx", GetIdx(p_255, 1D))));
q_262 = Fn((V _self1, int _argc263, V k_269, V _a266, V _a267, V _a268, V[] _rest264) => {
return Add(GetK(A_259, k_269), ((V)(((ToNum(GetK(B_260, k_269)) - ToNum(GetK(A_259, k_269))) * f_258))));
}, 1, "", true);
return Arr(Add(Call(q_262, V.Undef, ((V)(0D))), ((V)((d_261 * ToNum(Call(q_262, V.Undef, ((V)(2D)))))))), Add(Call(q_262, V.Undef, ((V)(1D))), ((V)((d_261 * ToNum(Call(q_262, V.Undef, ((V)(3D)))))))));
return default;
}, 1, "", true)));
return default;
}, 2, "", true);
PEL_26 = Fn((V _self1, int _argc270, V D_276, V EL_277, V ax_278, V ay_279, V[] _rest271) => {
return Fn((V _self1, int _argc280, V x_286, V y_287, V z_288, V _a285, V[] _rest281) => {
V p_289 = default;
p_289 = Invoke(D_276, "P3", x_286, y_287, z_288);
return Arr(GetIdx(p_289, 0D), Add(GetIdx(p_289, 1D), ((V)((ToNum(EL_277) * (ToNum(Invoke(D_276, "Z3", x_286, y_287, z_288)) - ToNum(Invoke(D_276, "Z3", ax_278, ay_279, ((V)(0D))))))))));
return default;
}, 3, "", true);
}, 4, "", true);
fade_27 = Fn((V _self1, int _argc290, V f_296, V a_297, V w_298, V _a295, V[] _rest291) => {
return Call(SM_17, V.Undef, ((V)(((ToNum(f_296) - ToNum(a_297)) / ToNum(w_298)))));
}, 3, "", true);
ROLLF_28 = Fn((V _self1, int _argc299, V R_305, V cy0_306, V _a303, V _a304, V[] _rest300) => {
V OS_307 = default;
OS_307 = Invoke(Get(R_305, "O"), "filter", Fn((V _self1, int _argc308, V p_314, V i_315, V _a312, V _a313, V[] _rest309) => {
return (((ToNum(i_315) % 3D) == 0D) ? V.True : V.False);
}, 2, "", true));
return Fn((V _self1, int _argc316, V a_322, V P_323, V G_324, V sy_325, V[] _rest317) => {
double c_326 = 0;
double s_327 = 0;
V lf_328 = default;
V px_329 = default;
V cx_330 = default;
double cy_331 = 0;
double my_332 = 0;
c_326 = FdLibm.Cos(ToNum(a_322));
s_327 = FdLibm.Sin(ToNum(a_322));
lf_328 = (((V)(ToNum(Get(P_323, "lift")))) is var _t333 && Truthy(_t333) ? _t333 : ((V)(0D)));
px_329 = (((V)(ToNum(Get(P_323, "x")))) is var _t334 && Truthy(_t334) ? _t334 : ((V)(0D)));
cx_330 = Add(((V)(50D)), px_329);
cy_331 = ((ToNum(G_324) - ToNum(lf_328)) - ((ToNum(G_324) - ToNum(cy0_306)) * ToNum(sy_325)));
my_332 = (-1000000000D);
Invoke(OS_307, "forEach", Fn((V _self1, int _argc335, V p_341, V _a338, V _a339, V _a340, V[] _rest336) => {
V gx_342 = default;
double gy_343 = 0;
double y_344 = 0;
gx_342 = Add(GetIdx(p_341, 0D), px_329);
gy_343 = ((ToNum(G_324) - ToNum(lf_328)) - ((ToNum(G_324) - ToNum(GetIdx(p_341, 1D))) * ToNum(sy_325)));
y_344 = ((cy_331 + ((ToNum(gx_342) - ToNum(cx_330)) * s_327)) + ((gy_343 - cy_331) * c_326));
if ((y_344 > my_332)) {
my_332 = y_344;
}
return default;
}, 1, "", true));
return NewObj(5).Put("c", ((V)(c_326))).Put("s", ((V)(s_327))).Put("cx", cx_330).Put("cy", ((V)(cy_331))).Put("up", ((V)((my_332 - (ToNum(G_324) - ToNum(lf_328)))))).V;
return default;
}, 4, "", true);
return default;
}, 2, "", true);
DECS_29 = Fn((V _self1, int _argc345, V S_351, V R_352, V pred_353, V copies_354, V[] _rest346) => {
V @out_356 = default;
V par_355 = default;
par_355 = (_argc345 > 4 ? _rest346[0] : V.Undef);
@out_356 = Arr();
Invoke(Invoke(S_351, "decals", pred_353, par_355), "forEach", Fn((V _self1, int _argc357, V o_363, V _a360, V _a361, V _a362, V[] _rest358) => {
V sx_364 = default;
V sy_365 = default;
double n_366 = 0;
V c_367 = default;
double op_368 = 0;
V line_369 = default;
sx_364 = ((V)(0D));
sy_365 = ((V)(0D));
n_366 = 0D;
Invoke(Get(o_363, "L"), "forEach", Fn((V _self1, int _argc370, V L_376, V _a373, V _a374, V _a375, V[] _rest371) => {
return Invoke(L_376, "forEach", Fn((V _self1, int _argc377, V p_383, V _a380, V _a381, V _a382, V[] _rest378) => {
sx_364 = Add(sx_364, GetIdx(p_383, 0D));
sy_365 = Add(sy_365, GetIdx(p_383, 1D));
n_366++;
return default;
}, 1, "", true));
}, 1, "", true));
c_367 = Arr(((V)((ToNum(sx_364) / ToNum((((V)(n_366)) is var _t384 && Truthy(_t384) ? _t384 : ((V)(1D))))))), ((V)((ToNum(sy_365) / ToNum((((V)(n_366)) is var _t385 && Truthy(_t385) ? _t385 : ((V)(1D))))))));
op_368 = ToNum((Invoke(Get(o_363, "e"), "getAttribute", ((V)("opacity"))) is var _t386 && Truthy(_t386) ? _t386 : ((V)(1D))));
line_369 = (SEqS((Invoke(Get(o_363, "e"), "getAttribute", ((V)("fill"))) is var _t387 && Truthy(_t387) ? _t387 : ((V)(""))), "none") ? V.True : V.False);
Invoke((copies_354 is var _t397 && Truthy(_t397) ? _t397 : Arr(((V)(0D)))), "forEach", Fn((V _self1, int _argc388, V dA_394, V i_395, V _a392, V _a393, V[] _rest389) => {
V e_396 = default;
e_396 = (Truthy(i_395) ? Invoke(Get(Get(o_363, "e"), "parentNode"), "insertBefore", Invoke(Get(o_363, "e"), "cloneNode"), Get(Get(o_363, "e"), "nextSibling")) : Get(o_363, "e"));
Invoke(@out_356, "push", NewObj(6).Put("e", e_396).Put("L", Get(o_363, "L")).Put("c", c_367).Put("op", ((V)(op_368))).Put("dA", dA_394).Put("line", line_369).V);
return default;
}, 2, "", true));
return default;
}, 1, "", true));
return @out_356;
return default;
}, 5, "", true);
decDraw_30 = Fn((V _self1, int _argc398, V D_404, V R_405, V list_406, V _a403, V[] _rest399) => {
return Invoke(list_406, "forEach", Fn((V _self1, int _argc407, V o_413, V _a410, V _a411, V _a412, V[] _rest408) => {
V f0_414 = default;
V s_415 = default;
V v_416 = default;
V map_417 = default;
f0_414 = Add(Invoke(R_405, "fOf", GetIdx(Get(o_413, "c"), 0D), GetIdx(Get(o_413, "c"), 1D)), Get(o_413, "dA"));
s_415 = Invoke(R_405, "at", f0_414, GetIdx(Get(o_413, "c"), 1D));
v_416 = Call(fade_27, V.Undef, Invoke(D_404, "facing", GetIdx(s_415, 0D), GetIdx(s_415, 1D), GetIdx(s_415, 2D), GetIdx(s_415, 3D), GetIdx(s_415, 4D), GetIdx(s_415, 5D)), ((V)(0.02)), ((V)(0.28)));
if (LtN(v_416, 0.01)) {
if (!SEqN(Get(o_413, "on"), 0D)) {
Set(o_413, "on", ((V)(0D)));
Invoke(Get(o_413, "e"), "setAttribute", ((V)("opacity")), ((V)(0D)));
}
return default;
}
Set(o_413, "on", ((V)(1D)));
Call(SA_23, V.Undef, Get(o_413, "e"), ((V)("opacity")), Call(r2_18, V.Undef, ((V)((ToNum(Get(o_413, "op")) * ToNum(v_416))))));
map_417 = Fn((V _self1, int _argc418, V x_424, V y_425, V _a422, V _a423, V[] _rest419) => {
V p_426 = default;
p_426 = Invoke(R_405, "at", Add(Invoke(R_405, "fOf", x_424, y_425), Get(o_413, "dA")), y_425, ((V)(0.12)));
return Invoke(D_404, "P3", GetIdx(p_426, 0D), GetIdx(p_426, 1D), GetIdx(p_426, 2D));
return default;
}, 2, "", true);
if (Truthy(Get(o_413, "line"))) {
V d_427 = default;
d_427 = ((V)(""));
Invoke(Get(o_413, "L"), "forEach", Fn((V _self1, int _argc428, V L_434, V _a431, V _a432, V _a433, V[] _rest429) => {
V Q_435 = default;
V ok_436 = default;
Q_435 = Arr();
ok_436 = Arr();
Invoke(L_434, "forEach", Fn((V _self1, int _argc437, V _a439, V _a440, V _a441, V _a442, V[] _rest438) => {
V p_448 = default;
V x_445 = default;
V y_447 = default;
{ V _t443 = ListOf(_a439);
{ V _t444 = GetIdx(_t443, 0D);
x_445 = _t444; }
{ V _t446 = GetIdx(_t443, 1D);
y_447 = _t446; }
}
p_448 = Invoke(R_405, "at", Add(Invoke(R_405, "fOf", x_445, y_447), Get(o_413, "dA")), y_447, ((V)(0.12)));
Invoke(Q_435, "push", Invoke(D_404, "P3", GetIdx(p_448, 0D), GetIdx(p_448, 1D), GetIdx(p_448, 2D)));
Invoke(ok_436, "push", (GtN(Invoke(D_404, "facing", GetIdx(p_448, 0D), GetIdx(p_448, 1D), GetIdx(p_448, 2D), GetIdx(p_448, 3D), GetIdx(p_448, 4D), GetIdx(p_448, 5D)), 0.03) ? V.True : V.False));
return default;
}, 1, "", true));
d_427 = Add(d_427, Call(runs_15, V.Undef, Q_435, ok_436));
return default;
}, 1, "", true));
Invoke(Get(o_413, "e"), "setAttribute", ((V)("d")), (d_427 is var _t449 && Truthy(_t449) ? _t449 : ((V)("M0 0"))));
} else {
Invoke(Get(o_413, "e"), "setAttribute", ((V)("d")), Call(decD_21, V.Undef, o_413, map_417));
}
return default;
}, 1, "", true));
}, 3, "", true);
FIX_31 = Fn((V _self1, int _argc450, V S_456, V pred_457, V par_458, V _a455, V[] _rest451) => {
return Invoke(Invoke(S_456, "decals", pred_457, par_458), "map", Fn((V _self1, int _argc459, V o_465, V _a462, V _a463, V _a464, V[] _rest460) => {
return o_465;
}, 1, "", true));
}, 3, "", true);
fixDraw_32 = Fn((V _self1, int _argc466, V D_472, V list_473, V _a470, V _a471, V[] _rest467) => {
return Invoke(list_473, "forEach", Fn((V _self1, int _argc474, V o_480, V _a477, V _a478, V _a479, V[] _rest475) => {
return Invoke(Get(o_480, "e"), "setAttribute", ((V)("d")), Call(decD_21, V.Undef, o_480, Fn((V _self1, int _argc481, V x_487, V y_488, V _a485, V _a486, V[] _rest482) => {
return Invoke(D_472, "glob", x_487, y_488);
}, 2, "", true)));
}, 1, "", true));
}, 2, "", true);
SHINE_33 = Fn((V _self1, int _argc489, V S_495, V _a492, V _a493, V _a494, V[] _rest490) => {
return Invoke(Invoke(S_495, "hide", Fn((V _self1, int _argc506, V q_512, V _a509, V _a510, V _a511, V[] _rest507) => {
return ((SEqS(Get(q_512, "role"), "shine") && !(Truthy(Get(q_512, "inBody")))) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _self1, int _argc496, V q_502, V _a499, V _a500, V _a501, V[] _rest497) => {
V e_503 = default;
e_503 = Call(el_10, V.Undef, ((V)("path")), NewObj(2).Put("fill", (Invoke(Get(q_502, "e"), "getAttribute", ((V)("fill"))) is var _t504 && Truthy(_t504) ? _t504 : ((V)("#fff")))).Put("opacity", (Invoke(Get(q_502, "e"), "getAttribute", ((V)("opacity"))) is var _t505 && Truthy(_t505) ? _t505 : ((V)(0.85)))).V, Get(Get(q_502, "e"), "parentNode"), Get(q_502, "e"));
return NewObj(2).Put("e", e_503).Put("L", Call(subs_20, V.Undef, Get(q_502, "segs"), ((V)(8D)))).V;
return default;
}, 1, "", true));
}, 1, "", true);
SCAT_34 = Fn((V _self1, int _argc513, V R_519, V n_520, V seed_521, V min_522, V[] _rest514) => {
V @out_524 = default;
V avoid_523 = default;
avoid_523 = (_argc513 > 4 ? _rest514[0] : V.Undef);
@out_524 = Arr();
{
double k_525 = 0;
k_525 = 0D;
while (true) {
if (!((Lt(Get(@out_524, "length"), n_520) && (k_525 < (ToNum(n_520) * 60D))))) break;
V y_527 = default;
double f_528 = 0;
V p_529 = default;
y_527 = Add(Add(Get(R_519, "yT"), ((V)(2.5))), ((V)((ToNum(Call(rnd_19, V.Undef, Add(seed_521, ((V)((k_525 * 1.31)))))) * ((ToNum(Get(R_519, "yB")) - ToNum(Get(R_519, "yT"))) - 5D)))));
f_528 = (((ToNum(Call(rnd_19, V.Undef, Add(seed_521, ((V)((k_525 * 2.77)))))) * 2D) - 1D) * System.Math.PI);
if (GtN(Call(rnd_19, V.Undef, Add(seed_521, ((V)((k_525 * 5.13))))), (ToNum(Invoke(R_519, "rT", y_527)) / ToNum(Get(R_519, "rmax"))))) {
goto _cont526;
}
if (Truthy((avoid_523 is var _t530 && !Truthy(_t530) ? _t530 : Call(avoid_523, V.Undef, ((V)(f_528)), y_527)))) {
goto _cont526;
}
p_529 = Invoke(R_519, "at", ((V)(f_528)), y_527);
if (Truthy(Invoke(@out_524, "some", Fn((V _self1, int _argc531, V q_537, V _a534, V _a535, V _a536, V[] _rest532) => {
return (Lt(((V)(Hypot((ToNum(GetIdx(Get(q_537, "p"), 0D)) - ToNum(GetIdx(p_529, 0D))), (ToNum(GetIdx(Get(q_537, "p"), 1D)) - ToNum(GetIdx(p_529, 1D))), (ToNum(GetIdx(Get(q_537, "p"), 2D)) - ToNum(GetIdx(p_529, 2D)))))), min_522) ? V.True : V.False);
}, 1, "", true)))) {
goto _cont526;
}
Invoke(@out_524, "push", NewObj(4).Put("f", ((V)(f_528))).Put("y", y_527).Put("p", p_529).Put("k", Call(rnd_19, V.Undef, Add(seed_521, ((V)((k_525 * 7.7)))))).V);
_cont526: ;
k_525++;
}
}
return @out_524;
return default;
}, 5, "", true);
faceAvoid_35 = Fn((V _self1, int _argc538, V y0_544, V y1_545, V fw_546, V _a543, V[] _rest539) => {
return Fn((V _self1, int _argc547, V f_553, V y_554, V _a551, V _a552, V[] _rest548) => {
return (((Lt(((V)(System.Math.Abs(ToNum(f_553)))), (fw_546 is var _t555 && Truthy(_t555) ? _t555 : ((V)(0.72)))) && Gt(y_554, y0_544)) && Lt(y_554, y1_545)) ? V.True : V.False);
}, 2, "", true);
}, 3, "", true);
dotsDraw_36 = Fn((V _self1, int _argc556, V D_562, V R_563, V o_564, V _a561, V[] _rest557) => {
V d_565 = default;
double r_566 = 0;
d_565 = ((V)(""));
r_566 = (ToNum(Get(o_564, "r")) * ToNum(Get(D_562, "kS")));
Invoke(Get(o_564, "P"), "forEach", Fn((V _self1, int _argc567, V s_573, V _a570, V _a571, V _a572, V[] _rest568) => {
V p_574 = default;
p_574 = Invoke(R_563, "at", Get(s_573, "f"), Get(s_573, "y"), ((V)(0.1)));
if (LtN(Invoke(D_562, "facing", GetIdx(p_574, 0D), GetIdx(p_574, 1D), GetIdx(p_574, 2D), GetIdx(p_574, 3D), GetIdx(p_574, 4D), GetIdx(p_574, 5D)), 0.1)) {
return default;
}
d_565 = Add(d_565, Call(circD_14, V.Undef, Invoke(D_562, "P3", GetIdx(p_574, 0D), GetIdx(p_574, 1D), GetIdx(p_574, 2D)), ((V)((r_566 * (0.8 + (ToNum(Get(s_573, "k")) * 0.4)))))));
return default;
}, 1, "", true));
Call(SA_23, V.Undef, Get(o_564, "e"), ((V)("d")), (d_565 is var _t575 && Truthy(_t575) ? _t575 : ((V)("M0 0"))));
return default;
}, 3, "", true);
fibDraw_37 = Fn((V _self1, int _argc576, V D_582, V R_583, V o_584, V _a581, V[] _rest577) => {
V d_585 = default;
V fz_586 = default;
d_585 = ((V)(""));
fz_586 = Call(clamp_16, V.Undef, Invoke(D_582, "bv", ((V)("fz"))), ((V)(0D)), ((V)(1.3)));
Invoke(Get(o_584, "P"), "forEach", Fn((V _self1, int _argc587, V s_593, V _a590, V _a591, V _a592, V[] _rest588) => {
V p_594 = default;
double a_595 = 0;
double L_596 = 0;
V q_597 = default;
p_594 = Invoke(R_583, "at", Get(s_593, "f"), Get(s_593, "y"), ((V)(0.1)));
if (LtN(Invoke(D_582, "facing", GetIdx(p_594, 0D), GetIdx(p_594, 1D), GetIdx(p_594, 2D), GetIdx(p_594, 3D), GetIdx(p_594, 4D), GetIdx(p_594, 5D)), 0.12)) {
return default;
}
a_595 = (ToNum(Get(s_593, "k")) * TAU_22);
L_596 = ((1.8 + (ToNum(Get(s_593, "k")) * 1.2)) * (1D - (ToNum(fz_586) * 0.25)));
q_597 = Invoke(R_583, "at", Add(Get(s_593, "f"), ((V)(((FdLibm.Cos(a_595) * L_596) / Max(4D, ToNum(Invoke(R_583, "rT", Get(s_593, "y")))))))), Add(Get(s_593, "y"), ((V)((FdLibm.Sin(a_595) * L_596)))), ((V)((0.1 + (ToNum(fz_586) * (1.6 + (ToNum(Get(s_593, "k")) * 1.4)))))));
d_585 = ((V)(string.Concat(new string[] { ToStr(d_585), "M", ToStr(Call(pt_11, V.Undef, Invoke(D_582, "P3", GetIdx(p_594, 0D), GetIdx(p_594, 1D), GetIdx(p_594, 2D)))), "L", ToStr(Call(pt_11, V.Undef, Invoke(D_582, "P3", GetIdx(q_597, 0D), GetIdx(q_597, 1D), GetIdx(q_597, 2D)))) })));
return default;
}, 1, "", true));
Call(SA_23, V.Undef, Get(o_584, "e"), ((V)("d")), (d_585 is var _t598 && Truthy(_t598) ? _t598 : ((V)("M0 0"))));
return default;
}, 3, "", true);
ridgeDraw_38 = Fn((V _self1, int _argc599, V D_605, V R_606, V o_607, V _a604, V[] _rest600) => {
V d_608 = default;
d_608 = ((V)(""));
Invoke(Get(o_607, "F"), "forEach", Fn((V _self1, int _argc609, V f_615, V _a612, V _a613, V _a614, V[] _rest610) => {
V Q_616 = default;
V ok_617 = default;
Q_616 = Arr();
ok_617 = Arr();
{
V y_618 = default;
y_618 = Get(o_607, "y0");
while (true) {
if (!(Le(y_618, Get(o_607, "y1")))) break;
V p_620 = default;
p_620 = Invoke(R_606, "at", f_615, y_618, ((V)(0.05)));
Invoke(Q_616, "push", Invoke(D_605, "P3", GetIdx(p_620, 0D), GetIdx(p_620, 1D), GetIdx(p_620, 2D)));
Invoke(ok_617, "push", (GtN(Invoke(D_605, "facing", GetIdx(p_620, 0D), GetIdx(p_620, 1D), GetIdx(p_620, 2D), GetIdx(p_620, 3D), GetIdx(p_620, 4D), GetIdx(p_620, 5D)), 0.12) ? V.True : V.False));
y_618 = Add(y_618, ((V)(1.5)));
}
}
d_608 = Add(d_608, Call(runs_15, V.Undef, Q_616, ok_617));
return default;
}, 1, "", true));
Call(SA_23, V.Undef, Get(o_607, "e"), ((V)("d")), (d_608 is var _t621 && Truthy(_t621) ? _t621 : ((V)("M0 0"))));
return default;
}, 3, "", true);
TOPS_39 = Fn((V _self1, int _argc622, V S_628, V o_629, V _a626, V _a627, V[] _rest623) => {
V G_630 = default;
V L_631 = default;
double n_632 = 0;
G_630 = Invoke(S_628, "g");
L_631 = Invoke(Invoke(S_628, "decals", Fn((V _self1, int _argc660, V q_666, V _a663, V _a664, V _a665, V[] _rest661) => {
return Invoke(S_628, "dk", q_666, ((V)("top")));
}, 1, "", true), G_630), "map", Fn((V _self1, int _argc633, V d_639, V _a636, V _a637, V _a638, V[] _rest634) => {
if (Truthy(Invoke(NewRegExp(RX0, "^url\\(#l", ""), "test", (Invoke(Get(d_639, "e"), "getAttribute", ((V)("fill"))) is var _t640 && Truthy(_t640) ? _t640 : ((V)("")))))) {
V b_641 = default;
V tp_642 = default;
double md_643 = 0;
b_641 = GetIdx(GetIdx(Get(d_639, "L"), 0D), 0D);
tp_642 = b_641;
md_643 = 0D;
Invoke(Get(d_639, "L"), "forEach", Fn((V _self1, int _argc644, V Q_650, V _a647, V _a648, V _a649, V[] _rest645) => {
return Invoke(Q_650, "forEach", Fn((V _self1, int _argc651, V p_657, V _a654, V _a655, V _a656, V[] _rest652) => {
double m_658 = 0;
m_658 = Hypot((ToNum(GetIdx(p_657, 0D)) - ToNum(GetIdx(b_641, 0D))), (ToNum(GetIdx(p_657, 1D)) - ToNum(GetIdx(b_641, 1D))));
if ((m_658 > md_643)) {
md_643 = m_658;
tp_642 = p_657;
}
return default;
}, 1, "", true));
}, 1, "", true));
Set(d_639, "leaf", NewObj(3).Put("b", b_641).Put("tp", tp_642).Put("L", (((V)(md_643)) is var _t659 && Truthy(_t659) ? _t659 : ((V)(1D)))).V);
}
return d_639;
return default;
}, 1, "", true));
n_632 = 0D;
Invoke(L_631, "forEach", Fn((V _self1, int _argc667, V d_673, V _a670, V _a671, V _a672, V[] _rest668) => {
if (Truthy(Get(d_673, "leaf"))) {
Set(Get(d_673, "leaf"), "ro", ((V)(((ToNum((Get(o_629, "roll").IsNullish ? ((V)(0.5)) : Get(o_629, "roll"))) * (NumTruthy((n_632++ % 2D)) ? (-1D) : 1D)) * (Lt(GetIdx(Get(Get(d_673, "leaf"), "tp"), 0D), GetIdx(Get(Get(d_673, "leaf"), "b"), 0D)) ? (-1D) : 1D)))));
}
return default;
}, 1, "", true));
return NewObj(3).Put("G", G_630).Put("L", L_631).Put("o", o_629).V;
return default;
}, 2, "", true);
topDraw_40 = Fn((V _self1, int _argc674, V D_680, V T_681, V _a678, V _a679, V[] _rest675) => {
V o_682 = default;
V lf_683 = default;
V tw_684 = default;
V th_685 = default;
double c_686 = 0;
double s_687 = 0;
double tc_688 = 0;
double ts_689 = 0;
o_682 = Get(T_681, "o");
lf_683 = Call(clamp_16, V.Undef, Invoke(D_680, "bv", ((V)("lf"))), ((V)(0D)), ((V)(1.2)));
tw_684 = Call(clamp_16, V.Undef, Invoke(D_680, "bv", ((V)("stw"))), ((V)((-1D))), ((V)(1D)));
th_685 = Add(Add(Call(clamp_16, V.Undef, ((V)(((-ToNum(Get(D_680, "ox"))) * 0.045))), ((V)((-0.5))), ((V)(0.5))), ((V)((ToNum((Get(o_682, "wob").IsNullish ? ((V)(0.035)) : Get(o_682, "wob"))) * FdLibm.Sin((ToNum(Get(D_680, "ts")) * 1.6)))))), ((V)(((ToNum(lf_683) * 0.2) * FdLibm.Sin((ToNum(Get(D_680, "ts")) * 14D))))));
c_686 = FdLibm.Cos(ToNum(th_685));
s_687 = FdLibm.Sin(ToNum(th_685));
tc_688 = FdLibm.Cos((ToNum(tw_684) * System.Math.PI));
ts_689 = FdLibm.Sin((ToNum(tw_684) * System.Math.PI));
Invoke(Get(T_681, "L"), "forEach", Fn((V _self1, int _argc690, V d_696, V _a693, V _a694, V _a695, V[] _rest691) => {
V lv_697 = default;
double fl_698 = 0;
lv_697 = Get(d_696, "leaf");
fl_698 = (Truthy(lv_697) ? ((ToNum(lf_683) * 0.6) * FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_680, "ts")) * 17D))), GetIdx(Get(lv_697, "b"), 0D))))) : 0D);
Invoke(Get(d_696, "e"), "setAttribute", ((V)("d")), Call(decD_21, V.Undef, d_696, Fn((V _self1, int _argc699, V x_705, V y_706, V _a703, V _a704, V[] _rest700) => {
double z_707 = 0;
double dx_708 = 0;
double dy_709 = 0;
double X_710 = 0;
double Y_711 = 0;
double xx_712 = 0;
double zz_713 = 0;
z_707 = 0D;
if (Truthy(lv_697)) {
double vx_714 = 0;
double vy_715 = 0;
double w_716 = 0;
double u_717 = 0;
V ro_718 = default;
double k_719 = 0;
vx_714 = (ToNum(GetIdx(Get(lv_697, "tp"), 0D)) - ToNum(GetIdx(Get(lv_697, "b"), 0D)));
vy_715 = (ToNum(GetIdx(Get(lv_697, "tp"), 1D)) - ToNum(GetIdx(Get(lv_697, "b"), 1D)));
w_716 = ((((ToNum(x_705) - ToNum(GetIdx(Get(lv_697, "b"), 0D))) * vy_715) - ((ToNum(y_706) - ToNum(GetIdx(Get(lv_697, "b"), 1D))) * vx_714)) / ToNum(Get(lv_697, "L")));
u_717 = ((((ToNum(x_705) - ToNum(GetIdx(Get(lv_697, "b"), 0D))) * vx_714) + ((ToNum(y_706) - ToNum(GetIdx(Get(lv_697, "b"), 1D))) * vy_715)) / (ToNum(Get(lv_697, "L")) * ToNum(Get(lv_697, "L"))));
ro_718 = Get(lv_697, "ro");
k_719 = (1D - FdLibm.Cos(ToNum(ro_718)));
x_705 = ((V)((ToNum(x_705) - (((w_716 * vy_715) / ToNum(Get(lv_697, "L"))) * k_719))));
y_706 = Add(y_706, ((V)((((w_716 * vx_714) / ToNum(Get(lv_697, "L"))) * k_719))));
z_707 = ((((w_716 * FdLibm.Sin(ToNum(ro_718))) + ((ToNum((Get(o_682, "curl") is var _t720 && Truthy(_t720) ? _t720 : ((V)(0.12)))) * w_716) * w_716)) + (ToNum((Get(o_682, "lz") is var _t721 && Truthy(_t721) ? _t721 : ((V)(0D)))) * u_717)) + (((fl_698 * u_717) * u_717) * 3D));
}
dx_708 = (ToNum(x_705) - ToNum(Get(o_682, "ax")));
dy_709 = (ToNum(y_706) - ToNum(Get(o_682, "ay")));
X_710 = ((dx_708 * c_686) - (dy_709 * s_687));
Y_711 = ((dx_708 * s_687) + (dy_709 * c_686));
xx_712 = ((X_710 * tc_688) - (z_707 * ts_689));
zz_713 = ((X_710 * ts_689) + (z_707 * tc_688));
return Invoke(D_680, "P3", Add(Get(o_682, "ax"), ((V)(xx_712))), Add(Get(o_682, "ay"), ((V)(Y_711))), Add(((V)(zz_713)), (Get(o_682, "z") is var _t722 && Truthy(_t722) ? _t722 : ((V)(0D)))));
return default;
}, 2, "", true)));
return default;
}, 1, "", true));
return default;
}, 2, "", true);
FRUIT_41 = Fn((V _self1, int _argc723, V cfg_729, V _a726, V _a727, V _a728, V[] _rest724) => {
return NewObj(2).Put("setup", Fn((V _self730, int _argc731, V S_737, V _a734, V _a735, V _a736, V[] _rest732) => {
V R_738 = default;
V B_739 = default;
if (_self730.IsNullish) _self730 = GlobalV;
R_738 = Call(REV_24, V.Undef, S_737, cfg_729);
B_739 = NewObj(8).Put("R", R_738).Put("cfg", cfg_729).Put("rT", Get(R_738, "rT")).Put("zAt", Get(R_738, "zAt")).Put("rx", (Get(cfg_729, "rx") is var _t740 && Truthy(_t740) ? _t740 : ((V)(30D)))).Put("ya", Add(Get(R_738, "yT"), ((V)(5D)))).Put("yb", ((V)((ToNum(Get(R_738, "yB")) - 2D)))).Put("zE", Fn((V _self730, int _argc741, V dx_747, V dy_748, V _a745, V _a746, V[] _rest742) => {
V y_749 = default;
V fy_750 = default;
double d_751 = 0;
y_749 = Add(Get(S_737, "HY"), dy_748);
fy_750 = (Get(cfg_729, "fy") is var _t752 && Truthy(_t752) ? _t752 : y_749);
d_751 = (ToNum(y_749) - ToNum(fy_750));
return ((V)(((ToNum(Invoke(R_738, "zAt", Add(Get(S_737, "HX"), dx_747), fy_750)) - ((d_751 * d_751) / 60D)) + 0.3)));
return default;
}, 2, "zE", true)).V;
if (Truthy(Get(cfg_729, "hide"))) {
Invoke(S_737, "hide", Get(cfg_729, "hide"));
}
Set(B_739, "dc", (Truthy(Get(cfg_729, "dc")) ? Call(DECS_29, V.Undef, S_737, R_738, Fn((V _self730, int _argc753, V q_759, V _a756, V _a757, V _a758, V[] _rest754) => {
return (Invoke(S_737, "dk", q_759, ((V)("dc"))) is var _t760 && !Truthy(_t760) ? _t760 : Invoke(Get(cfg_729, "dc"), "pred", q_759));
}, 1, "", true), Get(Get(cfg_729, "dc"), "copies")) : Arr()));
if (Truthy((Get(cfg_729, "dc") is var _t761 && !Truthy(_t761) ? _t761 : Get(Get(cfg_729, "dc"), "drop")))) {
Invoke(S_737, "hide", Fn((V _self730, int _argc762, V q_768, V _a765, V _a766, V _a767, V[] _rest763) => {
return Invoke(S_737, "dk", q_768, ((V)("dc")));
}, 1, "", true));
}
Set(B_739, "fx", (Truthy(Get(cfg_729, "fix")) ? Call(FIX_31, V.Undef, S_737, Fn((V _self730, int _argc769, V q_775, V _a772, V _a773, V _a774, V[] _rest770) => {
return (Invoke(S_737, "dk", q_775, ((V)("dc"))) is var _t776 && !Truthy(_t776) ? _t776 : Invoke(cfg_729, "fix", q_775));
}, 1, "", true)) : Arr()));
if (Truthy(Get(cfg_729, "spk"))) {
Set(B_739, "spk", NewObj(3).Put("P", Call(SCAT_34, V.Undef, R_738, Get(Get(cfg_729, "spk"), "n"), (Get(Get(cfg_729, "spk"), "seed") is var _t777 && Truthy(_t777) ? _t777 : ((V)(3D))), (Get(Get(cfg_729, "spk"), "min") is var _t778 && Truthy(_t778) ? _t778 : ((V)(4D))), (Get(cfg_729, "face") is var _t779 && !Truthy(_t779) ? _t779 : Call(faceAvoid_35, V.Undef, GetIdx(Get(cfg_729, "face"), 0D), GetIdx(Get(cfg_729, "face"), 1D))))).Put("r", (Get(Get(cfg_729, "spk"), "r") is var _t780 && Truthy(_t780) ? _t780 : ((V)(0.55)))).Put("e", Invoke(S_737, "path", NewObj(2).Put("fill", Get(Get(cfg_729, "spk"), "c")).Put("opacity", (Get(Get(cfg_729, "spk"), "op") is var _t781 && Truthy(_t781) ? _t781 : ((V)(0.7)))).V)).V);
}
if (Truthy(Get(cfg_729, "fib"))) {
Set(B_739, "fib", NewObj(2).Put("P", Call(SCAT_34, V.Undef, R_738, Get(Get(cfg_729, "fib"), "n"), (Get(Get(cfg_729, "fib"), "seed") is var _t782 && Truthy(_t782) ? _t782 : ((V)(7D))), (Get(Get(cfg_729, "fib"), "min") is var _t783 && Truthy(_t783) ? _t783 : ((V)(3.6))), (Get(cfg_729, "face") is var _t784 && !Truthy(_t784) ? _t784 : Call(faceAvoid_35, V.Undef, GetIdx(Get(cfg_729, "face"), 0D), GetIdx(Get(cfg_729, "face"), 1D))))).Put("e", Invoke(S_737, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(cfg_729, "fib"), "c")).Put("stroke-width", (Get(Get(cfg_729, "fib"), "w") is var _t785 && Truthy(_t785) ? _t785 : ((V)(0.55)))).Put("stroke-linecap", ((V)("round"))).Put("opacity", (Get(Get(cfg_729, "fib"), "op") is var _t786 && Truthy(_t786) ? _t786 : ((V)(0.6)))).V)).V);
}
if (Truthy(Get(cfg_729, "ridge"))) {
Set(B_739, "rdg", Object_assign(NewObj(1).Put("e", Invoke(S_737, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(cfg_729, "ridge"), "c")).Put("stroke-width", (Get(Get(cfg_729, "ridge"), "w") is var _t787 && Truthy(_t787) ? _t787 : ((V)(1.1)))).Put("stroke-linecap", ((V)("round"))).Put("opacity", (Get(Get(cfg_729, "ridge"), "op") is var _t788 && Truthy(_t788) ? _t788 : ((V)(0.3)))).V)).V, Get(cfg_729, "ridge")));
}
if (Truthy(Get(cfg_729, "extra"))) {
Invoke(Get(cfg_729, "extra"), "setup", S_737, B_739, R_738);
}
Set(B_739, "top", (Truthy(Get(cfg_729, "top")) ? Call(TOPS_39, V.Undef, S_737, Get(cfg_729, "top")) : Seq(Invoke(S_737, "hide", Fn((V _self730, int _argc789, V q_795, V _a792, V _a793, V _a794, V[] _rest790) => {
return Invoke(S_737, "dk", q_795, ((V)("top")));
}, 1, "", true)), V.Null)));
Set(B_739, "sh", (SEqS(Get(cfg_729, "shine"), "fix") ? Call(SHINE_33, V.Undef, S_737) : V.Null));
return B_739;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self796, int _argc797, V B_803, V D_804, V _a801, V _a802, V[] _rest798) => {
V R_805 = default;
if (_self796.IsNullish) _self796 = GlobalV;
R_805 = Get(B_803, "R");
Set(B_803, "d", Call(SIL_25, V.Undef, D_804, R_805));
Call(decDraw_30, V.Undef, D_804, R_805, Get(B_803, "dc"));
if (Truthy(Get(Get(B_803, "fx"), "length"))) {
Call(fixDraw_32, V.Undef, D_804, Get(B_803, "fx"));
}
if (Truthy(Get(B_803, "spk"))) {
Call(dotsDraw_36, V.Undef, D_804, R_805, Get(B_803, "spk"));
}
if (Truthy(Get(B_803, "fib"))) {
Call(fibDraw_37, V.Undef, D_804, R_805, Get(B_803, "fib"));
}
if (Truthy(Get(B_803, "rdg"))) {
Call(ridgeDraw_38, V.Undef, D_804, R_805, Get(B_803, "rdg"));
}
if (Truthy(Get(Get(B_803, "cfg"), "extra"))) {
Invoke(Get(Get(B_803, "cfg"), "extra"), "draw", B_803, D_804, R_805);
}
if (Truthy(Get(B_803, "top"))) {
Call(topDraw_40, V.Undef, D_804, Get(B_803, "top"));
}
if (Truthy(Get(B_803, "sh"))) {
Call(fixDraw_32, V.Undef, D_804, Get(B_803, "sh"));
}
return default;
}, 2, "draw", false)).V;
}, 1, "", true);
isTag_42 = Fn((V _self1, int _argc806, V t_812, V _a809, V _a810, V _a811, V[] _rest807) => {
return Fn((V _self1, int _argc813, V q_819, V _a816, V _a817, V _a818, V[] _rest814) => {
return (SEq(Get(q_819, "tag"), t_812) ? V.True : V.False);
}, 1, "", true);
}, 1, "", true);
SEPALS_43 = Fn((V _self1, int _argc820, V S_826, V fill_827, V n_828, V ph_829, V[] _rest821) => {
V par_830 = default;
par_830 = (_argc820 > 4 ? _rest821[0] : V.Undef);
return Array_from(NewObj(1).Put("length", n_828).V, Fn((V _self1, int _argc831, V __837, V i_838, V _a835, V _a836, V[] _rest832) => {
return NewObj(3).Put("a", Add(ph_829, ((V)(((ToNum(i_838) * TAU_22) / ToNum(n_828)))))).Put("id", ((V)(string.Concat("s", ToStr(i_838))))).Put("e", Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", fill_827).V, par_830)).V;
}, 2, "", true));
}, 5, "", true);
sepalDraw_44 = Fn((V _self1, int _argc839, V D_845, V list_846, V P_847, V o_848, V[] _rest840) => {
V cf_849 = default;
V up0_850 = default;
V L_851 = default;
cf_849 = Call(clamp_16, V.Undef, Invoke(D_845, "bv", ((V)("crf"))), ((V)((-0.5))), ((V)(1.2)));
up0_850 = Get(o_848, "up");
o_848 = Object_assign(NewObj(0).V, o_848, NewObj(2).Put("R", ((V)((ToNum(Get(o_848, "R")) * (1D + (0.28 * ToNum(cf_849))))))).Put("up", ((V)(((ToNum(up0_850) * (1D - (0.55 * ToNum(cf_849)))) + (LtN(cf_849, 0D) ? ((-ToNum(cf_849)) * 3D) : 0D))))).V);
L_851 = Invoke(Invoke(list_846, "map", Fn((V _self1, int _argc860, V s_866, V _a863, V _a864, V _a865, V[] _rest861) => {
V a_867 = default;
V w_868 = default;
V R_869 = default;
V tip_870 = default;
V c1_871 = default;
V c2_872 = default;
V m_873 = default;
V s1_874 = default;
V s2_875 = default;
V C_876 = default;
a_867 = Add(Get(s_866, "a"), Get(o_848, "spin"));
w_868 = Get(o_848, "w");
R_869 = Get(o_848, "R");
tip_870 = Arr(((V)((50D + (ToNum(R_869) * FdLibm.Cos(ToNum(a_867)))))), ((V)((ToNum(Get(o_848, "y")) - ToNum(Get(o_848, "up"))))), ((V)((ToNum(R_869) * FdLibm.Sin(ToNum(a_867))))));
c1_871 = Arr(((V)((50D + (ToNum(Get(o_848, "r0")) * FdLibm.Cos((ToNum(a_867) - ToNum(w_868))))))), Get(o_848, "y"), ((V)((ToNum(Get(o_848, "r0")) * FdLibm.Sin((ToNum(a_867) - ToNum(w_868)))))));
c2_872 = Arr(((V)((50D + (ToNum(Get(o_848, "r0")) * FdLibm.Cos(ToNum(Add(a_867, w_868))))))), Get(o_848, "y"), ((V)((ToNum(Get(o_848, "r0")) * FdLibm.Sin(ToNum(Add(a_867, w_868)))))));
m_873 = (Get(o_848, "mid") is var _t877 && Truthy(_t877) ? _t877 : ((V)(0.5)));
s1_874 = Arr(((V)((50D + ((ToNum(R_869) * ToNum(m_873)) * FdLibm.Cos((ToNum(a_867) - (ToNum(w_868) * 0.55))))))), ((V)((ToNum(Get(o_848, "y")) - ((ToNum(Get(o_848, "up")) * ToNum(m_873)) * 0.6)))), ((V)(((ToNum(R_869) * ToNum(m_873)) * FdLibm.Sin((ToNum(a_867) - (ToNum(w_868) * 0.55)))))));
s2_875 = Arr(((V)((50D + ((ToNum(R_869) * ToNum(m_873)) * FdLibm.Cos(ToNum(Add(a_867, ((V)((ToNum(w_868) * 0.55)))))))))), ((V)((ToNum(Get(o_848, "y")) - ((ToNum(Get(o_848, "up")) * ToNum(m_873)) * 0.6)))), ((V)(((ToNum(R_869) * ToNum(m_873)) * FdLibm.Sin(ToNum(Add(a_867, ((V)((ToNum(w_868) * 0.55))))))))));
C_876 = Arr(((V)(50D)), Add(Get(o_848, "y"), (Get(o_848, "dip") is var _t878 && Truthy(_t878) ? _t878 : ((V)(0D)))), ((V)(0D)));
Invoke(Get(s_866, "e"), "setAttribute", ((V)("d")), Call(polyW_13, V.Undef, Invoke(Arr(C_876, c1_871, s1_874, tip_870, s2_875, c2_872), "map", Fn((V _self1, int _argc879, V p_885, V _a882, V _a883, V _a884, V[] _rest880) => {
return Call(P_847, V.Undef, GetIdx(p_885, 0D), GetIdx(p_885, 1D), GetIdx(p_885, 2D));
}, 1, "", true))));
return NewObj(3).Put("id", Get(s_866, "id")).Put("e", Get(s_866, "e")).Put("z", Invoke(D_845, "Z3", GetIdx(tip_870, 0D), GetIdx(tip_870, 1D), GetIdx(tip_870, 2D))).V;
return default;
}, 1, "", true)), "sort", Fn((V _self1, int _argc852, V a_858, V b_859, V _a856, V _a857, V[] _rest853) => {
return ((V)((ToNum(Get(a_858, "z")) - ToNum(Get(b_859, "z")))));
}, 2, "", true));
return L_851;
return default;
}, 4, "", true);
Set(M_9, "bing", Call(FRUIT_41, V.Undef, NewObj(4).Put("fy", ((V)(62D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(32D))).Put("top", NewObj(3).Put("ax", ((V)(50D))).Put("ay", ((V)(34.8))).Put("curl", ((V)(0.14))).V).V));
Set(M_9, "clemmy", Call(FRUIT_41, V.Undef, NewObj(7).Put("fy", ((V)(63D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(33D))).Put("dc", NewObj(2).Put("pred", Fn((V _self1, int _argc886, V _a888, V _a889, V _a890, V _a891, V[] _rest887) => {
return (false ? V.True : V.False);
}, 0, "pred", true)).Put("drop", ((V)(1D))).V).Put("face", Arr(((V)(52D)), ((V)(73D)))).Put("spk", NewObj(6).Put("n", ((V)(120D))).Put("c", ((V)("#e2701a"))).Put("op", ((V)(0.6))).Put("r", ((V)(0.55))).Put("min", ((V)(4.2))).Put("seed", ((V)(4D))).V).Put("top", NewObj(3).Put("ax", ((V)(50D))).Put("ay", ((V)(36.4))).Put("curl", ((V)(0.14))).V).V));
Set(M_9, "appy", Call(FRUIT_41, V.Undef, NewObj(9).Put("fy", ((V)(62D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(33D))).Put("dc", NewObj(2).Put("pred", Call(isTag_42, V.Undef, ((V)("ellipse")))).Put("copies", Arr(((V)(0D)), ((V)(2.6)))).V).Put("hide", Fn((V _self1, int _argc892, V q_898, V _a895, V _a896, V _a897, V[] _rest893) => {
return (Call(inDc_49, V.Undef, q_898) is var _t899 && !Truthy(_t899) ? _t899 : (!SEqS(Get(q_898, "tag"), "ellipse") ? V.True : V.False));
}, 1, "hide", true)).Put("face", Arr(((V)(51D)), ((V)(71D)))).Put("spk", NewObj(6).Put("n", ((V)(26D))).Put("c", ((V)("#f2ffd0"))).Put("op", ((V)(0.8))).Put("r", ((V)(0.5))).Put("min", ((V)(7D))).Put("seed", ((V)(5D))).V).Put("top", NewObj(3).Put("ax", ((V)(50D))).Put("ay", ((V)(33D))).Put("curl", ((V)(0.14))).V).Put("extra", NewObj(2).Put("setup", Fn((V _self900, int _argc901, V S_907, V B_908, V _a905, V _a906, V[] _rest902) => {
if (_self900.IsNullish) _self900 = GlobalV;
Set(B_908, "cav", Invoke(S_907, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#4e8a26"))).Put("stroke-width", ((V)(1.2))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.45))).V));
return default;
}, 2, "setup", false)).Put("draw", Fn((V _self909, int _argc910, V B_916, V D_917, V R_918, V _a915, V[] _rest911) => {
V P_919 = default;
V Q_920 = default;
if (_self909.IsNullish) _self909 = GlobalV;
P_919 = Call(PEL_26, V.Undef, D_917, ((V)(0.3)), ((V)(50D)), ((V)(34.5)));
Q_920 = Invoke(Invoke(Get(SN_8, "h"), "frontArc", D_917, ((V)(6D)), ((V)(34.5)), ((V)(48D))), "map", Fn((V _self909, int _argc921, V f_927, V _a924, V _a925, V _a926, V[] _rest922) => {
return Call(P_919, V.Undef, ((V)((50D + (6D * FdLibm.Sin(ToNum(f_927)))))), ((V)(34.5)), ((V)((6D * FdLibm.Cos(ToNum(f_927))))));
}, 1, "", true));
Call(SA_23, V.Undef, Get(B_916, "cav"), ((V)("d")), (GtN(Get(Q_920, "length"), 1D) ? Call(runs_15, V.Undef, Q_920, Invoke(Q_920, "map", Fn((V _self909, int _argc928, V _a930, V _a931, V _a932, V _a933, V[] _rest929) => {
return (true ? V.True : V.False);
}, 0, "", true))) : ((V)("M0 0"))));
return default;
}, 3, "draw", false)).V).V));
Set(M_9, "blueby", Call(FRUIT_41, V.Undef, NewObj(5).Put("fy", ((V)(63D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(33D))).Put("fix", Fn((V _self1, int _argc934, V _a936, V _a937, V _a938, V _a939, V[] _rest935) => {
return (true ? V.True : V.False);
}, 0, "fix", true)).Put("extra", NewObj(2).Put("setup", Fn((V _self940, int _argc941, V S_947, V B_948, V R_949, V _a946, V[] _rest942) => {
V cr_950 = default;
V st_951 = default;
V F_952 = default;
if (_self940.IsNullish) _self940 = GlobalV;
cr_950 = Invoke(S_947, "hide", Fn((V _self940, int _argc953, V q_959, V _a956, V _a957, V _a958, V[] _rest954) => {
return Invoke(S_947, "dk", q_959, ((V)("cr")));
}, 1, "", true));
st_951 = Invoke(cr_950, "find", Fn((V _self940, int _argc960, V q_966, V _a963, V _a964, V _a965, V[] _rest961) => {
return (SEqS(Get(q_966, "tag"), "path") ? V.True : V.False);
}, 1, "", true));
F_952 = (Truthy(st_951) ? Invoke(S_947, "f", st_951) : ((V)("#3a4296")));
Set(B_948, "CG", Invoke(S_947, "g"));
Set(B_948, "sep", Call(SEPALS_43, V.Undef, S_947, F_952, ((V)(5D)), ((V)(((-System.Math.PI) / 2D))), Get(B_948, "CG")));
Set(B_948, "hole", Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#26296a"))).V, Get(B_948, "CG")));
Set(B_948, "roll", Call(ROLLF_28, V.Undef, R_949, ((V)(61D))));
return default;
}, 3, "setup", false)).Put("draw", Fn((V _self967, int _argc968, V B_974, V D_975, V _a972, V _a973, V[] _rest969) => {
double spin_976 = 0;
V P_977 = default;
V L_978 = default;
if (_self967.IsNullish) _self967 = GlobalV;
spin_976 = ((ToNum(Call(clamp_16, V.Undef, Invoke(D_975, "bv", ((V)("stw"))), ((V)((-1D))), ((V)(1D)))) * System.Math.PI) * 0.4);
P_977 = Call(PEL_26, V.Undef, D_975, ((V)(0.45)), ((V)(50D)), ((V)(38.3)));
L_978 = Call(sepalDraw_44, V.Undef, D_975, Get(B_974, "sep"), P_977, NewObj(7).Put("y", ((V)(38.3))).Put("R", ((V)(12.5))).Put("r0", ((V)(4.6))).Put("w", ((V)(0.62))).Put("up", ((V)(1.6))).Put("spin", ((V)(spin_976))).Put("mid", ((V)(0.45))).V);
Invoke(SN_8, "order", Get(B_974, "CG"), Invoke(L_978, "concat", Arr(NewObj(2).Put("id", ((V)("h"))).Put("e", Get(B_974, "hole")).V)));
Invoke(Get(B_974, "hole"), "setAttribute", ((V)("d")), Call(polyW_13, V.Undef, Array_from(NewObj(1).Put("length", ((V)(20D))).V, Fn((V _self967, int _argc979, V __985, V k_986, V _a983, V _a984, V[] _rest980) => {
double f_987 = 0;
f_987 = ((ToNum(k_986) / 20D) * TAU_22);
return Call(P_977, V.Undef, ((V)((50D + (4.2 * FdLibm.Cos(f_987))))), ((V)(38D)), ((V)((4.2 * FdLibm.Sin(f_987)))));
return default;
}, 2, "", true))));
return default;
}, 2, "draw", false)).V).V));
Set(M_9, "coco", Call(FRUIT_41, V.Undef, NewObj(8).Put("fy", ((V)(61D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(33D))).Put("dc", NewObj(1).Put("pred", Call(isTag_42, V.Undef, ((V)("circle")))).V).Put("hide", Fn((V _self1, int _argc988, V q_994, V _a991, V _a992, V _a993, V[] _rest989) => {
return (Call(inDc_49, V.Undef, q_994) is var _t995 && !Truthy(_t995) ? _t995 : (SEqS(Get(q_994, "tag"), "path") ? V.True : V.False));
}, 1, "hide", true)).Put("face", Arr(((V)(50D)), ((V)(71D)))).Put("fib", NewObj(6).Put("n", ((V)(150D))).Put("c", ((V)("#5a3820"))).Put("op", ((V)(0.6))).Put("w", ((V)(0.55))).Put("min", ((V)(3.4))).Put("seed", ((V)(7D))).V).Put("extra", NewObj(2).Put("setup", Fn((V _self996, int _argc997, V S_1003, V B_1004, V R_1005, V _a1002, V[] _rest998) => {
if (_self996.IsNullish) _self996 = GlobalV;
Set(B_1004, "roll", Call(ROLLF_28, V.Undef, R_1005, ((V)(59D))));
Set(B_1004, "pre", Fn((V _self996, int _argc1006, V P_1012, V _a1009, V _a1010, V _a1011, V[] _rest1007) => {
V k_1013 = default;
k_1013 = Call(clamp_16, V.Undef, (((V)(ToNum(Get(P_1012, "rig")))) is var _t1014 && Truthy(_t1014) ? _t1014 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
if (LtN(k_1013, 0.01)) {
return P_1012;
}
if (GtN(k_1013, 0.5)) {
Set(Get(S_1003, "I"), "ms", V.Null);
}
return Object_assign(NewObj(0).V, P_1012, NewObj(4).Put("sq", ((V)((ToNum((((V)(ToNum(Get(P_1012, "sq")))) is var _t1015 && Truthy(_t1015) ? _t1015 : ((V)(0D)))) * (1D - ToNum(k_1013)))))).Put("bend", ((V)((ToNum((((V)(ToNum(Get(P_1012, "bend")))) is var _t1016 && Truthy(_t1016) ? _t1016 : ((V)(0D)))) * (1D - ToNum(k_1013)))))).Put("lean", ((V)((ToNum((((V)(ToNum(Get(P_1012, "lean")))) is var _t1017 && Truthy(_t1017) ? _t1017 : ((V)(0D)))) * (1D - ToNum(k_1013)))))).Put("tilt", Add((((V)(ToNum(Get(P_1012, "tilt")))) is var _t1018 && Truthy(_t1018) ? _t1018 : ((V)(0D))), ((V)(((ToNum((((V)(ToNum(Get(P_1012, "lean")))) is var _t1019 && Truthy(_t1019) ? _t1019 : ((V)(0D)))) * 0.8) * ToNum(k_1013)))))).V);
return default;
}, 1, "", true));
return default;
}, 3, "setup", false)).Put("draw", Fn((V _self1020, int _argc1021, V _a1023, V _a1024, V _a1025, V _a1026, V[] _rest1022) => {
if (_self1020.IsNullish) _self1020 = GlobalV;

return default;
}, 0, "draw", false)).V).V));
Set(M_9, "perry", Call(FRUIT_41, V.Undef, NewObj(8).Put("fy", ((V)(65D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(30D))).Put("dc", NewObj(2).Put("pred", Call(isTag_42, V.Undef, ((V)("ellipse")))).Put("copies", Arr(((V)(0D)), ((V)(2.8)))).V).Put("hide", Fn((V _self1, int _argc1027, V q_1033, V _a1030, V _a1031, V _a1032, V[] _rest1028) => {
return (Call(inDc_49, V.Undef, q_1033) is var _t1034 && !Truthy(_t1034) ? _t1034 : (SEqS(Get(q_1033, "tag"), "circle") ? V.True : V.False));
}, 1, "hide", true)).Put("face", Arr(((V)(54D)), ((V)(74D)))).Put("spk", NewObj(6).Put("n", ((V)(70D))).Put("c", ((V)("#8a9a3a"))).Put("op", ((V)(0.65))).Put("r", ((V)(0.5))).Put("min", ((V)(5D))).Put("seed", ((V)(9D))).V).Put("top", NewObj(3).Put("ax", ((V)(50D))).Put("ay", ((V)(27D))).Put("curl", ((V)(0.14))).V).V));
Set(M_9, "grana", Call(FRUIT_41, V.Undef, NewObj(6).Put("fy", ((V)(63D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(33D))).Put("dc", NewObj(2).Put("pred", Fn((V _self1, int _argc1035, V _a1037, V _a1038, V _a1039, V _a1040, V[] _rest1036) => {
return (false ? V.True : V.False);
}, 0, "pred", true)).Put("drop", ((V)(1D))).V).Put("ridge", NewObj(6).Put("F", Invoke(Arr(((V)((-5D))), ((V)((-3D))), ((V)((-1D))), ((V)(1D)), ((V)(3D)), ((V)(5D))), "map", Fn((V _self1, int _argc1041, V k_1047, V _a1044, V _a1045, V _a1046, V[] _rest1042) => {
return ((V)(((ToNum(k_1047) * System.Math.PI) / 6D)));
}, 1, "", true))).Put("y0", ((V)(40D))).Put("y1", ((V)(84D))).Put("c", ((V)("#a81e2e"))).Put("op", ((V)(0.3))).Put("w", ((V)(1.1))).V).Put("extra", NewObj(2).Put("setup", Fn((V _self1048, int _argc1049, V S_1055, V B_1056, V _a1053, V _a1054, V[] _rest1050) => {
V cr_1057 = default;
V F_1058 = default;
if (_self1048.IsNullish) _self1048 = GlobalV;
cr_1057 = Invoke(S_1055, "hide", Fn((V _self1048, int _argc1059, V q_1065, V _a1062, V _a1063, V _a1064, V[] _rest1060) => {
return Invoke(S_1055, "dk", q_1065, ((V)("cr")));
}, 1, "", true));
F_1058 = (Truthy(Get(cr_1057, "length")) ? Invoke(S_1055, "f", GetIdx(cr_1057, 0D)) : ((V)("#b02a34")));
Set(B_1056, "CG", Invoke(S_1055, "g"));
Set(B_1056, "neck", Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", F_1058).V, Get(B_1056, "CG")));
Set(B_1056, "open", Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#5a0e18"))).V, Get(B_1056, "CG")));
Set(B_1056, "rim", Call(el_10, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#e86a6a"))).Put("stroke-width", ((V)(0.6))).Put("opacity", ((V)(0.6))).V, Get(B_1056, "CG")));
Set(B_1056, "sep", Call(SEPALS_43, V.Undef, S_1055, F_1058, ((V)(6D)), ((V)((((-System.Math.PI) / 2D) + (System.Math.PI / 6D)))), Get(B_1056, "CG")));
return default;
}, 2, "setup", false)).Put("draw", Fn((V _self1066, int _argc1067, V B_1073, V D_1074, V _a1071, V _a1072, V[] _rest1068) => {
V P_1075 = default;
V ring_1076 = default;
double spin_1077 = 0;
V L_1078 = default;
V bk_1079 = default;
V fr_1080 = default;
if (_self1066.IsNullish) _self1066 = GlobalV;
P_1075 = Call(PEL_26, V.Undef, D_1074, ((V)(0.3)), ((V)(50D)), ((V)(31D)));
ring_1076 = Fn((V _self1066, int _argc1081, V r_1087, V y_1088, V _a1085, V _a1086, V[] _rest1082) => {
return Array_from(NewObj(1).Put("length", ((V)(24D))).V, Fn((V _self1066, int _argc1089, V __1095, V k_1096, V _a1093, V _a1094, V[] _rest1090) => {
double f_1097 = 0;
f_1097 = ((ToNum(k_1096) / 24D) * TAU_22);
return Call(P_1075, V.Undef, ((V)((50D + (ToNum(r_1087) * FdLibm.Cos(f_1097))))), y_1088, ((V)((ToNum(r_1087) * FdLibm.Sin(f_1097)))));
return default;
}, 2, "", true));
}, 2, "", true);
spin_1077 = ((ToNum(Call(clamp_16, V.Undef, Invoke(D_1074, "bv", ((V)("stw"))), ((V)((-1D))), ((V)(1D)))) * System.Math.PI) * 0.35);
Invoke(Get(B_1073, "neck"), "setAttribute", ((V)("d")), Invoke(D_1074, "hull", Invoke(Call(ring_1076, V.Undef, ((V)(7.4)), ((V)(36D))), "concat", Call(ring_1076, V.Undef, ((V)(6.1)), ((V)(31D))))));
Invoke(Get(B_1073, "open"), "setAttribute", ((V)("d")), Call(polyW_13, V.Undef, Call(ring_1076, V.Undef, ((V)(4.6)), ((V)(30.9)))));
Invoke(Get(B_1073, "rim"), "setAttribute", ((V)("d")), Call(polyW_13, V.Undef, Call(ring_1076, V.Undef, ((V)(6.1)), ((V)(31D)))));
L_1078 = Call(sepalDraw_44, V.Undef, D_1074, Get(B_1073, "sep"), P_1075, NewObj(8).Put("y", ((V)(31D))).Put("R", ((V)(9.6))).Put("r0", ((V)(4.2))).Put("w", ((V)(0.42))).Put("up", ((V)(7D))).Put("spin", ((V)(spin_1077))).Put("mid", ((V)(0.5))).Put("dip", ((V)(0D))).V);
bk_1079 = Invoke(L_1078, "filter", Fn((V _self1066, int _argc1098, V o_1104, V _a1101, V _a1102, V _a1103, V[] _rest1099) => {
return (LtN(Get(o_1104, "z"), 0D) ? V.True : V.False);
}, 1, "", true));
fr_1080 = Invoke(L_1078, "filter", Fn((V _self1066, int _argc1105, V o_1111, V _a1108, V _a1109, V _a1110, V[] _rest1106) => {
return (GeN(Get(o_1111, "z"), 0D) ? V.True : V.False);
}, 1, "", true));
Invoke(SN_8, "order", Get(B_1073, "CG"), Invoke(bk_1079, "concat", Arr(NewObj(2).Put("id", ((V)("n"))).Put("e", Get(B_1073, "neck")).V, NewObj(2).Put("id", ((V)("o"))).Put("e", Get(B_1073, "open")).V, NewObj(2).Put("id", ((V)("r"))).Put("e", Get(B_1073, "rim")).V), fr_1080));
return default;
}, 2, "draw", false)).V).V));
Set(M_9, "mangie", Call(FRUIT_41, V.Undef, NewObj(10).Put("fy", ((V)(61D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(30D))).Put("kz", ((V)(0.85))).Put("cx", ((V)("mid"))).Put("dc", NewObj(2).Put("pred", Call(isTag_42, V.Undef, ((V)("ellipse")))).Put("copies", Arr(((V)(0D)), ((V)(System.Math.PI)))).V).Put("hide", Fn((V _self1, int _argc1112, V q_1118, V _a1115, V _a1116, V _a1117, V[] _rest1113) => {
return (Call(inDc_49, V.Undef, q_1118) is var _t1119 && !Truthy(_t1119) ? _t1119 : (SEqS(Get(q_1118, "tag"), "circle") ? V.True : V.False));
}, 1, "hide", true)).Put("face", Arr(((V)(50D)), ((V)(70D)))).Put("spk", NewObj(6).Put("n", ((V)(30D))).Put("c", ((V)("#fff6c8"))).Put("op", ((V)(0.7))).Put("r", ((V)(0.5))).Put("min", ((V)(6.5))).Put("seed", ((V)(13D))).V).Put("top", NewObj(3).Put("ax", ((V)(47.6))).Put("ay", ((V)(30.6))).Put("curl", ((V)(0.12))).V).V));
Set(M_9, "razzy", Call(FRUIT_41, V.Undef, NewObj(5).Put("fy", ((V)(59D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(30D))).Put("dc", NewObj(2).Put("pred", Fn((V _self1, int _argc1120, V _a1122, V _a1123, V _a1124, V _a1125, V[] _rest1121) => {
return (false ? V.True : V.False);
}, 0, "pred", true)).Put("drop", ((V)(1D))).V).Put("extra", NewObj(2).Put("setup", Fn((V _self1126, int _argc1127, V S_1133, V B_1134, V R_1135, V _a1132, V[] _rest1128) => {
V gr_1136 = default;
V GF_1137 = default;
V cr_1138 = default;
V CF_1139 = default;
V DR_1140 = default;
V nf_1141 = default;
double row_1142 = 0;
if (_self1126.IsNullish) _self1126 = GlobalV;
gr_1136 = Invoke(S_1133, "hide", Fn((V _self1126, int _argc1143, V q_1149, V _a1146, V _a1147, V _a1148, V[] _rest1144) => {
return Invoke(S_1133, "dk", q_1149, ((V)("gr")));
}, 1, "", true));
GF_1137 = (Truthy(Get(gr_1136, "length")) ? Invoke(S_1133, "f", GetIdx(gr_1136, 0D)) : ((V)("#ec3a6c")));
cr_1138 = Invoke(S_1133, "hide", Fn((V _self1126, int _argc1150, V q_1156, V _a1153, V _a1154, V _a1155, V[] _rest1151) => {
return Invoke(S_1133, "dk", q_1156, ((V)("cr")));
}, 1, "", true));
CF_1139 = (Truthy(Get((Invoke(cr_1138, "find", Fn((V _self1126, int _argc1164, V q_1170, V _a1167, V _a1168, V _a1169, V[] _rest1165) => {
return (SEqS(Get(q_1170, "tag"), "path") ? V.True : V.False);
}, 1, "", true)) is var _t1171 && Truthy(_t1171) ? _t1171 : NewObj(0).V), "e")) ? Invoke(S_1133, "f", Invoke(cr_1138, "find", Fn((V _self1126, int _argc1157, V q_1163, V _a1160, V _a1161, V _a1162, V[] _rest1158) => {
return (SEqS(Get(q_1163, "tag"), "path") ? V.True : V.False);
}, 1, "", true))) : ((V)("#6ab83a")));
DR_1140 = Arr();
nf_1141 = Fn((V _self1126, int _argc1172, V f_1178, V y_1179, V _a1176, V _a1177, V[] _rest1173) => {
double x_1180 = 0;
if ((FdLibm.Cos(ToNum(f_1178)) < 0.3)) {
return (false ? V.True : V.False);
}
x_1180 = (50D + ((ToNum(Invoke(R_1135, "rT", y_1179)) - 1.6) * FdLibm.Sin(ToNum(f_1178))));
return ((((Hypot((x_1180 - 40D), (ToNum(y_1179) - 56D)) < 5.6) || (Hypot((x_1180 - 60D), (ToNum(y_1179) - 56D)) < 5.6)) || (Hypot((x_1180 - 50D), (ToNum(y_1179) - 63.5)) < 4.2)) ? V.True : V.False);
return default;
}, 2, "", true);
row_1142 = 0D;
{
double y_1181 = 0;
y_1181 = 34.5;
while (true) {
if (!((y_1181 < 87D))) break;
double r_1183 = 0;
double n_1184 = 0;
r_1183 = Max(0D, (ToNum(Invoke(R_1135, "rT", ((V)(y_1181)))) - 1.6));
n_1184 = Max(1D, Round(((TAU_22 * r_1183) / 8.2)));
{
double i_1185 = 0;
i_1185 = 0D;
while (true) {
if (!((i_1185 < n_1184))) break;
double f_1187 = 0;
double yy_1188 = 0;
f_1187 = ((((i_1185 + ((row_1142 % 2D) * 0.5)) + ((ToNum(Call(rnd_19, V.Undef, ((V)(((y_1181 * 3D) + i_1185))))) - 0.5) * 0.2)) / n_1184) * TAU_22);
yy_1188 = (y_1181 + ((ToNum(Call(rnd_19, V.Undef, ((V)(((y_1181 * 5D) + i_1185))))) - 0.5) * 1.2));
if (!(Truthy(Call(nf_1141, V.Undef, ((V)(f_1187)), ((V)(yy_1188)))))) {
Invoke(DR_1140, "push", NewObj(3).Put("f", ((V)(f_1187))).Put("y", ((V)(yy_1188))).Put("s", ((V)(((0.93 + (ToNum(Call(rnd_19, V.Undef, ((V)((y_1181 + (i_1185 * 1.7)))))) * 0.12)) * ((y_1181 > 82D) ? 0.8 : 1D))))).V);
}
i_1185++;
}
}
y_1181 = (y_1181 + 6.3);
row_1142++;
}
}
Set(B_1134, "DR", DR_1140);
Set(B_1134, "DG", Invoke(S_1133, "g"));
Invoke(Get(B_1134, "DG"), "setAttribute", ((V)("data-ol")), ((V)(0.8)));
Set(B_1134, "pool", Invoke(DR_1140, "map", Fn((V _self1126, int _argc1189, V _a1191, V _a1192, V _a1193, V _a1194, V[] _rest1190) => {
return Call(el_10, V.Undef, ((V)("path")), NewObj(2).Put("fill", GF_1137).Put("d", ((V)("M0 0"))).V, Get(B_1134, "DG"));
}, 0, "", true)));
Set(B_1134, "CG", Invoke(S_1133, "g"));
Set(B_1134, "stalk", Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#5a9a2a"))).V, Get(B_1134, "CG")));
Set(B_1134, "sep", Call(SEPALS_43, V.Undef, S_1133, CF_1139, ((V)(6D)), ((V)(((-System.Math.PI) / 2D))), Get(B_1134, "CG")));
return default;
}, 3, "setup", false)).Put("draw", Fn((V _self1195, int _argc1196, V B_1202, V D_1203, V R_1204, V _a1201, V[] _rest1197) => {
V jg_1205 = default;
V L_1206 = default;
double rr_1207 = 0;
V P_1208 = default;
double spin_1209 = 0;
if (_self1195.IsNullish) _self1195 = GlobalV;
jg_1205 = Call(clamp_16, V.Undef, Invoke(D_1203, "bv", ((V)("jig"))), ((V)(0D)), ((V)(1.5)));
L_1206 = Arr();
rr_1207 = (4.25 * ToNum(Get(D_1203, "kS")));
Invoke(Get(B_1202, "DR"), "forEach", Fn((V _self1195, int _argc1210, V o_1216, V i_1217, V _a1214, V _a1215, V[] _rest1211) => {
double j_1218 = 0;
V p_1219 = default;
V fz_1220 = default;
j_1218 = ((ToNum(jg_1205) * 0.5) * FdLibm.Sin(((ToNum(Get(D_1203, "ts")) * 19D) + (ToNum(i_1217) * 1.3))));
p_1219 = Invoke(R_1204, "at", Get(o_1216, "f"), Get(o_1216, "y"), ((V)(((-1.6) + j_1218))));
fz_1220 = Invoke(D_1203, "facing", GetIdx(p_1219, 0D), GetIdx(p_1219, 1D), GetIdx(p_1219, 2D), GetIdx(p_1219, 3D), GetIdx(p_1219, 4D), GetIdx(p_1219, 5D));
if (LtN(fz_1220, (-0.15))) {
return default;
}
Invoke(L_1206, "push", NewObj(3).Put("c", Invoke(D_1203, "P3", GetIdx(p_1219, 0D), GetIdx(p_1219, 1D), GetIdx(p_1219, 2D))).Put("z", Invoke(D_1203, "Z3", GetIdx(p_1219, 0D), GetIdx(p_1219, 1D), GetIdx(p_1219, 2D))).Put("s", Get(o_1216, "s")).V);
return default;
}, 2, "", true));
Invoke(L_1206, "sort", Fn((V _self1195, int _argc1221, V a_1227, V b_1228, V _a1225, V _a1226, V[] _rest1222) => {
return ((V)((ToNum(Get(a_1227, "z")) - ToNum(Get(b_1228, "z")))));
}, 2, "", true));
Invoke(Get(B_1202, "pool"), "forEach", Fn((V _self1195, int _argc1229, V e_1235, V i_1236, V _a1233, V _a1234, V[] _rest1230) => {
V o_1237 = default;
o_1237 = GetK(L_1206, i_1236);
Call(SA_23, V.Undef, e_1235, ((V)("d")), (Truthy(o_1237) ? Call(circD_14, V.Undef, Get(o_1237, "c"), ((V)((rr_1207 * ToNum(Get(o_1237, "s")))))) : ((V)("M0 0"))));
return default;
}, 2, "", true));
P_1208 = Call(PEL_26, V.Undef, D_1203, ((V)(0.38)), ((V)(50D)), ((V)(31D)));
spin_1209 = ((ToNum(Call(clamp_16, V.Undef, Invoke(D_1203, "bv", ((V)("stw"))), ((V)((-1D))), ((V)(1D)))) * System.Math.PI) * 0.4);
Invoke(Get(B_1202, "stalk"), "setAttribute", ((V)("d")), Invoke(Get(SN_8, "h"), "tubeD", D_1203, Arr(Arr(((V)(50D)), ((V)(31.1)), ((V)(0D))), Arr(((V)(50D)), ((V)(27.3)), ((V)(0D))), Arr(((V)(50.3)), ((V)(23.6)), ((V)(0D)))), Arr(((V)(1.05)), ((V)(1D)), ((V)(0.95)))));
Invoke(SN_8, "order", Get(B_1202, "CG"), Invoke(Call(sepalDraw_44, V.Undef, D_1203, Get(B_1202, "sep"), P_1208, NewObj(7).Put("y", ((V)(31D))).Put("R", ((V)(12D))).Put("r0", ((V)(2.6))).Put("w", ((V)(0.5))).Put("up", ((V)(1.4))).Put("spin", ((V)(spin_1209))).Put("mid", ((V)(0.5))).V), "concat", Arr(NewObj(2).Put("id", ((V)("st"))).Put("e", Get(B_1202, "stalk")).V)));
return default;
}, 3, "draw", false)).V).V));
NTF_45 = FdLibm.Sin((System.Math.PI * 0.553));
NC_46 = Fn((V _self1, int _argc1238, V t_1244, V cv_1245, V _a1242, V _a1243, V[] _rest1239) => {
return Arr(((V)((((63D - (8D * ToNum(t_1244))) - ((12D * ToNum(Add(((V)(1D)), (cv_1245 is var _t1246 && Truthy(_t1246) ? _t1246 : ((V)(0D)))))) * FdLibm.Sin((System.Math.PI * ToNum(t_1244))))) + ((12D * ToNum((cv_1245 is var _t1247 && Truthy(_t1247) ? _t1247 : ((V)(0D))))) * NTF_45)))), ((V)((12D + (76D * ToNum(t_1244))))));
}, 2, "", true);
NW_47 = Fn((V _self1, int _argc1248, V t_1254, V _a1251, V _a1252, V _a1253, V[] _rest1249) => {
return ((V)((3D + (15.5 * Pow(FdLibm.Sin((System.Math.PI * ToNum(Call(clamp_16, V.Undef, ((V)(((ToNum(t_1254) - 0.02) / 0.96))), ((V)(0D)), ((V)(1D)))))), 0.55)))));
}, 1, "", true);
NT_48 = Fn((V _self1, int _argc1255, V t_1261, V cv_1262, V _a1259, V _a1260, V[] _rest1256) => {
double dx_1263 = 0;
double dy_1264 = 0;
double L_1265 = 0;
dx_1263 = ((-8D) - (((12D * ToNum(Add(((V)(1D)), (cv_1262 is var _t1266 && Truthy(_t1266) ? _t1266 : ((V)(0D)))))) * System.Math.PI) * FdLibm.Cos((System.Math.PI * ToNum(t_1261)))));
dy_1264 = 76D;
L_1265 = Hypot(dx_1263, dy_1264);
return Arr(((V)((dx_1263 / L_1265))), ((V)((dy_1264 / L_1265))));
return default;
}, 2, "", true);
Set(M_9, "nana", NewObj(2).Put("setup", Fn((V _self1267, int _argc1268, V S_1274, V _a1271, V _a1272, V _a1273, V[] _rest1269) => {
double KZ_1275 = 0;
V ST_1276 = default;
V zAt_1277 = default;
V rd_1278 = default;
V sk_1279 = default;
V skC_1280 = default;
V tip_1281 = default;
if (_self1267.IsNullish) _self1267 = GlobalV;
KZ_1275 = 0.9;
Invoke(S_1274, "hide", Fn((V _self1267, int _argc1282, V q_1288, V _a1285, V _a1286, V _a1287, V[] _rest1283) => {
return Invoke(S_1274, "dk", q_1288);
}, 1, "", true));
ST_1276 = Invoke(S_1274, "rgrad", ((V)("nst")), Arr(Arr(((V)(0D)), ((V)("#b8905a"))), Arr(((V)(0.6)), ((V)("#7a5a2a"))), Arr(((V)(1D)), ((V)("#4a3418")))));
zAt_1277 = Fn((V _self1267, int _argc1289, V x_1295, V y_1296, V _a1293, V _a1294, V[] _rest1290) => {
V t_1297 = default;
V c_1298 = default;
V T_1299 = default;
V w_1300 = default;
double d_1301 = 0;
t_1297 = Call(clamp_16, V.Undef, ((V)(((ToNum(y_1296) - 12D) / 76D))), ((V)(0D)), ((V)(1D)));
c_1298 = Call(NC_46, V.Undef, t_1297);
T_1299 = Call(NT_48, V.Undef, t_1297);
w_1300 = Call(NW_47, V.Undef, t_1297);
d_1301 = ((ToNum(x_1295) - ToNum(GetIdx(c_1298, 0D))) * ToNum(GetIdx(T_1299, 1D)));
return ((V)((((d_1301 * d_1301) < (ToNum(w_1300) * ToNum(w_1300))) ? (KZ_1275 * System.Math.Sqrt(((ToNum(w_1300) * ToNum(w_1300)) - (d_1301 * d_1301)))) : 0D)));
return default;
}, 2, "", true);
rd_1278 = Invoke(S_1274, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#d9a820"))).Put("stroke-width", ((V)(0.9))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.6))).V);
sk_1279 = Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", ST_1276).V, Get(S_1274, "LG"));
skC_1280 = Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#4a3418"))).V, Get(S_1274, "LG"));
tip_1281 = Invoke(S_1274, "path", NewObj(1).Put("fill", ((V)("#6a4a24"))).V);
return NewObj(11).Put("KZ", ((V)(KZ_1275))).Put("rd", rd_1278).Put("sk", sk_1279).Put("skC", skC_1280).Put("tip", tip_1281).Put("rx", ((V)(24D))).Put("ya", ((V)(20D))).Put("yb", ((V)(86D))).Put("rT", Fn((V _self1267, int _argc1302, V y_1308, V _a1305, V _a1306, V _a1307, V[] _rest1303) => {
V t_1309 = default;
t_1309 = Call(clamp_16, V.Undef, ((V)(((ToNum(y_1308) - 12D) / 76D))), ((V)(0D)), ((V)(1D)));
return ((V)((ToNum(Call(NW_47, V.Undef, t_1309)) / Max(0.5, ToNum(GetIdx(Call(NT_48, V.Undef, t_1309), 1D))))));
return default;
}, 1, "rT", true)).Put("zAt", zAt_1277).Put("zE", Fn((V _self1267, int _argc1310, V dx_1316, V dy_1317, V _a1314, V _a1315, V[] _rest1311) => {
return Add(Call(zAt_1277, V.Undef, Add(Get(S_1274, "HX"), dx_1316), Add(Get(S_1274, "HY"), dy_1317)), ((V)(0.3)));
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self1318, int _argc1319, V B_1325, V D_1326, V _a1323, V _a1324, V[] _rest1320) => {
V P3_1327 = default;
V KZ_1328 = default;
double n_1329 = 0;
V Rt_1330 = default;
V Lt_1331 = default;
V cv_1332 = default;
V ring_1333 = default;
V ext_1334 = default;
V G_1335 = default;
V cap_1336 = default;
V rd_1337 = default;
V sw_1338 = default;
double dx0_1339 = 0;
V C0_1340 = default;
V C1_1341 = default;
V C2_1342 = default;
V e_1343 = default;
if (_self1318.IsNullish) _self1318 = GlobalV;
{ V _t1344 = D_1326;
if (_t1344.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1344));
{ V _t1345 = Get(_t1344, "P3");
P3_1327 = _t1345; } }
KZ_1328 = Get(B_1325, "KZ");
n_1329 = 30D;
Rt_1330 = Arr();
Lt_1331 = Arr();
cv_1332 = Call(clamp_16, V.Undef, Invoke(D_1326, "bv", ((V)("cv"))), ((V)((-1D))), ((V)(1.2)));
ring_1333 = Fn((V _self1318, int _argc1346, V t_1352, V _a1349, V _a1350, V _a1351, V[] _rest1347) => {
V c_1353 = default;
V T_1354 = default;
V N_1355 = default;
V w_1356 = default;
c_1353 = Call(NC_46, V.Undef, t_1352, cv_1332);
T_1354 = Call(NT_48, V.Undef, t_1352, cv_1332);
N_1355 = Arr(GetIdx(T_1354, 1D), ((V)((-ToNum(GetIdx(T_1354, 0D))))));
w_1356 = Call(NW_47, V.Undef, t_1352);
return NewObj(4).Put("c", Arr(GetIdx(c_1353, 0D), GetIdx(c_1353, 1D), ((V)(0D)))).Put("N", Arr(GetIdx(N_1355, 0D), GetIdx(N_1355, 1D), ((V)(0D)))).Put("T", Arr(GetIdx(T_1354, 0D), GetIdx(T_1354, 1D), ((V)(0D)))).Put("w", w_1356).V;
return default;
}, 1, "", true);
ext_1334 = Fn((V _self1318, int _argc1357, V g_1363, V _a1360, V _a1361, V _a1362, V[] _rest1358) => {
V c_1364 = default;
V e1_1365 = default;
V e2_1366 = default;
V a_1367 = default;
V E1_1368 = default;
V E2_1369 = default;
V A_1370 = default;
V L_1371 = default;
double nx_1372 = 0;
double ny_1373 = 0;
double an_1374 = 0;
V V_1375 = default;
c_1364 = Call(P3_1327, V.Undef, GetIdx(Get(g_1363, "c"), 0D), GetIdx(Get(g_1363, "c"), 1D), ((V)(0D)));
e1_1365 = Call(P3_1327, V.Undef, Add(GetIdx(Get(g_1363, "c"), 0D), GetIdx(Get(g_1363, "N"), 0D)), Add(GetIdx(Get(g_1363, "c"), 1D), GetIdx(Get(g_1363, "N"), 1D)), ((V)(0D)));
e2_1366 = Call(P3_1327, V.Undef, GetIdx(Get(g_1363, "c"), 0D), GetIdx(Get(g_1363, "c"), 1D), KZ_1328);
a_1367 = Call(P3_1327, V.Undef, Add(GetIdx(Get(g_1363, "c"), 0D), GetIdx(Get(g_1363, "T"), 0D)), Add(GetIdx(Get(g_1363, "c"), 1D), GetIdx(Get(g_1363, "T"), 1D)), ((V)(0D)));
E1_1368 = Arr(((V)((ToNum(GetIdx(e1_1365, 0D)) - ToNum(GetIdx(c_1364, 0D))))), ((V)((ToNum(GetIdx(e1_1365, 1D)) - ToNum(GetIdx(c_1364, 1D))))));
E2_1369 = Arr(((V)((ToNum(GetIdx(e2_1366, 0D)) - ToNum(GetIdx(c_1364, 0D))))), ((V)((ToNum(GetIdx(e2_1366, 1D)) - ToNum(GetIdx(c_1364, 1D))))));
A_1370 = Arr(((V)((ToNum(GetIdx(a_1367, 0D)) - ToNum(GetIdx(c_1364, 0D))))), ((V)((ToNum(GetIdx(a_1367, 1D)) - ToNum(GetIdx(c_1364, 1D))))));
L_1371 = (((V)(Hypot(ToNum(GetIdx(A_1370, 0D)), ToNum(GetIdx(A_1370, 1D))))) is var _t1376 && Truthy(_t1376) ? _t1376 : ((V)(1D)));
nx_1372 = (ToNum(GetIdx(A_1370, 1D)) / ToNum(L_1371));
ny_1373 = ((-ToNum(GetIdx(A_1370, 0D))) / ToNum(L_1371));
an_1374 = FdLibm.Atan2(((nx_1372 * ToNum(GetIdx(E2_1369, 0D))) + (ny_1373 * ToNum(GetIdx(E2_1369, 1D)))), ((nx_1372 * ToNum(GetIdx(E1_1368, 0D))) + (ny_1373 * ToNum(GetIdx(E1_1368, 1D)))));
V_1375 = Arr(((V)(((ToNum(GetIdx(E1_1368, 0D)) * FdLibm.Cos(an_1374)) + (ToNum(GetIdx(E2_1369, 0D)) * FdLibm.Sin(an_1374))))), ((V)(((ToNum(GetIdx(E1_1368, 1D)) * FdLibm.Cos(an_1374)) + (ToNum(GetIdx(E2_1369, 1D)) * FdLibm.Sin(an_1374))))));
return NewObj(3).Put("c", c_1364).Put("V", V_1375).Put("A", Arr(((V)((ToNum(GetIdx(A_1370, 0D)) / ToNum(L_1371)))), ((V)((ToNum(GetIdx(A_1370, 1D)) / ToNum(L_1371)))))).V;
return default;
}, 1, "", true);
G_1335 = Arr();
{
double i_1377 = 0;
i_1377 = 0D;
while (true) {
if (!((i_1377 <= n_1329))) break;
Invoke(G_1335, "push", Call(ext_1334, V.Undef, Call(ring_1333, V.Undef, ((V)((i_1377 / n_1329))))));
i_1377++;
}
}
Invoke(G_1335, "forEach", Fn((V _self1318, int _argc1379, V g_1385, V i_1386, V _a1383, V _a1384, V[] _rest1380) => {
V w_1387 = default;
w_1387 = Call(NW_47, V.Undef, ((V)((ToNum(i_1386) / n_1329))));
Invoke(Rt_1330, "push", Arr(Add(GetIdx(Get(g_1385, "c"), 0D), ((V)((ToNum(GetIdx(Get(g_1385, "V"), 0D)) * ToNum(w_1387))))), Add(GetIdx(Get(g_1385, "c"), 1D), ((V)((ToNum(GetIdx(Get(g_1385, "V"), 1D)) * ToNum(w_1387)))))));
Invoke(Lt_1331, "push", Arr(((V)((ToNum(GetIdx(Get(g_1385, "c"), 0D)) - (ToNum(GetIdx(Get(g_1385, "V"), 0D)) * ToNum(w_1387))))), ((V)((ToNum(GetIdx(Get(g_1385, "c"), 1D)) - (ToNum(GetIdx(Get(g_1385, "V"), 1D)) * ToNum(w_1387)))))));
return default;
}, 2, "", true));
cap_1336 = Fn((V _self1318, int _argc1388, V g_1394, V w_1395, V sg_1396, V rev_1397, V[] _rest1389) => {
V vl_1398 = default;
double r_1399 = 0;
double vx_1400 = 0;
double vy_1401 = 0;
V o_1402 = default;
vl_1398 = (((V)(Hypot(ToNum(GetIdx(Get(g_1394, "V"), 0D)), ToNum(GetIdx(Get(g_1394, "V"), 1D))))) is var _t1403 && Truthy(_t1403) ? _t1403 : ((V)(1D)));
r_1399 = (ToNum(vl_1398) * ToNum(w_1395));
vx_1400 = (ToNum(GetIdx(Get(g_1394, "V"), 0D)) / ToNum(vl_1398));
vy_1401 = (ToNum(GetIdx(Get(g_1394, "V"), 1D)) / ToNum(vl_1398));
o_1402 = Arr();
{
double k_1404 = 0;
k_1404 = 1D;
while (true) {
if (!((k_1404 < 8D))) break;
double a_1406 = 0;
a_1406 = (((Truthy(rev_1397) ? (8D - k_1404) : k_1404) / 8D) * System.Math.PI);
Invoke(o_1402, "push", Arr(Add(GetIdx(Get(g_1394, "c"), 0D), ((V)((r_1399 * ((vx_1400 * FdLibm.Cos(a_1406)) + ((ToNum(sg_1396) * ToNum(GetIdx(Get(g_1394, "A"), 0D))) * FdLibm.Sin(a_1406))))))), Add(GetIdx(Get(g_1394, "c"), 1D), ((V)((r_1399 * ((vy_1401 * FdLibm.Cos(a_1406)) + ((ToNum(sg_1396) * ToNum(GetIdx(Get(g_1394, "A"), 1D))) * FdLibm.Sin(a_1406)))))))));
k_1404++;
}
}
return o_1402;
return default;
}, 4, "", true);
Set(B_1325, "d", Call(polyD_12, V.Undef, Invoke(Rt_1330, "concat", Call(cap_1336, V.Undef, GetIdx(G_1335, n_1329), Call(NW_47, V.Undef, ((V)(1D))), ((V)(1D)), ((V)(0D))), Invoke(Lt_1331, "reverse"), Call(cap_1336, V.Undef, GetIdx(G_1335, 0D), Call(NW_47, V.Undef, ((V)(0D))), ((V)((-1D))), ((V)(1D))))));
rd_1337 = ((V)(""));
Invoke(Arr(((V)((-0.63))), ((V)(0.63)), ((V)((-1.9))), ((V)(1.9)), ((V)(System.Math.PI))), "forEach", Fn((V _self1318, int _argc1407, V f_1413, V _a1410, V _a1411, V _a1412, V[] _rest1408) => {
V Q_1414 = default;
V ok_1415 = default;
Q_1414 = Arr();
ok_1415 = Arr();
{
double i_1416 = 0;
i_1416 = 2D;
while (true) {
if (!((i_1416 <= 27D))) break;
V g_1418 = default;
double sf_1419 = 0;
double cf_1420 = 0;
V x_1421 = default;
V y_1422 = default;
double z_1423 = 0;
g_1418 = Call(ring_1333, V.Undef, ((V)((i_1416 / n_1329))));
sf_1419 = FdLibm.Sin(ToNum(f_1413));
cf_1420 = FdLibm.Cos(ToNum(f_1413));
x_1421 = Add(GetIdx(Get(g_1418, "c"), 0D), ((V)(((ToNum(Get(g_1418, "w")) * ToNum(GetIdx(Get(g_1418, "N"), 0D))) * sf_1419))));
y_1422 = Add(GetIdx(Get(g_1418, "c"), 1D), ((V)(((ToNum(Get(g_1418, "w")) * ToNum(GetIdx(Get(g_1418, "N"), 1D))) * sf_1419))));
z_1423 = ((ToNum(Get(g_1418, "w")) * ToNum(KZ_1328)) * cf_1420);
Invoke(Q_1414, "push", Call(P3_1327, V.Undef, x_1421, y_1422, ((V)(z_1423))));
Invoke(ok_1415, "push", (GtN(Invoke(D_1326, "facing", x_1421, y_1422, ((V)(z_1423)), ((V)((ToNum(GetIdx(Get(g_1418, "N"), 0D)) * sf_1419))), ((V)((ToNum(GetIdx(Get(g_1418, "N"), 1D)) * sf_1419))), ((V)((cf_1420 / ToNum(KZ_1328))))), 0.1) ? V.True : V.False));
i_1416++;
}
}
rd_1337 = Add(rd_1337, Call(runs_15, V.Undef, Q_1414, ok_1415));
return default;
}, 1, "", true));
Call(SA_23, V.Undef, Get(B_1325, "rd"), ((V)("d")), (rd_1337 is var _t1424 && Truthy(_t1424) ? _t1424 : ((V)("M0 0"))));
sw_1338 = Add(Call(clamp_16, V.Undef, ((V)(((-ToNum(Get(D_1326, "ox"))) * 0.08))), ((V)((-0.6))), ((V)(0.6))), ((V)(((ToNum(GetIdx(Call(NT_48, V.Undef, ((V)(0D)), cv_1332), 0D)) - ToNum(GetIdx(Call(NT_48, V.Undef, ((V)(0D)), ((V)(0D))), 0D))) * 0.6))));
dx0_1339 = (ToNum(GetIdx(Call(NC_46, V.Undef, ((V)(0.033)), cv_1332), 0D)) - ToNum(GetIdx(Call(NC_46, V.Undef, ((V)(0.033)), ((V)(0D))), 0D)));
C0_1340 = Arr(((V)((63.1 + dx0_1339))), ((V)(14.6)), ((V)(0D)));
C1_1341 = Arr(((V)(((63.6 + dx0_1339) + (ToNum(sw_1338) * 2D)))), ((V)(9.6)), ((V)(0D)));
C2_1342 = Arr(((V)(((64.4 + dx0_1339) + (ToNum(sw_1338) * 4.5)))), ((V)(5D)), ((V)(0D)));
Invoke(Get(B_1325, "sk"), "setAttribute", ((V)("d")), Invoke(Get(SN_8, "h"), "tubeD", D_1326, Arr(C0_1340, C1_1341, C2_1342), Arr(((V)(2.5)), ((V)(2.2)), ((V)(1.95)))));
Invoke(Get(B_1325, "skC"), "setAttribute", ((V)("d")), Call(circD_14, V.Undef, Call(P3_1327, V.Undef, GetIdx(C2_1342, 0D), ((V)((ToNum(GetIdx(C2_1342, 1D)) - 0.6))), ((V)(0D))), ((V)((1.75 * ToNum(Get(D_1326, "kS")))))));
e_1343 = Call(NC_46, V.Undef, ((V)(0.985)), cv_1332);
Invoke(Get(B_1325, "tip"), "setAttribute", ((V)("d")), Call(circD_14, V.Undef, Call(P3_1327, V.Undef, GetIdx(e_1343, 0D), GetIdx(e_1343, 1D), ((V)(0D))), ((V)((2.7 * ToNum(Get(D_1326, "kS")))))));
return default;
}, 2, "draw", false)).V);
Set(M_9, "plummy", Call(FRUIT_41, V.Undef, NewObj(10).Put("fy", ((V)(62D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(31D))).Put("dc", NewObj(1).Put("pred", Call(isTag_42, V.Undef, ((V)("path")))).V).Put("fix", Call(isTag_42, V.Undef, ((V)("ellipse")))).Put("hide", Fn((V _self1, int _argc1425, V q_1431, V _a1428, V _a1429, V _a1430, V[] _rest1426) => {
return (Call(inDc_49, V.Undef, q_1431) is var _t1432 && !Truthy(_t1432) ? _t1432 : (SEqS(Get(q_1431, "tag"), "circle") ? V.True : V.False));
}, 1, "hide", true)).Put("face", Arr(((V)(51D)), ((V)(72D)))).Put("spk", NewObj(6).Put("n", ((V)(55D))).Put("c", ((V)("#ead0f0"))).Put("op", ((V)(0.5))).Put("r", ((V)(0.45))).Put("min", ((V)(5.5))).Put("seed", ((V)(11D))).V).Put("top", NewObj(3).Put("ax", ((V)(50D))).Put("ay", ((V)(32D))).Put("curl", ((V)(0.14))).V).Put("extra", NewObj(2).Put("setup", Fn((V _self1433, int _argc1434, V S_1440, V B_1441, V _a1438, V _a1439, V[] _rest1435) => {
if (_self1433.IsNullish) _self1433 = GlobalV;
Set(B_1441, "bloom", Invoke(Get(B_1441, "fx"), "map", Fn((V _self1433, int _argc1442, V o_1448, V _a1445, V _a1446, V _a1447, V[] _rest1443) => {
return NewObj(2).Put("e", Get(o_1448, "e")).Put("op", ((V)(ToNum((Invoke(Get(o_1448, "e"), "getAttribute", ((V)("opacity"))) is var _t1449 && Truthy(_t1449) ? _t1449 : ((V)(1D))))))).V;
}, 1, "", true)));
Set(B_1441, "gl", Invoke(S_1440, "path", NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0D))).V));
return default;
}, 2, "setup", false)).Put("draw", Fn((V _self1450, int _argc1451, V B_1457, V D_1458, V _a1455, V _a1456, V[] _rest1452) => {
V p_1459 = default;
V Q_1460 = default;
double N_1461 = 0;
V A_1462 = default;
if (_self1450.IsNullish) _self1450 = GlobalV;
p_1459 = Call(clamp_16, V.Undef, Invoke(D_1458, "bv", ((V)("pol"))), ((V)(0D)), ((V)(1D)));
Invoke(Get(B_1457, "bloom"), "forEach", Fn((V _self1450, int _argc1463, V b_1469, V _a1466, V _a1467, V _a1468, V[] _rest1464) => {
return Invoke(Get(b_1469, "e"), "setAttribute", ((V)("opacity")), Call(r2_18, V.Undef, ((V)((ToNum(Get(b_1469, "op")) * (1D - (0.92 * ToNum(p_1459))))))));
}, 1, "", true));
if (LtN(p_1459, 0.02)) {
if (!SEqN(Get(B_1457, "glOn"), 0D)) {
Set(B_1457, "glOn", ((V)(0D)));
Call(SA_23, V.Undef, Get(B_1457, "gl"), ((V)("opacity")), ((V)(0D)));
}
return default;
}
Set(B_1457, "glOn", ((V)(1D)));
Q_1460 = Arr();
N_1461 = 14D;
A_1462 = Fn((V _self1450, int _argc1470, V u_1476, V _a1473, V _a1474, V _a1475, V[] _rest1471) => {
return ((V)((((40D + (62D * ToNum(u_1476))) * System.Math.PI) / 180D)));
}, 1, "", true);
{
double i_1477 = 0;
i_1477 = 0D;
while (true) {
if (!((i_1477 <= N_1461))) break;
V a_1479 = default;
a_1479 = Call(A_1462, V.Undef, ((V)((i_1477 / N_1461))));
Invoke(Q_1460, "push", Invoke(D_1458, "glob", ((V)((50D + (28D * FdLibm.Sin(ToNum(a_1479)))))), ((V)((60D - (27D * FdLibm.Cos(ToNum(a_1479))))))));
i_1477++;
}
}
{
double i_1480 = 0;
i_1480 = N_1461;
while (true) {
if (!((i_1480 >= 0D))) break;
double u_1482 = 0;
V a_1483 = default;
double k_1484 = 0;
u_1482 = (i_1480 / N_1461);
a_1483 = Call(A_1462, V.Undef, ((V)(u_1482)));
k_1484 = (28D - (3D * FdLibm.Sin((System.Math.PI * u_1482))));
Invoke(Q_1460, "push", Invoke(D_1458, "glob", ((V)((50D + (k_1484 * FdLibm.Sin(ToNum(a_1483)))))), ((V)((60D - ((k_1484 - 1D) * FdLibm.Cos(ToNum(a_1483))))))));
i_1480--;
}
}
Call(SA_23, V.Undef, Get(B_1457, "gl"), ((V)("d")), Call(polyW_13, V.Undef, Q_1460));
Call(SA_23, V.Undef, Get(B_1457, "gl"), ((V)("opacity")), Call(r2_18, V.Undef, ((V)((0.6 * ToNum(p_1459))))));
return default;
}, 2, "draw", false)).V).V));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
