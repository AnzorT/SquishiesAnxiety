// house4-rooms.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house4_rooms_js
    {

        public static void Run()
        {
Call(Named(boot_1216 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V X_8 = default;
V K_9 = default;
V mix_10 = default;
V shade_11 = default;
V f1_12 = default;
V circ_13 = default;
V ell_14 = default;
V CR_15 = default;
V WH_16 = default;
V GOLD_17 = default;
double VW_18 = 0;
V FY0_19 = default;
V pd_20 = default;
V rr_21 = default;
double BL_22 = 0;
double BR_23 = 0;
V WY_24 = default;
V sideB_25 = default;
V lum_26 = default;
V SPEC_27 = default;
V DEF_28 = default;
V SLOTS_IN_29 = default;
V SLOTS_OUT_30 = default;
V ROOMS_31 = default;
V RKEYS_32 = default;
V NAME_33 = default;
V YARD_34 = default;
V slotsOf_35 = default;
V specOf_36 = default;
V palette_37 = default;
V curtains_38 = default;
V hill_39 = default;
V window__40 = default;
V light_41 = default;
V art_42 = default;
V rust_43 = default;
V @fixed_44 = default;
V fence_45 = default;
V qb_46 = default;
V ylights_47 = default;
V ARROW_48 = default;
V SIGN_49 = default;
V SHAPE_50 = default;
V outl_51 = default;
V ell2_52 = default;
V box2_53 = default;
V door_54 = default;
double SC_55 = 0;
V ST_56 = default;
V PW_57 = default;
V wp_58 = default;
V WT_59 = default;
V WF_60 = default;
V WS_61 = default;
V WE_62 = default;
V RL_63 = default;
V RD_64 = default;
V NOSE_65 = default;
V upStairs_66 = default;
V downStairs_67 = default;
V @lock_68 = default;
V boards_69 = default;
V rowsK_70 = default;
V floor_71 = default;
V SH_72 = default;
V shell_73 = default;
V MOTIF_74 = default;
V swatch_75 = default;
if (_self1.IsNullish) _self1 = GlobalV;
palette_37 = Fn((V _self76, int _argc77, V rk_83, V sf_84, V _a81, V _a82, V[] _rest78) => {
V w_85 = default;
V t_86 = default;
V f_87 = default;
V d_88 = default;
if (_self76.IsNullish) _self76 = GlobalV;
if (Truthy(Get(GetK(ROOMS_31, rk_83), "out"))) {
V g_89 = default;
g_89 = Call(specOf_36, V.Undef, ((V)("ground")), Get(sf_84, "ground"));
return Object_assign(NewObj(0).V, YARD_34, NewObj(9).Put("f0", Get(g_89, "f0")).Put("f1", Get(g_89, "f1")).Put("f2", Get(g_89, "f2")).Put("fl", Get(g_89, "fl")).Put("fd", Get(g_89, "fd")).Put("fli", Get(g_89, "fli")).Put("op", Get(g_89, "op")).Put("door", ((V)("#84b6c9"))).Put("doorL", ((V)("#b4d6e2"))).V);
}
w_85 = Call(specOf_36, V.Undef, ((V)("wall")), Get(sf_84, "wall"));
t_86 = Call(specOf_36, V.Undef, ((V)("trim")), Get(sf_84, "trim"));
f_87 = Call(specOf_36, V.Undef, ((V)("floor")), Get(sf_84, "floor"));
d_88 = Call(specOf_36, V.Undef, ((V)("door")), Get(sf_84, "door"));
return NewObj(22).Put("b0", Get(w_85, "b0")).Put("b1", Get(w_85, "b1")).Put("l0", Call(mix_10, V.Undef, Get(w_85, "b0"), ((V)("#ffffff")), ((V)(0.12)))).Put("l1", Get(w_85, "b0")).Put("r0", Call(shade_11, V.Undef, Get(w_85, "b0"), ((V)(0.88)))).Put("r1", Call(shade_11, V.Undef, Get(w_85, "b0"), ((V)(0.94)))).Put("pat", Get(w_85, "pc")).Put("w0", Get(t_86, "w0")).Put("w1", Get(t_86, "w1")).Put("wr0", Call(shade_11, V.Undef, Get(t_86, "w0"), ((V)(0.9)))).Put("wr1", Call(shade_11, V.Undef, Get(t_86, "w1"), ((V)(0.9)))).Put("trim", Get(t_86, "trim")).Put("f0", Get(f_87, "f0")).Put("f1", Get(f_87, "f1")).Put("f2", Get(f_87, "f2")).Put("fl", Get(f_87, "fl")).Put("fd", Get(f_87, "fd")).Put("fli", Get(f_87, "fli")).Put("op", Get(f_87, "op")).Put("door", Get(d_88, "c")).Put("doorL", Get(d_88, "cl")).Put("edge", (LtN(Call(lum_26, V.Undef, Get(f_87, "f1")), 0.35) ? ((V)("#000000")) : Call(shade_11, V.Undef, Get(f_87, "f0"), ((V)(0.45))))).V;
return default;
}, 2, "palette", false);
curtains_38 = Fn((V _self90, int _argc91, V o_97, V x_98, V y_99, V w_100, V[] _rest92) => {
V D_103 = default;
V h_101 = default;
V c_102 = default;
if (_self90.IsNullish) _self90 = GlobalV;
h_101 = (_argc91 > 4 ? _rest92[0] : V.Undef);
c_102 = (_argc91 > 5 ? _rest92[1] : V.Undef);
D_103 = Call(shade_11, V.Undef, c_102, ((V)(0.85)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis111, int _argc104, V s_110, V _a107, V _a108, V _a109, V[] _rest105) => {
V a_112 = default;
V b_113 = default;
a_112 = Add(x_98, ((V)((ToNum(s_110) * ((ToNum(w_100) / 2D) + 16D)))));
b_113 = Add(x_98, ((V)((ToNum(s_110) * ((ToNum(w_100) / 2D) - 6D)))));
Invoke(o_97, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(a_112).S(" ").N((ToNum(y_99) - 8D)).S("H").V(b_113).S("Q").V(Add(b_113, ((V)((ToNum(s_110) * 7D))))).S(" ").V(Add(y_99, ((V)((ToNum(h_101) / 2D))))).S(" ").N((ToNum(b_113) - (ToNum(s_110) * 2D))).S(" ").V(Add(Add(y_99, h_101), ((V)(10D)))).S("H").V(Add(a_112, ((V)((ToNum(s_110) * 3D))))).S("Q").N((ToNum(a_112) - (ToNum(s_110) * 4D))).S(" ").V(Add(y_99, ((V)((ToNum(h_101) / 2D))))).S(" ").V(a_112).S(" ").N((ToNum(y_99) - 8D)).S("Z").End())), c_102, D_103, ((V)(1D))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, ((V)((ToNum(Add(a_112, b_113)) / 2D))))).S(" ").N((ToNum(y_99) - 6D)).S("Q").V(Call(f1_12, V.Undef, ((V)(((ToNum(Add(a_112, b_113)) / 2D) + (ToNum(s_110) * 2D)))))).S(" ").V(Add(y_99, ((V)((ToNum(h_101) / 2D))))).S(" ").V(Call(f1_12, V.Undef, ((V)((ToNum(Add(a_112, b_113)) / 2D))))).S(" ").V(Add(Add(y_99, h_101), ((V)(8D)))).End())), ((V)("none")), D_103, ((V)(1.4)), ((V)(0.8))));
return default;
}, 1, "", true));
Invoke(o_97, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(x_98) - (ToNum(w_100) / 2D)) - 22D))), ((V)((ToNum(y_99) - 11D))), Add(w_100, ((V)(44D))), ((V)(5D)), ((V)(2.5))), ((V)("#b97a42"))));
return default;
}, 6, "curtains", false);
hill_39 = Fn((V _self114, int _argc115, V o_121, V x_122, V y_123, V w_124, V[] _rest116) => {
V h_125 = default;
if (_self114.IsNullish) _self114 = GlobalV;
h_125 = (_argc115 > 4 ? _rest116[0] : V.Undef);
Invoke(o_121, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_122) - (ToNum(w_124) / 2D))).S(" ").V(Add(y_123, ((V)((ToNum(h_125) * 0.78))))).S("Q").V(Call(f1_12, V.Undef, ((V)((ToNum(x_122) - (ToNum(w_124) / 6D)))))).S(" ").V(Call(f1_12, V.Undef, Add(y_123, ((V)((ToNum(h_125) * 0.52)))))).S(" ").V(Call(f1_12, V.Undef, Add(x_122, ((V)((ToNum(w_124) / 8D)))))).S(" ").V(Call(f1_12, V.Undef, Add(y_123, ((V)((ToNum(h_125) * 0.7)))))).S("T").V(Add(x_122, ((V)((ToNum(w_124) / 2D))))).S(" ").V(Call(f1_12, V.Undef, Add(y_123, ((V)((ToNum(h_125) * 0.64)))))).S("V").V(Add(y_123, h_125)).S("H").N((ToNum(x_122) - (ToNum(w_124) / 2D))).S("Z").End())), ((V)("#a8d08a"))));
return default;
}, 5, "hill", false);
window__40 = Fn((V _self126, int _argc127, V o_133, V x_134, V S_135, V _a132, V[] _rest128) => {
V k_136 = default;
double w_137 = 0;
double h_138 = 0;
double y_139 = 0;
if (_self126.IsNullish) _self126 = GlobalV;
k_136 = Get(S_135, "k");
w_137 = (SEqS(k_136, "big") ? 140D : 76D);
h_138 = 46D;
y_139 = 12D;
if (Truthy(Get(S_135, "ir"))) {
V a_140 = default;
V b_141 = default;
V iw_142 = default;
V ih_143 = default;
{ V _t144 = Get(S_135, "ir");
{ V _t145 = ListOf(_t144);
{ V _t146 = GetIdx(_t145, 0D);
a_140 = _t146; }
{ V _t147 = GetIdx(_t145, 1D);
b_141 = _t147; }
{ V _t148 = GetIdx(_t145, 2D);
iw_142 = _t148; }
{ V _t149 = GetIdx(_t145, 3D);
ih_143 = _t149; }
} }
Invoke(o_133, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, Add(x_134, a_140))).S(" ").V(b_141).S("h").V(iw_142).S("v").V(ih_143).S("h").N((-ToNum(iw_142))).S("Z").End())), ((V)("url(#rnWin)"))));
return default;
}
if (SEqS(k_136, "port")) {
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_134, ((V)(36D)), ((V)(28D))), Get(S_135, "fr"), Call(shade_11, V.Undef, Get(S_135, "fr"), ((V)(0.7))), ((V)(1.5))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_134, ((V)(36D)), ((V)(22D))), ((V)("url(#hsSky)"))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)((ToNum(x_134) - 2D))), ((V)(40D)), ((V)(12D)), ((V)(4D))), WH_16, ((V)(0D)), ((V)(0D)), ((V)(0.9))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_134) - 22D)).S(" 46Q").V(x_134).S(" 34 ").V(Add(x_134, ((V)(22D)))).S(" 44").End())), ((V)("none")), ((V)("#a8d08a")), ((V)(6D)), ((V)(0.9))));
{
double i_150 = 0;
i_150 = 0D;
while (true) {
if (!((i_150 < 8D))) break;
double a_152 = 0;
a_152 = (((i_150 / 8D) * System.Math.PI) * 2D);
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_134, ((V)((25D * FdLibm.Cos(a_152))))), ((V)((36D + (25D * FdLibm.Sin(a_152))))), ((V)(1.8))), ((V)("#8a949a"))));
i_150++;
}
}
return default;
}
if (SEqS(k_136, "bonbon")) {
V C_153 = default;
C_153 = Arr(((V)("#cdb8f5")), WH_16, ((V)("#bff0dc")), WH_16, ((V)("#fff1a0")), WH_16, ((V)("#bfe4ff")), WH_16);
Invoke(C_153, "forEach", Fn((V _arrowThis162, int _argc154, V c_160, V i_161, V _a158, V _a159, V[] _rest155) => {
double a0_163 = 0;
double a1_164 = 0;
a0_163 = (((ToNum(i_161) / 8D) * System.Math.PI) * 2D);
a1_164 = (((ToNum(Add(i_161, ((V)(1D)))) / 8D) * System.Math.PI) * 2D);
Invoke(o_133, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_134).S(" 36L").V(Call(f1_12, V.Undef, Add(x_134, ((V)((30D * FdLibm.Cos(a0_163))))))).S(" ").V(Call(f1_12, V.Undef, ((V)((36D + (30D * FdLibm.Sin(a0_163))))))).S("A30 30 0 0 1 ").V(Call(f1_12, V.Undef, Add(x_134, ((V)((30D * FdLibm.Cos(a1_164))))))).S(" ").V(Call(f1_12, V.Undef, ((V)((36D + (30D * FdLibm.Sin(a1_164))))))).S("Z").End())), c_160));
return default;
}, 2, "", true));
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_134, ((V)(36D)), ((V)(23D))), ((V)("url(#hsSky)"))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)((ToNum(x_134) - 6D))), ((V)(30D)), ((V)(9D)), ((V)(4D))), WH_16, ((V)(0D)), ((V)(0D)), ((V)(0.9))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_134) - 23D)).S(" 44Q").V(x_134).S(" 34 ").V(Add(x_134, ((V)(23D)))).S(" 42").End())), ((V)("none")), ((V)("#b4ead2")), ((V)(7D)), ((V)(0.9))));
return default;
}
if (SEqS(k_136, "arch")) {
V a_165 = default;
V b_166 = default;
a_165 = ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_134) - 34D)).S(" 62V36Q").N((ToNum(x_134) - 34D)).S(" 4 ").V(x_134).S(" 4Q").V(Add(x_134, ((V)(34D)))).S(" 4 ").V(Add(x_134, ((V)(34D)))).S(" 36V62Z").End()));
b_166 = ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_134) - 28D)).S(" 58V37Q").N((ToNum(x_134) - 28D)).S(" 10 ").V(x_134).S(" 10Q").V(Add(x_134, ((V)(28D)))).S(" 10 ").V(Add(x_134, ((V)(28D)))).S(" 37V58Z").End()));
Invoke(o_133, "push", Call(pd_20, V.Undef, a_165, ((V)("url(#hsGold)")), ((V)("#c9961f")), ((V)(1.4))), Call(pd_20, V.Undef, b_166, ((V)("url(#hsSky)"))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, Add(x_134, ((V)(10D))), ((V)(24D)), ((V)(9D)), ((V)(4D))), WH_16, ((V)(0D)), ((V)(0D)), ((V)(0.9))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_134).S(" 10V58M").N((ToNum(x_134) - 28D)).S(" 36H").V(Add(x_134, ((V)(28D)))).End())), ((V)("none")), GOLD_17, ((V)(3D))));
Call(curtains_38, V.Undef, o_133, x_134, ((V)(6D)), ((V)(64D)), ((V)(52D)), Get(S_135, "cu"));
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)((ToNum(x_134) - 46D))), ((V)(40D)), ((V)(3.5))), ((V)("url(#hsGold)"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_134, ((V)(46D))), ((V)(40D)), ((V)(3.5))), ((V)("url(#hsGold)"))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_134) - 40D))), ((V)(62D)), ((V)(80D)), ((V)(6D)), ((V)(3D))), GOLD_17));
return default;
}
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(x_134) - (w_137 / 2D)) - 5D))), ((V)((y_139 - 5D))), ((V)((w_137 + 10D))), ((V)((h_138 + 10D))), ((V)((SEqS(k_136, "big") ? 3D : 8D)))), Get(S_135, "fr"), Call(shade_11, V.Undef, Get(S_135, "fr"), ((V)(0.75))), ((V)(1D))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_134) - (w_137 / 2D)))), ((V)(y_139)), ((V)(w_137)), ((V)(h_138)), ((V)((SEqS(k_136, "big") ? 2D : 5D)))), ((V)("url(#hsSky)"))));
if (!SEqS(k_136, "crack")) {
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_134, ((V)((w_137 * 0.28)))), ((V)((y_139 + 12D))), ((V)(6D))), ((V)("#fff1a8"))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)((ToNum(x_134) - (w_137 * 0.2)))), ((V)((y_139 + 14D))), ((V)(11D)), ((V)(4.5))), WH_16));
}
Call(hill_39, V.Undef, o_133, x_134, ((V)(y_139)), ((V)(w_137)), ((V)(h_138)));
if (SEqS(k_136, "crack")) {
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_134) - (w_137 / 2D)))), ((V)(y_139)), ((V)(w_137)), ((V)(h_138)), ((V)(5D))), ((V)("#8a7454")), ((V)(0D)), ((V)(0D)), ((V)(0.28))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_134) - 30D)).S(" ").N((y_139 + 6D)).S("L").N((ToNum(x_134) - 16D)).S(" ").N((y_139 + 18D)).S("L").N((ToNum(x_134) - 22D)).S(" ").N((y_139 + 26D)).S("L").N((ToNum(x_134) - 6D)).S(" ").N((y_139 + 38D)).S("M").N((ToNum(x_134) - 16D)).S(" ").N((y_139 + 18D)).S("L").N((ToNum(x_134) - 4D)).S(" ").N((y_139 + 14D)).End())), ((V)("none")), WH_16, ((V)(1.4)), ((V)(0.9))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Add(x_134, ((V)(6D)))).S(" ").N((y_139 + 4D)).S("L").V(Add(x_134, ((V)(34D)))).S(" ").N((y_139 + 40D)).End())), ((V)("none")), ((V)("#e8dcc0")), ((V)(7D)), ((V)(0.95))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Add(x_134, ((V)(34D)))).S(" ").N((y_139 + 4D)).S("L").V(Add(x_134, ((V)(6D)))).S(" ").N((y_139 + 40D)).End())), ((V)("none")), ((V)("#e8dcc0")), ((V)(7D)), ((V)(0.95))));
}
if (!SEqS(k_136, "big")) {
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_134) - 2D))), ((V)(y_139)), ((V)(4D)), ((V)(h_138)), ((V)(1D))), Get(S_135, "fr")), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_134) - (w_137 / 2D)))), ((V)(((y_139 + (h_138 / 2D)) - 2D))), ((V)(w_137)), ((V)(4D)), ((V)(1D))), Get(S_135, "fr")));
} else {
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(x_134) - (w_137 / 6D)) - 1.5))), ((V)(y_139)), ((V)(3D)), ((V)(h_138)), ((V)(1D))), Get(S_135, "fr")), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(Add(x_134, ((V)((w_137 / 6D))))) - 1.5))), ((V)(y_139)), ((V)(3D)), ((V)(h_138)), ((V)(1D))), Get(S_135, "fr")));
}
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(x_134) - (w_137 / 2D)) - 9D))), ((V)(((y_139 + h_138) + 4D))), ((V)((w_137 + 18D))), ((V)(6D)), ((V)(3D))), (SEqS(k_136, "crack") ? ((V)("#b9ab92")) : Get(S_135, "fr"))));
if ((SEqS(k_136, "curt") || SEqS(k_136, "flower"))) {
Call(curtains_38, V.Undef, o_133, x_134, ((V)(y_139)), ((V)(w_137)), ((V)(h_138)), Get(S_135, "cu"));
}
if (SEqS(k_136, "lace")) {
Call(curtains_38, V.Undef, o_133, x_134, ((V)(y_139)), ((V)(w_137)), ((V)(h_138)), ((V)("#ffffff")));
{
double i_167 = 0;
i_167 = 0D;
while (true) {
if (!((i_167 < 5D))) break;
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)((((ToNum(x_134) - (w_137 / 2D)) - 10D) + ((i_167 % 2D) * 6D)))), ((V)(((y_139 + 6D) + (i_167 * 9D)))), ((V)(1.6))), ((V)("#e6e0d2"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(Add(Add(x_134, ((V)((w_137 / 2D)))), ((V)(6D))), ((V)(((i_167 % 2D) * 4D)))), ((V)(((y_139 + 6D) + (i_167 * 9D)))), ((V)(1.6))), ((V)("#e6e0d2"))));
i_167++;
}
}
}
if (SEqS(k_136, "flower")) {
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(x_134) - (w_137 / 2D)) - 4D))), ((V)(((y_139 + h_138) + 6D))), ((V)((w_137 + 8D))), ((V)(12D)), ((V)(3D))), ((V)("#b97a42"))));
Invoke(Arr(((V)("#e3946a")), ((V)("#f2c255")), CR_15, ((V)("#c4a0e0")), ((V)("#e3946a")), ((V)("#f2c255"))), "forEach", Fn((V _arrowThis177, int _argc169, V c_175, V i_176, V _a173, V _a174, V[] _rest170) => {
double fx_178 = 0;
fx_178 = (((ToNum(x_134) - (w_137 / 2D)) + 6D) + ((ToNum(i_176) * (w_137 - 12D)) / 5D));
Invoke(o_133, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)(fx_178)), ((V)(((y_139 + h_138) + 4D))), ((V)(5.5))), ((V)("#7ab45c"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)(fx_178)), ((V)(((y_139 + h_138) + 2D))), ((V)(3.4))), c_175));
return default;
}, 2, "", true));
}
return default;
}, 3, "window_", false);
light_41 = Fn((V _self179, int _argc180, V o_186, V x_187, V S_188, V sw_189, V[] _rest181) => {
V k_190 = default;
V cord_191 = default;
if (_self179.IsNullish) _self179 = GlobalV;
k_190 = Get(S_188, "k");
cord_191 = Fn((V _arrowThis199, int _argc192, V y_198, V _a195, V _a196, V _a197, V[] _rest193) => {
return Invoke(o_186, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_187).S(" 0V").V(y_198).End())), ((V)("none")), ((V)("#6a5a4a")), ((V)(1.6))));
}, 1, "", true);
if (SEqS(k_190, "none")) {
return default;
}
if (SEqS(k_190, "halo")) {
Invoke(o_186, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_187) - 30D)).S(" 0V30M").V(Add(x_187, ((V)(30D)))).S(" 0V30M").V(x_187).S(" 0V48").End())), ((V)("none")), ((V)("#8a8fa8")), ((V)(1D))));
Invoke(Arr(Arr(((V)(30D)), ((V)(42D)), ((V)(11D)), ((V)("#4fe0d0")), ((V)("#d6fffa"))), Arr(((V)(40D)), ((V)(30D)), ((V)(8D)), ((V)("#8f7bff")), ((V)("#e6e0ff"))), Arr(((V)(48D)), ((V)(18D)), ((V)(5D)), ((V)("#ff4fd8")), ((V)("#ffe0f6")))), "forEach", Fn((V _arrowThis217, int _argc200, V _a202, V _a203, V _a204, V _a205, V[] _rest201) => {
V y_208 = default;
V rx_210 = default;
V ry_212 = default;
V c_214 = default;
V h_216 = default;
{ V _t206 = ListOf(_a202);
{ V _t207 = GetIdx(_t206, 0D);
y_208 = _t207; }
{ V _t209 = GetIdx(_t206, 1D);
rx_210 = _t209; }
{ V _t211 = GetIdx(_t206, 2D);
ry_212 = _t211; }
{ V _t213 = GetIdx(_t206, 3D);
c_214 = _t213; }
{ V _t215 = GetIdx(_t206, 4D);
h_216 = _t215; }
}
return Invoke(o_186, "push", Call(pd_20, V.Undef, Call(ell_14, V.Undef, x_187, y_208, rx_210, ry_212), ((V)("none")), c_214, ((V)(12D)), ((V)(0.2))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, x_187, y_208, rx_210, ry_212), ((V)("none")), c_214, ((V)(4.4))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, x_187, y_208, rx_210, ry_212), ((V)("none")), h_216, ((V)(1.6))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)((ToNum(x_187) - (ToNum(rx_210) * 0.45)))), ((V)((ToNum(y_208) - (ToNum(ry_212) * 0.75)))), ((V)((ToNum(rx_210) * 0.22))), ((V)(1D))), ((V)("#ffffff")), ((V)(0D)), ((V)(0D)), ((V)(0.8))));
}, 1, "", true));
return default;
}
if (SEqS(k_190, "laser")) {
double W_218 = 0;
double Ln_219 = 0;
V C_220 = default;
W_218 = (Truthy(sw_189) ? 36D : 90D);
Ln_219 = (Truthy(sw_189) ? 40D : 230D);
C_220 = Arr(((V)("#ff3b6b")), ((V)("#4fe0d0")), ((V)("#a6f06a")), ((V)("#8f7bff")), ((V)("#ffd66b")));
Invoke(o_186, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_187) - W_218)).S(" 0V8M").V(Add(x_187, ((V)(W_218)))).S(" 0V8").End())), ((V)("none")), ((V)("#6a6f80")), ((V)(1.4))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(x_187) - W_218) - 6D))), ((V)(8D)), ((V)(((2D * W_218) + 12D))), ((V)(7D)), ((V)(2D))), ((V)("#3a3d4a")), ((V)("#22242e")), ((V)(1D))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(((ToNum(x_187) - W_218) - 4D)).S(" 11.5H").V(Add(Add(x_187, ((V)(W_218))), ((V)(4D)))).End())), ((V)("none")), ((V)("#6a6f80")), ((V)(0.8))));
{
double i_221 = 0;
i_221 = 0D;
while (true) {
if (!((i_221 < 5D))) break;
double h0_223 = 0;
V c_224 = default;
h0_223 = ((ToNum(x_187) - W_218) + ((i_221 * W_218) / 2D));
c_224 = GetIdx(C_220, i_221);
{
double j_225 = 0;
j_225 = (-1D);
while (true) {
if (!((j_225 <= 1D))) break;
double ex_227 = 0;
double ey_228 = 0;
V dl_229 = default;
ex_227 = ((h0_223 + (j_225 * (Truthy(sw_189) ? 9D : 70D))) + ((i_221 - 2D) * (Truthy(sw_189) ? 3D : 24D)));
ey_228 = (15D + Ln_219);
dl_229 = ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, ((V)(h0_223)))).S(" 18L").V(Call(f1_12, V.Undef, ((V)(ex_227)))).S(" ").V(Call(f1_12, V.Undef, ((V)(ey_228)))).End()));
Invoke(o_186, "push", Call(pd_20, V.Undef, dl_229, ((V)("none")), c_224, ((V)(3.6)), ((V)(0.16))), Call(pd_20, V.Undef, dl_229, ((V)("none")), c_224, ((V)(1D)), ((V)(0.8))));
if (!(Truthy(sw_189))) {
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)(ex_227)), ((V)(ey_228)), ((V)(5D)), ((V)(2D))), c_224, ((V)(0D)), ((V)(0D)), ((V)(0.5))));
}
j_225++;
}
}
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((h0_223 - 5D))), ((V)(14D)), ((V)(10D)), ((V)(6D)), ((V)(2D))), ((V)("#22242e"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)(h0_223)), ((V)(19D)), ((V)(2.2))), c_224));
i_221++;
}
}
return default;
}
if (SEqS(k_190, "truss")) {
double W_230 = 0;
double Ln_231 = 0;
V C_232 = default;
double n_233 = 0;
JsStrBuf z_234 = null;
W_230 = (Truthy(sw_189) ? 40D : 110D);
Ln_231 = (Truthy(sw_189) ? 36D : 170D);
C_232 = Arr(((V)("#ff9d4a")), ((V)("#4fe0d0")), ((V)("#ff4fd8")), ((V)("#ffd66b")), ((V)("#6ac8ff")));
n_233 = (Truthy(sw_189) ? 3D : 5D);
Invoke(o_186, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(((ToNum(x_187) - W_230) + 10D)).S(" 0V6M").N((ToNum(Add(x_187, ((V)(W_230)))) - 10D)).S(" 0V6").End())), ((V)("none")), ((V)("#9aa0ae")), ((V)(1.4))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_187) - W_230))), ((V)(6D)), ((V)((2D * W_230))), ((V)(10D)), ((V)(1.5))), ((V)("#c9cfd8")), ((V)("#7a8090")), ((V)(1D))));
z_234 = new JsStrBuf("");
{
double i_235 = 0;
i_235 = 0D;
while (true) {
if (!((i_235 <= (2D * W_230)))) break;
z_234.S((NumTruthy(i_235) ? "L" : "M")).V(Call(f1_12, V.Undef, ((V)(((ToNum(x_187) - W_230) + i_235))))).S(" ").N((NumTruthy(((i_235 / 8D) % 2D)) ? 15D : 7D));
i_235 = (i_235 + 8D);
}
}
Invoke(o_186, "push", Call(pd_20, V.Undef, ((V)(z_234.Str)), ((V)("none")), ((V)("#7a8090")), ((V)(1D))));
{
double i_237 = 0;
i_237 = 0D;
while (true) {
if (!((i_237 < n_233))) break;
double h0_239 = 0;
V c_240 = default;
double tx_241 = 0;
double sp_242 = 0;
h0_239 = (((ToNum(x_187) - W_230) + 14D) + ((i_237 * ((2D * W_230) - 28D)) / (n_233 - 1D)));
c_240 = GetIdx(C_232, i_237);
tx_241 = (h0_239 + ((i_237 - ((n_233 - 1D) / 2D)) * (Truthy(sw_189) ? 6D : 34D)));
sp_242 = (Truthy(sw_189) ? 9D : 34D);
Invoke(o_186, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, ((V)((h0_239 - 4D))))).S(" 26L").V(Call(f1_12, V.Undef, ((V)((tx_241 - sp_242))))).S(" ").N((26D + Ln_231)).S("L").V(Call(f1_12, V.Undef, ((V)((tx_241 + sp_242))))).S(" ").N((26D + Ln_231)).S("L").V(Call(f1_12, V.Undef, ((V)((h0_239 + 4D))))).S(" 26Z").End())), c_240, ((V)(0D)), ((V)(0D)), ((V)(0.14))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, ((V)((h0_239 - 7D))))).S(" 16V24M").V(Call(f1_12, V.Undef, ((V)((h0_239 + 7D))))).S(" 16V24").End())), ((V)("none")), ((V)("#2c2e38")), ((V)(2D))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)(h0_239)), ((V)(23D)), ((V)(6.5))), ((V)("#2c2e38")), ((V)("#1a1b22")), ((V)(1D))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)(h0_239)), ((V)(24.5)), ((V)(3.6))), c_240), Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)((h0_239 - 1.2))), ((V)(23.4)), ((V)(1.2))), WH_16, ((V)(0D)), ((V)(0D)), ((V)(0.9))));
i_237++;
}
}
return default;
}
if (SEqS(k_190, "crys")) {
V R_243 = default;
Call(cord_191, V.Undef, ((V)(8D)));
R_243 = Arr(((V)("#bff0ff")), ((V)("#e6d9ff")), ((V)("#ffe0f6")), ((V)("#fff1b8")), ((V)("#c8ffe6")));
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)(34D)), ((V)(46D))), ((V)("url(#gNeon)")), ((V)(0D)), ((V)(0D)), ((V)(0.7))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, x_187, ((V)(22D)), ((V)(34D)), ((V)(7D))), ((V)("none")), GOLD_17, ((V)(3D))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, x_187, ((V)(34D)), ((V)(22D)), ((V)(5D))), ((V)("none")), GOLD_17, ((V)(2.4))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_187).S(" 8V40").End())), ((V)("none")), GOLD_17, ((V)(2.4))));
{
double i_244 = 0;
i_244 = 0D;
while (true) {
if (!((i_244 < 9D))) break;
double a_246 = 0;
double dx_247 = 0;
double dy_248 = 0;
double Lq_249 = 0;
a_246 = (((i_244 / 9D) * System.Math.PI) * 2D);
dx_247 = (FdLibm.Cos(a_246) * 34D);
dy_248 = (22D + (FdLibm.Sin(a_246) * 7D));
Lq_249 = (10D + ((i_244 % 3D) * 5D));
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_187, ((V)(dx_247))), ((V)((dy_248 + (Lq_249 * 0.5)))), ((V)(5.5))), GetIdx(R_243, (i_244 % 5D)), ((V)(0D)), ((V)(0D)), ((V)(0.35))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, Add(x_187, ((V)(dx_247))))).S(" ").V(Call(f1_12, V.Undef, ((V)(dy_248)))).S("l-3 ").V(Call(f1_12, V.Undef, ((V)((Lq_249 * 0.5))))).S("l3 ").V(Call(f1_12, V.Undef, ((V)((Lq_249 * 0.5))))).S("l3 -").V(Call(f1_12, V.Undef, ((V)((Lq_249 * 0.5))))).S("z").End())), GetIdx(R_243, (i_244 % 5D)), WH_16, ((V)(0.8)), ((V)(0.95))));
i_244++;
}
}
{
double i_250 = 0;
i_250 = 0D;
while (true) {
if (!((i_250 < 5D))) break;
double dx_252 = 0;
dx_252 = ((i_250 - 2D) * 9D);
Invoke(o_186, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, Add(x_187, ((V)(dx_252))))).S(" 36l-2.6 8l2.6 9l2.6-9z").End())), GetIdx(R_243, ((i_250 + 2D) % 5D)), WH_16, ((V)(0.8))));
i_250++;
}
}
return default;
}
if ((!SEqS(k_190, "neon") && !SEqS(k_190, "disco"))) {
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)((SEqS(k_190, "chand") ? 40D : 44D))), ((V)(44D))), ((V)("url(#gWarm)")), ((V)(0D)), ((V)(0D)), ((V)(0.8))));
}
if (SEqS(k_190, "bulb")) {
Call(cord_191, V.Undef, ((V)(22D)));
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_187) - 4D))), ((V)(20D)), ((V)(8D)), ((V)(7D)), ((V)(2D))), ((V)("#6a625c"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)(32D)), ((V)(6.5))), ((V)("#fff6c8")), ((V)("#d9c48a")), ((V)(1D))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)((ToNum(x_187) - 2D))), ((V)(30D)), ((V)(2D))), WH_16));
} else {
if (SEqS(k_190, "jar")) {
Call(cord_191, V.Undef, ((V)(14D)));
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_187) - 9D))), ((V)(14D)), ((V)(18D)), ((V)(4D)), ((V)(1.5))), ((V)("#a9b0b4"))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_187) - 10D))), ((V)(18D)), ((V)(20D)), ((V)(24D)), ((V)(6D))), ((V)("#fff4c8")), ((V)("#c9b48e")), ((V)(1.2))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)(30D)), ((V)(4D))), ((V)("#ffd66b"))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_187) - 7D))), ((V)(21D)), ((V)(4D)), ((V)(14D)), ((V)(2D))), WH_16, ((V)(0D)), ((V)(0D)), ((V)(0.7))));
} else {
if (SEqS(k_190, "wicker")) {
Call(cord_191, V.Undef, ((V)(16D)));
Invoke(o_186, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_187) - 24D)).S(" 40Q").N((ToNum(x_187) - 24D)).S(" 16 ").V(x_187).S(" 16Q").V(Add(x_187, ((V)(24D)))).S(" 16 ").V(Add(x_187, ((V)(24D)))).S(" 40Z").End())), ((V)("#d9b47a")), ((V)("#a8824e")), ((V)(1.2))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_187) - 22D)).S(" 32H").V(Add(x_187, ((V)(22D)))).S("M").N((ToNum(x_187) - 18D)).S(" 24H").V(Add(x_187, ((V)(18D)))).S("M").N((ToNum(x_187) - 10D)).S(" 17V40M").V(x_187).S(" 16V40M").V(Add(x_187, ((V)(10D)))).S(" 17V40").End())), ((V)("none")), ((V)("#b8925a")), ((V)(1D))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, x_187, ((V)(41D)), ((V)(14D)), ((V)(3.5))), ((V)("#fff6c8"))));
} else {
if (SEqS(k_190, "neon")) {
Call(cord_191, V.Undef, ((V)(10D)));
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)(32D)), ((V)(20D))), ((V)("none")), ((V)("#4fe0d0")), ((V)(9D)), ((V)(0.3))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)(32D)), ((V)(20D))), ((V)("none")), ((V)("#bffcf4")), ((V)(3D))));
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)(32D)), ((V)(13D))), ((V)("none")), ((V)("#ff9d4a")), ((V)(7D)), ((V)(0.3))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)(32D)), ((V)(13D))), ((V)("none")), ((V)("#ffe0c0")), ((V)(2.4))));
} else {
if (SEqS(k_190, "disco")) {
Invoke(o_186, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_187).S(" 0V14").End())), ((V)("none")), ((V)("#c9cde8")), ((V)(2D))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)(34D)), ((V)(22D))), ((V)("url(#dBall)"))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_187) - 22D)).S(" 26H").V(Add(x_187, ((V)(22D)))).S("M").N((ToNum(x_187) - 22D)).S(" 34H").V(Add(x_187, ((V)(22D)))).S("M").N((ToNum(x_187) - 21D)).S(" 42H").V(Add(x_187, ((V)(21D)))).S("M").N((ToNum(x_187) - 8D)).S(" 13V55M").V(Add(x_187, ((V)(8D)))).S(" 13V55").End())), ((V)("none")), ((V)("#5a5f96")), ((V)(1D)), ((V)(0.6))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_187) - 13D))), ((V)(21D)), ((V)(8D)), ((V)(7D)), ((V)(1D))), WH_16, ((V)(0D)), ((V)(0D)), ((V)(0.85))));
} else {
if (SEqS(k_190, "globe")) {
Call(cord_191, V.Undef, ((V)(14D)));
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_187) - 5D))), ((V)(12D)), ((V)(10D)), ((V)(5D)), ((V)(2D))), ((V)("#2c2d31"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)(32D)), ((V)(16D))), ((V)("#f6f1e2")), ((V)("#d6cdb6")), ((V)(1D))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)((ToNum(x_187) - 5D))), ((V)(26D)), ((V)(5D))), WH_16, ((V)(0D)), ((V)(0D)), ((V)(0.9))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)(34D)), ((V)(6D))), ((V)("#fff1a8")), ((V)(0D)), ((V)(0D)), ((V)(0.8))));
} else {
if (SEqS(k_190, "sprinkle")) {
Call(cord_191, V.Undef, ((V)(14D)));
Invoke(o_186, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_187) - 22D)).S(" 36Q").N((ToNum(x_187) - 20D)).S(" 14 ").V(x_187).S(" 14Q").V(Add(x_187, ((V)(20D)))).S(" 14 ").V(Add(x_187, ((V)(22D)))).S(" 36Z").End())), ((V)("#cdb8f5")), ((V)("#a98be8")), ((V)(1.2))));
Invoke(Arr(((V)("#4fe0d0")), ((V)("#ffd66b")), ((V)("#ff9d4a")), ((V)("#a6f06a")), ((V)("#6ac8ff"))), "forEach", Fn((V _arrowThis261, int _argc253, V c_259, V i_260, V _a257, V _a258, V[] _rest254) => {
return Invoke(o_186, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(x_187) - 15D) + (ToNum(i_260) * 7D)))), ((V)((20D + ((ToNum(i_260) % 2D) * 7D)))), ((V)(5D)), ((V)(2.4)), ((V)(1.2))), c_259));
}, 2, "", true));
{
double i_262 = 0;
i_262 = 0D;
while (true) {
if (!((i_262 < 5D))) break;
Invoke(o_186, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(((ToNum(x_187) - 22D) + (i_262 * 11D))).S(" 36q2 6 0 8").End())), ((V)("none")), ((V)("#bff0dc")), ((V)(4D))));
i_262++;
}
}
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(ell_14, V.Undef, x_187, ((V)(37D)), ((V)(12D)), ((V)(3D))), ((V)("#fff6c8"))));
} else {
if (SEqS(k_190, "chand")) {
Call(cord_191, V.Undef, ((V)(10D)));
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_187, ((V)(12D)), ((V)(4D))), ((V)("url(#hsGold)"))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_187) - 34D)).S(" 34Q").V(x_187).S(" 50 ").V(Add(x_187, ((V)(34D)))).S(" 34").End())), ((V)("none")), GOLD_17, ((V)(3D))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_187) - 20D)).S(" 28Q").V(x_187).S(" 40 ").V(Add(x_187, ((V)(20D)))).S(" 28").End())), ((V)("none")), GOLD_17, ((V)(2.4))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_187).S(" 12V44").End())), ((V)("none")), GOLD_17, ((V)(3D))));
Invoke(Arr(((V)((-34D))), ((V)((-20D))), ((V)(0D)), ((V)(20D)), ((V)(34D))), "forEach", Fn((V _arrowThis272, int _argc264, V dx_270, V i_271, V _a268, V _a269, V[] _rest265) => {
double yy_273 = 0;
yy_273 = (SEqN(i_271, 2D) ? 44D : ((System.Math.Abs(ToNum(dx_270)) > 30D) ? 34D : 28D));
Invoke(o_186, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(Add(x_187, dx_270)) - 2.4))), ((V)((yy_273 - 10D))), ((V)(4.8)), ((V)(10D)), ((V)(1.5))), CR_15), Call(pd_20, V.Undef, Call(ell_14, V.Undef, Add(x_187, dx_270), ((V)((yy_273 - 13D))), ((V)(2.4)), ((V)(3.6))), ((V)("#ffb347"))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Add(x_187, dx_270)).S(" ").N((yy_273 + 2D)).S("l-3 6l3 5l3-5z").End())), ((V)("#e9f7fd")), ((V)("#bfe4ff")), ((V)(0.8))));
return default;
}, 2, "", true));
}
}
}
}
}
}
}
}
return default;
}, 4, "light", false);
art_42 = Fn((V _self274, int _argc275, V o_281, V x_282, V S_283, V T_284, V[] _rest276) => {
V k_285 = default;
if (_self274.IsNullish) _self274 = GlobalV;
k_285 = Get(S_283, "k");
if (SEqS(k_285, "none")) {
return default;
}
if (SEqS(k_285, "cards")) {
Invoke(Arr(Arr(((V)((-20D))), ((V)(22D)), ((V)((-0.12))), ((V)("#f2c255"))), Arr(((V)(6D)), ((V)(18D)), ((V)(0.1)), ((V)("#84b6c9"))), Arr(((V)((-6D))), ((V)(40D)), ((V)(0.06)), ((V)("#e3946a"))), Arr(((V)(20D)), ((V)(38D)), ((V)((-0.08))), ((V)("#9fc684")))), "forEach", Fn((V _arrowThis301, int _argc286, V _a288, V _a289, V _a290, V _a291, V[] _rest287) => {
V cx_302 = default;
double w_303 = 0;
double h_304 = 0;
double co_305 = 0;
double si_306 = 0;
V P_307 = default;
V dx_294 = default;
V y_296 = default;
V r_298 = default;
V c_300 = default;
{ V _t292 = ListOf(_a288);
{ V _t293 = GetIdx(_t292, 0D);
dx_294 = _t293; }
{ V _t295 = GetIdx(_t292, 1D);
y_296 = _t295; }
{ V _t297 = GetIdx(_t292, 2D);
r_298 = _t297; }
{ V _t299 = GetIdx(_t292, 3D);
c_300 = _t299; }
}
cx_302 = Add(x_282, dx_294);
w_303 = 22D;
h_304 = 15D;
co_305 = FdLibm.Cos(ToNum(r_298));
si_306 = FdLibm.Sin(ToNum(r_298));
P_307 = Invoke(Arr(Arr(((V)(((-w_303) / 2D))), ((V)(((-h_304) / 2D)))), Arr(((V)((w_303 / 2D))), ((V)(((-h_304) / 2D)))), Arr(((V)((w_303 / 2D))), ((V)((h_304 / 2D)))), Arr(((V)(((-w_303) / 2D))), ((V)((h_304 / 2D))))), "map", Fn((V _arrowThis319, int _argc308, V _a310, V _a311, V _a312, V _a313, V[] _rest309) => {
V a_316 = default;
V b_318 = default;
{ V _t314 = ListOf(_a310);
{ V _t315 = GetIdx(_t314, 0D);
a_316 = _t315; }
{ V _t317 = GetIdx(_t314, 1D);
b_318 = _t317; }
}
return Arr(((V)((ToNum(Add(cx_302, ((V)((ToNum(a_316) * co_305))))) - (ToNum(b_318) * si_306)))), Add(Add(y_296, ((V)((ToNum(a_316) * si_306)))), ((V)((ToNum(b_318) * co_305)))));
}, 1, "", true));
Invoke(o_281, "push", Call(pd_20, V.Undef, Invoke(K_9, "pathOf", P_307), WH_16, ((V)("#c9bfa8")), ((V)(1D))), Call(pd_20, V.Undef, Invoke(K_9, "pathOf", Invoke(P_307, "map", Fn((V _arrowThis331, int _argc320, V _a322, V _a323, V _a324, V _a325, V[] _rest321) => {
V a_328 = default;
V b_330 = default;
{ V _t326 = ListOf(_a322);
{ V _t327 = GetIdx(_t326, 0D);
a_328 = _t327; }
{ V _t329 = GetIdx(_t326, 1D);
b_330 = _t329; }
}
return Arr(Add(cx_302, ((V)(((ToNum(a_328) - ToNum(cx_302)) * 0.7)))), Add(y_296, ((V)(((ToNum(b_330) - ToNum(y_296)) * 0.6)))));
}, 1, "", true))), c_300, ((V)(0D)), ((V)(0D)), ((V)(0.8))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, cx_302, ((V)(((ToNum(y_296) - (h_304 / 2D)) + 1D))), ((V)(1.8))), ((V)("#e2554a"))));
return default;
}, 1, "", true));
} else {
if (SEqS(k_285, "map")) {
Invoke(o_281, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_282) - 32D))), ((V)(14D)), ((V)(64D)), ((V)(44D)), ((V)(2D))), ((V)("#efe0bc")), ((V)("#c9b48e")), ((V)(1.2))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_282) - 22D)).S(" 30q8-10 16-2t14 4q4 10-8 12t-18-4z").End())), ((V)("#a8c88a")), ((V)(0D)), ((V)(0D)), ((V)(0.9))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Add(x_282, ((V)(8D)))).S(" 22q10-4 16 4t-4 10z").End())), ((V)("#a8c88a")), ((V)(0D)), ((V)(0D)), ((V)(0.9))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_282) - 14D)).S(" 48l8-6l8 4l10-8").End())), ((V)("none")), ((V)("#e2554a")), ((V)(1.4))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Add(x_282, ((V)(14D)))).S(" 36l3 3m0-3l-3 3").End())), ((V)("none")), ((V)("#e2554a")), ((V)(1.6))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)((ToNum(x_282) - 32D))), ((V)(14D)), ((V)(2.4))), ((V)("#b8714a"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_282, ((V)(32D))), ((V)(14D)), ((V)(2.4))), ((V)("#b8714a"))));
} else {
if (SEqS(k_285, "flowers")) {
Invoke(o_281, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_282) - 26D))), ((V)(12D)), ((V)(52D)), ((V)(50D)), ((V)(4D))), ((V)("url(#hsWood)"))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_282) - 21D))), ((V)(17D)), ((V)(42D)), ((V)(40D)), ((V)(2D))), ((V)("#fbf6e8"))));
Invoke(Arr(Arr(((V)((-8D))), ((V)(30D)), ((V)("#e3946a"))), Arr(((V)(8D)), ((V)(26D)), ((V)("#c4a0e0"))), Arr(((V)(0D)), ((V)(42D)), ((V)("#f2c255")))), "forEach", Fn((V _arrowThis345, int _argc332, V _a334, V _a335, V _a336, V _a337, V[] _rest333) => {
V dx_340 = default;
V y_342 = default;
V c_344 = default;
{ V _t338 = ListOf(_a334);
{ V _t339 = GetIdx(_t338, 0D);
dx_340 = _t339; }
{ V _t341 = GetIdx(_t338, 1D);
y_342 = _t341; }
{ V _t343 = GetIdx(_t338, 2D);
c_344 = _t343; }
}
Invoke(o_281, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Add(x_282, dx_340)).S(" ").V(Add(y_342, ((V)(4D)))).S("Q").V(Add(Add(x_282, dx_340), ((V)(2D)))).S(" ").V(Add(y_342, ((V)(12D)))).S(" ").V(x_282).S(" 54").End())), ((V)("none")), ((V)("#7ab45c")), ((V)(1.4))));
{
double i_346 = 0;
i_346 = 0D;
while (true) {
if (!((i_346 < 5D))) break;
double a_348 = 0;
a_348 = (((i_346 / 5D) * System.Math.PI) * 2D);
Invoke(o_281, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(Add(x_282, dx_340), ((V)((4D * FdLibm.Cos(a_348))))), Add(y_342, ((V)((4D * FdLibm.Sin(a_348))))), ((V)(3D))), c_344));
i_346++;
}
}
Invoke(o_281, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_282, dx_340), y_342, ((V)(2D))), ((V)("#fff1a8"))));
return default;
}, 1, "", true));
} else {
if (SEqS(k_285, "clock")) {
{
double i_349 = 0;
i_349 = 0D;
while (true) {
if (!((i_349 < 12D))) break;
double a_351 = 0;
double r_352 = 0;
a_351 = (((i_349 / 12D) * System.Math.PI) * 2D);
r_352 = (NumTruthy((i_349 % 2D)) ? 26D : 32D);
Invoke(o_281, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, Add(x_282, ((V)((18D * FdLibm.Cos(a_351))))))).S(" ").V(Call(f1_12, V.Undef, ((V)((36D + (18D * FdLibm.Sin(a_351))))))).S("L").V(Call(f1_12, V.Undef, Add(x_282, ((V)((r_352 * FdLibm.Cos(a_351))))))).S(" ").V(Call(f1_12, V.Undef, ((V)((36D + (r_352 * FdLibm.Sin(a_351))))))).End())), ((V)("none")), (NumTruthy((i_349 % 2D)) ? ((V)("#e2554a")) : GOLD_17), ((V)(2.4))));
Invoke(o_281, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_282, ((V)((r_352 * FdLibm.Cos(a_351))))), ((V)((36D + (r_352 * FdLibm.Sin(a_351))))), ((V)(2.6))), ((V)((NumTruthy((i_349 % 2D)) ? "#e2554a" : "#5cc8c0")))));
i_349++;
}
}
Invoke(o_281, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_282, ((V)(36D)), ((V)(17D))), ((V)("url(#hsClock)")), ((V)("#c9b48e")), ((V)(1.2))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_282).S(" 36L").N((ToNum(x_282) - 6D)).S(" 30").End())), ((V)("none")), ((V)("#3b2e28")), ((V)(2.4))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_282).S(" 36L").V(Add(x_282, ((V)(8D)))).S(" 27").End())), ((V)("none")), ((V)("#3b2e28")), ((V)(1.6))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_282, ((V)(36D)), ((V)(2D))), ((V)("#e2554a"))));
} else {
if (SEqS(k_285, "records")) {
Invoke(Arr(Arr(((V)((-24D))), ((V)(28D))), Arr(((V)(2D)), ((V)(22D))), Arr(((V)(26D)), ((V)(34D)))), "forEach", Fn((V _arrowThis365, int _argc353, V _a355, V i_359, V _a357, V _a358, V[] _rest354) => {
V dx_362 = default;
V y_364 = default;
{ V _t360 = ListOf(_a355);
{ V _t361 = GetIdx(_t360, 0D);
dx_362 = _t361; }
{ V _t363 = GetIdx(_t360, 1D);
y_364 = _t363; }
}
return Invoke(o_281, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_282, dx_362), Add(y_364, ((V)(8D))), ((V)(14D))), ((V)("#2b2b33"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_282, dx_362), Add(y_364, ((V)(8D))), ((V)(9D))), ((V)("none")), ((V)("#4a4a56")), ((V)(1D))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_282, dx_362), Add(y_364, ((V)(8D))), ((V)(5D))), GetK(Arr(((V)("#e2554a")), ((V)("#ffd23f")), ((V)("#5cc8c0"))), i_359)), Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_282, dx_362), Add(y_364, ((V)(8D))), ((V)(1.2))), ((V)("#2b2b33"))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(Add(x_282, dx_362)) - 8D)).S(" ").V(Add(y_364, ((V)(2D)))).S("A10 10 0 0 1 ").V(Add(Add(x_282, dx_362), ((V)(2D)))).S(" ").N((ToNum(y_364) - 2D)).End())), ((V)("none")), WH_16, ((V)(1.4)), ((V)(0.5))));
}, 2, "", true));
} else {
if (SEqS(k_285, "canvas")) {
Invoke(o_281, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_282) - 28D))), ((V)(12D)), ((V)(56D)), ((V)(50D)), ((V)(1D))), ((V)("#fbfaf6")), ((V)("#d4d0c6")), ((V)(1.2))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)((ToNum(x_282) - 8D))), ((V)(32D)), ((V)(12D))), ((V)("#e8b04a"))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_282) - 2D))), ((V)(26D)), ((V)(22D)), ((V)(26D)), ((V)(1D))), ((V)("#c46a4a")), ((V)(0D)), ((V)(0D)), ((V)(0.9))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_282) - 24D)).S(" 54Q").V(x_282).S(" 40 ").V(Add(x_282, ((V)(24D)))).S(" 50").End())), ((V)("none")), ((V)("#5a6270")), ((V)(3D))));
} else {
if (SEqS(k_285, "rainbow")) {
Invoke(Arr(((V)("#ff9d4a")), ((V)("#ffd66b")), ((V)("#a6f06a")), ((V)("#6ac8ff")), ((V)("#8f7bff"))), "forEach", Fn((V _arrowThis374, int _argc366, V c_372, V i_373, V _a370, V _a371, V[] _rest367) => {
double r_375 = 0;
r_375 = (30D - (ToNum(i_373) * 5.5));
Invoke(o_281, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_282) - r_375)).S(" 58A").N(r_375).S(" ").N(r_375).S(" 0 0 1 ").V(Add(x_282, ((V)(r_375)))).S(" 58").End())), ((V)("none")), c_372, ((V)(5.5))));
return default;
}, 2, "", true));
Invoke(o_281, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)((ToNum(x_282) - 30D))), ((V)(56D)), ((V)(8D))), WH_16), Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)((ToNum(x_282) - 22D))), ((V)(54D)), ((V)(9D))), WH_16), Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_282, ((V)(22D))), ((V)(54D)), ((V)(9D))), WH_16), Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_282, ((V)(30D))), ((V)(56D)), ((V)(8D))), WH_16));
} else {
if (SEqS(k_285, "portrait")) {
Invoke(o_281, "push", Call(pd_20, V.Undef, Call(ell_14, V.Undef, x_282, ((V)(36D)), ((V)(26D)), ((V)(30D))), ((V)("url(#hsGold)")), ((V)("#c9961f")), ((V)(1.2))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, x_282, ((V)(36D)), ((V)(20D)), ((V)(24D))), ((V)("#7a1e2c"))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, x_282, ((V)(44D)), ((V)(12D)), ((V)(11D))), ((V)("#fbe3c4"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)((ToNum(x_282) - 4D))), ((V)(42D)), ((V)(1.6))), ((V)("#3b2e28"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_282, ((V)(4D))), ((V)(42D)), ((V)(1.6))), ((V)("#3b2e28"))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_282) - 9D)).S(" 33L").N((ToNum(x_282) - 9D)).S(" 24L").N((ToNum(x_282) - 4D)).S(" 29L").V(x_282).S(" 22L").V(Add(x_282, ((V)(4D)))).S(" 29L").V(Add(x_282, ((V)(9D)))).S(" 24L").V(Add(x_282, ((V)(9D)))).S(" 33Z").End())), GOLD_17, ((V)("#c9961f")), ((V)(1D))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_282) - 4D)).S(" 48q4 3 8 0").End())), ((V)("none")), ((V)("#c4651f")), ((V)(1.4))));
}
}
}
}
}
}
}
}
return default;
}, 4, "art", false);
rust_43 = Fn((V _self376, int _argc377, V o_383, V P_384, V _a381, V _a382, V[] _rest378) => {
V web_385 = default;
if (_self376.IsNullish) _self376 = GlobalV;
web_385 = Fn((V _arrowThis394, int _argc386, V x_392, V s_393, V _a390, V _a391, V[] _rest387) => {
JsStrBuf d_395 = null;
d_395 = new JsStrBuf("");
{
double i_396 = 0;
i_396 = 1D;
while (true) {
if (!((i_396 <= 3D))) break;
d_395.S("M").V(x_392).S(" ").N((i_396 * 9D)).S("Q").V(Add(x_392, ((V)(((ToNum(s_393) * i_396) * 5D))))).S(" ").N((i_396 * 6D)).S(" ").V(Add(x_392, ((V)(((ToNum(s_393) * i_396) * 9D))))).S(" 0");
i_396++;
}
}
d_395.S("M").V(x_392).S(" 0L").V(Add(x_392, ((V)((ToNum(s_393) * 30D))))).S(" 30M").V(x_392).S(" 0L").V(Add(x_392, ((V)((ToNum(s_393) * 14D))))).S(" 34M").V(x_392).S(" 0L").V(Add(x_392, ((V)((ToNum(s_393) * 34D))))).S(" 12");
Invoke(o_383, "push", Call(pd_20, V.Undef, ((V)(d_395.Str)), ((V)("none")), ((V)("#ffffff")), ((V)(1D)), ((V)(0.7))));
return default;
}, 2, "", true);
Call(web_385, V.Undef, ((V)(BL_22)), ((V)(1D)));
Call(web_385, V.Undef, ((V)(BR_23)), ((V)((-1D))));
Invoke(o_383, "push", Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)(214D)), ((V)(40D)), ((V)(18D)), ((V)(12D))), ((V)("#8a6a48")), ((V)(0D)), ((V)(0D)), ((V)(0.12))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)(600D)), ((V)(26D)), ((V)(14D)), ((V)(20D))), ((V)("#8a6a48")), ((V)(0D)), ((V)(0D)), ((V)(0.1))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)(60D)), ((V)(120D)), ((V)(16D)), ((V)(24D))), ((V)("#8a6a48")), ((V)(0D)), ((V)(0D)), ((V)(0.1))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)(790D)), ((V)(110D)), ((V)(18D)), ((V)(22D))), ((V)("#8a6a48")), ((V)(0D)), ((V)(0D)), ((V)(0.1))));
Invoke(o_383, "push", Call(pd_20, V.Undef, ((V)("M380 0L386 10L382 18L390 30L386 40")), ((V)("none")), Call(shade_11, V.Undef, Get(P_384, "b0"), ((V)(0.7))), ((V)(1.4))), Call(pd_20, V.Undef, ((V)("M660 66L652 54L656 46L648 36")), ((V)("none")), Call(shade_11, V.Undef, Get(P_384, "b0"), ((V)(0.7))), ((V)(1.4))), Call(pd_20, V.Undef, ((V)("M30 160L42 150L38 138L50 128")), ((V)("none")), Call(shade_11, V.Undef, Get(P_384, "b0"), ((V)(0.7))), ((V)(1.4))));
Invoke(o_383, "push", Call(pd_20, V.Undef, ((V)("M540 4Q552 8 548 22Q546 30 556 34L560 4Z")), ((V)("#f1e8d6")), Call(shade_11, V.Undef, Get(P_384, "b0"), ((V)(0.8))), ((V)(1D))), Call(pd_20, V.Undef, ((V)("M170 70Q176 60 186 66L190 52L172 54Z")), ((V)("#f1e8d6")), Call(shade_11, V.Undef, Get(P_384, "b0"), ((V)(0.8))), ((V)(1D))));
return default;
}, 2, "rust", false);
@fixed_44 = Fn((V _self398, int _argc399, V k_405, V a_406, V P_407, V o_408, V[] _rest400) => {
V x_410 = default;
V T_409 = default;
if (_self398.IsNullish) _self398 = GlobalV;
T_409 = (_argc399 > 4 ? _rest400[0] : V.Undef);
x_410 = GetIdx(a_406, 1D);
if (SEqS(k_405, "hwin")) {
double w_411 = 0;
double h_412 = 0;
double y_413 = 0;
w_411 = 54D;
h_412 = 44D;
y_413 = 22D;
Invoke(o_408, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(x_410) - (w_411 / 2D)) - 16D))), ((V)((y_413 - 2D))), ((V)(13D)), ((V)((h_412 + 4D))), ((V)(3D))), ((V)("#84b6c9"))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, Add(Add(x_410, ((V)((w_411 / 2D)))), ((V)(3D))), ((V)((y_413 - 2D))), ((V)(13D)), ((V)((h_412 + 4D))), ((V)(3D))), ((V)("#84b6c9"))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(x_410) - (w_411 / 2D)) - 5D))), ((V)((y_413 - 5D))), ((V)((w_411 + 10D))), ((V)((h_412 + 10D))), ((V)(8D))), CR_15), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_410) - (w_411 / 2D)))), ((V)(y_413)), ((V)(w_411)), ((V)(h_412)), ((V)(5D))), ((V)("url(#hsSky)"))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_410) - 2D))), ((V)(y_413)), ((V)(4D)), ((V)(h_412)), ((V)(1D))), CR_15), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_410) - (w_411 / 2D)))), ((V)(((y_413 + (h_412 / 2D)) - 2D))), ((V)(w_411)), ((V)(4D)), ((V)(1D))), CR_15));
} else {
if (SEqS(k_405, "mirror")) {
Invoke(o_408, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_410, ((V)(36D)), ((V)(26D))), ((V)("url(#hsWood)"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_410, ((V)(36D)), ((V)(21D))), ((V)("url(#bMirror)"))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_410) - 12D)).S(" 30L").N((ToNum(x_410) - 2D)).S(" 20M").N((ToNum(x_410) - 9D)).S(" 42L").V(Add(x_410, ((V)(9D)))).S(" 24").End())), ((V)("none")), WH_16, ((V)(4D)), ((V)(0.8))));
} else {
if (SEqS(k_405, "neon")) {
Invoke(T_409, "push", NewObj(7).Put("x", x_410).Put("y", ((V)(54D))).Put("t", GetIdx(a_406, 2D)).Put("f", ((V)("#eafffb"))).Put("s", ((V)("#4fe0d0"))).Put("sz", ((V)(36D))).Put("glow", ((V)(1D))).V);
}
}
}
return default;
}, 5, "fixed", false);
fence_45 = Fn((V _self414, int _argc415, V o_421, V S_422, V _a419, V _a420, V[] _rest416) => {
V k_423 = default;
V c_424 = default;
V posts_425 = default;
V rail_426 = default;
V hedge_427 = default;
if (_self414.IsNullish) _self414 = GlobalV;
k_423 = Get(S_422, "k");
c_424 = Get(S_422, "c");
posts_425 = Fn((V _arrowThis435, int _argc428, V s_434, V _a431, V _a432, V _a433, V[] _rest429) => {
JsStrBuf d_436 = null;
double N_437 = 0;
d_436 = new JsStrBuf("");
N_437 = (SEqS(k_423, "slat") ? 30D : 15D);
{
double i_438 = 0;
i_438 = 0D;
while (true) {
if (!((i_438 < N_437))) break;
double t0_440 = 0;
double t1_441 = 0;
V p_442 = default;
V q_443 = default;
double H_444 = 0;
double tilt_445 = 0;
double hp_446 = 0;
double hq_447 = 0;
double tip_448 = 0;
if ((SEqS(k_423, "broken") && (((i_438 == 4D) || (i_438 == 9D)) || (i_438 == 12D)))) {
goto _cont439;
}
t0_440 = ((i_438 / N_437) + (SEqS(k_423, "slat") ? 0.004 : 0.012));
t1_441 = (((i_438 + 1D) / N_437) - (SEqS(k_423, "slat") ? 0.004 : 0.012));
p_442 = Call(sideB_25, V.Undef, s_434, ((V)(t0_440)));
q_443 = Call(sideB_25, V.Undef, s_434, ((V)(t1_441)));
H_444 = (SEqS(k_423, "gold") ? 54D : (SEqS(k_423, "slat") ? 50D : 40D));
tilt_445 = ((SEqS(k_423, "broken") && ((i_438 % 3D) == 1D)) ? 6D : 0D);
hp_446 = (H_444 * ToNum(Call(WY_24, V.Undef, GetIdx(p_442, 1D))));
hq_447 = ((H_444 * ToNum(Call(WY_24, V.Undef, GetIdx(q_443, 1D)))) - tilt_445);
tip_448 = (SEqS(k_423, "slat") ? 0D : (SEqS(k_423, "gold") ? 12D : 7D));
d_436.S("M").V(Call(f1_12, V.Undef, GetIdx(p_442, 0D))).S(" ").V(Call(f1_12, V.Undef, GetIdx(p_442, 1D))).S("L").V(Call(f1_12, V.Undef, GetIdx(q_443, 0D))).S(" ").V(Call(f1_12, V.Undef, GetIdx(q_443, 1D))).S("L").V(Call(f1_12, V.Undef, GetIdx(q_443, 0D))).S(" ").V(Call(f1_12, V.Undef, ((V)((ToNum(GetIdx(q_443, 1D)) - hq_447))))).S("L").V(Call(f1_12, V.Undef, ((V)((ToNum(Add(GetIdx(p_442, 0D), GetIdx(q_443, 0D))) / 2D))))).S(" ").V(Call(f1_12, V.Undef, ((V)((((ToNum(Add(GetIdx(p_442, 1D), GetIdx(q_443, 1D))) / 2D) - ((hp_446 + hq_447) / 2D)) - tip_448))))).S("L").V(Call(f1_12, V.Undef, GetIdx(p_442, 0D))).S(" ").V(Call(f1_12, V.Undef, ((V)((ToNum(GetIdx(p_442, 1D)) - hp_446))))).S("Z");
_cont439: ;
i_438++;
}
}
return ((V)(d_436.Str));
return default;
}, 1, "", true);
rail_426 = Fn((V _arrowThis457, int _argc449, V s_455, V f_456, V _a453, V _a454, V[] _rest450) => {
V p_458 = default;
V q_459 = default;
p_458 = Call(sideB_25, V.Undef, s_455, ((V)(0D)));
q_459 = Call(sideB_25, V.Undef, s_455, ((V)(1D)));
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, GetIdx(p_458, 0D))).S(" ").V(Call(f1_12, V.Undef, ((V)((ToNum(GetIdx(p_458, 1D)) - ((40D * ToNum(f_456)) * ToNum(Call(WY_24, V.Undef, GetIdx(p_458, 1D))))))))).S("L").V(Call(f1_12, V.Undef, GetIdx(q_459, 0D))).S(" ").V(Call(f1_12, V.Undef, ((V)((ToNum(GetIdx(q_459, 1D)) - ((40D * ToNum(f_456)) * ToNum(Call(WY_24, V.Undef, GetIdx(q_459, 1D))))))))).End()));
return default;
}, 2, "", true);
hedge_427 = Fn((V _arrowThis467, int _argc460, V s_466, V _a463, V _a464, V _a465, V[] _rest461) => {
JsStrBuf d_468 = null;
d_468 = new JsStrBuf("");
{
double i_469 = 0;
i_469 = 0D;
while (true) {
if (!((i_469 < 7D))) break;
V p_471 = default;
double r_472 = 0;
p_471 = Call(sideB_25, V.Undef, s_466, ((V)(((i_469 + 0.5) / 7D))));
r_472 = (18D * ToNum(Call(WY_24, V.Undef, GetIdx(p_471, 1D))));
d_468.V(Call(circ_13, V.Undef, Add(GetIdx(p_471, 0D), ((V)((SEqS(s_466, "L") ? ((-r_472) * 0.4) : (r_472 * 0.4))))), ((V)((ToNum(GetIdx(p_471, 1D)) - (46D * ToNum(Call(WY_24, V.Undef, GetIdx(p_471, 1D))))))), ((V)(r_472))));
i_469++;
}
}
return ((V)(d_468.Str));
return default;
}, 1, "", true);
if (SEqS(k_423, "hedge")) {
Invoke(Arr(((V)("L")), ((V)("R"))), "forEach", Fn((V _arrowThis480, int _argc473, V s_479, V _a476, V _a477, V _a478, V[] _rest474) => {
return Invoke(o_421, "push", Call(pd_20, V.Undef, Call(hedge_427, V.Undef, s_479), ((V)("#7ab45c")), ((V)("#4f8a40")), ((V)(2.5))));
}, 1, "", true));
Invoke(o_421, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(95D)), ((V)(0D)), ((V)(662D)), ((V)(9D)), ((V)(0D))), ((V)("#c4651f"))), Call(pd_20, V.Undef, ((V)("M95 9H757")), ((V)("none")), ((V)("#9a4a14")), ((V)(2D))));
return default;
}
Invoke(Arr(((V)("L")), ((V)("R"))), "forEach", Fn((V _arrowThis488, int _argc481, V s_487, V _a484, V _a485, V _a486, V[] _rest482) => {
Invoke(o_421, "push", Call(pd_20, V.Undef, Call(hedge_427, V.Undef, s_487), ((V)((SEqS(k_423, "broken") ? "#93a86a" : "#7ab45c"))), ((V)((SEqS(k_423, "broken") ? "#6c7f48" : "#4f8a40"))), ((V)(2.5))));
if (!SEqS(k_423, "slat")) {
Invoke(o_421, "push", Call(pd_20, V.Undef, Add(Call(rail_426, V.Undef, s_487, ((V)(0.35))), Call(rail_426, V.Undef, s_487, ((V)(0.7)))), ((V)("none")), Call(shade_11, V.Undef, c_424, ((V)(0.78))), ((V)(4D))));
}
Invoke(o_421, "push", Call(pd_20, V.Undef, Call(posts_425, V.Undef, s_487), c_424, Call(shade_11, V.Undef, c_424, ((V)(0.75))), ((V)(1.2))));
if (SEqS(k_423, "cane")) {
JsStrBuf d_489 = null;
d_489 = new JsStrBuf("");
{
double i_490 = 0;
i_490 = 0D;
while (true) {
if (!((i_490 < 15D))) break;
V p_492 = default;
p_492 = Call(sideB_25, V.Undef, s_487, ((V)(((i_490 + 0.5) / 15D))));
{
double j_493 = 0;
j_493 = 1D;
while (true) {
if (!((j_493 < 4D))) break;
d_489.S("M").V(Call(f1_12, V.Undef, ((V)((ToNum(GetIdx(p_492, 0D)) - 4D))))).S(" ").V(Call(f1_12, V.Undef, ((V)((ToNum(GetIdx(p_492, 1D)) - ((j_493 * 11D) * ToNum(Call(WY_24, V.Undef, GetIdx(p_492, 1D))))))))).S("l8 -4");
j_493++;
}
}
i_490++;
}
}
Invoke(o_421, "push", Call(pd_20, V.Undef, ((V)(d_489.Str)), ((V)("none")), ((V)("#e2554a")), ((V)(3D))));
}
if (SEqS(k_423, "gold")) {
JsStrBuf d_495 = null;
d_495 = new JsStrBuf("");
{
double i_496 = 0;
i_496 = 0D;
while (true) {
if (!((i_496 < 15D))) break;
V p_498 = default;
p_498 = Call(sideB_25, V.Undef, s_487, ((V)(((i_496 + 0.5) / 15D))));
d_495.V(Call(circ_13, V.Undef, GetIdx(p_498, 0D), ((V)((ToNum(GetIdx(p_498, 1D)) - (62D * ToNum(Call(WY_24, V.Undef, GetIdx(p_498, 1D))))))), ((V)((3.4 * ToNum(Call(WY_24, V.Undef, GetIdx(p_498, 1D))))))));
i_496++;
}
}
Invoke(o_421, "push", Call(pd_20, V.Undef, ((V)(d_495.Str)), ((V)("url(#hsGold)"))));
}
return default;
}, 1, "", true));
if (SEqS(k_423, "broken")) {
Invoke(o_421, "push", Call(pd_20, V.Undef, ((V)("M40 230l20 -6l4 4l-20 7z")), Call(shade_11, V.Undef, c_424, ((V)(0.85))), Call(shade_11, V.Undef, c_424, ((V)(0.6))), ((V)(1D))), Call(pd_20, V.Undef, ((V)("M800 220l-22 -4l-2 5l22 5z")), Call(shade_11, V.Undef, c_424, ((V)(0.85))), Call(shade_11, V.Undef, c_424, ((V)(0.6))), ((V)(1D))));
}
Invoke(o_421, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(95D)), ((V)(0D)), ((V)(662D)), ((V)(9D)), ((V)(0D))), ((V)("#c4651f"))), Call(pd_20, V.Undef, ((V)("M95 9H757")), ((V)("none")), ((V)("#9a4a14")), ((V)(2D))));
return default;
}, 2, "fence", false);
ylights_47 = Fn((V _self499, int _argc500, V o_506, V S_507, V _a504, V _a505, V[] _rest501) => {
V C_508 = default;
V W_509 = default;
if (_self499.IsNullish) _self499 = GlobalV;
if (SEqS(Get(S_507, "k"), "none")) {
return default;
}
C_508 = Arr(((V)("#ff9d4a")), ((V)("#ffd66b")), ((V)("#a6f06a")), ((V)("#6ac8ff")), ((V)("#8f7bff")), ((V)("#4fe0d0")));
W_509 = ((V)("#5a4a40"));
if (SEqS(Get(S_507, "k"), "fairy")) {
Invoke(Arr(Arr(((V)(105D)), ((V)(8D)), ((V)(30D)), ((V)(747D)), ((V)(8D))), Arr(((V)(105D)), ((V)(20D)), ((V)(46D)), ((V)(747D)), ((V)(20D))), Arr(((V)(0D)), ((V)(60D)), ((V)(90D)), ((V)(100D)), ((V)(30D))), Arr(((V)(852D)), ((V)(60D)), ((V)(90D)), ((V)(752D)), ((V)(30D)))), "forEach", Fn((V _arrowThis528, int _argc510, V _a512, V r_516, V _a514, V _a515, V[] _rest511) => {
double xm_529 = 0;
double N_530 = 0;
V x0_519 = default;
V y0_521 = default;
V ym_523 = default;
V x1_525 = default;
V y1_527 = default;
{ V _t517 = ListOf(_a512);
{ V _t518 = GetIdx(_t517, 0D);
x0_519 = _t518; }
{ V _t520 = GetIdx(_t517, 1D);
y0_521 = _t520; }
{ V _t522 = GetIdx(_t517, 2D);
ym_523 = _t522; }
{ V _t524 = GetIdx(_t517, 3D);
x1_525 = _t524; }
{ V _t526 = GetIdx(_t517, 4D);
y1_527 = _t526; }
}
xm_529 = (ToNum(Add(x0_519, x1_525)) / 2D);
Invoke(o_506, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x0_519).S(" ").V(y0_521).S("Q").N(xm_529).S(" ").V(ym_523).S(" ").V(x1_525).S(" ").V(y1_527).End())), ((V)("none")), ((V)("#6a5a4a")), ((V)(0.8)), ((V)(0.7))));
N_530 = (LtN(r_516, 2D) ? 34D : 8D);
{
double n_531 = 0;
n_531 = 0D;
while (true) {
if (!((n_531 < N_530))) break;
double t_533 = 0;
V bx_534 = default;
V by_535 = default;
t_533 = ((n_531 + 0.5) / N_530);
bx_534 = Call(qb_46, V.Undef, ((V)(t_533)), x0_519, ((V)(xm_529)), x1_525);
by_535 = Add(Call(qb_46, V.Undef, ((V)(t_533)), y0_521, ym_523, y1_527), ((V)(1.5)));
Invoke(o_506, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, bx_534, by_535, ((V)(5D))), ((V)("#fff4c8")), ((V)(0D)), ((V)(0D)), ((V)(0.22))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, bx_534, by_535, ((V)(1.7))), ((V)("#fffbe6"))));
n_531++;
}
}
return default;
}, 2, "", true));
return default;
}
if (SEqS(Get(S_507, "k"), "festoon")) {
Invoke(Arr(Arr(((V)(105D)), ((V)(6D)), ((V)(50D)), ((V)(520D)), ((V)(10D))), Arr(((V)(332D)), ((V)(10D)), ((V)(54D)), ((V)(747D)), ((V)(6D)))), "forEach", Fn((V _arrowThis553, int _argc536, V _a538, V _a539, V _a540, V _a541, V[] _rest537) => {
double xm_554 = 0;
V x0_544 = default;
V y0_546 = default;
V ym_548 = default;
V x1_550 = default;
V y1_552 = default;
{ V _t542 = ListOf(_a538);
{ V _t543 = GetIdx(_t542, 0D);
x0_544 = _t543; }
{ V _t545 = GetIdx(_t542, 1D);
y0_546 = _t545; }
{ V _t547 = GetIdx(_t542, 2D);
ym_548 = _t547; }
{ V _t549 = GetIdx(_t542, 3D);
x1_550 = _t549; }
{ V _t551 = GetIdx(_t542, 4D);
y1_552 = _t551; }
}
xm_554 = (ToNum(Add(x0_544, x1_550)) / 2D);
Invoke(o_506, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x0_544).S(" ").V(y0_546).S("Q").N(xm_554).S(" ").V(ym_548).S(" ").V(x1_550).S(" ").V(y1_552).End())), ((V)("none")), ((V)("#2c2d31")), ((V)(1.4))));
{
double n_555 = 0;
n_555 = 0D;
while (true) {
if (!((n_555 < 10D))) break;
double t_557 = 0;
V bx_558 = default;
V by_559 = default;
t_557 = ((n_555 + 0.5) / 10D);
bx_558 = Call(qb_46, V.Undef, ((V)(t_557)), x0_544, ((V)(xm_554)), x1_550);
by_559 = Call(qb_46, V.Undef, ((V)(t_557)), y0_546, ym_548, y1_552);
Invoke(o_506, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, bx_558)).S(" ").V(Call(f1_12, V.Undef, by_559)).S("v4").End())), ((V)("none")), ((V)("#2c2d31")), ((V)(1.4))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(bx_558) - 2.4))), Add(by_559, ((V)(3D))), ((V)(4.8)), ((V)(4D)), ((V)(1D))), ((V)("#2c2d31"))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, bx_558, Add(by_559, ((V)(12D))), ((V)(12D))), ((V)("#ffe9a0")), ((V)(0D)), ((V)(0D)), ((V)(0.2))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, bx_558, Add(by_559, ((V)(12D))), ((V)(4.2)), ((V)(5.6))), ((V)("#fff1b8")), ((V)("#e2b14a")), ((V)(0.8))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)((ToNum(bx_558) - 1.4))), Add(by_559, ((V)(10D))), ((V)(1.2)), ((V)(2D))), WH_16, ((V)(0D)), ((V)(0D)), ((V)(0.85))));
n_555++;
}
}
return default;
}, 1, "", true));
return default;
}
if (SEqS(Get(S_507, "k"), "lantern")) {
Invoke(o_506, "push", Call(pd_20, V.Undef, ((V)("M105 10Q426 40 747 10")), ((V)("none")), W_509, ((V)(1.2))));
{
double n_560 = 0;
n_560 = 0D;
while (true) {
if (!((n_560 < 9D))) break;
double t_562 = 0;
V bx_563 = default;
V by_564 = default;
V c_565 = default;
double h_566 = 0;
t_562 = ((n_560 + 0.5) / 9D);
bx_563 = Call(qb_46, V.Undef, ((V)(t_562)), ((V)(105D)), ((V)(426D)), ((V)(747D)));
by_564 = Call(qb_46, V.Undef, ((V)(t_562)), ((V)(10D)), ((V)(40D)), ((V)(10D)));
c_565 = GetIdx(C_508, (n_560 % 6D));
h_566 = (13D + ((n_560 % 3D) * 3D));
Invoke(o_506, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, bx_563)).S(" ").V(Call(f1_12, V.Undef, by_564)).S("v5").End())), ((V)("none")), W_509, ((V)(1D))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, bx_563, Add(Add(by_564, ((V)(6D))), ((V)(h_566))), ((V)((h_566 + 8D)))), c_565, ((V)(0D)), ((V)(0D)), ((V)(0.18))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, bx_563, Add(Add(by_564, ((V)(6D))), ((V)(h_566))), ((V)((h_566 * 0.9))), ((V)(h_566))), c_565, Call(shade_11, V.Undef, c_565, ((V)(0.7))), ((V)(1D))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, ((V)((ToNum(bx_563) - (h_566 * 0.9)))))).S(" ").V(Call(f1_12, V.Undef, Add(Add(by_564, ((V)(6D))), ((V)(h_566))))).S("H").V(Call(f1_12, V.Undef, Add(bx_563, ((V)((h_566 * 0.9)))))).S("M").V(Call(f1_12, V.Undef, ((V)((ToNum(bx_563) - (h_566 * 0.8)))))).S(" ").V(Call(f1_12, V.Undef, Add(Add(by_564, ((V)(6D))), ((V)((h_566 * 0.55)))))).S("H").V(Call(f1_12, V.Undef, Add(bx_563, ((V)((h_566 * 0.8)))))).S("M").V(Call(f1_12, V.Undef, ((V)((ToNum(bx_563) - (h_566 * 0.8)))))).S(" ").V(Call(f1_12, V.Undef, Add(Add(by_564, ((V)(6D))), ((V)((h_566 * 1.45)))))).S("H").V(Call(f1_12, V.Undef, Add(bx_563, ((V)((h_566 * 0.8)))))).End())), ((V)("none")), Call(shade_11, V.Undef, c_565, ((V)(0.75))), ((V)(0.8))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(bx_563) - 4D))), Add(by_564, ((V)(4D))), ((V)(8D)), ((V)(3D)), ((V)(1D))), ((V)("#2c2d31"))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(bx_563) - 4D))), Add(Add(by_564, ((V)(5D))), ((V)((h_566 * 2D)))), ((V)(8D)), ((V)(3D)), ((V)(1D))), ((V)("#2c2d31"))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)((ToNum(bx_563) - (h_566 * 0.35)))), Add(Add(by_564, ((V)(6D))), ((V)((h_566 * 0.6)))), ((V)((h_566 * 0.22))), ((V)((h_566 * 0.3)))), WH_16, ((V)(0D)), ((V)(0D)), ((V)(0.45))));
n_560++;
}
}
return default;
}
if (SEqS(Get(S_507, "k"), "torch")) {
Invoke(Arr(Arr(((V)(30D)), ((V)(150D))), Arr(((V)(70D)), ((V)(92D))), Arr(((V)(782D)), ((V)(92D))), Arr(((V)(822D)), ((V)(150D))), Arr(((V)(140D)), ((V)(30D))), Arr(((V)(712D)), ((V)(30D)))), "forEach", Fn((V _arrowThis578, int _argc567, V _a569, V _a570, V _a571, V _a572, V[] _rest568) => {
V x_575 = default;
V y_577 = default;
{ V _t573 = ListOf(_a569);
{ V _t574 = GetIdx(_t573, 0D);
x_575 = _t574; }
{ V _t576 = GetIdx(_t573, 1D);
y_577 = _t576; }
}
Invoke(o_506, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_575) - 2D))), ((V)((ToNum(y_577) - 10D))), ((V)(4D)), ((V)(74D)), ((V)(2D))), ((V)("#8a6a3e")), ((V)("#5a4020")), ((V)(0.8))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_575) - 2D)).S(" ").V(Add(y_577, ((V)(6D)))).S("h4M").N((ToNum(x_575) - 2D)).S(" ").V(Add(y_577, ((V)(24D)))).S("h4").End())), ((V)("none")), ((V)("#5a4020")), ((V)(1D))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_575) - 7D)).S(" ").N((ToNum(y_577) - 22D)).S("L").V(Add(x_575, ((V)(7D)))).S(" ").N((ToNum(y_577) - 22D)).S("L").V(Add(x_575, ((V)(4D)))).S(" ").N((ToNum(y_577) - 8D)).S("L").N((ToNum(x_575) - 4D)).S(" ").N((ToNum(y_577) - 8D)).S("Z").End())), GOLD_17, ((V)("#8a5d00")), ((V)(1D))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_575, ((V)((ToNum(y_577) - 34D))), ((V)(22D))), ((V)("#ffb340")), ((V)(0D)), ((V)(0D)), ((V)(0.18))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_575).S(" ").N((ToNum(y_577) - 46D)).S("C").V(Add(x_575, ((V)(9D)))).S(" ").N((ToNum(y_577) - 34D)).S(" ").V(Add(x_575, ((V)(7D)))).S(" ").N((ToNum(y_577) - 24D)).S(" ").V(x_575).S(" ").N((ToNum(y_577) - 22D)).S("C").N((ToNum(x_575) - 7D)).S(" ").N((ToNum(y_577) - 24D)).S(" ").N((ToNum(x_575) - 9D)).S(" ").N((ToNum(y_577) - 34D)).S(" ").V(x_575).S(" ").N((ToNum(y_577) - 46D)).S("Z").End())), ((V)("#ff9d2a"))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_575).S(" ").N((ToNum(y_577) - 38D)).S("C").V(Add(x_575, ((V)(4D)))).S(" ").N((ToNum(y_577) - 31D)).S(" ").V(Add(x_575, ((V)(3D)))).S(" ").N((ToNum(y_577) - 25D)).S(" ").V(x_575).S(" ").N((ToNum(y_577) - 24D)).S("C").N((ToNum(x_575) - 3D)).S(" ").N((ToNum(y_577) - 25D)).S(" ").N((ToNum(x_575) - 4D)).S(" ").N((ToNum(y_577) - 31D)).S(" ").V(x_575).S(" ").N((ToNum(y_577) - 38D)).S("Z").End())), ((V)("#ffe9a0"))));
return default;
}, 1, "", true));
return default;
}
Invoke(o_506, "push", Call(pd_20, V.Undef, ((V)("M105 14Q426 44 747 14")), ((V)("none")), ((V)("#5a4a40")), ((V)(1.6))), Call(pd_20, V.Undef, ((V)("M0 70Q50 96 100 40")), ((V)("none")), ((V)("#5a4a40")), ((V)(1.6))), Call(pd_20, V.Undef, ((V)("M852 70Q802 96 752 40")), ((V)("none")), ((V)("#5a4a40")), ((V)(1.6))));
{
double n_579 = 0;
n_579 = 0D;
while (true) {
if (!((n_579 < 18D))) break;
double t_581 = 0;
double bx_582 = 0;
double by_583 = 0;
t_581 = ((n_579 + 0.5) / 18D);
bx_582 = (((((1D - t_581) * (1D - t_581)) * 105D) + (((2D * (1D - t_581)) * t_581) * 426D)) + ((t_581 * t_581) * 747D));
by_583 = ((((((1D - t_581) * (1D - t_581)) * 14D) + (((2D * (1D - t_581)) * t_581) * 44D)) + ((t_581 * t_581) * 14D)) + 6D);
Invoke(o_506, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)(bx_582)), ((V)(by_583)), ((V)(9D))), GetIdx(C_508, (n_579 % 6D)), ((V)(0D)), ((V)(0D)), ((V)(0.25))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)(bx_582)), ((V)(by_583)), ((V)(3.6)), ((V)(5D))), GetIdx(C_508, (n_579 % 6D)), Call(shade_11, V.Undef, GetIdx(C_508, (n_579 % 6D)), ((V)(0.75))), ((V)(0.8))));
n_579++;
}
}
return default;
}, 2, "ylights", false);
outl_51 = Fn((V _self584, int _argc585, V sh_591, V ua_592, V ub_593, V vb_594, V[] _rest586) => {
V P_596 = default;
double m_597 = 0;
double hw_598 = 0;
V vt_595 = default;
if (_self584.IsNullish) _self584 = GlobalV;
vt_595 = (_argc585 > 4 ? _rest586[0] : V.Undef);
P_596 = Arr(Arr(ua_592, vb_594), Arr(ub_593, vb_594));
m_597 = (ToNum(Add(ua_592, ub_593)) / 2D);
hw_598 = ((ToNum(ub_593) - ToNum(ua_592)) / 2D);
if (SEqS(sh_591, "arch")) {
V vs_599 = default;
vs_599 = Add(vb_594, ((V)(((ToNum(vt_595) - ToNum(vb_594)) * 0.64))));
Invoke(P_596, "push", Arr(ub_593, vs_599));
{
double i_600 = 0;
i_600 = 1D;
while (true) {
if (!((i_600 < 14D))) break;
double an_602 = 0;
an_602 = ((i_600 / 14D) * System.Math.PI);
Invoke(P_596, "push", Arr(((V)((m_597 + (hw_598 * FdLibm.Cos(an_602))))), Add(vs_599, ((V)(((ToNum(vt_595) - ToNum(vs_599)) * FdLibm.Sin(an_602)))))));
i_600++;
}
}
Invoke(P_596, "push", Arr(ua_592, vs_599));
} else {
if (SEqS(sh_591, "round")) {
double ru_603 = 0;
double rv_604 = 0;
ru_603 = (hw_598 * 0.42);
rv_604 = ((ToNum(vt_595) - ToNum(vb_594)) * 0.16);
{
double i_605 = 0;
i_605 = 0D;
while (true) {
if (!((i_605 <= 5D))) break;
double an_607 = 0;
an_607 = (((i_605 / 5D) * System.Math.PI) / 2D);
Invoke(P_596, "push", Arr(((V)(((ToNum(ub_593) - ru_603) + (ru_603 * FdLibm.Cos(an_607))))), ((V)(((ToNum(vt_595) - rv_604) + (rv_604 * FdLibm.Sin(an_607)))))));
i_605++;
}
}
{
double i_608 = 0;
i_608 = 0D;
while (true) {
if (!((i_608 <= 5D))) break;
double an_610 = 0;
an_610 = ((System.Math.PI / 2D) + (((i_608 / 5D) * System.Math.PI) / 2D));
Invoke(P_596, "push", Arr(Add(Add(ua_592, ((V)(ru_603))), ((V)((ru_603 * FdLibm.Cos(an_610))))), ((V)(((ToNum(vt_595) - rv_604) + (rv_604 * FdLibm.Sin(an_610)))))));
i_608++;
}
}
} else {
Invoke(P_596, "push", Arr(ub_593, vt_595), Arr(ua_592, vt_595));
}
}
return P_596;
return default;
}, 5, "outl", false);
door_54 = Fn((V _self611, int _argc612, V dd_618, V P_619, V o_620, V T_621, V[] _rest613) => {
V dark_626 = default;
V k_627 = default;
V side_628 = default;
V x_629 = default;
V isUp_630 = default;
V isDn_631 = default;
double @base_632 = 0;
double vh_633 = 0;
double t0_634 = 0;
double t1_635 = 0;
V M_636 = default;
V pth_637 = default;
V ln_638 = default;
V special_639 = default;
V sh_640 = default;
double du_641 = 0;
double vt_642 = 0;
double fT_643 = 0;
V frame_644 = default;
V inner_645 = default;
V sc_646 = default;
V st_647 = default;
double tm_648 = 0;
double y_649 = 0;
V ex_650 = default;
V R_622 = default;
V sp_623 = default;
V lockLv_624 = default;
V noLab_625 = default;
if (_self611.IsNullish) _self611 = GlobalV;
R_622 = (_argc612 > 4 ? _rest613[0] : V.Undef);
sp_623 = (_argc612 > 5 ? _rest613[1] : V.Undef);
lockLv_624 = (_argc612 > 6 ? _rest613[2] : V.Undef);
noLab_625 = (_argc612 > 7 ? _rest613[3] : V.Undef);
dark_626 = Get(R_622, "dark");
k_627 = (Get(sp_623, "k") is var _t651 && Truthy(_t651) ? _t651 : ((V)("arch")));
side_628 = (!SEqS(Get(dd_618, "s"), "B") ? V.True : V.False);
x_629 = Get(dd_618, "x");
isUp_630 = ((!(Truthy(side_628)) && SEqS(Get(dd_618, "k"), "up")) ? V.True : V.False);
isDn_631 = ((!(Truthy(side_628)) && SEqS(Get(dd_618, "k"), "down")) ? V.True : V.False);
@base_632 = 100D;
vh_633 = 74D;
t0_634 = 0.4;
t1_635 = 0.68;
M_636 = (Truthy(side_628) ? Fn((V _arrowThis660, int _argc652, V u_658, V v_659, V _a656, V _a657, V[] _rest653) => {
V p_661 = default;
p_661 = Call(sideB_25, V.Undef, Get(dd_618, "s"), ((V)((t0_634 + ((t1_635 - t0_634) * ToNum(u_658))))));
return Arr(GetIdx(p_661, 0D), ((V)((ToNum(GetIdx(p_661, 1D)) - ((72D * ToNum(Call(WY_24, V.Undef, GetIdx(p_661, 1D)))) * ToNum(v_659))))));
return default;
}, 2, "", true) : Fn((V _arrowThis670, int _argc662, V u_668, V v_669, V _a666, V _a667, V[] _rest663) => {
return Arr(((V)(((ToNum(x_629) - 31D) + (62D * ToNum(u_668))))), ((V)((@base_632 - (vh_633 * ToNum(v_669))))));
}, 2, "", true));
pth_637 = Fn((V _arrowThis678, int _argc671, V pts_677, V _a674, V _a675, V _a676, V[] _rest672) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_677, "map", Fn((V _arrowThis686, int _argc679, V q_685, V _a682, V _a683, V _a684, V[] _rest680) => {
V p_687 = default;
p_687 = Call(M_636, V.Undef, GetIdx(q_685, 0D), GetIdx(q_685, 1D));
return ((V)(JsStrBuf.Begin().V(Call(f1_12, V.Undef, GetIdx(p_687, 0D))).S(" ").V(Call(f1_12, V.Undef, GetIdx(p_687, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
ln_638 = Fn((V _arrowThis696, int _argc688, V a_694, V b_695, V _a692, V _a693, V[] _rest689) => {
V p_697 = default;
V q_698 = default;
p_697 = Call(M_636, V.Undef, GetIdx(a_694, 0D), GetIdx(a_694, 1D));
q_698 = Call(M_636, V.Undef, GetIdx(b_695, 0D), GetIdx(b_695, 1D));
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, GetIdx(p_697, 0D))).S(" ").V(Call(f1_12, V.Undef, GetIdx(p_697, 1D))).S("L").V(Call(f1_12, V.Undef, GetIdx(q_698, 0D))).S(" ").V(Call(f1_12, V.Undef, GetIdx(q_698, 1D))).End()));
return default;
}, 2, "", true);
special_639 = ((!(Truthy(side_628)) && ((SEqS(Get(dd_618, "k"), "up") || SEqS(Get(dd_618, "k"), "down")) || SEqS(Get(dd_618, "k"), "glass"))) ? V.True : V.False);
sh_640 = (Truthy(special_639) ? ((V)("arch")) : (GetK(SHAPE_50, k_627) is var _t699 && Truthy(_t699) ? _t699 : ((V)("arch"))));
du_641 = (Truthy(side_628) ? (0.03 / 0.28) : (5D / 62D));
vt_642 = (Truthy(side_628) ? 1D : 1D);
fT_643 = (Truthy(side_628) ? 1.08 : (80D / 74D));
frame_644 = Call(pth_637, V.Undef, Call(outl_51, V.Undef, sh_640, ((V)((-du_641))), ((V)((1D + du_641))), ((V)(0D)), ((V)(fT_643))));
inner_645 = Call(pth_637, V.Undef, Call(outl_51, V.Undef, sh_640, ((V)(0D)), ((V)(1D)), ((V)(0D)), ((V)(vt_642))));
sc_646 = (Truthy(side_628) ? Call(WY_24, V.Undef, GetIdx(Call(M_636, V.Undef, ((V)(0.5)), ((V)(0D))), 1D)) : ((V)(1D)));
st_647 = V.Null;
if (Truthy(isDn_631)) {
st_647 = Call(downStairs_67, V.Undef, o_620, x_629, lockLv_624, dark_626);
} else {
if (Truthy(dark_626)) {
Invoke(o_620, "push", Call(pd_20, V.Undef, frame_644, ((V)("#4fe0d0")), ((V)("#4fe0d0")), ((V)(6D)), ((V)(0.35))));
}
Invoke(o_620, "push", Call(pd_20, V.Undef, frame_644, (SEqS(k_627, "palace") ? GOLD_17 : Get(P_619, "trim")), Call(shade_11, V.Undef, (Truthy(dark_626) ? ((V)("#4fe0d0")) : Get(P_619, "trim")), ((V)(0.8))), ((V)(1.5))));
}
if (Truthy(special_639)) {
if (Truthy(isUp_630)) {
Invoke(o_620, "push", Call(pd_20, V.Undef, inner_645, ((V)("#3a2414"))));
{
double i_700 = 0;
i_700 = 0D;
while (true) {
if (!((i_700 < 5D))) break;
Invoke(o_620, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(x_629) - 27D) + (i_700 * 3D)))), ((V)((@base_632 - ((i_700 + 1D) * 8.5)))), ((V)((54D - (i_700 * 6D)))), ((V)(8.5)), ((V)(1D))), Call(shade_11, V.Undef, ((V)((NumTruthy((i_700 % 2D)) ? "#a86b36" : "#c98d58"))), ((V)((1D - (i_700 * 0.1)))))));
i_700++;
}
}
} else {
if (Truthy(isDn_631)) {

} else {
if (SEqS(Get(dd_618, "k"), "glass")) {
Invoke(o_620, "push", Call(pd_20, V.Undef, inner_645, ((V)("url(#hsSky)"))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_629) - 31D)).S(" 84Q").N((ToNum(x_629) - 10D)).S(" 72 ").V(Add(x_629, ((V)(8D)))).S(" 80T").V(Add(x_629, ((V)(31D)))).S(" 78V100H").N((ToNum(x_629) - 31D)).S("Z").End())), ((V)("#a8d08a"))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_629).S(" 26V100M").N((ToNum(x_629) - 31D)).S(" 62H").V(Add(x_629, ((V)(31D)))).End())), ((V)("none")), Get(P_619, "trim"), ((V)(4D))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_629, ((V)(24D))), ((V)(66D)), ((V)(3.5))), ((V)("url(#hsGold)"))));
}
}
}
} else {
V D_702 = default;
V DL_703 = default;
D_702 = Get(P_619, "door");
DL_703 = Get(P_619, "doorL");
Invoke(o_620, "push", Call(pd_20, V.Undef, inner_645, D_702));
if ((SEqS(k_627, "plank") || SEqS(k_627, "scuff"))) {
Invoke(o_620, "push", Call(pd_20, V.Undef, Add(Add(Call(ln_638, V.Undef, Arr(((V)(0.25)), ((V)(0D))), Arr(((V)(0.25)), ((V)(1D)))), Call(ln_638, V.Undef, Arr(((V)(0.5)), ((V)(0D))), Arr(((V)(0.5)), ((V)(1D))))), Call(ln_638, V.Undef, Arr(((V)(0.75)), ((V)(0D))), Arr(((V)(0.75)), ((V)(1D))))), ((V)("none")), Call(shade_11, V.Undef, D_702, ((V)(0.78))), ((V)(1.4))), Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(box2_53, V.Undef, ((V)(0D)), ((V)(1D)), ((V)(0.27)), ((V)(0.35)))), Call(shade_11, V.Undef, D_702, ((V)(0.85)))), Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(box2_53, V.Undef, ((V)(0D)), ((V)(1D)), ((V)(0.68)), ((V)(0.76)))), Call(shade_11, V.Undef, D_702, ((V)(0.85)))), Call(pd_20, V.Undef, Call(ln_638, V.Undef, Arr(((V)(0D)), ((V)(0.31))), Arr(((V)(1D)), ((V)(0.72)))), ((V)("none")), Call(shade_11, V.Undef, D_702, ((V)(0.82))), ((V)(3D))));
if (SEqS(k_627, "scuff")) {
Invoke(o_620, "push", Call(pd_20, V.Undef, Add(Call(ln_638, V.Undef, Arr(((V)(0.15)), ((V)(0.5))), Arr(((V)(0.32)), ((V)(0.46)))), Call(ln_638, V.Undef, Arr(((V)(0.6)), ((V)(0.15))), Arr(((V)(0.8)), ((V)(0.19))))), ((V)("none")), Call(shade_11, V.Undef, D_702, ((V)(0.62))), ((V)(1.4))));
}
} else {
if (SEqS(k_627, "jet")) {
Invoke(o_620, "push", Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(ell2_52, V.Undef, ((V)(0.5)), ((V)(0.66)), ((V)(0.24)), ((V)(0.16)))), ((V)("url(#hsSky)")), ((V)("#d5dde2")), ((V)((3D * ToNum(sc_646))))), Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(box2_53, V.Undef, ((V)(0.14)), ((V)(0.86)), ((V)(0.3)), ((V)(0.34)))), DL_703), Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(box2_53, V.Undef, ((V)(0.14)), ((V)(0.86)), ((V)(0.2)), ((V)(0.24)))), DL_703));
} else {
if (SEqS(k_627, "flush")) {
Invoke(o_620, "push", Call(pd_20, V.Undef, Call(ln_638, V.Undef, Arr(((V)(0.12)), ((V)(0.02))), Arr(((V)(0.12)), ((V)(0.98)))), ((V)("none")), Call(shade_11, V.Undef, D_702, ((V)(0.9))), ((V)(1D))), Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(box2_53, V.Undef, ((V)(0.8)), ((V)(0.86)), ((V)(0.38)), ((V)(0.64)))), ((V)("#2c2d31"))));
} else {
if (SEqS(k_627, "ginger")) {
JsStrBuf z_704 = null;
Invoke(o_620, "push", Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(outl_51, V.Undef, ((V)("arch")), ((V)(0.08)), ((V)(0.92)), ((V)(0.06)), ((V)(0.92)))), ((V)("none")), CR_15, ((V)((2.4 * ToNum(sc_646))))));
Invoke(Arr(Arr(((V)(0.3)), ((V)(0.6)), ((V)("#e2554a"))), Arr(((V)(0.7)), ((V)(0.6)), ((V)("#a6f06a"))), Arr(((V)(0.5)), ((V)(0.36)), ((V)("#6ac8ff")))), "forEach", Fn((V _arrowThis718, int _argc705, V _a707, V _a708, V _a709, V _a710, V[] _rest706) => {
V u_713 = default;
V v_715 = default;
V c_717 = default;
{ V _t711 = ListOf(_a707);
{ V _t712 = GetIdx(_t711, 0D);
u_713 = _t712; }
{ V _t714 = GetIdx(_t711, 1D);
v_715 = _t714; }
{ V _t716 = GetIdx(_t711, 2D);
c_717 = _t716; }
}
return Invoke(o_620, "push", Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(ell2_52, V.Undef, u_713, v_715, ((V)(0.08)), ((V)(0.06)), ((V)(12D)))), c_717), Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(ell2_52, V.Undef, ((V)((ToNum(u_713) - 0.025))), Add(v_715, ((V)(0.02))), ((V)(0.025)), ((V)(0.02)), ((V)(8D)))), WH_16, ((V)(0D)), ((V)(0D)), ((V)(0.7))));
}, 1, "", true));
z_704 = new JsStrBuf("");
{
double i_719 = 0;
i_719 = 0D;
while (true) {
if (!((i_719 <= 8D))) break;
V p_721 = default;
p_721 = Call(M_636, V.Undef, ((V)((0.12 + (i_719 * 0.095)))), ((V)((0.16 + ((i_719 % 2D) * 0.05)))));
z_704.S((NumTruthy(i_719) ? "L" : "M")).V(Call(f1_12, V.Undef, GetIdx(p_721, 0D))).S(" ").V(Call(f1_12, V.Undef, GetIdx(p_721, 1D)));
i_719++;
}
}
Invoke(o_620, "push", Call(pd_20, V.Undef, ((V)(z_704.Str)), ((V)("none")), CR_15, ((V)((2.4 * ToNum(sc_646))))));
} else {
double pc_722 = 0;
pc_722 = (SEqS(k_627, "palace") ? 1D : 0.75);
Invoke(o_620, "push", Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(box2_53, V.Undef, ((V)(0.15)), ((V)(0.85)), ((V)(0.08)), ((V)(0.42)))), DL_703, ((V)(0D)), ((V)(0D)), ((V)(pc_722))), Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(outl_51, V.Undef, ((V)("arch")), ((V)(0.15)), ((V)(0.85)), ((V)(0.5)), ((V)(0.9)))), DL_703, ((V)(0D)), ((V)(0D)), ((V)(pc_722))));
if (SEqS(k_627, "palace")) {
Invoke(o_620, "push", Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(box2_53, V.Undef, ((V)(0.22)), ((V)(0.78)), ((V)(0.13)), ((V)(0.37)))), D_702), Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(outl_51, V.Undef, ((V)("arch")), ((V)(0.22)), ((V)(0.78)), ((V)(0.55)), ((V)(0.84)))), D_702), Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(box2_53, V.Undef, ((V)(0.15)), ((V)(0.85)), ((V)(0.08)), ((V)(0.42)))), ((V)("none")), GOLD_17, ((V)((1.4 * ToNum(sc_646))))));
}
}
}
}
}
if (!SEqS(k_627, "flush")) {
V kp_723 = default;
kp_723 = Call(M_636, V.Undef, ((V)(0.86)), ((V)(0.46)));
Invoke(o_620, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, GetIdx(kp_723, 0D), GetIdx(kp_723, 1D), ((V)((4D * ToNum(sc_646))))), ((V)("url(#hsGold)"))));
}
}
if (Truthy((lockLv_624 is var _t724 && !Truthy(_t724) ? _t724 : (!(Truthy(isDn_631)) ? V.True : V.False)))) {
V m_725 = default;
Invoke(Arr(Arr(((V)(0.18)), ((V)(0.3))), Arr(((V)(0.52)), ((V)(0.64))), Arr(((V)(0.82)), ((V)(0.94)))), "forEach", Fn((V _arrowThis738, int _argc726, V _a728, V i_732, V _a730, V _a731, V[] _rest727) => {
V a_735 = default;
V b_737 = default;
{ V _t733 = ListOf(_a728);
{ V _t734 = GetIdx(_t733, 0D);
a_735 = _t734; }
{ V _t736 = GetIdx(_t733, 1D);
b_737 = _t736; }
}
return Invoke(o_620, "push", Call(pd_20, V.Undef, Call(pth_637, V.Undef, Call(box2_53, V.Undef, ((V)((-0.05))), ((V)(1.05)), a_735, b_737)), ((V)((NumTruthy((ToNum(i_732) % 2D)) ? "#a07a50" : "#b08a5e"))), ((V)("#7d6248")), ((V)(1D))));
}, 2, "", true));
m_725 = Call(M_636, V.Undef, ((V)(0.5)), ((V)(0.58)));
Call(@lock_68, V.Undef, o_620, GetIdx(m_725, 0D), GetIdx(m_725, 1D));
}
if (!(Truthy(noLab_625))) {
V lab_739 = default;
V S3_740 = default;
V top_741 = default;
V cx_742 = default;
double w_743 = 0;
double h_744 = 0;
double cy_745 = 0;
double ny_746 = 0;
lab_739 = ((V)((Truthy(lockLv_624) ? JsStrBuf.Begin().S("Lv ").V(lockLv_624).S(" \u00b7 ").V(GetK(NAME_33, Get(dd_618, "to"))).End() : JsStrBuf.Begin().V((GetK(ARROW_48, Get(dd_618, "k")) is var _t747 && Truthy(_t747) ? _t747 : ((V)("")))).S((Truthy(Get(dd_618, "lab")) ? JsStrBuf.Begin().V(Get(dd_618, "lab")).S(" \u00b7 ").End() : "")).V(GetK(NAME_33, Get(dd_618, "to"))).End())));
S3_740 = (Truthy(lockLv_624) ? Get(SIGN_49, "scuff") : (GetK(SIGN_49, k_627) is var _t748 && Truthy(_t748) ? _t748 : Get(SIGN_49, "arch")));
top_741 = (Truthy(isDn_631) ? Arr(x_629, ((V)(74D))) : Call(M_636, V.Undef, ((V)(0.5)), ((V)(fT_643))));
cx_742 = GetIdx(top_741, 0D);
w_743 = (14D + (ToNum(Get(lab_739, "length")) * 5.1));
h_744 = 15D;
cy_745 = ((ToNum(GetIdx(top_741, 1D)) - 6D) - (h_744 / 2D));
ny_746 = ((cy_745 - (h_744 / 2D)) - 7D);
Invoke(o_620, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, cx_742)).S(" ").V(Call(f1_12, V.Undef, ((V)(ny_746)))).S("L").V(Call(f1_12, V.Undef, ((V)((ToNum(cx_742) - (w_743 * 0.32)))))).S(" ").V(Call(f1_12, V.Undef, ((V)((cy_745 - (h_744 / 2D)))))).S("M").V(Call(f1_12, V.Undef, cx_742)).S(" ").V(Call(f1_12, V.Undef, ((V)(ny_746)))).S("L").V(Call(f1_12, V.Undef, Add(cx_742, ((V)((w_743 * 0.32)))))).S(" ").V(Call(f1_12, V.Undef, ((V)((cy_745 - (h_744 / 2D)))))).End())), ((V)("none")), ((V)("#6b4426")), ((V)(1.2))));
Invoke(o_620, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(cx_742) - (w_743 / 2D)))), ((V)(((cy_745 - (h_744 / 2D)) + 1.5))), ((V)(w_743)), ((V)(h_744)), ((V)(3D))), ((V)("rgba(60,30,10,0.25)"))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(cx_742) - (w_743 / 2D)))), ((V)((cy_745 - (h_744 / 2D)))), ((V)(w_743)), ((V)(h_744)), ((V)(3D))), (Truthy((dark_626 is var _t749 && !Truthy(_t749) ? _t749 : (!(Truthy(lockLv_624)) ? V.True : V.False))) ? ((V)("#1c1f4d")) : GetIdx(S3_740, 0D)), (Truthy((dark_626 is var _t750 && !Truthy(_t750) ? _t750 : (!(Truthy(lockLv_624)) ? V.True : V.False))) ? ((V)("#4fe0d0")) : GetIdx(S3_740, 1D)), ((V)(1.8))));
if ((SEqS(k_627, "palace") && !(Truthy(lockLv_624)))) {
Invoke(o_620, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(cx_742) - (w_743 / 2D)) + 2.5))), ((V)(((cy_745 - (h_744 / 2D)) + 2.5))), ((V)((w_743 - 5D))), ((V)((h_744 - 5D))), ((V)(2D))), ((V)("none")), GOLD_17, ((V)(1D))));
}
if ((SEqS(k_627, "ginger") && !(Truthy(lockLv_624)))) {
Invoke(o_620, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(((ToNum(cx_742) - (w_743 / 2D)) + 2.5))), ((V)(((cy_745 - (h_744 / 2D)) + 2.5))), ((V)((w_743 - 5D))), ((V)((h_744 - 5D))), ((V)(2D))), ((V)("none")), CR_15, ((V)(1.2))));
}
Invoke(o_620, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, cx_742, ((V)(ny_746)), ((V)(2.2))), ((V)("url(#hsGold)")), ((V)("#6b4426")), ((V)(0.8))));
Invoke(T_621, "push", NewObj(5).Put("x", cx_742).Put("y", ((V)((cy_745 + 3.6)))).Put("t", lab_739).Put("f", (Truthy(lockLv_624) ? ((V)("#b23a2e")) : (Truthy(dark_626) ? ((V)("#bffcf4")) : GetIdx(S3_740, 2D)))).Put("sz", ((V)(8.8))).V);
}
if (Truthy(st_647)) {
return NewObj(3).Put("hit", Add((Truthy(isDn_631) ? ((V)("")) : frame_644), Get(st_647, "hit"))).Put("spawn", Arr(Get(st_647, "foot"), ((V)(134D)))).Put("walk", Arr(Get(st_647, "foot"), ((V)(176D)))).V;
}
if (!(Truthy(side_628))) {
return NewObj(3).Put("hit", frame_644).Put("spawn", Arr(x_629, ((V)(134D)))).Put("walk", Arr(x_629, ((V)(176D)))).V;
}
tm_648 = ((t0_634 + t1_635) / 2D);
y_649 = Max(ToNum(Add(FY0_19, ((V)(6D)))), ((100D + (162D * tm_648)) + 10D));
ex_650 = Add(Invoke(X_8, "edge", ((V)(y_649))), ((V)(30D)));
return NewObj(3).Put("hit", frame_644).Put("spawn", Arr((SEqS(Get(dd_618, "s"), "L") ? ex_650 : ((V)((VW_18 - ToNum(ex_650))))), ((V)(y_649)))).Put("walk", Arr((SEqS(Get(dd_618, "s"), "L") ? Add(ex_650, ((V)(90D))) : ((V)(((VW_18 - ToNum(ex_650)) - 90D)))), ((V)((y_649 + 10D))))).V;
return default;
}, 8, "door", false);
upStairs_66 = Fn((V _self751, int _argc752, V o_758, V x_759, V _a756, V _a757, V[] _rest753) => {
double dir_760 = 0;
V Z_761 = default;
V LH_762 = default;
double hw_763 = 0;
double n_764 = 0;
double sw_765 = 0;
double rise_766 = 0;
V ex_767 = default;
double far_768 = 0;
V foot_769 = default;
double hl_770 = 0;
V blocks_771 = default;
double lo_772 = 0;
double hi_773 = 0;
V wr_774 = default;
JsStrBuf br_775 = null;
double RH_776 = 0;
double zr_777 = 0;
double nx_778 = 0;
JsStrBuf posts_779 = null;
V rail_780 = default;
V k_781 = default;
V hit_782 = default;
if (_self751.IsNullish) _self751 = GlobalV;
dir_760 = (GtN(x_759, SC_55) ? (-1D) : 1D);
Z_761 = Get(ST_56, "Z");
LH_762 = Get(ST_56, "LH");
hw_763 = 34D;
n_764 = 4D;
sw_765 = 14D;
rise_766 = 8D;
ex_767 = Add(x_759, ((V)((dir_760 * hw_763))));
far_768 = (ToNum(x_759) - (dir_760 * hw_763));
foot_769 = Add(ex_767, ((V)(((dir_760 * sw_765) * n_764))));
hl_770 = (ToNum(LH_762) - (rise_766 * n_764));
blocks_771 = Arr(Arr(((V)((ToNum(x_759) - hw_763))), Add(x_759, ((V)(hw_763))), LH_762));
{
double j_783 = 0;
j_783 = 0D;
while (true) {
if (!((j_783 < n_764))) break;
V a_785 = default;
V b_786 = default;
a_785 = Add(ex_767, ((V)(((dir_760 * sw_765) * j_783))));
b_786 = Add(ex_767, ((V)(((dir_760 * sw_765) * (j_783 + 1D)))));
Invoke(blocks_771, "push", Arr(((V)(Min(ToNum(a_785), ToNum(b_786)))), ((V)(Max(ToNum(a_785), ToNum(b_786)))), ((V)((ToNum(LH_762) - (rise_766 * (j_783 + 1D)))))));
j_783++;
}
}
lo_772 = Min(ToNum(foot_769), far_768);
hi_773 = Max(ToNum(foot_769), far_768);
Invoke(o_758, "push", Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(((V)((lo_772 - 3D))), ((V)((ToNum(Z_761) - 4D))), ((V)(0D))), Arr(((V)((hi_773 + 3D))), ((V)((ToNum(Z_761) - 4D))), ((V)(0D))), Arr(((V)((hi_773 + 6D))), Add(Z_761, ((V)(5D))), ((V)(0D))), Arr(((V)((lo_772 - 6D))), Add(Z_761, ((V)(5D))), ((V)(0D))))), ((V)("#2a1608")), ((V)(0D)), ((V)(0D)), ((V)(0.18))));
wr_774 = Call(wp_58, V.Undef, Arr(Arr(foot_769, ((V)(1D)), ((V)((hl_770 + 15D)))), Arr(ex_767, ((V)(1D)), Add(LH_762, ((V)(15D))))), ((V)(1D)));
br_775 = new JsStrBuf("");
{
double j_787 = 0;
j_787 = 1D;
while (true) {
if (!((j_787 < n_764))) break;
V bx_789 = default;
double h_790 = 0;
bx_789 = Add(ex_767, ((V)(((dir_760 * sw_765) * (j_787 + 0.5)))));
h_790 = ((ToNum(LH_762) - (rise_766 * (j_787 + 1D))) + 15D);
br_775.V(Call(wp_58, V.Undef, Arr(Arr(bx_789, ((V)(1D)), ((V)(h_790))), Arr(bx_789, ((V)(1D)), ((V)((h_790 - 6D))))), ((V)(1D))));
j_787 = (j_787 + 2D);
}
}
Invoke(o_758, "push", Call(pd_20, V.Undef, ((V)(br_775.Str)), ((V)("none")), RD_64, ((V)(1.4))), Call(pd_20, V.Undef, wr_774, ((V)("none")), RD_64, ((V)(3.4))), Call(pd_20, V.Undef, wr_774, ((V)("none")), RL_63, ((V)(1.6))));
Invoke(blocks_771, "forEach", Fn((V _arrowThis804, int _argc791, V _a793, V _a794, V _a795, V _a796, V[] _rest792) => {
V xs_805 = default;
V a_799 = default;
V b_801 = default;
V h_803 = default;
{ V _t797 = ListOf(_a793);
{ V _t798 = GetIdx(_t797, 0D);
a_799 = _t798; }
{ V _t800 = GetIdx(_t797, 1D);
b_801 = _t800; }
{ V _t802 = GetIdx(_t797, 2D);
h_803 = _t802; }
}
xs_805 = ((dir_760 < 0D) ? a_799 : b_801);
Invoke(o_758, "push", Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(xs_805, ((V)(0D)), h_803), Arr(xs_805, Z_761, h_803), Arr(xs_805, Z_761, ((V)(0D))), Arr(xs_805, ((V)(0D)), ((V)(0D))))), WS_61, WE_62, ((V)(1D))));
Invoke(o_758, "push", Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(a_799, Z_761, h_803), Arr(b_801, Z_761, h_803), Arr(b_801, Z_761, ((V)(0D))), Arr(a_799, Z_761, ((V)(0D))))), WF_60, WE_62, ((V)(1D))));
Invoke(o_758, "push", Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(a_799, ((V)(0D)), h_803), Arr(b_801, ((V)(0D)), h_803), Arr(b_801, Z_761, h_803), Arr(a_799, Z_761, h_803))), WT_59, WE_62, ((V)(1D))));
Invoke(o_758, "push", Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(Add(a_799, ((V)(1D))), Z_761, h_803), Arr(((V)((ToNum(b_801) - 1D))), Z_761, h_803)), ((V)(1D))), ((V)("none")), NOSE_65, ((V)(1.4))));
if (Lt(h_803, LH_762)) {
Invoke(o_758, "push", Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(Add(a_799, ((V)(1D))), Z_761, ((V)((ToNum(h_803) - 2.5)))), Arr(((V)((ToNum(b_801) - 1D))), Z_761, ((V)((ToNum(h_803) - 2.5))))), ((V)(1D))), ((V)("none")), WE_62, ((V)(0.8)), ((V)(0.5))));
}
return default;
}, 1, "", true));
Invoke(o_758, "push", Call(pd_20, V.Undef, Add(Call(wp_58, V.Undef, Arr(Arr(((V)(((ToNum(x_759) - hw_763) + 4D))), Z_761, ((V)((ToNum(LH_762) - 10D)))), Arr(((V)((ToNum(Add(x_759, ((V)(hw_763)))) - 4D))), Z_761, ((V)((ToNum(LH_762) - 10D))))), ((V)(1D))), Call(wp_58, V.Undef, Arr(Arr(((V)(((ToNum(x_759) - hw_763) + 4D))), Z_761, ((V)((ToNum(LH_762) - 22D)))), Arr(((V)((ToNum(Add(x_759, ((V)(hw_763)))) - 4D))), Z_761, ((V)((ToNum(LH_762) - 22D))))), ((V)(1D)))), ((V)("none")), WE_62, ((V)(0.8)), ((V)(0.45))));
RH_776 = 17D;
zr_777 = (ToNum(Z_761) - 2.5);
nx_778 = (ToNum(foot_769) - (dir_760 * 3D));
posts_779 = new JsStrBuf("");
{
double j_806 = 0;
j_806 = 0D;
while (true) {
if (!((j_806 < (n_764 - 1D)))) break;
V px_808 = default;
double h_809 = 0;
px_808 = Add(ex_767, ((V)(((dir_760 * sw_765) * (j_806 + 0.5)))));
h_809 = (ToNum(LH_762) - (rise_766 * (j_806 + 1D)));
posts_779.V(Call(wp_58, V.Undef, Arr(Arr(px_808, ((V)(zr_777)), ((V)(h_809))), Arr(px_808, ((V)(zr_777)), ((V)((h_809 + RH_776))))), ((V)(1D))));
j_806++;
}
}
{
double i_810 = 0;
i_810 = 0D;
while (true) {
if (!((i_810 <= 5D))) break;
double px_812 = 0;
px_812 = (ToNum(ex_767) - (((dir_760 * ((2D * hw_763) - 3D)) * i_810) / 5D));
posts_779.V(Call(wp_58, V.Undef, Arr(Arr(((V)(px_812)), ((V)(zr_777)), LH_762), Arr(((V)(px_812)), ((V)(zr_777)), Add(LH_762, ((V)(RH_776))))), ((V)(1D))));
i_810++;
}
}
{
double i_813 = 0;
i_813 = 1D;
while (true) {
if (!((i_813 < 3D))) break;
double z_815 = 0;
z_815 = ((zr_777 * i_813) / 3D);
posts_779.V(Call(wp_58, V.Undef, Arr(Arr(((V)((far_768 + (dir_760 * 3D)))), ((V)(z_815)), LH_762), Arr(((V)((far_768 + (dir_760 * 3D)))), ((V)(z_815)), Add(LH_762, ((V)(RH_776))))), ((V)(1D))));
i_813++;
}
}
rail_780 = Call(wp_58, V.Undef, Arr(Arr(((V)(nx_778)), ((V)(zr_777)), ((V)(((hl_770 + RH_776) + 2D)))), Arr(ex_767, ((V)(zr_777)), Add(LH_762, ((V)(RH_776)))), Arr(((V)((far_768 + (dir_760 * 3D)))), ((V)(zr_777)), Add(LH_762, ((V)(RH_776)))), Arr(((V)((far_768 + (dir_760 * 3D)))), ((V)(1D)), Add(LH_762, ((V)(RH_776))))), ((V)(1D)));
Invoke(o_758, "push", Call(pd_20, V.Undef, ((V)(posts_779.Str)), ((V)("none")), RD_64, ((V)(1.6))), Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(((V)(nx_778)), ((V)(zr_777)), ((V)(hl_770))), Arr(((V)(nx_778)), ((V)(zr_777)), ((V)(((hl_770 + RH_776) + 3D))))), ((V)(1D))), ((V)("none")), RD_64, ((V)(4.4))), Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(((V)(nx_778)), ((V)(zr_777)), ((V)(hl_770))), Arr(((V)(nx_778)), ((V)(zr_777)), ((V)(((hl_770 + RH_776) + 3D))))), ((V)(1D))), ((V)("none")), RL_63, ((V)(2D))));
Invoke(o_758, "push", Call(pd_20, V.Undef, rail_780, ((V)("none")), RD_64, ((V)(4.4))), Call(pd_20, V.Undef, rail_780, ((V)("none")), RL_63, ((V)(2.2))));
k_781 = Call(PW_57, V.Undef, ((V)(nx_778)), ((V)(zr_777)), ((V)(((hl_770 + RH_776) + 4D))));
Invoke(o_758, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, GetIdx(k_781, 0D), GetIdx(k_781, 1D), ((V)(3D))), RL_63, RD_64, ((V)(1.2))));
hit_782 = Add(Call(wp_58, V.Undef, Arr(Arr(((V)((lo_772 - 4D))), ((V)(0D)), ((V)(0D))), Arr(((V)((hi_773 + 4D))), ((V)(0D)), ((V)(0D))), Arr(((V)((hi_773 + 4D))), Add(Z_761, ((V)(4D))), ((V)(0D))), Arr(((V)((lo_772 - 4D))), Add(Z_761, ((V)(4D))), ((V)(0D))))), Call(wp_58, V.Undef, Arr(Arr(((V)((ToNum(x_759) - hw_763))), Z_761, Add(LH_762, ((V)(RH_776)))), Arr(Add(x_759, ((V)(hw_763))), Z_761, Add(LH_762, ((V)(RH_776)))), Arr(Add(x_759, ((V)(hw_763))), Z_761, ((V)(0D))), Arr(((V)(lo_772)), Z_761, ((V)(0D))), Arr(((V)(lo_772)), Z_761, ((V)((hl_770 + RH_776)))))));
return NewObj(2).Put("hit", hit_782).Put("foot", Add(foot_769, ((V)((dir_760 * 10D))))).V;
return default;
}, 2, "upStairs", false);
downStairs_67 = Fn((V _self816, int _argc817, V o_823, V x_824, V lockLv_825, V dark_826, V[] _rest818) => {
double dir_827 = 0;
double Z_828 = 0;
double hw_829 = 0;
double n_830 = 0;
double d_831 = 0;
double sw_832 = 0;
double a_833 = 0;
V b_834 = default;
V ent_835 = default;
double far_836 = 0;
V pit_837 = default;
double RH_838 = 0;
double zr_839 = 0;
double s0_840 = 0;
double s1_841 = 0;
JsStrBuf posts_842 = null;
V rail_843 = default;
V k_844 = default;
V hit_845 = default;
if (_self816.IsNullish) _self816 = GlobalV;
dir_827 = (GtN(x_824, SC_55) ? (-1D) : 1D);
Z_828 = 34D;
hw_829 = 46D;
n_830 = 5D;
d_831 = 6.4;
sw_832 = ((2D * hw_829) / n_830);
a_833 = (ToNum(x_824) - hw_829);
b_834 = Add(x_824, ((V)(hw_829)));
ent_835 = ((dir_827 < 0D) ? ((V)(a_833)) : b_834);
far_836 = (ToNum(ent_835) - ((dir_827 * 2D) * hw_829));
pit_837 = Call(wp_58, V.Undef, Arr(Arr(((V)(a_833)), ((V)(0D)), ((V)(0D))), Arr(b_834, ((V)(0D)), ((V)(0D))), Arr(b_834, ((V)(Z_828)), ((V)(0D))), Arr(((V)(a_833)), ((V)(Z_828)), ((V)(0D)))));
Invoke(o_823, "push", Call(pd_20, V.Undef, pit_837, ((V)((Truthy(dark_826) ? "#0e0b20" : "#2a1a10")))));
{
double j_846 = 0;
j_846 = 0D;
while (true) {
if (!((j_846 < n_830))) break;
double dj_848 = 0;
double x0_849 = 0;
double x1_850 = 0;
V tc_851 = default;
double zc_852 = 0;
dj_848 = (d_831 * (j_846 + 1D));
if ((dj_848 >= Z_828)) {
break;
}
x0_849 = (ToNum(ent_835) - ((dir_827 * sw_832) * j_846));
x1_850 = (ToNum(ent_835) - ((dir_827 * sw_832) * (j_846 + 1D)));
tc_851 = Call(shade_11, V.Undef, WT_59, ((V)((1D - (j_846 * 0.16)))));
zc_852 = (Z_828 - dj_848);
Invoke(o_823, "push", Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(((V)(x0_849)), ((V)(0D)), ((V)((-dj_848)))), Arr(((V)(x1_850)), ((V)(0D)), ((V)((-dj_848)))), Arr(((V)(x1_850)), ((V)(zc_852)), ((V)((-dj_848)))), Arr(((V)(x0_849)), ((V)(zc_852)), ((V)((-dj_848)))))), tc_851));
Invoke(o_823, "push", Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(((V)(x0_849)), ((V)(0D)), ((V)((-dj_848)))), Arr(((V)(x1_850)), ((V)(0D)), ((V)((-dj_848))))), ((V)(1D))), ((V)("none")), ((V)("#1a0e06")), ((V)(1.6)), ((V)(0.6))));
if ((j_846 < (n_830 - 1D))) {
Invoke(o_823, "push", Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(((V)(x1_850)), ((V)(0D)), ((V)((-dj_848)))), Arr(((V)(x1_850)), ((V)(zc_852)), ((V)((-dj_848))))), ((V)(1D))), ((V)("none")), NOSE_65, ((V)(1.6)), ((V)((0.85 - (j_846 * 0.15))))));
}
j_846++;
}
}
Invoke(o_823, "push", Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(((V)(a_833)), ((V)(0D)), ((V)(0D))), Arr(b_834, ((V)(0D)), ((V)(0D))), Arr(b_834, ((V)(7D)), ((V)(0D))), Arr(((V)(a_833)), ((V)(7D)), ((V)(0D))))), ((V)("#000000")), ((V)(0D)), ((V)(0D)), ((V)(0.22))));
Invoke(o_823, "push", Call(pd_20, V.Undef, pit_837, ((V)("none")), WE_62, ((V)(2D))), Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(((V)(a_833)), ((V)(Z_828)), ((V)(0D))), Arr(b_834, ((V)(Z_828)), ((V)(0D)))), ((V)(1D))), ((V)("none")), NOSE_65, ((V)(1.2)), ((V)(0.6))));
if (Truthy(lockLv_825)) {
V m_853 = default;
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis861, int _argc854, V i_860, V _a857, V _a858, V _a859, V[] _rest855) => {
return Invoke(o_823, "push", Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(((V)((a_833 - 5D))), ((V)((2D + (ToNum(i_860) * 8.6)))), ((V)(0D))), Arr(Add(b_834, ((V)(5D))), ((V)((2D + (ToNum(i_860) * 8.6)))), ((V)(0D))), Arr(Add(b_834, ((V)(5D))), ((V)((8.5 + (ToNum(i_860) * 8.6)))), ((V)(0D))), Arr(((V)((a_833 - 5D))), ((V)((8.5 + (ToNum(i_860) * 8.6)))), ((V)(0D))))), ((V)((NumTruthy((ToNum(i_860) % 2D)) ? "#a07a50" : "#b08a5e"))), ((V)("#7d6248")), ((V)(1D))));
}, 1, "", true));
m_853 = Call(PW_57, V.Undef, x_824, ((V)((Z_828 / 2D))), ((V)(0D)));
Call(@lock_68, V.Undef, o_823, GetIdx(m_853, 0D), ((V)((ToNum(GetIdx(m_853, 1D)) - 4D))));
}
RH_838 = 15D;
zr_839 = (Z_828 + 1.5);
s0_840 = (ToNum(ent_835) - (dir_827 * 3D));
s1_841 = (far_836 + (dir_827 * 2D));
posts_842 = new JsStrBuf("");
{
double i_862 = 0;
i_862 = 1D;
while (true) {
if (!((i_862 <= 4D))) break;
double px_864 = 0;
px_864 = (s0_840 + (((s1_841 - s0_840) * i_862) / 4D));
posts_842.V(Call(wp_58, V.Undef, Arr(Arr(((V)(px_864)), ((V)(zr_839)), ((V)(0D))), Arr(((V)(px_864)), ((V)(zr_839)), ((V)(RH_838)))), ((V)(1D))));
i_862++;
}
}
{
double i_865 = 0;
i_865 = 1D;
while (true) {
if (!((i_865 < 3D))) break;
double z_867 = 0;
z_867 = ((zr_839 * i_865) / 3D);
posts_842.V(Call(wp_58, V.Undef, Arr(Arr(((V)(s1_841)), ((V)(z_867)), ((V)(0D))), Arr(((V)(s1_841)), ((V)(z_867)), ((V)(RH_838)))), ((V)(1D))));
i_865++;
}
}
rail_843 = Call(wp_58, V.Undef, Arr(Arr(((V)(s0_840)), ((V)(zr_839)), ((V)((RH_838 + 1D)))), Arr(((V)(s1_841)), ((V)(zr_839)), ((V)(RH_838))), Arr(((V)(s1_841)), ((V)(1D)), ((V)(RH_838)))), ((V)(1D)));
Invoke(o_823, "push", Call(pd_20, V.Undef, ((V)(posts_842.Str)), ((V)("none")), RD_64, ((V)(1.6))), Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(((V)(s0_840)), ((V)(zr_839)), ((V)(0D))), Arr(((V)(s0_840)), ((V)(zr_839)), ((V)((RH_838 + 3D))))), ((V)(1D))), ((V)("none")), RD_64, ((V)(4.4))), Call(pd_20, V.Undef, Call(wp_58, V.Undef, Arr(Arr(((V)(s0_840)), ((V)(zr_839)), ((V)(0D))), Arr(((V)(s0_840)), ((V)(zr_839)), ((V)((RH_838 + 3D))))), ((V)(1D))), ((V)("none")), RL_63, ((V)(2D))));
Invoke(o_823, "push", Call(pd_20, V.Undef, rail_843, ((V)("none")), RD_64, ((V)(4.4))), Call(pd_20, V.Undef, rail_843, ((V)("none")), RL_63, ((V)(2.2))));
k_844 = Call(PW_57, V.Undef, ((V)(s0_840)), ((V)(zr_839)), ((V)((RH_838 + 4D))));
Invoke(o_823, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, GetIdx(k_844, 0D), GetIdx(k_844, 1D), ((V)(3D))), RL_63, RD_64, ((V)(1.2))));
hit_845 = Call(wp_58, V.Undef, Arr(Arr(((V)((a_833 - 4D))), ((V)(0D)), ((V)(RH_838))), Arr(Add(b_834, ((V)(4D))), ((V)(0D)), ((V)(RH_838))), Arr(Add(b_834, ((V)(4D))), ((V)((Z_828 + 5D))), ((V)(0D))), Arr(((V)((a_833 - 4D))), ((V)((Z_828 + 5D))), ((V)(0D)))));
return NewObj(2).Put("hit", hit_845).Put("foot", Add(ent_835, ((V)((dir_827 * 14D))))).V;
return default;
}, 4, "downStairs", false);
@lock_68 = Fn((V _self868, int _argc869, V o_875, V x_876, V y_877, V _a874, V[] _rest870) => {
if (_self868.IsNullish) _self868 = GlobalV;
Invoke(o_875, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_876) - 5D)).S(" ").N((ToNum(y_877) - 2D)).S("V").N((ToNum(y_877) - 7D)).S("a5 5 0 0 1 10 0V").N((ToNum(y_877) - 2D)).End())), ((V)("none")), ((V)("#5a5450")), ((V)(2.6))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_876) - 8D))), ((V)((ToNum(y_877) - 2D))), ((V)(16D)), ((V)(13D)), ((V)(3D))), ((V)("url(#hsGold)")), ((V)("#a87a1a")), ((V)(1D))), Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_876, Add(y_877, ((V)(4D))), ((V)(1.8))), ((V)("#7a5a10"))));
return default;
}, 3, "lock", false);
boards_69 = Fn((V _self878, int _argc879, V o_885, V x_886, V y_887, V w_888, V[] _rest880) => {
V h_889 = default;
if (_self878.IsNullish) _self878 = GlobalV;
h_889 = (_argc879 > 4 ? _rest880[0] : V.Undef);
Invoke(o_885, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, x_886, Add(y_887, ((V)((ToNum(h_889) * 0.18)))), w_888, ((V)(11D)), ((V)(2D))), ((V)("#b08a5e")), ((V)("#7d6248")), ((V)(1D))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, x_886, Add(y_887, ((V)((ToNum(h_889) * 0.55)))), w_888, ((V)(11D)), ((V)(2D))), ((V)("#a07a50")), ((V)("#7d6248")), ((V)(1D))), Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_886).S(" ").V(Add(y_887, h_889)).S("L").V(Add(x_886, ((V)(8D)))).S(" ").V(Add(Add(y_887, h_889), ((V)(6D)))).S("L").V(Add(x_886, w_888)).S(" ").V(Add(y_887, ((V)(6D)))).S("L").N((ToNum(Add(x_886, w_888)) - 8D)).S(" ").V(y_887).S("Z").End())), ((V)("#c09a6c")), ((V)("#7d6248")), ((V)(1D))));
Invoke(Arr(Arr(Add(x_886, ((V)(4D))), Add(Add(y_887, ((V)((ToNum(h_889) * 0.18)))), ((V)(5D)))), Arr(((V)((ToNum(Add(x_886, w_888)) - 4D))), Add(Add(y_887, ((V)((ToNum(h_889) * 0.18)))), ((V)(5D)))), Arr(Add(x_886, ((V)(4D))), Add(Add(y_887, ((V)((ToNum(h_889) * 0.55)))), ((V)(5D)))), Arr(((V)((ToNum(Add(x_886, w_888)) - 4D))), Add(Add(y_887, ((V)((ToNum(h_889) * 0.55)))), ((V)(5D))))), "forEach", Fn((V _arrowThis901, int _argc890, V _a892, V _a893, V _a894, V _a895, V[] _rest891) => {
V a_898 = default;
V b_900 = default;
{ V _t896 = ListOf(_a892);
{ V _t897 = GetIdx(_t896, 0D);
a_898 = _t897; }
{ V _t899 = GetIdx(_t896, 1D);
b_900 = _t899; }
}
return Invoke(o_885, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, a_898, b_900, ((V)(1.4))), ((V)("#5a5450"))));
}, 1, "", true));
Call(@lock_68, V.Undef, o_885, Add(x_886, ((V)((ToNum(w_888) / 2D)))), Add(y_887, ((V)((ToNum(h_889) * 0.42)))));
return default;
}, 5, "boards", false);
floor_71 = Fn((V _self902, int _argc903, V type_909, V k_910, V _a907, V _a908, V[] _rest904) => {
double H_911 = 0;
double sp0_912 = 0;
double sp1_913 = 0;
V xb_914 = default;
V quad_915 = default;
V RW_916 = default;
V RB_917 = default;
V RT_918 = default;
JsStrBuf lines_919 = null;
JsStrBuf dark_920 = null;
JsStrBuf light_921 = null;
V tiles_922 = default;
V vl_923 = default;
if (_self902.IsNullish) _self902 = GlobalV;
k_910 = (k_910 is var _t924 && Truthy(_t924) ? _t924 : ((V)(1D)));
H_911 = 100D;
sp0_912 = ((562D / 16.5) * ToNum(k_910));
sp1_913 = (sp0_912 * ToNum(Call(WY_24, V.Undef, ((V)(393D)))));
xb_914 = Fn((V _arrowThis933, int _argc925, V j_931, V y_932, V _a929, V _a930, V[] _rest926) => {
return ((V)((426D + (ToNum(j_931) * (sp0_912 + (((sp1_913 - sp0_912) * (ToNum(y_932) - H_911)) / 293D))))));
}, 2, "", true);
quad_915 = Fn((V _arrowThis944, int _argc934, V j_940, V a_941, V b_942, V step_943, V[] _rest935) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, j_940, a_941))).S(" ").V(a_941).S("L").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, Add(j_940, step_943), a_941))).S(" ").V(a_941).S("L").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, Add(j_940, step_943), b_942))).S(" ").V(b_942).S("L").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, j_940, b_942))).S(" ").V(b_942).S("Z").End()));
}, 4, "", true);
RW_916 = Call(rowsK_70, V.Undef, Arr(((V)(100D)), ((V)(114D)), ((V)(130D)), ((V)(149D)), ((V)(171D)), ((V)(197D)), ((V)(228D)), ((V)(265D)), ((V)(310D)), ((V)(393D))), k_910);
RB_917 = Call(rowsK_70, V.Undef, Arr(((V)(100D)), ((V)(122D)), ((V)(148D)), ((V)(180D)), ((V)(218D)), ((V)(264D)), ((V)(320D)), ((V)(393D))), k_910);
RT_918 = Call(rowsK_70, V.Undef, Arr(((V)(100D)), ((V)(113D)), ((V)(128D)), ((V)(145D)), ((V)(165D)), ((V)(188D)), ((V)(215D)), ((V)(246D)), ((V)(283D)), ((V)(330D)), ((V)(393D))), k_910);
lines_919 = new JsStrBuf("");
dark_920 = new JsStrBuf("");
light_921 = new JsStrBuf("");
tiles_922 = Arr();
vl_923 = Fn((V _arrowThis954, int _argc945, V a_951, V b_952, V st_953, V _a950, V[] _rest946) => {
{
V j_955 = default;
j_955 = a_951;
while (true) {
if (!(Le(j_955, b_952))) break;
lines_919.S("M").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, j_955, ((V)(H_911))))).S(" ").N(H_911).S("L").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, j_955, ((V)(393D))))).S(" 393");
j_955 = Add(j_955, st_953);
}
}
return default;
}, 3, "", true);
if ((SEqS(type_909, "wood") || SEqS(type_909, "boards"))) {
double st_957 = 0;
st_957 = (SEqS(type_909, "boards") ? 2D : 1D);
Call(vl_923, V.Undef, ((V)((-24D))), ((V)(24D)), ((V)(st_957)));
{
double r_958 = 0;
r_958 = 1D;
while (true) {
if (!((r_958 < (ToNum(Get(RW_916, "length")) - 1D)))) break;
{
double j_960 = 0;
j_960 = (-24D);
while (true) {
if (!((j_960 < 24D))) break;
if (((((((j_960 * 2D) + r_958) % 3D) + 3D) % 3D) == 0D)) {
lines_919.S("M").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)(j_960)), GetIdx(RW_916, r_958)))).S(" ").V(GetIdx(RW_916, r_958)).S("L").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)((j_960 + st_957))), GetIdx(RW_916, r_958)))).S(" ").V(GetIdx(RW_916, r_958));
}
j_960 = (j_960 + st_957);
}
}
r_958++;
}
}
{
double r_962 = 0;
r_962 = 0D;
while (true) {
if (!((r_962 < (ToNum(Get(RW_916, "length")) - 1D)))) break;
{
double j_964 = 0;
j_964 = (-24D);
while (true) {
if (!((j_964 < 24D))) break;
double m_966 = 0;
m_966 = (((((j_964 * 7D) + (r_962 * 3D)) % (SEqS(type_909, "boards") ? 9D : 5D)) + 9D) % (SEqS(type_909, "boards") ? 9D : 5D));
if ((m_966 == 0D)) {
dark_920.V((SEqS(type_909, "boards") ? Call(quad_915, V.Undef, ((V)((j_964 + 0.7))), GetIdx(RW_916, r_962), GetIdx(RW_916, (r_962 + 1D)), ((V)(0.6))) : Call(quad_915, V.Undef, ((V)(j_964)), GetIdx(RW_916, r_962), GetIdx(RW_916, (r_962 + 1D)), ((V)(1D)))));
} else {
if ((m_966 == 2D)) {
light_921.V(Call(quad_915, V.Undef, ((V)(j_964)), GetIdx(RW_916, r_962), GetIdx(RW_916, (r_962 + 1D)), ((V)(st_957))));
}
}
j_964 = (j_964 + st_957);
}
}
r_962++;
}
}
} else {
if ((SEqS(type_909, "checker") || SEqS(type_909, "dance"))) {
{
double r_967 = 0;
r_967 = 0D;
while (true) {
if (!((r_967 < (ToNum(Get(RB_917, "length")) - 1D)))) break;
{
double j_969 = 0;
j_969 = (-14D);
while (true) {
if (!((j_969 < 14D))) break;
V q_971 = default;
q_971 = Call(quad_915, V.Undef, ((V)(j_969)), GetIdx(RB_917, r_967), GetIdx(RB_917, (r_967 + 1D)), ((V)(2D)));
if (SEqS(type_909, "dance")) {
Invoke(tiles_922, "push", NewObj(3).Put("i", ((V)((j_969 / 2D)))).Put("r", ((V)(r_967))).Put("d", q_971).V);
} else {
if (((((((j_969 / 2D) + r_967) % 2D) + 2D) % 2D) == 0D)) {
dark_920.V(q_971);
}
}
j_969 = (j_969 + 2D);
}
}
r_967++;
}
}
if (SEqS(type_909, "dance")) {
Call(vl_923, V.Undef, ((V)((-14D))), ((V)(14D)), ((V)(2D)));
Invoke(RB_917, "forEach", Fn((V _arrowThis979, int _argc972, V y_978, V _a975, V _a976, V _a977, V[] _rest973) => {
return ((V)(lines_919.S("M0 ").V(y_978).S("H852").Str));
}, 1, "", true));
}
} else {
if (SEqS(type_909, "tile")) {
Call(vl_923, V.Undef, ((V)((-24D))), ((V)(24D)), ((V)(1D)));
Invoke(RT_918, "forEach", Fn((V _arrowThis987, int _argc980, V y_986, V _a983, V _a984, V _a985, V[] _rest981) => {
return ((V)(lines_919.S("M0 ").V(y_986).S("H852").Str));
}, 1, "", true));
{
double r_988 = 0;
r_988 = 0D;
while (true) {
if (!((r_988 < (ToNum(Get(RT_918, "length")) - 1D)))) break;
{
double j_990 = 0;
j_990 = (-24D);
while (true) {
if (!((j_990 < 24D))) break;
if (((((((j_990 * 3D) + (r_988 * 5D)) % 7D) + 7D) % 7D) == 0D)) {
light_921.V(Call(quad_915, V.Undef, ((V)(j_990)), GetIdx(RT_918, r_988), GetIdx(RT_918, (r_988 + 1D)), ((V)(1D))));
}
j_990++;
}
}
r_988++;
}
}
} else {
if (((SEqS(type_909, "lino") || SEqS(type_909, "marble")) || SEqS(type_909, "ballroom"))) {
V R_992 = default;
R_992 = Call(rowsK_70, V.Undef, Arr(((V)(100D)), ((V)(130D)), ((V)(170D)), ((V)(222D)), ((V)(290D)), ((V)(393D))), k_910);
Call(vl_923, V.Undef, ((V)((-15D))), ((V)(15D)), ((V)(3D)));
Invoke(R_992, "forEach", Fn((V _arrowThis1000, int _argc993, V y_999, V _a996, V _a997, V _a998, V[] _rest994) => {
return ((V)(lines_919.S("M0 ").V(y_999).S("H852").Str));
}, 1, "", true));
{
double r_1001 = 0;
r_1001 = 0D;
while (true) {
if (!((r_1001 < (ToNum(Get(R_992, "length")) - 1D)))) break;
{
double j_1003 = 0;
j_1003 = (-15D);
while (true) {
if (!((j_1003 < 15D))) break;
double odd_1005 = 0;
odd_1005 = (((((j_1003 / 3D) + r_1001) % 2D) + 2D) % 2D);
if (NumTruthy(odd_1005)) {
if (SEqS(type_909, "marble")) {
light_921.V(Call(quad_915, V.Undef, ((V)(j_1003)), GetIdx(R_992, r_1001), GetIdx(R_992, (r_1001 + 1D)), ((V)(3D))));
} else {
dark_920.V(Call(quad_915, V.Undef, ((V)(j_1003)), GetIdx(R_992, r_1001), GetIdx(R_992, (r_1001 + 1D)), ((V)(3D))));
}
}
j_1003 = (j_1003 + 3D);
}
}
r_1001++;
}
}
if (SEqS(type_909, "marble")) {
{
double n_1006 = 0;
n_1006 = 0D;
while (true) {
if (!((n_1006 < 9D))) break;
double y_1008 = 0;
double x_1009 = 0;
y_1008 = (112D + (n_1006 * 30D));
x_1009 = (140D + ((n_1006 * 211D) % 560D));
lines_919.S("M").N(x_1009).S(" ").N(y_1008).S("q30 8 50 -2t44 10");
n_1006++;
}
}
}
if (SEqS(type_909, "lino")) {
{
double n_1010 = 0;
n_1010 = 0D;
while (true) {
if (!((n_1010 < 6D))) break;
dark_920.V(Call(circ_13, V.Undef, ((V)((160D + ((n_1010 * 173D) % 540D)))), ((V)((150D + (n_1010 * 38D)))), ((V)((10D + ((n_1010 % 3D) * 5D))))));
n_1010++;
}
}
}
if (SEqS(type_909, "ballroom")) {
{
double n_1012 = 0;
n_1012 = 0D;
while (true) {
if (!((n_1012 < 40D))) break;
double y_1014 = 0;
double x_1015 = 0;
double s_1016 = 0;
y_1014 = (108D + ((n_1012 * 47D) % 280D));
x_1015 = (426D + ((((((n_1012 * 97D) % 160D) - 80D) * 9D) * ToNum(Call(WY_24, V.Undef, ((V)(y_1014))))) * 0.6));
s_1016 = (2D + (n_1012 % 3D));
light_921.S("M").V(Call(f1_12, V.Undef, ((V)(x_1015)))).S(" ").V(Call(f1_12, V.Undef, ((V)((y_1014 - (s_1016 * 2D)))))).S("L").V(Call(f1_12, V.Undef, ((V)((x_1015 + (s_1016 * 0.6)))))).S(" ").V(Call(f1_12, V.Undef, ((V)((y_1014 - (s_1016 * 0.6)))))).S("L").V(Call(f1_12, V.Undef, ((V)((x_1015 + (s_1016 * 2D)))))).S(" ").N(y_1014).S("L").V(Call(f1_12, V.Undef, ((V)((x_1015 + (s_1016 * 0.6)))))).S(" ").V(Call(f1_12, V.Undef, ((V)((y_1014 + (s_1016 * 0.6)))))).S("L").V(Call(f1_12, V.Undef, ((V)(x_1015)))).S(" ").V(Call(f1_12, V.Undef, ((V)((y_1014 + (s_1016 * 2D)))))).S("L").V(Call(f1_12, V.Undef, ((V)((x_1015 - (s_1016 * 0.6)))))).S(" ").V(Call(f1_12, V.Undef, ((V)((y_1014 + (s_1016 * 0.6)))))).S("L").V(Call(f1_12, V.Undef, ((V)((x_1015 - (s_1016 * 2D)))))).S(" ").N(y_1014).S("L").V(Call(f1_12, V.Undef, ((V)((x_1015 - (s_1016 * 0.6)))))).S(" ").V(Call(f1_12, V.Undef, ((V)((y_1014 - (s_1016 * 0.6)))))).S("Z");
n_1012++;
}
}
}
} else {
if (SEqS(type_909, "herring")) {
{
double r_1017 = 0;
r_1017 = 0D;
while (true) {
if (!((r_1017 < (ToNum(Get(RW_916, "length")) - 1D)))) break;
{
double j_1019 = 0;
j_1019 = (-24D);
while (true) {
if (!((j_1019 < 24D))) break;
V a_1021 = default;
V b_1022 = default;
a_1021 = GetIdx(RW_916, r_1017);
b_1022 = GetIdx(RW_916, (r_1017 + 1D));
lines_919.S((NumTruthy(((j_1019 + r_1017) % 2D)) ? JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)(j_1019)), a_1021))).S(" ").V(a_1021).S("L").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)((j_1019 + 1D))), b_1022))).S(" ").V(b_1022).End() : JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)((j_1019 + 1D))), a_1021))).S(" ").V(a_1021).S("L").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)(j_1019)), b_1022))).S(" ").V(b_1022).End()));
if (((((((j_1019 * 5D) + (r_1017 * 3D)) % 6D) + 6D) % 6D) == 0D)) {
dark_920.V(Call(quad_915, V.Undef, ((V)(j_1019)), a_1021, b_1022, ((V)(1D))));
}
j_1019++;
}
}
r_1017++;
}
}
Invoke(RW_916, "forEach", Fn((V _arrowThis1030, int _argc1023, V y_1029, V _a1026, V _a1027, V _a1028, V[] _rest1024) => {
return ((V)(lines_919.S("M0 ").V(y_1029).S("H852").Str));
}, 1, "", true));
} else {
if (SEqS(type_909, "wafer")) {
{
double j_1031 = 0;
j_1031 = (-40D);
while (true) {
if (!((j_1031 <= 40D))) break;
lines_919.S("M").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)(j_1031)), ((V)(H_911))))).S(" ").N(H_911).S("L").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)((j_1031 + 8D))), ((V)(393D))))).S(" 393M").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)(j_1031)), ((V)(H_911))))).S(" ").N(H_911).S("L").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)((j_1031 - 8D))), ((V)(393D))))).S(" 393");
j_1031 = (j_1031 + 2D);
}
}
{
double n_1033 = 0;
n_1033 = 0D;
while (true) {
if (!((n_1033 < 30D))) break;
light_921.V(Call(circ_13, V.Undef, ((V)((150D + ((n_1033 * 131D) % 560D)))), ((V)((112D + ((n_1033 * 59D) % 270D)))), ((V)(2.4))));
n_1033++;
}
}
} else {
if ((SEqS(type_909, "grass") || SEqS(type_909, "patchy"))) {
{
double j_1035 = 0;
j_1035 = (-14D);
while (true) {
if (!((j_1035 < 14D))) break;
if ((((((j_1035 / 2D) % 2D) + 2D) % 2D) == 0D)) {
light_921.V(Call(quad_915, V.Undef, ((V)(j_1035)), ((V)(H_911)), ((V)(393D)), ((V)(2D))));
}
j_1035 = (j_1035 + 2D);
}
}
{
double n_1037 = 0;
n_1037 = 0D;
while (true) {
if (!((n_1037 < 70D))) break;
double y_1039 = 0;
double x_1040 = 0;
double k_1041 = 0;
y_1039 = (110D + ((n_1037 * 53D) % 280D));
x_1040 = (426D + ((((((n_1037 * 97D) % 160D) - 80D) * 10D) * ToNum(Call(WY_24, V.Undef, ((V)(y_1039))))) * 0.6));
k_1041 = (ToNum(Call(WY_24, V.Undef, ((V)(y_1039)))) * 3D);
lines_919.S("M").V(Call(f1_12, V.Undef, ((V)(x_1040)))).S(" ").N(y_1039).S("l").V(Call(f1_12, V.Undef, ((V)((-k_1041))))).S(" ").V(Call(f1_12, V.Undef, ((V)(((-k_1041) * 2D))))).S("M").V(Call(f1_12, V.Undef, ((V)((x_1040 + 3D))))).S(" ").N(y_1039).S("l").V(Call(f1_12, V.Undef, ((V)((k_1041 * 0.4))))).S(" ").V(Call(f1_12, V.Undef, ((V)(((-k_1041) * 2.4)))));
n_1037++;
}
}
if (SEqS(type_909, "patchy")) {
{
double n_1042 = 0;
n_1042 = 0D;
while (true) {
if (!((n_1042 < 9D))) break;
double y_1044 = 0;
double x_1045 = 0;
y_1044 = (140D + ((n_1042 * 71D) % 230D));
x_1045 = (120D + ((n_1042 * 197D) % 620D));
dark_920.V(Call(ell_14, V.Undef, ((V)(x_1045)), ((V)(y_1044)), ((V)((30D * ToNum(Call(WY_24, V.Undef, ((V)(y_1044))))))), ((V)((11D * ToNum(Call(WY_24, V.Undef, ((V)(y_1044)))))))));
n_1042++;
}
}
}
} else {
if (SEqS(type_909, "patio")) {
V R_1046 = default;
R_1046 = Call(rowsK_70, V.Undef, Arr(((V)(100D)), ((V)(126D)), ((V)(158D)), ((V)(198D)), ((V)(248D)), ((V)(312D)), ((V)(393D))), k_910);
Invoke(R_1046, "forEach", Fn((V _arrowThis1054, int _argc1047, V y_1053, V _a1050, V _a1051, V _a1052, V[] _rest1048) => {
return ((V)(lines_919.S("M0 ").V(y_1053).S("H852").Str));
}, 1, "", true));
{
double r_1055 = 0;
r_1055 = 0D;
while (true) {
if (!((r_1055 < (ToNum(Get(R_1046, "length")) - 1D)))) break;
{
double j_1057 = 0;
j_1057 = ((-18D) + ((r_1055 % 2D) * 1.5));
while (true) {
if (!((j_1057 < 18D))) break;
lines_919.S("M").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)(j_1057)), GetIdx(R_1046, r_1055)))).S(" ").V(GetIdx(R_1046, r_1055)).S("L").V(Call(f1_12, V.Undef, Call(xb_914, V.Undef, ((V)(j_1057)), GetIdx(R_1046, (r_1055 + 1D))))).S(" ").V(GetIdx(R_1046, (r_1055 + 1D)));
if (((((((Round(j_1057) * 3D) + r_1055) % 4D) + 4D) % 4D) == 0D)) {
light_921.V(Call(quad_915, V.Undef, ((V)(j_1057)), GetIdx(R_1046, r_1055), GetIdx(R_1046, (r_1055 + 1D)), ((V)(3D))));
}
j_1057 = (j_1057 + 3D);
}
}
r_1055++;
}
}
} else {
if (SEqS(type_909, "cloud")) {
{
double n_1059 = 0;
n_1059 = 0D;
while (true) {
if (!((n_1059 < 26D))) break;
double y_1061 = 0;
double x_1062 = 0;
V s_1063 = default;
y_1061 = (120D + ((n_1059 * 53D) % 260D));
x_1062 = (120D + ((n_1059 * 211D) % 620D));
s_1063 = Call(WY_24, V.Undef, ((V)(y_1061)));
light_921.V(Add(Call(ell_14, V.Undef, ((V)(x_1062)), ((V)(y_1061)), ((V)((34D * ToNum(s_1063)))), ((V)((12D * ToNum(s_1063))))), Call(ell_14, V.Undef, ((V)((x_1062 + (24D * ToNum(s_1063))))), ((V)((y_1061 - (6D * ToNum(s_1063))))), ((V)((20D * ToNum(s_1063)))), ((V)((10D * ToNum(s_1063)))))));
n_1059++;
}
}
}
}
}
}
}
}
}
}
}
return NewObj(4).Put("lines", ((V)(lines_919.Str))).Put("dark", ((V)(dark_920.Str))).Put("light", ((V)(light_921.Str))).Put("tiles", tiles_922).V;
return default;
}, 2, "floor", false);
shell_73 = Fn((V _self1064, int _argc1065, V rk_1071, V sf_1072, V lockOf_1073, V _a1070, V[] _rest1066) => {
V R_1074 = default;
V locks_1075 = default;
V kf_1076 = default;
V key_1077 = default;
V P_1078 = default;
V o_1079 = default;
V T_1080 = default;
V @out_1081 = default;
V junk_1082 = default;
V dark_1083 = default;
V Rr_1084 = default;
V doors_1085 = default;
V top_1086 = default;
V fs_1087 = default;
V fl_1088 = default;
if (_self1064.IsNullish) _self1064 = GlobalV;
R_1074 = GetK(ROOMS_31, rk_1071);
sf_1072 = (sf_1072 is var _t1089 && Truthy(_t1089) ? _t1089 : NewObj(0).V);
locks_1075 = Invoke(Get(R_1074, "doors"), "map", Fn((V _arrowThis1097, int _argc1090, V d_1096, V _a1093, V _a1094, V _a1095, V[] _rest1091) => {
return (Truthy(lockOf_1073) ? Call(lockOf_1073, V.Undef, Get(d_1096, "to")) : ((V)(0D)));
}, 1, "", true));
kf_1076 = ((Get(X_8, "BIG") is var _t1098 && !Truthy(_t1098) ? _t1098 : GetK(Get(X_8, "BIG"), rk_1071)) is var _t1099 && Truthy(_t1099) ? _t1099 : ((V)(1D)));
key_1077 = ((V)(JsStrBuf.Begin().V(rk_1071).S("|").V(Invoke(Invoke(Call(slotsOf_35, V.Undef, rk_1071), "map", Fn((V _arrowThis1107, int _argc1100, V s_1106, V _a1103, V _a1104, V _a1105, V[] _rest1101) => {
return (GetK(sf_1072, s_1106) is var _t1108 && Truthy(_t1108) ? _t1108 : GetK(DEF_28, s_1106));
}, 1, "", true)), "join", ((V)(",")))).S("|").V(Invoke(locks_1075, "join", ((V)(",")))).S("|").V(kf_1076).S("|").V((!Get(sf_1072, "lx").IsNullish ? Get(sf_1072, "lx") : ((V)("")))).S("|").V((Get(sf_1072, "lz") is var _t1109 && Truthy(_t1109) ? _t1109 : ((V)(1D)))).S("|").S((Truthy((GetK(SPEC_27, Get(sf_1072, "win")) is var _t1110 && !Truthy(_t1110) ? _t1110 : Get(GetK(SPEC_27, Get(sf_1072, "win")), "ir"))) ? "ir" : "")).End()));
if (Truthy(GetK(SH_72, key_1077))) {
return GetK(SH_72, key_1077);
}
P_1078 = Call(palette_37, V.Undef, rk_1071, sf_1072);
o_1079 = Arr();
T_1080 = Arr();
@out_1081 = (!(!(Truthy(Get(R_1074, "out")))) ? V.True : V.False);
junk_1082 = ((((!(Truthy(@out_1081)) && SEqS(Get(Call(specOf_36, V.Undef, ((V)("wall")), Get(sf_1072, "wall")), "pat"), "peel")) && SEqS((Get(sf_1072, "trim") is var _t1111 && Truthy(_t1111) ? _t1111 : Get(DEF_28, "trim")), "t_scuff")) && SEqS((Get(sf_1072, "floor") is var _t1112 && Truthy(_t1112) ? _t1112 : Get(DEF_28, "floor")), "f_boards")) ? V.True : V.False);
dark_1083 = ((((!(Truthy(@out_1081)) && LtN(Call(lum_26, V.Undef, Get(P_1078, "b0")), 0.4)) && SEqS(rk_1071, "dance")) || ((!(Truthy(@out_1081)) && SEqS(Get(Call(specOf_36, V.Undef, ((V)("floor")), Get(sf_1072, "floor")), "ft"), "dance")) && LtN(Call(lum_26, V.Undef, Get(P_1078, "b0")), 0.5))) ? V.True : V.False);
Rr_1084 = NewObj(1).Put("dark", dark_1083).V;
if (Truthy(@out_1081)) {
Call(fence_45, V.Undef, o_1079, Call(specOf_36, V.Undef, ((V)("fence")), Get(sf_1072, "fence")));
} else {
if (Truthy(junk_1082)) {
Call(rust_43, V.Undef, o_1079, P_1078);
}
}
Invoke((Get(R_1074, "fixed") is var _t1121 && Truthy(_t1121) ? _t1121 : Arr()), "forEach", Fn((V _arrowThis1120, int _argc1113, V a_1119, V _a1116, V _a1117, V _a1118, V[] _rest1114) => {
return Call(@fixed_44, V.Undef, GetIdx(a_1119, 0D), a_1119, P_1078, o_1079, T_1080);
}, 1, "", true));
if (!(Truthy(@out_1081))) {
if (!Get(R_1074, "winX").IsNullish) {
Call(window__40, V.Undef, o_1079, Get(R_1074, "winX"), Call(specOf_36, V.Undef, ((V)("win")), Get(sf_1072, "win")));
}
if (!Get(R_1074, "artX").IsNullish) {
Call(art_42, V.Undef, o_1079, Get(R_1074, "artX"), Call(specOf_36, V.Undef, ((V)("art")), Get(sf_1072, "art")), T_1080);
}
}
doors_1085 = Arr();
top_1086 = Arr();
if (Truthy(@out_1081)) {
Call(ylights_47, V.Undef, top_1086, Call(specOf_36, V.Undef, ((V)("ylight")), Get(sf_1072, "ylight")));
} else {
V LX_1122 = default;
V LS_1123 = default;
V lz_1124 = default;
V n0_1125 = default;
LX_1122 = ((!Get(R_1074, "lightX").IsNullish && !Get(sf_1072, "lx").IsNullish) ? ((V)(ToNum(Get(sf_1072, "lx")))) : Get(R_1074, "lightX"));
LS_1123 = Call(specOf_36, V.Undef, ((V)("light")), Get(sf_1072, "light"));
lz_1124 = (((V)(ToNum(Get(sf_1072, "lz")))) is var _t1126 && Truthy(_t1126) ? _t1126 : ((V)(1D)));
if ((!LX_1122.IsNullish && !SEqS(Get(LS_1123, "k"), "none"))) {
Invoke(top_1086, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(LX_1122).S(" -72V4").End())), ((V)("none")), ((V)("#7a6a58")), ((V)(1.6))));
}
n0_1125 = Get(top_1086, "length");
Call(light_41, V.Undef, top_1086, LX_1122, LS_1123);
if ((!SEqN(lz_1124, 1D) && !LX_1122.IsNullish)) {
{
V i_1127 = default;
i_1127 = n0_1125;
while (true) {
if (!(Lt(i_1127, Get(top_1086, "length")))) break;
Set(GetK(top_1086, i_1127), "tf", ((V)(JsStrBuf.Begin().S("matrix(").V(lz_1124).S(" 0 0 ").V(lz_1124).S(" ").V(Call(f1_12, V.Undef, ((V)((ToNum(LX_1122) * (1D - ToNum(lz_1124))))))).S(" 0)").End())));
PostInc(ref i_1127, 1D);
}
}
}
}
fs_1087 = (Truthy(@out_1081) ? Call(specOf_36, V.Undef, ((V)("ground")), Get(sf_1072, "ground")) : Call(specOf_36, V.Undef, ((V)("floor")), Get(sf_1072, "floor")));
fl_1088 = Call(floor_71, V.Undef, Get(fs_1087, "ft"), kf_1076);
SetK(SH_72, key_1077, NewObj(12).Put("P", P_1078).Put("decor", Invoke(Invoke(o_1079, "concat", top_1086), "map", Fn((V _arrowThis1136, int _argc1129, V p_1135, V _a1132, V _a1133, V _a1134, V[] _rest1130) => {
return (Get(p_1135, "tf").IsNullish ? Object_assign(p_1135, NewObj(1).Put("tf", ((V)(""))).V) : p_1135);
}, 1, "", true))).Put("texts", T_1080).Put("doors", doors_1085).Put("floor", fl_1088).Put("fop", Get(fs_1087, "op")).Put("wall", (Truthy(@out_1081) ? ((V)("siding")) : Get(Call(specOf_36, V.Undef, ((V)("wall")), Get(sf_1072, "wall")), "pat"))).Put("out", @out_1081).Put("dark", dark_1083).Put("rusty", junk_1082).Put("name", Get(R_1074, "name")).Put("light", (Truthy(@out_1081) ? V.Null : Get(Call(specOf_36, V.Undef, ((V)("light")), Get(sf_1072, "light")), "k"))).V);
return GetK(SH_72, key_1077);
return default;
}, 3, "shell", false);
swatch_75 = Fn((V _self1137, int _argc1138, V id_1144, V _a1141, V _a1142, V _a1143, V[] _rest1139) => {
V M_1145 = default;
V S_1146 = default;
V o_1147 = default;
V T_1148 = default;
V sl_1149 = default;
if (_self1137.IsNullish) _self1137 = GlobalV;
M_1145 = GetK(Get(X_8, "SURF"), id_1144);
S_1146 = GetK(SPEC_27, id_1144);
if ((!(Truthy(M_1145)) || !(Truthy(S_1146)))) {
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", Arr()).V;
}
o_1147 = Arr();
T_1148 = Arr();
sl_1149 = Get(M_1145, "arch");
if (SEqS(sl_1149, "wall")) {
Invoke(o_1147, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(56D)), ((V)(6D))), Get(S_1146, "b0")));
Invoke(Call((GetK(MOTIF_74, Get(S_1146, "pat")) is var _t1165 && Truthy(_t1165) ? _t1165 : Fn((V _arrowThis1164, int _argc1158, V _a1160, V _a1161, V _a1162, V _a1163, V[] _rest1159) => {
return Arr();
}, 0, "", true)), V.Undef, Get(S_1146, "pc")), "forEach", Fn((V _arrowThis1157, int _argc1150, V p_1156, V _a1153, V _a1154, V _a1155, V[] _rest1151) => {
return Invoke(o_1147, "push", p_1156);
}, 1, "", true));
Invoke(o_1147, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(80D)), ((V)(16D)), ((V)(0D))), ((V)("#d8cbb4")), ((V)(0D)), ((V)(0D)), ((V)(0D))));
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_1147).V;
}
if (SEqS(sl_1149, "trim")) {
Invoke(o_1147, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(56D)), ((V)(6D))), ((V)("#efe6d6"))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(80D)), ((V)(30D)), ((V)(0D))), Get(S_1146, "w0")), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(80D)), ((V)(4D)), ((V)(0D))), Get(S_1146, "trim")));
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_1147).V;
}
if ((SEqS(sl_1149, "floor") || SEqS(sl_1149, "ground"))) {
V P_1166 = default;
V L_1167 = default;
P_1166 = NewObj(1).Put("f1", Get(S_1146, "f1")).V;
Invoke(o_1147, "push", Call(pd_20, V.Undef, ((V)("M14 0H66L80 56H0Z")), Get(S_1146, "f1")));
L_1167 = (GetK(NewObj(14).Put("wood", ((V)("M22 0L14 56M34 0L30 56M46 0L50 56M58 0L66 56"))).Put("boards", ((V)("M28 0L22 56M52 0L58 56"))).Put("checker", ((V)(""))).Put("dance", ((V)(""))).Put("tile", ((V)("M28 0L24 56M40 0V56M52 0L56 56M0 28H80"))).Put("lino", ((V)("M40 0V56M0 26H80"))).Put("marble", ((V)("M40 0V56M0 26H80M10 40q14 -6 24 2"))).Put("herring", ((V)("M20 6l10 10l10 -10l10 10l10 -10M16 26l10 10l10 -10l10 10l10 -10M12 46l10 10l10 -10l10 10l10 -10"))).Put("wafer", ((V)("M14 0L40 56M40 0L66 56M66 0L40 56M40 0L14 56"))).Put("ballroom", ((V)(""))).Put("grass", ((V)("M20 30l-2 -5M24 30l1 -6M50 18l-2 -5M54 18l1 -6M40 46l-2 -5M44 46l1 -6"))).Put("patchy", ((V)("M20 30l-2 -5M24 30l1 -6M56 40l-2 -5"))).Put("patio", ((V)("M0 18H80M0 38H80M30 0V18M54 18V38M24 38V56"))).Put("cloud", ((V)(""))).V, Get(S_1146, "ft")) is var _t1168 && Truthy(_t1168) ? _t1168 : ((V)("")));
if ((SEqS(Get(S_1146, "ft"), "checker") || SEqS(Get(S_1146, "ft"), "dance"))) {
Invoke(Arr(Arr(((V)(14D)), ((V)(0D))), Arr(((V)(40D)), ((V)(14D))), Arr(((V)(14D)), ((V)(28D))), Arr(((V)(40D)), ((V)(42D))), Arr(((V)(66D)), ((V)(28D)))), "forEach", Fn((V _arrowThis1181, int _argc1169, V _a1171, V i_1175, V _a1173, V _a1174, V[] _rest1170) => {
V x_1178 = default;
V y_1180 = default;
{ V _t1176 = ListOf(_a1171);
{ V _t1177 = GetIdx(_t1176, 0D);
x_1178 = _t1177; }
{ V _t1179 = GetIdx(_t1176, 1D);
y_1180 = _t1179; }
}
return Invoke(o_1147, "push", Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((ToNum(x_1178) - 4D))), y_1180, ((V)(22D)), ((V)(14D)), ((V)(0D))), (SEqS(Get(S_1146, "ft"), "dance") ? GetK(Get(K_9, "NEON"), i_1175) : Get(S_1146, "fd")), ((V)(0D)), ((V)(0D)), ((V)((SEqS(Get(S_1146, "ft"), "dance") ? 0.9 : 0.85)))));
}, 2, "", true));
}
if (SEqS(Get(S_1146, "ft"), "ballroom")) {
Invoke(Arr(Arr(((V)(24D)), ((V)(14D))), Arr(((V)(52D)), ((V)(30D))), Arr(((V)(34D)), ((V)(44D))), Arr(((V)(62D)), ((V)(12D)))), "forEach", Fn((V _arrowThis1193, int _argc1182, V _a1184, V _a1185, V _a1186, V _a1187, V[] _rest1183) => {
V x_1190 = default;
V y_1192 = default;
{ V _t1188 = ListOf(_a1184);
{ V _t1189 = GetIdx(_t1188, 0D);
x_1190 = _t1189; }
{ V _t1191 = GetIdx(_t1188, 1D);
y_1192 = _t1191; }
}
return Invoke(o_1147, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_1190, y_1192, ((V)(2.4))), Get(S_1146, "fli")));
}, 1, "", true));
}
if (SEqS(Get(S_1146, "ft"), "patchy")) {
Invoke(o_1147, "push", Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)(50D)), ((V)(36D)), ((V)(14D)), ((V)(6D))), Get(S_1146, "fd"), ((V)(0D)), ((V)(0D)), ((V)(0.8))));
}
if (SEqS(Get(S_1146, "ft"), "cloud")) {
Invoke(o_1147, "push", Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)(30D)), ((V)(22D)), ((V)(14D)), ((V)(6D))), WH_16), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)(52D)), ((V)(40D)), ((V)(16D)), ((V)(6D))), WH_16));
}
if (Truthy(L_1167)) {
Invoke(o_1147, "push", Call(pd_20, V.Undef, L_1167, ((V)("none")), Get(S_1146, "fl"), ((V)(1.4))));
}
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_1147).V;
}
if (SEqS(sl_1149, "win")) {
Call(window__40, V.Undef, o_1147, ((V)(0D)), S_1146);
return NewObj(2).Put("vb", ((V)("-56 -12 112 92"))).Put("polys", o_1147).V;
}
if (SEqS(sl_1149, "light")) {
if (SEqS(Get(S_1146, "k"), "none")) {
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", Arr()).V;
}
Call(light_41, V.Undef, o_1147, ((V)(0D)), S_1146, ((V)(1D)));
return NewObj(2).Put("vb", ((V)(((SEqS(Get(S_1146, "k"), "laser") || SEqS(Get(S_1146, "k"), "truss")) ? "-50 -4 100 70" : "-46 -4 92 64")))).Put("polys", o_1147).V;
}
if (SEqS(sl_1149, "art")) {
Call(art_42, V.Undef, o_1147, ((V)(0D)), S_1146, T_1148);
return NewObj(2).Put("vb", ((V)("-40 6 80 62"))).Put("polys", o_1147).V;
}
if (SEqS(sl_1149, "door")) {
V P_1194 = default;
P_1194 = NewObj(3).Put("door", Get(S_1146, "c")).Put("doorL", Get(S_1146, "cl")).Put("trim", CR_15).V;
Call(door_54, V.Undef, NewObj(4).Put("s", ((V)("B"))).Put("x", ((V)(0D))).Put("to", ((V)("living"))).Put("k", ((V)("door"))).V, P_1194, o_1147, Arr(), NewObj(0).V, S_1146, ((V)(0D)), ((V)(1D)));
return NewObj(2).Put("vb", ((V)("-40 16 80 86"))).Put("polys", o_1147).V;
}
if (SEqS(sl_1149, "fence")) {
V c_1195 = default;
V d_1196 = default;
c_1195 = Get(S_1146, "c");
d_1196 = Call(shade_11, V.Undef, c_1195, ((V)(0.75)));
{
double i_1197 = 0;
i_1197 = 0D;
while (true) {
if (!((i_1197 < 5D))) break;
double x_1199 = 0;
double h_1200 = 0;
double tilt_1201 = 0;
x_1199 = (6D + (i_1197 * 15D));
h_1200 = (SEqS(Get(S_1146, "k"), "gold") ? 46D : (SEqS(Get(S_1146, "k"), "slat") ? 44D : 38D));
tilt_1201 = ((SEqS(Get(S_1146, "k"), "broken") && (i_1197 == 2D)) ? 8D : 0D);
if ((SEqS(Get(S_1146, "k"), "broken") && (i_1197 == 3D))) {
goto _cont1198;
}
Invoke(o_1147, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(x_1199).S(" 56V").N(((56D - h_1200) + tilt_1201)).S("L").N((x_1199 + 6D)).S(" ").N((((56D - h_1200) - (SEqS(Get(S_1146, "k"), "slat") ? 0D : 7D)) + tilt_1201)).S("L").N((x_1199 + 12D)).S(" ").N(((56D - h_1200) + tilt_1201)).S("V56Z").End())), c_1195, d_1196, ((V)(1.2))));
if (SEqS(Get(S_1146, "k"), "cane")) {
Invoke(o_1147, "push", Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N((x_1199 + 1D)).S(" 30l10 -4M").N((x_1199 + 1D)).S(" 42l10 -4").End())), ((V)("none")), ((V)("#e2554a")), ((V)(3D))));
}
if (SEqS(Get(S_1146, "k"), "gold")) {
Invoke(o_1147, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)((x_1199 + 6D))), ((V)(6D)), ((V)(3D))), ((V)("url(#hsGold)"))));
}
_cont1198: ;
i_1197++;
}
}
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_1147).V;
}
if ((SEqS(sl_1149, "ylight") && !SEqS(Get(S_1146, "k"), "string"))) {
if (SEqS(Get(S_1146, "k"), "none")) {
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", Arr()).V;
}
Call(ylights_47, V.Undef, o_1147, S_1146);
return NewObj(2).Put("vb", ((V)((SEqS(Get(S_1146, "k"), "torch") ? "0 40 200 140" : "230 -4 300 110")))).Put("polys", o_1147).V;
}
if (SEqS(sl_1149, "ylight")) {
if (SEqS(Get(S_1146, "k"), "none")) {
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", Arr()).V;
}
Invoke(o_1147, "push", Call(pd_20, V.Undef, ((V)("M0 10Q40 40 80 10")), ((V)("none")), ((V)("#5a4a40")), ((V)(1.6))));
Invoke(Arr(((V)("#ff9d4a")), ((V)("#ffd66b")), ((V)("#a6f06a")), ((V)("#6ac8ff")), ((V)("#8f7bff"))), "forEach", Fn((V _arrowThis1210, int _argc1202, V c_1208, V i_1209, V _a1206, V _a1207, V[] _rest1203) => {
double t_1211 = 0;
double x_1212 = 0;
double y_1213 = 0;
t_1211 = (ToNum(Add(i_1209, ((V)(0.5)))) / 5D);
x_1212 = (t_1211 * 80D);
y_1213 = ((10D + ((((30D * 4D) * t_1211) * (1D - t_1211)) * 0.5)) + 6D);
Invoke(o_1147, "push", Call(pd_20, V.Undef, Call(circ_13, V.Undef, ((V)(x_1212)), ((V)(y_1213)), ((V)(8D))), c_1208, ((V)(0D)), ((V)(0D)), ((V)(0.3))), Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)(x_1212)), ((V)(y_1213)), ((V)(4D)), ((V)(5.5))), c_1208));
return default;
}, 2, "", true));
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", o_1147).V;
}
return NewObj(2).Put("vb", ((V)("0 0 80 56"))).Put("polys", Arr()).V;
return default;
}, 1, "swatch", false);
X_8 = Get(G("window"), "House3D");
if (!(Truthy(((X_8 is var _t1214 && !Truthy(_t1214) ? _t1214 : Get(X_8, "K")) is var _t1215 && !Truthy(_t1215) ? _t1215 : Get(X_8, "CAT"))))) {
Call(G("setTimeout"), V.Undef, boot_1216.v, ((V)(20D)));
return default;
}
if (Truthy(Get(X_8, "SPEC"))) {
return default;
}
K_9 = Get(X_8, "K");
{ V _t1217 = K_9;
if (_t1217.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1217));
{ V _t1218 = Get(_t1217, "mix");
mix_10 = _t1218; }
{ V _t1219 = Get(_t1217, "shade");
shade_11 = _t1219; }
{ V _t1220 = Get(_t1217, "f1");
f1_12 = _t1220; }
{ V _t1221 = Get(_t1217, "circ");
circ_13 = _t1221; }
{ V _t1222 = Get(_t1217, "ell");
ell_14 = _t1222; } }
CR_15 = ((V)("#fffaf1"));
WH_16 = ((V)("#ffffff"));
GOLD_17 = ((V)("#e2b14a"));
VW_18 = 852D;
FY0_19 = Get(X_8, "FY0");
pd_20 = Fn((V _arrowThis1234, int _argc1223, V d_1229, V f_1230, V s_1231, V w_1232, V[] _rest1224) => {
V o_1233 = default;
o_1233 = (_argc1223 > 4 ? _rest1224[0] : V.Undef);
return NewObj(5).Put("d", d_1229).Put("f", f_1230).Put("s", (s_1231 is var _t1235 && Truthy(_t1235) ? _t1235 : ((V)("none")))).Put("w", (w_1232 is var _t1236 && Truthy(_t1236) ? _t1236 : ((V)(0D)))).Put("o", (o_1233.IsNullish ? ((V)(1D)) : o_1233)).V;
}, 5, "", true);
rr_21 = Fn((V _arrowThis1248, int _argc1237, V x_1243, V y_1244, V w_1245, V h_1246, V[] _rest1238) => {
V r_1247 = default;
r_1247 = (_argc1237 > 4 ? _rest1238[0] : V.Undef);
r_1247 = ((V)(Min(ToNum(r_1247), (ToNum(w_1245) / 2D), (ToNum(h_1246) / 2D))));
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_12, V.Undef, Add(x_1243, r_1247))).S(" ").V(Call(f1_12, V.Undef, y_1244)).S("H").V(Call(f1_12, V.Undef, ((V)((ToNum(Add(x_1243, w_1245)) - ToNum(r_1247)))))).S("A").V(r_1247).S(" ").V(r_1247).S(" 0 0 1 ").V(Call(f1_12, V.Undef, Add(x_1243, w_1245))).S(" ").V(Call(f1_12, V.Undef, Add(y_1244, r_1247))).S("V").V(Call(f1_12, V.Undef, ((V)((ToNum(Add(y_1244, h_1246)) - ToNum(r_1247)))))).S("A").V(r_1247).S(" ").V(r_1247).S(" 0 0 1 ").V(Call(f1_12, V.Undef, ((V)((ToNum(Add(x_1243, w_1245)) - ToNum(r_1247)))))).S(" ").V(Call(f1_12, V.Undef, Add(y_1244, h_1246))).S("H").V(Call(f1_12, V.Undef, Add(x_1243, r_1247))).S("A").V(r_1247).S(" ").V(r_1247).S(" 0 0 1 ").V(Call(f1_12, V.Undef, x_1243)).S(" ").V(Call(f1_12, V.Undef, ((V)((ToNum(Add(y_1244, h_1246)) - ToNum(r_1247)))))).S("V").V(Call(f1_12, V.Undef, Add(y_1244, r_1247))).S("A").V(r_1247).S(" ").V(r_1247).S(" 0 0 1 ").V(Call(f1_12, V.Undef, Add(x_1243, r_1247))).S(" ").V(Call(f1_12, V.Undef, y_1244)).S("Z").End()));
return default;
}, 5, "", true);
BL_22 = 100D;
BR_23 = 752D;
WY_24 = Fn((V _arrowThis1256, int _argc1249, V y_1255, V _a1252, V _a1253, V _a1254, V[] _rest1250) => {
return ((V)(((652D + (1.235 * (ToNum(y_1255) - 100D))) / 652D)));
}, 1, "", true);
sideB_25 = Fn((V _arrowThis1265, int _argc1257, V s_1263, V t_1264, V _a1261, V _a1262, V[] _rest1258) => {
return (SEqS(s_1263, "L") ? Arr(((V)((BL_22 - (BL_22 * ToNum(t_1264))))), ((V)((100D + (162D * ToNum(t_1264)))))) : Arr(((V)((BR_23 + ((852D - BR_23) * ToNum(t_1264))))), ((V)((100D + (162D * ToNum(t_1264)))))));
}, 2, "", true);
lum_26 = Fn((V _arrowThis1273, int _argc1266, V h_1272, V _a1269, V _a1270, V _a1271, V[] _rest1267) => {
double c_1274 = 0;
c_1274 = ParseInt(Invoke(h_1272, "slice", ((V)(1D))), ((V)(16D)));
return ((V)(((((((double)(ToInt32(((double)(ToInt32(c_1274) >> (int)(ToUint32(16D) & 31)))) & ToInt32(255D))) * 0.3) + (((double)(ToInt32(((double)(ToInt32(c_1274) >> (int)(ToUint32(8D) & 31)))) & ToInt32(255D))) * 0.59)) + (((double)(ToInt32(c_1274) & ToInt32(255D))) * 0.11)) / 255D)));
return default;
}, 1, "", true);
SPEC_27 = NewObj(70).Put("w_peel", NewObj(4).Put("pat", ((V)("peel"))).Put("b0", ((V)("#d9c9ae"))).Put("b1", ((V)("#e6d9c2"))).Put("pc", ((V)("#c2ab88"))).V).Put("w_plaster", NewObj(4).Put("pat", ((V)("plaster"))).Put("b0", ((V)("#e8dcc6"))).Put("b1", ((V)("#f1e8d6"))).Put("pc", ((V)("#d8c8aa"))).V).Put("w_daisy", NewObj(4).Put("pat", ((V)("daisy"))).Put("b0", ((V)("#f3ecd2"))).Put("b1", ((V)("#faf4e2"))).Put("pc", ((V)("#e8c860"))).V).Put("w_tile", NewObj(4).Put("pat", ((V)("tile"))).Put("b0", ((V)("#d7ecf3"))).Put("b1", ((V)("#e8f5f9"))).Put("pc", ((V)("#bcdbe6"))).V).Put("w_burst", NewObj(4).Put("pat", ((V)("burst"))).Put("b0", ((V)("#bfe8e0"))).Put("b1", ((V)("#d8f3ee"))).Put("pc", ((V)("#ffffff"))).V).Put("w_linen", NewObj(4).Put("pat", ((V)("linen"))).Put("b0", ((V)("#e6e3dc"))).Put("b1", ((V)("#efede8"))).Put("pc", ((V)("#d4d0c6"))).V).Put("w_candy", NewObj(4).Put("pat", ((V)("candy"))).Put("b0", ((V)("#e6ddff"))).Put("b1", ((V)("#f1ebff"))).Put("pc", ((V)("#fff4c0"))).V).Put("w_damask", NewObj(4).Put("pat", ((V)("damask"))).Put("b0", ((V)("#efe2c4"))).Put("b1", ((V)("#f6ebd3"))).Put("pc", ((V)("#d4ad5a"))).V).Put("f_boards", NewObj(8).Put("ft", ((V)("boards"))).Put("f0", ((V)("#a88a66"))).Put("f1", ((V)("#b89a74"))).Put("f2", ((V)("#c4a882"))).Put("fl", ((V)("#7d6248"))).Put("fd", ((V)("#5e4632"))).Put("fli", ((V)("#cbb08a"))).Put("op", Arr(((V)(0.55)), ((V)(0.18)), ((V)(0.7)))).V).Put("f_lino", NewObj(8).Put("ft", ((V)("lino"))).Put("f0", ((V)("#cfc6a8"))).Put("f1", ((V)("#ddd5ba"))).Put("f2", ((V)("#e8e1ca"))).Put("fl", ((V)("#b5aa8a"))).Put("fd", ((V)("#c2b896"))).Put("fli", ((V)("#efe9d6"))).Put("op", Arr(((V)(0.4)), ((V)(0.4)), ((V)(0.5)))).V).Put("f_oak", NewObj(8).Put("ft", ((V)("wood"))).Put("f0", ((V)("#c98d52"))).Put("f1", ((V)("#e0a96e"))).Put("f2", ((V)("#f0c590"))).Put("fl", ((V)("#a86b36"))).Put("fd", ((V)("#b87a40"))).Put("fli", ((V)("#fff2d8"))).Put("op", Arr(((V)(0.22)), ((V)(0.18)), ((V)(0.42)))).V).Put("f_check", NewObj(8).Put("ft", ((V)("checker"))).Put("f0", ((V)("#f3efe6"))).Put("f1", ((V)("#f8f5ee"))).Put("f2", ((V)("#ffffff"))).Put("fl", ((V)("#d8d0c0"))).Put("fd", ((V)("#3d4048"))).Put("fli", ((V)("#ffffff"))).Put("op", Arr(((V)(0.8)), ((V)(0D)), ((V)(0.2)))).V).Put("f_lightup", NewObj(8).Put("ft", ((V)("dance"))).Put("f0", ((V)("#1c1f4d"))).Put("f1", ((V)("#22265a"))).Put("f2", ((V)("#292e68"))).Put("fl", ((V)("#3d4596"))).Put("fd", ((V)("#2a2e66"))).Put("fli", ((V)("#2a2e66"))).Put("op", Arr(((V)(0D)), ((V)(0D)), ((V)(0.6)))).V).Put("f_herring", NewObj(8).Put("ft", ((V)("herring"))).Put("f0", ((V)("#d6b98e"))).Put("f1", ((V)("#e2c79e"))).Put("f2", ((V)("#ecd5b0"))).Put("fl", ((V)("#b8956a"))).Put("fd", ((V)("#c9a87c"))).Put("fli", ((V)("#f4e2c4"))).Put("op", Arr(((V)(0.3)), ((V)(0.3)), ((V)(0.55)))).V).Put("f_wafer", NewObj(8).Put("ft", ((V)("wafer"))).Put("f0", ((V)("#e8c88e"))).Put("f1", ((V)("#f0d6a2"))).Put("f2", ((V)("#f6e2b8"))).Put("fl", ((V)("#c9a466"))).Put("fd", ((V)("#ddb878"))).Put("fli", ((V)("#fbeecf"))).Put("op", Arr(((V)(0.3)), ((V)(0.3)), ((V)(0.7)))).V).Put("f_marble", NewObj(8).Put("ft", ((V)("marble"))).Put("f0", ((V)("#e8e4dc"))).Put("f1", ((V)("#f2efe8"))).Put("f2", ((V)("#faf8f3"))).Put("fl", ((V)("#cfc8bb"))).Put("fd", ((V)("#ddd6c8"))).Put("fli", ((V)("#ffffff"))).Put("op", Arr(((V)(0.3)), ((V)(0.5)), ((V)(0.6)))).V).Put("f_ballroom", NewObj(8).Put("ft", ((V)("ballroom"))).Put("f0", ((V)("#5e1a26"))).Put("f1", ((V)("#6e2230"))).Put("f2", ((V)("#7f2a3a"))).Put("fl", ((V)("#c9963f"))).Put("fd", ((V)("#521620"))).Put("fli", ((V)("#ffe2a0"))).Put("op", Arr(((V)(0.5)), ((V)(0.9)), ((V)(0.45)))).V).Put("g_patchy", NewObj(8).Put("ft", ((V)("patchy"))).Put("f0", ((V)("#a3b46a"))).Put("f1", ((V)("#b2c27a"))).Put("f2", ((V)("#bccb86"))).Put("fl", ((V)("#7d8c48"))).Put("fd", ((V)("#a88a5c"))).Put("fli", ((V)("#c8d696"))).Put("op", Arr(((V)(0.75)), ((V)(0.3)), ((V)(0.55)))).V).Put("g_clover", NewObj(8).Put("ft", ((V)("grass"))).Put("f0", ((V)("#7fbd5e"))).Put("f1", ((V)("#93cf70"))).Put("f2", ((V)("#a5dc84"))).Put("fl", ((V)("#6fae50"))).Put("fd", ((V)("#86c466"))).Put("fli", ((V)("#b2e494"))).Put("op", Arr(((V)(0D)), ((V)(0.22)), ((V)(0.5)))).V).Put("g_patio", NewObj(8).Put("ft", ((V)("patio"))).Put("f0", ((V)("#cfc8bb"))).Put("f1", ((V)("#dcd6ca"))).Put("f2", ((V)("#e6e1d6"))).Put("fl", ((V)("#aea594"))).Put("fd", ((V)("#c2baa8"))).Put("fli", ((V)("#efebe2"))).Put("op", Arr(((V)(0.3)), ((V)(0.3)), ((V)(0.7)))).V).Put("g_mint", NewObj(8).Put("ft", ((V)("grass"))).Put("f0", ((V)("#9fe0c4"))).Put("f1", ((V)("#b4ead2"))).Put("f2", ((V)("#c6f1de"))).Put("fl", ((V)("#7cc9a8"))).Put("fd", ((V)("#a0dcc0"))).Put("fli", ((V)("#fff4c0"))).Put("op", Arr(((V)(0D)), ((V)(0.3)), ((V)(0.5)))).V).Put("g_cloud", NewObj(8).Put("ft", ((V)("cloud"))).Put("f0", ((V)("#dfeefa"))).Put("f1", ((V)("#eaf4fc"))).Put("f2", ((V)("#f6fbff"))).Put("fl", ((V)("#bcd8ee"))).Put("fd", ((V)("#cfe4f4"))).Put("fli", ((V)("#ffffff"))).Put("op", Arr(((V)(0D)), ((V)(0.9)), ((V)(0.4)))).V).Put("t_scuff", NewObj(3).Put("w0", ((V)("#b9ab92"))).Put("w1", ((V)("#a99a80"))).Put("trim", ((V)("#d9cdb5"))).V).Put("t_ging", NewObj(3).Put("w0", ((V)("#e3946a"))).Put("w1", ((V)("#d4845a"))).Put("trim", ((V)("#fffaf1"))).V).Put("t_pastel", NewObj(3).Put("w0", ((V)("#bfe3d4"))).Put("w1", ((V)("#a3d3c0"))).Put("trim", ((V)("#fffaf1"))).V).Put("t_stripe", NewObj(3).Put("w0", ((V)("#e2554a"))).Put("w1", ((V)("#c9443a"))).Put("trim", ((V)("#fffaf1"))).V).Put("t_min", NewObj(3).Put("w0", ((V)("#3e4046"))).Put("w1", ((V)("#34363b"))).Put("trim", ((V)("#f1eee8"))).V).Put("t_frost", NewObj(3).Put("w0", ((V)("#fff1a0"))).Put("w1", ((V)("#f3e48a"))).Put("trim", ((V)("#ffffff"))).V).Put("t_gold", NewObj(3).Put("w0", ((V)("#7f2030"))).Put("w1", ((V)("#6a1a28"))).Put("trim", ((V)("#e2b14a"))).V).Put("win_crack", NewObj(2).Put("k", ((V)("crack"))).Put("fr", ((V)("#cbbfa6"))).V).Put("win_oil", NewObj(3).Put("k", ((V)("curt"))).Put("fr", ((V)("#e8dcc6"))).Put("cu", ((V)("#c9a85a"))).V).Put("win_lace", NewObj(3).Put("k", ((V)("lace"))).Put("fr", CR_15).Put("cu", WH_16).V).Put("win_flower", NewObj(3).Put("k", ((V)("flower"))).Put("fr", CR_15).Put("cu", ((V)("#e3946a"))).V).Put("win_port", NewObj(2).Put("k", ((V)("port"))).Put("fr", ((V)("#d5dde2"))).V).Put("win_big", NewObj(2).Put("k", ((V)("big"))).Put("fr", ((V)("#2c2d31"))).V).Put("win_bonbon", NewObj(2).Put("k", ((V)("bonbon"))).Put("fr", ((V)("#cdb8f5"))).V).Put("win_arch", NewObj(3).Put("k", ((V)("arch"))).Put("fr", GOLD_17).Put("cu", ((V)("#7a1e2c"))).V).Put("l_none", NewObj(1).Put("k", ((V)("none"))).V).Put("l_bulb", NewObj(1).Put("k", ((V)("bulb"))).V).Put("l_jar", NewObj(1).Put("k", ((V)("jar"))).V).Put("l_wicker", NewObj(1).Put("k", ((V)("wicker"))).V).Put("l_neon", NewObj(1).Put("k", ((V)("neon"))).V).Put("l_disco", NewObj(1).Put("k", ((V)("disco"))).V).Put("l_globe", NewObj(1).Put("k", ((V)("globe"))).V).Put("l_sprinkle", NewObj(1).Put("k", ((V)("sprinkle"))).V).Put("l_chand", NewObj(1).Put("k", ((V)("chand"))).V).Put("a_none", NewObj(1).Put("k", ((V)("none"))).V).Put("a_cards", NewObj(1).Put("k", ((V)("cards"))).V).Put("a_map", NewObj(1).Put("k", ((V)("map"))).V).Put("a_flowers", NewObj(1).Put("k", ((V)("flowers"))).V).Put("a_clock", NewObj(1).Put("k", ((V)("clock"))).V).Put("a_records", NewObj(1).Put("k", ((V)("records"))).V).Put("a_canvas", NewObj(1).Put("k", ((V)("canvas"))).V).Put("a_rainbow", NewObj(1).Put("k", ((V)("rainbow"))).V).Put("a_portrait", NewObj(1).Put("k", ((V)("portrait"))).V).Put("d_scuff", NewObj(3).Put("k", ((V)("scuff"))).Put("c", ((V)("#a89478"))).Put("cl", ((V)("#bfae90"))).V).Put("d_plank", NewObj(3).Put("k", ((V)("plank"))).Put("c", ((V)("#b08a5e"))).Put("cl", ((V)("#c9a576"))).V).Put("d_arch", NewObj(3).Put("k", ((V)("arch"))).Put("c", ((V)("#9ab886"))).Put("cl", ((V)("#c4d8b2"))).V).Put("d_jet", NewObj(3).Put("k", ((V)("jet"))).Put("c", ((V)("#5cc8c0"))).Put("cl", ((V)("#bfeee8"))).V).Put("d_flush", NewObj(3).Put("k", ((V)("flush"))).Put("c", ((V)("#e9e5dc"))).Put("cl", ((V)("#f6f4ef"))).V).Put("d_ginger", NewObj(3).Put("k", ((V)("ginger"))).Put("c", ((V)("#c98d52"))).Put("cl", ((V)("#fffaf1"))).V).Put("d_palace", NewObj(3).Put("k", ((V)("palace"))).Put("c", ((V)("#f3ead6"))).Put("cl", ((V)("#e2b14a"))).V).Put("y_broken", NewObj(2).Put("k", ((V)("broken"))).Put("c", ((V)("#c9b896"))).V).Put("y_picket", NewObj(2).Put("k", ((V)("picket"))).Put("c", CR_15).V).Put("y_slat", NewObj(2).Put("k", ((V)("slat"))).Put("c", ((V)("#9a7550"))).V).Put("y_cane", NewObj(2).Put("k", ((V)("cane"))).Put("c", WH_16).V).Put("y_gold", NewObj(2).Put("k", ((V)("gold"))).Put("c", GOLD_17).V).Put("y_hedge", NewObj(2).Put("k", ((V)("hedge"))).Put("c", CR_15).V).Put("yl_none", NewObj(1).Put("k", ((V)("none"))).V).Put("yl_tiki", NewObj(1).Put("k", ((V)("string"))).V).V;
DEF_28 = NewObj(10).Put("wall", ((V)("w_peel"))).Put("floor", ((V)("f_boards"))).Put("trim", ((V)("t_scuff"))).Put("win", ((V)("win_crack"))).Put("light", ((V)("l_bulb"))).Put("art", ((V)("a_none"))).Put("door", ((V)("d_scuff"))).Put("fence", ((V)("y_broken"))).Put("ground", ((V)("g_patchy"))).Put("ylight", ((V)("yl_none"))).V;
SLOTS_IN_29 = Arr(((V)("wall")), ((V)("floor")), ((V)("trim")), ((V)("win")), ((V)("light")), ((V)("art")));
SLOTS_OUT_30 = Arr(((V)("fence")), ((V)("ground")), ((V)("ylight")));
ROOMS_31 = NewObj(7).Put("living", NewObj(7).Put("name", ((V)("Living Room"))).Put("unlock", ((V)(1D))).Put("doors", Arr(NewObj(2).Put("s", ((V)("L"))).Put("to", ((V)("kitchen"))).V, NewObj(2).Put("s", ((V)("R"))).Put("to", ((V)("bathroom"))).V, NewObj(4).Put("s", ((V)("B"))).Put("x", ((V)(620D))).Put("to", ((V)("dance"))).Put("k", ((V)("up"))).V)).Put("winX", ((V)(270D))).Put("artX", ((V)(470D))).Put("lightX", ((V)(380D))).Put("start", Arr(Arr(((V)("saggySofa")), ((V)(426D)), ((V)(168D))), Arr(((V)("crateTable")), ((V)(426D)), ((V)(238D))), Arr(((V)("boxTV")), ((V)(232D)), ((V)(156D))))).V).Put("kitchen", NewObj(7).Put("name", ((V)("Kitchen"))).Put("unlock", ((V)(2D))).Put("doors", Arr(NewObj(2).Put("s", ((V)("R"))).Put("to", ((V)("living"))).V, NewObj(4).Put("s", ((V)("B"))).Put("x", ((V)(430D))).Put("to", ((V)("backyard"))).Put("k", ((V)("glass"))).V, NewObj(4).Put("s", ((V)("B"))).Put("x", ((V)(612D))).Put("to", ((V)("bedroom"))).Put("k", ((V)("up"))).V)).Put("winX", ((V)(262D))).Put("artX", ((V)(521D))).Put("lightX", ((V)(340D))).Put("start", Arr(Arr(((V)("icebox")), ((V)(176D)), ((V)(150D))), Arr(((V)("wobblyCounter")), ((V)(292D)), ((V)(150D))), Arr(((V)("rustyStove")), ((V)(520D)), ((V)(152D))), Arr(((V)("crateStool")), ((V)(440D)), ((V)(256D))))).V).Put("bathroom", NewObj(9).Put("name", ((V)("Bathroom"))).Put("unlock", ((V)(4D))).Put("doors", Arr(NewObj(2).Put("s", ((V)("L"))).Put("to", ((V)("living"))).V, NewObj(4).Put("s", ((V)("B"))).Put("x", ((V)(640D))).Put("to", ((V)("backyard"))).Put("k", ((V)("door"))).V)).Put("winX", ((V)(290D))).Put("artX", ((V)(412D))).Put("lightX", ((V)(470D))).Put("fixed", Arr(Arr(((V)("mirror")), ((V)(520D))))).Put("start", Arr(Arr(((V)("washtub")), ((V)(300D)), ((V)(176D))), Arr(((V)("chipBasin")), ((V)(520D)), ((V)(152D))), Arr(((V)("oldBasket")), ((V)(690D)), ((V)(250D))))).Put("toys", Arr(Arr(((V)("duck")), ((V)(560D)), ((V)(302D))))).V).Put("bedroom", NewObj(7).Put("name", ((V)("Bedroom"))).Put("unlock", ((V)(6D))).Put("doors", Arr(NewObj(2).Put("s", ((V)("R"))).Put("to", ((V)("dance"))).V, NewObj(4).Put("s", ((V)("B"))).Put("x", ((V)(620D))).Put("to", ((V)("kitchen"))).Put("k", ((V)("down"))).V)).Put("winX", ((V)(330D))).Put("artX", ((V)(474D))).Put("lightX", ((V)(410D))).Put("start", Arr(Arr(((V)("oldMattress")), ((V)(330D)), ((V)(198D))), Arr(((V)("crateStand")), ((V)(432D)), ((V)(150D))), Arr(((V)("rickWard")), ((V)(192D)), ((V)(154D))))).V).Put("backyard", NewObj(7).Put("name", ((V)("Backyard"))).Put("unlock", ((V)(8D))).Put("out", ((V)(1D))).Put("doors", Arr(NewObj(5).Put("s", ((V)("B"))).Put("x", ((V)(200D))).Put("to", ((V)("dance"))).Put("k", ((V)("up"))).Put("lab", ((V)("STAIRS"))).V, NewObj(4).Put("s", ((V)("B"))).Put("x", ((V)(360D))).Put("to", ((V)("bathroom"))).Put("k", ((V)("door"))).V, NewObj(4).Put("s", ((V)("B"))).Put("x", ((V)(600D))).Put("to", ((V)("kitchen"))).Put("k", ((V)("glass"))).V)).Put("fixed", Arr(Arr(((V)("hwin")), ((V)(480D))), Arr(((V)("hwin")), ((V)(690D))))).Put("start", Arr(Arr(((V)("tireSwing")), ((V)(470D)), ((V)(204D))), Arr(((V)("oldSandbox")), ((V)(232D)), ((V)(284D))), Arr(((V)("leakyPool")), ((V)(660D)), ((V)(286D))))).Put("toys", Arr()).V).Put("dance", NewObj(8).Put("name", ((V)("Dance Room"))).Put("unlock", ((V)(11D))).Put("doors", Arr(NewObj(2).Put("s", ((V)("L"))).Put("to", ((V)("bedroom"))).V, NewObj(4).Put("s", ((V)("B"))).Put("x", ((V)(200D))).Put("to", ((V)("living"))).Put("k", ((V)("down"))).V, NewObj(5).Put("s", ((V)("B"))).Put("x", ((V)(640D))).Put("to", ((V)("backyard"))).Put("k", ((V)("down"))).Put("lab", ((V)("BALCONY"))).V, NewObj(2).Put("s", ((V)("R"))).Put("to", ((V)("movie"))).V)).Put("winX", V.Null).Put("artX", ((V)(290D))).Put("lightX", ((V)(540D))).Put("fixed", Arr(Arr(((V)("neon")), ((V)(410D)), ((V)("DANCE"))))).Put("start", Arr(Arr(((V)("crateStage")), ((V)(426D)), ((V)(164D))), Arr(((V)("boombox")), ((V)(318D)), ((V)(150D))), Arr(((V)("recPlayer")), ((V)(226D)), ((V)(198D))))).V).Put("movie", NewObj(6).Put("name", ((V)("Movie Room"))).Put("unlock", ((V)(12D))).Put("doors", Arr(NewObj(2).Put("s", ((V)("L"))).Put("to", ((V)("dance"))).V)).Put("artX", ((V)(470D))).Put("lightX", ((V)(380D))).Put("start", Arr()).V).V;
RKEYS_32 = Arr(((V)("living")), ((V)("kitchen")), ((V)("bathroom")), ((V)("bedroom")), ((V)("backyard")), ((V)("dance")), ((V)("movie")));
NAME_33 = NewObj(7).Put("living", ((V)("LIVING ROOM"))).Put("kitchen", ((V)("KITCHEN"))).Put("bathroom", ((V)("BATHROOM"))).Put("bedroom", ((V)("BEDROOM"))).Put("dance", ((V)("DANCE ROOM"))).Put("backyard", ((V)("BACKYARD"))).Put("movie", ((V)("MOVIE ROOM"))).V;
YARD_34 = NewObj(13).Put("b0", ((V)("#f6e7c4"))).Put("b1", ((V)("#fbf1da"))).Put("l0", ((V)("#9fd2f2"))).Put("l1", ((V)("#d4ecf8"))).Put("r0", ((V)("#9fd2f2"))).Put("r1", ((V)("#d4ecf8"))).Put("w0", ((V)("#e9d6ac"))).Put("w1", ((V)("#dcc594"))).Put("wr0", ((V)("#e9d6ac"))).Put("wr1", ((V)("#dcc594"))).Put("trim", CR_15).Put("pat", ((V)("#e3cfa2"))).Put("edge", ((V)("#2a4a1a"))).V;
slotsOf_35 = Fn((V _arrowThis1282, int _argc1275, V rk_1281, V _a1278, V _a1279, V _a1280, V[] _rest1276) => {
return (Truthy(Get(GetK(ROOMS_31, rk_1281), "out")) ? SLOTS_OUT_30 : SLOTS_IN_29);
}, 1, "", true);
specOf_36 = Fn((V _arrowThis1291, int _argc1283, V slot_1289, V id_1290, V _a1287, V _a1288, V[] _rest1284) => {
return (GetK(SPEC_27, id_1290) is var _t1292 && Truthy(_t1292) ? _t1292 : GetK(SPEC_27, GetK(DEF_28, slot_1289)));
}, 2, "", true);
qb_46 = Fn((V _arrowThis1303, int _argc1293, V t_1299, V a_1300, V b_1301, V c_1302, V[] _rest1294) => {
return ((V)((((((1D - ToNum(t_1299)) * (1D - ToNum(t_1299))) * ToNum(a_1300)) + (((2D * (1D - ToNum(t_1299))) * ToNum(t_1299)) * ToNum(b_1301))) + ((ToNum(t_1299) * ToNum(t_1299)) * ToNum(c_1302)))));
}, 4, "", true);
ARROW_48 = NewObj(2).Put("up", ((V)("\u2191 "))).Put("down", ((V)("\u2193 "))).V;
SIGN_49 = NewObj(7).Put("scuff", Arr(((V)("#c9b896")), ((V)("#7d6248")), ((V)("#4a3a28")))).Put("plank", Arr(((V)("#c09a6c")), ((V)("#6b4a2a")), ((V)("#3d2814")))).Put("arch", Arr(((V)("#fff6e2")), ((V)("#5f8a4a")), ((V)("#3f5a30")))).Put("jet", Arr(((V)("#e4eaee")), ((V)("#3d6a6a")), ((V)("#245050")))).Put("flush", Arr(((V)("#2c2d31")), ((V)("#16171a")), ((V)("#f1eee8")))).Put("ginger", Arr(((V)("#c98d52")), ((V)("#7a4a24")), ((V)("#fffaf1")))).Put("palace", Arr(((V)("#f3ead6")), ((V)("#b8862a")), ((V)("#7a1e2c")))).V;
SHAPE_50 = NewObj(7).Put("scuff", ((V)("rect"))).Put("plank", ((V)("rect"))).Put("flush", ((V)("rect"))).Put("jet", ((V)("round"))).Put("arch", ((V)("arch"))).Put("ginger", ((V)("arch"))).Put("palace", ((V)("arch"))).V;
ell2_52 = Fn((V _arrowThis1316, int _argc1304, V cu_1310, V cv_1311, V ru_1312, V rv_1313, V[] _rest1305) => {
V n_1315 = default;
{ V _t1314 = (_argc1304 > 4 ? _rest1305[0] : V.Undef); if (_t1314.IsUndef) _t1314 = ((V)(16D));
n_1315 = _t1314; }
return Array_from(NewObj(1).Put("length", n_1315).V, Fn((V _arrowThis1325, int _argc1317, V __1323, V i_1324, V _a1321, V _a1322, V[] _rest1318) => {
return Arr(Add(cu_1310, ((V)((ToNum(ru_1312) * FdLibm.Cos((((ToNum(i_1324) / ToNum(n_1315)) * System.Math.PI) * 2D)))))), Add(cv_1311, ((V)((ToNum(rv_1313) * FdLibm.Sin((((ToNum(i_1324) / ToNum(n_1315)) * System.Math.PI) * 2D)))))));
}, 2, "", true));
}, 5, "", true);
box2_53 = Fn((V _arrowThis1336, int _argc1326, V ua_1332, V ub_1333, V va_1334, V vb_1335, V[] _rest1327) => {
return Arr(Arr(ua_1332, va_1334), Arr(ub_1333, va_1334), Arr(ub_1333, vb_1335), Arr(ua_1332, vb_1335));
}, 4, "", true);
SC_55 = 426D;
ST_56 = NewObj(2).Put("LH", ((V)(40D))).Put("Z", ((V)(22D))).V;
PW_57 = Fn((V _arrowThis1346, int _argc1337, V px_1343, V z_1344, V h_1345, V _a1342, V[] _rest1338) => {
V s_1347 = default;
s_1347 = Call(WY_24, V.Undef, Add(((V)(100D)), z_1344));
return Arr(((V)((SC_55 + ((ToNum(px_1343) - SC_55) * ToNum(s_1347))))), ((V)((ToNum(Add(((V)(100D)), z_1344)) - (ToNum(h_1345) * ToNum(s_1347))))));
return default;
}, 3, "", true);
wp_58 = Fn((V _arrowThis1356, int _argc1348, V pts_1354, V open_1355, V _a1352, V _a1353, V[] _rest1349) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_1354, "map", Fn((V _arrowThis1364, int _argc1357, V q_1363, V _a1360, V _a1361, V _a1362, V[] _rest1358) => {
V p_1365 = default;
p_1365 = Call(PW_57, V.Undef, GetIdx(q_1363, 0D), GetIdx(q_1363, 1D), GetIdx(q_1363, 2D));
return ((V)(JsStrBuf.Begin().V(Call(f1_12, V.Undef, GetIdx(p_1365, 0D))).S(" ").V(Call(f1_12, V.Undef, GetIdx(p_1365, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S((Truthy(open_1355) ? "" : "Z")).End()));
}, 2, "", true);
WT_59 = ((V)("#c98d58"));
WF_60 = ((V)("#a86b36"));
WS_61 = ((V)("#8e5a2c"));
WE_62 = ((V)("#6b4426"));
RL_63 = ((V)("#e2ad74"));
RD_64 = ((V)("#7d5232"));
NOSE_65 = ((V)("#e7b47e"));
rowsK_70 = Fn((V _arrowThis1374, int _argc1366, V A_1372, V k_1373, V _a1370, V _a1371, V[] _rest1367) => {
V o_1375 = default;
if (SEqN(k_1373, 1D)) {
return A_1372;
}
o_1375 = Arr();
{
V p_1376 = default;
p_1376 = ((V)(0D));
while (true) {
if (!(LtN(p_1376, ((ToNum(Get(A_1372, "length")) - 1D) - 0.000001)))) break;
double i_1378 = 0;
double f_1379 = 0;
i_1378 = System.Math.Floor(ToNum(p_1376));
f_1379 = (ToNum(p_1376) - i_1378);
Invoke(o_1375, "push", ((V)(Round(ToNum(Add(GetIdx(A_1372, i_1378), ((V)(((ToNum(GetIdx(A_1372, (i_1378 + 1D))) - ToNum(GetIdx(A_1372, i_1378))) * f_1379)))))))));
p_1376 = Add(p_1376, k_1373);
}
}
Invoke(o_1375, "push", GetIdx(A_1372, (ToNum(Get(A_1372, "length")) - 1D)));
return o_1375;
return default;
}, 2, "", true);
SH_72 = NewObj(0).V;
MOTIF_74 = NewObj(9).Put("stripe", Fn((V _arrowThis1387, int _argc1380, V c_1386, V _a1383, V _a1384, V _a1385, V[] _rest1381) => {
return Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "map", Fn((V _arrowThis1395, int _argc1388, V i_1394, V _a1391, V _a1392, V _a1393, V[] _rest1389) => {
return Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)((6D + (ToNum(i_1394) * 18D)))), ((V)(0D)), ((V)(9D)), ((V)(52D)), ((V)(0D))), c_1386, ((V)(0D)), ((V)(0D)), ((V)(0.55)));
}, 1, "", true));
}, 1, "stripe", true)).Put("peel", Fn((V _arrowThis1403, int _argc1396, V c_1402, V _a1399, V _a1400, V _a1401, V[] _rest1397) => {
return Arr(Call(pd_20, V.Undef, Call(ell_14, V.Undef, ((V)(22D)), ((V)(18D)), ((V)(10D)), ((V)(7D))), ((V)("#8a6a48")), ((V)(0D)), ((V)(0D)), ((V)(0.15))), Call(pd_20, V.Undef, ((V)("M50 0L54 10L50 18L58 30")), ((V)("none")), c_1402, ((V)(1.4))), Call(pd_20, V.Undef, ((V)("M62 4Q70 8 66 20L74 22L72 2Z")), ((V)("#f1e8d6")), c_1402, ((V)(1D))));
}, 1, "peel", true)).Put("plaster", Fn((V _arrowThis1411, int _argc1404, V c_1410, V _a1407, V _a1408, V _a1409, V[] _rest1405) => {
return Arr(Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(10D)), ((V)(8D)), ((V)(22D)), ((V)(16D)), ((V)(2D))), c_1410, ((V)(0D)), ((V)(0D)), ((V)(0.7))), Call(pd_20, V.Undef, Call(rr_21, V.Undef, ((V)(44D)), ((V)(26D)), ((V)(26D)), ((V)(18D)), ((V)(2D))), c_1410, ((V)(0D)), ((V)(0D)), ((V)(0.7))));
}, 1, "plaster", true)).Put("daisy", Fn((V _arrowThis1419, int _argc1412, V c_1418, V _a1415, V _a1416, V _a1417, V[] _rest1413) => {
return Invoke(Arr(Arr(((V)(16D)), ((V)(14D))), Arr(((V)(50D)), ((V)(10D))), Arr(((V)(30D)), ((V)(36D))), Arr(((V)(66D)), ((V)(34D)))), "flatMap", Fn((V _arrowThis1431, int _argc1420, V _a1422, V _a1423, V _a1424, V _a1425, V[] _rest1421) => {
V x_1428 = default;
V y_1430 = default;
{ V _t1426 = ListOf(_a1422);
{ V _t1427 = GetIdx(_t1426, 0D);
x_1428 = _t1427; }
{ V _t1429 = GetIdx(_t1426, 1D);
y_1430 = _t1429; }
}
return Invoke(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D))), "map", Fn((V _arrowThis1439, int _argc1432, V i_1438, V _a1435, V _a1436, V _a1437, V[] _rest1433) => {
return Call(pd_20, V.Undef, Call(circ_13, V.Undef, Add(x_1428, ((V)((4D * FdLibm.Cos((ToNum(i_1438) * 1.26)))))), Add(y_1430, ((V)((4D * FdLibm.Sin((ToNum(i_1438) * 1.26)))))), ((V)(2.6))), ((V)("#ffffff")));
}, 1, "", true)), "concat", Arr(Call(pd_20, V.Undef, Call(circ_13, V.Undef, x_1428, y_1430, ((V)(2D))), c_1418)));
}, 1, "", true));
}, 1, "daisy", true)).Put("tile", Fn((V _arrowThis1447, int _argc1440, V c_1446, V _a1443, V _a1444, V _a1445, V[] _rest1441) => {
return Arr(Call(pd_20, V.Undef, ((V)("M0 13H80M0 26H80M0 39H80M13 0V52M26 0V52M39 0V52M52 0V52M65 0V52")), ((V)("none")), c_1446, ((V)(1.4))));
}, 1, "tile", true)).Put("burst", Fn((V _arrowThis1455, int _argc1448, V c_1454, V _a1451, V _a1452, V _a1453, V[] _rest1449) => {
return Invoke(Arr(Arr(((V)(18D)), ((V)(14D))), Arr(((V)(56D)), ((V)(24D))), Arr(((V)(30D)), ((V)(40D)))), "map", Fn((V _arrowThis1467, int _argc1456, V _a1458, V _a1459, V _a1460, V _a1461, V[] _rest1457) => {
V x_1464 = default;
V y_1466 = default;
{ V _t1462 = ListOf(_a1458);
{ V _t1463 = GetIdx(_t1462, 0D);
x_1464 = _t1463; }
{ V _t1465 = GetIdx(_t1462, 1D);
y_1466 = _t1465; }
}
return Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_1464).S(" ").N((ToNum(y_1466) - 7D)).S("L").V(Add(x_1464, ((V)(1.6)))).S(" ").N((ToNum(y_1466) - 1.6)).S("L").V(Add(x_1464, ((V)(7D)))).S(" ").V(y_1466).S("L").V(Add(x_1464, ((V)(1.6)))).S(" ").V(Add(y_1466, ((V)(1.6)))).S("L").V(x_1464).S(" ").V(Add(y_1466, ((V)(7D)))).S("L").N((ToNum(x_1464) - 1.6)).S(" ").V(Add(y_1466, ((V)(1.6)))).S("L").N((ToNum(x_1464) - 7D)).S(" ").V(y_1466).S("L").N((ToNum(x_1464) - 1.6)).S(" ").N((ToNum(y_1466) - 1.6)).S("Z").End())), c_1454);
}, 1, "", true));
}, 1, "burst", true)).Put("linen", Fn((V _arrowThis1475, int _argc1468, V c_1474, V _a1471, V _a1472, V _a1473, V[] _rest1469) => {
return Arr(Call(pd_20, V.Undef, ((V)("M0 6H80M0 14H80M0 22H80M0 30H80M0 38H80M0 46H80")), ((V)("none")), c_1474, ((V)(0.8))));
}, 1, "linen", true)).Put("candy", Fn((V _arrowThis1483, int _argc1476, V c_1482, V _a1479, V _a1480, V _a1481, V[] _rest1477) => {
return Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D)), ((V)(5D))), "map", Fn((V _arrowThis1491, int _argc1484, V i_1490, V _a1487, V _a1488, V _a1489, V[] _rest1485) => {
return Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").N(((ToNum(i_1490) * 18D) - 20D)).S(" 52L").N(((ToNum(i_1490) * 18D) + 2D)).S(" 0H").N(((ToNum(i_1490) * 18D) + 11D)).S("L").N(((ToNum(i_1490) * 18D) - 11D)).S(" 52Z").End())), c_1482, ((V)(0D)), ((V)(0D)), ((V)(0.8)));
}, 1, "", true));
}, 1, "candy", true)).Put("damask", Fn((V _arrowThis1499, int _argc1492, V c_1498, V _a1495, V _a1496, V _a1497, V[] _rest1493) => {
return Invoke(Arr(Arr(((V)(20D)), ((V)(14D))), Arr(((V)(60D)), ((V)(14D))), Arr(((V)(40D)), ((V)(36D)))), "map", Fn((V _arrowThis1511, int _argc1500, V _a1502, V _a1503, V _a1504, V _a1505, V[] _rest1501) => {
V x_1508 = default;
V y_1510 = default;
{ V _t1506 = ListOf(_a1502);
{ V _t1507 = GetIdx(_t1506, 0D);
x_1508 = _t1507; }
{ V _t1509 = GetIdx(_t1506, 1D);
y_1510 = _t1509; }
}
return Call(pd_20, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(x_1508).S(" ").N((ToNum(y_1510) - 10D)).S("Q").V(Add(x_1508, ((V)(8D)))).S(" ").V(y_1510).S(" ").V(x_1508).S(" ").V(Add(y_1510, ((V)(10D)))).S("Q").N((ToNum(x_1508) - 8D)).S(" ").V(y_1510).S(" ").V(x_1508).S(" ").N((ToNum(y_1510) - 10D)).S("Z").End())), c_1498);
}, 1, "", true));
}, 1, "damask", true)).V;
Object_assign(X_8, NewObj(11).Put("ROOMS", ROOMS_31).Put("RKEYS", RKEYS_32).Put("NAME", NAME_33).Put("SPEC", SPEC_27).Put("DEF", DEF_28).Put("SLOTS_IN", SLOTS_IN_29).Put("SLOTS_OUT", SLOTS_OUT_30).Put("slotsOf", slotsOf_35).Put("shell", shell_73).Put("swatch", swatch_75).Put("palette", palette_37).V);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
