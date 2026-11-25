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
SA_23 = Fn((V _arrowThis82, int _argc73, V e_79, V k_80, V v_81, V _a78, V[] _rest74) => {
if (!SEq(GetK(e_79, ((V)(JsStrBuf.Begin().S("_").V(k_80).End()))), v_81)) {
SetK(e_79, ((V)(JsStrBuf.Begin().S("_").V(k_80).End())), v_81);
Invoke(e_79, "setAttribute", k_80, v_81);
}
return default;
}, 3, "", true);
REV_24 = Fn((V _arrowThis91, int _argc83, V S_89, V o_90, V _a87, V _a88, V[] _rest84) => {
V O_92 = default;
V yT_93 = default;
V yB_94 = default;
V ext_95 = default;
double N_96 = 0;
V RR_97 = default;
V CX_98 = default;
V look_99 = default;
V kz_100 = default;
V cx_101 = default;
V rT_102 = default;
V dr_103 = default;
V rmax_104 = default;
V zAt_105 = default;
V at_106 = default;
V fOf_107 = default;
O_92 = Invoke(S_89, "outline", Get(S_89, "sk"), (Get(o_90, "n") is var _t108 && Truthy(_t108) ? _t108 : ((V)(96D))));
yT_93 = ((V)(1000000000D));
yB_94 = ((V)((-1000000000D)));
Invoke(O_92, "forEach", Fn((V _arrowThis116, int _argc109, V p_115, V _a112, V _a113, V _a114, V[] _rest110) => {
if (Lt(GetIdx(p_115, 1D), yT_93)) {
yT_93 = GetIdx(p_115, 1D);
}
if (Gt(GetIdx(p_115, 1D), yB_94)) {
yB_94 = GetIdx(p_115, 1D);
}
return default;
}, 1, "", true));
ext_95 = Fn((V _arrowThis124, int _argc117, V y_123, V _a120, V _a121, V _a122, V[] _rest118) => {
V lo_125 = default;
V hi_126 = default;
lo_125 = ((V)(1000000000D));
hi_126 = ((V)((-1000000000D)));
{
double i_127 = 0;
i_127 = 0D;
while (true) {
if (!(Lt(((V)(i_127)), Get(O_92, "length")))) break;
V a_129 = default;
V b_130 = default;
a_129 = GetIdx(O_92, i_127);
b_130 = GetIdx(O_92, ((i_127 + 1D) % ToNum(Get(O_92, "length"))));
if (((((ToNum(GetIdx(a_129, 1D)) - ToNum(y_123)) * (ToNum(GetIdx(b_130, 1D)) - ToNum(y_123))) <= 0D) && !SEq(GetIdx(a_129, 1D), GetIdx(b_130, 1D)))) {
V x_131 = default;
x_131 = Add(GetIdx(a_129, 0D), ((V)((((ToNum(GetIdx(b_130, 0D)) - ToNum(GetIdx(a_129, 0D))) * (ToNum(y_123) - ToNum(GetIdx(a_129, 1D)))) / (ToNum(GetIdx(b_130, 1D)) - ToNum(GetIdx(a_129, 1D)))))));
if (Lt(x_131, lo_125)) {
lo_125 = x_131;
}
if (Gt(x_131, hi_126)) {
hi_126 = x_131;
}
}
i_127++;
}
}
return (Lt(hi_126, lo_125) ? Arr(((V)(50D)), ((V)(50D))) : Arr(lo_125, hi_126));
return default;
}, 1, "", true);
N_96 = System.Math.Ceiling(((ToNum(yB_94) - ToNum(yT_93)) / 0.5));
RR_97 = Arr();
CX_98 = Arr();
{
double i_132 = 0;
i_132 = 0D;
while (true) {
if (!((i_132 <= N_96))) break;
V e_134 = default;
e_134 = Call(ext_95, V.Undef, ((V)(Min(ToNum(yB_94), ToNum(Add(yT_93, ((V)((i_132 * 0.5)))))))));
Invoke(RR_97, "push", ((V)(((ToNum(GetIdx(e_134, 1D)) - ToNum(GetIdx(e_134, 0D))) / 2D))));
Invoke(CX_98, "push", ((V)((ToNum(Add(GetIdx(e_134, 0D), GetIdx(e_134, 1D))) / 2D))));
i_132++;
}
}
look_99 = Fn((V _arrowThis143, int _argc135, V A_141, V y_142, V _a139, V _a140, V[] _rest136) => {
V u_144 = default;
double i_145 = 0;
double f_146 = 0;
u_144 = Call(clamp_16, V.Undef, ((V)(((ToNum(y_142) - ToNum(yT_93)) / 0.5))), ((V)(0D)), ((V)(N_96)));
i_145 = Min((N_96 - 1D), System.Math.Floor(ToNum(u_144)));
f_146 = (ToNum(u_144) - i_145);
return Add(GetIdx(A_141, i_145), ((V)(((ToNum(GetIdx(A_141, (i_145 + 1D))) - ToNum(GetIdx(A_141, i_145))) * f_146))));
return default;
}, 2, "", true);
kz_100 = (Get(o_90, "kz") is var _t147 && Truthy(_t147) ? _t147 : ((V)(1D)));
cx_101 = (SEqS(Get(o_90, "cx"), "mid") ? Fn((V _arrowThis155, int _argc148, V y_154, V _a151, V _a152, V _a153, V[] _rest149) => {
return Call(look_99, V.Undef, CX_98, y_154);
}, 1, "", true) : Fn((V _arrowThis162, int _argc156, V _a158, V _a159, V _a160, V _a161, V[] _rest157) => {
return (Get(o_90, "cx") is var _t163 && Truthy(_t163) ? _t163 : ((V)(50D)));
}, 0, "", true));
rT_102 = Fn((V _arrowThis171, int _argc164, V y_170, V _a167, V _a168, V _a169, V[] _rest165) => {
return Call(look_99, V.Undef, RR_97, y_170);
}, 1, "", true);
dr_103 = Fn((V _arrowThis179, int _argc172, V y_178, V _a175, V _a176, V _a177, V[] _rest173) => {
return ((V)((ToNum(Call(rT_102, V.Undef, Add(y_178, ((V)(0.5))))) - ToNum(Call(rT_102, V.Undef, ((V)((ToNum(y_178) - 0.5))))))));
}, 1, "", true);
rmax_104 = ((V)(0D));
Invoke(RR_97, "forEach", Fn((V _arrowThis187, int _argc180, V r_186, V _a183, V _a184, V _a185, V[] _rest181) => {
if (Gt(r_186, rmax_104)) {
rmax_104 = r_186;
}
return default;
}, 1, "", true));
zAt_105 = Fn((V _arrowThis196, int _argc188, V x_194, V y_195, V _a192, V _a193, V[] _rest189) => {
V r_197 = default;
double d_198 = 0;
r_197 = Call(rT_102, V.Undef, y_195);
d_198 = (ToNum(x_194) - ToNum(Call(cx_101, V.Undef, y_195)));
return ((V)((((d_198 * d_198) < (ToNum(r_197) * ToNum(r_197))) ? (ToNum(kz_100) * System.Math.Sqrt(((ToNum(r_197) * ToNum(r_197)) - (d_198 * d_198)))) : 0D)));
return default;
}, 2, "", true);
at_106 = Fn((V _arrowThis208, int _argc199, V f_205, V y_206, V lift_207, V _a204, V[] _rest200) => {
V r_209 = default;
double s_210 = 0;
double c_211 = 0;
double nx_212 = 0;
double nz_213 = 0;
double ny_214 = 0;
V L_215 = default;
r_209 = Add(Call(rT_102, V.Undef, y_206), (lift_207 is var _t216 && Truthy(_t216) ? _t216 : ((V)(0D))));
s_210 = FdLibm.Sin(ToNum(f_205));
c_211 = FdLibm.Cos(ToNum(f_205));
nx_212 = s_210;
nz_213 = (c_211 / ToNum(kz_100));
ny_214 = (-ToNum(Call(dr_103, V.Undef, y_206)));
L_215 = (((V)(Hypot(nx_212, ny_214, nz_213))) is var _t217 && Truthy(_t217) ? _t217 : ((V)(1D)));
return Arr(Add(Call(cx_101, V.Undef, y_206), ((V)((ToNum(r_209) * s_210)))), y_206, ((V)(((ToNum(kz_100) * ToNum(r_209)) * c_211))), ((V)((nx_212 / ToNum(L_215)))), ((V)((ny_214 / ToNum(L_215)))), ((V)((nz_213 / ToNum(L_215)))));
return default;
}, 3, "", true);
fOf_107 = Fn((V _arrowThis226, int _argc218, V x_224, V y_225, V _a222, V _a223, V[] _rest219) => {
V r_227 = default;
r_227 = Call(rT_102, V.Undef, y_225);
return ((V)(FdLibm.Asin(ToNum(Call(clamp_16, V.Undef, ((V)(((ToNum(x_224) - ToNum(Call(cx_101, V.Undef, y_225))) / ToNum((r_227 is var _t228 && Truthy(_t228) ? _t228 : ((V)(1D))))))), ((V)((-1D))), ((V)(1D)))))));
return default;
}, 2, "", true);
return NewObj(10).Put("O", O_92).Put("yT", yT_93).Put("yB", yB_94).Put("rT", rT_102).Put("cx", cx_101).Put("kz", kz_100).Put("zAt", zAt_105).Put("at", at_106).Put("fOf", fOf_107).Put("rmax", rmax_104).V;
return default;
}, 2, "", true);
SIL_25 = Fn((V _arrowThis237, int _argc229, V D_235, V R_236, V _a233, V _a234, V[] _rest230) => {
V P3_238 = default;
double n_239 = 0;
double st_240 = 0;
V G_241 = default;
P3_238 = Get(D_235, "P3");
n_239 = Max(2D, System.Math.Ceiling(((ToNum(Get(R_236, "yB")) - ToNum(Get(R_236, "yT"))) / 2.5)));
st_240 = ((ToNum(Get(R_236, "yB")) - ToNum(Get(R_236, "yT"))) / n_239);
G_241 = Arr();
{
double i_242 = 0;
i_242 = 0D;
while (true) {
if (!((i_242 <= n_239))) break;
V y_244 = default;
V cx_245 = default;
V c_246 = default;
V e1_247 = default;
V e2_248 = default;
V a_249 = default;
double E1x_250 = 0;
double E1y_251 = 0;
double E2x_252 = 0;
double E2y_253 = 0;
double Ax_254 = 0;
double Ay_255 = 0;
V L_256 = default;
double nx_257 = 0;
double ny_258 = 0;
double an_259 = 0;
double ca_260 = 0;
double sa_261 = 0;
y_244 = Add(Get(R_236, "yT"), ((V)((i_242 * st_240))));
cx_245 = Invoke(R_236, "cx", y_244);
c_246 = Call(P3_238, V.Undef, cx_245, y_244, ((V)(0D)));
e1_247 = Call(P3_238, V.Undef, Add(cx_245, ((V)(1D))), y_244, ((V)(0D)));
e2_248 = Call(P3_238, V.Undef, cx_245, y_244, Get(R_236, "kz"));
a_249 = Call(P3_238, V.Undef, cx_245, Add(y_244, ((V)(1D))), ((V)(0D)));
E1x_250 = (ToNum(GetIdx(e1_247, 0D)) - ToNum(GetIdx(c_246, 0D)));
E1y_251 = (ToNum(GetIdx(e1_247, 1D)) - ToNum(GetIdx(c_246, 1D)));
E2x_252 = (ToNum(GetIdx(e2_248, 0D)) - ToNum(GetIdx(c_246, 0D)));
E2y_253 = (ToNum(GetIdx(e2_248, 1D)) - ToNum(GetIdx(c_246, 1D)));
Ax_254 = (ToNum(GetIdx(a_249, 0D)) - ToNum(GetIdx(c_246, 0D)));
Ay_255 = (ToNum(GetIdx(a_249, 1D)) - ToNum(GetIdx(c_246, 1D)));
L_256 = (((V)(Hypot(Ax_254, Ay_255))) is var _t262 && Truthy(_t262) ? _t262 : ((V)(1D)));
nx_257 = (Ay_255 / ToNum(L_256));
ny_258 = ((-Ax_254) / ToNum(L_256));
an_259 = FdLibm.Atan2(((nx_257 * E2x_252) + (ny_258 * E2y_253)), ((nx_257 * E1x_250) + (ny_258 * E1y_251)));
ca_260 = FdLibm.Cos(an_259);
sa_261 = FdLibm.Sin(an_259);
Invoke(G_241, "push", Arr(GetIdx(c_246, 0D), GetIdx(c_246, 1D), ((V)(((E1x_250 * ca_260) + (E2x_252 * sa_261)))), ((V)(((E1y_251 * ca_260) + (E2y_253 * sa_261))))));
i_242++;
}
}
return Call(polyD_12, V.Undef, Invoke(Get(R_236, "O"), "map", Fn((V _arrowThis270, int _argc263, V p_269, V _a266, V _a267, V _a268, V[] _rest264) => {
V u_271 = default;
double i_272 = 0;
double f_273 = 0;
V A_274 = default;
V B_275 = default;
double d_276 = 0;
V q_277 = default;
u_271 = Call(clamp_16, V.Undef, ((V)(((ToNum(GetIdx(p_269, 1D)) - ToNum(Get(R_236, "yT"))) / st_240))), ((V)(0D)), ((V)(n_239)));
i_272 = Min((n_239 - 1D), System.Math.Floor(ToNum(u_271)));
f_273 = (ToNum(u_271) - i_272);
A_274 = GetIdx(G_241, i_272);
B_275 = GetIdx(G_241, (i_272 + 1D));
d_276 = (ToNum(GetIdx(p_269, 0D)) - ToNum(Invoke(R_236, "cx", GetIdx(p_269, 1D))));
q_277 = Fn((V _arrowThis285, int _argc278, V k_284, V _a281, V _a282, V _a283, V[] _rest279) => {
return Add(GetK(A_274, k_284), ((V)(((ToNum(GetK(B_275, k_284)) - ToNum(GetK(A_274, k_284))) * f_273))));
}, 1, "", true);
return Arr(Add(Call(q_277, V.Undef, ((V)(0D))), ((V)((d_276 * ToNum(Call(q_277, V.Undef, ((V)(2D)))))))), Add(Call(q_277, V.Undef, ((V)(1D))), ((V)((d_276 * ToNum(Call(q_277, V.Undef, ((V)(3D)))))))));
return default;
}, 1, "", true)));
return default;
}, 2, "", true);
PEL_26 = Fn((V _arrowThis296, int _argc286, V D_292, V EL_293, V ax_294, V ay_295, V[] _rest287) => {
return Fn((V _arrowThis306, int _argc297, V x_303, V y_304, V z_305, V _a302, V[] _rest298) => {
V p_307 = default;
p_307 = Invoke(D_292, "P3", x_303, y_304, z_305);
return Arr(GetIdx(p_307, 0D), Add(GetIdx(p_307, 1D), ((V)((ToNum(EL_293) * (ToNum(Invoke(D_292, "Z3", x_303, y_304, z_305)) - ToNum(Invoke(D_292, "Z3", ax_294, ay_295, ((V)(0D))))))))));
return default;
}, 3, "", true);
}, 4, "", true);
fade_27 = Fn((V _arrowThis317, int _argc308, V f_314, V a_315, V w_316, V _a313, V[] _rest309) => {
return Call(SM_17, V.Undef, ((V)(((ToNum(f_314) - ToNum(a_315)) / ToNum(w_316)))));
}, 3, "", true);
ROLLF_28 = Fn((V _arrowThis326, int _argc318, V R_324, V cy0_325, V _a322, V _a323, V[] _rest319) => {
V OS_327 = default;
OS_327 = Invoke(Get(R_324, "O"), "filter", Fn((V _arrowThis336, int _argc328, V p_334, V i_335, V _a332, V _a333, V[] _rest329) => {
return (((ToNum(i_335) % 3D) == 0D) ? V.True : V.False);
}, 2, "", true));
return Fn((V _arrowThis347, int _argc337, V a_343, V P_344, V G_345, V sy_346, V[] _rest338) => {
double c_348 = 0;
double s_349 = 0;
V lf_350 = default;
V px_351 = default;
V cx_352 = default;
double cy_353 = 0;
double my_354 = 0;
c_348 = FdLibm.Cos(ToNum(a_343));
s_349 = FdLibm.Sin(ToNum(a_343));
lf_350 = (((V)(ToNum(Get(P_344, "lift")))) is var _t355 && Truthy(_t355) ? _t355 : ((V)(0D)));
px_351 = (((V)(ToNum(Get(P_344, "x")))) is var _t356 && Truthy(_t356) ? _t356 : ((V)(0D)));
cx_352 = Add(((V)(50D)), px_351);
cy_353 = ((ToNum(G_345) - ToNum(lf_350)) - ((ToNum(G_345) - ToNum(cy0_325)) * ToNum(sy_346)));
my_354 = (-1000000000D);
Invoke(OS_327, "forEach", Fn((V _arrowThis364, int _argc357, V p_363, V _a360, V _a361, V _a362, V[] _rest358) => {
V gx_365 = default;
double gy_366 = 0;
double y_367 = 0;
gx_365 = Add(GetIdx(p_363, 0D), px_351);
gy_366 = ((ToNum(G_345) - ToNum(lf_350)) - ((ToNum(G_345) - ToNum(GetIdx(p_363, 1D))) * ToNum(sy_346)));
y_367 = ((cy_353 + ((ToNum(gx_365) - ToNum(cx_352)) * s_349)) + ((gy_366 - cy_353) * c_348));
if ((y_367 > my_354)) {
my_354 = y_367;
}
return default;
}, 1, "", true));
return NewObj(5).Put("c", ((V)(c_348))).Put("s", ((V)(s_349))).Put("cx", cx_352).Put("cy", ((V)(cy_353))).Put("up", ((V)((my_354 - (ToNum(G_345) - ToNum(lf_350)))))).V;
return default;
}, 4, "", true);
return default;
}, 2, "", true);
DECS_29 = Fn((V _arrowThis379, int _argc368, V S_374, V R_375, V pred_376, V copies_377, V[] _rest369) => {
V @out_380 = default;
V par_378 = default;
par_378 = (_argc368 > 4 ? _rest369[0] : V.Undef);
@out_380 = Arr();
Invoke(Invoke(S_374, "decals", pred_376, par_378), "forEach", Fn((V _arrowThis388, int _argc381, V o_387, V _a384, V _a385, V _a386, V[] _rest382) => {
V sx_389 = default;
V sy_390 = default;
double n_391 = 0;
V c_392 = default;
double op_393 = 0;
V line_394 = default;
sx_389 = ((V)(0D));
sy_390 = ((V)(0D));
n_391 = 0D;
Invoke(Get(o_387, "L"), "forEach", Fn((V _arrowThis402, int _argc395, V L_401, V _a398, V _a399, V _a400, V[] _rest396) => {
return Invoke(L_401, "forEach", Fn((V _arrowThis410, int _argc403, V p_409, V _a406, V _a407, V _a408, V[] _rest404) => {
sx_389 = Add(sx_389, GetIdx(p_409, 0D));
sy_390 = Add(sy_390, GetIdx(p_409, 1D));
n_391++;
return default;
}, 1, "", true));
}, 1, "", true));
c_392 = Arr(((V)((ToNum(sx_389) / ToNum((((V)(n_391)) is var _t411 && Truthy(_t411) ? _t411 : ((V)(1D))))))), ((V)((ToNum(sy_390) / ToNum((((V)(n_391)) is var _t412 && Truthy(_t412) ? _t412 : ((V)(1D))))))));
op_393 = ToNum((Invoke(Get(o_387, "e"), "getAttribute", ((V)("opacity"))) is var _t413 && Truthy(_t413) ? _t413 : ((V)(1D))));
line_394 = (SEqS((Invoke(Get(o_387, "e"), "getAttribute", ((V)("fill"))) is var _t414 && Truthy(_t414) ? _t414 : ((V)(""))), "none") ? V.True : V.False);
Invoke((copies_377 is var _t425 && Truthy(_t425) ? _t425 : Arr(((V)(0D)))), "forEach", Fn((V _arrowThis423, int _argc415, V dA_421, V i_422, V _a419, V _a420, V[] _rest416) => {
V e_424 = default;
e_424 = (Truthy(i_422) ? Invoke(Get(Get(o_387, "e"), "parentNode"), "insertBefore", Invoke(Get(o_387, "e"), "cloneNode"), Get(Get(o_387, "e"), "nextSibling")) : Get(o_387, "e"));
Invoke(@out_380, "push", NewObj(6).Put("e", e_424).Put("L", Get(o_387, "L")).Put("c", c_392).Put("op", ((V)(op_393))).Put("dA", dA_421).Put("line", line_394).V);
return default;
}, 2, "", true));
return default;
}, 1, "", true));
return @out_380;
return default;
}, 5, "", true);
decDraw_30 = Fn((V _arrowThis435, int _argc426, V D_432, V R_433, V list_434, V _a431, V[] _rest427) => {
return Invoke(list_434, "forEach", Fn((V _arrowThis443, int _argc436, V o_442, V _a439, V _a440, V _a441, V[] _rest437) => {
V f0_444 = default;
V s_445 = default;
V v_446 = default;
V map_447 = default;
f0_444 = Add(Invoke(R_433, "fOf", GetIdx(Get(o_442, "c"), 0D), GetIdx(Get(o_442, "c"), 1D)), Get(o_442, "dA"));
s_445 = Invoke(R_433, "at", f0_444, GetIdx(Get(o_442, "c"), 1D));
v_446 = Call(fade_27, V.Undef, Invoke(D_432, "facing", GetIdx(s_445, 0D), GetIdx(s_445, 1D), GetIdx(s_445, 2D), GetIdx(s_445, 3D), GetIdx(s_445, 4D), GetIdx(s_445, 5D)), ((V)(0.02)), ((V)(0.28)));
if (LtN(v_446, 0.01)) {
if (!SEqN(Get(o_442, "on"), 0D)) {
Set(o_442, "on", ((V)(0D)));
Invoke(Get(o_442, "e"), "setAttribute", ((V)("opacity")), ((V)(0D)));
}
return default;
}
Set(o_442, "on", ((V)(1D)));
Call(SA_23, V.Undef, Get(o_442, "e"), ((V)("opacity")), Call(r2_18, V.Undef, ((V)((ToNum(Get(o_442, "op")) * ToNum(v_446))))));
map_447 = Fn((V _arrowThis456, int _argc448, V x_454, V y_455, V _a452, V _a453, V[] _rest449) => {
V p_457 = default;
p_457 = Invoke(R_433, "at", Add(Invoke(R_433, "fOf", x_454, y_455), Get(o_442, "dA")), y_455, ((V)(0.12)));
return Invoke(D_432, "P3", GetIdx(p_457, 0D), GetIdx(p_457, 1D), GetIdx(p_457, 2D));
return default;
}, 2, "", true);
if (Truthy(Get(o_442, "line"))) {
JsStrBuf d_458 = null;
d_458 = new JsStrBuf("");
Invoke(Get(o_442, "L"), "forEach", Fn((V _arrowThis466, int _argc459, V L_465, V _a462, V _a463, V _a464, V[] _rest460) => {
V Q_467 = default;
V ok_468 = default;
Q_467 = Arr();
ok_468 = Arr();
Invoke(L_465, "forEach", Fn((V _arrowThis480, int _argc469, V _a471, V _a472, V _a473, V _a474, V[] _rest470) => {
V p_481 = default;
V x_477 = default;
V y_479 = default;
{ V _t475 = ListOf(_a471);
{ V _t476 = GetIdx(_t475, 0D);
x_477 = _t476; }
{ V _t478 = GetIdx(_t475, 1D);
y_479 = _t478; }
}
p_481 = Invoke(R_433, "at", Add(Invoke(R_433, "fOf", x_477, y_479), Get(o_442, "dA")), y_479, ((V)(0.12)));
Invoke(Q_467, "push", Invoke(D_432, "P3", GetIdx(p_481, 0D), GetIdx(p_481, 1D), GetIdx(p_481, 2D)));
Invoke(ok_468, "push", (GtN(Invoke(D_432, "facing", GetIdx(p_481, 0D), GetIdx(p_481, 1D), GetIdx(p_481, 2D), GetIdx(p_481, 3D), GetIdx(p_481, 4D), GetIdx(p_481, 5D)), 0.03) ? V.True : V.False));
return default;
}, 1, "", true));
d_458.V(Call(runs_15, V.Undef, Q_467, ok_468));
return default;
}, 1, "", true));
Invoke(Get(o_442, "e"), "setAttribute", ((V)("d")), (((V)(d_458.Str)) is var _t482 && Truthy(_t482) ? _t482 : ((V)("M0 0"))));
} else {
Invoke(Get(o_442, "e"), "setAttribute", ((V)("d")), Call(decD_21, V.Undef, o_442, map_447));
}
return default;
}, 1, "", true));
}, 3, "", true);
FIX_31 = Fn((V _arrowThis492, int _argc483, V S_489, V pred_490, V par_491, V _a488, V[] _rest484) => {
return Invoke(Invoke(S_489, "decals", pred_490, par_491), "map", Fn((V _arrowThis500, int _argc493, V o_499, V _a496, V _a497, V _a498, V[] _rest494) => {
return o_499;
}, 1, "", true));
}, 3, "", true);
fixDraw_32 = Fn((V _arrowThis509, int _argc501, V D_507, V list_508, V _a505, V _a506, V[] _rest502) => {
return Invoke(list_508, "forEach", Fn((V _arrowThis517, int _argc510, V o_516, V _a513, V _a514, V _a515, V[] _rest511) => {
return Invoke(Get(o_516, "e"), "setAttribute", ((V)("d")), Call(decD_21, V.Undef, o_516, Fn((V _arrowThis526, int _argc518, V x_524, V y_525, V _a522, V _a523, V[] _rest519) => {
return Invoke(D_507, "glob", x_524, y_525);
}, 2, "", true)));
}, 1, "", true));
}, 2, "", true);
SHINE_33 = Fn((V _arrowThis534, int _argc527, V S_533, V _a530, V _a531, V _a532, V[] _rest528) => {
return Invoke(Invoke(S_533, "hide", Fn((V _arrowThis553, int _argc546, V q_552, V _a549, V _a550, V _a551, V[] _rest547) => {
return ((SEqS(Get(q_552, "role"), "shine") && !(Truthy(Get(q_552, "inBody")))) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis542, int _argc535, V q_541, V _a538, V _a539, V _a540, V[] _rest536) => {
V e_543 = default;
e_543 = Call(el_10, V.Undef, ((V)("path")), NewObj(2).Put("fill", (Invoke(Get(q_541, "e"), "getAttribute", ((V)("fill"))) is var _t544 && Truthy(_t544) ? _t544 : ((V)("#fff")))).Put("opacity", (Invoke(Get(q_541, "e"), "getAttribute", ((V)("opacity"))) is var _t545 && Truthy(_t545) ? _t545 : ((V)(0.85)))).V, Get(Get(q_541, "e"), "parentNode"), Get(q_541, "e"));
return NewObj(2).Put("e", e_543).Put("L", Call(subs_20, V.Undef, Get(q_541, "segs"), ((V)(8D)))).V;
return default;
}, 1, "", true));
}, 1, "", true);
SCAT_34 = Fn((V _arrowThis565, int _argc554, V R_560, V n_561, V seed_562, V min_563, V[] _rest555) => {
V @out_566 = default;
V avoid_564 = default;
avoid_564 = (_argc554 > 4 ? _rest555[0] : V.Undef);
@out_566 = Arr();
{
double k_567 = 0;
k_567 = 0D;
while (true) {
if (!((Lt(Get(@out_566, "length"), n_561) && (k_567 < (ToNum(n_561) * 60D))))) break;
V y_569 = default;
double f_570 = 0;
V p_571 = default;
y_569 = Add(Add(Get(R_560, "yT"), ((V)(2.5))), ((V)((ToNum(Call(rnd_19, V.Undef, Add(seed_562, ((V)((k_567 * 1.31)))))) * ((ToNum(Get(R_560, "yB")) - ToNum(Get(R_560, "yT"))) - 5D)))));
f_570 = (((ToNum(Call(rnd_19, V.Undef, Add(seed_562, ((V)((k_567 * 2.77)))))) * 2D) - 1D) * System.Math.PI);
if (GtN(Call(rnd_19, V.Undef, Add(seed_562, ((V)((k_567 * 5.13))))), (ToNum(Invoke(R_560, "rT", y_569)) / ToNum(Get(R_560, "rmax"))))) {
goto _cont568;
}
if (Truthy((avoid_564 is var _t572 && !Truthy(_t572) ? _t572 : Call(avoid_564, V.Undef, ((V)(f_570)), y_569)))) {
goto _cont568;
}
p_571 = Invoke(R_560, "at", ((V)(f_570)), y_569);
if (Truthy(Invoke(@out_566, "some", Fn((V _arrowThis580, int _argc573, V q_579, V _a576, V _a577, V _a578, V[] _rest574) => {
return (Lt(((V)(Hypot((ToNum(GetIdx(Get(q_579, "p"), 0D)) - ToNum(GetIdx(p_571, 0D))), (ToNum(GetIdx(Get(q_579, "p"), 1D)) - ToNum(GetIdx(p_571, 1D))), (ToNum(GetIdx(Get(q_579, "p"), 2D)) - ToNum(GetIdx(p_571, 2D)))))), min_563) ? V.True : V.False);
}, 1, "", true)))) {
goto _cont568;
}
Invoke(@out_566, "push", NewObj(4).Put("f", ((V)(f_570))).Put("y", y_569).Put("p", p_571).Put("k", Call(rnd_19, V.Undef, Add(seed_562, ((V)((k_567 * 7.7)))))).V);
_cont568: ;
k_567++;
}
}
return @out_566;
return default;
}, 5, "", true);
faceAvoid_35 = Fn((V _arrowThis590, int _argc581, V y0_587, V y1_588, V fw_589, V _a586, V[] _rest582) => {
return Fn((V _arrowThis599, int _argc591, V f_597, V y_598, V _a595, V _a596, V[] _rest592) => {
return (((Lt(((V)(System.Math.Abs(ToNum(f_597)))), (fw_589 is var _t600 && Truthy(_t600) ? _t600 : ((V)(0.72)))) && Gt(y_598, y0_587)) && Lt(y_598, y1_588)) ? V.True : V.False);
}, 2, "", true);
}, 3, "", true);
dotsDraw_36 = Fn((V _arrowThis610, int _argc601, V D_607, V R_608, V o_609, V _a606, V[] _rest602) => {
JsStrBuf d_611 = null;
double r_612 = 0;
d_611 = new JsStrBuf("");
r_612 = (ToNum(Get(o_609, "r")) * ToNum(Get(D_607, "kS")));
Invoke(Get(o_609, "P"), "forEach", Fn((V _arrowThis620, int _argc613, V s_619, V _a616, V _a617, V _a618, V[] _rest614) => {
V p_621 = default;
p_621 = Invoke(R_608, "at", Get(s_619, "f"), Get(s_619, "y"), ((V)(0.1)));
if (LtN(Invoke(D_607, "facing", GetIdx(p_621, 0D), GetIdx(p_621, 1D), GetIdx(p_621, 2D), GetIdx(p_621, 3D), GetIdx(p_621, 4D), GetIdx(p_621, 5D)), 0.1)) {
return default;
}
d_611.V(Call(circD_14, V.Undef, Invoke(D_607, "P3", GetIdx(p_621, 0D), GetIdx(p_621, 1D), GetIdx(p_621, 2D)), ((V)((r_612 * (0.8 + (ToNum(Get(s_619, "k")) * 0.4)))))));
return default;
}, 1, "", true));
Call(SA_23, V.Undef, Get(o_609, "e"), ((V)("d")), (((V)(d_611.Str)) is var _t622 && Truthy(_t622) ? _t622 : ((V)("M0 0"))));
return default;
}, 3, "", true);
fibDraw_37 = Fn((V _arrowThis632, int _argc623, V D_629, V R_630, V o_631, V _a628, V[] _rest624) => {
JsStrBuf d_633 = null;
V fz_634 = default;
d_633 = new JsStrBuf("");
fz_634 = Call(clamp_16, V.Undef, Invoke(D_629, "bv", ((V)("fz"))), ((V)(0D)), ((V)(1.3)));
Invoke(Get(o_631, "P"), "forEach", Fn((V _arrowThis642, int _argc635, V s_641, V _a638, V _a639, V _a640, V[] _rest636) => {
V p_643 = default;
double a_644 = 0;
double L_645 = 0;
V q_646 = default;
p_643 = Invoke(R_630, "at", Get(s_641, "f"), Get(s_641, "y"), ((V)(0.1)));
if (LtN(Invoke(D_629, "facing", GetIdx(p_643, 0D), GetIdx(p_643, 1D), GetIdx(p_643, 2D), GetIdx(p_643, 3D), GetIdx(p_643, 4D), GetIdx(p_643, 5D)), 0.12)) {
return default;
}
a_644 = (ToNum(Get(s_641, "k")) * TAU_22);
L_645 = ((1.8 + (ToNum(Get(s_641, "k")) * 1.2)) * (1D - (ToNum(fz_634) * 0.25)));
q_646 = Invoke(R_630, "at", Add(Get(s_641, "f"), ((V)(((FdLibm.Cos(a_644) * L_645) / Max(4D, ToNum(Invoke(R_630, "rT", Get(s_641, "y")))))))), Add(Get(s_641, "y"), ((V)((FdLibm.Sin(a_644) * L_645)))), ((V)((0.1 + (ToNum(fz_634) * (1.6 + (ToNum(Get(s_641, "k")) * 1.4)))))));
d_633.S("M").V(Call(pt_11, V.Undef, Invoke(D_629, "P3", GetIdx(p_643, 0D), GetIdx(p_643, 1D), GetIdx(p_643, 2D)))).S("L").V(Call(pt_11, V.Undef, Invoke(D_629, "P3", GetIdx(q_646, 0D), GetIdx(q_646, 1D), GetIdx(q_646, 2D))));
return default;
}, 1, "", true));
Call(SA_23, V.Undef, Get(o_631, "e"), ((V)("d")), (((V)(d_633.Str)) is var _t647 && Truthy(_t647) ? _t647 : ((V)("M0 0"))));
return default;
}, 3, "", true);
ridgeDraw_38 = Fn((V _arrowThis657, int _argc648, V D_654, V R_655, V o_656, V _a653, V[] _rest649) => {
JsStrBuf d_658 = null;
d_658 = new JsStrBuf("");
Invoke(Get(o_656, "F"), "forEach", Fn((V _arrowThis666, int _argc659, V f_665, V _a662, V _a663, V _a664, V[] _rest660) => {
V Q_667 = default;
V ok_668 = default;
Q_667 = Arr();
ok_668 = Arr();
{
V y_669 = default;
y_669 = Get(o_656, "y0");
while (true) {
if (!(Le(y_669, Get(o_656, "y1")))) break;
V p_671 = default;
p_671 = Invoke(R_655, "at", f_665, y_669, ((V)(0.05)));
Invoke(Q_667, "push", Invoke(D_654, "P3", GetIdx(p_671, 0D), GetIdx(p_671, 1D), GetIdx(p_671, 2D)));
Invoke(ok_668, "push", (GtN(Invoke(D_654, "facing", GetIdx(p_671, 0D), GetIdx(p_671, 1D), GetIdx(p_671, 2D), GetIdx(p_671, 3D), GetIdx(p_671, 4D), GetIdx(p_671, 5D)), 0.12) ? V.True : V.False));
y_669 = Add(y_669, ((V)(1.5)));
}
}
d_658.V(Call(runs_15, V.Undef, Q_667, ok_668));
return default;
}, 1, "", true));
Call(SA_23, V.Undef, Get(o_656, "e"), ((V)("d")), (((V)(d_658.Str)) is var _t672 && Truthy(_t672) ? _t672 : ((V)("M0 0"))));
return default;
}, 3, "", true);
TOPS_39 = Fn((V _arrowThis681, int _argc673, V S_679, V o_680, V _a677, V _a678, V[] _rest674) => {
V G_682 = default;
V L_683 = default;
double n_684 = 0;
G_682 = Invoke(S_679, "g");
L_683 = Invoke(Invoke(S_679, "decals", Fn((V _arrowThis722, int _argc715, V q_721, V _a718, V _a719, V _a720, V[] _rest716) => {
return Invoke(S_679, "dk", q_721, ((V)("top")));
}, 1, "", true), G_682), "map", Fn((V _arrowThis692, int _argc685, V d_691, V _a688, V _a689, V _a690, V[] _rest686) => {
if (Truthy(Invoke(NewRegExp(RX0, "^url\\(#l", ""), "test", (Invoke(Get(d_691, "e"), "getAttribute", ((V)("fill"))) is var _t693 && Truthy(_t693) ? _t693 : ((V)("")))))) {
V b_694 = default;
V tp_695 = default;
double md_696 = 0;
b_694 = GetIdx(GetIdx(Get(d_691, "L"), 0D), 0D);
tp_695 = b_694;
md_696 = 0D;
Invoke(Get(d_691, "L"), "forEach", Fn((V _arrowThis704, int _argc697, V Q_703, V _a700, V _a701, V _a702, V[] _rest698) => {
return Invoke(Q_703, "forEach", Fn((V _arrowThis712, int _argc705, V p_711, V _a708, V _a709, V _a710, V[] _rest706) => {
double m_713 = 0;
m_713 = Hypot((ToNum(GetIdx(p_711, 0D)) - ToNum(GetIdx(b_694, 0D))), (ToNum(GetIdx(p_711, 1D)) - ToNum(GetIdx(b_694, 1D))));
if ((m_713 > md_696)) {
md_696 = m_713;
tp_695 = p_711;
}
return default;
}, 1, "", true));
}, 1, "", true));
Set(d_691, "leaf", NewObj(3).Put("b", b_694).Put("tp", tp_695).Put("L", (((V)(md_696)) is var _t714 && Truthy(_t714) ? _t714 : ((V)(1D)))).V);
}
return d_691;
return default;
}, 1, "", true));
n_684 = 0D;
Invoke(L_683, "forEach", Fn((V _arrowThis730, int _argc723, V d_729, V _a726, V _a727, V _a728, V[] _rest724) => {
if (Truthy(Get(d_729, "leaf"))) {
Set(Get(d_729, "leaf"), "ro", ((V)(((ToNum((Get(o_680, "roll").IsNullish ? ((V)(0.5)) : Get(o_680, "roll"))) * (NumTruthy((n_684++ % 2D)) ? (-1D) : 1D)) * (Lt(GetIdx(Get(Get(d_729, "leaf"), "tp"), 0D), GetIdx(Get(Get(d_729, "leaf"), "b"), 0D)) ? (-1D) : 1D)))));
}
return default;
}, 1, "", true));
return NewObj(3).Put("G", G_682).Put("L", L_683).Put("o", o_680).V;
return default;
}, 2, "", true);
topDraw_40 = Fn((V _arrowThis739, int _argc731, V D_737, V T_738, V _a735, V _a736, V[] _rest732) => {
V o_740 = default;
V lf_741 = default;
V tw_742 = default;
V th_743 = default;
double c_744 = 0;
double s_745 = 0;
double tc_746 = 0;
double ts_747 = 0;
o_740 = Get(T_738, "o");
lf_741 = Call(clamp_16, V.Undef, Invoke(D_737, "bv", ((V)("lf"))), ((V)(0D)), ((V)(1.2)));
tw_742 = Call(clamp_16, V.Undef, Invoke(D_737, "bv", ((V)("stw"))), ((V)((-1D))), ((V)(1D)));
th_743 = Add(Add(Call(clamp_16, V.Undef, ((V)(((-ToNum(Get(D_737, "ox"))) * 0.045))), ((V)((-0.5))), ((V)(0.5))), ((V)((ToNum((Get(o_740, "wob").IsNullish ? ((V)(0.035)) : Get(o_740, "wob"))) * FdLibm.Sin((ToNum(Get(D_737, "ts")) * 1.6)))))), ((V)(((ToNum(lf_741) * 0.2) * FdLibm.Sin((ToNum(Get(D_737, "ts")) * 14D))))));
c_744 = FdLibm.Cos(ToNum(th_743));
s_745 = FdLibm.Sin(ToNum(th_743));
tc_746 = FdLibm.Cos((ToNum(tw_742) * System.Math.PI));
ts_747 = FdLibm.Sin((ToNum(tw_742) * System.Math.PI));
Invoke(Get(T_738, "L"), "forEach", Fn((V _arrowThis755, int _argc748, V d_754, V _a751, V _a752, V _a753, V[] _rest749) => {
V lv_756 = default;
double fl_757 = 0;
lv_756 = Get(d_754, "leaf");
fl_757 = (Truthy(lv_756) ? ((ToNum(lf_741) * 0.6) * FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_737, "ts")) * 17D))), GetIdx(Get(lv_756, "b"), 0D))))) : 0D);
Invoke(Get(d_754, "e"), "setAttribute", ((V)("d")), Call(decD_21, V.Undef, d_754, Fn((V _arrowThis766, int _argc758, V x_764, V y_765, V _a762, V _a763, V[] _rest759) => {
double z_767 = 0;
double dx_768 = 0;
double dy_769 = 0;
double X_770 = 0;
double Y_771 = 0;
double xx_772 = 0;
double zz_773 = 0;
z_767 = 0D;
if (Truthy(lv_756)) {
double vx_774 = 0;
double vy_775 = 0;
double w_776 = 0;
double u_777 = 0;
V ro_778 = default;
double k_779 = 0;
vx_774 = (ToNum(GetIdx(Get(lv_756, "tp"), 0D)) - ToNum(GetIdx(Get(lv_756, "b"), 0D)));
vy_775 = (ToNum(GetIdx(Get(lv_756, "tp"), 1D)) - ToNum(GetIdx(Get(lv_756, "b"), 1D)));
w_776 = ((((ToNum(x_764) - ToNum(GetIdx(Get(lv_756, "b"), 0D))) * vy_775) - ((ToNum(y_765) - ToNum(GetIdx(Get(lv_756, "b"), 1D))) * vx_774)) / ToNum(Get(lv_756, "L")));
u_777 = ((((ToNum(x_764) - ToNum(GetIdx(Get(lv_756, "b"), 0D))) * vx_774) + ((ToNum(y_765) - ToNum(GetIdx(Get(lv_756, "b"), 1D))) * vy_775)) / (ToNum(Get(lv_756, "L")) * ToNum(Get(lv_756, "L"))));
ro_778 = Get(lv_756, "ro");
k_779 = (1D - FdLibm.Cos(ToNum(ro_778)));
x_764 = ((V)((ToNum(x_764) - (((w_776 * vy_775) / ToNum(Get(lv_756, "L"))) * k_779))));
y_765 = Add(y_765, ((V)((((w_776 * vx_774) / ToNum(Get(lv_756, "L"))) * k_779))));
z_767 = ((((w_776 * FdLibm.Sin(ToNum(ro_778))) + ((ToNum((Get(o_740, "curl") is var _t780 && Truthy(_t780) ? _t780 : ((V)(0.12)))) * w_776) * w_776)) + (ToNum((Get(o_740, "lz") is var _t781 && Truthy(_t781) ? _t781 : ((V)(0D)))) * u_777)) + (((fl_757 * u_777) * u_777) * 3D));
}
dx_768 = (ToNum(x_764) - ToNum(Get(o_740, "ax")));
dy_769 = (ToNum(y_765) - ToNum(Get(o_740, "ay")));
X_770 = ((dx_768 * c_744) - (dy_769 * s_745));
Y_771 = ((dx_768 * s_745) + (dy_769 * c_744));
xx_772 = ((X_770 * tc_746) - (z_767 * ts_747));
zz_773 = ((X_770 * ts_747) + (z_767 * tc_746));
return Invoke(D_737, "P3", Add(Get(o_740, "ax"), ((V)(xx_772))), Add(Get(o_740, "ay"), ((V)(Y_771))), Add(((V)(zz_773)), (Get(o_740, "z") is var _t782 && Truthy(_t782) ? _t782 : ((V)(0D)))));
return default;
}, 2, "", true)));
return default;
}, 1, "", true));
return default;
}, 2, "", true);
FRUIT_41 = Fn((V _arrowThis790, int _argc783, V cfg_789, V _a786, V _a787, V _a788, V[] _rest784) => {
return NewObj(2).Put("setup", Fn((V _self791, int _argc792, V S_798, V _a795, V _a796, V _a797, V[] _rest793) => {
V R_799 = default;
V B_800 = default;
if (_self791.IsNullish) _self791 = GlobalV;
R_799 = Call(REV_24, V.Undef, S_798, cfg_789);
B_800 = NewObj(8).Put("R", R_799).Put("cfg", cfg_789).Put("rT", Get(R_799, "rT")).Put("zAt", Get(R_799, "zAt")).Put("rx", (Get(cfg_789, "rx") is var _t801 && Truthy(_t801) ? _t801 : ((V)(30D)))).Put("ya", Add(Get(R_799, "yT"), ((V)(5D)))).Put("yb", ((V)((ToNum(Get(R_799, "yB")) - 2D)))).Put("zE", Fn((V _arrowThis810, int _argc802, V dx_808, V dy_809, V _a806, V _a807, V[] _rest803) => {
V y_811 = default;
V fy_812 = default;
double d_813 = 0;
y_811 = Add(Get(S_798, "HY"), dy_809);
fy_812 = (Get(cfg_789, "fy") is var _t814 && Truthy(_t814) ? _t814 : y_811);
d_813 = (ToNum(y_811) - ToNum(fy_812));
return ((V)(((ToNum(Invoke(R_799, "zAt", Add(Get(S_798, "HX"), dx_808), fy_812)) - ((d_813 * d_813) / 60D)) + 0.3)));
return default;
}, 2, "zE", true)).V;
if (Truthy(Get(cfg_789, "hide"))) {
Invoke(S_798, "hide", Get(cfg_789, "hide"));
}
Set(B_800, "dc", (Truthy(Get(cfg_789, "dc")) ? Call(DECS_29, V.Undef, S_798, R_799, Fn((V _arrowThis822, int _argc815, V q_821, V _a818, V _a819, V _a820, V[] _rest816) => {
return (Invoke(S_798, "dk", q_821, ((V)("dc"))) is var _t823 && !Truthy(_t823) ? _t823 : Invoke(Get(cfg_789, "dc"), "pred", q_821));
}, 1, "", true), Get(Get(cfg_789, "dc"), "copies")) : Arr()));
if (Truthy((Get(cfg_789, "dc") is var _t824 && !Truthy(_t824) ? _t824 : Get(Get(cfg_789, "dc"), "drop")))) {
Invoke(S_798, "hide", Fn((V _arrowThis832, int _argc825, V q_831, V _a828, V _a829, V _a830, V[] _rest826) => {
return Invoke(S_798, "dk", q_831, ((V)("dc")));
}, 1, "", true));
}
Set(B_800, "fx", (Truthy(Get(cfg_789, "fix")) ? Call(FIX_31, V.Undef, S_798, Fn((V _arrowThis840, int _argc833, V q_839, V _a836, V _a837, V _a838, V[] _rest834) => {
return (Invoke(S_798, "dk", q_839, ((V)("dc"))) is var _t841 && !Truthy(_t841) ? _t841 : Invoke(cfg_789, "fix", q_839));
}, 1, "", true)) : Arr()));
if (Truthy(Get(cfg_789, "spk"))) {
Set(B_800, "spk", NewObj(3).Put("P", Call(SCAT_34, V.Undef, R_799, Get(Get(cfg_789, "spk"), "n"), (Get(Get(cfg_789, "spk"), "seed") is var _t842 && Truthy(_t842) ? _t842 : ((V)(3D))), (Get(Get(cfg_789, "spk"), "min") is var _t843 && Truthy(_t843) ? _t843 : ((V)(4D))), (Get(cfg_789, "face") is var _t844 && !Truthy(_t844) ? _t844 : Call(faceAvoid_35, V.Undef, GetIdx(Get(cfg_789, "face"), 0D), GetIdx(Get(cfg_789, "face"), 1D))))).Put("r", (Get(Get(cfg_789, "spk"), "r") is var _t845 && Truthy(_t845) ? _t845 : ((V)(0.55)))).Put("e", Invoke(S_798, "path", NewObj(2).Put("fill", Get(Get(cfg_789, "spk"), "c")).Put("opacity", (Get(Get(cfg_789, "spk"), "op") is var _t846 && Truthy(_t846) ? _t846 : ((V)(0.7)))).V)).V);
}
if (Truthy(Get(cfg_789, "fib"))) {
Set(B_800, "fib", NewObj(2).Put("P", Call(SCAT_34, V.Undef, R_799, Get(Get(cfg_789, "fib"), "n"), (Get(Get(cfg_789, "fib"), "seed") is var _t847 && Truthy(_t847) ? _t847 : ((V)(7D))), (Get(Get(cfg_789, "fib"), "min") is var _t848 && Truthy(_t848) ? _t848 : ((V)(3.6))), (Get(cfg_789, "face") is var _t849 && !Truthy(_t849) ? _t849 : Call(faceAvoid_35, V.Undef, GetIdx(Get(cfg_789, "face"), 0D), GetIdx(Get(cfg_789, "face"), 1D))))).Put("e", Invoke(S_798, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(cfg_789, "fib"), "c")).Put("stroke-width", (Get(Get(cfg_789, "fib"), "w") is var _t850 && Truthy(_t850) ? _t850 : ((V)(0.55)))).Put("stroke-linecap", ((V)("round"))).Put("opacity", (Get(Get(cfg_789, "fib"), "op") is var _t851 && Truthy(_t851) ? _t851 : ((V)(0.6)))).V)).V);
}
if (Truthy(Get(cfg_789, "ridge"))) {
Set(B_800, "rdg", Object_assign(NewObj(1).Put("e", Invoke(S_798, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(cfg_789, "ridge"), "c")).Put("stroke-width", (Get(Get(cfg_789, "ridge"), "w") is var _t852 && Truthy(_t852) ? _t852 : ((V)(1.1)))).Put("stroke-linecap", ((V)("round"))).Put("opacity", (Get(Get(cfg_789, "ridge"), "op") is var _t853 && Truthy(_t853) ? _t853 : ((V)(0.3)))).V)).V, Get(cfg_789, "ridge")));
}
if (Truthy(Get(cfg_789, "extra"))) {
Invoke(Get(cfg_789, "extra"), "setup", S_798, B_800, R_799);
}
Set(B_800, "top", (Truthy(Get(cfg_789, "top")) ? Call(TOPS_39, V.Undef, S_798, Get(cfg_789, "top")) : Seq(Invoke(S_798, "hide", Fn((V _arrowThis861, int _argc854, V q_860, V _a857, V _a858, V _a859, V[] _rest855) => {
return Invoke(S_798, "dk", q_860, ((V)("top")));
}, 1, "", true)), V.Null)));
Set(B_800, "sh", (SEqS(Get(cfg_789, "shine"), "fix") ? Call(SHINE_33, V.Undef, S_798) : V.Null));
return B_800;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self862, int _argc863, V B_869, V D_870, V _a867, V _a868, V[] _rest864) => {
V R_871 = default;
if (_self862.IsNullish) _self862 = GlobalV;
R_871 = Get(B_869, "R");
Set(B_869, "d", Call(SIL_25, V.Undef, D_870, R_871));
Call(decDraw_30, V.Undef, D_870, R_871, Get(B_869, "dc"));
if (Truthy(Get(Get(B_869, "fx"), "length"))) {
Call(fixDraw_32, V.Undef, D_870, Get(B_869, "fx"));
}
if (Truthy(Get(B_869, "spk"))) {
Call(dotsDraw_36, V.Undef, D_870, R_871, Get(B_869, "spk"));
}
if (Truthy(Get(B_869, "fib"))) {
Call(fibDraw_37, V.Undef, D_870, R_871, Get(B_869, "fib"));
}
if (Truthy(Get(B_869, "rdg"))) {
Call(ridgeDraw_38, V.Undef, D_870, R_871, Get(B_869, "rdg"));
}
if (Truthy(Get(Get(B_869, "cfg"), "extra"))) {
Invoke(Get(Get(B_869, "cfg"), "extra"), "draw", B_869, D_870, R_871);
}
if (Truthy(Get(B_869, "top"))) {
Call(topDraw_40, V.Undef, D_870, Get(B_869, "top"));
}
if (Truthy(Get(B_869, "sh"))) {
Call(fixDraw_32, V.Undef, D_870, Get(B_869, "sh"));
}
return default;
}, 2, "draw", false)).V;
}, 1, "", true);
isTag_42 = Fn((V _arrowThis879, int _argc872, V t_878, V _a875, V _a876, V _a877, V[] _rest873) => {
return Fn((V _arrowThis887, int _argc880, V q_886, V _a883, V _a884, V _a885, V[] _rest881) => {
return (SEq(Get(q_886, "tag"), t_878) ? V.True : V.False);
}, 1, "", true);
}, 1, "", true);
SEPALS_43 = Fn((V _arrowThis899, int _argc888, V S_894, V fill_895, V n_896, V ph_897, V[] _rest889) => {
V par_898 = default;
par_898 = (_argc888 > 4 ? _rest889[0] : V.Undef);
return Array_from(NewObj(1).Put("length", n_896).V, Fn((V _arrowThis908, int _argc900, V __906, V i_907, V _a904, V _a905, V[] _rest901) => {
return NewObj(3).Put("a", Add(ph_897, ((V)(((ToNum(i_907) * TAU_22) / ToNum(n_896)))))).Put("id", ((V)(JsStrBuf.Begin().S("s").V(i_907).End()))).Put("e", Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", fill_895).V, par_898)).V;
}, 2, "", true));
}, 5, "", true);
sepalDraw_44 = Fn((V _arrowThis919, int _argc909, V D_915, V list_916, V P_917, V o_918, V[] _rest910) => {
V cf_920 = default;
V up0_921 = default;
V L_922 = default;
cf_920 = Call(clamp_16, V.Undef, Invoke(D_915, "bv", ((V)("crf"))), ((V)((-0.5))), ((V)(1.2)));
up0_921 = Get(o_918, "up");
o_918 = Object_assign(NewObj(0).V, o_918, NewObj(2).Put("R", ((V)((ToNum(Get(o_918, "R")) * (1D + (0.28 * ToNum(cf_920))))))).Put("up", ((V)(((ToNum(up0_921) * (1D - (0.55 * ToNum(cf_920)))) + (LtN(cf_920, 0D) ? ((-ToNum(cf_920)) * 3D) : 0D))))).V);
L_922 = Invoke(Invoke(list_916, "map", Fn((V _arrowThis939, int _argc932, V s_938, V _a935, V _a936, V _a937, V[] _rest933) => {
V a_940 = default;
V w_941 = default;
V R_942 = default;
V tip_943 = default;
V c1_944 = default;
V c2_945 = default;
V m_946 = default;
V s1_947 = default;
V s2_948 = default;
V C_949 = default;
a_940 = Add(Get(s_938, "a"), Get(o_918, "spin"));
w_941 = Get(o_918, "w");
R_942 = Get(o_918, "R");
tip_943 = Arr(((V)((50D + (ToNum(R_942) * FdLibm.Cos(ToNum(a_940)))))), ((V)((ToNum(Get(o_918, "y")) - ToNum(Get(o_918, "up"))))), ((V)((ToNum(R_942) * FdLibm.Sin(ToNum(a_940))))));
c1_944 = Arr(((V)((50D + (ToNum(Get(o_918, "r0")) * FdLibm.Cos((ToNum(a_940) - ToNum(w_941))))))), Get(o_918, "y"), ((V)((ToNum(Get(o_918, "r0")) * FdLibm.Sin((ToNum(a_940) - ToNum(w_941)))))));
c2_945 = Arr(((V)((50D + (ToNum(Get(o_918, "r0")) * FdLibm.Cos(ToNum(Add(a_940, w_941))))))), Get(o_918, "y"), ((V)((ToNum(Get(o_918, "r0")) * FdLibm.Sin(ToNum(Add(a_940, w_941)))))));
m_946 = (Get(o_918, "mid") is var _t950 && Truthy(_t950) ? _t950 : ((V)(0.5)));
s1_947 = Arr(((V)((50D + ((ToNum(R_942) * ToNum(m_946)) * FdLibm.Cos((ToNum(a_940) - (ToNum(w_941) * 0.55))))))), ((V)((ToNum(Get(o_918, "y")) - ((ToNum(Get(o_918, "up")) * ToNum(m_946)) * 0.6)))), ((V)(((ToNum(R_942) * ToNum(m_946)) * FdLibm.Sin((ToNum(a_940) - (ToNum(w_941) * 0.55)))))));
s2_948 = Arr(((V)((50D + ((ToNum(R_942) * ToNum(m_946)) * FdLibm.Cos(ToNum(Add(a_940, ((V)((ToNum(w_941) * 0.55)))))))))), ((V)((ToNum(Get(o_918, "y")) - ((ToNum(Get(o_918, "up")) * ToNum(m_946)) * 0.6)))), ((V)(((ToNum(R_942) * ToNum(m_946)) * FdLibm.Sin(ToNum(Add(a_940, ((V)((ToNum(w_941) * 0.55))))))))));
C_949 = Arr(((V)(50D)), Add(Get(o_918, "y"), (Get(o_918, "dip") is var _t951 && Truthy(_t951) ? _t951 : ((V)(0D)))), ((V)(0D)));
Invoke(Get(s_938, "e"), "setAttribute", ((V)("d")), Call(polyW_13, V.Undef, Invoke(Arr(C_949, c1_944, s1_947, tip_943, s2_948, c2_945), "map", Fn((V _arrowThis959, int _argc952, V p_958, V _a955, V _a956, V _a957, V[] _rest953) => {
return Call(P_917, V.Undef, GetIdx(p_958, 0D), GetIdx(p_958, 1D), GetIdx(p_958, 2D));
}, 1, "", true))));
return NewObj(3).Put("id", Get(s_938, "id")).Put("e", Get(s_938, "e")).Put("z", Invoke(D_915, "Z3", GetIdx(tip_943, 0D), GetIdx(tip_943, 1D), GetIdx(tip_943, 2D))).V;
return default;
}, 1, "", true)), "sort", Fn((V _arrowThis931, int _argc923, V a_929, V b_930, V _a927, V _a928, V[] _rest924) => {
return ((V)((ToNum(Get(a_929, "z")) - ToNum(Get(b_930, "z")))));
}, 2, "", true));
return L_922;
return default;
}, 4, "", true);
Set(M_9, "bing", Call(FRUIT_41, V.Undef, NewObj(4).Put("fy", ((V)(62D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(32D))).Put("top", NewObj(3).Put("ax", ((V)(50D))).Put("ay", ((V)(34.8))).Put("curl", ((V)(0.14))).V).V));
Set(M_9, "clemmy", Call(FRUIT_41, V.Undef, NewObj(7).Put("fy", ((V)(63D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(33D))).Put("dc", NewObj(2).Put("pred", Fn((V _arrowThis966, int _argc960, V _a962, V _a963, V _a964, V _a965, V[] _rest961) => {
return (false ? V.True : V.False);
}, 0, "pred", true)).Put("drop", ((V)(1D))).V).Put("face", Arr(((V)(52D)), ((V)(73D)))).Put("spk", NewObj(6).Put("n", ((V)(120D))).Put("c", ((V)("#e2701a"))).Put("op", ((V)(0.6))).Put("r", ((V)(0.55))).Put("min", ((V)(4.2))).Put("seed", ((V)(4D))).V).Put("top", NewObj(3).Put("ax", ((V)(50D))).Put("ay", ((V)(36.4))).Put("curl", ((V)(0.14))).V).V));
Set(M_9, "appy", Call(FRUIT_41, V.Undef, NewObj(9).Put("fy", ((V)(62D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(33D))).Put("dc", NewObj(2).Put("pred", Call(isTag_42, V.Undef, ((V)("ellipse")))).Put("copies", Arr(((V)(0D)), ((V)(2.6)))).V).Put("hide", Fn((V _arrowThis974, int _argc967, V q_973, V _a970, V _a971, V _a972, V[] _rest968) => {
return (Call(inDc_49, V.Undef, q_973) is var _t975 && !Truthy(_t975) ? _t975 : (!SEqS(Get(q_973, "tag"), "ellipse") ? V.True : V.False));
}, 1, "hide", true)).Put("face", Arr(((V)(51D)), ((V)(71D)))).Put("spk", NewObj(6).Put("n", ((V)(26D))).Put("c", ((V)("#f2ffd0"))).Put("op", ((V)(0.8))).Put("r", ((V)(0.5))).Put("min", ((V)(7D))).Put("seed", ((V)(5D))).V).Put("top", NewObj(3).Put("ax", ((V)(50D))).Put("ay", ((V)(33D))).Put("curl", ((V)(0.14))).V).Put("extra", NewObj(2).Put("setup", Fn((V _self976, int _argc977, V S_983, V B_984, V _a981, V _a982, V[] _rest978) => {
if (_self976.IsNullish) _self976 = GlobalV;
Set(B_984, "cav", Invoke(S_983, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#4e8a26"))).Put("stroke-width", ((V)(1.2))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.45))).V));
return default;
}, 2, "setup", false)).Put("draw", Fn((V _self985, int _argc986, V B_992, V D_993, V R_994, V _a991, V[] _rest987) => {
V P_995 = default;
V Q_996 = default;
if (_self985.IsNullish) _self985 = GlobalV;
P_995 = Call(PEL_26, V.Undef, D_993, ((V)(0.3)), ((V)(50D)), ((V)(34.5)));
Q_996 = Invoke(Invoke(Get(SN_8, "h"), "frontArc", D_993, ((V)(6D)), ((V)(34.5)), ((V)(48D))), "map", Fn((V _arrowThis1004, int _argc997, V f_1003, V _a1000, V _a1001, V _a1002, V[] _rest998) => {
return Call(P_995, V.Undef, ((V)((50D + (6D * FdLibm.Sin(ToNum(f_1003)))))), ((V)(34.5)), ((V)((6D * FdLibm.Cos(ToNum(f_1003))))));
}, 1, "", true));
Call(SA_23, V.Undef, Get(B_992, "cav"), ((V)("d")), (GtN(Get(Q_996, "length"), 1D) ? Call(runs_15, V.Undef, Q_996, Invoke(Q_996, "map", Fn((V _arrowThis1011, int _argc1005, V _a1007, V _a1008, V _a1009, V _a1010, V[] _rest1006) => {
return (true ? V.True : V.False);
}, 0, "", true))) : ((V)("M0 0"))));
return default;
}, 3, "draw", false)).V).V));
Set(M_9, "blueby", Call(FRUIT_41, V.Undef, NewObj(5).Put("fy", ((V)(63D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(33D))).Put("fix", Fn((V _arrowThis1018, int _argc1012, V _a1014, V _a1015, V _a1016, V _a1017, V[] _rest1013) => {
return (true ? V.True : V.False);
}, 0, "fix", true)).Put("extra", NewObj(2).Put("setup", Fn((V _self1019, int _argc1020, V S_1026, V B_1027, V R_1028, V _a1025, V[] _rest1021) => {
V cr_1029 = default;
V st_1030 = default;
V F_1031 = default;
if (_self1019.IsNullish) _self1019 = GlobalV;
cr_1029 = Invoke(S_1026, "hide", Fn((V _arrowThis1039, int _argc1032, V q_1038, V _a1035, V _a1036, V _a1037, V[] _rest1033) => {
return Invoke(S_1026, "dk", q_1038, ((V)("cr")));
}, 1, "", true));
st_1030 = Invoke(cr_1029, "find", Fn((V _arrowThis1047, int _argc1040, V q_1046, V _a1043, V _a1044, V _a1045, V[] _rest1041) => {
return (SEqS(Get(q_1046, "tag"), "path") ? V.True : V.False);
}, 1, "", true));
F_1031 = (Truthy(st_1030) ? Invoke(S_1026, "f", st_1030) : ((V)("#3a4296")));
Set(B_1027, "CG", Invoke(S_1026, "g"));
Set(B_1027, "sep", Call(SEPALS_43, V.Undef, S_1026, F_1031, ((V)(5D)), ((V)(((-System.Math.PI) / 2D))), Get(B_1027, "CG")));
Set(B_1027, "hole", Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#26296a"))).V, Get(B_1027, "CG")));
Set(B_1027, "roll", Call(ROLLF_28, V.Undef, R_1028, ((V)(61D))));
return default;
}, 3, "setup", false)).Put("draw", Fn((V _self1048, int _argc1049, V B_1055, V D_1056, V _a1053, V _a1054, V[] _rest1050) => {
double spin_1057 = 0;
V P_1058 = default;
V L_1059 = default;
if (_self1048.IsNullish) _self1048 = GlobalV;
spin_1057 = ((ToNum(Call(clamp_16, V.Undef, Invoke(D_1056, "bv", ((V)("stw"))), ((V)((-1D))), ((V)(1D)))) * System.Math.PI) * 0.4);
P_1058 = Call(PEL_26, V.Undef, D_1056, ((V)(0.45)), ((V)(50D)), ((V)(38.3)));
L_1059 = Call(sepalDraw_44, V.Undef, D_1056, Get(B_1055, "sep"), P_1058, NewObj(7).Put("y", ((V)(38.3))).Put("R", ((V)(12.5))).Put("r0", ((V)(4.6))).Put("w", ((V)(0.62))).Put("up", ((V)(1.6))).Put("spin", ((V)(spin_1057))).Put("mid", ((V)(0.45))).V);
Invoke(SN_8, "order", Get(B_1055, "CG"), Invoke(L_1059, "concat", Arr(NewObj(2).Put("id", ((V)("h"))).Put("e", Get(B_1055, "hole")).V)));
Invoke(Get(B_1055, "hole"), "setAttribute", ((V)("d")), Call(polyW_13, V.Undef, Array_from(NewObj(1).Put("length", ((V)(20D))).V, Fn((V _arrowThis1068, int _argc1060, V __1066, V k_1067, V _a1064, V _a1065, V[] _rest1061) => {
double f_1069 = 0;
f_1069 = ((ToNum(k_1067) / 20D) * TAU_22);
return Call(P_1058, V.Undef, ((V)((50D + (4.2 * FdLibm.Cos(f_1069))))), ((V)(38D)), ((V)((4.2 * FdLibm.Sin(f_1069)))));
return default;
}, 2, "", true))));
return default;
}, 2, "draw", false)).V).V));
Set(M_9, "coco", Call(FRUIT_41, V.Undef, NewObj(8).Put("fy", ((V)(61D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(33D))).Put("dc", NewObj(1).Put("pred", Call(isTag_42, V.Undef, ((V)("circle")))).V).Put("hide", Fn((V _arrowThis1077, int _argc1070, V q_1076, V _a1073, V _a1074, V _a1075, V[] _rest1071) => {
return (Call(inDc_49, V.Undef, q_1076) is var _t1078 && !Truthy(_t1078) ? _t1078 : (SEqS(Get(q_1076, "tag"), "path") ? V.True : V.False));
}, 1, "hide", true)).Put("face", Arr(((V)(50D)), ((V)(71D)))).Put("fib", NewObj(6).Put("n", ((V)(150D))).Put("c", ((V)("#5a3820"))).Put("op", ((V)(0.6))).Put("w", ((V)(0.55))).Put("min", ((V)(3.4))).Put("seed", ((V)(7D))).V).Put("extra", NewObj(2).Put("setup", Fn((V _self1079, int _argc1080, V S_1086, V B_1087, V R_1088, V _a1085, V[] _rest1081) => {
if (_self1079.IsNullish) _self1079 = GlobalV;
Set(B_1087, "roll", Call(ROLLF_28, V.Undef, R_1088, ((V)(59D))));
Set(B_1087, "pre", Fn((V _arrowThis1096, int _argc1089, V P_1095, V _a1092, V _a1093, V _a1094, V[] _rest1090) => {
V k_1097 = default;
k_1097 = Call(clamp_16, V.Undef, (((V)(ToNum(Get(P_1095, "rig")))) is var _t1098 && Truthy(_t1098) ? _t1098 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
if (LtN(k_1097, 0.01)) {
return P_1095;
}
if (GtN(k_1097, 0.5)) {
Set(Get(S_1086, "I"), "ms", V.Null);
}
return Object_assign(NewObj(0).V, P_1095, NewObj(4).Put("sq", ((V)((ToNum((((V)(ToNum(Get(P_1095, "sq")))) is var _t1099 && Truthy(_t1099) ? _t1099 : ((V)(0D)))) * (1D - ToNum(k_1097)))))).Put("bend", ((V)((ToNum((((V)(ToNum(Get(P_1095, "bend")))) is var _t1100 && Truthy(_t1100) ? _t1100 : ((V)(0D)))) * (1D - ToNum(k_1097)))))).Put("lean", ((V)((ToNum((((V)(ToNum(Get(P_1095, "lean")))) is var _t1101 && Truthy(_t1101) ? _t1101 : ((V)(0D)))) * (1D - ToNum(k_1097)))))).Put("tilt", Add((((V)(ToNum(Get(P_1095, "tilt")))) is var _t1102 && Truthy(_t1102) ? _t1102 : ((V)(0D))), ((V)(((ToNum((((V)(ToNum(Get(P_1095, "lean")))) is var _t1103 && Truthy(_t1103) ? _t1103 : ((V)(0D)))) * 0.8) * ToNum(k_1097)))))).V);
return default;
}, 1, "", true));
return default;
}, 3, "setup", false)).Put("draw", Fn((V _self1104, int _argc1105, V _a1107, V _a1108, V _a1109, V _a1110, V[] _rest1106) => {
if (_self1104.IsNullish) _self1104 = GlobalV;

return default;
}, 0, "draw", false)).V).V));
Set(M_9, "perry", Call(FRUIT_41, V.Undef, NewObj(8).Put("fy", ((V)(65D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(30D))).Put("dc", NewObj(2).Put("pred", Call(isTag_42, V.Undef, ((V)("ellipse")))).Put("copies", Arr(((V)(0D)), ((V)(2.8)))).V).Put("hide", Fn((V _arrowThis1118, int _argc1111, V q_1117, V _a1114, V _a1115, V _a1116, V[] _rest1112) => {
return (Call(inDc_49, V.Undef, q_1117) is var _t1119 && !Truthy(_t1119) ? _t1119 : (SEqS(Get(q_1117, "tag"), "circle") ? V.True : V.False));
}, 1, "hide", true)).Put("face", Arr(((V)(54D)), ((V)(74D)))).Put("spk", NewObj(6).Put("n", ((V)(70D))).Put("c", ((V)("#8a9a3a"))).Put("op", ((V)(0.65))).Put("r", ((V)(0.5))).Put("min", ((V)(5D))).Put("seed", ((V)(9D))).V).Put("top", NewObj(3).Put("ax", ((V)(50D))).Put("ay", ((V)(27D))).Put("curl", ((V)(0.14))).V).V));
Set(M_9, "grana", Call(FRUIT_41, V.Undef, NewObj(6).Put("fy", ((V)(63D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(33D))).Put("dc", NewObj(2).Put("pred", Fn((V _arrowThis1126, int _argc1120, V _a1122, V _a1123, V _a1124, V _a1125, V[] _rest1121) => {
return (false ? V.True : V.False);
}, 0, "pred", true)).Put("drop", ((V)(1D))).V).Put("ridge", NewObj(6).Put("F", Invoke(Arr(((V)((-5D))), ((V)((-3D))), ((V)((-1D))), ((V)(1D)), ((V)(3D)), ((V)(5D))), "map", Fn((V _arrowThis1134, int _argc1127, V k_1133, V _a1130, V _a1131, V _a1132, V[] _rest1128) => {
return ((V)(((ToNum(k_1133) * System.Math.PI) / 6D)));
}, 1, "", true))).Put("y0", ((V)(40D))).Put("y1", ((V)(84D))).Put("c", ((V)("#a81e2e"))).Put("op", ((V)(0.3))).Put("w", ((V)(1.1))).V).Put("extra", NewObj(2).Put("setup", Fn((V _self1135, int _argc1136, V S_1142, V B_1143, V _a1140, V _a1141, V[] _rest1137) => {
V cr_1144 = default;
V F_1145 = default;
if (_self1135.IsNullish) _self1135 = GlobalV;
cr_1144 = Invoke(S_1142, "hide", Fn((V _arrowThis1153, int _argc1146, V q_1152, V _a1149, V _a1150, V _a1151, V[] _rest1147) => {
return Invoke(S_1142, "dk", q_1152, ((V)("cr")));
}, 1, "", true));
F_1145 = (Truthy(Get(cr_1144, "length")) ? Invoke(S_1142, "f", GetIdx(cr_1144, 0D)) : ((V)("#b02a34")));
Set(B_1143, "CG", Invoke(S_1142, "g"));
Set(B_1143, "neck", Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", F_1145).V, Get(B_1143, "CG")));
Set(B_1143, "open", Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#5a0e18"))).V, Get(B_1143, "CG")));
Set(B_1143, "rim", Call(el_10, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#e86a6a"))).Put("stroke-width", ((V)(0.6))).Put("opacity", ((V)(0.6))).V, Get(B_1143, "CG")));
Set(B_1143, "sep", Call(SEPALS_43, V.Undef, S_1142, F_1145, ((V)(6D)), ((V)((((-System.Math.PI) / 2D) + (System.Math.PI / 6D)))), Get(B_1143, "CG")));
return default;
}, 2, "setup", false)).Put("draw", Fn((V _self1154, int _argc1155, V B_1161, V D_1162, V _a1159, V _a1160, V[] _rest1156) => {
V P_1163 = default;
V ring_1164 = default;
double spin_1165 = 0;
V L_1166 = default;
V bk_1167 = default;
V fr_1168 = default;
if (_self1154.IsNullish) _self1154 = GlobalV;
P_1163 = Call(PEL_26, V.Undef, D_1162, ((V)(0.3)), ((V)(50D)), ((V)(31D)));
ring_1164 = Fn((V _arrowThis1177, int _argc1169, V r_1175, V y_1176, V _a1173, V _a1174, V[] _rest1170) => {
return Array_from(NewObj(1).Put("length", ((V)(24D))).V, Fn((V _arrowThis1186, int _argc1178, V __1184, V k_1185, V _a1182, V _a1183, V[] _rest1179) => {
double f_1187 = 0;
f_1187 = ((ToNum(k_1185) / 24D) * TAU_22);
return Call(P_1163, V.Undef, ((V)((50D + (ToNum(r_1175) * FdLibm.Cos(f_1187))))), y_1176, ((V)((ToNum(r_1175) * FdLibm.Sin(f_1187)))));
return default;
}, 2, "", true));
}, 2, "", true);
spin_1165 = ((ToNum(Call(clamp_16, V.Undef, Invoke(D_1162, "bv", ((V)("stw"))), ((V)((-1D))), ((V)(1D)))) * System.Math.PI) * 0.35);
Invoke(Get(B_1161, "neck"), "setAttribute", ((V)("d")), Invoke(D_1162, "hull", Invoke(Call(ring_1164, V.Undef, ((V)(7.4)), ((V)(36D))), "concat", Call(ring_1164, V.Undef, ((V)(6.1)), ((V)(31D))))));
Invoke(Get(B_1161, "open"), "setAttribute", ((V)("d")), Call(polyW_13, V.Undef, Call(ring_1164, V.Undef, ((V)(4.6)), ((V)(30.9)))));
Invoke(Get(B_1161, "rim"), "setAttribute", ((V)("d")), Call(polyW_13, V.Undef, Call(ring_1164, V.Undef, ((V)(6.1)), ((V)(31D)))));
L_1166 = Call(sepalDraw_44, V.Undef, D_1162, Get(B_1161, "sep"), P_1163, NewObj(8).Put("y", ((V)(31D))).Put("R", ((V)(9.6))).Put("r0", ((V)(4.2))).Put("w", ((V)(0.42))).Put("up", ((V)(7D))).Put("spin", ((V)(spin_1165))).Put("mid", ((V)(0.5))).Put("dip", ((V)(0D))).V);
bk_1167 = Invoke(L_1166, "filter", Fn((V _arrowThis1195, int _argc1188, V o_1194, V _a1191, V _a1192, V _a1193, V[] _rest1189) => {
return (LtN(Get(o_1194, "z"), 0D) ? V.True : V.False);
}, 1, "", true));
fr_1168 = Invoke(L_1166, "filter", Fn((V _arrowThis1203, int _argc1196, V o_1202, V _a1199, V _a1200, V _a1201, V[] _rest1197) => {
return (GeN(Get(o_1202, "z"), 0D) ? V.True : V.False);
}, 1, "", true));
Invoke(SN_8, "order", Get(B_1161, "CG"), Invoke(bk_1167, "concat", Arr(NewObj(2).Put("id", ((V)("n"))).Put("e", Get(B_1161, "neck")).V, NewObj(2).Put("id", ((V)("o"))).Put("e", Get(B_1161, "open")).V, NewObj(2).Put("id", ((V)("r"))).Put("e", Get(B_1161, "rim")).V), fr_1168));
return default;
}, 2, "draw", false)).V).V));
Set(M_9, "mangie", Call(FRUIT_41, V.Undef, NewObj(10).Put("fy", ((V)(61D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(30D))).Put("kz", ((V)(0.85))).Put("cx", ((V)("mid"))).Put("dc", NewObj(2).Put("pred", Call(isTag_42, V.Undef, ((V)("ellipse")))).Put("copies", Arr(((V)(0D)), ((V)(System.Math.PI)))).V).Put("hide", Fn((V _arrowThis1211, int _argc1204, V q_1210, V _a1207, V _a1208, V _a1209, V[] _rest1205) => {
return (Call(inDc_49, V.Undef, q_1210) is var _t1212 && !Truthy(_t1212) ? _t1212 : (SEqS(Get(q_1210, "tag"), "circle") ? V.True : V.False));
}, 1, "hide", true)).Put("face", Arr(((V)(50D)), ((V)(70D)))).Put("spk", NewObj(6).Put("n", ((V)(30D))).Put("c", ((V)("#fff6c8"))).Put("op", ((V)(0.7))).Put("r", ((V)(0.5))).Put("min", ((V)(6.5))).Put("seed", ((V)(13D))).V).Put("top", NewObj(3).Put("ax", ((V)(47.6))).Put("ay", ((V)(30.6))).Put("curl", ((V)(0.12))).V).V));
Set(M_9, "razzy", Call(FRUIT_41, V.Undef, NewObj(5).Put("fy", ((V)(59D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(30D))).Put("dc", NewObj(2).Put("pred", Fn((V _arrowThis1219, int _argc1213, V _a1215, V _a1216, V _a1217, V _a1218, V[] _rest1214) => {
return (false ? V.True : V.False);
}, 0, "pred", true)).Put("drop", ((V)(1D))).V).Put("extra", NewObj(2).Put("setup", Fn((V _self1220, int _argc1221, V S_1227, V B_1228, V R_1229, V _a1226, V[] _rest1222) => {
V gr_1230 = default;
V GF_1231 = default;
V cr_1232 = default;
V CF_1233 = default;
V DR_1234 = default;
V nf_1235 = default;
double row_1236 = 0;
if (_self1220.IsNullish) _self1220 = GlobalV;
gr_1230 = Invoke(S_1227, "hide", Fn((V _arrowThis1244, int _argc1237, V q_1243, V _a1240, V _a1241, V _a1242, V[] _rest1238) => {
return Invoke(S_1227, "dk", q_1243, ((V)("gr")));
}, 1, "", true));
GF_1231 = (Truthy(Get(gr_1230, "length")) ? Invoke(S_1227, "f", GetIdx(gr_1230, 0D)) : ((V)("#ec3a6c")));
cr_1232 = Invoke(S_1227, "hide", Fn((V _arrowThis1252, int _argc1245, V q_1251, V _a1248, V _a1249, V _a1250, V[] _rest1246) => {
return Invoke(S_1227, "dk", q_1251, ((V)("cr")));
}, 1, "", true));
CF_1233 = (Truthy(Get((Invoke(cr_1232, "find", Fn((V _arrowThis1268, int _argc1261, V q_1267, V _a1264, V _a1265, V _a1266, V[] _rest1262) => {
return (SEqS(Get(q_1267, "tag"), "path") ? V.True : V.False);
}, 1, "", true)) is var _t1269 && Truthy(_t1269) ? _t1269 : NewObj(0).V), "e")) ? Invoke(S_1227, "f", Invoke(cr_1232, "find", Fn((V _arrowThis1260, int _argc1253, V q_1259, V _a1256, V _a1257, V _a1258, V[] _rest1254) => {
return (SEqS(Get(q_1259, "tag"), "path") ? V.True : V.False);
}, 1, "", true))) : ((V)("#6ab83a")));
DR_1234 = Arr();
nf_1235 = Fn((V _arrowThis1278, int _argc1270, V f_1276, V y_1277, V _a1274, V _a1275, V[] _rest1271) => {
double x_1279 = 0;
if ((FdLibm.Cos(ToNum(f_1276)) < 0.3)) {
return (false ? V.True : V.False);
}
x_1279 = (50D + ((ToNum(Invoke(R_1229, "rT", y_1277)) - 1.6) * FdLibm.Sin(ToNum(f_1276))));
return ((((Hypot((x_1279 - 40D), (ToNum(y_1277) - 56D)) < 5.6) || (Hypot((x_1279 - 60D), (ToNum(y_1277) - 56D)) < 5.6)) || (Hypot((x_1279 - 50D), (ToNum(y_1277) - 63.5)) < 4.2)) ? V.True : V.False);
return default;
}, 2, "", true);
row_1236 = 0D;
{
double y_1280 = 0;
y_1280 = 34.5;
while (true) {
if (!((y_1280 < 87D))) break;
double r_1282 = 0;
double n_1283 = 0;
r_1282 = Max(0D, (ToNum(Invoke(R_1229, "rT", ((V)(y_1280)))) - 1.6));
n_1283 = Max(1D, Round(((TAU_22 * r_1282) / 8.2)));
{
double i_1284 = 0;
i_1284 = 0D;
while (true) {
if (!((i_1284 < n_1283))) break;
double f_1286 = 0;
double yy_1287 = 0;
f_1286 = ((((i_1284 + ((row_1236 % 2D) * 0.5)) + ((ToNum(Call(rnd_19, V.Undef, ((V)(((y_1280 * 3D) + i_1284))))) - 0.5) * 0.2)) / n_1283) * TAU_22);
yy_1287 = (y_1280 + ((ToNum(Call(rnd_19, V.Undef, ((V)(((y_1280 * 5D) + i_1284))))) - 0.5) * 1.2));
if (!(Truthy(Call(nf_1235, V.Undef, ((V)(f_1286)), ((V)(yy_1287)))))) {
Invoke(DR_1234, "push", NewObj(3).Put("f", ((V)(f_1286))).Put("y", ((V)(yy_1287))).Put("s", ((V)(((0.93 + (ToNum(Call(rnd_19, V.Undef, ((V)((y_1280 + (i_1284 * 1.7)))))) * 0.12)) * ((y_1280 > 82D) ? 0.8 : 1D))))).V);
}
i_1284++;
}
}
y_1280 = (y_1280 + 6.3);
row_1236++;
}
}
Set(B_1228, "DR", DR_1234);
Set(B_1228, "DG", Invoke(S_1227, "g"));
Invoke(Get(B_1228, "DG"), "setAttribute", ((V)("data-ol")), ((V)(0.8)));
Set(B_1228, "pool", Invoke(DR_1234, "map", Fn((V _arrowThis1294, int _argc1288, V _a1290, V _a1291, V _a1292, V _a1293, V[] _rest1289) => {
return Call(el_10, V.Undef, ((V)("path")), NewObj(2).Put("fill", GF_1231).Put("d", ((V)("M0 0"))).V, Get(B_1228, "DG"));
}, 0, "", true)));
Set(B_1228, "CG", Invoke(S_1227, "g"));
Set(B_1228, "stalk", Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#5a9a2a"))).V, Get(B_1228, "CG")));
Set(B_1228, "sep", Call(SEPALS_43, V.Undef, S_1227, CF_1233, ((V)(6D)), ((V)(((-System.Math.PI) / 2D))), Get(B_1228, "CG")));
return default;
}, 3, "setup", false)).Put("draw", Fn((V _self1295, int _argc1296, V B_1302, V D_1303, V R_1304, V _a1301, V[] _rest1297) => {
V jg_1305 = default;
V L_1306 = default;
double rr_1307 = 0;
V P_1308 = default;
double spin_1309 = 0;
if (_self1295.IsNullish) _self1295 = GlobalV;
jg_1305 = Call(clamp_16, V.Undef, Invoke(D_1303, "bv", ((V)("jig"))), ((V)(0D)), ((V)(1.5)));
L_1306 = Arr();
rr_1307 = (4.25 * ToNum(Get(D_1303, "kS")));
Invoke(Get(B_1302, "DR"), "forEach", Fn((V _arrowThis1318, int _argc1310, V o_1316, V i_1317, V _a1314, V _a1315, V[] _rest1311) => {
double j_1319 = 0;
V p_1320 = default;
V fz_1321 = default;
j_1319 = ((ToNum(jg_1305) * 0.5) * FdLibm.Sin(((ToNum(Get(D_1303, "ts")) * 19D) + (ToNum(i_1317) * 1.3))));
p_1320 = Invoke(R_1304, "at", Get(o_1316, "f"), Get(o_1316, "y"), ((V)(((-1.6) + j_1319))));
fz_1321 = Invoke(D_1303, "facing", GetIdx(p_1320, 0D), GetIdx(p_1320, 1D), GetIdx(p_1320, 2D), GetIdx(p_1320, 3D), GetIdx(p_1320, 4D), GetIdx(p_1320, 5D));
if (LtN(fz_1321, (-0.15))) {
return default;
}
Invoke(L_1306, "push", NewObj(3).Put("c", Invoke(D_1303, "P3", GetIdx(p_1320, 0D), GetIdx(p_1320, 1D), GetIdx(p_1320, 2D))).Put("z", Invoke(D_1303, "Z3", GetIdx(p_1320, 0D), GetIdx(p_1320, 1D), GetIdx(p_1320, 2D))).Put("s", Get(o_1316, "s")).V);
return default;
}, 2, "", true));
Invoke(L_1306, "sort", Fn((V _arrowThis1330, int _argc1322, V a_1328, V b_1329, V _a1326, V _a1327, V[] _rest1323) => {
return ((V)((ToNum(Get(a_1328, "z")) - ToNum(Get(b_1329, "z")))));
}, 2, "", true));
Invoke(Get(B_1302, "pool"), "forEach", Fn((V _arrowThis1339, int _argc1331, V e_1337, V i_1338, V _a1335, V _a1336, V[] _rest1332) => {
V o_1340 = default;
o_1340 = GetK(L_1306, i_1338);
Call(SA_23, V.Undef, e_1337, ((V)("d")), (Truthy(o_1340) ? Call(circD_14, V.Undef, Get(o_1340, "c"), ((V)((rr_1307 * ToNum(Get(o_1340, "s")))))) : ((V)("M0 0"))));
return default;
}, 2, "", true));
P_1308 = Call(PEL_26, V.Undef, D_1303, ((V)(0.38)), ((V)(50D)), ((V)(31D)));
spin_1309 = ((ToNum(Call(clamp_16, V.Undef, Invoke(D_1303, "bv", ((V)("stw"))), ((V)((-1D))), ((V)(1D)))) * System.Math.PI) * 0.4);
Invoke(Get(B_1302, "stalk"), "setAttribute", ((V)("d")), Invoke(Get(SN_8, "h"), "tubeD", D_1303, Arr(Arr(((V)(50D)), ((V)(31.1)), ((V)(0D))), Arr(((V)(50D)), ((V)(27.3)), ((V)(0D))), Arr(((V)(50.3)), ((V)(23.6)), ((V)(0D)))), Arr(((V)(1.05)), ((V)(1D)), ((V)(0.95)))));
Invoke(SN_8, "order", Get(B_1302, "CG"), Invoke(Call(sepalDraw_44, V.Undef, D_1303, Get(B_1302, "sep"), P_1308, NewObj(7).Put("y", ((V)(31D))).Put("R", ((V)(12D))).Put("r0", ((V)(2.6))).Put("w", ((V)(0.5))).Put("up", ((V)(1.4))).Put("spin", ((V)(spin_1309))).Put("mid", ((V)(0.5))).V), "concat", Arr(NewObj(2).Put("id", ((V)("st"))).Put("e", Get(B_1302, "stalk")).V)));
return default;
}, 3, "draw", false)).V).V));
NTF_45 = FdLibm.Sin((System.Math.PI * 0.553));
NC_46 = Fn((V _arrowThis1349, int _argc1341, V t_1347, V cv_1348, V _a1345, V _a1346, V[] _rest1342) => {
return Arr(((V)((((63D - (8D * ToNum(t_1347))) - ((12D * ToNum(Add(((V)(1D)), (cv_1348 is var _t1350 && Truthy(_t1350) ? _t1350 : ((V)(0D)))))) * FdLibm.Sin((System.Math.PI * ToNum(t_1347))))) + ((12D * ToNum((cv_1348 is var _t1351 && Truthy(_t1351) ? _t1351 : ((V)(0D))))) * NTF_45)))), ((V)((12D + (76D * ToNum(t_1347))))));
}, 2, "", true);
NW_47 = Fn((V _arrowThis1359, int _argc1352, V t_1358, V _a1355, V _a1356, V _a1357, V[] _rest1353) => {
return ((V)((3D + (15.5 * Pow(FdLibm.Sin((System.Math.PI * ToNum(Call(clamp_16, V.Undef, ((V)(((ToNum(t_1358) - 0.02) / 0.96))), ((V)(0D)), ((V)(1D)))))), 0.55)))));
}, 1, "", true);
NT_48 = Fn((V _arrowThis1368, int _argc1360, V t_1366, V cv_1367, V _a1364, V _a1365, V[] _rest1361) => {
double dx_1369 = 0;
double dy_1370 = 0;
double L_1371 = 0;
dx_1369 = ((-8D) - (((12D * ToNum(Add(((V)(1D)), (cv_1367 is var _t1372 && Truthy(_t1372) ? _t1372 : ((V)(0D)))))) * System.Math.PI) * FdLibm.Cos((System.Math.PI * ToNum(t_1366)))));
dy_1370 = 76D;
L_1371 = Hypot(dx_1369, dy_1370);
return Arr(((V)((dx_1369 / L_1371))), ((V)((dy_1370 / L_1371))));
return default;
}, 2, "", true);
Set(M_9, "nana", NewObj(2).Put("setup", Fn((V _self1373, int _argc1374, V S_1380, V _a1377, V _a1378, V _a1379, V[] _rest1375) => {
double KZ_1381 = 0;
V ST_1382 = default;
V zAt_1383 = default;
V rd_1384 = default;
V sk_1385 = default;
V skC_1386 = default;
V tip_1387 = default;
if (_self1373.IsNullish) _self1373 = GlobalV;
KZ_1381 = 0.9;
Invoke(S_1380, "hide", Fn((V _arrowThis1395, int _argc1388, V q_1394, V _a1391, V _a1392, V _a1393, V[] _rest1389) => {
return Invoke(S_1380, "dk", q_1394);
}, 1, "", true));
ST_1382 = Invoke(S_1380, "rgrad", ((V)("nst")), Arr(Arr(((V)(0D)), ((V)("#b8905a"))), Arr(((V)(0.6)), ((V)("#7a5a2a"))), Arr(((V)(1D)), ((V)("#4a3418")))));
zAt_1383 = Fn((V _arrowThis1404, int _argc1396, V x_1402, V y_1403, V _a1400, V _a1401, V[] _rest1397) => {
V t_1405 = default;
V c_1406 = default;
V T_1407 = default;
V w_1408 = default;
double d_1409 = 0;
t_1405 = Call(clamp_16, V.Undef, ((V)(((ToNum(y_1403) - 12D) / 76D))), ((V)(0D)), ((V)(1D)));
c_1406 = Call(NC_46, V.Undef, t_1405);
T_1407 = Call(NT_48, V.Undef, t_1405);
w_1408 = Call(NW_47, V.Undef, t_1405);
d_1409 = ((ToNum(x_1402) - ToNum(GetIdx(c_1406, 0D))) * ToNum(GetIdx(T_1407, 1D)));
return ((V)((((d_1409 * d_1409) < (ToNum(w_1408) * ToNum(w_1408))) ? (KZ_1381 * System.Math.Sqrt(((ToNum(w_1408) * ToNum(w_1408)) - (d_1409 * d_1409)))) : 0D)));
return default;
}, 2, "", true);
rd_1384 = Invoke(S_1380, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#d9a820"))).Put("stroke-width", ((V)(0.9))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.6))).V);
sk_1385 = Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", ST_1382).V, Get(S_1380, "LG"));
skC_1386 = Call(el_10, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#4a3418"))).V, Get(S_1380, "LG"));
tip_1387 = Invoke(S_1380, "path", NewObj(1).Put("fill", ((V)("#6a4a24"))).V);
return NewObj(11).Put("KZ", ((V)(KZ_1381))).Put("rd", rd_1384).Put("sk", sk_1385).Put("skC", skC_1386).Put("tip", tip_1387).Put("rx", ((V)(24D))).Put("ya", ((V)(20D))).Put("yb", ((V)(86D))).Put("rT", Fn((V _arrowThis1417, int _argc1410, V y_1416, V _a1413, V _a1414, V _a1415, V[] _rest1411) => {
V t_1418 = default;
t_1418 = Call(clamp_16, V.Undef, ((V)(((ToNum(y_1416) - 12D) / 76D))), ((V)(0D)), ((V)(1D)));
return ((V)((ToNum(Call(NW_47, V.Undef, t_1418)) / Max(0.5, ToNum(GetIdx(Call(NT_48, V.Undef, t_1418), 1D))))));
return default;
}, 1, "rT", true)).Put("zAt", zAt_1383).Put("zE", Fn((V _arrowThis1427, int _argc1419, V dx_1425, V dy_1426, V _a1423, V _a1424, V[] _rest1420) => {
return Add(Call(zAt_1383, V.Undef, Add(Get(S_1380, "HX"), dx_1425), Add(Get(S_1380, "HY"), dy_1426)), ((V)(0.3)));
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self1428, int _argc1429, V B_1435, V D_1436, V _a1433, V _a1434, V[] _rest1430) => {
V P3_1437 = default;
V KZ_1438 = default;
double n_1439 = 0;
V Rt_1440 = default;
V Lt_1441 = default;
V cv_1442 = default;
V ring_1443 = default;
V ext_1444 = default;
V G_1445 = default;
V cap_1446 = default;
JsStrBuf rd_1447 = null;
V sw_1448 = default;
double dx0_1449 = 0;
V C0_1450 = default;
V C1_1451 = default;
V C2_1452 = default;
V e_1453 = default;
if (_self1428.IsNullish) _self1428 = GlobalV;
{ V _t1454 = D_1436;
if (_t1454.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1454));
{ V _t1455 = Get(_t1454, "P3");
P3_1437 = _t1455; } }
KZ_1438 = Get(B_1435, "KZ");
n_1439 = 30D;
Rt_1440 = Arr();
Lt_1441 = Arr();
cv_1442 = Call(clamp_16, V.Undef, Invoke(D_1436, "bv", ((V)("cv"))), ((V)((-1D))), ((V)(1.2)));
ring_1443 = Fn((V _arrowThis1463, int _argc1456, V t_1462, V _a1459, V _a1460, V _a1461, V[] _rest1457) => {
V c_1464 = default;
V T_1465 = default;
V N_1466 = default;
V w_1467 = default;
c_1464 = Call(NC_46, V.Undef, t_1462, cv_1442);
T_1465 = Call(NT_48, V.Undef, t_1462, cv_1442);
N_1466 = Arr(GetIdx(T_1465, 1D), ((V)((-ToNum(GetIdx(T_1465, 0D))))));
w_1467 = Call(NW_47, V.Undef, t_1462);
return NewObj(4).Put("c", Arr(GetIdx(c_1464, 0D), GetIdx(c_1464, 1D), ((V)(0D)))).Put("N", Arr(GetIdx(N_1466, 0D), GetIdx(N_1466, 1D), ((V)(0D)))).Put("T", Arr(GetIdx(T_1465, 0D), GetIdx(T_1465, 1D), ((V)(0D)))).Put("w", w_1467).V;
return default;
}, 1, "", true);
ext_1444 = Fn((V _arrowThis1475, int _argc1468, V g_1474, V _a1471, V _a1472, V _a1473, V[] _rest1469) => {
V c_1476 = default;
V e1_1477 = default;
V e2_1478 = default;
V a_1479 = default;
V E1_1480 = default;
V E2_1481 = default;
V A_1482 = default;
V L_1483 = default;
double nx_1484 = 0;
double ny_1485 = 0;
double an_1486 = 0;
V V_1487 = default;
c_1476 = Call(P3_1437, V.Undef, GetIdx(Get(g_1474, "c"), 0D), GetIdx(Get(g_1474, "c"), 1D), ((V)(0D)));
e1_1477 = Call(P3_1437, V.Undef, Add(GetIdx(Get(g_1474, "c"), 0D), GetIdx(Get(g_1474, "N"), 0D)), Add(GetIdx(Get(g_1474, "c"), 1D), GetIdx(Get(g_1474, "N"), 1D)), ((V)(0D)));
e2_1478 = Call(P3_1437, V.Undef, GetIdx(Get(g_1474, "c"), 0D), GetIdx(Get(g_1474, "c"), 1D), KZ_1438);
a_1479 = Call(P3_1437, V.Undef, Add(GetIdx(Get(g_1474, "c"), 0D), GetIdx(Get(g_1474, "T"), 0D)), Add(GetIdx(Get(g_1474, "c"), 1D), GetIdx(Get(g_1474, "T"), 1D)), ((V)(0D)));
E1_1480 = Arr(((V)((ToNum(GetIdx(e1_1477, 0D)) - ToNum(GetIdx(c_1476, 0D))))), ((V)((ToNum(GetIdx(e1_1477, 1D)) - ToNum(GetIdx(c_1476, 1D))))));
E2_1481 = Arr(((V)((ToNum(GetIdx(e2_1478, 0D)) - ToNum(GetIdx(c_1476, 0D))))), ((V)((ToNum(GetIdx(e2_1478, 1D)) - ToNum(GetIdx(c_1476, 1D))))));
A_1482 = Arr(((V)((ToNum(GetIdx(a_1479, 0D)) - ToNum(GetIdx(c_1476, 0D))))), ((V)((ToNum(GetIdx(a_1479, 1D)) - ToNum(GetIdx(c_1476, 1D))))));
L_1483 = (((V)(Hypot(ToNum(GetIdx(A_1482, 0D)), ToNum(GetIdx(A_1482, 1D))))) is var _t1488 && Truthy(_t1488) ? _t1488 : ((V)(1D)));
nx_1484 = (ToNum(GetIdx(A_1482, 1D)) / ToNum(L_1483));
ny_1485 = ((-ToNum(GetIdx(A_1482, 0D))) / ToNum(L_1483));
an_1486 = FdLibm.Atan2(((nx_1484 * ToNum(GetIdx(E2_1481, 0D))) + (ny_1485 * ToNum(GetIdx(E2_1481, 1D)))), ((nx_1484 * ToNum(GetIdx(E1_1480, 0D))) + (ny_1485 * ToNum(GetIdx(E1_1480, 1D)))));
V_1487 = Arr(((V)(((ToNum(GetIdx(E1_1480, 0D)) * FdLibm.Cos(an_1486)) + (ToNum(GetIdx(E2_1481, 0D)) * FdLibm.Sin(an_1486))))), ((V)(((ToNum(GetIdx(E1_1480, 1D)) * FdLibm.Cos(an_1486)) + (ToNum(GetIdx(E2_1481, 1D)) * FdLibm.Sin(an_1486))))));
return NewObj(3).Put("c", c_1476).Put("V", V_1487).Put("A", Arr(((V)((ToNum(GetIdx(A_1482, 0D)) / ToNum(L_1483)))), ((V)((ToNum(GetIdx(A_1482, 1D)) / ToNum(L_1483)))))).V;
return default;
}, 1, "", true);
G_1445 = Arr();
{
double i_1489 = 0;
i_1489 = 0D;
while (true) {
if (!((i_1489 <= n_1439))) break;
Invoke(G_1445, "push", Call(ext_1444, V.Undef, Call(ring_1443, V.Undef, ((V)((i_1489 / n_1439))))));
i_1489++;
}
}
Invoke(G_1445, "forEach", Fn((V _arrowThis1499, int _argc1491, V g_1497, V i_1498, V _a1495, V _a1496, V[] _rest1492) => {
V w_1500 = default;
w_1500 = Call(NW_47, V.Undef, ((V)((ToNum(i_1498) / n_1439))));
Invoke(Rt_1440, "push", Arr(Add(GetIdx(Get(g_1497, "c"), 0D), ((V)((ToNum(GetIdx(Get(g_1497, "V"), 0D)) * ToNum(w_1500))))), Add(GetIdx(Get(g_1497, "c"), 1D), ((V)((ToNum(GetIdx(Get(g_1497, "V"), 1D)) * ToNum(w_1500)))))));
Invoke(Lt_1441, "push", Arr(((V)((ToNum(GetIdx(Get(g_1497, "c"), 0D)) - (ToNum(GetIdx(Get(g_1497, "V"), 0D)) * ToNum(w_1500))))), ((V)((ToNum(GetIdx(Get(g_1497, "c"), 1D)) - (ToNum(GetIdx(Get(g_1497, "V"), 1D)) * ToNum(w_1500)))))));
return default;
}, 2, "", true));
cap_1446 = Fn((V _arrowThis1511, int _argc1501, V g_1507, V w_1508, V sg_1509, V rev_1510, V[] _rest1502) => {
V vl_1512 = default;
double r_1513 = 0;
double vx_1514 = 0;
double vy_1515 = 0;
V o_1516 = default;
vl_1512 = (((V)(Hypot(ToNum(GetIdx(Get(g_1507, "V"), 0D)), ToNum(GetIdx(Get(g_1507, "V"), 1D))))) is var _t1517 && Truthy(_t1517) ? _t1517 : ((V)(1D)));
r_1513 = (ToNum(vl_1512) * ToNum(w_1508));
vx_1514 = (ToNum(GetIdx(Get(g_1507, "V"), 0D)) / ToNum(vl_1512));
vy_1515 = (ToNum(GetIdx(Get(g_1507, "V"), 1D)) / ToNum(vl_1512));
o_1516 = Arr();
{
double k_1518 = 0;
k_1518 = 1D;
while (true) {
if (!((k_1518 < 8D))) break;
double a_1520 = 0;
a_1520 = (((Truthy(rev_1510) ? (8D - k_1518) : k_1518) / 8D) * System.Math.PI);
Invoke(o_1516, "push", Arr(Add(GetIdx(Get(g_1507, "c"), 0D), ((V)((r_1513 * ((vx_1514 * FdLibm.Cos(a_1520)) + ((ToNum(sg_1509) * ToNum(GetIdx(Get(g_1507, "A"), 0D))) * FdLibm.Sin(a_1520))))))), Add(GetIdx(Get(g_1507, "c"), 1D), ((V)((r_1513 * ((vy_1515 * FdLibm.Cos(a_1520)) + ((ToNum(sg_1509) * ToNum(GetIdx(Get(g_1507, "A"), 1D))) * FdLibm.Sin(a_1520)))))))));
k_1518++;
}
}
return o_1516;
return default;
}, 4, "", true);
Set(B_1435, "d", Call(polyD_12, V.Undef, Invoke(Rt_1440, "concat", Call(cap_1446, V.Undef, GetIdx(G_1445, n_1439), Call(NW_47, V.Undef, ((V)(1D))), ((V)(1D)), ((V)(0D))), Invoke(Lt_1441, "reverse"), Call(cap_1446, V.Undef, GetIdx(G_1445, 0D), Call(NW_47, V.Undef, ((V)(0D))), ((V)((-1D))), ((V)(1D))))));
rd_1447 = new JsStrBuf("");
Invoke(Arr(((V)((-0.63))), ((V)(0.63)), ((V)((-1.9))), ((V)(1.9)), ((V)(System.Math.PI))), "forEach", Fn((V _arrowThis1528, int _argc1521, V f_1527, V _a1524, V _a1525, V _a1526, V[] _rest1522) => {
V Q_1529 = default;
V ok_1530 = default;
Q_1529 = Arr();
ok_1530 = Arr();
{
double i_1531 = 0;
i_1531 = 2D;
while (true) {
if (!((i_1531 <= 27D))) break;
V g_1533 = default;
double sf_1534 = 0;
double cf_1535 = 0;
V x_1536 = default;
V y_1537 = default;
double z_1538 = 0;
g_1533 = Call(ring_1443, V.Undef, ((V)((i_1531 / n_1439))));
sf_1534 = FdLibm.Sin(ToNum(f_1527));
cf_1535 = FdLibm.Cos(ToNum(f_1527));
x_1536 = Add(GetIdx(Get(g_1533, "c"), 0D), ((V)(((ToNum(Get(g_1533, "w")) * ToNum(GetIdx(Get(g_1533, "N"), 0D))) * sf_1534))));
y_1537 = Add(GetIdx(Get(g_1533, "c"), 1D), ((V)(((ToNum(Get(g_1533, "w")) * ToNum(GetIdx(Get(g_1533, "N"), 1D))) * sf_1534))));
z_1538 = ((ToNum(Get(g_1533, "w")) * ToNum(KZ_1438)) * cf_1535);
Invoke(Q_1529, "push", Call(P3_1437, V.Undef, x_1536, y_1537, ((V)(z_1538))));
Invoke(ok_1530, "push", (GtN(Invoke(D_1436, "facing", x_1536, y_1537, ((V)(z_1538)), ((V)((ToNum(GetIdx(Get(g_1533, "N"), 0D)) * sf_1534))), ((V)((ToNum(GetIdx(Get(g_1533, "N"), 1D)) * sf_1534))), ((V)((cf_1535 / ToNum(KZ_1438))))), 0.1) ? V.True : V.False));
i_1531++;
}
}
rd_1447.V(Call(runs_15, V.Undef, Q_1529, ok_1530));
return default;
}, 1, "", true));
Call(SA_23, V.Undef, Get(B_1435, "rd"), ((V)("d")), (((V)(rd_1447.Str)) is var _t1539 && Truthy(_t1539) ? _t1539 : ((V)("M0 0"))));
sw_1448 = Add(Call(clamp_16, V.Undef, ((V)(((-ToNum(Get(D_1436, "ox"))) * 0.08))), ((V)((-0.6))), ((V)(0.6))), ((V)(((ToNum(GetIdx(Call(NT_48, V.Undef, ((V)(0D)), cv_1442), 0D)) - ToNum(GetIdx(Call(NT_48, V.Undef, ((V)(0D)), ((V)(0D))), 0D))) * 0.6))));
dx0_1449 = (ToNum(GetIdx(Call(NC_46, V.Undef, ((V)(0.033)), cv_1442), 0D)) - ToNum(GetIdx(Call(NC_46, V.Undef, ((V)(0.033)), ((V)(0D))), 0D)));
C0_1450 = Arr(((V)((63.1 + dx0_1449))), ((V)(14.6)), ((V)(0D)));
C1_1451 = Arr(((V)(((63.6 + dx0_1449) + (ToNum(sw_1448) * 2D)))), ((V)(9.6)), ((V)(0D)));
C2_1452 = Arr(((V)(((64.4 + dx0_1449) + (ToNum(sw_1448) * 4.5)))), ((V)(5D)), ((V)(0D)));
Invoke(Get(B_1435, "sk"), "setAttribute", ((V)("d")), Invoke(Get(SN_8, "h"), "tubeD", D_1436, Arr(C0_1450, C1_1451, C2_1452), Arr(((V)(2.5)), ((V)(2.2)), ((V)(1.95)))));
Invoke(Get(B_1435, "skC"), "setAttribute", ((V)("d")), Call(circD_14, V.Undef, Call(P3_1437, V.Undef, GetIdx(C2_1452, 0D), ((V)((ToNum(GetIdx(C2_1452, 1D)) - 0.6))), ((V)(0D))), ((V)((1.75 * ToNum(Get(D_1436, "kS")))))));
e_1453 = Call(NC_46, V.Undef, ((V)(0.985)), cv_1442);
Invoke(Get(B_1435, "tip"), "setAttribute", ((V)("d")), Call(circD_14, V.Undef, Call(P3_1437, V.Undef, GetIdx(e_1453, 0D), GetIdx(e_1453, 1D), ((V)(0D))), ((V)((2.7 * ToNum(Get(D_1436, "kS")))))));
return default;
}, 2, "draw", false)).V);
Set(M_9, "plummy", Call(FRUIT_41, V.Undef, NewObj(10).Put("fy", ((V)(62D))).Put("shine", ((V)("fix"))).Put("rx", ((V)(31D))).Put("dc", NewObj(1).Put("pred", Call(isTag_42, V.Undef, ((V)("path")))).V).Put("fix", Call(isTag_42, V.Undef, ((V)("ellipse")))).Put("hide", Fn((V _arrowThis1547, int _argc1540, V q_1546, V _a1543, V _a1544, V _a1545, V[] _rest1541) => {
return (Call(inDc_49, V.Undef, q_1546) is var _t1548 && !Truthy(_t1548) ? _t1548 : (SEqS(Get(q_1546, "tag"), "circle") ? V.True : V.False));
}, 1, "hide", true)).Put("face", Arr(((V)(51D)), ((V)(72D)))).Put("spk", NewObj(6).Put("n", ((V)(55D))).Put("c", ((V)("#ead0f0"))).Put("op", ((V)(0.5))).Put("r", ((V)(0.45))).Put("min", ((V)(5.5))).Put("seed", ((V)(11D))).V).Put("top", NewObj(3).Put("ax", ((V)(50D))).Put("ay", ((V)(32D))).Put("curl", ((V)(0.14))).V).Put("extra", NewObj(2).Put("setup", Fn((V _self1549, int _argc1550, V S_1556, V B_1557, V _a1554, V _a1555, V[] _rest1551) => {
if (_self1549.IsNullish) _self1549 = GlobalV;
Set(B_1557, "bloom", Invoke(Get(B_1557, "fx"), "map", Fn((V _arrowThis1565, int _argc1558, V o_1564, V _a1561, V _a1562, V _a1563, V[] _rest1559) => {
return NewObj(2).Put("e", Get(o_1564, "e")).Put("op", ((V)(ToNum((Invoke(Get(o_1564, "e"), "getAttribute", ((V)("opacity"))) is var _t1566 && Truthy(_t1566) ? _t1566 : ((V)(1D))))))).V;
}, 1, "", true)));
Set(B_1557, "gl", Invoke(S_1556, "path", NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0D))).V));
return default;
}, 2, "setup", false)).Put("draw", Fn((V _self1567, int _argc1568, V B_1574, V D_1575, V _a1572, V _a1573, V[] _rest1569) => {
V p_1576 = default;
V Q_1577 = default;
double N_1578 = 0;
V A_1579 = default;
if (_self1567.IsNullish) _self1567 = GlobalV;
p_1576 = Call(clamp_16, V.Undef, Invoke(D_1575, "bv", ((V)("pol"))), ((V)(0D)), ((V)(1D)));
Invoke(Get(B_1574, "bloom"), "forEach", Fn((V _arrowThis1587, int _argc1580, V b_1586, V _a1583, V _a1584, V _a1585, V[] _rest1581) => {
return Invoke(Get(b_1586, "e"), "setAttribute", ((V)("opacity")), Call(r2_18, V.Undef, ((V)((ToNum(Get(b_1586, "op")) * (1D - (0.92 * ToNum(p_1576))))))));
}, 1, "", true));
if (LtN(p_1576, 0.02)) {
if (!SEqN(Get(B_1574, "glOn"), 0D)) {
Set(B_1574, "glOn", ((V)(0D)));
Call(SA_23, V.Undef, Get(B_1574, "gl"), ((V)("opacity")), ((V)(0D)));
}
return default;
}
Set(B_1574, "glOn", ((V)(1D)));
Q_1577 = Arr();
N_1578 = 14D;
A_1579 = Fn((V _arrowThis1595, int _argc1588, V u_1594, V _a1591, V _a1592, V _a1593, V[] _rest1589) => {
return ((V)((((40D + (62D * ToNum(u_1594))) * System.Math.PI) / 180D)));
}, 1, "", true);
{
double i_1596 = 0;
i_1596 = 0D;
while (true) {
if (!((i_1596 <= N_1578))) break;
V a_1598 = default;
a_1598 = Call(A_1579, V.Undef, ((V)((i_1596 / N_1578))));
Invoke(Q_1577, "push", Invoke(D_1575, "glob", ((V)((50D + (28D * FdLibm.Sin(ToNum(a_1598)))))), ((V)((60D - (27D * FdLibm.Cos(ToNum(a_1598))))))));
i_1596++;
}
}
{
double i_1599 = 0;
i_1599 = N_1578;
while (true) {
if (!((i_1599 >= 0D))) break;
double u_1601 = 0;
V a_1602 = default;
double k_1603 = 0;
u_1601 = (i_1599 / N_1578);
a_1602 = Call(A_1579, V.Undef, ((V)(u_1601)));
k_1603 = (28D - (3D * FdLibm.Sin((System.Math.PI * u_1601))));
Invoke(Q_1577, "push", Invoke(D_1575, "glob", ((V)((50D + (k_1603 * FdLibm.Sin(ToNum(a_1602)))))), ((V)((60D - ((k_1603 - 1D) * FdLibm.Cos(ToNum(a_1602))))))));
i_1599--;
}
}
Call(SA_23, V.Undef, Get(B_1574, "gl"), ((V)("d")), Call(polyW_13, V.Undef, Q_1577));
Call(SA_23, V.Undef, Get(B_1574, "gl"), ((V)("opacity")), Call(r2_18, V.Undef, ((V)((0.6 * ToNum(p_1576))))));
return default;
}, 2, "draw", false)).V).V));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
