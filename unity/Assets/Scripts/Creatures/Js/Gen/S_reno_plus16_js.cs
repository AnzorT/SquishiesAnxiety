// reno-plus16.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus16_js
    {

        public static void Run()
        {
Call(Named(boot_71 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V solid_11 = default;
V box_12 = default;
V cyl_13 = default;
V ball_14 = default;
V slab_15 = default;
V slabX_16 = default;
V arcW_17 = default;
V disc_18 = default;
V pillowY_19 = default;
V pillowZ_20 = default;
V shade_21 = default;
V mix_22 = default;
V f1_23 = default;
V N_24 = default;
double PI_25 = 0;
V GOLD_26 = default;
V CH_27 = default;
V rep_28 = default;
V em_29 = default;
V W__30 = default;
V M__31 = default;
V F__32 = default;
V L__33 = default;
V PL_34 = default;
V G__35 = default;
V cr_36 = default;
V dt_37 = default;
V rotF_38 = default;
V xf_39 = default;
V tilt_40 = default;
V tiltAll_41 = default;
V newell_42 = default;
V loft_43 = default;
V rod_44 = default;
V pipe_45 = default;
V n4_46 = default;
V P2_47 = default;
V an_48 = default;
V bobA_49 = default;
V fxEll_50 = default;
V FONT_51 = default;
V mtx_52 = default;
V frame_53 = default;
V kern_54 = default;
V cup_55 = default;
V holder_56 = default;
V PIL33_57 = default;
V egg_58 = default;
V partOf_59 = default;
V BBR_60 = default;
V bbAt_61 = default;
V COUCH_62 = default;
V POD_63 = default;
V CORD_64 = default;
V VELC_65 = default;
V EGG_66 = default;
V edit15_67 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((RD_8 is var _t68 && !Truthy(_t68) ? _t68 : Get(RD_8, "PLUS15")) is var _t69 && !Truthy(_t69) ? _t69 : X_9) is var _t70 && !Truthy(_t70) ? _t70 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_71.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS16"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t72 = K_10;
if (_t72.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t72));
{ V _t73 = Get(_t72, "solid");
solid_11 = _t73; }
{ V _t74 = Get(_t72, "box");
box_12 = _t74; }
{ V _t75 = Get(_t72, "cyl");
cyl_13 = _t75; }
{ V _t76 = Get(_t72, "ball");
ball_14 = _t76; }
{ V _t77 = Get(_t72, "slab");
slab_15 = _t77; }
{ V _t78 = Get(_t72, "slabX");
slabX_16 = _t78; }
{ V _t79 = Get(_t72, "arcW");
arcW_17 = _t79; }
{ V _t80 = Get(_t72, "disc");
disc_18 = _t80; }
{ V _t81 = Get(_t72, "pillowY");
pillowY_19 = _t81; }
{ V _t82 = Get(_t72, "pillowZ");
pillowZ_20 = _t82; }
{ V _t83 = Get(_t72, "shade");
shade_21 = _t83; }
{ V _t84 = Get(_t72, "mix");
mix_22 = _t84; }
{ V _t85 = Get(_t72, "f1");
f1_23 = _t85; } }
N_24 = Get(RD_8, "N");
PI_25 = System.Math.PI;
GOLD_26 = ((V)("#e2b14a"));
CH_27 = ((V)("#d5dde2"));
rep_28 = Fn((V _arrowThis94, int _argc86, V n_92, V f_93, V _a90, V _a91, V[] _rest87) => {
return Array_from(NewObj(1).Put("length", n_92).V, Fn((V _arrowThis103, int _argc95, V __101, V i_102, V _a99, V _a100, V[] _rest96) => {
return Call(f_93, V.Undef, i_102);
}, 2, "", true));
}, 2, "", true);
em_29 = Fn((V _arrowThis111, int _argc104, V o_110, V _a107, V _a108, V _a109, V[] _rest105) => {
return Object_assign(NewObj(2).Put("emit", ((V)(1D))).Put("noOut", ((V)(1D))).V, (o_110 is var _t112 && Truthy(_t112) ? _t112 : NewObj(0).V));
}, 1, "", true);
W__30 = Fn((V _arrowThis120, int _argc113, V o_119, V _a116, V _a117, V _a118, V[] _rest114) => {
return Object_assign(NewObj(1).Put("mat", ((V)("wood"))).V, (o_119 is var _t121 && Truthy(_t121) ? _t121 : NewObj(0).V));
}, 1, "", true);
M__31 = Fn((V _arrowThis129, int _argc122, V o_128, V _a125, V _a126, V _a127, V[] _rest123) => {
return Object_assign(NewObj(1).Put("mat", ((V)("metal"))).V, (o_128 is var _t130 && Truthy(_t130) ? _t130 : NewObj(0).V));
}, 1, "", true);
F__32 = Fn((V _arrowThis138, int _argc131, V o_137, V _a134, V _a135, V _a136, V[] _rest132) => {
return Object_assign(NewObj(2).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V, (o_137 is var _t139 && Truthy(_t139) ? _t139 : NewObj(0).V));
}, 1, "", true);
L__33 = Fn((V _arrowThis147, int _argc140, V o_146, V _a143, V _a144, V _a145, V[] _rest141) => {
return Object_assign(NewObj(1).Put("mat", ((V)("lea"))).V, (o_146 is var _t148 && Truthy(_t148) ? _t148 : NewObj(0).V));
}, 1, "", true);
PL_34 = Fn((V _arrowThis156, int _argc149, V o_155, V _a152, V _a153, V _a154, V[] _rest150) => {
return Object_assign(NewObj(1).Put("mat", ((V)("pl"))).V, (o_155 is var _t157 && Truthy(_t157) ? _t157 : NewObj(0).V));
}, 1, "", true);
G__35 = Fn((V _arrowThis165, int _argc158, V o_164, V _a161, V _a162, V _a163, V[] _rest159) => {
return Object_assign(NewObj(1).Put("shine", ((V)(1D))).V, (o_164 is var _t166 && Truthy(_t166) ? _t166 : NewObj(0).V));
}, 1, "", true);
cr_36 = Fn((V _arrowThis175, int _argc167, V a_173, V b_174, V _a171, V _a172, V[] _rest168) => {
return Arr(((V)(((ToNum(GetIdx(a_173, 1D)) * ToNum(GetIdx(b_174, 2D))) - (ToNum(GetIdx(a_173, 2D)) * ToNum(GetIdx(b_174, 1D)))))), ((V)(((ToNum(GetIdx(a_173, 2D)) * ToNum(GetIdx(b_174, 0D))) - (ToNum(GetIdx(a_173, 0D)) * ToNum(GetIdx(b_174, 2D)))))), ((V)(((ToNum(GetIdx(a_173, 0D)) * ToNum(GetIdx(b_174, 1D))) - (ToNum(GetIdx(a_173, 1D)) * ToNum(GetIdx(b_174, 0D)))))));
}, 2, "", true);
dt_37 = Fn((V _arrowThis184, int _argc176, V a_182, V b_183, V _a180, V _a181, V[] _rest177) => {
return ((V)((((ToNum(GetIdx(a_182, 0D)) * ToNum(GetIdx(b_183, 0D))) + (ToNum(GetIdx(a_182, 1D)) * ToNum(GetIdx(b_183, 1D)))) + (ToNum(GetIdx(a_182, 2D)) * ToNum(GetIdx(b_183, 2D))))));
}, 2, "", true);
rotF_38 = Fn((V _arrowThis193, int _argc185, V ax_191, V an_192, V _a189, V _a190, V[] _rest186) => {
V L_194 = default;
V k_195 = default;
double c_196 = 0;
double s_197 = 0;
L_194 = (((V)(Hypot(ToNum(GetIdx(ax_191, 0D)), ToNum(GetIdx(ax_191, 1D)), ToNum(GetIdx(ax_191, 2D))))) is var _t198 && Truthy(_t198) ? _t198 : ((V)(1D)));
k_195 = Invoke(ax_191, "map", Fn((V _arrowThis206, int _argc199, V v_205, V _a202, V _a203, V _a204, V[] _rest200) => {
return ((V)((ToNum(v_205) / ToNum(L_194))));
}, 1, "", true));
c_196 = FdLibm.Cos(ToNum(an_192));
s_197 = FdLibm.Sin(ToNum(an_192));
return Fn((V _arrowThis214, int _argc207, V v_213, V _a210, V _a211, V _a212, V[] _rest208) => {
V kv_215 = default;
V kd_216 = default;
kv_215 = Call(cr_36, V.Undef, k_195, v_213);
kd_216 = Call(dt_37, V.Undef, k_195, v_213);
return Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis224, int _argc217, V i_223, V _a220, V _a221, V _a222, V[] _rest218) => {
return ((V)((((ToNum(GetK(v_213, i_223)) * c_196) + (ToNum(GetK(kv_215, i_223)) * s_197)) + ((ToNum(GetK(k_195, i_223)) * ToNum(kd_216)) * (1D - c_196)))));
}, 1, "", true));
return default;
}, 1, "", true);
return default;
}, 2, "", true);
xf_39 = Fn((V _arrowThis235, int _argc225, V S_231, V R_232, V piv_233, V off_234, V[] _rest226) => {
V seen_236 = default;
V mv_237 = default;
piv_233 = (piv_233 is var _t238 && Truthy(_t238) ? _t238 : Arr(((V)(0D)), ((V)(0D)), ((V)(0D))));
off_234 = (off_234 is var _t239 && Truthy(_t239) ? _t239 : Arr(((V)(0D)), ((V)(0D)), ((V)(0D))));
seen_236 = New(G("Set"));
mv_237 = Fn((V _arrowThis247, int _argc240, V p_246, V _a243, V _a244, V _a245, V[] _rest241) => {
V q_248 = default;
if (Truthy(Invoke(seen_236, "has", p_246))) {
return default;
}
Invoke(seen_236, "add", p_246);
q_248 = Call(R_232, V.Undef, Arr(((V)((ToNum(GetIdx(p_246, 0D)) - ToNum(GetIdx(piv_233, 0D))))), ((V)((ToNum(GetIdx(p_246, 1D)) - ToNum(GetIdx(piv_233, 1D))))), ((V)((ToNum(GetIdx(p_246, 2D)) - ToNum(GetIdx(piv_233, 2D)))))));
SetIdx(p_246, 0D, Add(Add(GetIdx(q_248, 0D), GetIdx(piv_233, 0D)), GetIdx(off_234, 0D)));
SetIdx(p_246, 1D, Add(Add(GetIdx(q_248, 1D), GetIdx(piv_233, 1D)), GetIdx(off_234, 1D)));
SetIdx(p_246, 2D, Add(Add(GetIdx(q_248, 2D), GetIdx(piv_233, 2D)), GetIdx(off_234, 2D)));
return default;
}, 1, "", true);
Invoke(Get(S_231, "pts"), "forEach", mv_237);
Invoke(Get(S_231, "faces"), "forEach", Fn((V _arrowThis256, int _argc249, V F_255, V _a252, V _a253, V _a254, V[] _rest250) => {
V n_257 = default;
Invoke(Get(F_255, "q"), "forEach", mv_237);
n_257 = Call(R_232, V.Undef, Get(F_255, "n"));
SetIdx(Get(F_255, "n"), 0D, GetIdx(n_257, 0D));
SetIdx(Get(F_255, "n"), 1D, GetIdx(n_257, 1D));
SetIdx(Get(F_255, "n"), 2D, GetIdx(n_257, 2D));
return default;
}, 1, "", true));
return S_231;
return default;
}, 4, "", true);
tilt_40 = Fn((V _arrowThis268, int _argc258, V S_264, V ax_265, V an_266, V piv_267, V[] _rest259) => {
return Call(xf_39, V.Undef, S_264, Call(rotF_38, V.Undef, ax_265, an_266), piv_267);
}, 4, "", true);
tiltAll_41 = Fn((V _arrowThis279, int _argc269, V L_275, V ax_276, V an_277, V piv_278, V[] _rest270) => {
return Invoke(L_275, "map", Fn((V _arrowThis287, int _argc280, V S_286, V _a283, V _a284, V _a285, V[] _rest281) => {
return Call(tilt_40, V.Undef, S_286, ax_276, an_277, piv_278);
}, 1, "", true));
}, 4, "", true);
newell_42 = Fn((V _arrowThis295, int _argc288, V q_294, V _a291, V _a292, V _a293, V[] _rest289) => {
V n_296 = default;
n_296 = Arr(((V)(0D)), ((V)(0D)), ((V)(0D)));
{
double i_297 = 0;
i_297 = 0D;
while (true) {
if (!(Lt(((V)(i_297)), Get(q_294, "length")))) break;
V a_299 = default;
V b_300 = default;
a_299 = GetIdx(q_294, i_297);
b_300 = GetIdx(q_294, ((i_297 + 1D) % ToNum(Get(q_294, "length"))));
OpSetK(n_296, ((V)(0D)), 0, ((V)(((ToNum(GetIdx(a_299, 1D)) - ToNum(GetIdx(b_300, 1D))) * ToNum(Add(GetIdx(a_299, 2D), GetIdx(b_300, 2D)))))));
OpSetK(n_296, ((V)(1D)), 0, ((V)(((ToNum(GetIdx(a_299, 2D)) - ToNum(GetIdx(b_300, 2D))) * ToNum(Add(GetIdx(a_299, 0D), GetIdx(b_300, 0D)))))));
OpSetK(n_296, ((V)(2D)), 0, ((V)(((ToNum(GetIdx(a_299, 0D)) - ToNum(GetIdx(b_300, 0D))) * ToNum(Add(GetIdx(a_299, 1D), GetIdx(b_300, 1D)))))));
i_297++;
}
}
return n_296;
return default;
}, 1, "", true);
loft_43 = Fn((V _arrowThis310, int _argc301, V R_307, V col_308, V o_309, V _a306, V[] _rest302) => {
V n_311 = default;
V RR_312 = default;
V faces_313 = default;
V lr_314 = default;
o_309 = (o_309 is var _t315 && Truthy(_t315) ? _t315 : NewObj(0).V);
n_311 = (Get(o_309, "n") is var _t316 && Truthy(_t316) ? _t316 : ((V)(24D)));
RR_312 = Invoke(R_307, "map", Fn((V _arrowThis334, int _argc317, V _a319, V _a320, V _a321, V _a322, V[] _rest318) => {
V y_325 = default;
V cx_327 = default;
V cz_329 = default;
V a_331 = default;
V b_333 = default;
{ V _t323 = ListOf(_a319);
{ V _t324 = GetIdx(_t323, 0D);
y_325 = _t324; }
{ V _t326 = GetIdx(_t323, 1D);
cx_327 = _t326; }
{ V _t328 = GetIdx(_t323, 2D);
cz_329 = _t328; }
{ V _t330 = GetIdx(_t323, 3D);
a_331 = _t330; }
{ V _t332 = GetIdx(_t323, 4D);
b_333 = _t332; }
}
return Call(rep_28, V.Undef, n_311, Fn((V _arrowThis342, int _argc335, V i_341, V _a338, V _a339, V _a340, V[] _rest336) => {
double t_343 = 0;
t_343 = (((ToNum(i_341) / ToNum(n_311)) * 2D) * PI_25);
return Arr(Add(cx_327, ((V)((ToNum(a_331) * FdLibm.Cos(t_343))))), y_325, Add(cz_329, ((V)((ToNum(b_333) * FdLibm.Sin(t_343))))));
return default;
}, 1, "", true));
}, 1, "", true));
faces_313 = Arr();
{
double k_344 = 0;
k_344 = 0D;
while (true) {
if (!((k_344 < (ToNum(Get(RR_312, "length")) - 1D)))) break;
{
double i_346 = 0;
i_346 = 0D;
while (true) {
if (!(Lt(((V)(i_346)), n_311))) break;
double j_348 = 0;
V q_349 = default;
V nn_350 = default;
double L_351 = 0;
double mx_352 = 0;
double mz_353 = 0;
j_348 = ((i_346 + 1D) % ToNum(n_311));
q_349 = Arr(GetIdx(GetIdx(RR_312, k_344), i_346), GetIdx(GetIdx(RR_312, k_344), j_348), GetIdx(GetIdx(RR_312, (k_344 + 1D)), j_348), GetIdx(GetIdx(RR_312, (k_344 + 1D)), i_346));
nn_350 = Call(newell_42, V.Undef, q_349);
L_351 = Hypot(ToNum(GetIdx(nn_350, 0D)), ToNum(GetIdx(nn_350, 1D)), ToNum(GetIdx(nn_350, 2D)));
if ((L_351 < 0.02)) {
goto _cont347;
}
nn_350 = Invoke(nn_350, "map", Fn((V _arrowThis361, int _argc354, V v_360, V _a357, V _a358, V _a359, V[] _rest355) => {
return ((V)((ToNum(v_360) / L_351)));
}, 1, "", true));
mx_352 = ((ToNum(Add(Add(Add(GetIdx(GetIdx(q_349, 0D), 0D), GetIdx(GetIdx(q_349, 1D), 0D)), GetIdx(GetIdx(q_349, 2D), 0D)), GetIdx(GetIdx(q_349, 3D), 0D))) / 4D) - (ToNum(Add(GetIdx(GetIdx(R_307, k_344), 1D), GetIdx(GetIdx(R_307, (k_344 + 1D)), 1D))) / 2D));
mz_353 = ((ToNum(Add(Add(Add(GetIdx(GetIdx(q_349, 0D), 2D), GetIdx(GetIdx(q_349, 1D), 2D)), GetIdx(GetIdx(q_349, 2D), 2D)), GetIdx(GetIdx(q_349, 3D), 2D))) / 4D) - (ToNum(Add(GetIdx(GetIdx(R_307, k_344), 2D), GetIdx(GetIdx(R_307, (k_344 + 1D)), 2D))) / 2D));
if ((((mx_352 * ToNum(GetIdx(nn_350, 0D))) + (mz_353 * ToNum(GetIdx(nn_350, 2D)))) < 0D)) {
nn_350 = Invoke(nn_350, "map", Fn((V _arrowThis369, int _argc362, V v_368, V _a365, V _a366, V _a367, V[] _rest363) => {
return ((V)((-ToNum(v_368))));
}, 1, "", true));
}
Invoke(faces_313, "push", NewObj(2).Put("q", q_349).Put("n", nn_350).V);
_cont347: ;
i_346++;
}
}
k_344++;
}
}
Invoke(faces_313, "push", NewObj(3).Put("q", GetIdx(RR_312, 0D)).Put("n", Arr(((V)(0D)), ((V)((-1D))), ((V)(0D)))).Put("cap", ((V)(1D))).V);
lr_314 = GetIdx(R_307, (ToNum(Get(R_307, "length")) - 1D));
if (GtN(GetIdx(lr_314, 3D), 0.4)) {
Invoke(faces_313, "push", NewObj(3).Put("q", GetIdx(RR_312, (ToNum(Get(RR_312, "length")) - 1D))).Put("n", Arr(((V)(0D)), ((V)(1D)), ((V)(0D)))).Put("cap", ((V)(2D))).V);
}
return NewObj(12).Put("faces", faces_313).Put("pts", InvokeSpread(Arr(), "concat", new ArrBuilder().Spread(RR_312).V)).Put("col", col_308).Put("soft", Get(o_309, "soft")).Put("shine", Get(o_309, "shine")).Put("emit", Get(o_309, "emit")).Put("cv", ((V)(1D))).Put("zb", (Get(o_309, "zb") is var _t370 && Truthy(_t370) ? _t370 : ((V)(0D)))).Put("noOut", Get(o_309, "noOut")).Put("part", Get(o_309, "part")).Put("op", Get(o_309, "op")).Put("mat", Get(o_309, "mat")).V;
return default;
}, 3, "", true);
rod_44 = Fn((V _arrowThis382, int _argc371, V a_377, V b_378, V r_379, V col_380, V[] _rest372) => {
V d_383 = default;
double L_384 = 0;
V u_385 = default;
V S_386 = default;
V ax_387 = default;
double sn_388 = 0;
V o_381 = default;
o_381 = (_argc371 > 4 ? _rest372[0] : V.Undef);
d_383 = Arr(((V)((ToNum(GetIdx(b_378, 0D)) - ToNum(GetIdx(a_377, 0D))))), ((V)((ToNum(GetIdx(b_378, 1D)) - ToNum(GetIdx(a_377, 1D))))), ((V)((ToNum(GetIdx(b_378, 2D)) - ToNum(GetIdx(a_377, 2D))))));
L_384 = Hypot(ToNum(GetIdx(d_383, 0D)), ToNum(GetIdx(d_383, 1D)), ToNum(GetIdx(d_383, 2D)));
u_385 = Invoke(d_383, "map", Fn((V _arrowThis396, int _argc389, V v_395, V _a392, V _a393, V _a394, V[] _rest390) => {
return ((V)((ToNum(v_395) / L_384)));
}, 1, "", true));
S_386 = Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), r_379, ((V)(L_384)), col_380, Object_assign(NewObj(1).Put("n", ((V)(10D))).V, (o_381 is var _t397 && Truthy(_t397) ? _t397 : NewObj(0).V)));
ax_387 = Call(cr_36, V.Undef, Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), u_385);
sn_388 = Hypot(ToNum(GetIdx(ax_387, 0D)), ToNum(GetIdx(ax_387, 1D)), ToNum(GetIdx(ax_387, 2D)));
return Call(xf_39, V.Undef, S_386, ((sn_388 < 0.000001) ? (GtN(GetIdx(u_385, 1D), 0D) ? Fn((V _arrowThis405, int _argc398, V v_404, V _a401, V _a402, V _a403, V[] _rest399) => {
return v_404;
}, 1, "", true) : Call(rotF_38, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(PI_25)))) : Call(rotF_38, V.Undef, ax_387, ((V)(FdLibm.Atan2(sn_388, ToNum(GetIdx(u_385, 1D))))))), Arr(((V)(0D)), ((V)(0D)), ((V)(0D))), a_377);
return default;
}, 5, "", true);
pipe_45 = Fn((V _arrowThis416, int _argc406, V P_412, V r_413, V col_414, V o_415, V[] _rest407) => {
V @out_417 = default;
@out_417 = Arr();
{
double i_418 = 0;
i_418 = 0D;
while (true) {
if (!((i_418 < (ToNum(Get(P_412, "length")) - 1D)))) break;
Invoke(@out_417, "push", Call(rod_44, V.Undef, GetIdx(P_412, i_418), GetIdx(P_412, (i_418 + 1D)), r_413, col_414, o_415));
i_418++;
}
}
{
double i_420 = 0;
i_420 = 1D;
while (true) {
if (!((i_420 < (ToNum(Get(P_412, "length")) - 1D)))) break;
Invoke(@out_417, "push", Call(ball_14, V.Undef, GetIdx(GetIdx(P_412, i_420), 0D), ((V)((ToNum(GetIdx(GetIdx(P_412, i_420), 1D)) - ToNum(r_413)))), GetIdx(GetIdx(P_412, i_420), 2D), r_413, col_414, Object_assign(NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).V, (o_415 is var _t422 && Truthy(_t422) ? _t422 : NewObj(0).V))));
i_420++;
}
}
return @out_417;
return default;
}, 4, "", true);
n4_46 = Fn((V _arrowThis430, int _argc423, V v_429, V _a426, V _a427, V _a428, V[] _rest424) => {
return ((V)((Round((ToNum(v_429) * 10000D)) / 10000D)));
}, 1, "", true);
P2_47 = Fn((V _arrowThis438, int _argc431, V q_437, V _a434, V _a435, V _a436, V[] _rest432) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(q_437, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_437, 1D))).End()));
}, 1, "", true);
an_48 = Fn((V _arrowThis449, int _argc439, V a_445, V v_446, V d_447, V b_448, V[] _rest440) => {
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"").V(a_445).S("\" values=\"").V(v_446).S("\" dur=\"").V(d_447).S("s\"").S((Truthy(b_448) ? JsStrBuf.Begin().S(" begin=\"").V(b_448).S("s\"").End() : "")).S(" repeatCount=\"indefinite\"/>").End()));
}, 4, "", true);
bobA_49 = Fn((V _arrowThis458, int _argc450, V a_456, V d_457, V _a454, V _a455, V[] _rest451) => {
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;0 ").N((-ToNum(a_456))).S(";0 0\" dur=\"").V(d_457).S("s\" calcMode=\"spline\" keyTimes=\"0;0.5;1\" keySplines=\"0.45 0 0.55 1;0.45 0 0.55 1\" repeatCount=\"indefinite\"/>").End()));
}, 2, "", true);
fxEll_50 = Fn((V _arrowThis472, int _argc459, V c_465, V x_466, V y_467, V z_468, V[] _rest460) => {
V q_473 = default;
V R_469 = default;
V fill_470 = default;
V extra_471 = default;
R_469 = (_argc459 > 4 ? _rest460[0] : V.Undef);
fill_470 = (_argc459 > 5 ? _rest460[1] : V.Undef);
extra_471 = (_argc459 > 6 ? _rest460[2] : V.Undef);
q_473 = Invoke(c_465, "p", x_466, y_467, z_468);
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_473, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_473, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(R_469) * ToNum(Get(c_465, "k"))))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((ToNum(R_469) * ToNum(Get(c_465, "k"))) * ToNum(Get(X_9, "SA"))))))).S("\" fill=\"").V(fill_470).S("\">").V((extra_471 is var _t474 && Truthy(_t474) ? _t474 : ((V)("")))).S("</ellipse>").End()));
return default;
}, 7, "", true);
FONT_51 = ((V)(string.Concat("font-family=\"'Fredoka','Arial Rounded MT Bold',sans-serif\" font-weight=\"700\"", "")));
mtx_52 = Fn((V _arrowThis484, int _argc475, V o_481, V a_482, V b_483, V _a480, V[] _rest476) => {
return ((V)(JsStrBuf.Begin().S("matrix(").V(Invoke(Invoke(Arr(((V)((ToNum(GetIdx(a_482, 0D)) - ToNum(GetIdx(o_481, 0D))))), ((V)((ToNum(GetIdx(a_482, 1D)) - ToNum(GetIdx(o_481, 1D))))), ((V)((ToNum(GetIdx(b_483, 0D)) - ToNum(GetIdx(o_481, 0D))))), ((V)((ToNum(GetIdx(b_483, 1D)) - ToNum(GetIdx(o_481, 1D))))), GetIdx(o_481, 0D), GetIdx(o_481, 1D)), "map", n4_46), "join", ((V)(" ")))).S(")").End()));
}, 3, "", true);
frame_53 = Fn((V _arrowThis495, int _argc485, V p_491, V O_492, V U_493, V Vd_494, V[] _rest486) => {
return Call(mtx_52, V.Undef, CallSpread(p_491, V.Undef, new ArrBuilder().Spread(O_492).V), Call(p_491, V.Undef, Add(GetIdx(O_492, 0D), GetIdx(U_493, 0D)), Add(GetIdx(O_492, 1D), GetIdx(U_493, 1D)), Add(GetIdx(O_492, 2D), GetIdx(U_493, 2D))), Call(p_491, V.Undef, Add(GetIdx(O_492, 0D), GetIdx(Vd_494, 0D)), Add(GetIdx(O_492, 1D), GetIdx(Vd_494, 1D)), Add(GetIdx(O_492, 2D), GetIdx(Vd_494, 2D))));
}, 4, "", true);
kern_54 = Fn((V _arrowThis507, int _argc496, V x_502, V y_503, V z_504, V r_505, V[] _rest497) => {
V C_508 = default;
V i_506 = default;
i_506 = (_argc496 > 4 ? _rest497[0] : V.Undef);
C_508 = Arr(((V)("#fffaf0")), ((V)("#fff4d6")), ((V)("#ffefc0")));
return Arr(Call(ball_14, V.Undef, x_502, y_503, z_504, ((V)((ToNum(r_505) * 1.1))), GetIdx(C_508, (ToNum(i_506) % 3D)), NewObj(5).Put("k", ((V)(3D))).Put("n", ((V)(9D))).Put("sy", ((V)(0.85))).Put("shine", ((V)(0D))).Put("mat", ((V)("fab"))).V), Call(ball_14, V.Undef, Add(x_502, ((V)((ToNum(r_505) * 0.7)))), Add(y_503, ((V)((ToNum(r_505) * 0.5)))), Add(z_504, ((V)((ToNum(r_505) * 0.4)))), ((V)((ToNum(r_505) * 0.8))), GetIdx(C_508, (ToNum(Add(i_506, ((V)(1D)))) % 3D)), NewObj(5).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).Put("mat", ((V)("fab"))).Put("noOut", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)((ToNum(x_502) - (ToNum(r_505) * 0.5)))), Add(y_503, ((V)((ToNum(r_505) * 0.6)))), ((V)((ToNum(z_504) - (ToNum(r_505) * 0.3)))), ((V)((ToNum(r_505) * 0.55))), ((V)("#f6cf5a")), NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).Put("noOut", ((V)(1D))).V));
return default;
}, 5, "", true);
cup_55 = Fn((V _arrowThis522, int _argc509, V x_515, V y_516, V z_517, V r_518, V[] _rest510) => {
V h_519 = default;
V col_520 = default;
V band_521 = default;
h_519 = (_argc509 > 4 ? _rest510[0] : V.Undef);
col_520 = (_argc509 > 5 ? _rest510[1] : V.Undef);
band_521 = (_argc509 > 6 ? _rest510[2] : V.Undef);
return Arr(Call(cyl_13, V.Undef, x_515, y_516, z_517, ((V)((ToNum(r_518) * 0.84))), h_519, col_520, Call(PL_34, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.84))), Arr(h_519, ((V)(0D)), ((V)(1D))))).V)), Call(cyl_13, V.Undef, x_515, Add(y_516, ((V)((ToNum(h_519) * 0.45)))), z_517, ((V)((ToNum(r_518) * 0.95))), ((V)((ToNum(h_519) * 0.2))), (band_521 is var _t523 && Truthy(_t523) ? _t523 : ((V)("#ffffff"))), Call(PL_34, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V)), Call(cyl_13, V.Undef, x_515, Add(y_516, h_519), z_517, ((V)((ToNum(r_518) * 1.04))), ((V)(1.1)), ((V)("#ffffff")), Call(PL_34, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(rod_44, V.Undef, Arr(x_515, Add(y_516, h_519), z_517), Arr(Add(x_515, ((V)((ToNum(r_518) * 0.5)))), Add(Add(y_516, h_519), ((V)(7D))), ((V)((ToNum(z_517) - (ToNum(r_518) * 0.3))))), ((V)(0.55)), ((V)("#f4f4f4")), Call(PL_34, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)));
}, 7, "", true);
holder_56 = Fn((V _arrowThis535, int _argc524, V x_530, V y_531, V z_532, V r_533, V[] _rest525) => {
V o_536 = default;
V ring_534 = default;
ring_534 = (_argc524 > 4 ? _rest525[0] : V.Undef);
o_536 = Arr(Call(cyl_13, V.Undef, x_530, y_531, z_532, r_533, ((V)(1D)), (ring_534 is var _t537 && Truthy(_t537) ? _t537 : CH_27), Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_13, V.Undef, x_530, Add(y_531, ((V)(0.2))), z_532, ((V)((ToNum(r_533) * 0.76))), ((V)(1D)), ((V)("#141416")), NewObj(2).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).V));
return o_536;
return default;
}, 5, "", true);
Set(N_24, "futon16", Fn((V _arrowThis545, int _argc538, V S_544, V _a541, V _a542, V _a543, V[] _rest539) => {
double W_546 = 0;
double Dp_547 = 0;
double by_548 = 0;
V PN_549 = default;
V PD_550 = default;
V FAB_551 = default;
V FL_552 = default;
V FD_553 = default;
V TIE_554 = default;
V sag_555 = default;
W_546 = 150D;
Dp_547 = 74D;
by_548 = 14D;
PN_549 = ((V)("#dcb37a"));
PD_550 = ((V)("#b98a50"));
FAB_551 = ((V)("#6f84a8"));
FL_552 = Call(shade_21, V.Undef, FAB_551, ((V)(1.1)));
FD_553 = Call(shade_21, V.Undef, FAB_551, ((V)(0.8)));
TIE_554 = Call(shade_21, V.Undef, FAB_551, ((V)(0.55)));
sag_555 = Fn((V _arrowThis563, int _argc556, V x_562, V _a559, V _a560, V _a561, V[] _rest557) => {
return ((V)(((by_548 + 16.6) - (3.4 * (1D - Min(1D, (System.Math.Abs(ToNum(x_562)) / 74D)))))));
}, 1, "", true);
return NewObj(5).Put("w", ((V)((W_546 + 16D)))).Put("d", ((V)((Dp_547 + 8D)))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-34D)))).Put("z", ((V)(8D))).Put("h", ((V)(36D))).V, NewObj(3).Put("x", ((V)(34D))).Put("z", ((V)(8D))).Put("h", ((V)(36D))).V)).Put("build", Fn((V _arrowThis570, int _argc564, V _a566, V _a567, V _a568, V _a569, V[] _rest565) => {
V o_571 = default;
V on_572 = default;
V FP_573 = default;
V SE_574 = default;
V BK_575 = default;
V bt_576 = default;
V pa_577 = default;
V BC_578 = default;
V PW_579 = default;
V PS_580 = default;
o_571 = Arr();
on_572 = Fn((V _arrowThis589, int _argc581, V p_587, V L_588, V _a585, V _a586, V[] _rest582) => {
return Invoke(L_588, "map", Fn((V _arrowThis597, int _argc590, V k_596, V _a593, V _a594, V _a595, V[] _rest591) => {
Set(k_596, "par", p_587);
Invoke(o_571, "push", k_596);
return k_596;
return default;
}, 1, "", true));
}, 2, "", true);
FP_573 = NewObj(0).V;
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis605, int _argc598, V sg_604, V _a601, V _a602, V _a603, V[] _rest599) => {
double x_606 = 0;
x_606 = (ToNum(sg_604) * ((W_546 / 2D) + 3D));
Invoke(o_571, "push", Call(box_12, V.Undef, ((V)(x_606)), ((V)(0D)), ((V)((((-Dp_547) / 2D) + 5D))), ((V)(8D)), ((V)(64D)), ((V)(8D)), PD_550, Call(W__30, V.Undef, NewObj(2).Put("r", ((V)(2.4))).Put("bev", ((V)(1.6))).V)), SetK(FP_573, sg_604, Call(box_12, V.Undef, ((V)(x_606)), ((V)(0D)), ((V)(((Dp_547 / 2D) - 5D))), ((V)(8D)), ((V)(36D)), ((V)(8D)), PD_550, Call(W__30, V.Undef, NewObj(2).Put("r", ((V)(2.4))).Put("bev", ((V)(1.6))).V))));
Invoke(o_571, "push", Call(box_12, V.Undef, ((V)(x_606)), ((V)(31D)), ((V)(0D)), ((V)(10D)), ((V)(5D)), ((V)((Dp_547 - 18D))), PN_549, Call(W__30, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("bev", ((V)(1.5))).V)), Call(box_12, V.Undef, ((V)(x_606)), ((V)(6D)), ((V)(0D)), ((V)(6D)), ((V)(4D)), ((V)((Dp_547 - 18D))), PD_550, Call(W__30, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis614, int _argc607, V i_613, V _a610, V _a611, V _a612, V[] _rest608) => {
return Invoke(o_571, "push", Call(box_12, V.Undef, ((V)(x_606)), ((V)(10D)), ((V)(((((-Dp_547) / 2D) + 20D) + (ToNum(i_613) * 17D)))), ((V)(4.6)), ((V)(21D)), ((V)(3.6)), PN_549, Call(W__30, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(o_571, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)(58D)), ((V)((((-Dp_547) / 2D) + 3D))), ((V)((W_546 - 4D))), ((V)(6D)), ((V)(6D)), PN_549, Call(W__30, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(((Dp_547 / 2D) - 4D))), ((V)((W_546 - 4D))), ((V)(9D)), ((V)(4D)), PN_549, Call(W__30, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((by_548 - 6D))), ((V)(0D)), ((V)((W_546 - 6D))), ((V)(4D)), ((V)((Dp_547 - 14D))), PD_550, Call(W__30, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Call(on_572, V.Undef, GetIdx(FP_573, (-1D)), Arr(Call(box_12, V.Undef, ((V)((((-W_546) / 2D) - 3D))), ((V)(18D)), ((V)(((Dp_547 / 2D) - 5D))), ((V)(9.4)), ((V)(4D)), ((V)(9.4)), ((V)("#b9bec4")), NewObj(2).Put("r", ((V)(1.2))).Put("mat", ((V)("pl"))).V)));
Invoke(o_571, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((by_548 - 2D))), ((V)(0D)), ((V)((W_546 - 6D))), ((V)(3D)), ((V)((Dp_547 - 14D))), FD_553, Call(F__32, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)));
SE_574 = NewObj(0).V;
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis622, int _argc615, V sg_621, V _a618, V _a619, V _a620, V[] _rest616) => {
return Invoke(o_571, "push", SetK(SE_574, sg_621, Call(tilt_40, V.Undef, Call(pillowY_19, V.Undef, ((V)((ToNum(sg_621) * 36.5))), ((V)((by_548 + 4.6))), ((V)(7D)), ((V)(72D)), ((V)(12D)), ((V)(44D)), FL_552, Call(F__32, V.Undef)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)((ToNum(sg_621) * 0.046))), Arr(((V)((ToNum(sg_621) * 72.5))), ((V)((by_548 + 4.6))), ((V)(7D))))));
}, 1, "", true));
BK_575 = Call(pillowZ_20, V.Undef, ((V)(0D)), ((V)((by_548 + 12D))), ((V)((-21.5))), ((V)((W_546 - 6D))), ((V)(38D)), ((V)(12D)), FAB_551, Call(F__32, V.Undef));
bt_576 = Arr();
Invoke(Arr(((V)((-54D))), ((V)((-18D))), ((V)(18D)), ((V)(54D))), "forEach", Fn((V _arrowThis630, int _argc623, V x_629, V _a626, V _a627, V _a628, V[] _rest624) => {
return Invoke(Arr(((V)(10D)), ((V)(26D))), "forEach", Fn((V _arrowThis638, int _argc631, V h_637, V _a634, V _a635, V _a636, V[] _rest632) => {
return Invoke(bt_576, "push", Call(ball_14, V.Undef, x_629, Add(((V)((by_548 + 12D))), h_637), ((V)((-14.8))), ((V)(1.7)), TIE_554, NewObj(5).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sz", ((V)(0.5))).Put("noOut", ((V)(1D))).Put("shine", ((V)(0D))).V));
}, 1, "", true));
}, 1, "", true));
Call(tiltAll_41, V.Undef, Invoke(Arr(BK_575), "concat", bt_576), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.08))), Arr(((V)(0D)), ((V)((by_548 + 12D))), ((V)((-21.5)))));
Invoke(o_571, "push", BK_575);
Invoke(Call(on_572, V.Undef, BK_575, bt_576), "forEach", Fn((V _arrowThis646, int _argc639, V k_645, V _a642, V _a643, V _a644, V[] _rest640) => {
return Set(k_645, "fn", Arr(((V)(0D)), ((V)(0.08)), ((V)(1D))));
}, 1, "", true));
Invoke(Arr(((V)((-54D))), ((V)((-18D))), ((V)(18D)), ((V)(54D))), "forEach", Fn((V _arrowThis654, int _argc647, V x_653, V _a650, V _a651, V _a652, V[] _rest648) => {
return Call(on_572, V.Undef, GetIdx(SE_574, Sign(ToNum(x_653))), Arr(Call(ball_14, V.Undef, x_653, ((V)((ToNum(Call(sag_555, V.Undef, x_653)) - 0.6))), ((V)(10D)), ((V)(1.7)), TIE_554, NewObj(5).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sy", ((V)(0.5))).Put("noOut", ((V)(1D))).Put("shine", ((V)(0D))).V)));
}, 1, "", true));
{ V _t655 = Call(on_572, V.Undef, GetIdx(SE_574, 1D), Arr(Call(box_12, V.Undef, ((V)(46D)), ((V)((ToNum(Call(sag_555, V.Undef, ((V)(46D)))) - 0.3))), ((V)(14D)), ((V)(17D)), ((V)(0.9)), ((V)(13D)), ((V)("#c8584a")), Call(F__32, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)(0.25))).V))));
{ V _t656 = ListOf(_t655);
{ V _t657 = GetIdx(_t656, 0D);
pa_577 = _t657; }
} }
Call(on_572, V.Undef, pa_577, Arr(Call(box_12, V.Undef, ((V)(46D)), Add(Call(sag_555, V.Undef, ((V)(46D))), ((V)(0.5))), ((V)(14D)), ((V)(17D)), ((V)(0.2)), ((V)(2D)), ((V)("#f0d49a")), NewObj(3).Put("r", ((V)(0D))).Put("yaw", ((V)(0.25))).Put("noOut", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(46D)), Add(Call(sag_555, V.Undef, ((V)(46D))), ((V)(0.5))), ((V)(14D)), ((V)(2D)), ((V)(0.2)), ((V)(13D)), ((V)("#f0d49a")), NewObj(3).Put("r", ((V)(0D))).Put("yaw", ((V)(0.25))).Put("noOut", ((V)(1D))).V)));
Call(on_572, V.Undef, GetIdx(SE_574, (-1D)), Arr(Call(ball_14, V.Undef, ((V)((-54D))), ((V)((ToNum(Call(sag_555, V.Undef, ((V)((-54D))))) - 1.5))), ((V)(8D)), ((V)(14D)), ((V)("#e2b45a")), Call(F__32, V.Undef, NewObj(5).Put("sy", ((V)(0.42))).Put("sx", ((V)(1.2))).Put("k", ((V)(4D))).Put("n", ((V)(14D))).Put("shine", ((V)(0D))).V)), Call(ball_14, V.Undef, ((V)((-46D))), Add(Call(sag_555, V.Undef, ((V)((-46D)))), ((V)(3D))), ((V)(2D)), ((V)(8D)), ((V)("#ecc472")), Call(F__32, V.Undef, NewObj(4).Put("sy", ((V)(0.55))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).Put("shine", ((V)(0D))).V)), Call(ball_14, V.Undef, ((V)((-60D))), Add(Call(sag_555, V.Undef, ((V)((-60D)))), ((V)(4D))), ((V)((-2D))), ((V)(6D)), ((V)("#d9a84c")), Call(F__32, V.Undef, NewObj(4).Put("sy", ((V)(0.6))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("shine", ((V)(0D))).V))));
BC_578 = Call(box_12, V.Undef, ((V)((-58D))), ((V)((by_548 - 3D))), ((V)(((Dp_547 / 2D) + 1.5))), ((V)(20D)), ((V)(18D)), ((V)(3D)), ((V)("#e2b45a")), Call(F__32, V.Undef, NewObj(1).Put("r", ((V)(3D))).V));
Invoke(o_571, "push", BC_578);
Call(on_572, V.Undef, BC_578, Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis665, int _argc658, V i_664, V _a661, V _a662, V _a663, V[] _rest659) => {
return Call(box_12, V.Undef, ((V)(((-66D) + (ToNum(i_664) * 4D)))), ((V)((by_548 - 6D))), ((V)(((Dp_547 / 2D) + 3.2))), ((V)(1D)), ((V)(4D)), ((V)(1D)), ((V)("#c99a40")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)));
PW_579 = Call(pillowZ_20, V.Undef, ((V)(54D)), ((V)((by_548 + 19D))), ((V)((-10D))), ((V)(28D)), ((V)(26D)), ((V)(9D)), ((V)("#efe4cc")), Call(F__32, V.Undef));
PS_580 = Call(slabX_16, V.Undef, ((V)(54D)), ((V)((by_548 + 30D))), ((V)((-5.3))), ((V)(26D)), ((V)(3D)), ((V)(0.6)), ((V)("#7fa4c8")), NewObj(3).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).Put("mat", ((V)("fab"))).V);
Call(tiltAll_41, V.Undef, Arr(PW_579, PS_580), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(0.18)), Arr(((V)(54D)), ((V)((by_548 + 19D))), ((V)((-10D)))));
Invoke(o_571, "push", PW_579);
Set(GetIdx(Call(on_572, V.Undef, PW_579, Arr(PS_580)), 0D), "fn", Arr(((V)((-0.18))), ((V)(0D)), ((V)(1D))));
return o_571;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
PIL33_57 = Arr(Arr(((V)("#f3d27a")), ((V)("#f3ead8"))), Arr(((V)("#f3ead8")), ((V)("#7fb2c9"))), Arr(((V)("#f3ead8")), ((V)("#e98f74"))), Arr(((V)("#f3ead8")), ((V)("#9cbf8a"))), Arr(((V)("#f3d27a")), ((V)("#f3ead8"))));
Set(N_24, "couch16", Fn((V _arrowThis673, int _argc666, V S_672, V _a669, V _a670, V _a671, V[] _rest667) => {
double n_674 = 0;
double SW_675 = 0;
double AW_676 = 0;
double Wd_677 = 0;
double Dp_678 = 0;
double by_679 = 0;
V xs_680 = default;
V PC_681 = default;
n_674 = 3D;
SW_675 = 54D;
AW_676 = 22D;
Wd_677 = ((n_674 * SW_675) + (2D * AW_676));
Dp_678 = 90D;
by_679 = 10D;
xs_680 = Call(rep_28, V.Undef, ((V)(n_674)), Fn((V _arrowThis689, int _argc682, V i_688, V _a685, V _a686, V _a687, V[] _rest683) => {
return ((V)(((((-Wd_677) / 2D) + AW_676) + (SW_675 * ToNum(Add(i_688, ((V)(0.5))))))));
}, 1, "", true));
PC_681 = GetIdx(PIL33_57, (((double)(ToInt32(ToNum(Get(S_672, "ci"))) | ToInt32(0D))) % ToNum(Get(PIL33_57, "length"))));
return NewObj(5).Put("w", ((V)((Wd_677 + 14D)))).Put("d", ((V)((Dp_678 + 6D)))).Put("act", ((V)("sit"))).Put("seats", Invoke(xs_680, "map", Fn((V _arrowThis697, int _argc690, V x_696, V _a693, V _a694, V _a695, V[] _rest691) => {
return NewObj(3).Put("x", x_696).Put("z", ((V)(8D))).Put("h", ((V)((by_679 + 28D)))).V;
}, 1, "", true))).Put("build", Fn((V _arrowThis705, int _argc698, V P_704, V _a701, V _a702, V _a703, V[] _rest699) => {
V o_706 = default;
V A_707 = default;
V AL_708 = default;
V AD_709 = default;
V WD_710 = default;
double IW_711 = 0;
V on_712 = default;
V ARM_713 = default;
o_706 = Arr();
A_707 = Get(P_704, "a");
AL_708 = Get(P_704, "aL");
AD_709 = Get(P_704, "aD");
WD_710 = ((V)("#b07c48"));
IW_711 = (Wd_677 - (2D * AW_676));
on_712 = Fn((V _arrowThis723, int _argc714, V p_720, V L_721, V fn_722, V _a719, V[] _rest715) => {
return Invoke(L_721, "map", Fn((V _arrowThis731, int _argc724, V k_730, V _a727, V _a728, V _a729, V[] _rest725) => {
Set(k_730, "par", p_720);
if (Truthy(fn_722)) {
Set(k_730, "fn", fn_722);
}
Invoke(o_706, "push", k_730);
return k_730;
return default;
}, 1, "", true));
}, 3, "", true);
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis743, int _argc732, V _a734, V _a735, V _a736, V _a737, V[] _rest733) => {
V sx_740 = default;
V sz_742 = default;
{ V _t738 = ListOf(_a734);
{ V _t739 = GetIdx(_t738, 0D);
sx_740 = _t739; }
{ V _t741 = GetIdx(_t738, 1D);
sz_742 = _t741; }
}
return Invoke(o_706, "push", Call(cyl_13, V.Undef, ((V)((ToNum(sx_740) * ((Wd_677 / 2D) - 12D)))), ((V)(0D)), ((V)((ToNum(sz_742) * ((Dp_678 / 2D) - 12D)))), ((V)(3.4)), ((V)(by_679)), WD_710, Call(W__30, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.62))), Arr(((V)(by_679)), ((V)(0D)), ((V)(1.1))))).V)));
}, 1, "", true));
Invoke(o_706, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(by_679)), ((V)(0D)), ((V)(IW_711)), ((V)(14D)), ((V)((Dp_678 - 4D))), AD_709, Call(F__32, V.Undef, NewObj(2).Put("r", ((V)(10D))).Put("bev", ((V)(4D))).V)));
Invoke(o_706, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)((by_679 + 14D))), ((V)((((-Dp_678) / 2D) + 9D))), ((V)(IW_711)), ((V)(42D)), ((V)(16D)), A_707, Call(F__32, V.Undef, NewObj(1).Put("r", ((V)(14D))).V)));
Invoke(xs_680, "forEach", Fn((V _arrowThis751, int _argc744, V x_750, V _a747, V _a748, V _a749, V[] _rest745) => {
return Invoke(o_706, "push", Call(pillowY_19, V.Undef, x_750, ((V)((by_679 + 14D))), ((V)(11D)), ((V)((SW_675 - 2D))), ((V)(15D)), ((V)((Dp_678 - 36D))), AL_708, Call(F__32, V.Undef)));
}, 1, "", true));
Invoke(xs_680, "forEach", Fn((V _arrowThis759, int _argc752, V x_758, V _a755, V _a756, V _a757, V[] _rest753) => {
return Invoke(o_706, "push", Call(tilt_40, V.Undef, Call(pillowZ_20, V.Undef, x_758, ((V)((by_679 + 29D))), ((V)((((-Dp_678) / 2D) + 25.5))), ((V)((SW_675 - 3D))), ((V)(34D)), ((V)(14D)), AL_708, Call(F__32, V.Undef)), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.07))), Arr(x_758, ((V)((by_679 + 29D))), ((V)((((-Dp_678) / 2D) + 25.5))))));
}, 1, "", true));
ARM_713 = NewObj(0).V;
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis767, int _argc760, V sg_766, V _a763, V _a764, V _a765, V[] _rest761) => {
double x_768 = 0;
double z1_769 = 0;
V dc_770 = default;
x_768 = (ToNum(sg_766) * ((Wd_677 / 2D) - (AW_676 / 2D)));
z1_769 = ((Dp_678 / 2D) - 3D);
Invoke(o_706, "push", SetK(ARM_713, sg_766, Call(slab_15, V.Undef, ((V)(x_768)), ((V)(by_679)), ((V)(0D)), ((V)(AW_676)), ((V)(40D)), ((V)((Dp_678 - 6D))), A_707, Call(F__32, V.Undef, NewObj(1).Put("r", ((V)(((AW_676 / 2D) - 0.5)))).V))));
{ V _t771 = Call(on_712, V.Undef, GetK(ARM_713, sg_766), Arr(Call(disc_18, V.Undef, ((V)(x_768)), ((V)((by_679 + 29D))), ((V)((z1_769 + 0.6))), ((V)(((AW_676 / 2D) - 2.5))), ((V)(0.9)), AD_709, Call(F__32, V.Undef, NewObj(1).Put("n", ((V)(18D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
{ V _t772 = ListOf(_t771);
{ V _t773 = GetIdx(_t772, 0D);
dc_770 = _t773; }
} }
Call(on_712, V.Undef, dc_770, Arr(Call(disc_18, V.Undef, ((V)(x_768)), ((V)((by_679 + 29D))), ((V)((z1_769 + 1.5))), ((V)(2.2)), ((V)(0.6)), Call(shade_21, V.Undef, A_707, ((V)(0.7))), NewObj(3).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).Put("mat", ((V)("fab"))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis781, int _argc774, V sg_780, V _a777, V _a778, V _a779, V[] _rest775) => {
double px_782 = 0;
double pz_783 = 0;
double py_784 = 0;
V col_785 = default;
V PW_786 = default;
V L_787 = default;
px_782 = (ToNum(sg_780) * (((Wd_677 / 2D) - AW_676) - 20D));
pz_783 = (((-Dp_678) / 2D) + 40D);
py_784 = (by_679 + 30.6);
col_785 = (LtN(sg_780, 0D) ? GetIdx(PC_681, 0D) : GetIdx(PC_681, 1D));
PW_786 = Call(pillowZ_20, V.Undef, ((V)(px_782)), ((V)(py_784)), ((V)(pz_783)), ((V)(32D)), ((V)(30D)), ((V)(10D)), col_785, Call(F__32, V.Undef));
L_787 = Arr();
if (GtN(sg_780, 0D)) {
Call(rep_28, V.Undef, ((V)(5D)), Fn((V _arrowThis795, int _argc788, V i_794, V _a791, V _a792, V _a793, V[] _rest789) => {
return Invoke(L_787, "push", Call(ball_14, V.Undef, ((V)((((px_782 - 9D) + ((ToNum(i_794) % 3D) * 9D)) + (GtN(i_794, 2D) ? 4.5 : 0D)))), ((V)(((py_784 + 8D) + (GtN(i_794, 2D) ? 13D : 0D)))), ((V)((pz_783 + 5.3))), ((V)(1.8)), Call(shade_21, V.Undef, col_785, ((V)(0.7))), NewObj(5).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sz", ((V)(0.4))).Put("noOut", ((V)(1D))).Put("shine", ((V)(0D))).V));
}, 1, "", true));
} else {
Invoke(Arr(((V)(0D)), ((V)(1D))), "forEach", Fn((V _arrowThis803, int _argc796, V j_802, V _a799, V _a800, V _a801, V[] _rest797) => {
return Invoke(L_787, "push", Call(slabX_16, V.Undef, ((V)(px_782)), ((V)(((py_784 + 9D) + (ToNum(j_802) * 10D)))), ((V)((pz_783 + 5.2))), ((V)(27D)), ((V)(2.4)), ((V)(0.6)), Call(shade_21, V.Undef, col_785, ((V)(0.78))), NewObj(3).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).Put("mat", ((V)("fab"))).V));
}, 1, "", true));
}
Call(tiltAll_41, V.Undef, Call(tiltAll_41, V.Undef, Invoke(Arr(PW_786), "concat", L_787), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(((-ToNum(sg_780)) * 0.08))), Arr(((V)(px_782)), ((V)(py_784)), ((V)(pz_783)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.08))), Arr(((V)(px_782)), ((V)(py_784)), ((V)(pz_783))));
Invoke(o_706, "push", PW_786);
Call(on_712, V.Undef, PW_786, L_787, Arr(((V)(0D)), ((V)(0.08)), ((V)(1D))));
return default;
}, 1, "", true));
{
double xa_804 = 0;
V THR_805 = default;
V ST_806 = default;
double y0_807 = 0;
V T1_808 = default;
V T2_809 = default;
xa_804 = ((Wd_677 / 2D) - (AW_676 / 2D));
THR_805 = ((V)((SEqS(GetIdx(PC_681, 0D), "#f3d27a") ? "#e98f74" : "#f3d27a")));
ST_806 = Call(shade_21, V.Undef, THR_805, ((V)(0.78)));
y0_807 = (by_679 + 39.6);
{ V _t810 = Call(on_712, V.Undef, GetIdx(ARM_713, 1D), Arr(Call(pillowY_19, V.Undef, ((V)(xa_804)), ((V)(y0_807)), ((V)(6D)), ((V)((AW_676 + 2D))), ((V)(5D)), ((V)(36D)), THR_805, Call(F__32, V.Undef))));
{ V _t811 = ListOf(_t810);
{ V _t812 = GetIdx(_t811, 0D);
T1_808 = _t812; }
} }
{ V _t813 = Call(on_712, V.Undef, T1_808, Arr(Call(pillowY_19, V.Undef, ((V)(xa_804)), ((V)((y0_807 + 4.4))), ((V)(5D)), ((V)((AW_676 - 2D))), ((V)(5D)), ((V)(33D)), Call(mix_22, V.Undef, THR_805, ((V)("#ffffff")), ((V)(0.12))), Call(F__32, V.Undef))));
{ V _t814 = ListOf(_t813);
{ V _t815 = GetIdx(_t814, 0D);
T2_809 = _t815; }
} }
Call(on_712, V.Undef, T2_809, Arr(Call(slabX_16, V.Undef, ((V)(xa_804)), ((V)((y0_807 + 6.6))), ((V)((5D + 16.7))), ((V)((AW_676 - 6D))), ((V)(1.4)), ((V)(0.5)), ST_806, NewObj(3).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).Put("mat", ((V)("fab"))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_712, V.Undef, T1_808, Call(rep_28, V.Undef, ((V)(7D)), Fn((V _arrowThis823, int _argc816, V i_822, V _a819, V _a820, V _a821, V[] _rest817) => {
return Call(box_12, V.Undef, ((V)(((xa_804 - (AW_676 / 2D)) + ((ToNum(i_822) * AW_676) / 6D)))), ((V)((y0_807 - 1.6))), ((V)((6D + 18.4))), ((V)(1.1)), ((V)(3D)), ((V)(1.1)), ST_806, NewObj(3).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).Put("mat", ((V)("fab"))).V);
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
}
{
double x_824 = 0;
V RM_825 = default;
x_824 = (((-Wd_677) / 2D) + (AW_676 / 2D));
{ V _t826 = Call(on_712, V.Undef, GetIdx(ARM_713, (-1D)), Arr(Call(box_12, V.Undef, ((V)(x_824)), ((V)((by_679 + 39.6))), ((V)(14D)), ((V)(6D)), ((V)(2.2)), ((V)(16D)), ((V)("#3a3b40")), Call(PL_34, V.Undef, NewObj(2).Put("r", ((V)(1.6))).Put("yaw", ((V)(0.2))).V))));
{ V _t827 = ListOf(_t826);
{ V _t828 = GetIdx(_t827, 0D);
RM_825 = _t828; }
} }
Call(on_712, V.Undef, RM_825, Invoke(Arr(Arr(((V)("#ff5a4a")), ((V)(0D))), Arr(((V)("#4fd06a")), ((V)(4D))), Arr(((V)("#4fa8ff")), ((V)(8D)))), "map", Fn((V _arrowThis840, int _argc829, V _a831, V _a832, V _a833, V _a834, V[] _rest830) => {
V c_837 = default;
V dz_839 = default;
{ V _t835 = ListOf(_a831);
{ V _t836 = GetIdx(_t835, 0D);
c_837 = _t836; }
{ V _t838 = GetIdx(_t835, 1D);
dz_839 = _t838; }
}
return Call(ball_14, V.Undef, ((V)((x_824 + (ToNum(dz_839) * 0.2)))), ((V)((by_679 + 41.8))), Add(((V)(9D)), dz_839), ((V)(0.9)), c_837, NewObj(4).Put("k", ((V)(2D))).Put("n", ((V)(6D))).Put("sy", ((V)(0.5))).Put("noOut", ((V)(1D))).V);
}, 1, "", true)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
}
return o_706;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "loveseat16", Fn((V _arrowThis848, int _argc841, V S_847, V _a844, V _a845, V _a846, V[] _rest842) => {
double n_849 = 0;
double SW_850 = 0;
double AW_851 = 0;
double Wd_852 = 0;
double Dp_853 = 0;
double by_854 = 0;
V xs_855 = default;
V LEA_856 = default;
V LL_857 = default;
V LD_858 = default;
V BTN_859 = default;
V STI_860 = default;
n_849 = 2D;
SW_850 = 60D;
AW_851 = 26D;
Wd_852 = ((n_849 * SW_850) + (2D * AW_851));
Dp_853 = 92D;
by_854 = 21D;
xs_855 = Call(rep_28, V.Undef, ((V)(n_849)), Fn((V _arrowThis868, int _argc861, V i_867, V _a864, V _a865, V _a866, V[] _rest862) => {
return ((V)(((((-Wd_852) / 2D) + AW_851) + (SW_850 * ToNum(Add(i_867, ((V)(0.5))))))));
}, 1, "", true));
LEA_856 = ((V)("#a65a33"));
LL_857 = Call(shade_21, V.Undef, LEA_856, ((V)(1.12)));
LD_858 = Call(shade_21, V.Undef, LEA_856, ((V)(0.8)));
BTN_859 = Call(shade_21, V.Undef, LEA_856, ((V)(0.5)));
STI_860 = Call(shade_21, V.Undef, LEA_856, ((V)(1.4)));
return NewObj(5).Put("w", ((V)((Wd_852 + 6D)))).Put("d", ((V)((Dp_853 + 6D)))).Put("act", ((V)("sit"))).Put("seats", Invoke(xs_855, "map", Fn((V _arrowThis876, int _argc869, V x_875, V _a872, V _a873, V _a874, V[] _rest870) => {
return NewObj(3).Put("x", x_875).Put("z", ((V)(8D))).Put("h", ((V)(36D))).V;
}, 1, "", true))).Put("build", Fn((V _arrowThis883, int _argc877, V _a879, V _a880, V _a881, V _a882, V[] _rest878) => {
V o_884 = default;
double IW_885 = 0;
V on_886 = default;
V PLN_887 = default;
double bz_888 = 0;
double zf_889 = 0;
double yb_890 = 0;
double yt_891 = 0;
V BF_892 = default;
o_884 = Arr();
IW_885 = (Wd_852 - (2D * AW_851));
on_886 = Fn((V _arrowThis902, int _argc893, V p_899, V L_900, V fn_901, V _a898, V[] _rest894) => {
return Invoke(L_900, "map", Fn((V _arrowThis910, int _argc903, V k_909, V _a906, V _a907, V _a908, V[] _rest904) => {
Set(k_909, "par", p_899);
if (Truthy(fn_901)) {
Set(k_909, "fn", fn_901);
}
Invoke(o_884, "push", k_909);
return k_909;
return default;
}, 1, "", true));
}, 3, "", true);
PLN_887 = Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((Wd_852 - 14D))), ((V)(7D)), ((V)((Dp_853 - 16D))), ((V)("#232326")), Call(PL_34, V.Undef, NewObj(1).Put("r", ((V)(3D))).V));
Invoke(o_884, "push", PLN_887);
Call(on_886, V.Undef, PLN_887, Arr(Call(slabX_16, V.Undef, ((V)(0D)), ((V)(1.6)), ((V)(((Dp_853 / 2D) - 7.6))), ((V)((Wd_852 - 18D))), ((V)(1.8)), ((V)(0.6)), ((V)("#ffc870")), Call(em_29, V.Undef))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(o_884, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(7D)), ((V)(0D)), ((V)(IW_885)), ((V)(14D)), ((V)((Dp_853 - 4D))), LD_858, Call(L__33, V.Undef, NewObj(3).Put("r", ((V)(10D))).Put("bev", ((V)(4D))).Put("soft", ((V)(1D))).V)));
Invoke(xs_855, "forEach", Fn((V _arrowThis918, int _argc911, V x_917, V _a914, V _a915, V _a916, V[] _rest912) => {
V SC_919 = default;
SC_919 = Call(pillowY_19, V.Undef, x_917, ((V)(by_854)), ((V)(10D)), ((V)((SW_850 - 2D))), ((V)(15D)), ((V)((Dp_853 - 34D))), LL_857, Call(L__33, V.Undef, NewObj(1).Put("soft", ((V)(1D))).V));
Invoke(o_884, "push", SC_919);
Call(on_886, V.Undef, SC_919, Arr(Call(slabX_16, V.Undef, x_917, ((V)((by_854 + 8D))), ((V)(39.3)), ((V)((SW_850 - 12D))), ((V)(0.7)), ((V)(0.6)), STI_860, NewObj(3).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).Put("mat", ((V)("lea"))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
bz_888 = (((-Dp_853) / 2D) + 10D);
zf_889 = (-20D);
yb_890 = 32D;
yt_891 = 72D;
BF_892 = Call(slab_15, V.Undef, ((V)(0D)), ((V)(by_854)), ((V)(bz_888)), ((V)(IW_885)), ((V)(59D)), ((V)(16D)), LEA_856, Call(L__33, V.Undef, NewObj(2).Put("r", ((V)(14D))).Put("soft", ((V)(1D))).V));
Invoke(o_884, "push", BF_892);
Call(on_886, V.Undef, BF_892, Arr(Call(slabX_16, V.Undef, ((V)(0D)), ((V)((by_854 + 58.4))), ((V)((bz_888 + 4D))), ((V)((IW_885 - 16D))), ((V)(0.7)), ((V)(0.6)), STI_860, NewObj(3).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).Put("mat", ((V)("lea"))).V)), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Invoke(xs_855, "forEach", Fn((V _arrowThis927, int _argc920, V x_926, V _a923, V _a924, V _a925, V[] _rest921) => {
V BC_928 = default;
V T_929 = default;
double PX_930 = 0;
V rows_931 = default;
BC_928 = Call(slab_15, V.Undef, x_926, ((V)(yb_890)), ((V)((zf_889 - 4D))), ((V)((SW_850 - 3D))), ((V)((yt_891 - yb_890))), ((V)(8D)), LD_858, Call(L__33, V.Undef, NewObj(2).Put("r", ((V)(7D))).Put("soft", ((V)(1D))).V));
T_929 = Arr();
Invoke(o_884, "push", BC_928);
PX_930 = 13D;
rows_931 = Arr(((V)(43D)), ((V)(53.5)), ((V)(64D)));
Invoke(rows_931, "forEach", Fn((V _arrowThis940, int _argc932, V y_938, V j_939, V _a936, V _a937, V[] _rest933) => {
double odd_941 = 0;
double nI_942 = 0;
odd_941 = (ToNum(j_939) % 2D);
nI_942 = (NumTruthy(odd_941) ? 3D : 4D);
Call(rep_28, V.Undef, ((V)(nI_942)), Fn((V _arrowThis950, int _argc943, V i_949, V _a946, V _a947, V _a948, V[] _rest944) => {
V px_951 = default;
px_951 = Add(x_926, ((V)(((ToNum(i_949) - ((nI_942 - 1D) / 2D)) * PX_930))));
Invoke(T_929, "push", Call(ball_14, V.Undef, px_951, y_938, ((V)(zf_889)), ((V)(6.4)), (((ToNum(i_949) % 2D) == (odd_941 % 2D)) ? LL_857 : Call(shade_21, V.Undef, LL_857, ((V)(0.96)))), Call(L__33, V.Undef, NewObj(7).Put("sx", ((V)(1.18))).Put("sy", ((V)(1D))).Put("sz", ((V)(0.4))).Put("k", ((V)(4D))).Put("n", ((V)(14D))).Put("shine", ((V)(0.5))).Put("noOut", ((V)(1D))).V)));
return default;
}, 1, "", true));
return default;
}, 2, "", true));
Call(on_886, V.Undef, BC_928, T_929, Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(rep_28, V.Undef, ((V)(2D)), Fn((V _arrowThis959, int _argc952, V j_958, V _a955, V _a956, V _a957, V[] _rest953) => {
double y_960 = 0;
y_960 = (ToNum(Add(GetK(rows_931, j_958), GetK(rows_931, Add(j_958, ((V)(1D)))))) / 2D);
Call(rep_28, V.Undef, ((V)(3D)), Fn((V _arrowThis968, int _argc961, V i_967, V _a964, V _a965, V _a966, V[] _rest962) => {
return Call(on_886, V.Undef, BC_928, Arr(Call(ball_14, V.Undef, Add(x_926, ((V)(((ToNum(i_967) - 1D) * PX_930)))), ((V)(y_960)), ((V)((zf_889 + 2.3))), ((V)(1.3)), BTN_859, NewObj(5).Put("sz", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).Put("mat", ((V)("lea"))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis976, int _argc969, V sg_975, V _a972, V _a973, V _a974, V[] _rest970) => {
return Call(on_886, V.Undef, BC_928, Arr(Call(ball_14, V.Undef, Add(x_926, ((V)(((ToNum(sg_975) * 1.5) * PX_930)))), GetIdx(rows_931, 1D), ((V)((zf_889 + 2.3))), ((V)(1.3)), BTN_859, NewObj(5).Put("sz", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).Put("mat", ((V)("lea"))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis984, int _argc977, V sg_983, V _a980, V _a981, V _a982, V[] _rest978) => {
double x_985 = 0;
double z_986 = 0;
V AB_987 = default;
V CP_988 = default;
x_985 = (ToNum(sg_983) * ((Wd_852 / 2D) - (AW_851 / 2D)));
z_986 = ((Dp_853 / 2D) - 16D);
AB_987 = Call(box_12, V.Undef, ((V)(x_985)), ((V)(7D)), ((V)(0D)), ((V)(AW_851)), ((V)(35D)), ((V)((Dp_853 - 6D))), LEA_856, Call(L__33, V.Undef, NewObj(2).Put("r", ((V)(8D))).Put("soft", ((V)(1D))).V));
CP_988 = Call(box_12, V.Undef, ((V)(x_985)), ((V)(42D)), ((V)(0D)), ((V)(AW_851)), ((V)(5D)), ((V)((Dp_853 - 4D))), LL_857, Call(L__33, V.Undef, NewObj(3).Put("r", ((V)(6D))).Put("bev", ((V)(2.5))).Put("soft", ((V)(1D))).V));
Invoke(o_884, "push", AB_987, CP_988);
Call(on_886, V.Undef, AB_987, Arr(Call(slabX_16, V.Undef, ((V)(x_985)), ((V)(30D)), ((V)(((Dp_853 / 2D) - 2.6))), ((V)((AW_851 - 6D))), ((V)(0.7)), ((V)(0.6)), STI_860, NewObj(3).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).Put("mat", ((V)("lea"))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Call(on_886, V.Undef, CP_988, Invoke(Arr(Call(cyl_13, V.Undef, ((V)(x_985)), ((V)(46.6)), ((V)(z_986)), ((V)(6D)), ((V)(0.5)), ((V)("#7fd8ff")), Call(em_29, V.Undef, NewObj(1).Put("n", ((V)(16D))).V))), "concat", Call(holder_56, V.Undef, ((V)(x_985)), ((V)(46.8)), ((V)(z_986)), ((V)(5D)))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
if (GtN(sg_983, 0D)) {
V c0_989 = default;
V cr_990 = default;
{ V _t991 = Call(cup_55, V.Undef, ((V)(x_985)), ((V)(47D)), ((V)(z_986)), ((V)(4D)), ((V)(12D)), ((V)("#d9363b")));
{ V _t992 = ListOf(_t991);
{ V _t993 = GetIdx(_t992, 0D);
c0_989 = _t993; }
cr_990 = RestFrom(_t992, 1);
} }
Invoke(o_884, "push", c0_989);
Call(on_886, V.Undef, c0_989, cr_990);
}
return default;
}, 1, "", true));
return o_884;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "recliner16", Fn((V _arrowThis1001, int _argc994, V S_1000, V _a997, V _a998, V _a999, V[] _rest995) => {
double n_1002 = 0;
double SW_1003 = 0;
double CW_1004 = 0;
double EW_1005 = 0;
double Wd_1006 = 0;
double Dp_1007 = 0;
double by_1008 = 0;
V LEA_1009 = default;
V LL_1010 = default;
V LD_1011 = default;
V STI_1012 = default;
V xs_1013 = default;
V cxs_1014 = default;
V rec_1015 = default;
n_1002 = 3D;
SW_1003 = 56D;
CW_1004 = 18D;
EW_1005 = 20D;
Wd_1006 = (((n_1002 * SW_1003) + ((n_1002 - 1D) * CW_1004)) + (2D * EW_1005));
Dp_1007 = 96D;
by_1008 = 12D;
LEA_1009 = ((V)("#b8703e"));
LL_1010 = Call(shade_21, V.Undef, LEA_1009, ((V)(1.12)));
LD_1011 = Call(shade_21, V.Undef, LEA_1009, ((V)(0.78)));
STI_1012 = Call(shade_21, V.Undef, LEA_1009, ((V)(1.45)));
xs_1013 = Call(rep_28, V.Undef, ((V)(n_1002)), Fn((V _arrowThis1023, int _argc1016, V i_1022, V _a1019, V _a1020, V _a1021, V[] _rest1017) => {
return ((V)((((((-Wd_1006) / 2D) + EW_1005) + (SW_1003 / 2D)) + (ToNum(i_1022) * (SW_1003 + CW_1004)))));
}, 1, "", true));
cxs_1014 = Call(rep_28, V.Undef, ((V)((n_1002 - 1D))), Fn((V _arrowThis1031, int _argc1024, V i_1030, V _a1027, V _a1028, V _a1029, V[] _rest1025) => {
return Add(Add(GetK(xs_1013, i_1030), ((V)((SW_1003 / 2D)))), ((V)((CW_1004 / 2D))));
}, 1, "", true));
rec_1015 = Arr(((V)(0D)), ((V)(1D)), ((V)(0D)));
return NewObj(5).Put("w", ((V)((Wd_1006 + 6D)))).Put("d", ((V)((Dp_1007 + 30D)))).Put("act", ((V)("sit"))).Put("seats", Invoke(xs_1013, "map", Fn((V _arrowThis1040, int _argc1032, V x_1038, V i_1039, V _a1036, V _a1037, V[] _rest1033) => {
return NewObj(3).Put("x", x_1038).Put("z", ((V)((Truthy(GetK(rec_1015, i_1039)) ? 4D : 8D)))).Put("h", ((V)((by_1008 + 28D)))).V;
}, 2, "", true))).Put("build", Fn((V _arrowThis1047, int _argc1041, V _a1043, V _a1044, V _a1045, V _a1046, V[] _rest1042) => {
V o_1048 = default;
V on_1049 = default;
o_1048 = Arr();
on_1049 = Fn((V _arrowThis1059, int _argc1050, V p_1056, V L_1057, V fn_1058, V _a1055, V[] _rest1051) => {
return Invoke(L_1057, "map", Fn((V _arrowThis1067, int _argc1060, V k_1066, V _a1063, V _a1064, V _a1065, V[] _rest1061) => {
Set(k_1066, "par", p_1056);
if (Truthy(fn_1058)) {
Set(k_1066, "fn", fn_1058);
}
Invoke(o_1048, "push", k_1066);
return k_1066;
return default;
}, 1, "", true));
}, 3, "", true);
Invoke(o_1048, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((Wd_1006 - 10D))), ((V)(by_1008)), ((V)((Dp_1007 - 14D))), ((V)("#2b2320")), Call(PL_34, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)));
Invoke(xs_1013, "forEach", Fn((V _arrowThis1076, int _argc1068, V x_1074, V i_1075, V _a1072, V _a1073, V[] _rest1069) => {
V r_1077 = default;
V SB_1078 = default;
V SP_1079 = default;
double th_1080 = 0;
V piv_1081 = default;
V BK_1082 = default;
V CU_1083 = default;
V HD_1084 = default;
V ST_1085 = default;
V fn_1086 = default;
r_1077 = GetK(rec_1015, i_1075);
SB_1078 = Call(box_12, V.Undef, x_1074, ((V)(by_1008)), ((V)(4.5)), ((V)((SW_1003 - 2D))), ((V)(15D)), ((V)((Dp_1007 - 15D))), LD_1011, Call(L__33, V.Undef, NewObj(3).Put("r", ((V)(8D))).Put("bev", ((V)(3D))).Put("soft", ((V)(1D))).V));
SP_1079 = Call(pillowY_19, V.Undef, x_1074, ((V)((by_1008 + 15D))), ((V)((Truthy(r_1077) ? 1.5 : 8D))), ((V)((SW_1003 - 4D))), ((V)(14D)), ((V)((Truthy(r_1077) ? 75D : (Dp_1007 - 34D)))), LL_1010, Call(L__33, V.Undef));
Invoke(o_1048, "push", SB_1078, SP_1079);
Call(on_1049, V.Undef, SP_1079, Arr(Call(slabX_16, V.Undef, x_1074, ((V)((by_1008 + 22D))), ((V)(37.3)), ((V)((SW_1003 - 12D))), ((V)(0.7)), ((V)(0.6)), STI_1012, NewObj(3).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).Put("mat", ((V)("lea"))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
th_1080 = (Truthy(r_1077) ? (-0.42) : (-0.06));
piv_1081 = Arr(x_1074, ((V)(by_1008)), ((V)((((-Dp_1007) / 2D) + 2D))));
BK_1082 = Call(slab_15, V.Undef, x_1074, ((V)(by_1008)), ((V)((((-Dp_1007) / 2D) + 7D))), ((V)((SW_1003 - 2D))), ((V)((Truthy(r_1077) ? 66D : 72D))), ((V)(10D)), LD_1011, Call(L__33, V.Undef, NewObj(3).Put("r", ((V)(16D))).Put("rb", ((V)(4D))).Put("soft", ((V)(1D))).V));
CU_1083 = Call(pillowZ_20, V.Undef, x_1074, ((V)((by_1008 + 18D))), ((V)((((-Dp_1007) / 2D) + 18D))), ((V)((SW_1003 - 8D))), ((V)(42D)), ((V)(12D)), LEA_1009, Call(L__33, V.Undef));
HD_1084 = Call(pillowZ_20, V.Undef, x_1074, ((V)((by_1008 + 60D))), ((V)((((-Dp_1007) / 2D) + 18.5))), ((V)((SW_1003 - 12D))), ((V)(12D)), ((V)(11D)), LL_1010, Call(L__33, V.Undef));
ST_1085 = Call(slabX_16, V.Undef, x_1074, ((V)((by_1008 + 38D))), ((V)((((-Dp_1007) / 2D) + 24.4))), ((V)((SW_1003 - 14D))), ((V)(0.7)), ((V)(0.6)), STI_1012, NewObj(3).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).Put("mat", ((V)("lea"))).V);
Call(tiltAll_41, V.Undef, Arr(BK_1082, CU_1083, HD_1084, ST_1085), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(th_1080)), piv_1081);
Invoke(o_1048, "push", BK_1082);
fn_1086 = Arr(((V)(0D)), ((V)(FdLibm.Sin((-th_1080)))), ((V)(FdLibm.Cos(th_1080))));
if (Truthy(r_1077)) {
Call(on_1049, V.Undef, BK_1082, Arr(CU_1083, HD_1084), fn_1086);
} else {
Invoke(o_1048, "push", CU_1083, HD_1084);
}
Call(on_1049, V.Undef, CU_1083, Arr(ST_1085), fn_1086);
if (Truthy(r_1077)) {
V FR_1087 = default;
FR_1087 = Call(tilt_40, V.Undef, Call(box_12, V.Undef, x_1074, ((V)((by_1008 + 5D))), ((V)(((Dp_1007 / 2D) + 10D))), ((V)((SW_1003 - 6D))), ((V)(7D)), ((V)(24D)), LEA_1009, Call(L__33, V.Undef, NewObj(2).Put("r", ((V)(4D))).Put("soft", ((V)(1D))).V)), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(0.1)), Arr(x_1074, ((V)((by_1008 + 5D))), ((V)(((Dp_1007 / 2D) - 2D)))));
Call(on_1049, V.Undef, SB_1078, Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis1095, int _argc1088, V sg_1094, V _a1091, V _a1092, V _a1093, V[] _rest1089) => {
return Call(rod_44, V.Undef, Arr(Add(x_1074, ((V)((ToNum(sg_1094) * 20D)))), ((V)((by_1008 + 4D))), ((V)(((Dp_1007 / 2D) - 4D)))), Arr(Add(x_1074, ((V)((ToNum(sg_1094) * 20D)))), ((V)((by_1008 + 6D))), ((V)(((Dp_1007 / 2D) + 6D)))), ((V)(1D)), ((V)("#9aa0a6")), Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(6D))).V));
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(o_1048, "push", FR_1087);
} else {
Call(on_1049, V.Undef, SB_1078, Arr(Call(slabX_16, V.Undef, x_1074, ((V)((by_1008 + 4D))), ((V)(((Dp_1007 / 2D) - 3.2))), ((V)((SW_1003 - 8D))), ((V)(0.8)), ((V)(0.8)), Call(shade_21, V.Undef, LEA_1009, ((V)(0.6))), NewObj(2).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
}
return default;
}, 2, "", true));
Invoke(cxs_1014, "forEach", Fn((V _arrowThis1104, int _argc1096, V x_1102, V i_1103, V _a1100, V _a1101, V[] _rest1097) => {
double z_1105 = 0;
V CB_1106 = default;
V CP_1107 = default;
z_1105 = ((Dp_1007 / 2D) - 18D);
CB_1106 = Call(box_12, V.Undef, x_1102, ((V)(by_1008)), ((V)(0D)), ((V)(CW_1004)), ((V)(24D)), ((V)((Dp_1007 - 12D))), LD_1011, Call(L__33, V.Undef, NewObj(2).Put("r", ((V)(5D))).Put("soft", ((V)(1D))).V));
CP_1107 = Call(box_12, V.Undef, x_1102, ((V)((by_1008 + 24D))), ((V)(0D)), ((V)(CW_1004)), ((V)(5D)), ((V)((Dp_1007 - 10D))), LEA_1009, Call(L__33, V.Undef, NewObj(3).Put("r", ((V)(4D))).Put("bev", ((V)(2D))).Put("soft", ((V)(1D))).V));
Invoke(o_1048, "push", CB_1106, CP_1107);
Call(on_1049, V.Undef, CP_1107, Invoke(Arr(Call(slabX_16, V.Undef, x_1102, ((V)((by_1008 + 29.1))), ((V)((-4D))), ((V)((CW_1004 - 3D))), ((V)(0.3)), ((V)(0.6)), Call(shade_21, V.Undef, LEA_1009, ((V)(0.55))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(cyl_13, V.Undef, x_1102, ((V)((by_1008 + 29.2))), ((V)(z_1105)), ((V)(6.2)), ((V)(0.5)), ((V)("#5fc8ff")), Call(em_29, V.Undef, NewObj(1).Put("n", ((V)(16D))).V))), "concat", Call(holder_56, V.Undef, x_1102, ((V)((by_1008 + 29.4))), ((V)(z_1105)), ((V)(5.2)))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))));
Call(on_1049, V.Undef, CB_1106, Arr(Call(ball_14, V.Undef, x_1102, ((V)((by_1008 + 18D))), ((V)(((Dp_1007 / 2D) - 6.5))), ((V)(1D)), ((V)("#5fc8ff")), Call(em_29, V.Undef, NewObj(2).Put("k", ((V)(2D))).Put("n", ((V)(6D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
if (SEqN(i_1103, 0D)) {
V c0_1108 = default;
V cr_1109 = default;
{ V _t1110 = Call(cup_55, V.Undef, x_1102, ((V)((by_1008 + 29D))), ((V)(z_1105)), ((V)(4D)), ((V)(12D)), ((V)("#3a8fd8")));
{ V _t1111 = ListOf(_t1110);
{ V _t1112 = GetIdx(_t1111, 0D);
c0_1108 = _t1112; }
cr_1109 = RestFrom(_t1111, 1);
} }
Invoke(o_1048, "push", c0_1108);
Call(on_1049, V.Undef, c0_1108, cr_1109);
} else {
V BU_1113 = default;
BU_1113 = Call(cyl_13, V.Undef, x_1102, ((V)((by_1008 + 29D))), ((V)(z_1105)), ((V)(4.6)), ((V)(9D)), ((V)("#ffffff")), Call(PL_34, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.82))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V));
Invoke(o_1048, "push", BU_1113);
Call(on_1049, V.Undef, BU_1113, Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis1121, int _argc1114, V k_1120, V _a1117, V _a1118, V _a1119, V[] _rest1115) => {
return Call(rod_44, V.Undef, Arr(((V)(((ToNum(x_1102) - 3.4) + (ToNum(k_1120) * 3.4)))), ((V)((by_1008 + 29.2))), ((V)((z_1105 + 4D)))), Arr(((V)(((ToNum(x_1102) - 4D) + (ToNum(k_1120) * 4D)))), ((V)((by_1008 + 37.8))), ((V)((z_1105 + 4.4)))), ((V)(0.9)), ((V)("#d9363b")), Call(PL_34, V.Undef, NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true)));
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis1129, int _argc1122, V k_1128, V _a1125, V _a1126, V _a1127, V[] _rest1123) => {
return Call(on_1049, V.Undef, BU_1113, Call(kern_54, V.Undef, ((V)(((ToNum(x_1102) - 3D) + ((ToNum(k_1128) % 3D) * 3D)))), ((V)(((by_1008 + 37.8) + (GtN(k_1128, 2D) ? 1.6 : 0D)))), ((V)(((z_1105 - 1.5) + (GtN(k_1128, 2D) ? 3D : 0D)))), ((V)(1.5)), k_1128));
}, 1, "", true));
}
return default;
}, 2, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1137, int _argc1130, V sg_1136, V _a1133, V _a1134, V _a1135, V[] _rest1131) => {
double x_1138 = 0;
V AB_1139 = default;
x_1138 = (ToNum(sg_1136) * ((Wd_1006 / 2D) - (EW_1005 / 2D)));
AB_1139 = Call(box_12, V.Undef, ((V)(x_1138)), ((V)(by_1008)), ((V)(0D)), ((V)(EW_1005)), ((V)(26D)), ((V)((Dp_1007 - 8D))), LEA_1009, Call(L__33, V.Undef, NewObj(2).Put("r", ((V)(8D))).Put("soft", ((V)(1D))).V));
Invoke(o_1048, "push", AB_1139, Call(box_12, V.Undef, ((V)(x_1138)), ((V)((by_1008 + 26D))), ((V)(0D)), ((V)(EW_1005)), ((V)(5D)), ((V)((Dp_1007 - 6D))), LL_1010, Call(L__33, V.Undef, NewObj(3).Put("r", ((V)(5D))).Put("bev", ((V)(2D))).Put("soft", ((V)(1D))).V)));
Call(on_1049, V.Undef, AB_1139, Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis1147, int _argc1140, V k_1146, V _a1143, V _a1144, V _a1145, V[] _rest1141) => {
return Call(ball_14, V.Undef, ((V)((x_1138 - (ToNum(sg_1136) * 4D)))), ((V)(((by_1008 + 20D) - (ToNum(k_1146) * 5D)))), ((V)(((Dp_1007 / 2D) - 4.2))), ((V)(1.3)), ((V)("#c9ced3")), Call(M__31, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sz", ((V)(0.5))).V));
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
return o_1048;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
egg_58 = Fn((V _arrowThis1163, int _argc1148, V x_1154, V y0_1155, V z_1156, V rx_1157, V[] _rest1149) => {
double ox_1164 = 0;
double oy_1165 = 0;
V oc_1166 = default;
V fz_1167 = default;
V ry_1158 = default;
V rz_1159 = default;
V SH_1160 = default;
V ID_1161 = default;
V o_1162 = default;
ry_1158 = (_argc1148 > 4 ? _rest1149[0] : V.Undef);
rz_1159 = (_argc1148 > 5 ? _rest1149[1] : V.Undef);
SH_1160 = (_argc1148 > 6 ? _rest1149[2] : V.Undef);
ID_1161 = (_argc1148 > 7 ? _rest1149[3] : V.Undef);
o_1162 = (_argc1148 > 8 ? _rest1149[4] : V.Undef);
o_1162 = (o_1162 is var _t1168 && Truthy(_t1168) ? _t1168 : NewObj(0).V);
ox_1164 = (ToNum(rx_1157) * ToNum((Get(o_1162, "ow") is var _t1169 && Truthy(_t1169) ? _t1169 : ((V)(0.76)))));
oy_1165 = (ToNum(ry_1158) * ToNum((Get(o_1162, "oh") is var _t1170 && Truthy(_t1170) ? _t1170 : ((V)(0.62)))));
oc_1166 = Add(y0_1155, ((V)((ToNum(ry_1158) * ToNum((Get(o_1162, "oc") is var _t1171 && Truthy(_t1171) ? _t1171 : ((V)(0.9))))))));
fz_1167 = Add(z_1156, ((V)((ToNum(rz_1159) * 0.58))));
return NewObj(6).Put("shell", Arr(Call(ball_14, V.Undef, x_1154, y0_1155, z_1156, rx_1157, SH_1160, Call(G__35, V.Undef, NewObj(4).Put("sy", ((V)((ToNum(ry_1158) / ToNum(rx_1157))))).Put("sz", ((V)((ToNum(rz_1159) / ToNum(rx_1157))))).Put("k", ((V)(9D))).Put("n", ((V)(24D))).V)))).Put("part", Arr(Call(ball_14, V.Undef, x_1154, ((V)((ToNum(oc_1166) - oy_1165))), fz_1167, ((V)(ox_1164)), ID_1161, NewObj(7).Put("sy", ((V)((oy_1165 / ox_1164)))).Put("sz", ((V)(((ToNum(rz_1159) * 0.4) / ox_1164)))).Put("k", ((V)(7D))).Put("n", ((V)(22D))).Put("part", ((V)(1D))).Put("mat", ((V)("fab"))).Put("shine", ((V)(0D))).V))).Put("oc", oc_1166).Put("ox", ((V)(ox_1164))).Put("oy", ((V)(oy_1165))).Put("fz", Add(fz_1167, ((V)((ToNum(rz_1159) * 0.4))))).V;
return default;
}, 9, "", true);
partOf_59 = Fn((V _arrowThis1179, int _argc1172, V L_1178, V _a1175, V _a1176, V _a1177, V[] _rest1173) => {
return Invoke(L_1178, "map", Fn((V _arrowThis1187, int _argc1180, V S_1186, V _a1183, V _a1184, V _a1185, V[] _rest1181) => {
Set(S_1186, "part", ((V)(1D)));
return S_1186;
return default;
}, 1, "", true));
}, 1, "", true);
Set(N_24, "pods16", Fn((V _arrowThis1195, int _argc1188, V S_1194, V _a1191, V _a1192, V _a1193, V[] _rest1189) => {
double n_1196 = 0;
double R_1197 = 0;
double CW_1198 = 0;
double Wd_1199 = 0;
double by_1200 = 0;
V xs_1201 = default;
V cxs_1202 = default;
V SH_1203 = default;
double TL_1204 = 0;
n_1196 = 3D;
R_1197 = 30D;
CW_1198 = 18D;
Wd_1199 = (((n_1196 * 2D) * R_1197) + ((n_1196 - 1D) * CW_1198));
by_1200 = 14D;
xs_1201 = Call(rep_28, V.Undef, ((V)(n_1196)), Fn((V _arrowThis1212, int _argc1205, V i_1211, V _a1208, V _a1209, V _a1210, V[] _rest1206) => {
return ((V)(((((-Wd_1199) / 2D) + R_1197) + (ToNum(i_1211) * ((2D * R_1197) + CW_1198)))));
}, 1, "", true));
cxs_1202 = Call(rep_28, V.Undef, ((V)((n_1196 - 1D))), Fn((V _arrowThis1220, int _argc1213, V i_1219, V _a1216, V _a1217, V _a1218, V[] _rest1214) => {
return Add(Add(GetK(xs_1201, i_1219), ((V)(R_1197))), ((V)((CW_1198 / 2D))));
}, 1, "", true));
SH_1203 = ((V)("#f2f4f8"));
TL_1204 = (-0.32);
return NewObj(8).Put("w", ((V)((Wd_1199 + 8D)))).Put("d", ((V)(((2D * R_1197) + 14D)))).Put("act", ((V)("sit"))).Put("seats", Invoke(xs_1201, "map", Fn((V _arrowThis1228, int _argc1221, V x_1227, V _a1224, V _a1225, V _a1226, V[] _rest1222) => {
return NewObj(3).Put("x", x_1227).Put("z", ((V)(12D))).Put("h", ((V)((by_1200 + 22D)))).V;
}, 1, "", true))).Put("anim", Call(bobA_49, V.Undef, ((V)(4D)), ((V)(3.6)))).Put("pad", Arr(((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(0D)))).Put("build", Fn((V _arrowThis1236, int _argc1229, V P_1235, V _a1232, V _a1233, V _a1234, V[] _rest1230) => {
V o_1237 = default;
V IN_1238 = default;
V IL_1239 = default;
V ID_1240 = default;
o_1237 = Arr();
IN_1238 = Get(P_1235, "a");
IL_1239 = Get(P_1235, "aL");
ID_1240 = Call(shade_21, V.Undef, Get(P_1235, "aD"), ((V)(0.8)));
Invoke(xs_1201, "forEach", Fn((V _arrowThis1248, int _argc1241, V x_1247, V _a1244, V _a1245, V _a1246, V[] _rest1242) => {
V E_1249 = default;
V piv_1250 = default;
V cz_1251 = default;
V L_1252 = default;
E_1249 = Call(egg_58, V.Undef, x_1247, ((V)((by_1200 - 6D))), ((V)(0D)), ((V)(R_1197)), ((V)(38D)), ((V)(R_1197)), SH_1203, ID_1240, NewObj(3).Put("ow", ((V)(0.74))).Put("oh", ((V)(0.6))).Put("oc", ((V)(0.92))).V);
piv_1250 = Arr(x_1247, ((V)(by_1200)), ((V)(0D)));
cz_1251 = Get(E_1249, "fz");
L_1252 = Invoke(Get(E_1249, "shell"), "concat", Get(E_1249, "part"), Call(partOf_59, V.Undef, Arr(Call(pillowY_19, V.Undef, x_1247, ((V)((by_1200 + 6D))), ((V)((ToNum(cz_1251) - 2D))), ((V)(38D)), ((V)(11D)), ((V)(20D)), IL_1239, Call(L__33, V.Undef)), Call(pillowZ_20, V.Undef, x_1247, ((V)((by_1200 + 14D))), ((V)((ToNum(cz_1251) - 5D))), ((V)(36D)), ((V)(34D)), ((V)(7D)), IN_1238, Call(L__33, V.Undef)), Call(pillowZ_20, V.Undef, x_1247, ((V)((by_1200 + 44D))), ((V)((ToNum(cz_1251) - 6D))), ((V)(24D)), ((V)(10D)), ((V)(6D)), IL_1239, Call(L__33, V.Undef)), Call(ball_14, V.Undef, x_1247, ((V)((by_1200 + 53D))), ((V)((ToNum(cz_1251) - 9D))), ((V)(2.4)), ((V)("#7ff0ff")), Call(em_29, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("part", ((V)(1D))).V)))));
Invoke(Call(tiltAll_41, V.Undef, L_1252, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(TL_1204)), piv_1250), "forEach", Fn((V _arrowThis1260, int _argc1253, V s_1259, V _a1256, V _a1257, V _a1258, V[] _rest1254) => {
return Invoke(o_1237, "push", s_1259);
}, 1, "", true));
Invoke(o_1237, "push", Call(cyl_13, V.Undef, x_1247, ((V)((by_1200 - 9D))), ((V)(0D)), ((V)(10D)), ((V)(1.4)), ((V)("#8ff6ff")), Call(em_29, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
return default;
}, 1, "", true));
Invoke(cxs_1202, "forEach", Fn((V _arrowThis1269, int _argc1261, V x_1267, V i_1268, V _a1265, V _a1266, V[] _rest1262) => {
Invoke(o_1237, "push", Call(cyl_13, V.Undef, x_1267, ((V)((by_1200 - 4D))), ((V)(6D)), ((V)(7D)), ((V)(30D)), SH_1203, Call(G__35, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(4D)), ((V)(0D)), ((V)(1D))), Arr(((V)(30D)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_13, V.Undef, x_1267, ((V)((by_1200 + 26D))), ((V)(6D)), ((V)(7.4)), ((V)(1D)), ((V)("#7ff0ff")), Call(em_29, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_13, V.Undef, x_1267, ((V)((by_1200 + 26.6))), ((V)(6D)), ((V)(5D)), ((V)(0.6)), ((V)("#1a1d2a")), NewObj(1).Put("n", ((V)(14D))).V));
Invoke(o_1237, "push", Call(cyl_13, V.Undef, x_1267, ((V)((by_1200 + 27D))), ((V)(6D)), ((V)(3D)), ((V)(9D)), ((V)("#bfefff")), NewObj(3).Put("n", ((V)(12D))).Put("op", ((V)(0.55))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_13, V.Undef, x_1267, ((V)((by_1200 + 27.4))), ((V)(6D)), ((V)(2.5)), ((V)(6D)), ((V)((Truthy(i_1268) ? "#ff6fae" : "#7ff0ff"))), Call(em_29, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("op", ((V)(0.85))).V)), Call(rod_44, V.Undef, Arr(x_1267, ((V)((by_1200 + 36D))), ((V)(6D))), Arr(Add(x_1267, ((V)(1.4))), ((V)((by_1200 + 42D))), ((V)(5D))), ((V)(0.5)), ((V)("#ffffff")), Call(PL_34, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)));
return default;
}, 2, "", true));
return o_1237;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1277, int _argc1270, V c_1276, V _a1273, V _a1274, V _a1275, V[] _rest1271) => {
JsStrBuf u_1278 = null;
u_1278 = new JsStrBuf("<defs><radialGradient id=\"p16hv\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#8ff6ff\" stop-opacity=\"0.85\"/><stop offset=\"0.55\" stop-color=\"#5fd8ff\" stop-opacity=\"0.35\"/><stop offset=\"1\" stop-color=\"#5fd8ff\" stop-opacity=\"0\"/></radialGradient></defs>");
Invoke(xs_1201, "forEach", Fn((V _arrowThis1287, int _argc1279, V x_1285, V i_1286, V _a1283, V _a1284, V[] _rest1280) => {
u_1278.V(Add(Call(fxEll_50, V.Undef, c_1276, x_1285, ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)("url(#p16hv)")), Call(an_48, V.Undef, ((V)("opacity")), ((V)("0.7;1;0.7")), ((V)(3.6)), ((V)(((-ToNum(i_1286)) * 0.4))))), Call(fxEll_50, V.Undef, c_1276, x_1285, ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(JsStrBuf.Begin().S("none\" stroke=\"#8ff6ff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(Get(c_1276, "k"))))))).S("\" stroke-opacity=\"0.8").End())), Add(Add(Call(an_48, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((8D * ToNum(Get(c_1276, "k"))))))).S(";").V(Call(f1_23, V.Undef, ((V)((30D * ToNum(Get(c_1276, "k"))))))).End())), ((V)(2.4)), ((V)(((-ToNum(i_1286)) * 0.8)))), Call(an_48, V.Undef, ((V)("ry")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)(((8D * ToNum(Get(c_1276, "k"))) * ToNum(Get(X_9, "SA"))))))).S(";").V(Call(f1_23, V.Undef, ((V)(((30D * ToNum(Get(c_1276, "k"))) * ToNum(Get(X_9, "SA"))))))).End())), ((V)(2.4)), ((V)(((-ToNum(i_1286)) * 0.8))))), Call(an_48, V.Undef, ((V)("stroke-opacity")), ((V)("0.9;0")), ((V)(2.4)), ((V)(((-ToNum(i_1286)) * 0.8))))))));
return default;
}, 2, "", true));
return NewObj(1).Put("under", ((V)(u_1278.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "royal16", Fn((V _arrowThis1295, int _argc1288, V S_1294, V _a1291, V _a1292, V _a1293, V[] _rest1289) => {
double n_1296 = 0;
double SW_1297 = 0;
double AW_1298 = 0;
double Wd_1299 = 0;
double Dp_1300 = 0;
V MAH_1301 = default;
V MAL_1302 = default;
V VEL_1303 = default;
V VL_1304 = default;
V VD_1305 = default;
V xs_1306 = default;
V axs_1307 = default;
double AR_1308 = 0;
V archTop_1309 = default;
n_1296 = 3D;
SW_1297 = 56D;
AW_1298 = 15D;
Wd_1299 = ((n_1296 * SW_1297) + ((n_1296 + 1D) * AW_1298));
Dp_1300 = 100D;
MAH_1301 = ((V)("#6a2a1c"));
MAL_1302 = Call(shade_21, V.Undef, MAH_1301, ((V)(1.22)));
VEL_1303 = ((V)("#a3202f"));
VL_1304 = Call(shade_21, V.Undef, VEL_1303, ((V)(1.16)));
VD_1305 = Call(shade_21, V.Undef, VEL_1303, ((V)(0.76)));
xs_1306 = Call(rep_28, V.Undef, ((V)(n_1296)), Fn((V _arrowThis1317, int _argc1310, V i_1316, V _a1313, V _a1314, V _a1315, V[] _rest1311) => {
return ((V)((((((-Wd_1299) / 2D) + AW_1298) + (SW_1297 / 2D)) + (ToNum(i_1316) * (SW_1297 + AW_1298)))));
}, 1, "", true));
axs_1307 = Call(rep_28, V.Undef, ((V)((n_1296 + 1D))), Fn((V _arrowThis1325, int _argc1318, V i_1324, V _a1321, V _a1322, V _a1323, V[] _rest1319) => {
return ((V)(((((-Wd_1299) / 2D) + (AW_1298 / 2D)) + (ToNum(i_1324) * (SW_1297 + AW_1298)))));
}, 1, "", true));
AR_1308 = 26D;
archTop_1309 = Fn((V _arrowThis1333, int _argc1326, V xo_1332, V _a1329, V _a1330, V _a1331, V[] _rest1327) => {
return ((V)((71D + System.Math.Sqrt(Max(0D, ((AR_1308 * AR_1308) - Pow(Max(0D, (System.Math.Abs(ToNum(xo_1332)) - 1D)), 2D)))))));
}, 1, "", true);
return NewObj(5).Put("w", ((V)((Wd_1299 + 10D)))).Put("d", ((V)((Dp_1300 + 6D)))).Put("act", ((V)("sit"))).Put("seats", Invoke(xs_1306, "map", Fn((V _arrowThis1341, int _argc1334, V x_1340, V _a1337, V _a1338, V _a1339, V[] _rest1335) => {
return NewObj(3).Put("x", x_1340).Put("z", ((V)(10D))).Put("h", ((V)(34D))).V;
}, 1, "", true))).Put("build", Fn((V _arrowThis1348, int _argc1342, V _a1344, V _a1345, V _a1346, V _a1347, V[] _rest1343) => {
V o_1349 = default;
o_1349 = Arr();
Invoke(o_1349, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((Wd_1299 + 8D))), ((V)(8D)), ((V)((Dp_1300 + 4D))), MAH_1301, Call(W__30, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("bev", ((V)(1.2))).V)), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(6.2)), ((V)(((Dp_1300 / 2D) + 2.1))), ((V)((Wd_1299 + 7D))), ((V)(1.6)), ((V)(1.2)), GOLD_26, Call(M__31, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
Call(rep_28, V.Undef, ((V)(9D)), Fn((V _arrowThis1357, int _argc1350, V i_1356, V _a1353, V _a1354, V _a1355, V[] _rest1351) => {
return Invoke(o_1349, "push", Call(ball_14, V.Undef, ((V)(((((-Wd_1299) / 2D) + 10D) + ((ToNum(i_1356) * (Wd_1299 - 20D)) / 8D)))), ((V)(2.6)), ((V)(((Dp_1300 / 2D) + 2.4))), ((V)(1.2)), ((V)("#ffd98a")), Call(em_29, V.Undef, NewObj(2).Put("k", ((V)(2D))).Put("n", ((V)(6D))).V)));
}, 1, "", true));
Invoke(xs_1306, "forEach", Fn((V _arrowThis1365, int _argc1358, V x_1364, V _a1361, V _a1362, V _a1363, V[] _rest1359) => {
double bz_1366 = 0;
V B_1367 = default;
bz_1366 = (((-Dp_1300) / 2D) + 14D);
Invoke(o_1349, "push", Call(box_12, V.Undef, x_1364, ((V)(8D)), ((V)(6D)), ((V)((SW_1297 - 2D))), ((V)(15D)), ((V)((Dp_1300 - 22D))), VD_1305, Call(F__32, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)), Call(pillowY_19, V.Undef, x_1364, ((V)(22D)), ((V)(9D)), ((V)((SW_1297 - 6D))), ((V)(11D)), ((V)((Dp_1300 - 36D))), VL_1304, Call(F__32, V.Undef)), Call(slabX_16, V.Undef, x_1364, ((V)(22.6)), ((V)(((9D + ((Dp_1300 - 36D) / 2D)) - 0.4))), ((V)((SW_1297 - 10D))), ((V)(1.2)), ((V)(1D)), GOLD_26, Call(M__31, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).V)));
B_1367 = Arr(Call(slab_15, V.Undef, x_1364, ((V)(20D)), ((V)((bz_1366 - 1.8))), ((V)((SW_1297 + 2D))), ((V)(78D)), ((V)(10D)), GOLD_26, Call(M__31, V.Undef, NewObj(2).Put("r", ((V)((AR_1308 + 1D)))).Put("rb", ((V)(4D))).V)), Call(slab_15, V.Undef, x_1364, ((V)(21D)), ((V)(bz_1366)), ((V)((SW_1297 - 2D))), ((V)(76D)), ((V)(13D)), VEL_1303, Call(F__32, V.Undef, NewObj(2).Put("r", ((V)(AR_1308))).Put("rb", ((V)(4D))).V)));
Invoke(Arr(((V)((-19.5))), ((V)((-6.5))), ((V)(6.5)), ((V)(19.5))), "forEach", Fn((V _arrowThis1375, int _argc1368, V xo_1374, V _a1371, V _a1372, V _a1373, V[] _rest1369) => {
double top_1376 = 0;
top_1376 = (ToNum(Call(archTop_1309, V.Undef, xo_1374)) - 5.5);
Invoke(B_1367, "push", Call(pillowZ_20, V.Undef, Add(x_1364, xo_1374), ((V)(31D)), ((V)((bz_1366 + 10D))), ((V)(12.6)), ((V)((top_1376 - 31D))), ((V)(5.4)), VEL_1303, Call(F__32, V.Undef)));
return default;
}, 1, "", true));
Invoke(B_1367, "push", Call(ball_14, V.Undef, x_1364, ((V)(97.6)), ((V)((bz_1366 - 1.8))), ((V)(3D)), GOLD_26, Call(M__31, V.Undef, NewObj(3).Put("sz", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)));
Invoke(Call(tiltAll_41, V.Undef, B_1367, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.05))), Arr(x_1364, ((V)(22D)), ((V)(bz_1366)))), "forEach", Fn((V _arrowThis1384, int _argc1377, V s_1383, V _a1380, V _a1381, V _a1382, V[] _rest1378) => {
return Invoke(o_1349, "push", s_1383);
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(axs_1307, "forEach", Fn((V _arrowThis1393, int _argc1385, V x_1391, V i_1392, V _a1389, V _a1390, V[] _rest1386) => {
double z_1394 = 0;
double zf_1395 = 0;
z_1394 = ((Dp_1300 / 2D) - 16D);
zf_1395 = (2D + ((Dp_1300 - 14D) / 2D));
Invoke(o_1349, "push", Call(box_12, V.Undef, x_1391, ((V)(8D)), ((V)(2D)), ((V)(AW_1298)), ((V)(27D)), ((V)((Dp_1300 - 14D))), MAH_1301, Call(W__30, V.Undef, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(1.4))).V)), Call(box_12, V.Undef, x_1391, ((V)(35D)), ((V)(2D)), ((V)((AW_1298 + 2D))), ((V)(5D)), ((V)((Dp_1300 - 10D))), VEL_1303, Call(F__32, V.Undef, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(2.2))).V)));
Invoke(o_1349, "push", Call(slab_15, V.Undef, x_1391, ((V)(13D)), ((V)((zf_1395 + 0.2))), ((V)((AW_1298 - 5D))), ((V)(16D)), ((V)(0.6)), MAL_1302, Call(W__30, V.Undef, NewObj(2).Put("r", ((V)(2.4))).Put("noOut", ((V)(1D))).V)), Call(disc_18, V.Undef, x_1391, ((V)(21D)), ((V)((zf_1395 + 0.6))), ((V)(3D)), ((V)(0.8)), GOLD_26, Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(ball_14, V.Undef, x_1391, ((V)(20.4)), ((V)((zf_1395 + 1.3))), ((V)(1.2)), Call(shade_21, V.Undef, GOLD_26, ((V)(1.2))), Call(M__31, V.Undef, NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sz", ((V)(0.4))).Put("noOut", ((V)(1D))).V)));
Invoke(Call(holder_56, V.Undef, x_1391, ((V)(40D)), ((V)(z_1394)), ((V)(4.8)), GOLD_26), "forEach", Fn((V _arrowThis1403, int _argc1396, V s_1402, V _a1399, V _a1400, V _a1401, V[] _rest1397) => {
return Invoke(o_1349, "push", s_1402);
}, 1, "", true));
if (SEqN(i_1392, 1D)) {
Invoke(Call(cup_55, V.Undef, x_1391, ((V)(40.6)), ((V)(z_1394)), ((V)(3.8)), ((V)(12D)), ((V)("#ffffff")), ((V)("#d9363b"))), "forEach", Fn((V _arrowThis1411, int _argc1404, V s_1410, V _a1407, V _a1408, V _a1409, V[] _rest1405) => {
return Invoke(o_1349, "push", s_1410);
}, 1, "", true));
}
if (SEqN(i_1392, 2D)) {
Invoke(o_1349, "push", Call(cyl_13, V.Undef, x_1391, ((V)(40.6)), ((V)(z_1394)), ((V)(4.4)), ((V)(9D)), ((V)("#d4a640")), Call(M__31, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V)));
Call(rep_28, V.Undef, ((V)(6D)), Fn((V _arrowThis1419, int _argc1412, V k_1418, V _a1415, V _a1416, V _a1417, V[] _rest1413) => {
return Invoke(Call(kern_54, V.Undef, ((V)(((ToNum(x_1391) - 2.8) + ((ToNum(k_1418) % 3D) * 2.8)))), ((V)((49.4 + (GtN(k_1418, 2D) ? 1.6 : 0D)))), ((V)(((z_1394 - 1.4) + (GtN(k_1418, 2D) ? 2.8 : 0D)))), ((V)(1.5)), k_1418), "forEach", Fn((V _arrowThis1427, int _argc1420, V s_1426, V _a1423, V _a1424, V _a1425, V[] _rest1421) => {
return Invoke(o_1349, "push", s_1426);
}, 1, "", true));
}, 1, "", true));
}
return default;
}, 2, "", true));
return o_1349;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "camp16", Fn((V _arrowThis1435, int _argc1428, V S_1434, V _a1431, V _a1432, V _a1433, V[] _rest1429) => {
V FR_1436 = default;
V CAN_1437 = default;
V CL_1438 = default;
V CD_1439 = default;
double hw_1440 = 0;
double hd_1441 = 0;
double ht_1442 = 0;
FR_1436 = ((V)("#2c2e33"));
CAN_1437 = ((V)("#3f7a52"));
CL_1438 = Call(shade_21, V.Undef, CAN_1437, ((V)(1.12)));
CD_1439 = Call(shade_21, V.Undef, CAN_1437, ((V)(0.72)));
hw_1440 = 22D;
hd_1441 = 19D;
ht_1442 = 29D;
return NewObj(5).Put("w", ((V)(64D))).Put("d", ((V)(52D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(2D))).Put("h", ((V)(31D))).V)).Put("build", Fn((V _arrowThis1449, int _argc1443, V _a1445, V _a1446, V _a1447, V _a1448, V[] _rest1444) => {
V o_1450 = default;
V T_1451 = default;
o_1450 = Arr();
T_1451 = Fn((V _arrowThis1460, int _argc1452, V a_1458, V b_1459, V _a1456, V _a1457, V[] _rest1453) => {
return Invoke(o_1450, "push", Call(rod_44, V.Undef, a_1458, b_1459, ((V)(1.15)), FR_1436, Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 2, "", true);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1468, int _argc1461, V sz_1467, V _a1464, V _a1465, V _a1466, V[] _rest1462) => {
Call(T_1451, V.Undef, Arr(((V)((-hw_1440))), ((V)(0D)), ((V)((ToNum(sz_1467) * hd_1441)))), Arr(((V)(hw_1440)), ((V)(ht_1442)), ((V)((ToNum(sz_1467) * hd_1441)))));
Call(T_1451, V.Undef, Arr(((V)(hw_1440)), ((V)(0D)), ((V)((ToNum(sz_1467) * hd_1441)))), Arr(((V)((-hw_1440))), ((V)(ht_1442)), ((V)((ToNum(sz_1467) * hd_1441)))));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1476, int _argc1469, V sx_1475, V _a1472, V _a1473, V _a1474, V[] _rest1470) => {
Call(T_1451, V.Undef, Arr(((V)((ToNum(sx_1475) * hw_1440))), ((V)(0D)), ((V)(hd_1441))), Arr(((V)((ToNum(sx_1475) * hw_1440))), ((V)(ht_1442)), ((V)((-hd_1441)))));
Call(T_1451, V.Undef, Arr(((V)((ToNum(sx_1475) * hw_1440))), ((V)(0D)), ((V)((-hd_1441)))), Arr(((V)((ToNum(sx_1475) * hw_1440))), ((V)(ht_1442)), ((V)(hd_1441))));
Call(T_1451, V.Undef, Arr(((V)((ToNum(sx_1475) * (hw_1440 - 1D)))), ((V)(ht_1442)), ((V)((-hd_1441)))), Arr(((V)((ToNum(sx_1475) * (hw_1440 - 2D)))), ((V)(64D)), ((V)((-26D)))));
Call(T_1451, V.Undef, Arr(((V)((ToNum(sx_1475) * hw_1440))), ((V)(ht_1442)), ((V)(hd_1441))), Arr(((V)((ToNum(sx_1475) * (hw_1440 + 1D)))), ((V)(44D)), ((V)(17D))));
Call(T_1451, V.Undef, Arr(((V)((ToNum(sx_1475) * (hw_1440 + 1D)))), ((V)(44D)), ((V)(17D))), Arr(((V)((ToNum(sx_1475) * (hw_1440 - 1.5)))), ((V)(46D)), ((V)((-23D)))));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1484, int _argc1477, V sz_1483, V _a1480, V _a1481, V _a1482, V[] _rest1478) => {
return Invoke(o_1450, "push", Call(ball_14, V.Undef, ((V)((ToNum(sx_1475) * hw_1440))), ((V)((-0.6))), ((V)((ToNum(sz_1483) * hd_1441))), ((V)(2D)), ((V)("#18191c")), NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sy", ((V)(0.6))).Put("shine", ((V)(0D))).V));
}, 1, "", true));
Invoke(o_1450, "push", Call(box_12, V.Undef, ((V)((ToNum(sx_1475) * (hw_1440 + 0.5)))), ((V)(45.6)), ((V)((-3D))), ((V)(6D)), ((V)(1.6)), ((V)(36D)), CAN_1437, Call(F__32, V.Undef, NewObj(2).Put("r", ((V)(1.4))).Put("yaw", ((V)(0D))).V)));
return default;
}, 1, "", true));
Invoke(o_1450, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(26.5)), ((V)(0D)), ((V)(42D)), ((V)(3D)), ((V)(38D)), CAN_1437, Call(F__32, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("bev", ((V)(1D))).V)), Call(pillowY_19, V.Undef, ((V)(0D)), ((V)(25.4)), ((V)(0D)), ((V)(34D)), ((V)(4D)), ((V)(30D)), CL_1438, Call(F__32, V.Undef)), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(27D)), ((V)((hd_1441 - 0.4))), ((V)(42D)), ((V)(2.4)), ((V)(1D)), CD_1439, Call(F__32, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
Invoke(Call(tiltAll_41, V.Undef, Arr(Call(slab_15, V.Undef, ((V)(0D)), ((V)(33D)), ((V)(((-hd_1441) - 0.6))), ((V)(39D)), ((V)(29D)), ((V)(2.2)), CAN_1437, Call(F__32, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(((-hd_1441) - 0.6))), ((V)(39D)), ((V)(2.4)), ((V)(2.6)), CD_1439, Call(F__32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(33D)), ((V)(((-hd_1441) - 0.6))), ((V)(39D)), ((V)(2.4)), ((V)(2.6)), CD_1439, Call(F__32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.197))), Arr(((V)(0D)), ((V)(ht_1442)), ((V)((-hd_1441))))), "forEach", Fn((V _arrowThis1492, int _argc1485, V s_1491, V _a1488, V _a1489, V _a1490, V[] _rest1486) => {
return Invoke(o_1450, "push", s_1491);
}, 1, "", true));
Invoke(o_1450, "push", Call(rod_44, V.Undef, Arr(((V)((hw_1440 + 1D))), ((V)(42D)), ((V)(13D))), Arr(((V)((hw_1440 + 7D))), ((V)(40D)), ((V)(13D))), ((V)(0.8)), FR_1436, Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(arcW_17, V.Undef, ((V)((hw_1440 + 8D))), ((V)(33D)), ((V)(13D)), ((V)(5D)), ((V)(5D)), ((V)(0.7)), ((V)(7D)), ((V)(0D)), ((V)((2D * PI_25))), CD_1439, Call(F__32, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, ((V)((hw_1440 + 8D))), ((V)(33D)), ((V)(13D)), ((V)(4.6)), ((V)(0.6)), CD_1439, NewObj(1).Put("n", ((V)(12D))).V));
Invoke(o_1450, "push", Call(cyl_13, V.Undef, ((V)((hw_1440 + 8D))), ((V)(33.4)), ((V)(13D)), ((V)(3.6)), ((V)(11D)), ((V)("#d9363b")), Call(M__31, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(0.8)), ((V)(0D)), ((V)(1D))), Arr(((V)(10D)), ((V)(0D)), ((V)(1D))), Arr(((V)(11D)), ((V)(0D)), ((V)(0.82))))).V)), Call(cyl_13, V.Undef, ((V)((hw_1440 + 8D))), ((V)(38D)), ((V)(13D)), ((V)(3.7)), ((V)(2D)), ((V)("#ffffff")), NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)((hw_1440 + 8D))), ((V)(44.4)), ((V)(13D)), ((V)(3D)), ((V)(0.4)), CH_27, Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)));
return o_1450;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
BBR_60 = Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(36D)), ((V)(33D))), Arr(((V)(3D)), ((V)(0D)), ((V)(4D)), ((V)(42D)), ((V)(38D))), Arr(((V)(9D)), ((V)(0D)), ((V)(4D)), ((V)(45D)), ((V)(41D))), Arr(((V)(15D)), ((V)(0D)), ((V)(3D)), ((V)(45D)), ((V)(40.5))), Arr(((V)(20D)), ((V)(0D)), ((V)(1D)), ((V)(43D)), ((V)(37D))), Arr(((V)(24D)), ((V)(0D)), ((V)((-2D))), ((V)(40D)), ((V)(32D))), Arr(((V)(27D)), ((V)(0D)), ((V)((-7D))), ((V)(36.5)), ((V)(26D))), Arr(((V)(30D)), ((V)(0D)), ((V)((-11D))), ((V)(33.5)), ((V)(21D))), Arr(((V)(35D)), ((V)(0D)), ((V)((-14D))), ((V)(30D)), ((V)(17D))), Arr(((V)(40D)), ((V)(0D)), ((V)((-15D))), ((V)(26D)), ((V)(14D))), Arr(((V)(44D)), ((V)(0D)), ((V)((-15.5))), ((V)(19.5)), ((V)(10.5))), Arr(((V)(46.6)), ((V)(0D)), ((V)((-15.5))), ((V)(10.5)), ((V)(6D))), Arr(((V)(47.4)), ((V)(0D)), ((V)((-15.5))), ((V)(2D)), ((V)(1.4))));
bbAt_61 = Fn((V _arrowThis1501, int _argc1493, V k_1499, V f_1500, V _a1497, V _a1498, V[] _rest1494) => {
V q_1502 = default;
q_1502 = GetK(BBR_60, k_1499);
return Arr(Add(GetIdx(q_1502, 1D), ((V)((ToNum(GetIdx(q_1502, 3D)) * FdLibm.Cos(ToNum(f_1500)))))), GetIdx(q_1502, 0D), Add(GetIdx(q_1502, 2D), ((V)((ToNum(GetIdx(q_1502, 4D)) * FdLibm.Sin(ToNum(f_1500)))))));
return default;
}, 2, "", true);
Set(N_24, "bean16", Fn((V _arrowThis1510, int _argc1503, V S_1509, V _a1506, V _a1507, V _a1508, V[] _rest1504) => {
return NewObj(6).Put("w", ((V)(92D))).Put("d", ((V)(84D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(13D))).Put("h", ((V)(27D))).V)).Put("build", Fn((V _arrowThis1518, int _argc1511, V P_1517, V _a1514, V _a1515, V _a1516, V[] _rest1512) => {
V o_1519 = default;
V A_1520 = default;
V AD_1521 = default;
o_1519 = Arr();
A_1520 = Get(P_1517, "a");
AD_1521 = Get(P_1517, "aD");
Invoke(o_1519, "push", Call(loft_43, V.Undef, BBR_60, A_1520, Call(F__32, V.Undef, NewObj(1).Put("n", ((V)(30D))).V)));
{
double f_1522 = 0;
V q_1523 = default;
f_1522 = (PI_25 * 0.3);
q_1523 = Call(bbAt_61, V.Undef, ((V)(3D)), ((V)(f_1522)));
Invoke(o_1519, "push", Call(box_12, V.Undef, Add(GetIdx(q_1523, 0D), ((V)((FdLibm.Cos(f_1522) * 0.7)))), ((V)(9D)), Add(GetIdx(q_1523, 2D), ((V)((FdLibm.Sin(f_1522) * 0.7)))), ((V)(6D)), ((V)(6.4)), ((V)(0.9)), ((V)("#f3ead8")), NewObj(4).Put("r", ((V)(0.6))).Put("yaw", ((V)((f_1522 + (PI_25 / 2D))))).Put("noOut", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(box_12, V.Undef, Add(GetIdx(q_1523, 0D), ((V)((FdLibm.Cos(f_1522) * 1.2)))), ((V)(12.8)), Add(GetIdx(q_1523, 2D), ((V)((FdLibm.Sin(f_1522) * 1.2)))), ((V)(6.1)), ((V)(1.4)), ((V)(0.4)), ((V)("#d9363b")), NewObj(3).Put("r", ((V)(0D))).Put("yaw", ((V)((f_1522 + (PI_25 / 2D))))).Put("noOut", ((V)(1D))).V));
}
return o_1519;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1531, int _argc1524, V c_1530, V _a1527, V _a1528, V _a1529, V[] _rest1525) => {
V A_1532 = default;
V DK_1533 = default;
V LT_1534 = default;
V o0_1535 = default;
V e1_1536 = default;
double cT_1537 = 0;
double sT_1538 = 0;
V k_1539 = default;
V vis_1540 = default;
JsStrBuf wl_1541 = null;
V seam_1542 = default;
V sm_1543 = default;
V dn_1544 = default;
double dr_1545 = 0;
V crease_1546 = default;
V rim_1547 = default;
V fold_1548 = default;
V lip_1549 = default;
A_1532 = (Get(Get(c_1530, "P"), "a") is var _t1550 && Truthy(_t1550) ? _t1550 : ((V)("#d99a35")));
DK_1533 = Call(shade_21, V.Undef, A_1532, ((V)(0.5)));
LT_1534 = Call(mix_22, V.Undef, A_1532, ((V)("#ffffff")), ((V)(0.45)));
o0_1535 = Invoke(c_1530, "p", ((V)(0D)), ((V)(0D)), ((V)(0D)));
e1_1536 = Invoke(c_1530, "p", ((V)(1D)), ((V)(0D)), ((V)(0D)));
cT_1537 = ((ToNum(GetIdx(e1_1536, 0D)) - ToNum(GetIdx(o0_1535, 0D))) / ToNum(Get(c_1530, "k")));
sT_1538 = ((-(ToNum(GetIdx(e1_1536, 1D)) - ToNum(GetIdx(o0_1535, 1D)))) / (ToNum(Get(c_1530, "k")) * ToNum(Get(X_9, "SA"))));
k_1539 = Get(c_1530, "k");
vis_1540 = Fn((V _arrowThis1559, int _argc1551, V k2_1557, V f_1558, V _a1555, V _a1556, V[] _rest1552) => {
V q_1560 = default;
q_1560 = GetK(BBR_60, k2_1557);
return ((V)((((-(FdLibm.Cos(ToNum(f_1558)) / ToNum(GetIdx(q_1560, 3D)))) * sT_1538) + ((FdLibm.Sin(ToNum(f_1558)) / ToNum(GetIdx(q_1560, 4D))) * cT_1537))));
return default;
}, 2, "", true);
wl_1541 = new JsStrBuf("");
{
double j_1561 = 0;
j_1561 = 0D;
while (true) {
if (!((j_1561 < 34D))) break;
double f_1563 = 0;
V seg_1564 = default;
V pts_1565 = default;
f_1563 = (((j_1561 / 34D) * 2D) * PI_25);
seg_1564 = Arr();
pts_1565 = Arr();
{
double k2_1566 = 0;
k2_1566 = 1D;
while (true) {
if (!((k2_1566 < (ToNum(Get(BBR_60, "length")) - 1D)))) break;
if (GtN(Call(vis_1540, V.Undef, ((V)(k2_1566)), ((V)(f_1563))), 0.004)) {
Invoke(pts_1565, "push", Call(P2_47, V.Undef, InvokeSpread(c_1530, "p", new ArrBuilder().Spread(Call(bbAt_61, V.Undef, ((V)(k2_1566)), ((V)(f_1563)))).V)));
} else {
if (GtN(Get(pts_1565, "length"), 1D)) {
Invoke(seg_1564, "push", pts_1565);
}
pts_1565 = Arr();
}
k2_1566++;
}
}
if (GtN(Get(pts_1565, "length"), 1D)) {
Invoke(seg_1564, "push", pts_1565);
}
Invoke(seg_1564, "forEach", Fn((V _arrowThis1575, int _argc1568, V P_1574, V _a1571, V _a1572, V _a1573, V[] _rest1569) => {
return ((V)(wl_1541.S("M").V(Invoke(P_1574, "join", ((V)("L")))).Str));
}, 1, "", true));
j_1561++;
}
}
seam_1542 = Fn((V _arrowThis1583, int _argc1576, V k2_1582, V _a1579, V _a1580, V _a1581, V[] _rest1577) => {
JsStrBuf s_1584 = null;
V pts_1585 = default;
s_1584 = new JsStrBuf("");
pts_1585 = Arr();
{
double j_1586 = 0;
j_1586 = 0D;
while (true) {
if (!((j_1586 <= 56D))) break;
double f_1588 = 0;
f_1588 = (((j_1586 / 56D) * 2D) * PI_25);
if (GtN(Call(vis_1540, V.Undef, k2_1582, ((V)(f_1588))), 0.004)) {
Invoke(pts_1585, "push", Call(P2_47, V.Undef, InvokeSpread(c_1530, "p", new ArrBuilder().Spread(Call(bbAt_61, V.Undef, k2_1582, ((V)(f_1588)))).V)));
} else {
if (GtN(Get(pts_1585, "length"), 1D)) {
s_1584.S("M").V(Invoke(pts_1585, "join", ((V)("L"))));
}
pts_1585 = Arr();
}
j_1586++;
}
}
if (GtN(Get(pts_1585, "length"), 1D)) {
s_1584.S("M").V(Invoke(pts_1585, "join", ((V)("L"))));
}
return ((V)(s_1584.Str));
return default;
}, 1, "", true);
sm_1543 = Call(seam_1542, V.Undef, ((V)(2D)));
dn_1544 = Invoke(c_1530, "p", ((V)(0D)), ((V)(26.4)), ((V)(14D)));
dr_1545 = (20D * ToNum(k_1539));
crease_1546 = Invoke(Invoke(Arr(Arr(((V)((-15D))), ((V)(24D)), ((V)(26D)), ((V)((-24D))), ((V)(16D)), ((V)(32D))), Arr(((V)(13D)), ((V)(24.5)), ((V)(27D)), ((V)(22D)), ((V)(17D)), ((V)(33D))), Arr(((V)((-26D))), ((V)(26.5)), ((V)(6D)), ((V)((-34D))), ((V)(20D)), ((V)(14D))), Arr(((V)(26D)), ((V)(27D)), ((V)(7D)), ((V)(34D)), ((V)(20.5)), ((V)(15D)))), "map", Fn((V _arrowThis1608, int _argc1589, V _a1591, V _a1592, V _a1593, V _a1594, V[] _rest1590) => {
V a_1609 = default;
V b_1610 = default;
V m_1611 = default;
V x0_1597 = default;
V y0_1599 = default;
V z0_1601 = default;
V x1_1603 = default;
V y1_1605 = default;
V z1_1607 = default;
{ V _t1595 = ListOf(_a1591);
{ V _t1596 = GetIdx(_t1595, 0D);
x0_1597 = _t1596; }
{ V _t1598 = GetIdx(_t1595, 1D);
y0_1599 = _t1598; }
{ V _t1600 = GetIdx(_t1595, 2D);
z0_1601 = _t1600; }
{ V _t1602 = GetIdx(_t1595, 3D);
x1_1603 = _t1602; }
{ V _t1604 = GetIdx(_t1595, 4D);
y1_1605 = _t1604; }
{ V _t1606 = GetIdx(_t1595, 5D);
z1_1607 = _t1606; }
}
a_1609 = Invoke(c_1530, "p", x0_1597, y0_1599, z0_1601);
b_1610 = Invoke(c_1530, "p", x1_1603, y1_1605, z1_1607);
m_1611 = Invoke(c_1530, "p", ((V)(((ToNum(Add(x0_1597, x1_1603)) / 2D) + (LtN(x0_1597, 0D) ? (-2D) : 2D)))), ((V)(((ToNum(Add(y0_1599, y1_1605)) / 2D) + 1.5))), ((V)((ToNum(Add(z0_1601, z1_1607)) / 2D))));
return ((V)(JsStrBuf.Begin().S("M").V(Call(P2_47, V.Undef, a_1609)).S("Q").V(Call(P2_47, V.Undef, m_1611)).S(" ").V(Call(P2_47, V.Undef, b_1610)).End()));
return default;
}, 1, "", true)), "join", ((V)("")));
rim_1547 = Call(Fn((V _arrowThis1618, int _argc1612, V _a1614, V _a1615, V _a1616, V _a1617, V[] _rest1613) => {
V a_1619 = default;
V m_1620 = default;
V b_1621 = default;
a_1619 = Invoke(c_1530, "p", ((V)((-22D))), ((V)(29.6)), ((V)(1D)));
m_1620 = Invoke(c_1530, "p", ((V)(0D)), ((V)(32.6)), ((V)((-6D))));
b_1621 = Invoke(c_1530, "p", ((V)(22D)), ((V)(29.6)), ((V)(1D)));
return ((V)(JsStrBuf.Begin().S("M").V(Call(P2_47, V.Undef, a_1619)).S("Q").V(Call(P2_47, V.Undef, m_1620)).S(" ").V(Call(P2_47, V.Undef, b_1621)).End()));
return default;
}, 0, "", true), V.Undef);
fold_1548 = Call(Fn((V _arrowThis1628, int _argc1622, V _a1624, V _a1625, V _a1626, V _a1627, V[] _rest1623) => {
V a_1629 = default;
V m_1630 = default;
V b_1631 = default;
a_1629 = Invoke(c_1530, "p", ((V)((-21D))), ((V)(27.6)), ((V)(3D)));
m_1630 = Invoke(c_1530, "p", ((V)(0D)), ((V)(29.4)), ((V)((-2D))));
b_1631 = Invoke(c_1530, "p", ((V)(21D)), ((V)(27.6)), ((V)(3D)));
return ((V)(JsStrBuf.Begin().S("M").V(Call(P2_47, V.Undef, a_1629)).S("Q").V(Call(P2_47, V.Undef, m_1630)).S(" ").V(Call(P2_47, V.Undef, b_1631)).End()));
return default;
}, 0, "", true), V.Undef);
lip_1549 = Call(Fn((V _arrowThis1638, int _argc1632, V _a1634, V _a1635, V _a1636, V _a1637, V[] _rest1633) => {
V a_1639 = default;
V m_1640 = default;
V b_1641 = default;
a_1639 = Invoke(c_1530, "p", ((V)((-24D))), ((V)(24.4)), ((V)(24D)));
m_1640 = Invoke(c_1530, "p", ((V)(0D)), ((V)(25.6)), ((V)(36D)));
b_1641 = Invoke(c_1530, "p", ((V)(24D)), ((V)(24.4)), ((V)(24D)));
return ((V)(JsStrBuf.Begin().S("M").V(Call(P2_47, V.Undef, a_1639)).S("Q").V(Call(P2_47, V.Undef, m_1640)).S(" ").V(Call(P2_47, V.Undef, b_1641)).End()));
return default;
}, 0, "", true), V.Undef);
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<defs><radialGradient id=\"b16dn\" cx=\"50%\" cy=\"44%\" r=\"50%\"><stop offset=\"0\" stop-color=\"").V(DK_1533).S("\" stop-opacity=\"0.6\"/><stop offset=\"0.6\" stop-color=\"").V(DK_1533).S("\" stop-opacity=\"0.22\"/><stop offset=\"1\" stop-color=\"").V(DK_1533).S("\" stop-opacity=\"0\"/></radialGradient></defs>").S("<path d=\"").S(wl_1541.Str).S("\" fill=\"none\" stroke=\"").V(DK_1533).S("\" stroke-opacity=\"0.11\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.5 * ToNum(k_1539)))))).S("\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>").S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(dn_1544, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(dn_1544, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)(dr_1545)))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((dr_1545 * 0.56))))).S("\" fill=\"url(#b16dn)\"/>").S("<path d=\"").V(fold_1548).S("\" fill=\"none\" stroke=\"").V(DK_1533).S("\" stroke-opacity=\"0.45\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1.3 * ToNum(k_1539)))))).S("\" stroke-linecap=\"round\"/><path d=\"").V(rim_1547).S("\" fill=\"none\" stroke=\"").V(LT_1534).S("\" stroke-opacity=\"0.7\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(k_1539)))))).S("\" stroke-linecap=\"round\"/><path d=\"").V(lip_1549).S("\" fill=\"none\" stroke=\"").V(LT_1534).S("\" stroke-opacity=\"0.5\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(k_1539)))))).S("\" stroke-linecap=\"round\"/>").S("<path d=\"").V(crease_1546).S("\" fill=\"none\" stroke=\"").V(DK_1533).S("\" stroke-opacity=\"0.32\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.8 * ToNum(k_1539)))))).S("\" stroke-linecap=\"round\"/>").S("<path d=\"").V(sm_1543).S("\" fill=\"none\" stroke=\"").V(DK_1533).S("\" stroke-opacity=\"0.45\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1D * ToNum(k_1539)))))).S("\" stroke-linecap=\"round\"/><path d=\"").V(sm_1543).S("\" fill=\"none\" stroke=\"").V(LT_1534).S("\" stroke-opacity=\"0.6\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.35 * ToNum(k_1539)))))).S("\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((1.1 * ToNum(k_1539)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((1.1 * ToNum(k_1539)))))).S("\" transform=\"translate(0 ").V(Call(f1_23, V.Undef, ((V)(((-0.9) * ToNum(k_1539)))))).S(")\"/>").End()))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "barrel16", Fn((V _arrowThis1649, int _argc1642, V S_1648, V _a1645, V _a1646, V _a1647, V[] _rest1643) => {
V BR_1650 = default;
double R_1651 = 0;
double NC_1652 = 0;
double a0_1653 = 0;
double a1_1654 = 0;
double rc_1655 = 0;
double dA_1656 = 0;
BR_1650 = ((V)("#d4a548"));
R_1651 = 26D;
NC_1652 = 13D;
a0_1653 = (PI_25 * 0.8);
a1_1654 = (PI_25 * 2.2);
rc_1655 = (R_1651 - 4.8);
dA_1656 = ((a1_1654 - a0_1653) / (NC_1652 - 1D));
return NewObj(5).Put("w", ((V)(60D))).Put("d", ((V)(60D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(5D))).Put("h", ((V)(34D))).V)).Put("build", Fn((V _arrowThis1664, int _argc1657, V P_1663, V _a1660, V _a1661, V _a1662, V[] _rest1658) => {
V o_1665 = default;
V V_1666 = default;
V VL_1667 = default;
V VD_1668 = default;
o_1665 = Arr();
V_1666 = Get(P_1663, "a");
VL_1667 = Get(P_1663, "aL");
VD_1668 = Get(P_1663, "aD");
Invoke(o_1665, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(2.4)), BR_1650, Call(M__31, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(1.5)), ((V)(0D)), ((V)(1D))), Arr(((V)(2.4)), ((V)(0.8)), ((V)(0.9))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2.4)), ((V)(0D)), ((V)(4.2)), ((V)(7.4)), BR_1650, Call(M__31, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.5))), Arr(((V)(1.6)), ((V)(0D)), ((V)(1D))), Arr(((V)(7.4)), ((V)(0D)), ((V)(0.85))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(9.6)), ((V)(0D)), ((V)(19D)), ((V)(1.4)), BR_1650, Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(26D))).V)));
Invoke(o_1665, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(11D)), ((V)(0D)), ((V)(R_1651)), ((V)(15D)), VD_1668, Call(F__32, V.Undef, NewObj(2).Put("n", ((V)(30D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(1.6)), ((V)(0.93))), Arr(((V)(2D)), ((V)(0D)), ((V)(1D))), Arr(((V)(13D)), ((V)(0D)), ((V)(1D))), Arr(((V)(15D)), ((V)(0.5)), ((V)(0.99))))).V)));
Call(rep_28, V.Undef, ((V)(NC_1652)), Fn((V _arrowThis1676, int _argc1669, V i_1675, V _a1672, V _a1673, V _a1674, V[] _rest1670) => {
double t_1677 = 0;
double d_1678 = 0;
double top_1679 = 0;
double h_1680 = 0;
V end_1681 = default;
t_1677 = (a0_1653 + (ToNum(i_1675) * dA_1656));
d_1678 = (System.Math.Abs((t_1677 - (PI_25 * 1.5))) / (PI_25 * 0.7));
top_1679 = (39D + (16D * (0.5 + (0.5 * FdLibm.Cos((PI_25 * Min(1D, d_1678)))))));
h_1680 = (top_1679 - 24D);
end_1681 = ((SEqN(i_1675, 0D) || SEqN(i_1675, (NC_1652 - 1D))) ? V.True : V.False);
Invoke(o_1665, "push", Call(cyl_13, V.Undef, ((V)((FdLibm.Cos(t_1677) * rc_1655))), ((V)(24D)), ((V)((FdLibm.Sin(t_1677) * rc_1655))), ((V)(((rc_1655 * dA_1656) * 0.62))), ((V)(h_1680)), (Truthy(end_1681) ? VL_1667 : V_1666), Call(F__32, V.Undef, NewObj(4).Put("rz", ((V)(5D))).Put("yaw", ((V)((t_1677 + (PI_25 / 2D))))).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)((h_1680 - 3.6))), ((V)(0D)), ((V)(1D))), Arr(((V)((h_1680 - 1.6))), ((V)(0.6)), ((V)(0.86))), Arr(((V)((h_1680 - 0.5))), ((V)(1.2)), ((V)(0.62))), Arr(((V)(h_1680)), ((V)(1.6)), ((V)(0.34))))).V)));
return default;
}, 1, "", true));
Invoke(o_1665, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(24.6)), ((V)(4D)), ((V)(16.6)), ((V)(9.6)), VL_1667, Call(F__32, V.Undef, NewObj(3).Put("n", ((V)(26D))).Put("rz", ((V)(18.6))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(5.4)), ((V)(0D)), ((V)(1.02))), Arr(((V)(8D)), ((V)(2D)), ((V)(0.95))), Arr(((V)(9.6)), ((V)(5D)), ((V)(0.8))))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(33.9)), ((V)(4D)), ((V)(1.4)), VD_1668, NewObj(5).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sy", ((V)(0.5))).Put("noOut", ((V)(1D))).Put("shine", ((V)(0D))).V));
return o_1665;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "eames16", Fn((V _arrowThis1689, int _argc1682, V S_1688, V _a1685, V _a1686, V _a1687, V[] _rest1683) => {
V RW_1690 = default;
V LEA_1691 = default;
V LL_1692 = default;
V AL_1693 = default;
V BT_1694 = default;
V star_1695 = default;
RW_1690 = ((V)("#5e2f1d"));
LEA_1691 = ((V)("#2a2628"));
LL_1692 = ((V)("#3a3538"));
AL_1693 = ((V)("#c9ced3"));
BT_1694 = ((V)("#141214"));
star_1695 = Fn((V _arrowThis1708, int _argc1696, V cx_1702, V cz_1703, V r_1704, V nL_1705, V[] _rest1697) => {
V @out_1709 = default;
V y_1706 = default;
V ph_1707 = default;
y_1706 = (_argc1696 > 4 ? _rest1697[0] : V.Undef);
ph_1707 = (_argc1696 > 5 ? _rest1697[1] : V.Undef);
@out_1709 = Arr();
Call(rep_28, V.Undef, nL_1705, Fn((V _arrowThis1717, int _argc1710, V i_1716, V _a1713, V _a1714, V _a1715, V[] _rest1711) => {
V t_1718 = default;
V e_1719 = default;
t_1718 = Add(ph_1707, ((V)((((ToNum(i_1716) * 2D) * PI_25) / ToNum(nL_1705)))));
e_1719 = Arr(Add(cx_1702, ((V)((FdLibm.Cos(ToNum(t_1718)) * ToNum(r_1704))))), y_1706, Add(cz_1703, ((V)((FdLibm.Sin(ToNum(t_1718)) * ToNum(r_1704))))));
Invoke(@out_1709, "push", Call(rod_44, V.Undef, Arr(cx_1702, Add(y_1706, ((V)(3D))), cz_1703), Arr(GetIdx(e_1719, 0D), Add(y_1706, ((V)(1.2))), GetIdx(e_1719, 2D)), ((V)(1.6)), LEA_1691, Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(ball_14, V.Undef, GetIdx(e_1719, 0D), ((V)(0D)), GetIdx(e_1719, 2D), ((V)(2D)), AL_1693, Call(M__31, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sy", ((V)(0.7))).V)));
return default;
}, 1, "", true));
return @out_1709;
return default;
}, 6, "", true);
return NewObj(5).Put("w", ((V)(70D))).Put("d", ((V)(104D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)((-8D)))).Put("h", ((V)(32D))).V)).Put("build", Fn((V _arrowThis1726, int _argc1720, V _a1722, V _a1723, V _a1724, V _a1725, V[] _rest1721) => {
V o_1727 = default;
double cz_1728 = 0;
double oz_1729 = 0;
V seat_1730 = default;
double bz_1731 = 0;
V back_1732 = default;
o_1727 = Arr();
cz_1728 = (-10D);
oz_1729 = 34D;
Invoke(Call(star_1695, V.Undef, ((V)(0D)), ((V)(cz_1728)), ((V)(22D)), ((V)(5D)), ((V)(1D)), ((V)((PI_25 / 10D)))), "forEach", Fn((V _arrowThis1740, int _argc1733, V s_1739, V _a1736, V _a1737, V _a1738, V[] _rest1734) => {
return Invoke(o_1727, "push", s_1739);
}, 1, "", true));
Invoke(o_1727, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(cz_1728)), ((V)(3.2)), ((V)(13D)), AL_1693, Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
seat_1730 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(17D)), ((V)((cz_1728 + 2D))), ((V)(42D)), ((V)(4D)), ((V)(40D)), RW_1690, Call(W__30, V.Undef, NewObj(2).Put("r", ((V)(10D))).Put("bev", ((V)(1.6))).V)), Call(pillowY_19, V.Undef, ((V)(0D)), ((V)(20.6)), ((V)((cz_1728 + 3D))), ((V)(39D)), ((V)(10D)), ((V)(36D)), LEA_1691, Call(L__33, V.Undef)));
Invoke(Arr(((V)((-9D))), ((V)(9D))), "forEach", Fn((V _arrowThis1748, int _argc1741, V x_1747, V _a1744, V _a1745, V _a1746, V[] _rest1742) => {
return Invoke(seat_1730, "push", Call(ball_14, V.Undef, x_1747, ((V)(30.2)), ((V)((cz_1728 + 2D))), ((V)(1.1)), BT_1694, NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("sy", ((V)(0.4))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
Invoke(Call(tiltAll_41, V.Undef, seat_1730, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.07))), Arr(((V)(0D)), ((V)(17D)), ((V)((cz_1728 + 2D))))), "forEach", Fn((V _arrowThis1756, int _argc1749, V s_1755, V _a1752, V _a1753, V _a1754, V[] _rest1750) => {
return Invoke(o_1727, "push", s_1755);
}, 1, "", true));
bz_1731 = (cz_1728 - 18D);
back_1732 = Arr(Call(slab_15, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(bz_1731)), ((V)(42D)), ((V)(30D)), ((V)(4D)), RW_1690, Call(W__30, V.Undef, NewObj(1).Put("r", ((V)(12D))).V)), Call(pillowZ_20, V.Undef, ((V)(0D)), ((V)(25D)), ((V)((bz_1731 + 5D))), ((V)(39D)), ((V)(28D)), ((V)(8D)), LEA_1691, Call(L__33, V.Undef)), Call(slab_15, V.Undef, ((V)(0D)), ((V)(56D)), ((V)(bz_1731)), ((V)(38D)), ((V)(17D)), ((V)(4D)), RW_1690, Call(W__30, V.Undef, NewObj(1).Put("r", ((V)(8D))).V)), Call(pillowZ_20, V.Undef, ((V)(0D)), ((V)(57D)), ((V)((bz_1731 + 5D))), ((V)(35D)), ((V)(15D)), ((V)(7D)), LL_1692, Call(L__33, V.Undef)));
Invoke(Arr(Arr(((V)((-9D))), ((V)(37D))), Arr(((V)(9D)), ((V)(37D))), Arr(((V)(0D)), ((V)(65D)))), "forEach", Fn((V _arrowThis1768, int _argc1757, V _a1759, V _a1760, V _a1761, V _a1762, V[] _rest1758) => {
V x_1765 = default;
V y_1767 = default;
{ V _t1763 = ListOf(_a1759);
{ V _t1764 = GetIdx(_t1763, 0D);
x_1765 = _t1764; }
{ V _t1766 = GetIdx(_t1763, 1D);
y_1767 = _t1766; }
}
return Invoke(back_1732, "push", Call(ball_14, V.Undef, x_1765, y_1767, ((V)((bz_1731 + 9.2))), ((V)(1.1)), BT_1694, NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("sz", ((V)(0.4))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
Invoke(back_1732, "push", Call(rod_44, V.Undef, Arr(((V)(0D)), ((V)(52D)), ((V)((bz_1731 - 2.2)))), Arr(((V)(0D)), ((V)(60D)), ((V)((bz_1731 - 2.2)))), ((V)(1.6)), ((V)("#3a3a3e")), Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
Invoke(Call(tiltAll_41, V.Undef, back_1732, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.34))), Arr(((V)(0D)), ((V)(24D)), ((V)(bz_1731)))), "forEach", Fn((V _arrowThis1776, int _argc1769, V s_1775, V _a1772, V _a1773, V _a1774, V[] _rest1770) => {
return Invoke(o_1727, "push", s_1775);
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1784, int _argc1777, V sg_1783, V _a1780, V _a1781, V _a1782, V[] _rest1778) => {
double x_1785 = 0;
x_1785 = (ToNum(sg_1783) * 22.5);
Invoke(o_1727, "push", Call(rod_44, V.Undef, Arr(((V)(x_1785)), ((V)(21D)), ((V)((cz_1728 + 10D)))), Arr(((V)(x_1785)), ((V)(33D)), ((V)((cz_1728 + 6D)))), ((V)(1D)), AL_1693, Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(rod_44, V.Undef, Arr(((V)(x_1785)), ((V)(21D)), ((V)((cz_1728 - 14D)))), Arr(((V)(x_1785)), ((V)(33D)), ((V)((cz_1728 - 16D)))), ((V)(1D)), AL_1693, Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(box_12, V.Undef, ((V)(x_1785)), ((V)(33D)), ((V)((cz_1728 - 4D))), ((V)(6D)), ((V)(3.2)), ((V)(30D)), LEA_1691, Call(L__33, V.Undef, NewObj(2).Put("r", ((V)(2.5))).Put("soft", ((V)(1D))).V)));
return default;
}, 1, "", true));
Invoke(Call(star_1695, V.Undef, ((V)(0D)), ((V)(oz_1729)), ((V)(15D)), ((V)(4D)), ((V)(1D)), ((V)((PI_25 / 4D)))), "forEach", Fn((V _arrowThis1793, int _argc1786, V s_1792, V _a1789, V _a1790, V _a1791, V[] _rest1787) => {
return Invoke(o_1727, "push", s_1792);
}, 1, "", true));
Invoke(o_1727, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(oz_1729)), ((V)(2.8)), ((V)(8D)), AL_1693, Call(M__31, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
Invoke(Call(tiltAll_41, V.Undef, Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(oz_1729)), ((V)(36D)), ((V)(3.6)), ((V)(30D)), RW_1690, Call(W__30, V.Undef, NewObj(2).Put("r", ((V)(9D))).Put("bev", ((V)(1.4))).V)), Call(pillowY_19, V.Undef, ((V)(0D)), ((V)(15.4)), ((V)(oz_1729)), ((V)(34D)), ((V)(8D)), ((V)(27D)), LEA_1691, Call(L__33, V.Undef)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(23.2)), ((V)(oz_1729)), ((V)(1.1)), BT_1694, NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("sy", ((V)(0.4))).Put("noOut", ((V)(1D))).V)), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(0.08)), Arr(((V)(0D)), ((V)(12D)), ((V)(oz_1729)))), "forEach", Fn((V _arrowThis1801, int _argc1794, V s_1800, V _a1797, V _a1798, V _a1799, V[] _rest1795) => {
return Invoke(o_1727, "push", s_1800);
}, 1, "", true));
return o_1727;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "hover16", Fn((V _arrowThis1809, int _argc1802, V S_1808, V _a1805, V _a1806, V _a1807, V[] _rest1803) => {
double by_1810 = 0;
double zc_1811 = 0;
V SH_1812 = default;
V E0_1813 = default;
by_1810 = 16D;
zc_1811 = (-4D);
SH_1812 = ((V)("#f4f6fa"));
E0_1813 = NewObj(3).Put("ow", ((V)(0.78))).Put("oh", ((V)(0.6))).Put("oc", ((V)(0.86))).V;
return NewObj(8).Put("w", ((V)(76D))).Put("d", ((V)(74D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(8D))).Put("h", ((V)((by_1810 + 16D)))).V)).Put("anim", Call(bobA_49, V.Undef, ((V)(4D)), ((V)(3.2)))).Put("pad", Arr(((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(0D)))).Put("build", Fn((V _arrowThis1821, int _argc1814, V P_1820, V _a1817, V _a1818, V _a1819, V[] _rest1815) => {
V o_1822 = default;
V IN_1823 = default;
V IL_1824 = default;
V ID_1825 = default;
V E_1826 = default;
V cz_1827 = default;
o_1822 = Arr();
IN_1823 = Get(P_1820, "a");
IL_1824 = Get(P_1820, "aL");
ID_1825 = Call(shade_21, V.Undef, Get(P_1820, "aD"), ((V)(0.8)));
E_1826 = Call(egg_58, V.Undef, ((V)(0D)), ((V)((by_1810 - 8D))), ((V)(zc_1811)), ((V)(33D)), ((V)(44D)), ((V)(31D)), SH_1812, ID_1825, E0_1813);
cz_1827 = Get(E_1826, "fz");
Invoke(Invoke(Get(E_1826, "shell"), "concat", Get(E_1826, "part")), "forEach", Fn((V _arrowThis1835, int _argc1828, V s_1834, V _a1831, V _a1832, V _a1833, V[] _rest1829) => {
return Invoke(o_1822, "push", s_1834);
}, 1, "", true));
Invoke(o_1822, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)((by_1810 - 9.2))), ((V)(zc_1811)), ((V)(12D)), ((V)(1.2)), ((V)("#8ff6ff")), Call(em_29, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)((by_1810 - 2D))), ((V)(zc_1811)), ((V)(33.4)), ((V)(31.4)), ((V)(1D)), ((V)(1.4)), ((V)(0D)), ((V)((2D * PI_25))), ((V)("#7ff0ff")), Call(em_29, V.Undef, NewObj(1).Put("n", ((V)(28D))).V)));
Invoke(Call(partOf_59, V.Undef, Arr(Call(pillowY_19, V.Undef, ((V)(0D)), ((V)((by_1810 + 2D))), ((V)((ToNum(cz_1827) - 3D))), ((V)(42D)), ((V)(12D)), ((V)(22D)), IL_1824, Call(L__33, V.Undef)), Call(pillowZ_20, V.Undef, ((V)(0D)), ((V)((by_1810 + 12D))), ((V)((ToNum(cz_1827) - 6D))), ((V)(40D)), ((V)(38D)), ((V)(8D)), IN_1823, Call(L__33, V.Undef)), Call(pillowZ_20, V.Undef, ((V)(0D)), ((V)((by_1810 + 46D))), ((V)((ToNum(cz_1827) - 7D))), ((V)(26D)), ((V)(11D)), ((V)(7D)), IL_1824, Call(L__33, V.Undef)), Call(box_12, V.Undef, ((V)(25D)), ((V)((by_1810 + 12D))), ((V)((ToNum(cz_1827) - 6D))), ((V)(6D)), ((V)(5D)), ((V)(18D)), Call(shade_21, V.Undef, IN_1823, ((V)(0.85))), Call(L__33, V.Undef, NewObj(2).Put("r", ((V)(2.4))).Put("soft", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(25D)), ((V)((by_1810 + 17D))), ((V)((ToNum(cz_1827) - 1D))), ((V)(4.4)), ((V)(0.6)), ((V)(6D)), ((V)("#1a1d2a")), NewObj(1).Put("r", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(25D)), ((V)((by_1810 + 17.6))), ((V)((ToNum(cz_1827) - 1D))), ((V)(1D)), ((V)("#7ff0ff")), Call(em_29, V.Undef, NewObj(2).Put("k", ((V)(2D))).Put("n", ((V)(6D))).V)))), "forEach", Fn((V _arrowThis1843, int _argc1836, V s_1842, V _a1839, V _a1840, V _a1841, V[] _rest1837) => {
return Invoke(o_1822, "push", s_1842);
}, 1, "", true));
return o_1822;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1851, int _argc1844, V c_1850, V _a1847, V _a1848, V _a1849, V[] _rest1845) => {
double cz_1852 = 0;
V node_1853 = default;
JsStrBuf f_1854 = null;
V u_1855 = default;
cz_1852 = ((zc_1811 + (31D * 0.58)) + (31D * 0.4));
node_1853 = Fn((V _arrowThis1865, int _argc1856, V x_1862, V y_1863, V i_1864, V _a1861, V[] _rest1857) => {
V q_1866 = default;
double r_1867 = 0;
q_1866 = Invoke(c_1850, "p", x_1862, y_1863, ((V)((cz_1852 - 1.6))));
r_1867 = (1.5 * ToNum(Get(c_1850, "k")));
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_1866, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_1866, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((r_1867 * 2.4))))).S("\" fill=\"#7ff0ff\" opacity=\"0\">").V(Call(an_48, V.Undef, ((V)("opacity")), ((V)("0;0.5;0")), ((V)(1.6)), ((V)(((-ToNum(i_1864)) * 0.27))))).S("</circle><circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_1866, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_1866, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)(r_1867)))).S("\" fill=\"#dffcff\" stroke=\"#3fc8d8\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.3 * ToNum(Get(c_1850, "k"))))))).S("\">").V(Call(an_48, V.Undef, ((V)("opacity")), ((V)("0.45;1;0.45")), ((V)(1.6)), ((V)(((-ToNum(i_1864)) * 0.27))))).S("</circle>").End()));
return default;
}, 3, "", true);
f_1854 = new JsStrBuf("");
Invoke(Arr(((V)((by_1810 + 24D))), ((V)((by_1810 + 34D))), ((V)((by_1810 + 44D)))), "forEach", Fn((V _arrowThis1876, int _argc1868, V y_1874, V j_1875, V _a1872, V _a1873, V[] _rest1869) => {
return Invoke(Arr(((V)((-8D))), ((V)(8D))), "forEach", Fn((V _arrowThis1885, int _argc1877, V x_1883, V i_1884, V _a1881, V _a1882, V[] _rest1878) => {
return ((V)(f_1854.V(Call(node_1853, V.Undef, x_1883, y_1874, Add(((V)((ToNum(j_1875) * 2D))), i_1884))).Str));
}, 2, "", true));
}, 2, "", true));
u_1855 = ((V)(JsStrBuf.Begin().S("<defs><radialGradient id=\"p16hc\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#8ff6ff\" stop-opacity=\"0.85\"/><stop offset=\"0.55\" stop-color=\"#5fd8ff\" stop-opacity=\"0.35\"/><stop offset=\"1\" stop-color=\"#5fd8ff\" stop-opacity=\"0\"/></radialGradient></defs>").V(Call(fxEll_50, V.Undef, c_1850, ((V)(0D)), ((V)(0D)), ((V)(zc_1811)), ((V)(32D)), ((V)("url(#p16hc)")), Call(an_48, V.Undef, ((V)("opacity")), ((V)("0.7;1;0.7")), ((V)(3.2))))).V(Invoke(Call(rep_28, V.Undef, ((V)(2D)), Fn((V _arrowThis1893, int _argc1886, V i_1892, V _a1889, V _a1890, V _a1891, V[] _rest1887) => {
return Call(fxEll_50, V.Undef, c_1850, ((V)(0D)), ((V)(0D)), ((V)(zc_1811)), ((V)(16D)), ((V)(JsStrBuf.Begin().S("none\" stroke=\"#8ff6ff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(Get(c_1850, "k"))))))).S("\" stroke-opacity=\"0.8").End())), Add(Add(Call(an_48, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((8D * ToNum(Get(c_1850, "k"))))))).S(";").V(Call(f1_23, V.Undef, ((V)((32D * ToNum(Get(c_1850, "k"))))))).End())), ((V)(2.4)), ((V)(((-ToNum(i_1892)) * 1.2)))), Call(an_48, V.Undef, ((V)("ry")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)(((8D * ToNum(Get(c_1850, "k"))) * ToNum(Get(X_9, "SA"))))))).S(";").V(Call(f1_23, V.Undef, ((V)(((32D * ToNum(Get(c_1850, "k"))) * ToNum(Get(X_9, "SA"))))))).End())), ((V)(2.4)), ((V)(((-ToNum(i_1892)) * 1.2))))), Call(an_48, V.Undef, ((V)("stroke-opacity")), ((V)("0.9;0")), ((V)(2.4)), ((V)(((-ToNum(i_1892)) * 1.2))))));
}, 1, "", true)), "join", ((V)("")))).End()));
return NewObj(2).Put("front", ((V)(f_1854.Str))).Put("under", u_1855).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "pnest16", Fn((V _arrowThis1901, int _argc1894, V S_1900, V _a1897, V _a1898, V _a1899, V[] _rest1895) => {
V WHT_1902 = default;
V RED_1903 = default;
V CB_1904 = default;
double hw_1905 = 0;
double hd_1906 = 0;
V wallZ_1907 = default;
V wallX_1908 = default;
WHT_1902 = ((V)("#fbf6ec"));
RED_1903 = ((V)("#d9363b"));
CB_1904 = ((V)("#d8b88a"));
hw_1905 = 24D;
hd_1906 = 21D;
wallZ_1907 = Fn((V _arrowThis1918, int _argc1909, V z_1915, V h_1916, V sg_1917, V _a1914, V[] _rest1910) => {
V L_1919 = default;
L_1919 = Arr(Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), z_1915, ((V)((2D * hw_1905))), h_1916, ((V)(2.4)), WHT_1902, NewObj(2).Put("r", ((V)(1.2))).Put("mat", ((V)("pl"))).V));
Call(rep_28, V.Undef, ((V)(4D)), Fn((V _arrowThis1927, int _argc1920, V i_1926, V _a1923, V _a1924, V _a1925, V[] _rest1921) => {
return Invoke(L_1919, "push", Call(slab_15, V.Undef, ((V)((((-hw_1905) + 6D) + (ToNum(i_1926) * 12D)))), ((V)(0.4)), Add(z_1915, ((V)((ToNum(sg_1917) * 1.35)))), ((V)(6D)), ((V)((ToNum(h_1916) - 0.8))), ((V)(0.3)), RED_1903, NewObj(3).Put("r", ((V)(0.4))).Put("mat", ((V)("pl"))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
return Call(tiltAll_41, V.Undef, L_1919, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((ToNum(sg_1917) * 0.12))), Arr(((V)(0D)), ((V)(0D)), z_1915));
return default;
}, 3, "", true);
wallX_1908 = Fn((V _arrowThis1937, int _argc1928, V x_1934, V h_1935, V sg_1936, V _a1933, V[] _rest1929) => {
V L_1938 = default;
L_1938 = Arr(Call(box_12, V.Undef, x_1934, ((V)(0D)), ((V)(0D)), ((V)(2.4)), h_1935, ((V)((2D * hd_1906))), WHT_1902, NewObj(2).Put("r", ((V)(1.2))).Put("mat", ((V)("pl"))).V));
Call(rep_28, V.Undef, ((V)(4D)), Fn((V _arrowThis1946, int _argc1939, V i_1945, V _a1942, V _a1943, V _a1944, V[] _rest1940) => {
return Invoke(L_1938, "push", Call(box_12, V.Undef, Add(x_1934, ((V)((ToNum(sg_1936) * 1.35)))), ((V)(0.4)), ((V)((((-hd_1906) + 5D) + (ToNum(i_1945) * 10.6)))), ((V)(0.3)), ((V)((ToNum(h_1935) - 0.8))), ((V)(5.2)), RED_1903, NewObj(3).Put("r", ((V)(0.4))).Put("mat", ((V)("pl"))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
return Call(tiltAll_41, V.Undef, L_1938, Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(((-ToNum(sg_1936)) * 0.12))), Arr(x_1934, ((V)(0D)), ((V)(0D))));
return default;
}, 3, "", true);
return NewObj(6).Put("w", ((V)(64D))).Put("d", ((V)(58D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(2D))).Put("h", ((V)(14D))).V)).Put("build", Fn((V _arrowThis1953, int _argc1947, V _a1949, V _a1950, V _a1951, V _a1952, V[] _rest1948) => {
V o_1954 = default;
o_1954 = Arr();
Invoke(o_1954, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((2D * hw_1905))), ((V)(2D)), ((V)((2D * hd_1906))), CB_1904, NewObj(2).Put("r", ((V)(1.5))).Put("mat", ((V)("pl"))).V));
Invoke(Invoke(Call(wallZ_1907, V.Undef, ((V)((-hd_1906))), ((V)(36D)), ((V)((-1D)))), "concat", Call(wallX_1908, V.Undef, ((V)((-hw_1905))), ((V)(28D)), ((V)((-1D)))), Call(wallX_1908, V.Undef, ((V)(hw_1905)), ((V)(28D)), ((V)(1D))), Call(wallZ_1907, V.Undef, ((V)(hd_1906)), ((V)(15D)), ((V)(1D)))), "forEach", Fn((V _arrowThis1962, int _argc1955, V s_1961, V _a1958, V _a1959, V _a1960, V[] _rest1956) => {
return Invoke(o_1954, "push", s_1961);
}, 1, "", true));
Invoke(o_1954, "push", Call(pillowY_19, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(1D)), ((V)(((2D * hw_1905) - 6D))), ((V)(11D)), ((V)(((2D * hd_1906) - 6D))), ((V)("#fff3dc")), Call(F__32, V.Undef)), Call(ball_14, V.Undef, ((V)((-8D))), ((V)(12.5)), ((V)((-6D))), ((V)(6D)), ((V)("#ffe9c4")), Call(F__32, V.Undef, NewObj(4).Put("sy", ((V)(0.45))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).Put("shine", ((V)(0D))).V)));
Invoke(Arr(Arr(((V)((-16D))), ((V)(25D)), ((V)((-16D)))), Arr(((V)((-10D))), ((V)(22D)), ((V)((-17D)))), Arr(((V)(14D)), ((V)(24D)), ((V)((-16D)))), Arr(((V)(18D)), ((V)(15.5)), ((V)((-10D)))), Arr(((V)((-17D))), ((V)(15D)), ((V)((-9D)))), Arr(((V)(6D)), ((V)(13.6)), ((V)(10D)))), "forEach", Fn((V _arrowThis1977, int _argc1963, V _a1965, V i_1969, V _a1967, V _a1968, V[] _rest1964) => {
V x_1972 = default;
V y_1974 = default;
V z_1976 = default;
{ V _t1970 = ListOf(_a1965);
{ V _t1971 = GetIdx(_t1970, 0D);
x_1972 = _t1971; }
{ V _t1973 = GetIdx(_t1970, 1D);
y_1974 = _t1973; }
{ V _t1975 = GetIdx(_t1970, 2D);
z_1976 = _t1975; }
}
return Invoke(Call(kern_54, V.Undef, x_1972, y_1974, z_1976, ((V)(2D)), i_1969), "forEach", Fn((V _arrowThis1985, int _argc1978, V s_1984, V _a1981, V _a1982, V _a1983, V[] _rest1979) => {
return Invoke(o_1954, "push", s_1984);
}, 1, "", true));
}, 2, "", true));
Invoke(Arr(Arr(((V)(30D)), ((V)(0D)), ((V)(18D))), Arr(((V)(34D)), ((V)(0D)), ((V)(10D))), Arr(((V)((-30D))), ((V)(0D)), ((V)(22D)))), "forEach", Fn((V _arrowThis2000, int _argc1986, V _a1988, V i_1992, V _a1990, V _a1991, V[] _rest1987) => {
V x_1995 = default;
V y_1997 = default;
V z_1999 = default;
{ V _t1993 = ListOf(_a1988);
{ V _t1994 = GetIdx(_t1993, 0D);
x_1995 = _t1994; }
{ V _t1996 = GetIdx(_t1993, 1D);
y_1997 = _t1996; }
{ V _t1998 = GetIdx(_t1993, 2D);
z_1999 = _t1998; }
}
return Invoke(Call(kern_54, V.Undef, x_1995, y_1997, z_1999, ((V)(1.8)), Add(i_1992, ((V)(2D)))), "forEach", Fn((V _arrowThis2008, int _argc2001, V s_2007, V _a2004, V _a2005, V _a2006, V[] _rest2002) => {
return Invoke(o_1954, "push", s_2007);
}, 1, "", true));
}, 2, "", true));
return o_1954;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis2016, int _argc2009, V c_2015, V _a2012, V _a2013, V _a2014, V[] _rest2010) => {
V O_2017 = default;
V Vd_2018 = default;
V M_2019 = default;
O_2017 = Call(Call(rotF_38, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(0.12))), V.Undef, Arr(((V)(0D)), ((V)(8.4)), ((V)(1.4))));
Vd_2018 = Call(Call(rotF_38, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(0.12))), V.Undef, Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
M_2019 = Call(frame_53, V.Undef, Get(c_2015, "p"), Arr(GetIdx(O_2017, 0D), GetIdx(O_2017, 1D), Add(GetIdx(O_2017, 2D), ((V)(hd_1906)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Vd_2018);
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(M_2019).S("\"><rect x=\"-16\" y=\"-4.2\" width=\"32\" height=\"8.4\" rx=\"4.2\" fill=\"#ffd23f\" stroke=\"#b8202a\" stroke-width=\"0.7\"/><text x=\"0\" y=\"2.2\" text-anchor=\"middle\" ").V(FONT_51).S(" font-size=\"6\" fill=\"#c8202a\" letter-spacing=\"0.4\">POPCORN</text></g>").End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
COUCH_62 = Arr(NewObj(2).Put("n", ((V)("Sage"))).Put("c", ((V)("#9cbf8a"))).V, NewObj(2).Put("n", ((V)("Coral"))).Put("c", ((V)("#e98f74"))).V, NewObj(2).Put("n", ((V)("Denim"))).Put("c", ((V)("#6f8fc0"))).V, NewObj(2).Put("n", ((V)("Mustard"))).Put("c", ((V)("#e0b04c"))).V, NewObj(2).Put("n", ((V)("Lilac"))).Put("c", ((V)("#b39ad8"))).V);
POD_63 = Arr(NewObj(2).Put("n", ((V)("Teal"))).Put("c", ((V)("#3fc7c9"))).V, NewObj(2).Put("n", ((V)("Violet"))).Put("c", ((V)("#8a6ee0"))).V, NewObj(2).Put("n", ((V)("Hot pink"))).Put("c", ((V)("#ff6fae"))).V, NewObj(2).Put("n", ((V)("Midnight"))).Put("c", ((V)("#3a4466"))).V);
CORD_64 = Arr(NewObj(2).Put("n", ((V)("Mustard"))).Put("c", ((V)("#d99a35"))).V, NewObj(2).Put("n", ((V)("Rust"))).Put("c", ((V)("#c4643a"))).V, NewObj(2).Put("n", ((V)("Olive"))).Put("c", ((V)("#8a9a4a"))).V, NewObj(2).Put("n", ((V)("Plum"))).Put("c", ((V)("#8a4f7a"))).V);
VELC_65 = Arr(NewObj(2).Put("n", ((V)("Emerald"))).Put("c", ((V)("#2f7a5e"))).V, NewObj(2).Put("n", ((V)("Blush"))).Put("c", ((V)("#d98a8f"))).V, NewObj(2).Put("n", ((V)("Navy"))).Put("c", ((V)("#34477a"))).V, NewObj(2).Put("n", ((V)("Mustard"))).Put("c", ((V)("#d0a03c"))).V);
EGG_66 = Arr(NewObj(2).Put("n", ((V)("Ice"))).Put("c", ((V)("#7fd6e0"))).V, NewObj(2).Put("n", ((V)("Lavender"))).Put("c", ((V)("#b6a2f0"))).V, NewObj(2).Put("n", ((V)("Peach"))).Put("c", ((V)("#ffb38a"))).V, NewObj(2).Put("n", ((V)("Mint"))).Put("c", ((V)("#8ee6b4"))).V);
Set(RD_8, "DEL16", New(G("Set"), Arr(((V)("MOV-027")), ((V)("MOV-039")), ((V)("MOV-059")), ((V)("MOV-079")), ((V)("MOV-099")), ((V)("LIV-034")), ((V)("LIV-074")), ((V)("LIV-094")))));
Set(RD_8, "SET16", NewObj(31).Put("MOV-013", NewObj(3).Put("name", ((V)("Old Futon"))).Put("spec", ((V)("futon16"))).Put("note", ((V)("A saggy blue futon on a pine slat frame: the mattress dips in the middle, a plaid patch covers a hole, a mustard blanket is crumpled on one end and an old striped pillow slumps on the other. Duct tape holds one leg together."))).V).Put("MOV-033", NewObj(4).Put("name", ((V)("Comfy Couch"))).Put("spec", ((V)("couch16"))).Put("colors", COUCH_62).Put("note", ((V)("A big puffy 3-seat couch on wooden legs: rolled arms, three fat seat cushions and three back cushions, two throw pillows, a striped knit throw folded over one arm and the TV remote on the other. Pick a colour."))).V).Put("MOV-053", NewObj(3).Put("name", ((V)("Leather Loveseat"))).Put("spec", ((V)("loveseat16"))).Put("note", ((V)("A cognac leather 2-seater with a tall rolled back and two thick diamond-tufted back cushions (pillowy diamonds with buttons in the dimples), plump seat cushions and padded arms with glowing cup holders. Sits on a black plinth with a warm light strip underneath."))).V).Put("MOV-073", NewObj(3).Put("name", ((V)("Recliner Sofa"))).Put("spec", ((V)("recliner16"))).Put("note", ((V)("Three caramel leather recliners in a row with consoles between them: cup holders with blue light rings, a cola and a tub of popcorn. The middle seat is reclined with its footrest out."))).V).Put("MOV-093", NewObj(5).Put("name", ((V)("Zero-G Pods"))).Put("spec", ((V)("pods16"))).Put("colors", POD_63).Put("live", ((V)("Floating"))).Put("note", ((V)("Three white egg pods floating over glowing hover pads, with cushy seats, a light line inside each shell and glowing drink pillars between them. Pick the cushion colour."))).V).Put("MOV-101", NewObj(3).Put("name", ((V)("Royal Cinema Seats"))).Put("spec", ((V)("royal16"))).Put("note", ((V)("Three crimson velvet cinema seats with tall arched channel-tufted backs framed in gold, padded arms on mahogany with gold medallions, on a mahogany step with little floor lights. Gold cup holders hold a soda and a gold tub of popcorn."))).V).Put("MOV-016", NewObj(3).Put("name", ((V)("Camp Chair"))).Put("spec", ((V)("camp16"))).Put("note", ((V)("A green folding camp chair on a black steel X frame, with canvas arms and a mesh cup holder holding a can of soda."))).V).Put("MOV-036", NewObj(4).Put("name", ((V)("Beanbag"))).Put("spec", ((V)("bean16"))).Put("colors", CORD_64).Put("note", ((V)("A big slouchy corduroy beanbag with a deep dent to sink into, a soft lump behind to lean on, a stitched seam round the bottom and a little tag. Pick a colour."))).V).Put("MOV-056", NewObj(4).Put("name", ((V)("Velvet Swivel Chair"))).Put("spec", ((V)("barrel16"))).Put("colors", VELC_65).Put("note", ((V)("A round velvet scallop chair: puffy channel tufts wrap round a deep button cushion, tall at the back and curving down into the arms, on a brass swivel base. Pick a colour."))).V).Put("MOV-076", NewObj(3).Put("name", ((V)("Wood Lounge Chair"))).Put("spec", ((V)("eames16"))).Put("note", ((V)("A classic rosewood lounge chair with black leather cushions and buttons, leaning back on a five-star base, with its matching footstool in front."))).V).Put("MOV-096", NewObj(5).Put("name", ((V)("Hover Egg Chair"))).Put("spec", ((V)("hover16"))).Put("colors", EGG_66).Put("live", ((V)("Massage lights"))).Put("note", ((V)("A white egg chair floating over a glowing hover pad. Light lines trace its opening and six massage lights pulse on the back cushion. Pick the cushion colour."))).V).Put("MOV-019", NewObj(3).Put("name", ((V)("Popcorn Box Bed"))).Put("spec", ((V)("pnest16"))).Put("note", ((V)("A giant red-and-white popcorn box turned into a pet bed: the front is cut low to climb in, a fluffy cushion fills the bottom and a few popcorn pieces are scattered around."))).V).Put("MOV-003", NewObj(1).Put("name", ((V)("Crate Table"))).V).Put("MOV-023", NewObj(1).Put("name", ((V)("Snack Table"))).V).Put("MOV-043", NewObj(1).Put("name", ((V)("Glass Coffee Table"))).V).Put("MOV-063", NewObj(1).Put("name", ((V)("Fridge Table"))).V).Put("MOV-083", NewObj(1).Put("name", ((V)("Holo Table"))).V).Put("MOV-007", NewObj(1).Put("name", ((V)("TV Tray"))).V).Put("MOV-047", NewObj(1).Put("name", ((V)("Brass Side Table"))).V).Put("MOV-067", NewObj(1).Put("name", ((V)("Marble Side Table"))).V).Put("MOV-087", NewObj(1).Put("name", ((V)("Robot Butler"))).V).Put("MOV-017", NewObj(1).Put("name", ((V)("Brick Shelf"))).V).Put("MOV-037", NewObj(1).Put("name", ((V)("DVD Tower"))).V).Put("MOV-057", NewObj(1).Put("name", ((V)("Wood Media Console"))).V).Put("MOV-077", NewObj(1).Put("name", ((V)("Movie Vault"))).V).Put("MOV-097", NewObj(1).Put("name", ((V)("Holo Movie Library"))).V).Put("MOV-008", NewObj(1).Put("name", ((V)("Candy & 3D Glasses"))).V).Put("MOV-028", NewObj(1).Put("name", ((V)("Popcorn Bucket"))).V).Put("MOV-048", NewObj(1).Put("name", ((V)("Director Kit"))).V).Put("MOV-068", NewObj(1).Put("name", ((V)("Gold Trophy"))).V).Put("MOV-088", NewObj(1).Put("name", ((V)("Holo Mascot"))).V).V);
edit15_67 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis2027, int _argc2020, V rows_2026, V _a2023, V _a2024, V _a2025, V[] _rest2021) => {
return Invoke(Invoke(Call(edit15_67, V.Undef, rows_2026), "filter", Fn((V _arrowThis2043, int _argc2036, V r_2042, V _a2039, V _a2040, V _a2041, V[] _rest2037) => {
return (!(Truthy(Invoke(Get(RD_8, "DEL16"), "has", Get(r_2042, "id")))) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis2035, int _argc2028, V r_2034, V _a2031, V _a2032, V _a2033, V[] _rest2029) => {
return (Truthy(GetK(Get(RD_8, "SET16"), Get(r_2034, "id"))) ? Object_assign(NewObj(0).V, r_2034, GetK(Get(RD_8, "SET16"), Get(r_2034, "id"))) : r_2034);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H16", NewObj(23).Put("loft", loft_43).Put("xf", xf_39).Put("tilt", tilt_40).Put("tiltAll", tiltAll_41).Put("rotF", rotF_38).Put("rod", rod_44).Put("pipe", pipe_45).Put("fxEll", fxEll_50).Put("frame", frame_53).Put("kern", kern_54).Put("cup", cup_55).Put("holder", holder_56).Put("bobA", bobA_49).Put("an", an_48).Put("FONT", FONT_51).Put("W_", W__30).Put("M_", M__31).Put("F_", F__32).Put("L_", L__33).Put("PL", PL_34).Put("G_", G__35).Put("em", em_29).Put("rep", rep_28).V);
Set(RD_8, "PLUS16", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
