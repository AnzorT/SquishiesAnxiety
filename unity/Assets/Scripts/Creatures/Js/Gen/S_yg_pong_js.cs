// yg-pong.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_yg_pong_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V go_8 = default;
if (_self1.IsNullish) _self1 = GlobalV;
go_8 = Fn((V _self1, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_15 = default;
V S_16 = default;
V D_17 = default;
V cl_18 = default;
V lerp_19 = default;
V r2_20 = default;
V track_21 = default;
V SFX_22 = default;
V ICON_23 = default;
YG_15 = Get(G("window"), "YardGames");
if (((!(Truthy(YG_15)) || !(Truthy(Get(YG_15, "add")))) || !(Truthy(Get(YG_15, "cam"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t24 = YG_15;
if (_t24.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t24));
{ V _t25 = Get(_t24, "S");
S_16 = _t25; }
{ V _t26 = Get(_t24, "D");
D_17 = _t26; }
{ V _t27 = Get(_t24, "cl");
cl_18 = _t27; }
{ V _t28 = Get(_t24, "lerp");
lerp_19 = _t28; }
{ V _t29 = Get(_t24, "r2");
r2_20 = _t29; }
{ V _t30 = Get(_t24, "track");
track_21 = _t30; }
{ V _t31 = Get(_t24, "SFX");
SFX_22 = _t31; } }
ICON_23 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#9fdc6e\"/><path d=\"M22 70L38 22H82L98 70Z\" fill=\"#2f6fc0\"/><path d=\"M22 70H98V75H22Z\" fill=\"#245a9e\"/>", "<path d=\"M60 22V70M24 64L96 64M37 25H83\" stroke=\"#fff\" stroke-width=\"1.6\" opacity=\"0.9\"/><path d=\"M29 47H91\" stroke=\"#e9eef5\" stroke-width=\"5\"/><path d=\"M29 44H91\" stroke=\"#3a3a44\" stroke-width=\"1\"/>", "<circle cx=\"40\" cy=\"62\" r=\"7\" fill=\"#e8483c\"/><rect x=\"38.5\" y=\"67\" width=\"3\" height=\"7\" rx=\"1.5\" fill=\"#8a5a34\"/><circle cx=\"80\" cy=\"28\" r=\"4.6\" fill=\"#3a3a44\"/><circle cx=\"66\" cy=\"38\" r=\"2.4\" fill=\"#fff\"/></svg>")));
Invoke(YG_15, "add", NewObj(11).Put("id", ((V)("pong"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Ping-Pong"))).Put("item", ((V)("Ping-Pong Table"))).Put("color", ((V)("#2f9e6f"))).Put("icon", ICON_23).Put("stars", Arr(((V)(100D)), ((V)(160D)), ((V)(220D)))).Put("coinK", ((V)(0.25))).Put("hint", ((V)("Slide left and right to move \u00b7 first to 7"))).Put("how", Arr(((V)("Slide your finger left and right: your creature runs to the ball and swings by itself.")), ((V)("Hit it on the paddle's edge (or while running) to angle your shot.")), ((V)("First to 7 wins. Long rallies score extra!")))).Put("make", Fn((V _self32, int _argc33, V ctx_39, V _a36, V _a37, V _a38, V[] _rest34) => {
V bg_40 = default;
V fg_41 = default;
V W_42 = default;
V H_43 = default;
V P_44 = default;
double G_45 = 0;
double TW_46 = 0;
double Z0_47 = 0;
double Z1_48 = 0;
double ZN_49 = 0;
double TY_50 = 0;
double NH_51 = 0;
double BR_52 = 0;
double ZP_53 = 0;
double ZO_54 = 0;
double GZ_55 = 0;
V SM_56 = default;
V eo_57 = default;
V stage_58 = default;
double PAN0_59 = 0;
double PANK_60 = 0;
V KP_61 = default;
double PXM_62 = 0;
V fingerToPx_63 = default;
V svgL_64 = default;
V scene_65 = default;
V oppL_66 = default;
V tbl_67 = default;
V quad_68 = default;
V line_69 = default;
V drawScene_70 = default;
V ballFarSh_71 = default;
V ballFar_72 = default;
V netG_73 = default;
V ballNear_74 = default;
V ballBack_75 = default;
V ballSh_76 = default;
V ball_77 = default;
V trail_78 = default;
V PADDLE_79 = default;
V ok_80 = default;
V okName_81 = default;
V opp_82 = default;
V me_83 = default;
double MESZ_84 = 0;
double OPSZ_85 = 0;
V ME_86 = default;
V OP_87 = default;
V learn_88 = default;
V scoreTx_89 = default;
double px_90 = 0;
V pxT_91 = default;
double pv_92 = 0;
V ox_93 = default;
V oxT_94 = default;
double ov_95 = 0;
V b_96 = default;
V pts_97 = default;
double rally_98 = 0;
double best_99 = 0;
V serve_100 = default;
double serveN_101 = 0;
JsStrBuf phase_102 = null;
V ph0_103 = default;
V tNow_104 = default;
V swingP_105 = default;
V swingO_106 = default;
V lastHit_107 = default;
V skill_108 = default;
V trailPts_109 = default;
V dustAt_110 = default;
double pvPrev_111 = 0;
V say_112 = default;
V newBall_113 = default;
V send_114 = default;
V hitByMe_115 = default;
V hitByOpp_116 = default;
V point_117 = default;
V swingPose_118 = default;
V poseCreature_119 = default;
V api_120 = default;
if (_self32.IsNullish) _self32 = GlobalV;
drawScene_70 = Fn((V _self121, int _argc122, V sv_128, V _a125, V _a126, V _a127, V[] _rest123) => {
V k0_129 = default;
V gp_130 = default;
double FT_131 = 0;
V far_132 = default;
V tree_133 = default;
if (_self121.IsNullish) _self121 = GlobalV;
k0_129 = GetIdx(Call(P_44, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(GZ_55))), 2D);
gp_130 = Fn((V _self121, int _argc134, V x_140, V z_141, V _a138, V _a139, V[] _rest135) => {
return Call(P_44, V.Undef, x_140, ((V)(0D)), z_141);
}, 2, "", true);
Set(Call(S_16, V.Undef, ((V)("defs")), NewObj(0).V, sv_128), "innerHTML", ((V)(JsStrBuf.Begin().S("<linearGradient id=\"ppSky\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#62b4f0\"/><stop offset=\"0.7\" stop-color=\"#aedcfa\"/><stop offset=\"1\" stop-color=\"#e2f4ff\"/></linearGradient>").S("<radialGradient id=\"ppSunG\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fffbe6\" stop-opacity=\"0.95\"/><stop offset=\"0.35\" stop-color=\"#fff2b8\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#ffe9a0\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"ppLawn\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#8fcf62\"/><stop offset=\"1\" stop-color=\"#4f9a3c\"/></linearGradient>").S("<linearGradient id=\"ppFence\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#c98f58\"/><stop offset=\"1\" stop-color=\"#a8703e\"/></linearGradient>").S("<linearGradient id=\"ppStone\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#d8d0c2\"/><stop offset=\"1\" stop-color=\"#bdb3a2\"/></linearGradient>").S("<radialGradient id=\"ppSun\" cx=\"88%\" cy=\"6%\" r=\"90%\"><stop offset=\"0\" stop-color=\"#fff4c8\" stop-opacity=\"0.4\"/><stop offset=\"1\" stop-color=\"#fff4c8\" stop-opacity=\"0\"/></radialGradient>").S("<filter id=\"ppGrain\" x=\"0\" y=\"0\" width=\"100%\" height=\"100%\"><feTurbulence type=\"fractalNoise\" baseFrequency=\"0.7\" numOctaves=\"3\" seed=\"8\"/><feColorMatrix values=\"0 0 0 0 0.3  0 0 0 0 0.28  0 0 0 0 0.25  0 0 0 0.5 -0.12\"/><feComposite in2=\"SourceGraphic\" operator=\"in\"/></filter>").End())));
Call(S_16, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-160D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_42, ((V)(320D)))).Put("height", ((V)(380D))).Put("fill", ((V)("url(#ppSky)"))).V, sv_128);
FT_131 = (ToNum(GetIdx(Call(P_44, V.Undef, ((V)(0D)), ((V)(1.45)), ((V)(GZ_55))), 1D)) - 142D);
far_132 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(0 ").V(Call(r2_20, V.Undef, ((V)(FT_131)))).S(")").End()))).V, sv_128);
Invoke(Arr(Arr(((V)(40D)), ((V)(96D)), ((V)(0.7))), Arr(((V)(210D)), ((V)(70D)), ((V)(0.55))), Arr(((V)(430D)), ((V)(104D)), ((V)(0.6))), Arr(((V)((-90D))), ((V)(70D)), ((V)(0.5))), Arr(((V)(620D)), ((V)(80D)), ((V)(0.6))), Arr(((V)(760D)), ((V)(60D)), ((V)(0.5)))), "forEach", Fn((V _self121, int _argc142, V _a144, V _a145, V _a146, V _a147, V[] _rest143) => {
V g_155 = default;
V x_150 = default;
V y_152 = default;
V k_154 = default;
{ V _t148 = ListOf(_a144);
{ V _t149 = GetIdx(_t148, 0D);
x_150 = _t149; }
{ V _t151 = GetIdx(_t148, 1D);
y_152 = _t151; }
{ V _t153 = GetIdx(_t148, 2D);
k_154 = _t153; }
}
g_155 = Call(S_16, V.Undef, ((V)("g")), NewObj(2).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(x_150).S(" ").V(y_152).S(") scale(").V(k_154).S(")").End()))).Put("opacity", ((V)(0.92))).V, sv_128);
Invoke(Arr(Arr(((V)((-28D))), ((V)(6D)), ((V)(17D))), Arr(((V)((-6D))), ((V)((-6D))), ((V)(24D))), Arr(((V)(20D)), ((V)(0D)), ((V)(20D))), Arr(((V)(38D)), ((V)(8D)), ((V)(13D))), Arr(((V)(4D)), ((V)(10D)), ((V)(18D))), Arr(((V)((-18D))), ((V)(12D)), ((V)(14D)))), "forEach", Fn((V _self121, int _argc156, V _a158, V _a159, V _a160, V _a161, V[] _rest157) => {
V a_164 = default;
V b2_166 = default;
V r_168 = default;
{ V _t162 = ListOf(_a158);
{ V _t163 = GetIdx(_t162, 0D);
a_164 = _t163; }
{ V _t165 = GetIdx(_t162, 1D);
b2_166 = _t165; }
{ V _t167 = GetIdx(_t162, 2D);
r_168 = _t167; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", a_164).Put("cy", b2_166).Put("r", r_168).Put("fill", ((V)("#ffffff"))).V, g_155);
}, 1, "", true));
return default;
}, 1, "", true));
{
JsStrBuf d_169 = null;
d_169 = new JsStrBuf("M-160 150");
{
double x_170 = 0;
x_170 = (-160D);
while (true) {
if (!(Le(((V)(x_170)), Add(W_42, ((V)(160D)))))) break;
d_169.S("Q").N((x_170 + 7D)).S(" ").N((122D - (((x_170 * 37D) + 999D) % 21D))).S(" ").N((x_170 + 14D)).S(" ").N((134D - (((x_170 * 53D) + 999D) % 11D)));
x_170 = (x_170 + 14D);
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(string.Concat(d_169.Str, "V190H-160Z")))).Put("fill", ((V)("#8fbf9a"))).Put("opacity", ((V)(0.8))).V, far_132);
}
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)("M-40 128L-6 104L28 128V170H-40Z"))).Put("fill", ((V)("#c9a596"))).Put("opacity", ((V)(0.8))).V, far_132);
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)("M370 124L404 100L438 124V170H370Z"))).Put("fill", ((V)("#c9a596"))).Put("opacity", ((V)(0.8))).V, far_132);
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)("M600 126L640 98L680 126V170H600Z"))).Put("fill", ((V)("#c9a596"))).Put("opacity", ((V)(0.8))).V, far_132);
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)("M760 128L792 106L824 128V170H760Z"))).Put("fill", ((V)("#c9a596"))).Put("opacity", ((V)(0.75))).V, far_132);
tree_133 = Fn((V _self121, int _argc172, V x_178, V z_179, V h_180, V r_181, V[] _rest173) => {
V a_184 = default;
V k_185 = default;
V c1_182 = default;
V c2_183 = default;
c1_182 = (_argc172 > 4 ? _rest173[0] : V.Undef);
c2_183 = (_argc172 > 5 ? _rest173[1] : V.Undef);
a_184 = Call(gp_130, V.Undef, x_178, z_179);
k_185 = GetIdx(a_184, 2D);
Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_184, 0D)) - (0.12 * ToNum(k_185))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_184, 1D))).S("L").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_184, 0D)) - (0.07 * ToNum(k_185))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_184, 1D)) - (ToNum(h_180) * ToNum(k_185))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(a_184, 0D), ((V)((0.07 * ToNum(k_185))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_184, 1D)) - (ToNum(h_180) * ToNum(k_185))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(a_184, 0D), ((V)((0.12 * ToNum(k_185))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_184, 1D))).S("Z").End()))).Put("fill", ((V)("#7a5034"))).V, sv_128);
Invoke(Arr(Arr(((V)((-0.7))), ((V)(((-ToNum(h_180)) - 0.1))), ((V)((ToNum(r_181) * 0.8))), c1_182), Arr(((V)(0.65)), ((V)((-ToNum(h_180)))), ((V)((ToNum(r_181) * 0.85))), c1_182), Arr(((V)(0D)), ((V)(((-ToNum(h_180)) - 0.7))), r_181, c2_183), Arr(((V)((-0.35))), ((V)(((-ToNum(h_180)) - 1.1))), ((V)((ToNum(r_181) * 0.7))), c2_183), Arr(((V)(0.4)), ((V)(((-ToNum(h_180)) - 1D))), ((V)((ToNum(r_181) * 0.66))), c2_183), Arr(((V)(0.05)), ((V)(((-ToNum(h_180)) - 0.3))), ((V)((ToNum(r_181) * 0.8))), c2_183)), "forEach", Fn((V _self121, int _argc186, V _a188, V _a189, V _a190, V _a191, V[] _rest187) => {
V dx_194 = default;
V dy_196 = default;
V rr_198 = default;
V c_200 = default;
{ V _t192 = ListOf(_a188);
{ V _t193 = GetIdx(_t192, 0D);
dx_194 = _t193; }
{ V _t195 = GetIdx(_t192, 1D);
dy_196 = _t195; }
{ V _t197 = GetIdx(_t192, 2D);
rr_198 = _t197; }
{ V _t199 = GetIdx(_t192, 3D);
c_200 = _t199; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(a_184, 0D), ((V)((ToNum(dx_194) * ToNum(k_185))))))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(a_184, 1D), ((V)((ToNum(dy_196) * ToNum(k_185))))))).Put("r", Call(r2_20, V.Undef, ((V)((ToNum(rr_198) * ToNum(k_185)))))).Put("fill", c_200).V, sv_128);
}, 1, "", true));
return default;
}, 6, "", true);
Call(tree_133, V.Undef, ((V)((-2.6))), ((V)((GZ_55 + 1.2))), ((V)(2.2)), ((V)(1D)), ((V)("#4c9140")), ((V)("#5aa84a")));
Call(tree_133, V.Undef, ((V)(0.6)), ((V)((GZ_55 + 1.6))), ((V)(2.6)), ((V)(1.1)), ((V)("#4f9a3e")), ((V)("#62ad52")));
Call(tree_133, V.Undef, ((V)(3.4)), ((V)((GZ_55 + 1D))), ((V)(2D)), ((V)(0.95)), ((V)("#4c9140")), ((V)("#5aa84a")));
Call(tree_133, V.Undef, ((V)((-4.8))), ((V)((GZ_55 + 1.4))), ((V)(2.4)), ((V)(1D)), ((V)("#4f9a3e")), ((V)("#62ad52")));
Call(tree_133, V.Undef, ((V)(5.6)), ((V)((GZ_55 + 1.4))), ((V)(2.3)), ((V)(1D)), ((V)("#4f9a3e")), ((V)("#62ad52")));
Call(tree_133, V.Undef, ((V)((-7.6))), ((V)((GZ_55 + 1.1))), ((V)(2.1)), ((V)(1D)), ((V)("#4c9140")), ((V)("#5aa84a")));
Call(tree_133, V.Undef, ((V)(8.2)), ((V)((GZ_55 + 1.2))), ((V)(2.4)), ((V)(1.05)), ((V)("#4c9140")), ((V)("#5aa84a")));
Call(quad_68, V.Undef, Arr(Arr(((V)((-12D))), ((V)(0D)), ((V)((-1D)))), Arr(((V)(12D)), ((V)(0D)), ((V)((-1D)))), Arr(((V)(12D)), ((V)(0D)), ((V)(GZ_55))), Arr(((V)((-12D))), ((V)(0D)), ((V)(GZ_55)))), NewObj(1).Put("fill", ((V)("url(#ppLawn)"))).V, sv_128);
{
double i_201 = 0;
i_201 = (-12D);
while (true) {
if (!((i_201 <= 12D))) break;
double x0_203 = 0;
x0_203 = (i_201 * 0.8);
Call(quad_68, V.Undef, Arr(Arr(((V)(x0_203)), ((V)(0D)), ((V)((-0.8)))), Arr(((V)((x0_203 + 0.4))), ((V)(0D)), ((V)((-0.8)))), Arr(((V)((x0_203 + 0.4))), ((V)(0D)), ((V)(GZ_55))), Arr(((V)(x0_203)), ((V)(0D)), ((V)(GZ_55)))), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.06))).V, sv_128);
i_201++;
}
}
Call(quad_68, V.Undef, Arr(Arr(((V)((-10D))), ((V)(0D)), ((V)(GZ_55))), Arr(((V)(10D)), ((V)(0D)), ((V)(GZ_55))), Arr(((V)(10D)), ((V)(1.45)), ((V)(GZ_55))), Arr(((V)((-10D))), ((V)(1.45)), ((V)(GZ_55)))), NewObj(1).Put("fill", ((V)("url(#ppFence)"))).V, sv_128);
{
V g_204 = default;
g_204 = Call(S_16, V.Undef, ((V)("g")), NewObj(3).Put("stroke", ((V)("#8a5a30"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.7))).V, sv_128);
{
double x_205 = 0;
x_205 = (-10D);
while (true) {
if (!((x_205 <= 10D))) break;
Call(line_69, V.Undef, Arr(Arr(((V)(x_205)), ((V)(0D)), ((V)(GZ_55))), Arr(((V)(x_205)), ((V)(1.45)), ((V)(GZ_55)))), NewObj(0).V, g_204);
x_205 = (x_205 + 0.16);
}
}
}
Invoke(Arr(((V)(0.25)), ((V)(1.2))), "forEach", Fn((V _self121, int _argc207, V y_213, V _a210, V _a211, V _a212, V[] _rest208) => {
return Call(quad_68, V.Undef, Arr(Arr(((V)((-10D))), y_213, ((V)((GZ_55 - 0.02)))), Arr(((V)(10D)), y_213, ((V)((GZ_55 - 0.02)))), Arr(((V)(10D)), Add(y_213, ((V)(0.09))), ((V)((GZ_55 - 0.02)))), Arr(((V)((-10D))), Add(y_213, ((V)(0.09))), ((V)((GZ_55 - 0.02))))), NewObj(1).Put("fill", ((V)("#9a6436"))).V, sv_128);
}, 1, "", true));
{
double x_214 = 0;
x_214 = (-9.8);
while (true) {
if (!((x_214 <= 10D))) break;
Call(quad_68, V.Undef, Arr(Arr(((V)((x_214 - 0.05))), ((V)(0D)), ((V)((GZ_55 - 0.03)))), Arr(((V)((x_214 + 0.05))), ((V)(0D)), ((V)((GZ_55 - 0.03)))), Arr(((V)((x_214 + 0.05))), ((V)(1.52)), ((V)((GZ_55 - 0.03)))), Arr(((V)((x_214 - 0.05))), ((V)(1.52)), ((V)((GZ_55 - 0.03))))), NewObj(1).Put("fill", ((V)("#8a5a30"))).V, sv_128);
x_214 = (x_214 + 1.8);
}
}
Call(quad_68, V.Undef, Arr(Arr(((V)((-10D))), ((V)(0D)), ((V)((GZ_55 - 0.02)))), Arr(((V)(10D)), ((V)(0D)), ((V)((GZ_55 - 0.02)))), Arr(((V)(10D)), ((V)(0D)), ((V)((GZ_55 - 0.5)))), Arr(((V)((-10D))), ((V)(0D)), ((V)((GZ_55 - 0.5))))), NewObj(1).Put("fill", ((V)("#7a5a3a"))).V, sv_128);
{
double sd_216 = 0;
V rnd_217 = default;
sd_216 = 5D;
rnd_217 = Fn((V _self121, int _argc218, V _a220, V _a221, V _a222, V _a223, V[] _rest219) => {
return ((V)(((sd_216 = (((sd_216 * 9301D) + 49297D) % 233280D)) / 233280D)));
}, 0, "", true);
{
double i_224 = 0;
i_224 = 0D;
while (true) {
if (!((i_224 < 110D))) break;
double x_226 = 0;
double z_227 = 0;
V a_228 = default;
V k_229 = default;
double h_230 = 0;
x_226 = ((-9.6) + (ToNum(Call(rnd_217, V.Undef)) * 19.2));
z_227 = ((GZ_55 - 0.08) - (ToNum(Call(rnd_217, V.Undef)) * 0.36));
a_228 = Call(gp_130, V.Undef, ((V)(x_226)), ((V)(z_227)));
k_229 = GetIdx(a_228, 2D);
h_230 = ((0.18 + (ToNum(Call(rnd_217, V.Undef)) * 0.22)) * ToNum(k_229));
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(a_228, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_228, 1D))).S("q").V(Call(r2_20, V.Undef, ((V)(((-0.03) * ToNum(k_229)))))).S(" ").V(Call(r2_20, V.Undef, ((V)(((-h_230) * 0.6))))).S(" ").V(Call(r2_20, V.Undef, ((V)((0.01 * ToNum(k_229)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((-h_230))))).End()))).Put("stroke", ((V)("#3f8a34"))).Put("stroke-width", ((V)(1.2))).Put("fill", ((V)("none"))).V, sv_128);
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(a_228, 0D), ((V)((0.01 * ToNum(k_229))))))).Put("cy", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_228, 1D)) - h_230))))).Put("r", Call(r2_20, V.Undef, ((V)(((0.05 * ToNum(k_229)) + 0.6))))).Put("fill", GetIdx(Arr(((V)("#ff6f91")), ((V)("#ffd84a")), ((V)("#ffffff")), ((V)("#c9a0ff")), ((V)("#ff9a4a"))), (i_224 % 5D))).V, sv_128);
i_224++;
}
}
}
{
V a_231 = default;
V k_232 = default;
V X_233 = default;
V Y_234 = default;
a_231 = Call(gp_130, V.Undef, ((V)((-3.4))), ((V)((GZ_55 - 0.9))));
k_232 = GetIdx(a_231, 2D);
X_233 = Fn((V _self121, int _argc235, V v_241, V _a238, V _a239, V _a240, V[] _rest236) => {
return Call(r2_20, V.Undef, Add(GetIdx(a_231, 0D), ((V)((ToNum(v_241) * ToNum(k_232))))));
}, 1, "", true);
Y_234 = Fn((V _self121, int _argc242, V v_248, V _a245, V _a246, V _a247, V[] _rest243) => {
return Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_231, 1D)) - (ToNum(v_248) * ToNum(k_232))))));
}, 1, "", true);
Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(X_233, V.Undef, ((V)((-0.8))))).S(" ").V(Call(Y_234, V.Undef, ((V)(0D)))).S("V").V(Call(Y_234, V.Undef, ((V)(1.7)))).S("H").V(Call(X_233, V.Undef, ((V)(0.8)))).S("V").V(Call(Y_234, V.Undef, ((V)(0D)))).S("Z").End()))).Put("fill", ((V)("#b9d0e6"))).V, sv_128);
Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(X_233, V.Undef, ((V)((-0.95))))).S(" ").V(Call(Y_234, V.Undef, ((V)(1.65)))).S("L").V(Call(X_233, V.Undef, ((V)(0D)))).S(" ").V(Call(Y_234, V.Undef, ((V)(2.35)))).S("L").V(Call(X_233, V.Undef, ((V)(0.95)))).S(" ").V(Call(Y_234, V.Undef, ((V)(1.65)))).S("Z").End()))).Put("fill", ((V)("#b8604a"))).V, sv_128);
Call(S_16, V.Undef, ((V)("rect")), NewObj(7).Put("x", Call(X_233, V.Undef, ((V)((-0.32))))).Put("y", Call(Y_234, V.Undef, ((V)(1.35)))).Put("width", Call(r2_20, V.Undef, ((V)((0.64 * ToNum(k_232)))))).Put("height", Call(r2_20, V.Undef, ((V)((1.35 * ToNum(k_232)))))).Put("fill", ((V)("#8faecb"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.2))).V, sv_128);
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(X_233, V.Undef, ((V)(0.22)))).Put("cy", Call(Y_234, V.Undef, ((V)(0.7)))).Put("r", ((V)(1.3))).Put("fill", ((V)("#e6c060"))).V, sv_128);
Call(S_16, V.Undef, ((V)("rect")), NewObj(7).Put("x", Call(X_233, V.Undef, ((V)((-0.68))))).Put("y", Call(Y_234, V.Undef, ((V)(1.35)))).Put("width", Call(r2_20, V.Undef, ((V)((0.26 * ToNum(k_232)))))).Put("height", Call(r2_20, V.Undef, ((V)((0.3 * ToNum(k_232)))))).Put("fill", ((V)("#3f6a88"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1D))).V, sv_128);
}
{
V a_249 = default;
V k_250 = default;
a_249 = Call(gp_130, V.Undef, ((V)((-1.9))), ((V)((GZ_55 - 0.7))));
k_250 = GetIdx(a_249, 2D);
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(a_249, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_249, 1D))).S("V").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_249, 1D)) - (1.7 * ToNum(k_250))))))).End()))).Put("stroke", ((V)("#7a5034"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)((0.06 * ToNum(k_250)))))).V, sv_128);
Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_249, 0D)) - (0.2 * ToNum(k_250))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_249, 1D)) - (1.6 * ToNum(k_250))))))).S("H").V(Call(r2_20, V.Undef, Add(GetIdx(a_249, 0D), ((V)((0.2 * ToNum(k_250))))))).S("V").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_249, 1D)) - (1.95 * ToNum(k_250))))))).S("L").V(Call(r2_20, V.Undef, GetIdx(a_249, 0D))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_249, 1D)) - (2.15 * ToNum(k_250))))))).S("L").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_249, 0D)) - (0.2 * ToNum(k_250))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_249, 1D)) - (1.95 * ToNum(k_250))))))).S("Z").End()))).Put("fill", ((V)("#e8956a"))).V, sv_128);
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, GetIdx(a_249, 0D))).Put("cy", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_249, 1D)) - (1.82 * ToNum(k_250))))))).Put("r", Call(r2_20, V.Undef, ((V)((0.05 * ToNum(k_250)))))).Put("fill", ((V)("#3a2a20"))).V, sv_128);
}
{
V a_251 = default;
V k_252 = default;
a_251 = Call(gp_130, V.Undef, ((V)(2.6)), ((V)((GZ_55 - 1D))));
k_252 = GetIdx(a_251, 2D);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 0D)) - (0.3 * ToNum(k_252))))))).Put("cy", Call(r2_20, V.Undef, GetIdx(a_251, 1D))).Put("rx", Call(r2_20, V.Undef, ((V)((1D * ToNum(k_252)))))).Put("ry", Call(r2_20, V.Undef, ((V)((0.2 * ToNum(k_252)))))).Put("fill", ((V)("#2a4a20"))).Put("opacity", ((V)(0.22))).V, sv_128);
Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 0D)) - (0.14 * ToNum(k_252))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_251, 1D))).S("L").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 0D)) - (0.08 * ToNum(k_252))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 1D)) - (2.2 * ToNum(k_252))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(a_251, 0D), ((V)((0.08 * ToNum(k_252))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 1D)) - (2.2 * ToNum(k_252))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(a_251, 0D), ((V)((0.14 * ToNum(k_252))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_251, 1D))).S("Z").End()))).Put("fill", ((V)("#7a5034"))).V, sv_128);
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(a_251, 0D))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 1D)) - (1.9 * ToNum(k_252))))))).S("L").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 0D)) - (0.9 * ToNum(k_252))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 1D)) - (2D * ToNum(k_252))))))).End()))).Put("stroke", ((V)("#7a5034"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)((0.08 * ToNum(k_252)))))).V, sv_128);
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 0D)) - (0.7 * ToNum(k_252))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 1D)) - (1.98 * ToNum(k_252))))))).S("V").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 1D)) - (0.75 * ToNum(k_252))))))).End()))).Put("stroke", ((V)("#5a5a5a"))).Put("stroke-width", ((V)(1D))).V, sv_128);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(7).Put("cx", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 0D)) - (0.7 * ToNum(k_252))))))).Put("cy", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_251, 1D)) - (0.6 * ToNum(k_252))))))).Put("rx", Call(r2_20, V.Undef, ((V)((0.22 * ToNum(k_252)))))).Put("ry", Call(r2_20, V.Undef, ((V)((0.16 * ToNum(k_252)))))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#2a2a32"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)((0.08 * ToNum(k_252)))))).V, sv_128);
Invoke(Arr(Arr(((V)((-0.6))), ((V)((-2.5))), ((V)(0.8)), ((V)("#4f9a3e"))), Arr(((V)(0.55)), ((V)((-2.4))), ((V)(0.75)), ((V)("#4f9a3e"))), Arr(((V)(0D)), ((V)((-3D))), ((V)(0.9)), ((V)("#5aa84a"))), Arr(((V)((-0.3))), ((V)((-3.5))), ((V)(0.6)), ((V)("#66b456"))), Arr(((V)(0.4)), ((V)((-3.4))), ((V)(0.55)), ((V)("#66b456")))), "forEach", Fn((V _self121, int _argc253, V _a255, V _a256, V _a257, V _a258, V[] _rest254) => {
V dx_261 = default;
V dy_263 = default;
V r_265 = default;
V c_267 = default;
{ V _t259 = ListOf(_a255);
{ V _t260 = GetIdx(_t259, 0D);
dx_261 = _t260; }
{ V _t262 = GetIdx(_t259, 1D);
dy_263 = _t262; }
{ V _t264 = GetIdx(_t259, 2D);
r_265 = _t264; }
{ V _t266 = GetIdx(_t259, 3D);
c_267 = _t266; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(a_251, 0D), ((V)((ToNum(dx_261) * ToNum(k_252))))))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(a_251, 1D), ((V)((ToNum(dy_263) * ToNum(k_252))))))).Put("r", Call(r2_20, V.Undef, ((V)((ToNum(r_265) * ToNum(k_252)))))).Put("fill", c_267).V, sv_128);
}, 1, "", true));
}
{
double sd_268 = 0;
V rnd_269 = default;
sd_268 = 9D;
rnd_269 = Fn((V _self121, int _argc270, V _a272, V _a273, V _a274, V _a275, V[] _rest271) => {
return ((V)(((sd_268 = (((sd_268 * 9301D) + 49297D) % 233280D)) / 233280D)));
}, 0, "", true);
{
double i_276 = 0;
i_276 = 0D;
while (true) {
if (!((i_276 < 150D))) break;
double x_278 = 0;
double z_279 = 0;
V a_280 = default;
double k_281 = 0;
x_278 = ((-6.5) + (ToNum(Call(rnd_269, V.Undef)) * 13D));
z_279 = ((-0.6) + (ToNum(Call(rnd_269, V.Undef)) * (GZ_55 - 1D)));
a_280 = Call(gp_130, V.Undef, ((V)(x_278)), ((V)(z_279)));
k_281 = (ToNum(GetIdx(a_280, 2D)) / 100D);
if ((((System.Math.Abs(x_278) < 1.45) && (z_279 > (-0.05))) && (z_279 < 3.75))) {
goto _cont277;
}
if (NumTruthy((i_276 % 6D))) {
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_280, 0D)) - (3D * k_281)))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_280, 1D))).S("q").V(Call(r2_20, V.Undef, ((V)(k_281)))).S(" ").V(Call(r2_20, V.Undef, ((V)(((-6D) * k_281))))).S(" ").V(Call(r2_20, V.Undef, ((V)((2D * k_281))))).S(" ").V(Call(r2_20, V.Undef, ((V)(((-8D) * k_281))))).S("q").V(Call(r2_20, V.Undef, ((V)((0.5 * k_281))))).S(" ").V(Call(r2_20, V.Undef, ((V)((5D * k_281))))).S(" ").V(Call(r2_20, V.Undef, ((V)((1.6 * k_281))))).S(" ").V(Call(r2_20, V.Undef, ((V)((8D * k_281))))).S("q").V(Call(r2_20, V.Undef, ((V)(k_281)))).S(" ").V(Call(r2_20, V.Undef, ((V)(((-5D) * k_281))))).S(" ").V(Call(r2_20, V.Undef, ((V)((3D * k_281))))).S(" ").V(Call(r2_20, V.Undef, ((V)(((-7D) * k_281))))).S("q").V(Call(r2_20, V.Undef, ((V)(((-0.6) * k_281))))).S(" ").V(Call(r2_20, V.Undef, ((V)((5D * k_281))))).S(" ").V(Call(r2_20, V.Undef, ((V)((0.4 * k_281))))).S(" ").V(Call(r2_20, V.Undef, ((V)((7D * k_281))))).S("Z").End()))).Put("fill", ((V)("#3f8a34"))).Put("opacity", ((V)(0.6))).V, sv_128);
} else {
{
double j_282 = 0;
j_282 = 0D;
while (true) {
if (!((j_282 < 5D))) break;
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(a_280, 0D), ((V)(((FdLibm.Cos((j_282 * 1.2566)) * 2.4) * k_281)))))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(a_280, 1D), ((V)(((FdLibm.Sin((j_282 * 1.2566)) * 1.4) * k_281)))))).Put("r", Call(r2_20, V.Undef, ((V)((1.8 * k_281))))).Put("fill", ((V)("#ffffff"))).V, sv_128);
j_282++;
}
}
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, GetIdx(a_280, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(a_280, 1D))).Put("r", Call(r2_20, V.Undef, ((V)((1.2 * k_281))))).Put("fill", ((V)("#ffc93a"))).V, sv_128);
}
_cont277: ;
i_276++;
}
}
}
Call(quad_68, V.Undef, Arr(Arr(((V)((-1.45))), ((V)(0.001)), ((V)((-0.05)))), Arr(((V)(1.45)), ((V)(0.001)), ((V)((-0.05)))), Arr(((V)(1.45)), ((V)(0.001)), ((V)(3.75))), Arr(((V)((-1.45))), ((V)(0.001)), ((V)(3.75)))), NewObj(1).Put("fill", ((V)("url(#ppStone)"))).V, sv_128);
Call(S_16, V.Undef, ((V)("rect")), NewObj(8).Put("x", ((V)((-160D)))).Put("y", ((V)(150D))).Put("width", Add(W_42, ((V)(320D)))).Put("height", ((V)((ToNum(H_43) - 150D)))).Put("fill", ((V)("#ffffff"))).Put("filter", ((V)("url(#ppGrain)"))).Put("clip-path", ((V)("url(#ppPatioC)"))).Put("opacity", ((V)(0.8))).V, sv_128);
{
V cp_284 = default;
cp_284 = Call(S_16, V.Undef, ((V)("clipPath")), NewObj(1).Put("id", ((V)("ppPatioC"))).V, Invoke(sv_128, "querySelector", ((V)("defs"))));
Call(quad_68, V.Undef, Arr(Arr(((V)((-1.45))), ((V)(0D)), ((V)((-0.05)))), Arr(((V)(1.45)), ((V)(0D)), ((V)((-0.05)))), Arr(((V)(1.45)), ((V)(0D)), ((V)(3.75))), Arr(((V)((-1.45))), ((V)(0D)), ((V)(3.75)))), NewObj(0).V, cp_284);
}
{
V g_285 = default;
g_285 = Call(S_16, V.Undef, ((V)("g")), NewObj(3).Put("stroke", ((V)("#9c917f"))).Put("stroke-width", ((V)(1.1))).Put("opacity", ((V)(0.85))).V, sv_128);
{
double z_286 = 0;
double r_287 = 0;
z_286 = (-0.05);
r_287 = 0D;
while (true) {
if (!((z_286 < 3.75))) break;
Call(line_69, V.Undef, Arr(Arr(((V)((-1.45))), ((V)(0.002)), ((V)(z_286))), Arr(((V)(1.45)), ((V)(0.002)), ((V)(z_286)))), NewObj(0).V, g_285);
{
double x_289 = 0;
x_289 = ((-1.45) + (NumTruthy((r_287 % 2D)) ? 0.3 : 0D));
while (true) {
if (!((x_289 < 1.45))) break;
Call(line_69, V.Undef, Arr(Arr(((V)(x_289)), ((V)(0.002)), ((V)(z_286))), Arr(((V)(x_289)), ((V)(0.002)), ((V)(Min(3.75, (z_286 + 0.42)))))), NewObj(0).V, g_285);
x_289 = (x_289 + 0.6);
}
}
z_286 = (z_286 + 0.42);
r_287++;
}
}
}
Invoke(Arr(Arr(((V)((-1.2))), ((V)(0.5))), Arr(((V)(0.9)), ((V)(2.9))), Arr(((V)((-0.3))), ((V)(3.4))), Arr(((V)(1.25)), ((V)(1.2)))), "forEach", Fn((V _self121, int _argc291, V _a293, V _a294, V _a295, V _a296, V[] _rest292) => {
V a_302 = default;
V k_303 = default;
V x_299 = default;
V z_301 = default;
{ V _t297 = ListOf(_a293);
{ V _t298 = GetIdx(_t297, 0D);
x_299 = _t298; }
{ V _t300 = GetIdx(_t297, 1D);
z_301 = _t300; }
}
a_302 = Call(gp_130, V.Undef, x_299, z_301);
k_303 = GetIdx(a_302, 2D);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_20, V.Undef, GetIdx(a_302, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(a_302, 1D))).Put("rx", Call(r2_20, V.Undef, ((V)((0.12 * ToNum(k_303)))))).Put("ry", Call(r2_20, V.Undef, ((V)((0.03 * ToNum(k_303)))))).Put("fill", ((V)("#6f9a4a"))).Put("opacity", ((V)(0.5))).V, sv_128);
return default;
}, 1, "", true));
Call(quad_68, V.Undef, Arr(Arr(((V)((-1.5))), ((V)(0.003)), ((V)((-0.1)))), Arr(((V)(1.5)), ((V)(0.003)), ((V)((-0.1)))), Arr(((V)(1.5)), ((V)(0.003)), ((V)((-0.02)))), Arr(((V)((-1.5))), ((V)(0.003)), ((V)((-0.02))))), NewObj(1).Put("fill", ((V)("#a89e8c"))).V, sv_128);
Call(quad_68, V.Undef, Arr(Arr(((V)((-1.5))), ((V)(0.003)), ((V)(3.72))), Arr(((V)(1.5)), ((V)(0.003)), ((V)(3.72))), Arr(((V)(1.5)), ((V)(0.003)), ((V)(3.8))), Arr(((V)((-1.5))), ((V)(0.003)), ((V)(3.8)))), NewObj(1).Put("fill", ((V)("#a89e8c"))).V, sv_128);
Call(quad_68, V.Undef, Arr(Arr(((V)(((-TW_46) + 0D))), ((V)(0.004)), ((V)((Z0_47 + 0.35)))), Arr(((V)((TW_46 + 0.25))), ((V)(0.004)), ((V)((Z0_47 + 0.35)))), Arr(((V)((TW_46 + 0.45))), ((V)(0.004)), ((V)((Z1_48 - 0.1)))), Arr(((V)(((-TW_46) + 0.2))), ((V)(0.004)), ((V)((Z1_48 - 0.1))))), NewObj(2).Put("fill", ((V)("#2a2018"))).Put("opacity", ((V)(0.22))).V, sv_128);
Invoke(Arr(Arr(((V)((-1.3))), ((V)(3.55))), Arr(((V)(1.3)), ((V)(3.55)))), "forEach", Fn((V _self121, int _argc304, V _a306, V _a307, V _a308, V _a309, V[] _rest305) => {
V a_315 = default;
V k_316 = default;
V x_312 = default;
V z_314 = default;
{ V _t310 = ListOf(_a306);
{ V _t311 = GetIdx(_t310, 0D);
x_312 = _t311; }
{ V _t313 = GetIdx(_t310, 1D);
z_314 = _t313; }
}
a_315 = Call(gp_130, V.Undef, x_312, z_314);
k_316 = GetIdx(a_315, 2D);
Call(S_16, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_315, 0D)) - (0.17 * ToNum(k_316))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_315, 1D)) - (0.36 * ToNum(k_316))))))).S("H").V(Call(r2_20, V.Undef, Add(GetIdx(a_315, 0D), ((V)((0.17 * ToNum(k_316))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(a_315, 0D), ((V)((0.13 * ToNum(k_316))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_315, 1D))).S("H").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_315, 0D)) - (0.13 * ToNum(k_316))))))).S("Z").End()))).Put("fill", ((V)("#c96a44"))).V, sv_128);
Invoke(Arr(Arr(((V)((-0.12))), ((V)((-0.5))), ((V)(0.14))), Arr(((V)(0.1)), ((V)((-0.54))), ((V)(0.15))), Arr(((V)(0D)), ((V)((-0.66))), ((V)(0.15))), Arr(((V)((-0.04))), ((V)((-0.4))), ((V)(0.12)))), "forEach", Fn((V _self121, int _argc317, V _a319, V i_323, V _a321, V _a322, V[] _rest318) => {
V dx_326 = default;
V dy_328 = default;
V r_330 = default;
{ V _t324 = ListOf(_a319);
{ V _t325 = GetIdx(_t324, 0D);
dx_326 = _t325; }
{ V _t327 = GetIdx(_t324, 1D);
dy_328 = _t327; }
{ V _t329 = GetIdx(_t324, 2D);
r_330 = _t329; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(a_315, 0D), ((V)((ToNum(dx_326) * ToNum(k_316))))))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(a_315, 1D), ((V)((ToNum(dy_328) * ToNum(k_316))))))).Put("r", Call(r2_20, V.Undef, ((V)((ToNum(r_330) * ToNum(k_316)))))).Put("fill", ((V)((NumTruthy((ToNum(i_323) % 2D)) ? "#4f9a3e" : "#5aa84a")))).V, sv_128);
}, 2, "", true));
Invoke(Arr(Arr(((V)((-0.1))), ((V)((-0.58)))), Arr(((V)(0.09)), ((V)((-0.62)))), Arr(((V)(0.02)), ((V)((-0.46))))), "forEach", Fn((V _self121, int _argc331, V _a333, V i_337, V _a335, V _a336, V[] _rest332) => {
V dx_340 = default;
V dy_342 = default;
{ V _t338 = ListOf(_a333);
{ V _t339 = GetIdx(_t338, 0D);
dx_340 = _t339; }
{ V _t341 = GetIdx(_t338, 1D);
dy_342 = _t341; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, Add(GetIdx(a_315, 0D), ((V)((ToNum(dx_340) * ToNum(k_316))))))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(a_315, 1D), ((V)((ToNum(dy_342) * ToNum(k_316))))))).Put("r", Call(r2_20, V.Undef, ((V)(((0.04 * ToNum(k_316)) + 0.4))))).Put("fill", GetK(Arr(((V)("#ff6f91")), ((V)("#ffd84a")), ((V)("#ffffff"))), i_337)).V, sv_128);
}, 2, "", true));
return default;
}, 1, "", true));
{
V a_343 = default;
V k_344 = default;
a_343 = Call(gp_130, V.Undef, ((V)(1.75)), ((V)(2.4)));
k_344 = GetIdx(a_343, 2D);
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_343, 0D)) - (0.13 * ToNum(k_344))))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_343, 1D))).S("V").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_343, 1D)) - (0.22 * ToNum(k_344))))))).S("H").V(Call(r2_20, V.Undef, Add(GetIdx(a_343, 0D), ((V)((0.13 * ToNum(k_344))))))).S("V").V(Call(r2_20, V.Undef, GetIdx(a_343, 1D))).S("Z").End()))).Put("fill", ((V)("#4fa8e8"))).Put("stroke", ((V)("#2f78b8"))).Put("stroke-width", ((V)(0.8))).V, sv_128);
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, Add(GetIdx(a_343, 0D), ((V)((0.13 * ToNum(k_344))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_343, 1D)) - (0.18 * ToNum(k_344))))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(a_343, 0D), ((V)((0.3 * ToNum(k_344))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_343, 1D)) - (0.32 * ToNum(k_344))))))).End()))).Put("stroke", ((V)("#2f78b8"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)((0.03 * ToNum(k_344)))))).V, sv_128);
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_343, 0D)) - (0.08 * ToNum(k_344))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_343, 1D)) - (0.22 * ToNum(k_344))))))).S("Q").V(Call(r2_20, V.Undef, GetIdx(a_343, 0D))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_343, 1D)) - (0.36 * ToNum(k_344))))))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(a_343, 0D), ((V)((0.08 * ToNum(k_344))))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_343, 1D)) - (0.22 * ToNum(k_344))))))).End()))).Put("stroke", ((V)("#2f78b8"))).Put("stroke-width", ((V)(1D))).Put("fill", ((V)("none"))).V, sv_128);
}
Call(S_16, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-160D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_42, ((V)(320D)))).Put("height", Add(H_43, ((V)(40D)))).Put("fill", ((V)("url(#ppSun)"))).V, sv_128);
return default;
}, 1, "drawScene", false);
newBall_113 = Fn((V _self345, int _argc346, V who_352, V _a349, V _a350, V _a351, V[] _rest347) => {
if (_self345.IsNullish) _self345 = GlobalV;
b_96 = NewObj(8).Put("x", (Truthy(who_352) ? ox_93 : ((V)((px_90 + 0.04))))).Put("y", ((V)((TY_50 + 0.3)))).Put("z", ((V)((Truthy(who_352) ? (ZO_54 - 0.02) : (ZP_53 + 0.02))))).Put("vx", ((V)(0D))).Put("vy", ((V)(0D))).Put("vz", ((V)(0D))).Put("bounces", ((V)(0D))).Put("side", ((V)((-1D)))).V;
phase_102.Set("serve");
ph0_103 = tNow_104;
serve_100 = who_352;
if (!(Truthy(who_352))) {
Invoke(ctx_39, "hint", ((V)("Tap to serve \u00b7 slide to move")));
}
return default;
}, 1, "newBall", false);
send_114 = Fn((V _self353, int _argc354, V from_360, V lx_361, V lz_362, V _a359, V[] _rest355) => {
double T_363 = 0;
double tn_364 = 0;
if (_self353.IsNullish) _self353 = GlobalV;
T_363 = (Max(0.34, (0.6 - (rally_98 * 0.012))) * (Truthy(from_360) ? 1.05 : 1D));
Set(b_96, "vx", ((V)(((ToNum(lx_361) - ToNum(Get(b_96, "x"))) / T_363))));
Set(b_96, "vz", ((V)(((ToNum(lz_362) - ToNum(Get(b_96, "z"))) / T_363))));
Set(b_96, "vy", ((V)(((((TY_50 + BR_52) - ToNum(Get(b_96, "y"))) + (((0.5 * G_45) * T_363) * T_363)) / T_363))));
tn_364 = ((ZN_49 - ToNum(Get(b_96, "z"))) / ToNum(Get(b_96, "vz")));
if (((tn_364 > 0D) && (tn_364 < T_363))) {
double yn_365 = 0;
yn_365 = (ToNum(Add(Get(b_96, "y"), ((V)((ToNum(Get(b_96, "vy")) * tn_364))))) - (((0.5 * G_45) * tn_364) * tn_364));
if ((yn_365 < (((TY_50 + NH_51) + BR_52) + 0.03))) {
OpSet(b_96, "vy", 0, ((V)((((((TY_50 + NH_51) + BR_52) + 0.05) - yn_365) / tn_364))));
}
}
Set(b_96, "bounces", ((V)(0D)));
Set(b_96, "side", from_360);
lastHit_107 = from_360;
return default;
}, 3, "send", false);
hitByMe_115 = Fn((V _self366, int _argc367, V _a369, V _a370, V _a371, V _a372, V[] _rest368) => {
double off_373 = 0;
V lx_374 = default;
double lz_375 = 0;
V s_376 = default;
if (_self366.IsNullish) _self366 = GlobalV;
off_373 = ((ToNum(Get(b_96, "x")) - px_90) / 0.11);
lx_374 = Call(cl_18, V.Undef, Add(Add(Add(Get(b_96, "x"), ((V)((off_373 * 0.35)))), ((V)((pv_92 * 0.18)))), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.06)))), ((V)(((-TW_46) + 0.06))), ((V)((TW_46 - 0.06))));
lz_375 = (2.25 + (ToNum(Invoke(G("Math"), "random")) * 0.5));
Call(send_114, V.Undef, ((V)(0D)), lx_374, ((V)(lz_375)));
rally_98++;
if (((ToNum(tNow_104) - ToNum(swingP_105)) > 250D)) {
swingP_105 = tNow_104;
}
Invoke(SFX_22, "pop");
s_376 = Call(P_44, V.Undef, Get(b_96, "x"), Get(b_96, "y"), Get(b_96, "z"));
Invoke(ctx_39, "burst", GetIdx(s_376, 0D), GetIdx(s_376, 1D), ((V)("spark")), ((V)(5D)), NewObj(2).Put("v", ((V)(70D))).Put("life", ((V)(0.35))).V);
if (((rally_98 > 1D) && ((rally_98 % 5D) == 0D))) {
Invoke(ctx_39, "toast", ((V)(JsStrBuf.Begin().S("Rally ").N(rally_98).S("!").End())), ((V)((ToNum(W_42) / 2D))), ((V)((ToNum(H_43) * 0.3))), ((V)("#ffe36e")));
}
return default;
}, 0, "hitByMe", false);
hitByOpp_116 = Fn((V _self377, int _argc378, V _a380, V _a381, V _a382, V _a383, V[] _rest379) => {
double away_384 = 0;
double aim_385 = 0;
if (_self377.IsNullish) _self377 = GlobalV;
away_384 = ((System.Math.Abs(px_90) < 0.25) ? (LtN(Invoke(G("Math"), "random"), 0.5) ? (-1D) : 1D) : (-Sign(px_90)));
aim_385 = (LtN(Invoke(G("Math"), "random"), (ToNum(skill_108) * 0.6)) ? (away_384 * (0.3 + (ToNum(Invoke(G("Math"), "random")) * 0.25))) : ((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.7));
Call(send_114, V.Undef, ((V)(1D)), Call(cl_18, V.Undef, ((V)(aim_385)), ((V)(((-TW_46) + 0.08))), ((V)((TW_46 - 0.08)))), ((V)((0.8 + (ToNum(Invoke(G("Math"), "random")) * 0.55)))));
rally_98++;
if (((ToNum(tNow_104) - ToNum(swingO_106)) > 250D)) {
swingO_106 = tNow_104;
}
Invoke(SFX_22, "tap");
return default;
}, 0, "hitByOpp", false);
point_117 = Fn((V _self386, int _argc387, V win_393, V why_394, V _a391, V _a392, V[] _rest388) => {
if (_self386.IsNullish) _self386 = GlobalV;
if (string.Equals(phase_102.Str, "point")) {
return default;
}
phase_102.Set("point");
ph0_103 = tNow_104;
IncK(pts_97, ((V)((Truthy(win_393) ? 0D : 1D))), 1D, false);
best_99 = Max(best_99, rally_98);
Call(say_112, V.Undef);
if (Truthy(win_393)) {
Invoke(ctx_39, "add", ((V)(10D)), ((V)((ToNum(W_42) / 2D))), ((V)((ToNum(H_43) * 0.42))), (why_394 is var _t395 && Truthy(_t395) ? _t395 : ((V)("Point!"))), ((V)("#ffe36e")));
Invoke(SFX_22, "score");
Invoke(me_83, "play", ((V)("happy")));
Invoke(opp_82, "play", ((V)("surprised")));
} else {
Invoke(ctx_39, "toast", (why_394 is var _t396 && Truthy(_t396) ? _t396 : ((V)(JsStrBuf.Begin().S("Point ").V(okName_81).End()))), ((V)((ToNum(W_42) / 2D))), ((V)((ToNum(H_43) * 0.42))), ((V)("#ffffff")));
Invoke(SFX_22, "miss");
Invoke(opp_82, "play", ((V)("happy")));
}
rally_98 = 0D;
skill_108 = Call(cl_18, V.Undef, ((V)(((0.5 + ((ToNum(GetIdx(pts_97, 0D)) - ToNum(GetIdx(pts_97, 1D))) * 0.06)) + (ToNum(Add(GetIdx(pts_97, 0D), GetIdx(pts_97, 1D))) * 0.015)))), ((V)(0.4)), ((V)(0.85)));
return default;
}, 2, "point", false);
swingPose_118 = Fn((V _self397, int _argc398, V wind_404, V since_405, V q_406, V _a403, V[] _rest399) => {
V R_407 = default;
V Bk_408 = default;
V Ht_409 = default;
V mix_410 = default;
V p_411 = default;
if (_self397.IsNullish) _self397 = GlobalV;
R_407 = NewObj(9).Put("a", ((V)(92D))).Put("hx", ((V)(2D))).Put("hy", ((V)(0D))).Put("hz", ((V)(0D))).Put("lean", ((V)(0.2))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.03))).Put("yaw", ((V)(0D))).Put("rot", ((V)(10D))).V;
Bk_408 = NewObj(9).Put("a", ((V)(80D))).Put("hx", ((V)(7D))).Put("hy", ((V)(2D))).Put("hz", ((V)((-9D)))).Put("lean", ((V)((-0.4)))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("yaw", ((V)(14D))).Put("rot", ((V)(35D))).V;
Ht_409 = NewObj(9).Put("a", ((V)(96D))).Put("hx", ((V)((-2D)))).Put("hy", ((V)((-1D)))).Put("hz", ((V)(11D))).Put("lean", ((V)(0.9))).Put("lift", ((V)(0.6))).Put("sq", ((V)((-0.02)))).Put("yaw", ((V)((-18D)))).Put("rot", ((V)((-5D)))).V;
mix_410 = Fn((V _self397, int _argc412, V A_418, V B2_419, V u_420, V _a417, V[] _rest413) => {
V o_421 = default;
o_421 = NewObj(0).V;
{
foreach (V _k422 in ForInKeys(A_418)) {
V k_423 = default;
k_423 = _k422;
SetK(o_421, k_423, Call(lerp_19, V.Undef, GetK(A_418, k_423), GetK(B2_419, k_423), u_420));
}
}
return o_421;
return default;
}, 3, "", true);
p_411 = Call(mix_410, V.Undef, R_407, Bk_408, Call(SM_56, V.Undef, wind_404));
if ((GeN(since_405, 0D) && LtN(since_405, 560D))) {
if (LtN(since_405, 110D)) {
p_411 = Call(mix_410, V.Undef, p_411, Ht_409, Call(eo_57, V.Undef, ((V)((ToNum(since_405) / 110D)))));
} else {
if (LtN(since_405, 260D)) {
p_411 = Ht_409;
} else {
p_411 = Call(mix_410, V.Undef, Ht_409, R_407, Call(SM_56, V.Undef, ((V)(((ToNum(since_405) - 260D) / 300D)))));
}
}
}
return p_411;
return default;
}, 3, "swingPose", false);
poseCreature_119 = Fn((V _self424, int _argc425, V c_431, V Q_432, V p_433, V run_434, V[] _rest426) => {
V E_439 = default;
V dt_435 = default;
V spin_436 = default;
V yaw0_437 = default;
V extra_438 = default;
if (_self424.IsNullish) _self424 = GlobalV;
dt_435 = (_argc425 > 4 ? _rest426[0] : V.Undef);
spin_436 = (_argc425 > 5 ? _rest426[1] : V.Undef);
yaw0_437 = (_argc425 > 6 ? _rest426[2] : V.Undef);
extra_438 = (_argc425 > 7 ? _rest426[3] : V.Undef);
E_439 = Object_assign(NewObj(3).Put("lean", Get(p_433, "lean")).Put("lift", Get(p_433, "lift")).Put("sq", Get(p_433, "sq")).V, (extra_438 is var _t440 && Truthy(_t440) ? _t440 : NewObj(0).V));
SetK(E_439, Get(Q_432, "arm"), Get(p_433, "a"));
SetK(E_439, ((V)((GtN(Get(Q_432, "side"), 0D) ? "hLx" : "hRx"))), (GtN(Get(Q_432, "side"), 0D) ? Get(p_433, "hx") : ((V)((-ToNum(Get(p_433, "hx")))))));
SetK(E_439, ((V)((GtN(Get(Q_432, "side"), 0D) ? "hLy" : "hRy"))), Get(p_433, "hy"));
SetK(E_439, ((V)((GtN(Get(Q_432, "side"), 0D) ? "hLz" : "hRz"))), Get(p_433, "hz"));
Invoke(c_431, "pose", E_439);
Set(Get(Q_432, "ws"), "run", ((V)((GtN(run_434, 0.55) ? 1D : 0D))));
if (Truthy((Get(G("window"), "HouseWalk") is var _t441 && !Truthy(_t441) ? _t441 : (GtN(run_434, 0.02) ? V.True : V.False)))) {
try {
Invoke(Get(G("window"), "HouseWalk"), "step", Get(c_431, "key"), Get(Q_432, "ws"), Get(c_431, "E"), ((V)(Min(1D, (ToNum(run_434) * 1.3)))), dt_435, ((V)((0.7 + (ToNum(run_434) * 1.6)))), spin_436);
} catch (System.Exception _ex442) {
V e_443 = default;
e_443 = Caught(_ex442);

}
}
Invoke(c_431, "yaw", Add(yaw0_437, ((V)((ToNum(Get(p_433, "yaw")) * ToNum(Get(Q_432, "side")))))));
Set(Q_432, "rot", ((V)(((GtN(Get(Q_432, "side"), 0D) ? (-25D) : 20D) + (ToNum(Get(p_433, "rot")) * ToNum(Get(Q_432, "side")))))));
return default;
}, 8, "poseCreature", false);
{ V _t444 = ctx_39;
if (_t444.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t444));
{ V _t445 = Get(_t444, "bg");
bg_40 = _t445; }
{ V _t446 = Get(_t444, "fg");
fg_41 = _t446; }
{ V _t447 = Get(_t444, "W");
W_42 = _t447; }
{ V _t448 = Get(_t444, "H");
H_43 = _t448; } }
P_44 = Invoke(YG_15, "cam", ((V)(2D)), ((V)(2.32)), ((V)(14D)), ((V)(262D)));
G_45 = 8.2;
TW_46 = 0.6;
Z0_47 = 0.55;
Z1_48 = 2.95;
ZN_49 = 1.75;
TY_50 = 0.76;
NH_51 = 0.13;
BR_52 = 0.022;
ZP_53 = 0.45;
ZO_54 = 3.06;
GZ_55 = 7D;
SM_56 = Get(YG_15, "SM");
eo_57 = Fn((V _self32, int _argc449, V u_455, V _a452, V _a453, V _a454, V[] _rest450) => {
return ((V)((1D - ((1D - ToNum(u_455)) * (1D - ToNum(u_455))))));
}, 1, "", true);
stage_58 = Get(Get(ctx_39, "crl"), "parentNode");
PAN0_59 = 0D;
PANK_60 = 0D;
KP_61 = GetIdx(Call(P_44, V.Undef, ((V)(0D)), ((V)(TY_50)), ((V)(ZP_53))), 2D);
PXM_62 = (TW_46 + 0.04);
fingerToPx_63 = Fn((V _self32, int _argc456, V x_462, V _a459, V _a460, V _a461, V[] _rest457) => {
return Call(cl_18, V.Undef, ((V)((((ToNum(x_462) - (ToNum(W_42) / 2D)) - PAN0_59) / (ToNum(KP_61) - PANK_60)))), ((V)((-PXM_62))), ((V)(PXM_62)));
}, 1, "", true);
svgL_64 = Fn((V _self32, int _argc463, V _a465, V _a466, V _a467, V _a468, V[] _rest464) => {
V e_469 = default;
e_469 = Invoke(G("document"), "createElementNS", ((V)("http://www.w3.org/2000/svg")), ((V)("svg")));
Invoke(e_469, "setAttribute", ((V)("viewBox")), ((V)(JsStrBuf.Begin().S("0 0 ").V(W_42).S(" ").V(H_43).End())));
Invoke(e_469, "setAttribute", ((V)("class")), ((V)("yg-layer")));
Invoke(e_469, "setAttribute", ((V)("preserveAspectRatio")), ((V)("none")));
Set(Get(e_469, "style"), "overflow", ((V)("visible")));
return e_469;
return default;
}, 0, "", true);
scene_65 = Call(svgL_64, V.Undef);
Invoke(stage_58, "insertBefore", scene_65, bg_40);
oppL_66 = Call(D_17, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-layer yg-crl"))).V);
tbl_67 = Call(svgL_64, V.Undef);
Invoke(stage_58, "insertBefore", oppL_66, Get(ctx_39, "crl"));
Invoke(stage_58, "insertBefore", tbl_67, Get(ctx_39, "crl"));
quad_68 = Fn((V _self32, int _argc470, V pts_476, V a_477, V p_478, V _a475, V[] _rest471) => {
return Call(S_16, V.Undef, ((V)("path")), Object_assign(NewObj(1).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_476, "map", Fn((V _self32, int _argc479, V q_485, V _a482, V _a483, V _a484, V[] _rest480) => {
V s_486 = default;
s_486 = Call(P_44, V.Undef, GetIdx(q_485, 0D), GetIdx(q_485, 1D), GetIdx(q_485, 2D));
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_486, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_486, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).V, a_477), p_478);
}, 3, "", true);
line_69 = Fn((V _self32, int _argc487, V pts_493, V a_494, V p_495, V _a492, V[] _rest488) => {
return Call(S_16, V.Undef, ((V)("path")), Object_assign(NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_493, "map", Fn((V _self32, int _argc496, V q_502, V _a499, V _a500, V _a501, V[] _rest497) => {
V s_503 = default;
s_503 = Call(P_44, V.Undef, GetIdx(q_502, 0D), GetIdx(q_502, 1D), GetIdx(q_502, 2D));
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_503, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_503, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()))).Put("fill", ((V)("none"))).V, a_494), p_495);
}, 3, "", true);
Call(drawScene_70, V.Undef, scene_65);
{
V g0_504 = default;
V ln_505 = default;
g0_504 = Call(P_44, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(((Z0_47 + Z1_48) / 2D))));
Invoke(Arr(Arr(((V)(((-TW_46) + 0.08))), ((V)((Z1_48 - 0.15)))), Arr(((V)((TW_46 - 0.08))), ((V)((Z1_48 - 0.15))))), "forEach", Fn((V _self32, int _argc506, V _a508, V _a509, V _a510, V _a511, V[] _rest507) => {
V a_517 = default;
V b2_518 = default;
V w_519 = default;
V x_514 = default;
V z_516 = default;
{ V _t512 = ListOf(_a508);
{ V _t513 = GetIdx(_t512, 0D);
x_514 = _t513; }
{ V _t515 = GetIdx(_t512, 1D);
z_516 = _t515; }
}
a_517 = Call(P_44, V.Undef, x_514, ((V)(0.05)), z_516);
b2_518 = Call(P_44, V.Undef, x_514, ((V)((TY_50 - 0.03))), z_516);
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(a_517, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_517, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(b2_518, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(b2_518, 1D))).End()))).Put("stroke", ((V)("#2a2a34"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)((0.045 * ToNum(GetIdx(a_517, 2D))))))).Put("stroke-linecap", ((V)("round"))).V, tbl_67);
w_519 = Call(P_44, V.Undef, x_514, ((V)(0.03)), z_516);
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, GetIdx(w_519, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(w_519, 1D))).Put("r", Call(r2_20, V.Undef, ((V)((0.04 * ToNum(GetIdx(w_519, 2D))))))).Put("fill", ((V)("#1a1a22"))).V, tbl_67);
return default;
}, 1, "", true));
Call(line_69, V.Undef, Arr(Arr(((V)(((-TW_46) + 0.08))), ((V)(0.3)), ((V)((Z1_48 - 0.15)))), Arr(((V)((TW_46 - 0.08))), ((V)(0.3)), ((V)((Z1_48 - 0.15))))), NewObj(2).Put("stroke", ((V)("#2a2a34"))).Put("stroke-width", ((V)(2D))).V, tbl_67);
Call(quad_68, V.Undef, Arr(Arr(((V)((-TW_46))), ((V)((TY_50 - 0.045))), ((V)(Z0_47))), Arr(((V)(TW_46)), ((V)((TY_50 - 0.045))), ((V)(Z0_47))), Arr(((V)(TW_46)), ((V)(TY_50)), ((V)(Z0_47))), Arr(((V)((-TW_46))), ((V)(TY_50)), ((V)(Z0_47)))), NewObj(1).Put("fill", ((V)("#1d4a86"))).V, tbl_67);
Call(quad_68, V.Undef, Arr(Arr(((V)(TW_46)), ((V)((TY_50 - 0.045))), ((V)(Z0_47))), Arr(((V)(TW_46)), ((V)((TY_50 - 0.045))), ((V)(Z1_48))), Arr(((V)(TW_46)), ((V)(TY_50)), ((V)(Z1_48))), Arr(((V)(TW_46)), ((V)(TY_50)), ((V)(Z0_47)))), NewObj(1).Put("fill", ((V)("#1a4278"))).V, tbl_67);
Call(quad_68, V.Undef, Arr(Arr(((V)((-TW_46))), ((V)(TY_50)), ((V)(Z0_47))), Arr(((V)(TW_46)), ((V)(TY_50)), ((V)(Z0_47))), Arr(((V)(TW_46)), ((V)(TY_50)), ((V)(Z1_48))), Arr(((V)((-TW_46))), ((V)(TY_50)), ((V)(Z1_48)))), NewObj(1).Put("fill", ((V)("#2d6cc0"))).V, tbl_67);
ln_505 = Fn((V _self32, int _argc520, V a_526, V b2_527, V w_528, V _a525, V[] _rest521) => {
V p_529 = default;
V q_530 = default;
p_529 = Call(P_44, V.Undef, GetIdx(a_526, 0D), ((V)((TY_50 + 0.001))), GetIdx(a_526, 1D));
q_530 = Call(P_44, V.Undef, GetIdx(b2_527, 0D), ((V)((TY_50 + 0.001))), GetIdx(b2_527, 1D));
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(p_529, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_529, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(q_530, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(q_530, 1D))).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", w_528).Put("opacity", ((V)(0.92))).V, tbl_67);
return default;
}, 3, "", true);
Call(ln_505, V.Undef, Arr(((V)(((-TW_46) + 0.015))), ((V)(Z0_47))), Arr(((V)(((-TW_46) + 0.015))), ((V)(Z1_48))), ((V)(2.4)));
Call(ln_505, V.Undef, Arr(((V)((TW_46 - 0.015))), ((V)(Z0_47))), Arr(((V)((TW_46 - 0.015))), ((V)(Z1_48))), ((V)(2.4)));
Call(ln_505, V.Undef, Arr(((V)((-TW_46))), ((V)((Z0_47 + 0.01)))), Arr(((V)(TW_46)), ((V)((Z0_47 + 0.01)))), ((V)(2.4)));
Call(ln_505, V.Undef, Arr(((V)((-TW_46))), ((V)((Z1_48 - 0.01)))), Arr(((V)(TW_46)), ((V)((Z1_48 - 0.01)))), ((V)(1.6)));
Call(ln_505, V.Undef, Arr(((V)(0D)), ((V)(Z0_47))), Arr(((V)(0D)), ((V)(Z1_48))), ((V)(1.2)));
Call(quad_68, V.Undef, Arr(Arr(((V)(((-TW_46) + 0.1))), ((V)((TY_50 + 0.001))), ((V)((Z0_47 + 0.15)))), Arr(((V)((-0.05))), ((V)((TY_50 + 0.001))), ((V)((Z0_47 + 0.15)))), Arr(((V)((-0.25))), ((V)((TY_50 + 0.001))), ((V)((Z1_48 - 0.2)))), Arr(((V)(((-TW_46) + 0.1))), ((V)((TY_50 + 0.001))), ((V)((Z1_48 - 0.2))))), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.07))).V, tbl_67);
Call(quad_68, V.Undef, Arr(Arr(((V)(0.15)), ((V)((TY_50 + 0.001))), ((V)((Z0_47 + 0.2)))), Arr(((V)((TW_46 - 0.05))), ((V)((TY_50 + 0.001))), ((V)((Z0_47 + 0.2)))), Arr(((V)((TW_46 - 0.05))), ((V)((TY_50 + 0.001))), ((V)((Z0_47 + 0.6)))), Arr(((V)(0.3)), ((V)((TY_50 + 0.001))), ((V)((Z0_47 + 0.6))))), NewObj(2).Put("fill", ((V)("#fff4d0"))).Put("opacity", ((V)(0.08))).V, tbl_67);
}
ballFarSh_71 = Call(S_16, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#10203a"))).Put("opacity", ((V)(0.3))).V, tbl_67);
ballFar_72 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, tbl_67);
netG_73 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, tbl_67);
ballNear_74 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, tbl_67);
ballBack_75 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, fg_41);
{
V a_531 = default;
V b2_532 = default;
V c_533 = default;
V d_534 = default;
JsStrBuf m_535 = null;
a_531 = Call(P_44, V.Undef, ((V)(((-TW_46) - 0.06))), ((V)(TY_50)), ((V)(ZN_49)));
b2_532 = Call(P_44, V.Undef, ((V)((TW_46 + 0.06))), ((V)(TY_50)), ((V)(ZN_49)));
c_533 = Call(P_44, V.Undef, ((V)((TW_46 + 0.06))), ((V)((TY_50 + NH_51))), ((V)(ZN_49)));
d_534 = Call(P_44, V.Undef, ((V)(((-TW_46) - 0.06))), ((V)((TY_50 + NH_51))), ((V)(ZN_49)));
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Arr(a_531, b2_532, c_533, d_534), "map", Fn((V _self32, int _argc536, V s_542, V _a539, V _a540, V _a541, V[] _rest537) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_542, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_542, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).Put("fill", ((V)("#eef2f8"))).Put("opacity", ((V)(0.5))).V, netG_73);
m_535 = new JsStrBuf("");
{
double i_543 = 0;
i_543 = 0D;
while (true) {
if (!((i_543 <= 30D))) break;
double x_545 = 0;
V p_546 = default;
V q_547 = default;
x_545 = (((-TW_46) - 0.06) + ((((2D * TW_46) + 0.12) * i_543) / 30D));
p_546 = Call(P_44, V.Undef, ((V)(x_545)), ((V)(TY_50)), ((V)(ZN_49)));
q_547 = Call(P_44, V.Undef, ((V)(x_545)), ((V)((TY_50 + NH_51))), ((V)(ZN_49)));
m_535.S("M").V(Call(r2_20, V.Undef, GetIdx(p_546, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_546, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(q_547, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(q_547, 1D)));
i_543++;
}
}
{
double j_548 = 0;
j_548 = 1D;
while (true) {
if (!((j_548 < 4D))) break;
double y_550 = 0;
V p_551 = default;
V q_552 = default;
y_550 = (TY_50 + ((NH_51 * j_548) / 4D));
p_551 = Call(P_44, V.Undef, ((V)(((-TW_46) - 0.06))), ((V)(y_550)), ((V)(ZN_49)));
q_552 = Call(P_44, V.Undef, ((V)((TW_46 + 0.06))), ((V)(y_550)), ((V)(ZN_49)));
m_535.S("M").V(Call(r2_20, V.Undef, GetIdx(p_551, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_551, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(q_552, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(q_552, 1D)));
j_548++;
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(m_535.Str))).Put("stroke", ((V)("#3a3a44"))).Put("stroke-width", ((V)(0.6))).Put("opacity", ((V)(0.6))).V, netG_73);
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(d_534, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(d_534, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(c_533, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(c_533, 1D))).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(3D))).V, netG_73);
Invoke(Arr(a_531, b2_532), "forEach", Fn((V _self32, int _argc553, V s_559, V i_560, V _a557, V _a558, V[] _rest554) => {
V t_561 = default;
t_561 = GetK(Arr(d_534, c_533), i_560);
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(s_559, 0D))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(s_559, 1D), ((V)(3D))))).S("L").V(Call(r2_20, V.Undef, GetIdx(t_561, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(t_561, 1D))).End()))).Put("stroke", ((V)("#3a3a44"))).Put("stroke-width", ((V)(3D))).V, netG_73);
return default;
}, 2, "", true));
}
ballSh_76 = Call(S_16, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#10203a"))).Put("opacity", ((V)(0.3))).V, ballNear_74);
ball_77 = Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("r", ((V)(5D))).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#e6dccb"))).Put("stroke-width", ((V)(0.8))).V);
trail_78 = Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(3D))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.35))).V);
PADDLE_79 = Fn((V _self32, int _argc562, V col_568, V edge_569, V _a566, V _a567, V[] _rest563) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"-0.75\" y=\"0.2\" width=\"1.5\" height=\"4.6\" rx=\"0.6\" fill=\"#c98a52\" stroke=\"#6b4426\" stroke-width=\"0.35\"/><rect x=\"-0.75\" y=\"1.7\" width=\"1.5\" height=\"0.9\" fill=\"#8a5a2c\" opacity=\"0.6\"/>").S("<ellipse cx=\"0\" cy=\"-3.2\" rx=\"3.7\" ry=\"4\" fill=\"").V(col_568).S("\" stroke=\"").V(edge_569).S("\" stroke-width=\"0.5\"/><ellipse cx=\"-1.1\" cy=\"-4.5\" rx=\"1.3\" ry=\"0.8\" fill=\"#ffffff\" opacity=\"0.3\"/>").End()));
}, 2, "", true);
ok_80 = Invoke(ctx_39, "opponent");
okName_81 = Invoke(ctx_39, "nameOf", ok_80);
opp_82 = Invoke(YG_15, "creature", oppL_66, ok_80, NewObj(1).Put("yaw", ((V)(0D))).V);
me_83 = Invoke(ctx_39, "creature", Get(ctx_39, "playerKey"), NewObj(1).Put("yaw", ((V)(150D))).V);
MESZ_84 = 140D;
OPSZ_85 = 82D;
ME_86 = NewObj(9).Put("paw", ((V)("pawL"))).Put("arm", ((V)("armL"))).Put("side", ((V)(1D))).Put("ws", NewObj(0).V).Put("off", Arr(((V)(26D)), ((V)((-36D))))).Put("offN", ((V)(0D))).Put("rot", ((V)((-25D)))).Put("pad", Call(PADDLE_79, V.Undef, ((V)("#e8483c")), ((V)("#7a1c18")))).Put("k", ((V)(2.9))).V;
OP_87 = NewObj(9).Put("paw", ((V)("pawR"))).Put("arm", ((V)("armR"))).Put("side", ((V)((-1D)))).Put("ws", NewObj(0).V).Put("off", Arr(((V)(24D)), ((V)((-38D))))).Put("offN", ((V)(0D))).Put("rot", ((V)(20D))).Put("pad", Call(PADDLE_79, V.Undef, ((V)("#2f6fe0")), ((V)("#14306e")))).Put("k", ((V)(2.3))).V;
Invoke(Arr(Arr(me_83, ME_86), Arr(opp_82, OP_87)), "forEach", Fn((V _self32, int _argc570, V _a572, V _a573, V _a574, V _a575, V[] _rest571) => {
V I_581 = default;
V c_578 = default;
V Q_580 = default;
{ V _t576 = ListOf(_a572);
{ V _t577 = GetIdx(_t576, 0D);
c_578 = _t577; }
{ V _t579 = GetIdx(_t576, 1D);
Q_580 = _t579; }
}
I_581 = Get(c_578, "I");
if (!(Truthy(I_581))) {
return default;
}
Set(I_581, "propArm", Get(Q_580, "arm"));
Set(I_581, "propFn", Fn((V _self32, int _argc582, V I2_588, V _a585, V _a586, V _a587, V[] _rest583) => {
V p_589 = default;
p_589 = (Get(I2_588, "W") is var _t590 && !Truthy(_t590) ? _t590 : GetK(Get(I2_588, "W"), Get(Q_580, "paw")));
return ((V)((Truthy(p_589) ? JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_20, V.Undef, GetIdx(p_589, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_589, 1D))).S(") rotate(").V(Call(r2_20, V.Undef, Get(Q_580, "rot"))).S(") scale(").V(Get(Q_580, "k")).S(")\">").V(Get(Q_580, "pad")).S("</g>").End() : "")));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
learn_88 = Fn((V _self32, int _argc591, V c_597, V Q_598, V _a595, V _a596, V[] _rest592) => {
V p_599 = default;
V o_600 = default;
p_599 = ((Get(c_597, "I") is var _t601 && !Truthy(_t601) ? _t601 : Get(Get(c_597, "I"), "W")) is var _t602 && !Truthy(_t602) ? _t602 : GetK(Get(Get(c_597, "I"), "W"), Get(Q_598, "paw")));
if (!(Truthy(p_599))) {
return default;
}
o_600 = Arr(((V)((ToNum(GetIdx(p_599, 0D)) - 50D))), ((V)((ToNum(GetIdx(p_599, 1D)) - 93D))));
Set(Q_598, "off", (Truthy(Get(Q_598, "offN")) ? Arr(Call(lerp_19, V.Undef, GetIdx(Get(Q_598, "off"), 0D), GetIdx(o_600, 0D), ((V)(0.5))), Call(lerp_19, V.Undef, GetIdx(Get(Q_598, "off"), 1D), GetIdx(o_600, 1D), ((V)(0.5)))) : o_600));
IncM(Q_598, "offN", 1D, false);
return default;
}, 2, "", true);
scoreTx_89 = Call(D_17, V.Undef, ((V)("div")), NewObj(2).Put("cls", ((V)("yg-pill"))).Put("style", ((V)("position:absolute;left:50%;top:12.5%;transform:translateX(-50%);font-size:14px;padding:6px 12px;white-space:nowrap;"))).V, Invoke(stage_58, "querySelector", ((V)(".yg-hud"))));
px_90 = 0D;
pxT_91 = ((V)(0D));
pv_92 = 0D;
ox_93 = ((V)(0D));
oxT_94 = ((V)(0D));
ov_95 = 0D;
b_96 = V.Null;
pts_97 = Arr(((V)(0D)), ((V)(0D)));
rally_98 = 0D;
best_99 = 0D;
serve_100 = ((V)(0D));
serveN_101 = 0D;
phase_102 = new JsStrBuf("serve");
ph0_103 = ((V)(0D));
tNow_104 = ((V)(0D));
swingP_105 = ((V)((-9D)));
swingO_106 = ((V)((-9D)));
lastHit_107 = ((V)(0D));
skill_108 = ((V)(0.55));
trailPts_109 = Arr();
dustAt_110 = ((V)(0D));
pvPrev_111 = 0D;
say_112 = Fn((V _self32, int _argc603, V _a605, V _a606, V _a607, V _a608, V[] _rest604) => {
Set(scoreTx_89, "textContent", ((V)(JsStrBuf.Begin().S("You ").V(GetIdx(pts_97, 0D)).S(" \u2013 ").V(GetIdx(pts_97, 1D)).S(" ").V(okName_81).End())));
Invoke(ctx_39, "timer", ((V)("")));
return default;
}, 0, "", true);
api_120 = NewObj(10).Put("oppKey", ok_80).Put("start", Fn((V _self609, int _argc610, V _a612, V _a613, V _a614, V _a615, V[] _rest611) => {
if (_self609.IsNullish) _self609 = GlobalV;
Set(api_120, "_done", (false ? V.True : V.False));
pts_97 = Arr(((V)(0D)), ((V)(0D)));
rally_98 = 0D;
best_99 = 0D;
serveN_101 = 0D;
Invoke(ctx_39, "setScore", ((V)(0D)));
Call(say_112, V.Undef);
Call(newBall_113, V.Undef, ((V)(0D)));
Invoke(me_83, "play", ((V)("idle")));
Invoke(opp_82, "play", ((V)("idle")));
return default;
}, 0, "start", false)).Put("down", Fn((V _self616, int _argc617, V p_623, V _a620, V _a621, V _a622, V[] _rest618) => {
if (_self616.IsNullish) _self616 = GlobalV;
pxT_91 = Call(fingerToPx_63, V.Undef, Get(p_623, "x"));
if (((string.Equals(phase_102.Str, "serve") && SEqN(serve_100, 0D)) && ((ToNum(tNow_104) - ToNum(ph0_103)) > 300D))) {
phase_102.Set("play");
Invoke(ctx_39, "hint", ((V)("")));
Set(b_96, "x", ((V)((px_90 + 0.04))));
Call(hitByMe_115, V.Undef);
}
return default;
}, 1, "down", false)).Put("move", Fn((V _self624, int _argc625, V p_631, V _a628, V _a629, V _a630, V[] _rest626) => {
if (_self624.IsNullish) _self624 = GlobalV;
pxT_91 = Call(fingerToPx_63, V.Undef, Get(p_631, "x"));
return default;
}, 1, "move", false)).Put("key", Fn((V _self632, int _argc633, V k_639, V dn_640, V _a637, V _a638, V[] _rest634) => {
if (_self632.IsNullish) _self632 = GlobalV;
if (!(Truthy(dn_640))) {
return default;
}
if (SEqS(k_639, "ArrowLeft")) {
pxT_91 = Call(cl_18, V.Undef, ((V)((ToNum(pxT_91) - 0.15))), ((V)((-PXM_62))), ((V)(PXM_62)));
return (true ? V.True : V.False);
}
if (SEqS(k_639, "ArrowRight")) {
pxT_91 = Call(cl_18, V.Undef, Add(pxT_91, ((V)(0.15))), ((V)((-PXM_62))), ((V)(PXM_62)));
return (true ? V.True : V.False);
}
if ((SEqS(k_639, " ") || SEqS(k_639, "ArrowUp"))) {
Invoke(api_120, "down", NewObj(1).Put("x", ((V)((((ToNum(W_42) / 2D) + PAN0_59) + (px_90 * (ToNum(KP_61) - PANK_60)))))).V);
return (true ? V.True : V.False);
}
return default;
}, 2, "key", false)).Put("_state", Fn((V _self32, int _argc641, V _a643, V _a644, V _a645, V _a646, V[] _rest642) => {
return NewObj(8).Put("phase", ((V)(phase_102.Str))).Put("pts", Invoke(pts_97, "slice")).Put("rally", ((V)(rally_98))).Put("best", ((V)(best_99))).Put("b", (b_96 is var _t654 && !Truthy(_t654) ? _t654 : Invoke(Arr(Get(b_96, "x"), Get(b_96, "y"), Get(b_96, "z")), "map", Fn((V _self32, int _argc647, V v_653, V _a650, V _a651, V _a652, V[] _rest648) => {
return ((V)(ToNum(Invoke(v_653, "toFixed", ((V)(2D))))));
}, 1, "", true)))).Put("px", ((V)(ToNum(Invoke(((V)(px_90)), "toFixed", ((V)(2D))))))).Put("off", Invoke(Get(ME_86, "off"), "map", Fn((V _self32, int _argc655, V v_661, V _a658, V _a659, V _a660, V[] _rest656) => {
return ((V)(ToNum(Invoke(v_661, "toFixed", ((V)(1D))))));
}, 1, "", true))).Put("offO", Invoke(Get(OP_87, "off"), "map", Fn((V _self32, int _argc662, V v_668, V _a665, V _a666, V _a667, V[] _rest663) => {
return ((V)(ToNum(Invoke(v_668, "toFixed", ((V)(1D))))));
}, 1, "", true))).V;
}, 0, "_state", true)).Put("_aimAt", Fn((V _self32, int _argc669, V _a671, V _a672, V _a673, V _a674, V[] _rest670) => {
if (Truthy((b_96 is var _t675 && !Truthy(_t675) ? _t675 : (LtN(Get(b_96, "vz"), 0D) ? V.True : V.False)))) {
double tz_676 = 0;
tz_676 = ((ZP_53 - ToNum(Get(b_96, "z"))) / ToNum(Get(b_96, "vz")));
pxT_91 = Call(cl_18, V.Undef, ((V)((ToNum(Add(Get(b_96, "x"), ((V)((ToNum(Get(b_96, "vx")) * tz_676))))) - 0.04))), ((V)((-PXM_62))), ((V)(PXM_62)));
}
return default;
}, 0, "_aimAt", true)).Put("celebrate", Fn((V _self677, int _argc678, V st_684, V _a681, V _a682, V _a683, V[] _rest679) => {
if (_self677.IsNullish) _self677 = GlobalV;
Set(api_120, "_done", (true ? V.True : V.False));
Invoke(me_83, "pose", NewObj(1).Put("armL", ((V)(60D))).V);
Invoke(me_83, "yaw", ((V)(0D)));
Invoke(me_83, "play", ((V)((GeN(st_684, 2D) ? "happy" : "idle"))));
return default;
}, 1, "celebrate", false)).Put("update", Fn((V _self685, int _argc686, V dt_692, V t_693, V _a690, V _a691, V[] _rest687) => {
double px0_694 = 0;
double sp_695 = 0;
V ox0_696 = default;
V windMe_697 = default;
V windOp_698 = default;
V runMe_699 = default;
V runOp_700 = default;
if (_self685.IsNullish) _self685 = GlobalV;
tNow_104 = t_693;
px0_694 = px_90;
px_90 = (px_90 + ((ToNum(pxT_91) - px_90) * (1D - FdLibm.Exp(((-ToNum(dt_692)) * 12D)))));
pv_92 = ((px_90 - px0_694) / Max(ToNum(dt_692), 0.001));
if (Truthy((((b_96 is var _t701 && !Truthy(_t701) ? _t701 : (string.Equals(phase_102.Str, "serve") ? V.True : V.False)) is var _t702 && !Truthy(_t702) ? _t702 : (SEqN(serve_100, 1D) ? V.True : V.False)) is var _t703 && !Truthy(_t703) ? _t703 : (((ToNum(t_693) - ToNum(ph0_103)) > 900D) ? V.True : V.False)))) {
phase_102.Set("play");
Call(hitByOpp_116, V.Undef);
}
if (Truthy(((b_96 is var _t704 && !Truthy(_t704) ? _t704 : (string.Equals(phase_102.Str, "serve") ? V.True : V.False)) is var _t705 && !Truthy(_t705) ? _t705 : (SEqN(serve_100, 0D) ? V.True : V.False)))) {
Set(b_96, "x", ((V)((px_90 + 0.04))));
Set(b_96, "y", ((V)(((TY_50 + 0.3) + (System.Math.Abs(FdLibm.Sin(((ToNum(t_693) - ToNum(ph0_103)) / 260D))) * 0.15)))));
Set(b_96, "z", ((V)((ZP_53 + 0.02))));
}
if (Truthy((b_96 is var _t706 && !Truthy(_t706) ? _t706 : ((string.Equals(phase_102.Str, "play") || string.Equals(phase_102.Str, "point")) ? V.True : V.False)))) {
double n_707 = 0;
n_707 = 4D;
{
double i_708 = 0;
i_708 = 0D;
while (true) {
if (!((i_708 < n_707))) break;
double h_710 = 0;
V pz_711 = default;
h_710 = (ToNum(dt_692) / n_707);
pz_711 = Get(b_96, "z");
OpSet(b_96, "vy", 1, ((V)((G_45 * h_710))));
OpSet(b_96, "x", 0, ((V)((ToNum(Get(b_96, "vx")) * h_710))));
OpSet(b_96, "y", 0, ((V)((ToNum(Get(b_96, "vy")) * h_710))));
OpSet(b_96, "z", 0, ((V)((ToNum(Get(b_96, "vz")) * h_710))));
if (((((LeN(Get(b_96, "y"), (TY_50 + BR_52)) && LtN(Get(b_96, "vy"), 0D)) && (System.Math.Abs(ToNum(Get(b_96, "x"))) <= TW_46)) && GeN(Get(b_96, "z"), Z0_47)) && LeN(Get(b_96, "z"), Z1_48))) {
double hs_712 = 0;
Set(b_96, "y", ((V)((TY_50 + BR_52))));
Set(b_96, "vy", ((V)(((-ToNum(Get(b_96, "vy"))) * 0.82))));
IncM(b_96, "bounces", 1D, false);
Invoke(SFX_22, "tap");
hs_712 = (LtN(Get(b_96, "z"), ZN_49) ? 0D : 1D);
if (string.Equals(phase_102.Str, "play")) {
if (SEqN(lastHit_107, hs_712)) {
Call(point_117, V.Undef, (SEqN(lastHit_107, 1D) ? V.True : V.False), ((V)((SEqN(lastHit_107, 1D) ? "Fault!" : "Fault"))));
} else {
if (GeN(Get(b_96, "bounces"), 2D)) {
Call(point_117, V.Undef, ((hs_712 == 1D) ? V.True : V.False), ((hs_712 == 1D) ? ((V)("Point!")) : V.Null));
}
}
}
}
if ((((string.Equals(phase_102.Str, "play") && (((ToNum(pz_711) - ZN_49) * (ToNum(Get(b_96, "z")) - ZN_49)) <= 0D)) && LtN(Get(b_96, "y"), ((TY_50 + NH_51) + BR_52))) && (System.Math.Abs(ToNum(Get(b_96, "x"))) < (TW_46 + 0.06)))) {
Set(b_96, "vz", ((V)(((-ToNum(Get(b_96, "vz"))) * 0.15))));
OpSet(b_96, "vx", 2, ((V)(0.3)));
Invoke(SFX_22, "thud");
Call(point_117, V.Undef, (SEqN(lastHit_107, 1D) ? V.True : V.False), ((V)((SEqN(lastHit_107, 1D) ? "Net!" : "Into the net"))));
}
if (LtN(Get(b_96, "y"), BR_52)) {
if ((string.Equals(phase_102.Str, "play") && SEqN(Get(b_96, "bounces"), 0D))) {
Call(point_117, V.Undef, (SEqN(lastHit_107, 1D) ? V.True : V.False), ((V)((SEqN(lastHit_107, 1D) ? "Out!" : "Out"))));
}
Set(b_96, "y", ((V)(BR_52)));
Set(b_96, "vy", ((V)(((-ToNum(Get(b_96, "vy"))) * 0.5))));
OpSet(b_96, "vx", 2, ((V)(0.7)));
OpSet(b_96, "vz", 2, ((V)(0.7)));
}
if (string.Equals(phase_102.Str, "play")) {
if ((((LtN(Get(b_96, "vz"), 0D) && GeN(pz_711, ZP_53)) && LtN(Get(b_96, "z"), ZP_53)) && LtN(Get(b_96, "y"), (TY_50 + 0.75)))) {
if ((System.Math.Abs((ToNum(Get(b_96, "x")) - px_90)) < 0.13)) {
if ((SEqN(Get(b_96, "bounces"), 1D) || (SEqN(Get(b_96, "side"), 1D) && GeN(Get(b_96, "bounces"), 1D)))) {
Call(hitByMe_115, V.Undef);
} else {
if (SEqN(Get(b_96, "bounces"), 0D)) {
Call(hitByMe_115, V.Undef);
}
}
}
}
if (LtN(Get(b_96, "z"), (ZP_53 - 0.35))) {
Call(point_117, V.Undef, (false ? V.True : V.False), V.Null);
}
if ((((GtN(Get(b_96, "vz"), 0D) && LeN(pz_711, ZO_54)) && GtN(Get(b_96, "z"), ZO_54)) && LtN(Get(b_96, "y"), (TY_50 + 0.75)))) {
V pMiss_713 = default;
pMiss_713 = Call(cl_18, V.Undef, ((V)(((0.05 + (rally_98 * 0.012)) - ((ToNum(skill_108) - 0.5) * 0.12)))), ((V)(0.03)), ((V)(0.32)));
if (((System.Math.Abs((ToNum(Get(b_96, "x")) - ToNum(ox_93))) < 0.13) && Gt(Invoke(G("Math"), "random"), pMiss_713))) {
Call(hitByOpp_116, V.Undef);
} else {
if ((System.Math.Abs((ToNum(Get(b_96, "x")) - ToNum(ox_93))) < 0.2)) {
swingO_106 = tNow_104;
}
}
}
if (GtN(Get(b_96, "z"), (ZO_54 + 0.4))) {
Call(point_117, V.Undef, (true ? V.True : V.False), ((V)("Point!")));
}
}
i_708++;
}
}
}
if ((string.Equals(phase_102.Str, "point") && ((ToNum(t_693) - ToNum(ph0_103)) > 1200D))) {
if ((GeN(GetIdx(pts_97, 0D), 7D) || GeN(GetIdx(pts_97, 1D), 7D))) {
V won_714 = default;
phase_102.Set("done");
won_714 = (Gt(GetIdx(pts_97, 0D), GetIdx(pts_97, 1D)) ? V.True : V.False);
if (Truthy(won_714)) {
Invoke(ctx_39, "add", ((V)((50D + (best_99 * 5D)))), ((V)((ToNum(W_42) / 2D))), ((V)((ToNum(H_43) * 0.46))), ((V)(JsStrBuf.Begin().S("You win! +").N((50D + (best_99 * 5D))).End())), ((V)("#ffe36e")));
} else {
Invoke(ctx_39, "add", ((V)((best_99 * 5D))));
}
Invoke(ctx_39, "finish", NewObj(3).Put("title", ((V)((Truthy(won_714) ? "You win!" : JsStrBuf.Begin().V(okName_81).S(" wins").End())))).Put("sub", ((V)(JsStrBuf.Begin().S("You ").V(GetIdx(pts_97, 0D)).S(" \u2013 ").V(GetIdx(pts_97, 1D)).S(" \u00b7 best rally ").N(best_99).End()))).Put("delay", ((V)(900D))).V);
} else {
serveN_101++;
Call(newBall_113, V.Undef, ((V)((System.Math.Floor((serveN_101 / 2D)) % 2D))));
}
}
if (Truthy(((b_96 is var _t715 && !Truthy(_t715) ? _t715 : (string.Equals(phase_102.Str, "play") ? V.True : V.False)) is var _t716 && !Truthy(_t716) ? _t716 : (GtN(Get(b_96, "vz"), 0D) ? V.True : V.False)))) {
double tz_717 = 0;
V gx_718 = default;
double err_719 = 0;
tz_717 = ((ZO_54 - ToNum(Get(b_96, "z"))) / ToNum(Get(b_96, "vz")));
gx_718 = Add(Get(b_96, "x"), ((V)((ToNum(Get(b_96, "vx")) * tz_717))));
err_719 = (((1D - ToNum(skill_108)) * 0.16) * FdLibm.Sin(((ToNum(t_693) / 300D) + rally_98)));
oxT_94 = Call(cl_18, V.Undef, Add(gx_718, ((V)(err_719))), ((V)((-TW_46))), ((V)(TW_46)));
} else {
if ((!string.Equals(phase_102.Str, "serve") || SEqN(serve_100, 0D))) {
oxT_94 = Call(lerp_19, V.Undef, oxT_94, ((V)(0D)), ((V)((1D - FdLibm.Exp(((-ToNum(dt_692)) * 2D))))));
}
}
sp_695 = (0.9 + (ToNum(skill_108) * 1.4));
ox0_696 = ox_93;
ox_93 = Add(ox_93, Call(cl_18, V.Undef, ((V)((ToNum(oxT_94) - ToNum(ox_93)))), ((V)(((-sp_695) * ToNum(dt_692)))), ((V)((sp_695 * ToNum(dt_692))))));
if ((string.Equals(phase_102.Str, "serve") && SEqN(serve_100, 1D))) {
ox_93 = Call(lerp_19, V.Undef, ox_93, ((V)(0D)), ((V)(0.1)));
Set(b_96, "x", ox_93);
Set(b_96, "y", ((V)(((TY_50 + 0.28) + (System.Math.Abs(FdLibm.Sin(((ToNum(t_693) - ToNum(ph0_103)) / 240D))) * 0.12)))));
Set(b_96, "z", ((V)((ZO_54 - 0.02))));
}
ov_95 = ((ToNum(ox_93) - ToNum(ox0_696)) / Max(ToNum(dt_692), 0.001));
windMe_697 = (Truthy((((b_96 is var _t720 && !Truthy(_t720) ? _t720 : (string.Equals(phase_102.Str, "play") ? V.True : V.False)) is var _t721 && !Truthy(_t721) ? _t721 : (LtN(Get(b_96, "vz"), 0D) ? V.True : V.False)) is var _t722 && !Truthy(_t722) ? _t722 : (GtN(Get(b_96, "z"), ZP_53) ? V.True : V.False))) ? Call(cl_18, V.Undef, ((V)((1D - ((((ToNum(Get(b_96, "z")) - ZP_53) / (-ToNum(Get(b_96, "vz")))) - 0.06) / 0.42)))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
windOp_698 = (Truthy((((b_96 is var _t723 && !Truthy(_t723) ? _t723 : (string.Equals(phase_102.Str, "play") ? V.True : V.False)) is var _t724 && !Truthy(_t724) ? _t724 : (GtN(Get(b_96, "vz"), 0D) ? V.True : V.False)) is var _t725 && !Truthy(_t725) ? _t725 : (LtN(Get(b_96, "z"), ZO_54) ? V.True : V.False))) ? Call(cl_18, V.Undef, ((V)((1D - ((((ZO_54 - ToNum(Get(b_96, "z"))) / ToNum(Get(b_96, "vz"))) - 0.06) / 0.42)))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
runMe_699 = Call(cl_18, V.Undef, ((V)((System.Math.Abs(pv_92) / 1.6))), ((V)(0D)), ((V)(1D)));
runOp_700 = Call(cl_18, V.Undef, ((V)((System.Math.Abs(ov_95) / 1.4))), ((V)(0D)), ((V)(1D)));
if (Truthy(((((b_96 is var _t726 && !Truthy(_t726) ? _t726 : (string.Equals(phase_102.Str, "play") ? V.True : V.False)) is var _t727 && !Truthy(_t727) ? _t727 : (LtN(Get(b_96, "vz"), 0D) ? V.True : V.False)) is var _t728 && !Truthy(_t728) ? _t728 : (GtN(Get(b_96, "z"), ZP_53) ? V.True : V.False)) is var _t729 && !Truthy(_t729) ? _t729 : (((ToNum(t_693) - ToNum(swingP_105)) > 600D) ? V.True : V.False)))) {
double tz_730 = 0;
V gx_731 = default;
tz_730 = ((ToNum(Get(b_96, "z")) - ZP_53) / (-ToNum(Get(b_96, "vz"))));
gx_731 = Add(Get(b_96, "x"), ((V)((ToNum(Get(b_96, "vx")) * tz_730))));
if (((tz_730 < 0.075) && (System.Math.Abs((ToNum(gx_731) - px_90)) < 0.2))) {
swingP_105 = ((V)((ToNum(Add(t_693, ((V)((tz_730 * 1000D))))) - 60D)));
}
}
if (Truthy(((((b_96 is var _t732 && !Truthy(_t732) ? _t732 : (string.Equals(phase_102.Str, "play") ? V.True : V.False)) is var _t733 && !Truthy(_t733) ? _t733 : (GtN(Get(b_96, "vz"), 0D) ? V.True : V.False)) is var _t734 && !Truthy(_t734) ? _t734 : (LtN(Get(b_96, "z"), ZO_54) ? V.True : V.False)) is var _t735 && !Truthy(_t735) ? _t735 : (((ToNum(t_693) - ToNum(swingO_106)) > 600D) ? V.True : V.False)))) {
double tz_736 = 0;
V gx_737 = default;
tz_736 = ((ZO_54 - ToNum(Get(b_96, "z"))) / ToNum(Get(b_96, "vz")));
gx_737 = Add(Get(b_96, "x"), ((V)((ToNum(Get(b_96, "vx")) * tz_736))));
if (((tz_736 < 0.075) && (System.Math.Abs((ToNum(gx_737) - ToNum(ox_93))) < 0.2))) {
swingO_106 = ((V)((ToNum(Add(t_693, ((V)((tz_736 * 1000D))))) - 60D)));
}
}
if (!(Truthy(Get(api_120, "_done")))) {
Call(poseCreature_119, V.Undef, me_83, ME_86, Call(swingPose_118, V.Undef, windMe_697, ((V)((ToNum(t_693) - ToNum(swingP_105))))), runMe_699, dt_692, ((V)(180D)), Add(((V)(150D)), Call(cl_18, V.Undef, ((V)((pv_92 * 6D))), ((V)((-14D))), ((V)(14D)))), NewObj(2).Put("tilt", Call(cl_18, V.Undef, ((V)((pv_92 * 5D))), ((V)((-7D))), ((V)(7D)))).Put("smile", ((V)((string.Equals(phase_102.Str, "point") ? 0D : 0.2)))).V);
}
Call(poseCreature_119, V.Undef, opp_82, OP_87, Call(swingPose_118, V.Undef, windOp_698, ((V)((ToNum(t_693) - ToNum(swingO_106))))), runOp_700, dt_692, ((V)(0D)), Add(Call(cl_18, V.Undef, ((V)(((-ov_95) * 6D))), ((V)((-16D))), ((V)(16D))), ((V)(8D))), NewObj(1).Put("tilt", Call(cl_18, V.Undef, ((V)(((-ov_95) * 5D))), ((V)((-7D))), ((V)(7D)))).V);
if ((((System.Math.Abs((pv_92 - pvPrev_111)) > (((9D * ToNum(dt_692)) * 60D) * 0.05)) && (System.Math.Abs(pv_92) > 1.2)) && Gt(t_693, dustAt_110))) {
V f_738 = default;
dustAt_110 = Add(t_693, ((V)(260D)));
f_738 = Call(P_44, V.Undef, ((V)((px_90 - 0.2))), ((V)(0D)), ((V)(0.2)));
Invoke(ctx_39, "burst", GetIdx(f_738, 0D), ((V)(Min((ToNum(H_43) - 40D), ToNum(GetIdx(f_738, 1D))))), ((V)("dust")), ((V)(4D)), NewObj(3).Put("v", ((V)(50D))).Put("life", ((V)(0.5))).Put("layer", fg_41).V);
}
pvPrev_111 = pv_92;
if (((((GtN(t_693, 600D) && LtN(Get(ME_86, "offN"), 6D)) && LtN(windMe_697, 0.05)) && ((ToNum(t_693) - ToNum(swingP_105)) > 700D)) && LtN(runMe_699, 0.05))) {
Call(learn_88, V.Undef, me_83, ME_86);
}
if (((((GtN(t_693, 600D) && LtN(Get(OP_87, "offN"), 6D)) && LtN(windOp_698, 0.05)) && ((ToNum(t_693) - ToNum(swingO_106)) > 700D)) && LtN(runOp_700, 0.05))) {
Call(learn_88, V.Undef, opp_82, OP_87);
}
{
V g_739 = default;
double k_740 = 0;
g_739 = Call(P_44, V.Undef, ((V)(px_90)), ((V)((TY_50 + 0.11))), ((V)(ZP_53)));
k_740 = (MESZ_84 / 100D);
Invoke(me_83, "set", ((V)((ToNum(GetIdx(g_739, 0D)) - (ToNum(GetIdx(Get(ME_86, "off"), 0D)) * k_740)))), ((V)((ToNum(GetIdx(g_739, 1D)) - (ToNum(GetIdx(Get(ME_86, "off"), 1D)) * k_740)))), ((V)(MESZ_84)));
}
{
V g_741 = default;
double k_742 = 0;
g_741 = Call(P_44, V.Undef, ox_93, ((V)((TY_50 + 0.12))), ((V)(ZO_54)));
k_742 = (OPSZ_85 / 100D);
Invoke(opp_82, "set", ((V)((ToNum(GetIdx(g_741, 0D)) - (ToNum(GetIdx(Get(OP_87, "off"), 0D)) * k_742)))), ((V)((ToNum(GetIdx(g_741, 1D)) - (ToNum(GetIdx(Get(OP_87, "off"), 1D)) * k_742)))), ((V)(OPSZ_85)));
}
{
double pan_743 = 0;
V tr_744 = default;
pan_743 = (PAN0_59 - (px_90 * PANK_60));
tr_744 = ((V)(JsStrBuf.Begin().S("translateX(").V(Call(r2_20, V.Undef, ((V)(((pan_743 / ToNum(W_42)) * 100D))))).S("%)").End()));
Invoke(Arr(scene_65, bg_40, oppL_66, tbl_67, Get(ctx_39, "crl"), fg_41), "forEach", Fn((V _self685, int _argc745, V e_751, V _a748, V _a749, V _a750, V[] _rest746) => {
if (!SEq(Get(Get(e_751, "style"), "transform"), tr_744)) {
Set(Get(e_751, "style"), "transform", tr_744);
}
return default;
}, 1, "", true));
}
if (Truthy(b_96)) {
V s_752 = default;
double r_753 = 0;
V lay_754 = default;
V onT_755 = default;
double gy_756 = 0;
V g0_757 = default;
V hk_758 = default;
s_752 = Call(P_44, V.Undef, Get(b_96, "x"), Get(b_96, "y"), Get(b_96, "z"));
r_753 = Max(2.4, (BR_52 * ToNum(GetIdx(s_752, 2D))));
Invoke(ball_77, "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, GetIdx(s_752, 0D)));
Invoke(ball_77, "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, GetIdx(s_752, 1D)));
Invoke(ball_77, "setAttribute", ((V)("r")), Call(r2_20, V.Undef, ((V)(r_753))));
lay_754 = (GtN(Get(b_96, "z"), ZN_49) ? ballFar_72 : (GtN(Get(b_96, "z"), 0.2) ? ballNear_74 : ballBack_75));
if (!SEq(Get(ball_77, "parentNode"), lay_754)) {
Invoke(lay_754, "appendChild", trail_78);
Invoke(lay_754, "appendChild", ball_77);
}
if (!SEq(Get(ballSh_76, "parentNode"), (GtN(Get(b_96, "z"), ZN_49) ? tbl_67 : ballNear_74))) {
if (GtN(Get(b_96, "z"), ZN_49)) {
Invoke(tbl_67, "insertBefore", ballSh_76, ballFar_72);
} else {
Invoke(ballNear_74, "insertBefore", ballSh_76, Get(ballNear_74, "firstChild"));
}
}
onT_755 = ((((System.Math.Abs(ToNum(Get(b_96, "x"))) <= TW_46) && GeN(Get(b_96, "z"), Z0_47)) && LeN(Get(b_96, "z"), Z1_48)) ? V.True : V.False);
gy_756 = (Truthy(onT_755) ? TY_50 : 0D);
g0_757 = Call(P_44, V.Undef, Get(b_96, "x"), ((V)(gy_756)), Get(b_96, "z"));
hk_758 = Call(cl_18, V.Undef, ((V)((1D - ((ToNum(Get(b_96, "y")) - gy_756) / 1D)))), ((V)(0.2)), ((V)(1D)));
Invoke(ballSh_76, "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, GetIdx(g0_757, 0D)));
Invoke(ballSh_76, "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, GetIdx(g0_757, 1D)));
Invoke(ballSh_76, "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)(((r_753 * 1.2) * ToNum(hk_758))))));
Invoke(ballSh_76, "setAttribute", ((V)("ry")), Call(r2_20, V.Undef, ((V)(((r_753 * 0.5) * ToNum(hk_758))))));
Invoke(ballSh_76, "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)((0.35 * ToNum(hk_758))))));
Invoke(trailPts_109, "push", Arr(GetIdx(s_752, 0D), GetIdx(s_752, 1D)));
if (GtN(Get(trailPts_109, "length"), 6D)) {
Invoke(trailPts_109, "shift");
}
Invoke(trail_78, "setAttribute", ((V)("d")), ((V)((string.Equals(phase_102.Str, "play") ? JsStrBuf.Begin().S("M").V(Invoke(Invoke(trailPts_109, "map", Fn((V _self685, int _argc759, V q_765, V _a762, V _a763, V _a764, V[] _rest760) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(q_765, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(q_765, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).End() : ""))));
}
return default;
}, 2, "update", false)).Put("destroy", Fn((V _self766, int _argc767, V _a769, V _a770, V _a771, V _a772, V[] _rest768) => {
if (_self766.IsNullish) _self766 = GlobalV;
Invoke(Arr(bg_40, Get(ctx_39, "crl"), fg_41), "forEach", Fn((V _self766, int _argc773, V e_779, V _a776, V _a777, V _a778, V[] _rest774) => {
Set(Get(e_779, "style"), "transform", ((V)("")));
return default;
}, 1, "", true));
Invoke(Arr(me_83, opp_82), "forEach", Fn((V _self766, int _argc780, V c_786, V _a783, V _a784, V _a785, V[] _rest781) => {
if (Truthy(Get(c_786, "I"))) {
Set(Get(c_786, "I"), "propFn", V.Null);
Set(Get(c_786, "I"), "propArm", V.Null);
}
return default;
}, 1, "", true));
Invoke(opp_82, "destroy");
Invoke(oppL_66, "remove");
Invoke(tbl_67, "remove");
Invoke(scene_65, "remove");
return default;
}, 0, "destroy", false)).V;
Invoke(ballFarSh_71, "remove");
Call(newBall_113, V.Undef, ((V)(0D)));
Call(say_112, V.Undef);
return api_120;
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
