// reno-plus10.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus10_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("play", "");
        public static void Run()
        {
Call(Named(boot_412 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V slab_11 = default;
V shade_12 = default;
V mix_13 = default;
V N_14 = default;
double PI_15 = 0;
V f1_16 = default;
V n4_17 = default;
V rep_18 = default;
V P2_19 = default;
V add_20 = default;
V sub_21 = default;
V mul_22 = default;
V dot_23 = default;
V cross_24 = default;
V nrm_25 = default;
V mtx_26 = default;
V hull_27 = default;
V pth_28 = default;
V hash_29 = default;
V rng_30 = default;
V isPlay_31 = default;
V B_32 = default;
V an_33 = default;
V at_34 = default;
V SPL_35 = default;
V FONT_36 = default;
V DEF10_37 = default;
double UID_38 = 0;
V cam_39 = default;
V lit_40 = default;
V vis_41 = default;
V FR_42 = default;
V tanF_43 = default;
V shadow_44 = default;
V yawA_45 = default;
V PAT_46 = default;
V I3_47 = default;
V box3_48 = default;
V CYS_49 = default;
V cyl3_50 = default;
V sph_51 = default;
V KV_52 = default;
V flip_53 = default;
V easeA_54 = default;
V mist_55 = default;
V CANS_56 = default;
V canTop_57 = default;
V can3_58 = default;
V PUFF_59 = default;
V puffAt_60 = default;
V OPEN_61 = default;
V edit9_62 = default;
if (_self1.IsNullish) _self1 = GlobalV;
cam_39 = Fn((V _self63, int _argc64, V ctx_70, V _a67, V _a68, V _a69, V[] _rest65) => {
V p0_71 = default;
V o_72 = default;
V e1_73 = default;
V e2_74 = default;
V e3_75 = default;
V Xr_76 = default;
V Yr_77 = default;
V v_78 = default;
V rt_79 = default;
V L_80 = default;
V C_81 = default;
if (_self63.IsNullish) _self63 = GlobalV;
p0_71 = Get(ctx_70, "p");
o_72 = Call(p0_71, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
e1_73 = Call(p0_71, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D)));
e2_74 = Call(p0_71, V.Undef, ((V)(0D)), ((V)(1D)), ((V)(0D)));
e3_75 = Call(p0_71, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(1D)));
Xr_76 = Arr(((V)((ToNum(GetIdx(e1_73, 0D)) - ToNum(GetIdx(o_72, 0D))))), ((V)((ToNum(GetIdx(e2_74, 0D)) - ToNum(GetIdx(o_72, 0D))))), ((V)((ToNum(GetIdx(e3_75, 0D)) - ToNum(GetIdx(o_72, 0D))))));
Yr_77 = Arr(((V)((ToNum(GetIdx(e1_73, 1D)) - ToNum(GetIdx(o_72, 1D))))), ((V)((ToNum(GetIdx(e2_74, 1D)) - ToNum(GetIdx(o_72, 1D))))), ((V)((ToNum(GetIdx(e3_75, 1D)) - ToNum(GetIdx(o_72, 1D))))));
v_78 = Call(nrm_25, V.Undef, Call(cross_24, V.Undef, Xr_76, Yr_77));
if (LtN(GetIdx(v_78, 1D), 0D)) {
v_78 = Call(mul_22, V.Undef, v_78, ((V)((-1D))));
}
rt_79 = Call(nrm_25, V.Undef, Arr(GetIdx(Xr_76, 0D), ((V)(0D)), GetIdx(Xr_76, 2D)));
L_80 = Call(nrm_25, V.Undef, Call(add_20, V.Undef, Call(add_20, V.Undef, Call(mul_22, V.Undef, rt_79, ((V)((-0.7)))), Arr(((V)(0D)), ((V)(1.2)), ((V)(0D)))), Call(mul_22, V.Undef, v_78, ((V)(0.55)))));
C_81 = NewObj(8).Put("v", v_78).Put("rt", rt_79).Put("L", L_80).Put("k", ((V)(Hypot(ToNum(GetIdx(Xr_76, 0D)), ToNum(GetIdx(Xr_76, 2D)))))).Put("id", ((V)(JsStrBuf.Begin().S("q").N(++UID_38).S("_").End()))).Put("n", ((V)(0D))).Put("b", Arr(((V)(1000000000D)), ((V)(1000000000D)), ((V)((-1000000000D))), ((V)((-1000000000D))))).Put("S", Get(ctx_70, "S")).V;
Set(C_81, "p", Fn((V _arrowThis91, int _argc82, V x_88, V y_89, V z_90, V _a87, V[] _rest83) => {
V q_92 = default;
q_92 = Call(p0_71, V.Undef, x_88, y_89, z_90);
if (Lt(GetIdx(q_92, 0D), GetIdx(Get(C_81, "b"), 0D))) {
SetIdx(Get(C_81, "b"), 0D, GetIdx(q_92, 0D));
}
if (Lt(GetIdx(q_92, 1D), GetIdx(Get(C_81, "b"), 1D))) {
SetIdx(Get(C_81, "b"), 1D, GetIdx(q_92, 1D));
}
if (Gt(GetIdx(q_92, 0D), GetIdx(Get(C_81, "b"), 2D))) {
SetIdx(Get(C_81, "b"), 2D, GetIdx(q_92, 0D));
}
if (Gt(GetIdx(q_92, 1D), GetIdx(Get(C_81, "b"), 3D))) {
SetIdx(Get(C_81, "b"), 3D, GetIdx(q_92, 1D));
}
return q_92;
return default;
}, 3, "", true));
Set(C_81, "P", Fn((V _arrowThis100, int _argc93, V q_99, V _a96, V _a97, V _a98, V[] _rest94) => {
return Invoke(C_81, "p", GetIdx(q_99, 0D), GetIdx(q_99, 1D), GetIdx(q_99, 2D));
}, 1, "", true));
Set(C_81, "bb", Fn((V _arrowThis108, int _argc101, V m_107, V _a104, V _a105, V _a106, V[] _rest102) => {
return Arr(((V)((ToNum(GetIdx(Get(C_81, "b"), 0D)) - ToNum(m_107)))), ((V)((ToNum(GetIdx(Get(C_81, "b"), 1D)) - ToNum(m_107)))), Add(GetIdx(Get(C_81, "b"), 2D), m_107), Add(GetIdx(Get(C_81, "b"), 3D), m_107));
}, 1, "", true));
Set(C_81, "u", Fn((V _arrowThis116, int _argc109, V s_115, V _a112, V _a113, V _a114, V[] _rest110) => {
return Add(Add(Get(C_81, "id"), s_115), ((V)(IncM(C_81, "n", 1D, true))));
}, 1, "", true));
Set(C_81, "thV", ((V)(FdLibm.Atan2(ToNum(GetIdx(v_78, 0D)), ToNum(GetIdx(v_78, 2D))))));
return C_81;
return default;
}, 1, "cam", false);
box3_48 = Fn((V _self117, int _argc118, V C_124, V o_125, V _a122, V _a123, V[] _rest119) => {
V A_126 = default;
V c_127 = default;
V w_128 = default;
V h_129 = default;
V d_130 = default;
double hw_131 = 0;
double hd_132 = 0;
double r_133 = 0;
V col_134 = default;
V dec_135 = default;
V skip_136 = default;
V F0_137 = default;
V P_138 = default;
V Vd_139 = default;
V pat_140 = default;
V tp_141 = default;
V op_142 = default;
V gl_143 = default;
JsStrBuf s_144 = null;
V rrp_145 = default;
V cap_146 = default;
if (_self117.IsNullish) _self117 = GlobalV;
A_126 = (Get(o_125, "ax") is var _t147 && Truthy(_t147) ? _t147 : I3_47);
c_127 = Get(o_125, "c");
w_128 = Get(o_125, "w");
h_129 = Get(o_125, "h");
d_130 = Get(o_125, "d");
hw_131 = (ToNum(w_128) / 2D);
hd_132 = (ToNum(d_130) / 2D);
r_133 = Max(0D, Min(ToNum((Get(o_125, "r") is var _t148 && Truthy(_t148) ? _t148 : ((V)(0D)))), (hw_131 - 0.05), (hd_132 - 0.05)));
col_134 = Get(o_125, "col");
dec_135 = (Get(o_125, "dec") is var _t149 && Truthy(_t149) ? _t149 : NewObj(0).V);
skip_136 = (Get(o_125, "skip") is var _t150 && Truthy(_t150) ? _t150 : NewObj(0).V);
F0_137 = (Get(o_125, "f") is var _t151 && Truthy(_t151) ? _t151 : ((V)(1D)));
P_138 = Fn((V _arrowThis161, int _argc152, V u_158, V v_159, V s_160, V _a157, V[] _rest153) => {
return Call(add_20, V.Undef, c_127, Call(add_20, V.Undef, Call(add_20, V.Undef, Call(mul_22, V.Undef, GetIdx(A_126, 0D), u_158), Call(mul_22, V.Undef, GetIdx(A_126, 1D), v_159)), Call(mul_22, V.Undef, GetIdx(A_126, 2D), s_160)));
}, 3, "", true);
Vd_139 = Call(mul_22, V.Undef, GetIdx(A_126, 1D), ((V)((-1D))));
pat_140 = GetK(PAT_46, Get(o_125, "mat"));
tp_141 = (SEq(Get(o_125, "tpat"), V.Undef) ? pat_140 : GetK(PAT_46, Get(o_125, "tpat")));
op_142 = ((V)((Get(o_125, "op").IsNullish ? "" : string.Concat(" opacity=\"", ToStr(Get(o_125, "op")), "\""))));
gl_143 = (Get(o_125, "gl") is var _t162 && Truthy(_t162) ? _t162 : ((V)(0D)));
s_144 = new JsStrBuf("");
if ((r_133 > 0.05)) {
Invoke(Arr(Arr(((V)(1D)), ((V)(1D)), ((V)(0D))), Arr(((V)(1D)), ((V)((-1D))), ((V)(1D))), Arr(((V)((-1D))), ((V)((-1D))), ((V)(2D))), Arr(((V)((-1D))), ((V)(1D)), ((V)(3D)))), "forEach", Fn((V _arrowThis176, int _argc163, V _a165, V _a166, V _a167, V _a168, V[] _rest164) => {
double cu_177 = 0;
double cs_178 = 0;
V su_171 = default;
V ss_173 = default;
V qd_175 = default;
{ V _t169 = ListOf(_a165);
{ V _t170 = GetIdx(_t169, 0D);
su_171 = _t170; }
{ V _t172 = GetIdx(_t169, 1D);
ss_173 = _t172; }
{ V _t174 = GetIdx(_t169, 2D);
qd_175 = _t174; }
}
cu_177 = (ToNum(su_171) * (hw_131 - r_133));
cs_178 = (ToNum(ss_173) * (hd_132 - r_133));
{
double i_179 = 0;
i_179 = 0D;
while (true) {
if (!((i_179 < 4D))) break;
double a0_181 = 0;
double a1_182 = 0;
double am_183 = 0;
V n_184 = default;
V q0_185 = default;
V q1_186 = default;
V fc_187 = default;
a0_181 = ((ToNum(Add(qd_175, ((V)((i_179 / 4D))))) * PI_15) / 2D);
a1_182 = ((ToNum(Add(qd_175, ((V)(((i_179 + 1D) / 4D))))) * PI_15) / 2D);
am_183 = ((a0_181 + a1_182) / 2D);
n_184 = Call(nrm_25, V.Undef, Call(add_20, V.Undef, Call(mul_22, V.Undef, GetIdx(A_126, 0D), ((V)(FdLibm.Sin(am_183)))), Call(mul_22, V.Undef, GetIdx(A_126, 2D), ((V)(FdLibm.Cos(am_183))))));
if (!(Truthy(Call(vis_41, V.Undef, C_124, n_184)))) {
goto _cont180;
}
q0_185 = Arr(((V)((cu_177 + (r_133 * FdLibm.Sin(a0_181))))), ((V)((cs_178 + (r_133 * FdLibm.Cos(a0_181))))));
q1_186 = Arr(((V)((cu_177 + (r_133 * FdLibm.Sin(a1_182))))), ((V)((cs_178 + (r_133 * FdLibm.Cos(a1_182))))));
fc_187 = Call(shade_12, V.Undef, col_134, ((V)((ToNum(Call(lit_40, V.Undef, C_124, n_184)) * ToNum(F0_137)))));
s_144.S(string.Concat("<path d=\"", ToStr(Call(pth_28, V.Undef, Invoke(Arr(Call(P_138, V.Undef, GetIdx(q0_185, 0D), h_129, GetIdx(q0_185, 1D)), Call(P_138, V.Undef, GetIdx(q1_186, 0D), h_129, GetIdx(q1_186, 1D)), Call(P_138, V.Undef, GetIdx(q1_186, 0D), ((V)(0D)), GetIdx(q1_186, 1D)), Call(P_138, V.Undef, GetIdx(q0_185, 0D), ((V)(0D)), GetIdx(q0_185, 1D))), "map", Get(C_124, "P")))), "\" fill=\"", ToStr(fc_187), "\" stroke=\"", ToStr(fc_187), "\" stroke-width=\"0.3\"", ToStr(op_142), "/>"));
_cont180: ;
i_179++;
}
}
return default;
}, 1, "", true));
}
Invoke(Arr(NewObj(5).Put("k", ((V)("f"))).Put("n", GetIdx(A_126, 2D)).Put("O", Call(P_138, V.Undef, ((V)((-hw_131))), h_129, ((V)(hd_132)))).Put("U", GetIdx(A_126, 0D)).Put("W", w_128).V, NewObj(5).Put("k", ((V)("r"))).Put("n", GetIdx(A_126, 0D)).Put("O", Call(P_138, V.Undef, ((V)(hw_131)), h_129, ((V)(hd_132)))).Put("U", Call(mul_22, V.Undef, GetIdx(A_126, 2D), ((V)((-1D))))).Put("W", d_130).V, NewObj(5).Put("k", ((V)("b"))).Put("n", Call(mul_22, V.Undef, GetIdx(A_126, 2D), ((V)((-1D))))).Put("O", Call(P_138, V.Undef, ((V)(hw_131)), h_129, ((V)((-hd_132))))).Put("U", Call(mul_22, V.Undef, GetIdx(A_126, 0D), ((V)((-1D))))).Put("W", w_128).V, NewObj(5).Put("k", ((V)("l"))).Put("n", Call(mul_22, V.Undef, GetIdx(A_126, 0D), ((V)((-1D))))).Put("O", Call(P_138, V.Undef, ((V)((-hw_131))), h_129, ((V)((-hd_132))))).Put("U", GetIdx(A_126, 2D)).Put("W", d_130).V), "forEach", Fn((V _arrowThis195, int _argc188, V F_194, V _a191, V _a192, V _a193, V[] _rest189) => {
V fc_196 = default;
double x0_197 = 0;
double W_198 = 0;
V ho_199 = default;
V shp_200 = default;
V fl_201 = default;
if (Truthy((GetK(skip_136, Get(F_194, "k")) is var _t202 && Truthy(_t202) ? _t202 : (!(Truthy(Call(vis_41, V.Undef, C_124, Get(F_194, "n")))) ? V.True : V.False)))) {
return default;
}
fc_196 = Call(shade_12, V.Undef, col_134, ((V)((ToNum(Call(lit_40, V.Undef, C_124, Get(F_194, "n"))) * ToNum(F0_137)))));
x0_197 = r_133;
W_198 = (ToNum(Get(F_194, "W")) - (2D * r_133));
ho_199 = (Get(o_125, "hole") is var _t203 && !Truthy(_t203) ? _t203 : GetK(Get(o_125, "hole"), Get(F_194, "k")));
shp_200 = ((V)(string.Concat(string.Concat("M", ToStr(Call(f1_16, V.Undef, ((V)(x0_197)))), " 0H", ToStr(Call(f1_16, V.Undef, ((V)((x0_197 + W_198))))), "V", ToStr(Call(f1_16, V.Undef, h_129)), "H", ToStr(Call(f1_16, V.Undef, ((V)(x0_197)))), "Z"), (Truthy(ho_199) ? string.Concat("M", ToStr(Call(f1_16, V.Undef, GetIdx(ho_199, 0D))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(ho_199, 1D))), "V", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(h_129) - ToNum(GetIdx(ho_199, 3D))))))), "H", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Get(F_194, "W")) - ToNum(GetIdx(ho_199, 2D))))))), "V", ToStr(Call(f1_16, V.Undef, GetIdx(ho_199, 1D))), "Z") : ""))));
fl_201 = Fn((V _arrowThis211, int _argc204, V u_210, V _a207, V _a208, V _a209, V[] _rest205) => {
return ((V)(string.Concat("<path d=\"", ToStr(shp_200), "\" fill=\"", ToStr(u_210), "\" fill-rule=\"evenodd\"/>")));
}, 1, "", true);
s_144.S(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_124, Get(F_194, "O"), Get(F_194, "U"), Vd_139)), "\"", ToStr(op_142), "><path d=\"", ToStr(shp_200), "\" fill=\"", ToStr(fc_196), "\" fill-rule=\"evenodd\"", (Truthy(ho_199) ? "" : string.Concat(" stroke=\"", ToStr(fc_196), "\" stroke-width=\"0.25\"")), "/>")).V(Call(fl_201, V.Undef, ((V)("url(#m10v)")))).V((Truthy(pat_140) ? Call(fl_201, V.Undef, ((V)(string.Concat("url(#", ToStr(pat_140), ")")))) : ((V)("")))).S((Truthy(gl_143) ? string.Concat("<g opacity=\"", ToStr(gl_143), "\">", ToStr(Call(fl_201, V.Undef, ((V)("url(#m10s)")))), "</g>") : "")).S((!SEqN(Get(o_125, "edge"), 0D) ? string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)(x0_197)))), " 0.3H", ToStr(Call(f1_16, V.Undef, ((V)((x0_197 + W_198))))), "\" stroke=\"#ffffff\" stroke-opacity=\"", ToStr((Get(o_125, "edge") is var _t212 && Truthy(_t212) ? _t212 : ((V)(0.35)))), "\" stroke-width=\"0.45\"/>") : "")).V((GetK(dec_135, Get(F_194, "k")) is var _t213 && Truthy(_t213) ? _t213 : ((V)("")))).S("</g>");
return default;
}, 1, "", true));
rrp_145 = Fn((V _arrowThis223, int _argc214, V W_220, V Dd_221, V th_222, V _a219, V[] _rest215) => {
return ((V)(string.Concat(string.Concat("M", ToStr(Call(f1_16, V.Undef, ((V)(r_133)))), " 0H", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(W_220) - r_133))))), "Q", ToStr(Call(f1_16, V.Undef, W_220)), " 0 ", ToStr(Call(f1_16, V.Undef, W_220)), " ", ToStr(Call(f1_16, V.Undef, ((V)(r_133)))), "V", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Dd_221) - r_133))))), "Q", ToStr(Call(f1_16, V.Undef, W_220)), " ", ToStr(Call(f1_16, V.Undef, Dd_221)), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(W_220) - r_133))))), " ", ToStr(Call(f1_16, V.Undef, Dd_221)), "H", ToStr(Call(f1_16, V.Undef, ((V)(r_133)))), "Q0 ", ToStr(Call(f1_16, V.Undef, Dd_221)), " 0 ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Dd_221) - r_133))))), "V", ToStr(Call(f1_16, V.Undef, ((V)(r_133)))), "Q0 0 ", ToStr(Call(f1_16, V.Undef, ((V)(r_133)))), " 0Z"), (Truthy(th_222) ? string.Concat("M", ToStr(th_222), " ", ToStr(th_222), "V", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Dd_221) - ToNum(th_222)))))), "H", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(W_220) - ToNum(th_222)))))), "V", ToStr(th_222), "Z") : ""))));
}, 3, "", true);
cap_146 = Fn((V _arrowThis234, int _argc224, V n_230, V M_231, V k_232, V th_233, V[] _rest225) => {
V fc_235 = default;
V sh_236 = default;
V fl_237 = default;
fc_235 = Call(shade_12, V.Undef, col_134, ((V)((ToNum(Call(lit_40, V.Undef, C_124, n_230)) * ToNum(F0_137)))));
sh_236 = Call(rrp_145, V.Undef, w_128, d_130, th_233);
fl_237 = Fn((V _arrowThis245, int _argc238, V u_244, V _a241, V _a242, V _a243, V[] _rest239) => {
return ((V)(string.Concat("<path d=\"", ToStr(sh_236), "\" fill=\"", ToStr(u_244), "\" fill-rule=\"evenodd\"/>")));
}, 1, "", true);
return ((V)(JsStrBuf.Begin().S(string.Concat("<g transform=\"", ToStr(M_231), "\"", ToStr(op_142), ">")).V(Call(fl_237, V.Undef, fc_235)).V(Call(fl_237, V.Undef, ((V)("url(#m10t)")))).V((Truthy(tp_141) ? Call(fl_237, V.Undef, ((V)(string.Concat("url(#", ToStr(tp_141), ")")))) : ((V)("")))).S((Truthy(gl_143) ? string.Concat("<g opacity=\"", ToStr(gl_143), "\">", ToStr(Call(fl_237, V.Undef, ((V)("url(#m10s)")))), "</g>") : "")).V((GetK(dec_135, k_232) is var _t246 && Truthy(_t246) ? _t246 : ((V)("")))).S("</g>").End()));
return default;
}, 4, "", true);
if (Truthy(((!(Truthy(Get(skip_136, "t"))) ? V.True : V.False) is var _t247 && !Truthy(_t247) ? _t247 : Call(vis_41, V.Undef, C_124, GetIdx(A_126, 1D))))) {
s_144.V(Call(cap_146, V.Undef, GetIdx(A_126, 1D), Call(FR_42, V.Undef, C_124, Call(P_138, V.Undef, ((V)((-hw_131))), h_129, ((V)((-hd_132)))), GetIdx(A_126, 0D), GetIdx(A_126, 2D)), ((V)("t")), (Get(o_125, "hole") is var _t248 && !Truthy(_t248) ? _t248 : Get(Get(o_125, "hole"), "t"))));
}
if (Truthy(((!(Truthy(Get(skip_136, "u"))) ? V.True : V.False) is var _t249 && !Truthy(_t249) ? _t249 : Call(vis_41, V.Undef, C_124, Call(mul_22, V.Undef, GetIdx(A_126, 1D), ((V)((-1D)))))))) {
s_144.V(Call(cap_146, V.Undef, Call(mul_22, V.Undef, GetIdx(A_126, 1D), ((V)((-1D)))), Call(FR_42, V.Undef, C_124, Call(P_138, V.Undef, ((V)((-hw_131))), ((V)(0D)), ((V)(hd_132))), GetIdx(A_126, 0D), Call(mul_22, V.Undef, GetIdx(A_126, 2D), ((V)((-1D))))), ((V)("u"))));
}
if (!SEqN(Get(o_125, "ol"), 0D)) {
V sec_250 = default;
V pts_251 = default;
sec_250 = ((r_133 > 0.05) ? Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis259, int _argc252, V i_258, V _a255, V _a256, V _a257, V[] _rest253) => {
double qd_260 = 0;
double a_261 = 0;
qd_260 = System.Math.Floor((ToNum(i_258) / 4D));
a_261 = (((qd_260 + ((ToNum(i_258) % 4D) / 3D)) * PI_15) / 2D);
return Arr(((V)(((ToNum(GetIdx(Arr(((V)(1D)), ((V)(1D)), ((V)((-1D))), ((V)((-1D)))), qd_260)) * (hw_131 - r_133)) + (r_133 * FdLibm.Sin(a_261))))), ((V)(((ToNum(GetIdx(Arr(((V)(1D)), ((V)((-1D))), ((V)((-1D))), ((V)(1D))), qd_260)) * (hd_132 - r_133)) + (r_133 * FdLibm.Cos(a_261))))));
return default;
}, 1, "", true)) : Arr(Arr(((V)(hw_131)), ((V)(hd_132))), Arr(((V)(hw_131)), ((V)((-hd_132)))), Arr(((V)((-hw_131))), ((V)((-hd_132)))), Arr(((V)((-hw_131))), ((V)(hd_132)))));
pts_251 = Arr();
Invoke(Arr(((V)(0D)), h_129), "forEach", Fn((V _arrowThis269, int _argc262, V v_268, V _a265, V _a266, V _a267, V[] _rest263) => {
return Invoke(sec_250, "forEach", Fn((V _arrowThis277, int _argc270, V q_276, V _a273, V _a274, V _a275, V[] _rest271) => {
return Invoke(pts_251, "push", Invoke(C_124, "P", Call(P_138, V.Undef, GetIdx(q_276, 0D), v_268, GetIdx(q_276, 1D))));
}, 1, "", true));
}, 1, "", true));
s_144.S(string.Concat("<path d=\"", ToStr(Call(pth_28, V.Undef, Call(hull_27, V.Undef, pts_251))), "\" fill=\"none\" stroke=\"", ToStr((Get(o_125, "olc") is var _t278 && Truthy(_t278) ? _t278 : Call(shade_12, V.Undef, col_134, ((V)(0.4))))), "\" stroke-width=\"", ToStr((Get(o_125, "olw") is var _t279 && Truthy(_t279) ? _t279 : ((V)(0.5)))), "\" stroke-opacity=\"", ToStr((Get(o_125, "olo") is var _t280 && Truthy(_t280) ? _t280 : ((V)(0.75)))), "\" stroke-linejoin=\"round\"/>"));
}
return ((V)(s_144.Str));
return default;
}, 2, "box3", false);
cyl3_50 = Fn((V _self281, int _argc282, V C_288, V a_289, V b_290, V r_291, V[] _rest283) => {
V r2_294 = default;
V dz_295 = default;
V @ref_296 = default;
V e1_297 = default;
V e2_298 = default;
V n_299 = default;
V ring_300 = default;
V RA_301 = default;
V RB_302 = default;
V A2_303 = default;
V B2_304 = default;
double dx_305 = 0;
double dy_306 = 0;
double dl_307 = 0;
double nx_308 = 0;
double ny_309 = 0;
double cx_310 = 0;
double cy_311 = 0;
V H_312 = default;
double m_313 = 0;
V id_314 = default;
V f0_315 = default;
V op_316 = default;
JsStrBuf s_317 = null;
V dv_318 = default;
V capB_319 = default;
V cn_320 = default;
V cq_321 = default;
V cr_322 = default;
V CR_323 = default;
V col_292 = default;
V o_293 = default;
if (_self281.IsNullish) _self281 = GlobalV;
col_292 = (_argc282 > 4 ? _rest283[0] : V.Undef);
o_293 = (_argc282 > 5 ? _rest283[1] : V.Undef);
o_293 = (o_293 is var _t324 && Truthy(_t324) ? _t324 : NewObj(0).V);
r2_294 = (Get(o_293, "r2").IsNullish ? r_291 : Get(o_293, "r2"));
dz_295 = Call(nrm_25, V.Undef, Call(sub_21, V.Undef, b_290, a_289));
@ref_296 = ((System.Math.Abs(ToNum(GetIdx(dz_295, 1D))) < 0.9) ? Arr(((V)(0D)), ((V)(1D)), ((V)(0D))) : Arr(((V)(1D)), ((V)(0D)), ((V)(0D))));
e1_297 = Call(nrm_25, V.Undef, Call(cross_24, V.Undef, dz_295, @ref_296));
e2_298 = Call(cross_24, V.Undef, dz_295, e1_297);
n_299 = (Get(o_293, "n") is var _t325 && Truthy(_t325) ? _t325 : ((V)(28D)));
ring_300 = Fn((V _arrowThis334, int _argc326, V q_332, V rr_333, V _a330, V _a331, V[] _rest327) => {
return Call(rep_18, V.Undef, n_299, Fn((V _arrowThis342, int _argc335, V i_341, V _a338, V _a339, V _a340, V[] _rest336) => {
double t_343 = 0;
t_343 = (((ToNum(i_341) / ToNum(n_299)) * 2D) * PI_15);
return Invoke(C_288, "P", Call(add_20, V.Undef, q_332, Call(add_20, V.Undef, Call(mul_22, V.Undef, e1_297, ((V)((FdLibm.Cos(t_343) * ToNum(rr_333))))), Call(mul_22, V.Undef, e2_298, ((V)((FdLibm.Sin(t_343) * ToNum(rr_333))))))));
return default;
}, 1, "", true));
}, 2, "", true);
RA_301 = Call(ring_300, V.Undef, a_289, r_291);
RB_302 = Call(ring_300, V.Undef, b_290, r2_294);
A2_303 = Invoke(C_288, "P", a_289);
B2_304 = Invoke(C_288, "P", b_290);
dx_305 = (ToNum(GetIdx(B2_304, 0D)) - ToNum(GetIdx(A2_303, 0D)));
dy_306 = (ToNum(GetIdx(B2_304, 1D)) - ToNum(GetIdx(A2_303, 1D)));
dl_307 = Hypot(dx_305, dy_306);
nx_308 = (-0.6);
ny_309 = (-0.8);
if ((dl_307 > 0.05)) {
nx_308 = ((-dy_306) / dl_307);
ny_309 = (dx_305 / dl_307);
if ((((nx_308 * (-0.6)) + (ny_309 * (-0.8))) < 0D)) {
nx_308 = (-nx_308);
ny_309 = (-ny_309);
}
}
cx_310 = (ToNum(Add(GetIdx(A2_303, 0D), GetIdx(B2_304, 0D))) / 2D);
cy_311 = (ToNum(Add(GetIdx(A2_303, 1D), GetIdx(B2_304, 1D))) / 2D);
H_312 = Call(hull_27, V.Undef, Invoke(RA_301, "concat", RB_302));
m_313 = 0.2;
Invoke(H_312, "forEach", Fn((V _arrowThis351, int _argc344, V q_350, V _a347, V _a348, V _a349, V[] _rest345) => {
return ((V)((m_313 = Max(m_313, System.Math.Abs((((ToNum(GetIdx(q_350, 0D)) - cx_310) * nx_308) + ((ToNum(GetIdx(q_350, 1D)) - cy_311) * ny_309)))))));
}, 1, "", true));
id_314 = Invoke(C_288, "u", ((V)("c")));
f0_315 = (Get(o_293, "f") is var _t352 && Truthy(_t352) ? _t352 : ((V)(1D)));
op_316 = ((V)((Get(o_293, "op").IsNullish ? "" : string.Concat(" opacity=\"", ToStr(Get(o_293, "op")), "\""))));
s_317 = new JsStrBuf(string.Concat("<defs><linearGradient id=\"", ToStr(id_314), "\" gradientUnits=\"userSpaceOnUse\" x1=\"", ToStr(Call(f1_16, V.Undef, ((V)((cx_310 + (nx_308 * m_313)))))), "\" y1=\"", ToStr(Call(f1_16, V.Undef, ((V)((cy_311 + (ny_309 * m_313)))))), "\" x2=\"", ToStr(Call(f1_16, V.Undef, ((V)((cx_310 - (nx_308 * m_313)))))), "\" y2=\"", ToStr(Call(f1_16, V.Undef, ((V)((cy_311 - (ny_309 * m_313)))))), "\">", ToStr(Invoke(Invoke((GetK(CYS_49, Get(o_293, "mat")) is var _t365 && Truthy(_t365) ? _t365 : Get(CYS_49, "plastic")), "map", Fn((V _arrowThis364, int _argc353, V _a355, V _a356, V _a357, V _a358, V[] _rest354) => {
V t_361 = default;
V f_363 = default;
{ V _t359 = ListOf(_a355);
{ V _t360 = GetIdx(_t359, 0D);
t_361 = _t360; }
{ V _t362 = GetIdx(_t359, 1D);
f_363 = _t362; }
}
return ((V)(string.Concat("<stop offset=\"", ToStr(t_361), "\" stop-color=\"", ToStr(Call(shade_12, V.Undef, col_292, ((V)((ToNum(f_363) * ToNum(f0_315)))))), "\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</linearGradient></defs>"));
if (!(Truthy(Get(o_293, "noSide")))) {
s_317.S(string.Concat("<path d=\"", ToStr(Call(pth_28, V.Undef, H_312)), "\" fill=\"url(#", ToStr(id_314), ")\"", ToStr(op_316), "/>")).S((Truthy(Get(o_293, "pat")) ? string.Concat("<path d=\"", ToStr(Call(pth_28, V.Undef, H_312)), "\" fill=\"url(#", ToStr(Get(o_293, "pat")), ")\"", ToStr(op_316), "/>") : ""));
}
dv_318 = Call(dot_23, V.Undef, dz_295, Get(C_288, "v"));
capB_319 = (GtN(dv_318, 0D) ? V.True : V.False);
cn_320 = (Truthy(capB_319) ? dz_295 : Call(mul_22, V.Undef, dz_295, ((V)((-1D)))));
cq_321 = (Truthy(capB_319) ? b_290 : a_289);
cr_322 = (Truthy(capB_319) ? r2_294 : r_291);
CR_323 = (Truthy(capB_319) ? RB_302 : RA_301);
if (((System.Math.Abs(ToNum(dv_318)) > 0.02) && !(Truthy(Get(o_293, "noCap"))))) {
s_317.S(string.Concat("<path d=\"", ToStr(Call(pth_28, V.Undef, CR_323)), "\" fill=\"", ToStr((Get(o_293, "capCol") is var _t366 && Truthy(_t366) ? _t366 : Call(shade_12, V.Undef, col_292, ((V)((ToNum(Call(lit_40, V.Undef, C_288, cn_320)) * ToNum(f0_315))))))), "\"", ToStr(op_316), "/><path d=\"", ToStr(Call(pth_28, V.Undef, CR_323)), "\" fill=\"url(#m10cap)\"", ToStr(op_316), "/>"));
if (Truthy(Get(o_293, "cap"))) {
V u_367 = default;
V w_368 = default;
u_367 = Call(sub_21, V.Undef, Get(C_288, "rt"), Call(mul_22, V.Undef, cn_320, Call(dot_23, V.Undef, Get(C_288, "rt"), cn_320)));
if ((Hypot(ToNum(GetIdx(u_367, 0D)), ToNum(GetIdx(u_367, 1D)), ToNum(GetIdx(u_367, 2D))) < 0.2)) {
u_367 = e1_297;
}
u_367 = Call(nrm_25, V.Undef, u_367);
w_368 = Call(nrm_25, V.Undef, Call(cross_24, V.Undef, cn_320, u_367));
if (Lt(GetIdx(Invoke(C_288, "P", Call(add_20, V.Undef, cq_321, w_368)), 1D), GetIdx(Invoke(C_288, "P", cq_321), 1D))) {
w_368 = Call(mul_22, V.Undef, w_368, ((V)((-1D))));
}
s_317.S(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_288, cq_321, u_367, w_368)), "\">", ToStr(Invoke(o_293, "cap", cr_322)), "</g>"));
}
}
if (!SEqN(Get(o_293, "ol"), 0D)) {
s_317.S(string.Concat("<path d=\"", ToStr(Call(pth_28, V.Undef, H_312)), "\" fill=\"none\" stroke=\"", ToStr((Get(o_293, "olc") is var _t369 && Truthy(_t369) ? _t369 : Call(shade_12, V.Undef, col_292, ((V)(0.4))))), "\" stroke-width=\"", ToStr((Get(o_293, "olw") is var _t370 && Truthy(_t370) ? _t370 : ((V)(0.45)))), "\" stroke-opacity=\"", ToStr((Get(o_293, "olo") is var _t371 && Truthy(_t371) ? _t371 : ((V)(0.7)))), "\" stroke-linejoin=\"round\"/>"));
}
return ((V)(s_317.Str));
return default;
}, 6, "cyl3", false);
sph_51 = Fn((V _self372, int _argc373, V C_379, V q_380, V r_381, V col_382, V[] _rest374) => {
V c_384 = default;
double R_385 = 0;
V id_386 = default;
V o_383 = default;
if (_self372.IsNullish) _self372 = GlobalV;
o_383 = (_argc373 > 4 ? _rest374[0] : V.Undef);
o_383 = (o_383 is var _t387 && Truthy(_t387) ? _t387 : NewObj(0).V);
c_384 = Invoke(C_379, "P", q_380);
R_385 = (ToNum(r_381) * ToNum(Get(C_379, "k")));
id_386 = Invoke(C_379, "u", ((V)("s")));
Invoke(C_379, "p", ((V)((ToNum(GetIdx(q_380, 0D)) - ToNum(r_381)))), ((V)((ToNum(GetIdx(q_380, 1D)) - ToNum(r_381)))), GetIdx(q_380, 2D));
Invoke(C_379, "p", Add(GetIdx(q_380, 0D), r_381), Add(GetIdx(q_380, 1D), r_381), GetIdx(q_380, 2D));
return ((V)(string.Concat("<defs><radialGradient id=\"", ToStr(id_386), "\" cx=\"36%\" cy=\"30%\" r=\"72%\"><stop offset=\"0\" stop-color=\"", ToStr(Call(shade_12, V.Undef, col_382, ((V)(1.55)))), "\"/><stop offset=\"0.3\" stop-color=\"", ToStr(Call(shade_12, V.Undef, col_382, ((V)(1.08)))), "\"/><stop offset=\"0.75\" stop-color=\"", ToStr(Call(shade_12, V.Undef, col_382, ((V)(0.72)))), "\"/><stop offset=\"1\" stop-color=\"", ToStr(Call(shade_12, V.Undef, col_382, ((V)(0.5)))), "\"/></radialGradient></defs><circle cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_384, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_384, 1D))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)(R_385)))), "\" fill=\"url(#", ToStr(id_386), ")\"", (!Get(o_383, "op").IsNullish ? string.Concat(" opacity=\"", ToStr(Get(o_383, "op")), "\"") : ""), "/>")));
return default;
}, 5, "sph", false);
can3_58 = Fn((V _self388, int _argc389, V C_395, V x_396, V y_397, V z_398, V[] _rest390) => {
V c_402 = default;
V b_403 = default;
V th_404 = default;
V r_399 = default;
V h_400 = default;
V ci_401 = default;
if (_self388.IsNullish) _self388 = GlobalV;
r_399 = (_argc389 > 4 ? _rest390[0] : V.Undef);
h_400 = (_argc389 > 5 ? _rest390[1] : V.Undef);
ci_401 = (_argc389 > 6 ? _rest390[2] : V.Undef);
{ V _t405 = GetIdx(CANS_56, (ToNum(ci_401) % ToNum(Get(CANS_56, "length"))));
{ V _t406 = ListOf(_t405);
{ V _t407 = GetIdx(_t406, 0D);
c_402 = _t407; }
{ V _t408 = GetIdx(_t406, 1D);
b_403 = _t408; }
} }
th_404 = Get(C_395, "thV");
return ((V)(JsStrBuf.Begin().V(Add(Call(cyl3_50, V.Undef, C_395, Arr(x_396, y_397, z_398), Arr(x_396, Add(y_397, h_400), z_398), r_399, c_402, NewObj(3).Put("mat", ((V)("gloss"))).Put("cap", canTop_57).Put("olw", ((V)(0.35))).V), Call(cyl3_50, V.Undef, C_395, Arr(x_396, ((V)((ToNum(Add(y_397, h_400)) - 0.2))), z_398), Arr(x_396, Add(Add(y_397, h_400), ((V)(0.5))), z_398), ((V)((ToNum(r_399) * 0.86))), ((V)("#c9ced2")), NewObj(3).Put("mat", ((V)("chrome"))).Put("noCap", ((V)(1D))).Put("olw", ((V)(0.25))).V))).S(string.Concat("<g transform=\"", ToStr(Call(tanF_43, V.Undef, C_395, x_396, z_398, r_399, th_404, Add(y_397, ((V)((ToNum(h_400) * 0.62)))))), "\"><path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(r_399)) * 0.9))))), " 0q", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_399) * 0.45))))), " -1.2 ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_399) * 0.9))))), " 0t", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_399) * 0.9))))), " 0\" stroke=\"", ToStr(b_403), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(h_400) * 0.08))))), "\" fill=\"none\" opacity=\"0.9\"/></g>")).End()));
return default;
}, 7, "can3", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((RD_8 is var _t409 && !Truthy(_t409) ? _t409 : Get(RD_8, "PLUS9")) is var _t410 && !Truthy(_t410) ? _t410 : X_9) is var _t411 && !Truthy(_t411) ? _t411 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_412.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS10"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t413 = K_10;
if (_t413.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t413));
{ V _t414 = Get(_t413, "slab");
slab_11 = _t414; }
{ V _t415 = Get(_t413, "shade");
shade_12 = _t415; }
{ V _t416 = Get(_t413, "mix");
mix_13 = _t416; } }
N_14 = Get(RD_8, "N");
PI_15 = System.Math.PI;
f1_16 = Fn((V _arrowThis424, int _argc417, V v_423, V _a420, V _a421, V _a422, V[] _rest418) => {
return ((V)((Round((ToNum(v_423) * 100D)) / 100D)));
}, 1, "", true);
n4_17 = Fn((V _arrowThis432, int _argc425, V v_431, V _a428, V _a429, V _a430, V[] _rest426) => {
return ((V)((Round((ToNum(v_431) * 10000D)) / 10000D)));
}, 1, "", true);
rep_18 = Fn((V _arrowThis441, int _argc433, V n_439, V f_440, V _a437, V _a438, V[] _rest434) => {
return Array_from(NewObj(1).Put("length", n_439).V, Fn((V _arrowThis450, int _argc442, V __448, V i_449, V _a446, V _a447, V[] _rest443) => {
return Call(f_440, V.Undef, i_449);
}, 2, "", true));
}, 2, "", true);
P2_19 = Fn((V _arrowThis458, int _argc451, V q_457, V _a454, V _a455, V _a456, V[] _rest452) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, GetIdx(q_457, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(q_457, 1D))).End()));
}, 1, "", true);
add_20 = Fn((V _arrowThis467, int _argc459, V a_465, V b_466, V _a463, V _a464, V[] _rest460) => {
return Arr(Add(GetIdx(a_465, 0D), GetIdx(b_466, 0D)), Add(GetIdx(a_465, 1D), GetIdx(b_466, 1D)), Add(GetIdx(a_465, 2D), GetIdx(b_466, 2D)));
}, 2, "", true);
sub_21 = Fn((V _arrowThis476, int _argc468, V a_474, V b_475, V _a472, V _a473, V[] _rest469) => {
return Arr(((V)((ToNum(GetIdx(a_474, 0D)) - ToNum(GetIdx(b_475, 0D))))), ((V)((ToNum(GetIdx(a_474, 1D)) - ToNum(GetIdx(b_475, 1D))))), ((V)((ToNum(GetIdx(a_474, 2D)) - ToNum(GetIdx(b_475, 2D))))));
}, 2, "", true);
mul_22 = Fn((V _arrowThis485, int _argc477, V a_483, V s_484, V _a481, V _a482, V[] _rest478) => {
return Arr(((V)((ToNum(GetIdx(a_483, 0D)) * ToNum(s_484)))), ((V)((ToNum(GetIdx(a_483, 1D)) * ToNum(s_484)))), ((V)((ToNum(GetIdx(a_483, 2D)) * ToNum(s_484)))));
}, 2, "", true);
dot_23 = Fn((V _arrowThis494, int _argc486, V a_492, V b_493, V _a490, V _a491, V[] _rest487) => {
return ((V)((((ToNum(GetIdx(a_492, 0D)) * ToNum(GetIdx(b_493, 0D))) + (ToNum(GetIdx(a_492, 1D)) * ToNum(GetIdx(b_493, 1D)))) + (ToNum(GetIdx(a_492, 2D)) * ToNum(GetIdx(b_493, 2D))))));
}, 2, "", true);
cross_24 = Fn((V _arrowThis503, int _argc495, V a_501, V b_502, V _a499, V _a500, V[] _rest496) => {
return Arr(((V)(((ToNum(GetIdx(a_501, 1D)) * ToNum(GetIdx(b_502, 2D))) - (ToNum(GetIdx(a_501, 2D)) * ToNum(GetIdx(b_502, 1D)))))), ((V)(((ToNum(GetIdx(a_501, 2D)) * ToNum(GetIdx(b_502, 0D))) - (ToNum(GetIdx(a_501, 0D)) * ToNum(GetIdx(b_502, 2D)))))), ((V)(((ToNum(GetIdx(a_501, 0D)) * ToNum(GetIdx(b_502, 1D))) - (ToNum(GetIdx(a_501, 1D)) * ToNum(GetIdx(b_502, 0D)))))));
}, 2, "", true);
nrm_25 = Fn((V _arrowThis511, int _argc504, V a_510, V _a507, V _a508, V _a509, V[] _rest505) => {
V l_512 = default;
l_512 = (((V)(Hypot(ToNum(GetIdx(a_510, 0D)), ToNum(GetIdx(a_510, 1D)), ToNum(GetIdx(a_510, 2D))))) is var _t513 && Truthy(_t513) ? _t513 : ((V)(1D)));
return Arr(((V)((ToNum(GetIdx(a_510, 0D)) / ToNum(l_512)))), ((V)((ToNum(GetIdx(a_510, 1D)) / ToNum(l_512)))), ((V)((ToNum(GetIdx(a_510, 2D)) / ToNum(l_512)))));
return default;
}, 1, "", true);
mtx_26 = Fn((V _arrowThis523, int _argc514, V o_520, V a_521, V b_522, V _a519, V[] _rest515) => {
return ((V)(JsStrBuf.Begin().S("matrix(").V(Invoke(Invoke(Arr(((V)((ToNum(GetIdx(a_521, 0D)) - ToNum(GetIdx(o_520, 0D))))), ((V)((ToNum(GetIdx(a_521, 1D)) - ToNum(GetIdx(o_520, 1D))))), ((V)((ToNum(GetIdx(b_522, 0D)) - ToNum(GetIdx(o_520, 0D))))), ((V)((ToNum(GetIdx(b_522, 1D)) - ToNum(GetIdx(o_520, 1D))))), GetIdx(o_520, 0D), GetIdx(o_520, 1D)), "map", n4_17), "join", ((V)(" ")))).S(")").End()));
}, 3, "", true);
hull_27 = Fn((V _arrowThis531, int _argc524, V P_530, V _a527, V _a528, V _a529, V[] _rest525) => {
V a_532 = default;
V cr_533 = default;
V lo_534 = default;
V up_535 = default;
a_532 = Invoke(Invoke(P_530, "slice"), "sort", Fn((V _arrowThis544, int _argc536, V p_542, V q_543, V _a540, V _a541, V[] _rest537) => {
return (((V)((ToNum(GetIdx(p_542, 0D)) - ToNum(GetIdx(q_543, 0D))))) is var _t545 && Truthy(_t545) ? _t545 : ((V)((ToNum(GetIdx(p_542, 1D)) - ToNum(GetIdx(q_543, 1D))))));
}, 2, "", true));
if (LtN(Get(a_532, "length"), 3D)) {
return a_532;
}
cr_533 = Fn((V _arrowThis555, int _argc546, V o_552, V p_553, V q_554, V _a551, V[] _rest547) => {
return ((V)((((ToNum(GetIdx(p_553, 0D)) - ToNum(GetIdx(o_552, 0D))) * (ToNum(GetIdx(q_554, 1D)) - ToNum(GetIdx(o_552, 1D)))) - ((ToNum(GetIdx(p_553, 1D)) - ToNum(GetIdx(o_552, 1D))) * (ToNum(GetIdx(q_554, 0D)) - ToNum(GetIdx(o_552, 0D)))))));
}, 3, "", true);
lo_534 = Arr();
up_535 = Arr();
{
foreach (V _k556 in new JsIter(a_532)) {
V q_557 = default;
q_557 = _k556;
while ((GeN(Get(lo_534, "length"), 2D) && LeN(Call(cr_533, V.Undef, GetIdx(lo_534, (ToNum(Get(lo_534, "length")) - 2D)), GetIdx(lo_534, (ToNum(Get(lo_534, "length")) - 1D)), q_557), 0D))) {
Invoke(lo_534, "pop");
}
Invoke(lo_534, "push", q_557);
}
}
{
double i_558 = 0;
i_558 = (ToNum(Get(a_532, "length")) - 1D);
while (true) {
if (!((i_558 >= 0D))) break;
V q_560 = default;
q_560 = GetIdx(a_532, i_558);
while ((GeN(Get(up_535, "length"), 2D) && LeN(Call(cr_533, V.Undef, GetIdx(up_535, (ToNum(Get(up_535, "length")) - 2D)), GetIdx(up_535, (ToNum(Get(up_535, "length")) - 1D)), q_560), 0D))) {
Invoke(up_535, "pop");
}
Invoke(up_535, "push", q_560);
i_558--;
}
}
return Invoke(Invoke(lo_534, "slice", ((V)(0D)), ((V)((-1D)))), "concat", Invoke(up_535, "slice", ((V)(0D)), ((V)((-1D)))));
return default;
}, 1, "", true);
pth_28 = Fn((V _arrowThis568, int _argc561, V P_567, V _a564, V _a565, V _a566, V[] _rest562) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(P_567, "map", P2_19), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
hash_29 = Fn((V _arrowThis576, int _argc569, V s_575, V _a572, V _a573, V _a574, V[] _rest570) => {
double h_577 = 0;
h_577 = 7D;
{
foreach (V _k578 in new JsIter(((V)(ToStrS(s_575))))) {
V ch_579 = default;
ch_579 = _k578;
h_577 = ((double)(ToInt32(ToNum(Add(((V)((h_577 * 31D))), Invoke(ch_579, "charCodeAt", ((V)(0D)))))) | ToInt32(0D)));
}
}
return ((V)(System.Math.Abs(h_577)));
return default;
}, 1, "", true);
rng_30 = Fn((V _arrowThis587, int _argc580, V s_586, V _a583, V _a584, V _a585, V[] _rest581) => {
V h_588 = default;
h_588 = (Call(hash_29, V.Undef, s_586) is var _t589 && Truthy(_t589) ? _t589 : ((V)(1D)));
return Fn((V _arrowThis596, int _argc590, V _a592, V _a593, V _a594, V _a595, V[] _rest591) => {
h_588 = ((V)(((double)(ToInt32(((ToNum(h_588) * 1103515245D) + 12345D)) | ToInt32(0D)))));
return ((V)((((double)(ToInt32(((double)(ToUint32(ToNum(h_588)) >> (int)(ToUint32(8D) & 31)))) & ToInt32(65535D))) / 65536D)));
return default;
}, 0, "", true);
return default;
}, 1, "", true);
isPlay_31 = Fn((V _arrowThis604, int _argc597, V S_603, V _a600, V _a601, V _a602, V[] _rest598) => {
return Invoke(NewRegExp(RX0, "play", ""), "test", (Get(S_603, "st") is var _t605 && Truthy(_t605) ? _t605 : ((V)(""))));
}, 1, "", true);
B_32 = Fn((V _arrowThis613, int _argc606, V b_612, V _a609, V _a610, V _a611, V[] _rest607) => {
return ((V)((Truthy(b_612) ? string.Concat(" begin=\"", ToStr(Call(n4_17, V.Undef, b_612)), "s\"") : "")));
}, 1, "", true);
an_33 = Fn((V _arrowThis625, int _argc614, V a_620, V v_621, V d_622, V b_623, V[] _rest615) => {
V x_624 = default;
x_624 = (_argc614 > 4 ? _rest615[0] : V.Undef);
return ((V)(string.Concat("<animate attributeName=\"", ToStr(a_620), "\" values=\"", ToStr(v_621), "\" dur=\"", ToStr(Call(n4_17, V.Undef, d_622)), "s\"", ToStr(Call(B_32, V.Undef, b_623)), " repeatCount=\"indefinite\"", ToStr((x_624 is var _t626 && Truthy(_t626) ? _t626 : ((V)("")))), "/>")));
}, 5, "", true);
at_34 = Fn((V _arrowThis638, int _argc627, V t_633, V v_634, V d_635, V b_636, V[] _rest628) => {
V x_637 = default;
x_637 = (_argc627 > 4 ? _rest628[0] : V.Undef);
return ((V)(string.Concat("<animateTransform attributeName=\"transform\" type=\"", ToStr(t_633), "\" values=\"", ToStr(v_634), "\" dur=\"", ToStr(Call(n4_17, V.Undef, d_635)), "s\"", ToStr(Call(B_32, V.Undef, b_636)), " repeatCount=\"indefinite\"", ToStr((x_637 is var _t639 && Truthy(_t639) ? _t639 : ((V)("")))), "/>")));
}, 5, "", true);
SPL_35 = Fn((V _arrowThis647, int _argc640, V n_646, V _a643, V _a644, V _a645, V[] _rest641) => {
return ((V)(string.Concat(" calcMode=\"spline\" keyTimes=\"", ToStr(Invoke(Call(rep_18, V.Undef, Add(n_646, ((V)(1D))), Fn((V _arrowThis655, int _argc648, V i_654, V _a651, V _a652, V _a653, V[] _rest649) => {
return Call(n4_17, V.Undef, ((V)((ToNum(i_654) / ToNum(n_646)))));
}, 1, "", true)), "join", ((V)(";")))), "\" keySplines=\"", ToStr(Invoke(Call(rep_18, V.Undef, n_646, Fn((V _arrowThis662, int _argc656, V _a658, V _a659, V _a660, V _a661, V[] _rest657) => {
return ((V)("0.45 0 0.55 1"));
}, 0, "", true)), "join", ((V)(";")))), "\"")));
}, 1, "", true);
FONT_36 = ((V)("font-family=\"Arial,Helvetica,sans-serif\" font-weight=\"700\""));
DEF10_37 = ((V)(JsStrBuf.Begin().S("<linearGradient id=\"m10v\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.13\"/><stop offset=\"0.45\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.22\"/></linearGradient>").S("<linearGradient id=\"m10t\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.2\"/><stop offset=\"0.55\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.1\"/></linearGradient>").S("<linearGradient id=\"m10s\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0.6\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.3\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.36\" stop-color=\"#ffffff\" stop-opacity=\"0.34\"/><stop offset=\"0.44\" stop-color=\"#ffffff\" stop-opacity=\"0.05\"/><stop offset=\"0.52\" stop-color=\"#ffffff\" stop-opacity=\"0.17\"/><stop offset=\"0.58\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>").S("<linearGradient id=\"m10in\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"0.04\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.38\"/></linearGradient>").S("<radialGradient id=\"m10sh\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"0.45\"/><stop offset=\"0.55\" stop-color=\"#000000\" stop-opacity=\"0.18\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0\"/></radialGradient>").S("<radialGradient id=\"m10cap\" cx=\"38%\" cy=\"32%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.32\"/><stop offset=\"0.6\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.16\"/></radialGradient>").S("<radialGradient id=\"m10cold\" cx=\"45%\" cy=\"25%\" r=\"80%\"><stop offset=\"0\" stop-color=\"#e8f8ff\" stop-opacity=\"0.75\"/><stop offset=\"0.5\" stop-color=\"#bfe8ff\" stop-opacity=\"0.2\"/><stop offset=\"1\" stop-color=\"#bfe8ff\" stop-opacity=\"0\"/></radialGradient>").S("<pattern id=\"m10foam\" width=\"2.6\" height=\"2.3\" patternUnits=\"userSpaceOnUse\"><circle cx=\"0.7\" cy=\"0.6\" r=\"0.62\" fill=\"none\" stroke=\"#6a6250\" stroke-opacity=\"0.16\" stroke-width=\"0.18\"/><circle cx=\"2\" cy=\"1.75\" r=\"0.6\" fill=\"none\" stroke=\"#6a6250\" stroke-opacity=\"0.13\" stroke-width=\"0.18\"/><circle cx=\"0.55\" cy=\"0.45\" r=\"0.22\" fill=\"#ffffff\" fill-opacity=\"0.7\"/><circle cx=\"1.85\" cy=\"1.6\" r=\"0.2\" fill=\"#ffffff\" fill-opacity=\"0.6\"/></pattern>").S("<pattern id=\"m10mesh\" width=\"1.1\" height=\"1.1\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 0.28H1.1M0 0.83H1.1\" stroke=\"#000000\" stroke-opacity=\"0.35\" stroke-width=\"0.22\"/><path d=\"M0.28 0V1.1M0.83 0V1.1\" stroke=\"#ffffff\" stroke-opacity=\"0.07\" stroke-width=\"0.22\"/></pattern>").S("<pattern id=\"m10perf\" width=\"1.7\" height=\"1.5\" patternUnits=\"userSpaceOnUse\"><circle cx=\"0.85\" cy=\"0.75\" r=\"0.42\" fill=\"#0a0a0c\" fill-opacity=\"0.8\"/><circle cx=\"0.7\" cy=\"0.62\" r=\"0.14\" fill=\"#ffffff\" fill-opacity=\"0.25\"/></pattern>").S("<pattern id=\"m10brush\" width=\"30\" height=\"1.6\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 0.4H18M6 1.2H30\" stroke=\"#ffffff\" stroke-opacity=\"0.2\" stroke-width=\"0.25\"/><path d=\"M12 0.8H28\" stroke=\"#000000\" stroke-opacity=\"0.08\" stroke-width=\"0.25\"/></pattern>").S("<pattern id=\"m10noise\" width=\"5\" height=\"5\" patternUnits=\"userSpaceOnUse\"><circle cx=\"1\" cy=\"1.4\" r=\"0.25\" fill=\"#000000\" fill-opacity=\"0.07\"/><circle cx=\"3.6\" cy=\"0.8\" r=\"0.2\" fill=\"#ffffff\" fill-opacity=\"0.12\"/><circle cx=\"2.6\" cy=\"3.5\" r=\"0.28\" fill=\"#000000\" fill-opacity=\"0.06\"/><circle cx=\"4.4\" cy=\"4.1\" r=\"0.18\" fill=\"#ffffff\" fill-opacity=\"0.1\"/><circle cx=\"0.6\" cy=\"4.2\" r=\"0.2\" fill=\"#000000\" fill-opacity=\"0.05\"/></pattern>").S("<radialGradient id=\"m10mst\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.9\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.45\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></radialGradient>").S("<filter id=\"m10b1\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"0.9\"/></filter><filter id=\"m10b2\" x=\"-60%\" y=\"-60%\" width=\"220%\" height=\"220%\"><feGaussianBlur stdDeviation=\"2.2\"/></filter><filter id=\"m10b3\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"3.2\"/></filter>").End()));
UID_38 = 0D;
lit_40 = Fn((V _arrowThis671, int _argc663, V C_669, V n_670, V _a667, V _a668, V[] _rest664) => {
return ((V)(Max(0.4, Min(1.22, ((0.5 + (0.56 * Max(0D, ToNum(Call(dot_23, V.Undef, n_670, Get(C_669, "L")))))) + (0.12 * Max(0D, ToNum(Call(dot_23, V.Undef, n_670, Get(C_669, "v"))))))))));
}, 2, "", true);
vis_41 = Fn((V _arrowThis680, int _argc672, V C_678, V n_679, V _a676, V _a677, V[] _rest673) => {
return (GtN(Call(dot_23, V.Undef, n_679, Get(C_678, "v")), 0.004) ? V.True : V.False);
}, 2, "", true);
FR_42 = Fn((V _arrowThis691, int _argc681, V C_687, V O_688, V U_689, V V_690, V[] _rest682) => {
return Call(mtx_26, V.Undef, Invoke(C_687, "P", O_688), Invoke(C_687, "P", Call(add_20, V.Undef, O_688, U_689)), Invoke(C_687, "P", Call(add_20, V.Undef, O_688, V_690)));
}, 4, "", true);
tanF_43 = Fn((V _arrowThis704, int _argc692, V C_698, V cx_699, V cz_700, V R_701, V[] _rest693) => {
double s_705 = 0;
double c_706 = 0;
V th_702 = default;
V y_703 = default;
th_702 = (_argc692 > 4 ? _rest693[0] : V.Undef);
y_703 = (_argc692 > 5 ? _rest693[1] : V.Undef);
s_705 = FdLibm.Sin(ToNum(th_702));
c_706 = FdLibm.Cos(ToNum(th_702));
return Call(FR_42, V.Undef, C_698, Arr(Add(cx_699, ((V)((ToNum(R_701) * s_705)))), y_703, Add(cz_700, ((V)((ToNum(R_701) * c_706))))), Arr(((V)(c_706)), ((V)(0D)), ((V)((-s_705)))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
return default;
}, 6, "", true);
shadow_44 = Fn((V _arrowThis720, int _argc707, V C_713, V x_714, V z_715, V rx_716, V[] _rest708) => {
V rz_717 = default;
V op_718 = default;
V y_719 = default;
rz_717 = (_argc707 > 4 ? _rest708[0] : V.Undef);
op_718 = (_argc707 > 5 ? _rest708[1] : V.Undef);
y_719 = (_argc707 > 6 ? _rest708[2] : V.Undef);
return ((V)(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_713, Arr(x_714, (y_719 is var _t721 && Truthy(_t721) ? _t721 : ((V)(0.05))), z_715), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><ellipse rx=\"", ToStr(rx_716), "\" ry=\"", ToStr(rz_717), "\" fill=\"url(#m10sh)\" opacity=\"", ToStr((op_718 is var _t722 && Truthy(_t722) ? _t722 : ((V)(1D)))), "\"/></g>")));
}, 7, "", true);
yawA_45 = Fn((V _arrowThis730, int _argc723, V t_729, V _a726, V _a727, V _a728, V[] _rest724) => {
return Arr(Arr(((V)(FdLibm.Cos(ToNum(t_729)))), ((V)(0D)), ((V)((-FdLibm.Sin(ToNum(t_729)))))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), Arr(((V)(FdLibm.Sin(ToNum(t_729)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(t_729))))));
}, 1, "", true);
PAT_46 = NewObj(4).Put("foam", ((V)("m10foam"))).Put("mesh", ((V)("m10mesh"))).Put("brush", ((V)("m10brush"))).Put("noise", ((V)("m10noise"))).V;
I3_47 = Arr(Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
CYS_49 = NewObj(5).Put("plastic", Arr(Arr(((V)(0D)), ((V)(0.95))), Arr(((V)(0.2)), ((V)(1.12))), Arr(((V)(0.45)), ((V)(1D))), Arr(((V)(0.78)), ((V)(0.76))), Arr(((V)(1D)), ((V)(0.6))))).Put("gloss", Arr(Arr(((V)(0D)), ((V)(0.82))), Arr(((V)(0.14)), ((V)(1.5))), Arr(((V)(0.22)), ((V)(1.1))), Arr(((V)(0.5)), ((V)(0.9))), Arr(((V)(0.85)), ((V)(0.6))), Arr(((V)(0.95)), ((V)(0.74))), Arr(((V)(1D)), ((V)(0.62))))).Put("metal", Arr(Arr(((V)(0D)), ((V)(0.72))), Arr(((V)(0.12)), ((V)(1.55))), Arr(((V)(0.26)), ((V)(0.95))), Arr(((V)(0.45)), ((V)(1.2))), Arr(((V)(0.64)), ((V)(0.68))), Arr(((V)(0.84)), ((V)(1.08))), Arr(((V)(1D)), ((V)(0.55))))).Put("chrome", Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(0.1)), ((V)(1.75))), Arr(((V)(0.2)), ((V)(0.95))), Arr(((V)(0.36)), ((V)(0.42))), Arr(((V)(0.52)), ((V)(1.35))), Arr(((V)(0.7)), ((V)(0.62))), Arr(((V)(0.86)), ((V)(1.45))), Arr(((V)(1D)), ((V)(0.5))))).Put("matte", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(0.3)), ((V)(1.04))), Arr(((V)(0.7)), ((V)(0.82))), Arr(((V)(1D)), ((V)(0.64))))).V;
KV_52 = Fn((V _arrowThis738, int _argc731, V P_737, V _a734, V _a735, V _a736, V[] _rest732) => {
V Q_739 = default;
Q_739 = Invoke(P_737, "filter", Fn((V _arrowThis748, int _argc740, V p_746, V k_747, V _a744, V _a745, V[] _rest741) => {
return (!(((GtN(k_747, 0D) && SEq(GetIdx(p_746, 0D), GetIdx(GetIdx(P_737, (ToNum(k_747) - 1D)), 0D))) && SEq(GetIdx(p_746, 1D), GetIdx(GetIdx(P_737, (ToNum(k_747) - 1D)), 1D)))) ? V.True : V.False);
}, 2, "", true));
return ((V)(string.Concat("values=\"", ToStr(Invoke(Invoke(Q_739, "map", Fn((V _arrowThis756, int _argc749, V p_755, V _a752, V _a753, V _a754, V[] _rest750) => {
return GetIdx(p_755, 1D);
}, 1, "", true)), "join", ((V)(";")))), "\" keyTimes=\"", ToStr(Invoke(Invoke(Q_739, "map", Fn((V _arrowThis764, int _argc757, V p_763, V _a760, V _a761, V _a762, V[] _rest758) => {
return Call(n4_17, V.Undef, GetIdx(p_763, 0D));
}, 1, "", true)), "join", ((V)(";")))), "\"")));
return default;
}, 1, "", true);
flip_53 = Fn((V _arrowThis775, int _argc765, V frames_771, V n_772, V T_773, V b0_774, V[] _rest766) => {
double m_776 = 0;
m_776 = Max(1D, (ToNum(n_772) - 1D));
return Invoke(Invoke(frames_771, "map", Fn((V _arrowThis787, int _argc777, V _a779, V _a780, V _a781, V _a782, V[] _rest778) => {
V last_788 = default;
V P_789 = default;
V i_784 = default;
V s_786 = default;
if (_a779.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a779));
{ V _t783 = Get(_a779, "i");
i_784 = _t783; }
{ V _t785 = Get(_a779, "s");
s_786 = _t785; }
last_788 = (SEqN(i_784, (ToNum(n_772) - 1D)) ? V.True : V.False);
P_789 = (SEqN(i_784, 0D) ? Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)((0.5 / m_776))), ((V)(1D))), Arr(((V)((1D / m_776))), ((V)(0D))), Arr(((V)(1D)), ((V)(0D)))) : (Truthy(last_788) ? Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(((m_776 - 1D) / m_776))), ((V)(0D))), Arr(((V)(((m_776 - 0.5) / m_776))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))) : Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(((ToNum(i_784) - 1D) / m_776))), ((V)(0D))), Arr(((V)(((ToNum(i_784) - 0.5) / m_776))), ((V)(1D))), Arr(((V)((ToNum(Add(i_784, ((V)(0.5)))) / m_776))), ((V)(1D))), Arr(((V)((ToNum(Add(i_784, ((V)(1D)))) / m_776))), ((V)(0D))), Arr(((V)(1D)), ((V)(0D))))));
return ((V)(string.Concat("<g opacity=\"", NumStr((Truthy(last_788) ? 1D : 0D)), "\"><animate attributeName=\"opacity\" ", ToStr(Call(KV_52, V.Undef, P_789)), " dur=\"", ToStr(T_773), "s\"", ToStr(Call(B_32, V.Undef, b0_774)), " fill=\"freeze\"/>", ToStr(s_786), "</g>")));
return default;
}, 1, "", true)), "join", ((V)("")));
return default;
}, 4, "", true);
easeA_54 = Fn((V _arrowThis799, int _argc790, V a1_796, V n_797, V a0_798, V _a795, V[] _rest791) => {
return Call(rep_18, V.Undef, n_797, Fn((V _arrowThis807, int _argc800, V k_806, V _a803, V _a804, V _a805, V[] _rest801) => {
double t_808 = 0;
t_808 = (ToNum(Add(k_806, ((V)(1D)))) / ToNum(n_797));
return Add((a0_798 is var _t809 && Truthy(_t809) ? _t809 : ((V)(0D))), ((V)(((ToNum(a1_796) - ToNum((a0_798 is var _t810 && Truthy(_t810) ? _t810 : ((V)(0D))))) * (1D - ((1D - t_808) * (1D - t_808)))))));
return default;
}, 1, "", true));
}, 3, "", true);
mist_55 = Fn((V _arrowThis823, int _argc811, V C_817, V x_818, V y_819, V z_820, V[] _rest812) => {
V q_824 = default;
V n_821 = default;
V sz_822 = default;
n_821 = (_argc811 > 4 ? _rest812[0] : V.Undef);
sz_822 = (_argc811 > 5 ? _rest812[1] : V.Undef);
q_824 = Invoke(C_817, "p", x_818, y_819, z_820);
return ((V)(JsStrBuf.Begin().S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_19, V.Undef, q_824)), ") scale(", ToStr(Call(n4_17, V.Undef, ((V)((ToNum(Get(C_817, "k")) * ToNum((sz_822 is var _t825 && Truthy(_t825) ? _t825 : ((V)(1D))))))))), ")\" >")).V(Invoke(Call(rep_18, V.Undef, (n_821 is var _t826 && Truthy(_t826) ? _t826 : ((V)(4D))), Fn((V _arrowThis834, int _argc827, V i_833, V _a830, V _a831, V _a832, V[] _rest828) => {
double d_835 = 0;
double b_836 = 0;
double dx_837 = 0;
d_835 = (2.6 + (ToNum(i_833) * 0.4));
b_836 = (((-ToNum(i_833)) * d_835) / ToNum((n_821 is var _t838 && Truthy(_t838) ? _t838 : ((V)(4D)))));
dx_837 = ((NumTruthy((ToNum(i_833) % 2D)) ? 1D : (-1D)) * (3D + (ToNum(i_833) * 2D)));
return ((V)(string.Concat("<ellipse rx=\"7.5\" ry=\"4\" fill=\"url(#m10mst)\" opacity=\"0\">", ToStr(Call(an_33, V.Undef, ((V)("opacity")), ((V)("0;0.5;0")), ((V)(d_835)), ((V)(b_836)))), "<animateTransform attributeName=\"transform\" type=\"translate\" values=\"", NumStr((dx_837 * 0.3)), " 0;", NumStr(dx_837), " -16\" dur=\"", NumStr(d_835), "s\"", ToStr(Call(B_32, V.Undef, ((V)(b_836)))), " repeatCount=\"indefinite\"/></ellipse>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>").End()));
return default;
}, 6, "", true);
CANS_56 = Arr(Arr(((V)("#d8322f")), ((V)("#ffffff"))), Arr(((V)("#e6ebee")), ((V)("#d8322f"))), Arr(((V)("#2f9d4a")), ((V)("#f6e24a"))), Arr(((V)("#f08a24")), ((V)("#ffffff"))), Arr(((V)("#2b5fc4")), ((V)("#ffffff"))), Arr(((V)("#7a2a8f")), ((V)("#f5c542"))));
canTop_57 = Fn((V _arrowThis846, int _argc839, V cr_845, V _a842, V _a843, V _a844, V[] _rest840) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, cr_845)), "\" fill=\"#c3c9cd\"/><circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_845) * 0.84))))), "\" fill=\"#d9dee1\" stroke=\"#8d949a\" stroke-width=\"0.28\"/><circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_845) * 0.62))))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.6\" stroke-width=\"0.2\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_845)) * 0.3))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_845)) * 0.55))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_845) * 0.6))))), "v", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_845) * 0.5))))), "a", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_845) * 0.3))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_845) * 0.3))))), " 0 0 1 ", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_845)) * 0.6))))), " 0z\" fill=\"#a9b0b5\" stroke=\"#7d848a\" stroke-width=\"0.2\"/><ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_845) * 0.2))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_845) * 0.35))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_845) * 0.26))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_845) * 0.15))))), "\" fill=\"#5a6066\"/>")));
}, 1, "", true);
PUFF_59 = ((V)("<circle cx=\"-1\" cy=\"0.3\" r=\"1.25\" fill=\"#fff8e4\"/><circle cx=\"0.9\" cy=\"0.1\" r=\"1.15\" fill=\"#fffaf0\"/><circle cx=\"0\" cy=\"-0.9\" r=\"1.1\" fill=\"#fff4d6\"/><circle cx=\"0.25\" cy=\"0.95\" r=\"0.85\" fill=\"#efd696\"/><circle cx=\"-0.55\" cy=\"-1.15\" r=\"0.42\" fill=\"#ffffff\"/><path d=\"M-1.7 0.7q1.7 1 3.4 0\" stroke=\"#c99a48\" stroke-width=\"0.32\" fill=\"none\" opacity=\"0.7\"/>"));
puffAt_60 = Fn((V _arrowThis857, int _argc847, V C_853, V q_854, V s_855, V rot_856, V[] _rest848) => {
V c_858 = default;
c_858 = Invoke(C_853, "P", q_854);
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_19, V.Undef, c_858)), ") rotate(", ToStr(Call(f1_16, V.Undef, (rot_856 is var _t859 && Truthy(_t859) ? _t859 : ((V)(0D))))), ") scale(", ToStr(Call(n4_17, V.Undef, ((V)((ToNum(Get(C_853, "k")) * ToNum((s_855 is var _t860 && Truthy(_t860) ? _t860 : ((V)(1D))))))))), ")\">", ToStr(PUFF_59), "</g>")));
return default;
}, 4, "", true);
Set(N_14, "cool10", Fn((V _arrowThis868, int _argc861, V S_867, V _a864, V _a865, V _a866, V[] _rest862) => {
V open_869 = default;
V FO_870 = default;
double W_871 = 0;
double Dd_872 = 0;
double H_873 = 0;
double LH_874 = 0;
double T_875 = 0;
V D_876 = default;
V bandF_877 = default;
V bodyF_878 = default;
V bodyR_879 = default;
V lidTop_880 = default;
V lidU_881 = default;
V lidE_882 = default;
V lidAt_883 = default;
open_869 = Call(isPlay_31, V.Undef, S_867);
FO_870 = ((V)("#f3f1ea"));
W_871 = 60D;
Dd_872 = 38D;
H_873 = 32D;
LH_874 = 6.5;
T_875 = 3.2;
D_876 = NewObj(3).Put("w", ((V)(66D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis890, int _argc884, V _a886, V _a887, V _a888, V _a889, V[] _rest885) => {
return Arr();
}, 0, "build", true)).V;
bandF_877 = Fn((V _arrowThis898, int _argc891, V W_897, V _a894, V _a895, V _a896, V[] _rest892) => {
return ((V)(string.Concat("<path d=\"M2 4.3H", NumStr((ToNum(W_897) - 2D)), "\" stroke=\"#000000\" stroke-opacity=\"0.1\" stroke-width=\"0.6\"/><path d=\"M2 4.9H", NumStr((ToNum(W_897) - 2D)), "\" stroke=\"#ffffff\" stroke-opacity=\"0.85\" stroke-width=\"0.4\"/><path d=\"M1.5 28.7H", NumStr((ToNum(W_897) - 1.5)), "\" stroke=\"#000000\" stroke-opacity=\"0.1\" stroke-width=\"0.6\"/><path d=\"M1.5 29.3H", NumStr((ToNum(W_897) - 1.5)), "\" stroke=\"#ffffff\" stroke-opacity=\"0.7\" stroke-width=\"0.35\"/>")));
}, 1, "", true);
bodyF_878 = ((V)(JsStrBuf.Begin().V(Call(bandF_877, V.Undef, ((V)(W_871)))).S(string.Concat("<g transform=\"translate(30 16.5)\"><ellipse rx=\"11.5\" ry=\"5.2\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.09\" stroke-width=\"0.7\"/><ellipse rx=\"11.5\" ry=\"5.2\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.8\" stroke-width=\"0.4\" transform=\"translate(-0.35 -0.35)\"/><text y=\"1.5\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"4.2\" fill=\"#2f6fb0\" fill-opacity=\"0.78\" letter-spacing=\"0.3\">COOL\u00b7PAK</text></g><path d=\"M45 21.5l3.4 1.6M47 20.6l1.2 2.6\" stroke=\"#8a7f66\" stroke-opacity=\"0.28\" stroke-width=\"0.35\"/>")).End()));
bodyR_879 = ((V)(JsStrBuf.Begin().V(Call(bandF_877, V.Undef, ((V)(Dd_872)))).S(string.Concat("<rect x=\"11\" y=\"7\" width=\"16\" height=\"4.6\" rx=\"2.3\" fill=\"#000000\" fill-opacity=\"0.14\"/><rect x=\"11\" y=\"7\" width=\"16\" height=\"2\" rx=\"1\" fill=\"#000000\" fill-opacity=\"0.12\"/><path d=\"M11.8 11.4H26.2\" stroke=\"#ffffff\" stroke-opacity=\"0.85\" stroke-width=\"0.4\"/>", "")).End()));
lidTop_880 = ((V)(string.Concat("<rect x=\"7\" y=\"6\" width=\"48\" height=\"28\" rx=\"3\" fill=\"#000000\" fill-opacity=\"0.03\" stroke=\"#000000\" stroke-opacity=\"0.09\" stroke-width=\"0.8\"/><rect x=\"7.5\" y=\"6.5\" width=\"47\" height=\"27\" rx=\"2.6\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.85\" stroke-width=\"0.45\"/><text x=\"31\" y=\"22\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"3.4\" fill=\"#000000\" fill-opacity=\"0.07\" letter-spacing=\"1\">KEEP COLD</text>")));
lidU_881 = ((V)(string.Concat("<rect x=\"3.6\" y=\"3.6\" width=\"54.8\" height=\"32.8\" rx=\"2.4\" fill=\"#000000\" fill-opacity=\"0.07\"/><rect x=\"4\" y=\"4\" width=\"54\" height=\"32\" rx=\"2.2\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.7\" stroke-width=\"0.4\"/><rect x=\"9\" y=\"9\" width=\"44\" height=\"22\" rx=\"2\" fill=\"#000000\" fill-opacity=\"0.04\"/>", "")));
lidE_882 = Fn((V _arrowThis906, int _argc899, V W_905, V _a902, V _a903, V _a904, V[] _rest900) => {
return ((V)(string.Concat("<path d=\"M0.5 3.5H", NumStr((ToNum(W_905) - 0.5)), "\" stroke=\"#000000\" stroke-opacity=\"0.13\" stroke-width=\"0.5\"/>")));
}, 1, "", true);
lidAt_883 = Fn((V _arrowThis915, int _argc907, V C_913, V th_914, V _a911, V _a912, V[] _rest908) => {
double t_916 = 0;
V ey_917 = default;
V ez_918 = default;
V hinge_919 = default;
t_916 = ((ToNum(th_914) * PI_15) / 180D);
ey_917 = Arr(((V)(0D)), ((V)(FdLibm.Cos(t_916))), ((V)((-FdLibm.Sin(t_916)))));
ez_918 = Arr(((V)(0D)), ((V)(FdLibm.Sin(t_916))), ((V)(FdLibm.Cos(t_916))));
hinge_919 = Arr(((V)(0D)), ((V)(H_873)), ((V)((((-Dd_872) / 2D) - 1D))));
return Call(box3_48, V.Undef, C_913, NewObj(11).Put("c", Call(add_20, V.Undef, hinge_919, Call(mul_22, V.Undef, ez_918, ((V)(((Dd_872 / 2D) + 1D)))))).Put("ax", Arr(Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ey_917, ez_918)).Put("w", ((V)((W_871 + 2D)))).Put("h", ((V)(LH_874))).Put("d", ((V)((Dd_872 + 2D)))).Put("r", ((V)(4.6))).Put("col", FO_870).Put("mat", ((V)("foam"))).Put("dec", NewObj(4).Put("t", lidTop_880).Put("u", lidU_881).Put("f", Call(lidE_882, V.Undef, ((V)((W_871 + 2D))))).Put("r", Call(lidE_882, V.Undef, ((V)((Dd_872 + 2D))))).V).Put("olw", ((V)(0.4))).Put("olo", ((V)(0.55))).V);
return default;
}, 2, "", true);
Set(D_876, "fx", Fn((V _arrowThis927, int _argc920, V ctx_926, V _a923, V _a924, V _a925, V[] _rest921) => {
V C_928 = default;
V s_929 = default;
V body_930 = default;
V ANG_931 = default;
V bk_932 = default;
V fr_933 = default;
double x0_934 = 0;
double z0_935 = 0;
double IW_936 = 0;
double ID_937 = 0;
double IY_938 = 0;
V IN_939 = default;
V R_940 = default;
V its_941 = default;
V pack_942 = default;
C_928 = Call(cam_39, V.Undef, ctx_926);
s_929 = Call(shadow_44, V.Undef, C_928, ((V)(1D)), ((V)(3D)), ((V)(40D)), ((V)(26D)), ((V)(0.85)));
body_930 = Fn((V _arrowThis950, int _argc943, V o_949, V _a946, V _a947, V _a948, V[] _rest944) => {
return Call(box3_48, V.Undef, C_928, Object_assign(NewObj(10).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("w", ((V)(W_871))).Put("h", ((V)(H_873))).Put("d", ((V)(Dd_872))).Put("r", ((V)(4D))).Put("col", FO_870).Put("mat", ((V)("foam"))).Put("dec", NewObj(2).Put("f", bodyF_878).Put("r", bodyR_879).V).Put("olw", ((V)(0.45))).Put("olo", ((V)(0.55))).V, o_949));
}, 1, "", true);
if (!(Truthy(open_869))) {
return NewObj(3).Put("defs", DEF10_37).Put("front", ((V)(JsStrBuf.Begin().V(Add(s_929, Call(body_930, V.Undef))).S(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_928, Arr(((V)(((-W_871) / 2D))), ((V)(H_873)), ((V)((Dd_872 / 2D)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect x=\"2\" y=\"-0.2\" width=\"", NumStr((W_871 - 4D)), "\" height=\"1.4\" fill=\"#000000\" opacity=\"0.12\"/></g>")).V(Call(lidAt_883, V.Undef, C_928, ((V)(0D)))).End()))).Put("bb", Invoke(C_928, "bb", ((V)(4D)))).V;
}
ANG_931 = Call(easeA_54, V.Undef, ((V)(106D)), ((V)(11D)));
bk_932 = Arr();
fr_933 = Arr();
Invoke(ANG_931, "forEach", Fn((V _arrowThis959, int _argc951, V a_957, V i_958, V _a955, V _a956, V[] _rest952) => {
return Invoke((GeN(a_957, 72D) ? bk_932 : fr_933), "push", NewObj(2).Put("i", i_958).Put("s", Call(lidAt_883, V.Undef, C_928, a_957)).V);
}, 2, "", true));
s_929 = Add(s_929, Call(flip_53, V.Undef, bk_932, Get(ANG_931, "length"), ((V)(0.85))));
x0_934 = (((-W_871) / 2D) + T_875);
z0_935 = (((-Dd_872) / 2D) + T_875);
IW_936 = (W_871 - (2D * T_875));
ID_937 = (Dd_872 - (2D * T_875));
IY_938 = 19.5;
IN_939 = ((V)("#ebe8df"));
s_929 = ((V)(JsStrBuf.Begin().V(s_929).S(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_928, Arr(((V)(x0_934)), ((V)(H_873)), ((V)(z0_935))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", NumStr(IW_936), "\" height=\"", NumStr((H_873 - 2D)), "\" fill=\"", ToStr(Call(shade_12, V.Undef, IN_939, Call(lit_40, V.Undef, C_928, Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))))), "\"/><rect width=\"", NumStr(IW_936), "\" height=\"", NumStr((H_873 - 2D)), "\" fill=\"url(#m10foam)\"/><rect width=\"", NumStr(IW_936), "\" height=\"", NumStr((H_873 - 2D)), "\" fill=\"url(#m10in)\"/></g>")).S(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_928, Arr(((V)(x0_934)), ((V)(H_873)), ((V)(z0_935))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", NumStr(ID_937), "\" height=\"", NumStr((H_873 - 2D)), "\" fill=\"", ToStr(Call(shade_12, V.Undef, IN_939, ((V)((ToNum(Call(lit_40, V.Undef, C_928, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))))) * 0.92))))), "\"/><rect width=\"", NumStr(ID_937), "\" height=\"", NumStr((H_873 - 2D)), "\" fill=\"url(#m10foam)\"/><rect width=\"", NumStr(ID_937), "\" height=\"", NumStr((H_873 - 2D)), "\" fill=\"url(#m10in)\"/></g>")).End()));
R_940 = Call(rng_30, V.Undef, ((V)("cool10")));
its_941 = Arr();
s_929 = ((V)(JsStrBuf.Begin().V(s_929).S(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_928, Arr(((V)(x0_934)), ((V)(IY_938)), ((V)(z0_935))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><rect width=\"", NumStr(IW_936), "\" height=\"", NumStr(ID_937), "\" fill=\"#d6ebf2\"/><rect width=\"", NumStr(IW_936), "\" height=\"", NumStr(ID_937), "\" fill=\"url(#m10t)\"/>")).V(Invoke(Call(rep_18, V.Undef, ((V)(26D)), Fn((V _arrowThis966, int _argc960, V _a962, V _a963, V _a964, V _a965, V[] _rest961) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_940, V.Undef)) * IW_936))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_940, V.Undef)) * ID_937))))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.8 + (ToNum(Call(R_940, V.Undef)) * 1.6)))))), "\" fill=\"#ffffff\" opacity=\"", ToStr(Call(n4_17, V.Undef, ((V)((0.35 + (ToNum(Call(R_940, V.Undef)) * 0.4)))))), "\"/>")));
}, 0, "", true)), "join", ((V)("")))).S("</g>").End()));
Call(rep_18, V.Undef, ((V)(18D)), Fn((V _arrowThis974, int _argc967, V i_973, V _a970, V _a971, V _a972, V[] _rest968) => {
double x_975 = 0;
double z_976 = 0;
double sz_977 = 0;
x_975 = ((x0_934 + 3D) + (ToNum(Call(R_940, V.Undef)) * (IW_936 - 6D)));
z_976 = ((z0_935 + 3D) + (ToNum(Call(R_940, V.Undef)) * (ID_937 - 6D)));
sz_977 = (3.4 + (ToNum(Call(R_940, V.Undef)) * 2.4));
Invoke(its_941, "push", NewObj(2).Put("z", ((V)((z_976 + (x_975 * 0.02))))).Put("s", Call(box3_48, V.Undef, C_928, NewObj(13).Put("c", Arr(((V)(x_975)), ((V)(((IY_938 - 1.2) + (ToNum(Call(R_940, V.Undef)) * 1.4)))), ((V)(z_976)))).Put("ax", Call(yawA_45, V.Undef, ((V)((ToNum(Call(R_940, V.Undef)) * PI_15))))).Put("w", ((V)(sz_977))).Put("h", ((V)((sz_977 * 0.8)))).Put("d", ((V)((sz_977 * 0.9)))).Put("r", ((V)(0.8))).Put("col", ((V)("#e6f5fb"))).Put("gl", ((V)(0.8))).Put("op", ((V)(0.92))).Put("olc", ((V)("#8fb7c8"))).Put("olw", ((V)(0.3))).Put("olo", ((V)(0.8))).Put("edge", ((V)(0.7))).V)).V);
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-17D))), ((V)((-9D))), ((V)(0D))), Arr(((V)((-7.5))), ((V)((-10D))), ((V)(1D))), Arr(((V)((-19D))), ((V)(3D)), ((V)(2D))), Arr(((V)(4D)), ((V)((-9.5))), ((V)(3D)))), "forEach", Fn((V _arrowThis991, int _argc978, V _a980, V _a981, V _a982, V _a983, V[] _rest979) => {
V x_986 = default;
V z_988 = default;
V ci_990 = default;
{ V _t984 = ListOf(_a980);
{ V _t985 = GetIdx(_t984, 0D);
x_986 = _t985; }
{ V _t987 = GetIdx(_t984, 1D);
z_988 = _t987; }
{ V _t989 = GetIdx(_t984, 2D);
ci_990 = _t989; }
}
return Invoke(its_941, "push", NewObj(2).Put("z", z_988).Put("s", Call(can3_58, V.Undef, C_928, x_986, ((V)((IY_938 - 6D))), z_988, ((V)(3.2)), ((V)(12.5)), ci_990)).V);
}, 1, "", true));
pack_942 = Fn((V _arrowThis1003, int _argc992, V x_998, V y_999, V z_1000, V yw_1001, V[] _rest993) => {
V A_1004 = default;
V ax_1005 = default;
V tl_1002 = default;
tl_1002 = (_argc992 > 4 ? _rest993[0] : V.Undef);
A_1004 = Call(yawA_45, V.Undef, yw_1001);
ax_1005 = Arr(GetIdx(A_1004, 0D), Call(add_20, V.Undef, Call(mul_22, V.Undef, GetIdx(A_1004, 1D), ((V)(FdLibm.Cos(ToNum(tl_1002))))), Call(mul_22, V.Undef, GetIdx(A_1004, 2D), ((V)(FdLibm.Sin(ToNum(tl_1002)))))), Call(sub_21, V.Undef, Call(mul_22, V.Undef, GetIdx(A_1004, 2D), ((V)(FdLibm.Cos(ToNum(tl_1002))))), Call(mul_22, V.Undef, GetIdx(A_1004, 1D), ((V)(FdLibm.Sin(ToNum(tl_1002)))))));
return Call(box3_48, V.Undef, C_928, NewObj(10).Put("c", Arr(x_998, y_999, z_1000)).Put("ax", ax_1005).Put("w", ((V)(17D))).Put("h", ((V)(3.4))).Put("d", ((V)(11D))).Put("r", ((V)(2.4))).Put("col", ((V)("#2470d0"))).Put("gl", ((V)(0.85))).Put("dec", NewObj(1).Put("t", ((V)(string.Concat("<text x=\"8.5\" y=\"6.4\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"2.6\" fill=\"#ffffff\" fill-opacity=\"0.92\">ICE PACK</text><text x=\"8.5\" y=\"8.6\" text-anchor=\"middle\" font-family=\"Arial\" font-size=\"1.4\" fill=\"#cfe4ff\">reusable gel</text>")))).V).Put("olw", ((V)(0.35))).V);
return default;
}, 5, "", true);
Invoke(its_941, "push", NewObj(2).Put("z", ((V)((-6D)))).Put("s", Call(pack_942, V.Undef, ((V)(14D)), ((V)((IY_938 - 0.6))), ((V)((-7D))), ((V)(0.25)), ((V)(0.18)))).V, NewObj(2).Put("z", ((V)(7D))).Put("s", Call(pack_942, V.Undef, ((V)(9D)), ((V)((IY_938 - 0.2))), ((V)(7D)), ((V)((-0.35))), ((V)((-0.12))))).V);
Invoke(Invoke(its_941, "sort", Fn((V _arrowThis1022, int _argc1014, V a_1020, V b_1021, V _a1018, V _a1019, V[] _rest1015) => {
return ((V)((ToNum(Get(a_1020, "z")) - ToNum(Get(b_1021, "z")))));
}, 2, "", true)), "forEach", Fn((V _arrowThis1013, int _argc1006, V q_1012, V _a1009, V _a1010, V _a1011, V[] _rest1007) => {
return (s_929 = Add(s_929, Get(q_1012, "s")));
}, 1, "", true));
s_929 = Add(s_929, Call(mist_55, V.Undef, C_928, ((V)(0D)), ((V)((IY_938 + 4D))), ((V)(0D)), ((V)(4D)), ((V)(1.2))));
s_929 = Add(s_929, Add(Call(body_930, V.Undef, NewObj(1).Put("hole", NewObj(1).Put("t", ((V)(T_875))).V).V), Call(flip_53, V.Undef, fr_933, Get(ANG_931, "length"), ((V)(0.85)))));
return NewObj(3).Put("defs", DEF10_37).Put("front", s_929).Put("bb", Invoke(C_928, "bb", ((V)(8D)))).V;
return default;
}, 1, "", true));
return D_876;
return default;
}, 1, "", true));
Set(N_14, "mfr10", Fn((V _arrowThis1030, int _argc1023, V S_1029, V _a1026, V _a1027, V _a1028, V[] _rest1024) => {
V open_1031 = default;
V BC_1032 = default;
double W_1033 = 0;
double Dd_1034 = 0;
double H_1035 = 0;
double FT_1036 = 0;
double DT_1037 = 0;
double Z0_1038 = 0;
double ZF_1039 = 0;
double ID_1040 = 0;
V D_1041 = default;
V doorF_1042 = default;
V sideR_1043 = default;
V liner_1044 = default;
V doorAt_1045 = default;
open_1031 = Call(isPlay_31, V.Undef, S_1029);
BC_1032 = ((V)("#cfe8db"));
W_1033 = 34D;
Dd_1034 = 28D;
H_1035 = 40D;
FT_1036 = 1.6;
DT_1037 = 3D;
Z0_1038 = (-15D);
ZF_1039 = 13D;
ID_1040 = 2.6;
D_1041 = NewObj(3).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis1052, int _argc1046, V _a1048, V _a1049, V _a1050, V _a1051, V[] _rest1047) => {
return Arr();
}, 0, "build", true)).V;
doorF_1042 = ((V)(string.Concat(string.Concat("<rect x=\"0.7\" y=\"0.7\" width=\"", NumStr((W_1033 - 1.4)), "\" height=\"", NumStr((H_1035 - 1.4)), "\" rx=\"1.6\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.07\" stroke-width=\"0.5\"/><rect x=\"8\" y=\"2.4\" width=\"18\" height=\"2.8\" rx=\"1.4\" fill=\"#000000\" fill-opacity=\"0.24\"/><rect x=\"8\" y=\"2.4\" width=\"18\" height=\"1.2\" rx=\"0.6\" fill=\"#000000\" fill-opacity=\"0.2\"/><path d=\"M8.6 5H25.4\" stroke=\"#ffffff\" stroke-opacity=\"0.75\" stroke-width=\"0.4\"/>"), string.Concat("<rect x=\"20.5\" y=\"8.5\" width=\"9.5\" height=\"5.2\" rx=\"1.1\" fill=\"#12161a\" stroke=\"#6f8a80\" stroke-width=\"0.3\"/><text x=\"25.25\" y=\"12.35\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"3.3\" fill=\"#7fd6ff\">4\u00b0C</text><rect x=\"20.5\" y=\"8.5\" width=\"9.5\" height=\"2.2\" rx=\"1\" fill=\"#ffffff\" opacity=\"0.08\"/>"), string.Concat("<text x=\"17\" y=\"36.4\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"2.9\" fill=\"#5d8475\" letter-spacing=\"0.7\">chill\u00b76</text>"))));
sideR_1043 = ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis1060, int _argc1053, V i_1059, V _a1056, V _a1057, V _a1058, V[] _rest1054) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)((16D + (ToNum(i_1059) * 1.6)))))), "\" y=\"30\" width=\"0.75\" height=\"6.5\" rx=\"0.37\" fill=\"#000000\" fill-opacity=\"0.3\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M1 0.6H", NumStr((Dd_1034 - 1D)), "\" stroke=\"#ffffff\" stroke-opacity=\"0.4\" stroke-width=\"0.4\"/>")).End()));
liner_1044 = ((V)(string.Concat(string.Concat("<rect x=\"2\" y=\"2\" width=\"", NumStr((W_1033 - 4D)), "\" height=\"", NumStr((H_1035 - 4D)), "\" rx=\"2\" fill=\"#eef4f2\"/><rect x=\"2\" y=\"2\" width=\"", NumStr((W_1033 - 4D)), "\" height=\"", NumStr((H_1035 - 4D)), "\" rx=\"2\" fill=\"none\" stroke=\"#9aaba5\" stroke-width=\"1.2\"/><rect x=\"5\" y=\"5\" width=\"", NumStr((W_1033 - 10D)), "\" height=\"", NumStr((H_1035 - 10D)), "\" rx=\"1.6\" fill=\"#000000\" fill-opacity=\"0.05\"/>"), string.Concat("<rect x=\"6\" y=\"28\" width=\"", NumStr((W_1033 - 12D)), "\" height=\"5\" rx=\"1\" fill=\"#dfe8e5\" stroke=\"#b5c2bd\" stroke-width=\"0.4\"/><rect x=\"14\" y=\"19.5\" width=\"6.4\" height=\"11\" rx=\"1.2\" fill=\"#2f9d4a\"/><rect x=\"14\" y=\"19.5\" width=\"6.4\" height=\"1.4\" rx=\"0.6\" fill=\"#c9ced2\"/><rect x=\"15\" y=\"21\" width=\"1.2\" height=\"9\" fill=\"#ffffff\" opacity=\"0.35\"/><rect x=\"6\" y=\"28\" width=\"", NumStr((W_1033 - 12D)), "\" height=\"1.2\" fill=\"#ffffff\" opacity=\"0.5\"/>"))));
doorAt_1045 = Fn((V _arrowThis1069, int _argc1061, V C_1067, V th_1068, V _a1065, V _a1066, V[] _rest1062) => {
double t_1070 = 0;
V ex_1071 = default;
V ez_1072 = default;
t_1070 = ((ToNum(th_1068) * PI_15) / 180D);
ex_1071 = Arr(((V)(FdLibm.Cos(t_1070))), ((V)(0D)), ((V)(FdLibm.Sin(t_1070))));
ez_1072 = Arr(((V)((-FdLibm.Sin(t_1070)))), ((V)(0D)), ((V)(FdLibm.Cos(t_1070))));
return Call(box3_48, V.Undef, C_1067, NewObj(10).Put("c", Call(add_20, V.Undef, Arr(((V)(((-W_1033) / 2D))), ((V)(FT_1036)), ((V)(ZF_1039))), Call(add_20, V.Undef, Call(mul_22, V.Undef, ex_1071, ((V)((W_1033 / 2D)))), Call(mul_22, V.Undef, ez_1072, ((V)((DT_1037 / 2D))))))).Put("ax", Arr(ex_1071, Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), ez_1072)).Put("w", ((V)(W_1033))).Put("h", ((V)(H_1035))).Put("d", ((V)(DT_1037))).Put("r", ((V)(1.2))).Put("col", Call(shade_12, V.Undef, BC_1032, ((V)(1.04)))).Put("gl", ((V)(0.55))).Put("dec", NewObj(2).Put("f", doorF_1042).Put("b", liner_1044).V).Put("olw", ((V)(0.45))).V);
return default;
}, 2, "", true);
Set(D_1041, "fx", Fn((V _arrowThis1080, int _argc1073, V ctx_1079, V _a1076, V _a1077, V _a1078, V[] _rest1074) => {
V C_1081 = default;
V s_1082 = default;
V body_1083 = default;
double xi_1084 = 0;
double yb_1085 = 0;
double yt_1086 = 0;
double zi_1087 = 0;
double IW_1088 = 0;
double IH_1089 = 0;
double IDp_1090 = 0;
V IN_1091 = default;
double SY_1092 = 0;
V ANG_1093 = default;
C_1081 = Call(cam_39, V.Undef, ctx_1079);
s_1082 = Call(shadow_44, V.Undef, C_1081, ((V)(0D)), ((V)(1D)), ((V)(24D)), ((V)(22D)), ((V)(0.85)));
Invoke(Arr(Arr(((V)((-13D))), ((V)((-11D)))), Arr(((V)(13D)), ((V)((-11D)))), Arr(((V)((-13D))), ((V)(13D))), Arr(((V)(13D)), ((V)(13D)))), "forEach", Fn((V _arrowThis1105, int _argc1094, V _a1096, V _a1097, V _a1098, V _a1099, V[] _rest1095) => {
V x_1102 = default;
V z_1104 = default;
{ V _t1100 = ListOf(_a1096);
{ V _t1101 = GetIdx(_t1100, 0D);
x_1102 = _t1101; }
{ V _t1103 = GetIdx(_t1100, 1D);
z_1104 = _t1103; }
}
return (s_1082 = Add(s_1082, Call(cyl3_50, V.Undef, C_1081, Arr(x_1102, ((V)(0D)), z_1104), Arr(x_1102, ((V)(FT_1036)), z_1104), ((V)(1.6)), ((V)("#2c2e31")), NewObj(2).Put("mat", ((V)("matte"))).Put("olw", ((V)(0.3))).V)));
}, 1, "", true));
body_1083 = Fn((V _arrowThis1113, int _argc1106, V o_1112, V _a1109, V _a1110, V _a1111, V[] _rest1107) => {
return Call(box3_48, V.Undef, C_1081, Object_assign(NewObj(9).Put("c", Arr(((V)(0D)), ((V)(FT_1036)), ((V)(((Z0_1038 + ZF_1039) / 2D))))).Put("w", ((V)(W_1033))).Put("h", ((V)(H_1035))).Put("d", ((V)((ZF_1039 - Z0_1038)))).Put("r", ((V)(3.2))).Put("col", BC_1032).Put("gl", ((V)(0.3))).Put("dec", NewObj(1).Put("r", sideR_1043).V).Put("olw", ((V)(0.45))).V, o_1112));
}, 1, "", true);
if (!(Truthy(open_1031))) {
return NewObj(3).Put("defs", DEF10_37).Put("front", Add(Add(s_1082, Call(body_1083, V.Undef)), Call(doorAt_1045, V.Undef, C_1081, ((V)(0D))))).Put("bb", Invoke(C_1081, "bb", ((V)(4D)))).V;
}
xi_1084 = (((-W_1033) / 2D) + ID_1040);
yb_1085 = (FT_1036 + ID_1040);
yt_1086 = ((FT_1036 + H_1035) - ID_1040);
zi_1087 = (Z0_1038 + ID_1040);
IW_1088 = (W_1033 - (2D * ID_1040));
IH_1089 = (yt_1086 - yb_1085);
IDp_1090 = (ZF_1039 - zi_1087);
IN_1091 = ((V)("#eef4f6"));
SY_1092 = (FT_1036 + 19.5);
s_1082 = ((V)(JsStrBuf.Begin().V(s_1082).S(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_1081, Arr(((V)(xi_1084)), ((V)(yt_1086)), ((V)(zi_1087))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", NumStr(IW_1088), "\" height=\"", NumStr(IH_1089), "\" fill=\"", ToStr(Call(shade_12, V.Undef, IN_1091, Call(lit_40, V.Undef, C_1081, Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))))), "\"/><rect width=\"", NumStr(IW_1088), "\" height=\"", NumStr(IH_1089), "\" fill=\"url(#m10in)\" opacity=\"0.6\"/><rect x=\"2\" y=\"0.8\" width=\"", NumStr((IW_1088 - 4D)), "\" height=\"1\" rx=\"0.5\" fill=\"#bfeaff\"/>")).S(string.Concat("<g transform=\"translate(", NumStr((IW_1088 / 2D)), " ", NumStr((IH_1089 * 0.3)), ")\"><circle r=\"5.2\" fill=\"#dfe6e9\" stroke=\"#a9b4b9\" stroke-width=\"0.5\"/><g>", ToStr(Call(at_34, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(0.6)))), ToStr(Invoke(Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis1121, int _argc1114, V i_1120, V _a1117, V _a1118, V _a1119, V[] _rest1115) => {
return ((V)(string.Concat("<path d=\"M0 0Q2 -1.6 1.2 -4.4L-0.6 -4.2Q0.4 -2 0 0Z\" fill=\"#8f9aa0\" transform=\"rotate(", NumStr((ToNum(i_1120) * 72D)), ")\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g><circle r=\"1.1\" fill=\"#6f7a80\"/>", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis1129, int _argc1122, V i_1128, V _a1125, V _a1126, V _a1127, V[] _rest1123) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.9 + (ToNum(i_1128) * 1.3)))))), "\" fill=\"none\" stroke=\"#7d888e\" stroke-width=\"0.35\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g></g>")).S(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_1081, Arr(((V)(xi_1084)), ((V)(yt_1086)), ((V)(zi_1087))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", NumStr(IDp_1090), "\" height=\"", NumStr(IH_1089), "\" fill=\"", ToStr(Call(shade_12, V.Undef, IN_1091, ((V)((ToNum(Call(lit_40, V.Undef, C_1081, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))))) * 0.94))))), "\"/><rect width=\"", NumStr(IDp_1090), "\" height=\"", NumStr(IH_1089), "\" fill=\"url(#m10in)\" opacity=\"0.6\"/><path d=\"M0 ", ToStr(Call(f1_16, V.Undef, ((V)((yt_1086 - SY_1092))))), "H", NumStr(IDp_1090), "\" stroke=\"#b9c6cc\" stroke-width=\"0.8\"/></g>")).S(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_1081, Arr(((V)(xi_1084)), ((V)(yb_1085)), ((V)(zi_1087))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><rect width=\"", NumStr(IW_1088), "\" height=\"", NumStr(IDp_1090), "\" fill=\"", ToStr(Call(shade_12, V.Undef, IN_1091, ((V)((ToNum(Call(lit_40, V.Undef, C_1081, Arr(((V)(0D)), ((V)(1D)), ((V)(0D))))) * 0.9))))), "\"/><rect width=\"", NumStr(IW_1088), "\" height=\"", NumStr(IDp_1090), "\" fill=\"url(#m10t)\"/></g>")).End()));
Invoke(Arr(((V)((-9.5))), ((V)(0D)), ((V)(9.5))), "forEach", Fn((V _arrowThis1138, int _argc1130, V x_1136, V i_1137, V _a1134, V _a1135, V[] _rest1131) => {
return (s_1082 = Add(s_1082, Call(can3_58, V.Undef, C_1081, x_1136, ((V)(yb_1085)), ((V)((-2D))), ((V)(4D)), ((V)(13.5)), GetK(Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), i_1137))));
}, 2, "", true));
s_1082 = ((V)(JsStrBuf.Begin().V(s_1082).S(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_1081, Arr(((V)(xi_1084)), ((V)(SY_1092)), ((V)(zi_1087))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\">")).V(Invoke(Call(rep_18, V.Undef, ((V)(13D)), Fn((V _arrowThis1146, int _argc1139, V i_1145, V _a1142, V _a1143, V _a1144, V[] _rest1140) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((0.6 + (ToNum(i_1145) * 2.33)))))), " 0.4V", ToStr(Call(f1_16, V.Undef, ((V)((IDp_1090 - 0.6))))), "\" stroke=\"#7d868c\" stroke-width=\"0.55\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((0.45 + (ToNum(i_1145) * 2.33)))))), " 0.4V", ToStr(Call(f1_16, V.Undef, ((V)((IDp_1090 - 0.6))))), "\" stroke=\"#e8eef1\" stroke-width=\"0.28\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M0 1H", NumStr(IW_1088), "M0 ", ToStr(Call(f1_16, V.Undef, ((V)((IDp_1090 - 1D))))), "H", NumStr(IW_1088), "\" stroke=\"#d5dde2\" stroke-width=\"0.9\"/></g>")).End()));
Invoke(Arr(((V)((-9.5))), ((V)(0D)), ((V)(9.5))), "forEach", Fn((V _arrowThis1155, int _argc1147, V x_1153, V i_1154, V _a1151, V _a1152, V[] _rest1148) => {
return (s_1082 = Add(s_1082, Call(can3_58, V.Undef, C_1081, x_1153, ((V)(SY_1092)), ((V)((-2D))), ((V)(4D)), ((V)(13.5)), GetK(Arr(((V)(2D)), ((V)(3D)), ((V)(4D))), i_1154))));
}, 2, "", true));
s_1082 = ((V)(JsStrBuf.Begin().V(s_1082).S(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_1081, Arr(((V)(xi_1084)), ((V)(yt_1086)), ((V)(ZF_1039))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", NumStr(IW_1088), "\" height=\"", NumStr(IH_1089), "\" fill=\"url(#m10cold)\">", ToStr(Call(an_33, V.Undef, ((V)("opacity")), ((V)("0.85;1;0.85")), ((V)(3D)))), "</rect></g>")).V(Call(mist_55, V.Undef, C_1081, ((V)(0D)), ((V)((FT_1036 + 8D))), ((V)((ZF_1039 + 2D))), ((V)(3D)), ((V)(0.8)))).End()));
s_1082 = Add(s_1082, Call(body_1083, V.Undef, NewObj(2).Put("hole", NewObj(1).Put("f", Arr(((V)(ID_1040)), ((V)(ID_1040)), ((V)(ID_1040)), ((V)(ID_1040)))).V).Put("dec", NewObj(2).Put("r", sideR_1043).Put("f", ((V)(string.Concat("<rect x=\"", NumStr(ID_1040), "\" y=\"", NumStr(ID_1040), "\" width=\"", NumStr(IW_1088), "\" height=\"", NumStr(IH_1089), "\" fill=\"none\" stroke=\"#a9b8b2\" stroke-width=\"0.9\"/>")))).V).V));
ANG_1093 = Call(easeA_54, V.Undef, ((V)(108D)), ((V)(10D)));
s_1082 = Add(s_1082, Call(flip_53, V.Undef, Invoke(ANG_1093, "map", Fn((V _arrowThis1164, int _argc1156, V a_1162, V i_1163, V _a1160, V _a1161, V[] _rest1157) => {
return NewObj(2).Put("i", i_1163).Put("s", Call(doorAt_1045, V.Undef, C_1081, a_1162)).V;
}, 2, "", true)), Get(ANG_1093, "length"), ((V)(0.7))));
return NewObj(3).Put("defs", DEF10_37).Put("front", s_1082).Put("bb", Invoke(C_1081, "bb", ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_1041;
return default;
}, 1, "", true));
Set(N_14, "plas10", Fn((V _arrowThis1172, int _argc1165, V S_1171, V _a1168, V _a1169, V _a1170, V[] _rest1166) => {
double TW_1173 = 0;
double TH_1174 = 0;
double TD_1175 = 0;
double ZB_1176 = 0;
double ZF_1177 = 0;
V D_1178 = default;
V front_1179 = default;
V top_1180 = default;
V side_1181 = default;
TW_1173 = 140D;
TH_1174 = 84D;
TD_1175 = 7D;
ZB_1176 = 4.5;
ZF_1177 = (ZB_1176 + TD_1175);
D_1178 = NewObj(6).Put("w", ((V)(150D))).Put("d", ((V)(14D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(40D))).Put("act", ((V)("watch"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(150D))).V).V;
Set(D_1178, "build", Fn((V _arrowThis1188, int _argc1182, V _a1184, V _a1185, V _a1186, V _a1187, V[] _rest1183) => {
return Arr(Call(slab_11, V.Undef, ((V)(0D)), ((V)((TH_1174 - 75D))), ((V)((ZF_1177 + 0.05))), ((V)(124D)), ((V)(70D)), ((V)(0.2)), ((V)("#000000")), NewObj(5).Put("scr", ((V)(1D))).Put("r", ((V)(0.5))).Put("emit", ((V)(1D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0D))).V));
}, 0, "", true));
front_1179 = ((V)(string.Concat(string.Concat("<defs><linearGradient id=\"pl10s\" x1=\"0\" y1=\"0\" x2=\"0.9\" y2=\"1\"><stop offset=\"0\" stop-color=\"#2b3036\"/><stop offset=\"0.55\" stop-color=\"#15181c\"/><stop offset=\"1\" stop-color=\"#0b0c0f\"/></linearGradient><linearGradient id=\"pl10k\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#e3e6e8\"/><stop offset=\"0.5\" stop-color=\"#b9bec2\"/><stop offset=\"1\" stop-color=\"#8e9499\"/></linearGradient></defs>", ""), string.Concat("<rect x=\"7.4\" y=\"4.4\" width=\"125.2\" height=\"71.2\" rx=\"0.6\" fill=\"#050506\"/><rect x=\"8\" y=\"5\" width=\"124\" height=\"70\" fill=\"url(#pl10s)\"/><path d=\"M71 5H101L79 75H49Z\" fill=\"#ffffff\" opacity=\"0.045\"/><path d=\"M104 5H112L90 75H82Z\" fill=\"#ffffff\" opacity=\"0.03\"/><rect x=\"8\" y=\"5\" width=\"124\" height=\"16\" fill=\"#ffffff\" opacity=\"0.025\"/>", ""), string.Concat("<path d=\"M8 5.3H132\" stroke=\"#ffffff\" stroke-opacity=\"0.12\" stroke-width=\"0.4\"/><rect x=\"0\" y=\"76.4\" width=\"", NumStr(TW_1173), "\" height=\"", NumStr((TH_1174 - 76.4)), "\" fill=\"url(#pl10k)\"/><rect x=\"4\" y=\"77.6\" width=\"52\" height=\"5.2\" fill=\"url(#m10perf)\"/><rect x=\"84\" y=\"77.6\" width=\"52\" height=\"5.2\" fill=\"url(#m10perf)\"/><path d=\"M0 76.5H", NumStr(TW_1173), "\" stroke=\"#ffffff\" stroke-opacity=\"0.8\" stroke-width=\"0.35\"/>"), string.Concat("<rect x=\"61\" y=\"78.2\" width=\"18\" height=\"4\" rx=\"0.6\" fill=\"#ced3d6\" stroke=\"#8e9499\" stroke-width=\"0.25\"/><text x=\"70\" y=\"81.2\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"2.6\" letter-spacing=\"1\" fill=\"#3b3f44\">PLASMA</text><circle cx=\"58.4\" cy=\"80.2\" r=\"0.62\" fill=\"#ff4a3a\"/><circle cx=\"58.4\" cy=\"80.2\" r=\"1.6\" fill=\"#ff4a3a\" opacity=\"0.25\"/>"))));
top_1180 = Invoke(Call(rep_18, V.Undef, ((V)(34D)), Fn((V _arrowThis1196, int _argc1189, V i_1195, V _a1192, V _a1193, V _a1194, V[] _rest1190) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)((8D + (ToNum(i_1195) * 3.6)))))), "\" y=\"2.2\" width=\"2.2\" height=\"2.6\" rx=\"0.4\" fill=\"#000000\" fill-opacity=\"0.55\"/>")));
}, 1, "", true)), "join", ((V)("")));
side_1181 = Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis1204, int _argc1197, V i_1203, V _a1200, V _a1201, V _a1202, V[] _rest1198) => {
return ((V)(string.Concat("<rect x=\"2.3\" y=\"", ToStr(Call(f1_16, V.Undef, ((V)((18D + (ToNum(i_1203) * 4.6)))))), "\" width=\"2.4\" height=\"2.8\" rx=\"0.6\" fill=\"#2c2f34\" stroke=\"#000000\" stroke-width=\"0.2\"/>")));
}, 1, "", true)), "join", ((V)("")));
Set(D_1178, "fx", Fn((V _arrowThis1212, int _argc1205, V ctx_1211, V _a1208, V _a1209, V _a1210, V[] _rest1206) => {
V C_1213 = default;
JsStrBuf s_1214 = null;
V cb_1215 = default;
V cd_1216 = default;
C_1213 = Call(cam_39, V.Undef, ctx_1211);
s_1214 = new JsStrBuf(string.Concat("<g transform=\"", ToStr(Call(FR_42, V.Undef, C_1213, Arr(((V)(((-TW_1173) / 2D))), ((V)(TH_1174)), ((V)(0.2))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect x=\"3\" y=\"5\" width=\"", NumStr(TW_1173), "\" height=\"", NumStr(TH_1174), "\" rx=\"3\" fill=\"#000000\" opacity=\"0.3\" filter=\"url(#m10b3)\"/></g>"));
s_1214.V(Call(box3_48, V.Undef, C_1213, NewObj(8).Put("c", Arr(((V)(62D)), ((V)(18D)), ((V)((ZB_1176 / 2D))))).Put("w", ((V)(3D))).Put("h", ((V)(44D))).Put("d", ((V)(ZB_1176))).Put("r", ((V)(0.6))).Put("col", ((V)("#2a2c30"))).Put("mat", ((V)("brush"))).Put("olw", ((V)(0.35))).V));
Invoke(Arr(((V)((-34D))), ((V)(34D))), "forEach", Fn((V _arrowThis1224, int _argc1217, V x_1223, V _a1220, V _a1221, V _a1222, V[] _rest1218) => {
s_1214.V(Add(Call(box3_48, V.Undef, C_1213, NewObj(8).Put("c", Arr(x_1223, ((V)((-7D))), ((V)(2.4)))).Put("w", ((V)(3.2))).Put("h", ((V)(22D))).Put("d", ((V)(3D))).Put("r", ((V)(0.5))).Put("col", ((V)("#26282c"))).Put("mat", ((V)("brush"))).Put("olw", ((V)(0.35))).V), Call(cyl3_50, V.Undef, C_1213, Arr(x_1223, ((V)((-5.5))), ((V)(3.9))), Arr(x_1223, ((V)((-5.5))), ((V)(6.4))), ((V)(1.3)), ((V)("#3b3e43")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.3))).V)));
return default;
}, 1, "", true));
cb_1215 = Invoke(Arr(Arr(((V)(54D)), ((V)(1D)), ((V)(6D))), Arr(((V)(55D)), ((V)((-8D))), ((V)(6.5))), Arr(((V)(57.5)), ((V)((-16D))), ((V)(4.5))), Arr(((V)(56D)), ((V)((-26D))), ((V)(2D)))), "map", Fn((V _arrowThis1232, int _argc1225, V q_1231, V _a1228, V _a1229, V _a1230, V[] _rest1226) => {
return InvokeSpread(C_1213, "p", new ArrBuilder().Spread(q_1231).V);
}, 1, "", true));
cd_1216 = ((V)(string.Concat("M", ToStr(Call(P2_19, V.Undef, GetIdx(cb_1215, 0D))), "C", ToStr(Call(P2_19, V.Undef, GetIdx(cb_1215, 1D))), " ", ToStr(Call(P2_19, V.Undef, GetIdx(cb_1215, 2D))), " ", ToStr(Call(P2_19, V.Undef, GetIdx(cb_1215, 3D))))));
s_1214.S(string.Concat("<path d=\"", ToStr(cd_1216), "\" stroke=\"#0e0f11\" stroke-width=\"2.1\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"", ToStr(cd_1216), "\" stroke=\"#4a4d52\" stroke-width=\"0.6\" fill=\"none\" stroke-linecap=\"round\" transform=\"translate(-0.5 -0.3)\"/>"));
s_1214.V(Call(box3_48, V.Undef, C_1213, NewObj(11).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)((ZB_1176 + (TD_1175 / 2D)))))).Put("w", ((V)(TW_1173))).Put("h", ((V)(TH_1174))).Put("d", ((V)(TD_1175))).Put("r", ((V)(1.4))).Put("col", ((V)("#17181c"))).Put("gl", ((V)(0.9))).Put("dec", NewObj(3).Put("f", front_1179).Put("t", top_1180).Put("r", side_1181).V).Put("olc", ((V)("#050506"))).Put("olw", ((V)(0.6))).Put("edge", ((V)(0.25))).V));
return NewObj(3).Put("defs", DEF10_37).Put("front", ((V)(s_1214.Str))).Put("bb", Invoke(C_1213, "bb", ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_1178;
return default;
}, 1, "", true));
Set(N_14, "cproj10", Fn((V _arrowThis1240, int _argc1233, V S_1239, V _a1236, V _a1237, V _a1238, V[] _rest1234) => {
double PW_1241 = 0;
double PH_1242 = 0;
double PD_1243 = 0;
double LX_1244 = 0;
double LY_1245 = 0;
V D_1246 = default;
V lens_1247 = default;
V front_1248 = default;
V top_1249 = default;
V side_1250 = default;
PW_1241 = 42D;
PH_1242 = 13D;
PD_1243 = 34D;
LX_1244 = (-10D);
LY_1245 = 6.6;
D_1246 = NewObj(4).Put("w", ((V)(50D))).Put("d", ((V)(40D))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis1257, int _argc1251, V _a1253, V _a1254, V _a1255, V _a1256, V[] _rest1252) => {
return Arr();
}, 0, "build", true)).V;
lens_1247 = Fn((V _arrowThis1265, int _argc1258, V cr_1264, V _a1261, V _a1262, V _a1263, V[] _rest1259) => {
return ((V)(string.Concat("<defs><radialGradient id=\"cp10g\" cx=\"42%\" cy=\"38%\" r=\"62%\"><stop offset=\"0\" stop-color=\"#4b4f9a\"/><stop offset=\"0.45\" stop-color=\"#1d2244\"/><stop offset=\"1\" stop-color=\"#05060a\"/></radialGradient></defs><circle r=\"", ToStr(Call(f1_16, V.Undef, cr_1264)), "\" fill=\"#111215\"/><circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.8))))), "\" fill=\"url(#cp10g)\"/><circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.8))))), "\" fill=\"none\" stroke=\"#3a3d44\" stroke-width=\"0.3\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_1264)) * 0.62))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_1264)) * 0.1))))), "A", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.64))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.64))))), " 0 0 1 ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.1))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_1264)) * 0.62))))), "\" stroke=\"#7affc8\" stroke-opacity=\"0.45\" stroke-width=\"0.35\" fill=\"none\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.5))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.2))))), "A", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.55))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.55))))), " 0 0 1 ", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_1264)) * 0.1))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.55))))), "\" stroke=\"#ff7ae0\" stroke-opacity=\"0.35\" stroke-width=\"0.3\" fill=\"none\"/><ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_1264)) * 0.28))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_1264)) * 0.3))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.22))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1264) * 0.13))))), "\" fill=\"#ffffff\" opacity=\"0.75\" transform=\"rotate(-35 ", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_1264)) * 0.28))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_1264)) * 0.3))))), ")\"/>")));
}, 1, "", true);
front_1248 = ((V)(JsStrBuf.Begin().S(string.Concat("<circle cx=\"", NumStr(((PW_1241 / 2D) + LX_1244)), "\" cy=\"", NumStr((PH_1242 - LY_1245)), "\" r=\"6.6\" fill=\"#1b1d20\"/><circle cx=\"", NumStr(((PW_1241 / 2D) + LX_1244)), "\" cy=\"", NumStr((PH_1242 - LY_1245)), "\" r=\"6.6\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.5\" stroke-width=\"0.35\"/>")).V(Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis1273, int _argc1266, V i_1272, V _a1269, V _a1270, V _a1271, V[] _rest1267) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)((24D + (ToNum(i_1272) * 1.65)))))), "\" y=\"2.6\" width=\"0.8\" height=\"7.8\" rx=\"0.4\" fill=\"#000000\" fill-opacity=\"0.42\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<text x=\"31\" y=\"12.1\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"1.5\" fill=\"#9aa1a6\" letter-spacing=\"0.3\">FULL HD 1080p</text>")).End()));
top_1249 = ((V)(string.Concat(string.Concat("<circle cx=\"31\" cy=\"23\" r=\"4.2\" fill=\"#e2e5e5\" stroke=\"#b9bfc1\" stroke-width=\"0.35\"/><circle cx=\"31\" cy=\"23\" r=\"1.5\" fill=\"#f4f5f5\" stroke=\"#aab0b3\" stroke-width=\"0.3\"/>", ToStr(Invoke(Invoke(Arr(((V)(0D)), ((V)(90D)), ((V)(180D)), ((V)(270D))), "map", Fn((V _arrowThis1281, int _argc1274, V a_1280, V _a1277, V _a1278, V _a1279, V[] _rest1275) => {
return ((V)(string.Concat("<path d=\"M31 19.6l0.9 1.1h-1.8z\" fill=\"#8f979b\" transform=\"rotate(", ToStr(a_1280), " 31 23)\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<circle cx=\"37\" cy=\"29.5\" r=\"1.3\" fill=\"#e7eaea\" stroke=\"#aab0b3\" stroke-width=\"0.3\"/><circle cx=\"37\" cy=\"27.3\" r=\"0.45\" fill=\"#3fd0ff\">", ToStr(Call(an_33, V.Undef, ((V)("opacity")), ((V)("1;0.25;1")), ((V)(2.4)))), "</circle>"), string.Concat("<rect x=\"5.5\" y=\"24\" width=\"10\" height=\"2\" rx=\"1\" fill=\"#c9cecf\"/><rect x=\"9\" y=\"23.6\" width=\"2.4\" height=\"2.8\" rx=\"0.6\" fill=\"#8f979b\"/><text x=\"21\" y=\"9\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"2.6\" fill=\"#b5bbbd\" letter-spacing=\"1.2\">LUMINA</text>"))));
side_1250 = Invoke(Call(rep_18, V.Undef, ((V)(11D)), Fn((V _arrowThis1289, int _argc1282, V i_1288, V _a1285, V _a1286, V _a1287, V[] _rest1283) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)((5D + (ToNum(i_1288) * 2.2)))))), "\" y=\"2.4\" width=\"1.1\" height=\"8.4\" rx=\"0.55\" fill=\"#000000\" fill-opacity=\"0.4\"/>")));
}, 1, "", true)), "join", ((V)("")));
Set(D_1246, "fx", Fn((V _arrowThis1297, int _argc1290, V ctx_1296, V _a1293, V _a1294, V _a1295, V[] _rest1291) => {
V C_1298 = default;
JsStrBuf s_1299 = null;
C_1298 = Call(cam_39, V.Undef, ctx_1296);
s_1299 = new JsStrBuf("");
s_1299.V(Call(box3_48, V.Undef, C_1298, NewObj(10).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("w", ((V)(PW_1241))).Put("h", ((V)(PH_1242))).Put("d", ((V)(PD_1243))).Put("r", ((V)(5D))).Put("col", ((V)("#eceeed"))).Put("gl", ((V)(0.35))).Put("mat", ((V)("noise"))).Put("dec", NewObj(3).Put("f", front_1248).Put("t", top_1249).Put("r", side_1250).V).Put("olw", ((V)(0.45))).V));
s_1299.V(Add(Call(cyl3_50, V.Undef, C_1298, Arr(((V)(LX_1244)), ((V)(LY_1245)), ((V)(((PD_1243 / 2D) - 0.3)))), Arr(((V)(LX_1244)), ((V)(LY_1245)), ((V)(((PD_1243 / 2D) + 2.2)))), ((V)(5.9)), ((V)("#2b2d31")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.35))).V), Call(cyl3_50, V.Undef, C_1298, Arr(((V)(LX_1244)), ((V)(LY_1245)), ((V)(((PD_1243 / 2D) + 2.2)))), Arr(((V)(LX_1244)), ((V)(LY_1245)), ((V)(((PD_1243 / 2D) + 4.2)))), ((V)(5.3)), ((V)("#1a1b1e")), NewObj(3).Put("mat", ((V)("gloss"))).Put("cap", lens_1247).Put("olw", ((V)(0.35))).V)));
Invoke(Invoke(Arr(Arr(((V)((-14D))), ((V)((-11D)))), Arr(((V)(14D)), ((V)((-11D)))), Arr(((V)((-14D))), ((V)(11D))), Arr(((V)(14D)), ((V)(11D)))), "sort", Fn((V _arrowThis1320, int _argc1312, V a_1318, V b_1319, V _a1316, V _a1317, V[] _rest1313) => {
return ((V)((ToNum(GetIdx(a_1318, 1D)) - ToNum(GetIdx(b_1319, 1D)))));
}, 2, "", true)), "forEach", Fn((V _arrowThis1311, int _argc1300, V _a1302, V _a1303, V _a1304, V _a1305, V[] _rest1301) => {
V x_1308 = default;
V z_1310 = default;
{ V _t1306 = ListOf(_a1302);
{ V _t1307 = GetIdx(_t1306, 0D);
x_1308 = _t1307; }
{ V _t1309 = GetIdx(_t1306, 1D);
z_1310 = _t1309; }
}
return ((V)(s_1299.V(Add(Call(cyl3_50, V.Undef, C_1298, Arr(((V)((ToNum(x_1308) * 0.4))), ((V)((PH_1242 + 2.6))), ((V)((ToNum(z_1310) * 0.4)))), Arr(x_1308, ((V)((PH_1242 + 0.2))), z_1310), ((V)(0.75)), ((V)("#2b2d31")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.25))).V), Call(cyl3_50, V.Undef, C_1298, Arr(x_1308, ((V)(PH_1242)), z_1310), Arr(x_1308, ((V)((PH_1242 + 0.8))), z_1310), ((V)(1.5)), ((V)("#2b2d31")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.25))).V))).Str));
}, 1, "", true));
s_1299.V(Add(Call(cyl3_50, V.Undef, C_1298, Arr(((V)(0D)), ((V)((PH_1242 + 1.6))), ((V)(0D))), Arr(((V)(0D)), ((V)((PH_1242 + 4D))), ((V)(0D))), ((V)(3.4)), ((V)("#232428")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.35))).V), Call(cyl3_50, V.Undef, C_1298, Arr(((V)(0D)), ((V)((PH_1242 + 4D))), ((V)(0D))), Arr(((V)(0D)), ((V)(34D)), ((V)(0D))), ((V)(1.25)), ((V)("#cdd3d7")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.3))).V)));
s_1299.V(Add(Add(Call(cyl3_50, V.Undef, C_1298, Arr(((V)(0D)), ((V)(32.5)), ((V)(0D))), Arr(((V)(0D)), ((V)(35.5)), ((V)(0D))), ((V)(2.3)), ((V)("#232428")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.3))).V), Call(cyl3_50, V.Undef, C_1298, Arr(((V)(2.1)), ((V)(34D)), ((V)(0D))), Arr(((V)(4.6)), ((V)(34D)), ((V)(0D))), ((V)(0.7)), ((V)("#3b3e43")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.25))).V)), Call(cyl3_50, V.Undef, C_1298, Arr(((V)(0D)), ((V)(35.5)), ((V)(0D))), Arr(((V)(0D)), ((V)(49D)), ((V)(0D))), ((V)(1.75)), ((V)("#cdd3d7")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.3))).V)));
s_1299.V(Call(cyl3_50, V.Undef, C_1298, Arr(((V)(0D)), ((V)(49D)), ((V)(0D))), Arr(((V)(0D)), ((V)(51D)), ((V)(0D))), ((V)(8.5)), ((V)("#eceeed")), NewObj(2).Put("cap", Fn((V _arrowThis1328, int _argc1321, V cr_1327, V _a1324, V _a1325, V _a1326, V[] _rest1322) => {
return Invoke(Invoke(Arr(((V)(0D)), ((V)(120D)), ((V)(240D))), "map", Fn((V _arrowThis1336, int _argc1329, V a_1335, V _a1332, V _a1333, V _a1334, V[] _rest1330) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(cr_1327) * 0.68) * FdLibm.Cos(((ToNum(a_1335) * PI_15) / 180D))))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(cr_1327) * 0.68) * FdLibm.Sin(((ToNum(a_1335) * PI_15) / 180D))))))), "\" r=\"0.7\" fill=\"#b9bfc1\" stroke=\"#8f979b\" stroke-width=\"0.2\"/>")));
}, 1, "", true)), "join", ((V)("")));
}, 1, "cap", true)).Put("olw", ((V)(0.35))).V));
return NewObj(3).Put("defs", DEF10_37).Put("front", ((V)(s_1299.Str))).Put("bb", Invoke(C_1298, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1246;
return default;
}, 1, "", true));
Set(N_14, "sbar10", Fn((V _arrowThis1344, int _argc1337, V S_1343, V _a1340, V _a1341, V _a1342, V[] _rest1338) => {
V on_1345 = default;
double BW_1346 = 0;
double BH_1347 = 0;
double BD_1348 = 0;
double WW_1349 = 0;
double WH_1350 = 0;
double WD_1351 = 0;
V D_1352 = default;
V pump_1353 = default;
V wF_1354 = default;
V bF_1355 = default;
V bT_1356 = default;
on_1345 = Call(isPlay_31, V.Undef, S_1343);
BW_1346 = 86D;
BH_1347 = 7.2;
BD_1348 = 9D;
WW_1349 = 24D;
WH_1350 = 30D;
WD_1351 = 27D;
D_1352 = NewObj(3).Put("w", ((V)(116D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis1363, int _argc1357, V _a1359, V _a1360, V _a1361, V _a1362, V[] _rest1358) => {
return Arr();
}, 0, "build", true)).V;
pump_1353 = (Truthy(on_1345) ? Call(at_34, V.Undef, ((V)("scale")), ((V)("1;1.07;0.98;1")), ((V)(0.42)), ((V)(0D)), Call(SPL_35, V.Undef, ((V)(3D)))) : ((V)("")));
wF_1354 = ((V)(string.Concat(string.Concat("<defs><radialGradient id=\"sb10c\" cx=\"45%\" cy=\"40%\" r=\"60%\"><stop offset=\"0\" stop-color=\"#4a4d53\"/><stop offset=\"0.7\" stop-color=\"#1c1d21\"/><stop offset=\"1\" stop-color=\"#0c0c0e\"/></radialGradient><radialGradient id=\"sb10d\" cx=\"38%\" cy=\"32%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#9aa0a8\"/><stop offset=\"0.45\" stop-color=\"#3a3d43\"/><stop offset=\"1\" stop-color=\"#101113\"/></radialGradient></defs>", ""), string.Concat("<circle cx=\"12\" cy=\"12.5\" r=\"9.9\" fill=\"#070708\"/><circle cx=\"12\" cy=\"12.5\" r=\"9.9\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.18\" stroke-width=\"0.35\"/><g transform=\"translate(12 12.5)\"><g>", ToStr(pump_1353), "<circle r=\"9.1\" fill=\"#26272b\"/><circle r=\"9.1\" fill=\"none\" stroke=\"#3d3f44\" stroke-width=\"1.2\"/><path d=\"M-6.5 -6.5A9.2 9.2 0 0 1 6.5 -6.5\" stroke=\"#ffffff\" stroke-opacity=\"0.22\" stroke-width=\"0.7\" fill=\"none\"/><circle r=\"7.6\" fill=\"url(#sb10c)\"/><circle r=\"7.6\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.5\" stroke-width=\"0.4\"/>", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis1371, int _argc1364, V i_1370, V _a1367, V _a1368, V _a1369, V[] _rest1365) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((3.8 + (ToNum(i_1370) * 1.2)))))), "\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.18\" stroke-width=\"0.25\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<circle r=\"2.9\" fill=\"url(#sb10d)\"/></g></g>"), string.Concat("<rect x=\"6\" y=\"25\" width=\"12\" height=\"2.8\" rx=\"1.4\" fill=\"#040405\"/><path d=\"M6.8 27.6H17.2\" stroke=\"#ffffff\" stroke-opacity=\"0.2\" stroke-width=\"0.3\"/><text x=\"12\" y=\"1.9\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"1.3\" fill=\"#8f949a\" letter-spacing=\"0.6\">SUB\u00b72.1</text>"))));
bF_1355 = ((V)(JsStrBuf.Begin().S(string.Concat("<text x=\"", NumStr((BW_1346 / 2D)), "\" y=\"3.6\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"1.6\" fill=\"#a9aeb3\" letter-spacing=\"0.8\">SOUNDBAR</text>")).V(Invoke(Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis1379, int _argc1372, V i_1378, V _a1375, V _a1376, V _a1377, V[] _rest1373) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((((BW_1346 / 2D) - 4D) + (ToNum(i_1378) * 2D)))))), "\" cy=\"5.6\" r=\"0.36\" fill=\"#ffffff\" opacity=\"", NumStr((Truthy(on_1345) ? 0.9 : 0.25)), "\">", ToStr((Truthy(on_1345) ? Call(an_33, V.Undef, ((V)("opacity")), GetIdx(Arr(((V)("0.2;0.95;0.4;0.9;0.2")), ((V)("0.6;0.2;0.95;0.3;0.6")), ((V)("0.9;0.4;0.2;0.95;0.9"))), (ToNum(i_1378) % 3D)), ((V)((0.9 + (ToNum(i_1378) * 0.07)))), ((V)(((-ToNum(i_1378)) * 0.13)))) : ((V)("")))), "</circle>")));
}, 1, "", true)), "join", ((V)("")))).End()));
bT_1356 = ((V)(JsStrBuf.Begin().V(Invoke(Invoke(Arr(Arr(((V)("\u23fb")), ((V)(62D))), Arr(((V)("\u2013")), ((V)(67D))), Arr(((V)("+")), ((V)(72D))), Arr(((V)("\u25e6")), ((V)(77D)))), "map", Fn((V _arrowThis1391, int _argc1380, V _a1382, V _a1383, V _a1384, V _a1385, V[] _rest1381) => {
V g_1388 = default;
V x_1390 = default;
{ V _t1386 = ListOf(_a1382);
{ V _t1387 = GetIdx(_t1386, 0D);
g_1388 = _t1387; }
{ V _t1389 = GetIdx(_t1386, 1D);
x_1390 = _t1389; }
}
return ((V)(string.Concat("<circle cx=\"", ToStr(x_1390), "\" cy=\"4.5\" r=\"1.5\" fill=\"#17181b\" stroke=\"#3a3c41\" stroke-width=\"0.3\"/><circle cx=\"", NumStr((ToNum(x_1390) - 0.3)), "\" cy=\"4.2\" r=\"1.1\" fill=\"#ffffff\" opacity=\"0.06\"/><text x=\"", ToStr(x_1390), "\" y=\"5.15\" text-anchor=\"middle\" font-family=\"Arial\" font-size=\"1.7\" fill=\"#9aa0a6\">", ToStr(g_1388), "</text>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<circle cx=\"10\" cy=\"4.5\" r=\"0.55\" fill=\"", (Truthy(on_1345) ? "#3fa8ff" : "#2a4a6a"), "\"/>")).End()));
Set(D_1352, "fx", Fn((V _arrowThis1399, int _argc1392, V ctx_1398, V _a1395, V _a1396, V _a1397, V[] _rest1393) => {
V C_1400 = default;
V s_1401 = default;
C_1400 = Call(cam_39, V.Undef, ctx_1398);
s_1401 = Add(Call(shadow_44, V.Undef, C_1400, ((V)(34D)), ((V)((-6D))), ((V)(20D)), ((V)(20D)), ((V)(0.8))), Call(shadow_44, V.Undef, C_1400, ((V)((-16D))), ((V)(13D)), ((V)(48D)), ((V)(9D)), ((V)(0.7))));
Invoke(Arr(Arr(((V)(24D)), ((V)((-17D)))), Arr(((V)(44D)), ((V)((-17D)))), Arr(((V)(24D)), ((V)(5D))), Arr(((V)(44D)), ((V)(5D)))), "forEach", Fn((V _arrowThis1413, int _argc1402, V _a1404, V _a1405, V _a1406, V _a1407, V[] _rest1403) => {
V x_1410 = default;
V z_1412 = default;
{ V _t1408 = ListOf(_a1404);
{ V _t1409 = GetIdx(_t1408, 0D);
x_1410 = _t1409; }
{ V _t1411 = GetIdx(_t1408, 1D);
z_1412 = _t1411; }
}
return (s_1401 = Add(s_1401, Call(cyl3_50, V.Undef, C_1400, Arr(x_1410, ((V)(0D)), z_1412), Arr(x_1410, ((V)(1.2)), z_1412), ((V)(1.5)), ((V)("#151517")), NewObj(2).Put("mat", ((V)("matte"))).Put("ol", ((V)(0D))).V)));
}, 1, "", true));
s_1401 = Add(s_1401, Call(box3_48, V.Undef, C_1400, NewObj(12).Put("c", Arr(((V)(34D)), ((V)(1.2)), ((V)((-6D))))).Put("w", ((V)(WW_1349))).Put("h", ((V)(WH_1350))).Put("d", ((V)(WD_1351))).Put("r", ((V)(1.8))).Put("col", ((V)("#1d1e22"))).Put("mat", ((V)("noise"))).Put("gl", ((V)(0.15))).Put("dec", NewObj(2).Put("f", wF_1354).Put("t", ((V)(string.Concat("<text x=\"12\" y=\"25\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"1.6\" fill=\"#55585e\" letter-spacing=\"1\">BASS</text>")))).V).Put("olc", ((V)("#060607"))).Put("olw", ((V)(0.5))).Put("edge", ((V)(0.18))).V));
s_1401 = Add(s_1401, Call(box3_48, V.Undef, C_1400, NewObj(13).Put("c", Arr(((V)((-16D))), ((V)(0.6)), ((V)(13D)))).Put("w", ((V)(BW_1346))).Put("h", ((V)(BH_1347))).Put("d", ((V)(BD_1348))).Put("r", ((V)(3.6))).Put("col", ((V)("#232428"))).Put("mat", ((V)("mesh"))).Put("tpat", ((V)("noise"))).Put("gl", ((V)(0.1))).Put("dec", NewObj(2).Put("f", bF_1355).Put("t", bT_1356).V).Put("olc", ((V)("#060607"))).Put("olw", ((V)(0.5))).Put("edge", ((V)(0.2))).V));
return NewObj(3).Put("defs", DEF10_37).Put("front", s_1401).Put("bb", Invoke(C_1400, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1352;
return default;
}, 1, "", true));
Set(N_14, "popr10", Fn((V _arrowThis1421, int _argc1414, V S_1420, V _a1417, V _a1418, V _a1419, V[] _rest1415) => {
double BZ_1422 = 0;
double BR_1423 = 0;
double HR_1424 = 0;
double BX_1425 = 0;
double BWZ_1426 = 0;
V D_1427 = default;
BZ_1422 = (-4D);
BR_1423 = 12D;
HR_1424 = 10.6;
BX_1425 = 0D;
BWZ_1426 = 24D;
D_1427 = NewObj(3).Put("w", ((V)(44D))).Put("d", ((V)(62D))).Put("build", Fn((V _arrowThis1434, int _argc1428, V _a1430, V _a1431, V _a1432, V _a1433, V[] _rest1429) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1427, "fx", Fn((V _arrowThis1442, int _argc1435, V ctx_1441, V _a1438, V _a1439, V _a1440, V[] _rest1436) => {
V C_1443 = default;
V th_1444 = default;
V R_1445 = default;
V s_1446 = default;
V kc_1447 = default;
double rx_1448 = 0;
double ry_1449 = 0;
V ring_1450 = default;
double tl_1451 = 0;
V ey_1452 = default;
V ez_1453 = default;
V H_1454 = default;
double hx_1455 = 0;
V rimP_1456 = default;
V heap_1457 = default;
V rimF_1458 = default;
V m0_1459 = default;
C_1443 = Call(cam_39, V.Undef, ctx_1441);
th_1444 = Get(C_1443, "thV");
R_1445 = Call(rng_30, V.Undef, ((V)("popr10")));
s_1446 = Add(Call(shadow_44, V.Undef, C_1443, ((V)(0D)), ((V)(BZ_1422)), ((V)(17D)), ((V)(15D)), ((V)(0.85))), Call(shadow_44, V.Undef, C_1443, ((V)(BX_1425)), ((V)(BWZ_1426)), ((V)(17D)), ((V)(13D)), ((V)(0.8))));
s_1446 = Add(s_1446, Add(Add(Call(cyl3_50, V.Undef, C_1443, Arr(((V)(0D)), ((V)(0D)), ((V)(BZ_1422))), Arr(((V)(0D)), ((V)(1.6)), ((V)(BZ_1422))), ((V)((BR_1423 + 0.4))), ((V)("#3a3b3f")), NewObj(2).Put("mat", ((V)("matte"))).Put("olw", ((V)(0.35))).V), Call(cyl3_50, V.Undef, C_1443, Arr(((V)(0D)), ((V)(1.6)), ((V)(BZ_1422))), Arr(((V)(0D)), ((V)(12.6)), ((V)(BZ_1422))), ((V)(BR_1423)), ((V)("#f4f1ea")), NewObj(3).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("olw", ((V)(0.4))).V)), Call(cyl3_50, V.Undef, C_1443, Arr(((V)(0D)), ((V)(12.4)), ((V)(BZ_1422))), Arr(((V)(0D)), ((V)(15.2)), ((V)(BZ_1422))), ((V)((BR_1423 + 0.15))), ((V)("#cf2f2a")), NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.4))).V)));
Invoke(Arr(((V)((-0.95))), ((V)((-0.7))), ((V)((-0.45))), ((V)(0.45)), ((V)(0.7)), ((V)(0.95))), "forEach", Fn((V _arrowThis1467, int _argc1460, V dt_1466, V _a1463, V _a1464, V _a1465, V[] _rest1461) => {
return (s_1446 = ((V)(JsStrBuf.Begin().V(s_1446).S(string.Concat("<g transform=\"", ToStr(Call(tanF_43, V.Undef, C_1443, ((V)(0D)), ((V)(BZ_1422)), ((V)((BR_1423 + 0.05))), Add(th_1444, dt_1466), ((V)(11.4)))), "\"><rect x=\"-0.45\" width=\"0.9\" height=\"6.4\" rx=\"0.45\" fill=\"#000000\" opacity=\"0.4\"/><path d=\"M0.35 0.4V6\" stroke=\"#ffffff\" stroke-opacity=\"0.5\" stroke-width=\"0.2\"/></g>")).End())));
}, 1, "", true));
s_1446 = ((V)(JsStrBuf.Begin().V(s_1446).S(string.Concat("<g transform=\"", ToStr(Call(tanF_43, V.Undef, C_1443, ((V)(0D)), ((V)(BZ_1422)), ((V)((BR_1423 + 0.05))), th_1444, ((V)(8.6)))), "\"><rect x=\"-3\" y=\"0\" width=\"6\" height=\"4.2\" rx=\"1\" fill=\"#2a2b2e\"/><rect x=\"-2.4\" y=\"0.5\" width=\"4.8\" height=\"3.2\" rx=\"0.8\" fill=\"#d8322f\"/><rect x=\"-2.4\" y=\"0.5\" width=\"4.8\" height=\"1.4\" rx=\"0.6\" fill=\"#ffffff\" opacity=\"0.3\"/><text y=\"6.2\" text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"1.3\" fill=\"#8a857c\">ON \u00b7 OFF</text></g>")).S(string.Concat("<g transform=\"", ToStr(Call(tanF_43, V.Undef, C_1443, ((V)(0D)), ((V)(BZ_1422)), ((V)((BR_1423 + 0.05))), ((V)((ToNum(th_1444) - 0.12))), ((V)(3.6)))), "\"><text text-anchor=\"middle\" ", ToStr(FONT_36), " font-size=\"1.8\" fill=\"#cf2f2a\" letter-spacing=\"0.6\">POP\u00b7AIR</text></g>")).End()));
s_1446 = Add(s_1446, Call(cyl3_50, V.Undef, C_1443, Arr(((V)(0D)), ((V)(15.2)), ((V)(BZ_1422))), Arr(((V)(0D)), ((V)(26D)), ((V)(BZ_1422))), ((V)(HR_1424)), ((V)("#f2c142")), NewObj(7).Put("r2", ((V)(9.3))).Put("mat", ((V)("gloss"))).Put("op", ((V)(0.34))).Put("noCap", ((V)(1D))).Put("olc", ((V)("#a8781c"))).Put("olw", ((V)(0.4))).Put("olo", ((V)(0.6))).V));
kc_1447 = Invoke(C_1443, "p", ((V)(0D)), ((V)(18.5)), ((V)(BZ_1422)));
rx_1448 = ((HR_1424 * ToNum(Get(C_1443, "k"))) * 0.8);
ry_1449 = ((HR_1424 * ToNum(Get(C_1443, "k"))) * 0.3);
ring_1450 = ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(kc_1447, 0D)) - rx_1448))))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(kc_1447, 1D))), "a", ToStr(Call(f1_16, V.Undef, ((V)(rx_1448)))), " ", ToStr(Call(f1_16, V.Undef, ((V)(ry_1449)))), " 0 1 0 ", ToStr(Call(f1_16, V.Undef, ((V)((2D * rx_1448))))), " 0a", ToStr(Call(f1_16, V.Undef, ((V)(rx_1448)))), " ", ToStr(Call(f1_16, V.Undef, ((V)(ry_1449)))), " 0 1 0 ", ToStr(Call(f1_16, V.Undef, ((V)(((-2D) * rx_1448))))), " 0")));
s_1446 = Add(s_1446, Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis1475, int _argc1468, V i_1474, V _a1471, V _a1472, V _a1473, V[] _rest1469) => {
return ((V)(string.Concat("<ellipse rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.9 * ToNum(Get(C_1443, "k"))))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.65 * ToNum(Get(C_1443, "k"))))))), "\" fill=\"", (NumTruthy((ToNum(i_1474) % 3D)) ? "#e8a73a" : "#fff4d6"), "\" stroke=\"#9a6a1c\" stroke-width=\"0.2\"><animateMotion dur=\"", ToStr(Call(n4_17, V.Undef, ((V)((0.5 + ((ToNum(i_1474) % 4D) * 0.08)))))), "s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)(((-ToNum(i_1474)) * 0.13))))), "s\" repeatCount=\"indefinite\" path=\"", ToStr(ring_1450), "\"/>", ToStr(Call(an_33, V.Undef, ((V)("cy")), ((V)(string.Concat("0;", ToStr(Call(f1_16, V.Undef, ((V)(((-3D) - ((ToNum(i_1474) % 3D) * 2D)))))), ";0"))), ((V)((0.31 + ((ToNum(i_1474) % 3D) * 0.07)))), ((V)(((-ToNum(i_1474)) * 0.05))))), "</ellipse>")));
}, 1, "", true)), "join", ((V)(""))));
tl_1451 = 0.42;
ey_1452 = Arr(((V)(0D)), ((V)(FdLibm.Cos(tl_1451))), ((V)(FdLibm.Sin(tl_1451))));
ez_1453 = Arr(((V)(0D)), ((V)((-FdLibm.Sin(tl_1451)))), ((V)(FdLibm.Cos(tl_1451))));
s_1446 = Add(s_1446, Call(box3_48, V.Undef, C_1443, NewObj(13).Put("c", Arr(((V)(0D)), ((V)(18.4)), ((V)((BZ_1422 + 9.4))))).Put("ax", Arr(Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ey_1452, ez_1453)).Put("w", ((V)(12D))).Put("h", ((V)(5.6))).Put("d", ((V)(11D))).Put("r", ((V)(2D))).Put("col", ((V)("#f2c142"))).Put("op", ((V)(0.38))).Put("gl", ((V)(0.9))).Put("olc", ((V)("#a8781c"))).Put("olw", ((V)(0.4))).Put("olo", ((V)(0.6))).Put("edge", ((V)(0.6))).V));
H_1454 = Invoke(C_1443, "p", ((V)(0D)), ((V)(26D)), ((V)(BZ_1422)));
hx_1455 = (9.3 * ToNum(Get(C_1443, "k")));
s_1446 = ((V)(JsStrBuf.Begin().V(s_1446).S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(GetIdx(H_1454, 0D)) - hx_1455) + 1.2))))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(H_1454, 1D), ((V)(1D))))), "Q", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(GetIdx(H_1454, 0D)) - hx_1455) - 0.6))))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(H_1454, 1D), ((V)(14D))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(GetIdx(H_1454, 0D)) - hx_1455) + 1.6))))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(H_1454, 1D), ((V)(22D))))), "\" stroke=\"#ffffff\" stroke-opacity=\"0.6\" stroke-width=\"1.1\" fill=\"none\" stroke-linecap=\"round\"/>")).End()));
s_1446 = Add(s_1446, Call(cyl3_50, V.Undef, C_1443, Arr(((V)(0D)), ((V)(26D)), ((V)(BZ_1422))), Arr(((V)(0D)), ((V)(30.2)), ((V)(BZ_1422))), ((V)(7.3)), ((V)("#f2c230")), NewObj(4).Put("r2", ((V)(8.2))).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.4))).Put("cap", Fn((V _arrowThis1483, int _argc1476, V cr_1482, V _a1479, V _a1480, V _a1481, V[] _rest1477) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1482) * 0.86))))), "\" fill=\"#c98f12\"/><circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1482) * 0.86))))), "\" fill=\"url(#m10in)\"/><rect x=\"-2.2\" y=\"-1.4\" width=\"4.4\" height=\"3\" rx=\"0.6\" fill=\"#fff1a8\" transform=\"rotate(-12)\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_1482)) * 0.6))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_1482) * 0.6))))), "h3\" stroke=\"#a8761a\" stroke-width=\"0.35\"/>")));
}, 1, "cap", true)).V));
s_1446 = Add(s_1446, Call(cyl3_50, V.Undef, C_1443, Arr(((V)(BX_1425)), ((V)(0D)), ((V)(BWZ_1426))), Arr(((V)(BX_1425)), ((V)(9.5)), ((V)(BWZ_1426))), ((V)(7.5)), ((V)("#c8392f")), NewObj(4).Put("r2", ((V)(13.5))).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("olw", ((V)(0.45))).V));
rimP_1456 = Call(rep_18, V.Undef, ((V)(40D)), Fn((V _arrowThis1491, int _argc1484, V i_1490, V _a1487, V _a1488, V _a1489, V[] _rest1485) => {
double t_1492 = 0;
t_1492 = (((ToNum(i_1490) / 40D) * 2D) * PI_15);
return Invoke(C_1443, "p", ((V)((BX_1425 + (13.5 * FdLibm.Cos(t_1492))))), ((V)(9.5)), ((V)((BWZ_1426 + (13.5 * FdLibm.Sin(t_1492))))));
return default;
}, 1, "", true));
s_1446 = ((V)(JsStrBuf.Begin().V(s_1446).S(string.Concat("<path d=\"", ToStr(Call(pth_28, V.Undef, rimP_1456)), "\" fill=\"#6e1a14\"/><path d=\"", ToStr(Call(pth_28, V.Undef, rimP_1456)), "\" fill=\"url(#m10in)\"/>")).End()));
heap_1457 = Invoke(Call(rep_18, V.Undef, ((V)(46D)), Fn((V _arrowThis1508, int _argc1502, V _a1504, V _a1505, V _a1506, V _a1507, V[] _rest1503) => {
double a_1509 = 0;
double d_1510 = 0;
double x_1511 = 0;
double z_1512 = 0;
a_1509 = ((ToNum(Call(R_1445, V.Undef)) * 2D) * PI_15);
d_1510 = (System.Math.Sqrt(ToNum(Call(R_1445, V.Undef))) * 11.6);
x_1511 = (BX_1425 + (d_1510 * FdLibm.Cos(a_1509)));
z_1512 = (BWZ_1426 + (d_1510 * FdLibm.Sin(a_1509)));
return NewObj(4).Put("x", ((V)(x_1511))).Put("z", ((V)(z_1512))).Put("y", ((V)(((9.4 + (4.6 * (1D - Pow((d_1510 / 12.5), 2D)))) + (ToNum(Call(R_1445, V.Undef)) * 1.2))))).Put("r", ((V)((ToNum(Call(R_1445, V.Undef)) * 360D)))).V;
return default;
}, 0, "", true)), "sort", Fn((V _arrowThis1501, int _argc1493, V a_1499, V b_1500, V _a1497, V _a1498, V[] _rest1494) => {
return ((V)((ToNum(Add(Get(a_1499, "z"), ((V)((ToNum(Get(a_1499, "y")) * 0.3))))) - ToNum(Add(Get(b_1500, "z"), ((V)((ToNum(Get(b_1500, "y")) * 0.3))))))));
}, 2, "", true));
Invoke(heap_1457, "forEach", Fn((V _arrowThis1520, int _argc1513, V q_1519, V _a1516, V _a1517, V _a1518, V[] _rest1514) => {
return (s_1446 = Add(s_1446, Call(puffAt_60, V.Undef, C_1443, Arr(Get(q_1519, "x"), Get(q_1519, "y"), Get(q_1519, "z")), ((V)((0.95 + (ToNum(Call(R_1445, V.Undef)) * 0.25)))), Get(q_1519, "r"))));
}, 1, "", true));
rimF_1458 = Call(rep_18, V.Undef, ((V)(21D)), Fn((V _arrowThis1528, int _argc1521, V i_1527, V _a1524, V _a1525, V _a1526, V[] _rest1522) => {
double t_1529 = 0;
t_1529 = ((ToNum(i_1527) / 20D) * PI_15);
return Invoke(C_1443, "p", ((V)((BX_1425 + (13.5 * FdLibm.Cos(t_1529))))), ((V)(9.5)), ((V)((BWZ_1426 + (13.5 * FdLibm.Sin(t_1529))))));
return default;
}, 1, "", true));
s_1446 = ((V)(JsStrBuf.Begin().V(s_1446).S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(rimF_1458, "map", P2_19), "join", ((V)("L")))), "\" stroke=\"#e45a4e\" stroke-width=\"1.1\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Invoke(Invoke(rimF_1458, "map", P2_19), "join", ((V)("L")))), "\" stroke=\"#ffffff\" stroke-opacity=\"0.35\" stroke-width=\"0.4\" fill=\"none\" transform=\"translate(0 -0.4)\"/>")).End()));
m0_1459 = Invoke(C_1443, "p", ((V)(0D)), ((V)(17.8)), ((V)((BZ_1422 + 14.4))));
s_1446 = Add(s_1446, Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis1537, int _argc1530, V i_1536, V _a1533, V _a1534, V _a1535, V[] _rest1531) => {
V e_1538 = default;
V c_1539 = default;
double d_1540 = 0;
double b_1541 = 0;
e_1538 = Invoke(C_1443, "p", ((V)((BX_1425 + ((ToNum(Call(R_1445, V.Undef)) - 0.5) * 14D)))), ((V)((13.5 + (ToNum(Call(R_1445, V.Undef)) * 2D)))), ((V)((BWZ_1426 + ((ToNum(Call(R_1445, V.Undef)) - 0.5) * 12D)))));
c_1539 = Arr(((V)(((ToNum(Add(GetIdx(m0_1459, 0D), GetIdx(e_1538, 0D))) / 2D) + ((ToNum(Call(R_1445, V.Undef)) - 0.5) * 6D)))), ((V)(((Min(ToNum(GetIdx(m0_1459, 1D)), ToNum(GetIdx(e_1538, 1D))) - 6D) - (ToNum(Call(R_1445, V.Undef)) * 5D)))));
d_1540 = (0.9 + (ToNum(Call(R_1445, V.Undef)) * 0.5));
b_1541 = ((-ToNum(i_1536)) * 0.27);
return ((V)(string.Concat("<g opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;1;1;0\" keyTimes=\"0;0.08;0.85;1\" dur=\"", ToStr(Call(n4_17, V.Undef, ((V)(d_1540)))), "s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)(b_1541)))), "s\" repeatCount=\"indefinite\"/><animateMotion dur=\"", ToStr(Call(n4_17, V.Undef, ((V)(d_1540)))), "s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)(b_1541)))), "s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(P2_19, V.Undef, m0_1459)), "Q", ToStr(Call(P2_19, V.Undef, c_1539)), " ", ToStr(Call(P2_19, V.Undef, e_1538)), "\"/><g transform=\"scale(", ToStr(Call(n4_17, V.Undef, Get(C_1443, "k"))), ")\"><g>", ToStr(Call(at_34, V.Undef, ((V)("rotate")), ((V)(string.Concat("0;", NumStr((GtN(Call(R_1445, V.Undef), 0.5) ? 360D : (-360D)))))), ((V)((d_1540 * 0.9))))), ToStr(PUFF_59), "</g></g></g>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
return NewObj(3).Put("defs", DEF10_37).Put("front", s_1446).Put("bb", Invoke(C_1443, "bb", ((V)(8D)))).V;
return default;
}, 1, "", true));
return D_1427;
return default;
}, 1, "", true));
OPEN_61 = Fn((V _arrowThis1552, int _argc1542, V l_1548, V s_1549, V note_1550, V ex_1551, V[] _rest1543) => {
return Object_assign(NewObj(7).Put("play", ((V)("open"))).Put("playL", ((V)(JsStrBuf.Begin().S("Open the ").V(l_1548).End()))).Put("stopL", ((V)(JsStrBuf.Begin().S("Close the ").V(l_1548).End()))).Put("playS", s_1549).Put("idleS", ((V)(JsStrBuf.Begin().S("Tap to open the ").V(l_1548).End()))).Put("live", ((V)("Opens"))).Put("note", note_1550).V, (ex_1551 is var _t1553 && Truthy(_t1553) ? _t1553 : NewObj(0).V));
}, 4, "", true);
Set(RD_8, "SET10", NewObj(7).Put("MOV-002", NewObj(1).Put("name", ((V)("Wrinkled Bedsheet Projector Screen Tacked to Wall"))).V).Put("MOV-014", Object_assign(NewObj(1).Put("spec", ((V)("cool10"))).V, Call(OPEN_61, V.Undef, ((V)("lid")), ((V)("Lid open \u00b7 ice cold \u00b7 tap to close")), ((V)("A beaded white styrofoam cooler with molded bands, hand grips and a fitted lid. Tap it: the lid swings back onto its hinge edge, showing cans of soda buried in ice with two blue gel ice packs, and cold mist rolls out. Tap again to close it."))))).Put("MOV-022", NewObj(2).Put("spec", ((V)("plas10"))).Put("note", ((V)("A thick 42-inch piano-black plasma with a silver speaker strip, perforated grilles, a red standby light and a glossy glass screen. It hangs on a steel tilt bracket (rails and safety knobs peek out underneath) with its power cable dangling down the wall."))).V).Put("MOV-026", NewObj(2).Put("spec", ((V)("cproj10"))).Put("note", ((V)("A satin-white 1080p home projector hanging from a telescoping chrome ceiling pole on a spider cradle. Coated glass lens with focus ring, exhaust louvres, a control pad on top and a blinking status light."))).V).Put("MOV-030", NewObj(2).Put("spec", ((V)("sbar10"))).Put("note", ((V)("A fabric-wrapped 2.1 soundbar with top touch buttons and a row of status lights, plus a compact black subwoofer with an exposed driver and bass port. Tap it to play music: the woofer cone pumps and the lights dance."))).V).Put("MOV-031", NewObj(3).Put("spec", ((V)("popr10"))).Put("live", ((V)("Pops live"))).Put("note", ((V)("A red-and-white hot-air popper with a clear amber chute, a yellow butter cup on top and an ON/OFF rocker. Kernels whirl inside the chute and fluffy popcorn shoots out into a red bowl heaped with popcorn."))).V).Put("MOV-034", Object_assign(NewObj(1).Put("spec", ((V)("mfr10"))).V, Call(OPEN_61, V.Undef, ((V)("door")), ((V)("Door open \u00b7 cold light on \u00b7 tap to close")), ((V)("A glossy mint 6-can thermoelectric mini fridge with a recessed handle and a blue 4\u00b0C display. Tap it: the door swings open on its hinge to show two rows of three cans on a wire shelf, a spinning cooling fan and a cool blue glow. Tap again to close it."))))).V);
edit9_62 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis1561, int _argc1554, V rows_1560, V _a1557, V _a1558, V _a1559, V[] _rest1555) => {
return Invoke(Call(edit9_62, V.Undef, rows_1560), "map", Fn((V _arrowThis1569, int _argc1562, V r_1568, V _a1565, V _a1566, V _a1567, V[] _rest1563) => {
return (Truthy(GetK(Get(RD_8, "SET10"), Get(r_1568, "id"))) ? Object_assign(NewObj(0).V, r_1568, GetK(Get(RD_8, "SET10"), Get(r_1568, "id"))) : r_1568);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H10", NewObj(37).Put("PAT", PAT_46).Put("cam", cam_39).Put("box3", box3_48).Put("cyl3", cyl3_50).Put("sph", sph_51).Put("shadow", shadow_44).Put("tanF", tanF_43).Put("FR", FR_42).Put("flip", flip_53).Put("KV", KV_52).Put("easeA", easeA_54).Put("mist", mist_55).Put("lit", lit_40).Put("vis", vis_41).Put("yawA", yawA_45).Put("DEF10", DEF10_37).Put("can3", can3_58).Put("puffAt", puffAt_60).Put("PUFF", PUFF_59).Put("hull", hull_27).Put("pth", pth_28).Put("add", add_20).Put("sub", sub_21).Put("mul", mul_22).Put("dot", dot_23).Put("cross", cross_24).Put("nrm", nrm_25).Put("rng", rng_30).Put("isPlay", isPlay_31).Put("an", an_33).Put("at", at_34).Put("SPL", SPL_35).Put("f1", f1_16).Put("n4", n4_17).Put("rep", rep_18).Put("P2", P2_19).Put("FONT", FONT_36).V);
Set(RD_8, "PLUS10", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
