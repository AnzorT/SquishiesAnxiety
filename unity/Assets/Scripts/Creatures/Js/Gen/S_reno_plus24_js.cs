// reno-plus24.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus24_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("^<g transform=\"translate\\([^\"]*\\) scale\\([^\"]*\\)\">.*?<\\/g>", "");
        public static void Run()
        {
Call(Named(boot_63 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V box_11 = default;
V cyl_12 = default;
V ball_13 = default;
V shade_14 = default;
V mix_15 = default;
V N_16 = default;
double PI_17 = 0;
V BR_18 = default;
V CH_19 = default;
V tilt_20 = default;
V rotF_21 = default;
V rod_22 = default;
V pipe_23 = default;
V M__24 = default;
V W__25 = default;
V F__26 = default;
V PL_27 = default;
V rep_28 = default;
V band_29 = default;
V R0_30 = default;
V glue_31 = default;
V rp_32 = default;
V book_33 = default;
V add_34 = default;
V sub_35 = default;
V mul_36 = default;
V cr_37 = default;
V nz_38 = default;
V X3_39 = default;
V Y3_40 = default;
V Z3_41 = default;
V cN_42 = default;
V wv_43 = default;
V dec_44 = default;
V elP_45 = default;
V spot_46 = default;
V rrect_47 = default;
V bb_48 = default;
V at_49 = default;
V ext_50 = default;
V ringY_51 = default;
V ringC_52 = default;
V ST62_53 = default;
V grainX_54 = default;
V speck_55 = default;
V seg_56 = default;
V edit23_57 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((((RD_8 is var _t58 && !Truthy(_t58) ? _t58 : Get(RD_8, "PLUS23")) is var _t59 && !Truthy(_t59) ? _t59 : Get(RD_8, "H22")) is var _t60 && !Truthy(_t60) ? _t60 : Get(RD_8, "H16")) is var _t61 && !Truthy(_t61) ? _t61 : X_9) is var _t62 && !Truthy(_t62) ? _t62 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_63.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS24"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t64 = K_10;
if (_t64.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t64));
{ V _t65 = Get(_t64, "box");
box_11 = _t65; }
{ V _t66 = Get(_t64, "cyl");
cyl_12 = _t66; }
{ V _t67 = Get(_t64, "ball");
ball_13 = _t67; }
{ V _t68 = Get(_t64, "shade");
shade_14 = _t68; }
{ V _t69 = Get(_t64, "mix");
mix_15 = _t69; } }
N_16 = Get(RD_8, "N");
PI_17 = System.Math.PI;
BR_18 = ((V)("#d4a548"));
CH_19 = ((V)("#d5dde2"));
{ V _t70 = Get(RD_8, "H16");
if (_t70.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t70));
{ V _t71 = Get(_t70, "tilt");
tilt_20 = _t71; }
{ V _t72 = Get(_t70, "rotF");
rotF_21 = _t72; }
{ V _t73 = Get(_t70, "rod");
rod_22 = _t73; }
{ V _t74 = Get(_t70, "pipe");
pipe_23 = _t74; }
{ V _t75 = Get(_t70, "M_");
M__24 = _t75; }
{ V _t76 = Get(_t70, "W_");
W__25 = _t76; }
{ V _t77 = Get(_t70, "F_");
F__26 = _t77; }
{ V _t78 = Get(_t70, "PL");
PL_27 = _t78; }
{ V _t79 = Get(_t70, "rep");
rep_28 = _t79; } }
{ V _t80 = Get(RD_8, "H22");
if (_t80.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t80));
{ V _t81 = Get(_t80, "band");
band_29 = _t81; }
{ V _t82 = Get(_t80, "R0");
R0_30 = _t82; }
{ V _t83 = Get(_t80, "glue");
glue_31 = _t83; }
{ V _t84 = Get(_t80, "rp");
rp_32 = _t84; }
{ V _t85 = Get(_t80, "book");
book_33 = _t85; } }
add_34 = Fn((V _arrowThis94, int _argc86, V a_92, V b_93, V _a90, V _a91, V[] _rest87) => {
return Arr(Add(GetIdx(a_92, 0D), GetIdx(b_93, 0D)), Add(GetIdx(a_92, 1D), GetIdx(b_93, 1D)), Add(GetIdx(a_92, 2D), GetIdx(b_93, 2D)));
}, 2, "", true);
sub_35 = Fn((V _arrowThis103, int _argc95, V a_101, V b_102, V _a99, V _a100, V[] _rest96) => {
return Arr(((V)((ToNum(GetIdx(a_101, 0D)) - ToNum(GetIdx(b_102, 0D))))), ((V)((ToNum(GetIdx(a_101, 1D)) - ToNum(GetIdx(b_102, 1D))))), ((V)((ToNum(GetIdx(a_101, 2D)) - ToNum(GetIdx(b_102, 2D))))));
}, 2, "", true);
mul_36 = Fn((V _arrowThis112, int _argc104, V a_110, V k_111, V _a108, V _a109, V[] _rest105) => {
return Arr(((V)((ToNum(GetIdx(a_110, 0D)) * ToNum(k_111)))), ((V)((ToNum(GetIdx(a_110, 1D)) * ToNum(k_111)))), ((V)((ToNum(GetIdx(a_110, 2D)) * ToNum(k_111)))));
}, 2, "", true);
cr_37 = Fn((V _arrowThis121, int _argc113, V a_119, V b_120, V _a117, V _a118, V[] _rest114) => {
return Arr(((V)(((ToNum(GetIdx(a_119, 1D)) * ToNum(GetIdx(b_120, 2D))) - (ToNum(GetIdx(a_119, 2D)) * ToNum(GetIdx(b_120, 1D)))))), ((V)(((ToNum(GetIdx(a_119, 2D)) * ToNum(GetIdx(b_120, 0D))) - (ToNum(GetIdx(a_119, 0D)) * ToNum(GetIdx(b_120, 2D)))))), ((V)(((ToNum(GetIdx(a_119, 0D)) * ToNum(GetIdx(b_120, 1D))) - (ToNum(GetIdx(a_119, 1D)) * ToNum(GetIdx(b_120, 0D)))))));
}, 2, "", true);
nz_38 = Fn((V _arrowThis129, int _argc122, V a_128, V _a125, V _a126, V _a127, V[] _rest123) => {
V L_130 = default;
L_130 = (((V)(Hypot(ToNum(GetIdx(a_128, 0D)), ToNum(GetIdx(a_128, 1D)), ToNum(GetIdx(a_128, 2D))))) is var _t131 && Truthy(_t131) ? _t131 : ((V)(1D)));
return Arr(((V)((ToNum(GetIdx(a_128, 0D)) / ToNum(L_130)))), ((V)((ToNum(GetIdx(a_128, 1D)) / ToNum(L_130)))), ((V)((ToNum(GetIdx(a_128, 2D)) / ToNum(L_130)))));
return default;
}, 1, "", true);
X3_39 = Arr(((V)(1D)), ((V)(0D)), ((V)(0D)));
Y3_40 = Arr(((V)(0D)), ((V)(1D)), ((V)(0D)));
Z3_41 = Arr(((V)(0D)), ((V)(0D)), ((V)(1D)));
cN_42 = Fn((V _arrowThis139, int _argc132, V a_138, V _a135, V _a136, V _a137, V[] _rest133) => {
return Arr(((V)(FdLibm.Cos(ToNum(a_138)))), ((V)(0D)), ((V)(FdLibm.Sin(ToNum(a_138)))));
}, 1, "", true);
wv_43 = Fn((V _arrowThis148, int _argc140, V m_146, V f_147, V _a144, V _a145, V[] _rest141) => {
return Call(rep_28, V.Undef, Add(m_146, ((V)(1D))), Fn((V _arrowThis156, int _argc149, V i_155, V _a152, V _a153, V _a154, V[] _rest150) => {
return Call(f_147, V.Undef, ((V)((ToNum(i_155) / ToNum(m_146)))));
}, 1, "", true));
}, 2, "", true);
dec_44 = Fn((V _arrowThis165, int _argc157, V col_163, V o_164, V _a161, V _a162, V[] _rest158) => {
V S_166 = default;
double LF_167 = 0;
S_166 = Object_assign(NewObj(6).Put("faces", Arr()).Put("pts", Arr()).Put("col", col_163).Put("cv", ((V)(0D))).Put("zb", ((V)(0D))).Put("noOut", ((V)(1D))).V, (o_164 is var _t168 && Truthy(_t168) ? _t168 : NewObj(0).V));
LF_167 = 0.05;
Set(S_166, "line", Fn((V _arrowThis179, int _argc169, V P_175, V Nn_176, V w_177, V tp_178, V[] _rest170) => {
V n_180 = default;
V nn_181 = default;
V L_182 = default;
n_180 = Get(P_175, "length");
if (LtN(n_180, 2D)) {
return S_166;
}
nn_181 = Fn((V _arrowThis190, int _argc183, V i_189, V _a186, V _a187, V _a188, V[] _rest184) => {
return ((GetIdx(Nn_176, 0D).O is JsArray) ? GetK(Nn_176, i_189) : Nn_176);
}, 1, "", true);
L_182 = Invoke(P_175, "map", Fn((V _arrowThis199, int _argc191, V p_197, V i_198, V _a195, V _a196, V[] _rest192) => {
V t_200 = default;
V q_201 = default;
V sd_202 = default;
double k_203 = 0;
V b_204 = default;
t_200 = Call(nz_38, V.Undef, Call(sub_35, V.Undef, GetIdx(P_175, Min((ToNum(n_180) - 1D), ToNum(Add(i_198, ((V)(1D)))))), GetIdx(P_175, Max(0D, (ToNum(i_198) - 1D)))));
q_201 = Call(nn_181, V.Undef, i_198);
sd_202 = Call(nz_38, V.Undef, Call(cr_37, V.Undef, t_200, q_201));
k_203 = (((Truthy(tp_178) ? Max(0.2, FdLibm.Sin(((PI_17 * ToNum(i_198)) / (ToNum(n_180) - 1D)))) : 1D) * ToNum(w_177)) / 2D);
b_204 = Call(add_34, V.Undef, p_197, Call(mul_36, V.Undef, q_201, ((V)(LF_167))));
return Arr(Call(add_34, V.Undef, b_204, Call(mul_36, V.Undef, sd_202, ((V)(k_203)))), Call(add_34, V.Undef, b_204, Call(mul_36, V.Undef, sd_202, ((V)((-k_203))))));
return default;
}, 2, "", true));
{
double i_205 = 0;
i_205 = 0D;
while (true) {
if (!((i_205 < (ToNum(n_180) - 1D)))) break;
V q_207 = default;
q_207 = Arr(GetIdx(GetIdx(L_182, i_205), 0D), GetIdx(GetIdx(L_182, (i_205 + 1D)), 0D), GetIdx(GetIdx(L_182, (i_205 + 1D)), 1D), GetIdx(GetIdx(L_182, i_205), 1D));
Invoke(Get(S_166, "faces"), "push", NewObj(2).Put("q", q_207).Put("n", Call(nz_38, V.Undef, Call(add_34, V.Undef, Call(nn_181, V.Undef, ((V)(i_205))), Call(nn_181, V.Undef, ((V)((i_205 + 1D))))))).V);
Invoke(q_207, "forEach", Fn((V _arrowThis215, int _argc208, V p_214, V _a211, V _a212, V _a213, V[] _rest209) => {
return Invoke(Get(S_166, "pts"), "push", Invoke(p_214, "slice"));
}, 1, "", true));
i_205++;
}
}
return S_166;
return default;
}, 4, "", true));
Set(S_166, "poly", Fn((V _arrowThis224, int _argc216, V P_222, V n_223, V _a220, V _a221, V[] _rest217) => {
V q_225 = default;
q_225 = Invoke(P_222, "map", Fn((V _arrowThis233, int _argc226, V p_232, V _a229, V _a230, V _a231, V[] _rest227) => {
return Call(add_34, V.Undef, p_232, Call(mul_36, V.Undef, n_223, ((V)(LF_167))));
}, 1, "", true));
Invoke(Get(S_166, "faces"), "push", NewObj(2).Put("q", q_225).Put("n", Invoke(n_223, "slice")).V);
Invoke(q_225, "forEach", Fn((V _arrowThis241, int _argc234, V p_240, V _a237, V _a238, V _a239, V[] _rest235) => {
return Invoke(Get(S_166, "pts"), "push", Invoke(p_240, "slice"));
}, 1, "", true));
return S_166;
return default;
}, 2, "", true));
return S_166;
return default;
}, 2, "", true);
elP_45 = Fn((V _arrowThis254, int _argc242, V c_248, V u_249, V v_250, V rx_251, V[] _rest243) => {
V ry_252 = default;
V m_253 = default;
ry_252 = (_argc242 > 4 ? _rest243[0] : V.Undef);
m_253 = (_argc242 > 5 ? _rest243[1] : V.Undef);
return Call(rep_28, V.Undef, (m_253 is var _t255 && Truthy(_t255) ? _t255 : ((V)(10D))), Fn((V _arrowThis263, int _argc256, V i_262, V _a259, V _a260, V _a261, V[] _rest257) => {
double a_264 = 0;
a_264 = (((ToNum(i_262) / ToNum((m_253 is var _t265 && Truthy(_t265) ? _t265 : ((V)(10D))))) * 2D) * PI_17);
return Call(add_34, V.Undef, c_248, Call(add_34, V.Undef, Call(mul_36, V.Undef, u_249, ((V)((FdLibm.Cos(a_264) * ToNum(rx_251))))), Call(mul_36, V.Undef, v_250, ((V)((FdLibm.Sin(a_264) * ToNum(ry_252)))))));
return default;
}, 1, "", true));
}, 6, "", true);
spot_46 = Fn((V _arrowThis279, int _argc266, V D_272, V c_273, V n_274, V rx_275, V[] _rest267) => {
V u_280 = default;
V v_281 = default;
V ry_276 = default;
V rot_277 = default;
V m_278 = default;
ry_276 = (_argc266 > 4 ? _rest267[0] : V.Undef);
rot_277 = (_argc266 > 5 ? _rest267[1] : V.Undef);
m_278 = (_argc266 > 6 ? _rest267[2] : V.Undef);
u_280 = ((System.Math.Abs(ToNum(GetIdx(n_274, 1D))) > 0.9) ? X3_39 : Call(nz_38, V.Undef, Call(cr_37, V.Undef, Y3_40, n_274)));
v_281 = Call(nz_38, V.Undef, Call(cr_37, V.Undef, n_274, u_280));
if (Truthy(rot_277)) {
double a_282 = 0;
double b_283 = 0;
V u2_284 = default;
a_282 = FdLibm.Cos(ToNum(rot_277));
b_283 = FdLibm.Sin(ToNum(rot_277));
u2_284 = Call(add_34, V.Undef, Call(mul_36, V.Undef, u_280, ((V)(a_282))), Call(mul_36, V.Undef, v_281, ((V)(b_283))));
v_281 = Call(add_34, V.Undef, Call(mul_36, V.Undef, v_281, ((V)(a_282))), Call(mul_36, V.Undef, u_280, ((V)((-b_283)))));
u_280 = u2_284;
}
return Invoke(D_272, "poly", Call(elP_45, V.Undef, c_273, u_280, v_281, rx_275, ry_276, (m_278 is var _t285 && Truthy(_t285) ? _t285 : ((V)(8D)))), n_274);
return default;
}, 7, "", true);
rrect_47 = Fn((V _arrowThis300, int _argc286, V cx_292, V y_293, V cz_294, V w_295, V[] _rest287) => {
double c_301 = 0;
double s_302 = 0;
V d_296 = default;
V yaw_297 = default;
V ox_298 = default;
V oz_299 = default;
d_296 = (_argc286 > 4 ? _rest287[0] : V.Undef);
yaw_297 = (_argc286 > 5 ? _rest287[1] : V.Undef);
ox_298 = (_argc286 > 6 ? _rest287[2] : V.Undef);
oz_299 = (_argc286 > 7 ? _rest287[3] : V.Undef);
c_301 = FdLibm.Cos(ToNum((yaw_297 is var _t303 && Truthy(_t303) ? _t303 : ((V)(0D)))));
s_302 = FdLibm.Sin(ToNum((yaw_297 is var _t304 && Truthy(_t304) ? _t304 : ((V)(0D)))));
ox_298 = (ox_298 is var _t305 && Truthy(_t305) ? _t305 : ((V)(0D)));
oz_299 = (oz_299 is var _t306 && Truthy(_t306) ? _t306 : ((V)(0D)));
return Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(1D))), Arr(((V)((-1D))), ((V)(1D)))), "map", Fn((V _arrowThis318, int _argc307, V _a309, V _a310, V _a311, V _a312, V[] _rest308) => {
V u_319 = default;
V v_320 = default;
V a_315 = default;
V b_317 = default;
{ V _t313 = ListOf(_a309);
{ V _t314 = GetIdx(_t313, 0D);
a_315 = _t314; }
{ V _t316 = GetIdx(_t313, 1D);
b_317 = _t316; }
}
u_319 = Add(ox_298, ((V)(((ToNum(a_315) * ToNum(w_295)) / 2D))));
v_320 = Add(oz_299, ((V)(((ToNum(b_317) * ToNum(d_296)) / 2D))));
return Arr(((V)((ToNum(Add(cx_292, ((V)((ToNum(u_319) * c_301))))) - (ToNum(v_320) * s_302)))), y_293, Add(Add(cz_294, ((V)((ToNum(u_319) * s_302)))), ((V)((ToNum(v_320) * c_301)))));
return default;
}, 1, "", true));
return default;
}, 8, "", true);
bb_48 = Fn((V _arrowThis328, int _argc321, V S_327, V _a324, V _a325, V _a326, V[] _rest322) => {
V L_329 = default;
L_329 = Arr(((V)(1000000000D)), ((V)((-1000000000D))), ((V)(1000000000D)), ((V)((-1000000000D))), ((V)(1000000000D)), ((V)((-1000000000D))));
Invoke(Get(S_327, "pts"), "forEach", Fn((V _arrowThis337, int _argc330, V p_336, V _a333, V _a334, V _a335, V[] _rest331) => {
{
double k_338 = 0;
k_338 = 0D;
while (true) {
if (!((k_338 < 3D))) break;
if (Lt(GetIdx(p_336, k_338), GetIdx(L_329, (2D * k_338)))) {
SetIdx(L_329, (2D * k_338), GetIdx(p_336, k_338));
}
if (Gt(GetIdx(p_336, k_338), GetIdx(L_329, ((2D * k_338) + 1D)))) {
SetIdx(L_329, ((2D * k_338) + 1D), GetIdx(p_336, k_338));
}
k_338++;
}
}
return default;
}, 1, "", true));
return L_329;
return default;
}, 1, "", true);
at_49 = Fn((V _arrowThis351, int _argc340, V o_346, V p_347, V col_348, V m_349, V[] _rest341) => {
V best_352 = default;
double bv_353 = 0;
V all_350 = default;
all_350 = (_argc340 > 4 ? _rest341[0] : V.Undef);
m_349 = (m_349.IsNullish ? ((V)(0.6)) : m_349);
best_352 = V.Null;
bv_353 = 1000000000000000000D;
Invoke(o_346, "forEach", Fn((V _arrowThis361, int _argc354, V S_360, V _a357, V _a358, V _a359, V[] _rest355) => {
V L_362 = default;
double v_363 = 0;
if (Truthy((((Get(S_360, "par") is var _t364 && !Truthy(_t364) ? _t364 : (!(Truthy(all_350)) ? V.True : V.False)) is var _t366 && Truthy(_t366) ? _t366 : (col_348 is var _t365 && !Truthy(_t365) ? _t365 : (!SEq(Get(S_360, "col"), col_348) ? V.True : V.False))) is var _t367 && Truthy(_t367) ? _t367 : (!(Truthy(Get(S_360, "pts"))) ? V.True : V.False)))) {
return default;
}
L_362 = Call(bb_48, V.Undef, S_360);
if ((((((LtN(GetIdx(p_347, 0D), (ToNum(GetIdx(L_362, 0D)) - ToNum(m_349))) || Gt(GetIdx(p_347, 0D), Add(GetIdx(L_362, 1D), m_349))) || LtN(GetIdx(p_347, 1D), (ToNum(GetIdx(L_362, 2D)) - ToNum(m_349)))) || Gt(GetIdx(p_347, 1D), Add(GetIdx(L_362, 3D), m_349))) || LtN(GetIdx(p_347, 2D), (ToNum(GetIdx(L_362, 4D)) - ToNum(m_349)))) || Gt(GetIdx(p_347, 2D), Add(GetIdx(L_362, 5D), m_349)))) {
return default;
}
v_363 = ((((ToNum(GetIdx(L_362, 1D)) - ToNum(GetIdx(L_362, 0D))) + 0.1) * ((ToNum(GetIdx(L_362, 3D)) - ToNum(GetIdx(L_362, 2D))) + 0.1)) * ((ToNum(GetIdx(L_362, 5D)) - ToNum(GetIdx(L_362, 4D))) + 0.1));
if ((v_363 < bv_353)) {
bv_353 = v_363;
best_352 = S_360;
}
return default;
}, 1, "", true));
return best_352;
return default;
}, 5, "", true);
ext_50 = Fn((V _arrowThis377, int _argc368, V src_374, V f_375, V more_376, V _a373, V[] _rest369) => {
return Fn((V _arrowThis385, int _argc378, V S_384, V _a381, V _a382, V _a383, V[] _rest379) => {
V B_386 = default;
V D_387 = default;
B_386 = InvokeK(N_16, src_374, S_384);
D_387 = Object_assign(NewObj(0).V, B_386, (more_376 is var _t388 && Truthy(_t388) ? _t388 : NewObj(0).V));
if (Truthy(Get(B_386, "build"))) {
Set(D_387, "build", Fn((V _arrowThis396, int _argc389, V _a391, V _a392, V _a393, V _a394, V[] _rest390) => {
V o_397 = default;
V a_395 = default;
a_395 = RestArgs(0, _argc389, _a391, _a392, _a393, _a394, _rest390);
o_397 = InvokeSpread(B_386, "build", new ArrBuilder().Spread(a_395).V);
Call(f_375, V.Undef, o_397, Call(glue_31, V.Undef, o_397), Call(R0_30, V.Undef, ((V)(JsStrBuf.Begin().V(src_374).S("24").End()))));
return o_397;
return default;
}, 1, "", true));
}
return D_387;
return default;
}, 1, "", true);
}, 3, "", true);
ringY_51 = Fn((V _arrowThis411, int _argc398, V D_404, V cx_405, V cz_406, V r_407, V[] _rest399) => {
V y_408 = default;
V w_409 = default;
V m_410 = default;
y_408 = (_argc398 > 4 ? _rest399[0] : V.Undef);
w_409 = (_argc398 > 5 ? _rest399[1] : V.Undef);
m_410 = (_argc398 > 6 ? _rest399[2] : V.Undef);
return Invoke(D_404, "line", Call(wv_43, V.Undef, (m_410 is var _t412 && Truthy(_t412) ? _t412 : ((V)(40D))), Fn((V _arrowThis420, int _argc413, V t_419, V _a416, V _a417, V _a418, V[] _rest414) => {
return Arr(Add(cx_405, ((V)((FdLibm.Cos(((ToNum(t_419) * 2D) * PI_17)) * ToNum(r_407))))), y_408, Add(cz_406, ((V)((FdLibm.Sin(((ToNum(t_419) * 2D) * PI_17)) * ToNum(r_407))))));
}, 1, "", true)), Y3_40, w_409);
}, 7, "", true);
ringC_52 = Fn((V _arrowThis436, int _argc421, V D_427, V cx_428, V cz_429, V r_430, V[] _rest422) => {
V y_431 = default;
V w_432 = default;
V m_433 = default;
V wob_434 = default;
V ph_435 = default;
y_431 = (_argc421 > 4 ? _rest422[0] : V.Undef);
w_432 = (_argc421 > 5 ? _rest422[1] : V.Undef);
m_433 = (_argc421 > 6 ? _rest422[2] : V.Undef);
wob_434 = (_argc421 > 7 ? _rest422[3] : V.Undef);
ph_435 = (_argc421 > 8 ? _rest422[4] : V.Undef);
return Invoke(D_427, "line", Call(wv_43, V.Undef, (m_433 is var _t437 && Truthy(_t437) ? _t437 : ((V)(40D))), Fn((V _arrowThis445, int _argc438, V t_444, V _a441, V _a442, V _a443, V[] _rest439) => {
double a_446 = 0;
a_446 = ((ToNum(t_444) * 2D) * PI_17);
return Arr(Add(cx_428, ((V)((FdLibm.Cos(a_446) * ToNum(r_430))))), Add(y_431, ((V)((Truthy(wob_434) ? (ToNum(wob_434) * FdLibm.Sin(ToNum(Add(((V)((a_446 * 3D))), (ph_435 is var _t447 && Truthy(_t447) ? _t447 : ((V)(0D))))))) : 0D)))), Add(cz_429, ((V)((FdLibm.Sin(a_446) * ToNum(r_430))))));
return default;
}, 1, "", true)), Call(wv_43, V.Undef, (m_433 is var _t448 && Truthy(_t448) ? _t448 : ((V)(40D))), Fn((V _arrowThis456, int _argc449, V t_455, V _a452, V _a453, V _a454, V[] _rest450) => {
return Call(cN_42, V.Undef, ((V)(((ToNum(t_455) * 2D) * PI_17))));
}, 1, "", true)), w_432);
}, 9, "", true);
Set(N_16, "torch24", Call(ext_50, V.Undef, ((V)("torch22")), Fn((V _arrowThis466, int _argc457, V o_463, V on_464, V R_465, V _a462, V[] _rest458) => {
V ST_467 = default;
double TA_468 = 0;
V piv_469 = default;
V RT_470 = default;
V P_471 = default;
V BS_472 = default;
V PO_473 = default;
V TP_474 = default;
V SH_475 = default;
V CD_476 = default;
ST_467 = ((V)("#8a8f94"));
TA_468 = (-0.22);
piv_469 = Arr(((V)(7D)), ((V)(121D)), ((V)(7D)));
RT_470 = Call(rotF_21, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(TA_468)));
P_471 = Fn((V _arrowThis484, int _argc477, V v_483, V _a480, V _a481, V _a482, V[] _rest478) => {
return Call(rp_32, V.Undef, RT_470, piv_469, v_483);
}, 1, "", true);
BS_472 = Call(at_49, V.Undef, o_463, Arr(((V)(9D)), ((V)(1D)), ((V)(0D))), ST_467);
if (Truthy(BS_472)) {
V d1_485 = default;
V d2_486 = default;
V d3_487 = default;
V SK_488 = default;
V SK2_489 = default;
V SK3_490 = default;
d1_485 = Call(dec_44, V.Undef, ((V)("#dfe4e8")), NewObj(1).Put("op", ((V)(0.5))).V);
d2_486 = Call(dec_44, V.Undef, ((V)("#3e3428")), NewObj(1).Put("op", ((V)(0.55))).V);
d3_487 = Call(dec_44, V.Undef, ((V)("#9a5a2e")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Arr(((V)(4D)), ((V)(5.6)), ((V)(7.2)), ((V)(8.8)), ((V)(10D))), "forEach", Fn((V _arrowThis499, int _argc491, V r_497, V k_498, V _a495, V _a496, V[] _rest492) => {
return Call(ringY_51, V.Undef, d1_485, ((V)(0D)), ((V)(0D)), r_497, ((V)(3D)), ((V)((NumTruthy((ToNum(k_498) % 2D)) ? 0.12 : 0.2))), ((V)(48D)));
}, 2, "", true));
Call(rep_28, V.Undef, ((V)(8D)), Fn((V _arrowThis506, int _argc500, V _a502, V _a503, V _a504, V _a505, V[] _rest501) => {
double a_507 = 0;
double r_508 = 0;
double L_509 = 0;
V b_510 = default;
V p_511 = default;
a_507 = ((ToNum(Call(R_465, V.Undef)) * 2D) * PI_17);
r_508 = (4.4 + (ToNum(Call(R_465, V.Undef)) * 5D));
L_509 = (1.2 + (ToNum(Call(R_465, V.Undef)) * 2D));
b_510 = Add(((V)((a_507 + 1.3))), Call(R_465, V.Undef));
p_511 = Arr(((V)((FdLibm.Cos(a_507) * r_508))), ((V)(3D)), ((V)((FdLibm.Sin(a_507) * r_508))));
Invoke(d2_486, "line", Arr(p_511, Call(add_34, V.Undef, p_511, Arr(((V)((FdLibm.Cos(ToNum(b_510)) * L_509))), ((V)(0D)), ((V)((FdLibm.Sin(ToNum(b_510)) * L_509)))))), Y3_40, ((V)(0.18)));
return default;
}, 0, "", true));
Call(rep_28, V.Undef, ((V)(8D)), Fn((V _arrowThis518, int _argc512, V _a514, V _a515, V _a516, V _a517, V[] _rest513) => {
double a_519 = 0;
double r_520 = 0;
a_519 = ((ToNum(Call(R_465, V.Undef)) * 2D) * PI_17);
r_520 = (4.2 + (ToNum(Call(R_465, V.Undef)) * 5.6));
Call(spot_46, V.Undef, d3_487, Arr(((V)((FdLibm.Cos(a_519) * r_520))), ((V)(3D)), ((V)((FdLibm.Sin(a_519) * r_520)))), Y3_40, ((V)((0.3 + (ToNum(Call(R_465, V.Undef)) * 0.6)))), ((V)((0.2 + (ToNum(Call(R_465, V.Undef)) * 0.35)))), ((V)((ToNum(Call(R_465, V.Undef)) * 3D))));
return default;
}, 0, "", true));
Call(rep_28, V.Undef, ((V)(7D)), Fn((V _arrowThis527, int _argc521, V _a523, V _a524, V _a525, V _a526, V[] _rest522) => {
double a_528 = 0;
a_528 = ((ToNum(Call(R_465, V.Undef)) * 2D) * PI_17);
Call(spot_46, V.Undef, d3_487, Arr(((V)((FdLibm.Cos(a_528) * 11.9))), ((V)(1.4)), ((V)((FdLibm.Sin(a_528) * 11.9)))), Call(nz_38, V.Undef, Arr(((V)(FdLibm.Cos(a_528))), ((V)(0.78)), ((V)(FdLibm.Sin(a_528))))), ((V)((0.6 + (ToNum(Call(R_465, V.Undef)) * 0.6)))), ((V)(0.3)), ((V)(0D)));
return default;
}, 0, "", true));
SK_488 = Call(dec_44, V.Undef, ((V)("#f28a3a")));
Invoke(SK_488, "poly", Call(elP_45, V.Undef, Arr(((V)(5D)), ((V)(3D)), ((V)((-4.6)))), X3_39, Z3_41, ((V)(2.2)), ((V)(1.5)), ((V)(14D))), Y3_40);
SK2_489 = Call(dec_44, V.Undef, ((V)("#fff4dc")));
Invoke(SK2_489, "poly", Call(elP_45, V.Undef, Arr(((V)(5D)), ((V)(3D)), ((V)((-4.6)))), X3_39, Z3_41, ((V)(1.5)), ((V)(0.95)), ((V)(12D))), Y3_40);
SK3_490 = Call(dec_44, V.Undef, ((V)("#5a3a22")));
Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis536, int _argc529, V i_535, V _a532, V _a533, V _a534, V[] _rest530) => {
return Invoke(SK3_490, "line", Arr(Arr(((V)((4.1 + (ToNum(i_535) * 0.42)))), ((V)(3D)), ((V)((-5.1)))), Arr(((V)((4.1 + (ToNum(i_535) * 0.42)))), ((V)(3D)), ((V)((-4.1))))), Y3_40, ((V)((NumTruthy((ToNum(i_535) % 2D)) ? 0.12 : 0.22))));
}, 1, "", true));
Call(on_464, V.Undef, BS_472, Arr(Call(band_29, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(13.06)), ((V)(0.9)), ((V)("#2a2b30")), NewObj(2).Put("n", ((V)(26D))).Put("noOut", ((V)(1D))).V), d1_485, d2_486, d3_487, SK_488, SK2_489, SK3_490));
}
PO_473 = Call(at_49, V.Undef, o_463, Arr(((V)(0.4)), ((V)(27D)), ((V)(0.2))), ST_467);
if (Truthy(PO_473)) {
double y_537 = 0;
double x_538 = 0;
double z_539 = 0;
V d_540 = default;
y_537 = 33D;
x_538 = ((0.8 * (y_537 - 5.4)) / 42.6);
z_539 = ((0.4 * (y_537 - 5.4)) / 42.6);
d_540 = Call(dec_44, V.Undef, ((V)("#8a4a24")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(rep_28, V.Undef, ((V)(8D)), Fn((V _arrowThis547, int _argc541, V _a543, V _a544, V _a545, V _a546, V[] _rest542) => {
double a_548 = 0;
double yy_549 = 0;
double xx_550 = 0;
double zz_551 = 0;
a_548 = ((ToNum(Call(R_465, V.Undef)) * 2D) * PI_17);
yy_549 = (8D + (ToNum(Call(R_465, V.Undef)) * 36D));
xx_550 = ((0.8 * (yy_549 - 5.4)) / 42.6);
zz_551 = ((0.4 * (yy_549 - 5.4)) / 42.6);
Call(spot_46, V.Undef, d_540, Arr(((V)((xx_550 + FdLibm.Cos(a_548)))), ((V)(yy_549)), ((V)((zz_551 + FdLibm.Sin(a_548))))), Call(cN_42, V.Undef, ((V)(a_548))), ((V)(0.32)), ((V)((0.5 + (ToNum(Call(R_465, V.Undef)) * 0.7)))), ((V)(0D)));
return default;
}, 0, "", true));
Call(on_464, V.Undef, PO_473, Arr(d_540, Call(cyl_12, V.Undef, ((V)(x_538)), ((V)((y_537 - 1.7))), ((V)(z_539)), ((V)(1.8)), ((V)(3.4)), ((V)("#2a2b30")), Call(PL_27, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(band_29, V.Undef, ((V)(x_538)), ((V)((y_537 + 1.1))), ((V)(z_539)), ((V)(1.82)), ((V)(0.35)), ((V)("#5c6166")), NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V)));
Call(on_464, V.Undef, PO_473, Arr(Call(box_11, V.Undef, ((V)(x_538)), ((V)((y_537 - 0.8))), ((V)((z_539 + 1.9))), ((V)(1.3)), ((V)(1.4)), ((V)(1.2)), ((V)("#e8e2d4")), Call(PL_27, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))), Z3_41);
}
TP_474 = Call(at_49, V.Undef, o_463, Arr(((V)(0.3)), ((V)(62D)), ((V)(0.5))), ((V)("#b9bec4")), ((V)(0.6)), ((V)(1D)));
if (Truthy(TP_474)) {
V d_552 = default;
d_552 = Call(dec_44, V.Undef, ((V)("#7d8288")), NewObj(1).Put("op", ((V)(0.55))).V);
Invoke(Arr(((V)(60.9)), ((V)(62.4)), ((V)(63.8))), "forEach", Fn((V _arrowThis561, int _argc553, V y_559, V k_560, V _a557, V _a558, V[] _rest554) => {
return Call(ringC_52, V.Undef, d_552, ((V)(0.3)), ((V)(0.5)), ((V)(1.62)), y_559, ((V)(0.16)), ((V)(16D)), ((V)(0.25)), k_560);
}, 2, "", true));
Call(on_464, V.Undef, TP_474, Arr(d_552));
Call(on_464, V.Undef, TP_474, Arr(Call(tilt_20, V.Undef, Call(box_11, V.Undef, ((V)(1.95)), ((V)(59.6)), ((V)(1.2)), ((V)(0.25)), ((V)(2.4)), ((V)(1.4)), ((V)("#c6cbd0")), NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(0.25)), Arr(((V)(1.9)), ((V)(62D)), ((V)(1.2))))), X3_39);
}
SH_475 = Call(at_49, V.Undef, o_463, Call(P_471, V.Undef, Arr(((V)(7D)), ((V)(125D)), ((V)(7D)))), ((V)("#eadcbe")), ((V)(0.6)), ((V)(1D)));
if (Truthy(SH_475)) {
V rr_562 = default;
V sl_563 = default;
V pt_564 = default;
V nn_565 = default;
V RB_566 = default;
V HL_567 = default;
V SC_568 = default;
V CK_569 = default;
rr_562 = Fn((V _arrowThis577, int _argc570, V y_576, V _a573, V _a574, V _a575, V[] _rest571) => {
return ((V)((6D * (LtN(y_576, 4D) ? (0.45 + ((0.5 * ToNum(y_576)) / 4D)) : (0.95 + ((1.3 * (ToNum(y_576) - 4D)) / 9D))))));
}, 1, "", true);
sl_563 = Fn((V _arrowThis585, int _argc578, V y_584, V _a581, V _a582, V _a583, V[] _rest579) => {
return ((V)((LtN(y_584, 4D) ? 0.75 : 0.867)));
}, 1, "", true);
pt_564 = Fn((V _arrowThis595, int _argc586, V a_592, V y_593, V k_594, V _a591, V[] _rest587) => {
return Call(P_471, V.Undef, Arr(((V)((7D + ((FdLibm.Cos(ToNum(a_592)) * ToNum(Call(rr_562, V.Undef, y_593))) * ToNum((k_594 is var _t596 && Truthy(_t596) ? _t596 : ((V)(1.01)))))))), Add(((V)(118D)), y_593), ((V)((7D + ((FdLibm.Sin(ToNum(a_592)) * ToNum(Call(rr_562, V.Undef, y_593))) * ToNum((k_594 is var _t597 && Truthy(_t597) ? _t597 : ((V)(1.01))))))))));
}, 3, "", true);
nn_565 = Fn((V _arrowThis606, int _argc598, V a_604, V y_605, V _a602, V _a603, V[] _rest599) => {
return Call(RT_470, V.Undef, Call(nz_38, V.Undef, Arr(((V)(FdLibm.Cos(ToNum(a_604)))), ((V)((-ToNum(Call(sl_563, V.Undef, y_605))))), ((V)(FdLibm.Sin(ToNum(a_604)))))));
}, 2, "", true);
RB_566 = Call(dec_44, V.Undef, ((V)("#cdbb94")), NewObj(1).Put("op", ((V)(0.75))).V);
HL_567 = Call(dec_44, V.Undef, ((V)("#fff8e6")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(rep_28, V.Undef, ((V)(20D)), Fn((V _arrowThis614, int _argc607, V i_613, V _a610, V _a611, V _a612, V[] _rest608) => {
double a_615 = 0;
V Y_616 = default;
a_615 = (((ToNum(i_613) / 20D) * 2D) * PI_17);
Y_616 = Call(wv_43, V.Undef, ((V)(8D)), Fn((V _arrowThis624, int _argc617, V t_623, V _a620, V _a621, V _a622, V[] _rest618) => {
return ((V)((0.6 + (ToNum(t_623) * 12D))));
}, 1, "", true));
Invoke(RB_566, "line", Invoke(Y_616, "map", Fn((V _arrowThis632, int _argc625, V y_631, V _a628, V _a629, V _a630, V[] _rest626) => {
return Call(pt_564, V.Undef, ((V)(a_615)), y_631);
}, 1, "", true)), Invoke(Y_616, "map", Fn((V _arrowThis640, int _argc633, V y_639, V _a636, V _a637, V _a638, V[] _rest634) => {
return Call(nn_565, V.Undef, ((V)(a_615)), y_639);
}, 1, "", true)), ((V)(0.3)));
Invoke(HL_567, "line", Invoke(Y_616, "map", Fn((V _arrowThis648, int _argc641, V y_647, V _a644, V _a645, V _a646, V[] _rest642) => {
return Call(pt_564, V.Undef, ((V)((a_615 + 0.07))), y_647);
}, 1, "", true)), Invoke(Y_616, "map", Fn((V _arrowThis656, int _argc649, V y_655, V _a652, V _a653, V _a654, V[] _rest650) => {
return Call(nn_565, V.Undef, ((V)((a_615 + 0.07))), y_655);
}, 1, "", true)), ((V)(0.14)));
return default;
}, 1, "", true));
SC_568 = Call(dec_44, V.Undef, ((V)("#a8743a")), NewObj(1).Put("op", ((V)(0.35))).V);
Call(spot_46, V.Undef, SC_568, Call(pt_564, V.Undef, ((V)(2.4)), ((V)(10.4))), Call(nn_565, V.Undef, ((V)(2.4)), ((V)(10.4))), ((V)(2.6)), ((V)(1.4)), ((V)(0D)));
Call(spot_46, V.Undef, SC_568, Call(pt_564, V.Undef, ((V)(2.4)), ((V)(10.8))), Call(nn_565, V.Undef, ((V)(2.4)), ((V)(10.8))), ((V)(1.3)), ((V)(0.7)), ((V)(0D)));
CK_569 = Call(dec_44, V.Undef, ((V)("#6a5a40")), NewObj(1).Put("op", ((V)(0.8))).V);
Invoke(CK_569, "line", Arr(Call(pt_564, V.Undef, ((V)(1.25)), ((V)(12.6))), Call(pt_564, V.Undef, ((V)(1.32)), ((V)(11D))), Call(pt_564, V.Undef, ((V)(1.24)), ((V)(9.6))), Call(pt_564, V.Undef, ((V)(1.36)), ((V)(8.2))), Call(pt_564, V.Undef, ((V)(1.3)), ((V)(7D)))), Arr(Call(nn_565, V.Undef, ((V)(1.25)), ((V)(12D))), Call(nn_565, V.Undef, ((V)(1.3)), ((V)(11D))), Call(nn_565, V.Undef, ((V)(1.25)), ((V)(9.6))), Call(nn_565, V.Undef, ((V)(1.35)), ((V)(8.2))), Call(nn_565, V.Undef, ((V)(1.3)), ((V)(7D)))), ((V)(0.3)), ((V)(1D)));
Call(on_464, V.Undef, SH_475, Arr(RB_566, HL_567, SC_568, CK_569));
}
CD_476 = Call(at_49, V.Undef, o_463, Arr(((V)((-3D))), ((V)(0.8)), ((V)((-15D)))), ((V)("#3a3b40")));
if (Truthy(CD_476)) {
V LD_657 = default;
LD_657 = Call(dec_44, V.Undef, ((V)("#d9443a")));
Invoke(LD_657, "poly", Call(elP_45, V.Undef, Arr(((V)((-3D))), ((V)(1.4)), ((V)((-15D)))), X3_39, Z3_41, ((V)(0.5)), ((V)(0.5)), ((V)(8D))), Y3_40);
Call(on_464, V.Undef, CD_476, Arr(Call(box_11, V.Undef, ((V)((-3D))), ((V)(0D)), ((V)((-15D))), ((V)(2.2)), ((V)(1.4)), ((V)(3.6)), ((V)("#f2efe6")), Call(PL_27, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("yaw", ((V)(0.785))).V)), LD_657));
}
return default;
}, 3, "", true)));
Set(N_16, "arc24", Call(ext_50, V.Undef, ((V)("arc22")), Fn((V _arrowThis667, int _argc658, V o_664, V on_665, V R_666, V _a663, V[] _rest659) => {
V MB_668 = default;
double BX_669 = 0;
double BZ_670 = 0;
double DX_671 = 0;
double DZ_672 = 0;
double DY_673 = 0;
V bez_674 = default;
V BS_675 = default;
V HB_676 = default;
V DM_677 = default;
V CD_678 = default;
MB_668 = ((V)("#f4f1ec"));
BX_669 = (-40D);
BZ_670 = (-8D);
DX_671 = 30D;
DZ_672 = 8D;
DY_673 = 92D;
bez_674 = Fn((V _arrowThis686, int _argc679, V t_685, V _a682, V _a683, V _a684, V[] _rest680) => {
V Q_687 = default;
double u_688 = 0;
Q_687 = Arr(Arr(((V)(BX_669)), ((V)(12D)), ((V)(BZ_670))), Arr(((V)(BX_669)), ((V)(156D)), ((V)(BZ_670))), Arr(((V)(DX_671)), ((V)(158D)), ((V)(DZ_672))), Arr(((V)(DX_671)), ((V)((DY_673 + 14D))), ((V)(DZ_672))));
u_688 = (1D - ToNum(t_685));
return Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis696, int _argc689, V k_695, V _a692, V _a693, V _a694, V[] _rest690) => {
return ((V)(((((((u_688 * u_688) * u_688) * ToNum(GetK(GetIdx(Q_687, 0D), k_695))) + ((((3D * u_688) * u_688) * ToNum(t_685)) * ToNum(GetK(GetIdx(Q_687, 1D), k_695)))) + ((((3D * u_688) * ToNum(t_685)) * ToNum(t_685)) * ToNum(GetK(GetIdx(Q_687, 2D), k_695)))) + (((ToNum(t_685) * ToNum(t_685)) * ToNum(t_685)) * ToNum(GetK(GetIdx(Q_687, 3D), k_695))))));
}, 1, "", true));
return default;
}, 1, "", true);
BS_675 = Call(at_49, V.Undef, o_664, Arr(((V)((BX_669 + 8D))), ((V)(5D)), ((V)(BZ_670))), MB_668);
if (Truthy(BS_675)) {
V V1_697 = default;
V V2_698 = default;
double h_699 = 0;
V vn_700 = default;
V FZ_701 = default;
V BK_702 = default;
V FX_703 = default;
V FXm_704 = default;
V TPf_705 = default;
V SP_706 = default;
V1_697 = Call(dec_44, V.Undef, ((V)("#9d958a")), NewObj(1).Put("op", ((V)(0.7))).V);
V2_698 = Call(dec_44, V.Undef, ((V)("#c2bbb0")), NewObj(1).Put("op", ((V)(0.6))).V);
h_699 = 13D;
vn_700 = Fn((V _arrowThis723, int _argc707, V D_713, V f_714, V n_715, V u0_716, V[] _rest708) => {
V v0_717 = default;
V u1_718 = default;
V v1_719 = default;
V w_720 = default;
V amp_721 = default;
V ph_722 = default;
v0_717 = (_argc707 > 4 ? _rest708[0] : V.Undef);
u1_718 = (_argc707 > 5 ? _rest708[1] : V.Undef);
v1_719 = (_argc707 > 6 ? _rest708[2] : V.Undef);
w_720 = (_argc707 > 7 ? _rest708[3] : V.Undef);
amp_721 = (_argc707 > 8 ? _rest708[4] : V.Undef);
ph_722 = (_argc707 > 9 ? _rest708[5] : V.Undef);
return Invoke(D_713, "line", Call(wv_43, V.Undef, ((V)(14D)), Fn((V _arrowThis731, int _argc724, V t_730, V _a727, V _a728, V _a729, V[] _rest725) => {
return Call(f_714, V.Undef, Add(Add(u0_716, ((V)(((ToNum(u1_718) - ToNum(u0_716)) * ToNum(t_730))))), ((V)(((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_730) * 9D))), ph_722))) * ToNum(amp_721)) * 0.4)))), Add(Add(v0_717, ((V)(((ToNum(v1_719) - ToNum(v0_717)) * ToNum(t_730))))), ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_730) * 6.3))), ph_722))) * ToNum(amp_721))))));
}, 1, "", true)), n_715, w_720, ((V)(1D)));
}, 10, "", true);
FZ_701 = Fn((V _arrowThis740, int _argc732, V u_738, V v_739, V _a736, V _a737, V[] _rest733) => {
return Arr(Add(((V)(BX_669)), u_738), v_739, ((V)((BZ_670 + h_699))));
}, 2, "", true);
BK_702 = Fn((V _arrowThis749, int _argc741, V u_747, V v_748, V _a745, V _a746, V[] _rest742) => {
return Arr(((V)((BX_669 - ToNum(u_747)))), v_748, ((V)((BZ_670 - h_699))));
}, 2, "", true);
FX_703 = Fn((V _arrowThis758, int _argc750, V u_756, V v_757, V _a754, V _a755, V[] _rest751) => {
return Arr(((V)((BX_669 + h_699))), v_757, ((V)((BZ_670 - ToNum(u_756)))));
}, 2, "", true);
FXm_704 = Fn((V _arrowThis767, int _argc759, V u_765, V v_766, V _a763, V _a764, V[] _rest760) => {
return Arr(((V)((BX_669 - h_699))), v_766, Add(((V)(BZ_670)), u_765));
}, 2, "", true);
TPf_705 = Fn((V _arrowThis776, int _argc768, V u_774, V v_775, V _a772, V _a773, V[] _rest769) => {
return Arr(Add(((V)(BX_669)), u_774), ((V)(11D)), Add(((V)(BZ_670)), v_775));
}, 2, "", true);
Call(vn_700, V.Undef, V1_697, FZ_701, Z3_41, ((V)((-10.4))), ((V)(9.4)), ((V)(10.4)), ((V)(2D)), ((V)(0.42)), ((V)(0.8)), ((V)(1D)));
Call(vn_700, V.Undef, V2_698, FZ_701, Z3_41, ((V)((-3D))), ((V)(7D)), ((V)(6D)), ((V)(0.8)), ((V)(0.22)), ((V)(0.6)), ((V)(2D)));
Call(vn_700, V.Undef, V2_698, FZ_701, Z3_41, ((V)(2D)), ((V)(9.6)), ((V)(10.4)), ((V)(6D)), ((V)(0.18)), ((V)(0.5)), ((V)(3D)));
Call(vn_700, V.Undef, V1_697, FX_703, X3_39, ((V)((-10.4))), ((V)(2D)), ((V)(10.4)), ((V)(9.4)), ((V)(0.4)), ((V)(0.8)), ((V)(4D)));
Call(vn_700, V.Undef, V2_698, FX_703, X3_39, ((V)((-4D))), ((V)(3.5)), ((V)(4D)), ((V)(1D)), ((V)(0.2)), ((V)(0.5)), ((V)(5D)));
Call(vn_700, V.Undef, V1_697, FXm_704, Call(mul_36, V.Undef, X3_39, ((V)((-1D)))), ((V)((-10.4))), ((V)(6D)), ((V)(10.4)), ((V)(3D)), ((V)(0.35)), ((V)(0.7)), ((V)(6D)));
Call(vn_700, V.Undef, V1_697, BK_702, Call(mul_36, V.Undef, Z3_41, ((V)((-1D)))), ((V)((-10.4))), ((V)(3D)), ((V)(10.4)), ((V)(9D)), ((V)(0.35)), ((V)(0.7)), ((V)(7D)));
Call(vn_700, V.Undef, V1_697, TPf_705, Y3_40, ((V)((-10.4))), ((V)(6D)), ((V)(10.4)), ((V)((-9D))), ((V)(0.3)), ((V)(0.8)), ((V)(8D)));
Call(vn_700, V.Undef, V2_698, TPf_705, Y3_40, ((V)((-8D))), ((V)((-10D))), ((V)(4D)), ((V)(10D)), ((V)(0.18)), ((V)(0.6)), ((V)(9D)));
Call(vn_700, V.Undef, V2_698, TPf_705, Y3_40, ((V)(3D)), ((V)(10D)), ((V)(10D)), ((V)((-2D))), ((V)(0.16)), ((V)(0.5)), ((V)(10D)));
SP_706 = Call(dec_44, V.Undef, ((V)("#b7afa2")), NewObj(1).Put("op", ((V)(0.5))).V);
Call(rep_28, V.Undef, ((V)(14D)), Fn((V _arrowThis783, int _argc777, V _a779, V _a780, V _a781, V _a782, V[] _rest778) => {
return Call(spot_46, V.Undef, SP_706, Arr(((V)((BX_669 + ((ToNum(Call(R_666, V.Undef)) - 0.5) * 20D)))), ((V)(11D)), ((V)((BZ_670 + ((ToNum(Call(R_666, V.Undef)) - 0.5) * 20D))))), Y3_40, ((V)((0.3 + (ToNum(Call(R_666, V.Undef)) * 0.5)))), ((V)((0.2 + (ToNum(Call(R_666, V.Undef)) * 0.3)))), ((V)((ToNum(Call(R_666, V.Undef)) * 3D))), ((V)(6D)));
}, 0, "", true));
Call(on_665, V.Undef, BS_675, Arr(V2_698, V1_697, SP_706));
}
HB_676 = Call(at_49, V.Undef, o_664, Arr(((V)((BX_669 + 2.6))), ((V)(12.6)), ((V)(BZ_670))), CH_19);
if (Truthy(HB_676)) {
V KN_784 = default;
KN_784 = Call(dec_44, V.Undef, ((V)("#8e989f")), NewObj(1).Put("op", ((V)(0.65))).V);
Call(rep_28, V.Undef, ((V)(18D)), Fn((V _arrowThis792, int _argc785, V i_791, V _a788, V _a789, V _a790, V[] _rest786) => {
double a_793 = 0;
a_793 = (((ToNum(i_791) / 18D) * 2D) * PI_17);
Invoke(KN_784, "line", Arr(Arr(((V)((BX_669 + (FdLibm.Cos(a_793) * 2.83)))), ((V)(11.5)), ((V)((BZ_670 + (FdLibm.Sin(a_793) * 2.83))))), Arr(((V)((BX_669 + (FdLibm.Cos(a_793) * 2.83)))), ((V)(14D)), ((V)((BZ_670 + (FdLibm.Sin(a_793) * 2.83)))))), Call(cN_42, V.Undef, ((V)(a_793))), ((V)(0.22)));
return default;
}, 1, "", true));
Call(on_665, V.Undef, HB_676, Arr(KN_784));
}
Invoke(Arr(((V)(0.24)), ((V)(0.52)), ((V)(0.8))), "forEach", Fn((V _arrowThis801, int _argc794, V t_800, V _a797, V _a798, V _a799, V[] _rest795) => {
V p_802 = default;
V d_803 = default;
V S_804 = default;
p_802 = Call(bez_674, V.Undef, t_800);
d_803 = Call(nz_38, V.Undef, Call(sub_35, V.Undef, Call(bez_674, V.Undef, Add(t_800, ((V)(0.01)))), p_802));
S_804 = Call(at_49, V.Undef, o_664, p_802, CH_19, ((V)(0.4)));
if (Truthy(S_804)) {
Call(on_665, V.Undef, S_804, Arr(Call(rod_22, V.Undef, Call(add_34, V.Undef, p_802, Call(mul_36, V.Undef, d_803, ((V)((-1.1))))), Call(add_34, V.Undef, p_802, Call(mul_36, V.Undef, d_803, ((V)(1.1)))), ((V)(1.75)), ((V)("#b4bec5")), Call(M__24, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(rod_22, V.Undef, Call(add_34, V.Undef, p_802, Call(mul_36, V.Undef, d_803, ((V)((-1.5))))), Call(add_34, V.Undef, p_802, Call(mul_36, V.Undef, d_803, ((V)((-1.1))))), ((V)(1.5)), ((V)("#8e989f")), Call(M__24, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).V))));
}
return default;
}, 1, "", true));
DM_677 = Call(at_49, V.Undef, o_664, Arr(((V)((DX_671 + 11D))), ((V)((DY_673 + 2D))), ((V)(DZ_672))), CH_19);
if (Truthy(DM_677)) {
V pf_805 = default;
V rr_806 = default;
V sl_807 = default;
V pt_808 = default;
V nn_809 = default;
V H1_810 = default;
V S1_811 = default;
V RF_812 = default;
V RK_813 = default;
pf_805 = Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(4D)), ((V)(0.96))), Arr(((V)(8D)), ((V)(0.8))), Arr(((V)(11D)), ((V)(0.55))), Arr(((V)(13D)), ((V)(0.25))), Arr(((V)(14D)), ((V)(0.08))));
rr_806 = Fn((V _arrowThis821, int _argc814, V y_820, V _a817, V _a818, V _a819, V[] _rest815) => {
{
double i_822 = 0;
i_822 = 0D;
while (true) {
if (!((i_822 < 5D))) break;
if (Le(y_820, GetIdx(GetIdx(pf_805, (i_822 + 1D)), 0D))) {
V y0_824 = default;
V a_825 = default;
V y1_826 = default;
V b_827 = default;
{ V _t828 = GetIdx(pf_805, i_822);
{ V _t829 = ListOf(_t828);
{ V _t830 = GetIdx(_t829, 0D);
y0_824 = _t830; }
{ V _t831 = GetIdx(_t829, 1D);
a_825 = _t831; }
} }
{ V _t832 = GetIdx(pf_805, (i_822 + 1D));
{ V _t833 = ListOf(_t832);
{ V _t834 = GetIdx(_t833, 0D);
y1_826 = _t834; }
{ V _t835 = GetIdx(_t833, 1D);
b_827 = _t835; }
} }
return ((V)((14D * ToNum(Add(a_825, ((V)((((ToNum(b_827) - ToNum(a_825)) * (ToNum(y_820) - ToNum(y0_824))) / (ToNum(y1_826) - ToNum(y0_824))))))))));
}
i_822++;
}
}
return ((V)(1D));
return default;
}, 1, "", true);
sl_807 = Fn((V _arrowThis843, int _argc836, V y_842, V _a839, V _a840, V _a841, V[] _rest837) => {
return ((V)(((ToNum(Call(rr_806, V.Undef, ((V)(Min(14D, ToNum(Add(y_842, ((V)(0.2))))))))) - ToNum(Call(rr_806, V.Undef, ((V)(Max(0D, (ToNum(y_842) - 0.2))))))) / 0.4)));
}, 1, "", true);
pt_808 = Fn((V _arrowThis852, int _argc844, V a_850, V y_851, V _a848, V _a849, V[] _rest845) => {
return Arr(((V)((DX_671 + ((FdLibm.Cos(ToNum(a_850)) * ToNum(Call(rr_806, V.Undef, y_851))) * 1.004)))), Add(((V)(DY_673)), y_851), ((V)((DZ_672 + ((FdLibm.Sin(ToNum(a_850)) * ToNum(Call(rr_806, V.Undef, y_851))) * 1.004)))));
}, 2, "", true);
nn_809 = Fn((V _arrowThis861, int _argc853, V a_859, V y_860, V _a857, V _a858, V[] _rest854) => {
return Call(nz_38, V.Undef, Arr(((V)(FdLibm.Cos(ToNum(a_859)))), ((V)((-ToNum(Call(sl_807, V.Undef, y_860))))), ((V)(FdLibm.Sin(ToNum(a_859))))));
}, 2, "", true);
H1_810 = Call(dec_44, V.Undef, ((V)("#30353a")), NewObj(1).Put("op", ((V)(0.85))).V);
Call(rep_28, V.Undef, ((V)(18D)), Fn((V _arrowThis869, int _argc862, V i_868, V _a865, V _a866, V _a867, V[] _rest863) => {
double a_870 = 0;
V n_871 = default;
V u_872 = default;
V v_873 = default;
a_870 = (((ToNum(i_868) / 18D) * 2D) * PI_17);
n_871 = Call(nn_809, V.Undef, ((V)(a_870)), ((V)(9.6)));
u_872 = Arr(((V)((-FdLibm.Sin(a_870)))), ((V)(0D)), ((V)(FdLibm.Cos(a_870))));
v_873 = Call(nz_38, V.Undef, Call(cr_37, V.Undef, n_871, u_872));
Invoke(H1_810, "poly", Call(elP_45, V.Undef, Call(pt_808, V.Undef, ((V)(a_870)), ((V)(9.6))), u_872, v_873, ((V)(0.5)), ((V)(0.5)), ((V)(8D))), n_871);
return default;
}, 1, "", true));
S1_811 = Call(dec_44, V.Undef, ((V)("#7d878e")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(S1_811, "line", Call(wv_43, V.Undef, ((V)(36D)), Fn((V _arrowThis881, int _argc874, V t_880, V _a877, V _a878, V _a879, V[] _rest875) => {
return Call(pt_808, V.Undef, ((V)(((ToNum(t_880) * 2D) * PI_17))), ((V)(3.2)));
}, 1, "", true)), Call(wv_43, V.Undef, ((V)(36D)), Fn((V _arrowThis889, int _argc882, V t_888, V _a885, V _a886, V _a887, V[] _rest883) => {
return Call(nn_809, V.Undef, ((V)(((ToNum(t_888) * 2D) * PI_17))), ((V)(3.2)));
}, 1, "", true)), ((V)(0.3)));
RF_812 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.7))).V);
RK_813 = Call(dec_44, V.Undef, ((V)("#5d666d")), NewObj(1).Put("op", ((V)(0.32))).V);
Invoke(Arr(Arr(((V)(2.5)), ((V)(1.6)), RF_812), Arr(((V)(1D)), ((V)(2.4)), RK_813)), "forEach", Fn((V _arrowThis903, int _argc890, V _a892, V _a893, V _a894, V _a895, V[] _rest891) => {
V Y_904 = default;
V a_898 = default;
V w_900 = default;
V D_902 = default;
{ V _t896 = ListOf(_a892);
{ V _t897 = GetIdx(_t896, 0D);
a_898 = _t897; }
{ V _t899 = GetIdx(_t896, 1D);
w_900 = _t899; }
{ V _t901 = GetIdx(_t896, 2D);
D_902 = _t901; }
}
Y_904 = Call(wv_43, V.Undef, ((V)(10D)), Fn((V _arrowThis912, int _argc905, V t_911, V _a908, V _a909, V _a910, V[] _rest906) => {
return ((V)((0.8 + (ToNum(t_911) * 10.6))));
}, 1, "", true));
Invoke(D_902, "line", Invoke(Y_904, "map", Fn((V _arrowThis920, int _argc913, V y_919, V _a916, V _a917, V _a918, V[] _rest914) => {
return Call(pt_808, V.Undef, a_898, y_919);
}, 1, "", true)), Invoke(Y_904, "map", Fn((V _arrowThis928, int _argc921, V y_927, V _a924, V _a925, V _a926, V[] _rest922) => {
return Call(nn_809, V.Undef, a_898, y_927);
}, 1, "", true)), w_900, ((V)(1D)));
return default;
}, 1, "", true));
Call(on_665, V.Undef, DM_677, Arr(S1_811, RK_813, RF_812, H1_810));
}
CD_678 = Call(at_49, V.Undef, o_664, Arr(((V)((BX_669 - 7D))), ((V)(0.6)), ((V)((BZ_670 - 21D)))), ((V)("#3a3b40")));
if (Truthy(CD_678)) {
V LD_929 = default;
V RG2_930 = default;
LD_929 = Call(dec_44, V.Undef, ((V)("#ff6a4a")), NewObj(1).Put("emit", ((V)(1D))).V);
Invoke(LD_929, "poly", Call(elP_45, V.Undef, Arr(((V)((BX_669 - 8.4))), ((V)(1.62)), ((V)((BZ_670 - 25.6)))), X3_39, Z3_41, ((V)(0.5)), ((V)(0.5)), ((V)(8D))), Y3_40);
RG2_930 = Call(dec_44, V.Undef, ((V)("#5a5c62")), NewObj(1).Put("op", ((V)(0.8))).V);
Call(ringY_51, V.Undef, RG2_930, ((V)((BX_669 - 8.4))), ((V)((BZ_670 - 25.6))), ((V)(1.8)), ((V)(1.62)), ((V)(0.25)), ((V)(20D)));
Call(on_665, V.Undef, CD_678, Arr(Call(cyl_12, V.Undef, ((V)((BX_669 - 8.4))), ((V)(0D)), ((V)((BZ_670 - 25.6))), ((V)(2.6)), ((V)(1.6)), ((V)("#2a2b30")), Call(PL_27, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), RG2_930, LD_929));
}
return default;
}, 3, "", true)));
ST62_53 = Arr(Arr(((V)(11D)), ((V)(15D)), ((V)(0.6))), Arr(((V)(13.5)), ((V)(19D)), ((V)((-1D)))), Arr(((V)(9D)), ((V)(13D)), ((V)(1.2))), Arr(((V)(12D)), ((V)(21D)), ((V)(0D))), Arr(((V)(8D)), ((V)(12D)), ((V)((-0.6)))), Arr(((V)(10.5)), ((V)(17D)), ((V)(0.5))));
Set(N_16, "alab24", Call(ext_50, V.Undef, ((V)("alab22")), Fn((V _arrowThis940, int _argc931, V o_937, V on_938, V R_939, V _a936, V[] _rest932) => {
V BRZ_941 = default;
V AL_942 = default;
V y_943 = default;
V L_944 = default;
V pf_945 = default;
V BS_946 = default;
BRZ_941 = ((V)("#7a5534"));
AL_942 = Arr(((V)("#fbe8c8")), ((V)("#f7dcb6")), ((V)("#fdeed6")));
y_943 = ((V)(4.6));
L_944 = Invoke(ST62_53, "map", Fn((V _arrowThis960, int _argc947, V _a949, V _a950, V _a951, V _a952, V[] _rest948) => {
V s_961 = default;
V r_955 = default;
V h_957 = default;
V dx_959 = default;
{ V _t953 = ListOf(_a949);
{ V _t954 = GetIdx(_t953, 0D);
r_955 = _t954; }
{ V _t956 = GetIdx(_t953, 1D);
h_957 = _t956; }
{ V _t958 = GetIdx(_t953, 2D);
dx_959 = _t958; }
}
s_961 = NewObj(4).Put("r", r_955).Put("h", h_957).Put("dx", dx_959).Put("y", y_943).V;
y_943 = Add(y_943, Add(h_957, ((V)(2.4))));
return s_961;
return default;
}, 1, "", true));
pf_945 = Fn((V _arrowThis969, int _argc962, V t_968, V _a965, V _a966, V _a967, V[] _rest963) => {
V Kk_970 = default;
Kk_970 = Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(0.18)), ((V)(0.9))), Arr(((V)(0.5)), ((V)(1D))), Arr(((V)(0.82)), ((V)(0.9))), Arr(((V)(1D)), ((V)(0.5))));
{
double i_971 = 0;
i_971 = 0D;
while (true) {
if (!((i_971 < 4D))) break;
if (Le(t_968, GetIdx(GetIdx(Kk_970, (i_971 + 1D)), 0D))) {
return Add(GetIdx(GetIdx(Kk_970, i_971), 1D), ((V)((((ToNum(GetIdx(GetIdx(Kk_970, (i_971 + 1D)), 1D)) - ToNum(GetIdx(GetIdx(Kk_970, i_971), 1D))) * (ToNum(t_968) - ToNum(GetIdx(GetIdx(Kk_970, i_971), 0D)))) / (ToNum(GetIdx(GetIdx(Kk_970, (i_971 + 1D)), 0D)) - ToNum(GetIdx(GetIdx(Kk_970, i_971), 0D)))))));
}
i_971++;
}
}
return ((V)(0.5));
return default;
}, 1, "", true);
Invoke(L_944, "forEach", Fn((V _arrowThis981, int _argc973, V s_979, V i_980, V _a977, V _a978, V[] _rest974) => {
V S_982 = default;
V pt_983 = default;
V nn_984 = default;
V V1_985 = default;
V V2_986 = default;
V V3_987 = default;
V SP_988 = default;
S_982 = Call(at_49, V.Undef, o_937, Arr(Add(Get(s_979, "dx"), ((V)((ToNum(Get(s_979, "r")) * 0.6)))), Add(Get(s_979, "y"), ((V)((ToNum(Get(s_979, "h")) / 2D)))), ((V)(0D))), GetIdx(AL_942, (ToNum(i_980) % 3D)));
if (!(Truthy(S_982))) {
return default;
}
pt_983 = Fn((V _arrowThis997, int _argc989, V a_995, V t_996, V _a993, V _a994, V[] _rest990) => {
double f_998 = 0;
f_998 = (ToNum(Call(pf_945, V.Undef, t_996)) * 1.01);
return Arr(Add(Get(s_979, "dx"), ((V)(((FdLibm.Cos(ToNum(a_995)) * ToNum(Get(s_979, "r"))) * f_998)))), Add(Get(s_979, "y"), ((V)((ToNum(Get(s_979, "h")) * ToNum(t_996))))), ((V)((((FdLibm.Sin(ToNum(a_995)) * ToNum(Get(s_979, "r"))) * 0.86) * f_998))));
return default;
}, 2, "", true);
nn_984 = Fn((V _arrowThis1006, int _argc999, V a_1005, V _a1002, V _a1003, V _a1004, V[] _rest1000) => {
return Call(nz_38, V.Undef, Arr(((V)((FdLibm.Cos(ToNum(a_1005)) / ToNum(Get(s_979, "r"))))), ((V)(0D)), ((V)((FdLibm.Sin(ToNum(a_1005)) / (ToNum(Get(s_979, "r")) * 0.86))))));
}, 1, "", true);
V1_985 = Call(dec_44, V.Undef, ((V)("#d79a66")), NewObj(2).Put("op", ((V)(0.5))).Put("emit", ((V)(1D))).V);
V2_986 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(2).Put("op", ((V)(0.75))).Put("emit", ((V)(1D))).V);
V3_987 = Call(dec_44, V.Undef, ((V)("#e9c89c")), NewObj(2).Put("op", ((V)(0.4))).Put("emit", ((V)(1D))).V);
Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis1013, int _argc1007, V _a1009, V _a1010, V _a1011, V _a1012, V[] _rest1008) => {
double a_1014 = 0;
double t_1015 = 0;
a_1014 = ((ToNum(Call(R_939, V.Undef)) * 2D) * PI_17);
t_1015 = (0.18 + (ToNum(Call(R_939, V.Undef)) * 0.64));
Call(spot_46, V.Undef, V3_987, Call(pt_983, V.Undef, ((V)(a_1014)), ((V)(t_1015))), Call(nn_984, V.Undef, ((V)(a_1014))), ((V)((0.8 + (ToNum(Call(R_939, V.Undef)) * 1.6)))), ((V)((0.4 + (ToNum(Call(R_939, V.Undef)) * 0.8)))), ((V)(((ToNum(Call(R_939, V.Undef)) - 0.5) * 0.8))));
return default;
}, 0, "", true));
Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis1023, int _argc1016, V k_1022, V _a1019, V _a1020, V _a1021, V[] _rest1017) => {
double a0_1024 = 0;
double da_1025 = 0;
double t0_1026 = 0;
double amp_1027 = 0;
double ph_1028 = 0;
V D_1029 = default;
V T_1030 = default;
a0_1024 = ((ToNum(Call(R_939, V.Undef)) * 2D) * PI_17);
da_1025 = (1.2 + (ToNum(Call(R_939, V.Undef)) * 1.8));
t0_1026 = (0.22 + (ToNum(Call(R_939, V.Undef)) * 0.56));
amp_1027 = (0.06 + (ToNum(Call(R_939, V.Undef)) * 0.12));
ph_1028 = (ToNum(Call(R_939, V.Undef)) * 6D);
D_1029 = (NumTruthy((ToNum(k_1022) % 2D)) ? V2_986 : V1_985);
T_1030 = Call(wv_43, V.Undef, ((V)(16D)), Fn((V _arrowThis1038, int _argc1031, V u_1037, V _a1034, V _a1035, V _a1036, V[] _rest1032) => {
return Arr(((V)((a0_1024 + (da_1025 * ToNum(u_1037))))), ((V)(Min(0.88, Max(0.12, ((t0_1026 + (amp_1027 * FdLibm.Sin(((ToNum(u_1037) * 7D) + ph_1028)))) + (0.05 * FdLibm.Sin(((ToNum(u_1037) * 19D) + ph_1028)))))))));
}, 1, "", true));
Invoke(D_1029, "line", Invoke(T_1030, "map", Fn((V _arrowThis1050, int _argc1039, V _a1041, V _a1042, V _a1043, V _a1044, V[] _rest1040) => {
V a_1047 = default;
V t_1049 = default;
{ V _t1045 = ListOf(_a1041);
{ V _t1046 = GetIdx(_t1045, 0D);
a_1047 = _t1046; }
{ V _t1048 = GetIdx(_t1045, 1D);
t_1049 = _t1048; }
}
return Call(pt_983, V.Undef, a_1047, t_1049);
}, 1, "", true)), Invoke(T_1030, "map", Fn((V _arrowThis1060, int _argc1051, V _a1053, V _a1054, V _a1055, V _a1056, V[] _rest1052) => {
V a_1059 = default;
{ V _t1057 = ListOf(_a1053);
{ V _t1058 = GetIdx(_t1057, 0D);
a_1059 = _t1058; }
}
return Call(nn_984, V.Undef, a_1059);
}, 1, "", true)), ((V)((NumTruthy((ToNum(k_1022) % 2D)) ? 0.22 : 0.42))), ((V)(1D)));
return default;
}, 1, "", true));
Call(on_938, V.Undef, S_982, Arr(V3_987, V1_985, V2_986));
SP_988 = Call(at_49, V.Undef, o_937, Arr(((V)(((ToNum(Get(s_979, "dx")) * 0.5) + 3.1))), Add(Add(Get(s_979, "y"), Get(s_979, "h")), ((V)(1.2))), ((V)(0D))), BRZ_941);
if (Truthy(SP_988)) {
V G_1061 = default;
V HL_1062 = default;
G_1061 = Call(dec_44, V.Undef, ((V)("#3e2a1a")), NewObj(1).Put("op", ((V)(0.75))).V);
HL_1062 = Call(dec_44, V.Undef, ((V)("#c9925a")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(ringC_52, V.Undef, G_1061, ((V)((ToNum(Get(s_979, "dx")) * 0.5))), ((V)(0D)), ((V)(3.43)), Add(Add(Get(s_979, "y"), Get(s_979, "h")), ((V)(1.2))), ((V)(0.32)), ((V)(24D)));
Call(ringC_52, V.Undef, HL_1062, ((V)((ToNum(Get(s_979, "dx")) * 0.5))), ((V)(0D)), ((V)(3.43)), Add(Add(Get(s_979, "y"), Get(s_979, "h")), ((V)(0.5))), ((V)(0.2)), ((V)(24D)));
Call(on_938, V.Undef, SP_988, Arr(G_1061, HL_1062));
}
return default;
}, 2, "", true));
BS_946 = Call(at_49, V.Undef, o_937, Arr(((V)(11D)), ((V)(2D)), ((V)(0D))), BRZ_941);
if (Truthy(BS_946)) {
V PA_1063 = default;
V EN_1064 = default;
V HL_1065 = default;
PA_1063 = Call(dec_44, V.Undef, ((V)("#6f9a80")), NewObj(1).Put("op", ((V)(0.5))).V);
EN_1064 = Call(dec_44, V.Undef, ((V)("#3e2a1a")), NewObj(1).Put("op", ((V)(0.7))).V);
HL_1065 = Call(dec_44, V.Undef, ((V)("#c9925a")), NewObj(1).Put("op", ((V)(0.55))).V);
Call(rep_28, V.Undef, ((V)(12D)), Fn((V _arrowThis1072, int _argc1066, V _a1068, V _a1069, V _a1070, V _a1071, V[] _rest1067) => {
double a_1073 = 0;
double r_1074 = 0;
a_1073 = ((ToNum(Call(R_939, V.Undef)) * 2D) * PI_17);
r_1074 = (4D + (ToNum(Call(R_939, V.Undef)) * 7.6));
Call(spot_46, V.Undef, PA_1063, Arr(((V)((FdLibm.Cos(a_1073) * r_1074))), ((V)(4.6)), ((V)((FdLibm.Sin(a_1073) * r_1074)))), Y3_40, ((V)((0.4 + (ToNum(Call(R_939, V.Undef)) * 0.9)))), ((V)((0.3 + (ToNum(Call(R_939, V.Undef)) * 0.5)))), ((V)((ToNum(Call(R_939, V.Undef)) * 3D))));
return default;
}, 0, "", true));
Call(rep_28, V.Undef, ((V)(10D)), Fn((V _arrowThis1081, int _argc1075, V _a1077, V _a1078, V _a1079, V _a1080, V[] _rest1076) => {
double a_1082 = 0;
a_1082 = ((ToNum(Call(R_939, V.Undef)) * 2D) * PI_17);
Call(spot_46, V.Undef, PA_1063, Arr(((V)((FdLibm.Cos(a_1082) * 13.4))), ((V)((0.8 + (ToNum(Call(R_939, V.Undef)) * 3D)))), ((V)((FdLibm.Sin(a_1082) * 13.4)))), Call(nz_38, V.Undef, Arr(((V)(FdLibm.Cos(a_1082))), ((V)(0.3)), ((V)(FdLibm.Sin(a_1082))))), ((V)((0.5 + (ToNum(Call(R_939, V.Undef)) * 0.8)))), ((V)((0.3 + (ToNum(Call(R_939, V.Undef)) * 0.4)))), ((V)(0D)));
return default;
}, 0, "", true));
Call(ringY_51, V.Undef, EN_1064, ((V)(0D)), ((V)(0D)), ((V)(11.6)), ((V)(4.6)), ((V)(0.3)), ((V)(48D)));
Call(ringY_51, V.Undef, EN_1064, ((V)(0D)), ((V)(0D)), ((V)(10.4)), ((V)(4.6)), ((V)(0.2)), ((V)(48D)));
Call(ringY_51, V.Undef, HL_1065, ((V)(0D)), ((V)(0D)), ((V)(12.2)), ((V)(4.6)), ((V)(0.22)), ((V)(48D)));
Call(on_938, V.Undef, BS_946, Arr(PA_1063, EN_1064, HL_1065));
}
return default;
}, 3, "", true)));
Set(N_16, "bio24", Call(ext_50, V.Undef, ((V)("bio22")), Fn((V _arrowThis1092, int _argc1083, V o_1089, V on_1090, V R_1091, V _a1088, V[] _rest1084) => {
V POT_1093 = default;
V PT_1094 = default;
V RB_1095 = default;
V RS_1096 = default;
V GL_1097 = default;
V PO_1098 = default;
V RIB_1099 = default;
V DR_1100 = default;
V DH_1101 = default;
V CP_1102 = default;
POT_1093 = ((V)("#2b3436"));
PT_1094 = Call(at_49, V.Undef, o_1089, Arr(((V)(14D)), ((V)(8D)), ((V)(0D))), POT_1093);
if (!(Truthy(PT_1094))) {
return default;
}
RB_1095 = Call(dec_44, V.Undef, ((V)("#4a5a5f")), NewObj(1).Put("op", ((V)(0.9))).V);
RS_1096 = Call(dec_44, V.Undef, ((V)("#161c1e")), NewObj(1).Put("op", ((V)(0.8))).V);
GL_1097 = Call(dec_44, V.Undef, ((V)("#5cf2b0")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.9))).V);
PO_1098 = Call(dec_44, V.Undef, ((V)("#1a2022")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(ringC_52, V.Undef, RB_1095, ((V)(0D)), ((V)(0D)), ((V)(15.03)), ((V)(3D)), ((V)(0.6)), ((V)(40D)));
Call(ringC_52, V.Undef, RS_1096, ((V)(0D)), ((V)(0D)), ((V)(15.03)), ((V)(3.7)), ((V)(0.28)), ((V)(40D)));
Call(ringC_52, V.Undef, RB_1095, ((V)(0D)), ((V)(0D)), ((V)(15.03)), ((V)(13.2)), ((V)(0.6)), ((V)(40D)));
Call(ringC_52, V.Undef, RS_1096, ((V)(0D)), ((V)(0D)), ((V)(15.03)), ((V)(12.5)), ((V)(0.28)), ((V)(40D)));
Call(rep_28, V.Undef, ((V)(12D)), Fn((V _arrowThis1110, int _argc1103, V i_1109, V _a1106, V _a1107, V _a1108, V[] _rest1104) => {
double a_1111 = 0;
V c_1112 = default;
V u_1113 = default;
a_1111 = ((((ToNum(i_1109) / 12D) * 2D) * PI_17) + 0.13);
c_1112 = Arr(((V)((FdLibm.Cos(a_1111) * 15.03))), ((V)(8D)), ((V)((FdLibm.Sin(a_1111) * 15.03))));
u_1113 = Arr(((V)((-FdLibm.Sin(a_1111)))), ((V)(0D)), ((V)(FdLibm.Cos(a_1111))));
Invoke(GL_1097, "line", (NumTruthy((ToNum(i_1109) % 2D)) ? Arr(Call(add_34, V.Undef, c_1112, Call(add_34, V.Undef, Call(mul_36, V.Undef, u_1113, ((V)((-1D)))), Arr(((V)(0D)), ((V)((-1.8))), ((V)(0D))))), Call(add_34, V.Undef, c_1112, Arr(((V)(0D)), ((V)(1.8)), ((V)(0D)))), Call(add_34, V.Undef, c_1112, Call(add_34, V.Undef, Call(mul_36, V.Undef, u_1113, ((V)(1D))), Arr(((V)(0D)), ((V)((-1.8))), ((V)(0D)))))) : Arr(Call(add_34, V.Undef, c_1112, Arr(((V)(0D)), ((V)((-1.8))), ((V)(0D)))), Call(add_34, V.Undef, c_1112, Arr(((V)(0D)), ((V)(1.8)), ((V)(0D)))))), Call(cN_42, V.Undef, ((V)(a_1111))), ((V)(0.34)));
if (!(NumTruthy((ToNum(i_1109) % 2D)))) {
Invoke(GL_1097, "line", Arr(Call(add_34, V.Undef, c_1112, Call(add_34, V.Undef, Call(mul_36, V.Undef, u_1113, ((V)((-0.9)))), Arr(((V)(0D)), ((V)(0.3)), ((V)(0D))))), Call(add_34, V.Undef, c_1112, Call(add_34, V.Undef, Call(mul_36, V.Undef, u_1113, ((V)(0.9))), Arr(((V)(0D)), ((V)(0.3)), ((V)(0D)))))), Call(cN_42, V.Undef, ((V)(a_1111))), ((V)(0.3)));
}
return default;
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(40D)), Fn((V _arrowThis1120, int _argc1114, V _a1116, V _a1117, V _a1118, V _a1119, V[] _rest1115) => {
double a_1121 = 0;
double y_1122 = 0;
a_1121 = ((ToNum(Call(R_1091, V.Undef)) * 2D) * PI_17);
y_1122 = (1D + (ToNum(Call(R_1091, V.Undef)) * 14D));
Call(spot_46, V.Undef, PO_1098, Arr(((V)((FdLibm.Cos(a_1121) * 15.03))), ((V)(y_1122)), ((V)((FdLibm.Sin(a_1121) * 15.03)))), Call(cN_42, V.Undef, ((V)(a_1121))), ((V)((0.2 + (ToNum(Call(R_1091, V.Undef)) * 0.35)))), ((V)((0.15 + (ToNum(Call(R_1091, V.Undef)) * 0.2)))), ((V)(0D)), ((V)(6D)));
return default;
}, 0, "", true));
Call(on_1090, V.Undef, PT_1094, Arr(RB_1095, RS_1096, GL_1097, PO_1098));
Call(rep_28, V.Undef, ((V)(16D)), Fn((V _arrowThis1130, int _argc1123, V i_1129, V _a1126, V _a1127, V _a1128, V[] _rest1124) => {
double a_1131 = 0;
double r_1132 = 0;
a_1131 = ((((ToNum(i_1129) / 16D) * 2D) * PI_17) + (ToNum(Call(R_1091, V.Undef)) * 0.2));
r_1132 = (12.4 + (ToNum(Call(R_1091, V.Undef)) * 0.8));
Call(on_1090, V.Undef, PT_1094, Arr(Call(ball_13, V.Undef, ((V)((FdLibm.Cos(a_1131) * r_1132))), ((V)(17.2)), ((V)((FdLibm.Sin(a_1131) * r_1132))), ((V)((1.4 + (ToNum(Call(R_1091, V.Undef)) * 0.7)))), GetIdx(Arr(((V)("#4f8a3e")), ((V)("#6fae5a")), ((V)("#3e7a3a"))), (ToNum(i_1129) % 3D)), NewObj(5).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).Put("mat", ((V)("fab"))).V)), Call(cN_42, V.Undef, ((V)(a_1131))));
return default;
}, 1, "", true));
Invoke(Arr(((V)(0.6)), ((V)(2.3)), ((V)(4.4))), "forEach", Fn((V _arrowThis1141, int _argc1133, V a_1139, V i_1140, V _a1137, V _a1138, V[] _rest1134) => {
double x_1142 = 0;
double z_1143 = 0;
x_1142 = (FdLibm.Cos(ToNum(a_1139)) * 12.6);
z_1143 = (FdLibm.Sin(ToNum(a_1139)) * 12.6);
Call(on_1090, V.Undef, PT_1094, Arr(Call(cyl_12, V.Undef, ((V)(x_1142)), ((V)(17.8)), ((V)(z_1143)), ((V)(0.35)), ((V)((2.4 + (ToNum(i_1140) * 0.4)))), ((V)("#e8fff2")), NewObj(2).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V), Call(ball_13, V.Undef, ((V)(x_1142)), ((V)((19.9 + (ToNum(i_1140) * 0.4)))), ((V)(z_1143)), ((V)((1D + (ToNum(i_1140) * 0.15)))), GetK(Arr(((V)("#7fd8ff")), ((V)("#b48cff")), ((V)("#9affdc"))), i_1140), NewObj(5).Put("sy", ((V)(0.55))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("emit", ((V)(1D))).Put("noOut", ((V)(1D))).V)), Call(cN_42, V.Undef, a_1139));
return default;
}, 2, "", true));
RIB_1099 = Call(dec_44, V.Undef, BR_18, NewObj(1).Put("op", ((V)(0.9))).V);
DR_1100 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.55))).V);
DH_1101 = Call(dec_44, V.Undef, ((V)("#9fe8ff")), NewObj(1).Put("op", ((V)(0.35))).V);
Call(rep_28, V.Undef, ((V)(4D)), Fn((V _arrowThis1151, int _argc1144, V i_1150, V _a1147, V _a1148, V _a1149, V[] _rest1145) => {
double a_1152 = 0;
a_1152 = ((PI_17 / 4D) + ((ToNum(i_1150) * PI_17) / 2D));
Invoke(RIB_1099, "line", Arr(Arr(((V)((FdLibm.Cos(a_1152) * 10.75))), ((V)(17.4)), ((V)((FdLibm.Sin(a_1152) * 10.75)))), Arr(((V)((FdLibm.Cos(a_1152) * 10.75))), ((V)(113D)), ((V)((FdLibm.Sin(a_1152) * 10.75))))), Call(cN_42, V.Undef, ((V)(a_1152))), ((V)(0.8)));
return default;
}, 1, "", true));
Call(ringC_52, V.Undef, RIB_1099, ((V)(0D)), ((V)(0D)), ((V)(10.75)), ((V)(65D)), ((V)(0.9)), ((V)(40D)));
Call(ringC_52, V.Undef, RIB_1099, ((V)(0D)), ((V)(0D)), ((V)(10.75)), ((V)(18D)), ((V)(0.9)), ((V)(40D)));
Call(rep_28, V.Undef, ((V)(36D)), Fn((V _arrowThis1159, int _argc1153, V _a1155, V _a1156, V _a1157, V _a1158, V[] _rest1154) => {
double a_1160 = 0;
double y_1161 = 0;
a_1160 = ((ToNum(Call(R_1091, V.Undef)) * 2D) * PI_17);
y_1161 = (22D + (ToNum(Call(R_1091, V.Undef)) * 88D));
Call(spot_46, V.Undef, DR_1100, Arr(((V)((FdLibm.Cos(a_1160) * 10.66))), ((V)(y_1161)), ((V)((FdLibm.Sin(a_1160) * 10.66)))), Call(cN_42, V.Undef, ((V)(a_1160))), ((V)((0.18 + (ToNum(Call(R_1091, V.Undef)) * 0.25)))), ((V)((0.25 + (ToNum(Call(R_1091, V.Undef)) * 0.35)))), ((V)(0D)), ((V)(6D)));
return default;
}, 0, "", true));
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis1169, int _argc1162, V i_1168, V _a1165, V _a1166, V _a1167, V[] _rest1163) => {
double a_1170 = 0;
a_1170 = (2.2 + (ToNum(i_1168) * 0.12));
Invoke(DH_1101, "line", Arr(Arr(((V)((FdLibm.Cos(a_1170) * 10.66))), ((V)(24D)), ((V)((FdLibm.Sin(a_1170) * 10.66)))), Arr(((V)((FdLibm.Cos(a_1170) * 10.66))), ((V)(106D)), ((V)((FdLibm.Sin(a_1170) * 10.66))))), Call(cN_42, V.Undef, ((V)(a_1170))), ((V)((SEqN(i_1168, 1D) ? 1.4 : 0.4))));
return default;
}, 1, "", true));
Call(on_1090, V.Undef, PT_1094, Arr(DH_1101, RIB_1099, DR_1100));
CP_1102 = Call(at_49, V.Undef, o_1089, Arr(((V)(11.3)), ((V)(114.6)), ((V)(0D))), BR_18, ((V)(0.6)), ((V)(1D)));
if (Truthy(CP_1102)) {
V VT_1171 = default;
VT_1171 = Call(dec_44, V.Undef, ((V)("#3a2a14")), NewObj(1).Put("op", ((V)(0.8))).V);
Call(rep_28, V.Undef, ((V)(24D)), Fn((V _arrowThis1179, int _argc1172, V i_1178, V _a1175, V _a1176, V _a1177, V[] _rest1173) => {
double a_1180 = 0;
a_1180 = (((ToNum(i_1178) / 24D) * 2D) * PI_17);
Invoke(VT_1171, "line", Arr(Arr(((V)((FdLibm.Cos(a_1180) * 11.63))), ((V)(113.9)), ((V)((FdLibm.Sin(a_1180) * 11.63)))), Arr(((V)((FdLibm.Cos(a_1180) * 11.63))), ((V)(115.6)), ((V)((FdLibm.Sin(a_1180) * 11.63))))), Call(cN_42, V.Undef, ((V)(a_1180))), ((V)(0.4)));
return default;
}, 1, "", true));
Call(on_1090, V.Undef, CP_1102, Arr(VT_1171));
}
return default;
}, 3, "", true)));
Set(N_16, "iron24", Call(ext_50, V.Undef, ((V)("iron22")), Fn((V _arrowThis1190, int _argc1181, V o_1187, V on_1188, V R_1189, V _a1186, V[] _rest1182) => {
V IR_1191 = default;
V GL_1192 = default;
double W_1193 = 0;
double Dp_1194 = 0;
double H_1195 = 0;
V edge_1196 = default;
V streak_1197 = default;
V TP_1198 = default;
V SH_1199 = default;
V BK_1200 = default;
V TR_1201 = default;
V FR_1202 = default;
V PH_1203 = default;
V PG_1204 = default;
V PF_1205 = default;
V MT_1206 = default;
IR_1191 = ((V)("#25262a"));
GL_1192 = ((V)("#cfe6ee"));
W_1193 = 118D;
Dp_1194 = 28D;
H_1195 = 56D;
edge_1196 = Fn((V _arrowThis1217, int _argc1207, V y0_1213, V h_1214, V w2_1215, V d2_1216, V[] _rest1208) => {
V E_1218 = default;
E_1218 = Call(dec_44, V.Undef, ((V)("#78c4a8")), NewObj(1).Put("op", ((V)(0.85))).V);
Invoke(Invoke(Invoke(Invoke(E_1218, "poly", Arr(Arr(((V)((-ToNum(w2_1215)))), y0_1213, d2_1216), Arr(w2_1215, y0_1213, d2_1216), Arr(w2_1215, Add(y0_1213, h_1214), d2_1216), Arr(((V)((-ToNum(w2_1215)))), Add(y0_1213, h_1214), d2_1216)), Z3_41), "poly", Arr(Arr(w2_1215, y0_1213, ((V)((-ToNum(d2_1216))))), Arr(((V)((-ToNum(w2_1215)))), y0_1213, ((V)((-ToNum(d2_1216))))), Arr(((V)((-ToNum(w2_1215)))), Add(y0_1213, h_1214), ((V)((-ToNum(d2_1216))))), Arr(w2_1215, Add(y0_1213, h_1214), ((V)((-ToNum(d2_1216)))))), Call(mul_36, V.Undef, Z3_41, ((V)((-1D))))), "poly", Arr(Arr(w2_1215, y0_1213, d2_1216), Arr(w2_1215, y0_1213, ((V)((-ToNum(d2_1216))))), Arr(w2_1215, Add(y0_1213, h_1214), ((V)((-ToNum(d2_1216))))), Arr(w2_1215, Add(y0_1213, h_1214), d2_1216)), X3_39), "poly", Arr(Arr(((V)((-ToNum(w2_1215)))), y0_1213, ((V)((-ToNum(d2_1216))))), Arr(((V)((-ToNum(w2_1215)))), y0_1213, d2_1216), Arr(((V)((-ToNum(w2_1215)))), Add(y0_1213, h_1214), d2_1216), Arr(((V)((-ToNum(w2_1215)))), Add(y0_1213, h_1214), ((V)((-ToNum(d2_1216)))))), Call(mul_36, V.Undef, X3_39, ((V)((-1D)))));
return E_1218;
return default;
}, 4, "", true);
streak_1197 = Fn((V _arrowThis1227, int _argc1219, V y_1225, V d2_1226, V _a1223, V _a1224, V[] _rest1220) => {
V E_1228 = default;
E_1228 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Arr(Arr(((V)((-40D))), ((V)(8D))), Arr(((V)((-24D))), ((V)(3D))), Arr(((V)(26D)), ((V)(6D)))), "forEach", Fn((V _arrowThis1240, int _argc1229, V _a1231, V _a1232, V _a1233, V _a1234, V[] _rest1230) => {
V x_1237 = default;
V wd_1239 = default;
{ V _t1235 = ListOf(_a1231);
{ V _t1236 = GetIdx(_t1235, 0D);
x_1237 = _t1236; }
{ V _t1238 = GetIdx(_t1235, 1D);
wd_1239 = _t1238; }
}
return Invoke(E_1228, "poly", Arr(Arr(x_1237, y_1225, d2_1226), Arr(Add(x_1237, wd_1239), y_1225, d2_1226), Arr(((V)((ToNum(Add(x_1237, wd_1239)) - 12D))), y_1225, ((V)((-ToNum(d2_1226))))), Arr(((V)((ToNum(x_1237) - 12D))), y_1225, ((V)((-ToNum(d2_1226)))))), Y3_40);
}, 1, "", true));
return E_1228;
return default;
}, 2, "", true);
TP_1198 = Call(at_49, V.Undef, o_1187, Arr(((V)(0D)), ((V)((H_1195 + 0.6))), ((V)(0D))), GL_1192);
SH_1199 = Call(at_49, V.Undef, o_1187, Arr(((V)(0D)), ((V)(13.2)), ((V)(0D))), GL_1192);
if (Truthy(TP_1198)) {
Call(on_1188, V.Undef, TP_1198, Arr(Call(edge_1196, V.Undef, ((V)((H_1195 + 0.15))), ((V)(0.9)), ((V)(((W_1193 / 2D) + 1D))), ((V)(((Dp_1194 / 2D) + 1D)))), Call(streak_1197, V.Undef, ((V)((H_1195 + 1.2))), ((V)(((Dp_1194 / 2D) - 0.5))))));
}
if (Truthy(SH_1199)) {
Call(on_1188, V.Undef, SH_1199, Arr(Call(edge_1196, V.Undef, ((V)(12.85)), ((V)(0.7)), ((V)(((W_1193 / 2D) - 2D))), ((V)(((Dp_1194 / 2D) - 2D)))), Call(streak_1197, V.Undef, ((V)(13.7)), ((V)(((Dp_1194 / 2D) - 3D))))));
}
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis1252, int _argc1241, V _a1243, V _a1244, V _a1245, V _a1246, V[] _rest1242) => {
double x_1253 = 0;
double z_1254 = 0;
V L_1255 = default;
V HL_1256 = default;
V sx_1249 = default;
V sz_1251 = default;
{ V _t1247 = ListOf(_a1243);
{ V _t1248 = GetIdx(_t1247, 0D);
sx_1249 = _t1248; }
{ V _t1250 = GetIdx(_t1247, 1D);
sz_1251 = _t1250; }
}
x_1253 = (ToNum(sx_1249) * ((W_1193 / 2D) - 1D));
z_1254 = (ToNum(sz_1251) * ((Dp_1194 / 2D) - 1D));
L_1255 = Call(at_49, V.Undef, o_1187, Arr(((V)(x_1253)), ((V)(30D)), ((V)(z_1254))), IR_1191);
if (!(Truthy(L_1255))) {
return default;
}
HL_1256 = Call(dec_44, V.Undef, ((V)("#6a6d74")), NewObj(1).Put("op", ((V)(0.8))).V);
Invoke(Invoke(HL_1256, "line", Arr(Arr(((V)((x_1253 - 0.45))), ((V)(1.4)), ((V)((z_1254 + 0.9)))), Arr(((V)((x_1253 - 0.45))), ((V)((H_1195 - 2.2))), ((V)((z_1254 + 0.9))))), Z3_41, ((V)(0.25))), "line", Arr(Arr(((V)((x_1253 + 0.9))), ((V)(1.4)), ((V)((z_1254 - 0.45)))), Arr(((V)((x_1253 + 0.9))), ((V)((H_1195 - 2.2))), ((V)((z_1254 - 0.45))))), X3_39, ((V)(0.2)));
Call(on_1188, V.Undef, L_1255, Arr(Call(cyl_12, V.Undef, ((V)(x_1253)), ((V)(0D)), ((V)(z_1254)), ((V)(1.35)), ((V)(1D)), ((V)("#8a8f94")), Call(M__24, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), HL_1256));
return default;
}, 1, "", true));
BK_1200 = Call(at_49, V.Undef, o_1187, Arr(((V)((-21.5))), ((V)(18D)), ((V)(0D))), ((V)("#c9a06a")));
if (Truthy(BK_1200)) {
V r_1257 = default;
V P3_1258 = default;
V A_1259 = default;
V B2_1260 = default;
V TH_1261 = default;
V KN_1262 = default;
r_1257 = Fn((V _arrowThis1270, int _argc1263, V y_1269, V _a1266, V _a1267, V _a1268, V[] _rest1264) => {
return ((V)(((9D * (0.9 + ((0.1 * (ToNum(y_1269) - 13.7)) / 9D))) + 0.04)));
}, 1, "", true);
P3_1258 = Fn((V _arrowThis1279, int _argc1271, V a_1277, V y_1278, V _a1275, V _a1276, V[] _rest1272) => {
return Arr(((V)(((-30D) + (FdLibm.Cos(ToNum(a_1277)) * ToNum(Call(r_1257, V.Undef, y_1278)))))), y_1278, ((V)((FdLibm.Sin(ToNum(a_1277)) * ToNum(Call(r_1257, V.Undef, y_1278))))));
}, 2, "", true);
A_1259 = Call(dec_44, V.Undef, ((V)("#7a5636")), NewObj(1).Put("op", ((V)(0.85))).V);
B2_1260 = Call(dec_44, V.Undef, ((V)("#e6c48e")), NewObj(1).Put("op", ((V)(0.9))).V);
Call(rep_28, V.Undef, ((V)(30D)), Fn((V _arrowThis1287, int _argc1280, V i_1286, V _a1283, V _a1284, V _a1285, V[] _rest1281) => {
double a_1288 = 0;
a_1288 = (((ToNum(i_1286) / 30D) * 2D) * PI_17);
Invoke(Arr(Arr(((V)(14.1)), ((V)(17.9))), Arr(((V)(19.5)), ((V)(21.5)))), "forEach", Fn((V _arrowThis1300, int _argc1289, V _a1291, V _a1292, V _a1293, V _a1294, V[] _rest1290) => {
V y0_1297 = default;
V y1_1299 = default;
{ V _t1295 = ListOf(_a1291);
{ V _t1296 = GetIdx(_t1295, 0D);
y0_1297 = _t1296; }
{ V _t1298 = GetIdx(_t1295, 1D);
y1_1299 = _t1298; }
}
return Invoke(A_1259, "line", Arr(Call(P3_1258, V.Undef, ((V)(a_1288)), y0_1297), Call(P3_1258, V.Undef, ((V)(a_1288)), y1_1299)), Call(cN_42, V.Undef, ((V)(a_1288))), ((V)(0.3)));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(((V)(14.7)), ((V)(15.9)), ((V)(17.1)), ((V)(20D)), ((V)(21D))), "forEach", Fn((V _arrowThis1309, int _argc1301, V y_1307, V k_1308, V _a1305, V _a1306, V[] _rest1302) => {
return Call(rep_28, V.Undef, ((V)(30D)), Fn((V _arrowThis1317, int _argc1310, V i_1316, V _a1313, V _a1314, V _a1315, V[] _rest1311) => {
double a0_1318 = 0;
double a1_1319 = 0;
a0_1318 = (((ToNum(Add(i_1316, ((V)(((ToNum(k_1308) % 2D) * 0.5))))) / 30D) * 2D) * PI_17);
a1_1319 = (a0_1318 + 0.16);
Invoke(B2_1260, "line", Arr(Call(P3_1258, V.Undef, ((V)(a0_1318)), y_1307), Call(P3_1258, V.Undef, ((V)(((a0_1318 + a1_1319) / 2D))), Add(y_1307, ((V)(0.1)))), Call(P3_1258, V.Undef, ((V)(a1_1319)), y_1307)), Arr(Call(cN_42, V.Undef, ((V)(a0_1318))), Call(cN_42, V.Undef, ((V)(((a0_1318 + a1_1319) / 2D)))), Call(cN_42, V.Undef, ((V)(a1_1319)))), ((V)(0.8)));
return default;
}, 1, "", true));
}, 2, "", true));
TH_1261 = Call(box_11, V.Undef, ((V)((-30D))), ((V)(22.3)), ((V)((-0.5))), ((V)(11D)), ((V)(2.4)), ((V)(10D)), ((V)("#c96f5a")), Call(F__26, V.Undef, NewObj(1).Put("r", ((V)(3.4))).V));
KN_1262 = Call(dec_44, V.Undef, ((V)("#a8503e")), NewObj(1).Put("op", ((V)(0.75))).V);
Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis1327, int _argc1320, V i_1326, V _a1323, V _a1324, V _a1325, V[] _rest1321) => {
return Invoke(KN_1262, "line", Call(wv_43, V.Undef, ((V)(8D)), Fn((V _arrowThis1335, int _argc1328, V t_1334, V _a1331, V _a1332, V _a1333, V[] _rest1329) => {
return Arr(((V)(((-35D) + (ToNum(t_1334) * 10D)))), ((V)(24.72)), ((V)((((-4.5) + (ToNum(i_1326) * 2D)) + (NumTruthy((System.Math.Floor((ToNum(t_1334) * 8D)) % 2D)) ? 0.5 : (-0.5))))));
}, 1, "", true)), Y3_40, ((V)(0.3)));
}, 1, "", true));
Call(on_1188, V.Undef, BK_1200, Arr(A_1259, B2_1260, TH_1261));
Call(on_1188, V.Undef, TH_1261, Arr(KN_1262));
}
Invoke(Arr(Arr(((V)("#2f5a8a")), ((V)(0D))), Arr(((V)("#e0b04c")), ((V)(1D))), Arr(((V)("#c4643a")), ((V)(2D)))), "forEach", Fn((V _arrowThis1347, int _argc1336, V _a1338, V _a1339, V _a1340, V _a1341, V[] _rest1337) => {
V B_1348 = default;
V yaw_1349 = default;
V E_1350 = default;
V G_1351 = default;
V col_1344 = default;
V i_1346 = default;
{ V _t1342 = ListOf(_a1338);
{ V _t1343 = GetIdx(_t1342, 0D);
col_1344 = _t1343; }
{ V _t1345 = GetIdx(_t1342, 1D);
i_1346 = _t1345; }
}
B_1348 = Call(at_49, V.Undef, o_1187, Arr(((V)(26D)), ((V)(((13.7 + (ToNum(i_1346) * 2.6)) + 1.3))), ((V)(0D))), col_1344);
if (!(Truthy(B_1348))) {
return default;
}
yaw_1349 = GetK(Arr(((V)(0D)), ((V)(0.1)), ((V)((-0.08)))), i_1346);
E_1350 = Call(dec_44, V.Undef, Call(shade_14, V.Undef, col_1344, ((V)(0.6))), NewObj(1).Put("op", ((V)(0.9))).V);
G_1351 = Call(dec_44, V.Undef, ((V)("#e2b14a")), NewObj(1).Put("op", ((V)(0.95))).V);
Invoke(E_1350, "poly", Call(rrect_47, V.Undef, ((V)(26D)), ((V)((13.7 + (ToNum(Add(i_1346, ((V)(1D)))) * 2.6)))), ((V)(0D)), ((V)(22D)), ((V)(1.4)), yaw_1349, ((V)(0D)), ((V)((-5.2)))), Y3_40);
Invoke(G_1351, "poly", Call(rrect_47, V.Undef, ((V)(26D)), ((V)((13.7 + (ToNum(Add(i_1346, ((V)(1D)))) * 2.6)))), ((V)(0D)), ((V)(8D)), ((V)(0.5)), yaw_1349, ((V)((-5D))), ((V)(3D))), Y3_40);
Call(on_1188, V.Undef, B_1348, Arr(E_1350, G_1351));
return default;
}, 1, "", true));
TR_1201 = Call(at_49, V.Undef, o_1187, Arr(((V)(28D)), ((V)((H_1195 + 1.6))), ((V)(0D))), BR_18);
if (Truthy(TR_1201)) {
V KY_1352 = default;
V KB_1353 = default;
KY_1352 = Call(dec_44, V.Undef, ((V)("#c9ced3")));
KB_1353 = Call(dec_44, V.Undef, ((V)("#b88a2a")));
Invoke(Invoke(KY_1352, "poly", Call(elP_45, V.Undef, Arr(((V)(24D)), ((V)((H_1195 + 2.12))), ((V)((-2.6)))), X3_39, Z3_41, ((V)(1.3)), ((V)(1.3)), ((V)(10D))), Y3_40), "poly", Call(rrect_47, V.Undef, ((V)(26.6)), ((V)((H_1195 + 2.12))), ((V)((-2.6))), ((V)(3.8)), ((V)(0.9)), ((V)(0.15))), Y3_40);
Invoke(Invoke(KB_1353, "poly", Call(elP_45, V.Undef, Arr(((V)(24D)), ((V)((H_1195 + 2.16))), ((V)((-2.6)))), X3_39, Z3_41, ((V)(0.6)), ((V)(0.6)), ((V)(8D))), Y3_40), "poly", Call(rrect_47, V.Undef, ((V)(32D)), ((V)((H_1195 + 2.12))), ((V)(2.2)), ((V)(2.4)), ((V)(2.4)), ((V)(0.4))), Y3_40);
Call(on_1188, V.Undef, TR_1201, Arr(KY_1352, KB_1353, Call(cyl_12, V.Undef, ((V)(33.6)), ((V)((H_1195 + 2.1))), ((V)((-2.6))), ((V)(1.3)), ((V)(0.3)), ((V)("#c99a3a")), Call(M__24, V.Undef, NewObj(1).Put("n", ((V)(12D))).V))));
}
if (Truthy(TP_1198)) {
V EV_1354 = default;
V EF_1355 = default;
V STM_1356 = default;
V Q_1357 = default;
EV_1354 = Call(dec_44, V.Undef, ((V)("#f6f0e2")));
EF_1355 = Call(dec_44, V.Undef, ((V)("#c9bea6")), NewObj(1).Put("op", ((V)(0.9))).V);
STM_1356 = Call(dec_44, V.Undef, ((V)("#d9483b")));
Q_1357 = Call(rrect_47, V.Undef, ((V)((-8D))), ((V)((H_1195 + 1.2))), ((V)(5D)), ((V)(14D)), ((V)(9D)), ((V)((-0.12))));
Invoke(EV_1354, "poly", Q_1357, Y3_40);
Invoke(EF_1355, "line", Arr(GetIdx(Q_1357, 3D), Call(add_34, V.Undef, Call(mul_36, V.Undef, Call(add_34, V.Undef, GetIdx(Q_1357, 2D), GetIdx(Q_1357, 3D)), ((V)(0.5))), Call(mul_36, V.Undef, Call(sub_35, V.Undef, Call(add_34, V.Undef, GetIdx(Q_1357, 0D), GetIdx(Q_1357, 1D)), Call(add_34, V.Undef, GetIdx(Q_1357, 2D), GetIdx(Q_1357, 3D))), ((V)(0.22)))), GetIdx(Q_1357, 2D)), Y3_40, ((V)(0.3)));
Invoke(STM_1356, "poly", Call(rrect_47, V.Undef, ((V)((-8D))), ((V)((H_1195 + 1.22))), ((V)(5D)), ((V)(2.4)), ((V)(2.8)), ((V)((-0.12))), ((V)(4.6)), ((V)((-2.4)))), Y3_40);
Call(on_1188, V.Undef, TP_1198, Arr(EV_1354, EF_1355, STM_1356));
}
FR_1202 = Call(tilt_20, V.Undef, Call(box_11, V.Undef, ((V)(6D)), ((V)((H_1195 + 1.2))), ((V)((-8D))), ((V)(11D)), ((V)(8.6)), ((V)(1D)), ((V)("#2c2d31")), Call(W__25, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), X3_39, ((V)((-0.12))), Arr(((V)(6D)), ((V)((H_1195 + 1.2))), ((V)((-8.5)))));
Invoke(o_1187, "push", FR_1202);
PH_1203 = Call(dec_44, V.Undef, ((V)("#9fd0ee")));
PG_1204 = Call(dec_44, V.Undef, ((V)("#7fb25a")));
PF_1205 = Call(dec_44, V.Undef, ((V)("#f2c94a")));
MT_1206 = Call(dec_44, V.Undef, ((V)("#f6f0e2")));
Invoke(MT_1206, "poly", Arr(Arr(((V)(1.4)), ((V)((H_1195 + 2.1))), ((V)((-7.45)))), Arr(((V)(10.6)), ((V)((H_1195 + 2.1))), ((V)((-7.45)))), Arr(((V)(10.6)), ((V)((H_1195 + 9D))), ((V)((-7.45)))), Arr(((V)(1.4)), ((V)((H_1195 + 9D))), ((V)((-7.45))))), Z3_41);
Invoke(PH_1203, "poly", Arr(Arr(((V)(2.4)), ((V)((H_1195 + 4.6))), ((V)((-7.4)))), Arr(((V)(9.6)), ((V)((H_1195 + 4.6))), ((V)((-7.4)))), Arr(((V)(9.6)), ((V)((H_1195 + 8.2))), ((V)((-7.4)))), Arr(((V)(2.4)), ((V)((H_1195 + 8.2))), ((V)((-7.4))))), Z3_41);
Invoke(PG_1204, "poly", Arr(Arr(((V)(2.4)), ((V)((H_1195 + 2.9))), ((V)((-7.4)))), Arr(((V)(9.6)), ((V)((H_1195 + 2.9))), ((V)((-7.4)))), Arr(((V)(9.6)), ((V)((H_1195 + 4.8))), ((V)((-7.4)))), Arr(((V)(6D)), ((V)((H_1195 + 5.6))), ((V)((-7.4)))), Arr(((V)(2.4)), ((V)((H_1195 + 4.4))), ((V)((-7.4))))), Z3_41);
Invoke(Invoke(PF_1205, "poly", Call(elP_45, V.Undef, Arr(((V)(4.4)), ((V)((H_1195 + 4.6))), ((V)((-7.36)))), X3_39, Y3_40, ((V)(0.6)), ((V)(1.4)), ((V)(8D))), Z3_41), "poly", Call(elP_45, V.Undef, Arr(((V)(7.4)), ((V)((H_1195 + 4.4))), ((V)((-7.36)))), X3_39, Y3_40, ((V)(0.6)), ((V)(1.2)), ((V)(8D))), Z3_41);
Call(on_1188, V.Undef, FR_1202, Invoke(Arr(MT_1206, PH_1203, PG_1204, PF_1205), "map", Fn((V _arrowThis1365, int _argc1358, V D_1364, V _a1361, V _a1362, V _a1363, V[] _rest1359) => {
return Call(tilt_20, V.Undef, D_1364, X3_39, ((V)((-0.12))), Arr(((V)(6D)), ((V)((H_1195 + 1.2))), ((V)((-8.5)))));
}, 1, "", true)));
return default;
}, 3, "", true)));
Set(N_16, "burl24", Call(ext_50, V.Undef, ((V)("burl22")), Fn((V _arrowThis1375, int _argc1366, V o_1372, V on_1373, V R_1374, V _a1371, V[] _rest1367) => {
V BU_1376 = default;
double TY_1377 = 0;
double YT_1378 = 0;
V TP_1379 = default;
V OR_1380 = default;
BU_1376 = ((V)("#a2653a"));
TY_1377 = 52D;
YT_1378 = (TY_1377 + 4D);
TP_1379 = Call(at_49, V.Undef, o_1372, Arr(((V)(0D)), ((V)((TY_1377 + 2D))), ((V)(0D))), BU_1376);
if (Truthy(TP_1379)) {
V G1_1381 = default;
V G2_1382 = default;
V EY_1383 = default;
V RG2_1384 = default;
V RG3_1385 = default;
V GLs_1386 = default;
G1_1381 = Call(dec_44, V.Undef, ((V)("#5a2c12")), NewObj(1).Put("op", ((V)(0.42))).V);
G2_1382 = Call(dec_44, V.Undef, ((V)("#d8a066")), NewObj(1).Put("op", ((V)(0.38))).V);
EY_1383 = Call(dec_44, V.Undef, ((V)("#3a1a08")), NewObj(1).Put("op", ((V)(0.85))).V);
RG2_1384 = Call(dec_44, V.Undef, ((V)("#c88a52")), NewObj(1).Put("op", ((V)(0.55))).V);
RG3_1385 = Call(dec_44, V.Undef, ((V)("#6e3a1c")), NewObj(1).Put("op", ((V)(0.5))).V);
Call(rep_28, V.Undef, ((V)(16D)), Fn((V _arrowThis1394, int _argc1387, V k_1393, V _a1390, V _a1391, V _a1392, V[] _rest1388) => {
double z0_1395 = 0;
double ph_1396 = 0;
double a1_1397 = 0;
double f1_1398 = 0;
z0_1395 = ((-14.5) + (ToNum(k_1393) * 1.95));
ph_1396 = (ToNum(Call(R_1374, V.Undef)) * 6D);
a1_1397 = (0.6 + (ToNum(Call(R_1374, V.Undef)) * 0.9));
f1_1398 = (0.08 + (ToNum(Call(R_1374, V.Undef)) * 0.05));
Invoke((NumTruthy((ToNum(k_1393) % 3D)) ? G1_1381 : G2_1382), "line", Call(wv_43, V.Undef, ((V)(44D)), Fn((V _arrowThis1406, int _argc1399, V t_1405, V _a1402, V _a1403, V _a1404, V[] _rest1400) => {
double x_1407 = 0;
x_1407 = ((-59D) + (118D * ToNum(t_1405)));
return Arr(((V)(x_1407)), ((V)(YT_1378)), ((V)(Max((-15.3), Min(15.3, ((z0_1395 + (a1_1397 * FdLibm.Sin(((x_1407 * f1_1398) + ph_1396)))) + (0.6 * FdLibm.Sin(((x_1407 * 0.31) + (ph_1396 * 2D))))))))));
return default;
}, 1, "", true)), Y3_40, ((V)((NumTruthy((ToNum(k_1393) % 3D)) ? 0.26 : 0.4))));
return default;
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(40D)), Fn((V _arrowThis1414, int _argc1408, V _a1410, V _a1411, V _a1412, V _a1413, V[] _rest1409) => {
double cx_1415 = 0;
double cz_1416 = 0;
double rx_1417 = 0;
double rz_1418 = 0;
cx_1415 = ((ToNum(Call(R_1374, V.Undef)) - 0.5) * 108D);
cz_1416 = ((ToNum(Call(R_1374, V.Undef)) - 0.5) * 24D);
rx_1417 = (0.8 + (ToNum(Call(R_1374, V.Undef)) * 0.4));
rz_1418 = (0.55 + (ToNum(Call(R_1374, V.Undef)) * 0.25));
Call(rep_28, V.Undef, ((V)((2D + System.Math.Floor((ToNum(Call(R_1374, V.Undef)) * 4D))))), Fn((V _arrowThis1425, int _argc1419, V _a1421, V _a1422, V _a1423, V _a1424, V[] _rest1420) => {
return Call(spot_46, V.Undef, EY_1383, Arr(((V)((cx_1415 + ((ToNum(Call(R_1374, V.Undef)) - 0.5) * 1.4)))), ((V)(YT_1378)), ((V)((cz_1416 + ((ToNum(Call(R_1374, V.Undef)) - 0.5) * 0.9))))), Y3_40, ((V)((0.12 + (ToNum(Call(R_1374, V.Undef)) * 0.16)))), ((V)((0.1 + (ToNum(Call(R_1374, V.Undef)) * 0.1)))), ((V)((ToNum(Call(R_1374, V.Undef)) * 3D))), ((V)(6D)));
}, 0, "", true));
Invoke(RG2_1384, "line", Call(wv_43, V.Undef, ((V)(16D)), Fn((V _arrowThis1433, int _argc1426, V t_1432, V _a1429, V _a1430, V _a1431, V[] _rest1427) => {
return Arr(((V)((cx_1415 + (FdLibm.Cos(((ToNum(t_1432) * 2D) * PI_17)) * rx_1417)))), ((V)(YT_1378)), ((V)((cz_1416 + (FdLibm.Sin(((ToNum(t_1432) * 2D) * PI_17)) * rz_1418)))));
}, 1, "", true)), Y3_40, ((V)(0.22)));
Invoke(RG3_1385, "line", Call(wv_43, V.Undef, ((V)(18D)), Fn((V _arrowThis1441, int _argc1434, V t_1440, V _a1437, V _a1438, V _a1439, V[] _rest1435) => {
return Arr(((V)((cx_1415 + ((FdLibm.Cos(((ToNum(t_1440) * 2D) * PI_17)) * rx_1417) * 1.7)))), ((V)(YT_1378)), ((V)((cz_1416 + ((FdLibm.Sin(((ToNum(t_1440) * 2D) * PI_17)) * rz_1418) * 1.6)))));
}, 1, "", true)), Y3_40, ((V)(0.18)));
return default;
}, 0, "", true));
GLs_1386 = Call(dec_44, V.Undef, ((V)("#fff4e0")), NewObj(1).Put("op", ((V)(0.24))).V);
Invoke(Invoke(GLs_1386, "poly", Arr(Arr(((V)((-50D))), ((V)(YT_1378)), ((V)(15D))), Arr(((V)((-38D))), ((V)(YT_1378)), ((V)(15D))), Arr(((V)((-24D))), ((V)(YT_1378)), ((V)((-15D)))), Arr(((V)((-36D))), ((V)(YT_1378)), ((V)((-15D))))), Y3_40), "poly", Arr(Arr(((V)(10D)), ((V)(YT_1378)), ((V)(15D))), Arr(((V)(14D)), ((V)(YT_1378)), ((V)(15D))), Arr(((V)(28D)), ((V)(YT_1378)), ((V)((-15D)))), Arr(((V)(24D)), ((V)(YT_1378)), ((V)((-15D))))), Y3_40);
Call(on_1373, V.Undef, TP_1379, Arr(G1_1381, G2_1382, RG3_1385, RG2_1384, EY_1383, GLs_1386));
}
Invoke(Arr(((V)((-52D))), ((V)(52D))), "forEach", Fn((V _arrowThis1449, int _argc1442, V x_1448, V _a1445, V _a1446, V _a1447, V[] _rest1443) => {
return Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1457, int _argc1450, V sz_1456, V _a1453, V _a1454, V _a1455, V[] _rest1451) => {
double z_1458 = 0;
V L_1459 = default;
V F_1460 = default;
V Hh_1461 = default;
double y0_1462 = 0;
double y1_1463 = 0;
z_1458 = (ToNum(sz_1456) * 13D);
L_1459 = Call(at_49, V.Undef, o_1372, Arr(x_1448, ((V)(20D)), ((V)(z_1458))), BR_18);
if (!(Truthy(L_1459))) {
return default;
}
F_1460 = Call(dec_44, V.Undef, ((V)("#9a7428")), NewObj(1).Put("op", ((V)(0.65))).V);
Hh_1461 = Call(dec_44, V.Undef, ((V)("#fff0b8")), NewObj(1).Put("op", ((V)(0.75))).V);
y0_1462 = 3.4;
y1_1463 = (TY_1377 - 3.4);
Invoke(Arr(((V)((-0.6))), ((V)(0.6))), "forEach", Fn((V _arrowThis1471, int _argc1464, V d_1470, V _a1467, V _a1468, V _a1469, V[] _rest1465) => {
Invoke(Invoke(Invoke(Invoke(F_1460, "line", Arr(Arr(Add(x_1448, d_1470), ((V)(y0_1462)), ((V)((z_1458 + 1.3)))), Arr(Add(x_1448, d_1470), ((V)(y1_1463)), ((V)((z_1458 + 1.3))))), Z3_41, ((V)(0.2))), "line", Arr(Arr(Add(x_1448, d_1470), ((V)(y0_1462)), ((V)((z_1458 - 1.3)))), Arr(Add(x_1448, d_1470), ((V)(y1_1463)), ((V)((z_1458 - 1.3))))), Call(mul_36, V.Undef, Z3_41, ((V)((-1D)))), ((V)(0.2))), "line", Arr(Arr(Add(x_1448, ((V)(1.3))), ((V)(y0_1462)), Add(((V)(z_1458)), d_1470)), Arr(Add(x_1448, ((V)(1.3))), ((V)(y1_1463)), Add(((V)(z_1458)), d_1470))), X3_39, ((V)(0.2))), "line", Arr(Arr(((V)((ToNum(x_1448) - 1.3))), ((V)(y0_1462)), Add(((V)(z_1458)), d_1470)), Arr(((V)((ToNum(x_1448) - 1.3))), ((V)(y1_1463)), Add(((V)(z_1458)), d_1470))), Call(mul_36, V.Undef, X3_39, ((V)((-1D)))), ((V)(0.2)));
return default;
}, 1, "", true));
Invoke(Invoke(Hh_1461, "line", Arr(Arr(((V)((ToNum(x_1448) - 1D))), ((V)(y0_1462)), ((V)((z_1458 + 1.3)))), Arr(((V)((ToNum(x_1448) - 1D))), ((V)(y1_1463)), ((V)((z_1458 + 1.3))))), Z3_41, ((V)(0.25))), "line", Arr(Arr(((V)((ToNum(x_1448) - 1.3))), ((V)(y0_1462)), ((V)((z_1458 + 1D)))), Arr(((V)((ToNum(x_1448) - 1.3))), ((V)(y1_1463)), ((V)((z_1458 + 1D))))), Call(mul_36, V.Undef, X3_39, ((V)((-1D)))), ((V)(0.25)));
Call(on_1373, V.Undef, L_1459, Arr(F_1460, Hh_1461));
return default;
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(Arr(((V)("#e0b04c")), ((V)((-37D))), ((V)((-0.6)))), Arr(((V)("#d9663a")), ((V)((-31D))), ((V)((-0.6)))), Arr(((V)("#e86fa8")), ((V)((-37D))), ((V)(4.6))), Arr(((V)("#4f9a4a")), ((V)((-31D))), ((V)(4.6)))), "forEach", Fn((V _arrowThis1486, int _argc1472, V _a1474, V i_1478, V _a1476, V _a1477, V[] _rest1473) => {
V F_1487 = default;
double tp_1488 = 0;
V col_1481 = default;
V x_1483 = default;
V z_1485 = default;
{ V _t1479 = ListOf(_a1474);
{ V _t1480 = GetIdx(_t1479, 0D);
col_1481 = _t1480; }
{ V _t1482 = GetIdx(_t1479, 1D);
x_1483 = _t1482; }
{ V _t1484 = GetIdx(_t1479, 2D);
z_1485 = _t1484; }
}
F_1487 = Call(at_49, V.Undef, o_1372, Arr(x_1483, ((V)((TY_1377 + 9.6))), z_1485), col_1481);
if (!(Truthy(F_1487))) {
return default;
}
tp_1488 = (TY_1377 + 12.2);
Call(on_1373, V.Undef, F_1487, Invoke(Arr(Call(rod_22, V.Undef, Arr(x_1483, ((V)((tp_1488 - 0.3))), z_1485), Arr(Add(x_1483, ((V)(0.3))), ((V)((tp_1488 + 1.3))), ((V)((ToNum(z_1485) - 0.2)))), ((V)(0.22)), ((V)("#5a3a1a")), NewObj(2).Put("n", ((V)(5D))).Put("noOut", ((V)(1D))).V)), "concat", (NumTruthy((ToNum(i_1478) % 2D)) ? Arr(Call(ball_13, V.Undef, Add(x_1483, ((V)(0.6))), ((V)((tp_1488 + 0.6))), ((V)((ToNum(z_1485) - 0.6))), ((V)(0.9)), ((V)("#5f9a4a")), NewObj(5).Put("sx", ((V)(1.6))).Put("sy", ((V)(0.35))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("yaw", ((V)(0.6))).V)) : Arr())));
if (SEqN(i_1478, 1D)) {
V DP_1489 = default;
DP_1489 = Call(dec_44, V.Undef, Call(shade_14, V.Undef, col_1481, ((V)(0.78))), NewObj(1).Put("op", ((V)(0.6))).V);
Call(rep_28, V.Undef, ((V)(18D)), Fn((V _arrowThis1496, int _argc1490, V _a1492, V _a1493, V _a1494, V _a1495, V[] _rest1491) => {
double a_1497 = 0;
double b_1498 = 0;
V n_1499 = default;
a_1497 = ((ToNum(Call(R_1374, V.Undef)) * 2D) * PI_17);
b_1498 = ((ToNum(Call(R_1374, V.Undef)) - 0.3) * 1.2);
n_1499 = Arr(((V)((FdLibm.Cos(a_1497) * FdLibm.Cos(b_1498)))), ((V)(FdLibm.Sin(b_1498))), ((V)((FdLibm.Sin(a_1497) * FdLibm.Cos(b_1498)))));
Call(spot_46, V.Undef, DP_1489, Call(add_34, V.Undef, Arr(x_1483, ((V)((TY_1377 + 9.6))), z_1485), Call(mul_36, V.Undef, n_1499, ((V)(2.62)))), n_1499, ((V)(0.16)), ((V)(0.16)), ((V)(0D)), ((V)(5D)));
return default;
}, 0, "", true));
Call(on_1373, V.Undef, F_1487, Arr(DP_1489));
}
return default;
}, 2, "", true));
OR_1380 = Call(at_49, V.Undef, o_1372, Arr(((V)(36D)), ((V)((TY_1377 + 14D))), ((V)((-2D)))), ((V)("#e9e3d8")));
if (Truthy(OR_1380)) {
V c_1500 = default;
V V_1501 = default;
V V2_1502 = default;
c_1500 = Arr(((V)(36D)), ((V)((TY_1377 + 14D))), ((V)((-2D))));
V_1501 = Call(dec_44, V.Undef, ((V)("#a39a88")), NewObj(1).Put("op", ((V)(0.65))).V);
V2_1502 = Call(dec_44, V.Undef, ((V)("#c8bfae")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Arr(Arr(((V)(0.5)), ((V)(0.3)), V_1501, ((V)(0.4))), Arr(((V)(1.6)), ((V)((-0.4))), V2_1502, ((V)(0.24))), Arr(((V)(2.6)), ((V)(0.9)), V_1501, ((V)(0.22)))), "forEach", Fn((V _arrowThis1518, int _argc1503, V _a1505, V _a1506, V _a1507, V _a1508, V[] _rest1504) => {
V e1_1519 = default;
V e2_1520 = default;
V Q_1521 = default;
V yaw_1511 = default;
V tl_1513 = default;
V D_1515 = default;
V w_1517 = default;
{ V _t1509 = ListOf(_a1505);
{ V _t1510 = GetIdx(_t1509, 0D);
yaw_1511 = _t1510; }
{ V _t1512 = GetIdx(_t1509, 1D);
tl_1513 = _t1512; }
{ V _t1514 = GetIdx(_t1509, 2D);
D_1515 = _t1514; }
{ V _t1516 = GetIdx(_t1509, 3D);
w_1517 = _t1516; }
}
e1_1519 = Arr(((V)(FdLibm.Cos(ToNum(yaw_1511)))), ((V)((FdLibm.Sin(ToNum(tl_1513)) * 0.4))), ((V)(FdLibm.Sin(ToNum(yaw_1511)))));
e2_1520 = Call(nz_38, V.Undef, Call(cr_37, V.Undef, e1_1519, Arr(((V)(0D)), ((V)(1D)), ((V)(0.2)))));
Q_1521 = Call(wv_43, V.Undef, ((V)(40D)), Fn((V _arrowThis1529, int _argc1522, V t_1528, V _a1525, V _a1526, V _a1527, V[] _rest1523) => {
double a_1530 = 0;
a_1530 = ((ToNum(t_1528) * 2D) * PI_17);
return Call(nz_38, V.Undef, Call(add_34, V.Undef, Call(mul_36, V.Undef, e1_1519, ((V)(FdLibm.Cos(a_1530)))), Call(mul_36, V.Undef, e2_1520, ((V)((FdLibm.Sin(a_1530) + (0.15 * FdLibm.Sin((a_1530 * 5D)))))))));
return default;
}, 1, "", true));
Invoke(D_1515, "line", Invoke(Q_1521, "map", Fn((V _arrowThis1538, int _argc1531, V n_1537, V _a1534, V _a1535, V _a1536, V[] _rest1532) => {
return Call(add_34, V.Undef, c_1500, Call(mul_36, V.Undef, n_1537, ((V)(7.04))));
}, 1, "", true)), Q_1521, w_1517);
return default;
}, 1, "", true));
Call(on_1373, V.Undef, OR_1380, Arr(V_1501, V2_1502));
}
Invoke(Arr(Arr(((V)("#1f3a4a")), ((V)(0D))), Arr(((V)("#e0d4b8")), ((V)(1D)))), "forEach", Fn((V _arrowThis1550, int _argc1539, V _a1541, V _a1542, V _a1543, V _a1544, V[] _rest1540) => {
V B_1551 = default;
V yaw_1552 = default;
V E_1553 = default;
V col_1547 = default;
V i_1549 = default;
{ V _t1545 = ListOf(_a1541);
{ V _t1546 = GetIdx(_t1545, 0D);
col_1547 = _t1546; }
{ V _t1548 = GetIdx(_t1545, 1D);
i_1549 = _t1548; }
}
B_1551 = Call(at_49, V.Undef, o_1372, Arr(((V)(10D)), ((V)((((TY_1377 + 4D) + (ToNum(i_1549) * 3.2)) + 1.6))), ((V)(4D))), col_1547);
if (!(Truthy(B_1551))) {
return default;
}
yaw_1552 = GetK(Arr(((V)(0D)), ((V)(0.08))), i_1549);
E_1553 = Call(dec_44, V.Undef, ((V)((Truthy(i_1549) ? "#b44a3a" : "#e2b14a"))), NewObj(1).Put("op", ((V)(0.9))).V);
Invoke(Invoke(E_1553, "poly", Call(rrect_47, V.Undef, ((V)(10D)), ((V)(((TY_1377 + 4D) + (ToNum(Add(i_1549, ((V)(1D)))) * 3.2)))), ((V)(4D)), ((V)(14D)), ((V)(1.2)), yaw_1552, ((V)(0D)), ((V)(5D))), Y3_40), "poly", Call(rrect_47, V.Undef, ((V)(10D)), ((V)(((TY_1377 + 4D) + (ToNum(Add(i_1549, ((V)(1D)))) * 3.2)))), ((V)(4D)), ((V)(10D)), ((V)(5D)), yaw_1552, ((V)(0D)), ((V)((-1.5)))), Y3_40);
Call(on_1373, V.Undef, B_1551, Arr(E_1553));
return default;
}, 1, "", true));
return default;
}, 3, "", true)));
Set(N_16, "liquid24", Call(ext_50, V.Undef, ((V)("liquid22")), Fn((V _arrowThis1563, int _argc1554, V o_1560, V on_1561, V R_1562, V _a1559, V[] _rest1555) => {
double Dp_1564 = 0;
double TY_1565 = 0;
V legR_1566 = default;
V ip_1567 = default;
V TP_1568 = default;
V VS_1569 = default;
Dp_1564 = 32D;
TY_1565 = 46D;
legR_1566 = Fn((V _arrowThis1577, int _argc1570, V sx_1576, V _a1573, V _a1574, V _a1575, V[] _rest1571) => {
return Arr(Arr(Arr(((V)(0D)), ((V)((ToNum(sx_1576) * 36D))), ((V)(0D)), ((V)(15D)), ((V)(10D))), Arr(((V)(2.4)), ((V)((ToNum(sx_1576) * 36D))), ((V)(0D)), ((V)(14D)), ((V)(9.4))), Arr(((V)(5D)), ((V)((ToNum(sx_1576) * 35D))), ((V)(0D)), ((V)(9D)), ((V)(6.4)))), Arr(Arr(((V)(5D)), ((V)((ToNum(sx_1576) * 35D))), ((V)(0D)), ((V)(8.4)), ((V)(6D))), Arr(((V)(16D)), ((V)((ToNum(sx_1576) * 31.6))), ((V)(1D)), ((V)(4.4)), ((V)(3.6))), Arr(((V)(28D)), ((V)((ToNum(sx_1576) * 30.6))), ((V)(0D)), ((V)(3.8)), ((V)(3.2)))), Arr(Arr(((V)(28D)), ((V)((ToNum(sx_1576) * 30.6))), ((V)(0D)), ((V)(3.8)), ((V)(3.2))), Arr(((V)(37D)), ((V)((ToNum(sx_1576) * 33D))), ((V)((-1D))), ((V)(7D)), ((V)(5D))), Arr(((V)(43D)), ((V)((ToNum(sx_1576) * 36D))), ((V)(0D)), ((V)(13D)), ((V)(8.6))), Arr(((V)(46D)), ((V)((ToNum(sx_1576) * 37D))), ((V)(0D)), ((V)(16D)), ((V)(10.4)))));
}, 1, "", true);
ip_1567 = Fn((V _arrowThis1586, int _argc1578, V Rg_1584, V y_1585, V _a1582, V _a1583, V[] _rest1579) => {
{
double i_1587 = 0;
i_1587 = 0D;
while (true) {
if (!((i_1587 < (ToNum(Get(Rg_1584, "length")) - 1D)))) break;
if (Le(y_1585, GetIdx(GetIdx(Rg_1584, (i_1587 + 1D)), 0D))) {
V A_1589 = default;
V B_1590 = default;
double t_1591 = 0;
A_1589 = GetIdx(Rg_1584, i_1587);
B_1590 = GetIdx(Rg_1584, (i_1587 + 1D));
t_1591 = ((ToNum(y_1585) - ToNum(GetIdx(A_1589, 0D))) / (ToNum(GetIdx(B_1590, 0D)) - ToNum(GetIdx(A_1589, 0D))));
return Invoke(A_1589, "map", Fn((V _arrowThis1600, int _argc1592, V v_1598, V k_1599, V _a1596, V _a1597, V[] _rest1593) => {
return Add(v_1598, ((V)(((ToNum(GetK(B_1590, k_1599)) - ToNum(v_1598)) * t_1591))));
}, 2, "", true));
}
i_1587++;
}
}
return GetIdx(Rg_1584, (ToNum(Get(Rg_1584, "length")) - 1D));
return default;
}, 2, "", true);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1608, int _argc1601, V sx_1607, V _a1604, V _a1605, V _a1606, V[] _rest1602) => {
return Invoke(Call(legR_1566, V.Undef, sx_1607), "forEach", Fn((V _arrowThis1616, int _argc1609, V Rg_1615, V _a1612, V _a1613, V _a1614, V[] _rest1610) => {
V y0_1617 = default;
V y1_1618 = default;
V mid_1619 = default;
V S_1620 = default;
double sc_1621 = 0;
V Wt_1622 = default;
V Dk_1623 = default;
V Bl_1624 = default;
y0_1617 = GetIdx(GetIdx(Rg_1615, 0D), 0D);
y1_1618 = GetIdx(GetIdx(Rg_1615, (ToNum(Get(Rg_1615, "length")) - 1D)), 0D);
mid_1619 = Call(ip_1567, V.Undef, Rg_1615, ((V)((ToNum(Add(y0_1617, y1_1618)) / 2D))));
S_1620 = Call(at_49, V.Undef, o_1560, Arr(GetIdx(mid_1619, 1D), GetIdx(mid_1619, 0D), GetIdx(mid_1619, 2D)), CH_19);
if (!(Truthy(S_1620))) {
return default;
}
sc_1621 = Max(0.35, Min(1D, (ToNum(GetIdx(mid_1619, 3D)) / 9D)));
Wt_1622 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.85))).V);
Dk_1623 = Call(dec_44, V.Undef, ((V)("#4d575e")), NewObj(1).Put("op", ((V)(0.55))).V);
Bl_1624 = Call(dec_44, V.Undef, ((V)("#9fb4c4")), NewObj(1).Put("op", ((V)(0.55))).V);
Invoke(Arr(Arr(((V)(2.35)), Wt_1622, ((V)(0.9))), Arr(((V)(2.05)), Wt_1622, ((V)(0.35))), Arr(((V)(1.15)), Dk_1623, ((V)(1.6))), Arr(((V)(0.5)), Bl_1624, ((V)(1.2))), Arr(((V)((-0.7))), Dk_1623, ((V)(1.2))), Arr(((V)((-2.4))), Bl_1624, ((V)(1D)))), "forEach", Fn((V _arrowThis1638, int _argc1625, V _a1627, V _a1628, V _a1629, V _a1630, V[] _rest1626) => {
V Y_1639 = default;
V t_1633 = default;
V D_1635 = default;
V w_1637 = default;
{ V _t1631 = ListOf(_a1627);
{ V _t1632 = GetIdx(_t1631, 0D);
t_1633 = _t1632; }
{ V _t1634 = GetIdx(_t1631, 1D);
D_1635 = _t1634; }
{ V _t1636 = GetIdx(_t1631, 2D);
w_1637 = _t1636; }
}
Y_1639 = Call(wv_43, V.Undef, ((V)(10D)), Fn((V _arrowThis1647, int _argc1640, V u_1646, V _a1643, V _a1644, V _a1645, V[] _rest1641) => {
return Add(Add(y0_1617, ((V)(0.2))), ((V)((((ToNum(y1_1618) - ToNum(y0_1617)) - 0.4) * ToNum(u_1646)))));
}, 1, "", true));
Invoke(D_1635, "line", Invoke(Y_1639, "map", Fn((V _arrowThis1655, int _argc1648, V y_1654, V _a1651, V _a1652, V _a1653, V[] _rest1649) => {
V q_1656 = default;
q_1656 = Call(ip_1567, V.Undef, Rg_1615, y_1654);
return Arr(Add(GetIdx(q_1656, 1D), ((V)(((FdLibm.Cos(ToNum(t_1633)) * ToNum(GetIdx(q_1656, 3D))) * 1.01)))), y_1654, Add(GetIdx(q_1656, 2D), ((V)(((FdLibm.Sin(ToNum(t_1633)) * ToNum(GetIdx(q_1656, 4D))) * 1.01)))));
return default;
}, 1, "", true)), Invoke(Y_1639, "map", Fn((V _arrowThis1664, int _argc1657, V y_1663, V _a1660, V _a1661, V _a1662, V[] _rest1658) => {
V q_1665 = default;
q_1665 = Call(ip_1567, V.Undef, Rg_1615, y_1663);
return Call(nz_38, V.Undef, Arr(((V)((FdLibm.Cos(ToNum(t_1633)) / ToNum(GetIdx(q_1665, 3D))))), ((V)(0D)), ((V)((FdLibm.Sin(ToNum(t_1633)) / ToNum(GetIdx(q_1665, 4D)))))));
return default;
}, 1, "", true)), ((V)((ToNum(w_1637) * sc_1621))));
return default;
}, 1, "", true));
Call(on_1561, V.Undef, S_1620, Arr(Bl_1624, Dk_1623, Wt_1622));
return default;
}, 1, "", true));
}, 1, "", true));
TP_1568 = Call(at_49, V.Undef, o_1560, Arr(((V)(0D)), ((V)((TY_1565 + 2.3))), ((V)(0D))), CH_19);
if (Truthy(TP_1568)) {
double yT_1666 = 0;
V Dk_1667 = default;
V Bl_1668 = default;
V Wt_1669 = default;
V FL_1670 = default;
V FD_1671 = default;
yT_1666 = (TY_1565 + 4.6);
Dk_1667 = Call(dec_44, V.Undef, ((V)("#6c777f")), NewObj(1).Put("op", ((V)(0.42))).V);
Bl_1668 = Call(dec_44, V.Undef, ((V)("#a9c0d2")), NewObj(1).Put("op", ((V)(0.4))).V);
Wt_1669 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.75))).V);
FL_1670 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.8))).V);
FD_1671 = Call(dec_44, V.Undef, ((V)("#5d666d")), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Dk_1667, "poly", Invoke(Call(wv_43, V.Undef, ((V)(20D)), Fn((V _arrowThis1687, int _argc1680, V t_1686, V _a1683, V _a1684, V _a1685, V[] _rest1681) => {
return Arr(((V)(((-44D) + (88D * ToNum(t_1686))))), ((V)(yT_1666)), ((V)(((-1D) + (FdLibm.Sin((ToNum(t_1686) * 7D)) * 1.2)))));
}, 1, "", true)), "concat", Call(wv_43, V.Undef, ((V)(20D)), Fn((V _arrowThis1679, int _argc1672, V t_1678, V _a1675, V _a1676, V _a1677, V[] _rest1673) => {
return Arr(((V)((44D - (88D * ToNum(t_1678))))), ((V)(yT_1666)), ((V)(((-5.5) + FdLibm.Sin(((ToNum(t_1678) * 5D) + 1D))))));
}, 1, "", true))), Y3_40);
Invoke(Bl_1668, "poly", Invoke(Call(wv_43, V.Undef, ((V)(20D)), Fn((V _arrowThis1703, int _argc1696, V t_1702, V _a1699, V _a1700, V _a1701, V[] _rest1697) => {
return Arr(((V)(((-44D) + (88D * ToNum(t_1702))))), ((V)(yT_1666)), ((V)(((-6D) + FdLibm.Sin(((ToNum(t_1702) * 5D) + 1D))))));
}, 1, "", true)), "concat", Call(wv_43, V.Undef, ((V)(20D)), Fn((V _arrowThis1695, int _argc1688, V t_1694, V _a1691, V _a1692, V _a1693, V[] _rest1689) => {
return Arr(((V)((44D - (88D * ToNum(t_1694))))), ((V)(yT_1666)), ((V)(((-12D) + (FdLibm.Sin(((ToNum(t_1694) * 4D) + 2D)) * 0.6)))));
}, 1, "", true))), Y3_40);
Invoke(Invoke(Wt_1669, "poly", Arr(Arr(((V)((-38D))), ((V)(yT_1666)), ((V)(12D))), Arr(((V)((-30D))), ((V)(yT_1666)), ((V)(12D))), Arr(((V)((-18D))), ((V)(yT_1666)), ((V)((-12D)))), Arr(((V)((-26D))), ((V)(yT_1666)), ((V)((-12D))))), Y3_40), "poly", Arr(Arr(((V)(18D)), ((V)(yT_1666)), ((V)(12D))), Arr(((V)(21D)), ((V)(yT_1666)), ((V)(12D))), Arr(((V)(33D)), ((V)(yT_1666)), ((V)((-12D)))), Arr(((V)(30D)), ((V)(yT_1666)), ((V)((-12D))))), Y3_40);
Invoke(FL_1670, "line", Call(wv_43, V.Undef, ((V)(10D)), Fn((V _arrowThis1711, int _argc1704, V t_1710, V _a1707, V _a1708, V _a1709, V[] _rest1705) => {
return Arr(((V)(((-44D) + (88D * ToNum(t_1710))))), ((V)((TY_1565 + 1.5))), ((V)((Dp_1564 / 2D))));
}, 1, "", true)), Z3_41, ((V)(0.5)));
Invoke(FD_1671, "line", Call(wv_43, V.Undef, ((V)(10D)), Fn((V _arrowThis1719, int _argc1712, V t_1718, V _a1715, V _a1716, V _a1717, V[] _rest1713) => {
return Arr(((V)(((-44D) + (88D * ToNum(t_1718))))), ((V)((TY_1565 + 0.6))), ((V)((Dp_1564 / 2D))));
}, 1, "", true)), Z3_41, ((V)(0.6)));
Call(on_1561, V.Undef, TP_1568, Invoke(Arr(Bl_1668, Dk_1667, Wt_1669, FD_1671, FL_1670), "concat", Invoke(Arr(((V)((-30D))), ((V)((-6D))), ((V)(38D))), "map", Fn((V _arrowThis1728, int _argc1720, V x_1726, V i_1727, V _a1724, V _a1725, V[] _rest1721) => {
return Call(ball_13, V.Undef, x_1726, ((V)(((TY_1565 - 2D) - (ToNum(i_1727) * 0.5)))), ((V)(((Dp_1564 / 2D) - 2.2))), ((V)(0.8)), CH_19, NewObj(5).Put("sy", ((V)(1.7))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V);
}, 2, "", true))));
}
VS_1569 = Call(at_49, V.Undef, o_1560, Arr(((V)((-20D))), ((V)((TY_1565 + 10D))), ((V)((-4D)))), ((V)("#2a2b30")));
if (Truthy(VS_1569)) {
V t0_1729 = default;
V BW_1730 = default;
V b1_1731 = default;
V b2_1732 = default;
t0_1729 = Arr(((V)((-20D))), ((V)((TY_1565 + 16.6))), ((V)((-4D))));
BW_1730 = ((V)("#5a4030"));
b1_1731 = Call(pipe_23, V.Undef, Arr(t0_1729, Arr(((V)((-22D))), ((V)((TY_1565 + 26D))), ((V)((-4.6)))), Arr(((V)((-25D))), ((V)((TY_1565 + 34D))), ((V)((-5D)))), Arr(((V)((-27D))), ((V)((TY_1565 + 40D))), ((V)((-3.6))))), ((V)(0.32)), BW_1730, NewObj(1).Put("n", ((V)(5D))).V);
b2_1732 = Call(pipe_23, V.Undef, Arr(t0_1729, Arr(((V)((-17D))), ((V)((TY_1565 + 25D))), ((V)((-3.6)))), Arr(((V)((-14.6))), ((V)((TY_1565 + 31D))), ((V)((-4.4)))), Arr(((V)((-12.6))), ((V)((TY_1565 + 35D))), ((V)((-6D))))), ((V)(0.28)), BW_1730, NewObj(1).Put("n", ((V)(5D))).V);
Call(on_1561, V.Undef, VS_1569, Invoke(b1_1731, "concat", b2_1732, Invoke(Arr(Arr(((V)((-25D))), ((V)((TY_1565 + 34D))), ((V)((-5D)))), Arr(((V)((-27D))), ((V)((TY_1565 + 40D))), ((V)((-3.6)))), Arr(((V)((-22.6))), ((V)((TY_1565 + 28D))), ((V)((-4.4)))), Arr(((V)((-14.6))), ((V)((TY_1565 + 31D))), ((V)((-4.4)))), Arr(((V)((-12.6))), ((V)((TY_1565 + 35D))), ((V)((-6D)))), Arr(((V)((-16.6))), ((V)((TY_1565 + 26.6))), ((V)((-3.8))))), "map", Fn((V _arrowThis1741, int _argc1733, V p_1739, V i_1740, V _a1737, V _a1738, V[] _rest1734) => {
return Call(ball_13, V.Undef, Add(GetIdx(p_1739, 0D), ((V)(0.5))), GetIdx(p_1739, 1D), GetIdx(p_1739, 2D), ((V)((0.75 + ((ToNum(i_1740) % 2D) * 0.25)))), ((V)((NumTruthy((ToNum(i_1740) % 3D)) ? "#f6efe2" : "#e8d4c0"))), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).V);
}, 2, "", true))));
}
return default;
}, 3, "", true)));
Set(N_16, "live24", Call(ext_50, V.Undef, ((V)("live22")), Fn((V _arrowThis1751, int _argc1742, V o_1748, V on_1749, V R_1750, V _a1747, V[] _rest1743) => {
V WAL_1752 = default;
V SAP_1753 = default;
V ST_1754 = default;
double TY_1755 = 0;
double YT_1756 = 0;
V outl_1757 = default;
V pin_1758 = default;
V SW_1759 = default;
V HW_1760 = default;
V BW_1761 = default;
V CF_1762 = default;
V CU_1763 = default;
WAL_1752 = ((V)("#6e4226"));
SAP_1753 = ((V)("#d9b07c"));
ST_1754 = ((V)("#232428"));
TY_1755 = 26.4;
YT_1756 = (TY_1755 + 4D);
outl_1757 = Fn((V _arrowThis1773, int _argc1764, V a_1770, V b_1771, V g_1772, V _a1769, V[] _rest1765) => {
return Call(rep_28, V.Undef, ((V)(32D)), Fn((V _arrowThis1781, int _argc1774, V i_1780, V _a1777, V _a1778, V _a1779, V[] _rest1775) => {
double t_1782 = 0;
double c_1783 = 0;
double s_1784 = 0;
double w_1785 = 0;
t_1782 = (((ToNum(i_1780) / 32D) * 2D) * PI_17);
c_1783 = FdLibm.Cos(t_1782);
s_1784 = FdLibm.Sin(t_1782);
w_1785 = (1D + ((ToNum(g_1772) * ((0.05 * FdLibm.Sin(((5D * t_1782) + 1D))) + (0.03 * FdLibm.Sin(((9D * t_1782) + 2D))))) * System.Math.Abs(s_1784)));
return Arr(((V)(((ToNum(a_1770) * Sign(c_1783)) * Pow(System.Math.Abs(c_1783), 0.32)))), ((V)((((ToNum(b_1771) * w_1785) * Sign(s_1784)) * Pow(System.Math.Abs(s_1784), 0.8)))));
return default;
}, 1, "", true));
}, 3, "", true);
pin_1758 = Fn((V _arrowThis1795, int _argc1786, V P_1792, V x_1793, V z_1794, V _a1791, V[] _rest1787) => {
V c_1796 = default;
c_1796 = (false ? V.True : V.False);
{
double i_1797 = 0;
double j_1798 = 0;
i_1797 = 0D;
j_1798 = (ToNum(Get(P_1792, "length")) - 1D);
while (true) {
if (!(Lt(((V)(i_1797)), Get(P_1792, "length")))) break;
V xi_1800 = default;
V zi_1801 = default;
V xj_1802 = default;
V zj_1803 = default;
{ V _t1804 = GetIdx(P_1792, i_1797);
{ V _t1805 = ListOf(_t1804);
{ V _t1806 = GetIdx(_t1805, 0D);
xi_1800 = _t1806; }
{ V _t1807 = GetIdx(_t1805, 1D);
zi_1801 = _t1807; }
} }
{ V _t1808 = GetIdx(P_1792, j_1798);
{ V _t1809 = ListOf(_t1808);
{ V _t1810 = GetIdx(_t1809, 0D);
xj_1802 = _t1810; }
{ V _t1811 = GetIdx(_t1809, 1D);
zj_1803 = _t1811; }
} }
if ((!SEq((Gt(zi_1801, z_1794) ? V.True : V.False), (Gt(zj_1803, z_1794) ? V.True : V.False)) && Lt(x_1793, Add(((V)((((ToNum(xj_1802) - ToNum(xi_1800)) * (ToNum(z_1794) - ToNum(zi_1801))) / (ToNum(zj_1803) - ToNum(zi_1801))))), xi_1800)))) {
c_1796 = (!(Truthy(c_1796)) ? V.True : V.False);
}
j_1798 = i_1797++;
}
}
return c_1796;
return default;
}, 3, "", true);
SW_1759 = Call(at_49, V.Undef, o_1748, Arr(((V)(40D)), ((V)((TY_1755 + 1.5))), ((V)(0D))), SAP_1753);
HW_1760 = (SW_1759 is var _t1820 && !Truthy(_t1820) ? _t1820 : Invoke(o_1748, "find", Fn((V _arrowThis1819, int _argc1812, V S_1818, V _a1815, V _a1816, V _a1817, V[] _rest1813) => {
return ((SEq(Get(S_1818, "col"), WAL_1752) && SEq(Get(S_1818, "par"), SW_1759)) ? V.True : V.False);
}, 1, "", true)));
if (Truthy(HW_1760)) {
V IN_1821 = default;
V G1_1822 = default;
V G2_1823 = default;
V KN_1824 = default;
V KR_1825 = default;
V CK_1826 = default;
V SH_1827 = default;
V knots_1828 = default;
V BT_1829 = default;
IN_1821 = Call(outl_1757, V.Undef, ((V)(54D)), ((V)(23.4)), ((V)(1.4)));
G1_1822 = Call(dec_44, V.Undef, ((V)("#3a1f0e")), NewObj(1).Put("op", ((V)(0.5))).V);
G2_1823 = Call(dec_44, V.Undef, ((V)("#a06a3c")), NewObj(1).Put("op", ((V)(0.45))).V);
KN_1824 = Call(dec_44, V.Undef, ((V)("#24120a")), NewObj(1).Put("op", ((V)(0.85))).V);
KR_1825 = Call(dec_44, V.Undef, ((V)("#4a2a14")), NewObj(1).Put("op", ((V)(0.6))).V);
CK_1826 = Call(dec_44, V.Undef, ((V)("#1c0f06")), NewObj(1).Put("op", ((V)(0.92))).V);
SH_1827 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.12))).V);
knots_1828 = Arr(Arr(((V)(18D)), ((V)(8D)), ((V)(1.6)), ((V)(1D))), Arr(((V)((-36D))), ((V)((-9D))), ((V)(1.1)), ((V)(0.7))));
Call(rep_28, V.Undef, ((V)(14D)), Fn((V _arrowThis1837, int _argc1830, V k_1836, V _a1833, V _a1834, V _a1835, V[] _rest1831) => {
double z0_1838 = 0;
double ph_1839 = 0;
V D_1840 = default;
V cur_1841 = default;
V fl_1842 = default;
z0_1838 = (((-22D) + (ToNum(k_1836) * 3.4)) + (ToNum(Call(R_1750, V.Undef)) - 0.5));
ph_1839 = (ToNum(Call(R_1750, V.Undef)) * 6D);
D_1840 = (NumTruthy((ToNum(k_1836) % 2D)) ? G2_1823 : G1_1822);
cur_1841 = Arr();
fl_1842 = Fn((V _arrowThis1849, int _argc1843, V _a1845, V _a1846, V _a1847, V _a1848, V[] _rest1844) => {
if (GtN(Get(cur_1841, "length"), 1D)) {
Invoke(D_1840, "line", cur_1841, Y3_40, ((V)((NumTruthy((ToNum(k_1836) % 2D)) ? 0.3 : 0.4))), ((V)(1D)));
}
cur_1841 = Arr();
return default;
}, 0, "", true);
{
double i_1850 = 0;
i_1850 = 0D;
while (true) {
if (!((i_1850 <= 60D))) break;
double x_1852 = 0;
double z_1853 = 0;
x_1852 = ((-54D) + (i_1850 * 1.8));
z_1853 = ((z0_1838 + (1.6 * FdLibm.Sin(((x_1852 * 0.06) + ph_1839)))) + (0.7 * FdLibm.Sin(((x_1852 * 0.17) + (2D * ph_1839)))));
Invoke(knots_1828, "forEach", Fn((V _arrowThis1867, int _argc1854, V _a1856, V _a1857, V _a1858, V _a1859, V[] _rest1855) => {
double d_1868 = 0;
double f_1869 = 0;
V kx_1862 = default;
V kz_1864 = default;
V a_1866 = default;
{ V _t1860 = ListOf(_a1856);
{ V _t1861 = GetIdx(_t1860, 0D);
kx_1862 = _t1861; }
{ V _t1863 = GetIdx(_t1860, 1D);
kz_1864 = _t1863; }
{ V _t1865 = GetIdx(_t1860, 2D);
a_1866 = _t1865; }
}
d_1868 = (z_1853 - ToNum(kz_1864));
f_1869 = FdLibm.Exp(((-((x_1852 - ToNum(kx_1862)) * (x_1852 - ToNum(kx_1862)))) / (30D * ToNum(a_1866))));
if ((System.Math.Abs(d_1868) < 7D)) {
z_1853 = (z_1853 + (((Sign(ToNum((((V)(d_1868)) is var _t1870 && Truthy(_t1870) ? _t1870 : ((V)(1D))))) * f_1869) * (7D - System.Math.Abs(d_1868))) * 0.6));
}
return default;
}, 1, "", true));
if (Truthy(Call(pin_1758, V.Undef, IN_1821, ((V)(x_1852)), ((V)(z_1853))))) {
Invoke(cur_1841, "push", Arr(((V)(x_1852)), ((V)(YT_1756)), ((V)(z_1853))));
} else {
Call(fl_1842, V.Undef);
}
i_1850++;
}
}
Call(fl_1842, V.Undef);
return default;
}, 1, "", true));
Invoke(knots_1828, "forEach", Fn((V _arrowThis1886, int _argc1871, V _a1873, V _a1874, V _a1875, V _a1876, V[] _rest1872) => {
V x_1879 = default;
V z_1881 = default;
V a_1883 = default;
V b_1885 = default;
{ V _t1877 = ListOf(_a1873);
{ V _t1878 = GetIdx(_t1877, 0D);
x_1879 = _t1878; }
{ V _t1880 = GetIdx(_t1877, 1D);
z_1881 = _t1880; }
{ V _t1882 = GetIdx(_t1877, 2D);
a_1883 = _t1882; }
{ V _t1884 = GetIdx(_t1877, 3D);
b_1885 = _t1884; }
}
Call(spot_46, V.Undef, KN_1824, Arr(x_1879, ((V)(YT_1756)), z_1881), Y3_40, a_1883, b_1885, ((V)(0.1)), ((V)(12D)));
Invoke(Arr(((V)(1.7)), ((V)(2.5)), ((V)(3.4))), "forEach", Fn((V _arrowThis1894, int _argc1887, V k_1893, V _a1890, V _a1891, V _a1892, V[] _rest1888) => {
return Invoke(KR_1825, "line", Call(wv_43, V.Undef, ((V)(22D)), Fn((V _arrowThis1902, int _argc1895, V t_1901, V _a1898, V _a1899, V _a1900, V[] _rest1896) => {
return Arr(Add(x_1879, ((V)(((FdLibm.Cos(((ToNum(t_1901) * 2D) * PI_17)) * ToNum(a_1883)) * ToNum(k_1893))))), ((V)(YT_1756)), Add(z_1881, ((V)((((FdLibm.Sin(((ToNum(t_1901) * 2D) * PI_17)) * ToNum(b_1885)) * ToNum(k_1893)) * 1.25)))));
}, 1, "", true)), Y3_40, ((V)(0.22)));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(CK_1826, "line", Arr(Arr(((V)((-12D))), ((V)(YT_1756)), ((V)(23.6))), Arr(((V)((-12.6))), ((V)(YT_1756)), ((V)(20D))), Arr(((V)((-11.4))), ((V)(YT_1756)), ((V)(14D))), Arr(((V)((-12.2))), ((V)(YT_1756)), ((V)(9.6))), Arr(((V)((-11.6))), ((V)(YT_1756)), ((V)(6.6))), Arr(((V)((-12.6))), ((V)(YT_1756)), ((V)(3.4))), Arr(((V)((-13.6))), ((V)(YT_1756)), ((V)((-1.6)))), Arr(((V)((-14.2))), ((V)(YT_1756)), ((V)((-5D))))), Y3_40, ((V)(0.6)), ((V)(1D)));
Invoke(SH_1827, "poly", Arr(Arr(((V)((-40D))), ((V)(YT_1756)), ((V)(18D))), Arr(((V)((-30D))), ((V)(YT_1756)), ((V)(18D))), Arr(((V)((-14D))), ((V)(YT_1756)), ((V)((-16D)))), Arr(((V)((-24D))), ((V)(YT_1756)), ((V)((-16D))))), Y3_40);
BT_1829 = Invoke(o_1748, "filter", Fn((V _arrowThis1910, int _argc1903, V S_1909, V _a1906, V _a1907, V _a1908, V[] _rest1904) => {
return ((SEq(Get(S_1909, "par"), HW_1760) && SEqS(Get(S_1909, "col"), "#2e1a0c")) ? V.True : V.False);
}, 1, "", true));
Invoke(BT_1829, "forEach", Fn((V _arrowThis1918, int _argc1911, V S_1917, V _a1914, V _a1915, V _a1916, V[] _rest1912) => {
return Invoke(o_1748, "splice", Invoke(o_1748, "indexOf", S_1917), ((V)(1D)));
}, 1, "", true));
Call(on_1749, V.Undef, HW_1760, Arr(G1_1822, G2_1823, KR_1825, KN_1824, SH_1827, CK_1826));
Invoke(BT_1829, "forEach", Fn((V _arrowThis1926, int _argc1919, V S_1925, V _a1922, V _a1923, V _a1924, V[] _rest1920) => {
return Invoke(o_1748, "push", S_1925);
}, 1, "", true));
}
if (Truthy(SW_1759)) {
V SR_1927 = default;
V SL_1928 = default;
V BKk_1929 = default;
V close_1930 = default;
SR_1927 = Call(dec_44, V.Undef, ((V)("#b8844e")), NewObj(1).Put("op", ((V)(0.6))).V);
SL_1928 = Call(dec_44, V.Undef, ((V)("#f2d4a4")), NewObj(1).Put("op", ((V)(0.6))).V);
BKk_1929 = Call(dec_44, V.Undef, ((V)("#4a2e18")), NewObj(1).Put("op", ((V)(0.7))).V);
close_1930 = Fn((V _arrowThis1938, int _argc1931, V P_1937, V _a1934, V _a1935, V _a1936, V[] _rest1932) => {
return Invoke(P_1937, "concat", Arr(GetIdx(P_1937, 0D)));
}, 1, "", true);
Invoke(SR_1927, "line", Invoke(Call(close_1930, V.Undef, Call(outl_1757, V.Undef, ((V)(56D)), ((V)(26.3)), ((V)(1.2)))), "map", Fn((V _arrowThis1950, int _argc1939, V _a1941, V _a1942, V _a1943, V _a1944, V[] _rest1940) => {
V x_1947 = default;
V z_1949 = default;
{ V _t1945 = ListOf(_a1941);
{ V _t1946 = GetIdx(_t1945, 0D);
x_1947 = _t1946; }
{ V _t1948 = GetIdx(_t1945, 1D);
z_1949 = _t1948; }
}
return Arr(x_1947, ((V)((TY_1755 + 3D))), z_1949);
}, 1, "", true)), Y3_40, ((V)(0.3)));
Invoke(SL_1928, "line", Invoke(Call(close_1930, V.Undef, Call(outl_1757, V.Undef, ((V)(56.6)), ((V)(27.3)), ((V)(1.1)))), "map", Fn((V _arrowThis1962, int _argc1951, V _a1953, V _a1954, V _a1955, V _a1956, V[] _rest1952) => {
V x_1959 = default;
V z_1961 = default;
{ V _t1957 = ListOf(_a1953);
{ V _t1958 = GetIdx(_t1957, 0D);
x_1959 = _t1958; }
{ V _t1960 = GetIdx(_t1957, 1D);
z_1961 = _t1960; }
}
return Arr(x_1959, ((V)((TY_1755 + 3D))), z_1961);
}, 1, "", true)), Y3_40, ((V)(0.22)));
Invoke(Call(outl_1757, V.Undef, ((V)(56.7)), ((V)(27.4)), ((V)(1.1))), "forEach", Fn((V _arrowThis1975, int _argc1963, V _a1965, V i_1969, V _a1967, V _a1968, V[] _rest1964) => {
V x_1972 = default;
V z_1974 = default;
{ V _t1970 = ListOf(_a1965);
{ V _t1971 = GetIdx(_t1970, 0D);
x_1972 = _t1971; }
{ V _t1973 = GetIdx(_t1970, 1D);
z_1974 = _t1973; }
}
if (((ToNum(i_1969) % 3D) == 0D)) {
Call(spot_46, V.Undef, BKk_1929, Arr(x_1972, ((V)((TY_1755 + 3D))), z_1974), Y3_40, ((V)((0.6 + (ToNum(Call(R_1750, V.Undef)) * 0.6)))), ((V)(0.3)), ((V)((FdLibm.Atan2(ToNum(z_1974), ToNum(x_1972)) + (PI_17 / 2D)))), ((V)(6D)));
}
return default;
}, 2, "", true));
Call(on_1749, V.Undef, SW_1759, Arr(SR_1927, SL_1928, BKk_1929));
}
Invoke(Arr(((V)((-40D))), ((V)(40D))), "forEach", Fn((V _arrowThis1983, int _argc1976, V x_1982, V _a1979, V _a1980, V _a1981, V[] _rest1977) => {
return Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1991, int _argc1984, V sz_1990, V _a1987, V _a1988, V _a1989, V[] _rest1985) => {
V L_1992 = default;
V HL_1993 = default;
L_1992 = Call(at_49, V.Undef, o_1748, Arr(x_1982, ((V)(12D)), ((V)((ToNum(sz_1990) * 20D)))), ST_1754);
if (!(Truthy(L_1992))) {
return default;
}
HL_1993 = Call(dec_44, V.Undef, ((V)("#5a5c62")), NewObj(1).Put("op", ((V)(0.85))).V);
Invoke(Invoke(HL_1993, "line", Arr(Arr(((V)((ToNum(x_1982) - 0.8))), ((V)(3D)), ((V)(((ToNum(sz_1990) * 20D) + 1.5)))), Arr(((V)((ToNum(x_1982) - 0.8))), ((V)((TY_1755 - 3D))), ((V)(((ToNum(sz_1990) * 20D) + 1.5))))), Z3_41, ((V)(0.3))), "line", Arr(Arr(Add(x_1982, ((V)(1.5))), ((V)(3D)), ((V)(((ToNum(sz_1990) * 20D) - 0.8)))), Arr(Add(x_1982, ((V)(1.5))), ((V)((TY_1755 - 3D))), ((V)(((ToNum(sz_1990) * 20D) - 0.8))))), X3_39, ((V)(0.25)));
Call(on_1749, V.Undef, L_1992, Arr(HL_1993));
return default;
}, 1, "", true));
}, 1, "", true));
BW_1761 = Call(at_49, V.Undef, o_1748, Arr(((V)(33D)), ((V)((TY_1755 + 6D))), ((V)((-4D)))), ((V)("#8a5a34")));
if (Truthy(BW_1761)) {
V L1_1994 = default;
V L2_1995 = default;
L1_1994 = Call(dec_44, V.Undef, ((V)("#a87448")), NewObj(1).Put("op", ((V)(0.7))).V);
L2_1995 = Call(dec_44, V.Undef, ((V)("#5e3a1e")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(ringC_52, V.Undef, L1_1994, ((V)(26D)), ((V)((-4D))), ((V)(8.5)), ((V)((TY_1755 + 6.2))), ((V)(0.35)), ((V)(36D)));
Call(ringC_52, V.Undef, L2_1995, ((V)(26D)), ((V)((-4D))), ((V)(8.95)), ((V)((TY_1755 + 7.6))), ((V)(0.3)), ((V)(36D)));
Call(ringC_52, V.Undef, L1_1994, ((V)(26D)), ((V)((-4D))), ((V)(7.4)), ((V)((TY_1755 + 5D))), ((V)(0.25)), ((V)(36D)));
Call(on_1749, V.Undef, BW_1761, Arr(L2_1995, L1_1994));
}
Invoke(Arr(Arr(((V)("#5f9a4a")), ((V)(23D)), ((V)((-5D)))), Arr(((V)("#7fb25a")), ((V)(26D)), ((V)((-2.4)))), Arr(((V)("#4f8a3e")), ((V)(29D)), ((V)((-5D))))), "forEach", Fn((V _arrowThis2009, int _argc1996, V _a1998, V _a1999, V _a2000, V _a2001, V[] _rest1997) => {
V M_2010 = default;
V c_2011 = default;
V D1_2012 = default;
V D2_2013 = default;
V col_2004 = default;
V x_2006 = default;
V z_2008 = default;
{ V _t2002 = ListOf(_a1998);
{ V _t2003 = GetIdx(_t2002, 0D);
col_2004 = _t2003; }
{ V _t2005 = GetIdx(_t2002, 1D);
x_2006 = _t2005; }
{ V _t2007 = GetIdx(_t2002, 2D);
z_2008 = _t2007; }
}
M_2010 = Call(at_49, V.Undef, o_1748, Arr(x_2006, ((V)((TY_1755 + 10.4))), z_2008), col_2004);
if (!(Truthy(M_2010))) {
return default;
}
c_2011 = Arr(x_2006, ((V)((TY_1755 + 10.4))), z_2008);
D1_2012 = Call(dec_44, V.Undef, Call(shade_14, V.Undef, col_2004, ((V)(0.7))), NewObj(1).Put("op", ((V)(0.7))).V);
D2_2013 = Call(dec_44, V.Undef, Call(shade_14, V.Undef, col_2004, ((V)(1.3))), NewObj(1).Put("op", ((V)(0.7))).V);
Call(rep_28, V.Undef, ((V)(22D)), Fn((V _arrowThis2021, int _argc2014, V j_2020, V _a2017, V _a2018, V _a2019, V[] _rest2015) => {
double a_2022 = 0;
double b_2023 = 0;
V n_2024 = default;
a_2022 = ((ToNum(Call(R_1750, V.Undef)) * 2D) * PI_17);
b_2023 = ((ToNum(Call(R_1750, V.Undef)) - 0.2) * 1.3);
n_2024 = Arr(((V)((FdLibm.Cos(a_2022) * FdLibm.Cos(b_2023)))), ((V)(FdLibm.Sin(b_2023))), ((V)((FdLibm.Sin(a_2022) * FdLibm.Cos(b_2023)))));
Call(spot_46, V.Undef, (NumTruthy((ToNum(j_2020) % 2D)) ? D1_2012 : D2_2013), Call(add_34, V.Undef, c_2011, Call(mul_36, V.Undef, n_2024, ((V)(3.02)))), n_2024, ((V)(0.3)), ((V)(0.3)), ((V)(0D)), ((V)(5D)));
return default;
}, 1, "", true));
Call(on_1749, V.Undef, M_2010, Arr(D1_2012, D2_2013));
return default;
}, 1, "", true));
CF_1762 = Call(at_49, V.Undef, o_1748, Arr(((V)((-30D))), ((V)((TY_1755 + 9.85))), ((V)((-6D)))), ((V)("#5a3418")));
CU_1763 = Call(at_49, V.Undef, o_1748, Arr(((V)((-27.5))), ((V)((TY_1755 + 6D))), ((V)((-6D)))), ((V)("#f2efe8")));
if (Truthy(CF_1762)) {
V LA_2025 = default;
LA_2025 = Call(dec_44, V.Undef, ((V)("#e8d2b0")));
Invoke(LA_2025, "poly", Arr(Arr(((V)((-30D))), ((V)((TY_1755 + 10D))), ((V)((-4.6)))), Arr(((V)((-31.3))), ((V)((TY_1755 + 10D))), ((V)((-6D)))), Arr(((V)((-31.2))), ((V)((TY_1755 + 10D))), ((V)((-7D)))), Arr(((V)((-30.5))), ((V)((TY_1755 + 10D))), ((V)((-7.4)))), Arr(((V)((-30D))), ((V)((TY_1755 + 10D))), ((V)((-6.8)))), Arr(((V)((-29.5))), ((V)((TY_1755 + 10D))), ((V)((-7.4)))), Arr(((V)((-28.8))), ((V)((TY_1755 + 10D))), ((V)((-7D)))), Arr(((V)((-28.7))), ((V)((TY_1755 + 10D))), ((V)((-6D))))), Y3_40);
Call(on_1749, V.Undef, CF_1762, Arr(LA_2025));
}
if (Truthy(CU_1763)) {
Call(on_1749, V.Undef, CU_1763, Call(pipe_23, V.Undef, Arr(Arr(((V)((-27.1))), ((V)((TY_1755 + 8.4))), ((V)((-6D)))), Arr(((V)((-25.2))), ((V)((TY_1755 + 8D))), ((V)((-6D)))), Arr(((V)((-25.2))), ((V)((TY_1755 + 5.8))), ((V)((-6D)))), Arr(((V)((-27.1))), ((V)((TY_1755 + 5.4))), ((V)((-6D))))), ((V)(0.5)), ((V)("#f2efe8")), NewObj(2).Put("mat", ((V)("cer"))).Put("n", ((V)(5D))).V));
}
if (Truthy(HW_1760)) {
V BKs_2026 = default;
V T_2027 = default;
Call(on_1749, V.Undef, HW_1760, Arr(Call(rod_22, V.Undef, Arr(((V)((-24D))), ((V)((YT_1756 + 0.3))), ((V)((-2.6)))), Arr(((V)((-20D))), ((V)((YT_1756 + 0.3))), ((V)(1.8))), ((V)(0.25)), CH_19, Call(M__24, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)), Call(ball_13, V.Undef, ((V)((-24.6))), ((V)(YT_1756)), ((V)((-3.4))), ((V)(1D)), CH_19, NewObj(6).Put("sx", ((V)(0.7))).Put("sy", ((V)(0.3))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("mat", ((V)("metal"))).Put("yaw", ((V)(0.8))).V)));
BKs_2026 = Call(book_33, V.Undef, ((V)((-4D))), ((V)(YT_1756)), ((V)((-12D))), ((V)(18D)), ((V)(2.4)), ((V)(13D)), ((V)("#3f6a5a")), ((V)(0.25)));
Set(GetIdx(BKs_2026, 0D), "par", HW_1760);
Invoke(o_1748, "push", GetIdx(BKs_2026, 0D), GetIdx(BKs_2026, 1D));
T_2027 = Call(dec_44, V.Undef, ((V)("#e2b14a")), NewObj(1).Put("op", ((V)(0.9))).V);
Invoke(T_2027, "poly", Call(rrect_47, V.Undef, ((V)((-4D))), ((V)((YT_1756 + 2.4))), ((V)((-12D))), ((V)(10D)), ((V)(1D)), ((V)(0.25)), ((V)(0D)), ((V)(2D))), Y3_40);
Call(Call(glue_31, V.Undef, o_1748), V.Undef, GetIdx(BKs_2026, 0D), Arr(T_2027));
}
return default;
}, 3, "", true), NewObj(1).Put("fx", V.Undef).V));
Set(N_16, "drum24", Call(ext_50, V.Undef, ((V)("drum22")), Fn((V _arrowThis2037, int _argc2028, V o_2034, V on_2035, V R_2036, V _a2033, V[] _rest2029) => {
V TV_2038 = default;
V BZ_2039 = default;
V T_2040 = default;
V B_2041 = default;
V BW_2042 = default;
V BK_2043 = default;
TV_2038 = ((V)("#eadcc2"));
BZ_2039 = ((V)("#4e3e32"));
T_2040 = Call(at_49, V.Undef, o_2034, Arr(((V)(16D)), ((V)(15D)), ((V)((-6D)))), TV_2038);
if (Truthy(T_2040)) {
double cx_2044 = 0;
double cz_2045 = 0;
double r_2046 = 0;
V P_2047 = default;
V S1_2048 = default;
V S2_2049 = default;
V PO_2050 = default;
V TVn_2051 = default;
V BV_2052 = default;
cx_2044 = (-12D);
cz_2045 = (-6D);
r_2046 = 30.02;
P_2047 = Fn((V _arrowThis2061, int _argc2053, V a_2059, V y_2060, V _a2057, V _a2058, V[] _rest2054) => {
return Arr(((V)((cx_2044 + (FdLibm.Cos(ToNum(a_2059)) * r_2046)))), y_2060, ((V)((cz_2045 + (FdLibm.Sin(ToNum(a_2059)) * r_2046)))));
}, 2, "", true);
S1_2048 = Call(dec_44, V.Undef, ((V)("#c2aa80")), NewObj(1).Put("op", ((V)(0.6))).V);
S2_2049 = Call(dec_44, V.Undef, ((V)("#fbf3e4")), NewObj(1).Put("op", ((V)(0.65))).V);
PO_2050 = Call(dec_44, V.Undef, ((V)("#a89070")), NewObj(1).Put("op", ((V)(0.75))).V);
Call(rep_28, V.Undef, ((V)(13D)), Fn((V _arrowThis2069, int _argc2062, V k_2068, V _a2065, V _a2066, V _a2067, V[] _rest2063) => {
double y0_2070 = 0;
double ph_2071 = 0;
V D_2072 = default;
double w_2073 = 0;
double a_2074 = 0;
double end_2075 = 0;
y0_2070 = ((1.8 + (ToNum(k_2068) * 2.15)) + ((ToNum(Call(R_2036, V.Undef)) - 0.5) * 0.6));
ph_2071 = (ToNum(Call(R_2036, V.Undef)) * 6D);
D_2072 = (((ToNum(k_2068) % 3D) == 1D) ? S2_2049 : S1_2048);
w_2073 = (((ToNum(k_2068) % 3D) == 1D) ? 0.32 : (0.2 + (ToNum(Call(R_2036, V.Undef)) * 0.22)));
a_2074 = ((ToNum(Call(R_2036, V.Undef)) * 2D) * PI_17);
end_2075 = (a_2074 + (2D * PI_17));
while ((a_2074 < (end_2075 - 0.3))) {
double len_2076 = 0;
V A_2077 = default;
len_2076 = Min((end_2075 - a_2074), (0.5 + (ToNum(Call(R_2036, V.Undef)) * 1.6)));
A_2077 = Call(wv_43, V.Undef, ((V)(Max(3D, System.Math.Ceiling((len_2076 * 10D))))), Fn((V _arrowThis2085, int _argc2078, V t_2084, V _a2081, V _a2082, V _a2083, V[] _rest2079) => {
return ((V)((a_2074 + (len_2076 * ToNum(t_2084)))));
}, 1, "", true));
Invoke(D_2072, "line", Invoke(A_2077, "map", Fn((V _arrowThis2093, int _argc2086, V q_2092, V _a2089, V _a2090, V _a2091, V[] _rest2087) => {
return Call(P_2047, V.Undef, q_2092, ((V)(((y0_2070 + (0.35 * FdLibm.Sin(((ToNum(q_2092) * 3D) + ph_2071)))) + (0.2 * FdLibm.Sin(((ToNum(q_2092) * 11D) + ph_2071)))))));
}, 1, "", true)), Invoke(A_2077, "map", cN_42), ((V)(w_2073)), ((V)(1D)));
a_2074 = (a_2074 + ((len_2076 + 0.15) + (ToNum(Call(R_2036, V.Undef)) * 0.5)));
}
return default;
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(80D)), Fn((V _arrowThis2100, int _argc2094, V _a2096, V _a2097, V _a2098, V _a2099, V[] _rest2095) => {
double a_2101 = 0;
double y_2102 = 0;
a_2101 = ((ToNum(Call(R_2036, V.Undef)) * 2D) * PI_17);
y_2102 = (1D + (ToNum(Call(R_2036, V.Undef)) * 28D));
Call(spot_46, V.Undef, PO_2050, Call(P_2047, V.Undef, ((V)(a_2101)), ((V)(y_2102))), Call(cN_42, V.Undef, ((V)(a_2101))), ((V)((0.25 + (ToNum(Call(R_2036, V.Undef)) * 0.7)))), ((V)((0.12 + (ToNum(Call(R_2036, V.Undef)) * 0.18)))), ((V)(0D)), ((V)(6D)));
return default;
}, 0, "", true));
TVn_2051 = Call(dec_44, V.Undef, ((V)("#cdb894")), NewObj(1).Put("op", ((V)(0.55))).V);
BV_2052 = Call(dec_44, V.Undef, ((V)("#fff8ec")), NewObj(1).Put("op", ((V)(0.7))).V);
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis2110, int _argc2103, V k_2109, V _a2106, V _a2107, V _a2108, V[] _rest2104) => {
double z0_2111 = 0;
double ph_2112 = 0;
V L_2113 = default;
z0_2111 = (((-26D) + (ToNum(k_2109) * 9D)) + (ToNum(Call(R_2036, V.Undef)) * 3D));
ph_2112 = (ToNum(Call(R_2036, V.Undef)) * 6D);
L_2113 = Invoke(Call(wv_43, V.Undef, ((V)(30D)), Fn((V _arrowThis2129, int _argc2122, V t_2128, V _a2125, V _a2126, V _a2127, V[] _rest2123) => {
return Arr(((V)(((cx_2044 - 28D) + (56D * ToNum(t_2128))))), ((V)(30D)), ((V)(((cz_2045 + z0_2111) + (1.6 * FdLibm.Sin(((ToNum(t_2128) * 6D) + ph_2112)))))));
}, 1, "", true)), "filter", Fn((V _arrowThis2121, int _argc2114, V p_2120, V _a2117, V _a2118, V _a2119, V[] _rest2115) => {
return ((Hypot((ToNum(GetIdx(p_2120, 0D)) - cx_2044), (ToNum(GetIdx(p_2120, 2D)) - cz_2045)) < 28.5) ? V.True : V.False);
}, 1, "", true));
if (GtN(Get(L_2113, "length"), 1D)) {
Invoke(TVn_2051, "line", L_2113, Y3_40, ((V)(0.3)), ((V)(1D)));
}
return default;
}, 1, "", true));
Call(ringY_51, V.Undef, BV_2052, ((V)(cx_2044)), ((V)(cz_2045)), ((V)(29.4)), ((V)(30D)), ((V)(0.5)), ((V)(56D)));
Call(on_2035, V.Undef, T_2040, Arr(S1_2048, S2_2049, PO_2050, TVn_2051, BV_2052));
}
B_2041 = Call(at_49, V.Undef, o_2034, Arr(((V)(48D)), ((V)(10D)), ((V)(16D))), BZ_2039);
if (Truthy(B_2041)) {
V BL_2130 = default;
V BD_2131 = default;
V TR_2132 = default;
BL_2130 = Call(dec_44, V.Undef, ((V)("#6e5a48")), NewObj(1).Put("op", ((V)(0.5))).V);
BD_2131 = Call(dec_44, V.Undef, ((V)("#2e241e")), NewObj(1).Put("op", ((V)(0.35))).V);
TR_2132 = Call(dec_44, V.Undef, ((V)("#7a6654")), NewObj(1).Put("op", ((V)(0.45))).V);
Call(rep_28, V.Undef, ((V)(80D)), Fn((V _arrowThis2140, int _argc2133, V i_2139, V _a2136, V _a2137, V _a2138, V[] _rest2134) => {
double a_2141 = 0;
double y0_2142 = 0;
double y1_2143 = 0;
a_2141 = ((((ToNum(i_2139) / 80D) * 2D) * PI_17) + (ToNum(Call(R_2036, V.Undef)) * 0.03));
y0_2142 = (0.4 + (ToNum(Call(R_2036, V.Undef)) * 3D));
y1_2143 = (19.8 - (ToNum(Call(R_2036, V.Undef)) * 4D));
Invoke(BL_2130, "line", Arr(Arr(((V)((32D + (FdLibm.Cos(a_2141) * 17.02)))), ((V)(y0_2142)), ((V)((16D + (FdLibm.Sin(a_2141) * 17.02))))), Arr(((V)((32D + (FdLibm.Cos(a_2141) * 17.02)))), ((V)(y1_2143)), ((V)((16D + (FdLibm.Sin(a_2141) * 17.02)))))), Call(cN_42, V.Undef, ((V)(a_2141))), ((V)((0.14 + (ToNum(Call(R_2036, V.Undef)) * 0.12)))));
return default;
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(14D)), Fn((V _arrowThis2150, int _argc2144, V _a2146, V _a2147, V _a2148, V _a2149, V[] _rest2145) => {
double a_2151 = 0;
double y_2152 = 0;
a_2151 = ((ToNum(Call(R_2036, V.Undef)) * 2D) * PI_17);
y_2152 = (2D + (ToNum(Call(R_2036, V.Undef)) * 16D));
Call(spot_46, V.Undef, BD_2131, Arr(((V)((32D + (FdLibm.Cos(a_2151) * 17.03)))), ((V)(y_2152)), ((V)((16D + (FdLibm.Sin(a_2151) * 17.03))))), Call(cN_42, V.Undef, ((V)(a_2151))), ((V)((1.2 + (ToNum(Call(R_2036, V.Undef)) * 2.4)))), ((V)((0.8 + (ToNum(Call(R_2036, V.Undef)) * 1.6)))), ((V)(0D)));
return default;
}, 0, "", true));
Invoke(Arr(((V)(8D)), ((V)(9.6)), ((V)(11.2)), ((V)(12.8)), ((V)(14.4)), ((V)(15.8))), "forEach", Fn((V _arrowThis2160, int _argc2153, V rr_2159, V _a2156, V _a2157, V _a2158, V[] _rest2154) => {
return Call(ringY_51, V.Undef, TR_2132, ((V)(32D)), ((V)(16D)), rr_2159, ((V)(21D)), ((V)(0.18)), ((V)(40D)));
}, 1, "", true));
Call(on_2035, V.Undef, B_2041, Arr(BL_2130, BD_2131, TR_2132));
}
BW_2042 = Call(at_49, V.Undef, o_2034, Arr(((V)((32D + 6D))), ((V)(23D)), ((V)(16D))), ((V)("#f2efe8")));
if (Truthy(BW_2042)) {
Call(on_2035, V.Undef, BW_2042, Arr(Call(ball_13, V.Undef, ((V)(30.4)), ((V)(25D)), ((V)(15.2)), ((V)(2D)), ((V)("#6b6e70")), NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V), Call(ball_13, V.Undef, ((V)(33.6)), ((V)(25D)), ((V)(17.4)), ((V)(1.6)), ((V)("#a29484")), NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V), Call(ball_13, V.Undef, ((V)(33.8)), ((V)(25D)), ((V)(13.4)), ((V)(1.3)), ((V)("#3e4144")), NewObj(3).Put("sy", ((V)(0.55))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)));
}
BK_2043 = Call(at_49, V.Undef, o_2034, Arr(((V)((-28D))), ((V)(31.3)), ((V)(4D))), ((V)("#2f4f5a")));
if (Truthy(BK_2043)) {
V E_2161 = default;
E_2161 = Call(dec_44, V.Undef, ((V)("#e2b14a")), NewObj(1).Put("op", ((V)(0.9))).V);
Invoke(Invoke(E_2161, "poly", Call(rrect_47, V.Undef, ((V)((-28D))), ((V)(32.6)), ((V)(4D)), ((V)(12D)), ((V)(1D)), ((V)(0.2)), ((V)(0D)), ((V)((-3D)))), Y3_40), "poly", Call(rrect_47, V.Undef, ((V)((-28D))), ((V)(32.6)), ((V)(4D)), ((V)(7D)), ((V)(0.6)), ((V)(0.2)), ((V)(0D)), ((V)((-1.2)))), Y3_40);
Call(on_2035, V.Undef, BK_2043, Arr(E_2161));
}
return default;
}, 3, "", true)));
Set(N_16, "crate24", Call(ext_50, V.Undef, ((V)("crate22")), Fn((V _arrowThis2171, int _argc2162, V o_2168, V on_2169, V R_2170, V _a2167, V[] _rest2163) => {
V RED_2172 = default;
double W_2173 = 0;
double H_2174 = 0;
double Dp_2175 = 0;
double zf_2176 = 0;
double xf_2177 = 0;
V C_2178 = default;
V CU_2179 = default;
V PH_2180 = default;
V CB_2181 = default;
RED_2172 = ((V)("#d9363b"));
W_2173 = 34D;
H_2174 = 30D;
Dp_2175 = 30D;
zf_2176 = (Dp_2175 / 2D);
xf_2177 = (W_2173 / 2D);
C_2178 = Call(at_49, V.Undef, o_2168, Arr(((V)(0D)), ((V)(15D)), ((V)(0D))), RED_2172);
if (Truthy(C_2178)) {
V LT_2182 = default;
V DK_2183 = default;
V SC_2184 = default;
V XZ_2185 = default;
V LB_2186 = default;
V LC_2187 = default;
LT_2182 = Call(dec_44, V.Undef, ((V)("#f2777a")), NewObj(1).Put("op", ((V)(0.9))).V);
DK_2183 = Call(dec_44, V.Undef, ((V)("#6e1216")), NewObj(1).Put("op", ((V)(0.6))).V);
SC_2184 = Call(dec_44, V.Undef, ((V)("#f6e6e0")), NewObj(1).Put("op", ((V)(0.35))).V);
XZ_2185 = Call(mul_36, V.Undef, X3_39, ((V)(1D)));
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis2195, int _argc2188, V i_2194, V _a2191, V _a2192, V _a2193, V[] _rest2189) => {
return Call(rep_28, V.Undef, ((V)(2D)), Fn((V _arrowThis2203, int _argc2196, V j_2202, V _a2199, V _a2200, V _a2201, V[] _rest2197) => {
double x_2204 = 0;
double y_2205 = 0;
x_2204 = ((-10D) + (ToNum(i_2194) * 10D));
y_2205 = (6D + (ToNum(j_2202) * 10D));
Invoke(LT_2182, "line", Arr(Arr(((V)((x_2204 - 3D))), ((V)((y_2205 + 0.25))), ((V)((zf_2176 + 0.25)))), Arr(((V)((x_2204 + 3D))), ((V)((y_2205 + 0.25))), ((V)((zf_2176 + 0.25))))), Z3_41, ((V)(0.5)));
Invoke(Invoke(DK_2183, "line", Arr(Arr(((V)((x_2204 - 3D))), ((V)((y_2205 + 6.75))), ((V)((zf_2176 + 0.25)))), Arr(((V)((x_2204 + 3D))), ((V)((y_2205 + 6.75))), ((V)((zf_2176 + 0.25))))), Z3_41, ((V)(0.5))), "line", Arr(Arr(((V)((x_2204 - 3.25))), ((V)((y_2205 + 1D))), ((V)((zf_2176 + 0.25)))), Arr(((V)((x_2204 - 3.25))), ((V)((y_2205 + 6.5))), ((V)((zf_2176 + 0.25))))), Z3_41, ((V)(0.4)));
return default;
}, 1, "", true));
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis2213, int _argc2206, V i_2212, V _a2209, V _a2210, V _a2211, V[] _rest2207) => {
return Call(rep_28, V.Undef, ((V)(2D)), Fn((V _arrowThis2221, int _argc2214, V j_2220, V _a2217, V _a2218, V _a2219, V[] _rest2215) => {
double z_2222 = 0;
double y_2223 = 0;
z_2222 = ((-9D) + (ToNum(i_2212) * 9D));
y_2223 = (6D + (ToNum(j_2220) * 10D));
Invoke(LT_2182, "line", Arr(Arr(((V)((xf_2177 + 0.25))), ((V)((y_2223 + 0.25))), ((V)((z_2222 - 2.7)))), Arr(((V)((xf_2177 + 0.25))), ((V)((y_2223 + 0.25))), ((V)((z_2222 + 2.7))))), XZ_2185, ((V)(0.5)));
Invoke(DK_2183, "line", Arr(Arr(((V)((xf_2177 + 0.25))), ((V)((y_2223 + 6.75))), ((V)((z_2222 - 2.7)))), Arr(((V)((xf_2177 + 0.25))), ((V)((y_2223 + 6.75))), ((V)((z_2222 + 2.7))))), XZ_2185, ((V)(0.5)));
return default;
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis2231, int _argc2224, V s_2230, V _a2227, V _a2228, V _a2229, V[] _rest2225) => {
Invoke(LT_2182, "line", Arr(Arr(((V)((ToNum(s_2230) * (xf_2177 - 2.2)))), ((V)(1.5)), ((V)(zf_2176))), Arr(((V)((ToNum(s_2230) * (xf_2177 - 2.2)))), ((V)((H_2174 - 2D))), ((V)(zf_2176)))), Z3_41, ((V)(0.5)));
Invoke(DK_2183, "line", Arr(Arr(((V)((ToNum(s_2230) * (xf_2177 - 3.1)))), ((V)(1.5)), ((V)(zf_2176))), Arr(((V)((ToNum(s_2230) * (xf_2177 - 3.1)))), ((V)((H_2174 - 2D))), ((V)(zf_2176)))), Z3_41, ((V)(0.35)));
Invoke(LT_2182, "line", Arr(Arr(((V)(xf_2177)), ((V)(1.5)), ((V)((ToNum(s_2230) * (zf_2176 - 2.2))))), Arr(((V)(xf_2177)), ((V)((H_2174 - 2D))), ((V)((ToNum(s_2230) * (zf_2176 - 2.2)))))), XZ_2185, ((V)(0.5)));
Invoke(DK_2183, "line", Arr(Arr(((V)(xf_2177)), ((V)(1.5)), ((V)((ToNum(s_2230) * (zf_2176 - 3.1))))), Arr(((V)(xf_2177)), ((V)((H_2174 - 2D))), ((V)((ToNum(s_2230) * (zf_2176 - 3.1)))))), XZ_2185, ((V)(0.35)));
return default;
}, 1, "", true));
Invoke(Invoke(LT_2182, "line", Arr(Arr(((V)(((-xf_2177) + 2.4))), ((V)((H_2174 - 1.1))), ((V)(zf_2176))), Arr(((V)((xf_2177 - 2.4))), ((V)((H_2174 - 1.1))), ((V)(zf_2176)))), Z3_41, ((V)(0.5))), "line", Arr(Arr(((V)(xf_2177)), ((V)((H_2174 - 1.1))), ((V)(((-zf_2176) + 2.4)))), Arr(((V)(xf_2177)), ((V)((H_2174 - 1.1))), ((V)((zf_2176 - 2.4))))), XZ_2185, ((V)(0.5)));
Invoke(Invoke(Invoke(DK_2183, "line", Arr(Arr(((V)(((-xf_2177) + 2.4))), ((V)((H_2174 - 2.2))), ((V)(zf_2176))), Arr(((V)((xf_2177 - 2.4))), ((V)((H_2174 - 2.2))), ((V)(zf_2176)))), Z3_41, ((V)(0.35))), "line", Arr(Arr(((V)(((-xf_2177) + 2.4))), ((V)(1.3)), ((V)(zf_2176))), Arr(((V)((xf_2177 - 2.4))), ((V)(1.3)), ((V)(zf_2176)))), Z3_41, ((V)(0.5))), "line", Arr(Arr(((V)(xf_2177)), ((V)(1.3)), ((V)(((-zf_2176) + 2.4)))), Arr(((V)(xf_2177)), ((V)(1.3)), ((V)((zf_2176 - 2.4))))), XZ_2185, ((V)(0.5)));
Call(rep_28, V.Undef, ((V)(10D)), Fn((V _arrowThis2238, int _argc2232, V _a2234, V _a2235, V _a2236, V _a2237, V[] _rest2233) => {
double x_2239 = 0;
double y_2240 = 0;
double a_2241 = 0;
double L_2242 = 0;
x_2239 = ((ToNum(Call(R_2170, V.Undef)) - 0.5) * 28D);
y_2240 = (2D + (ToNum(Call(R_2170, V.Undef)) * 26D));
a_2241 = ((ToNum(Call(R_2170, V.Undef)) - 0.5) * 0.8);
L_2242 = (1D + (ToNum(Call(R_2170, V.Undef)) * 3D));
Invoke(SC_2184, "line", Arr(Arr(((V)(x_2239)), ((V)(y_2240)), ((V)((zf_2176 + 0.1)))), Arr(((V)((x_2239 + (FdLibm.Cos(a_2241) * L_2242)))), ((V)((y_2240 + (FdLibm.Sin(a_2241) * L_2242)))), ((V)((zf_2176 + 0.1))))), Z3_41, ((V)(0.2)));
return default;
}, 0, "", true));
Call(rep_28, V.Undef, ((V)(8D)), Fn((V _arrowThis2249, int _argc2243, V _a2245, V _a2246, V _a2247, V _a2248, V[] _rest2244) => {
double z_2250 = 0;
double y_2251 = 0;
double a_2252 = 0;
double L_2253 = 0;
z_2250 = ((ToNum(Call(R_2170, V.Undef)) - 0.5) * 26D);
y_2251 = (2D + (ToNum(Call(R_2170, V.Undef)) * 26D));
a_2252 = ((ToNum(Call(R_2170, V.Undef)) - 0.5) * 0.8);
L_2253 = (1D + (ToNum(Call(R_2170, V.Undef)) * 3D));
Invoke(SC_2184, "line", Arr(Arr(((V)((xf_2177 + 0.1))), ((V)(y_2251)), ((V)(z_2250))), Arr(((V)((xf_2177 + 0.1))), ((V)((y_2251 + (FdLibm.Sin(a_2252) * L_2253)))), ((V)((z_2250 + (FdLibm.Cos(a_2252) * L_2253)))))), XZ_2185, ((V)(0.2)));
return default;
}, 0, "", true));
LB_2186 = Call(dec_44, V.Undef, ((V)("#f4f0e6")));
LC_2187 = Call(dec_44, V.Undef, ((V)("#2a2d34")));
Invoke(LB_2186, "poly", Arr(Arr(((V)((xf_2177 + 0.3))), ((V)(13.3)), ((V)((-5D)))), Arr(((V)((xf_2177 + 0.3))), ((V)(13.3)), ((V)(5D))), Arr(((V)((xf_2177 + 0.3))), ((V)(15.7)), ((V)(5D))), Arr(((V)((xf_2177 + 0.3))), ((V)(15.7)), ((V)((-5D))))), XZ_2185);
Call(rep_28, V.Undef, ((V)(12D)), Fn((V _arrowThis2261, int _argc2254, V i_2260, V _a2257, V _a2258, V _a2259, V[] _rest2255) => {
return Invoke(LC_2187, "line", Arr(Arr(((V)((xf_2177 + 0.3))), ((V)(13.7)), ((V)(((-1D) + (ToNum(i_2260) * 0.45))))), Arr(((V)((xf_2177 + 0.3))), ((V)(15.3)), ((V)(((-1D) + (ToNum(i_2260) * 0.45)))))), XZ_2185, ((V)((NumTruthy((ToNum(i_2260) % 3D)) ? 0.14 : 0.28))));
}, 1, "", true));
Invoke(LC_2187, "line", Arr(Arr(((V)((xf_2177 + 0.3))), ((V)(14.5)), ((V)((-4.4)))), Arr(((V)((xf_2177 + 0.3))), ((V)(14.5)), ((V)((-2D))))), XZ_2185, ((V)(0.3)));
Call(on_2169, V.Undef, C_2178, Arr(LT_2182, DK_2183, SC_2184, LB_2186, LC_2187));
}
CU_2179 = Call(at_49, V.Undef, o_2168, Arr(((V)(9D)), ((V)((H_2174 + 5.6))), ((V)(4D))), ((V)("#fbf6ec")));
if (Truthy(CU_2179)) {
V YW_2262 = default;
V RD2_2263 = default;
V TX_2264 = default;
V rr_2265 = default;
YW_2262 = Call(dec_44, V.Undef, ((V)("#f2c230")));
RD2_2263 = Call(dec_44, V.Undef, ((V)("#e8402a")));
TX_2264 = Call(dec_44, V.Undef, ((V)("#3a2a22")), NewObj(1).Put("op", ((V)(0.8))).V);
rr_2265 = Fn((V _arrowThis2273, int _argc2266, V y_2272, V _a2269, V _a2270, V _a2271, V[] _rest2267) => {
return ((V)(((4.6 * (0.78 + ((0.22 * (ToNum(y_2272) - H_2174)) / 8.4))) + 0.03)));
}, 1, "", true);
Invoke(YW_2262, "line", Call(wv_43, V.Undef, ((V)(30D)), Fn((V _arrowThis2281, int _argc2274, V t_2280, V _a2277, V _a2278, V _a2279, V[] _rest2275) => {
double a_2282 = 0;
a_2282 = ((ToNum(t_2280) * 2D) * PI_17);
return Arr(((V)((5D + (FdLibm.Cos(a_2282) * ToNum(Call(rr_2265, V.Undef, ((V)((H_2174 + 6.4))))))))), ((V)(((H_2174 + 6.4) + (FdLibm.Sin((a_2282 * 6D)) * 0.35)))), ((V)((4D + (FdLibm.Sin(a_2282) * ToNum(Call(rr_2265, V.Undef, ((V)((H_2174 + 6.4))))))))));
return default;
}, 1, "", true)), Call(wv_43, V.Undef, ((V)(30D)), Fn((V _arrowThis2290, int _argc2283, V t_2289, V _a2286, V _a2287, V _a2288, V[] _rest2284) => {
return Call(cN_42, V.Undef, ((V)(((ToNum(t_2289) * 2D) * PI_17))));
}, 1, "", true)), ((V)(0.9)));
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis2298, int _argc2291, V i_2297, V _a2294, V _a2295, V _a2296, V[] _rest2292) => {
double a_2299 = 0;
a_2299 = (0.4 + (ToNum(i_2297) * 0.3));
Call(spot_46, V.Undef, RD2_2263, Arr(((V)((5D + (FdLibm.Cos(a_2299) * ToNum(Call(rr_2265, V.Undef, ((V)((H_2174 + 1.6))))))))), ((V)((H_2174 + 1.6))), ((V)((4D + (FdLibm.Sin(a_2299) * ToNum(Call(rr_2265, V.Undef, ((V)((H_2174 + 1.6)))))))))), Call(cN_42, V.Undef, ((V)(a_2299))), ((V)(0.35)), ((V)(0.35)), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
Invoke(Arr(((V)(1.2)), ((V)(1.7)), ((V)(2.2))), "forEach", Fn((V _arrowThis2308, int _argc2300, V a_2306, V i_2307, V _a2304, V _a2305, V[] _rest2301) => {
return Invoke(TX_2264, "line", Arr(Arr(((V)((5D + (FdLibm.Cos(ToNum(a_2306)) * ToNum(Call(rr_2265, V.Undef, ((V)((H_2174 + 7.4))))))))), ((V)(((H_2174 + 7.4) - (ToNum(i_2307) * 0.02)))), ((V)((4D + (FdLibm.Sin(ToNum(a_2306)) * ToNum(Call(rr_2265, V.Undef, ((V)((H_2174 + 7.4)))))))))), Arr(((V)((5D + (FdLibm.Cos(ToNum(Add(a_2306, ((V)(0.3))))) * ToNum(Call(rr_2265, V.Undef, ((V)((H_2174 + 7.4))))))))), ((V)((H_2174 + 7.4))), ((V)((4D + (FdLibm.Sin(ToNum(Add(a_2306, ((V)(0.3))))) * ToNum(Call(rr_2265, V.Undef, ((V)((H_2174 + 7.4))))))))))), Call(cN_42, V.Undef, Add(a_2306, ((V)(0.15)))), ((V)(0.3)));
}, 2, "", true));
Call(on_2169, V.Undef, CU_2179, Arr(YW_2262, RD2_2263, TX_2264));
}
PH_2180 = Call(at_49, V.Undef, o_2168, Arr(((V)((-6D))), ((V)((H_2174 + 0.35))), ((V)((-6D)))), ((V)("#2a2d34")));
if (Truthy(PH_2180)) {
V SCR_2309 = default;
V BAR_2310 = default;
V IC_2311 = default;
SCR_2309 = Call(dec_44, V.Undef, ((V)("#5d8fd8")), NewObj(1).Put("emit", ((V)(1D))).V);
BAR_2310 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.85))).V);
IC_2311 = Call(dec_44, V.Undef, ((V)("#9fe27a")), NewObj(1).Put("emit", ((V)(1D))).V);
Invoke(SCR_2309, "poly", Call(rrect_47, V.Undef, ((V)((-6D))), ((V)((H_2174 + 0.72))), ((V)((-6D))), ((V)(3.8)), ((V)(8D)), ((V)(0.4))), Y3_40);
Invoke(BAR_2310, "poly", Call(rrect_47, V.Undef, ((V)((-6D))), ((V)((H_2174 + 0.74))), ((V)((-6D))), ((V)(3.2)), ((V)(1.2)), ((V)(0.4)), ((V)(0D)), ((V)((-2.6)))), Y3_40);
Invoke(Invoke(IC_2311, "poly", Call(rrect_47, V.Undef, ((V)((-6D))), ((V)((H_2174 + 0.74))), ((V)((-6D))), ((V)(0.9)), ((V)(0.9)), ((V)(0.4)), ((V)((-1D))), ((V)(0.6))), Y3_40), "poly", Call(rrect_47, V.Undef, ((V)((-6D))), ((V)((H_2174 + 0.74))), ((V)((-6D))), ((V)(0.9)), ((V)(0.9)), ((V)(0.4)), ((V)(0.4)), ((V)(0.6))), Y3_40);
Call(on_2169, V.Undef, PH_2180, Arr(SCR_2309, BAR_2310, IC_2311));
}
CB_2181 = Call(at_49, V.Undef, o_2168, Arr(((V)((((-W_2173) / 2D) - 0.8))), ((V)(15D)), ((V)(7D))), ((V)("#f4f4f4")));
if (Truthy(CB_2181)) {
Call(on_2169, V.Undef, CB_2181, Arr(Call(box_11, V.Undef, ((V)((((-W_2173) / 2D) - 0.8))), ((V)(1D)), ((V)(8.1)), ((V)(1.6)), ((V)(2.6)), ((V)(1.4)), ((V)("#f4f4f4")), Call(PL_27, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(rod_22, V.Undef, Arr(((V)((((-W_2173) / 2D) - 1.3))), ((V)(0.2)), ((V)(8.1))), Arr(((V)((((-W_2173) / 2D) - 1.3))), ((V)(1.1)), ((V)(8.1))), ((V)(0.18)), ((V)("#c9ced3")), Call(M__24, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)), Call(rod_22, V.Undef, Arr(((V)((((-W_2173) / 2D) - 0.3))), ((V)(0.2)), ((V)(8.1))), Arr(((V)((((-W_2173) / 2D) - 0.3))), ((V)(1.1)), ((V)(8.1))), ((V)(0.18)), ((V)("#c9ced3")), Call(M__24, V.Undef, NewObj(1).Put("n", ((V)(4D))).V))));
}
return default;
}, 3, "", true)));
Set(N_16, "bistro24", Call(ext_50, V.Undef, ((V)("bistro22")), Fn((V _arrowThis2321, int _argc2312, V o_2318, V on_2319, V R_2320, V _a2317, V[] _rest2313) => {
V WH_2322 = default;
V TP_2323 = default;
V SM_2324 = default;
V BS_2325 = default;
V TU_2326 = default;
V VS_2327 = default;
V SAU_2328 = default;
V CUP_2329 = default;
V RIM_2330 = default;
V SR_2331 = default;
WH_2322 = ((V)("#f7f5f0"));
TP_2323 = Call(at_49, V.Undef, o_2318, Arr(((V)(15D)), ((V)(37D)), ((V)(0D))), WH_2322);
if (Truthy(TP_2323)) {
V E_2332 = default;
V Gs_2333 = default;
V Sd_2334 = default;
V Rf_2335 = default;
E_2332 = Call(dec_44, V.Undef, ((V)("#cfccc4")), NewObj(1).Put("op", ((V)(0.6))).V);
Gs_2333 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.95))).V);
Sd_2334 = Call(dec_44, V.Undef, ((V)("#dcd8cf")), NewObj(1).Put("op", ((V)(0.55))).V);
Rf_2335 = Call(dec_44, V.Undef, ((V)("#e3e0d8")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(ringY_51, V.Undef, E_2332, ((V)(0D)), ((V)(0D)), ((V)(18.3)), ((V)(38.4)), ((V)(0.35)), ((V)(48D)));
Call(ringC_52, V.Undef, Sd_2334, ((V)(0D)), ((V)(0D)), ((V)(19.02)), ((V)(36.5)), ((V)(0.6)), ((V)(48D)));
Invoke(Rf_2335, "poly", Invoke(Call(wv_43, V.Undef, ((V)(16D)), Fn((V _arrowThis2352, int _argc2345, V t_2351, V _a2348, V _a2349, V _a2350, V[] _rest2346) => {
double a_2353 = 0;
a_2353 = (3.6 + (ToNum(t_2351) * 1.6));
return Arr(((V)((FdLibm.Cos(a_2353) * 16.5))), ((V)(38.4)), ((V)((FdLibm.Sin(a_2353) * 16.5))));
return default;
}, 1, "", true)), "concat", Call(wv_43, V.Undef, ((V)(16D)), Fn((V _arrowThis2343, int _argc2336, V t_2342, V _a2339, V _a2340, V _a2341, V[] _rest2337) => {
double a_2344 = 0;
a_2344 = (5.2 - (ToNum(t_2342) * 1.6));
return Arr(((V)((FdLibm.Cos(a_2344) * 12.5))), ((V)(38.4)), ((V)((FdLibm.Sin(a_2344) * 12.5))));
return default;
}, 1, "", true))), Y3_40);
Invoke(Gs_2333, "poly", Arr(Arr(((V)((-14D))), ((V)(38.4)), ((V)(8D))), Arr(((V)((-10D))), ((V)(38.4)), ((V)(10D))), Arr(((V)(4D)), ((V)(38.4)), ((V)((-12D)))), Arr(((V)(0D)), ((V)(38.4)), ((V)((-14D))))), Y3_40);
Call(on_2319, V.Undef, TP_2323, Arr(E_2332, Rf_2335, Gs_2333, Sd_2334));
}
SM_2324 = Call(at_49, V.Undef, o_2318, Arr(((V)(2.8)), ((V)(17D)), ((V)(0D))), WH_2322);
if (Truthy(SM_2324)) {
V HL_2354 = default;
V SD_2355 = default;
HL_2354 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.95))).V);
SD_2355 = Call(dec_44, V.Undef, ((V)("#d6d2c9")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Arr(Arr(((V)(2.5)), HL_2354, ((V)(0.6))), Arr(((V)(0.9)), SD_2355, ((V)(0.8))), Arr(((V)((-0.3))), SD_2355, ((V)(0.5)))), "forEach", Fn((V _arrowThis2369, int _argc2356, V _a2358, V _a2359, V _a2360, V _a2361, V[] _rest2357) => {
V a_2364 = default;
V D_2366 = default;
V w_2368 = default;
{ V _t2362 = ListOf(_a2358);
{ V _t2363 = GetIdx(_t2362, 0D);
a_2364 = _t2363; }
{ V _t2365 = GetIdx(_t2362, 1D);
D_2366 = _t2365; }
{ V _t2367 = GetIdx(_t2362, 2D);
w_2368 = _t2367; }
}
return Invoke(D_2366, "line", Arr(Arr(((V)((FdLibm.Cos(ToNum(a_2364)) * 3.02))), ((V)(7D)), ((V)((FdLibm.Sin(ToNum(a_2364)) * 3.02)))), Arr(((V)((FdLibm.Cos(ToNum(a_2364)) * 3.02))), ((V)(28D)), ((V)((FdLibm.Sin(ToNum(a_2364)) * 3.02))))), Call(cN_42, V.Undef, a_2364), w_2368);
}, 1, "", true));
Call(on_2319, V.Undef, SM_2324, Arr(SD_2355, HL_2354));
}
BS_2325 = Call(at_49, V.Undef, o_2318, Arr(((V)(12.4)), ((V)(1D)), ((V)(0D))), WH_2322);
if (Truthy(BS_2325)) {
V GR_2370 = default;
GR_2370 = Call(dec_44, V.Undef, ((V)("#cfccc4")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(ringY_51, V.Undef, GR_2370, ((V)(0D)), ((V)(0D)), ((V)(11.4)), ((V)(2.4)), ((V)(0.3)), ((V)(48D)));
Call(on_2319, V.Undef, BS_2325, Arr(Call(band_29, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(13.04)), ((V)(0.5)), ((V)("#8a8780")), NewObj(2).Put("n", ((V)(30D))).Put("noOut", ((V)(1D))).V), GR_2370));
}
TU_2326 = Call(at_49, V.Undef, o_2318, Arr(((V)((-4.2))), ((V)(55D)), ((V)((-2.4)))), ((V)("#ff6f8a")));
if (Truthy(TU_2326)) {
V STM_2371 = default;
Invoke(Arr(((V)(0D)), ((V)(2.1)), ((V)(4.2))), "forEach", Fn((V _arrowThis2380, int _argc2372, V a_2378, V i_2379, V _a2376, V _a2377, V[] _rest2373) => {
return Call(on_2319, V.Undef, TU_2326, Arr(Call(ball_13, V.Undef, ((V)(((-4.2) + (FdLibm.Cos(ToNum(a_2378)) * 1.1)))), ((V)(53.6)), ((V)(((-2.4) + (FdLibm.Sin(ToNum(a_2378)) * 1.1)))), ((V)(1.45)), ((V)((NumTruthy((ToNum(i_2379) % 2D)) ? "#f2557a" : "#ff8fa6"))), NewObj(3).Put("sy", ((V)(1.75))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)), Call(cN_42, V.Undef, a_2378));
}, 2, "", true));
STM_2371 = Call(at_49, V.Undef, o_2318, Arr(((V)((-4.6))), ((V)(49D)), ((V)((-2.2)))), ((V)("#5f9a4a")));
if (Truthy(STM_2371)) {
Call(on_2319, V.Undef, STM_2371, Arr(Call(ball_13, V.Undef, ((V)((-3D))), ((V)(47.2)), ((V)((-2.8))), ((V)(1.3)), ((V)("#5f9a4a")), NewObj(4).Put("sx", ((V)(0.6))).Put("sy", ((V)(1.9))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
}
}
VS_2327 = Call(at_49, V.Undef, o_2318, Arr(((V)((-3D))), ((V)(42D)), ((V)((-2D)))), ((V)("#bfe2ee")));
if (Truthy(VS_2327)) {
V WL_2381 = default;
WL_2381 = Call(dec_44, V.Undef, ((V)("#8fc4dc")), NewObj(1).Put("op", ((V)(0.8))).V);
Call(ringC_52, V.Undef, WL_2381, ((V)((-5D))), ((V)((-2D))), ((V)(2.45)), ((V)(43.5)), ((V)(0.3)), ((V)(20D)));
Call(on_2319, V.Undef, VS_2327, Arr(WL_2381));
}
SAU_2328 = Call(cyl_12, V.Undef, ((V)(8D)), ((V)(38.4)), ((V)((-7.5))), ((V)(4.4)), ((V)(0.6)), ((V)("#f2ede4")), NewObj(3).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.82))), Arr(((V)(0.6)), ((V)(0D)), ((V)(1D))))).V);
CUP_2329 = Call(cyl_12, V.Undef, ((V)(8D)), ((V)(39D)), ((V)((-7.5))), ((V)(2.7)), ((V)(3.4)), ((V)("#eef3f6")), NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(3.4)), ((V)(0D)), ((V)(1D))))).V);
Invoke(o_2318, "push", SAU_2328, CUP_2329);
RIM_2330 = Call(dec_44, V.Undef, ((V)("#e2b14a")), NewObj(1).Put("op", ((V)(0.9))).V);
Call(ringC_52, V.Undef, RIM_2330, ((V)(8D)), ((V)((-7.5))), ((V)(2.72)), ((V)(42.1)), ((V)(0.25)), ((V)(20D)));
SR_2331 = Call(dec_44, V.Undef, ((V)("#e2b14a")), NewObj(1).Put("op", ((V)(0.9))).V);
Call(ringY_51, V.Undef, SR_2331, ((V)(8D)), ((V)((-7.5))), ((V)(3.9)), ((V)(39D)), ((V)(0.2)), ((V)(24D)));
Call(Call(glue_31, V.Undef, o_2318), V.Undef, SAU_2328, Arr(SR_2331));
Call(Call(glue_31, V.Undef, o_2318), V.Undef, CUP_2329, Invoke(Arr(Call(cyl_12, V.Undef, ((V)(8D)), ((V)(42.2)), ((V)((-7.5))), ((V)(2.45)), ((V)(0.2)), ((V)("#b8743a")), NewObj(2).Put("n", ((V)(14D))).Put("noOut", ((V)(1D))).V), RIM_2330), "concat", Call(pipe_23, V.Undef, Arr(Arr(((V)(10.6)), ((V)(41.6)), ((V)((-7.5)))), Arr(((V)(12.2)), ((V)(41.2)), ((V)((-7.5)))), Arr(((V)(12.2)), ((V)(39.8)), ((V)((-7.5)))), Arr(((V)(10.4)), ((V)(39.5)), ((V)((-7.5))))), ((V)(0.32)), ((V)("#eef3f6")), NewObj(2).Put("mat", ((V)("cer"))).Put("n", ((V)(5D))).V)));
return default;
}, 3, "", true)));
Set(N_16, "tambour24", Call(ext_50, V.Undef, ((V)("tambour22")), Fn((V _arrowThis2391, int _argc2382, V o_2388, V on_2389, V R_2390, V _a2387, V[] _rest2383) => {
V OK_2392 = default;
V OL_2393 = default;
V OD_2394 = default;
double W_2395 = 0;
double Dp_2396 = 0;
double BY_2397 = 0;
double BH_2398 = 0;
double TY_2399 = 0;
V TP_2400 = default;
V BD_2401 = default;
double yaw_2402 = 0;
double c_2403 = 0;
double s_2404 = 0;
V BKs_2405 = default;
V RB_2406 = default;
V fz_2407 = default;
V fn_2408 = default;
V TT_2409 = default;
OK_2392 = ((V)("#cd9a60"));
OL_2393 = Call(shade_14, V.Undef, OK_2392, ((V)(1.12)));
OD_2394 = Call(shade_14, V.Undef, OK_2392, ((V)(0.7)));
W_2395 = 40D;
Dp_2396 = 36D;
BY_2397 = 6D;
BH_2398 = 36D;
TY_2399 = ((BY_2397 + BH_2398) + 2.4);
TP_2400 = Call(at_49, V.Undef, o_2388, Arr(((V)(0D)), ((V)((TY_2399 - 1.2))), ((V)(0D))), OL_2393);
BD_2401 = Call(at_49, V.Undef, o_2388, Arr(((V)(0D)), ((V)((BY_2397 + (BH_2398 / 2D)))), ((V)(0D))), OK_2392);
if (Truthy(TP_2400)) {
V G1_2410 = default;
V G2_2411 = default;
V KN_2412 = default;
V WR_2413 = default;
G1_2410 = Call(dec_44, V.Undef, ((V)("#a0703c")), NewObj(1).Put("op", ((V)(0.5))).V);
G2_2411 = Call(dec_44, V.Undef, ((V)("#f2cc94")), NewObj(1).Put("op", ((V)(0.45))).V);
KN_2412 = Call(dec_44, V.Undef, ((V)("#6a4220")), NewObj(1).Put("op", ((V)(0.75))).V);
WR_2413 = Call(dec_44, V.Undef, ((V)("#9a7044")), NewObj(1).Put("op", ((V)(0.3))).V);
Call(rep_28, V.Undef, ((V)(12D)), Fn((V _arrowThis2421, int _argc2414, V k_2420, V _a2417, V _a2418, V _a2419, V[] _rest2415) => {
double z0_2422 = 0;
double ph_2423 = 0;
z0_2422 = ((-17.5) + (ToNum(k_2420) * 3.1));
ph_2423 = (ToNum(Call(R_2390, V.Undef)) * 6D);
Invoke((NumTruthy((ToNum(k_2420) % 2D)) ? G2_2411 : G1_2410), "line", Call(wv_43, V.Undef, ((V)(26D)), Fn((V _arrowThis2431, int _argc2424, V t_2430, V _a2427, V _a2428, V _a2429, V[] _rest2425) => {
double x_2432 = 0;
double z_2433 = 0;
double d_2434 = 0;
double f_2435 = 0;
x_2432 = ((-20D) + (40D * ToNum(t_2430)));
z_2433 = ((z0_2422 + (0.9 * FdLibm.Sin(((x_2432 * 0.12) + ph_2423)))) + (0.4 * FdLibm.Sin(((x_2432 * 0.4) + ph_2423))));
d_2434 = (z_2433 - (-9D));
f_2435 = FdLibm.Exp(((-((x_2432 - 10D) * (x_2432 - 10D))) / 18D));
if ((System.Math.Abs(d_2434) < 5D)) {
z_2433 = (z_2433 + (((Sign(ToNum((((V)(d_2434)) is var _t2436 && Truthy(_t2436) ? _t2436 : ((V)(1D))))) * f_2435) * (5D - System.Math.Abs(d_2434))) * 0.6));
}
return Arr(((V)(x_2432)), ((V)(TY_2399)), ((V)(Max((-18.6), Min(18.6, z_2433)))));
return default;
}, 1, "", true)), Y3_40, ((V)((NumTruthy((ToNum(k_2420) % 2D)) ? 0.28 : 0.36))), ((V)(1D)));
return default;
}, 1, "", true));
Call(spot_46, V.Undef, KN_2412, Arr(((V)(10D)), ((V)(TY_2399)), ((V)((-9D)))), Y3_40, ((V)(0.9)), ((V)(0.55)), ((V)(0D)), ((V)(10D)));
Invoke(KN_2412, "line", Call(wv_43, V.Undef, ((V)(16D)), Fn((V _arrowThis2444, int _argc2437, V t_2443, V _a2440, V _a2441, V _a2442, V[] _rest2438) => {
return Arr(((V)((10D + (FdLibm.Cos(((ToNum(t_2443) * 2D) * PI_17)) * 1.6)))), ((V)(TY_2399)), ((V)(((-9D) + (FdLibm.Sin(((ToNum(t_2443) * 2D) * PI_17)) * 1.1)))));
}, 1, "", true)), Y3_40, ((V)(0.2)));
Call(ringY_51, V.Undef, WR_2413, ((V)((-9D))), ((V)(7D)), ((V)(3D)), ((V)(TY_2399)), ((V)(0.35)), ((V)(24D)));
Call(on_2389, V.Undef, TP_2400, Arr(G1_2410, G2_2411, WR_2413, KN_2412));
}
if (Truthy(BD_2401)) {
V G1_2445 = default;
V G2_2446 = default;
V SL_2447 = default;
G1_2445 = Call(dec_44, V.Undef, ((V)("#9a6a38")), NewObj(1).Put("op", ((V)(0.45))).V);
G2_2446 = Call(dec_44, V.Undef, ((V)("#ecc28a")), NewObj(1).Put("op", ((V)(0.4))).V);
Invoke(Arr(((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis2455, int _argc2448, V s_2454, V _a2451, V _a2452, V _a2453, V[] _rest2449) => {
return Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis2463, int _argc2456, V k_2462, V _a2459, V _a2460, V _a2461, V[] _rest2457) => {
double z0_2464 = 0;
double ph_2465 = 0;
z0_2464 = ((-14D) + (ToNum(k_2462) * 5.6));
ph_2465 = (ToNum(Call(R_2390, V.Undef)) * 6D);
Invoke((NumTruthy((ToNum(k_2462) % 2D)) ? G2_2446 : G1_2445), "line", Call(wv_43, V.Undef, ((V)(14D)), Fn((V _arrowThis2473, int _argc2466, V t_2472, V _a2469, V _a2470, V _a2471, V[] _rest2467) => {
double y_2474 = 0;
y_2474 = ((BY_2397 + 1D) + ((BH_2398 - 2D) * ToNum(t_2472)));
return Arr(((V)(((ToNum(s_2454) * W_2395) / 2D))), ((V)(y_2474)), ((V)((z0_2464 + (0.8 * FdLibm.Sin(((y_2474 * 0.2) + ph_2465)))))));
return default;
}, 1, "", true)), Call(mul_36, V.Undef, X3_39, s_2454), ((V)(0.3)), ((V)(1D)));
return default;
}, 1, "", true));
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis2482, int _argc2475, V k_2481, V _a2478, V _a2479, V _a2480, V[] _rest2476) => {
double x0_2483 = 0;
double ph_2484 = 0;
x0_2483 = ((-16D) + (ToNum(k_2481) * 6.4));
ph_2484 = (ToNum(Call(R_2390, V.Undef)) * 6D);
Invoke(G1_2445, "line", Call(wv_43, V.Undef, ((V)(14D)), Fn((V _arrowThis2492, int _argc2485, V t_2491, V _a2488, V _a2489, V _a2490, V[] _rest2486) => {
double y_2493 = 0;
y_2493 = ((BY_2397 + 1D) + ((BH_2398 - 2D) * ToNum(t_2491)));
return Arr(((V)((x0_2483 + (0.8 * FdLibm.Sin(((y_2493 * 0.2) + ph_2484)))))), ((V)(y_2493)), ((V)(((-Dp_2396) / 2D))));
return default;
}, 1, "", true)), Call(mul_36, V.Undef, Z3_41, ((V)((-1D)))), ((V)(0.3)), ((V)(1D)));
return default;
}, 1, "", true));
Invoke(Arr(((V)((BY_2397 + 1.2))), ((V)(((BY_2397 + BH_2398) - 1.4)))), "forEach", Fn((V _arrowThis2502, int _argc2494, V y_2500, V k_2501, V _a2498, V _a2499, V[] _rest2495) => {
Invoke(G1_2445, "line", Call(wv_43, V.Undef, ((V)(16D)), Fn((V _arrowThis2510, int _argc2503, V t_2509, V _a2506, V _a2507, V _a2508, V[] _rest2504) => {
return Arr(((V)(((-18.4) + (36.8 * ToNum(t_2509))))), Add(y_2500, ((V)((0.3 * FdLibm.Sin(ToNum(Add(((V)((ToNum(t_2509) * 9D))), k_2501))))))), ((V)((Dp_2396 / 2D))));
}, 1, "", true)), Z3_41, ((V)(0.25)), ((V)(1D)));
Invoke(G2_2446, "line", Call(wv_43, V.Undef, ((V)(16D)), Fn((V _arrowThis2518, int _argc2511, V t_2517, V _a2514, V _a2515, V _a2516, V[] _rest2512) => {
return Arr(((V)(((-18.4) + (36.8 * ToNum(t_2517))))), Add(Add(y_2500, ((V)(0.8))), ((V)((0.25 * FdLibm.Sin(ToNum(Add(((V)((ToNum(t_2517) * 7D))), k_2501))))))), ((V)((Dp_2396 / 2D))));
}, 1, "", true)), Z3_41, ((V)(0.2)), ((V)(1D)));
return default;
}, 2, "", true));
SL_2447 = Call(dec_44, V.Undef, ((V)("#f6d6a4")), NewObj(1).Put("op", ((V)(0.75))).V);
Call(rep_28, V.Undef, ((V)(10D)), Fn((V _arrowThis2526, int _argc2519, V i_2525, V _a2522, V _a2523, V _a2524, V[] _rest2520) => {
double x_2527 = 0;
double a_2528 = 0;
x_2527 = ((-0.6) + (ToNum(i_2525) * 2.3));
a_2528 = 2D;
Invoke(SL_2447, "line", Arr(Arr(((V)((x_2527 + (FdLibm.Cos(a_2528) * 1.16)))), ((V)((BY_2397 + 3.4))), ((V)((((Dp_2396 / 2D) + 0.05) + (FdLibm.Sin(a_2528) * 1.16))))), Arr(((V)((x_2527 + (FdLibm.Cos(a_2528) * 1.16)))), ((V)(((BY_2397 + BH_2398) - 3.4))), ((V)((((Dp_2396 / 2D) + 0.05) + (FdLibm.Sin(a_2528) * 1.16)))))), Call(cN_42, V.Undef, ((V)(a_2528))), ((V)(0.3)));
return default;
}, 1, "", true));
Call(on_2389, V.Undef, BD_2401, Arr(G1_2445, G2_2446, SL_2447));
}
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis2540, int _argc2529, V _a2531, V _a2532, V _a2533, V _a2534, V[] _rest2530) => {
double x_2541 = 0;
double z_2542 = 0;
V L_2543 = default;
V sx_2537 = default;
V sz_2539 = default;
{ V _t2535 = ListOf(_a2531);
{ V _t2536 = GetIdx(_t2535, 0D);
sx_2537 = _t2536; }
{ V _t2538 = GetIdx(_t2535, 1D);
sz_2539 = _t2538; }
}
x_2541 = (ToNum(sx_2537) * ((W_2395 / 2D) - 4D));
z_2542 = (ToNum(sz_2539) * ((Dp_2396 / 2D) - 4D));
L_2543 = Call(at_49, V.Undef, o_2388, Arr(((V)(x_2541)), ((V)((BY_2397 / 2D))), ((V)(z_2542))), OD_2394);
if (Truthy(L_2543)) {
Call(on_2389, V.Undef, L_2543, Arr(Call(cyl_12, V.Undef, ((V)(x_2541)), ((V)(0D)), ((V)(z_2542)), ((V)(2.15)), ((V)(1.4)), BR_18, Call(M__24, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))));
}
return default;
}, 1, "", true));
yaw_2402 = (-0.2);
c_2403 = FdLibm.Cos(yaw_2402);
s_2404 = FdLibm.Sin(yaw_2402);
BKs_2405 = Call(book_33, V.Undef, ((V)((-9D))), ((V)(TY_2399)), ((V)((-5D))), ((V)(14D)), ((V)(2D)), ((V)(10D)), ((V)("#7f2030")), ((V)(yaw_2402)));
Invoke(o_2388, "push", GetIdx(BKs_2405, 0D), GetIdx(BKs_2405, 1D));
RB_2406 = Call(dec_44, V.Undef, ((V)("#e2b14a")));
fz_2407 = Fn((V _arrowThis2552, int _argc2544, V u_2550, V y_2551, V _a2548, V _a2549, V[] _rest2545) => {
return Arr(((V)((((-9D) + (ToNum(u_2550) * c_2403)) - (5D * s_2404)))), y_2551, ((V)((((-5D) + (ToNum(u_2550) * s_2404)) + (5D * c_2403)))));
}, 2, "", true);
fn_2408 = Arr(((V)((-s_2404))), ((V)(0D)), ((V)(c_2403)));
Invoke(Invoke(RB_2406, "line", Arr(Arr(((V)((((-9D) + (2D * c_2403)) - (1D * s_2404)))), ((V)((TY_2399 + 2D))), ((V)((((-5D) + (2D * s_2404)) + (1D * c_2403))))), Call(fz_2407, V.Undef, ((V)(2.4)), ((V)((TY_2399 + 2D))))), Y3_40, ((V)(0.5))), "line", Arr(Call(fz_2407, V.Undef, ((V)(2.4)), ((V)((TY_2399 + 2D)))), Call(fz_2407, V.Undef, ((V)(2.5)), ((V)((TY_2399 + 0.4))))), fn_2408, ((V)(0.5)));
TT_2409 = Call(dec_44, V.Undef, ((V)("#e2b14a")), NewObj(1).Put("op", ((V)(0.9))).V);
Invoke(TT_2409, "poly", Call(rrect_47, V.Undef, ((V)((-9D))), ((V)((TY_2399 + 2D))), ((V)((-5D))), ((V)(8D)), ((V)(0.8)), ((V)(yaw_2402)), ((V)(0D)), ((V)((-2D)))), Y3_40);
Call(Call(glue_31, V.Undef, o_2388), V.Undef, GetIdx(BKs_2405, 0D), Arr(TT_2409, RB_2406));
return default;
}, 3, "", true)));
Set(N_16, "lev24", Fn((V _arrowThis2560, int _argc2553, V S_2559, V _a2556, V _a2557, V _a2558, V[] _rest2554) => {
V B_2561 = default;
V CY_2562 = default;
V WH_2563 = default;
double TY_2564 = 0;
V D_2565 = default;
B_2561 = Invoke(N_16, "lev22", S_2559);
CY_2562 = ((V)("#7fe8ff"));
WH_2563 = ((V)("#f2f4f8"));
TY_2564 = 26D;
D_2565 = Object_assign(NewObj(0).V, B_2561);
Set(D_2565, "layers", Invoke(Get(B_2561, "layers"), "map", Fn((V _arrowThis2573, int _argc2566, V L_2572, V _a2569, V _a2570, V _a2571, V[] _rest2567) => {
return Object_assign(NewObj(0).V, L_2572, NewObj(1).Put("build", Fn((V _arrowThis2580, int _argc2574, V _a2576, V _a2577, V _a2578, V _a2579, V[] _rest2575) => {
V o_2581 = default;
V on_2582 = default;
V T_2583 = default;
V PH_2584 = default;
o_2581 = Invoke(L_2572, "build");
on_2582 = Call(glue_31, V.Undef, o_2581);
T_2583 = Call(at_49, V.Undef, o_2581, Arr(((V)(14D)), ((V)((TY_2564 + 1.5))), ((V)(0D))), WH_2563);
if (Truthy(T_2583)) {
V RG2_2585 = default;
V LD_2586 = default;
RG2_2585 = Call(dec_44, V.Undef, ((V)("#cdd4de")), NewObj(1).Put("op", ((V)(0.5))).V);
LD_2586 = Call(dec_44, V.Undef, CY_2562, NewObj(1).Put("emit", ((V)(1D))).V);
Invoke(Arr(((V)(13D)), ((V)(14.4)), ((V)(15.8))), "forEach", Fn((V _arrowThis2594, int _argc2587, V r_2593, V _a2590, V _a2591, V _a2592, V[] _rest2588) => {
return Call(ringY_51, V.Undef, RG2_2585, ((V)(0D)), ((V)(0D)), r_2593, ((V)((TY_2564 + 3D))), ((V)(0.18)), ((V)(48D)));
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(28D)), Fn((V _arrowThis2602, int _argc2595, V i_2601, V _a2598, V _a2599, V _a2600, V[] _rest2596) => {
double a_2603 = 0;
a_2603 = (((ToNum(i_2601) / 28D) * 2D) * PI_17);
Call(spot_46, V.Undef, LD_2586, Arr(((V)((FdLibm.Cos(a_2603) * 17.02))), ((V)((TY_2564 + 1.6))), ((V)((FdLibm.Sin(a_2603) * 17.02)))), Call(cN_42, V.Undef, ((V)(a_2603))), ((V)(0.28)), ((V)(0.28)), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
Call(on_2582, V.Undef, T_2583, Arr(RG2_2585, LD_2586));
}
PH_2584 = Call(at_49, V.Undef, o_2581, Arr(((V)(4D)), ((V)((TY_2564 + 4.1))), ((V)(2D))), ((V)("#2a2d34")));
if (Truthy(PH_2584)) {
V cols_2604 = default;
V IC_2605 = default;
V BOLT_2606 = default;
V q_2607 = default;
cols_2604 = Arr(((V)("#ff7a5a")), ((V)("#ffd24a")), ((V)("#7fe27a")), ((V)("#7fc8ff")), ((V)("#c48cff")), ((V)("#ffffff")));
IC_2605 = Invoke(cols_2604, "map", Fn((V _arrowThis2615, int _argc2608, V col_2614, V _a2611, V _a2612, V _a2613, V[] _rest2609) => {
return Call(dec_44, V.Undef, col_2614, NewObj(1).Put("emit", ((V)(1D))).V);
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis2623, int _argc2616, V i_2622, V _a2619, V _a2620, V _a2621, V[] _rest2617) => {
return Invoke(GetK(IC_2605, i_2622), "poly", Call(rrect_47, V.Undef, ((V)(4D)), ((V)((TY_2564 + 4.6))), ((V)(2D)), ((V)(1D)), ((V)(1D)), ((V)(0.3)), ((V)(((-1.3) + ((ToNum(i_2622) % 3D) * 1.3)))), ((V)(((-3D) + (System.Math.Floor((ToNum(i_2622) / 3D)) * 1.5))))), Y3_40);
}, 1, "", true));
BOLT_2606 = Call(dec_44, V.Undef, ((V)("#9affb0")), NewObj(1).Put("emit", ((V)(1D))).V);
q_2607 = Fn((V _arrowThis2632, int _argc2624, V u_2630, V v_2631, V _a2628, V _a2629, V[] _rest2625) => {
double c_2633 = 0;
double s_2634 = 0;
c_2633 = FdLibm.Cos(0.3);
s_2634 = FdLibm.Sin(0.3);
return Arr(((V)(((4D + (ToNum(u_2630) * c_2633)) - (ToNum(v_2631) * s_2634)))), ((V)((TY_2564 + 4.62))), ((V)(((2D + (ToNum(u_2630) * s_2634)) + (ToNum(v_2631) * c_2633)))));
return default;
}, 2, "", true);
Invoke(BOLT_2606, "poly", Arr(Call(q_2607, V.Undef, ((V)(0.3)), ((V)(0.6))), Call(q_2607, V.Undef, ((V)((-0.6))), ((V)(2.2))), Call(q_2607, V.Undef, ((V)(0D)), ((V)(2.2))), Call(q_2607, V.Undef, ((V)((-0.4))), ((V)(3.6))), Call(q_2607, V.Undef, ((V)(0.7)), ((V)(1.8))), Call(q_2607, V.Undef, ((V)(0.1)), ((V)(1.8)))), Y3_40);
Call(on_2582, V.Undef, PH_2584, Invoke(IC_2605, "concat", Arr(BOLT_2606)));
}
return o_2581;
return default;
}, 0, "build", true)).V);
}, 1, "", true)));
Set(D_2565, "build", Fn((V _arrowThis2641, int _argc2635, V _a2637, V _a2638, V _a2639, V _a2640, V[] _rest2636) => {
V o_2642 = default;
V on_2643 = default;
V BS_2644 = default;
o_2642 = Invoke(B_2561, "build");
on_2643 = Call(glue_31, V.Undef, o_2642);
BS_2644 = Call(at_49, V.Undef, o_2642, Arr(((V)(12D)), ((V)(1.7)), ((V)(0D))), ((V)("#23262d")));
if (Truthy(BS_2644)) {
V VT_2645 = default;
V LDs_2646 = default;
VT_2645 = Call(dec_44, V.Undef, ((V)("#0e1013")), NewObj(1).Put("op", ((V)(0.9))).V);
LDs_2646 = Invoke(Arr(((V)("#7fe27a")), CY_2562, ((V)("#ffb84a"))), "map", Fn((V _arrowThis2654, int _argc2647, V col_2653, V _a2650, V _a2651, V _a2652, V[] _rest2648) => {
return Call(dec_44, V.Undef, col_2653, NewObj(1).Put("emit", ((V)(1D))).V);
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(24D)), Fn((V _arrowThis2662, int _argc2655, V i_2661, V _a2658, V _a2659, V _a2660, V[] _rest2656) => {
double a_2663 = 0;
a_2663 = (((ToNum(i_2661) / 24D) * 2D) * PI_17);
Invoke(VT_2645, "line", Arr(Arr(((V)((FdLibm.Cos(a_2663) * 9.6))), ((V)(3.4)), ((V)((FdLibm.Sin(a_2663) * 9.6)))), Arr(((V)((FdLibm.Cos(a_2663) * 11D))), ((V)(3.4)), ((V)((FdLibm.Sin(a_2663) * 11D))))), Y3_40, ((V)(0.35)));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-0.25))), ((V)(0D)), ((V)(0.25))), "forEach", Fn((V _arrowThis2672, int _argc2664, V d_2670, V i_2671, V _a2668, V _a2669, V[] _rest2665) => {
V a_2673 = default;
a_2673 = Add(((V)((PI_17 / 2D))), d_2670);
Call(spot_46, V.Undef, GetK(LDs_2646, i_2671), Arr(((V)((FdLibm.Cos(ToNum(a_2673)) * 12.25))), ((V)(1.7)), ((V)((FdLibm.Sin(ToNum(a_2673)) * 12.25)))), Call(nz_38, V.Undef, Arr(((V)(FdLibm.Cos(ToNum(a_2673)))), ((V)(0.45)), ((V)(FdLibm.Sin(ToNum(a_2673)))))), ((V)(0.3)), ((V)(0.3)), ((V)(0D)), ((V)(6D)));
return default;
}, 2, "", true));
Call(on_2643, V.Undef, BS_2644, Invoke(Arr(Call(band_29, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(13.03)), ((V)(0.6)), ((V)("#0e1013")), NewObj(2).Put("n", ((V)(28D))).Put("noOut", ((V)(1D))).V), VT_2645), "concat", LDs_2646));
}
return o_2642;
return default;
}, 0, "", true));
return D_2565;
return default;
}, 1, "", true));
grainX_54 = Fn((V _arrowThis2690, int _argc2674, V D1_2680, V D2_2681, V x0_2682, V x1_2683, V[] _rest2675) => {
V y_2684 = default;
V z0_2685 = default;
V z1_2686 = default;
V n_2687 = default;
V R_2688 = default;
V w_2689 = default;
y_2684 = (_argc2674 > 4 ? _rest2675[0] : V.Undef);
z0_2685 = (_argc2674 > 5 ? _rest2675[1] : V.Undef);
z1_2686 = (_argc2674 > 6 ? _rest2675[2] : V.Undef);
n_2687 = (_argc2674 > 7 ? _rest2675[3] : V.Undef);
R_2688 = (_argc2674 > 8 ? _rest2675[4] : V.Undef);
w_2689 = (_argc2674 > 9 ? _rest2675[5] : V.Undef);
return Call(rep_28, V.Undef, n_2687, Fn((V _arrowThis2698, int _argc2691, V k_2697, V _a2694, V _a2695, V _a2696, V[] _rest2692) => {
V zc_2699 = default;
double ph_2700 = 0;
double a_2701 = 0;
zc_2699 = Add(z0_2685, ((V)((((ToNum(z1_2686) - ToNum(z0_2685)) * ToNum(Add(k_2697, ((V)(0.5))))) / ToNum(n_2687)))));
ph_2700 = (ToNum(Call(R_2688, V.Undef)) * 6D);
a_2701 = (0.3 + (ToNum(Call(R_2688, V.Undef)) * 0.6));
Invoke((NumTruthy((ToNum(k_2697) % 2D)) ? D2_2681 : D1_2680), "line", Call(wv_43, V.Undef, ((V)(30D)), Fn((V _arrowThis2709, int _argc2702, V t_2708, V _a2705, V _a2706, V _a2707, V[] _rest2703) => {
V x_2710 = default;
x_2710 = Add(x0_2682, ((V)(((ToNum(x1_2683) - ToNum(x0_2682)) * ToNum(t_2708)))));
return Arr(x_2710, y_2684, ((V)(Max(ToNum(Add(z0_2685, ((V)(0.2)))), Min((ToNum(z1_2686) - 0.2), ToNum(Add(Add(zc_2699, ((V)((a_2701 * FdLibm.Sin(((ToNum(x_2710) * 0.09) + ph_2700)))))), ((V)((0.3 * FdLibm.Sin(((ToNum(x_2710) * 0.27) + (ph_2700 * 2D)))))))))))));
return default;
}, 1, "", true)), Y3_40, ((V)((ToNum((w_2689 is var _t2711 && Truthy(_t2711) ? _t2711 : ((V)(0.3)))) * (0.7 + (ToNum(Call(R_2688, V.Undef)) * 0.6))))), ((V)(1D)));
return default;
}, 1, "", true));
}, 10, "", true);
speck_55 = Fn((V _arrowThis2726, int _argc2712, V D_2718, V cnt_2719, V f_2720, V nrm_2721, V[] _rest2713) => {
V r0_2722 = default;
V r1_2723 = default;
V R_2724 = default;
V m_2725 = default;
r0_2722 = (_argc2712 > 4 ? _rest2713[0] : V.Undef);
r1_2723 = (_argc2712 > 5 ? _rest2713[1] : V.Undef);
R_2724 = (_argc2712 > 6 ? _rest2713[2] : V.Undef);
m_2725 = (_argc2712 > 7 ? _rest2713[3] : V.Undef);
return Call(rep_28, V.Undef, cnt_2719, Fn((V _arrowThis2733, int _argc2727, V _a2729, V _a2730, V _a2731, V _a2732, V[] _rest2728) => {
V p_2734 = default;
V r_2735 = default;
p_2734 = Call(f_2720, V.Undef, Call(R_2724, V.Undef), Call(R_2724, V.Undef));
r_2735 = Add(r0_2722, ((V)((ToNum(Call(R_2724, V.Undef)) * (ToNum(r1_2723) - ToNum(r0_2722))))));
if (Truthy(p_2734)) {
Call(spot_46, V.Undef, D_2718, p_2734, nrm_2721, r_2735, ((V)((ToNum(r_2735) * (0.6 + (ToNum(Call(R_2724, V.Undef)) * 0.4))))), ((V)((ToNum(Call(R_2724, V.Undef)) * 3D))), (m_2725 is var _t2736 && Truthy(_t2736) ? _t2736 : ((V)(6D))));
}
return default;
}, 0, "", true));
}, 8, "", true);
seg_56 = Fn((V _arrowThis2748, int _argc2737, V D_2743, V A_2744, V B_2745, V n_2746, V[] _rest2738) => {
V w_2747 = default;
w_2747 = (_argc2737 > 4 ? _rest2738[0] : V.Undef);
return Invoke(D_2743, "line", Arr(A_2744, B_2745), n_2746, w_2747);
}, 5, "", true);
Set(N_16, "faux24", Call(ext_50, V.Undef, ((V)("faux23")), Fn((V _arrowThis2758, int _argc2749, V o_2755, V on_2756, V R_2757, V _a2754, V[] _rest2750) => {
V MO_2759 = default;
double OY_2760 = 0;
double HY_2761 = 0;
double MY_2762 = 0;
double ZF_2763 = 0;
double ZB_2764 = 0;
V mZ_2765 = default;
V HE_2766 = default;
V PLf_2767 = default;
V PRt_2768 = default;
V LT_2769 = default;
V star_2770 = default;
V side_2771 = default;
V BK_2772 = default;
V MT_2773 = default;
V HT_2774 = default;
V GR_2775 = default;
MO_2759 = ((V)("#d8cbb6"));
OY_2760 = 45.4;
HY_2761 = 4D;
MY_2762 = 74D;
ZF_2763 = 15D;
ZB_2764 = (ZF_2763 + 0.7);
mZ_2765 = Call(mul_36, V.Undef, Z3_41, ((V)((-1D))));
HE_2766 = Call(at_49, V.Undef, o_2755, Arr(((V)(0D)), ((V)(2D)), ((V)(4D))), ((V)("#6f6a64")));
if (Truthy(HE_2766)) {
V TL_2776 = default;
V SP_2777 = default;
V SPd_2778 = default;
V CK_2779 = default;
V CP_2780 = default;
V xs_2781 = default;
V zs_2782 = default;
TL_2776 = Invoke(Arr(((V)("#7c766e")), ((V)("#635d56")), ((V)("#746d64")), ((V)("#5c5751")), ((V)("#6b655d"))), "map", Fn((V _arrowThis2790, int _argc2783, V c_2789, V _a2786, V _a2787, V _a2788, V[] _rest2784) => {
return Call(dec_44, V.Undef, c_2789, NewObj(1).Put("op", ((V)(0.55))).V);
}, 1, "", true));
SP_2777 = Call(dec_44, V.Undef, ((V)("#8f8a82")), NewObj(1).Put("op", ((V)(0.6))).V);
SPd_2778 = Call(dec_44, V.Undef, ((V)("#45413c")), NewObj(1).Put("op", ((V)(0.6))).V);
CK_2779 = Call(dec_44, V.Undef, ((V)("#2e2b28")), NewObj(1).Put("op", ((V)(0.85))).V);
CP_2780 = Call(dec_44, V.Undef, ((V)("#a8a299")), NewObj(1).Put("op", ((V)(0.85))).V);
xs_2781 = Arr(((V)((-64D))), ((V)((-48D))), ((V)((-32D))), ((V)((-16D))), ((V)(0D)), ((V)(16D)), ((V)(32D)), ((V)(48D)), ((V)(64D)));
zs_2782 = Arr(((V)((-15D))), ((V)((-5D))), ((V)(4D)), ((V)(13D)), ((V)(23D)));
Invoke(Invoke(xs_2781, "slice", ((V)(0D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis2799, int _argc2791, V x0_2797, V i_2798, V _a2795, V _a2796, V[] _rest2792) => {
return Invoke(Invoke(zs_2782, "slice", ((V)(0D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis2808, int _argc2800, V z0_2806, V j_2807, V _a2804, V _a2805, V[] _rest2801) => {
V x1_2809 = default;
V z1_2810 = default;
x1_2809 = GetK(xs_2781, Add(i_2798, ((V)(1D))));
z1_2810 = GetK(zs_2782, Add(j_2807, ((V)(1D))));
Invoke(GetIdx(TL_2776, (((ToNum(i_2798) * 3D) + (ToNum(j_2807) * 7D)) % 5D)), "poly", Arr(Arr(Add(x0_2797, ((V)(0.3))), ((V)(HY_2761)), Add(z0_2806, ((V)(0.3)))), Arr(((V)((ToNum(x1_2809) - 0.3))), ((V)(HY_2761)), Add(z0_2806, ((V)(0.3)))), Arr(((V)((ToNum(x1_2809) - 0.3))), ((V)(HY_2761)), ((V)((ToNum(z1_2810) - 0.3)))), Arr(Add(x0_2797, ((V)(0.3))), ((V)(HY_2761)), ((V)((ToNum(z1_2810) - 0.3))))), Y3_40);
return default;
}, 2, "", true));
}, 2, "", true));
Call(speck_55, V.Undef, SP_2777, ((V)(70D)), Fn((V _arrowThis2819, int _argc2811, V u_2817, V v_2818, V _a2815, V _a2816, V[] _rest2812) => {
return Arr(((V)(((-63D) + (ToNum(u_2817) * 126D)))), ((V)(HY_2761)), ((V)(((-14D) + (ToNum(v_2818) * 36D)))));
}, 2, "", true), Y3_40, ((V)(0.15)), ((V)(0.4)), R_2757);
Call(speck_55, V.Undef, SPd_2778, ((V)(50D)), Fn((V _arrowThis2828, int _argc2820, V u_2826, V v_2827, V _a2824, V _a2825, V[] _rest2821) => {
return Arr(((V)(((-63D) + (ToNum(u_2826) * 126D)))), ((V)(HY_2761)), ((V)(((-14D) + (ToNum(v_2827) * 36D)))));
}, 2, "", true), Y3_40, ((V)(0.12)), ((V)(0.35)), R_2757);
Call(speck_55, V.Undef, SPd_2778, ((V)(24D)), Fn((V _arrowThis2837, int _argc2829, V u_2835, V v_2836, V _a2833, V _a2834, V[] _rest2830) => {
return Arr(((V)(((-63D) + (ToNum(u_2835) * 126D)))), ((V)((0.5 + (ToNum(v_2836) * 3D)))), ((V)(23D)));
}, 2, "", true), Z3_41, ((V)(0.15)), ((V)(0.4)), R_2757);
Invoke(CK_2779, "line", Arr(Arr(((V)(6D)), ((V)(HY_2761)), ((V)(22.6))), Arr(((V)(8.4)), ((V)(HY_2761)), ((V)(20D))), Arr(((V)(7.6)), ((V)(HY_2761)), ((V)(17.6))), Arr(((V)(10.4)), ((V)(HY_2761)), ((V)(15.2))), Arr(((V)(11.2)), ((V)(HY_2761)), ((V)(13.4)))), Y3_40, ((V)(0.24)), ((V)(1D)));
Invoke(Invoke(CP_2780, "poly", Arr(Arr(((V)(47.7)), ((V)(HY_2761)), ((V)(22.7))), Arr(((V)(44.6)), ((V)(HY_2761)), ((V)(22.7))), Arr(((V)(45.6)), ((V)(HY_2761)), ((V)(21.4))), Arr(((V)(47.7)), ((V)(HY_2761)), ((V)(20.6)))), Y3_40), "poly", Arr(Arr(((V)(47.7)), ((V)(3.6)), ((V)(23D))), Arr(((V)(44.6)), ((V)(3.6)), ((V)(23D))), Arr(((V)(45.6)), ((V)(2.4)), ((V)(23D))), Arr(((V)(47.7)), ((V)(2D)), ((V)(23D)))), Z3_41);
Call(on_2756, V.Undef, HE_2766, Invoke(TL_2776, "concat", Arr(SP_2777, SPd_2778, CK_2779, CP_2780, Call(ball_13, V.Undef, ((V)((-18D))), ((V)((HY_2761 + 1.35))), ((V)(9D)), ((V)(1.5)), ((V)("#f2efe6")), Call(F__26, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sy", ((V)(0.85))).V)))));
}
PLf_2767 = Call(at_49, V.Undef, o_2755, Arr(((V)((-43D))), ((V)(20D)), ((V)(1D))), MO_2759);
PRt_2768 = Call(at_49, V.Undef, o_2755, Arr(((V)(43D)), ((V)(20D)), ((V)(1D))), MO_2759);
LT_2769 = Call(at_49, V.Undef, o_2755, Arr(((V)(0D)), ((V)(60D)), ((V)(0D))), MO_2759);
if (Truthy(LT_2769)) {
V SM_2838 = default;
V SL_2839 = default;
V NL_2840 = default;
V FD_2841 = default;
V LB_2842 = default;
V BC2_2843 = default;
V RDt_2844 = default;
SM_2838 = Call(dec_44, V.Undef, ((V)("#4a3226")), NewObj(1).Put("op", ((V)(0.55))).V);
SL_2839 = Call(dec_44, V.Undef, ((V)("#f0dcc6")), NewObj(1).Put("op", ((V)(0.45))).V);
NL_2840 = Call(dec_44, V.Undef, ((V)("#8d8780")));
FD_2841 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.1))).V);
Call(spot_46, V.Undef, FD_2841, Arr(((V)((-30D))), ((V)(62D)), ((V)(ZB_2764))), Z3_41, ((V)(18D)), ((V)(8D)), ((V)(0.2)), ((V)(14D)));
Call(spot_46, V.Undef, FD_2841, Arr(((V)((-22D))), ((V)(64D)), ((V)(ZB_2764))), Z3_41, ((V)(9D)), ((V)(4D)), ((V)((-0.1))), ((V)(12D)));
Call(seg_56, V.Undef, SM_2838, Arr(((V)(8D)), ((V)((OY_2760 + 0.4))), ((V)(ZB_2764))), Arr(((V)(8D)), ((V)((MY_2762 - 0.4))), ((V)(ZB_2764))), Z3_41, ((V)(0.25)));
Call(seg_56, V.Undef, SL_2839, Arr(((V)(8.35)), ((V)((OY_2760 + 0.4))), ((V)(ZB_2764))), Arr(((V)(8.35)), ((V)((MY_2762 - 0.4))), ((V)(ZB_2764))), Z3_41, ((V)(0.15)));
Invoke(Arr(((V)((OY_2760 + 2D))), ((V)((OY_2760 + 9.5))), ((V)((OY_2760 + 17D))), ((V)((OY_2760 + 24.5)))), "forEach", Fn((V _arrowThis2852, int _argc2845, V y_2851, V _a2848, V _a2849, V _a2850, V[] _rest2846) => {
Call(spot_46, V.Undef, NL_2840, Arr(((V)(8.9)), y_2851, ((V)(ZB_2764))), Z3_41, ((V)(0.32)), ((V)(0.32)), ((V)(0D)), ((V)(6D)));
Call(spot_46, V.Undef, NL_2840, Arr(((V)((-58.6))), y_2851, ((V)(ZB_2764))), Z3_41, ((V)(0.32)), ((V)(0.32)), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
LB_2842 = Call(dec_44, V.Undef, ((V)("#f4f0e6")));
BC2_2843 = Call(dec_44, V.Undef, ((V)("#2a2d34")));
RDt_2844 = Call(dec_44, V.Undef, ((V)("#d9483b")));
Invoke(LB_2842, "poly", Arr(Arr(((V)(44D)), ((V)(57D)), ((V)((-15D)))), Arr(((V)(30D)), ((V)(57D)), ((V)((-15D)))), Arr(((V)(30D)), ((V)(66D)), ((V)((-15D)))), Arr(((V)(44D)), ((V)(66D)), ((V)((-15D))))), mZ_2765);
Call(rep_28, V.Undef, ((V)(14D)), Fn((V _arrowThis2860, int _argc2853, V i_2859, V _a2856, V _a2857, V _a2858, V[] _rest2854) => {
return Call(seg_56, V.Undef, BC2_2843, Arr(((V)((42.8 - (ToNum(i_2859) * 0.5)))), ((V)(58D)), ((V)((-15D)))), Arr(((V)((42.8 - (ToNum(i_2859) * 0.5)))), ((V)(61D)), ((V)((-15D)))), mZ_2765, ((V)((NumTruthy((ToNum(i_2859) % 3D)) ? 0.14 : 0.28))));
}, 1, "", true));
Call(seg_56, V.Undef, RDt_2844, Arr(((V)(43D)), ((V)(64.6)), ((V)((-15D)))), Arr(((V)(35D)), ((V)(64.6)), ((V)((-15D)))), mZ_2765, ((V)(0.8)));
Call(seg_56, V.Undef, BC2_2843, Arr(((V)(43D)), ((V)(62.7)), ((V)((-15D)))), Arr(((V)(33D)), ((V)(62.7)), ((V)((-15D)))), mZ_2765, ((V)(0.3)));
Call(on_2756, V.Undef, LT_2769, Arr(FD_2841, SM_2838, SL_2839, NL_2840, LB_2842, BC2_2843, RDt_2844));
}
star_2770 = Fn((V _arrowThis2872, int _argc2861, V D_2867, V c_2868, V r1_2869, V r2_2870, V[] _rest2862) => {
V rot_2871 = default;
rot_2871 = (_argc2861 > 4 ? _rest2862[0] : V.Undef);
return Invoke(D_2867, "poly", Call(rep_28, V.Undef, ((V)(10D)), Fn((V _arrowThis2880, int _argc2873, V i_2879, V _a2876, V _a2877, V _a2878, V[] _rest2874) => {
V a_2881 = default;
V r_2882 = default;
a_2881 = Add(rot_2871, ((V)(((ToNum(i_2879) * PI_17) / 5D))));
r_2882 = (NumTruthy((ToNum(i_2879) % 2D)) ? r2_2870 : r1_2869);
return Arr(Add(GetIdx(c_2868, 0D), ((V)((FdLibm.Sin(ToNum(a_2881)) * ToNum(r_2882))))), Add(GetIdx(c_2868, 1D), ((V)((FdLibm.Cos(ToNum(a_2881)) * ToNum(r_2882))))), GetIdx(c_2868, 2D));
return default;
}, 1, "", true)), Z3_41);
}, 5, "", true);
Invoke(Arr(Arr(PLf_2767, ((V)((-1D)))), Arr(PRt_2768, ((V)(1D)))), "forEach", Fn((V _arrowThis2894, int _argc2883, V _a2885, V _a2886, V _a2887, V _a2888, V[] _rest2884) => {
V NL_2895 = default;
V SC_2896 = default;
V L2_2897 = default;
V P_2891 = default;
V s_2893 = default;
{ V _t2889 = ListOf(_a2885);
{ V _t2890 = GetIdx(_t2889, 0D);
P_2891 = _t2890; }
{ V _t2892 = GetIdx(_t2889, 1D);
s_2893 = _t2892; }
}
if (!(Truthy(P_2891))) {
return default;
}
NL_2895 = Call(dec_44, V.Undef, ((V)("#8d8780")));
SC_2896 = Call(dec_44, V.Undef, ((V)("#f2d8c4")), NewObj(1).Put("op", ((V)(0.38))).V);
Invoke(Arr(((V)(8D)), ((V)(20D)), ((V)(32D)), ((V)(42D))), "forEach", Fn((V _arrowThis2905, int _argc2898, V y_2904, V _a2901, V _a2902, V _a2903, V[] _rest2899) => {
return Call(spot_46, V.Undef, NL_2895, Arr(((V)((ToNum(s_2893) * 58.6))), y_2904, ((V)(ZB_2764))), Z3_41, ((V)(0.32)), ((V)(0.32)), ((V)(0D)), ((V)(6D)));
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(7D)), Fn((V _arrowThis2912, int _argc2906, V _a2908, V _a2909, V _a2910, V _a2911, V[] _rest2907) => {
double x_2913 = 0;
double y_2914 = 0;
double a_2915 = 0;
double L_2916 = 0;
x_2913 = (ToNum(s_2893) * (30D + (ToNum(Call(R_2757, V.Undef)) * 28D)));
y_2914 = (5D + (ToNum(Call(R_2757, V.Undef)) * 9D));
a_2915 = ((ToNum(Call(R_2757, V.Undef)) - 0.5) * 0.5);
L_2916 = (1.5 + (ToNum(Call(R_2757, V.Undef)) * 3D));
Call(seg_56, V.Undef, SC_2896, Arr(((V)(x_2913)), ((V)(y_2914)), ((V)(ZB_2764))), Arr(((V)((x_2913 + (FdLibm.Cos(a_2915) * L_2916)))), ((V)((y_2914 + (FdLibm.Sin(a_2915) * L_2916)))), ((V)(ZB_2764))), Z3_41, ((V)(0.25)));
return default;
}, 0, "", true));
L2_2897 = Arr(SC_2896, NL_2895);
if (LtN(s_2893, 0D)) {
V SH2_2917 = default;
V ST2_2918 = default;
SH2_2917 = Call(dec_44, V.Undef, ((V)("#c99a1a")), NewObj(1).Put("op", ((V)(0.7))).V);
ST2_2918 = Call(dec_44, V.Undef, ((V)("#f2c230")));
Call(star_2770, V.Undef, SH2_2917, Arr(((V)((-47.8))), ((V)(27.8)), ((V)(ZB_2764))), ((V)(2.6)), ((V)(1.15)), ((V)(0.15)));
Call(star_2770, V.Undef, ST2_2918, Arr(((V)((-48D))), ((V)(28D)), ((V)((ZB_2764 + 0.02)))), ((V)(2.3)), ((V)(1D)), ((V)(0.15)));
Invoke(L2_2897, "push", SH2_2917, ST2_2918);
}
Call(on_2756, V.Undef, P_2891, L2_2897);
return default;
}, 1, "", true));
side_2771 = Fn((V _arrowThis2930, int _argc2919, V P_2925, V sx_2926, V y0_2927, V y1_2928, V[] _rest2920) => {
V n_2931 = default;
double x_2932 = 0;
V S1_2933 = default;
V S2_2934 = default;
V ED_2935 = default;
V SR_2936 = default;
V SS_2937 = default;
V f_2938 = default;
V z0_2929 = default;
z0_2929 = (_argc2919 > 4 ? _rest2920[0] : V.Undef);
if (!(Truthy(P_2925))) {
return default;
}
n_2931 = Call(mul_36, V.Undef, X3_39, sx_2926);
x_2932 = (ToNum(sx_2926) * 60D);
S1_2933 = Call(dec_44, V.Undef, ((V)("#b6a68c")), NewObj(1).Put("op", ((V)(0.6))).V);
S2_2934 = Call(dec_44, V.Undef, ((V)("#efe6d6")), NewObj(1).Put("op", ((V)(0.6))).V);
ED_2935 = Call(dec_44, V.Undef, ((V)("#f6f1e8")));
SR_2936 = Call(dec_44, V.Undef, ((V)("#8d8780")));
SS_2937 = Call(dec_44, V.Undef, ((V)("#4a4540")));
f_2938 = Fn((V _arrowThis2947, int _argc2939, V u_2945, V v_2946, V _a2943, V _a2944, V[] _rest2940) => {
return Arr(((V)(x_2932)), Add(Add(y0_2927, ((V)(0.5))), ((V)((ToNum(u_2945) * ((ToNum(y1_2928) - ToNum(y0_2927)) - 1D))))), Add(Add(z0_2929, ((V)(0.5))), ((V)((ToNum(v_2946) * ((ZF_2763 - ToNum(z0_2929)) - 1D))))));
}, 2, "", true);
Call(speck_55, V.Undef, S1_2933, ((V)(30D)), f_2938, n_2931, ((V)(0.12)), ((V)(0.35)), R_2757);
Call(speck_55, V.Undef, S2_2934, ((V)(20D)), f_2938, n_2931, ((V)(0.12)), ((V)(0.3)), R_2757);
Call(seg_56, V.Undef, ED_2935, Arr(((V)(x_2932)), Add(y0_2927, ((V)(0.2))), ((V)((ZF_2763 - 0.25)))), Arr(((V)(x_2932)), ((V)((ToNum(y1_2928) - 0.2))), ((V)((ZF_2763 - 0.25)))), n_2931, ((V)(0.4)));
Invoke(Arr(Add(y0_2927, ((V)(4D))), ((V)((ToNum(y1_2928) - 4D)))), "forEach", Fn((V _arrowThis2955, int _argc2948, V y_2954, V _a2951, V _a2952, V _a2953, V[] _rest2949) => {
Call(spot_46, V.Undef, SR_2936, Arr(((V)(x_2932)), y_2954, ((V)(0D))), n_2931, ((V)(0.5)), ((V)(0.5)), ((V)(0D)), ((V)(8D)));
Call(seg_56, V.Undef, SS_2937, Arr(((V)(x_2932)), ((V)((ToNum(y_2954) - 0.4))), ((V)(0.3))), Arr(((V)(x_2932)), Add(y_2954, ((V)(0.4))), ((V)((-0.3)))), n_2931, ((V)(0.14)));
return default;
}, 1, "", true));
Call(on_2756, V.Undef, P_2925, Arr(S1_2933, S2_2934, ED_2935, SR_2936, SS_2937));
return default;
}, 5, "", true);
Call(side_2771, V.Undef, PLf_2767, ((V)((-1D))), ((V)(HY_2761)), ((V)(OY_2760)), ((V)((-13D))));
Call(side_2771, V.Undef, LT_2769, ((V)((-1D))), ((V)(OY_2760)), ((V)(MY_2762)), ((V)((-15D))));
Call(side_2771, V.Undef, PRt_2768, ((V)(1D)), ((V)(HY_2761)), ((V)(OY_2760)), ((V)((-13D))));
Call(side_2771, V.Undef, LT_2769, ((V)(1D)), ((V)(OY_2760)), ((V)(MY_2762)), ((V)((-15D))));
BK_2772 = Call(at_49, V.Undef, o_2755, Arr(((V)(0D)), ((V)(20D)), ((V)((-14D)))), ((V)("#1e1c1b")));
if (Truthy(BK_2772)) {
V AR_2956 = default;
V DU_2957 = default;
V SC_2958 = default;
AR_2956 = Call(dec_44, V.Undef, ((V)("#cfc6b6")), NewObj(1).Put("op", ((V)(0.85))).V);
DU_2957 = Call(dec_44, V.Undef, ((V)("#5a5550")), NewObj(1).Put("op", ((V)(0.35))).V);
SC_2958 = Call(dec_44, V.Undef, ((V)("#77716a")), NewObj(1).Put("op", ((V)(0.4))).V);
Invoke(Arr(((V)((-40D))), ((V)(40D))), "forEach", Fn((V _arrowThis2966, int _argc2959, V x_2965, V _a2962, V _a2963, V _a2964, V[] _rest2960) => {
Invoke(AR_2956, "poly", Arr(Arr(x_2965, ((V)(36D)), ((V)((-15D)))), Arr(((V)((ToNum(x_2965) - 3D))), ((V)(31D)), ((V)((-15D)))), Arr(((V)((ToNum(x_2965) - 1.2))), ((V)(31D)), ((V)((-15D)))), Arr(((V)((ToNum(x_2965) - 1.2))), ((V)(26D)), ((V)((-15D)))), Arr(Add(x_2965, ((V)(1.2))), ((V)(26D)), ((V)((-15D)))), Arr(Add(x_2965, ((V)(1.2))), ((V)(31D)), ((V)((-15D)))), Arr(Add(x_2965, ((V)(3D))), ((V)(31D)), ((V)((-15D))))), mZ_2765);
Call(seg_56, V.Undef, AR_2956, Arr(((V)((ToNum(x_2965) - 4.4))), ((V)(23.4)), ((V)((-15D)))), Arr(Add(x_2965, ((V)(4.4))), ((V)(23.4)), ((V)((-15D)))), mZ_2765, ((V)(0.6)));
Call(seg_56, V.Undef, AR_2956, Arr(((V)((ToNum(x_2965) - 3.4))), ((V)(21.8)), ((V)((-15D)))), Arr(Add(x_2965, ((V)(3.4))), ((V)(21.8)), ((V)((-15D)))), mZ_2765, ((V)(0.5)));
return default;
}, 1, "", true));
Call(speck_55, V.Undef, DU_2957, ((V)(18D)), Fn((V _arrowThis2975, int _argc2967, V u_2973, V v_2974, V _a2971, V _a2972, V[] _rest2968) => {
return Arr(((V)(((-24D) + (ToNum(u_2973) * 48D)))), ((V)(((HY_2761 + 0.8) + (ToNum(v_2974) * 10D)))), ((V)((-13D))));
}, 2, "", true), Z3_41, ((V)(0.6)), ((V)(1.6)), R_2757);
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis2982, int _argc2976, V _a2978, V _a2979, V _a2980, V _a2981, V[] _rest2977) => {
double x_2983 = 0;
double y_2984 = 0;
double a_2985 = 0;
double L_2986 = 0;
x_2983 = ((-22D) + (ToNum(Call(R_2757, V.Undef)) * 44D));
y_2984 = ((HY_2761 + 2D) + (ToNum(Call(R_2757, V.Undef)) * 30D));
a_2985 = ((ToNum(Call(R_2757, V.Undef)) - 0.5) * 1.2);
L_2986 = (1.5 + (ToNum(Call(R_2757, V.Undef)) * 3D));
Call(seg_56, V.Undef, SC_2958, Arr(((V)(x_2983)), ((V)(y_2984)), ((V)((-13D)))), Arr(((V)((x_2983 + (FdLibm.Cos(a_2985) * L_2986)))), ((V)((y_2984 + (FdLibm.Sin(a_2985) * L_2986)))), ((V)((-13D)))), Z3_41, ((V)(0.2)));
return default;
}, 0, "", true));
Call(on_2756, V.Undef, BK_2772, Arr(DU_2957, SC_2958, AR_2956));
}
MT_2773 = Call(at_49, V.Undef, o_2755, Arr(((V)(0D)), ((V)((MY_2762 + 2D))), ((V)(2D))), ((V)("#a87a4e")));
if (Truthy(MT_2773)) {
double yT_2987 = 0;
V G1_2988 = default;
V G2_2989 = default;
V KN_2990 = default;
V KR_2991 = default;
V WR_2992 = default;
V SC_2993 = default;
V WX_2994 = default;
V BN_2995 = default;
yT_2987 = (MY_2762 + 4D);
G1_2988 = Call(dec_44, V.Undef, ((V)("#7a5232")), NewObj(1).Put("op", ((V)(0.5))).V);
G2_2989 = Call(dec_44, V.Undef, ((V)("#c99c66")), NewObj(1).Put("op", ((V)(0.45))).V);
KN_2990 = Call(dec_44, V.Undef, ((V)("#4a2e18")), NewObj(1).Put("op", ((V)(0.8))).V);
KR_2991 = Call(dec_44, V.Undef, ((V)("#7a5232")), NewObj(1).Put("op", ((V)(0.5))).V);
WR_2992 = Call(dec_44, V.Undef, ((V)("#6a4528")), NewObj(1).Put("op", ((V)(0.35))).V);
SC_2993 = Call(dec_44, V.Undef, ((V)("#e0bb88")), NewObj(1).Put("op", ((V)(0.5))).V);
WX_2994 = Call(dec_44, V.Undef, ((V)("#f4e9d0")));
BN_2995 = Call(dec_44, V.Undef, ((V)("#2e1c10")), NewObj(1).Put("op", ((V)(0.55))).V);
Call(grainX_54, V.Undef, G1_2988, G2_2989, ((V)((-64.6))), ((V)(64.6)), ((V)(yT_2987)), ((V)((-15.6))), ((V)(19.6)), ((V)(14D)), R_2757, ((V)(0.32)));
Invoke(Arr(Arr(((V)((-18D))), ((V)(10D)), ((V)(1.1))), Arr(((V)(44D)), ((V)((-6D))), ((V)(0.8)))), "forEach", Fn((V _arrowThis3009, int _argc2996, V _a2998, V _a2999, V _a3000, V _a3001, V[] _rest2997) => {
V x_3004 = default;
V z_3006 = default;
V a_3008 = default;
{ V _t3002 = ListOf(_a2998);
{ V _t3003 = GetIdx(_t3002, 0D);
x_3004 = _t3003; }
{ V _t3005 = GetIdx(_t3002, 1D);
z_3006 = _t3005; }
{ V _t3007 = GetIdx(_t3002, 2D);
a_3008 = _t3007; }
}
Call(spot_46, V.Undef, KN_2990, Arr(x_3004, ((V)(yT_2987)), z_3006), Y3_40, a_3008, ((V)(0.6)), ((V)(0.1)), ((V)(10D)));
Invoke(Arr(((V)(1.8)), ((V)(2.8))), "forEach", Fn((V _arrowThis3017, int _argc3010, V k_3016, V _a3013, V _a3014, V _a3015, V[] _rest3011) => {
return Invoke(KR_2991, "line", Call(wv_43, V.Undef, ((V)(18D)), Fn((V _arrowThis3025, int _argc3018, V t_3024, V _a3021, V _a3022, V _a3023, V[] _rest3019) => {
return Arr(Add(x_3004, ((V)(((FdLibm.Cos(((ToNum(t_3024) * 2D) * PI_17)) * ToNum(a_3008)) * ToNum(k_3016))))), ((V)(yT_2987)), Add(z_3006, ((V)(((FdLibm.Sin(((ToNum(t_3024) * 2D) * PI_17)) * 0.78) * ToNum(k_3016))))));
}, 1, "", true)), Y3_40, ((V)(0.2)));
}, 1, "", true));
return default;
}, 1, "", true));
Call(ringY_51, V.Undef, WR_2992, ((V)((-6D))), ((V)((-4D))), ((V)(3.4)), ((V)(yT_2987)), ((V)(0.45)), ((V)(28D)));
Call(ringY_51, V.Undef, WR_2992, ((V)((-4.6))), ((V)((-3.2))), ((V)(3.3)), ((V)(yT_2987)), ((V)(0.2)), ((V)(28D)));
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis3032, int _argc3026, V _a3028, V _a3029, V _a3030, V _a3031, V[] _rest3027) => {
double x_3033 = 0;
double z_3034 = 0;
double a_3035 = 0;
double L_3036 = 0;
x_3033 = ((-60D) + (ToNum(Call(R_2757, V.Undef)) * 120D));
z_3034 = ((-12D) + (ToNum(Call(R_2757, V.Undef)) * 28D));
a_3035 = ((ToNum(Call(R_2757, V.Undef)) - 0.5) * 0.6);
L_3036 = (2D + (ToNum(Call(R_2757, V.Undef)) * 4D));
Call(seg_56, V.Undef, SC_2993, Arr(((V)(x_3033)), ((V)(yT_2987)), ((V)(z_3034))), Arr(((V)((x_3033 + (FdLibm.Cos(a_3035) * L_3036)))), ((V)(yT_2987)), ((V)((z_3034 + (FdLibm.Sin(a_3035) * L_3036))))), Y3_40, ((V)(0.18)));
return default;
}, 0, "", true));
Invoke(WX_2994, "poly", Call(rep_28, V.Undef, ((V)(12D)), Fn((V _arrowThis3044, int _argc3037, V i_3043, V _a3040, V _a3041, V _a3042, V[] _rest3038) => {
double a_3045 = 0;
double r_3046 = 0;
a_3045 = (((ToNum(i_3043) / 12D) * 2D) * PI_17);
r_3046 = ((3.1 + (NumTruthy((ToNum(i_3043) % 3D)) ? 0.4 : (-0.3))) + (SEqN(i_3043, 4D) ? 1.4 : 0D));
return Arr(((V)((26D + (FdLibm.Cos(a_3045) * r_3046)))), ((V)(yT_2987)), ((V)((4D + (FdLibm.Sin(a_3045) * r_3046)))));
return default;
}, 1, "", true)), Y3_40);
Call(spot_46, V.Undef, BN_2995, Arr(((V)(16D)), ((V)(yT_2987)), ((V)(13D))), Y3_40, ((V)(0.7)), ((V)(0.5)), ((V)(0.4)), ((V)(8D)));
Invoke(G1_2988, "line", Call(wv_43, V.Undef, ((V)(30D)), Fn((V _arrowThis3054, int _argc3047, V t_3053, V _a3050, V _a3051, V _a3052, V[] _rest3048) => {
return Arr(((V)(((-64.6) + (129.2 * ToNum(t_3053))))), ((V)(((MY_2762 + 0.6) + (0.2 * FdLibm.Sin((ToNum(t_3053) * 17D)))))), ((V)(20D)));
}, 1, "", true)), Z3_41, ((V)(0.25)), ((V)(1D)));
Invoke(G2_2989, "line", Call(wv_43, V.Undef, ((V)(30D)), Fn((V _arrowThis3062, int _argc3055, V t_3061, V _a3058, V _a3059, V _a3060, V[] _rest3056) => {
return Arr(((V)(((-64.6) + (129.2 * ToNum(t_3061))))), ((V)(((MY_2762 + 3.3) + (0.2 * FdLibm.Sin(((ToNum(t_3061) * 13D) + 1D)))))), ((V)(20D)));
}, 1, "", true)), Z3_41, ((V)(0.22)), ((V)(1D)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3070, int _argc3063, V s_3069, V _a3066, V _a3067, V _a3068, V[] _rest3064) => {
return Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis3078, int _argc3071, V k_3077, V _a3074, V _a3075, V _a3076, V[] _rest3072) => {
return Invoke(G1_2988, "line", Call(wv_43, V.Undef, ((V)(10D)), Fn((V _arrowThis3086, int _argc3079, V t_3085, V _a3082, V _a3083, V _a3084, V[] _rest3080) => {
return Arr(((V)((ToNum(s_3069) * 65D))), ((V)(((MY_2762 + 0.5) + (ToNum(t_3085) * 3D)))), ((V)((((-14D) + (ToNum(k_3077) * 11D)) + (FdLibm.Sin((ToNum(t_3085) * PI_17)) * 2.4)))));
}, 1, "", true)), Call(mul_36, V.Undef, X3_39, s_3069), ((V)(0.22)));
}, 1, "", true));
}, 1, "", true));
Call(on_2756, V.Undef, MT_2773, Arr(G1_2988, G2_2989, KR_2991, KN_2990, WR_2992, SC_2993, BN_2995, WX_2994));
}
Invoke(Arr(Arr(((V)(26D)), ((V)(4D)), ((V)(2.2)), ((V)(5D)), ((V)("#f4e9d0")), ((V)("#fffaf0"))), Arr(((V)(32D)), ((V)(7D)), ((V)(1.8)), ((V)(3.2)), ((V)("#e86f8a")), ((V)("#f6a0b4")))), "forEach", Fn((V _arrowThis3106, int _argc3087, V _a3089, V _a3090, V _a3091, V _a3092, V[] _rest3088) => {
V C_3107 = default;
V DR_3108 = default;
V x_3095 = default;
V z_3097 = default;
V r_3099 = default;
V h_3101 = default;
V col_3103 = default;
V dc_3105 = default;
{ V _t3093 = ListOf(_a3089);
{ V _t3094 = GetIdx(_t3093, 0D);
x_3095 = _t3094; }
{ V _t3096 = GetIdx(_t3093, 1D);
z_3097 = _t3096; }
{ V _t3098 = GetIdx(_t3093, 2D);
r_3099 = _t3098; }
{ V _t3100 = GetIdx(_t3093, 3D);
h_3101 = _t3100; }
{ V _t3102 = GetIdx(_t3093, 4D);
col_3103 = _t3102; }
{ V _t3104 = GetIdx(_t3093, 5D);
dc_3105 = _t3104; }
}
C_3107 = Call(at_49, V.Undef, o_2755, Arr(x_3095, ((V)(((MY_2762 + 4D) + (ToNum(h_3101) / 2D)))), z_3097), col_3103);
if (!(Truthy(C_3107))) {
return default;
}
DR_3108 = Call(dec_44, V.Undef, dc_3105, NewObj(1).Put("op", ((V)(0.95))).V);
Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis3116, int _argc3109, V i_3115, V _a3112, V _a3113, V _a3114, V[] _rest3110) => {
double a_3117 = 0;
double L_3118 = 0;
V e_3119 = default;
a_3117 = ((0.3 + (ToNum(i_3115) * 1.25)) + (ToNum(Call(R_2757, V.Undef)) * 0.4));
L_3118 = (1D + ((ToNum(Call(R_2757, V.Undef)) * ToNum(h_3101)) * 0.55));
e_3119 = Arr(Add(x_3095, ((V)((FdLibm.Cos(a_3117) * ToNum(r_3099))))), ((V)(((ToNum(Add(((V)((MY_2762 + 4D))), h_3101)) - 0.1) - L_3118))), Add(z_3097, ((V)((FdLibm.Sin(a_3117) * ToNum(r_3099))))));
Invoke(DR_3108, "line", Call(wv_43, V.Undef, ((V)(4D)), Fn((V _arrowThis3127, int _argc3120, V t_3126, V _a3123, V _a3124, V _a3125, V[] _rest3121) => {
return Arr(Add(x_3095, ((V)((FdLibm.Cos(a_3117) * ToNum(r_3099))))), ((V)(((ToNum(Add(((V)((MY_2762 + 4D))), h_3101)) - 0.1) - (ToNum(t_3126) * L_3118)))), Add(z_3097, ((V)((FdLibm.Sin(a_3117) * ToNum(r_3099))))));
}, 1, "", true)), Call(cN_42, V.Undef, ((V)(a_3117))), ((V)(0.5)));
Call(spot_46, V.Undef, DR_3108, e_3119, Call(cN_42, V.Undef, ((V)(a_3117))), ((V)(0.32)), ((V)(0.38)), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
Call(on_2756, V.Undef, C_3107, Arr(DR_3108));
return default;
}, 1, "", true));
HT_2774 = Call(at_49, V.Undef, o_2755, Arr(((V)(0D)), ((V)((HY_2761 + 10D))), ((V)((-1D)))), ((V)("#ece6da")));
if (Truthy(HT_2774)) {
double yT_3128 = 0;
V YL_3129 = default;
V VT_3130 = default;
V TK_3131 = default;
V RDd_3132 = default;
V BD_3133 = default;
V BT2_3134 = default;
V LD_3135 = default;
V WN_3136 = default;
V WT_3137 = default;
yT_3128 = (HY_2761 + 20D);
YL_3129 = Call(dec_44, V.Undef, ((V)("#c9a868")), NewObj(1).Put("op", ((V)(0.25))).V);
VT_3130 = Call(dec_44, V.Undef, ((V)("#8a847a")), NewObj(1).Put("op", ((V)(0.85))).V);
TK_3131 = Call(dec_44, V.Undef, ((V)("#5a5650")));
RDd_3132 = Call(dec_44, V.Undef, ((V)("#d9483b")));
BD_3133 = Call(dec_44, V.Undef, ((V)("#b9bec4")));
BT2_3134 = Call(dec_44, V.Undef, ((V)("#3a3a3e")), NewObj(1).Put("op", ((V)(0.8))).V);
LD_3135 = Call(dec_44, V.Undef, ((V)("#ff3a2a")), NewObj(1).Put("emit", ((V)(1D))).V);
WN_3136 = Call(dec_44, V.Undef, ((V)("#f2c230")));
WT_3137 = Call(dec_44, V.Undef, ((V)("#2a2a2e")));
Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis3145, int _argc3138, V i_3144, V _a3141, V _a3142, V _a3143, V[] _rest3139) => {
return Call(seg_56, V.Undef, VT_3130, Arr(((V)((-12D))), ((V)(yT_3128)), ((V)(((-6.4) + (ToNum(i_3144) * 0.8))))), Arr(((V)(12D)), ((V)(yT_3128)), ((V)(((-6.4) + (ToNum(i_3144) * 0.8))))), Y3_40, ((V)(0.4)));
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(9D)), Fn((V _arrowThis3153, int _argc3146, V i_3152, V _a3149, V _a3150, V _a3151, V[] _rest3147) => {
double a_3154 = 0;
double c_3155 = 0;
double s_3156 = 0;
a_3154 = ((PI_17 * 0.75) + (((ToNum(i_3152) * PI_17) * 1.5) / 8D));
c_3155 = FdLibm.Cos(a_3154);
s_3156 = FdLibm.Sin(a_3154);
Call(seg_56, V.Undef, TK_3131, Arr(((V)((10D + (c_3155 * 2.05)))), ((V)(yT_3128)), ((V)((2D + (s_3156 * 2.05))))), Arr(((V)((10D + (c_3155 * (NumTruthy((ToNum(i_3152) % 4D)) ? 2.5 : 2.8))))), ((V)(yT_3128)), ((V)((2D + (s_3156 * (NumTruthy((ToNum(i_3152) % 4D)) ? 2.5 : 2.8)))))), Y3_40, ((V)(0.16)));
return default;
}, 1, "", true));
Call(spot_46, V.Undef, RDd_3132, Arr(((V)(10D)), ((V)((yT_3128 + 1.4))), ((V)(0.9))), Y3_40, ((V)(0.3)), ((V)(0.3)), ((V)(0D)), ((V)(6D)));
Call(spot_46, V.Undef, YL_3129, Arr(((V)(0D)), ((V)(21.8)), ((V)(5D))), Z3_41, ((V)(12D)), ((V)(2D)), ((V)(0D)), ((V)(14D)));
Invoke(BD_3133, "poly", Arr(Arr(((V)((-4D))), ((V)(21D)), ((V)(5D))), Arr(((V)(4D)), ((V)(21D)), ((V)(5D))), Arr(((V)(4D)), ((V)(22.8)), ((V)(5D))), Arr(((V)((-4D))), ((V)(22.8)), ((V)(5D)))), Z3_41);
Call(seg_56, V.Undef, BT2_3134, Arr(((V)((-3.2))), ((V)(21.9)), ((V)(5D))), Arr(((V)(1.4)), ((V)(21.9)), ((V)(5D))), Z3_41, ((V)(0.55)));
Call(spot_46, V.Undef, BT2_3134, Arr(((V)(2.8)), ((V)(21.9)), ((V)(5D))), Z3_41, ((V)(0.4)), ((V)(0.4)), ((V)(0D)), ((V)(6D)));
Call(spot_46, V.Undef, LD_3135, Arr(((V)(10D)), ((V)(22D)), ((V)(5D))), Z3_41, ((V)(0.45)), ((V)(0.45)), ((V)(0D)), ((V)(8D)));
Invoke(WN_3136, "poly", Arr(Arr(((V)(14D)), ((V)(10D)), ((V)((-4.2)))), Arr(((V)(14D)), ((V)(10D)), ((V)(1.8))), Arr(((V)(14D)), ((V)(15.4)), ((V)((-1.2))))), X3_39);
Call(seg_56, V.Undef, WT_3137, Arr(((V)(14D)), ((V)(11.9)), ((V)((-1.2)))), Arr(((V)(14D)), ((V)(13.9)), ((V)((-1.2)))), X3_39, ((V)(0.4)));
Call(spot_46, V.Undef, WT_3137, Arr(((V)(14D)), ((V)(11D)), ((V)((-1.2)))), X3_39, ((V)(0.24)), ((V)(0.24)), ((V)(0D)), ((V)(6D)));
Call(on_2756, V.Undef, HT_2774, Arr(YL_3129, VT_3130, TK_3131, RDd_3132, BD_3133, BT2_3134, LD_3135, WN_3136, WT_3137));
}
GR_2775 = Call(at_49, V.Undef, o_2755, Arr(((V)(0D)), ((V)((HY_2761 + 9D))), ((V)(5.3))), ((V)("#2b2b2e")), ((V)(0.6)), ((V)(1D)));
if (Truthy(GR_2775)) {
V GW_3157 = default;
GW_3157 = Call(dec_44, V.Undef, ((V)("#a9aeb4")), NewObj(1).Put("op", ((V)(0.9))).V);
Call(rep_28, V.Undef, ((V)(11D)), Fn((V _arrowThis3165, int _argc3158, V i_3164, V _a3161, V _a3162, V _a3163, V[] _rest3159) => {
return Call(seg_56, V.Undef, GW_3157, Arr(((V)(((-10D) + (ToNum(i_3164) * 2D)))), ((V)((HY_2761 + 3.4))), ((V)(5.66))), Arr(((V)(((-10D) + (ToNum(i_3164) * 2D)))), ((V)((HY_2761 + 15.6))), ((V)(5.66))), Z3_41, ((V)(0.22)));
}, 1, "", true));
Call(seg_56, V.Undef, GW_3157, Arr(((V)((-10.6))), ((V)((HY_2761 + 9.5))), ((V)(5.66))), Arr(((V)(10.6)), ((V)((HY_2761 + 9.5))), ((V)(5.66))), Z3_41, ((V)(0.3)));
Call(on_2756, V.Undef, GR_2775, Arr(GW_3157));
}
return default;
}, 3, "", true)));
Set(N_16, "mantel24", Call(ext_50, V.Undef, ((V)("mantel23")), Fn((V _arrowThis3175, int _argc3166, V o_3172, V on_3173, V R_3174, V _a3171, V[] _rest3167) => {
V PNT_3176 = default;
V PL2_3177 = default;
V SL_3178 = default;
double ZF_3179 = 0;
V HR_3180 = default;
V slate_3181 = default;
V FB_3182 = default;
V MP_3183 = default;
V RT_3184 = default;
V PM_3185 = default;
V nF_3186 = default;
V MF_3187 = default;
V FRb_3188 = default;
V SH_3189 = default;
PNT_3176 = ((V)("#f4f1ea"));
PL2_3177 = Call(mix_15, V.Undef, PNT_3176, ((V)("#ffffff")), ((V)(0.4)));
SL_3178 = ((V)("#2c2e33"));
ZF_3179 = 20D;
HR_3180 = Call(at_49, V.Undef, o_3172, Arr(((V)(0D)), ((V)(1.5)), ((V)(6D))), ((V)("#18191c")));
if (Truthy(HR_3180)) {
V W1_3190 = default;
V G1_3191 = default;
V G2_3192 = default;
V AS_3193 = default;
V RF_3194 = default;
V ft_3195 = default;
V ff_3196 = default;
W1_3190 = Call(dec_44, V.Undef, ((V)("#d8dce0")), NewObj(1).Put("op", ((V)(0.75))).V);
G1_3191 = Call(dec_44, V.Undef, ((V)("#5a5e66")), NewObj(1).Put("op", ((V)(0.7))).V);
G2_3192 = Call(dec_44, V.Undef, ((V)("#34373d")), NewObj(1).Put("op", ((V)(0.8))).V);
AS_3193 = Call(dec_44, V.Undef, ((V)("#8a8580")), NewObj(1).Put("op", ((V)(0.28))).V);
RF_3194 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.08))).V);
ft_3195 = Fn((V _arrowThis3205, int _argc3197, V u_3203, V v_3204, V _a3201, V _a3202, V[] _rest3198) => {
return Arr(((V)(((-69D) + (ToNum(u_3203) * 138D)))), ((V)(3D)), ((V)(((-19D) + (ToNum(v_3204) * 50D)))));
}, 2, "", true);
ff_3196 = Fn((V _arrowThis3214, int _argc3206, V u_3212, V v_3213, V _a3210, V _a3211, V[] _rest3207) => {
return Arr(((V)(((-69D) + (ToNum(u_3212) * 138D)))), ((V)((0.3 + (ToNum(v_3213) * 2.4)))), ((V)(32D)));
}, 2, "", true);
Call(speck_55, V.Undef, G2_3192, ((V)(60D)), ft_3195, Y3_40, ((V)(0.5)), ((V)(1.3)), R_3174);
Call(speck_55, V.Undef, G1_3191, ((V)(80D)), ft_3195, Y3_40, ((V)(0.15)), ((V)(0.45)), R_3174);
Call(speck_55, V.Undef, W1_3190, ((V)(50D)), ft_3195, Y3_40, ((V)(0.08)), ((V)(0.22)), R_3174);
Call(speck_55, V.Undef, G1_3191, ((V)(30D)), ff_3196, Z3_41, ((V)(0.12)), ((V)(0.35)), R_3174);
Call(speck_55, V.Undef, W1_3190, ((V)(16D)), ff_3196, Z3_41, ((V)(0.08)), ((V)(0.2)), R_3174);
Call(rep_28, V.Undef, ((V)(7D)), Fn((V _arrowThis3221, int _argc3215, V _a3217, V _a3218, V _a3219, V _a3220, V[] _rest3216) => {
return Call(spot_46, V.Undef, AS_3193, Arr(((V)(((-24D) + (ToNum(Call(R_3174, V.Undef)) * 48D)))), ((V)(3D)), ((V)((12D + (ToNum(Call(R_3174, V.Undef)) * 12D))))), Y3_40, ((V)((2D + (ToNum(Call(R_3174, V.Undef)) * 3D)))), ((V)((1D + (ToNum(Call(R_3174, V.Undef)) * 1.4)))), ((V)(((ToNum(Call(R_3174, V.Undef)) - 0.5) * 0.4))), ((V)(10D)));
}, 0, "", true));
Invoke(Invoke(RF_3194, "poly", Arr(Arr(((V)((-60D))), ((V)(3D)), ((V)(32D))), Arr(((V)((-48D))), ((V)(3D)), ((V)(32D))), Arr(((V)((-38D))), ((V)(3D)), ((V)(22.4))), Arr(((V)((-50D))), ((V)(3D)), ((V)(22.4)))), Y3_40), "poly", Arr(Arr(((V)(20D)), ((V)(3D)), ((V)(32D))), Arr(((V)(24D)), ((V)(3D)), ((V)(32D))), Arr(((V)(34D)), ((V)(3D)), ((V)(22.4))), Arr(((V)(30D)), ((V)(3D)), ((V)(22.4)))), Y3_40);
Call(on_3173, V.Undef, HR_3180, Arr(G2_3192, G1_3191, W1_3190, AS_3193, RF_3194));
}
slate_3181 = Fn((V _arrowThis3233, int _argc3222, V P_3228, V x0_3229, V x1_3230, V y0_3231, V[] _rest3223) => {
V C1_3234 = default;
V C2_3235 = default;
V RS_3236 = default;
V MI_3237 = default;
double A_3238 = 0;
double n_3239 = 0;
V y1_3232 = default;
y1_3232 = (_argc3222 > 4 ? _rest3223[0] : V.Undef);
if (!(Truthy(P_3228))) {
return default;
}
C1_3234 = Call(dec_44, V.Undef, ((V)("#1c1e22")), NewObj(1).Put("op", ((V)(0.7))).V);
C2_3235 = Call(dec_44, V.Undef, ((V)("#454951")), NewObj(1).Put("op", ((V)(0.6))).V);
RS_3236 = Call(dec_44, V.Undef, ((V)("#6e5038")), NewObj(1).Put("op", ((V)(0.35))).V);
MI_3237 = Call(dec_44, V.Undef, ((V)("#8a8f98")), NewObj(1).Put("op", ((V)(0.6))).V);
A_3238 = ((ToNum(x1_3230) - ToNum(x0_3229)) * (ToNum(y1_3232) - ToNum(y0_3231)));
n_3239 = Max(3D, Round(((ToNum(y1_3232) - ToNum(y0_3231)) / 2.4)));
Call(rep_28, V.Undef, ((V)(n_3239)), Fn((V _arrowThis3247, int _argc3240, V k_3246, V _a3243, V _a3244, V _a3245, V[] _rest3241) => {
V y_3248 = default;
double ph_3249 = 0;
V x_3250 = default;
y_3248 = Add(Add(y0_3231, ((V)((((ToNum(y1_3232) - ToNum(y0_3231)) * ToNum(Add(k_3246, ((V)(0.5))))) / n_3239)))), ((V)(((ToNum(Call(R_3174, V.Undef)) - 0.5) * 0.6))));
ph_3249 = (ToNum(Call(R_3174, V.Undef)) * 6D);
x_3250 = Add(x0_3229, ((V)((ToNum(Call(R_3174, V.Undef)) * 2D))));
while (LtN(x_3250, (ToNum(x1_3230) - 1D))) {
double L_3251 = 0;
V xa_3252 = default;
L_3251 = Min((ToNum(x1_3230) - ToNum(x_3250)), (2D + (ToNum(Call(R_3174, V.Undef)) * 8D)));
xa_3252 = x_3250;
Invoke((LtN(Call(R_3174, V.Undef), 0.6) ? C1_3234 : C2_3235), "line", Call(wv_43, V.Undef, ((V)(6D)), Fn((V _arrowThis3260, int _argc3253, V t_3259, V _a3256, V _a3257, V _a3258, V[] _rest3254) => {
return Arr(Add(xa_3252, ((V)((L_3251 * ToNum(t_3259))))), Add(y_3248, ((V)((0.35 * FdLibm.Sin(((ToNum(Add(xa_3252, ((V)((L_3251 * ToNum(t_3259)))))) * 0.5) + ph_3249)))))), ((V)(ZF_3179)));
}, 1, "", true)), Z3_41, ((V)((0.2 + (ToNum(Call(R_3174, V.Undef)) * 0.3)))), ((V)(1D)));
x_3250 = Add(x_3250, ((V)(((L_3251 + 0.5) + (ToNum(Call(R_3174, V.Undef)) * 3D)))));
}
return default;
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(Round((A_3238 / 40D)))), Fn((V _arrowThis3267, int _argc3261, V _a3263, V _a3264, V _a3265, V _a3266, V[] _rest3262) => {
return Call(spot_46, V.Undef, RS_3236, Arr(Add(Add(x0_3229, ((V)(0.6))), ((V)((ToNum(Call(R_3174, V.Undef)) * ((ToNum(x1_3230) - ToNum(x0_3229)) - 1.2))))), Add(Add(y0_3231, ((V)(0.6))), ((V)((ToNum(Call(R_3174, V.Undef)) * ((ToNum(y1_3232) - ToNum(y0_3231)) - 1.2))))), ((V)(ZF_3179))), Z3_41, ((V)((0.4 + (ToNum(Call(R_3174, V.Undef)) * 0.9)))), ((V)((0.3 + (ToNum(Call(R_3174, V.Undef)) * 0.5)))), ((V)((ToNum(Call(R_3174, V.Undef)) * 3D))), ((V)(8D)));
}, 0, "", true));
Call(speck_55, V.Undef, MI_3237, ((V)(Round((A_3238 / 12D)))), Fn((V _arrowThis3276, int _argc3268, V u_3274, V v_3275, V _a3272, V _a3273, V[] _rest3269) => {
return Arr(Add(x0_3229, ((V)((ToNum(u_3274) * (ToNum(x1_3230) - ToNum(x0_3229)))))), Add(y0_3231, ((V)((ToNum(v_3275) * (ToNum(y1_3232) - ToNum(y0_3231)))))), ((V)(ZF_3179)));
}, 2, "", true), Z3_41, ((V)(0.08)), ((V)(0.2)), R_3174);
Call(on_3173, V.Undef, P_3228, Arr(RS_3236, C1_3234, C2_3235, MI_3237));
return default;
}, 5, "", true);
Call(slate_3181, V.Undef, Call(at_49, V.Undef, o_3172, Arr(((V)((-34D))), ((V)(20D)), ((V)(0D))), SL_3178), ((V)((-37.6))), ((V)((-31.2))), ((V)(3.6)), ((V)(52.2)));
Call(slate_3181, V.Undef, Call(at_49, V.Undef, o_3172, Arr(((V)(34D)), ((V)(20D)), ((V)(0D))), SL_3178), ((V)(31.2)), ((V)(37.6)), ((V)(3.6)), ((V)(52.2)));
Call(slate_3181, V.Undef, Call(at_49, V.Undef, o_3172, Arr(((V)(0D)), ((V)(57D)), ((V)(0D))), SL_3178), ((V)((-37.6))), ((V)(37.6)), ((V)(53.9)), ((V)(60.6)));
FB_3182 = Call(at_49, V.Undef, o_3172, Arr(((V)(0D)), ((V)(20D)), ((V)((-18.5)))), ((V)("#5e3426")));
if (Truthy(FB_3182)) {
V SO_3277 = default;
V SO2_3278 = default;
SO_3277 = Call(dec_44, V.Undef, ((V)("#0a0605")), NewObj(1).Put("op", ((V)(0.3))).V);
SO2_3278 = Call(dec_44, V.Undef, ((V)("#1a0e0a")), NewObj(1).Put("op", ((V)(0.45))).V);
Call(rep_28, V.Undef, ((V)(9D)), Fn((V _arrowThis3286, int _argc3279, V i_3285, V _a3282, V _a3283, V _a3284, V[] _rest3280) => {
double x_3287 = 0;
double y0_3288 = 0;
double L_3289 = 0;
double ph_3290 = 0;
x_3287 = (((-24D) + (ToNum(i_3285) * 6D)) + ((ToNum(Call(R_3174, V.Undef)) - 0.5) * 2D));
y0_3288 = (16D + (ToNum(Call(R_3174, V.Undef)) * 6D));
L_3289 = (18D + (ToNum(Call(R_3174, V.Undef)) * 14D));
ph_3290 = (ToNum(Call(R_3174, V.Undef)) * 6D);
Invoke(SO_3277, "line", Call(wv_43, V.Undef, ((V)(10D)), Fn((V _arrowThis3298, int _argc3291, V t_3297, V _a3294, V _a3295, V _a3296, V[] _rest3292) => {
return Arr(((V)((x_3287 + (1.4 * FdLibm.Sin(((ToNum(t_3297) * 4D) + ph_3290)))))), ((V)(Min(52.4, (y0_3288 + (L_3289 * ToNum(t_3297)))))), ((V)((-16.9))));
}, 1, "", true)), Z3_41, ((V)((2D + (ToNum(Call(R_3174, V.Undef)) * 2.4)))), ((V)(1D)));
return default;
}, 1, "", true));
Call(speck_55, V.Undef, SO2_3278, ((V)(14D)), Fn((V _arrowThis3307, int _argc3299, V u_3305, V v_3306, V _a3303, V _a3304, V[] _rest3300) => {
return Arr(((V)(((-28D) + (ToNum(u_3305) * 56D)))), ((V)((6D + (ToNum(v_3306) * 12D)))), ((V)((-16.9))));
}, 2, "", true), Z3_41, ((V)(0.6)), ((V)(1.6)), R_3174);
Call(on_3173, V.Undef, FB_3182, Arr(SO_3277, SO2_3278));
}
Invoke(Arr(Arr(((V)("#6a5442")), Arr(((V)((-20D))), ((V)(11D)), ((V)(6D))), Arr(((V)(20D)), ((V)(11D)), ((V)(6D))), ((V)(2.6))), Arr(((V)("#5e4a3a")), Arr(((V)((-18D))), ((V)(11.2)), ((V)((-6D)))), Arr(((V)(19D)), ((V)(11.6)), ((V)((-6D)))), ((V)(2.8))), Arr(((V)("#725a46")), Arr(((V)((-12D))), ((V)(16.6)), ((V)((-4D)))), Arr(((V)(14D)), ((V)(16D)), ((V)(3D))), ((V)(2.2)))), "forEach", Fn((V _arrowThis3323, int _argc3308, V _a3310, V _a3311, V _a3312, V _a3313, V[] _rest3309) => {
V L_3324 = default;
V u_3325 = default;
V e2_3326 = default;
V e1_3327 = default;
double len_3328 = 0;
V P_3329 = default;
V BK2_3330 = default;
V BH_3331 = default;
V AS_3332 = default;
V EM_3333 = default;
V col_3316 = default;
V a_3318 = default;
V b_3320 = default;
V r_3322 = default;
{ V _t3314 = ListOf(_a3310);
{ V _t3315 = GetIdx(_t3314, 0D);
col_3316 = _t3315; }
{ V _t3317 = GetIdx(_t3314, 1D);
a_3318 = _t3317; }
{ V _t3319 = GetIdx(_t3314, 2D);
b_3320 = _t3319; }
{ V _t3321 = GetIdx(_t3314, 3D);
r_3322 = _t3321; }
}
L_3324 = Call(at_49, V.Undef, o_3172, Call(mul_36, V.Undef, Call(add_34, V.Undef, a_3318, b_3320), ((V)(0.5))), col_3316);
if (!(Truthy(L_3324))) {
return default;
}
u_3325 = Call(nz_38, V.Undef, Call(sub_35, V.Undef, b_3320, a_3318));
e2_3326 = Call(nz_38, V.Undef, Call(cr_37, V.Undef, u_3325, Y3_40));
e1_3327 = Call(nz_38, V.Undef, Call(cr_37, V.Undef, e2_3326, u_3325));
len_3328 = Hypot((ToNum(GetIdx(b_3320, 0D)) - ToNum(GetIdx(a_3318, 0D))), (ToNum(GetIdx(b_3320, 1D)) - ToNum(GetIdx(a_3318, 1D))), (ToNum(GetIdx(b_3320, 2D)) - ToNum(GetIdx(a_3318, 2D))));
P_3329 = Fn((V _arrowThis3342, int _argc3334, V t_3340, V th_3341, V _a3338, V _a3339, V[] _rest3335) => {
V n_3343 = default;
n_3343 = Call(add_34, V.Undef, Call(mul_36, V.Undef, e1_3327, ((V)(FdLibm.Cos(ToNum(th_3341))))), Call(mul_36, V.Undef, e2_3326, ((V)(FdLibm.Sin(ToNum(th_3341))))));
return Arr(Call(add_34, V.Undef, Call(add_34, V.Undef, a_3318, Call(mul_36, V.Undef, u_3325, ((V)((ToNum(t_3340) * len_3328))))), Call(mul_36, V.Undef, n_3343, r_3322)), n_3343);
return default;
}, 2, "", true);
BK2_3330 = Call(dec_44, V.Undef, Call(shade_14, V.Undef, col_3316, ((V)(0.62))), NewObj(1).Put("op", ((V)(0.8))).V);
BH_3331 = Call(dec_44, V.Undef, Call(shade_14, V.Undef, col_3316, ((V)(1.35))), NewObj(1).Put("op", ((V)(0.55))).V);
AS_3332 = Call(dec_44, V.Undef, ((V)("#e8e2d8")), NewObj(1).Put("op", ((V)(0.75))).V);
EM_3333 = Call(dec_44, V.Undef, ((V)("#ff7a2a")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.9))).V);
Call(rep_28, V.Undef, ((V)(9D)), Fn((V _arrowThis3351, int _argc3344, V i_3350, V _a3347, V _a3348, V _a3349, V[] _rest3345) => {
double th_3352 = 0;
double t0_3353 = 0;
double t1_3354 = 0;
V Q_3355 = default;
th_3352 = ((((-PI_17) * 0.7) + (((ToNum(i_3350) * PI_17) * 1.4) / 8D)) + ((ToNum(Call(R_3174, V.Undef)) - 0.5) * 0.2));
t0_3353 = (0.04 + (ToNum(Call(R_3174, V.Undef)) * 0.2));
t1_3354 = (0.75 + (ToNum(Call(R_3174, V.Undef)) * 0.2));
Q_3355 = Call(wv_43, V.Undef, ((V)(10D)), Fn((V _arrowThis3363, int _argc3356, V s_3362, V _a3359, V _a3360, V _a3361, V[] _rest3357) => {
return Call(P_3329, V.Undef, ((V)((t0_3353 + ((t1_3354 - t0_3353) * ToNum(s_3362))))), ((V)((th_3352 + (0.08 * FdLibm.Sin(ToNum(Add(((V)((ToNum(s_3362) * 9D))), i_3350))))))));
}, 1, "", true));
Invoke((NumTruthy((ToNum(i_3350) % 2D)) ? BH_3331 : BK2_3330), "line", Invoke(Q_3355, "map", Fn((V _arrowThis3371, int _argc3364, V q_3370, V _a3367, V _a3368, V _a3369, V[] _rest3365) => {
return GetIdx(q_3370, 0D);
}, 1, "", true)), Invoke(Q_3355, "map", Fn((V _arrowThis3379, int _argc3372, V q_3378, V _a3375, V _a3376, V _a3377, V[] _rest3373) => {
return GetIdx(q_3378, 1D);
}, 1, "", true)), ((V)((0.3 + (ToNum(Call(R_3174, V.Undef)) * 0.25)))), ((V)(1D)));
return default;
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(7D)), Fn((V _arrowThis3386, int _argc3380, V _a3382, V _a3383, V _a3384, V _a3385, V[] _rest3381) => {
V p_3387 = default;
V n_3388 = default;
{ V _t3389 = Call(P_3329, V.Undef, ((V)((0.1 + (ToNum(Call(R_3174, V.Undef)) * 0.8)))), ((V)(((ToNum(Call(R_3174, V.Undef)) - 0.5) * 0.9))));
{ V _t3390 = ListOf(_t3389);
{ V _t3391 = GetIdx(_t3390, 0D);
p_3387 = _t3391; }
{ V _t3392 = GetIdx(_t3390, 1D);
n_3388 = _t3392; }
} }
Call(spot_46, V.Undef, AS_3332, p_3387, n_3388, ((V)((0.8 + (ToNum(Call(R_3174, V.Undef)) * 1.2)))), ((V)((0.4 + (ToNum(Call(R_3174, V.Undef)) * 0.5)))), ((V)(0D)), ((V)(8D)));
return default;
}, 0, "", true));
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis3400, int _argc3393, V i_3399, V _a3396, V _a3397, V _a3398, V[] _rest3394) => {
double t_3401 = 0;
V Q_3402 = default;
t_3401 = ((0.2 + (ToNum(i_3399) * 0.26)) + (ToNum(Call(R_3174, V.Undef)) * 0.06));
Q_3402 = Call(wv_43, V.Undef, ((V)(5D)), Fn((V _arrowThis3410, int _argc3403, V s_3409, V _a3406, V _a3407, V _a3408, V[] _rest3404) => {
return Call(P_3329, V.Undef, ((V)((t_3401 + (ToNum(s_3409) * 0.08)))), ((V)(((PI_17 * 0.58) + (ToNum(s_3409) * 0.3)))));
}, 1, "", true));
Invoke(EM_3333, "line", Invoke(Q_3402, "map", Fn((V _arrowThis3418, int _argc3411, V q_3417, V _a3414, V _a3415, V _a3416, V[] _rest3412) => {
return GetIdx(q_3417, 0D);
}, 1, "", true)), Invoke(Q_3402, "map", Fn((V _arrowThis3426, int _argc3419, V q_3425, V _a3422, V _a3423, V _a3424, V[] _rest3420) => {
return GetIdx(q_3425, 1D);
}, 1, "", true)), ((V)(0.28)), ((V)(1D)));
return default;
}, 1, "", true));
Call(on_3173, V.Undef, L_3324, Arr(BK2_3330, BH_3331, AS_3332, EM_3333));
return default;
}, 1, "", true));
MP_3183 = Arr(((V)(0D)), ((V)(92D)), ((V)((-16D))));
RT_3184 = Call(rotF_21, V.Undef, X3_39, ((V)((-0.06))));
PM_3185 = Fn((V _arrowThis3434, int _argc3427, V v_3433, V _a3430, V _a3431, V _a3432, V[] _rest3428) => {
return Call(rp_32, V.Undef, RT_3184, MP_3183, v_3433);
}, 1, "", true);
nF_3186 = Call(RT_3184, V.Undef, Z3_41);
MF_3187 = Call(at_49, V.Undef, o_3172, Call(PM_3185, V.Undef, Arr(((V)(0D)), ((V)(112D)), ((V)((-17D))))), ((V)("#c9a04a")));
if (Truthy(MF_3187)) {
V HL_3435 = default;
V DK_3436 = default;
V FX2_3437 = default;
double z_3438 = 0;
V rl_3439 = default;
V bead_3440 = default;
HL_3435 = Call(dec_44, V.Undef, ((V)("#f6dc8a")), NewObj(1).Put("op", ((V)(0.9))).V);
DK_3436 = Call(dec_44, V.Undef, ((V)("#7a5a22")), NewObj(1).Put("op", ((V)(0.75))).V);
FX2_3437 = Call(dec_44, V.Undef, ((V)("#8a7a5a")), NewObj(1).Put("op", ((V)(0.3))).V);
z_3438 = (-16D);
rl_3439 = Fn((V _arrowThis3453, int _argc3441, V D_3447, V x0_3448, V y0_3449, V x1_3450, V[] _rest3442) => {
V y1_3451 = default;
V w_3452 = default;
y1_3451 = (_argc3441 > 4 ? _rest3442[0] : V.Undef);
w_3452 = (_argc3441 > 5 ? _rest3442[1] : V.Undef);
Invoke(Arr(Arr(x0_3448, y0_3449, x1_3450, y0_3449), Arr(x1_3450, y0_3449, x1_3450, y1_3451), Arr(x1_3450, y1_3451, x0_3448, y1_3451), Arr(x0_3448, y1_3451, x0_3448, y0_3449)), "forEach", Fn((V _arrowThis3469, int _argc3454, V _a3456, V _a3457, V _a3458, V _a3459, V[] _rest3455) => {
V a_3462 = default;
V b_3464 = default;
V c_3466 = default;
V d_3468 = default;
{ V _t3460 = ListOf(_a3456);
{ V _t3461 = GetIdx(_t3460, 0D);
a_3462 = _t3461; }
{ V _t3463 = GetIdx(_t3460, 1D);
b_3464 = _t3463; }
{ V _t3465 = GetIdx(_t3460, 2D);
c_3466 = _t3465; }
{ V _t3467 = GetIdx(_t3460, 3D);
d_3468 = _t3467; }
}
return Call(seg_56, V.Undef, D_3447, Call(PM_3185, V.Undef, Arr(a_3462, b_3464, ((V)(z_3438)))), Call(PM_3185, V.Undef, Arr(c_3466, d_3468, ((V)(z_3438)))), nF_3186, w_3452);
}, 1, "", true));
return default;
}, 6, "", true);
Call(rl_3439, V.Undef, DK_3436, ((V)((-20.4))), ((V)(94.6)), ((V)(20.4)), ((V)(129.4)), ((V)(0.4)));
Call(rl_3439, V.Undef, HL_3435, ((V)((-22.6))), ((V)(92.4)), ((V)(22.6)), ((V)(131.6)), ((V)(0.3)));
Call(rl_3439, V.Undef, DK_3436, ((V)((-22.1))), ((V)(92.9)), ((V)(22.1)), ((V)(131.1)), ((V)(0.16)));
bead_3440 = Fn((V _arrowThis3478, int _argc3470, V x_3476, V y_3477, V _a3474, V _a3475, V[] _rest3471) => {
Call(spot_46, V.Undef, DK_3436, Call(PM_3185, V.Undef, Arr(Add(x_3476, ((V)(0.12))), ((V)((ToNum(y_3477) - 0.12))), ((V)(z_3438)))), nF_3186, ((V)(0.36)), ((V)(0.36)), ((V)(0D)), ((V)(6D)));
Call(spot_46, V.Undef, HL_3435, Call(PM_3185, V.Undef, Arr(x_3476, y_3477, ((V)(z_3438)))), nF_3186, ((V)(0.3)), ((V)(0.3)), ((V)(0D)), ((V)(6D)));
return default;
}, 2, "", true);
Call(rep_28, V.Undef, ((V)(19D)), Fn((V _arrowThis3486, int _argc3479, V i_3485, V _a3482, V _a3483, V _a3484, V[] _rest3480) => {
double x_3487 = 0;
x_3487 = ((-18D) + (ToNum(i_3485) * 2D));
Call(bead_3440, V.Undef, ((V)(x_3487)), ((V)(93.5)));
Call(bead_3440, V.Undef, ((V)(x_3487)), ((V)(130.5)));
return default;
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(16D)), Fn((V _arrowThis3495, int _argc3488, V i_3494, V _a3491, V _a3492, V _a3493, V[] _rest3489) => {
double y_3496 = 0;
y_3496 = (97D + (ToNum(i_3494) * 2.05));
Call(bead_3440, V.Undef, ((V)((-21.5))), ((V)(y_3496)));
Call(bead_3440, V.Undef, ((V)(21.5)), ((V)(y_3496)));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-21.5))), ((V)(93.5))), Arr(((V)(21.5)), ((V)(93.5))), Arr(((V)((-21.5))), ((V)(130.5))), Arr(((V)(21.5)), ((V)(130.5)))), "forEach", Fn((V _arrowThis3508, int _argc3497, V _a3499, V _a3500, V _a3501, V _a3502, V[] _rest3498) => {
V x_3505 = default;
V y_3507 = default;
{ V _t3503 = ListOf(_a3499);
{ V _t3504 = GetIdx(_t3503, 0D);
x_3505 = _t3504; }
{ V _t3506 = GetIdx(_t3503, 1D);
y_3507 = _t3506; }
}
Call(spot_46, V.Undef, DK_3436, Call(PM_3185, V.Undef, Arr(Add(x_3505, ((V)(0.2))), ((V)((ToNum(y_3507) - 0.2))), ((V)(z_3438)))), nF_3186, ((V)(1.3)), ((V)(1.3)), ((V)(0D)), ((V)(10D)));
Call(spot_46, V.Undef, HL_3435, Call(PM_3185, V.Undef, Arr(x_3505, y_3507, ((V)(z_3438)))), nF_3186, ((V)(1.15)), ((V)(1.15)), ((V)(0D)), ((V)(10D)));
Call(spot_46, V.Undef, DK_3436, Call(PM_3185, V.Undef, Arr(x_3505, y_3507, ((V)(z_3438)))), nF_3186, ((V)(0.45)), ((V)(0.45)), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-18D))), ((V)(97D)), ((V)(2.4))), Arr(((V)(17D)), ((V)(127D)), ((V)(2D))), Arr(((V)((-16.6))), ((V)(126.6)), ((V)(1.2))), Arr(((V)(18D)), ((V)(98.6)), ((V)(1.4)))), "forEach", Fn((V _arrowThis3522, int _argc3509, V _a3511, V _a3512, V _a3513, V _a3514, V[] _rest3510) => {
V x_3517 = default;
V y_3519 = default;
V r2_3521 = default;
{ V _t3515 = ListOf(_a3511);
{ V _t3516 = GetIdx(_t3515, 0D);
x_3517 = _t3516; }
{ V _t3518 = GetIdx(_t3515, 1D);
y_3519 = _t3518; }
{ V _t3520 = GetIdx(_t3515, 2D);
r2_3521 = _t3520; }
}
return Call(rep_28, V.Undef, ((V)(4D)), Fn((V _arrowThis3529, int _argc3523, V _a3525, V _a3526, V _a3527, V _a3528, V[] _rest3524) => {
return Call(spot_46, V.Undef, FX2_3437, Call(PM_3185, V.Undef, Arr(Add(x_3517, ((V)((((ToNum(Call(R_3174, V.Undef)) - 0.5) * ToNum(r2_3521)) * 2D)))), Add(y_3519, ((V)((((ToNum(Call(R_3174, V.Undef)) - 0.5) * ToNum(r2_3521)) * 2D)))), ((V)((-15.9))))), nF_3186, ((V)((0.3 + (ToNum(Call(R_3174, V.Undef)) * 0.6)))), ((V)((0.3 + (ToNum(Call(R_3174, V.Undef)) * 0.5)))), ((V)((ToNum(Call(R_3174, V.Undef)) * 3D))), ((V)(8D)));
}, 0, "", true));
}, 1, "", true));
Call(on_3173, V.Undef, MF_3187, Arr(FX2_3437, DK_3436, HL_3435));
}
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3537, int _argc3530, V sg_3536, V _a3533, V _a3534, V _a3535, V[] _rest3531) => {
V P_3538 = default;
double x_3539 = 0;
V n_3540 = default;
V SD_3541 = default;
V HL_3542 = default;
V SC_3543 = default;
V CK_3544 = default;
V pr_3545 = default;
P_3538 = Call(at_49, V.Undef, o_3172, Arr(((V)((ToNum(sg_3536) * 51.5))), ((V)(30D)), ((V)(0D))), PNT_3176);
if (!(Truthy(P_3538))) {
return default;
}
x_3539 = (ToNum(sg_3536) * 65D);
n_3540 = Call(mul_36, V.Undef, X3_39, sg_3536);
SD_3541 = Call(dec_44, V.Undef, ((V)("#c9c4ba")), NewObj(1).Put("op", ((V)(0.75))).V);
HL_3542 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.9))).V);
SC_3543 = Call(dec_44, V.Undef, ((V)("#9a958c")), NewObj(1).Put("op", ((V)(0.35))).V);
CK_3544 = Call(dec_44, V.Undef, ((V)("#a8a398")), NewObj(1).Put("op", ((V)(0.5))).V);
pr_3545 = Fn((V _arrowThis3558, int _argc3546, V D_3552, V z0_3553, V y0_3554, V z1_3555, V[] _rest3547) => {
V y1_3556 = default;
V w_3557 = default;
y1_3556 = (_argc3546 > 4 ? _rest3547[0] : V.Undef);
w_3557 = (_argc3546 > 5 ? _rest3547[1] : V.Undef);
Call(seg_56, V.Undef, D_3552, Arr(((V)(x_3539)), y0_3554, z0_3553), Arr(((V)(x_3539)), y0_3554, z1_3555), n_3540, w_3557);
Call(seg_56, V.Undef, D_3552, Arr(((V)(x_3539)), y1_3556, z0_3553), Arr(((V)(x_3539)), y1_3556, z1_3555), n_3540, w_3557);
Call(seg_56, V.Undef, D_3552, Arr(((V)(x_3539)), y0_3554, z0_3553), Arr(((V)(x_3539)), y1_3556, z0_3553), n_3540, w_3557);
Call(seg_56, V.Undef, D_3552, Arr(((V)(x_3539)), y0_3554, z1_3555), Arr(((V)(x_3539)), y1_3556, z1_3555), n_3540, w_3557);
return default;
}, 6, "", true);
Call(pr_3545, V.Undef, SD_3541, ((V)((-15D))), ((V)(13D)), ((V)(15D)), ((V)(53D)), ((V)(0.5)));
Call(pr_3545, V.Undef, HL_3542, ((V)((-14.4))), ((V)(13.6)), ((V)(14.4)), ((V)(52.4)), ((V)(0.3)));
Call(seg_56, V.Undef, SD_3541, Arr(((V)(x_3539)), ((V)(9D)), ((V)((-19.6)))), Arr(((V)(x_3539)), ((V)(9D)), ((V)(19.6))), n_3540, ((V)(0.4)));
Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis3565, int _argc3559, V _a3561, V _a3562, V _a3563, V _a3564, V[] _rest3560) => {
double xx_3566 = 0;
double y_3567 = 0;
double a_3568 = 0;
double L_3569 = 0;
xx_3566 = ((ToNum(sg_3536) * 51.5) + ((ToNum(Call(R_3174, V.Undef)) - 0.5) * 18D));
y_3567 = (3.6 + (ToNum(Call(R_3174, V.Undef)) * 4D));
a_3568 = ((ToNum(Call(R_3174, V.Undef)) - 0.5) * 0.6);
L_3569 = (1.4 + (ToNum(Call(R_3174, V.Undef)) * 2.6));
Call(seg_56, V.Undef, SC_3543, Arr(((V)(xx_3566)), ((V)(y_3567)), ((V)(22.2))), Arr(((V)((xx_3566 + (FdLibm.Cos(a_3568) * L_3569)))), ((V)((y_3567 + (FdLibm.Sin(a_3568) * L_3569)))), ((V)(22.2))), Z3_41, ((V)(0.3)));
return default;
}, 0, "", true));
Invoke(CK_3544, "line", Arr(Arr(((V)(x_3539)), ((V)(40D)), ((V)((-8D)))), Arr(((V)(x_3539)), ((V)(37.6)), ((V)((-6.4)))), Arr(((V)(x_3539)), ((V)(36.2)), ((V)((-7.6)))), Arr(((V)(x_3539)), ((V)(33D)), ((V)((-5.8))))), n_3540, ((V)(0.14)));
Call(on_3173, V.Undef, P_3538, Arr(SD_3541, HL_3542, SC_3543, CK_3544));
return default;
}, 1, "", true));
FRb_3188 = Call(at_49, V.Undef, o_3172, Arr(((V)(0D)), ((V)(70D)), ((V)(0D))), PNT_3176);
if (Truthy(FRb_3188)) {
V SW_3570 = default;
V SS_3571 = default;
V CR2_3572 = default;
SW_3570 = Call(dec_44, V.Undef, PL2_3177);
SS_3571 = Call(dec_44, V.Undef, ((V)("#bdb6a8")), NewObj(1).Put("op", ((V)(0.85))).V);
CR2_3572 = Call(dec_44, V.Undef, ((V)("#b8b2a6")), NewObj(1).Put("op", ((V)(0.4))).V);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3580, int _argc3573, V sg_3579, V _a3576, V _a3577, V _a3578, V[] _rest3574) => {
V A_3581 = default;
A_3581 = Call(wv_43, V.Undef, ((V)(16D)), Fn((V _arrowThis3589, int _argc3582, V t_3588, V _a3585, V _a3586, V _a3587, V[] _rest3583) => {
return Arr(((V)((ToNum(sg_3579) * (22D + (16D * ToNum(t_3588)))))), ((V)((82D - (6.5 * FdLibm.Sin((PI_17 * ToNum(t_3588))))))), ((V)(ZF_3179)));
}, 1, "", true));
Invoke(SS_3571, "line", Invoke(A_3581, "map", Fn((V _arrowThis3597, int _argc3590, V p_3596, V _a3593, V _a3594, V _a3595, V[] _rest3591) => {
return Arr(GetIdx(p_3596, 0D), ((V)((ToNum(GetIdx(p_3596, 1D)) - 0.7))), ((V)(ZF_3179)));
}, 1, "", true)), Z3_41, ((V)(1.7)), ((V)(1D)));
Invoke(SW_3570, "line", A_3581, Z3_41, ((V)(1.8)), ((V)(1D)));
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis3605, int _argc3598, V k_3604, V _a3601, V _a3602, V _a3603, V[] _rest3599) => {
V p_3606 = default;
p_3606 = GetIdx(A_3581, ((1D + (ToNum(k_3604) * 2D)) + 1D));
Call(seg_56, V.Undef, SS_3571, Arr(((V)((ToNum(GetIdx(p_3606, 0D)) - 0.6))), Add(GetIdx(p_3606, 1D), ((V)(0.7))), ((V)(ZF_3179))), Arr(Add(GetIdx(p_3606, 0D), ((V)(0.6))), ((V)((ToNum(GetIdx(p_3606, 1D)) - 0.7))), ((V)(ZF_3179))), Z3_41, ((V)(0.25)));
return default;
}, 1, "", true));
Invoke(Arr(((V)(22D)), ((V)(38D))), "forEach", Fn((V _arrowThis3614, int _argc3607, V x0_3613, V _a3610, V _a3611, V _a3612, V[] _rest3608) => {
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis3622, int _argc3615, V j_3621, V _a3618, V _a3619, V _a3620, V[] _rest3616) => {
double y_3623 = 0;
y_3623 = (80D - (ToNum(j_3621) * 2.2));
Call(spot_46, V.Undef, SS_3571, Arr(((V)(((ToNum(sg_3579) * ToNum(x0_3613)) + 0.2))), ((V)((y_3623 - 0.3))), ((V)(ZF_3179))), Z3_41, ((V)((0.8 - (ToNum(j_3621) * 0.15)))), ((V)((0.95 - (ToNum(j_3621) * 0.15)))), ((V)(0D)), ((V)(8D)));
Call(spot_46, V.Undef, SW_3570, Arr(((V)((ToNum(sg_3579) * ToNum(x0_3613)))), ((V)(y_3623)), ((V)(ZF_3179))), Z3_41, ((V)((0.72 - (ToNum(j_3621) * 0.15)))), ((V)((0.88 - (ToNum(j_3621) * 0.15)))), ((V)(0D)), ((V)(8D)));
return default;
}, 1, "", true));
Call(spot_46, V.Undef, SS_3571, Arr(((V)(((ToNum(sg_3579) * ToNum(x0_3613)) + 0.2))), ((V)(82.3)), ((V)(ZF_3179))), Z3_41, ((V)(1.3)), ((V)(0.9)), ((V)(0D)), ((V)(10D)));
Call(spot_46, V.Undef, SW_3570, Arr(((V)((ToNum(sg_3579) * ToNum(x0_3613)))), ((V)(82.6)), ((V)(ZF_3179))), Z3_41, ((V)(1.2)), ((V)(0.8)), ((V)(0D)), ((V)(10D)));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(4D)), Fn((V _arrowThis3630, int _argc3624, V _a3626, V _a3627, V _a3628, V _a3629, V[] _rest3625) => {
double x_3631 = 0;
double y_3632 = 0;
x_3631 = ((-38D) + (ToNum(Call(R_3174, V.Undef)) * 76D));
y_3632 = (62D + (ToNum(Call(R_3174, V.Undef)) * 3D));
Invoke(CR2_3572, "line", Call(wv_43, V.Undef, ((V)(4D)), Fn((V _arrowThis3640, int _argc3633, V t_3639, V _a3636, V _a3637, V _a3638, V[] _rest3634) => {
return Arr(((V)((x_3631 + (ToNum(t_3639) * 3D)))), ((V)((y_3632 + (((((ToNum(t_3639) * 4D) % 2D) > 1D) ? 0.4 : (-0.4)) * ToNum(Add(Call(R_3174, V.Undef), ((V)(0.3)))))))), ((V)(ZF_3179)));
}, 1, "", true)), Z3_41, ((V)(0.12)));
return default;
}, 0, "", true));
Call(on_3173, V.Undef, FRb_3188, Arr(SS_3571, SW_3570, CR2_3572));
}
SH_3189 = Call(at_49, V.Undef, o_3172, Arr(((V)(0D)), ((V)(90D)), ((V)(2D))), PL2_3177);
if (Truthy(SH_3189)) {
V G_3641 = default;
V WX_3642 = default;
V WXs_3643 = default;
G_3641 = Call(dec_44, V.Undef, ((V)("#d8d2c6")), NewObj(1).Put("op", ((V)(0.28))).V);
WX_3642 = Call(dec_44, V.Undef, ((V)("#fbf6ea")));
WXs_3643 = Call(dec_44, V.Undef, ((V)("#d8d0c0")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(grainX_54, V.Undef, G_3641, G_3641, ((V)((-69D))), ((V)(69D)), ((V)(92D)), ((V)((-20D))), ((V)(24D)), ((V)(10D)), R_3174, ((V)(0.25)));
Invoke(Arr(((V)((-54D))), ((V)(54D))), "forEach", Fn((V _arrowThis3651, int _argc3644, V x_3650, V _a3647, V _a3648, V _a3649, V[] _rest3645) => {
return Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis3658, int _argc3652, V _a3654, V _a3655, V _a3656, V _a3657, V[] _rest3653) => {
double a_3659 = 0;
V c_3660 = default;
a_3659 = ((ToNum(Call(R_3174, V.Undef)) * 2D) * PI_17);
c_3660 = Arr(Add(x_3650, ((V)((FdLibm.Cos(a_3659) * 4.4)))), ((V)(92D)), ((V)((6D + (FdLibm.Sin(a_3659) * 4.4)))));
Call(spot_46, V.Undef, WXs_3643, c_3660, Y3_40, ((V)(0.9)), ((V)(0.7)), ((V)(a_3659)), ((V)(8D)));
Call(spot_46, V.Undef, WX_3642, c_3660, Y3_40, ((V)(0.72)), ((V)(0.55)), ((V)(a_3659)), ((V)(8D)));
return default;
}, 0, "", true));
}, 1, "", true));
Call(on_3173, V.Undef, SH_3189, Arr(G_3641, WXs_3643, WX_3642));
}
Invoke(Arr(((V)((-54D))), ((V)(54D))), "forEach", Fn((V _arrowThis3668, int _argc3661, V x_3667, V _a3664, V _a3665, V _a3666, V[] _rest3662) => {
V C_3669 = default;
V DR_3670 = default;
V DS_3671 = default;
C_3669 = Call(at_49, V.Undef, o_3172, Arr(x_3667, ((V)(111D)), ((V)(6D))), ((V)("#f8f2e4")));
if (!(Truthy(C_3669))) {
return default;
}
DR_3670 = Call(dec_44, V.Undef, ((V)("#fffcf4")));
DS_3671 = Call(dec_44, V.Undef, ((V)("#e0d6c4")), NewObj(1).Put("op", ((V)(0.75))).V);
Call(rep_28, V.Undef, ((V)(4D)), Fn((V _arrowThis3679, int _argc3672, V i_3678, V _a3675, V _a3676, V _a3677, V[] _rest3673) => {
double a_3680 = 0;
double L_3681 = 0;
V pa_3682 = default;
a_3680 = ((0.4 + (ToNum(i_3678) * 1.6)) + (ToNum(Call(R_3174, V.Undef)) * 0.5));
L_3681 = (1.4 + (ToNum(Call(R_3174, V.Undef)) * 4D));
pa_3682 = Fn((V _arrowThis3691, int _argc3683, V aa_3689, V t_3690, V _a3687, V _a3688, V[] _rest3684) => {
return Arr(Add(x_3667, ((V)((FdLibm.Cos(ToNum(aa_3689)) * 1.4)))), ((V)((116.9 - (ToNum(t_3690) * L_3681)))), ((V)((6D + (FdLibm.Sin(ToNum(aa_3689)) * 1.4)))));
}, 2, "", true);
Invoke(DS_3671, "line", Call(wv_43, V.Undef, ((V)(4D)), Fn((V _arrowThis3699, int _argc3692, V t_3698, V _a3695, V _a3696, V _a3697, V[] _rest3693) => {
return Call(pa_3682, V.Undef, ((V)((a_3680 + 0.12))), t_3698);
}, 1, "", true)), Call(cN_42, V.Undef, ((V)((a_3680 + 0.12)))), ((V)(0.45)));
Invoke(DR_3670, "line", Call(wv_43, V.Undef, ((V)(4D)), Fn((V _arrowThis3707, int _argc3700, V t_3706, V _a3703, V _a3704, V _a3705, V[] _rest3701) => {
return Call(pa_3682, V.Undef, ((V)(a_3680)), t_3706);
}, 1, "", true)), Call(cN_42, V.Undef, ((V)(a_3680))), ((V)(0.42)));
Call(spot_46, V.Undef, DR_3670, Call(pa_3682, V.Undef, ((V)(a_3680)), ((V)(1D))), Call(cN_42, V.Undef, ((V)(a_3680))), ((V)(0.32)), ((V)(0.4)), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
Call(on_3173, V.Undef, C_3669, Arr(DS_3671, DR_3670));
return default;
}, 1, "", true));
return default;
}, 3, "", true)));
Set(N_16, "etha24", Call(ext_50, V.Undef, ((V)("etha23")), Fn((V _arrowThis3717, int _argc3708, V o_3714, V on_3715, V R_3716, V _a3713, V[] _rest3709) => {
V ST_3718 = default;
V GL_3719 = default;
double ZF_3720 = 0;
V SB_3721 = default;
V SC0_3722 = default;
V stones_3723 = default;
V SL_3724 = default;
V BT_3725 = default;
V FP_3726 = default;
V BPn_3727 = default;
V RL_3728 = default;
ST_3718 = ((V)("#1b1d22"));
GL_3719 = ((V)("#d6f0fa"));
ZF_3720 = 20D;
SB_3721 = Call(at_49, V.Undef, o_3714, Arr(((V)(0D)), ((V)(10D)), ((V)(0D))), ST_3718);
SC0_3722 = Arr(((V)("#f4f1ea")), ((V)("#dcd8cf")), ((V)("#b9b4aa")), ((V)("#e8e4dc")));
stones_3723 = (Truthy(SB_3721) ? Invoke(o_3714, "filter", Fn((V _arrowThis3736, int _argc3729, V S_3735, V _a3732, V _a3733, V _a3734, V[] _rest3730) => {
return ((SEq(Get(S_3735, "par"), SB_3721) ? V.True : V.False) is var _t3737 && !Truthy(_t3737) ? _t3737 : Invoke(SC0_3722, "includes", Get(S_3735, "col")));
}, 1, "", true)) : Arr());
SL_3724 = Invoke(stones_3723, "map", Fn((V _arrowThis3745, int _argc3738, V S_3744, V _a3741, V _a3742, V _a3743, V[] _rest3739) => {
V L_3746 = default;
L_3746 = Call(bb_48, V.Undef, S_3744);
return Arr(((V)((ToNum(Add(GetIdx(L_3746, 0D), GetIdx(L_3746, 1D))) / 2D))), ((V)((ToNum(Add(GetIdx(L_3746, 2D), GetIdx(L_3746, 3D))) / 2D))), ((V)((ToNum(Add(GetIdx(L_3746, 4D), GetIdx(L_3746, 5D))) / 2D))), ((V)(((ToNum(GetIdx(L_3746, 1D)) - ToNum(GetIdx(L_3746, 0D))) / 2D))), ((V)(((ToNum(GetIdx(L_3746, 3D)) - ToNum(GetIdx(L_3746, 2D))) / 2D))));
return default;
}, 1, "", true));
if (Truthy(SB_3721)) {
V MI_3747 = default;
V GR_3748 = default;
V EH_3749 = default;
V ffr_3750 = default;
V ftp_3751 = default;
double zc_3752 = 0;
V FLm_3753 = default;
V FLi_3754 = default;
V LV_3755 = default;
V PW_3756 = default;
MI_3747 = Call(dec_44, V.Undef, ((V)("#c8ccd4")), NewObj(1).Put("op", ((V)(0.55))).V);
GR_3748 = Call(dec_44, V.Undef, ((V)("#3a3e46")), NewObj(1).Put("op", ((V)(0.7))).V);
EH_3749 = Call(dec_44, V.Undef, ((V)("#555a64")), NewObj(1).Put("op", ((V)(0.9))).V);
ffr_3750 = Fn((V _arrowThis3765, int _argc3757, V u_3763, V v_3764, V _a3761, V _a3762, V[] _rest3758) => {
double x_3766 = 0;
double y_3767 = 0;
x_3766 = ((-55D) + (ToNum(u_3763) * 110D));
y_3767 = (7.2 + (ToNum(v_3764) * 5.8));
return (((((x_3766 > 38D) && (x_3766 < 50D)) && (y_3767 > 8.4)) && (y_3767 < 12.6)) ? V.Null : Arr(((V)(x_3766)), ((V)(y_3767)), ((V)(ZF_3720))));
return default;
}, 2, "", true);
ftp_3751 = Fn((V _arrowThis3776, int _argc3768, V u_3774, V v_3775, V _a3772, V _a3773, V[] _rest3769) => {
double x_3777 = 0;
double z_3778 = 0;
x_3777 = ((-55D) + (ToNum(u_3774) * 110D));
z_3778 = ((-19.5) + (ToNum(v_3775) * 39D));
return (Truthy(((((System.Math.Abs(x_3777) < 40.5) && (System.Math.Abs(z_3778) < 5.5)) ? V.True : V.False) is var _t3787 && Truthy(_t3787) ? _t3787 : Invoke(SL_3724, "some", Fn((V _arrowThis3786, int _argc3779, V s_3785, V _a3782, V _a3783, V _a3784, V[] _rest3780) => {
return (Lt(((V)(Hypot((x_3777 - ToNum(GetIdx(s_3785, 0D))), (z_3778 - ToNum(GetIdx(s_3785, 2D)))))), Add(GetIdx(s_3785, 3D), ((V)(0.4)))) ? V.True : V.False);
}, 1, "", true)))) ? V.Null : Arr(((V)(x_3777)), ((V)(15D)), ((V)(z_3778))));
return default;
}, 2, "", true);
Call(speck_55, V.Undef, GR_3748, ((V)(50D)), ffr_3750, Z3_41, ((V)(0.2)), ((V)(0.6)), R_3716);
Call(speck_55, V.Undef, MI_3747, ((V)(40D)), ffr_3750, Z3_41, ((V)(0.06)), ((V)(0.16)), R_3716);
Call(speck_55, V.Undef, GR_3748, ((V)(70D)), ftp_3751, Y3_40, ((V)(0.2)), ((V)(0.55)), R_3716);
Call(speck_55, V.Undef, MI_3747, ((V)(50D)), ftp_3751, Y3_40, ((V)(0.06)), ((V)(0.16)), R_3716);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3795, int _argc3788, V s_3794, V _a3791, V _a3792, V _a3793, V[] _rest3789) => {
V f_3796 = default;
V n_3797 = default;
f_3796 = Fn((V _arrowThis3806, int _argc3798, V u_3804, V v_3805, V _a3802, V _a3803, V[] _rest3799) => {
return Arr(((V)((ToNum(s_3794) * 56D))), ((V)((7.2 + (ToNum(v_3805) * 7.4)))), ((V)(((-19.4) + (ToNum(u_3804) * 38.8)))));
}, 2, "", true);
n_3797 = Call(mul_36, V.Undef, X3_39, s_3794);
Call(speck_55, V.Undef, GR_3748, ((V)(14D)), f_3796, n_3797, ((V)(0.2)), ((V)(0.5)), R_3716);
Call(speck_55, V.Undef, MI_3747, ((V)(10D)), f_3796, n_3797, ((V)(0.06)), ((V)(0.16)), R_3716);
Call(seg_56, V.Undef, EH_3749, Arr(((V)((ToNum(s_3794) * 56D))), ((V)(14.7)), ((V)((-19.4)))), Arr(((V)((ToNum(s_3794) * 56D))), ((V)(14.7)), ((V)(19.4))), n_3797, ((V)(0.3)));
Call(seg_56, V.Undef, EH_3749, Arr(((V)((ToNum(s_3794) * 55.7))), ((V)(15D)), ((V)((-19.4)))), Arr(((V)((ToNum(s_3794) * 55.7))), ((V)(15D)), ((V)(19.4))), Y3_40, ((V)(0.3)));
return default;
}, 1, "", true));
Call(seg_56, V.Undef, EH_3749, Arr(((V)((-55.4))), ((V)(15D)), ((V)(19.7))), Arr(((V)(55.4)), ((V)(15D)), ((V)(19.7))), Y3_40, ((V)(0.35)));
Call(seg_56, V.Undef, EH_3749, Arr(((V)((-55.4))), ((V)(14.6)), ((V)(ZF_3720))), Arr(((V)(55.4)), ((V)(14.6)), ((V)(ZF_3720))), Z3_41, ((V)(0.3)));
zc_3752 = (ZF_3720 + 0.15);
FLm_3753 = Call(dec_44, V.Undef, ((V)("#ff9a3a")), NewObj(1).Put("emit", ((V)(1D))).V);
FLi_3754 = Call(dec_44, V.Undef, ((V)("#ffe08a")), NewObj(1).Put("emit", ((V)(1D))).V);
LV_3755 = Invoke(Arr(((V)("#3ad6a0")), ((V)("#3ad6a0")), ((V)("#ffd24a")), ((V)("#3a4450"))), "map", Fn((V _arrowThis3815, int _argc3807, V c_3813, V i_3814, V _a3811, V _a3812, V[] _rest3808) => {
return Call(dec_44, V.Undef, c_3813, NewObj(1).Put("emit", ((V)((LtN(i_3814, 3D) ? 1D : 0D)))).V);
}, 2, "", true));
PW_3756 = Call(dec_44, V.Undef, ((V)("#7fe8ff")), NewObj(1).Put("emit", ((V)(1D))).V);
Invoke(FLm_3753, "poly", Arr(Arr(((V)(40.8)), ((V)(9.5)), ((V)(zc_3752))), Arr(((V)(41.9)), ((V)(9.5)), ((V)(zc_3752))), Arr(((V)(42.2)), ((V)(10.5)), ((V)(zc_3752))), Arr(((V)(41.5)), ((V)(11.6)), ((V)(zc_3752))), Arr(((V)(41.3)), ((V)(10.8)), ((V)(zc_3752))), Arr(((V)(40.9)), ((V)(11.2)), ((V)(zc_3752))), Arr(((V)(40.5)), ((V)(10.4)), ((V)(zc_3752)))), Z3_41);
Invoke(FLi_3754, "poly", Call(elP_45, V.Undef, Arr(((V)(41.4)), ((V)(10D)), ((V)(zc_3752))), X3_39, Y3_40, ((V)(0.3)), ((V)(0.4)), ((V)(6D))), Z3_41);
Invoke(LV_3755, "forEach", Fn((V _arrowThis3824, int _argc3816, V D_3822, V i_3823, V _a3820, V _a3821, V[] _rest3817) => {
return Invoke(D_3822, "poly", Arr(Arr(((V)((43.4 + (ToNum(i_3823) * 1.1)))), ((V)(9.6)), ((V)(zc_3752))), Arr(((V)((44.1 + (ToNum(i_3823) * 1.1)))), ((V)(9.6)), ((V)(zc_3752))), Arr(((V)((44.1 + (ToNum(i_3823) * 1.1)))), ((V)((10D + (ToNum(i_3823) * 0.45)))), ((V)(zc_3752))), Arr(((V)((43.4 + (ToNum(i_3823) * 1.1)))), ((V)((10D + (ToNum(i_3823) * 0.45)))), ((V)(zc_3752)))), Z3_41);
}, 2, "", true));
Invoke(PW_3756, "line", Call(wv_43, V.Undef, ((V)(14D)), Fn((V _arrowThis3832, int _argc3825, V t_3831, V _a3828, V _a3829, V _a3830, V[] _rest3826) => {
double a_3833 = 0;
a_3833 = (0.6 + (ToNum(t_3831) * ((2D * PI_17) - 1.2)));
return Arr(((V)((47.9 + (FdLibm.Sin(a_3833) * 0.55)))), ((V)((10.4 + (FdLibm.Cos(a_3833) * 0.55)))), ((V)(zc_3752)));
return default;
}, 1, "", true)), Z3_41, ((V)(0.18)));
Call(seg_56, V.Undef, PW_3756, Arr(((V)(47.9)), ((V)(10.4)), ((V)(zc_3752))), Arr(((V)(47.9)), ((V)(11.1)), ((V)(zc_3752))), Z3_41, ((V)(0.18)));
Call(on_3715, V.Undef, SB_3721, Invoke(Arr(GR_3748, MI_3747, EH_3749, FLm_3753, FLi_3754, PW_3756), "concat", LV_3755));
Invoke(stones_3723, "forEach", Fn((V _arrowThis3842, int _argc3834, V S_3840, V i_3841, V _a3838, V _a3839, V[] _rest3835) => {
V cx_3843 = default;
V cy_3844 = default;
V cz_3845 = default;
V rx_3846 = default;
V ry_3847 = default;
V pt_3848 = default;
V HLs_3849 = default;
V FK_3850 = default;
V p_3851 = default;
V n_3852 = default;
{ V _t3853 = GetK(SL_3724, i_3841);
{ V _t3854 = ListOf(_t3853);
{ V _t3855 = GetIdx(_t3854, 0D);
cx_3843 = _t3855; }
{ V _t3856 = GetIdx(_t3854, 1D);
cy_3844 = _t3856; }
{ V _t3857 = GetIdx(_t3854, 2D);
cz_3845 = _t3857; }
{ V _t3858 = GetIdx(_t3854, 3D);
rx_3846 = _t3858; }
{ V _t3859 = GetIdx(_t3854, 4D);
ry_3847 = _t3859; }
} }
pt_3848 = Fn((V _arrowThis3867, int _argc3860, V d_3866, V _a3863, V _a3864, V _a3865, V[] _rest3861) => {
d_3866 = Call(nz_38, V.Undef, d_3866);
return Arr(Arr(Add(cx_3843, ((V)((ToNum(GetIdx(d_3866, 0D)) * ToNum(rx_3846))))), Add(cy_3844, ((V)((ToNum(GetIdx(d_3866, 1D)) * ToNum(ry_3847))))), Add(cz_3845, ((V)((ToNum(GetIdx(d_3866, 2D)) * ToNum(rx_3846)))))), Call(nz_38, V.Undef, Arr(((V)((ToNum(GetIdx(d_3866, 0D)) / ToNum(rx_3846)))), ((V)((ToNum(GetIdx(d_3866, 1D)) / ToNum(ry_3847)))), ((V)((ToNum(GetIdx(d_3866, 2D)) / ToNum(rx_3846)))))));
return default;
}, 1, "", true);
HLs_3849 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.6))).V);
FK_3850 = Call(dec_44, V.Undef, Call(shade_14, V.Undef, Get(S_3840, "col"), ((V)(0.7))), NewObj(1).Put("op", ((V)(0.8))).V);
{ V _t3868 = Call(pt_3848, V.Undef, Arr(((V)((-0.35))), ((V)(1D)), ((V)((-0.3)))));
{ V _t3869 = ListOf(_t3868);
{ V _t3870 = GetIdx(_t3869, 0D);
p_3851 = _t3870; }
{ V _t3871 = GetIdx(_t3869, 1D);
n_3852 = _t3871; }
} }
Call(spot_46, V.Undef, HLs_3849, p_3851, n_3852, ((V)((ToNum(rx_3846) * 0.28))), ((V)((ToNum(rx_3846) * 0.18))), ((V)(0.5)), ((V)(8D)));
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis3878, int _argc3872, V _a3874, V _a3875, V _a3876, V _a3877, V[] _rest3873) => {
{ V _t3879 = Call(pt_3848, V.Undef, Arr(((V)(((ToNum(Call(R_3716, V.Undef)) - 0.5) * 1.2))), ((V)(1D)), ((V)(((ToNum(Call(R_3716, V.Undef)) - 0.5) * 1.2)))));
{ V _t3880 = ListOf(_t3879);
{ V _t3881 = GetIdx(_t3880, 0D);
p_3851 = _t3881; }
{ V _t3882 = GetIdx(_t3880, 1D);
n_3852 = _t3882; }
} }
Call(spot_46, V.Undef, FK_3850, p_3851, n_3852, ((V)((0.12 + (ToNum(Call(R_3716, V.Undef)) * 0.12)))), ((V)((0.1 + (ToNum(Call(R_3716, V.Undef)) * 0.08)))), ((V)(0D)), ((V)(5D)));
return default;
}, 0, "", true));
Call(on_3715, V.Undef, S_3840, Arr(FK_3850, HLs_3849));
return default;
}, 2, "", true));
}
BT_3725 = Call(at_49, V.Undef, o_3714, Arr(((V)(0D)), ((V)(16D)), ((V)(0D))), CH_19);
if (Truthy(BT_3725)) {
V B1_3883 = default;
V B2_3884 = default;
V SC_3885 = default;
B1_3883 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.55))).V);
B2_3884 = Call(dec_44, V.Undef, ((V)("#8e989f")), NewObj(1).Put("op", ((V)(0.5))).V);
SC_3885 = Call(dec_44, V.Undef, ((V)("#3a3e44")), NewObj(1).Put("op", ((V)(0.85))).V);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3893, int _argc3886, V s_3892, V _a3889, V _a3890, V _a3891, V[] _rest3887) => {
return Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis3901, int _argc3894, V k_3900, V _a3897, V _a3898, V _a3899, V[] _rest3895) => {
return Call(seg_56, V.Undef, (NumTruthy((ToNum(k_3900) % 2D)) ? B2_3884 : B1_3883), Arr(((V)((-39.4))), ((V)(17D)), ((V)((ToNum(s_3892) * (2.1 + (ToNum(k_3900) * 0.6)))))), Arr(((V)(39.4)), ((V)(17D)), ((V)((ToNum(s_3892) * (2.1 + (ToNum(k_3900) * 0.6)))))), Y3_40, ((V)((0.14 + ((ToNum(k_3900) % 2D) * 0.06)))));
}, 1, "", true));
}, 1, "", true));
Call(seg_56, V.Undef, B1_3883, Arr(((V)((-39.4))), ((V)(16.4)), ((V)(5D))), Arr(((V)(39.4)), ((V)(16.4)), ((V)(5D))), Z3_41, ((V)(0.25)));
Invoke(Arr(Arr(((V)(38.6)), ((V)(3.3))), Arr(((V)(38.6)), ((V)((-3.3)))), Arr(((V)((-38.6))), ((V)(3.3))), Arr(((V)((-38.6))), ((V)((-3.3))))), "forEach", Fn((V _arrowThis3913, int _argc3902, V _a3904, V _a3905, V _a3906, V _a3907, V[] _rest3903) => {
V x_3910 = default;
V z_3912 = default;
{ V _t3908 = ListOf(_a3904);
{ V _t3909 = GetIdx(_t3908, 0D);
x_3910 = _t3909; }
{ V _t3911 = GetIdx(_t3908, 1D);
z_3912 = _t3911; }
}
Call(spot_46, V.Undef, SC_3885, Arr(x_3910, ((V)(17D)), z_3912), Y3_40, ((V)(0.38)), ((V)(0.38)), ((V)(0D)), ((V)(8D)));
Call(seg_56, V.Undef, B1_3883, Arr(((V)((ToNum(x_3910) - 0.3))), ((V)(17D)), z_3912), Arr(Add(x_3910, ((V)(0.3))), ((V)(17D)), z_3912), Y3_40, ((V)(0.1)));
return default;
}, 1, "", true));
Call(on_3715, V.Undef, BT_3725, Arr(B2_3884, B1_3883, SC_3885, Call(cyl_12, V.Undef, ((V)(38.6)), ((V)(17D)), ((V)(0D)), ((V)(0.9)), ((V)(0.5)), ((V)("#9aa3aa")), Call(M__24, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))));
}
FP_3726 = Call(at_49, V.Undef, o_3714, Arr(((V)(0D)), ((V)(30D)), ((V)(18.7))), GL_3719);
if (Truthy(FP_3726)) {
V SM_3914 = default;
V FPr_3915 = default;
V ED_3916 = default;
SM_3914 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.1))).V);
FPr_3915 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.18))).V);
ED_3916 = Call(dec_44, V.Undef, ((V)("#78c4a8")), NewObj(1).Put("op", ((V)(0.8))).V);
Invoke(Arr(Arr(((V)((-36D))), ((V)(24D)), ((V)(4D)), ((V)(2.6))), Arr(((V)((-31D))), ((V)(22D)), ((V)(2D)), ((V)(1.4))), Arr(((V)(22D)), ((V)(40D)), ((V)(3D)), ((V)(2D))), Arr(((V)(44D)), ((V)(21D)), ((V)(2.2)), ((V)(1.6)))), "forEach", Fn((V _arrowThis3932, int _argc3917, V _a3919, V _a3920, V _a3921, V _a3922, V[] _rest3918) => {
V x_3925 = default;
V y_3927 = default;
V rx_3929 = default;
V ry_3931 = default;
{ V _t3923 = ListOf(_a3919);
{ V _t3924 = GetIdx(_t3923, 0D);
x_3925 = _t3924; }
{ V _t3926 = GetIdx(_t3923, 1D);
y_3927 = _t3926; }
{ V _t3928 = GetIdx(_t3923, 2D);
rx_3929 = _t3928; }
{ V _t3930 = GetIdx(_t3923, 3D);
ry_3931 = _t3930; }
}
return Call(spot_46, V.Undef, SM_3914, Arr(x_3925, y_3927, ((V)(19D))), Z3_41, rx_3929, ry_3931, ((V)(0.3)), ((V)(12D)));
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis3940, int _argc3933, V i_3939, V _a3936, V _a3937, V _a3938, V[] _rest3934) => {
return Invoke(Arr(((V)(1.2)), ((V)(0.85)), ((V)(0.5))), "forEach", Fn((V _arrowThis3948, int _argc3941, V k_3947, V _a3944, V _a3945, V _a3946, V[] _rest3942) => {
return Invoke(FPr_3915, "line", Call(wv_43, V.Undef, ((V)(14D)), Fn((V _arrowThis3956, int _argc3949, V t_3955, V _a3952, V _a3953, V _a3954, V[] _rest3950) => {
return Arr(((V)(((26D + (ToNum(i_3939) * 1.8)) + ((FdLibm.Cos(((ToNum(t_3955) * 2D) * PI_17)) * ToNum(k_3947)) * 0.8)))), ((V)(((22.5 - (ToNum(i_3939) * 0.5)) + (FdLibm.Sin(((ToNum(t_3955) * 2D) * PI_17)) * ToNum(k_3947))))), ((V)(19D)));
}, 1, "", true)), Z3_41, ((V)(0.1)));
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3964, int _argc3957, V s_3963, V _a3960, V _a3961, V _a3962, V[] _rest3958) => {
return Call(seg_56, V.Undef, ED_3916, Arr(((V)((ToNum(s_3963) * 54D))), ((V)(15.3)), ((V)(18.7))), Arr(((V)((ToNum(s_3963) * 54D))), ((V)(50.4)), ((V)(18.7))), Call(mul_36, V.Undef, X3_39, s_3963), ((V)(0.55)));
}, 1, "", true));
Call(on_3715, V.Undef, FP_3726, Arr(SM_3914, FPr_3915, ED_3916));
}
BPn_3727 = Call(at_49, V.Undef, o_3714, Arr(((V)(0D)), ((V)(30D)), ((V)((-18.7)))), ((V)("#14161a")));
if (Truthy(BPn_3727)) {
V RF_3965 = default;
V RF2_3966 = default;
V DS_3967 = default;
double zb_3968 = 0;
RF_3965 = Call(dec_44, V.Undef, ((V)("#ff9a4a")), NewObj(1).Put("op", ((V)(0.07))).V);
RF2_3966 = Call(dec_44, V.Undef, ((V)("#ffd9a0")), NewObj(1).Put("op", ((V)(0.16))).V);
DS_3967 = Call(dec_44, V.Undef, ((V)("#8a8f98")), NewObj(1).Put("op", ((V)(0.25))).V);
zb_3968 = (-18.4);
Call(spot_46, V.Undef, RF_3965, Arr(((V)(0D)), ((V)(24D)), ((V)(zb_3968))), Z3_41, ((V)(40D)), ((V)(6D)), ((V)(0D)), ((V)(20D)));
Call(spot_46, V.Undef, RF_3965, Arr(((V)(0D)), ((V)(21D)), ((V)(zb_3968))), Z3_41, ((V)(34D)), ((V)(3D)), ((V)(0D)), ((V)(18D)));
Invoke(RF2_3966, "poly", Arr(Arr(((V)((-38D))), ((V)(17.4)), ((V)(zb_3968))), Arr(((V)(38D)), ((V)(17.4)), ((V)(zb_3968))), Arr(((V)(38D)), ((V)(18.4)), ((V)(zb_3968))), Arr(((V)((-38D))), ((V)(18.4)), ((V)(zb_3968)))), Z3_41);
Call(speck_55, V.Undef, DS_3967, ((V)(26D)), Fn((V _arrowThis3977, int _argc3969, V u_3975, V v_3976, V _a3973, V _a3974, V[] _rest3970) => {
return Arr(((V)(((-52D) + (ToNum(u_3975) * 104D)))), ((V)((16D + (ToNum(v_3976) * 34D)))), ((V)(zb_3968)));
}, 2, "", true), Z3_41, ((V)(0.1)), ((V)(0.3)), R_3716);
Call(on_3715, V.Undef, BPn_3727, Arr(RF_3965, RF2_3966, DS_3967));
}
RL_3728 = Call(at_49, V.Undef, o_3714, Arr(((V)(0D)), ((V)(51D)), ((V)(18.7))), CH_19, ((V)(0.6)), ((V)(1D)));
if (Truthy(RL_3728)) {
V H_3978 = default;
H_3978 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.75))).V);
Call(seg_56, V.Undef, H_3978, Arr(((V)((-54D))), ((V)(51.1)), ((V)(19.16))), Arr(((V)(54D)), ((V)(51.1)), ((V)(19.16))), Z3_41, ((V)(0.25)));
Call(on_3715, V.Undef, RL_3728, Arr(H_3978));
}
return default;
}, 3, "", true)));
{
V arcW_3979 = default;
V f1_3980 = default;
V face_3981 = default;
V frame_3982 = default;
V an_3983 = default;
V em_3984 = default;
V fxEll_3985 = default;
V FONT_3986 = default;
V RG_3987 = default;
V ell_3988 = default;
V atS_3989 = default;
V GOLD_3990 = default;
V P2_3991 = default;
V L__3992 = default;
V NL_3993 = default;
V rq_3994 = default;
V cP_3995 = default;
V dash_3996 = default;
V ringL_3997 = default;
V vL_3998 = default;
V band3_3999 = default;
V spotC_4000 = default;
V heart_4001 = default;
V elS_4002 = default;
V flameG_4003 = default;
{ V _t4004 = K_10;
if (_t4004.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4004));
{ V _t4005 = Get(_t4004, "arcW");
arcW_3979 = _t4005; } }
f1_3980 = Get(K_10, "f1");
{ V _t4006 = Get(RD_8, "H23");
if (_t4006.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4006));
{ V _t4007 = Get(_t4006, "face");
face_3981 = _t4007; } }
{ V _t4008 = Get(RD_8, "H16");
if (_t4008.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4008));
{ V _t4009 = Get(_t4008, "frame");
frame_3982 = _t4009; }
{ V _t4010 = Get(_t4008, "an");
an_3983 = _t4010; }
{ V _t4011 = Get(_t4008, "em");
em_3984 = _t4011; }
{ V _t4012 = Get(_t4008, "fxEll");
fxEll_3985 = _t4012; }
{ V _t4013 = Get(_t4008, "FONT");
FONT_3986 = _t4013; } }
{ V _t4014 = Get(RD_8, "H22");
if (_t4014.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4014));
{ V _t4015 = Get(_t4014, "RG");
RG_3987 = _t4015; }
{ V _t4016 = Get(_t4014, "ell");
ell_3988 = _t4016; } }
atS_3989 = Get(Get(RD_8, "H3"), "atS");
GOLD_3990 = ((V)("#e2b14a"));
P2_3991 = Fn((V _arrowThis4024, int _argc4017, V q_4023, V _a4020, V _a4021, V _a4022, V[] _rest4018) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_3980, V.Undef, GetIdx(q_4023, 0D))).S(" ").V(Call(f1_3980, V.Undef, GetIdx(q_4023, 1D))).End()));
}, 1, "", true);
L__3992 = Fn((V _arrowThis4034, int _argc4025, V cx_4031, V cz_4032, V yw_4033, V _a4030, V[] _rest4026) => {
double c_4035 = 0;
double s_4036 = 0;
c_4035 = FdLibm.Cos(ToNum((yw_4033 is var _t4037 && Truthy(_t4037) ? _t4037 : ((V)(0D)))));
s_4036 = FdLibm.Sin(ToNum((yw_4033 is var _t4038 && Truthy(_t4038) ? _t4038 : ((V)(0D)))));
return Fn((V _arrowThis4048, int _argc4039, V u_4045, V y_4046, V v_4047, V _a4044, V[] _rest4040) => {
return Arr(((V)((ToNum(Add(cx_4031, ((V)((ToNum(u_4045) * c_4035))))) - (ToNum(v_4047) * s_4036)))), y_4046, Add(Add(cz_4032, ((V)((ToNum(u_4045) * s_4036)))), ((V)((ToNum(v_4047) * c_4035)))));
}, 3, "", true);
return default;
}, 3, "", true);
NL_3993 = Fn((V _arrowThis4056, int _argc4049, V yw_4055, V _a4052, V _a4053, V _a4054, V[] _rest4050) => {
double c_4057 = 0;
double s_4058 = 0;
c_4057 = FdLibm.Cos(ToNum((yw_4055 is var _t4059 && Truthy(_t4059) ? _t4059 : ((V)(0D)))));
s_4058 = FdLibm.Sin(ToNum((yw_4055 is var _t4060 && Truthy(_t4060) ? _t4060 : ((V)(0D)))));
return Fn((V _arrowThis4069, int _argc4061, V u_4067, V v_4068, V _a4065, V _a4066, V[] _rest4062) => {
return Arr(((V)(((ToNum(u_4067) * c_4057) - (ToNum(v_4068) * s_4058)))), ((V)(0D)), ((V)(((ToNum(u_4067) * s_4058) + (ToNum(v_4068) * c_4057)))));
}, 2, "", true);
return default;
}, 1, "", true);
rq_3994 = Fn((V _arrowThis4082, int _argc4070, V L_4076, V u0_4077, V v0_4078, V u1_4079, V[] _rest4071) => {
V v1_4080 = default;
V y_4081 = default;
v1_4080 = (_argc4070 > 4 ? _rest4071[0] : V.Undef);
y_4081 = (_argc4070 > 5 ? _rest4071[1] : V.Undef);
return Arr(Call(L_4076, V.Undef, u0_4077, y_4081, v0_4078), Call(L_4076, V.Undef, u1_4079, y_4081, v0_4078), Call(L_4076, V.Undef, u1_4079, y_4081, v1_4080), Call(L_4076, V.Undef, u0_4077, y_4081, v1_4080));
}, 6, "", true);
cP_3995 = Fn((V _arrowThis4094, int _argc4083, V cx_4089, V cz_4090, V r_4091, V a_4092, V[] _rest4084) => {
V y_4093 = default;
y_4093 = (_argc4083 > 4 ? _rest4084[0] : V.Undef);
return Arr(Add(cx_4089, ((V)((FdLibm.Cos(ToNum(a_4092)) * ToNum(r_4091))))), y_4093, Add(cz_4090, ((V)((FdLibm.Sin(ToNum(a_4092)) * ToNum(r_4091))))));
}, 5, "", true);
dash_3996 = Fn((V _arrowThis4110, int _argc4095, V D_4101, V L_4102, V u0_4103, V v0_4104, V[] _rest4096) => {
V u1_4105 = default;
V v1_4106 = default;
V y_4107 = default;
V w_4108 = default;
V len_4109 = default;
u1_4105 = (_argc4095 > 4 ? _rest4096[0] : V.Undef);
v1_4106 = (_argc4095 > 5 ? _rest4096[1] : V.Undef);
y_4107 = (_argc4095 > 6 ? _rest4096[2] : V.Undef);
w_4108 = (_argc4095 > 7 ? _rest4096[3] : V.Undef);
len_4109 = (_argc4095 > 8 ? _rest4096[4] : V.Undef);
return Invoke(Arr(Arr(u0_4103, v0_4104, u1_4105, v0_4104), Arr(u1_4105, v0_4104, u1_4105, v1_4106), Arr(u1_4105, v1_4106, u0_4103, v1_4106), Arr(u0_4103, v1_4106, u0_4103, v0_4104)), "forEach", Fn((V _arrowThis4126, int _argc4111, V _a4113, V _a4114, V _a4115, V _a4116, V[] _rest4112) => {
double n_4127 = 0;
V a_4119 = default;
V b_4121 = default;
V c_4123 = default;
V d_4125 = default;
{ V _t4117 = ListOf(_a4113);
{ V _t4118 = GetIdx(_t4117, 0D);
a_4119 = _t4118; }
{ V _t4120 = GetIdx(_t4117, 1D);
b_4121 = _t4120; }
{ V _t4122 = GetIdx(_t4117, 2D);
c_4123 = _t4122; }
{ V _t4124 = GetIdx(_t4117, 3D);
d_4125 = _t4124; }
}
n_4127 = Max(2D, Round((Hypot((ToNum(c_4123) - ToNum(a_4119)), (ToNum(d_4125) - ToNum(b_4121))) / ToNum(len_4109))));
{
double i_4128 = 0;
i_4128 = 0D;
while (true) {
if (!((i_4128 < n_4127))) break;
double t0_4130 = 0;
double t1_4131 = 0;
t0_4130 = (i_4128 / n_4127);
t1_4131 = ((i_4128 + 1D) / n_4127);
Invoke(D_4101, "line", Arr(Call(L_4102, V.Undef, Add(a_4119, ((V)(((ToNum(c_4123) - ToNum(a_4119)) * t0_4130)))), y_4107, Add(b_4121, ((V)(((ToNum(d_4125) - ToNum(b_4121)) * t0_4130))))), Call(L_4102, V.Undef, Add(a_4119, ((V)(((ToNum(c_4123) - ToNum(a_4119)) * t1_4131)))), y_4107, Add(b_4121, ((V)(((ToNum(d_4125) - ToNum(b_4121)) * t1_4131)))))), Y3_40, w_4108);
i_4128 = (i_4128 + 2D);
}
}
return default;
}, 1, "", true));
}, 9, "", true);
ringL_3997 = Fn((V _arrowThis4148, int _argc4132, V D_4138, V cx_4139, V cz_4140, V rf_4141, V[] _rest4133) => {
V y_4142 = default;
V w_4143 = default;
V a0_4144 = default;
V a1_4145 = default;
V m_4146 = default;
V wob_4147 = default;
y_4142 = (_argc4132 > 4 ? _rest4133[0] : V.Undef);
w_4143 = (_argc4132 > 5 ? _rest4133[1] : V.Undef);
a0_4144 = (_argc4132 > 6 ? _rest4133[2] : V.Undef);
a1_4145 = (_argc4132 > 7 ? _rest4133[3] : V.Undef);
m_4146 = (_argc4132 > 8 ? _rest4133[4] : V.Undef);
wob_4147 = (_argc4132 > 9 ? _rest4133[5] : V.Undef);
return Invoke(D_4138, "line", Call(wv_43, V.Undef, m_4146, Fn((V _arrowThis4156, int _argc4149, V t_4155, V _a4152, V _a4153, V _a4154, V[] _rest4150) => {
V a_4157 = default;
a_4157 = Add(a0_4144, ((V)(((ToNum(a1_4145) - ToNum(a0_4144)) * ToNum(t_4155)))));
return Call(cP_3995, V.Undef, cx_4139, cz_4140, Call(rf_4141, V.Undef, y_4142), a_4157, Add(y_4142, (Truthy(wob_4147) ? Call(wob_4147, V.Undef, a_4157) : ((V)(0D)))));
return default;
}, 1, "", true)), Call(wv_43, V.Undef, m_4146, Fn((V _arrowThis4165, int _argc4158, V t_4164, V _a4161, V _a4162, V _a4163, V[] _rest4159) => {
return Call(cN_42, V.Undef, Add(a0_4144, ((V)(((ToNum(a1_4145) - ToNum(a0_4144)) * ToNum(t_4164))))));
}, 1, "", true)), w_4143);
}, 10, "", true);
vL_3998 = Fn((V _arrowThis4180, int _argc4166, V D_4172, V cx_4173, V cz_4174, V rf_4175, V[] _rest4167) => {
V a_4176 = default;
V y0_4177 = default;
V y1_4178 = default;
V w_4179 = default;
a_4176 = (_argc4166 > 4 ? _rest4167[0] : V.Undef);
y0_4177 = (_argc4166 > 5 ? _rest4167[1] : V.Undef);
y1_4178 = (_argc4166 > 6 ? _rest4167[2] : V.Undef);
w_4179 = (_argc4166 > 7 ? _rest4167[3] : V.Undef);
return Invoke(D_4172, "line", Call(wv_43, V.Undef, ((V)(6D)), Fn((V _arrowThis4188, int _argc4181, V t_4187, V _a4184, V _a4185, V _a4186, V[] _rest4182) => {
V y_4189 = default;
y_4189 = Add(y0_4177, ((V)(((ToNum(y1_4178) - ToNum(y0_4177)) * ToNum(t_4187)))));
return Call(cP_3995, V.Undef, cx_4173, cz_4174, Call(rf_4175, V.Undef, y_4189), a_4176, y_4189);
return default;
}, 1, "", true)), Call(cN_42, V.Undef, a_4176), w_4179);
}, 8, "", true);
band3_3999 = Fn((V _arrowThis4205, int _argc4190, V D_4196, V cx_4197, V cz_4198, V rf_4199, V[] _rest4191) => {
V y0_4200 = default;
V y1_4201 = default;
V a0_4202 = default;
V a1_4203 = default;
V m_4204 = default;
y0_4200 = (_argc4190 > 4 ? _rest4191[0] : V.Undef);
y1_4201 = (_argc4190 > 5 ? _rest4191[1] : V.Undef);
a0_4202 = (_argc4190 > 6 ? _rest4191[2] : V.Undef);
a1_4203 = (_argc4190 > 7 ? _rest4191[3] : V.Undef);
m_4204 = (_argc4190 > 8 ? _rest4191[4] : V.Undef);
return Call(rep_28, V.Undef, m_4204, Fn((V _arrowThis4213, int _argc4206, V i_4212, V _a4209, V _a4210, V _a4211, V[] _rest4207) => {
V p_4214 = default;
V q_4215 = default;
p_4214 = Add(a0_4202, ((V)((((ToNum(a1_4203) - ToNum(a0_4202)) * ToNum(i_4212)) / ToNum(m_4204)))));
q_4215 = Add(a0_4202, ((V)((((ToNum(a1_4203) - ToNum(a0_4202)) * ToNum(Add(i_4212, ((V)(1D))))) / ToNum(m_4204)))));
Invoke(D_4196, "poly", Arr(Call(cP_3995, V.Undef, cx_4197, cz_4198, Call(rf_4199, V.Undef, y0_4200), p_4214, y0_4200), Call(cP_3995, V.Undef, cx_4197, cz_4198, Call(rf_4199, V.Undef, y0_4200), q_4215, y0_4200), Call(cP_3995, V.Undef, cx_4197, cz_4198, Call(rf_4199, V.Undef, y1_4201), q_4215, y1_4201), Call(cP_3995, V.Undef, cx_4197, cz_4198, Call(rf_4199, V.Undef, y1_4201), p_4214, y1_4201)), Call(cN_42, V.Undef, ((V)((ToNum(Add(p_4214, q_4215)) / 2D)))));
return default;
}, 1, "", true));
}, 9, "", true);
spotC_4000 = Fn((V _arrowThis4231, int _argc4216, V D_4222, V cx_4223, V cz_4224, V rf_4225, V[] _rest4217) => {
V a_4226 = default;
V y_4227 = default;
V rx_4228 = default;
V ry_4229 = default;
V rot_4230 = default;
a_4226 = (_argc4216 > 4 ? _rest4217[0] : V.Undef);
y_4227 = (_argc4216 > 5 ? _rest4217[1] : V.Undef);
rx_4228 = (_argc4216 > 6 ? _rest4217[2] : V.Undef);
ry_4229 = (_argc4216 > 7 ? _rest4217[3] : V.Undef);
rot_4230 = (_argc4216 > 8 ? _rest4217[4] : V.Undef);
return Call(spot_46, V.Undef, D_4222, Call(cP_3995, V.Undef, cx_4223, cz_4224, Call(rf_4225, V.Undef, y_4227), a_4226, y_4227), Call(cN_42, V.Undef, a_4226), rx_4228, ry_4229, (rot_4230 is var _t4232 && Truthy(_t4232) ? _t4232 : ((V)(0D))), ((V)(8D)));
}, 9, "", true);
heart_4001 = Fn((V _arrowThis4245, int _argc4233, V D_4239, V cx_4240, V y_4241, V cz_4242, V[] _rest4234) => {
V s_4243 = default;
V a_4244 = default;
s_4243 = (_argc4233 > 4 ? _rest4234[0] : V.Undef);
a_4244 = (_argc4233 > 5 ? _rest4234[1] : V.Undef);
return Invoke(D_4239, "poly", Call(rep_28, V.Undef, ((V)(20D)), Fn((V _arrowThis4253, int _argc4246, V i_4252, V _a4249, V _a4250, V _a4251, V[] _rest4247) => {
double th_4254 = 0;
double hx_4255 = 0;
double hy_4256 = 0;
th_4254 = (((ToNum(i_4252) / 20D) * 2D) * PI_17);
hx_4255 = Pow(FdLibm.Sin(th_4254), 3D);
hy_4256 = (((((13D * FdLibm.Cos(th_4254)) - (5D * FdLibm.Cos((2D * th_4254)))) - (2D * FdLibm.Cos((3D * th_4254)))) - FdLibm.Cos((4D * th_4254))) / 16D);
return Arr(Add(cx_4240, ((V)((((hx_4255 * FdLibm.Cos(ToNum(a_4244))) - (hy_4256 * FdLibm.Sin(ToNum(a_4244)))) * ToNum(s_4243))))), y_4241, Add(cz_4242, ((V)((((hx_4255 * FdLibm.Sin(ToNum(a_4244))) + (hy_4256 * FdLibm.Cos(ToNum(a_4244)))) * ToNum(s_4243))))));
return default;
}, 1, "", true)), Y3_40);
}, 6, "", true);
elS_4002 = Fn((V _arrowThis4268, int _argc4257, V c_4263, V rx_4264, V ry_4265, V rz_4266, V[] _rest4258) => {
V d_4267 = default;
d_4267 = (_argc4257 > 4 ? _rest4258[0] : V.Undef);
d_4267 = Call(nz_38, V.Undef, d_4267);
return Arr(Arr(Add(GetIdx(c_4263, 0D), ((V)((ToNum(GetIdx(d_4267, 0D)) * ToNum(rx_4264))))), Add(GetIdx(c_4263, 1D), ((V)((ToNum(GetIdx(d_4267, 1D)) * ToNum(ry_4265))))), Add(GetIdx(c_4263, 2D), ((V)((ToNum(GetIdx(d_4267, 2D)) * ToNum(rz_4266)))))), Call(nz_38, V.Undef, Arr(((V)((ToNum(GetIdx(d_4267, 0D)) / ToNum(rx_4264)))), ((V)((ToNum(GetIdx(d_4267, 1D)) / ToNum(ry_4265)))), ((V)((ToNum(GetIdx(d_4267, 2D)) / ToNum(rz_4266)))))));
return default;
}, 5, "", true);
flameG_4003 = Fn((V _arrowThis4278, int _argc4269, V c_4275, V P_4276, V id_4277, V _a4274, V[] _rest4270) => {
V q_4279 = default;
V k_4280 = default;
q_4279 = Invoke(c_4275, "p", GetIdx(P_4276, 0D), GetIdx(P_4276, 1D), GetIdx(P_4276, 2D));
k_4280 = Get(c_4275, "k");
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_3991, V.Undef, q_4279)).S(") scale(").V(Call(f1_3980, V.Undef, k_4280)).S(")\"><ellipse cy=\"-1.4\" rx=\"4.4\" ry=\"4.8\" fill=\"url(#").V(id_4277).S(")\">").V(Call(an_3983, V.Undef, ((V)("opacity")), ((V)("0.4;0.8;0.5;0.75;0.4")), ((V)(1.6)))).S("</ellipse><g><animateTransform attributeName=\"transform\" type=\"skewX\" values=\"0;7;-5;4;0\" dur=\"1.5s\" repeatCount=\"indefinite\"/><path d=\"M0 -3.8Q1.7 -1.3 0.5 0.4Q0 0.7 -0.5 0.4Q-1.6 -1 0 -3.8Z\" fill=\"#ffd24a\" stroke=\"#ff8a2a\" stroke-width=\"0.22\"/><path d=\"M0 -1.6Q0.6 -0.6 0.2 0.2Q-0.5 -0.4 0 -1.6Z\" fill=\"#fff6d0\"/></g><ellipse cy=\"0.45\" rx=\"0.35\" ry=\"0.5\" fill=\"#5a8aff\" opacity=\"0.7\"/></g>").End()));
return default;
}, 3, "", true);
Set(N_16, "coupons25", Fn((V _arrowThis4288, int _argc4281, V S_4287, V _a4284, V _a4285, V _a4286, V[] _rest4282) => {
V R_4289 = default;
V CC_4290 = default;
V PCs_4291 = default;
V YW_4292 = default;
double TH_4293 = 0;
V SH_4294 = default;
V T_4295 = default;
R_4289 = Call(R0_30, V.Undef, ((V)("coupons25L")));
CC_4290 = Arr(((V)("#efe6cf")), ((V)("#f6e27a")), ((V)("#f4b8c4")), ((V)("#bfe0b0")), ((V)("#f2ead8")), ((V)("#cfe2f2")));
PCs_4291 = Arr(((V)("#d9483b")), ((V)("#2b6fb8")), ((V)("#e07a1a")), ((V)("#3a8a3a")), ((V)("#7a3a9a")), ((V)("#d9483b")));
YW_4292 = Arr(((V)(0.06)), ((V)((-0.14))), ((V)(0.22)), ((V)((-0.05))), ((V)(0.12)), ((V)((-0.18))));
TH_4293 = 0.42;
SH_4294 = Invoke(CC_4290, "map", Fn((V _arrowThis4304, int _argc4296, V col_4302, V i_4303, V _a4300, V _a4301, V[] _rest4297) => {
return NewObj(7).Put("col", col_4302).Put("cx", ((V)((6D + ((ToNum(Call(R_4289, V.Undef)) - 0.5) * 2.4))))).Put("cz", ((V)(((-1D) + ((ToNum(Call(R_4289, V.Undef)) - 0.5) * 2D))))).Put("yaw", GetK(YW_4292, i_4303)).Put("y", ((V)((ToNum(i_4303) * TH_4293)))).Put("w", ((V)((18D - ((ToNum(i_4303) % 2D) * 1.6))))).Put("d", ((V)((9.6 + ((ToNum(i_4303) % 3D) * 0.6))))).V;
}, 2, "", true));
T_4295 = GetIdx(SH_4294, (ToNum(Get(SH_4294, "length")) - 1D));
return NewObj(6).Put("w", ((V)(40D))).Put("d", ((V)(32D))).Put("small", ((V)(1D))).Put("topH", ((V)(3D))).Put("build", Fn((V _arrowThis4311, int _argc4305, V _a4307, V _a4308, V _a4309, V _a4310, V[] _rest4306) => {
V o_4312 = default;
V on_4313 = default;
V Rr_4314 = default;
V CO_4315 = default;
V TOPC_4316 = default;
V B1_4317 = default;
V B2_4318 = default;
V PEN_4319 = default;
o_4312 = Arr();
on_4313 = Call(glue_31, V.Undef, o_4312);
Rr_4314 = Call(R0_30, V.Undef, ((V)("coupons25")));
CO_4315 = Call(cyl_12, V.Undef, ((V)((-12.5))), ((V)(0D)), ((V)(5D)), ((V)(6.5)), ((V)(0.8)), ((V)("#b98a56")), NewObj(2).Put("n", ((V)(26D))).Put("mat", ((V)("fab"))).V);
Invoke(o_4312, "push", CO_4315);
{
V D1_4320 = default;
V D2_4321 = default;
V RA_4322 = default;
V RB_4323 = default;
V PR_4324 = default;
V disk_4325 = default;
D1_4320 = Call(dec_44, V.Undef, ((V)("#7a5232")), NewObj(1).Put("op", ((V)(0.75))).V);
D2_4321 = Call(dec_44, V.Undef, ((V)("#dcb486")), NewObj(1).Put("op", ((V)(0.65))).V);
RA_4322 = Call(dec_44, V.Undef, ((V)("#5a3018")), NewObj(1).Put("op", ((V)(0.42))).V);
RB_4323 = Call(dec_44, V.Undef, ((V)("#6a3a1a")), NewObj(1).Put("op", ((V)(0.14))).V);
PR_4324 = Call(dec_44, V.Undef, ((V)("#7a2a2a")), NewObj(1).Put("op", ((V)(0.16))).V);
disk_4325 = Fn((V _arrowThis4334, int _argc4326, V u_4332, V v_4333, V _a4330, V _a4331, V[] _rest4327) => {
double a_4335 = 0;
double r_4336 = 0;
a_4335 = ((ToNum(u_4332) * 2D) * PI_17);
r_4336 = (System.Math.Sqrt(ToNum(v_4333)) * 6.1);
return Arr(((V)(((-12.5) + (FdLibm.Cos(a_4335) * r_4336)))), ((V)(0.8)), ((V)((5D + (FdLibm.Sin(a_4335) * r_4336)))));
return default;
}, 2, "", true);
Call(speck_55, V.Undef, D1_4320, ((V)(40D)), disk_4325, Y3_40, ((V)(0.06)), ((V)(0.16)), Rr_4314);
Call(speck_55, V.Undef, D2_4321, ((V)(30D)), disk_4325, Y3_40, ((V)(0.06)), ((V)(0.14)), Rr_4314);
Call(rep_28, V.Undef, ((V)(28D)), Fn((V _arrowThis4344, int _argc4337, V i_4343, V _a4340, V _a4341, V _a4342, V[] _rest4338) => {
double a_4345 = 0;
a_4345 = ((((ToNum(i_4343) / 28D) * 2D) * PI_17) + (ToNum(Call(Rr_4314, V.Undef)) * 0.2));
Call(spot_46, V.Undef, D1_4320, Arr(((V)(((-12.5) + (FdLibm.Cos(a_4345) * 6.5)))), ((V)((0.2 + (ToNum(Call(Rr_4314, V.Undef)) * 0.4)))), ((V)((5D + (FdLibm.Sin(a_4345) * 6.5))))), Call(cN_42, V.Undef, ((V)(a_4345))), ((V)(0.18)), ((V)(0.12)), ((V)(0D)), ((V)(5D)));
return default;
}, 1, "", true));
Invoke(RB_4323, "poly", Call(elP_45, V.Undef, Arr(((V)((-11.5))), ((V)(0.8)), ((V)(4D))), X3_39, Z3_41, ((V)(3.9)), ((V)(3.9)), ((V)(24D))), Y3_40);
Call(ringY_51, V.Undef, RA_4322, ((V)((-11.5))), ((V)(4D)), ((V)(3.7)), ((V)(0.8)), ((V)(0.32)), ((V)(36D)));
Call(ringY_51, V.Undef, RA_4322, ((V)((-11.1))), ((V)(4.4)), ((V)(3.4)), ((V)(0.8)), ((V)(0.12)), ((V)(30D)));
Call(ringY_51, V.Undef, PR_4324, ((V)((-12.5))), ((V)(5D)), ((V)(5.5)), ((V)(0.8)), ((V)(0.22)), ((V)(40D)));
Call(ringY_51, V.Undef, PR_4324, ((V)((-12.5))), ((V)(5D)), ((V)(4.9)), ((V)(0.8)), ((V)(0.1)), ((V)(40D)));
Call(on_4313, V.Undef, CO_4315, Arr(D1_4320, D2_4321, RB_4323, RA_4322, PR_4324));
}
TOPC_4316 = V.Null;
Invoke(SH_4294, "forEach", Fn((V _arrowThis4354, int _argc4346, V s_4352, V i_4353, V _a4350, V _a4351, V[] _rest4347) => {
V L_4355 = default;
V C_4356 = default;
V yt_4357 = default;
double hw_4358 = 0;
double hd_4359 = 0;
V DS_4360 = default;
V PB_4361 = default;
V TX_4362 = default;
V SG_4363 = default;
L_4355 = Call(L__3992, V.Undef, Get(s_4352, "cx"), Get(s_4352, "cz"), Get(s_4352, "yaw"));
C_4356 = Call(box_11, V.Undef, Get(s_4352, "cx"), Get(s_4352, "y"), Get(s_4352, "cz"), Get(s_4352, "w"), ((V)(TH_4293)), Get(s_4352, "d"), Get(s_4352, "col"), NewObj(3).Put("r", ((V)(0.15))).Put("yaw", Get(s_4352, "yaw")).Put("mat", ((V)("fab"))).V);
Invoke(o_4312, "push", C_4356);
TOPC_4316 = C_4356;
yt_4357 = Add(Get(s_4352, "y"), ((V)(TH_4293)));
hw_4358 = ((ToNum(Get(s_4352, "w")) / 2D) - 0.8);
hd_4359 = ((ToNum(Get(s_4352, "d")) / 2D) - 0.8);
DS_4360 = Call(dec_44, V.Undef, ((V)("#9a9080")), NewObj(1).Put("op", ((V)(0.55))).V);
PB_4361 = Call(dec_44, V.Undef, GetK(PCs_4291, i_4353));
TX_4362 = Call(dec_44, V.Undef, ((V)("#aaa498")), NewObj(1).Put("op", ((V)(0.6))).V);
SG_4363 = Call(dec_44, V.Undef, Call(shade_14, V.Undef, Get(s_4352, "col"), ((V)(0.86))));
Call(dash_3996, V.Undef, DS_4360, L_4355, ((V)((-hw_4358))), ((V)((-hd_4359))), ((V)(hw_4358)), ((V)(hd_4359)), yt_4357, ((V)(0.06)), ((V)(0.8)));
Invoke(PB_4361, "poly", Call(rq_3994, V.Undef, L_4355, ((V)(((-hw_4358) + 0.5))), ((V)(((-hd_4359) + 0.5))), ((V)(((-hw_4358) + 6.2))), ((V)((hd_4359 - 0.5))), yt_4357), Y3_40);
Invoke((SEqN(i_4353, (ToNum(Get(SH_4294, "length")) - 1D)) ? Arr(((V)((-0.3))), ((V)(1.1))) : Arr(((V)((-2.6))), ((V)((-1D))), ((V)(0.6)), ((V)(2.2)))), "forEach", Fn((V _arrowThis4372, int _argc4364, V v_4370, V k_4371, V _a4368, V _a4369, V[] _rest4365) => {
return Call(seg_56, V.Undef, TX_4362, Call(L_4355, V.Undef, ((V)(((-hw_4358) + 7.2))), yt_4357, v_4370), Call(L_4355, V.Undef, ((V)(((hw_4358 - 1D) - ((ToNum(k_4371) % 2D) * 3D)))), yt_4357, v_4370), Y3_40, ((V)(0.16)));
}, 2, "", true));
Invoke(Arr(Arr(((V)(1D)), ((V)(0D))), Arr(((V)((-1D))), ((V)(0D))), Arr(((V)(0D)), ((V)(1D))), Arr(((V)(0D)), ((V)((-1D))))), "forEach", Fn((V _arrowThis4384, int _argc4373, V _a4375, V _a4376, V _a4377, V _a4378, V[] _rest4374) => {
V n_4385 = default;
double u_4386 = 0;
double v_4387 = 0;
V e_4388 = default;
V a_4381 = default;
V b_4383 = default;
{ V _t4379 = ListOf(_a4375);
{ V _t4380 = GetIdx(_t4379, 0D);
a_4381 = _t4380; }
{ V _t4382 = GetIdx(_t4379, 1D);
b_4383 = _t4382; }
}
n_4385 = Call(Call(NL_3993, V.Undef, Get(s_4352, "yaw")), V.Undef, a_4381, b_4383);
u_4386 = ((ToNum(a_4381) * ToNum(Get(s_4352, "w"))) / 2D);
v_4387 = ((ToNum(b_4383) * ToNum(Get(s_4352, "d"))) / 2D);
e_4388 = (Truthy(a_4381) ? Arr(((V)(0D)), ((V)(((ToNum(Get(s_4352, "d")) / 2D) - 0.3)))) : Arr(((V)(((ToNum(Get(s_4352, "w")) / 2D) - 0.3))), ((V)(0D))));
Invoke(SG_4363, "line", Arr(Call(L_4355, V.Undef, ((V)((u_4386 - ToNum(GetIdx(e_4388, 0D))))), Add(Get(s_4352, "y"), ((V)((TH_4293 * 0.5)))), ((V)((v_4387 - ToNum(GetIdx(e_4388, 1D)))))), Call(L_4355, V.Undef, Add(((V)(u_4386)), GetIdx(e_4388, 0D)), Add(Get(s_4352, "y"), ((V)((TH_4293 * 0.5)))), Add(((V)(v_4387)), GetIdx(e_4388, 1D)))), n_4385, ((V)(0.12)));
return default;
}, 1, "", true));
Call(on_4313, V.Undef, C_4356, Arr(SG_4363, DS_4360, PB_4361, TX_4362));
return default;
}, 2, "", true));
{
V L_4389 = default;
V yt_4390 = default;
double hd_4391 = 0;
double u_4392 = 0;
L_4389 = Call(L__3992, V.Undef, Get(T_4295, "cx"), Get(T_4295, "cz"), Get(T_4295, "yaw"));
yt_4390 = Add(Add(Get(T_4295, "y"), ((V)(TH_4293))), ((V)(0.14)));
hd_4391 = (ToNum(Get(T_4295, "d")) / 2D);
u_4392 = 2.4;
Call(on_4313, V.Undef, TOPC_4316, Call(pipe_23, V.Undef, Invoke(Arr(Arr(((V)(u_4392)), ((V)((hd_4391 - 3.4)))), Arr(((V)(u_4392)), ((V)((hd_4391 + 0.8)))), Arr(((V)((u_4392 + 1.3))), ((V)((hd_4391 + 0.8)))), Arr(((V)((u_4392 + 1.3))), ((V)((hd_4391 - 2.6)))), Arr(((V)((u_4392 + 0.4))), ((V)((hd_4391 - 2.6)))), Arr(((V)((u_4392 + 0.4))), ((V)((hd_4391 + 0.2))))), "map", Fn((V _arrowThis4404, int _argc4393, V _a4395, V _a4396, V _a4397, V _a4398, V[] _rest4394) => {
V a_4401 = default;
V b_4403 = default;
{ V _t4399 = ListOf(_a4395);
{ V _t4400 = GetIdx(_t4399, 0D);
a_4401 = _t4400; }
{ V _t4402 = GetIdx(_t4399, 1D);
b_4403 = _t4402; }
}
return Call(L_4389, V.Undef, a_4401, yt_4390, b_4403);
}, 1, "", true)), ((V)(0.13)), ((V)("#c9ced3")), Call(M__24, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)));
}
Invoke(Arr(((V)((-13.6))), ((V)((-10.6)))), "forEach", Fn((V _arrowThis4412, int _argc4405, V z_4411, V _a4408, V _a4409, V _a4410, V[] _rest4406) => {
return Invoke(o_4312, "push", Call(arcW_3979, V.Undef, ((V)((-15D))), ((V)(0D)), z_4411, ((V)(1.7)), ((V)(1.15)), ((V)(0.55)), ((V)(0.6)), ((V)(0D)), ((V)((2D * PI_17))), ((V)("#e8742a")), Call(PL_27, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
}, 1, "", true));
B1_4317 = Call(box_11, V.Undef, ((V)((-8.2))), ((V)(0D)), ((V)((-11.9))), ((V)(10.4)), ((V)(0.28)), ((V)(1.1)), ((V)("#c9ced3")), Call(M__24, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("yaw", ((V)(0.08))).V));
B2_4318 = Call(box_11, V.Undef, ((V)((-8.2))), ((V)(0.28)), ((V)((-12.3))), ((V)(10.4)), ((V)(0.28)), ((V)(1.1)), ((V)("#d5dde2")), Call(M__24, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("yaw", ((V)((-0.08)))).V));
Invoke(o_4312, "push", B1_4317, B2_4318);
{
V H1_4413 = default;
H1_4413 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.7))).V);
Call(seg_56, V.Undef, H1_4413, Arr(((V)((-12.4))), ((V)(0.57)), ((V)((-12.5)))), Arr(((V)((-3.6))), ((V)(0.57)), ((V)((-11.8)))), Y3_40, ((V)(0.14)));
Call(on_4313, V.Undef, B2_4318, Arr(H1_4413, Call(cyl_12, V.Undef, ((V)((-12.3))), ((V)(0.56)), ((V)((-12.1))), ((V)(0.5)), ((V)(0.14)), ((V)("#8a9096")), Call(M__24, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))));
}
PEN_4319 = Call(rod_22, V.Undef, Arr(((V)((-3.5))), ((V)(0.55)), ((V)(11.6))), Arr(((V)(11.5)), ((V)(0.55)), ((V)(12.8))), ((V)(0.55)), ((V)("#2b5fb8")), Call(PL_27, V.Undef, NewObj(1).Put("n", ((V)(10D))).V));
Invoke(o_4312, "push", PEN_4319);
{
V H2_4414 = default;
H2_4414 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.45))).V);
Call(seg_56, V.Undef, H2_4414, Arr(((V)((-3.2))), ((V)(1.05)), ((V)(11.5))), Arr(((V)(11.2)), ((V)(1.05)), ((V)(12.7))), Y3_40, ((V)(0.16)));
Call(on_4313, V.Undef, PEN_4319, Arr(H2_4414, Call(rod_22, V.Undef, Arr(((V)(11.5)), ((V)(0.55)), ((V)(12.8))), Arr(((V)(14.2)), ((V)(0.55)), ((V)(13D))), ((V)(0.62)), ((V)("#1d2a44")), Call(PL_27, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(rod_22, V.Undef, Arr(((V)((-3.5))), ((V)(0.55)), ((V)(11.6))), Arr(((V)((-4.8))), ((V)(0.55)), ((V)(11.5))), ((V)(0.3)), ((V)("#c9ced3")), Call(M__24, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(box_11, V.Undef, ((V)(12.8)), ((V)(1.15)), ((V)(13.45)), ((V)(2.6)), ((V)(0.2)), ((V)(0.32)), ((V)("#c9ced3")), Call(M__24, V.Undef, NewObj(2).Put("r", ((V)(0.1))).Put("yaw", ((V)(0.07))).V))));
}
return o_4312;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis4422, int _argc4415, V c_4421, V _a4418, V _a4419, V _a4420, V[] _rest4416) => {
V M_4423 = default;
double hw_4424 = 0;
double px_4425 = 0;
M_4423 = Call(frame_3982, V.Undef, Get(c_4421, "p"), Arr(Get(T_4295, "cx"), Add(Add(Get(T_4295, "y"), ((V)(TH_4293))), ((V)(0.07))), Get(T_4295, "cz")), Arr(((V)(FdLibm.Cos(ToNum(Get(T_4295, "yaw"))))), ((V)(0D)), ((V)(FdLibm.Sin(ToNum(Get(T_4295, "yaw")))))), Arr(((V)((-FdLibm.Sin(ToNum(Get(T_4295, "yaw")))))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(Get(T_4295, "yaw")))))));
hw_4424 = ((ToNum(Get(T_4295, "w")) / 2D) - 0.8);
px_4425 = ((-hw_4424) + 3.35);
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(M_4423).S("\"><text x=\"").V(Call(f1_3980, V.Undef, ((V)(px_4425)))).S("\" y=\"0.2\" text-anchor=\"middle\" ").V(FONT_3986).S(" font-size=\"2.5\" fill=\"#fff\">50\u00a2</text><text x=\"").V(Call(f1_3980, V.Undef, ((V)(px_4425)))).S("\" y=\"2.3\" text-anchor=\"middle\" ").V(FONT_3986).S(" font-size=\"1.25\" fill=\"#fff\">OFF</text><text x=\"").V(Call(f1_3980, V.Undef, ((V)(((-hw_4424) + 7.2))))).S("\" y=\"-1.9\" ").V(FONT_3986).S(" font-size=\"1.25\" fill=\"#3a352e\">Squish Mart</text><text x=\"").V(Call(f1_3980, V.Undef, ((V)(((-hw_4424) + 7.2))))).S("\" y=\"3.3\" font-family=\"monospace\" font-size=\"0.85\" fill=\"#b0302a\">EXP 03/09/98</text><g transform=\"translate(").V(Call(f1_3980, V.Undef, ((V)((hw_4424 - 2.8))))).S(" 1.9) rotate(-16)\" opacity=\"0.7\"><rect x=\"-3\" y=\"-0.95\" width=\"6\" height=\"1.9\" rx=\"0.35\" fill=\"none\" stroke=\"#c8303a\" stroke-width=\"0.22\"/><text y=\"0.45\" text-anchor=\"middle\" ").V(FONT_3986).S(" font-size=\"1.15\" fill=\"#c8303a\" letter-spacing=\"0.15\">EXPIRED</text></g></g>").End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_16, "candle25", Fn((V _arrowThis4433, int _argc4426, V S_4432, V _a4429, V _a4430, V _a4431, V[] _rest4427) => {
double JX_4434 = 0;
double JR_4435 = 0;
double JH_4436 = 0;
double DX_4437 = 0;
double DZ_4438 = 0;
V rJ_4439 = default;
JX_4434 = (-8D);
JR_4435 = 6.5;
JH_4436 = 11D;
DX_4437 = 11D;
DZ_4438 = 0D;
rJ_4439 = Fn((V _arrowThis4447, int _argc4440, V y_4446, V _a4443, V _a4444, V _a4445, V[] _rest4441) => {
return ((V)((JR_4435 * (LtN(y_4446, 0.8) ? (0.95 + ((0.05 * ToNum(y_4446)) / 0.8)) : (GtN(y_4446, (JH_4436 - 0.8)) ? (1D - ((0.07 * ((ToNum(y_4446) - JH_4436) + 0.8)) / 0.8)) : 1D)))));
}, 1, "", true);
return NewObj(6).Put("w", ((V)(44D))).Put("d", ((V)(40D))).Put("small", ((V)(1D))).Put("topH", ((V)(12D))).Put("build", Fn((V _arrowThis4454, int _argc4448, V _a4450, V _a4451, V _a4452, V _a4453, V[] _rest4449) => {
V o_4455 = default;
V on_4456 = default;
V R_4457 = default;
double fr_4458 = 0;
V J_4459 = default;
V LD_4460 = default;
V DI_4461 = default;
V MB_4462 = default;
V MT_4463 = default;
o_4455 = Arr();
on_4456 = Call(glue_31, V.Undef, o_4455);
R_4457 = Call(R0_30, V.Undef, ((V)("candle25")));
fr_4458 = (PI_17 / 2D);
J_4459 = Call(cyl_12, V.Undef, ((V)(JX_4434)), ((V)(0D)), ((V)(0D)), ((V)(JR_4435)), ((V)(JH_4436)), ((V)("#b8701f")), NewObj(3).Put("n", ((V)(26D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.95))), Arr(((V)(0.8)), ((V)(0D)), ((V)(1D))), Arr(((V)((JH_4436 - 0.8))), ((V)(0D)), ((V)(1D))), Arr(((V)(JH_4436)), ((V)(0D)), ((V)(0.93))))).V);
Invoke(o_4455, "push", J_4459);
{
V LB_4464 = default;
V LK_4465 = default;
V LV_4466 = default;
V LG_4467 = default;
V HL_4468 = default;
V HL2_4469 = default;
V WX_4470 = default;
V WS_4471 = default;
V RM_4472 = default;
V MP_4473 = default;
LB_4464 = Call(dec_44, V.Undef, ((V)("#dcc092")));
LK_4465 = Call(dec_44, V.Undef, ((V)("#7a6248")), NewObj(1).Put("op", ((V)(0.55))).V);
LV_4466 = Call(dec_44, V.Undef, ((V)("#8a6ab8")));
LG_4467 = Call(dec_44, V.Undef, ((V)("#6a8a4a")));
HL_4468 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.55))).V);
HL2_4469 = Call(dec_44, V.Undef, ((V)("#ffe0a8")), NewObj(1).Put("op", ((V)(0.35))).V);
WX_4470 = Call(dec_44, V.Undef, ((V)("#f3e7cf")));
WS_4471 = Call(dec_44, V.Undef, ((V)("#b89a6a")), NewObj(1).Put("op", ((V)(0.55))).V);
RM_4472 = Call(dec_44, V.Undef, ((V)("#e8b060")), NewObj(1).Put("op", ((V)(0.7))).V);
MP_4473 = Call(dec_44, V.Undef, ((V)("#e6d2aa")), NewObj(1).Put("op", ((V)(0.85))).V);
Call(band3_3999, V.Undef, LB_4464, ((V)(JX_4434)), ((V)(0D)), rJ_4439, ((V)(3D)), ((V)(8.4)), ((V)((fr_4458 - 2.1))), ((V)((fr_4458 + 2.1))), ((V)(20D)));
Invoke(Arr(((V)(3.4)), ((V)(8D))), "forEach", Fn((V _arrowThis4481, int _argc4474, V y_4480, V _a4477, V _a4478, V _a4479, V[] _rest4475) => {
return Call(ringL_3997, V.Undef, LK_4465, ((V)(JX_4434)), ((V)(0D)), rJ_4439, y_4480, ((V)(0.08)), ((V)((fr_4458 - 2.05))), ((V)((fr_4458 + 2.05))), ((V)(20D)));
}, 1, "", true));
Invoke(Arr(Arr(((V)(6.8)), ((V)(0.45)), ((V)(0.22))), Arr(((V)(5.6)), ((V)(0.3)), ((V)(0.1)))), "forEach", Fn((V _arrowThis4495, int _argc4482, V _a4484, V _a4485, V _a4486, V _a4487, V[] _rest4483) => {
V y_4490 = default;
V ha_4492 = default;
V w_4494 = default;
{ V _t4488 = ListOf(_a4484);
{ V _t4489 = GetIdx(_t4488, 0D);
y_4490 = _t4489; }
{ V _t4491 = GetIdx(_t4488, 1D);
ha_4492 = _t4491; }
{ V _t4493 = GetIdx(_t4488, 2D);
w_4494 = _t4493; }
}
return Call(ringL_3997, V.Undef, LK_4465, ((V)(JX_4434)), ((V)(0D)), rJ_4439, y_4490, w_4494, ((V)((fr_4458 - ToNum(ha_4492)))), Add(((V)(fr_4458)), ha_4492), ((V)(6D)));
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis4503, int _argc4496, V i_4502, V _a4499, V _a4500, V _a4501, V[] _rest4497) => {
return Call(spotC_4000, V.Undef, LV_4466, ((V)(JX_4434)), ((V)(0D)), rJ_4439, ((V)(((fr_4458 + 0.95) + ((ToNum(i_4502) % 2D) * 0.05)))), ((V)((4.4 + (ToNum(i_4502) * 0.6)))), ((V)(0.22)), ((V)(0.3)));
}, 1, "", true));
Call(vL_3998, V.Undef, LG_4467, ((V)(JX_4434)), ((V)(0D)), rJ_4439, ((V)((fr_4458 + 0.97))), ((V)(3.8)), ((V)(7.4)), ((V)(0.12)));
Call(vL_3998, V.Undef, HL_4468, ((V)(JX_4434)), ((V)(0D)), rJ_4439, ((V)((fr_4458 + 0.75))), ((V)(1.2)), ((V)((JH_4436 - 1.2))), ((V)(0.5)));
Call(vL_3998, V.Undef, HL2_4469, ((V)(JX_4434)), ((V)(0D)), rJ_4439, ((V)((fr_4458 + 1.05))), ((V)(1.5)), ((V)((JH_4436 - 1.5))), ((V)(0.22)));
Call(vL_3998, V.Undef, HL_4468, ((V)(JX_4434)), ((V)(0D)), rJ_4439, ((V)((fr_4458 - 1.25))), ((V)(2D)), ((V)((JH_4436 - 2D))), ((V)(0.18)));
Invoke(RM_4472, "line", Call(wv_43, V.Undef, ((V)(30D)), Fn((V _arrowThis4511, int _argc4504, V t_4510, V _a4507, V _a4508, V _a4509, V[] _rest4505) => {
return Call(cP_3995, V.Undef, ((V)(JX_4434)), ((V)(0D)), ((V)(((JR_4435 * 0.93) - 0.3))), ((V)(((ToNum(t_4510) * 2D) * PI_17))), ((V)(JH_4436)));
}, 1, "", true)), Y3_40, ((V)(0.5)));
Invoke(WX_4470, "poly", Call(elP_45, V.Undef, Arr(((V)(JX_4434)), ((V)(JH_4436)), ((V)(0D))), X3_39, Z3_41, ((V)(((JR_4435 * 0.93) - 0.6))), ((V)(((JR_4435 * 0.93) - 0.6))), ((V)(26D))), Y3_40);
Invoke(WS_4471, "poly", Invoke(Call(wv_43, V.Undef, ((V)(14D)), Fn((V _arrowThis4528, int _argc4521, V t_4527, V _a4524, V _a4525, V _a4526, V[] _rest4522) => {
return Call(cP_3995, V.Undef, ((V)(JX_4434)), ((V)(0D)), ((V)(((JR_4435 * 0.93) - 0.6))), ((V)((PI_17 + (ToNum(t_4527) * PI_17)))), ((V)(JH_4436)));
}, 1, "", true)), "concat", Call(wv_43, V.Undef, ((V)(14D)), Fn((V _arrowThis4519, int _argc4512, V t_4518, V _a4515, V _a4516, V _a4517, V[] _rest4513) => {
double a_4520 = 0;
a_4520 = ((2D * PI_17) - (ToNum(t_4518) * PI_17));
return Arr(((V)((JX_4434 + (FdLibm.Cos(a_4520) * ((JR_4435 * 0.93) - 0.6))))), ((V)(JH_4436)), ((V)(((FdLibm.Sin(a_4520) * ((JR_4435 * 0.93) - 0.6)) * 0.55))));
return default;
}, 1, "", true))), Y3_40);
Call(spot_46, V.Undef, MP_4473, Arr(((V)(JX_4434)), ((V)(JH_4436)), ((V)(0.2))), Y3_40, ((V)(3.1)), ((V)(3.1)), ((V)(0D)), ((V)(18D)));
Call(on_4456, V.Undef, J_4459, Arr(LB_4464, LK_4465, LV_4466, LG_4467, HL_4468, HL2_4469, RM_4472, WX_4470, WS_4471, MP_4473, Call(rod_22, V.Undef, Arr(((V)(JX_4434)), ((V)(JH_4436)), ((V)(0D))), Arr(((V)((JX_4434 + 0.15))), ((V)((JH_4436 + 1.5))), ((V)(0D))), ((V)(0.18)), ((V)("#2a2020")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_13, V.Undef, ((V)((JX_4434 + 0.25))), ((V)((JH_4436 + 1.6))), ((V)(0D)), ((V)(0.28)), ((V)("#1a1414")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V)));
}
LD_4460 = Call(cyl_12, V.Undef, ((V)((JX_4434 - 2D))), ((V)(0D)), ((V)(13.5)), ((V)(6.2)), ((V)(1.3)), ((V)("#c8925a")), Call(W__25, V.Undef, NewObj(1).Put("n", ((V)(26D))).V));
Invoke(o_4455, "push", LD_4460);
{
V G1_4529 = default;
V G2_4530 = default;
V BN_4531 = default;
V SL_4532 = default;
G1_4529 = Call(dec_44, V.Undef, ((V)("#9a6a3a")), NewObj(1).Put("op", ((V)(0.5))).V);
G2_4530 = Call(dec_44, V.Undef, ((V)("#e0b47e")), NewObj(1).Put("op", ((V)(0.5))).V);
BN_4531 = Call(dec_44, V.Undef, ((V)("#5a3418")), NewObj(1).Put("op", ((V)(0.6))).V);
SL_4532 = Call(dec_44, V.Undef, ((V)("#e8e2d6")));
Invoke(Arr(((V)(1.4)), ((V)(2.6)), ((V)(3.6)), ((V)(4.6)), ((V)(5.5))), "forEach", Fn((V _arrowThis4541, int _argc4533, V r_4539, V i_4540, V _a4537, V _a4538, V[] _rest4534) => {
return Invoke((NumTruthy((ToNum(i_4540) % 2D)) ? G2_4530 : G1_4529), "line", Call(wv_43, V.Undef, ((V)(30D)), Fn((V _arrowThis4549, int _argc4542, V t_4548, V _a4545, V _a4546, V _a4547, V[] _rest4543) => {
double a_4550 = 0;
a_4550 = ((ToNum(t_4548) * 2D) * PI_17);
return Arr(((V)(((JX_4434 - 2D) + ((FdLibm.Cos(a_4550) * ToNum(r_4539)) * (1D + (0.06 * FdLibm.Sin(ToNum(Add(((V)((a_4550 * 3D))), i_4540))))))))), ((V)(1.3)), ((V)((13.5 + ((FdLibm.Sin(a_4550) * ToNum(r_4539)) * 0.92)))));
return default;
}, 1, "", true)), Y3_40, ((V)(0.18)));
}, 2, "", true));
Call(ringY_51, V.Undef, BN_4531, ((V)((JX_4434 - 2D))), ((V)(13.5)), ((V)(2.2)), ((V)(1.3)), ((V)(0.14)), ((V)(24D)));
Call(seg_56, V.Undef, BN_4531, Arr(((V)((JX_4434 - 3.2))), ((V)(1.3)), ((V)(13.5))), Arr(((V)((JX_4434 - 0.8))), ((V)(1.3)), ((V)(13.5))), Y3_40, ((V)(0.25)));
Call(ringC_52, V.Undef, SL_4532, ((V)((JX_4434 - 2D))), ((V)(13.5)), ((V)(6.2)), ((V)(0.25)), ((V)(0.3)), ((V)(40D)));
Call(on_4456, V.Undef, LD_4460, Arr(G1_4529, G2_4530, BN_4531, SL_4532));
}
DI_4461 = Call(cyl_12, V.Undef, ((V)(DX_4437)), ((V)(0D)), ((V)(DZ_4438)), ((V)(9D)), ((V)(2.4)), ((V)("#e4dccd")), NewObj(3).Put("n", ((V)(30D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.72))), Arr(((V)(0.5)), ((V)(0D)), ((V)(0.84))), Arr(((V)(2.4)), ((V)(0D)), ((V)(1D))))).V);
Invoke(o_4455, "push", DI_4461);
{
V GZ_4551 = default;
V SPk_4552 = default;
V GD_4553 = default;
V BL_4554 = default;
V FT_4555 = default;
V rD_4556 = default;
GZ_4551 = Call(dec_44, V.Undef, ((V)("#f2ece2")));
SPk_4552 = Call(dec_44, V.Undef, ((V)("#8a6a4a")), NewObj(1).Put("op", ((V)(0.45))).V);
GD_4553 = Call(dec_44, V.Undef, GOLD_3990);
BL_4554 = Call(dec_44, V.Undef, ((V)("#6a98c0")), NewObj(1).Put("op", ((V)(0.6))).V);
FT_4555 = Call(dec_44, V.Undef, ((V)("#b8ab98")));
rD_4556 = Fn((V _arrowThis4564, int _argc4557, V y_4563, V _a4560, V _a4561, V _a4562, V[] _rest4558) => {
return ((V)((9D * (LtN(y_4563, 0.5) ? (0.72 + (0.24 * ToNum(y_4563))) : (0.84 + ((0.16 * (ToNum(y_4563) - 0.5)) / 1.9))))));
}, 1, "", true);
Invoke(GZ_4551, "poly", Call(elP_45, V.Undef, Arr(((V)(DX_4437)), ((V)(2.4)), ((V)(DZ_4438))), X3_39, Z3_41, ((V)(7.8)), ((V)(7.8)), ((V)(28D))), Y3_40);
Call(speck_55, V.Undef, SPk_4552, ((V)(22D)), Fn((V _arrowThis4573, int _argc4565, V u_4571, V v_4572, V _a4569, V _a4570, V[] _rest4566) => {
double a_4574 = 0;
double r_4575 = 0;
a_4574 = ((ToNum(u_4571) * 2D) * PI_17);
r_4575 = (System.Math.Sqrt(ToNum(v_4572)) * 8.6);
return Arr(((V)((DX_4437 + (FdLibm.Cos(a_4574) * r_4575)))), ((V)(2.4)), ((V)((DZ_4438 + (FdLibm.Sin(a_4574) * r_4575)))));
return default;
}, 2, "", true), Y3_40, ((V)(0.06)), ((V)(0.16)), R_4457);
Invoke(BL_4554, "line", Call(wv_43, V.Undef, ((V)(24D)), Fn((V _arrowThis4583, int _argc4576, V t_4582, V _a4579, V _a4580, V _a4581, V[] _rest4577) => {
double a_4584 = 0;
a_4584 = ((ToNum(t_4582) * 2D) * PI_17);
return Arr(((V)((DX_4437 + (FdLibm.Cos(a_4584) * (5.6 + (0.5 * FdLibm.Sin((a_4584 * 5D)))))))), ((V)(2.4)), ((V)((DZ_4438 + (FdLibm.Sin(a_4584) * (5.6 + (0.5 * FdLibm.Sin((a_4584 * 5D)))))))));
return default;
}, 1, "", true)), Y3_40, ((V)(0.3)));
Call(ringY_51, V.Undef, GD_4553, ((V)(DX_4437)), ((V)(DZ_4438)), ((V)(8.85)), ((V)(2.4)), ((V)(0.4)), ((V)(44D)));
Call(ringL_3997, V.Undef, GD_4553, ((V)(DX_4437)), ((V)(DZ_4438)), rD_4556, ((V)(2.2)), ((V)(0.2)), ((V)(0D)), ((V)((2D * PI_17))), ((V)(44D)));
Call(ringL_3997, V.Undef, FT_4555, ((V)(DX_4437)), ((V)(DZ_4438)), rD_4556, ((V)(0.15)), ((V)(0.3)), ((V)(0D)), ((V)((2D * PI_17))), ((V)(40D)));
Call(rep_28, V.Undef, ((V)(18D)), Fn((V _arrowThis4591, int _argc4585, V _a4587, V _a4588, V _a4589, V _a4590, V[] _rest4586) => {
return Call(spotC_4000, V.Undef, SPk_4552, ((V)(DX_4437)), ((V)(DZ_4438)), rD_4556, ((V)(((ToNum(Call(R_4457, V.Undef)) * 2D) * PI_17))), ((V)((0.6 + (ToNum(Call(R_4457, V.Undef)) * 1.4)))), ((V)(0.08)), ((V)(0.08)));
}, 0, "", true));
Call(on_4456, V.Undef, DI_4461, Arr(GZ_4551, BL_4554, SPk_4552, GD_4553, FT_4555, Call(arcW_3979, V.Undef, ((V)((DX_4437 - 2.6))), ((V)(2.4)), ((V)((DZ_4438 + 1.6))), ((V)(1.5)), ((V)(1.5)), ((V)(0.4)), ((V)(0.5)), ((V)(0D)), ((V)((2D * PI_17))), GOLD_3990, Call(M__24, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V)), Call(ball_13, V.Undef, ((V)((DX_4437 - 2.6))), ((V)(3.2)), ((V)((DZ_4438 + 3.2))), ((V)(0.55)), ((V)("#7fd0ff")), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V), Call(ball_13, V.Undef, ((V)((DX_4437 + 2.6))), ((V)(3.05)), ((V)((DZ_4438 - 2D))), ((V)(0.65)), ((V)("#fbf6ee")), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V), Call(ball_13, V.Undef, ((V)((DX_4437 + 3.8))), ((V)(3.05)), ((V)((DZ_4438 - 0.8))), ((V)(0.65)), ((V)("#fbf6ee")), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V), Call(arcW_3979, V.Undef, ((V)((DX_4437 + 1.6))), ((V)(2.4)), ((V)((DZ_4438 + 4.6))), ((V)(1.9)), ((V)(1.6)), ((V)(0.7)), ((V)(0.8)), ((V)(0D)), ((V)((2D * PI_17))), ((V)("#e86f8a")), Call(F__26, V.Undef, NewObj(1).Put("n", ((V)(16D))).V))));
}
MB_4462 = Call(box_11, V.Undef, ((V)(2D)), ((V)(0D)), ((V)(15D)), ((V)(7.4)), ((V)(2D)), ((V)(4.6)), ((V)("#f2ead8")), NewObj(2).Put("r", ((V)(0.2))).Put("yaw", ((V)(0.25))).V);
Invoke(o_4455, "push", MB_4462);
{
V L_4592 = default;
V N2_4593 = default;
V RD2_4594 = default;
V YL_4595 = default;
V BK_4596 = default;
V ST_4597 = default;
L_4592 = Call(L__3992, V.Undef, ((V)(2D)), ((V)(15D)), ((V)(0.25)));
N2_4593 = Call(NL_3993, V.Undef, ((V)(0.25)));
RD2_4594 = Call(dec_44, V.Undef, ((V)("#c8303a")));
YL_4595 = Call(dec_44, V.Undef, ((V)("#f2c230")));
BK_4596 = Call(dec_44, V.Undef, ((V)("#2a2420")), NewObj(1).Put("op", ((V)(0.9))).V);
ST_4597 = Call(dec_44, V.Undef, ((V)("#6a4a3a")), NewObj(1).Put("op", ((V)(0.85))).V);
Invoke(RD2_4594, "poly", Call(rq_3994, V.Undef, L_4592, ((V)((-3.2))), ((V)((-1.8))), ((V)(3.2)), ((V)(1.8)), ((V)(2D))), Y3_40);
Invoke(YL_4595, "poly", Arr(Call(L_4592, V.Undef, ((V)((-1.6))), ((V)(2D)), ((V)((-0.9)))), Call(L_4592, V.Undef, ((V)((-0.6))), ((V)(2D)), ((V)(0.2))), Call(L_4592, V.Undef, ((V)((-1.2))), ((V)(2D)), ((V)(1.1))), Call(L_4592, V.Undef, ((V)((-2D))), ((V)(2D)), ((V)(0.2)))), Y3_40);
Invoke(Arr(((V)((-0.7))), ((V)(0.4))), "forEach", Fn((V _arrowThis4606, int _argc4598, V v_4604, V k_4605, V _a4602, V _a4603, V[] _rest4599) => {
return Call(seg_56, V.Undef, BK_4596, Call(L_4592, V.Undef, ((V)(0.2)), ((V)(2D)), v_4604), Call(L_4592, V.Undef, ((V)((2.6 - ToNum(k_4605)))), ((V)(2D)), v_4604), Y3_40, ((V)(0.3)));
}, 2, "", true));
Invoke(Arr(((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis4614, int _argc4607, V sg_4613, V _a4610, V _a4611, V _a4612, V[] _rest4608) => {
return Invoke(ST_4597, "poly", Arr(Call(L_4592, V.Undef, ((V)((-3.4))), ((V)(0.35)), ((V)((ToNum(sg_4613) * 2.3)))), Call(L_4592, V.Undef, ((V)(3.4)), ((V)(0.35)), ((V)((ToNum(sg_4613) * 2.3)))), Call(L_4592, V.Undef, ((V)(3.4)), ((V)(1.65)), ((V)((ToNum(sg_4613) * 2.3)))), Call(L_4592, V.Undef, ((V)((-3.4))), ((V)(1.65)), ((V)((ToNum(sg_4613) * 2.3))))), Call(N2_4593, V.Undef, ((V)(0D)), sg_4613));
}, 1, "", true));
Call(on_4456, V.Undef, MB_4462, Arr(RD2_4594, YL_4595, BK_4596, ST_4597));
}
MT_4463 = Call(rod_22, V.Undef, Arr(((V)(7D)), ((V)(0.24)), ((V)(17.8))), Arr(((V)(11.6)), ((V)(0.24)), ((V)(18.6))), ((V)(0.22)), ((V)("#e8d2a0")), Call(W__25, V.Undef, NewObj(1).Put("n", ((V)(5D))).V));
Invoke(o_4455, "push", MT_4463);
Call(on_4456, V.Undef, MT_4463, Arr(Call(rod_22, V.Undef, Arr(((V)(7D)), ((V)(0.24)), ((V)(17.8))), Arr(((V)(8.2)), ((V)(0.24)), ((V)(18D))), ((V)(0.24)), ((V)("#2a1c14")), NewObj(1).Put("n", ((V)(5D))).V), Call(ball_13, V.Undef, ((V)(6.8)), ((V)(0.3)), ((V)(17.76)), ((V)(0.42)), ((V)("#1a1412")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V)));
return o_4455;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis4622, int _argc4615, V c_4621, V _a4618, V _a4619, V _a4620, V[] _rest4616) => {
return NewObj(3).Put("defs", Add(Call(RG_3987, V.Undef, ((V)("q25cf")), ((V)("#fff3b0")), ((V)("#ffb347")), ((V)(0.8))), Call(RG_3987, V.Undef, ((V)("q25cg")), ((V)("#ffd9a0")), ((V)("#ffb347")), ((V)(0.35))))).Put("back", Call(fxEll_3985, V.Undef, c_4621, ((V)(JX_4434)), ((V)(0.1)), ((V)(0D)), ((V)(13D)), ((V)("url(#q25cg)")), Call(an_3983, V.Undef, ((V)("opacity")), ((V)("0.5;0.8;0.55;0.8;0.5")), ((V)(1.6))))).Put("front", Call(flameG_4003, V.Undef, c_4621, Arr(((V)((JX_4434 + 0.25))), ((V)((JH_4436 + 1.85))), ((V)(0D))), ((V)("q25cf")))).V;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_16, "books25", Fn((V _arrowThis4630, int _argc4623, V S_4629, V _a4626, V _a4627, V _a4628, V[] _rest4624) => {
V BK_4631 = default;
double TY_4632 = 0;
double mx_4633 = 0;
double mz_4634 = 0;
BK_4631 = Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(36D)), ((V)(5.2)), ((V)(30D)), ((V)("#2f4870")), ((V)(0D)), ((V)("MODERN ART"))), Arr(((V)((-1.6))), ((V)(5.2)), ((V)(0.5)), ((V)(31D)), ((V)(4.6)), ((V)(26D)), ((V)("#7f2030")), ((V)(0.09)), ((V)("BAUHAUS"))), Arr(((V)(1.2)), ((V)(9.8)), ((V)((-0.6))), ((V)(27D)), ((V)(4D)), ((V)(22D)), ((V)("#1f4f3e")), ((V)((-0.11))), ((V)("MATISSE"))));
TY_4632 = 13.8;
mx_4633 = (-2.5);
mz_4634 = (-3.2);
return NewObj(6).Put("w", ((V)(52D))).Put("d", ((V)(40D))).Put("small", ((V)(1D))).Put("topH", ((V)(15D))).Put("build", Fn((V _arrowThis4641, int _argc4635, V _a4637, V _a4638, V _a4639, V _a4640, V[] _rest4636) => {
V o_4642 = default;
V on_4643 = default;
V B_4644 = default;
V RNG_4645 = default;
V hd0_4646 = default;
V hd1_4647 = default;
V hd2_4648 = default;
V HW_4649 = default;
o_4642 = Arr();
on_4643 = Call(glue_31, V.Undef, o_4642);
B_4644 = Arr();
Invoke(BK_4631, "forEach", Fn((V _arrowThis4673, int _argc4650, V _a4652, V _a4653, V _a4654, V _a4655, V[] _rest4651) => {
V S1_4674 = default;
V L_4675 = default;
V Nn_4676 = default;
double hw_4677 = 0;
double hd_4678 = 0;
V yb_4679 = default;
double yt_4680 = 0;
V PG_4681 = default;
V PLn_4682 = default;
V GB_4683 = default;
V CW_4684 = default;
V DB_4685 = default;
V WR_4686 = default;
double fu_4687 = 0;
double fv0_4688 = 0;
double fv1_4689 = 0;
V x_4658 = default;
V y_4660 = default;
V z_4662 = default;
V w_4664 = default;
V t_4666 = default;
V d_4668 = default;
V col_4670 = default;
V yaw_4672 = default;
{ V _t4656 = ListOf(_a4652);
{ V _t4657 = GetIdx(_t4656, 0D);
x_4658 = _t4657; }
{ V _t4659 = GetIdx(_t4656, 1D);
y_4660 = _t4659; }
{ V _t4661 = GetIdx(_t4656, 2D);
z_4662 = _t4661; }
{ V _t4663 = GetIdx(_t4656, 3D);
w_4664 = _t4663; }
{ V _t4665 = GetIdx(_t4656, 4D);
t_4666 = _t4665; }
{ V _t4667 = GetIdx(_t4656, 5D);
d_4668 = _t4667; }
{ V _t4669 = GetIdx(_t4656, 6D);
col_4670 = _t4669; }
{ V _t4671 = GetIdx(_t4656, 7D);
yaw_4672 = _t4671; }
}
S1_4674 = Call(box_11, V.Undef, x_4658, y_4660, z_4662, w_4664, t_4666, d_4668, col_4670, NewObj(3).Put("r", ((V)(0.5))).Put("yaw", yaw_4672).Put("mat", ((V)("fab"))).V);
Invoke(o_4642, "push", S1_4674);
Invoke(B_4644, "push", S1_4674);
L_4675 = Call(L__3992, V.Undef, x_4658, z_4662, yaw_4672);
Nn_4676 = Call(NL_3993, V.Undef, yaw_4672);
hw_4677 = (ToNum(w_4664) / 2D);
hd_4678 = (ToNum(d_4668) / 2D);
yb_4679 = Add(y_4660, ((V)(0.75)));
yt_4680 = (ToNum(Add(y_4660, t_4666)) - 0.75);
PG_4681 = Call(dec_44, V.Undef, ((V)("#f4ecd8")));
PLn_4682 = Call(dec_44, V.Undef, ((V)("#cfc2a4")), NewObj(1).Put("op", ((V)(0.85))).V);
GB_4683 = Call(dec_44, V.Undef, GOLD_3990);
CW_4684 = Call(dec_44, V.Undef, Call(shade_14, V.Undef, col_4670, ((V)(1.18))), NewObj(1).Put("op", ((V)(0.35))).V);
DB_4685 = Call(dec_44, V.Undef, Call(shade_14, V.Undef, col_4670, ((V)(0.72))), NewObj(1).Put("op", ((V)(0.8))).V);
WR_4686 = Call(dec_44, V.Undef, Call(mix_15, V.Undef, col_4670, ((V)("#ffffff")), ((V)(0.45))), NewObj(1).Put("op", ((V)(0.5))).V);
Invoke(Arr(Arr(((V)(hw_4677)), ((V)(((-hd_4678) + 0.6))), ((V)(hw_4677)), ((V)((hd_4678 - 1.4))), ((V)(1D)), ((V)(0D))), Arr(((V)((-hw_4677))), ((V)(((-hd_4678) + 0.6))), ((V)((-hw_4677))), ((V)((hd_4678 - 1.4))), ((V)((-1D))), ((V)(0D))), Arr(((V)(((-hw_4677) + 0.6))), ((V)((-hd_4678))), ((V)((hw_4677 - 0.6))), ((V)((-hd_4678))), ((V)(0D)), ((V)((-1D))))), "forEach", Fn((V _arrowThis4709, int _argc4690, V _a4692, V _a4693, V _a4694, V _a4695, V[] _rest4691) => {
V n_4710 = default;
V u0_4698 = default;
V v0_4700 = default;
V u1_4702 = default;
V v1_4704 = default;
V nu_4706 = default;
V nv_4708 = default;
{ V _t4696 = ListOf(_a4692);
{ V _t4697 = GetIdx(_t4696, 0D);
u0_4698 = _t4697; }
{ V _t4699 = GetIdx(_t4696, 1D);
v0_4700 = _t4699; }
{ V _t4701 = GetIdx(_t4696, 2D);
u1_4702 = _t4701; }
{ V _t4703 = GetIdx(_t4696, 3D);
v1_4704 = _t4703; }
{ V _t4705 = GetIdx(_t4696, 4D);
nu_4706 = _t4705; }
{ V _t4707 = GetIdx(_t4696, 5D);
nv_4708 = _t4707; }
}
n_4710 = Call(Nn_4676, V.Undef, nu_4706, nv_4708);
Invoke(PG_4681, "poly", Arr(Call(L_4675, V.Undef, u0_4698, yb_4679, v0_4700), Call(L_4675, V.Undef, u1_4702, yb_4679, v1_4704), Call(L_4675, V.Undef, u1_4702, ((V)(yt_4680)), v1_4704), Call(L_4675, V.Undef, u0_4698, ((V)(yt_4680)), v0_4700)), n_4710);
Call(rep_28, V.Undef, ((V)(4D)), Fn((V _arrowThis4718, int _argc4711, V k_4717, V _a4714, V _a4715, V _a4716, V[] _rest4712) => {
V yy_4719 = default;
yy_4719 = Add(yb_4679, ((V)((((yt_4680 - ToNum(yb_4679)) * ToNum(Add(k_4717, ((V)(0.5))))) / 4D))));
Invoke(PLn_4682, "line", Arr(Call(L_4675, V.Undef, u0_4698, yy_4719, v0_4700), Call(L_4675, V.Undef, u1_4702, yy_4719, v1_4704)), n_4710, ((V)(0.09)));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(Arr(Add(y_4660, ((V)(0.55))), ((V)(0.22))), Arr(Add(y_4660, ((V)(0.85))), ((V)(0.1))), Arr(((V)((ToNum(Add(y_4660, t_4666)) - 0.55))), ((V)(0.22))), Arr(((V)((ToNum(Add(y_4660, t_4666)) - 0.85))), ((V)(0.1)))), "forEach", Fn((V _arrowThis4731, int _argc4720, V _a4722, V _a4723, V _a4724, V _a4725, V[] _rest4721) => {
V yy_4728 = default;
V ww_4730 = default;
{ V _t4726 = ListOf(_a4722);
{ V _t4727 = GetIdx(_t4726, 0D);
yy_4728 = _t4727; }
{ V _t4729 = GetIdx(_t4726, 1D);
ww_4730 = _t4729; }
}
return Invoke(GB_4683, "line", Arr(Call(L_4675, V.Undef, ((V)(((-hw_4677) + 0.8))), yy_4728, ((V)(hd_4678))), Call(L_4675, V.Undef, ((V)((hw_4677 - 0.8))), yy_4728, ((V)(hd_4678)))), Call(Nn_4676, V.Undef, ((V)(0D)), ((V)(1D))), ww_4730);
}, 1, "", true));
Invoke(DB_4685, "line", Arr(Call(L_4675, V.Undef, ((V)(((-hw_4677) + 0.5))), Add(y_4660, t_4666), ((V)((hd_4678 - 1.6)))), Call(L_4675, V.Undef, ((V)((hw_4677 - 0.5))), Add(y_4660, t_4666), ((V)((hd_4678 - 1.6))))), Y3_40, ((V)(0.18)));
Call(rep_28, V.Undef, ((V)(7D)), Fn((V _arrowThis4739, int _argc4732, V k_4738, V _a4735, V _a4736, V _a4737, V[] _rest4733) => {
return Invoke(CW_4684, "line", Arr(Call(L_4675, V.Undef, ((V)(((-hw_4677) + 0.6))), Add(y_4660, t_4666), ((V)((((-hd_4678) + 2D) + ((ToNum(k_4738) * (ToNum(d_4668) - 4D)) / 6D))))), Call(L_4675, V.Undef, ((V)((hw_4677 - 0.6))), Add(y_4660, t_4666), ((V)((((-hd_4678) + 2D) + ((ToNum(k_4738) * (ToNum(d_4668) - 4D)) / 6D)))))), Y3_40, ((V)(0.08)));
}, 1, "", true));
fu_4687 = (hw_4677 - 2.2);
fv0_4688 = ((-hd_4678) + 2.2);
fv1_4689 = (hd_4678 - 3.2);
Invoke(Arr(Arr(((V)((-fu_4687))), ((V)(fv0_4688)), ((V)(fu_4687)), ((V)(fv0_4688))), Arr(((V)(fu_4687)), ((V)(fv0_4688)), ((V)(fu_4687)), ((V)(fv1_4689))), Arr(((V)(fu_4687)), ((V)(fv1_4689)), ((V)((-fu_4687))), ((V)(fv1_4689))), Arr(((V)((-fu_4687))), ((V)(fv1_4689)), ((V)((-fu_4687))), ((V)(fv0_4688)))), "forEach", Fn((V _arrowThis4755, int _argc4740, V _a4742, V _a4743, V _a4744, V _a4745, V[] _rest4741) => {
V a_4748 = default;
V b_4750 = default;
V c2_4752 = default;
V e_4754 = default;
{ V _t4746 = ListOf(_a4742);
{ V _t4747 = GetIdx(_t4746, 0D);
a_4748 = _t4747; }
{ V _t4749 = GetIdx(_t4746, 1D);
b_4750 = _t4749; }
{ V _t4751 = GetIdx(_t4746, 2D);
c2_4752 = _t4751; }
{ V _t4753 = GetIdx(_t4746, 3D);
e_4754 = _t4753; }
}
return Invoke(DB_4685, "line", Arr(Call(L_4675, V.Undef, a_4748, Add(y_4660, t_4666), b_4750), Call(L_4675, V.Undef, c2_4752, Add(y_4660, t_4666), e_4754)), Y3_40, ((V)(0.16)));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis4767, int _argc4756, V _a4758, V _a4759, V _a4760, V _a4761, V[] _rest4757) => {
V a_4764 = default;
V b_4766 = default;
{ V _t4762 = ListOf(_a4758);
{ V _t4763 = GetIdx(_t4762, 0D);
a_4764 = _t4763; }
{ V _t4765 = GetIdx(_t4762, 1D);
b_4766 = _t4765; }
}
return Call(spot_46, V.Undef, WR_4686, Call(L_4675, V.Undef, ((V)((ToNum(a_4764) * (hw_4677 - 0.7)))), Add(y_4660, t_4666), ((V)((ToNum(b_4766) * (hd_4678 - 0.7))))), Y3_40, ((V)(0.9)), ((V)(0.6)), Add(yaw_4672, ((V)(((ToNum(a_4764) * ToNum(b_4766)) * 0.8)))), ((V)(8D)));
}, 1, "", true));
Call(on_4643, V.Undef, S1_4674, Arr(PG_4681, PLn_4682, CW_4684, DB_4685, WR_4686, GB_4683));
return default;
}, 1, "", true));
{
V x_4768 = default;
V y_4769 = default;
V z_4770 = default;
V w_4771 = default;
V t_4772 = default;
V d_4773 = default;
V yaw_4774 = default;
V L_4775 = default;
V RB_4776 = default;
V RB2_4777 = default;
double u_4778 = 0;
double hd_4779 = 0;
{ V _t4780 = GetIdx(BK_4631, 1D);
{ V _t4781 = ListOf(_t4780);
{ V _t4782 = GetIdx(_t4781, 0D);
x_4768 = _t4782; }
{ V _t4783 = GetIdx(_t4781, 1D);
y_4769 = _t4783; }
{ V _t4784 = GetIdx(_t4781, 2D);
z_4770 = _t4784; }
{ V _t4785 = GetIdx(_t4781, 3D);
w_4771 = _t4785; }
{ V _t4786 = GetIdx(_t4781, 4D);
t_4772 = _t4786; }
{ V _t4787 = GetIdx(_t4781, 5D);
d_4773 = _t4787; }
{ V _t4788 = GetIdx(_t4781, 7D);
yaw_4774 = _t4788; }
} }
L_4775 = Call(L__3992, V.Undef, x_4768, z_4770, yaw_4774);
RB_4776 = Call(dec_44, V.Undef, ((V)("#c8303a")));
RB2_4777 = Call(dec_44, V.Undef, ((V)("#c8303a")));
u_4778 = (-6D);
hd_4779 = (ToNum(d_4773) / 2D);
Invoke(RB_4776, "line", Arr(Call(L_4775, V.Undef, ((V)(u_4778)), ((V)((ToNum(Add(y_4769, t_4772)) - 0.4))), ((V)((-hd_4779)))), Call(L_4775, V.Undef, ((V)(u_4778)), Add(y_4769, ((V)(0.2))), ((V)((-hd_4779))))), Call(Call(NL_3993, V.Undef, yaw_4774), V.Undef, ((V)(0D)), ((V)((-1D)))), ((V)(0.9)));
Invoke(RB2_4777, "line", Arr(Call(L_4775, V.Undef, ((V)(u_4778)), ((V)(5.2)), ((V)((-hd_4779)))), Call(L_4775, V.Undef, ((V)((u_4778 - 0.4))), ((V)(5.2)), ((V)(((-hd_4779) - 1.4)))), Call(L_4775, V.Undef, ((V)((u_4778 - 0.2))), ((V)(5.2)), ((V)(((-hd_4779) - 2.2))))), Y3_40, ((V)(0.9)));
Call(on_4643, V.Undef, GetIdx(B_4644, 1D), Arr(RB_4776));
Call(on_4643, V.Undef, GetIdx(B_4644, 0D), Arr(RB2_4777));
}
{
V PC_4789 = default;
V SP_4790 = default;
V LN_4791 = default;
PC_4789 = GetIdx(Call(on_4643, V.Undef, GetIdx(B_4644, 0D), Arr(Call(box_11, V.Undef, ((V)(19.2)), ((V)(2D)), ((V)(4D)), ((V)(3.4)), ((V)(0.16)), ((V)(8.6)), ((V)("#f6efe0")), NewObj(1).Put("r", ((V)(0.1))).V))), 0D);
SP_4790 = Call(dec_44, V.Undef, ((V)("#c8303a")));
LN_4791 = Call(dec_44, V.Undef, ((V)("#3a5a9a")), NewObj(1).Put("op", ((V)(0.7))).V);
Invoke(SP_4790, "poly", Arr(Arr(((V)(19.6)), ((V)(2.16)), ((V)(0.4))), Arr(((V)(20.6)), ((V)(2.16)), ((V)(0.4))), Arr(((V)(20.6)), ((V)(2.16)), ((V)(1.6))), Arr(((V)(19.6)), ((V)(2.16)), ((V)(1.6)))), Y3_40);
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis4799, int _argc4792, V k_4798, V _a4795, V _a4796, V _a4797, V[] _rest4793) => {
return Call(seg_56, V.Undef, LN_4791, Arr(((V)(18.2)), ((V)(2.16)), ((V)((3D + (ToNum(k_4798) * 1.4))))), Arr(((V)(20.6)), ((V)(2.16)), ((V)((3D + (ToNum(k_4798) * 1.4))))), Y3_40, ((V)(0.1)));
}, 1, "", true));
Call(on_4643, V.Undef, PC_4789, Arr(SP_4790, LN_4791));
}
RNG_4645 = Call(arcW_3979, V.Undef, ((V)(mx_4633)), ((V)(TY_4632)), ((V)(mz_4634)), ((V)(6.4)), ((V)(6.4)), ((V)(1.2)), ((V)(1.3)), ((V)(0D)), ((V)((2D * PI_17))), BR_18, Call(M__24, V.Undef, NewObj(2).Put("n", ((V)(30D))).Put("shine", ((V)(1D))).V));
Invoke(o_4642, "push", RNG_4645);
{
V HL_4800 = default;
V ED_4801 = default;
HL_4800 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.7))).V);
ED_4801 = Call(dec_44, V.Undef, ((V)("#8a6a22")), NewObj(1).Put("op", ((V)(0.6))).V);
Call(ringY_51, V.Undef, HL_4800, ((V)(mx_4633)), ((V)(mz_4634)), ((V)(5.95)), ((V)((TY_4632 + 1.3))), ((V)(0.16)), ((V)(30D)));
Call(ringY_51, V.Undef, ED_4801, ((V)(mx_4633)), ((V)(mz_4634)), ((V)(5.5)), ((V)((TY_4632 + 1.3))), ((V)(0.12)), ((V)(30D)));
Call(on_4643, V.Undef, RNG_4645, Arr(HL_4800, ED_4801, Call(cyl_12, V.Undef, ((V)(mx_4633)), ((V)((TY_4632 + 0.1))), ((V)(mz_4634)), ((V)(5.2)), ((V)(0.6)), ((V)("#e6f6fd")), NewObj(3).Put("n", ((V)(26D))).Put("op", ((V)(0.35))).Put("shine", ((V)(1D))).V)));
}
hd0_4646 = Arr(((V)((mx_4633 + 6.6))), ((V)((TY_4632 + 1.2))), ((V)((mz_4634 + 1.5))));
hd1_4647 = Arr(((V)((mx_4633 + 8.8))), ((V)((TY_4632 + 1.2))), ((V)((mz_4634 + 2D))));
hd2_4648 = Arr(((V)((mx_4633 + 16D))), ((V)((TY_4632 + 1.2))), ((V)((mz_4634 + 3.8))));
HW_4649 = Call(rod_22, V.Undef, hd1_4647, hd2_4648, ((V)(1.15)), ((V)("#3a2416")), Call(W__25, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("shine", ((V)(1D))).V));
Invoke(o_4642, "push", Call(rod_22, V.Undef, hd0_4646, hd1_4647, ((V)(0.85)), BR_18, Call(M__24, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)), HW_4649);
{
V G_4802 = default;
V d_4803 = default;
G_4802 = Call(dec_44, V.Undef, ((V)("#6a4428")), NewObj(1).Put("op", ((V)(0.6))).V);
d_4803 = Call(nz_38, V.Undef, Call(sub_35, V.Undef, hd2_4648, hd1_4647));
Invoke(Arr(((V)((-0.5))), ((V)(0.5))), "forEach", Fn((V _arrowThis4811, int _argc4804, V s2_4810, V _a4807, V _a4808, V _a4809, V[] _rest4805) => {
return Invoke(G_4802, "line", Call(wv_43, V.Undef, ((V)(6D)), Fn((V _arrowThis4819, int _argc4812, V t_4818, V _a4815, V _a4816, V _a4817, V[] _rest4813) => {
return Call(add_34, V.Undef, Call(add_34, V.Undef, hd1_4647, Call(mul_36, V.Undef, d_4803, ((V)((0.4 + (ToNum(t_4818) * 6.6)))))), Arr(((V)(0D)), ((V)(1.16)), ((V)((ToNum(s2_4810) * 0.3)))));
}, 1, "", true)), Y3_40, ((V)(0.1)));
}, 1, "", true));
Call(on_4643, V.Undef, HW_4649, Arr(G_4802, Call(ball_13, V.Undef, Add(GetIdx(hd2_4648, 0D), ((V)(0.2))), GetIdx(hd2_4648, 1D), Add(GetIdx(hd2_4648, 2D), ((V)(0.05))), ((V)(1.15)), BR_18, Call(M__24, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V))));
}
return o_4642;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis4827, int _argc4820, V c_4826, V _a4823, V _a4824, V _a4825, V[] _rest4821) => {
JsStrBuf f_4828 = null;
V q_4829 = default;
V k_4830 = default;
f_4828 = new JsStrBuf("");
Invoke(BK_4631, "forEach", Fn((V _arrowThis4857, int _argc4831, V _a4833, V bi_4837, V _a4835, V _a4836, V[] _rest4832) => {
double cs_4858 = 0;
double sn_4859 = 0;
V L_4860 = default;
V M_4861 = default;
V x_4840 = default;
V y_4842 = default;
V z_4844 = default;
V w_4846 = default;
V t_4848 = default;
V d_4850 = default;
V col_4852 = default;
V yaw_4854 = default;
V title_4856 = default;
{ V _t4838 = ListOf(_a4833);
{ V _t4839 = GetIdx(_t4838, 0D);
x_4840 = _t4839; }
{ V _t4841 = GetIdx(_t4838, 1D);
y_4842 = _t4841; }
{ V _t4843 = GetIdx(_t4838, 2D);
z_4844 = _t4843; }
{ V _t4845 = GetIdx(_t4838, 3D);
w_4846 = _t4845; }
{ V _t4847 = GetIdx(_t4838, 4D);
t_4848 = _t4847; }
{ V _t4849 = GetIdx(_t4838, 5D);
d_4850 = _t4849; }
{ V _t4851 = GetIdx(_t4838, 6D);
col_4852 = _t4851; }
{ V _t4853 = GetIdx(_t4838, 7D);
yaw_4854 = _t4853; }
{ V _t4855 = GetIdx(_t4838, 8D);
title_4856 = _t4855; }
}
cs_4858 = FdLibm.Cos(ToNum(yaw_4854));
sn_4859 = FdLibm.Sin(ToNum(yaw_4854));
if (LtN(Call(face_3981, V.Undef, c_4826, ((V)((-sn_4859))), ((V)(cs_4858))), 0.08)) {
return default;
}
L_4860 = Call(L__3992, V.Undef, x_4840, z_4844, yaw_4854);
M_4861 = Call(frame_3982, V.Undef, Get(c_4826, "p"), Call(L_4860, V.Undef, ((V)(((-ToNum(w_4846)) / 2D))), Add(y_4842, t_4848), ((V)(((ToNum(d_4850) / 2D) + 0.06)))), Arr(((V)(cs_4858)), ((V)(0D)), ((V)(sn_4859))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
f_4828.S("<g transform=\"").V(M_4861).S("\"><text x=\"").V(Call(f1_3980, V.Undef, ((V)((ToNum(w_4846) / 2D))))).S("\" y=\"").V(Call(f1_3980, V.Undef, ((V)(((ToNum(t_4848) / 2D) + 0.95))))).S("\" text-anchor=\"middle\" font-family=\"Georgia, 'Times New Roman', serif\" font-weight=\"700\" font-size=\"").V(Call(f1_3980, V.Undef, ((V)(Min(2.7, (ToNum(t_4848) * 0.58)))))).S("\" letter-spacing=\"0.4\" fill=\"#f2d27a\">").V(title_4856).S("</text><text x=\"").V(Call(f1_3980, V.Undef, ((V)((ToNum(w_4846) - 2.4))))).S("\" y=\"").V(Call(f1_3980, V.Undef, ((V)(((ToNum(t_4848) / 2D) + 0.5))))).S("\" text-anchor=\"middle\" font-family=\"Georgia, serif\" font-size=\"1.1\" fill=\"#f2d27a\">").V(GetK(Arr(((V)("I")), ((V)("II")), ((V)("III"))), bi_4837)).S("</text></g>");
return default;
}, 2, "", true));
{
V x_4862 = default;
V z_4863 = default;
V yaw_4864 = default;
V L_4865 = default;
double cs_4866 = 0;
double sn_4867 = 0;
V M_4868 = default;
{ V _t4869 = GetIdx(BK_4631, 2D);
{ V _t4870 = ListOf(_t4869);
{ V _t4871 = GetIdx(_t4870, 0D);
x_4862 = _t4871; }
{ V _t4872 = GetIdx(_t4870, 2D);
z_4863 = _t4872; }
{ V _t4873 = GetIdx(_t4870, 7D);
yaw_4864 = _t4873; }
} }
L_4865 = Call(L__3992, V.Undef, x_4862, z_4863, yaw_4864);
cs_4866 = FdLibm.Cos(ToNum(yaw_4864));
sn_4867 = FdLibm.Sin(ToNum(yaw_4864));
M_4868 = Call(frame_3982, V.Undef, Get(c_4826, "p"), Call(L_4865, V.Undef, ((V)(2D)), ((V)((TY_4632 + 0.06))), ((V)(5.6))), Arr(((V)(cs_4866)), ((V)(0D)), ((V)(sn_4867))), Arr(((V)((-sn_4867))), ((V)(0D)), ((V)(cs_4866))));
f_4828.S("<g transform=\"").V(M_4868).S("\"><text text-anchor=\"middle\" font-family=\"Georgia, serif\" font-weight=\"700\" font-size=\"2.2\" letter-spacing=\"0.6\" fill=\"#e2c26a\">MATISSE</text><text y=\"2.1\" text-anchor=\"middle\" font-family=\"Georgia, serif\" font-style=\"italic\" font-size=\"1.2\" fill=\"#d8b85a\">the cut-outs</text></g>");
}
q_4829 = Invoke(c_4826, "p", ((V)((mx_4633 - 1.5))), ((V)((TY_4632 + 0.8))), ((V)((mz_4634 - 1.5))));
k_4830 = Get(c_4826, "k");
f_4828.S("<path d=\"M").V(Call(f1_3980, V.Undef, ((V)((ToNum(GetIdx(q_4829, 0D)) - (2.6 * ToNum(k_4830))))))).S(" ").V(Call(f1_3980, V.Undef, GetIdx(q_4829, 1D))).S("Q").V(Call(f1_3980, V.Undef, ((V)((ToNum(GetIdx(q_4829, 0D)) - (0.6 * ToNum(k_4830))))))).S(" ").V(Call(f1_3980, V.Undef, ((V)((ToNum(GetIdx(q_4829, 1D)) - (1.8 * ToNum(k_4830))))))).S(" ").V(Call(f1_3980, V.Undef, Add(GetIdx(q_4829, 0D), ((V)((2.6 * ToNum(k_4830))))))).S(" ").V(Call(f1_3980, V.Undef, ((V)((ToNum(GetIdx(q_4829, 1D)) - (1.2 * ToNum(k_4830))))))).S("\" fill=\"none\" stroke=\"#fff\" stroke-width=\"").V(Call(f1_3980, V.Undef, ((V)((0.5 * ToNum(k_4830)))))).S("\" opacity=\"0.75\">").V(Call(an_3983, V.Undef, ((V)("opacity")), ((V)("0.35;0.85;0.35")), ((V)(4.5)))).S("</path>");
return NewObj(1).Put("front", ((V)(f_4828.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_16, "ikebana25", Fn((V _arrowThis4881, int _argc4874, V S_4880, V _a4877, V _a4878, V _a4879, V[] _rest4875) => {
double TY_4882 = 0;
double VX_4883 = 0;
double VZ_4884 = 0;
double VH_4885 = 0;
double IX_4886 = 0;
double IZ_4887 = 0;
V rV_4888 = default;
V sb_4889 = default;
V sd_4890 = default;
V sp_4891 = default;
V TIP_4892 = default;
TY_4882 = 1.4;
VX_4883 = (-11D);
VZ_4884 = (-3D);
VH_4885 = 20D;
IX_4886 = 11D;
IZ_4887 = 3D;
rV_4888 = Fn((V _arrowThis4900, int _argc4893, V y_4899, V _a4896, V _a4897, V _a4898, V[] _rest4894) => {
return ((V)((6D * (LtN(y_4899, 7D) ? (0.86 + ((0.14 * ToNum(y_4899)) / 7D)) : (1D - ((0.34 * (ToNum(y_4899) - 7D)) / 13D))))));
}, 1, "", true);
sb_4889 = Arr(((V)((IX_4886 + 1D))), ((V)((TY_4882 + 2.6))), ((V)((IZ_4887 - 0.5))));
sd_4890 = Arr(((V)(3.8)), ((V)(11.4)), ((V)((-1.2))));
sp_4891 = Fn((V _arrowThis4908, int _argc4901, V t_4907, V _a4904, V _a4905, V _a4906, V[] _rest4902) => {
return Call(add_34, V.Undef, sb_4889, Call(mul_36, V.Undef, sd_4890, t_4907));
}, 1, "", true);
TIP_4892 = Call(add_34, V.Undef, Call(sp_4891, V.Undef, ((V)(1D))), Arr(((V)(0.9)), ((V)(0.7)), ((V)(0D))));
return NewObj(6).Put("w", ((V)(56D))).Put("d", ((V)(36D))).Put("small", ((V)(1D))).Put("topH", ((V)(22D))).Put("build", Fn((V _arrowThis4915, int _argc4909, V _a4911, V _a4912, V _a4913, V _a4914, V[] _rest4910) => {
V o_4916 = default;
V on_4917 = default;
V R_4918 = default;
V TR_4919 = default;
V V_4920 = default;
double y0_4921 = 0;
V lerp_4922 = default;
V P1_4923 = default;
V b1_4924 = default;
V P2b_4925 = default;
V b2_4926 = default;
V P3_4927 = default;
V b3_4928 = default;
V ID_4929 = default;
V IB_4930 = default;
V KB_4931 = default;
o_4916 = Arr();
on_4917 = Call(glue_31, V.Undef, o_4916);
R_4918 = Call(R0_30, V.Undef, ((V)("ikebana25")));
TR_4919 = Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(52D)), ((V)(TY_4882)), ((V)(28D)), ((V)("#2c2f35")), NewObj(2).Put("r", ((V)(0.8))).Put("mat", ((V)("cer"))).V);
Invoke(o_4916, "push", TR_4919);
{
V C1_4932 = default;
V C2_4933 = default;
V EH_4934 = default;
V CA2_4935 = default;
C1_4932 = Call(dec_44, V.Undef, ((V)("#1c1e22")), NewObj(1).Put("op", ((V)(0.7))).V);
C2_4933 = Call(dec_44, V.Undef, ((V)("#4a4e56")), NewObj(1).Put("op", ((V)(0.6))).V);
EH_4934 = Call(dec_44, V.Undef, ((V)("#5a5f68")), NewObj(1).Put("op", ((V)(0.9))).V);
CA2_4935 = Call(dec_44, V.Undef, ((V)("#bfefff")), NewObj(1).Put("op", ((V)(0.22))).V);
Call(rep_28, V.Undef, ((V)(9D)), Fn((V _arrowThis4943, int _argc4936, V k_4942, V _a4939, V _a4940, V _a4941, V[] _rest4937) => {
double z_4944 = 0;
double ph_4945 = 0;
double x_4946 = 0;
z_4944 = (((-12.5) + (ToNum(k_4942) * 3.1)) + (ToNum(Call(R_4918, V.Undef)) - 0.5));
ph_4945 = (ToNum(Call(R_4918, V.Undef)) * 6D);
x_4946 = ((-25D) + (ToNum(Call(R_4918, V.Undef)) * 3D));
while ((x_4946 < 24D)) {
double Lg_4947 = 0;
double xa_4948 = 0;
Lg_4947 = Min((24D - x_4946), (3D + (ToNum(Call(R_4918, V.Undef)) * 9D)));
xa_4948 = x_4946;
Invoke((LtN(Call(R_4918, V.Undef), 0.6) ? C1_4932 : C2_4933), "line", Call(wv_43, V.Undef, ((V)(6D)), Fn((V _arrowThis4956, int _argc4949, V t_4955, V _a4952, V _a4953, V _a4954, V[] _rest4950) => {
return Arr(((V)((xa_4948 + (Lg_4947 * ToNum(t_4955))))), ((V)(TY_4882)), ((V)((z_4944 + (0.4 * FdLibm.Sin((((xa_4948 + (Lg_4947 * ToNum(t_4955))) * 0.4) + ph_4945)))))));
}, 1, "", true)), Y3_40, ((V)((0.15 + (ToNum(Call(R_4918, V.Undef)) * 0.25)))), ((V)(1D)));
x_4946 = (x_4946 + ((Lg_4947 + 1D) + (ToNum(Call(R_4918, V.Undef)) * 4D)));
}
return default;
}, 1, "", true));
Call(seg_56, V.Undef, EH_4934, Arr(((V)((-25.4))), ((V)(TY_4882)), ((V)(13.8))), Arr(((V)(25.4)), ((V)(TY_4882)), ((V)(13.8))), Y3_40, ((V)(0.3)));
Call(seg_56, V.Undef, EH_4934, Arr(((V)((-25.6))), ((V)((TY_4882 - 0.3))), ((V)(14D))), Arr(((V)(25.6)), ((V)((TY_4882 - 0.3))), ((V)(14D))), Z3_41, ((V)(0.25)));
Call(spot_46, V.Undef, CA2_4935, Arr(((V)((VX_4883 + 2.5))), ((V)(TY_4882)), ((V)((VZ_4884 + 9D)))), Y3_40, ((V)(3.2)), ((V)(1.6)), ((V)(0.3)), ((V)(14D)));
Call(spot_46, V.Undef, CA2_4935, Arr(((V)((VX_4883 + 1.8))), ((V)(TY_4882)), ((V)((VZ_4884 + 8.4)))), Y3_40, ((V)(1.4)), ((V)(0.6)), ((V)(0.3)), ((V)(10D)));
Call(on_4917, V.Undef, TR_4919, Arr(C1_4932, C2_4933, EH_4934, CA2_4935));
}
V_4920 = Call(cyl_12, V.Undef, ((V)(VX_4883)), ((V)(TY_4882)), ((V)(VZ_4884)), ((V)(6D)), ((V)(VH_4885)), ((V)("#e3f3fa")), NewObj(4).Put("n", ((V)(8D))).Put("op", ((V)(0.45))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.86))), Arr(((V)(7D)), ((V)(0D)), ((V)(1D))), Arr(((V)(VH_4885)), ((V)(0D)), ((V)(0.66))))).V);
Invoke(o_4916, "push", V_4920);
{
V FE_4957 = default;
V CU_4958 = default;
V WT_4959 = default;
V STm_4960 = default;
V MO_4961 = default;
V rr_4962 = default;
FE_4957 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.75))).V);
CU_4958 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.4))).V);
WT_4959 = Call(dec_44, V.Undef, ((V)("#8fd0ea")), NewObj(1).Put("op", ((V)(0.22))).V);
STm_4960 = Call(dec_44, V.Undef, ((V)("#4a7a3a")), NewObj(1).Put("op", ((V)(0.5))).V);
MO_4961 = Call(dec_44, V.Undef, ((V)("#2a4a52")), NewObj(1).Put("op", ((V)(0.55))).V);
rr_4962 = Fn((V _arrowThis4970, int _argc4963, V y_4969, V _a4966, V _a4967, V _a4968, V[] _rest4964) => {
return Call(rV_4888, V.Undef, ((V)((ToNum(y_4969) - TY_4882))));
}, 1, "", true);
Call(band3_3999, V.Undef, WT_4959, ((V)(VX_4883)), ((V)(VZ_4884)), rr_4962, ((V)((TY_4882 + 0.6))), ((V)((TY_4882 + 12.5))), ((V)(0D)), ((V)((2D * PI_17))), ((V)(16D)));
Invoke(Arr(Arr(((V)(((PI_17 / 2D) - 0.25))), ((V)(0.3))), Arr(((V)(((PI_17 / 2D) + 0.2))), ((V)((-0.2)))), Arr(((V)(((PI_17 / 2D) + 0.05))), ((V)(0.5)))), "forEach", Fn((V _arrowThis4982, int _argc4971, V _a4973, V _a4974, V _a4975, V _a4976, V[] _rest4972) => {
V a_4979 = default;
V da_4981 = default;
{ V _t4977 = ListOf(_a4973);
{ V _t4978 = GetIdx(_t4977, 0D);
a_4979 = _t4978; }
{ V _t4980 = GetIdx(_t4977, 1D);
da_4981 = _t4980; }
}
return Invoke(STm_4960, "line", Call(wv_43, V.Undef, ((V)(6D)), Fn((V _arrowThis4990, int _argc4983, V t_4989, V _a4986, V _a4987, V _a4988, V[] _rest4984) => {
double y_4991 = 0;
y_4991 = ((TY_4882 + 1D) + (ToNum(t_4989) * (VH_4885 - 1.4)));
return Call(cP_3995, V.Undef, ((V)(VX_4883)), ((V)(VZ_4884)), Call(rr_4962, V.Undef, ((V)(y_4991))), Add(a_4979, ((V)(((ToNum(da_4981) * ToNum(t_4989)) * 0.3)))), ((V)(y_4991)));
return default;
}, 1, "", true)), Call(wv_43, V.Undef, ((V)(6D)), Fn((V _arrowThis4999, int _argc4992, V t_4998, V _a4995, V _a4996, V _a4997, V[] _rest4993) => {
return Call(cN_42, V.Undef, Add(a_4979, ((V)(((ToNum(da_4981) * ToNum(t_4998)) * 0.3)))));
}, 1, "", true)), ((V)(0.3)));
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(8D)), Fn((V _arrowThis5007, int _argc5000, V k_5006, V _a5003, V _a5004, V _a5005, V[] _rest5001) => {
double a0_5008 = 0;
double a1_5009 = 0;
a0_5008 = ((ToNum(k_5006) * PI_17) / 4D);
a1_5009 = (a0_5008 + (PI_17 / 4D));
Invoke(CU_4958, "line", Arr(Call(cP_3995, V.Undef, ((V)(VX_4883)), ((V)(VZ_4884)), Call(rr_4962, V.Undef, ((V)((TY_4882 + 1D)))), ((V)(a0_5008)), ((V)((TY_4882 + 1D)))), Call(cP_3995, V.Undef, ((V)(VX_4883)), ((V)(VZ_4884)), Call(rr_4962, V.Undef, ((V)((TY_4882 + 6D)))), ((V)(a1_5009)), ((V)((TY_4882 + 6D))))), Call(cN_42, V.Undef, ((V)((a0_5008 + (PI_17 / 8D))))), ((V)(0.14)));
Invoke(CU_4958, "line", Arr(Call(cP_3995, V.Undef, ((V)(VX_4883)), ((V)(VZ_4884)), Call(rr_4962, V.Undef, ((V)((TY_4882 + 1D)))), ((V)(a1_5009)), ((V)((TY_4882 + 1D)))), Call(cP_3995, V.Undef, ((V)(VX_4883)), ((V)(VZ_4884)), Call(rr_4962, V.Undef, ((V)((TY_4882 + 6D)))), ((V)(a0_5008)), ((V)((TY_4882 + 6D))))), Call(cN_42, V.Undef, ((V)((a0_5008 + (PI_17 / 8D))))), ((V)(0.14)));
return default;
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(8D)), Fn((V _arrowThis5017, int _argc5010, V k_5016, V _a5013, V _a5014, V _a5015, V[] _rest5011) => {
return Call(vL_3998, V.Undef, FE_4957, ((V)(VX_4883)), ((V)(VZ_4884)), rr_4962, ((V)(((ToNum(k_5016) * PI_17) / 4D))), ((V)((TY_4882 + 0.2))), ((V)(((TY_4882 + VH_4885) - 0.2))), ((V)(0.16)));
}, 1, "", true));
Call(ringL_3997, V.Undef, FE_4957, ((V)(VX_4883)), ((V)(VZ_4884)), rr_4962, ((V)((TY_4882 + 7D))), ((V)(0.2)), ((V)(0D)), ((V)((2D * PI_17))), ((V)(32D)));
Call(ringL_3997, V.Undef, FE_4957, ((V)(VX_4883)), ((V)(VZ_4884)), rr_4962, ((V)((TY_4882 + 12.5))), ((V)(0.12)), ((V)(0D)), ((V)((2D * PI_17))), ((V)(32D)));
Invoke(MO_4961, "poly", Call(elP_45, V.Undef, Arr(((V)(VX_4883)), ((V)((TY_4882 + VH_4885))), ((V)(VZ_4884))), X3_39, Z3_41, ((V)(2.6)), ((V)(2.6)), ((V)(16D))), Y3_40);
Call(on_4917, V.Undef, V_4920, Arr(WT_4959, STm_4960, CU_4958, FE_4957, MO_4961));
}
y0_4921 = (TY_4882 + VH_4885);
lerp_4922 = Fn((V _arrowThis5027, int _argc5018, V P_5024, V s_5025, V t_5026, V _a5023, V[] _rest5019) => {
return Call(add_34, V.Undef, GetK(P_5024, s_5025), Call(mul_36, V.Undef, Call(sub_35, V.Undef, GetK(P_5024, Add(s_5025, ((V)(1D)))), GetK(P_5024, s_5025)), t_5026));
}, 3, "", true);
P1_4923 = Arr(Arr(((V)((VX_4883 - 0.8))), ((V)(y0_4921)), ((V)((VZ_4884 - 0.6)))), Arr(((V)((VX_4883 - 2.6))), ((V)((y0_4921 + 8.5))), ((V)((VZ_4884 - 1.3)))), Arr(((V)((VX_4883 - 1.6))), ((V)((y0_4921 + 17D))), ((V)((VZ_4884 - 2D)))), Arr(((V)((VX_4883 + 2.6))), ((V)((y0_4921 + 24.5))), ((V)((VZ_4884 - 2.4)))), Arr(((V)((VX_4883 + 8.4))), ((V)((y0_4921 + 28.4))), ((V)((VZ_4884 - 2D)))));
b1_4924 = Call(pipe_23, V.Undef, P1_4923, ((V)(0.42)), ((V)("#5a4030")), Call(W__25, V.Undef, NewObj(1).Put("n", ((V)(6D))).V));
Invoke(b1_4924, "forEach", Fn((V _arrowThis5035, int _argc5028, V s_5034, V _a5031, V _a5032, V _a5033, V[] _rest5029) => {
return Invoke(o_4916, "push", s_5034);
}, 1, "", true));
Invoke(Arr(Arr(((V)(0D)), ((V)(0.6)), ((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(0.35)), ((V)(1D)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(0.8)), ((V)((-1D))), ((V)(1D))), Arr(((V)(2D)), ((V)(0.3)), ((V)(1D)), ((V)(1D))), Arr(((V)(2D)), ((V)(0.7)), ((V)((-1D))), ((V)((-1D)))), Arr(((V)(3D)), ((V)(0.25)), ((V)(1D)), ((V)(1D))), Arr(((V)(3D)), ((V)(0.6)), ((V)((-1D))), ((V)(1D))), Arr(((V)(3D)), ((V)(0.95)), ((V)(1D)), ((V)((-1D))))), "forEach", Fn((V _arrowThis5052, int _argc5036, V _a5038, V i_5042, V _a5040, V _a5041, V[] _rest5037) => {
V p_5053 = default;
V si_5045 = default;
V t_5047 = default;
V sx_5049 = default;
V sz_5051 = default;
{ V _t5043 = ListOf(_a5038);
{ V _t5044 = GetIdx(_t5043, 0D);
si_5045 = _t5044; }
{ V _t5046 = GetIdx(_t5043, 1D);
t_5047 = _t5046; }
{ V _t5048 = GetIdx(_t5043, 2D);
sx_5049 = _t5048; }
{ V _t5050 = GetIdx(_t5043, 3D);
sz_5051 = _t5050; }
}
p_5053 = Call(add_34, V.Undef, Call(lerp_4922, V.Undef, P1_4923, si_5045, t_5047), Arr(((V)((ToNum(sx_5049) * 0.9))), ((V)(0.3)), ((V)((ToNum(sz_5051) * 0.6)))));
Call(on_4917, V.Undef, GetK(b1_4924, si_5045), (((ToNum(i_5042) % 3D) == 2D) ? Arr(Call(ball_13, V.Undef, GetIdx(p_5053, 0D), GetIdx(p_5053, 1D), GetIdx(p_5053, 2D), ((V)(0.6)), ((V)("#d8507a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)) : Arr(Call(ball_13, V.Undef, GetIdx(p_5053, 0D), GetIdx(p_5053, 1D), GetIdx(p_5053, 2D), ((V)(1.1)), ((V)((NumTruthy((ToNum(i_5042) % 2D)) ? "#f6c2d0" : "#fbe4ea"))), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(9D))).Put("sy", ((V)(0.8))).V), Call(ball_13, V.Undef, GetIdx(p_5053, 0D), Add(GetIdx(p_5053, 1D), ((V)(0.75))), Add(GetIdx(p_5053, 2D), ((V)(0.2))), ((V)(0.35)), ((V)("#c83a6a")), NewObj(2).Put("k", ((V)(2D))).Put("n", ((V)(6D))).V))));
return default;
}, 2, "", true));
P2b_4925 = Arr(Arr(((V)((VX_4883 + 0.9))), ((V)(y0_4921)), ((V)((VZ_4884 + 0.5)))), Arr(((V)((VX_4883 + 4.2))), ((V)((y0_4921 + 4.6))), ((V)((VZ_4884 + 1.6)))), Arr(((V)((VX_4883 + 9D))), ((V)((y0_4921 + 7.2))), ((V)((VZ_4884 + 3D)))), Arr(((V)((VX_4883 + 14.4))), ((V)((y0_4921 + 6.6))), ((V)((VZ_4884 + 4D)))));
b2_4926 = Call(pipe_23, V.Undef, P2b_4925, ((V)(0.32)), ((V)("#4a5a2a")), NewObj(1).Put("n", ((V)(6D))).V);
Invoke(b2_4926, "forEach", Fn((V _arrowThis5061, int _argc5054, V s_5060, V _a5057, V _a5058, V _a5059, V[] _rest5055) => {
return Invoke(o_4916, "push", s_5060);
}, 1, "", true));
Invoke(Arr(Arr(((V)(0D)), ((V)(0.7)), ((V)(1D))), Arr(((V)(1D)), ((V)(0.3)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(0.75)), ((V)(1D))), Arr(((V)(2D)), ((V)(0.4)), ((V)((-1D)))), Arr(((V)(2D)), ((V)(0.9)), ((V)(1D)))), "forEach", Fn((V _arrowThis5076, int _argc5062, V _a5064, V i_5068, V _a5066, V _a5067, V[] _rest5063) => {
V p_5077 = default;
V si_5071 = default;
V t_5073 = default;
V sg_5075 = default;
{ V _t5069 = ListOf(_a5064);
{ V _t5070 = GetIdx(_t5069, 0D);
si_5071 = _t5070; }
{ V _t5072 = GetIdx(_t5069, 1D);
t_5073 = _t5072; }
{ V _t5074 = GetIdx(_t5069, 2D);
sg_5075 = _t5074; }
}
p_5077 = Call(add_34, V.Undef, Call(lerp_4922, V.Undef, P2b_4925, si_5071, t_5073), Arr(((V)(0D)), ((V)(0.4)), ((V)((ToNum(sg_5075) * 1.3)))));
Call(on_4917, V.Undef, GetK(b2_4926, si_5071), Arr(Call(ball_13, V.Undef, GetIdx(p_5077, 0D), GetIdx(p_5077, 1D), GetIdx(p_5077, 2D), ((V)(1.7)), ((V)((NumTruthy((ToNum(i_5068) % 2D)) ? "#3f7a34" : "#5a9a44"))), NewObj(5).Put("sx", ((V)(1.5))).Put("sy", ((V)(0.3))).Put("sz", ((V)(0.75))).Put("k", ((V)(3D))).Put("n", ((V)(9D))).V)));
return default;
}, 2, "", true));
P3_4927 = Arr(Arr(((V)((VX_4883 - 0.4))), ((V)(y0_4921)), ((V)((VZ_4884 + 1.2)))), Arr(((V)((VX_4883 - 3.6))), ((V)((y0_4921 + 2.2))), ((V)((VZ_4884 + 3.4)))), Arr(((V)((VX_4883 - 6.6))), ((V)((y0_4921 + 1.8))), ((V)((VZ_4884 + 5.2)))));
b3_4928 = Call(pipe_23, V.Undef, P3_4927, ((V)(0.32)), ((V)("#3f6a2e")), NewObj(1).Put("n", ((V)(6D))).V);
Invoke(b3_4928, "forEach", Fn((V _arrowThis5085, int _argc5078, V s_5084, V _a5081, V _a5082, V _a5083, V[] _rest5079) => {
return Invoke(o_4916, "push", s_5084);
}, 1, "", true));
{
V fc_5086 = default;
fc_5086 = Arr(((V)((VX_4883 - 7.6))), ((V)((y0_4921 + 2.2))), ((V)((VZ_4884 + 5.8))));
Call(on_4917, V.Undef, GetIdx(b3_4928, 1D), Invoke(Arr(Call(ball_13, V.Undef, ((V)((VX_4883 - 4.6))), ((V)((y0_4921 + 2.6))), ((V)((VZ_4884 + 2.6))), ((V)(2D)), ((V)("#2f5a2a")), NewObj(5).Put("sx", ((V)(1.4))).Put("sy", ((V)(0.3))).Put("sz", ((V)(0.7))).Put("k", ((V)(3D))).Put("n", ((V)(9D))).V), Call(ball_13, V.Undef, ((V)((VX_4883 - 5.4))), ((V)((y0_4921 + 2.4))), ((V)((VZ_4884 + 6.4))), ((V)(1.8)), ((V)("#2f5a2a")), NewObj(5).Put("sx", ((V)(1.3))).Put("sy", ((V)(0.3))).Put("sz", ((V)(0.7))).Put("k", ((V)(3D))).Put("n", ((V)(9D))).V), Call(ball_13, V.Undef, GetIdx(fc_5086, 0D), GetIdx(fc_5086, 1D), GetIdx(fc_5086, 2D), ((V)(2.2)), ((V)("#b81e34")), NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)), "concat", Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis5094, int _argc5087, V i_5093, V _a5090, V _a5091, V _a5092, V[] _rest5088) => {
double a_5095 = 0;
a_5095 = (((ToNum(i_5093) / 5D) * 2D) * PI_17);
return Call(ball_13, V.Undef, Add(GetIdx(fc_5086, 0D), ((V)((FdLibm.Cos(a_5095) * 1.5)))), Add(GetIdx(fc_5086, 1D), ((V)(1.1))), Add(GetIdx(fc_5086, 2D), ((V)((FdLibm.Sin(a_5095) * 1.5)))), ((V)(1.2)), ((V)((NumTruthy((ToNum(i_5093) % 2D)) ? "#d8283e" : "#e8344a"))), NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(9D))).V);
return default;
}, 1, "", true)), Arr(Call(ball_13, V.Undef, GetIdx(fc_5086, 0D), Add(GetIdx(fc_5086, 1D), ((V)(1.6))), GetIdx(fc_5086, 2D), ((V)(0.7)), ((V)("#f2c230")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V))));
}
ID_4929 = Call(cyl_12, V.Undef, ((V)(IX_4886)), ((V)(TY_4882)), ((V)(IZ_4887)), ((V)(6.4)), ((V)(2.6)), ((V)("#1e1f22")), NewObj(4).Put("n", ((V)(28D))).Put("mat", ((V)("cer"))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.78))), Arr(((V)(0.8)), ((V)(0D)), ((V)(0.92))), Arr(((V)(2.6)), ((V)(0D)), ((V)(1D))))).V);
Invoke(o_4916, "push", ID_4929);
{
double yT_5096 = 0;
V SD_5097 = default;
V RK_5098 = default;
V AS_5099 = default;
V RM_5100 = default;
V GL2_5101 = default;
V sx_5102 = default;
V sz_5103 = default;
yT_5096 = (TY_4882 + 2.6);
SD_5097 = Call(dec_44, V.Undef, ((V)("#d9ceb3")));
RK_5098 = Call(dec_44, V.Undef, ((V)("#b3a586")), NewObj(1).Put("op", ((V)(0.9))).V);
AS_5099 = Call(dec_44, V.Undef, ((V)("#8a8580")), NewObj(1).Put("op", ((V)(0.8))).V);
RM_5100 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.22))).V);
GL2_5101 = Call(dec_44, V.Undef, ((V)("#c9a66a")), NewObj(1).Put("op", ((V)(0.5))).V);
sx_5102 = GetIdx(sb_4889, 0D);
sz_5103 = GetIdx(sb_4889, 2D);
Invoke(SD_5097, "poly", Call(elP_45, V.Undef, Arr(((V)(IX_4886)), ((V)(yT_5096)), ((V)(IZ_4887))), X3_39, Z3_41, ((V)(5.6)), ((V)(5.6)), ((V)(28D))), Y3_40);
Invoke(Arr(((V)(1.2)), ((V)(2.2)), ((V)(3.2))), "forEach", Fn((V _arrowThis5111, int _argc5104, V r_5110, V _a5107, V _a5108, V _a5109, V[] _rest5105) => {
return Call(ringY_51, V.Undef, RK_5098, sx_5102, sz_5103, r_5110, ((V)(yT_5096)), ((V)(0.16)), ((V)(28D)));
}, 1, "", true));
Invoke(Arr(((V)(4.1)), ((V)(4.7)), ((V)((-4.3)))), "forEach", Fn((V _arrowThis5119, int _argc5112, V dz_5118, V _a5115, V _a5116, V _a5117, V[] _rest5113) => {
double h_5120 = 0;
h_5120 = System.Math.Sqrt(Max(0D, ((5.3 * 5.3) - (ToNum(dz_5118) * ToNum(dz_5118)))));
Call(seg_56, V.Undef, RK_5098, Arr(((V)((IX_4886 - h_5120))), ((V)(yT_5096)), Add(((V)(IZ_4887)), dz_5118)), Arr(((V)((IX_4886 + h_5120))), ((V)(yT_5096)), Add(((V)(IZ_4887)), dz_5118)), Y3_40, ((V)(0.16)));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)(0.7)), ((V)(0.4))), Arr(((V)((-0.5))), ((V)(0.8))), Arr(((V)(0.3)), ((V)((-0.7))))), "forEach", Fn((V _arrowThis5132, int _argc5121, V _a5123, V _a5124, V _a5125, V _a5126, V[] _rest5122) => {
V dx_5129 = default;
V dz_5131 = default;
{ V _t5127 = ListOf(_a5123);
{ V _t5128 = GetIdx(_t5127, 0D);
dx_5129 = _t5128; }
{ V _t5130 = GetIdx(_t5127, 1D);
dz_5131 = _t5130; }
}
return Call(spot_46, V.Undef, AS_5099, Arr(Add(sx_5102, dx_5129), ((V)(yT_5096)), Add(sz_5103, dz_5131)), Y3_40, ((V)(0.3)), ((V)(0.2)), dx_5129, ((V)(6D)));
}, 1, "", true));
Call(ringY_51, V.Undef, RM_5100, ((V)(IX_4886)), ((V)(IZ_4887)), ((V)(6.25)), ((V)(yT_5096)), ((V)(0.25)), ((V)(40D)));
Call(ringC_52, V.Undef, GL2_5101, ((V)(IX_4886)), ((V)(IZ_4887)), ((V)(6.3)), ((V)((TY_4882 + 2.2))), ((V)(0.16)), ((V)(40D)));
Call(on_4917, V.Undef, ID_4929, Invoke(Arr(SD_5097, RK_5098, AS_5099, RM_5100, GL2_5101, Call(rod_22, V.Undef, Call(sp_4891, V.Undef, ((V)(0D))), Call(sp_4891, V.Undef, ((V)(0.12))), ((V)(0.14)), ((V)("#d8c0a0")), NewObj(1).Put("n", ((V)(4D))).V), Call(rod_22, V.Undef, Call(sp_4891, V.Undef, ((V)(0.12))), Call(sp_4891, V.Undef, ((V)(0.93))), ((V)(0.24)), ((V)("#6a2f22")), NewObj(1).Put("n", ((V)(5D))).V), Call(rod_22, V.Undef, Call(sp_4891, V.Undef, ((V)(0.93))), Call(sp_4891, V.Undef, ((V)(0.98))), ((V)(0.26)), ((V)("#ff6a2a")), Call(em_3984, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)), CallSpread(ball_13, V.Undef, new ArrBuilder().Spread(Call(sp_4891, V.Undef, ((V)(0.955)))).Add(((V)(0.33))).Add(((V)("#ff8a3a"))).Add(Call(em_3984, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V)).V)), "concat", Call(pipe_23, V.Undef, Arr(Call(sp_4891, V.Undef, ((V)(0.98))), Call(add_34, V.Undef, Call(sp_4891, V.Undef, ((V)(1D))), Arr(((V)(0.4)), ((V)(0.4)), ((V)(0D)))), Call(add_34, V.Undef, Call(sp_4891, V.Undef, ((V)(1D))), Arr(((V)(0.9)), ((V)(0.45)), ((V)(0D))))), ((V)(0.2)), ((V)("#a8a39c")), NewObj(1).Put("n", ((V)(5D))).V)));
}
IB_4930 = Call(box_11, V.Undef, ((V)(15D)), ((V)(TY_4882)), ((V)((-9D))), ((V)(12D)), ((V)(2.4)), ((V)(4.4)), ((V)("#d8b88a")), Call(W__25, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V));
Invoke(o_4916, "push", IB_4930);
{
V G_5133 = default;
V LBL_5134 = default;
V SP_5135 = default;
V TX_5136 = default;
double yT_5137 = 0;
G_5133 = Call(dec_44, V.Undef, ((V)("#b8935e")), NewObj(1).Put("op", ((V)(0.6))).V);
LBL_5134 = Call(dec_44, V.Undef, ((V)("#f4ead8")));
SP_5135 = Call(dec_44, V.Undef, ((V)("#c8303a")));
TX_5136 = Call(dec_44, V.Undef, ((V)("#3a2a22")), NewObj(1).Put("op", ((V)(0.85))).V);
yT_5137 = (TY_4882 + 2.4);
Call(rep_28, V.Undef, ((V)(4D)), Fn((V _arrowThis5145, int _argc5138, V k_5144, V _a5141, V _a5142, V _a5143, V[] _rest5139) => {
return Invoke(G_5133, "line", Call(wv_43, V.Undef, ((V)(12D)), Fn((V _arrowThis5153, int _argc5146, V t_5152, V _a5149, V _a5150, V _a5151, V[] _rest5147) => {
return Arr(((V)((9.2 + (ToNum(t_5152) * 11.6)))), ((V)(yT_5137)), ((V)((((-10.7) + (ToNum(k_5144) * 1.1)) + (0.15 * FdLibm.Sin(ToNum(Add(((V)((ToNum(t_5152) * 9D))), k_5144))))))));
}, 1, "", true)), Y3_40, ((V)(0.12)));
}, 1, "", true));
Invoke(LBL_5134, "poly", Arr(Arr(((V)(11D)), ((V)(yT_5137)), ((V)((-10.4)))), Arr(((V)(15.4)), ((V)(yT_5137)), ((V)((-10.4)))), Arr(((V)(15.4)), ((V)(yT_5137)), ((V)((-7.6)))), Arr(((V)(11D)), ((V)(yT_5137)), ((V)((-7.6))))), Y3_40);
Invoke(SP_5135, "poly", Call(elP_45, V.Undef, Arr(((V)(16.8)), ((V)(yT_5137)), ((V)((-9D)))), X3_39, Z3_41, ((V)(0.9)), ((V)(0.9)), ((V)(12D))), Y3_40);
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis5161, int _argc5154, V k_5160, V _a5157, V _a5158, V _a5159, V[] _rest5155) => {
return Call(seg_56, V.Undef, TX_5136, Arr(((V)(11.6)), ((V)(yT_5137)), ((V)(((-9.9) + (ToNum(k_5160) * 0.85))))), Arr(((V)((14.8 - ((ToNum(k_5160) % 2D) * 1.2)))), ((V)(yT_5137)), ((V)(((-9.9) + (ToNum(k_5160) * 0.85))))), Y3_40, ((V)(0.22)));
}, 1, "", true));
Call(on_4917, V.Undef, IB_4930, Invoke(Arr(G_5133, LBL_5134, SP_5135, TX_5136), "concat", Call(rep_28, V.Undef, ((V)(4D)), Fn((V _arrowThis5169, int _argc5162, V k_5168, V _a5165, V _a5166, V _a5167, V[] _rest5163) => {
return Call(rod_22, V.Undef, Arr(((V)(21D)), ((V)(((TY_4882 + 0.8) + ((ToNum(k_5168) % 2D) * 0.7)))), ((V)(((-10D) + (ToNum(k_5168) * 0.6))))), Arr(((V)(23.4)), ((V)(((TY_4882 + 0.8) + ((ToNum(k_5168) % 2D) * 0.7)))), ((V)(((-10.1) + (ToNum(k_5168) * 0.62))))), ((V)(0.22)), ((V)("#7a3a2a")), NewObj(1).Put("n", ((V)(4D))).V);
}, 1, "", true))));
}
Invoke(Arr(Arr(((V)(0.5)), ((V)(3.2)), ((V)(0.47)), ((V)("#8a8580"))), Arr(((V)(0.8)), ((V)(2.4)), ((V)(0.48)), ((V)("#a39e96"))), Arr(((V)(0.6)), ((V)(1.7)), ((V)(0.5)), ((V)("#6f6a64")))), "reduce", Fn((V _arrowThis5187, int _argc5170, V y_5176, V _a5173, V i_5177, V _a5175, V[] _rest5171) => {
double h_5188 = 0;
double z_5189 = 0;
V c_5190 = default;
V S1_5191 = default;
V HL_5192 = default;
V FK_5193 = default;
V p_5194 = default;
V n_5195 = default;
V x_5180 = default;
V r_5182 = default;
V sy_5184 = default;
V col_5186 = default;
{ V _t5178 = ListOf(_a5173);
{ V _t5179 = GetIdx(_t5178, 0D);
x_5180 = _t5179; }
{ V _t5181 = GetIdx(_t5178, 1D);
r_5182 = _t5181; }
{ V _t5183 = GetIdx(_t5178, 2D);
sy_5184 = _t5183; }
{ V _t5185 = GetIdx(_t5178, 3D);
col_5186 = _t5185; }
}
h_5188 = (ToNum(r_5182) * ToNum(sy_5184));
z_5189 = (9D - (ToNum(i_5177) * 0.15));
c_5190 = Arr(x_5180, Add(y_5176, ((V)(h_5188))), ((V)(z_5189)));
S1_5191 = Call(ball_13, V.Undef, x_5180, Add(y_5176, ((V)(h_5188))), ((V)(z_5189)), r_5182, col_5186, NewObj(3).Put("sy", sy_5184).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V);
Invoke(o_4916, "push", S1_5191);
HL_5192 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.45))).V);
FK_5193 = Call(dec_44, V.Undef, Call(shade_14, V.Undef, col_5186, ((V)(0.7))), NewObj(1).Put("op", ((V)(0.7))).V);
{ V _t5196 = Call(elS_4002, V.Undef, c_5190, r_5182, ((V)(h_5188)), r_5182, Arr(((V)((-0.35))), ((V)(1D)), ((V)((-0.3)))));
{ V _t5197 = ListOf(_t5196);
{ V _t5198 = GetIdx(_t5197, 0D);
p_5194 = _t5198; }
{ V _t5199 = GetIdx(_t5197, 1D);
n_5195 = _t5199; }
} }
Call(spot_46, V.Undef, HL_5192, p_5194, n_5195, ((V)((ToNum(r_5182) * 0.3))), ((V)((ToNum(r_5182) * 0.16))), ((V)(0.5)), ((V)(8D)));
Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis5206, int _argc5200, V _a5202, V _a5203, V _a5204, V _a5205, V[] _rest5201) => {
{ V _t5207 = Call(elS_4002, V.Undef, c_5190, r_5182, ((V)(h_5188)), r_5182, Arr(((V)(((ToNum(Call(R_4918, V.Undef)) - 0.5) * 2D))), Add(((V)(0.3)), Call(R_4918, V.Undef)), ((V)(((ToNum(Call(R_4918, V.Undef)) - 0.3) * 2D)))));
{ V _t5208 = ListOf(_t5207);
{ V _t5209 = GetIdx(_t5208, 0D);
p_5194 = _t5209; }
{ V _t5210 = GetIdx(_t5208, 1D);
n_5195 = _t5210; }
} }
Call(spot_46, V.Undef, FK_5193, p_5194, n_5195, ((V)((0.12 + (ToNum(Call(R_4918, V.Undef)) * 0.14)))), ((V)((0.1 + (ToNum(Call(R_4918, V.Undef)) * 0.08)))), ((V)((ToNum(Call(R_4918, V.Undef)) * 3D))), ((V)(5D)));
return default;
}, 0, "", true));
Call(on_4917, V.Undef, S1_5191, Arr(FK_5193, HL_5192));
return Add(y_5176, ((V)((2D * h_5188))));
return default;
}, 3, "", true), ((V)(TY_4882)));
KB_4931 = Call(ball_13, V.Undef, ((V)((-20D))), ((V)((TY_4882 + 3D))), ((V)(8D)), ((V)(3D)), ((V)("#4f7a3a")), NewObj(3).Put("k", ((V)(5D))).Put("n", ((V)(14D))).Put("mat", ((V)("fab"))).V);
Invoke(o_4916, "push", KB_4931);
{
V c_5211 = default;
V TW_5212 = default;
V M1_5213 = default;
V M2_5214 = default;
c_5211 = Arr(((V)((-20D))), ((V)((TY_4882 + 3D))), ((V)(8D)));
TW_5212 = Call(dec_44, V.Undef, ((V)("#b89a6a")), NewObj(1).Put("op", ((V)(0.9))).V);
M1_5213 = Call(dec_44, V.Undef, ((V)("#6f9a4a")), NewObj(1).Put("op", ((V)(0.7))).V);
M2_5214 = Call(dec_44, V.Undef, ((V)("#2f5a26")), NewObj(1).Put("op", ((V)(0.6))).V);
Invoke(Arr(((V)(0.4)), ((V)(1.5)), ((V)(2.6))), "forEach", Fn((V _arrowThis5222, int _argc5215, V ph_5221, V _a5218, V _a5219, V _a5220, V[] _rest5216) => {
V Q_5223 = default;
Q_5223 = Call(wv_43, V.Undef, ((V)(24D)), Fn((V _arrowThis5231, int _argc5224, V t_5230, V _a5227, V _a5228, V _a5229, V[] _rest5225) => {
double a_5232 = 0;
V d_5233 = default;
a_5232 = ((ToNum(t_5230) * 2D) * PI_17);
d_5233 = Arr(((V)((FdLibm.Cos(a_5232) * FdLibm.Cos(ToNum(ph_5221))))), ((V)(FdLibm.Sin(a_5232))), ((V)((FdLibm.Cos(a_5232) * FdLibm.Sin(ToNum(ph_5221))))));
return Arr(Call(add_34, V.Undef, c_5211, Call(mul_36, V.Undef, d_5233, ((V)(3.02)))), d_5233);
return default;
}, 1, "", true));
Invoke(TW_5212, "line", Invoke(Q_5223, "map", Fn((V _arrowThis5241, int _argc5234, V q_5240, V _a5237, V _a5238, V _a5239, V[] _rest5235) => {
return GetIdx(q_5240, 0D);
}, 1, "", true)), Invoke(Q_5223, "map", Fn((V _arrowThis5249, int _argc5242, V q_5248, V _a5245, V _a5246, V _a5247, V[] _rest5243) => {
return GetIdx(q_5248, 1D);
}, 1, "", true)), ((V)(0.14)));
return default;
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(30D)), Fn((V _arrowThis5256, int _argc5250, V _a5252, V _a5253, V _a5254, V _a5255, V[] _rest5251) => {
V d_5257 = default;
d_5257 = Call(nz_38, V.Undef, Arr(((V)(((ToNum(Call(R_4918, V.Undef)) - 0.5) * 2D))), ((V)(((ToNum(Call(R_4918, V.Undef)) * 1.4) - 0.2))), ((V)(((ToNum(Call(R_4918, V.Undef)) - 0.5) * 2D)))));
Call(spot_46, V.Undef, (LtN(Call(R_4918, V.Undef), 0.5) ? M1_5213 : M2_5214), Call(add_34, V.Undef, c_5211, Call(mul_36, V.Undef, d_5257, ((V)(3D)))), d_5257, ((V)(0.25)), ((V)(0.18)), ((V)((ToNum(Call(R_4918, V.Undef)) * 3D))), ((V)(5D)));
return default;
}, 0, "", true));
Call(on_4917, V.Undef, KB_4931, Invoke(Arr(M1_5213, M2_5214, TW_5212), "concat", Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis5265, int _argc5258, V i_5264, V _a5261, V _a5262, V _a5263, V[] _rest5259) => {
double a_5266 = 0;
a_5266 = (ToNum(i_5264) * 2.1);
return Call(ball_13, V.Undef, ((V)(((-20D) + (FdLibm.Cos(a_5266) * 0.8)))), ((V)((TY_4882 + 6.3))), ((V)((8D + (FdLibm.Sin(a_5266) * 0.8)))), ((V)(0.9)), ((V)("#7ab84a")), NewObj(4).Put("sx", ((V)(1.4))).Put("sy", ((V)(0.35))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
return default;
}, 1, "", true))));
}
return o_4916;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis5274, int _argc5267, V c_5273, V _a5270, V _a5271, V _a5272, V[] _rest5268) => {
V q_5275 = default;
V k_5276 = default;
V g_5277 = default;
V sm_5278 = default;
q_5275 = Invoke(c_5273, "p", GetIdx(TIP_4892, 0D), GetIdx(TIP_4892, 1D), GetIdx(TIP_4892, 2D));
k_5276 = Get(c_5273, "k");
g_5277 = Invoke(c_5273, "p", ((V)((VX_4883 - 3D))), ((V)((TY_4882 + 10D))), ((V)((VZ_4884 + 5D))));
sm_5278 = ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_3991, V.Undef, q_5275)).S(") scale(").V(Call(f1_3980, V.Undef, k_5276)).S(")\"><g><animateTransform attributeName=\"transform\" type=\"skewX\" values=\"0;7;-5;3;0\" dur=\"6s\" repeatCount=\"indefinite\"/><path d=\"M0 0C-1.5 -4 1.8 -7 0.4 -11S-1.6 -18 0.8 -22S2.6 -28 0.2 -32\" fill=\"none\" stroke=\"url(#q25sm)\" stroke-width=\"0.55\" stroke-linecap=\"round\" stroke-dasharray=\"6 2.4\">").V(Call(an_3983, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-16.8")), ((V)(3.2)))).S("</path><path d=\"M0.2 -6C2 -10 -1 -14 1.4 -19S0 -26 2.2 -30\" fill=\"none\" stroke=\"url(#q25sm)\" stroke-width=\"0.3\" opacity=\"0.7\"/></g></g>").End()));
return NewObj(2).Put("defs", ((V)("<linearGradient id=\"q25sm\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"-32\"><stop offset=\"0\" stop-color=\"#ece8e0\" stop-opacity=\"0.8\"/><stop offset=\"1\" stop-color=\"#ece8e0\" stop-opacity=\"0\"/></linearGradient>"))).Put("front", ((V)(JsStrBuf.Begin().V(sm_5278).S("<ellipse cx=\"").V(Call(f1_3980, V.Undef, GetIdx(g_5277, 0D))).S("\" cy=\"").V(Call(f1_3980, V.Undef, GetIdx(g_5277, 1D))).S("\" rx=\"").V(Call(f1_3980, V.Undef, ((V)((0.7 * ToNum(k_5276)))))).S("\" ry=\"").V(Call(f1_3980, V.Undef, ((V)((6D * ToNum(k_5276)))))).S("\" fill=\"#ffffff\" opacity=\"0.3\">").V(Call(an_3983, V.Undef, ((V)("opacity")), ((V)("0.1;0.55;0.1")), ((V)(5D)))).S("</ellipse>").End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_16, "chrono25", Fn((V _arrowThis5286, int _argc5279, V S_5285, V _a5282, V _a5283, V _a5284, V[] _rest5280) => {
V B_5287 = default;
V L0_5288 = default;
B_5287 = Invoke(N_16, "chrono", S_5285);
L0_5288 = GetIdx(Get(B_5287, "layers"), 0D);
return Object_assign(NewObj(0).V, B_5287, NewObj(3).Put("fx", Fn((V _arrowThis5296, int _argc5289, V c_5295, V _a5292, V _a5293, V _a5294, V[] _rest5290) => {
V F_5297 = default;
F_5297 = Object_assign(NewObj(0).V, Invoke(B_5287, "fx", c_5295));
if (LtN(Call(face_3981, V.Undef, c_5295, ((V)(0D)), ((V)(1D))), 0.05)) {
Set(F_5297, "front", Invoke(Get(F_5297, "front"), "replace", NewRegExp(RX0, "^<g transform=\"translate\\([^\"]*\\) scale\\([^\"]*\\)\">.*?<\\/g>", ""), ((V)(""))));
}
return F_5297;
return default;
}, 1, "fx", true)).Put("build", Fn((V _arrowThis5305, int _argc5298, V P_5304, V _a5301, V _a5302, V _a5303, V[] _rest5299) => {
V o_5306 = default;
V on_5307 = default;
V R_5308 = default;
V MT_5309 = default;
V CEN_5310 = default;
V M0_5311 = default;
V c0_5312 = default;
V BS_5313 = default;
V ST_5314 = default;
V PN_5315 = default;
o_5306 = Invoke(B_5287, "build", P_5304);
on_5307 = Call(glue_31, V.Undef, o_5306);
R_5308 = Call(R0_30, V.Undef, ((V)("chrono25")));
MT_5309 = Invoke(o_5306, "filter", Fn((V _arrowThis5323, int _argc5316, V S1_5322, V _a5319, V _a5320, V _a5321, V[] _rest5317) => {
return (((SEqS(Get(S1_5322, "col"), "#4b4a4c") || SEqS(Get(S1_5322, "col"), "#2e2d30")) && !(Truthy(Get(S1_5322, "par")))) ? V.True : V.False);
}, 1, "", true));
CEN_5310 = Fn((V _arrowThis5331, int _argc5324, V S1_5330, V _a5327, V _a5328, V _a5329, V[] _rest5325) => {
V L_5332 = default;
L_5332 = Call(bb_48, V.Undef, S1_5330);
return Arr(((V)((ToNum(Add(GetIdx(L_5332, 0D), GetIdx(L_5332, 1D))) / 2D))), ((V)((ToNum(Add(GetIdx(L_5332, 2D), GetIdx(L_5332, 3D))) / 2D))), ((V)((ToNum(Add(GetIdx(L_5332, 4D), GetIdx(L_5332, 5D))) / 2D))));
return default;
}, 1, "", true);
M0_5311 = GetIdx(MT_5309, 0D);
c0_5312 = (M0_5311 is var _t5333 && !Truthy(_t5333) ? _t5333 : Call(CEN_5310, V.Undef, M0_5311));
if (Truthy(M0_5311)) {
Invoke(Invoke(MT_5309, "slice", ((V)(1D))), "forEach", Fn((V _arrowThis5341, int _argc5334, V S1_5340, V _a5337, V _a5338, V _a5339, V[] _rest5335) => {
V d_5342 = default;
d_5342 = Call(sub_35, V.Undef, Call(CEN_5310, V.Undef, S1_5340), c0_5312);
Set(S1_5340, "par", M0_5311);
if ((Hypot(ToNum(GetIdx(d_5342, 0D)), ToNum(GetIdx(d_5342, 1D)), ToNum(GetIdx(d_5342, 2D))) > 0.5)) {
Set(S1_5340, "fn", Call(nz_38, V.Undef, d_5342));
}
return default;
}, 1, "", true));
}
{
V PNo_5343 = default;
V STo_5344 = default;
PNo_5343 = Invoke(o_5306, "find", Fn((V _arrowThis5352, int _argc5345, V S1_5351, V _a5348, V _a5349, V _a5350, V[] _rest5346) => {
return ((SEqS(Get(S1_5351, "col"), "#9aa3a8") && !(Truthy(Get(S1_5351, "par")))) ? V.True : V.False);
}, 1, "", true));
STo_5344 = Invoke(o_5306, "find", Fn((V _arrowThis5360, int _argc5353, V S1_5359, V _a5356, V _a5357, V _a5358, V[] _rest5354) => {
return ((SEqS(Get(S1_5359, "col"), "#3a2416") && !(Truthy(Get(S1_5359, "par")))) ? V.True : V.False);
}, 1, "", true));
if (Truthy((PNo_5343 is var _t5361 && !Truthy(_t5361) ? _t5361 : STo_5344))) {
Set(PNo_5343, "par", STo_5344);
}
}
BS_5313 = Call(at_49, V.Undef, o_5306, Arr(((V)((-12D))), ((V)(2.5)), ((V)(0D))), ((V)("#16161a")));
ST_5314 = Call(at_49, V.Undef, o_5306, Arr(((V)(15D)), ((V)(1.5)), ((V)(0D))), ((V)("#3a2416")));
PN_5315 = Call(at_49, V.Undef, o_5306, Arr(((V)(15D)), ((V)(5D)), ((V)(0D))), ((V)("#9aa3a8")), ((V)(0.6)), ((V)(1D)));
if (Truthy(BS_5313)) {
double yT_5362 = 0;
V IN_5363 = default;
V TK_5364 = default;
V SH_5365 = default;
V RP_5366 = default;
V GL_5367 = default;
double x0_5368 = 0;
double x1_5369 = 0;
double z0_5370 = 0;
double z1_5371 = 0;
V PQ_5372 = default;
V EN_5373 = default;
yT_5362 = 5D;
IN_5363 = Call(dec_44, V.Undef, BR_18, NewObj(1).Put("op", ((V)(0.95))).V);
TK_5364 = Call(dec_44, V.Undef, ((V)("#c9a24a")), NewObj(1).Put("op", ((V)(0.9))).V);
SH_5365 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.07))).V);
RP_5366 = Call(dec_44, V.Undef, ((V)("#3a3a44")), NewObj(1).Put("op", ((V)(0.6))).V);
GL_5367 = Call(dec_44, V.Undef, ((V)("#6ac8ff")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.85))).V);
x0_5368 = (-24.3);
x1_5369 = 0.3;
z0_5370 = (-9.3);
z1_5371 = 9.3;
Invoke(Arr(Arr(((V)(x0_5368)), ((V)(z0_5370)), ((V)(x1_5369)), ((V)(z0_5370))), Arr(((V)(x1_5369)), ((V)(z0_5370)), ((V)(x1_5369)), ((V)(z1_5371))), Arr(((V)(x1_5369)), ((V)(z1_5371)), ((V)(x0_5368)), ((V)(z1_5371))), Arr(((V)(x0_5368)), ((V)(z1_5371)), ((V)(x0_5368)), ((V)(z0_5370)))), "forEach", Fn((V _arrowThis5389, int _argc5374, V _a5376, V _a5377, V _a5378, V _a5379, V[] _rest5375) => {
V a_5382 = default;
V b_5384 = default;
V c2_5386 = default;
V d_5388 = default;
{ V _t5380 = ListOf(_a5376);
{ V _t5381 = GetIdx(_t5380, 0D);
a_5382 = _t5381; }
{ V _t5383 = GetIdx(_t5380, 1D);
b_5384 = _t5383; }
{ V _t5385 = GetIdx(_t5380, 2D);
c2_5386 = _t5385; }
{ V _t5387 = GetIdx(_t5380, 3D);
d_5388 = _t5387; }
}
return Call(seg_56, V.Undef, IN_5363, Arr(a_5382, ((V)(yT_5362)), b_5384), Arr(c2_5386, ((V)(yT_5362)), d_5388), Y3_40, ((V)(0.3)));
}, 1, "", true));
Invoke(Arr(Arr(((V)(x0_5368)), ((V)(z0_5370))), Arr(((V)(x1_5369)), ((V)(z0_5370))), Arr(((V)(x0_5368)), ((V)(z1_5371))), Arr(((V)(x1_5369)), ((V)(z1_5371)))), "forEach", Fn((V _arrowThis5401, int _argc5390, V _a5392, V _a5393, V _a5394, V _a5395, V[] _rest5391) => {
V x_5398 = default;
V z_5400 = default;
{ V _t5396 = ListOf(_a5392);
{ V _t5397 = GetIdx(_t5396, 0D);
x_5398 = _t5397; }
{ V _t5399 = GetIdx(_t5396, 1D);
z_5400 = _t5399; }
}
return Call(spot_46, V.Undef, IN_5363, Arr(x_5398, ((V)(yT_5362)), z_5400), Y3_40, ((V)(0.45)), ((V)(0.45)), ((V)(0D)), ((V)(8D)));
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(48D)), Fn((V _arrowThis5409, int _argc5402, V i_5408, V _a5405, V _a5406, V _a5407, V[] _rest5403) => {
double a_5410 = 0;
double l_5411 = 0;
double r0_5412 = 0;
a_5410 = (((ToNum(i_5408) / 48D) * 2D) * PI_17);
l_5411 = (NumTruthy((ToNum(i_5408) % 4D)) ? 0.4 : 0.8);
r0_5412 = 8.4;
Call(seg_56, V.Undef, TK_5364, Arr(((V)(((-12D) + (FdLibm.Cos(a_5410) * r0_5412)))), ((V)(yT_5362)), ((V)((FdLibm.Sin(a_5410) * r0_5412)))), Arr(((V)(((-12D) + (FdLibm.Cos(a_5410) * (r0_5412 + l_5411))))), ((V)(yT_5362)), ((V)((FdLibm.Sin(a_5410) * (r0_5412 + l_5411))))), Y3_40, ((V)((NumTruthy((ToNum(i_5408) % 4D)) ? 0.1 : 0.2))));
return default;
}, 1, "", true));
Invoke(SH_5365, "poly", Arr(Arr(((V)((-24D))), ((V)(yT_5362)), ((V)((-2D)))), Arr(((V)((-18D))), ((V)(yT_5362)), ((V)((-9.4)))), Arr(((V)((-14.6))), ((V)(yT_5362)), ((V)((-9.4)))), Arr(((V)((-20.6))), ((V)(yT_5362)), ((V)((-2D))))), Y3_40);
Invoke(SH_5365, "poly", Arr(Arr(((V)((-6D))), ((V)(yT_5362)), ((V)(9.4))), Arr(((V)(0D)), ((V)(yT_5362)), ((V)(2D))), Arr(((V)(0.2)), ((V)(yT_5362)), ((V)(4.4))), Arr(((V)((-3.6))), ((V)(yT_5362)), ((V)(9.4)))), Y3_40);
Invoke(Arr(((V)(2.2)), ((V)(3.2)), ((V)(4.2))), "forEach", Fn((V _arrowThis5420, int _argc5413, V r_5419, V _a5416, V _a5417, V _a5418, V[] _rest5414) => {
return Invoke(RP_5366, "line", Call(wv_43, V.Undef, ((V)(10D)), Fn((V _arrowThis5428, int _argc5421, V t_5427, V _a5424, V _a5425, V _a5426, V[] _rest5422) => {
double a_5429 = 0;
a_5429 = (PI_17 + ((ToNum(t_5427) * PI_17) / 2D));
return Arr(((V)(((-24D) + ((FdLibm.Cos(a_5429) * (-ToNum(r_5419))) * 0.9)))), ((V)(yT_5362)), ((V)((9D + (FdLibm.Sin(a_5429) * ToNum(r_5419))))));
return default;
}, 1, "", true)), Y3_40, ((V)(0.08)));
}, 1, "", true));
Invoke(Arr(Arr(Z3_41, ((V)(10D)), ((V)(1D))), Arr(Call(mul_36, V.Undef, Z3_41, ((V)((-1D)))), ((V)((-10D))), ((V)(1D)))), "forEach", Fn((V _arrowThis5441, int _argc5430, V _a5432, V _a5433, V _a5434, V _a5435, V[] _rest5431) => {
V n_5438 = default;
V z_5440 = default;
{ V _t5436 = ListOf(_a5432);
{ V _t5437 = GetIdx(_t5436, 0D);
n_5438 = _t5437; }
{ V _t5439 = GetIdx(_t5436, 1D);
z_5440 = _t5439; }
}
Call(seg_56, V.Undef, IN_5363, Arr(((V)((-23D))), ((V)(4.2)), z_5440), Arr(((V)((-1D))), ((V)(4.2)), z_5440), n_5438, ((V)(0.25)));
Call(seg_56, V.Undef, GL_5367, Arr(((V)((-22D))), ((V)(0.4)), z_5440), Arr(((V)((-2D))), ((V)(0.4)), z_5440), n_5438, ((V)(0.35)));
return default;
}, 1, "", true));
Invoke(Arr(Arr(X3_39, ((V)(1D))), Arr(Call(mul_36, V.Undef, X3_39, ((V)((-1D)))), ((V)((-25D))))), "forEach", Fn((V _arrowThis5453, int _argc5442, V _a5444, V _a5445, V _a5446, V _a5447, V[] _rest5443) => {
V n_5450 = default;
V x_5452 = default;
{ V _t5448 = ListOf(_a5444);
{ V _t5449 = GetIdx(_t5448, 0D);
n_5450 = _t5449; }
{ V _t5451 = GetIdx(_t5448, 1D);
x_5452 = _t5451; }
}
return Call(seg_56, V.Undef, IN_5363, Arr(x_5452, ((V)(4.2)), ((V)((-8D)))), Arr(x_5452, ((V)(4.2)), ((V)(8D))), n_5450, ((V)(0.25)));
}, 1, "", true));
Call(on_5307, V.Undef, BS_5313, Arr(SH_5365, RP_5366, IN_5363, TK_5364, GL_5367));
PQ_5372 = GetIdx(Call(on_5307, V.Undef, BS_5313, Arr(Call(box_11, V.Undef, ((V)((-12D))), ((V)(1.1)), ((V)(10D)), ((V)(10D)), ((V)(2.6)), ((V)(0.32)), BR_18, Call(M__24, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V))), Z3_41), 0D);
EN_5373 = Call(dec_44, V.Undef, ((V)("#5a4214")), NewObj(1).Put("op", ((V)(0.85))).V);
Call(seg_56, V.Undef, EN_5373, Arr(((V)((-15.6))), ((V)(2.9)), ((V)(10.18))), Arr(((V)((-8.4))), ((V)(2.9)), ((V)(10.18))), Z3_41, ((V)(0.26)));
Call(seg_56, V.Undef, EN_5373, Arr(((V)((-14.6))), ((V)(2.1)), ((V)(10.18))), Arr(((V)((-9.4))), ((V)(2.1)), ((V)(10.18))), Z3_41, ((V)(0.16)));
Invoke(Arr(Arr(((V)((-16.4))), ((V)(1.6))), Arr(((V)((-7.6))), ((V)(1.6))), Arr(((V)((-16.4))), ((V)(3.2))), Arr(((V)((-7.6))), ((V)(3.2)))), "forEach", Fn((V _arrowThis5465, int _argc5454, V _a5456, V _a5457, V _a5458, V _a5459, V[] _rest5455) => {
V x_5462 = default;
V y_5464 = default;
{ V _t5460 = ListOf(_a5456);
{ V _t5461 = GetIdx(_t5460, 0D);
x_5462 = _t5461; }
{ V _t5463 = GetIdx(_t5460, 1D);
y_5464 = _t5463; }
}
return Call(spot_46, V.Undef, EN_5373, Arr(x_5462, y_5464, ((V)(10.18))), Z3_41, ((V)(0.2)), ((V)(0.2)), ((V)(0D)), ((V)(6D)));
}, 1, "", true));
Call(on_5307, V.Undef, PQ_5372, Arr(EN_5373));
}
if (Truthy(ST_5314)) {
double yT_5466 = 0;
V G1_5467 = default;
V G2_5468 = default;
V HLs_5469 = default;
V PL3_5470 = default;
V EN_5471 = default;
yT_5466 = 3D;
G1_5467 = Call(dec_44, V.Undef, ((V)("#24160c")), NewObj(1).Put("op", ((V)(0.55))).V);
G2_5468 = Call(dec_44, V.Undef, ((V)("#5a3a22")), NewObj(1).Put("op", ((V)(0.5))).V);
HLs_5469 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.12))).V);
Invoke(Arr(((V)(1.8)), ((V)(3D)), ((V)(4.2)), ((V)(5.4)), ((V)(6.6)), ((V)(7.6))), "forEach", Fn((V _arrowThis5480, int _argc5472, V r_5478, V i_5479, V _a5476, V _a5477, V[] _rest5473) => {
return Invoke((NumTruthy((ToNum(i_5479) % 2D)) ? G2_5468 : G1_5467), "line", Call(wv_43, V.Undef, ((V)(32D)), Fn((V _arrowThis5488, int _argc5481, V t_5487, V _a5484, V _a5485, V _a5486, V[] _rest5482) => {
double a_5489 = 0;
a_5489 = ((ToNum(t_5487) * 2D) * PI_17);
return Arr(((V)((15D + ((FdLibm.Cos(a_5489) * ToNum(r_5478)) * (1D + (0.05 * FdLibm.Sin(ToNum(Add(((V)((a_5489 * 4D))), i_5479))))))))), ((V)(yT_5466)), ((V)(((FdLibm.Sin(a_5489) * ToNum(r_5478)) * (1D + (0.05 * FdLibm.Cos(ToNum(Add(((V)((a_5489 * 3D))), i_5479)))))))));
return default;
}, 1, "", true)), Y3_40, ((V)(0.16)));
}, 2, "", true));
Call(rep_28, V.Undef, ((V)(20D)), Fn((V _arrowThis5497, int _argc5490, V i_5496, V _a5493, V _a5494, V _a5495, V[] _rest5491) => {
return Call(vL_3998, V.Undef, (NumTruthy((ToNum(i_5496) % 2D)) ? G1_5467 : G2_5468), ((V)(15D)), ((V)(0D)), Fn((V _arrowThis5504, int _argc5498, V _a5500, V _a5501, V _a5502, V _a5503, V[] _rest5499) => {
return ((V)(8D));
}, 0, "", true), ((V)(((((ToNum(i_5496) / 20D) * 2D) * PI_17) + (ToNum(Call(R_5308, V.Undef)) * 0.1)))), ((V)(0.2)), ((V)(2.8)), ((V)(0.12)));
}, 1, "", true));
Call(spot_46, V.Undef, HLs_5469, Arr(((V)(12.5)), ((V)(yT_5466)), ((V)((-2.5)))), Y3_40, ((V)(2.4)), ((V)(1.2)), ((V)(0.6)), ((V)(12D)));
Call(on_5307, V.Undef, ST_5314, Arr(G1_5467, G2_5468, HLs_5469));
PL3_5470 = GetIdx(Call(on_5307, V.Undef, ST_5314, Arr(Call(box_11, V.Undef, ((V)(15D)), ((V)(0.7)), ((V)(7.85)), ((V)(4.4)), ((V)(1.5)), ((V)(0.3)), BR_18, Call(M__24, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V))), Z3_41), 0D);
EN_5471 = Call(dec_44, V.Undef, ((V)("#5a4214")), NewObj(1).Put("op", ((V)(0.85))).V);
Call(seg_56, V.Undef, EN_5471, Arr(((V)(13.4)), ((V)(1.75)), ((V)(8.18))), Arr(((V)(16.6)), ((V)(1.75)), ((V)(8.18))), Z3_41, ((V)(0.2)));
Call(seg_56, V.Undef, EN_5471, Arr(((V)(13.9)), ((V)(1.2)), ((V)(8.18))), Arr(((V)(16.1)), ((V)(1.2)), ((V)(8.18))), Z3_41, ((V)(0.14)));
Call(on_5307, V.Undef, PL3_5470, Arr(EN_5471));
}
if (Truthy(PN_5315)) {
V BL_5505 = default;
BL_5505 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.4))).V);
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis5513, int _argc5506, V k_5512, V _a5509, V _a5510, V _a5511, V[] _rest5507) => {
return Call(vL_3998, V.Undef, BL_5505, ((V)(15D)), ((V)(0D)), Fn((V _arrowThis5520, int _argc5514, V _a5516, V _a5517, V _a5518, V _a5519, V[] _rest5515) => {
return ((V)(1.4));
}, 0, "", true), ((V)((((PI_17 / 2D) + 0.5) + (ToNum(k_5512) * 0.3)))), ((V)(3.2)), ((V)(6.8)), ((V)(0.1)));
}, 1, "", true));
Call(on_5307, V.Undef, PN_5315, Arr(BL_5505));
}
Invoke(Invoke(o_5306, "filter", Fn((V _arrowThis5582, int _argc5575, V S1_5581, V _a5578, V _a5579, V _a5580, V[] _rest5576) => {
return ((SEqS(Get(S1_5581, "col"), "#4b4a4c") && (!(Truthy(Get(S1_5581, "par"))) || SEq(Get(S1_5581, "par"), M0_5311))) ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis5528, int _argc5521, V S1_5527, V _a5524, V _a5525, V _a5526, V[] _rest5522) => {
V L_5529 = default;
V c_5530 = default;
double rx_5531 = 0;
double ry_5532 = 0;
V TH2_5533 = default;
V RS_5534 = default;
V MG_5535 = default;
L_5529 = Call(bb_48, V.Undef, S1_5527);
c_5530 = Arr(((V)((ToNum(Add(GetIdx(L_5529, 0D), GetIdx(L_5529, 1D))) / 2D))), ((V)((ToNum(Add(GetIdx(L_5529, 2D), GetIdx(L_5529, 3D))) / 2D))), ((V)((ToNum(Add(GetIdx(L_5529, 4D), GetIdx(L_5529, 5D))) / 2D))));
rx_5531 = ((ToNum(GetIdx(L_5529, 1D)) - ToNum(GetIdx(L_5529, 0D))) / 2D);
ry_5532 = ((ToNum(GetIdx(L_5529, 3D)) - ToNum(GetIdx(L_5529, 2D))) / 2D);
TH2_5533 = Call(dec_44, V.Undef, ((V)("#2a292c")), NewObj(1).Put("op", ((V)(0.65))).V);
RS_5534 = Call(dec_44, V.Undef, ((V)("#7a4a2a")), NewObj(1).Put("op", ((V)(0.5))).V);
MG_5535 = Call(dec_44, V.Undef, ((V)("#d5dde2")), NewObj(1).Put("op", ((V)(0.85))).V);
Call(rep_28, V.Undef, ((V)(Round((rx_5531 * 1.6)))), Fn((V _arrowThis5542, int _argc5536, V _a5538, V _a5539, V _a5540, V _a5541, V[] _rest5537) => {
V p_5543 = default;
V n_5544 = default;
{ V _t5545 = Call(elS_4002, V.Undef, c_5530, ((V)(rx_5531)), ((V)(ry_5532)), ((V)(rx_5531)), Arr(((V)(((ToNum(Call(R_5308, V.Undef)) - 0.5) * 2D))), Add(((V)(0.2)), Call(R_5308, V.Undef)), ((V)(((ToNum(Call(R_5308, V.Undef)) - 0.3) * 2D)))));
{ V _t5546 = ListOf(_t5545);
{ V _t5547 = GetIdx(_t5546, 0D);
p_5543 = _t5547; }
{ V _t5548 = GetIdx(_t5546, 1D);
n_5544 = _t5548; }
} }
Call(spot_46, V.Undef, TH2_5533, p_5543, n_5544, ((V)((rx_5531 * (0.14 + (ToNum(Call(R_5308, V.Undef)) * 0.12))))), ((V)((rx_5531 * (0.1 + (ToNum(Call(R_5308, V.Undef)) * 0.08))))), ((V)((ToNum(Call(R_5308, V.Undef)) * 3D))), ((V)(9D)));
return default;
}, 0, "", true));
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis5555, int _argc5549, V _a5551, V _a5552, V _a5553, V _a5554, V[] _rest5550) => {
V p_5556 = default;
V n_5557 = default;
{ V _t5558 = Call(elS_4002, V.Undef, c_5530, ((V)(rx_5531)), ((V)(ry_5532)), ((V)(rx_5531)), Arr(((V)(((ToNum(Call(R_5308, V.Undef)) - 0.5) * 2D))), ((V)((ToNum(Call(R_5308, V.Undef)) * 0.8))), Add(((V)(0.4)), Call(R_5308, V.Undef))));
{ V _t5559 = ListOf(_t5558);
{ V _t5560 = GetIdx(_t5559, 0D);
p_5556 = _t5560; }
{ V _t5561 = GetIdx(_t5559, 1D);
n_5557 = _t5561; }
} }
Call(spot_46, V.Undef, RS_5534, p_5556, n_5557, ((V)((0.3 + (ToNum(Call(R_5308, V.Undef)) * 0.4)))), ((V)((0.2 + (ToNum(Call(R_5308, V.Undef)) * 0.3)))), ((V)((ToNum(Call(R_5308, V.Undef)) * 3D))), ((V)(7D)));
return default;
}, 0, "", true));
Call(rep_28, V.Undef, ((V)(4D)), Fn((V _arrowThis5568, int _argc5562, V _a5564, V _a5565, V _a5566, V _a5567, V[] _rest5563) => {
V p_5569 = default;
V n_5570 = default;
{ V _t5571 = Call(elS_4002, V.Undef, c_5530, ((V)(rx_5531)), ((V)(ry_5532)), ((V)(rx_5531)), Arr(((V)(((-0.4) + (ToNum(Call(R_5308, V.Undef)) - 0.5)))), ((V)((0.8 + (ToNum(Call(R_5308, V.Undef)) * 0.4)))), ((V)((0.2 + (ToNum(Call(R_5308, V.Undef)) - 0.5))))));
{ V _t5572 = ListOf(_t5571);
{ V _t5573 = GetIdx(_t5572, 0D);
p_5569 = _t5573; }
{ V _t5574 = GetIdx(_t5572, 1D);
n_5570 = _t5574; }
} }
Call(spot_46, V.Undef, MG_5535, p_5569, n_5570, ((V)(0.12)), ((V)(0.08)), ((V)(0D)), ((V)(5D)));
return default;
}, 0, "", true));
Call(on_5307, V.Undef, S1_5527, Arr(TH2_5533, RS_5534, MG_5535));
return default;
}, 1, "", true));
return o_5306;
return default;
}, 1, "build", true)).Put("layers", Arr(Object_assign(NewObj(0).V, L0_5288, NewObj(1).Put("build", Fn((V _arrowThis5590, int _argc5583, V P_5589, V _a5586, V _a5587, V _a5588, V[] _rest5584) => {
V o_5591 = default;
V on_5592 = default;
V SP_5593 = default;
V c_5594 = default;
double r_5595 = 0;
V R_5596 = default;
o_5591 = Invoke(L0_5288, "build", P_5589);
on_5592 = Call(glue_31, V.Undef, o_5591);
SP_5593 = GetIdx(o_5591, 0D);
c_5594 = Arr(((V)((-12D))), ((V)(14D)), ((V)(0D)));
r_5595 = 5.4;
R_5596 = Call(R0_30, V.Undef, ((V)("chrono25s")));
if (Truthy(SP_5593)) {
V ML_5597 = default;
V EQ_5598 = default;
V TK_5599 = default;
V STr_5600 = default;
V HL_5601 = default;
V gp_5602 = default;
ML_5597 = Call(dec_44, V.Undef, ((V)("#9aa3aa")), NewObj(1).Put("op", ((V)(0.8))).V);
EQ_5598 = Call(dec_44, V.Undef, GOLD_3990);
TK_5599 = Call(dec_44, V.Undef, ((V)("#6a4a12")));
STr_5600 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.85))).V);
HL_5601 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.5))).V);
gp_5602 = Fn((V _arrowThis5610, int _argc5603, V d_5609, V _a5606, V _a5607, V _a5608, V[] _rest5604) => {
d_5609 = Call(nz_38, V.Undef, d_5609);
return Arr(Call(add_34, V.Undef, c_5594, Call(mul_36, V.Undef, d_5609, ((V)((r_5595 + 0.02))))), d_5609);
return default;
}, 1, "", true);
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis5618, int _argc5611, V m_5617, V _a5614, V _a5615, V _a5616, V[] _rest5612) => {
double ph_5619 = 0;
V Q_5620 = default;
ph_5619 = ((ToNum(m_5617) * PI_17) / 6D);
Q_5620 = Call(wv_43, V.Undef, ((V)(24D)), Fn((V _arrowThis5628, int _argc5621, V t_5627, V _a5624, V _a5625, V _a5626, V[] _rest5622) => {
return Call(gp_5602, V.Undef, Arr(((V)((FdLibm.Sin((ToNum(t_5627) * PI_17)) * FdLibm.Cos(ph_5619)))), ((V)(FdLibm.Cos((ToNum(t_5627) * PI_17)))), ((V)((FdLibm.Sin((ToNum(t_5627) * PI_17)) * FdLibm.Sin(ph_5619))))));
}, 1, "", true));
Invoke(ML_5597, "line", Invoke(Q_5620, "map", Fn((V _arrowThis5636, int _argc5629, V q_5635, V _a5632, V _a5633, V _a5634, V[] _rest5630) => {
return GetIdx(q_5635, 0D);
}, 1, "", true)), Invoke(Q_5620, "map", Fn((V _arrowThis5644, int _argc5637, V q_5643, V _a5640, V _a5641, V _a5642, V[] _rest5638) => {
return GetIdx(q_5643, 1D);
}, 1, "", true)), ((V)(0.1)));
return default;
}, 1, "", true));
{
V Q_5645 = default;
Q_5645 = Call(wv_43, V.Undef, ((V)(40D)), Fn((V _arrowThis5653, int _argc5646, V t_5652, V _a5649, V _a5650, V _a5651, V[] _rest5647) => {
return Call(gp_5602, V.Undef, Arr(((V)(FdLibm.Cos(((ToNum(t_5652) * 2D) * PI_17)))), ((V)(0D)), ((V)(FdLibm.Sin(((ToNum(t_5652) * 2D) * PI_17))))));
}, 1, "", true));
Invoke(EQ_5598, "line", Invoke(Q_5645, "map", Fn((V _arrowThis5661, int _argc5654, V q_5660, V _a5657, V _a5658, V _a5659, V[] _rest5655) => {
return GetIdx(q_5660, 0D);
}, 1, "", true)), Invoke(Q_5645, "map", Fn((V _arrowThis5669, int _argc5662, V q_5668, V _a5665, V _a5666, V _a5667, V[] _rest5663) => {
return GetIdx(q_5668, 1D);
}, 1, "", true)), ((V)(0.45)));
}
Call(rep_28, V.Undef, ((V)(12D)), Fn((V _arrowThis5677, int _argc5670, V i_5676, V _a5673, V _a5674, V _a5675, V[] _rest5671) => {
double a_5678 = 0;
V p1_5679 = default;
V n1_5680 = default;
V p2_5681 = default;
a_5678 = (((ToNum(i_5676) / 12D) * 2D) * PI_17);
{ V _t5682 = Call(gp_5602, V.Undef, Arr(((V)(FdLibm.Cos(a_5678))), ((V)(0.14)), ((V)(FdLibm.Sin(a_5678)))));
{ V _t5683 = ListOf(_t5682);
{ V _t5684 = GetIdx(_t5683, 0D);
p1_5679 = _t5684; }
{ V _t5685 = GetIdx(_t5683, 1D);
n1_5680 = _t5685; }
} }
{ V _t5686 = Call(gp_5602, V.Undef, Arr(((V)(FdLibm.Cos(a_5678))), ((V)((-0.14))), ((V)(FdLibm.Sin(a_5678)))));
{ V _t5687 = ListOf(_t5686);
{ V _t5688 = GetIdx(_t5687, 0D);
p2_5681 = _t5688; }
} }
Invoke(TK_5599, "line", Arr(p1_5679, p2_5681), Arr(n1_5680, n1_5680), ((V)(0.16)));
return default;
}, 1, "", true));
Call(rep_28, V.Undef, ((V)(14D)), Fn((V _arrowThis5695, int _argc5689, V _a5691, V _a5692, V _a5693, V _a5694, V[] _rest5690) => {
V p_5696 = default;
V n_5697 = default;
{ V _t5698 = Call(gp_5602, V.Undef, Arr(((V)(((ToNum(Call(R_5596, V.Undef)) - 0.5) * 2D))), ((V)(((ToNum(Call(R_5596, V.Undef)) - 0.3) * 2D))), ((V)(((ToNum(Call(R_5596, V.Undef)) - 0.5) * 2D)))));
{ V _t5699 = ListOf(_t5698);
{ V _t5700 = GetIdx(_t5699, 0D);
p_5696 = _t5700; }
{ V _t5701 = GetIdx(_t5699, 1D);
n_5697 = _t5701; }
} }
Call(spot_46, V.Undef, STr_5600, p_5696, n_5697, ((V)(0.12)), ((V)(0.12)), ((V)(0D)), ((V)(5D)));
return default;
}, 0, "", true));
{
V p_5702 = default;
V n_5703 = default;
{ V _t5704 = Call(gp_5602, V.Undef, Arr(((V)((-0.45))), ((V)(0.75)), ((V)(0.5))));
{ V _t5705 = ListOf(_t5704);
{ V _t5706 = GetIdx(_t5705, 0D);
p_5702 = _t5706; }
{ V _t5707 = GetIdx(_t5705, 1D);
n_5703 = _t5707; }
} }
Call(spot_46, V.Undef, HL_5601, p_5702, n_5703, ((V)(1.3)), ((V)(0.8)), ((V)(0.6)), ((V)(12D)));
}
Call(on_5592, V.Undef, SP_5593, Arr(ML_5597, EQ_5598, TK_5599, STr_5600, HL_5601));
}
return o_5591;
return default;
}, 1, "build", true)).V))).V);
return default;
}, 1, "", true));
Set(N_16, "pothos25", Fn((V _arrowThis5715, int _argc5708, V S_5714, V _a5711, V _a5712, V _a5713, V[] _rest5709) => {
V B_5716 = default;
V rC_5717 = default;
double fr_5718 = 0;
B_5716 = Invoke(N_16, "flora", NewObj(1).Put("pl", ((V)("pothos"))).V);
rC_5717 = Fn((V _arrowThis5726, int _argc5719, V y_5725, V _a5722, V _a5723, V _a5724, V[] _rest5720) => {
return ((V)((10D * (0.8 + ((0.2 * (ToNum(y_5725) - 1D)) / 14D)))));
}, 1, "", true);
fr_5718 = (PI_17 / 2D);
return Object_assign(NewObj(0).V, B_5716, NewObj(1).Put("build", Fn((V _arrowThis5733, int _argc5727, V _a5729, V _a5730, V _a5731, V _a5732, V[] _rest5728) => {
V o_5734 = default;
V on_5735 = default;
V R_5736 = default;
V SA0_5737 = default;
V C_5738 = default;
V SO_5739 = default;
o_5734 = Arr();
on_5735 = Call(glue_31, V.Undef, o_5734);
R_5736 = Call(R0_30, V.Undef, ((V)("pothos25")));
SA0_5737 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(11.6)), ((V)(1D)), ((V)("#f6f1e8")), Call(PL_27, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(1D)), ((V)(0D)), ((V)(1D))))).V));
Invoke(o_5734, "push", SA0_5737);
{
V PK_5740 = default;
V PK2_5741 = default;
V PD_5742 = default;
V PDh_5743 = default;
V YL_5744 = default;
V YLv_5745 = default;
V BRw_5746 = default;
V DT_5747 = default;
PK_5740 = Call(dec_44, V.Undef, ((V)("#e86f8a")));
PK2_5741 = Call(dec_44, V.Undef, ((V)("#f6c2cc")));
PD_5742 = Call(dec_44, V.Undef, ((V)("#8fb0c4")), NewObj(1).Put("op", ((V)(0.32))).V);
PDh_5743 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.35))).V);
YL_5744 = Call(dec_44, V.Undef, ((V)("#d8c45a")));
YLv_5745 = Call(dec_44, V.Undef, ((V)("#a8943a")), NewObj(1).Put("op", ((V)(0.8))).V);
BRw_5746 = Call(dec_44, V.Undef, ((V)("#9a6a3a")));
DT_5747 = Call(dec_44, V.Undef, ((V)("#8a7a60")), NewObj(1).Put("op", ((V)(0.25))).V);
Call(ringY_51, V.Undef, PK_5740, ((V)(0D)), ((V)(0D)), ((V)(10.6)), ((V)(1D)), ((V)(1.1)), ((V)(48D)));
Call(ringY_51, V.Undef, PK2_5741, ((V)(0D)), ((V)(0D)), ((V)(9.4)), ((V)(1D)), ((V)(0.35)), ((V)(48D)));
Call(speck_55, V.Undef, DT_5747, ((V)(16D)), Fn((V _arrowThis5756, int _argc5748, V u_5754, V v_5755, V _a5752, V _a5753, V[] _rest5749) => {
double a_5757 = 0;
double r_5758 = 0;
a_5757 = ((ToNum(u_5754) * 2D) * PI_17);
r_5758 = (8.4 + (ToNum(v_5755) * 2.8));
return Arr(((V)((FdLibm.Cos(a_5757) * r_5758))), ((V)(1D)), ((V)((FdLibm.Sin(a_5757) * r_5758))));
return default;
}, 2, "", true), Y3_40, ((V)(0.15)), ((V)(0.4)), R_5736);
Invoke(PD_5742, "poly", Call(elP_45, V.Undef, Arr(((V)(6.2)), ((V)(1D)), ((V)(6.4))), X3_39, Z3_41, ((V)(3.2)), ((V)(2D)), ((V)(18D))), Y3_40);
Call(spot_46, V.Undef, PDh_5743, Arr(((V)(5.6)), ((V)(1D)), ((V)(6D))), Y3_40, ((V)(0.9)), ((V)(0.3)), ((V)(0.4)), ((V)(10D)));
Call(heart_4001, V.Undef, YL_5744, ((V)((-7.4))), ((V)(1D)), ((V)(5.8)), ((V)(1.5)), ((V)(0.6)));
Call(seg_56, V.Undef, YLv_5745, Arr(((V)(((-7.4) + (FdLibm.Sin(0.6) * 1.3)))), ((V)(1D)), ((V)((5.8 - (FdLibm.Cos(0.6) * 1.3))))), Arr(((V)(((-7.4) - (FdLibm.Sin(0.6) * 1.1)))), ((V)(1D)), ((V)((5.8 + (FdLibm.Cos(0.6) * 1.1))))), Y3_40, ((V)(0.1)));
Call(heart_4001, V.Undef, BRw_5746, ((V)(8.2)), ((V)(1D)), ((V)((-6D))), ((V)(1.2)), ((V)(2.4)));
Call(on_5735, V.Undef, SA0_5737, Arr(PK_5740, PK2_5741, DT_5747, PD_5742, PDh_5743, YL_5744, YLv_5745, BRw_5746));
}
C_5738 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(1D)), ((V)(0D)), ((V)(10D)), ((V)(14D)), ((V)("#f4f2ec")), Call(PL_27, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))))).V));
Invoke(o_5734, "push", C_5738);
{
V LB_5759 = default;
V WH_5760 = default;
V RDs_5761 = default;
V GRs_5762 = default;
V SD_5763 = default;
V TB_5764 = default;
V RB_5765 = default;
V DR_5766 = default;
V TP_5767 = default;
V CK_5768 = default;
V FO_5769 = default;
V FOh_5770 = default;
V HO_5771 = default;
V NUT_5772 = default;
V BC_5773 = default;
V WD_5774 = default;
V PRc_5775 = default;
V RS_5776 = default;
double bk_5777 = 0;
LB_5759 = Call(dec_44, V.Undef, ((V)("#f3a6b6")));
WH_5760 = Call(dec_44, V.Undef, ((V)("#ffffff")));
RDs_5761 = Call(dec_44, V.Undef, ((V)("#e0303e")));
GRs_5762 = Call(dec_44, V.Undef, ((V)("#4f9a3a")));
SD_5763 = Call(dec_44, V.Undef, ((V)("#ffe58a")));
TB_5764 = Call(dec_44, V.Undef, ((V)("#c83a5a")));
RB_5765 = Call(dec_44, V.Undef, ((V)("#e2ded4")), NewObj(1).Put("op", ((V)(0.9))).V);
DR_5766 = Call(dec_44, V.Undef, ((V)("#8a7a5a")), NewObj(1).Put("op", ((V)(0.2))).V);
TP_5767 = Call(dec_44, V.Undef, ((V)("#f2e8b0")), NewObj(1).Put("op", ((V)(0.45))).V);
CK_5768 = Call(dec_44, V.Undef, ((V)("#9a958c")), NewObj(1).Put("op", ((V)(0.9))).V);
FO_5769 = Call(dec_44, V.Undef, ((V)("#c9ced3")));
FOh_5770 = Call(dec_44, V.Undef, ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0.75))).V);
HO_5771 = Call(dec_44, V.Undef, ((V)("#3a3028")), NewObj(1).Put("op", ((V)(0.85))).V);
NUT_5772 = Call(dec_44, V.Undef, ((V)("#ffffff")));
BC_5773 = Call(dec_44, V.Undef, ((V)("#2a2a2e")));
WD_5774 = Call(dec_44, V.Undef, ((V)("#bcd8e4")), NewObj(1).Put("op", ((V)(0.35))).V);
PRc_5775 = Call(dec_44, V.Undef, ((V)("#ff8a2a")));
RS_5776 = Call(dec_44, V.Undef, ((V)("#e8e2d6")), NewObj(1).Put("op", ((V)(0.9))).V);
Call(rep_28, V.Undef, ((V)(28D)), Fn((V _arrowThis5785, int _argc5778, V i_5784, V _a5781, V _a5782, V _a5783, V[] _rest5779) => {
return Call(vL_3998, V.Undef, RB_5765, ((V)(0D)), ((V)(0D)), rC_5717, ((V)((((ToNum(i_5784) / 28D) * 2D) * PI_17))), ((V)(1.3)), ((V)(3.6)), ((V)(0.14)));
}, 1, "", true));
Call(band3_3999, V.Undef, DR_5766, ((V)(0D)), ((V)(0D)), rC_5717, ((V)(1.05)), ((V)(1.8)), ((V)(0D)), ((V)((2D * PI_17))), ((V)(24D)));
Call(band3_3999, V.Undef, LB_5759, ((V)(0D)), ((V)(0D)), rC_5717, ((V)(4D)), ((V)(12.2)), ((V)(0.55)), ((V)(((2D * PI_17) - 0.25))), ((V)(30D)));
Invoke(Arr(Arr(((V)((-0.05))), ((V)(6D))), Arr(((V)(0.25)), ((V)(9.4)))), "forEach", Fn((V _arrowThis5797, int _argc5786, V _a5788, V _a5789, V _a5790, V _a5791, V[] _rest5787) => {
V a_5794 = default;
V y_5796 = default;
{ V _t5792 = ListOf(_a5788);
{ V _t5793 = GetIdx(_t5792, 0D);
a_5794 = _t5793; }
{ V _t5795 = GetIdx(_t5792, 1D);
y_5796 = _t5795; }
}
return Call(spotC_4000, V.Undef, RS_5776, ((V)(0D)), ((V)(0D)), rC_5717, a_5794, y_5796, ((V)(1.2)), ((V)(0.6)));
}, 1, "", true));
Invoke(WH_5760, "line", Call(wv_43, V.Undef, ((V)(10D)), Fn((V _arrowThis5805, int _argc5798, V t_5804, V _a5801, V _a5802, V _a5803, V[] _rest5799) => {
double y_5806 = 0;
y_5806 = (4D + (8.2 * ToNum(t_5804)));
return Call(cP_3995, V.Undef, ((V)(0D)), ((V)(0D)), Call(rC_5717, V.Undef, ((V)(y_5806))), ((V)((0.55 + (0.05 * FdLibm.Sin((ToNum(t_5804) * 40D)))))), ((V)(y_5806)));
return default;
}, 1, "", true)), Call(cN_42, V.Undef, ((V)(0.58))), ((V)(0.24)));
Invoke(WH_5760, "line", Call(wv_43, V.Undef, ((V)(36D)), Fn((V _arrowThis5814, int _argc5807, V t_5813, V _a5810, V _a5811, V _a5812, V[] _rest5808) => {
double a_5815 = 0;
a_5815 = (0.62 + (ToNum(t_5813) * ((2D * PI_17) - 0.95)));
return Call(cP_3995, V.Undef, ((V)(0D)), ((V)(0D)), Call(rC_5717, V.Undef, ((V)(10.8))), ((V)(a_5815)), ((V)((10.8 + (0.35 * FdLibm.Sin((a_5815 * 6D)))))));
return default;
}, 1, "", true)), Call(wv_43, V.Undef, ((V)(36D)), Fn((V _arrowThis5823, int _argc5816, V t_5822, V _a5819, V _a5820, V _a5821, V[] _rest5817) => {
return Call(cN_42, V.Undef, ((V)((0.62 + (ToNum(t_5822) * ((2D * PI_17) - 0.95))))));
}, 1, "", true)), ((V)(0.7)));
Invoke(Arr(((V)((fr_5718 - 0.6))), ((V)((fr_5718 + 0.34))), ((V)((fr_5718 + 1.25))), ((V)((fr_5718 + 2.3))), ((V)((fr_5718 + 3.4)))), "forEach", Fn((V _arrowThis5831, int _argc5824, V a_5830, V _a5827, V _a5828, V _a5829, V[] _rest5825) => {
Call(spotC_4000, V.Undef, RDs_5761, ((V)(0D)), ((V)(0D)), rC_5717, a_5830, ((V)(6.2)), ((V)(1.1)), ((V)(1.35)));
Call(spotC_4000, V.Undef, GRs_5762, ((V)(0D)), ((V)(0D)), rC_5717, a_5830, ((V)(7.55)), ((V)(0.8)), ((V)(0.35)));
Invoke(Arr(Arr(((V)((-0.04))), ((V)(6.6))), Arr(((V)(0.04)), ((V)(6.1))), Arr(((V)(0D)), ((V)(5.5)))), "forEach", Fn((V _arrowThis5843, int _argc5832, V _a5834, V _a5835, V _a5836, V _a5837, V[] _rest5833) => {
V da_5840 = default;
V y_5842 = default;
{ V _t5838 = ListOf(_a5834);
{ V _t5839 = GetIdx(_t5838, 0D);
da_5840 = _t5839; }
{ V _t5841 = GetIdx(_t5838, 1D);
y_5842 = _t5841; }
}
return Call(spotC_4000, V.Undef, SD_5763, ((V)(0D)), ((V)(0D)), rC_5717, Add(a_5830, da_5840), y_5842, ((V)(0.12)), ((V)(0.16)));
}, 1, "", true));
return default;
}, 1, "", true));
Call(spotC_4000, V.Undef, WH_5760, ((V)(0D)), ((V)(0D)), rC_5717, ((V)(fr_5718)), ((V)(8.8)), ((V)(2.4)), ((V)(1D)));
Call(ringL_3997, V.Undef, TB_5764, ((V)(0D)), ((V)(0D)), rC_5717, ((V)(8.9)), ((V)(0.36)), ((V)((fr_5718 - 0.17))), ((V)((fr_5718 + 0.17))), ((V)(6D)));
Call(ringL_3997, V.Undef, TB_5764, ((V)(0D)), ((V)(0D)), rC_5717, ((V)(8.35)), ((V)(0.16)), ((V)((fr_5718 - 0.12))), ((V)((fr_5718 + 0.12))), ((V)(4D)));
bk_5777 = ((3D * PI_17) / 2D);
Call(band3_3999, V.Undef, NUT_5772, ((V)(0D)), ((V)(0D)), rC_5717, ((V)(5D)), ((V)(10D)), ((V)((bk_5777 - 0.4))), ((V)((bk_5777 + 0.4))), ((V)(4D)));
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis5851, int _argc5844, V i_5850, V _a5847, V _a5848, V _a5849, V[] _rest5845) => {
return Call(ringL_3997, V.Undef, BC_5773, ((V)(0D)), ((V)(0D)), rC_5717, ((V)((5.6 + (ToNum(i_5850) * 0.75)))), ((V)((Truthy(i_5850) ? 0.1 : 0.22))), ((V)((bk_5777 - 0.32))), ((V)(((bk_5777 + 0.32) - ((ToNum(i_5850) % 2D) * 0.12)))), ((V)(4D)));
}, 1, "", true));
Call(band3_3999, V.Undef, NUT_5772, ((V)(0D)), ((V)(0D)), rC_5717, ((V)(5D)), ((V)(7.8)), ((V)((bk_5777 + 0.6))), ((V)((bk_5777 + 0.95))), ((V)(3D)));
Call(rep_28, V.Undef, ((V)(12D)), Fn((V _arrowThis5859, int _argc5852, V i_5858, V _a5855, V _a5856, V _a5857, V[] _rest5853) => {
return Call(vL_3998, V.Undef, BC_5773, ((V)(0D)), ((V)(0D)), rC_5717, ((V)(((bk_5777 + 0.63) + (ToNum(i_5858) * 0.027)))), ((V)(5.4)), ((V)(7.4)), ((V)((NumTruthy((ToNum(i_5858) % 3D)) ? 0.06 : 0.12))));
}, 1, "", true));
Call(spotC_4000, V.Undef, PRc_5775, ((V)(0D)), ((V)(0D)), rC_5717, ((V)((fr_5718 + 0.95))), ((V)(2.6)), ((V)(1.3)), ((V)(0.8)));
Call(ringL_3997, V.Undef, WH_5760, ((V)(0D)), ((V)(0D)), rC_5717, ((V)(2.6)), ((V)(0.18)), ((V)((fr_5718 + 0.88))), ((V)((fr_5718 + 1.02))), ((V)(3D)));
Invoke(CK_5768, "line", Call(wv_43, V.Undef, ((V)(6D)), Fn((V _arrowThis5867, int _argc5860, V t_5866, V _a5863, V _a5864, V _a5865, V[] _rest5861) => {
return Call(cP_3995, V.Undef, ((V)(0D)), ((V)(0D)), Call(rC_5717, V.Undef, ((V)((8.6 + (5D * ToNum(t_5866)))))), ((V)(((fr_5718 + 1.55) + (0.05 * FdLibm.Sin((ToNum(t_5866) * 12D)))))), ((V)((8.6 + (5D * ToNum(t_5866))))));
}, 1, "", true)), Call(cN_42, V.Undef, ((V)((fr_5718 + 1.55)))), ((V)(0.14)));
Call(band3_3999, V.Undef, TP_5767, ((V)(0D)), ((V)(0D)), rC_5717, ((V)(9.4)), ((V)(12.8)), ((V)((fr_5718 + 1.4))), ((V)((fr_5718 + 1.72))), ((V)(3D)));
Invoke(FO_5769, "poly", Invoke(Arr(Arr(((V)((fr_5718 - 1.25))), ((V)(15D))), Arr(((V)((fr_5718 - 0.7))), ((V)(15D))), Arr(((V)((fr_5718 - 0.82))), ((V)(13.6))), Arr(((V)((fr_5718 - 0.98))), ((V)(12.4))), Arr(((V)((fr_5718 - 1.12))), ((V)(13.4)))), "map", Fn((V _arrowThis5879, int _argc5868, V _a5870, V _a5871, V _a5872, V _a5873, V[] _rest5869) => {
V a_5876 = default;
V y_5878 = default;
{ V _t5874 = ListOf(_a5870);
{ V _t5875 = GetIdx(_t5874, 0D);
a_5876 = _t5875; }
{ V _t5877 = GetIdx(_t5874, 1D);
y_5878 = _t5877; }
}
return Call(cP_3995, V.Undef, ((V)(0D)), ((V)(0D)), Call(rC_5717, V.Undef, y_5878), a_5876, y_5878);
}, 1, "", true)), Call(cN_42, V.Undef, ((V)((fr_5718 - 1D)))));
Invoke(FOh_5770, "line", Arr(Call(cP_3995, V.Undef, ((V)(0D)), ((V)(0D)), Call(rC_5717, V.Undef, ((V)(14.6))), ((V)((fr_5718 - 1.1))), ((V)(14.6))), Call(cP_3995, V.Undef, ((V)(0D)), ((V)(0D)), Call(rC_5717, V.Undef, ((V)(13.4))), ((V)((fr_5718 - 0.95))), ((V)(13.4)))), Call(cN_42, V.Undef, ((V)((fr_5718 - 1D)))), ((V)(0.12)));
Invoke(Arr(((V)((fr_5718 + 0.5))), ((V)((fr_5718 - 0.2))), ((V)((fr_5718 + 1.1)))), "forEach", Fn((V _arrowThis5887, int _argc5880, V a_5886, V _a5883, V _a5884, V _a5885, V[] _rest5881) => {
return Call(spotC_4000, V.Undef, HO_5771, ((V)(0D)), ((V)(0D)), rC_5717, a_5886, ((V)(1.7)), ((V)(0.3)), ((V)(0.3)));
}, 1, "", true));
Call(vL_3998, V.Undef, WD_5774, ((V)(0D)), ((V)(0D)), rC_5717, ((V)((fr_5718 + 0.7))), ((V)(1.4)), ((V)(6D)), ((V)(0.3)));
Call(on_5735, V.Undef, C_5738, Arr(RB_5765, DR_5766, LB_5759, RS_5776, WH_5760, RDs_5761, GRs_5762, SD_5763, TB_5764, NUT_5772, BC_5773, PRc_5775, TP_5767, CK_5768, FO_5769, FOh_5770, HO_5771, WD_5774));
}
Call(on_5735, V.Undef, C_5738, Arr(Call(band_29, V.Undef, ((V)(0D)), ((V)(14.4)), ((V)(0D)), ((V)(10.1)), ((V)(0.6)), ((V)("#ffffff")), Call(PL_27, V.Undef, NewObj(1).Put("n", ((V)(28D))).V))));
SO_5739 = GetIdx(Call(on_5735, V.Undef, C_5738, Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(14.92)), ((V)(0D)), ((V)(9.5)), ((V)(0.16)), ((V)("#4a3020")), NewObj(1).Put("n", ((V)(26D))).V))), 0D);
{
V PE_5888 = default;
V DK_5889 = default;
V Y2_5890 = default;
double yS_5891 = 0;
V disk_5892 = default;
PE_5888 = Call(dec_44, V.Undef, ((V)("#f2f0ea")));
DK_5889 = Call(dec_44, V.Undef, ((V)("#2e1c10")), NewObj(1).Put("op", ((V)(0.7))).V);
Y2_5890 = Call(dec_44, V.Undef, ((V)("#c9b04a")));
yS_5891 = 15.08;
disk_5892 = Fn((V _arrowThis5901, int _argc5893, V u_5899, V v_5900, V _a5897, V _a5898, V[] _rest5894) => {
double a_5902 = 0;
double r_5903 = 0;
a_5902 = ((ToNum(u_5899) * 2D) * PI_17);
r_5903 = (System.Math.Sqrt(ToNum(v_5900)) * 9D);
return Arr(((V)((FdLibm.Cos(a_5902) * r_5903))), ((V)(yS_5891)), ((V)((FdLibm.Sin(a_5902) * r_5903))));
return default;
}, 2, "", true);
Call(speck_55, V.Undef, DK_5889, ((V)(40D)), disk_5892, Y3_40, ((V)(0.3)), ((V)(0.8)), R_5736);
Call(speck_55, V.Undef, PE_5888, ((V)(26D)), disk_5892, Y3_40, ((V)(0.15)), ((V)(0.32)), R_5736);
Call(heart_4001, V.Undef, Y2_5890, ((V)((-3.4))), ((V)(yS_5891)), ((V)(4.2)), ((V)(1.6)), ((V)(2.2)));
Call(on_5735, V.Undef, SO_5739, Arr(DK_5889, PE_5888, Y2_5890, Call(rod_22, V.Undef, Arr(((V)(3.2)), ((V)(yS_5891)), ((V)((-2.4)))), Arr(((V)(6.4)), ((V)((yS_5891 + 6.4))), ((V)((-5D)))), ((V)(0.42)), ((V)("#f6a0b4")), Call(PL_27, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(ball_13, V.Undef, ((V)(6.5)), ((V)((yS_5891 + 6.6))), ((V)((-5.1))), ((V)(0.6)), ((V)("#f6a0b4")), Call(PL_27, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sy", ((V)(0.6))).V))));
}
return o_5734;
return default;
}, 0, "build", true)).V);
return default;
}, 1, "", true));
Set(N_16, "terra25", Fn((V _arrowThis5911, int _argc5904, V S_5910, V _a5907, V _a5908, V _a5909, V[] _rest5905) => {
V B_5912 = default;
V L0_5913 = default;
double GY_5914 = 0;
double GR_5915 = 0;
double GS_5916 = 0;
V gH_5917 = default;
double OC_5918 = 0;
double OR_5919 = 0;
double LX_5920 = 0;
double LZ_5921 = 0;
B_5912 = Invoke(N_16, "flora", NewObj(1).Put("pl", ((V)("terrarium"))).V);
L0_5913 = GetIdx(Get(B_5912, "layers"), 0D);
GY_5914 = 40.5;
GR_5915 = 15.6;
GS_5916 = 0.16;
gH_5917 = Fn((V _arrowThis5930, int _argc5922, V x_5928, V z_5929, V _a5926, V _a5927, V[] _rest5923) => {
return ((V)(((GY_5914 + ((GR_5915 * GS_5916) * System.Math.Sqrt(Max(0D, (1D - (((ToNum(x_5928) * ToNum(x_5928)) + (ToNum(z_5929) * ToNum(z_5929))) / (GR_5915 * GR_5915))))))) + 0.05)));
}, 2, "", true);
OC_5918 = 37D;
OR_5919 = 32D;
LX_5920 = (-9D);
LZ_5921 = 6.5;
return Object_assign(NewObj(0).V, B_5912, NewObj(5).Put("w", ((V)(64D))).Put("d", ((V)(56D))).Put("build", Fn((V _arrowThis5937, int _argc5931, V _a5933, V _a5934, V _a5935, V _a5936, V[] _rest5932) => {
V o_5938 = default;
V on_5939 = default;
V B1_5940 = default;
V B2_5941 = default;
V EM_5942 = default;
o_5938 = Arr();
on_5939 = Call(glue_31, V.Undef, o_5938);
B1_5940 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(15D)), ((V)(2D)), ((V)("#23252b")), Call(M__24, V.Undef, NewObj(3).Put("n", ((V)(30D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.96))), Arr(((V)(0.4)), ((V)(0D)), ((V)(1D))), Arr(((V)(2D)), ((V)(0D)), ((V)(1D))))).V));
B2_5941 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)), ((V)(12.6)), ((V)(1.6)), ((V)("#3a3d44")), Call(M__24, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(1.6)), ((V)(0D)), ((V)(0.94))))).V));
Invoke(o_5938, "push", B1_5940, B2_5941);
{
V WA_5943 = default;
V WAh_5944 = default;
V RU_5945 = default;
V BRu_5946 = default;
WA_5943 = Call(dec_44, V.Undef, ((V)("#4fb8e8")), NewObj(1).Put("op", ((V)(0.55))).V);
WAh_5944 = Call(dec_44, V.Undef, ((V)("#d8f4ff")), NewObj(1).Put("op", ((V)(0.5))).V);
RU_5945 = Call(dec_44, V.Undef, ((V)("#6ac8ff")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.8))).V);
BRu_5946 = Call(dec_44, V.Undef, ((V)("#8a9098")), NewObj(1).Put("op", ((V)(0.5))).V);
Call(rep_28, V.Undef, ((V)(30D)), Fn((V _arrowThis5954, int _argc5947, V i_5953, V _a5950, V _a5951, V _a5952, V[] _rest5948) => {
return Call(vL_3998, V.Undef, BRu_5946, ((V)(0D)), ((V)(0D)), Fn((V _arrowThis5961, int _argc5955, V _a5957, V _a5958, V _a5959, V _a5960, V[] _rest5956) => {
return ((V)(15D));
}, 0, "", true), ((V)((((ToNum(i_5953) / 30D) * 2D) * PI_17))), ((V)(0.3)), ((V)(1.8)), ((V)(0.08)));
}, 1, "", true));
Invoke(WA_5943, "line", Call(wv_43, V.Undef, ((V)(48D)), Fn((V _arrowThis5969, int _argc5962, V t_5968, V _a5965, V _a5966, V _a5967, V[] _rest5963) => {
return Arr(((V)((FdLibm.Cos(((ToNum(t_5968) * 2D) * PI_17)) * 13.8))), ((V)(2D)), ((V)((FdLibm.Sin(((ToNum(t_5968) * 2D) * PI_17)) * 13.8))));
}, 1, "", true)), Y3_40, ((V)(1.7)));
Call(ringY_51, V.Undef, WAh_5944, ((V)(0D)), ((V)(0D)), ((V)(13.3)), ((V)(2D)), ((V)(0.15)), ((V)(48D)));
Call(ringY_51, V.Undef, WAh_5944, ((V)(0.4)), ((V)(0.2)), ((V)(14.3)), ((V)(2D)), ((V)(0.1)), ((V)(40D)));
Call(rep_28, V.Undef, ((V)(16D)), Fn((V _arrowThis5977, int _argc5970, V i_5976, V _a5973, V _a5974, V _a5975, V[] _rest5971) => {
double a_5978 = 0;
a_5978 = (((ToNum(i_5976) / 16D) * 2D) * PI_17);
Call(ringL_3997, V.Undef, RU_5945, ((V)(0D)), ((V)(0D)), Fn((V _arrowThis5985, int _argc5979, V _a5981, V _a5982, V _a5983, V _a5984, V[] _rest5980) => {
return ((V)(15D));
}, 0, "", true), ((V)(1.05)), ((V)(0.22)), ((V)((a_5978 - 0.08))), ((V)((a_5978 + 0.08))), ((V)(3D)));
Call(vL_3998, V.Undef, RU_5945, ((V)(0D)), ((V)(0D)), Fn((V _arrowThis5992, int _argc5986, V _a5988, V _a5989, V _a5990, V _a5991, V[] _rest5987) => {
return ((V)(15D));
}, 0, "", true), ((V)((a_5978 + (NumTruthy((ToNum(i_5976) % 2D)) ? 0.05 : (-0.05))))), ((V)(0.7)), ((V)(1.4)), ((V)(0.14)));
return default;
}, 1, "", true));
Call(on_5939, V.Undef, B1_5940, Arr(BRu_5946, WA_5943, WAh_5944, RU_5945));
}
{
V BT_5993 = default;
BT_5993 = Call(dec_44, V.Undef, ((V)("#9aa3aa")), NewObj(1).Put("op", ((V)(0.9))).V);
Call(rep_28, V.Undef, ((V)(8D)), Fn((V _arrowThis6001, int _argc5994, V i_6000, V _a5997, V _a5998, V _a5999, V[] _rest5995) => {
double a_6002 = 0;
a_6002 = ((((ToNum(i_6000) / 8D) * 2D) * PI_17) + 0.2);
Call(spot_46, V.Undef, BT_5993, Arr(((V)((FdLibm.Cos(a_6002) * 11D))), ((V)(3.6)), ((V)((FdLibm.Sin(a_6002) * 11D)))), Y3_40, ((V)(0.35)), ((V)(0.35)), ((V)(0D)), ((V)(6D)));
return default;
}, 1, "", true));
Call(on_5939, V.Undef, B2_5941, Arr(BT_5993));
}
EM_5942 = GetIdx(Call(on_5939, V.Undef, B2_5941, Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(3.6)), ((V)(0D)), ((V)(9.6)), ((V)(0.25)), ((V)("#6ac8ff")), Call(em_3984, V.Undef, NewObj(1).Put("n", ((V)(26D))).V)))), 0D);
{
V RI_6003 = default;
V HX_6004 = default;
double yT_6005 = 0;
RI_6003 = Call(dec_44, V.Undef, ((V)("#e8fbff")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.7))).V);
HX_6004 = Call(dec_44, V.Undef, ((V)("#2a8ac8")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.6))).V);
yT_6005 = 3.85;
Call(rep_28, V.Undef, ((V)(12D)), Fn((V _arrowThis6013, int _argc6006, V i_6012, V _a6009, V _a6010, V _a6011, V[] _rest6007) => {
double a_6014 = 0;
a_6014 = (((ToNum(i_6012) / 12D) * 2D) * PI_17);
Call(seg_56, V.Undef, HX_6004, Arr(((V)((FdLibm.Cos(a_6014) * 3.2))), ((V)(yT_6005)), ((V)((FdLibm.Sin(a_6014) * 3.2)))), Arr(((V)((FdLibm.Cos(a_6014) * 8D))), ((V)(yT_6005)), ((V)((FdLibm.Sin(a_6014) * 8D)))), Y3_40, ((V)(0.14)));
return default;
}, 1, "", true));
Invoke(Arr(((V)(3D)), ((V)(5.6)), ((V)(8.2))), "forEach", Fn((V _arrowThis6022, int _argc6015, V r_6021, V _a6018, V _a6019, V _a6020, V[] _rest6016) => {
return Call(ringY_51, V.Undef, RI_6003, ((V)(0D)), ((V)(0D)), r_6021, ((V)(yT_6005)), ((V)(0.22)), ((V)(36D)));
}, 1, "", true));
Call(on_5939, V.Undef, EM_5942, Arr(HX_6004, RI_6003));
}
return o_5938;
return default;
}, 0, "build", true)).Put("layers", Arr(Object_assign(NewObj(0).V, L0_5913, NewObj(1).Put("build", Fn((V _arrowThis6029, int _argc6023, V _a6025, V _a6026, V _a6027, V _a6028, V[] _rest6024) => {
V o_6030 = default;
V on_6031 = default;
V R_6032 = default;
V RK_6033 = default;
V SO_6034 = default;
V GRb_6035 = default;
V r1_6036 = default;
V r2_6037 = default;
V r3_6038 = default;
o_6030 = Arr();
on_6031 = Call(glue_31, V.Undef, o_6030);
R_6032 = Call(R0_30, V.Undef, ((V)("terra25i")));
RK_6033 = Call(ball_13, V.Undef, ((V)(0D)), ((V)(26.4)), ((V)(0D)), ((V)(12D)), ((V)("#7a6a5a")), NewObj(3).Put("sy", ((V)(0.55))).Put("k", ((V)(6D))).Put("n", ((V)(18D))).V);
SO_6034 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(33D)), ((V)(0D)), ((V)(15.2)), ((V)(5D)), ((V)("#6e5a44")), NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.72))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))))).V);
GRb_6035 = Call(ball_13, V.Undef, ((V)(0D)), ((V)(GY_5914)), ((V)(0D)), ((V)(GR_5915)), ((V)("#5a8f3a")), NewObj(3).Put("sy", ((V)(GS_5916))).Put("k", ((V)(3D))).Put("n", ((V)(22D))).V);
r1_6036 = Call(ball_13, V.Undef, ((V)((-5D))), ((V)(15D)), ((V)(2.5)), ((V)(5.6)), ((V)("#6a5a4a")), NewObj(3).Put("sy", ((V)(0.75))).Put("k", ((V)(5D))).Put("n", ((V)(14D))).V);
r2_6037 = Call(ball_13, V.Undef, ((V)(6D)), ((V)(15.6)), ((V)((-2D))), ((V)(5D)), ((V)("#5a4a3a")), NewObj(3).Put("sy", ((V)(0.8))).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V);
r3_6038 = Call(ball_13, V.Undef, ((V)(0.4)), ((V)(8.2)), ((V)(0.4)), ((V)(2.6)), ((V)("#4e4034")), NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V);
Invoke(o_6030, "push", RK_6033, SO_6034, GRb_6035, r1_6036, r2_6037, r3_6038);
{
V rK_6039 = default;
V S1_6040 = default;
V S2_6041 = default;
V MS_6042 = default;
V MD_6043 = default;
rK_6039 = Fn((V _arrowThis6051, int _argc6044, V y_6050, V _a6047, V _a6048, V _a6049, V[] _rest6045) => {
return ((V)((12D * System.Math.Sqrt(Max(0.02, (1D - Pow(((ToNum(y_6050) - 26.4) / 6.6), 2D)))))));
}, 1, "", true);
S1_6040 = Call(dec_44, V.Undef, ((V)("#5a4a3c")), NewObj(1).Put("op", ((V)(0.6))).V);
S2_6041 = Call(dec_44, V.Undef, ((V)("#9a8a78")), NewObj(1).Put("op", ((V)(0.5))).V);
MS_6042 = Call(dec_44, V.Undef, ((V)("#5f9a3e")), NewObj(1).Put("op", ((V)(0.85))).V);
MD_6043 = Call(dec_44, V.Undef, ((V)("#3f6f2e")), NewObj(1).Put("op", ((V)(0.8))).V);
Invoke(Arr(((V)(21.5)), ((V)(23.6)), ((V)(25.8)), ((V)(28D)), ((V)(30.2))), "forEach", Fn((V _arrowThis6060, int _argc6052, V y_6058, V i_6059, V _a6056, V _a6057, V[] _rest6053) => {
return Call(ringL_3997, V.Undef, (NumTruthy((ToNum(i_6059) % 2D)) ? S2_6041 : S1_6040), ((V)(0D)), ((V)(0D)), rK_6039, y_6058, ((V)(0.24)), ((V)(0D)), ((V)((2D * PI_17))), ((V)(36D)), Fn((V _arrowThis6068, int _argc6061, V a_6067, V _a6064, V _a6065, V _a6066, V[] _rest6062) => {
return ((V)((0.4 * FdLibm.Sin(ToNum(Add(((V)((ToNum(a_6067) * 3D))), y_6058))))));
}, 1, "", true));
}, 2, "", true));
Call(rep_28, V.Undef, ((V)(14D)), Fn((V _arrowThis6076, int _argc6069, V i_6075, V _a6072, V _a6073, V _a6074, V[] _rest6070) => {
double a_6077 = 0;
a_6077 = ((((ToNum(i_6075) / 14D) * 2D) * PI_17) + (ToNum(Call(R_6032, V.Undef)) * 0.3));
Call(spotC_4000, V.Undef, MS_6042, ((V)(0D)), ((V)(0D)), rK_6039, ((V)(a_6077)), ((V)(31.6)), Add(((V)(1.4)), Call(R_6032, V.Undef)), ((V)(0.6)));
if (NumTruthy((ToNum(i_6075) % 2D))) {
Call(vL_3998, V.Undef, MD_6043, ((V)(0D)), ((V)(0D)), rK_6039, ((V)((a_6077 + 0.05))), ((V)((28.4 + (ToNum(Call(R_6032, V.Undef)) * 1.4)))), ((V)(31.4)), ((V)(0.35)));
}
return default;
}, 1, "", true));
Call(on_6031, V.Undef, RK_6033, Arr(S1_6040, S2_6041, MD_6043, MS_6042));
}
Invoke(Arr(Arr(r1_6036, Arr(((V)((-5D))), ((V)(15D)), ((V)(2.5))), ((V)(5.6)), ((V)(4.2))), Arr(r2_6037, Arr(((V)(6D)), ((V)(15.6)), ((V)((-2D)))), ((V)(5D)), ((V)(4D)))), "forEach", Fn((V _arrowThis6093, int _argc6078, V _a6080, V _a6081, V _a6082, V _a6083, V[] _rest6079) => {
V S1_6094 = default;
V MS_6095 = default;
V Sr_6086 = default;
V c_6088 = default;
V rx_6090 = default;
V ry_6092 = default;
{ V _t6084 = ListOf(_a6080);
{ V _t6085 = GetIdx(_t6084, 0D);
Sr_6086 = _t6085; }
{ V _t6087 = GetIdx(_t6084, 1D);
c_6088 = _t6087; }
{ V _t6089 = GetIdx(_t6084, 2D);
rx_6090 = _t6089; }
{ V _t6091 = GetIdx(_t6084, 3D);
ry_6092 = _t6091; }
}
S1_6094 = Call(dec_44, V.Undef, ((V)("#3e3228")), NewObj(1).Put("op", ((V)(0.5))).V);
MS_6095 = Call(dec_44, V.Undef, ((V)("#5f9a3e")), NewObj(1).Put("op", ((V)(0.75))).V);
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis6102, int _argc6096, V _a6098, V _a6099, V _a6100, V _a6101, V[] _rest6097) => {
V p_6103 = default;
V n_6104 = default;
{ V _t6105 = Call(elS_4002, V.Undef, c_6088, rx_6090, ry_6092, rx_6090, Arr(((V)(((ToNum(Call(R_6032, V.Undef)) - 0.5) * 2D))), ((V)(((ToNum(Call(R_6032, V.Undef)) - 0.6) * 1.6))), ((V)(((ToNum(Call(R_6032, V.Undef)) - 0.5) * 2D)))));
{ V _t6106 = ListOf(_t6105);
{ V _t6107 = GetIdx(_t6106, 0D);
p_6103 = _t6107; }
{ V _t6108 = GetIdx(_t6106, 1D);
n_6104 = _t6108; }
} }
Call(spot_46, V.Undef, S1_6094, p_6103, n_6104, ((V)((0.4 + (ToNum(Call(R_6032, V.Undef)) * 0.5)))), ((V)(0.25)), ((V)((ToNum(Call(R_6032, V.Undef)) * 3D))), ((V)(6D)));
return default;
}, 0, "", true));
Call(rep_28, V.Undef, ((V)(4D)), Fn((V _arrowThis6115, int _argc6109, V _a6111, V _a6112, V _a6113, V _a6114, V[] _rest6110) => {
V p_6116 = default;
V n_6117 = default;
{ V _t6118 = Call(elS_4002, V.Undef, c_6088, rx_6090, ry_6092, rx_6090, Arr(((V)(((ToNum(Call(R_6032, V.Undef)) - 0.5) * 2D))), ((V)(0.7)), ((V)(((ToNum(Call(R_6032, V.Undef)) - 0.5) * 2D)))));
{ V _t6119 = ListOf(_t6118);
{ V _t6120 = GetIdx(_t6119, 0D);
p_6116 = _t6120; }
{ V _t6121 = GetIdx(_t6119, 1D);
n_6117 = _t6121; }
} }
Call(spot_46, V.Undef, MS_6095, p_6116, n_6117, ((V)(0.8)), ((V)(0.4)), ((V)((ToNum(Call(R_6032, V.Undef)) * 3D))), ((V)(7D)));
return default;
}, 0, "", true));
Call(on_6031, V.Undef, Sr_6086, Arr(S1_6094, MS_6095));
return default;
}, 1, "", true));
Call(on_6031, V.Undef, r2_6037, Arr(Call(rod_22, V.Undef, Arr(((V)(9.6)), ((V)(14.6)), ((V)((-3.4)))), Arr(((V)(12.4)), ((V)(13.4)), ((V)((-4.6)))), ((V)(0.7)), ((V)("#b07aff")), Call(em_3984, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(rod_22, V.Undef, Arr(((V)(9.2)), ((V)(13D)), ((V)((-2.4)))), Arr(((V)(11.4)), ((V)(11.2)), ((V)((-2.8)))), ((V)(0.5)), ((V)("#d0a8ff")), Call(em_3984, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(rod_22, V.Undef, Arr(((V)(8.8)), ((V)(15.8)), ((V)((-4.4)))), Arr(((V)(10.4)), ((V)(17.2)), ((V)((-5.6)))), ((V)(0.45)), ((V)("#9a6aff")), Call(em_3984, V.Undef, NewObj(1).Put("n", ((V)(6D))).V))), Arr(((V)(0.9)), ((V)(0D)), ((V)((-0.42)))));
Call(on_6031, V.Undef, r3_6038, Call(pipe_23, V.Undef, Arr(Arr(((V)(0.4)), ((V)(5.8)), ((V)(0.4))), Arr(((V)(0.9)), ((V)(4.9)), ((V)(1D))), Arr(((V)(0.6)), ((V)(4.2)), ((V)(1.6)))), ((V)(0.16)), ((V)("#5a3e28")), NewObj(1).Put("n", ((V)(4D))).V));
Call(on_6031, V.Undef, r1_6036, Call(pipe_23, V.Undef, Arr(Arr(((V)((-6D))), ((V)(10.9)), ((V)(4.5))), Arr(((V)((-6.6))), ((V)(8.4)), ((V)(5.4))), Arr(((V)((-6.2))), ((V)(6.6)), ((V)(6.2)))), ((V)(0.14)), ((V)("#5a3e28")), NewObj(1).Put("n", ((V)(4D))).V));
{
V rS_6122 = default;
V PB_6123 = default;
V RT_6124 = default;
V FR_6125 = default;
rS_6122 = Fn((V _arrowThis6133, int _argc6126, V y_6132, V _a6129, V _a6130, V _a6131, V[] _rest6127) => {
return ((V)((15.2 * (0.72 + ((0.28 * (ToNum(y_6132) - 33D)) / 5D)))));
}, 1, "", true);
PB_6123 = Call(dec_44, V.Undef, ((V)("#4a3a2a")), NewObj(1).Put("op", ((V)(0.75))).V);
RT_6124 = Call(dec_44, V.Undef, ((V)("#3a2a1a")), NewObj(1).Put("op", ((V)(0.6))).V);
FR_6125 = Call(dec_44, V.Undef, ((V)("#4f8a36")));
Call(rep_28, V.Undef, ((V)(30D)), Fn((V _arrowThis6140, int _argc6134, V _a6136, V _a6137, V _a6138, V _a6139, V[] _rest6135) => {
return Call(spotC_4000, V.Undef, PB_6123, ((V)(0D)), ((V)(0D)), rS_6122, ((V)(((ToNum(Call(R_6032, V.Undef)) * 2D) * PI_17))), ((V)((33.6 + (ToNum(Call(R_6032, V.Undef)) * 3.4)))), ((V)(0.28)), ((V)(0.22)));
}, 0, "", true));
Call(rep_28, V.Undef, ((V)(10D)), Fn((V _arrowThis6147, int _argc6141, V _a6143, V _a6144, V _a6145, V _a6146, V[] _rest6142) => {
double a_6148 = 0;
a_6148 = ((ToNum(Call(R_6032, V.Undef)) * 2D) * PI_17);
Invoke(RT_6124, "line", Call(wv_43, V.Undef, ((V)(4D)), Fn((V _arrowThis6156, int _argc6149, V t_6155, V _a6152, V _a6153, V _a6154, V[] _rest6150) => {
double y_6157 = 0;
y_6157 = (34D + (ToNum(t_6155) * 3D));
return Call(cP_3995, V.Undef, ((V)(0D)), ((V)(0D)), Call(rS_6122, V.Undef, ((V)(y_6157))), ((V)((a_6148 + (0.06 * FdLibm.Sin((ToNum(t_6155) * 6D)))))), ((V)(y_6157)));
return default;
}, 1, "", true)), Call(cN_42, V.Undef, ((V)(a_6148))), ((V)(0.12)));
return default;
}, 0, "", true));
Call(ringL_3997, V.Undef, FR_6125, ((V)(0D)), ((V)(0D)), rS_6122, ((V)(37.6)), ((V)(0.8)), ((V)(0D)), ((V)((2D * PI_17))), ((V)(48D)), Fn((V _arrowThis6165, int _argc6158, V a_6164, V _a6161, V _a6162, V _a6163, V[] _rest6159) => {
return ((V)((0.25 * FdLibm.Sin((ToNum(a_6164) * 9D)))));
}, 1, "", true));
Call(on_6031, V.Undef, SO_6034, Arr(PB_6123, RT_6124, FR_6125));
}
{
V top_6166 = default;
V LG_6167 = default;
V DG_6168 = default;
V GV_6169 = default;
V STn_6170 = default;
V PO_6171 = default;
V POh_6172 = default;
V LP_6173 = default;
V FLc_6174 = default;
V okP_6175 = default;
double h_6176 = 0;
V WN_6177 = default;
V LB_6178 = default;
top_6166 = Fn((V _arrowThis6187, int _argc6179, V x_6185, V z_6186, V _a6183, V _a6184, V[] _rest6180) => {
return Arr(x_6185, Call(gH_5917, V.Undef, x_6185, z_6186), z_6186);
}, 2, "", true);
LG_6167 = Call(dec_44, V.Undef, ((V)("#7ab84a")), NewObj(1).Put("op", ((V)(0.7))).V);
DG_6168 = Call(dec_44, V.Undef, ((V)("#3f6f2e")), NewObj(1).Put("op", ((V)(0.6))).V);
GV_6169 = Call(dec_44, V.Undef, ((V)("#e2dccd")));
STn_6170 = Call(dec_44, V.Undef, ((V)("#b8b3aa")));
PO_6171 = Call(dec_44, V.Undef, ((V)("#3a8ac0")), NewObj(1).Put("op", ((V)(0.9))).V);
POh_6172 = Call(dec_44, V.Undef, ((V)("#cdefff")), NewObj(1).Put("op", ((V)(0.6))).V);
LP_6173 = Call(dec_44, V.Undef, ((V)("#6fae46")));
FLc_6174 = Invoke(Arr(((V)("#ffffff")), ((V)("#f6a0b4")), ((V)("#ffe066"))), "map", Fn((V _arrowThis6195, int _argc6188, V c_6194, V _a6191, V _a6192, V _a6193, V[] _rest6189) => {
return Call(dec_44, V.Undef, c_6194);
}, 1, "", true));
okP_6175 = Fn((V _arrowThis6204, int _argc6196, V x_6202, V z_6203, V _a6200, V _a6201, V[] _rest6197) => {
return ((((Hypot((ToNum(x_6202) - 10.2), (ToNum(z_6203) - 5.2)) > 3.6) && (Hypot((ToNum(x_6202) - LX_5920), (ToNum(z_6203) - LZ_5921)) > 2.6)) && (Hypot(ToNum(x_6202), ToNum(z_6203)) > 3D)) ? V.True : V.False);
}, 2, "", true);
Call(speck_55, V.Undef, LG_6167, ((V)(80D)), Fn((V _arrowThis6213, int _argc6205, V u_6211, V v_6212, V _a6209, V _a6210, V[] _rest6206) => {
double a_6214 = 0;
double r_6215 = 0;
double x_6216 = 0;
double z_6217 = 0;
a_6214 = ((ToNum(u_6211) * 2D) * PI_17);
r_6215 = (System.Math.Sqrt(ToNum(v_6212)) * 14.8);
x_6216 = (FdLibm.Cos(a_6214) * r_6215);
z_6217 = (FdLibm.Sin(a_6214) * r_6215);
return (Truthy(Call(okP_6175, V.Undef, ((V)(x_6216)), ((V)(z_6217)))) ? Call(top_6166, V.Undef, ((V)(x_6216)), ((V)(z_6217))) : V.Null);
return default;
}, 2, "", true), Y3_40, ((V)(0.15)), ((V)(0.42)), R_6032);
Call(speck_55, V.Undef, DG_6168, ((V)(50D)), Fn((V _arrowThis6226, int _argc6218, V u_6224, V v_6225, V _a6222, V _a6223, V[] _rest6219) => {
double a_6227 = 0;
double r_6228 = 0;
double x_6229 = 0;
double z_6230 = 0;
a_6227 = ((ToNum(u_6224) * 2D) * PI_17);
r_6228 = (System.Math.Sqrt(ToNum(v_6225)) * 14.8);
x_6229 = (FdLibm.Cos(a_6227) * r_6228);
z_6230 = (FdLibm.Sin(a_6227) * r_6228);
return (Truthy(Call(okP_6175, V.Undef, ((V)(x_6229)), ((V)(z_6230)))) ? Call(top_6166, V.Undef, ((V)(x_6229)), ((V)(z_6230))) : V.Null);
return default;
}, 2, "", true), Y3_40, ((V)(0.15)), ((V)(0.4)), R_6032);
Call(rep_28, V.Undef, ((V)(28D)), Fn((V _arrowThis6238, int _argc6231, V i_6237, V _a6234, V _a6235, V _a6236, V[] _rest6232) => {
double t_6239 = 0;
double x_6240 = 0;
double z_6241 = 0;
t_6239 = (ToNum(i_6237) / 27D);
x_6240 = (((-12D) + (13D * t_6239)) + ((ToNum(Call(R_6032, V.Undef)) - 0.5) * 1.2));
z_6241 = (((9D - (11D * t_6239)) + (2D * FdLibm.Sin(((t_6239 * PI_17) * 2D)))) + ((ToNum(Call(R_6032, V.Undef)) - 0.5) * 1.2));
if ((Hypot(x_6240, z_6241) > 2.6)) {
Call(spot_46, V.Undef, GV_6169, Call(top_6166, V.Undef, ((V)(x_6240)), ((V)(z_6241))), Y3_40, ((V)((0.3 + (ToNum(Call(R_6032, V.Undef)) * 0.15)))), ((V)(0.24)), ((V)((ToNum(Call(R_6032, V.Undef)) * 3D))), ((V)(6D)));
}
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-8.6))), ((V)(1.4))), Arr(((V)((-5D))), ((V)((-1.6)))), Arr(((V)((-1.6))), ((V)((-3.4))))), "forEach", Fn((V _arrowThis6253, int _argc6242, V _a6244, V _a6245, V _a6246, V _a6247, V[] _rest6243) => {
V x_6250 = default;
V z_6252 = default;
{ V _t6248 = ListOf(_a6244);
{ V _t6249 = GetIdx(_t6248, 0D);
x_6250 = _t6249; }
{ V _t6251 = GetIdx(_t6248, 1D);
z_6252 = _t6251; }
}
return Call(spot_46, V.Undef, STn_6170, Call(top_6166, V.Undef, x_6250, z_6252), Y3_40, ((V)(1D)), ((V)(0.75)), x_6250, ((V)(10D)));
}, 1, "", true));
Invoke(PO_6171, "poly", Call(elP_45, V.Undef, Call(top_6166, V.Undef, ((V)(10.2)), ((V)(5.2))), X3_39, Z3_41, ((V)(2.8)), ((V)(2D)), ((V)(18D))), Y3_40);
Call(spot_46, V.Undef, POh_6172, Call(top_6166, V.Undef, ((V)(9.4)), ((V)(4.6))), Y3_40, ((V)(1.1)), ((V)(0.35)), ((V)(0.3)), ((V)(10D)));
Call(spot_46, V.Undef, LP_6173, Call(top_6166, V.Undef, ((V)(11.2)), ((V)(5.6))), Y3_40, ((V)(0.6)), ((V)(0.5)), ((V)(0D)), ((V)(8D)));
Call(spot_46, V.Undef, LP_6173, Call(top_6166, V.Undef, ((V)(9.6)), ((V)(6.2))), Y3_40, ((V)(0.45)), ((V)(0.4)), ((V)(0D)), ((V)(8D)));
Call(spot_46, V.Undef, GetIdx(FLc_6174, 1D), Call(top_6166, V.Undef, ((V)(11.1)), ((V)(5.5))), Y3_40, ((V)(0.22)), ((V)(0.22)), ((V)(0D)), ((V)(6D)));
Call(rep_28, V.Undef, ((V)(22D)), Fn((V _arrowThis6261, int _argc6254, V i_6260, V _a6257, V _a6258, V _a6259, V[] _rest6255) => {
double a_6262 = 0;
double r_6263 = 0;
double x_6264 = 0;
double z_6265 = 0;
a_6262 = ((ToNum(Call(R_6032, V.Undef)) * 2D) * PI_17);
r_6263 = (4D + (ToNum(Call(R_6032, V.Undef)) * 10.5));
x_6264 = (FdLibm.Cos(a_6262) * r_6263);
z_6265 = (FdLibm.Sin(a_6262) * r_6263);
if (Truthy(Call(okP_6175, V.Undef, ((V)(x_6264)), ((V)(z_6265))))) {
Call(spot_46, V.Undef, GetIdx(FLc_6174, (ToNum(i_6260) % 3D)), Call(top_6166, V.Undef, ((V)(x_6264)), ((V)(z_6265))), Y3_40, ((V)(0.2)), ((V)(0.2)), ((V)(0D)), ((V)(6D)));
}
return default;
}, 1, "", true));
Call(on_6031, V.Undef, GRb_6035, Invoke(Arr(DG_6168, LG_6167, GV_6169, STn_6170, PO_6171, POh_6172, LP_6173), "concat", FLc_6174));
h_6176 = (ToNum(Call(gH_5917, V.Undef, ((V)(LX_5920)), ((V)(LZ_5921)))) - 0.05);
WN_6177 = Call(dec_44, V.Undef, ((V)("#ffb85a")), NewObj(2).Put("emit", ((V)(1D))).Put("op", ((V)(0.95))).V);
LB_6178 = Call(box_11, V.Undef, ((V)(LX_5920)), ((V)((h_6176 + 2.9))), ((V)(LZ_5921)), ((V)(1.9)), ((V)(1.5)), ((V)(1.9)), ((V)("#a8a399")), NewObj(1).Put("r", ((V)(0.3))).V);
Call(on_6031, V.Undef, GRb_6035, Arr(Call(cyl_12, V.Undef, ((V)(LX_5920)), ((V)((h_6176 - 0.1))), ((V)(LZ_5921)), ((V)(1.3)), ((V)(0.6)), ((V)("#9a958c")), NewObj(1).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(LX_5920)), ((V)((h_6176 + 0.5))), ((V)(LZ_5921)), ((V)(0.9)), ((V)(2.4)), ((V)(0.9)), ((V)("#a8a399")), NewObj(1).Put("r", ((V)(0.2))).V), LB_6178));
Invoke(Arr(Arr(Z3_41, ((V)(0D)), ((V)(0.96))), Arr(Call(mul_36, V.Undef, Z3_41, ((V)((-1D)))), ((V)(0D)), ((V)((-0.96)))), Arr(X3_39, ((V)(0.96)), ((V)(0D))), Arr(Call(mul_36, V.Undef, X3_39, ((V)((-1D)))), ((V)((-0.96))), ((V)(0D)))), "forEach", Fn((V _arrowThis6279, int _argc6266, V _a6268, V _a6269, V _a6270, V _a6271, V[] _rest6267) => {
V c_6280 = default;
V u_6281 = default;
V n_6274 = default;
V dx_6276 = default;
V dz_6278 = default;
{ V _t6272 = ListOf(_a6268);
{ V _t6273 = GetIdx(_t6272, 0D);
n_6274 = _t6273; }
{ V _t6275 = GetIdx(_t6272, 1D);
dx_6276 = _t6275; }
{ V _t6277 = GetIdx(_t6272, 2D);
dz_6278 = _t6277; }
}
c_6280 = Arr(Add(((V)(LX_5920)), dx_6276), ((V)((h_6176 + 3.65))), Add(((V)(LZ_5921)), dz_6278));
u_6281 = ((System.Math.Abs(ToNum(GetIdx(n_6274, 0D))) > 0.5) ? Z3_41 : X3_39);
Invoke(WN_6177, "poly", Arr(Call(add_34, V.Undef, c_6280, Call(add_34, V.Undef, Call(mul_36, V.Undef, u_6281, ((V)((-0.45)))), Arr(((V)(0D)), ((V)((-0.45))), ((V)(0D))))), Call(add_34, V.Undef, c_6280, Call(add_34, V.Undef, Call(mul_36, V.Undef, u_6281, ((V)(0.45))), Arr(((V)(0D)), ((V)((-0.45))), ((V)(0D))))), Call(add_34, V.Undef, c_6280, Call(add_34, V.Undef, Call(mul_36, V.Undef, u_6281, ((V)(0.45))), Arr(((V)(0D)), ((V)(0.45)), ((V)(0D))))), Call(add_34, V.Undef, c_6280, Call(add_34, V.Undef, Call(mul_36, V.Undef, u_6281, ((V)((-0.45)))), Arr(((V)(0D)), ((V)(0.45)), ((V)(0D)))))), n_6274);
return default;
}, 1, "", true));
Call(on_6031, V.Undef, LB_6178, Arr(WN_6177));
Call(on_6031, V.Undef, GRb_6035, Arr(Call(cyl_12, V.Undef, ((V)(LX_5920)), ((V)((h_6176 + 4.4))), ((V)(LZ_5921)), ((V)(2.2)), ((V)(1D)), ((V)("#8a857c")), NewObj(2).Put("n", ((V)(6D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(0.3)), ((V)(0D)), ((V)(1.05))), Arr(((V)(1D)), ((V)(0D)), ((V)(0.25))))).V), Call(ball_13, V.Undef, ((V)(LX_5920)), ((V)((h_6176 + 5.6))), ((V)(LZ_5921)), ((V)(0.35)), ((V)("#8a857c")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V)));
}
return o_6030;
return default;
}, 0, "build", true)).V))).Put("fx", Fn((V _arrowThis6289, int _argc6282, V c_6288, V _a6285, V _a6286, V _a6287, V[] _rest6283) => {
V F_6290 = default;
V k_6291 = default;
V q_6292 = default;
double Rr_6293 = 0;
V lq_6294 = default;
V pq_6295 = default;
V mv_6296 = default;
V orb_6297 = default;
V bb0_6298 = default;
F_6290 = Invoke(B_5912, "fx", c_6288);
k_6291 = Get(c_6288, "k");
q_6292 = Invoke(c_6288, "p", ((V)(0D)), ((V)(OC_5918)), ((V)(0D)));
Rr_6293 = (OR_5919 * ToNum(k_6291));
lq_6294 = Invoke(c_6288, "p", ((V)(LX_5920)), Add(Call(gH_5917, V.Undef, ((V)(LX_5920)), ((V)(LZ_5921))), ((V)(3.6))), ((V)(LZ_5921)));
pq_6295 = Invoke(c_6288, "p", ((V)(10.2)), Call(gH_5917, V.Undef, ((V)(10.2)), ((V)(5.2))), ((V)(5.2)));
mv_6296 = Call(atS_3989, V.Undef, ((V)("translate")), ((V)("0 0;0 -4;0 0")), ((V)(4D)));
orb_6297 = ((V)(JsStrBuf.Begin().S("<g>").V(mv_6296).S("<ellipse cx=\"").V(Call(f1_3980, V.Undef, GetIdx(lq_6294, 0D))).S("\" cy=\"").V(Call(f1_3980, V.Undef, GetIdx(lq_6294, 1D))).S("\" rx=\"").V(Call(f1_3980, V.Undef, ((V)((4D * ToNum(k_6291)))))).S("\" ry=\"").V(Call(f1_3980, V.Undef, ((V)((4D * ToNum(k_6291)))))).S("\" fill=\"url(#q25lg)\">").V(Call(an_3983, V.Undef, ((V)("opacity")), ((V)("0.55;0.9;0.6;0.85;0.55")), ((V)(2.2)))).S("</ellipse>").S("<ellipse cx=\"").V(Call(f1_3980, V.Undef, GetIdx(pq_6295, 0D))).S("\" cy=\"").V(Call(f1_3980, V.Undef, GetIdx(pq_6295, 1D))).S("\" rx=\"").V(Call(f1_3980, V.Undef, ((V)((1.4 * ToNum(k_6291)))))).S("\" ry=\"").V(Call(f1_3980, V.Undef, ((V)(((1.4 * ToNum(k_6291)) * ToNum(Get(X_9, "SA"))))))).S("\" fill=\"none\" stroke=\"#e8fbff\" stroke-width=\"").V(Call(f1_3980, V.Undef, ((V)((0.18 * ToNum(k_6291)))))).S("\">").V(Call(an_3983, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_3980, V.Undef, ((V)((0.6 * ToNum(k_6291)))))).S(";").V(Call(f1_3980, V.Undef, ((V)((2.6 * ToNum(k_6291)))))).End())), ((V)(2.4)))).V(Call(an_3983, V.Undef, ((V)("ry")), ((V)(JsStrBuf.Begin().V(Call(f1_3980, V.Undef, ((V)(((0.6 * ToNum(k_6291)) * ToNum(Get(X_9, "SA"))))))).S(";").V(Call(f1_3980, V.Undef, ((V)(((2.6 * ToNum(k_6291)) * ToNum(Get(X_9, "SA"))))))).End())), ((V)(2.4)))).V(Call(an_3983, V.Undef, ((V)("opacity")), ((V)("0.9;0")), ((V)(2.4)))).S("</ellipse>").S("<circle cx=\"").V(Call(f1_3980, V.Undef, GetIdx(q_6292, 0D))).S("\" cy=\"").V(Call(f1_3980, V.Undef, GetIdx(q_6292, 1D))).S("\" r=\"").V(Call(f1_3980, V.Undef, ((V)(Rr_6293)))).S("\" fill=\"url(#q25orb)\" stroke=\"#dff6ff\" stroke-opacity=\"0.55\" stroke-width=\"").V(Call(f1_3980, V.Undef, ((V)((0.35 * ToNum(k_6291)))))).S("\"/>").S("<path d=\"M").V(Call(f1_3980, V.Undef, ((V)((ToNum(GetIdx(q_6292, 0D)) - (Rr_6293 * 0.78)))))).S(" ").V(Call(f1_3980, V.Undef, ((V)((ToNum(GetIdx(q_6292, 1D)) - (Rr_6293 * 0.3)))))).S("A").V(Call(f1_3980, V.Undef, ((V)((Rr_6293 * 0.84))))).S(" ").V(Call(f1_3980, V.Undef, ((V)((Rr_6293 * 0.84))))).S(" 0 0 1 ").V(Call(f1_3980, V.Undef, ((V)((ToNum(GetIdx(q_6292, 0D)) - (Rr_6293 * 0.18)))))).S(" ").V(Call(f1_3980, V.Undef, ((V)((ToNum(GetIdx(q_6292, 1D)) - (Rr_6293 * 0.82)))))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_3980, V.Undef, ((V)((1.1 * ToNum(k_6291)))))).S("\" stroke-linecap=\"round\" opacity=\"0.55\"/>").S("<ellipse cx=\"").V(Call(f1_3980, V.Undef, Add(GetIdx(q_6292, 0D), ((V)((Rr_6293 * 0.5)))))).S("\" cy=\"").V(Call(f1_3980, V.Undef, Add(GetIdx(q_6292, 1D), ((V)((Rr_6293 * 0.55)))))).S("\" rx=\"").V(Call(f1_3980, V.Undef, ((V)((Rr_6293 * 0.2))))).S("\" ry=\"").V(Call(f1_3980, V.Undef, ((V)((Rr_6293 * 0.07))))).S("\" transform=\"rotate(-40 ").V(Call(f1_3980, V.Undef, Add(GetIdx(q_6292, 0D), ((V)((Rr_6293 * 0.5)))))).S(" ").V(Call(f1_3980, V.Undef, Add(GetIdx(q_6292, 1D), ((V)((Rr_6293 * 0.55)))))).S(")\" fill=\"#ffffff\" opacity=\"0.25\"/>").S("<circle cx=\"").V(Call(f1_3980, V.Undef, ((V)((ToNum(GetIdx(q_6292, 0D)) - (Rr_6293 * 0.5)))))).S("\" cy=\"").V(Call(f1_3980, V.Undef, ((V)((ToNum(GetIdx(q_6292, 1D)) - (Rr_6293 * 0.56)))))).S("\" r=\"").V(Call(f1_3980, V.Undef, ((V)((0.9 * ToNum(k_6291)))))).S("\" fill=\"#ffffff\">").V(Call(an_3983, V.Undef, ((V)("opacity")), ((V)("0.2;1;0.2")), ((V)(3.6)))).S("</circle></g>").End()));
bb0_6298 = (Get(F_6290, "bb") is var _t6299 && Truthy(_t6299) ? _t6299 : Arr(GetIdx(q_6292, 0D), GetIdx(q_6292, 1D), GetIdx(q_6292, 0D), GetIdx(q_6292, 1D)));
return Object_assign(NewObj(0).V, F_6290, NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(Add((Get(F_6290, "defs") is var _t6300 && Truthy(_t6300) ? _t6300 : ((V)(""))), Call(RG_3987, V.Undef, ((V)("q25lg")), ((V)("#ffe2a0")), ((V)("#ffb85a")), ((V)(0.6))))).S("<radialGradient id=\"q25orb\" cx=\"38%\" cy=\"32%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.06\"/><stop offset=\"0.75\" stop-color=\"#cfeefa\" stop-opacity=\"0.08\"/><stop offset=\"1\" stop-color=\"#9fd8f0\" stop-opacity=\"0.3\"/></radialGradient>").End()))).Put("front", Add((Get(F_6290, "front") is var _t6301 && Truthy(_t6301) ? _t6301 : ((V)(""))), orb_6297)).Put("bb", Arr(((V)(Min(ToNum(GetIdx(bb0_6298, 0D)), ((ToNum(GetIdx(q_6292, 0D)) - Rr_6293) - 2D)))), ((V)(Min(ToNum(GetIdx(bb0_6298, 1D)), ((ToNum(GetIdx(q_6292, 1D)) - Rr_6293) - 6D)))), ((V)(Max(ToNum(GetIdx(bb0_6298, 2D)), ToNum(Add(Add(GetIdx(q_6292, 0D), ((V)(Rr_6293))), ((V)(2D))))))), ((V)(Max(ToNum(GetIdx(bb0_6298, 3D)), ToNum(Add(Add(GetIdx(q_6292, 1D), ((V)(Rr_6293))), ((V)(2D))))))))).V);
return default;
}, 1, "fx", true)).V);
return default;
}, 1, "", true));
}
Set(RD_8, "SET24", NewObj(23).Put("LIV-002", NewObj(2).Put("spec", ((V)("torch24"))).Put("note", ((V)("A cheap grey torchiere: scuffed, rusty base with a $4.99 sticker, a bent pole with rust streaks and a rotary switch, held together with wrinkled tape, a bendy gooseneck and a ribbed plastic bowl shade with a scorch mark and two cracks. The bulb flickers now and then."))).V).Put("LIV-042", NewObj(2).Put("spec", ((V)("arc24"))).Put("note", ((V)("A chrome arc with jointed collars that rises from a veined white marble block and curves over the sofa, ending in a vented, mirror-shiny dome shade that throws a pool of warm light below. A foot switch on the cord."))).V).Put("LIV-062", NewObj(2).Put("spec", ((V)("alab24"))).Put("note", ((V)("A totem of six smooth alabaster stones with amber and white veins and cloudy inclusions, stacked on grooved bronze spacers over a patinated base. Light glows through the stones and slowly breathes from one to the next."))).V).Put("LIV-082", NewObj(2).Put("spec", ((V)("bio24"))).Put("note", ((V)("A glass column ribbed in brass, misted with drops, on a carved stone pot with glowing runes. A glowing vine spirals up inside, moss and tiny glowing mushrooms ring its foot. Spores drift up and a pulse of light climbs the vine."))).V).Put("LIV-023", NewObj(2).Put("spec", ((V)("iron24"))).Put("note", ((V)("A slim black iron frame with green-edged glass top and shelf: keys, a coin and a letter in the brass tray, a framed photo and a succulent on top, a woven basket with a knit throw and books below."))).V).Put("LIV-063", NewObj(2).Put("spec", ((V)("burl24"))).Put("note", ((V)("A swirly burl-wood top full of tiny burl eyes under a glossy lacquer, on fluted brass legs with a gallery rail at the back. A brass bowl of fruit, a veined stone orb and art books on top."))).V).Put("LIV-083", NewObj(3).Put("spec", ((V)("liquid24"))).Put("live", ((V)("Dripping"))).Put("note", ((V)("A mirror-chrome console that looks poured: its legs flow up like liquid metal into the top, reflecting the room. Drips hang under the edge, a shine sweeps across, ripples spread on the top and a drop drips down into a little puddle. A dried branch in a black vase."))).V).Put("LIV-056", NewObj(2).Put("spec", ((V)("live24"))).Put("note", ((V)("A thick walnut slab with flowing grain around two knots, a resin-filled crack held by two wooden bowties and a pale sapwood rim with bits of bark, on black steel frames. A turned bowl of moss balls, a latte with a heart, a spoon and a book."))).V).Put("LIV-076", NewObj(2).Put("spec", ((V)("drum24"))).Put("note", ((V)("A big cream travertine drum with broken bands and little pores all round, nested with a smaller brushed, smoky bronze drum with a brass rim. A book, a brass orb and a white bowl of river stones."))).V).Put("LIV-019", NewObj(2).Put("spec", ((V)("crate24"))).Put("note", ((V)("A scuffed red plastic milk crate turned upside down, with a barcode sticker on the side, a cup of instant noodles and a fork on top, and a phone whose charger cable hangs over the side."))).V).Put("LIV-039", NewObj(2).Put("spec", ((V)("bistro24"))).Put("note", ((V)("A glossy white tulip table on one slim pedestal, with a bud vase holding a pink tulip, a little book and a cup of tea on a gold-rimmed saucer."))).V).Put("LIV-059", NewObj(2).Put("spec", ((V)("tambour24"))).Put("note", ((V)("A small grained-oak cabinet on brass-capped legs with a fluted tambour door slid half open to show books inside. A glass of water, reading glasses and a novel with a ribbon bookmark on top."))).V).Put("LIV-015", NewObj(2).Put("spec", ((V)("faux24"))).Put("note", ((V)("A drafty fake fireplace: a printed brick panel with a seam, nail heads, a sun-faded patch, scuffs, a gold star sticker and one corner peeling off, on a speckled tile hearth with a cracked tile. In the empty firebox a little space heater glows orange behind its guard, cord trailing past a paper ball. A grainy wood mantel with a water ring, a plastic clock that ticks and a dripping candle that flickers sideways; a sock dries on a pin, swinging in the draft."))).V).Put("LIV-055", NewObj(2).Put("spec", ((V)("mantel24"))).Put("note", ((V)("A classic white mantel: fluted pilasters, carved swags and bellflower drops on the frieze, a dentil crown and panelled sides, over a cleft black slate surround with brass trim and a flecked granite hearth. Ceramic gas logs with white ash and glowing cracks burn on a grate with blue-based flames in a sooty brick firebox behind a brass mesh screen; dripping candles flicker either side of a beaded gilt mirror."))).V).Put("LIV-095", NewObj(2).Put("spec", ((V)("etha24"))).Put("note", ((V)("A honed black basalt slab that seems to float on a warm under-glow, glass on three sides with green edges. A brushed steel burner sends up a row of flames and softly glowing water-vapour mist between glinting river stones; the flames reflect in the dark back glass and a little panel shows the flame level."))).V).Put("LIV-008", NewObj(2).Put("spec", ((V)("coupons25"))).Put("note", ((V)("A little stack of six clipped coupons in faded colours, each with dashed scissor lines and a price box, a paperclip on the top one (50\u00a2 OFF, long EXPIRED). Next to it a cork coaster with an old coffee ring, orange-handled scissors and a ballpoint pen."))).V).Put("LIV-028", NewObj(2).Put("spec", ((V)("candle25"))).Put("note", ((V)("A soy candle in an amber glass jar with a kraft lavender & fig label, a soft melt pool and a flickering flame, its wooden lid beside it. A speckled ceramic dish with a gold rim holds a ring, two pearl studs and a hair tie, next to a matchbox and a burnt match."))).V).Put("LIV-048", NewObj(2).Put("spec", ((V)("books25"))).Put("note", ((V)("Three cloth-bound art books stacked a little crooked, with gilt titles on the spines, debossed covers, worn corners and a red ribbon bookmark, a postcard tucked in the bottom one. A brass magnifying glass with a turned wooden handle lies on top."))).V).Put("LIV-068", NewObj(2).Put("spec", ((V)("ikebana25"))).Put("note", ((V)("A cut-crystal vase holding a plum branch in blossom, a leafy branch and a red camellia, on a cleft slate tray. Beside it an incense stick glows in a black dish of raked sand, its smoke curling up, with a wooden incense box, a little stone cairn and a moss ball."))).V).Put("LIV-088", NewObj(3).Put("spec", ((V)("chrono25"))).Put("live", ((V)("Levitating"))).Put("note", ((V)("A polished steel sphere with meridian lines, a gold equator and tiny stars floats above an obsidian base inlaid with brass and an engraved hour ring, inside armillary rings. Beside it, a rare iron meteorite covered in thumbprint dents sits on a walnut stand with a brass label."))).V).Put("LIV-020", NewObj(2).Put("spec", ((V)("pothos25"))).Put("note", ((V)("A half-wilted pothos in an old strawberry yogurt cup with a torn label, a taped crack, a bit of foil stuck to the rim and holes poked in the bottom, standing on its lid as a saucer with a little puddle and fallen leaves. A pink plastic spoon is stuck in the soil."))).V).Put("LIV-100", NewObj(3).Put("spec", ((V)("terra25"))).Put("live", ((V)("Levitating"))).Put("note", ((V)("A tiny sky island floats inside a glass orb above a glowing base with a water ring: a bonsai on a mossy lawn with a gravel path, stepping stones, a tiny pond with lily pads and a glowing stone lantern. The rocks underneath have moss, roots and glowing crystals, and a little waterfall spills over the edge."))).V).Put("LIV-099", NewObj(3).Put("spec", ((V)("lev24"))).Put("live", ((V)("Floating"))).Put("note", ((V)("A white round top ringed with tiny lights floats over a vented glowing base and gently bobs. Rings of light rise between them and the phone on the top charges wirelessly."))).V).V);
edit23_57 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis6309, int _argc6302, V rows_6308, V _a6305, V _a6306, V _a6307, V[] _rest6303) => {
return Invoke(Call(edit23_57, V.Undef, rows_6308), "map", Fn((V _arrowThis6317, int _argc6310, V r_6316, V _a6313, V _a6314, V _a6315, V[] _rest6311) => {
return (Truthy(GetK(Get(RD_8, "SET24"), Get(r_6316, "id"))) ? Object_assign(NewObj(0).V, r_6316, GetK(Get(RD_8, "SET24"), Get(r_6316, "id"))) : r_6316);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H24", NewObj(9).Put("dec", dec_44).Put("spot", spot_46).Put("elP", elP_45).Put("wv", wv_43).Put("at", at_49).Put("rrect", rrect_47).Put("ext", ext_50).Put("ringY", ringY_51).Put("ringC", ringC_52).V);
Set(RD_8, "PLUS24", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
