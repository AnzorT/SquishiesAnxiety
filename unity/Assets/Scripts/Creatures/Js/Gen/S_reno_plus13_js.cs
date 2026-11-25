// reno-plus13.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus13_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("#ffd34a", "");
        public static void Run()
        {
Call(Named(boot_416 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V shade_11 = default;
V N_12 = default;
double PI_13 = 0;
V H_14 = default;
V cam_15 = default;
V FR_16 = default;
V vis_17 = default;
V lit_18 = default;
V rng_19 = default;
V an_20 = default;
V at_21 = default;
V SPL_22 = default;
V f1_23 = default;
V n4_24 = default;
V rep_25 = default;
V pth_26 = default;
V FONT_27 = default;
V TR_28 = default;
V ginv_29 = default;
V px_30 = default;
V PP_31 = default;
V wk_32 = default;
V gv_33 = default;
V quad_34 = default;
V lineUV_35 = default;
V crv_36 = default;
V FDEF_37 = default;
V FL_38 = default;
V fblot_39 = default;
V fConc_40 = default;
V fTile_41 = default;
V fCrim_42 = default;
V fTeak_43 = default;
V fGlass_44 = default;
V FLOOR13_45 = default;
V draw12_46 = default;
V DEF13_47 = default;
V ellP_48 = default;
V rrP_49 = default;
V dP_50 = default;
V slab_51 = default;
V top_52 = default;
V face_53 = default;
V RUG_54 = default;
V edit12_55 = default;
if (_self1.IsNullish) _self1 = GlobalV;
fConc_40 = Fn((V _self56, int _argc57, V _a59, V _a60, V _a61, V _a62, V[] _rest58) => {
V R_63 = default;
JsStrBuf s_64 = null;
V J_65 = default;
V ck_66 = default;
V br_67 = default;
V br2_68 = default;
V cab_69 = default;
V A_70 = default;
V B_71 = default;
V tape_72 = default;
V mid_73 = default;
if (_self56.IsNullish) _self56 = GlobalV;
R_63 = Call(rng_19, V.Undef, ((V)("conc13")));
s_64 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#b3b1aa\"/>").V(Call(fblot_39, V.Undef, ((V)("conc")), ((V)(26D)), Arr(((V)("#c6c4bd")), ((V)("#9c9a93")), ((V)("#aba9a1"))), ((V)(0.55)), ((V)(8D)))).End());
s_64.V(Invoke(Call(rep_25, V.Undef, ((V)(70D)), Fn((V _arrowThis80, int _argc74, V _a76, V _a77, V _a78, V _a79, V[] _rest75) => {
V p_81 = default;
p_81 = Call(px_30, V.Undef, Call(R_63, V.Undef), Call(R_63, V.Undef));
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_81, 0D))), "\" cy=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_81, 1D))), "\" r=\"", ToStr(Call(f1_23, V.Undef, ((V)((0.22 + (ToNum(Call(R_63, V.Undef)) * 0.3)))))), "\" fill=\"", (LtN(Call(R_63, V.Undef), 0.55) ? "#8d8b84" : "#d4d2cb"), "\" opacity=\"0.75\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
{
V p_82 = default;
p_82 = Call(px_30, V.Undef, ((V)(0.72)), ((V)(0.3)));
s_64.S(string.Concat("<g filter=\"url(#fb1)\"><ellipse cx=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_82, 0D))), "\" cy=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_82, 1D))), "\" rx=\"", ToStr(Call(f1_23, V.Undef, ((V)((7.5 * ToNum(Call(wk_32, V.Undef, ((V)(0.3))))))))), "\" ry=\"2.8\" fill=\"#5c5950\" opacity=\"0.32\"/><ellipse cx=\"", ToStr(Call(f1_23, V.Undef, Add(GetIdx(p_82, 0D), ((V)(2D))))), "\" cy=\"", ToStr(Call(f1_23, V.Undef, Add(GetIdx(p_82, 1D), ((V)(0.6))))), "\" rx=\"", ToStr(Call(f1_23, V.Undef, ((V)((3.6 * ToNum(Call(wk_32, V.Undef, ((V)(0.3))))))))), "\" ry=\"1.4\" fill=\"#4a473f\" opacity=\"0.3\"/></g>"));
}
J_65 = Fn((V _arrowThis90, int _argc83, V pts_89, V _a86, V _a87, V _a88, V[] _rest84) => {
return ((V)(string.Concat("<path d=\"", ToStr(Call(lineUV_35, V.Undef, pts_89)), "\" stroke=\"#d6d4cd\" stroke-width=\"0.3\" fill=\"none\" transform=\"translate(0.25 0.3)\"/><path d=\"", ToStr(Call(lineUV_35, V.Undef, pts_89)), "\" stroke=\"#7a7871\" stroke-width=\"0.4\" fill=\"none\"/>")));
}, 1, "", true);
Call(rep_25, V.Undef, ((V)(4D)), Fn((V _arrowThis98, int _argc91, V k_97, V _a94, V _a95, V _a96, V[] _rest92) => {
return ((V)(s_64.V(Call(J_65, V.Undef, Arr(Arr(((V)((ToNum(Add(k_97, ((V)(1D)))) / 5D))), ((V)(0D))), Arr(((V)((ToNum(Add(k_97, ((V)(1D)))) / 5D))), ((V)(1D)))))).Str));
}, 1, "", true));
Invoke(Arr(((V)(1D)), ((V)(2D)), ((V)(3D))), "forEach", Fn((V _arrowThis106, int _argc99, V k_105, V _a102, V _a103, V _a104, V[] _rest100) => {
return ((V)(s_64.V(Call(J_65, V.Undef, Arr(Arr(((V)(0D)), Call(gv_33, V.Undef, ((V)((ToNum(k_105) / 4D))))), Arr(((V)(1D)), Call(gv_33, V.Undef, ((V)((ToNum(k_105) / 4D)))))))).Str));
}, 1, "", true));
ck_66 = Arr(Arr(((V)(0.1)), ((V)(0.58))), Arr(((V)(0.16)), ((V)(0.63))), Arr(((V)(0.21)), ((V)(0.61))), Arr(((V)(0.26)), ((V)(0.7))), Arr(((V)(0.31)), ((V)(0.72))), Arr(((V)(0.33)), ((V)(0.82))), Arr(((V)(0.4)), ((V)(0.87))), Arr(((V)(0.45)), ((V)(1.02))));
br_67 = Arr(Arr(((V)(0.26)), ((V)(0.7))), Arr(((V)(0.21)), ((V)(0.79))), Arr(((V)(0.23)), ((V)(0.87))));
br2_68 = Arr(Arr(((V)(0.16)), ((V)(0.63))), Arr(((V)(0.14)), ((V)(0.7))));
s_64.S(string.Concat("<g fill=\"none\" stroke-linejoin=\"round\" stroke-linecap=\"round\"><path d=\"", ToStr(Call(lineUV_35, V.Undef, ck_66)), "\" stroke=\"#e2e0d9\" stroke-width=\"1\" transform=\"translate(0.35 0.4)\" opacity=\"0.8\"/><path d=\"", ToStr(Call(lineUV_35, V.Undef, ck_66)), "\" stroke=\"#54524c\" stroke-width=\"0.75\"/><path d=\"", ToStr(Call(lineUV_35, V.Undef, br_67)), "\" stroke=\"#54524c\" stroke-width=\"0.45\"/><path d=\"", ToStr(Call(lineUV_35, V.Undef, br2_68)), "\" stroke=\"#54524c\" stroke-width=\"0.35\"/></g>"));
s_64.S(string.Concat("<path d=\"", ToStr(Call(lineUV_35, V.Undef, Arr(Arr(((V)(0.3)), ((V)(0.73))), Arr(((V)(0.36)), ((V)(0.71))), Arr(((V)(0.375)), ((V)(0.77))), Arr(((V)(0.33)), ((V)(0.795)))))), "Z\" fill=\"#9a978e\" stroke=\"#6e6b64\" stroke-width=\"0.35\" stroke-linejoin=\"round\"/><path d=\"", ToStr(Call(lineUV_35, V.Undef, Arr(Arr(((V)(0.31)), ((V)(0.735))), Arr(((V)(0.355)), ((V)(0.72)))))), "\" stroke=\"#c9c7c0\" stroke-width=\"0.35\"/>"));
cab_69 = Fn((V _arrowThis116, int _argc107, V pts_113, V col_114, V w_115, V _a112, V[] _rest108) => {
V d_117 = default;
d_117 = Call(crv_36, V.Undef, pts_113);
return ((V)(string.Concat("<path d=\"", ToStr(d_117), "\" stroke=\"#000000\" stroke-opacity=\"0.28\" stroke-width=\"", ToStr(Add(w_115, ((V)(0.8)))), "\" fill=\"none\" stroke-linecap=\"round\" transform=\"translate(0.5 1)\" filter=\"url(#fb1)\"/><path d=\"", ToStr(d_117), "\" stroke=\"", ToStr(Call(shade_11, V.Undef, col_114, ((V)(0.6)))), "\" stroke-width=\"", ToStr(Add(w_115, ((V)(0.4)))), "\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"", ToStr(d_117), "\" stroke=\"", ToStr(col_114), "\" stroke-width=\"", ToStr(w_115), "\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"", ToStr(d_117), "\" stroke=\"#ffffff\" stroke-opacity=\"0.35\" stroke-width=\"", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(w_115) * 0.28))))), "\" fill=\"none\" transform=\"translate(-0.15 -0.35)\"/>")));
return default;
}, 3, "", true);
A_70 = Arr(Arr(((V)((-0.05))), ((V)(0.52))), Arr(((V)(0.15)), ((V)(0.48))), Arr(((V)(0.35)), ((V)(0.56))), Arr(((V)(0.55)), ((V)(0.5))), Arr(((V)(0.75)), ((V)(0.6))), Arr(((V)(1.05)), ((V)(0.55))));
B_71 = Arr(Arr(((V)((-0.05))), ((V)(0.7))), Arr(((V)(0.2)), ((V)(0.77))), Arr(((V)(0.45)), ((V)(0.7))), Arr(((V)(0.62)), ((V)(0.81))), Arr(((V)(0.85)), ((V)(0.74))), Arr(((V)(1.05)), ((V)(0.83))));
s_64.V(Add(Call(cab_69, V.Undef, A_70, ((V)("#2b2c31")), ((V)(0.8))), Call(cab_69, V.Undef, B_71, ((V)("#e2783a")), ((V)(0.95)))));
tape_72 = Fn((V _arrowThis127, int _argc118, V u_124, V v_125, V sk_126, V _a123, V[] _rest119) => {
V Q_128 = default;
V d_129 = default;
Q_128 = Arr(Arr(((V)((ToNum(u_124) - 0.018))), ((V)((ToNum(v_125) - 0.042)))), Arr(Add(Add(u_124, ((V)(0.017))), sk_126), ((V)((ToNum(v_125) - 0.04)))), Arr(Add(Add(u_124, ((V)(0.02))), sk_126), Add(v_125, ((V)(0.042)))), Arr(((V)((ToNum(u_124) - 0.016))), Add(v_125, ((V)(0.045)))));
d_129 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Q_128, "map", Fn((V _arrowThis141, int _argc130, V _a132, V _a133, V _a134, V _a135, V[] _rest131) => {
V a_138 = default;
V b_140 = default;
{ V _t136 = ListOf(_a132);
{ V _t137 = GetIdx(_t136, 0D);
a_138 = _t137; }
{ V _t139 = GetIdx(_t136, 1D);
b_140 = _t139; }
}
return Call(PP_31, V.Undef, a_138, b_140);
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
return ((V)(string.Concat("<path d=\"", ToStr(d_129), "\" fill=\"#000000\" opacity=\"0.25\" transform=\"translate(0.4 0.8)\" filter=\"url(#fb1)\"/><path d=\"", ToStr(d_129), "\" fill=\"#c2c6cb\" stroke=\"#868b92\" stroke-width=\"0.3\" stroke-linejoin=\"round\"/><path d=\"", ToStr(Call(lineUV_35, V.Undef, Arr(Arr(((V)((ToNum(u_124) - 0.012))), ((V)((ToNum(v_125) - 0.034)))), Arr(Add(Add(u_124, ((V)(0.012))), sk_126), ((V)((ToNum(v_125) - 0.032))))))), "\" stroke=\"#f1f3f5\" stroke-width=\"0.3\"/><path d=\"", ToStr(Call(lineUV_35, V.Undef, Arr(Arr(((V)((ToNum(u_124) - 0.006))), ((V)((ToNum(v_125) - 0.018)))), Arr(Add(u_124, ((V)(0.006))), Add(v_125, ((V)(0.02))))))), "\" stroke=\"#9a9fa6\" stroke-width=\"0.2\"/>")));
return default;
}, 3, "", true);
mid_73 = Fn((V _arrowThis150, int _argc142, V P_148, V i_149, V _a146, V _a147, V[] _rest143) => {
return Arr(((V)((ToNum(Add(GetIdx(GetK(P_148, i_149), 0D), GetIdx(GetK(P_148, Add(i_149, ((V)(1D)))), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(GetK(P_148, i_149), 1D), GetIdx(GetK(P_148, Add(i_149, ((V)(1D)))), 1D))) / 2D))));
}, 2, "", true);
Invoke(Arr(Arr(A_70, ((V)(1D)), ((V)(0.006))), Arr(A_70, ((V)(3D)), ((V)((-0.004)))), Arr(B_71, ((V)(1D)), ((V)(0.004))), Arr(B_71, ((V)(3D)), ((V)((-0.006)))), Arr(B_71, ((V)(4D)), ((V)(0.005)))), "forEach", Fn((V _arrowThis164, int _argc151, V _a153, V _a154, V _a155, V _a156, V[] _rest152) => {
V m_165 = default;
V P_159 = default;
V i_161 = default;
V sk_163 = default;
{ V _t157 = ListOf(_a153);
{ V _t158 = GetIdx(_t157, 0D);
P_159 = _t158; }
{ V _t160 = GetIdx(_t157, 1D);
i_161 = _t160; }
{ V _t162 = GetIdx(_t157, 2D);
sk_163 = _t162; }
}
m_165 = Call(mid_73, V.Undef, P_159, i_161);
s_64.V(Call(tape_72, V.Undef, GetIdx(m_165, 0D), GetIdx(m_165, 1D), sk_163));
return default;
}, 1, "", true));
return Call(FL_38, V.Undef, ((V)(s_64.Str)));
return default;
}, 0, "fConc", false);
fTile_41 = Fn((V _self166, int _argc167, V _a169, V _a170, V _a171, V _a172, V[] _rest168) => {
double NU_173 = 0;
double NV_174 = 0;
V V_175 = default;
JsStrBuf s_176 = null;
JsStrBuf pile_177 = null;
JsStrBuf seam_178 = null;
double cu_179 = 0;
V cv_180 = default;
V a_181 = default;
V b_182 = default;
V c_183 = default;
V tp_184 = default;
V P_185 = default;
if (_self166.IsNullish) _self166 = GlobalV;
NU_173 = 14D;
NV_174 = 8D;
V_175 = Call(rep_25, V.Undef, ((V)((NV_174 + 1D))), Fn((V _arrowThis193, int _argc186, V k_192, V _a189, V _a190, V _a191, V[] _rest187) => {
return Call(gv_33, V.Undef, ((V)((ToNum(k_192) / NV_174))));
}, 1, "", true));
s_176 = new JsStrBuf("<rect width=\"80\" height=\"56\" fill=\"#8a8f96\"/>");
pile_177 = new JsStrBuf("");
seam_178 = new JsStrBuf("");
{
double v_194 = 0;
v_194 = 0D;
while (true) {
if (!((v_194 < NV_174))) break;
{
V u_196 = default;
u_196 = ((V)(0D));
while (true) {
V u_196_it = u_196;
if (!(LtN(u_196_it, NU_173))) break;
double odd_198 = 0;
V col_199 = default;
V v0_200 = default;
V v1_201 = default;
odd_198 = (ToNum(Add(u_196_it, ((V)(v_194)))) % 2D);
col_199 = ((V)((((SEqN(u_196_it, 9D) && (v_194 == 2D)) || (SEqN(u_196_it, 3D) && (v_194 == 6D))) ? "#7d8997" : (NumTruthy(odd_198) ? "#83888f" : "#8f949b"))));
v0_200 = GetIdx(V_175, v_194);
v1_201 = GetIdx(V_175, (v_194 + 1D));
s_176.S(string.Concat("<path d=\"", ToStr(Call(quad_34, V.Undef, ((V)((ToNum(u_196_it) / NU_173))), v0_200, ((V)((ToNum(Add(u_196_it, ((V)(1D)))) / NU_173))), v1_201)), "\" fill=\"", ToStr(col_199), "\"/>"));
Call(rep_25, V.Undef, ((V)(3D)), Fn((V _arrowThis209, int _argc202, V k_208, V _a205, V _a206, V _a207, V[] _rest203) => {
pile_177.V((NumTruthy(odd_198) ? Call(lineUV_35, V.Undef, Arr(Arr(((V)((ToNum(u_196_it) / NU_173))), Add(v0_200, ((V)((((ToNum(v1_201) - ToNum(v0_200)) * ToNum(Add(k_208, ((V)(0.5))))) / 3D))))), Arr(((V)((ToNum(Add(u_196_it, ((V)(1D)))) / NU_173))), Add(v0_200, ((V)((((ToNum(v1_201) - ToNum(v0_200)) * ToNum(Add(k_208, ((V)(0.5))))) / 3D))))))) : Call(lineUV_35, V.Undef, Arr(Arr(((V)((ToNum(Add(u_196_it, ((V)((ToNum(Add(k_208, ((V)(0.5)))) / 3D))))) / NU_173))), v0_200), Arr(((V)((ToNum(Add(u_196_it, ((V)((ToNum(Add(k_208, ((V)(0.5)))) / 3D))))) / NU_173))), v1_201)))));
return default;
}, 1, "", true));
u_196 = u_196_it;
PostInc(ref u_196, 1D);
}
}
v_194++;
}
}
s_176.S(string.Concat("<path d=\"", pile_177.Str, "\" stroke=\"#000000\" stroke-opacity=\"0.07\" stroke-width=\"0.3\" fill=\"none\"/>")).V(Call(fblot_39, V.Undef, ((V)("ct")), ((V)(18D)), Arr(((V)("#9ca1a8")), ((V)("#777c83"))), ((V)(0.4)), ((V)(9D))));
s_176.S(string.Concat("<path d=\"", ToStr(Call(quad_34, V.Undef, ((V)(0.38)), ((V)(0D)), ((V)(0.62)), ((V)(1D)))), "\" fill=\"#a5aab0\" opacity=\"0.35\" filter=\"url(#fb3)\"/>"));
{
V p_210 = default;
p_210 = Call(px_30, V.Undef, ((V)(0.78)), ((V)(0.66)));
s_176.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_210, 0D))), "\" cy=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_210, 1D))), "\" rx=\"", ToStr(Call(f1_23, V.Undef, ((V)((3D * ToNum(Call(wk_32, V.Undef, ((V)(0.66))))))))), "\" ry=\"1.6\" fill=\"#6a6258\" opacity=\"0.28\" filter=\"url(#fb1)\"/>"));
}
{
double u_211 = 0;
u_211 = 1D;
while (true) {
if (!((u_211 < NU_173))) break;
seam_178.V(Call(lineUV_35, V.Undef, Arr(Arr(((V)((u_211 / NU_173))), ((V)(0D))), Arr(((V)((u_211 / NU_173))), ((V)(1D))))));
u_211++;
}
}
{
double v_213 = 0;
v_213 = 1D;
while (true) {
if (!((v_213 < NV_174))) break;
seam_178.V(Call(lineUV_35, V.Undef, Arr(Arr(((V)(0D)), GetIdx(V_175, v_213)), Arr(((V)(1D)), GetIdx(V_175, v_213)))));
v_213++;
}
}
s_176.S(string.Concat("<path d=\"", seam_178.Str, "\" stroke=\"#a9aeb4\" stroke-width=\"0.25\" fill=\"none\" transform=\"translate(0.2 0.25)\"/><path d=\"", seam_178.Str, "\" stroke=\"#5c6168\" stroke-width=\"0.32\" fill=\"none\"/>"));
cu_179 = (5D / 14D);
cv_180 = GetIdx(V_175, 6D);
a_181 = Call(px_30, V.Undef, ((V)(cu_179)), ((V)((ToNum(cv_180) - 0.04))));
b_182 = Call(px_30, V.Undef, ((V)((cu_179 - 0.024))), cv_180);
c_183 = Call(px_30, V.Undef, ((V)(cu_179)), cv_180);
tp_184 = Arr(((V)(((ToNum(Add(GetIdx(a_181, 0D), GetIdx(b_182, 0D))) / 2D) - 0.6))), ((V)(((ToNum(Add(GetIdx(a_181, 1D), GetIdx(b_182, 1D))) / 2D) - 0.9))));
P_185 = Fn((V _arrowThis222, int _argc215, V q_221, V _a218, V _a219, V _a220, V[] _rest216) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(q_221, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_221, 1D))).End()));
}, 1, "", true);
s_176.S(string.Concat("<path d=\"M", ToStr(Call(P_185, V.Undef, a_181)), "L", ToStr(Call(P_185, V.Undef, c_183)), "L", ToStr(Call(P_185, V.Undef, b_182)), "Z\" fill=\"#3e4146\"/><path d=\"M", ToStr(Call(P_185, V.Undef, a_181)), "L", ToStr(Call(P_185, V.Undef, tp_184)), "L", ToStr(Call(P_185, V.Undef, b_182)), "Z\" fill=\"#000000\" opacity=\"0.3\" transform=\"translate(0.5 1)\" filter=\"url(#fb1)\"/><path d=\"M", ToStr(Call(P_185, V.Undef, a_181)), "Q", ToStr(Call(f1_23, V.Undef, Add(GetIdx(tp_184, 0D), ((V)(1.4))))), " ", ToStr(Call(f1_23, V.Undef, Add(GetIdx(tp_184, 1D), ((V)(0.4))))), " ", ToStr(Call(P_185, V.Undef, tp_184)), "Q", ToStr(Call(f1_23, V.Undef, Add(GetIdx(tp_184, 0D), ((V)(0.4))))), " ", ToStr(Call(f1_23, V.Undef, Add(GetIdx(tp_184, 1D), ((V)(1.6))))), " ", ToStr(Call(P_185, V.Undef, b_182)), "Z\" fill=\"#a4a9af\" stroke=\"#5c6168\" stroke-width=\"0.3\" stroke-linejoin=\"round\"/>"));
return Call(FL_38, V.Undef, ((V)(s_176.Str)));
return default;
}, 0, "fTile", false);
fCrim_42 = Fn((V _self223, int _argc224, V _a226, V _a227, V _a228, V _a229, V[] _rest225) => {
JsStrBuf s_230 = null;
JsStrBuf lat_231 = null;
JsStrBuf dots_232 = null;
double a_233 = 0;
V CS_234 = default;
if (_self223.IsNullish) _self223 = GlobalV;
s_230 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#9a1d2c\"/>").V(Call(fblot_39, V.Undef, ((V)("crim")), ((V)(24D)), Arr(((V)("#b02a3c")), ((V)("#7e1626"))), ((V)(0.5)), ((V)(8D)))).End());
lat_231 = new JsStrBuf("");
dots_232 = new JsStrBuf("");
a_233 = 0.5;
CS_234 = Arr();
{
double c_235 = 0;
c_235 = (-0.56);
while (true) {
if (!((c_235 <= 1.06))) break;
Invoke(CS_234, "push", ((V)(c_235)));
c_235 = (c_235 + (1D / 16D));
}
}
Invoke(CS_234, "forEach", Fn((V _arrowThis244, int _argc237, V c_243, V _a240, V _a241, V _a242, V[] _rest238) => {
lat_231.V(Add(Call(lineUV_35, V.Undef, Arr(Arr(c_243, ((V)(0D))), Arr(Add(c_243, ((V)(a_233))), ((V)(1D))))), Call(lineUV_35, V.Undef, Arr(Arr(Add(c_243, ((V)(a_233))), ((V)(0D))), Arr(c_243, ((V)(1D)))))));
return default;
}, 1, "", true));
Invoke(CS_234, "forEach", Fn((V _arrowThis252, int _argc245, V c1_251, V _a248, V _a249, V _a250, V[] _rest246) => {
return Invoke(CS_234, "forEach", Fn((V _arrowThis260, int _argc253, V c2_259, V _a256, V _a257, V _a258, V[] _rest254) => {
double v_261 = 0;
V u_262 = default;
V p_263 = default;
double z_264 = 0;
v_261 = ((ToNum(Add(c2_259, ((V)(a_233)))) - ToNum(c1_251)) / (2D * a_233));
u_262 = Add(c1_251, ((V)((a_233 * v_261))));
if (((((v_261 < 0D) || (v_261 > 1D)) || LtN(u_262, (-0.03))) || GtN(u_262, 1.03))) {
return default;
}
p_263 = Call(px_30, V.Undef, u_262, ((V)(v_261)));
z_264 = (0.55 * ToNum(Call(wk_32, V.Undef, ((V)(v_261)))));
dots_232.S(string.Concat("<path d=\"M", ToStr(Call(f1_23, V.Undef, GetIdx(p_263, 0D))), " ", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(p_263, 1D)) - (z_264 * 0.62)))))), "L", ToStr(Call(f1_23, V.Undef, Add(GetIdx(p_263, 0D), ((V)(z_264))))), " ", ToStr(Call(f1_23, V.Undef, GetIdx(p_263, 1D))), "L", ToStr(Call(f1_23, V.Undef, GetIdx(p_263, 0D))), " ", ToStr(Call(f1_23, V.Undef, Add(GetIdx(p_263, 1D), ((V)((z_264 * 0.62)))))), "L", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(p_263, 0D)) - z_264))))), " ", ToStr(Call(f1_23, V.Undef, GetIdx(p_263, 1D))), "Z\"/>"));
return default;
}, 1, "", true));
}, 1, "", true));
s_230.S(string.Concat("<path d=\"", lat_231.Str, "\" stroke=\"#e8b850\" stroke-opacity=\"0.2\" stroke-width=\"0.25\" fill=\"none\"/><g fill=\"#efc25a\" opacity=\"0.6\">", dots_232.Str, "</g>"));
Invoke(Arr(((V)(0.2)), ((V)(0.8))), "forEach", Fn((V _arrowThis272, int _argc265, V u_271, V _a268, V _a269, V _a270, V[] _rest266) => {
V ln_273 = default;
ln_273 = Call(lineUV_35, V.Undef, Arr(Arr(u_271, ((V)(1D))), Arr(u_271, ((V)(0D)))));
s_230.S(string.Concat("<path d=\"", ToStr(ln_273), "\" stroke=\"#ffb347\" stroke-width=\"3\" opacity=\"0.3\" filter=\"url(#fb2)\"/><path d=\"", ToStr(Call(quad_34, V.Undef, ((V)((ToNum(u_271) - 0.011))), ((V)(0D)), Add(u_271, ((V)(0.011))), ((V)(1D)))), "\" fill=\"#241a1e\" stroke=\"#c9a24a\" stroke-width=\"0.25\"/>"));
s_230.V(Invoke(Call(rep_25, V.Undef, ((V)(26D)), Fn((V _arrowThis281, int _argc274, V i_280, V _a277, V _a278, V _a279, V[] _rest275) => {
V v_282 = default;
V p_283 = default;
double r_284 = 0;
V b_285 = default;
v_282 = Call(gv_33, V.Undef, ((V)((ToNum(Add(i_280, ((V)(0.5)))) / 26D))));
p_283 = Call(px_30, V.Undef, u_271, v_282);
r_284 = ((0.3 * ToNum(Call(wk_32, V.Undef, v_282))) + 0.1);
b_285 = Call(n4_24, V.Undef, ((V)(((-(ToNum(i_280) / 26D)) * 1.8))));
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_283, 0D))), "\" cy=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_283, 1D))), "\" r=\"", ToStr(Call(f1_23, V.Undef, ((V)((r_284 * 3.2))))), "\" fill=\"#ffb347\" opacity=\"0.05\" filter=\"url(#fb1)\">", ToStr(Call(an_20, V.Undef, ((V)("opacity")), ((V)("0.05;0.45;0.05")), ((V)(1.8)), b_285)), "</circle><circle cx=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_283, 0D))), "\" cy=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_283, 1D))), "\" r=\"", ToStr(Call(f1_23, V.Undef, ((V)(r_284)))), "\" fill=\"#ffe0a0\" opacity=\"0.35\">", ToStr(Call(an_20, V.Undef, ((V)("opacity")), ((V)("0.35;1;0.35")), ((V)(1.8)), b_285)), "</circle>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
return default;
}, 1, "", true));
return Call(FL_38, V.Undef, ((V)(s_230.Str)));
return default;
}, 0, "fCrim", false);
fTeak_43 = Fn((V _self286, int _argc287, V _a289, V _a290, V _a291, V _a292, V[] _rest288) => {
double NP_293 = 0;
V R_294 = default;
V PC_295 = default;
JsStrBuf s_296 = null;
JsStrBuf lines_297 = null;
if (_self286.IsNullish) _self286 = GlobalV;
NP_293 = 26D;
R_294 = Call(rng_19, V.Undef, ((V)("teak13")));
PC_295 = Arr(((V)("#5e3722")), ((V)("#683d24")), ((V)("#52311e")), ((V)("#6f4227")), ((V)("#5a3421")));
s_296 = new JsStrBuf("<defs><radialGradient id=\"tkh\" cx=\"50%\" cy=\"72%\" r=\"60%\"><stop offset=\"0\" stop-color=\"#ff9a3a\" stop-opacity=\"0.24\"/><stop offset=\"1\" stop-color=\"#ff9a3a\" stop-opacity=\"0\"/></radialGradient></defs><rect width=\"80\" height=\"56\" fill=\"#4e2e1b\"/>");
lines_297 = new JsStrBuf("");
{
double i_298 = 0;
i_298 = 0D;
while (true) {
if (!((i_298 < NP_293))) break;
double u0_300 = 0;
double u1_301 = 0;
V cuts_302 = default;
double cv_303 = 0;
u0_300 = (i_298 / NP_293);
u1_301 = ((i_298 + 1D) / NP_293);
cuts_302 = Arr(((V)(0D)));
cv_303 = (ToNum(Call(R_294, V.Undef)) * 0.25);
while ((cv_303 < 0.94)) {
Invoke(cuts_302, "push", Call(gv_33, V.Undef, ((V)(cv_303))));
cv_303 = (cv_303 + (0.2 + (ToNum(Call(R_294, V.Undef)) * 0.16)));
}
Invoke(cuts_302, "push", ((V)(1D)));
{
double j_304 = 0;
j_304 = 0D;
while (true) {
if (!((j_304 < (ToNum(Get(cuts_302, "length")) - 1D)))) break;
s_296.S(string.Concat("<path d=\"", ToStr(Call(quad_34, V.Undef, ((V)(u0_300)), GetIdx(cuts_302, j_304), ((V)(u1_301)), GetIdx(cuts_302, (j_304 + 1D)))), "\" fill=\"", ToStr(Call(shade_11, V.Undef, GetIdx(PC_295, (((i_298 * 2D) + j_304) % 5D)), ((V)((0.92 + (ToNum(Call(R_294, V.Undef)) * 0.16)))))), "\"/>"));
if (NumTruthy(j_304)) {
lines_297.S(string.Concat("<path d=\"", ToStr(Call(lineUV_35, V.Undef, Arr(Arr(((V)(u0_300)), GetIdx(cuts_302, j_304)), Arr(((V)(u1_301)), GetIdx(cuts_302, j_304))))), "\" stroke=\"#2a160b\" stroke-width=\"0.3\"/>"));
}
j_304++;
}
}
{
double ub_306 = 0;
double ph_307 = 0;
V pts_308 = default;
ub_306 = (u0_300 + ((0.5 + ((ToNum(Call(R_294, V.Undef)) - 0.5) * 0.3)) / NP_293));
ph_307 = (ToNum(Call(R_294, V.Undef)) * 6D);
pts_308 = Call(rep_25, V.Undef, ((V)(9D)), Fn((V _arrowThis316, int _argc309, V j_315, V _a312, V _a313, V _a314, V[] _rest310) => {
return Arr(((V)((ub_306 + (0.003 * FdLibm.Sin(((ToNum(j_315) * 1.3) + ph_307)))))), ((V)((ToNum(j_315) / 8D))));
}, 1, "", true));
s_296.S(string.Concat("<path d=\"", ToStr(Call(crv_36, V.Undef, pts_308)), "\" stroke=\"#2c170b\" stroke-opacity=\"0.24\" stroke-width=\"0.22\" fill=\"none\"/><path d=\"", ToStr(Call(crv_36, V.Undef, Invoke(pts_308, "map", Fn((V _arrowThis328, int _argc317, V _a319, V _a320, V _a321, V _a322, V[] _rest318) => {
V x_325 = default;
V y_327 = default;
{ V _t323 = ListOf(_a319);
{ V _t324 = GetIdx(_t323, 0D);
x_325 = _t324; }
{ V _t326 = GetIdx(_t323, 1D);
y_327 = _t326; }
}
return Arr(Add(x_325, ((V)(0.004))), y_327);
}, 1, "", true)))), "\" stroke=\"#c88a58\" stroke-opacity=\"0.16\" stroke-width=\"0.25\" fill=\"none\"/>"));
}
lines_297.S(string.Concat("<path d=\"", ToStr(Call(lineUV_35, V.Undef, Arr(Arr(((V)(u0_300)), ((V)(0D))), Arr(((V)(u0_300)), ((V)(1D)))))), "\" stroke=\"#231208\" stroke-width=\"0.32\"/>"));
i_298++;
}
}
s_296.V(Call(fblot_39, V.Undef, ((V)("teak")), ((V)(16D)), Arr(((V)("#80502f")), ((V)("#3a2112"))), ((V)(0.3)), ((V)(8D)))).S(lines_297.Str);
s_296.S(string.Concat("<g filter=\"url(#fb3)\"><ellipse cx=\"40\" cy=\"9\" rx=\"17\" ry=\"3.2\" fill=\"#ffe9c8\" opacity=\"0.22\"/><path d=\"", ToStr(Call(quad_34, V.Undef, ((V)(0.42)), ((V)(0.05)), ((V)(0.58)), ((V)(0.55)))), "\" fill=\"#ffe6c0\" opacity=\"0.08\"/></g>"));
s_296.S(string.Concat("<path d=\"", ToStr(TR_28), "\" fill=\"url(#tkh)\">", ToStr(Call(an_20, V.Undef, ((V)("opacity")), ((V)("0.55;1;0.55")), ((V)(6D)), ((V)(0D)), Call(SPL_22, V.Undef, ((V)(2D))))), "</path>"));
Invoke(Arr(((V)(0.07)), ((V)(0.93))), "forEach", Fn((V _arrowThis337, int _argc329, V u_335, V i_336, V _a333, V _a334, V[] _rest330) => {
V ln_338 = default;
ln_338 = Call(lineUV_35, V.Undef, Arr(Arr(u_335, ((V)(1D))), Arr(u_335, ((V)(0D)))));
s_296.S(string.Concat("<path d=\"", ToStr(Call(quad_34, V.Undef, ((V)((ToNum(u_335) - 0.008))), ((V)(0D)), Add(u_335, ((V)(0.008))), ((V)(1D)))), "\" fill=\"#160b05\"/><path d=\"", ToStr(ln_338), "\" stroke=\"#ffcf7a\" stroke-width=\"3\" opacity=\"0.45\" filter=\"url(#fb2)\">", ToStr(Call(an_20, V.Undef, ((V)("opacity")), ((V)("0.35;0.65;0.35")), ((V)(4D)), ((V)(((-ToNum(i_336)) * 2D))), Call(SPL_22, V.Undef, ((V)(2D))))), "</path><path d=\"", ToStr(ln_338), "\" stroke=\"#ffe7b8\" stroke-width=\"0.55\"/>")).S(string.Concat("<path d=\"", ToStr(ln_338), "\" stroke=\"#ffffff\" stroke-width=\"1.1\" stroke-linecap=\"round\" stroke-dasharray=\"5 66\" opacity=\"0.9\"><animate attributeName=\"stroke-dashoffset\" values=\"0;-71\" dur=\"3s\" begin=\"", NumStr(((-ToNum(i_336)) * 1.5)), "s\" repeatCount=\"indefinite\"/></path>"));
return default;
}, 2, "", true));
return Call(FL_38, V.Undef, ((V)(s_296.Str)), ((V)(1D)));
return default;
}, 0, "fTeak", false);
fGlass_44 = Fn((V _self339, int _argc340, V _a342, V _a343, V _a344, V _a345, V[] _rest341) => {
double NU_346 = 0;
double NV_347 = 0;
V V_348 = default;
V R_349 = default;
V CL_350 = default;
double m_351 = 0;
JsStrBuf s_352 = null;
JsStrBuf seam_353 = null;
if (_self339.IsNullish) _self339 = GlobalV;
NU_346 = 12D;
NV_347 = 7D;
V_348 = Call(rep_25, V.Undef, ((V)((NV_347 + 1D))), Fn((V _arrowThis361, int _argc354, V k_360, V _a357, V _a358, V _a359, V[] _rest355) => {
return Call(gv_33, V.Undef, ((V)((ToNum(k_360) / NV_347))));
}, 1, "", true));
R_349 = Call(rng_19, V.Undef, ((V)("hg13")));
CL_350 = Arr(((V)("#00d8ff")), ((V)("#8a2cff")), ((V)("#ff1f9a")));
m_351 = 0.005;
s_352 = new JsStrBuf("<defs><linearGradient id=\"hgt\" x1=\"0\" y1=\"0\" x2=\"0.4\" y2=\"1\"><stop offset=\"0\" stop-color=\"#2a1470\"/><stop offset=\"1\" stop-color=\"#120838\"/></linearGradient><linearGradient id=\"hgs\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.16\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient></defs><rect width=\"80\" height=\"56\" fill=\"#0e0b1e\"/>");
seam_353 = new JsStrBuf("");
s_352.V(Invoke(Call(rep_25, V.Undef, ((V)(46D)), Fn((V _arrowThis369, int _argc362, V i_368, V _a365, V _a366, V _a367, V[] _rest363) => {
V p_370 = default;
p_370 = Call(px_30, V.Undef, Call(R_349, V.Undef), Call(R_349, V.Undef));
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_370, 0D))), "\" cy=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_370, 1D))), "\" r=\"", ToStr(Call(f1_23, V.Undef, ((V)((0.18 + (ToNum(Call(R_349, V.Undef)) * 0.22)))))), "\" fill=\"", (NumTruthy((ToNum(i_368) % 3D)) ? "#fff4dc" : "#cfe6ff"), "\" opacity=\"0.4\">", ToStr(Call(an_20, V.Undef, ((V)("opacity")), ((V)("0.15;0.95;0.15")), Call(n4_24, V.Undef, ((V)((1.8 + (ToNum(Call(R_349, V.Undef)) * 2.6))))), Call(n4_24, V.Undef, ((V)(((-ToNum(Call(R_349, V.Undef))) * 3D)))))), "</circle>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
{
double v_371 = 0;
v_371 = 0D;
while (true) {
if (!((v_371 < NV_347))) break;
{
double u_373 = 0;
u_373 = 0D;
while (true) {
if (!((u_373 < NU_346))) break;
double u0_375 = 0;
double u1_376 = 0;
V v0_377 = default;
double v1_378 = 0;
V q_379 = default;
double d_380 = 0;
u0_375 = ((u_373 / NU_346) + m_351);
u1_376 = (((u_373 + 1D) / NU_346) - m_351);
v0_377 = Add(GetIdx(V_348, v_371), ((V)((m_351 * 1.4))));
v1_378 = (ToNum(GetIdx(V_348, (v_371 + 1D))) - (m_351 * 1.4));
q_379 = Call(quad_34, V.Undef, ((V)(u0_375)), v0_377, ((V)(u1_376)), ((V)(v1_378)));
d_380 = (Hypot((u_373 - 5.5), ((v_371 - 3D) * 1.6)) * 0.45);
s_352.S(string.Concat("<path d=\"", ToStr(q_379), "\" fill=\"url(#hgt)\"/><path d=\"", ToStr(q_379), "\" fill=\"", ToStr(GetIdx(CL_350, ((u_373 + v_371) % 3D))), "\" opacity=\"0.55\"><animate attributeName=\"opacity\" values=\"0.55;1;0.75;0.55\" keyTimes=\"0;0.1;0.4;1\" dur=\"2.4s\" begin=\"", ToStr(Call(n4_24, V.Undef, ((V)(((d_380 * 0.22) - 2.4))))), "s\" repeatCount=\"indefinite\"/></path>")).S(string.Concat("<path d=\"", ToStr(Call(lineUV_35, V.Undef, Arr(Arr(((V)(u0_375)), ((V)(v1_378))), Arr(((V)(u0_375)), v0_377), Arr(((V)(u1_376)), v0_377)))), "\" stroke=\"#b49cff\" stroke-opacity=\"0.75\" stroke-width=\"0.22\" fill=\"none\"/>"));
u_373++;
}
}
v_371++;
}
}
{
double u_381 = 0;
u_381 = 1D;
while (true) {
if (!((u_381 < NU_346))) break;
seam_353.V(Call(lineUV_35, V.Undef, Arr(Arr(((V)((u_381 / NU_346))), ((V)(0D))), Arr(((V)((u_381 / NU_346))), ((V)(1D))))));
u_381++;
}
}
{
double v_383 = 0;
v_383 = 1D;
while (true) {
if (!((v_383 < NV_347))) break;
seam_353.V(Call(lineUV_35, V.Undef, Arr(Arr(((V)(0D)), GetIdx(V_348, v_383)), Arr(((V)(1D)), GetIdx(V_348, v_383)))));
v_383++;
}
}
s_352.S(string.Concat("<path d=\"", seam_353.Str, "\" stroke=\"#6a3cff\" stroke-width=\"0.9\" fill=\"none\" opacity=\"0.5\" filter=\"url(#fb1)\">", ToStr(Call(an_20, V.Undef, ((V)("opacity")), ((V)("0.3;0.8;0.3")), ((V)(1.2)))), "</path><path d=\"", seam_353.Str, "\" stroke=\"#8f6bff\" stroke-opacity=\"0.9\" stroke-width=\"0.24\" fill=\"none\"/>"));
Invoke(Arr(), "forEach", Fn((V _arrowThis398, int _argc385, V _a387, V _a388, V _a389, V _a390, V[] _rest386) => {
V p_399 = default;
double RR_400 = 0;
V u_393 = default;
V v_395 = default;
V b_397 = default;
{ V _t391 = ListOf(_a387);
{ V _t392 = GetIdx(_t391, 0D);
u_393 = _t392; }
{ V _t394 = GetIdx(_t391, 1D);
v_395 = _t394; }
{ V _t396 = GetIdx(_t391, 2D);
b_397 = _t396; }
}
p_399 = Call(px_30, V.Undef, u_393, v_395);
RR_400 = (24D * ToNum(Call(wk_32, V.Undef, v_395)));
s_352.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_399, 0D))), "\" cy=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_399, 1D))), "\" rx=\"", ToStr(Call(f1_23, V.Undef, ((V)((4D * ToNum(Call(wk_32, V.Undef, v_395))))))), "\" ry=\"", ToStr(Call(f1_23, V.Undef, ((V)((2.2 * ToNum(Call(wk_32, V.Undef, v_395))))))), "\" fill=\"#8ff6ff\" opacity=\"0\" filter=\"url(#fb2)\"><animate attributeName=\"opacity\" values=\"0.7;0;0\" keyTimes=\"0;0.3;1\" dur=\"2.4s\" begin=\"", ToStr(Call(n4_24, V.Undef, ((V)((-ToNum(b_397)))))), "s\" repeatCount=\"indefinite\"/></ellipse>"));
s_352.V(Invoke(Call(rep_25, V.Undef, ((V)(3D)), Fn((V _arrowThis408, int _argc401, V k_407, V _a404, V _a405, V _a406, V[] _rest402) => {
V bg_409 = default;
bg_409 = Call(n4_24, V.Undef, ((V)(((-ToNum(b_397)) - (ToNum(k_407) * 0.8)))));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_399, 0D))), "\" cy=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_399, 1D))), "\" rx=\"0.5\" ry=\"0.3\" fill=\"none\" stroke=\"#8ff6ff\" stroke-width=\"0.7\" opacity=\"0\"><animate attributeName=\"rx\" values=\"0.5;", ToStr(Call(f1_23, V.Undef, ((V)(RR_400)))), "\" dur=\"2.4s\" begin=\"", ToStr(bg_409), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"ry\" values=\"0.3;", ToStr(Call(f1_23, V.Undef, ((V)((RR_400 * 0.55))))), "\" dur=\"2.4s\" begin=\"", ToStr(bg_409), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.9;0\" dur=\"2.4s\" begin=\"", ToStr(bg_409), "s\" repeatCount=\"indefinite\"/></ellipse>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
return default;
}, 1, "", true));
s_352.S(string.Concat("<path d=\"M-30 0H-12L-22 56H-40Z\" fill=\"url(#hgs)\">", ToStr(Call(at_21, V.Undef, ((V)("translate")), ((V)("0 0;0 0;130 0")), ((V)(6D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.4;1\"")))), "</path>"));
return Call(FL_38, V.Undef, ((V)(s_352.Str)), ((V)(1D)));
return default;
}, 0, "fGlass", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((((RD_8 is var _t410 && !Truthy(_t410) ? _t410 : Get(RD_8, "PLUS12")) is var _t411 && !Truthy(_t411) ? _t411 : Get(RD_8, "H12")) is var _t412 && !Truthy(_t412) ? _t412 : Get(RD_8, "H11")) is var _t413 && !Truthy(_t413) ? _t413 : Get(RD_8, "H10")) is var _t414 && !Truthy(_t414) ? _t414 : X_9) is var _t415 && !Truthy(_t415) ? _t415 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_416.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS13"))) {
return default;
}
K_10 = Get(X_9, "K");
shade_11 = Get(K_10, "shade");
N_12 = Get(RD_8, "N");
PI_13 = System.Math.PI;
H_14 = Get(RD_8, "H10");
{ V _t417 = H_14;
if (_t417.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t417));
{ V _t418 = Get(_t417, "cam");
cam_15 = _t418; }
{ V _t419 = Get(_t417, "FR");
FR_16 = _t419; }
{ V _t420 = Get(_t417, "vis");
vis_17 = _t420; }
{ V _t421 = Get(_t417, "lit");
lit_18 = _t421; }
{ V _t422 = Get(_t417, "rng");
rng_19 = _t422; }
{ V _t423 = Get(_t417, "an");
an_20 = _t423; }
{ V _t424 = Get(_t417, "at");
at_21 = _t424; }
{ V _t425 = Get(_t417, "SPL");
SPL_22 = _t425; }
{ V _t426 = Get(_t417, "f1");
f1_23 = _t426; }
{ V _t427 = Get(_t417, "n4");
n4_24 = _t427; }
{ V _t428 = Get(_t417, "rep");
rep_25 = _t428; }
{ V _t429 = Get(_t417, "pth");
pth_26 = _t429; }
{ V _t430 = Get(_t417, "FONT");
FONT_27 = _t430; } }
TR_28 = ((V)("M14 0H66L80 56H0Z"));
ginv_29 = Fn((V _arrowThis438, int _argc431, V v_437, V _a434, V _a435, V _a436, V[] _rest432) => {
return ((V)((((-0.7) + System.Math.Sqrt((0.49 + (1.2 * Max(0D, ToNum(v_437)))))) / 0.6)));
}, 1, "", true);
px_30 = Fn((V _arrowThis447, int _argc439, V u_445, V v_446, V _a443, V _a444, V[] _rest440) => {
return (Truthy(Get(RD_8, "_FLAT")) ? Arr(((V)((80D * ToNum(u_445)))), ((V)((56D * ToNum(Call(ginv_29, V.Undef, v_446)))))) : Arr(((V)(((14D - (14D * ToNum(v_446))) + ((52D + (28D * ToNum(v_446))) * ToNum(u_445))))), ((V)((56D * ToNum(v_446))))));
}, 2, "", true);
PP_31 = Fn((V _arrowThis456, int _argc448, V u_454, V v_455, V _a452, V _a453, V[] _rest449) => {
V p_457 = default;
p_457 = Call(px_30, V.Undef, u_454, v_455);
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(p_457, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(p_457, 1D))).End()));
return default;
}, 2, "", true);
wk_32 = Fn((V _arrowThis465, int _argc458, V v_464, V _a461, V _a462, V _a463, V[] _rest459) => {
return ((V)(((52D + (28D * ToNum(v_464))) / 80D)));
}, 1, "", true);
gv_33 = Fn((V _arrowThis473, int _argc466, V t_472, V _a469, V _a470, V _a471, V[] _rest467) => {
return ((V)((ToNum(t_472) * (0.7 + (0.3 * ToNum(t_472))))));
}, 1, "", true);
quad_34 = Fn((V _arrowThis484, int _argc474, V u0_480, V v0_481, V u1_482, V v1_483, V[] _rest475) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(PP_31, V.Undef, u0_480, v0_481)).S("L").V(Call(PP_31, V.Undef, u1_482, v0_481)).S("L").V(Call(PP_31, V.Undef, u1_482, v1_483)).S("L").V(Call(PP_31, V.Undef, u0_480, v1_483)).S("Z").End()));
}, 4, "", true);
lineUV_35 = Fn((V _arrowThis492, int _argc485, V pts_491, V _a488, V _a489, V _a490, V[] _rest486) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_491, "map", Fn((V _arrowThis504, int _argc493, V _a495, V _a496, V _a497, V _a498, V[] _rest494) => {
V u_501 = default;
V v_503 = default;
{ V _t499 = ListOf(_a495);
{ V _t500 = GetIdx(_t499, 0D);
u_501 = _t500; }
{ V _t502 = GetIdx(_t499, 1D);
v_503 = _t502; }
}
return Call(PP_31, V.Undef, u_501, v_503);
}, 1, "", true)), "join", ((V)("L")))).End()));
}, 1, "", true);
crv_36 = Fn((V _arrowThis512, int _argc505, V pts_511, V _a508, V _a509, V _a510, V[] _rest506) => {
V P_513 = default;
JsStrBuf d_514 = null;
V l_515 = default;
P_513 = Invoke(pts_511, "map", Fn((V _arrowThis527, int _argc516, V _a518, V _a519, V _a520, V _a521, V[] _rest517) => {
V u_524 = default;
V v_526 = default;
{ V _t522 = ListOf(_a518);
{ V _t523 = GetIdx(_t522, 0D);
u_524 = _t523; }
{ V _t525 = GetIdx(_t522, 1D);
v_526 = _t525; }
}
return Call(px_30, V.Undef, u_524, v_526);
}, 1, "", true));
d_514 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(f1_23, V.Undef, GetIdx(GetIdx(P_513, 0D), 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(GetIdx(P_513, 0D), 1D))).End());
{
double i_528 = 0;
i_528 = 1D;
while (true) {
if (!((i_528 < (ToNum(Get(P_513, "length")) - 1D)))) break;
d_514.S("Q").V(Call(f1_23, V.Undef, GetIdx(GetIdx(P_513, i_528), 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(GetIdx(P_513, i_528), 1D))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(Add(GetIdx(GetIdx(P_513, i_528), 0D), GetIdx(GetIdx(P_513, (i_528 + 1D)), 0D))) / 2D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(Add(GetIdx(GetIdx(P_513, i_528), 1D), GetIdx(GetIdx(P_513, (i_528 + 1D)), 1D))) / 2D)))));
i_528++;
}
}
l_515 = GetIdx(P_513, (ToNum(Get(P_513, "length")) - 1D));
return ((V)(JsStrBuf.Begin().S(d_514.Str).S("L").V(Call(f1_23, V.Undef, GetIdx(l_515, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(l_515, 1D))).End()));
return default;
}, 1, "", true);
FDEF_37 = ((V)(JsStrBuf.Begin().S("<filter id=\"fb3\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"2.4\"/></filter><filter id=\"fb2\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"1.2\"/></filter><filter id=\"fb1\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"0.6\"/></filter>").S("<clipPath id=\"ftc\"><path d=\"").V(TR_28).S("\"/></clipPath>").S("<linearGradient id=\"fsh\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"0.32\"/><stop offset=\"0.12\" stop-color=\"#000000\" stop-opacity=\"0.06\"/><stop offset=\"0.55\" stop-color=\"#ffffff\" stop-opacity=\"0.05\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.14\"/></linearGradient>").S("<radialGradient id=\"fpl\" cx=\"50%\" cy=\"60%\" r=\"55%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.12\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"fsd\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"0.2\"/><stop offset=\"0.16\" stop-color=\"#000000\" stop-opacity=\"0\"/><stop offset=\"0.84\" stop-color=\"#000000\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.2\"/></linearGradient>").End()));
FL_38 = Fn((V _arrowThis538, int _argc530, V body_536, V dk_537, V _a534, V _a535, V[] _rest531) => {
return ((V)((Truthy(Get(RD_8, "_FLAT")) ? JsStrBuf.Begin().S("<defs>").V(FDEF_37).S("</defs>").V(body_536).End() : JsStrBuf.Begin().S("<defs>").V(FDEF_37).S("</defs><g clip-path=\"url(#ftc)\">").V(body_536).S(string.Concat("<path d=\"", ToStr(TR_28), "\" fill=\"url(#fsh)\"/><path d=\"", ToStr(TR_28), "\" fill=\"url(#fpl)\" opacity=\"", NumStr((Truthy(dk_537) ? 0.4 : 1D)), "\"/><path d=\"", ToStr(TR_28), "\" fill=\"url(#fsd)\"/></g>")).End())));
}, 2, "", true);
fblot_39 = Fn((V _arrowThis550, int _argc539, V seed_545, V n_546, V cols_547, V op_548, V[] _rest540) => {
V R_551 = default;
JsStrBuf o_552 = null;
V sz_549 = default;
sz_549 = (_argc539 > 4 ? _rest540[0] : V.Undef);
R_551 = Call(rng_19, V.Undef, seed_545);
o_552 = new JsStrBuf("<g filter=\"url(#fb3)\">");
Call(rep_25, V.Undef, n_546, Fn((V _arrowThis560, int _argc553, V i_559, V _a556, V _a557, V _a558, V[] _rest554) => {
double u_561 = 0;
V v_562 = default;
V p_563 = default;
double rx_564 = 0;
u_561 = ((ToNum(Call(R_551, V.Undef)) * 1.1) - 0.05);
v_562 = Call(R_551, V.Undef);
p_563 = Call(px_30, V.Undef, ((V)(u_561)), v_562);
rx_564 = ((ToNum((sz_549 is var _t565 && Truthy(_t565) ? _t565 : ((V)(7D)))) * (0.6 + (ToNum(Call(R_551, V.Undef)) * 0.8))) * ToNum(Call(wk_32, V.Undef, v_562)));
o_552.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_563, 0D))), "\" cy=\"", ToStr(Call(f1_23, V.Undef, GetIdx(p_563, 1D))), "\" rx=\"", ToStr(Call(f1_23, V.Undef, ((V)(rx_564)))), "\" ry=\"", ToStr(Call(f1_23, V.Undef, ((V)((rx_564 * (0.45 + (0.2 * ToNum(v_562)))))))), "\" fill=\"", ToStr(GetIdx(cols_547, (ToNum(i_559) % ToNum(Get(cols_547, "length"))))), "\" opacity=\"", ToStr(op_548), "\"/>"));
return default;
}, 1, "", true));
return ((V)(string.Concat(o_552.Str, "</g>")));
return default;
}, 5, "", true);
FLOOR13_45 = NewObj(5).Put("conc", fConc_40).Put("tile", fTile_41).Put("crim", fCrim_42).Put("teak", fTeak_43).Put("glass", fGlass_44).V;
draw12_46 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis574, int _argc566, V r_572, V o_573, V _a570, V _a571, V[] _rest567) => {
V res_575 = default;
res_575 = Call(draw12_46, V.Undef, r_572, o_573);
if (Truthy(((!(Truthy(res_575)) ? V.True : V.False) is var _t576 && Truthy(_t576) ? _t576 : Get(res_575, "_p13")))) {
return res_575;
}
try {
V f_577 = default;
f_577 = (Get(r_572, "f13") is var _t578 && !Truthy(_t578) ? _t578 : GetK(FLOOR13_45, Get(r_572, "f13")));
if (Truthy((f_577 is var _t579 && !Truthy(_t579) ? _t579 : Get(res_575, "surf")))) {
Set(res_575, "_p13", ((V)(1D)));
Set(res_575, "vb", ((V)("0 0 80 56")));
Set(res_575, "svg", Invoke(RD_8, "svgDoc", ((V)("0 0 80 56")), Arr(), Call(f_577, V.Undef)));
Set(res_575, "src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Get(res_575, "svg"))).End())));
}
} catch (System.Exception _ex580) {
V e_581 = default;
e_581 = Caught(_ex580);
Invoke(G("console"), "warn", ((V)("reno plus13")), Get(r_572, "id"), e_581);
}
return res_575;
return default;
}, 2, "", true));
DEF13_47 = ((V)("<filter id=\"r13b\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"1.6\"/></filter><filter id=\"r13s\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"0.5\"/></filter>"));
ellP_48 = Fn((V _arrowThis591, int _argc582, V a_588, V b_589, V n_590, V _a587, V[] _rest583) => {
return Call(rep_25, V.Undef, n_590, Fn((V _arrowThis599, int _argc592, V i_598, V _a595, V _a596, V _a597, V[] _rest593) => {
double t_600 = 0;
t_600 = (((ToNum(i_598) / ToNum(n_590)) * 2D) * PI_13);
return Arr(((V)((ToNum(a_588) * FdLibm.Cos(t_600)))), ((V)((ToNum(b_589) * FdLibm.Sin(t_600)))));
return default;
}, 1, "", true));
}, 3, "", true);
rrP_49 = Fn((V _arrowThis610, int _argc601, V w_607, V d_608, V r_609, V _a606, V[] _rest602) => {
V o_611 = default;
o_611 = Arr();
Invoke(Arr(Arr(((V)(((ToNum(w_607) / 2D) - ToNum(r_609)))), ((V)(((ToNum(d_608) / 2D) - ToNum(r_609)))), ((V)(0D))), Arr(Add(((V)(((-ToNum(w_607)) / 2D))), r_609), ((V)(((ToNum(d_608) / 2D) - ToNum(r_609)))), ((V)((PI_13 / 2D)))), Arr(Add(((V)(((-ToNum(w_607)) / 2D))), r_609), Add(((V)(((-ToNum(d_608)) / 2D))), r_609), ((V)(PI_13))), Arr(((V)(((ToNum(w_607) / 2D) - ToNum(r_609)))), Add(((V)(((-ToNum(d_608)) / 2D))), r_609), ((V)((1.5 * PI_13))))), "forEach", Fn((V _arrowThis625, int _argc612, V _a614, V _a615, V _a616, V _a617, V[] _rest613) => {
V cx_620 = default;
V cz_622 = default;
V a0_624 = default;
{ V _t618 = ListOf(_a614);
{ V _t619 = GetIdx(_t618, 0D);
cx_620 = _t619; }
{ V _t621 = GetIdx(_t618, 1D);
cz_622 = _t621; }
{ V _t623 = GetIdx(_t618, 2D);
a0_624 = _t623; }
}
{
double k_626 = 0;
k_626 = 0D;
while (true) {
if (!((k_626 <= 6D))) break;
V a_628 = default;
a_628 = Add(a0_624, ((V)((((k_626 / 6D) * PI_13) / 2D))));
Invoke(o_611, "push", Arr(Add(cx_620, ((V)((ToNum(r_609) * FdLibm.Cos(ToNum(a_628)))))), Add(cz_622, ((V)((ToNum(r_609) * FdLibm.Sin(ToNum(a_628))))))));
k_626++;
}
}
return default;
}, 1, "", true));
return o_611;
return default;
}, 3, "", true);
dP_50 = Fn((V _arrowThis636, int _argc629, V P_635, V _a632, V _a633, V _a634, V[] _rest630) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(P_635, "map", Fn((V _arrowThis644, int _argc637, V q_643, V _a640, V _a641, V _a642, V[] _rest638) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(q_643, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_643, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
slab_51 = Fn((V _arrowThis655, int _argc645, V C_651, V P_652, V t_653, V side_654, V[] _rest646) => {
V cx_656 = default;
V cz_657 = default;
JsStrBuf s_658 = null;
cx_656 = ((V)(0D));
cz_657 = ((V)(0D));
Invoke(P_652, "forEach", Fn((V _arrowThis666, int _argc659, V q_665, V _a662, V _a663, V _a664, V[] _rest660) => {
cx_656 = Add(cx_656, GetIdx(q_665, 0D));
cz_657 = Add(cz_657, GetIdx(q_665, 1D));
return default;
}, 1, "", true));
cx_656 = ((V)((ToNum(cx_656) / ToNum(Get(P_652, "length")))));
cz_657 = ((V)((ToNum(cz_657) / ToNum(Get(P_652, "length")))));
s_658 = new JsStrBuf(string.Concat("<g transform=\"", ToStr(Call(FR_16, V.Undef, C_651, Arr(((V)(0D)), ((V)(0.03)), ((V)(0D))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><path d=\"", ToStr(Call(dP_50, V.Undef, Invoke(P_652, "map", Fn((V _arrowThis674, int _argc667, V q_673, V _a670, V _a671, V _a672, V[] _rest668) => {
return Arr(((V)(((ToNum(GetIdx(q_673, 0D)) * 1.02) + 2D))), ((V)(((ToNum(GetIdx(q_673, 1D)) * 1.02) + 3D))));
}, 1, "", true)))), "\" fill=\"#000000\" opacity=\"0.3\" filter=\"url(#r13b)\"/></g>"));
Invoke(P_652, "forEach", Fn((V _arrowThis683, int _argc675, V a_681, V i_682, V _a679, V _a680, V[] _rest676) => {
V b_684 = default;
double dx_685 = 0;
double dz_686 = 0;
V L_687 = default;
V n_688 = default;
V Q_689 = default;
V c_690 = default;
b_684 = GetIdx(P_652, (ToNum(Add(i_682, ((V)(1D)))) % ToNum(Get(P_652, "length"))));
dx_685 = (ToNum(GetIdx(b_684, 0D)) - ToNum(GetIdx(a_681, 0D)));
dz_686 = (ToNum(GetIdx(b_684, 1D)) - ToNum(GetIdx(a_681, 1D)));
L_687 = (((V)(Hypot(dx_685, dz_686))) is var _t691 && Truthy(_t691) ? _t691 : ((V)(1D)));
n_688 = Arr(((V)((dz_686 / ToNum(L_687)))), ((V)(0D)), ((V)(((-dx_685) / ToNum(L_687)))));
if ((((ToNum(GetIdx(n_688, 0D)) * ((ToNum(Add(GetIdx(a_681, 0D), GetIdx(b_684, 0D))) / 2D) - ToNum(cx_656))) + (ToNum(GetIdx(n_688, 2D)) * ((ToNum(Add(GetIdx(a_681, 1D), GetIdx(b_684, 1D))) / 2D) - ToNum(cz_657)))) < 0D)) {
n_688 = Arr(((V)((-ToNum(GetIdx(n_688, 0D))))), ((V)(0D)), ((V)((-ToNum(GetIdx(n_688, 2D))))));
}
Q_689 = Invoke(Arr(Arr(GetIdx(a_681, 0D), ((V)(0D)), GetIdx(a_681, 1D)), Arr(GetIdx(b_684, 0D), ((V)(0D)), GetIdx(b_684, 1D)), Arr(GetIdx(b_684, 0D), t_653, GetIdx(b_684, 1D)), Arr(GetIdx(a_681, 0D), t_653, GetIdx(a_681, 1D))), "map", Get(C_651, "P"));
if (!(Truthy(Call(vis_17, V.Undef, C_651, n_688)))) {
return default;
}
c_690 = Call(shade_11, V.Undef, side_654, Call(lit_18, V.Undef, C_651, n_688));
s_658.S(string.Concat("<path d=\"", ToStr(Call(pth_26, V.Undef, Q_689)), "\" fill=\"", ToStr(c_690), "\" stroke=\"", ToStr(c_690), "\" stroke-width=\"0.3\"/>"));
return default;
}, 2, "", true));
return ((V)(s_658.Str));
return default;
}, 4, "", true);
top_52 = Fn((V _arrowThis701, int _argc692, V C_698, V t_699, V svg_700, V _a697, V[] _rest693) => {
return ((V)(string.Concat("<g transform=\"", ToStr(Call(FR_16, V.Undef, C_698, Arr(((V)(0D)), t_699, ((V)(0D))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\">", ToStr(svg_700), "</g>")));
}, 3, "", true);
face_53 = Fn((V _arrowThis712, int _argc702, V id_708, V P_709, V art_710, V rim_711, V[] _rest703) => {
return ((V)(string.Concat(string.Concat("<defs><clipPath id=\"", ToStr(id_708), "c\"><path d=\"", ToStr(Call(dP_50, V.Undef, P_709)), "\"/></clipPath><linearGradient id=\"", ToStr(id_708), "l\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.16\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.16\"/></linearGradient></defs>"), string.Concat("<g clip-path=\"url(#", ToStr(id_708), "c)\">", ToStr(art_710), "<path d=\"", ToStr(Call(dP_50, V.Undef, P_709)), "\" fill=\"url(#", ToStr(id_708), "l)\"/><path d=\"", ToStr(Call(dP_50, V.Undef, P_709)), "\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"", ToStr((rim_711.IsNullish ? ((V)(0.28)) : rim_711)), "\" stroke-width=\"5\" filter=\"url(#r13b)\"/></g>"))));
}, 4, "", true);
RUG_54 = Fn((V _arrowThis722, int _argc713, V w_719, V d_720, V o_721, V _a718, V[] _rest714) => {
return Object_assign(NewObj(5).Put("w", w_719).Put("d", d_720).Put("flat", ((V)(1D))).Put("noBlock", ((V)(1D))).Put("build", Fn((V _arrowThis729, int _argc723, V _a725, V _a726, V _a727, V _a728, V[] _rest724) => {
return Arr();
}, 0, "build", true)).V, (o_721 is var _t730 && Truthy(_t730) ? _t730 : NewObj(0).V));
}, 3, "", true);
Set(N_12, "rag13", Fn((V _arrowThis738, int _argc731, V S_737, V _a734, V _a735, V _a736, V[] _rest732) => {
double A_739 = 0;
double B_740 = 0;
double T_741 = 0;
V P_742 = default;
V COLS_743 = default;
V D_744 = default;
A_739 = 84D;
B_740 = 56D;
T_741 = 2.2;
P_742 = Call(ellP_48, V.Undef, ((V)(A_739)), ((V)(B_740)), ((V)(60D)));
COLS_743 = Arr(((V)("#c8553d")), ((V)("#e8b04a")), ((V)("#4f7cac")), ((V)("#7fa65a")), ((V)("#e9dcc4")), ((V)("#9a5a8a")), ((V)("#d97a4a")));
D_744 = Call(RUG_54, V.Undef, ((V)(180D)), ((V)(124D)), NewObj(1).Put("round", ((V)(1D))).V);
Set(D_744, "fx", Fn((V _arrowThis752, int _argc745, V ctx_751, V _a748, V _a749, V _a750, V[] _rest746) => {
V C_753 = default;
V R_754 = default;
JsStrBuf art_755 = null;
double k_756 = 0;
JsStrBuf fr_757 = null;
double t0_758 = 0;
double rx0_759 = 0;
double rz0_760 = 0;
double ang_761 = 0;
V strand_762 = default;
V s_763 = default;
C_753 = Call(cam_15, V.Undef, ctx_751);
R_754 = Call(rng_19, V.Undef, ((V)("rag13")));
art_755 = new JsStrBuf(string.Concat("<ellipse rx=\"", NumStr(A_739), "\" ry=\"", NumStr(B_740), "\" fill=\"#6a4a3a\"/>"));
k_756 = 0D;
{
while (true) {
double rx_765 = 0;
double ry_766 = 0;
V c_767 = default;
rx_765 = ((A_739 - 2.6) - (5D * k_756));
ry_766 = ((B_740 - 2.6) - (5D * k_756));
if ((ry_766 < 3D)) {
break;
}
c_767 = GetIdx(COLS_743, (k_756 % 7D));
art_755.S(string.Concat("<ellipse rx=\"", ToStr(Call(f1_23, V.Undef, ((V)(rx_765)))), "\" ry=\"", ToStr(Call(f1_23, V.Undef, ((V)(ry_766)))), "\" fill=\"none\" stroke=\"", ToStr(c_767), "\" stroke-width=\"4.9\"/><ellipse rx=\"", ToStr(Call(f1_23, V.Undef, ((V)(rx_765)))), "\" ry=\"", ToStr(Call(f1_23, V.Undef, ((V)(ry_766)))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_11, V.Undef, c_767, ((V)(0.66)))), "\" stroke-width=\"4.9\" stroke-dasharray=\"1.1 2.3\" opacity=\"0.6\"/>")).S(string.Concat("<ellipse rx=\"", ToStr(Call(f1_23, V.Undef, ((V)((rx_765 - 1D))))), "\" ry=\"", ToStr(Call(f1_23, V.Undef, ((V)((ry_766 - 1D))))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_11, V.Undef, c_767, ((V)(1.25)))), "\" stroke-width=\"0.6\" stroke-dasharray=\"1.6 1.8\" opacity=\"0.7\"/><ellipse rx=\"", ToStr(Call(f1_23, V.Undef, ((V)((rx_765 + 2.45))))), "\" ry=\"", ToStr(Call(f1_23, V.Undef, ((V)((ry_766 + 2.45))))), "\" fill=\"none\" stroke=\"#3a2418\" stroke-width=\"0.4\" opacity=\"0.45\"/>"));
k_756++;
}
}
{
double rx_768 = 0;
double ry_769 = 0;
rx_768 = (((A_739 - 2.6) - (5D * k_756)) + 2.4);
ry_769 = (((B_740 - 2.6) - (5D * k_756)) + 2.4);
if ((ry_769 > 0.5)) {
art_755.S(string.Concat("<ellipse rx=\"", ToStr(Call(f1_23, V.Undef, ((V)(rx_768)))), "\" ry=\"", ToStr(Call(f1_23, V.Undef, ((V)(ry_769)))), "\" fill=\"", ToStr(GetIdx(COLS_743, (k_756 % 7D))), "\"/><path d=\"M", ToStr(Call(f1_23, V.Undef, ((V)(((-rx_768) * 0.8))))), " 0H", ToStr(Call(f1_23, V.Undef, ((V)((rx_768 * 0.8))))), "\" stroke=\"", ToStr(Call(shade_11, V.Undef, GetIdx(COLS_743, (k_756 % 7D)), ((V)(0.66)))), "\" stroke-width=\"", ToStr(Call(f1_23, V.Undef, ((V)((ry_769 * 1.2))))), "\" stroke-dasharray=\"1.1 2.3\" opacity=\"0.5\"/>"));
}
}
fr_757 = new JsStrBuf("");
Call(rep_25, V.Undef, ((V)(54D)), Fn((V _arrowThis776, int _argc770, V _a772, V _a773, V _a774, V _a775, V[] _rest771) => {
double t_777 = 0;
double x_778 = 0;
double z_779 = 0;
double nx_780 = 0;
double nz_781 = 0;
double nl_782 = 0;
double a_783 = 0;
double L_784 = 0;
t_777 = ((ToNum(Call(R_754, V.Undef)) * 2D) * PI_13);
x_778 = (A_739 * FdLibm.Cos(t_777));
z_779 = (B_740 * FdLibm.Sin(t_777));
nx_780 = (FdLibm.Cos(t_777) / A_739);
nz_781 = (FdLibm.Sin(t_777) / B_740);
nl_782 = Hypot(nx_780, nz_781);
a_783 = (FdLibm.Atan2((nz_781 / nl_782), (nx_780 / nl_782)) + ((ToNum(Call(R_754, V.Undef)) - 0.5) * 0.9));
L_784 = (1.4 + (ToNum(Call(R_754, V.Undef)) * 2D));
fr_757.S(string.Concat("<path d=\"M", ToStr(Call(f1_23, V.Undef, ((V)(x_778)))), " ", ToStr(Call(f1_23, V.Undef, ((V)(z_779)))), "l", ToStr(Call(f1_23, V.Undef, ((V)((L_784 * FdLibm.Cos(a_783)))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((L_784 * FdLibm.Sin(a_783)))))), "\" stroke=\"", ToStr((LtN(Call(R_754, V.Undef), 0.75) ? GetIdx(COLS_743, 0D) : ((V)("#e9dcc4")))), "\" stroke-width=\"0.5\" stroke-linecap=\"round\"/>"));
return default;
}, 0, "", true));
t0_758 = 0.55;
rx0_759 = (A_739 * FdLibm.Cos(t0_758));
rz0_760 = (B_740 * FdLibm.Sin(t0_758));
ang_761 = ((FdLibm.Atan2((FdLibm.Sin(t0_758) / B_740), (FdLibm.Cos(t0_758) / A_739)) * 180D) / PI_13);
strand_762 = ((V)(string.Concat("<g><animateTransform attributeName=\"transform\" type=\"rotate\" values=\"-12 ", ToStr(Call(f1_23, V.Undef, ((V)(rx0_759)))), " ", ToStr(Call(f1_23, V.Undef, ((V)(rz0_760)))), ";14 ", ToStr(Call(f1_23, V.Undef, ((V)(rx0_759)))), " ", ToStr(Call(f1_23, V.Undef, ((V)(rz0_760)))), ";-12 ", ToStr(Call(f1_23, V.Undef, ((V)(rx0_759)))), " ", ToStr(Call(f1_23, V.Undef, ((V)(rz0_760)))), "\" dur=\"3.6s\" repeatCount=\"indefinite\"", ToStr(Call(SPL_22, V.Undef, ((V)(2D)))), "/><g transform=\"translate(", ToStr(Call(f1_23, V.Undef, ((V)(rx0_759)))), " ", ToStr(Call(f1_23, V.Undef, ((V)(rz0_760)))), ") rotate(", ToStr(Call(f1_23, V.Undef, ((V)(ang_761)))), ")\"><path d=\"M-1 0q4 2.6 7.5 0.6q3.4 -2 6.5 1.2q1.6 1.6 3 1\" stroke=\"", ToStr(Call(shade_11, V.Undef, GetIdx(COLS_743, 0D), ((V)(0.7)))), "\" stroke-width=\"1.5\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M-1 0q4 2.6 7.5 0.6q3.4 -2 6.5 1.2q1.6 1.6 3 1\" stroke=\"", ToStr(GetIdx(COLS_743, 0D)), "\" stroke-width=\"1\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M15.8 2.6l1.6 0.2M15.6 2.9l1.2 1\" stroke=\"", ToStr(GetIdx(COLS_743, 0D)), "\" stroke-width=\"0.4\" stroke-linecap=\"round\"/></g></g>")));
s_763 = Add(Call(slab_51, V.Undef, C_753, P_742, ((V)(T_741)), ((V)("#8a3a2a"))), Call(top_52, V.Undef, C_753, ((V)(T_741)), ((V)(JsStrBuf.Begin().V(Call(face_53, V.Undef, ((V)("rg")), P_742, ((V)(art_755.Str)))).S(fr_757.Str).V(strand_762).End()))));
return NewObj(3).Put("defs", DEF13_47).Put("front", s_763).Put("bb", Invoke(C_753, "bb", ((V)(5D)))).V;
return default;
}, 1, "", true));
return D_744;
return default;
}, 1, "", true));
Set(N_12, "film13", Fn((V _arrowThis792, int _argc785, V S_791, V _a788, V _a789, V _a790, V[] _rest786) => {
double W_793 = 0;
double Dd_794 = 0;
double T_795 = 0;
V P_796 = default;
V D_797 = default;
V ico_798 = default;
W_793 = 240D;
Dd_794 = 64D;
T_795 = 1.4;
P_796 = Call(rrP_49, V.Undef, ((V)(W_793)), ((V)(Dd_794)), ((V)(3D)));
D_797 = Call(RUG_54, V.Undef, ((V)(250D)), ((V)(70D)));
ico_798 = Fn((V _arrowThis807, int _argc799, V i_805, V cx_806, V _a803, V _a804, V[] _rest800) => {
V B_808 = default;
V star_809 = default;
B_808 = Fn((V _arrowThis818, int _argc810, V y_816, V sq_817, V _a814, V _a815, V[] _rest811) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(cx_806), " ", ToStr(y_816), ") scale(", (Truthy(sq_817) ? "1.2 0.8" : "1 1"), ")\"><path d=\"M-7 4C-7.4 -3 -4 -7 0 -7C4 -7 7.4 -3 7 4Z\" fill=\"#a46bff\"/><ellipse cx=\"-2.6\" cy=\"-4.4\" rx=\"1.8\" ry=\"1\" fill=\"#ffffff\" opacity=\"0.45\"/><circle cx=\"-2.4\" cy=\"-1\" r=\"1.3\" fill=\"#ffffff\"/><circle cx=\"2.4\" cy=\"-1\" r=\"1.3\" fill=\"#ffffff\"/><circle cx=\"-2.2\" cy=\"-0.8\" r=\"0.7\" fill=\"#2a1450\"/><circle cx=\"2.6\" cy=\"-0.8\" r=\"0.7\" fill=\"#2a1450\"/><path d=\"M-1.4 1.6Q0 2.8 1.4 1.6\" stroke=\"#2a1450\" stroke-width=\"0.5\" fill=\"none\"/></g>")));
}, 2, "", true);
star_809 = Fn((V _arrowThis827, int _argc819, V r_825, V y_826, V _a823, V _a824, V[] _rest820) => {
JsStrBuf d_828 = null;
d_828 = new JsStrBuf("");
{
double k_829 = 0;
k_829 = 0D;
while (true) {
if (!((k_829 < 10D))) break;
double a_831 = 0;
V rr_832 = default;
a_831 = (((-PI_13) / 2D) + ((k_829 * PI_13) / 5D));
rr_832 = (NumTruthy((k_829 % 2D)) ? ((V)((ToNum(r_825) * 0.45))) : r_825);
d_828.S((NumTruthy(k_829) ? "L" : "M")).V(Call(f1_23, V.Undef, Add(cx_806, ((V)((ToNum(rr_832) * FdLibm.Cos(a_831))))))).S(" ").V(Call(f1_23, V.Undef, Add(y_826, ((V)((ToNum(rr_832) * FdLibm.Sin(a_831)))))));
k_829++;
}
}
return ((V)(string.Concat("<path d=\"", d_828.Str, "Z\" fill=\"#ffd34a\" stroke=\"#c98a1a\" stroke-width=\"0.4\"/>")));
return default;
}, 2, "", true);
if (SEqN(i_805, 0D)) {
return ((V)(JsStrBuf.Begin().V(Call(B_808, V.Undef, ((V)(4D)))).S(string.Concat("<ellipse cx=\"", ToStr(cx_806), "\" cy=\"9.5\" rx=\"7\" ry=\"1.2\" fill=\"#000000\" opacity=\"0.3\"/>")).End()));
}
if (SEqN(i_805, 1D)) {
return ((V)(JsStrBuf.Begin().V(Call(B_808, V.Undef, ((V)(5D)), ((V)(1D)))).S(string.Concat("<ellipse cx=\"", ToStr(cx_806), "\" cy=\"9.5\" rx=\"8\" ry=\"1.2\" fill=\"#000000\" opacity=\"0.35\"/>")).End()));
}
if (SEqN(i_805, 2D)) {
return ((V)(JsStrBuf.Begin().V(Call(B_808, V.Undef, ((V)((-5D))))).S(string.Concat("<ellipse cx=\"", ToStr(cx_806), "\" cy=\"9.5\" rx=\"4\" ry=\"0.8\" fill=\"#000000\" opacity=\"0.2\"/><path d=\"M", NumStr((ToNum(cx_806) - 8D)), " 6l2 1M", ToStr(Add(cx_806, ((V)(8D)))), " 6l-2 1\" stroke=\"#ffffff\" stroke-width=\"0.6\"/>")).End()));
}
if (SEqN(i_805, 3D)) {
return Add(Add(Call(star_809, V.Undef, ((V)(9D)), ((V)(0D))), Call(star_809, V.Undef, ((V)(2.6)), ((V)((-10D))))), Call(star_809, V.Undef, ((V)(2D)), ((V)(9D))));
}
if (SEqN(i_805, 4D)) {
return ((V)(JsStrBuf.Begin().S(string.Concat("<path d=\"M", NumStr((ToNum(cx_806) - 6D)), " -4L", NumStr((ToNum(cx_806) - 4D)), " 10H", ToStr(Add(cx_806, ((V)(4D)))), "L", ToStr(Add(cx_806, ((V)(6D)))), " -4Z\" fill=\"#f4efe6\"/><path d=\"M", NumStr((ToNum(cx_806) - 4.5)), " -4L", NumStr((ToNum(cx_806) - 3D)), " 10M", ToStr(cx_806), " -4V10M", ToStr(Add(cx_806, ((V)(4.5)))), " -4L", ToStr(Add(cx_806, ((V)(3D)))), " 10\" stroke=\"#e0383e\" stroke-width=\"1.4\"/>")).V(Invoke(Call(rep_25, V.Undef, ((V)(7D)), Fn((V _arrowThis840, int _argc833, V k_839, V _a836, V _a837, V _a838, V[] _rest834) => {
return ((V)(string.Concat("<circle cx=\"", NumStr(((ToNum(cx_806) - 5D) + (ToNum(k_839) * 1.7))), "\" cy=\"", NumStr(((-5D) - ((ToNum(k_839) % 2D) * 1.6))), "\" r=\"2\" fill=\"#fff6d8\" stroke=\"#e8c27a\" stroke-width=\"0.3\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
}
if (SEqN(i_805, 5D)) {
return ((V)(JsStrBuf.Begin().S(string.Concat("<circle cx=\"", ToStr(Add(cx_806, ((V)(2D)))), "\" cy=\"-2\" r=\"7\" fill=\"#fff1c8\"/><circle cx=\"", ToStr(Add(cx_806, ((V)(5D)))), "\" cy=\"-4\" r=\"6\" fill=\"#33467a\"/>")).V(Invoke(Call(star_809, V.Undef, ((V)(1.6)), ((V)(8D))), "replace", NewRegExp(RX0, "#ffd34a", ""), ((V)("#fff1c8")))).End()));
}
if (SEqN(i_805, 6D)) {
return ((V)(JsStrBuf.Begin().V(Call(B_808, V.Undef, ((V)(4D)))).S(string.Concat("<path d=\"M", ToStr(Add(cx_806, ((V)(6D)))), " -8c-1.6 -2.4 -4.6 -0.6 -2.8 1.4l2.8 2.8l2.8 -2.8c1.8 -2 -1.2 -3.8 -2.8 -1.4Z\" fill=\"#ff5f8a\"/>")).End()));
}
return ((V)(string.Concat("<text x=\"", ToStr(cx_806), "\" y=\"1.8\" text-anchor=\"middle\" ", ToStr(FONT_27), " font-size=\"5\" fill=\"#f1e4c4\" letter-spacing=\"0.4\">THE</text><text x=\"", ToStr(cx_806), "\" y=\"8\" text-anchor=\"middle\" ", ToStr(FONT_27), " font-size=\"5\" fill=\"#f1e4c4\" letter-spacing=\"0.4\">END</text>")));
return default;
}, 2, "", true);
Set(D_797, "fx", Fn((V _arrowThis848, int _argc841, V ctx_847, V _a844, V _a845, V _a846, V[] _rest842) => {
V C_849 = default;
V BG_850 = default;
JsStrBuf art_851 = null;
V s_852 = default;
C_849 = Call(cam_15, V.Undef, ctx_847);
BG_850 = Arr(((V)("#3b5a8a")), ((V)("#5a3b7a")), ((V)("#2f6f6a")), ((V)("#7a4a3a")), ((V)("#3b5a8a")), ((V)("#25305a")), ((V)("#5a3b7a")), ((V)("#2a2a30")));
art_851 = new JsStrBuf(string.Concat("<defs><linearGradient id=\"fms\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.14\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient></defs><rect x=\"", NumStr(((-W_793) / 2D)), "\" y=\"", NumStr(((-Dd_794) / 2D)), "\" width=\"", NumStr(W_793), "\" height=\"", NumStr(Dd_794), "\" fill=\"#1c1b21\"/>"));
{
V x_853 = default;
x_853 = ((V)((((-W_793) / 2D) + 4D)));
while (true) {
V x_853_it = x_853;
if (!(LeN(x_853_it, ((W_793 / 2D) - 4D)))) break;
Invoke(Arr(((V)((((-Dd_794) / 2D) + 4.6))), ((V)(((Dd_794 / 2D) - 7.4)))), "forEach", Fn((V _arrowThis862, int _argc855, V z_861, V _a858, V _a859, V _a860, V[] _rest856) => {
return ((V)(art_851.S(string.Concat("<rect x=\"", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(x_853_it) - 1.8))))), "\" y=\"", ToStr(Call(f1_23, V.Undef, z_861)), "\" width=\"3.6\" height=\"2.8\" rx=\"0.7\" fill=\"#e8e2d4\"/>")).Str));
}, 1, "", true));
x_853 = x_853_it;
x_853 = Add(x_853, ((V)(7.25)));
}
}
Call(rep_25, V.Undef, ((V)(8D)), Fn((V _arrowThis870, int _argc863, V i_869, V _a866, V _a867, V _a868, V[] _rest864) => {
double x0_871 = 0;
double cx_872 = 0;
x0_871 = ((-114.5) + (ToNum(i_869) * 29D));
cx_872 = (x0_871 + 13D);
art_851.S(string.Concat("<rect x=\"", ToStr(Call(f1_23, V.Undef, ((V)(x0_871)))), "\" y=\"-20\" width=\"26\" height=\"40\" rx=\"1.2\" fill=\"", ToStr(GetK(BG_850, i_869)), "\"/><clipPath id=\"fmc", ToStr(i_869), "\"><rect x=\"", ToStr(Call(f1_23, V.Undef, ((V)(x0_871)))), "\" y=\"-20\" width=\"26\" height=\"40\" rx=\"1.2\"/></clipPath><g clip-path=\"url(#fmc", ToStr(i_869), ")\"><rect x=\"", ToStr(Call(f1_23, V.Undef, ((V)(x0_871)))), "\" y=\"10\" width=\"26\" height=\"10\" fill=\"#000000\" opacity=\"0.18\"/>", ToStr(Call(ico_798, V.Undef, i_869, ((V)(cx_872)))), "</g><rect x=\"", ToStr(Call(f1_23, V.Undef, ((V)(x0_871)))), "\" y=\"-20\" width=\"26\" height=\"40\" rx=\"1.2\" fill=\"none\" stroke=\"#0e0d12\" stroke-width=\"0.6\"/><rect x=\"", ToStr(Call(f1_23, V.Undef, ((V)((x0_871 + 0.6))))), "\" y=\"-19.4\" width=\"24.8\" height=\"38.8\" rx=\"0.8\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.15\" stroke-width=\"0.4\"/>"));
return default;
}, 1, "", true));
art_851.S(string.Concat("<rect x=\"", ToStr(Call(f1_23, V.Undef, ((V)((((-W_793) / 2D) + 0.7))))), "\" y=\"", ToStr(Call(f1_23, V.Undef, ((V)((((-Dd_794) / 2D) + 0.7))))), "\" width=\"", NumStr((W_793 - 1.4)), "\" height=\"", NumStr((Dd_794 - 1.4)), "\" rx=\"2.4\" fill=\"none\" stroke=\"#4a4a52\" stroke-width=\"1.2\"/>"));
art_851.S(string.Concat("<rect x=\"-150\" y=\"-40\" width=\"44\" height=\"80\" fill=\"url(#fms)\" transform=\"skewX(-25)\">", ToStr(Call(at_21, V.Undef, ((V)("translate")), ((V)("0 0;0 0;330 0")), ((V)(8D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.45;1\" additive=\"sum\"")))), "</rect>"));
s_852 = Add(Call(slab_51, V.Undef, C_849, P_796, ((V)(T_795)), ((V)("#2a2a30"))), Call(top_52, V.Undef, C_849, ((V)(T_795)), Call(face_53, V.Undef, ((V)("fm")), P_796, ((V)(art_851.Str)), ((V)(0.22)))));
return NewObj(3).Put("defs", DEF13_47).Put("front", s_852).Put("bb", Invoke(C_849, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_797;
return default;
}, 1, "", true));
Set(N_12, "shag13", Fn((V _arrowThis880, int _argc873, V S_879, V _a876, V _a877, V _a878, V[] _rest874) => {
double W_881 = 0;
double Dd_882 = 0;
double RC_883 = 0;
double T_884 = 0;
V P_885 = default;
V PAL_886 = default;
V D_887 = default;
V inside_888 = default;
W_881 = 172D;
Dd_882 = 124D;
RC_883 = 20D;
T_884 = 4D;
P_885 = Call(rrP_49, V.Undef, ((V)(W_881)), ((V)(Dd_882)), ((V)(RC_883)));
PAL_886 = Arr(((V)("#3a3a42")), ((V)("#232328")), ((V)("#45454e")), ((V)("#1c1c20")), ((V)("#2e2e35")));
D_887 = Call(RUG_54, V.Undef, ((V)(180D)), ((V)(130D)));
inside_888 = Fn((V _arrowThis897, int _argc889, V x_895, V z_896, V _a893, V _a894, V[] _rest890) => {
double ax_898 = 0;
double az_899 = 0;
ax_898 = (System.Math.Abs(ToNum(x_895)) - ((W_881 / 2D) - RC_883));
az_899 = (System.Math.Abs(ToNum(z_896)) - ((Dd_882 / 2D) - RC_883));
return ((((System.Math.Abs(ToNum(x_895)) <= (W_881 / 2D)) && (System.Math.Abs(ToNum(z_896)) <= (Dd_882 / 2D))) && (((ax_898 <= 0D) || (az_899 <= 0D)) || (((ax_898 * ax_898) + (az_899 * az_899)) <= (RC_883 * RC_883)))) ? V.True : V.False);
return default;
}, 2, "", true);
Set(D_887, "fx", Fn((V _arrowThis907, int _argc900, V ctx_906, V _a903, V _a904, V _a905, V[] _rest901) => {
V C_908 = default;
V R_909 = default;
V tf_910 = default;
V tuft_911 = default;
V art_912 = default;
JsStrBuf fr_913 = null;
V per_914 = default;
V s_915 = default;
C_908 = Call(cam_15, V.Undef, ctx_906);
R_909 = Call(rng_19, V.Undef, ((V)("shag13")));
tf_910 = Arr();
{
double i_916 = 0;
i_916 = 0D;
while (true) {
if (!((i_916 < 640D))) break;
double x_918 = 0;
double z_919 = 0;
x_918 = ((ToNum(Call(R_909, V.Undef)) - 0.5) * W_881);
z_919 = ((ToNum(Call(R_909, V.Undef)) - 0.5) * Dd_882);
if (!(Truthy(Call(inside_888, V.Undef, ((V)(x_918)), ((V)(z_919)))))) {
goto _cont917;
}
Invoke(tf_910, "push", Arr(((V)(x_918)), ((V)(z_919)), ((V)((2.6 + (ToNum(Call(R_909, V.Undef)) * 2D)))), ((V)(((PI_13 / 2D) + ((ToNum(Call(R_909, V.Undef)) - 0.5) * 1.8)))), GetIdx(PAL_886, ((double)(ToInt32((ToNum(Call(R_909, V.Undef)) * 5D)) | ToInt32(0D)))), Call(R_909, V.Undef)));
_cont917: ;
i_916++;
}
}
Invoke(tf_910, "sort", Fn((V _arrowThis928, int _argc920, V a_926, V b_927, V _a924, V _a925, V[] _rest921) => {
return ((V)((ToNum(GetIdx(a_926, 1D)) - ToNum(GetIdx(b_927, 1D)))));
}, 2, "", true));
tuft_911 = Fn((V _arrowThis949, int _argc929, V _a931, V w_935, V _a933, V _a934, V[] _rest930) => {
V ex_950 = default;
V ez_951 = default;
V mx_952 = default;
V mz_953 = default;
V x_938 = default;
V z_940 = default;
V L_942 = default;
V a_944 = default;
V c_946 = default;
V h_948 = default;
{ V _t936 = ListOf(_a931);
{ V _t937 = GetIdx(_t936, 0D);
x_938 = _t937; }
{ V _t939 = GetIdx(_t936, 1D);
z_940 = _t939; }
{ V _t941 = GetIdx(_t936, 2D);
L_942 = _t941; }
{ V _t943 = GetIdx(_t936, 3D);
a_944 = _t943; }
{ V _t945 = GetIdx(_t936, 4D);
c_946 = _t945; }
{ V _t947 = GetIdx(_t936, 5D);
h_948 = _t947; }
}
ex_950 = Add(x_938, ((V)((ToNum(L_942) * FdLibm.Cos(ToNum(a_944))))));
ez_951 = Add(z_940, ((V)((ToNum(L_942) * FdLibm.Sin(ToNum(a_944))))));
mx_952 = Add(x_938, ((V)(((ToNum(L_942) * 0.5) * FdLibm.Cos((ToNum(a_944) - 0.5))))));
mz_953 = Add(z_940, ((V)(((ToNum(L_942) * 0.5) * FdLibm.Sin((ToNum(a_944) - 0.5))))));
return ((V)(string.Concat(string.Concat("<path d=\"M", ToStr(Call(f1_23, V.Undef, x_938)), " ", ToStr(Call(f1_23, V.Undef, z_940)), "Q", ToStr(Call(f1_23, V.Undef, mx_952)), " ", ToStr(Call(f1_23, V.Undef, mz_953)), " ", ToStr(Call(f1_23, V.Undef, ex_950)), " ", ToStr(Call(f1_23, V.Undef, ez_951)), "\" stroke=\"", ToStr(c_946), "\" stroke-width=\"", ToStr((w_935 is var _t954 && Truthy(_t954) ? _t954 : ((V)(1.6)))), "\" fill=\"none\" stroke-linecap=\"round\"/>"), (GtN(h_948, 0.7) ? string.Concat("<path d=\"M", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(x_938) - 0.3))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(z_940) - 0.3))))), "Q", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(mx_952) - 0.3))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(mz_953) - 0.3))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(ex_950) - 0.2))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(ez_951) - 0.2))))), "\" stroke=\"#5c5c66\" stroke-width=\"0.45\" fill=\"none\" stroke-linecap=\"round\" opacity=\"0.8\"/>") : ""))));
return default;
}, 2, "", true);
art_912 = ((V)(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(Call(dP_50, V.Undef, P_885)), "\" fill=\"#26262c\"/>")).V(Invoke(Invoke(tf_910, "map", Fn((V _arrowThis962, int _argc955, V q_961, V _a958, V _a959, V _a960, V[] _rest956) => {
return Call(tuft_911, V.Undef, q_961);
}, 1, "", true)), "join", ((V)("")))).End()));
fr_913 = new JsStrBuf("");
per_914 = Arr();
Invoke(P_885, "forEach", Fn((V _arrowThis971, int _argc963, V a_969, V i_970, V _a967, V _a968, V[] _rest964) => {
V b_972 = default;
double L_973 = 0;
double n_974 = 0;
b_972 = GetIdx(P_885, (ToNum(Add(i_970, ((V)(1D)))) % ToNum(Get(P_885, "length"))));
L_973 = Hypot((ToNum(GetIdx(b_972, 0D)) - ToNum(GetIdx(a_969, 0D))), (ToNum(GetIdx(b_972, 1D)) - ToNum(GetIdx(a_969, 1D))));
n_974 = Max(1D, Round((L_973 / 2.4)));
{
double k_975 = 0;
k_975 = 0D;
while (true) {
if (!((k_975 < n_974))) break;
Invoke(per_914, "push", Arr(Add(GetIdx(a_969, 0D), ((V)((((ToNum(GetIdx(b_972, 0D)) - ToNum(GetIdx(a_969, 0D))) * k_975) / n_974)))), Add(GetIdx(a_969, 1D), ((V)((((ToNum(GetIdx(b_972, 1D)) - ToNum(GetIdx(a_969, 1D))) * k_975) / n_974))))));
k_975++;
}
}
return default;
}, 2, "", true));
Invoke(per_914, "forEach", Fn((V _arrowThis988, int _argc977, V _a979, V _a980, V _a981, V _a982, V[] _rest978) => {
double a_989 = 0;
V x_985 = default;
V z_987 = default;
{ V _t983 = ListOf(_a979);
{ V _t984 = GetIdx(_t983, 0D);
x_985 = _t984; }
{ V _t986 = GetIdx(_t983, 1D);
z_987 = _t986; }
}
a_989 = (FdLibm.Atan2((ToNum(z_987) / Dd_882), (ToNum(x_985) / W_881)) + ((ToNum(Call(R_909, V.Undef)) - 0.5) * 0.9));
fr_913.V(Call(tuft_911, V.Undef, Arr(((V)((ToNum(x_985) - (FdLibm.Cos(a_989) * 1.2)))), ((V)((ToNum(z_987) - (FdLibm.Sin(a_989) * 1.2)))), ((V)((2.4 + (ToNum(Call(R_909, V.Undef)) * 2.2)))), ((V)(a_989)), GetIdx(PAL_886, ((double)(ToInt32((ToNum(Call(R_909, V.Undef)) * 5D)) | ToInt32(0D)))), Call(R_909, V.Undef)), ((V)(1.5))));
return default;
}, 1, "", true));
s_915 = Add(Add(Call(slab_51, V.Undef, C_908, P_885, ((V)(T_884)), ((V)("#1f1f24"))), Call(top_52, V.Undef, C_908, ((V)((T_884 * 0.45))), ((V)(fr_913.Str)))), Call(top_52, V.Undef, C_908, ((V)(T_884)), ((V)(JsStrBuf.Begin().V(Call(face_53, V.Undef, ((V)("sh")), P_885, art_912, ((V)(0.4)))).S(fr_913.Str).End()))));
return NewObj(3).Put("defs", DEF13_47).Put("front", s_915).Put("bb", Invoke(C_908, "bb", ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_887;
return default;
}, 1, "", true));
Set(N_12, "deco13", Fn((V _arrowThis997, int _argc990, V S_996, V _a993, V _a994, V _a995, V[] _rest991) => {
double W_998 = 0;
double Dd_999 = 0;
double T_1000 = 0;
V P_1001 = default;
V D_1002 = default;
V G_1003 = default;
W_998 = 196D;
Dd_999 = 126D;
T_1000 = 1.8;
P_1001 = Call(rrP_49, V.Undef, ((V)(W_998)), ((V)(Dd_999)), ((V)(2D)));
D_1002 = Call(RUG_54, V.Undef, ((V)(200D)), ((V)(130D)));
G_1003 = Fn((V _arrowThis1013, int _argc1004, V st_1010, V fl_1011, V k_1012, V _a1009, V[] _rest1005) => {
V w_1014 = default;
JsStrBuf g_1015 = null;
w_1014 = Fn((V _arrowThis1023, int _argc1016, V x_1022, V _a1019, V _a1020, V _a1021, V[] _rest1017) => {
return Call(f1_23, V.Undef, ((V)((ToNum(x_1022) * ToNum((k_1012 is var _t1024 && Truthy(_t1024) ? _t1024 : ((V)(1D))))))));
}, 1, "", true);
g_1015 = new JsStrBuf(string.Concat("<g fill=\"none\" stroke=\"", ToStr(st_1010), "\" stroke-linejoin=\"miter\">"));
g_1015.S(string.Concat("<rect x=\"", NumStr((((-W_998) / 2D) + 4.5)), "\" y=\"", NumStr((((-Dd_999) / 2D) + 4.5)), "\" width=\"", NumStr((W_998 - 9D)), "\" height=\"", NumStr((Dd_999 - 9D)), "\" stroke-width=\"", ToStr(Call(w_1014, V.Undef, ((V)(3.2)))), "\"/><rect x=\"", NumStr((((-W_998) / 2D) + 10D)), "\" y=\"", NumStr((((-Dd_999) / 2D) + 10D)), "\" width=\"", NumStr((W_998 - 20D)), "\" height=\"", NumStr((Dd_999 - 20D)), "\" stroke-width=\"", ToStr(Call(w_1014, V.Undef, ((V)(0.9)))), "\"/><rect x=\"", NumStr((((-W_998) / 2D) + 13D)), "\" y=\"", NumStr((((-Dd_999) / 2D) + 13D)), "\" width=\"", NumStr((W_998 - 26D)), "\" height=\"", NumStr((Dd_999 - 26D)), "\" stroke-width=\"", ToStr(Call(w_1014, V.Undef, ((V)(0.5)))), "\"/>"));
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis1036, int _argc1025, V _a1027, V _a1028, V _a1029, V _a1030, V[] _rest1026) => {
V sx_1033 = default;
V sz_1035 = default;
{ V _t1031 = ListOf(_a1027);
{ V _t1032 = GetIdx(_t1031, 0D);
sx_1033 = _t1032; }
{ V _t1034 = GetIdx(_t1031, 1D);
sz_1035 = _t1034; }
}
return ((V)(g_1015.S(string.Concat("<g transform=\"translate(", NumStr((ToNum(sx_1033) * ((W_998 / 2D) - 13D))), " ", NumStr((ToNum(sz_1035) * ((Dd_999 / 2D) - 13D))), ") scale(", NumStr((-ToNum(sx_1033))), " ", NumStr((-ToNum(sz_1035))), ")\"><path d=\"M0 18V0H18M4 13V8H8V4H13\" stroke-width=\"", ToStr(Call(w_1014, V.Undef, ((V)(1.2)))), "\"/><path d=\"M4 4h3v3h-3z\" fill=\"", ToStr(fl_1011), "\" stroke=\"none\"/></g>")).Str));
}, 1, "", true));
g_1015.S(string.Concat("<circle r=\"27\" stroke-width=\"", ToStr(Call(w_1014, V.Undef, ((V)(1.6)))), "\"/><circle r=\"23\" stroke-width=\"", ToStr(Call(w_1014, V.Undef, ((V)(0.6)))), "\"/>")).V(Invoke(Call(rep_25, V.Undef, ((V)(24D)), Fn((V _arrowThis1044, int _argc1037, V i_1043, V _a1040, V _a1041, V _a1042, V[] _rest1038) => {
double a_1045 = 0;
double r1_1046 = 0;
a_1045 = ((ToNum(i_1043) * PI_13) / 12D);
r1_1046 = (NumTruthy((ToNum(i_1043) % 2D)) ? 18D : 22.4);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_23, V.Undef, ((V)((9D * FdLibm.Cos(a_1045)))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((9D * FdLibm.Sin(a_1045)))))), "L", ToStr(Call(f1_23, V.Undef, ((V)((r1_1046 * FdLibm.Cos(a_1045)))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((r1_1046 * FdLibm.Sin(a_1045)))))), "\" stroke-width=\"", ToStr(Call(w_1014, V.Undef, ((V)((NumTruthy((ToNum(i_1043) % 2D)) ? 0.6 : 1D))))), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<circle r=\"7.2\" fill=\"", ToStr(fl_1011), "\" stroke=\"none\"/>"));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1054, int _argc1047, V sx_1053, V _a1050, V _a1051, V _a1052, V[] _rest1048) => {
return Call(rep_25, V.Undef, ((V)(3D)), Fn((V _arrowThis1062, int _argc1055, V k_1061, V _a1058, V _a1059, V _a1060, V[] _rest1056) => {
return ((V)(g_1015.S(string.Concat("<path d=\"M", NumStr((ToNum(sx_1053) * (52D + (ToNum(k_1061) * 7D)))), " -20L", NumStr((ToNum(sx_1053) * (64D + (ToNum(k_1061) * 7D)))), " 0L", NumStr((ToNum(sx_1053) * (52D + (ToNum(k_1061) * 7D)))), " 20\" stroke-width=\"", ToStr(Call(w_1014, V.Undef, ((V)(1.4)))), "\"/>")).Str));
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1070, int _argc1063, V sz_1069, V _a1066, V _a1067, V _a1068, V[] _rest1064) => {
return ((V)(g_1015.S(string.Concat("<g transform=\"translate(0 ", NumStr((ToNum(sz_1069) * ((Dd_999 / 2D) - 13D))), ") scale(1 ", ToStr(sz_1069), ")\"><path d=\"M-13 0A13 13 0 0 1 13 0M-8.5 0A8.5 8.5 0 0 1 8.5 0\" stroke-width=\"", ToStr(Call(w_1014, V.Undef, ((V)(1D)))), "\"/>", ToStr(Invoke(Call(rep_25, V.Undef, ((V)(7D)), Fn((V _arrowThis1078, int _argc1071, V i_1077, V _a1074, V _a1075, V _a1076, V[] _rest1072) => {
double a_1079 = 0;
a_1079 = (PI_13 + ((ToNum(Add(i_1077, ((V)(0.5)))) * PI_13) / 7D));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_23, V.Undef, ((V)((3.4 * FdLibm.Cos(a_1079)))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((3.4 * FdLibm.Sin(a_1079)))))), "L", ToStr(Call(f1_23, V.Undef, ((V)((8D * FdLibm.Cos(a_1079)))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((8D * FdLibm.Sin(a_1079)))))), "\" stroke-width=\"", ToStr(Call(w_1014, V.Undef, ((V)(0.7)))), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))), "</g>")).Str));
}, 1, "", true));
return ((V)(string.Concat(g_1015.Str, "</g>")));
return default;
}, 3, "", true);
Set(D_1002, "fx", Fn((V _arrowThis1087, int _argc1080, V ctx_1086, V _a1083, V _a1084, V _a1085, V[] _rest1081) => {
V C_1088 = default;
V R_1089 = default;
JsStrBuf art_1090 = null;
V s_1091 = default;
C_1088 = Call(cam_15, V.Undef, ctx_1086);
R_1089 = Call(rng_19, V.Undef, ((V)("deco13")));
art_1090 = new JsStrBuf(string.Concat(string.Concat("<defs><linearGradient id=\"dgl\" gradientUnits=\"userSpaceOnUse\" x1=\"-60\" y1=\"-40\" x2=\"-20\" y2=\"40\"><stop offset=\"0\" stop-color=\"#fff6c8\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#fff6c8\" stop-opacity=\"0.95\"/><stop offset=\"1\" stop-color=\"#fff6c8\" stop-opacity=\"0\"/><animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"-120 0;-120 0;240 0\" keyTimes=\"0;0.35;1\" dur=\"5s\" repeatCount=\"indefinite\"/></linearGradient></defs>", ""), string.Concat("<rect x=\"", NumStr(((-W_998) / 2D)), "\" y=\"", NumStr(((-Dd_999) / 2D)), "\" width=\"", NumStr(W_998), "\" height=\"", NumStr(Dd_999), "\" fill=\"#8c1a2b\"/><rect x=\"", NumStr((((-W_998) / 2D) + 13D)), "\" y=\"", NumStr((((-Dd_999) / 2D) + 13D)), "\" width=\"", NumStr((W_998 - 26D)), "\" height=\"", NumStr((Dd_999 - 26D)), "\" fill=\"#7a1525\"/>")));
art_1090.S("<g filter=\"url(#r13b)\">").V(Invoke(Call(rep_25, V.Undef, ((V)(12D)), Fn((V _arrowThis1099, int _argc1092, V i_1098, V _a1095, V _a1096, V _a1097, V[] _rest1093) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_23, V.Undef, ((V)(((ToNum(Call(R_1089, V.Undef)) - 0.5) * W_998))))), "\" cy=\"", ToStr(Call(f1_23, V.Undef, ((V)(((ToNum(Call(R_1089, V.Undef)) - 0.5) * Dd_999))))), "\" rx=\"", ToStr(Call(f1_23, V.Undef, ((V)((10D + (ToNum(Call(R_1089, V.Undef)) * 14D)))))), "\" ry=\"", ToStr(Call(f1_23, V.Undef, ((V)((7D + (ToNum(Call(R_1089, V.Undef)) * 9D)))))), "\" fill=\"", (NumTruthy((ToNum(i_1098) % 2D)) ? "#a02436" : "#5e0f1b"), "\" opacity=\"0.35\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
art_1090.S(string.Concat("<circle r=\"7.2\" fill=\"#d9a441\"/><circle r=\"3.6\" fill=\"#8c1a2b\"/>", ""));
art_1090.S(string.Concat("<g transform=\"translate(0.5 0.7)\" opacity=\"0.7\" filter=\"url(#r13s)\">", ToStr(Call(G_1003, V.Undef, ((V)("#3e0912")), ((V)("#3e0912")))), "</g>")).V(Call(G_1003, V.Undef, ((V)("#d9a441")), ((V)("#d9a441")))).S(string.Concat("<g transform=\"translate(-0.25 -0.3)\" opacity=\"0.45\">", ToStr(Call(G_1003, V.Undef, ((V)("#ffe7a0")), ((V)("none")), ((V)(0.4)))), "</g>")).V(Call(G_1003, V.Undef, ((V)("url(#dgl)")), ((V)("url(#dgl)")))).S(string.Concat("<circle r=\"3.6\" fill=\"#8c1a2b\"/>", ""));
s_1091 = Add(Call(slab_51, V.Undef, C_1088, P_1001, ((V)(T_1000)), ((V)("#6e1220"))), Call(top_52, V.Undef, C_1088, ((V)(T_1000)), Call(face_53, V.Undef, ((V)("dc")), P_1001, ((V)(art_1090.Str)), ((V)(0.24)))));
return NewObj(3).Put("defs", DEF13_47).Put("front", s_1091).Put("bb", Invoke(C_1088, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1002;
return default;
}, 1, "", true));
Set(N_12, "cloud13", Fn((V _arrowThis1107, int _argc1100, V S_1106, V _a1103, V _a1104, V _a1105, V[] _rest1101) => {
double A_1108 = 0;
double B_1109 = 0;
double T_1110 = 0;
V cl_1111 = default;
V P_1112 = default;
V D_1113 = default;
V spk_1114 = default;
A_1108 = 92D;
B_1109 = 64D;
T_1110 = 3.2;
cl_1111 = Fn((V _arrowThis1122, int _argc1115, V k_1121, V _a1118, V _a1119, V _a1120, V[] _rest1116) => {
return Call(rep_25, V.Undef, ((V)(120D)), Fn((V _arrowThis1130, int _argc1123, V i_1129, V _a1126, V _a1127, V _a1128, V[] _rest1124) => {
double t_1131 = 0;
double r_1132 = 0;
t_1131 = (((ToNum(i_1129) / 120D) * 2D) * PI_13);
r_1132 = ((0.88 + (0.12 * System.Math.Abs(FdLibm.Sin((4D * t_1131))))) * ToNum(k_1121));
return Arr(((V)(((A_1108 * r_1132) * FdLibm.Cos(t_1131)))), ((V)(((B_1109 * r_1132) * FdLibm.Sin(t_1131)))));
return default;
}, 1, "", true));
}, 1, "", true);
P_1112 = Call(cl_1111, V.Undef, ((V)(1D)));
D_1113 = Call(RUG_54, V.Undef, ((V)(200D)), ((V)(140D)), NewObj(1).Put("round", ((V)(1D))).V);
spk_1114 = Fn((V _arrowThis1143, int _argc1133, V x_1139, V z_1140, V r_1141, V b_1142, V[] _rest1134) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_23, V.Undef, x_1139)), " ", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(z_1140) - ToNum(r_1141)))))), "Q", ToStr(Call(f1_23, V.Undef, Add(x_1139, ((V)((ToNum(r_1141) * 0.18)))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(z_1140) - (ToNum(r_1141) * 0.18)))))), " ", ToStr(Call(f1_23, V.Undef, Add(x_1139, r_1141))), " ", ToStr(Call(f1_23, V.Undef, z_1140)), "Q", ToStr(Call(f1_23, V.Undef, Add(x_1139, ((V)((ToNum(r_1141) * 0.18)))))), " ", ToStr(Call(f1_23, V.Undef, Add(z_1140, ((V)((ToNum(r_1141) * 0.18)))))), " ", ToStr(Call(f1_23, V.Undef, x_1139)), " ", ToStr(Call(f1_23, V.Undef, Add(z_1140, r_1141))), "Q", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(x_1139) - (ToNum(r_1141) * 0.18)))))), " ", ToStr(Call(f1_23, V.Undef, Add(z_1140, ((V)((ToNum(r_1141) * 0.18)))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(x_1139) - ToNum(r_1141)))))), " ", ToStr(Call(f1_23, V.Undef, z_1140)), "Q", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(x_1139) - (ToNum(r_1141) * 0.18)))))), " ", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(z_1140) - (ToNum(r_1141) * 0.18)))))), " ", ToStr(Call(f1_23, V.Undef, x_1139)), " ", ToStr(Call(f1_23, V.Undef, ((V)((ToNum(z_1140) - ToNum(r_1141)))))), "Z\" fill=\"#ffffff\">", ToStr(Call(an_20, V.Undef, ((V)("opacity")), ((V)("0.2;1;0.2")), ((V)(0.9)), b_1142)), "</path>")));
}, 4, "", true);
Set(D_1113, "fx", Fn((V _arrowThis1151, int _argc1144, V ctx_1150, V _a1147, V _a1148, V _a1149, V[] _rest1145) => {
V C_1152 = default;
JsStrBuf art_1153 = null;
V s_1154 = default;
C_1152 = Call(cam_15, V.Undef, ctx_1150);
art_1153 = new JsStrBuf(string.Concat(string.Concat("<defs><linearGradient id=\"csg\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#f6efff\"/><stop offset=\"0.5\" stop-color=\"#e4eaff\"/><stop offset=\"1\" stop-color=\"#fbe4f1\"/></linearGradient>", ""), string.Concat("<linearGradient id=\"csh\" gradientUnits=\"userSpaceOnUse\" x1=\"-60\" y1=\"0\" x2=\"60\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffd6f0\" stop-opacity=\"0\"/><stop offset=\"0.35\" stop-color=\"#ffc8ea\" stop-opacity=\"0.55\"/><stop offset=\"0.65\" stop-color=\"#bfe8ff\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#bfe8ff\" stop-opacity=\"0\"/><animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"-150 0;150 0\" dur=\"7s\" repeatCount=\"indefinite\"/></linearGradient>", ""), string.Concat("<linearGradient id=\"csw\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0.5\"/></linearGradient></defs>", ""), string.Concat("<path d=\"", ToStr(Call(dP_50, V.Undef, P_1112)), "\" fill=\"url(#csg)\"/><rect x=\"-100\" y=\"-70\" width=\"200\" height=\"140\" fill=\"url(#csh)\"/>")));
Invoke(Arr(((V)(0.76)), ((V)(0.52)), ((V)(0.28))), "forEach", Fn((V _arrowThis1162, int _argc1155, V k_1161, V _a1158, V _a1159, V _a1160, V[] _rest1156) => {
V d_1163 = default;
d_1163 = Call(dP_50, V.Undef, Call(cl_1111, V.Undef, k_1161));
art_1153.S(string.Concat("<path d=\"", ToStr(d_1163), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.7\" transform=\"translate(-0.5 -0.6)\"/><path d=\"", ToStr(d_1163), "\" fill=\"none\" stroke=\"#bfb0e2\" stroke-width=\"0.8\"/>"));
return default;
}, 1, "", true));
art_1153.S(string.Concat("<g>", ToStr(Call(at_21, V.Undef, ((V)("translate")), ((V)("-120 0;120 0")), ((V)(4.5)))), "<rect x=\"-16\" y=\"-70\" width=\"16\" height=\"140\" fill=\"url(#csw)\" transform=\"skewX(-12)\"/>")).V(Invoke(Invoke(Arr(Arr(((V)((-56D))), ((V)(2.4))), Arr(((V)((-38D))), ((V)(1.6))), Arr(((V)((-20D))), ((V)(2.8))), Arr(((V)((-2D))), ((V)(1.8))), Arr(((V)(16D)), ((V)(2.6))), Arr(((V)(34D)), ((V)(1.5))), Arr(((V)(52D)), ((V)(2.2)))), "map", Fn((V _arrowThis1176, int _argc1164, V _a1166, V i_1170, V _a1168, V _a1169, V[] _rest1165) => {
V z_1173 = default;
V r_1175 = default;
{ V _t1171 = ListOf(_a1166);
{ V _t1172 = GetIdx(_t1171, 0D);
z_1173 = _t1172; }
{ V _t1174 = GetIdx(_t1171, 1D);
r_1175 = _t1174; }
}
return Call(spk_1114, V.Undef, ((V)(((ToNum(z_1173) * 0.21) - 2D))), z_1173, r_1175, Call(n4_24, V.Undef, ((V)(((-ToNum(i_1170)) * 0.13)))));
}, 2, "", true)), "join", ((V)("")))).S("</g>");
s_1154 = Add(Call(slab_51, V.Undef, C_1152, P_1112, ((V)(T_1110)), ((V)("#d6cdea"))), Call(top_52, V.Undef, C_1152, ((V)(T_1110)), Call(face_53, V.Undef, ((V)("cl")), P_1112, ((V)(art_1153.Str)), ((V)(0.16)))));
return NewObj(3).Put("defs", DEF13_47).Put("front", s_1154).Put("bb", Invoke(C_1152, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1113;
return default;
}, 1, "", true));
Set(RD_8, "SET13", NewObj(10).Put("MOV-005", NewObj(3).Put("s3", V.Null).Put("f13", ((V)("conc"))).Put("note", ((V)("Bare grey concrete with saw-cut joints, a long crack with a chipped edge, an old oil stain and paint specks. A black cable and an orange extension cord snake across it, held down with strips of silver duct tape."))).V).Put("MOV-025", NewObj(2).Put("f13", ((V)("tile"))).Put("note", ((V)("Low-pile grey carpet squares laid with the pile turned every other way, a worn path down the middle, one bluer replacement tile and a corner that has started to curl up."))).V).Put("MOV-045", NewObj(3).Put("f13", ((V)("crim"))).Put("live", ((V)("Chasing aisle lights"))).Put("note", ((V)("Plush crimson cinema carpet with a gold diamond pattern. Two aisle strips run toward the screen, with little amber lights that chase forward like in a real theatre."))).V).Put("MOV-065", NewObj(3).Put("f13", ((V)("teak"))).Put("live", ((V)("Glowing guides"))).Put("note", ((V)("Long dark teak planks with soft grain and staggered joints, polished so the screen glow shows in them. Warm LED guide strips are set into both sides with a pulse of light running toward the screen, and the heated floor glows softly."))).V).Put("MOV-085", NewObj(3).Put("f13", ((V)("glass"))).Put("live", ((V)("Bass glow"))).Put("note", ((V)("Dark obsidian glass tiles with tiny stars underneath. Panels light up in waves of cyan, violet and pink with every bass hit."))).V).Put("MOV-020", NewObj(3).Put("spec", ((V)("rag13"))).Put("live", ((V)("Loose thread sways"))).Put("note", ((V)("An oval rag rug braided from strips of old fabric in red, mustard, denim, green, cream and plum. The edge is frayed, and one loose strand sticks out and sways."))).V).Put("MOV-040", NewObj(2).Put("spec", ((V)("film13"))).Put("note", ((V)("A long black nylon runner printed like a film strip: sprocket holes along both edges and eight frames telling a tiny story about a bouncing Squish, ending with THE END. A soft sheen slides across the nylon."))).V).Put("MOV-060", NewObj(2).Put("spec", ((V)("shag13"))).Put("note", ((V)("A thick charcoal shag rug with deep, floppy tufts that spill over the edges. It soaks up sound and light so the room stays dark and quiet."))).V).Put("MOV-080", NewObj(3).Put("spec", ((V)("deco13"))).Put("live", ((V)("Gold shimmer"))).Put("note", ((V)("A hand-tufted crimson rug with a carved gold Art Deco design: a sunburst medallion, stepped corners, fan motifs and chevrons. A soft shimmer runs across the gold."))).V).Put("MOV-100", NewObj(3).Put("spec", ((V)("cloud13"))).Put("live", ((V)("Self-cleaning sparkle"))).Put("note", ((V)("A cloud-shaped silk rug with quilted sound-soaking channels. Its pearly sheen shifts between pink and blue, and a sweep of sparkles keeps gliding across it to clean it."))).V).V);
edit12_55 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis1184, int _argc1177, V rows_1183, V _a1180, V _a1181, V _a1182, V[] _rest1178) => {
return Invoke(Call(edit12_55, V.Undef, rows_1183), "map", Fn((V _arrowThis1192, int _argc1185, V r_1191, V _a1188, V _a1189, V _a1190, V[] _rest1186) => {
return (Truthy(GetK(Get(RD_8, "SET13"), Get(r_1191, "id"))) ? Object_assign(NewObj(0).V, r_1191, GetK(Get(RD_8, "SET13"), Get(r_1191, "id"))) : r_1191);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H13", NewObj(12).Put("px", px_30).Put("quad", quad_34).Put("lineUV", lineUV_35).Put("crv", crv_36).Put("fblot", fblot_39).Put("FL", FL_38).Put("slab", slab_51).Put("top", top_52).Put("face", face_53).Put("ellP", ellP_48).Put("rrP", rrP_49).Put("dP", dP_50).V);
Set(RD_8, "PLUS13", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
