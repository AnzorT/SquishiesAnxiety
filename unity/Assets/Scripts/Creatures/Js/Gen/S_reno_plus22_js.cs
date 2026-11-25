// reno-plus22.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus22_js
    {

        public static void Run()
        {
Call(Named(boot_63 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V box_11 = default;
V cyl_12 = default;
V ball_13 = default;
V slab_14 = default;
V slabX_15 = default;
V arcW_16 = default;
V disc_17 = default;
V shade_18 = default;
V mix_19 = default;
V f1_20 = default;
V N_21 = default;
double PI_22 = 0;
V GOLD_23 = default;
V CH_24 = default;
V BR_25 = default;
V loft_26 = default;
V tilt_27 = default;
V tiltAll_28 = default;
V rotF_29 = default;
V rod_30 = default;
V pipe_31 = default;
V fxEll_32 = default;
V frame_33 = default;
V bobA_34 = default;
V an_35 = default;
V FONT_36 = default;
V W__37 = default;
V M__38 = default;
V F__39 = default;
V PL_40 = default;
V G__41 = default;
V em_42 = default;
V rep_43 = default;
V P2_44 = default;
V n4_45 = default;
V R0_46 = default;
V rp_47 = default;
V glue_48 = default;
V prism_49 = default;
V band_50 = default;
V RG_51 = default;
V ell_52 = default;
V TOP_53 = default;
V book_54 = default;
V mug_55 = default;
V sprig_56 = default;
V ST62_57 = default;
V edit21_58 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((RD_8 is var _t59 && !Truthy(_t59) ? _t59 : Get(RD_8, "PLUS21")) is var _t60 && !Truthy(_t60) ? _t60 : Get(RD_8, "H16")) is var _t61 && !Truthy(_t61) ? _t61 : X_9) is var _t62 && !Truthy(_t62) ? _t62 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_63.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS22"))) {
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
{ V _t68 = Get(_t64, "slab");
slab_14 = _t68; }
{ V _t69 = Get(_t64, "slabX");
slabX_15 = _t69; }
{ V _t70 = Get(_t64, "arcW");
arcW_16 = _t70; }
{ V _t71 = Get(_t64, "disc");
disc_17 = _t71; }
{ V _t72 = Get(_t64, "shade");
shade_18 = _t72; }
{ V _t73 = Get(_t64, "mix");
mix_19 = _t73; }
{ V _t74 = Get(_t64, "f1");
f1_20 = _t74; } }
N_21 = Get(RD_8, "N");
PI_22 = System.Math.PI;
GOLD_23 = ((V)("#e2b14a"));
CH_24 = ((V)("#d5dde2"));
BR_25 = ((V)("#d4a548"));
{ V _t75 = Get(RD_8, "H16");
if (_t75.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t75));
{ V _t76 = Get(_t75, "loft");
loft_26 = _t76; }
{ V _t77 = Get(_t75, "tilt");
tilt_27 = _t77; }
{ V _t78 = Get(_t75, "tiltAll");
tiltAll_28 = _t78; }
{ V _t79 = Get(_t75, "rotF");
rotF_29 = _t79; }
{ V _t80 = Get(_t75, "rod");
rod_30 = _t80; }
{ V _t81 = Get(_t75, "pipe");
pipe_31 = _t81; }
{ V _t82 = Get(_t75, "fxEll");
fxEll_32 = _t82; }
{ V _t83 = Get(_t75, "frame");
frame_33 = _t83; }
{ V _t84 = Get(_t75, "bobA");
bobA_34 = _t84; }
{ V _t85 = Get(_t75, "an");
an_35 = _t85; }
{ V _t86 = Get(_t75, "FONT");
FONT_36 = _t86; }
{ V _t87 = Get(_t75, "W_");
W__37 = _t87; }
{ V _t88 = Get(_t75, "M_");
M__38 = _t88; }
{ V _t89 = Get(_t75, "F_");
F__39 = _t89; }
{ V _t90 = Get(_t75, "PL");
PL_40 = _t90; }
{ V _t91 = Get(_t75, "G_");
G__41 = _t91; }
{ V _t92 = Get(_t75, "em");
em_42 = _t92; }
{ V _t93 = Get(_t75, "rep");
rep_43 = _t93; } }
P2_44 = Fn((V _arrowThis101, int _argc94, V q_100, V _a97, V _a98, V _a99, V[] _rest95) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(q_100, 0D))).S(" ").V(Call(f1_20, V.Undef, GetIdx(q_100, 1D))).End()));
}, 1, "", true);
n4_45 = Fn((V _arrowThis109, int _argc102, V v_108, V _a105, V _a106, V _a107, V[] _rest103) => {
return ((V)((Round((ToNum(v_108) * 10000D)) / 10000D)));
}, 1, "", true);
R0_46 = Fn((V _arrowThis117, int _argc110, V s_116, V _a113, V _a114, V _a115, V[] _rest111) => {
V h_118 = default;
h_118 = ((V)(7D));
{
foreach (V _k119 in new JsIter(((V)(ToStrS(s_116))))) {
V ch_120 = default;
ch_120 = _k119;
h_118 = ((V)(((double)(ToInt32(ToNum(Add(((V)((ToNum(h_118) * 31D))), Invoke(ch_120, "charCodeAt", ((V)(0D)))))) | ToInt32(0D)))));
}
}
h_118 = (((V)(System.Math.Abs(ToNum(h_118)))) is var _t121 && Truthy(_t121) ? _t121 : ((V)(1D)));
return Fn((V _arrowThis128, int _argc122, V _a124, V _a125, V _a126, V _a127, V[] _rest123) => {
h_118 = ((V)(((double)(ToInt32(((ToNum(h_118) * 1103515245D) + 12345D)) | ToInt32(0D)))));
return ((V)((((double)(ToInt32(((double)(ToUint32(ToNum(h_118)) >> (int)(ToUint32(8D) & 31)))) & ToInt32(65535D))) / 65536D)));
return default;
}, 0, "", true);
return default;
}, 1, "", true);
rp_47 = Fn((V _arrowThis138, int _argc129, V R_135, V p_136, V v_137, V _a134, V[] _rest130) => {
V q_139 = default;
q_139 = Call(R_135, V.Undef, Arr(((V)((ToNum(GetIdx(v_137, 0D)) - ToNum(GetIdx(p_136, 0D))))), ((V)((ToNum(GetIdx(v_137, 1D)) - ToNum(GetIdx(p_136, 1D))))), ((V)((ToNum(GetIdx(v_137, 2D)) - ToNum(GetIdx(p_136, 2D)))))));
return Arr(Add(GetIdx(q_139, 0D), GetIdx(p_136, 0D)), Add(GetIdx(q_139, 1D), GetIdx(p_136, 1D)), Add(GetIdx(q_139, 2D), GetIdx(p_136, 2D)));
return default;
}, 3, "", true);
glue_48 = Fn((V _arrowThis147, int _argc140, V o_146, V _a143, V _a144, V _a145, V[] _rest141) => {
return Fn((V _arrowThis157, int _argc148, V p_154, V L_155, V fn_156, V _a153, V[] _rest149) => {
return Invoke(L_155, "map", Fn((V _arrowThis165, int _argc158, V k_164, V _a161, V _a162, V _a163, V[] _rest159) => {
Set(k_164, "par", p_154);
if (Truthy(fn_156)) {
Set(k_164, "fn", fn_156);
}
Invoke(o_146, "push", k_164);
return k_164;
return default;
}, 1, "", true));
}, 3, "", true);
}, 1, "", true);
prism_49 = Fn((V _arrowThis177, int _argc166, V poly_172, V y_173, V h_174, V col_175, V[] _rest167) => {
V n_178 = default;
V B_179 = default;
V T_180 = default;
V faces_181 = default;
double cx_182 = 0;
double cz_183 = 0;
V o_176 = default;
o_176 = (_argc166 > 4 ? _rest167[0] : V.Undef);
n_178 = Get(poly_172, "length");
B_179 = Invoke(poly_172, "map", Fn((V _arrowThis195, int _argc184, V _a186, V _a187, V _a188, V _a189, V[] _rest185) => {
V x_192 = default;
V z_194 = default;
{ V _t190 = ListOf(_a186);
{ V _t191 = GetIdx(_t190, 0D);
x_192 = _t191; }
{ V _t193 = GetIdx(_t190, 1D);
z_194 = _t193; }
}
return Arr(x_192, y_173, z_194);
}, 1, "", true));
T_180 = Invoke(poly_172, "map", Fn((V _arrowThis207, int _argc196, V _a198, V _a199, V _a200, V _a201, V[] _rest197) => {
V x_204 = default;
V z_206 = default;
{ V _t202 = ListOf(_a198);
{ V _t203 = GetIdx(_t202, 0D);
x_204 = _t203; }
{ V _t205 = GetIdx(_t202, 1D);
z_206 = _t205; }
}
return Arr(x_204, Add(y_173, h_174), z_206);
}, 1, "", true));
faces_181 = Arr();
cx_182 = 0D;
cz_183 = 0D;
Invoke(poly_172, "forEach", Fn((V _arrowThis215, int _argc208, V p_214, V _a211, V _a212, V _a213, V[] _rest209) => {
cx_182 = (cx_182 + (ToNum(GetIdx(p_214, 0D)) / ToNum(n_178)));
cz_183 = (cz_183 + (ToNum(GetIdx(p_214, 1D)) / ToNum(n_178)));
return default;
}, 1, "", true));
{
double i_216 = 0;
i_216 = 0D;
while (true) {
if (!(Lt(((V)(i_216)), n_178))) break;
double j_218 = 0;
double dx_219 = 0;
double dz_220 = 0;
V L_221 = default;
V nn_222 = default;
j_218 = ((i_216 + 1D) % ToNum(n_178));
dx_219 = (ToNum(GetIdx(GetIdx(poly_172, j_218), 0D)) - ToNum(GetIdx(GetIdx(poly_172, i_216), 0D)));
dz_220 = (ToNum(GetIdx(GetIdx(poly_172, j_218), 1D)) - ToNum(GetIdx(GetIdx(poly_172, i_216), 1D)));
L_221 = (((V)(Hypot(dx_219, dz_220))) is var _t223 && Truthy(_t223) ? _t223 : ((V)(1D)));
nn_222 = Arr(((V)((dz_220 / ToNum(L_221)))), ((V)(0D)), ((V)(((-dx_219) / ToNum(L_221)))));
if ((((ToNum(GetIdx(nn_222, 0D)) * ((ToNum(Add(GetIdx(GetIdx(poly_172, i_216), 0D), GetIdx(GetIdx(poly_172, j_218), 0D))) / 2D) - cx_182)) + (ToNum(GetIdx(nn_222, 2D)) * ((ToNum(Add(GetIdx(GetIdx(poly_172, i_216), 1D), GetIdx(GetIdx(poly_172, j_218), 1D))) / 2D) - cz_183))) < 0D)) {
nn_222 = Invoke(nn_222, "map", Fn((V _arrowThis231, int _argc224, V v_230, V _a227, V _a228, V _a229, V[] _rest225) => {
return ((V)((-ToNum(v_230))));
}, 1, "", true));
}
Invoke(faces_181, "push", NewObj(2).Put("q", Arr(GetIdx(B_179, i_216), GetIdx(B_179, j_218), GetIdx(T_180, j_218), GetIdx(T_180, i_216))).Put("n", nn_222).V);
i_216++;
}
}
Invoke(faces_181, "push", NewObj(3).Put("q", B_179).Put("n", Arr(((V)(0D)), ((V)((-1D))), ((V)(0D)))).Put("cap", ((V)(1D))).V, NewObj(3).Put("q", T_180).Put("n", Arr(((V)(0D)), ((V)(1D)), ((V)(0D)))).Put("cap", ((V)(2D))).V);
return Object_assign(NewObj(5).Put("faces", faces_181).Put("pts", Invoke(B_179, "concat", T_180)).Put("col", col_175).Put("cv", ((V)(1D))).Put("zb", ((V)(0D))).V, (o_176 is var _t232 && Truthy(_t232) ? _t232 : NewObj(0).V));
return default;
}, 5, "", true);
band_50 = Fn((V _arrowThis246, int _argc233, V x_239, V y_240, V z_241, V r_242, V[] _rest234) => {
V S_247 = default;
V h_243 = default;
V col_244 = default;
V o_245 = default;
h_243 = (_argc233 > 4 ? _rest234[0] : V.Undef);
col_244 = (_argc233 > 5 ? _rest234[1] : V.Undef);
o_245 = (_argc233 > 6 ? _rest234[2] : V.Undef);
S_247 = Call(arcW_16, V.Undef, x_239, y_240, z_241, r_242, r_242, ((V)(0.2)), h_243, ((V)(0D)), ((V)((2D * PI_22))), col_244, Object_assign(NewObj(1).Put("n", ((V)(30D))).V, (o_245 is var _t248 && Truthy(_t248) ? _t248 : NewObj(0).V)));
Set(S_247, "faces", Invoke(Get(S_247, "faces"), "filter", Fn((V _arrowThis256, int _argc249, V F_255, V _a252, V _a253, V _a254, V[] _rest250) => {
V m_257 = default;
if ((System.Math.Abs(ToNum(GetIdx(Get(F_255, "n"), 1D))) > 0.5)) {
return (false ? V.True : V.False);
}
m_257 = Invoke(Get(F_255, "q"), "reduce", Fn((V _arrowThis266, int _argc258, V a_264, V q_265, V _a262, V _a263, V[] _rest259) => {
return Arr(Add(GetIdx(a_264, 0D), ((V)((ToNum(GetIdx(q_265, 0D)) / ToNum(Get(Get(F_255, "q"), "length")))))), Add(GetIdx(a_264, 1D), ((V)((ToNum(GetIdx(q_265, 2D)) / ToNum(Get(Get(F_255, "q"), "length")))))));
}, 2, "", true), Arr(((V)(0D)), ((V)(0D))));
return ((((ToNum(GetIdx(Get(F_255, "n"), 0D)) * (ToNum(GetIdx(m_257, 0D)) - ToNum(x_239))) + (ToNum(GetIdx(Get(F_255, "n"), 2D)) * (ToNum(GetIdx(m_257, 1D)) - ToNum(z_241)))) > 0D) ? V.True : V.False);
return default;
}, 1, "", true)));
return S_247;
return default;
}, 7, "", true);
RG_51 = Fn((V _arrowThis277, int _argc267, V id_273, V c0_274, V c1_275, V o0_276, V[] _rest268) => {
return ((V)(JsStrBuf.Begin().S("<radialGradient id=\"").V(id_273).S("\"><stop offset=\"0\" stop-color=\"").V(c0_274).S("\" stop-opacity=\"").V((o0_276.IsNullish ? ((V)(0.9)) : o0_276)).S("\"/><stop offset=\"1\" stop-color=\"").V((c1_275 is var _t278 && Truthy(_t278) ? _t278 : c0_274)).S("\" stop-opacity=\"0\"/></radialGradient>").End()));
}, 4, "", true);
ell_52 = Fn((V _arrowThis292, int _argc279, V c_285, V q_286, V rx_287, V ry_288, V[] _rest280) => {
V fill_289 = default;
V extra_290 = default;
V op_291 = default;
fill_289 = (_argc279 > 4 ? _rest280[0] : V.Undef);
extra_290 = (_argc279 > 5 ? _rest280[1] : V.Undef);
op_291 = (_argc279 > 6 ? _rest280[2] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_20, V.Undef, GetIdx(q_286, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(q_286, 1D))).S("\" rx=\"").V(Call(f1_20, V.Undef, rx_287)).S("\" ry=\"").V(Call(f1_20, V.Undef, ry_288)).S("\" fill=\"").V(fill_289).S("\"").S((!op_291.IsNullish ? JsStrBuf.Begin().S(" opacity=\"").V(op_291).S("\"").End() : "")).S(">").V((extra_290 is var _t293 && Truthy(_t293) ? _t293 : ((V)("")))).S("</ellipse>").End()));
}, 7, "", true);
TOP_53 = Fn((V _arrowThis304, int _argc294, V c_300, V y_301, V x_302, V z_303, V[] _rest295) => {
return Call(frame_33, V.Undef, Get(c_300, "p"), Arr((x_302 is var _t305 && Truthy(_t305) ? _t305 : ((V)(0D))), y_301, (z_303 is var _t306 && Truthy(_t306) ? _t306 : ((V)(0D)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
}, 4, "", true);
book_54 = Fn((V _arrowThis321, int _argc307, V x_313, V y_314, V z_315, V w_316, V[] _rest308) => {
double s_322 = 0;
double c_323 = 0;
V B_324 = default;
V P_325 = default;
V h_317 = default;
V d_318 = default;
V col_319 = default;
V yaw_320 = default;
h_317 = (_argc307 > 4 ? _rest308[0] : V.Undef);
d_318 = (_argc307 > 5 ? _rest308[1] : V.Undef);
col_319 = (_argc307 > 6 ? _rest308[2] : V.Undef);
yaw_320 = (_argc307 > 7 ? _rest308[3] : V.Undef);
yaw_320 = (yaw_320 is var _t326 && Truthy(_t326) ? _t326 : ((V)(0D)));
s_322 = FdLibm.Sin(ToNum(yaw_320));
c_323 = FdLibm.Cos(ToNum(yaw_320));
B_324 = Call(box_11, V.Undef, x_313, y_314, z_315, w_316, h_317, d_318, col_319, Call(PL_40, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("yaw", yaw_320).V));
P_325 = Call(box_11, V.Undef, ((V)((ToNum(x_313) - (s_322 * ((ToNum(d_318) / 2D) + 0.03))))), Add(y_314, ((V)(0.35))), Add(z_315, ((V)((c_323 * ((ToNum(d_318) / 2D) + 0.03))))), ((V)((ToNum(w_316) - 1.2))), ((V)((ToNum(h_317) - 0.7))), ((V)(0.06)), ((V)("#f6f0e2")), NewObj(3).Put("r", ((V)(0D))).Put("yaw", yaw_320).Put("noOut", ((V)(1D))).V);
Set(P_325, "par", B_324);
Set(P_325, "fn", Arr(((V)((-s_322))), ((V)(0D)), ((V)(c_323))));
return Arr(B_324, P_325);
return default;
}, 8, "", true);
mug_55 = Fn((V _arrowThis338, int _argc327, V o_333, V x_334, V y_335, V z_336, V[] _rest328) => {
V col_337 = default;
col_337 = (_argc327 > 4 ? _rest328[0] : V.Undef);
Invoke(o_333, "push", Call(cyl_12, V.Undef, x_334, y_335, z_336, ((V)(3.4)), ((V)(7D)), col_337, NewObj(3).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.92))), Arr(((V)(7D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_12, V.Undef, x_334, Add(y_335, ((V)(6.7))), z_336, ((V)(2.9)), ((V)(0.3)), ((V)("#5a3418")), NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V));
Invoke(Call(pipe_31, V.Undef, Arr(Arr(Add(x_334, ((V)(3.1))), Add(y_335, ((V)(5.6))), z_336), Arr(Add(x_334, ((V)(5.4))), Add(y_335, ((V)(5.2))), z_336), Arr(Add(x_334, ((V)(5.4))), Add(y_335, ((V)(2.4))), z_336), Arr(Add(x_334, ((V)(3.1))), Add(y_335, ((V)(2D))), z_336)), ((V)(0.55)), col_337, NewObj(2).Put("mat", ((V)("cer"))).Put("n", ((V)(5D))).V), "forEach", Fn((V _arrowThis346, int _argc339, V s_345, V _a342, V _a343, V _a344, V[] _rest340) => {
return Invoke(o_333, "push", s_345);
}, 1, "", true));
return default;
}, 5, "", true);
sprig_56 = Fn((V _arrowThis360, int _argc347, V o_353, V x_354, V y_355, V z_356, V[] _rest348) => {
V R_357 = default;
V col_358 = default;
V n_359 = default;
R_357 = (_argc347 > 4 ? _rest348[0] : V.Undef);
col_358 = (_argc347 > 5 ? _rest348[1] : V.Undef);
n_359 = (_argc347 > 6 ? _rest348[2] : V.Undef);
return Call(rep_43, V.Undef, (n_359 is var _t361 && Truthy(_t361) ? _t361 : ((V)(7D))), Fn((V _arrowThis369, int _argc362, V i_368, V _a365, V _a366, V _a367, V[] _rest363) => {
double a_370 = 0;
double r_371 = 0;
a_370 = (ToNum(i_368) * 2.4);
r_371 = (1.4 + (ToNum(Call(R_357, V.Undef)) * 2.2));
Invoke(o_353, "push", Call(ball_13, V.Undef, Add(x_354, ((V)((FdLibm.Cos(a_370) * r_371)))), Add(y_355, ((V)((ToNum(Call(R_357, V.Undef)) * 3D)))), Add(z_356, ((V)((FdLibm.Sin(a_370) * r_371)))), Add(((V)(1.8)), Call(R_357, V.Undef)), (col_358 is var _t372 && Truthy(_t372) ? _t372 : ((V)((NumTruthy((ToNum(i_368) % 2D)) ? "#6fae5a" : "#86c46a")))), NewObj(3).Put("sy", ((V)(1.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
return default;
}, 1, "", true));
}, 7, "", true);
Set(N_21, "torch22", Fn((V _arrowThis380, int _argc373, V S_379, V _a376, V _a377, V _a378, V[] _rest374) => {
V ST_381 = default;
V SD_382 = default;
V SH_383 = default;
V piv_384 = default;
double TA_385 = 0;
V RT_386 = default;
ST_381 = ((V)("#8a8f94"));
SD_382 = Call(shade_18, V.Undef, ST_381, ((V)(0.72)));
SH_383 = ((V)("#eadcbe"));
piv_384 = Arr(((V)(7D)), ((V)(121D)), ((V)(7D)));
TA_385 = (-0.22);
RT_386 = Call(rotF_29, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(TA_385)));
return NewObj(6).Put("w", ((V)(48D))).Put("d", ((V)(44D))).Put("glow", Fn((V _arrowThis393, int _argc387, V _a389, V _a390, V _a391, V _a392, V[] _rest388) => {
return NewObj(2).Put("y", ((V)(120D))).Put("r", ((V)(72D))).V;
}, 0, "glow", true)).Put("anim", Fn((V _arrowThis401, int _argc394, V p_400, V _a397, V _a398, V _a399, V[] _rest395) => {
V q_402 = default;
V v_403 = default;
q_402 = Call(P2_44, V.Undef, Call(p_400, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D))));
v_403 = Fn((V _arrowThis411, int _argc404, V a_410, V _a407, V _a408, V _a409, V[] _rest405) => {
return ((V)(JsStrBuf.Begin().V(a_410).S(" ").V(q_402).End()));
}, 1, "", true);
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"rotate\" values=\"").V(Invoke(Invoke(Arr(((V)(0D)), ((V)(1.2)), ((V)(0D)), ((V)((-0.9))), ((V)(0.4)), ((V)(0D))), "map", v_403), "join", ((V)(";")))).S("\" dur=\"5.5s\" calcMode=\"spline\" keyTimes=\"0;0.2;0.45;0.65;0.85;1\" keySplines=\"0.4 0 0.6 1;0.4 0 0.6 1;0.4 0 0.6 1;0.4 0 0.6 1;0.4 0 0.6 1\" repeatCount=\"indefinite\"/>").End()));
return default;
}, 1, "anim", true)).Put("build", Fn((V _arrowThis418, int _argc412, V _a414, V _a415, V _a416, V _a417, V[] _rest413) => {
V o_419 = default;
V on_420 = default;
V PO_421 = default;
V GN_422 = default;
V SHD_423 = default;
V fnT_424 = default;
V fnF_425 = default;
o_419 = Arr();
on_420 = Call(glue_48, V.Undef, o_419);
Invoke(o_419, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(13D)), ((V)(3D)), ST_381, Call(M__38, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.82))))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(3.4)), ((V)(2.4)), SD_382, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)));
PO_421 = Call(pipe_31, V.Undef, Arr(Arr(((V)(0D)), ((V)(5.4)), ((V)(0D))), Arr(((V)(0.8)), ((V)(48D)), ((V)(0.4))), Arr(((V)((-1.3))), ((V)(92D)), ((V)(0.6))), Arr(((V)((-0.6))), ((V)(104D)), ((V)(1D)))), ((V)(1D)), ST_381, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(8D))).V));
Invoke(PO_421, "forEach", Fn((V _arrowThis433, int _argc426, V s_432, V _a429, V _a430, V _a431, V[] _rest427) => {
return Invoke(o_419, "push", s_432);
}, 1, "", true));
Call(on_420, V.Undef, GetIdx(PO_421, 1D), Arr(Call(cyl_12, V.Undef, ((V)(0.3)), ((V)(60D)), ((V)(0.5)), ((V)(1.6)), ((V)(4.6)), ((V)("#b9bec4")), Call(PL_40, V.Undef, NewObj(1).Put("n", ((V)(8D))).V))));
GN_422 = Call(pipe_31, V.Undef, Arr(Arr(((V)((-0.6))), ((V)(104D)), ((V)(1D))), Arr(((V)((-0.2))), ((V)(111D)), ((V)(2.4))), Arr(((V)(2.4)), ((V)(117D)), ((V)(4.6))), Arr(((V)(5.6)), ((V)(120.4)), ((V)(6.4)))), ((V)(1.35)), ((V)("#6f7479")), Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(8D))).V));
Call(on_420, V.Undef, GetIdx(PO_421, 2D), GN_422);
Call(on_420, V.Undef, GetIdx(GN_422, 0D), Call(rep_43, V.Undef, ((V)(3D)), Fn((V _arrowThis441, int _argc434, V i_440, V _a437, V _a438, V _a439, V[] _rest435) => {
return Call(cyl_12, V.Undef, ((V)(((-0.6) + (ToNum(i_440) * 0.15)))), ((V)((105D + (ToNum(i_440) * 2.2)))), ((V)((1D + (ToNum(i_440) * 0.45)))), ((V)(1.75)), ((V)(0.8)), ((V)("#5c6166")), Call(M__38, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true)));
Call(on_420, V.Undef, GetIdx(GN_422, 1D), Arr(Call(cyl_12, V.Undef, ((V)(0.6)), ((V)(113D)), ((V)(3.2)), ((V)(1.75)), ((V)(0.8)), ((V)("#5c6166")), Call(M__38, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V)), Call(cyl_12, V.Undef, ((V)(1.6)), ((V)(115.4)), ((V)(4D)), ((V)(1.75)), ((V)(0.8)), ((V)("#5c6166")), Call(M__38, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V))));
SHD_423 = GetIdx(Call(on_420, V.Undef, GetIdx(GN_422, 2D), Arr(Call(tilt_27, V.Undef, Call(cyl_12, V.Undef, ((V)(7D)), ((V)(118D)), ((V)(7D)), ((V)(6D)), ((V)(13D)), SH_383, NewObj(3).Put("n", ((V)(22D))).Put("mat", ((V)("pl"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.45))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.95))), Arr(((V)(13D)), ((V)(0D)), ((V)(2.25))))).V), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(TA_385)), piv_384))), 0D);
fnT_424 = Call(RT_386, V.Undef, Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
fnF_425 = Call(RT_386, V.Undef, Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_420, V.Undef, SHD_423, Arr(Call(tilt_27, V.Undef, Call(band_50, V.Undef, ((V)(7D)), ((V)(129.6)), ((V)(7D)), ((V)(13.45)), ((V)(1.4)), ((V)("#d9b46a")), NewObj(1).Put("n", ((V)(24D))).V), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(TA_385)), piv_384), Call(tilt_27, V.Undef, Call(cyl_12, V.Undef, ((V)(7D)), ((V)(131D)), ((V)(7D)), ((V)(12.2)), ((V)(0.3)), ((V)("#fff2c2")), Call(em_42, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(TA_385)), piv_384)), fnT_424);
Call(on_420, V.Undef, SHD_423, Call(tiltAll_28, V.Undef, Call(pipe_31, V.Undef, Arr(Arr(((V)(8D)), ((V)(121.6)), ((V)(12.9))), Arr(((V)(6D)), ((V)(124.4)), ((V)(15.4))), Arr(((V)(8.4)), ((V)(126.6)), ((V)(17.6))), Arr(((V)(7.2)), ((V)(129.4)), ((V)(20D)))), ((V)(0.28)), ((V)("#6a5a40")), NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(TA_385)), piv_384), fnF_425);
Invoke(Call(pipe_31, V.Undef, Arr(Arr(((V)(0D)), ((V)(1D)), ((V)((-12D)))), Arr(((V)((-6D))), ((V)(0.6)), ((V)((-18D)))), Arr(((V)((-14D))), ((V)(0.6)), ((V)((-20D))))), ((V)(0.7)), ((V)("#3a3b40")), Call(PL_40, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)), "forEach", Fn((V _arrowThis449, int _argc442, V s_448, V _a445, V _a446, V _a447, V[] _rest443) => {
return Invoke(o_419, "push", s_448);
}, 1, "", true));
Invoke(o_419, "push", Call(box_11, V.Undef, ((V)((-8D))), ((V)(0D)), ((V)((-18.6))), ((V)(3D)), ((V)(1.8)), ((V)(5D)), ((V)("#f2efe6")), Call(PL_40, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("yaw", ((V)(0.5))).V)));
return o_419;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis457, int _argc450, V c_456, V _a453, V _a454, V _a455, V[] _rest451) => {
V tc_458 = default;
V k_459 = default;
tc_458 = InvokeSpread(c_456, "p", new ArrBuilder().Spread(Call(rp_47, V.Undef, Call(rotF_29, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.22)))), piv_384, Arr(((V)(7D)), ((V)(131.4)), ((V)(7D))))).V);
k_459 = Get(c_456, "k");
return NewObj(2).Put("defs", Call(RG_51, V.Undef, ((V)("q22tg")), ((V)("#fff6cc")), ((V)("#ffd27a")), ((V)(0.95)))).Put("front", Call(ell_52, V.Undef, c_456, tc_458, ((V)((13D * ToNum(k_459)))), ((V)((6D * ToNum(k_459)))), ((V)("url(#q22tg)")), Call(an_35, V.Undef, ((V)("opacity")), ((V)("0.75;0.95;0.35;0.9;0.6;0.95;0.2;0.85;0.75")), ((V)(2.6))), ((V)(0.8)))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_21, "tripod22", Fn((V _arrowThis467, int _argc460, V S_466, V _a463, V _a464, V _a465, V[] _rest461) => {
V WD_468 = default;
V LIN_469 = default;
WD_468 = ((V)("#c08a52"));
LIN_469 = ((V)("#f6ecd4"));
return NewObj(6).Put("w", ((V)(60D))).Put("d", ((V)(56D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis476, int _argc470, V _a472, V _a473, V _a474, V _a475, V[] _rest471) => {
return NewObj(2).Put("y", ((V)(104D))).Put("r", ((V)(80D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis483, int _argc477, V _a479, V _a480, V _a481, V _a482, V[] _rest478) => {
V o_484 = default;
V on_485 = default;
V SH_486 = default;
o_484 = Arr();
on_485 = Call(glue_48, V.Undef, o_484);
Call(rep_43, V.Undef, ((V)(3D)), Fn((V _arrowThis494, int _argc487, V i_493, V _a490, V _a491, V _a492, V[] _rest488) => {
double t_495 = 0;
double fx_496 = 0;
double fz_497 = 0;
V L_498 = default;
t_495 = ((PI_22 / 2D) + (((ToNum(i_493) * 2D) * PI_22) / 3D));
fx_496 = (FdLibm.Cos(t_495) * 24D);
fz_497 = (FdLibm.Sin(t_495) * 24D);
L_498 = Call(rod_30, V.Undef, Arr(((V)(fx_496)), ((V)(0D)), ((V)(fz_497))), Arr(((V)((FdLibm.Cos(t_495) * 4.5))), ((V)(77.4)), ((V)((FdLibm.Sin(t_495) * 4.5)))), ((V)(1.5)), WD_468, Call(W__37, V.Undef, NewObj(1).Put("n", ((V)(8D))).V));
Invoke(o_484, "push", L_498);
Call(on_485, V.Undef, L_498, Arr(Call(ball_13, V.Undef, ((V)(fx_496)), ((V)((-0.6))), ((V)(fz_497)), ((V)(1.9)), Call(shade_18, V.Undef, WD_468, ((V)(0.7))), NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sy", ((V)(0.6))).Put("shine", ((V)(0D))).V)));
return default;
}, 1, "", true));
Invoke(o_484, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(78D)), ((V)(0D)), ((V)(5.6)), ((V)(7D)), BR_25, Call(M__38, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(7D)), ((V)(0D)), ((V)(0.6))))).V)), Call(rod_30, V.Undef, Arr(((V)(0D)), ((V)(85D)), ((V)(0D))), Arr(((V)(0D)), ((V)(93D)), ((V)(0D))), ((V)(0.8)), BR_25, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
SH_486 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(93D)), ((V)(0D)), ((V)(19D)), ((V)(22D)), LIN_469, Call(em_42, V.Undef, NewObj(3).Put("n", ((V)(30D))).Put("noOut", ((V)(0D))).Put("mat", ((V)("fab"))).V));
Invoke(o_484, "push", SH_486);
Call(on_485, V.Undef, SH_486, Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(115D)), ((V)(0D)), ((V)(18.2)), ((V)(0.25)), ((V)("#f8d98a")), Call(em_42, V.Undef, NewObj(1).Put("n", ((V)(26D))).V))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Call(on_485, V.Undef, SH_486, Arr(Call(rod_30, V.Undef, Arr(((V)(0D)), ((V)(93.6)), ((V)(19.1))), Arr(((V)(0D)), ((V)(114.4)), ((V)(19.1))), ((V)(0.25)), ((V)("#ddcca8")), NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_485, V.Undef, SH_486, Arr(Call(band_50, V.Undef, ((V)(0D)), ((V)(93D)), ((V)(0D)), ((V)(19.15)), ((V)(1.4)), ((V)("#cbb690"))), Call(band_50, V.Undef, ((V)(0D)), ((V)(113.6)), ((V)(0D)), ((V)(19.15)), ((V)(1.4)), ((V)("#cbb690")))));
Call(on_485, V.Undef, SH_486, Arr(Call(rod_30, V.Undef, Arr(((V)(9D)), ((V)(92.6)), ((V)(6D))), Arr(((V)(9D)), ((V)(85D)), ((V)(6D))), ((V)(0.25)), BR_25, Call(M__38, V.Undef, NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V)), Call(ball_13, V.Undef, ((V)(9D)), ((V)(83.6)), ((V)(6D)), ((V)(1D)), BR_25, Call(M__38, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V))));
Invoke(Call(pipe_31, V.Undef, Arr(Arr(((V)((-24D))), ((V)(0.6)), ((V)((-16D)))), Arr(((V)((-28D))), ((V)(0.6)), ((V)((-21D)))), Arr(((V)((-34D))), ((V)(0.6)), ((V)((-24D))))), ((V)(0.6)), ((V)("#3a3b40")), Call(PL_40, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)), "forEach", Fn((V _arrowThis506, int _argc499, V s_505, V _a502, V _a503, V _a504, V[] _rest500) => {
return Invoke(o_484, "push", s_505);
}, 1, "", true));
return o_484;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis514, int _argc507, V c_513, V _a510, V _a511, V _a512, V[] _rest508) => {
return NewObj(2).Put("defs", Call(RG_51, V.Undef, ((V)("q22wg")), ((V)("#fff3cf")), ((V)("#ffcf7a")), ((V)(0.5)))).Put("under", Call(fxEll_32, V.Undef, c_513, ((V)(0D)), ((V)(0.2)), ((V)(0D)), ((V)(34D)), ((V)("url(#q22wg)")))).V;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_21, "arc22", Fn((V _arrowThis522, int _argc515, V S_521, V _a518, V _a519, V _a520, V[] _rest516) => {
V MB_523 = default;
double BX_524 = 0;
double BZ_525 = 0;
double DX_526 = 0;
double DZ_527 = 0;
double DY_528 = 0;
V bez_529 = default;
MB_523 = ((V)("#f4f1ec"));
BX_524 = (-40D);
BZ_525 = (-8D);
DX_526 = 30D;
DZ_527 = 8D;
DY_528 = 92D;
bez_529 = Fn((V _arrowThis537, int _argc530, V t_536, V _a533, V _a534, V _a535, V[] _rest531) => {
V P_538 = default;
double u_539 = 0;
P_538 = Arr(Arr(((V)(BX_524)), ((V)(12D)), ((V)(BZ_525))), Arr(((V)(BX_524)), ((V)(156D)), ((V)(BZ_525))), Arr(((V)(DX_526)), ((V)(158D)), ((V)(DZ_527))), Arr(((V)(DX_526)), ((V)((DY_528 + 14D))), ((V)(DZ_527))));
u_539 = (1D - ToNum(t_536));
return Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis547, int _argc540, V k_546, V _a543, V _a544, V _a545, V[] _rest541) => {
return ((V)(((((((u_539 * u_539) * u_539) * ToNum(GetK(GetIdx(P_538, 0D), k_546))) + ((((3D * u_539) * u_539) * ToNum(t_536)) * ToNum(GetK(GetIdx(P_538, 1D), k_546)))) + ((((3D * u_539) * ToNum(t_536)) * ToNum(t_536)) * ToNum(GetK(GetIdx(P_538, 2D), k_546)))) + (((ToNum(t_536) * ToNum(t_536)) * ToNum(t_536)) * ToNum(GetK(GetIdx(P_538, 3D), k_546))))));
}, 1, "", true));
return default;
}, 1, "", true);
return NewObj(5).Put("w", ((V)(100D))).Put("d", ((V)(48D))).Put("glow", Fn((V _arrowThis554, int _argc548, V _a550, V _a551, V _a552, V _a553, V[] _rest549) => {
return NewObj(2).Put("y", ((V)(96D))).Put("r", ((V)(86D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis561, int _argc555, V _a557, V _a558, V _a559, V _a560, V[] _rest556) => {
V o_562 = default;
V on_563 = default;
V BS_564 = default;
V DM_565 = default;
o_562 = Arr();
on_563 = Call(glue_48, V.Undef, o_562);
BS_564 = Call(box_11, V.Undef, ((V)(BX_524)), ((V)(0D)), ((V)(BZ_525)), ((V)(26D)), ((V)(11D)), ((V)(26D)), MB_523, NewObj(3).Put("r", ((V)(2.6))).Put("mat", ((V)("cer"))).Put("bev", ((V)(1.2))).V);
Invoke(o_562, "push", BS_564);
Call(on_563, V.Undef, BS_564, Arr(Call(rod_30, V.Undef, Arr(((V)((BX_524 - 9D))), ((V)(11.05)), ((V)((BZ_525 - 6D)))), Arr(((V)((BX_524 + 2D))), ((V)(11.05)), ((V)((BZ_525 + 4D)))), ((V)(0.22)), ((V)("#b9b2a6")), NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V), Call(rod_30, V.Undef, Arr(((V)((BX_524 + 2D))), ((V)(11.05)), ((V)((BZ_525 + 4D)))), Arr(((V)((BX_524 + 10D))), ((V)(11.05)), ((V)((BZ_525 + 1D)))), ((V)(0.18)), ((V)("#c4beb2")), NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Invoke(o_562, "push", Call(cyl_12, V.Undef, ((V)(BX_524)), ((V)(11D)), ((V)(BZ_525)), ((V)(2.8)), ((V)(3.4)), CH_24, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
Invoke(Call(pipe_31, V.Undef, Call(rep_43, V.Undef, ((V)(13D)), Fn((V _arrowThis581, int _argc574, V i_580, V _a577, V _a578, V _a579, V[] _rest575) => {
return Call(bez_529, V.Undef, ((V)((ToNum(i_580) / 12D))));
}, 1, "", true)), ((V)(1.3)), CH_24, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), "forEach", Fn((V _arrowThis573, int _argc566, V s_572, V _a569, V _a570, V _a571, V[] _rest567) => {
return Invoke(o_562, "push", s_572);
}, 1, "", true));
DM_565 = Call(cyl_12, V.Undef, ((V)(DX_526)), ((V)(DY_528)), ((V)(DZ_527)), ((V)(14D)), ((V)(14D)), CH_24, Call(M__38, V.Undef, NewObj(3).Put("n", ((V)(26D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.96))), Arr(((V)(8D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(11D)), ((V)(0D)), ((V)(0.55))), Arr(((V)(13D)), ((V)(0D)), ((V)(0.25))), Arr(((V)(14D)), ((V)(0D)), ((V)(0.08))))).V));
Invoke(o_562, "push", DM_565);
Call(on_563, V.Undef, DM_565, Arr(Call(cyl_12, V.Undef, ((V)(DX_526)), ((V)((DY_528 - 0.5))), ((V)(DZ_527)), ((V)(13.4)), ((V)(0.5)), ((V)("#fff1c0")), Call(em_42, V.Undef, NewObj(1).Put("n", ((V)(26D))).V))));
Invoke(o_562, "push", Call(ball_13, V.Undef, ((V)((BX_524 + 1.3))), ((V)(40D)), ((V)(BZ_525)), ((V)(2D)), ((V)("#2a2b30")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
Invoke(Call(pipe_31, V.Undef, Arr(Arr(((V)(BX_524)), ((V)(1D)), ((V)((BZ_525 - 13D)))), Arr(((V)((BX_524 - 6D))), ((V)(0.6)), ((V)((BZ_525 - 18D)))), Arr(((V)((BX_524 - 8D))), ((V)(0.6)), ((V)((BZ_525 - 24D))))), ((V)(0.6)), ((V)("#3a3b40")), Call(PL_40, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)), "forEach", Fn((V _arrowThis589, int _argc582, V s_588, V _a585, V _a586, V _a587, V[] _rest583) => {
return Invoke(o_562, "push", s_588);
}, 1, "", true));
return o_562;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis597, int _argc590, V c_596, V _a593, V _a594, V _a595, V[] _rest591) => {
V a_598 = default;
V b_599 = default;
V fl_600 = default;
V k_601 = default;
a_598 = Invoke(c_596, "p", ((V)((DX_526 - 13D))), ((V)((DY_528 - 0.5))), ((V)(DZ_527)));
b_599 = Invoke(c_596, "p", ((V)((DX_526 + 13D))), ((V)((DY_528 - 0.5))), ((V)(DZ_527)));
fl_600 = Invoke(c_596, "p", ((V)(DX_526)), ((V)(0D)), ((V)(DZ_527)));
k_601 = Get(c_596, "k");
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().S("<linearGradient id=\"q22ac\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff4cc\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#fff4cc\" stop-opacity=\"0\"/></linearGradient>").V(Call(RG_51, V.Undef, ((V)("q22ap")), ((V)("#fff1c4")), ((V)("#ffd27a")), ((V)(0.55)))).End()))).Put("under", Call(fxEll_32, V.Undef, c_596, ((V)(DX_526)), ((V)(0.2)), ((V)(DZ_527)), ((V)(30D)), ((V)("url(#q22ap)")))).Put("front", ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(P2_44, V.Undef, a_598)).S("L").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(fl_600, 0D)) - (30D * ToNum(k_601))))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(fl_600, 1D)) - (6D * ToNum(k_601))))))).S("H").V(Call(f1_20, V.Undef, Add(GetIdx(fl_600, 0D), ((V)((30D * ToNum(k_601))))))).S("L").V(Call(P2_44, V.Undef, b_599)).S("Z\" fill=\"url(#q22ac)\" opacity=\"0.7\"/>").End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
ST62_57 = Arr(Arr(((V)(11D)), ((V)(15D)), ((V)(0.6))), Arr(((V)(13.5)), ((V)(19D)), ((V)((-1D)))), Arr(((V)(9D)), ((V)(13D)), ((V)(1.2))), Arr(((V)(12D)), ((V)(21D)), ((V)(0D))), Arr(((V)(8D)), ((V)(12D)), ((V)((-0.6)))), Arr(((V)(10.5)), ((V)(17D)), ((V)(0.5))));
Set(N_21, "alab22", Fn((V _arrowThis609, int _argc602, V S_608, V _a605, V _a606, V _a607, V[] _rest603) => {
V BRZ_610 = default;
V AL_611 = default;
V lay_612 = default;
BRZ_610 = ((V)("#7a5534"));
AL_611 = Arr(((V)("#fbe8c8")), ((V)("#f7dcb6")), ((V)("#fdeed6")));
lay_612 = Fn((V _arrowThis619, int _argc613, V _a615, V _a616, V _a617, V _a618, V[] _rest614) => {
V y_620 = default;
y_620 = ((V)(4.6));
return Invoke(ST62_57, "map", Fn((V _arrowThis635, int _argc621, V _a623, V i_627, V _a625, V _a626, V[] _rest622) => {
V s_636 = default;
V r_630 = default;
V h_632 = default;
V dx_634 = default;
{ V _t628 = ListOf(_a623);
{ V _t629 = GetIdx(_t628, 0D);
r_630 = _t629; }
{ V _t631 = GetIdx(_t628, 1D);
h_632 = _t631; }
{ V _t633 = GetIdx(_t628, 2D);
dx_634 = _t633; }
}
s_636 = NewObj(4).Put("r", r_630).Put("h", h_632).Put("dx", dx_634).Put("y", y_620).V;
y_620 = Add(y_620, Add(h_632, ((V)(2.4))));
return s_636;
return default;
}, 2, "", true));
return default;
}, 0, "", true);
return NewObj(6).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis643, int _argc637, V _a639, V _a640, V _a641, V _a642, V[] _rest638) => {
return NewObj(2).Put("y", ((V)(70D))).Put("r", ((V)(78D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis650, int _argc644, V _a646, V _a647, V _a648, V _a649, V[] _rest645) => {
V o_651 = default;
o_651 = Arr();
Invoke(o_651, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(4.6)), BRZ_610, Call(M__38, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(4.6)), ((V)(0D)), ((V)(0.9))))).V)));
Invoke(Call(lay_612, V.Undef), "forEach", Fn((V _arrowThis660, int _argc652, V s_658, V i_659, V _a656, V _a657, V[] _rest653) => {
Invoke(o_651, "push", Call(cyl_12, V.Undef, Get(s_658, "dx"), Get(s_658, "y"), ((V)(0D)), Get(s_658, "r"), Get(s_658, "h"), GetIdx(AL_611, (ToNum(i_659) % 3D)), Call(em_42, V.Undef, NewObj(5).Put("n", ((V)(24D))).Put("noOut", ((V)(0D))).Put("mat", ((V)("cer"))).Put("rz", ((V)((ToNum(Get(s_658, "r")) * 0.86)))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.5))), Arr(((V)((ToNum(Get(s_658, "h")) * 0.18))), ((V)(0D)), ((V)(0.9))), Arr(((V)((ToNum(Get(s_658, "h")) * 0.5))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(Get(s_658, "h")) * 0.82))), ((V)(0D)), ((V)(0.9))), Arr(Get(s_658, "h"), ((V)(0D)), ((V)(0.5))))).V)));
Invoke(o_651, "push", Call(cyl_12, V.Undef, ((V)((ToNum(Get(s_658, "dx")) * 0.5))), Add(Get(s_658, "y"), Get(s_658, "h")), ((V)(0D)), ((V)(3.4)), ((V)(2.4)), BRZ_610, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
return default;
}, 2, "", true));
return o_651;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis668, int _argc661, V c_667, V _a664, V _a665, V _a666, V[] _rest662) => {
V k_669 = default;
JsStrBuf f_670 = null;
k_669 = Get(c_667, "k");
f_670 = new JsStrBuf("");
Invoke(Call(lay_612, V.Undef), "forEach", Fn((V _arrowThis679, int _argc671, V s_677, V i_678, V _a675, V _a676, V[] _rest672) => {
V q_680 = default;
q_680 = Invoke(c_667, "p", Get(s_677, "dx"), Add(Get(s_677, "y"), ((V)((ToNum(Get(s_677, "h")) / 2D)))), ((V)(0D)));
f_670.V(Call(ell_52, V.Undef, c_667, q_680, ((V)(((ToNum(Get(s_677, "r")) * 0.8) * ToNum(k_669)))), ((V)(((ToNum(Get(s_677, "h")) * 0.42) * ToNum(k_669)))), ((V)("url(#q22al)")), Call(an_35, V.Undef, ((V)("opacity")), ((V)("0.25;0.85;0.25")), ((V)(4.2)), Call(n4_45, V.Undef, ((V)(((-ToNum(i_678)) * 0.7))))), ((V)(0.5))));
return default;
}, 2, "", true));
return NewObj(2).Put("defs", Call(RG_51, V.Undef, ((V)("q22al")), ((V)("#ffffff")), ((V)("#ffe2b0")), ((V)(0.9)))).Put("front", ((V)(f_670.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_21, "bio22", Fn((V _arrowThis688, int _argc681, V S_687, V _a684, V _a685, V _a686, V[] _rest682) => {
V POT_689 = default;
V hel_690 = default;
POT_689 = ((V)("#2b3436"));
hel_690 = Fn((V _arrowThis698, int _argc691, V t_697, V _a694, V _a695, V _a696, V[] _rest692) => {
double a_699 = 0;
a_699 = ((ToNum(t_697) * 4.2) * PI_22);
return Arr(((V)((FdLibm.Cos(a_699) * 6D))), ((V)((19D + (ToNum(t_697) * 90D)))), ((V)((FdLibm.Sin(a_699) * 6D))));
return default;
}, 1, "", true);
return NewObj(6).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis706, int _argc700, V _a702, V _a703, V _a704, V _a705, V[] _rest701) => {
return NewObj(3).Put("y", ((V)(64D))).Put("r", ((V)(80D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis713, int _argc707, V _a709, V _a710, V _a711, V _a712, V[] _rest708) => {
V o_714 = default;
V on_715 = default;
V R_716 = default;
V PT_717 = default;
V V_718 = default;
V back_719 = default;
V front_720 = default;
V LV_721 = default;
V MU_722 = default;
o_714 = Arr();
on_715 = Call(glue_48, V.Undef, o_714);
R_716 = Call(R0_46, V.Undef, ((V)("bio")));
PT_717 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(15D)), ((V)(16D)), POT_689, NewObj(3).Put("n", ((V)(26D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(16D)), ((V)(0D)), ((V)(1D))))).V);
Invoke(o_714, "push", PT_717);
Call(on_715, V.Undef, PT_717, Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)), ((V)(14.3)), ((V)(1.2)), ((V)("#38c98a")), Call(em_42, V.Undef, NewObj(1).Put("n", ((V)(24D))).V))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
V_718 = Call(rep_43, V.Undef, ((V)(25D)), Fn((V _arrowThis730, int _argc723, V i_729, V _a726, V _a727, V _a728, V[] _rest724) => {
return Call(hel_690, V.Undef, ((V)((ToNum(i_729) / 24D))));
}, 1, "", true));
back_719 = Arr();
front_720 = Arr();
{
double i_731 = 0;
i_731 = 0D;
while (true) {
if (!((i_731 < 24D))) break;
Invoke((LtN(Add(GetIdx(GetIdx(V_718, i_731), 2D), GetIdx(GetIdx(V_718, (i_731 + 1D)), 2D)), 0D) ? back_719 : front_720), "push", Call(rod_30, V.Undef, GetIdx(V_718, i_731), GetIdx(V_718, (i_731 + 1D)), ((V)(0.75)), ((V)("#1f6b4a")), NewObj(1).Put("n", ((V)(5D))).V));
i_731++;
}
}
LV_721 = Call(rep_43, V.Undef, ((V)(16D)), Fn((V _arrowThis740, int _argc733, V i_739, V _a736, V _a737, V _a738, V[] _rest734) => {
double t_741 = 0;
V p_742 = default;
double a_743 = 0;
t_741 = (ToNum(Add(i_739, ((V)(0.5)))) / 16D);
p_742 = Call(hel_690, V.Undef, ((V)(t_741)));
a_743 = ((t_741 * 4.2) * PI_22);
return Call(ball_13, V.Undef, Add(GetIdx(p_742, 0D), ((V)((FdLibm.Cos(a_743) * 2.2)))), GetIdx(p_742, 1D), Add(GetIdx(p_742, 2D), ((V)((FdLibm.Sin(a_743) * 2.2)))), ((V)(2.2)), ((V)((NumTruthy((ToNum(i_739) % 2D)) ? "#62f2c4" : "#9affdc"))), Call(em_42, V.Undef, NewObj(5).Put("sx", ((V)(1.5))).Put("sy", ((V)(0.55))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("yaw", ((V)((-a_743)))).V));
return default;
}, 1, "", true));
MU_722 = Invoke(Arr(Arr(((V)(0.22)), ((V)("#7fd8ff"))), Arr(((V)(0.55)), ((V)("#b48cff"))), Arr(((V)(0.82)), ((V)("#7fd8ff")))), "map", Fn((V _arrowThis755, int _argc744, V _a746, V _a747, V _a748, V _a749, V[] _rest745) => {
V p_756 = default;
V t_752 = default;
V col_754 = default;
{ V _t750 = ListOf(_a746);
{ V _t751 = GetIdx(_t750, 0D);
t_752 = _t751; }
{ V _t753 = GetIdx(_t750, 1D);
col_754 = _t753; }
}
p_756 = Call(hel_690, V.Undef, t_752);
return Call(cyl_12, V.Undef, ((V)((ToNum(GetIdx(p_756, 0D)) * 1.3))), GetIdx(p_756, 1D), ((V)((ToNum(GetIdx(p_756, 2D)) * 1.3))), ((V)(2.6)), ((V)(2.2)), col_754, Call(em_42, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(1.4)), ((V)(0D)), ((V)(0.8))), Arr(((V)(2.2)), ((V)(0D)), ((V)(0.2))))).V));
return default;
}, 1, "", true));
Call(on_715, V.Undef, PT_717, Invoke(back_719, "concat", Invoke(LV_721, "filter", Fn((V _arrowThis765, int _argc757, V s_763, V i_764, V _a761, V _a762, V[] _rest758) => {
return ((FdLibm.Sin((((ToNum(Add(i_764, ((V)(0.5)))) / 16D) * 4.2) * PI_22)) < 0D) ? V.True : V.False);
}, 2, "", true)), front_720, Invoke(LV_721, "filter", Fn((V _arrowThis774, int _argc766, V s_772, V i_773, V _a770, V _a771, V[] _rest767) => {
return ((FdLibm.Sin((((ToNum(Add(i_773, ((V)(0.5)))) / 16D) * 4.2) * PI_22)) >= 0D) ? V.True : V.False);
}, 2, "", true)), MU_722));
Call(on_715, V.Undef, PT_717, Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(17.2)), ((V)(0D)), ((V)(10.6)), ((V)(96D)), ((V)("#d8fbff")), NewObj(3).Put("n", ((V)(24D))).Put("op", ((V)(0.2))).Put("shine", ((V)(1D))).V)));
Call(on_715, V.Undef, PT_717, Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(113.2)), ((V)(0D)), ((V)(11.6)), ((V)(3D)), BR_25, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(116.2)), ((V)(0D)), ((V)(7D)), ((V)(0.6)), ((V)("#9affe8")), Call(em_42, V.Undef, NewObj(1).Put("n", ((V)(18D))).V))));
return o_714;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis782, int _argc775, V c_781, V _a778, V _a779, V _a780, V[] _rest776) => {
V R_783 = default;
V k_784 = default;
JsStrBuf f_785 = null;
V path_786 = default;
R_783 = Call(R0_46, V.Undef, ((V)("spore")));
k_784 = Get(c_781, "k");
f_785 = new JsStrBuf("");
Call(rep_43, V.Undef, ((V)(9D)), Fn((V _arrowThis794, int _argc787, V i_793, V _a790, V _a791, V _a792, V[] _rest788) => {
double x_795 = 0;
double z_796 = 0;
V a_797 = default;
V b_798 = default;
V d_799 = default;
V bg_800 = default;
x_795 = ((ToNum(Call(R_783, V.Undef)) - 0.5) * 12D);
z_796 = ((ToNum(Call(R_783, V.Undef)) - 0.5) * 10D);
a_797 = Invoke(c_781, "p", ((V)(x_795)), ((V)(22D)), ((V)(z_796)));
b_798 = Invoke(c_781, "p", ((V)(x_795)), ((V)(108D)), ((V)(z_796)));
d_799 = Call(n4_45, V.Undef, ((V)((5D + (ToNum(Call(R_783, V.Undef)) * 3D)))));
bg_800 = Call(n4_45, V.Undef, ((V)(((-ToNum(Call(R_783, V.Undef))) * 6D))));
f_785.S("<circle cx=\"").V(Call(f1_20, V.Undef, GetIdx(a_797, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(a_797, 1D))).S("\" r=\"").V(Call(f1_20, V.Undef, ((V)((0.9 * ToNum(k_784)))))).S("\" fill=\"#c8fff2\" opacity=\"0\">").V(Call(an_35, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(a_797, 1D))).S(";").V(Call(f1_20, V.Undef, GetIdx(b_798, 1D))).End())), d_799, bg_800)).V(Call(an_35, V.Undef, ((V)("opacity")), ((V)("0;0.9;0.9;0")), d_799, bg_800)).S("</circle>");
return default;
}, 1, "", true));
path_786 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Call(rep_43, V.Undef, ((V)(25D)), Fn((V _arrowThis808, int _argc801, V i_807, V _a804, V _a805, V _a806, V[] _rest802) => {
return Call(P2_44, V.Undef, InvokeSpread(c_781, "p", new ArrBuilder().Spread(Call(hel_690, V.Undef, ((V)((ToNum(i_807) / 24D))))).V));
}, 1, "", true)), "join", ((V)("L")))).End()));
f_785.S("<circle r=\"").V(Call(f1_20, V.Undef, ((V)((2.4 * ToNum(k_784)))))).S("\" fill=\"#e8fff8\" opacity=\"0.9\"><animateMotion path=\"").V(path_786).S("\" dur=\"3.6s\" repeatCount=\"indefinite\"/>").V(Call(an_35, V.Undef, ((V)("opacity")), ((V)("0;1;1;0")), ((V)(3.6)))).S("</circle>");
return NewObj(1).Put("front", ((V)(f_785.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_21, "trestle22", Fn((V _arrowThis816, int _argc809, V S_815, V _a812, V _a813, V _a814, V[] _rest810) => {
V PLY_817 = default;
V PD_818 = default;
V PN_819 = default;
double W_820 = 0;
double Dp_821 = 0;
double TY_822 = 0;
PLY_817 = ((V)("#dcbd8c"));
PD_818 = Call(shade_18, V.Undef, PLY_817, ((V)(0.74)));
PN_819 = ((V)("#c9a06a"));
W_820 = 124D;
Dp_821 = 34D;
TY_822 = 48D;
return NewObj(5).Put("w", ((V)((W_820 + 4D)))).Put("d", ((V)((Dp_821 + 6D)))).Put("topH", ((V)((TY_822 + 2.2)))).Put("topW", ((V)(70D))).Put("build", Fn((V _arrowThis829, int _argc823, V _a825, V _a826, V _a827, V _a828, V[] _rest824) => {
V o_830 = default;
V on_831 = default;
V R_832 = default;
V TP_833 = default;
o_830 = Arr();
on_831 = Call(glue_48, V.Undef, o_830);
R_832 = Call(R0_46, V.Undef, ((V)("ply")));
Invoke(Arr(((V)((-44D))), ((V)(44D))), "forEach", Fn((V _arrowThis841, int _argc834, V x_840, V _a837, V _a838, V _a839, V[] _rest835) => {
Invoke(o_830, "push", Call(box_11, V.Undef, x_840, ((V)((TY_822 - 4D))), ((V)(0D)), ((V)(6D)), ((V)(4D)), ((V)((Dp_821 - 6D))), PN_819, Call(W__37, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis849, int _argc842, V sx_848, V _a845, V _a846, V _a847, V[] _rest843) => {
return Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis857, int _argc850, V sz_856, V _a853, V _a854, V _a855, V[] _rest851) => {
return Invoke(o_830, "push", Call(rod_30, V.Undef, Arr(Add(x_840, ((V)((ToNum(sx_848) * 2.2)))), ((V)((TY_822 - 4.5))), ((V)((ToNum(sz_856) * 11D)))), Arr(Add(x_840, ((V)((ToNum(sx_848) * 7.5)))), ((V)(0D)), ((V)((ToNum(sz_856) * 14D)))), ((V)(1.4)), Call(shade_18, V.Undef, PN_819, ((V)(0.92))), Call(W__37, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis865, int _argc858, V sx_864, V _a861, V _a862, V _a863, V[] _rest859) => {
return Invoke(o_830, "push", Call(rod_30, V.Undef, Arr(Add(x_840, ((V)((ToNum(sx_864) * 5.2)))), ((V)(14D)), ((V)((-13D)))), Arr(Add(x_840, ((V)((ToNum(sx_864) * 5.2)))), ((V)(14D)), ((V)(13D))), ((V)(0.9)), Call(shade_18, V.Undef, PN_819, ((V)(0.84))), Call(W__37, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
TP_833 = Call(box_11, V.Undef, ((V)(0D)), ((V)(TY_822)), ((V)(0D)), ((V)(W_820)), ((V)(2.2)), ((V)(Dp_821)), PLY_817, Call(W__37, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("yaw", ((V)(0.02))).V));
Invoke(o_830, "push", TP_833);
Call(on_831, V.Undef, TP_833, Invoke(Arr(((V)(0.7)), ((V)(1.45))), "map", Fn((V _arrowThis873, int _argc866, V y_872, V _a869, V _a870, V _a871, V[] _rest867) => {
return Call(slabX_15, V.Undef, ((V)(0D)), Add(((V)(TY_822)), y_872), ((V)(((Dp_821 / 2D) + 0.9))), ((V)((W_820 - 4D))), ((V)(0.3)), ((V)(0.3)), PD_818, NewObj(3).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).Put("yaw", ((V)(0.02))).V);
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_831, V.Undef, TP_833, Arr(Call(cyl_12, V.Undef, ((V)(20D)), ((V)((TY_822 + 2.22))), ((V)(6D)), ((V)(4D)), ((V)(0.05)), ((V)("#8a5a30")), NewObj(3).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.3))).V), Call(cyl_12, V.Undef, ((V)(26D)), ((V)((TY_822 + 2.22))), ((V)((-3D))), ((V)(3.6)), ((V)(0.05)), ((V)("#8a5a30")), NewObj(3).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.25))).V), Call(box_11, V.Undef, ((V)((-30D))), ((V)((TY_822 + 2.22))), ((V)((-6D))), ((V)(9D)), ((V)(0.05)), ((V)(6D)), ((V)("#f2e27a")), NewObj(3).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).Put("yaw", ((V)(0.3))).V)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Call(mug_55, V.Undef, o_830, ((V)(40D)), ((V)((TY_822 + 2.2))), ((V)(4D)), ((V)("#e86f5a")));
Invoke(Arr(Arr(((V)("#f4efe4")), ((V)(0.1))), Arr(((V)("#bcd4f0")), ((V)((-0.12)))), Arr(((V)("#f4c9c9")), ((V)(0.22)))), "forEach", Fn((V _arrowThis886, int _argc874, V _a876, V i_880, V _a878, V _a879, V[] _rest875) => {
V col_883 = default;
V y_885 = default;
{ V _t881 = ListOf(_a876);
{ V _t882 = GetIdx(_t881, 0D);
col_883 = _t882; }
{ V _t884 = GetIdx(_t881, 1D);
y_885 = _t884; }
}
return Invoke(o_830, "push", Call(box_11, V.Undef, ((V)(((-40D) + (ToNum(i_880) * 0.8)))), ((V)(((TY_822 + 2.2) + (ToNum(i_880) * 0.6)))), ((V)(4D)), ((V)(16D)), ((V)(0.6)), ((V)(10D)), col_883, Call(PL_40, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("yaw", y_885).V)));
}, 2, "", true));
Invoke(o_830, "push", Call(arcW_16, V.Undef, ((V)((-22D))), ((V)((TY_822 + 2.2))), ((V)(8D)), ((V)(2D)), ((V)(2D)), ((V)(0.5)), ((V)(0.5)), ((V)(0D)), ((V)((2D * PI_22))), CH_24, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(box_11, V.Undef, ((V)((-18.6))), ((V)((TY_822 + 2.2))), ((V)(9.4)), ((V)(4.6)), ((V)(0.5)), ((V)(1.6)), ((V)("#c9a14a")), Call(M__38, V.Undef, NewObj(2).Put("r", ((V)(0.3))).Put("yaw", ((V)(0.4))).V)));
return o_830;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_21, "iron22", Fn((V _arrowThis894, int _argc887, V S_893, V _a890, V _a891, V _a892, V[] _rest888) => {
V IR_895 = default;
V GL_896 = default;
double W_897 = 0;
double Dp_898 = 0;
double H_899 = 0;
IR_895 = ((V)("#25262a"));
GL_896 = ((V)("#cfe6ee"));
W_897 = 118D;
Dp_898 = 28D;
H_899 = 56D;
return NewObj(5).Put("w", ((V)((W_897 + 4D)))).Put("d", ((V)((Dp_898 + 4D)))).Put("topH", ((V)((H_899 + 1.2)))).Put("topW", ((V)(66D))).Put("build", Fn((V _arrowThis906, int _argc900, V _a902, V _a903, V _a904, V _a905, V[] _rest901) => {
V o_907 = default;
V BK_908 = default;
o_907 = Arr();
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis920, int _argc909, V _a911, V _a912, V _a913, V _a914, V[] _rest910) => {
V sx_917 = default;
V sz_919 = default;
{ V _t915 = ListOf(_a911);
{ V _t916 = GetIdx(_t915, 0D);
sx_917 = _t916; }
{ V _t918 = GetIdx(_t915, 1D);
sz_919 = _t918; }
}
return Invoke(o_907, "push", Call(box_11, V.Undef, ((V)((ToNum(sx_917) * ((W_897 / 2D) - 1D)))), ((V)(0D)), ((V)((ToNum(sz_919) * ((Dp_898 / 2D) - 1D)))), ((V)(1.8)), ((V)(H_899)), ((V)(1.8)), IR_895, Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
}, 1, "", true));
Invoke(Arr(((V)((H_899 - 2D))), ((V)(11D))), "forEach", Fn((V _arrowThis928, int _argc921, V y_927, V _a924, V _a925, V _a926, V[] _rest922) => {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis936, int _argc929, V sz_935, V _a932, V _a933, V _a934, V[] _rest930) => {
return Invoke(o_907, "push", Call(slabX_15, V.Undef, ((V)(0D)), y_927, ((V)((ToNum(sz_935) * ((Dp_898 / 2D) - 1D)))), ((V)((W_897 - 3.6))), ((V)(1.8)), ((V)(1.4)), IR_895, Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis944, int _argc937, V sx_943, V _a940, V _a941, V _a942, V[] _rest938) => {
return Invoke(o_907, "push", Call(box_11, V.Undef, ((V)((ToNum(sx_943) * ((W_897 / 2D) - 1D)))), y_927, ((V)(0D)), ((V)(1.4)), ((V)(1.8)), ((V)((Dp_898 - 3.6))), IR_895, Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(o_907, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(12.8)), ((V)(0D)), ((V)((W_897 - 4D))), ((V)(0.9)), ((V)((Dp_898 - 4D))), GL_896, NewObj(3).Put("r", ((V)(0.8))).Put("op", ((V)(0.42))).Put("shine", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(H_899)), ((V)(0D)), ((V)((W_897 + 2D))), ((V)(1.2)), ((V)((Dp_898 + 2D))), GL_896, NewObj(3).Put("r", ((V)(1D))).Put("op", ((V)(0.45))).Put("shine", ((V)(1D))).V));
BK_908 = Call(cyl_12, V.Undef, ((V)((-30D))), ((V)(13.7)), ((V)(0D)), ((V)(9D)), ((V)(9D)), ((V)("#c9a06a")), Call(F__39, V.Undef, NewObj(3).Put("n", ((V)(20D))).Put("soft", ((V)(0D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V));
Invoke(o_907, "push", BK_908);
Call(Call(glue_48, V.Undef, o_907), V.Undef, BK_908, Arr(Call(band_50, V.Undef, ((V)((-30D))), ((V)(18D)), ((V)(0D)), ((V)(9.05)), ((V)(1.4)), ((V)("#8a6440"))), Call(band_50, V.Undef, ((V)((-30D))), ((V)(21.6)), ((V)(0D)), ((V)(9.05)), ((V)(1D)), ((V)("#8a6440")))));
Invoke(Arr(Arr(((V)("#2f5a8a")), ((V)(0D))), Arr(((V)("#e0b04c")), ((V)(0.1))), Arr(((V)("#c4643a")), ((V)((-0.08))))), "forEach", Fn((V _arrowThis957, int _argc945, V _a947, V i_951, V _a949, V _a950, V[] _rest946) => {
V col_954 = default;
V y_956 = default;
{ V _t952 = ListOf(_a947);
{ V _t953 = GetIdx(_t952, 0D);
col_954 = _t953; }
{ V _t955 = GetIdx(_t952, 1D);
y_956 = _t955; }
}
return Invoke(Call(book_54, V.Undef, ((V)(26D)), ((V)((13.7 + (ToNum(i_951) * 2.6)))), ((V)(0D)), ((V)(22D)), ((V)(2.6)), ((V)(15D)), col_954, y_956), "forEach", Fn((V _arrowThis965, int _argc958, V s_964, V _a961, V _a962, V _a963, V[] _rest959) => {
return Invoke(o_907, "push", s_964);
}, 1, "", true));
}, 2, "", true));
Invoke(o_907, "push", Call(box_11, V.Undef, ((V)(28D)), ((V)((H_899 + 1.2))), ((V)(0D)), ((V)(20D)), ((V)(0.9)), ((V)(11D)), BR_25, Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)), Call(arcW_16, V.Undef, ((V)(25D)), ((V)((H_899 + 2.1))), ((V)(0D)), ((V)(1.8)), ((V)(1.8)), ((V)(0.45)), ((V)(0.45)), ((V)(0D)), ((V)((2D * PI_22))), CH_24, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(box_11, V.Undef, ((V)(28.6)), ((V)((H_899 + 2.1))), ((V)(1.4)), ((V)(4.4)), ((V)(0.5)), ((V)(1.4)), ((V)("#c9a14a")), Call(M__38, V.Undef, NewObj(2).Put("r", ((V)(0.3))).Put("yaw", ((V)(0.6))).V)));
Invoke(o_907, "push", Call(cyl_12, V.Undef, ((V)((-34D))), ((V)((H_899 + 1.2))), ((V)((-2D))), ((V)(4.2)), ((V)(6D)), ((V)("#f2efe8")), NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))))).V));
Call(sprig_56, V.Undef, o_907, ((V)((-34D))), ((V)((H_899 + 7D))), ((V)((-2D))), Call(R0_46, V.Undef, ((V)("suc"))), V.Null, ((V)(6D)));
return o_907;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_21, "rattan22", Fn((V _arrowThis973, int _argc966, V S_972, V _a969, V _a970, V _a971, V[] _rest967) => {
V TK_974 = default;
V TL_975 = default;
V TD_976 = default;
V CANE_977 = default;
double W_978 = 0;
double Dp_979 = 0;
double BY_980 = 0;
double BH_981 = 0;
TK_974 = ((V)("#a8683a"));
TL_975 = Call(shade_18, V.Undef, TK_974, ((V)(1.14)));
TD_976 = Call(shade_18, V.Undef, TK_974, ((V)(0.74)));
CANE_977 = ((V)("#dcb47a"));
W_978 = 132D;
Dp_979 = 36D;
BY_980 = 14D;
BH_981 = 40D;
return NewObj(5).Put("w", ((V)((W_978 + 6D)))).Put("d", ((V)((Dp_979 + 6D)))).Put("topH", ((V)(((BY_980 + BH_981) + 2.4)))).Put("topW", ((V)(76D))).Put("build", Fn((V _arrowThis988, int _argc982, V _a984, V _a985, V _a986, V _a987, V[] _rest983) => {
V o_989 = default;
V on_990 = default;
V BD_991 = default;
double TY_992 = 0;
V VS_993 = default;
o_989 = Arr();
on_990 = Call(glue_48, V.Undef, o_989);
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis1005, int _argc994, V _a996, V _a997, V _a998, V _a999, V[] _rest995) => {
V sx_1002 = default;
V sz_1004 = default;
{ V _t1000 = ListOf(_a996);
{ V _t1001 = GetIdx(_t1000, 0D);
sx_1002 = _t1001; }
{ V _t1003 = GetIdx(_t1000, 1D);
sz_1004 = _t1003; }
}
return Invoke(o_989, "push", Call(cyl_12, V.Undef, ((V)((ToNum(sx_1002) * ((W_978 / 2D) - 6D)))), ((V)(0D)), ((V)((ToNum(sz_1004) * ((Dp_979 / 2D) - 5D)))), ((V)(2.6)), ((V)(BY_980)), TD_976, Call(W__37, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(BY_980)), ((V)(0D)), ((V)(1D))))).V)));
}, 1, "", true));
BD_991 = Call(box_11, V.Undef, ((V)(0D)), ((V)(BY_980)), ((V)(0D)), ((V)(W_978)), ((V)(BH_981)), ((V)(Dp_979)), TK_974, Call(W__37, V.Undef, NewObj(1).Put("r", ((V)(1.4))).V));
Invoke(o_989, "push", BD_991);
Invoke(o_989, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((BY_980 + BH_981))), ((V)(0D)), ((V)((W_978 + 2D))), ((V)(2.4)), ((V)((Dp_979 + 2D))), TL_975, Call(W__37, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)));
Invoke(Arr(((V)((-43D))), ((V)(43D))), "forEach", Fn((V _arrowThis1013, int _argc1006, V x_1012, V _a1009, V _a1010, V _a1011, V[] _rest1007) => {
V FR_1014 = default;
V CN_1015 = default;
double hw_1016 = 0;
double hh_1017 = 0;
double cy_1018 = 0;
double zf_1019 = 0;
V L_1020 = default;
FR_1014 = GetIdx(Call(on_990, V.Undef, BD_991, Arr(Call(box_11, V.Undef, x_1012, ((V)((BY_980 + 3D))), ((V)(((Dp_979 / 2D) + 0.05))), ((V)(42D)), ((V)((BH_981 - 6D))), ((V)(0.8)), TD_976, Call(W__37, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
CN_1015 = GetIdx(Call(on_990, V.Undef, FR_1014, Arr(Call(box_11, V.Undef, x_1012, ((V)((BY_980 + 5.4))), ((V)(((Dp_979 / 2D) + 0.85))), ((V)(36.4)), ((V)((BH_981 - 10.8))), ((V)(0.3)), CANE_977, NewObj(2).Put("r", ((V)(0.3))).Put("mat", ((V)("fab"))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
hw_1016 = 18.2;
hh_1017 = ((BH_981 - 10.8) / 2D);
cy_1018 = ((BY_980 + 5.4) + hh_1017);
zf_1019 = ((Dp_979 / 2D) + 1.25);
L_1020 = Arr();
{
V k_1021 = default;
k_1021 = ((V)(((-hw_1016) - hh_1017)));
while (true) {
V k_1021_it = k_1021;
if (!(LeN(k_1021_it, (hw_1016 + hh_1017)))) break;
Invoke(Arr(((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis1030, int _argc1023, V sg_1029, V _a1026, V _a1027, V _a1028, V[] _rest1024) => {
double u0_1031 = 0;
double u1_1032 = 0;
u0_1031 = Max((-hw_1016), (ToNum(k_1021_it) - hh_1017));
u1_1032 = Min(hw_1016, ToNum(Add(k_1021_it, ((V)(hh_1017)))));
if (((u1_1032 - u0_1031) < 1D)) {
return default;
}
Invoke(L_1020, "push", Call(rod_30, V.Undef, Arr(Add(x_1012, ((V)(u0_1031))), ((V)((cy_1018 + (ToNum(sg_1029) * (u0_1031 - ToNum(k_1021_it)))))), ((V)(zf_1019))), Arr(Add(x_1012, ((V)(u1_1032))), ((V)((cy_1018 + (ToNum(sg_1029) * (u1_1032 - ToNum(k_1021_it)))))), ((V)(zf_1019))), ((V)(0.24)), Call(shade_18, V.Undef, CANE_977, ((V)(0.72))), NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V));
return default;
}, 1, "", true));
k_1021 = k_1021_it;
k_1021 = Add(k_1021, ((V)(3.4)));
}
}
Call(on_990, V.Undef, CN_1015, L_1020, Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_990, V.Undef, FR_1014, Arr(Call(box_11, V.Undef, Add(x_1012, ((V)((LtN(x_1012, 0D) ? 18D : (-18D))))), ((V)((BY_980 + 18D))), ((V)(((Dp_979 / 2D) + 0.85))), ((V)(1.2)), ((V)(6D)), ((V)(0.8)), BR_25, Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
Call(rep_43, V.Undef, ((V)(3D)), Fn((V _arrowThis1040, int _argc1033, V i_1039, V _a1036, V _a1037, V _a1038, V[] _rest1034) => {
V DR_1041 = default;
DR_1041 = GetIdx(Call(on_990, V.Undef, BD_991, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(((BY_980 + 3D) + (ToNum(i_1039) * 11.4)))), ((V)(((Dp_979 / 2D) + 0.05))), ((V)(40D)), ((V)(10.4)), ((V)(0.8)), TL_975, Call(W__37, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_990, V.Undef, DR_1041, Arr(Call(slabX_15, V.Undef, ((V)(0D)), ((V)(((BY_980 + 7.6) + (ToNum(i_1039) * 11.4)))), ((V)(((Dp_979 / 2D) + 1.25))), ((V)(10D)), ((V)(1.2)), ((V)(0.8)), BR_25, Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
TY_992 = ((BY_980 + BH_981) + 2.4);
VS_993 = Call(cyl_12, V.Undef, ((V)((-44D))), ((V)(TY_992)), ((V)((-4D))), ((V)(5.6)), ((V)(16D)), ((V)("#efe7da")), NewObj(3).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))), Arr(((V)(14D)), ((V)(0D)), ((V)(0.5))), Arr(((V)(16D)), ((V)(0D)), ((V)(0.6))))).V);
Invoke(o_989, "push", VS_993);
Call(rep_43, V.Undef, ((V)(5D)), Fn((V _arrowThis1049, int _argc1042, V i_1048, V _a1045, V _a1046, V _a1047, V[] _rest1043) => {
double a_1050 = 0;
V tp_1051 = default;
a_1050 = ((-0.5) + (ToNum(i_1048) * 0.25));
tp_1051 = Arr(((V)(((-44D) + (FdLibm.Sin(a_1050) * 18D)))), ((V)(((TY_992 + 38D) + (FdLibm.Cos(ToNum(i_1048)) * 3D)))), ((V)(((-4D) + (NumTruthy((ToNum(i_1048) % 2D)) ? 3D : (-3D))))));
Call(on_990, V.Undef, VS_993, Arr(Call(rod_30, V.Undef, Arr(((V)((-44D))), ((V)((TY_992 + 14D))), ((V)((-4D)))), tp_1051, ((V)(0.35)), ((V)("#c9b48a")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_13, V.Undef, GetIdx(tp_1051, 0D), ((V)((ToNum(GetIdx(tp_1051, 1D)) - 2D))), GetIdx(tp_1051, 2D), ((V)(3.6)), ((V)("#efe2c4")), Call(F__39, V.Undef, NewObj(5).Put("sy", ((V)(2D))).Put("sx", ((V)(0.8))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("shine", ((V)(0D))).V))));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)("#2f4f5a")), ((V)(0.05))), Arr(((V)("#e8dcc4")), ((V)((-0.06)))), Arr(((V)("#b44a3a")), ((V)(0.12)))), "forEach", Fn((V _arrowThis1064, int _argc1052, V _a1054, V i_1058, V _a1056, V _a1057, V[] _rest1053) => {
V col_1061 = default;
V y_1063 = default;
{ V _t1059 = ListOf(_a1054);
{ V _t1060 = GetIdx(_t1059, 0D);
col_1061 = _t1060; }
{ V _t1062 = GetIdx(_t1059, 1D);
y_1063 = _t1062; }
}
return Invoke(Call(book_54, V.Undef, ((V)(40D)), ((V)((TY_992 + (ToNum(i_1058) * 3D)))), ((V)(2D)), ((V)(24D)), ((V)(3D)), ((V)(17D)), col_1061, y_1063), "forEach", Fn((V _arrowThis1072, int _argc1065, V s_1071, V _a1068, V _a1069, V _a1070, V[] _rest1066) => {
return Invoke(o_989, "push", s_1071);
}, 1, "", true));
}, 2, "", true));
return o_989;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_21, "burl22", Fn((V _arrowThis1080, int _argc1073, V S_1079, V _a1076, V _a1077, V _a1078, V[] _rest1074) => {
V BU_1081 = default;
double W_1082 = 0;
double Dp_1083 = 0;
double TY_1084 = 0;
BU_1081 = ((V)("#a2653a"));
W_1082 = 124D;
Dp_1083 = 34D;
TY_1084 = 52D;
return NewObj(5).Put("w", ((V)((W_1082 + 4D)))).Put("d", ((V)((Dp_1083 + 4D)))).Put("topH", ((V)((TY_1084 + 4D)))).Put("topW", ((V)(70D))).Put("build", Fn((V _arrowThis1091, int _argc1085, V _a1087, V _a1088, V _a1089, V _a1090, V[] _rest1086) => {
V o_1092 = default;
V on_1093 = default;
V R_1094 = default;
V TP_1095 = default;
o_1092 = Arr();
on_1093 = Call(glue_48, V.Undef, o_1092);
R_1094 = Call(R0_46, V.Undef, ((V)("burl")));
Invoke(Arr(((V)((-52D))), ((V)(52D))), "forEach", Fn((V _arrowThis1103, int _argc1096, V x_1102, V _a1099, V _a1100, V _a1101, V[] _rest1097) => {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1111, int _argc1104, V sz_1110, V _a1107, V _a1108, V _a1109, V[] _rest1105) => {
return Invoke(o_1092, "push", Call(box_11, V.Undef, x_1102, ((V)(2.4)), ((V)((ToNum(sz_1110) * 13D))), ((V)(2.6)), ((V)((TY_1084 - 2.4))), ((V)(2.6)), BR_25, Call(M__38, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_1092, "push", Call(box_11, V.Undef, x_1102, ((V)(0D)), ((V)(0D)), ((V)(3D)), ((V)(2.4)), ((V)(30D)), BR_25, Call(M__38, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V)), Call(box_11, V.Undef, x_1102, ((V)((TY_1084 - 3D))), ((V)(0D)), ((V)(2.6)), ((V)(2.4)), ((V)(24D)), BR_25, Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
return default;
}, 1, "", true));
Invoke(o_1092, "push", Call(slabX_15, V.Undef, ((V)(0D)), ((V)(9D)), ((V)((-13D))), ((V)(101D)), ((V)(2D)), ((V)(2D)), BR_25, Call(M__38, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("shine", ((V)(1D))).V)));
TP_1095 = Call(box_11, V.Undef, ((V)(0D)), ((V)(TY_1084)), ((V)(0D)), ((V)(W_1082)), ((V)(4D)), ((V)(Dp_1083)), BU_1081, Call(W__37, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("bev", ((V)(1.2))).V));
Invoke(o_1092, "push", TP_1095);
Call(on_1093, V.Undef, TP_1095, Call(rep_43, V.Undef, ((V)(22D)), Fn((V _arrowThis1119, int _argc1112, V i_1118, V _a1115, V _a1116, V _a1117, V[] _rest1113) => {
double x_1120 = 0;
double z_1121 = 0;
double s_1122 = 0;
x_1120 = ((ToNum(Call(R_1094, V.Undef)) - 0.5) * (W_1082 - 14D));
z_1121 = ((ToNum(Call(R_1094, V.Undef)) - 0.5) * (Dp_1083 - 8D));
s_1122 = (1.4 + (ToNum(Call(R_1094, V.Undef)) * 2.6));
return Call(cyl_12, V.Undef, ((V)(x_1120)), ((V)((TY_1084 + 4.02))), ((V)(z_1121)), ((V)((s_1122 * 1.4))), ((V)(0.08)), GetIdx(Arr(((V)("#6e3a1c")), ((V)("#c98c56")), ((V)("#7f4724")), ((V)("#b57540"))), (ToNum(i_1118) % 4D)), NewObj(4).Put("n", ((V)(10D))).Put("rz", ((V)(s_1122))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.7))).V);
return default;
}, 1, "", true)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Call(on_1093, V.Undef, TP_1095, Arr(Call(slabX_15, V.Undef, ((V)(0D)), ((V)((TY_1084 + 1D))), ((V)(((Dp_1083 / 2D) + 0.05))), ((V)((W_1082 - 4D))), ((V)(1.4)), ((V)(0.3)), BR_25, Call(M__38, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(o_1092, "push", Call(rod_30, V.Undef, Arr(((V)((-56D))), ((V)((TY_1084 + 9.6))), ((V)((-15D)))), Arr(((V)(56D)), ((V)((TY_1084 + 9.6))), ((V)((-15D)))), ((V)(0.6)), BR_25, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
Call(rep_43, V.Undef, ((V)(5D)), Fn((V _arrowThis1130, int _argc1123, V i_1129, V _a1126, V _a1127, V _a1128, V[] _rest1124) => {
return Invoke(o_1092, "push", Call(rod_30, V.Undef, Arr(((V)(((-56D) + (ToNum(i_1129) * 28D)))), ((V)((TY_1084 + 4D))), ((V)((-15D)))), Arr(((V)(((-56D) + (ToNum(i_1129) * 28D)))), ((V)((TY_1084 + 9.6))), ((V)((-15D)))), ((V)(0.45)), BR_25, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)));
}, 1, "", true));
Invoke(o_1092, "push", Call(cyl_12, V.Undef, ((V)((-34D))), ((V)((TY_1084 + 4D))), ((V)(2D)), ((V)(9D)), ((V)(4.6)), BR_25, Call(M__38, V.Undef, NewObj(3).Put("n", ((V)(20D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.5))), Arr(((V)(2.4)), ((V)(0D)), ((V)(0.9))), Arr(((V)(4.6)), ((V)(0D)), ((V)(1D))))).V)));
Call(rep_43, V.Undef, ((V)(4D)), Fn((V _arrowThis1138, int _argc1131, V i_1137, V _a1134, V _a1135, V _a1136, V[] _rest1132) => {
return Invoke(o_1092, "push", Call(ball_13, V.Undef, ((V)(((-34D) + (NumTruthy((ToNum(i_1137) % 2D)) ? 3D : (-3D))))), ((V)((TY_1084 + 7D))), ((V)((2D + (GtN(i_1137, 1D) ? 2.6 : (-2.6))))), ((V)(2.6)), GetK(Arr(((V)("#e0b04c")), ((V)("#d9663a")), ((V)("#e86fa8")), ((V)("#4f9a4a"))), i_1137), NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V));
}, 1, "", true));
Invoke(o_1092, "push", Call(cyl_12, V.Undef, ((V)(36D)), ((V)((TY_1084 + 4D))), ((V)((-2D))), ((V)(3D)), ((V)(3D)), ((V)("#2a2b30")), NewObj(1).Put("n", ((V)(12D))).V), Call(ball_13, V.Undef, ((V)(36D)), ((V)((TY_1084 + 7D))), ((V)((-2D))), ((V)(7D)), ((V)("#e9e3d8")), NewObj(3).Put("k", ((V)(5D))).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).V));
Invoke(Arr(Arr(((V)("#1f3a4a")), ((V)(0D))), Arr(((V)("#e0d4b8")), ((V)(0.08)))), "forEach", Fn((V _arrowThis1151, int _argc1139, V _a1141, V i_1145, V _a1143, V _a1144, V[] _rest1140) => {
V col_1148 = default;
V y_1150 = default;
{ V _t1146 = ListOf(_a1141);
{ V _t1147 = GetIdx(_t1146, 0D);
col_1148 = _t1147; }
{ V _t1149 = GetIdx(_t1146, 1D);
y_1150 = _t1149; }
}
return Invoke(Call(book_54, V.Undef, ((V)(10D)), ((V)(((TY_1084 + 4D) + (ToNum(i_1145) * 3.2)))), ((V)(4D)), ((V)(26D)), ((V)(3.2)), ((V)(18D)), col_1148, y_1150), "forEach", Fn((V _arrowThis1159, int _argc1152, V s_1158, V _a1155, V _a1156, V _a1157, V[] _rest1153) => {
return Invoke(o_1092, "push", s_1158);
}, 1, "", true));
}, 2, "", true));
return o_1092;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_21, "liquid22", Fn((V _arrowThis1167, int _argc1160, V S_1166, V _a1163, V _a1164, V _a1165, V[] _rest1161) => {
double W_1168 = 0;
double Dp_1169 = 0;
double TY_1170 = 0;
V leg_1171 = default;
W_1168 = 120D;
Dp_1169 = 32D;
TY_1170 = 46D;
leg_1171 = Fn((V _arrowThis1179, int _argc1172, V sx_1178, V _a1175, V _a1176, V _a1177, V[] _rest1173) => {
return Arr(Call(loft_26, V.Undef, Arr(Arr(((V)(0D)), ((V)((ToNum(sx_1178) * 36D))), ((V)(0D)), ((V)(15D)), ((V)(10D))), Arr(((V)(2.4)), ((V)((ToNum(sx_1178) * 36D))), ((V)(0D)), ((V)(14D)), ((V)(9.4))), Arr(((V)(5D)), ((V)((ToNum(sx_1178) * 35D))), ((V)(0D)), ((V)(9D)), ((V)(6.4)))), CH_24, NewObj(3).Put("n", ((V)(22D))).Put("shine", ((V)(1D))).Put("mat", ((V)("metal"))).V), Call(loft_26, V.Undef, Arr(Arr(((V)(5D)), ((V)((ToNum(sx_1178) * 35D))), ((V)(0D)), ((V)(8.4)), ((V)(6D))), Arr(((V)(16D)), ((V)((ToNum(sx_1178) * 31.6))), ((V)(1D)), ((V)(4.4)), ((V)(3.6))), Arr(((V)(28D)), ((V)((ToNum(sx_1178) * 30.6))), ((V)(0D)), ((V)(3.8)), ((V)(3.2)))), CH_24, NewObj(3).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).Put("mat", ((V)("metal"))).V), Call(loft_26, V.Undef, Arr(Arr(((V)(28D)), ((V)((ToNum(sx_1178) * 30.6))), ((V)(0D)), ((V)(3.8)), ((V)(3.2))), Arr(((V)(37D)), ((V)((ToNum(sx_1178) * 33D))), ((V)((-1D))), ((V)(7D)), ((V)(5D))), Arr(((V)(43D)), ((V)((ToNum(sx_1178) * 36D))), ((V)(0D)), ((V)(13D)), ((V)(8.6))), Arr(((V)(46D)), ((V)((ToNum(sx_1178) * 37D))), ((V)(0D)), ((V)(16D)), ((V)(10.4)))), CH_24, NewObj(3).Put("n", ((V)(22D))).Put("shine", ((V)(1D))).Put("mat", ((V)("metal"))).V));
}, 1, "", true);
return NewObj(6).Put("w", ((V)((W_1168 + 4D)))).Put("d", ((V)((Dp_1169 + 6D)))).Put("topH", ((V)((TY_1170 + 4.6)))).Put("topW", ((V)(66D))).Put("build", Fn((V _arrowThis1186, int _argc1180, V _a1182, V _a1183, V _a1184, V _a1185, V[] _rest1181) => {
V o_1187 = default;
o_1187 = Arr();
Invoke(Invoke(Call(leg_1171, V.Undef, ((V)((-1D)))), "concat", Call(leg_1171, V.Undef, ((V)(1D)))), "forEach", Fn((V _arrowThis1195, int _argc1188, V s_1194, V _a1191, V _a1192, V _a1193, V[] _rest1189) => {
return Invoke(o_1187, "push", s_1194);
}, 1, "", true));
Invoke(o_1187, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(TY_1170)), ((V)(0D)), ((V)(W_1168)), ((V)(4.6)), ((V)(Dp_1169)), CH_24, NewObj(4).Put("r", ((V)(14D))).Put("shine", ((V)(1D))).Put("mat", ((V)("metal"))).Put("bev", ((V)(2D))).V));
Invoke(o_1187, "push", Call(cyl_12, V.Undef, ((V)(14D)), ((V)(0D)), ((V)(18D)), ((V)(5.4)), ((V)(0.4)), CH_24, NewObj(4).Put("n", ((V)(16D))).Put("rz", ((V)(3D))).Put("shine", ((V)(1D))).Put("mat", ((V)("metal"))).V), Call(cyl_12, V.Undef, ((V)((-48D))), ((V)(0D)), ((V)(12D)), ((V)(3D)), ((V)(0.3)), CH_24, NewObj(4).Put("n", ((V)(12D))).Put("rz", ((V)(1.8))).Put("shine", ((V)(1D))).Put("mat", ((V)("metal"))).V));
Invoke(o_1187, "push", Call(ball_13, V.Undef, ((V)((-20D))), ((V)((TY_1170 + 4.6))), ((V)((-4D))), ((V)(6D)), ((V)("#2a2b30")), NewObj(3).Put("k", ((V)(5D))).Put("n", ((V)(16D))).Put("sy", ((V)(1.1))).V), Call(ball_13, V.Undef, ((V)(24D)), ((V)((TY_1170 + 4.6))), ((V)((-6D))), ((V)(3.6)), CH_24, NewObj(4).Put("k", ((V)(4D))).Put("n", ((V)(12D))).Put("sy", ((V)(1.6))).Put("mat", ((V)("metal"))).V));
return o_1187;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1203, int _argc1196, V c_1202, V _a1199, V _a1200, V _a1201, V[] _rest1197) => {
V k_1204 = default;
V a_1205 = default;
V b_1206 = default;
V M_1207 = default;
JsStrBuf f_1208 = null;
k_1204 = Get(c_1202, "k");
a_1205 = Invoke(c_1202, "p", ((V)(14D)), ((V)((TY_1170 + 0.4))), ((V)(17.4)));
b_1206 = Invoke(c_1202, "p", ((V)(14D)), ((V)(0.6)), ((V)(18D)));
M_1207 = Call(TOP_53, V.Undef, c_1202, ((V)((TY_1170 + 4.62))));
f_1208 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"").V(M_1207).S("\"><g clip-path=\"url(#q22lc)\"><rect x=\"-80\" y=\"-18\" width=\"22\" height=\"36\" fill=\"url(#q22ls)\" transform=\"skewX(-25)\">").V(Call(an_35, V.Undef, ((V)("x")), ((V)("-80;80")), ((V)(4.2)))).S("</rect>").V(Invoke(Call(rep_43, V.Undef, ((V)(2D)), Fn((V _arrowThis1216, int _argc1209, V i_1215, V _a1212, V _a1213, V _a1214, V[] _rest1210) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"6\" cy=\"2\" rx=\"1\" ry=\"1\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.4\" opacity=\"0\">").V(Call(an_35, V.Undef, ((V)("rx")), ((V)("1;14")), ((V)(3D)), ((V)(((-ToNum(i_1215)) * 1.5))))).V(Call(an_35, V.Undef, ((V)("ry")), ((V)("1;9")), ((V)(3D)), ((V)(((-ToNum(i_1215)) * 1.5))))).V(Call(an_35, V.Undef, ((V)("opacity")), ((V)("0.8;0")), ((V)(3D)), ((V)(((-ToNum(i_1215)) * 1.5))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g></g>").End());
f_1208.S("<ellipse cx=\"").V(Call(f1_20, V.Undef, GetIdx(a_1205, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(a_1205, 1D))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((1D * ToNum(k_1204)))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((1.4 * ToNum(k_1204)))))).S("\" fill=\"").V(CH_24).S("\" stroke=\"#8a949c\" stroke-width=\"0.3\" opacity=\"0\">").V(Call(an_35, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(a_1205, 1D))).S(";").V(Call(f1_20, V.Undef, GetIdx(a_1205, 1D))).S(";").V(Call(f1_20, V.Undef, GetIdx(b_1206, 1D))).End())), ((V)(3.2)))).V(Call(an_35, V.Undef, ((V)("opacity")), ((V)("0;1;1;0")), ((V)(3.2)))).S("</ellipse>");
f_1208.V(Invoke(Call(ell_52, V.Undef, c_1202, b_1206, ((V)(1D)), ((V)(1D)), ((V)("none")), Add(Add(Call(an_35, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, ((V)((1D * ToNum(k_1204)))))).S(";").V(Call(f1_20, V.Undef, ((V)((1D * ToNum(k_1204)))))).S(";").V(Call(f1_20, V.Undef, ((V)((7D * ToNum(k_1204)))))).End())), ((V)(3.2))), Call(an_35, V.Undef, ((V)("ry")), ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(k_1204)))))).S(";").V(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(k_1204)))))).S(";").V(Call(f1_20, V.Undef, ((V)((3D * ToNum(k_1204)))))).End())), ((V)(3.2)))), Call(an_35, V.Undef, ((V)("opacity")), ((V)("0;0;0.8;0")), ((V)(3.2))))), "replace", ((V)("fill=\"none\"")), ((V)("fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.5\""))));
return NewObj(2).Put("defs", ((V)("<clipPath id=\"q22lc\"><rect x=\"-60\" y=\"-16\" width=\"120\" height=\"32\" rx=\"14\"/></clipPath><linearGradient id=\"q22ls\" x1=\"0\" x2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>"))).Put("front", ((V)(f_1208.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_21, "spool22", Fn((V _arrowThis1224, int _argc1217, V S_1223, V _a1220, V _a1221, V _a1222, V[] _rest1218) => {
V PLY_1225 = default;
V DR_1226 = default;
double R_1227 = 0;
double TY_1228 = 0;
PLY_1225 = ((V)("#d6ae78"));
DR_1226 = ((V)("#b98a58"));
R_1227 = 46D;
TY_1228 = 28D;
return NewObj(7).Put("w", ((V)(((2D * R_1227) + 4D)))).Put("d", ((V)(((2D * R_1227) + 4D)))).Put("round", ((V)(1D))).Put("topH", ((V)((TY_1228 + 5D)))).Put("topW", ((V)(50D))).Put("build", Fn((V _arrowThis1235, int _argc1229, V _a1231, V _a1232, V _a1233, V _a1234, V[] _rest1230) => {
V o_1236 = default;
V on_1237 = default;
V DM_1238 = default;
V TP_1239 = default;
o_1236 = Arr();
on_1237 = Call(glue_48, V.Undef, o_1236);
Invoke(o_1236, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((R_1227 - 2D))), ((V)(5D)), PLY_1225, Call(W__37, V.Undef, NewObj(1).Put("n", ((V)(30D))).V)));
DM_1238 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(0D)), ((V)(17D)), ((V)((TY_1228 - 5D))), DR_1226, Call(W__37, V.Undef, NewObj(1).Put("n", ((V)(22D))).V));
Invoke(o_1236, "push", DM_1238);
Call(on_1237, V.Undef, DM_1238, Invoke(Arr(((V)(9D)), ((V)(13.4)), ((V)(17.8))), "map", Fn((V _arrowThis1247, int _argc1240, V y_1246, V _a1243, V _a1244, V _a1245, V[] _rest1241) => {
return Call(band_50, V.Undef, ((V)(0D)), y_1246, ((V)(0D)), ((V)(17.5)), ((V)(4D)), ((V)("#2a2a2e")), Call(PL_40, V.Undef, NewObj(1).Put("n", ((V)(24D))).V));
}, 1, "", true)));
TP_1239 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(TY_1228)), ((V)(0D)), ((V)(R_1227)), ((V)(5D)), PLY_1225, Call(W__37, V.Undef, NewObj(1).Put("n", ((V)(34D))).V));
Invoke(o_1236, "push", TP_1239);
Call(on_1237, V.Undef, TP_1239, Invoke(Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)((TY_1228 + 5.02))), ((V)(0D)), ((V)(6D)), ((V)(0.1)), ((V)("#5a3a1a")), NewObj(2).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).V)), "concat", Call(rep_43, V.Undef, ((V)(8D)), Fn((V _arrowThis1255, int _argc1248, V i_1254, V _a1251, V _a1252, V _a1253, V[] _rest1249) => {
double a_1256 = 0;
a_1256 = (((ToNum(i_1254) * PI_22) / 4D) + 0.2);
return Call(cyl_12, V.Undef, ((V)((FdLibm.Cos(a_1256) * 30D))), ((V)((TY_1228 + 5.02))), ((V)((FdLibm.Sin(a_1256) * 30D))), ((V)(1.6)), ((V)(0.6)), ((V)("#8a8f94")), Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(8D))).V));
return default;
}, 1, "", true))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Call(on_1237, V.Undef, TP_1239, Call(rep_43, V.Undef, ((V)(3D)), Fn((V _arrowThis1264, int _argc1257, V i_1263, V _a1260, V _a1261, V _a1262, V[] _rest1258) => {
return Call(band_50, V.Undef, ((V)(0D)), ((V)(((TY_1228 + 1.2) + (ToNum(i_1263) * 1.3)))), ((V)(0D)), ((V)((R_1227 + 0.05))), ((V)(0.25)), Call(shade_18, V.Undef, PLY_1225, ((V)(0.74))), NewObj(2).Put("n", ((V)(34D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)));
Invoke(o_1236, "push", Call(cyl_12, V.Undef, ((V)(26D)), ((V)((TY_1228 + 5D))), ((V)((-18D))), ((V)(5D)), ((V)(0.6)), ((V)("#c9a87a")), NewObj(1).Put("n", ((V)(14D))).V));
Call(mug_55, V.Undef, o_1236, ((V)(26D)), ((V)((TY_1228 + 5.6))), ((V)((-18D))), ((V)("#3f7fc8")));
return o_1236;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1272, int _argc1265, V c_1271, V _a1268, V _a1269, V _a1270, V[] _rest1266) => {
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(TOP_53, V.Undef, c_1271, ((V)((TY_1228 + 5.04))))).S("\" opacity=\"0.5\"><text x=\"0\" y=\"33\" text-anchor=\"middle\" ").V(FONT_36).S(" font-size=\"5.4\" fill=\"#5a3a1a\" letter-spacing=\"1.2\">SQUISH CABLE CO.</text><text x=\"-24\" y=\"-24\" text-anchor=\"middle\" ").V(FONT_36).S(" font-size=\"4\" fill=\"#5a3a1a\" transform=\"rotate(-30 -24 -24)\">REEL 07</text></g>").End()))).V;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_21, "hairpin22", Fn((V _arrowThis1280, int _argc1273, V S_1279, V _a1276, V _a1277, V _a1278, V[] _rest1274) => {
V PN_1281 = default;
V BK_1282 = default;
double W_1283 = 0;
double Dp_1284 = 0;
double TY_1285 = 0;
PN_1281 = ((V)("#e2b57e"));
BK_1282 = ((V)("#232428"));
W_1283 = 104D;
Dp_1284 = 52D;
TY_1285 = 32D;
return NewObj(5).Put("w", ((V)((W_1283 + 4D)))).Put("d", ((V)((Dp_1284 + 4D)))).Put("topH", ((V)((TY_1285 + 3D)))).Put("topW", ((V)(60D))).Put("build", Fn((V _arrowThis1292, int _argc1286, V _a1288, V _a1289, V _a1290, V _a1291, V[] _rest1287) => {
V o_1293 = default;
V R_1294 = default;
o_1293 = Arr();
R_1294 = Call(R0_46, V.Undef, ((V)("hp")));
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis1306, int _argc1295, V _a1297, V _a1298, V _a1299, V _a1300, V[] _rest1296) => {
double x_1307 = 0;
double z_1308 = 0;
V sx_1303 = default;
V sz_1305 = default;
{ V _t1301 = ListOf(_a1297);
{ V _t1302 = GetIdx(_t1301, 0D);
sx_1303 = _t1302; }
{ V _t1304 = GetIdx(_t1301, 1D);
sz_1305 = _t1304; }
}
x_1307 = (ToNum(sx_1303) * ((W_1283 / 2D) - 8D));
z_1308 = (ToNum(sz_1305) * ((Dp_1284 / 2D) - 7D));
Invoke(o_1293, "push", Call(rod_30, V.Undef, Arr(((V)((x_1307 - 2.4))), ((V)(TY_1285)), ((V)(z_1308))), Arr(((V)(x_1307)), ((V)(0.6)), ((V)(z_1308))), ((V)(0.55)), BK_1282, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(rod_30, V.Undef, Arr(((V)((x_1307 + 2.4))), ((V)(TY_1285)), ((V)(z_1308))), Arr(((V)(x_1307)), ((V)(0.6)), ((V)(z_1308))), ((V)(0.55)), BK_1282, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(ball_13, V.Undef, ((V)(x_1307)), ((V)(0D)), ((V)(z_1308)), ((V)(0.9)), BK_1282, Call(M__38, V.Undef, NewObj(2).Put("k", ((V)(2D))).Put("n", ((V)(6D))).V)));
return default;
}, 1, "", true));
Invoke(o_1293, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)((W_1283 - 24D))), ((V)(2.4)), ((V)((Dp_1284 - 17D))), Call(shade_18, V.Undef, PN_1281, ((V)(0.95))), Call(W__37, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)), Call(box_11, V.Undef, ((V)(0D)), ((V)(TY_1285)), ((V)(0D)), ((V)(W_1283)), ((V)(3D)), ((V)(Dp_1284)), PN_1281, Call(W__37, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("bev", ((V)(0.8))).V)));
Invoke(Arr(Arr(((V)("#e86f5a")), ((V)(0.1))), Arr(((V)("#3f7fc8")), ((V)((-0.15)))), Arr(((V)("#f2e27a")), ((V)(0.3)))), "forEach", Fn((V _arrowThis1321, int _argc1309, V _a1311, V i_1315, V _a1313, V _a1314, V[] _rest1310) => {
V col_1318 = default;
V y_1320 = default;
{ V _t1316 = ListOf(_a1311);
{ V _t1317 = GetIdx(_t1316, 0D);
col_1318 = _t1317; }
{ V _t1319 = GetIdx(_t1316, 1D);
y_1320 = _t1319; }
}
return Invoke(o_1293, "push", Call(box_11, V.Undef, Add(((V)((-26D))), i_1315), ((V)((12.4 + (ToNum(i_1315) * 0.8)))), ((V)(2D)), ((V)(22D)), ((V)(0.8)), ((V)(16D)), col_1318, Call(PL_40, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("yaw", y_1320).V)));
}, 2, "", true));
Invoke(o_1293, "push", Call(cyl_12, V.Undef, ((V)(24D)), ((V)(12.4)), ((V)(0D)), ((V)(10D)), ((V)(8D)), ((V)("#c9a06a")), Call(F__39, V.Undef, NewObj(3).Put("n", ((V)(20D))).Put("soft", ((V)(0D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.88))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))))).V)));
Call(rep_43, V.Undef, ((V)(3D)), Fn((V _arrowThis1329, int _argc1322, V i_1328, V _a1325, V _a1326, V _a1327, V[] _rest1323) => {
return Invoke(o_1293, "push", Call(ball_13, V.Undef, ((V)((21D + (ToNum(i_1328) * 3D)))), ((V)(19.4)), ((V)(((-1D) + ((ToNum(i_1328) % 2D) * 2D)))), ((V)(3.4)), GetK(Arr(((V)("#f2ead8")), ((V)("#9cbf8a")), ((V)("#e0b04c"))), i_1328), Call(F__39, V.Undef, NewObj(4).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("shine", ((V)(0D))).Put("sy", ((V)(0.8))).V)));
}, 1, "", true));
Invoke(o_1293, "push", Call(cyl_12, V.Undef, ((V)(34D)), ((V)((TY_1285 + 3D))), ((V)((-12D))), ((V)(5D)), ((V)(7D)), ((V)("#d86a4a")), NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(7D)), ((V)(0D)), ((V)(1D))))).V));
Call(sprig_56, V.Undef, o_1293, ((V)(34D)), ((V)((TY_1285 + 10D))), ((V)((-12D))), R_1294, V.Null, ((V)(8D)));
Invoke(Arr(Arr(((V)((-30D))), ((V)(10D))), Arr(((V)((-20D))), ((V)(14D)))), "forEach", Fn((V _arrowThis1341, int _argc1330, V _a1332, V _a1333, V _a1334, V _a1335, V[] _rest1331) => {
V x_1338 = default;
V z_1340 = default;
{ V _t1336 = ListOf(_a1332);
{ V _t1337 = GetIdx(_t1336, 0D);
x_1338 = _t1337; }
{ V _t1339 = GetIdx(_t1336, 1D);
z_1340 = _t1339; }
}
return Invoke(o_1293, "push", Call(cyl_12, V.Undef, x_1338, ((V)((TY_1285 + 3D))), z_1340, ((V)(4D)), ((V)(0.6)), ((V)("#3a3b40")), NewObj(1).Put("n", ((V)(14D))).V));
}, 1, "", true));
return o_1293;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_21, "live22", Fn((V _arrowThis1349, int _argc1342, V S_1348, V _a1345, V _a1346, V _a1347, V[] _rest1343) => {
V WAL_1350 = default;
V SAP_1351 = default;
V ST_1352 = default;
double TY_1353 = 0;
V outl_1354 = default;
WAL_1350 = ((V)("#6e4226"));
SAP_1351 = ((V)("#d9b07c"));
ST_1352 = ((V)("#232428"));
TY_1353 = 26.4;
outl_1354 = Fn((V _arrowThis1364, int _argc1355, V a_1361, V b_1362, V g_1363, V _a1360, V[] _rest1356) => {
return Call(rep_43, V.Undef, ((V)(32D)), Fn((V _arrowThis1372, int _argc1365, V i_1371, V _a1368, V _a1369, V _a1370, V[] _rest1366) => {
double t_1373 = 0;
double c_1374 = 0;
double s_1375 = 0;
double ex_1376 = 0;
double w_1377 = 0;
t_1373 = (((ToNum(i_1371) / 32D) * 2D) * PI_22);
c_1374 = FdLibm.Cos(t_1373);
s_1375 = FdLibm.Sin(t_1373);
ex_1376 = 0.32;
w_1377 = (1D + ((ToNum(g_1363) * ((0.05 * FdLibm.Sin(((5D * t_1373) + 1D))) + (0.03 * FdLibm.Sin(((9D * t_1373) + 2D))))) * System.Math.Abs(s_1375)));
return Arr(((V)(((ToNum(a_1361) * Sign(c_1374)) * Pow(System.Math.Abs(c_1374), ex_1376)))), ((V)((((ToNum(b_1362) * w_1377) * Sign(s_1375)) * Pow(System.Math.Abs(s_1375), 0.8)))));
return default;
}, 1, "", true));
}, 3, "", true);
return NewObj(6).Put("w", ((V)(118D))).Put("d", ((V)(62D))).Put("topH", ((V)((TY_1353 + 4D)))).Put("topW", ((V)(60D))).Put("build", Fn((V _arrowThis1384, int _argc1378, V _a1380, V _a1381, V _a1382, V _a1383, V[] _rest1379) => {
V o_1385 = default;
V on_1386 = default;
V SW_1387 = default;
V HW_1388 = default;
o_1385 = Arr();
on_1386 = Call(glue_48, V.Undef, o_1385);
Invoke(Arr(((V)((-40D))), ((V)(40D))), "forEach", Fn((V _arrowThis1396, int _argc1389, V x_1395, V _a1392, V _a1393, V _a1394, V[] _rest1390) => {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1404, int _argc1397, V sz_1403, V _a1400, V _a1401, V _a1402, V[] _rest1398) => {
return Invoke(o_1385, "push", Call(box_11, V.Undef, x_1395, ((V)(2.4)), ((V)((ToNum(sz_1403) * 20D))), ((V)(3D)), ((V)((TY_1353 - 4.8))), ((V)(3D)), ST_1352, Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}, 1, "", true));
Invoke(o_1385, "push", Call(box_11, V.Undef, x_1395, ((V)(0D)), ((V)(0D)), ((V)(3D)), ((V)(2.4)), ((V)(44D)), ST_1352, Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)), Call(box_11, V.Undef, x_1395, ((V)((TY_1353 - 2.4))), ((V)(0D)), ((V)(3D)), ((V)(2.4)), ((V)(44D)), ST_1352, Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
return default;
}, 1, "", true));
SW_1387 = Call(prism_49, V.Undef, Call(outl_1354, V.Undef, ((V)(57D)), ((V)(28D)), ((V)(1D))), ((V)(TY_1353)), ((V)(3D)), SAP_1351, Call(W__37, V.Undef, NewObj(0).V));
Invoke(o_1385, "push", SW_1387);
HW_1388 = GetIdx(Call(on_1386, V.Undef, SW_1387, Arr(Call(prism_49, V.Undef, Call(outl_1354, V.Undef, ((V)(55D)), ((V)(24.5)), ((V)(1.4))), ((V)((TY_1353 + 3D))), ((V)(1D)), WAL_1350, Call(W__37, V.Undef, NewObj(0).V))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D)))), 0D);
Call(on_1386, V.Undef, HW_1388, Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis1412, int _argc1405, V s_1411, V _a1408, V _a1409, V _a1410, V[] _rest1406) => {
return Call(box_11, V.Undef, ((V)(((-12D) + (ToNum(s_1411) * 1.5)))), ((V)((TY_1353 + 4.02))), ((V)(6D)), ((V)(3.2)), ((V)(0.1)), ((V)(2.4)), ((V)("#2e1a0c")), NewObj(3).Put("r", ((V)(0.2))).Put("yaw", ((V)((ToNum(s_1411) * 0.5)))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Invoke(o_1385, "push", Call(cyl_12, V.Undef, ((V)(26D)), ((V)((TY_1353 + 4D))), ((V)((-4D))), ((V)(9D)), ((V)(4.4)), ((V)("#8a5a34")), Call(W__37, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.55))), Arr(((V)(2D)), ((V)(0D)), ((V)(0.88))), Arr(((V)(4.4)), ((V)(0D)), ((V)(1D))))).V)));
Call(rep_43, V.Undef, ((V)(3D)), Fn((V _arrowThis1420, int _argc1413, V i_1419, V _a1416, V _a1417, V _a1418, V[] _rest1414) => {
return Invoke(o_1385, "push", Call(ball_13, V.Undef, ((V)((23D + (ToNum(i_1419) * 3D)))), ((V)((TY_1353 + 7.4))), ((V)(((-5D) + ((ToNum(i_1419) % 2D) * 2.6)))), ((V)(3D)), GetK(Arr(((V)("#5f9a4a")), ((V)("#7fb25a")), ((V)("#4f8a3e"))), i_1419), Call(F__39, V.Undef, NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("shine", ((V)(0D))).V)));
}, 1, "", true));
Invoke(o_1385, "push", Call(cyl_12, V.Undef, ((V)((-30D))), ((V)((TY_1353 + 4D))), ((V)((-6D))), ((V)(3D)), ((V)(6D)), ((V)("#f2efe8")), NewObj(3).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_12, V.Undef, ((V)((-30D))), ((V)((TY_1353 + 9.7))), ((V)((-6D))), ((V)(2.5)), ((V)(0.3)), ((V)("#5a3418")), NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V));
return o_1385;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1428, int _argc1421, V c_1427, V _a1424, V _a1425, V _a1426, V[] _rest1422) => {
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(TOP_53, V.Undef, c_1427, ((V)((TY_1353 + 4.03))))).S("\" opacity=\"0.55\"><path d=\"M-12 26Q-13 18 -11.5 10T-12 7.4M-12 4.6Q-11 0 -14 -6\" stroke=\"#22120a\" stroke-width=\"0.5\" fill=\"none\" stroke-linecap=\"round\"/></g>").End()))).V;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_21, "drum22", Fn((V _arrowThis1436, int _argc1429, V S_1435, V _a1432, V _a1433, V _a1434, V[] _rest1430) => {
V TV_1437 = default;
V TVD_1438 = default;
V BZ_1439 = default;
TV_1437 = ((V)("#eadcc2"));
TVD_1438 = ((V)("#d4c09c"));
BZ_1439 = ((V)("#4e3e32"));
return NewObj(6).Put("w", ((V)(98D))).Put("d", ((V)(76D))).Put("topH", ((V)(30D))).Put("topZ", ((V)((-4D)))).Put("topW", ((V)(40D))).Put("build", Fn((V _arrowThis1446, int _argc1440, V _a1442, V _a1443, V _a1444, V _a1445, V[] _rest1441) => {
V o_1447 = default;
V on_1448 = default;
V R_1449 = default;
V T_1450 = default;
V B_1451 = default;
o_1447 = Arr();
on_1448 = Call(glue_48, V.Undef, o_1447);
R_1449 = Call(R0_46, V.Undef, ((V)("trav")));
T_1450 = Call(cyl_12, V.Undef, ((V)((-12D))), ((V)(0D)), ((V)((-6D))), ((V)(30D)), ((V)(30D)), TV_1437, NewObj(2).Put("n", ((V)(34D))).Put("mat", ((V)("cer"))).V);
Invoke(o_1447, "push", T_1450);
Call(on_1448, V.Undef, T_1450, Invoke(Arr(((V)(9.5)), ((V)(21D))), "map", Fn((V _arrowThis1459, int _argc1452, V y_1458, V _a1455, V _a1456, V _a1457, V[] _rest1453) => {
return Call(band_50, V.Undef, ((V)((-12D))), y_1458, ((V)((-6D))), ((V)(30.05)), ((V)(0.6)), Call(mix_19, V.Undef, TV_1437, TVD_1438, ((V)(0.55))), NewObj(2).Put("n", ((V)(34D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)));
Call(on_1448, V.Undef, T_1450, Call(rep_43, V.Undef, ((V)(18D)), Fn((V _arrowThis1466, int _argc1460, V _a1462, V _a1463, V _a1464, V _a1465, V[] _rest1461) => {
double a_1467 = 0;
double r_1468 = 0;
a_1467 = ((ToNum(Call(R_1449, V.Undef)) * 2D) * PI_22);
r_1468 = (System.Math.Sqrt(ToNum(Call(R_1449, V.Undef))) * 26D);
return Call(cyl_12, V.Undef, ((V)(((-12D) + (FdLibm.Cos(a_1467) * r_1468)))), ((V)(30.02)), ((V)(((-6D) + (FdLibm.Sin(a_1467) * r_1468)))), ((V)((0.5 + (ToNum(Call(R_1449, V.Undef)) * 0.9)))), ((V)(0.05)), ((V)("#c7b28c")), NewObj(3).Put("n", ((V)(8D))).Put("rz", ((V)((0.4 + (ToNum(Call(R_1449, V.Undef)) * 0.5))))).Put("noOut", ((V)(1D))).V);
return default;
}, 0, "", true)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
B_1451 = Call(cyl_12, V.Undef, ((V)(32D)), ((V)(0D)), ((V)(16D)), ((V)(17D)), ((V)(21D)), BZ_1439, Call(M__38, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).V));
Invoke(o_1447, "push", B_1451);
Call(on_1448, V.Undef, B_1451, Arr(Call(band_50, V.Undef, ((V)(32D)), ((V)(20.2)), ((V)(16D)), ((V)(17.05)), ((V)(0.8)), BR_25, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(28D))).V))));
Invoke(o_1447, "push", Call(cyl_12, V.Undef, ((V)(32D)), ((V)(21D)), ((V)(16D)), ((V)(7D)), ((V)(4D)), ((V)("#f2efe8")), NewObj(3).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.5))), Arr(((V)(2D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(4D)), ((V)(0D)), ((V)(1D))))).V));
Invoke(Call(book_54, V.Undef, ((V)((-28D))), ((V)(30D)), ((V)(4D)), ((V)(22D)), ((V)(2.6)), ((V)(16D)), ((V)("#2f4f5a")), ((V)(0.2))), "forEach", Fn((V _arrowThis1476, int _argc1469, V s_1475, V _a1472, V _a1473, V _a1474, V[] _rest1470) => {
return Invoke(o_1447, "push", s_1475);
}, 1, "", true));
Invoke(o_1447, "push", Call(ball_13, V.Undef, ((V)((-28D))), ((V)(32.6)), ((V)(4D)), ((V)(2.6)), BR_25, Call(M__38, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(10D))).Put("sy", ((V)(0.6))).V)));
return o_1447;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_21, "koi22", Fn((V _arrowThis1484, int _argc1477, V S_1483, V _a1480, V _a1481, V _a1482, V[] _rest1478) => {
double W_1485 = 0;
double Dp_1486 = 0;
double TY_1487 = 0;
W_1485 = 110D;
Dp_1486 = 60D;
TY_1487 = 26D;
return NewObj(6).Put("w", ((V)((W_1485 + 4D)))).Put("d", ((V)((Dp_1486 + 4D)))).Put("topH", ((V)((TY_1487 + 2D)))).Put("topW", ((V)(60D))).Put("build", Fn((V _arrowThis1494, int _argc1488, V _a1490, V _a1491, V _a1492, V _a1493, V[] _rest1489) => {
V o_1495 = default;
V on_1496 = default;
V R_1497 = default;
V PL0_1498 = default;
o_1495 = Arr();
on_1496 = Call(glue_48, V.Undef, o_1495);
R_1497 = Call(R0_46, V.Undef, ((V)("koi")));
PL0_1498 = Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((W_1485 - 8D))), ((V)(4D)), ((V)((Dp_1486 - 8D))), ((V)("#2e3338")), NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("cer"))).V);
Invoke(o_1495, "push", PL0_1498);
Call(on_1496, V.Undef, PL0_1498, Call(rep_43, V.Undef, ((V)(26D)), Fn((V _arrowThis1506, int _argc1499, V i_1505, V _a1502, V _a1503, V _a1504, V[] _rest1500) => {
return Call(ball_13, V.Undef, ((V)(((ToNum(Call(R_1497, V.Undef)) - 0.5) * (W_1485 - 20D)))), ((V)(4D)), ((V)(((ToNum(Call(R_1497, V.Undef)) - 0.5) * (Dp_1486 - 18D)))), ((V)((1.6 + (ToNum(Call(R_1497, V.Undef)) * 1.6)))), GetIdx(Arr(((V)("#8a8478")), ((V)("#b8ae9a")), ((V)("#5e5a54"))), (ToNum(i_1505) % 3D)), NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sy", ((V)(0.6))).Put("shine", ((V)(0D))).V);
}, 1, "", true)));
Call(on_1496, V.Undef, PL0_1498, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)((W_1485 - 4D))), ((V)((TY_1487 - 4D))), ((V)((Dp_1486 - 4D))), ((V)("#1f7088")), NewObj(2).Put("r", ((V)(3D))).Put("op", ((V)(0.55))).V)));
Call(on_1496, V.Undef, PL0_1498, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(TY_1487)), ((V)(0D)), ((V)(W_1485)), ((V)(2D)), ((V)(Dp_1486)), ((V)("#d6f4fa")), NewObj(3).Put("r", ((V)(3D))).Put("op", ((V)(0.3))).Put("shine", ((V)(1D))).V)));
Call(on_1496, V.Undef, PL0_1498, Arr(Call(slabX_15, V.Undef, ((V)(0D)), ((V)((TY_1487 - 0.4))), ((V)(((Dp_1486 / 2D) + 0.1))), ((V)((W_1485 - 2D))), ((V)(2.4)), ((V)(0.6)), ((V)("#2a2d34")), Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_11, V.Undef, ((V)(((W_1485 / 2D) + 0.1))), ((V)((TY_1487 - 0.4))), ((V)(0D)), ((V)(0.6)), ((V)(2.4)), ((V)((Dp_1486 - 2D))), ((V)("#2a2d34")), Call(M__38, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))));
return o_1495;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1514, int _argc1507, V c_1513, V _a1510, V _a1511, V _a1512, V[] _rest1508) => {
V M_1515 = default;
V fish_1516 = default;
V swim_1517 = default;
JsStrBuf f_1518 = null;
M_1515 = Call(TOP_53, V.Undef, c_1513, ((V)((TY_1487 - 1D))));
fish_1516 = Fn((V _arrowThis1528, int _argc1519, V col_1525, V spot_1526, V s_1527, V _a1524, V[] _rest1520) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"scale(").V(s_1527).S(")\"><path d=\"M7 0C5 -3 -2 -3.2 -5 -1L-10 -3.4L-8.6 0L-10 3.4L-5 1C-2 3.2 5 3 7 0Z\" fill=\"").V(col_1525).S("\" stroke=\"#ffffff\" stroke-opacity=\"0.5\" stroke-width=\"0.4\"><animateTransform attributeName=\"transform\" type=\"skewY\" values=\"-6;6;-6\" dur=\"0.9s\" repeatCount=\"indefinite\"/></path><ellipse cx=\"1\" cy=\"-0.6\" rx=\"2.6\" ry=\"1.4\" fill=\"").V(spot_1526).S("\"/><path d=\"M1 -2.6L-1 -5L-2 -2.2Z\" fill=\"").V(col_1525).S("\" opacity=\"0.8\"/></g>").End()));
}, 3, "", true);
swim_1517 = Fn((V _arrowThis1539, int _argc1529, V path_1535, V d_1536, V b_1537, V body_1538, V[] _rest1530) => {
return ((V)(JsStrBuf.Begin().S("<g opacity=\"0.92\">").V(body_1538).S("<animateMotion path=\"").V(path_1535).S("\" dur=\"").V(d_1536).S("s\" begin=\"").V(b_1537).S("s\" rotate=\"auto\" repeatCount=\"indefinite\"/></g>").End()));
}, 4, "", true);
f_1518 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"").V(M_1515).S("\"><g clip-path=\"url(#q22kc)\"><rect x=\"-52\" y=\"-28\" width=\"104\" height=\"56\" fill=\"url(#q22kw)\" opacity=\"0.5\"><animate attributeName=\"opacity\" values=\"0.3;0.6;0.3\" dur=\"3s\" repeatCount=\"indefinite\"/></rect>").End());
f_1518.V(Call(swim_1517, V.Undef, ((V)("M-36 0a36 16 0 1 0 72 0a36 16 0 1 0 -72 0")), ((V)(14D)), ((V)(0D)), Call(fish_1516, V.Undef, ((V)("#ff7a2a")), ((V)("#ffffff")), ((V)(1D)))));
f_1518.V(Call(swim_1517, V.Undef, ((V)("M30 4a28 12 0 1 1 -56 0a28 12 0 1 1 56 0")), ((V)(11D)), ((V)((-3D))), Call(fish_1516, V.Undef, ((V)("#fff6ea")), ((V)("#e8402a")), ((V)(0.85)))));
f_1518.V(Call(swim_1517, V.Undef, ((V)("M-20 -6a22 14 0 1 0 44 0a22 14 0 1 0 -44 0")), ((V)(9D)), ((V)((-5D))), Call(fish_1516, V.Undef, ((V)("#ffc63a")), ((V)("#ff7a2a")), ((V)(0.7)))));
Invoke(Arr(Arr(((V)((-34D))), ((V)((-14D))), ((V)(7D))), Arr(((V)(30D)), ((V)(14D)), ((V)(6D))), Arr(((V)(38D)), ((V)((-12D))), ((V)(4.6)))), "forEach", Fn((V _arrowThis1553, int _argc1540, V _a1542, V _a1543, V _a1544, V _a1545, V[] _rest1541) => {
V x_1548 = default;
V y_1550 = default;
V r_1552 = default;
{ V _t1546 = ListOf(_a1542);
{ V _t1547 = GetIdx(_t1546, 0D);
x_1548 = _t1547; }
{ V _t1549 = GetIdx(_t1546, 1D);
y_1550 = _t1549; }
{ V _t1551 = GetIdx(_t1546, 2D);
r_1552 = _t1551; }
}
f_1518.S("<path d=\"M").V(x_1548).S(" ").V(y_1550).S("m0 0l").V(r_1552).S(" -1.6a").V(r_1552).S(" ").V(r_1552).S(" 0 1 1 -1.4 -3.2Z\" fill=\"#4f9a4a\" stroke=\"#2f6a2e\" stroke-width=\"0.4\"/>");
return default;
}, 1, "", true));
f_1518.S("<g transform=\"translate(-30 -16)\"><circle r=\"2.6\" fill=\"#ffb0cc\"/><circle r=\"1.2\" fill=\"#ffe27a\"/></g>");
Call(rep_43, V.Undef, ((V)(3D)), Fn((V _arrowThis1561, int _argc1554, V i_1560, V _a1557, V _a1558, V _a1559, V[] _rest1555) => {
f_1518.S("<ellipse cx=\"").V(GetK(Arr(((V)(10D)), ((V)((-16D))), ((V)(24D))), i_1560)).S("\" cy=\"").V(GetK(Arr(((V)((-8D))), ((V)(10D)), ((V)(6D))), i_1560)).S("\" rx=\"1\" ry=\"1\" fill=\"none\" stroke=\"#e8fbff\" stroke-width=\"0.5\" opacity=\"0\">").V(Call(an_35, V.Undef, ((V)("rx")), ((V)("1;12")), ((V)(3.4)), ((V)(((-ToNum(i_1560)) * 1.1))))).V(Call(an_35, V.Undef, ((V)("ry")), ((V)("1;6")), ((V)(3.4)), ((V)(((-ToNum(i_1560)) * 1.1))))).V(Call(an_35, V.Undef, ((V)("opacity")), ((V)("0.9;0")), ((V)(3.4)), ((V)(((-ToNum(i_1560)) * 1.1))))).S("</ellipse>");
return default;
}, 1, "", true));
f_1518.S("</g></g>");
return NewObj(2).Put("defs", ((V)("<clipPath id=\"q22kc\"><rect x=\"-52\" y=\"-28\" width=\"104\" height=\"56\" rx=\"3\"/></clipPath><pattern id=\"q22kw\" width=\"16\" height=\"8\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 4Q4 1 8 4T16 4\" stroke=\"#bff6ff\" stroke-width=\"0.5\" fill=\"none\"/></pattern>"))).Put("front", ((V)(f_1518.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_21, "crate22", Fn((V _arrowThis1569, int _argc1562, V S_1568, V _a1565, V _a1566, V _a1567, V[] _rest1563) => {
V RED_1570 = default;
V RD2_1571 = default;
double W_1572 = 0;
double H_1573 = 0;
double Dp_1574 = 0;
RED_1570 = ((V)("#d9363b"));
RD2_1571 = Call(shade_18, V.Undef, RED_1570, ((V)(0.62)));
W_1572 = 34D;
H_1573 = 30D;
Dp_1574 = 30D;
return NewObj(5).Put("w", ((V)((W_1572 + 4D)))).Put("d", ((V)((Dp_1574 + 4D)))).Put("topH", ((V)(H_1573))).Put("topW", ((V)(22D))).Put("build", Fn((V _arrowThis1581, int _argc1575, V _a1577, V _a1578, V _a1579, V _a1580, V[] _rest1576) => {
V o_1582 = default;
V on_1583 = default;
V C_1584 = default;
o_1582 = Arr();
on_1583 = Call(glue_48, V.Undef, o_1582);
C_1584 = Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(W_1572)), ((V)(H_1573)), ((V)(Dp_1574)), RED_1570, Call(PL_40, V.Undef, NewObj(2).Put("r", ((V)(2.4))).Put("bev", ((V)(1D))).V));
Invoke(o_1582, "push", C_1584);
Call(on_1583, V.Undef, C_1584, Invoke(Invoke(Call(rep_43, V.Undef, ((V)(3D)), Fn((V _arrowThis1592, int _argc1585, V i_1591, V _a1588, V _a1589, V _a1590, V[] _rest1586) => {
return Call(rep_43, V.Undef, ((V)(2D)), Fn((V _arrowThis1600, int _argc1593, V j_1599, V _a1596, V _a1597, V _a1598, V[] _rest1594) => {
return Call(box_11, V.Undef, ((V)(((-10D) + (ToNum(i_1591) * 10D)))), ((V)((6D + (ToNum(j_1599) * 10D)))), ((V)(((Dp_1574 / 2D) + 0.05))), ((V)(7D)), ((V)(7D)), ((V)(0.4)), RD2_1571, NewObj(2).Put("r", ((V)(1.6))).Put("noOut", ((V)(1D))).V);
}, 1, "", true));
}, 1, "", true)), "flat"), "concat", Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)((H_1573 - 6D))), ((V)(((Dp_1574 / 2D) + 0.05))), ((V)(12D)), ((V)(2.6)), ((V)(0.4)), RD2_1571, NewObj(2).Put("r", ((V)(1.2))).Put("noOut", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1583, V.Undef, C_1584, Invoke(Call(rep_43, V.Undef, ((V)(3D)), Fn((V _arrowThis1608, int _argc1601, V i_1607, V _a1604, V _a1605, V _a1606, V[] _rest1602) => {
return Call(rep_43, V.Undef, ((V)(2D)), Fn((V _arrowThis1616, int _argc1609, V j_1615, V _a1612, V _a1613, V _a1614, V[] _rest1610) => {
return Call(box_11, V.Undef, ((V)(((W_1572 / 2D) + 0.05))), ((V)((6D + (ToNum(j_1615) * 10D)))), ((V)(((-9D) + (ToNum(i_1607) * 9D)))), ((V)(0.4)), ((V)(7D)), ((V)(6.4)), RD2_1571, NewObj(2).Put("r", ((V)(1.6))).Put("noOut", ((V)(1D))).V);
}, 1, "", true));
}, 1, "", true)), "flat"), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))));
Call(on_1583, V.Undef, C_1584, Invoke(Call(rep_43, V.Undef, ((V)(4D)), Fn((V _arrowThis1624, int _argc1617, V i_1623, V _a1620, V _a1621, V _a1622, V[] _rest1618) => {
return Call(rep_43, V.Undef, ((V)(4D)), Fn((V _arrowThis1632, int _argc1625, V j_1631, V _a1628, V _a1629, V _a1630, V[] _rest1626) => {
return Call(box_11, V.Undef, ((V)(((-11.4) + (ToNum(i_1623) * 7.6)))), ((V)((H_1573 + 0.02))), ((V)(((-10D) + (ToNum(j_1631) * 6.8)))), ((V)(5D)), ((V)(0.06)), ((V)(4.6)), RD2_1571, NewObj(2).Put("r", ((V)(0.8))).Put("noOut", ((V)(1D))).V);
}, 1, "", true));
}, 1, "", true)), "flat"), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Invoke(o_1582, "push", Call(cyl_12, V.Undef, ((V)(5D)), ((V)(H_1573)), ((V)(4D)), ((V)(4.6)), ((V)(8.4)), ((V)("#fbf6ec")), Call(PL_40, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.78))), Arr(((V)(8.4)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_12, V.Undef, ((V)(5D)), ((V)((H_1573 + 3D))), ((V)(4D)), ((V)(4.4)), ((V)(2.6)), ((V)("#e8402a")), Call(PL_40, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).V)), Call(tilt_27, V.Undef, Call(box_11, V.Undef, ((V)(5D)), ((V)((H_1573 + 8.4))), ((V)(4D)), ((V)(9D)), ((V)(0.3)), ((V)(9D)), ((V)("#e8e2d4")), NewObj(1).Put("r", ((V)(3.6))).V), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.5))), Arr(((V)(5D)), ((V)((H_1573 + 8.4))), ((V)((-0.6))))));
Invoke(o_1582, "push", Call(rod_30, V.Undef, Arr(((V)(6D)), ((V)((H_1573 + 6D))), ((V)(4D))), Arr(((V)(9D)), ((V)((H_1573 + 15D))), ((V)(1D))), ((V)(0.3)), ((V)("#f2f2f2")), Call(PL_40, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)));
Invoke(Call(pipe_31, V.Undef, Arr(Arr(((V)((-8D))), ((V)((H_1573 + 0.4))), ((V)((-4D)))), Arr(((V)((-14D))), ((V)((H_1573 + 0.4))), ((V)(4D))), Arr(((V)((((-W_1572) / 2D) - 0.8))), ((V)((H_1573 - 2D))), ((V)(6D))), Arr(((V)((((-W_1572) / 2D) - 0.8))), ((V)(4D)), ((V)(8D)))), ((V)(0.4)), ((V)("#f4f4f4")), Call(PL_40, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)), "forEach", Fn((V _arrowThis1640, int _argc1633, V s_1639, V _a1636, V _a1637, V _a1638, V[] _rest1634) => {
return Invoke(o_1582, "push", s_1639);
}, 1, "", true));
Invoke(o_1582, "push", Call(box_11, V.Undef, ((V)((-6D))), ((V)(H_1573)), ((V)((-6D))), ((V)(4.6)), ((V)(0.7)), ((V)(9D)), ((V)("#2a2d34")), Call(PL_40, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)(0.4))).V)));
return o_1582;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_21, "bistro22", Fn((V _arrowThis1648, int _argc1641, V S_1647, V _a1644, V _a1645, V _a1646, V[] _rest1642) => {
V WH_1649 = default;
WH_1649 = ((V)("#f7f5f0"));
return NewObj(6).Put("w", ((V)(42D))).Put("d", ((V)(42D))).Put("round", ((V)(1D))).Put("topH", ((V)(38.4))).Put("topW", ((V)(24D))).Put("build", Fn((V _arrowThis1656, int _argc1650, V _a1652, V _a1653, V _a1654, V _a1655, V[] _rest1651) => {
V o_1657 = default;
o_1657 = Arr();
Invoke(o_1657, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(13D)), ((V)(2.4)), WH_1649, Call(G__41, V.Undef, NewObj(2).Put("n", ((V)(26D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(2.4)), ((V)(0D)), ((V)(0.9))))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(2.4)), ((V)(0D)), ((V)(10D)), ((V)(4D)), WH_1649, Call(G__41, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(2D)), ((V)(0D)), ((V)(0.55))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.3))))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(6.4)), ((V)(0D)), ((V)(3D)), ((V)(22D)), WH_1649, Call(G__41, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(22D)), ((V)(0D)), ((V)(0.85))))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(28.4)), ((V)(0D)), ((V)(3D)), ((V)(7.6)), WH_1649, Call(G__41, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.85))), Arr(((V)(4D)), ((V)(0D)), ((V)(1.6))), Arr(((V)(7.6)), ((V)(0D)), ((V)(3.6))))).V)));
Invoke(o_1657, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(0D)), ((V)(19D)), ((V)(2.4)), WH_1649, Call(G__41, V.Undef, NewObj(1).Put("n", ((V)(32D))).V)));
Invoke(o_1657, "push", Call(cyl_12, V.Undef, ((V)((-5D))), ((V)(38.4)), ((V)((-2D))), ((V)(2.4)), ((V)(8D)), ((V)("#bfe2ee")), NewObj(4).Put("n", ((V)(14D))).Put("op", ((V)(0.6))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))), Arr(((V)(8D)), ((V)(0D)), ((V)(0.6))))).V), Call(rod_30, V.Undef, Arr(((V)((-5D))), ((V)(44D)), ((V)((-2D)))), Arr(((V)((-4.2))), ((V)(54D)), ((V)((-2.4)))), ((V)(0.3)), ((V)("#5f9a4a")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_13, V.Undef, ((V)((-4.2))), ((V)(53.4)), ((V)((-2.4))), ((V)(2D)), ((V)("#ff6f8a")), NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("sy", ((V)(1.3))).V), Call(ball_13, V.Undef, ((V)((-6D))), ((V)(49D)), ((V)((-1.6))), ((V)(1.4)), ((V)("#6fae5a")), NewObj(4).Put("sx", ((V)(0.6))).Put("sy", ((V)(1.8))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
Invoke(Call(book_54, V.Undef, ((V)(5D)), ((V)(38.4)), ((V)(3D)), ((V)(12D)), ((V)(2D)), ((V)(9D)), ((V)("#7fb2c9")), ((V)(0.3))), "forEach", Fn((V _arrowThis1665, int _argc1658, V s_1664, V _a1661, V _a1662, V _a1663, V[] _rest1659) => {
return Invoke(o_1657, "push", s_1664);
}, 1, "", true));
return o_1657;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_21, "tambour22", Fn((V _arrowThis1673, int _argc1666, V S_1672, V _a1669, V _a1670, V _a1671, V[] _rest1667) => {
V OK_1674 = default;
V OL_1675 = default;
V OD_1676 = default;
double W_1677 = 0;
double Dp_1678 = 0;
double BY_1679 = 0;
double BH_1680 = 0;
OK_1674 = ((V)("#cd9a60"));
OL_1675 = Call(shade_18, V.Undef, OK_1674, ((V)(1.12)));
OD_1676 = Call(shade_18, V.Undef, OK_1674, ((V)(0.7)));
W_1677 = 40D;
Dp_1678 = 36D;
BY_1679 = 6D;
BH_1680 = 36D;
return NewObj(5).Put("w", ((V)((W_1677 + 6D)))).Put("d", ((V)((Dp_1678 + 6D)))).Put("topH", ((V)(((BY_1679 + BH_1680) + 2.4)))).Put("topW", ((V)(24D))).Put("build", Fn((V _arrowThis1687, int _argc1681, V _a1683, V _a1684, V _a1685, V _a1686, V[] _rest1682) => {
V o_1688 = default;
V on_1689 = default;
V BD_1690 = default;
V IN_1691 = default;
double TY_1692 = 0;
o_1688 = Arr();
on_1689 = Call(glue_48, V.Undef, o_1688);
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis1704, int _argc1693, V _a1695, V _a1696, V _a1697, V _a1698, V[] _rest1694) => {
V sx_1701 = default;
V sz_1703 = default;
{ V _t1699 = ListOf(_a1695);
{ V _t1700 = GetIdx(_t1699, 0D);
sx_1701 = _t1700; }
{ V _t1702 = GetIdx(_t1699, 1D);
sz_1703 = _t1702; }
}
return Invoke(o_1688, "push", Call(cyl_12, V.Undef, ((V)((ToNum(sx_1701) * ((W_1677 / 2D) - 4D)))), ((V)(0D)), ((V)((ToNum(sz_1703) * ((Dp_1678 / 2D) - 4D)))), ((V)(2D)), ((V)(BY_1679)), OD_1676, Call(W__37, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(BY_1679)), ((V)(0D)), ((V)(1D))))).V)));
}, 1, "", true));
BD_1690 = Call(box_11, V.Undef, ((V)(0D)), ((V)(BY_1679)), ((V)(0D)), ((V)(W_1677)), ((V)(BH_1680)), ((V)(Dp_1678)), OK_1674, Call(W__37, V.Undef, NewObj(1).Put("r", ((V)(2D))).V));
Invoke(o_1688, "push", BD_1690);
Invoke(o_1688, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((BY_1679 + BH_1680))), ((V)(0D)), ((V)((W_1677 + 2D))), ((V)(2.4)), ((V)((Dp_1678 + 2D))), OL_1675, Call(W__37, V.Undef, NewObj(1).Put("r", ((V)(1.6))).V)));
IN_1691 = GetIdx(Call(on_1689, V.Undef, BD_1690, Arr(Call(box_11, V.Undef, ((V)((-10D))), ((V)((BY_1679 + 3D))), ((V)(((Dp_1678 / 2D) + 0.05))), ((V)(16D)), ((V)((BH_1680 - 6D))), ((V)(0.3)), ((V)("#2a1a10")), NewObj(2).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_1689, V.Undef, IN_1691, Invoke(Arr(Arr(((V)("#3f7fc8")), ((V)(2.2))), Arr(((V)("#e0b04c")), ((V)(2.6))), Arr(((V)("#c4643a")), ((V)(2D))), Arr(((V)("#4f9a4a")), ((V)(2.4)))), "map", Fn((V _arrowThis1717, int _argc1705, V _a1707, V i_1711, V _a1709, V _a1710, V[] _rest1706) => {
V col_1714 = default;
V w_1716 = default;
{ V _t1712 = ListOf(_a1707);
{ V _t1713 = GetIdx(_t1712, 0D);
col_1714 = _t1713; }
{ V _t1715 = GetIdx(_t1712, 1D);
w_1716 = _t1715; }
}
return Call(box_11, V.Undef, ((V)(((-15.5) + (ToNum(i_1711) * 3D)))), ((V)((BY_1679 + 4D))), ((V)(((Dp_1678 / 2D) + 0.5))), w_1716, ((V)((12D - ((ToNum(i_1711) % 2D) * 1.6)))), ((V)(0.6)), col_1714, NewObj(1).Put("r", ((V)(0.3))).V);
}, 2, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1689, V.Undef, BD_1690, Call(rep_43, V.Undef, ((V)(10D)), Fn((V _arrowThis1725, int _argc1718, V i_1724, V _a1721, V _a1722, V _a1723, V[] _rest1719) => {
return Call(cyl_12, V.Undef, ((V)(((-0.6) + (ToNum(i_1724) * 2.3)))), ((V)((BY_1679 + 3D))), ((V)(((Dp_1678 / 2D) + 0.05))), ((V)(1.15)), ((V)((BH_1680 - 6D))), (NumTruthy((ToNum(i_1724) % 2D)) ? OL_1675 : OK_1674), Call(W__37, V.Undef, NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1689, V.Undef, BD_1690, Arr(Call(ball_13, V.Undef, ((V)(0.6)), ((V)((BY_1679 + (BH_1680 / 2D)))), ((V)(((Dp_1678 / 2D) + 1.4))), ((V)(1.1)), BR_25, Call(M__38, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
TY_1692 = ((BY_1679 + BH_1680) + 2.4);
Invoke(o_1688, "push", Call(cyl_12, V.Undef, ((V)(5D)), ((V)(TY_1692)), ((V)((-3D))), ((V)(3D)), ((V)(8D)), ((V)("#e8f6ff")), NewObj(4).Put("n", ((V)(14D))).Put("op", ((V)(0.5))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.86))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_12, V.Undef, ((V)(5D)), ((V)((TY_1692 + 0.4))), ((V)((-3D))), ((V)(2.6)), ((V)(5.6)), ((V)("#bfe6ff")), NewObj(2).Put("n", ((V)(14D))).Put("op", ((V)(0.5))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1733, int _argc1726, V s_1732, V _a1729, V _a1730, V _a1731, V[] _rest1727) => {
return Invoke(o_1688, "push", Call(arcW_16, V.Undef, ((V)(((-5D) + (ToNum(s_1732) * 2.6)))), ((V)((TY_1692 + 0.6))), ((V)(4D)), ((V)(2.2)), ((V)(1.4)), ((V)(0.5)), ((V)(0.6)), ((V)(0D)), ((V)((2D * PI_22))), ((V)("#2a2b30")), NewObj(1).Put("n", ((V)(12D))).V));
}, 1, "", true));
Invoke(o_1688, "push", Call(rod_30, V.Undef, Arr(((V)((-5D))), ((V)((TY_1692 + 0.9))), ((V)(4D))), Arr(((V)((-4.6))), ((V)((TY_1692 + 0.9))), ((V)(4D))), ((V)(0.3)), ((V)("#2a2b30")), NewObj(1).Put("n", ((V)(4D))).V));
return o_1688;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_21, "marq22", Fn((V _arrowThis1741, int _argc1734, V S_1740, V _a1737, V _a1738, V _a1739, V[] _rest1735) => {
V NM_1742 = default;
V VN_1743 = default;
double W_1744 = 0;
double H_1745 = 0;
NM_1742 = ((V)("#1e1e22"));
VN_1743 = ((V)("#f2efe8"));
W_1744 = 34D;
H_1745 = 40D;
return NewObj(6).Put("w", ((V)((W_1744 + 4D)))).Put("d", ((V)((W_1744 + 4D)))).Put("topH", ((V)(H_1745))).Put("topW", ((V)(20D))).Put("build", Fn((V _arrowThis1752, int _argc1746, V _a1748, V _a1749, V _a1750, V _a1751, V[] _rest1747) => {
V o_1753 = default;
V on_1754 = default;
V P_1755 = default;
double h_1756 = 0;
V vein_1757 = default;
o_1753 = Arr();
on_1754 = Call(glue_48, V.Undef, o_1753);
P_1755 = Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(W_1744)), ((V)(H_1745)), ((V)(W_1744)), NM_1742, NewObj(2).Put("r", ((V)(1.2))).Put("shine", ((V)(1D))).V);
Invoke(o_1753, "push", P_1755);
h_1756 = ((W_1744 / 2D) + 0.05);
vein_1757 = Fn((V _arrowThis1767, int _argc1758, V L_1764, V fn_1765, V r_1766, V _a1763, V[] _rest1759) => {
return Call(on_1754, V.Undef, P_1755, Call(pipe_31, V.Undef, L_1764, (r_1766 is var _t1768 && Truthy(_t1768) ? _t1768 : ((V)(0.3))), VN_1743, NewObj(3).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.85))).V), fn_1765);
}, 3, "", true);
Call(vein_1757, V.Undef, Arr(Arr(((V)((-h_1756))), ((V)(34D)), ((V)(h_1756))), Arr(((V)((-6D))), ((V)(26D)), ((V)(h_1756))), Arr(((V)(2D)), ((V)(27.4)), ((V)(h_1756))), Arr(((V)(h_1756)), ((V)(12D)), ((V)(h_1756)))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(vein_1757, V.Undef, Arr(Arr(((V)((-8D))), ((V)(26.4)), ((V)(h_1756))), Arr(((V)((-10D))), ((V)(14D)), ((V)(h_1756))), Arr(((V)((-4D))), ((V)(4D)), ((V)(h_1756)))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(0.16)));
Call(vein_1757, V.Undef, Arr(Arr(((V)(h_1756)), ((V)(12D)), ((V)(h_1756))), Arr(((V)(h_1756)), ((V)(20D)), ((V)(4D))), Arr(((V)(h_1756)), ((V)(26D)), ((V)((-6D)))), Arr(((V)(h_1756)), ((V)(40D)), ((V)((-h_1756))))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))));
Call(vein_1757, V.Undef, Arr(Arr(((V)(h_1756)), ((V)(22D)), ((V)(0D))), Arr(((V)(h_1756)), ((V)(8D)), ((V)((-8D))))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(0.16)));
Call(vein_1757, V.Undef, Arr(Arr(((V)((-h_1756))), ((V)((H_1745 + 0.05))), ((V)((-4D)))), Arr(((V)((-6D))), ((V)((H_1745 + 0.05))), ((V)(2D))), Arr(((V)(4D)), ((V)((H_1745 + 0.05))), ((V)(0D))), Arr(((V)(h_1756)), ((V)((H_1745 + 0.05))), ((V)(h_1756)))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Invoke(o_1753, "push", Call(cyl_12, V.Undef, ((V)(3D)), ((V)(H_1745)), ((V)(2D)), ((V)(6D)), ((V)(1D)), BR_25, Call(M__38, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_12, V.Undef, ((V)(3D)), ((V)((H_1745 + 1D))), ((V)(2D)), ((V)(3.2)), ((V)(12D)), ((V)("#fbf6ea")), NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).V), Call(rod_30, V.Undef, Arr(((V)(3D)), ((V)((H_1745 + 13D))), ((V)(2D))), Arr(((V)(3D)), ((V)((H_1745 + 14.2))), ((V)(2D))), ((V)(0.2)), ((V)("#2a2020")), NewObj(1).Put("n", ((V)(4D))).V));
return o_1753;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1776, int _argc1769, V c_1775, V _a1772, V _a1773, V _a1774, V[] _rest1770) => {
V q_1777 = default;
V k_1778 = default;
q_1777 = Invoke(c_1775, "p", ((V)(3D)), ((V)((H_1745 + 16.6))), ((V)(2D)));
k_1778 = Get(c_1775, "k");
return NewObj(2).Put("defs", Call(RG_51, V.Undef, ((V)("q22cf")), ((V)("#fff3b0")), ((V)("#ffb347")), ((V)(0.8)))).Put("front", ((V)(JsStrBuf.Begin().V(Call(ell_52, V.Undef, c_1775, q_1777, ((V)((9D * ToNum(k_1778)))), ((V)((9D * ToNum(k_1778)))), ((V)("url(#q22cf)")), Call(an_35, V.Undef, ((V)("opacity")), ((V)("0.4;0.75;0.5;0.8;0.4")), ((V)(1.6))), ((V)(0.6)))).S("<path d=\"M").V(Call(f1_20, V.Undef, GetIdx(q_1777, 0D))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_1777, 1D)) - (2.6 * ToNum(k_1778))))))).S("q").V(Call(f1_20, V.Undef, ((V)((1.6 * ToNum(k_1778)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((2.2 * ToNum(k_1778)))))).S(" 0 ").V(Call(f1_20, V.Undef, ((V)((3.6 * ToNum(k_1778)))))).S("q").V(Call(f1_20, V.Undef, ((V)(((-1.6) * ToNum(k_1778)))))).S(" ").V(Call(f1_20, V.Undef, ((V)(((-1.4) * ToNum(k_1778)))))).S(" 0 ").V(Call(f1_20, V.Undef, ((V)(((-3.6) * ToNum(k_1778)))))).S("Z\" fill=\"#ffcf4a\" stroke=\"#ff8a2a\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.25 * ToNum(k_1778)))))).S("\">").S("<animateTransform attributeName=\"transform\" type=\"skewX\" values=\"0;6;-4;3;0\" dur=\"1.4s\" repeatCount=\"indefinite\" additive=\"sum\"/></path>").End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_21, "lev22", Fn((V _arrowThis1786, int _argc1779, V S_1785, V _a1782, V _a1783, V _a1784, V[] _rest1780) => {
V WH_1787 = default;
V CY_1788 = default;
double TY_1789 = 0;
WH_1787 = ((V)("#f2f4f8"));
CY_1788 = ((V)("#7fe8ff"));
TY_1789 = 26D;
return NewObj(10).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).Put("topH", ((V)((TY_1789 + 3D)))).Put("topW", ((V)(22D))).Put("glow", Fn((V _arrowThis1796, int _argc1790, V _a1792, V _a1793, V _a1794, V _a1795, V[] _rest1791) => {
return NewObj(3).Put("y", ((V)(14D))).Put("r", ((V)(46D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("pad", Arr(((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(0D)))).Put("layers", Arr(NewObj(2).Put("anim", Call(bobA_34, V.Undef, ((V)(2.4)), ((V)(3.2)))).Put("build", Fn((V _arrowThis1803, int _argc1797, V _a1799, V _a1800, V _a1801, V _a1802, V[] _rest1798) => {
V o_1804 = default;
V on_1805 = default;
V T_1806 = default;
V PH_1807 = default;
o_1804 = Arr();
on_1805 = Call(glue_48, V.Undef, o_1804);
T_1806 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(TY_1789)), ((V)(0D)), ((V)(17D)), ((V)(3D)), WH_1787, Call(G__41, V.Undef, NewObj(2).Put("n", ((V)(30D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(1D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3D)), ((V)(0D)), ((V)(1D))))).V));
Invoke(o_1804, "push", T_1806);
Call(on_1805, V.Undef, T_1806, Arr(Call(band_50, V.Undef, ((V)(0D)), ((V)((TY_1789 + 0.4))), ((V)(0D)), ((V)(15.4)), ((V)(0.7)), CY_1788, Call(em_42, V.Undef, NewObj(1).Put("n", ((V)(28D))).V))));
Call(on_1805, V.Undef, T_1806, Arr(Call(cyl_12, V.Undef, ((V)(4D)), ((V)((TY_1789 + 3D))), ((V)(2D)), ((V)(6.4)), ((V)(0.5)), ((V)("#1c1f26")), NewObj(1).Put("n", ((V)(18D))).V), Call(arcW_16, V.Undef, ((V)(4D)), ((V)((TY_1789 + 3.5))), ((V)(2D)), ((V)(5.6)), ((V)(5.6)), ((V)(0.5)), ((V)(0.2)), ((V)(0D)), ((V)((2D * PI_22))), CY_1788, Call(em_42, V.Undef, NewObj(1).Put("n", ((V)(18D))).V))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
PH_1807 = Call(box_11, V.Undef, ((V)(4D)), ((V)((TY_1789 + 3.7))), ((V)(2D)), ((V)(5.4)), ((V)(0.8)), ((V)(10.4)), ((V)("#2a2d34")), NewObj(3).Put("r", ((V)(1.4))).Put("yaw", ((V)(0.3))).Put("shine", ((V)(1D))).V);
Invoke(o_1804, "push", PH_1807);
Call(on_1805, V.Undef, PH_1807, Arr(Call(box_11, V.Undef, ((V)(4D)), ((V)((TY_1789 + 4.52))), ((V)(2D)), ((V)(4.6)), ((V)(0.05)), ((V)(9.4)), ((V)("#3a6aa8")), Call(em_42, V.Undef, NewObj(3).Put("r", ((V)(1.1))).Put("yaw", ((V)(0.3))).Put("op", ((V)(0.9))).V))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
return o_1804;
return default;
}, 0, "build", true)).V)).Put("build", Fn((V _arrowThis1814, int _argc1808, V _a1810, V _a1811, V _a1812, V _a1813, V[] _rest1809) => {
V o_1815 = default;
V on_1816 = default;
V B_1817 = default;
o_1815 = Arr();
on_1816 = Call(glue_48, V.Undef, o_1815);
B_1817 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(13D)), ((V)(3.4)), ((V)("#23262d")), Call(G__41, V.Undef, NewObj(2).Put("n", ((V)(26D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3.4)), ((V)(0D)), ((V)(0.88))))).V));
Invoke(o_1815, "push", B_1817);
Call(on_1816, V.Undef, B_1817, Arr(Call(arcW_16, V.Undef, ((V)(0D)), ((V)(3.4)), ((V)(0D)), ((V)(9D)), ((V)(9D)), ((V)(1.2)), ((V)(0.3)), ((V)(0D)), ((V)((2D * PI_22))), CY_1788, Call(em_42, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(3.42)), ((V)(0D)), ((V)(3D)), ((V)(0.2)), CY_1788, Call(em_42, V.Undef, NewObj(1).Put("n", ((V)(12D))).V))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
return o_1815;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1825, int _argc1818, V c_1824, V _a1821, V _a1822, V _a1823, V[] _rest1819) => {
V a_1826 = default;
V b_1827 = default;
V k_1828 = default;
JsStrBuf f_1829 = null;
a_1826 = Invoke(c_1824, "p", ((V)(0D)), ((V)(4D)), ((V)(0D)));
b_1827 = Invoke(c_1824, "p", ((V)(0D)), ((V)((TY_1789 - 0.4))), ((V)(0D)));
k_1828 = Get(c_1824, "k");
f_1829 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(a_1826, 0D)) - (4D * ToNum(k_1828))))))).S(" ").V(Call(f1_20, V.Undef, GetIdx(a_1826, 1D))).S("L").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_1827, 0D)) - (12D * ToNum(k_1828))))))).S(" ").V(Call(f1_20, V.Undef, GetIdx(b_1827, 1D))).S("H").V(Call(f1_20, V.Undef, Add(GetIdx(b_1827, 0D), ((V)((12D * ToNum(k_1828))))))).S("L").V(Call(f1_20, V.Undef, Add(GetIdx(a_1826, 0D), ((V)((4D * ToNum(k_1828))))))).S(" ").V(Call(f1_20, V.Undef, GetIdx(a_1826, 1D))).S("Z\" fill=\"url(#q22lb)\">").V(Call(an_35, V.Undef, ((V)("opacity")), ((V)("0.5;0.9;0.5")), ((V)(2.4)))).S("</path>").End());
Call(rep_43, V.Undef, ((V)(3D)), Fn((V _arrowThis1837, int _argc1830, V i_1836, V _a1833, V _a1834, V _a1835, V[] _rest1831) => {
V bg_1838 = default;
bg_1838 = Call(n4_45, V.Undef, ((V)(((-ToNum(i_1836)) * 0.8))));
f_1829.V(Invoke(Call(ell_52, V.Undef, c_1824, a_1826, ((V)((4D * ToNum(k_1828)))), ((V)(((4D * ToNum(k_1828)) * ToNum(Get(X_9, "SA"))))), ((V)("none")), Add(Add(Add(Call(an_35, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(a_1826, 1D))).S(";").V(Call(f1_20, V.Undef, GetIdx(b_1827, 1D))).End())), ((V)(2.4)), bg_1838), Call(an_35, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, ((V)((4D * ToNum(k_1828)))))).S(";").V(Call(f1_20, V.Undef, ((V)((13D * ToNum(k_1828)))))).End())), ((V)(2.4)), bg_1838)), Call(an_35, V.Undef, ((V)("ry")), ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, ((V)(((4D * ToNum(k_1828)) * ToNum(Get(X_9, "SA"))))))).S(";").V(Call(f1_20, V.Undef, ((V)(((13D * ToNum(k_1828)) * ToNum(Get(X_9, "SA"))))))).End())), ((V)(2.4)), bg_1838)), Call(an_35, V.Undef, ((V)("opacity")), ((V)("0;0.8;0")), ((V)(2.4)), bg_1838))), "replace", ((V)("fill=\"none\"")), ((V)(JsStrBuf.Begin().S("fill=\"none\" stroke=\"").V(CY_1788).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(k_1828)))))).S("\"").End()))));
return default;
}, 1, "", true));
return NewObj(2).Put("defs", ((V)(JsStrBuf.Begin().S("<linearGradient id=\"q22lb\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"").V(CY_1788).S("\" stop-opacity=\"0.45\"/><stop offset=\"1\" stop-color=\"").V(CY_1788).S("\" stop-opacity=\"0.05\"/></linearGradient>").End()))).Put("back", ((V)(f_1829.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(RD_8, "SET22", NewObj(20).Put("LIV-002", NewObj(3).Put("spec", ((V)("torch22"))).Put("live", ((V)("Flickers"))).Put("note", ((V)("A cheap grey torchiere with a slightly bent pole (held together with tape), a bendy gooseneck and an upturned plastic bowl shade with a crack. The bulb flickers now and then."))).V).Put("LIV-022", NewObj(2).Put("spec", ((V)("tripod22"))).Put("note", ((V)("Three oak legs meet at a brass hub under a glowing linen drum shade, with a little pull chain and the cord trailing off one leg."))).V).Put("LIV-042", NewObj(2).Put("spec", ((V)("arc22"))).Put("note", ((V)("A chrome arc that rises from a heavy white marble block and curves over the sofa, ending in a shiny dome shade that throws a pool of warm light below."))).V).Put("LIV-062", NewObj(3).Put("spec", ((V)("alab22"))).Put("live", ((V)("Glowing stones"))).Put("note", ((V)("A totem of six smooth alabaster stones stacked on bronze spacers. Light glows through the stones and slowly breathes from one to the next."))).V).Put("LIV-082", NewObj(3).Put("spec", ((V)("bio22"))).Put("live", ((V)("Living light"))).Put("note", ((V)("A glass column on a stone pot with a glowing vine spiralling up inside, little glowing mushrooms and moss. Spores drift up and a pulse of light climbs the vine."))).V).Put("LIV-003", NewObj(2).Put("spec", ((V)("trestle22"))).Put("note", ((V)("A rough plywood board on two wooden sawhorses, with layered ply edges, mug rings, a sticky note, a pile of mail, keys and a coffee mug."))).V).Put("LIV-023", NewObj(2).Put("spec", ((V)("iron22"))).Put("note", ((V)("A slim black iron frame with a glass top and a glass shelf: a brass key tray and a little succulent on top, a woven basket and books below."))).V).Put("LIV-043", NewObj(2).Put("spec", ((V)("rattan22"))).Put("note", ((V)("A teak credenza on tapered legs with two woven cane doors, three drawers with brass pulls, a vase of pampas and a stack of books on top."))).V).Put("LIV-063", NewObj(2).Put("spec", ((V)("burl22"))).Put("note", ((V)("A swirly burl-wood top with a brass edge on shiny brass legs and a little brass gallery rail at the back. A brass bowl of fruit, a stone orb sculpture and art books on top."))).V).Put("LIV-083", NewObj(3).Put("spec", ((V)("liquid22"))).Put("live", ((V)("Dripping"))).Put("note", ((V)("A mirror-chrome console that looks poured: its legs flow up like liquid metal into the top. A shine sweeps across it, ripples spread on the top and a drop drips down into a little puddle."))).V).Put("LIV-016", NewObj(2).Put("spec", ((V)("spool22"))).Put("note", ((V)("An old cable spool turned into a coffee table: a thick round plywood top with bolts and stencilled letters, black cable still wound round the drum, and a mug on a coaster."))).V).Put("LIV-036", NewObj(2).Put("spec", ((V)("hairpin22"))).Put("note", ((V)("A pine coffee table with a lower shelf on black hairpin legs. Magazines and a basket of yarn below, a terracotta plant and coasters on top."))).V).Put("LIV-056", NewObj(2).Put("spec", ((V)("live22"))).Put("note", ((V)("A thick walnut slab with its natural wavy edge and pale sapwood rim, a small crack held by two wooden bowties, on black steel frames. A wooden bowl of moss balls and a cup of coffee."))).V).Put("LIV-076", NewObj(2).Put("spec", ((V)("drum22"))).Put("note", ((V)("A big cream travertine drum with soft bands and little pores, nested with a smaller smoked-bronze drum with a brass rim. A book, a brass orb and a white bowl."))).V).Put("LIV-096", NewObj(3).Put("spec", ((V)("koi22"))).Put("live", ((V)("Koi swim"))).Put("note", ((V)("A low glass table that is a little pond: three koi swim round under the glass between lily pads and a lotus, the water shimmers and ripples spread across it."))).V).Put("LIV-019", NewObj(2).Put("spec", ((V)("crate22"))).Put("note", ((V)("A red plastic milk crate turned upside down, with a cup of instant noodles and a fork on top, a phone and its charger cable hanging over the side."))).V).Put("LIV-039", NewObj(2).Put("spec", ((V)("bistro22"))).Put("note", ((V)("A glossy white tulip table on one slim pedestal, with a bud vase holding a pink tulip and a little book."))).V).Put("LIV-059", NewObj(2).Put("spec", ((V)("tambour22"))).Put("note", ((V)("A small oak cabinet with a fluted tambour door slid half open to show books inside. A glass of water and reading glasses on top."))).V).Put("LIV-079", NewObj(3).Put("spec", ((V)("marq22"))).Put("live", ((V)("Candle"))).Put("note", ((V)("A solid block of glossy black Nero Marquina marble with white veins running over its faces, with a brass candle holder and a flickering candle."))).V).Put("LIV-099", NewObj(3).Put("spec", ((V)("lev22"))).Put("live", ((V)("Floating"))).Put("note", ((V)("A white round top floats over a glowing base and gently bobs. Rings of light rise between them and the phone on the top charges wirelessly."))).V).V);
edit21_58 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis1846, int _argc1839, V rows_1845, V _a1842, V _a1843, V _a1844, V[] _rest1840) => {
return Invoke(Call(edit21_58, V.Undef, rows_1845), "map", Fn((V _arrowThis1854, int _argc1847, V r_1853, V _a1850, V _a1851, V _a1852, V[] _rest1848) => {
return (Truthy(GetK(Get(RD_8, "SET22"), Get(r_1853, "id"))) ? Object_assign(NewObj(0).V, r_1853, GetK(Get(RD_8, "SET22"), Get(r_1853, "id"))) : r_1853);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H22", NewObj(11).Put("band", band_50).Put("prism", prism_49).Put("R0", R0_46).Put("glue", glue_48).Put("rp", rp_47).Put("RG", RG_51).Put("ell", ell_52).Put("TOP", TOP_53).Put("book", book_54).Put("mug", mug_55).Put("sprig", sprig_56).V);
Set(RD_8, "PLUS22", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
