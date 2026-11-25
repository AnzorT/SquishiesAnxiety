// beach.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_beach_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("<", "g");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("\"", "g");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("&", "g");
        public static void Run()
        {
Call(Named(boot_974 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V X_8 = default;
V K_9 = default;
V f1_10 = default;
V mix_11 = default;
V shade_12 = default;
double VW_13 = 0;
double PI_14 = 0;
double LV_15 = 0;
V WY_16 = default;
V sideB_17 = default;
V hash_18 = default;
V rng_19 = default;
V rep_20 = default;
V n3_21 = default;
V pd_22 = default;
V esc_23 = default;
V P_24 = default;
V AT_25 = default;
V AN_26 = default;
V SPL_27 = default;
V circ_28 = default;
V ell_29 = default;
V rr_30 = default;
V stp_31 = default;
V LG_32 = default;
V RG_33 = default;
double SO_34 = 0;
double BY0_35 = 0;
double BM_36 = 0;
V shore_37 = default;
V PIER_38 = default;
V FISH_39 = default;
V B_40 = default;
V ice_41 = default;
V onPier_42 = default;
V inSea_43 = default;
V wet_44 = default;
V nearPier_45 = default;
V clamp_46 = default;
V randSand_47 = default;
V randSea_48 = default;
V itemX_49 = default;
V gate_50 = default;
V polySvg_51 = default;
V textSvg_52 = default;
V SKY_53 = default;
V SEA_54 = default;
V SAND_55 = default;
V NIGHT_56 = default;
V PIERS_57 = default;
V scene_58 = default;
V thumb_59 = default;
V SHELLK_60 = default;
V shellSvg_61 = default;
V snowmanSvg_62 = default;
V SNOWMEN_63 = default;
V props_64 = default;
V shell0_65 = default;
V AUG_66 = default;
V BSH_67 = default;
V beachShell_68 = default;
if (_self1.IsNullish) _self1 = GlobalV;
clamp_46 = Fn((V _self69, int _argc70, V x_76, V y_77, V m_78, V o_79, V[] _rest71) => {
V L_80 = default;
if (_self69.IsNullish) _self69 = GlobalV;
o_79 = (o_79 is var _t81 && Truthy(_t81) ? _t81 : NewObj(0).V);
y_77 = ((V)(Max(BY0_35, Min(ToNum(Get(X_8, "FY1")), ToNum(y_77)))));
L_80 = Add(Invoke(X_8, "edge", y_77), ((V)((m_78.IsNullish ? BM_36 : Min(ToNum(m_78), BM_36)))));
if (Truthy((Call(nearPier_45, V.Undef, x_76, y_77) is var _t82 && !Truthy(_t82) ? _t82 : (GtN(x_76, (ToNum(Call(shore_37, V.Undef, y_77)) - 24D)) ? V.True : V.False)))) {
if (GtN(x_76, (ToNum(Get(PIER_38, "xe")) - 6D))) {
return Arr(((V)(Min((ToNum(Get(PIER_38, "xp1")) - 10D), ToNum(x_76)))), ((V)(Max(ToNum(Add(Get(PIER_38, "py0"), ((V)(6D)))), Min((ToNum(Get(PIER_38, "py1")) - 6D), ToNum(y_77))))));
}
return Arr(((V)(Max(ToNum(Add(Get(PIER_38, "x0"), ((V)(8D)))), ToNum(x_76)))), ((V)(Max(ToNum(Add(Get(PIER_38, "y0"), ((V)(4D)))), Min((ToNum(Get(PIER_38, "y1")) - 4D), ToNum(y_77))))));
}
if (Truthy(Get(o_79, "sea"))) {
double xs_83 = 0;
xs_83 = Min(834D, ToNum(x_76));
if (Gt(((V)(xs_83)), Add(Add(Call(shore_37, V.Undef, y_77), Call(ice_41, V.Undef)), ((V)(10D))))) {
V yy_84 = default;
yy_84 = y_77;
if (((Gt(((V)(xs_83)), Get(PIER_38, "x0")) && GtN(yy_84, (ToNum(Get(PIER_38, "py0")) - 16D))) && Lt(yy_84, Add(Get(PIER_38, "py1"), ((V)(12D)))))) {
yy_84 = (LtN(yy_84, (ToNum(Add(Get(PIER_38, "py0"), Get(PIER_38, "py1"))) / 2D)) ? ((V)((ToNum(Get(PIER_38, "py0")) - 16D))) : Add(Get(PIER_38, "py1"), ((V)(12D))));
}
return Arr(((V)(xs_83)), ((V)(Max(BY0_35, Min(ToNum(Get(X_8, "FY1")), ToNum(yy_84))))));
}
}
return Arr(((V)(Max(ToNum(L_80), Min((ToNum(Add(Call(shore_37, V.Undef, y_77), Call(ice_41, V.Undef))) - 18D), ToNum(x_76))))), y_77);
return default;
}, 4, "clamp", false);
randSand_47 = Fn((V _self85, int _argc86, V R_92, V _a89, V _a90, V _a91, V[] _rest87) => {
double y_93 = 0;
V a_94 = default;
double b_95 = 0;
if (_self85.IsNullish) _self85 = GlobalV;
R_92 = (R_92 is var _t96 && Truthy(_t96) ? _t96 : Get(G("Math"), "random"));
y_93 = (118D + (ToNum(Call(R_92, V.Undef)) * (ToNum(Get(X_8, "FY1")) - 118D)));
a_94 = Add(Invoke(X_8, "edge", ((V)(y_93))), ((V)(40D)));
b_95 = (ToNum(Add(Call(shore_37, V.Undef, ((V)(y_93))), Call(ice_41, V.Undef))) - 40D);
return Arr(Add(a_94, ((V)((ToNum(Call(R_92, V.Undef)) * Max(10D, (b_95 - ToNum(a_94))))))), ((V)(y_93)));
return default;
}, 1, "randSand", false);
randSea_48 = Fn((V _self97, int _argc98, V R_104, V _a101, V _a102, V _a103, V[] _rest99) => {
if (_self97.IsNullish) _self97 = GlobalV;
R_104 = (R_104 is var _t105 && Truthy(_t105) ? _t105 : Get(G("Math"), "random"));
{
double i_106 = 0;
i_106 = 0D;
while (true) {
if (!((i_106 < 20D))) break;
double y_108 = 0;
V a_109 = default;
double b_110 = 0;
y_108 = (140D + (ToNum(Call(R_104, V.Undef)) * (ToNum(Get(X_8, "FY1")) - 140D)));
if (((y_108 > (ToNum(Get(PIER_38, "py0")) - 16D)) && Lt(((V)(y_108)), Add(Get(PIER_38, "py1"), ((V)(12D)))))) {
goto _cont107;
}
a_109 = Add(Add(Call(shore_37, V.Undef, ((V)(y_108))), Call(ice_41, V.Undef)), ((V)(34D)));
b_110 = 826D;
if (((b_110 - ToNum(a_109)) < 20D)) {
goto _cont107;
}
return Arr(Add(a_109, ((V)((ToNum(Call(R_104, V.Undef)) * (b_110 - ToNum(a_109)))))), ((V)(y_108)));
_cont107: ;
i_106++;
}
}
return Arr(((V)(760D)), ((V)(300D)));
return default;
}, 1, "randSea", false);
itemX_49 = Fn((V _self111, int _argc112, V x_118, V y_119, V hx_120, V sea_121, V[] _rest113) => {
V s_122 = default;
if (_self111.IsNullish) _self111 = GlobalV;
s_122 = Add(Call(shore_37, V.Undef, y_119), Call(ice_41, V.Undef));
if (Truthy(sea_121)) {
return ((V)(Max(ToNum(Add(Add(s_122, hx_120), ((V)(8D)))), Min((VW_13 - 14D), ToNum(x_118)))));
}
return ((V)(Min(((ToNum(s_122) - (ToNum(hx_120) * 0.6)) - 6D), ToNum(x_118))));
return default;
}, 4, "itemX", false);
gate_50 = Fn((V _self123, int _argc124, V s_130, V lk_131, V lab_132, V _a129, V[] _rest125) => {
double t0_133 = 0;
double t1_134 = 0;
V M_135 = default;
V Q_136 = default;
V Ln_137 = default;
V W_138 = default;
V WL_139 = default;
V WD_140 = default;
V o_141 = default;
V T_142 = default;
V top_143 = default;
double w_144 = 0;
double h_145 = 0;
V cx_146 = default;
double cy_147 = 0;
V ny_148 = default;
V hit_149 = default;
double tm_150 = 0;
double y_151 = 0;
V ex_152 = default;
if (_self123.IsNullish) _self123 = GlobalV;
t0_133 = 0.42;
t1_134 = 0.66;
M_135 = Fn((V _arrowThis161, int _argc153, V u_159, V v_160, V _a157, V _a158, V[] _rest154) => {
V p_162 = default;
p_162 = Call(sideB_17, V.Undef, s_130, ((V)((t0_133 + ((t1_134 - t0_133) * ToNum(u_159))))));
return Arr(GetIdx(p_162, 0D), ((V)((ToNum(GetIdx(p_162, 1D)) - ((72D * ToNum(Call(WY_16, V.Undef, GetIdx(p_162, 1D)))) * ToNum(v_160))))));
return default;
}, 2, "", true);
Q_136 = Fn((V _arrowThis170, int _argc163, V pts_169, V _a166, V _a167, V _a168, V[] _rest164) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_169, "map", Fn((V _arrowThis178, int _argc171, V q_177, V _a174, V _a175, V _a176, V[] _rest172) => {
V p_179 = default;
p_179 = Call(M_135, V.Undef, GetIdx(q_177, 0D), GetIdx(q_177, 1D));
return ((V)(JsStrBuf.Begin().V(Call(f1_10, V.Undef, GetIdx(p_179, 0D))).S(" ").V(Call(f1_10, V.Undef, GetIdx(p_179, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
Ln_137 = Fn((V _arrowThis188, int _argc180, V a_186, V b_187, V _a184, V _a185, V[] _rest181) => {
V p_189 = default;
V q_190 = default;
p_189 = Call(M_135, V.Undef, GetIdx(a_186, 0D), GetIdx(a_186, 1D));
q_190 = Call(M_135, V.Undef, GetIdx(b_187, 0D), GetIdx(b_187, 1D));
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_10, V.Undef, GetIdx(p_189, 0D))).S(" ").V(Call(f1_10, V.Undef, GetIdx(p_189, 1D))).S("L").V(Call(f1_10, V.Undef, GetIdx(q_190, 0D))).S(" ").V(Call(f1_10, V.Undef, GetIdx(q_190, 1D))).End()));
return default;
}, 2, "", true);
W_138 = ((V)("#b8804a"));
WL_139 = ((V)("#d49a60"));
WD_140 = ((V)("#5e3c1c"));
o_141 = Arr();
T_142 = Arr();
Invoke(o_141, "push", Call(pd_22, V.Undef, Call(Q_136, V.Undef, Arr(Arr(((V)((-0.2))), ((V)(0.02))), Arr(((V)(1.2)), ((V)(0.02))), Arr(((V)(1.2)), ((V)((-0.08)))), Arr(((V)((-0.2))), ((V)((-0.08)))))), ((V)("#2a1608")), ((V)(0D)), ((V)(0D)), ((V)(0.16))));
Invoke(Arr(Arr(((V)((-0.07))), ((V)(0.05))), Arr(((V)(0.95)), ((V)(1.07)))), "forEach", Fn((V _arrowThis202, int _argc191, V _a193, V _a194, V _a195, V _a196, V[] _rest192) => {
V a_199 = default;
V b_201 = default;
{ V _t197 = ListOf(_a193);
{ V _t198 = GetIdx(_t197, 0D);
a_199 = _t198; }
{ V _t200 = GetIdx(_t197, 1D);
b_201 = _t200; }
}
Invoke(o_141, "push", Call(pd_22, V.Undef, Call(Q_136, V.Undef, Arr(Arr(a_199, ((V)(0D))), Arr(b_201, ((V)(0D))), Arr(b_201, ((V)(1.2))), Arr(a_199, ((V)(1.2))))), W_138, WD_140, ((V)(1.5))), Call(pd_22, V.Undef, Call(Ln_137, V.Undef, Arr(Add(a_199, ((V)(0.04))), ((V)(0.05))), Arr(Add(a_199, ((V)(0.04))), ((V)(1.15)))), ((V)("none")), WL_139, ((V)(1.2)), ((V)(0.8))));
return default;
}, 1, "", true));
Invoke(o_141, "push", Call(pd_22, V.Undef, Call(Q_136, V.Undef, Arr(Arr(((V)((-0.18))), ((V)(1.1))), Arr(((V)(1.18)), ((V)(1.1))), Arr(((V)(1.18)), ((V)(1.26))), Arr(((V)((-0.18))), ((V)(1.26))))), WL_139, WD_140, ((V)(1.5))), Call(pd_22, V.Undef, Call(Ln_137, V.Undef, Arr(((V)((-0.14))), ((V)(1.16))), Arr(((V)(1.14)), ((V)(1.16)))), ((V)("none")), ((V)("#f0c48a")), ((V)(1D)), ((V)(0.7))));
if (Truthy(lk_131)) {
V m_203 = default;
Invoke(Arr(Arr(((V)(0.16)), ((V)(0.3))), Arr(((V)(0.5)), ((V)(0.64))), Arr(((V)(0.78)), ((V)(0.9)))), "forEach", Fn((V _arrowThis216, int _argc204, V _a206, V i_210, V _a208, V _a209, V[] _rest205) => {
V a_213 = default;
V b_215 = default;
{ V _t211 = ListOf(_a206);
{ V _t212 = GetIdx(_t211, 0D);
a_213 = _t212; }
{ V _t214 = GetIdx(_t211, 1D);
b_215 = _t214; }
}
return Invoke(o_141, "push", Call(pd_22, V.Undef, Call(Q_136, V.Undef, Arr(Arr(((V)((-0.04))), a_213), Arr(((V)(1.04)), ((V)((ToNum(b_215) - 0.02)))), Arr(((V)(1.04)), Add(b_215, ((V)(0.1)))), Arr(((V)((-0.04))), Add(a_213, ((V)(0.12)))))), ((V)((NumTruthy((ToNum(i_210) % 2D)) ? "#a07a50" : "#b08a5e"))), ((V)("#6b4a2a")), ((V)(1D))));
}, 2, "", true));
m_203 = Call(M_135, V.Undef, ((V)(0.5)), ((V)(0.56)));
Invoke(o_141, "push", Call(pd_22, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_10, V.Undef, ((V)((ToNum(GetIdx(m_203, 0D)) - 4D))))).S(" ").V(Call(f1_10, V.Undef, ((V)((ToNum(GetIdx(m_203, 1D)) - 2D))))).S("V").V(Call(f1_10, V.Undef, ((V)((ToNum(GetIdx(m_203, 1D)) - 6D))))).S("a4 4 0 0 1 8 0V").V(Call(f1_10, V.Undef, ((V)((ToNum(GetIdx(m_203, 1D)) - 2D))))).End())), ((V)("none")), ((V)("#5a5450")), ((V)(2.2))), Call(pd_22, V.Undef, Call(rr_30, V.Undef, ((V)((ToNum(GetIdx(m_203, 0D)) - 6.5))), ((V)((ToNum(GetIdx(m_203, 1D)) - 2D))), ((V)(13D)), ((V)(10.5)), ((V)(2.5))), ((V)("#ffd66b")), ((V)("#a87a1a")), ((V)(1D))), Call(pd_22, V.Undef, Call(circ_28, V.Undef, GetIdx(m_203, 0D), Add(GetIdx(m_203, 1D), ((V)(3.2))), ((V)(1.5))), ((V)("#7a5a10"))));
} else {
V a_217 = default;
V b_218 = default;
V c_219 = default;
a_217 = Call(M_135, V.Undef, ((V)(0D)), ((V)(0.42)));
b_218 = Call(M_135, V.Undef, ((V)(1D)), ((V)(0.42)));
c_219 = Call(M_135, V.Undef, ((V)(0.5)), ((V)(0.3)));
Invoke(o_141, "push", Call(pd_22, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_10, V.Undef, GetIdx(a_217, 0D))).S(" ").V(Call(f1_10, V.Undef, GetIdx(a_217, 1D))).S("Q").V(Call(f1_10, V.Undef, GetIdx(c_219, 0D))).S(" ").V(Call(f1_10, V.Undef, Add(GetIdx(c_219, 1D), ((V)(6D))))).S(" ").V(Call(f1_10, V.Undef, GetIdx(b_218, 0D))).S(" ").V(Call(f1_10, V.Undef, GetIdx(b_218, 1D))).End())), ((V)("none")), ((V)("#e8d2a0")), ((V)(2.4))));
Invoke(Arr(((V)(0.25)), ((V)(0.5)), ((V)(0.75))), "forEach", Fn((V _arrowThis228, int _argc220, V u_226, V i_227, V _a224, V _a225, V[] _rest221) => {
V q_229 = default;
q_229 = Call(M_135, V.Undef, u_226, ((V)((0.34 - (FdLibm.Sin((ToNum(u_226) * PI_14)) * 0.06)))));
Invoke(o_141, "push", Call(pd_22, V.Undef, Call(ell_29, V.Undef, GetIdx(q_229, 0D), Add(GetIdx(q_229, 1D), ((V)(3D))), ((V)(2.6)), ((V)(3.2))), GetK(Arr(((V)("#ffb3a0")), ((V)("#fff1d8")), ((V)("#9fe0e0"))), i_227), ((V)("#8a5a2c")), ((V)(0.8))));
return default;
}, 2, "", true));
}
top_143 = Call(M_135, V.Undef, ((V)(0.5)), ((V)(1.26)));
w_144 = (16D + (ToNum(Get(lab_132, "length")) * 5.2));
h_145 = 15D;
cx_146 = GetIdx(top_143, 0D);
cy_147 = (ToNum(GetIdx(top_143, 1D)) - 14D);
ny_148 = GetIdx(top_143, 1D);
Invoke(o_141, "push", Call(pd_22, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_10, V.Undef, ((V)((ToNum(cx_146) - (w_144 * 0.3)))))).S(" ").V(Call(f1_10, V.Undef, ((V)((cy_147 - (h_145 / 2D)))))).S("L").V(Call(f1_10, V.Undef, ((V)((ToNum(cx_146) - (w_144 * 0.3)))))).S(" ").V(Call(f1_10, V.Undef, ny_148)).S("M").V(Call(f1_10, V.Undef, Add(cx_146, ((V)((w_144 * 0.3)))))).S(" ").V(Call(f1_10, V.Undef, ((V)((cy_147 - (h_145 / 2D)))))).S("L").V(Call(f1_10, V.Undef, Add(cx_146, ((V)((w_144 * 0.3)))))).S(" ").V(Call(f1_10, V.Undef, ny_148)).End())), ((V)("none")), ((V)("#6b4426")), ((V)(1.2))));
Invoke(o_141, "push", Call(pd_22, V.Undef, Call(rr_30, V.Undef, ((V)((ToNum(cx_146) - (w_144 / 2D)))), ((V)(((cy_147 - (h_145 / 2D)) + 1.6))), ((V)(w_144)), ((V)(h_145)), ((V)(3D))), ((V)("rgba(60,30,10,0.28)"))), Call(pd_22, V.Undef, Call(rr_30, V.Undef, ((V)((ToNum(cx_146) - (w_144 / 2D)))), ((V)((cy_147 - (h_145 / 2D)))), ((V)(w_144)), ((V)(h_145)), ((V)(3D))), ((V)((Truthy(lk_131) ? "#c9b896" : "#fff2cf"))), ((V)((Truthy(lk_131) ? "#7d6248" : "#8a5a2c"))), ((V)(1.8))));
if (!(Truthy(lk_131))) {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis237, int _argc230, V sg_236, V _a233, V _a234, V _a235, V[] _rest231) => {
return Invoke(o_141, "push", Call(pd_22, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_10, V.Undef, ((V)((ToNum(Add(cx_146, ((V)((ToNum(sg_236) * ((w_144 / 2D) - 6D)))))) - 3D))))).S(" ").V(Call(f1_10, V.Undef, ((V)(cy_147)))).S("q1.5 -2.4 3 0t3 0").End())), ((V)("none")), ((V)("#3fa8d8")), ((V)(1.2))));
}, 1, "", true));
}
Invoke(T_142, "push", NewObj(5).Put("x", cx_146).Put("y", ((V)((cy_147 + 3.6)))).Put("t", lab_132).Put("f", ((V)((Truthy(lk_131) ? "#b23a2e" : "#5b3418")))).Put("sz", ((V)(8.8))).V);
hit_149 = Add(Call(Q_136, V.Undef, Arr(Arr(((V)((-0.24))), ((V)((-0.04)))), Arr(((V)(1.24)), ((V)((-0.04)))), Arr(((V)(1.24)), ((V)(1.5))), Arr(((V)((-0.24))), ((V)(1.5))))), Call(rr_30, V.Undef, ((V)(((ToNum(cx_146) - (w_144 / 2D)) - 2D))), ((V)(((cy_147 - (h_145 / 2D)) - 2D))), ((V)((w_144 + 4D))), ((V)((h_145 + 4D))), ((V)(3D))));
tm_150 = ((t0_133 + t1_134) / 2D);
y_151 = Max(ToNum(Add(Get(X_8, "FY0"), ((V)(6D)))), ((100D + (162D * tm_150)) + 10D));
ex_152 = Add(Invoke(X_8, "edge", ((V)(y_151))), ((V)(30D)));
return NewObj(5).Put("polys", o_141).Put("texts", T_142).Put("hit", hit_149).Put("spawn", Arr((SEqS(s_130, "L") ? ex_152 : ((V)((VW_13 - ToNum(ex_152))))), ((V)(y_151)))).Put("walk", Arr((SEqS(s_130, "L") ? Add(ex_152, ((V)(90D))) : ((V)(((VW_13 - ToNum(ex_152)) - 90D)))), ((V)((y_151 + 10D))))).V;
return default;
}, 3, "gate", false);
scene_58 = Fn((V _self238, int _argc239, V o_245, V _a242, V _a243, V _a244, V[] _rest240) => {
V sea_246 = default;
V nt_247 = default;
double st_248 = 0;
double pt_249 = 0;
double lt_250 = 0;
V rainy_251 = default;
V snowy_252 = default;
V sunny_253 = default;
V R_254 = default;
V NM_255 = default;
double icew_256 = 0;
double spd_257 = 0;
V sk_258 = default;
V SC_259 = default;
V sand_260 = default;
V sandD_261 = default;
V sandL_262 = default;
V wetC_263 = default;
V SH_264 = default;
V shoreD_265 = default;
V shoreOff_266 = default;
V seaPoly_267 = default;
V sandPoly_268 = default;
V d_269 = default;
JsStrBuf s_270 = null;
V cloud_271 = default;
double CL_272 = 0;
V cc_273 = default;
double NCR_274 = 0;
V Rt_275 = default;
double fo_276 = 0;
double fd_277 = 0;
V palm_278 = default;
V DF_279 = default;
V g_280 = default;
V PR_281 = default;
V X0_282 = default;
V Y0_283 = default;
V Y1_284 = default;
V XE_285 = default;
V Q0_286 = default;
V Q1_287 = default;
V XP_288 = default;
V FC_289 = default;
V pa_290 = default;
V pb_291 = default;
V pe_292 = default;
V pf_293 = default;
V pp_294 = default;
JsStrBuf pl_295 = null;
V railPosts_296 = default;
V glow_297 = default;
if (_self238.IsNullish) _self238 = GlobalV;
o_245 = (o_245 is var _t298 && Truthy(_t298) ? _t298 : NewObj(0).V);
sea_246 = (Truthy(GetK(SKY_53, Get(o_245, "season"))) ? Get(o_245, "season") : ((V)("sunny")));
nt_247 = (!(!(Truthy(Get(o_245, "night")))) ? V.True : V.False);
st_248 = Max(1D, Min(5D, ToNum((Get(o_245, "sand") is var _t299 && Truthy(_t299) ? _t299 : ((V)(1D))))));
pt_249 = Max(1D, Min(5D, ToNum((Get(o_245, "pier") is var _t300 && Truthy(_t300) ? _t300 : ((V)(1D))))));
lt_250 = Max(0D, Min(5D, ToNum((Get(o_245, "light") is var _t301 && Truthy(_t301) ? _t301 : ((V)(0D))))));
rainy_251 = (SEqS(sea_246, "rainy") ? V.True : V.False);
snowy_252 = (SEqS(sea_246, "snowy") ? V.True : V.False);
sunny_253 = (SEqS(sea_246, "sunny") ? V.True : V.False);
R_254 = Call(rng_19, V.Undef, ((V)(JsStrBuf.Begin().S("beach").V(sea_246).N(st_248).N(pt_249).End())));
NM_255 = Fn((V _arrowThis310, int _argc302, V c_308, V k_309, V _a306, V _a307, V[] _rest303) => {
return (Truthy(nt_247) ? Call(mix_11, V.Undef, c_308, NIGHT_56, k_309) : c_308);
}, 2, "", true);
icew_256 = (Truthy(snowy_252) ? 62D : 0D);
spd_257 = (Truthy(rainy_251) ? 0.62 : (Truthy(snowy_252) ? 1.8 : 1D));
sk_258 = Invoke(GetK(SKY_53, sea_246), "map", Fn((V _arrowThis319, int _argc311, V c_317, V i_318, V _a315, V _a316, V[] _rest312) => {
return Call(NM_255, V.Undef, c_317, ((V)((Truthy(i_318) ? 0.72 : 0.82))));
}, 2, "", true));
SC_259 = Invoke(GetK(SEA_54, sea_246), "map", Fn((V _arrowThis327, int _argc320, V c_326, V _a323, V _a324, V _a325, V[] _rest321) => {
return Call(NM_255, V.Undef, c_326, ((V)(0.62)));
}, 1, "", true));
sand_260 = GetIdx(SAND_55, (st_248 - 1D));
if (Truthy(rainy_251)) {
sand_260 = Call(mix_11, V.Undef, sand_260, ((V)("#8a7a5c")), ((V)(0.22)));
}
if (Truthy(snowy_252)) {
sand_260 = Call(mix_11, V.Undef, sand_260, ((V)("#e6ecf0")), ((V)(0.3)));
}
sand_260 = Call(NM_255, V.Undef, sand_260, ((V)(0.5)));
sandD_261 = Call(shade_12, V.Undef, sand_260, ((V)(0.86)));
sandL_262 = Call(mix_11, V.Undef, sand_260, ((V)("#ffffff")), ((V)(0.25)));
wetC_263 = Call(mix_11, V.Undef, sand_260, ((V)((Truthy(rainy_251) ? "#5a4a30" : "#8a6a3a"))), ((V)(0.32)));
SH_264 = Call(rep_20, V.Undef, ((V)(36D)), Fn((V _arrowThis335, int _argc328, V i_334, V _a331, V _a332, V _a333, V[] _rest329) => {
double y_336 = 0;
y_336 = (54D + (((393D - 54D) * ToNum(i_334)) / 35D));
return Arr(Call(shore_37, V.Undef, ((V)(y_336))), ((V)(y_336)));
return default;
}, 1, "", true));
shoreD_265 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(SH_264, "map", Fn((V _arrowThis344, int _argc337, V q_343, V _a340, V _a341, V _a342, V[] _rest338) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_10, V.Undef, GetIdx(q_343, 0D))).S(" ").V(Call(f1_10, V.Undef, GetIdx(q_343, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).End()));
shoreOff_266 = Fn((V _arrowThis352, int _argc345, V dx_351, V _a348, V _a349, V _a350, V[] _rest346) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(SH_264, "map", Fn((V _arrowThis360, int _argc353, V q_359, V _a356, V _a357, V _a358, V[] _rest354) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_10, V.Undef, Add(GetIdx(q_359, 0D), ((V)((ToNum(dx_351) * ToNum(Call(WY_16, V.Undef, ((V)(Max(100D, ToNum(GetIdx(q_359, 1D))))))))))))).S(" ").V(Call(f1_10, V.Undef, GetIdx(q_359, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).End()));
}, 1, "", true);
seaPoly_267 = ((V)(JsStrBuf.Begin().V(shoreD_265).S("L870 393L870 54Z").End()));
sandPoly_268 = ((V)(JsStrBuf.Begin().S("M-20 54").V(Invoke(shoreD_265, "replace", ((V)("M")), ((V)("L")))).S("L-20 400Z").End()));
d_269 = ((V)(JsStrBuf.Begin().V(Add(Add(Add(Add(Add(Add(Add(Call(LG_32, V.Undef, ((V)("bzSky")), Arr(Arr(((V)(0D)), GetIdx(sk_258, 0D)), Arr(((V)(1D)), GetIdx(sk_258, 1D))), ((V)("x1=\"0\" y1=\"-60\" x2=\"0\" y2=\"60\" gradientUnits=\"userSpaceOnUse\""))), Call(LG_32, V.Undef, ((V)("bzSea")), Arr(Arr(((V)(0D)), GetIdx(SC_259, 0D)), Arr(((V)(0.12)), GetIdx(SC_259, 1D)), Arr(((V)(0.55)), GetIdx(SC_259, 2D)), Arr(((V)(1D)), Call(mix_11, V.Undef, GetIdx(SC_259, 2D), GetIdx(SC_259, 3D), ((V)(0.4))))), ((V)("x1=\"0\" y1=\"54\" x2=\"0\" y2=\"393\" gradientUnits=\"userSpaceOnUse\"")))), Call(LG_32, V.Undef, ((V)("bzSand")), Arr(Arr(((V)(0D)), Call(mix_11, V.Undef, sand_260, GetIdx(sk_258, 1D), ((V)(0.25)))), Arr(((V)(0.25)), sand_260), Arr(((V)(1D)), Call(mix_11, V.Undef, sand_260, ((V)("#ffffff")), ((V)((Truthy(nt_247) ? 0D : 0.12)))))), ((V)("x1=\"0\" y1=\"54\" x2=\"0\" y2=\"393\" gradientUnits=\"userSpaceOnUse\"")))), Call(LG_32, V.Undef, ((V)("bzDune")), Arr(Arr(((V)(0D)), Call(mix_11, V.Undef, sandL_262, ((V)("#ffffff")), ((V)(0.1)))), Arr(((V)(0.55)), sand_260), Arr(((V)(1D)), sandD_261)), ((V)("x1=\"0\" y1=\"10\" x2=\"0\" y2=\"120\" gradientUnits=\"userSpaceOnUse\"")))), Call(LG_32, V.Undef, ((V)("bzDune2")), Arr(Arr(((V)(0D)), Call(mix_11, V.Undef, sand_260, GetIdx(sk_258, 1D), ((V)(0.45)))), Arr(((V)(1D)), Call(mix_11, V.Undef, sand_260, GetIdx(sk_258, 1D), ((V)(0.2))))))), Call(RG_33, V.Undef, ((V)("bzGlow")), Arr(Arr(((V)(0D)), ((V)("#fff2b0")), ((V)(0.85))), Arr(((V)(0.4)), ((V)("#ffd88a")), ((V)(0.35))), Arr(((V)(1D)), ((V)("#ffd88a")), ((V)(0D)))))), Call(RG_33, V.Undef, ((V)("bzSun")), Arr(Arr(((V)(0D)), ((V)("#fffbe0")), ((V)(0.95))), Arr(((V)(0.5)), ((V)("#fff1a8")), ((V)(0.4))), Arr(((V)(1D)), ((V)("#fff1a8")), ((V)(0D)))))), Call(RG_33, V.Undef, ((V)("bzCyan")), Arr(Arr(((V)(0D)), ((V)("#bffcff")), ((V)(0.9))), Arr(((V)(0.45)), ((V)("#4fe0f0")), ((V)(0.35))), Arr(((V)(1D)), ((V)("#4fe0f0")), ((V)(0D))))))).S(string.Concat("<clipPath id=\"bzSeaC\"><path d=\"", ToStr(seaPoly_267), "\"/></clipPath><clipPath id=\"bzSandC\"><path d=\"", ToStr(sandPoly_268), "\"/></clipPath>")).S(string.Concat("<filter id=\"bzB3\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"3\"/></filter><filter id=\"bzB8\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"8\"/></filter>", "")).S(string.Concat("<pattern id=\"bzWv\" width=\"54\" height=\"22\" patternUnits=\"userSpaceOnUse\"><path d=\"M4 6q6-4 12 0t12 0M30 17q6-4 12 0\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.3\" stroke-linecap=\"round\"/><animateTransform attributeName=\"patternTransform\" type=\"translate\" values=\"0 0;-54 22\" dur=\"", ToStr(Call(n3_21, V.Undef, ((V)((14D * spd_257))))), "s\" repeatCount=\"indefinite\"/></pattern>")).S(string.Concat("<pattern id=\"bzWv2\" width=\"90\" height=\"34\" patternUnits=\"userSpaceOnUse\"><path d=\"M8 10q9-5 18 0t18 0M52 26q8-4 16 0\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.8\" stroke-linecap=\"round\"/><animateTransform attributeName=\"patternTransform\" type=\"translate\" values=\"0 0;-90 34\" dur=\"", ToStr(Call(n3_21, V.Undef, ((V)((21D * spd_257))))), "s\" repeatCount=\"indefinite\"/></pattern>")).End()));
s_270 = new JsStrBuf("");
s_270.S(string.Concat("<rect x=\"-20\" y=\"-70\" width=\"900\" height=\"140\" fill=\"url(#bzSky)\"/>", ""));
if (Truthy(nt_247)) {
V Rs_361 = default;
Rs_361 = Call(rng_19, V.Undef, ((V)("stars")));
s_270.V(Invoke(Call(rep_20, V.Undef, ((V)(46D)), Fn((V _arrowThis369, int _argc362, V i_368, V _a365, V _a366, V _a367, V[] _rest363) => {
double x_370 = 0;
double y_371 = 0;
double r_372 = 0;
double dd_373 = 0;
x_370 = (ToNum(Call(Rs_361, V.Undef)) * 860D);
y_371 = ((-48D) + (ToNum(Call(Rs_361, V.Undef)) * 96D));
r_372 = (0.6 + (ToNum(Call(Rs_361, V.Undef)) * 1.1));
dd_373 = (1.6 + (ToNum(Call(Rs_361, V.Undef)) * 2.4));
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_10, V.Undef, ((V)(x_370)))), "\" cy=\"", ToStr(Call(f1_10, V.Undef, ((V)(y_371)))), "\" r=\"", ToStr(Call(f1_10, V.Undef, ((V)(r_372)))), "\" fill=\"#fffbe6\">", ToStr(Call(AN_26, V.Undef, ((V)("opacity")), ((V)("1;0.25;1")), ((V)(dd_373)), ((V)(((-ToNum(Call(Rs_361, V.Undef))) * dd_373))))), "</circle>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
s_270.S(string.Concat("<circle cx=\"620\" cy=\"-16\" r=\"46\" fill=\"url(#bzSun)\" opacity=\"0.5\"/>", "")).V(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(620D)), ((V)((-16D))), ((V)(17D))), ((V)("#fff8dc")))).V(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(628D)), ((V)((-21D))), ((V)(15D))), GetIdx(sk_258, 0D))).V(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(612D)), ((V)((-12D))), ((V)(2.4))), ((V)("#efe6c4")), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.7\""))));
} else {
if (!(Truthy(rainy_251))) {
s_270.S(string.Concat("<circle cx=\"630\" cy=\"-22\" r=\"60\" fill=\"url(#bzSun)\"/>", "")).V(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(630D)), ((V)((-22D))), ((V)(19D))), ((V)((Truthy(snowy_252) ? "#fffdf2" : "#fff4b8"))), ((V)("#ffe07a")), ((V)(1.4))));
}
}
cloud_271 = Fn((V _arrowThis385, int _argc374, V x_380, V y_381, V k_382, V c_383, V[] _rest375) => {
V op_384 = default;
op_384 = (_argc374 > 4 ? _rest375[0] : V.Undef);
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_10, V.Undef, x_380)), " ", ToStr(Call(f1_10, V.Undef, y_381)), ") scale(", ToStr(Call(n3_21, V.Undef, k_382)), ")\" opacity=\"", ToStr(op_384), "\">", ToStr(Call(P_24, V.Undef, ((V)("M-34 8C-46 8-48-6-36-8C-36-22-16-26-8-16C-2-30 22-28 24-12C40-14 44 6 30 8Z")), c_383, Call(mix_11, V.Undef, c_383, ((V)("#7a9ab0")), ((V)(0.35))), ((V)(1.2)))), ToStr(Call(P_24, V.Undef, ((V)("M-28 2C-24-6-14-6-10-2")), ((V)("none")), ((V)("#ffffff")), ((V)(1.4)), ((V)(" opacity=\"0.7\"")))), "</g>")));
}, 5, "", true);
CL_272 = (Truthy(rainy_251) ? 9D : (Truthy(snowy_252) ? 6D : 4D));
cc_273 = (Truthy(rainy_251) ? Call(NM_255, V.Undef, ((V)("#d6dce2")), ((V)(0.6))) : Call(NM_255, V.Undef, ((V)("#ffffff")), ((V)(0.6))));
Call(rep_20, V.Undef, ((V)(CL_272)), Fn((V _arrowThis393, int _argc386, V i_392, V _a389, V _a390, V _a391, V[] _rest387) => {
double y_394 = 0;
double k_395 = 0;
double dur_396 = 0;
double x0_397 = 0;
y_394 = ((-40D) + ((ToNum(i_392) * 23D) % 70D));
k_395 = (0.7 + ((ToNum(i_392) % 3D) * 0.3));
dur_396 = ((90D + (ToNum(i_392) * 23D)) / (Truthy(rainy_251) ? 1.6 : 1D));
x0_397 = (-80D);
s_270.S(string.Concat("<g>", ToStr(Call(AT_25, V.Undef, ((V)("translate")), ((V)(string.Concat(NumStr(x0_397), " 0;", NumStr(940D), " 0"))), ((V)(dur_396)), ((V)(((-dur_396) * ((ToNum(i_392) * 0.37) % 1D)))))), ToStr(Call(cloud_271, V.Undef, ((V)(0D)), ((V)(y_394)), ((V)((k_395 * (Truthy(rainy_251) ? 1.4 : 1D)))), cc_273, ((V)((Truthy(rainy_251) ? 0.95 : 0.9))))), "</g>"));
return default;
}, 1, "", true));
s_270.S(string.Concat("<g clip-path=\"url(#bzSeaC)\"><rect x=\"0\" y=\"50\" width=\"870\" height=\"350\" fill=\"url(#bzSea)\"/></g>", ""));
s_270.V(Call(P_24, V.Undef, ((V)("M688 56C700 44 716 40 730 44C742 34 764 36 776 46C790 46 800 52 806 56Z")), Call(NM_255, V.Undef, ((V)((Truthy(snowy_252) ? "#cfe0e4" : "#7fb87a"))), ((V)(0.6))), Call(NM_255, V.Undef, ((V)("#4f7a50")), ((V)(0.6))), ((V)(1D))));
s_270.S(string.Concat("<g>", ToStr(Call(P_24, V.Undef, Call(rr_30, V.Undef, ((V)(756D)), ((V)(22D)), ((V)(8D)), ((V)(26D)), ((V)(2D))), Call(NM_255, V.Undef, ((V)("#fffaf1")), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#7a6a5a")), ((V)(0.5))), ((V)(1D)))), ToStr(Call(P_24, V.Undef, ((V)("M756 30H764M756 38H764")), ((V)("none")), ((V)("#e2554a")), ((V)(2.6)))), ToStr(Call(P_24, V.Undef, ((V)("M754 22H766L760 15Z")), Call(NM_255, V.Undef, ((V)("#e2554a")), ((V)(0.4))), Call(NM_255, V.Undef, ((V)("#7a2a20")), ((V)(0.5))), ((V)(1D)))), ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(760D)), ((V)(19D)), ((V)(2.6))), ((V)((Truthy(nt_247) ? "#fff1a8" : "#fff8d8"))))), "</g>"));
if (Truthy(nt_247)) {
s_270.S(string.Concat("<g>", ToStr(Call(AT_25, V.Undef, ((V)("rotate")), ((V)("0 760 19;360 760 19")), ((V)(6D)))), "<path d=\"M760 19L860 4L860 34Z\" fill=\"#fff1a8\" opacity=\"0.22\"/></g><circle cx=\"760\" cy=\"19\" r=\"10\" fill=\"url(#bzGlow)\"/>"));
}
s_270.S(string.Concat("<g>", ToStr(Call(AT_25, V.Undef, ((V)("translate")), ((V)("400 0;900 0")), ((V)((110D * spd_257))), ((V)((-40D))))), "<g transform=\"translate(0 53)\">", ToStr(Call(P_24, V.Undef, ((V)("M-8 0H8L5 3H-5Z")), Call(NM_255, V.Undef, ((V)("#c4651f")), ((V)(0.5))))), ToStr(Call(P_24, V.Undef, ((V)("M0 -1V-14L7 -2Z")), Call(NM_255, V.Undef, ((V)("#ffffff")), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#b8c4cc")), ((V)(0.5))), ((V)(0.6)))), "</g></g>"));
s_270.S(string.Concat("<g clip-path=\"url(#bzSeaC)\">", ""));
s_270.V(Call(P_24, V.Undef, Call(shoreOff_266, V.Undef, ((V)(16D))), ((V)("none")), Call(NM_255, V.Undef, GetIdx(GetK(SEA_54, sea_246), 3D), ((V)(0.6))), ((V)(70D)), ((V)(" opacity=\"0.75\" filter=\"url(#bzB8)\""))));
s_270.S(string.Concat("<rect x=\"300\" y=\"60\" width=\"570\" height=\"340\" fill=\"url(#bzWv)\" opacity=\"", NumStr((Truthy(rainy_251) ? 0.45 : 0.28)), "\"/><rect x=\"300\" y=\"120\" width=\"570\" height=\"280\" fill=\"url(#bzWv2)\" opacity=\"", NumStr((Truthy(rainy_251) ? 0.4 : 0.22)), "\"/>"));
NCR_274 = (Truthy(rainy_251) ? 16D : 9D);
Call(rep_20, V.Undef, ((V)(NCR_274)), Fn((V _arrowThis405, int _argc398, V i_404, V _a401, V _a402, V _a403, V[] _rest399) => {
double y_406 = 0;
V xs_407 = default;
double k_408 = 0;
double dur_409 = 0;
y_406 = (70D + ((ToNum(i_404) * 61D) % 320D));
xs_407 = Add(Add(Call(shore_37, V.Undef, ((V)(y_406))), ((V)(40D))), ((V)(((ToNum(i_404) * 97D) % 260D))));
k_408 = (ToNum(Call(WY_16, V.Undef, ((V)(Max(100D, y_406))))) * (Truthy(rainy_251) ? 1.4 : 1D));
dur_409 = ((5D + (ToNum(i_404) % 4D)) * spd_257);
if (GtN(xs_407, 850D)) {
return default;
}
s_270.S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_10, V.Undef, xs_407)), " ", ToStr(Call(f1_10, V.Undef, ((V)(y_406)))), ") scale(", ToStr(Call(n3_21, V.Undef, ((V)(k_408)))), ")\"><g>", ToStr(Call(AT_25, V.Undef, ((V)("translate")), ((V)("0 0;-26 6")), ((V)(dur_409)), ((V)(((-ToNum(i_404)) * 0.9))))), ToStr(Call(P_24, V.Undef, ((V)("M-10 0Q-4 -5 2 -1Q6 1 10 -1")), ((V)("none")), ((V)("#ffffff")), ((V)(1.6)))), ToStr(Call(AN_26, V.Undef, ((V)("opacity")), ((V)("0;0.9;0")), ((V)(dur_409)), ((V)(((-ToNum(i_404)) * 0.9))))), "</g></g>"));
return default;
}, 1, "", true));
if (!(Truthy(rainy_251))) {
V Rg_410 = default;
Rg_410 = Call(rng_19, V.Undef, ((V)(JsStrBuf.Begin().S("glint").V(sea_246).End())));
Call(rep_20, V.Undef, ((V)((Truthy(sunny_253) ? 18D : 8D))), Fn((V _arrowThis418, int _argc411, V i_417, V _a414, V _a415, V _a416, V[] _rest412) => {
double y_419 = 0;
V x_420 = default;
double dd_421 = 0;
y_419 = (70D + (ToNum(Call(Rg_410, V.Undef)) * 310D));
x_420 = Add(Add(Call(shore_37, V.Undef, ((V)(y_419))), ((V)(30D))), ((V)((ToNum(Call(Rg_410, V.Undef)) * 380D))));
if (GtN(x_420, 850D)) {
return default;
}
dd_421 = (1.8 + (ToNum(Call(Rg_410, V.Undef)) * 2D));
s_270.S(string.Concat("<path d=\"M0 -3L0.6 -0.6L3 0L0.6 0.6L0 3L-0.6 0.6L-3 0L-0.6 -0.6Z\" fill=\"#ffffff\" transform=\"translate(", ToStr(Call(f1_10, V.Undef, x_420)), " ", ToStr(Call(f1_10, V.Undef, ((V)(y_419)))), ") scale(", ToStr(Call(n3_21, V.Undef, Add(((V)(0.8)), Call(Rg_410, V.Undef)))), ")\" opacity=\"0\">", ToStr(Call(AN_26, V.Undef, ((V)("opacity")), ((V)("0;0;1;0")), ((V)(dd_421)), ((V)(((-ToNum(Call(Rg_410, V.Undef))) * dd_421))))), "</path>"));
return default;
}, 1, "", true));
}
if (Truthy(nt_247)) {
s_270.V(Invoke(Call(rep_20, V.Undef, ((V)(14D)), Fn((V _arrowThis429, int _argc422, V i_428, V _a425, V _a426, V _a427, V[] _rest423) => {
double y_430 = 0;
double x_431 = 0;
double w_432 = 0;
y_430 = (70D + (ToNum(i_428) * 24D));
x_431 = ((600D + (FdLibm.Sin((ToNum(i_428) * 1.7)) * 10D)) + ((y_430 - 60D) * 0.3));
w_432 = (6D + ((ToNum(i_428) % 3D) * 4D));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_10, V.Undef, ((V)((x_431 - w_432))))), " ", ToStr(Call(f1_10, V.Undef, ((V)(y_430)))), "H", ToStr(Call(f1_10, V.Undef, ((V)((x_431 + w_432))))), "\" stroke=\"#fff6c8\" stroke-width=\"2\" stroke-linecap=\"round\" opacity=\"0.5\">", ToStr(Call(AN_26, V.Undef, ((V)("opacity")), ((V)("0.15;0.6;0.15")), ((V)((1.4 + ((ToNum(i_428) % 4D) * 0.3)))), ((V)(((-ToNum(i_428)) * 0.2))))), "</path>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
}
s_270.S(string.Concat("<g transform=\"translate(772 150)\"><g>", ToStr(Call(AT_25, V.Undef, ((V)("translate")), ((V)("0 0;0 -2.5;0 0")), ((V)((2.6 * spd_257))), ((V)(0D)), Call(SPL_27, V.Undef, ((V)(2D))))), ToStr(Call(P_24, V.Undef, Call(ell_29, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(9D)), ((V)(3D))), ((V)("none")), ((V)("#ffffff")), ((V)(1.2)), ((V)(" opacity=\"0.6\"")))), ToStr(Call(P_24, V.Undef, ((V)("M-6 4L-4 -10H4L6 4Z")), Call(NM_255, V.Undef, ((V)("#e2554a")), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#7a2a20")), ((V)(0.5))), ((V)(1D)))), ToStr(Call(P_24, V.Undef, ((V)("M-5 -3H5")), ((V)("none")), Call(NM_255, V.Undef, ((V)("#ffffff")), ((V)(0.5))), ((V)(2.4)))), ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(0D)), ((V)((-12D))), ((V)(2.4))), (Truthy(nt_247) ? ((V)("#ffd66b")) : Call(NM_255, V.Undef, ((V)("#ffe9a0")), ((V)(0.4)))))), "</g></g>"));
if (Truthy(nt_247)) {
s_270.S(string.Concat("<circle cx=\"772\" cy=\"138\" r=\"9\" fill=\"url(#bzGlow)\">", ToStr(Call(AN_26, V.Undef, ((V)("opacity")), ((V)("1;0.2;1")), ((V)(2D)))), "</circle>"));
}
s_270.S(string.Concat("</g>", ""));
s_270.V(Call(P_24, V.Undef, sandPoly_268, ((V)("url(#bzSand)"))));
s_270.S(string.Concat("<g clip-path=\"url(#bzSandC)\">", "")).V(Call(P_24, V.Undef, Call(shoreOff_266, V.Undef, ((V)((-12D)))), ((V)("none")), wetC_263, ((V)(30D)), ((V)(string.Concat(" opacity=\"", NumStr((Truthy(rainy_251) ? 0.7 : 0.5)), "\" filter=\"url(#bzB3)\"")))));
Rt_275 = Call(rng_19, V.Undef, ((V)(JsStrBuf.Begin().S("sand").N(st_248).End())));
Call(rep_20, V.Undef, ((V)(44D)), Fn((V _arrowThis440, int _argc433, V i_439, V _a436, V _a437, V _a438, V[] _rest434) => {
double y_441 = 0;
V x_442 = default;
V k_443 = default;
y_441 = (112D + (ToNum(Call(Rt_275, V.Undef)) * 280D));
x_442 = Add(Invoke(X_8, "edge", ((V)(y_441))), ((V)((ToNum(Call(Rt_275, V.Undef)) * (ToNum(Call(shore_37, V.Undef, ((V)(y_441)))) - ToNum(Invoke(X_8, "edge", ((V)(y_441)))))))));
k_443 = Call(WY_16, V.Undef, ((V)(y_441)));
s_270.V(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_442) - (7D * ToNum(k_443))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)(y_441)))), "q", ToStr(Call(f1_10, V.Undef, ((V)((7D * ToNum(k_443)))))), " ", ToStr(Call(f1_10, V.Undef, ((V)(((-3D) * ToNum(k_443)))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((14D * ToNum(k_443)))))), " 0"))), ((V)("none")), (NumTruthy((ToNum(i_439) % 2D)) ? sandL_262 : sandD_261), ((V)(1.1)), ((V)(" opacity=\"0.6\""))));
return default;
}, 1, "", true));
if ((st_248 == 1D)) {
Call(rep_20, V.Undef, ((V)(36D)), Fn((V _arrowThis451, int _argc444, V i_450, V _a447, V _a448, V _a449, V[] _rest445) => {
double y_452 = 0;
V x_453 = default;
V k_454 = default;
y_452 = (112D + (ToNum(Call(Rt_275, V.Undef)) * 280D));
x_453 = Add(Add(Invoke(X_8, "edge", ((V)(y_452))), ((V)(20D))), ((V)((ToNum(Call(Rt_275, V.Undef)) * ((ToNum(Call(shore_37, V.Undef, ((V)(y_452)))) - ToNum(Invoke(X_8, "edge", ((V)(y_452))))) - 30D)))));
k_454 = Call(WY_16, V.Undef, ((V)(y_452)));
s_270.V(Call(P_24, V.Undef, Call(ell_29, V.Undef, x_453, ((V)(y_452)), ((V)((2.4 * ToNum(k_454)))), ((V)((1.5 * ToNum(k_454))))), Call(NM_255, V.Undef, GetIdx(Arr(((V)("#9a948a")), ((V)("#b4ada0")), ((V)("#7f786e"))), (ToNum(i_450) % 3D)), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#5e584e")), ((V)(0.5))), ((V)(0.5))));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)(230D)), ((V)(300D))), Arr(((V)(420D)), ((V)(208D))), Arr(((V)(150D)), ((V)(250D)))), "forEach", Fn((V _arrowThis467, int _argc455, V _a457, V i_461, V _a459, V _a460, V[] _rest456) => {
V x_464 = default;
V y_466 = default;
{ V _t462 = ListOf(_a457);
{ V _t463 = GetIdx(_t462, 0D);
x_464 = _t463; }
{ V _t465 = GetIdx(_t462, 1D);
y_466 = _t465; }
}
return ((V)(s_270.V(Add(Call(P_24, V.Undef, ((V)(string.Concat("M", NumStr((ToNum(x_464) - 12D)), " ", ToStr(y_466), "q4 -6 8 -1t8 -2t8 1"))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#3f6a3a")), ((V)(0.5))), ((V)(2.4))), Call(P_24, V.Undef, ((V)(string.Concat("M", NumStr((ToNum(x_464) - 8D)), " ", ToStr(Add(y_466, ((V)(2D)))), "q5 -4 10 0"))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#5a8a44")), ((V)(0.5))), ((V)(1.6))))).Str));
}, 2, "", true));
s_270.S(string.Concat("<g transform=\"translate(330 330) rotate(-24)\">", ToStr(Call(P_24, V.Undef, Call(rr_30, V.Undef, ((V)((-7D))), ((V)((-4D))), ((V)(14D)), ((V)(8D)), ((V)(2D))), Call(NM_255, V.Undef, ((V)("#d84a3a")), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#7a2a20")), ((V)(0.5))), ((V)(1D)))), ToStr(Call(P_24, V.Undef, ((V)("M-7 -1.4H7")), ((V)("none")), Call(NM_255, V.Undef, ((V)("#ffffff")), ((V)(0.5))), ((V)(1.4)))), ToStr(Call(P_24, V.Undef, Call(ell_29, V.Undef, ((V)(7D)), ((V)(0D)), ((V)(1.2)), ((V)(4D))), Call(NM_255, V.Undef, ((V)("#c9cdd2")), ((V)(0.5))))), "</g>"));
} else {
if ((st_248 == 2D)) {
{
double r_468 = 0;
r_468 = 0D;
while (true) {
if (!((r_468 < 9D))) break;
double y0_470 = 0;
JsStrBuf dd_471 = null;
y0_470 = (150D + (r_468 * 24D));
dd_471 = new JsStrBuf("");
{
V x_472 = default;
x_472 = Add(Invoke(X_8, "edge", ((V)(y0_470))), ((V)(40D)));
while (true) {
if (!(LtN(x_472, (ToNum(Call(shore_37, V.Undef, ((V)(y0_470)))) - 30D)))) break;
dd_471.S((((dd_471.Str).Length != 0) ? "L" : "M")).V(Call(f1_10, V.Undef, x_472)).S(" ").V(Call(f1_10, V.Undef, ((V)((y0_470 + (FdLibm.Sin(((ToNum(x_472) * 0.04) + r_468)) * 2.2))))));
x_472 = Add(x_472, ((V)(12D)));
}
}
if (((dd_471.Str).Length != 0)) {
s_270.V(Call(P_24, V.Undef, ((V)(dd_471.Str)), ((V)("none")), sandD_261, ((V)(1.4)), ((V)(" opacity=\"0.5\""))));
}
r_468++;
}
}
} else {
if ((st_248 == 3D)) {
Call(rep_20, V.Undef, ((V)(70D)), Fn((V _arrowThis481, int _argc474, V i_480, V _a477, V _a478, V _a479, V[] _rest475) => {
double y_482 = 0;
V x_483 = default;
y_482 = (112D + (ToNum(Call(Rt_275, V.Undef)) * 280D));
x_483 = Add(Invoke(X_8, "edge", ((V)(y_482))), ((V)((ToNum(Call(Rt_275, V.Undef)) * (ToNum(Call(shore_37, V.Undef, ((V)(y_482)))) - ToNum(Invoke(X_8, "edge", ((V)(y_482)))))))));
s_270.V(Call(P_24, V.Undef, Call(circ_28, V.Undef, x_483, ((V)(y_482)), ((V)((0.8 + (ToNum(Call(Rt_275, V.Undef)) * 0.8))))), GetIdx(Arr(((V)("#ffffff")), ((V)("#ffd8cc")), ((V)("#fff4d8"))), (ToNum(i_480) % 3D)), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.9\""))));
return default;
}, 1, "", true));
} else {
if ((st_248 == 4D)) {
Call(rep_20, V.Undef, ((V)(34D)), Fn((V _arrowThis491, int _argc484, V i_490, V _a487, V _a488, V _a489, V[] _rest485) => {
double y_492 = 0;
V x_493 = default;
V k_494 = default;
y_492 = (112D + (ToNum(Call(Rt_275, V.Undef)) * 280D));
x_493 = Add(Invoke(X_8, "edge", ((V)(y_492))), ((V)((ToNum(Call(Rt_275, V.Undef)) * (ToNum(Call(shore_37, V.Undef, ((V)(y_492)))) - ToNum(Invoke(X_8, "edge", ((V)(y_492)))))))));
k_494 = Call(WY_16, V.Undef, ((V)(y_492)));
s_270.V(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, x_493)), " ", ToStr(Call(f1_10, V.Undef, ((V)((y_492 - (2D * ToNum(k_494))))))), "l", ToStr(Call(f1_10, V.Undef, ((V)((2.6 * ToNum(k_494)))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((1.2 * ToNum(k_494)))))), "l", ToStr(Call(f1_10, V.Undef, ((V)(((-0.8) * ToNum(k_494)))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((2.2 * ToNum(k_494)))))), "l", ToStr(Call(f1_10, V.Undef, ((V)(((-2.6) * ToNum(k_494)))))), " ", ToStr(Call(f1_10, V.Undef, ((V)(((-0.6) * ToNum(k_494)))))), "Z"))), Call(NM_255, V.Undef, GetIdx(Arr(((V)("#7fe0d0")), ((V)("#a6e8f6")), ((V)("#c4f0b0")), ((V)("#ff9db0"))), (ToNum(i_490) % 4D)), ((V)(0.5))), ((V)("#ffffff")), ((V)(0.5)), ((V)(" opacity=\"0.9\""))));
return default;
}, 1, "", true));
} else {
Call(rep_20, V.Undef, ((V)(46D)), Fn((V _arrowThis502, int _argc495, V i_501, V _a498, V _a499, V _a500, V[] _rest496) => {
double y_503 = 0;
V x_504 = default;
double dd_505 = 0;
y_503 = (112D + (ToNum(Call(Rt_275, V.Undef)) * 280D));
x_504 = Add(Invoke(X_8, "edge", ((V)(y_503))), ((V)((ToNum(Call(Rt_275, V.Undef)) * (ToNum(Call(shore_37, V.Undef, ((V)(y_503)))) - ToNum(Invoke(X_8, "edge", ((V)(y_503)))))))));
dd_505 = (1.4 + (ToNum(Call(Rt_275, V.Undef)) * 2D));
s_270.S(string.Concat("<path d=\"M0 -2.6L0.5 -0.5L2.6 0L0.5 0.5L0 2.6L-0.5 0.5L-2.6 0L-0.5 -0.5Z\" fill=\"", ToStr(GetIdx(Arr(((V)("#fff6c8")), ((V)("#ffffff")), ((V)("#ffe08a")), ((V)("#d8f6ff"))), (ToNum(i_501) % 4D))), "\" transform=\"translate(", ToStr(Call(f1_10, V.Undef, x_504)), " ", ToStr(Call(f1_10, V.Undef, ((V)(y_503)))), ")\" opacity=\"0\">", ToStr(Call(AN_26, V.Undef, ((V)("opacity")), ((V)("0;1;0;0")), ((V)(dd_505)), ((V)(((-ToNum(Call(Rt_275, V.Undef))) * dd_505))))), "</path>"));
return default;
}, 1, "", true));
}
}
}
}
if (Truthy(rainy_251)) {
Call(rep_20, V.Undef, ((V)(6D)), Fn((V _arrowThis513, int _argc506, V i_512, V _a509, V _a510, V _a511, V[] _rest507) => {
double y_514 = 0;
V x_515 = default;
V k_516 = default;
y_514 = (170D + (ToNum(i_512) * 30D));
x_515 = Add(Add(Invoke(X_8, "edge", ((V)(y_514))), ((V)(70D))), ((V)(((ToNum(i_512) * 131D) % Max(40D, ((ToNum(Call(shore_37, V.Undef, ((V)(y_514)))) - ToNum(Invoke(X_8, "edge", ((V)(y_514))))) - 150D))))));
k_516 = Call(WY_16, V.Undef, ((V)(y_514)));
s_270.V(Add(Add(Call(P_24, V.Undef, Call(ell_29, V.Undef, x_515, ((V)(y_514)), ((V)((26D * ToNum(k_516)))), ((V)((7D * ToNum(k_516))))), Call(NM_255, V.Undef, ((V)("#8fb0bc")), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#6a8a96")), ((V)(0.5))), ((V)(1D)), ((V)(" opacity=\"0.85\""))), Call(P_24, V.Undef, Call(ell_29, V.Undef, ((V)((ToNum(x_515) - (6D * ToNum(k_516))))), ((V)((y_514 - (2D * ToNum(k_516))))), ((V)((10D * ToNum(k_516)))), ((V)((2D * ToNum(k_516))))), ((V)("#ffffff")), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.4\"")))), Invoke(Call(rep_20, V.Undef, ((V)(2D)), Fn((V _arrowThis524, int _argc517, V j_523, V _a520, V _a521, V _a522, V[] _rest518) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_10, V.Undef, Add(x_515, ((V)(((Truthy(j_523) ? 8D : (-6D)) * ToNum(k_516))))))), "\" cy=\"", ToStr(Call(f1_10, V.Undef, ((V)(y_514)))), "\" rx=\"1\" ry=\"0.4\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.8\"><animate attributeName=\"rx\" values=\"1;", ToStr(Call(f1_10, V.Undef, ((V)((9D * ToNum(k_516)))))), "\" dur=\"1.2s\" begin=\"", ToStr(Call(n3_21, V.Undef, ((V)((((-ToNum(j_523)) * 0.6) - (ToNum(i_512) * 0.2)))))), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"ry\" values=\"0.4;", ToStr(Call(f1_10, V.Undef, ((V)((3D * ToNum(k_516)))))), "\" dur=\"1.2s\" begin=\"", ToStr(Call(n3_21, V.Undef, ((V)((((-ToNum(j_523)) * 0.6) - (ToNum(i_512) * 0.2)))))), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.9;0\" dur=\"1.2s\" begin=\"", ToStr(Call(n3_21, V.Undef, ((V)((((-ToNum(j_523)) * 0.6) - (ToNum(i_512) * 0.2)))))), "s\" repeatCount=\"indefinite\"/></ellipse>")));
}, 1, "", true)), "join", ((V)("")))));
return default;
}, 1, "", true));
}
if (Truthy(snowy_252)) {
V Rn_525 = default;
Rn_525 = Call(rng_19, V.Undef, ((V)("snowp")));
Call(rep_20, V.Undef, ((V)(16D)), Fn((V _arrowThis533, int _argc526, V i_532, V _a529, V _a530, V _a531, V[] _rest527) => {
double y_534 = 0;
V x_535 = default;
V k_536 = default;
y_534 = (130D + (ToNum(Call(Rn_525, V.Undef)) * 260D));
x_535 = Add(Invoke(X_8, "edge", ((V)(y_534))), ((V)((ToNum(Call(Rn_525, V.Undef)) * (ToNum(Call(shore_37, V.Undef, ((V)(y_534)))) - ToNum(Invoke(X_8, "edge", ((V)(y_534)))))))));
k_536 = Call(WY_16, V.Undef, ((V)(y_534)));
s_270.V(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_535) - (22D * ToNum(k_536))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)(y_534)))), "C", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_535) - (18D * ToNum(k_536))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((y_534 - (8D * ToNum(k_536))))))), " ", ToStr(Call(f1_10, V.Undef, Add(x_535, ((V)((14D * ToNum(k_536))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((y_534 - (9D * ToNum(k_536))))))), " ", ToStr(Call(f1_10, V.Undef, Add(x_535, ((V)((24D * ToNum(k_536))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)(y_534)))), "C", ToStr(Call(f1_10, V.Undef, Add(x_535, ((V)((10D * ToNum(k_536))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((y_534 + (6D * ToNum(k_536))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_535) - (12D * ToNum(k_536))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((y_534 + (5D * ToNum(k_536))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_535) - (22D * ToNum(k_536))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)(y_534)))), "Z"))), Call(NM_255, V.Undef, ((V)("#ffffff")), ((V)(0.45))), Call(NM_255, V.Undef, ((V)("#cfdde6")), ((V)(0.5))), ((V)(0.8)), ((V)(" opacity=\"0.92\""))));
return default;
}, 1, "", true));
}
s_270.S(string.Concat("</g>", ""));
if (Truthy(snowy_252)) {
V IC_537 = default;
IC_537 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Invoke(SH_264, "filter", Fn((V _arrowThis553, int _argc546, V q_552, V _a549, V _a550, V _a551, V[] _rest547) => {
return (GeN(GetIdx(q_552, 1D), 90D) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis545, int _argc538, V q_544, V _a541, V _a542, V _a543, V[] _rest539) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_10, V.Undef, ((V)((ToNum(GetIdx(q_544, 0D)) - 4D))))).S(" ").V(Call(f1_10, V.Undef, GetIdx(q_544, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("L").V(Invoke(Invoke(Invoke(Invoke(SH_264, "filter", Fn((V _arrowThis569, int _argc562, V q_568, V _a565, V _a566, V _a567, V[] _rest563) => {
return (GeN(GetIdx(q_568, 1D), 90D) ? V.True : V.False);
}, 1, "", true)), "reverse"), "map", Fn((V _arrowThis561, int _argc554, V q_560, V _a557, V _a558, V _a559, V[] _rest555) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_10, V.Undef, Add(Add(GetIdx(q_560, 0D), ((V)((icew_256 * ToNum(Call(WY_16, V.Undef, GetIdx(q_560, 1D))))))), ((V)((FdLibm.Sin((ToNum(GetIdx(q_560, 1D)) * 0.08)) * 6D)))))).S(" ").V(Call(f1_10, V.Undef, GetIdx(q_560, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
s_270.V(Add(Add(Call(P_24, V.Undef, IC_537, Call(NM_255, V.Undef, ((V)("#e6f6fb")), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#a8d8ea")), ((V)(0.5))), ((V)(2D)), ((V)(" opacity=\"0.95\""))), Invoke(Call(rep_20, V.Undef, ((V)(9D)), Fn((V _arrowThis577, int _argc570, V i_576, V _a573, V _a574, V _a575, V[] _rest571) => {
double y_578 = 0;
V x_579 = default;
y_578 = (120D + (ToNum(i_576) * 30D));
x_579 = Add(Add(Call(shore_37, V.Undef, ((V)(y_578))), ((V)(12D))), ((V)(((ToNum(i_576) % 3D) * 12D))));
return Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, x_579)), " ", ToStr(Call(f1_10, V.Undef, ((V)(y_578)))), "l9 4l-3 8l10 5"))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#a8cfe0")), ((V)(0.5))), ((V)(1D)));
return default;
}, 1, "", true)), "join", ((V)("")))), Call(P_24, V.Undef, Call(shoreOff_266, V.Undef, ((V)(icew_256))), ((V)("none")), ((V)("#ffffff")), ((V)(2D)), ((V)(" opacity=\"0.8\"")))));
}
fo_276 = (Truthy(snowy_252) ? icew_256 : 0D);
fd_277 = (4.2 * spd_257);
Invoke(Arr(Arr(((V)(2D)), ((V)(0D)), ((V)(3.6)), ((V)(0.95))), Arr(((V)(16D)), ((V)(((-fd_277) / 2D))), ((V)(2.2)), ((V)(0.6)))), "forEach", Fn((V _arrowThis595, int _argc580, V _a582, V _a583, V _a584, V _a585, V[] _rest581) => {
V dx_588 = default;
V b_590 = default;
V w_592 = default;
V op_594 = default;
{ V _t586 = ListOf(_a582);
{ V _t587 = GetIdx(_t586, 0D);
dx_588 = _t587; }
{ V _t589 = GetIdx(_t586, 1D);
b_590 = _t589; }
{ V _t591 = GetIdx(_t586, 2D);
w_592 = _t591; }
{ V _t593 = GetIdx(_t586, 3D);
op_594 = _t593; }
}
return ((V)(s_270.S(string.Concat("<g>", ToStr(Call(AT_25, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;", ToStr(Call(f1_10, V.Undef, ((V)(((-8D) * (Truthy(rainy_251) ? 1.6 : 1D)))))), " 1;0 0"))), ((V)(fd_277)), b_590, Call(SPL_27, V.Undef, ((V)(2D))))), "<path d=\"", ToStr(Call(shoreOff_266, V.Undef, Add(((V)(fo_276)), dx_588))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"", ToStr(w_592), "\" stroke-linecap=\"round\" stroke-dasharray=\"", (Truthy(rainy_251) ? "18 6" : "26 10"), "\" opacity=\"", ToStr(op_594), "\">", ToStr(Call(AN_26, V.Undef, ((V)("opacity")), ((V)(string.Concat(ToStr(op_594), ";", ToStr(Call(n3_21, V.Undef, ((V)((ToNum(op_594) * 0.4))))), ";", ToStr(op_594)))), ((V)(fd_277)), b_590)), "</path></g>")).Str));
}, 1, "", true));
if ((lt_250 == 5D)) {
s_270.S(string.Concat("<g>", ToStr(Call(AT_25, V.Undef, ((V)("translate")), ((V)("0 0;-8 1;0 0")), ((V)(fd_277)), ((V)(0D)), Call(SPL_27, V.Undef, ((V)(2D))))), "<path d=\"", ToStr(Call(shoreOff_266, V.Undef, ((V)((fo_276 + 4D))))), "\" fill=\"none\" stroke=\"#7af6ff\" stroke-width=\"", NumStr((Truthy(nt_247) ? 6D : 3D)), "\" stroke-linecap=\"round\" stroke-dasharray=\"3 9\" opacity=\"", NumStr((Truthy(nt_247) ? 0.95 : 0.5)), "\">", ToStr(Call(AN_26, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-24")), ((V)(3D)))), "</path><path d=\"", ToStr(Call(shoreOff_266, V.Undef, ((V)((fo_276 + 4D))))), "\" fill=\"none\" stroke=\"#4fe0f0\" stroke-width=\"", NumStr((Truthy(nt_247) ? 18D : 8D)), "\" opacity=\"", NumStr((Truthy(nt_247) ? 0.35 : 0.15)), "\" filter=\"url(#bzB3)\"/></g>"));
}
s_270.V(Call(P_24, V.Undef, ((V)("M-20 60C40 30 110 22 170 34C230 46 290 20 360 30C400 36 430 46 452 60L-20 60Z")), ((V)("url(#bzDune2)"))));
palm_278 = Fn((V _arrowThis607, int _argc596, V x_602, V y_603, V k_604, V lean_605, V[] _rest597) => {
V tx_608 = default;
double ty_609 = 0;
JsStrBuf fr_610 = null;
V ph_606 = default;
ph_606 = (_argc596 > 4 ? _rest597[0] : V.Undef);
tx_608 = Add(x_602, ((V)(((ToNum(lean_605) * 40D) * ToNum(k_604)))));
ty_609 = (ToNum(y_603) - (90D * ToNum(k_604)));
fr_610 = new JsStrBuf("");
Call(rep_20, V.Undef, ((V)(7D)), Fn((V _arrowThis618, int _argc611, V i_617, V _a614, V _a615, V _a616, V[] _rest612) => {
double a_619 = 0;
double L_620 = 0;
V ex_621 = default;
double ey_622 = 0;
V mx_623 = default;
double my_624 = 0;
a_619 = ((((-PI_14) * 0.95) + ((ToNum(i_617) * PI_14) * 0.32)) + ((ToNum(i_617) % 2D) * 0.1));
L_620 = ((36D + ((ToNum(i_617) % 3D) * 6D)) * ToNum(k_604));
ex_621 = Add(tx_608, ((V)((FdLibm.Cos(a_619) * L_620))));
ey_622 = ((ty_609 + ((FdLibm.Sin(a_619) * L_620) * 0.62)) + (L_620 * 0.28));
mx_623 = Add(tx_608, ((V)(((FdLibm.Cos(a_619) * L_620) * 0.5))));
my_624 = ((ty_609 + ((FdLibm.Sin(a_619) * L_620) * 0.5)) - (8D * ToNum(k_604)));
fr_610.V(Add(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, tx_608)), " ", ToStr(Call(f1_10, V.Undef, ((V)(ty_609)))), "Q", ToStr(Call(f1_10, V.Undef, mx_623)), " ", ToStr(Call(f1_10, V.Undef, ((V)(my_624)))), " ", ToStr(Call(f1_10, V.Undef, ex_621)), " ", ToStr(Call(f1_10, V.Undef, ((V)(ey_622)))), "Q", ToStr(Call(f1_10, V.Undef, Add(mx_623, ((V)((4D * ToNum(k_604))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((my_624 + (6D * ToNum(k_604))))))), " ", ToStr(Call(f1_10, V.Undef, tx_608)), " ", ToStr(Call(f1_10, V.Undef, ((V)((ty_609 + (2D * ToNum(k_604))))))), "Z"))), Call(NM_255, V.Undef, ((V)((NumTruthy((ToNum(i_617) % 2D)) ? "#3f9a42" : "#4fb04a"))), ((V)(0.55))), Call(NM_255, V.Undef, ((V)("#22602a")), ((V)(0.55))), ((V)(1.1))), (Truthy(snowy_252) ? Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, tx_608)), " ", ToStr(Call(f1_10, V.Undef, ((V)(ty_609)))), "Q", ToStr(Call(f1_10, V.Undef, mx_623)), " ", ToStr(Call(f1_10, V.Undef, ((V)(my_624)))), " ", ToStr(Call(f1_10, V.Undef, ex_621)), " ", ToStr(Call(f1_10, V.Undef, ((V)(ey_622))))))), ((V)("none")), ((V)("#ffffff")), ((V)((2.2 * ToNum(k_604)))), ((V)(" opacity=\"0.85\""))) : ((V)("")))));
return default;
}, 1, "", true));
return ((V)(string.Concat("<g>", ToStr(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_602) - (5D * ToNum(k_604))))))), " ", ToStr(Call(f1_10, V.Undef, y_603)), "Q", ToStr(Call(f1_10, V.Undef, Add(x_602, ((V)(((ToNum(lean_605) * 10D) * ToNum(k_604))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(y_603) - (50D * ToNum(k_604))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(tx_608) - (2D * ToNum(k_604))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)(ty_609)))), "L", ToStr(Call(f1_10, V.Undef, Add(tx_608, ((V)((3D * ToNum(k_604))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)(ty_609)))), "Q", ToStr(Call(f1_10, V.Undef, Add(Add(x_602, ((V)(((ToNum(lean_605) * 14D) * ToNum(k_604))))), ((V)((6D * ToNum(k_604))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(y_603) - (50D * ToNum(k_604))))))), " ", ToStr(Call(f1_10, V.Undef, Add(x_602, ((V)((5D * ToNum(k_604))))))), " ", ToStr(Call(f1_10, V.Undef, y_603)), "Z"))), Call(NM_255, V.Undef, ((V)("#b07a44")), ((V)(0.55))), Call(NM_255, V.Undef, ((V)("#5e3c1c")), ((V)(0.55))), ((V)(1.2)))), ToStr(Invoke(Call(rep_20, V.Undef, ((V)(6D)), Fn((V _arrowThis632, int _argc625, V i_631, V _a628, V _a629, V _a630, V[] _rest626) => {
double t_633 = 0;
V cx_634 = default;
t_633 = (ToNum(Add(i_631, ((V)(1D)))) / 7D);
cx_634 = Add(Add(x_602, ((V)(((((ToNum(tx_608) - ToNum(x_602)) * t_633) * t_633) * 0.9)))), ((V)((((ToNum(lean_605) * 4D) * ToNum(k_604)) * t_633))));
return Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(cx_634) - (4.5 * ToNum(k_604))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(y_603) - ((ToNum(y_603) - ty_609) * t_633)))))), "h", ToStr(Call(f1_10, V.Undef, ((V)((9D * ToNum(k_604))))))))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#7a4e24")), ((V)(0.55))), ((V)(1D)));
return default;
}, 1, "", true)), "join", ((V)("")))), "<g>", ToStr(Call(AT_25, V.Undef, ((V)("rotate")), ((V)(string.Concat("-2.5 ", ToStr(Call(f1_10, V.Undef, tx_608)), " ", ToStr(Call(f1_10, V.Undef, ((V)(ty_609)))), ";2.5 ", ToStr(Call(f1_10, V.Undef, tx_608)), " ", ToStr(Call(f1_10, V.Undef, ((V)(ty_609)))), ";-2.5 ", ToStr(Call(f1_10, V.Undef, tx_608)), " ", ToStr(Call(f1_10, V.Undef, ((V)(ty_609))))))), ((V)((5D * (Truthy(rainy_251) ? 0.5 : 1D)))), ph_606, Call(SPL_27, V.Undef, ((V)(2D))))), fr_610.Str, ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)((ToNum(tx_608) - (3D * ToNum(k_604))))), ((V)((ty_609 + (4D * ToNum(k_604))))), ((V)((3.4 * ToNum(k_604))))), Call(NM_255, V.Undef, ((V)("#7a4e24")), ((V)(0.5))))), ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, Add(tx_608, ((V)((3D * ToNum(k_604))))), ((V)((ty_609 + (5D * ToNum(k_604))))), ((V)((3.4 * ToNum(k_604))))), Call(NM_255, V.Undef, ((V)("#8a5a2c")), ((V)(0.5))))), "</g></g>")));
return default;
}, 5, "", true);
s_270.V(Add(Add(Call(palm_278, V.Undef, ((V)(70D)), ((V)(50D)), ((V)(0.62)), ((V)(0.5)), ((V)(0D))), Call(palm_278, V.Undef, ((V)(196D)), ((V)(40D)), ((V)(0.5)), ((V)((-0.4))), ((V)((-1.4))))), Call(palm_278, V.Undef, ((V)(318D)), ((V)(44D)), ((V)(0.56)), ((V)(0.6)), ((V)((-2.6))))));
DF_279 = ((V)("M-20 272L0 262Q44 180 96 94Q250 80 480 86Q520 80 540 64L540 54C490 42 400 40 330 46C270 54 230 30 170 40C110 50 70 30 30 46C10 54 -6 70 -20 84Z"));
s_270.V(Call(P_24, V.Undef, DF_279, ((V)("url(#bzDune)")), Call(NM_255, V.Undef, Call(shade_12, V.Undef, sand_260, ((V)(0.72))), ((V)(0.3))), ((V)(1.6))));
s_270.V(Call(P_24, V.Undef, ((V)("M-10 250Q38 172 90 100Q240 86 470 92")), ((V)("none")), Call(NM_255, V.Undef, Call(shade_12, V.Undef, sand_260, ((V)(0.8))), ((V)(0.3))), ((V)(10D)), ((V)(" opacity=\"0.35\" filter=\"url(#bzB3)\""))));
if (Truthy(snowy_252)) {
s_270.V(Call(P_24, V.Undef, ((V)("M-20 84C-6 70 10 54 30 46C70 30 110 50 170 40C230 30 270 54 330 46C380 40 430 44 470 54L466 62C420 54 380 50 330 56C270 64 230 40 170 50C110 60 70 40 34 56C14 64 0 80 -20 96Z")), Call(NM_255, V.Undef, ((V)("#ffffff")), ((V)(0.45))), Call(NM_255, V.Undef, ((V)("#cfdde6")), ((V)(0.5))), ((V)(1D))));
}
g_280 = Call(gate_50, V.Undef, ((V)("L")), (Get(o_245, "gateLock") is var _t635 && Truthy(_t635) ? _t635 : ((V)(0D))), ((V)("BACKYARD")));
s_270.V(Add(Add(Call(P_24, V.Undef, ((V)("M18 236Q60 230 110 226L140 214Q80 210 44 196Z")), Call(mix_11, V.Undef, sand_260, ((V)("#ffffff")), ((V)(0.18))), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.8\""))), Call(polySvg_51, V.Undef, Get(g_280, "polys"))), Invoke(Invoke(Get(g_280, "texts"), "map", textSvg_52), "join", ((V)("")))));
PR_281 = GetIdx(PIERS_57, (pt_249 - 1D));
X0_282 = Get(PIER_38, "x0");
Y0_283 = Get(PIER_38, "y0");
Y1_284 = Get(PIER_38, "y1");
XE_285 = Get(PIER_38, "xe");
Q0_286 = Get(PIER_38, "py0");
Q1_287 = Get(PIER_38, "py1");
XP_288 = Get(PIER_38, "xp1");
FC_289 = Get(PIER_38, "face");
pa_290 = Call(NM_255, V.Undef, Get(PR_281, "a"), ((V)(0.5)));
pb_291 = Call(NM_255, V.Undef, Get(PR_281, "b"), ((V)(0.5)));
pe_292 = Call(NM_255, V.Undef, Get(PR_281, "e"), ((V)(0.5)));
pf_293 = Call(NM_255, V.Undef, Get(PR_281, "face"), ((V)(0.5)));
pp_294 = Call(NM_255, V.Undef, Get(PR_281, "post"), ((V)(0.5)));
s_270.V(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Add(X0_282, ((V)(30D)))), " ", ToStr(Add(Y1_284, FC_289)), "H", ToStr(XE_285), "V", ToStr(Add(Q1_287, FC_289)), "H", ToStr(Add(XP_288, ((V)(6D)))), "L", ToStr(Add(XP_288, ((V)(10D)))), " ", ToStr(Add(Add(Q1_287, FC_289), ((V)(12D)))), "H", ToStr(Add(X0_282, ((V)(40D)))), "Z"))), ((V)("#06324a")), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.22\" filter=\"url(#bzB3)\""))));
Call(rep_20, V.Undef, ((V)((System.Math.Floor((((ToNum(XP_288) - ToNum(X0_282)) - 40D) / 44D)) + 1D))), Fn((V _arrowThis643, int _argc636, V i_642, V _a639, V _a640, V _a641, V[] _rest637) => {
V x_644 = default;
V yb_645 = default;
double crook_646 = 0;
x_644 = Add(Add(X0_282, ((V)(44D))), ((V)((ToNum(i_642) * 44D))));
yb_645 = (Gt(x_644, XE_285) ? Q1_287 : Y1_284);
if (Gt(x_644, XP_288)) {
return default;
}
crook_646 = ((pt_249 == 1D) ? (NumTruthy((ToNum(i_642) % 2D)) ? 2D : (-1.5)) : 0D);
s_270.V(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_644) - 3D))))), " ", ToStr(yb_645), "L", ToStr(Call(f1_10, V.Undef, ((V)(((ToNum(x_644) - 3D) + crook_646))))), " ", ToStr(Add(Add(yb_645, FC_289), ((V)(13D)))), "H", ToStr(Call(f1_10, V.Undef, Add(Add(x_644, ((V)(3D))), ((V)(crook_646))))), "L", ToStr(Call(f1_10, V.Undef, Add(x_644, ((V)(3D))))), " ", ToStr(yb_645), "Z"))), pp_294, Call(NM_255, V.Undef, ((V)("#2a1c10")), ((V)(0.5))), ((V)(1D)))).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_10, V.Undef, Add(x_644, ((V)(crook_646))))), "\" cy=\"", ToStr(Add(Add(yb_645, FC_289), ((V)(13D)))), "\" rx=\"5\" ry=\"1.6\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1\" opacity=\"0.7\">", ToStr(Call(AN_26, V.Undef, ((V)("rx")), ((V)("4;8;4")), ((V)((2.4 * spd_257))), ((V)(((-ToNum(i_642)) * 0.3))))), "</ellipse>"));
return default;
}, 1, "", true));
s_270.V(Add(Add(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(X0_282), " ", ToStr(Y1_284), "H", ToStr(XE_285), "V", ToStr(Add(Y1_284, FC_289)), "H", ToStr(Add(X0_282, ((V)(8D)))), "Z"))), pf_293, pe_292, ((V)(1.2))), Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(XE_285), " ", ToStr(Q1_287), "H", ToStr(XP_288), "V", ToStr(Add(Q1_287, FC_289)), "H", ToStr(XE_285), "Z"))), pf_293, pe_292, ((V)(1.2)))), Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(XP_288), " ", ToStr(Q0_286), "L", ToStr(Add(XP_288, ((V)(6D)))), " ", ToStr(Add(Q0_286, ((V)(8D)))), "V", ToStr(Add(Add(Q1_287, FC_289), ((V)(6D)))), "L", ToStr(XP_288), " ", ToStr(Add(Q1_287, FC_289)), "Z"))), Call(shade_12, V.Undef, pf_293, ((V)(0.82))), pe_292, ((V)(1.2)))));
if (Truthy(snowy_252)) {
s_270.V(Invoke(Call(rep_20, V.Undef, ((V)(14D)), Fn((V _arrowThis654, int _argc647, V i_653, V _a650, V _a651, V _a652, V[] _rest648) => {
V x_655 = default;
x_655 = Add(Add(X0_282, ((V)(30D))), ((V)((ToNum(i_653) * 21D))));
return Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(x_655), " ", ToStr((Gt(x_655, XE_285) ? Add(Q1_287, FC_289) : Add(Y1_284, FC_289))), "l2 ", NumStr((6D + ((ToNum(i_653) % 3D) * 3D))), "l2 ", NumStr((-(6D + ((ToNum(i_653) % 3D) * 3D)))), "Z"))), ((V)("#eaf8ff")), ((V)("#b8dcec")), ((V)(0.6)));
return default;
}, 1, "", true)), "join", ((V)(""))));
}
s_270.V(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Add(X0_282, ((V)(6D)))), " ", ToStr(Y0_283), "H", ToStr(XE_285), "V", ToStr(Q0_286), "H", ToStr(XP_288), "V", ToStr(Q1_287), "H", ToStr(XE_285), "V", ToStr(Y1_284), "H", ToStr(X0_282), "Z"))), pa_290, pe_292, ((V)(1.6))));
pl_295 = new JsStrBuf("");
{
V x_656 = default;
x_656 = Add(X0_282, ((V)(14D)));
while (true) {
if (!(LtN(x_656, (ToNum(XP_288) - 2D)))) break;
V top_658 = default;
V bot_659 = default;
top_658 = (Gt(x_656, XE_285) ? Q0_286 : Y0_283);
bot_659 = (Gt(x_656, XE_285) ? Q1_287 : Y1_284);
pl_295.S(string.Concat("M", ToStr(Call(f1_10, V.Undef, x_656)), " ", ToStr(Add(top_658, ((V)(1D)))), "L", ToStr(Call(f1_10, V.Undef, x_656)), " ", NumStr((ToNum(bot_659) - 1D))));
x_656 = Add(x_656, ((V)(9D)));
}
}
s_270.V(Call(P_24, V.Undef, ((V)(pl_295.Str)), ((V)("none")), pe_292, ((V)(0.8)), ((V)(" opacity=\"0.55\""))));
{
V x_660 = default;
double j_661 = 0;
x_660 = Add(X0_282, ((V)(18D)));
j_661 = 0D;
while (true) {
if (!(LtN(x_660, (ToNum(XP_288) - 4D)))) break;
if (NumTruthy((j_661 % 2D))) {
s_270.V(Call(P_24, V.Undef, Call(rr_30, V.Undef, ((V)((ToNum(x_660) - 8D))), (Gt(x_660, XE_285) ? Add(Q0_286, ((V)(2D))) : Add(Y0_283, ((V)(2D)))), ((V)(8D)), ((V)(((Gt(x_660, XE_285) ? (ToNum(Q1_287) - ToNum(Q0_286)) : (ToNum(Y1_284) - ToNum(Y0_283))) - 4D))), ((V)(0.5))), pb_291, ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.8\""))));
}
x_660 = Add(x_660, ((V)(18D)));
j_661++;
}
}
if ((pt_249 == 1D)) {
Invoke(Arr(Arr(Add(X0_282, ((V)(120D))), ((V)(0D))), Arr(Add(X0_282, ((V)(174D))), ((V)(1D))), Arr(Add(XE_285, ((V)(30D))), ((V)(2D)))), "forEach", Fn((V _arrowThis674, int _argc663, V _a665, V _a666, V _a667, V _a668, V[] _rest664) => {
V top_675 = default;
V bot_676 = default;
V x_671 = default;
V j_673 = default;
{ V _t669 = ListOf(_a665);
{ V _t670 = GetIdx(_t669, 0D);
x_671 = _t670; }
{ V _t672 = GetIdx(_t669, 1D);
j_673 = _t672; }
}
top_675 = (Gt(x_671, XE_285) ? Q0_286 : Y0_283);
bot_676 = (Gt(x_671, XE_285) ? Q1_287 : Y1_284);
s_270.V(Call(P_24, V.Undef, Call(rr_30, V.Undef, x_671, Add(top_675, ((V)((SEqN(j_673, 1D) ? 8D : 1D)))), ((V)(8D)), ((V)(((ToNum(bot_676) - ToNum(top_675)) - (SEqN(j_673, 1D) ? 9D : 2D)))), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#1a5a7a")), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#3a3020")), ((V)(0.5))), ((V)(0.8))));
return default;
}, 1, "", true));
}
if (Truthy(snowy_252)) {
s_270.V(Add(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Add(X0_282, ((V)(8D)))), " ", ToStr(Add(Y0_283, ((V)(2D)))), "H", ToStr(XE_285), "V", ToStr(Add(Q0_286, ((V)(2D)))), "H", NumStr((ToNum(XP_288) - 2D))))), ((V)("none")), ((V)("#ffffff")), ((V)(3D)), ((V)(" opacity=\"0.85\""))), Invoke(Call(rep_20, V.Undef, ((V)(8D)), Fn((V _arrowThis684, int _argc677, V i_683, V _a680, V _a681, V _a682, V[] _rest678) => {
return Call(P_24, V.Undef, Call(ell_29, V.Undef, Add(Add(X0_282, ((V)(40D))), ((V)((ToNum(i_683) * 36D)))), (NumTruthy((ToNum(i_683) % 2D)) ? Add(Y0_283, ((V)(6D))) : ((V)((ToNum(Y1_284) - 5D)))), ((V)(7D)), ((V)(2D))), ((V)("#ffffff")), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.75\"")));
}, 1, "", true)), "join", ((V)("")))));
}
railPosts_296 = Arr();
{
V x_685 = default;
x_685 = Add(X0_282, ((V)(24D)));
while (true) {
if (!(Le(x_685, XE_285))) break;
Invoke(railPosts_296, "push", Arr(x_685, Y0_283));
x_685 = Add(x_685, ((V)(36D)));
}
}
Invoke(railPosts_296, "push", Arr(XE_285, Q0_286), Arr(Add(XE_285, ((V)(43D))), Q0_286), Arr(((V)((ToNum(XP_288) - 2D))), Q0_286));
if (SEqS(Get(PR_281, "rail"), "rope")) {
JsStrBuf rp_687 = null;
Invoke(railPosts_296, "forEach", Fn((V _arrowThis699, int _argc688, V _a690, V _a691, V _a692, V _a693, V[] _rest689) => {
V x_696 = default;
V y_698 = default;
{ V _t694 = ListOf(_a690);
{ V _t695 = GetIdx(_t694, 0D);
x_696 = _t695; }
{ V _t697 = GetIdx(_t694, 1D);
y_698 = _t697; }
}
return ((V)(s_270.V(Call(P_24, V.Undef, Call(rr_30, V.Undef, ((V)((ToNum(x_696) - 1.8))), ((V)((ToNum(y_698) - 16D))), ((V)(3.6)), ((V)(16D)), ((V)(1D))), pp_294, Call(NM_255, V.Undef, ((V)("#3a2614")), ((V)(0.5))), ((V)(0.8)))).Str));
}, 1, "", true));
rp_687 = new JsStrBuf("");
{
double i_700 = 0;
i_700 = 0D;
while (true) {
if (!((i_700 < (ToNum(Get(railPosts_296, "length")) - 1D)))) break;
V a_702 = default;
V b_703 = default;
a_702 = GetIdx(railPosts_296, i_700);
b_703 = GetIdx(railPosts_296, (i_700 + 1D));
rp_687.S(string.Concat("M", ToStr(GetIdx(a_702, 0D)), " ", NumStr((ToNum(GetIdx(a_702, 1D)) - 13D)), "Q", NumStr((ToNum(Add(GetIdx(a_702, 0D), GetIdx(b_703, 0D))) / 2D)), " ", NumStr(((ToNum(Add(GetIdx(a_702, 1D), GetIdx(b_703, 1D))) / 2D) - 7D)), " ", ToStr(GetIdx(b_703, 0D)), " ", NumStr((ToNum(GetIdx(b_703, 1D)) - 13D))));
i_700++;
}
}
s_270.V(Call(P_24, V.Undef, ((V)(rp_687.Str)), ((V)("none")), Call(NM_255, V.Undef, ((V)("#e2c890")), ((V)(0.5))), ((V)(1.8))));
s_270.S(string.Concat("<g transform=\"translate(", NumStr((ToNum(XP_288) - 14D)), " ", NumStr((ToNum(Q0_286) - 6D)), ")\">", ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(7D))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#e2554a")), ((V)(0.45))), ((V)(3.4)))), ToStr(Call(P_24, V.Undef, ((V)("M-7 0H-4M4 0H7M0 -7V-4M0 4V7")), ((V)("none")), Call(NM_255, V.Undef, ((V)("#ffffff")), ((V)(0.45))), ((V)(3.4)))), "</g>"));
} else {
if (Truthy(Get(PR_281, "rail"))) {
V rc_704 = default;
V ro_705 = default;
double ht_706 = 0;
JsStrBuf bal_707 = null;
rc_704 = Call(NM_255, V.Undef, ((V)((SEqS(Get(PR_281, "rail"), "white") ? "#ffffff" : (SEqS(Get(PR_281, "rail"), "teak") ? "#8a4e24" : "#e2b14a")))), ((V)(0.45)));
ro_705 = Call(NM_255, V.Undef, ((V)((SEqS(Get(PR_281, "rail"), "white") ? "#9aa4b0" : (SEqS(Get(PR_281, "rail"), "teak") ? "#4a2810" : "#9a6a10")))), ((V)(0.45)));
ht_706 = (SEqS(Get(PR_281, "rail"), "gold") ? 20D : 16D);
bal_707 = new JsStrBuf("");
Invoke(railPosts_296, "forEach", Fn((V _arrowThis719, int _argc708, V _a710, V _a711, V _a712, V _a713, V[] _rest709) => {
V x_716 = default;
V y_718 = default;
{ V _t714 = ListOf(_a710);
{ V _t715 = GetIdx(_t714, 0D);
x_716 = _t715; }
{ V _t717 = GetIdx(_t714, 1D);
y_718 = _t717; }
}
return ((V)(bal_707.V(Call(P_24, V.Undef, Call(rr_30, V.Undef, ((V)((ToNum(x_716) - 2D))), ((V)((ToNum(y_718) - ht_706))), ((V)(4D)), ((V)(ht_706)), ((V)(1D))), rc_704, ro_705, ((V)(0.8)))).Str));
}, 1, "", true));
{
double i_720 = 0;
i_720 = 0D;
while (true) {
if (!((i_720 < (ToNum(Get(railPosts_296, "length")) - 1D)))) break;
V a_722 = default;
V b_723 = default;
a_722 = GetIdx(railPosts_296, i_720);
b_723 = GetIdx(railPosts_296, (i_720 + 1D));
{
double k_724 = 0;
k_724 = 1D;
while (true) {
if (!((k_724 < 4D))) break;
V x_726 = default;
V y_727 = default;
x_726 = Add(GetIdx(a_722, 0D), ((V)((((ToNum(GetIdx(b_723, 0D)) - ToNum(GetIdx(a_722, 0D))) * k_724) / 4D))));
y_727 = Add(GetIdx(a_722, 1D), ((V)((((ToNum(GetIdx(b_723, 1D)) - ToNum(GetIdx(a_722, 1D))) * k_724) / 4D))));
bal_707.V((SEqS(Get(PR_281, "rail"), "gold") ? Call(P_24, V.Undef, Call(ell_29, V.Undef, x_726, ((V)((ToNum(y_727) - (ht_706 / 2D)))), ((V)(1.6)), ((V)(((ht_706 / 2D) - 1D)))), rc_704, ro_705, ((V)(0.5))) : Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, x_726)), " ", ToStr(Call(f1_10, V.Undef, y_727)), "V", ToStr(Call(f1_10, V.Undef, ((V)(((ToNum(y_727) - ht_706) + 3D)))))))), ((V)("none")), rc_704, ((V)(1.3)))));
k_724++;
}
}
i_720++;
}
}
s_270.S(bal_707.Str).V(Call(P_24, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(railPosts_296, "map", Fn((V _arrowThis735, int _argc728, V q_734, V _a731, V _a732, V _a733, V[] _rest729) => {
return ((V)(JsStrBuf.Begin().V(GetIdx(q_734, 0D)).S(" ").N((ToNum(GetIdx(q_734, 1D)) - ht_706)).End()));
}, 1, "", true)), "join", ((V)("L")))).End())), ((V)("none")), ro_705, ((V)(4.2)))).V(Call(P_24, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(railPosts_296, "map", Fn((V _arrowThis743, int _argc736, V q_742, V _a739, V _a740, V _a741, V[] _rest737) => {
return ((V)(JsStrBuf.Begin().V(GetIdx(q_742, 0D)).S(" ").N((ToNum(GetIdx(q_742, 1D)) - ht_706)).End()));
}, 1, "", true)), "join", ((V)("L")))).End())), ((V)("none")), rc_704, ((V)(2.6))));
if (SEqS(Get(PR_281, "rail"), "teak")) {
JsStrBuf bn_744 = null;
Invoke(Arr(Add(XE_285, ((V)(4D))), ((V)((ToNum(XP_288) - 4D)))), "forEach", Fn((V _arrowThis753, int _argc745, V x_751, V j_752, V _a749, V _a750, V[] _rest746) => {
s_270.V(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(x_751), " ", ToStr(Q0_286), "V", NumStr((ToNum(Q0_286) - 52D))))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#f4f1ea")), ((V)(0.45))), ((V)(2D)))).S(string.Concat("<g transform=\"translate(", ToStr(x_751), " ", NumStr((ToNum(Q0_286) - 52D)), ")\">", ToStr(Call(P_24, V.Undef, ((V)("M0 0L16 4L0 9Z")), Call(NM_255, V.Undef, ((V)((Truthy(j_752) ? "#3f7fc8" : "#e2554a"))), ((V)(0.45))), Call(NM_255, V.Undef, ((V)("#2a2a40")), ((V)(0.5))), ((V)(0.8)), ((V)("")))), "</g>"));
return default;
}, 2, "", true));
bn_744 = new JsStrBuf("");
Call(rep_20, V.Undef, ((V)(9D)), Fn((V _arrowThis761, int _argc754, V i_760, V _a757, V _a758, V _a759, V[] _rest755) => {
double t_762 = 0;
V x_763 = default;
double y_764 = 0;
t_762 = (ToNum(Add(i_760, ((V)(0.5)))) / 9D);
x_763 = Add(Add(XE_285, ((V)(4D))), ((V)((((ToNum(XP_288) - ToNum(XE_285)) - 8D) * t_762))));
y_764 = ((ToNum(Q0_286) - 48D) + (FdLibm.Sin((t_762 * PI_14)) * 8D));
bn_744.S(string.Concat("<path d=\"M", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_763) - 3D))))), " ", ToStr(Call(f1_10, V.Undef, ((V)(y_764)))), "L", ToStr(Call(f1_10, V.Undef, Add(x_763, ((V)(3D))))), " ", ToStr(Call(f1_10, V.Undef, ((V)(y_764)))), "L", ToStr(Call(f1_10, V.Undef, x_763)), " ", ToStr(Call(f1_10, V.Undef, ((V)((y_764 + 7D))))), "Z\" fill=\"", ToStr(Call(NM_255, V.Undef, GetIdx(Arr(((V)("#e2554a")), ((V)("#ffd23f")), ((V)("#3f7fc8")), ((V)("#ffffff"))), (ToNum(i_760) % 4D)), ((V)(0.45)))), "\"/>"));
return default;
}, 1, "", true));
s_270.V(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Add(XE_285, ((V)(4D)))), " ", NumStr((ToNum(Q0_286) - 48D)), "Q", NumStr((ToNum(Add(XE_285, XP_288)) / 2D)), " ", NumStr((ToNum(Q0_286) - 36D)), " ", NumStr((ToNum(XP_288) - 4D)), " ", NumStr((ToNum(Q0_286) - 48D))))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#3a2a20")), ((V)(0.5))), ((V)(0.8)))).S(string.Concat("<g>", ToStr(Call(AT_25, V.Undef, ((V)("skewX")), ((V)("-3;3;-3")), ((V)(2.4)), ((V)(0D)), Call(SPL_27, V.Undef, ((V)(2D))))), bn_744.Str, "</g>"));
Invoke(Arr(Add(X0_282, ((V)(80D))), Add(X0_282, ((V)(160D))), ((V)((ToNum(XE_285) - 20D)))), "forEach", Fn((V _arrowThis772, int _argc765, V x_771, V _a768, V _a769, V _a770, V[] _rest766) => {
return ((V)(s_270.V(Call(P_24, V.Undef, Call(rr_30, V.Undef, ((V)((ToNum(x_771) - 4D))), ((V)((ToNum(Y1_284) - 4D))), ((V)(8D)), ((V)(2.6)), ((V)(1.2))), Call(NM_255, V.Undef, ((V)("#e2b14a")), ((V)(0.4))), Call(NM_255, V.Undef, ((V)("#8a5d00")), ((V)(0.4))), ((V)(0.6)))).Str));
}, 1, "", true));
}
if ((SEqS(Get(PR_281, "rail"), "white") || SEqS(Get(PR_281, "rail"), "gold"))) {
V lamps_773 = default;
lamps_773 = (SEqS(Get(PR_281, "rail"), "gold") ? Arr(Arr(Add(X0_282, ((V)(60D))), Y0_283), Arr(((V)((ToNum(XE_285) - 10D))), Y0_283), Arr(Add(XE_285, ((V)(4D))), Q0_286), Arr(((V)((ToNum(XP_288) - 4D))), Q0_286)) : Arr(Arr(Add(X0_282, ((V)(90D))), Y0_283), Arr(((V)((ToNum(XE_285) - 40D))), Y0_283), Arr(((V)((ToNum(XP_288) - 6D))), Q0_286)));
Invoke(lamps_773, "forEach", Fn((V _arrowThis785, int _argc774, V _a776, V _a777, V _a778, V _a779, V[] _rest775) => {
double H_786 = 0;
V lc_787 = default;
V x_782 = default;
V y_784 = default;
{ V _t780 = ListOf(_a776);
{ V _t781 = GetIdx(_t780, 0D);
x_782 = _t781; }
{ V _t783 = GetIdx(_t780, 1D);
y_784 = _t783; }
}
H_786 = (SEqS(Get(PR_281, "rail"), "gold") ? 46D : 40D);
lc_787 = ((V)((SEqS(Get(PR_281, "rail"), "gold") ? "#e2b14a" : "#2c2d31")));
s_270.V(Add(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(x_782), " ", ToStr(y_784), "V", NumStr((ToNum(y_784) - H_786))))), ((V)("none")), Call(NM_255, V.Undef, lc_787, ((V)(0.4))), ((V)(2.6))), (SEqS(Get(PR_281, "rail"), "gold") ? Add(Call(P_24, V.Undef, ((V)(string.Concat("M", NumStr((ToNum(x_782) - 5D)), " ", NumStr((ToNum(y_784) - H_786)), "h10l-2 -10h-6Z"))), Call(NM_255, V.Undef, ((V)("#fff1b8")), ((V)((Truthy(nt_247) ? 0D : 0.3)))), Call(NM_255, V.Undef, ((V)("#9a6a10")), ((V)(0.4))), ((V)(1D))), Call(P_24, V.Undef, ((V)(string.Concat("M", NumStr((ToNum(x_782) - 6D)), " ", NumStr(((ToNum(y_784) - H_786) - 10D)), "h12l-6 -6Z"))), Call(NM_255, V.Undef, ((V)("#e2b14a")), ((V)(0.4))))) : Add(Call(P_24, V.Undef, Call(circ_28, V.Undef, x_782, ((V)(((ToNum(y_784) - H_786) - 3D))), ((V)(4.4))), Call(NM_255, V.Undef, ((V)("#fff6c8")), ((V)((Truthy(nt_247) ? 0D : 0.3)))), Call(NM_255, V.Undef, ((V)("#2c2d31")), ((V)(0.4))), ((V)(1.2))), Call(P_24, V.Undef, ((V)(string.Concat("M", NumStr((ToNum(x_782) - 5D)), " ", NumStr(((ToNum(y_784) - H_786) - 6D)), "h10"))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#2c2d31")), ((V)(0.4))), ((V)(2D)))))));
if (Truthy(nt_247)) {
s_270.S(string.Concat("<circle cx=\"", ToStr(x_782), "\" cy=\"", NumStr(((ToNum(y_784) - H_786) - 5D)), "\" r=\"26\" fill=\"url(#bzGlow)\"/>"));
}
return default;
}, 1, "", true));
}
}
}
s_270.S(string.Concat("<g transform=\"translate(", NumStr((ToNum(XP_288) - 40D)), " ", ToStr(Add(Q0_286, ((V)(5D)))), ")\">", ToStr(Call(P_24, V.Undef, ((V)("M-6 -9L-5 0H5L6 -9Z")), Call(NM_255, V.Undef, ((V)("#9aa4ac")), ((V)(0.45))), Call(NM_255, V.Undef, ((V)("#4a5058")), ((V)(0.45))), ((V)(1D)))), ToStr(Call(P_24, V.Undef, Call(ell_29, V.Undef, ((V)(0D)), ((V)((-9D))), ((V)(6D)), ((V)(1.8))), Call(NM_255, V.Undef, ((V)("#2a5a7a")), ((V)(0.45))), Call(NM_255, V.Undef, ((V)("#4a5058")), ((V)(0.45))), ((V)(0.8)))), ToStr(Call(P_24, V.Undef, Call(rr_30, V.Undef, ((V)(9D)), ((V)((-6D))), ((V)(12D)), ((V)(7D)), ((V)(1.5))), Call(NM_255, V.Undef, ((V)("#3f9a5a")), ((V)(0.45))), Call(NM_255, V.Undef, ((V)("#1e5a32")), ((V)(0.45))), ((V)(0.8)))), ToStr(Call(P_24, V.Undef, ((V)("M-12 -1L-2 -34")), ((V)("none")), Call(NM_255, V.Undef, ((V)("#6a4a2a")), ((V)(0.45))), ((V)(1.4)))), ToStr(Call(P_24, V.Undef, ((V)("M-2 -34Q4 -20 2 -6")), ((V)("none")), Call(NM_255, V.Undef, ((V)("#ffffff")), ((V)(0.45))), ((V)(0.5)), ((V)(" opacity=\"0.8\"")))), "</g>"));
glow_297 = Fn((V _arrowThis798, int _argc788, V x_794, V y_795, V r_796, V c_797, V[] _rest789) => {
return ((V)((Truthy(nt_247) ? string.Concat("<circle cx=\"", ToStr(Call(f1_10, V.Undef, x_794)), "\" cy=\"", ToStr(Call(f1_10, V.Undef, y_795)), "\" r=\"", ToStr(Call(f1_10, V.Undef, r_796)), "\" fill=\"url(#", ToStr((c_797 is var _t799 && Truthy(_t799) ? _t799 : ((V)("bzGlow")))), ")\"/>") : "")));
}, 4, "", true);
if ((lt_250 == 1D)) {
V lx_800 = default;
V ly_801 = default;
lx_800 = Add(X0_282, ((V)(30D)));
ly_801 = Y0_283;
s_270.V(Add(Add(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(lx_800), " ", ToStr(ly_801), "L", NumStr((ToNum(lx_800) - 2D)), " ", NumStr((ToNum(ly_801) - 32D)), "L", ToStr(Add(lx_800, ((V)(4D)))), " ", NumStr((ToNum(ly_801) - 32D)), "L", ToStr(Add(lx_800, ((V)(5D)))), " ", ToStr(ly_801), "Z"))), Call(NM_255, V.Undef, ((V)("#9a7a56")), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#4a3a28")), ((V)(0.5))), ((V)(1D))), Call(P_24, V.Undef, Call(rr_30, V.Undef, ((V)((ToNum(lx_800) - 4D))), ((V)((ToNum(ly_801) - 36D))), ((V)(12D)), ((V)(7D)), ((V)(2D))), Call(NM_255, V.Undef, ((V)("#3a3d44")), ((V)(0.5))), ((V)("")), ((V)(0D)))), Call(P_24, V.Undef, Call(rr_30, V.Undef, lx_800, ((V)((ToNum(ly_801) - 30D))), ((V)(4D)), ((V)(3D)), ((V)(1D))), Call(NM_255, V.Undef, ((V)("#c9c9c9")), ((V)(0.5))))));
if (Truthy(nt_247)) {
s_270.V(Call(glow_297, V.Undef, Add(lx_800, ((V)(8D))), ((V)((ToNum(ly_801) - 33D))), ((V)(22D))));
}
} else {
if ((lt_250 == 2D)) {
Invoke(Arr(Arr(Add(X0_282, ((V)(40D))), Y0_283), Arr(Add(X0_282, ((V)(110D))), Y0_283), Arr(((V)((ToNum(XE_285) - 20D))), Y0_283), Arr(((V)((ToNum(XP_288) - 10D))), Q0_286)), "forEach", Fn((V _arrowThis813, int _argc802, V _a804, V _a805, V _a806, V _a807, V[] _rest803) => {
V x_810 = default;
V y_812 = default;
{ V _t808 = ListOf(_a804);
{ V _t809 = GetIdx(_t808, 0D);
x_810 = _t809; }
{ V _t811 = GetIdx(_t808, 1D);
y_812 = _t811; }
}
s_270.V(Add(Add(Add(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(x_810), " ", ToStr(y_812), "V", NumStr((ToNum(y_812) - 12D))))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#3a3d44")), ((V)(0.5))), ((V)(1.6))), Call(P_24, V.Undef, Call(rr_30, V.Undef, ((V)((ToNum(x_810) - 3.5))), ((V)((ToNum(y_812) - 19D))), ((V)(7D)), ((V)(7D)), ((V)(1.5))), Call(NM_255, V.Undef, ((V)((Truthy(nt_247) ? "#fff6c8" : "#e6eef2"))), ((V)(0.3))), Call(NM_255, V.Undef, ((V)("#3a3d44")), ((V)(0.5))), ((V)(0.8)))), Call(P_24, V.Undef, Call(rr_30, V.Undef, ((V)((ToNum(x_810) - 4.5))), ((V)((ToNum(y_812) - 21D))), ((V)(9D)), ((V)(2.5)), ((V)(1D))), Call(NM_255, V.Undef, ((V)("#2a5aa8")), ((V)(0.4))))), Call(glow_297, V.Undef, x_810, ((V)((ToNum(y_812) - 15D))), ((V)(20D)))));
return default;
}, 1, "", true));
} else {
if ((lt_250 == 3D)) {
Invoke(Arr(Arr(Add(X0_282, ((V)(10D))), ((V)((ToNum(Y0_283) - 2D)))), Arr(((V)((ToNum(XE_285) - 10D))), ((V)((ToNum(Y0_283) - 2D)))), Arr(((V)((ToNum(XP_288) - 8D))), ((V)((ToNum(Q0_286) - 2D))))), "forEach", Fn((V _arrowThis826, int _argc814, V _a816, V i_820, V _a818, V _a819, V[] _rest815) => {
V k_827 = default;
double fy_828 = 0;
V x_823 = default;
V y_825 = default;
{ V _t821 = ListOf(_a816);
{ V _t822 = GetIdx(_t821, 0D);
x_823 = _t822; }
{ V _t824 = GetIdx(_t821, 1D);
y_825 = _t824; }
}
k_827 = Call(WY_16, V.Undef, y_825);
s_270.V(Add(Call(P_24, V.Undef, ((V)(string.Concat("M", NumStr((ToNum(x_823) - (1.6 * ToNum(k_827)))), " ", ToStr(y_825), "L", NumStr((ToNum(x_823) - (1.2 * ToNum(k_827)))), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(y_825) - (34D * ToNum(k_827))))))), "H", ToStr(Call(f1_10, V.Undef, Add(x_823, ((V)((1.2 * ToNum(k_827))))))), "L", ToStr(Call(f1_10, V.Undef, Add(x_823, ((V)((1.6 * ToNum(k_827))))))), " ", ToStr(y_825), "Z"))), Call(NM_255, V.Undef, ((V)("#8a6a3e")), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#4a3018")), ((V)(0.5))), ((V)(0.8))), Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_823) - (4D * ToNum(k_827))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(y_825) - (34D * ToNum(k_827))))))), "L", ToStr(Call(f1_10, V.Undef, Add(x_823, ((V)((4D * ToNum(k_827))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(y_825) - (34D * ToNum(k_827))))))), "L", ToStr(Call(f1_10, V.Undef, Add(x_823, ((V)((3D * ToNum(k_827))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(y_825) - (41D * ToNum(k_827))))))), "L", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_823) - (3D * ToNum(k_827))))))), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(y_825) - (41D * ToNum(k_827))))))), "Z"))), Call(NM_255, V.Undef, ((V)("#c49a5a")), ((V)(0.5))), Call(NM_255, V.Undef, ((V)("#6a4a20")), ((V)(0.5))), ((V)(0.8)))));
fy_828 = (ToNum(y_825) - (41D * ToNum(k_827)));
s_270.S(string.Concat("<g transform=\"translate(", ToStr(x_823), " ", ToStr(Call(f1_10, V.Undef, ((V)(fy_828)))), ") scale(", ToStr(Call(n3_21, V.Undef, k_827)), ")\"><path d=\"M0 -12C4 -7 4 -3 0 0C-4 -3 -4 -7 0 -12Z\" fill=\"#ff8a2a\">", ToStr(Call(AN_26, V.Undef, ((V)("d")), ((V)("M0 -12C4 -7 4 -3 0 0C-4 -3 -4 -7 0 -12Z;M1 -14C5 -8 4 -3 0 0C-4 -3 -3 -8 1 -14Z;M-1 -11C3 -7 4 -3 0 0C-4 -3 -4 -6 -1 -11Z;M0 -12C4 -7 4 -3 0 0C-4 -3 -4 -7 0 -12Z")), ((V)(0.9)), ((V)(((-ToNum(i_820)) * 0.2))))), "</path><path d=\"M0 -7C2 -4 2 -2 0 0C-2 -2 -2 -4 0 -7Z\" fill=\"#ffe9a0\"/></g>")).V(Call(glow_297, V.Undef, x_823, ((V)((fy_828 - 4D))), ((V)(22D)))).S((Truthy(nt_247) ? "" : string.Concat("<circle cx=\"", ToStr(x_823), "\" cy=\"", ToStr(Call(f1_10, V.Undef, ((V)((fy_828 - 4D))))), "\" r=\"8\" fill=\"url(#bzGlow)\" opacity=\"0.5\"/>")));
return default;
}, 2, "", true));
} else {
if ((lt_250 == 4D)) {
V C_829 = default;
V line_830 = default;
C_829 = Arr(((V)("#ff9d4a")), ((V)("#ffd66b")), ((V)("#ff7aa0")), ((V)("#6ac8ff")), ((V)("#a6f06a")));
line_830 = Fn((V _arrowThis844, int _argc831, V x0_837, V y0_838, V ym_839, V x1_840, V[] _rest832) => {
double xm_845 = 0;
V t_846 = default;
V y1_841 = default;
V n_842 = default;
V seed_843 = default;
y1_841 = (_argc831 > 4 ? _rest832[0] : V.Undef);
n_842 = (_argc831 > 5 ? _rest832[1] : V.Undef);
seed_843 = (_argc831 > 6 ? _rest832[2] : V.Undef);
xm_845 = (ToNum(Add(x0_837, x1_840)) / 2D);
t_846 = Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(x0_837), " ", ToStr(y0_838), "Q", NumStr(xm_845), " ", ToStr(ym_839), " ", ToStr(x1_840), " ", ToStr(y1_841)))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#4a3a30")), ((V)(0.5))), ((V)(1D)));
Call(rep_20, V.Undef, n_842, Fn((V _arrowThis854, int _argc847, V i_853, V _a850, V _a851, V _a852, V[] _rest848) => {
double u_855 = 0;
double bx_856 = 0;
double by_857 = 0;
V c_858 = default;
double h_859 = 0;
u_855 = (ToNum(Add(i_853, ((V)(0.5)))) / ToNum(n_842));
bx_856 = (((((1D - u_855) * (1D - u_855)) * ToNum(x0_837)) + (((2D * (1D - u_855)) * u_855) * xm_845)) + ((u_855 * u_855) * ToNum(x1_840)));
by_857 = (((((1D - u_855) * (1D - u_855)) * ToNum(y0_838)) + (((2D * (1D - u_855)) * u_855) * ToNum(ym_839))) + ((u_855 * u_855) * ToNum(y1_841)));
c_858 = GetIdx(C_829, (ToNum(Add(i_853, seed_843)) % 5D));
h_859 = (6D + ((ToNum(i_853) % 2D) * 2D));
t_846 = ((V)(JsStrBuf.Begin().V(t_846).V(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, ((V)(bx_856)))), " ", ToStr(Call(f1_10, V.Undef, ((V)(by_857)))), "v3"))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#4a3a30")), ((V)(0.5))), ((V)(0.8)))).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_10, V.Undef, ((V)(bx_856)))), " ", ToStr(Call(f1_10, V.Undef, ((V)((by_857 + 3D))))), ")\"><g>", ToStr(Call(AT_25, V.Undef, ((V)("rotate")), ((V)("-6;6;-6")), ((V)(2.6)), ((V)(((-ToNum(i_853)) * 0.3))), Call(SPL_27, V.Undef, ((V)(2D))))), ToStr(Call(P_24, V.Undef, Call(ell_29, V.Undef, ((V)(0D)), ((V)(h_859)), ((V)((h_859 * 0.8))), ((V)(h_859))), Call(NM_255, V.Undef, c_858, ((V)((Truthy(nt_247) ? 0D : 0.35)))), Call(NM_255, V.Undef, Call(shade_12, V.Undef, c_858, ((V)(0.6))), ((V)(0.4))), ((V)(0.8)))), ToStr(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, ((V)(((-h_859) * 0.8))))), " ", NumStr(h_859), "H", ToStr(Call(f1_10, V.Undef, ((V)((h_859 * 0.8)))))))), ((V)("none")), Call(NM_255, V.Undef, Call(shade_12, V.Undef, c_858, ((V)(0.7))), ((V)(0.4))), ((V)(0.6)))), "</g></g>")).V(Call(glow_297, V.Undef, ((V)(bx_856)), ((V)(((by_857 + 3D) + h_859))), ((V)(16D)))).End()));
return default;
}, 1, "", true));
return t_846;
return default;
}, 7, "", true);
s_270.V(Add(Add(Call(P_24, V.Undef, ((V)(string.Concat("M", ToStr(Add(X0_282, ((V)(24D)))), " ", ToStr(Y0_283), "V", NumStr((ToNum(Y0_283) - 34D)), "M", ToStr(XE_285), " ", ToStr(Y0_283), "V", NumStr((ToNum(Y0_283) - 34D)), "M", NumStr((ToNum(XP_288) - 4D)), " ", ToStr(Q0_286), "V", NumStr((ToNum(Q0_286) - 34D))))), ((V)("none")), Call(NM_255, V.Undef, ((V)("#8a6a48")), ((V)(0.5))), ((V)(2D))), Call(line_830, V.Undef, Add(X0_282, ((V)(24D))), ((V)((ToNum(Y0_283) - 32D))), ((V)((ToNum(Y0_283) - 16D))), XE_285, ((V)((ToNum(Y0_283) - 32D))), ((V)(8D)), ((V)(2D)))), Call(line_830, V.Undef, XE_285, ((V)((ToNum(Y0_283) - 32D))), ((V)((ToNum(Q0_286) - 22D))), ((V)((ToNum(XP_288) - 4D))), ((V)((ToNum(Q0_286) - 32D))), ((V)(3D)), ((V)(1D)))));
} else {
if ((lt_250 == 5D)) {
Call(rep_20, V.Undef, ((V)(7D)), Fn((V _arrowThis867, int _argc860, V i_866, V _a863, V _a864, V _a865, V[] _rest861) => {
double x_868 = 0;
double y_869 = 0;
x_868 = (560D + ((ToNum(i_866) * 47D) % 260D));
y_869 = (120D + ((ToNum(i_866) * 53D) % 200D));
if (Truthy(Call(nearPier_45, V.Undef, ((V)(x_868)), ((V)(y_869))))) {
return default;
}
s_270.S(string.Concat("<g transform=\"translate(", NumStr(x_868), " ", NumStr(y_869), ")\"><g>", ToStr(Call(AT_25, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;", NumStr((NumTruthy((ToNum(i_866) % 2D)) ? 6D : (-6D))), " -8;0 0"))), ((V)((4D + (ToNum(i_866) * 0.6)))), ((V)((-ToNum(i_866)))), Call(SPL_27, V.Undef, ((V)(2D))))), "<circle r=\"", NumStr((Truthy(nt_247) ? 14D : 8D)), "\" fill=\"url(#bzCyan)\"/><circle r=\"2.4\" fill=\"#e8ffff\"/></g></g>"));
return default;
}, 1, "", true));
}
}
}
}
}
if (Truthy(rainy_251)) {
V Rr_870 = default;
Rr_870 = Call(rng_19, V.Undef, ((V)("rain")));
s_270.S(string.Concat("<g opacity=\"0.55\">", "")).V(Invoke(Call(rep_20, V.Undef, ((V)(70D)), Fn((V _arrowThis878, int _argc871, V i_877, V _a874, V _a875, V _a876, V[] _rest872) => {
double x_879 = 0;
double dd_880 = 0;
x_879 = (ToNum(Call(Rr_870, V.Undef)) * 900D);
dd_880 = (0.5 + (ToNum(Call(Rr_870, V.Undef)) * 0.35));
return ((V)(string.Concat("<path d=\"M0 0l-4 12\" stroke=\"#e6eef4\" stroke-width=\"1.1\" stroke-linecap=\"round\"><animateTransform attributeName=\"transform\" type=\"translate\" values=\"", ToStr(Call(f1_10, V.Undef, ((V)(x_879)))), " -60;", ToStr(Call(f1_10, V.Undef, ((V)((x_879 - 30D))))), " 400\" dur=\"", ToStr(Call(n3_21, V.Undef, ((V)(dd_880)))), "s\" begin=\"", ToStr(Call(n3_21, V.Undef, ((V)(((-ToNum(Call(Rr_870, V.Undef))) * dd_880))))), "s\" repeatCount=\"indefinite\"/></path>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("</g>", ""));
}
if (Truthy(snowy_252)) {
V Rs_881 = default;
Rs_881 = Call(rng_19, V.Undef, ((V)("snowf")));
s_270.V(Invoke(Call(rep_20, V.Undef, ((V)(54D)), Fn((V _arrowThis889, int _argc882, V i_888, V _a885, V _a886, V _a887, V[] _rest883) => {
double x_890 = 0;
double w_891 = 0;
double dd_892 = 0;
x_890 = ((ToNum(Call(Rs_881, V.Undef)) * 870D) - 10D);
w_891 = (8D + (ToNum(Call(Rs_881, V.Undef)) * 14D));
dd_892 = (7D + (ToNum(Call(Rs_881, V.Undef)) * 6D));
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_10, V.Undef, ((V)((1.2 + (ToNum(Call(Rs_881, V.Undef)) * 1.8)))))), "\" fill=\"#ffffff\" opacity=\"0.9\"><animateTransform attributeName=\"transform\" type=\"translate\" values=\"", ToStr(Call(f1_10, V.Undef, ((V)(x_890)))), " -60;", ToStr(Call(f1_10, V.Undef, ((V)((x_890 + w_891))))), " 110;", ToStr(Call(f1_10, V.Undef, ((V)((x_890 - w_891))))), " 260;", ToStr(Call(f1_10, V.Undef, ((V)((x_890 + (w_891 * 0.5)))))), " 400\" dur=\"", ToStr(Call(n3_21, V.Undef, ((V)(dd_892)))), "s\" begin=\"", ToStr(Call(n3_21, V.Undef, ((V)(((-ToNum(Call(Rs_881, V.Undef))) * dd_892))))), "s\" repeatCount=\"indefinite\"/></circle>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
}
if (Truthy((sunny_253 is var _t893 && !Truthy(_t893) ? _t893 : (!(Truthy(nt_247)) ? V.True : V.False)))) {
s_270.V(Invoke(Call(rep_20, V.Undef, ((V)(2D)), Fn((V _arrowThis901, int _argc894, V i_900, V _a897, V _a898, V _a899, V[] _rest895) => {
return ((V)(string.Concat("<g>", string.Concat("<animateMotion dur=\"", NumStr((18D + (ToNum(i_900) * 7D))), "s\" begin=\"", NumStr(((-ToNum(i_900)) * 9D)), "s\" repeatCount=\"indefinite\" path=\"M-40 ", NumStr((10D + (ToNum(i_900) * 14D))), "C200 ", NumStr(((-20D) + (ToNum(i_900) * 10D))), " 500 ", NumStr((30D + (ToNum(i_900) * 6D))), " 900 ", NumStr(((-4D) + (ToNum(i_900) * 12D))), "\"/>"), "<path d=\"M-6 0Q-3 -3 0 0Q3 -3 6 0\" fill=\"none\" stroke=\"#4a5058\" stroke-width=\"1.4\" stroke-linecap=\"round\">", ToStr(Call(AN_26, V.Undef, ((V)("d")), ((V)("M-6 0Q-3 -3 0 0Q3 -3 6 0;M-6 -2Q-3 1 0 0Q3 1 6 -2;M-6 0Q-3 -3 0 0Q3 -3 6 0")), ((V)(0.6)), ((V)(((-ToNum(i_900)) * 0.2))))), "</path></g>")));
}, 1, "", true)), "join", ((V)(""))));
}
return NewObj(2).Put("defs", d_269).Put("body", ((V)(s_270.Str))).V;
return default;
}, 1, "scene", false);
thumb_59 = Fn((V _self902, int _argc903, V kind_909, V tier_910, V _a907, V _a908, V[] _rest904) => {
V o_911 = default;
V sc_912 = default;
V vb_913 = default;
if (_self902.IsNullish) _self902 = GlobalV;
o_911 = NewObj(5).Put("season", ((V)("sunny"))).Put("sand", (SEqS(kind_909, "ground") ? tier_910 : ((V)(3D)))).Put("pier", (SEqS(kind_909, "fence") ? tier_910 : ((V)(2D)))).Put("light", (SEqS(kind_909, "ylight") ? tier_910 : ((V)(0D)))).Put("night", (SEqS(kind_909, "ylight") ? V.True : V.False)).V;
sc_912 = Call(scene_58, V.Undef, o_911);
vb_913 = ((V)((SEqS(kind_909, "ground") ? "140 186 360 200" : (SEqS(kind_909, "fence") ? "470 150 382 140" : (SEqN(tier_910, 5D) ? "470 90 382 240" : (SEqN(tier_910, 1D) ? "280 40 200 120" : (SEqN(tier_910, 4D) ? "80 10 420 160" : "20 60 420 200")))))));
return ((V)(string.Concat("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"", ToStr(vb_913), "\" preserveAspectRatio=\"xMidYMid slice\"><defs>", ToStr(Get(sc_912, "defs")), "</defs>", ToStr(Get(sc_912, "body")), "</svg>")));
return default;
}, 2, "thumb", false);
shellSvg_61 = Fn((V _self914, int _argc915, V k_921, V _a918, V _a919, V _a920, V[] _rest916) => {
V a_922 = default;
V b_923 = default;
V body_924 = default;
if (_self914.IsNullish) _self914 = GlobalV;
{ V _t925 = GetIdx(SHELLK_60, (ToNum(k_921) % ToNum(Get(SHELLK_60, "length"))));
{ V _t926 = ListOf(_t925);
{ V _t927 = GetIdx(_t926, 0D);
a_922 = _t927; }
{ V _t928 = GetIdx(_t926, 1D);
b_923 = _t928; }
} }
body_924 = ((V)((((ToNum(k_921) % 3D) == 0D) ? string.Concat(ToStr(Call(P_24, V.Undef, ((V)("M-9 3C-9-6 9-6 9 3Q0 6-9 3Z")), a_922, b_923, ((V)(1.2)))), ToStr(Call(P_24, V.Undef, ((V)("M0 4L0-4M-4 4L-2-4M4 4L2-4M-7 3L-5-2M7 3L5-2")), ((V)("none")), b_923, ((V)(0.8)))), ToStr(Call(P_24, V.Undef, Call(rr_30, V.Undef, ((V)((-3D))), ((V)(3D)), ((V)(6D)), ((V)(3D)), ((V)(1D))), a_922, b_923, ((V)(1D))))) : (((ToNum(k_921) % 3D) == 1D) ? string.Concat(ToStr(Call(P_24, V.Undef, ((V)("M-8 4Q-10-2-2-6Q8-8 9 0Q8 5 0 5Z")), a_922, b_923, ((V)(1.2)))), ToStr(Call(P_24, V.Undef, ((V)("M-6 2Q0-2 6 1M-4 -2Q2-4 6-2")), ((V)("none")), b_923, ((V)(0.8)))), ToStr(Call(P_24, V.Undef, ((V)("M8 0l4 3")), ((V)("none")), b_923, ((V)(1.4))))) : string.Concat(ToStr(Call(P_24, V.Undef, ((V)("M0-8L2.4-2.6L8-2.6L3.6 1L5.4 7L0 3.6L-5.4 7L-3.6 1L-8-2.6L-2.4-2.6Z")), a_922, b_923, ((V)(1.2)))), ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(1.2))), b_923)))))));
return ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, ((V)(string.Concat("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"-14 -12 28 22\">", ToStr(Call(P_24, V.Undef, Call(ell_29, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(9D)), ((V)(2.4))), ((V)("#3a2210")), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.18\"")))), ToStr(body_924), ToStr(Call(P_24, V.Undef, Call(ell_29, V.Undef, ((V)((-3D))), ((V)((-2D))), ((V)(2.4)), ((V)(1.2))), ((V)("#ffffff")), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.6\"")))), "</svg>"))))).End()));
return default;
}, 1, "shellSvg", false);
snowmanSvg_62 = Fn((V _self929, int _argc930, V i_936, V _a933, V _a934, V _a935, V[] _rest931) => {
V sc_937 = default;
if (_self929.IsNullish) _self929 = GlobalV;
sc_937 = GetIdx(Arr(((V)("#e2554a")), ((V)("#3f7fc8")), ((V)("#4fae5a"))), (ToNum(i_936) % 3D));
return ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, ((V)(string.Concat("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"-30 -84 60 92\"><radialGradient id=\"sn\" cx=\"38%\" cy=\"32%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"1\" stop-color=\"#cfe0ea\"/></radialGradient>", ToStr(Call(P_24, V.Undef, Call(ell_29, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(22D)), ((V)(5D))), ((V)("#2a3a50")), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.2\"")))), ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(0D)), ((V)((-14D))), ((V)(19D))), ((V)("url(#sn)")), ((V)("#9ab4c6")), ((V)(1.5)))), ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(0D)), ((V)((-44D))), ((V)(14D))), ((V)("url(#sn)")), ((V)("#9ab4c6")), ((V)(1.5)))), ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(0D)), ((V)((-66D))), ((V)(10D))), ((V)("url(#sn)")), ((V)("#9ab4c6")), ((V)(1.5)))), ToStr(Call(P_24, V.Undef, ((V)("M-12 -56Q0 -50 12 -56L13 -51Q0 -45 -13 -51Z")), sc_937, Call(shade_12, V.Undef, sc_937, ((V)(0.6))), ((V)(1D)))), ToStr(Call(P_24, V.Undef, ((V)("M8 -52l4 14l-6 0Z")), sc_937, Call(shade_12, V.Undef, sc_937, ((V)(0.6))), ((V)(1D)))), ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)((-3.5))), ((V)((-69D))), ((V)(1.4))), ((V)("#2a2a30")))), ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(3.5)), ((V)((-69D))), ((V)(1.4))), ((V)("#2a2a30")))), ToStr(Call(P_24, V.Undef, ((V)("M0 -66l8 2l-8 2Z")), ((V)("#ff8a2a")), ((V)("#c4561c")), ((V)(0.6)))), ToStr(Call(P_24, V.Undef, ((V)("M-4 -61q4 3 8 0")), ((V)("none")), ((V)("#2a2a30")), ((V)(1.1)))), ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(0D)), ((V)((-42D))), ((V)(1.6))), ((V)("#2a2a30")))), ToStr(Call(P_24, V.Undef, Call(circ_28, V.Undef, ((V)(0D)), ((V)((-34D))), ((V)(1.6))), ((V)("#2a2a30")))), ToStr(Call(P_24, V.Undef, ((V)("M-13 -46L-26 -54M-24 -53l-2 -5M13 -46L26 -56M24 -55l3 -4")), ((V)("none")), ((V)("#7a5434")), ((V)(1.6)))), ToStr(Call(P_24, V.Undef, ((V)("M-10 -74H10L7 -76V-84H-7V-76Z")), ((V)("#2c2d31")), ((V)("#16171a")), ((V)(1D)))), ToStr(Call(P_24, V.Undef, ((V)("M-7 -77H7")), ((V)("none")), sc_937, ((V)(1.6)))), "</svg>"))))).End()));
return default;
}, 1, "snowmanSvg", false);
props_64 = Fn((V _self938, int _argc939, V o_945, V _a942, V _a943, V _a944, V[] _rest940) => {
V @out_946 = default;
if (_self938.IsNullish) _self938 = GlobalV;
@out_946 = Arr();
if (SEqS(Get(o_945, "season"), "snowy")) {
Invoke(SNOWMEN_63, "forEach", Fn((V _arrowThis959, int _argc947, V _a949, V i_953, V _a951, V _a952, V[] _rest948) => {
V x_956 = default;
V y_958 = default;
{ V _t954 = ListOf(_a949);
{ V _t955 = GetIdx(_t954, 0D);
x_956 = _t955; }
{ V _t957 = GetIdx(_t954, 1D);
y_958 = _t957; }
}
return Invoke(@out_946, "push", NewObj(9).Put("id", ((V)(JsStrBuf.Begin().S("sm").V(i_953).End()))).Put("x", x_956).Put("y", y_958).Put("w", ((V)(60D))).Put("h", ((V)(92D))).Put("ax", ((V)(30D))).Put("ay", ((V)(84D))).Put("src", Call(snowmanSvg_62, V.Undef, i_953)).Put("kind", ((V)("snowman"))).V);
}, 2, "", true));
}
return @out_946;
return default;
}, 1, "props", false);
beachShell_68 = Fn((V _self960, int _argc961, V _a963, V _a964, V _a965, V _a966, V[] _rest962) => {
V g_967 = default;
V P0_968 = default;
if (_self960.IsNullish) _self960 = GlobalV;
if (Truthy(Get(BSH_67, "s"))) {
return Get(BSH_67, "s");
}
g_967 = Call(gate_50, V.Undef, ((V)("L")), ((V)(0D)), ((V)("BACKYARD")));
P0_968 = NewObj(22).Put("b0", ((V)("#9fd6f4"))).Put("b1", ((V)("#e3f4fb"))).Put("l0", ((V)("#e9cf98"))).Put("l1", ((V)("#f1dcae"))).Put("r0", ((V)("#5ec4ea"))).Put("r1", ((V)("#8fd8f0"))).Put("w0", ((V)("#e9cf98"))).Put("w1", ((V)("#e2c48a"))).Put("wr0", ((V)("#5ec4ea"))).Put("wr1", ((V)("#4fb8e2"))).Put("trim", ((V)("#f1dcae"))).Put("pat", ((V)("#9fd6f4"))).Put("f0", ((V)("#ead09a"))).Put("f1", ((V)("#f1d9a6"))).Put("f2", ((V)("#f6e2b6"))).Put("fl", ((V)("#d8b878"))).Put("fd", ((V)("#d8b878"))).Put("fli", ((V)("#fbefd2"))).Put("edge", ((V)("#8a6a3a"))).Put("op", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("door", ((V)("#84b6c9"))).Put("doorL", ((V)("#b4d6e2"))).V;
return Set(BSH_67, "s", NewObj(13).Put("P", P0_968).Put("decor", Arr()).Put("texts", Arr()).Put("doors", Arr(NewObj(6).Put("id", ((V)("g-backyard"))).Put("to", ((V)("backyard"))).Put("hit", Get(g_967, "hit")).Put("spawn", Get(g_967, "spawn")).Put("walk", Get(g_967, "walk")).Put("lock", ((V)(0D))).V)).Put("floor", NewObj(4).Put("lines", ((V)(""))).Put("dark", ((V)(""))).Put("light", ((V)(""))).Put("tiles", Arr()).V).Put("fop", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("wall", ((V)("siding"))).Put("out", (true ? V.True : V.False)).Put("beach", (true ? V.True : V.False)).Put("dark", (false ? V.True : V.False)).Put("rusty", (false ? V.True : V.False)).Put("name", ((V)("Beach"))).Put("light", V.Null).V);
return default;
}, 0, "beachShell", false);
X_8 = Get(G("window"), "House3D");
if (!(Truthy((((((X_8 is var _t969 && !Truthy(_t969) ? _t969 : Get(X_8, "ROOMS")) is var _t970 && !Truthy(_t970) ? _t970 : Get(X_8, "shell")) is var _t971 && !Truthy(_t971) ? _t971 : Get(X_8, "RKEYS")) is var _t972 && !Truthy(_t972) ? _t972 : Get(X_8, "K")) is var _t973 && !Truthy(_t973) ? _t973 : Get(X_8, "edge"))))) {
Call(G("setTimeout"), V.Undef, boot_974.v, ((V)(30D)));
return default;
}
if (Truthy(Get(G("window"), "Beach"))) {
return default;
}
K_9 = Get(X_8, "K");
f1_10 = Get(K_9, "f1");
mix_11 = Get(K_9, "mix");
shade_12 = Get(K_9, "shade");
VW_13 = 852D;
PI_14 = System.Math.PI;
LV_15 = 30D;
WY_16 = Fn((V _arrowThis982, int _argc975, V y_981, V _a978, V _a979, V _a980, V[] _rest976) => {
return ((V)(((652D + (1.235 * (ToNum(y_981) - 100D))) / 652D)));
}, 1, "", true);
sideB_17 = Fn((V _arrowThis991, int _argc983, V s_989, V t_990, V _a987, V _a988, V[] _rest984) => {
return (SEqS(s_989, "L") ? Arr(((V)((100D - (100D * ToNum(t_990))))), ((V)((100D + (162D * ToNum(t_990)))))) : Arr(((V)((752D + (100D * ToNum(t_990))))), ((V)((100D + (162D * ToNum(t_990)))))));
}, 2, "", true);
hash_18 = Fn((V _arrowThis999, int _argc992, V s_998, V _a995, V _a996, V _a997, V[] _rest993) => {
double h_1000 = 0;
h_1000 = 7D;
{
foreach (V _k1001 in new JsIter(((V)(ToStrS(s_998))))) {
V ch_1002 = default;
ch_1002 = _k1001;
h_1000 = ((double)(ToInt32(ToNum(Add(((V)((h_1000 * 31D))), Invoke(ch_1002, "charCodeAt", ((V)(0D)))))) | ToInt32(0D)));
}
}
return (((V)(System.Math.Abs(h_1000))) is var _t1003 && Truthy(_t1003) ? _t1003 : ((V)(1D)));
return default;
}, 1, "", true);
rng_19 = Fn((V _arrowThis1011, int _argc1004, V s_1010, V _a1007, V _a1008, V _a1009, V[] _rest1005) => {
V h_1012 = default;
h_1012 = Call(hash_18, V.Undef, s_1010);
return Fn((V _arrowThis1019, int _argc1013, V _a1015, V _a1016, V _a1017, V _a1018, V[] _rest1014) => {
h_1012 = ((V)(((double)(ToInt32(((ToNum(h_1012) * 1103515245D) + 12345D)) | ToInt32(0D)))));
return ((V)((((double)(ToInt32(((double)(ToUint32(ToNum(h_1012)) >> (int)(ToUint32(8D) & 31)))) & ToInt32(65535D))) / 65536D)));
return default;
}, 0, "", true);
return default;
}, 1, "", true);
rep_20 = Fn((V _arrowThis1028, int _argc1020, V n_1026, V f_1027, V _a1024, V _a1025, V[] _rest1021) => {
return Array_from(NewObj(1).Put("length", n_1026).V, Fn((V _arrowThis1037, int _argc1029, V __1035, V i_1036, V _a1033, V _a1034, V[] _rest1030) => {
return Call(f_1027, V.Undef, i_1036);
}, 2, "", true));
}, 2, "", true);
n3_21 = Fn((V _arrowThis1045, int _argc1038, V v_1044, V _a1041, V _a1042, V _a1043, V[] _rest1039) => {
return ((V)((Round((ToNum(v_1044) * 1000D)) / 1000D)));
}, 1, "", true);
pd_22 = Fn((V _arrowThis1057, int _argc1046, V d_1052, V f_1053, V s_1054, V w_1055, V[] _rest1047) => {
V o_1056 = default;
o_1056 = (_argc1046 > 4 ? _rest1047[0] : V.Undef);
return NewObj(5).Put("d", d_1052).Put("f", f_1053).Put("s", (s_1054 is var _t1058 && Truthy(_t1058) ? _t1058 : ((V)("none")))).Put("w", (w_1055 is var _t1059 && Truthy(_t1059) ? _t1059 : ((V)(0D)))).Put("o", (o_1056.IsNullish ? ((V)(1D)) : o_1056)).V;
}, 5, "", true);
esc_23 = Fn((V _arrowThis1067, int _argc1060, V s_1066, V _a1063, V _a1064, V _a1065, V[] _rest1061) => {
return Invoke(Invoke(Invoke(((V)(ToStrS(s_1066))), "replace", NewRegExp(RX2, "&", "g"), ((V)("&amp;"))), "replace", NewRegExp(RX1, "\"", "g"), ((V)("&quot;"))), "replace", NewRegExp(RX0, "<", "g"), ((V)("&lt;")));
}, 1, "", true);
P_24 = Fn((V _arrowThis1079, int _argc1068, V d_1074, V f_1075, V s_1076, V w_1077, V[] _rest1069) => {
V ex_1078 = default;
ex_1078 = (_argc1068 > 4 ? _rest1069[0] : V.Undef);
return ((V)(string.Concat("<path d=\"", ToStr(d_1074), "\" fill=\"", ToStr((f_1075 is var _t1080 && Truthy(_t1080) ? _t1080 : ((V)("none")))), "\"", (Truthy(s_1076) ? string.Concat(" stroke=\"", ToStr(s_1076), "\" stroke-width=\"", ToStr((w_1077 is var _t1081 && Truthy(_t1081) ? _t1081 : ((V)(1D)))), "\" stroke-linejoin=\"round\" stroke-linecap=\"round\"") : ""), ToStr((ex_1078 is var _t1082 && Truthy(_t1082) ? _t1082 : ((V)("")))), "/>")));
}, 5, "", true);
AT_25 = Fn((V _arrowThis1094, int _argc1083, V type_1089, V vals_1090, V d_1091, V b_1092, V[] _rest1084) => {
V ex_1093 = default;
ex_1093 = (_argc1083 > 4 ? _rest1084[0] : V.Undef);
return ((V)(string.Concat("<animateTransform attributeName=\"transform\" type=\"", ToStr(type_1089), "\" values=\"", ToStr(vals_1090), "\" dur=\"", ToStr(Call(n3_21, V.Undef, d_1091)), "s\"", (Truthy(b_1092) ? string.Concat(" begin=\"", ToStr(Call(n3_21, V.Undef, b_1092)), "s\"") : ""), " repeatCount=\"indefinite\"", ToStr((ex_1093 is var _t1095 && Truthy(_t1095) ? _t1095 : ((V)("")))), "/>")));
}, 5, "", true);
AN_26 = Fn((V _arrowThis1107, int _argc1096, V a_1102, V vals_1103, V d_1104, V b_1105, V[] _rest1097) => {
V ex_1106 = default;
ex_1106 = (_argc1096 > 4 ? _rest1097[0] : V.Undef);
return ((V)(string.Concat("<animate attributeName=\"", ToStr(a_1102), "\" values=\"", ToStr(vals_1103), "\" dur=\"", ToStr(Call(n3_21, V.Undef, d_1104)), "s\"", (Truthy(b_1105) ? string.Concat(" begin=\"", ToStr(Call(n3_21, V.Undef, b_1105)), "s\"") : ""), " repeatCount=\"indefinite\"", ToStr((ex_1106 is var _t1108 && Truthy(_t1108) ? _t1108 : ((V)("")))), "/>")));
}, 5, "", true);
SPL_27 = Fn((V _arrowThis1116, int _argc1109, V n_1115, V _a1112, V _a1113, V _a1114, V[] _rest1110) => {
return ((V)(string.Concat(" calcMode=\"spline\" keyTimes=\"", ToStr(Invoke(Call(rep_20, V.Undef, Add(n_1115, ((V)(1D))), Fn((V _arrowThis1124, int _argc1117, V i_1123, V _a1120, V _a1121, V _a1122, V[] _rest1118) => {
return Call(n3_21, V.Undef, ((V)((ToNum(i_1123) / ToNum(n_1115)))));
}, 1, "", true)), "join", ((V)(";")))), "\" keySplines=\"", ToStr(Invoke(Call(rep_20, V.Undef, n_1115, Fn((V _arrowThis1131, int _argc1125, V _a1127, V _a1128, V _a1129, V _a1130, V[] _rest1126) => {
return ((V)("0.45 0 0.55 1"));
}, 0, "", true)), "join", ((V)(";")))), "\"")));
}, 1, "", true);
circ_28 = Fn((V _arrowThis1141, int _argc1132, V x_1138, V y_1139, V r_1140, V _a1137, V[] _rest1133) => {
return ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_1138) - ToNum(r_1140)))))), " ", ToStr(Call(f1_10, V.Undef, y_1139)), "a", ToStr(Call(f1_10, V.Undef, r_1140)), " ", ToStr(Call(f1_10, V.Undef, r_1140)), " 0 1 0 ", ToStr(Call(f1_10, V.Undef, ((V)((2D * ToNum(r_1140)))))), " 0a", ToStr(Call(f1_10, V.Undef, r_1140)), " ", ToStr(Call(f1_10, V.Undef, r_1140)), " 0 1 0 ", ToStr(Call(f1_10, V.Undef, ((V)(((-2D) * ToNum(r_1140)))))), " 0Z")));
}, 3, "", true);
ell_29 = Fn((V _arrowThis1152, int _argc1142, V x_1148, V y_1149, V rx_1150, V ry_1151, V[] _rest1143) => {
return ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(x_1148) - ToNum(rx_1150)))))), " ", ToStr(Call(f1_10, V.Undef, y_1149)), "a", ToStr(Call(f1_10, V.Undef, rx_1150)), " ", ToStr(Call(f1_10, V.Undef, ry_1151)), " 0 1 0 ", ToStr(Call(f1_10, V.Undef, ((V)((2D * ToNum(rx_1150)))))), " 0a", ToStr(Call(f1_10, V.Undef, rx_1150)), " ", ToStr(Call(f1_10, V.Undef, ry_1151)), " 0 1 0 ", ToStr(Call(f1_10, V.Undef, ((V)(((-2D) * ToNum(rx_1150)))))), " 0Z")));
}, 4, "", true);
rr_30 = Fn((V _arrowThis1164, int _argc1153, V x_1159, V y_1160, V w_1161, V h_1162, V[] _rest1154) => {
V r_1163 = default;
r_1163 = (_argc1153 > 4 ? _rest1154[0] : V.Undef);
r_1163 = ((V)(Min(ToNum(r_1163), (ToNum(w_1161) / 2D), (ToNum(h_1162) / 2D))));
return ((V)(string.Concat("M", ToStr(Call(f1_10, V.Undef, Add(x_1159, r_1163))), " ", ToStr(Call(f1_10, V.Undef, y_1160)), "H", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(Add(x_1159, w_1161)) - ToNum(r_1163)))))), "A", ToStr(r_1163), " ", ToStr(r_1163), " 0 0 1 ", ToStr(Call(f1_10, V.Undef, Add(x_1159, w_1161))), " ", ToStr(Call(f1_10, V.Undef, Add(y_1160, r_1163))), "V", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(Add(y_1160, h_1162)) - ToNum(r_1163)))))), "A", ToStr(r_1163), " ", ToStr(r_1163), " 0 0 1 ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(Add(x_1159, w_1161)) - ToNum(r_1163)))))), " ", ToStr(Call(f1_10, V.Undef, Add(y_1160, h_1162))), "H", ToStr(Call(f1_10, V.Undef, Add(x_1159, r_1163))), "A", ToStr(r_1163), " ", ToStr(r_1163), " 0 0 1 ", ToStr(Call(f1_10, V.Undef, x_1159)), " ", ToStr(Call(f1_10, V.Undef, ((V)((ToNum(Add(y_1160, h_1162)) - ToNum(r_1163)))))), "V", ToStr(Call(f1_10, V.Undef, Add(y_1160, r_1163))), "A", ToStr(r_1163), " ", ToStr(r_1163), " 0 0 1 ", ToStr(Call(f1_10, V.Undef, Add(x_1159, r_1163))), " ", ToStr(Call(f1_10, V.Undef, y_1160)), "Z")));
return default;
}, 5, "", true);
stp_31 = Fn((V _arrowThis1172, int _argc1165, V s_1171, V _a1168, V _a1169, V _a1170, V[] _rest1166) => {
return Invoke(Invoke(s_1171, "map", Fn((V _arrowThis1180, int _argc1173, V q_1179, V _a1176, V _a1177, V _a1178, V[] _rest1174) => {
return ((V)(string.Concat("<stop offset=\"", ToStr(GetIdx(q_1179, 0D)), "\" stop-color=\"", ToStr(GetIdx(q_1179, 1D)), "\"", (!GetIdx(q_1179, 2D).IsNullish ? string.Concat(" stop-opacity=\"", ToStr(GetIdx(q_1179, 2D)), "\"") : ""), "/>")));
}, 1, "", true)), "join", ((V)("")));
}, 1, "", true);
LG_32 = Fn((V _arrowThis1190, int _argc1181, V id_1187, V s_1188, V a_1189, V _a1186, V[] _rest1182) => {
return ((V)(string.Concat("<linearGradient id=\"", ToStr(id_1187), "\" ", ToStr((a_1189 is var _t1191 && Truthy(_t1191) ? _t1191 : ((V)("x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"")))), ">", ToStr(Call(stp_31, V.Undef, s_1188)), "</linearGradient>")));
}, 3, "", true);
RG_33 = Fn((V _arrowThis1201, int _argc1192, V id_1198, V s_1199, V a_1200, V _a1197, V[] _rest1193) => {
return ((V)(string.Concat("<radialGradient id=\"", ToStr(id_1198), "\" ", ToStr((a_1200 is var _t1202 && Truthy(_t1202) ? _t1202 : ((V)("cx=\"50%\" cy=\"50%\" r=\"50%\"")))), ">", ToStr(Call(stp_31, V.Undef, s_1199)), "</radialGradient>")));
}, 3, "", true);
SO_34 = 540D;
BY0_35 = 104D;
BM_36 = 22D;
shore_37 = Fn((V _arrowThis1210, int _argc1203, V y_1209, V _a1206, V _a1207, V _a1208, V[] _rest1204) => {
return ((V)((GeN(y_1209, 100D) ? ((SO_34 + (0.95 * (ToNum(y_1209) - 100D))) - ((0.0009 * (ToNum(y_1209) - 100D)) * (ToNum(y_1209) - 100D))) : (SO_34 - ((100D - ToNum(y_1209)) * 2.4)))));
}, 1, "", true);
PIER_38 = NewObj(7).Put("y0", ((V)(226D))).Put("y1", ((V)(248D))).Put("py0", ((V)(212D))).Put("py1", ((V)(258D))).Put("xe", ((V)(742D))).Put("xp1", ((V)(828D))).Put("face", ((V)(7D))).V;
Set(PIER_38, "x0", ((V)(Round((ToNum(Call(shore_37, V.Undef, ((V)(237D)))) - 58D)))));
FISH_39 = Arr(NewObj(3).Put("x", ((V)(806D))).Put("y", ((V)(232D))).Put("face", ((V)(90D))).V, NewObj(3).Put("x", ((V)(770D))).Put("y", ((V)(250D))).Put("face", ((V)(20D))).V);
B_40 = NewObj(1).Put("season", ((V)("sunny"))).V;
ice_41 = Fn((V _arrowThis1217, int _argc1211, V _a1213, V _a1214, V _a1215, V _a1216, V[] _rest1212) => {
return ((V)((SEqS(Get(B_40, "season"), "snowy") ? 62D : 0D)));
}, 0, "", true);
onPier_42 = Fn((V _arrowThis1226, int _argc1218, V x_1224, V y_1225, V _a1222, V _a1223, V[] _rest1219) => {
return (((((Ge(x_1224, Add(Get(PIER_38, "x0"), ((V)(4D)))) && Le(x_1224, Add(Get(PIER_38, "xe"), ((V)(2D))))) && Ge(y_1225, Add(Get(PIER_38, "y0"), ((V)(2D))))) && LeN(y_1225, (ToNum(Get(PIER_38, "y1")) - 2D))) || (((GtN(x_1224, (ToNum(Get(PIER_38, "xe")) - 6D)) && LeN(x_1224, (ToNum(Get(PIER_38, "xp1")) - 6D))) && Ge(y_1225, Add(Get(PIER_38, "py0"), ((V)(4D))))) && LeN(y_1225, (ToNum(Get(PIER_38, "py1")) - 4D)))) ? V.True : V.False);
}, 2, "", true);
inSea_43 = Fn((V _arrowThis1235, int _argc1227, V x_1233, V y_1234, V _a1231, V _a1232, V[] _rest1228) => {
return (Gt(x_1233, Add(Call(shore_37, V.Undef, y_1234), Call(ice_41, V.Undef))) ? V.True : V.False);
}, 2, "", true);
wet_44 = Fn((V _arrowThis1244, int _argc1236, V x_1242, V y_1243, V _a1240, V _a1241, V[] _rest1237) => {
return (Call(inSea_43, V.Undef, x_1242, y_1243) is var _t1245 && !Truthy(_t1245) ? _t1245 : (!(Truthy(Call(onPier_42, V.Undef, x_1242, y_1243))) ? V.True : V.False));
}, 2, "", true);
nearPier_45 = Fn((V _arrowThis1254, int _argc1246, V x_1252, V y_1253, V _a1250, V _a1251, V[] _rest1247) => {
return (((((Ge(x_1252, Get(PIER_38, "x0")) && Le(x_1252, Get(PIER_38, "xe"))) && GeN(y_1253, (ToNum(Get(PIER_38, "y0")) - 8D))) && Le(y_1253, Add(Get(PIER_38, "y1"), ((V)(8D))))) || (((GtN(x_1252, (ToNum(Get(PIER_38, "xe")) - 6D)) && Le(x_1252, Add(Get(PIER_38, "xp1"), ((V)(10D))))) && GeN(y_1253, (ToNum(Get(PIER_38, "py0")) - 8D))) && Le(y_1253, Add(Get(PIER_38, "py1"), ((V)(8D)))))) ? V.True : V.False);
}, 2, "", true);
polySvg_51 = Fn((V _arrowThis1262, int _argc1255, V L_1261, V _a1258, V _a1259, V _a1260, V[] _rest1256) => {
return Invoke(Invoke(L_1261, "map", Fn((V _arrowThis1270, int _argc1263, V p_1269, V _a1266, V _a1267, V _a1268, V[] _rest1264) => {
return Call(P_24, V.Undef, Get(p_1269, "d"), Get(p_1269, "f"), (!SEqS(Get(p_1269, "s"), "none") ? Get(p_1269, "s") : ((V)(""))), Get(p_1269, "w"), ((V)((!SEqN(Get(p_1269, "o"), 1D) ? string.Concat(" opacity=\"", ToStr(Get(p_1269, "o")), "\"") : ""))));
}, 1, "", true)), "join", ((V)("")));
}, 1, "", true);
textSvg_52 = Fn((V _arrowThis1278, int _argc1271, V t_1277, V _a1274, V _a1275, V _a1276, V[] _rest1272) => {
return ((V)(string.Concat("<text x=\"", ToStr(Call(f1_10, V.Undef, Get(t_1277, "x"))), "\" y=\"", ToStr(Call(f1_10, V.Undef, Get(t_1277, "y"))), "\" text-anchor=\"middle\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"", ToStr(Get(t_1277, "sz")), "\" fill=\"", ToStr(Get(t_1277, "f")), "\">", ToStr(Call(esc_23, V.Undef, Get(t_1277, "t"))), "</text>")));
}, 1, "", true);
SKY_53 = NewObj(3).Put("sunny", Arr(((V)("#68bdf0")), ((V)("#d4f0fb")))).Put("rainy", Arr(((V)("#7d8c99")), ((V)("#c4ccd2")))).Put("snowy", Arr(((V)("#9cbcd2")), ((V)("#eaf2f6")))).V;
SEA_54 = NewObj(3).Put("sunny", Arr(((V)("#b4e6f2")), ((V)("#1f93d2")), ((V)("#3cb8e6")), ((V)("#74e2e2")))).Put("rainy", Arr(((V)("#a6b8c0")), ((V)("#285f80")), ((V)("#36809e")), ((V)("#5aa6b2")))).Put("snowy", Arr(((V)("#d8eef4")), ((V)("#3f8cbc")), ((V)("#5aaad2")), ((V)("#94d6e6")))).V;
SAND_55 = Arr(((V)("#d4c09a")), ((V)("#f0cf8a")), ((V)("#f6e8ca")), ((V)("#f4cfbe")), ((V)("#f3dca4")));
NIGHT_56 = ((V)("#0f1a40"));
PIERS_57 = Arr(NewObj(7).Put("n", ((V)("drift"))).Put("a", ((V)("#a8977c"))).Put("b", ((V)("#968670"))).Put("e", ((V)("#6a5c48"))).Put("face", ((V)("#7a6a54"))).Put("post", ((V)("#5e5040"))).Put("rail", ((V)(0D))).V, NewObj(7).Put("n", ((V)("board"))).Put("a", ((V)("#dcb880"))).Put("b", ((V)("#cfa86e"))).Put("e", ((V)("#8a6a3e"))).Put("face", ((V)("#a8804c"))).Put("post", ((V)("#7a5a34"))).Put("rail", ((V)("rope"))).V, NewObj(7).Put("n", ((V)("white"))).Put("a", ((V)("#f4f2ec"))).Put("b", ((V)("#e8e6de"))).Put("e", ((V)("#9aa4b0"))).Put("face", ((V)("#3f7fc8"))).Put("post", ((V)("#e8e6de"))).Put("rail", ((V)("white"))).V, NewObj(7).Put("n", ((V)("teak"))).Put("a", ((V)("#c27a42"))).Put("b", ((V)("#b06a36"))).Put("e", ((V)("#6a3a18"))).Put("face", ((V)("#8a4e24"))).Put("post", ((V)("#5a3418"))).Put("rail", ((V)("teak"))).V, NewObj(7).Put("n", ((V)("marble"))).Put("a", ((V)("#f6f2ea"))).Put("b", ((V)("#ebe4d6"))).Put("e", ((V)("#c9b48a"))).Put("face", ((V)("#e2d6bc"))).Put("post", ((V)("#e2b14a"))).Put("rail", ((V)("gold"))).V);
SHELLK_60 = Arr(Arr(((V)("#ffd2c4")), ((V)("#e8907a"))), Arr(((V)("#fff1d8")), ((V)("#d8b480"))), Arr(((V)("#ffc6dc")), ((V)("#d8708e"))), Arr(((V)("#cfeefb")), ((V)("#6aa8c8"))), Arr(((V)("#ffe9a0")), ((V)("#d8a440"))));
SNOWMEN_63 = Arr(Arr(((V)(210D)), ((V)(286D))), Arr(((V)(120D)), ((V)(214D))));
Set(Get(X_8, "ROOMS"), "beach", NewObj(8).Put("name", ((V)("Beach"))).Put("unlock", ((V)(LV_15))).Put("out", ((V)(1D))).Put("beach", ((V)(1D))).Put("visit", ((V)(1D))).Put("doors", Arr(NewObj(3).Put("s", ((V)("L"))).Put("to", ((V)("backyard"))).Put("lab", ((V)("BACKYARD"))).V)).Put("start", Arr(Arr(((V)("")), ((V)(230D)), ((V)(210D))), Arr(((V)("")), ((V)(330D)), ((V)(262D))), Arr(((V)("")), ((V)(170D)), ((V)(300D))))).Put("toys", Arr(Arr(((V)("ball")), ((V)(380D)), ((V)(300D))))).V);
if (!(Truthy(Invoke(Get(X_8, "RKEYS"), "includes", ((V)("beach")))))) {
Invoke(Get(X_8, "RKEYS"), "push", ((V)("beach")));
}
if (Truthy(Get(X_8, "NAME"))) {
Set(Get(X_8, "NAME"), "beach", ((V)("BEACH")));
}
shell0_65 = Get(X_8, "shell");
AUG_66 = New(G("WeakMap"));
BSH_67 = NewObj(0).V;
Set(X_8, "shell", Fn((V _self1279, int _argc1280, V rk_1286, V sf_1287, V lockOf_1288, V _a1285, V[] _rest1281) => {
V sh_1289 = default;
V lk_1290 = default;
V m_1291 = default;
V g_1292 = default;
if (_self1279.IsNullish) _self1279 = GlobalV;
if (SEqS(rk_1286, "beach")) {
return Call(beachShell_68, V.Undef);
}
sh_1289 = Call(shell0_65, V.Undef, rk_1286, sf_1287, lockOf_1288);
if (((!SEqS(rk_1286, "backyard") || !(Truthy(sh_1289))) || !(Truthy(Get(G("window"), "BEACH_GATE"))))) {
return sh_1289;
}
lk_1290 = (Truthy(lockOf_1288) ? (Call(lockOf_1288, V.Undef, ((V)("beach"))) is var _t1293 && Truthy(_t1293) ? _t1293 : ((V)(0D))) : ((V)(0D)));
m_1291 = Invoke(AUG_66, "get", sh_1289);
if (!(Truthy(m_1291))) {
Invoke(AUG_66, "set", sh_1289, (m_1291 = NewObj(0).V));
}
if (Truthy(GetK(m_1291, lk_1290))) {
return GetK(m_1291, lk_1290);
}
g_1292 = Call(gate_50, V.Undef, ((V)("R")), lk_1290, ((V)((Truthy(lk_1290) ? JsStrBuf.Begin().S("Lv ").V(lk_1290).S(" \u00b7 BEACH").End() : "BEACH"))));
return SetK(m_1291, lk_1290, Object_assign(NewObj(0).V, sh_1289, NewObj(3).Put("decor", Invoke(Get(sh_1289, "decor"), "concat", Get(g_1292, "polys"))).Put("texts", Invoke(Get(sh_1289, "texts"), "concat", Get(g_1292, "texts"))).Put("doors", Invoke((Get(sh_1289, "doors") is var _t1294 && Truthy(_t1294) ? _t1294 : Arr()), "concat", Arr(NewObj(6).Put("id", ((V)("g-beach"))).Put("to", ((V)("beach"))).Put("hit", Get(g_1292, "hit")).Put("spawn", Get(g_1292, "spawn")).Put("walk", Get(g_1292, "walk")).Put("lock", lk_1290).V))).V));
return default;
}, 3, "", false));
Set(G("window"), "Beach", NewObj(24).Put("LV", ((V)(LV_15))).Put("PIER", PIER_38).Put("FISH", FISH_39).Put("shore", shore_37).Put("onPier", onPier_42).Put("inSea", inSea_43).Put("wet", wet_44).Put("clamp", clamp_46).Put("randSand", randSand_47).Put("randSea", randSea_48).Put("itemX", itemX_49).Put("nearPier", nearPier_45).Put("scene", scene_58).Put("thumb", thumb_59).Put("props", props_64).Put("shellSvg", shellSvg_61).Put("SHELLK", SHELLK_60).Put("gate", gate_50).Put("WY", WY_16).Put("rng", rng_19).Put("setSeason", Fn((V _arrowThis1302, int _argc1295, V s_1301, V _a1298, V _a1299, V _a1300, V[] _rest1296) => {
Set(B_40, "season", (s_1301 is var _t1303 && Truthy(_t1303) ? _t1303 : ((V)("sunny"))));
return default;
}, 1, "setSeason", true)).Put("season", Fn((V _arrowThis1310, int _argc1304, V _a1306, V _a1307, V _a1308, V _a1309, V[] _rest1305) => {
return Get(B_40, "season");
}, 0, "season", true)).Put("ice", ice_41).Put("ready", ((V)(1D))).V);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
