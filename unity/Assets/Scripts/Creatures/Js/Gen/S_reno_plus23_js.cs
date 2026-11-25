// reno-plus23.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus23_js
    {

        public static void Run()
        {
Call(Named(boot_79 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
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
V cush_18 = default;
V pillowZ_19 = default;
V solid_20 = default;
V shade_21 = default;
V mix_22 = default;
V f1_23 = default;
V prismZ_24 = default;
V N_25 = default;
double PI_26 = 0;
V GOLD_27 = default;
V CH_28 = default;
V BR_29 = default;
V tilt_30 = default;
V tiltAll_31 = default;
V rotF_32 = default;
V rod_33 = default;
V pipe_34 = default;
V fxEll_35 = default;
V frame_36 = default;
V an_37 = default;
V FONT_38 = default;
V W__39 = default;
V M__40 = default;
V F__41 = default;
V PL_42 = default;
V G__43 = default;
V em_44 = default;
V rep_45 = default;
V band_46 = default;
V R0_47 = default;
V glue_48 = default;
V rp_49 = default;
V RG_50 = default;
V ell_51 = default;
V TOP_52 = default;
V book_53 = default;
V mug_54 = default;
V sprig_55 = default;
V gmug_56 = default;
V P2_57 = default;
V n4_58 = default;
V face_59 = default;
V fw_60 = default;
V qd_61 = default;
V fireIn_62 = default;
V slide_63 = default;
V AOD_64 = default;
V aoSvg_65 = default;
V backL_66 = default;
V sway_67 = default;
V BC_68 = default;
V deco_69 = default;
V spine_70 = default;
V bk_71 = default;
V edit22_72 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((((RD_8 is var _t73 && !Truthy(_t73) ? _t73 : Get(RD_8, "PLUS22")) is var _t74 && !Truthy(_t74) ? _t74 : Get(RD_8, "H22")) is var _t75 && !Truthy(_t75) ? _t75 : Get(RD_8, "H16")) is var _t76 && !Truthy(_t76) ? _t76 : Get(RD_8, "H")) is var _t77 && !Truthy(_t77) ? _t77 : X_9) is var _t78 && !Truthy(_t78) ? _t78 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_79.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS23"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t80 = K_10;
if (_t80.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t80));
{ V _t81 = Get(_t80, "box");
box_11 = _t81; }
{ V _t82 = Get(_t80, "cyl");
cyl_12 = _t82; }
{ V _t83 = Get(_t80, "ball");
ball_13 = _t83; }
{ V _t84 = Get(_t80, "slab");
slab_14 = _t84; }
{ V _t85 = Get(_t80, "slabX");
slabX_15 = _t85; }
{ V _t86 = Get(_t80, "arcW");
arcW_16 = _t86; }
{ V _t87 = Get(_t80, "disc");
disc_17 = _t87; }
{ V _t88 = Get(_t80, "cush");
cush_18 = _t88; }
{ V _t89 = Get(_t80, "pillowZ");
pillowZ_19 = _t89; }
{ V _t90 = Get(_t80, "solid");
solid_20 = _t90; }
{ V _t91 = Get(_t80, "shade");
shade_21 = _t91; }
{ V _t92 = Get(_t80, "mix");
mix_22 = _t92; }
{ V _t93 = Get(_t80, "f1");
f1_23 = _t93; } }
prismZ_24 = Get(K_10, "prismZ");
N_25 = Get(RD_8, "N");
PI_26 = System.Math.PI;
GOLD_27 = ((V)("#e2b14a"));
CH_28 = ((V)("#d5dde2"));
BR_29 = ((V)("#d4a548"));
{ V _t94 = Get(RD_8, "H16");
if (_t94.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t94));
{ V _t95 = Get(_t94, "tilt");
tilt_30 = _t95; }
{ V _t96 = Get(_t94, "tiltAll");
tiltAll_31 = _t96; }
{ V _t97 = Get(_t94, "rotF");
rotF_32 = _t97; }
{ V _t98 = Get(_t94, "rod");
rod_33 = _t98; }
{ V _t99 = Get(_t94, "pipe");
pipe_34 = _t99; }
{ V _t100 = Get(_t94, "fxEll");
fxEll_35 = _t100; }
{ V _t101 = Get(_t94, "frame");
frame_36 = _t101; }
{ V _t102 = Get(_t94, "an");
an_37 = _t102; }
{ V _t103 = Get(_t94, "FONT");
FONT_38 = _t103; }
{ V _t104 = Get(_t94, "W_");
W__39 = _t104; }
{ V _t105 = Get(_t94, "M_");
M__40 = _t105; }
{ V _t106 = Get(_t94, "F_");
F__41 = _t106; }
{ V _t107 = Get(_t94, "PL");
PL_42 = _t107; }
{ V _t108 = Get(_t94, "G_");
G__43 = _t108; }
{ V _t109 = Get(_t94, "em");
em_44 = _t109; }
{ V _t110 = Get(_t94, "rep");
rep_45 = _t110; } }
{ V _t111 = Get(RD_8, "H22");
if (_t111.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t111));
{ V _t112 = Get(_t111, "band");
band_46 = _t112; }
{ V _t113 = Get(_t111, "R0");
R0_47 = _t113; }
{ V _t114 = Get(_t111, "glue");
glue_48 = _t114; }
{ V _t115 = Get(_t111, "rp");
rp_49 = _t115; }
{ V _t116 = Get(_t111, "RG");
RG_50 = _t116; }
{ V _t117 = Get(_t111, "ell");
ell_51 = _t117; }
{ V _t118 = Get(_t111, "TOP");
TOP_52 = _t118; }
{ V _t119 = Get(_t111, "book");
book_53 = _t119; }
{ V _t120 = Get(_t111, "mug");
mug_54 = _t120; }
{ V _t121 = Get(_t111, "sprig");
sprig_55 = _t121; } }
gmug_56 = Fn((V _arrowThis133, int _argc122, V o_128, V x_129, V y_130, V z_131, V[] _rest123) => {
V i0_134 = default;
V B_135 = default;
V col_132 = default;
col_132 = (_argc122 > 4 ? _rest123[0] : V.Undef);
i0_134 = Get(o_128, "length");
Call(mug_54, V.Undef, o_128, x_129, y_130, z_131, col_132);
B_135 = GetK(o_128, i0_134);
{
V i_136 = default;
i_136 = Add(i0_134, ((V)(1D)));
while (true) {
if (!(Lt(i_136, Get(o_128, "length")))) break;
Set(GetK(o_128, i_136), "par", B_135);
PostInc(ref i_136, 1D);
}
}
return B_135;
return default;
}, 5, "", true);
P2_57 = Fn((V _arrowThis145, int _argc138, V q_144, V _a141, V _a142, V _a143, V[] _rest139) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(q_144, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_144, 1D))).End()));
}, 1, "", true);
n4_58 = Fn((V _arrowThis153, int _argc146, V v_152, V _a149, V _a150, V _a151, V[] _rest147) => {
return ((V)((Round((ToNum(v_152) * 10000D)) / 10000D)));
}, 1, "", true);
face_59 = Fn((V _arrowThis163, int _argc154, V c_160, V nx_161, V nz_162, V _a159, V[] _rest155) => {
return ((V)(((ToNum(GetIdx(Invoke(c_160, "p", nx_161, ((V)(0D)), nz_162), 1D)) - ToNum(GetIdx(Invoke(c_160, "p", ((V)(0D)), ((V)(0D)), ((V)(0D))), 1D))) / (ToNum(Get(c_160, "k")) * ToNum(Get(X_9, "SA"))))));
}, 3, "", true);
fw_60 = Fn((V _arrowThis173, int _argc164, V p_170, V nx_171, V nz_172, V _a169, V[] _rest165) => {
return ((V)((ToNum(GetIdx(Call(p_170, V.Undef, (nx_171.IsNullish ? ((V)(0D)) : nx_171), ((V)(0D)), (nz_172.IsNullish ? ((V)(1D)) : nz_172)), 1D)) - ToNum(GetIdx(Call(p_170, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D))), 1D)))));
}, 3, "", true);
qd_61 = Fn((V _arrowThis182, int _argc174, V c_180, V P_181, V _a178, V _a179, V[] _rest175) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(P_181, "map", Fn((V _arrowThis190, int _argc183, V q_189, V _a186, V _a187, V _a188, V[] _rest184) => {
return Call(P2_57, V.Undef, Invoke(c_180, "p", GetIdx(q_189, 0D), GetIdx(q_189, 1D), GetIdx(q_189, 2D)));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 2, "", true);
fireIn_62 = Fn((V _arrowThis201, int _argc191, V c_197, V id_198, V P_199, V L_200, V[] _rest192) => {
return NewObj(2).Put("defs", ((V)(JsStrBuf.Begin().S("<clipPath id=\"").V(id_198).S("\"><path d=\"").V(Call(qd_61, V.Undef, c_197, P_199)).S("\"/></clipPath>").End()))).Put("g", ((V)(JsStrBuf.Begin().S("<g clip-path=\"url(#").V(id_198).S(")\">").V(Get(Invoke(Get(RD_8, "H"), "fire", c_197, L_200), "over")).S("</g>").End()))).V;
}, 4, "", true);
slide_63 = Fn((V _arrowThis213, int _argc202, V p_208, V xs_209, V ys_210, V dur_211, V[] _rest203) => {
V o0_214 = default;
V ex_215 = default;
V ey_216 = default;
V T_217 = default;
V kt_212 = default;
kt_212 = (_argc202 > 4 ? _rest203[0] : V.Undef);
o0_214 = Call(p_208, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
ex_215 = Call(p_208, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D)));
ey_216 = Call(p_208, V.Undef, ((V)(0D)), ((V)(1D)), ((V)(0D)));
T_217 = Fn((V _arrowThis226, int _argc218, V dx_224, V dy_225, V _a222, V _a223, V[] _rest219) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((((ToNum(GetIdx(ex_215, 0D)) - ToNum(GetIdx(o0_214, 0D))) * ToNum(dx_224)) + ((ToNum(GetIdx(ey_216, 0D)) - ToNum(GetIdx(o0_214, 0D))) * ToNum(dy_225))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((((ToNum(GetIdx(ex_215, 1D)) - ToNum(GetIdx(o0_214, 1D))) * ToNum(dx_224)) + ((ToNum(GetIdx(ey_216, 1D)) - ToNum(GetIdx(o0_214, 1D))) * ToNum(dy_225))))))).End()));
}, 2, "", true);
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"translate\" values=\"").V(Invoke(Invoke(xs_209, "map", Fn((V _arrowThis235, int _argc227, V x_233, V i_234, V _a231, V _a232, V[] _rest228) => {
return Call(T_217, V.Undef, x_233, (Truthy(ys_210) ? GetK(ys_210, i_234) : ((V)(0D))));
}, 2, "", true)), "join", ((V)(";")))).S("\" keyTimes=\"").V(kt_212).S("\" dur=\"").V(dur_211).S("s\" calcMode=\"spline\" keySplines=\"").V(Invoke(Call(rep_45, V.Undef, ((V)((ToNum(Get(xs_209, "length")) - 1D))), Fn((V _arrowThis242, int _argc236, V _a238, V _a239, V _a240, V _a241, V[] _rest237) => {
return ((V)("0.45 0 0.55 1"));
}, 0, "", true)), "join", ((V)(";")))).S("\" repeatCount=\"indefinite\"/>").End()));
return default;
}, 5, "", true);
AOD_64 = ((V)("<defs><linearGradient id=\"q23aV\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#000\" stop-opacity=\"0.55\"/><stop offset=\"0.28\" stop-color=\"#000\" stop-opacity=\"0.16\"/><stop offset=\"0.8\" stop-color=\"#000\" stop-opacity=\"0.06\"/><stop offset=\"1\" stop-color=\"#000\" stop-opacity=\"0.26\"/></linearGradient><linearGradient id=\"q23aH\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#000\" stop-opacity=\"0.34\"/><stop offset=\"0.14\" stop-color=\"#000\" stop-opacity=\"0\"/><stop offset=\"0.86\" stop-color=\"#000\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000\" stop-opacity=\"0.34\"/></linearGradient></defs>"));
aoSvg_65 = Fn((V _arrowThis251, int _argc243, V p_249, V A_250, V _a247, V _a248, V[] _rest244) => {
V z_252 = default;
V L_253 = default;
if (!(Truthy(A_250))) {
return ((V)(""));
}
{ V _t254 = A_250;
{ V _t255 = ListOf(_t254);
{ V _t256 = GetIdx(_t255, 0D);
z_252 = _t256; }
{ V _t257 = GetIdx(_t255, 1D);
L_253 = _t257; }
} }
return ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(frame_36, V.Undef, p_249, Arr(((V)(0D)), ((V)(0D)), z_252), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))).S("\">").V(AOD_64).V(Invoke(Invoke(L_253, "map", Fn((V _arrowThis273, int _argc258, V _a260, V _a261, V _a262, V _a263, V[] _rest259) => {
V a_266 = default;
V b_268 = default;
V c_270 = default;
V d_272 = default;
{ V _t264 = ListOf(_a260);
{ V _t265 = GetIdx(_t264, 0D);
a_266 = _t265; }
{ V _t267 = GetIdx(_t264, 1D);
b_268 = _t267; }
{ V _t269 = GetIdx(_t264, 2D);
c_270 = _t269; }
{ V _t271 = GetIdx(_t264, 3D);
d_272 = _t271; }
}
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(a_266).S("\" y=\"").N((-ToNum(d_272))).S("\" width=\"").N((ToNum(b_268) - ToNum(a_266))).S("\" height=\"").N((ToNum(d_272) - ToNum(c_270))).S("\" fill=\"url(#q23aV)\"/><rect x=\"").V(a_266).S("\" y=\"").N((-ToNum(d_272))).S("\" width=\"").N((ToNum(b_268) - ToNum(a_266))).S("\" height=\"").N((ToNum(d_272) - ToNum(c_270))).S("\" fill=\"url(#q23aH)\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>").End()));
return default;
}, 2, "", true);
backL_66 = Fn((V _arrowThis282, int _argc274, V fn_280, V A_281, V _a278, V _a279, V[] _rest275) => {
return Arr(NewObj(3).Put("back", ((V)(1D))).Put("build", fn_280).Put("wrap", Fn((V _arrowThis291, int _argc283, V p_289, V s_290, V _a287, V _a288, V[] _rest284) => {
return (GeN(Call(fw_60, V.Undef, p_289), 0D) ? Add(s_290, Call(aoSvg_65, V.Undef, p_289, A_281)) : ((V)("")));
}, 2, "wrap", true)).V, NewObj(2).Put("build", fn_280).Put("wrap", Fn((V _arrowThis300, int _argc292, V p_298, V s_299, V _a296, V _a297, V[] _rest293) => {
return (LtN(Call(fw_60, V.Undef, p_298), 0D) ? s_299 : ((V)("")));
}, 2, "wrap", true)).V);
}, 2, "", true);
sway_67 = Fn((V _arrowThis310, int _argc301, V q_307, V a_308, V d_309, V _a306, V[] _rest302) => {
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"rotate\" values=\"").V(Invoke(Invoke(Arr(((V)(0D)), a_308, ((V)(0D)), ((V)(((-ToNum(a_308)) * 0.8))), ((V)(0D))), "map", Fn((V _arrowThis318, int _argc311, V v_317, V _a314, V _a315, V _a316, V[] _rest312) => {
return ((V)(JsStrBuf.Begin().V(v_317).S(" ").V(Call(P2_57, V.Undef, q_307)).End()));
}, 1, "", true)), "join", ((V)(";")))).S("\" dur=\"").V(d_309).S("s\" calcMode=\"spline\" keyTimes=\"0;0.25;0.5;0.75;1\" keySplines=\"0.45 0 0.55 1;0.45 0 0.55 1;0.45 0 0.55 1;0.45 0 0.55 1\" repeatCount=\"indefinite\"/>").End()));
}, 3, "", true);
BC_68 = Arr(((V)("#7f2030")), ((V)("#1f4f3e")), ((V)("#2b3f7a")), ((V)("#c99a2e")), ((V)("#5a2a5e")), ((V)("#e9dfcc")), ((V)("#3a2a22")), ((V)("#a8592b")), ((V)("#2c2d31")), ((V)("#6b8fb8")), ((V)("#9fb58c")), ((V)("#d9483b")), ((V)("#d8b4a0")), ((V)("#4a6a5a")));
deco_69 = Fn((V _arrowThis332, int _argc319, V o_325, V on_326, V R_327, V x_328, V[] _rest320) => {
double t_333 = 0;
V y_329 = default;
V z_330 = default;
V hm_331 = default;
y_329 = (_argc319 > 4 ? _rest320[0] : V.Undef);
z_330 = (_argc319 > 5 ? _rest320[1] : V.Undef);
hm_331 = (_argc319 > 6 ? _rest320[2] : V.Undef);
t_333 = System.Math.Floor((ToNum(Call(R_327, V.Undef)) * 5D));
if ((t_333 == 0D)) {
double r_334 = 0;
double h_335 = 0;
r_334 = 3.4;
h_335 = Min((ToNum(hm_331) * 0.7), 15D);
Invoke(o_325, "push", Call(cyl_12, V.Undef, Add(Add(x_328, ((V)(r_334))), ((V)(0.5))), y_329, z_330, ((V)(r_334)), ((V)(h_335)), GetIdx(Arr(((V)("#e9e4da")), ((V)("#3f6a8a")), ((V)("#c8693f")), ((V)("#2c2d31")), ((V)("#9fb58c"))), System.Math.Floor((ToNum(Call(R_327, V.Undef)) * 5D))), NewObj(3).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.66))), Arr(((V)((h_335 * 0.4))), ((V)(0D)), ((V)(1D))), Arr(((V)((h_335 * 0.82))), ((V)(0D)), ((V)(0.5))), Arr(((V)(h_335)), ((V)(0D)), ((V)(0.6))))).V));
return ((V)(((2D * r_334) + 1D)));
}
if ((t_333 == 1D)) {
Invoke(o_325, "push", Call(cyl_12, V.Undef, Add(x_328, ((V)(4.5))), y_329, z_330, ((V)(3.8)), ((V)(5D)), ((V)("#d86a4a")), NewObj(3).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.78))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))))).V));
Call(sprig_55, V.Undef, o_325, Add(x_328, ((V)(4.5))), Add(y_329, ((V)(5D))), z_330, R_327, V.Null, ((V)(6D)));
return ((V)(9D));
}
if ((t_333 == 2D)) {
double h_336 = 0;
V pv_337 = default;
V F_338 = default;
h_336 = Min((ToNum(hm_331) * 0.55), 12D);
pv_337 = Arr(Add(x_328, ((V)(5D))), y_329, ((V)((ToNum(z_330) - 2.4))));
F_338 = Call(tilt_30, V.Undef, Call(box_11, V.Undef, Add(x_328, ((V)(5D))), y_329, ((V)((ToNum(z_330) - 3D))), ((V)(10D)), ((V)(h_336)), ((V)(1.2)), ((V)("#2c2d31")), Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.08))), pv_337);
Invoke(o_325, "push", F_338);
Call(on_326, V.Undef, F_338, Arr(Call(tilt_30, V.Undef, Call(box_11, V.Undef, Add(x_328, ((V)(5D))), Add(y_329, ((V)(1.4))), ((V)((ToNum(z_330) - 2.35))), ((V)(7D)), ((V)((h_336 - 2.8))), ((V)(0.1)), GetIdx(Arr(((V)("#9fc4d9")), ((V)("#e8c9a0")), ((V)("#b9d6a8"))), System.Math.Floor((ToNum(Call(R_327, V.Undef)) * 3D))), NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.08))), pv_337)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return ((V)(10D));
}
if ((t_333 == 3D)) {
V G_339 = default;
G_339 = Call(ball_13, V.Undef, Add(x_328, ((V)(4.5))), Add(y_329, ((V)(7.4))), z_330, ((V)(4.4)), ((V)("#4f86b8")), NewObj(3).Put("k", ((V)(6D))).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).V);
Invoke(o_325, "push", Call(cyl_12, V.Undef, Add(x_328, ((V)(4.5))), y_329, z_330, ((V)(3D)), ((V)(1.2)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(rod_33, V.Undef, Arr(Add(x_328, ((V)(4.5))), Add(y_329, ((V)(1.2))), z_330), Arr(Add(x_328, ((V)(4.5))), Add(y_329, ((V)(3D))), z_330), ((V)(0.5)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), G_339);
Call(Call(glue_48, V.Undef, o_325), V.Undef, G_339, Invoke(Arr(Call(band_46, V.Undef, Add(x_328, ((V)(4.5))), Add(y_329, ((V)(7D))), z_330, ((V)(4.45)), ((V)(0.7)), GOLD_27, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(20D))).V))), "concat", Invoke(Arr(Arr(((V)((-1.6))), ((V)(1.4))), Arr(((V)(1.8)), ((V)((-0.6))))), "map", Fn((V _arrowThis351, int _argc340, V _a342, V _a343, V _a344, V _a345, V[] _rest341) => {
V dx_348 = default;
V dy_350 = default;
{ V _t346 = ListOf(_a342);
{ V _t347 = GetIdx(_t346, 0D);
dx_348 = _t347; }
{ V _t349 = GetIdx(_t346, 1D);
dy_350 = _t349; }
}
return Call(ball_13, V.Undef, Add(Add(x_328, ((V)(4.5))), dx_348), Add(Add(y_329, ((V)(7.4))), dy_350), Add(z_330, ((V)(3.6))), ((V)(1.7)), ((V)("#7fb25a")), NewObj(4).Put("sz", ((V)(0.35))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return ((V)(9D));
}
Invoke(o_325, "push", Call(box_11, V.Undef, Add(x_328, ((V)(3.5))), y_329, z_330, ((V)(7D)), ((V)(3D)), ((V)(7D)), ((V)("#2c2d31")), Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(ball_13, V.Undef, Add(x_328, ((V)(3.5))), Add(y_329, ((V)(6.4))), z_330, ((V)(3.4)), BR_29, Call(M__40, V.Undef, NewObj(3).Put("k", ((V)(5D))).Put("n", ((V)(12D))).Put("shine", ((V)(1D))).V)));
return ((V)(7D));
return default;
}, 7, "", true);
spine_70 = Fn((V _arrowThis367, int _argc352, V on_358, V B_359, V R_360, V cx_361, V[] _rest353) => {
double s_368 = 0;
V L_369 = default;
V y_362 = default;
V zf_363 = default;
V w_364 = default;
V h_365 = default;
V col_366 = default;
y_362 = (_argc352 > 4 ? _rest353[0] : V.Undef);
zf_363 = (_argc352 > 5 ? _rest353[1] : V.Undef);
w_364 = (_argc352 > 6 ? _rest353[2] : V.Undef);
h_365 = (_argc352 > 7 ? _rest353[3] : V.Undef);
col_366 = (_argc352 > 8 ? _rest353[4] : V.Undef);
s_368 = System.Math.Floor((ToNum(Call(R_360, V.Undef)) * 5D));
L_369 = Arr(Call(box_11, V.Undef, cx_361, ((V)((ToNum(Add(y_362, h_365)) - 0.55))), zf_363, ((V)((ToNum(w_364) - 0.1))), ((V)(0.55)), ((V)(0.1)), Call(shade_21, V.Undef, col_366, ((V)(0.68))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, cx_361, y_362, zf_363, ((V)((ToNum(w_364) - 0.1))), ((V)(0.45)), ((V)(0.1)), Call(shade_21, V.Undef, col_366, ((V)(0.72))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
if ((s_368 == 0D)) {
Invoke(L_369, "push", Call(box_11, V.Undef, cx_361, Add(y_362, ((V)((ToNum(h_365) * 0.8)))), zf_363, ((V)((ToNum(w_364) * 0.82))), ((V)(0.7)), ((V)(0.1)), GOLD_27, Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Call(box_11, V.Undef, cx_361, Add(y_362, ((V)((ToNum(h_365) * 0.14)))), zf_363, ((V)((ToNum(w_364) * 0.82))), ((V)(0.5)), ((V)(0.1)), GOLD_27, Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Call(box_11, V.Undef, cx_361, Add(y_362, ((V)((ToNum(h_365) * 0.5)))), zf_363, ((V)((ToNum(w_364) * 0.36))), ((V)((ToNum(h_365) * 0.16))), ((V)(0.1)), Call(shade_21, V.Undef, GOLD_27, ((V)(0.9))), Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
} else {
if ((s_368 == 1D)) {
V ly_370 = default;
ly_370 = Add(y_362, ((V)((ToNum(h_365) * 0.52))));
Invoke(L_369, "push", Call(box_11, V.Undef, cx_361, ly_370, zf_363, ((V)((ToNum(w_364) * 0.8))), ((V)((ToNum(h_365) * 0.22))), ((V)(0.1)), ((V)("#f2ead8")), NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, cx_361, Add(ly_370, ((V)((ToNum(h_365) * 0.15)))), zf_363, ((V)((ToNum(w_364) * 0.5))), ((V)(0.35)), ((V)(0.1)), ((V)("#3a2a22")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, cx_361, Add(ly_370, ((V)((ToNum(h_365) * 0.07)))), zf_363, ((V)((ToNum(w_364) * 0.6))), ((V)(0.35)), ((V)(0.1)), ((V)("#3a2a22")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
} else {
if ((s_368 == 2D)) {
Invoke(L_369, "push", Call(box_11, V.Undef, cx_361, Add(y_362, ((V)(0.45))), zf_363, ((V)((ToNum(w_364) - 0.1))), ((V)((ToNum(h_365) * 0.3))), ((V)(0.1)), GetIdx(Arr(((V)("#f2ead8")), ((V)("#2c2d31")), ((V)("#c99a2e")), ((V)("#7f2030"))), System.Math.Floor((ToNum(Call(R_360, V.Undef)) * 4D))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, cx_361, Add(y_362, ((V)((ToNum(h_365) * 0.66)))), zf_363, ((V)((ToNum(w_364) * 0.7))), ((V)((ToNum(h_365) * 0.06))), ((V)(0.1)), ((V)("#ffffff")), NewObj(3).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.7))).V));
} else {
if ((s_368 == 3D)) {
Call(rep_45, V.Undef, ((V)(3D)), Fn((V _arrowThis378, int _argc371, V i_377, V _a374, V _a375, V _a376, V[] _rest372) => {
return Invoke(L_369, "push", Call(box_11, V.Undef, cx_361, Add(y_362, ((V)((ToNum(h_365) * (0.74 + (ToNum(i_377) * 0.05)))))), zf_363, ((V)((ToNum(w_364) * 0.8))), ((V)(0.25)), ((V)(0.1)), GOLD_27, Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
} else {
Invoke(L_369, "push", Call(box_11, V.Undef, cx_361, Add(y_362, ((V)((ToNum(h_365) * 0.25)))), zf_363, ((V)((ToNum(w_364) * 0.8))), ((V)((ToNum(h_365) * 0.5))), ((V)(0.1)), Call(shade_21, V.Undef, col_366, ((V)(1.22))), NewObj(2).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, cx_361, Add(y_362, ((V)((ToNum(h_365) * 0.5)))), zf_363, ((V)((ToNum(w_364) * 0.5))), ((V)(0.4)), ((V)(0.1)), Call(shade_21, V.Undef, col_366, ((V)(0.6))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}
}
}
}
Call(on_358, V.Undef, B_359, L_369, Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 9, "", true);
bk_71 = Fn((V _arrowThis396, int _argc379, V o_385, V on_386, V R_387, V x0_388, V[] _rest380) => {
V x_397 = default;
V x1_389 = default;
V y_390 = default;
V zb_391 = default;
V dm_392 = default;
V hm_393 = default;
V dc_394 = default;
V sh_395 = default;
x1_389 = (_argc379 > 4 ? _rest380[0] : V.Undef);
y_390 = (_argc379 > 5 ? _rest380[1] : V.Undef);
zb_391 = (_argc379 > 6 ? _rest380[2] : V.Undef);
dm_392 = (_argc379 > 7 ? _rest380[3] : V.Undef);
hm_393 = (_argc379 > 8 ? _rest380[4] : V.Undef);
dc_394 = (_argc379 > 9 ? _rest380[5] : V.Undef);
sh_395 = (_argc379 > 10 ? _rest380[6] : V.Undef);
x_397 = Add(x0_388, ((V)(0.3)));
if (Truthy(sh_395)) {
Call(on_386, V.Undef, sh_395, Arr(Call(box_11, V.Undef, ((V)((ToNum(Add(x0_388, x1_389)) / 2D))), Add(y_390, ((V)(0.03))), Add(Add(zb_391, dm_392), ((V)(0.6))), ((V)(((ToNum(x1_389) - ToNum(x0_388)) - 1D))), ((V)(0.05)), ((V)(2.4)), ((V)("#000000")), NewObj(3).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.16))).V), Call(box_11, V.Undef, ((V)((ToNum(Add(x0_388, x1_389)) / 2D))), Add(y_390, ((V)(0.03))), Add(zb_391, ((V)(2D))), ((V)(((ToNum(x1_389) - ToNum(x0_388)) - 1D))), ((V)(0.05)), ((V)(4D)), ((V)("#000000")), NewObj(3).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.22))).V)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
}
while (LtN(x_397, (ToNum(x1_389) - 2.4))) {
V k_398 = default;
double room_399 = 0;
double w_400 = 0;
double h_401 = 0;
double d_402 = 0;
V B_403 = default;
k_398 = Call(R_387, V.Undef);
room_399 = ((ToNum(x1_389) - ToNum(x_397)) - 0.3);
if (Truthy(((dc_394 is var _t404 && !Truthy(_t404) ? _t404 : (LtN(k_398, 0.12) ? V.True : V.False)) is var _t405 && !Truthy(_t405) ? _t405 : ((room_399 > 11D) ? V.True : V.False)))) {
x_397 = Add(x_397, Add(Call(dc_394, V.Undef, o_385, on_386, R_387, x_397, y_390, Add(zb_391, ((V)((ToNum(dm_392) / 2D)))), hm_393), ((V)(0.8))));
continue;
}
if ((LtN(k_398, 0.24) && (room_399 > 13D))) {
double w_406 = 0;
V yy_407 = default;
w_406 = (10D + (ToNum(Call(R_387, V.Undef)) * 2.6));
yy_407 = y_390;
Call(rep_45, V.Undef, ((V)((2D + System.Math.Floor((ToNum(Call(R_387, V.Undef)) * 3D))))), Fn((V _arrowThis415, int _argc408, V j_414, V _a411, V _a412, V _a413, V[] _rest409) => {
double t_416 = 0;
double ww_417 = 0;
double dd_418 = 0;
double cx_419 = 0;
V B_420 = default;
t_416 = (1.8 + (ToNum(Call(R_387, V.Undef)) * 1.4));
ww_417 = (w_406 - (ToNum(j_414) * 0.9));
dd_418 = ((ToNum(dm_392) - 2D) - (ToNum(j_414) * 0.8));
cx_419 = (ToNum(Add(x_397, ((V)((w_406 / 2D))))) - (ToNum(j_414) * 0.2));
B_420 = Call(box_11, V.Undef, ((V)(cx_419)), yy_407, Add(zb_391, ((V)((ToNum(dm_392) / 2D)))), ((V)(ww_417)), ((V)(t_416)), ((V)(dd_418)), GetIdx(BC_68, System.Math.Floor((ToNum(Call(R_387, V.Undef)) * ToNum(Get(BC_68, "length"))))), NewObj(2).Put("r", ((V)(0.4))).Put("mat", ((V)("fab"))).V);
Invoke(o_385, "push", B_420);
Call(on_386, V.Undef, B_420, Arr(Call(box_11, V.Undef, ((V)(cx_419)), Add(yy_407, ((V)(0.3))), Add(Add(Add(zb_391, ((V)((ToNum(dm_392) / 2D)))), ((V)((dd_418 / 2D)))), ((V)(0.05))), ((V)((ww_417 - 1.2))), ((V)((t_416 - 0.6))), ((V)(0.1)), ((V)("#f2ead8")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(cx_419)), Add(yy_407, ((V)((t_416 * 0.45)))), Add(Add(Add(zb_391, ((V)((ToNum(dm_392) / 2D)))), ((V)((dd_418 / 2D)))), ((V)(0.07))), ((V)((ww_417 - 1.4))), ((V)(0.12)), ((V)(0.05)), ((V)("#d8ccb2")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
yy_407 = Add(yy_407, ((V)(t_416)));
return default;
}, 1, "", true));
x_397 = Add(x_397, ((V)((w_406 + 0.8))));
continue;
}
w_400 = (2.2 + (ToNum(Call(R_387, V.Undef)) * 2.6));
h_401 = (ToNum(hm_393) * (0.62 + (ToNum(Call(R_387, V.Undef)) * 0.34)));
d_402 = (ToNum(dm_392) - (ToNum(Call(R_387, V.Undef)) * 3D));
B_403 = Call(box_11, V.Undef, Add(x_397, ((V)((w_400 / 2D)))), y_390, Add(zb_391, ((V)((d_402 / 2D)))), ((V)(w_400)), ((V)(h_401)), ((V)(d_402)), GetIdx(BC_68, System.Math.Floor((ToNum(Call(R_387, V.Undef)) * ToNum(Get(BC_68, "length"))))), NewObj(2).Put("r", ((V)(0.4))).Put("mat", ((V)("fab"))).V);
Invoke(o_385, "push", B_403);
Call(spine_70, V.Undef, on_386, B_403, R_387, Add(x_397, ((V)((w_400 / 2D)))), y_390, Add(Add(zb_391, ((V)(d_402))), ((V)(0.05))), ((V)(w_400)), ((V)(h_401)), Get(B_403, "col"));
Call(on_386, V.Undef, B_403, Arr(Call(box_11, V.Undef, Add(x_397, ((V)((w_400 / 2D)))), Add(Add(y_390, ((V)(h_401))), ((V)(0.02))), ((V)((ToNum(Add(zb_391, ((V)((d_402 / 2D))))) - 0.3))), ((V)((w_400 - 0.5))), ((V)(0.06)), ((V)((d_402 - 1D))), ((V)("#efe4cc")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
x_397 = Add(x_397, ((V)((w_400 + 0.25))));
}
return default;
}, 11, "", true);
Set(N_25, "cube23", Fn((V _arrowThis428, int _argc421, V S_427, V _a424, V _a425, V _a426, V[] _rest422) => {
V PB_429 = default;
V CORE_430 = default;
V HB_431 = default;
double W_432 = 0;
double T_433 = 0;
double C_434 = 0;
double H_435 = 0;
double D_436 = 0;
V piv_437 = default;
V RL_438 = default;
PB_429 = ((V)("#ece6d8"));
CORE_430 = ((V)("#b99a6c"));
HB_431 = ((V)("#7a5a3c"));
W_432 = 40D;
T_433 = 1.8;
C_434 = 36D;
H_435 = ((3D * C_434) + (4D * T_433));
D_436 = 30D;
piv_437 = Arr(((V)(0D)), ((V)(0D)), ((V)(0D)));
RL_438 = Fn((V _arrowThis446, int _argc439, V v_445, V _a442, V _a443, V _a444, V[] _rest440) => {
return v_445;
}, 1, "", true);
return NewObj(7).Put("w", ((V)((W_432 + 10D)))).Put("d", ((V)((D_436 + 6D)))).Put("topH", ((V)(H_435))).Put("topW", ((V)(24D))).Put("build", Fn((V _arrowThis453, int _argc447, V _a449, V _a450, V _a451, V _a452, V[] _rest448) => {
V o_454 = default;
V on_455 = default;
V R_456 = default;
V SL_457 = default;
V SR_458 = default;
V SH_459 = default;
V BIN_460 = default;
double y1_461 = 0;
V LB_462 = default;
double y2_463 = 0;
V JAR_464 = default;
V MG_465 = default;
o_454 = Arr();
on_455 = Call(glue_48, V.Undef, o_454);
R_456 = Call(R0_47, V.Undef, ((V)("cube")));
SL_457 = Call(box_11, V.Undef, ((V)((-((W_432 / 2D) - (T_433 / 2D))))), ((V)(0D)), ((V)(0.3)), ((V)(T_433)), ((V)(H_435)), ((V)((D_436 - 0.6))), PB_429, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V));
SR_458 = Call(box_11, V.Undef, ((V)(((W_432 / 2D) - (T_433 / 2D)))), ((V)(0D)), ((V)(0.3)), ((V)(T_433)), ((V)(H_435)), ((V)((D_436 - 0.6))), PB_429, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V));
Invoke(o_454, "push", SL_457, SR_458);
Invoke(Arr(SL_457, SR_458), "forEach", Fn((V _arrowThis474, int _argc466, V P_472, V i_473, V _a470, V _a471, V[] _rest467) => {
return Call(on_455, V.Undef, P_472, Arr(Call(box_11, V.Undef, ((V)(((Truthy(i_473) ? 1D : (-1D)) * ((W_432 / 2D) - (T_433 / 2D))))), ((V)(0D)), ((V)(0.3)), ((V)((T_433 + 0.12))), ((V)(4.4)), ((V)((D_436 - 0.48))), ((V)("#d9ccb0")), Call(PL_42, V.Undef, NewObj(2).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).V))));
}, 2, "", true));
SH_459 = Call(rep_45, V.Undef, ((V)(4D)), Fn((V _arrowThis482, int _argc475, V i_481, V _a478, V _a479, V _a480, V[] _rest476) => {
return Call(box_11, V.Undef, ((V)(0D)), ((V)((ToNum(i_481) * (C_434 + T_433)))), ((V)(0.4)), ((V)((W_432 - (2D * T_433)))), ((V)(T_433)), ((V)((D_436 - 0.8))), PB_429, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V));
}, 1, "", true));
Invoke(SH_459, "forEach", Fn((V _arrowThis490, int _argc483, V s_489, V _a486, V _a487, V _a488, V[] _rest484) => {
return Invoke(o_454, "push", s_489);
}, 1, "", true));
Call(on_455, V.Undef, GetIdx(SH_459, 1D), Arr(Call(box_11, V.Undef, ((V)((((W_432 / 2D) - T_433) - 2.6))), ((V)((C_434 + T_433))), ((V)(((D_436 / 2D) + 0.05))), ((V)(4.4)), ((V)(T_433)), ((V)(0.1)), CORE_430, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_455, V.Undef, GetIdx(SH_459, 1D), Call(pipe_34, V.Undef, Arr(Arr(((V)((((W_432 / 2D) - T_433) - 4.8))), ((V)((C_434 + (2D * T_433)))), ((V)(((D_436 / 2D) - 0.1)))), Arr(((V)((((W_432 / 2D) - T_433) - 6.4))), ((V)(((C_434 + (2D * T_433)) + 1.4))), ((V)(((D_436 / 2D) + 1.4)))), Arr(((V)((((W_432 / 2D) - T_433) - 7.2))), ((V)(((C_434 + (2D * T_433)) + 3.2))), ((V)(((D_436 / 2D) + 1D))))), ((V)(0.28)), ((V)("#f6f2ea")), Call(PL_42, V.Undef, NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V)));
Call(on_455, V.Undef, GetIdx(SH_459, 3D), Arr(Call(box_11, V.Undef, ((V)((((-W_432) / 2D) + 6D))), ((V)((H_435 + 0.02))), ((V)(6D)), ((V)(6D)), ((V)(0.06)), ((V)(4D)), CORE_430, NewObj(3).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.55))).V)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
BIN_460 = Call(box_11, V.Undef, ((V)(0D)), ((V)(T_433)), ((V)(1.6)), ((V)((C_434 - 2D))), ((V)((C_434 - 4D))), ((V)((D_436 - 6D))), ((V)("#8d9096")), Call(F__41, V.Undef, NewObj(1).Put("r", ((V)(2D))).V));
Invoke(o_454, "push", BIN_460);
Call(on_455, V.Undef, BIN_460, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(((T_433 + C_434) - 13D))), ((V)(13.65)), ((V)(10D)), ((V)(3.6)), ((V)(0.1)), ((V)("#3a3c40")), NewObj(2).Put("r", ((V)(1.6))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((-10D))), ((V)((T_433 + 6D))), ((V)(13.65)), ((V)(7D)), ((V)(4D)), ((V)(0.1)), ((V)("#f2efe6")), NewObj(2).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_455, V.Undef, BIN_460, Arr(Call(box_11, V.Undef, ((V)(9D)), ((V)(((T_433 + C_434) - 4D))), ((V)(7D)), ((V)(4.4)), ((V)(1.2)), ((V)(9D)), ((V)("#e86f5a")), Call(F__41, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_11, V.Undef, ((V)(9D)), ((V)(((T_433 + C_434) - 12.4))), ((V)(14.3)), ((V)(4.4)), ((V)(9.6)), ((V)(1.2)), ((V)("#e86f5a")), Call(F__41, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_11, V.Undef, ((V)(9D)), ((V)(((T_433 + C_434) - 9D))), ((V)(14.95)), ((V)(4.5)), ((V)(1.2)), ((V)(0.1)), ((V)("#f2efe6")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
y1_461 = (C_434 + (2D * T_433));
Call(bk_71, V.Undef, o_454, on_455, R_456, ((V)((((-W_432) / 2D) + T_433))), ((V)(10D)), ((V)(y1_461)), ((V)((((-D_436) / 2D) + 0.8))), ((V)(20D)), ((V)(26D)), V.Null, GetIdx(SH_459, 1D));
Invoke(Arr(SL_457, SR_458), "forEach", Fn((V _arrowThis499, int _argc491, V P_497, V i_498, V _a495, V _a496, V[] _rest492) => {
double xf_500 = 0;
xf_500 = ((Truthy(i_498) ? 1D : (-1D)) * ((W_432 / 2D) - T_433));
Call(on_455, V.Undef, P_497, Invoke(Arr(((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis508, int _argc501, V k_507, V _a504, V _a505, V _a506, V[] _rest502) => {
return Call(solid_20, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(10D)), ((V)(((ToNum(k_507) * (C_434 + T_433)) + (T_433 / 2D)))))).Put("a", ((V)(1.1))).Put("b", ((V)(1.1))).Put("n", ((V)(10D))).Put("rings", (Truthy(i_498) ? Arr(Arr(((V)((xf_500 - 0.12))), ((V)(0D))), Arr(((V)(xf_500)), ((V)(0D)))) : Arr(Arr(((V)(xf_500)), ((V)(0D))), Arr(((V)((xf_500 + 0.12))), ((V)(0D)))))).Put("col", ((V)("#c9ced3"))).Put("mat", ((V)("metal"))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)), Arr(((V)((Truthy(i_498) ? (-1D) : 1D))), ((V)(0D)), ((V)(0D))));
return default;
}, 2, "", true));
LB_462 = Call(box_11, V.Undef, ((V)(12.3)), ((V)(y1_461)), ((V)((-2D))), ((V)(2.6)), ((V)(24D)), ((V)(18D)), ((V)("#2b3f7a")), NewObj(2).Put("r", ((V)(0.4))).Put("mat", ((V)("fab"))).V);
Call(tilt_30, V.Undef, LB_462, Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)((-0.18))), Arr(((V)(13.6)), ((V)(y1_461)), ((V)((-2D)))));
Invoke(o_454, "push", LB_462);
y2_463 = ((2D * (C_434 + T_433)) + T_433);
Invoke(Arr(Arr(((V)("#d9483b")), ((V)(24D)), ((V)(4.2))), Arr(((V)("#3f7fc8")), ((V)(22.6)), ((V)(3.4))), Arr(((V)("#f2c14a")), ((V)(21D)), ((V)(3D)))), "reduce", Fn((V _arrowThis524, int _argc509, V yy_515, V _a512, V i_516, V _a514, V[] _rest510) => {
V G_525 = default;
V col_519 = default;
V w_521 = default;
V h_523 = default;
{ V _t517 = ListOf(_a512);
{ V _t518 = GetIdx(_t517, 0D);
col_519 = _t518; }
{ V _t520 = GetIdx(_t517, 1D);
w_521 = _t520; }
{ V _t522 = GetIdx(_t517, 2D);
h_523 = _t522; }
}
G_525 = Call(box_11, V.Undef, ((V)(((-5D) + (ToNum(i_516) * 0.6)))), yy_515, ((V)((-1D))), w_521, h_523, ((V)((22D - ToNum(i_516)))), col_519, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V));
Invoke(o_454, "push", G_525);
Call(on_455, V.Undef, G_525, Arr(Call(box_11, V.Undef, ((V)(((-5D) + (ToNum(i_516) * 0.6)))), Add(yy_515, ((V)((ToNum(h_523) * 0.5)))), ((V)((((-1D) + ((22D - ToNum(i_516)) / 2D)) + 0.05))), ((V)((ToNum(w_521) - 3D))), ((V)((ToNum(h_523) * 0.36))), ((V)(0.1)), ((V)("#ffffff")), NewObj(3).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.8))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return Add(yy_515, h_523);
return default;
}, 3, "", true), ((V)(y2_463)));
JAR_464 = Call(cyl_12, V.Undef, ((V)(12D)), ((V)(y2_463)), ((V)((-2D))), ((V)(4D)), ((V)(11D)), ((V)("#dff2f8")), NewObj(4).Put("n", ((V)(14D))).Put("op", ((V)(0.42))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.92))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))), Arr(((V)(11D)), ((V)(0D)), ((V)(0.7))))).V);
Invoke(o_454, "push", JAR_464);
Call(on_455, V.Undef, JAR_464, Arr(Call(cyl_12, V.Undef, ((V)(12D)), ((V)((y2_463 + 0.2))), ((V)((-2D))), ((V)(3.6)), ((V)(4.6)), ((V)("#d4a548")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_12, V.Undef, ((V)(12D)), ((V)((y2_463 + 11D))), ((V)((-2D))), ((V)(3D)), ((V)(1.4)), ((V)("#6a6e74")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V))));
MG_465 = Call(gmug_56, V.Undef, o_454, ((V)((-9D))), ((V)(H_435)), ((V)(2D)), ((V)("#4f9a4a")));
Invoke(Arr(Arr(((V)("#e86f5a")), ((V)((-1.2))), ((V)(0.6))), Arr(((V)("#2b3f7a")), ((V)(0.8)), ((V)((-0.8)))), Arr(((V)("#f2c14a")), ((V)(0D)), ((V)(1D)))), "forEach", Fn((V _arrowThis539, int _argc526, V _a528, V _a529, V _a530, V _a531, V[] _rest527) => {
V col_534 = default;
V dx_536 = default;
V dz_538 = default;
{ V _t532 = ListOf(_a528);
{ V _t533 = GetIdx(_t532, 0D);
col_534 = _t533; }
{ V _t535 = GetIdx(_t532, 1D);
dx_536 = _t535; }
{ V _t537 = GetIdx(_t532, 2D);
dz_538 = _t537; }
}
return Call(Call(glue_48, V.Undef, o_454), V.Undef, MG_465, Arr(Call(rod_33, V.Undef, Arr(Add(((V)((-9D))), dx_536), ((V)((H_435 + 6.4))), Add(((V)(2D)), dz_538)), Arr(((V)(((-9D) + (ToNum(dx_536) * 1.6)))), ((V)((H_435 + 13D))), ((V)((2D + (ToNum(dz_538) * 1.6))))), ((V)(0.35)), col_534, Call(PL_42, V.Undef, NewObj(1).Put("n", ((V)(5D))).V))));
}, 1, "", true));
Invoke(o_454, "push", Call(ball_13, V.Undef, ((V)(8D)), ((V)((H_435 + 3.2))), ((V)(4D)), ((V)(4D)), ((V)("#ffd23a")), Call(PL_42, V.Undef, NewObj(4).Put("sx", ((V)(1.25))).Put("sy", ((V)(0.85))).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V)), Call(ball_13, V.Undef, ((V)(10.4)), ((V)((H_435 + 8D))), ((V)(4.4)), ((V)(2.6)), ((V)("#ffd23a")), Call(PL_42, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)), Call(ball_13, V.Undef, ((V)(13D)), ((V)((H_435 + 7.6))), ((V)(4.4)), ((V)(1.2)), ((V)("#ff8a2a")), Call(PL_42, V.Undef, NewObj(4).Put("sx", ((V)(1.3))).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
return o_454;
return default;
}, 0, "build", true)).Put("layers", Call(backL_66, V.Undef, Fn((V _arrowThis546, int _argc540, V _a542, V _a543, V _a544, V _a545, V[] _rest541) => {
return Arr(Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((((-D_436) / 2D) + 0.3))), ((V)(W_432)), ((V)(H_435)), ((V)(0.6)), HB_431, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0D))).V)));
}, 0, "", true), Arr(((V)((((-D_436) / 2D) + 0.62))), Call(rep_45, V.Undef, ((V)(3D)), Fn((V _arrowThis554, int _argc547, V i_553, V _a550, V _a551, V _a552, V[] _rest548) => {
return Arr(((V)((((-W_432) / 2D) + T_433))), ((V)(((W_432 / 2D) - T_433))), ((V)(((ToNum(i_553) * (C_434 + T_433)) + T_433))), ((V)((ToNum(Add(i_553, ((V)(1D)))) * (C_434 + T_433)))));
}, 1, "", true))))).Put("fx", Fn((V _arrowThis562, int _argc555, V c_561, V _a558, V _a559, V _a560, V[] _rest556) => {
V O_563 = default;
V M_564 = default;
if (LtN(Call(face_59, V.Undef, c_561, ((V)(1D)), ((V)(0D))), 0.12)) {
return NewObj(0).V;
}
O_563 = Call(rp_49, V.Undef, RL_438, piv_437, Arr(((V)(((W_432 / 2D) + 0.08))), ((V)(80D)), ((V)(9D))));
M_564 = Call(frame_36, V.Undef, Get(c_561, "p"), O_563, Call(RL_438, V.Undef, Arr(((V)(0D)), ((V)(0D)), ((V)((-1D))))), Call(RL_438, V.Undef, Arr(((V)(0D)), ((V)((-1D))), ((V)(0D)))));
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(M_564).S("\"><g><animateTransform attributeName=\"transform\" type=\"rotate\" values=\"0 3.5 0;5 3.5 0;-2 3.5 0;3 3.5 0;0 3.5 0\" dur=\"4.6s\" repeatCount=\"indefinite\"/><rect x=\"0\" y=\"0\" width=\"7\" height=\"7\" fill=\"#ffe66b\" stroke=\"#e0c24a\" stroke-width=\"0.2\"/><path d=\"M1.2 2.4H5.6M1.2 3.8H5M1.2 5.2H4.2\" stroke=\"#7a6a3a\" stroke-width=\"0.35\" stroke-linecap=\"round\"/></g></g>").End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_25, "pipe23", Fn((V _arrowThis572, int _argc565, V S_571, V _a568, V _a569, V _a570, V[] _rest566) => {
V PN_573 = default;
V IR_574 = default;
double W_575 = 0;
double D_576 = 0;
double TH_577 = 0;
V YS_578 = default;
double PX_579 = 0;
double PZ_580 = 0;
V H_581 = default;
V CN_582 = default;
PN_573 = ((V)("#dca96c"));
IR_574 = ((V)("#2b2c30"));
W_575 = 96D;
D_576 = 30D;
TH_577 = 3.2;
YS_578 = Arr(((V)(7D)), ((V)(42D)), ((V)(77D)), ((V)(112D)), ((V)(147D)));
PX_579 = ((W_575 / 2D) - 6D);
PZ_580 = ((D_576 / 2D) - 5D);
H_581 = Add(GetIdx(YS_578, 4D), ((V)(TH_577)));
CN_582 = Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D))));
return NewObj(8).Put("w", ((V)((W_575 + 6D)))).Put("d", ((V)((D_576 + 8D)))).Put("topH", H_581).Put("topW", ((V)(60D))).Put("glow", Fn((V _arrowThis589, int _argc583, V _a585, V _a586, V _a587, V _a588, V[] _rest584) => {
return NewObj(2).Put("y", ((V)(120D))).Put("r", ((V)(60D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis596, int _argc590, V _a592, V _a593, V _a594, V _a595, V[] _rest591) => {
V o_597 = default;
V on_598 = default;
V R_599 = default;
V PK_600 = default;
V y0_601 = default;
V roll_602 = default;
V CF_603 = default;
V y1_604 = default;
V y2_605 = default;
V POT_606 = default;
V CK_607 = default;
V y3_608 = default;
V y4_609 = default;
V CAM_610 = default;
o_597 = Arr();
on_598 = Call(glue_48, V.Undef, o_597);
R_599 = Call(R0_47, V.Undef, ((V)("pipe")));
PK_600 = Invoke(YS_578, "map", Fn((V _arrowThis618, int _argc611, V y_617, V _a614, V _a615, V _a616, V[] _rest612) => {
return Call(box_11, V.Undef, ((V)(0D)), y_617, ((V)(0D)), ((V)(W_575)), ((V)(TH_577)), ((V)(D_576)), PN_573, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V));
}, 1, "", true));
Invoke(PK_600, "forEach", Fn((V _arrowThis626, int _argc619, V s_625, V _a622, V _a623, V _a624, V[] _rest620) => {
return Invoke(o_597, "push", s_625);
}, 1, "", true));
Invoke(PK_600, "forEach", Fn((V _arrowThis635, int _argc627, V P_633, V i_634, V _a631, V _a632, V[] _rest628) => {
V y_636 = default;
y_636 = GetK(YS_578, i_634);
Call(on_598, V.Undef, P_633, Call(rep_45, V.Undef, ((V)(3D)), Fn((V _arrowThis643, int _argc637, V _a639, V _a640, V _a641, V _a642, V[] _rest638) => {
return Call(cyl_12, V.Undef, ((V)(((ToNum(Call(R_599, V.Undef)) - 0.5) * (W_575 - 20D)))), Add(Add(y_636, ((V)(TH_577))), ((V)(0.02))), ((V)(((ToNum(Call(R_599, V.Undef)) - 0.5) * (D_576 - 10D)))), Add(((V)(1.1)), Call(R_599, V.Undef)), ((V)(0.05)), ((V)("#a06c3a")), NewObj(4).Put("n", ((V)(10D))).Put("rz", ((V)(0.7))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.7))).V);
}, 0, "", true)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Call(on_598, V.Undef, P_633, Invoke(Arr(((V)(0.9)), ((V)(2.2))), "map", Fn((V _arrowThis651, int _argc644, V t_650, V _a647, V _a648, V _a649, V[] _rest645) => {
return Call(slabX_15, V.Undef, ((V)(0D)), Add(y_636, t_650), ((V)(((D_576 / 2D) + 0.05))), ((V)((W_575 - 3D))), ((V)(0.22)), ((V)(0.1)), Call(shade_21, V.Undef, PN_573, ((V)(0.78))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_598, V.Undef, P_633, Invoke(Invoke(CN_582, "map", Fn((V _arrowThis683, int _argc672, V _a674, V _a675, V _a676, V _a677, V[] _rest673) => {
V sx_680 = default;
V sz_682 = default;
{ V _t678 = ListOf(_a674);
{ V _t679 = GetIdx(_t678, 0D);
sx_680 = _t679; }
{ V _t681 = GetIdx(_t678, 1D);
sz_682 = _t681; }
}
return Call(cyl_12, V.Undef, ((V)((ToNum(sx_680) * PX_579))), Add(y_636, ((V)(TH_577))), ((V)((ToNum(sz_682) * PZ_580))), ((V)(2.8)), ((V)(0.7)), IR_574, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V));
}, 1, "", true)), "concat", InvokeSpread(Arr(), "concat", new ArrBuilder().Spread(Invoke(CN_582, "map", Fn((V _arrowThis663, int _argc652, V _a654, V _a655, V _a656, V _a657, V[] _rest653) => {
V sx_660 = default;
V sz_662 = default;
{ V _t658 = ListOf(_a654);
{ V _t659 = GetIdx(_t658, 0D);
sx_660 = _t659; }
{ V _t661 = GetIdx(_t658, 1D);
sz_662 = _t661; }
}
return Call(rep_45, V.Undef, ((V)(4D)), Fn((V _arrowThis671, int _argc664, V q_670, V _a667, V _a668, V _a669, V[] _rest665) => {
return Call(ball_13, V.Undef, ((V)(((ToNum(sx_660) * PX_579) + (FdLibm.Cos((((ToNum(q_670) * PI_26) / 2D) + 0.78)) * 2.1)))), Add(Add(y_636, ((V)(TH_577))), ((V)(0.8))), ((V)(((ToNum(sz_662) * PZ_580) + (FdLibm.Sin((((ToNum(q_670) * PI_26) / 2D) + 0.78)) * 2.1)))), ((V)(0.42)), ((V)("#5a5c62")), Call(M__40, V.Undef, NewObj(4).Put("sy", ((V)(0.5))).Put("k", ((V)(2D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
}, 1, "", true))).V)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Call(on_598, V.Undef, P_633, Invoke(Arr(), "concat", Call(rep_45, V.Undef, ((V)(2D)), Fn((V _arrowThis691, int _argc684, V j_690, V _a687, V _a688, V _a689, V[] _rest685) => {
return Call(slabX_15, V.Undef, ((V)(0D)), Add(Add(y_636, ((V)(TH_577))), ((V)(0.02))), ((V)(((((-D_576) / 2D) + 3D) + (ToNum(j_690) * (D_576 - 6D))))), ((V)((W_575 - 2D))), ((V)(0.03)), ((V)(0.9)), Call(shade_21, V.Undef, PN_573, ((V)(0.85))), NewObj(3).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.6))).V);
}, 1, "", true))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Call(on_598, V.Undef, P_633, Invoke(CN_582, "map", Fn((V _arrowThis703, int _argc692, V _a694, V _a695, V _a696, V _a697, V[] _rest693) => {
V sx_700 = default;
V sz_702 = default;
{ V _t698 = ListOf(_a694);
{ V _t699 = GetIdx(_t698, 0D);
sx_700 = _t699; }
{ V _t701 = GetIdx(_t698, 1D);
sz_702 = _t701; }
}
return Call(cyl_12, V.Undef, ((V)((ToNum(sx_700) * PX_579))), ((V)((ToNum(y_636) - 0.7))), ((V)((ToNum(sz_702) * PZ_580))), ((V)(2.8)), ((V)(0.7)), IR_574, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V));
}, 1, "", true)));
return default;
}, 2, "", true));
Invoke(CN_582, "forEach", Fn((V _arrowThis715, int _argc704, V _a706, V _a707, V _a708, V _a709, V[] _rest705) => {
double x_716 = 0;
double z_717 = 0;
V sx_712 = default;
V sz_714 = default;
{ V _t710 = ListOf(_a706);
{ V _t711 = GetIdx(_t710, 0D);
sx_712 = _t711; }
{ V _t713 = GetIdx(_t710, 1D);
sz_714 = _t713; }
}
x_716 = (ToNum(sx_712) * PX_579);
z_717 = (ToNum(sz_714) * PZ_580);
Invoke(o_597, "push", Call(cyl_12, V.Undef, ((V)(x_716)), ((V)(0D)), ((V)(z_717)), ((V)(3.2)), ((V)(0.8)), IR_574, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_12, V.Undef, ((V)(x_716)), ((V)(0.8)), ((V)(z_717)), ((V)(1.5)), ((V)((ToNum(GetIdx(YS_578, 0D)) - 1.5))), IR_574, Call(M__40, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)));
{
double i_718 = 0;
i_718 = 0D;
while (true) {
if (!((i_718 < 4D))) break;
V a_720 = default;
double b_721 = 0;
V Pp_722 = default;
a_720 = Add(Add(GetIdx(YS_578, i_718), ((V)(TH_577))), ((V)(0.7)));
b_721 = (ToNum(GetIdx(YS_578, (i_718 + 1D))) - 0.7);
Pp_722 = Call(cyl_12, V.Undef, ((V)(x_716)), a_720, ((V)(z_717)), ((V)(1.5)), ((V)((b_721 - ToNum(a_720)))), IR_574, Call(M__40, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V));
Invoke(o_597, "push", Pp_722);
Call(on_598, V.Undef, Pp_722, Arr(Call(band_46, V.Undef, ((V)(x_716)), ((V)(((ToNum(Add(a_720, ((V)(b_721)))) / 2D) - 0.8))), ((V)(z_717)), ((V)(1.8)), ((V)(1.6)), ((V)("#3a3b40")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V))));
i_718++;
}
}
Call(on_598, V.Undef, GetIdx(PK_600, 4D), Arr(Call(cyl_12, V.Undef, ((V)(x_716)), Add(H_581, ((V)(0.7))), ((V)(z_717)), ((V)(1.9)), ((V)(2.4)), IR_574, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))));
return default;
}, 1, "", true));
y0_601 = Add(GetIdx(YS_578, 0D), ((V)(TH_577)));
roll_602 = Fn((V _arrowThis732, int _argc723, V cz_729, V cy_730, V col_731, V _a728, V[] _rest724) => {
V Rl_733 = default;
Rl_733 = Call(solid_20, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(cz_729, cy_730)).Put("a", ((V)(5.2))).Put("b", ((V)(5.2))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)((-38D))), ((V)(0D)), ((V)(0.9))), Arr(((V)((-37.2))), ((V)(0D)), ((V)(1D))), Arr(((V)((-8.8))), ((V)(0D)), ((V)(1D))), Arr(((V)((-8D))), ((V)(0D)), ((V)(0.9))))).Put("col", col_731).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V);
Invoke(o_597, "push", Rl_733);
Call(on_598, V.Undef, Rl_733, Invoke(Arr(((V)((-30D))), ((V)((-16D)))), "map", Fn((V _arrowThis741, int _argc734, V x_740, V _a737, V _a738, V _a739, V[] _rest735) => {
return Call(solid_20, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(cz_729, cy_730)).Put("a", ((V)(5.3))).Put("b", ((V)(5.3))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(x_740, ((V)(0D))), Arr(Add(x_740, ((V)(1.4))), ((V)(0D))))).Put("col", Call(shade_21, V.Undef, col_731, ((V)(0.72)))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)));
return default;
}, 3, "", true);
Call(roll_602, V.Undef, ((V)((-5.4))), Add(y0_601, ((V)(5.2))), ((V)("#d9a23a")));
Call(roll_602, V.Undef, ((V)(5.4)), Add(y0_601, ((V)(5.2))), ((V)("#8fae8a")));
Call(roll_602, V.Undef, ((V)(0D)), Add(y0_601, ((V)(14.25))), ((V)("#c4643a")));
CF_603 = Call(box_11, V.Undef, ((V)(20D)), y0_601, ((V)(0D)), ((V)(30D)), ((V)(11D)), ((V)(20D)), ((V)("#c49660")), Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V));
Invoke(o_597, "push", CF_603);
Call(on_598, V.Undef, CF_603, Arr(Call(box_11, V.Undef, ((V)(20D)), Add(y0_601, ((V)(6D))), ((V)(10.05)), ((V)(8D)), ((V)(2.2)), ((V)(0.1)), ((V)("#2a1a10")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V), Call(slabX_15, V.Undef, ((V)(20D)), Add(y0_601, ((V)(3D))), ((V)(10.05)), ((V)(29D)), ((V)(0.3)), ((V)(0.1)), ((V)("#9a7044")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_598, V.Undef, CF_603, Arr(Call(box_11, V.Undef, ((V)(20D)), Add(y0_601, ((V)(11.02))), ((V)(0D)), ((V)(27.6)), ((V)(0.05)), ((V)(17.6)), ((V)("#3a2616")), NewObj(2).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Call(on_598, V.Undef, CF_603, Call(rep_45, V.Undef, ((V)(10D)), Fn((V _arrowThis749, int _argc742, V i_748, V _a745, V _a746, V _a747, V[] _rest743) => {
return Call(box_11, V.Undef, ((V)((8D + (ToNum(i_748) * 2.5)))), Add(y0_601, ((V)(11.05))), ((V)(0D)), ((V)(1.4)), ((V)((SEqN(i_748, 6D) ? 7.6 : 5.8))), ((V)(16.6)), GetIdx(Arr(((V)("#e8402a")), ((V)("#2b3f7a")), ((V)("#f2c14a")), ((V)("#1d1e21")), ((V)("#e9dfcc")), ((V)("#4f9a4a"))), (ToNum(i_748) % 6D)), Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V));
}, 1, "", true)));
y1_604 = Add(GetIdx(YS_578, 1D), ((V)(TH_577)));
Call(bk_71, V.Undef, o_597, on_598, R_599, ((V)((-40D))), ((V)(27.6)), y1_604, ((V)((((-D_576) / 2D) + 1D))), ((V)(22D)), ((V)(28D)), deco_69, GetIdx(PK_600, 1D));
Invoke(o_597, "push", Call(box_11, V.Undef, ((V)(31D)), y1_604, ((V)((-2D))), ((V)(6D)), ((V)(0.8)), ((V)(12D)), IR_574, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V)), Call(box_11, V.Undef, ((V)(28.4)), Add(y1_604, ((V)(0.8))), ((V)((-2D))), ((V)(0.8)), ((V)(13D)), ((V)(12D)), IR_574, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V)));
y2_605 = Add(GetIdx(YS_578, 2D), ((V)(TH_577)));
POT_606 = Call(cyl_12, V.Undef, ((V)((-28D))), y2_605, ((V)(0D)), ((V)(6.5)), ((V)(9D)), ((V)("#a8a59e")), NewObj(3).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.84))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V);
Invoke(o_597, "push", POT_606);
Call(on_598, V.Undef, POT_606, Arr(Call(cyl_12, V.Undef, ((V)((-28D))), Add(y2_605, ((V)(9D))), ((V)(0D)), ((V)(5.8)), ((V)(0.2)), ((V)("#4a3426")), NewObj(2).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).V)));
Call(sprig_55, V.Undef, o_597, ((V)((-28D))), Add(y2_605, ((V)(9.2))), ((V)(0D)), R_599, V.Null, ((V)(10D)));
Invoke(Arr(Arr(((V)("#2b3f7a")), ((V)(22D)), ((V)(2.6))), Arr(((V)("#e9dfcc")), ((V)(20D)), ((V)(2.4))), Arr(((V)("#7f2030")), ((V)(18.6)), ((V)(2.2)))), "reduce", Fn((V _arrowThis764, int _argc750, V yy_756, V _a753, V _a754, V _a755, V[] _rest751) => {
V col_759 = default;
V w_761 = default;
V h_763 = default;
{ V _t757 = ListOf(_a753);
{ V _t758 = GetIdx(_t757, 0D);
col_759 = _t758; }
{ V _t760 = GetIdx(_t757, 1D);
w_761 = _t760; }
{ V _t762 = GetIdx(_t757, 2D);
h_763 = _t762; }
}
Invoke(Call(book_53, V.Undef, ((V)(22D)), yy_756, ((V)(0D)), w_761, h_763, ((V)(16D)), col_759, ((V)(0D))), "forEach", Fn((V _arrowThis772, int _argc765, V s_771, V _a768, V _a769, V _a770, V[] _rest766) => {
return Invoke(o_597, "push", s_771);
}, 1, "", true));
return Add(yy_756, h_763);
return default;
}, 2, "", true), y2_605);
CK_607 = Call(disc_17, V.Undef, ((V)(22D)), Add(y2_605, ((V)(12.4))), ((V)((-1D))), ((V)(5D)), ((V)(3.6)), ((V)("#c8402e")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(22D))).V));
Invoke(o_597, "push", CK_607);
Call(on_598, V.Undef, CK_607, Arr(Call(disc_17, V.Undef, ((V)(22D)), Add(y2_605, ((V)(12.4))), ((V)(2.6)), ((V)(4.2)), ((V)(0.1)), ((V)("#f6f0e2")), NewObj(2).Put("n", ((V)(20D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(o_597, "push", Call(ball_13, V.Undef, ((V)(18.6)), Add(y2_605, ((V)(18.2))), ((V)(0.8)), ((V)(1.9)), BR_29, Call(M__40, V.Undef, NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("sy", ((V)(0.7))).V)), Call(ball_13, V.Undef, ((V)(25.4)), Add(y2_605, ((V)(18.2))), ((V)(0.8)), ((V)(1.9)), BR_29, Call(M__40, V.Undef, NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("sy", ((V)(0.7))).V)), Call(rod_33, V.Undef, Arr(((V)(19D)), Add(y2_605, ((V)(7.2))), ((V)(0.8))), Arr(((V)(17.6)), ((V)((ToNum(Add(y2_605, ((V)(7.2)))) - 2.4))), ((V)(0.8))), ((V)(0.5)), ((V)("#2a2a2e")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)), Call(rod_33, V.Undef, Arr(((V)(25D)), Add(y2_605, ((V)(7.2))), ((V)(0.8))), Arr(((V)(26.4)), ((V)((ToNum(Add(y2_605, ((V)(7.2)))) - 2.4))), ((V)(0.8))), ((V)(0.5)), ((V)("#2a2a2e")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)));
y3_608 = Add(GetIdx(YS_578, 3D), ((V)(TH_577)));
Call(bk_71, V.Undef, o_597, on_598, R_599, ((V)((-40D))), ((V)(16D)), y3_608, ((V)((((-D_576) / 2D) + 1D))), ((V)(22D)), ((V)(27D)), V.Null, GetIdx(PK_600, 3D));
Invoke(o_597, "push", Call(rod_33, V.Undef, Arr(((V)(26D)), ((V)((ToNum(GetIdx(YS_578, 4D)) - 0.1))), ((V)(0D))), Arr(((V)(26D)), ((V)(128.4)), ((V)(0D))), ((V)(0.25)), ((V)("#1d1e21")), NewObj(1).Put("n", ((V)(4D))).V), Call(cyl_12, V.Undef, ((V)(26D)), ((V)(124.6)), ((V)(0D)), ((V)(1.4)), ((V)(3.8)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(ball_13, V.Undef, ((V)(26D)), ((V)(120.2)), ((V)(0D)), ((V)(3.6)), ((V)("#ffe8b0")), NewObj(5).Put("op", ((V)(0.55))).Put("sy", ((V)(1.22))).Put("k", ((V)(6D))).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).V));
Call(deco_69, V.Undef, o_597, on_598, Fn((V _arrowThis779, int _argc773, V _a775, V _a776, V _a777, V _a778, V[] _rest774) => {
return ((V)(0.5));
}, 0, "", true), ((V)(30.5)), y3_608, ((V)(0D)), ((V)(26D)));
y4_609 = H_581;
CAM_610 = Call(box_11, V.Undef, ((V)((-20D))), y4_609, ((V)(0D)), ((V)(14D)), ((V)(8D)), ((V)(7D)), ((V)("#2c2d31")), NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("lea"))).V);
Invoke(o_597, "push", CAM_610);
Call(on_598, V.Undef, CAM_610, Arr(Call(disc_17, V.Undef, ((V)((-20D))), Add(y4_609, ((V)(4D))), ((V)(3.5)), ((V)(3.1)), ((V)(2.6)), ((V)("#1a1a1c")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(slabX_15, V.Undef, ((V)((-20D))), Add(y4_609, ((V)(5.6))), ((V)(3.55)), ((V)(13D)), ((V)(2.2)), ((V)(0.1)), ((V)("#c9ced3")), Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_598, V.Undef, CAM_610, Arr(Call(cyl_12, V.Undef, ((V)((-15D))), Add(y4_609, ((V)(8D))), ((V)(0D)), ((V)(1.3)), ((V)(1.2)), ((V)("#c9ced3")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(8D))).V))));
Invoke(o_597, "push", Call(cyl_12, V.Undef, ((V)(18D)), y4_609, ((V)(0D)), ((V)(4D)), ((V)(5D)), ((V)("#e9e4da")), NewObj(3).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))))).V), Call(ball_13, V.Undef, ((V)(18D)), Add(y4_609, ((V)(9.2))), ((V)(0D)), ((V)(3D)), ((V)("#4f8a3e")), NewObj(3).Put("sy", ((V)(1.6))).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V), Call(ball_13, V.Undef, ((V)(18D)), Add(y4_609, ((V)(14.4))), ((V)(0D)), ((V)(1.3)), ((V)("#ff6f9a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
return o_597;
return default;
}, 0, "build", true)).Put("layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis786, int _argc780, V _a782, V _a783, V _a784, V _a785, V[] _rest781) => {
V o_787 = default;
V v_788 = default;
V y2_789 = default;
o_787 = Arr();
v_788 = Fn((V _arrowThis798, int _argc790, V P_796, V sd_797, V _a794, V _a795, V[] _rest791) => {
Invoke(Call(pipe_34, V.Undef, P_796, ((V)(0.35)), ((V)("#3f7a3a")), NewObj(1).Put("n", ((V)(5D))).V), "forEach", Fn((V _arrowThis806, int _argc799, V s_805, V _a802, V _a803, V _a804, V[] _rest800) => {
return Invoke(o_787, "push", s_805);
}, 1, "", true));
{
V i_807 = default;
i_807 = ((V)(1D));
while (true) {
V i_807_it = i_807;
if (!(Lt(i_807_it, Get(P_796, "length")))) break;
V a_809 = default;
V b_810 = default;
a_809 = GetIdx(P_796, (ToNum(i_807_it) - 1D));
b_810 = GetK(P_796, i_807_it);
Invoke(Arr(((V)(0.35)), ((V)(0.8))), "forEach", Fn((V _arrowThis819, int _argc811, V t_817, V j_818, V _a815, V _a816, V[] _rest812) => {
V q_820 = default;
double s2_821 = 0;
q_820 = Arr(Add(GetIdx(a_809, 0D), ((V)(((ToNum(GetIdx(b_810, 0D)) - ToNum(GetIdx(a_809, 0D))) * ToNum(t_817))))), Add(GetIdx(a_809, 1D), ((V)(((ToNum(GetIdx(b_810, 1D)) - ToNum(GetIdx(a_809, 1D))) * ToNum(t_817))))), Add(GetIdx(a_809, 2D), ((V)(((ToNum(GetIdx(b_810, 2D)) - ToNum(GetIdx(a_809, 2D))) * ToNum(t_817))))));
s2_821 = (NumTruthy((ToNum(Add(Add(i_807_it, j_818), sd_797)) % 2D)) ? 1D : (-1D));
Invoke(o_787, "push", Call(ball_13, V.Undef, Add(GetIdx(q_820, 0D), ((V)((s2_821 * 1.6)))), ((V)((ToNum(GetIdx(q_820, 1D)) - 0.6))), Add(GetIdx(q_820, 2D), ((V)(0.9))), ((V)(1.7)), ((V)((NumTruthy((ToNum(Add(i_807_it, j_818)) % 2D)) ? "#5fae4a" : "#86c46a"))), NewObj(5).Put("sx", ((V)(1.2))).Put("sy", ((V)(1.25))).Put("sz", ((V)(0.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
return default;
}, 2, "", true));
i_807 = i_807_it;
PostInc(ref i_807, 1D);
}
}
return default;
}, 2, "", true);
y2_789 = Add(GetIdx(YS_578, 2D), ((V)(TH_577)));
Call(v_788, V.Undef, Arr(Arr(((V)((-31D))), Add(y2_789, ((V)(8.6))), ((V)(4D))), Arr(((V)((-32D))), Add(y2_789, ((V)(5D))), ((V)(11D))), Arr(((V)((-32.6))), Add(y2_789, ((V)(0.8))), ((V)(15.7))), Arr(((V)((-33D))), ((V)((ToNum(y2_789) - 7D))), ((V)(16.3))), Arr(((V)((-32D))), ((V)((ToNum(y2_789) - 16D))), ((V)(16.3))), Arr(((V)((-34D))), ((V)((ToNum(y2_789) - 25D))), ((V)(16.5)))), ((V)(0D)));
Call(v_788, V.Undef, Arr(Arr(((V)((-25D))), Add(y2_789, ((V)(8.6))), ((V)(4D))), Arr(((V)((-24D))), Add(y2_789, ((V)(5D))), ((V)(11D))), Arr(((V)((-23.6))), Add(y2_789, ((V)(0.8))), ((V)(15.7))), Arr(((V)((-23D))), ((V)((ToNum(y2_789) - 6D))), ((V)(16.3))), Arr(((V)((-24.6))), ((V)((ToNum(y2_789) - 15D))), ((V)(16.4)))), ((V)(1D)));
Call(v_788, V.Undef, Arr(Arr(((V)((-28D))), Add(y2_789, ((V)(8.6))), ((V)(5D))), Arr(((V)((-28.4))), Add(y2_789, ((V)(4.4))), ((V)(12D))), Arr(((V)((-28.6))), Add(y2_789, ((V)(0.8))), ((V)(15.7))), Arr(((V)((-29.4))), ((V)((ToNum(y2_789) - 10D))), ((V)(16.4))), Arr(((V)((-28D))), ((V)((ToNum(y2_789) - 22D))), ((V)(16.5))), Arr(((V)((-29.6))), ((V)((ToNum(y2_789) - 31D))), ((V)(16.6)))), ((V)(0D)));
Invoke(Invoke(o_787, "slice", ((V)(1D))), "forEach", Fn((V _arrowThis829, int _argc822, V s_828, V _a825, V _a826, V _a827, V[] _rest823) => {
return Set(s_828, "par", GetIdx(o_787, 0D));
}, 1, "", true));
return o_787;
return default;
}, 0, "build", true)).Put("wrap", Fn((V _arrowThis838, int _argc830, V p_836, V s_837, V _a834, V _a835, V[] _rest831) => {
return ((V)((GtN(Call(fw_60, V.Undef, p_836), 0D) ? JsStrBuf.Begin().S("<g>").V(Call(sway_67, V.Undef, Call(p_836, V.Undef, ((V)((-29D))), Add(Add(GetIdx(YS_578, 2D), ((V)(TH_577))), ((V)(0.8))), ((V)(15.7))), ((V)(1.6)), ((V)(7D)))).V(s_837).S("</g>").End() : "")));
}, 2, "wrap", true)).V)).Put("fx", Fn((V _arrowThis846, int _argc839, V c_845, V _a842, V _a843, V _a844, V[] _rest840) => {
V q_847 = default;
V k_848 = default;
JsStrBuf f_849 = null;
q_847 = Invoke(c_845, "p", ((V)(26D)), ((V)(120.4)), ((V)(0D)));
k_848 = Get(c_845, "k");
f_849 = new JsStrBuf(JsStrBuf.Begin().V(Call(ell_51, V.Undef, c_845, q_847, ((V)((9D * ToNum(k_848)))), ((V)((10D * ToNum(k_848)))), ((V)("url(#q23eb)")), Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.55;0.8;0.6;0.85;0.55")), ((V)(3.4))), ((V)(0.7)))).S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_847, 0D)) - (1.2 * ToNum(k_848))))))).S(" ").V(Call(f1_23, V.Undef, Add(GetIdx(q_847, 1D), ((V)((1.4 * ToNum(k_848))))))).S("l").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(k_848)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-2.6) * ToNum(k_848)))))).S("l").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(k_848)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(k_848)))))).S("l").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(k_848)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-1.6) * ToNum(k_848)))))).S("l").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(k_848)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((2.6 * ToNum(k_848)))))).S("\" fill=\"none\" stroke=\"#ffb53a\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.35 * ToNum(k_848)))))).S("\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.8;1;0.7;1;0.8")), ((V)(1.3)))).S("</path>").End());
if (GtN(Call(face_59, V.Undef, c_845, ((V)(0D)), ((V)(1D))), 0.1)) {
V M_850 = default;
M_850 = Call(frame_36, V.Undef, Get(c_845, "p"), Arr(((V)(22D)), Add(Add(GetIdx(YS_578, 2D), ((V)(TH_577))), ((V)(12.4))), ((V)(2.75))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
f_849.S("<g transform=\"").V(M_850).S("\"><path d=\"M0 0V-2.6M0 0L1.8 0.6\" stroke=\"#2a2a2e\" stroke-width=\"0.45\" stroke-linecap=\"round\"/><path d=\"M0 0V-3.4\" stroke=\"#c8402e\" stroke-width=\"0.2\">").S("<animateTransform attributeName=\"transform\" type=\"rotate\" values=\"0;360\" dur=\"60s\" repeatCount=\"indefinite\"/></path><circle r=\"0.45\" fill=\"#2a2a2e\"/></g>");
}
return NewObj(2).Put("defs", Call(RG_50, V.Undef, ((V)("q23eb")), ((V)("#fff2c4")), ((V)("#ffc46a")), ((V)(0.75)))).Put("front", ((V)(f_849.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_25, "arch23", Fn((V _arrowThis858, int _argc851, V S_857, V _a854, V _a855, V _a856, V[] _rest852) => {
V PNT_859 = default;
V BKP_860 = default;
V OAK_861 = default;
double W_862 = 0;
double H_863 = 0;
double D_864 = 0;
double ZF_865 = 0;
double FT_866 = 0;
V BAYS_867 = default;
PNT_859 = ((V)("#eee7d8"));
BKP_860 = ((V)("#ddd3bf"));
OAK_861 = ((V)("#c8925a"));
W_862 = 176D;
H_863 = 148D;
D_864 = 34D;
ZF_865 = (D_864 / 2D);
FT_866 = 2.4;
BAYS_867 = Arr(Arr(((V)((-58D))), ((V)(24D)), ((V)(108D))), Arr(((V)(0D)), ((V)(29D)), ((V)(106D))), Arr(((V)(58D)), ((V)(24D)), ((V)(108D))));
return NewObj(8).Put("w", ((V)((W_862 + 6D)))).Put("d", ((V)((D_864 + 6D)))).Put("topH", ((V)(H_863))).Put("topW", ((V)(110D))).Put("glow", Fn((V _arrowThis874, int _argc868, V _a870, V _a871, V _a872, V _a873, V[] _rest869) => {
return NewObj(2).Put("y", ((V)(100D))).Put("r", ((V)(56D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis881, int _argc875, V _a877, V _a878, V _a879, V _a880, V[] _rest876) => {
V o_882 = default;
V on_883 = default;
V R_884 = default;
double zb_885 = 0;
V HD_886 = default;
V BN_887 = default;
V DL_888 = default;
V FS_889 = default;
o_882 = Arr();
on_883 = Call(glue_48, V.Undef, o_882);
R_884 = Call(R0_47, V.Undef, ((V)("arch23")));
zb_885 = (((-D_864) / 2D) + 2.2);
Invoke(o_882, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(W_862)), ((V)(8D)), ((V)(D_864)), PNT_859, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis897, int _argc890, V sg_896, V _a893, V _a894, V _a895, V[] _rest891) => {
return Invoke(o_882, "push", Call(box_11, V.Undef, ((V)((ToNum(sg_896) * ((W_862 / 2D) - 3D)))), ((V)(8D)), ((V)(0D)), ((V)(6D)), ((V)((H_863 - 12D))), ((V)(D_864)), PNT_859, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_11, V.Undef, ((V)((ToNum(sg_896) * 31.5))), ((V)(8D)), ((V)(1D)), ((V)(5D)), ((V)((H_863 - 12D))), ((V)((D_864 - 2D))), PNT_859, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Invoke(o_882, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((H_863 - 4D))), ((V)(0.5)), ((V)((W_862 + 4D))), ((V)(4D)), ((V)((D_864 + 1D))), PNT_859, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_11, V.Undef, ((V)(0D)), ((V)(H_863)), ((V)(0D)), ((V)((W_862 + 8D))), ((V)(2.4)), ((V)((D_864 + 4D))), Call(mix_22, V.Undef, PNT_859, ((V)("#ffffff")), ((V)(0.35))), Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
HD_886 = Call(box_11, V.Undef, ((V)(0D)), ((V)(140D)), ((V)((ZF_865 - (FT_866 / 2D)))), ((V)((W_862 - 12D))), ((V)(4D)), ((V)(FT_866)), PNT_859, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V));
Invoke(o_882, "push", HD_886);
Invoke(BAYS_867, "forEach", Fn((V _arrowThis911, int _argc898, V _a900, V _a901, V _a902, V _a903, V[] _rest899) => {
V ay_912 = default;
double NS_913 = 0;
V cx_906 = default;
V hw_908 = default;
V spr_910 = default;
{ V _t904 = ListOf(_a900);
{ V _t905 = GetIdx(_t904, 0D);
cx_906 = _t905; }
{ V _t907 = GetIdx(_t904, 1D);
hw_908 = _t907; }
{ V _t909 = GetIdx(_t904, 2D);
spr_910 = _t909; }
}
ay_912 = Fn((V _arrowThis921, int _argc914, V x_920, V _a917, V _a918, V _a919, V[] _rest915) => {
return Add(spr_910, ((V)(System.Math.Sqrt(Max(0D, ((ToNum(hw_908) * ToNum(hw_908)) - ((ToNum(x_920) - ToNum(cx_906)) * (ToNum(x_920) - ToNum(cx_906)))))))));
}, 1, "", true);
NS_913 = 10D;
Call(on_883, V.Undef, HD_886, Call(rep_45, V.Undef, ((V)(NS_913)), Fn((V _arrowThis929, int _argc922, V s_928, V _a925, V _a926, V _a927, V[] _rest923) => {
double xa_930 = 0;
double xb_931 = 0;
xa_930 = ((ToNum(cx_906) - ToNum(hw_908)) + (((2D * ToNum(hw_908)) * ToNum(s_928)) / NS_913));
xb_931 = ((ToNum(cx_906) - ToNum(hw_908)) + (((2D * ToNum(hw_908)) * ToNum(Add(s_928, ((V)(1D))))) / NS_913));
return Call(prismZ_24, V.Undef, ((V)((ZF_865 - FT_866))), ((V)(ZF_865)), Arr(Arr(((V)(xa_930)), Call(ay_912, V.Undef, ((V)(xa_930)))), Arr(((V)(xb_931)), Call(ay_912, V.Undef, ((V)(xb_931)))), Arr(((V)(xb_931)), ((V)(140D))), Arr(((V)(xa_930)), ((V)(140D)))), PNT_859, Call(PL_42, V.Undef, NewObj(1).Put("noOut", ((V)(1D))).V));
return default;
}, 1, "", true)));
Call(on_883, V.Undef, HD_886, Call(pipe_34, V.Undef, Call(rep_45, V.Undef, ((V)(13D)), Fn((V _arrowThis939, int _argc932, V i_938, V _a935, V _a936, V _a937, V[] _rest933) => {
double t_940 = 0;
t_940 = (PI_26 - ((ToNum(i_938) * PI_26) / 12D));
return Arr(Add(cx_906, ((V)((FdLibm.Cos(t_940) * (ToNum(hw_908) - 0.3))))), Add(spr_910, ((V)((FdLibm.Sin(t_940) * (ToNum(hw_908) - 0.3))))), ((V)((ZF_865 + 0.3))));
return default;
}, 1, "", true)), ((V)(0.55)), Call(mix_22, V.Undef, PNT_859, ((V)("#ffffff")), ((V)(0.5))), NewObj(2).Put("n", ((V)(5D))).Put("noOut", ((V)(1D))).V));
Call(on_883, V.Undef, HD_886, Arr(Call(box_11, V.Undef, cx_906, ((V)((ToNum(Add(spr_910, hw_908)) - 1.2))), ((V)((ZF_865 + 0.3))), ((V)(5D)), ((V)(7D)), ((V)(0.7)), Call(mix_22, V.Undef, PNT_859, ((V)("#ffffff")), ((V)(0.4))), Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V))));
return default;
}, 1, "", true));
Invoke(Arr(GetIdx(BAYS_867, 0D), GetIdx(BAYS_867, 2D)), "forEach", Fn((V _arrowThis950, int _argc941, V _a943, V _a944, V _a945, V _a946, V[] _rest942) => {
V SBs_951 = default;
V cx_949 = default;
{ V _t947 = ListOf(_a943);
{ V _t948 = GetIdx(_t947, 0D);
cx_949 = _t948; }
}
SBs_951 = Invoke(Arr(((V)(36D)), ((V)(64D)), ((V)(92D))), "map", Fn((V _arrowThis959, int _argc952, V y_958, V _a955, V _a956, V _a957, V[] _rest953) => {
V SB_960 = default;
SB_960 = Call(box_11, V.Undef, cx_949, y_958, ((V)(0D)), ((V)(48D)), ((V)(2.2)), ((V)(30D)), OAK_861, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
Invoke(o_882, "push", SB_960);
Call(on_883, V.Undef, SB_960, Arr(Call(slabX_15, V.Undef, cx_949, ((V)((ToNum(y_958) - 0.05))), ((V)(14.6)), ((V)(44D)), ((V)(0.45)), ((V)(0.6)), ((V)("#fff1c8")), Call(em_44, V.Undef, NewObj(1).Put("r", ((V)(0D))).V)), Call(slabX_15, V.Undef, cx_949, Add(y_958, ((V)(1.1))), ((V)(15.05)), ((V)(47D)), ((V)(0.25)), ((V)(0.1)), Call(shade_21, V.Undef, OAK_861, ((V)(0.78))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
return SB_960;
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)(8D)), ((V)(26D))), Arr(((V)(38.2)), ((V)(24D))), Arr(((V)(66.2)), ((V)(24D))), Arr(((V)(94.2)), ((V)(22D)))), "forEach", Fn((V _arrowThis973, int _argc961, V _a963, V j_967, V _a965, V _a966, V[] _rest962) => {
V y_970 = default;
V hm_972 = default;
{ V _t968 = ListOf(_a963);
{ V _t969 = GetIdx(_t968, 0D);
y_970 = _t969; }
{ V _t971 = GetIdx(_t968, 1D);
hm_972 = _t971; }
}
return Call(bk_71, V.Undef, o_882, on_883, R_884, ((V)((ToNum(cx_949) - 24D))), Add(cx_949, ((V)(24D))), y_970, ((V)(zb_885)), ((V)(24D)), hm_972, (SEqN(j_967, 3D) ? deco_69 : (LtN(Call(R_884, V.Undef), 0.6) ? deco_69 : V.Null)), (Truthy(j_967) ? GetIdx(SBs_951, (ToNum(j_967) - 1D)) : V.Null));
}, 2, "", true));
return default;
}, 1, "", true));
BN_887 = Call(box_11, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(58D)), ((V)(26D)), ((V)(30D)), PNT_859, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V));
Invoke(o_882, "push", BN_887);
DL_888 = Call(on_883, V.Undef, BN_887, Arr(Call(box_11, V.Undef, ((V)((-14D))), ((V)(12D)), ((V)(15.35)), ((V)(26D)), ((V)(18D)), ((V)(0.6)), Call(mix_22, V.Undef, PNT_859, ((V)("#ffffff")), ((V)(0.25))), Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_11, V.Undef, ((V)(14D)), ((V)(12D)), ((V)(15.35)), ((V)(26D)), ((V)(18D)), ((V)(0.6)), Call(mix_22, V.Undef, PNT_859, ((V)("#ffffff")), ((V)(0.25))), Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_883, V.Undef, GetIdx(DL_888, 0D), Arr(Call(ball_13, V.Undef, ((V)((-14D))), ((V)(21D)), ((V)(16.3)), ((V)(1D)), BR_29, Call(M__40, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(o_882, "push", Call(cush_18, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0.5)), ((V)(56D)), ((V)(6D)), ((V)(28D)), ((V)("#6b8fb8")), Call(F__41, V.Undef, NewObj(0).V)), Call(pillowZ_19, V.Undef, ((V)((-13D))), ((V)(40D)), ((V)((-10D))), ((V)(20D)), ((V)(18D)), ((V)(8D)), ((V)("#c99a2e")), Call(F__41, V.Undef, NewObj(0).V)), Call(pillowZ_19, V.Undef, ((V)(12D)), ((V)(40D)), ((V)((-10D))), ((V)(18D)), ((V)(16D)), ((V)(8D)), ((V)("#efe4cc")), Call(F__41, V.Undef, NewObj(0).V)));
Invoke(o_882, "push", Call(box_11, V.Undef, ((V)(16D)), ((V)(40D)), ((V)(4.6)), ((V)(18D)), ((V)(0.8)), ((V)(21D)), ((V)("#c96a4a")), Call(F__41, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_11, V.Undef, ((V)(16D)), ((V)(21.4)), ((V)(16.3)), ((V)(18D)), ((V)(19.4)), ((V)(0.8)), ((V)("#c96a4a")), Call(F__41, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
Invoke(o_882, "push", Call(box_11, V.Undef, ((V)((-4D))), ((V)(40D)), ((V)(6D)), ((V)(17D)), ((V)(0.4)), ((V)(11.6)), ((V)("#7f2030")), Call(F__41, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(tilt_30, V.Undef, Call(box_11, V.Undef, ((V)((-8.1))), ((V)(40.4)), ((V)(6D)), ((V)(8D)), ((V)(1.2)), ((V)(11D)), ((V)("#fbf6ea")), NewObj(2).Put("r", ((V)(0.2))).Put("mat", ((V)("fab"))).V), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)((-0.08))), Arr(((V)((-4D))), ((V)(40.4)), ((V)(6D)))), Call(tilt_30, V.Undef, Call(box_11, V.Undef, ((V)(0.1)), ((V)(40.4)), ((V)(6D)), ((V)(8D)), ((V)(1.2)), ((V)(11D)), ((V)("#fbf6ea")), NewObj(2).Put("r", ((V)(0.2))).Put("mat", ((V)("fab"))).V), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(0.08)), Arr(((V)((-4D))), ((V)(40.4)), ((V)(6D)))));
Invoke(o_882, "push", Call(rod_33, V.Undef, Arr(((V)(0D)), ((V)(96D)), ((V)((-14.4)))), Arr(((V)(0D)), ((V)(98.6)), ((V)((-9D)))), ((V)(0.5)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(98.6)), ((V)((-9D))), ((V)(3.8)), ((V)(6.4)), ((V)("#fff2c8")), Call(em_44, V.Undef, NewObj(4).Put("n", ((V)(16D))).Put("noOut", ((V)(0D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.45))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.85))), Arr(((V)(6.4)), ((V)(0D)), ((V)(1D))))).V)));
FS_889 = Call(box_11, V.Undef, ((V)(0D)), ((V)(112D)), ((V)((-9.5))), ((V)(40D)), ((V)(2D)), ((V)(11D)), OAK_861, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
Invoke(o_882, "push", FS_889);
Invoke(o_882, "push", Call(cyl_12, V.Undef, ((V)((-13D))), ((V)(114D)), ((V)((-9.5))), ((V)(3.6)), ((V)(5D)), ((V)("#e9e4da")), NewObj(3).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))))).V));
Call(sprig_55, V.Undef, o_882, ((V)((-13D))), ((V)(119D)), ((V)((-9.5))), R_884, V.Null, ((V)(7D)));
Call(on_883, V.Undef, FS_889, Invoke(Call(rep_45, V.Undef, ((V)(7D)), Fn((V _arrowThis981, int _argc974, V i_980, V _a977, V _a978, V _a979, V[] _rest975) => {
return Call(ball_13, V.Undef, ((V)((((-14.5) + ((ToNum(i_980) % 2D) * 1.8)) - (ToNum(i_980) * 0.3)))), ((V)((111D - (ToNum(i_980) * 2.2)))), ((V)((-2.9))), ((V)(1.5)), ((V)((NumTruthy((ToNum(i_980) % 2D)) ? "#5fae4a" : "#86c46a"))), NewObj(4).Put("sx", ((V)(1.2))).Put("sz", ((V)(0.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 1, "", true)), "concat", Arr(Call(rod_33, V.Undef, Arr(((V)((-13.6))), ((V)(112D)), ((V)((-3.6)))), Arr(((V)((-16.4))), ((V)(97.6)), ((V)((-3.2)))), ((V)(0.25)), ((V)("#3f7a3a")), NewObj(1).Put("n", ((V)(4D))).V))));
Call(bk_71, V.Undef, o_882, on_883, R_884, ((V)((-6D))), ((V)(18D)), ((V)(114D)), ((V)((-14.8))), ((V)(9D)), ((V)(14D)), V.Null);
return o_882;
return default;
}, 0, "build", true)).Put("layers", Call(backL_66, V.Undef, Fn((V _arrowThis988, int _argc982, V _a984, V _a985, V _a986, V _a987, V[] _rest983) => {
V o_989 = default;
V on_990 = default;
V BK_991 = default;
o_989 = Arr();
on_990 = Call(glue_48, V.Undef, o_989);
BK_991 = Call(slab_14, V.Undef, ((V)(0D)), ((V)(8D)), ((V)((((-D_864) / 2D) + 1D))), ((V)((W_862 - 12D))), ((V)((H_863 - 12D))), ((V)(2D)), BKP_860, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0D))).V));
Invoke(o_989, "push", BK_991);
Call(on_990, V.Undef, BK_991, Call(rep_45, V.Undef, ((V)(13D)), Fn((V _arrowThis999, int _argc992, V i_998, V _a995, V _a996, V _a997, V[] _rest993) => {
return Call(box_11, V.Undef, ((V)(((-26D) + (ToNum(i_998) * 4.33)))), ((V)(40D)), ((V)((-14.95))), ((V)(0.4)), ((V)(94D)), ((V)(0.1)), Call(shade_21, V.Undef, BKP_860, ((V)(0.86))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_990, V.Undef, BK_991, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(92D)), ((V)((-14.7))), ((V)(4.4)), ((V)(8D)), ((V)(0.6)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(disc_17, V.Undef, ((V)(0D)), ((V)(99D)), ((V)((-14.98))), ((V)(13D)), ((V)(0.05)), ((V)("#fff2c8")), Call(em_44, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("op", ((V)(0.3))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return o_989;
return default;
}, 0, "", true), Arr(((V)((-14.9))), Arr(Arr(((V)((-82D))), ((V)((-34D))), ((V)(8D)), ((V)(36D))), Arr(((V)((-82D))), ((V)((-34D))), ((V)(38.2)), ((V)(64D))), Arr(((V)((-82D))), ((V)((-34D))), ((V)(66.2)), ((V)(92D))), Arr(((V)((-82D))), ((V)((-34D))), ((V)(94.2)), ((V)(132D))), Arr(((V)(34D)), ((V)(82D)), ((V)(8D)), ((V)(36D))), Arr(((V)(34D)), ((V)(82D)), ((V)(38.2)), ((V)(64D))), Arr(((V)(34D)), ((V)(82D)), ((V)(66.2)), ((V)(92D))), Arr(((V)(34D)), ((V)(82D)), ((V)(94.2)), ((V)(132D))), Arr(((V)((-29D))), ((V)(29D)), ((V)(40D)), ((V)(135D))))))).Put("fx", Fn((V _arrowThis1007, int _argc1000, V c_1006, V _a1003, V _a1004, V _a1005, V[] _rest1001) => {
V q_1008 = default;
V k_1009 = default;
V M_1010 = default;
V f_1011 = default;
if (LtN(Call(face_59, V.Undef, c_1006, ((V)(0D)), ((V)(1D))), 0.05)) {
return NewObj(0).V;
}
q_1008 = Invoke(c_1006, "p", ((V)(0D)), ((V)(104.4)), ((V)((-9D))));
k_1009 = Get(c_1006, "k");
M_1010 = Call(TOP_52, V.Undef, c_1006, ((V)(41.7)), ((V)((-4D))), ((V)(6D)));
f_1011 = Call(ell_51, V.Undef, c_1006, q_1008, ((V)((6D * ToNum(k_1009)))), ((V)((3.4 * ToNum(k_1009)))), ((V)("url(#q23sc)")), Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.5;0.85;0.6;0.9;0.5")), ((V)(5D))), ((V)(0.7)));
f_1011 = ((V)(JsStrBuf.Begin().V(f_1011).S("<g transform=\"").V(M_1010).S("\"><path d=\"M0 -5.4H7.6V5.4H0Z\" fill=\"#fffaf0\" stroke=\"#d9cfb8\" stroke-width=\"0.2\" opacity=\"0\"><animateTransform attributeName=\"transform\" type=\"scale\" values=\"1 1;1 1;-1 1;-1 1\" keyTimes=\"0;0.7;0.86;1\" dur=\"9s\" repeatCount=\"indefinite\"/>").S("<animate attributeName=\"opacity\" values=\"0;1;1;0\" keyTimes=\"0;0.68;0.86;1\" dur=\"9s\" repeatCount=\"indefinite\"/></path></g>").End()));
return NewObj(2).Put("defs", Call(RG_50, V.Undef, ((V)("q23sc")), ((V)("#fff6d0")), ((V)("#ffd88a")), ((V)(0.9)))).Put("front", f_1011).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_25, "lib23", Fn((V _arrowThis1019, int _argc1012, V S_1018, V _a1015, V _a1016, V _a1017, V[] _rest1013) => {
V WAL_1020 = default;
V WD_1021 = default;
V WL_1022 = default;
double W_1023 = 0;
double H_1024 = 0;
double D_1025 = 0;
double ZF_1026 = 0;
V BX_1027 = default;
WAL_1020 = ((V)("#5b3820"));
WD_1021 = ((V)("#4a2c18"));
WL_1022 = Call(shade_21, V.Undef, WAL_1020, ((V)(1.12)));
W_1023 = 170D;
H_1024 = 150D;
D_1025 = 38D;
ZF_1026 = (D_1025 / 2D);
BX_1027 = Arr(Arr(((V)((-53.75))), ((V)(50.5))), Arr(((V)(0D)), ((V)(51D))), Arr(((V)(53.75)), ((V)(50.5))));
return NewObj(8).Put("w", ((V)((W_1023 + 6D)))).Put("d", ((V)((D_1025 + 30D)))).Put("topH", ((V)(156.4))).Put("topW", ((V)(110D))).Put("glow", Fn((V _arrowThis1034, int _argc1028, V _a1030, V _a1031, V _a1032, V _a1033, V[] _rest1029) => {
return NewObj(3).Put("y", ((V)(120D))).Put("r", ((V)(80D))).Put("c", ((V)("url(#gWarm)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1041, int _argc1035, V _a1037, V _a1038, V _a1039, V _a1040, V[] _rest1036) => {
V o_1042 = default;
V on_1043 = default;
V R_1044 = default;
V LC_1045 = default;
V HD_1046 = default;
o_1042 = Arr();
on_1043 = Call(glue_48, V.Undef, o_1042);
R_1044 = Call(R0_47, V.Undef, ((V)("lib23")));
Invoke(o_1042, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(W_1023)), ((V)(6D)), ((V)(D_1025)), WD_1021, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1054, int _argc1047, V sg_1053, V _a1050, V _a1051, V _a1052, V[] _rest1048) => {
return Invoke(o_1042, "push", Call(box_11, V.Undef, ((V)((ToNum(sg_1053) * ((W_1023 / 2D) - 3D)))), ((V)(6D)), ((V)(0D)), ((V)(6D)), ((V)((H_1024 - 6D))), ((V)(D_1025)), WAL_1020, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "", true));
LC_1045 = Call(box_11, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)((W_1023 - 12D))), ((V)(34D)), ((V)(D_1025)), WAL_1020, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
Invoke(o_1042, "push", LC_1045);
Invoke(Arr(((V)((-65D))), ((V)((-39D))), ((V)((-13D))), ((V)(13D)), ((V)(39D)), ((V)(65D))), "forEach", Fn((V _arrowThis1063, int _argc1055, V x_1061, V i_1062, V _a1059, V _a1060, V[] _rest1056) => {
V DR_1064 = default;
DR_1064 = GetIdx(Call(on_1043, V.Undef, LC_1045, Arr(Call(box_11, V.Undef, x_1061, ((V)(9D)), ((V)((ZF_1026 + 0.45))), ((V)(24D)), ((V)(28D)), ((V)(0.8)), WAL_1020, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_1043, V.Undef, DR_1064, Arr(Call(box_11, V.Undef, x_1061, ((V)(12D)), ((V)((ZF_1026 + 1.15))), ((V)(18D)), ((V)(22D)), ((V)(0.6)), WL_1022, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(ball_13, V.Undef, Add(x_1061, ((V)((NumTruthy((ToNum(i_1062) % 2D)) ? (-9.6) : 9.6)))), ((V)(24D)), ((V)((ZF_1026 + 1.5))), ((V)(1D)), BR_29, Call(M__40, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 2, "", true));
Invoke(o_1042, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(1D)), ((V)((W_1023 - 12D))), ((V)(3D)), ((V)((D_1025 + 2D))), WL_1022, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1072, int _argc1065, V sg_1071, V _a1068, V _a1069, V _a1070, V[] _rest1066) => {
return Invoke(o_1042, "push", Call(box_11, V.Undef, ((V)((ToNum(sg_1071) * 27D))), ((V)(43D)), ((V)(1D)), ((V)(3D)), ((V)(99D)), ((V)(36D)), WAL_1020, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Invoke(BX_1027, "forEach", Fn((V _arrowThis1084, int _argc1073, V _a1075, V _a1076, V _a1077, V _a1078, V[] _rest1074) => {
V SBs_1085 = default;
V cx_1081 = default;
V bw_1083 = default;
{ V _t1079 = ListOf(_a1075);
{ V _t1080 = GetIdx(_t1079, 0D);
cx_1081 = _t1080; }
{ V _t1082 = GetIdx(_t1079, 1D);
bw_1083 = _t1082; }
}
SBs_1085 = Invoke(Arr(((V)(76D)), ((V)(108D))), "map", Fn((V _arrowThis1093, int _argc1086, V y_1092, V _a1089, V _a1090, V _a1091, V[] _rest1087) => {
V SB_1094 = default;
SB_1094 = Call(box_11, V.Undef, cx_1081, y_1092, ((V)(0D)), bw_1083, ((V)(2.4)), ((V)(34D)), WAL_1020, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
Invoke(o_1042, "push", SB_1094);
Call(on_1043, V.Undef, SB_1094, Arr(Call(slabX_15, V.Undef, cx_1081, Add(y_1092, ((V)(0.5))), ((V)(17.05)), ((V)((ToNum(bw_1083) - 1D))), ((V)(1.4)), ((V)(0.1)), WL_1022, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(slabX_15, V.Undef, cx_1081, Add(y_1092, ((V)(0.35))), ((V)(17.08)), ((V)((ToNum(bw_1083) - 1D))), ((V)(0.2)), ((V)(0.05)), ((V)("#2a170c")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(slabX_15, V.Undef, cx_1081, Add(y_1092, ((V)(2.05))), ((V)(17.08)), ((V)((ToNum(bw_1083) - 1D))), ((V)(0.2)), ((V)(0.05)), ((V)("#2a170c")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return SB_1094;
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)(43D)), ((V)(30D))), Arr(((V)(78.4)), ((V)(27D))), Arr(((V)(110.4)), ((V)(28D)))), "forEach", Fn((V _arrowThis1107, int _argc1095, V _a1097, V j_1101, V _a1099, V _a1100, V[] _rest1096) => {
V y_1104 = default;
V hm_1106 = default;
{ V _t1102 = ListOf(_a1097);
{ V _t1103 = GetIdx(_t1102, 0D);
y_1104 = _t1103; }
{ V _t1105 = GetIdx(_t1102, 1D);
hm_1106 = _t1105; }
}
return Call(bk_71, V.Undef, o_1042, on_1043, R_1044, ((V)((ToNum(cx_1081) - (ToNum(bw_1083) / 2D)))), Add(cx_1081, ((V)((ToNum(bw_1083) / 2D)))), y_1104, ((V)((-16.8))), ((V)(28D)), hm_1106, deco_69, (Truthy(j_1101) ? GetIdx(SBs_1085, (ToNum(j_1101) - 1D)) : V.Null));
}, 2, "", true));
return default;
}, 1, "", true));
HD_1046 = Call(box_11, V.Undef, ((V)(0D)), ((V)(142D)), ((V)(1D)), ((V)((W_1023 - 12D))), ((V)(8D)), ((V)(36D)), WAL_1020, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
Invoke(o_1042, "push", HD_1046);
Invoke(o_1042, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(H_1024)), ((V)(0D)), ((V)((W_1023 + 4D))), ((V)(3D)), ((V)((D_1025 + 4D))), WAL_1020, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_11, V.Undef, ((V)(0D)), ((V)((H_1024 + 3D))), ((V)((-1D))), ((V)((W_1023 + 10D))), ((V)(3.4)), ((V)((D_1025 + 8D))), WL_1022, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Call(on_1043, V.Undef, HD_1046, Invoke(Arr(Call(rod_33, V.Undef, Arr(((V)((-77D))), ((V)(145D)), ((V)(23D))), Arr(((V)(77D)), ((V)(145D)), ((V)(23D))), ((V)(1.2)), BR_29, Call(M__40, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V))), "concat", Invoke(Arr(((V)((-72D))), ((V)((-26D))), ((V)(26D)), ((V)(72D))), "map", Fn((V _arrowThis1115, int _argc1108, V x_1114, V _a1111, V _a1112, V _a1113, V[] _rest1109) => {
return Call(rod_33, V.Undef, Arr(x_1114, ((V)(145D)), ((V)(19D))), Arr(x_1114, ((V)(145D)), ((V)(21.8))), ((V)(0.6)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(6D))).V));
}, 1, "", true))));
Invoke(BX_1027, "forEach", Fn((V _arrowThis1125, int _argc1116, V _a1118, V _a1119, V _a1120, V _a1121, V[] _rest1117) => {
V L_1126 = default;
V B_1127 = default;
V cx_1124 = default;
{ V _t1122 = ListOf(_a1118);
{ V _t1123 = GetIdx(_t1122, 0D);
cx_1124 = _t1123; }
}
L_1126 = Arr(Call(rod_33, V.Undef, Arr(((V)((ToNum(cx_1124) - 8D))), ((V)(144D)), ((V)(19D))), Arr(((V)((ToNum(cx_1124) - 8D))), ((V)(141.6)), ((V)(21.6))), ((V)(0.4)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)), Call(rod_33, V.Undef, Arr(Add(cx_1124, ((V)(8D))), ((V)(144D)), ((V)(19D))), Arr(Add(cx_1124, ((V)(8D))), ((V)(141.6)), ((V)(21.6))), ((V)(0.4)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)));
B_1127 = Call(slabX_15, V.Undef, cx_1124, ((V)(139.6)), ((V)(22.6)), ((V)(24D)), ((V)(2D)), ((V)(3D)), BR_29, Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("shine", ((V)(1D))).V));
Call(on_1043, V.Undef, HD_1046, Invoke(L_1126, "concat", Arr(B_1127)));
Call(on_1043, V.Undef, B_1127, Arr(Call(slabX_15, V.Undef, cx_1124, ((V)(139.7)), ((V)(24.15)), ((V)(22D)), ((V)(0.6)), ((V)(0.1)), ((V)("#fff4d0")), Call(em_44, V.Undef, NewObj(1).Put("r", ((V)(0D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
return o_1042;
return default;
}, 0, "build", true)).Put("layers", Invoke(Call(backL_66, V.Undef, Fn((V _arrowThis1179, int _argc1173, V _a1175, V _a1176, V _a1177, V _a1178, V[] _rest1174) => {
return Arr(Call(slab_14, V.Undef, ((V)(0D)), ((V)(43D)), ((V)((((-D_1025) / 2D) + 1D))), ((V)((W_1023 - 12D))), ((V)(99D)), ((V)(2D)), WD_1021, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0D))).V)));
}, 0, "", true), Arr(((V)((-16.95))), InvokeSpread(Arr(), "concat", new ArrBuilder().Spread(Invoke(BX_1027, "map", Fn((V _arrowThis1191, int _argc1180, V _a1182, V _a1183, V _a1184, V _a1185, V[] _rest1181) => {
V cx_1188 = default;
V bw_1190 = default;
{ V _t1186 = ListOf(_a1182);
{ V _t1187 = GetIdx(_t1186, 0D);
cx_1188 = _t1187; }
{ V _t1189 = GetIdx(_t1186, 1D);
bw_1190 = _t1189; }
}
return Arr(Arr(((V)((ToNum(cx_1188) - (ToNum(bw_1190) / 2D)))), Add(cx_1188, ((V)((ToNum(bw_1190) / 2D)))), ((V)(43D)), ((V)(76D))), Arr(((V)((ToNum(cx_1188) - (ToNum(bw_1190) / 2D)))), Add(cx_1188, ((V)((ToNum(bw_1190) / 2D)))), ((V)(78.4)), ((V)(108D))), Arr(((V)((ToNum(cx_1188) - (ToNum(bw_1190) / 2D)))), Add(cx_1188, ((V)((ToNum(bw_1190) / 2D)))), ((V)(110.4)), ((V)(142D))));
}, 1, "", true))).V))), "concat", Arr(NewObj(2).Put("build", Fn((V _arrowThis1134, int _argc1128, V _a1130, V _a1131, V _a1132, V _a1133, V[] _rest1129) => {
V o_1135 = default;
V lz_1136 = default;
V WR_1137 = default;
o_1135 = Arr();
lz_1136 = Fn((V _arrowThis1145, int _argc1138, V y_1144, V _a1141, V _a1142, V _a1143, V[] _rest1139) => {
return ((V)((34D - ((ToNum(y_1144) / 145D) * 11D))));
}, 1, "", true);
WR_1137 = ((V)("#7a4a2a"));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1153, int _argc1146, V sg_1152, V _a1149, V _a1150, V _a1151, V[] _rest1147) => {
double x_1154 = 0;
x_1154 = (ToNum(sg_1152) * 9D);
Invoke(o_1135, "push", Call(rod_33, V.Undef, Arr(((V)(x_1154)), ((V)(2D)), Call(lz_1136, V.Undef, ((V)(2D)))), Arr(((V)(x_1154)), ((V)(143.4)), Call(lz_1136, V.Undef, ((V)(143.4)))), ((V)(1.1)), WR_1137, Call(W__39, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(ball_13, V.Undef, ((V)(x_1154)), ((V)(1.8)), Call(lz_1136, V.Undef, ((V)(0D))), ((V)(1.8)), ((V)("#2c2d31")), Call(M__40, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)), Call(box_11, V.Undef, ((V)(x_1154)), ((V)(142.4)), ((V)(23.2)), ((V)(2D)), ((V)(3.6)), ((V)(2.6)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
return default;
}, 1, "", true));
Call(rep_45, V.Undef, ((V)(9D)), Fn((V _arrowThis1162, int _argc1155, V i_1161, V _a1158, V _a1159, V _a1160, V[] _rest1156) => {
double y_1163 = 0;
y_1163 = (14D + (ToNum(i_1161) * 14.5));
Invoke(o_1135, "push", Call(rod_33, V.Undef, Arr(((V)((-7.9))), ((V)(y_1163)), Call(lz_1136, V.Undef, ((V)(y_1163)))), Arr(((V)(7.9)), ((V)(y_1163)), Call(lz_1136, V.Undef, ((V)(y_1163)))), ((V)(0.9)), ((V)("#8a5a34")), Call(W__39, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
return default;
}, 1, "", true));
return o_1135;
return default;
}, 0, "build", true)).Put("wrap", Fn((V _arrowThis1172, int _argc1164, V p_1170, V s_1171, V _a1168, V _a1169, V[] _rest1165) => {
return ((V)((GtN(Call(fw_60, V.Undef, p_1170), 0D) ? JsStrBuf.Begin().S("<g>").V(Call(slide_63, V.Undef, p_1170, Arr(((V)(0D)), ((V)((-48D))), ((V)((-48D))), ((V)(46D)), ((V)(46D)), ((V)(0D))), V.Null, ((V)(34D)), ((V)("0;0.16;0.36;0.6;0.82;1")))).V(s_1171).S("</g>").End() : "")));
}, 2, "wrap", true)).V))).Put("fx", Fn((V _arrowThis1199, int _argc1192, V c_1198, V _a1195, V _a1196, V _a1197, V[] _rest1193) => {
JsStrBuf f_1200 = null;
if (LtN(Call(face_59, V.Undef, c_1198, ((V)(0D)), ((V)(1D))), 0.2)) {
return NewObj(0).V;
}
f_1200 = new JsStrBuf("");
Invoke(BX_1027, "forEach", Fn((V _arrowThis1211, int _argc1201, V _a1203, V i_1207, V _a1205, V _a1206, V[] _rest1202) => {
V cx_1210 = default;
{ V _t1208 = ListOf(_a1203);
{ V _t1209 = GetIdx(_t1208, 0D);
cx_1210 = _t1209; }
}
return ((V)(f_1200.S("<path d=\"").V(Call(qd_61, V.Undef, c_1198, Arr(Arr(((V)((ToNum(cx_1210) - 11D))), ((V)(139.4)), ((V)(21D))), Arr(Add(cx_1210, ((V)(11D))), ((V)(139.4)), ((V)(21D))), Arr(Add(cx_1210, ((V)(22D))), ((V)(100D)), ((V)(16D))), Arr(((V)((ToNum(cx_1210) - 22D))), ((V)(100D)), ((V)(16D)))))).S("\" fill=\"url(#q23pl)\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.55;0.85;0.55")), ((V)(7D)), Call(n4_58, V.Undef, ((V)(((-ToNum(i_1207)) * 1.6)))))).S("</path>").Str));
}, 2, "", true));
return NewObj(2).Put("defs", ((V)("<linearGradient id=\"q23pl\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff1c4\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#fff1c4\" stop-opacity=\"0\"/></linearGradient>"))).Put("front", ((V)(f_1200.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_25, "arc23", Fn((V _arrowThis1219, int _argc1212, V S_1218, V _a1215, V _a1216, V _a1217, V[] _rest1213) => {
V FRM_1220 = default;
V EDG_1221 = default;
double W_1222 = 0;
double H_1223 = 0;
double D_1224 = 0;
double COLS_1225 = 0;
double ROWS_1226 = 0;
double x0_1227 = 0;
double y0_1228 = 0;
double cw_1229 = 0;
double rh_1230 = 0;
V LED_1231 = default;
double GX_1232 = 0;
FRM_1220 = ((V)("#2e3036"));
EDG_1221 = ((V)("#b9c0c8"));
W_1222 = 172D;
H_1223 = 150D;
D_1224 = 26D;
COLS_1225 = 5D;
ROWS_1226 = 4D;
x0_1227 = (((-W_1222) / 2D) + 4D);
y0_1228 = 10D;
cw_1229 = ((W_1222 - 8D) / COLS_1225);
rh_1230 = ((H_1223 - 16D) / ROWS_1226);
LED_1231 = Arr(((V)("#cfe9ff")), ((V)("#ffe7c2")), ((V)("#e2d4ff")), ((V)("#c9fff0")), ((V)("#ffd9c9")));
GX_1232 = (x0_1227 + 12D);
return NewObj(7).Put("w", ((V)((W_1222 + 6D)))).Put("d", ((V)((D_1224 + 16D)))).Put("topH", ((V)(H_1223))).Put("topW", ((V)(110D))).Put("build", Fn((V _arrowThis1239, int _argc1233, V _a1235, V _a1236, V _a1237, V _a1238, V[] _rest1234) => {
V o_1240 = default;
V on_1241 = default;
V R_1242 = default;
V BS_1243 = default;
V BKS_1244 = default;
V TP_1245 = default;
o_1240 = Arr();
on_1241 = Call(glue_48, V.Undef, o_1240);
R_1242 = Call(R0_47, V.Undef, ((V)("arc23")));
BS_1243 = Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(W_1222)), ((V)(y0_1228)), ((V)(D_1224)), FRM_1220, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V));
Invoke(o_1240, "push", BS_1243);
BKS_1244 = Call(slab_14, V.Undef, ((V)(0D)), ((V)(y0_1228)), ((V)((((-D_1224) / 2D) + 1D))), ((V)((W_1222 - 8D))), ((V)((H_1223 - 16D))), ((V)(2D)), ((V)("#15171c")), Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0D))).V));
Invoke(o_1240, "push", BKS_1244);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1253, int _argc1246, V sg_1252, V _a1249, V _a1250, V _a1251, V[] _rest1247) => {
return Invoke(o_1240, "push", Call(box_11, V.Undef, ((V)((ToNum(sg_1252) * ((W_1222 / 2D) - 2D)))), ((V)(y0_1228)), ((V)(0D)), ((V)(4D)), ((V)((H_1223 - 16D))), ((V)(D_1224)), FRM_1220, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}, 1, "", true));
TP_1245 = Call(box_11, V.Undef, ((V)(0D)), ((V)((H_1223 - 6D))), ((V)(0D)), ((V)(W_1222)), ((V)(6D)), ((V)(D_1224)), FRM_1220, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V));
Invoke(o_1240, "push", TP_1245);
Call(on_1241, V.Undef, TP_1245, Arr(Call(slabX_15, V.Undef, ((V)(0D)), ((V)((H_1223 - 4D))), ((V)(((D_1224 / 2D) + 0.05))), ((V)((W_1222 - 2D))), ((V)(1.2)), ((V)(0.1)), EDG_1221, Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(rep_45, V.Undef, ((V)((COLS_1225 - 1D))), Fn((V _arrowThis1261, int _argc1254, V i_1260, V _a1257, V _a1258, V _a1259, V[] _rest1255) => {
V DV_1262 = default;
DV_1262 = Call(box_11, V.Undef, ((V)((x0_1227 + (cw_1229 * ToNum(Add(i_1260, ((V)(1D)))))))), ((V)(y0_1228)), ((V)(1D)), ((V)(2D)), ((V)((H_1223 - 16D))), ((V)((D_1224 - 2D))), FRM_1220, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V));
Invoke(o_1240, "push", DV_1262);
Call(on_1241, V.Undef, DV_1262, Arr(Call(box_11, V.Undef, ((V)((x0_1227 + (cw_1229 * ToNum(Add(i_1260, ((V)(1D)))))))), ((V)(y0_1228)), ((V)(((D_1224 / 2D) + 0.05))), ((V)(2D)), ((V)((H_1223 - 16D))), ((V)(0.1)), EDG_1221, Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
Call(rep_45, V.Undef, ((V)(COLS_1225)), Fn((V _arrowThis1270, int _argc1263, V i_1269, V _a1266, V _a1267, V _a1268, V[] _rest1264) => {
double xa_1271 = 0;
double xb_1272 = 0;
xa_1271 = ((x0_1227 + (cw_1229 * ToNum(i_1269))) + (Truthy(i_1269) ? 1D : 0D));
xb_1272 = ((x0_1227 + (cw_1229 * ToNum(Add(i_1269, ((V)(1D)))))) - (LtN(i_1269, (COLS_1225 - 1D)) ? 1D : 0D));
Call(rep_45, V.Undef, ((V)((ROWS_1226 - 1D))), Fn((V _arrowThis1280, int _argc1273, V j_1279, V _a1276, V _a1277, V _a1278, V[] _rest1274) => {
V SB_1281 = default;
SB_1281 = Call(box_11, V.Undef, ((V)(((xa_1271 + xb_1272) / 2D))), ((V)(((y0_1228 + (rh_1230 * ToNum(Add(j_1279, ((V)(1D)))))) - 1D))), ((V)(1D)), ((V)((xb_1272 - xa_1271))), ((V)(2D)), ((V)((D_1224 - 2D))), FRM_1220, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V));
Invoke(o_1240, "push", SB_1281);
Call(on_1241, V.Undef, SB_1281, Arr(Call(slabX_15, V.Undef, ((V)(((xa_1271 + xb_1272) / 2D))), ((V)(((y0_1228 + (rh_1230 * ToNum(Add(j_1279, ((V)(1D)))))) - 1D))), ((V)(((D_1224 / 2D) + 0.05))), ((V)((xb_1272 - xa_1271))), ((V)(2D)), ((V)(0.1)), EDG_1221, Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Call(box_11, V.Undef, ((V)(((xa_1271 + xb_1272) / 2D))), ((V)(((y0_1228 + (rh_1230 * ToNum(Add(j_1279, ((V)(1D)))))) - 0.6))), ((V)(((D_1224 / 2D) + 0.17))), ((V)(6D)), ((V)(1.2)), ((V)(0.05)), ((V)("#f6f6f2")), NewObj(2).Put("r", ((V)(0.1))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((((xa_1271 + xb_1272) / 2D) - 1D))), ((V)(((y0_1228 + (rh_1230 * ToNum(Add(j_1279, ((V)(1D)))))) - 0.2))), ((V)(((D_1224 / 2D) + 0.2))), ((V)(3D)), ((V)(0.2)), ((V)(0.03)), ((V)("#2c2d31")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(slabX_15, V.Undef, ((V)(((xa_1271 + xb_1272) / 2D))), ((V)(((y0_1228 + (rh_1230 * ToNum(Add(j_1279, ((V)(1D)))))) - 1.4))), ((V)(((D_1224 / 2D) - 1.4))), ((V)(((xb_1272 - xa_1271) - 2D))), ((V)(0.4)), ((V)(0.5)), ((V)("#ffffff")), Call(em_44, V.Undef, NewObj(1).Put("r", ((V)(0D))).V))));
return default;
}, 1, "", true));
Call(rep_45, V.Undef, ((V)(ROWS_1226)), Fn((V _arrowThis1289, int _argc1282, V j_1288, V _a1285, V _a1286, V _a1287, V[] _rest1283) => {
double cx_1290 = 0;
double b_1291 = 0;
double t_1292 = 0;
double hh_1293 = 0;
double zc_1294 = 0;
double kind_1295 = 0;
cx_1290 = (x0_1227 + (cw_1229 * ToNum(Add(i_1269, ((V)(0.5))))));
b_1291 = ((y0_1228 + (rh_1230 * ToNum(j_1288))) + (Truthy(j_1288) ? 1D : 0D));
t_1292 = ((y0_1228 + (rh_1230 * ToNum(Add(j_1288, ((V)(1D)))))) - (LtN(j_1288, (ROWS_1226 - 1D)) ? 1D : 0D));
hh_1293 = (t_1292 - b_1291);
zc_1294 = (-1D);
kind_1295 = System.Math.Floor((ToNum(Call(R_1242, V.Undef)) * 6D));
Call(on_1241, V.Undef, BKS_1244, Arr(Call(box_11, V.Undef, ((V)(cx_1290)), ((V)((b_1291 + 1.4))), ((V)((((-D_1224) / 2D) + 2.05))), ((V)((cw_1229 - 6D))), ((V)((hh_1293 - 3.4))), ((V)(0.1)), GetIdx(LED_1231, (ToNum(Add(((V)((ToNum(i_1269) * 2D))), j_1288)) % 5D)), Call(em_44, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("op", ((V)(0.55))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
if ((kind_1295 == 0D)) {
Call(rep_45, V.Undef, ((V)(3D)), Fn((V _arrowThis1303, int _argc1296, V k_1302, V _a1299, V _a1300, V _a1301, V[] _rest1297) => {
V A_1304 = default;
A_1304 = Call(box_11, V.Undef, ((V)(((cx_1290 - 9.4) + (ToNum(k_1302) * 9.4)))), ((V)(b_1291)), ((V)(zc_1294)), ((V)(8.4)), ((V)(10D)), ((V)(15D)), GetK(Arr(((V)("#d8cdb8")), ((V)("#c9bba0")), ((V)("#e2d6c0"))), k_1302), NewObj(2).Put("r", ((V)(0.5))).Put("mat", ((V)("fab"))).V);
Invoke(o_1240, "push", A_1304);
Call(on_1241, V.Undef, A_1304, Arr(Call(box_11, V.Undef, ((V)(((cx_1290 - 9.4) + (ToNum(k_1302) * 9.4)))), ((V)((b_1291 + 5.4))), ((V)((zc_1294 + 7.55))), ((V)(4.6)), ((V)(2.4)), ((V)(0.1)), ((V)("#ffffff")), NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(((cx_1290 - 9.4) + (ToNum(k_1302) * 9.4)))), ((V)((b_1291 + 8D))), ((V)((zc_1294 + 7.55))), ((V)(3.6)), ((V)(1D)), ((V)(0.1)), ((V)("#5a4a3a")), NewObj(2).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
} else {
if ((kind_1295 == 1D)) {
Call(bk_71, V.Undef, o_1240, on_1241, R_1242, ((V)(((cx_1290 - (cw_1229 / 2D)) + 1.6))), ((V)(((cx_1290 + (cw_1229 / 2D)) - 1.6))), ((V)(b_1291)), ((V)((((-D_1224) / 2D) + 2.4))), ((V)(15D)), ((V)((hh_1293 - 5D))), V.Null);
} else {
if ((kind_1295 == 2D)) {
Invoke(o_1240, "push", Call(cyl_12, V.Undef, ((V)((cx_1290 - 5D))), ((V)(b_1291)), ((V)(zc_1294)), ((V)(4.6)), ((V)(15D)), GetIdx(Arr(((V)("#2c2d31")), ((V)("#e9e4da")), ((V)("#3f6a8a"))), System.Math.Floor((ToNum(Call(R_1242, V.Undef)) * 3D))), NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))), Arr(((V)(12D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(15D)), ((V)(0D)), ((V)(0.75))))).V), Call(cyl_12, V.Undef, ((V)((cx_1290 + 6D))), ((V)(b_1291)), ((V)((zc_1294 + 2D))), ((V)(3.2)), ((V)(8D)), ((V)("#c8693f")), NewObj(3).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))))).V));
} else {
if ((kind_1295 == 3D)) {
Invoke(o_1240, "push", Call(box_11, V.Undef, ((V)(cx_1290)), ((V)(b_1291)), ((V)(zc_1294)), ((V)(10D)), ((V)(4D)), ((V)(10D)), ((V)("#1d1e22")), Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(ball_13, V.Undef, ((V)(cx_1290)), ((V)((b_1291 + 10D))), ((V)(zc_1294)), ((V)(6D)), GetIdx(Arr(((V)("#d4a548")), ((V)("#d5dde2")), ((V)("#e9e4da"))), System.Math.Floor((ToNum(Call(R_1242, V.Undef)) * 3D))), Call(M__40, V.Undef, NewObj(3).Put("k", ((V)(7D))).Put("n", ((V)(16D))).Put("shine", ((V)(1D))).V)));
} else {
if ((kind_1295 == 4D)) {
Call(rep_45, V.Undef, ((V)(3D)), Fn((V _arrowThis1312, int _argc1305, V k_1311, V _a1308, V _a1309, V _a1310, V[] _rest1306) => {
double x_1313 = 0;
V J_1314 = default;
x_1313 = ((cx_1290 - 9D) + (ToNum(k_1311) * 9D));
J_1314 = Call(cyl_12, V.Undef, ((V)(x_1313)), ((V)(b_1291)), ((V)(zc_1294)), ((V)(3.4)), ((V)((10D + (ToNum(k_1311) * 2D)))), ((V)("#dff2f8")), NewObj(3).Put("n", ((V)(14D))).Put("op", ((V)(0.38))).Put("shine", ((V)(1D))).V);
Invoke(o_1240, "push", J_1314);
Call(on_1241, V.Undef, J_1314, Arr(Call(cyl_12, V.Undef, ((V)(x_1313)), ((V)((b_1291 + 0.3))), ((V)(zc_1294)), ((V)(2.9)), ((V)((5D + (ToNum(k_1311) * 2D)))), GetK(Arr(((V)("#9fcf6a")), ((V)("#ffb45a")), ((V)("#7fb2ff"))), k_1311), NewObj(2).Put("n", ((V)(12D))).Put("op", ((V)(0.8))).V), Call(cyl_12, V.Undef, ((V)(x_1313)), ((V)(((b_1291 + 10D) + (ToNum(k_1311) * 2D)))), ((V)(zc_1294)), ((V)(3D)), ((V)(1.4)), ((V)("#2c2d31")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V))));
return default;
}, 1, "", true));
} else {
Invoke(o_1240, "push", Call(box_11, V.Undef, ((V)(cx_1290)), ((V)(b_1291)), ((V)(zc_1294)), ((V)(14D)), ((V)(2D)), ((V)(10D)), ((V)("#1d1e22")), Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)), Call(box_11, V.Undef, ((V)(cx_1290)), ((V)((b_1291 + 2D))), ((V)(zc_1294)), ((V)(8D)), ((V)(8D)), ((V)(8D)), ((V)("#9ff0ff")), Call(em_44, V.Undef, NewObj(3).Put("r", ((V)(0.8))).Put("op", ((V)(0.55))).Put("noOut", ((V)(0D))).V)));
}
}
}
}
}
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Call(on_1241, V.Undef, BS_1243, Arr(Call(rod_33, V.Undef, Arr(((V)((-80D))), ((V)(7D)), ((V)(((D_1224 / 2D) + 1.4)))), Arr(((V)(80D)), ((V)(7D)), ((V)(((D_1224 / 2D) + 1.4)))), ((V)(1D)), CH_28, Call(M__40, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V)), Call(box_11, V.Undef, ((V)(68D)), ((V)(2.4)), ((V)(((D_1224 / 2D) + 0.15))), ((V)(16D)), ((V)(4.4)), ((V)(0.2)), ((V)("#0e1a24")), NewObj(2).Put("r", ((V)(0.6))).Put("noOut", ((V)(1D))).V)));
Call(on_1241, V.Undef, TP_1245, Arr(Call(rod_33, V.Undef, Arr(((V)((-80D))), ((V)((H_1223 - 3D))), ((V)(((D_1224 / 2D) + 1.4)))), Arr(((V)(80D)), ((V)((H_1223 - 3D))), ((V)(((D_1224 / 2D) + 1.4)))), ((V)(1D)), CH_28, Call(M__40, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V))));
return o_1240;
return default;
}, 0, "build", true)).Put("layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1321, int _argc1315, V _a1317, V _a1318, V _a1319, V _a1320, V[] _rest1316) => {
return Arr(Call(box_11, V.Undef, ((V)(GX_1232)), ((V)((y0_1228 - 0.4))), ((V)(((D_1224 / 2D) + 3.6))), ((V)(3D)), ((V)(((H_1223 - (2D * y0_1228)) + 0.8))), ((V)(2.4)), ((V)("#c9ced3")), Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V)), Call(box_11, V.Undef, ((V)(GX_1232)), ((V)(4.6)), ((V)(((D_1224 / 2D) + 3D))), ((V)(8D)), ((V)(5D)), ((V)(3.6)), ((V)("#2c2d31")), Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_11, V.Undef, ((V)(GX_1232)), ((V)((H_1223 - 9.6))), ((V)(((D_1224 / 2D) + 3D))), ((V)(8D)), ((V)(5D)), ((V)(3.6)), ((V)("#2c2d31")), Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_11, V.Undef, ((V)(GX_1232)), ((V)((H_1223 - 8.6))), ((V)(((D_1224 / 2D) + 4.85))), ((V)(4D)), ((V)(1D)), ((V)(0.1)), ((V)("#4fe0ff")), Call(em_44, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
}, 0, "build", true)).Put("wrap", Fn((V _arrowThis1330, int _argc1322, V p_1328, V s_1329, V _a1326, V _a1327, V[] _rest1323) => {
return ((V)((GtN(Call(fw_60, V.Undef, p_1328), 0D) ? JsStrBuf.Begin().S("<g>").V(Call(slide_63, V.Undef, p_1328, Arr(((V)(0D)), ((V)(0D)), ((V)(66D)), ((V)(66D)), ((V)(132D)), ((V)(132D)), ((V)(0D))), V.Null, ((V)(22D)), ((V)("0;0.1;0.3;0.45;0.65;0.8;1")))).V(s_1329).S("</g>").End() : "")));
}, 2, "wrap", true)).V, NewObj(2).Put("build", Fn((V _arrowThis1337, int _argc1331, V _a1333, V _a1334, V _a1335, V _a1336, V[] _rest1332) => {
V o_1338 = default;
V A_1339 = default;
o_1338 = Arr();
A_1339 = Call(box_11, V.Undef, ((V)(GX_1232)), ((V)(70D)), ((V)(((D_1224 / 2D) + 7.3))), ((V)(8D)), ((V)(7D)), ((V)(5D)), ((V)("#2c2d31")), Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V));
Invoke(o_1338, "push", A_1339, Call(box_11, V.Undef, ((V)(GX_1232)), ((V)(62D)), ((V)(((D_1224 / 2D) + 7.3))), ((V)(7D)), ((V)(8D)), ((V)(5D)), ((V)("#d8cdb8")), NewObj(2).Put("r", ((V)(0.5))).Put("mat", ((V)("fab"))).V));
Call(Call(glue_48, V.Undef, o_1338), V.Undef, A_1339, Arr(Call(box_11, V.Undef, ((V)(GX_1232)), ((V)(73.4)), ((V)(((D_1224 / 2D) + 9.85))), ((V)(4D)), ((V)(1.2)), ((V)(0.1)), ((V)("#4fe0ff")), Call(em_44, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_11, V.Undef, ((V)((GX_1232 - 2.6))), ((V)(71D)), ((V)(((D_1224 / 2D) + 9.85))), ((V)(1D)), ((V)(1D)), ((V)(0.1)), ((V)("#ff5a5a")), Call(em_44, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return o_1338;
return default;
}, 0, "build", true)).Put("wrap", Fn((V _arrowThis1348, int _argc1340, V p_1346, V s_1347, V _a1344, V _a1345, V[] _rest1341) => {
return ((V)((GtN(Call(fw_60, V.Undef, p_1346), 0D) ? JsStrBuf.Begin().S("<g>").V(Call(slide_63, V.Undef, p_1346, Arr(((V)(0D)), ((V)(0D)), ((V)(66D)), ((V)(66D)), ((V)(132D)), ((V)(132D)), ((V)(0D))), V.Null, ((V)(22D)), ((V)("0;0.1;0.3;0.45;0.65;0.8;1")))).S("<g>").V(Call(slide_63, V.Undef, p_1346, Arr(((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)((-28D))), ((V)(0D)), ((V)(36D)), ((V)(0D))), ((V)(22D)), ((V)("0;0.2;0.3;0.55;0.65;0.9;1")))).V(s_1347).S("</g></g>").End() : "")));
}, 2, "wrap", true)).V)).Put("fx", Fn((V _arrowThis1356, int _argc1349, V c_1355, V _a1352, V _a1353, V _a1354, V[] _rest1350) => {
JsStrBuf f_1357 = null;
if (LtN(Call(face_59, V.Undef, c_1355, ((V)(0D)), ((V)(1D))), 0.1)) {
return NewObj(0).V;
}
f_1357 = new JsStrBuf("");
Call(rep_45, V.Undef, ((V)(5D)), Fn((V _arrowThis1365, int _argc1358, V i_1364, V _a1361, V _a1362, V _a1363, V[] _rest1359) => {
V q_1366 = default;
q_1366 = Invoke(c_1355, "p", ((V)((62D + (ToNum(i_1364) * 2.6)))), ((V)(4.6)), ((V)(((D_1224 / 2D) + 0.3))));
f_1357.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_1366, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_1366, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(Get(c_1355, "k"))))))).S("\" fill=\"").V(GetK(Arr(((V)("#4fe0ff")), ((V)("#7fff9a")), ((V)("#ffd66b")), ((V)("#4fe0ff")), ((V)("#ff7a7a"))), i_1364)).S("\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.2;1;0.2")), Call(n4_58, V.Undef, ((V)((1.2 + (ToNum(i_1364) * 0.37))))), Call(n4_58, V.Undef, ((V)(((-ToNum(i_1364)) * 0.3)))))).S("</circle>");
return default;
}, 1, "", true));
return NewObj(1).Put("front", ((V)(f_1357.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_25, "faux23", Fn((V _arrowThis1374, int _argc1367, V S_1373, V _a1370, V _a1371, V _a1372, V[] _rest1368) => {
V MO_1375 = default;
V BRK_1376 = default;
double W_1377 = 0;
double D_1378 = 0;
double OX_1379 = 0;
double OY_1380 = 0;
double HY_1381 = 0;
double MY_1382 = 0;
double ZF_1383 = 0;
MO_1375 = ((V)("#d8cbb6"));
BRK_1376 = Arr(((V)("#b4553c")), ((V)("#a84a34")), ((V)("#c0634a")));
W_1377 = 120D;
D_1378 = 30D;
OX_1379 = 26D;
OY_1380 = 45.4;
HY_1381 = 4D;
MY_1382 = 74D;
ZF_1383 = (D_1378 / 2D);
return NewObj(6).Put("w", ((V)((W_1377 + 12D)))).Put("d", ((V)((D_1378 + 16D)))).Put("glow", Fn((V _arrowThis1390, int _argc1384, V _a1386, V _a1387, V _a1388, V _a1389, V[] _rest1385) => {
return NewObj(2).Put("y", ((V)(14D))).Put("r", ((V)(60D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1397, int _argc1391, V _a1393, V _a1394, V _a1395, V _a1396, V[] _rest1392) => {
V o_1398 = default;
V on_1399 = default;
V HE_1400 = default;
V PLf_1401 = default;
V PRt_1402 = default;
V LT_1403 = default;
V MT_1404 = default;
V HT_1405 = default;
V GR_1406 = default;
o_1398 = Arr();
on_1399 = Call(glue_48, V.Undef, o_1398);
HE_1400 = Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)((W_1377 + 8D))), ((V)(HY_1381)), ((V)((D_1378 + 8D))), ((V)("#6f6a64")), NewObj(2).Put("r", ((V)(0.6))).Put("mat", ((V)("cer"))).V);
Invoke(o_1398, "push", HE_1400);
Call(on_1399, V.Undef, HE_1400, Invoke(Invoke(Arr(((V)((-5D))), ((V)(4D)), ((V)(13D))), "map", Fn((V _arrowThis1422, int _argc1415, V z_1421, V _a1418, V _a1419, V _a1420, V[] _rest1416) => {
return Call(slabX_15, V.Undef, ((V)(0D)), ((V)((HY_1381 + 0.02))), z_1421, ((V)((W_1377 + 6D))), ((V)(0.05)), ((V)(0.25)), ((V)("#55504a")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)), "concat", Call(rep_45, V.Undef, ((V)(7D)), Fn((V _arrowThis1414, int _argc1407, V i_1413, V _a1410, V _a1411, V _a1412, V[] _rest1408) => {
return Call(box_11, V.Undef, ((V)(((-48D) + (ToNum(i_1413) * 16D)))), ((V)((HY_1381 + 0.02))), ((V)(4D)), ((V)(0.25)), ((V)(0.05)), ((V)((D_1378 + 6D))), ((V)("#55504a")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
PLf_1401 = Call(box_11, V.Undef, ((V)((-43D))), ((V)(HY_1381)), ((V)(1D)), ((V)(34D)), ((V)((OY_1380 - HY_1381))), ((V)((D_1378 - 2D))), MO_1375, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
PRt_1402 = Call(box_11, V.Undef, ((V)(43D)), ((V)(HY_1381)), ((V)(1D)), ((V)(34D)), ((V)((OY_1380 - HY_1381))), ((V)((D_1378 - 2D))), MO_1375, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
LT_1403 = Call(box_11, V.Undef, ((V)(0D)), ((V)(OY_1380)), ((V)(0D)), ((V)(W_1377)), ((V)((MY_1382 - OY_1380))), ((V)(D_1378)), MO_1375, Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
Invoke(o_1398, "push", PLf_1401, PRt_1402, LT_1403);
Invoke(o_1398, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(HY_1381)), ((V)(((-ZF_1383) + 1D))), ((V)(W_1377)), ((V)((OY_1380 - HY_1381))), ((V)(2D)), ((V)("#1e1c1b")), NewObj(1).Put("r", ((V)(0.2))).V));
Call(on_1399, V.Undef, PLf_1401, Arr(Call(box_11, V.Undef, ((V)(((-OX_1379) + 0.3))), ((V)(HY_1381)), ((V)(1D)), ((V)(0.6)), ((V)((OY_1380 - HY_1381))), ((V)((D_1378 - 2D))), ((V)("#2a2725")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))));
Call(on_1399, V.Undef, PRt_1402, Arr(Call(box_11, V.Undef, ((V)((OX_1379 - 0.3))), ((V)(HY_1381)), ((V)(1D)), ((V)(0.6)), ((V)((OY_1380 - HY_1381))), ((V)((D_1378 - 2D))), ((V)("#2a2725")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)((-1D))), ((V)(0D)), ((V)(0D))));
Call(on_1399, V.Undef, LT_1403, Arr(Call(box_11, V.Undef, ((V)(54D)), ((V)(66.4)), ((V)((ZF_1383 + 0.05))), ((V)(8.4)), ((V)(7.4)), ((V)(0.1)), ((V)("#c9a676")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
{
V j_1423 = default;
j_1423 = ((V)(0D));
while (true) {
V j_1423_it = j_1423;
if (!(LtN(j_1423_it, 11D))) break;
double y_1425 = 0;
double off_1426 = 0;
y_1425 = (4.6 + (ToNum(j_1423_it) * 5.9));
off_1426 = (NumTruthy((ToNum(j_1423_it) % 2D)) ? 6.15 : 0D);
{
V k_1427 = default;
k_1427 = ((V)((-1D)));
while (true) {
V k_1427_it = k_1427;
if (!(LtN(k_1427_it, 11D))) break;
double xa_1429 = 0;
double xb_1430 = 0;
xa_1429 = (((-60D) + off_1426) + (ToNum(k_1427_it) * 12.3));
xb_1430 = (xa_1429 + 11.4);
Invoke(((y_1425 > OY_1380) ? Arr(Arr(((V)((-60D))), ((V)(60D)), LT_1403)) : Arr(Arr(((V)((-60D))), ((V)((-OX_1379))), PLf_1401), Arr(((V)(OX_1379)), ((V)(60D)), PRt_1402))), "forEach", Fn((V _arrowThis1444, int _argc1431, V _a1433, V _a1434, V _a1435, V _a1436, V[] _rest1432) => {
double a_1445 = 0;
double b_1446 = 0;
V cc_1447 = default;
V u_1439 = default;
V v_1441 = default;
V P_1443 = default;
{ V _t1437 = ListOf(_a1433);
{ V _t1438 = GetIdx(_t1437, 0D);
u_1439 = _t1438; }
{ V _t1440 = GetIdx(_t1437, 1D);
v_1441 = _t1440; }
{ V _t1442 = GetIdx(_t1437, 2D);
P_1443 = _t1442; }
}
a_1445 = Max(xa_1429, ToNum(Add(u_1439, ((V)(0.3)))));
b_1446 = Min(xb_1430, (ToNum(v_1441) - 0.3));
if (((b_1446 - a_1445) < 1.2)) {
return default;
}
if (((SEq(P_1443, LT_1403) && (b_1446 > 49.6)) && ((y_1425 + 5D) > 66D))) {
return default;
}
cc_1447 = GetIdx(Arr(((V)("#b4553c")), ((V)("#a84a34")), ((V)("#c0634a")), ((V)("#9c4430")), ((V)("#b85e44")), ((V)("#aa5238"))), (((((ToNum(j_1423_it) * 7D) + (ToNum(k_1427_it) * 13D)) % 6D) + 6D) % 6D));
Call(on_1399, V.Undef, P_1443, Invoke(Arr(Call(box_11, V.Undef, ((V)(((a_1445 + b_1446) / 2D))), ((V)(y_1425)), ((V)((ZF_1383 + 0.2))), ((V)((b_1446 - a_1445))), ((V)(5D)), ((V)(0.4)), cc_1447, NewObj(3).Put("r", ((V)(0.5))).Put("noOut", ((V)(1D))).Put("mat", ((V)("cer"))).V), Call(box_11, V.Undef, ((V)(((a_1445 + b_1446) / 2D))), ((V)((y_1425 + 4.3))), ((V)((ZF_1383 + 0.62))), ((V)(((b_1446 - a_1445) - 0.8))), ((V)(0.4)), ((V)(0.05)), Call(shade_21, V.Undef, cc_1447, ((V)(1.28))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(((a_1445 + b_1446) / 2D))), ((V)((y_1425 + 0.25))), ((V)((ZF_1383 + 0.62))), ((V)(((b_1446 - a_1445) - 0.8))), ((V)(0.35)), ((V)(0.05)), Call(shade_21, V.Undef, cc_1447, ((V)(0.72))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), "concat", (NumTruthy((ToNum(Add(j_1423_it, k_1427_it)) % 3D)) ? Arr() : Arr(Call(box_11, V.Undef, ((V)((a_1445 + ((b_1446 - a_1445) * 0.3)))), ((V)((y_1425 + 2.2))), ((V)((ZF_1383 + 0.63))), ((V)(0.7)), ((V)(0.5)), ((V)(0.05)), Call(shade_21, V.Undef, cc_1447, ((V)(0.6))), NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V)))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
k_1427 = k_1427_it;
PostInc(ref k_1427, 1D);
}
}
j_1423 = j_1423_it;
PostInc(ref j_1423, 1D);
}
}
Call(on_1399, V.Undef, LT_1403, Arr(Call(tilt_30, V.Undef, Call(box_11, V.Undef, ((V)(54.4)), ((V)(66.4)), ((V)((ZF_1383 + 0.45))), ((V)(9D)), ((V)(7.4)), ((V)(0.3)), GetIdx(BRK_1376, 0D), NewObj(2).Put("r", ((V)(0.3))).Put("mat", ((V)("cer"))).V), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), ((V)((-0.5))), Arr(((V)(49.9)), ((V)(66.4)), ((V)((ZF_1383 + 0.45)))))));
MT_1404 = Call(box_11, V.Undef, ((V)(0D)), ((V)(MY_1382)), ((V)(2D)), ((V)((W_1377 + 10D))), ((V)(4D)), ((V)((D_1378 + 6D))), ((V)("#a87a4e")), Call(W__39, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V));
Invoke(o_1398, "push", MT_1404);
Call(on_1399, V.Undef, MT_1404, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)((MY_1382 + 1.2))), ((V)(((D_1378 / 2D) + 5.05))), ((V)((W_1377 + 8D))), ((V)(0.5)), ((V)(0.1)), ((V)("#c9a06a")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1399, V.Undef, MT_1404, Call(pipe_34, V.Undef, Arr(Arr(((V)(60.4)), ((V)((MY_1382 + 1.8))), ((V)(((D_1378 / 2D) + 5.1)))), Arr(((V)(61.6)), ((V)((MY_1382 + 0.6))), ((V)(((D_1378 / 2D) + 6.2)))), Arr(((V)(62D)), ((V)((MY_1382 - 1.2))), ((V)(((D_1378 / 2D) + 5.6))))), ((V)(0.3)), ((V)("#c9a06a")), NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V));
HT_1405 = Call(box_11, V.Undef, ((V)(0D)), ((V)(HY_1381)), ((V)((-1D))), ((V)(28D)), ((V)(20D)), ((V)(12D)), ((V)("#ece6da")), Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(2D))).V));
Invoke(o_1398, "push", HT_1405);
GR_1406 = GetIdx(Call(on_1399, V.Undef, HT_1405, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)((HY_1381 + 3D))), ((V)(5.15)), ((V)(22D)), ((V)(13D)), ((V)(0.3)), ((V)("#2b2b2e")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_1399, V.Undef, GR_1406, Call(rep_45, V.Undef, ((V)(3D)), Fn((V _arrowThis1455, int _argc1448, V i_1454, V _a1451, V _a1452, V _a1453, V[] _rest1449) => {
return Call(box_11, V.Undef, ((V)(0D)), ((V)(((HY_1381 + 5D) + (ToNum(i_1454) * 3.8)))), ((V)(5.45)), ((V)(19D)), ((V)(1.1)), ((V)(0.3)), ((V)("#ff7a2a")), Call(em_44, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V));
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1399, V.Undef, HT_1405, Arr(Call(box_11, V.Undef, ((V)((-3D))), ((V)((HY_1381 + 20D))), ((V)((-1D))), ((V)(10D)), ((V)(1.4)), ((V)(2D)), ((V)("#d8d0c2")), Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(cyl_12, V.Undef, ((V)(10D)), ((V)((HY_1381 + 20D))), ((V)(2D)), ((V)(1.6)), ((V)(1.4)), ((V)("#3a3a3e")), Call(PL_42, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))));
Call(on_1399, V.Undef, HE_1400, Invoke(Call(pipe_34, V.Undef, Arr(Arr(((V)((-14.4))), ((V)((HY_1381 + 1.4))), ((V)((-4D)))), Arr(((V)((-20D))), ((V)((HY_1381 + 0.6))), ((V)(2D))), Arr(((V)((-22D))), ((V)((HY_1381 + 0.6))), ((V)(10D))), Arr(((V)((-25D))), ((V)((HY_1381 + 0.6))), ((V)(18D))), Arr(((V)((-34D))), ((V)((HY_1381 + 0.6))), ((V)(21D))), Arr(((V)((-50D))), ((V)((HY_1381 + 0.6))), ((V)(21D)))), ((V)(0.5)), ((V)("#f2efe8")), Call(PL_42, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)), "concat", Arr(Call(box_11, V.Undef, ((V)((-52.4))), ((V)(HY_1381)), ((V)(21D)), ((V)(3D)), ((V)(1.6)), ((V)(2.6)), ((V)("#f2efe8")), Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)))));
Invoke(o_1398, "push", Call(ball_13, V.Undef, ((V)(44D)), ((V)((HY_1381 + 1.2))), ((V)(18D)), ((V)(1.8)), ((V)("#a8a29a")), Call(F__41, V.Undef, NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
Invoke(o_1398, "push", Call(disc_17, V.Undef, ((V)((-36D))), ((V)(((MY_1382 + 4D) + 6D))), ((V)(6D)), ((V)(6D)), ((V)(1.6)), ((V)("#f2efe8")), Call(PL_42, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)), Call(box_11, V.Undef, ((V)((-36D))), ((V)((MY_1382 + 4D))), ((V)(6.8)), ((V)(6D)), ((V)(0.8)), ((V)(2D)), ((V)("#d8d0c2")), Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
Invoke(o_1398, "push", Call(cyl_12, V.Undef, ((V)(26D)), ((V)((MY_1382 + 4D))), ((V)(4D)), ((V)(2.2)), ((V)(5D)), ((V)("#f4e9d0")), NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("cer"))).V), Call(rod_33, V.Undef, Arr(((V)(26D)), ((V)((MY_1382 + 9D))), ((V)(4D))), Arr(((V)(26D)), ((V)((MY_1382 + 10.2))), ((V)(4D))), ((V)(0.18)), ((V)("#2a2020")), NewObj(1).Put("n", ((V)(4D))).V), Call(cyl_12, V.Undef, ((V)(32D)), ((V)((MY_1382 + 4D))), ((V)(7D)), ((V)(1.8)), ((V)(3.2)), ((V)("#e86f8a")), NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("cer"))).V));
return o_1398;
return default;
}, 0, "build", true)).Put("layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1462, int _argc1456, V _a1458, V _a1459, V _a1460, V _a1461, V[] _rest1457) => {
V o_1463 = default;
V on_1464 = default;
double z_1465 = 0;
V L_1466 = default;
o_1463 = Arr();
on_1464 = Call(glue_48, V.Undef, o_1463);
z_1465 = (ZF_1383 + 1.4);
L_1466 = Call(box_11, V.Undef, ((V)(14D)), ((V)(60D)), ((V)(z_1465)), ((V)(4.4)), ((V)(8D)), ((V)(1.4)), ((V)("#e8e2d4")), Call(F__41, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V));
Invoke(o_1463, "push", L_1466, Call(box_11, V.Undef, ((V)(15.6)), ((V)(56D)), ((V)(z_1465)), ((V)(7.6)), ((V)(4D)), ((V)(1.4)), ((V)("#e8e2d4")), Call(F__41, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(ball_13, V.Undef, ((V)(14D)), ((V)(68.6)), ((V)((ZF_1383 + 1.2))), ((V)(0.9)), ((V)("#e8402a")), Call(PL_42, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
Call(on_1464, V.Undef, L_1466, Invoke(Arr(((V)(62D)), ((V)(65D))), "map", Fn((V _arrowThis1474, int _argc1467, V y_1473, V _a1470, V _a1471, V _a1472, V[] _rest1468) => {
return Call(box_11, V.Undef, ((V)(14D)), y_1473, ((V)((z_1465 + 0.75))), ((V)(4.5)), ((V)(1D)), ((V)(0.1)), ((V)("#d9483b")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return o_1463;
return default;
}, 0, "build", true)).Put("wrap", Fn((V _arrowThis1483, int _argc1475, V p_1481, V s_1482, V _a1479, V _a1480, V[] _rest1476) => {
return ((V)((GtN(Call(fw_60, V.Undef, p_1481), 0D) ? JsStrBuf.Begin().S("<g>").V(Call(sway_67, V.Undef, Call(p_1481, V.Undef, ((V)(14D)), ((V)(68.6)), ((V)((ZF_1383 + 1.2)))), ((V)(5D)), ((V)(3.8)))).V(s_1482).S("</g>").End() : "")));
}, 2, "wrap", true)).V)).Put("fx", Fn((V _arrowThis1491, int _argc1484, V c_1490, V _a1487, V _a1488, V _a1489, V[] _rest1485) => {
V @out_1492 = default;
V k_1493 = default;
V M_1494 = default;
V q_1495 = default;
V W0_1496 = default;
@out_1492 = NewObj(2).Put("defs", ((V)(""))).Put("front", ((V)(""))).V;
if (LtN(Call(face_59, V.Undef, c_1490, ((V)(0D)), ((V)(1D))), 0.05)) {
return @out_1492;
}
k_1493 = Get(c_1490, "k");
OpSet(@out_1492, "front", 0, ((V)(JsStrBuf.Begin().S("<path d=\"").V(Call(qd_61, V.Undef, c_1490, Arr(Arr(((V)((-11D))), ((V)((HY_1381 + 3D))), ((V)(5.6))), Arr(((V)(11D)), ((V)((HY_1381 + 3D))), ((V)(5.6))), Arr(((V)(11D)), ((V)((HY_1381 + 16D))), ((V)(5.6))), Arr(((V)((-11D))), ((V)((HY_1381 + 16D))), ((V)(5.6)))))).S("\" fill=\"#ff8a3a\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.25;0.6;0.4;0.65;0.25")), ((V)(2.8)))).S("</path>").End())));
OpSet(@out_1492, "front", 0, Call(fxEll_35, V.Undef, c_1490, ((V)(0D)), ((V)((HY_1381 + 0.1))), ((V)(12D)), ((V)(18D)), ((V)("url(#q23ht)")), Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.5;0.9;0.6;0.9;0.5")), ((V)(2.8)))));
M_1494 = Call(frame_36, V.Undef, Get(c_1490, "p"), Arr(((V)((-36D))), ((V)((MY_1382 + 10D))), ((V)(7.7))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
OpSet(@out_1492, "front", 0, ((V)(JsStrBuf.Begin().S("<g transform=\"").V(M_1494).S("\"><circle r=\"5\" fill=\"none\" stroke=\"#c9c2b4\" stroke-width=\"0.3\"/>").V(Invoke(Call(rep_45, V.Undef, ((V)(12D)), Fn((V _arrowThis1504, int _argc1497, V i_1503, V _a1500, V _a1501, V _a1502, V[] _rest1498) => {
double a_1505 = 0;
a_1505 = ((ToNum(i_1503) * PI_26) / 6D);
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)((FdLibm.Cos(a_1505) * 4.2))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((FdLibm.Sin(a_1505) * 4.2))))).S("\" r=\"0.25\" fill=\"#5a5450\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M0 0L-1.6 -1.6M0 0V-3.6\" stroke=\"#2a2a2e\" stroke-width=\"0.45\" stroke-linecap=\"round\"/><path d=\"M0 0.8V-3.8\" stroke=\"#d9483b\" stroke-width=\"0.2\"><animateTransform attributeName=\"transform\" type=\"rotate\" values=\"0;360\" dur=\"60s\" repeatCount=\"indefinite\"/></path></g>").End())));
q_1495 = Invoke(c_1490, "p", ((V)(26D)), ((V)((MY_1382 + 12.4))), ((V)(4D)));
OpSet(@out_1492, "front", 0, ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_57, V.Undef, q_1495)).S(") scale(").V(Call(f1_23, V.Undef, k_1493)).S(")\"><ellipse cy=\"-1.4\" rx=\"3.4\" ry=\"3.8\" fill=\"url(#q23cf)\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.4;0.8;0.5;0.75;0.4")), ((V)(1.6)))).S("</ellipse><path d=\"M0 -3.6Q1.6 -1.2 0.4 0.6Q-1.4 0 0 -3.6Z\" fill=\"#ffcf4a\" stroke=\"#ff8a2a\" stroke-width=\"0.2\"><animateTransform attributeName=\"transform\" type=\"skewX\" values=\"-14;-4;-18;-8;-14\" dur=\"1.7s\" repeatCount=\"indefinite\"/></path></g>").End())));
W0_1496 = Call(frame_36, V.Undef, Get(c_1490, "p"), Arr(((V)((-OX_1379))), ((V)(OY_1380)), ((V)((ZF_1383 + 0.7)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
OpSet(@out_1492, "front", 0, ((V)(JsStrBuf.Begin().S("<g transform=\"").V(W0_1496).S("\" opacity=\"0.6\"><g><animateTransform attributeName=\"transform\" type=\"skewX\" values=\"0;3;0;-2;0\" dur=\"5s\" repeatCount=\"indefinite\"/><path d=\"M0 9Q3 6 9 0M0 5Q2.6 3 5 0M0 2Q1 1 2 0M0 9Q4 9 6.4 4.8Q8 3 9 0\" fill=\"none\" stroke=\"#f4f0ea\" stroke-width=\"0.18\"/></g></g>").End())));
Set(@out_1492, "defs", Add(Call(RG_50, V.Undef, ((V)("q23ht")), ((V)("#ffb05a")), ((V)("#ff8a3a")), ((V)(0.5))), Call(RG_50, V.Undef, ((V)("q23cf")), ((V)("#fff3b0")), ((V)("#ffb347")), ((V)(0.8)))));
return @out_1492;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_25, "stove23", Fn((V _arrowThis1513, int _argc1506, V S_1512, V _a1509, V _a1510, V _a1511, V[] _rest1507) => {
V IRN_1514 = default;
V IRL_1515 = default;
V PAD_1516 = default;
IRN_1514 = ((V)("#26272b"));
IRL_1515 = Call(shade_21, V.Undef, IRN_1514, ((V)(1.35)));
PAD_1516 = ((V)("#3d4046"));
return NewObj(5).Put("w", ((V)(84D))).Put("d", ((V)(62D))).Put("glow", Fn((V _arrowThis1523, int _argc1517, V _a1519, V _a1520, V _a1521, V _a1522, V[] _rest1518) => {
return NewObj(2).Put("y", ((V)(26D))).Put("r", ((V)(60D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1530, int _argc1524, V _a1526, V _a1527, V _a1528, V _a1529, V[] _rest1525) => {
V o_1531 = default;
V on_1532 = default;
V BD_1533 = default;
V DF_1534 = default;
V TP_1535 = default;
V FL_1536 = default;
V KB_1537 = default;
V BA_1538 = default;
V RM_1539 = default;
o_1531 = Arr();
on_1532 = Call(glue_48, V.Undef, o_1531);
Invoke(o_1531, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(78D)), ((V)(3D)), ((V)(56D)), PAD_1516, NewObj(3).Put("r", ((V)(1D))).Put("mat", ((V)("cer"))).Put("bev", ((V)(0.8))).V));
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis1551, int _argc1540, V _a1542, V _a1543, V _a1544, V _a1545, V[] _rest1541) => {
V sx_1548 = default;
V sz_1550 = default;
{ V _t1546 = ListOf(_a1542);
{ V _t1547 = GetIdx(_t1546, 0D);
sx_1548 = _t1547; }
{ V _t1549 = GetIdx(_t1546, 1D);
sz_1550 = _t1549; }
}
return Invoke(o_1531, "push", Call(cyl_12, V.Undef, ((V)((ToNum(sx_1548) * 19D))), ((V)(3D)), ((V)((ToNum(sz_1550) * 11D))), ((V)(2.6)), ((V)(9D)), IRN_1514, Call(M__40, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.3))), Arr(((V)(2D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V)));
}, 1, "", true));
BD_1533 = Call(box_11, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(48D)), ((V)(34D)), ((V)(30D)), IRN_1514, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(1.6))).V));
Invoke(o_1531, "push", BD_1533);
Call(on_1532, V.Undef, BD_1533, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(15.8)), ((V)(48D)), ((V)(3D)), ((V)(1.6)), IRN_1514, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V))));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1559, int _argc1552, V sg_1558, V _a1555, V _a1556, V _a1557, V[] _rest1553) => {
V P_1560 = default;
P_1560 = GetIdx(Call(on_1532, V.Undef, BD_1533, Arr(Call(box_11, V.Undef, ((V)((ToNum(sg_1558) * 24.05))), ((V)(16D)), ((V)(0D)), ((V)(0.6)), ((V)(26D)), ((V)(24D)), IRL_1515, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V))), Arr(sg_1558, ((V)(0D)), ((V)(0D)))), 0D);
Call(on_1532, V.Undef, P_1560, Invoke(Invoke(Arr(Call(box_11, V.Undef, ((V)((ToNum(sg_1558) * 24.4))), ((V)(19D)), ((V)(0D)), ((V)(0.3)), ((V)(20D)), ((V)(18D)), IRN_1514, Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("noOut", ((V)(1D))).V))), "concat", Invoke(Arr(Arr(((V)((-6D))), ((V)(29D))), Arr(((V)(6D)), ((V)(29D))), Arr(((V)(0D)), ((V)(23D))), Arr(((V)(0D)), ((V)(35D)))), "map", Fn((V _arrowThis1572, int _argc1561, V _a1563, V _a1564, V _a1565, V _a1566, V[] _rest1562) => {
V z_1569 = default;
V y_1571 = default;
{ V _t1567 = ListOf(_a1563);
{ V _t1568 = GetIdx(_t1567, 0D);
z_1569 = _t1568; }
{ V _t1570 = GetIdx(_t1567, 1D);
y_1571 = _t1570; }
}
return Call(ball_13, V.Undef, ((V)((ToNum(sg_1558) * 24.5))), y_1571, z_1569, ((V)(1.6)), IRL_1515, Call(M__40, V.Undef, NewObj(3).Put("sx", ((V)(0.3))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V));
}, 1, "", true))), "concat", Arr(Call(solid_20, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(29D)))).Put("a", ((V)(3.4))).Put("b", ((V)(3.4))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)((ToNum(sg_1558) * 24.5))), ((V)(0D))), Arr(((V)((ToNum(sg_1558) * 24.9))), ((V)(0D))))).Put("col", IRL_1515).Put("mat", ((V)("metal"))).V))), Arr(sg_1558, ((V)(0D)), ((V)(0D))));
return default;
}, 1, "", true));
Call(on_1532, V.Undef, BD_1533, InvokeSpread(Arr(), "concat", new ArrBuilder().Spread(Invoke(Arr(((V)((-22.6))), ((V)(22.6))), "map", Fn((V _arrowThis1580, int _argc1573, V x_1579, V _a1576, V _a1577, V _a1578, V[] _rest1574) => {
return Call(rep_45, V.Undef, ((V)(6D)), Fn((V _arrowThis1588, int _argc1581, V i_1587, V _a1584, V _a1585, V _a1586, V[] _rest1582) => {
return Call(ball_13, V.Undef, x_1579, ((V)((18D + (ToNum(i_1587) * 5D)))), ((V)(15.2)), ((V)(0.55)), IRL_1515, Call(M__40, V.Undef, NewObj(4).Put("sz", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
}, 1, "", true))).V), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1532, V.Undef, BD_1533, Invoke(Invoke(Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(13.4)), ((V)(16.65)), ((V)(10D)), ((V)(1.6)), ((V)(0.1)), GOLD_27, Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V))), "concat", Call(rep_45, V.Undef, ((V)(6D)), Fn((V _arrowThis1604, int _argc1597, V i_1603, V _a1600, V _a1601, V _a1602, V[] _rest1598) => {
return Call(box_11, V.Undef, ((V)(((-20D) + (ToNum(i_1603) * 2.2)))), ((V)(13.2)), ((V)(16.65)), ((V)(1.2)), ((V)(1.4)), ((V)(0.05)), ((V)("#0e0e10")), NewObj(2).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).V);
}, 1, "", true))), "concat", Call(rep_45, V.Undef, ((V)(6D)), Fn((V _arrowThis1596, int _argc1589, V i_1595, V _a1592, V _a1593, V _a1594, V[] _rest1590) => {
return Call(box_11, V.Undef, ((V)((9D + (ToNum(i_1595) * 2.2)))), ((V)(13.2)), ((V)(16.65)), ((V)(1.2)), ((V)(1.4)), ((V)(0.05)), ((V)("#0e0e10")), NewObj(2).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).V);
}, 1, "", true))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
DF_1534 = GetIdx(Call(on_1532, V.Undef, BD_1533, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(17D)), ((V)(15.55)), ((V)(36D)), ((V)(24D)), ((V)(1D)), ((V)("#1d1e21")), Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_1532, V.Undef, DF_1534, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(19.4)), ((V)(16.1)), ((V)(29.4)), ((V)(19.2)), ((V)(0.1)), ((V)("#0c0c0d")), NewObj(2).Put("r", ((V)(0.8))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(16.15)), ((V)(28D)), ((V)(18D)), ((V)(0.2)), ((V)("#1a0d08")), NewObj(2).Put("r", ((V)(0.6))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(38.8)), ((V)(16.12)), ((V)(30D)), ((V)(0.5)), ((V)(0.06)), ((V)("#5a5c62")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(cyl_12, V.Undef, ((V)((-18.4))), ((V)(21D)), ((V)(16.4)), ((V)(1D)), ((V)(3D)), ((V)("#3a3b40")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(cyl_12, V.Undef, ((V)((-18.4))), ((V)(34D)), ((V)(16.4)), ((V)(1D)), ((V)(3D)), ((V)("#3a3b40")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(8D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1532, V.Undef, DF_1534, Call(pipe_34, V.Undef, Arr(Arr(((V)(16D)), ((V)(32D)), ((V)(16.05))), Arr(((V)(16D)), ((V)(32D)), ((V)(18.6))), Arr(((V)(16D)), ((V)(25D)), ((V)(18.6))), Arr(((V)(16D)), ((V)(25D)), ((V)(16.05)))), ((V)(0.5)), ((V)("#b9b2a6")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
TP_1535 = Call(box_11, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(0D)), ((V)(54D)), ((V)(2.6)), ((V)(36D)), IRN_1514, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V));
Invoke(o_1531, "push", TP_1535);
Call(on_1532, V.Undef, TP_1535, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(48.6)), ((V)(0D)), ((V)(50D)), ((V)(1.2)), ((V)(32D)), IRL_1515, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))));
Invoke(o_1531, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(48.6)), ((V)((-4D))), ((V)(7.4)), ((V)(4D)), IRN_1514, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
FL_1536 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(52.6)), ((V)((-4D))), ((V)(6D)), ((V)(96D)), ((V)("#2e2f33")), Call(M__40, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V));
Invoke(o_1531, "push", FL_1536);
Call(on_1532, V.Undef, FL_1536, Invoke(Invoke(Arr(((V)(80D)), ((V)(112D))), "map", Fn((V _arrowThis1612, int _argc1605, V y_1611, V _a1608, V _a1609, V _a1610, V[] _rest1606) => {
return Call(band_46, V.Undef, ((V)(0D)), y_1611, ((V)((-4D))), ((V)(6.05)), ((V)(1.2)), ((V)("#3e4046")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(18D))).V));
}, 1, "", true)), "concat", Arr(Call(rod_33, V.Undef, Arr(((V)(6D)), ((V)(70D)), ((V)((-4D)))), Arr(((V)(9D)), ((V)(70D)), ((V)((-4D)))), ((V)(0.5)), ((V)("#b9b2a6")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)))));
KB_1537 = Call(ball_13, V.Undef, ((V)(14D)), ((V)(54.9)), ((V)(6D)), ((V)(6.4)), ((V)("#c0392b")), Call(M__40, V.Undef, NewObj(4).Put("sy", ((V)(0.8))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).Put("shine", ((V)(1D))).V));
Invoke(o_1531, "push", KB_1537);
Call(on_1532, V.Undef, KB_1537, Arr(Call(cyl_12, V.Undef, ((V)(14D)), ((V)(59.6)), ((V)(6D)), ((V)(2.6)), ((V)(1D)), ((V)("#a8302a")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(ball_13, V.Undef, ((V)(14D)), ((V)(61.2)), ((V)(6D)), ((V)(1D)), ((V)("#1d1e21")), Call(M__40, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V))));
Invoke(Call(pipe_34, V.Undef, Arr(Arr(((V)(19.6)), ((V)(54D)), ((V)(6D))), Arr(((V)(22.6)), ((V)(57.4)), ((V)(6D))), Arr(((V)(24.2)), ((V)(59.2)), ((V)(6D)))), ((V)(0.8)), ((V)("#c0392b")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), "forEach", Fn((V _arrowThis1620, int _argc1613, V s_1619, V _a1616, V _a1617, V _a1618, V[] _rest1614) => {
return Call(on_1532, V.Undef, KB_1537, Arr(s_1619));
}, 1, "", true));
Call(on_1532, V.Undef, KB_1537, Call(pipe_34, V.Undef, Arr(Arr(((V)(9.4)), ((V)(59D)), ((V)(6D))), Arr(((V)(11D)), ((V)(64D)), ((V)(6D))), Arr(((V)(17D)), ((V)(64D)), ((V)(6D))), Arr(((V)(18.6)), ((V)(59D)), ((V)(6D)))), ((V)(0.45)), ((V)("#1d1e21")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
BA_1538 = Call(cyl_12, V.Undef, ((V)((-32D))), ((V)(3D)), ((V)(22D)), ((V)(6D)), ((V)(8D)), ((V)("#b98a58")), Call(F__41, V.Undef, NewObj(3).Put("n", ((V)(18D))).Put("soft", ((V)(0D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))))).V));
Invoke(o_1531, "push", BA_1538);
Call(on_1532, V.Undef, BA_1538, Arr(Call(band_46, V.Undef, ((V)((-32D))), ((V)(9.6)), ((V)(22D)), ((V)(6.05)), ((V)(1.2)), ((V)("#8a6440"))), Call(band_46, V.Undef, ((V)((-32D))), ((V)(4.6)), ((V)(22D)), ((V)(5.5)), ((V)(0.9)), ((V)("#8a6440")))));
Invoke(Arr(Arr(((V)(20D)), ((V)(13.2))), Arr(((V)(24.2)), ((V)(13.2))), Arr(((V)(22.1)), ((V)(16.9)))), "forEach", Fn((V _arrowThis1632, int _argc1621, V _a1623, V _a1624, V _a1625, V _a1626, V[] _rest1622) => {
V LG_1633 = default;
V z_1629 = default;
V y_1631 = default;
{ V _t1627 = ListOf(_a1623);
{ V _t1628 = GetIdx(_t1627, 0D);
z_1629 = _t1628; }
{ V _t1630 = GetIdx(_t1627, 1D);
y_1631 = _t1630; }
}
LG_1633 = Call(solid_20, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(z_1629, y_1631)).Put("a", ((V)(2.1))).Put("b", ((V)(2.1))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((-38.5))), ((V)(0D))), Arr(((V)((-25.5))), ((V)(0D))))).Put("col", ((V)("#ece6da"))).Put("mat", ((V)("wood"))).V);
Invoke(o_1531, "push", LG_1633);
Call(on_1532, V.Undef, LG_1633, Arr(Call(solid_20, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(z_1629, y_1631)).Put("a", ((V)(1.8))).Put("b", ((V)(1.8))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)((-25.5))), ((V)(0D))), Arr(((V)((-25.4))), ((V)(0D))))).Put("col", ((V)("#d9b48a"))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((-32D))), Add(y_1631, ((V)(1.6))), z_1629, ((V)(1.6)), ((V)(0.5)), ((V)(1.4)), ((V)("#3a3230")), NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((-29D))), Add(y_1631, ((V)(1.7))), Add(z_1629, ((V)(0.6))), ((V)(1D)), ((V)(0.4)), ((V)(1.2)), ((V)("#3a3230")), NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V)));
return default;
}, 1, "", true));
RM_1539 = Call(box_11, V.Undef, ((V)(27D)), ((V)(3D)), ((V)(26D)), ((V)(3.4)), ((V)(1.2)), ((V)(8D)), ((V)("#1d1e21")), Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V));
Invoke(o_1531, "push", RM_1539);
Call(on_1532, V.Undef, RM_1539, Call(rep_45, V.Undef, ((V)(4D)), Fn((V _arrowThis1641, int _argc1634, V i_1640, V _a1637, V _a1638, V _a1639, V[] _rest1635) => {
return Call(cyl_12, V.Undef, ((V)(27D)), ((V)(4.2)), ((V)((23.6 + (ToNum(i_1640) * 1.6)))), ((V)(0.5)), ((V)(0.2)), ((V)((Truthy(i_1640) ? "#9aa3a8" : "#d9483b"))), NewObj(2).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
return o_1531;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1649, int _argc1642, V c_1648, V _a1645, V _a1646, V _a1647, V[] _rest1643) => {
V k_1650 = default;
V @out_1651 = default;
V F_1652 = default;
V lg_1653 = default;
k_1650 = Get(c_1648, "k");
@out_1651 = NewObj(2).Put("defs", Call(RG_50, V.Undef, ((V)("q23sg")), ((V)("#ffb05a")), ((V)("#ff7a2a")), ((V)(0.5)))).Put("front", ((V)(""))).V;
Call(rep_45, V.Undef, ((V)(3D)), Fn((V _arrowThis1661, int _argc1654, V i_1660, V _a1657, V _a1658, V _a1659, V[] _rest1655) => {
V a_1662 = default;
V b_1663 = default;
a_1662 = Invoke(c_1648, "p", ((V)(24.6)), ((V)(60D)), ((V)(6D)));
b_1663 = Call(n4_58, V.Undef, ((V)(((-ToNum(i_1660)) * 1.3))));
OpSet(@out_1651, "front", 0, ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(a_1662, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(a_1662, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(k_1650)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((1.2 * ToNum(k_1650)))))).S("\" fill=\"#ffffff\" opacity=\"0\">").V(Call(an_37, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(a_1662, 1D))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(a_1662, 1D)) - (18D * ToNum(k_1650))))))).End())), ((V)(3.9)), b_1663)).V(Call(an_37, V.Undef, ((V)("cx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(a_1662, 0D))).S(";").V(Call(f1_23, V.Undef, Add(GetIdx(a_1662, 0D), ((V)((4D * ToNum(k_1650))))))).End())), ((V)(3.9)), b_1663)).V(Call(an_37, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((1.2 * ToNum(k_1650)))))).S(";").V(Call(f1_23, V.Undef, ((V)((4.6 * ToNum(k_1650)))))).End())), ((V)(3.9)), b_1663)).V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0;0.55;0")), ((V)(3.9)), b_1663)).S("</ellipse>").End())));
return default;
}, 1, "", true));
if (LtN(Call(face_59, V.Undef, c_1648, ((V)(0D)), ((V)(1D))), 0.05)) {
return @out_1651;
}
F_1652 = Call(fireIn_62, V.Undef, c_1648, ((V)("q23sw")), Arr(Arr(((V)((-14D))), ((V)(20D)), ((V)(16.3))), Arr(((V)(14D)), ((V)(20D)), ((V)(16.3))), Arr(((V)(14D)), ((V)(38D)), ((V)(16.3))), Arr(((V)((-14D))), ((V)(38D)), ((V)(16.3)))), Arr(Arr(((V)((-6D))), ((V)(22.4)), ((V)(12D)), ((V)(0.42))), Arr(((V)(0.5)), ((V)(22.4)), ((V)(12.6)), ((V)(0.5))), Arr(((V)(6.6)), ((V)(22.4)), ((V)(12D)), ((V)(0.42)))));
lg_1653 = Invoke(c_1648, "p", ((V)(0D)), ((V)(21.4)), ((V)(16.3)));
OpSet(@out_1651, "defs", 0, Get(F_1652, "defs"));
OpSet(@out_1651, "front", 0, ((V)(JsStrBuf.Begin().S("<g clip-path=\"url(#q23sw)\"><ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(lg_1653, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(lg_1653, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((13D * ToNum(k_1650)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((4.4 * ToNum(k_1650)))))).S("\" fill=\"url(#q23sg)\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.75;1;0.6")), ((V)(2.2)))).S("</ellipse><rect x=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(lg_1653, 0D)) - (10D * ToNum(k_1650))))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(lg_1653, 1D)) - (2.2 * ToNum(k_1650))))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((20D * ToNum(k_1650)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(k_1650)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1.2 * ToNum(k_1650)))))).S("\" fill=\"#4a2a18\"/>").V(Get(F_1652, "g")).S("<path d=\"").V(Call(qd_61, V.Undef, c_1648, Arr(Arr(((V)((-12D))), ((V)(38D)), ((V)(16.3))), Arr(((V)((-6D))), ((V)(38D)), ((V)(16.3))), Arr(((V)((-14D))), ((V)(26D)), ((V)(16.3))), Arr(((V)((-14D))), ((V)(32D)), ((V)(16.3)))))).S("\" fill=\"#ffffff\" opacity=\"0.12\"/></g>").End())));
OpSet(@out_1651, "front", 0, Call(fxEll_35, V.Undef, c_1648, ((V)(0D)), ((V)(3.1)), ((V)(26D)), ((V)(14D)), ((V)("url(#q23sg)")), Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.15;0.32;0.2;0.3;0.15")), ((V)(2.2)))));
return @out_1651;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_25, "mantel23", Fn((V _arrowThis1671, int _argc1664, V S_1670, V _a1667, V _a1668, V _a1669, V[] _rest1665) => {
V PNT_1672 = default;
V PL2_1673 = default;
V SL_1674 = default;
V IRN_1675 = default;
double D_1676 = 0;
double ZF_1677 = 0;
PNT_1672 = ((V)("#f4f1ea"));
PL2_1673 = Call(mix_22, V.Undef, PNT_1672, ((V)("#ffffff")), ((V)(0.4)));
SL_1674 = ((V)("#2c2e33"));
IRN_1675 = ((V)("#26272b"));
D_1676 = 40D;
ZF_1677 = (D_1676 / 2D);
return NewObj(5).Put("w", ((V)(144D))).Put("d", ((V)(66D))).Put("glow", Fn((V _arrowThis1684, int _argc1678, V _a1680, V _a1681, V _a1682, V _a1683, V[] _rest1679) => {
return NewObj(2).Put("y", ((V)(18D))).Put("r", ((V)(72D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1691, int _argc1685, V _a1687, V _a1688, V _a1689, V _a1690, V[] _rest1686) => {
V o_1692 = default;
V on_1693 = default;
V PI2_1694 = default;
V SLT_1695 = default;
V ST_1696 = default;
V FR_1697 = default;
V FB_1698 = default;
V CR_1699 = default;
V SH5_1700 = default;
V LA_1701 = default;
V LB_1702 = default;
V LC_1703 = default;
V MP_1704 = default;
V RT_1705 = default;
V MF_1706 = default;
V VS_1707 = default;
V CL_1708 = default;
o_1692 = Arr();
on_1693 = Call(glue_48, V.Undef, o_1692);
Invoke(o_1692, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(140D)), ((V)(3D)), ((V)(52D)), ((V)("#18191c")), NewObj(3).Put("r", ((V)(0.8))).Put("mat", ((V)("cer"))).Put("shine", ((V)(1D))).V));
PI2_1694 = Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis1716, int _argc1709, V sg_1715, V _a1712, V _a1713, V _a1714, V[] _rest1710) => {
return Call(box_11, V.Undef, ((V)((ToNum(sg_1715) * 51.5))), ((V)(3D)), ((V)(0D)), ((V)(27D)), ((V)(58D)), ((V)(D_1676)), PNT_1672, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
}, 1, "", true));
SLT_1695 = Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis1724, int _argc1717, V sg_1723, V _a1720, V _a1721, V _a1722, V[] _rest1718) => {
return Call(box_11, V.Undef, ((V)((ToNum(sg_1723) * 34D))), ((V)(3D)), ((V)(0D)), ((V)(8D)), ((V)(50D)), ((V)(D_1676)), SL_1674, NewObj(2).Put("r", ((V)(0.2))).Put("mat", ((V)("cer"))).V);
}, 1, "", true));
ST_1696 = Call(box_11, V.Undef, ((V)(0D)), ((V)(53D)), ((V)(0D)), ((V)(76D)), ((V)(8D)), ((V)(D_1676)), SL_1674, NewObj(2).Put("r", ((V)(0.2))).Put("mat", ((V)("cer"))).V);
FR_1697 = Call(box_11, V.Undef, ((V)(0D)), ((V)(61D)), ((V)(0D)), ((V)(130D)), ((V)(25D)), ((V)(D_1676)), PNT_1672, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
Invoke(Invoke(PI2_1694, "concat", SLT_1695, Arr(ST_1696, FR_1697)), "forEach", Fn((V _arrowThis1732, int _argc1725, V s_1731, V _a1728, V _a1729, V _a1730, V[] _rest1726) => {
return Invoke(o_1692, "push", s_1731);
}, 1, "", true));
FB_1698 = Call(box_11, V.Undef, ((V)(0D)), ((V)(3D)), ((V)((-18.5))), ((V)(60D)), ((V)(50D)), ((V)(3D)), ((V)("#5e3426")), NewObj(2).Put("r", ((V)(0.2))).Put("mat", ((V)("cer"))).V);
Invoke(o_1692, "push", FB_1698);
Call(on_1693, V.Undef, FB_1698, Invoke(InvokeSpread(Arr(), "concat", new ArrBuilder().Spread(Call(rep_45, V.Undef, ((V)(8D)), Fn((V _arrowThis1740, int _argc1733, V r_1739, V _a1736, V _a1737, V _a1738, V[] _rest1734) => {
return Call(rep_45, V.Undef, ((V)(7D)), Fn((V _arrowThis1748, int _argc1741, V kk_1747, V _a1744, V _a1745, V _a1746, V[] _rest1742) => {
double x0_1749 = 0;
double a_1750 = 0;
double b_1751 = 0;
x0_1749 = ((-30D) + ((ToNum(kk_1747) - ((ToNum(r_1739) % 2D) * 0.5)) * 10D));
a_1750 = Max((-29.8), (x0_1749 + 0.3));
b_1751 = Min(29.8, (x0_1749 + 9.7));
return (((b_1751 - a_1750) > 1D) ? Call(box_11, V.Undef, ((V)(((a_1750 + b_1751) / 2D))), ((V)(((3D + (ToNum(r_1739) * 6.25)) + 0.3))), ((V)((-16.98))), ((V)((b_1751 - a_1750))), ((V)(5.6)), ((V)(0.04)), GetIdx(Arr(((V)("#6a3a2a")), ((V)("#5a3022")), ((V)("#734232")), ((V)("#4e2a1e"))), (((ToNum(r_1739) * 3D) + (ToNum(kk_1747) * 5D)) % 4D)), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V) : V.Null);
return default;
}, 1, "", true));
}, 1, "", true))).V), "filter", G("Boolean")), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1693, V.Undef, FB_1698, Invoke(Call(rep_45, V.Undef, ((V)(7D)), Fn((V _arrowThis1775, int _argc1768, V r_1774, V _a1771, V _a1772, V _a1773, V[] _rest1769) => {
return Call(slabX_15, V.Undef, ((V)(0D)), ((V)((3D + (ToNum(Add(r_1774, ((V)(1D)))) * 6.25)))), ((V)((-16.95))), ((V)(59D)), ((V)(0.5)), ((V)(0.1)), ((V)("#2a1610")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)), "concat", InvokeSpread(Arr(), "concat", new ArrBuilder().Spread(Call(rep_45, V.Undef, ((V)(8D)), Fn((V _arrowThis1759, int _argc1752, V r_1758, V _a1755, V _a1756, V _a1757, V[] _rest1753) => {
return Call(rep_45, V.Undef, ((V)(5D)), Fn((V _arrowThis1767, int _argc1760, V kk_1766, V _a1763, V _a1764, V _a1765, V[] _rest1761) => {
return Call(box_11, V.Undef, ((V)(((-30D) + ((ToNum(Add(kk_1766, ((V)(1D)))) - ((ToNum(r_1758) % 2D) * 0.5)) * 10D)))), ((V)((3D + (ToNum(r_1758) * 6.25)))), ((V)((-16.95))), ((V)(0.5)), ((V)(6.25)), ((V)(0.1)), ((V)("#2a1610")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true));
}, 1, "", true))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1693, V.Undef, GetIdx(SLT_1695, 0D), Arr(Call(box_11, V.Undef, ((V)((-29.7))), ((V)(3D)), ((V)((-1D))), ((V)(0.6)), ((V)(50D)), ((V)((D_1676 - 6D))), ((V)("#3a2620")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))));
Call(on_1693, V.Undef, GetIdx(SLT_1695, 1D), Arr(Call(box_11, V.Undef, ((V)(29.7)), ((V)(3D)), ((V)((-1D))), ((V)(0.6)), ((V)(50D)), ((V)((D_1676 - 6D))), ((V)("#3a2620")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)((-1D))), ((V)(0D)), ((V)(0D))));
Call(on_1693, V.Undef, GetIdx(SLT_1695, 0D), Arr(Call(box_11, V.Undef, ((V)((-30.4))), ((V)(3D)), ((V)((ZF_1677 + 0.2))), ((V)(1.2)), ((V)(50.6)), ((V)(0.4)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1693, V.Undef, GetIdx(SLT_1695, 1D), Arr(Call(box_11, V.Undef, ((V)(30.4)), ((V)(3D)), ((V)((ZF_1677 + 0.2))), ((V)(1.2)), ((V)(50.6)), ((V)(0.4)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1693, V.Undef, ST_1696, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(52.4)), ((V)((ZF_1677 + 0.2))), ((V)(62D)), ((V)(1.2)), ((V)(0.4)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1693, V.Undef, FB_1698, Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis1783, int _argc1776, V i_1782, V _a1779, V _a1780, V _a1781, V[] _rest1777) => {
return Call(box_11, V.Undef, ((V)(0D)), ((V)((46D - (ToNum(i_1782) * 3D)))), ((V)((-16.9))), ((V)((56D - (ToNum(i_1782) * 10D)))), ((V)((7D + (ToNum(i_1782) * 3D)))), ((V)(0.05)), ((V)("#0a0605")), NewObj(3).Put("r", ((V)(3D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.28))).V);
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1792, int _argc1784, V sg_1790, V i_1791, V _a1788, V _a1789, V[] _rest1785) => {
double x_1793 = 0;
V PIL_1794 = default;
x_1793 = (ToNum(sg_1790) * 51.5);
PIL_1794 = GetIdx(Call(on_1693, V.Undef, GetK(PI2_1694, i_1791), Arr(Call(box_11, V.Undef, ((V)(x_1793)), ((V)(3D)), ((V)((ZF_1677 + 0.9))), ((V)(18D)), ((V)(52D)), ((V)(1.8)), PNT_1672, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_1693, V.Undef, PIL_1794, Call(rep_45, V.Undef, ((V)(4D)), Fn((V _arrowThis1802, int _argc1795, V kk_1801, V _a1798, V _a1799, V _a1800, V[] _rest1796) => {
return Call(cyl_12, V.Undef, ((V)((x_1793 + ((ToNum(kk_1801) - 1.5) * 3.6)))), ((V)(11D)), ((V)((ZF_1677 + 1.8))), ((V)(0.8)), ((V)(42D)), Call(shade_21, V.Undef, PNT_1672, ((V)(0.84))), NewObj(2).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_1693, V.Undef, GetK(PI2_1694, i_1791), Arr(Call(box_11, V.Undef, ((V)(x_1793)), ((V)(3D)), ((V)((ZF_1677 + 1.1))), ((V)(21D)), ((V)(6D)), ((V)(2.2)), PL2_1673, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_11, V.Undef, ((V)(x_1793)), ((V)(55D)), ((V)((ZF_1677 + 1.1))), ((V)(21D)), ((V)(6D)), ((V)(2.2)), PL2_1673, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(slabX_15, V.Undef, ((V)(x_1793)), ((V)(5.8)), ((V)((ZF_1677 + 2.35))), ((V)(20D)), ((V)(0.3)), ((V)(0.1)), Call(shade_21, V.Undef, PNT_1672, ((V)(0.8))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(disc_17, V.Undef, ((V)((x_1793 - 8D))), ((V)(58D)), ((V)((ZF_1677 + 3.3))), ((V)(1.6)), ((V)(0.6)), PL2_1673, NewObj(1).Put("n", ((V)(12D))).V), Call(disc_17, V.Undef, ((V)((x_1793 + 8D))), ((V)(58D)), ((V)((ZF_1677 + 3.3))), ((V)(1.6)), ((V)(0.6)), PL2_1673, NewObj(1).Put("n", ((V)(12D))).V), Call(disc_17, V.Undef, ((V)((x_1793 - 8D))), ((V)(58D)), ((V)((ZF_1677 + 3.9))), ((V)(0.7)), ((V)(0.2)), Call(shade_21, V.Undef, PNT_1672, ((V)(0.8))), NewObj(2).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V), Call(disc_17, V.Undef, ((V)((x_1793 + 8D))), ((V)(58D)), ((V)((ZF_1677 + 3.9))), ((V)(0.7)), ((V)(0.2)), Call(shade_21, V.Undef, PNT_1672, ((V)(0.8))), NewObj(2).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V)));
Call(on_1693, V.Undef, FR_1697, Arr(Call(box_11, V.Undef, ((V)(x_1793)), ((V)(61D)), ((V)((ZF_1677 + 1D))), ((V)(21D)), ((V)(25D)), ((V)(2D)), PNT_1672, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(disc_17, V.Undef, ((V)(x_1793)), ((V)(73.5)), ((V)((ZF_1677 + 2D))), ((V)(4.5)), ((V)(1D)), PL2_1673, NewObj(1).Put("n", ((V)(16D))).V), Call(disc_17, V.Undef, ((V)(x_1793)), ((V)(73.5)), ((V)((ZF_1677 + 3D))), ((V)(1.8)), ((V)(0.6)), Call(shade_21, V.Undef, PNT_1672, ((V)(0.9))), NewObj(2).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).V)));
return default;
}, 2, "", true));
Call(on_1693, V.Undef, FR_1697, Arr(Call(disc_17, V.Undef, ((V)(0D)), ((V)(73.5)), ((V)(ZF_1677)), ((V)(18D)), ((V)(0.9)), PL2_1673, NewObj(3).Put("a", ((V)(20D))).Put("b", ((V)(7.5))).Put("n", ((V)(28D))).V), Call(disc_17, V.Undef, ((V)(0D)), ((V)(73.5)), ((V)((ZF_1677 + 0.9))), ((V)(15D)), ((V)(0.3)), Call(shade_21, V.Undef, PNT_1672, ((V)(0.93))), NewObj(4).Put("a", ((V)(15D))).Put("b", ((V)(4.6))).Put("n", ((V)(24D))).Put("noOut", ((V)(1D))).V)));
CR_1699 = Call(box_11, V.Undef, ((V)(0D)), ((V)(86D)), ((V)(1D)), ((V)(134D)), ((V)(2D)), ((V)((D_1676 + 2D))), PNT_1672, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V));
Invoke(o_1692, "push", CR_1699);
Call(on_1693, V.Undef, CR_1699, Call(rep_45, V.Undef, ((V)(26D)), Fn((V _arrowThis1810, int _argc1803, V i_1809, V _a1806, V _a1807, V _a1808, V[] _rest1804) => {
return Call(box_11, V.Undef, ((V)(((-62.5) + (ToNum(i_1809) * 5D)))), ((V)(86.2)), ((V)(22.3)), ((V)(2.6)), ((V)(1.6)), ((V)(0.6)), PL2_1673, NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
SH5_1700 = Call(box_11, V.Undef, ((V)(0D)), ((V)(88D)), ((V)(2D)), ((V)(140D)), ((V)(4D)), ((V)((D_1676 + 6D))), PL2_1673, Call(PL_42, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V));
Invoke(o_1692, "push", SH5_1700);
Call(on_1693, V.Undef, SH5_1700, Arr(Call(slabX_15, V.Undef, ((V)(0D)), ((V)(89.2)), ((V)(25.05)), ((V)(139D)), ((V)(0.3)), ((V)(0.1)), Call(shade_21, V.Undef, PNT_1672, ((V)(0.82))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(slabX_15, V.Undef, ((V)(0D)), ((V)(90.8)), ((V)(25.05)), ((V)(139D)), ((V)(0.25)), ((V)(0.1)), ((V)("#ffffff")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(o_1692, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(32D)), ((V)(0.4)), ((V)(18D)), ((V)("#ff7a2a")), Call(em_44, V.Undef, NewObj(2).Put("op", ((V)(0.55))).Put("r", ((V)(2D))).V)));
Invoke(Arr(((V)((-18D))), ((V)(18D))), "forEach", Fn((V _arrowThis1818, int _argc1811, V x_1817, V _a1814, V _a1815, V _a1816, V[] _rest1812) => {
Invoke(o_1692, "push", Call(rod_33, V.Undef, Arr(x_1817, ((V)(6D)), ((V)((-11D)))), Arr(x_1817, ((V)(6D)), ((V)(11D))), ((V)(0.8)), IRN_1675, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
Invoke(Arr(((V)((-10D))), ((V)(10D))), "forEach", Fn((V _arrowThis1826, int _argc1819, V z_1825, V _a1822, V _a1823, V _a1824, V[] _rest1820) => {
return Invoke(o_1692, "push", Call(rod_33, V.Undef, Arr(x_1817, ((V)(3D)), z_1825), Arr(x_1817, ((V)(5.2)), z_1825), ((V)(0.7)), IRN_1675, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-8D))), ((V)(8D))), "forEach", Fn((V _arrowThis1834, int _argc1827, V z_1833, V _a1830, V _a1831, V _a1832, V[] _rest1828) => {
return Invoke(o_1692, "push", Call(rod_33, V.Undef, Arr(((V)((-20D))), ((V)(7.6)), z_1833), Arr(((V)(20D)), ((V)(7.6)), z_1833), ((V)(0.8)), IRN_1675, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
LA_1701 = Call(rod_33, V.Undef, Arr(((V)((-20D))), ((V)(11D)), ((V)(6D))), Arr(((V)(20D)), ((V)(11D)), ((V)(6D))), ((V)(2.6)), ((V)("#6a5442")), NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("cer"))).V);
LB_1702 = Call(rod_33, V.Undef, Arr(((V)((-18D))), ((V)(11.2)), ((V)((-6D)))), Arr(((V)(19D)), ((V)(11.6)), ((V)((-6D)))), ((V)(2.8)), ((V)("#5e4a3a")), NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("cer"))).V);
LC_1703 = Call(rod_33, V.Undef, Arr(((V)((-12D))), ((V)(16.6)), ((V)((-4D)))), Arr(((V)(14D)), ((V)(16D)), ((V)(3D))), ((V)(2.2)), ((V)("#725a46")), NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("cer"))).V);
Invoke(o_1692, "push", LA_1701, LB_1702, LC_1703);
Call(on_1693, V.Undef, LA_1701, Arr(Call(solid_20, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(6D)), ((V)(11D)))).Put("a", ((V)(2.2))).Put("b", ((V)(2.2))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)(20D)), ((V)(0D))), Arr(((V)(20.15)), ((V)(0D))))).Put("col", ((V)("#2a1a12"))).Put("noOut", ((V)(1D))).V), Call(ball_13, V.Undef, ((V)((-6D))), ((V)(13.3)), ((V)(7.4)), ((V)(1.8)), ((V)("#ff8a3a")), Call(em_44, V.Undef, NewObj(3).Put("sy", ((V)(0.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)), Call(ball_13, V.Undef, ((V)(8D)), ((V)(13.2)), ((V)(7.6)), ((V)(1.4)), ((V)("#ff8a3a")), Call(em_44, V.Undef, NewObj(3).Put("sy", ((V)(0.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V))));
MP_1704 = Arr(((V)(0D)), ((V)(92D)), ((V)((-16D))));
RT_1705 = Call(rotF_32, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.06))));
MF_1706 = Call(tilt_30, V.Undef, Call(box_11, V.Undef, ((V)(0D)), ((V)(92D)), ((V)((-17D))), ((V)(46D)), ((V)(40D)), ((V)(2D)), ((V)("#c9a04a")), Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.06))), MP_1704);
Invoke(o_1692, "push", MF_1706);
Call(on_1693, V.Undef, MF_1706, Arr(Call(tilt_30, V.Undef, Call(box_11, V.Undef, ((V)(0D)), ((V)(95D)), ((V)((-15.95))), ((V)(40D)), ((V)(34D)), ((V)(0.1)), ((V)("#cfe3ea")), NewObj(3).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).Put("shine", ((V)(1D))).V), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.06))), MP_1704)), Call(RT_1705, V.Undef, Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))));
Invoke(Arr(((V)((-54D))), ((V)(54D))), "forEach", Fn((V _arrowThis1842, int _argc1835, V x_1841, V _a1838, V _a1839, V _a1840, V[] _rest1836) => {
Invoke(o_1692, "push", Call(cyl_12, V.Undef, x_1841, ((V)(92D)), ((V)(6D)), ((V)(3.4)), ((V)(1.4)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_12, V.Undef, x_1841, ((V)(93.4)), ((V)(6D)), ((V)(1.2)), ((V)(10D)), BR_29, Call(M__40, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.4))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(7D)), ((V)(0D)), ((V)(1D))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.8))))).V)), Call(cyl_12, V.Undef, x_1841, ((V)(103.4)), ((V)(6D)), ((V)(2.2)), ((V)(1.6)), BR_29, Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_12, V.Undef, x_1841, ((V)(105D)), ((V)(6D)), ((V)(1.4)), ((V)(12D)), ((V)("#f8f2e4")), NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("cer"))).V), Call(rod_33, V.Undef, Arr(x_1841, ((V)(117D)), ((V)(6D))), Arr(x_1841, ((V)(118.2)), ((V)(6D))), ((V)(0.18)), ((V)("#2a2020")), NewObj(1).Put("n", ((V)(4D))).V));
return default;
}, 1, "", true));
VS_1707 = Call(cyl_12, V.Undef, ((V)((-32D))), ((V)(92D)), ((V)(4D)), ((V)(4D)), ((V)(12D)), ((V)("#e9e4da")), NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(12D)), ((V)(0D)), ((V)(0.7))))).V);
Invoke(o_1692, "push", VS_1707);
Call(rep_45, V.Undef, ((V)(4D)), Fn((V _arrowThis1850, int _argc1843, V i_1849, V _a1846, V _a1847, V _a1848, V[] _rest1844) => {
double a_1851 = 0;
V tp_1852 = default;
a_1851 = ((-0.6) + (ToNum(i_1849) * 0.4));
tp_1852 = Arr(((V)(((-32D) + (FdLibm.Sin(a_1851) * 9D)))), ((V)((116D + ((ToNum(i_1849) % 2D) * 3D)))), ((V)((4D + (NumTruthy((ToNum(i_1849) % 2D)) ? 2D : (-2D))))));
Call(on_1693, V.Undef, VS_1707, Arr(Call(rod_33, V.Undef, Arr(((V)((-32D))), ((V)(103D)), ((V)(4D))), tp_1852, ((V)(0.3)), ((V)("#6a7a5a")), NewObj(1).Put("n", ((V)(4D))).V)));
Call(rep_45, V.Undef, ((V)(3D)), Fn((V _arrowThis1860, int _argc1853, V j_1859, V _a1856, V _a1857, V _a1858, V[] _rest1854) => {
double t_1861 = 0;
t_1861 = (0.45 + (ToNum(j_1859) * 0.25));
Call(on_1693, V.Undef, VS_1707, Arr(Call(ball_13, V.Undef, ((V)((((-32D) + (ToNum(Add(GetIdx(tp_1852, 0D), ((V)(32D)))) * t_1861)) + (NumTruthy((ToNum(j_1859) % 2D)) ? 1.4 : (-1.4))))), ((V)((103D + ((ToNum(GetIdx(tp_1852, 1D)) - 103D) * t_1861)))), ((V)((4D + ((ToNum(GetIdx(tp_1852, 2D)) - 4D) * t_1861)))), ((V)(1.3)), ((V)("#9fb5a0")), NewObj(3).Put("sz", ((V)(0.35))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)("#2b3f7a")), ((V)(20D)), ((V)(2.8))), Arr(((V)("#e9dfcc")), ((V)(18D)), ((V)(2.4)))), "reduce", Fn((V _arrowThis1876, int _argc1862, V yy_1868, V _a1865, V _a1866, V _a1867, V[] _rest1863) => {
V col_1871 = default;
V w_1873 = default;
V h_1875 = default;
{ V _t1869 = ListOf(_a1865);
{ V _t1870 = GetIdx(_t1869, 0D);
col_1871 = _t1870; }
{ V _t1872 = GetIdx(_t1869, 1D);
w_1873 = _t1872; }
{ V _t1874 = GetIdx(_t1869, 2D);
h_1875 = _t1874; }
}
Invoke(Call(book_53, V.Undef, ((V)(32D)), yy_1868, ((V)(6D)), w_1873, h_1875, ((V)(13D)), col_1871, ((V)(0.05))), "forEach", Fn((V _arrowThis1884, int _argc1877, V s_1883, V _a1880, V _a1881, V _a1882, V[] _rest1878) => {
return Invoke(o_1692, "push", s_1883);
}, 1, "", true));
return Add(yy_1868, h_1875);
return default;
}, 2, "", true), ((V)(92D)));
CL_1708 = Call(box_11, V.Undef, ((V)(32D)), ((V)(97.2)), ((V)(6D)), ((V)(6D)), ((V)(7D)), ((V)(4D)), BR_29, Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("shine", ((V)(1D))).V));
Invoke(o_1692, "push", CL_1708);
Call(on_1693, V.Undef, CL_1708, Arr(Call(disc_17, V.Undef, ((V)(32D)), ((V)(101.2)), ((V)(8.05)), ((V)(2.2)), ((V)(0.1)), ((V)("#f6f0e2")), NewObj(2).Put("n", ((V)(14D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return o_1692;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1892, int _argc1885, V c_1891, V _a1888, V _a1889, V _a1890, V[] _rest1886) => {
V @out_1893 = default;
V k_1894 = default;
V F_1895 = default;
V ib_1896 = default;
JsStrBuf g_1897 = null;
V RT_1898 = default;
V MO_1899 = default;
@out_1893 = NewObj(2).Put("defs", ((V)(""))).Put("front", ((V)(""))).V;
k_1894 = Get(c_1891, "k");
if (LtN(Call(face_59, V.Undef, c_1891, ((V)(0D)), ((V)(1D))), 0.05)) {
return @out_1893;
}
F_1895 = Call(fireIn_62, V.Undef, c_1891, ((V)("q23mf")), Arr(Arr(((V)((-30D))), ((V)(3D)), ((V)(ZF_1677))), Arr(((V)(30D)), ((V)(3D)), ((V)(ZF_1677))), Arr(((V)(30D)), ((V)(53D)), ((V)(ZF_1677))), Arr(((V)((-30D))), ((V)(53D)), ((V)(ZF_1677)))), Arr(Arr(((V)((-12D))), ((V)(12.6)), ((V)(6D)), ((V)(0.7))), Arr(((V)(0D)), ((V)(13.6)), ((V)(4D)), ((V)(0.85))), Arr(((V)(12D)), ((V)(12.6)), ((V)(6D)), ((V)(0.7))), Arr(((V)((-5D))), ((V)(18D)), ((V)((-3D))), ((V)(0.6))), Arr(((V)(6D)), ((V)(18D)), ((V)((-2D))), ((V)(0.62)))));
ib_1896 = Invoke(c_1891, "p", ((V)(0D)), ((V)(18D)), ((V)((-4D))));
g_1897 = new JsStrBuf(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(ib_1896, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(ib_1896, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((30D * ToNum(k_1894)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((22D * ToNum(k_1894)))))).S("\" fill=\"url(#q23mi)\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.5;0.85;0.6;0.8;0.5")), ((V)(2.4)))).S("</ellipse>").End());
Invoke(Arr(Arr(((V)((-12D))), ((V)(6D))), Arr(((V)(0D)), ((V)(5D))), Arr(((V)(12D)), ((V)(6D)))), "forEach", Fn((V _arrowThis1912, int _argc1900, V _a1902, V i_1906, V _a1904, V _a1905, V[] _rest1901) => {
V q_1913 = default;
V x_1909 = default;
V z_1911 = default;
{ V _t1907 = ListOf(_a1902);
{ V _t1908 = GetIdx(_t1907, 0D);
x_1909 = _t1908; }
{ V _t1910 = GetIdx(_t1907, 1D);
z_1911 = _t1910; }
}
q_1913 = Invoke(c_1891, "p", x_1909, ((V)(10.6)), Add(z_1911, ((V)(2.4))));
g_1897.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_1913, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_1913, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((5D * ToNum(k_1894)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((1.4 * ToNum(k_1894)))))).S("\" fill=\"#5aa8ff\" opacity=\"0.6\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.35;0.75;0.45;0.7;0.35")), Call(n4_58, V.Undef, ((V)((1.1 + (ToNum(i_1906) * 0.2))))), Call(n4_58, V.Undef, ((V)(((-ToNum(i_1906)) * 0.3)))))).S("</ellipse>");
return default;
}, 2, "", true));
OpSet(@out_1893, "defs", 0, ((V)(JsStrBuf.Begin().V(Add(Add(Get(F_1895, "defs"), Call(RG_50, V.Undef, ((V)("q23mi")), ((V)("#ffb05a")), ((V)("#ff6a2a")), ((V)(0.45)))), Call(RG_50, V.Undef, ((V)("q23mc")), ((V)("#fff3b0")), ((V)("#ffb347")), ((V)(0.8))))).S("<pattern id=\"q23mm\" width=\"2\" height=\"2\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 0L2 2M2 0L0 2\" stroke=\"#1d1e21\" stroke-width=\"0.25\"/></pattern>").End())));
OpSet(@out_1893, "front", 0, ((V)(JsStrBuf.Begin().S("<g clip-path=\"url(#q23mf)\">").S(g_1897.Str).V(Get(F_1895, "g")).S("</g>").End())));
Invoke(Arr(((V)((-54D))), ((V)(54D))), "forEach", Fn((V _arrowThis1922, int _argc1914, V x_1920, V i_1921, V _a1918, V _a1919, V[] _rest1915) => {
V q_1923 = default;
q_1923 = Invoke(c_1891, "p", x_1920, ((V)(120.2)), ((V)(6D)));
OpSet(@out_1893, "front", 0, ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_57, V.Undef, q_1923)).S(") scale(").V(Call(f1_23, V.Undef, k_1894)).S(")\"><ellipse cy=\"-1.2\" rx=\"3.2\" ry=\"3.8\" fill=\"url(#q23mc)\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.4;0.8;0.5;0.75;0.4")), ((V)(1.5)), Call(n4_58, V.Undef, ((V)(((-ToNum(i_1921)) * 0.5)))))).S("</ellipse><path d=\"M0 -3.4Q1.5 -1 0.4 0.6Q-1.3 0 0 -3.4Z\" fill=\"#ffcf4a\" stroke=\"#ff8a2a\" stroke-width=\"0.2\"><animateTransform attributeName=\"transform\" type=\"skewX\" values=\"0;7;-5;4;0\" dur=\"1.4s\" begin=\"").V(Call(n4_58, V.Undef, ((V)(((-ToNum(i_1921)) * 0.4))))).S("s\" repeatCount=\"indefinite\"/></path></g>").End())));
return default;
}, 2, "", true));
RT_1898 = Call(rotF_32, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.06))));
MO_1899 = Call(rp_49, V.Undef, RT_1898, Arr(((V)(0D)), ((V)(92D)), ((V)((-16D)))), Arr(((V)((-20D))), ((V)(129D)), ((V)((-15.85)))));
OpSet(@out_1893, "front", 0, ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(frame_36, V.Undef, Get(c_1891, "p"), MO_1899, Call(RT_1898, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D)))), Call(RT_1898, V.Undef, Arr(((V)(0D)), ((V)((-1D))), ((V)(0D)))))).S("\"><clipPath id=\"q23mr\"><rect width=\"40\" height=\"34\" rx=\"0.4\"/></clipPath><g clip-path=\"url(#q23mr)\"><rect x=\"-30\" width=\"14\" height=\"34\" fill=\"#ffffff\" opacity=\"0.35\" transform=\"skewX(-20)\">").V(Call(an_37, V.Undef, ((V)("x")), ((V)("-30;70;70")), ((V)(11D)))).S("</rect></g></g>").End())));
if (GtN(Call(face_59, V.Undef, c_1891, ((V)(0D)), ((V)(1D))), 0.3)) {
OpSet(@out_1893, "front", 0, ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(frame_36, V.Undef, Get(c_1891, "p"), Arr(((V)((-30D))), ((V)(34D)), ((V)(27D))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))).S("\"><path d=\"M0 31V6Q30 -3 60 6V31Z\" fill=\"url(#q23mm)\" stroke=\"#b8862e\" stroke-width=\"1.2\"/><path d=\"M0 31V6Q30 -3 60 6V31Z\" fill=\"#000000\" opacity=\"0.12\"/><path d=\"M-1 31H4M56 31H61\" stroke=\"#b8862e\" stroke-width=\"1.6\" stroke-linecap=\"round\"/><circle cx=\"30\" cy=\"0.6\" r=\"1.4\" fill=\"#d4a548\"/></g>").End())));
}
return @out_1893;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_25, "susp23", Fn((V _arrowThis1931, int _argc1924, V S_1930, V _a1927, V _a1928, V _a1929, V[] _rest1925) => {
V BK_1932 = default;
double OY_1933 = 0;
double OA_1934 = 0;
double OB_1935 = 0;
double OZ_1936 = 0;
BK_1932 = ((V)("#2a2b2e"));
OY_1933 = 42D;
OA_1934 = 14D;
OB_1935 = 10D;
OZ_1936 = 28.95;
return NewObj(5).Put("w", ((V)(132D))).Put("d", ((V)(84D))).Put("glow", Fn((V _arrowThis1943, int _argc1937, V _a1939, V _a1940, V _a1941, V _a1942, V[] _rest1938) => {
return NewObj(2).Put("y", ((V)(34D))).Put("r", ((V)(74D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1950, int _argc1944, V _a1946, V _a1947, V _a1948, V _a1949, V[] _rest1945) => {
V o_1951 = default;
V on_1952 = default;
V PLT_1953 = default;
V BW_1954 = default;
V ST_1955 = default;
o_1951 = Arr();
on_1952 = Call(glue_48, V.Undef, o_1951);
PLT_1953 = Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(34D)), ((V)(2.4)), ((V)("#3a3c40")), NewObj(3).Put("n", ((V)(32D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.98))), Arr(((V)(2.4)), ((V)(0D)), ((V)(1D))))).V);
Invoke(o_1951, "push", PLT_1953);
Call(on_1952, V.Undef, PLT_1953, Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(2.4)), ((V)(0D)), ((V)(30D)), ((V)(0.3)), ((V)("#55585e")), NewObj(3).Put("n", ((V)(30D))).Put("mat", ((V)("cer"))).Put("noOut", ((V)(1D))).V), Call(band_46, V.Undef, ((V)(0D)), ((V)(0.6)), ((V)(0D)), ((V)(34.05)), ((V)(1.2)), ((V)("#8a8f96")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(30D))).V))));
BW_1954 = Invoke(Get(RD_8, "H16"), "loft", Arr(Arr(((V)(22D)), ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(6D))), Arr(((V)(24D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(14D))), Arr(((V)(28D)), ((V)(0D)), ((V)(0D)), ((V)(21D)), ((V)(21D))), Arr(((V)(34D)), ((V)(0D)), ((V)(0D)), ((V)(26D)), ((V)(26D))), Arr(((V)(42D)), ((V)(0D)), ((V)(0D)), ((V)(27D)), ((V)(27D))), Arr(((V)(50D)), ((V)(0D)), ((V)(0D)), ((V)(25D)), ((V)(25D))), Arr(((V)(58D)), ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(20D))), Arr(((V)(64D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(14D))), Arr(((V)(68D)), ((V)(0D)), ((V)(0D)), ((V)(8D)), ((V)(8D)))), BK_1932, NewObj(3).Put("n", ((V)(32D))).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V);
Invoke(o_1951, "push", BW_1954);
Call(on_1952, V.Undef, BW_1954, Arr(Call(band_46, V.Undef, ((V)(0D)), ((V)(30.6)), ((V)(0D)), ((V)(23.9)), ((V)(0.5)), ((V)("#3e4046")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(30D))).V)), Call(band_46, V.Undef, ((V)(0D)), ((V)(53.5)), ((V)(0D)), ((V)(23.4)), ((V)(0.5)), ((V)("#3e4046")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(30D))).V))));
Call(on_1952, V.Undef, PLT_1953, Call(rep_45, V.Undef, ((V)(16D)), Fn((V _arrowThis1963, int _argc1956, V i_1962, V _a1959, V _a1960, V _a1961, V[] _rest1957) => {
double a_1964 = 0;
a_1964 = (((ToNum(i_1962) / 16D) * 2D) * PI_26);
return Call(ball_13, V.Undef, ((V)((FdLibm.Cos(a_1964) * 32.4))), ((V)(2.45)), ((V)((FdLibm.Sin(a_1964) * 32.4))), ((V)(0.6)), ((V)("#8a8f96")), Call(M__40, V.Undef, NewObj(4).Put("sy", ((V)(0.4))).Put("k", ((V)(2D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V));
return default;
}, 1, "", true)));
ST_1955 = GetIdx(Call(on_1952, V.Undef, BW_1954, Arr(Call(solid_20, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(OY_1933)))).Put("a", ((V)(15.5))).Put("b", ((V)(11.5))).Put("n", ((V)(28D))).Put("rings", Arr(Arr(((V)(18D)), ((V)(0D))), Arr(((V)(28D)), ((V)(0D))))).Put("col", BK_1932).Put("mat", ((V)("metal"))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_1952, V.Undef, ST_1955, Arr(Call(solid_20, V.Undef, NewObj(10).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(OY_1933)))).Put("a", ((V)(16.4))).Put("b", ((V)(12.4))).Put("n", ((V)(28D))).Put("rings", Arr(Arr(((V)(27.6)), ((V)(0D))), Arr(((V)(28.8)), ((V)(0D))))).Put("col", ((V)("#3a3b40"))).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V), Call(disc_17, V.Undef, ((V)(0D)), ((V)(OY_1933)), ((V)(28.8)), ((V)(OA_1934)), ((V)(0.15)), ((V)("#120d0a")), NewObj(4).Put("a", ((V)(OA_1934))).Put("b", ((V)(OB_1935))).Put("n", ((V)(28D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(o_1951, "push", Call(cyl_12, V.Undef, ((V)(0D)), ((V)(68D)), ((V)(0D)), ((V)(5.4)), ((V)(118D)), BK_1932, Call(M__40, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(186D)), ((V)(0D)), ((V)(9D)), ((V)(4D)), ((V)("#3a3b40")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
Call(on_1952, V.Undef, GetIdx(o_1951, (ToNum(Get(o_1951, "length")) - 2D)), Arr(Call(band_46, V.Undef, ((V)(0D)), ((V)(92D)), ((V)(0D)), ((V)(5.45)), ((V)(1D)), ((V)("#3a3b40")), Call(M__40, V.Undef, NewObj(1).Put("n", ((V)(16D))).V))));
Invoke(Arr(((V)((-12D))), ((V)(10D))), "forEach", Fn((V _arrowThis1972, int _argc1965, V z_1971, V _a1968, V _a1969, V _a1970, V[] _rest1966) => {
return Invoke(o_1951, "push", Call(box_11, V.Undef, ((V)(50D)), ((V)(0D)), z_1971, ((V)(26.4)), ((V)(1.2)), ((V)(1.4)), BK_1932, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
}, 1, "", true));
Invoke(Arr(((V)(37.4)), ((V)(62.6))), "forEach", Fn((V _arrowThis1980, int _argc1973, V x_1979, V _a1976, V _a1977, V _a1978, V[] _rest1974) => {
return Invoke(Arr(((V)((-12D))), ((V)(10D))), "forEach", Fn((V _arrowThis1988, int _argc1981, V z_1987, V _a1984, V _a1985, V _a1986, V[] _rest1982) => {
return Invoke(o_1951, "push", Call(box_11, V.Undef, x_1979, ((V)(1.2)), z_1987, ((V)(1.2)), ((V)(15D)), ((V)(1.4)), BK_1932, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(Arr(((V)(42.4)), ((V)(5D))), Arr(((V)(50D)), ((V)(5D))), Arr(((V)(57.6)), ((V)(5D))), Arr(((V)(46.2)), ((V)(11.58))), Arr(((V)(53.8)), ((V)(11.58))), Arr(((V)(50D)), ((V)(18.16)))), "forEach", Fn((V _arrowThis2001, int _argc1989, V _a1991, V i_1995, V _a1993, V _a1994, V[] _rest1990) => {
V LG_2002 = default;
V x_1998 = default;
V y_2000 = default;
{ V _t1996 = ListOf(_a1991);
{ V _t1997 = GetIdx(_t1996, 0D);
x_1998 = _t1997; }
{ V _t1999 = GetIdx(_t1996, 1D);
y_2000 = _t1999; }
}
LG_2002 = Call(solid_20, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(x_1998, y_2000)).Put("a", ((V)(3.8))).Put("b", ((V)(3.6))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((-13D))), ((V)(0D))), Arr(((V)(11D)), ((V)(0D))))).Put("col", ((V)((NumTruthy((ToNum(i_1995) % 2D)) ? "#7a5234" : "#8a5a34")))).Put("mat", ((V)("wood"))).V);
Invoke(o_1951, "push", LG_2002);
Call(on_1952, V.Undef, LG_2002, Arr(Call(disc_17, V.Undef, x_1998, y_2000, ((V)(11D)), ((V)(3.2)), ((V)(0.3)), ((V)("#d9b48a")), Call(W__39, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V)), Call(disc_17, V.Undef, x_1998, y_2000, ((V)(11.3)), ((V)(1.8)), ((V)(0.08)), ((V)("#b88a5a")), NewObj(2).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).V), Call(disc_17, V.Undef, x_1998, y_2000, ((V)(11.38)), ((V)(0.6)), ((V)(0.06)), ((V)("#8a5a34")), NewObj(2).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 2, "", true));
return o_1951;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis2010, int _argc2003, V c_2009, V _a2006, V _a2007, V _a2008, V[] _rest2004) => {
V k_2011 = default;
V @out_2012 = default;
V EP_2013 = default;
V q_2014 = default;
V F_2015 = default;
V hc_2016 = default;
k_2011 = Get(c_2009, "k");
@out_2012 = NewObj(2).Put("defs", Add(Call(RG_50, V.Undef, ((V)("q23sh")), ((V)("#ffcf6a")), ((V)("#ff7a22")), ((V)(0.95))), Call(RG_50, V.Undef, ((V)("q23sp")), ((V)("#ffb05a")), ((V)("#ff7a2a")), ((V)(0.45))))).Put("front", ((V)(""))).V;
OpSet(@out_2012, "front", 0, Call(fxEll_35, V.Undef, c_2009, ((V)(0D)), ((V)(2.8)), ((V)(14D)), ((V)(20D)), ((V)("url(#q23sp)")), Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.4;0.8;0.5;0.75;0.4")), ((V)(1.8)))));
if (LtN(Call(face_59, V.Undef, c_2009, ((V)(0D)), ((V)(1D))), 0.05)) {
return @out_2012;
}
EP_2013 = Call(rep_45, V.Undef, ((V)(28D)), Fn((V _arrowThis2024, int _argc2017, V i_2023, V _a2020, V _a2021, V _a2022, V[] _rest2018) => {
double t_2025 = 0;
t_2025 = (((ToNum(i_2023) / 28D) * 2D) * PI_26);
return Arr(((V)((FdLibm.Cos(t_2025) * OA_1934))), ((V)((OY_1933 + (FdLibm.Sin(t_2025) * OB_1935)))), ((V)(OZ_1936)));
return default;
}, 1, "", true));
q_2014 = Invoke(c_2009, "p", ((V)(0D)), ((V)((OY_1933 - 6D))), ((V)(24D)));
F_2015 = Invoke(Get(RD_8, "H"), "fire", c_2009, Arr(Arr(((V)((-3.4))), ((V)((OY_1933 - 6.4))), ((V)(23D)), ((V)(0.5))), Arr(((V)(3.6)), ((V)((OY_1933 - 6D))), ((V)(23.4)), ((V)(0.44)))));
OpSet(@out_2012, "defs", 0, ((V)(JsStrBuf.Begin().S("<clipPath id=\"q23so\"><path d=\"").V(Call(qd_61, V.Undef, c_2009, EP_2013)).S("\"/></clipPath>").V(Call(RG_50, V.Undef, ((V)("q23ht2")), ((V)("#c98a4a")), ((V)("#6a4a8a")), ((V)(0.4)))).End())));
hc_2016 = Invoke(c_2009, "p", ((V)(0D)), ((V)(OY_1933)), ((V)(29D)));
Set(@out_2012, "front", ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(hc_2016, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(hc_2016, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((24D * ToNum(k_2011)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((19D * ToNum(k_2011)))))).S("\" fill=\"url(#q23ht2)\" opacity=\"0.55\"/>").V(Get(@out_2012, "front")).End())));
OpSet(@out_2012, "front", 0, ((V)(JsStrBuf.Begin().S("<g clip-path=\"url(#q23so)\"><ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_2014, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_2014, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((13D * ToNum(k_2011)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((6D * ToNum(k_2011)))))).S("\" fill=\"url(#q23sh)\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.75;0.95;0.6")), ((V)(1.8)))).S("</ellipse><ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_2014, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, Add(GetIdx(q_2014, 1D), ((V)((2.6 * ToNum(k_2011))))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((11D * ToNum(k_2011)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((2.6 * ToNum(k_2011)))))).S("\" fill=\"#8a8580\"/><ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_2014, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, Add(GetIdx(q_2014, 1D), ((V)((2D * ToNum(k_2011))))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((8D * ToNum(k_2011)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((1.4 * ToNum(k_2011)))))).S("\" fill=\"#ff7a2a\" opacity=\"0.6\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.3;0.7;0.4")), ((V)(1.3)))).S("</ellipse>").S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_2014, 0D)) - (9D * ToNum(k_2011))))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_2014, 1D)) - (1.4 * ToNum(k_2011))))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((18D * ToNum(k_2011)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((2.6 * ToNum(k_2011)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1.3 * ToNum(k_2011)))))).S("\" fill=\"#5a3418\" transform=\"rotate(-6 ").V(Call(P2_57, V.Undef, q_2014)).S(")\"/><rect x=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_2014, 0D)) - (8D * ToNum(k_2011))))))).S("\" y=\"").V(Call(f1_23, V.Undef, Add(GetIdx(q_2014, 1D), ((V)((0.2 * ToNum(k_2011))))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((16D * ToNum(k_2011)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(k_2011)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1.2 * ToNum(k_2011)))))).S("\" fill=\"#6a3e1e\" transform=\"rotate(8 ").V(Call(P2_57, V.Undef, q_2014)).S(")\"/>").V(Get(F_2015, "over")).S("</g>").End())));
Call(rep_45, V.Undef, ((V)(4D)), Fn((V _arrowThis2033, int _argc2026, V i_2032, V _a2029, V _a2030, V _a2031, V[] _rest2027) => {
V a_2034 = default;
V b_2035 = default;
double dx_2036 = 0;
a_2034 = Invoke(c_2009, "p", ((V)(((-2D) + (ToNum(i_2032) * 1.4)))), ((V)((OY_1933 + 6D))), ((V)((OZ_1936 + 1D))));
b_2035 = Call(n4_58, V.Undef, ((V)(((-ToNum(i_2032)) * 0.9))));
dx_2036 = (((NumTruthy((ToNum(i_2032) % 2D)) ? 1D : (-1D)) * 5D) * ToNum(k_2011));
OpSet(@out_2012, "front", 0, ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(a_2034, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(a_2034, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.45 * ToNum(k_2011)))))).S("\" fill=\"#ffd66b\" opacity=\"0\">").V(Call(an_37, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(a_2034, 1D))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(a_2034, 1D)) - (26D * ToNum(k_2011))))))).End())), ((V)(2.6)), b_2035)).V(Call(an_37, V.Undef, ((V)("cx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(a_2034, 0D))).S(";").V(Call(f1_23, V.Undef, Add(GetIdx(a_2034, 0D), ((V)(dx_2036))))).End())), ((V)(2.6)), b_2035)).V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0;1;0")), ((V)(2.6)), b_2035)).S("</circle>").End())));
return default;
}, 1, "", true));
return @out_2012;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_25, "etha23", Fn((V _arrowThis2044, int _argc2037, V S_2043, V _a2040, V _a2041, V _a2042, V[] _rest2038) => {
V ST_2045 = default;
V GL_2046 = default;
double W_2047 = 0;
double D_2048 = 0;
ST_2045 = ((V)("#1b1d22"));
GL_2046 = ((V)("#d6f0fa"));
W_2047 = 112D;
D_2048 = 40D;
return NewObj(5).Put("w", ((V)((W_2047 + 4D)))).Put("d", ((V)((D_2048 + 6D)))).Put("glow", Fn((V _arrowThis2055, int _argc2049, V _a2051, V _a2052, V _a2053, V _a2054, V[] _rest2050) => {
return NewObj(2).Put("y", ((V)(8D))).Put("r", ((V)(70D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis2062, int _argc2056, V _a2058, V _a2059, V _a2060, V _a2061, V[] _rest2057) => {
V o_2063 = default;
V on_2064 = default;
V R_2065 = default;
V SB_2066 = default;
V BT_2067 = default;
V FP_2068 = default;
V BP_2069 = default;
V SP_2070 = default;
o_2063 = Arr();
on_2064 = Call(glue_48, V.Undef, o_2063);
R_2065 = Call(R0_47, V.Undef, ((V)("etha")));
Invoke(o_2063, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(60D)), ((V)(6D)), ((V)(16D)), ((V)("#0d0e10")), NewObj(2).Put("r", ((V)(0.6))).Put("mat", ((V)("cer"))).V));
SB_2066 = Call(box_11, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(W_2047)), ((V)(9D)), ((V)(D_2048)), ST_2045, NewObj(3).Put("r", ((V)(1.4))).Put("mat", ((V)("cer"))).Put("shine", ((V)(1D))).V);
Invoke(o_2063, "push", SB_2066);
Call(on_2064, V.Undef, SB_2066, Invoke(Arr(Call(slabX_15, V.Undef, ((V)(0D)), ((V)(6.1)), ((V)(((D_2048 / 2D) + 0.05))), ((V)((W_2047 - 6D))), ((V)(0.6)), ((V)(0.1)), ((V)("#ffb45a")), Call(em_44, V.Undef, NewObj(1).Put("r", ((V)(0D))).V)), Call(slabX_15, V.Undef, ((V)(0D)), ((V)(13.4)), ((V)(((D_2048 / 2D) + 0.05))), ((V)((W_2047 - 3D))), ((V)(0.5)), ((V)(0.1)), ((V)("#8a8f96")), Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Call(box_11, V.Undef, ((V)(44D)), ((V)(9D)), ((V)(((D_2048 / 2D) + 0.05))), ((V)(10D)), ((V)(3D)), ((V)(0.1)), ((V)("#0e1a24")), NewObj(2).Put("r", ((V)(0.6))).Put("noOut", ((V)(1D))).V)), "concat", Call(pipe_34, V.Undef, Arr(Arr(((V)((((-W_2047) / 2D) + 2D))), ((V)(11.8)), ((V)(((D_2048 / 2D) + 0.05)))), Arr(((V)((-30D))), ((V)(9.6)), ((V)(((D_2048 / 2D) + 0.05)))), Arr(((V)((-12D))), ((V)(10.6)), ((V)(((D_2048 / 2D) + 0.05)))), Arr(((V)(8D)), ((V)(8.4)), ((V)(((D_2048 / 2D) + 0.05))))), ((V)(0.12)), ((V)("#4a4d55")), NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_2064, V.Undef, SB_2066, Invoke(Call(pipe_34, V.Undef, Arr(Arr(((V)((((-W_2047) / 2D) + 3D))), ((V)(15.02)), ((V)((-16D)))), Arr(((V)((-36D))), ((V)(15.02)), ((V)((-9D)))), Arr(((V)((-30D))), ((V)(15.02)), ((V)(6D))), Arr(((V)((-44D))), ((V)(15.02)), ((V)(18D)))), ((V)(0.12)), ((V)("#3e4148")), NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V), "concat", Call(pipe_34, V.Undef, Arr(Arr(((V)(40D)), ((V)(15.02)), ((V)((-18D)))), Arr(((V)(34D)), ((V)(15.02)), ((V)((-6D)))), Arr(((V)(46D)), ((V)(15.02)), ((V)(8D))), Arr(((V)(52D)), ((V)(15.02)), ((V)(17D)))), ((V)(0.1)), ((V)("#3e4148")), NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
BT_2067 = Call(box_11, V.Undef, ((V)(0D)), ((V)(15D)), ((V)(0D)), ((V)(80D)), ((V)(2D)), ((V)(10D)), CH_28, Call(M__40, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V));
Invoke(o_2063, "push", BT_2067);
Call(on_2064, V.Undef, BT_2067, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(17.02)), ((V)(0D)), ((V)(74D)), ((V)(0.05)), ((V)(3.4)), ((V)("#0e0e10")), NewObj(2).Put("r", ((V)(0.6))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Call(rep_45, V.Undef, ((V)(26D)), Fn((V _arrowThis2078, int _argc2071, V i_2077, V _a2074, V _a2075, V _a2076, V[] _rest2072) => {
double side_2079 = 0;
double x_2080 = 0;
double z_2081 = 0;
double r_2082 = 0;
side_2079 = (NumTruthy((ToNum(i_2077) % 2D)) ? 1D : (-1D));
x_2080 = (((-48D) + ((ToNum(i_2077) * 37D) % 96D)) + (ToNum(Call(R_2065, V.Undef)) * 2D));
z_2081 = (side_2079 * (8.4 + (ToNum(Call(R_2065, V.Undef)) * 7.4)));
r_2082 = (1.5 + (ToNum(Call(R_2065, V.Undef)) * 1.1));
Call(on_2064, V.Undef, SB_2066, Arr(Call(ball_13, V.Undef, ((V)(x_2080)), ((V)((15D + (r_2082 * 0.55)))), ((V)(z_2081)), ((V)(r_2082)), GetIdx(Arr(((V)("#f4f1ea")), ((V)("#dcd8cf")), ((V)("#b9b4aa")), ((V)("#e8e4dc"))), (ToNum(i_2077) % 4D)), NewObj(4).Put("sy", ((V)(0.55))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("mat", ((V)("cer"))).V)));
return default;
}, 1, "", true));
FP_2068 = Call(slab_14, V.Undef, ((V)(0D)), ((V)(15D)), ((V)(((D_2048 / 2D) - 1.3))), ((V)((W_2047 - 4D))), ((V)(36D)), ((V)(0.6)), GL_2046, NewObj(3).Put("r", ((V)(0.3))).Put("op", ((V)(0.16))).Put("shine", ((V)(1D))).V);
BP_2069 = Call(slab_14, V.Undef, ((V)(0D)), ((V)(15D)), ((V)((((-D_2048) / 2D) + 1.3))), ((V)((W_2047 - 4D))), ((V)(36D)), ((V)(0.6)), ((V)("#14161a")), NewObj(3).Put("r", ((V)(0.3))).Put("op", ((V)(0.92))).Put("shine", ((V)(1D))).V);
Invoke(o_2063, "push", FP_2068, BP_2069);
SP_2070 = Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis2090, int _argc2083, V sg_2089, V _a2086, V _a2087, V _a2088, V[] _rest2084) => {
return Call(box_11, V.Undef, ((V)((ToNum(sg_2089) * ((W_2047 / 2D) - 2.3)))), ((V)(15D)), ((V)(0D)), ((V)(0.6)), ((V)(36D)), ((V)((D_2048 - 3.2))), GL_2046, NewObj(3).Put("r", ((V)(0.2))).Put("op", ((V)(0.16))).Put("shine", ((V)(1D))).V);
}, 1, "", true));
Invoke(SP_2070, "forEach", Fn((V _arrowThis2098, int _argc2091, V s_2097, V _a2094, V _a2095, V _a2096, V[] _rest2092) => {
return Invoke(o_2063, "push", s_2097);
}, 1, "", true));
Call(on_2064, V.Undef, FP_2068, Arr(Call(slabX_15, V.Undef, ((V)(0D)), ((V)(50.6)), ((V)(((D_2048 / 2D) - 1.3))), ((V)((W_2047 - 3.4))), ((V)(0.8)), ((V)(0.9)), CH_28, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V))));
Invoke(SP_2070, "forEach", Fn((V _arrowThis2107, int _argc2099, V s_2105, V i_2106, V _a2103, V _a2104, V[] _rest2100) => {
return Call(on_2064, V.Undef, s_2105, Arr(Call(box_11, V.Undef, ((V)(((Truthy(i_2106) ? 1D : (-1D)) * ((W_2047 / 2D) - 2.3)))), ((V)(50.6)), ((V)(0D)), ((V)(0.9)), ((V)(0.8)), ((V)((D_2048 - 3.2))), CH_28, Call(M__40, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V))));
}, 2, "", true));
return o_2063;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis2115, int _argc2108, V c_2114, V _a2111, V _a2112, V _a2113, V[] _rest2109) => {
V k_2116 = default;
V @out_2117 = default;
V L_2118 = default;
V r_2119 = default;
k_2116 = Get(c_2114, "k");
@out_2117 = NewObj(3).Put("defs", Add(Call(RG_50, V.Undef, ((V)("q23eu")), ((V)("#ffb45a")), ((V)("#ff8a2a")), ((V)(0.6))), Call(RG_50, V.Undef, ((V)("q23ev")), ((V)("#ffd9a0")), ((V)("#ffffff")), ((V)(0.7))))).Put("front", ((V)(""))).Put("under", Call(fxEll_35, V.Undef, c_2114, ((V)(0D)), ((V)(0.2)), ((V)(0D)), ((V)(52D)), ((V)("url(#q23eu)")), Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.55;0.85;0.55")), ((V)(4D))))).V;
if (LtN(Call(face_59, V.Undef, c_2114, ((V)(0D)), ((V)(1D))), (-0.25))) {
return @out_2117;
}
L_2118 = Call(rep_45, V.Undef, ((V)(6D)), Fn((V _arrowThis2127, int _argc2120, V i_2126, V _a2123, V _a2124, V _a2125, V[] _rest2121) => {
return Arr(((V)(((-30D) + (ToNum(i_2126) * 12D)))), ((V)(17D)), ((V)(0D)), ((V)((0.5 + ((ToNum(i_2126) % 2D) * 0.08)))));
}, 1, "", true));
OpSet(@out_2117, "front", 0, Get(Invoke(Get(RD_8, "H"), "fire", c_2114, L_2118), "over"));
Call(rep_45, V.Undef, ((V)(7D)), Fn((V _arrowThis2135, int _argc2128, V i_2134, V _a2131, V _a2132, V _a2133, V[] _rest2129) => {
V a_2136 = default;
V b_2137 = default;
V d_2138 = default;
a_2136 = Invoke(c_2114, "p", ((V)(((-33D) + (ToNum(i_2134) * 11D)))), ((V)(22D)), ((V)(0D)));
b_2137 = Call(n4_58, V.Undef, ((V)(((-ToNum(i_2134)) * 0.7))));
d_2138 = Call(n4_58, V.Undef, ((V)((3.6 + ((ToNum(i_2134) % 3D) * 0.5)))));
OpSet(@out_2117, "front", 0, ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(a_2136, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(a_2136, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((4D * ToNum(k_2116)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(k_2116)))))).S("\" fill=\"url(#q23ev)\" opacity=\"0\">").V(Call(an_37, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(a_2136, 1D))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(a_2136, 1D)) - (24D * ToNum(k_2116))))))).End())), d_2138, b_2137)).V(Call(an_37, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((3D * ToNum(k_2116)))))).S(";").V(Call(f1_23, V.Undef, ((V)((8D * ToNum(k_2116)))))).End())), d_2138, b_2137)).V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0;0.55;0")), d_2138, b_2137)).S("</ellipse>").End())));
return default;
}, 1, "", true));
if (GtN(Call(face_59, V.Undef, c_2114, ((V)(0D)), ((V)(1D))), 0.15)) {
OpSet(@out_2117, "front", 0, ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(frame_36, V.Undef, Get(c_2114, "p"), Arr(((V)((((-W_2047) / 2D) + 2D))), ((V)(51D)), ((V)(((D_2048 / 2D) - 0.9)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))).S("\"><path d=\"M10 0L2 36M16 0L8 36M70 0L62 36\" stroke=\"#ffffff\" stroke-width=\"0.8\" opacity=\"0.28\"/><path d=\"M13 0L5 36\" stroke=\"#ffffff\" stroke-width=\"2.4\" opacity=\"0.1\"/></g>").End())));
}
r_2119 = Invoke(c_2114, "p", ((V)(0D)), ((V)(15.1)), ((V)(10D)));
OpSet(@out_2117, "front", 0, ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(r_2119, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(r_2119, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((40D * ToNum(k_2116)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((4D * ToNum(k_2116)))))).S("\" fill=\"#ffb45a\" opacity=\"0.18\">").V(Call(an_37, V.Undef, ((V)("opacity")), ((V)("0.1;0.24;0.14;0.22;0.1")), ((V)(1.9)))).S("</ellipse>").End())));
return @out_2117;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(RD_8, "SET23", NewObj(10).Put("LIV-007", NewObj(2).Put("spec", ((V)("cube23"))).Put("note", ((V)("A cheap white particleboard 3-cube tower. The laminate is peeling off one shelf edge and the feet are swollen. A grey canvas bin with a sock flopping out, a row of books with one leaning over, board games, a coin jar, and a pen mug and rubber duck on top."))).V).Put("LIV-027", NewObj(3).Put("spec", ((V)("pipe23"))).Put("live", ((V)("Edison bulb"))).Put("note", ((V)("Five thick pine planks on black iron pipes with flanges at every board. Blanket rolls and a crate of records at the bottom, books with an iron bookend, a pothos whose vines trail and sway over the front, a red alarm clock ticking, a glowing Edison bulb on its cord and an old camera on top."))).V).Put("LIV-047", NewObj(3).Put("spec", ((V)("arch23"))).Put("live", ((V)("Reading nook"))).Put("note", ((V)("Painted built-in bookcases with three true arches. The side bays are full of books on oak shelves with LED strips. The middle is a window seat with a blue cushion, pillows, a throw, an open book whose pages turn, a brass sconce and a little floating shelf with trailing ivy."))).V).Put("LIV-067", NewObj(3).Put("spec", ((V)("lib23"))).Put("live", ((V)("Rolling ladder"))).Put("note", ((V)("A floor-to-ceiling walnut library: raised-panel cupboards below, three bays of books and curios above, brass picture lights washing the shelves, and a rolling ladder that slowly glides along its brass rail."))).V).Put("LIV-087", NewObj(3).Put("spec", ((V)("arc23"))).Put("live", ((V)("Robot picker"))).Put("note", ((V)("A graphite grid of softly lit niches holding archive boxes, books, specimen jars, vases and sculptures. A robot gantry glides along its rails and the picker rises and falls carrying a box, while status lights blink on the base."))).V).Put("LIV-015", NewObj(3).Put("spec", ((V)("faux23"))).Put("live", ((V)("Space heater"))).Put("note", ((V)("A drafty fake fireplace with a printed brick panel peeling at one corner. Inside the empty firebox a little space heater glows orange, its cord trailing across the hearth. A plastic clock ticks on the mantel, a candle stub flickers sideways and a sock dries on a pin, swinging in the draft."))).V).Put("LIV-035", NewObj(3).Put("spec", ((V)("stove23"))).Put("live", ((V)("Flames + steam"))).Put("note", ((V)("A cast-iron electric stove on cabriole legs over a slate hearth pad, with cast relief side panels and a glass door showing flickering flames over glowing logs. A flue pipe rises behind, a red kettle steams on top, and a basket of birch logs and the remote sit on the pad."))).V).Put("LIV-055", NewObj(3).Put("spec", ((V)("mantel23"))).Put("live", ((V)("Gas fire"))).Put("note", ((V)("A classic white mantel with fluted pilasters, a frieze with a plaque and rosettes and a dentil crown over a black slate surround with brass trim. Ceramic gas logs burn on a grate with blue-based flames behind a brass mesh screen; brass candlesticks flicker either side of a leaning mirror."))).V).Put("LIV-075", NewObj(3).Put("spec", ((V)("susp23"))).Put("live", ((V)("Wood fire"))).Put("note", ((V)("A black steel egg that hangs on its flue over a round slate plate. Real logs burn in its round opening, sparks drift up and the plate glows. A steel holder of split logs stands beside it."))).V).Put("LIV-095", NewObj(3).Put("spec", ((V)("etha23"))).Put("live", ((V)("Floating flames"))).Put("note", ((V)("A black stone slab that seems to float on a warm under-glow, with glass on three sides. A long steel burner sends up a row of flames and softly glowing water-vapour mist between white river stones."))).V).V);
edit22_72 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis2146, int _argc2139, V rows_2145, V _a2142, V _a2143, V _a2144, V[] _rest2140) => {
return Invoke(Call(edit22_72, V.Undef, rows_2145), "map", Fn((V _arrowThis2154, int _argc2147, V r_2153, V _a2150, V _a2151, V _a2152, V[] _rest2148) => {
return (Truthy(GetK(Get(RD_8, "SET23"), Get(r_2153, "id"))) ? Object_assign(NewObj(0).V, r_2153, GetK(Get(RD_8, "SET23"), Get(r_2153, "id"))) : r_2153);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H23", NewObj(9).Put("bk", bk_71).Put("deco", deco_69).Put("face", face_59).Put("fw", fw_60).Put("qd", qd_61).Put("fireIn", fireIn_62).Put("slide", slide_63).Put("sway", sway_67).Put("BC", BC_68).V);
Set(RD_8, "PLUS23", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
