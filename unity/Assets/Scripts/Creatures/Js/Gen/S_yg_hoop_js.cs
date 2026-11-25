// yg-hoop.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_yg_hoop_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V go_8 = default;
if (_self1.IsNullish) _self1 = GlobalV;
go_8 = Fn((V _arrowThis15, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_16 = default;
V S_17 = default;
V cl_18 = default;
V lerp_19 = default;
V r2_20 = default;
V SFX_21 = default;
V ICON_22 = default;
YG_16 = Get(G("window"), "YardGames");
if (((!(Truthy(YG_16)) || !(Truthy(Get(YG_16, "add")))) || !(Truthy(Get(YG_16, "cam"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t23 = YG_16;
if (_t23.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t23));
{ V _t24 = Get(_t23, "S");
S_17 = _t24; }
{ V _t25 = Get(_t23, "cl");
cl_18 = _t25; }
{ V _t26 = Get(_t23, "lerp");
lerp_19 = _t26; }
{ V _t27 = Get(_t23, "r2");
r2_20 = _t27; }
{ V _t28 = Get(_t23, "SFX");
SFX_21 = _t28; } }
ICON_22 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#cfeaff\"/><rect y=\"58\" width=\"120\" height=\"26\" fill=\"#9fdc6e\"/><path d=\"M14 84L36 58H84L106 84Z\" fill=\"#d9d4cc\"/>", "<rect x=\"57\" y=\"22\" width=\"5\" height=\"40\" rx=\"2\" fill=\"#3a3a44\"/><rect x=\"38\" y=\"8\" width=\"44\" height=\"28\" rx=\"3\" fill=\"#fff\" stroke=\"#e8483c\" stroke-width=\"2.5\"/><rect x=\"51\" y=\"18\" width=\"18\" height=\"12\" fill=\"none\" stroke=\"#e8483c\" stroke-width=\"2\"/>", "<ellipse cx=\"60\" cy=\"34\" rx=\"10\" ry=\"3\" fill=\"none\" stroke=\"#f07a2e\" stroke-width=\"2.4\"/><path d=\"M51 35L54 46H66L69 35M55 35L57 46M65 35L63 46M60 35V46\" stroke=\"#fff\" stroke-width=\"1.2\" fill=\"none\"/>", "<circle cx=\"34\" cy=\"40\" r=\"9\" fill=\"#f07a2e\"/><path d=\"M25 40H43M34 31V49M27.5 33.5Q34 40 27.5 46.5M40.5 33.5Q34 40 40.5 46.5\" stroke=\"#7a3410\" stroke-width=\"1.2\" fill=\"none\"/></svg>")));
Invoke(YG_16, "add", NewObj(12).Put("id", ((V)("hoop"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Hoop Shot"))).Put("item", ((V)("Basketball Hoop"))).Put("color", ((V)("#ff9a4a"))).Put("icon", ICON_22).Put("dur", ((V)(45D))).Put("stars", Arr(((V)(30D)), ((V)(60D)), ((V)(100D)))).Put("coinK", ((V)(0.35))).Put("hint", ((V)("Pull back to aim \u00b7 green = it goes in \u00b7 let go to throw"))).Put("how", Arr(((V)("Pull back from anywhere, like a slingshot. Farther = harder; to the side = aim the other way.")), ((V)("GREEN path = it goes in, RED = it misses. Let go to throw!")), ((V)("Swish 3, rim or bank 2. Every basket adds 10 seconds! Three in a row = on fire. At 20 points the hoop starts to move.")))).Put("make", Fn((V _self29, int _argc30, V ctx_36, V _a33, V _a34, V _a35, V[] _rest31) => {
V bg_37 = default;
V fg_38 = default;
V W_39 = default;
V H_40 = default;
V P_41 = default;
double G_42 = 0;
double BR_43 = 0;
double RR_44 = 0;
double RT_45 = 0;
double RY_46 = 0;
double RZ_47 = 0;
double BZ_48 = 0;
double PZ_49 = 0;
double GZ_50 = 0;
double DW_51 = 0;
double FZ_52 = 0;
double PX_53 = 0;
double TH_54 = 0;
V HOLD_55 = default;
V REL_56 = default;
double THROW_57 = 0;
double PULL_58 = 0;
double DT_59 = 0;
double LIFE_60 = 0;
V SM_61 = default;
V eo_62 = default;
V ei_63 = default;
double L0_64 = 0;
double PH0_65 = 0;
V vMid_66 = default;
V vOf_67 = default;
double AMP_68 = 0;
double W1_69 = 0;
double W2_70 = 0;
V M_71 = default;
V hxAt_72 = default;
V court_73 = default;
V drawCourt_74 = default;
V shG_75 = default;
V hoopG_76 = default;
V backG_77 = default;
V slotB_78 = default;
V frontG_79 = default;
V pathG_80 = default;
V slotH_81 = default;
V bandG_82 = default;
V hx_83 = default;
double netSw_84 = 0;
V netAt_85 = default;
V lastHx_86 = default;
V drawHoop_87 = default;
V stepB_88 = default;
V sim_89 = default;
V posAt_90 = default;
V me_91 = default;
V f0_92 = default;
V meSh_93 = default;
V balls_94 = default;
V held_95 = default;
V nextAt_96 = default;
double streak_97 = 0;
double fire_98 = 0;
V cheerT_99 = default;
V missT_100 = default;
double made_101 = 0;
V tNow_102 = default;
V aim_103 = default;
V thr_104 = default;
V lastThrow_105 = default;
V clangAt_106 = default;
V mkBall_107 = default;
V drawBall_108 = default;
V pullOf_109 = default;
V drawPath_110 = default;
V release_111 = default;
V launch_112 = default;
V basket_113 = default;
V missed_114 = default;
V schedule_115 = default;
V poseMe_116 = default;
V pawsAt_117 = default;
V api_118 = default;
if (_self29.IsNullish) _self29 = GlobalV;
drawCourt_74 = Fn((V _self119, int _argc120, V sv_126, V _a123, V _a124, V _a125, V[] _rest121) => {
V q_127 = default;
V ln_128 = default;
V wp_129 = default;
V wr_130 = default;
V k0_131 = default;
V yAt_132 = default;
V yF_133 = default;
V yT_134 = default;
V pa_135 = default;
if (_self119.IsNullish) _self119 = GlobalV;
q_127 = Fn((V _arrowThis145, int _argc136, V pts_142, V a_143, V p_144, V _a141, V[] _rest137) => {
return Call(S_17, V.Undef, ((V)("path")), Object_assign(NewObj(1).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_142, "map", Fn((V _arrowThis159, int _argc146, V _a148, V _a149, V _a150, V _a151, V[] _rest147) => {
V s_160 = default;
V x_154 = default;
V z_156 = default;
V y_158 = default;
{ V _t152 = ListOf(_a148);
{ V _t153 = GetIdx(_t152, 0D);
x_154 = _t153; }
{ V _t155 = GetIdx(_t152, 1D);
z_156 = _t155; }
{ V _t157 = GetIdx(_t152, 2D);
y_158 = _t157; }
}
s_160 = Call(P_41, V.Undef, x_154, (y_158 is var _t161 && Truthy(_t161) ? _t161 : ((V)(0D))), z_156);
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_160, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_160, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).V, a_143), (p_144 is var _t162 && Truthy(_t162) ? _t162 : sv_126));
}, 3, "", true);
ln_128 = Fn((V _arrowThis172, int _argc163, V pts_169, V a_170, V p_171, V _a168, V[] _rest164) => {
return Call(S_17, V.Undef, ((V)("path")), Object_assign(NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_169, "map", Fn((V _arrowThis186, int _argc173, V _a175, V _a176, V _a177, V _a178, V[] _rest174) => {
V s_187 = default;
V x_181 = default;
V z_183 = default;
V y_185 = default;
{ V _t179 = ListOf(_a175);
{ V _t180 = GetIdx(_t179, 0D);
x_181 = _t180; }
{ V _t182 = GetIdx(_t179, 1D);
z_183 = _t182; }
{ V _t184 = GetIdx(_t179, 2D);
y_185 = _t184; }
}
s_187 = Call(P_41, V.Undef, x_181, (y_185 is var _t188 && Truthy(_t188) ? _t188 : ((V)(0D))), z_183);
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_187, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_187, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()))).Put("fill", ((V)("none"))).V, a_170), (p_171 is var _t189 && Truthy(_t189) ? _t189 : sv_126));
}, 3, "", true);
wp_129 = Fn((V _arrowThis198, int _argc190, V x_196, V y_197, V _a194, V _a195, V[] _rest191) => {
return Call(P_41, V.Undef, x_196, y_197, ((V)(GZ_50)));
}, 2, "", true);
wr_130 = Fn((V _arrowThis211, int _argc199, V x0_205, V y0_206, V x1_207, V y1_208, V[] _rest200) => {
V A_212 = default;
V B_213 = default;
V a_209 = default;
V p_210 = default;
a_209 = (_argc199 > 4 ? _rest200[0] : V.Undef);
p_210 = (_argc199 > 5 ? _rest200[1] : V.Undef);
A_212 = Call(wp_129, V.Undef, x0_205, y1_208);
B_213 = Call(wp_129, V.Undef, x1_207, y0_206);
return Call(S_17, V.Undef, ((V)("rect")), Object_assign(NewObj(4).Put("x", Call(r2_20, V.Undef, GetIdx(A_212, 0D))).Put("y", Call(r2_20, V.Undef, GetIdx(A_212, 1D))).Put("width", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(B_213, 0D)) - ToNum(GetIdx(A_212, 0D))))))).Put("height", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(B_213, 1D)) - ToNum(GetIdx(A_212, 1D))))))).V, a_209), (p_210 is var _t214 && Truthy(_t214) ? _t214 : sv_126));
return default;
}, 6, "", true);
k0_131 = GetIdx(Call(P_41, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(GZ_50))), 2D);
Set(Call(S_17, V.Undef, ((V)("defs")), NewObj(0).V, sv_126), "innerHTML", ((V)(JsStrBuf.Begin().S("<linearGradient id=\"hcSky\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#6fbaf2\"/><stop offset=\"0.6\" stop-color=\"#b6e0fb\"/><stop offset=\"1\" stop-color=\"#e8f6ff\"/></linearGradient>").S("<radialGradient id=\"hcSun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fffbe6\" stop-opacity=\"0.95\"/><stop offset=\"0.35\" stop-color=\"#fff2b8\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#ffe9a0\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"hcCon\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#e9e4dc\"/><stop offset=\"1\" stop-color=\"#cdc5b8\"/></linearGradient>").S("<linearGradient id=\"hcLawn\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#8fcf62\"/><stop offset=\"1\" stop-color=\"#4f9a3c\"/></linearGradient>").S("<linearGradient id=\"hcWall\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#f6eedf\"/><stop offset=\"1\" stop-color=\"#e9dcc6\"/></linearGradient>").S("<linearGradient id=\"hcDoor\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fdfaf3\"/><stop offset=\"1\" stop-color=\"#e8e0d0\"/></linearGradient>").S("<linearGradient id=\"hcRoof\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#9a4e3e\"/><stop offset=\"1\" stop-color=\"#c0664e\"/></linearGradient>").S("<linearGradient id=\"hcGlass\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#a9d6f2\"/><stop offset=\"0.5\" stop-color=\"#6aa8d8\"/><stop offset=\"1\" stop-color=\"#3f7fb8\"/></linearGradient>").S("<linearGradient id=\"hcAO\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#3a2a3a\" stop-opacity=\"0.32\"/><stop offset=\"1\" stop-color=\"#3a2a3a\" stop-opacity=\"0\"/></linearGradient>").S("<radialGradient id=\"hcBall\" cx=\"35%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#ffb070\"/><stop offset=\"0.55\" stop-color=\"#f07a2e\"/><stop offset=\"1\" stop-color=\"#b44a14\"/></radialGradient>").S("<filter id=\"hcGrain\" x=\"0\" y=\"0\" width=\"100%\" height=\"100%\"><feTurbulence type=\"fractalNoise\" baseFrequency=\"0.85\" numOctaves=\"3\" seed=\"11\"/><feColorMatrix values=\"0 0 0 0 0.35  0 0 0 0 0.32  0 0 0 0 0.3  0 0 0 0.55 -0.12\"/><feComposite in2=\"SourceGraphic\" operator=\"in\"/></filter>").S("<filter id=\"hcBlur\" x=\"-20%\" y=\"-20%\" width=\"140%\" height=\"140%\"><feGaussianBlur stdDeviation=\"2\"/></filter>").S("<clipPath id=\"hcDrive\"><path d=\"M").V(Invoke(Invoke(Arr(Arr(((V)((-DW_51))), ((V)((-1D)))), Arr(((V)(DW_51)), ((V)((-1D)))), Arr(((V)(DW_51)), ((V)(GZ_50))), Arr(((V)((-DW_51))), ((V)(GZ_50)))), "map", Fn((V _arrowThis226, int _argc215, V _a217, V _a218, V _a219, V _a220, V[] _rest216) => {
V s_227 = default;
V x_223 = default;
V z_225 = default;
{ V _t221 = ListOf(_a217);
{ V _t222 = GetIdx(_t221, 0D);
x_223 = _t222; }
{ V _t224 = GetIdx(_t221, 1D);
z_225 = _t224; }
}
s_227 = Call(P_41, V.Undef, x_223, ((V)(0D)), z_225);
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_227, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_227, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z\"/></clipPath>").End())));
yAt_132 = Fn((V _arrowThis235, int _argc228, V z_234, V _a231, V _a232, V _a233, V[] _rest229) => {
return GetIdx(Call(P_41, V.Undef, ((V)(0D)), ((V)(0D)), z_234), 1D);
}, 1, "", true);
yF_133 = Call(yAt_132, V.Undef, ((V)(26D)));
yT_134 = Call(yAt_132, V.Undef, ((V)(14D)));
Call(S_17, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_39, ((V)(40D)))).Put("height", Add(yT_134, ((V)(40D)))).Put("fill", ((V)("url(#hcSky)"))).V, sv_126);
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", ((V)(90D))).Put("cy", ((V)(40D))).Put("r", ((V)(130D))).Put("fill", ((V)("url(#hcSun)"))).V, sv_126);
Invoke(Arr(Arr(((V)(110D)), ((V)(52D)), ((V)(0.8))), Arr(((V)(300D)), ((V)(34D)), ((V)(0.6))), Arr(((V)(560D)), ((V)(50D)), ((V)(0.75))), Arr(((V)(700D)), ((V)(24D)), ((V)(0.5))), Arr(((V)(450D)), ((V)(92D)), ((V)(0.42))), Arr(((V)(190D)), ((V)(104D)), ((V)(0.4)))), "forEach", Fn((V _arrowThis249, int _argc236, V _a238, V _a239, V _a240, V _a241, V[] _rest237) => {
V g_250 = default;
V x_244 = default;
V y_246 = default;
V k_248 = default;
{ V _t242 = ListOf(_a238);
{ V _t243 = GetIdx(_t242, 0D);
x_244 = _t243; }
{ V _t245 = GetIdx(_t242, 1D);
y_246 = _t245; }
{ V _t247 = GetIdx(_t242, 2D);
k_248 = _t247; }
}
g_250 = Call(S_17, V.Undef, ((V)("g")), NewObj(2).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(x_244).S(" ").V(y_246).S(") scale(").V(k_248).S(")").End()))).Put("opacity", ((V)(0.9))).V, sv_126);
Invoke(Arr(Arr(((V)((-28D))), ((V)(6D)), ((V)(17D))), Arr(((V)((-6D))), ((V)((-6D))), ((V)(24D))), Arr(((V)(20D)), ((V)(0D)), ((V)(20D))), Arr(((V)(38D)), ((V)(8D)), ((V)(13D))), Arr(((V)(4D)), ((V)(10D)), ((V)(18D))), Arr(((V)((-18D))), ((V)(12D)), ((V)(14D)))), "forEach", Fn((V _arrowThis264, int _argc251, V _a253, V _a254, V _a255, V _a256, V[] _rest252) => {
V a_259 = default;
V b_261 = default;
V r_263 = default;
{ V _t257 = ListOf(_a253);
{ V _t258 = GetIdx(_t257, 0D);
a_259 = _t258; }
{ V _t260 = GetIdx(_t257, 1D);
b_261 = _t260; }
{ V _t262 = GetIdx(_t257, 2D);
r_263 = _t262; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", a_259).Put("cy", b_261).Put("r", r_263).Put("fill", ((V)("#ffffff"))).V, g_250);
}, 1, "", true));
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)("M-44 18H52"))).Put("stroke", ((V)("#dcefff"))).Put("stroke-width", ((V)(6D))).Put("stroke-linecap", ((V)("round"))).V, g_250);
return default;
}, 1, "", true));
{
JsStrBuf d_265 = null;
d_265 = new JsStrBuf(JsStrBuf.Begin().S("M-20 ").V(Call(r2_20, V.Undef, Add(yF_133, ((V)(6D))))).End());
{
double x_266 = 0;
x_266 = (-20D);
while (true) {
if (!(Le(((V)(x_266)), Add(W_39, ((V)(20D)))))) break;
d_265.S("Q").N((x_266 + 7D)).S(" ").V(Call(r2_20, V.Undef, ((V)(((ToNum(yF_133) - 22D) - ((x_266 * 37D) % 23D)))))).S(" ").N((x_266 + 14D)).S(" ").V(Call(r2_20, V.Undef, ((V)(((ToNum(yF_133) - 12D) - ((x_266 * 53D) % 11D))))));
x_266 = (x_266 + 14D);
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S(d_265.Str).S("V").V(Call(r2_20, V.Undef, Add(yT_134, ((V)(10D))))).S("H-20Z").End()))).Put("fill", ((V)("#8fbf9a"))).Put("opacity", ((V)(0.75))).V, sv_126);
}
Invoke(Arr(Arr(((V)(40D)), ((V)(1D))), Arr(((V)(150D)), ((V)(0.8))), Arr(((V)(640D)), ((V)(1.1))), Arr(((V)(745D)), ((V)(0.85)))), "forEach", Fn((V _arrowThis279, int _argc268, V _a270, V _a271, V _a272, V _a273, V[] _rest269) => {
V y_280 = default;
V x_276 = default;
V k_278 = default;
{ V _t274 = ListOf(_a270);
{ V _t275 = GetIdx(_t274, 0D);
x_276 = _t275; }
{ V _t277 = GetIdx(_t274, 1D);
k_278 = _t277; }
}
y_280 = Add(yF_133, ((V)(4D)));
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_276) - (34D * ToNum(k_278)))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(y_280) - (22D * ToNum(k_278))))))).S("L").V(x_276).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(y_280) - (44D * ToNum(k_278))))))).S("L").V(Add(x_276, ((V)((34D * ToNum(k_278)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(y_280) - (22D * ToNum(k_278))))))).S("V").V(Call(r2_20, V.Undef, y_280)).S("H").N((ToNum(x_276) - (34D * ToNum(k_278)))).S("Z").End()))).Put("fill", ((V)("#c9a596"))).Put("opacity", ((V)(0.8))).V, sv_126);
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_276) - (40D * ToNum(k_278)))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(y_280) - (18D * ToNum(k_278))))))).S("L").V(x_276).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(y_280) - (48D * ToNum(k_278))))))).S("L").V(Add(x_276, ((V)((40D * ToNum(k_278)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(y_280) - (18D * ToNum(k_278))))))).End()))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#a87a6a"))).Put("stroke-width", ((V)(3D))).Put("opacity", ((V)(0.8))).V, sv_126);
return default;
}, 1, "", true));
{
JsStrBuf d_281 = null;
d_281 = new JsStrBuf(JsStrBuf.Begin().S("M-20 ").V(Call(r2_20, V.Undef, Add(yT_134, ((V)(8D))))).End());
{
double x_282 = 0;
x_282 = (-20D);
while (true) {
if (!(Le(((V)(x_282)), Add(W_39, ((V)(20D)))))) break;
d_281.S("Q").N((x_282 + 9D)).S(" ").V(Call(r2_20, V.Undef, ((V)(((ToNum(yT_134) - 18D) - ((x_282 * 29D) % 19D)))))).S(" ").N((x_282 + 18D)).S(" ").V(Call(r2_20, V.Undef, ((V)(((ToNum(yT_134) - 6D) - ((x_282 * 41D) % 9D))))));
x_282 = (x_282 + 18D);
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S(d_281.Str).S("V").V(Call(r2_20, V.Undef, Add(yT_134, ((V)(26D))))).S("H-20Z").End()))).Put("fill", ((V)("#5f9e5a"))).V, sv_126);
}
Call(S_17, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", Call(r2_20, V.Undef, yT_134)).Put("width", Add(W_39, ((V)(40D)))).Put("height", H_40).Put("fill", ((V)("url(#hcLawn)"))).V, sv_126);
{
double i_284 = 0;
i_284 = (-18D);
while (true) {
if (!((i_284 <= 18D))) break;
double x0_286 = 0;
x0_286 = (i_284 * 0.9);
Call(q_127, V.Undef, Arr(Arr(((V)(x0_286)), ((V)((-1D)))), Arr(((V)((x0_286 + 0.45))), ((V)((-1D)))), Arr(((V)((x0_286 + 0.45))), ((V)(GZ_50))), Arr(((V)(x0_286)), ((V)(GZ_50)))), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.06))).V);
i_284++;
}
}
Invoke(Arr(Arr(((V)((-11.5))), ((V)((GZ_50 + 2.2))), ((V)(1.15))), Arr(((V)((-7.8))), ((V)((GZ_50 + 3.4))), ((V)(0.9))), Arr(((V)(7.2)), ((V)((GZ_50 + 2.6))), ((V)(1.2))), Arr(((V)(11.8)), ((V)((GZ_50 + 1.6))), ((V)(0.95)))), "forEach", Fn((V _arrowThis300, int _argc287, V _a289, V _a290, V _a291, V _a292, V[] _rest288) => {
V p_301 = default;
double k_302 = 0;
V x_295 = default;
V z_297 = default;
V kk_299 = default;
{ V _t293 = ListOf(_a289);
{ V _t294 = GetIdx(_t293, 0D);
x_295 = _t294; }
{ V _t296 = GetIdx(_t293, 1D);
z_297 = _t296; }
{ V _t298 = GetIdx(_t293, 2D);
kk_299 = _t298; }
}
p_301 = Call(P_41, V.Undef, x_295, ((V)(0D)), z_297);
k_302 = (ToNum(GetIdx(p_301, 2D)) * ToNum(kk_299));
Call(S_17, V.Undef, ((V)("rect")), NewObj(5).Put("x", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_301, 0D)) - (0.12 * k_302)))))).Put("y", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_301, 1D)) - (2.2 * k_302)))))).Put("width", Call(r2_20, V.Undef, ((V)((0.24 * k_302))))).Put("height", Call(r2_20, V.Undef, ((V)((2.2 * k_302))))).Put("fill", ((V)("#7a5034"))).V, sv_126);
Invoke(Arr(Arr(((V)((-0.7))), ((V)((-2.4))), ((V)(0.75)), ((V)("#4f9a3e"))), Arr(((V)(0.6)), ((V)((-2.5))), ((V)(0.8)), ((V)("#4f9a3e"))), Arr(((V)(0D)), ((V)((-3.2))), ((V)(0.9)), ((V)("#5aa84a"))), Arr(((V)((-0.3))), ((V)((-3.7))), ((V)(0.55)), ((V)("#66b456")))), "forEach", Fn((V _arrowThis318, int _argc303, V _a305, V _a306, V _a307, V _a308, V[] _rest304) => {
V a_311 = default;
V b_313 = default;
V r_315 = default;
V c_317 = default;
{ V _t309 = ListOf(_a305);
{ V _t310 = GetIdx(_t309, 0D);
a_311 = _t310; }
{ V _t312 = GetIdx(_t309, 1D);
b_313 = _t312; }
{ V _t314 = GetIdx(_t309, 2D);
r_315 = _t314; }
{ V _t316 = GetIdx(_t309, 3D);
c_317 = _t316; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(p_301, 0D), ((V)((ToNum(a_311) * k_302)))))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(p_301, 1D), ((V)((ToNum(b_313) * k_302)))))).Put("r", Call(r2_20, V.Undef, ((V)((ToNum(r_315) * k_302))))).Put("fill", c_317).V, sv_126);
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-17D))), ((V)((-7D)))), Arr(((V)(3.5)), ((V)(17D)))), "forEach", Fn((V _arrowThis330, int _argc319, V _a321, V _a322, V _a323, V _a324, V[] _rest320) => {
V x0_327 = default;
V x1_329 = default;
{ V _t325 = ListOf(_a321);
{ V _t326 = GetIdx(_t325, 0D);
x0_327 = _t326; }
{ V _t328 = GetIdx(_t325, 1D);
x1_329 = _t328; }
}
Call(q_127, V.Undef, Arr(Arr(x0_327, ((V)((GZ_50 + 0.4))), ((V)(0D))), Arr(x1_329, ((V)((GZ_50 + 0.4))), ((V)(0D))), Arr(x1_329, ((V)((GZ_50 + 0.4))), ((V)(1.7))), Arr(x0_327, ((V)((GZ_50 + 0.4))), ((V)(1.7)))), NewObj(1).Put("fill", ((V)("#e9d8bd"))).V);
{
V x_331 = default;
x_331 = x0_327;
while (true) {
if (!(Le(x_331, x1_329))) break;
Call(ln_128, V.Undef, Arr(Arr(x_331, ((V)((GZ_50 + 0.4))), ((V)(0D))), Arr(x_331, ((V)((GZ_50 + 0.4))), ((V)(1.72)))), NewObj(2).Put("stroke", ((V)("#cdb796"))).Put("stroke-width", ((V)(1D))).V);
x_331 = Add(x_331, ((V)(0.36)));
}
}
Call(ln_128, V.Undef, Arr(Arr(x0_327, ((V)((GZ_50 + 0.4))), ((V)(1.3))), Arr(x1_329, ((V)((GZ_50 + 0.4))), ((V)(1.3)))), NewObj(2).Put("stroke", ((V)("#cdb796"))).Put("stroke-width", ((V)(1.6))).V);
Call(ln_128, V.Undef, Arr(Arr(x0_327, ((V)((GZ_50 + 0.4))), ((V)(1.7))), Arr(x1_329, ((V)((GZ_50 + 0.4))), ((V)(1.7)))), NewObj(2).Put("stroke", ((V)("#fff4e0"))).Put("stroke-width", ((V)(2D))).V);
return default;
}, 1, "", true));
Call(q_127, V.Undef, Arr(Arr(((V)((-7D))), ((V)(GZ_50)), ((V)(0D))), Arr(((V)(3.5)), ((V)(GZ_50)), ((V)(0D))), Arr(((V)(3.5)), ((V)(GZ_50)), ((V)(2.75))), Arr(((V)((-7D))), ((V)(GZ_50)), ((V)(2.75)))), NewObj(1).Put("fill", ((V)("url(#hcWall)"))).V);
{
V g_333 = default;
g_333 = Call(S_17, V.Undef, ((V)("g")), NewObj(3).Put("stroke", ((V)("#dccdb3"))).Put("stroke-width", ((V)(0.8))).Put("opacity", ((V)(0.9))).V, sv_126);
{
double y_334 = 0;
y_334 = 0.25;
while (true) {
if (!((y_334 < 2.7))) break;
Call(ln_128, V.Undef, Arr(Arr(((V)((-7D))), ((V)(GZ_50)), ((V)(y_334))), Arr(((V)(3.5)), ((V)(GZ_50)), ((V)(y_334)))), NewObj(0).V, g_333);
y_334 = (y_334 + 0.24);
}
}
}
Call(q_127, V.Undef, Arr(Arr(((V)((-7D))), ((V)(GZ_50)), ((V)(0D))), Arr(((V)(3.5)), ((V)(GZ_50)), ((V)(0D))), Arr(((V)(3.5)), ((V)(GZ_50)), ((V)(0.16))), Arr(((V)((-7D))), ((V)(GZ_50)), ((V)(0.16)))), NewObj(1).Put("fill", ((V)("#bdb3a6"))).V);
Call(q_127, V.Undef, Arr(Arr(((V)((-7.2))), ((V)(GZ_50)), ((V)(2.72))), Arr(((V)(3.7)), ((V)(GZ_50)), ((V)(2.72))), Arr(((V)(3.4)), ((V)(GZ_50)), ((V)(3.5))), Arr(((V)((-6.9))), ((V)(GZ_50)), ((V)(3.5)))), NewObj(1).Put("fill", ((V)("url(#hcRoof)"))).V);
{
V g_336 = default;
g_336 = Call(S_17, V.Undef, ((V)("g")), NewObj(3).Put("stroke", ((V)("#8a4434"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.55))).V, sv_126);
{
double y_337 = 0;
y_337 = 2.9;
while (true) {
if (!((y_337 < 3.5))) break;
Call(ln_128, V.Undef, Arr(Arr(((V)((-7.1))), ((V)(GZ_50)), ((V)(y_337))), Arr(((V)(3.6)), ((V)(GZ_50)), ((V)(y_337)))), NewObj(0).V, g_336);
y_337 = (y_337 + 0.17);
}
}
}
Call(q_127, V.Undef, Arr(Arr(((V)((-1.9))), ((V)(GZ_50)), ((V)(2.7))), Arr(((V)(1.9)), ((V)(GZ_50)), ((V)(2.7))), Arr(((V)(0D)), ((V)(GZ_50)), ((V)(4.05)))), NewObj(3).Put("fill", ((V)("#f6eedf"))).Put("stroke", ((V)("#dccdb3"))).Put("stroke-width", ((V)(1D))).V);
{
V a_339 = default;
V b_340 = default;
V c_341 = default;
a_339 = Call(wp_129, V.Undef, ((V)((-2.05))), ((V)(2.62)));
b_340 = Call(wp_129, V.Undef, ((V)(0D)), ((V)(4.2)));
c_341 = Call(wp_129, V.Undef, ((V)(2.05)), ((V)(2.62)));
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(a_339, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_339, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(b_340, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(b_340, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(c_341, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(c_341, 1D))).End()))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#9a4e3e"))).Put("stroke-width", ((V)(4.5))).Put("stroke-linejoin", ((V)("round"))).V, sv_126);
}
{
V v_342 = default;
v_342 = Call(wp_129, V.Undef, ((V)(0D)), ((V)(3.35)));
Call(S_17, V.Undef, ((V)("circle")), NewObj(6).Put("cx", Call(r2_20, V.Undef, GetIdx(v_342, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(v_342, 1D))).Put("r", Call(r2_20, V.Undef, ((V)((0.22 * ToNum(k0_131)))))).Put("fill", ((V)("#e4d6bf"))).Put("stroke", ((V)("#c9b89c"))).Put("stroke-width", ((V)(1D))).V, sv_126);
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(v_342, 0D)) - (0.16 * ToNum(k0_131))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(v_342, 1D))).S("H").V(Call(r2_20, V.Undef, Add(GetIdx(v_342, 0D), ((V)((0.16 * ToNum(k0_131))))))).S("M").V(Call(r2_20, V.Undef, GetIdx(v_342, 0D))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(v_342, 1D)) - (0.16 * ToNum(k0_131))))))).S("V").V(Call(r2_20, V.Undef, Add(GetIdx(v_342, 1D), ((V)((0.16 * ToNum(k0_131))))))).End()))).Put("stroke", ((V)("#c9b89c"))).Put("stroke-width", ((V)(1D))).V, sv_126);
}
Call(q_127, V.Undef, Arr(Arr(((V)((-7.2))), ((V)(GZ_50)), ((V)(2.68))), Arr(((V)(3.7)), ((V)(GZ_50)), ((V)(2.68))), Arr(((V)(3.7)), ((V)(GZ_50)), ((V)(2.76))), Arr(((V)((-7.2))), ((V)(GZ_50)), ((V)(2.76)))), NewObj(1).Put("fill", ((V)("#e7e2d8"))).V);
Call(wr_130, V.Undef, ((V)((-7D))), ((V)(2.5)), ((V)(3.5)), ((V)(2.68)), NewObj(2).Put("fill", ((V)("#3a2a3a"))).Put("opacity", ((V)(0.08))).V);
Call(wr_130, V.Undef, ((V)(3.18)), ((V)(0.1)), ((V)(3.3)), ((V)(2.7)), NewObj(3).Put("fill", ((V)("#e2ddd2"))).Put("stroke", ((V)("#c9c2b4"))).Put("stroke-width", ((V)(0.6))).V);
Call(wr_130, V.Undef, ((V)((-1.35))), ((V)(0D)), ((V)(1.35)), ((V)(2.22)), NewObj(1).Put("fill", ((V)("#e6dccb"))).V);
Call(wr_130, V.Undef, ((V)((-1.25))), ((V)(0D)), ((V)(1.25)), ((V)(2.12)), NewObj(1).Put("fill", ((V)("url(#hcDoor)"))).V);
{
double r_343 = 0;
r_343 = 0D;
while (true) {
if (!((r_343 < 4D))) break;
double y0_345 = 0;
double y1_346 = 0;
y0_345 = (r_343 * 0.53);
y1_346 = (y0_345 + 0.53);
Call(ln_128, V.Undef, Arr(Arr(((V)((-1.25))), ((V)(GZ_50)), ((V)(y1_346))), Arr(((V)(1.25)), ((V)(GZ_50)), ((V)(y1_346)))), NewObj(2).Put("stroke", ((V)("#d3c8b4"))).Put("stroke-width", ((V)(1.2))).V);
{
double c_347 = 0;
c_347 = 0D;
while (true) {
if (!((c_347 < 4D))) break;
double x0_349 = 0;
x0_349 = ((-1.18) + (c_347 * 0.6));
if ((r_343 == 3D)) {
Call(wr_130, V.Undef, ((V)((x0_349 + 0.05))), ((V)((y0_345 + 0.14))), ((V)((x0_349 + 0.5))), ((V)((y0_345 + 0.42))), NewObj(3).Put("fill", ((V)("url(#hcGlass)"))).Put("stroke", ((V)("#cfc4b0"))).Put("stroke-width", ((V)(1D))).V);
} else {
Call(wr_130, V.Undef, ((V)((x0_349 + 0.05))), ((V)((y0_345 + 0.1))), ((V)((x0_349 + 0.5))), ((V)((y0_345 + 0.42))), NewObj(3).Put("fill", ((V)("none"))).Put("stroke", ((V)("#d8cdb9"))).Put("stroke-width", ((V)(1D))).V);
}
c_347++;
}
}
r_343++;
}
}
Call(wr_130, V.Undef, ((V)((-0.16))), ((V)(0.5)), ((V)(0.16)), ((V)(0.55)), NewObj(2).Put("fill", ((V)("#9a9488"))).Put("rx", ((V)(1D))).V);
Call(wr_130, V.Undef, ((V)((-2.45))), ((V)(0D)), ((V)((-1.75))), ((V)(2.08)), NewObj(1).Put("fill", ((V)("#7fa3c4"))).V);
Call(wr_130, V.Undef, ((V)((-2.4))), ((V)(0D)), ((V)((-1.8))), ((V)(2.03)), NewObj(1).Put("fill", ((V)("#8fb2d2"))).V);
Call(wr_130, V.Undef, ((V)((-2.3))), ((V)(1.3)), ((V)((-1.9))), ((V)(1.9)), NewObj(1).Put("fill", ((V)("url(#hcGlass)"))).V);
{
V k_350 = default;
k_350 = Call(wp_129, V.Undef, ((V)((-1.88))), ((V)(1D)));
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, GetIdx(k_350, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(k_350, 1D))).Put("r", ((V)(1.6))).Put("fill", ((V)("#e6c060"))).V, sv_126);
}
Call(wr_130, V.Undef, ((V)((-4.9))), ((V)(0.95)), ((V)((-3.5))), ((V)(2.05)), NewObj(1).Put("fill", ((V)("#ffffff"))).V);
Call(wr_130, V.Undef, ((V)((-4.83))), ((V)(1.02)), ((V)((-3.57))), ((V)(1.98)), NewObj(1).Put("fill", ((V)("url(#hcGlass)"))).V);
Call(ln_128, V.Undef, Arr(Arr(((V)((-4.2))), ((V)(GZ_50)), ((V)(1.02))), Arr(((V)((-4.2))), ((V)(GZ_50)), ((V)(1.98)))), NewObj(2).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.6))).V);
Call(ln_128, V.Undef, Arr(Arr(((V)((-4.83))), ((V)(GZ_50)), ((V)(1.5))), Arr(((V)((-3.57))), ((V)(GZ_50)), ((V)(1.5)))), NewObj(2).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.6))).V);
Call(wr_130, V.Undef, ((V)((-5.25))), ((V)(0.95)), ((V)((-4.95))), ((V)(2.05)), NewObj(1).Put("fill", ((V)("#6f8fb0"))).V);
Call(wr_130, V.Undef, ((V)((-3.45))), ((V)(0.95)), ((V)((-3.15))), ((V)(2.05)), NewObj(1).Put("fill", ((V)("#6f8fb0"))).V);
Call(wr_130, V.Undef, ((V)((-4.95))), ((V)(0.8)), ((V)((-3.45))), ((V)(0.95)), NewObj(1).Put("fill", ((V)("#a8764a"))).V);
Invoke(Arr(Arr(((V)((-4.8))), ((V)("#ff6f91"))), Arr(((V)((-4.55))), ((V)("#ffd84a"))), Arr(((V)((-4.3))), ((V)("#ff9fd0"))), Arr(((V)((-4.05))), ((V)("#ffffff"))), Arr(((V)((-3.8))), ((V)("#ff6f91"))), Arr(((V)((-3.6))), ((V)("#ffd84a")))), "forEach", Fn((V _arrowThis362, int _argc351, V _a353, V _a354, V _a355, V _a356, V[] _rest352) => {
V p_363 = default;
V x_359 = default;
V col_361 = default;
{ V _t357 = ListOf(_a353);
{ V _t358 = GetIdx(_t357, 0D);
x_359 = _t358; }
{ V _t360 = GetIdx(_t357, 1D);
col_361 = _t360; }
}
p_363 = Call(wp_129, V.Undef, x_359, ((V)(1D)));
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, GetIdx(p_363, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(p_363, 1D))).Put("r", ((V)(2.4))).Put("fill", ((V)("#5fa84c"))).V, sv_126);
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, GetIdx(p_363, 0D))).Put("cy", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_363, 1D)) - 1.5))))).Put("r", ((V)(1.7))).Put("fill", col_361).V, sv_126);
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1.6))), ((V)(1.6))), "forEach", Fn((V _arrowThis371, int _argc364, V x_370, V _a367, V _a368, V _a369, V[] _rest365) => {
V p_372 = default;
p_372 = Call(wp_129, V.Undef, x_370, ((V)(1.95)));
Call(S_17, V.Undef, ((V)("rect")), NewObj(6).Put("x", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_372, 0D)) - 2.2))))).Put("y", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_372, 1D)) - 4D))))).Put("width", ((V)(4.4))).Put("height", ((V)(7D))).Put("rx", ((V)(1.4))).Put("fill", ((V)("#3a3a44"))).V, sv_126);
Call(S_17, V.Undef, ((V)("rect")), NewObj(6).Put("x", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_372, 0D)) - 1.4))))).Put("y", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_372, 1D)) - 3D))))).Put("width", ((V)(2.8))).Put("height", ((V)(4.6))).Put("rx", ((V)(0.8))).Put("fill", ((V)("#fff2c4"))).V, sv_126);
return default;
}, 1, "", true));
Call(q_127, V.Undef, Arr(Arr(((V)((-7D))), ((V)(GZ_50))), Arr(((V)(3.5)), ((V)(GZ_50))), Arr(((V)(3.5)), ((V)((GZ_50 - 0.5)))), Arr(((V)((-7D))), ((V)((GZ_50 - 0.5))))), NewObj(1).Put("fill", ((V)("url(#hcAO)"))).V);
Invoke(Arr(((V)((-1.6))), ((V)(1.6))), "forEach", Fn((V _arrowThis380, int _argc373, V x_379, V _a376, V _a377, V _a378, V[] _rest374) => {
V p_381 = default;
V k_382 = default;
p_381 = Call(P_41, V.Undef, x_379, ((V)(0D)), ((V)((GZ_50 - 0.25))));
k_382 = GetIdx(p_381, 2D);
Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_381, 0D)) - (0.16 * ToNum(k_382))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_381, 1D)) - (0.3 * ToNum(k_382))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(p_381, 0D), ((V)((0.16 * ToNum(k_382))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_381, 1D)) - (0.3 * ToNum(k_382))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(p_381, 0D), ((V)((0.12 * ToNum(k_382))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_381, 1D))).S("L").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_381, 0D)) - (0.12 * ToNum(k_382))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_381, 1D))).S("Z").End()))).Put("fill", ((V)("#c96a44"))).V, sv_126);
Invoke(Arr(Arr(((V)((-0.1))), ((V)((-0.42))), ((V)(0.14))), Arr(((V)(0.08)), ((V)((-0.46))), ((V)(0.15))), Arr(((V)(0D)), ((V)((-0.55))), ((V)(0.13)))), "forEach", Fn((V _arrowThis396, int _argc383, V _a385, V _a386, V _a387, V _a388, V[] _rest384) => {
V a_391 = default;
V b_393 = default;
V r_395 = default;
{ V _t389 = ListOf(_a385);
{ V _t390 = GetIdx(_t389, 0D);
a_391 = _t390; }
{ V _t392 = GetIdx(_t389, 1D);
b_393 = _t392; }
{ V _t394 = GetIdx(_t389, 2D);
r_395 = _t394; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(p_381, 0D), ((V)((ToNum(a_391) * ToNum(k_382))))))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(p_381, 1D), ((V)((ToNum(b_393) * ToNum(k_382))))))).Put("r", Call(r2_20, V.Undef, ((V)((ToNum(r_395) * ToNum(k_382)))))).Put("fill", ((V)("#58a64a"))).V, sv_126);
}, 1, "", true));
Invoke(Arr(Arr(((V)((-0.08))), ((V)((-0.5)))), Arr(((V)(0.07)), ((V)((-0.56)))), Arr(((V)(0.02)), ((V)((-0.44))))), "forEach", Fn((V _arrowThis409, int _argc397, V _a399, V i_403, V _a401, V _a402, V[] _rest398) => {
V a_406 = default;
V b_408 = default;
{ V _t404 = ListOf(_a399);
{ V _t405 = GetIdx(_t404, 0D);
a_406 = _t405; }
{ V _t407 = GetIdx(_t404, 1D);
b_408 = _t407; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(p_381, 0D), ((V)((ToNum(a_406) * ToNum(k_382))))))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(p_381, 1D), ((V)((ToNum(b_408) * ToNum(k_382))))))).Put("r", Call(r2_20, V.Undef, ((V)((0.05 * ToNum(k_382)))))).Put("fill", GetK(Arr(((V)("#ff6f91")), ((V)("#ffd84a")), ((V)("#ffffff"))), i_403)).V, sv_126);
}, 2, "", true));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-2.1))), ((V)((-16D)))), Arr(((V)(2.05)), ((V)(16D)))), "forEach", Fn((V _arrowThis421, int _argc410, V _a412, V _a413, V _a414, V _a415, V[] _rest411) => {
V x0_418 = default;
V x1_420 = default;
{ V _t416 = ListOf(_a412);
{ V _t417 = GetIdx(_t416, 0D);
x0_418 = _t417; }
{ V _t419 = GetIdx(_t416, 1D);
x1_420 = _t419; }
}
{
double x_422 = 0;
x_422 = Min(ToNum(x0_418), ToNum(x1_420));
while (true) {
if (!((x_422 < Max(ToNum(x0_418), ToNum(x1_420))))) break;
V p_424 = default;
V k_425 = default;
V g_426 = default;
p_424 = Call(P_41, V.Undef, ((V)((x_422 + 0.2))), ((V)(0D)), ((V)((GZ_50 - 0.35))));
k_425 = GetIdx(p_424, 2D);
g_426 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, sv_126);
Invoke(Arr(Arr(((V)((-0.24))), ((V)((-0.34))), ((V)(0.3))), Arr(((V)(0.04)), ((V)((-0.46))), ((V)(0.34))), Arr(((V)(0.26)), ((V)((-0.32))), ((V)(0.28)))), "forEach", Fn((V _arrowThis441, int _argc427, V _a429, V i_433, V _a431, V _a432, V[] _rest428) => {
V a_436 = default;
V b_438 = default;
V r_440 = default;
{ V _t434 = ListOf(_a429);
{ V _t435 = GetIdx(_t434, 0D);
a_436 = _t435; }
{ V _t437 = GetIdx(_t434, 1D);
b_438 = _t437; }
{ V _t439 = GetIdx(_t434, 2D);
r_440 = _t439; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(p_424, 0D), ((V)((ToNum(a_436) * ToNum(k_425))))))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(p_424, 1D), ((V)((ToNum(b_438) * ToNum(k_425))))))).Put("r", Call(r2_20, V.Undef, ((V)((ToNum(r_440) * ToNum(k_425)))))).Put("fill", ((V)((SEqN(i_433, 1D) ? "#5aa24c" : "#4c9140")))).V, g_426);
}, 2, "", true));
Call(S_17, V.Undef, ((V)("circle")), NewObj(5).Put("cx", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_424, 0D)) - (0.05 * ToNum(k_425))))))).Put("cy", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_424, 1D)) - (0.6 * ToNum(k_425))))))).Put("r", Call(r2_20, V.Undef, ((V)((0.12 * ToNum(k_425)))))).Put("fill", ((V)("#7cc46a"))).Put("opacity", ((V)(0.7))).V, g_426);
x_422 = (x_422 + 0.42);
}
}
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)(3D)), ((V)(6.4))), Arr(((V)((-5.2))), ((V)(5.6)))), "forEach", Fn((V _arrowThis453, int _argc442, V _a444, V _a445, V _a446, V _a447, V[] _rest443) => {
V p_454 = default;
V k_455 = default;
V tx_450 = default;
V tz_452 = default;
{ V _t448 = ListOf(_a444);
{ V _t449 = GetIdx(_t448, 0D);
tx_450 = _t449; }
{ V _t451 = GetIdx(_t448, 1D);
tz_452 = _t451; }
}
p_454 = Call(P_41, V.Undef, tx_450, ((V)(0D)), tz_452);
k_455 = GetIdx(p_454, 2D);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_454, 0D)) - (0.4 * ToNum(k_455))))))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(p_454, 1D), ((V)((0.05 * ToNum(k_455))))))).Put("rx", Call(r2_20, V.Undef, ((V)((1.1 * ToNum(k_455)))))).Put("ry", Call(r2_20, V.Undef, ((V)((0.25 * ToNum(k_455)))))).Put("fill", ((V)("#2a4a20"))).Put("opacity", ((V)(0.25))).V, sv_126);
Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_454, 0D)) - (0.1 * ToNum(k_455))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_454, 1D))).S("L").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_454, 0D)) - (0.06 * ToNum(k_455))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_454, 1D)) - (2D * ToNum(k_455))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(p_454, 0D), ((V)((0.06 * ToNum(k_455))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_454, 1D)) - (2D * ToNum(k_455))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(p_454, 0D), ((V)((0.12 * ToNum(k_455))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_454, 1D))).S("Z").End()))).Put("fill", ((V)("#7a5034"))).V, sv_126);
Invoke(Arr(Arr(((V)((-0.6))), ((V)((-2.2))), ((V)(0.62)), ((V)("#4f9a3e"))), Arr(((V)(0.55)), ((V)((-2.3))), ((V)(0.66)), ((V)("#4f9a3e"))), Arr(((V)(0D)), ((V)((-2.9))), ((V)(0.75)), ((V)("#5aa84a"))), Arr(((V)((-0.3))), ((V)((-3.3))), ((V)(0.5)), ((V)("#66b456"))), Arr(((V)(0.35)), ((V)((-3.2))), ((V)(0.48)), ((V)("#66b456"))), Arr(((V)(0.1)), ((V)((-2.5))), ((V)(0.6)), ((V)("#5aa84a")))), "forEach", Fn((V _arrowThis471, int _argc456, V _a458, V _a459, V _a460, V _a461, V[] _rest457) => {
V a_464 = default;
V b_466 = default;
V r_468 = default;
V c_470 = default;
{ V _t462 = ListOf(_a458);
{ V _t463 = GetIdx(_t462, 0D);
a_464 = _t463; }
{ V _t465 = GetIdx(_t462, 1D);
b_466 = _t465; }
{ V _t467 = GetIdx(_t462, 2D);
r_468 = _t467; }
{ V _t469 = GetIdx(_t462, 3D);
c_470 = _t469; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(p_454, 0D), ((V)((ToNum(a_464) * ToNum(k_455))))))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(p_454, 1D), ((V)((ToNum(b_466) * ToNum(k_455))))))).Put("r", Call(r2_20, V.Undef, ((V)((ToNum(r_468) * ToNum(k_455)))))).Put("fill", c_470).V, sv_126);
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-3.6))), ((V)(2.2))), Arr(((V)(3.3)), ((V)(1.6))), Arr(((V)((-6.4))), ((V)(3.2))), Arr(((V)(5.6)), ((V)(3.4)))), "forEach", Fn((V _arrowThis484, int _argc472, V _a474, V i_478, V _a476, V _a477, V[] _rest473) => {
V p_485 = default;
V k_486 = default;
V x_481 = default;
V z_483 = default;
{ V _t479 = ListOf(_a474);
{ V _t480 = GetIdx(_t479, 0D);
x_481 = _t480; }
{ V _t482 = GetIdx(_t479, 1D);
z_483 = _t482; }
}
p_485 = Call(P_41, V.Undef, x_481, ((V)(0D)), z_483);
k_486 = GetIdx(p_485, 2D);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_20, V.Undef, GetIdx(p_485, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(p_485, 1D))).Put("rx", Call(r2_20, V.Undef, ((V)((0.7 * ToNum(k_486)))))).Put("ry", Call(r2_20, V.Undef, ((V)((0.16 * ToNum(k_486)))))).Put("fill", ((V)("#8a5a34"))).Put("opacity", ((V)(0.85))).V, sv_126);
{
double j_487 = 0;
j_487 = 0D;
while (true) {
if (!((j_487 < 7D))) break;
double a_489 = 0;
V c_490 = default;
a_489 = ((-0.55) + (j_487 * 0.18));
c_490 = GetIdx(Arr(((V)("#ff6f91")), ((V)("#ffd84a")), ((V)("#ffffff")), ((V)("#ff9fd0"))), (ToNum(Add(i_478, ((V)(j_487)))) % 4D));
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(p_485, 0D), ((V)((a_489 * ToNum(k_486))))))).Put("cy", Call(r2_20, V.Undef, ((V)(((ToNum(GetIdx(p_485, 1D)) - (0.12 * ToNum(k_486))) - ((System.Math.Abs(FdLibm.Sin((j_487 * 1.7))) * 0.1) * ToNum(k_486))))))).Put("r", Call(r2_20, V.Undef, ((V)((0.07 * ToNum(k_486)))))).Put("fill", ((V)("#58a64a"))).V, sv_126);
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(p_485, 0D), ((V)((a_489 * ToNum(k_486))))))).Put("cy", Call(r2_20, V.Undef, ((V)(((ToNum(GetIdx(p_485, 1D)) - (0.2 * ToNum(k_486))) - ((System.Math.Abs(FdLibm.Sin((j_487 * 1.7))) * 0.1) * ToNum(k_486))))))).Put("r", Call(r2_20, V.Undef, ((V)((0.055 * ToNum(k_486)))))).Put("fill", c_490).V, sv_126);
j_487++;
}
}
return default;
}, 2, "", true));
Call(q_127, V.Undef, Arr(Arr(((V)((-DW_51))), ((V)((-1D)))), Arr(((V)(DW_51)), ((V)((-1D)))), Arr(((V)(DW_51)), ((V)(GZ_50))), Arr(((V)((-DW_51))), ((V)(GZ_50)))), NewObj(1).Put("fill", ((V)("url(#hcCon)"))).V);
{
double y0_491 = 0;
y0_491 = (ToNum(GetIdx(Call(P_41, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(GZ_50))), 1D)) - 6D);
Call(S_17, V.Undef, ((V)("rect")), NewObj(8).Put("x", ((V)(0D))).Put("y", Call(r2_20, V.Undef, ((V)(y0_491)))).Put("width", W_39).Put("height", Call(r2_20, V.Undef, ((V)((ToNum(H_40) - y0_491))))).Put("fill", ((V)("#ffffff"))).Put("filter", ((V)("url(#hcGrain)"))).Put("clip-path", ((V)("url(#hcDrive)"))).Put("opacity", ((V)(0.9))).V, sv_126);
}
Call(q_127, V.Undef, Arr(Arr(((V)((-DW_51))), ((V)((-1D)))), Arr(((V)(((-DW_51) + 0.06))), ((V)((-1D)))), Arr(((V)(((-DW_51) + 0.06))), ((V)(GZ_50))), Arr(((V)((-DW_51))), ((V)(GZ_50)))), NewObj(1).Put("fill", ((V)("#b8b0a2"))).V);
Call(q_127, V.Undef, Arr(Arr(((V)((DW_51 - 0.06))), ((V)((-1D)))), Arr(((V)(DW_51)), ((V)((-1D)))), Arr(((V)(DW_51)), ((V)(GZ_50))), Arr(((V)((DW_51 - 0.06))), ((V)(GZ_50)))), NewObj(1).Put("fill", ((V)("#b8b0a2"))).V);
Invoke(Arr(((V)(1.4)), ((V)(3D)), ((V)(4.6)), ((V)(6.2))), "forEach", Fn((V _arrowThis499, int _argc492, V z_498, V _a495, V _a496, V _a497, V[] _rest493) => {
Call(ln_128, V.Undef, Arr(Arr(((V)((-DW_51))), z_498), Arr(((V)(DW_51)), z_498)), NewObj(2).Put("stroke", ((V)("#a89e90"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)(((1.6 * ToNum(GetIdx(Call(P_41, V.Undef, ((V)(0D)), ((V)(0D)), z_498), 2D))) / 100D))))).V);
Call(ln_128, V.Undef, Arr(Arr(((V)((-DW_51))), Add(z_498, ((V)(0.03)))), Arr(((V)(DW_51)), Add(z_498, ((V)(0.03))))), NewObj(3).Put("stroke", ((V)("#f4f0ea"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)(((1.2 * ToNum(GetIdx(Call(P_41, V.Undef, ((V)(0D)), ((V)(0D)), z_498), 2D))) / 100D))))).Put("opacity", ((V)(0.8))).V);
return default;
}, 1, "", true));
Call(ln_128, V.Undef, Arr(Arr(((V)(0D)), ((V)((-1D)))), Arr(((V)(0D)), ((V)(GZ_50)))), NewObj(3).Put("stroke", ((V)("#b5ab9c"))).Put("stroke-width", ((V)(1D))).Put("opacity", ((V)(0.6))).V);
Call(ln_128, V.Undef, Arr(Arr(((V)((-1.5))), ((V)(2.3))), Arr(((V)((-1.28))), ((V)(2.55))), Arr(((V)((-1.36))), ((V)(2.8))), Arr(((V)((-1.1))), ((V)(3D)))), NewObj(3).Put("stroke", ((V)("#8f8578"))).Put("stroke-width", ((V)(1.1))).Put("opacity", ((V)(0.7))).V);
Call(ln_128, V.Undef, Arr(Arr(((V)(1.2)), ((V)(5.1))), Arr(((V)(1.36)), ((V)(5.4))), Arr(((V)(1.25)), ((V)(5.7)))), NewObj(3).Put("stroke", ((V)("#8f8578"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.6))).V);
{
V p_500 = default;
V k_501 = default;
p_500 = Call(P_41, V.Undef, ((V)(0.7)), ((V)(0D)), ((V)(6.9)));
k_501 = GetIdx(p_500, 2D);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(7).Put("cx", Call(r2_20, V.Undef, GetIdx(p_500, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(p_500, 1D))).Put("rx", Call(r2_20, V.Undef, ((V)((0.45 * ToNum(k_501)))))).Put("ry", Call(r2_20, V.Undef, ((V)((0.12 * ToNum(k_501)))))).Put("fill", ((V)("#5a5450"))).Put("opacity", ((V)(0.22))).Put("filter", ((V)("url(#hcBlur)"))).V, sv_126);
}
Invoke(Arr(Arr(((V)((-1.2))), ((V)(1.9)), ((V)("#d9883a")), ((V)(20D))), Arr(((V)(1.5)), ((V)(2.4)), ((V)("#c8642e")), ((V)((-30D)))), Arr(((V)((-0.4))), ((V)(4D)), ((V)("#e0a040")), ((V)(60D))), Arr(((V)(1.1)), ((V)(0.8)), ((V)("#c8642e")), ((V)(10D))), Arr(((V)((-1.6))), ((V)(5.6)), ((V)("#d9883a")), ((V)((-50D))))), "forEach", Fn((V _arrowThis517, int _argc502, V _a504, V _a505, V _a506, V _a507, V[] _rest503) => {
V p_518 = default;
double k_519 = 0;
V x_510 = default;
V z_512 = default;
V c_514 = default;
V r_516 = default;
{ V _t508 = ListOf(_a504);
{ V _t509 = GetIdx(_t508, 0D);
x_510 = _t509; }
{ V _t511 = GetIdx(_t508, 1D);
z_512 = _t511; }
{ V _t513 = GetIdx(_t508, 2D);
c_514 = _t513; }
{ V _t515 = GetIdx(_t508, 3D);
r_516 = _t515; }
}
p_518 = Call(P_41, V.Undef, x_510, ((V)(0D)), z_512);
k_519 = (ToNum(GetIdx(p_518, 2D)) / 100D);
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)("M0 -6Q5 -2 0 6Q-5 -2 0 -6Z"))).Put("fill", c_514).Put("opacity", ((V)(0.85))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, GetIdx(p_518, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_518, 1D))).S(") rotate(").V(r_516).S(") scale(").V(Call(r2_20, V.Undef, ((V)((k_519 * 1.4))))).S(" ").V(Call(r2_20, V.Undef, ((V)((k_519 * 0.7))))).S(")").End()))).V, sv_126);
return default;
}, 1, "", true));
pa_135 = NewObj(4).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.82))).Put("stroke-linejoin", ((V)("round"))).V;
Call(ln_128, V.Undef, Arr(Arr(((V)((-0.9))), ((V)((BZ_48 - 0.02)))), Arr(((V)((-0.9))), ((V)(2.3))), Arr(((V)(0.9)), ((V)(2.3))), Arr(((V)(0.9)), ((V)((BZ_48 - 0.02))))), pa_135);
Call(ln_128, V.Undef, Arr(Arr(((V)(((-DW_51) + 0.08))), ((V)(BZ_48))), Arr(((V)((DW_51 - 0.08))), ((V)(BZ_48)))), pa_135);
{
V pts_520 = default;
V p2_521 = default;
pts_520 = Arr();
{
double i_522 = 0;
i_522 = 0D;
while (true) {
if (!((i_522 <= 24D))) break;
double a_524 = 0;
a_524 = ((System.Math.PI * i_522) / 24D);
Invoke(pts_520, "push", Arr(((V)((FdLibm.Cos(a_524) * 0.9))), ((V)((2.3 - (FdLibm.Sin(a_524) * 0.9))))));
i_522++;
}
}
Call(ln_128, V.Undef, pts_520, pa_135);
p2_521 = Arr();
{
double i_525 = 0;
i_525 = 0D;
while (true) {
if (!((i_525 <= 24D))) break;
double a_527 = 0;
a_527 = ((System.Math.PI * i_525) / 24D);
Invoke(p2_521, "push", Arr(((V)((FdLibm.Cos(a_527) * 0.9))), ((V)((2.3 + (FdLibm.Sin(a_527) * 0.9))))));
i_525++;
}
}
Call(ln_128, V.Undef, p2_521, Object_assign(NewObj(0).V, pa_135, NewObj(2).Put("stroke-dasharray", ((V)("5 6"))).Put("opacity", ((V)(0.6))).V));
}
{
V pts_528 = default;
double R_529 = 0;
pts_528 = Arr();
R_529 = 3.6;
{
double i_530 = 0;
i_530 = 0D;
while (true) {
if (!((i_530 <= 40D))) break;
double a_532 = 0;
double x_533 = 0;
double z_534 = 0;
a_532 = ((-1.05) + ((2.1 * i_530) / 40D));
x_533 = (FdLibm.Sin(a_532) * R_529);
z_534 = (RZ_47 - (FdLibm.Cos(a_532) * R_529));
if ((System.Math.Abs(x_533) <= (DW_51 - 0.1))) {
Invoke(pts_528, "push", Arr(((V)(x_533)), ((V)(z_534))));
}
i_530++;
}
}
Call(ln_128, V.Undef, pts_528, pa_135);
}
{
V p_535 = default;
V k_536 = default;
V b_537 = default;
p_535 = Call(P_41, V.Undef, ((V)(2.25)), ((V)(0D)), ((V)(4.4)));
k_536 = GetIdx(p_535, 2D);
b_537 = Fn((V _arrowThis546, int _argc538, V dx_544, V dy_545, V _a542, V _a543, V[] _rest539) => {
V cx_547 = default;
V cy_548 = default;
double r_549 = 0;
cx_547 = Add(GetIdx(p_535, 0D), ((V)((ToNum(dx_544) * ToNum(k_536)))));
cy_548 = Add(GetIdx(p_535, 1D), ((V)((ToNum(dy_545) * ToNum(k_536)))));
r_549 = (0.12 * ToNum(k_536));
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, cx_547)).Put("cy", Call(r2_20, V.Undef, cy_548)).Put("r", Call(r2_20, V.Undef, ((V)(r_549)))).Put("fill", ((V)("url(#hcBall)"))).V, sv_126);
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(cx_547) - r_549))))).S(" ").V(Call(r2_20, V.Undef, cy_548)).S("H").V(Call(r2_20, V.Undef, Add(cx_547, ((V)(r_549))))).S("M").V(Call(r2_20, V.Undef, cx_547)).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(cy_548) - r_549))))).S("V").V(Call(r2_20, V.Undef, Add(cy_548, ((V)(r_549))))).End()))).Put("stroke", ((V)("#7a3410"))).Put("stroke-width", ((V)(0.7))).Put("opacity", ((V)(0.8))).V, sv_126);
return default;
}, 2, "", true);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_535, 0D)) - (0.1 * ToNum(k_536))))))).Put("cy", Call(r2_20, V.Undef, GetIdx(p_535, 1D))).Put("rx", Call(r2_20, V.Undef, ((V)((0.4 * ToNum(k_536)))))).Put("ry", Call(r2_20, V.Undef, ((V)((0.07 * ToNum(k_536)))))).Put("fill", ((V)("#2a4a20"))).Put("opacity", ((V)(0.25))).V, sv_126);
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_535, 0D)) - (0.3 * ToNum(k_536))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_535, 1D))).S("V").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_535, 1D)) - (0.55 * ToNum(k_536))))))).S("M").V(Call(r2_20, V.Undef, Add(GetIdx(p_535, 0D), ((V)((0.3 * ToNum(k_536))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_535, 1D))).S("V").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_535, 1D)) - (0.55 * ToNum(k_536))))))).S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_535, 0D)) - (0.32 * ToNum(k_536))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_535, 1D)) - (0.3 * ToNum(k_536))))))).S("H").V(Call(r2_20, V.Undef, Add(GetIdx(p_535, 0D), ((V)((0.32 * ToNum(k_536))))))).S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_535, 0D)) - (0.32 * ToNum(k_536))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_535, 1D)) - (0.55 * ToNum(k_536))))))).S("H").V(Call(r2_20, V.Undef, Add(GetIdx(p_535, 0D), ((V)((0.32 * ToNum(k_536))))))).End()))).Put("stroke", ((V)("#4a4a56"))).Put("stroke-width", ((V)(1.4))).Put("stroke-linecap", ((V)("round"))).V, sv_126);
Call(b_537, V.Undef, ((V)((-0.14))), ((V)((-0.43))));
Call(b_537, V.Undef, ((V)(0.14)), ((V)((-0.43))));
Call(b_537, V.Undef, ((V)(0.02)), ((V)((-0.15))));
}
{
V p_550 = default;
V k_551 = default;
p_550 = Call(P_41, V.Undef, ((V)((-2.05))), ((V)(0D)), ((V)(3.7)));
k_551 = GetIdx(p_550, 2D);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_20, V.Undef, GetIdx(p_550, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(p_550, 1D))).Put("rx", Call(r2_20, V.Undef, ((V)((0.3 * ToNum(k_551)))))).Put("ry", Call(r2_20, V.Undef, ((V)((0.06 * ToNum(k_551)))))).Put("fill", ((V)("#2a4a20"))).Put("opacity", ((V)(0.22))).V, sv_126);
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_550, 0D)) - (0.28 * ToNum(k_551))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_550, 1D)) - (0.02 * ToNum(k_551))))))).S("Q").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_550, 0D)) - (0.1 * ToNum(k_551))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_550, 1D)) - (0.1 * ToNum(k_551))))))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(p_550, 0D), ((V)((0.02 * ToNum(k_551))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_550, 1D)) - (0.04 * ToNum(k_551))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(p_550, 0D), ((V)((0.06 * ToNum(k_551))))))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(p_550, 1D), ((V)((0.02 * ToNum(k_551))))))).S("L").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_550, 0D)) - (0.3 * ToNum(k_551))))))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(p_550, 1D), ((V)((0.04 * ToNum(k_551))))))).S("Z").End()))).Put("fill", ((V)("#ff8fb8"))).Put("stroke", ((V)("#e0608e"))).Put("stroke-width", ((V)(0.8))).V, sv_126);
Call(S_17, V.Undef, ((V)("rect")), NewObj(8).Put("x", Call(r2_20, V.Undef, Add(GetIdx(p_550, 0D), ((V)((0.1 * ToNum(k_551))))))).Put("y", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_550, 1D)) - (0.24 * ToNum(k_551))))))).Put("width", Call(r2_20, V.Undef, ((V)((0.08 * ToNum(k_551)))))).Put("height", Call(r2_20, V.Undef, ((V)((0.24 * ToNum(k_551)))))).Put("rx", ((V)(1.2))).Put("fill", ((V)("#5cc2ff"))).Put("stroke", ((V)("#2f86c8"))).Put("stroke-width", ((V)(0.7))).V, sv_126);
Call(S_17, V.Undef, ((V)("rect")), NewObj(6).Put("x", Call(r2_20, V.Undef, Add(GetIdx(p_550, 0D), ((V)((0.11 * ToNum(k_551))))))).Put("y", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_550, 1D)) - (0.29 * ToNum(k_551))))))).Put("width", Call(r2_20, V.Undef, ((V)((0.06 * ToNum(k_551)))))).Put("height", Call(r2_20, V.Undef, ((V)((0.05 * ToNum(k_551)))))).Put("rx", ((V)(0.8))).Put("fill", ((V)("#f0f4f8"))).V, sv_126);
}
Call(S_17, V.Undef, ((V)("rect")), NewObj(7).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_39, ((V)(40D)))).Put("height", Add(H_40, ((V)(40D)))).Put("fill", ((V)("url(#hcSun)"))).Put("opacity", ((V)(0.25))).Put("transform", ((V)("translate(-180 -300) scale(2.2)"))).V, sv_126);
return default;
}, 1, "drawCourt", false);
drawHoop_87 = Fn((V _self552, int _argc553, V t_559, V _a556, V _a557, V _a558, V[] _rest554) => {
V moving_560 = default;
V swaying_561 = default;
V sun_562 = default;
V gq_563 = default;
V pb_564 = default;
V pt_565 = default;
double pw_566 = 0;
V pd_567 = default;
V a1_568 = default;
V a2_569 = default;
V a3_570 = default;
V a4_571 = default;
V b1_572 = default;
V b2_573 = default;
double bw_574 = 0;
double bh_575 = 0;
V s1_576 = default;
V s2_577 = default;
V br_578 = default;
V c_579 = default;
V arc_580 = default;
double sw_581 = 0;
JsStrBuf nd_582 = null;
V ring_583 = default;
V r0_584 = default;
V r1_585 = default;
V r2b_586 = default;
if (_self552.IsNullish) _self552 = GlobalV;
moving_560 = ((System.Math.Abs((ToNum(hx_83) - ToNum((lastHx_86.IsNullish ? ((V)(1000000000D)) : lastHx_86)))) > 0.0001) ? V.True : V.False);
swaying_561 = (((ToNum(t_559) - ToNum(netAt_85)) < 1600D) ? V.True : V.False);
if (((!(Truthy(moving_560)) && !(Truthy(swaying_561))) && !lastHx_86.IsNullish)) {
return default;
}
lastHx_86 = hx_83;
Set(backG_77, "innerHTML", ((V)("")));
Set(frontG_79, "innerHTML", ((V)("")));
Invoke(Invoke(shG_75, "querySelectorAll", ((V)(".hs"))), "forEach", Fn((V _arrowThis594, int _argc587, V e_593, V _a590, V _a591, V _a592, V[] _rest588) => {
return Invoke(e_593, "remove");
}, 1, "", true));
sun_562 = Call(S_17, V.Undef, ((V)("g")), NewObj(2).Put("class", ((V)("hs"))).Put("opacity", ((V)(0.2))).V, shG_75);
Invoke(shG_75, "insertBefore", sun_562, Get(shG_75, "firstChild"));
gq_563 = Fn((V _arrowThis602, int _argc595, V pts_601, V _a598, V _a599, V _a600, V[] _rest596) => {
return Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_601, "map", Fn((V _arrowThis614, int _argc603, V _a605, V _a606, V _a607, V _a608, V[] _rest604) => {
V s_615 = default;
V x_611 = default;
V z_613 = default;
{ V _t609 = ListOf(_a605);
{ V _t610 = GetIdx(_t609, 0D);
x_611 = _t610; }
{ V _t612 = GetIdx(_t609, 1D);
z_613 = _t612; }
}
s_615 = Call(P_41, V.Undef, x_611, ((V)(0D)), z_613);
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_615, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_615, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).Put("fill", ((V)("#2a2034"))).V, sun_562);
}, 1, "", true);
Call(gq_563, V.Undef, Arr(Arr(((V)((ToNum(hx_83) - 0.06))), ((V)(PZ_49))), Arr(Add(hx_83, ((V)(0.06))), ((V)(PZ_49))), Arr(Add(hx_83, ((V)(1.05))), ((V)((PZ_49 - 3.2)))), Arr(Add(hx_83, ((V)(0.93))), ((V)((PZ_49 - 3.2))))));
Call(gq_563, V.Undef, Arr(Arr(Add(hx_83, ((V)(0.95))), ((V)((PZ_49 - 2.95)))), Arr(Add(hx_83, ((V)(2.55))), ((V)((PZ_49 - 2.95)))), Arr(Add(hx_83, ((V)(2.75))), ((V)((PZ_49 - 4.05)))), Arr(Add(hx_83, ((V)(1.15))), ((V)((PZ_49 - 4.05))))));
pb_564 = Call(P_41, V.Undef, hx_83, ((V)(0D)), ((V)(PZ_49)));
pt_565 = Call(P_41, V.Undef, hx_83, ((V)(3.6)), ((V)(PZ_49)));
pw_566 = (0.11 * ToNum(GetIdx(pb_564, 2D)));
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_20, V.Undef, GetIdx(pb_564, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(pb_564, 1D))).Put("rx", Call(r2_20, V.Undef, ((V)((0.55 * ToNum(GetIdx(pb_564, 2D))))))).Put("ry", Call(r2_20, V.Undef, ((V)((0.1 * ToNum(GetIdx(pb_564, 2D))))))).Put("fill", ((V)("#2a2034"))).Put("opacity", ((V)(0.28))).V, backG_77);
Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(pb_564, 0D)) - (0.42 * ToNum(GetIdx(pb_564, 2D)))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(pb_564, 1D))).S("L").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(pb_564, 0D)) - (0.36 * ToNum(GetIdx(pb_564, 2D)))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(pb_564, 1D)) - (0.22 * ToNum(GetIdx(pb_564, 2D)))))))).S("H").V(Call(r2_20, V.Undef, Add(GetIdx(pb_564, 0D), ((V)((0.36 * ToNum(GetIdx(pb_564, 2D)))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(pb_564, 0D), ((V)((0.42 * ToNum(GetIdx(pb_564, 2D)))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(pb_564, 1D))).S("Z").End()))).Put("fill", ((V)("#3a3a46"))).V, backG_77);
Call(S_17, V.Undef, ((V)("rect")), NewObj(5).Put("x", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(pb_564, 0D)) - (pw_566 / 2D)))))).Put("y", Call(r2_20, V.Undef, GetIdx(pt_565, 1D))).Put("width", Call(r2_20, V.Undef, ((V)(pw_566)))).Put("height", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(pb_564, 1D)) - ToNum(GetIdx(pt_565, 1D))))))).Put("fill", ((V)("url(#hcPole)"))).V, backG_77);
pd_567 = Call(P_41, V.Undef, hx_83, ((V)(1.5)), ((V)(PZ_49)));
Call(S_17, V.Undef, ((V)("rect")), NewObj(6).Put("x", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(pb_564, 0D)) - (pw_566 * 0.9)))))).Put("y", Call(r2_20, V.Undef, GetIdx(pd_567, 1D))).Put("width", Call(r2_20, V.Undef, ((V)((pw_566 * 1.8))))).Put("height", Call(r2_20, V.Undef, ((V)(((ToNum(GetIdx(pb_564, 1D)) - (0.22 * ToNum(GetIdx(pb_564, 2D)))) - ToNum(GetIdx(pd_567, 1D))))))).Put("rx", ((V)(3D))).Put("fill", ((V)("url(#hcPad)"))).V, backG_77);
a1_568 = Call(P_41, V.Undef, hx_83, ((V)(3.5)), ((V)(PZ_49)));
a2_569 = Call(P_41, V.Undef, hx_83, ((V)(3.42)), ((V)((BZ_48 + 0.05))));
a3_570 = Call(P_41, V.Undef, hx_83, ((V)(3.1)), ((V)(PZ_49)));
a4_571 = Call(P_41, V.Undef, hx_83, ((V)(3D)), ((V)((BZ_48 + 0.05))));
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(a1_568, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a1_568, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(a2_569, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a2_569, 1D))).S("M").V(Call(r2_20, V.Undef, GetIdx(a3_570, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a3_570, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(a4_571, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a4_571, 1D))).End()))).Put("stroke", ((V)("#3a3a46"))).Put("stroke-width", ((V)(4D))).Put("stroke-linecap", ((V)("round"))).V, backG_77);
b1_572 = Call(P_41, V.Undef, ((V)((ToNum(hx_83) - 0.9))), ((V)(3.85)), ((V)(BZ_48)));
b2_573 = Call(P_41, V.Undef, Add(hx_83, ((V)(0.9))), ((V)(2.78)), ((V)(BZ_48)));
bw_574 = (ToNum(GetIdx(b2_573, 0D)) - ToNum(GetIdx(b1_572, 0D)));
bh_575 = (ToNum(GetIdx(b2_573, 1D)) - ToNum(GetIdx(b1_572, 1D)));
Call(S_17, V.Undef, ((V)("rect")), NewObj(7).Put("x", Call(r2_20, V.Undef, Add(GetIdx(b1_572, 0D), ((V)(2D))))).Put("y", Call(r2_20, V.Undef, Add(GetIdx(b1_572, 1D), ((V)(3D))))).Put("width", Call(r2_20, V.Undef, ((V)(bw_574)))).Put("height", Call(r2_20, V.Undef, ((V)(bh_575)))).Put("rx", ((V)(4D))).Put("fill", ((V)("#2a2034"))).Put("opacity", ((V)(0.25))).V, backG_77);
Call(S_17, V.Undef, ((V)("rect")), NewObj(8).Put("x", Call(r2_20, V.Undef, GetIdx(b1_572, 0D))).Put("y", Call(r2_20, V.Undef, GetIdx(b1_572, 1D))).Put("width", Call(r2_20, V.Undef, ((V)(bw_574)))).Put("height", Call(r2_20, V.Undef, ((V)(bh_575)))).Put("rx", ((V)(4D))).Put("fill", ((V)("url(#hcBoard)"))).Put("stroke", ((V)("#f4f6fa"))).Put("stroke-width", ((V)(4D))).V, backG_77);
Call(S_17, V.Undef, ((V)("rect")), NewObj(8).Put("x", Call(r2_20, V.Undef, GetIdx(b1_572, 0D))).Put("y", Call(r2_20, V.Undef, GetIdx(b1_572, 1D))).Put("width", Call(r2_20, V.Undef, ((V)(bw_574)))).Put("height", Call(r2_20, V.Undef, ((V)(bh_575)))).Put("rx", ((V)(4D))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#9aa4b4"))).Put("stroke-width", ((V)(1D))).V, backG_77);
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, Add(GetIdx(b1_572, 0D), ((V)((bw_574 * 0.12)))))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(b1_572, 1D), ((V)(3D))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(b1_572, 0D), ((V)((bw_574 * 0.3)))))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(b1_572, 1D), ((V)(3D))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(b1_572, 0D), ((V)((bw_574 * 0.12)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(b2_573, 1D)) - 3D))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(b1_572, 0D), ((V)(3D))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(b2_573, 1D)) - 3D))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(b1_572, 0D), ((V)(3D))))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(b1_572, 1D), ((V)((bh_575 * 0.4)))))).S("Z").End()))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.6))).V, backG_77);
s1_576 = Call(P_41, V.Undef, ((V)((ToNum(hx_83) - 0.3))), ((V)(3.5)), ((V)(BZ_48)));
s2_577 = Call(P_41, V.Undef, Add(hx_83, ((V)(0.3))), ((V)(3.08)), ((V)(BZ_48)));
Call(S_17, V.Undef, ((V)("rect")), NewObj(7).Put("x", Call(r2_20, V.Undef, GetIdx(s1_576, 0D))).Put("y", Call(r2_20, V.Undef, GetIdx(s1_576, 1D))).Put("width", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s2_577, 0D)) - ToNum(GetIdx(s1_576, 0D))))))).Put("height", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s2_577, 1D)) - ToNum(GetIdx(s1_576, 1D))))))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#e8483c"))).Put("stroke-width", ((V)(2.4))).V, backG_77);
Call(S_17, V.Undef, ((V)("rect")), NewObj(5).Put("x", Call(r2_20, V.Undef, GetIdx(b1_572, 0D))).Put("y", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(b2_573, 1D)) - 2.6))))).Put("width", Call(r2_20, V.Undef, ((V)(bw_574)))).Put("height", ((V)(2.6))).Put("fill", ((V)("#e8483c"))).V, backG_77);
br_578 = Call(P_41, V.Undef, hx_83, ((V)((RY_46 - 0.02))), ((V)((BZ_48 - 0.01))));
c_579 = Call(P_41, V.Undef, hx_83, ((V)(RY_46)), ((V)(RZ_47)));
Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(br_578, 0D)) - 3.5))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(br_578, 1D)) - 2D))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(br_578, 0D), ((V)(3.5))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(br_578, 1D)) - 2D))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(c_579, 0D), ((V)(2D))))).S(" ").V(Call(r2_20, V.Undef, ((V)(((ToNum(GetIdx(c_579, 1D)) - 1D) - ((RR_44 * ToNum(GetIdx(c_579, 2D))) * 0.3)))))).S("L").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(c_579, 0D)) - 2D))))).S(" ").V(Call(r2_20, V.Undef, ((V)(((ToNum(GetIdx(c_579, 1D)) - 1D) - ((RR_44 * ToNum(GetIdx(c_579, 2D))) * 0.3)))))).S("Z").End()))).Put("fill", ((V)("#c8501e"))).V, backG_77);
arc_580 = Fn((V _arrowThis627, int _argc616, V a0_622, V a1_623, V w_624, V col_625, V[] _rest617) => {
JsStrBuf d_628 = null;
V g_626 = default;
g_626 = (_argc616 > 4 ? _rest617[0] : V.Undef);
d_628 = new JsStrBuf("");
{
double i_629 = 0;
i_629 = 0D;
while (true) {
if (!((i_629 <= 16D))) break;
V a_631 = default;
V s_632 = default;
a_631 = Add(a0_622, ((V)((((ToNum(a1_623) - ToNum(a0_622)) * i_629) / 16D))));
s_632 = Call(P_41, V.Undef, Add(hx_83, ((V)((FdLibm.Cos(ToNum(a_631)) * RR_44)))), ((V)(RY_46)), ((V)((RZ_47 + (FdLibm.Sin(ToNum(a_631)) * RR_44)))));
d_628.S((NumTruthy(i_629) ? "L" : "M")).V(Call(r2_20, V.Undef, GetIdx(s_632, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_632, 1D)));
i_629++;
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(d_628.Str))).Put("fill", ((V)("none"))).Put("stroke", col_625).Put("stroke-width", w_624).Put("stroke-linecap", ((V)("round"))).V, g_626);
return default;
}, 5, "", true);
Call(arc_580, V.Undef, ((V)(0D)), ((V)(System.Math.PI)), ((V)(2.6)), ((V)("#c8501e")), backG_77);
sw_581 = ((netSw_84 * FdLibm.Sin(((ToNum(t_559) - ToNum(netAt_85)) / 70D))) * FdLibm.Exp(((-(ToNum(t_559) - ToNum(netAt_85))) / 500D)));
nd_582 = new JsStrBuf("");
ring_583 = Fn((V _arrowThis642, int _argc633, V yy_639, V rr_640, V k_641, V _a638, V[] _rest634) => {
return Invoke(new ArrBuilder().Spread(Call(G("Array"), V.Undef, ((V)(12D)))).V, "map", Fn((V _arrowThis651, int _argc643, V __649, V i_650, V _a647, V _a648, V[] _rest644) => {
double a_652 = 0;
a_652 = (((ToNum(i_650) / 12D) * System.Math.PI) * 2D);
return Call(P_41, V.Undef, Add(Add(hx_83, ((V)((FdLibm.Cos(a_652) * ToNum(rr_640))))), ((V)(((sw_581 * 0.05) * ToNum(k_641))))), yy_639, ((V)((RZ_47 + (FdLibm.Sin(a_652) * ToNum(rr_640))))));
return default;
}, 2, "", true));
}, 3, "", true);
r0_584 = Call(ring_583, V.Undef, ((V)(RY_46)), ((V)(RR_44)), ((V)(0D)));
r1_585 = Call(ring_583, V.Undef, ((V)((RY_46 - 0.22))), ((V)((RR_44 * 0.82))), ((V)(1D)));
r2b_586 = Call(ring_583, V.Undef, ((V)((RY_46 - 0.42))), ((V)((RR_44 * 0.6))), ((V)(2D)));
{
double i_653 = 0;
i_653 = 0D;
while (true) {
if (!((i_653 < 12D))) break;
double j_655 = 0;
j_655 = ((i_653 + 1D) % 12D);
nd_582.S("M").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r0_584, i_653), 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r0_584, i_653), 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r1_585, j_655), 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r1_585, j_655), 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r2b_586, i_653), 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r2b_586, i_653), 1D)));
nd_582.S("M").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r0_584, j_655), 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r0_584, j_655), 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r1_585, i_653), 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r1_585, i_653), 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r2b_586, j_655), 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(GetIdx(r2b_586, j_655), 1D)));
i_653++;
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(nd_582.Str))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.95))).V, frontG_79);
Call(arc_580, V.Undef, ((V)(System.Math.PI)), ((V)((System.Math.PI * 2D))), ((V)(3D)), ((V)("#f07a2e")), frontG_79);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(8).Put("cx", Call(r2_20, V.Undef, GetIdx(c_579, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(c_579, 1D))).Put("rx", Call(r2_20, V.Undef, ((V)((RR_44 * ToNum(GetIdx(c_579, 2D))))))).Put("ry", Call(r2_20, V.Undef, ((V)(((RR_44 * ToNum(GetIdx(c_579, 2D))) * 0.3))))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffb070"))).Put("stroke-width", ((V)(0.8))).Put("opacity", ((V)(0.6))).V, frontG_79);
return default;
}, 1, "drawHoop", false);
stepB_88 = Fn((V _self656, int _argc657, V b_663, V dt_664, V h_665, V t_666, V[] _rest658) => {
V py_668 = default;
double ins0_669 = 0;
double rx_670 = 0;
double rz_671 = 0;
V d_672 = default;
V qx_673 = default;
double qz_674 = 0;
double ex_675 = 0;
double ey_676 = 0;
double ez_677 = 0;
double dist_678 = 0;
double din_679 = 0;
V @out_667 = default;
if (_self656.IsNullish) _self656 = GlobalV;
@out_667 = (_argc657 > 4 ? _rest658[0] : V.Undef);
py_668 = Get(b_663, "y");
ins0_669 = Hypot((ToNum(Get(b_663, "x")) - ToNum(h_665)), (ToNum(Get(b_663, "z")) - RZ_47));
OpSet(b_663, "vy", 1, ((V)((G_42 * ToNum(dt_664)))));
OpSet(b_663, "x", 0, ((V)((ToNum(Get(b_663, "vx")) * ToNum(dt_664)))));
OpSet(b_663, "y", 0, ((V)((ToNum(Get(b_663, "vy")) * ToNum(dt_664)))));
OpSet(b_663, "z", 0, ((V)((ToNum(Get(b_663, "vz")) * ToNum(dt_664)))));
rx_670 = (ToNum(Get(b_663, "x")) - ToNum(h_665));
rz_671 = (ToNum(Get(b_663, "z")) - RZ_47);
d_672 = (((V)(Hypot(rx_670, rz_671))) is var _t680 && Truthy(_t680) ? _t680 : ((V)(0.000001)));
qx_673 = Add(h_665, ((V)(((RR_44 * rx_670) / ToNum(d_672)))));
qz_674 = (RZ_47 + ((RR_44 * rz_671) / ToNum(d_672)));
ex_675 = (ToNum(Get(b_663, "x")) - ToNum(qx_673));
ey_676 = (ToNum(Get(b_663, "y")) - RY_46);
ez_677 = (ToNum(Get(b_663, "z")) - qz_674);
dist_678 = Hypot(ex_675, ey_676, ez_677);
if ((dist_678 < (BR_43 + RT_45))) {
double nx_681 = 0;
double ny_682 = 0;
double nz_683 = 0;
double vn_684 = 0;
nx_681 = (ex_675 / dist_678);
ny_682 = (ey_676 / dist_678);
nz_683 = (ez_677 / dist_678);
vn_684 = (((ToNum(Get(b_663, "vx")) * nx_681) + (ToNum(Get(b_663, "vy")) * ny_682)) + (ToNum(Get(b_663, "vz")) * nz_683));
if ((vn_684 < 0D)) {
OpSet(b_663, "vx", 1, ((V)(((1.55 * vn_684) * nx_681))));
OpSet(b_663, "vy", 1, ((V)(((1.55 * vn_684) * ny_682))));
OpSet(b_663, "vz", 1, ((V)(((1.55 * vn_684) * nz_683))));
OpSet(b_663, "vx", 2, ((V)(0.92)));
OpSet(b_663, "vz", 2, ((V)(0.92)));
IncM(b_663, "rim", 1D, false);
Invoke(Get(@out_667, "ev"), "push", Arr(t_666, ((V)("rim"))));
}
Set(b_663, "x", Add(qx_673, ((V)((nx_681 * (BR_43 + RT_45))))));
Set(b_663, "y", ((V)((RY_46 + (ny_682 * (BR_43 + RT_45))))));
Set(b_663, "z", ((V)((qz_674 + (nz_683 * (BR_43 + RT_45))))));
}
if ((((((GtN(Get(b_663, "vz"), 0D) && GtN(Add(Get(b_663, "z"), ((V)(BR_43))), BZ_48)) && LtN(Get(b_663, "z"), (BZ_48 + 0.08))) && (System.Math.Abs((ToNum(Get(b_663, "x")) - ToNum(h_665))) < (0.9 + (BR_43 * 0.5)))) && GtN(Get(b_663, "y"), (2.78 - (BR_43 * 0.5)))) && LtN(Get(b_663, "y"), (3.85 + (BR_43 * 0.5))))) {
Set(b_663, "vz", ((V)(((-ToNum(Get(b_663, "vz"))) * 0.6))));
OpSet(b_663, "vx", 2, ((V)(0.9)));
Set(b_663, "z", ((V)((BZ_48 - BR_43))));
IncM(b_663, "board", 1D, false);
Invoke(Get(@out_667, "ev"), "push", Arr(t_666, ((V)("board"))));
}
din_679 = Hypot((ToNum(Get(b_663, "x")) - ToNum(h_665)), (ToNum(Get(b_663, "z")) - RZ_47));
if ((((LtN(Get(b_663, "y"), RY_46) && GtN(Get(b_663, "y"), (RY_46 - 0.45))) && (ins0_669 < RR_44)) && GeN(py_668, (RY_46 - 0.45)))) {
if ((din_679 > ((RR_44 * 0.78) - (BR_43 * 0.4)))) {
double k_685 = 0;
k_685 = (((RR_44 * 0.78) - (BR_43 * 0.4)) / din_679);
Set(b_663, "x", Add(h_665, ((V)(((ToNum(Get(b_663, "x")) - ToNum(h_665)) * k_685)))));
Set(b_663, "z", ((V)((RZ_47 + ((ToNum(Get(b_663, "z")) - RZ_47) * k_685)))));
}
OpSet(b_663, "vx", 2, ((V)(0.9)));
OpSet(b_663, "vz", 2, ((V)(0.9)));
OpSet(b_663, "vy", 2, ((V)(0.97)));
}
if (((((!(Truthy(Get(b_663, "scored"))) && GeN(py_668, RY_46)) && LtN(Get(b_663, "y"), RY_46)) && LtN(Get(b_663, "vy"), 0D)) && (Hypot((ToNum(Get(b_663, "x")) - ToNum(h_665)), (ToNum(Get(b_663, "z")) - RZ_47)) < (RR_44 - 0.02)))) {
Set(b_663, "scored", ((V)(1D)));
Set(@out_667, "scored", ((V)(1D)));
Set(@out_667, "swish", ((V)(((!(Truthy(Get(b_663, "rim"))) && !(Truthy(Get(b_663, "board")))) ? 1D : 0D))));
Set(@out_667, "tScore", t_666);
Invoke(Get(@out_667, "ev"), "push", Arr(t_666, ((V)("basket"))));
}
if (LtN(Get(b_663, "y"), BR_43)) {
Set(b_663, "y", ((V)(BR_43)));
if ((System.Math.Abs(ToNum(Get(b_663, "vy"))) > 1.2)) {
IncM(b_663, "bounces", 1D, false);
Invoke(Get(@out_667, "ev"), "push", Arr(t_666, ((V)("ground"))));
if (LtN(Get(@out_667, "tGround"), 0D)) {
Set(@out_667, "tGround", t_666);
}
}
Set(b_663, "vy", ((V)(((-ToNum(Get(b_663, "vy"))) * 0.55))));
OpSet(b_663, "vx", 2, ((V)(0.8)));
OpSet(b_663, "vz", 2, ((V)(0.8)));
if ((System.Math.Abs(ToNum(Get(b_663, "vy"))) < 0.6)) {
Set(b_663, "vy", ((V)(0D)));
}
}
return default;
}, 5, "stepB", false);
sim_89 = Fn((V _self686, int _argc687, V k_693, V a_694, V tL_695, V _a692, V[] _rest688) => {
V v_696 = default;
double ph_697 = 0;
double ct_698 = 0;
V b_699 = default;
V @out_700 = default;
double n_701 = 0;
if (_self686.IsNullish) _self686 = GlobalV;
v_696 = Call(vOf_67, V.Undef, k_693);
ph_697 = (PH0_65 + ((Sign(ToNum(a_694)) * Pow(System.Math.Abs(ToNum(a_694)), 1.8)) * 0.16));
ct_698 = FdLibm.Cos(TH_54);
b_699 = NewObj(10).Put("x", GetIdx(REL_56, 0D)).Put("y", GetIdx(REL_56, 1D)).Put("z", GetIdx(REL_56, 2D)).Put("vx", ((V)(((FdLibm.Sin(ph_697) * ToNum(v_696)) * ct_698)))).Put("vz", ((V)(((FdLibm.Cos(ph_697) * ToNum(v_696)) * ct_698)))).Put("vy", ((V)((ToNum(v_696) * FdLibm.Sin(TH_54))))).Put("rim", ((V)(0D))).Put("board", ((V)(0D))).Put("scored", ((V)(0D))).Put("bounces", ((V)(0D))).V;
@out_700 = NewObj(9).Put("pos", Arr()).Put("ev", Arr()).Put("scored", ((V)(0D))).Put("swish", ((V)(0D))).Put("tScore", ((V)((-1D)))).Put("tGround", ((V)((-1D)))).Put("k", k_693).Put("a", a_694).Put("tL", tL_695).V;
n_701 = Round((LIFE_60 / DT_59));
{
double i_702 = 0;
i_702 = 0D;
while (true) {
if (!((i_702 <= n_701))) break;
double t_704 = 0;
t_704 = (i_702 * DT_59);
Invoke(Get(@out_700, "pos"), "push", Arr(Get(b_699, "x"), Get(b_699, "y"), Get(b_699, "z")));
Call(stepB_88, V.Undef, b_699, ((V)(DT_59)), Call(hxAt_72, V.Undef, Add(tL_695, ((V)((t_704 * 1000D))))), ((V)(t_704)), @out_700);
i_702++;
}
}
return @out_700;
return default;
}, 3, "sim", false);
mkBall_107 = Fn((V _self705, int _argc706, V layer_712, V _a709, V _a710, V _a711, V[] _rest707) => {
V g_713 = default;
V sh_714 = default;
V b_715 = default;
V sm_716 = default;
V hl_717 = default;
V fl_718 = default;
if (_self705.IsNullish) _self705 = GlobalV;
g_713 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, (layer_712 is var _t719 && Truthy(_t719) ? _t719 : slotH_81));
sh_714 = Call(S_17, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#2a2034"))).Put("opacity", ((V)(0.18))).V, shG_75);
b_715 = Call(S_17, V.Undef, ((V)("circle")), NewObj(2).Put("r", ((V)(10D))).Put("fill", ((V)("url(#ygBall)"))).V, g_713);
sm_716 = Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#7a3410"))).Put("stroke-width", ((V)(1.4))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.85))).V, g_713);
hl_717 = Call(S_17, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.35))).V, g_713);
fl_718 = Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd84a"))).Put("stroke-width", ((V)(2D))).Put("opacity", ((V)(0D))).V, g_713);
return NewObj(12).Put("g", g_713).Put("sh", sh_714).Put("b", b_715).Put("sm", sm_716).Put("hl", hl_717).Put("fl", fl_718).Put("x", GetIdx(HOLD_55, 0D)).Put("y", GetIdx(HOLD_55, 1D)).Put("z", GetIdx(HOLD_55, 2D)).Put("spin", ((V)(0D))).Put("born", tNow_102).Put("fire", ((V)(0D))).V;
return default;
}, 1, "mkBall", false);
drawBall_108 = Fn((V _self720, int _argc721, V o_727, V t_728, V _a725, V _a726, V[] _rest722) => {
V s_729 = default;
double r_730 = 0;
V sp_731 = default;
double c_732 = 0;
double sn_733 = 0;
V g0_734 = default;
V hgt_735 = default;
if (_self720.IsNullish) _self720 = GlobalV;
s_729 = Call(P_41, V.Undef, Get(o_727, "x"), Get(o_727, "y"), Get(o_727, "z"));
r_730 = ((BR_43 * ToNum(GetIdx(s_729, 2D))) * ToNum((Get(o_727, "pop").IsNullish ? ((V)(1D)) : Get(o_727, "pop"))));
Invoke(Get(o_727, "b"), "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, GetIdx(s_729, 0D)));
Invoke(Get(o_727, "b"), "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, GetIdx(s_729, 1D)));
Invoke(Get(o_727, "b"), "setAttribute", ((V)("r")), Call(r2_20, V.Undef, ((V)(r_730))));
sp_731 = Get(o_727, "spin");
c_732 = FdLibm.Cos(ToNum(sp_731));
sn_733 = FdLibm.Sin(ToNum(sp_731));
Invoke(Get(o_727, "sm"), "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_729, 0D)) - (r_730 * c_732)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_729, 1D)) - (r_730 * sn_733)))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(s_729, 0D), ((V)((r_730 * c_732)))))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(s_729, 1D), ((V)((r_730 * sn_733)))))).S("M").V(Call(r2_20, V.Undef, Add(GetIdx(s_729, 0D), ((V)((r_730 * sn_733)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_729, 1D)) - (r_730 * c_732)))))).S("Q").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_729, 0D)) - ((r_730 * 0.25) * c_732)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_729, 1D)) - ((r_730 * 0.25) * sn_733)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_729, 0D)) - (r_730 * sn_733)))))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(s_729, 1D), ((V)((r_730 * c_732)))))).End())));
Invoke(Get(o_727, "hl"), "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_729, 0D)) - (r_730 * 0.35))))));
Invoke(Get(o_727, "hl"), "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_729, 1D)) - (r_730 * 0.4))))));
Invoke(Get(o_727, "hl"), "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)((r_730 * 0.4)))));
Invoke(Get(o_727, "hl"), "setAttribute", ((V)("ry")), Call(r2_20, V.Undef, ((V)((r_730 * 0.25)))));
Invoke(Get(o_727, "fl"), "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, GetIdx(s_729, 0D)));
Invoke(Get(o_727, "fl"), "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, GetIdx(s_729, 1D)));
Invoke(Get(o_727, "fl"), "setAttribute", ((V)("r")), Call(r2_20, V.Undef, ((V)((r_730 + 2D)))));
Invoke(Get(o_727, "fl"), "setAttribute", ((V)("opacity")), ((V)((Truthy(Get(o_727, "fire")) ? (0.5 + (0.4 * FdLibm.Sin((ToNum(t_728) / 60D)))) : 0D))));
g0_734 = Call(P_41, V.Undef, Get(o_727, "x"), ((V)(0D)), Get(o_727, "z"));
hgt_735 = Call(cl_18, V.Undef, ((V)((1D - (ToNum(Get(o_727, "y")) / 4D)))), ((V)(0.25)), ((V)(1D)));
Invoke(Get(o_727, "sh"), "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, Add(GetIdx(g0_734, 0D), ((V)((ToNum(Get(o_727, "y")) * 3D))))));
Invoke(Get(o_727, "sh"), "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, GetIdx(g0_734, 1D)));
Invoke(Get(o_727, "sh"), "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)((((BR_43 * ToNum(GetIdx(g0_734, 2D))) * 1.1) * ToNum(hgt_735))))));
Invoke(Get(o_727, "sh"), "setAttribute", ((V)("ry")), Call(r2_20, V.Undef, ((V)((((BR_43 * ToNum(GetIdx(g0_734, 2D))) * 0.3) * ToNum(hgt_735))))));
Invoke(Get(o_727, "sh"), "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)((0.2 * ToNum(hgt_735))))));
return default;
}, 2, "drawBall", false);
pullOf_109 = Fn((V _self736, int _argc737, V d_743, V _a740, V _a741, V _a742, V[] _rest738) => {
double len_744 = 0;
if (_self736.IsNullish) _self736 = GlobalV;
len_744 = Hypot(ToNum(Get(d_743, "x")), ToNum(Get(d_743, "y")));
if ((LtN(Get(d_743, "y"), 6D) || (len_744 < 16D))) {
return V.Null;
}
return NewObj(2).Put("k", Call(cl_18, V.Undef, ((V)(((len_744 - 16D) / PULL_58))), ((V)(0D)), ((V)(1D)))).Put("a", Call(cl_18, V.Undef, ((V)((((-ToNum(Get(d_743, "x"))) / Max(60D, ToNum(Get(d_743, "y")))) * 0.9))), ((V)((-1.2))), ((V)(1.2)))).V;
return default;
}, 1, "pullOf", false);
drawPath_110 = Fn((V _self745, int _argc746, V S1_752, V _a749, V _a750, V _a751, V[] _rest747) => {
V ok_753 = default;
V col_754 = default;
V end_755 = default;
V c_756 = default;
if (_self745.IsNullish) _self745 = GlobalV;
Set(pathG_80, "innerHTML", ((V)("")));
Set(bandG_82, "innerHTML", ((V)("")));
if ((!(Truthy(S1_752)) || !(Truthy(aim_103)))) {
return default;
}
ok_753 = Get(S1_752, "scored");
col_754 = ((V)((Truthy(ok_753) ? "#38d96a" : "#ff4d5e")));
end_755 = (Truthy(ok_753) ? Add(Get(S1_752, "tScore"), ((V)(0.14))) : ((V)(Min(1.7, ToNum((GtN(Get(S1_752, "tGround"), 0D) ? Get(S1_752, "tGround") : ((V)(1.7)))), ToNum(Add(GetIdx((Invoke(Get(S1_752, "ev"), "find", Fn((V _arrowThis764, int _argc757, V e_763, V _a760, V _a761, V _a762, V[] _rest758) => {
return ((SEqS(GetIdx(e_763, 1D), "rim") || SEqS(GetIdx(e_763, 1D), "board")) ? V.True : V.False);
}, 1, "", true)) is var _t765 && Truthy(_t765) ? _t765 : Arr(((V)(9D)))), 0D), ((V)(0.35))))))));
{
double t_766 = 0;
double i_767 = 0;
t_766 = 0.03;
i_767 = 0D;
while (true) {
if (!(Le(((V)(t_766)), end_755))) break;
V p_769 = default;
V s_770 = default;
V r_771 = default;
p_769 = Call(posAt_90, V.Undef, S1_752, ((V)(t_766)));
s_770 = Call(P_41, V.Undef, GetIdx(p_769, 0D), GetIdx(p_769, 1D), GetIdx(p_769, 2D));
r_771 = Call(cl_18, V.Undef, ((V)(((2.9 * ToNum(GetIdx(s_770, 2D))) / 170D))), ((V)(1.4)), ((V)(3.2)));
Call(S_17, V.Undef, ((V)("circle")), NewObj(5).Put("cx", Call(r2_20, V.Undef, GetIdx(s_770, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(s_770, 1D))).Put("r", Call(r2_20, V.Undef, Add(r_771, ((V)(1.1))))).Put("fill", ((V)("#1e1430"))).Put("opacity", ((V)(0.32))).V, pathG_80);
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, GetIdx(s_770, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(s_770, 1D))).Put("r", Call(r2_20, V.Undef, r_771)).Put("fill", col_754).V, pathG_80);
t_766 = (t_766 + (1D / 30D));
i_767++;
}
}
c_756 = Call(P_41, V.Undef, Call(hxAt_72, V.Undef, Add(Get(S1_752, "tL"), ((V)((ToNum(Get(S1_752, "tScore")) * 1000D))))), ((V)(RY_46)), ((V)(RZ_47)));
if (Truthy(ok_753)) {
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(8).Put("cx", Call(r2_20, V.Undef, GetIdx(c_756, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(c_756, 1D))).Put("rx", Call(r2_20, V.Undef, ((V)(((RR_44 * ToNum(GetIdx(c_756, 2D))) + 4D))))).Put("ry", Call(r2_20, V.Undef, ((V)((((RR_44 * ToNum(GetIdx(c_756, 2D))) * 0.3) + 3D))))).Put("fill", ((V)("none"))).Put("stroke", col_754).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.9))).V, pathG_80);
}
Call(S_17, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, Get(aim_103, "x0"))).S(" ").V(Call(r2_20, V.Undef, Get(aim_103, "y0"))).S("L").V(Call(r2_20, V.Undef, Get(aim_103, "x"))).S(" ").V(Call(r2_20, V.Undef, Get(aim_103, "y"))).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(3D))).Put("stroke-dasharray", ((V)("2 6"))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.8))).V, bandG_82);
Call(S_17, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_20, V.Undef, Get(aim_103, "x0"))).Put("cy", Call(r2_20, V.Undef, Get(aim_103, "y0"))).Put("r", ((V)(6D))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.85))).V, bandG_82);
Call(S_17, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_20, V.Undef, Get(aim_103, "x"))).Put("cy", Call(r2_20, V.Undef, Get(aim_103, "y"))).Put("r", ((V)(9D))).Put("fill", col_754).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.95))).V, bandG_82);
return default;
}, 1, "drawPath", false);
release_111 = Fn((V _self772, int _argc773, V k_779, V a_780, V S0_781, V _a778, V[] _rest774) => {
V tL_782 = default;
V S1_783 = default;
if (_self772.IsNullish) _self772 = GlobalV;
if (Truthy(((!(Truthy(held_95)) ? V.True : V.False) is var _t784 && Truthy(_t784) ? _t784 : thr_104))) {
return default;
}
tL_782 = (Truthy(S0_781) ? Get(S0_781, "tL") : Add(tNow_102, ((V)(THROW_57))));
S1_783 = (Truthy((S0_781 is var _t785 && !Truthy(_t785) ? _t785 : ((System.Math.Abs((ToNum(Get(S0_781, "tL")) - ToNum(tL_782))) < 1D) ? V.True : V.False))) ? S0_781 : Call(sim_89, V.Undef, k_779, a_780, tL_782));
thr_104 = NewObj(6).Put("t0", tNow_102).Put("tL", tL_782).Put("k", k_779).Put("a", a_780).Put("S", S1_783).Put("from", Arr(Get(held_95, "x"), Get(held_95, "y"), Get(held_95, "z"))).V;
aim_103 = V.Null;
Call(drawPath_110, V.Undef, V.Null);
Invoke(SFX_21, "whoosh");
return default;
}, 3, "release", false);
launch_112 = Fn((V _self786, int _argc787, V _a789, V _a790, V _a791, V _a792, V[] _rest788) => {
V b_793 = default;
if (_self786.IsNullish) _self786 = GlobalV;
b_793 = held_95;
held_95 = V.Null;
Set(b_793, "S", Get(thr_104, "S"));
Set(b_793, "tl", Get(thr_104, "tL"));
Set(b_793, "fired", ((V)(0D)));
Set(b_793, "fire", ((V)(((fire_98 > 0D) ? 1D : 0D))));
Set(b_793, "missed", ((V)(0D)));
Invoke(balls_94, "push", b_793);
lastThrow_105 = NewObj(2).Put("tL", Get(thr_104, "tL")).Put("k", Get(thr_104, "k")).V;
thr_104 = V.Null;
nextAt_96 = Add(tNow_102, ((V)(640D)));
return default;
}, 0, "launch", false);
basket_113 = Fn((V _self794, int _argc795, V b_801, V _a798, V _a799, V _a800, V[] _rest796) => {
V sw_802 = default;
double pts_803 = 0;
V c_804 = default;
if (_self794.IsNullish) _self794 = GlobalV;
made_101++;
sw_802 = Get(Get(b_801, "S"), "swish");
streak_97++;
if (((streak_97 >= 3D) && !(NumTruthy(fire_98)))) {
fire_98 = 1D;
Invoke(ctx_36, "toast", ((V)("On fire!")), ((V)((ToNum(W_39) / 2D))), ((V)((ToNum(H_40) * 0.34))), ((V)("#ffb03a")), (true ? V.True : V.False));
Invoke(SFX_21, "win");
}
pts_803 = ((Truthy(sw_802) ? 3D : 2D) * (NumTruthy(fire_98) ? 2D : 1D));
c_804 = Call(P_41, V.Undef, hx_83, ((V)(RY_46)), ((V)(RZ_47)));
Invoke(ctx_36, "add", ((V)(pts_803)), GetIdx(c_804, 0D), ((V)((ToNum(GetIdx(c_804, 1D)) - 30D))), ((V)(JsStrBuf.Begin().S((Truthy(sw_802) ? "Swish! +" : "+")).N(pts_803).End())), ((V)((Truthy(sw_802) ? "#8fe0ff" : "#ffffff"))));
Invoke(ctx_36, "burst", GetIdx(c_804, 0D), Add(GetIdx(c_804, 1D), ((V)(8D))), ((V)("confetti")), ((V)(14D)), NewObj(2).Put("v", ((V)(120D))).Put("life", ((V)(0.9))).V);
netSw_84 = 1D;
netAt_85 = tNow_102;
cheerT_99 = tNow_102;
Invoke(SFX_21, "swish");
Call(G("setTimeout"), V.Undef, Get(SFX_21, "score"), ((V)(80D)));
if (Truthy((Get(ctx_36, "addTime") is var _t805 && !Truthy(_t805) ? _t805 : Get(ctx_36, "playing")))) {
Invoke(ctx_36, "addTime", ((V)(10D)));
Invoke(ctx_36, "toast", ((V)("+10s")), ((V)((ToNum(W_39) - 64D))), ((V)(78D)), ((V)("#9dffb0")));
}
return default;
}, 1, "basket", false);
missed_114 = Fn((V _self806, int _argc807, V _a809, V _a810, V _a811, V _a812, V[] _rest808) => {
if (_self806.IsNullish) _self806 = GlobalV;
missT_100 = tNow_102;
if (NumTruthy(streak_97)) {
streak_97 = 0D;
if (NumTruthy(fire_98)) {
fire_98 = 0D;
Invoke(ctx_36, "toast", ((V)("Fire out")), ((V)((ToNum(W_39) / 2D))), ((V)((ToNum(H_40) * 0.34))), ((V)("#ffffff")));
}
}
return default;
}, 0, "missed", false);
schedule_115 = Fn((V _self813, int _argc814, V _a816, V _a817, V _a818, V _a819, V[] _rest815) => {
V busyTo_820 = default;
if (_self813.IsNullish) _self813 = GlobalV;
busyTo_820 = Add(InvokeSpread(G("Math"), "max", new ArrBuilder().Add(tNow_102).Spread(Invoke(balls_94, "map", Fn((V _arrowThis828, int _argc821, V b_827, V _a824, V _a825, V _a826, V[] _rest822) => {
return Add(Get(b_827, "tl"), ((V)(2400D)));
}, 1, "", true))).Add((Truthy(thr_104) ? Add(Get(thr_104, "tL"), ((V)(2400D))) : ((V)(0D)))).Add((Truthy(aim_103) ? Add(Add(tNow_102, ((V)(THROW_57))), ((V)(2400D))) : ((V)(0D)))).V), ((V)(300D)));
if (((GeN(Get(ctx_36, "score"), 20D) && SEqN(Get(M_71, "t1"), double.PositiveInfinity)) && !(Truthy(Get(api_118, "_still"))))) {
Set(M_71, "t1", busyTo_820);
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis842, int _argc836, V _a838, V _a839, V _a840, V _a841, V[] _rest837) => {
if (Truthy(Get(ctx_36, "playing"))) {
Invoke(ctx_36, "toast", ((V)("The hoop moves!")), ((V)((ToNum(W_39) / 2D))), ((V)((ToNum(H_40) * 0.34))), ((V)("#ffe36e")));
}
return default;
}, 0, "", true), ((V)(Max(0D, (ToNum(Get(M_71, "t1")) - ToNum(tNow_102))))));
}
if (((GeN(Get(ctx_36, "score"), 50D) && LtN(Get(M_71, "t1"), double.PositiveInfinity)) && SEqN(Get(M_71, "t2"), double.PositiveInfinity))) {
Set(M_71, "t2", ((V)(Max(ToNum(busyTo_820), ToNum(Add(Get(M_71, "t1"), ((V)(1500D))))))));
}
return default;
}, 0, "schedule", false);
poseMe_116 = Fn((V _self843, int _argc844, V t_850, V _a847, V _a848, V _a849, V[] _rest845) => {
V E_851 = default;
double tc_852 = 0;
double tm_853 = 0;
if (_self843.IsNullish) _self843 = GlobalV;
E_851 = NewObj(6).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).V;
if (Truthy(thr_104)) {
V u_854 = default;
V k_855 = default;
V w_856 = default;
u_854 = Call(cl_18, V.Undef, ((V)(((ToNum(t_850) - ToNum(Get(thr_104, "t0"))) / Max(1D, (ToNum(Get(thr_104, "tL")) - ToNum(Get(thr_104, "t0"))))))), ((V)(0D)), ((V)(1D)));
k_855 = Get(thr_104, "k");
w_856 = NewObj(4).Put("armL", ((V)((128D - (34D * ToNum(k_855)))))).Put("armR", ((V)((128D - (34D * ToNum(k_855)))))).Put("lift", ((V)(((-1.6) * ToNum(k_855))))).Put("sq", ((V)((0.12 * ToNum(k_855))))).V;
E_851 = NewObj(6).Put("armL", Call(lerp_19, V.Undef, Get(w_856, "armL"), ((V)(172D)), Call(eo_62, V.Undef, u_854))).Put("armR", Call(lerp_19, V.Undef, Get(w_856, "armR"), ((V)(172D)), Call(eo_62, V.Undef, u_854))).Put("lift", Call(lerp_19, V.Undef, Get(w_856, "lift"), ((V)(7D)), Call(eo_62, V.Undef, u_854))).Put("sq", Call(lerp_19, V.Undef, Get(w_856, "sq"), ((V)((-0.1))), Call(eo_62, V.Undef, u_854))).Put("tilt", ((V)(((ToNum(Get(thr_104, "a")) * 6D) * (1D - ToNum(u_854)))))).Put("lean", ((V)(0D))).V;
} else {
if (Truthy((lastThrow_105 is var _t857 && !Truthy(_t857) ? _t857 : (((ToNum(t_850) - ToNum(Get(lastThrow_105, "tL"))) < 900D) ? V.True : V.False)))) {
double tt_858 = 0;
double up_859 = 0;
tt_858 = (ToNum(t_850) - ToNum(Get(lastThrow_105, "tL")));
up_859 = ((tt_858 < 360D) ? 1D : (1D - ToNum(Call(SM_61, V.Undef, ((V)(((tt_858 - 360D) / 360D)))))));
Set(E_851, "armL", Set(E_851, "armR", Call(lerp_19, V.Undef, ((V)(40D)), ((V)(172D)), ((V)(up_859)))));
Set(E_851, "lift", ((V)(((tt_858 < 380D) ? ((7D + (FdLibm.Sin((Min(1D, (tt_858 / 380D)) * System.Math.PI)) * 5D)) - (7D * ToNum(Call(SM_61, V.Undef, ((V)((tt_858 / 380D))))))) : 0D))));
Set(E_851, "sq", ((V)(((tt_858 < 380D) ? ((-0.1) * (1D - (tt_858 / 380D))) : (0.08 * FdLibm.Sin((ToNum(Call(cl_18, V.Undef, ((V)(((tt_858 - 380D) / 260D))), ((V)(0D)), ((V)(1D)))) * System.Math.PI)))))));
}
}
if (Truthy((held_95 is var _t860 && !Truthy(_t860) ? _t860 : (!(Truthy(thr_104)) ? V.True : V.False)))) {
V k_861 = default;
V kk_862 = default;
V born_863 = default;
k_861 = (Truthy((aim_103 is var _t864 && !Truthy(_t864) ? _t864 : Get(aim_103, "p"))) ? Get(Get(aim_103, "p"), "k") : ((V)(0D)));
kk_862 = Set(held_95, "kk", Call(lerp_19, V.Undef, (Get(held_95, "kk") is var _t865 && Truthy(_t865) ? _t865 : ((V)(0D))), k_861, ((V)(0.35))));
born_863 = Call(cl_18, V.Undef, ((V)(((ToNum(t_850) - ToNum(Get(held_95, "born"))) / 260D))), ((V)(0D)), ((V)(1D)));
Set(E_851, "armL", Call(lerp_19, V.Undef, Get(E_851, "armL"), ((V)((128D - (34D * ToNum(kk_862))))), born_863));
Set(E_851, "armR", Call(lerp_19, V.Undef, Get(E_851, "armR"), ((V)((128D - (34D * ToNum(kk_862))))), born_863));
OpSet(E_851, "sq", 0, ((V)((0.12 * ToNum(kk_862)))));
OpSet(E_851, "lift", 0, ((V)(((-1.6) * ToNum(kk_862)))));
OpSet(E_851, "tilt", 0, ((V)((Truthy((aim_103 is var _t866 && !Truthy(_t866) ? _t866 : Get(aim_103, "p"))) ? ((ToNum(Get(Get(aim_103, "p"), "a")) * 6D) * ToNum(kk_862)) : 0D))));
}
tc_852 = (ToNum(t_850) - ToNum(cheerT_99));
if ((tc_852 < 700D)) {
double u_867 = 0;
double s_868 = 0;
u_867 = (tc_852 / 700D);
s_868 = FdLibm.Sin((u_867 * System.Math.PI));
OpSet(E_851, "lift", 0, ((V)((s_868 * 9D))));
Set(E_851, "armL", Call(lerp_19, V.Undef, Get(E_851, "armL"), ((V)((150D + (20D * FdLibm.Sin((tc_852 / 60D)))))), ((V)(s_868))));
Set(E_851, "armR", Call(lerp_19, V.Undef, Get(E_851, "armR"), ((V)((150D - (20D * FdLibm.Sin((tc_852 / 60D)))))), ((V)(s_868))));
Set(E_851, "smile", ((V)(s_868)));
}
tm_853 = (ToNum(t_850) - ToNum(missT_100));
if (((tm_853 < 600D) && (tc_852 > 700D))) {
double s_869 = 0;
s_869 = FdLibm.Sin(((tm_853 / 600D) * System.Math.PI));
OpSet(E_851, "sq", 0, ((V)((0.05 * s_869))));
OpSet(E_851, "armL", 1, ((V)((14D * s_869))));
OpSet(E_851, "armR", 1, ((V)((14D * s_869))));
}
Invoke(me_91, "pose", E_851);
Invoke(me_91, "yaw", ((V)((((180D - ((PH0_65 * 57.3) * 0.8)) + (FdLibm.Sin((ToNum(t_850) / 900D)) * 4D)) + (ToNum(Get(E_851, "tilt")) * 0.6)))));
return default;
}, 1, "poseMe", false);
pawsAt_117 = Fn((V _self870, int _argc871, V _a873, V _a874, V _a875, V _a876, V[] _rest872) => {
V I_877 = default;
V L_878 = default;
V R_879 = default;
V sz_880 = default;
double sx_881 = 0;
double sy_882 = 0;
V z_883 = default;
V p0_884 = default;
if (_self870.IsNullish) _self870 = GlobalV;
I_877 = Get(me_91, "I");
L_878 = ((I_877 is var _t885 && !Truthy(_t885) ? _t885 : Get(I_877, "W")) is var _t886 && !Truthy(_t886) ? _t886 : Get(Get(I_877, "W"), "pawL"));
R_879 = ((I_877 is var _t887 && !Truthy(_t887) ? _t887 : Get(I_877, "W")) is var _t888 && !Truthy(_t888) ? _t888 : Get(Get(I_877, "W"), "pawR"));
if (((!(Truthy(L_878)) || !(Truthy(R_879))) || !(IsFiniteV(Add(Add(Add(GetIdx(L_878, 0D), GetIdx(L_878, 1D)), GetIdx(R_879, 0D)), GetIdx(R_879, 1D)))))) {
return V.Null;
}
sz_880 = Get(me_91, "size");
sx_881 = ((ToNum(Get(me_91, "x")) - (ToNum(sz_880) / 2D)) + ((ToNum(Add(GetIdx(L_878, 0D), GetIdx(R_879, 0D))) / 200D) * ToNum(sz_880)));
sy_882 = ((ToNum(Get(me_91, "y")) - (ToNum(sz_880) * 0.93)) + ((ToNum(Add(GetIdx(L_878, 1D), GetIdx(R_879, 1D))) / 200D) * ToNum(sz_880)));
z_883 = GetIdx(HOLD_55, 2D);
p0_884 = Call(P_41, V.Undef, ((V)(0D)), ((V)(0D)), z_883);
return Arr(((V)(((sx_881 - ToNum(GetIdx(p0_884, 0D))) / ToNum(GetIdx(p0_884, 2D))))), ((V)((((ToNum(GetIdx(p0_884, 1D)) - sy_882) / ToNum(GetIdx(p0_884, 2D))) + (BR_43 * 0.3)))), z_883);
return default;
}, 0, "pawsAt", false);
{ V _t889 = ctx_36;
if (_t889.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t889));
{ V _t890 = Get(_t889, "bg");
bg_37 = _t890; }
{ V _t891 = Get(_t889, "fg");
fg_38 = _t891; }
{ V _t892 = Get(_t889, "W");
W_39 = _t892; }
{ V _t893 = Get(_t889, "H");
H_40 = _t893; } }
P_41 = Invoke(YG_16, "cam", ((V)(2.4)), ((V)(1.9)), ((V)(166D)), ((V)(112D)));
G_42 = 9.8;
BR_43 = 0.12;
RR_44 = 0.23;
RT_45 = 0.018;
RY_46 = 3.05;
RZ_47 = 5D;
BZ_48 = 5.38;
PZ_49 = 5.72;
GZ_50 = 7.6;
DW_51 = 1.8;
FZ_52 = 0.95;
PX_53 = 0D;
TH_54 = ((62D * System.Math.PI) / 180D);
HOLD_55 = Arr(((V)(PX_53)), ((V)(1D)), ((V)((0.36 + FZ_52))));
REL_56 = Arr(((V)(PX_53)), ((V)(1.34)), ((V)((0.44 + FZ_52))));
THROW_57 = 120D;
PULL_58 = 95D;
DT_59 = (1D / 240D);
LIFE_60 = 3.2;
SM_61 = Get(YG_16, "SM");
eo_62 = Fn((V _arrowThis901, int _argc894, V u_900, V _a897, V _a898, V _a899, V[] _rest895) => {
return ((V)((1D - ((1D - ToNum(u_900)) * (1D - ToNum(u_900))))));
}, 1, "", true);
ei_63 = Fn((V _arrowThis909, int _argc902, V u_908, V _a905, V _a906, V _a907, V[] _rest903) => {
return ((V)((ToNum(u_908) * ToNum(u_908))));
}, 1, "", true);
L0_64 = Hypot((0D - ToNum(GetIdx(REL_56, 0D))), ((RZ_47 + 0.03) - ToNum(GetIdx(REL_56, 2D))));
PH0_65 = FdLibm.Atan2((0D - ToNum(GetIdx(REL_56, 0D))), ((RZ_47 + 0.03) - ToNum(GetIdx(REL_56, 2D))));
vMid_66 = Call(Fn((V _arrowThis916, int _argc910, V _a912, V _a913, V _a914, V _a915, V[] _rest911) => {
double dz_917 = 0;
double dy_918 = 0;
double ct_919 = 0;
dz_917 = L0_64;
dy_918 = (RY_46 - ToNum(GetIdx(REL_56, 1D)));
ct_919 = FdLibm.Cos(TH_54);
return ((V)(System.Math.Sqrt((((G_42 * dz_917) * dz_917) / (((2D * ct_919) * ct_919) * ((dz_917 * FdLibm.Tan(TH_54)) - dy_918))))));
return default;
}, 0, "", true), V.Undef);
vOf_67 = Fn((V _arrowThis927, int _argc920, V k_926, V _a923, V _a924, V _a925, V[] _rest921) => {
return ((V)((ToNum(vMid_66) * (0.94 + (0.12 * ToNum(k_926))))));
}, 1, "", true);
AMP_68 = 0.75;
W1_69 = 0.9;
W2_70 = 1.35;
M_71 = NewObj(2).Put("t1", ((V)(double.PositiveInfinity))).Put("t2", ((V)(double.PositiveInfinity))).V;
hxAt_72 = Fn((V _arrowThis935, int _argc928, V t_934, V _a931, V _a932, V _a933, V[] _rest929) => {
double a_936 = 0;
double ph_937 = 0;
if (Truthy((Get(api_118, "_still") is var _t938 && Truthy(_t938) ? _t938 : (Le(t_934, Get(M_71, "t1")) ? V.True : V.False)))) {
return ((V)(0D));
}
a_936 = (AMP_68 * Min(1D, ((ToNum(t_934) - ToNum(Get(M_71, "t1"))) / 1500D)));
ph_937 = (Le(t_934, Get(M_71, "t2")) ? (((ToNum(t_934) - ToNum(Get(M_71, "t1"))) / 1000D) * W1_69) : ((((ToNum(Get(M_71, "t2")) - ToNum(Get(M_71, "t1"))) / 1000D) * W1_69) + (((ToNum(t_934) - ToNum(Get(M_71, "t2"))) / 1000D) * W2_70)));
return ((V)((FdLibm.Sin(ph_937) * a_936)));
return default;
}, 1, "", true);
court_73 = Call(S_17, V.Undef, ((V)("svg")), NewObj(3).Put("viewBox", ((V)(JsStrBuf.Begin().S("0 0 ").V(W_39).S(" ").V(H_40).End()))).Put("class", ((V)("yg-layer"))).Put("preserveAspectRatio", ((V)("none"))).V);
Invoke(Get(bg_37, "parentNode"), "insertBefore", court_73, bg_37);
Call(drawCourt_74, V.Undef, court_73);
shG_75 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_37);
hoopG_76 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_37);
backG_77 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, hoopG_76);
slotB_78 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, hoopG_76);
frontG_79 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, hoopG_76);
pathG_80 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_37);
slotH_81 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_37);
bandG_82 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, fg_38);
{
V d_939 = default;
d_939 = Call(S_17, V.Undef, ((V)("defs")), NewObj(0).V, bg_37);
Set(d_939, "innerHTML", ((V)(string.Concat("<linearGradient id=\"hcPole\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#2c2c36\"/><stop offset=\"0.45\" stop-color=\"#6a6a7a\"/><stop offset=\"1\" stop-color=\"#2c2c36\"/></linearGradient>", "<linearGradient id=\"hcPad\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#1f4fa8\"/><stop offset=\"0.45\" stop-color=\"#3f7fe0\"/><stop offset=\"1\" stop-color=\"#1f4fa8\"/></linearGradient>", "<linearGradient id=\"hcBoard\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.92\"/><stop offset=\"1\" stop-color=\"#d9ecf8\" stop-opacity=\"0.92\"/></linearGradient>"))));
}
hx_83 = ((V)(0D));
netSw_84 = 0D;
netAt_85 = ((V)((-9D)));
lastHx_86 = V.Null;
posAt_90 = Fn((V _arrowThis948, int _argc940, V S1_946, V t_947, V _a944, V _a945, V[] _rest941) => {
V f_949 = default;
double i_950 = 0;
double u_951 = 0;
V A_952 = default;
V B_953 = default;
f_949 = Call(cl_18, V.Undef, ((V)((ToNum(t_947) / DT_59))), ((V)(0D)), ((V)((ToNum(Get(Get(S1_946, "pos"), "length")) - 1.001))));
i_950 = System.Math.Floor(ToNum(f_949));
u_951 = (ToNum(f_949) - i_950);
A_952 = GetIdx(Get(S1_946, "pos"), i_950);
B_953 = GetIdx(Get(S1_946, "pos"), (i_950 + 1D));
return Arr(Call(lerp_19, V.Undef, GetIdx(A_952, 0D), GetIdx(B_953, 0D), ((V)(u_951))), Call(lerp_19, V.Undef, GetIdx(A_952, 1D), GetIdx(B_953, 1D), ((V)(u_951))), Call(lerp_19, V.Undef, GetIdx(A_952, 2D), GetIdx(B_953, 2D), ((V)(u_951))));
return default;
}, 2, "", true);
me_91 = Invoke(ctx_36, "creature", Get(ctx_36, "playerKey"), NewObj(1).Put("yaw", ((V)(180D))).V);
f0_92 = Call(P_41, V.Undef, ((V)(PX_53)), ((V)(0D)), ((V)((0.25 + FZ_52))));
Invoke(me_91, "set", GetIdx(f0_92, 0D), GetIdx(f0_92, 1D), ((V)((1.12 * ToNum(GetIdx(f0_92, 2D))))));
meSh_93 = Invoke(YG_16, "shadow", shG_75, Add(GetIdx(f0_92, 0D), ((V)(((10D * ToNum(GetIdx(f0_92, 2D))) / 101.4)))), ((V)((ToNum(GetIdx(f0_92, 1D)) - 2D))), ((V)(((46D * ToNum(GetIdx(f0_92, 2D))) / 101.4))), ((V)(0.2)));
balls_94 = Arr();
held_95 = V.Null;
nextAt_96 = ((V)(0D));
streak_97 = 0D;
fire_98 = 0D;
cheerT_99 = ((V)((-9D)));
missT_100 = ((V)((-9D)));
made_101 = 0D;
tNow_102 = ((V)(0D));
aim_103 = V.Null;
thr_104 = V.Null;
lastThrow_105 = V.Null;
clangAt_106 = ((V)(0D));
api_118 = NewObj(16).Put("start", Fn((V _self954, int _argc955, V _a957, V _a958, V _a959, V _a960, V[] _rest956) => {
if (_self954.IsNullish) _self954 = GlobalV;
if (!(Truthy(held_95))) {
held_95 = Call(mkBall_107, V.Undef);
}
Invoke(balls_94, "forEach", Fn((V _arrowThis968, int _argc961, V b_967, V _a964, V _a965, V _a966, V[] _rest962) => {
Invoke(Get(b_967, "g"), "remove");
Invoke(Get(b_967, "sh"), "remove");
return default;
}, 1, "", true));
balls_94 = Arr();
streak_97 = 0D;
fire_98 = 0D;
made_101 = 0D;
Set(M_71, "t1", Set(M_71, "t2", ((V)(double.PositiveInfinity))));
hx_83 = ((V)(0D));
lastHx_86 = V.Null;
aim_103 = V.Null;
thr_104 = V.Null;
Call(drawPath_110, V.Undef, V.Null);
return default;
}, 0, "start", false)).Put("down", Fn((V _self969, int _argc970, V p_976, V _a973, V _a974, V _a975, V[] _rest971) => {
if (_self969.IsNullish) _self969 = GlobalV;
aim_103 = NewObj(6).Put("x0", Get(p_976, "x")).Put("y0", Get(p_976, "y")).Put("x", Get(p_976, "x")).Put("y", Get(p_976, "y")).Put("p", V.Null).Put("S", V.Null).V;
return default;
}, 1, "down", false)).Put("move", Fn((V _self977, int _argc978, V p_984, V _a981, V _a982, V _a983, V[] _rest979) => {
if (_self977.IsNullish) _self977 = GlobalV;
if (!(Truthy(aim_103))) {
return default;
}
Set(aim_103, "x", Get(p_984, "x"));
Set(aim_103, "y", Get(p_984, "y"));
return default;
}, 1, "move", false)).Put("up", Fn((V _self985, int _argc986, V p_992, V _a989, V _a990, V _a991, V[] _rest987) => {
V pp_993 = default;
V S0_994 = default;
if (_self985.IsNullish) _self985 = GlobalV;
if (!(Truthy(aim_103))) {
return default;
}
if (Truthy(p_992)) {
Set(aim_103, "x", Get(p_992, "x"));
Set(aim_103, "y", Get(p_992, "y"));
}
if (Truthy(((!(Truthy(held_95)) ? V.True : V.False) is var _t995 && Truthy(_t995) ? _t995 : thr_104))) {
aim_103 = V.Null;
Call(drawPath_110, V.Undef, V.Null);
return default;
}
pp_993 = Call(pullOf_109, V.Undef, NewObj(2).Put("x", ((V)((ToNum(Get(aim_103, "x")) - ToNum(Get(aim_103, "x0")))))).Put("y", ((V)((ToNum(Get(aim_103, "y")) - ToNum(Get(aim_103, "y0")))))).V);
S0_994 = Get(aim_103, "S");
if (!(Truthy(pp_993))) {
aim_103 = V.Null;
Call(drawPath_110, V.Undef, V.Null);
return default;
}
Call(release_111, V.Undef, Get(pp_993, "k"), Get(pp_993, "a"), S0_994);
return default;
}, 1, "up", false)).Put("key", Fn((V _self996, int _argc997, V k_1003, V dn_1004, V _a1001, V _a1002, V[] _rest998) => {
if (_self996.IsNullish) _self996 = GlobalV;
if (Truthy((dn_1004 is var _t1005 && !Truthy(_t1005) ? _t1005 : ((SEqS(k_1003, " ") || SEqS(k_1003, "ArrowUp")) ? V.True : V.False)))) {
if (Truthy((held_95 is var _t1006 && !Truthy(_t1006) ? _t1006 : (!(Truthy(thr_104)) ? V.True : V.False)))) {
Call(release_111, V.Undef, ((V)(0.5)), ((V)(0D)));
}
return (true ? V.True : V.False);
}
return default;
}, 2, "key", false)).Put("_aim", Fn((V _arrowThis1015, int _argc1007, V k_1013, V a_1014, V _a1011, V _a1012, V[] _rest1008) => {
aim_103 = NewObj(6).Put("x0", ((V)((ToNum(W_39) / 2D)))).Put("y0", ((V)((ToNum(H_40) * 0.45)))).Put("x", ((V)(((ToNum(W_39) / 2D) - (ToNum(a_1014) * 60D))))).Put("y", ((V)((((ToNum(H_40) * 0.45) + 16D) + (ToNum(k_1013) * PULL_58))))).Put("p", NewObj(2).Put("k", k_1013).Put("a", a_1014).V).Put("S", V.Null).V;
return default;
}, 2, "_aim", true)).Put("_shoot", Fn((V _arrowThis1024, int _argc1016, V k_1022, V a_1023, V _a1020, V _a1021, V[] _rest1017) => {
if (Truthy((held_95 is var _t1025 && !Truthy(_t1025) ? _t1025 : (!(Truthy(thr_104)) ? V.True : V.False)))) {
Call(release_111, V.Undef, k_1022, (a_1023.IsNullish ? ((V)(0D)) : a_1023));
}
return default;
}, 2, "_shoot", true)).Put("_sim", Fn((V _arrowThis1035, int _argc1026, V k_1032, V a_1033, V tL_1034, V _a1031, V[] _rest1027) => {
V S1_1036 = default;
S1_1036 = Call(sim_89, V.Undef, k_1032, a_1033, (tL_1034.IsNullish ? tNow_102 : tL_1034));
return NewObj(2).Put("scored", Get(S1_1036, "scored")).Put("swish", Get(S1_1036, "swish")).V;
return default;
}, 3, "_sim", true)).Put("_balls", Fn((V _arrowThis1043, int _argc1037, V _a1039, V _a1040, V _a1041, V _a1042, V[] _rest1038) => {
return Invoke(balls_94, "map", Fn((V _arrowThis1051, int _argc1044, V b_1050, V _a1047, V _a1048, V _a1049, V[] _rest1045) => {
return Arr(Get(Get(b_1050, "S"), "scored"), Get(b_1050, "fired"));
}, 1, "", true));
}, 0, "_balls", true)).Put("_M", M_71).Put("_still", (false ? V.True : V.False)).Put("_ready", Fn((V _arrowThis1058, int _argc1052, V _a1054, V _a1055, V _a1056, V _a1057, V[] _rest1053) => {
return (((!(!(Truthy(held_95))) && !(Truthy(thr_104))) && !(Truthy(aim_103))) ? V.True : V.False);
}, 0, "_ready", true)).Put("timeUp", Fn((V _self1059, int _argc1060, V _a1062, V _a1063, V _a1064, V _a1065, V[] _rest1061) => {
if (_self1059.IsNullish) _self1059 = GlobalV;
aim_103 = V.Null;
Call(drawPath_110, V.Undef, V.Null);
Invoke(ctx_36, "finish", NewObj(1).Put("sub", ((V)(JsStrBuf.Begin().N(made_101).S(" basket").S(((made_101 == 1D) ? "" : "s")).End()))).V);
return default;
}, 0, "timeUp", false)).Put("celebrate", Fn((V _self1066, int _argc1067, V st_1073, V _a1070, V _a1071, V _a1072, V[] _rest1068) => {
if (_self1066.IsNullish) _self1066 = GlobalV;
if (GeN(st_1073, 2D)) {
cheerT_99 = tNow_102;
}
return default;
}, 1, "celebrate", false)).Put("destroy", Fn((V _self1074, int _argc1075, V _a1077, V _a1078, V _a1079, V _a1080, V[] _rest1076) => {
if (_self1074.IsNullish) _self1074 = GlobalV;
Invoke(court_73, "remove");
return default;
}, 0, "destroy", false)).Put("update", Fn((V _self1081, int _argc1082, V dt_1088, V t_1089, V _a1086, V _a1087, V[] _rest1083) => {
if (_self1081.IsNullish) _self1081 = GlobalV;
tNow_102 = t_1089;
hx_83 = Call(hxAt_72, V.Undef, t_1089);
Call(schedule_115, V.Undef);
if (Truthy(((((!(Truthy(held_95)) && !(Truthy(thr_104))) && Gt(t_1089, nextAt_96)) ? V.True : V.False) is var _t1090 && !Truthy(_t1090) ? _t1090 : Get(ctx_36, "playing")))) {
held_95 = Call(mkBall_107, V.Undef);
Set(held_95, "pop", ((V)(0D)));
}
if (Truthy((held_95 is var _t1091 && !Truthy(_t1091) ? _t1091 : (!Get(held_95, "pop").IsNullish ? V.True : V.False)))) {
Set(held_95, "pop", ((V)(Min(1D, ((ToNum(t_1089) - ToNum(Get(held_95, "born"))) / 220D)))));
if (GeN(Get(held_95, "pop"), 1D)) {
Set(held_95, "pop", V.Null);
}
}
if (Truthy(((aim_103 is var _t1092 && !Truthy(_t1092) ? _t1092 : held_95) is var _t1093 && !Truthy(_t1093) ? _t1093 : (!(Truthy(thr_104)) ? V.True : V.False)))) {
V pp_1094 = default;
pp_1094 = Call(pullOf_109, V.Undef, NewObj(2).Put("x", ((V)((ToNum(Get(aim_103, "x")) - ToNum(Get(aim_103, "x0")))))).Put("y", ((V)((ToNum(Get(aim_103, "y")) - ToNum(Get(aim_103, "y0")))))).V);
Set(aim_103, "p", pp_1094);
if (Truthy(pp_1094)) {
Set(aim_103, "S", Call(sim_89, V.Undef, Get(pp_1094, "k"), Get(pp_1094, "a"), Add(t_1089, ((V)(THROW_57)))));
Call(drawPath_110, V.Undef, Get(aim_103, "S"));
} else {
Set(aim_103, "S", V.Null);
Set(pathG_80, "innerHTML", ((V)("")));
Set(bandG_82, "innerHTML", ((V)("")));
Call(S_17, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_20, V.Undef, Get(aim_103, "x0"))).Put("cy", Call(r2_20, V.Undef, Get(aim_103, "y0"))).Put("r", ((V)(6D))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.6))).V, bandG_82);
}
}
if (Truthy((thr_104 is var _t1095 && !Truthy(_t1095) ? _t1095 : (Ge(t_1089, Get(thr_104, "tL")) ? V.True : V.False)))) {
Call(launch_112, V.Undef);
}
if (Truthy(held_95)) {
if (Truthy(thr_104)) {
V u_1096 = default;
V e_1097 = default;
u_1096 = Call(cl_18, V.Undef, ((V)(((ToNum(t_1089) - ToNum(Get(thr_104, "t0"))) / Max(1D, (ToNum(Get(thr_104, "tL")) - ToNum(Get(thr_104, "t0"))))))), ((V)(0D)), ((V)(1D)));
e_1097 = Call(ei_63, V.Undef, u_1096);
Set(held_95, "x", Call(lerp_19, V.Undef, GetIdx(Get(thr_104, "from"), 0D), GetIdx(REL_56, 0D), e_1097));
Set(held_95, "y", Call(lerp_19, V.Undef, GetIdx(Get(thr_104, "from"), 1D), GetIdx(REL_56, 1D), e_1097));
Set(held_95, "z", Call(lerp_19, V.Undef, GetIdx(Get(thr_104, "from"), 2D), GetIdx(REL_56, 2D), e_1097));
} else {
V kk_1098 = default;
V pw_1099 = default;
kk_1098 = (Get(held_95, "kk") is var _t1100 && Truthy(_t1100) ? _t1100 : ((V)(0D)));
pw_1099 = Call(pawsAt_117, V.Undef);
if (Truthy(pw_1099)) {
Set(held_95, "x", GetIdx(pw_1099, 0D));
Set(held_95, "y", GetIdx(pw_1099, 1D));
Set(held_95, "z", GetIdx(pw_1099, 2D));
} else {
Set(held_95, "x", GetIdx(HOLD_55, 0D));
Set(held_95, "y", ((V)(((ToNum(GetIdx(HOLD_55, 1D)) - (0.22 * ToNum(kk_1098))) + ((FdLibm.Sin((ToNum(t_1089) / 400D)) * 0.012) * (1D - ToNum(kk_1098)))))));
Set(held_95, "z", ((V)((ToNum(GetIdx(HOLD_55, 2D)) - (0.05 * ToNum(kk_1098))))));
}
Set(held_95, "fire", ((V)(((fire_98 > 0D) ? 1D : 0D))));
}
}
{
foreach (V _k1101 in new JsIter(balls_94)) {
V b_1102 = default;
b_1102 = _k1101;
double tt_1103 = 0;
V p_1104 = default;
V behind_1105 = default;
V lay_1106 = default;
tt_1103 = ((ToNum(t_1089) - ToNum(Get(b_1102, "tl"))) / 1000D);
p_1104 = Call(posAt_90, V.Undef, Get(b_1102, "S"), ((V)(tt_1103)));
Set(b_1102, "x", GetIdx(p_1104, 0D));
Set(b_1102, "y", GetIdx(p_1104, 1D));
Set(b_1102, "z", GetIdx(p_1104, 2D));
Set(b_1102, "spin", ((V)((tt_1103 * 9D))));
while ((Lt(Get(b_1102, "fired"), Get(Get(Get(b_1102, "S"), "ev"), "length")) && LeN(GetIdx(GetK(Get(Get(b_1102, "S"), "ev"), Get(b_1102, "fired")), 0D), tt_1103))) {
V e_1107 = default;
e_1107 = GetIdx(GetIdx(Get(Get(b_1102, "S"), "ev"), IncM(b_1102, "fired", 1D, false)), 1D);
if (SEqS(e_1107, "rim")) {
if (((ToNum(t_1089) - ToNum(clangAt_106)) > 120D)) {
Invoke(SFX_21, "clang");
clangAt_106 = t_1089;
}
} else {
if ((SEqS(e_1107, "board") || SEqS(e_1107, "ground"))) {
Invoke(SFX_21, "thud");
} else {
if (SEqS(e_1107, "basket")) {
Call(basket_113, V.Undef, b_1102);
}
}
}
}
if (((!(Truthy(Get(Get(b_1102, "S"), "scored"))) && !(Truthy(Get(b_1102, "missed")))) && ((tt_1103 >= 2.2) || (GeN(Get(Get(b_1102, "S"), "tGround"), 0D) && Ge(((V)(tt_1103)), Get(Get(b_1102, "S"), "tGround")))))) {
Set(b_1102, "missed", ((V)(1D)));
Call(missed_114, V.Undef);
}
behind_1105 = ((GtN(Get(b_1102, "z"), (RZ_47 - 0.3)) && LtN(Get(b_1102, "y"), (RY_46 + 0.9))) ? V.True : V.False);
lay_1106 = (Truthy(behind_1105) ? slotB_78 : slotH_81);
if (!SEq(Get(Get(b_1102, "g"), "parentNode"), lay_1106)) {
Invoke(lay_1106, "appendChild", Get(b_1102, "g"));
}
if (Truthy(((Get(b_1102, "fire") is var _t1108 && !Truthy(_t1108) ? _t1108 : (LtN(Invoke(G("Math"), "random"), 0.5) ? V.True : V.False)) is var _t1109 && !Truthy(_t1109) ? _t1109 : ((tt_1103 < 1.2) ? V.True : V.False)))) {
V s_1110 = default;
s_1110 = Call(P_41, V.Undef, Get(b_1102, "x"), Get(b_1102, "y"), Get(b_1102, "z"));
Invoke(ctx_36, "burst", GetIdx(s_1110, 0D), GetIdx(s_1110, 1D), ((V)("spark")), ((V)(1D)), NewObj(4).Put("v", ((V)(30D))).Put("life", ((V)(0.4))).Put("g", ((V)((-40D)))).Put("col", ((V)("#ffb03a"))).V);
}
}
}
balls_94 = Invoke(balls_94, "filter", Fn((V _arrowThis1118, int _argc1111, V b_1117, V _a1114, V _a1115, V _a1116, V[] _rest1112) => {
if ((((ToNum(t_1089) - ToNum(Get(b_1117, "tl"))) / 1000D) > LIFE_60)) {
Invoke(Get(b_1117, "g"), "remove");
Invoke(Get(b_1117, "sh"), "remove");
return (false ? V.True : V.False);
}
return (true ? V.True : V.False);
return default;
}, 1, "", true));
Call(poseMe_116, V.Undef, t_1089);
Call(drawHoop_87, V.Undef, t_1089);
{
foreach (V _k1119 in new JsIter(new ArrBuilder().Add(held_95).Spread(balls_94).V)) {
V b_1120 = default;
b_1120 = _k1119;
if (Truthy(b_1120)) {
Call(drawBall_108, V.Undef, b_1120, t_1089);
}
}
}
return default;
}, 2, "update", false)).V;
Call(drawHoop_87, V.Undef, ((V)(0D)));
held_95 = Call(mkBall_107, V.Undef);
return api_118;
return default;
}, 1, "make", false)).V);
return default;
}, 0, "", true);
Call(go_8, V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
