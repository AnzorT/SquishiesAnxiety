// reno-flora.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_flora_js
    {

        public static void Run()
        {
Call(Named(boot_86 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V solid_11 = default;
V box_12 = default;
V cyl_13 = default;
V ball_14 = default;
V slab_15 = default;
V arcW_16 = default;
V disc_17 = default;
V shade_18 = default;
V mix_19 = default;
V f1_20 = default;
V H3_21 = default;
V rep_22 = default;
V rng_23 = default;
V n4_24 = default;
V P2_25 = default;
V plane_26 = default;
V planeH_27 = default;
V an_28 = default;
V anS_29 = default;
V atS_30 = default;
V BLUR_31 = default;
V mt_32 = default;
V wd_33 = default;
V cer_34 = default;
V pt_35 = default;
V N_36 = default;
V em_37 = default;
double PI_38 = 0;
V SA_39 = default;
V CA_40 = default;
V GOLD_41 = default;
V GL_42 = default;
V LT_43 = default;
V dep_44 = default;
V sub_45 = default;
V addv_46 = default;
V cross_47 = default;
V SHP_48 = default;
V Flora_49 = default;
V sm_50 = default;
V FL_51 = default;
V potT_52 = default;
V lift_53 = default;
V LEAF_54 = default;
V snake_55 = default;
V pothos_56 = default;
V fiddle_57 = default;
V bonsai_58 = default;
V olive_59 = default;
V fern_60 = default;
V bamboo_61 = default;
V euca_62 = default;
V lettuce_63 = default;
V carrot_64 = default;
V rose_65 = default;
V orchid_66 = default;
V PT_67 = default;
V S0_68 = default;
V PL_69 = default;
if (_self1.IsNullish) _self1 = GlobalV;
Flora_49 = Fn((V _self70, int _argc71, V c_77, V o_78, V _a75, V _a76, V[] _rest72) => {
if (_self70.IsNullish) _self70 = GlobalV;
o_78 = (o_78 is var _t79 && Truthy(_t79) ? _t79 : NewObj(0).V);
Set(_self70, "c", c_77);
Set(_self70, "p", Get(c_77, "p"));
Set(_self70, "k", Get(c_77, "k"));
Set(_self70, "it", Arr());
Set(_self70, "G", New(G("Map")));
Set(_self70, "split", (Get(o_78, "split").IsNullish ? ((V)((-1000000000D))) : Get(o_78, "split")));
Set(_self70, "bb", Arr(((V)(1000000000D)), ((V)(1000000000D)), ((V)((-1000000000D))), ((V)((-1000000000D)))));
Set(_self70, "sw", (Get(o_78, "sw").IsNullish ? ((V)(1.2)) : Get(o_78, "sw")));
Set(_self70, "piv", Get(o_78, "piv"));
Set(_self70, "dur", (Get(o_78, "dur") is var _t80 && Truthy(_t80) ? _t80 : ((V)(5.2))));
Set(_self70, "defs", ((V)("")));
Set(_self70, "dp", (Get(o_78, "dp") is var _t81 && Truthy(_t81) ? _t81 : dep_44));
return default;
}, 2, "Flora", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((RD_8 is var _t82 && !Truthy(_t82) ? _t82 : Get(RD_8, "PLUS3")) is var _t83 && !Truthy(_t83) ? _t83 : Get(RD_8, "H3")) is var _t84 && !Truthy(_t84) ? _t84 : X_9) is var _t85 && !Truthy(_t85) ? _t85 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_86.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "FLORA"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t87 = K_10;
if (_t87.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t87));
{ V _t88 = Get(_t87, "solid");
solid_11 = _t88; }
{ V _t89 = Get(_t87, "box");
box_12 = _t89; }
{ V _t90 = Get(_t87, "cyl");
cyl_13 = _t90; }
{ V _t91 = Get(_t87, "ball");
ball_14 = _t91; }
{ V _t92 = Get(_t87, "slab");
slab_15 = _t92; }
{ V _t93 = Get(_t87, "arcW");
arcW_16 = _t93; }
{ V _t94 = Get(_t87, "disc");
disc_17 = _t94; }
{ V _t95 = Get(_t87, "shade");
shade_18 = _t95; }
{ V _t96 = Get(_t87, "mix");
mix_19 = _t96; }
{ V _t97 = Get(_t87, "f1");
f1_20 = _t97; } }
H3_21 = Get(RD_8, "H3");
{ V _t98 = H3_21;
if (_t98.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t98));
{ V _t99 = Get(_t98, "rep");
rep_22 = _t99; }
{ V _t100 = Get(_t98, "rng");
rng_23 = _t100; }
{ V _t101 = Get(_t98, "n4");
n4_24 = _t101; }
{ V _t102 = Get(_t98, "P2");
P2_25 = _t102; }
{ V _t103 = Get(_t98, "plane");
plane_26 = _t103; }
{ V _t104 = Get(_t98, "planeH");
planeH_27 = _t104; }
{ V _t105 = Get(_t98, "an");
an_28 = _t105; }
{ V _t106 = Get(_t98, "anS");
anS_29 = _t106; }
{ V _t107 = Get(_t98, "atS");
atS_30 = _t107; }
{ V _t108 = Get(_t98, "BLUR");
BLUR_31 = _t108; }
{ V _t109 = Get(_t98, "mt");
mt_32 = _t109; }
{ V _t110 = Get(_t98, "wd");
wd_33 = _t110; }
{ V _t111 = Get(_t98, "cer");
cer_34 = _t111; }
{ V _t112 = Get(_t98, "pt");
pt_35 = _t112; } }
N_36 = Get(RD_8, "N");
em_37 = Get(Get(RD_8, "H"), "em");
PI_38 = System.Math.PI;
SA_39 = Get(X_9, "SA");
CA_40 = Get(X_9, "CA");
GOLD_41 = ((V)("#e2b14a"));
GL_42 = ((V)("#cfe8f2"));
LT_43 = Arr(((V)(((-0.5) / 1.24))), ((V)((1D / 1.24))), ((V)((0.55 / 1.24))));
dep_44 = Fn((V _arrowThis122, int _argc113, V x_119, V y_120, V z_121, V _a118, V[] _rest114) => {
return ((V)(((ToNum(y_120) * ToNum(SA_39)) + (((0.5 * ToNum(x_119)) + (0.866 * ToNum(z_121))) * ToNum(CA_40)))));
}, 3, "", true);
sub_45 = Fn((V _arrowThis131, int _argc123, V a_129, V b_130, V _a127, V _a128, V[] _rest124) => {
return Arr(((V)((ToNum(GetIdx(a_129, 0D)) - ToNum(GetIdx(b_130, 0D))))), ((V)((ToNum(GetIdx(a_129, 1D)) - ToNum(GetIdx(b_130, 1D))))), ((V)((ToNum(GetIdx(a_129, 2D)) - ToNum(GetIdx(b_130, 2D))))));
}, 2, "", true);
addv_46 = Fn((V _arrowThis141, int _argc132, V a_138, V b_139, V k_140, V _a137, V[] _rest133) => {
return Arr(Add(GetIdx(a_138, 0D), ((V)((ToNum(GetIdx(b_139, 0D)) * ToNum(k_140))))), Add(GetIdx(a_138, 1D), ((V)((ToNum(GetIdx(b_139, 1D)) * ToNum(k_140))))), Add(GetIdx(a_138, 2D), ((V)((ToNum(GetIdx(b_139, 2D)) * ToNum(k_140))))));
}, 3, "", true);
cross_47 = Fn((V _arrowThis150, int _argc142, V a_148, V b_149, V _a146, V _a147, V[] _rest143) => {
return Arr(((V)(((ToNum(GetIdx(a_148, 1D)) * ToNum(GetIdx(b_149, 2D))) - (ToNum(GetIdx(a_148, 2D)) * ToNum(GetIdx(b_149, 1D)))))), ((V)(((ToNum(GetIdx(a_148, 2D)) * ToNum(GetIdx(b_149, 0D))) - (ToNum(GetIdx(a_148, 0D)) * ToNum(GetIdx(b_149, 2D)))))), ((V)(((ToNum(GetIdx(a_148, 0D)) * ToNum(GetIdx(b_149, 1D))) - (ToNum(GetIdx(a_148, 1D)) * ToNum(GetIdx(b_149, 0D)))))));
}, 2, "", true);
SHP_48 = NewObj(9).Put("lance", Fn((V _arrowThis158, int _argc151, V t_157, V _a154, V _a155, V _a156, V[] _rest152) => {
return ((V)((Pow(FdLibm.Sin((PI_38 * ToNum(t_157))), 0.9) * (1D - (0.25 * ToNum(t_157))))));
}, 1, "lance", true)).Put("oval", Fn((V _arrowThis166, int _argc159, V t_165, V _a162, V _a163, V _a164, V[] _rest160) => {
return ((V)(Pow(FdLibm.Sin((PI_38 * ToNum(t_165))), 0.7)));
}, 1, "oval", true)).Put("heart", Fn((V _arrowThis174, int _argc167, V t_173, V _a170, V _a171, V _a172, V[] _rest168) => {
return ((V)(Pow(FdLibm.Sin((PI_38 * Pow(ToNum(t_173), 0.62))), 0.8)));
}, 1, "heart", true)).Put("fiddle", Fn((V _arrowThis182, int _argc175, V t_181, V _a178, V _a179, V _a180, V[] _rest176) => {
return ((V)((Pow(FdLibm.Sin((PI_38 * Pow(ToNum(t_181), 1.45))), 0.75) * (1D + (0.05 * FdLibm.Sin((ToNum(t_181) * 22D)))))));
}, 1, "fiddle", true)).Put("sword", Fn((V _arrowThis190, int _argc183, V t_189, V _a186, V _a187, V _a188, V[] _rest184) => {
return ((V)(Pow(FdLibm.Sin((PI_38 * Pow(ToNum(t_189), 0.8))), 0.55)));
}, 1, "sword", true)).Put("grass", Fn((V _arrowThis198, int _argc191, V t_197, V _a194, V _a195, V _a196, V[] _rest192) => {
return ((V)((Pow((1D - ToNum(t_197)), 0.8) * Min(1D, (ToNum(t_197) * 8D)))));
}, 1, "grass", true)).Put("coin", Fn((V _arrowThis206, int _argc199, V t_205, V _a202, V _a203, V _a204, V[] _rest200) => {
return ((V)(Pow(FdLibm.Sin((PI_38 * ToNum(t_205))), 0.5)));
}, 1, "coin", true)).Put("petal", Fn((V _arrowThis214, int _argc207, V t_213, V _a210, V _a211, V _a212, V[] _rest208) => {
return ((V)(Pow(FdLibm.Sin((PI_38 * Pow(ToNum(t_213), 0.8))), 0.6)));
}, 1, "petal", true)).Put("needle", Fn((V _arrowThis222, int _argc215, V t_221, V _a218, V _a219, V _a220, V[] _rest216) => {
return ((V)(((0.5 * Min(1D, (ToNum(t_221) * 6D))) * (1D - (ToNum(t_221) * 0.6)))));
}, 1, "needle", true)).V;
Set(Get(Flora_49, "prototype"), "q", Fn((V _self223, int _argc224, V P_230, V _a227, V _a228, V _a229, V[] _rest225) => {
V q_231 = default;
V b_232 = default;
if (_self223.IsNullish) _self223 = GlobalV;
q_231 = Invoke(_self223, "p", GetIdx(P_230, 0D), GetIdx(P_230, 1D), GetIdx(P_230, 2D));
b_232 = Get(_self223, "bb");
if (Lt(GetIdx(q_231, 0D), GetIdx(b_232, 0D))) {
SetIdx(b_232, 0D, GetIdx(q_231, 0D));
}
if (Lt(GetIdx(q_231, 1D), GetIdx(b_232, 1D))) {
SetIdx(b_232, 1D, GetIdx(q_231, 1D));
}
if (Gt(GetIdx(q_231, 0D), GetIdx(b_232, 2D))) {
SetIdx(b_232, 2D, GetIdx(q_231, 0D));
}
if (Gt(GetIdx(q_231, 1D), GetIdx(b_232, 3D))) {
SetIdx(b_232, 3D, GetIdx(q_231, 1D));
}
return q_231;
return default;
}, 1, "", false));
Set(Get(Flora_49, "prototype"), "add", Fn((V _self233, int _argc234, V d_240, V s_241, V layer_242, V _a239, V[] _rest235) => {
if (_self233.IsNullish) _self233 = GlobalV;
Invoke(Get(_self233, "it"), "push", NewObj(3).Put("d", d_240).Put("s", s_241).Put("L", layer_242).V);
return default;
}, 3, "", false));
Set(Get(Flora_49, "prototype"), "grad", Fn((V _self243, int _argc244, V c0_250, V c1_251, V _a248, V _a249, V[] _rest245) => {
V id_252 = default;
if (_self243.IsNullish) _self243 = GlobalV;
id_252 = ((V)(JsStrBuf.Begin().S("fg").V(Invoke(c0_250, "slice", ((V)(1D)))).V(Invoke(c1_251, "slice", ((V)(1D)))).End()));
if (!(Truthy(Invoke(Get(_self243, "G"), "has", id_252)))) {
Invoke(Get(_self243, "G"), "set", id_252, ((V)(JsStrBuf.Begin().S("<radialGradient id=\"").V(id_252).S("\" cx=\"34%\" cy=\"30%\" r=\"78%\"><stop offset=\"0\" stop-color=\"").V(c0_250).S("\"/><stop offset=\"1\" stop-color=\"").V(c1_251).S("\"/></radialGradient>").End())));
}
return id_252;
return default;
}, 2, "", false));
sm_50 = Fn((V _arrowThis261, int _argc253, V Q_259, V close_260, V _a257, V _a258, V[] _rest254) => {
JsStrBuf d_262 = null;
d_262 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(P2_25, V.Undef, GetIdx(Q_259, 0D))).End());
{
double i_263 = 0;
i_263 = 1D;
while (true) {
if (!((i_263 < (ToNum(Get(Q_259, "length")) - 1D)))) break;
d_262.S("Q").V(Call(P2_25, V.Undef, GetIdx(Q_259, i_263))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(Add(GetIdx(GetIdx(Q_259, i_263), 0D), GetIdx(GetIdx(Q_259, (i_263 + 1D)), 0D))) / 2D))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(Add(GetIdx(GetIdx(Q_259, i_263), 1D), GetIdx(GetIdx(Q_259, (i_263 + 1D)), 1D))) / 2D)))));
i_263++;
}
}
return ((V)(JsStrBuf.Begin().S(d_262.Str).S("L").V(Call(P2_25, V.Undef, GetIdx(Q_259, (ToNum(Get(Q_259, "length")) - 1D)))).S((Truthy(close_260) ? "Z" : "")).End()));
return default;
}, 2, "", true);
Set(Get(Flora_49, "prototype"), "leaf", Fn((V _self265, int _argc266, V o_272, V _a269, V _a270, V _a271, V[] _rest267) => {
V n_273 = default;
V b_274 = default;
V len_275 = default;
V wid_276 = default;
V droop_277 = default;
V sh_278 = default;
V col_279 = default;
V az_280 = default;
double cz_281 = 0;
double sz_282 = 0;
V M_283 = default;
V e_284 = default;
V P_285 = default;
double em2_286 = 0;
V dir_287 = default;
V upv_288 = default;
V w0_289 = default;
V rl_290 = default;
V W_291 = default;
V Lp_292 = default;
V Rp_293 = default;
V nn_294 = default;
V L_295 = default;
double nzr_296 = 0;
double nxr_297 = 0;
double vis_298 = 0;
double lit_299 = 0;
V back_300 = default;
V @base_301 = default;
double k_302 = 0;
V c1_303 = default;
V c2_304 = default;
V oc_305 = default;
V qm_306 = default;
V ql_307 = default;
V qr_308 = default;
V s_309 = default;
if (_self265.IsNullish) _self265 = GlobalV;
n_273 = (Get(o_272, "seg") is var _t310 && Truthy(_t310) ? _t310 : ((V)(7D)));
b_274 = Get(o_272, "b");
len_275 = Get(o_272, "len");
wid_276 = Get(o_272, "wid");
droop_277 = (Get(o_272, "droop").IsNullish ? ((V)(0.5)) : Get(o_272, "droop"));
sh_278 = GetK(SHP_48, (Get(o_272, "sh") is var _t311 && Truthy(_t311) ? _t311 : ((V)("lance"))));
col_279 = Get(o_272, "col");
az_280 = Get(o_272, "az");
cz_281 = FdLibm.Cos(ToNum(az_280));
sz_282 = FdLibm.Sin(ToNum(az_280));
M_283 = Arr(b_274);
e_284 = Get(o_272, "el");
P_285 = b_274;
{
double i_312 = 0;
i_312 = 0D;
while (true) {
if (!(Lt(((V)(i_312)), n_273))) break;
double t_314 = 0;
t_314 = ((i_312 + 0.5) / ToNum(n_273));
e_284 = ((V)(((ToNum(Get(o_272, "el")) - ((ToNum(droop_277) * t_314) * 1.7)) + ((ToNum((Get(o_272, "curl") is var _t315 && Truthy(_t315) ? _t315 : ((V)(0D)))) * t_314) * t_314))));
P_285 = Call(addv_46, V.Undef, P_285, Arr(((V)((FdLibm.Cos(ToNum(e_284)) * cz_281))), ((V)(FdLibm.Sin(ToNum(e_284)))), ((V)((FdLibm.Cos(ToNum(e_284)) * sz_282)))), ((V)((ToNum(len_275) / ToNum(n_273)))));
Invoke(M_283, "push", P_285);
i_312++;
}
}
em2_286 = (ToNum(Get(o_272, "el")) - (ToNum(droop_277) * 0.85));
dir_287 = Arr(((V)((FdLibm.Cos(em2_286) * cz_281))), ((V)(FdLibm.Sin(em2_286))), ((V)((FdLibm.Cos(em2_286) * sz_282))));
upv_288 = Arr(((V)(((-FdLibm.Sin(em2_286)) * cz_281))), ((V)(FdLibm.Cos(em2_286))), ((V)(((-FdLibm.Sin(em2_286)) * sz_282))));
w0_289 = Arr(((V)((-sz_282))), ((V)(0D)), ((V)(cz_281)));
rl_290 = (Get(o_272, "roll") is var _t316 && Truthy(_t316) ? _t316 : ((V)(0D)));
W_291 = Call(addv_46, V.Undef, Arr(((V)((ToNum(GetIdx(w0_289, 0D)) * FdLibm.Cos(ToNum(rl_290))))), ((V)(0D)), ((V)((ToNum(GetIdx(w0_289, 2D)) * FdLibm.Cos(ToNum(rl_290)))))), upv_288, ((V)(FdLibm.Sin(ToNum(rl_290)))));
Lp_292 = Arr();
Rp_293 = Arr();
Invoke(M_283, "forEach", Fn((V _arrowThis325, int _argc317, V m_323, V i_324, V _a321, V _a322, V[] _rest318) => {
double t_326 = 0;
double f_327 = 0;
t_326 = (ToNum(i_324) / ToNum(n_273));
f_327 = ((ToNum(Call(sh_278, V.Undef, ((V)(t_326)))) * ToNum(wid_276)) / 2D);
Invoke(Lp_292, "push", Call(addv_46, V.Undef, m_323, W_291, ((V)(f_327))));
Invoke(Rp_293, "push", Call(addv_46, V.Undef, m_323, W_291, ((V)((-f_327)))));
return default;
}, 2, "", true));
nn_294 = Call(cross_47, V.Undef, dir_287, W_291);
L_295 = (((V)(Hypot(ToNum(GetIdx(nn_294, 0D)), ToNum(GetIdx(nn_294, 1D)), ToNum(GetIdx(nn_294, 2D))))) is var _t328 && Truthy(_t328) ? _t328 : ((V)(1D)));
nn_294 = Invoke(nn_294, "map", Fn((V _arrowThis336, int _argc329, V v_335, V _a332, V _a333, V _a334, V[] _rest330) => {
return ((V)((ToNum(v_335) / ToNum(L_295))));
}, 1, "", true));
nzr_296 = ((0.5 * ToNum(GetIdx(nn_294, 0D))) + (0.866 * ToNum(GetIdx(nn_294, 2D))));
nxr_297 = ((0.866 * ToNum(GetIdx(nn_294, 0D))) - (0.5 * ToNum(GetIdx(nn_294, 2D))));
vis_298 = ((ToNum(GetIdx(nn_294, 1D)) * ToNum(SA_39)) + (nzr_296 * ToNum(CA_40)));
lit_299 = (((nxr_297 * ToNum(GetIdx(LT_43, 0D))) + (ToNum(GetIdx(nn_294, 1D)) * ToNum(GetIdx(LT_43, 1D)))) + (nzr_296 * ToNum(GetIdx(LT_43, 2D))));
back_300 = ((vis_298 < 0D) ? V.True : V.False);
if (Truthy(back_300)) {
lit_299 = (-lit_299);
}
@base_301 = (Truthy(back_300) ? (Get(o_272, "col2") is var _t337 && Truthy(_t337) ? _t337 : Call(mix_19, V.Undef, col_279, ((V)("#ffffff")), ((V)(0.18)))) : col_279);
k_302 = ((0.66 + (0.46 * Max(0D, lit_299))) * ToNum((Get(o_272, "lk") is var _t338 && Truthy(_t338) ? _t338 : ((V)(1D)))));
c1_303 = Call(shade_18, V.Undef, @base_301, ((V)((k_302 * 1.04))));
c2_304 = Call(shade_18, V.Undef, @base_301, ((V)((k_302 * 0.84))));
oc_305 = Call(shade_18, V.Undef, col_279, ((V)(0.5)));
qm_306 = Invoke(M_283, "map", Fn((V _arrowThis346, int _argc339, V m_345, V _a342, V _a343, V _a344, V[] _rest340) => {
return Invoke(_self265, "q", m_345);
}, 1, "", true));
ql_307 = Invoke(Lp_292, "map", Fn((V _arrowThis354, int _argc347, V m_353, V _a350, V _a351, V _a352, V[] _rest348) => {
return Invoke(_self265, "q", m_353);
}, 1, "", true));
qr_308 = Invoke(Rp_293, "map", Fn((V _arrowThis362, int _argc355, V m_361, V _a358, V _a359, V _a360, V[] _rest356) => {
return Invoke(_self265, "q", m_361);
}, 1, "", true));
s_309 = V.Undef;
if (Truthy(Get(o_272, "simple"))) {
s_309 = ((V)(JsStrBuf.Begin().S("<path d=\"").V(Call(sm_50, V.Undef, Invoke(ql_307, "concat", Invoke(Invoke(qr_308, "slice"), "reverse")), ((V)(1D)))).S("\" fill=\"").V(c1_303).S("\" stroke=\"").V(oc_305).S("\" stroke-width=\"0.3\"/>").End()));
} else {
s_309 = ((V)(JsStrBuf.Begin().S("<path d=\"").V(Call(sm_50, V.Undef, Invoke(qm_306, "concat", Invoke(Invoke(ql_307, "slice"), "reverse")), ((V)(1D)))).S("\" fill=\"").V(c1_303).S("\"/><path d=\"").V(Call(sm_50, V.Undef, Invoke(qm_306, "concat", Invoke(Invoke(qr_308, "slice"), "reverse")), ((V)(1D)))).S("\" fill=\"").V(c2_304).S("\"/>").End()));
if (Truthy(Get(o_272, "band"))) {
JsStrBuf d_363 = null;
d_363 = new JsStrBuf("");
{
double i_364 = 0;
i_364 = 1D;
while (true) {
if (!(Lt(((V)(i_364)), n_273))) break;
V a_366 = default;
V bq_367 = default;
V m_368 = default;
a_366 = GetIdx(ql_307, i_364);
bq_367 = GetIdx(qr_308, i_364);
m_368 = GetIdx(qm_306, i_364);
d_363.S("M").V(Call(P2_25, V.Undef, a_366)).S("Q").V(Call(f1_20, V.Undef, GetIdx(m_368, 0D))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(m_368, 1D)) - 0.8))))).S(" ").V(Call(P2_25, V.Undef, bq_367));
i_364 = (i_364 + 1D);
}
}
s_309 = ((V)(JsStrBuf.Begin().V(s_309).S("<path d=\"").S(d_363.Str).S("\" fill=\"none\" stroke=\"").V(Get(o_272, "band")).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)(((ToNum(len_275) / ToNum(n_273)) * 0.32))))).S("\" opacity=\"0.55\"/>").End()));
}
if (Truthy(Get(o_272, "vein"))) {
JsStrBuf d_369 = null;
d_369 = new JsStrBuf("");
{
double i_370 = 0;
i_370 = 1D;
while (true) {
if (!(Lt(((V)(i_370)), n_273))) break;
d_369.S("M").V(Call(P2_25, V.Undef, GetIdx(qm_306, i_370))).S("L").V(Call(P2_25, V.Undef, GetIdx(ql_307, Min(ToNum(n_273), (i_370 + 1D))))).S("M").V(Call(P2_25, V.Undef, GetIdx(qm_306, i_370))).S("L").V(Call(P2_25, V.Undef, GetIdx(qr_308, Min(ToNum(n_273), (i_370 + 1D)))));
i_370++;
}
}
s_309 = ((V)(JsStrBuf.Begin().V(s_309).S("<path d=\"").S(d_369.Str).S("\" fill=\"none\" stroke=\"").V(Call(mix_19, V.Undef, @base_301, ((V)("#ffffff")), ((V)(0.32)))).S("\" stroke-width=\"0.28\" opacity=\"0.7\"/>").End()));
}
if (Truthy(Get(o_272, "slit"))) {
JsStrBuf d_372 = null;
d_372 = new JsStrBuf("");
{
double i_373 = 0;
i_373 = 2D;
while (true) {
if (!((i_373 < (ToNum(n_273) - 1D)))) break;
d_372.S("M").V(Call(P2_25, V.Undef, GetIdx(ql_307, i_373))).S("L").V(Call(f1_20, V.Undef, ((V)(((ToNum(GetIdx(GetIdx(ql_307, i_373), 0D)) * 0.55) + (ToNum(GetIdx(GetIdx(qm_306, i_373), 0D)) * 0.45)))))).S(" ").V(Call(f1_20, V.Undef, ((V)(((ToNum(GetIdx(GetIdx(ql_307, i_373), 1D)) * 0.55) + (ToNum(GetIdx(GetIdx(qm_306, i_373), 1D)) * 0.45)))))).S("M").V(Call(P2_25, V.Undef, GetIdx(qr_308, i_373))).S("L").V(Call(f1_20, V.Undef, ((V)(((ToNum(GetIdx(GetIdx(qr_308, i_373), 0D)) * 0.55) + (ToNum(GetIdx(GetIdx(qm_306, i_373), 0D)) * 0.45)))))).S(" ").V(Call(f1_20, V.Undef, ((V)(((ToNum(GetIdx(GetIdx(qr_308, i_373), 1D)) * 0.55) + (ToNum(GetIdx(GetIdx(qm_306, i_373), 1D)) * 0.45))))));
i_373 = (i_373 + 1D);
}
}
s_309 = ((V)(JsStrBuf.Begin().V(s_309).S("<path d=\"").S(d_372.Str).S("\" fill=\"none\" stroke=\"").V(Call(shade_18, V.Undef, @base_301, ((V)(0.45)))).S("\" stroke-width=\"0.9\" stroke-linecap=\"round\"/>").End()));
}
s_309 = ((V)(JsStrBuf.Begin().V(s_309).S("<path d=\"").V(Call(sm_50, V.Undef, Invoke(Invoke(ql_307, "concat", Invoke(Invoke(qr_308, "slice", ((V)(1D)), ((V)((-1D)))), "reverse")), "concat", Arr(GetIdx(ql_307, 0D))))).S("\" fill=\"none\" stroke=\"").V((Get(o_272, "edge") is var _t375 && Truthy(_t375) ? _t375 : oc_305)).S("\" stroke-width=\"").N((Truthy(Get(o_272, "edge")) ? 0.6 : 0.35)).S("\" stroke-linejoin=\"round\"/><path d=\"").V(Call(sm_50, V.Undef, qm_306)).S("\" fill=\"none\" stroke=\"").V(Call(mix_19, V.Undef, @base_301, ((V)("#ffffff")), ((V)(0.38)))).S("\" stroke-width=\"0.35\"/>").End()));
if (Truthy((Get(o_272, "gloss") is var _t376 && !Truthy(_t376) ? _t376 : (!(Truthy(back_300)) ? V.True : V.False)))) {
s_309 = ((V)(JsStrBuf.Begin().V(s_309).S("<path d=\"").V(Call(sm_50, V.Undef, Invoke(Invoke(qm_306, "slice", ((V)(1D)), ((V)(System.Math.Ceiling((ToNum(n_273) * 0.7))))), "map", Fn((V _arrowThis385, int _argc377, V m_383, V i_384, V _a381, V _a382, V[] _rest378) => {
return Arr(((V)(((ToNum(GetIdx(m_383, 0D)) * 0.6) + (ToNum(GetIdx(GetK(ql_307, Add(i_384, ((V)(1D)))), 0D)) * 0.4)))), ((V)(((ToNum(GetIdx(m_383, 1D)) * 0.6) + (ToNum(GetIdx(GetK(ql_307, Add(i_384, ((V)(1D)))), 1D)) * 0.4)))));
}, 2, "", true)))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.7\" opacity=\"0.32\" stroke-linecap=\"round\"/>").End()));
}
}
Invoke(_self265, "add", Add(InvokeSpread(_self265, "dp", new ArrBuilder().Spread(GetIdx(M_283, System.Math.Floor((ToNum(n_273) / 2D)))).V), (Get(o_272, "db") is var _t386 && Truthy(_t386) ? _t386 : ((V)(0D)))), s_309, Get(o_272, "L"));
return GetK(M_283, n_273);
return default;
}, 1, "", false));
Set(Get(Flora_49, "prototype"), "stem", Fn((V _self387, int _argc388, V pts_394, V w0_395, V w1_396, V col_397, V[] _rest389) => {
double n_399 = 0;
V o_398 = default;
if (_self387.IsNullish) _self387 = GlobalV;
o_398 = (_argc388 > 4 ? _rest389[0] : V.Undef);
o_398 = (o_398 is var _t400 && Truthy(_t400) ? _t400 : NewObj(0).V);
n_399 = (ToNum(Get(pts_394, "length")) - 1D);
{
double i_401 = 0;
i_401 = 0D;
while (true) {
if (!((i_401 < n_399))) break;
V a_403 = default;
V b_404 = default;
double w_405 = 0;
V s_406 = default;
a_403 = Invoke(_self387, "q", GetIdx(pts_394, i_401));
b_404 = Invoke(_self387, "q", GetIdx(pts_394, (i_401 + 1D)));
w_405 = (ToNum(Add(w0_395, ((V)((((ToNum(w1_396) - ToNum(w0_395)) * (i_401 + 0.5)) / n_399))))) * ToNum(Get(_self387, "k")));
s_406 = ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(P2_25, V.Undef, a_403)).S("L").V(Call(P2_25, V.Undef, b_404)).S("\" stroke=\"").V(Call(shade_18, V.Undef, col_397, ((V)(0.6)))).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((w_405 + 0.7))))).S("\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_25, V.Undef, a_403)).S("L").V(Call(P2_25, V.Undef, b_404)).S("\" stroke=\"").V(col_397).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)(w_405)))).S("\" stroke-linecap=\"round\"/>").S(((w_405 > 1.6) ? JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(a_403, 0D)) - (w_405 * 0.22)))))).S(" ").V(Call(f1_20, V.Undef, GetIdx(a_403, 1D))).S("L").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_404, 0D)) - (w_405 * 0.22)))))).S(" ").V(Call(f1_20, V.Undef, GetIdx(b_404, 1D))).S("\" stroke=\"").V(Call(mix_19, V.Undef, col_397, ((V)("#ffffff")), ((V)(0.3)))).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((w_405 * 0.28))))).S("\" stroke-linecap=\"round\" opacity=\"0.8\"/>").End() : "")).S((Truthy((Get(o_398, "bark") is var _t407 && !Truthy(_t407) ? _t407 : ((w_405 > 2D) ? V.True : V.False))) ? JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_20, V.Undef, Add(GetIdx(a_403, 0D), ((V)((w_405 * 0.18)))))).S(" ").V(Call(f1_20, V.Undef, GetIdx(a_403, 1D))).S("L").V(Call(f1_20, V.Undef, Add(GetIdx(b_404, 0D), ((V)((w_405 * 0.12)))))).S(" ").V(Call(f1_20, V.Undef, GetIdx(b_404, 1D))).S("\" stroke=\"").V(Call(shade_18, V.Undef, col_397, ((V)(0.7)))).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((w_405 * 0.12))))).S("\" stroke-dasharray=\"").V(Call(f1_20, V.Undef, ((V)((w_405 * 0.6))))).S(" ").V(Call(f1_20, V.Undef, ((V)((w_405 * 0.4))))).S("\"/>").End() : "")).S((Truthy((Get(o_398, "node") is var _t408 && !Truthy(_t408) ? _t408 : ((V)(i_401)))) ? JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(a_403, 0D)) - (w_405 * 0.55)))))).S(" ").V(Call(f1_20, V.Undef, GetIdx(a_403, 1D))).S("h").V(Call(f1_20, V.Undef, ((V)((w_405 * 1.1))))).S("\" stroke=\"").V(Call(shade_18, V.Undef, col_397, ((V)(0.68)))).S("\" stroke-width=\"0.6\"/>").End() : "")).End()));
Invoke(_self387, "add", Add(((V)(((ToNum(InvokeSpread(_self387, "dp", new ArrBuilder().Spread(GetIdx(pts_394, i_401)).V)) * 0.5) + (ToNum(InvokeSpread(_self387, "dp", new ArrBuilder().Spread(GetIdx(pts_394, (i_401 + 1D))).V)) * 0.5)))), (Get(o_398, "db") is var _t409 && Truthy(_t409) ? _t409 : ((V)(0D)))), s_406, Get(o_398, "L"));
i_401++;
}
}
return default;
}, 5, "", false));
Set(Get(Flora_49, "prototype"), "blob", Fn((V _self410, int _argc411, V P_417, V r_418, V col_419, V o_420, V[] _rest412) => {
V q_421 = default;
double R_422 = 0;
V s_423 = default;
if (_self410.IsNullish) _self410 = GlobalV;
o_420 = (o_420 is var _t424 && Truthy(_t424) ? _t424 : NewObj(0).V);
q_421 = Invoke(_self410, "q", P_417);
R_422 = (ToNum(r_418) * ToNum(Get(_self410, "k")));
s_423 = ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_20, V.Undef, GetIdx(q_421, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(q_421, 1D))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((R_422 * ToNum((Get(o_420, "sx") is var _t425 && Truthy(_t425) ? _t425 : ((V)(1D))))))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((R_422 * ToNum((Get(o_420, "sy") is var _t426 && Truthy(_t426) ? _t426 : ((V)(0.86))))))))).S("\" fill=\"url(#").V(Invoke(_self410, "grad", Call(mix_19, V.Undef, col_419, ((V)("#ffffff")), (Get(o_420, "hl").IsNullish ? ((V)(0.35)) : Get(o_420, "hl"))), Call(shade_18, V.Undef, col_419, ((V)(0.62))))).S(")\" stroke=\"").V(Call(shade_18, V.Undef, col_419, ((V)(0.5)))).S("\" stroke-width=\"").V((Get(o_420, "ow") is var _t427 && Truthy(_t427) ? _t427 : ((V)(0.4)))).S("\"").S((Truthy(Get(o_420, "op")) ? JsStrBuf.Begin().S(" opacity=\"").V(Get(o_420, "op")).S("\"").End() : "")).S("/>").S((Truthy(Get(o_420, "shine")) ? JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_421, 0D)) - (R_422 * 0.32)))))).S("\" cy=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_421, 1D)) - (R_422 * 0.34)))))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((R_422 * 0.26))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((R_422 * 0.18))))).S("\" fill=\"#ffffff\" opacity=\"0.6\"/>").End() : "")).V((Truthy(Get(o_420, "extra")) ? Invoke(o_420, "extra", q_421, ((V)(R_422))) : ((V)("")))).End()));
Invoke(_self410, "q", Arr(((V)((ToNum(GetIdx(P_417, 0D)) - ToNum(r_418)))), ((V)((ToNum(GetIdx(P_417, 1D)) - ToNum(r_418)))), GetIdx(P_417, 2D)));
Invoke(_self410, "q", Arr(Add(GetIdx(P_417, 0D), r_418), Add(GetIdx(P_417, 1D), r_418), GetIdx(P_417, 2D)));
Invoke(_self410, "add", Add(InvokeSpread(_self410, "dp", new ArrBuilder().Spread(P_417).V), (Get(o_420, "db") is var _t428 && Truthy(_t428) ? _t428 : ((V)(0D)))), s_423, Get(o_420, "L"));
return default;
}, 4, "", false));
Set(Get(Flora_49, "prototype"), "flower", Fn((V _self429, int _argc430, V P_436, V r_437, V col_438, V o_439, V[] _rest431) => {
V q_440 = default;
double R_441 = 0;
V n_442 = default;
V rot_443 = default;
JsStrBuf s_444 = null;
if (_self429.IsNullish) _self429 = GlobalV;
o_439 = (o_439 is var _t445 && Truthy(_t445) ? _t445 : NewObj(0).V);
q_440 = Invoke(_self429, "q", P_436);
R_441 = (ToNum(r_437) * ToNum(Get(_self429, "k")));
n_442 = (Get(o_439, "n") is var _t446 && Truthy(_t446) ? _t446 : ((V)(5D)));
rot_443 = (Get(o_439, "rot") is var _t447 && Truthy(_t447) ? _t447 : ((V)(0D)));
s_444 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_25, V.Undef, q_440)).S(") scale(1 ").V((Get(o_439, "sq") is var _t448 && Truthy(_t448) ? _t448 : ((V)(0.78)))).S(") rotate(").V(Call(f1_20, V.Undef, rot_443)).S(")\">").End());
Call(rep_22, V.Undef, n_442, Fn((V _arrowThis456, int _argc449, V i_455, V _a452, V _a453, V _a454, V[] _rest450) => {
double a_457 = 0;
a_457 = ((ToNum(i_455) * 360D) / ToNum(n_442));
s_444.S("<ellipse cx=\"0\" cy=\"").V(Call(f1_20, V.Undef, ((V)(((-R_441) * 0.55))))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((R_441 * ToNum((Get(o_439, "pw") is var _t458 && Truthy(_t458) ? _t458 : ((V)(0.42))))))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((R_441 * 0.58))))).S("\" transform=\"rotate(").V(Call(f1_20, V.Undef, ((V)(a_457)))).S(")\" fill=\"").V(col_438).S("\" stroke=\"").V(Call(shade_18, V.Undef, col_438, ((V)(0.72)))).S("\" stroke-width=\"0.25\"/>");
return default;
}, 1, "", true));
s_444.S("<circle r=\"").V(Call(f1_20, V.Undef, ((V)((R_441 * 0.24))))).S("\" fill=\"").V((Get(o_439, "ctr") is var _t459 && Truthy(_t459) ? _t459 : ((V)("#f2c94c")))).S("\"/></g>");
Invoke(_self429, "add", Add(Add(InvokeSpread(_self429, "dp", new ArrBuilder().Spread(P_436).V), ((V)(0.4))), (Get(o_439, "db") is var _t460 && Truthy(_t460) ? _t460 : ((V)(0D)))), ((V)(s_444.Str)), Get(o_439, "L"));
return default;
}, 4, "", false));
Set(Get(Flora_49, "prototype"), "clump", Fn((V _self461, int _argc462, V C_468, V rx_469, V ry_470, V rz_471, V[] _rest463) => {
V R_474 = default;
V cols_475 = default;
V n_472 = default;
V o_473 = default;
if (_self461.IsNullish) _self461 = GlobalV;
n_472 = (_argc462 > 4 ? _rest463[0] : V.Undef);
o_473 = (_argc462 > 5 ? _rest463[1] : V.Undef);
R_474 = Get(o_473, "R");
cols_475 = Get(o_473, "cols");
Invoke(_self461, "blob", Arr(GetIdx(C_468, 0D), ((V)((ToNum(GetIdx(C_468, 1D)) - (ToNum(ry_470) * 0.4)))), GetIdx(C_468, 2D)), ((V)((Max(ToNum(rx_469), ToNum(rz_471)) * 0.82))), Call(shade_18, V.Undef, GetIdx(cols_475, 0D), ((V)(0.72))), NewObj(5).Put("sy", ((V)(((ToNum(ry_470) / Max(ToNum(rx_469), ToNum(rz_471))) * 0.9)))).Put("hl", ((V)(0.15))).Put("ow", ((V)(0.3))).Put("db", ((V)(((-ToNum(ry_470)) * 0.6)))).Put("L", Get(o_473, "L")).V);
Call(rep_22, V.Undef, n_472, Fn((V _arrowThis483, int _argc476, V i_482, V _a479, V _a480, V _a481, V[] _rest477) => {
double u_484 = 0;
double v_485 = 0;
double sh_486 = 0;
V d_487 = default;
V P_488 = default;
double li_489 = 0;
V col_490 = default;
u_484 = ((ToNum(Call(R_474, V.Undef)) * 2D) * PI_38);
v_485 = FdLibm.Acos((1D - (2D * Pow(ToNum(Call(R_474, V.Undef)), ToNum((Get(o_473, "top") is var _t491 && Truthy(_t491) ? _t491 : ((V)(0.8))))))));
sh_486 = (0.72 + (ToNum(Call(R_474, V.Undef)) * 0.32));
d_487 = Arr(((V)((FdLibm.Sin(v_485) * FdLibm.Cos(u_484)))), ((V)(FdLibm.Cos(v_485))), ((V)((FdLibm.Sin(v_485) * FdLibm.Sin(u_484)))));
P_488 = Arr(Add(GetIdx(C_468, 0D), ((V)(((ToNum(GetIdx(d_487, 0D)) * ToNum(rx_469)) * sh_486)))), Add(GetIdx(C_468, 1D), ((V)(((ToNum(GetIdx(d_487, 1D)) * ToNum(ry_470)) * sh_486)))), Add(GetIdx(C_468, 2D), ((V)(((ToNum(GetIdx(d_487, 2D)) * ToNum(rz_471)) * sh_486)))));
li_489 = (ToNum(Add(Add(((V)(((-ToNum(GetIdx(d_487, 0D))) * 0.5))), GetIdx(d_487, 1D)), ((V)((ToNum(GetIdx(d_487, 2D)) * 0.55))))) / 1.24);
col_490 = GetIdx(cols_475, System.Math.Floor((ToNum(Call(R_474, V.Undef)) * ToNum(Get(cols_475, "length")))));
Invoke(_self461, "leaf", NewObj(14).Put("b", P_488).Put("az", ((V)((FdLibm.Atan2(ToNum(GetIdx(d_487, 2D)), ToNum(GetIdx(d_487, 0D))) + ((ToNum(Call(R_474, V.Undef)) - 0.5) * 1.6))))).Put("el", ((V)(((FdLibm.Asin(Max((-1D), Min(1D, ToNum(GetIdx(d_487, 1D))))) * 0.6) + ((ToNum(Call(R_474, V.Undef)) - 0.3) * 0.8))))).Put("len", ((V)((ToNum(Get(o_473, "len")) * (0.8 + (ToNum(Call(R_474, V.Undef)) * 0.4)))))).Put("wid", ((V)((ToNum(Get(o_473, "wid")) * (0.8 + (ToNum(Call(R_474, V.Undef)) * 0.4)))))).Put("droop", (Get(o_473, "droop").IsNullish ? ((V)(0.25)) : Get(o_473, "droop"))).Put("roll", ((V)(((ToNum(Call(R_474, V.Undef)) - 0.5) * 1.2)))).Put("sh", (Get(o_473, "sh") is var _t492 && Truthy(_t492) ? _t492 : ((V)("oval")))).Put("col", col_490).Put("col2", Get(o_473, "col2")).Put("simple", (!SEqN(Get(o_473, "simple"), 0D) ? V.True : V.False)).Put("seg", ((V)(4D))).Put("lk", ((V)((0.9 + (li_489 * 0.25))))).Put("L", Get(o_473, "L")).V);
return default;
}, 1, "", true));
return default;
}, 6, "", false));
Set(Get(Flora_49, "prototype"), "out", Fn((V _self493, int _argc494, V _a496, V _a497, V _a498, V _a499, V[] _rest495) => {
V B_500 = default;
V F_501 = default;
V pv_502 = default;
V sw_503 = default;
V wrap_504 = default;
double m_505 = 0;
V b_506 = default;
if (_self493.IsNullish) _self493 = GlobalV;
Invoke(Get(_self493, "it"), "sort", Fn((V _arrowThis515, int _argc507, V a_513, V b_514, V _a511, V _a512, V[] _rest508) => {
return ((V)((ToNum(Get(a_513, "d")) - ToNum(Get(b_514, "d")))));
}, 2, "", true));
B_500 = Invoke(Get(_self493, "it"), "filter", Fn((V _arrowThis523, int _argc516, V e_522, V _a519, V _a520, V _a521, V[] _rest517) => {
return ((SEqS(Get(e_522, "L"), "b") || (Get(e_522, "L").IsNullish && Lt(Get(e_522, "d"), Get(_self493, "split")))) ? V.True : V.False);
}, 1, "", true));
F_501 = Invoke(Get(_self493, "it"), "filter", Fn((V _arrowThis531, int _argc524, V e_530, V _a527, V _a528, V _a529, V[] _rest525) => {
return (!((SEqS(Get(e_530, "L"), "b") || (Get(e_530, "L").IsNullish && Lt(Get(e_530, "d"), Get(_self493, "split"))))) ? V.True : V.False);
}, 1, "", true));
pv_502 = (Truthy(Get(_self493, "piv")) ? InvokeSpread(_self493, "p", new ArrBuilder().Spread(Get(_self493, "piv")).V) : V.Null);
sw_503 = Get(_self493, "sw");
wrap_504 = Fn((V _arrowThis539, int _argc532, V L_538, V _a535, V _a536, V _a537, V[] _rest533) => {
V s_540 = default;
s_540 = Invoke(Invoke(L_538, "map", Fn((V _arrowThis548, int _argc541, V e_547, V _a544, V _a545, V _a546, V[] _rest542) => {
return Get(e_547, "s");
}, 1, "", true)), "join", ((V)("")));
return ((!(Truthy(pv_502)) || !(Truthy(sw_503))) ? s_540 : ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_30, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().S("0 ").V(Call(P2_25, V.Undef, pv_502)).S(";").V(sw_503).S(" ").V(Call(P2_25, V.Undef, pv_502)).S(";").N(((-ToNum(sw_503)) * 0.7)).S(" ").V(Call(P2_25, V.Undef, pv_502)).S(";0 ").V(Call(P2_25, V.Undef, pv_502)).End())), Get(_self493, "dur"))).V(s_540).S("</g>").End())));
return default;
}, 1, "", true);
m_505 = 3D;
b_506 = Get(_self493, "bb");
return NewObj(4).Put("defs", Add(Invoke(new ArrBuilder().Spread(Invoke(Get(_self493, "G"), "values")).V, "join", ((V)(""))), Get(_self493, "defs"))).Put("back", Call(wrap_504, V.Undef, B_500)).Put("front", Add(Call(wrap_504, V.Undef, F_501), (Get(_self493, "over") is var _t549 && Truthy(_t549) ? _t549 : ((V)(""))))).Put("bb", Arr(((V)((ToNum(GetIdx(b_506, 0D)) - m_505))), ((V)((ToNum(GetIdx(b_506, 1D)) - m_505))), Add(GetIdx(b_506, 2D), ((V)(m_505))), Add(GetIdx(b_506, 3D), ((V)(m_505))))).V;
return default;
}, 0, "", false));
FL_51 = Fn((V _arrowThis558, int _argc550, V opt_556, V draw_557, V _a554, V _a555, V[] _rest551) => {
return Fn((V _arrowThis566, int _argc559, V c_565, V _a562, V _a563, V _a564, V[] _rest560) => {
V E_567 = default;
E_567 = New(Flora_49, c_565, (string.Equals(Typeof(opt_556), "function") ? Call(opt_556, V.Undef, c_565) : opt_556));
Call(draw_557, V.Undef, E_567, c_565);
return Invoke(E_567, "out");
return default;
}, 1, "", true);
}, 2, "", true);
potT_52 = Fn((V _arrowThis580, int _argc568, V x_574, V z_575, V r_576, V h_577, V[] _rest569) => {
V lip_581 = default;
V col_578 = default;
V o_579 = default;
col_578 = (_argc568 > 4 ? _rest569[0] : V.Undef);
o_579 = (_argc568 > 5 ? _rest569[1] : V.Undef);
o_579 = (o_579 is var _t582 && Truthy(_t582) ? _t582 : NewObj(0).V);
lip_581 = (Get(o_579, "lip").IsNullish ? ((V)(4D)) : Get(o_579, "lip"));
return Arr(Call(cyl_13, V.Undef, x_574, ((V)(0D)), z_575, r_576, h_577, col_578, Object_assign(NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), (Get(o_579, "base") is var _t583 && Truthy(_t583) ? _t583 : ((V)(0.74)))), Arr(((V)((ToNum(h_577) - ToNum(lip_581)))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(h_577) - ToNum(lip_581)))), ((V)(0D)), ((V)(1.1))), Arr(h_577, ((V)(0D)), ((V)(1.1))))).V, (Truthy(Get(o_579, "mat")) ? NewObj(1).Put("mat", Get(o_579, "mat")).V : Call(pt_35, V.Undef)))), Call(cyl_13, V.Undef, x_574, ((V)((ToNum(h_577) - 1.2))), z_575, ((V)((ToNum(r_576) * 0.96))), ((V)(1.8)), (Get(o_579, "soil") is var _t584 && Truthy(_t584) ? _t584 : ((V)("#4a3020"))), NewObj(4).Put("n", ((V)(20D))).Put("noOut", ((V)(1D))).Put("shine", ((V)(0D))).Put("mat", ((V)("paint"))).V));
return default;
}, 6, "", true);
lift_53 = Fn((V _arrowThis593, int _argc585, V arr_591, V dy_592, V _a589, V _a590, V[] _rest586) => {
return Invoke(arr_591, "map", Fn((V _arrowThis601, int _argc594, V s0_600, V _a597, V _a598, V _a599, V[] _rest595) => {
Invoke(Get(s0_600, "pts"), "forEach", Fn((V _arrowThis609, int _argc602, V q_608, V _a605, V _a606, V _a607, V[] _rest603) => {
return OpSetK(q_608, ((V)(1D)), 0, dy_592);
}, 1, "", true));
return s0_600;
return default;
}, 1, "", true));
}, 2, "", true);
LEAF_54 = NewObj(5).Put("dk", ((V)("#2f6b3a"))).Put("md", ((V)("#3f8f3a"))).Put("lt", ((V)("#6fb04a"))).Put("ol", ((V)("#7d8f6a"))).Put("ev", ((V)("#2e6a2c"))).V;
snake_55 = Fn((V _arrowThis622, int _argc610, V E_616, V x_617, V y_618, V z_619, V[] _rest611) => {
V s_620 = default;
V R_621 = default;
s_620 = (_argc610 > 4 ? _rest611[0] : V.Undef);
R_621 = (_argc610 > 5 ? _rest611[1] : V.Undef);
Call(rep_22, V.Undef, ((V)(9D)), Fn((V _arrowThis630, int _argc623, V i_629, V _a626, V _a627, V _a628, V[] _rest624) => {
double a_631 = 0;
double rr_632 = 0;
a_631 = ((ToNum(i_629) * 2.4) + (ToNum(Call(R_621, V.Undef)) * 0.4));
rr_632 = (1.5 + (ToNum(Call(R_621, V.Undef)) * 3.5));
Invoke(E_616, "leaf", NewObj(13).Put("b", Arr(Add(x_617, ((V)((FdLibm.Cos(a_631) * rr_632)))), y_618, Add(z_619, ((V)((FdLibm.Sin(a_631) * rr_632)))))).Put("az", ((V)(a_631))).Put("el", ((V)((1.33 + (ToNum(Call(R_621, V.Undef)) * 0.17))))).Put("len", ((V)(((40D + (ToNum(Call(R_621, V.Undef)) * 22D)) * ToNum(s_620))))).Put("wid", ((V)(((6.5 + (ToNum(Call(R_621, V.Undef)) * 1.5)) * ToNum(s_620))))).Put("droop", ((V)(0.04))).Put("roll", ((V)(((ToNum(Call(R_621, V.Undef)) - 0.5) * 1.2)))).Put("sh", ((V)("sword"))).Put("col", ((V)((NumTruthy((ToNum(i_629) % 3D)) ? "#2f6b3a" : "#3a7a40")))).Put("col2", ((V)("#4a8a4a"))).Put("band", ((V)("#a9cf8a"))).Put("edge", ((V)("#d8d06a"))).Put("seg", ((V)(9D))).V);
return default;
}, 1, "", true));
return default;
}, 6, "", true);
pothos_56 = Fn((V _arrowThis647, int _argc633, V E_639, V x_640, V y_641, V z_642, V[] _rest634) => {
V s_643 = default;
V R_644 = default;
V wilt_645 = default;
V rim_646 = default;
s_643 = (_argc633 > 4 ? _rest634[0] : V.Undef);
R_644 = (_argc633 > 5 ? _rest634[1] : V.Undef);
wilt_645 = (_argc633 > 6 ? _rest634[2] : V.Undef);
rim_646 = (_argc633 > 7 ? _rest634[3] : V.Undef);
Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis655, int _argc648, V v_654, V _a651, V _a652, V _a653, V[] _rest649) => {
double a_656 = 0;
double cz_657 = 0;
double sz_658 = 0;
V @out_659 = default;
double drop_660 = 0;
V pts_661 = default;
a_656 = ((ToNum(v_654) * 1.05) + (ToNum(Call(R_644, V.Undef)) * 0.3));
cz_657 = FdLibm.Cos(a_656);
sz_658 = FdLibm.Sin(a_656);
@out_659 = Add(rim_646, ((V)(4D)));
drop_660 = (Truthy(wilt_645) ? (16D + (ToNum(Call(R_644, V.Undef)) * 10D)) : (10D + (ToNum(Call(R_644, V.Undef)) * 22D)));
pts_661 = Arr(Arr(Add(x_640, ((V)((cz_657 * 2D)))), y_641, Add(z_642, ((V)((sz_658 * 2D))))), Arr(Add(x_640, ((V)((cz_657 * (ToNum(rim_646) * 0.6))))), Add(y_641, ((V)(6D))), Add(z_642, ((V)((sz_658 * (ToNum(rim_646) * 0.6)))))), Arr(Add(x_640, ((V)((cz_657 * ToNum(@out_659))))), Add(y_641, ((V)(3D))), Add(z_642, ((V)((sz_658 * ToNum(@out_659)))))), Arr(Add(x_640, ((V)((cz_657 * ToNum(Add(@out_659, ((V)(3D)))))))), ((V)((ToNum(y_641) - (drop_660 * 0.5)))), Add(z_642, ((V)((sz_658 * ToNum(Add(@out_659, ((V)(3D))))))))), Arr(Add(x_640, ((V)((cz_657 * ToNum(Add(@out_659, ((V)(4D)))))))), ((V)((ToNum(y_641) - drop_660))), Add(z_642, ((V)((sz_658 * ToNum(Add(@out_659, ((V)(4D))))))))));
Invoke(E_639, "stem", pts_661, ((V)(0.9)), ((V)(0.6)), ((V)((Truthy(wilt_645) ? "#8a9a4a" : "#5a8a3a"))));
{
double t_662 = 0;
t_662 = 0.15;
while (true) {
if (!((t_662 < 1D))) break;
double i_664 = 0;
double f_665 = 0;
V P_666 = default;
V yel_667 = default;
i_664 = Min(3D, System.Math.Floor((t_662 * 4D)));
f_665 = ((t_662 * 4D) - i_664);
P_666 = Invoke(GetIdx(pts_661, i_664), "map", Fn((V _arrowThis676, int _argc668, V v0_674, V k_675, V _a672, V _a673, V[] _rest669) => {
return Add(v0_674, ((V)(((ToNum(GetK(GetIdx(pts_661, (i_664 + 1D)), k_675)) - ToNum(v0_674)) * f_665))));
}, 2, "", true));
yel_667 = (wilt_645 is var _t677 && !Truthy(_t677) ? _t677 : (LtN(Call(R_644, V.Undef), 0.45) ? V.True : V.False));
Invoke(E_639, "leaf", NewObj(13).Put("b", P_666).Put("az", ((V)((a_656 + ((LtN(Call(R_644, V.Undef), 0.5) ? 1D : (-1D)) * (0.7 + (ToNum(Call(R_644, V.Undef)) * 0.6))))))).Put("el", ((V)((0.25 - (t_662 * 0.6))))).Put("len", ((V)((((7D + (ToNum(Call(R_644, V.Undef)) * 3D)) * ToNum(s_643)) * (Truthy(wilt_645) ? 0.85 : 1D))))).Put("wid", ((V)(((6D + (ToNum(Call(R_644, V.Undef)) * 2D)) * ToNum(s_643))))).Put("droop", ((V)((Truthy(wilt_645) ? 1D : 0.55)))).Put("roll", ((V)(((ToNum(Call(R_644, V.Undef)) - 0.5) * 0.8)))).Put("sh", ((V)("heart"))).Put("col", ((V)((Truthy(yel_667) ? (LtN(Call(R_644, V.Undef), 0.5) ? "#d8c45a" : "#b89a4a") : "#3f8f3a")))).Put("band", (Truthy(yel_667) ? V.Null : ((V)("#d8d27a")))).Put("gloss", (!(Truthy(yel_667)) ? V.True : V.False)).Put("seg", ((V)(6D))).Put("edge", (Truthy(yel_667) ? ((V)("#8a6a2a")) : V.Null)).V);
t_662 = (t_662 + 0.2);
}
}
return default;
}, 1, "", true));
return default;
}, 8, "", true);
fiddle_57 = Fn((V _arrowThis690, int _argc678, V E_684, V x_685, V y_686, V z_687, V[] _rest679) => {
V T_691 = default;
V s_688 = default;
V R_689 = default;
s_688 = (_argc678 > 4 ? _rest679[0] : V.Undef);
R_689 = (_argc678 > 5 ? _rest679[1] : V.Undef);
T_691 = Arr(Arr(x_685, y_686, z_687), Arr(Add(x_685, ((V)(1D))), Add(y_686, ((V)((20D * ToNum(s_688))))), z_687), Arr(((V)((ToNum(x_685) - 1.5))), Add(y_686, ((V)((42D * ToNum(s_688))))), Add(z_687, ((V)(1D)))), Arr(Add(x_685, ((V)(1D))), Add(y_686, ((V)((64D * ToNum(s_688))))), z_687), Arr(x_685, Add(y_686, ((V)((80D * ToNum(s_688))))), z_687));
Invoke(E_684, "stem", T_691, ((V)(3D)), ((V)(1.6)), ((V)("#7a6a52")), NewObj(1).Put("bark", ((V)(1D))).V);
Call(rep_22, V.Undef, ((V)(17D)), Fn((V _arrowThis699, int _argc692, V i_698, V _a695, V _a696, V _a697, V[] _rest693) => {
double t_700 = 0;
double j_701 = 0;
double f_702 = 0;
V P_703 = default;
double a_704 = 0;
t_700 = (0.42 + ((0.58 * ToNum(i_698)) / 16D));
j_701 = Min(3D, System.Math.Floor((t_700 * 4D)));
f_702 = ((t_700 * 4D) - j_701);
P_703 = Invoke(GetIdx(T_691, j_701), "map", Fn((V _arrowThis713, int _argc705, V v0_711, V k_712, V _a709, V _a710, V[] _rest706) => {
return Add(v0_711, ((V)(((ToNum(GetK(GetIdx(T_691, (j_701 + 1D)), k_712)) - ToNum(v0_711)) * f_702))));
}, 2, "", true));
a_704 = (ToNum(i_698) * 2.39);
Invoke(E_684, "leaf", NewObj(12).Put("b", P_703).Put("az", ((V)(a_704))).Put("el", ((V)(((0.55 + (ToNum(Call(R_689, V.Undef)) * 0.4)) - ((1D - t_700) * 0.3))))).Put("len", ((V)(((15D + (ToNum(Call(R_689, V.Undef)) * 5D)) * ToNum(s_688))))).Put("wid", ((V)(((11D + (ToNum(Call(R_689, V.Undef)) * 3D)) * ToNum(s_688))))).Put("droop", ((V)(0.4))).Put("roll", ((V)(((ToNum(Call(R_689, V.Undef)) - 0.5) * 0.7)))).Put("sh", ((V)("fiddle"))).Put("col", ((V)((NumTruthy((ToNum(i_698) % 4D)) ? "#2e6a2c" : "#3a7a34")))).Put("vein", ((V)(1D))).Put("gloss", ((V)(1D))).Put("seg", ((V)(7D))).V);
return default;
}, 1, "", true));
return default;
}, 6, "", true);
bonsai_58 = Fn((V _arrowThis727, int _argc714, V E_720, V x_721, V y_722, V z_723, V[] _rest715) => {
V T_728 = default;
V s_724 = default;
V R_725 = default;
V pads_726 = default;
s_724 = (_argc714 > 4 ? _rest715[0] : V.Undef);
R_725 = (_argc714 > 5 ? _rest715[1] : V.Undef);
pads_726 = (_argc714 > 6 ? _rest715[2] : V.Undef);
T_728 = Arr(Arr(x_721, y_722, z_723), Arr(((V)((ToNum(x_721) - (3D * ToNum(s_724))))), Add(y_722, ((V)((6D * ToNum(s_724))))), z_723), Arr(((V)((ToNum(x_721) - (6D * ToNum(s_724))))), Add(y_722, ((V)((12D * ToNum(s_724))))), Add(z_723, ((V)(1D)))), Arr(((V)((ToNum(x_721) - (3D * ToNum(s_724))))), Add(y_722, ((V)((18D * ToNum(s_724))))), z_723), Arr(Add(x_721, ((V)((3D * ToNum(s_724))))), Add(y_722, ((V)((22D * ToNum(s_724))))), ((V)((ToNum(z_723) - 1D)))), Arr(Add(x_721, ((V)((7D * ToNum(s_724))))), Add(y_722, ((V)((25D * ToNum(s_724))))), z_723));
Invoke(E_720, "stem", T_728, ((V)((5.2 * ToNum(s_724)))), ((V)((2.2 * ToNum(s_724)))), ((V)("#6a5444")), NewObj(1).Put("bark", ((V)(1D))).V);
Invoke(Arr(Arr(((V)((-1D))), ((V)(0D))), Arr(((V)(1D)), ((V)(0D))), Arr(((V)(0.4)), ((V)(1D)))), "forEach", Fn((V _arrowThis740, int _argc729, V _a731, V _a732, V _a733, V _a734, V[] _rest730) => {
V dx_737 = default;
V dz_739 = default;
{ V _t735 = ListOf(_a731);
{ V _t736 = GetIdx(_t735, 0D);
dx_737 = _t736; }
{ V _t738 = GetIdx(_t735, 1D);
dz_739 = _t738; }
}
return Invoke(E_720, "stem", Arr(Arr(x_721, Add(y_722, ((V)(0.5))), z_723), Arr(Add(x_721, ((V)(((ToNum(dx_737) * 5D) * ToNum(s_724))))), y_722, Add(z_723, ((V)(((ToNum(dz_739) * 4D) * ToNum(s_724))))))), ((V)((2.2 * ToNum(s_724)))), ((V)((1D * ToNum(s_724)))), ((V)("#6a5444")));
}, 1, "", true));
Invoke((pads_726 is var _t762 && Truthy(_t762) ? _t762 : Arr(Arr(((V)((-15D))), ((V)(14D)), ((V)(2D)), ((V)(13D)), ((V)(5D)), ((V)(10D))), Arr(((V)(11D)), ((V)(19D)), ((V)((-2D))), ((V)(11.5)), ((V)(4.6)), ((V)(9D))), Arr(((V)(4D)), ((V)(29D)), ((V)(0D)), ((V)(13D)), ((V)(5.4)), ((V)(10D))), Arr(((V)((-6D))), ((V)(23D)), ((V)(3D)), ((V)(8D)), ((V)(3.6)), ((V)(7D))))), "forEach", Fn((V _arrowThis761, int _argc741, V _a743, V i_747, V _a745, V _a746, V[] _rest742) => {
V dx_750 = default;
V dy_752 = default;
V dz_754 = default;
V rx_756 = default;
V ry_758 = default;
V rz_760 = default;
{ V _t748 = ListOf(_a743);
{ V _t749 = GetIdx(_t748, 0D);
dx_750 = _t749; }
{ V _t751 = GetIdx(_t748, 1D);
dy_752 = _t751; }
{ V _t753 = GetIdx(_t748, 2D);
dz_754 = _t753; }
{ V _t755 = GetIdx(_t748, 3D);
rx_756 = _t755; }
{ V _t757 = GetIdx(_t748, 4D);
ry_758 = _t757; }
{ V _t759 = GetIdx(_t748, 5D);
rz_760 = _t759; }
}
Invoke(E_720, "stem", Arr(GetIdx(T_728, Min(5D, ToNum(Add(((V)(2D)), i_747)))), Arr(Add(x_721, ((V)(((ToNum(dx_750) * ToNum(s_724)) * 0.8)))), ((V)((ToNum(Add(y_722, ((V)((ToNum(dy_752) * ToNum(s_724)))))) - 1D))), Add(z_723, ((V)((ToNum(dz_754) * ToNum(s_724))))))), ((V)((1.6 * ToNum(s_724)))), ((V)((0.8 * ToNum(s_724)))), ((V)("#6a5444")));
Invoke(E_720, "clump", Arr(Add(x_721, ((V)((ToNum(dx_750) * ToNum(s_724))))), Add(y_722, ((V)((ToNum(dy_752) * ToNum(s_724))))), Add(z_723, ((V)((ToNum(dz_754) * ToNum(s_724)))))), ((V)((ToNum(rx_756) * ToNum(s_724)))), ((V)((ToNum(ry_758) * ToNum(s_724)))), ((V)((ToNum(rz_760) * ToNum(s_724)))), ((V)(Max(14D, Round(((46D * ToNum(s_724)) * (ToNum(rx_756) / 10D)))))), NewObj(6).Put("R", R_725).Put("cols", Arr(((V)("#3f6f2e")), ((V)("#4f8a36")), ((V)("#5f9a3e")), ((V)("#2f5a26")))).Put("len", ((V)((3.6 * ToNum(s_724))))).Put("wid", ((V)((2.4 * ToNum(s_724))))).Put("droop", ((V)(0.1))).Put("top", ((V)(0.55))).V);
return default;
}, 2, "", true));
return default;
}, 7, "", true);
olive_59 = Fn((V _arrowThis775, int _argc763, V E_769, V x_770, V y_771, V z_772, V[] _rest764) => {
V T1_776 = default;
V T2_777 = default;
V s_773 = default;
V R_774 = default;
s_773 = (_argc763 > 4 ? _rest764[0] : V.Undef);
R_774 = (_argc763 > 5 ? _rest764[1] : V.Undef);
T1_776 = Arr(Arr(x_770, y_771, z_772), Arr(Add(x_770, ((V)((2D * ToNum(s_773))))), Add(y_771, ((V)((16D * ToNum(s_773))))), z_772), Arr(((V)((ToNum(x_770) - (2D * ToNum(s_773))))), Add(y_771, ((V)((32D * ToNum(s_773))))), Add(z_772, ((V)(1D)))), Arr(Add(x_770, ((V)((1D * ToNum(s_773))))), Add(y_771, ((V)((46D * ToNum(s_773))))), z_772));
T2_777 = Arr(Arr(Add(x_770, ((V)(1D))), y_771, z_772), Arr(((V)((ToNum(x_770) - (3D * ToNum(s_773))))), Add(y_771, ((V)((14D * ToNum(s_773))))), ((V)((ToNum(z_772) - 1D)))), Arr(Add(x_770, ((V)((3D * ToNum(s_773))))), Add(y_771, ((V)((30D * ToNum(s_773))))), z_772), Arr(Add(x_770, ((V)((6D * ToNum(s_773))))), Add(y_771, ((V)((44D * ToNum(s_773))))), ((V)((ToNum(z_772) - 1D)))));
Invoke(E_769, "stem", T1_776, ((V)((3.2 * ToNum(s_773)))), ((V)((1.4 * ToNum(s_773)))), ((V)("#8a7a62")), NewObj(1).Put("bark", ((V)(1D))).V);
Invoke(E_769, "stem", T2_777, ((V)((2.6 * ToNum(s_773)))), ((V)((1.2 * ToNum(s_773)))), ((V)("#7a6a52")), NewObj(1).Put("bark", ((V)(1D))).V);
Invoke(Arr(Arr(((V)(0D)), ((V)(50D)), ((V)(0D)), ((V)(14D)), ((V)(9D)), ((V)(12D))), Arr(((V)((-10D))), ((V)(42D)), ((V)(3D)), ((V)(9D)), ((V)(6D)), ((V)(8D))), Arr(((V)(11D)), ((V)(45D)), ((V)((-2D))), ((V)(10D)), ((V)(7D)), ((V)(8D))), Arr(((V)(3D)), ((V)(58D)), ((V)(1D)), ((V)(9D)), ((V)(6D)), ((V)(8D)))), "forEach", Fn((V _arrowThis797, int _argc778, V _a780, V _a781, V _a782, V _a783, V[] _rest779) => {
V dx_786 = default;
V dy_788 = default;
V dz_790 = default;
V rx_792 = default;
V ry_794 = default;
V rz_796 = default;
{ V _t784 = ListOf(_a780);
{ V _t785 = GetIdx(_t784, 0D);
dx_786 = _t785; }
{ V _t787 = GetIdx(_t784, 1D);
dy_788 = _t787; }
{ V _t789 = GetIdx(_t784, 2D);
dz_790 = _t789; }
{ V _t791 = GetIdx(_t784, 3D);
rx_792 = _t791; }
{ V _t793 = GetIdx(_t784, 4D);
ry_794 = _t793; }
{ V _t795 = GetIdx(_t784, 5D);
rz_796 = _t795; }
}
return Invoke(E_769, "clump", Arr(Add(x_770, ((V)((ToNum(dx_786) * ToNum(s_773))))), Add(y_771, ((V)((ToNum(dy_788) * ToNum(s_773))))), Add(z_772, ((V)((ToNum(dz_790) * ToNum(s_773)))))), ((V)((ToNum(rx_792) * ToNum(s_773)))), ((V)((ToNum(ry_794) * ToNum(s_773)))), ((V)((ToNum(rz_796) * ToNum(s_773)))), ((V)(Round((30D * ToNum(s_773))))), NewObj(8).Put("R", R_774).Put("cols", Arr(((V)("#7d8f6a")), ((V)("#8a9a72")), ((V)("#6f8060")))).Put("col2", ((V)("#c8cdb8"))).Put("len", ((V)((6D * ToNum(s_773))))).Put("wid", ((V)((1.6 * ToNum(s_773))))).Put("sh", ((V)("lance"))).Put("droop", ((V)(0.4))).Put("top", ((V)(0.9))).V);
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(7D)), Fn((V _arrowThis805, int _argc798, V i_804, V _a801, V _a802, V _a803, V[] _rest799) => {
return Invoke(E_769, "blob", Arr(Add(x_770, ((V)((((ToNum(Call(R_774, V.Undef)) - 0.5) * 22D) * ToNum(s_773))))), Add(y_771, ((V)(((42D + (ToNum(Call(R_774, V.Undef)) * 14D)) * ToNum(s_773))))), Add(z_772, ((V)((((ToNum(Call(R_774, V.Undef)) - 0.2) * 10D) * ToNum(s_773)))))), ((V)((0.9 * ToNum(s_773)))), ((V)((NumTruthy((ToNum(i_804) % 2D)) ? "#3a2a3a" : "#6a7a3a"))), NewObj(2).Put("shine", ((V)(1D))).Put("db", ((V)(6D))).V);
}, 1, "", true));
return default;
}, 6, "", true);
fern_60 = Fn((V _arrowThis819, int _argc806, V E_812, V x_813, V y_814, V z_815, V[] _rest807) => {
V s_816 = default;
V R_817 = default;
V faux_818 = default;
s_816 = (_argc806 > 4 ? _rest807[0] : V.Undef);
R_817 = (_argc806 > 5 ? _rest807[1] : V.Undef);
faux_818 = (_argc806 > 6 ? _rest807[2] : V.Undef);
Call(rep_22, V.Undef, ((V)(14D)), Fn((V _arrowThis827, int _argc820, V i_826, V _a823, V _a824, V _a825, V[] _rest821) => {
double a_828 = 0;
double cz_829 = 0;
double sz_830 = 0;
double el0_831 = 0;
double len_832 = 0;
double n_833 = 0;
V P_834 = default;
V pts_835 = default;
a_828 = ((ToNum(i_826) * 2.4) + (ToNum(Call(R_817, V.Undef)) * 0.3));
cz_829 = FdLibm.Cos(a_828);
sz_830 = FdLibm.Sin(a_828);
el0_831 = (0.6 + (ToNum(Call(R_817, V.Undef)) * 0.7));
len_832 = ((26D + (ToNum(Call(R_817, V.Undef)) * 12D)) * ToNum(s_816));
n_833 = 9D;
P_834 = Arr(Add(x_813, ((V)((cz_829 * 1.5)))), y_814, Add(z_815, ((V)((sz_830 * 1.5)))));
pts_835 = Arr(P_834);
{
double j_836 = 0;
j_836 = 0D;
while (true) {
if (!((j_836 < n_833))) break;
double e_838 = 0;
e_838 = (el0_831 - (1.8 * (j_836 / n_833)));
P_834 = Call(addv_46, V.Undef, P_834, Arr(((V)((FdLibm.Cos(e_838) * cz_829))), ((V)(FdLibm.Sin(e_838))), ((V)((FdLibm.Cos(e_838) * sz_830)))), ((V)((len_832 / n_833))));
Invoke(pts_835, "push", P_834);
j_836++;
}
}
Invoke(E_812, "stem", pts_835, ((V)(0.7)), ((V)(0.3)), ((V)((Truthy(faux_818) ? "#4aa83a" : "#4a7a2a"))));
{
V j_839 = default;
j_839 = ((V)(1D));
while (true) {
V j_839_it = j_839;
if (!(LtN(j_839_it, n_833))) break;
double t_841 = 0;
double e_842 = 0;
t_841 = (ToNum(j_839_it) / n_833);
e_842 = (el0_831 - (1.8 * t_841));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis850, int _argc843, V sg_849, V _a846, V _a847, V _a848, V[] _rest844) => {
return Invoke(E_812, "leaf", NewObj(12).Put("b", GetK(pts_835, j_839_it)).Put("az", ((V)((a_828 + (ToNum(sg_849) * 1.25))))).Put("el", ((V)((e_842 - 0.25)))).Put("len", ((V)(((4.8 * ToNum(s_816)) * (1D - (t_841 * 0.55)))))).Put("wid", ((V)((1.8 * ToNum(s_816))))).Put("droop", ((V)(0.25))).Put("roll", ((V)((0.3 * ToNum(sg_849))))).Put("sh", ((V)("lance"))).Put("col", ((V)((Truthy(faux_818) ? "#56b84a" : (NumTruthy((ToNum(j_839_it) % 2D)) ? "#4c9a3a" : "#5aa844"))))).Put("simple", ((V)(1D))).Put("seg", ((V)(3D))).Put("lk", ((V)((Truthy(faux_818) ? 1.15 : 1D)))).V);
}, 1, "", true));
j_839 = j_839_it;
PostInc(ref j_839, 1D);
}
}
return default;
}, 1, "", true));
return default;
}, 7, "", true);
bamboo_61 = Fn((V _arrowThis863, int _argc851, V E_857, V x_858, V y_859, V z_860, V[] _rest852) => {
V s_861 = default;
V R_862 = default;
s_861 = (_argc851 > 4 ? _rest852[0] : V.Undef);
R_862 = (_argc851 > 5 ? _rest852[1] : V.Undef);
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis871, int _argc864, V i_870, V _a867, V _a868, V _a869, V[] _rest865) => {
double a_872 = 0;
double rr_873 = 0;
double h_874 = 0;
V curly_875 = default;
V pts_876 = default;
V top_877 = default;
a_872 = (ToNum(i_870) * 1.3);
rr_873 = 2.2;
h_874 = (((34D + (ToNum(i_870) * 7D)) + (ToNum(Call(R_862, V.Undef)) * 6D)) * ToNum(s_861));
curly_875 = (SEqN(i_870, 2D) ? V.True : V.False);
pts_876 = Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis885, int _argc878, V j_884, V _a881, V _a882, V _a883, V[] _rest879) => {
double t_886 = 0;
t_886 = (ToNum(j_884) / 5D);
return Arr(Add(Add(x_858, ((V)((FdLibm.Cos(a_872) * rr_873)))), ((V)((Truthy(curly_875) ? (FdLibm.Sin((t_886 * 6D)) * 3D) : 0D)))), Add(y_859, ((V)((h_874 * t_886)))), Add(Add(z_860, ((V)((FdLibm.Sin(a_872) * rr_873)))), ((V)((Truthy(curly_875) ? (FdLibm.Cos((t_886 * 6D)) * 3D) : 0D)))));
return default;
}, 1, "", true));
Invoke(E_857, "stem", pts_876, ((V)(1.7)), ((V)(1.5)), ((V)("#7fb84a")), NewObj(1).Put("node", ((V)(1D))).V);
top_877 = GetIdx(pts_876, 5D);
Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis894, int _argc887, V j_893, V _a890, V _a891, V _a892, V[] _rest888) => {
return Invoke(E_857, "leaf", NewObj(10).Put("b", top_877).Put("az", ((V)((a_872 + (ToNum(j_893) * 2.1))))).Put("el", ((V)(0.5))).Put("len", ((V)((9D * ToNum(s_861))))).Put("wid", ((V)((2.6 * ToNum(s_861))))).Put("droop", ((V)(0.7))).Put("sh", ((V)("lance"))).Put("col", ((V)("#4f9a3a"))).Put("seg", ((V)(5D))).Put("gloss", ((V)(1D))).V);
}, 1, "", true));
return default;
}, 1, "", true));
return default;
}, 6, "", true);
euca_62 = Fn((V _arrowThis907, int _argc895, V E_901, V x_902, V y_903, V z_904, V[] _rest896) => {
V s_905 = default;
V R_906 = default;
s_905 = (_argc895 > 4 ? _rest896[0] : V.Undef);
R_906 = (_argc895 > 5 ? _rest896[1] : V.Undef);
Call(rep_22, V.Undef, ((V)(7D)), Fn((V _arrowThis915, int _argc908, V i_914, V _a911, V _a912, V _a913, V[] _rest909) => {
double a_916 = 0;
double len_917 = 0;
V pts_918 = default;
a_916 = (((-0.9) + (ToNum(i_914) * 0.3)) + ((ToNum(Call(R_906, V.Undef)) - 0.5) * 0.2));
len_917 = ((30D + (ToNum(Call(R_906, V.Undef)) * 10D)) * ToNum(s_905));
pts_918 = Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis926, int _argc919, V j_925, V _a922, V _a923, V _a924, V[] _rest920) => {
double t_927 = 0;
t_927 = (ToNum(j_925) / 5D);
return Arr(Add(x_902, ((V)((((FdLibm.Sin(a_916) * len_917) * t_927) * 0.5)))), ((V)((ToNum(y_903) - (len_917 * t_927)))), Add(Add(z_904, ((V)(4D))), ((V)(((FdLibm.Cos(a_916) * 3D) * t_927)))));
return default;
}, 1, "", true));
Invoke(E_901, "stem", pts_918, ((V)(0.7)), ((V)(0.4)), ((V)("#7a5a4a")));
{
V j_928 = default;
j_928 = ((V)(1D));
while (true) {
V j_928_it = j_928;
if (!(LtN(j_928_it, 6D))) break;
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis937, int _argc930, V sg_936, V _a933, V _a934, V _a935, V[] _rest931) => {
return Invoke(E_901, "leaf", NewObj(11).Put("b", GetK(pts_918, j_928_it)).Put("az", ((V)(((PI_38 / 2D) + (ToNum(sg_936) * 1.4))))).Put("el", ((V)((-0.6)))).Put("len", ((V)((3.8 * ToNum(s_905))))).Put("wid", ((V)((3.6 * ToNum(s_905))))).Put("droop", ((V)(0.4))).Put("sh", ((V)("coin"))).Put("col", ((V)("#7ea896"))).Put("col2", ((V)("#a9c4b8"))).Put("seg", ((V)(4D))).Put("simple", ((V)(1D))).V);
}, 1, "", true));
j_928 = j_928_it;
PostInc(ref j_928, 1D);
}
}
return default;
}, 1, "", true));
return default;
}, 6, "", true);
lettuce_63 = Fn((V _arrowThis951, int _argc938, V E_944, V x_945, V y_946, V z_947, V[] _rest939) => {
V s_948 = default;
V R_949 = default;
V col_950 = default;
s_948 = (_argc938 > 4 ? _rest939[0] : V.Undef);
R_949 = (_argc938 > 5 ? _rest939[1] : V.Undef);
col_950 = (_argc938 > 6 ? _rest939[2] : V.Undef);
Call(rep_22, V.Undef, ((V)(12D)), Fn((V _arrowThis959, int _argc952, V i_958, V _a955, V _a956, V _a957, V[] _rest953) => {
double a_960 = 0;
double rr_961 = 0;
a_960 = (ToNum(i_958) * 2.4);
rr_961 = (LtN(i_958, 5D) ? 0.6 : 2D);
Invoke(E_944, "leaf", NewObj(11).Put("b", Arr(Add(x_945, ((V)((FdLibm.Cos(a_960) * rr_961)))), y_946, Add(z_947, ((V)((FdLibm.Sin(a_960) * rr_961)))))).Put("az", ((V)(a_960))).Put("el", ((V)((LtN(i_958, 5D) ? 1.1 : 0.55)))).Put("len", ((V)(((LtN(i_958, 5D) ? 6D : 8D) * ToNum(s_948))))).Put("wid", ((V)(((LtN(i_958, 5D) ? 6D : 8D) * ToNum(s_948))))).Put("droop", ((V)((LtN(i_958, 5D) ? 0.2 : 0.6)))).Put("curl", ((V)(0.6))).Put("sh", ((V)("oval"))).Put("col", (col_950 is var _t962 && Truthy(_t962) ? _t962 : ((V)((LtN(i_958, 5D) ? "#9fd65a" : "#6fb04a"))))).Put("vein", ((V)(1D))).Put("seg", ((V)(5D))).V);
return default;
}, 1, "", true));
return default;
}, 7, "", true);
carrot_64 = Fn((V _arrowThis975, int _argc963, V E_969, V x_970, V y_971, V z_972, V[] _rest964) => {
V s_973 = default;
V R_974 = default;
s_973 = (_argc963 > 4 ? _rest964[0] : V.Undef);
R_974 = (_argc963 > 5 ? _rest964[1] : V.Undef);
Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis983, int _argc976, V i_982, V _a979, V _a980, V _a981, V[] _rest977) => {
double a_984 = 0;
V pts_985 = default;
a_984 = (ToNum(i_982) * 1.05);
pts_985 = Arr(Arr(x_970, y_971, z_972), Arr(Add(x_970, ((V)((FdLibm.Cos(a_984) * 3D)))), Add(y_971, ((V)((7D * ToNum(s_973))))), Add(z_972, ((V)((FdLibm.Sin(a_984) * 3D))))), Arr(Add(x_970, ((V)((FdLibm.Cos(a_984) * 6D)))), Add(y_971, ((V)((12D * ToNum(s_973))))), Add(z_972, ((V)((FdLibm.Sin(a_984) * 6D))))));
Invoke(E_969, "stem", pts_985, ((V)(0.5)), ((V)(0.3)), ((V)("#5a9a3a")));
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis993, int _argc986, V j_992, V _a989, V _a990, V _a991, V[] _rest987) => {
return Invoke(E_969, "leaf", NewObj(10).Put("b", GetIdx(pts_985, (1D + (ToNum(j_992) % 2D)))).Put("az", ((V)((a_984 + ((ToNum(j_992) - 2D) * 0.6))))).Put("el", ((V)(0.6))).Put("len", ((V)((3.4 * ToNum(s_973))))).Put("wid", ((V)((1.6 * ToNum(s_973))))).Put("droop", ((V)(0.3))).Put("sh", ((V)("lance"))).Put("col", ((V)("#5fa84a"))).Put("simple", ((V)(1D))).Put("seg", ((V)(3D))).V);
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(E_969, "blob", Arr(x_970, ((V)((ToNum(y_971) - 1.6))), Add(z_972, ((V)(0.5)))), ((V)((1.6 * ToNum(s_973)))), ((V)("#f2932c")), NewObj(2).Put("sy", ((V)(0.8))).Put("db", ((V)(4D))).V);
return default;
}, 6, "", true);
rose_65 = Fn((V _arrowThis1004, int _argc994, V E_1000, V P_1001, V s_1002, V col_1003, V[] _rest995) => {
Invoke(E_1000, "flower", P_1001, ((V)((2.4 * ToNum(s_1002)))), col_1003, NewObj(3).Put("n", ((V)(6D))).Put("pw", ((V)(0.5))).Put("ctr", Call(shade_18, V.Undef, col_1003, ((V)(0.7)))).V);
Invoke(E_1000, "flower", Arr(GetIdx(P_1001, 0D), Add(GetIdx(P_1001, 1D), ((V)(0.3))), Add(GetIdx(P_1001, 2D), ((V)(0.2)))), ((V)((1.4 * ToNum(s_1002)))), Call(shade_18, V.Undef, col_1003, ((V)(0.85))), NewObj(4).Put("n", ((V)(5D))).Put("pw", ((V)(0.5))).Put("ctr", Call(shade_18, V.Undef, col_1003, ((V)(0.55)))).Put("db", ((V)(0.5))).V);
return default;
}, 4, "", true);
orchid_66 = Fn((V _arrowThis1017, int _argc1005, V E_1011, V x_1012, V y_1013, V z_1014, V[] _rest1006) => {
V s_1015 = default;
V R_1016 = default;
s_1015 = (_argc1005 > 4 ? _rest1006[0] : V.Undef);
R_1016 = (_argc1005 > 5 ? _rest1006[1] : V.Undef);
Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis1025, int _argc1018, V i_1024, V _a1021, V _a1022, V _a1023, V[] _rest1019) => {
return Invoke(E_1011, "leaf", NewObj(10).Put("b", Arr(x_1012, y_1013, z_1014)).Put("az", ((V)(((ToNum(i_1024) * 1.6) + 0.3)))).Put("el", ((V)(0.3))).Put("len", ((V)((13D * ToNum(s_1015))))).Put("wid", ((V)((5D * ToNum(s_1015))))).Put("droop", ((V)(0.5))).Put("sh", ((V)("oval"))).Put("col", ((V)("#3f7a34"))).Put("gloss", ((V)(1D))).Put("seg", ((V)(6D))).V);
}, 1, "", true));
Invoke(Arr(Arr(((V)((-1D))), ((V)("#f6f0f8"))), Arr(((V)(1D)), ((V)("#e06ab8")))), "forEach", Fn((V _arrowThis1037, int _argc1026, V _a1028, V _a1029, V _a1030, V _a1031, V[] _rest1027) => {
V pts_1038 = default;
V sg_1034 = default;
V col_1036 = default;
{ V _t1032 = ListOf(_a1028);
{ V _t1033 = GetIdx(_t1032, 0D);
sg_1034 = _t1033; }
{ V _t1035 = GetIdx(_t1032, 1D);
col_1036 = _t1035; }
}
pts_1038 = Call(rep_22, V.Undef, ((V)(7D)), Fn((V _arrowThis1046, int _argc1039, V j_1045, V _a1042, V _a1043, V _a1044, V[] _rest1040) => {
double t_1047 = 0;
t_1047 = (ToNum(j_1045) / 6D);
return Arr(Add(x_1012, ((V)(((ToNum(sg_1034) * (t_1047 * 16D)) * ToNum(s_1015))))), Add(y_1013, ((V)((((t_1047 * 30D) - ((t_1047 * t_1047) * 10D)) * ToNum(s_1015))))), Add(z_1014, ((V)(2D))));
return default;
}, 1, "", true));
Invoke(E_1011, "stem", pts_1038, ((V)(0.6)), ((V)(0.4)), ((V)("#5a7a3a")));
{
double j_1048 = 0;
j_1048 = 3D;
while (true) {
if (!((j_1048 < 7D))) break;
V P_1050 = default;
P_1050 = GetIdx(pts_1038, j_1048);
Invoke(E_1011, "flower", Arr(Add(GetIdx(P_1050, 0D), ((V)((ToNum(sg_1034) * 1D)))), ((V)((ToNum(GetIdx(P_1050, 1D)) - 1.8))), Add(GetIdx(P_1050, 2D), ((V)(1D)))), ((V)((3.2 * ToNum(s_1015)))), col_1036, NewObj(5).Put("n", ((V)(5D))).Put("pw", ((V)(0.62))).Put("ctr", ((V)("#f2c94c"))).Put("sq", ((V)(0.95))).Put("rot", ((V)((ToNum(sg_1034) * 10D)))).V);
j_1048++;
}
}
return default;
}, 1, "", true));
return default;
}, 6, "", true);
PT_67 = Fn((V _arrowThis1058, int _argc1051, V D_1057, V _a1054, V _a1055, V _a1056, V[] _rest1052) => {
return Object_assign(NewObj(2).Put("w", ((V)(40D))).Put("d", ((V)(40D))).V, D_1057);
}, 1, "", true);
S0_68 = Fn((V _arrowThis1068, int _argc1059, V x_1065, V y_1066, V z_1067, V _a1064, V[] _rest1060) => {
return Call(dep_44, V.Undef, x_1065, y_1066, z_1067);
}, 3, "", true);
Set(N_36, "flora", Fn((V _arrowThis1076, int _argc1069, V S_1075, V _a1072, V _a1073, V _a1074, V[] _rest1070) => {
V v_1077 = default;
V R_1078 = default;
V recipes_1079 = default;
v_1077 = (Get(S_1075, "pl") is var _t1080 && Truthy(_t1080) ? _t1080 : ((V)("snake")));
R_1078 = Fn((V _arrowThis1087, int _argc1081, V _a1083, V _a1084, V _a1085, V _a1086, V[] _rest1082) => {
return Call(rng_23, V.Undef, ((V)(JsStrBuf.Begin().S("flora").V(v_1077).V((Get(S_1075, "nm") is var _t1088 && Truthy(_t1088) ? _t1088 : ((V)("")))).End())));
}, 0, "", true);
recipes_1079 = NewObj(20).Put("snake", Fn((V _arrowThis1095, int _argc1089, V _a1091, V _a1092, V _a1093, V _a1094, V[] _rest1090) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis1103, int _argc1096, V P_1102, V _a1099, V _a1100, V _a1101, V[] _rest1097) => {
return Call(potT_52, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(22D)), ((V)("#c8693f")), NewObj(1).Put("base", ((V)(0.76))).V);
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1111, int _argc1104, V c_1110, V _a1107, V _a1108, V _a1109, V[] _rest1105) => {
return NewObj(3).Put("split", Call(S0_68, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(22D)), ((V)(0D)))).Put("sw", ((V)(0.8))).V;
}, 1, "", true), Fn((V _arrowThis1119, int _argc1112, V E_1118, V _a1115, V _a1116, V _a1117, V[] _rest1113) => {
return Call(snake_55, V.Undef, E_1118, ((V)(0D)), ((V)(23.2)), ((V)(0D)), ((V)(1D)), Call(R_1078, V.Undef));
}, 1, "", true))).V);
}, 0, "snake", true)).Put("pothos", Fn((V _arrowThis1126, int _argc1120, V _a1122, V _a1123, V _a1124, V _a1125, V[] _rest1121) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis1134, int _argc1127, V P_1133, V _a1130, V _a1131, V _a1132, V[] _rest1128) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(15D)), ((V)("#f4f2ec")), NewObj(4).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(15D)), ((V)(0D)), ((V)(1D))))).Put("mat", ((V)("cer"))).Put("op", ((V)(0.96))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(10.2)), ((V)(5D)), ((V)("#6ac8ff")), NewObj(3).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.91))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.95))))).Put("noOut", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(9.6)), ((V)(1.6)), ((V)("#4a3020")), NewObj(2).Put("n", ((V)(18D))).Put("noOut", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)(7.6)), ((V)(9.6)), ((V)(6D)), ((V)(1.6)), ((V)(0.4)), ((V)("#ffffff")), NewObj(2).Put("r", ((V)(0.4))).Put("noOut", ((V)(1D))).V));
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1142, int _argc1135, V c_1141, V _a1138, V _a1139, V _a1140, V[] _rest1136) => {
return NewObj(3).Put("split", Call(S0_68, V.Undef, ((V)(0D)), ((V)(15D)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(15D)), ((V)(0D)))).Put("sw", ((V)(1D))).V;
}, 1, "", true), Fn((V _arrowThis1150, int _argc1143, V E_1149, V _a1146, V _a1147, V _a1148, V[] _rest1144) => {
return Call(pothos_56, V.Undef, E_1149, ((V)(0D)), ((V)(15.6)), ((V)(0D)), ((V)(1D)), Call(R_1078, V.Undef), ((V)(1D)), ((V)(10D)));
}, 1, "", true))).V);
}, 0, "pothos", true)).Put("fiddle", Fn((V _arrowThis1157, int _argc1151, V _a1153, V _a1154, V _a1155, V _a1156, V[] _rest1152) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(48D))).Put("d", ((V)(48D))).Put("build", Fn((V _arrowThis1165, int _argc1158, V P_1164, V _a1161, V _a1162, V _a1163, V[] _rest1159) => {
V o_1166 = default;
o_1166 = Arr();
Invoke(Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(1D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(0D)))), "forEach", Fn((V _arrowThis1178, int _argc1167, V _a1169, V _a1170, V _a1171, V _a1172, V[] _rest1168) => {
double x0_1179 = 0;
double z0_1180 = 0;
double x1_1181 = 0;
double z1_1182 = 0;
V a_1175 = default;
V b_1177 = default;
{ V _t1173 = ListOf(_a1169);
{ V _t1174 = GetIdx(_t1173, 0D);
a_1175 = _t1174; }
{ V _t1176 = GetIdx(_t1173, 1D);
b_1177 = _t1176; }
}
x0_1179 = (ToNum(a_1175) * 12D);
z0_1180 = (ToNum(b_1177) * 12D);
x1_1181 = (ToNum(a_1175) * 7D);
z1_1182 = (ToNum(b_1177) * 7D);
Invoke(o_1166, "push", (Truthy(a_1175) ? Invoke(K_10, "prismZ", ((V)((z0_1180 - 1D))), ((V)((z0_1180 + 1D))), Arr(Arr(((V)((x0_1179 - 1.2))), ((V)(0D))), Arr(((V)((x0_1179 + 1.2))), ((V)(0D))), Arr(((V)((x1_1181 + 1.2))), ((V)(14D))), Arr(((V)((x1_1181 - 1.2))), ((V)(14D)))), ((V)("#a86b36")), Call(wd_33, V.Undef)) : Invoke(K_10, "prism", ((V)((x0_1179 - 1D))), ((V)((x0_1179 + 1D))), Arr(Arr(((V)((z0_1180 - 1.2))), ((V)(0D))), Arr(((V)((z0_1180 + 1.2))), ((V)(0D))), Arr(((V)((z1_1182 + 1.2))), ((V)(14D))), Arr(((V)((z1_1182 - 1.2))), ((V)(14D)))), ((V)("#a86b36")), Call(wd_33, V.Undef))));
return default;
}, 1, "", true));
return Invoke(o_1166, "concat", Call(lift_53, V.Undef, Call(potT_52, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(13D)), ((V)(22D)), ((V)("#ece8e0")), NewObj(3).Put("mat", ((V)("cer"))).Put("base", ((V)(0.82))).Put("lip", ((V)(2D))).V), ((V)(13D))));
return default;
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1190, int _argc1183, V c_1189, V _a1186, V _a1187, V _a1188, V[] _rest1184) => {
return NewObj(3).Put("split", Call(S0_68, V.Undef, ((V)(0D)), ((V)(35D)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(35D)), ((V)(0D)))).Put("sw", ((V)(0.9))).V;
}, 1, "", true), Fn((V _arrowThis1198, int _argc1191, V E_1197, V _a1194, V _a1195, V _a1196, V[] _rest1192) => {
return Call(fiddle_57, V.Undef, E_1197, ((V)(0D)), ((V)(35.6)), ((V)(0D)), ((V)(1D)), Call(R_1078, V.Undef));
}, 1, "", true))).V);
}, 0, "fiddle", true)).Put("bonsaiOlive", Fn((V _arrowThis1205, int _argc1199, V _a1201, V _a1202, V _a1203, V _a1204, V[] _rest1200) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(96D))).Put("d", ((V)(50D))).Put("build", Fn((V _arrowThis1213, int _argc1206, V P_1212, V _a1209, V _a1210, V _a1211, V[] _rest1207) => {
return new ArrBuilder().Add(Call(box_12, V.Undef, ((V)((-20D))), ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)(2D)), ((V)(26D)), ((V)("#2c3a4a")), Call(cer_34, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).Spread(Invoke(Arr(Arr(((V)((-38D))), ((V)((-10D)))), Arr(((V)((-2D))), ((V)((-10D)))), Arr(((V)((-38D))), ((V)(10D))), Arr(((V)((-2D))), ((V)(10D)))), "map", Fn((V _arrowThis1225, int _argc1214, V _a1216, V _a1217, V _a1218, V _a1219, V[] _rest1215) => {
V x_1222 = default;
V z_1224 = default;
{ V _t1220 = ListOf(_a1216);
{ V _t1221 = GetIdx(_t1220, 0D);
x_1222 = _t1221; }
{ V _t1223 = GetIdx(_t1220, 1D);
z_1224 = _t1223; }
}
return Call(box_12, V.Undef, x_1222, ((V)((-0.01))), z_1224, ((V)(4D)), ((V)(0.01)), ((V)(4D)), ((V)("#2c3a4a")), Call(cer_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V));
}, 1, "", true))).Add(Call(box_12, V.Undef, ((V)((-20D))), ((V)(2D)), ((V)(0D)), ((V)(46D)), ((V)(8D)), ((V)(28D)), ((V)("#3f6a8a")), Call(cer_34, V.Undef, NewObj(1).Put("r", ((V)(2.5))).V))).Add(Call(box_12, V.Undef, ((V)((-20D))), ((V)(8.4)), ((V)(0D)), ((V)(43D)), ((V)(1.6)), ((V)(25D)), ((V)("#4a3a28")), NewObj(2).Put("r", ((V)(2D))).Put("noOut", ((V)(1D))).V)).Spread(Call(potT_52, V.Undef, ((V)(28D)), ((V)(2D)), ((V)(13D)), ((V)(24D)), ((V)("#d8d0c0")), NewObj(3).Put("mat", ((V)("cer"))).Put("base", ((V)(0.82))).Put("lip", ((V)(2.6))).V)).V;
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1233, int _argc1226, V c_1232, V _a1229, V _a1230, V _a1231, V[] _rest1227) => {
return NewObj(3).Put("split", Call(S0_68, V.Undef, ((V)(4D)), ((V)(20D)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(10D)), ((V)(0D)))).Put("sw", ((V)(0.5))).V;
}, 1, "", true), Fn((V _arrowThis1241, int _argc1234, V E_1240, V _a1237, V _a1238, V _a1239, V[] _rest1235) => {
Call(bonsai_58, V.Undef, E_1240, ((V)((-20D))), ((V)(10D)), ((V)(0D)), ((V)(1D)), Call(R_1078, V.Undef));
Call(olive_59, V.Undef, E_1240, ((V)(28D)), ((V)(24.6)), ((V)(2D)), ((V)(1D)), Call(R_1078, V.Undef));
return default;
}, 1, "", true))).V);
}, 0, "bonsaiOlive", true)).Put("terrarium", Fn((V _arrowThis1248, int _argc1242, V _a1244, V _a1245, V _a1246, V _a1247, V[] _rest1243) => {
V isl_1249 = default;
isl_1249 = Fn((V _arrowThis1259, int _argc1250, V x_1256, V y_1257, V z_1258, V _a1255, V[] _rest1251) => {
return Arr(Call(ball_14, V.Undef, x_1256, y_1257, z_1258, ((V)(16D)), ((V)("#7a6a5a")), NewObj(3).Put("sy", ((V)(0.55))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).V), Call(ball_14, V.Undef, ((V)((ToNum(x_1256) - 4D))), ((V)((ToNum(y_1257) - 5D))), Add(z_1258, ((V)(2D))), ((V)(9D)), ((V)("#6a5a4a")), NewObj(3).Put("sy", ((V)(0.9))).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V), Call(ball_14, V.Undef, Add(x_1256, ((V)(5D))), ((V)((ToNum(y_1257) - 9D))), ((V)((ToNum(z_1258) - 1D))), ((V)(6D)), ((V)("#5a4a3a")), NewObj(2).Put("k", ((V)(5D))).Put("n", ((V)(10D))).V), Call(ball_14, V.Undef, x_1256, Add(y_1257, ((V)(14.4))), z_1258, ((V)(15D)), ((V)("#4f8a36")), NewObj(3).Put("sy", ((V)(0.14))).Put("k", ((V)(3D))).Put("n", ((V)(16D))).V));
}, 3, "", true);
return NewObj(5).Put("w", ((V)(60D))).Put("d", ((V)(50D))).Put("build", Fn((V _arrowThis1267, int _argc1260, V P_1266, V _a1263, V _a1264, V _a1265, V[] _rest1261) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(3D)), ((V)("#2c2d31")), Call(mt_32, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(10D)), ((V)(0.8)), ((V)("#6ac8ff")), Call(em_37, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
}, 1, "build", true)).Put("layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1275, int _argc1268, V P_1274, V _a1271, V _a1272, V _a1273, V[] _rest1269) => {
return Call(isl_1249, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1284, int _argc1276, V p_1282, V s_1283, V _a1280, V _a1281, V[] _rest1277) => {
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_30, V.Undef, ((V)("translate")), ((V)("0 0;0 -4;0 0")), ((V)(4D)))).V(s_1283).S("</g>").End()));
}, 2, "wrap", true)).V)).Put("fx", Fn((V _arrowThis1292, int _argc1285, V c_1291, V _a1288, V _a1289, V _a1290, V[] _rest1286) => {
V E_1293 = default;
V k_1294 = default;
V o_1295 = default;
V w0_1296 = default;
V w1_1297 = default;
V wf_1298 = default;
E_1293 = New(Flora_49, c_1291, NewObj(1).Put("split", ((V)((-1000000000D)))).V);
Call(bonsai_58, V.Undef, E_1293, ((V)(0D)), ((V)(42D)), ((V)(0D)), ((V)(0.75)), Call(R_1078, V.Undef));
k_1294 = Get(c_1291, "k");
o_1295 = Invoke(E_1293, "out");
w0_1296 = Invoke(c_1291, "p", ((V)(12D)), ((V)(40D)), ((V)(6D)));
w1_1297 = Invoke(c_1291, "p", ((V)(14D)), ((V)(4D)), ((V)(6D)));
wf_1298 = ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(P2_25, V.Undef, w0_1296)).S("Q").V(Call(f1_20, V.Undef, Add(GetIdx(w0_1296, 0D), ((V)((6D * ToNum(k_1294))))))).S(" ").V(Call(f1_20, V.Undef, Add(GetIdx(w0_1296, 1D), ((V)((6D * ToNum(k_1294))))))).S(" ").V(Call(P2_25, V.Undef, w1_1297)).S("\" fill=\"none\" stroke=\"#bfe8ff\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((1.3 * ToNum(k_1294)))))).S("\" stroke-dasharray=\"").V(Call(f1_20, V.Undef, ((V)((2D * ToNum(k_1294)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((1.4 * ToNum(k_1294)))))).S("\" opacity=\"0.8\">").V(Call(an_28, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_20, V.Undef, ((V)((10D * ToNum(k_1294)))))).End())), ((V)(0.6)))).S("</path>").End()));
return NewObj(3).Put("defs", Get(o_1295, "defs")).Put("front", ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_30, V.Undef, ((V)("translate")), ((V)("0 0;0 -4;0 0")), ((V)(4D)))).V(Get(o_1295, "front")).V(wf_1298).S("</g>").End()))).Put("bb", Get(o_1295, "bb")).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 0, "terrarium", true)).Put("fern", Fn((V _arrowThis1305, int _argc1299, V _a1301, V _a1302, V _a1303, V _a1304, V[] _rest1300) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(54D))).Put("d", ((V)(54D))).Put("build", Fn((V _arrowThis1313, int _argc1306, V P_1312, V _a1309, V _a1310, V _a1311, V[] _rest1307) => {
return Call(potT_52, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(11D)), ((V)(16D)), ((V)((Truthy(Get(S_1075, "faux")) ? "#e9e4da" : "#c8693f"))), NewObj(3).Put("base", ((V)(0.8))).Put("lip", ((V)(3D))).Put("mat", (Truthy(Get(S_1075, "faux")) ? ((V)("cer")) : V.Null)).V);
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1321, int _argc1314, V c_1320, V _a1317, V _a1318, V _a1319, V[] _rest1315) => {
return NewObj(3).Put("split", Call(S0_68, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(16D)), ((V)(0D)))).Put("sw", ((V)(1.4))).V;
}, 1, "", true), Fn((V _arrowThis1329, int _argc1322, V E_1328, V _a1325, V _a1326, V _a1327, V[] _rest1323) => {
return Call(fern_60, V.Undef, E_1328, ((V)(0D)), ((V)(17D)), ((V)(0D)), ((V)((Truthy(Get(S_1075, "faux")) ? 0.8 : 1D))), Call(R_1078, V.Undef), Get(S_1075, "faux"));
}, 1, "", true))).V);
}, 0, "fern", true)).Put("euca", Fn((V _arrowThis1336, int _argc1330, V _a1332, V _a1333, V _a1334, V _a1335, V[] _rest1331) => {
return NewObj(6).Put("w", ((V)(40D))).Put("d", ((V)(30D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(70D))).Put("build", Fn((V _arrowThis1344, int _argc1337, V P_1343, V _a1340, V _a1341, V _a1342, V[] _rest1338) => {
return Arr(Call(disc_17, V.Undef, ((V)(0D)), ((V)(30D)), ((V)((-4D))), ((V)(3.4)), ((V)(2D)), ((V)("#d5dde2")), Call(mt_32, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Invoke(K_10, "solid", NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(30D)))).Put("a", ((V)(1.2))).Put("b", ((V)(1.2))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)((-2D))), ((V)(0D))), Arr(((V)(10D)), ((V)(0D))))).Put("col", ((V)("#d5dde2"))).Put("mat", ((V)("metal"))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(12D)), ((V)(6D)), ((V)(6D)), ((V)("#c9d0d6")), Call(mt_32, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.4))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(23.4)), ((V)(12D)), ((V)(5.6)), ((V)(0.6)), ((V)("#9aa3a8")), Call(mt_32, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)));
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1352, int _argc1345, V c_1351, V _a1348, V _a1349, V _a1350, V[] _rest1346) => {
return NewObj(3).Put("piv", Arr(((V)(0D)), ((V)(22D)), ((V)(14D)))).Put("sw", ((V)(2.4))).Put("dur", ((V)(4D))).V;
}, 1, "", true), Fn((V _arrowThis1360, int _argc1353, V E_1359, V _a1356, V _a1357, V _a1358, V[] _rest1354) => {
Call(euca_62, V.Undef, E_1359, ((V)(0D)), ((V)(22D)), ((V)(8D)), ((V)(1D)), Call(R_1078, V.Undef));
Invoke(E_1359, "stem", Arr(Arr(((V)((-2D))), ((V)(21.5)), ((V)(9D))), Arr(((V)(2D)), ((V)(21.5)), ((V)(9D)))), ((V)(2.2)), ((V)(2.2)), ((V)("#c9a873")));
return default;
}, 1, "", true))).V;
}, 0, "euca", true)).Put("bambooFern", Fn((V _arrowThis1367, int _argc1361, V _a1363, V _a1364, V _a1365, V _a1366, V[] _rest1362) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(70D))).Put("d", ((V)(44D))).Put("build", Fn((V _arrowThis1375, int _argc1368, V P_1374, V _a1371, V _a1372, V _a1373, V[] _rest1369) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)(0D)), ((V)(7D)), ((V)(16D)), GL_42, Call(cer_34, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("op", ((V)(0.3))).V))).Add(Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(0.4)), ((V)(0D)), ((V)(6.4)), ((V)(3D)), ((V)("#d8cdb8")), NewObj(2).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(3.4)), ((V)(0D)), ((V)(6.4)), ((V)(9D)), ((V)("#bfe4f2")), NewObj(3).Put("n", ((V)(16D))).Put("op", ((V)(0.45))).Put("noOut", ((V)(1D))).V)).Spread(Call(potT_52, V.Undef, ((V)(18D)), ((V)(0D)), ((V)(12D)), ((V)(15D)), ((V)("#e9e4da")), NewObj(3).Put("mat", ((V)("cer"))).Put("base", ((V)(0.82))).Put("lip", ((V)(2D))).V)).V;
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1383, int _argc1376, V c_1382, V _a1379, V _a1380, V _a1381, V[] _rest1377) => {
return NewObj(3).Put("split", Call(S0_68, V.Undef, ((V)(2D)), ((V)(12D)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(12D)), ((V)(0D)))).Put("sw", ((V)(0.9))).V;
}, 1, "", true), Fn((V _arrowThis1391, int _argc1384, V E_1390, V _a1387, V _a1388, V _a1389, V[] _rest1385) => {
Call(bamboo_61, V.Undef, E_1390, ((V)((-14D))), ((V)(3D)), ((V)(0D)), ((V)(1D)), Call(R_1078, V.Undef));
Call(fern_60, V.Undef, E_1390, ((V)(18D)), ((V)(15.6)), ((V)(0D)), ((V)(0.85)), Call(R_1078, V.Undef));
return default;
}, 1, "", true))).V);
}, 0, "bambooFern", true)).Put("mossWall", Fn((V _arrowThis1398, int _argc1392, V _a1394, V _a1395, V _a1396, V _a1397, V[] _rest1393) => {
return NewObj(4).Put("w", ((V)(90D))).Put("d", ((V)(34D))).Put("build", Fn((V _arrowThis1406, int _argc1399, V P_1405, V _a1402, V _a1403, V _a1404, V[] _rest1400) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(84D)), ((V)(10D)), ((V)(26D)), ((V)("#8a8a84")), Call(cer_34, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(8.4)), ((V)(4D)), ((V)(80D)), ((V)(1.6)), ((V)(22D)), ((V)("#9fd6ea")), NewObj(3).Put("r", ((V)(2D))).Put("op", ((V)(0.85))).Put("noOut", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(10D)), ((V)((-8D))), ((V)(84D)), ((V)(84D)), ((V)(6D)), ((V)("#6b4226")), Call(wd_33, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slab_15, V.Undef, ((V)(0D)), ((V)(14D)), ((V)((-4.6))), ((V)(76D)), ((V)(76D)), ((V)(1D)), ((V)("#3a5a26")), NewObj(1).Put("r", ((V)(1.5))).V), Invoke(K_10, "solid", NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(22D)), ((V)(78D)))).Put("a", ((V)(2.4))).Put("b", ((V)(2.4))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((-5D))), ((V)(0D))), Arr(((V)(12D)), ((V)(0D)), ((V)(0.9))))).Put("col", ((V)("#c9b26a"))).Put("mat", ((V)("wood"))).V), Call(disc_17, V.Undef, ((V)(22D)), ((V)(78D)), ((V)(12D)), ((V)(2D)), ((V)(0.4)), ((V)("#5a7a3a")), NewObj(2).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).V));
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1414, int _argc1407, V c_1413, V _a1410, V _a1411, V _a1412, V[] _rest1408) => {
V E_1415 = default;
V R0_1416 = default;
V o_1417 = default;
V k_1418 = default;
V w0_1419 = default;
V w1_1420 = default;
E_1415 = New(Flora_49, c_1413, NewObj(2).Put("piv", Arr(((V)(0D)), ((V)(14D)), ((V)((-4D))))).Put("sw", ((V)(0.4))).V);
R0_1416 = Call(R_1078, V.Undef);
{
double j_1421 = 0;
j_1421 = 0D;
while (true) {
if (!((j_1421 < 7D))) break;
{
double i_1423 = 0;
i_1423 = 0D;
while (true) {
if (!((i_1423 < 7D))) break;
Invoke(E_1415, "clump", Arr(((V)((((-33D) + (i_1423 * 11D)) + ((ToNum(Call(R0_1416, V.Undef)) - 0.5) * 3D)))), ((V)(((18D + (j_1421 * 11D)) + ((ToNum(Call(R0_1416, V.Undef)) - 0.5) * 3D)))), ((V)((-3D)))), ((V)(6D)), ((V)(5.4)), ((V)(1.6)), ((V)(9D)), NewObj(5).Put("R", R0_1416).Put("cols", Arr(((V)("#4f8a36")), ((V)("#5f9a3e")), ((V)("#6fae46")), ((V)("#3f7a2e")))).Put("len", ((V)(2.6))).Put("wid", ((V)(2.4))).Put("droop", ((V)(0.1))).V);
i_1423++;
}
}
j_1421++;
}
}
Invoke(Arr(Arr(((V)((-24D))), ((V)(30D))), Arr(((V)(10D)), ((V)(54D))), Arr(((V)((-8D))), ((V)(74D)))), "forEach", Fn((V _arrowThis1436, int _argc1425, V _a1427, V _a1428, V _a1429, V _a1430, V[] _rest1426) => {
V x_1433 = default;
V y_1435 = default;
{ V _t1431 = ListOf(_a1427);
{ V _t1432 = GetIdx(_t1431, 0D);
x_1433 = _t1432; }
{ V _t1434 = GetIdx(_t1431, 1D);
y_1435 = _t1434; }
}
return Call(rep_22, V.Undef, ((V)(7D)), Fn((V _arrowThis1444, int _argc1437, V i_1443, V _a1440, V _a1441, V _a1442, V[] _rest1438) => {
return Invoke(E_1415, "leaf", NewObj(10).Put("b", Arr(x_1433, y_1435, ((V)((-2D))))).Put("az", ((V)(((PI_38 / 2D) + ((ToNum(i_1443) - 3D) * 0.45))))).Put("el", ((V)(0.4))).Put("len", ((V)(9D))).Put("wid", ((V)(2.6))).Put("droop", ((V)(0.5))).Put("sh", ((V)("lance"))).Put("col", ((V)("#5aa844"))).Put("simple", ((V)(1D))).Put("seg", ((V)(4D))).V);
}, 1, "", true));
}, 1, "", true));
o_1417 = Invoke(E_1415, "out");
k_1418 = Get(c_1413, "k");
w0_1419 = Invoke(c_1413, "p", ((V)(22D)), ((V)(77D)), ((V)(12.4)));
w1_1420 = Invoke(c_1413, "p", ((V)(22D)), ((V)(10D)), ((V)(12.4)));
OpSet(o_1417, "front", 0, ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(P2_25, V.Undef, w0_1419)).S("Q").V(Call(f1_20, V.Undef, Add(GetIdx(w0_1419, 0D), ((V)((2D * ToNum(k_1418))))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(Add(GetIdx(w0_1419, 1D), GetIdx(w1_1420, 1D))) / 2D))))).S(" ").V(Call(P2_25, V.Undef, w1_1420)).S("\" fill=\"none\" stroke=\"#d8f2ff\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((1.1 * ToNum(k_1418)))))).S("\" stroke-dasharray=\"").V(Call(f1_20, V.Undef, ((V)((2.2 * ToNum(k_1418)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((1.2 * ToNum(k_1418)))))).S("\" opacity=\"0.85\">").V(Call(an_28, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_20, V.Undef, ((V)((10D * ToNum(k_1418)))))).End())), ((V)(0.5)))).S("</path><g transform=\"").V(Call(planeH_27, V.Undef, Get(c_1413, "p"), ((V)(10.1)), ((V)(22D)), ((V)(12D)))).S("\">").V(Invoke(Call(rep_22, V.Undef, ((V)(2D)), Fn((V _arrowThis1452, int _argc1445, V i_1451, V _a1448, V _a1449, V _a1450, V[] _rest1446) => {
return ((V)(JsStrBuf.Begin().S("<ellipse rx=\"2\" ry=\"2\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.4\">").V(Call(an_28, V.Undef, ((V)("rx")), ((V)("1;7")), ((V)(1.4)), ((V)(((-ToNum(i_1451)) * 0.7))))).V(Call(an_28, V.Undef, ((V)("ry")), ((V)("1;7")), ((V)(1.4)), ((V)(((-ToNum(i_1451)) * 0.7))))).V(Call(an_28, V.Undef, ((V)("opacity")), ((V)("0.9;0")), ((V)(1.4)), ((V)(((-ToNum(i_1451)) * 0.7))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>").End())));
return o_1417;
return default;
}, 1, "fx", true)).V;
}, 0, "mossWall", true)).Put("koi", Fn((V _arrowThis1459, int _argc1453, V _a1455, V _a1456, V _a1457, V _a1458, V[] _rest1454) => {
return NewObj(4).Put("w", ((V)(110D))).Put("d", ((V)(90D))).Put("build", Fn((V _arrowThis1467, int _argc1460, V P_1466, V _a1463, V _a1464, V _a1465, V[] _rest1461) => {
V o_1468 = default;
V R0_1469 = default;
o_1468 = Arr(Call(arcW_16, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(52D)), ((V)(40D)), ((V)(7D)), ((V)(10D)), ((V)(0D)), ((V)((2D * PI_38))), ((V)("#8a8a84")), Call(cer_34, V.Undef, NewObj(1).Put("n", ((V)(30D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(46D)), ((V)(7D)), ((V)("#3f8fb0")), NewObj(3).Put("rz", ((V)(34D))).Put("n", ((V)(30D))).Put("op", ((V)(0.95))).V));
R0_1469 = Call(rng_23, V.Undef, ((V)("koirock")));
Call(rep_22, V.Undef, ((V)(14D)), Fn((V _arrowThis1477, int _argc1470, V i_1476, V _a1473, V _a1474, V _a1475, V[] _rest1471) => {
double a_1478 = 0;
a_1478 = (((ToNum(i_1476) / 14D) * 2D) * PI_38);
Invoke(o_1468, "push", Call(ball_14, V.Undef, ((V)((FdLibm.Cos(a_1478) * 50D))), ((V)(8D)), ((V)((FdLibm.Sin(a_1478) * 38D))), ((V)((4D + (ToNum(Call(R0_1469, V.Undef)) * 2D)))), ((V)("#9a9a92")), Call(cer_34, V.Undef, NewObj(3).Put("sy", ((V)(0.55))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)));
return default;
}, 1, "", true));
Invoke(o_1468, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((-4D))), ((V)(18D)), ((V)("#7a6a5a")), NewObj(3).Put("sy", ((V)(0.9))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).V), Call(ball_14, V.Undef, ((V)((-8D))), ((V)(4D)), ((V)(2D)), ((V)(10D)), ((V)("#6a5a4a")), NewObj(2).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(33D)), ((V)((-4D))), ((V)(16D)), ((V)("#4f8a36")), NewObj(3).Put("sy", ((V)(0.14))).Put("k", ((V)(3D))).Put("n", ((V)(16D))).V));
return o_1468;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis1486, int _argc1479, V c_1485, V _a1482, V _a1483, V _a1484, V[] _rest1480) => {
V E_1487 = default;
V o_1488 = default;
V p_1489 = default;
V k_1490 = default;
JsStrBuf f_1491 = null;
V w0_1492 = default;
V w1_1493 = default;
E_1487 = New(Flora_49, c_1485, NewObj(3).Put("split", ((V)((-1000000000D)))).Put("piv", Arr(((V)(0D)), ((V)(36D)), ((V)((-4D))))).Put("sw", ((V)(0.5))).V);
Call(bonsai_58, V.Undef, E_1487, ((V)(0D)), ((V)(35D)), ((V)((-4D))), ((V)(0.85)), Call(R_1078, V.Undef));
o_1488 = Invoke(E_1487, "out");
p_1489 = Get(c_1485, "p");
k_1490 = Get(c_1485, "k");
f_1491 = new JsStrBuf("");
Invoke(Arr(Arr(((V)("#ff7a22")), ((V)(0D))), Arr(((V)("#ffffff")), ((V)(1D))), Arr(((V)("#ff9d4a")), ((V)(2D)))), "forEach", Fn((V _arrowThis1505, int _argc1494, V _a1496, V _a1497, V _a1498, V _a1499, V[] _rest1495) => {
V col_1502 = default;
V i_1504 = default;
{ V _t1500 = ListOf(_a1496);
{ V _t1501 = GetIdx(_t1500, 0D);
col_1502 = _t1501; }
{ V _t1503 = GetIdx(_t1500, 1D);
i_1504 = _t1503; }
}
f_1491.S("<g transform=\"").V(Call(planeH_27, V.Undef, p_1489, ((V)(7.1)))).S("\"><g><animateMotion dur=\"").N((9D + (ToNum(i_1504) * 2D))).S("s\" begin=\"").N(((-ToNum(i_1504)) * 3D)).S("s\" repeatCount=\"indefinite\" rotate=\"auto\" path=\"M36 0A36 26 0 1 1 -36 0A36 26 0 1 1 36 0\"/><path d=\"M-5 0Q-2 -2.4 2.6 -1.2Q5 0 2.6 1.2Q-2 2.4 -5 0L-7 -2L-6.6 0L-7 2Z\" fill=\"").V(col_1502).S("\" stroke=\"#b8501a\" stroke-width=\"0.3\"/><circle cx=\"-1\" cy=\"-0.6\" r=\"0.9\" fill=\"#ff5a1a\" opacity=\"").N((SEqN(i_1504, 1D) ? 0.9 : 0D)).S("\"/></g></g>");
return default;
}, 1, "", true));
w0_1492 = Call(p_1489, V.Undef, ((V)(10D)), ((V)(30D)), ((V)(8D)));
w1_1493 = Call(p_1489, V.Undef, ((V)(14D)), ((V)(7.2)), ((V)(14D)));
f_1491.S("<path d=\"M").V(Call(P2_25, V.Undef, w0_1492)).S("Q").V(Call(f1_20, V.Undef, Add(GetIdx(w0_1492, 0D), ((V)((5D * ToNum(k_1490))))))).S(" ").V(Call(f1_20, V.Undef, Add(GetIdx(w0_1492, 1D), ((V)((4D * ToNum(k_1490))))))).S(" ").V(Call(P2_25, V.Undef, w1_1493)).S("\" fill=\"none\" stroke=\"#d8f2ff\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((1.6 * ToNum(k_1490)))))).S("\" stroke-dasharray=\"").V(Call(f1_20, V.Undef, ((V)((2D * ToNum(k_1490)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((1.2 * ToNum(k_1490)))))).S("\" opacity=\"0.85\">").V(Call(an_28, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_20, V.Undef, ((V)((10D * ToNum(k_1490)))))).End())), ((V)(0.5)))).S("</path>");
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis1513, int _argc1506, V i_1512, V _a1509, V _a1510, V _a1511, V[] _rest1507) => {
V q_1514 = default;
q_1514 = Call(p_1489, V.Undef, ((V)(((-20D) + (ToNum(i_1512) * 10D)))), ((V)(9D)), ((V)((10D - (ToNum(i_1512) * 3D)))));
f_1491.S("<ellipse cx=\"").V(Call(f1_20, V.Undef, GetIdx(q_1514, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(q_1514, 1D))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((8D * ToNum(k_1490)))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((3D * ToNum(k_1490)))))).S("\" fill=\"#ffffff\" opacity=\"0\">").V(Call(an_28, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(q_1514, 1D))).S(";").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_1514, 1D)) - (14D * ToNum(k_1490))))))).End())), ((V)(4D)), ((V)(((-ToNum(i_1512)) * 0.8))))).V(Call(an_28, V.Undef, ((V)("opacity")), ((V)("0;0.3;0")), ((V)(4D)), ((V)(((-ToNum(i_1512)) * 0.8))))).S("</ellipse>");
return default;
}, 1, "", true));
OpSet(o_1488, "front", 0, ((V)(f_1491.Str)));
return o_1488;
return default;
}, 1, "fx", true)).V;
}, 0, "koi", true)).Put("sapling", Fn((V _arrowThis1521, int _argc1515, V _a1517, V _a1518, V _a1519, V _a1520, V[] _rest1516) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(50D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis1529, int _argc1522, V P_1528, V _a1525, V _a1526, V _a1527, V[] _rest1523) => {
return Arr(Call(ball_14, V.Undef, ((V)(0D)), ((V)((-2D))), ((V)(0D)), ((V)(16D)), ((V)("#6a4a2a")), NewObj(4).Put("sy", ((V)(0.3))).Put("k", ((V)(4D))).Put("n", ((V)(16D))).Put("mat", ((V)("paint"))).V), Call(box_12, V.Undef, ((V)(9D)), ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(64D)), ((V)(2D)), ((V)("#b98a58")), Call(wd_33, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1537, int _argc1530, V c_1536, V _a1533, V _a1534, V _a1535, V[] _rest1531) => {
return NewObj(4).Put("split", Call(S0_68, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(2D)), ((V)(0D)))).Put("sw", ((V)(1.8))).Put("dur", ((V)(4.4))).V;
}, 1, "", true), Fn((V _arrowThis1545, int _argc1538, V E_1544, V _a1541, V _a1542, V _a1543, V[] _rest1539) => {
V R0_1546 = default;
V T_1547 = default;
R0_1546 = Call(R_1078, V.Undef);
T_1547 = Arr(Arr(((V)(0D)), ((V)(2D)), ((V)(0D))), Arr(((V)(1D)), ((V)(22D)), ((V)(0D))), Arr(((V)((-1D))), ((V)(44D)), ((V)(0.5))), Arr(((V)(1D)), ((V)(64D)), ((V)(0D))), Arr(((V)(0D)), ((V)(74D)), ((V)(0D))));
Invoke(E_1544, "stem", T_1547, ((V)(1.7)), ((V)(0.7)), ((V)("#8a6a4a")));
Invoke(Arr(Arr(((V)(1D)), ((V)(0.6))), Arr(((V)(2D)), ((V)((-0.8)))), Arr(((V)(3D)), ((V)(0.4)))), "forEach", Fn((V _arrowThis1559, int _argc1548, V _a1550, V _a1551, V _a1552, V _a1553, V[] _rest1549) => {
V P_1560 = default;
V E2_1561 = default;
V j_1556 = default;
V a_1558 = default;
{ V _t1554 = ListOf(_a1550);
{ V _t1555 = GetIdx(_t1554, 0D);
j_1556 = _t1555; }
{ V _t1557 = GetIdx(_t1554, 1D);
a_1558 = _t1557; }
}
P_1560 = GetK(T_1547, j_1556);
E2_1561 = Arr(Add(GetIdx(P_1560, 0D), ((V)((FdLibm.Cos(ToNum(a_1558)) * 12D)))), Add(GetIdx(P_1560, 1D), ((V)(6D))), Add(GetIdx(P_1560, 2D), ((V)((FdLibm.Sin(ToNum(a_1558)) * 6D)))));
Invoke(E_1544, "stem", Arr(P_1560, E2_1561), ((V)(0.8)), ((V)(0.4)), ((V)("#8a6a4a")));
Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis1569, int _argc1562, V i_1568, V _a1565, V _a1566, V _a1567, V[] _rest1563) => {
return Invoke(E_1544, "leaf", NewObj(10).Put("b", E2_1561).Put("az", Add(a_1558, ((V)(((ToNum(i_1568) - 1D) * 0.9))))).Put("el", ((V)(0.2))).Put("len", ((V)(6D))).Put("wid", ((V)(3.4))).Put("droop", ((V)(0.6))).Put("sh", ((V)("oval"))).Put("col", ((V)((LtN(Call(R0_1546, V.Undef), 0.3) ? "#c8b44a" : "#6fa84a")))).Put("vein", ((V)(1D))).Put("seg", ((V)(5D))).V);
}, 1, "", true));
return default;
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis1577, int _argc1570, V i_1576, V _a1573, V _a1574, V _a1575, V[] _rest1571) => {
return Invoke(E_1544, "leaf", NewObj(10).Put("b", GetIdx(T_1547, 4D)).Put("az", ((V)((ToNum(i_1576) * 1.6)))).Put("el", ((V)(0.5))).Put("len", ((V)(6D))).Put("wid", ((V)(3.6))).Put("droop", ((V)(0.4))).Put("sh", ((V)("oval"))).Put("col", ((V)("#7ab84e"))).Put("vein", ((V)(1D))).Put("seg", ((V)(5D))).V);
}, 1, "", true));
Invoke(Arr(((V)(30D)), ((V)(52D))), "forEach", Fn((V _arrowThis1585, int _argc1578, V y_1584, V _a1581, V _a1582, V _a1583, V[] _rest1579) => {
V a_1586 = default;
V b_1587 = default;
a_1586 = Invoke(E_1544, "q", Arr(((V)(0D)), y_1584, ((V)(0D))));
b_1587 = Invoke(E_1544, "q", Arr(((V)(9D)), y_1584, ((V)(0D))));
Invoke(E_1544, "add", Call(dep_44, V.Undef, ((V)(5D)), y_1584, ((V)(1.2))), ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(P2_25, V.Undef, a_1586)).S("L").V(Call(P2_25, V.Undef, b_1587)).S("\" stroke=\"#c9a873\" stroke-width=\"1.6\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_25, V.Undef, a_1586)).S("L").V(Call(P2_25, V.Undef, b_1587)).S("\" stroke=\"#8a6a3a\" stroke-width=\"1.6\" stroke-dasharray=\"0.5 0.7\"/>").End())));
return default;
}, 1, "", true));
return default;
}, 1, "", true))).V);
}, 0, "sapling", true)).Put("lemon", Fn((V _arrowThis1594, int _argc1588, V _a1590, V _a1591, V _a1592, V _a1593, V[] _rest1589) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(80D))).Put("d", ((V)(70D))).Put("build", Fn((V _arrowThis1602, int _argc1595, V P_1601, V _a1598, V _a1599, V _a1600, V[] _rest1596) => {
V o_1603 = default;
o_1603 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(24D)), ((V)(26D)), ((V)("#9a6a3a")), Call(wd_33, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(13D)), ((V)(0D)), ((V)(1.04))), Arr(((V)(26D)), ((V)(0D)), ((V)(0.96))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(24.6)), ((V)(0D)), ((V)(22.6)), ((V)(1.6)), ((V)("#4a3020")), NewObj(2).Put("n", ((V)(22D))).Put("noOut", ((V)(1D))).V));
Invoke(Arr(((V)(4D)), ((V)(20D))), "forEach", Fn((V _arrowThis1611, int _argc1604, V y_1610, V _a1607, V _a1608, V _a1609, V[] _rest1605) => {
return Invoke(o_1603, "push", Call(arcW_16, V.Undef, ((V)(0D)), y_1610, ((V)(0D)), ((V)(25.2)), ((V)(25.2)), ((V)(1.2)), ((V)(2.4)), ((V)(0D)), ((V)((2D * PI_38))), ((V)("#4a4c52")), Call(mt_32, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)));
}, 1, "", true));
return o_1603;
return default;
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1619, int _argc1612, V c_1618, V _a1615, V _a1616, V _a1617, V[] _rest1613) => {
return NewObj(3).Put("split", Call(S0_68, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(26D)), ((V)(0D)))).Put("sw", ((V)(0.8))).V;
}, 1, "", true), Fn((V _arrowThis1628, int _argc1620, V E_1626, V c_1627, V _a1624, V _a1625, V[] _rest1621) => {
V R0_1629 = default;
V pl_1630 = default;
JsStrBuf s_1631 = null;
R0_1629 = Call(R_1078, V.Undef);
pl_1630 = Arr();
s_1631 = new JsStrBuf("");
Call(rep_22, V.Undef, ((V)(12D)), Fn((V _arrowThis1639, int _argc1632, V i_1638, V _a1635, V _a1636, V _a1637, V[] _rest1633) => {
double a_1640 = 0;
V q1_1641 = default;
V q2_1642 = default;
a_1640 = (((ToNum(i_1638) / 12D) * 2D) * PI_38);
q1_1641 = Invoke(c_1627, "p", ((V)((FdLibm.Cos(a_1640) * 23.8))), ((V)(3D)), ((V)((FdLibm.Sin(a_1640) * 23.8))));
q2_1642 = Invoke(c_1627, "p", ((V)((FdLibm.Cos(a_1640) * 24.8))), ((V)(24D)), ((V)((FdLibm.Sin(a_1640) * 24.8))));
if ((FdLibm.Sin((a_1640 + (PI_38 / 6D))) > (-0.2))) {
s_1631.S("<path d=\"M").V(Call(P2_25, V.Undef, q1_1641)).S("L").V(Call(P2_25, V.Undef, q2_1642)).S("\" stroke=\"#6a4422\" stroke-width=\"0.5\" opacity=\"0.7\"/>");
}
return default;
}, 1, "", true));
Invoke(E_1626, "add", Call(dep_44, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(30D))), ((V)(s_1631.Str)), ((V)("f0")));
Invoke(E_1626, "stem", Arr(Arr(((V)(0D)), ((V)(26D)), ((V)(0D))), Arr(((V)(1D)), ((V)(40D)), ((V)(0D))), Arr(((V)((-1D))), ((V)(52D)), ((V)(0D)))), ((V)(3D)), ((V)(2D)), ((V)("#7a5a3a")), NewObj(1).Put("bark", ((V)(1D))).V);
Invoke(Arr(Arr(((V)((-8D))), ((V)(50D)), ((V)(2D))), Arr(((V)(8D)), ((V)(54D)), ((V)((-2D)))), Arr(((V)(0D)), ((V)(62D)), ((V)(0D)))), "forEach", Fn((V _arrowThis1650, int _argc1643, V P_1649, V _a1646, V _a1647, V _a1648, V[] _rest1644) => {
return Invoke(E_1626, "stem", Arr(Arr(((V)(0D)), ((V)(50D)), ((V)(0D))), P_1649), ((V)(1.6)), ((V)(1D)), ((V)("#7a5a3a")));
}, 1, "", true));
Invoke(E_1626, "clump", Arr(((V)(0D)), ((V)(64D)), ((V)(0D))), ((V)(26D)), ((V)(18D)), ((V)(22D)), ((V)(110D)), NewObj(8).Put("R", R0_1629).Put("cols", Arr(((V)("#2f6f2e")), ((V)("#3a7f34")), ((V)("#2a5f28")))).Put("len", ((V)(6.4))).Put("wid", ((V)(3.4))).Put("sh", ((V)("oval"))).Put("droop", ((V)(0.3))).Put("top", ((V)(0.9))).Put("simple", ((V)(0D))).V);
Call(rep_22, V.Undef, ((V)(11D)), Fn((V _arrowThis1658, int _argc1651, V i_1657, V _a1654, V _a1655, V _a1656, V[] _rest1652) => {
double u_1659 = 0;
double v_1660 = 0;
V P_1661 = default;
u_1659 = ((ToNum(Call(R0_1629, V.Undef)) * 2D) * PI_38);
v_1660 = (0.4 + (ToNum(Call(R0_1629, V.Undef)) * 1.6));
P_1661 = Arr(((V)(((FdLibm.Sin(v_1660) * FdLibm.Cos(u_1659)) * 24D))), ((V)(((64D + (FdLibm.Cos(v_1660) * 16D)) - 4D))), ((V)(((FdLibm.Sin(v_1660) * FdLibm.Sin(u_1659)) * 20D))));
Invoke(E_1626, "blob", P_1661, ((V)(3.2)), ((V)("#f2d23a")), NewObj(4).Put("sx", ((V)(0.82))).Put("sy", ((V)(1D))).Put("shine", ((V)(1D))).Put("db", ((V)(3D))).V);
return default;
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis1669, int _argc1662, V i_1668, V _a1665, V _a1666, V _a1667, V[] _rest1663) => {
return Invoke(E_1626, "flower", Arr(((V)(((ToNum(Call(R0_1629, V.Undef)) - 0.5) * 40D))), ((V)((66D + (ToNum(Call(R0_1629, V.Undef)) * 14D)))), ((V)((10D + (ToNum(Call(R0_1629, V.Undef)) * 10D))))), ((V)(1.4)), ((V)("#ffffff")), NewObj(2).Put("ctr", ((V)("#f2c94c"))).Put("db", ((V)(4D))).V);
}, 1, "", true));
return default;
}, 2, "", true))).V);
}, 0, "lemon", true)).Put("cherry", Fn((V _arrowThis1676, int _argc1670, V _a1672, V _a1673, V _a1674, V _a1675, V[] _rest1671) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(120D))).Put("d", ((V)(90D))).Put("build", Fn((V _arrowThis1684, int _argc1677, V P_1683, V _a1680, V _a1681, V _a1682, V[] _rest1678) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(1.4)), ((V)("#5a3a20")), NewObj(3).Put("n", ((V)(22D))).Put("noOut", ((V)(1D))).Put("mat", ((V)("paint"))).V));
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1692, int _argc1685, V c_1691, V _a1688, V _a1689, V _a1690, V[] _rest1686) => {
return NewObj(4).Put("split", ((V)((-1000000000D)))).Put("piv", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("sw", ((V)(1D))).Put("dur", ((V)(6D))).V;
}, 1, "", true), Fn((V _arrowThis1701, int _argc1693, V E_1699, V c_1700, V _a1697, V _a1698, V[] _rest1694) => {
V R0_1702 = default;
V T_1703 = default;
JsStrBuf fp_1704 = null;
R0_1702 = Call(R_1078, V.Undef);
T_1703 = Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0D))), Arr(((V)(2D)), ((V)(20D)), ((V)(0D))), Arr(((V)((-2D))), ((V)(42D)), ((V)(1D))), Arr(((V)(1D)), ((V)(62D)), ((V)(0D))), Arr(((V)(0D)), ((V)(74D)), ((V)(0D))));
Invoke(E_1699, "stem", T_1703, ((V)(5D)), ((V)(2.6)), ((V)("#5a3a2a")), NewObj(1).Put("bark", ((V)(1D))).V);
Call(rep_22, V.Undef, ((V)(9D)), Fn((V _arrowThis1712, int _argc1705, V i_1711, V _a1708, V _a1709, V _a1710, V[] _rest1706) => {
double a_1713 = 0;
double cz_1714 = 0;
double sz_1715 = 0;
double r1_1716 = 0;
V pts_1717 = default;
a_1713 = ((ToNum(i_1711) * 0.7) + (ToNum(Call(R0_1702, V.Undef)) * 0.3));
cz_1714 = FdLibm.Cos(a_1713);
sz_1715 = FdLibm.Sin(a_1713);
r1_1716 = (22D + (ToNum(Call(R0_1702, V.Undef)) * 14D));
pts_1717 = Arr(GetIdx(T_1703, 3D), Arr(((V)(((cz_1714 * r1_1716) * 0.6))), ((V)((84D + (ToNum(Call(R0_1702, V.Undef)) * 6D)))), ((V)(((sz_1715 * r1_1716) * 0.5)))), Arr(((V)((cz_1714 * r1_1716))), ((V)(76D)), ((V)(((sz_1715 * r1_1716) * 0.8)))), Arr(((V)((cz_1714 * (r1_1716 + 6D)))), ((V)((52D - (ToNum(Call(R0_1702, V.Undef)) * 8D)))), ((V)(((sz_1715 * (r1_1716 + 6D)) * 0.8)))), Arr(((V)((cz_1714 * (r1_1716 + 8D)))), ((V)((30D - (ToNum(Call(R0_1702, V.Undef)) * 10D)))), ((V)(((sz_1715 * (r1_1716 + 8D)) * 0.8)))));
Invoke(E_1699, "stem", pts_1717, ((V)(1.8)), ((V)(0.5)), ((V)("#5a3a2a")));
{
double t_1718 = 0;
t_1718 = 0.25;
while (true) {
if (!((t_1718 < 1D))) break;
double j_1720 = 0;
double f_1721 = 0;
V P_1722 = default;
j_1720 = Min(3D, System.Math.Floor((t_1718 * 4D)));
f_1721 = ((t_1718 * 4D) - j_1720);
P_1722 = Invoke(GetIdx(pts_1717, j_1720), "map", Fn((V _arrowThis1731, int _argc1723, V v0_1729, V k_1730, V _a1727, V _a1728, V[] _rest1724) => {
return Add(v0_1729, ((V)(((ToNum(GetK(GetIdx(pts_1717, (j_1720 + 1D)), k_1730)) - ToNum(v0_1729)) * f_1721))));
}, 2, "", true));
Invoke(E_1699, "flower", Arr(Add(GetIdx(P_1722, 0D), ((V)(((ToNum(Call(R0_1702, V.Undef)) - 0.5) * 3D)))), ((V)((ToNum(GetIdx(P_1722, 1D)) - (ToNum(Call(R0_1702, V.Undef)) * 2D)))), Add(GetIdx(P_1722, 2D), ((V)(((ToNum(Call(R0_1702, V.Undef)) - 0.5) * 3D))))), ((V)((2D + (ToNum(Call(R0_1702, V.Undef)) * 0.8)))), ((V)((LtN(Call(R0_1702, V.Undef), 0.5) ? "#f6b8cc" : "#fbd4e0"))), NewObj(2).Put("ctr", ((V)("#e06a8a"))).Put("rot", ((V)((ToNum(Call(R0_1702, V.Undef)) * 70D)))).V);
t_1718 = (t_1718 + 0.07);
}
}
return default;
}, 1, "", true));
fp_1704 = new JsStrBuf("");
Call(rep_22, V.Undef, ((V)(10D)), Fn((V _arrowThis1739, int _argc1732, V i_1738, V _a1735, V _a1736, V _a1737, V[] _rest1733) => {
V q_1740 = default;
V d_1741 = default;
q_1740 = Invoke(c_1700, "p", ((V)(((ToNum(Call(R0_1702, V.Undef)) - 0.5) * 70D))), ((V)(70D)), ((V)(((ToNum(Call(R0_1702, V.Undef)) - 0.5) * 40D))));
d_1741 = Invoke(((V)((5D + (ToNum(Call(R0_1702, V.Undef)) * 4D)))), "toFixed", ((V)(1D)));
fp_1704.S("<ellipse cx=\"").V(Call(f1_20, V.Undef, GetIdx(q_1740, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(q_1740, 1D))).S("\" rx=\"1.4\" ry=\"0.9\" fill=\"#f6b8cc\">").V(Call(an_28, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(q_1740, 1D))).S(";").V(Call(f1_20, V.Undef, Add(GetIdx(q_1740, 1D), ((V)(80D))))).End())), d_1741, ((V)(((-ToNum(i_1738)) * 0.7))))).V(Call(an_28, V.Undef, ((V)("cx")), ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(q_1740, 0D))).S(";").V(Call(f1_20, V.Undef, Add(GetIdx(q_1740, 0D), ((V)(14D))))).S(";").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_1740, 0D)) - 6D))))).End())), d_1741, ((V)(((-ToNum(i_1738)) * 0.7))))).V(Call(an_28, V.Undef, ((V)("opacity")), ((V)("0;1;1;0")), d_1741, ((V)(((-ToNum(i_1738)) * 0.7))))).S("</ellipse>");
return default;
}, 1, "", true));
Set(E_1699, "over", ((V)(fp_1704.Str)));
return default;
}, 2, "", true))).V);
}, 0, "cherry", true)).Put("grove", Fn((V _arrowThis1748, int _argc1742, V _a1744, V _a1745, V _a1746, V _a1747, V[] _rest1743) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(120D))).Put("d", ((V)(80D))).Put("build", Fn((V _arrowThis1756, int _argc1749, V P_1755, V _a1752, V _a1753, V _a1754, V[] _rest1750) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(34D)), ((V)(1.4)), ((V)("#7a6a4a")), NewObj(4).Put("rz", ((V)(24D))).Put("n", ((V)(24D))).Put("noOut", ((V)(1D))).Put("mat", ((V)("paint"))).V));
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1764, int _argc1757, V c_1763, V _a1760, V _a1761, V _a1762, V[] _rest1758) => {
return NewObj(4).Put("split", ((V)((-1000000000D)))).Put("piv", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("sw", ((V)(0.6))).Put("dur", ((V)(7D))).V;
}, 1, "", true), Fn((V _arrowThis1772, int _argc1765, V E_1771, V _a1768, V _a1769, V _a1770, V[] _rest1766) => {
V R0_1773 = default;
R0_1773 = Call(R_1078, V.Undef);
Invoke(Arr(Arr(((V)(24D)), ((V)((-14D)))), Arr(((V)(38D)), ((V)((-4D))))), "forEach", Fn((V _arrowThis1786, int _argc1774, V _a1776, V i_1780, V _a1778, V _a1779, V[] _rest1775) => {
V x_1783 = default;
V z_1785 = default;
{ V _t1781 = ListOf(_a1776);
{ V _t1782 = GetIdx(_t1781, 0D);
x_1783 = _t1782; }
{ V _t1784 = GetIdx(_t1781, 1D);
z_1785 = _t1784; }
}
Invoke(E_1771, "stem", Arr(Arr(x_1783, ((V)(0D)), z_1785), Arr(x_1783, ((V)(10D)), z_1785)), ((V)(2.6)), ((V)(2.2)), ((V)("#5a4a3a")));
Invoke(E_1771, "clump", Arr(x_1783, ((V)((50D + (ToNum(i_1780) * 6D)))), z_1785), ((V)(7.5)), ((V)((44D + (ToNum(i_1780) * 6D)))), ((V)(7.5)), ((V)(150D)), NewObj(7).Put("R", R0_1773).Put("cols", Arr(((V)("#2f4a2a")), ((V)("#3a5a32")), ((V)("#2a4026")))).Put("len", ((V)(3.2))).Put("wid", ((V)(1.4))).Put("sh", ((V)("needle"))).Put("droop", ((V)(0.1))).Put("top", ((V)(1D))).V);
return default;
}, 2, "", true));
Call(olive_59, V.Undef, E_1771, ((V)((-14D))), ((V)(0D)), ((V)(8D)), ((V)(1.2)), R0_1773);
return default;
}, 1, "", true))).V);
}, 0, "grove", true)).Put("willow", Fn((V _arrowThis1793, int _argc1787, V _a1789, V _a1790, V _a1791, V _a1792, V[] _rest1788) => {
return Call(PT_67, V.Undef, NewObj(5).Put("w", ((V)(140D))).Put("d", ((V)(100D))).Put("glow", Fn((V _arrowThis1800, int _argc1794, V _a1796, V _a1797, V _a1798, V _a1799, V[] _rest1795) => {
return NewObj(3).Put("y", ((V)(70D))).Put("r", ((V)(90D))).Put("c", ((V)("url(#fwg)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1808, int _argc1801, V P_1807, V _a1804, V _a1805, V _a1806, V[] _rest1802) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(26D)), ((V)(1.4)), ((V)("#2a3a3a")), NewObj(3).Put("n", ((V)(24D))).Put("noOut", ((V)(1D))).Put("mat", ((V)("paint"))).V));
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1816, int _argc1809, V c_1815, V _a1812, V _a1813, V _a1814, V[] _rest1810) => {
return NewObj(4).Put("split", ((V)((-1000000000D)))).Put("piv", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("sw", ((V)(0.5))).Put("dur", ((V)(8D))).V;
}, 1, "", true), Fn((V _arrowThis1825, int _argc1817, V E_1823, V c_1824, V _a1821, V _a1822, V[] _rest1818) => {
V R0_1826 = default;
V T_1827 = default;
JsStrBuf m_1828 = null;
R0_1826 = Call(R_1078, V.Undef);
T_1827 = Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0D))), Arr(((V)(3D)), ((V)(24D)), ((V)(0D))), Arr(((V)((-3D))), ((V)(50D)), ((V)(1D))), Arr(((V)(0D)), ((V)(74D)), ((V)(0D))), Arr(((V)(0D)), ((V)(88D)), ((V)(0D))));
Invoke(E_1823, "stem", T_1827, ((V)(9D)), ((V)(4D)), ((V)("#4a3a4a")), NewObj(1).Put("bark", ((V)(1D))).V);
Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis1836, int _argc1829, V i_1835, V _a1832, V _a1833, V _a1834, V[] _rest1830) => {
double a_1837 = 0;
a_1837 = (ToNum(i_1835) * 1.6);
Invoke(E_1823, "stem", Arr(Arr(((V)(0D)), ((V)(2D)), ((V)(0D))), Arr(((V)((FdLibm.Cos(a_1837) * 12D))), ((V)((-1D))), ((V)((FdLibm.Sin(a_1837) * 9D))))), ((V)(4D)), ((V)(1.6)), ((V)("#4a3a4a")));
return default;
}, 1, "", true));
Set(E_1823, "defs", ((V)(JsStrBuf.Begin().S("<radialGradient id=\"fwg\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#7ff0ff\" stop-opacity=\"0.45\"/><stop offset=\"1\" stop-color=\"#7ff0ff\" stop-opacity=\"0\"/></radialGradient>").V(Call(BLUR_31, V.Undef, ((V)("fwb")), ((V)(1.2)))).End())));
Call(rep_22, V.Undef, ((V)(26D)), Fn((V _arrowThis1845, int _argc1838, V i_1844, V _a1841, V _a1842, V _a1843, V[] _rest1839) => {
double a_1846 = 0;
double r1_1847 = 0;
V top_1848 = default;
double len_1849 = 0;
V q0_1850 = default;
V q1_1851 = default;
V d_1852 = default;
JsStrBuf s_1853 = null;
a_1846 = ((ToNum(i_1844) * 2.4) + (ToNum(Call(R0_1826, V.Undef)) * 0.3));
r1_1847 = (18D + (ToNum(Call(R0_1826, V.Undef)) * 34D));
top_1848 = Arr(((V)((FdLibm.Cos(a_1846) * r1_1847))), ((V)(((92D - (r1_1847 * 0.25)) + (ToNum(Call(R0_1826, V.Undef)) * 6D)))), ((V)(((FdLibm.Sin(a_1846) * r1_1847) * 0.7))));
Invoke(E_1823, "stem", Arr(GetIdx(T_1827, 3D), Arr(((V)((ToNum(GetIdx(top_1848, 0D)) * 0.5))), Add(GetIdx(top_1848, 1D), ((V)(8D))), ((V)((ToNum(GetIdx(top_1848, 2D)) * 0.5)))), top_1848), ((V)(1.4)), ((V)(0.6)), ((V)("#4a3a4a")));
len_1849 = (40D + (ToNum(Call(R0_1826, V.Undef)) * 34D));
q0_1850 = Invoke(E_1823, "q", top_1848);
q1_1851 = Invoke(E_1823, "q", Arr(((V)((ToNum(GetIdx(top_1848, 0D)) * 1.08))), ((V)((ToNum(GetIdx(top_1848, 1D)) - len_1849))), ((V)((ToNum(GetIdx(top_1848, 2D)) * 1.08)))));
d_1852 = Invoke(((V)((2.4 + (ToNum(Call(R0_1826, V.Undef)) * 2D)))), "toFixed", ((V)(1D)));
s_1853 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"M").V(Call(P2_25, V.Undef, q0_1850)).S("Q").V(Call(f1_20, V.Undef, Add(GetIdx(q0_1850, 0D), ((V)(((ToNum(Call(R0_1826, V.Undef)) - 0.5) * 6D)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(Add(GetIdx(q0_1850, 1D), GetIdx(q1_1851, 1D))) / 2D))))).S(" ").V(Call(P2_25, V.Undef, q1_1851)).S("\" fill=\"none\" stroke=\"#7ff0ff\" stroke-width=\"2.6\" opacity=\"0.35\" filter=\"url(#fwb)\">").V(Call(an_28, V.Undef, ((V)("opacity")), ((V)("0.2;0.55;0.2")), d_1852, ((V)(((-ToNum(i_1844)) * 0.3))))).S("</path><path d=\"M").V(Call(P2_25, V.Undef, q0_1850)).S("Q").V(Call(f1_20, V.Undef, Add(GetIdx(q0_1850, 0D), ((V)(((ToNum(Call(R0_1826, V.Undef)) - 0.5) * 6D)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(Add(GetIdx(q0_1850, 1D), GetIdx(q1_1851, 1D))) / 2D))))).S(" ").V(Call(P2_25, V.Undef, q1_1851)).S("\" fill=\"none\" stroke=\"#c9fbff\" stroke-width=\"0.7\" stroke-dasharray=\"1.6 1.2\"/>").End());
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis1861, int _argc1854, V j_1860, V _a1857, V _a1858, V _a1859, V[] _rest1855) => {
double t_1862 = 0;
t_1862 = (ToNum(Add(j_1860, ((V)(1D)))) / 6D);
s_1853.S("<ellipse cx=\"").V(Call(f1_20, V.Undef, Add(GetIdx(q0_1850, 0D), ((V)(((ToNum(GetIdx(q1_1851, 0D)) - ToNum(GetIdx(q0_1850, 0D))) * t_1862)))))).S("\" cy=\"").V(Call(f1_20, V.Undef, Add(GetIdx(q0_1850, 1D), ((V)(((ToNum(GetIdx(q1_1851, 1D)) - ToNum(GetIdx(q0_1850, 1D))) * t_1862)))))).S("\" rx=\"1.4\" ry=\"0.7\" fill=\"").S((NumTruthy((ToNum(j_1860) % 2D)) ? "#7ff0ff" : "#b8ffcf")).S("\">").V(Call(an_28, V.Undef, ((V)("opacity")), ((V)("0.4;1;0.4")), d_1852, ((V)((((-ToNum(j_1860)) * 0.4) - (ToNum(i_1844) * 0.2)))))).S("</ellipse>");
return default;
}, 1, "", true));
Invoke(E_1823, "add", ((V)((ToNum(CallSpread(dep_44, V.Undef, new ArrBuilder().Spread(top_1848).V)) - 2D))), ((V)(s_1853.Str)));
return default;
}, 1, "", true));
m_1828 = new JsStrBuf("");
Call(rep_22, V.Undef, ((V)(12D)), Fn((V _arrowThis1870, int _argc1863, V i_1869, V _a1866, V _a1867, V _a1868, V[] _rest1864) => {
V q_1871 = default;
V d_1872 = default;
q_1871 = Invoke(c_1824, "p", ((V)(((ToNum(Call(R0_1826, V.Undef)) - 0.5) * 100D))), ((V)(4D)), ((V)(((ToNum(Call(R0_1826, V.Undef)) - 0.5) * 50D))));
d_1872 = Invoke(((V)((4D + (ToNum(Call(R0_1826, V.Undef)) * 3D)))), "toFixed", ((V)(1D)));
m_1828.S("<circle cx=\"").V(Call(f1_20, V.Undef, GetIdx(q_1871, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(q_1871, 1D))).S("\" r=\"0.9\" fill=\"#c9fbff\">").V(Call(an_28, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, GetIdx(q_1871, 1D))).S(";").V(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_1871, 1D)) - 90D))))).End())), d_1872, ((V)(((-ToNum(i_1869)) * 0.6))))).V(Call(an_28, V.Undef, ((V)("opacity")), ((V)("0;1;0")), d_1872, ((V)(((-ToNum(i_1869)) * 0.6))))).S("</circle>");
return default;
}, 1, "", true));
Set(E_1823, "over", ((V)(m_1828.Str)));
return default;
}, 2, "", true))).V);
}, 0, "willow", true)).Put("tire", Fn((V _arrowThis1879, int _argc1873, V _a1875, V _a1876, V _a1877, V _a1878, V[] _rest1874) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(56D))).Put("d", ((V)(50D))).Put("build", Fn((V _arrowThis1887, int _argc1880, V P_1886, V _a1883, V _a1884, V _a1885, V[] _rest1881) => {
return Arr(Call(arcW_16, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(22D)), ((V)(7D)), ((V)(10D)), ((V)(0D)), ((V)((2D * PI_38))), ((V)("#2a2b2e")), NewObj(2).Put("n", ((V)(28D))).Put("mat", ((V)("paint"))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)), ((V)(15.6)), ((V)(6.6)), ((V)("#4a3020")), NewObj(2).Put("n", ((V)(22D))).Put("noOut", ((V)(1D))).V));
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis1895, int _argc1888, V c_1894, V _a1891, V _a1892, V _a1893, V[] _rest1889) => {
return NewObj(3).Put("split", Call(S0_68, V.Undef, ((V)(0D)), ((V)(9D)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(9D)), ((V)(0D)))).Put("sw", ((V)(1.2))).V;
}, 1, "", true), Fn((V _arrowThis1904, int _argc1896, V E_1902, V c_1903, V _a1900, V _a1901, V[] _rest1897) => {
V R0_1905 = default;
JsStrBuf t_1906 = null;
R0_1905 = Call(R_1078, V.Undef);
t_1906 = new JsStrBuf("");
Call(rep_22, V.Undef, ((V)(28D)), Fn((V _arrowThis1914, int _argc1907, V i_1913, V _a1910, V _a1911, V _a1912, V[] _rest1908) => {
double a_1915 = 0;
V q1_1916 = default;
V q2_1917 = default;
a_1915 = (((ToNum(i_1913) / 28D) * 2D) * PI_38);
if ((FdLibm.Sin((a_1915 + (PI_38 / 6D))) < (-0.1))) {
return default;
}
q1_1916 = Invoke(c_1903, "p", ((V)((FdLibm.Cos(a_1915) * 22.2))), ((V)(1.4)), ((V)((FdLibm.Sin(a_1915) * 22.2))));
q2_1917 = Invoke(c_1903, "p", ((V)((FdLibm.Cos(a_1915) * 22.2))), ((V)(8.6)), ((V)((FdLibm.Sin(a_1915) * 22.2))));
t_1906.S("<path d=\"M").V(Call(P2_25, V.Undef, q1_1916)).S("L").V(Call(P2_25, V.Undef, q2_1917)).S("\" stroke=\"#141416\" stroke-width=\"1.1\"/>");
return default;
}, 1, "", true));
Invoke(E_1902, "add", Call(dep_44, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(24D))), ((V)(t_1906.Str)), ((V)("f0")));
Invoke(Arr(Arr(((V)((-7D))), ((V)((-4D)))), Arr(((V)(6D)), ((V)((-6D)))), Arr(((V)(0D)), ((V)(6D))), Arr(((V)((-8D))), ((V)(7D))), Arr(((V)(9D)), ((V)(5D)))), "forEach", Fn((V _arrowThis1930, int _argc1918, V _a1920, V i_1924, V _a1922, V _a1923, V[] _rest1919) => {
V top_1931 = default;
V x_1927 = default;
V z_1929 = default;
{ V _t1925 = ListOf(_a1920);
{ V _t1926 = GetIdx(_t1925, 0D);
x_1927 = _t1926; }
{ V _t1928 = GetIdx(_t1925, 1D);
z_1929 = _t1928; }
}
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis1939, int _argc1932, V j_1938, V _a1935, V _a1936, V _a1937, V[] _rest1933) => {
return Invoke(E_1902, "leaf", NewObj(10).Put("b", Arr(x_1927, ((V)(9D)), z_1929)).Put("az", ((V)((ToNum(j_1938) * 1.3)))).Put("el", ((V)(0.6))).Put("len", ((V)(5.4))).Put("wid", ((V)(3D))).Put("droop", ((V)(0.5))).Put("sh", ((V)("lance"))).Put("col", ((V)("#4f8a36"))).Put("simple", ((V)(1D))).Put("seg", ((V)(4D))).V);
}, 1, "", true));
top_1931 = Arr(x_1927, ((V)((17D + (ToNum(Call(R0_1905, V.Undef)) * 4D)))), z_1929);
Invoke(E_1902, "stem", Arr(Arr(x_1927, ((V)(9D)), z_1929), top_1931), ((V)(0.6)), ((V)(0.5)), ((V)("#4f8a36")));
Invoke(E_1902, "flower", top_1931, ((V)(3D)), GetIdx(Arr(((V)("#ff9d2a")), ((V)("#ffc23a")), ((V)("#f2732a"))), (ToNum(i_1924) % 3D)), NewObj(3).Put("n", ((V)(9D))).Put("pw", ((V)(0.34))).Put("ctr", ((V)("#a8501a"))).V);
return default;
}, 2, "", true));
return default;
}, 2, "", true))).V);
}, 0, "tire", true)).Put("cedarBed", Fn((V _arrowThis1946, int _argc1940, V _a1942, V _a1943, V _a1944, V _a1945, V[] _rest1941) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(110D))).Put("d", ((V)(64D))).Put("build", Fn((V _arrowThis1954, int _argc1947, V P_1953, V _a1950, V _a1951, V _a1952, V[] _rest1948) => {
V o_1955 = default;
o_1955 = Arr();
Invoke(Arr(Arr(((V)(0D)), ((V)(26.5)), ((V)(100D)), ((V)(4D))), Arr(((V)(0D)), ((V)((-26.5))), ((V)(100D)), ((V)(4D)))), "forEach", Fn((V _arrowThis1971, int _argc1956, V _a1958, V _a1959, V _a1960, V _a1961, V[] _rest1957) => {
V x_1964 = default;
V z_1966 = default;
V w_1968 = default;
V d_1970 = default;
{ V _t1962 = ListOf(_a1958);
{ V _t1963 = GetIdx(_t1962, 0D);
x_1964 = _t1963; }
{ V _t1965 = GetIdx(_t1962, 1D);
z_1966 = _t1965; }
{ V _t1967 = GetIdx(_t1962, 2D);
w_1968 = _t1967; }
{ V _t1969 = GetIdx(_t1962, 3D);
d_1970 = _t1969; }
}
return Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis1979, int _argc1972, V j_1978, V _a1975, V _a1976, V _a1977, V[] _rest1973) => {
return Invoke(o_1955, "push", Call(box_12, V.Undef, x_1964, ((V)((ToNum(j_1978) * 7.4))), z_1966, w_1968, ((V)(7D)), d_1970, ((V)((NumTruthy((ToNum(j_1978) % 2D)) ? "#b8693f" : "#c8794a"))), Call(wd_33, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(((V)((-48D))), ((V)(48D))), "forEach", Fn((V _arrowThis1987, int _argc1980, V x_1986, V _a1983, V _a1984, V _a1985, V[] _rest1981) => {
return Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis1995, int _argc1988, V j_1994, V _a1991, V _a1992, V _a1993, V[] _rest1989) => {
return Invoke(o_1955, "push", Call(box_12, V.Undef, x_1986, ((V)((ToNum(j_1994) * 7.4))), ((V)(0D)), ((V)(4D)), ((V)(7D)), ((V)(49D)), ((V)((NumTruthy((ToNum(j_1994) % 2D)) ? "#b8693f" : "#c8794a"))), Call(wd_33, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(o_1955, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(0D)), ((V)(92D)), ((V)(2.6)), ((V)(49D)), ((V)("#4a3020")), NewObj(2).Put("r", ((V)(1D))).Put("noOut", ((V)(1D))).V));
Invoke(Arr(((V)((-48D))), ((V)(48D))), "forEach", Fn((V _arrowThis2003, int _argc1996, V x_2002, V _a1999, V _a2000, V _a2001, V[] _rest1997) => {
return Invoke(Arr(((V)((-26.5))), ((V)(26.5))), "forEach", Fn((V _arrowThis2011, int _argc2004, V z_2010, V _a2007, V _a2008, V _a2009, V[] _rest2005) => {
return Invoke(o_1955, "push", Call(box_12, V.Undef, x_2002, ((V)(0D)), z_2010, ((V)(5D)), ((V)(23.6)), ((V)(5D)), ((V)("#9a5a32")), Call(wd_33, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "", true));
}, 1, "", true));
return o_1955;
return default;
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis2019, int _argc2012, V c_2018, V _a2015, V _a2016, V _a2017, V[] _rest2013) => {
return NewObj(3).Put("split", Call(S0_68, V.Undef, ((V)(0D)), ((V)(20.6)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(20.6)), ((V)(0D)))).Put("sw", ((V)(0.9))).V;
}, 1, "", true), Fn((V _arrowThis2028, int _argc2020, V E_2026, V c_2027, V _a2024, V _a2025, V[] _rest2021) => {
V R0_2029 = default;
V T_2030 = default;
R0_2029 = Call(R_1078, V.Undef);
Invoke(Arr(((V)((-32D))), ((V)((-14D)))), "forEach", Fn((V _arrowThis2039, int _argc2031, V x_2037, V i_2038, V _a2035, V _a2036, V[] _rest2032) => {
return Call(lettuce_63, V.Undef, E_2026, x_2037, ((V)(20.6)), ((V)((8D - (ToNum(i_2038) * 14D)))), ((V)(1D)), R0_2029, (Truthy(i_2038) ? ((V)("#8fc23a")) : V.Null));
}, 2, "", true));
Invoke(Arr(((V)(2D)), ((V)(10D)), ((V)(18D))), "forEach", Fn((V _arrowThis2048, int _argc2040, V x_2046, V i_2047, V _a2044, V _a2045, V[] _rest2041) => {
return Call(carrot_64, V.Undef, E_2026, x_2046, ((V)(20.6)), ((V)(((ToNum(i_2047) - 1D) * 12D))), ((V)(1D)), R0_2029);
}, 2, "", true));
T_2030 = Arr(Arr(((V)(34D)), ((V)(20.6)), ((V)(0D))), Arr(((V)(34D)), ((V)(34D)), ((V)(0D))), Arr(((V)(34D)), ((V)(48D)), ((V)(1D))));
Invoke(E_2026, "stem", T_2030, ((V)(1.2)), ((V)(0.8)), ((V)("#4f8a36")));
Call(rep_22, V.Undef, ((V)(10D)), Fn((V _arrowThis2056, int _argc2049, V i_2055, V _a2052, V _a2053, V _a2054, V[] _rest2050) => {
return Invoke(E_2026, "leaf", NewObj(10).Put("b", GetIdx(T_2030, (1D + (ToNum(i_2055) % 2D)))).Put("az", ((V)((ToNum(i_2055) * 1.3)))).Put("el", ((V)(0.3))).Put("len", ((V)(8D))).Put("wid", ((V)(3.6))).Put("droop", ((V)(0.5))).Put("sh", ((V)("lance"))).Put("col", ((V)("#4a8a34"))).Put("vein", ((V)(1D))).Put("seg", ((V)(5D))).V);
}, 1, "", true));
Invoke(Arr(Arr(((V)(30D)), ((V)(36D)), ((V)(5D))), Arr(((V)(38D)), ((V)(30D)), ((V)(4D))), Arr(((V)(36D)), ((V)(42D)), ((V)((-4D)))), Arr(((V)(30D)), ((V)(28D)), ((V)((-3D))))), "forEach", Fn((V _arrowThis2064, int _argc2057, V P_2063, V _a2060, V _a2061, V _a2062, V[] _rest2058) => {
return Invoke(E_2026, "blob", P_2063, ((V)(2.6)), ((V)("#d9363b")), NewObj(2).Put("shine", ((V)(1D))).Put("db", ((V)(4D))).V);
}, 1, "", true));
Invoke(Arr(((V)(26D)), ((V)(38D)), ((V)(50D))), "forEach", Fn((V _arrowThis2073, int _argc2065, V y_2071, V i_2072, V _a2069, V _a2070, V[] _rest2066) => {
V g_2074 = default;
V k_2075 = default;
g_2074 = Invoke(c_2027, "p", ((V)(34D)), y_2071, ((V)(0D)));
k_2075 = Get(c_2027, "k");
Invoke(E_2026, "add", Call(dep_44, V.Undef, ((V)(34D)), y_2071, ((V)(8D))), ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_20, V.Undef, GetIdx(g_2074, 0D))).S("\" cy=\"").V(Call(f1_20, V.Undef, GetIdx(g_2074, 1D))).S("\" rx=\"").N((ToNum(Call(f1_20, V.Undef, ((V)((9D - (ToNum(i_2072) * 1.5)))))) * ToNum(k_2075))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((((9D - (ToNum(i_2072) * 1.5)) * 0.45) * ToNum(k_2075)))))).S("\" fill=\"none\" stroke=\"#9aa3a8\" stroke-width=\"0.6\"/>").End())));
return default;
}, 2, "", true));
return default;
}, 2, "", true))).V);
}, 0, "cedarBed", true)).Put("tower", Fn((V _arrowThis2082, int _argc2076, V _a2078, V _a2079, V _a2080, V _a2081, V[] _rest2077) => {
return Call(PT_67, V.Undef, NewObj(4).Put("w", ((V)(60D))).Put("d", ((V)(60D))).Put("build", Fn((V _arrowThis2090, int _argc2083, V P_2089, V _a2086, V _a2087, V _a2088, V[] _rest2084) => {
return new ArrBuilder().Spread(Call(potT_52, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(14D)), ((V)("#c8693f")), NewObj(2).Put("base", ((V)(0.8))).Put("lip", ((V)(3D))).V)).Spread(Call(lift_53, V.Undef, Call(potT_52, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(15D)), ((V)(13D)), ((V)("#c8693f")), NewObj(2).Put("base", ((V)(0.8))).Put("lip", ((V)(3D))).V), ((V)(14D)))).Spread(Call(lift_53, V.Undef, Call(potT_52, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(9D)), ((V)(12D)), ((V)("#c8693f")), NewObj(2).Put("base", ((V)(0.8))).Put("lip", ((V)(2.4))).V), ((V)(27D)))).V;
}, 1, "build", true)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis2098, int _argc2091, V c_2097, V _a2094, V _a2095, V _a2096, V[] _rest2092) => {
return NewObj(3).Put("split", Call(S0_68, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(14D)), ((V)(0D)))).Put("sw", ((V)(0.7))).V;
}, 1, "", true), Fn((V _arrowThis2106, int _argc2099, V E_2105, V _a2102, V _a2103, V _a2104, V[] _rest2100) => {
V R0_2107 = default;
R0_2107 = Call(R_1078, V.Undef);
Call(rep_22, V.Undef, ((V)(10D)), Fn((V _arrowThis2115, int _argc2108, V i_2114, V _a2111, V _a2112, V _a2113, V[] _rest2109) => {
double a_2116 = 0;
V P_2117 = default;
a_2116 = (((ToNum(i_2114) / 10D) * 2D) * PI_38);
P_2117 = Arr(((V)((FdLibm.Cos(a_2116) * 18D))), ((V)(14.6)), ((V)((FdLibm.Sin(a_2116) * 18D))));
if (NumTruthy((ToNum(i_2114) % 2D))) {
Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis2125, int _argc2118, V j_2124, V _a2121, V _a2122, V _a2123, V[] _rest2119) => {
return Invoke(E_2105, "leaf", NewObj(10).Put("b", P_2117).Put("az", ((V)((a_2116 + ((ToNum(j_2124) - 1D) * 0.7))))).Put("el", ((V)(0.2))).Put("len", ((V)(5D))).Put("wid", ((V)(4D))).Put("droop", ((V)(0.6))).Put("sh", ((V)("oval"))).Put("col", ((V)("#3f8a34"))).Put("vein", ((V)(1D))).Put("seg", ((V)(4D))).V);
}, 1, "", true));
Invoke(E_2105, "stem", Arr(P_2117, Arr(((V)((ToNum(GetIdx(P_2117, 0D)) * 1.25))), ((V)(8D)), ((V)((ToNum(GetIdx(P_2117, 2D)) * 1.25))))), ((V)(0.4)), ((V)(0.3)), ((V)("#5a8a3a")));
Invoke(E_2105, "blob", Arr(((V)((ToNum(GetIdx(P_2117, 0D)) * 1.27))), ((V)(5.4)), ((V)((ToNum(GetIdx(P_2117, 2D)) * 1.27)))), ((V)(2.2)), ((V)("#d9283b")), NewObj(3).Put("sx", ((V)(0.85))).Put("shine", ((V)(1D))).Put("db", ((V)(3D))).V);
} else {
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis2133, int _argc2126, V j_2132, V _a2129, V _a2130, V _a2131, V[] _rest2127) => {
return Invoke(E_2105, "leaf", NewObj(10).Put("b", P_2117).Put("az", ((V)((a_2116 + ((ToNum(j_2132) - 2D) * 0.4))))).Put("el", ((V)(0.9))).Put("len", ((V)(8D))).Put("wid", ((V)(1D))).Put("droop", ((V)(0.2))).Put("sh", ((V)("needle"))).Put("col", ((V)("#5a7a4a"))).Put("simple", ((V)(1D))).Put("seg", ((V)(3D))).V);
}, 1, "", true));
}
return default;
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis2141, int _argc2134, V i_2140, V _a2137, V _a2138, V _a2139, V[] _rest2135) => {
double a_2142 = 0;
V P_2143 = default;
a_2142 = ((((ToNum(i_2140) / 6D) * 2D) * PI_38) + 0.4);
P_2143 = Arr(((V)((FdLibm.Cos(a_2142) * 11D))), ((V)(27.6)), ((V)((FdLibm.Sin(a_2142) * 11D))));
Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis2151, int _argc2144, V j_2150, V _a2147, V _a2148, V _a2149, V[] _rest2145) => {
return Invoke(E_2105, "leaf", NewObj(10).Put("b", P_2143).Put("az", ((V)((a_2142 + ((ToNum(j_2150) - 1D) * 0.8))))).Put("el", ((V)(0.4))).Put("len", ((V)(5.6))).Put("wid", ((V)(3.6))).Put("droop", ((V)(0.4))).Put("sh", ((V)("oval"))).Put("col", ((V)("#5ab83a"))).Put("gloss", ((V)(1D))).Put("seg", ((V)(4D))).V);
}, 1, "", true));
return default;
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(9D)), Fn((V _arrowThis2159, int _argc2152, V i_2158, V _a2155, V _a2156, V _a2157, V[] _rest2153) => {
return Invoke(E_2105, "leaf", NewObj(10).Put("b", Arr(((V)(0D)), ((V)(39.6)), ((V)(0D)))).Put("az", ((V)((ToNum(i_2158) * 0.7)))).Put("el", ((V)(1D))).Put("len", ((V)(9D))).Put("wid", ((V)(1.6))).Put("droop", ((V)(0.15))).Put("sh", ((V)("needle"))).Put("col", ((V)("#4a6a3a"))).Put("simple", ((V)(1D))).Put("seg", ((V)(4D))).V);
}, 1, "", true));
Invoke(E_2105, "flower", Arr(((V)(4D)), ((V)(30D)), ((V)(9D))), ((V)(1.6)), ((V)("#ffffff")), NewObj(2).Put("ctr", ((V)("#f2c94c"))).Put("db", ((V)(3D))).V);
return default;
}, 1, "", true))).V);
}, 0, "tower", true)).Put("parterre", Fn((V _arrowThis2166, int _argc2160, V _a2162, V _a2163, V _a2164, V _a2165, V[] _rest2161) => {
V HG_2167 = default;
V hedges_2168 = default;
HG_2167 = ((V)("#3f6a32"));
hedges_2168 = Arr(Arr(((V)((-40D))), ((V)(20D)), ((V)(30D)), ((V)(5D))), Arr(((V)(0D)), ((V)(20D)), ((V)(30D)), ((V)(5D))), Arr(((V)(40D)), ((V)(20D)), ((V)(30D)), ((V)(5D))), Arr(((V)((-40D))), ((V)((-16D))), ((V)(30D)), ((V)(5D))), Arr(((V)(40D)), ((V)((-16D))), ((V)(30D)), ((V)(5D))), Arr(((V)((-55D))), ((V)(2D)), ((V)(5D)), ((V)(31D))), Arr(((V)(55D)), ((V)(2D)), ((V)(5D)), ((V)(31D))), Arr(((V)((-25D))), ((V)(2D)), ((V)(5D)), ((V)(31D))), Arr(((V)(25D)), ((V)(2D)), ((V)(5D)), ((V)(31D))));
return NewObj(5).Put("w", ((V)(130D))).Put("d", ((V)(76D))).Put("build", Fn((V _arrowThis2176, int _argc2169, V P_2175, V _a2172, V _a2173, V _a2174, V[] _rest2170) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(124D)), ((V)(1.4)), ((V)(70D)), ((V)("#d8cdb8")), Call(pt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)));
}, 1, "build", true)).Put("layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis2184, int _argc2177, V P_2183, V _a2180, V _a2181, V _a2182, V[] _rest2178) => {
return Invoke(Invoke(hedges_2168, "map", Fn((V _arrowThis2200, int _argc2185, V _a2187, V _a2188, V _a2189, V _a2190, V[] _rest2186) => {
V x_2193 = default;
V z_2195 = default;
V w_2197 = default;
V d_2199 = default;
{ V _t2191 = ListOf(_a2187);
{ V _t2192 = GetIdx(_t2191, 0D);
x_2193 = _t2192; }
{ V _t2194 = GetIdx(_t2191, 1D);
z_2195 = _t2194; }
{ V _t2196 = GetIdx(_t2191, 2D);
w_2197 = _t2196; }
{ V _t2198 = GetIdx(_t2191, 3D);
d_2199 = _t2198; }
}
return Call(box_12, V.Undef, x_2193, ((V)(1.4)), z_2195, w_2197, ((V)(9D)), d_2199, HG_2167, NewObj(4).Put("r", ((V)(2.4))).Put("bev", ((V)(1.6))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V);
}, 1, "", true)), "concat", Arr(Call(ball_14, V.Undef, ((V)(0D)), ((V)(1.4)), ((V)(2D)), ((V)(6D)), HG_2167, NewObj(5).Put("sy", ((V)(1.4))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).Put("k", ((V)(6D))).Put("n", ((V)(14D))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis2209, int _argc2201, V p_2207, V s_2208, V _a2205, V _a2206, V[] _rest2202) => {
return Invoke(H3_21, "tex", s_2208, Arr(Arr(((V)("fleaf")), ((V)(0.75)))));
}, 2, "wrap", true)).V)).Put("fx", Call(FL_51, V.Undef, Fn((V _arrowThis2217, int _argc2210, V c_2216, V _a2213, V _a2214, V _a2215, V[] _rest2211) => {
return NewObj(3).Put("split", Call(S0_68, V.Undef, ((V)(0D)), ((V)(10D)), ((V)((-12D))))).Put("piv", Arr(((V)(0D)), ((V)(1D)), ((V)((-28D))))).Put("sw", ((V)(0.3))).V;
}, 1, "", true), Fn((V _arrowThis2226, int _argc2218, V E_2224, V c_2225, V _a2222, V _a2223, V[] _rest2219) => {
V R0_2227 = default;
V ap_2228 = default;
V rp_2229 = default;
R0_2227 = Call(R_1078, V.Undef);
Set(E_2224, "defs", ((V)("<pattern id=\"fleaf\" width=\"3.1\" height=\"2.7\" patternUnits=\"userSpaceOnUse\"><ellipse cx=\"0.8\" cy=\"0.7\" rx=\"0.75\" ry=\"0.42\" fill=\"#8fc86a\" opacity=\"0.45\" transform=\"rotate(-25 0.8 0.7)\"/><ellipse cx=\"2.3\" cy=\"1.9\" rx=\"0.75\" ry=\"0.42\" fill=\"#1f3a1a\" opacity=\"0.3\" transform=\"rotate(30 2.3 1.9)\"/><ellipse cx=\"1.6\" cy=\"2.4\" rx=\"0.5\" ry=\"0.3\" fill=\"#6fae46\" opacity=\"0.4\"/></pattern>")));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2237, int _argc2230, V sg_2236, V _a2233, V _a2234, V _a2235, V[] _rest2231) => {
return Invoke(E_2224, "stem", Arr(Arr(((V)((ToNum(sg_2236) * 22D))), ((V)(1D)), ((V)((-30D)))), Arr(((V)((ToNum(sg_2236) * 22D))), ((V)(52D)), ((V)((-30D))))), ((V)(1.2)), ((V)(1.2)), ((V)("#2c2d31")));
}, 1, "", true));
ap_2228 = Call(rep_22, V.Undef, ((V)(13D)), Fn((V _arrowThis2245, int _argc2238, V i_2244, V _a2241, V _a2242, V _a2243, V[] _rest2239) => {
double a_2246 = 0;
a_2246 = (PI_38 - ((ToNum(i_2244) * PI_38) / 12D));
return Arr(((V)((FdLibm.Cos(a_2246) * 22D))), ((V)((52D + (FdLibm.Sin(a_2246) * 16D)))), ((V)((-30D))));
return default;
}, 1, "", true));
Invoke(E_2224, "stem", ap_2228, ((V)(1.2)), ((V)(1.2)), ((V)("#2c2d31")));
rp_2229 = Invoke(ap_2228, "concat", Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis2254, int _argc2247, V i_2253, V _a2250, V _a2251, V _a2252, V[] _rest2248) => {
return Arr(((V)((-22D))), ((V)((8D + (ToNum(i_2253) * 8D)))), ((V)((-30D))));
}, 1, "", true)), Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis2262, int _argc2255, V i_2261, V _a2258, V _a2259, V _a2260, V[] _rest2256) => {
return Arr(((V)(22D)), ((V)((8D + (ToNum(i_2261) * 8D)))), ((V)((-30D))));
}, 1, "", true)));
Invoke(rp_2229, "forEach", Fn((V _arrowThis2271, int _argc2263, V P_2269, V i_2270, V _a2267, V _a2268, V[] _rest2264) => {
Invoke(E_2224, "clump", Arr(GetIdx(P_2269, 0D), GetIdx(P_2269, 1D), Add(GetIdx(P_2269, 2D), ((V)(1D)))), ((V)(4D)), ((V)(3.4)), ((V)(2.6)), ((V)(7D)), NewObj(5).Put("R", R0_2227).Put("cols", Arr(((V)("#3f7a2e")), ((V)("#4f8a36")))).Put("len", ((V)(3D))).Put("wid", ((V)(2D))).Put("droop", ((V)(0.2))).V);
if (((ToNum(i_2270) % 2D) == 0D)) {
Call(rose_65, V.Undef, E_2224, Arr(Add(GetIdx(P_2269, 0D), ((V)(((ToNum(Call(R0_2227, V.Undef)) - 0.5) * 3D)))), Add(GetIdx(P_2269, 1D), ((V)(1D))), Add(GetIdx(P_2269, 2D), ((V)(3D)))), ((V)(1D)), ((V)((NumTruthy((ToNum(i_2270) % 4D)) ? "#c8243a" : "#e94a6a"))));
}
return default;
}, 2, "", true));
return default;
}, 2, "", true))).V;
return default;
}, 0, "parterre", true)).Put("orchidIsles", Fn((V _arrowThis2278, int _argc2272, V _a2274, V _a2275, V _a2276, V _a2277, V[] _rest2273) => {
return NewObj(5).Put("w", ((V)(100D))).Put("d", ((V)(50D))).Put("build", Fn((V _arrowThis2286, int _argc2279, V P_2285, V _a2282, V _a2283, V _a2284, V[] _rest2280) => {
return new ArrBuilder().Spread(Call(potT_52, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(9D)), ((V)(12D)), ((V)("#f4f1ea")), NewObj(3).Put("mat", ((V)("cer"))).Put("base", ((V)(0.82))).Put("lip", ((V)(2D))).V)).Spread(Invoke(Arr(((V)((-34D))), ((V)(34D))), "map", Fn((V _arrowThis2294, int _argc2287, V x_2293, V _a2290, V _a2291, V _a2292, V[] _rest2288) => {
return Call(cyl_13, V.Undef, x_2293, ((V)(0D)), ((V)((-4D))), ((V)(8D)), ((V)(2.4)), ((V)("#2c2d31")), Call(mt_32, V.Undef, NewObj(1).Put("n", ((V)(16D))).V));
}, 1, "", true))).Spread(Invoke(Arr(((V)((-34D))), ((V)(34D))), "map", Fn((V _arrowThis2302, int _argc2295, V x_2301, V _a2298, V _a2299, V _a2300, V[] _rest2296) => {
return Call(cyl_13, V.Undef, x_2301, ((V)(2.4)), ((V)((-4D))), ((V)(6D)), ((V)(0.6)), ((V)("#6ac8ff")), Call(em_37, V.Undef, NewObj(1).Put("n", ((V)(14D))).V));
}, 1, "", true))).V;
}, 1, "build", true)).Put("layers", Invoke(Arr(((V)((-34D))), ((V)(34D))), "map", Fn((V _arrowThis2311, int _argc2303, V x_2309, V i_2310, V _a2307, V _a2308, V[] _rest2304) => {
return NewObj(2).Put("build", Fn((V _arrowThis2319, int _argc2312, V P_2318, V _a2315, V _a2316, V _a2317, V[] _rest2313) => {
return Arr(Call(ball_14, V.Undef, x_2309, ((V)(16D)), ((V)((-4D))), ((V)(10D)), ((V)("#7a6a5a")), NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(6D))).Put("n", ((V)(14D))).V), Call(ball_14, V.Undef, x_2309, ((V)(10D)), ((V)((-4D))), ((V)(6D)), ((V)("#6a5a4a")), NewObj(2).Put("k", ((V)(5D))).Put("n", ((V)(10D))).V), Call(ball_14, V.Undef, x_2309, ((V)(25.6)), ((V)((-4D))), ((V)(9.4)), ((V)("#4f8a36")), NewObj(3).Put("sy", ((V)(0.14))).Put("k", ((V)(3D))).Put("n", ((V)(14D))).V));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis2328, int _argc2320, V p_2326, V s_2327, V _a2324, V _a2325, V[] _rest2321) => {
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_30, V.Undef, ((V)("translate")), ((V)("0 0;0 -3.6;0 0")), Add(((V)(3.6)), i_2310), ((V)(((-ToNum(i_2310)) * 1.3))))).V(s_2327).S("</g>").End()));
}, 2, "wrap", true)).V;
}, 2, "", true))).Put("fx", Fn((V _arrowThis2336, int _argc2329, V c_2335, V _a2332, V _a2333, V _a2334, V[] _rest2330) => {
V E_2337 = default;
V o_2338 = default;
E_2337 = New(Flora_49, c_2335, NewObj(3).Put("split", Call(dep_44, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)))).Put("piv", Arr(((V)(0D)), ((V)(12D)), ((V)(0D)))).Put("sw", ((V)(0.6))).V);
Call(orchid_66, V.Undef, E_2337, ((V)(0D)), ((V)(12.6)), ((V)(0D)), ((V)(1D)), Call(R_1078, V.Undef));
o_2338 = Invoke(E_2337, "out");
Invoke(Arr(((V)((-34D))), ((V)(34D))), "forEach", Fn((V _arrowThis2347, int _argc2339, V x_2345, V i_2346, V _a2343, V _a2344, V[] _rest2340) => {
V E2_2348 = default;
V o2_2349 = default;
E2_2348 = New(Flora_49, c_2335, NewObj(0).V);
Call(bonsai_58, V.Undef, E2_2348, x_2345, ((V)(27D)), ((V)((-4D))), ((V)(0.55)), Call(R_1078, V.Undef));
o2_2349 = Invoke(E2_2348, "out");
OpSet(o_2338, "defs", 0, Get(o2_2349, "defs"));
OpSet(o_2338, "front", 0, ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_30, V.Undef, ((V)("translate")), ((V)("0 0;0 -3.6;0 0")), Add(((V)(3.6)), i_2346), ((V)(((-ToNum(i_2346)) * 1.3))))).V(Get(o2_2349, "front")).S("</g>").End())));
Set(o_2338, "bb", Arr(((V)(Min(ToNum(GetIdx(Get(o_2338, "bb"), 0D)), ToNum(GetIdx(Get(o2_2349, "bb"), 0D))))), ((V)(Min(ToNum(GetIdx(Get(o_2338, "bb"), 1D)), ToNum(GetIdx(Get(o2_2349, "bb"), 1D))))), ((V)(Max(ToNum(GetIdx(Get(o_2338, "bb"), 2D)), ToNum(GetIdx(Get(o2_2349, "bb"), 2D))))), ((V)(Max(ToNum(GetIdx(Get(o_2338, "bb"), 3D)), ToNum(GetIdx(Get(o2_2349, "bb"), 3D)))))));
return default;
}, 2, "", true));
return o_2338;
return default;
}, 1, "fx", true)).V;
}, 0, "orchidIsles", true)).V;
return Call((GetK(recipes_1079, v_1077) is var _t2350 && Truthy(_t2350) ? _t2350 : Get(recipes_1079, "snake")), V.Undef);
return default;
}, 1, "", true));
PL_69 = Fn((V _arrowThis2359, int _argc2351, V pl_2357, V ex_2358, V _a2355, V _a2356, V[] _rest2352) => {
return Object_assign(NewObj(2).Put("spec", ((V)("flora"))).Put("sx", Object_assign(NewObj(1).Put("pl", pl_2357).V, (ex_2358 is var _t2360 && Truthy(_t2360) ? _t2360 : NewObj(0).V))).V);
}, 2, "", true);
Object_assign(Get(RD_8, "SET3"), NewObj(20).Put("LIV-020", Call(PL_69, V.Undef, ((V)("pothos")))).Put("LIV-040", Call(PL_69, V.Undef, ((V)("snake")))).Put("LIV-060", Call(PL_69, V.Undef, ((V)("fiddle")))).Put("LIV-080", Call(PL_69, V.Undef, ((V)("bonsaiOlive")))).Put("LIV-100", Object_assign(Call(PL_69, V.Undef, ((V)("terrarium"))), NewObj(1).Put("live", ((V)("Levitating"))).V)).Put("BTH-017", Call(PL_69, V.Undef, ((V)("fern")), NewObj(1).Put("faux", ((V)(1D))).V)).Put("BTH-037", Call(PL_69, V.Undef, ((V)("euca")))).Put("BTH-057", Call(PL_69, V.Undef, ((V)("bambooFern")))).Put("BTH-077", Object_assign(Call(PL_69, V.Undef, ((V)("mossWall"))), NewObj(1).Put("live", ((V)("Trickling water"))).V)).Put("BTH-097", Object_assign(Call(PL_69, V.Undef, ((V)("koi"))), NewObj(1).Put("live", ((V)("Koi swim"))).V)).Put("YRD-011", Call(PL_69, V.Undef, ((V)("sapling")))).Put("YRD-031", Call(PL_69, V.Undef, ((V)("lemon")))).Put("YRD-051", Object_assign(Call(PL_69, V.Undef, ((V)("cherry"))), NewObj(1).Put("live", ((V)("Falling petals"))).V)).Put("YRD-071", Call(PL_69, V.Undef, ((V)("grove")))).Put("YRD-091", Object_assign(Call(PL_69, V.Undef, ((V)("willow"))), NewObj(1).Put("live", ((V)("Glowing"))).V)).Put("YRD-007", Call(PL_69, V.Undef, ((V)("tire")))).Put("YRD-027", Call(PL_69, V.Undef, ((V)("cedarBed")))).Put("YRD-047", Call(PL_69, V.Undef, ((V)("tower")))).Put("YRD-067", Call(PL_69, V.Undef, ((V)("parterre")))).Put("YRD-087", Object_assign(Call(PL_69, V.Undef, ((V)("orchidIsles"))), NewObj(1).Put("live", ((V)("Floating islands"))).V)).V);
Set(RD_8, "FLX", NewObj(12).Put("Flora", Flora_49).Put("FL", FL_51).Put("dep", dep_44).Put("sm", sm_50).Put("SHP", SHP_48).Put("potT", potT_52).Put("fern", fern_60).Put("euca", euca_62).Put("bamboo", bamboo_61).Put("bonsai", bonsai_58).Put("orchid", orchid_66).Put("LT", LT_43).V);
Set(RD_8, "FLORA", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
