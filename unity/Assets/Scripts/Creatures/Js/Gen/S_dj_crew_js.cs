// dj-crew.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_dj_crew_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("<metadata>[\\s\\S]*?<\\/metadata>", "");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V f1_8 = default;
double BEAT_9 = 0;
V A_10 = default;
V GEN_11 = default;
V RAW_12 = default;
V OUT_13 = default;
V SUBS_14 = default;
V load_15 = default;
V spl_16 = default;
V atr_17 = default;
V rects_18 = default;
V arm_19 = default;
V build_20 = default;
if (_self1.IsNullish) _self1 = GlobalV;
arm_19 = Fn((V _self21, int _argc22, V q_28, V R_29, V P_30, V tk_31, V[] _rest23) => {
V c_33 = default;
double dx_34 = 0;
double dy_35 = 0;
V L_36 = default;
double ux_37 = 0;
double uy_38 = 0;
double nx_39 = 0;
double ny_40 = 0;
double sg_41 = 0;
V d_42 = default;
double hx_43 = 0;
double hy_44 = 0;
double pr_45 = 0;
JsStrBuf s_46 = null;
V kind_32 = default;
if (_self21.IsNullish) _self21 = GlobalV;
kind_32 = (_argc22 > 4 ? _rest23[0] : V.Undef);
c_33 = Get(q_28, "c");
dx_34 = (ToNum(GetIdx(P_30, 0D)) - ToNum(GetIdx(R_29, 0D)));
dy_35 = (ToNum(GetIdx(P_30, 1D)) - ToNum(GetIdx(R_29, 1D)));
L_36 = (((V)(Hypot(dx_34, dy_35))) is var _t47 && Truthy(_t47) ? _t47 : ((V)(1D)));
ux_37 = (dx_34 / ToNum(L_36));
uy_38 = (dy_35 / ToNum(L_36));
nx_39 = (-uy_38);
ny_40 = ux_37;
sg_41 = (((nx_39 + ny_40) < 0D) ? 1D : (-1D));
d_42 = ((V)(JsStrBuf.Begin().S("M").V(Call(f1_8, V.Undef, GetIdx(R_29, 0D))).S(" ").V(Call(f1_8, V.Undef, GetIdx(R_29, 1D))).S("L").V(Call(f1_8, V.Undef, GetIdx(P_30, 0D))).S(" ").V(Call(f1_8, V.Undef, GetIdx(P_30, 1D))).End()));
hx_43 = (((nx_39 * sg_41) * ToNum(tk_31)) * 0.2);
hy_44 = (((ny_40 * sg_41) * ToNum(tk_31)) * 0.2);
pr_45 = (ToNum(tk_31) * (Truthy(Get(q_28, "flip")) ? 0.55 : 0.66));
s_46 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(d_42).S("\" stroke=\"").V(GetIdx(c_33, 2D)).S("\" stroke-width=\"").V(Call(f1_8, V.Undef, Add(tk_31, ((V)(1.2))))).S("\" stroke-linecap=\"round\" fill=\"none\"/><path d=\"").V(d_42).S("\" stroke=\"url(#djAg)\" stroke-width=\"").V(Call(f1_8, V.Undef, tk_31)).S("\" stroke-linecap=\"round\" fill=\"none\"/>").S("<path d=\"M").V(Call(f1_8, V.Undef, Add(Add(GetIdx(R_29, 0D), ((V)(hx_43))), ((V)((ux_37 * 2D)))))).S(" ").V(Call(f1_8, V.Undef, Add(Add(GetIdx(R_29, 1D), ((V)(hy_44))), ((V)((uy_38 * 2D)))))).S("L").V(Call(f1_8, V.Undef, ((V)((ToNum(Add(GetIdx(P_30, 0D), ((V)(hx_43)))) - (ux_37 * pr_45)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((ToNum(Add(GetIdx(P_30, 1D), ((V)(hy_44)))) - (uy_38 * pr_45)))))).S("\" stroke=\"").V(GetIdx(c_33, 0D)).S("\" stroke-width=\"").V(Call(f1_8, V.Undef, ((V)((ToNum(tk_31) * 0.32))))).S("\" stroke-linecap=\"round\" opacity=\"0.7\" fill=\"none\"/>").End());
s_46.S("<circle cx=\"").V(Call(f1_8, V.Undef, GetIdx(P_30, 0D))).S("\" cy=\"").V(Call(f1_8, V.Undef, GetIdx(P_30, 1D))).S("\" r=\"").V(Call(f1_8, V.Undef, ((V)(pr_45)))).S("\" fill=\"url(#djPw)\" stroke=\"").V(GetIdx(c_33, 2D)).S("\" stroke-width=\"0.6\"/><ellipse cx=\"").V(Call(f1_8, V.Undef, ((V)((ToNum(GetIdx(P_30, 0D)) - (pr_45 * 0.32)))))).S("\" cy=\"").V(Call(f1_8, V.Undef, ((V)((ToNum(GetIdx(P_30, 1D)) - (pr_45 * 0.38)))))).S("\" rx=\"").V(Call(f1_8, V.Undef, ((V)((pr_45 * 0.34))))).S("\" ry=\"").V(Call(f1_8, V.Undef, ((V)((pr_45 * 0.22))))).S("\" fill=\"#ffffff\" opacity=\"0.55\"/>");
if (!(Truthy(Get(q_28, "flip")))) {
double ax_48 = 0;
double ay_49 = 0;
ax_48 = (SEqS(kind_32, "fist") ? ux_37 : ((-nx_39) * sg_41));
ay_49 = (SEqS(kind_32, "fist") ? uy_38 : ((-ny_40) * sg_41));
Invoke(Arr(((V)((-1D))), ((V)(0D)), ((V)(1D))), "forEach", Fn((V _arrowThis57, int _argc50, V i_56, V _a53, V _a54, V _a55, V[] _rest51) => {
V bx_58 = default;
V by_59 = default;
bx_58 = Add(Add(GetIdx(P_30, 0D), ((V)(((ax_48 * pr_45) * 0.55)))), ((V)(((((-ay_49) * ToNum(i_56)) * pr_45) * 0.36))));
by_59 = Add(Add(GetIdx(P_30, 1D), ((V)(((ay_49 * pr_45) * 0.55)))), ((V)((((ax_48 * ToNum(i_56)) * pr_45) * 0.36))));
s_46.S("<path d=\"M").V(Call(f1_8, V.Undef, ((V)((ToNum(bx_58) - ((ax_48 * pr_45) * 0.32)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((ToNum(by_59) - ((ay_49 * pr_45) * 0.32)))))).S("L").V(Call(f1_8, V.Undef, bx_58)).S(" ").V(Call(f1_8, V.Undef, by_59)).S("\" stroke=\"").V(GetIdx(c_33, 2D)).S("\" stroke-width=\"0.55\" stroke-linecap=\"round\" opacity=\"0.7\"/>");
return default;
}, 1, "", true));
if (Truthy((Get(q_28, "bean") is var _t60 && !Truthy(_t60) ? _t60 : (!SEqS(kind_32, "fist") ? V.True : V.False)))) {
s_46.S("<ellipse cx=\"").V(Call(f1_8, V.Undef, ((V)((ToNum(GetIdx(P_30, 0D)) - ((ax_48 * pr_45) * 0.1)))))).S("\" cy=\"").V(Call(f1_8, V.Undef, ((V)((ToNum(GetIdx(P_30, 1D)) - ((ay_49 * pr_45) * 0.1)))))).S("\" rx=\"").V(Call(f1_8, V.Undef, ((V)((pr_45 * 0.3))))).S("\" ry=\"").V(Call(f1_8, V.Undef, ((V)((pr_45 * 0.24))))).S("\" fill=\"").V(Get(q_28, "bean")).S("\" opacity=\"0.8\"/>");
}
}
return ((V)(s_46.Str));
return default;
}, 5, "arm", false);
build_20 = Fn((V _self61, int _argc62, V k_68, V raw_69, V _a66, V _a67, V[] _rest63) => {
V q_70 = default;
V c_71 = default;
V er_72 = default;
double xL_73 = 0;
V xR_74 = default;
double ch_75 = 0;
double cw_76 = 0;
JsStrBuf defs_77 = null;
V neck_78 = default;
double yT_79 = 0;
double y0_80 = 0;
double yc_81 = 0;
V band_82 = default;
JsStrBuf hs_83 = null;
V cup_84 = default;
double lw_85 = 0;
double lh_86 = 0;
V lens_87 = default;
double lx_88 = 0;
V rx_89 = default;
double tY_90 = 0;
JsStrBuf sh_91 = null;
JsStrBuf mo_92 = null;
double tk_93 = 0;
V R1_94 = default;
V P1_95 = default;
V R2_96 = default;
V P2_97 = default;
V pump_98 = default;
V hold_99 = default;
V use_100 = default;
V nod_101 = default;
V body_102 = default;
V svg_103 = default;
if (_self61.IsNullish) _self61 = GlobalV;
q_70 = (GetK(A_10, k_68) is var _t104 && Truthy(_t104) ? _t104 : GEN_11);
c_71 = Get(q_70, "c");
er_72 = Get(q_70, "er");
xL_73 = (50D - ToNum(Get(q_70, "hw")));
xR_74 = Add(((V)(50D)), Get(q_70, "hw"));
ch_75 = (ToNum(er_72) * 1.65);
cw_76 = (ToNum(er_72) * 1.25);
defs_77 = new JsStrBuf(JsStrBuf.Begin().S("<g id=\"djC\">").V(raw_69).S("</g>").S("<linearGradient id=\"djAg\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"").V(GetIdx(c_71, 0D)).S("\"/><stop offset=\"0.55\" stop-color=\"").V(GetIdx(c_71, 1D)).S("\"/><stop offset=\"1\" stop-color=\"").V(GetIdx(c_71, 2D)).S("\"/></linearGradient>").S("<radialGradient id=\"djPw\" cx=\"36%\" cy=\"32%\" r=\"72%\"><stop offset=\"0\" stop-color=\"").V(GetIdx(c_71, 0D)).S("\"/><stop offset=\"0.6\" stop-color=\"").V(GetIdx(c_71, 1D)).S("\"/><stop offset=\"1\" stop-color=\"").V(GetIdx(c_71, 2D)).S("\"/></radialGradient>").S("<radialGradient id=\"djCup\" cx=\"34%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#5a5e6c\"/><stop offset=\"0.5\" stop-color=\"#26272f\"/><stop offset=\"1\" stop-color=\"#0c0c10\"/></radialGradient>").S("<linearGradient id=\"djBand\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#4a4d5a\"/><stop offset=\"0.5\" stop-color=\"#1d1e25\"/><stop offset=\"1\" stop-color=\"#0c0c10\"/></linearGradient>").S("<linearGradient id=\"djLens\" x1=\"0\" y1=\"0\" x2=\"0.3\" y2=\"1\"><stop offset=\"0\" stop-color=\"#3a3350\"/><stop offset=\"0.55\" stop-color=\"#14121c\"/><stop offset=\"1\" stop-color=\"#050508\"/></linearGradient>").S("<linearGradient id=\"djGold\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0b8\"/><stop offset=\"0.5\" stop-color=\"#e2b14a\"/><stop offset=\"1\" stop-color=\"#9a6a1a\"/></linearGradient>").S("<filter id=\"djGl\" x=\"-60%\" y=\"-60%\" width=\"220%\" height=\"220%\"><feGaussianBlur stdDeviation=\"0.9\"/></filter>").End());
neck_78 = (!Get(q_70, "nk").IsNullish ? V.True : V.False);
if (Truthy(neck_78)) {
defs_77.S("<clipPath id=\"djBc\" clipPathUnits=\"userSpaceOnUse\">").V(Call(rects_18, V.Undef, q_70, ((V)((ToNum(Get(q_70, "nk")) - 1D))), ((V)(110D)))).S("</clipPath><clipPath id=\"djHc\" clipPathUnits=\"userSpaceOnUse\">").V(Call(rects_18, V.Undef, q_70, ((V)((-10D))), Add(Get(q_70, "nk"), ((V)(3D))))).S("</clipPath>");
} else {
if (Truthy(Get(q_70, "clip"))) {
defs_77.S("<clipPath id=\"djBc\" clipPathUnits=\"userSpaceOnUse\">").V(Call(rects_18, V.Undef, q_70, ((V)((-10D))), ((V)(110D)))).S("</clipPath>");
}
}
yT_79 = (ToNum(Get(q_70, "ht")) - 3.2);
y0_80 = (ToNum(Get(q_70, "cy")) - (ch_75 * 0.9));
yc_81 = (((4D * yT_79) - y0_80) / 3D);
band_82 = ((V)(JsStrBuf.Begin().S("M").V(Call(f1_8, V.Undef, ((V)(xL_73)))).S(" ").V(Call(f1_8, V.Undef, ((V)(y0_80)))).S("C").V(Call(f1_8, V.Undef, ((V)((xL_73 - 1D))))).S(" ").V(Call(f1_8, V.Undef, ((V)(yc_81)))).S(" ").V(Call(f1_8, V.Undef, Add(xR_74, ((V)(1D))))).S(" ").V(Call(f1_8, V.Undef, ((V)(yc_81)))).S(" ").V(Call(f1_8, V.Undef, xR_74)).S(" ").V(Call(f1_8, V.Undef, ((V)(y0_80)))).End()));
hs_83 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(band_82).S("\" fill=\"none\" stroke=\"#0c0c10\" stroke-width=\"5.6\" stroke-linecap=\"round\"/><path d=\"").V(band_82).S("\" fill=\"none\" stroke=\"url(#djBand)\" stroke-width=\"4.4\" stroke-linecap=\"round\"/>").S("<path d=\"").V(band_82).S("\" fill=\"none\" stroke=\"#6a6e7c\" stroke-width=\"0.7\" stroke-linecap=\"round\" stroke-dasharray=\"1.4 1.2\" opacity=\"0.8\" transform=\"translate(0 -0.9)\"/>").S("<path d=\"").V(band_82).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.9\" stroke-linecap=\"round\" pathLength=\"100\" stroke-dasharray=\"0 22 56 22\" opacity=\"0.3\" transform=\"translate(0 -1.3)\"/>").End());
cup_84 = Fn((V _arrowThis113, int _argc105, V x_111, V side_112, V _a109, V _a110, V[] _rest106) => {
V cx_114 = default;
V s_115 = default;
cx_114 = Add(x_111, ((V)((ToNum(side_112) * 1.2))));
s_115 = ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_8, V.Undef, ((V)((ToNum(x_111) - (ToNum(side_112) * 0.6)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((y0_80 - 1.6))))).S("V").V(Call(f1_8, V.Undef, ((V)((ToNum(Get(q_70, "cy")) - (ch_75 * 0.55)))))).S("\" stroke=\"#d5dde2\" stroke-width=\"1.6\" stroke-linecap=\"round\"/>").S("<path d=\"M").V(Call(f1_8, V.Undef, ((V)((ToNum(cx_114) - (cw_76 * 0.95)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((ToNum(Get(q_70, "cy")) - (ch_75 * 0.25)))))).S("Q").V(Call(f1_8, V.Undef, ((V)((ToNum(cx_114) - (cw_76 * 0.95)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((ToNum(Get(q_70, "cy")) - (ch_75 * 1.05)))))).S(" ").V(Call(f1_8, V.Undef, cx_114)).S(" ").V(Call(f1_8, V.Undef, ((V)((ToNum(Get(q_70, "cy")) - (ch_75 * 1.05)))))).S("Q").V(Call(f1_8, V.Undef, Add(cx_114, ((V)((cw_76 * 0.95)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((ToNum(Get(q_70, "cy")) - (ch_75 * 1.05)))))).S(" ").V(Call(f1_8, V.Undef, Add(cx_114, ((V)((cw_76 * 0.95)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((ToNum(Get(q_70, "cy")) - (ch_75 * 0.25)))))).S("\" fill=\"none\" stroke=\"#b9c0c8\" stroke-width=\"0.9\"/>").S("<ellipse cx=\"").V(Call(f1_8, V.Undef, ((V)((ToNum(cx_114) - (ToNum(side_112) * 1.1)))))).S("\" cy=\"").V(Call(f1_8, V.Undef, Get(q_70, "cy"))).S("\" rx=\"").V(Call(f1_8, V.Undef, ((V)((cw_76 * 0.75))))).S("\" ry=\"").V(Call(f1_8, V.Undef, ((V)((ch_75 * 0.96))))).S("\" fill=\"#141418\"/>").S("<ellipse cx=\"").V(Call(f1_8, V.Undef, cx_114)).S("\" cy=\"").V(Call(f1_8, V.Undef, Get(q_70, "cy"))).S("\" rx=\"").V(Call(f1_8, V.Undef, ((V)(cw_76)))).S("\" ry=\"").V(Call(f1_8, V.Undef, ((V)(ch_75)))).S("\" fill=\"url(#djCup)\" stroke=\"#07070a\" stroke-width=\"0.7\"/>").S("<ellipse cx=\"").V(Call(f1_8, V.Undef, cx_114)).S("\" cy=\"").V(Call(f1_8, V.Undef, Get(q_70, "cy"))).S("\" rx=\"").V(Call(f1_8, V.Undef, ((V)((cw_76 * 0.66))))).S("\" ry=\"").V(Call(f1_8, V.Undef, ((V)((ch_75 * 0.66))))).S("\" fill=\"none\" stroke=\"#d5dde2\" stroke-width=\"0.7\"/>").S("<ellipse cx=\"").V(Call(f1_8, V.Undef, cx_114)).S("\" cy=\"").V(Call(f1_8, V.Undef, Get(q_70, "cy"))).S("\" rx=\"").V(Call(f1_8, V.Undef, ((V)((cw_76 * 0.66))))).S("\" ry=\"").V(Call(f1_8, V.Undef, ((V)((ch_75 * 0.66))))).S("\" fill=\"none\" stroke=\"#3ff0ff\" stroke-width=\"1.6\" filter=\"url(#djGl)\"><animate attributeName=\"opacity\" values=\"1;0.35;1\" dur=\"").N(BEAT_9).S("s\" repeatCount=\"indefinite\"/><animate attributeName=\"stroke\" values=\"#3ff0ff;#ff4fb8;#ffe14f;#3ff0ff\" dur=\"").N((BEAT_9 * 8D)).S("s\" repeatCount=\"indefinite\"/></ellipse>").S("<circle cx=\"").V(Call(f1_8, V.Undef, cx_114)).S("\" cy=\"").V(Call(f1_8, V.Undef, Get(q_70, "cy"))).S("\" r=\"").V(Call(f1_8, V.Undef, ((V)((ToNum(er_72) * 0.42))))).S("\" fill=\"#202128\" stroke=\"#5a5e6c\" stroke-width=\"0.35\"/><path d=\"M").V(Call(f1_8, V.Undef, ((V)((ToNum(cx_114) - (ToNum(er_72) * 0.2)))))).S(" ").V(Call(f1_8, V.Undef, Add(Get(q_70, "cy"), ((V)((ToNum(er_72) * 0.18)))))).S("L").V(Call(f1_8, V.Undef, cx_114)).S(" ").V(Call(f1_8, V.Undef, ((V)((ToNum(Get(q_70, "cy")) - (ToNum(er_72) * 0.26)))))).S("L").V(Call(f1_8, V.Undef, Add(cx_114, ((V)((ToNum(er_72) * 0.2)))))).S(" ").V(Call(f1_8, V.Undef, Add(Get(q_70, "cy"), ((V)((ToNum(er_72) * 0.18)))))).S("\" fill=\"none\" stroke=\"#e2b14a\" stroke-width=\"0.45\"/>").S("<ellipse cx=\"").V(Call(f1_8, V.Undef, ((V)((ToNum(cx_114) - (cw_76 * 0.35)))))).S("\" cy=\"").V(Call(f1_8, V.Undef, ((V)((ToNum(Get(q_70, "cy")) - (ch_75 * 0.5)))))).S("\" rx=\"").V(Call(f1_8, V.Undef, ((V)((cw_76 * 0.32))))).S("\" ry=\"").V(Call(f1_8, V.Undef, ((V)((ch_75 * 0.2))))).S("\" fill=\"#ffffff\" opacity=\"0.32\"/>").End()));
return s_115;
return default;
}, 2, "", true);
hs_83.V(Add(Call(cup_84, V.Undef, ((V)(xL_73)), ((V)((-1D)))), Call(cup_84, V.Undef, xR_74, ((V)(1D)))));
lw_85 = (ToNum(er_72) * 3D);
lh_86 = (ToNum(er_72) * 2.1);
lens_87 = Fn((V _arrowThis123, int _argc116, V cx_122, V _a119, V _a120, V _a121, V[] _rest117) => {
double l_124 = 0;
V r_125 = default;
double t_126 = 0;
V b_127 = default;
l_124 = (ToNum(cx_122) - (lw_85 / 2D));
r_125 = Add(cx_122, ((V)((lw_85 / 2D))));
t_126 = (ToNum(Get(q_70, "ey")) - (lh_86 * 0.45));
b_127 = Add(Get(q_70, "ey"), ((V)((lh_86 * 0.55))));
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_8, V.Undef, ((V)(l_124)))).S(" ").V(Call(f1_8, V.Undef, ((V)(t_126)))).S("H").V(Call(f1_8, V.Undef, r_125)).S("Q").V(Call(f1_8, V.Undef, Add(r_125, ((V)(0.4))))).S(" ").V(Call(f1_8, V.Undef, b_127)).S(" ").V(Call(f1_8, V.Undef, Add(cx_122, ((V)((lw_85 * 0.18)))))).S(" ").V(Call(f1_8, V.Undef, b_127)).S("H").V(Call(f1_8, V.Undef, ((V)((ToNum(cx_122) - (lw_85 * 0.18)))))).S("Q").V(Call(f1_8, V.Undef, ((V)((l_124 - 0.4))))).S(" ").V(Call(f1_8, V.Undef, b_127)).S(" ").V(Call(f1_8, V.Undef, ((V)(l_124)))).S(" ").V(Call(f1_8, V.Undef, ((V)(t_126)))).S("Z").End()));
return default;
}, 1, "", true);
lx_88 = (50D - ToNum(Get(q_70, "ex")));
rx_89 = Add(((V)(50D)), Get(q_70, "ex"));
tY_90 = (ToNum(Get(q_70, "ey")) - (lh_86 * 0.45));
sh_91 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_8, V.Undef, ((V)((lx_88 - (lw_85 / 2D)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((tY_90 + 0.6))))).S("L").V(Call(f1_8, V.Undef, ((V)((xL_73 + 1.5))))).S(" ").V(Call(f1_8, V.Undef, ((V)((ToNum(Get(q_70, "cy")) - 0.6))))).S("M").V(Call(f1_8, V.Undef, Add(rx_89, ((V)((lw_85 / 2D)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((tY_90 + 0.6))))).S("L").V(Call(f1_8, V.Undef, ((V)((ToNum(xR_74) - 1.5))))).S(" ").V(Call(f1_8, V.Undef, ((V)((ToNum(Get(q_70, "cy")) - 0.6))))).S("\" stroke=\"#16161c\" stroke-width=\"1.1\" stroke-linecap=\"round\"/>").End());
Invoke(Arr(((V)(lx_88)), rx_89), "forEach", Fn((V _arrowThis136, int _argc128, V cx_134, V i_135, V _a132, V _a133, V[] _rest129) => {
sh_91.S("<path d=\"").V(Call(lens_87, V.Undef, cx_134)).S("\" fill=\"url(#djLens)\" stroke=\"url(#djGold)\" stroke-width=\"0.75\"/>").S("<path d=\"M").V(Call(f1_8, V.Undef, ((V)((ToNum(cx_134) - (lw_85 * 0.32)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((tY_90 + (lh_86 * 0.75)))))).S("L").V(Call(f1_8, V.Undef, ((V)((ToNum(cx_134) - (lw_85 * 0.05)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((tY_90 + 0.5))))).S("L").V(Call(f1_8, V.Undef, Add(cx_134, ((V)((lw_85 * 0.12)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((tY_90 + 0.5))))).S("L").V(Call(f1_8, V.Undef, ((V)((ToNum(cx_134) - (lw_85 * 0.16)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((tY_90 + (lh_86 * 0.82)))))).S("Z\" fill=\"#ffffff\" opacity=\"0.28\"/>").S("<ellipse cx=\"").V(Call(f1_8, V.Undef, Add(cx_134, ((V)((lw_85 * 0.22)))))).S("\" cy=\"").V(Call(f1_8, V.Undef, Add(Get(q_70, "ey"), ((V)((lh_86 * 0.2)))))).S("\" rx=\"").V(Call(f1_8, V.Undef, ((V)((lw_85 * 0.13))))).S("\" ry=\"").V(Call(f1_8, V.Undef, ((V)((lh_86 * 0.1))))).S("\" fill=\"#3ff0ff\" opacity=\"0.6\"><animate attributeName=\"fill\" values=\"#3ff0ff;#ff4fb8;#ffe14f;#3ff0ff\" dur=\"").N((BEAT_9 * 8D)).S("s\" begin=\"").N((((-ToNum(i_135)) * BEAT_9) * 2D)).S("s\" repeatCount=\"indefinite\"/></ellipse>");
return default;
}, 2, "", true));
sh_91.S("<path d=\"M").V(Call(f1_8, V.Undef, ((V)(((lx_88 - (lw_85 / 2D)) - 0.4))))).S(" ").V(Call(f1_8, V.Undef, ((V)(tY_90)))).S("H").V(Call(f1_8, V.Undef, Add(Add(rx_89, ((V)((lw_85 / 2D)))), ((V)(0.4))))).S("\" stroke=\"url(#djGold)\" stroke-width=\"1.5\" stroke-linecap=\"round\"/><path d=\"M").V(Call(f1_8, V.Undef, ((V)((lx_88 + (lw_85 / 2D)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((tY_90 + 1.2))))).S("Q50 ").V(Call(f1_8, V.Undef, ((V)((tY_90 - 0.6))))).S(" ").V(Call(f1_8, V.Undef, ((V)((ToNum(rx_89) - (lw_85 / 2D)))))).S(" ").V(Call(f1_8, V.Undef, ((V)((tY_90 + 1.2))))).S("\" fill=\"none\" stroke=\"url(#djGold)\" stroke-width=\"0.9\"/>");
mo_92 = new JsStrBuf("");
if (!Get(q_70, "my").IsNullish) {
double w_137 = 0;
V my_138 = default;
w_137 = (ToNum(er_72) * 0.78);
my_138 = Get(q_70, "my");
mo_92.Set(JsStrBuf.Begin().S("<g transform=\"translate(50 ").V(Call(f1_8, V.Undef, ((V)((ToNum(my_138) - 1D))))).S(")\"><g>").V(Call(atr_17, V.Undef, ((V)("scale")), ((V)("1 1;1 0.72;1 1")), ((V)("0;0.5;1")), ((V)(BEAT_9)))).S("<path d=\"M").V(Call(f1_8, V.Undef, ((V)((-w_137))))).S(" 0Q0 ").V(Call(f1_8, V.Undef, ((V)((w_137 * 1.55))))).S(" ").V(Call(f1_8, V.Undef, ((V)(w_137)))).S(" 0Q0 ").V(Call(f1_8, V.Undef, ((V)((w_137 * 0.28))))).S(" ").V(Call(f1_8, V.Undef, ((V)((-w_137))))).S(" 0Z\" fill=\"#5c1f30\" stroke=\"#3a1420\" stroke-width=\"0.35\"/>").S("<ellipse cx=\"0\" cy=\"").V(Call(f1_8, V.Undef, ((V)((w_137 * 0.68))))).S("\" rx=\"").V(Call(f1_8, V.Undef, ((V)((w_137 * 0.5))))).S("\" ry=\"").V(Call(f1_8, V.Undef, ((V)((w_137 * 0.28))))).S("\" fill=\"#ff7f9a\"/></g></g>").End());
}
tk_93 = (Truthy(Get(q_70, "flip")) ? 8.4 : 9.6);
R1_94 = Arr(((V)((50D - (ToNum(Get(q_70, "sx")) * 0.78)))), ((V)((ToNum(Get(q_70, "sy")) - 6D))));
P1_95 = Arr(((V)((xL_73 - 4.5))), Add(Get(q_70, "ht"), ((V)(3D))));
R2_96 = Arr(Add(((V)(50D)), Get(q_70, "sx")), Get(q_70, "sy"));
P2_97 = Arr(Add(xR_74, ((V)(2.6))), Add(Get(q_70, "cy"), ((V)((ch_75 * 0.45)))));
pump_98 = ((V)(JsStrBuf.Begin().S("<g>").V(Call(atr_17, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().S("0 ").V(Call(f1_8, V.Undef, GetIdx(R1_94, 0D))).S(" ").V(Call(f1_8, V.Undef, GetIdx(R1_94, 1D))).S(";9 ").V(Call(f1_8, V.Undef, GetIdx(R1_94, 0D))).S(" ").V(Call(f1_8, V.Undef, GetIdx(R1_94, 1D))).S(";0 ").V(Call(f1_8, V.Undef, GetIdx(R1_94, 0D))).S(" ").V(Call(f1_8, V.Undef, GetIdx(R1_94, 1D))).End())), ((V)("0;0.32;1")), ((V)(BEAT_9)))).V(Call(arm_19, V.Undef, q_70, R1_94, P1_95, ((V)(tk_93)), ((V)("fist")))).S("</g>").End()));
hold_99 = Call(arm_19, V.Undef, q_70, R2_96, P2_97, ((V)(tk_93)), ((V)("cup")));
use_100 = Fn((V _arrowThis146, int _argc139, V cp_145, V _a142, V _a143, V _a144, V[] _rest140) => {
return ((V)(string.Concat("<use href=\"#djC\"", (Truthy(cp_145) ? JsStrBuf.Begin().S(" clip-path=\"url(#").V(cp_145).S(")\"").End() : ""), "/>")));
}, 1, "", true);
nod_101 = ((V)((Truthy(neck_78) ? JsStrBuf.Begin().S("<g>").V(Call(atr_17, V.Undef, ((V)("translate")), ((V)("0 0;0 2;0 0")), ((V)("0;0.45;1")), ((V)(BEAT_9)), ((V)(" begin=\"-0.06s\"")))).S("<g>").V(Call(atr_17, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().S("0 50 ").V(Get(q_70, "nk")).S(";-3 50 ").V(Get(q_70, "nk")).S(";0 50 ").V(Get(q_70, "nk")).S(";3 50 ").V(Get(q_70, "nk")).S(";0 50 ").V(Get(q_70, "nk")).End())), ((V)("0;0.25;0.5;0.75;1")), ((V)((BEAT_9 * 4D))))).End() : "<g><g>")));
body_102 = Add(pump_98, (Truthy(neck_78) ? Call(use_100, V.Undef, ((V)("djBc"))) : Call(use_100, V.Undef, ((V)((Truthy(Get(q_70, "clip")) ? "djBc" : ""))))));
body_102 = ((V)(JsStrBuf.Begin().V(body_102).V(Add(nod_101, (Truthy(neck_78) ? Call(use_100, V.Undef, ((V)("djHc"))) : ((V)(""))))).S(mo_92.Str).S(hs_83.Str).S(sh_91.Str).V(hold_99).S("</g></g>").End()));
svg_103 = ((V)(JsStrBuf.Begin().S("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"-10 -10 120 120\" width=\"240\" height=\"240\"><defs>").S(defs_77.Str).S("</defs>").S("<g transform=\"translate(50 96)\"><g>").V(Call(atr_17, V.Undef, ((V)("scale")), ((V)("1 1;1.025 0.965;1 1")), ((V)("0;0.4;1")), ((V)(BEAT_9)))).S("<g>").V(Call(atr_17, V.Undef, ((V)("rotate")), ((V)("0;-2.5;0;2.5;0")), ((V)("0;0.25;0.5;0.75;1")), ((V)((BEAT_9 * 4D))))).S("<g transform=\"translate(-50 -96)\">").V(body_102).S("</g></g></g></g></svg>").End()));
return ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, svg_103)).End()));
return default;
}, 2, "build", false);
if (Truthy(Get(G("window"), "DJCrew"))) {
return default;
}
f1_8 = Fn((V _arrowThis154, int _argc147, V n_153, V _a150, V _a151, V _a152, V[] _rest148) => {
return Invoke(((V)((Round((ToNum(n_153) * 10D)) / 10D))), "toString");
}, 1, "", true);
BEAT_9 = 0.5;
A_10 = NewObj(8).Put("mittens", NewObj(12).Put("ey", ((V)(47D))).Put("ex", ((V)(12D))).Put("er", ((V)(5.4))).Put("cy", ((V)(46D))).Put("hw", ((V)(29.5))).Put("ht", ((V)(16D))).Put("my", ((V)(58D))).Put("nk", ((V)(65D))).Put("sy", ((V)(69D))).Put("sx", ((V)(23D))).Put("c", Arr(((V)("#ffd9a8")), ((V)("#eba45e")), ((V)("#a35a24")))).Put("bean", ((V)("#ff9fb0"))).V).Put("mochi", NewObj(10).Put("ey", ((V)(62D))).Put("ex", ((V)(10D))).Put("er", ((V)(4.6))).Put("cy", ((V)(58D))).Put("hw", ((V)(34.5))).Put("ht", ((V)(36D))).Put("my", ((V)(69D))).Put("sy", ((V)(71D))).Put("sx", ((V)(36D))).Put("c", Arr(((V)("#ffffff")), ((V)("#f3e9ef")), ((V)("#c4b0bd")))).V).Put("boba", NewObj(11).Put("ey", ((V)(50D))).Put("ex", ((V)(10D))).Put("er", ((V)(4.6))).Put("cy", ((V)(46D))).Put("hw", ((V)(26.5))).Put("ht", ((V)(28D))).Put("my", ((V)(56D))).Put("sy", ((V)(59D))).Put("sx", ((V)(25D))).Put("clip", Arr(((V)(40D)), ((V)(23.6)), ((V)(76.4)))).Put("c", Arr(((V)("#fff4e4")), ((V)("#efd2a8")), ((V)("#b48656")))).V).Put("pip", NewObj(12).Put("ey", ((V)(47D))).Put("ex", ((V)(9D))).Put("er", ((V)(4.8))).Put("cy", ((V)(44D))).Put("hw", ((V)(31.5))).Put("ht", ((V)(16D))).Put("my", V.Null).Put("sy", ((V)(57D))).Put("sx", ((V)(30D))).Put("clip", Arr(((V)(50D)), ((V)(18.6)), ((V)(81.4)))).Put("c", Arr(((V)("#7484ad")), ((V)("#3e4c78")), ((V)("#1f2740")))).Put("flip", ((V)(1D))).V).Put("kiwi", NewObj(10).Put("ey", ((V)(50D))).Put("ex", ((V)(10D))).Put("er", ((V)(4.6))).Put("cy", ((V)(46D))).Put("hw", ((V)(34.5))).Put("ht", ((V)(23D))).Put("my", ((V)(57D))).Put("sy", ((V)(62D))).Put("sx", ((V)(35D))).Put("c", Arr(((V)("#b08a5e")), ((V)("#8a6038")), ((V)("#553a1e")))).V).Put("floof", NewObj(11).Put("ey", ((V)(53D))).Put("ex", ((V)(9D))).Put("er", ((V)(4.6))).Put("cy", ((V)(49D))).Put("hw", ((V)(32D))).Put("ht", ((V)(24D))).Put("my", ((V)(60D))).Put("sy", ((V)(64D))).Put("sx", ((V)(30D))).Put("clip", Arr(((V)(57D)), ((V)(17.5)), ((V)(82.5)))).Put("c", Arr(((V)("#ffffff")), ((V)("#e3e6f4")), ((V)("#a3a9cb")))).V).Put("gumdrop", NewObj(12).Put("ey", ((V)(40D))).Put("ex", ((V)(9D))).Put("er", ((V)(4.5))).Put("cy", ((V)(39D))).Put("hw", ((V)(24.5))).Put("ht", ((V)(16D))).Put("my", ((V)(49.5))).Put("nk", ((V)(62D))).Put("sy", ((V)(60D))).Put("sx", ((V)(19D))).Put("clip", Arr(((V)(55D)), ((V)(28.6)), ((V)(71.4)))).Put("c", Arr(((V)("#ff9aa6")), ((V)("#f04a5e")), ((V)("#a81e34")))).V).Put("mallow", NewObj(10).Put("ey", ((V)(62D))).Put("ex", ((V)(10D))).Put("er", ((V)(4.6))).Put("cy", ((V)(58D))).Put("hw", ((V)(37.5))).Put("ht", ((V)(32D))).Put("my", ((V)(69D))).Put("sy", ((V)(71D))).Put("sx", ((V)(37D))).Put("c", Arr(((V)("#fff4f7")), ((V)("#f6d3de")), ((V)("#c4919f")))).V).V;
GEN_11 = NewObj(10).Put("ey", ((V)(48D))).Put("ex", ((V)(11D))).Put("er", ((V)(5D))).Put("cy", ((V)(46D))).Put("hw", ((V)(30D))).Put("ht", ((V)(18D))).Put("my", ((V)(57D))).Put("sy", ((V)(66D))).Put("sx", ((V)(28D))).Put("c", Arr(((V)("#ffffff")), ((V)("#dcdcdc")), ((V)("#9a9a9a")))).V;
RAW_12 = NewObj(0).V;
OUT_13 = NewObj(0).V;
SUBS_14 = New(G("Set"));
load_15 = Fn((V _arrowThis162, int _argc155, V k_161, V _a158, V _a159, V _a160, V[] _rest156) => {
if (!SEq(GetK(RAW_12, k_161), V.Undef)) {
return default;
}
SetK(RAW_12, k_161, V.Null);
Invoke(Invoke(Invoke(Call(G("fetch"), V.Undef, ((V)(JsStrBuf.Begin().V((Get(G("window"), "DJ_BASE") is var _t197 && Truthy(_t197) ? _t197 : ((V)("")))).S("export/tripo/").V(k_161).S("/").V(k_161).S("-front.svg").End()))), "then", Fn((V _arrowThis195, int _argc188, V r_194, V _a191, V _a192, V _a193, V[] _rest189) => {
return (Truthy(Get(r_194, "ok")) ? Invoke(r_194, "text") : Invoke(G("Promise"), "reject", Get(r_194, "status")));
}, 1, "", true)), "then", Fn((V _arrowThis177, int _argc170, V t_176, V _a173, V _a174, V _a175, V[] _rest171) => {
V a_178 = default;
V b_179 = default;
t_176 = Invoke(t_176, "replace", NewRegExp(RX0, "<metadata>[\\s\\S]*?<\\/metadata>", ""), ((V)("")));
a_178 = Add(Invoke(t_176, "indexOf", ((V)(">")), Invoke(t_176, "indexOf", ((V)("<svg")))), ((V)(1D)));
b_179 = Invoke(t_176, "lastIndexOf", ((V)("</svg>")));
SetK(RAW_12, k_161, Invoke(t_176, "slice", a_178, b_179));
Invoke(SUBS_14, "forEach", Fn((V _arrowThis187, int _argc180, V fn_186, V _a183, V _a184, V _a185, V[] _rest181) => {
return Call(fn_186, V.Undef, k_161);
}, 1, "", true));
return default;
}, 1, "", true)), "catch", Fn((V _arrowThis169, int _argc163, V _a165, V _a166, V _a167, V _a168, V[] _rest164) => {
SetK(RAW_12, k_161, ((V)("")));
return default;
}, 0, "", true));
return default;
}, 1, "", true);
spl_16 = Fn((V _arrowThis208, int _argc198, V vals_204, V kt_205, V d_206, V extra_207, V[] _rest199) => {
return ((V)(JsStrBuf.Begin().S(" values=\"").V(vals_204).S("\" keyTimes=\"").V(kt_205).S("\" calcMode=\"spline\" keySplines=\"").V(Invoke(Invoke(Invoke(Invoke(kt_205, "split", ((V)(";"))), "slice", ((V)(1D))), "map", Fn((V _arrowThis215, int _argc209, V _a211, V _a212, V _a213, V _a214, V[] _rest210) => {
return ((V)("0.45 0 0.55 1"));
}, 0, "", true)), "join", ((V)(";")))).S("\" dur=\"").V(d_206).S("s\" repeatCount=\"indefinite\"").V((extra_207 is var _t216 && Truthy(_t216) ? _t216 : ((V)("")))).End()));
}, 4, "", true);
atr_17 = Fn((V _arrowThis228, int _argc217, V type_223, V vals_224, V kt_225, V d_226, V[] _rest218) => {
V extra_227 = default;
extra_227 = (_argc217 > 4 ? _rest218[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"").V(type_223).S("\"").V(Call(spl_16, V.Undef, vals_224, kt_225, d_226, extra_227)).S("/>").End()));
}, 5, "", true);
rects_18 = Fn((V _arrowThis238, int _argc229, V q_235, V yA_236, V yB_237, V _a234, V[] _rest230) => {
V r_239 = default;
V cy_240 = default;
V x0_241 = default;
V x1_242 = default;
r_239 = Fn((V _arrowThis253, int _argc243, V x_249, V y_250, V w_251, V h_252, V[] _rest244) => {
return ((V)((GtN(h_252, 0D) ? JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_8, V.Undef, x_249)).S("\" y=\"").V(Call(f1_8, V.Undef, y_250)).S("\" width=\"").V(Call(f1_8, V.Undef, w_251)).S("\" height=\"").V(Call(f1_8, V.Undef, h_252)).S("\"/>").End() : "")));
}, 4, "", true);
if (!(Truthy(Get(q_235, "clip")))) {
return Call(r_239, V.Undef, ((V)((-10D))), yA_236, ((V)(120D)), ((V)((ToNum(yB_237) - ToNum(yA_236)))));
}
{ V _t254 = Get(q_235, "clip");
{ V _t255 = ListOf(_t254);
{ V _t256 = GetIdx(_t255, 0D);
cy_240 = _t256; }
{ V _t257 = GetIdx(_t255, 1D);
x0_241 = _t257; }
{ V _t258 = GetIdx(_t255, 2D);
x1_242 = _t258; }
} }
return Add(Call(r_239, V.Undef, ((V)((-10D))), yA_236, ((V)(120D)), ((V)((Min(ToNum(yB_237), ToNum(cy_240)) - ToNum(yA_236))))), Call(r_239, V.Undef, x0_241, ((V)(Max(ToNum(yA_236), ToNum(cy_240)))), ((V)((ToNum(x1_242) - ToNum(x0_241)))), ((V)((ToNum(yB_237) - Max(ToNum(yA_236), ToNum(cy_240)))))));
return default;
}, 3, "", true);
Set(G("window"), "DJCrew", NewObj(3).Put("get", Fn((V _self259, int _argc260, V k_266, V _a263, V _a264, V _a265, V[] _rest261) => {
V raw_267 = default;
if (_self259.IsNullish) _self259 = GlobalV;
if (Truthy(GetK(OUT_13, k_266))) {
return GetK(OUT_13, k_266);
}
Call(load_15, V.Undef, k_266);
raw_267 = GetK(RAW_12, k_266);
if (!(Truthy(raw_267))) {
return V.Null;
}
try {
SetK(OUT_13, k_266, Call(build_20, V.Undef, k_266, raw_267));
} catch (System.Exception _ex268) {
V e_269 = default;
e_269 = Caught(_ex268);
Invoke(G("console"), "warn", ((V)("dj crew")), k_266, e_269);
SetK(OUT_13, k_266, V.Null);
}
return GetK(OUT_13, k_266);
return default;
}, 1, "get", false)).Put("sub", Fn((V _self270, int _argc271, V fn_277, V _a274, V _a275, V _a276, V[] _rest272) => {
if (_self270.IsNullish) _self270 = GlobalV;
Invoke(SUBS_14, "add", fn_277);
return Fn((V _arrowThis284, int _argc278, V _a280, V _a281, V _a282, V _a283, V[] _rest279) => {
return Invoke(SUBS_14, "delete", fn_277);
}, 0, "", true);
return default;
}, 1, "sub", false)).Put("A", A_10).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
