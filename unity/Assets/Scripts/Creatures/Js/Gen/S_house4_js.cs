// house4.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house4_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
double A_8 = 0;
double SA_9 = 0;
double CA_10 = 0;
double LN_11 = 0;
V LT_12 = default;
double VW_13 = 0;
double FY0_14 = 0;
double FY1_15 = 0;
V RM_16 = default;
double SK_17 = 0;
V sAt_18 = default;
V edge0_19 = default;
V edge_20 = default;
V f1_21 = default;
V hx_22 = default;
V th_23 = default;
V shade_24 = default;
V mix_25 = default;
V dot_26 = default;
V pathOf_27 = default;
V circ_28 = default;
V ell_29 = default;
V hull_30 = default;
V ring_31 = default;
V newell_32 = default;
V area2_33 = default;
V solid_34 = default;
V box_35 = default;
V cush_36 = default;
V cyl_37 = default;
V ball_38 = default;
V slab_39 = default;
V slabX_40 = default;
V arcW_41 = default;
V disc_42 = default;
V pillowY_43 = default;
V pillowZ_44 = default;
V legs4_45 = default;
V quarters_46 = default;
V CR_47 = default;
V WH_48 = default;
V MT_49 = default;
V GOLD_50 = default;
V NEON_51 = default;
V FAB_52 = default;
V WOOD_53 = default;
V pal_54 = default;
double FS_55 = 0;
V GR_56 = default;
V gref_57 = default;
V HSL_58 = default;
V MATC_59 = default;
V matOf_60 = default;
V TEX_61 = default;
V MDEFS_62 = default;
V grads_63 = default;
V CACHE_64 = default;
V render_65 = default;
V seatXY_66 = default;
V useXY_67 = default;
V half_68 = default;
V prism_69 = default;
V prismZ_70 = default;
V CAT_71 = default;
if (_self1.IsNullish) _self1 = GlobalV;
hull_30 = Fn((V _self72, int _argc73, V pts_79, V _a76, V _a77, V _a78, V[] _rest74) => {
V p_80 = default;
V cr_81 = default;
V lo_82 = default;
V up_83 = default;
if (_self72.IsNullish) _self72 = GlobalV;
p_80 = Invoke(Invoke(pts_79, "slice"), "sort", Fn((V _arrowThis92, int _argc84, V a_90, V b_91, V _a88, V _a89, V[] _rest85) => {
return (((V)((ToNum(GetIdx(a_90, 0D)) - ToNum(GetIdx(b_91, 0D))))) is var _t93 && Truthy(_t93) ? _t93 : ((V)((ToNum(GetIdx(a_90, 1D)) - ToNum(GetIdx(b_91, 1D))))));
}, 2, "", true));
if (LtN(Get(p_80, "length"), 3D)) {
return p_80;
}
cr_81 = Fn((V _arrowThis103, int _argc94, V o_100, V a_101, V b_102, V _a99, V[] _rest95) => {
return ((V)((((ToNum(GetIdx(a_101, 0D)) - ToNum(GetIdx(o_100, 0D))) * (ToNum(GetIdx(b_102, 1D)) - ToNum(GetIdx(o_100, 1D)))) - ((ToNum(GetIdx(a_101, 1D)) - ToNum(GetIdx(o_100, 1D))) * (ToNum(GetIdx(b_102, 0D)) - ToNum(GetIdx(o_100, 0D)))))));
}, 3, "", true);
lo_82 = Arr();
up_83 = Arr();
{
foreach (V _k104 in new JsIter(p_80)) {
V q_105 = default;
q_105 = _k104;
while ((GeN(Get(lo_82, "length"), 2D) && LeN(Call(cr_81, V.Undef, GetIdx(lo_82, (ToNum(Get(lo_82, "length")) - 2D)), GetIdx(lo_82, (ToNum(Get(lo_82, "length")) - 1D)), q_105), 0D))) {
Invoke(lo_82, "pop");
}
Invoke(lo_82, "push", q_105);
}
}
{
double i_106 = 0;
i_106 = (ToNum(Get(p_80, "length")) - 1D);
while (true) {
if (!((i_106 >= 0D))) break;
V q_108 = default;
q_108 = GetIdx(p_80, i_106);
while ((GeN(Get(up_83, "length"), 2D) && LeN(Call(cr_81, V.Undef, GetIdx(up_83, (ToNum(Get(up_83, "length")) - 2D)), GetIdx(up_83, (ToNum(Get(up_83, "length")) - 1D)), q_108), 0D))) {
Invoke(up_83, "pop");
}
Invoke(up_83, "push", q_108);
i_106--;
}
}
Invoke(up_83, "pop");
Invoke(lo_82, "pop");
return Invoke(lo_82, "concat", up_83);
return default;
}, 1, "hull", false);
ring_31 = Fn((V _self109, int _argc110, V o_116, V ins_117, V sc_118, V _a115, V[] _rest111) => {
double Aa_119 = 0;
double Bb_120 = 0;
double rt_121 = 0;
double rb_122 = 0;
double S_123 = 0;
V r_124 = default;
if (_self109.IsNullish) _self109 = GlobalV;
if (SEqS(Get(o_116, "sh"), "poly")) {
V P_125 = default;
double A_126 = 0;
P_125 = Invoke(Get(o_116, "pts"), "map", Fn((V _arrowThis134, int _argc127, V p_133, V _a130, V _a131, V _a132, V[] _rest128) => {
return Arr(((V)((ToNum(GetIdx(p_133, 0D)) * ToNum(sc_118)))), ((V)((ToNum(GetIdx(p_133, 1D)) * ToNum(sc_118)))));
}, 1, "", true));
A_126 = 0D;
{
double i_135 = 0;
i_135 = 0D;
while (true) {
if (!(Lt(((V)(i_135)), Get(P_125, "length")))) break;
double j_137 = 0;
j_137 = ((i_135 + 1D) % ToNum(Get(P_125, "length")));
A_126 = (A_126 + ((ToNum(GetIdx(GetIdx(P_125, i_135), 0D)) * ToNum(GetIdx(GetIdx(P_125, j_137), 1D))) - (ToNum(GetIdx(GetIdx(P_125, j_137), 0D)) * ToNum(GetIdx(GetIdx(P_125, i_135), 1D)))));
i_135++;
}
}
if ((A_126 < 0D)) {
P_125 = Invoke(P_125, "reverse");
}
return P_125;
}
if (SEqS(Get(o_116, "sh"), "arc")) {
V N_138 = default;
V @out_139 = default;
V inn_140 = default;
N_138 = (Get(o_116, "n") is var _t141 && Truthy(_t141) ? _t141 : ((V)(6D)));
@out_139 = Arr();
inn_140 = Arr();
{
double i_142 = 0;
i_142 = 0D;
while (true) {
if (!(Le(((V)(i_142)), N_138))) break;
V t_144 = default;
t_144 = Add(Get(o_116, "a0"), ((V)((((ToNum(Get(o_116, "a1")) - ToNum(Get(o_116, "a0"))) * i_142) / ToNum(N_138)))));
Invoke(@out_139, "push", Arr(((V)((ToNum(Get(o_116, "a")) * FdLibm.Cos(ToNum(t_144))))), ((V)((ToNum(Get(o_116, "b")) * FdLibm.Sin(ToNum(t_144)))))));
Invoke(inn_140, "push", Arr(((V)(((ToNum(Get(o_116, "a")) - ToNum(Get(o_116, "th"))) * FdLibm.Cos(ToNum(t_144))))), ((V)(((ToNum(Get(o_116, "b")) - ToNum(Get(o_116, "th"))) * FdLibm.Sin(ToNum(t_144)))))));
i_142++;
}
}
return Invoke(@out_139, "concat", Invoke(inn_140, "reverse"));
}
Aa_119 = Max(0.05, ((ToNum(Get(o_116, "a")) - ToNum(ins_117)) * ToNum(sc_118)));
Bb_120 = Max(0.05, ((ToNum(Get(o_116, "b")) - ToNum(ins_117)) * ToNum(sc_118)));
if (SEqS(Get(o_116, "sh"), "el")) {
V N_145 = default;
V r_146 = default;
N_145 = (Get(o_116, "n") is var _t147 && Truthy(_t147) ? _t147 : ((V)(16D)));
r_146 = Arr();
{
double i_148 = 0;
i_148 = 0D;
while (true) {
if (!(Lt(((V)(i_148)), N_145))) break;
double t_150 = 0;
t_150 = (((i_148 / ToNum(N_145)) * 2D) * System.Math.PI);
Invoke(r_146, "push", Arr(((V)((Aa_119 * FdLibm.Cos(t_150)))), ((V)((Bb_120 * FdLibm.Sin(t_150))))));
i_148++;
}
}
return r_146;
}
rt_121 = Max(0D, Min(((ToNum((Get(o_116, "r") is var _t151 && Truthy(_t151) ? _t151 : ((V)(0D)))) - ToNum(ins_117)) * ToNum(sc_118)), Aa_119, Bb_120));
rb_122 = Max(0D, Min(((ToNum(((Get(o_116, "rb") is var _t152 && !_t152.IsNullish ? _t152 : Get(o_116, "r")) is var _t153 && !_t153.IsNullish ? _t153 : ((V)(0D)))) - ToNum(ins_117)) * ToNum(sc_118)), Aa_119, Bb_120));
S_123 = 5D;
r_124 = Arr();
Invoke(Arr(Arr(((V)(Aa_119)), ((V)(Bb_120)), ((V)(0D)), ((V)(rt_121))), Arr(((V)((-Aa_119))), ((V)(Bb_120)), ((V)(90D)), ((V)(rt_121))), Arr(((V)((-Aa_119))), ((V)((-Bb_120))), ((V)(180D)), ((V)(rb_122))), Arr(((V)(Aa_119)), ((V)((-Bb_120))), ((V)(270D)), ((V)(rb_122)))), "forEach", Fn((V _arrowThis169, int _argc154, V _a156, V _a157, V _a158, V _a159, V[] _rest155) => {
double ox_170 = 0;
double oy_171 = 0;
V cx_162 = default;
V cy_164 = default;
V a0_166 = default;
V R_168 = default;
{ V _t160 = ListOf(_a156);
{ V _t161 = GetIdx(_t160, 0D);
cx_162 = _t161; }
{ V _t163 = GetIdx(_t160, 1D);
cy_164 = _t163; }
{ V _t165 = GetIdx(_t160, 2D);
a0_166 = _t165; }
{ V _t167 = GetIdx(_t160, 3D);
R_168 = _t167; }
}
ox_170 = (ToNum(cx_162) - (Sign(ToNum(cx_162)) * ToNum(R_168)));
oy_171 = (ToNum(cy_164) - (Sign(ToNum(cy_164)) * ToNum(R_168)));
{
double i_172 = 0;
i_172 = 0D;
while (true) {
if (!((i_172 <= S_123))) break;
double t_174 = 0;
t_174 = ((ToNum(Add(a0_166, ((V)(((90D * i_172) / S_123))))) * System.Math.PI) / 180D);
Invoke(r_124, "push", Arr(((V)((ox_170 + (ToNum(R_168) * FdLibm.Cos(t_174))))), ((V)((oy_171 + (ToNum(R_168) * FdLibm.Sin(t_174)))))));
i_172++;
}
}
return default;
}, 1, "", true));
return r_124;
return default;
}, 3, "ring", false);
newell_32 = Fn((V _self175, int _argc176, V q_182, V _a179, V _a180, V _a181, V[] _rest177) => {
V n_183 = default;
if (_self175.IsNullish) _self175 = GlobalV;
n_183 = Arr(((V)(0D)), ((V)(0D)), ((V)(0D)));
{
double i_184 = 0;
i_184 = 0D;
while (true) {
if (!(Lt(((V)(i_184)), Get(q_182, "length")))) break;
V a_186 = default;
V b_187 = default;
a_186 = GetIdx(q_182, i_184);
b_187 = GetIdx(q_182, ((i_184 + 1D) % ToNum(Get(q_182, "length"))));
OpSetK(n_183, ((V)(0D)), 0, ((V)(((ToNum(GetIdx(a_186, 1D)) - ToNum(GetIdx(b_187, 1D))) * ToNum(Add(GetIdx(a_186, 2D), GetIdx(b_187, 2D)))))));
OpSetK(n_183, ((V)(1D)), 0, ((V)(((ToNum(GetIdx(a_186, 2D)) - ToNum(GetIdx(b_187, 2D))) * ToNum(Add(GetIdx(a_186, 0D), GetIdx(b_187, 0D)))))));
OpSetK(n_183, ((V)(2D)), 0, ((V)(((ToNum(GetIdx(a_186, 0D)) - ToNum(GetIdx(b_187, 0D))) * ToNum(Add(GetIdx(a_186, 1D), GetIdx(b_187, 1D)))))));
i_184++;
}
}
return n_183;
return default;
}, 1, "newell", false);
solid_34 = Fn((V _self188, int _argc189, V o_195, V _a192, V _a193, V _a194, V[] _rest190) => {
V ax_196 = default;
V cu_197 = default;
V cv_198 = default;
V yw_199 = default;
double cy_200 = 0;
double sy_201 = 0;
V m3_202 = default;
V n3_203 = default;
V axis_204 = default;
V R2_205 = default;
V R3_206 = default;
V faces_207 = default;
double l_208 = 0;
if (_self188.IsNullish) _self188 = GlobalV;
ax_196 = (Get(o_195, "ax") is var _t209 && Truthy(_t209) ? _t209 : ((V)("y")));
cu_197 = GetIdx(Get(o_195, "c"), 0D);
cv_198 = GetIdx(Get(o_195, "c"), 1D);
yw_199 = (Get(o_195, "yaw") is var _t210 && Truthy(_t210) ? _t210 : ((V)(0D)));
cy_200 = FdLibm.Cos(ToNum(yw_199));
sy_201 = FdLibm.Sin(ToNum(yw_199));
m3_202 = Fn((V _arrowThis220, int _argc211, V u_217, V v_218, V t_219, V _a216, V[] _rest212) => {
return (SEqS(ax_196, "y") ? Arr(((V)((ToNum(Add(cu_197, ((V)((ToNum(u_217) * cy_200))))) - (ToNum(v_218) * sy_201)))), t_219, Add(Add(cv_198, ((V)((ToNum(u_217) * sy_201)))), ((V)((ToNum(v_218) * cy_200))))) : (SEqS(ax_196, "z") ? Arr(Add(cu_197, u_217), Add(cv_198, v_218), t_219) : Arr(t_219, Add(cv_198, v_218), Add(cu_197, u_217))));
}, 3, "", true);
n3_203 = Fn((V _arrowThis229, int _argc221, V u_227, V v_228, V _a225, V _a226, V[] _rest222) => {
return (SEqS(ax_196, "y") ? Arr(((V)(((ToNum(u_227) * cy_200) - (ToNum(v_228) * sy_201)))), ((V)(0D)), ((V)(((ToNum(u_227) * sy_201) + (ToNum(v_228) * cy_200))))) : (SEqS(ax_196, "z") ? Arr(u_227, v_228, ((V)(0D))) : Arr(((V)(0D)), v_228, u_227)));
}, 2, "", true);
axis_204 = (SEqS(ax_196, "y") ? Arr(((V)(0D)), ((V)(1D)), ((V)(0D))) : (SEqS(ax_196, "z") ? Arr(((V)(0D)), ((V)(0D)), ((V)(1D))) : Arr(((V)(1D)), ((V)(0D)), ((V)(0D)))));
R2_205 = Invoke(Get(o_195, "rings"), "map", Fn((V _arrowThis237, int _argc230, V r_236, V _a233, V _a234, V _a235, V[] _rest231) => {
return Call(ring_31, V.Undef, o_195, (GetIdx(r_236, 1D) is var _t238 && Truthy(_t238) ? _t238 : ((V)(0D))), (GetIdx(r_236, 2D) is var _t239 && !_t239.IsNullish ? _t239 : ((V)(1D))));
}, 1, "", true));
R3_206 = Invoke(Get(o_195, "rings"), "map", Fn((V _arrowThis248, int _argc240, V r_246, V k_247, V _a244, V _a245, V[] _rest241) => {
return Invoke(GetK(R2_205, k_247), "map", Fn((V _arrowThis260, int _argc249, V _a251, V _a252, V _a253, V _a254, V[] _rest250) => {
V u_257 = default;
V v_259 = default;
{ V _t255 = ListOf(_a251);
{ V _t256 = GetIdx(_t255, 0D);
u_257 = _t256; }
{ V _t258 = GetIdx(_t255, 1D);
v_259 = _t258; }
}
return Call(m3_202, V.Undef, u_257, v_259, GetIdx(r_246, 0D));
}, 1, "", true));
}, 2, "", true));
faces_207 = Arr();
{
double k_261 = 0;
k_261 = 0D;
while (true) {
if (!((k_261 < (ToNum(Get(R3_206, "length")) - 1D)))) break;
V a_263 = default;
V b_264 = default;
V a2_265 = default;
V b2_266 = default;
V N_267 = default;
a_263 = GetIdx(R3_206, k_261);
b_264 = GetIdx(R3_206, (k_261 + 1D));
a2_265 = GetIdx(R2_205, k_261);
b2_266 = GetIdx(R2_205, (k_261 + 1D));
N_267 = Get(a_263, "length");
{
double i_268 = 0;
i_268 = 0D;
while (true) {
if (!(Lt(((V)(i_268)), N_267))) break;
double j_270 = 0;
V q_271 = default;
V nn_272 = default;
double L_273 = 0;
double du_274 = 0;
double dv_275 = 0;
j_270 = ((i_268 + 1D) % ToNum(N_267));
q_271 = Arr(GetIdx(a_263, i_268), GetIdx(a_263, j_270), GetIdx(b_264, j_270), GetIdx(b_264, i_268));
nn_272 = Call(newell_32, V.Undef, q_271);
L_273 = Hypot(ToNum(GetIdx(nn_272, 0D)), ToNum(GetIdx(nn_272, 1D)), ToNum(GetIdx(nn_272, 2D)));
if ((L_273 < 0.02)) {
goto _cont269;
}
nn_272 = Invoke(nn_272, "map", Fn((V _arrowThis283, int _argc276, V v_282, V _a279, V _a280, V _a281, V[] _rest277) => {
return ((V)((ToNum(v_282) / L_273)));
}, 1, "", true));
du_274 = (ToNum(GetIdx(GetIdx(a2_265, j_270), 0D)) - ToNum(GetIdx(GetIdx(a2_265, i_268), 0D)));
dv_275 = (ToNum(GetIdx(GetIdx(a2_265, j_270), 1D)) - ToNum(GetIdx(GetIdx(a2_265, i_268), 1D)));
if (((System.Math.Abs(du_274) + System.Math.Abs(dv_275)) < 0.000001)) {
du_274 = (ToNum(GetIdx(GetIdx(b2_266, j_270), 0D)) - ToNum(GetIdx(GetIdx(b2_266, i_268), 0D)));
dv_275 = (ToNum(GetIdx(GetIdx(b2_266, j_270), 1D)) - ToNum(GetIdx(GetIdx(b2_266, i_268), 1D)));
}
if (LtN(Call(dot_26, V.Undef, nn_272, Call(n3_203, V.Undef, ((V)(dv_275)), ((V)((-du_274))))), 0D)) {
nn_272 = Invoke(nn_272, "map", Fn((V _arrowThis291, int _argc284, V v_290, V _a287, V _a288, V _a289, V[] _rest285) => {
return ((V)((-ToNum(v_290))));
}, 1, "", true));
}
Invoke(faces_207, "push", NewObj(2).Put("q", q_271).Put("n", nn_272).V);
_cont269: ;
i_268++;
}
}
k_261++;
}
}
if (GtN(Call(area2_33, V.Undef, GetIdx(R2_205, 0D)), 0.5)) {
Invoke(faces_207, "push", NewObj(3).Put("q", GetIdx(R3_206, 0D)).Put("n", Invoke(axis_204, "map", Fn((V _arrowThis299, int _argc292, V v_298, V _a295, V _a296, V _a297, V[] _rest293) => {
return ((V)((-ToNum(v_298))));
}, 1, "", true))).Put("cap", ((V)(1D))).V);
}
l_208 = (ToNum(Get(R2_205, "length")) - 1D);
if (GtN(Call(area2_33, V.Undef, GetIdx(R2_205, l_208)), 0.5)) {
Invoke(faces_207, "push", NewObj(3).Put("q", GetIdx(R3_206, l_208)).Put("n", axis_204).Put("cap", ((V)(2D))).V);
}
return NewObj(17).Put("faces", faces_207).Put("pts", InvokeSpread(Arr(), "concat", new ArrBuilder().Spread(R3_206).V)).Put("col", Get(o_195, "col")).Put("soft", Get(o_195, "soft")).Put("shine", Get(o_195, "shine")).Put("org", Get(o_195, "org")).Put("emit", Get(o_195, "emit")).Put("cv", ((V)(((SEqS(Get(o_195, "sh"), "arc") || SEqN(Get(o_195, "cv"), 0D)) ? 0D : 1D)))).Put("zb", (Get(o_195, "zb") is var _t300 && Truthy(_t300) ? _t300 : ((V)(0D)))).Put("noOut", Get(o_195, "noOut")).Put("part", Get(o_195, "part")).Put("op", Get(o_195, "op")).Put("mat", Get(o_195, "mat")).Put("scr", (Truthy(Get(o_195, "scr")) ? NewObj(1).Put("r", (Get(o_195, "r") is var _t301 && Truthy(_t301) ? _t301 : ((V)(0D)))).V : V.Null)).Put("tex", Get(o_195, "tex")).Put("texTop", Get(o_195, "texTop")).Put("texO", Get(o_195, "texO")).V;
return default;
}, 1, "solid", false);
gref_57 = Fn((V _self302, int _argc303, V t_309, V col_310, V set_311, V _a308, V[] _rest304) => {
V id_312 = default;
if (_self302.IsNullish) _self302 = GlobalV;
id_312 = ((V)(JsStrBuf.Begin().S("h").V(t_309).V(Invoke(col_310, "replace", ((V)("#")), ((V)("")))).End()));
if (!(Truthy(Invoke(GR_56, "has", id_312)))) {
Invoke(GR_56, "set", id_312, (SEqS(t_309, "S") ? NewObj(4).Put("id", id_312).Put("t", t_309).Put("c0", Call(shade_24, V.Undef, col_310, ((V)(1.1)))).Put("c1", Call(shade_24, V.Undef, col_310, ((V)(0.7)))).V : (SEqS(t_309, "T") ? NewObj(4).Put("id", id_312).Put("t", t_309).Put("c0", Call(shade_24, V.Undef, col_310, ((V)(1.22)))).Put("c1", Call(shade_24, V.Undef, col_310, ((V)(1.02)))).V : NewObj(4).Put("id", id_312).Put("t", t_309).Put("c0", Call(shade_24, V.Undef, col_310, ((V)(1.3)))).Put("c1", Call(shade_24, V.Undef, col_310, ((V)(0.66)))).V)));
}
Invoke(set_311, "add", id_312);
return ((V)(JsStrBuf.Begin().S("url(#").V(id_312).S(")").End()));
return default;
}, 3, "gref", false);
render_65 = Fn((V _self313, int _argc314, V t_320, V rot_321, V ci_322, V v_323, V[] _rest315) => {
V key_324 = default;
V hit_325 = default;
V D_326 = default;
V sol_327 = default;
double tr_328 = 0;
double c_329 = 0;
double s_330 = 0;
V Z_331 = default;
V Rn_332 = default;
V Rf_333 = default;
V R_334 = default;
V pr_335 = default;
V gs_336 = default;
V hi_337 = default;
V sd_338 = default;
V SQ_339 = default;
double vwx_340 = 0;
double vwz_341 = 0;
V inFr_342 = default;
V KID_343 = default;
V roots_344 = default;
double nf_345 = 0;
V list_346 = default;
V @out_347 = default;
V x0_348 = default;
V y0_349 = default;
V x1_350 = default;
V y1_351 = default;
V grow_352 = default;
V FR_353 = default;
V fpR_354 = default;
V shP_355 = default;
V ftP_356 = default;
V ctP_357 = default;
V face_358 = default;
V glow_359 = default;
V G_360 = default;
V pv_361 = default;
V screen_362 = default;
V res_363 = default;
if (_self313.IsNullish) _self313 = GlobalV;
key_324 = ((V)(JsStrBuf.Begin().V(t_320).S("|").V(rot_321).S("|").V(ci_322).S("|").V((v_323 is var _t364 && Truthy(_t364) ? _t364 : ((V)("")))).End()));
hit_325 = Invoke(CACHE_64, "get", key_324);
if (Truthy(hit_325)) {
return hit_325;
}
D_326 = GetK(CAT_71, t_320);
if (!(Truthy(D_326))) {
return V.Null;
}
sol_327 = Invoke(D_326, "build", Call(pal_54, V.Undef, D_326, (ci_322 is var _t365 && Truthy(_t365) ? _t365 : ((V)(0D)))), (v_323 is var _t366 && Truthy(_t366) ? _t366 : ((V)(""))));
tr_328 = ((ToNum(rot_321) * System.Math.PI) / 180D);
c_329 = FdLibm.Cos(tr_328);
s_330 = FdLibm.Sin(tr_328);
Z_331 = (Get(D_326, "zs") is var _t367 && Truthy(_t367) ? _t367 : ((V)(1D)));
Rn_332 = Fn((V _arrowThis375, int _argc368, V p_374, V _a371, V _a372, V _a373, V[] _rest369) => {
return Arr(((V)(((ToNum(GetIdx(p_374, 0D)) * c_329) + (ToNum(GetIdx(p_374, 2D)) * s_330)))), GetIdx(p_374, 1D), ((V)((((-ToNum(GetIdx(p_374, 0D))) * s_330) + (ToNum(GetIdx(p_374, 2D)) * c_329)))));
}, 1, "", true);
Rf_333 = Fn((V _arrowThis383, int _argc376, V p_382, V _a379, V _a380, V _a381, V[] _rest377) => {
return Arr(((V)((((ToNum(GetIdx(p_382, 0D)) * c_329) + (ToNum(GetIdx(p_382, 2D)) * s_330)) * FS_55))), ((V)((ToNum(GetIdx(p_382, 1D)) * FS_55))), ((V)(((((-ToNum(GetIdx(p_382, 0D))) * s_330) + (ToNum(GetIdx(p_382, 2D)) * c_329)) * FS_55))));
}, 1, "", true);
R_334 = Fn((V _arrowThis391, int _argc384, V p_390, V _a387, V _a388, V _a389, V[] _rest385) => {
return Arr(((V)(((((ToNum(GetIdx(p_390, 0D)) * c_329) + (ToNum(GetIdx(p_390, 2D)) * s_330)) * FS_55) * ToNum(Z_331)))), ((V)(((ToNum(GetIdx(p_390, 1D)) * FS_55) * ToNum(Z_331)))), ((V)((((((-ToNum(GetIdx(p_390, 0D))) * s_330) + (ToNum(GetIdx(p_390, 2D)) * c_329)) * FS_55) * ToNum(Z_331)))));
}, 1, "", true);
pr_335 = Fn((V _arrowThis399, int _argc392, V p_398, V _a395, V _a396, V _a397, V[] _rest393) => {
return Arr(GetIdx(p_398, 0D), ((V)(((ToNum(GetIdx(p_398, 2D)) * SA_9) - (ToNum(GetIdx(p_398, 1D)) * CA_10)))));
}, 1, "", true);
gs_336 = New(G("Set"));
hi_337 = Fn((V _arrowThis409, int _argc400, V P_406, V L_407, V o_408, V _a405, V[] _rest401) => {
double a_410 = 0;
double b_411 = 0;
double cc_412 = 0;
double d_413 = 0;
double w_414 = 0;
double hh_415 = 0;
a_410 = 1000000000D;
b_411 = 1000000000D;
cc_412 = (-1000000000D);
d_413 = (-1000000000D);
Invoke(P_406, "forEach", Fn((V _arrowThis423, int _argc416, V q_422, V _a419, V _a420, V _a421, V[] _rest417) => {
a_410 = Min(a_410, ToNum(GetIdx(q_422, 0D)));
cc_412 = Max(cc_412, ToNum(GetIdx(q_422, 0D)));
b_411 = Min(b_411, ToNum(GetIdx(q_422, 1D)));
d_413 = Max(d_413, ToNum(GetIdx(q_422, 1D)));
return default;
}, 1, "", true));
w_414 = (cc_412 - a_410);
hh_415 = (d_413 - b_411);
if (((w_414 < 8D) || ((ToNum(Call(area2_33, V.Undef, P_406)) / 2D) < ((w_414 * hh_415) * 0.5)))) {
return default;
}
Invoke(L_407, "push", NewObj(5).Put("d", Call(ell_29, V.Undef, ((V)((a_410 + (w_414 * 0.36)))), ((V)((b_411 + (hh_415 * 0.32)))), ((V)((w_414 * 0.24))), ((V)((hh_415 * 0.18))))).Put("f", ((V)("url(#hiW)"))).Put("s", ((V)("none"))).Put("w", ((V)(0D))).Put("o", o_408).V);
return default;
}, 3, "", true);
sd_338 = V.Null;
if (Truthy(Get(D_326, "inside"))) {
V q_424 = default;
q_424 = Call(R_334, V.Undef, Get(D_326, "inside"));
sd_338 = ((V)(((ToNum(GetIdx(q_424, 1D)) * SA_9) + (ToNum(GetIdx(q_424, 2D)) * CA_10))));
}
SQ_339 = (Truthy((((((sd_338.IsNullish && !(Truthy(Get(D_326, "roam")))) && !(Truthy(Get(D_326, "noFront")))) ? V.True : V.False) is var _t434 && !Truthy(_t434) ? _t434 : Get(D_326, "seats")) is var _t435 && !Truthy(_t435) ? _t435 : Get(Get(D_326, "seats"), "length"))) ? Invoke(Get(D_326, "seats"), "map", Fn((V _arrowThis432, int _argc425, V q_431, V _a428, V _a429, V _a430, V[] _rest426) => {
return NewObj(4).Put("x", Get(q_431, "x")).Put("z", Get(q_431, "z")).Put("h", Get(q_431, "h")).Put("m", ((V)((SEqS((Get(q_431, "k") is var _t433 && Truthy(_t433) ? _t433 : Get(D_326, "act")), "nap") ? 34D : 8D)))).V;
}, 1, "", true)) : V.Null);
vwx_340 = (-s_330);
vwz_341 = c_329;
inFr_342 = Fn((V _arrowThis443, int _argc436, V B_442, V _a439, V _a440, V _a441, V[] _rest437) => {
double cx_444 = 0;
double cz_445 = 0;
V q_446 = default;
double bd_447 = 0;
if ((!(Truthy(SQ_339)) || !(Truthy(B_442)))) {
return (false ? V.True : V.False);
}
cx_444 = (ToNum(Add(GetIdx(B_442, 0D), GetIdx(B_442, 1D))) / 2D);
cz_445 = (ToNum(Add(GetIdx(B_442, 4D), GetIdx(B_442, 5D))) / 2D);
q_446 = GetIdx(SQ_339, 0D);
bd_447 = 1000000000000000000D;
Invoke(SQ_339, "forEach", Fn((V _arrowThis455, int _argc448, V p_454, V _a451, V _a452, V _a453, V[] _rest449) => {
double d_456 = 0;
d_456 = (((ToNum(Get(p_454, "x")) - cx_444) * (ToNum(Get(p_454, "x")) - cx_444)) + ((ToNum(Get(p_454, "z")) - cz_445) * (ToNum(Get(p_454, "z")) - cz_445)));
if ((d_456 < bd_447)) {
bd_447 = d_456;
q_446 = p_454;
}
return default;
}, 1, "", true));
if (Lt(GetIdx(B_442, 3D), Add(Get(q_446, "h"), ((V)(6D))))) {
return (false ? V.True : V.False);
}
return ((((((vwz_341 > 0.3) && Gt(GetIdx(B_442, 4D), Add(Get(q_446, "z"), Get(q_446, "m")))) || ((vwz_341 < (-0.3)) && LtN(GetIdx(B_442, 5D), (ToNum(Get(q_446, "z")) - ToNum(Get(q_446, "m")))))) || ((vwx_340 > 0.3) && Gt(GetIdx(B_442, 0D), Add(Get(q_446, "x"), Get(q_446, "m"))))) || ((vwx_340 < (-0.3)) && LtN(GetIdx(B_442, 1D), (ToNum(Get(q_446, "x")) - ToNum(Get(q_446, "m")))))) ? V.True : V.False);
return default;
}, 1, "", true);
KID_343 = New(G("Map"));
roots_344 = Arr();
Invoke(sol_327, "forEach", Fn((V _arrowThis464, int _argc457, V S_463, V _a460, V _a461, V _a462, V[] _rest458) => {
if (Truthy((Get(S_463, "par") is var _t465 && !Truthy(_t465) ? _t465 : Invoke(sol_327, "includes", Get(S_463, "par"))))) {
if (!(Truthy(Invoke(KID_343, "has", Get(S_463, "par"))))) {
Invoke(KID_343, "set", Get(S_463, "par"), Arr());
}
Invoke(Invoke(KID_343, "get", Get(S_463, "par")), "push", S_463);
} else {
Invoke(roots_344, "push", S_463);
}
return default;
}, 1, "", true));
nf_345 = 0D;
list_346 = Invoke(roots_344, "map", Fn((V _arrowThis473, int _argc466, V S_472, V _a469, V _a470, V _a471, V[] _rest467) => {
V pts_474 = default;
V C0_475 = default;
V C1_476 = default;
V C2_477 = default;
V n_478 = default;
pts_474 = Invoke(Get(S_472, "pts"), "map", R_334);
C0_475 = ((V)(0D));
C1_476 = ((V)(0D));
C2_477 = ((V)(0D));
Invoke(pts_474, "forEach", Fn((V _arrowThis486, int _argc479, V p_485, V _a482, V _a483, V _a484, V[] _rest480) => {
C0_475 = Add(C0_475, GetIdx(p_485, 0D));
C1_476 = Add(C1_476, GetIdx(p_485, 1D));
C2_477 = Add(C2_477, GetIdx(p_485, 2D));
return default;
}, 1, "", true));
n_478 = Get(pts_474, "length");
return NewObj(3).Put("S", S_472).Put("pts", pts_474).Put("dep", Add(((V)((((ToNum(C1_476) / ToNum(n_478)) * SA_9) + ((ToNum(C2_477) / ToNum(n_478)) * CA_10)))), Get(S_472, "zb"))).V;
return default;
}, 1, "", true));
Invoke(list_346, "sort", Fn((V _arrowThis495, int _argc487, V a_493, V b_494, V _a491, V _a492, V[] _rest488) => {
return ((V)((ToNum(Get(a_493, "dep")) - ToNum(Get(b_494, "dep")))));
}, 2, "", true));
{
V n_496 = default;
double EP_497 = 0;
double wx_498 = 0;
double wz_499 = 0;
V after_500 = default;
V indeg_501 = default;
V inS_502 = default;
V done_503 = default;
V out2_504 = default;
n_496 = Get(list_346, "length");
EP_497 = 4D;
wx_498 = (-s_330);
wz_499 = c_329;
Invoke(list_346, "forEach", Fn((V _arrowThis512, int _argc505, V e_511, V _a508, V _a509, V _a510, V[] _rest506) => {
V L_513 = default;
V a_514 = default;
V b_515 = default;
double u0_516 = 0;
double u1_517 = 0;
double md_518 = 0;
L_513 = Arr(((V)(1000000000D)), ((V)((-1000000000D))), ((V)(1000000000D)), ((V)((-1000000000D))), ((V)(1000000000D)), ((V)((-1000000000D))));
Invoke(Get(Get(e_511, "S"), "pts"), "forEach", Fn((V _arrowThis526, int _argc519, V p_525, V _a522, V _a523, V _a524, V[] _rest520) => {
if (Lt(GetIdx(p_525, 0D), GetIdx(L_513, 0D))) {
SetIdx(L_513, 0D, GetIdx(p_525, 0D));
}
if (Gt(GetIdx(p_525, 0D), GetIdx(L_513, 1D))) {
SetIdx(L_513, 1D, GetIdx(p_525, 0D));
}
if (Lt(GetIdx(p_525, 1D), GetIdx(L_513, 2D))) {
SetIdx(L_513, 2D, GetIdx(p_525, 1D));
}
if (Gt(GetIdx(p_525, 1D), GetIdx(L_513, 3D))) {
SetIdx(L_513, 3D, GetIdx(p_525, 1D));
}
if (Lt(GetIdx(p_525, 2D), GetIdx(L_513, 4D))) {
SetIdx(L_513, 4D, GetIdx(p_525, 2D));
}
if (Gt(GetIdx(p_525, 2D), GetIdx(L_513, 5D))) {
SetIdx(L_513, 5D, GetIdx(p_525, 2D));
}
return default;
}, 1, "", true));
a_514 = ((V)(1000000000D));
b_515 = ((V)((-1000000000D)));
u0_516 = 1000000000D;
u1_517 = (-1000000000D);
md_518 = (-1000000000D);
Invoke(Get(e_511, "pts"), "forEach", Fn((V _arrowThis534, int _argc527, V p_533, V _a530, V _a531, V _a532, V[] _rest528) => {
double sy_535 = 0;
double dd_536 = 0;
if (Lt(GetIdx(p_533, 0D), a_514)) {
a_514 = GetIdx(p_533, 0D);
}
if (Gt(GetIdx(p_533, 0D), b_515)) {
b_515 = GetIdx(p_533, 0D);
}
sy_535 = ((ToNum(GetIdx(p_533, 2D)) * SA_9) - (ToNum(GetIdx(p_533, 1D)) * CA_10));
dd_536 = ((ToNum(GetIdx(p_533, 1D)) * SA_9) + (ToNum(GetIdx(p_533, 2D)) * CA_10));
if ((sy_535 < u0_516)) {
u0_516 = sy_535;
}
if ((sy_535 > u1_517)) {
u1_517 = sy_535;
}
if ((dd_536 > md_518)) {
md_518 = dd_536;
}
return default;
}, 1, "", true));
Set(e_511, "L", L_513);
Set(e_511, "sb", Arr(a_514, b_515, ((V)(u0_516)), ((V)(u1_517))));
Set(e_511, "md", ((V)(md_518)));
return default;
}, 1, "", true));
after_500 = Array_from(NewObj(1).Put("length", n_496).V, Fn((V _arrowThis543, int _argc537, V _a539, V _a540, V _a541, V _a542, V[] _rest538) => {
return Arr();
}, 0, "", true));
indeg_501 = Invoke(New(G("Array"), n_496), "fill", ((V)(0D)));
inS_502 = Invoke(New(G("Array"), n_496), "fill", ((V)(0D)));
{
double i_544 = 0;
i_544 = 0D;
while (true) {
if (!(Lt(((V)(i_544)), n_496))) break;
{
double j_546 = 0;
j_546 = (i_544 + 1D);
while (true) {
if (!(Lt(((V)(j_546)), n_496))) break;
V A_548 = default;
V B_549 = default;
V P_550 = default;
V Q_551 = default;
V a_552 = default;
V b_553 = default;
V ax_554 = default;
V f_555 = default;
double st_556 = 0;
A_548 = GetIdx(list_346, i_544);
B_549 = GetIdx(list_346, j_546);
P_550 = Get(A_548, "sb");
Q_551 = Get(B_549, "sb");
if ((((LtN(GetIdx(P_550, 1D), (ToNum(GetIdx(Q_551, 0D)) - 2.5)) || LtN(GetIdx(Q_551, 1D), (ToNum(GetIdx(P_550, 0D)) - 2.5))) || LtN(GetIdx(P_550, 3D), (ToNum(GetIdx(Q_551, 2D)) - 2.5))) || LtN(GetIdx(Q_551, 3D), (ToNum(GetIdx(P_550, 2D)) - 2.5)))) {
goto _cont547;
}
a_552 = Get(A_548, "L");
b_553 = Get(B_549, "L");
ax_554 = Arr(Arr(((V)(Max((ToNum(GetIdx(a_552, 2D)) - ToNum(GetIdx(b_553, 3D))), (ToNum(GetIdx(b_553, 2D)) - ToNum(GetIdx(a_552, 3D)))))), ((V)(1D)), ((V)((Gt(GetIdx(a_552, 2D), GetIdx(b_553, 2D)) ? 1D : (-1D))))));
if ((System.Math.Abs(wx_498) > 0.15)) {
Invoke(ax_554, "push", Arr(((V)(Max((ToNum(GetIdx(a_552, 0D)) - ToNum(GetIdx(b_553, 1D))), (ToNum(GetIdx(b_553, 0D)) - ToNum(GetIdx(a_552, 1D)))))), ((V)(0D)), ((V)(((Gt(GetIdx(a_552, 0D), GetIdx(b_553, 0D)) ? 1D : (-1D)) * Sign(wx_498))))));
}
if ((System.Math.Abs(wz_499) > 0.15)) {
Invoke(ax_554, "push", Arr(((V)(Max((ToNum(GetIdx(a_552, 4D)) - ToNum(GetIdx(b_553, 5D))), (ToNum(GetIdx(b_553, 4D)) - ToNum(GetIdx(a_552, 5D)))))), ((V)(0D)), ((V)(((Gt(GetIdx(a_552, 4D), GetIdx(b_553, 4D)) ? 1D : (-1D)) * Sign(wz_499))))));
}
if (Truthy((Invoke(ax_554, "some", Fn((V _arrowThis564, int _argc557, V p_563, V _a560, V _a561, V _a562, V[] _rest558) => {
return ((GtN(GetIdx(p_563, 0D), 0D) && SEqN(GetIdx(p_563, 2D), 1D)) ? V.True : V.False);
}, 1, "", true)) is var _t573 && !Truthy(_t573) ? _t573 : Invoke(ax_554, "some", Fn((V _arrowThis572, int _argc565, V p_571, V _a568, V _a569, V _a570, V[] _rest566) => {
return ((GtN(GetIdx(p_571, 0D), 0D) && SEqN(GetIdx(p_571, 2D), (-1D))) ? V.True : V.False);
}, 1, "", true))))) {
goto _cont547;
}
Invoke(ax_554, "sort", Fn((V _arrowThis582, int _argc574, V p_580, V q_581, V _a578, V _a579, V[] _rest575) => {
return ((V)((ToNum(GetIdx(q_581, 0D)) - ToNum(GetIdx(p_580, 0D)))));
}, 2, "", true));
f_555 = (GtN(GetIdx(GetIdx(ax_554, 0D), 0D), (-EP_497)) ? GetIdx(GetIdx(ax_554, 0D), 2D) : ((V)(0D)));
st_556 = (Truthy((f_555 is var _t583 && !Truthy(_t583) ? _t583 : (GtN(GetIdx(GetIdx(ax_554, 0D), 0D), 0D) ? V.True : V.False))) ? 1D : 0D);
if ((!(Truthy(f_555)) && (System.Math.Abs((ToNum(Get(A_548, "md")) - ToNum(Get(B_549, "md")))) > 1D))) {
f_555 = ((V)((Gt(Get(A_548, "md"), Get(B_549, "md")) ? 1D : (-1D))));
}
if (SEqN(f_555, 1D)) {
Invoke(GetIdx(after_500, j_546), "push", Arr(((V)(i_544)), ((V)(st_556))));
IncK(indeg_501, ((V)(i_544)), 1D, false);
OpSetK(inS_502, ((V)(i_544)), 0, ((V)(st_556)));
} else {
if (SEqN(f_555, (-1D))) {
Invoke(GetIdx(after_500, i_544), "push", Arr(((V)(j_546)), ((V)(st_556))));
IncK(indeg_501, ((V)(j_546)), 1D, false);
OpSetK(inS_502, ((V)(j_546)), 0, ((V)(st_556)));
}
}
_cont547: ;
j_546++;
}
}
i_544++;
}
}
done_503 = Invoke(New(G("Array"), n_496), "fill", (false ? V.True : V.False));
out2_504 = Arr();
{
double k_584 = 0;
k_584 = 0D;
while (true) {
if (!(Lt(((V)(k_584)), n_496))) break;
double pick_586 = 0;
pick_586 = (-1D);
{
double i_587 = 0;
i_587 = 0D;
while (true) {
if (!(Lt(((V)(i_587)), n_496))) break;
if ((!(Truthy(GetIdx(done_503, i_587))) && SEqN(GetIdx(indeg_501, i_587), 0D))) {
pick_586 = i_587;
break;
}
i_587++;
}
}
if ((pick_586 < 0D)) {
V bs_589 = default;
V bd_590 = default;
nf_345++;
bs_589 = ((V)(1000000000D));
bd_590 = ((V)(1000000000D));
{
double i_591 = 0;
i_591 = 0D;
while (true) {
if (!(Lt(((V)(i_591)), n_496))) break;
if ((!(Truthy(GetIdx(done_503, i_591))) && (Lt(GetIdx(inS_502, i_591), bs_589) || (SEq(GetIdx(inS_502, i_591), bs_589) && Lt(GetIdx(indeg_501, i_591), bd_590))))) {
bs_589 = GetIdx(inS_502, i_591);
bd_590 = GetIdx(indeg_501, i_591);
pick_586 = i_591;
}
i_591++;
}
}
}
SetIdx(done_503, pick_586, (true ? V.True : V.False));
Invoke(out2_504, "push", GetIdx(list_346, pick_586));
Invoke(GetIdx(after_500, pick_586), "forEach", Fn((V _arrowThis604, int _argc593, V _a595, V _a596, V _a597, V _a598, V[] _rest594) => {
V q_601 = default;
V st_603 = default;
{ V _t599 = ListOf(_a595);
{ V _t600 = GetIdx(_t599, 0D);
q_601 = _t600; }
{ V _t602 = GetIdx(_t599, 1D);
st_603 = _t602; }
}
IncK(indeg_501, q_601, -1D, false);
OpSetK(inS_502, q_601, 1, st_603);
return default;
}, 1, "", true));
k_584++;
}
}
Set(list_346, "length", ((V)(0D)));
Invoke(out2_504, "forEach", Fn((V _arrowThis612, int _argc605, V e_611, V _a608, V _a609, V _a610, V[] _rest606) => {
return Invoke(list_346, "push", e_611);
}, 1, "", true));
}
@out_347 = NewObj(4).Put("back", Arr()).Put("part", Arr()).Put("front", Arr()).Put("nf", ((V)(nf_345))).V;
x0_348 = ((V)(1000000000D));
y0_349 = ((V)(1000000000D));
x1_350 = ((V)((-1000000000D)));
y1_351 = ((V)((-1000000000D)));
grow_352 = Fn((V _arrowThis620, int _argc613, V P_619, V _a616, V _a617, V _a618, V[] _rest614) => {
return Invoke(P_619, "forEach", Fn((V _arrowThis628, int _argc621, V p_627, V _a624, V _a625, V _a626, V[] _rest622) => {
if (Lt(GetIdx(p_627, 0D), x0_348)) {
x0_348 = GetIdx(p_627, 0D);
}
if (Gt(GetIdx(p_627, 0D), x1_350)) {
x1_350 = GetIdx(p_627, 0D);
}
if (Lt(GetIdx(p_627, 1D), y0_349)) {
y0_349 = GetIdx(p_627, 1D);
}
if (Gt(GetIdx(p_627, 1D), y1_351)) {
y1_351 = GetIdx(p_627, 1D);
}
return default;
}, 1, "", true));
}, 1, "", true);
FR_353 = New(G("Set"));
if (Truthy(SQ_339)) {
V near_629 = default;
V ov_630 = default;
near_629 = Fn((V _arrowThis638, int _argc631, V B_637, V _a634, V _a635, V _a636, V[] _rest632) => {
double cx_639 = 0;
double cz_640 = 0;
V k_641 = default;
double bd_642 = 0;
cx_639 = (ToNum(Add(GetIdx(B_637, 0D), GetIdx(B_637, 1D))) / 2D);
cz_640 = (ToNum(Add(GetIdx(B_637, 4D), GetIdx(B_637, 5D))) / 2D);
k_641 = ((V)(0D));
bd_642 = 1000000000000000000D;
Invoke(SQ_339, "forEach", Fn((V _arrowThis651, int _argc643, V p_649, V i_650, V _a647, V _a648, V[] _rest644) => {
double d_652 = 0;
d_652 = (((ToNum(Get(p_649, "x")) - cx_639) * (ToNum(Get(p_649, "x")) - cx_639)) + ((ToNum(Get(p_649, "z")) - cz_640) * (ToNum(Get(p_649, "z")) - cz_640)));
if ((d_652 < bd_642)) {
bd_642 = d_652;
k_641 = i_650;
}
return default;
}, 2, "", true));
return k_641;
return default;
}, 1, "", true);
ov_630 = Fn((V _arrowThis661, int _argc653, V P_659, V Q_660, V _a657, V _a658, V[] _rest654) => {
return ((((LtN(GetIdx(P_659, 0D), (ToNum(GetIdx(Q_660, 1D)) - 1D)) && LtN(GetIdx(Q_660, 0D), (ToNum(GetIdx(P_659, 1D)) - 1D))) && LtN(GetIdx(P_659, 2D), (ToNum(GetIdx(Q_660, 3D)) - 1D))) && LtN(GetIdx(Q_660, 2D), (ToNum(GetIdx(P_659, 3D)) - 1D))) ? V.True : V.False);
}, 2, "", true);
Invoke(list_346, "forEach", Fn((V _arrowThis669, int _argc662, V e_668, V _a665, V _a666, V _a667, V[] _rest663) => {
V k_670 = default;
if (Truthy(Get(Get(e_668, "S"), "part"))) {
return default;
}
if (Truthy(Call(inFr_342, V.Undef, Get(e_668, "L")))) {
Set(e_668, "nk", Call(near_629, V.Undef, Get(e_668, "L")));
Invoke(FR_353, "add", e_668);
return default;
}
if (!(Truthy(Get(FR_353, "size")))) {
return default;
}
k_670 = Call(near_629, V.Undef, Get(e_668, "L"));
{
foreach (V _k671 in new JsIter(FR_353)) {
V f_672 = default;
f_672 = _k671;
if (Truthy(((Get(f_672, "cl") is var _t673 && Truthy(_t673) ? _t673 : (!SEq(Get(f_672, "nk"), k_670) ? V.True : V.False)) is var _t674 && !Truthy(_t674) ? _t674 : Call(ov_630, V.Undef, Get(e_668, "sb"), Get(f_672, "sb"))))) {
Set(e_668, "nk", k_670);
Set(e_668, "cl", ((V)(1D)));
Invoke(FR_353, "add", e_668);
return default;
}
}
}
return default;
}, 1, "", true));
}
if (Truthy(Get(KID_343, "size"))) {
V ex_675 = default;
V add_676 = default;
ex_675 = Arr();
add_676 = Fn((V _arrowThis684, int _argc677, V e_683, V _a680, V _a681, V _a682, V[] _rest678) => {
Invoke(ex_675, "push", e_683);
Invoke((Invoke(KID_343, "get", Get(e_683, "S")) is var _t693 && Truthy(_t693) ? _t693 : Arr()), "forEach", Fn((V _arrowThis692, int _argc685, V S_691, V _a688, V _a689, V _a690, V[] _rest686) => {
return Call(add_676, V.Undef, NewObj(4).Put("S", S_691).Put("pts", Invoke(Get(S_691, "pts"), "map", R_334)).Put("dep", Get(e_683, "dep")).Put("pe", e_683).V);
}, 1, "", true));
return default;
}, 1, "", true);
Invoke(list_346, "forEach", add_676);
Set(list_346, "length", ((V)(0D)));
Invoke(ex_675, "forEach", Fn((V _arrowThis701, int _argc694, V e_700, V _a697, V _a698, V _a699, V[] _rest695) => {
return Invoke(list_346, "push", e_700);
}, 1, "", true));
}
Invoke(list_346, "forEach", Fn((V _arrowThis709, int _argc702, V E_708, V _a705, V _a706, V _a707, V[] _rest703) => {
V S_710 = default;
V pts_711 = default;
V dep_712 = default;
V vis_713 = default;
V L_714 = default;
V oc_715 = default;
double ow_716 = 0;
V op_717 = default;
{ V _t718 = E_708;
if (_t718.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t718));
{ V _t719 = Get(_t718, "S");
S_710 = _t719; }
{ V _t720 = Get(_t718, "pts");
pts_711 = _t720; }
{ V _t721 = Get(_t718, "dep");
dep_712 = _t721; } }
Set(E_708, "lay", (Truthy(Get(E_708, "pe")) ? (Get(Get(E_708, "pe"), "lay") is var _t722 && Truthy(_t722) ? _t722 : Get(@out_347, "back")) : (Truthy(Get(S_710, "part")) ? Get(@out_347, "part") : (Truthy((((!sd_338.IsNullish && Gt(dep_712, Add(sd_338, ((V)(4D))))) ? V.True : V.False) is var _t723 && Truthy(_t723) ? _t723 : Invoke(FR_353, "has", E_708))) ? Get(@out_347, "front") : Get(@out_347, "back")))));
if (Truthy((Get(E_708, "pe") is var _t724 && !Truthy(_t724) ? _t724 : Get(S_710, "fn")))) {
V n_725 = default;
n_725 = Call(Rn_332, V.Undef, Get(S_710, "fn"));
if ((((ToNum(GetIdx(n_725, 1D)) * SA_9) + (ToNum(GetIdx(n_725, 2D)) * CA_10)) <= 0.05)) {
return default;
}
}
vis_713 = Arr();
Invoke(Get(S_710, "faces"), "forEach", Fn((V _arrowThis733, int _argc726, V F_732, V _a729, V _a730, V _a731, V[] _rest727) => {
V n_734 = default;
double dv_735 = 0;
n_734 = Call(Rn_332, V.Undef, Get(F_732, "n"));
dv_735 = ((ToNum(GetIdx(n_734, 1D)) * SA_9) + (ToNum(GetIdx(n_734, 2D)) * CA_10));
if ((dv_735 <= 0.02)) {
return default;
}
Invoke(vis_713, "push", NewObj(4).Put("P2", Invoke(Get(F_732, "q"), "map", Fn((V _arrowThis743, int _argc736, V p_742, V _a739, V _a740, V _a741, V[] _rest737) => {
return Call(pr_335, V.Undef, Call(R_334, V.Undef, p_742));
}, 1, "", true))).Put("n", n_734).Put("cap", Get(F_732, "cap")).Put("k", ((V)((Truthy(Get(S_710, "emit")) ? 1D : ((0.62 + (0.42 * Max(0D, ToNum(Call(dot_26, V.Undef, n_734, LT_12))))) + (0.05 * dv_735)))))).V);
return default;
}, 1, "", true));
if (!(Truthy(Get(vis_713, "length")))) {
return default;
}
L_714 = Get(E_708, "lay");
oc_715 = (Truthy(Get(S_710, "noOut")) ? ((V)("none")) : Call(shade_24, V.Undef, Get(S_710, "col"), ((V)(0.58))));
ow_716 = (Truthy(Get(S_710, "noOut")) ? 0D : 1.15);
op_717 = (Get(S_710, "op") is var _t744 && !_t744.IsNullish ? _t744 : ((V)(1D)));
if (Truthy(Get(S_710, "cv"))) {
V H_745 = default;
V HP_746 = default;
V m_747 = default;
V bx0_748 = default;
V bx1_749 = default;
V by0_750 = default;
V by1_751 = default;
double bw_752 = 0;
double bh_753 = 0;
V big_754 = default;
H_745 = Call(hull_30, V.Undef, Invoke(pts_711, "map", pr_335));
Call(grow_352, V.Undef, H_745);
HP_746 = Call(pathOf_27, V.Undef, H_745);
m_747 = Call(matOf_60, V.Undef, S_710);
bx0_748 = ((V)(1000000000D));
bx1_749 = ((V)((-1000000000D)));
by0_750 = ((V)(1000000000D));
by1_751 = ((V)((-1000000000D)));
Invoke(H_745, "forEach", Fn((V _arrowThis762, int _argc755, V p_761, V _a758, V _a759, V _a760, V[] _rest756) => {
if (Lt(GetIdx(p_761, 0D), bx0_748)) {
bx0_748 = GetIdx(p_761, 0D);
}
if (Gt(GetIdx(p_761, 0D), bx1_749)) {
bx1_749 = GetIdx(p_761, 0D);
}
if (Lt(GetIdx(p_761, 1D), by0_750)) {
by0_750 = GetIdx(p_761, 1D);
}
if (Gt(GetIdx(p_761, 1D), by1_751)) {
by1_751 = GetIdx(p_761, 1D);
}
return default;
}, 1, "", true));
bw_752 = (ToNum(bx1_749) - ToNum(bx0_748));
bh_753 = (ToNum(by1_751) - ToNum(by0_750));
big_754 = ((((bw_752 > 5D) && (bh_753 > 5D)) && GtN(op_717, 0.5)) ? V.True : V.False);
if (Truthy(Get(S_710, "emit"))) {
Invoke(L_714, "push", NewObj(5).Put("d", HP_746).Put("f", Call(shade_24, V.Undef, Get(S_710, "col"), ((V)(1.04)))).Put("s", oc_715).Put("w", ((V)(ow_716))).Put("o", op_717).V);
if (Truthy((big_754 is var _t763 && !Truthy(_t763) ? _t763 : (!(Truthy(Get(S_710, "noOut"))) ? V.True : V.False)))) {
Invoke(L_714, "push", NewObj(5).Put("d", HP_746).Put("f", ((V)("url(#mVol) none"))).Put("s", ((V)("none"))).Put("w", ((V)(0D))).Put("o", ((V)(0.35))).V);
}
} else {
if (Truthy((Get(S_710, "shine") is var _t764 && Truthy(_t764) ? _t764 : Get(S_710, "org")))) {
Invoke(L_714, "push", NewObj(5).Put("d", HP_746).Put("f", Call(gref_57, V.Undef, ((V)("R")), Get(S_710, "col"), gs_336)).Put("s", oc_715).Put("w", ((V)(ow_716))).Put("o", op_717).V);
if (Truthy(big_754)) {
Invoke(L_714, "push", NewObj(5).Put("d", HP_746).Put("f", ((V)("url(#mVol) none"))).Put("s", ((V)("none"))).Put("w", ((V)(0D))).Put("o", ((V)(0.6))).V);
}
if (!(Truthy(Get(S_710, "noOut")))) {
Call(hi_337, V.Undef, H_745, L_714, ((V)(0.9)));
}
} else {
V tp_765 = default;
V T_766 = default;
Invoke(L_714, "push", NewObj(5).Put("d", HP_746).Put("f", Call(gref_57, V.Undef, ((V)("S")), Get(S_710, "col"), gs_336)).Put("s", oc_715).Put("w", ((V)(ow_716))).Put("o", op_717).V);
tp_765 = Arr();
Invoke(vis_713, "forEach", Fn((V _arrowThis774, int _argc767, V F_773, V _a770, V _a771, V _a772, V[] _rest768) => {
if (GtN(GetIdx(Get(F_773, "n"), 1D), 0.42)) {
Invoke(Get(F_773, "P2"), "forEach", Fn((V _arrowThis782, int _argc775, V p_781, V _a778, V _a779, V _a780, V[] _rest776) => {
return Invoke(tp_765, "push", p_781);
}, 1, "", true));
}
return default;
}, 1, "", true));
T_766 = V.Null;
if (GeN(Get(tp_765, "length"), 3D)) {
T_766 = Call(hull_30, V.Undef, tp_765);
Invoke(L_714, "push", NewObj(5).Put("d", Call(pathOf_27, V.Undef, T_766)).Put("f", Call(gref_57, V.Undef, ((V)("T")), Get(S_710, "col"), gs_336)).Put("s", ((V)("none"))).Put("w", ((V)(0D))).Put("o", op_717).V);
}
if (Truthy(big_754)) {
if (Truthy((GetK(TEX_61, m_747) is var _t783 && !Truthy(_t783) ? _t783 : (((bw_752 * bh_753) > 120D) ? V.True : V.False)))) {
Invoke(L_714, "push", NewObj(5).Put("d", HP_746).Put("f", GetK(TEX_61, m_747)).Put("s", ((V)("none"))).Put("w", ((V)(0D))).Put("o", ((V)(1D))).V);
}
Invoke(L_714, "push", NewObj(5).Put("d", HP_746).Put("f", ((V)("url(#mVol) none"))).Put("s", ((V)("none"))).Put("w", ((V)(0D))).Put("o", ((V)((SEqS(m_747, "cer") ? 0.65 : 1D)))).V);
}
if (Truthy(Get(S_710, "soft"))) {
Call(hi_337, V.Undef, (T_766 is var _t784 && Truthy(_t784) ? _t784 : H_745), L_714, ((V)((Truthy(T_766) ? 0.75 : 0.6))));
} else {
if ((SEqS(m_747, "metal") || SEqS(m_747, "cer"))) {
Call(hi_337, V.Undef, (T_766 is var _t785 && Truthy(_t785) ? _t785 : H_745), L_714, ((V)(0.5)));
}
}
}
}
} else {
Invoke(vis_713, "forEach", Fn((V _arrowThis793, int _argc786, V F_792, V _a789, V _a790, V _a791, V[] _rest787) => {
V fc_794 = default;
Call(grow_352, V.Undef, Get(F_792, "P2"));
fc_794 = Call(shade_24, V.Undef, Get(S_710, "col"), Get(F_792, "k"));
Invoke(L_714, "push", NewObj(5).Put("d", Call(pathOf_27, V.Undef, Get(F_792, "P2"))).Put("f", fc_794).Put("s", fc_794).Put("w", ((V)(0.8))).Put("o", op_717).V);
return default;
}, 1, "", true));
}
if (Truthy(Get(S_710, "tex"))) {
V HH_795 = default;
HH_795 = V.Null;
if (Truthy(Get(S_710, "texTop"))) {
V tq_796 = default;
tq_796 = Arr();
Invoke(vis_713, "forEach", Fn((V _arrowThis804, int _argc797, V F_803, V _a800, V _a801, V _a802, V[] _rest798) => {
if (GtN(GetIdx(Get(F_803, "n"), 1D), 0.42)) {
Invoke(Get(F_803, "P2"), "forEach", Fn((V _arrowThis812, int _argc805, V p_811, V _a808, V _a809, V _a810, V[] _rest806) => {
return Invoke(tq_796, "push", p_811);
}, 1, "", true));
}
return default;
}, 1, "", true));
if (GeN(Get(tq_796, "length"), 3D)) {
HH_795 = Call(hull_30, V.Undef, tq_796);
}
} else {
HH_795 = Call(hull_30, V.Undef, Invoke(pts_711, "map", pr_335));
}
if (Truthy(HH_795)) {
Invoke(L_714, "push", NewObj(5).Put("d", Call(pathOf_27, V.Undef, HH_795)).Put("f", Get(S_710, "tex")).Put("s", ((V)("none"))).Put("w", ((V)(0D))).Put("o", (Get(S_710, "texO") is var _t813 && !_t813.IsNullish ? _t813 : ((V)(1D)))).V);
}
}
return default;
}, 1, "", true));
fpR_354 = Fn((V _arrowThis821, int _argc814, V k_820, V _a817, V _a818, V _a819, V[] _rest815) => {
return Invoke(Call(ring_31, V.Undef, NewObj(5).Put("sh", ((V)((Truthy(Get(D_326, "round")) ? "el" : "rr")))).Put("a", ((V)(((ToNum(Get(D_326, "w")) / 2D) * ToNum(k_820))))).Put("b", ((V)(((ToNum(Get(D_326, "d")) / 2D) * ToNum(k_820))))).Put("r", ((V)((Min(ToNum(Get(D_326, "w")), ToNum(Get(D_326, "d"))) * 0.22)))).Put("n", ((V)(20D))).V, ((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis833, int _argc822, V _a824, V _a825, V _a826, V _a827, V[] _rest823) => {
V u_830 = default;
V v_832 = default;
{ V _t828 = ListOf(_a824);
{ V _t829 = GetIdx(_t828, 0D);
u_830 = _t829; }
{ V _t831 = GetIdx(_t828, 1D);
v_832 = _t831; }
}
return Call(pr_335, V.Undef, Call(Rf_333, V.Undef, Arr(u_830, ((V)(0D)), v_832)));
}, 1, "", true));
}, 1, "", true);
shP_355 = Call(hull_30, V.Undef, Call(fpR_354, V.Undef, ((V)(1.04))));
ftP_356 = Call(hull_30, V.Undef, Call(fpR_354, V.Undef, ((V)(1.14))));
ctP_357 = Call(hull_30, V.Undef, Call(fpR_354, V.Undef, ((V)(0.9))));
Call(grow_352, V.Undef, ftP_356);
face_358 = V.Null;
if (Truthy(Get(D_326, "face"))) {
V q_834 = default;
double k_835 = 0;
q_834 = Call(pr_335, V.Undef, Call(R_334, V.Undef, Arr(((V)(0D)), Get(Get(D_326, "face"), "y"), Get(Get(D_326, "face"), "z"))));
k_835 = (FS_55 * ToNum(Z_331));
face_358 = NewObj(7).Put("x", Call(f1_21, V.Undef, GetIdx(q_834, 0D))).Put("y", Call(f1_21, V.Undef, GetIdx(q_834, 1D))).Put("a", ((V)((c_329 * k_835)))).Put("b", ((V)((((-s_330) * SA_9) * k_835)))).Put("d", ((V)((CA_10 * k_835)))).Put("w", Get(Get(D_326, "face"), "w")).Put("h", Get(Get(D_326, "face"), "h")).V;
}
glow_359 = V.Null;
G_360 = (Get(D_326, "glow") is var _t837 && !Truthy(_t837) ? _t837 : Invoke(D_326, "glow", (v_323 is var _t836 && Truthy(_t836) ? _t836 : ((V)("")))));
if (Truthy(G_360)) {
V q_838 = default;
double gr_839 = 0;
q_838 = Call(pr_335, V.Undef, Call(R_334, V.Undef, Arr(((V)(0D)), Get(G_360, "y"), ((V)(0D)))));
gr_839 = (ToNum(Get(G_360, "r")) * ToNum(Z_331));
glow_359 = NewObj(2).Put("d", Call(circ_28, V.Undef, GetIdx(q_838, 0D), GetIdx(q_838, 1D), ((V)(gr_839)))).Put("f", (Get(G_360, "c") is var _t840 && Truthy(_t840) ? _t840 : ((V)("url(#gWarm)")))).V;
Call(grow_352, V.Undef, Arr(Arr(((V)((ToNum(GetIdx(q_838, 0D)) - gr_839))), ((V)((ToNum(GetIdx(q_838, 1D)) - gr_839)))), Arr(Add(GetIdx(q_838, 0D), ((V)(gr_839))), Add(GetIdx(q_838, 1D), ((V)(gr_839))))));
}
pv_361 = (Truthy(Get(D_326, "pivot")) ? Call(pr_335, V.Undef, Call(R_334, V.Undef, Get(D_326, "pivot"))) : Arr(((V)(0D)), ((V)(0D))));
screen_362 = V.Null;
{
V SC_841 = default;
V nf_842 = default;
SC_841 = Invoke(sol_327, "find", Fn((V _arrowThis850, int _argc843, V S_849, V _a846, V _a847, V _a848, V[] _rest844) => {
return Get(S_849, "scr");
}, 1, "", true));
nf_842 = Call(Rn_332, V.Undef, Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
if (Truthy((SC_841 is var _t851 && !Truthy(_t851) ? _t851 : ((((ToNum(GetIdx(nf_842, 1D)) * SA_9) + (ToNum(GetIdx(nf_842, 2D)) * CA_10)) > 0.05) ? V.True : V.False)))) {
double a_852 = 0;
double b_853 = 0;
double lo_854 = 0;
double hi2_855 = 0;
double zf_856 = 0;
V TL_857 = default;
V TR_858 = default;
V BL_859 = default;
double W_860 = 0;
double H_861 = 0;
a_852 = 1000000000D;
b_853 = (-1000000000D);
lo_854 = 1000000000D;
hi2_855 = (-1000000000D);
zf_856 = (-1000000000D);
Invoke(Get(SC_841, "pts"), "forEach", Fn((V _arrowThis869, int _argc862, V p_868, V _a865, V _a866, V _a867, V[] _rest863) => {
a_852 = Min(a_852, ToNum(GetIdx(p_868, 0D)));
b_853 = Max(b_853, ToNum(GetIdx(p_868, 0D)));
lo_854 = Min(lo_854, ToNum(GetIdx(p_868, 1D)));
hi2_855 = Max(hi2_855, ToNum(GetIdx(p_868, 1D)));
zf_856 = Max(zf_856, ToNum(GetIdx(p_868, 2D)));
return default;
}, 1, "", true));
TL_857 = Call(pr_335, V.Undef, Call(R_334, V.Undef, Arr(((V)(a_852)), ((V)(hi2_855)), ((V)(zf_856)))));
TR_858 = Call(pr_335, V.Undef, Call(R_334, V.Undef, Arr(((V)(b_853)), ((V)(hi2_855)), ((V)(zf_856)))));
BL_859 = Call(pr_335, V.Undef, Call(R_334, V.Undef, Arr(((V)(a_852)), ((V)(lo_854)), ((V)(zf_856)))));
W_860 = (b_853 - a_852);
H_861 = (hi2_855 - lo_854);
if (((W_860 > 1D) && (H_861 > 1D))) {
screen_362 = NewObj(4).Put("w", Call(f1_21, V.Undef, ((V)(W_860)))).Put("h", Call(f1_21, V.Undef, ((V)(H_861)))).Put("r", Call(f1_21, V.Undef, ((V)(Min(ToNum(Get(Get(SC_841, "scr"), "r")), (W_860 / 2D), (H_861 / 2D)))))).Put("m", ((V)(JsStrBuf.Begin().S("matrix(").V(Invoke(Invoke(Arr(((V)(((ToNum(GetIdx(TR_858, 0D)) - ToNum(GetIdx(TL_857, 0D))) / W_860))), ((V)(((ToNum(GetIdx(TR_858, 1D)) - ToNum(GetIdx(TL_857, 1D))) / W_860))), ((V)(((ToNum(GetIdx(BL_859, 0D)) - ToNum(GetIdx(TL_857, 0D))) / H_861))), ((V)(((ToNum(GetIdx(BL_859, 1D)) - ToNum(GetIdx(TL_857, 1D))) / H_861))), GetIdx(TL_857, 0D), GetIdx(TL_857, 1D)), "map", Fn((V _arrowThis877, int _argc870, V q_876, V _a873, V _a874, V _a875, V[] _rest871) => {
return Invoke(q_876, "toFixed", ((V)(4D)));
}, 1, "", true)), "join", ((V)(" ")))).S(")").End()))).V;
}
}
}
x0_348 = ((V)((ToNum(x0_348) - 6D)));
y0_349 = ((V)((ToNum(y0_349) - 6D)));
x1_350 = Add(x1_350, ((V)(6D)));
y1_351 = Add(y1_351, ((V)(6D)));
res_363 = NewObj(14).Put("nf", ((V)(nf_345))).Put("gids", new ArrBuilder().Spread(gs_336).V).Put("back", Get(@out_347, "back")).Put("part", Get(@out_347, "part")).Put("front", Get(@out_347, "front")).Put("glow", glow_359).Put("shadow", Call(pathOf_27, V.Undef, shP_355)).Put("contact", Call(pathOf_27, V.Undef, ctP_357)).Put("foot", Call(pathOf_27, V.Undef, ftP_356)).Put("pv", pv_361).Put("face", face_358).Put("screen", screen_362).Put("bb", NewObj(4).Put("x", Call(f1_21, V.Undef, x0_348)).Put("y", Call(f1_21, V.Undef, y0_349)).Put("w", Call(f1_21, V.Undef, ((V)((ToNum(x1_350) - ToNum(x0_348)))))).Put("h", Call(f1_21, V.Undef, ((V)((ToNum(y1_351) - ToNum(y0_349)))))).V).Put("vb", ((V)(JsStrBuf.Begin().V(Call(f1_21, V.Undef, x0_348)).S(" ").V(Call(f1_21, V.Undef, y0_349)).S(" ").V(Call(f1_21, V.Undef, ((V)((ToNum(x1_350) - ToNum(x0_348)))))).S(" ").V(Call(f1_21, V.Undef, ((V)((ToNum(y1_351) - ToNum(y0_349)))))).End()))).V;
Invoke(CACHE_64, "set", key_324, res_363);
return res_363;
return default;
}, 4, "render", false);
A_8 = ((38D * System.Math.PI) / 180D);
SA_9 = FdLibm.Sin(A_8);
CA_10 = FdLibm.Cos(A_8);
LN_11 = Hypot(0.5, 1D, 0.55);
LT_12 = Arr(((V)(((-0.5) / LN_11))), ((V)((1D / LN_11))), ((V)((0.55 / LN_11))));
VW_13 = 852D;
FY0_14 = 128D;
FY1_15 = 334D;
RM_16 = NewObj(2).Put("s", ((V)(1D))).Put("e", V.Null).V;
SK_17 = 0.7;
sAt_18 = Fn((V _arrowThis885, int _argc878, V y_884, V _a881, V _a882, V _a883, V[] _rest879) => {
return ((V)((((0.6 + ((0.24 * (ToNum(y_884) - 128D)) / 228D)) * SK_17) * ToNum(Get(RM_16, "s")))));
}, 1, "", true);
edge0_19 = Fn((V _arrowThis893, int _argc886, V y_892, V _a889, V _a890, V _a891, V[] _rest887) => {
return ((V)((LtN(y_892, 262D) ? (100D - (((ToNum(y_892) - 100D) * 100D) / 162D)) : 0D)));
}, 1, "", true);
edge_20 = Fn((V _arrowThis901, int _argc894, V y_900, V _a897, V _a898, V _a899, V[] _rest895) => {
return (Truthy(Get(RM_16, "e")) ? Invoke(RM_16, "e", y_900) : Call(edge0_19, V.Undef, y_900));
}, 1, "", true);
f1_21 = Fn((V _arrowThis909, int _argc902, V v_908, V _a905, V _a906, V _a907, V[] _rest903) => {
return ((V)((Round((ToNum(v_908) * 10D)) / 10D)));
}, 1, "", true);
hx_22 = Fn((V _arrowThis917, int _argc910, V h_916, V _a913, V _a914, V _a915, V[] _rest911) => {
double n_918 = 0;
h_916 = Invoke(h_916, "replace", ((V)("#")), ((V)("")));
if (SEqN(Get(h_916, "length"), 3D)) {
h_916 = Invoke(Invoke(Invoke(h_916, "split", ((V)(""))), "map", Fn((V _arrowThis926, int _argc919, V c_925, V _a922, V _a923, V _a924, V[] _rest920) => {
return Add(c_925, c_925);
}, 1, "", true)), "join", ((V)("")));
}
n_918 = ParseInt(h_916, ((V)(16D)));
return Arr(((V)(((double)(ToInt32(((double)(ToInt32(n_918) >> (int)(ToUint32(16D) & 31)))) & ToInt32(255D))))), ((V)(((double)(ToInt32(((double)(ToInt32(n_918) >> (int)(ToUint32(8D) & 31)))) & ToInt32(255D))))), ((V)(((double)(ToInt32(n_918) & ToInt32(255D))))));
return default;
}, 1, "", true);
th_23 = Fn((V _arrowThis934, int _argc927, V c_933, V _a930, V _a931, V _a932, V[] _rest928) => {
return ((V)(JsStrBuf.Begin().S("#").V(Invoke(Invoke(c_933, "map", Fn((V _arrowThis942, int _argc935, V v_941, V _a938, V _a939, V _a940, V[] _rest936) => {
return Invoke(Invoke(((V)(Max(0D, Min(255D, Round(ToNum(v_941)))))), "toString", ((V)(16D))), "padStart", ((V)(2D)), ((V)("0")));
}, 1, "", true)), "join", ((V)("")))).End()));
}, 1, "", true);
shade_24 = Fn((V _arrowThis951, int _argc943, V h_949, V k_950, V _a947, V _a948, V[] _rest944) => {
V c_952 = default;
c_952 = Call(hx_22, V.Undef, h_949);
return Call(th_23, V.Undef, (LeN(k_950, 1D) ? Invoke(c_952, "map", Fn((V _arrowThis960, int _argc953, V v_959, V _a956, V _a957, V _a958, V[] _rest954) => {
return ((V)((ToNum(v_959) * ToNum(k_950))));
}, 1, "", true)) : Invoke(c_952, "map", Fn((V _arrowThis968, int _argc961, V v_967, V _a964, V _a965, V _a966, V[] _rest962) => {
return Add(v_967, ((V)(((255D - ToNum(v_967)) * (ToNum(k_950) - 1D)))));
}, 1, "", true))));
return default;
}, 2, "", true);
mix_25 = Fn((V _arrowThis978, int _argc969, V a_975, V b_976, V t_977, V _a974, V[] _rest970) => {
V x_979 = default;
V y_980 = default;
x_979 = Call(hx_22, V.Undef, a_975);
y_980 = Call(hx_22, V.Undef, b_976);
return Call(th_23, V.Undef, Invoke(x_979, "map", Fn((V _arrowThis989, int _argc981, V v_987, V i_988, V _a985, V _a986, V[] _rest982) => {
return Add(v_987, ((V)(((ToNum(GetK(y_980, i_988)) - ToNum(v_987)) * ToNum(t_977)))));
}, 2, "", true)));
return default;
}, 3, "", true);
dot_26 = Fn((V _arrowThis998, int _argc990, V a_996, V b_997, V _a994, V _a995, V[] _rest991) => {
return ((V)((((ToNum(GetIdx(a_996, 0D)) * ToNum(GetIdx(b_997, 0D))) + (ToNum(GetIdx(a_996, 1D)) * ToNum(GetIdx(b_997, 1D)))) + (ToNum(GetIdx(a_996, 2D)) * ToNum(GetIdx(b_997, 2D))))));
}, 2, "", true);
pathOf_27 = Fn((V _arrowThis1006, int _argc999, V P_1005, V _a1002, V _a1003, V _a1004, V[] _rest1000) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(P_1005, "map", Fn((V _arrowThis1014, int _argc1007, V p_1013, V _a1010, V _a1011, V _a1012, V[] _rest1008) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_21, V.Undef, GetIdx(p_1013, 0D))).S(" ").V(Call(f1_21, V.Undef, GetIdx(p_1013, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
circ_28 = Fn((V _arrowThis1024, int _argc1015, V cx_1021, V cy_1022, V r_1023, V _a1020, V[] _rest1016) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_21, V.Undef, ((V)((ToNum(cx_1021) - ToNum(r_1023)))))).S(" ").V(Call(f1_21, V.Undef, cy_1022)).S("a").V(r_1023).S(" ").V(r_1023).S(" 0 1 0 ").N((2D * ToNum(r_1023))).S(" 0a").V(r_1023).S(" ").V(r_1023).S(" 0 1 0 ").N(((-2D) * ToNum(r_1023))).S(" 0Z").End()));
}, 3, "", true);
ell_29 = Fn((V _arrowThis1035, int _argc1025, V cx_1031, V cy_1032, V rx_1033, V ry_1034, V[] _rest1026) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_21, V.Undef, ((V)((ToNum(cx_1031) - ToNum(rx_1033)))))).S(" ").V(Call(f1_21, V.Undef, cy_1032)).S("a").V(Call(f1_21, V.Undef, rx_1033)).S(" ").V(Call(f1_21, V.Undef, ry_1034)).S(" 0 1 0 ").V(Call(f1_21, V.Undef, ((V)((2D * ToNum(rx_1033)))))).S(" 0a").V(Call(f1_21, V.Undef, rx_1033)).S(" ").V(Call(f1_21, V.Undef, ry_1034)).S(" 0 1 0 ").V(Call(f1_21, V.Undef, ((V)(((-2D) * ToNum(rx_1033)))))).S(" 0Z").End()));
}, 4, "", true);
area2_33 = Fn((V _arrowThis1043, int _argc1036, V p_1042, V _a1039, V _a1040, V _a1041, V[] _rest1037) => {
double s_1044 = 0;
s_1044 = 0D;
{
double i_1045 = 0;
i_1045 = 0D;
while (true) {
if (!(Lt(((V)(i_1045)), Get(p_1042, "length")))) break;
double j_1047 = 0;
j_1047 = ((i_1045 + 1D) % ToNum(Get(p_1042, "length")));
s_1044 = (s_1044 + ((ToNum(GetIdx(GetIdx(p_1042, i_1045), 0D)) * ToNum(GetIdx(GetIdx(p_1042, j_1047), 1D))) - (ToNum(GetIdx(GetIdx(p_1042, j_1047), 0D)) * ToNum(GetIdx(GetIdx(p_1042, i_1045), 1D)))));
i_1045++;
}
}
return ((V)(System.Math.Abs(s_1044)));
return default;
}, 1, "", true);
box_35 = Fn((V _arrowThis1063, int _argc1048, V x_1054, V y_1055, V z_1056, V w_1057, V[] _rest1049) => {
V h_1058 = default;
V d_1059 = default;
V col_1060 = default;
V o_1062 = default;
h_1058 = (_argc1048 > 4 ? _rest1049[0] : V.Undef);
d_1059 = (_argc1048 > 5 ? _rest1049[1] : V.Undef);
col_1060 = (_argc1048 > 6 ? _rest1049[2] : V.Undef);
{ V _t1061 = (_argc1048 > 7 ? _rest1049[3] : V.Undef); if (_t1061.IsUndef) _t1061 = NewObj(0).V;
o_1062 = _t1061; }
return Call(solid_34, V.Undef, Object_assign(NewObj(8).Put("ax", ((V)("y"))).Put("sh", ((V)("rr"))).Put("c", Arr(x_1054, z_1056)).Put("a", ((V)((ToNum(w_1057) / 2D)))).Put("b", ((V)((ToNum(d_1059) / 2D)))).Put("r", ((V)(3D))).Put("rings", (Truthy(Get(o_1062, "bev")) ? Arr(Arr(y_1055, ((V)(0D))), Arr(((V)((ToNum(Add(y_1055, h_1058)) - ToNum(Get(o_1062, "bev"))))), ((V)(0D))), Arr(Add(y_1055, h_1058), Get(o_1062, "bev"))) : Arr(Arr(y_1055, ((V)(0D))), Arr(Add(y_1055, h_1058), ((V)(0D)))))).Put("col", col_1060).V, o_1062));
}, 8, "", true);
cush_36 = Fn((V _arrowThis1079, int _argc1064, V x_1070, V y_1071, V z_1072, V w_1073, V[] _rest1065) => {
double e_1080 = 0;
V h_1074 = default;
V d_1075 = default;
V col_1076 = default;
V o_1078 = default;
h_1074 = (_argc1064 > 4 ? _rest1065[0] : V.Undef);
d_1075 = (_argc1064 > 5 ? _rest1065[1] : V.Undef);
col_1076 = (_argc1064 > 6 ? _rest1065[2] : V.Undef);
{ V _t1077 = (_argc1064 > 7 ? _rest1065[3] : V.Undef); if (_t1077.IsUndef) _t1077 = NewObj(0).V;
o_1078 = _t1077; }
e_1080 = Min(6D, (ToNum(h_1074) * 0.45));
return Call(solid_34, V.Undef, Object_assign(NewObj(9).Put("ax", ((V)("y"))).Put("sh", ((V)("rr"))).Put("c", Arr(x_1070, z_1072)).Put("a", ((V)((ToNum(w_1073) / 2D)))).Put("b", ((V)((ToNum(d_1075) / 2D)))).Put("r", ((V)(10D))).Put("rings", Arr(Arr(y_1071, ((V)(2.5))), Arr(Add(y_1071, ((V)(2.5))), ((V)(0D))), Arr(((V)((ToNum(Add(y_1071, h_1074)) - e_1080))), ((V)(0D))), Arr(Add(y_1071, h_1074), ((V)(e_1080))))).Put("col", col_1076).Put("soft", ((V)(1D))).V, o_1078));
return default;
}, 8, "", true);
cyl_37 = Fn((V _arrowThis1095, int _argc1081, V x_1087, V y_1088, V z_1089, V rx_1090, V[] _rest1082) => {
V h_1091 = default;
V col_1092 = default;
V o_1094 = default;
h_1091 = (_argc1081 > 4 ? _rest1082[0] : V.Undef);
col_1092 = (_argc1081 > 5 ? _rest1082[1] : V.Undef);
{ V _t1093 = (_argc1081 > 6 ? _rest1082[2] : V.Undef); if (_t1093.IsUndef) _t1093 = NewObj(0).V;
o_1094 = _t1093; }
return Call(solid_34, V.Undef, Object_assign(NewObj(8).Put("ax", ((V)("y"))).Put("sh", ((V)("el"))).Put("c", Arr(x_1087, z_1089)).Put("a", rx_1090).Put("b", (Get(o_1094, "rz") is var _t1096 && !_t1096.IsNullish ? _t1096 : rx_1090)).Put("n", ((V)(16D))).Put("rings", (Truthy(Get(o_1094, "rg")) ? Invoke(Get(o_1094, "rg"), "map", Fn((V _arrowThis1104, int _argc1097, V r_1103, V _a1100, V _a1101, V _a1102, V[] _rest1098) => {
return Arr(Add(y_1088, GetIdx(r_1103, 0D)), (GetIdx(r_1103, 1D) is var _t1105 && Truthy(_t1105) ? _t1105 : ((V)(0D))), (GetIdx(r_1103, 2D) is var _t1106 && !_t1106.IsNullish ? _t1106 : ((V)(1D))));
}, 1, "", true)) : Arr(Arr(y_1088, ((V)(0D))), Arr(Add(y_1088, h_1091), (Get(o_1094, "top") is var _t1107 && Truthy(_t1107) ? _t1107 : ((V)(0D))))))).Put("col", col_1092).V, o_1094));
}, 7, "", true);
ball_38 = Fn((V _arrowThis1121, int _argc1108, V x_1114, V y_1115, V z_1116, V r_1117, V[] _rest1109) => {
V sx_1122 = default;
V sy_1123 = default;
V sz_1124 = default;
V K_1125 = default;
V rg_1126 = default;
V col_1118 = default;
V o_1120 = default;
col_1118 = (_argc1108 > 4 ? _rest1109[0] : V.Undef);
{ V _t1119 = (_argc1108 > 5 ? _rest1109[1] : V.Undef); if (_t1119.IsUndef) _t1119 = NewObj(0).V;
o_1120 = _t1119; }
sx_1122 = (Get(o_1120, "sx") is var _t1127 && Truthy(_t1127) ? _t1127 : ((V)(1D)));
sy_1123 = (Get(o_1120, "sy") is var _t1128 && Truthy(_t1128) ? _t1128 : ((V)(1D)));
sz_1124 = (Get(o_1120, "sz") is var _t1129 && Truthy(_t1129) ? _t1129 : ((V)(1D)));
K_1125 = (Get(o_1120, "k") is var _t1130 && Truthy(_t1130) ? _t1130 : ((V)(5D)));
rg_1126 = Arr();
{
double i_1131 = 0;
i_1131 = 0D;
while (true) {
if (!(Le(((V)(i_1131)), K_1125))) break;
double an_1133 = 0;
an_1133 = (((-System.Math.PI) / 2D) + ((System.Math.PI * i_1131) / ToNum(K_1125)));
Invoke(rg_1126, "push", Arr(Add(y_1115, ((V)(((ToNum(r_1117) * ToNum(sy_1123)) * (1D + FdLibm.Sin(an_1133)))))), ((V)(0D)), ((V)(Max(0.04, FdLibm.Cos(an_1133))))));
i_1131++;
}
}
return Call(solid_34, V.Undef, Object_assign(NewObj(9).Put("ax", ((V)("y"))).Put("sh", ((V)("el"))).Put("c", Arr(x_1114, z_1116)).Put("a", ((V)((ToNum(r_1117) * ToNum(sx_1122))))).Put("b", ((V)((ToNum(r_1117) * ToNum(sz_1124))))).Put("n", ((V)(12D))).Put("rings", rg_1126).Put("col", col_1118).Put("shine", ((V)(1D))).V, o_1120));
return default;
}, 6, "", true);
slab_39 = Fn((V _arrowThis1149, int _argc1134, V x_1140, V y_1141, V z_1142, V w_1143, V[] _rest1135) => {
V h_1144 = default;
V d_1145 = default;
V col_1146 = default;
V o_1148 = default;
h_1144 = (_argc1134 > 4 ? _rest1135[0] : V.Undef);
d_1145 = (_argc1134 > 5 ? _rest1135[1] : V.Undef);
col_1146 = (_argc1134 > 6 ? _rest1135[2] : V.Undef);
{ V _t1147 = (_argc1134 > 7 ? _rest1135[3] : V.Undef); if (_t1147.IsUndef) _t1147 = NewObj(0).V;
o_1148 = _t1147; }
return Call(solid_34, V.Undef, Object_assign(NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("rr"))).Put("c", Arr(x_1140, Add(y_1141, ((V)((ToNum(h_1144) / 2D)))))).Put("a", ((V)((ToNum(w_1143) / 2D)))).Put("b", ((V)((ToNum(h_1144) / 2D)))).Put("r", ((V)(8D))).Put("rb", ((V)(0D))).Put("rings", (Truthy(Get(o_1148, "soft")) ? Arr(Arr(((V)((ToNum(z_1142) - (ToNum(d_1145) / 2D)))), ((V)(2D))), Arr(((V)(((ToNum(z_1142) - (ToNum(d_1145) / 2D)) + 2D))), ((V)(0D))), Arr(((V)((ToNum(Add(z_1142, ((V)((ToNum(d_1145) / 2D))))) - 2D))), ((V)(0D))), Arr(Add(z_1142, ((V)((ToNum(d_1145) / 2D)))), ((V)(2D)))) : Arr(Arr(((V)((ToNum(z_1142) - (ToNum(d_1145) / 2D)))), ((V)(0D))), Arr(Add(z_1142, ((V)((ToNum(d_1145) / 2D)))), ((V)(0D)))))).Put("col", col_1146).V, o_1148));
}, 8, "", true);
slabX_40 = Fn((V _arrowThis1165, int _argc1150, V x_1156, V y_1157, V z_1158, V w_1159, V[] _rest1151) => {
V h_1160 = default;
V d_1161 = default;
V col_1162 = default;
V o_1164 = default;
h_1160 = (_argc1150 > 4 ? _rest1151[0] : V.Undef);
d_1161 = (_argc1150 > 5 ? _rest1151[1] : V.Undef);
col_1162 = (_argc1150 > 6 ? _rest1151[2] : V.Undef);
{ V _t1163 = (_argc1150 > 7 ? _rest1151[3] : V.Undef); if (_t1163.IsUndef) _t1163 = NewObj(0).V;
o_1164 = _t1163; }
return Call(solid_34, V.Undef, Object_assign(NewObj(8).Put("ax", ((V)("x"))).Put("sh", ((V)("rr"))).Put("c", Arr(z_1158, Add(y_1157, ((V)((ToNum(h_1160) / 2D)))))).Put("a", ((V)((ToNum(d_1161) / 2D)))).Put("b", ((V)((ToNum(h_1160) / 2D)))).Put("r", ((V)(3D))).Put("rings", Arr(Arr(((V)((ToNum(x_1156) - (ToNum(w_1159) / 2D)))), ((V)(0D))), Arr(Add(x_1156, ((V)((ToNum(w_1159) / 2D)))), ((V)(0D))))).Put("col", col_1162).V, o_1164));
}, 8, "", true);
arcW_41 = Fn((V _arrowThis1184, int _argc1166, V x_1172, V y_1173, V z_1174, V a_1175, V[] _rest1167) => {
V b_1176 = default;
V t_1177 = default;
V h_1178 = default;
V a0_1179 = default;
V a1_1180 = default;
V col_1181 = default;
V o_1183 = default;
b_1176 = (_argc1166 > 4 ? _rest1167[0] : V.Undef);
t_1177 = (_argc1166 > 5 ? _rest1167[1] : V.Undef);
h_1178 = (_argc1166 > 6 ? _rest1167[2] : V.Undef);
a0_1179 = (_argc1166 > 7 ? _rest1167[3] : V.Undef);
a1_1180 = (_argc1166 > 8 ? _rest1167[4] : V.Undef);
col_1181 = (_argc1166 > 9 ? _rest1167[5] : V.Undef);
{ V _t1182 = (_argc1166 > 10 ? _rest1167[6] : V.Undef); if (_t1182.IsUndef) _t1182 = NewObj(0).V;
o_1183 = _t1182; }
return Call(solid_34, V.Undef, Object_assign(NewObj(11).Put("ax", ((V)("y"))).Put("sh", ((V)("arc"))).Put("c", Arr(x_1172, z_1174)).Put("a", a_1175).Put("b", b_1176).Put("th", t_1177).Put("a0", a0_1179).Put("a1", a1_1180).Put("n", ((V)(5D))).Put("rings", Arr(Arr(y_1173, ((V)(0D))), Arr(Add(y_1173, h_1178), ((V)(0D))))).Put("col", col_1181).V, o_1183));
}, 11, "", true);
disc_42 = Fn((V _arrowThis1199, int _argc1185, V x_1191, V y_1192, V z_1193, V r_1194, V[] _rest1186) => {
V d_1195 = default;
V col_1196 = default;
V o_1198 = default;
d_1195 = (_argc1185 > 4 ? _rest1186[0] : V.Undef);
col_1196 = (_argc1185 > 5 ? _rest1186[1] : V.Undef);
{ V _t1197 = (_argc1185 > 6 ? _rest1186[2] : V.Undef); if (_t1197.IsUndef) _t1197 = NewObj(0).V;
o_1198 = _t1197; }
return Call(solid_34, V.Undef, Object_assign(NewObj(8).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(x_1191, y_1192)).Put("a", r_1194).Put("b", r_1194).Put("n", ((V)(14D))).Put("rings", Arr(Arr(z_1193, ((V)(0D))), Arr(Add(z_1193, d_1195), (Get(o_1198, "top") is var _t1200 && Truthy(_t1200) ? _t1200 : ((V)(0D)))))).Put("col", col_1196).V, o_1198));
}, 7, "", true);
pillowY_43 = Fn((V _arrowThis1216, int _argc1201, V x_1207, V y_1208, V z_1209, V w_1210, V[] _rest1202) => {
V hh_1211 = default;
V d_1212 = default;
V col_1213 = default;
V o_1215 = default;
hh_1211 = (_argc1201 > 4 ? _rest1202[0] : V.Undef);
d_1212 = (_argc1201 > 5 ? _rest1202[1] : V.Undef);
col_1213 = (_argc1201 > 6 ? _rest1202[2] : V.Undef);
{ V _t1214 = (_argc1201 > 7 ? _rest1202[3] : V.Undef); if (_t1214.IsUndef) _t1214 = NewObj(0).V;
o_1215 = _t1214; }
return Call(solid_34, V.Undef, Object_assign(NewObj(9).Put("ax", ((V)("y"))).Put("sh", ((V)("rr"))).Put("c", Arr(x_1207, z_1209)).Put("a", ((V)((ToNum(w_1210) / 2D)))).Put("b", ((V)((ToNum(d_1212) / 2D)))).Put("r", ((V)((Min(ToNum(w_1210), ToNum(d_1212)) * 0.3)))).Put("rings", Arr(Arr(y_1208, ((V)(4D)), ((V)(0.9))), Arr(Add(y_1208, ((V)(3D))), ((V)(0D)), ((V)(0.99))), Arr(((V)((ToNum(Add(y_1208, hh_1211)) - 5D))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(Add(y_1208, hh_1211)) - 1.5))), ((V)(4D)), ((V)(0.95))), Arr(Add(y_1208, hh_1211), ((V)(9D)), ((V)(0.82))))).Put("col", col_1213).Put("soft", ((V)(1D))).V, o_1215));
}, 8, "", true);
pillowZ_44 = Fn((V _arrowThis1232, int _argc1217, V x_1223, V y_1224, V z_1225, V w_1226, V[] _rest1218) => {
V hh_1227 = default;
V d_1228 = default;
V col_1229 = default;
V o_1231 = default;
hh_1227 = (_argc1217 > 4 ? _rest1218[0] : V.Undef);
d_1228 = (_argc1217 > 5 ? _rest1218[1] : V.Undef);
col_1229 = (_argc1217 > 6 ? _rest1218[2] : V.Undef);
{ V _t1230 = (_argc1217 > 7 ? _rest1218[3] : V.Undef); if (_t1230.IsUndef) _t1230 = NewObj(0).V;
o_1231 = _t1230; }
return Call(solid_34, V.Undef, Object_assign(NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("rr"))).Put("c", Arr(x_1223, Add(y_1224, ((V)((ToNum(hh_1227) / 2D)))))).Put("a", ((V)((ToNum(w_1226) / 2D)))).Put("b", ((V)((ToNum(hh_1227) / 2D)))).Put("r", ((V)((Min(ToNum(w_1226), ToNum(hh_1227)) * 0.4)))).Put("rings", Arr(Arr(((V)((ToNum(z_1225) - (ToNum(d_1228) / 2D)))), ((V)(5D)), ((V)(0.86))), Arr(((V)(((ToNum(z_1225) - (ToNum(d_1228) / 2D)) + 3D))), ((V)(0D)), ((V)(0.97))), Arr(((V)((ToNum(Add(z_1225, ((V)((ToNum(d_1228) / 2D))))) - 3D))), ((V)(0D)), ((V)(1D))), Arr(Add(z_1225, ((V)((ToNum(d_1228) / 2D)))), ((V)(5D)), ((V)(0.88))))).Put("col", col_1229).Put("soft", ((V)(1D))).V, o_1231));
}, 8, "", true);
legs4_45 = Fn((V _arrowThis1247, int _argc1233, V x_1239, V z_1240, V h_1241, V col_1242, V[] _rest1234) => {
V r_1244 = default;
V y_1246 = default;
{ V _t1243 = (_argc1233 > 4 ? _rest1234[0] : V.Undef); if (_t1243.IsUndef) _t1243 = ((V)(4D));
r_1244 = _t1243; }
{ V _t1245 = (_argc1233 > 5 ? _rest1234[1] : V.Undef); if (_t1245.IsUndef) _t1245 = ((V)(0D));
y_1246 = _t1245; }
return Arr(Call(cyl_37, V.Undef, ((V)((-ToNum(x_1239)))), y_1246, ((V)((-ToNum(z_1240)))), r_1244, h_1241, col_1242, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_37, V.Undef, x_1239, y_1246, ((V)((-ToNum(z_1240)))), r_1244, h_1241, col_1242, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_37, V.Undef, ((V)((-ToNum(x_1239)))), y_1246, z_1240, r_1244, h_1241, col_1242, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_37, V.Undef, x_1239, y_1246, z_1240, r_1244, h_1241, col_1242, NewObj(1).Put("n", ((V)(8D))).V));
}, 6, "", true);
quarters_46 = Fn((V _arrowThis1255, int _argc1248, V fn_1254, V _a1251, V _a1252, V _a1253, V[] _rest1249) => {
return Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "map", Fn((V _arrowThis1263, int _argc1256, V q_1262, V _a1259, V _a1260, V _a1261, V[] _rest1257) => {
return Call(fn_1254, V.Undef, ((V)(((ToNum(q_1262) * System.Math.PI) / 2D))), ((V)(((ToNum(Add(q_1262, ((V)(1D)))) * System.Math.PI) / 2D))));
}, 1, "", true));
}, 1, "", true);
CR_47 = ((V)("#fffaf1"));
WH_48 = ((V)("#ffffff"));
MT_49 = ((V)("#c9d3d8"));
GOLD_50 = ((V)("#e2b14a"));
NEON_51 = Arr(((V)("#4fe0d0")), ((V)("#ffd66b")), ((V)("#ff9d4a")), ((V)("#a6f06a")), ((V)("#6ac8ff")), ((V)("#8f7bff")));
FAB_52 = Arr(NewObj(2).Put("a", ((V)("#84b6c9"))).Put("b", ((V)("#e3946a"))).V, NewObj(2).Put("a", ((V)("#e3946a"))).Put("b", ((V)("#f2c255"))).V, NewObj(2).Put("a", ((V)("#9fc684"))).Put("b", ((V)("#fffaf1"))).V, NewObj(2).Put("a", ((V)("#f2c255"))).Put("b", ((V)("#84b6c9"))).V, NewObj(2).Put("a", ((V)("#8f86c9"))).Put("b", ((V)("#f2c255"))).V);
WOOD_53 = Arr(NewObj(3).Put("w", ((V)("#d49a60"))).Put("a", ((V)("#84b6c9"))).Put("b", ((V)("#e3946a"))).V, NewObj(3).Put("w", ((V)("#a86b36"))).Put("a", ((V)("#f2c255"))).Put("b", ((V)("#9fc684"))).V, NewObj(3).Put("w", ((V)("#f0d2a4"))).Put("a", ((V)("#9fc684"))).Put("b", ((V)("#84b6c9"))).V, NewObj(3).Put("w", ((V)("#e3946a"))).Put("a", ((V)("#fffaf1"))).Put("b", ((V)("#f2c255"))).V);
pal_54 = Fn((V _arrowThis1272, int _argc1264, V D_1270, V ci_1271, V _a1268, V _a1269, V[] _rest1265) => {
V c_1273 = default;
V a_1274 = default;
V b_1275 = default;
V w_1276 = default;
c_1273 = ((Get(D_1270, "cols") is var _t1277 && !Truthy(_t1277) ? _t1277 : GetIdx(Get(D_1270, "cols"), (ToNum(ci_1271) % ToNum(Get(Get(D_1270, "cols"), "length"))))) is var _t1278 && Truthy(_t1278) ? _t1278 : NewObj(0).V);
a_1274 = Call(mix_25, V.Undef, (Get(c_1273, "a") is var _t1279 && Truthy(_t1279) ? _t1279 : ((V)("#84b6c9"))), ((V)("#ffffff")), ((V)(0.1)));
b_1275 = Call(mix_25, V.Undef, (Get(c_1273, "b") is var _t1280 && Truthy(_t1280) ? _t1280 : ((V)("#f2c255"))), ((V)("#ffffff")), ((V)(0.08)));
w_1276 = Call(mix_25, V.Undef, (Get(c_1273, "w") is var _t1281 && Truthy(_t1281) ? _t1281 : ((V)("#d49a60"))), ((V)("#ffffff")), ((V)(0.1)));
return NewObj(11).Put("a", a_1274).Put("b", b_1275).Put("aL", Call(mix_25, V.Undef, a_1274, ((V)("#ffffff")), ((V)(0.22)))).Put("aD", Call(shade_24, V.Undef, a_1274, ((V)(0.86)))).Put("bL", Call(mix_25, V.Undef, b_1275, ((V)("#ffffff")), ((V)(0.2)))).Put("bD", Call(shade_24, V.Undef, b_1275, ((V)(0.86)))).Put("w", w_1276).Put("wD", Call(shade_24, V.Undef, w_1276, ((V)(0.76)))).Put("wL", Call(mix_25, V.Undef, w_1276, ((V)("#ffffff")), ((V)(0.25)))).Put("m", (Get(c_1273, "m") is var _t1282 && Truthy(_t1282) ? _t1282 : ((V)("#d5dde2")))).Put("c", c_1273).V;
return default;
}, 2, "", true);
FS_55 = 1.16;
GR_56 = ((Get(G("window"), "House3D") is var _t1283 && !Truthy(_t1283) ? _t1283 : Get(Get(G("window"), "House3D"), "_GR")) is var _t1284 && Truthy(_t1284) ? _t1284 : New(G("Map")));
HSL_58 = Fn((V _arrowThis1292, int _argc1285, V h_1291, V _a1288, V _a1289, V _a1290, V[] _rest1286) => {
V r_1293 = default;
V g_1294 = default;
V b_1295 = default;
double mx_1296 = 0;
double mn_1297 = 0;
double l_1298 = 0;
double d_1299 = 0;
double hh_1300 = 0;
double s_1301 = 0;
{ V _t1302 = Invoke(Call(hx_22, V.Undef, h_1291), "map", Fn((V _arrowThis1310, int _argc1303, V v_1309, V _a1306, V _a1307, V _a1308, V[] _rest1304) => {
return ((V)((ToNum(v_1309) / 255D)));
}, 1, "", true));
{ V _t1311 = ListOf(_t1302);
{ V _t1312 = GetIdx(_t1311, 0D);
r_1293 = _t1312; }
{ V _t1313 = GetIdx(_t1311, 1D);
g_1294 = _t1313; }
{ V _t1314 = GetIdx(_t1311, 2D);
b_1295 = _t1314; }
} }
mx_1296 = Max(ToNum(r_1293), ToNum(g_1294), ToNum(b_1295));
mn_1297 = Min(ToNum(r_1293), ToNum(g_1294), ToNum(b_1295));
l_1298 = ((mx_1296 + mn_1297) / 2D);
d_1299 = (mx_1296 - mn_1297);
hh_1300 = 0D;
s_1301 = 0D;
if ((d_1299 > 0.000001)) {
s_1301 = (d_1299 / (1D - System.Math.Abs(((2D * l_1298) - 1D))));
hh_1300 = (SEqN(r_1293, mx_1296) ? (((ToNum(g_1294) - ToNum(b_1295)) / d_1299) % 6D) : (SEqN(g_1294, mx_1296) ? (((ToNum(b_1295) - ToNum(r_1293)) / d_1299) + 2D) : (((ToNum(r_1293) - ToNum(g_1294)) / d_1299) + 4D)));
hh_1300 = (hh_1300 * 60D);
if ((hh_1300 < 0D)) {
hh_1300 = (hh_1300 + 360D);
}
}
return Arr(((V)(hh_1300)), ((V)(s_1301)), ((V)(l_1298)));
return default;
}, 1, "", true);
MATC_59 = New(G("Map"));
matOf_60 = Fn((V _arrowThis1322, int _argc1315, V S_1321, V _a1318, V _a1319, V _a1320, V[] _rest1316) => {
V c_1323 = default;
V h_1324 = default;
V s_1325 = default;
V l_1326 = default;
JsStrBuf m_1327 = null;
if (Truthy(Get(S_1321, "mat"))) {
return Get(S_1321, "mat");
}
if (Truthy(Get(S_1321, "emit"))) {
return ((V)("emit"));
}
if (Truthy((Get(S_1321, "shine") is var _t1328 && Truthy(_t1328) ? _t1328 : Get(S_1321, "org")))) {
return ((V)("gloss"));
}
if (Truthy(Get(S_1321, "soft"))) {
return ((V)("fab"));
}
c_1323 = Get(S_1321, "col");
if (Truthy(Invoke(MATC_59, "has", c_1323))) {
return Invoke(MATC_59, "get", c_1323);
}
{ V _t1329 = Call(HSL_58, V.Undef, c_1323);
{ V _t1330 = ListOf(_t1329);
{ V _t1331 = GetIdx(_t1330, 0D);
h_1324 = _t1331; }
{ V _t1332 = GetIdx(_t1330, 1D);
s_1325 = _t1332; }
{ V _t1333 = GetIdx(_t1330, 2D);
l_1326 = _t1333; }
} }
m_1327 = new JsStrBuf("paint");
if (LtN(s_1325, 0.18)) {
m_1327.Set((GtN(l_1326, 0.9) ? "cer" : (GtN(l_1326, 0.3) ? "metal" : "paint")));
} else {
if (((((GeN(h_1324, 38D) && LeN(h_1324, 54D)) && GtN(s_1325, 0.55)) && GtN(l_1326, 0.45)) && LtN(l_1326, 0.78))) {
m_1327.Set("metal");
} else {
if ((((((GeN(h_1324, 16D) && LeN(h_1324, 42D)) && GeN(s_1325, 0.2)) && LeN(s_1325, 0.62)) && GeN(l_1326, 0.22)) && LeN(l_1326, 0.72))) {
m_1327.Set("wood");
}
}
}
Invoke(MATC_59, "set", c_1323, ((V)(m_1327.Str)));
return ((V)(m_1327.Str));
return default;
}, 1, "", true);
TEX_61 = NewObj(4).Put("wood", ((V)("url(#mtWood) none"))).Put("fab", ((V)("url(#mtFab) none"))).Put("metal", ((V)("url(#mtMetal) none"))).Put("paint", ((V)("url(#mtPaint) none"))).V;
MDEFS_62 = ((V)(JsStrBuf.Begin().S("<pattern id=\"mtWood\" width=\"64\" height=\"14\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 3Q16 1.6 32 3.2T64 3M0 9.5Q20 11 40 9T64 9.8\" fill=\"none\" stroke=\"#3b1d08\" stroke-opacity=\"0.2\" stroke-width=\"0.8\"/><path d=\"M6 6.2q10-1.4 22 0M38 12.2q8 1 18-0.4\" fill=\"none\" stroke=\"#3b1d08\" stroke-opacity=\"0.13\" stroke-width=\"0.6\"/><path d=\"M0 5.6Q24 4.4 64 6\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.13\" stroke-width=\"0.7\"/><ellipse cx=\"50\" cy=\"6.4\" rx=\"2.6\" ry=\"1.2\" fill=\"none\" stroke=\"#3b1d08\" stroke-opacity=\"0.2\" stroke-width=\"0.6\"/></pattern>").S("<pattern id=\"mtFab\" width=\"5\" height=\"5\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 1.2H5M0 3.7H5\" stroke=\"#000000\" stroke-opacity=\"0.06\" stroke-width=\"1\"/><path d=\"M1.2 0V5M3.7 0V5\" stroke=\"#ffffff\" stroke-opacity=\"0.08\" stroke-width=\"0.9\"/></pattern>").S("<pattern id=\"mtMetal\" width=\"46\" height=\"5\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 1H30M8 3.4H46\" stroke=\"#ffffff\" stroke-opacity=\"0.24\" stroke-width=\"0.6\"/><path d=\"M14 2.2H40M0 4.4H12\" stroke=\"#000000\" stroke-opacity=\"0.08\" stroke-width=\"0.5\"/></pattern>").S("<pattern id=\"mtPaint\" width=\"14\" height=\"14\" patternUnits=\"userSpaceOnUse\"><circle cx=\"3\" cy=\"4\" r=\"0.7\" fill=\"#000000\" fill-opacity=\"0.08\"/><circle cx=\"10\" cy=\"2\" r=\"0.5\" fill=\"#ffffff\" fill-opacity=\"0.14\"/><circle cx=\"8\" cy=\"10\" r=\"0.8\" fill=\"#000000\" fill-opacity=\"0.06\"/><circle cx=\"12.5\" cy=\"12\" r=\"0.5\" fill=\"#ffffff\" fill-opacity=\"0.12\"/><circle cx=\"1.5\" cy=\"11\" r=\"0.6\" fill=\"#000000\" fill-opacity=\"0.07\"/></pattern>").S("<radialGradient id=\"mVol\" cx=\"34%\" cy=\"26%\" r=\"82%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.26\"/><stop offset=\"0.38\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.7\" stop-color=\"#1a0c04\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#1a0c04\" stop-opacity=\"0.3\"/></radialGradient>").End()));
grads_63 = Fn((V _arrowThis1341, int _argc1334, V ids_1340, V _a1337, V _a1338, V _a1339, V[] _rest1335) => {
V lin_1342 = default;
V rad_1343 = default;
lin_1342 = Arr();
rad_1343 = Arr();
Invoke(ids_1340, "forEach", Fn((V _arrowThis1351, int _argc1344, V id_1350, V _a1347, V _a1348, V _a1349, V[] _rest1345) => {
V g_1352 = default;
g_1352 = Invoke(GR_56, "get", id_1350);
if (!(Truthy(g_1352))) {
return default;
}
Invoke((SEqS(Get(g_1352, "t"), "R") ? rad_1343 : lin_1342), "push", (SEqS(Get(g_1352, "t"), "T") ? Object_assign(NewObj(2).Put("x2", ((V)("1"))).Put("y2", ((V)("0.7"))).V, g_1352) : Object_assign(NewObj(2).Put("x2", ((V)("0.85"))).Put("y2", ((V)("1"))).V, g_1352)));
return default;
}, 1, "", true));
return NewObj(2).Put("lin", lin_1342).Put("rad", rad_1343).V;
return default;
}, 1, "", true);
CACHE_64 = ((Get(G("window"), "House3D") is var _t1353 && !Truthy(_t1353) ? _t1353 : Get(Get(G("window"), "House3D"), "CACHE")) is var _t1354 && Truthy(_t1354) ? _t1354 : New(G("Map")));
seatXY_66 = Fn((V _arrowThis1364, int _argc1355, V D_1361, V rot_1362, V k_1363, V _a1360, V[] _rest1356) => {
V s_1365 = default;
double tr_1366 = 0;
double c_1367 = 0;
double sn_1368 = 0;
s_1365 = GetK(Get(D_1361, "seats"), k_1363);
tr_1366 = ((ToNum(rot_1362) * System.Math.PI) / 180D);
c_1367 = FdLibm.Cos(tr_1366);
sn_1368 = FdLibm.Sin(tr_1366);
return NewObj(5).Put("x", ((V)((((ToNum(Get(s_1365, "x")) * c_1367) + (ToNum(Get(s_1365, "z")) * sn_1368)) * FS_55)))).Put("z", ((V)(((((-ToNum(Get(s_1365, "x"))) * sn_1368) + (ToNum(Get(s_1365, "z")) * c_1367)) * FS_55)))).Put("h", ((V)((ToNum(Get(s_1365, "h")) * FS_55)))).Put("f", (Get(s_1365, "f") is var _t1369 && Truthy(_t1369) ? _t1369 : ((V)(0D)))).Put("k", (Get(s_1365, "k") is var _t1370 && Truthy(_t1370) ? _t1370 : Get(D_1361, "act"))).V;
return default;
}, 3, "", true);
useXY_67 = Fn((V _arrowThis1379, int _argc1371, V D_1377, V rot_1378, V _a1375, V _a1376, V[] _rest1372) => {
V u_1380 = default;
double tr_1381 = 0;
double c_1382 = 0;
double sn_1383 = 0;
u_1380 = Get(D_1377, "use");
tr_1381 = ((ToNum(rot_1378) * System.Math.PI) / 180D);
c_1382 = FdLibm.Cos(tr_1381);
sn_1383 = FdLibm.Sin(tr_1381);
return NewObj(3).Put("x", ((V)((((ToNum(Get(u_1380, "x")) * c_1382) + (ToNum(Get(u_1380, "z")) * sn_1383)) * FS_55)))).Put("z", ((V)(((((-ToNum(Get(u_1380, "x"))) * sn_1383) + (ToNum(Get(u_1380, "z")) * c_1382)) * FS_55)))).Put("inside", Get(u_1380, "inside")).V;
return default;
}, 2, "", true);
half_68 = Fn((V _arrowThis1392, int _argc1384, V D_1390, V rot_1391, V _a1388, V _a1389, V[] _rest1385) => {
double tr_1393 = 0;
double c_1394 = 0;
double s_1395 = 0;
tr_1393 = ((ToNum(rot_1391) * System.Math.PI) / 180D);
c_1394 = System.Math.Abs(FdLibm.Cos(tr_1393));
s_1395 = System.Math.Abs(FdLibm.Sin(tr_1393));
return NewObj(2).Put("hx", ((V)(((((ToNum(Get(D_1390, "w")) / 2D) * c_1394) + ((ToNum(Get(D_1390, "d")) / 2D) * s_1395)) * FS_55)))).Put("hz", ((V)(((((ToNum(Get(D_1390, "w")) / 2D) * s_1395) + ((ToNum(Get(D_1390, "d")) / 2D) * c_1394)) * FS_55)))).V;
return default;
}, 2, "", true);
prism_69 = Fn((V _arrowThis1408, int _argc1396, V x0_1402, V x1_1403, V pts_1404, V col_1405, V[] _rest1397) => {
V o_1407 = default;
{ V _t1406 = (_argc1396 > 4 ? _rest1397[0] : V.Undef); if (_t1406.IsUndef) _t1406 = NewObj(0).V;
o_1407 = _t1406; }
return Call(solid_34, V.Undef, Object_assign(NewObj(6).Put("ax", ((V)("x"))).Put("sh", ((V)("poly"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("pts", pts_1404).Put("rings", Arr(Arr(x0_1402, ((V)(0D))), Arr(x1_1403, ((V)(0D))))).Put("col", col_1405).V, o_1407));
}, 5, "", true);
prismZ_70 = Fn((V _arrowThis1421, int _argc1409, V z0_1415, V z1_1416, V pts_1417, V col_1418, V[] _rest1410) => {
V o_1420 = default;
{ V _t1419 = (_argc1409 > 4 ? _rest1410[0] : V.Undef); if (_t1419.IsUndef) _t1419 = NewObj(0).V;
o_1420 = _t1419; }
return Call(solid_34, V.Undef, Object_assign(NewObj(6).Put("ax", ((V)("z"))).Put("sh", ((V)("poly"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("pts", pts_1417).Put("rings", Arr(Arr(z0_1415, ((V)(0D))), Arr(z1_1416, ((V)(0D))))).Put("col", col_1418).V, o_1420));
}, 5, "", true);
CAT_71 = ((Get(G("window"), "House3D") is var _t1422 && !Truthy(_t1422) ? _t1422 : Get(Get(G("window"), "House3D"), "CAT")) is var _t1423 && Truthy(_t1423) ? _t1423 : NewObj(0).V);
Set(G("window"), "House3D", Object_assign((Get(G("window"), "House3D") is var _t1424 && Truthy(_t1424) ? _t1424 : NewObj(0).V), NewObj(22).Put("MDEFS", MDEFS_62).Put("matOf", matOf_60).Put("grads", grads_63).Put("FS", ((V)(FS_55))).Put("SA", ((V)(SA_9))).Put("CA", ((V)(CA_10))).Put("VW", ((V)(VW_13))).Put("FY0", ((V)(FY0_14))).Put("FY1", ((V)(FY1_15))).Put("sAt", sAt_18).Put("edge", edge_20).Put("edge0", edge0_19).Put("RM", RM_16).Put("CAT", CAT_71).Put("render", render_65).Put("seatXY", seatXY_66).Put("useXY", useXY_67).Put("half", half_68).Put("pal", pal_54).Put("CACHE", CACHE_64).Put("_GR", GR_56).Put("K", NewObj(27).Put("solid", solid_34).Put("box", box_35).Put("cush", cush_36).Put("cyl", cyl_37).Put("ball", ball_38).Put("slab", slab_39).Put("slabX", slabX_40).Put("arcW", arcW_41).Put("disc", disc_42).Put("pillowY", pillowY_43).Put("pillowZ", pillowZ_44).Put("legs4", legs4_45).Put("quarters", quarters_46).Put("mix", mix_25).Put("shade", shade_24).Put("prism", prism_69).Put("prismZ", prismZ_70).Put("hull", hull_30).Put("pathOf", pathOf_27).Put("circ", circ_28).Put("ell", ell_29).Put("f1", f1_21).Put("NEON", NEON_51).Put("CR", CR_47).Put("WH", WH_48).Put("MT", MT_49).Put("GOLD", GOLD_50).V).V));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
