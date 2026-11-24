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
go_8 = Fn((V _self1, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_15 = default;
V S_16 = default;
V cl_17 = default;
V lerp_18 = default;
V r2_19 = default;
V SFX_20 = default;
V ICON_21 = default;
YG_15 = Get(G("window"), "YardGames");
if (((!(Truthy(YG_15)) || !(Truthy(Get(YG_15, "add")))) || !(Truthy(Get(YG_15, "cam"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t22 = YG_15;
if (_t22.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t22));
{ V _t23 = Get(_t22, "S");
S_16 = _t23; }
{ V _t24 = Get(_t22, "cl");
cl_17 = _t24; }
{ V _t25 = Get(_t22, "lerp");
lerp_18 = _t25; }
{ V _t26 = Get(_t22, "r2");
r2_19 = _t26; }
{ V _t27 = Get(_t22, "SFX");
SFX_20 = _t27; } }
ICON_21 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#cfeaff\"/><rect y=\"58\" width=\"120\" height=\"26\" fill=\"#9fdc6e\"/><path d=\"M14 84L36 58H84L106 84Z\" fill=\"#d9d4cc\"/>", "<rect x=\"57\" y=\"22\" width=\"5\" height=\"40\" rx=\"2\" fill=\"#3a3a44\"/><rect x=\"38\" y=\"8\" width=\"44\" height=\"28\" rx=\"3\" fill=\"#fff\" stroke=\"#e8483c\" stroke-width=\"2.5\"/><rect x=\"51\" y=\"18\" width=\"18\" height=\"12\" fill=\"none\" stroke=\"#e8483c\" stroke-width=\"2\"/>", "<ellipse cx=\"60\" cy=\"34\" rx=\"10\" ry=\"3\" fill=\"none\" stroke=\"#f07a2e\" stroke-width=\"2.4\"/><path d=\"M51 35L54 46H66L69 35M55 35L57 46M65 35L63 46M60 35V46\" stroke=\"#fff\" stroke-width=\"1.2\" fill=\"none\"/>", "<circle cx=\"34\" cy=\"40\" r=\"9\" fill=\"#f07a2e\"/><path d=\"M25 40H43M34 31V49M27.5 33.5Q34 40 27.5 46.5M40.5 33.5Q34 40 40.5 46.5\" stroke=\"#7a3410\" stroke-width=\"1.2\" fill=\"none\"/></svg>")));
Invoke(YG_15, "add", NewObj(12).Put("id", ((V)("hoop"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Hoop Shot"))).Put("item", ((V)("Basketball Hoop"))).Put("color", ((V)("#ff9a4a"))).Put("icon", ICON_21).Put("dur", ((V)(45D))).Put("stars", Arr(((V)(30D)), ((V)(60D)), ((V)(100D)))).Put("coinK", ((V)(0.35))).Put("hint", ((V)("Pull back to aim \u00b7 green = it goes in \u00b7 let go to throw"))).Put("how", Arr(((V)("Pull back from anywhere, like a slingshot. Farther = harder; to the side = aim the other way.")), ((V)("GREEN path = it goes in, RED = it misses. Let go to throw!")), ((V)("Swish 3, rim or bank 2. Every basket adds 10 seconds! Three in a row = on fire. At 20 points the hoop starts to move.")))).Put("make", Fn((V _self28, int _argc29, V ctx_35, V _a32, V _a33, V _a34, V[] _rest30) => {
V bg_36 = default;
V fg_37 = default;
V W_38 = default;
V H_39 = default;
V P_40 = default;
double G_41 = 0;
double BR_42 = 0;
double RR_43 = 0;
double RT_44 = 0;
double RY_45 = 0;
double RZ_46 = 0;
double BZ_47 = 0;
double PZ_48 = 0;
double GZ_49 = 0;
double DW_50 = 0;
double FZ_51 = 0;
double PX_52 = 0;
double TH_53 = 0;
V HOLD_54 = default;
V REL_55 = default;
double THROW_56 = 0;
double PULL_57 = 0;
double DT_58 = 0;
double LIFE_59 = 0;
V SM_60 = default;
V eo_61 = default;
V ei_62 = default;
double L0_63 = 0;
double PH0_64 = 0;
V vMid_65 = default;
V vOf_66 = default;
double AMP_67 = 0;
double W1_68 = 0;
double W2_69 = 0;
V M_70 = default;
V hxAt_71 = default;
V court_72 = default;
V drawCourt_73 = default;
V shG_74 = default;
V hoopG_75 = default;
V backG_76 = default;
V slotB_77 = default;
V frontG_78 = default;
V pathG_79 = default;
V slotH_80 = default;
V bandG_81 = default;
V hx_82 = default;
double netSw_83 = 0;
V netAt_84 = default;
V lastHx_85 = default;
V drawHoop_86 = default;
V stepB_87 = default;
V sim_88 = default;
V posAt_89 = default;
V me_90 = default;
V f0_91 = default;
V meSh_92 = default;
V balls_93 = default;
V held_94 = default;
V nextAt_95 = default;
double streak_96 = 0;
double fire_97 = 0;
V cheerT_98 = default;
V missT_99 = default;
double made_100 = 0;
V tNow_101 = default;
V aim_102 = default;
V thr_103 = default;
V lastThrow_104 = default;
V clangAt_105 = default;
V mkBall_106 = default;
V drawBall_107 = default;
V pullOf_108 = default;
V drawPath_109 = default;
V release_110 = default;
V launch_111 = default;
V basket_112 = default;
V missed_113 = default;
V schedule_114 = default;
V poseMe_115 = default;
V pawsAt_116 = default;
V api_117 = default;
if (_self28.IsNullish) _self28 = GlobalV;
drawCourt_73 = Fn((V _self118, int _argc119, V sv_125, V _a122, V _a123, V _a124, V[] _rest120) => {
V q_126 = default;
V ln_127 = default;
V wp_128 = default;
V wr_129 = default;
V k0_130 = default;
V yAt_131 = default;
V yF_132 = default;
V yT_133 = default;
V pa_134 = default;
if (_self118.IsNullish) _self118 = GlobalV;
q_126 = Fn((V _self118, int _argc135, V pts_141, V a_142, V p_143, V _a140, V[] _rest136) => {
return Call(S_16, V.Undef, ((V)("path")), Object_assign(NewObj(1).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_141, "map", Fn((V _self118, int _argc144, V _a146, V _a147, V _a148, V _a149, V[] _rest145) => {
V s_157 = default;
V x_152 = default;
V z_154 = default;
V y_156 = default;
{ V _t150 = ListOf(_a146);
{ V _t151 = GetIdx(_t150, 0D);
x_152 = _t151; }
{ V _t153 = GetIdx(_t150, 1D);
z_154 = _t153; }
{ V _t155 = GetIdx(_t150, 2D);
y_156 = _t155; }
}
s_157 = Call(P_40, V.Undef, x_152, (y_156 is var _t158 && Truthy(_t158) ? _t158 : ((V)(0D))), z_154);
return ((V)(JsStrBuf.Begin().V(Call(r2_19, V.Undef, GetIdx(s_157, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(s_157, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).V, a_142), (p_143 is var _t159 && Truthy(_t159) ? _t159 : sv_125));
}, 3, "", true);
ln_127 = Fn((V _self118, int _argc160, V pts_166, V a_167, V p_168, V _a165, V[] _rest161) => {
return Call(S_16, V.Undef, ((V)("path")), Object_assign(NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_166, "map", Fn((V _self118, int _argc169, V _a171, V _a172, V _a173, V _a174, V[] _rest170) => {
V s_182 = default;
V x_177 = default;
V z_179 = default;
V y_181 = default;
{ V _t175 = ListOf(_a171);
{ V _t176 = GetIdx(_t175, 0D);
x_177 = _t176; }
{ V _t178 = GetIdx(_t175, 1D);
z_179 = _t178; }
{ V _t180 = GetIdx(_t175, 2D);
y_181 = _t180; }
}
s_182 = Call(P_40, V.Undef, x_177, (y_181 is var _t183 && Truthy(_t183) ? _t183 : ((V)(0D))), z_179);
return ((V)(JsStrBuf.Begin().V(Call(r2_19, V.Undef, GetIdx(s_182, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(s_182, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()))).Put("fill", ((V)("none"))).V, a_167), (p_168 is var _t184 && Truthy(_t184) ? _t184 : sv_125));
}, 3, "", true);
wp_128 = Fn((V _self118, int _argc185, V x_191, V y_192, V _a189, V _a190, V[] _rest186) => {
return Call(P_40, V.Undef, x_191, y_192, ((V)(GZ_49)));
}, 2, "", true);
wr_129 = Fn((V _self118, int _argc193, V x0_199, V y0_200, V x1_201, V y1_202, V[] _rest194) => {
V A_205 = default;
V B_206 = default;
V a_203 = default;
V p_204 = default;
a_203 = (_argc193 > 4 ? _rest194[0] : V.Undef);
p_204 = (_argc193 > 5 ? _rest194[1] : V.Undef);
A_205 = Call(wp_128, V.Undef, x0_199, y1_202);
B_206 = Call(wp_128, V.Undef, x1_201, y0_200);
return Call(S_16, V.Undef, ((V)("rect")), Object_assign(NewObj(4).Put("x", Call(r2_19, V.Undef, GetIdx(A_205, 0D))).Put("y", Call(r2_19, V.Undef, GetIdx(A_205, 1D))).Put("width", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(B_206, 0D)) - ToNum(GetIdx(A_205, 0D))))))).Put("height", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(B_206, 1D)) - ToNum(GetIdx(A_205, 1D))))))).V, a_203), (p_204 is var _t207 && Truthy(_t207) ? _t207 : sv_125));
return default;
}, 6, "", true);
k0_130 = GetIdx(Call(P_40, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(GZ_49))), 2D);
Set(Call(S_16, V.Undef, ((V)("defs")), NewObj(0).V, sv_125), "innerHTML", ((V)(JsStrBuf.Begin().S("<linearGradient id=\"hcSky\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#6fbaf2\"/><stop offset=\"0.6\" stop-color=\"#b6e0fb\"/><stop offset=\"1\" stop-color=\"#e8f6ff\"/></linearGradient>").S("<radialGradient id=\"hcSun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fffbe6\" stop-opacity=\"0.95\"/><stop offset=\"0.35\" stop-color=\"#fff2b8\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#ffe9a0\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"hcCon\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#e9e4dc\"/><stop offset=\"1\" stop-color=\"#cdc5b8\"/></linearGradient>").S("<linearGradient id=\"hcLawn\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#8fcf62\"/><stop offset=\"1\" stop-color=\"#4f9a3c\"/></linearGradient>").S("<linearGradient id=\"hcWall\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#f6eedf\"/><stop offset=\"1\" stop-color=\"#e9dcc6\"/></linearGradient>").S("<linearGradient id=\"hcDoor\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fdfaf3\"/><stop offset=\"1\" stop-color=\"#e8e0d0\"/></linearGradient>").S("<linearGradient id=\"hcRoof\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#9a4e3e\"/><stop offset=\"1\" stop-color=\"#c0664e\"/></linearGradient>").S("<linearGradient id=\"hcGlass\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#a9d6f2\"/><stop offset=\"0.5\" stop-color=\"#6aa8d8\"/><stop offset=\"1\" stop-color=\"#3f7fb8\"/></linearGradient>").S("<linearGradient id=\"hcAO\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#3a2a3a\" stop-opacity=\"0.32\"/><stop offset=\"1\" stop-color=\"#3a2a3a\" stop-opacity=\"0\"/></linearGradient>").S("<radialGradient id=\"hcBall\" cx=\"35%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#ffb070\"/><stop offset=\"0.55\" stop-color=\"#f07a2e\"/><stop offset=\"1\" stop-color=\"#b44a14\"/></radialGradient>").S("<filter id=\"hcGrain\" x=\"0\" y=\"0\" width=\"100%\" height=\"100%\"><feTurbulence type=\"fractalNoise\" baseFrequency=\"0.85\" numOctaves=\"3\" seed=\"11\"/><feColorMatrix values=\"0 0 0 0 0.35  0 0 0 0 0.32  0 0 0 0 0.3  0 0 0 0.55 -0.12\"/><feComposite in2=\"SourceGraphic\" operator=\"in\"/></filter>").S("<filter id=\"hcBlur\" x=\"-20%\" y=\"-20%\" width=\"140%\" height=\"140%\"><feGaussianBlur stdDeviation=\"2\"/></filter>").S("<clipPath id=\"hcDrive\"><path d=\"M").V(Invoke(Invoke(Arr(Arr(((V)((-DW_50))), ((V)((-1D)))), Arr(((V)(DW_50)), ((V)((-1D)))), Arr(((V)(DW_50)), ((V)(GZ_49))), Arr(((V)((-DW_50))), ((V)(GZ_49)))), "map", Fn((V _self118, int _argc208, V _a210, V _a211, V _a212, V _a213, V[] _rest209) => {
V s_219 = default;
V x_216 = default;
V z_218 = default;
{ V _t214 = ListOf(_a210);
{ V _t215 = GetIdx(_t214, 0D);
x_216 = _t215; }
{ V _t217 = GetIdx(_t214, 1D);
z_218 = _t217; }
}
s_219 = Call(P_40, V.Undef, x_216, ((V)(0D)), z_218);
return ((V)(JsStrBuf.Begin().V(Call(r2_19, V.Undef, GetIdx(s_219, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(s_219, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z\"/></clipPath>").End())));
yAt_131 = Fn((V _self118, int _argc220, V z_226, V _a223, V _a224, V _a225, V[] _rest221) => {
return GetIdx(Call(P_40, V.Undef, ((V)(0D)), ((V)(0D)), z_226), 1D);
}, 1, "", true);
yF_132 = Call(yAt_131, V.Undef, ((V)(26D)));
yT_133 = Call(yAt_131, V.Undef, ((V)(14D)));
Call(S_16, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_38, ((V)(40D)))).Put("height", Add(yT_133, ((V)(40D)))).Put("fill", ((V)("url(#hcSky)"))).V, sv_125);
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", ((V)(90D))).Put("cy", ((V)(40D))).Put("r", ((V)(130D))).Put("fill", ((V)("url(#hcSun)"))).V, sv_125);
Invoke(Arr(Arr(((V)(110D)), ((V)(52D)), ((V)(0.8))), Arr(((V)(300D)), ((V)(34D)), ((V)(0.6))), Arr(((V)(560D)), ((V)(50D)), ((V)(0.75))), Arr(((V)(700D)), ((V)(24D)), ((V)(0.5))), Arr(((V)(450D)), ((V)(92D)), ((V)(0.42))), Arr(((V)(190D)), ((V)(104D)), ((V)(0.4)))), "forEach", Fn((V _self118, int _argc227, V _a229, V _a230, V _a231, V _a232, V[] _rest228) => {
V g_240 = default;
V x_235 = default;
V y_237 = default;
V k_239 = default;
{ V _t233 = ListOf(_a229);
{ V _t234 = GetIdx(_t233, 0D);
x_235 = _t234; }
{ V _t236 = GetIdx(_t233, 1D);
y_237 = _t236; }
{ V _t238 = GetIdx(_t233, 2D);
k_239 = _t238; }
}
g_240 = Call(S_16, V.Undef, ((V)("g")), NewObj(2).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(x_235).S(" ").V(y_237).S(") scale(").V(k_239).S(")").End()))).Put("opacity", ((V)(0.9))).V, sv_125);
Invoke(Arr(Arr(((V)((-28D))), ((V)(6D)), ((V)(17D))), Arr(((V)((-6D))), ((V)((-6D))), ((V)(24D))), Arr(((V)(20D)), ((V)(0D)), ((V)(20D))), Arr(((V)(38D)), ((V)(8D)), ((V)(13D))), Arr(((V)(4D)), ((V)(10D)), ((V)(18D))), Arr(((V)((-18D))), ((V)(12D)), ((V)(14D)))), "forEach", Fn((V _self118, int _argc241, V _a243, V _a244, V _a245, V _a246, V[] _rest242) => {
V a_249 = default;
V b_251 = default;
V r_253 = default;
{ V _t247 = ListOf(_a243);
{ V _t248 = GetIdx(_t247, 0D);
a_249 = _t248; }
{ V _t250 = GetIdx(_t247, 1D);
b_251 = _t250; }
{ V _t252 = GetIdx(_t247, 2D);
r_253 = _t252; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", a_249).Put("cy", b_251).Put("r", r_253).Put("fill", ((V)("#ffffff"))).V, g_240);
}, 1, "", true));
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)("M-44 18H52"))).Put("stroke", ((V)("#dcefff"))).Put("stroke-width", ((V)(6D))).Put("stroke-linecap", ((V)("round"))).V, g_240);
return default;
}, 1, "", true));
{
JsStrBuf d_254 = null;
d_254 = new JsStrBuf(JsStrBuf.Begin().S("M-20 ").V(Call(r2_19, V.Undef, Add(yF_132, ((V)(6D))))).End());
{
double x_255 = 0;
x_255 = (-20D);
while (true) {
if (!(Le(((V)(x_255)), Add(W_38, ((V)(20D)))))) break;
d_254.S("Q").N((x_255 + 7D)).S(" ").V(Call(r2_19, V.Undef, ((V)(((ToNum(yF_132) - 22D) - ((x_255 * 37D) % 23D)))))).S(" ").N((x_255 + 14D)).S(" ").V(Call(r2_19, V.Undef, ((V)(((ToNum(yF_132) - 12D) - ((x_255 * 53D) % 11D))))));
x_255 = (x_255 + 14D);
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S(d_254.Str).S("V").V(Call(r2_19, V.Undef, Add(yT_133, ((V)(10D))))).S("H-20Z").End()))).Put("fill", ((V)("#8fbf9a"))).Put("opacity", ((V)(0.75))).V, sv_125);
}
Invoke(Arr(Arr(((V)(40D)), ((V)(1D))), Arr(((V)(150D)), ((V)(0.8))), Arr(((V)(640D)), ((V)(1.1))), Arr(((V)(745D)), ((V)(0.85)))), "forEach", Fn((V _self118, int _argc257, V _a259, V _a260, V _a261, V _a262, V[] _rest258) => {
V y_268 = default;
V x_265 = default;
V k_267 = default;
{ V _t263 = ListOf(_a259);
{ V _t264 = GetIdx(_t263, 0D);
x_265 = _t264; }
{ V _t266 = GetIdx(_t263, 1D);
k_267 = _t266; }
}
y_268 = Add(yF_132, ((V)(4D)));
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_265) - (34D * ToNum(k_267)))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(y_268) - (22D * ToNum(k_267))))))).S("L").V(x_265).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(y_268) - (44D * ToNum(k_267))))))).S("L").V(Add(x_265, ((V)((34D * ToNum(k_267)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(y_268) - (22D * ToNum(k_267))))))).S("V").V(Call(r2_19, V.Undef, y_268)).S("H").N((ToNum(x_265) - (34D * ToNum(k_267)))).S("Z").End()))).Put("fill", ((V)("#c9a596"))).Put("opacity", ((V)(0.8))).V, sv_125);
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_265) - (40D * ToNum(k_267)))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(y_268) - (18D * ToNum(k_267))))))).S("L").V(x_265).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(y_268) - (48D * ToNum(k_267))))))).S("L").V(Add(x_265, ((V)((40D * ToNum(k_267)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(y_268) - (18D * ToNum(k_267))))))).End()))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#a87a6a"))).Put("stroke-width", ((V)(3D))).Put("opacity", ((V)(0.8))).V, sv_125);
return default;
}, 1, "", true));
{
JsStrBuf d_269 = null;
d_269 = new JsStrBuf(JsStrBuf.Begin().S("M-20 ").V(Call(r2_19, V.Undef, Add(yT_133, ((V)(8D))))).End());
{
double x_270 = 0;
x_270 = (-20D);
while (true) {
if (!(Le(((V)(x_270)), Add(W_38, ((V)(20D)))))) break;
d_269.S("Q").N((x_270 + 9D)).S(" ").V(Call(r2_19, V.Undef, ((V)(((ToNum(yT_133) - 18D) - ((x_270 * 29D) % 19D)))))).S(" ").N((x_270 + 18D)).S(" ").V(Call(r2_19, V.Undef, ((V)(((ToNum(yT_133) - 6D) - ((x_270 * 41D) % 9D))))));
x_270 = (x_270 + 18D);
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S(d_269.Str).S("V").V(Call(r2_19, V.Undef, Add(yT_133, ((V)(26D))))).S("H-20Z").End()))).Put("fill", ((V)("#5f9e5a"))).V, sv_125);
}
Call(S_16, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", Call(r2_19, V.Undef, yT_133)).Put("width", Add(W_38, ((V)(40D)))).Put("height", H_39).Put("fill", ((V)("url(#hcLawn)"))).V, sv_125);
{
double i_272 = 0;
i_272 = (-18D);
while (true) {
if (!((i_272 <= 18D))) break;
double x0_274 = 0;
x0_274 = (i_272 * 0.9);
Call(q_126, V.Undef, Arr(Arr(((V)(x0_274)), ((V)((-1D)))), Arr(((V)((x0_274 + 0.45))), ((V)((-1D)))), Arr(((V)((x0_274 + 0.45))), ((V)(GZ_49))), Arr(((V)(x0_274)), ((V)(GZ_49)))), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.06))).V);
i_272++;
}
}
Invoke(Arr(Arr(((V)((-11.5))), ((V)((GZ_49 + 2.2))), ((V)(1.15))), Arr(((V)((-7.8))), ((V)((GZ_49 + 3.4))), ((V)(0.9))), Arr(((V)(7.2)), ((V)((GZ_49 + 2.6))), ((V)(1.2))), Arr(((V)(11.8)), ((V)((GZ_49 + 1.6))), ((V)(0.95)))), "forEach", Fn((V _self118, int _argc275, V _a277, V _a278, V _a279, V _a280, V[] _rest276) => {
V p_288 = default;
double k_289 = 0;
V x_283 = default;
V z_285 = default;
V kk_287 = default;
{ V _t281 = ListOf(_a277);
{ V _t282 = GetIdx(_t281, 0D);
x_283 = _t282; }
{ V _t284 = GetIdx(_t281, 1D);
z_285 = _t284; }
{ V _t286 = GetIdx(_t281, 2D);
kk_287 = _t286; }
}
p_288 = Call(P_40, V.Undef, x_283, ((V)(0D)), z_285);
k_289 = (ToNum(GetIdx(p_288, 2D)) * ToNum(kk_287));
Call(S_16, V.Undef, ((V)("rect")), NewObj(5).Put("x", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_288, 0D)) - (0.12 * k_289)))))).Put("y", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_288, 1D)) - (2.2 * k_289)))))).Put("width", Call(r2_19, V.Undef, ((V)((0.24 * k_289))))).Put("height", Call(r2_19, V.Undef, ((V)((2.2 * k_289))))).Put("fill", ((V)("#7a5034"))).V, sv_125);
Invoke(Arr(Arr(((V)((-0.7))), ((V)((-2.4))), ((V)(0.75)), ((V)("#4f9a3e"))), Arr(((V)(0.6)), ((V)((-2.5))), ((V)(0.8)), ((V)("#4f9a3e"))), Arr(((V)(0D)), ((V)((-3.2))), ((V)(0.9)), ((V)("#5aa84a"))), Arr(((V)((-0.3))), ((V)((-3.7))), ((V)(0.55)), ((V)("#66b456")))), "forEach", Fn((V _self118, int _argc290, V _a292, V _a293, V _a294, V _a295, V[] _rest291) => {
V a_298 = default;
V b_300 = default;
V r_302 = default;
V c_304 = default;
{ V _t296 = ListOf(_a292);
{ V _t297 = GetIdx(_t296, 0D);
a_298 = _t297; }
{ V _t299 = GetIdx(_t296, 1D);
b_300 = _t299; }
{ V _t301 = GetIdx(_t296, 2D);
r_302 = _t301; }
{ V _t303 = GetIdx(_t296, 3D);
c_304 = _t303; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, Add(GetIdx(p_288, 0D), ((V)((ToNum(a_298) * k_289)))))).Put("cy", Call(r2_19, V.Undef, Add(GetIdx(p_288, 1D), ((V)((ToNum(b_300) * k_289)))))).Put("r", Call(r2_19, V.Undef, ((V)((ToNum(r_302) * k_289))))).Put("fill", c_304).V, sv_125);
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-17D))), ((V)((-7D)))), Arr(((V)(3.5)), ((V)(17D)))), "forEach", Fn((V _self118, int _argc305, V _a307, V _a308, V _a309, V _a310, V[] _rest306) => {
V x0_313 = default;
V x1_315 = default;
{ V _t311 = ListOf(_a307);
{ V _t312 = GetIdx(_t311, 0D);
x0_313 = _t312; }
{ V _t314 = GetIdx(_t311, 1D);
x1_315 = _t314; }
}
Call(q_126, V.Undef, Arr(Arr(x0_313, ((V)((GZ_49 + 0.4))), ((V)(0D))), Arr(x1_315, ((V)((GZ_49 + 0.4))), ((V)(0D))), Arr(x1_315, ((V)((GZ_49 + 0.4))), ((V)(1.7))), Arr(x0_313, ((V)((GZ_49 + 0.4))), ((V)(1.7)))), NewObj(1).Put("fill", ((V)("#e9d8bd"))).V);
{
V x_316 = default;
x_316 = x0_313;
while (true) {
if (!(Le(x_316, x1_315))) break;
Call(ln_127, V.Undef, Arr(Arr(x_316, ((V)((GZ_49 + 0.4))), ((V)(0D))), Arr(x_316, ((V)((GZ_49 + 0.4))), ((V)(1.72)))), NewObj(2).Put("stroke", ((V)("#cdb796"))).Put("stroke-width", ((V)(1D))).V);
x_316 = Add(x_316, ((V)(0.36)));
}
}
Call(ln_127, V.Undef, Arr(Arr(x0_313, ((V)((GZ_49 + 0.4))), ((V)(1.3))), Arr(x1_315, ((V)((GZ_49 + 0.4))), ((V)(1.3)))), NewObj(2).Put("stroke", ((V)("#cdb796"))).Put("stroke-width", ((V)(1.6))).V);
Call(ln_127, V.Undef, Arr(Arr(x0_313, ((V)((GZ_49 + 0.4))), ((V)(1.7))), Arr(x1_315, ((V)((GZ_49 + 0.4))), ((V)(1.7)))), NewObj(2).Put("stroke", ((V)("#fff4e0"))).Put("stroke-width", ((V)(2D))).V);
return default;
}, 1, "", true));
Call(q_126, V.Undef, Arr(Arr(((V)((-7D))), ((V)(GZ_49)), ((V)(0D))), Arr(((V)(3.5)), ((V)(GZ_49)), ((V)(0D))), Arr(((V)(3.5)), ((V)(GZ_49)), ((V)(2.75))), Arr(((V)((-7D))), ((V)(GZ_49)), ((V)(2.75)))), NewObj(1).Put("fill", ((V)("url(#hcWall)"))).V);
{
V g_318 = default;
g_318 = Call(S_16, V.Undef, ((V)("g")), NewObj(3).Put("stroke", ((V)("#dccdb3"))).Put("stroke-width", ((V)(0.8))).Put("opacity", ((V)(0.9))).V, sv_125);
{
double y_319 = 0;
y_319 = 0.25;
while (true) {
if (!((y_319 < 2.7))) break;
Call(ln_127, V.Undef, Arr(Arr(((V)((-7D))), ((V)(GZ_49)), ((V)(y_319))), Arr(((V)(3.5)), ((V)(GZ_49)), ((V)(y_319)))), NewObj(0).V, g_318);
y_319 = (y_319 + 0.24);
}
}
}
Call(q_126, V.Undef, Arr(Arr(((V)((-7D))), ((V)(GZ_49)), ((V)(0D))), Arr(((V)(3.5)), ((V)(GZ_49)), ((V)(0D))), Arr(((V)(3.5)), ((V)(GZ_49)), ((V)(0.16))), Arr(((V)((-7D))), ((V)(GZ_49)), ((V)(0.16)))), NewObj(1).Put("fill", ((V)("#bdb3a6"))).V);
Call(q_126, V.Undef, Arr(Arr(((V)((-7.2))), ((V)(GZ_49)), ((V)(2.72))), Arr(((V)(3.7)), ((V)(GZ_49)), ((V)(2.72))), Arr(((V)(3.4)), ((V)(GZ_49)), ((V)(3.5))), Arr(((V)((-6.9))), ((V)(GZ_49)), ((V)(3.5)))), NewObj(1).Put("fill", ((V)("url(#hcRoof)"))).V);
{
V g_321 = default;
g_321 = Call(S_16, V.Undef, ((V)("g")), NewObj(3).Put("stroke", ((V)("#8a4434"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.55))).V, sv_125);
{
double y_322 = 0;
y_322 = 2.9;
while (true) {
if (!((y_322 < 3.5))) break;
Call(ln_127, V.Undef, Arr(Arr(((V)((-7.1))), ((V)(GZ_49)), ((V)(y_322))), Arr(((V)(3.6)), ((V)(GZ_49)), ((V)(y_322)))), NewObj(0).V, g_321);
y_322 = (y_322 + 0.17);
}
}
}
Call(q_126, V.Undef, Arr(Arr(((V)((-1.9))), ((V)(GZ_49)), ((V)(2.7))), Arr(((V)(1.9)), ((V)(GZ_49)), ((V)(2.7))), Arr(((V)(0D)), ((V)(GZ_49)), ((V)(4.05)))), NewObj(3).Put("fill", ((V)("#f6eedf"))).Put("stroke", ((V)("#dccdb3"))).Put("stroke-width", ((V)(1D))).V);
{
V a_324 = default;
V b_325 = default;
V c_326 = default;
a_324 = Call(wp_128, V.Undef, ((V)((-2.05))), ((V)(2.62)));
b_325 = Call(wp_128, V.Undef, ((V)(0D)), ((V)(4.2)));
c_326 = Call(wp_128, V.Undef, ((V)(2.05)), ((V)(2.62)));
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, GetIdx(a_324, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(a_324, 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(b_325, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(b_325, 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(c_326, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(c_326, 1D))).End()))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#9a4e3e"))).Put("stroke-width", ((V)(4.5))).Put("stroke-linejoin", ((V)("round"))).V, sv_125);
}
{
V v_327 = default;
v_327 = Call(wp_128, V.Undef, ((V)(0D)), ((V)(3.35)));
Call(S_16, V.Undef, ((V)("circle")), NewObj(6).Put("cx", Call(r2_19, V.Undef, GetIdx(v_327, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(v_327, 1D))).Put("r", Call(r2_19, V.Undef, ((V)((0.22 * ToNum(k0_130)))))).Put("fill", ((V)("#e4d6bf"))).Put("stroke", ((V)("#c9b89c"))).Put("stroke-width", ((V)(1D))).V, sv_125);
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(v_327, 0D)) - (0.16 * ToNum(k0_130))))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(v_327, 1D))).S("H").V(Call(r2_19, V.Undef, Add(GetIdx(v_327, 0D), ((V)((0.16 * ToNum(k0_130))))))).S("M").V(Call(r2_19, V.Undef, GetIdx(v_327, 0D))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(v_327, 1D)) - (0.16 * ToNum(k0_130))))))).S("V").V(Call(r2_19, V.Undef, Add(GetIdx(v_327, 1D), ((V)((0.16 * ToNum(k0_130))))))).End()))).Put("stroke", ((V)("#c9b89c"))).Put("stroke-width", ((V)(1D))).V, sv_125);
}
Call(q_126, V.Undef, Arr(Arr(((V)((-7.2))), ((V)(GZ_49)), ((V)(2.68))), Arr(((V)(3.7)), ((V)(GZ_49)), ((V)(2.68))), Arr(((V)(3.7)), ((V)(GZ_49)), ((V)(2.76))), Arr(((V)((-7.2))), ((V)(GZ_49)), ((V)(2.76)))), NewObj(1).Put("fill", ((V)("#e7e2d8"))).V);
Call(wr_129, V.Undef, ((V)((-7D))), ((V)(2.5)), ((V)(3.5)), ((V)(2.68)), NewObj(2).Put("fill", ((V)("#3a2a3a"))).Put("opacity", ((V)(0.08))).V);
Call(wr_129, V.Undef, ((V)(3.18)), ((V)(0.1)), ((V)(3.3)), ((V)(2.7)), NewObj(3).Put("fill", ((V)("#e2ddd2"))).Put("stroke", ((V)("#c9c2b4"))).Put("stroke-width", ((V)(0.6))).V);
Call(wr_129, V.Undef, ((V)((-1.35))), ((V)(0D)), ((V)(1.35)), ((V)(2.22)), NewObj(1).Put("fill", ((V)("#e6dccb"))).V);
Call(wr_129, V.Undef, ((V)((-1.25))), ((V)(0D)), ((V)(1.25)), ((V)(2.12)), NewObj(1).Put("fill", ((V)("url(#hcDoor)"))).V);
{
double r_328 = 0;
r_328 = 0D;
while (true) {
if (!((r_328 < 4D))) break;
double y0_330 = 0;
double y1_331 = 0;
y0_330 = (r_328 * 0.53);
y1_331 = (y0_330 + 0.53);
Call(ln_127, V.Undef, Arr(Arr(((V)((-1.25))), ((V)(GZ_49)), ((V)(y1_331))), Arr(((V)(1.25)), ((V)(GZ_49)), ((V)(y1_331)))), NewObj(2).Put("stroke", ((V)("#d3c8b4"))).Put("stroke-width", ((V)(1.2))).V);
{
double c_332 = 0;
c_332 = 0D;
while (true) {
if (!((c_332 < 4D))) break;
double x0_334 = 0;
x0_334 = ((-1.18) + (c_332 * 0.6));
if ((r_328 == 3D)) {
Call(wr_129, V.Undef, ((V)((x0_334 + 0.05))), ((V)((y0_330 + 0.14))), ((V)((x0_334 + 0.5))), ((V)((y0_330 + 0.42))), NewObj(3).Put("fill", ((V)("url(#hcGlass)"))).Put("stroke", ((V)("#cfc4b0"))).Put("stroke-width", ((V)(1D))).V);
} else {
Call(wr_129, V.Undef, ((V)((x0_334 + 0.05))), ((V)((y0_330 + 0.1))), ((V)((x0_334 + 0.5))), ((V)((y0_330 + 0.42))), NewObj(3).Put("fill", ((V)("none"))).Put("stroke", ((V)("#d8cdb9"))).Put("stroke-width", ((V)(1D))).V);
}
c_332++;
}
}
r_328++;
}
}
Call(wr_129, V.Undef, ((V)((-0.16))), ((V)(0.5)), ((V)(0.16)), ((V)(0.55)), NewObj(2).Put("fill", ((V)("#9a9488"))).Put("rx", ((V)(1D))).V);
Call(wr_129, V.Undef, ((V)((-2.45))), ((V)(0D)), ((V)((-1.75))), ((V)(2.08)), NewObj(1).Put("fill", ((V)("#7fa3c4"))).V);
Call(wr_129, V.Undef, ((V)((-2.4))), ((V)(0D)), ((V)((-1.8))), ((V)(2.03)), NewObj(1).Put("fill", ((V)("#8fb2d2"))).V);
Call(wr_129, V.Undef, ((V)((-2.3))), ((V)(1.3)), ((V)((-1.9))), ((V)(1.9)), NewObj(1).Put("fill", ((V)("url(#hcGlass)"))).V);
{
V k_335 = default;
k_335 = Call(wp_128, V.Undef, ((V)((-1.88))), ((V)(1D)));
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, GetIdx(k_335, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(k_335, 1D))).Put("r", ((V)(1.6))).Put("fill", ((V)("#e6c060"))).V, sv_125);
}
Call(wr_129, V.Undef, ((V)((-4.9))), ((V)(0.95)), ((V)((-3.5))), ((V)(2.05)), NewObj(1).Put("fill", ((V)("#ffffff"))).V);
Call(wr_129, V.Undef, ((V)((-4.83))), ((V)(1.02)), ((V)((-3.57))), ((V)(1.98)), NewObj(1).Put("fill", ((V)("url(#hcGlass)"))).V);
Call(ln_127, V.Undef, Arr(Arr(((V)((-4.2))), ((V)(GZ_49)), ((V)(1.02))), Arr(((V)((-4.2))), ((V)(GZ_49)), ((V)(1.98)))), NewObj(2).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.6))).V);
Call(ln_127, V.Undef, Arr(Arr(((V)((-4.83))), ((V)(GZ_49)), ((V)(1.5))), Arr(((V)((-3.57))), ((V)(GZ_49)), ((V)(1.5)))), NewObj(2).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.6))).V);
Call(wr_129, V.Undef, ((V)((-5.25))), ((V)(0.95)), ((V)((-4.95))), ((V)(2.05)), NewObj(1).Put("fill", ((V)("#6f8fb0"))).V);
Call(wr_129, V.Undef, ((V)((-3.45))), ((V)(0.95)), ((V)((-3.15))), ((V)(2.05)), NewObj(1).Put("fill", ((V)("#6f8fb0"))).V);
Call(wr_129, V.Undef, ((V)((-4.95))), ((V)(0.8)), ((V)((-3.45))), ((V)(0.95)), NewObj(1).Put("fill", ((V)("#a8764a"))).V);
Invoke(Arr(Arr(((V)((-4.8))), ((V)("#ff6f91"))), Arr(((V)((-4.55))), ((V)("#ffd84a"))), Arr(((V)((-4.3))), ((V)("#ff9fd0"))), Arr(((V)((-4.05))), ((V)("#ffffff"))), Arr(((V)((-3.8))), ((V)("#ff6f91"))), Arr(((V)((-3.6))), ((V)("#ffd84a")))), "forEach", Fn((V _self118, int _argc336, V _a338, V _a339, V _a340, V _a341, V[] _rest337) => {
V p_347 = default;
V x_344 = default;
V col_346 = default;
{ V _t342 = ListOf(_a338);
{ V _t343 = GetIdx(_t342, 0D);
x_344 = _t343; }
{ V _t345 = GetIdx(_t342, 1D);
col_346 = _t345; }
}
p_347 = Call(wp_128, V.Undef, x_344, ((V)(1D)));
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, GetIdx(p_347, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(p_347, 1D))).Put("r", ((V)(2.4))).Put("fill", ((V)("#5fa84c"))).V, sv_125);
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, GetIdx(p_347, 0D))).Put("cy", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_347, 1D)) - 1.5))))).Put("r", ((V)(1.7))).Put("fill", col_346).V, sv_125);
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1.6))), ((V)(1.6))), "forEach", Fn((V _self118, int _argc348, V x_354, V _a351, V _a352, V _a353, V[] _rest349) => {
V p_355 = default;
p_355 = Call(wp_128, V.Undef, x_354, ((V)(1.95)));
Call(S_16, V.Undef, ((V)("rect")), NewObj(6).Put("x", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_355, 0D)) - 2.2))))).Put("y", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_355, 1D)) - 4D))))).Put("width", ((V)(4.4))).Put("height", ((V)(7D))).Put("rx", ((V)(1.4))).Put("fill", ((V)("#3a3a44"))).V, sv_125);
Call(S_16, V.Undef, ((V)("rect")), NewObj(6).Put("x", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_355, 0D)) - 1.4))))).Put("y", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_355, 1D)) - 3D))))).Put("width", ((V)(2.8))).Put("height", ((V)(4.6))).Put("rx", ((V)(0.8))).Put("fill", ((V)("#fff2c4"))).V, sv_125);
return default;
}, 1, "", true));
Call(q_126, V.Undef, Arr(Arr(((V)((-7D))), ((V)(GZ_49))), Arr(((V)(3.5)), ((V)(GZ_49))), Arr(((V)(3.5)), ((V)((GZ_49 - 0.5)))), Arr(((V)((-7D))), ((V)((GZ_49 - 0.5))))), NewObj(1).Put("fill", ((V)("url(#hcAO)"))).V);
Invoke(Arr(((V)((-1.6))), ((V)(1.6))), "forEach", Fn((V _self118, int _argc356, V x_362, V _a359, V _a360, V _a361, V[] _rest357) => {
V p_363 = default;
V k_364 = default;
p_363 = Call(P_40, V.Undef, x_362, ((V)(0D)), ((V)((GZ_49 - 0.25))));
k_364 = GetIdx(p_363, 2D);
Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_363, 0D)) - (0.16 * ToNum(k_364))))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_363, 1D)) - (0.3 * ToNum(k_364))))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(p_363, 0D), ((V)((0.16 * ToNum(k_364))))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_363, 1D)) - (0.3 * ToNum(k_364))))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(p_363, 0D), ((V)((0.12 * ToNum(k_364))))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(p_363, 1D))).S("L").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_363, 0D)) - (0.12 * ToNum(k_364))))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(p_363, 1D))).S("Z").End()))).Put("fill", ((V)("#c96a44"))).V, sv_125);
Invoke(Arr(Arr(((V)((-0.1))), ((V)((-0.42))), ((V)(0.14))), Arr(((V)(0.08)), ((V)((-0.46))), ((V)(0.15))), Arr(((V)(0D)), ((V)((-0.55))), ((V)(0.13)))), "forEach", Fn((V _self118, int _argc365, V _a367, V _a368, V _a369, V _a370, V[] _rest366) => {
V a_373 = default;
V b_375 = default;
V r_377 = default;
{ V _t371 = ListOf(_a367);
{ V _t372 = GetIdx(_t371, 0D);
a_373 = _t372; }
{ V _t374 = GetIdx(_t371, 1D);
b_375 = _t374; }
{ V _t376 = GetIdx(_t371, 2D);
r_377 = _t376; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, Add(GetIdx(p_363, 0D), ((V)((ToNum(a_373) * ToNum(k_364))))))).Put("cy", Call(r2_19, V.Undef, Add(GetIdx(p_363, 1D), ((V)((ToNum(b_375) * ToNum(k_364))))))).Put("r", Call(r2_19, V.Undef, ((V)((ToNum(r_377) * ToNum(k_364)))))).Put("fill", ((V)("#58a64a"))).V, sv_125);
}, 1, "", true));
Invoke(Arr(Arr(((V)((-0.08))), ((V)((-0.5)))), Arr(((V)(0.07)), ((V)((-0.56)))), Arr(((V)(0.02)), ((V)((-0.44))))), "forEach", Fn((V _self118, int _argc378, V _a380, V i_384, V _a382, V _a383, V[] _rest379) => {
V a_387 = default;
V b_389 = default;
{ V _t385 = ListOf(_a380);
{ V _t386 = GetIdx(_t385, 0D);
a_387 = _t386; }
{ V _t388 = GetIdx(_t385, 1D);
b_389 = _t388; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, Add(GetIdx(p_363, 0D), ((V)((ToNum(a_387) * ToNum(k_364))))))).Put("cy", Call(r2_19, V.Undef, Add(GetIdx(p_363, 1D), ((V)((ToNum(b_389) * ToNum(k_364))))))).Put("r", Call(r2_19, V.Undef, ((V)((0.05 * ToNum(k_364)))))).Put("fill", GetK(Arr(((V)("#ff6f91")), ((V)("#ffd84a")), ((V)("#ffffff"))), i_384)).V, sv_125);
}, 2, "", true));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-2.1))), ((V)((-16D)))), Arr(((V)(2.05)), ((V)(16D)))), "forEach", Fn((V _self118, int _argc390, V _a392, V _a393, V _a394, V _a395, V[] _rest391) => {
V x0_398 = default;
V x1_400 = default;
{ V _t396 = ListOf(_a392);
{ V _t397 = GetIdx(_t396, 0D);
x0_398 = _t397; }
{ V _t399 = GetIdx(_t396, 1D);
x1_400 = _t399; }
}
{
double x_401 = 0;
x_401 = Min(ToNum(x0_398), ToNum(x1_400));
while (true) {
if (!((x_401 < Max(ToNum(x0_398), ToNum(x1_400))))) break;
V p_403 = default;
V k_404 = default;
V g_405 = default;
p_403 = Call(P_40, V.Undef, ((V)((x_401 + 0.2))), ((V)(0D)), ((V)((GZ_49 - 0.35))));
k_404 = GetIdx(p_403, 2D);
g_405 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, sv_125);
Invoke(Arr(Arr(((V)((-0.24))), ((V)((-0.34))), ((V)(0.3))), Arr(((V)(0.04)), ((V)((-0.46))), ((V)(0.34))), Arr(((V)(0.26)), ((V)((-0.32))), ((V)(0.28)))), "forEach", Fn((V _self118, int _argc406, V _a408, V i_412, V _a410, V _a411, V[] _rest407) => {
V a_415 = default;
V b_417 = default;
V r_419 = default;
{ V _t413 = ListOf(_a408);
{ V _t414 = GetIdx(_t413, 0D);
a_415 = _t414; }
{ V _t416 = GetIdx(_t413, 1D);
b_417 = _t416; }
{ V _t418 = GetIdx(_t413, 2D);
r_419 = _t418; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, Add(GetIdx(p_403, 0D), ((V)((ToNum(a_415) * ToNum(k_404))))))).Put("cy", Call(r2_19, V.Undef, Add(GetIdx(p_403, 1D), ((V)((ToNum(b_417) * ToNum(k_404))))))).Put("r", Call(r2_19, V.Undef, ((V)((ToNum(r_419) * ToNum(k_404)))))).Put("fill", ((V)((SEqN(i_412, 1D) ? "#5aa24c" : "#4c9140")))).V, g_405);
}, 2, "", true));
Call(S_16, V.Undef, ((V)("circle")), NewObj(5).Put("cx", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_403, 0D)) - (0.05 * ToNum(k_404))))))).Put("cy", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_403, 1D)) - (0.6 * ToNum(k_404))))))).Put("r", Call(r2_19, V.Undef, ((V)((0.12 * ToNum(k_404)))))).Put("fill", ((V)("#7cc46a"))).Put("opacity", ((V)(0.7))).V, g_405);
x_401 = (x_401 + 0.42);
}
}
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)(3D)), ((V)(6.4))), Arr(((V)((-5.2))), ((V)(5.6)))), "forEach", Fn((V _self118, int _argc420, V _a422, V _a423, V _a424, V _a425, V[] _rest421) => {
V p_431 = default;
V k_432 = default;
V tx_428 = default;
V tz_430 = default;
{ V _t426 = ListOf(_a422);
{ V _t427 = GetIdx(_t426, 0D);
tx_428 = _t427; }
{ V _t429 = GetIdx(_t426, 1D);
tz_430 = _t429; }
}
p_431 = Call(P_40, V.Undef, tx_428, ((V)(0D)), tz_430);
k_432 = GetIdx(p_431, 2D);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_431, 0D)) - (0.4 * ToNum(k_432))))))).Put("cy", Call(r2_19, V.Undef, Add(GetIdx(p_431, 1D), ((V)((0.05 * ToNum(k_432))))))).Put("rx", Call(r2_19, V.Undef, ((V)((1.1 * ToNum(k_432)))))).Put("ry", Call(r2_19, V.Undef, ((V)((0.25 * ToNum(k_432)))))).Put("fill", ((V)("#2a4a20"))).Put("opacity", ((V)(0.25))).V, sv_125);
Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_431, 0D)) - (0.1 * ToNum(k_432))))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(p_431, 1D))).S("L").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_431, 0D)) - (0.06 * ToNum(k_432))))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_431, 1D)) - (2D * ToNum(k_432))))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(p_431, 0D), ((V)((0.06 * ToNum(k_432))))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_431, 1D)) - (2D * ToNum(k_432))))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(p_431, 0D), ((V)((0.12 * ToNum(k_432))))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(p_431, 1D))).S("Z").End()))).Put("fill", ((V)("#7a5034"))).V, sv_125);
Invoke(Arr(Arr(((V)((-0.6))), ((V)((-2.2))), ((V)(0.62)), ((V)("#4f9a3e"))), Arr(((V)(0.55)), ((V)((-2.3))), ((V)(0.66)), ((V)("#4f9a3e"))), Arr(((V)(0D)), ((V)((-2.9))), ((V)(0.75)), ((V)("#5aa84a"))), Arr(((V)((-0.3))), ((V)((-3.3))), ((V)(0.5)), ((V)("#66b456"))), Arr(((V)(0.35)), ((V)((-3.2))), ((V)(0.48)), ((V)("#66b456"))), Arr(((V)(0.1)), ((V)((-2.5))), ((V)(0.6)), ((V)("#5aa84a")))), "forEach", Fn((V _self118, int _argc433, V _a435, V _a436, V _a437, V _a438, V[] _rest434) => {
V a_441 = default;
V b_443 = default;
V r_445 = default;
V c_447 = default;
{ V _t439 = ListOf(_a435);
{ V _t440 = GetIdx(_t439, 0D);
a_441 = _t440; }
{ V _t442 = GetIdx(_t439, 1D);
b_443 = _t442; }
{ V _t444 = GetIdx(_t439, 2D);
r_445 = _t444; }
{ V _t446 = GetIdx(_t439, 3D);
c_447 = _t446; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, Add(GetIdx(p_431, 0D), ((V)((ToNum(a_441) * ToNum(k_432))))))).Put("cy", Call(r2_19, V.Undef, Add(GetIdx(p_431, 1D), ((V)((ToNum(b_443) * ToNum(k_432))))))).Put("r", Call(r2_19, V.Undef, ((V)((ToNum(r_445) * ToNum(k_432)))))).Put("fill", c_447).V, sv_125);
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-3.6))), ((V)(2.2))), Arr(((V)(3.3)), ((V)(1.6))), Arr(((V)((-6.4))), ((V)(3.2))), Arr(((V)(5.6)), ((V)(3.4)))), "forEach", Fn((V _self118, int _argc448, V _a450, V i_454, V _a452, V _a453, V[] _rest449) => {
V p_460 = default;
V k_461 = default;
V x_457 = default;
V z_459 = default;
{ V _t455 = ListOf(_a450);
{ V _t456 = GetIdx(_t455, 0D);
x_457 = _t456; }
{ V _t458 = GetIdx(_t455, 1D);
z_459 = _t458; }
}
p_460 = Call(P_40, V.Undef, x_457, ((V)(0D)), z_459);
k_461 = GetIdx(p_460, 2D);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_19, V.Undef, GetIdx(p_460, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(p_460, 1D))).Put("rx", Call(r2_19, V.Undef, ((V)((0.7 * ToNum(k_461)))))).Put("ry", Call(r2_19, V.Undef, ((V)((0.16 * ToNum(k_461)))))).Put("fill", ((V)("#8a5a34"))).Put("opacity", ((V)(0.85))).V, sv_125);
{
double j_462 = 0;
j_462 = 0D;
while (true) {
if (!((j_462 < 7D))) break;
double a_464 = 0;
V c_465 = default;
a_464 = ((-0.55) + (j_462 * 0.18));
c_465 = GetIdx(Arr(((V)("#ff6f91")), ((V)("#ffd84a")), ((V)("#ffffff")), ((V)("#ff9fd0"))), (ToNum(Add(i_454, ((V)(j_462)))) % 4D));
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, Add(GetIdx(p_460, 0D), ((V)((a_464 * ToNum(k_461))))))).Put("cy", Call(r2_19, V.Undef, ((V)(((ToNum(GetIdx(p_460, 1D)) - (0.12 * ToNum(k_461))) - ((System.Math.Abs(FdLibm.Sin((j_462 * 1.7))) * 0.1) * ToNum(k_461))))))).Put("r", Call(r2_19, V.Undef, ((V)((0.07 * ToNum(k_461)))))).Put("fill", ((V)("#58a64a"))).V, sv_125);
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, Add(GetIdx(p_460, 0D), ((V)((a_464 * ToNum(k_461))))))).Put("cy", Call(r2_19, V.Undef, ((V)(((ToNum(GetIdx(p_460, 1D)) - (0.2 * ToNum(k_461))) - ((System.Math.Abs(FdLibm.Sin((j_462 * 1.7))) * 0.1) * ToNum(k_461))))))).Put("r", Call(r2_19, V.Undef, ((V)((0.055 * ToNum(k_461)))))).Put("fill", c_465).V, sv_125);
j_462++;
}
}
return default;
}, 2, "", true));
Call(q_126, V.Undef, Arr(Arr(((V)((-DW_50))), ((V)((-1D)))), Arr(((V)(DW_50)), ((V)((-1D)))), Arr(((V)(DW_50)), ((V)(GZ_49))), Arr(((V)((-DW_50))), ((V)(GZ_49)))), NewObj(1).Put("fill", ((V)("url(#hcCon)"))).V);
{
double y0_466 = 0;
y0_466 = (ToNum(GetIdx(Call(P_40, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(GZ_49))), 1D)) - 6D);
Call(S_16, V.Undef, ((V)("rect")), NewObj(8).Put("x", ((V)(0D))).Put("y", Call(r2_19, V.Undef, ((V)(y0_466)))).Put("width", W_38).Put("height", Call(r2_19, V.Undef, ((V)((ToNum(H_39) - y0_466))))).Put("fill", ((V)("#ffffff"))).Put("filter", ((V)("url(#hcGrain)"))).Put("clip-path", ((V)("url(#hcDrive)"))).Put("opacity", ((V)(0.9))).V, sv_125);
}
Call(q_126, V.Undef, Arr(Arr(((V)((-DW_50))), ((V)((-1D)))), Arr(((V)(((-DW_50) + 0.06))), ((V)((-1D)))), Arr(((V)(((-DW_50) + 0.06))), ((V)(GZ_49))), Arr(((V)((-DW_50))), ((V)(GZ_49)))), NewObj(1).Put("fill", ((V)("#b8b0a2"))).V);
Call(q_126, V.Undef, Arr(Arr(((V)((DW_50 - 0.06))), ((V)((-1D)))), Arr(((V)(DW_50)), ((V)((-1D)))), Arr(((V)(DW_50)), ((V)(GZ_49))), Arr(((V)((DW_50 - 0.06))), ((V)(GZ_49)))), NewObj(1).Put("fill", ((V)("#b8b0a2"))).V);
Invoke(Arr(((V)(1.4)), ((V)(3D)), ((V)(4.6)), ((V)(6.2))), "forEach", Fn((V _self118, int _argc467, V z_473, V _a470, V _a471, V _a472, V[] _rest468) => {
Call(ln_127, V.Undef, Arr(Arr(((V)((-DW_50))), z_473), Arr(((V)(DW_50)), z_473)), NewObj(2).Put("stroke", ((V)("#a89e90"))).Put("stroke-width", Call(r2_19, V.Undef, ((V)(((1.6 * ToNum(GetIdx(Call(P_40, V.Undef, ((V)(0D)), ((V)(0D)), z_473), 2D))) / 100D))))).V);
Call(ln_127, V.Undef, Arr(Arr(((V)((-DW_50))), Add(z_473, ((V)(0.03)))), Arr(((V)(DW_50)), Add(z_473, ((V)(0.03))))), NewObj(3).Put("stroke", ((V)("#f4f0ea"))).Put("stroke-width", Call(r2_19, V.Undef, ((V)(((1.2 * ToNum(GetIdx(Call(P_40, V.Undef, ((V)(0D)), ((V)(0D)), z_473), 2D))) / 100D))))).Put("opacity", ((V)(0.8))).V);
return default;
}, 1, "", true));
Call(ln_127, V.Undef, Arr(Arr(((V)(0D)), ((V)((-1D)))), Arr(((V)(0D)), ((V)(GZ_49)))), NewObj(3).Put("stroke", ((V)("#b5ab9c"))).Put("stroke-width", ((V)(1D))).Put("opacity", ((V)(0.6))).V);
Call(ln_127, V.Undef, Arr(Arr(((V)((-1.5))), ((V)(2.3))), Arr(((V)((-1.28))), ((V)(2.55))), Arr(((V)((-1.36))), ((V)(2.8))), Arr(((V)((-1.1))), ((V)(3D)))), NewObj(3).Put("stroke", ((V)("#8f8578"))).Put("stroke-width", ((V)(1.1))).Put("opacity", ((V)(0.7))).V);
Call(ln_127, V.Undef, Arr(Arr(((V)(1.2)), ((V)(5.1))), Arr(((V)(1.36)), ((V)(5.4))), Arr(((V)(1.25)), ((V)(5.7)))), NewObj(3).Put("stroke", ((V)("#8f8578"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.6))).V);
{
V p_474 = default;
V k_475 = default;
p_474 = Call(P_40, V.Undef, ((V)(0.7)), ((V)(0D)), ((V)(6.9)));
k_475 = GetIdx(p_474, 2D);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(7).Put("cx", Call(r2_19, V.Undef, GetIdx(p_474, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(p_474, 1D))).Put("rx", Call(r2_19, V.Undef, ((V)((0.45 * ToNum(k_475)))))).Put("ry", Call(r2_19, V.Undef, ((V)((0.12 * ToNum(k_475)))))).Put("fill", ((V)("#5a5450"))).Put("opacity", ((V)(0.22))).Put("filter", ((V)("url(#hcBlur)"))).V, sv_125);
}
Invoke(Arr(Arr(((V)((-1.2))), ((V)(1.9)), ((V)("#d9883a")), ((V)(20D))), Arr(((V)(1.5)), ((V)(2.4)), ((V)("#c8642e")), ((V)((-30D)))), Arr(((V)((-0.4))), ((V)(4D)), ((V)("#e0a040")), ((V)(60D))), Arr(((V)(1.1)), ((V)(0.8)), ((V)("#c8642e")), ((V)(10D))), Arr(((V)((-1.6))), ((V)(5.6)), ((V)("#d9883a")), ((V)((-50D))))), "forEach", Fn((V _self118, int _argc476, V _a478, V _a479, V _a480, V _a481, V[] _rest477) => {
V p_491 = default;
double k_492 = 0;
V x_484 = default;
V z_486 = default;
V c_488 = default;
V r_490 = default;
{ V _t482 = ListOf(_a478);
{ V _t483 = GetIdx(_t482, 0D);
x_484 = _t483; }
{ V _t485 = GetIdx(_t482, 1D);
z_486 = _t485; }
{ V _t487 = GetIdx(_t482, 2D);
c_488 = _t487; }
{ V _t489 = GetIdx(_t482, 3D);
r_490 = _t489; }
}
p_491 = Call(P_40, V.Undef, x_484, ((V)(0D)), z_486);
k_492 = (ToNum(GetIdx(p_491, 2D)) / 100D);
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)("M0 -6Q5 -2 0 6Q-5 -2 0 -6Z"))).Put("fill", c_488).Put("opacity", ((V)(0.85))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_19, V.Undef, GetIdx(p_491, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(p_491, 1D))).S(") rotate(").V(r_490).S(") scale(").V(Call(r2_19, V.Undef, ((V)((k_492 * 1.4))))).S(" ").V(Call(r2_19, V.Undef, ((V)((k_492 * 0.7))))).S(")").End()))).V, sv_125);
return default;
}, 1, "", true));
pa_134 = NewObj(4).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.82))).Put("stroke-linejoin", ((V)("round"))).V;
Call(ln_127, V.Undef, Arr(Arr(((V)((-0.9))), ((V)((BZ_47 - 0.02)))), Arr(((V)((-0.9))), ((V)(2.3))), Arr(((V)(0.9)), ((V)(2.3))), Arr(((V)(0.9)), ((V)((BZ_47 - 0.02))))), pa_134);
Call(ln_127, V.Undef, Arr(Arr(((V)(((-DW_50) + 0.08))), ((V)(BZ_47))), Arr(((V)((DW_50 - 0.08))), ((V)(BZ_47)))), pa_134);
{
V pts_493 = default;
V p2_494 = default;
pts_493 = Arr();
{
double i_495 = 0;
i_495 = 0D;
while (true) {
if (!((i_495 <= 24D))) break;
double a_497 = 0;
a_497 = ((System.Math.PI * i_495) / 24D);
Invoke(pts_493, "push", Arr(((V)((FdLibm.Cos(a_497) * 0.9))), ((V)((2.3 - (FdLibm.Sin(a_497) * 0.9))))));
i_495++;
}
}
Call(ln_127, V.Undef, pts_493, pa_134);
p2_494 = Arr();
{
double i_498 = 0;
i_498 = 0D;
while (true) {
if (!((i_498 <= 24D))) break;
double a_500 = 0;
a_500 = ((System.Math.PI * i_498) / 24D);
Invoke(p2_494, "push", Arr(((V)((FdLibm.Cos(a_500) * 0.9))), ((V)((2.3 + (FdLibm.Sin(a_500) * 0.9))))));
i_498++;
}
}
Call(ln_127, V.Undef, p2_494, Object_assign(NewObj(0).V, pa_134, NewObj(2).Put("stroke-dasharray", ((V)("5 6"))).Put("opacity", ((V)(0.6))).V));
}
{
V pts_501 = default;
double R_502 = 0;
pts_501 = Arr();
R_502 = 3.6;
{
double i_503 = 0;
i_503 = 0D;
while (true) {
if (!((i_503 <= 40D))) break;
double a_505 = 0;
double x_506 = 0;
double z_507 = 0;
a_505 = ((-1.05) + ((2.1 * i_503) / 40D));
x_506 = (FdLibm.Sin(a_505) * R_502);
z_507 = (RZ_46 - (FdLibm.Cos(a_505) * R_502));
if ((System.Math.Abs(x_506) <= (DW_50 - 0.1))) {
Invoke(pts_501, "push", Arr(((V)(x_506)), ((V)(z_507))));
}
i_503++;
}
}
Call(ln_127, V.Undef, pts_501, pa_134);
}
{
V p_508 = default;
V k_509 = default;
V b_510 = default;
p_508 = Call(P_40, V.Undef, ((V)(2.25)), ((V)(0D)), ((V)(4.4)));
k_509 = GetIdx(p_508, 2D);
b_510 = Fn((V _self118, int _argc511, V dx_517, V dy_518, V _a515, V _a516, V[] _rest512) => {
V cx_519 = default;
V cy_520 = default;
double r_521 = 0;
cx_519 = Add(GetIdx(p_508, 0D), ((V)((ToNum(dx_517) * ToNum(k_509)))));
cy_520 = Add(GetIdx(p_508, 1D), ((V)((ToNum(dy_518) * ToNum(k_509)))));
r_521 = (0.12 * ToNum(k_509));
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, cx_519)).Put("cy", Call(r2_19, V.Undef, cy_520)).Put("r", Call(r2_19, V.Undef, ((V)(r_521)))).Put("fill", ((V)("url(#hcBall)"))).V, sv_125);
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(cx_519) - r_521))))).S(" ").V(Call(r2_19, V.Undef, cy_520)).S("H").V(Call(r2_19, V.Undef, Add(cx_519, ((V)(r_521))))).S("M").V(Call(r2_19, V.Undef, cx_519)).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(cy_520) - r_521))))).S("V").V(Call(r2_19, V.Undef, Add(cy_520, ((V)(r_521))))).End()))).Put("stroke", ((V)("#7a3410"))).Put("stroke-width", ((V)(0.7))).Put("opacity", ((V)(0.8))).V, sv_125);
return default;
}, 2, "", true);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_508, 0D)) - (0.1 * ToNum(k_509))))))).Put("cy", Call(r2_19, V.Undef, GetIdx(p_508, 1D))).Put("rx", Call(r2_19, V.Undef, ((V)((0.4 * ToNum(k_509)))))).Put("ry", Call(r2_19, V.Undef, ((V)((0.07 * ToNum(k_509)))))).Put("fill", ((V)("#2a4a20"))).Put("opacity", ((V)(0.25))).V, sv_125);
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_508, 0D)) - (0.3 * ToNum(k_509))))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(p_508, 1D))).S("V").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_508, 1D)) - (0.55 * ToNum(k_509))))))).S("M").V(Call(r2_19, V.Undef, Add(GetIdx(p_508, 0D), ((V)((0.3 * ToNum(k_509))))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(p_508, 1D))).S("V").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_508, 1D)) - (0.55 * ToNum(k_509))))))).S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_508, 0D)) - (0.32 * ToNum(k_509))))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_508, 1D)) - (0.3 * ToNum(k_509))))))).S("H").V(Call(r2_19, V.Undef, Add(GetIdx(p_508, 0D), ((V)((0.32 * ToNum(k_509))))))).S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_508, 0D)) - (0.32 * ToNum(k_509))))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_508, 1D)) - (0.55 * ToNum(k_509))))))).S("H").V(Call(r2_19, V.Undef, Add(GetIdx(p_508, 0D), ((V)((0.32 * ToNum(k_509))))))).End()))).Put("stroke", ((V)("#4a4a56"))).Put("stroke-width", ((V)(1.4))).Put("stroke-linecap", ((V)("round"))).V, sv_125);
Call(b_510, V.Undef, ((V)((-0.14))), ((V)((-0.43))));
Call(b_510, V.Undef, ((V)(0.14)), ((V)((-0.43))));
Call(b_510, V.Undef, ((V)(0.02)), ((V)((-0.15))));
}
{
V p_522 = default;
V k_523 = default;
p_522 = Call(P_40, V.Undef, ((V)((-2.05))), ((V)(0D)), ((V)(3.7)));
k_523 = GetIdx(p_522, 2D);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_19, V.Undef, GetIdx(p_522, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(p_522, 1D))).Put("rx", Call(r2_19, V.Undef, ((V)((0.3 * ToNum(k_523)))))).Put("ry", Call(r2_19, V.Undef, ((V)((0.06 * ToNum(k_523)))))).Put("fill", ((V)("#2a4a20"))).Put("opacity", ((V)(0.22))).V, sv_125);
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_522, 0D)) - (0.28 * ToNum(k_523))))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_522, 1D)) - (0.02 * ToNum(k_523))))))).S("Q").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_522, 0D)) - (0.1 * ToNum(k_523))))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_522, 1D)) - (0.1 * ToNum(k_523))))))).S(" ").V(Call(r2_19, V.Undef, Add(GetIdx(p_522, 0D), ((V)((0.02 * ToNum(k_523))))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_522, 1D)) - (0.04 * ToNum(k_523))))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(p_522, 0D), ((V)((0.06 * ToNum(k_523))))))).S(" ").V(Call(r2_19, V.Undef, Add(GetIdx(p_522, 1D), ((V)((0.02 * ToNum(k_523))))))).S("L").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_522, 0D)) - (0.3 * ToNum(k_523))))))).S(" ").V(Call(r2_19, V.Undef, Add(GetIdx(p_522, 1D), ((V)((0.04 * ToNum(k_523))))))).S("Z").End()))).Put("fill", ((V)("#ff8fb8"))).Put("stroke", ((V)("#e0608e"))).Put("stroke-width", ((V)(0.8))).V, sv_125);
Call(S_16, V.Undef, ((V)("rect")), NewObj(8).Put("x", Call(r2_19, V.Undef, Add(GetIdx(p_522, 0D), ((V)((0.1 * ToNum(k_523))))))).Put("y", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_522, 1D)) - (0.24 * ToNum(k_523))))))).Put("width", Call(r2_19, V.Undef, ((V)((0.08 * ToNum(k_523)))))).Put("height", Call(r2_19, V.Undef, ((V)((0.24 * ToNum(k_523)))))).Put("rx", ((V)(1.2))).Put("fill", ((V)("#5cc2ff"))).Put("stroke", ((V)("#2f86c8"))).Put("stroke-width", ((V)(0.7))).V, sv_125);
Call(S_16, V.Undef, ((V)("rect")), NewObj(6).Put("x", Call(r2_19, V.Undef, Add(GetIdx(p_522, 0D), ((V)((0.11 * ToNum(k_523))))))).Put("y", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_522, 1D)) - (0.29 * ToNum(k_523))))))).Put("width", Call(r2_19, V.Undef, ((V)((0.06 * ToNum(k_523)))))).Put("height", Call(r2_19, V.Undef, ((V)((0.05 * ToNum(k_523)))))).Put("rx", ((V)(0.8))).Put("fill", ((V)("#f0f4f8"))).V, sv_125);
}
Call(S_16, V.Undef, ((V)("rect")), NewObj(7).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_38, ((V)(40D)))).Put("height", Add(H_39, ((V)(40D)))).Put("fill", ((V)("url(#hcSun)"))).Put("opacity", ((V)(0.25))).Put("transform", ((V)("translate(-180 -300) scale(2.2)"))).V, sv_125);
return default;
}, 1, "drawCourt", false);
drawHoop_86 = Fn((V _self524, int _argc525, V t_531, V _a528, V _a529, V _a530, V[] _rest526) => {
V moving_532 = default;
V swaying_533 = default;
V sun_534 = default;
V gq_535 = default;
V pb_536 = default;
V pt_537 = default;
double pw_538 = 0;
V pd_539 = default;
V a1_540 = default;
V a2_541 = default;
V a3_542 = default;
V a4_543 = default;
V b1_544 = default;
V b2_545 = default;
double bw_546 = 0;
double bh_547 = 0;
V s1_548 = default;
V s2_549 = default;
V br_550 = default;
V c_551 = default;
V arc_552 = default;
double sw_553 = 0;
JsStrBuf nd_554 = null;
V ring_555 = default;
V r0_556 = default;
V r1_557 = default;
V r2b_558 = default;
if (_self524.IsNullish) _self524 = GlobalV;
moving_532 = ((System.Math.Abs((ToNum(hx_82) - ToNum((lastHx_85.IsNullish ? ((V)(1000000000D)) : lastHx_85)))) > 0.0001) ? V.True : V.False);
swaying_533 = (((ToNum(t_531) - ToNum(netAt_84)) < 1600D) ? V.True : V.False);
if (((!(Truthy(moving_532)) && !(Truthy(swaying_533))) && !lastHx_85.IsNullish)) {
return default;
}
lastHx_85 = hx_82;
Set(backG_76, "innerHTML", ((V)("")));
Set(frontG_78, "innerHTML", ((V)("")));
Invoke(Invoke(shG_74, "querySelectorAll", ((V)(".hs"))), "forEach", Fn((V _self524, int _argc559, V e_565, V _a562, V _a563, V _a564, V[] _rest560) => {
return Invoke(e_565, "remove");
}, 1, "", true));
sun_534 = Call(S_16, V.Undef, ((V)("g")), NewObj(2).Put("class", ((V)("hs"))).Put("opacity", ((V)(0.2))).V, shG_74);
Invoke(shG_74, "insertBefore", sun_534, Get(shG_74, "firstChild"));
gq_535 = Fn((V _self524, int _argc566, V pts_572, V _a569, V _a570, V _a571, V[] _rest567) => {
return Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_572, "map", Fn((V _self524, int _argc573, V _a575, V _a576, V _a577, V _a578, V[] _rest574) => {
V s_584 = default;
V x_581 = default;
V z_583 = default;
{ V _t579 = ListOf(_a575);
{ V _t580 = GetIdx(_t579, 0D);
x_581 = _t580; }
{ V _t582 = GetIdx(_t579, 1D);
z_583 = _t582; }
}
s_584 = Call(P_40, V.Undef, x_581, ((V)(0D)), z_583);
return ((V)(JsStrBuf.Begin().V(Call(r2_19, V.Undef, GetIdx(s_584, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(s_584, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).Put("fill", ((V)("#2a2034"))).V, sun_534);
}, 1, "", true);
Call(gq_535, V.Undef, Arr(Arr(((V)((ToNum(hx_82) - 0.06))), ((V)(PZ_48))), Arr(Add(hx_82, ((V)(0.06))), ((V)(PZ_48))), Arr(Add(hx_82, ((V)(1.05))), ((V)((PZ_48 - 3.2)))), Arr(Add(hx_82, ((V)(0.93))), ((V)((PZ_48 - 3.2))))));
Call(gq_535, V.Undef, Arr(Arr(Add(hx_82, ((V)(0.95))), ((V)((PZ_48 - 2.95)))), Arr(Add(hx_82, ((V)(2.55))), ((V)((PZ_48 - 2.95)))), Arr(Add(hx_82, ((V)(2.75))), ((V)((PZ_48 - 4.05)))), Arr(Add(hx_82, ((V)(1.15))), ((V)((PZ_48 - 4.05))))));
pb_536 = Call(P_40, V.Undef, hx_82, ((V)(0D)), ((V)(PZ_48)));
pt_537 = Call(P_40, V.Undef, hx_82, ((V)(3.6)), ((V)(PZ_48)));
pw_538 = (0.11 * ToNum(GetIdx(pb_536, 2D)));
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_19, V.Undef, GetIdx(pb_536, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(pb_536, 1D))).Put("rx", Call(r2_19, V.Undef, ((V)((0.55 * ToNum(GetIdx(pb_536, 2D))))))).Put("ry", Call(r2_19, V.Undef, ((V)((0.1 * ToNum(GetIdx(pb_536, 2D))))))).Put("fill", ((V)("#2a2034"))).Put("opacity", ((V)(0.28))).V, backG_76);
Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(pb_536, 0D)) - (0.42 * ToNum(GetIdx(pb_536, 2D)))))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(pb_536, 1D))).S("L").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(pb_536, 0D)) - (0.36 * ToNum(GetIdx(pb_536, 2D)))))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(pb_536, 1D)) - (0.22 * ToNum(GetIdx(pb_536, 2D)))))))).S("H").V(Call(r2_19, V.Undef, Add(GetIdx(pb_536, 0D), ((V)((0.36 * ToNum(GetIdx(pb_536, 2D)))))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(pb_536, 0D), ((V)((0.42 * ToNum(GetIdx(pb_536, 2D)))))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(pb_536, 1D))).S("Z").End()))).Put("fill", ((V)("#3a3a46"))).V, backG_76);
Call(S_16, V.Undef, ((V)("rect")), NewObj(5).Put("x", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(pb_536, 0D)) - (pw_538 / 2D)))))).Put("y", Call(r2_19, V.Undef, GetIdx(pt_537, 1D))).Put("width", Call(r2_19, V.Undef, ((V)(pw_538)))).Put("height", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(pb_536, 1D)) - ToNum(GetIdx(pt_537, 1D))))))).Put("fill", ((V)("url(#hcPole)"))).V, backG_76);
pd_539 = Call(P_40, V.Undef, hx_82, ((V)(1.5)), ((V)(PZ_48)));
Call(S_16, V.Undef, ((V)("rect")), NewObj(6).Put("x", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(pb_536, 0D)) - (pw_538 * 0.9)))))).Put("y", Call(r2_19, V.Undef, GetIdx(pd_539, 1D))).Put("width", Call(r2_19, V.Undef, ((V)((pw_538 * 1.8))))).Put("height", Call(r2_19, V.Undef, ((V)(((ToNum(GetIdx(pb_536, 1D)) - (0.22 * ToNum(GetIdx(pb_536, 2D)))) - ToNum(GetIdx(pd_539, 1D))))))).Put("rx", ((V)(3D))).Put("fill", ((V)("url(#hcPad)"))).V, backG_76);
a1_540 = Call(P_40, V.Undef, hx_82, ((V)(3.5)), ((V)(PZ_48)));
a2_541 = Call(P_40, V.Undef, hx_82, ((V)(3.42)), ((V)((BZ_47 + 0.05))));
a3_542 = Call(P_40, V.Undef, hx_82, ((V)(3.1)), ((V)(PZ_48)));
a4_543 = Call(P_40, V.Undef, hx_82, ((V)(3D)), ((V)((BZ_47 + 0.05))));
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, GetIdx(a1_540, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(a1_540, 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(a2_541, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(a2_541, 1D))).S("M").V(Call(r2_19, V.Undef, GetIdx(a3_542, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(a3_542, 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(a4_543, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(a4_543, 1D))).End()))).Put("stroke", ((V)("#3a3a46"))).Put("stroke-width", ((V)(4D))).Put("stroke-linecap", ((V)("round"))).V, backG_76);
b1_544 = Call(P_40, V.Undef, ((V)((ToNum(hx_82) - 0.9))), ((V)(3.85)), ((V)(BZ_47)));
b2_545 = Call(P_40, V.Undef, Add(hx_82, ((V)(0.9))), ((V)(2.78)), ((V)(BZ_47)));
bw_546 = (ToNum(GetIdx(b2_545, 0D)) - ToNum(GetIdx(b1_544, 0D)));
bh_547 = (ToNum(GetIdx(b2_545, 1D)) - ToNum(GetIdx(b1_544, 1D)));
Call(S_16, V.Undef, ((V)("rect")), NewObj(7).Put("x", Call(r2_19, V.Undef, Add(GetIdx(b1_544, 0D), ((V)(2D))))).Put("y", Call(r2_19, V.Undef, Add(GetIdx(b1_544, 1D), ((V)(3D))))).Put("width", Call(r2_19, V.Undef, ((V)(bw_546)))).Put("height", Call(r2_19, V.Undef, ((V)(bh_547)))).Put("rx", ((V)(4D))).Put("fill", ((V)("#2a2034"))).Put("opacity", ((V)(0.25))).V, backG_76);
Call(S_16, V.Undef, ((V)("rect")), NewObj(8).Put("x", Call(r2_19, V.Undef, GetIdx(b1_544, 0D))).Put("y", Call(r2_19, V.Undef, GetIdx(b1_544, 1D))).Put("width", Call(r2_19, V.Undef, ((V)(bw_546)))).Put("height", Call(r2_19, V.Undef, ((V)(bh_547)))).Put("rx", ((V)(4D))).Put("fill", ((V)("url(#hcBoard)"))).Put("stroke", ((V)("#f4f6fa"))).Put("stroke-width", ((V)(4D))).V, backG_76);
Call(S_16, V.Undef, ((V)("rect")), NewObj(8).Put("x", Call(r2_19, V.Undef, GetIdx(b1_544, 0D))).Put("y", Call(r2_19, V.Undef, GetIdx(b1_544, 1D))).Put("width", Call(r2_19, V.Undef, ((V)(bw_546)))).Put("height", Call(r2_19, V.Undef, ((V)(bh_547)))).Put("rx", ((V)(4D))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#9aa4b4"))).Put("stroke-width", ((V)(1D))).V, backG_76);
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, Add(GetIdx(b1_544, 0D), ((V)((bw_546 * 0.12)))))).S(" ").V(Call(r2_19, V.Undef, Add(GetIdx(b1_544, 1D), ((V)(3D))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(b1_544, 0D), ((V)((bw_546 * 0.3)))))).S(" ").V(Call(r2_19, V.Undef, Add(GetIdx(b1_544, 1D), ((V)(3D))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(b1_544, 0D), ((V)((bw_546 * 0.12)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(b2_545, 1D)) - 3D))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(b1_544, 0D), ((V)(3D))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(b2_545, 1D)) - 3D))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(b1_544, 0D), ((V)(3D))))).S(" ").V(Call(r2_19, V.Undef, Add(GetIdx(b1_544, 1D), ((V)((bh_547 * 0.4)))))).S("Z").End()))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.6))).V, backG_76);
s1_548 = Call(P_40, V.Undef, ((V)((ToNum(hx_82) - 0.3))), ((V)(3.5)), ((V)(BZ_47)));
s2_549 = Call(P_40, V.Undef, Add(hx_82, ((V)(0.3))), ((V)(3.08)), ((V)(BZ_47)));
Call(S_16, V.Undef, ((V)("rect")), NewObj(7).Put("x", Call(r2_19, V.Undef, GetIdx(s1_548, 0D))).Put("y", Call(r2_19, V.Undef, GetIdx(s1_548, 1D))).Put("width", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(s2_549, 0D)) - ToNum(GetIdx(s1_548, 0D))))))).Put("height", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(s2_549, 1D)) - ToNum(GetIdx(s1_548, 1D))))))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#e8483c"))).Put("stroke-width", ((V)(2.4))).V, backG_76);
Call(S_16, V.Undef, ((V)("rect")), NewObj(5).Put("x", Call(r2_19, V.Undef, GetIdx(b1_544, 0D))).Put("y", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(b2_545, 1D)) - 2.6))))).Put("width", Call(r2_19, V.Undef, ((V)(bw_546)))).Put("height", ((V)(2.6))).Put("fill", ((V)("#e8483c"))).V, backG_76);
br_550 = Call(P_40, V.Undef, hx_82, ((V)((RY_45 - 0.02))), ((V)((BZ_47 - 0.01))));
c_551 = Call(P_40, V.Undef, hx_82, ((V)(RY_45)), ((V)(RZ_46)));
Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(br_550, 0D)) - 3.5))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(br_550, 1D)) - 2D))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(br_550, 0D), ((V)(3.5))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(br_550, 1D)) - 2D))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(c_551, 0D), ((V)(2D))))).S(" ").V(Call(r2_19, V.Undef, ((V)(((ToNum(GetIdx(c_551, 1D)) - 1D) - ((RR_43 * ToNum(GetIdx(c_551, 2D))) * 0.3)))))).S("L").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(c_551, 0D)) - 2D))))).S(" ").V(Call(r2_19, V.Undef, ((V)(((ToNum(GetIdx(c_551, 1D)) - 1D) - ((RR_43 * ToNum(GetIdx(c_551, 2D))) * 0.3)))))).S("Z").End()))).Put("fill", ((V)("#c8501e"))).V, backG_76);
arc_552 = Fn((V _self524, int _argc585, V a0_591, V a1_592, V w_593, V col_594, V[] _rest586) => {
JsStrBuf d_596 = null;
V g_595 = default;
g_595 = (_argc585 > 4 ? _rest586[0] : V.Undef);
d_596 = new JsStrBuf("");
{
double i_597 = 0;
i_597 = 0D;
while (true) {
if (!((i_597 <= 16D))) break;
V a_599 = default;
V s_600 = default;
a_599 = Add(a0_591, ((V)((((ToNum(a1_592) - ToNum(a0_591)) * i_597) / 16D))));
s_600 = Call(P_40, V.Undef, Add(hx_82, ((V)((FdLibm.Cos(ToNum(a_599)) * RR_43)))), ((V)(RY_45)), ((V)((RZ_46 + (FdLibm.Sin(ToNum(a_599)) * RR_43)))));
d_596.S((NumTruthy(i_597) ? "L" : "M")).V(Call(r2_19, V.Undef, GetIdx(s_600, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(s_600, 1D)));
i_597++;
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(d_596.Str))).Put("fill", ((V)("none"))).Put("stroke", col_594).Put("stroke-width", w_593).Put("stroke-linecap", ((V)("round"))).V, g_595);
return default;
}, 5, "", true);
Call(arc_552, V.Undef, ((V)(0D)), ((V)(System.Math.PI)), ((V)(2.6)), ((V)("#c8501e")), backG_76);
sw_553 = ((netSw_83 * FdLibm.Sin(((ToNum(t_531) - ToNum(netAt_84)) / 70D))) * FdLibm.Exp(((-(ToNum(t_531) - ToNum(netAt_84))) / 500D)));
nd_554 = new JsStrBuf("");
ring_555 = Fn((V _self524, int _argc601, V yy_607, V rr_608, V k_609, V _a606, V[] _rest602) => {
return Invoke(new ArrBuilder().Spread(Call(G("Array"), V.Undef, ((V)(12D)))).V, "map", Fn((V _self524, int _argc610, V __616, V i_617, V _a614, V _a615, V[] _rest611) => {
double a_618 = 0;
a_618 = (((ToNum(i_617) / 12D) * System.Math.PI) * 2D);
return Call(P_40, V.Undef, Add(Add(hx_82, ((V)((FdLibm.Cos(a_618) * ToNum(rr_608))))), ((V)(((sw_553 * 0.05) * ToNum(k_609))))), yy_607, ((V)((RZ_46 + (FdLibm.Sin(a_618) * ToNum(rr_608))))));
return default;
}, 2, "", true));
}, 3, "", true);
r0_556 = Call(ring_555, V.Undef, ((V)(RY_45)), ((V)(RR_43)), ((V)(0D)));
r1_557 = Call(ring_555, V.Undef, ((V)((RY_45 - 0.22))), ((V)((RR_43 * 0.82))), ((V)(1D)));
r2b_558 = Call(ring_555, V.Undef, ((V)((RY_45 - 0.42))), ((V)((RR_43 * 0.6))), ((V)(2D)));
{
double i_619 = 0;
i_619 = 0D;
while (true) {
if (!((i_619 < 12D))) break;
double j_621 = 0;
j_621 = ((i_619 + 1D) % 12D);
nd_554.S("M").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r0_556, i_619), 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r0_556, i_619), 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r1_557, j_621), 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r1_557, j_621), 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r2b_558, i_619), 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r2b_558, i_619), 1D)));
nd_554.S("M").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r0_556, j_621), 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r0_556, j_621), 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r1_557, i_619), 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r1_557, i_619), 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r2b_558, j_621), 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(GetIdx(r2b_558, j_621), 1D)));
i_619++;
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(nd_554.Str))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.95))).V, frontG_78);
Call(arc_552, V.Undef, ((V)(System.Math.PI)), ((V)((System.Math.PI * 2D))), ((V)(3D)), ((V)("#f07a2e")), frontG_78);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(8).Put("cx", Call(r2_19, V.Undef, GetIdx(c_551, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(c_551, 1D))).Put("rx", Call(r2_19, V.Undef, ((V)((RR_43 * ToNum(GetIdx(c_551, 2D))))))).Put("ry", Call(r2_19, V.Undef, ((V)(((RR_43 * ToNum(GetIdx(c_551, 2D))) * 0.3))))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffb070"))).Put("stroke-width", ((V)(0.8))).Put("opacity", ((V)(0.6))).V, frontG_78);
return default;
}, 1, "drawHoop", false);
stepB_87 = Fn((V _self622, int _argc623, V b_629, V dt_630, V h_631, V t_632, V[] _rest624) => {
V py_634 = default;
double ins0_635 = 0;
double rx_636 = 0;
double rz_637 = 0;
V d_638 = default;
V qx_639 = default;
double qz_640 = 0;
double ex_641 = 0;
double ey_642 = 0;
double ez_643 = 0;
double dist_644 = 0;
double din_645 = 0;
V @out_633 = default;
if (_self622.IsNullish) _self622 = GlobalV;
@out_633 = (_argc623 > 4 ? _rest624[0] : V.Undef);
py_634 = Get(b_629, "y");
ins0_635 = Hypot((ToNum(Get(b_629, "x")) - ToNum(h_631)), (ToNum(Get(b_629, "z")) - RZ_46));
OpSet(b_629, "vy", 1, ((V)((G_41 * ToNum(dt_630)))));
OpSet(b_629, "x", 0, ((V)((ToNum(Get(b_629, "vx")) * ToNum(dt_630)))));
OpSet(b_629, "y", 0, ((V)((ToNum(Get(b_629, "vy")) * ToNum(dt_630)))));
OpSet(b_629, "z", 0, ((V)((ToNum(Get(b_629, "vz")) * ToNum(dt_630)))));
rx_636 = (ToNum(Get(b_629, "x")) - ToNum(h_631));
rz_637 = (ToNum(Get(b_629, "z")) - RZ_46);
d_638 = (((V)(Hypot(rx_636, rz_637))) is var _t646 && Truthy(_t646) ? _t646 : ((V)(0.000001)));
qx_639 = Add(h_631, ((V)(((RR_43 * rx_636) / ToNum(d_638)))));
qz_640 = (RZ_46 + ((RR_43 * rz_637) / ToNum(d_638)));
ex_641 = (ToNum(Get(b_629, "x")) - ToNum(qx_639));
ey_642 = (ToNum(Get(b_629, "y")) - RY_45);
ez_643 = (ToNum(Get(b_629, "z")) - qz_640);
dist_644 = Hypot(ex_641, ey_642, ez_643);
if ((dist_644 < (BR_42 + RT_44))) {
double nx_647 = 0;
double ny_648 = 0;
double nz_649 = 0;
double vn_650 = 0;
nx_647 = (ex_641 / dist_644);
ny_648 = (ey_642 / dist_644);
nz_649 = (ez_643 / dist_644);
vn_650 = (((ToNum(Get(b_629, "vx")) * nx_647) + (ToNum(Get(b_629, "vy")) * ny_648)) + (ToNum(Get(b_629, "vz")) * nz_649));
if ((vn_650 < 0D)) {
OpSet(b_629, "vx", 1, ((V)(((1.55 * vn_650) * nx_647))));
OpSet(b_629, "vy", 1, ((V)(((1.55 * vn_650) * ny_648))));
OpSet(b_629, "vz", 1, ((V)(((1.55 * vn_650) * nz_649))));
OpSet(b_629, "vx", 2, ((V)(0.92)));
OpSet(b_629, "vz", 2, ((V)(0.92)));
IncM(b_629, "rim", 1D, false);
Invoke(Get(@out_633, "ev"), "push", Arr(t_632, ((V)("rim"))));
}
Set(b_629, "x", Add(qx_639, ((V)((nx_647 * (BR_42 + RT_44))))));
Set(b_629, "y", ((V)((RY_45 + (ny_648 * (BR_42 + RT_44))))));
Set(b_629, "z", ((V)((qz_640 + (nz_649 * (BR_42 + RT_44))))));
}
if ((((((GtN(Get(b_629, "vz"), 0D) && GtN(Add(Get(b_629, "z"), ((V)(BR_42))), BZ_47)) && LtN(Get(b_629, "z"), (BZ_47 + 0.08))) && (System.Math.Abs((ToNum(Get(b_629, "x")) - ToNum(h_631))) < (0.9 + (BR_42 * 0.5)))) && GtN(Get(b_629, "y"), (2.78 - (BR_42 * 0.5)))) && LtN(Get(b_629, "y"), (3.85 + (BR_42 * 0.5))))) {
Set(b_629, "vz", ((V)(((-ToNum(Get(b_629, "vz"))) * 0.6))));
OpSet(b_629, "vx", 2, ((V)(0.9)));
Set(b_629, "z", ((V)((BZ_47 - BR_42))));
IncM(b_629, "board", 1D, false);
Invoke(Get(@out_633, "ev"), "push", Arr(t_632, ((V)("board"))));
}
din_645 = Hypot((ToNum(Get(b_629, "x")) - ToNum(h_631)), (ToNum(Get(b_629, "z")) - RZ_46));
if ((((LtN(Get(b_629, "y"), RY_45) && GtN(Get(b_629, "y"), (RY_45 - 0.45))) && (ins0_635 < RR_43)) && GeN(py_634, (RY_45 - 0.45)))) {
if ((din_645 > ((RR_43 * 0.78) - (BR_42 * 0.4)))) {
double k_651 = 0;
k_651 = (((RR_43 * 0.78) - (BR_42 * 0.4)) / din_645);
Set(b_629, "x", Add(h_631, ((V)(((ToNum(Get(b_629, "x")) - ToNum(h_631)) * k_651)))));
Set(b_629, "z", ((V)((RZ_46 + ((ToNum(Get(b_629, "z")) - RZ_46) * k_651)))));
}
OpSet(b_629, "vx", 2, ((V)(0.9)));
OpSet(b_629, "vz", 2, ((V)(0.9)));
OpSet(b_629, "vy", 2, ((V)(0.97)));
}
if (((((!(Truthy(Get(b_629, "scored"))) && GeN(py_634, RY_45)) && LtN(Get(b_629, "y"), RY_45)) && LtN(Get(b_629, "vy"), 0D)) && (Hypot((ToNum(Get(b_629, "x")) - ToNum(h_631)), (ToNum(Get(b_629, "z")) - RZ_46)) < (RR_43 - 0.02)))) {
Set(b_629, "scored", ((V)(1D)));
Set(@out_633, "scored", ((V)(1D)));
Set(@out_633, "swish", ((V)(((!(Truthy(Get(b_629, "rim"))) && !(Truthy(Get(b_629, "board")))) ? 1D : 0D))));
Set(@out_633, "tScore", t_632);
Invoke(Get(@out_633, "ev"), "push", Arr(t_632, ((V)("basket"))));
}
if (LtN(Get(b_629, "y"), BR_42)) {
Set(b_629, "y", ((V)(BR_42)));
if ((System.Math.Abs(ToNum(Get(b_629, "vy"))) > 1.2)) {
IncM(b_629, "bounces", 1D, false);
Invoke(Get(@out_633, "ev"), "push", Arr(t_632, ((V)("ground"))));
if (LtN(Get(@out_633, "tGround"), 0D)) {
Set(@out_633, "tGround", t_632);
}
}
Set(b_629, "vy", ((V)(((-ToNum(Get(b_629, "vy"))) * 0.55))));
OpSet(b_629, "vx", 2, ((V)(0.8)));
OpSet(b_629, "vz", 2, ((V)(0.8)));
if ((System.Math.Abs(ToNum(Get(b_629, "vy"))) < 0.6)) {
Set(b_629, "vy", ((V)(0D)));
}
}
return default;
}, 5, "stepB", false);
sim_88 = Fn((V _self652, int _argc653, V k_659, V a_660, V tL_661, V _a658, V[] _rest654) => {
V v_662 = default;
double ph_663 = 0;
double ct_664 = 0;
V b_665 = default;
V @out_666 = default;
double n_667 = 0;
if (_self652.IsNullish) _self652 = GlobalV;
v_662 = Call(vOf_66, V.Undef, k_659);
ph_663 = (PH0_64 + ((Sign(ToNum(a_660)) * Pow(System.Math.Abs(ToNum(a_660)), 1.8)) * 0.16));
ct_664 = FdLibm.Cos(TH_53);
b_665 = NewObj(10).Put("x", GetIdx(REL_55, 0D)).Put("y", GetIdx(REL_55, 1D)).Put("z", GetIdx(REL_55, 2D)).Put("vx", ((V)(((FdLibm.Sin(ph_663) * ToNum(v_662)) * ct_664)))).Put("vz", ((V)(((FdLibm.Cos(ph_663) * ToNum(v_662)) * ct_664)))).Put("vy", ((V)((ToNum(v_662) * FdLibm.Sin(TH_53))))).Put("rim", ((V)(0D))).Put("board", ((V)(0D))).Put("scored", ((V)(0D))).Put("bounces", ((V)(0D))).V;
@out_666 = NewObj(9).Put("pos", Arr()).Put("ev", Arr()).Put("scored", ((V)(0D))).Put("swish", ((V)(0D))).Put("tScore", ((V)((-1D)))).Put("tGround", ((V)((-1D)))).Put("k", k_659).Put("a", a_660).Put("tL", tL_661).V;
n_667 = Round((LIFE_59 / DT_58));
{
double i_668 = 0;
i_668 = 0D;
while (true) {
if (!((i_668 <= n_667))) break;
double t_670 = 0;
t_670 = (i_668 * DT_58);
Invoke(Get(@out_666, "pos"), "push", Arr(Get(b_665, "x"), Get(b_665, "y"), Get(b_665, "z")));
Call(stepB_87, V.Undef, b_665, ((V)(DT_58)), Call(hxAt_71, V.Undef, Add(tL_661, ((V)((t_670 * 1000D))))), ((V)(t_670)), @out_666);
i_668++;
}
}
return @out_666;
return default;
}, 3, "sim", false);
mkBall_106 = Fn((V _self671, int _argc672, V layer_678, V _a675, V _a676, V _a677, V[] _rest673) => {
V g_679 = default;
V sh_680 = default;
V b_681 = default;
V sm_682 = default;
V hl_683 = default;
V fl_684 = default;
if (_self671.IsNullish) _self671 = GlobalV;
g_679 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, (layer_678 is var _t685 && Truthy(_t685) ? _t685 : slotH_80));
sh_680 = Call(S_16, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#2a2034"))).Put("opacity", ((V)(0.18))).V, shG_74);
b_681 = Call(S_16, V.Undef, ((V)("circle")), NewObj(2).Put("r", ((V)(10D))).Put("fill", ((V)("url(#ygBall)"))).V, g_679);
sm_682 = Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#7a3410"))).Put("stroke-width", ((V)(1.4))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.85))).V, g_679);
hl_683 = Call(S_16, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.35))).V, g_679);
fl_684 = Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd84a"))).Put("stroke-width", ((V)(2D))).Put("opacity", ((V)(0D))).V, g_679);
return NewObj(12).Put("g", g_679).Put("sh", sh_680).Put("b", b_681).Put("sm", sm_682).Put("hl", hl_683).Put("fl", fl_684).Put("x", GetIdx(HOLD_54, 0D)).Put("y", GetIdx(HOLD_54, 1D)).Put("z", GetIdx(HOLD_54, 2D)).Put("spin", ((V)(0D))).Put("born", tNow_101).Put("fire", ((V)(0D))).V;
return default;
}, 1, "mkBall", false);
drawBall_107 = Fn((V _self686, int _argc687, V o_693, V t_694, V _a691, V _a692, V[] _rest688) => {
V s_695 = default;
double r_696 = 0;
V sp_697 = default;
double c_698 = 0;
double sn_699 = 0;
V g0_700 = default;
V hgt_701 = default;
if (_self686.IsNullish) _self686 = GlobalV;
s_695 = Call(P_40, V.Undef, Get(o_693, "x"), Get(o_693, "y"), Get(o_693, "z"));
r_696 = ((BR_42 * ToNum(GetIdx(s_695, 2D))) * ToNum((Get(o_693, "pop").IsNullish ? ((V)(1D)) : Get(o_693, "pop"))));
Invoke(Get(o_693, "b"), "setAttribute", ((V)("cx")), Call(r2_19, V.Undef, GetIdx(s_695, 0D)));
Invoke(Get(o_693, "b"), "setAttribute", ((V)("cy")), Call(r2_19, V.Undef, GetIdx(s_695, 1D)));
Invoke(Get(o_693, "b"), "setAttribute", ((V)("r")), Call(r2_19, V.Undef, ((V)(r_696))));
sp_697 = Get(o_693, "spin");
c_698 = FdLibm.Cos(ToNum(sp_697));
sn_699 = FdLibm.Sin(ToNum(sp_697));
Invoke(Get(o_693, "sm"), "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(s_695, 0D)) - (r_696 * c_698)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(s_695, 1D)) - (r_696 * sn_699)))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(s_695, 0D), ((V)((r_696 * c_698)))))).S(" ").V(Call(r2_19, V.Undef, Add(GetIdx(s_695, 1D), ((V)((r_696 * sn_699)))))).S("M").V(Call(r2_19, V.Undef, Add(GetIdx(s_695, 0D), ((V)((r_696 * sn_699)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(s_695, 1D)) - (r_696 * c_698)))))).S("Q").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(s_695, 0D)) - ((r_696 * 0.25) * c_698)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(s_695, 1D)) - ((r_696 * 0.25) * sn_699)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(s_695, 0D)) - (r_696 * sn_699)))))).S(" ").V(Call(r2_19, V.Undef, Add(GetIdx(s_695, 1D), ((V)((r_696 * c_698)))))).End())));
Invoke(Get(o_693, "hl"), "setAttribute", ((V)("cx")), Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(s_695, 0D)) - (r_696 * 0.35))))));
Invoke(Get(o_693, "hl"), "setAttribute", ((V)("cy")), Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(s_695, 1D)) - (r_696 * 0.4))))));
Invoke(Get(o_693, "hl"), "setAttribute", ((V)("rx")), Call(r2_19, V.Undef, ((V)((r_696 * 0.4)))));
Invoke(Get(o_693, "hl"), "setAttribute", ((V)("ry")), Call(r2_19, V.Undef, ((V)((r_696 * 0.25)))));
Invoke(Get(o_693, "fl"), "setAttribute", ((V)("cx")), Call(r2_19, V.Undef, GetIdx(s_695, 0D)));
Invoke(Get(o_693, "fl"), "setAttribute", ((V)("cy")), Call(r2_19, V.Undef, GetIdx(s_695, 1D)));
Invoke(Get(o_693, "fl"), "setAttribute", ((V)("r")), Call(r2_19, V.Undef, ((V)((r_696 + 2D)))));
Invoke(Get(o_693, "fl"), "setAttribute", ((V)("opacity")), ((V)((Truthy(Get(o_693, "fire")) ? (0.5 + (0.4 * FdLibm.Sin((ToNum(t_694) / 60D)))) : 0D))));
g0_700 = Call(P_40, V.Undef, Get(o_693, "x"), ((V)(0D)), Get(o_693, "z"));
hgt_701 = Call(cl_17, V.Undef, ((V)((1D - (ToNum(Get(o_693, "y")) / 4D)))), ((V)(0.25)), ((V)(1D)));
Invoke(Get(o_693, "sh"), "setAttribute", ((V)("cx")), Call(r2_19, V.Undef, Add(GetIdx(g0_700, 0D), ((V)((ToNum(Get(o_693, "y")) * 3D))))));
Invoke(Get(o_693, "sh"), "setAttribute", ((V)("cy")), Call(r2_19, V.Undef, GetIdx(g0_700, 1D)));
Invoke(Get(o_693, "sh"), "setAttribute", ((V)("rx")), Call(r2_19, V.Undef, ((V)((((BR_42 * ToNum(GetIdx(g0_700, 2D))) * 1.1) * ToNum(hgt_701))))));
Invoke(Get(o_693, "sh"), "setAttribute", ((V)("ry")), Call(r2_19, V.Undef, ((V)((((BR_42 * ToNum(GetIdx(g0_700, 2D))) * 0.3) * ToNum(hgt_701))))));
Invoke(Get(o_693, "sh"), "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, ((V)((0.2 * ToNum(hgt_701))))));
return default;
}, 2, "drawBall", false);
pullOf_108 = Fn((V _self702, int _argc703, V d_709, V _a706, V _a707, V _a708, V[] _rest704) => {
double len_710 = 0;
if (_self702.IsNullish) _self702 = GlobalV;
len_710 = Hypot(ToNum(Get(d_709, "x")), ToNum(Get(d_709, "y")));
if ((LtN(Get(d_709, "y"), 6D) || (len_710 < 16D))) {
return V.Null;
}
return NewObj(2).Put("k", Call(cl_17, V.Undef, ((V)(((len_710 - 16D) / PULL_57))), ((V)(0D)), ((V)(1D)))).Put("a", Call(cl_17, V.Undef, ((V)((((-ToNum(Get(d_709, "x"))) / Max(60D, ToNum(Get(d_709, "y")))) * 0.9))), ((V)((-1.2))), ((V)(1.2)))).V;
return default;
}, 1, "pullOf", false);
drawPath_109 = Fn((V _self711, int _argc712, V S1_718, V _a715, V _a716, V _a717, V[] _rest713) => {
V ok_719 = default;
V col_720 = default;
V end_721 = default;
V c_722 = default;
if (_self711.IsNullish) _self711 = GlobalV;
Set(pathG_79, "innerHTML", ((V)("")));
Set(bandG_81, "innerHTML", ((V)("")));
if ((!(Truthy(S1_718)) || !(Truthy(aim_102)))) {
return default;
}
ok_719 = Get(S1_718, "scored");
col_720 = ((V)((Truthy(ok_719) ? "#38d96a" : "#ff4d5e")));
end_721 = (Truthy(ok_719) ? Add(Get(S1_718, "tScore"), ((V)(0.14))) : ((V)(Min(1.7, ToNum((GtN(Get(S1_718, "tGround"), 0D) ? Get(S1_718, "tGround") : ((V)(1.7)))), ToNum(Add(GetIdx((Invoke(Get(S1_718, "ev"), "find", Fn((V _self711, int _argc723, V e_729, V _a726, V _a727, V _a728, V[] _rest724) => {
return ((SEqS(GetIdx(e_729, 1D), "rim") || SEqS(GetIdx(e_729, 1D), "board")) ? V.True : V.False);
}, 1, "", true)) is var _t730 && Truthy(_t730) ? _t730 : Arr(((V)(9D)))), 0D), ((V)(0.35))))))));
{
double t_731 = 0;
double i_732 = 0;
t_731 = 0.03;
i_732 = 0D;
while (true) {
if (!(Le(((V)(t_731)), end_721))) break;
V p_734 = default;
V s_735 = default;
V r_736 = default;
p_734 = Call(posAt_89, V.Undef, S1_718, ((V)(t_731)));
s_735 = Call(P_40, V.Undef, GetIdx(p_734, 0D), GetIdx(p_734, 1D), GetIdx(p_734, 2D));
r_736 = Call(cl_17, V.Undef, ((V)(((2.9 * ToNum(GetIdx(s_735, 2D))) / 170D))), ((V)(1.4)), ((V)(3.2)));
Call(S_16, V.Undef, ((V)("circle")), NewObj(5).Put("cx", Call(r2_19, V.Undef, GetIdx(s_735, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(s_735, 1D))).Put("r", Call(r2_19, V.Undef, Add(r_736, ((V)(1.1))))).Put("fill", ((V)("#1e1430"))).Put("opacity", ((V)(0.32))).V, pathG_79);
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, GetIdx(s_735, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(s_735, 1D))).Put("r", Call(r2_19, V.Undef, r_736)).Put("fill", col_720).V, pathG_79);
t_731 = (t_731 + (1D / 30D));
i_732++;
}
}
c_722 = Call(P_40, V.Undef, Call(hxAt_71, V.Undef, Add(Get(S1_718, "tL"), ((V)((ToNum(Get(S1_718, "tScore")) * 1000D))))), ((V)(RY_45)), ((V)(RZ_46)));
if (Truthy(ok_719)) {
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(8).Put("cx", Call(r2_19, V.Undef, GetIdx(c_722, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(c_722, 1D))).Put("rx", Call(r2_19, V.Undef, ((V)(((RR_43 * ToNum(GetIdx(c_722, 2D))) + 4D))))).Put("ry", Call(r2_19, V.Undef, ((V)((((RR_43 * ToNum(GetIdx(c_722, 2D))) * 0.3) + 3D))))).Put("fill", ((V)("none"))).Put("stroke", col_720).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.9))).V, pathG_79);
}
Call(S_16, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, Get(aim_102, "x0"))).S(" ").V(Call(r2_19, V.Undef, Get(aim_102, "y0"))).S("L").V(Call(r2_19, V.Undef, Get(aim_102, "x"))).S(" ").V(Call(r2_19, V.Undef, Get(aim_102, "y"))).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(3D))).Put("stroke-dasharray", ((V)("2 6"))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.8))).V, bandG_81);
Call(S_16, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_19, V.Undef, Get(aim_102, "x0"))).Put("cy", Call(r2_19, V.Undef, Get(aim_102, "y0"))).Put("r", ((V)(6D))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.85))).V, bandG_81);
Call(S_16, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_19, V.Undef, Get(aim_102, "x"))).Put("cy", Call(r2_19, V.Undef, Get(aim_102, "y"))).Put("r", ((V)(9D))).Put("fill", col_720).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.95))).V, bandG_81);
return default;
}, 1, "drawPath", false);
release_110 = Fn((V _self737, int _argc738, V k_744, V a_745, V S0_746, V _a743, V[] _rest739) => {
V tL_747 = default;
V S1_748 = default;
if (_self737.IsNullish) _self737 = GlobalV;
if (Truthy(((!(Truthy(held_94)) ? V.True : V.False) is var _t749 && Truthy(_t749) ? _t749 : thr_103))) {
return default;
}
tL_747 = (Truthy(S0_746) ? Get(S0_746, "tL") : Add(tNow_101, ((V)(THROW_56))));
S1_748 = (Truthy((S0_746 is var _t750 && !Truthy(_t750) ? _t750 : ((System.Math.Abs((ToNum(Get(S0_746, "tL")) - ToNum(tL_747))) < 1D) ? V.True : V.False))) ? S0_746 : Call(sim_88, V.Undef, k_744, a_745, tL_747));
thr_103 = NewObj(6).Put("t0", tNow_101).Put("tL", tL_747).Put("k", k_744).Put("a", a_745).Put("S", S1_748).Put("from", Arr(Get(held_94, "x"), Get(held_94, "y"), Get(held_94, "z"))).V;
aim_102 = V.Null;
Call(drawPath_109, V.Undef, V.Null);
Invoke(SFX_20, "whoosh");
return default;
}, 3, "release", false);
launch_111 = Fn((V _self751, int _argc752, V _a754, V _a755, V _a756, V _a757, V[] _rest753) => {
V b_758 = default;
if (_self751.IsNullish) _self751 = GlobalV;
b_758 = held_94;
held_94 = V.Null;
Set(b_758, "S", Get(thr_103, "S"));
Set(b_758, "tl", Get(thr_103, "tL"));
Set(b_758, "fired", ((V)(0D)));
Set(b_758, "fire", ((V)(((fire_97 > 0D) ? 1D : 0D))));
Set(b_758, "missed", ((V)(0D)));
Invoke(balls_93, "push", b_758);
lastThrow_104 = NewObj(2).Put("tL", Get(thr_103, "tL")).Put("k", Get(thr_103, "k")).V;
thr_103 = V.Null;
nextAt_95 = Add(tNow_101, ((V)(640D)));
return default;
}, 0, "launch", false);
basket_112 = Fn((V _self759, int _argc760, V b_766, V _a763, V _a764, V _a765, V[] _rest761) => {
V sw_767 = default;
double pts_768 = 0;
V c_769 = default;
if (_self759.IsNullish) _self759 = GlobalV;
made_100++;
sw_767 = Get(Get(b_766, "S"), "swish");
streak_96++;
if (((streak_96 >= 3D) && !(NumTruthy(fire_97)))) {
fire_97 = 1D;
Invoke(ctx_35, "toast", ((V)("On fire!")), ((V)((ToNum(W_38) / 2D))), ((V)((ToNum(H_39) * 0.34))), ((V)("#ffb03a")), (true ? V.True : V.False));
Invoke(SFX_20, "win");
}
pts_768 = ((Truthy(sw_767) ? 3D : 2D) * (NumTruthy(fire_97) ? 2D : 1D));
c_769 = Call(P_40, V.Undef, hx_82, ((V)(RY_45)), ((V)(RZ_46)));
Invoke(ctx_35, "add", ((V)(pts_768)), GetIdx(c_769, 0D), ((V)((ToNum(GetIdx(c_769, 1D)) - 30D))), ((V)(JsStrBuf.Begin().S((Truthy(sw_767) ? "Swish! +" : "+")).N(pts_768).End())), ((V)((Truthy(sw_767) ? "#8fe0ff" : "#ffffff"))));
Invoke(ctx_35, "burst", GetIdx(c_769, 0D), Add(GetIdx(c_769, 1D), ((V)(8D))), ((V)("confetti")), ((V)(14D)), NewObj(2).Put("v", ((V)(120D))).Put("life", ((V)(0.9))).V);
netSw_83 = 1D;
netAt_84 = tNow_101;
cheerT_98 = tNow_101;
Invoke(SFX_20, "swish");
Call(G("setTimeout"), V.Undef, Get(SFX_20, "score"), ((V)(80D)));
if (Truthy((Get(ctx_35, "addTime") is var _t770 && !Truthy(_t770) ? _t770 : Get(ctx_35, "playing")))) {
Invoke(ctx_35, "addTime", ((V)(10D)));
Invoke(ctx_35, "toast", ((V)("+10s")), ((V)((ToNum(W_38) - 64D))), ((V)(78D)), ((V)("#9dffb0")));
}
return default;
}, 1, "basket", false);
missed_113 = Fn((V _self771, int _argc772, V _a774, V _a775, V _a776, V _a777, V[] _rest773) => {
if (_self771.IsNullish) _self771 = GlobalV;
missT_99 = tNow_101;
if (NumTruthy(streak_96)) {
streak_96 = 0D;
if (NumTruthy(fire_97)) {
fire_97 = 0D;
Invoke(ctx_35, "toast", ((V)("Fire out")), ((V)((ToNum(W_38) / 2D))), ((V)((ToNum(H_39) * 0.34))), ((V)("#ffffff")));
}
}
return default;
}, 0, "missed", false);
schedule_114 = Fn((V _self778, int _argc779, V _a781, V _a782, V _a783, V _a784, V[] _rest780) => {
V busyTo_785 = default;
if (_self778.IsNullish) _self778 = GlobalV;
busyTo_785 = Add(InvokeSpread(G("Math"), "max", new ArrBuilder().Add(tNow_101).Spread(Invoke(balls_93, "map", Fn((V _self778, int _argc786, V b_792, V _a789, V _a790, V _a791, V[] _rest787) => {
return Add(Get(b_792, "tl"), ((V)(2400D)));
}, 1, "", true))).Add((Truthy(thr_103) ? Add(Get(thr_103, "tL"), ((V)(2400D))) : ((V)(0D)))).Add((Truthy(aim_102) ? Add(Add(tNow_101, ((V)(THROW_56))), ((V)(2400D))) : ((V)(0D)))).V), ((V)(300D)));
if (((GeN(Get(ctx_35, "score"), 20D) && SEqN(Get(M_70, "t1"), double.PositiveInfinity)) && !(Truthy(Get(api_117, "_still"))))) {
Set(M_70, "t1", busyTo_785);
Call(G("setTimeout"), V.Undef, Fn((V _self778, int _argc799, V _a801, V _a802, V _a803, V _a804, V[] _rest800) => {
if (Truthy(Get(ctx_35, "playing"))) {
Invoke(ctx_35, "toast", ((V)("The hoop moves!")), ((V)((ToNum(W_38) / 2D))), ((V)((ToNum(H_39) * 0.34))), ((V)("#ffe36e")));
}
return default;
}, 0, "", true), ((V)(Max(0D, (ToNum(Get(M_70, "t1")) - ToNum(tNow_101))))));
}
if (((GeN(Get(ctx_35, "score"), 50D) && LtN(Get(M_70, "t1"), double.PositiveInfinity)) && SEqN(Get(M_70, "t2"), double.PositiveInfinity))) {
Set(M_70, "t2", ((V)(Max(ToNum(busyTo_785), ToNum(Add(Get(M_70, "t1"), ((V)(1500D))))))));
}
return default;
}, 0, "schedule", false);
poseMe_115 = Fn((V _self805, int _argc806, V t_812, V _a809, V _a810, V _a811, V[] _rest807) => {
V E_813 = default;
double tc_814 = 0;
double tm_815 = 0;
if (_self805.IsNullish) _self805 = GlobalV;
E_813 = NewObj(6).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).V;
if (Truthy(thr_103)) {
V u_816 = default;
V k_817 = default;
V w_818 = default;
u_816 = Call(cl_17, V.Undef, ((V)(((ToNum(t_812) - ToNum(Get(thr_103, "t0"))) / Max(1D, (ToNum(Get(thr_103, "tL")) - ToNum(Get(thr_103, "t0"))))))), ((V)(0D)), ((V)(1D)));
k_817 = Get(thr_103, "k");
w_818 = NewObj(4).Put("armL", ((V)((128D - (34D * ToNum(k_817)))))).Put("armR", ((V)((128D - (34D * ToNum(k_817)))))).Put("lift", ((V)(((-1.6) * ToNum(k_817))))).Put("sq", ((V)((0.12 * ToNum(k_817))))).V;
E_813 = NewObj(6).Put("armL", Call(lerp_18, V.Undef, Get(w_818, "armL"), ((V)(172D)), Call(eo_61, V.Undef, u_816))).Put("armR", Call(lerp_18, V.Undef, Get(w_818, "armR"), ((V)(172D)), Call(eo_61, V.Undef, u_816))).Put("lift", Call(lerp_18, V.Undef, Get(w_818, "lift"), ((V)(7D)), Call(eo_61, V.Undef, u_816))).Put("sq", Call(lerp_18, V.Undef, Get(w_818, "sq"), ((V)((-0.1))), Call(eo_61, V.Undef, u_816))).Put("tilt", ((V)(((ToNum(Get(thr_103, "a")) * 6D) * (1D - ToNum(u_816)))))).Put("lean", ((V)(0D))).V;
} else {
if (Truthy((lastThrow_104 is var _t819 && !Truthy(_t819) ? _t819 : (((ToNum(t_812) - ToNum(Get(lastThrow_104, "tL"))) < 900D) ? V.True : V.False)))) {
double tt_820 = 0;
double up_821 = 0;
tt_820 = (ToNum(t_812) - ToNum(Get(lastThrow_104, "tL")));
up_821 = ((tt_820 < 360D) ? 1D : (1D - ToNum(Call(SM_60, V.Undef, ((V)(((tt_820 - 360D) / 360D)))))));
Set(E_813, "armL", Set(E_813, "armR", Call(lerp_18, V.Undef, ((V)(40D)), ((V)(172D)), ((V)(up_821)))));
Set(E_813, "lift", ((V)(((tt_820 < 380D) ? ((7D + (FdLibm.Sin((Min(1D, (tt_820 / 380D)) * System.Math.PI)) * 5D)) - (7D * ToNum(Call(SM_60, V.Undef, ((V)((tt_820 / 380D))))))) : 0D))));
Set(E_813, "sq", ((V)(((tt_820 < 380D) ? ((-0.1) * (1D - (tt_820 / 380D))) : (0.08 * FdLibm.Sin((ToNum(Call(cl_17, V.Undef, ((V)(((tt_820 - 380D) / 260D))), ((V)(0D)), ((V)(1D)))) * System.Math.PI)))))));
}
}
if (Truthy((held_94 is var _t822 && !Truthy(_t822) ? _t822 : (!(Truthy(thr_103)) ? V.True : V.False)))) {
V k_823 = default;
V kk_824 = default;
V born_825 = default;
k_823 = (Truthy((aim_102 is var _t826 && !Truthy(_t826) ? _t826 : Get(aim_102, "p"))) ? Get(Get(aim_102, "p"), "k") : ((V)(0D)));
kk_824 = Set(held_94, "kk", Call(lerp_18, V.Undef, (Get(held_94, "kk") is var _t827 && Truthy(_t827) ? _t827 : ((V)(0D))), k_823, ((V)(0.35))));
born_825 = Call(cl_17, V.Undef, ((V)(((ToNum(t_812) - ToNum(Get(held_94, "born"))) / 260D))), ((V)(0D)), ((V)(1D)));
Set(E_813, "armL", Call(lerp_18, V.Undef, Get(E_813, "armL"), ((V)((128D - (34D * ToNum(kk_824))))), born_825));
Set(E_813, "armR", Call(lerp_18, V.Undef, Get(E_813, "armR"), ((V)((128D - (34D * ToNum(kk_824))))), born_825));
OpSet(E_813, "sq", 0, ((V)((0.12 * ToNum(kk_824)))));
OpSet(E_813, "lift", 0, ((V)(((-1.6) * ToNum(kk_824)))));
OpSet(E_813, "tilt", 0, ((V)((Truthy((aim_102 is var _t828 && !Truthy(_t828) ? _t828 : Get(aim_102, "p"))) ? ((ToNum(Get(Get(aim_102, "p"), "a")) * 6D) * ToNum(kk_824)) : 0D))));
}
tc_814 = (ToNum(t_812) - ToNum(cheerT_98));
if ((tc_814 < 700D)) {
double u_829 = 0;
double s_830 = 0;
u_829 = (tc_814 / 700D);
s_830 = FdLibm.Sin((u_829 * System.Math.PI));
OpSet(E_813, "lift", 0, ((V)((s_830 * 9D))));
Set(E_813, "armL", Call(lerp_18, V.Undef, Get(E_813, "armL"), ((V)((150D + (20D * FdLibm.Sin((tc_814 / 60D)))))), ((V)(s_830))));
Set(E_813, "armR", Call(lerp_18, V.Undef, Get(E_813, "armR"), ((V)((150D - (20D * FdLibm.Sin((tc_814 / 60D)))))), ((V)(s_830))));
Set(E_813, "smile", ((V)(s_830)));
}
tm_815 = (ToNum(t_812) - ToNum(missT_99));
if (((tm_815 < 600D) && (tc_814 > 700D))) {
double s_831 = 0;
s_831 = FdLibm.Sin(((tm_815 / 600D) * System.Math.PI));
OpSet(E_813, "sq", 0, ((V)((0.05 * s_831))));
OpSet(E_813, "armL", 1, ((V)((14D * s_831))));
OpSet(E_813, "armR", 1, ((V)((14D * s_831))));
}
Invoke(me_90, "pose", E_813);
Invoke(me_90, "yaw", ((V)((((180D - ((PH0_64 * 57.3) * 0.8)) + (FdLibm.Sin((ToNum(t_812) / 900D)) * 4D)) + (ToNum(Get(E_813, "tilt")) * 0.6)))));
return default;
}, 1, "poseMe", false);
pawsAt_116 = Fn((V _self832, int _argc833, V _a835, V _a836, V _a837, V _a838, V[] _rest834) => {
V I_839 = default;
V L_840 = default;
V R_841 = default;
V sz_842 = default;
double sx_843 = 0;
double sy_844 = 0;
V z_845 = default;
V p0_846 = default;
if (_self832.IsNullish) _self832 = GlobalV;
I_839 = Get(me_90, "I");
L_840 = ((I_839 is var _t847 && !Truthy(_t847) ? _t847 : Get(I_839, "W")) is var _t848 && !Truthy(_t848) ? _t848 : Get(Get(I_839, "W"), "pawL"));
R_841 = ((I_839 is var _t849 && !Truthy(_t849) ? _t849 : Get(I_839, "W")) is var _t850 && !Truthy(_t850) ? _t850 : Get(Get(I_839, "W"), "pawR"));
if (((!(Truthy(L_840)) || !(Truthy(R_841))) || !(IsFiniteV(Add(Add(Add(GetIdx(L_840, 0D), GetIdx(L_840, 1D)), GetIdx(R_841, 0D)), GetIdx(R_841, 1D)))))) {
return V.Null;
}
sz_842 = Get(me_90, "size");
sx_843 = ((ToNum(Get(me_90, "x")) - (ToNum(sz_842) / 2D)) + ((ToNum(Add(GetIdx(L_840, 0D), GetIdx(R_841, 0D))) / 200D) * ToNum(sz_842)));
sy_844 = ((ToNum(Get(me_90, "y")) - (ToNum(sz_842) * 0.93)) + ((ToNum(Add(GetIdx(L_840, 1D), GetIdx(R_841, 1D))) / 200D) * ToNum(sz_842)));
z_845 = GetIdx(HOLD_54, 2D);
p0_846 = Call(P_40, V.Undef, ((V)(0D)), ((V)(0D)), z_845);
return Arr(((V)(((sx_843 - ToNum(GetIdx(p0_846, 0D))) / ToNum(GetIdx(p0_846, 2D))))), ((V)((((ToNum(GetIdx(p0_846, 1D)) - sy_844) / ToNum(GetIdx(p0_846, 2D))) + (BR_42 * 0.3)))), z_845);
return default;
}, 0, "pawsAt", false);
{ V _t851 = ctx_35;
if (_t851.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t851));
{ V _t852 = Get(_t851, "bg");
bg_36 = _t852; }
{ V _t853 = Get(_t851, "fg");
fg_37 = _t853; }
{ V _t854 = Get(_t851, "W");
W_38 = _t854; }
{ V _t855 = Get(_t851, "H");
H_39 = _t855; } }
P_40 = Invoke(YG_15, "cam", ((V)(2.4)), ((V)(1.9)), ((V)(166D)), ((V)(112D)));
G_41 = 9.8;
BR_42 = 0.12;
RR_43 = 0.23;
RT_44 = 0.018;
RY_45 = 3.05;
RZ_46 = 5D;
BZ_47 = 5.38;
PZ_48 = 5.72;
GZ_49 = 7.6;
DW_50 = 1.8;
FZ_51 = 0.95;
PX_52 = 0D;
TH_53 = ((62D * System.Math.PI) / 180D);
HOLD_54 = Arr(((V)(PX_52)), ((V)(1D)), ((V)((0.36 + FZ_51))));
REL_55 = Arr(((V)(PX_52)), ((V)(1.34)), ((V)((0.44 + FZ_51))));
THROW_56 = 120D;
PULL_57 = 95D;
DT_58 = (1D / 240D);
LIFE_59 = 3.2;
SM_60 = Get(YG_15, "SM");
eo_61 = Fn((V _self28, int _argc856, V u_862, V _a859, V _a860, V _a861, V[] _rest857) => {
return ((V)((1D - ((1D - ToNum(u_862)) * (1D - ToNum(u_862))))));
}, 1, "", true);
ei_62 = Fn((V _self28, int _argc863, V u_869, V _a866, V _a867, V _a868, V[] _rest864) => {
return ((V)((ToNum(u_869) * ToNum(u_869))));
}, 1, "", true);
L0_63 = Hypot((0D - ToNum(GetIdx(REL_55, 0D))), ((RZ_46 + 0.03) - ToNum(GetIdx(REL_55, 2D))));
PH0_64 = FdLibm.Atan2((0D - ToNum(GetIdx(REL_55, 0D))), ((RZ_46 + 0.03) - ToNum(GetIdx(REL_55, 2D))));
vMid_65 = Call(Fn((V _self28, int _argc870, V _a872, V _a873, V _a874, V _a875, V[] _rest871) => {
double dz_876 = 0;
double dy_877 = 0;
double ct_878 = 0;
dz_876 = L0_63;
dy_877 = (RY_45 - ToNum(GetIdx(REL_55, 1D)));
ct_878 = FdLibm.Cos(TH_53);
return ((V)(System.Math.Sqrt((((G_41 * dz_876) * dz_876) / (((2D * ct_878) * ct_878) * ((dz_876 * FdLibm.Tan(TH_53)) - dy_877))))));
return default;
}, 0, "", true), V.Undef);
vOf_66 = Fn((V _self28, int _argc879, V k_885, V _a882, V _a883, V _a884, V[] _rest880) => {
return ((V)((ToNum(vMid_65) * (0.94 + (0.12 * ToNum(k_885))))));
}, 1, "", true);
AMP_67 = 0.75;
W1_68 = 0.9;
W2_69 = 1.35;
M_70 = NewObj(2).Put("t1", ((V)(double.PositiveInfinity))).Put("t2", ((V)(double.PositiveInfinity))).V;
hxAt_71 = Fn((V _self28, int _argc886, V t_892, V _a889, V _a890, V _a891, V[] _rest887) => {
double a_893 = 0;
double ph_894 = 0;
if (Truthy((Get(api_117, "_still") is var _t895 && Truthy(_t895) ? _t895 : (Le(t_892, Get(M_70, "t1")) ? V.True : V.False)))) {
return ((V)(0D));
}
a_893 = (AMP_67 * Min(1D, ((ToNum(t_892) - ToNum(Get(M_70, "t1"))) / 1500D)));
ph_894 = (Le(t_892, Get(M_70, "t2")) ? (((ToNum(t_892) - ToNum(Get(M_70, "t1"))) / 1000D) * W1_68) : ((((ToNum(Get(M_70, "t2")) - ToNum(Get(M_70, "t1"))) / 1000D) * W1_68) + (((ToNum(t_892) - ToNum(Get(M_70, "t2"))) / 1000D) * W2_69)));
return ((V)((FdLibm.Sin(ph_894) * a_893)));
return default;
}, 1, "", true);
court_72 = Call(S_16, V.Undef, ((V)("svg")), NewObj(3).Put("viewBox", ((V)(JsStrBuf.Begin().S("0 0 ").V(W_38).S(" ").V(H_39).End()))).Put("class", ((V)("yg-layer"))).Put("preserveAspectRatio", ((V)("none"))).V);
Invoke(Get(bg_36, "parentNode"), "insertBefore", court_72, bg_36);
Call(drawCourt_73, V.Undef, court_72);
shG_74 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_36);
hoopG_75 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_36);
backG_76 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, hoopG_75);
slotB_77 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, hoopG_75);
frontG_78 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, hoopG_75);
pathG_79 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_36);
slotH_80 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_36);
bandG_81 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, fg_37);
{
V d_896 = default;
d_896 = Call(S_16, V.Undef, ((V)("defs")), NewObj(0).V, bg_36);
Set(d_896, "innerHTML", ((V)(string.Concat("<linearGradient id=\"hcPole\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#2c2c36\"/><stop offset=\"0.45\" stop-color=\"#6a6a7a\"/><stop offset=\"1\" stop-color=\"#2c2c36\"/></linearGradient>", "<linearGradient id=\"hcPad\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#1f4fa8\"/><stop offset=\"0.45\" stop-color=\"#3f7fe0\"/><stop offset=\"1\" stop-color=\"#1f4fa8\"/></linearGradient>", "<linearGradient id=\"hcBoard\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.92\"/><stop offset=\"1\" stop-color=\"#d9ecf8\" stop-opacity=\"0.92\"/></linearGradient>"))));
}
hx_82 = ((V)(0D));
netSw_83 = 0D;
netAt_84 = ((V)((-9D)));
lastHx_85 = V.Null;
posAt_89 = Fn((V _self28, int _argc897, V S1_903, V t_904, V _a901, V _a902, V[] _rest898) => {
V f_905 = default;
double i_906 = 0;
double u_907 = 0;
V A_908 = default;
V B_909 = default;
f_905 = Call(cl_17, V.Undef, ((V)((ToNum(t_904) / DT_58))), ((V)(0D)), ((V)((ToNum(Get(Get(S1_903, "pos"), "length")) - 1.001))));
i_906 = System.Math.Floor(ToNum(f_905));
u_907 = (ToNum(f_905) - i_906);
A_908 = GetIdx(Get(S1_903, "pos"), i_906);
B_909 = GetIdx(Get(S1_903, "pos"), (i_906 + 1D));
return Arr(Call(lerp_18, V.Undef, GetIdx(A_908, 0D), GetIdx(B_909, 0D), ((V)(u_907))), Call(lerp_18, V.Undef, GetIdx(A_908, 1D), GetIdx(B_909, 1D), ((V)(u_907))), Call(lerp_18, V.Undef, GetIdx(A_908, 2D), GetIdx(B_909, 2D), ((V)(u_907))));
return default;
}, 2, "", true);
me_90 = Invoke(ctx_35, "creature", Get(ctx_35, "playerKey"), NewObj(1).Put("yaw", ((V)(180D))).V);
f0_91 = Call(P_40, V.Undef, ((V)(PX_52)), ((V)(0D)), ((V)((0.25 + FZ_51))));
Invoke(me_90, "set", GetIdx(f0_91, 0D), GetIdx(f0_91, 1D), ((V)((1.12 * ToNum(GetIdx(f0_91, 2D))))));
meSh_92 = Invoke(YG_15, "shadow", shG_74, Add(GetIdx(f0_91, 0D), ((V)(((10D * ToNum(GetIdx(f0_91, 2D))) / 101.4)))), ((V)((ToNum(GetIdx(f0_91, 1D)) - 2D))), ((V)(((46D * ToNum(GetIdx(f0_91, 2D))) / 101.4))), ((V)(0.2)));
balls_93 = Arr();
held_94 = V.Null;
nextAt_95 = ((V)(0D));
streak_96 = 0D;
fire_97 = 0D;
cheerT_98 = ((V)((-9D)));
missT_99 = ((V)((-9D)));
made_100 = 0D;
tNow_101 = ((V)(0D));
aim_102 = V.Null;
thr_103 = V.Null;
lastThrow_104 = V.Null;
clangAt_105 = ((V)(0D));
api_117 = NewObj(16).Put("start", Fn((V _self910, int _argc911, V _a913, V _a914, V _a915, V _a916, V[] _rest912) => {
if (_self910.IsNullish) _self910 = GlobalV;
if (!(Truthy(held_94))) {
held_94 = Call(mkBall_106, V.Undef);
}
Invoke(balls_93, "forEach", Fn((V _self910, int _argc917, V b_923, V _a920, V _a921, V _a922, V[] _rest918) => {
Invoke(Get(b_923, "g"), "remove");
Invoke(Get(b_923, "sh"), "remove");
return default;
}, 1, "", true));
balls_93 = Arr();
streak_96 = 0D;
fire_97 = 0D;
made_100 = 0D;
Set(M_70, "t1", Set(M_70, "t2", ((V)(double.PositiveInfinity))));
hx_82 = ((V)(0D));
lastHx_85 = V.Null;
aim_102 = V.Null;
thr_103 = V.Null;
Call(drawPath_109, V.Undef, V.Null);
return default;
}, 0, "start", false)).Put("down", Fn((V _self924, int _argc925, V p_931, V _a928, V _a929, V _a930, V[] _rest926) => {
if (_self924.IsNullish) _self924 = GlobalV;
aim_102 = NewObj(6).Put("x0", Get(p_931, "x")).Put("y0", Get(p_931, "y")).Put("x", Get(p_931, "x")).Put("y", Get(p_931, "y")).Put("p", V.Null).Put("S", V.Null).V;
return default;
}, 1, "down", false)).Put("move", Fn((V _self932, int _argc933, V p_939, V _a936, V _a937, V _a938, V[] _rest934) => {
if (_self932.IsNullish) _self932 = GlobalV;
if (!(Truthy(aim_102))) {
return default;
}
Set(aim_102, "x", Get(p_939, "x"));
Set(aim_102, "y", Get(p_939, "y"));
return default;
}, 1, "move", false)).Put("up", Fn((V _self940, int _argc941, V p_947, V _a944, V _a945, V _a946, V[] _rest942) => {
V pp_948 = default;
V S0_949 = default;
if (_self940.IsNullish) _self940 = GlobalV;
if (!(Truthy(aim_102))) {
return default;
}
if (Truthy(p_947)) {
Set(aim_102, "x", Get(p_947, "x"));
Set(aim_102, "y", Get(p_947, "y"));
}
if (Truthy(((!(Truthy(held_94)) ? V.True : V.False) is var _t950 && Truthy(_t950) ? _t950 : thr_103))) {
aim_102 = V.Null;
Call(drawPath_109, V.Undef, V.Null);
return default;
}
pp_948 = Call(pullOf_108, V.Undef, NewObj(2).Put("x", ((V)((ToNum(Get(aim_102, "x")) - ToNum(Get(aim_102, "x0")))))).Put("y", ((V)((ToNum(Get(aim_102, "y")) - ToNum(Get(aim_102, "y0")))))).V);
S0_949 = Get(aim_102, "S");
if (!(Truthy(pp_948))) {
aim_102 = V.Null;
Call(drawPath_109, V.Undef, V.Null);
return default;
}
Call(release_110, V.Undef, Get(pp_948, "k"), Get(pp_948, "a"), S0_949);
return default;
}, 1, "up", false)).Put("key", Fn((V _self951, int _argc952, V k_958, V dn_959, V _a956, V _a957, V[] _rest953) => {
if (_self951.IsNullish) _self951 = GlobalV;
if (Truthy((dn_959 is var _t960 && !Truthy(_t960) ? _t960 : ((SEqS(k_958, " ") || SEqS(k_958, "ArrowUp")) ? V.True : V.False)))) {
if (Truthy((held_94 is var _t961 && !Truthy(_t961) ? _t961 : (!(Truthy(thr_103)) ? V.True : V.False)))) {
Call(release_110, V.Undef, ((V)(0.5)), ((V)(0D)));
}
return (true ? V.True : V.False);
}
return default;
}, 2, "key", false)).Put("_aim", Fn((V _self28, int _argc962, V k_968, V a_969, V _a966, V _a967, V[] _rest963) => {
aim_102 = NewObj(6).Put("x0", ((V)((ToNum(W_38) / 2D)))).Put("y0", ((V)((ToNum(H_39) * 0.45)))).Put("x", ((V)(((ToNum(W_38) / 2D) - (ToNum(a_969) * 60D))))).Put("y", ((V)((((ToNum(H_39) * 0.45) + 16D) + (ToNum(k_968) * PULL_57))))).Put("p", NewObj(2).Put("k", k_968).Put("a", a_969).V).Put("S", V.Null).V;
return default;
}, 2, "_aim", true)).Put("_shoot", Fn((V _self28, int _argc970, V k_976, V a_977, V _a974, V _a975, V[] _rest971) => {
if (Truthy((held_94 is var _t978 && !Truthy(_t978) ? _t978 : (!(Truthy(thr_103)) ? V.True : V.False)))) {
Call(release_110, V.Undef, k_976, (a_977.IsNullish ? ((V)(0D)) : a_977));
}
return default;
}, 2, "_shoot", true)).Put("_sim", Fn((V _self28, int _argc979, V k_985, V a_986, V tL_987, V _a984, V[] _rest980) => {
V S1_988 = default;
S1_988 = Call(sim_88, V.Undef, k_985, a_986, (tL_987.IsNullish ? tNow_101 : tL_987));
return NewObj(2).Put("scored", Get(S1_988, "scored")).Put("swish", Get(S1_988, "swish")).V;
return default;
}, 3, "_sim", true)).Put("_balls", Fn((V _self28, int _argc989, V _a991, V _a992, V _a993, V _a994, V[] _rest990) => {
return Invoke(balls_93, "map", Fn((V _self28, int _argc995, V b_1001, V _a998, V _a999, V _a1000, V[] _rest996) => {
return Arr(Get(Get(b_1001, "S"), "scored"), Get(b_1001, "fired"));
}, 1, "", true));
}, 0, "_balls", true)).Put("_M", M_70).Put("_still", (false ? V.True : V.False)).Put("_ready", Fn((V _self28, int _argc1002, V _a1004, V _a1005, V _a1006, V _a1007, V[] _rest1003) => {
return (((!(!(Truthy(held_94))) && !(Truthy(thr_103))) && !(Truthy(aim_102))) ? V.True : V.False);
}, 0, "_ready", true)).Put("timeUp", Fn((V _self1008, int _argc1009, V _a1011, V _a1012, V _a1013, V _a1014, V[] _rest1010) => {
if (_self1008.IsNullish) _self1008 = GlobalV;
aim_102 = V.Null;
Call(drawPath_109, V.Undef, V.Null);
Invoke(ctx_35, "finish", NewObj(1).Put("sub", ((V)(JsStrBuf.Begin().N(made_100).S(" basket").S(((made_100 == 1D) ? "" : "s")).End()))).V);
return default;
}, 0, "timeUp", false)).Put("celebrate", Fn((V _self1015, int _argc1016, V st_1022, V _a1019, V _a1020, V _a1021, V[] _rest1017) => {
if (_self1015.IsNullish) _self1015 = GlobalV;
if (GeN(st_1022, 2D)) {
cheerT_98 = tNow_101;
}
return default;
}, 1, "celebrate", false)).Put("destroy", Fn((V _self1023, int _argc1024, V _a1026, V _a1027, V _a1028, V _a1029, V[] _rest1025) => {
if (_self1023.IsNullish) _self1023 = GlobalV;
Invoke(court_72, "remove");
return default;
}, 0, "destroy", false)).Put("update", Fn((V _self1030, int _argc1031, V dt_1037, V t_1038, V _a1035, V _a1036, V[] _rest1032) => {
if (_self1030.IsNullish) _self1030 = GlobalV;
tNow_101 = t_1038;
hx_82 = Call(hxAt_71, V.Undef, t_1038);
Call(schedule_114, V.Undef);
if (Truthy(((((!(Truthy(held_94)) && !(Truthy(thr_103))) && Gt(t_1038, nextAt_95)) ? V.True : V.False) is var _t1039 && !Truthy(_t1039) ? _t1039 : Get(ctx_35, "playing")))) {
held_94 = Call(mkBall_106, V.Undef);
Set(held_94, "pop", ((V)(0D)));
}
if (Truthy((held_94 is var _t1040 && !Truthy(_t1040) ? _t1040 : (!Get(held_94, "pop").IsNullish ? V.True : V.False)))) {
Set(held_94, "pop", ((V)(Min(1D, ((ToNum(t_1038) - ToNum(Get(held_94, "born"))) / 220D)))));
if (GeN(Get(held_94, "pop"), 1D)) {
Set(held_94, "pop", V.Null);
}
}
if (Truthy(((aim_102 is var _t1041 && !Truthy(_t1041) ? _t1041 : held_94) is var _t1042 && !Truthy(_t1042) ? _t1042 : (!(Truthy(thr_103)) ? V.True : V.False)))) {
V pp_1043 = default;
pp_1043 = Call(pullOf_108, V.Undef, NewObj(2).Put("x", ((V)((ToNum(Get(aim_102, "x")) - ToNum(Get(aim_102, "x0")))))).Put("y", ((V)((ToNum(Get(aim_102, "y")) - ToNum(Get(aim_102, "y0")))))).V);
Set(aim_102, "p", pp_1043);
if (Truthy(pp_1043)) {
Set(aim_102, "S", Call(sim_88, V.Undef, Get(pp_1043, "k"), Get(pp_1043, "a"), Add(t_1038, ((V)(THROW_56)))));
Call(drawPath_109, V.Undef, Get(aim_102, "S"));
} else {
Set(aim_102, "S", V.Null);
Set(pathG_79, "innerHTML", ((V)("")));
Set(bandG_81, "innerHTML", ((V)("")));
Call(S_16, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_19, V.Undef, Get(aim_102, "x0"))).Put("cy", Call(r2_19, V.Undef, Get(aim_102, "y0"))).Put("r", ((V)(6D))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.6))).V, bandG_81);
}
}
if (Truthy((thr_103 is var _t1044 && !Truthy(_t1044) ? _t1044 : (Ge(t_1038, Get(thr_103, "tL")) ? V.True : V.False)))) {
Call(launch_111, V.Undef);
}
if (Truthy(held_94)) {
if (Truthy(thr_103)) {
V u_1045 = default;
V e_1046 = default;
u_1045 = Call(cl_17, V.Undef, ((V)(((ToNum(t_1038) - ToNum(Get(thr_103, "t0"))) / Max(1D, (ToNum(Get(thr_103, "tL")) - ToNum(Get(thr_103, "t0"))))))), ((V)(0D)), ((V)(1D)));
e_1046 = Call(ei_62, V.Undef, u_1045);
Set(held_94, "x", Call(lerp_18, V.Undef, GetIdx(Get(thr_103, "from"), 0D), GetIdx(REL_55, 0D), e_1046));
Set(held_94, "y", Call(lerp_18, V.Undef, GetIdx(Get(thr_103, "from"), 1D), GetIdx(REL_55, 1D), e_1046));
Set(held_94, "z", Call(lerp_18, V.Undef, GetIdx(Get(thr_103, "from"), 2D), GetIdx(REL_55, 2D), e_1046));
} else {
V kk_1047 = default;
V pw_1048 = default;
kk_1047 = (Get(held_94, "kk") is var _t1049 && Truthy(_t1049) ? _t1049 : ((V)(0D)));
pw_1048 = Call(pawsAt_116, V.Undef);
if (Truthy(pw_1048)) {
Set(held_94, "x", GetIdx(pw_1048, 0D));
Set(held_94, "y", GetIdx(pw_1048, 1D));
Set(held_94, "z", GetIdx(pw_1048, 2D));
} else {
Set(held_94, "x", GetIdx(HOLD_54, 0D));
Set(held_94, "y", ((V)(((ToNum(GetIdx(HOLD_54, 1D)) - (0.22 * ToNum(kk_1047))) + ((FdLibm.Sin((ToNum(t_1038) / 400D)) * 0.012) * (1D - ToNum(kk_1047)))))));
Set(held_94, "z", ((V)((ToNum(GetIdx(HOLD_54, 2D)) - (0.05 * ToNum(kk_1047))))));
}
Set(held_94, "fire", ((V)(((fire_97 > 0D) ? 1D : 0D))));
}
}
{
foreach (V _k1050 in new JsIter(balls_93)) {
V b_1051 = default;
b_1051 = _k1050;
double tt_1052 = 0;
V p_1053 = default;
V behind_1054 = default;
V lay_1055 = default;
tt_1052 = ((ToNum(t_1038) - ToNum(Get(b_1051, "tl"))) / 1000D);
p_1053 = Call(posAt_89, V.Undef, Get(b_1051, "S"), ((V)(tt_1052)));
Set(b_1051, "x", GetIdx(p_1053, 0D));
Set(b_1051, "y", GetIdx(p_1053, 1D));
Set(b_1051, "z", GetIdx(p_1053, 2D));
Set(b_1051, "spin", ((V)((tt_1052 * 9D))));
while ((Lt(Get(b_1051, "fired"), Get(Get(Get(b_1051, "S"), "ev"), "length")) && LeN(GetIdx(GetK(Get(Get(b_1051, "S"), "ev"), Get(b_1051, "fired")), 0D), tt_1052))) {
V e_1056 = default;
e_1056 = GetIdx(GetIdx(Get(Get(b_1051, "S"), "ev"), IncM(b_1051, "fired", 1D, false)), 1D);
if (SEqS(e_1056, "rim")) {
if (((ToNum(t_1038) - ToNum(clangAt_105)) > 120D)) {
Invoke(SFX_20, "clang");
clangAt_105 = t_1038;
}
} else {
if ((SEqS(e_1056, "board") || SEqS(e_1056, "ground"))) {
Invoke(SFX_20, "thud");
} else {
if (SEqS(e_1056, "basket")) {
Call(basket_112, V.Undef, b_1051);
}
}
}
}
if (((!(Truthy(Get(Get(b_1051, "S"), "scored"))) && !(Truthy(Get(b_1051, "missed")))) && ((tt_1052 >= 2.2) || (GeN(Get(Get(b_1051, "S"), "tGround"), 0D) && Ge(((V)(tt_1052)), Get(Get(b_1051, "S"), "tGround")))))) {
Set(b_1051, "missed", ((V)(1D)));
Call(missed_113, V.Undef);
}
behind_1054 = ((GtN(Get(b_1051, "z"), (RZ_46 - 0.3)) && LtN(Get(b_1051, "y"), (RY_45 + 0.9))) ? V.True : V.False);
lay_1055 = (Truthy(behind_1054) ? slotB_77 : slotH_80);
if (!SEq(Get(Get(b_1051, "g"), "parentNode"), lay_1055)) {
Invoke(lay_1055, "appendChild", Get(b_1051, "g"));
}
if (Truthy(((Get(b_1051, "fire") is var _t1057 && !Truthy(_t1057) ? _t1057 : (LtN(Invoke(G("Math"), "random"), 0.5) ? V.True : V.False)) is var _t1058 && !Truthy(_t1058) ? _t1058 : ((tt_1052 < 1.2) ? V.True : V.False)))) {
V s_1059 = default;
s_1059 = Call(P_40, V.Undef, Get(b_1051, "x"), Get(b_1051, "y"), Get(b_1051, "z"));
Invoke(ctx_35, "burst", GetIdx(s_1059, 0D), GetIdx(s_1059, 1D), ((V)("spark")), ((V)(1D)), NewObj(4).Put("v", ((V)(30D))).Put("life", ((V)(0.4))).Put("g", ((V)((-40D)))).Put("col", ((V)("#ffb03a"))).V);
}
}
}
balls_93 = Invoke(balls_93, "filter", Fn((V _self1030, int _argc1060, V b_1066, V _a1063, V _a1064, V _a1065, V[] _rest1061) => {
if ((((ToNum(t_1038) - ToNum(Get(b_1066, "tl"))) / 1000D) > LIFE_59)) {
Invoke(Get(b_1066, "g"), "remove");
Invoke(Get(b_1066, "sh"), "remove");
return (false ? V.True : V.False);
}
return (true ? V.True : V.False);
return default;
}, 1, "", true));
Call(poseMe_115, V.Undef, t_1038);
Call(drawHoop_86, V.Undef, t_1038);
{
foreach (V _k1067 in new JsIter(new ArrBuilder().Add(held_94).Spread(balls_93).V)) {
V b_1068 = default;
b_1068 = _k1067;
if (Truthy(b_1068)) {
Call(drawBall_107, V.Undef, b_1068, t_1038);
}
}
}
return default;
}, 2, "update", false)).V;
Call(drawHoop_86, V.Undef, ((V)(0D)));
held_94 = Call(mkBall_106, V.Undef);
return api_117;
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
