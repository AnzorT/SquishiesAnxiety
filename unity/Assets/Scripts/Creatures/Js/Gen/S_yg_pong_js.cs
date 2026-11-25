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
go_8 = Fn((V _arrowThis15, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_16 = default;
V S_17 = default;
V D_18 = default;
V cl_19 = default;
V lerp_20 = default;
V r2_21 = default;
V track_22 = default;
V SFX_23 = default;
V ICON_24 = default;
YG_16 = Get(G("window"), "YardGames");
if (((!(Truthy(YG_16)) || !(Truthy(Get(YG_16, "add")))) || !(Truthy(Get(YG_16, "cam"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t25 = YG_16;
if (_t25.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t25));
{ V _t26 = Get(_t25, "S");
S_17 = _t26; }
{ V _t27 = Get(_t25, "D");
D_18 = _t27; }
{ V _t28 = Get(_t25, "cl");
cl_19 = _t28; }
{ V _t29 = Get(_t25, "lerp");
lerp_20 = _t29; }
{ V _t30 = Get(_t25, "r2");
r2_21 = _t30; }
{ V _t31 = Get(_t25, "track");
track_22 = _t31; }
{ V _t32 = Get(_t25, "SFX");
SFX_23 = _t32; } }
ICON_24 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#9fdc6e\"/><path d=\"M22 70L38 22H82L98 70Z\" fill=\"#2f6fc0\"/><path d=\"M22 70H98V75H22Z\" fill=\"#245a9e\"/>", "<path d=\"M60 22V70M24 64L96 64M37 25H83\" stroke=\"#fff\" stroke-width=\"1.6\" opacity=\"0.9\"/><path d=\"M29 47H91\" stroke=\"#e9eef5\" stroke-width=\"5\"/><path d=\"M29 44H91\" stroke=\"#3a3a44\" stroke-width=\"1\"/>", "<circle cx=\"40\" cy=\"62\" r=\"7\" fill=\"#e8483c\"/><rect x=\"38.5\" y=\"67\" width=\"3\" height=\"7\" rx=\"1.5\" fill=\"#8a5a34\"/><circle cx=\"80\" cy=\"28\" r=\"4.6\" fill=\"#3a3a44\"/><circle cx=\"66\" cy=\"38\" r=\"2.4\" fill=\"#fff\"/></svg>")));
Invoke(YG_16, "add", NewObj(11).Put("id", ((V)("pong"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Ping-Pong"))).Put("item", ((V)("Ping-Pong Table"))).Put("color", ((V)("#2f9e6f"))).Put("icon", ICON_24).Put("stars", Arr(((V)(100D)), ((V)(160D)), ((V)(220D)))).Put("coinK", ((V)(0.25))).Put("hint", ((V)("Slide left and right to move \u00b7 first to 7"))).Put("how", Arr(((V)("Slide your finger left and right: your creature runs to the ball and swings by itself.")), ((V)("Hit it on the paddle's edge (or while running) to angle your shot.")), ((V)("First to 7 wins. Long rallies score extra!")))).Put("make", Fn((V _self33, int _argc34, V ctx_40, V _a37, V _a38, V _a39, V[] _rest35) => {
V bg_41 = default;
V fg_42 = default;
V W_43 = default;
V H_44 = default;
V P_45 = default;
double G_46 = 0;
double TW_47 = 0;
double Z0_48 = 0;
double Z1_49 = 0;
double ZN_50 = 0;
double TY_51 = 0;
double NH_52 = 0;
double BR_53 = 0;
double ZP_54 = 0;
double ZO_55 = 0;
double GZ_56 = 0;
V SM_57 = default;
V eo_58 = default;
V stage_59 = default;
double PAN0_60 = 0;
double PANK_61 = 0;
V KP_62 = default;
double PXM_63 = 0;
V fingerToPx_64 = default;
V svgL_65 = default;
V scene_66 = default;
V oppL_67 = default;
V tbl_68 = default;
V quad_69 = default;
V line_70 = default;
V drawScene_71 = default;
V ballFarSh_72 = default;
V ballFar_73 = default;
V netG_74 = default;
V ballNear_75 = default;
V ballBack_76 = default;
V ballSh_77 = default;
V ball_78 = default;
V trail_79 = default;
V PADDLE_80 = default;
V ok_81 = default;
V okName_82 = default;
V opp_83 = default;
V me_84 = default;
double MESZ_85 = 0;
double OPSZ_86 = 0;
V ME_87 = default;
V OP_88 = default;
V learn_89 = default;
V scoreTx_90 = default;
double px_91 = 0;
V pxT_92 = default;
double pv_93 = 0;
V ox_94 = default;
V oxT_95 = default;
double ov_96 = 0;
V b_97 = default;
V pts_98 = default;
double rally_99 = 0;
double best_100 = 0;
V serve_101 = default;
double serveN_102 = 0;
JsStrBuf phase_103 = null;
V ph0_104 = default;
V tNow_105 = default;
V swingP_106 = default;
V swingO_107 = default;
V lastHit_108 = default;
V skill_109 = default;
V trailPts_110 = default;
V dustAt_111 = default;
double pvPrev_112 = 0;
V say_113 = default;
V newBall_114 = default;
V send_115 = default;
V hitByMe_116 = default;
V hitByOpp_117 = default;
V point_118 = default;
V swingPose_119 = default;
V poseCreature_120 = default;
V api_121 = default;
if (_self33.IsNullish) _self33 = GlobalV;
drawScene_71 = Fn((V _self122, int _argc123, V sv_129, V _a126, V _a127, V _a128, V[] _rest124) => {
V k0_130 = default;
V gp_131 = default;
double FT_132 = 0;
V far_133 = default;
V tree_134 = default;
if (_self122.IsNullish) _self122 = GlobalV;
k0_130 = GetIdx(Call(P_45, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(GZ_56))), 2D);
gp_131 = Fn((V _arrowThis143, int _argc135, V x_141, V z_142, V _a139, V _a140, V[] _rest136) => {
return Call(P_45, V.Undef, x_141, ((V)(0D)), z_142);
}, 2, "", true);
Set(Call(S_17, V.Undef, ((V)("defs")), NewObj(0).V, sv_129), "innerHTML", ((V)(JsStrBuf.Begin().S("<linearGradient id=\"ppSky\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#62b4f0\"/><stop offset=\"0.7\" stop-color=\"#aedcfa\"/><stop offset=\"1\" stop-color=\"#e2f4ff\"/></linearGradient>").S("<radialGradient id=\"ppSunG\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fffbe6\" stop-opacity=\"0.95\"/><stop offset=\"0.35\" stop-color=\"#fff2b8\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#ffe9a0\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"ppLawn\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#8fcf62\"/><stop offset=\"1\" stop-color=\"#4f9a3c\"/></linearGradient>").S("<linearGradient id=\"ppFence\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#c98f58\"/><stop offset=\"1\" stop-color=\"#a8703e\"/></linearGradient>").S("<linearGradient id=\"ppStone\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#d8d0c2\"/><stop offset=\"1\" stop-color=\"#bdb3a2\"/></linearGradient>").S("<radialGradient id=\"ppSun\" cx=\"88%\" cy=\"6%\" r=\"90%\"><stop offset=\"0\" stop-color=\"#fff4c8\" stop-opacity=\"0.4\"/><stop offset=\"1\" stop-color=\"#fff4c8\" stop-opacity=\"0\"/></radialGradient>").S("<filter id=\"ppGrain\" x=\"0\" y=\"0\" width=\"100%\" height=\"100%\"><feTurbulence type=\"fractalNoise\" baseFrequency=\"0.7\" numOctaves=\"3\" seed=\"8\"/><feColorMatrix values=\"0 0 0 0 0.3  0 0 0 0 0.28  0 0 0 0 0.25  0 0 0 0.5 -0.12\"/><feComposite in2=\"SourceGraphic\" operator=\"in\"/></filter>").End())));
Call(S_17, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-160D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_43, ((V)(320D)))).Put("height", ((V)(380D))).Put("fill", ((V)("url(#ppSky)"))).V, sv_129);
FT_132 = (ToNum(GetIdx(Call(P_45, V.Undef, ((V)(0D)), ((V)(1.45)), ((V)(GZ_56))), 1D)) - 142D);
far_133 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(0 ").V(Call(r2_21, V.Undef, ((V)(FT_132)))).S(")").End()))).V, sv_129);
Invoke(Arr(Arr(((V)(40D)), ((V)(96D)), ((V)(0.7))), Arr(((V)(210D)), ((V)(70D)), ((V)(0.55))), Arr(((V)(430D)), ((V)(104D)), ((V)(0.6))), Arr(((V)((-90D))), ((V)(70D)), ((V)(0.5))), Arr(((V)(620D)), ((V)(80D)), ((V)(0.6))), Arr(((V)(760D)), ((V)(60D)), ((V)(0.5)))), "forEach", Fn((V _arrowThis157, int _argc144, V _a146, V _a147, V _a148, V _a149, V[] _rest145) => {
V g_158 = default;
V x_152 = default;
V y_154 = default;
V k_156 = default;
{ V _t150 = ListOf(_a146);
{ V _t151 = GetIdx(_t150, 0D);
x_152 = _t151; }
{ V _t153 = GetIdx(_t150, 1D);
y_154 = _t153; }
{ V _t155 = GetIdx(_t150, 2D);
k_156 = _t155; }
}
g_158 = Call(S_17, V.Undef, ((V)("g")), NewObj(2).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(x_152).S(" ").V(y_154).S(") scale(").V(k_156).S(")").End()))).Put("opacity", ((V)(0.92))).V, sv_129);
Invoke(Arr(Arr(((V)((-28D))), ((V)(6D)), ((V)(17D))), Arr(((V)((-6D))), ((V)((-6D))), ((V)(24D))), Arr(((V)(20D)), ((V)(0D)), ((V)(20D))), Arr(((V)(38D)), ((V)(8D)), ((V)(13D))), Arr(((V)(4D)), ((V)(10D)), ((V)(18D))), Arr(((V)((-18D))), ((V)(12D)), ((V)(14D)))), "forEach", Fn((V _arrowThis172, int _argc159, V _a161, V _a162, V _a163, V _a164, V[] _rest160) => {
V a_167 = default;
V b2_169 = default;
V r_171 = default;
{ V _t165 = ListOf(_a161);
{ V _t166 = GetIdx(_t165, 0D);
a_167 = _t166; }
{ V _t168 = GetIdx(_t165, 1D);
b2_169 = _t168; }
{ V _t170 = GetIdx(_t165, 2D);
r_171 = _t170; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", a_167).Put("cy", b2_169).Put("r", r_171).Put("fill", ((V)("#ffffff"))).V, g_158);
}, 1, "", true));
return default;
}, 1, "", true));
{
JsStrBuf d_173 = null;
d_173 = new JsStrBuf("M-160 150");
{
double x_174 = 0;
x_174 = (-160D);
while (true) {
if (!(Le(((V)(x_174)), Add(W_43, ((V)(160D)))))) break;
d_173.S("Q").N((x_174 + 7D)).S(" ").N((122D - (((x_174 * 37D) + 999D) % 21D))).S(" ").N((x_174 + 14D)).S(" ").N((134D - (((x_174 * 53D) + 999D) % 11D)));
x_174 = (x_174 + 14D);
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(string.Concat(d_173.Str, "V190H-160Z")))).Put("fill", ((V)("#8fbf9a"))).Put("opacity", ((V)(0.8))).V, far_133);
}
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)("M-40 128L-6 104L28 128V170H-40Z"))).Put("fill", ((V)("#c9a596"))).Put("opacity", ((V)(0.8))).V, far_133);
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)("M370 124L404 100L438 124V170H370Z"))).Put("fill", ((V)("#c9a596"))).Put("opacity", ((V)(0.8))).V, far_133);
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)("M600 126L640 98L680 126V170H600Z"))).Put("fill", ((V)("#c9a596"))).Put("opacity", ((V)(0.8))).V, far_133);
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)("M760 128L792 106L824 128V170H760Z"))).Put("fill", ((V)("#c9a596"))).Put("opacity", ((V)(0.75))).V, far_133);
tree_134 = Fn((V _arrowThis188, int _argc176, V x_182, V z_183, V h_184, V r_185, V[] _rest177) => {
V a_189 = default;
V k_190 = default;
V c1_186 = default;
V c2_187 = default;
c1_186 = (_argc176 > 4 ? _rest177[0] : V.Undef);
c2_187 = (_argc176 > 5 ? _rest177[1] : V.Undef);
a_189 = Call(gp_131, V.Undef, x_182, z_183);
k_190 = GetIdx(a_189, 2D);
Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_189, 0D)) - (0.12 * ToNum(k_190))))))).S(" ").V(Call(r2_21, V.Undef, GetIdx(a_189, 1D))).S("L").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_189, 0D)) - (0.07 * ToNum(k_190))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_189, 1D)) - (ToNum(h_184) * ToNum(k_190))))))).S("L").V(Call(r2_21, V.Undef, Add(GetIdx(a_189, 0D), ((V)((0.07 * ToNum(k_190))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_189, 1D)) - (ToNum(h_184) * ToNum(k_190))))))).S("L").V(Call(r2_21, V.Undef, Add(GetIdx(a_189, 0D), ((V)((0.12 * ToNum(k_190))))))).S(" ").V(Call(r2_21, V.Undef, GetIdx(a_189, 1D))).S("Z").End()))).Put("fill", ((V)("#7a5034"))).V, sv_129);
Invoke(Arr(Arr(((V)((-0.7))), ((V)(((-ToNum(h_184)) - 0.1))), ((V)((ToNum(r_185) * 0.8))), c1_186), Arr(((V)(0.65)), ((V)((-ToNum(h_184)))), ((V)((ToNum(r_185) * 0.85))), c1_186), Arr(((V)(0D)), ((V)(((-ToNum(h_184)) - 0.7))), r_185, c2_187), Arr(((V)((-0.35))), ((V)(((-ToNum(h_184)) - 1.1))), ((V)((ToNum(r_185) * 0.7))), c2_187), Arr(((V)(0.4)), ((V)(((-ToNum(h_184)) - 1D))), ((V)((ToNum(r_185) * 0.66))), c2_187), Arr(((V)(0.05)), ((V)(((-ToNum(h_184)) - 0.3))), ((V)((ToNum(r_185) * 0.8))), c2_187)), "forEach", Fn((V _arrowThis206, int _argc191, V _a193, V _a194, V _a195, V _a196, V[] _rest192) => {
V dx_199 = default;
V dy_201 = default;
V rr_203 = default;
V c_205 = default;
{ V _t197 = ListOf(_a193);
{ V _t198 = GetIdx(_t197, 0D);
dx_199 = _t198; }
{ V _t200 = GetIdx(_t197, 1D);
dy_201 = _t200; }
{ V _t202 = GetIdx(_t197, 2D);
rr_203 = _t202; }
{ V _t204 = GetIdx(_t197, 3D);
c_205 = _t204; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_21, V.Undef, Add(GetIdx(a_189, 0D), ((V)((ToNum(dx_199) * ToNum(k_190))))))).Put("cy", Call(r2_21, V.Undef, Add(GetIdx(a_189, 1D), ((V)((ToNum(dy_201) * ToNum(k_190))))))).Put("r", Call(r2_21, V.Undef, ((V)((ToNum(rr_203) * ToNum(k_190)))))).Put("fill", c_205).V, sv_129);
}, 1, "", true));
return default;
}, 6, "", true);
Call(tree_134, V.Undef, ((V)((-2.6))), ((V)((GZ_56 + 1.2))), ((V)(2.2)), ((V)(1D)), ((V)("#4c9140")), ((V)("#5aa84a")));
Call(tree_134, V.Undef, ((V)(0.6)), ((V)((GZ_56 + 1.6))), ((V)(2.6)), ((V)(1.1)), ((V)("#4f9a3e")), ((V)("#62ad52")));
Call(tree_134, V.Undef, ((V)(3.4)), ((V)((GZ_56 + 1D))), ((V)(2D)), ((V)(0.95)), ((V)("#4c9140")), ((V)("#5aa84a")));
Call(tree_134, V.Undef, ((V)((-4.8))), ((V)((GZ_56 + 1.4))), ((V)(2.4)), ((V)(1D)), ((V)("#4f9a3e")), ((V)("#62ad52")));
Call(tree_134, V.Undef, ((V)(5.6)), ((V)((GZ_56 + 1.4))), ((V)(2.3)), ((V)(1D)), ((V)("#4f9a3e")), ((V)("#62ad52")));
Call(tree_134, V.Undef, ((V)((-7.6))), ((V)((GZ_56 + 1.1))), ((V)(2.1)), ((V)(1D)), ((V)("#4c9140")), ((V)("#5aa84a")));
Call(tree_134, V.Undef, ((V)(8.2)), ((V)((GZ_56 + 1.2))), ((V)(2.4)), ((V)(1.05)), ((V)("#4c9140")), ((V)("#5aa84a")));
Call(quad_69, V.Undef, Arr(Arr(((V)((-12D))), ((V)(0D)), ((V)((-1D)))), Arr(((V)(12D)), ((V)(0D)), ((V)((-1D)))), Arr(((V)(12D)), ((V)(0D)), ((V)(GZ_56))), Arr(((V)((-12D))), ((V)(0D)), ((V)(GZ_56)))), NewObj(1).Put("fill", ((V)("url(#ppLawn)"))).V, sv_129);
{
double i_207 = 0;
i_207 = (-12D);
while (true) {
if (!((i_207 <= 12D))) break;
double x0_209 = 0;
x0_209 = (i_207 * 0.8);
Call(quad_69, V.Undef, Arr(Arr(((V)(x0_209)), ((V)(0D)), ((V)((-0.8)))), Arr(((V)((x0_209 + 0.4))), ((V)(0D)), ((V)((-0.8)))), Arr(((V)((x0_209 + 0.4))), ((V)(0D)), ((V)(GZ_56))), Arr(((V)(x0_209)), ((V)(0D)), ((V)(GZ_56)))), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.06))).V, sv_129);
i_207++;
}
}
Call(quad_69, V.Undef, Arr(Arr(((V)((-10D))), ((V)(0D)), ((V)(GZ_56))), Arr(((V)(10D)), ((V)(0D)), ((V)(GZ_56))), Arr(((V)(10D)), ((V)(1.45)), ((V)(GZ_56))), Arr(((V)((-10D))), ((V)(1.45)), ((V)(GZ_56)))), NewObj(1).Put("fill", ((V)("url(#ppFence)"))).V, sv_129);
{
V g_210 = default;
g_210 = Call(S_17, V.Undef, ((V)("g")), NewObj(3).Put("stroke", ((V)("#8a5a30"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.7))).V, sv_129);
{
double x_211 = 0;
x_211 = (-10D);
while (true) {
if (!((x_211 <= 10D))) break;
Call(line_70, V.Undef, Arr(Arr(((V)(x_211)), ((V)(0D)), ((V)(GZ_56))), Arr(((V)(x_211)), ((V)(1.45)), ((V)(GZ_56)))), NewObj(0).V, g_210);
x_211 = (x_211 + 0.16);
}
}
}
Invoke(Arr(((V)(0.25)), ((V)(1.2))), "forEach", Fn((V _arrowThis220, int _argc213, V y_219, V _a216, V _a217, V _a218, V[] _rest214) => {
return Call(quad_69, V.Undef, Arr(Arr(((V)((-10D))), y_219, ((V)((GZ_56 - 0.02)))), Arr(((V)(10D)), y_219, ((V)((GZ_56 - 0.02)))), Arr(((V)(10D)), Add(y_219, ((V)(0.09))), ((V)((GZ_56 - 0.02)))), Arr(((V)((-10D))), Add(y_219, ((V)(0.09))), ((V)((GZ_56 - 0.02))))), NewObj(1).Put("fill", ((V)("#9a6436"))).V, sv_129);
}, 1, "", true));
{
double x_221 = 0;
x_221 = (-9.8);
while (true) {
if (!((x_221 <= 10D))) break;
Call(quad_69, V.Undef, Arr(Arr(((V)((x_221 - 0.05))), ((V)(0D)), ((V)((GZ_56 - 0.03)))), Arr(((V)((x_221 + 0.05))), ((V)(0D)), ((V)((GZ_56 - 0.03)))), Arr(((V)((x_221 + 0.05))), ((V)(1.52)), ((V)((GZ_56 - 0.03)))), Arr(((V)((x_221 - 0.05))), ((V)(1.52)), ((V)((GZ_56 - 0.03))))), NewObj(1).Put("fill", ((V)("#8a5a30"))).V, sv_129);
x_221 = (x_221 + 1.8);
}
}
Call(quad_69, V.Undef, Arr(Arr(((V)((-10D))), ((V)(0D)), ((V)((GZ_56 - 0.02)))), Arr(((V)(10D)), ((V)(0D)), ((V)((GZ_56 - 0.02)))), Arr(((V)(10D)), ((V)(0D)), ((V)((GZ_56 - 0.5)))), Arr(((V)((-10D))), ((V)(0D)), ((V)((GZ_56 - 0.5))))), NewObj(1).Put("fill", ((V)("#7a5a3a"))).V, sv_129);
{
double sd_223 = 0;
V rnd_224 = default;
sd_223 = 5D;
rnd_224 = Fn((V _arrowThis231, int _argc225, V _a227, V _a228, V _a229, V _a230, V[] _rest226) => {
return ((V)(((sd_223 = (((sd_223 * 9301D) + 49297D) % 233280D)) / 233280D)));
}, 0, "", true);
{
double i_232 = 0;
i_232 = 0D;
while (true) {
if (!((i_232 < 110D))) break;
double x_234 = 0;
double z_235 = 0;
V a_236 = default;
V k_237 = default;
double h_238 = 0;
x_234 = ((-9.6) + (ToNum(Call(rnd_224, V.Undef)) * 19.2));
z_235 = ((GZ_56 - 0.08) - (ToNum(Call(rnd_224, V.Undef)) * 0.36));
a_236 = Call(gp_131, V.Undef, ((V)(x_234)), ((V)(z_235)));
k_237 = GetIdx(a_236, 2D);
h_238 = ((0.18 + (ToNum(Call(rnd_224, V.Undef)) * 0.22)) * ToNum(k_237));
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, GetIdx(a_236, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(a_236, 1D))).S("q").V(Call(r2_21, V.Undef, ((V)(((-0.03) * ToNum(k_237)))))).S(" ").V(Call(r2_21, V.Undef, ((V)(((-h_238) * 0.6))))).S(" ").V(Call(r2_21, V.Undef, ((V)((0.01 * ToNum(k_237)))))).S(" ").V(Call(r2_21, V.Undef, ((V)((-h_238))))).End()))).Put("stroke", ((V)("#3f8a34"))).Put("stroke-width", ((V)(1.2))).Put("fill", ((V)("none"))).V, sv_129);
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_21, V.Undef, Add(GetIdx(a_236, 0D), ((V)((0.01 * ToNum(k_237))))))).Put("cy", Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_236, 1D)) - h_238))))).Put("r", Call(r2_21, V.Undef, ((V)(((0.05 * ToNum(k_237)) + 0.6))))).Put("fill", GetIdx(Arr(((V)("#ff6f91")), ((V)("#ffd84a")), ((V)("#ffffff")), ((V)("#c9a0ff")), ((V)("#ff9a4a"))), (i_232 % 5D))).V, sv_129);
i_232++;
}
}
}
{
V a_239 = default;
V k_240 = default;
V X_241 = default;
V Y_242 = default;
a_239 = Call(gp_131, V.Undef, ((V)((-3.4))), ((V)((GZ_56 - 0.9))));
k_240 = GetIdx(a_239, 2D);
X_241 = Fn((V _arrowThis250, int _argc243, V v_249, V _a246, V _a247, V _a248, V[] _rest244) => {
return Call(r2_21, V.Undef, Add(GetIdx(a_239, 0D), ((V)((ToNum(v_249) * ToNum(k_240))))));
}, 1, "", true);
Y_242 = Fn((V _arrowThis258, int _argc251, V v_257, V _a254, V _a255, V _a256, V[] _rest252) => {
return Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_239, 1D)) - (ToNum(v_257) * ToNum(k_240))))));
}, 1, "", true);
Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(X_241, V.Undef, ((V)((-0.8))))).S(" ").V(Call(Y_242, V.Undef, ((V)(0D)))).S("V").V(Call(Y_242, V.Undef, ((V)(1.7)))).S("H").V(Call(X_241, V.Undef, ((V)(0.8)))).S("V").V(Call(Y_242, V.Undef, ((V)(0D)))).S("Z").End()))).Put("fill", ((V)("#b9d0e6"))).V, sv_129);
Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(X_241, V.Undef, ((V)((-0.95))))).S(" ").V(Call(Y_242, V.Undef, ((V)(1.65)))).S("L").V(Call(X_241, V.Undef, ((V)(0D)))).S(" ").V(Call(Y_242, V.Undef, ((V)(2.35)))).S("L").V(Call(X_241, V.Undef, ((V)(0.95)))).S(" ").V(Call(Y_242, V.Undef, ((V)(1.65)))).S("Z").End()))).Put("fill", ((V)("#b8604a"))).V, sv_129);
Call(S_17, V.Undef, ((V)("rect")), NewObj(7).Put("x", Call(X_241, V.Undef, ((V)((-0.32))))).Put("y", Call(Y_242, V.Undef, ((V)(1.35)))).Put("width", Call(r2_21, V.Undef, ((V)((0.64 * ToNum(k_240)))))).Put("height", Call(r2_21, V.Undef, ((V)((1.35 * ToNum(k_240)))))).Put("fill", ((V)("#8faecb"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.2))).V, sv_129);
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(X_241, V.Undef, ((V)(0.22)))).Put("cy", Call(Y_242, V.Undef, ((V)(0.7)))).Put("r", ((V)(1.3))).Put("fill", ((V)("#e6c060"))).V, sv_129);
Call(S_17, V.Undef, ((V)("rect")), NewObj(7).Put("x", Call(X_241, V.Undef, ((V)((-0.68))))).Put("y", Call(Y_242, V.Undef, ((V)(1.35)))).Put("width", Call(r2_21, V.Undef, ((V)((0.26 * ToNum(k_240)))))).Put("height", Call(r2_21, V.Undef, ((V)((0.3 * ToNum(k_240)))))).Put("fill", ((V)("#3f6a88"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1D))).V, sv_129);
}
{
V a_259 = default;
V k_260 = default;
a_259 = Call(gp_131, V.Undef, ((V)((-1.9))), ((V)((GZ_56 - 0.7))));
k_260 = GetIdx(a_259, 2D);
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, GetIdx(a_259, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(a_259, 1D))).S("V").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_259, 1D)) - (1.7 * ToNum(k_260))))))).End()))).Put("stroke", ((V)("#7a5034"))).Put("stroke-width", Call(r2_21, V.Undef, ((V)((0.06 * ToNum(k_260)))))).V, sv_129);
Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_259, 0D)) - (0.2 * ToNum(k_260))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_259, 1D)) - (1.6 * ToNum(k_260))))))).S("H").V(Call(r2_21, V.Undef, Add(GetIdx(a_259, 0D), ((V)((0.2 * ToNum(k_260))))))).S("V").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_259, 1D)) - (1.95 * ToNum(k_260))))))).S("L").V(Call(r2_21, V.Undef, GetIdx(a_259, 0D))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_259, 1D)) - (2.15 * ToNum(k_260))))))).S("L").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_259, 0D)) - (0.2 * ToNum(k_260))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_259, 1D)) - (1.95 * ToNum(k_260))))))).S("Z").End()))).Put("fill", ((V)("#e8956a"))).V, sv_129);
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_21, V.Undef, GetIdx(a_259, 0D))).Put("cy", Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_259, 1D)) - (1.82 * ToNum(k_260))))))).Put("r", Call(r2_21, V.Undef, ((V)((0.05 * ToNum(k_260)))))).Put("fill", ((V)("#3a2a20"))).V, sv_129);
}
{
V a_261 = default;
V k_262 = default;
a_261 = Call(gp_131, V.Undef, ((V)(2.6)), ((V)((GZ_56 - 1D))));
k_262 = GetIdx(a_261, 2D);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 0D)) - (0.3 * ToNum(k_262))))))).Put("cy", Call(r2_21, V.Undef, GetIdx(a_261, 1D))).Put("rx", Call(r2_21, V.Undef, ((V)((1D * ToNum(k_262)))))).Put("ry", Call(r2_21, V.Undef, ((V)((0.2 * ToNum(k_262)))))).Put("fill", ((V)("#2a4a20"))).Put("opacity", ((V)(0.22))).V, sv_129);
Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 0D)) - (0.14 * ToNum(k_262))))))).S(" ").V(Call(r2_21, V.Undef, GetIdx(a_261, 1D))).S("L").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 0D)) - (0.08 * ToNum(k_262))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 1D)) - (2.2 * ToNum(k_262))))))).S("L").V(Call(r2_21, V.Undef, Add(GetIdx(a_261, 0D), ((V)((0.08 * ToNum(k_262))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 1D)) - (2.2 * ToNum(k_262))))))).S("L").V(Call(r2_21, V.Undef, Add(GetIdx(a_261, 0D), ((V)((0.14 * ToNum(k_262))))))).S(" ").V(Call(r2_21, V.Undef, GetIdx(a_261, 1D))).S("Z").End()))).Put("fill", ((V)("#7a5034"))).V, sv_129);
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, GetIdx(a_261, 0D))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 1D)) - (1.9 * ToNum(k_262))))))).S("L").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 0D)) - (0.9 * ToNum(k_262))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 1D)) - (2D * ToNum(k_262))))))).End()))).Put("stroke", ((V)("#7a5034"))).Put("stroke-width", Call(r2_21, V.Undef, ((V)((0.08 * ToNum(k_262)))))).V, sv_129);
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 0D)) - (0.7 * ToNum(k_262))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 1D)) - (1.98 * ToNum(k_262))))))).S("V").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 1D)) - (0.75 * ToNum(k_262))))))).End()))).Put("stroke", ((V)("#5a5a5a"))).Put("stroke-width", ((V)(1D))).V, sv_129);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(7).Put("cx", Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 0D)) - (0.7 * ToNum(k_262))))))).Put("cy", Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_261, 1D)) - (0.6 * ToNum(k_262))))))).Put("rx", Call(r2_21, V.Undef, ((V)((0.22 * ToNum(k_262)))))).Put("ry", Call(r2_21, V.Undef, ((V)((0.16 * ToNum(k_262)))))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#2a2a32"))).Put("stroke-width", Call(r2_21, V.Undef, ((V)((0.08 * ToNum(k_262)))))).V, sv_129);
Invoke(Arr(Arr(((V)((-0.6))), ((V)((-2.5))), ((V)(0.8)), ((V)("#4f9a3e"))), Arr(((V)(0.55)), ((V)((-2.4))), ((V)(0.75)), ((V)("#4f9a3e"))), Arr(((V)(0D)), ((V)((-3D))), ((V)(0.9)), ((V)("#5aa84a"))), Arr(((V)((-0.3))), ((V)((-3.5))), ((V)(0.6)), ((V)("#66b456"))), Arr(((V)(0.4)), ((V)((-3.4))), ((V)(0.55)), ((V)("#66b456")))), "forEach", Fn((V _arrowThis278, int _argc263, V _a265, V _a266, V _a267, V _a268, V[] _rest264) => {
V dx_271 = default;
V dy_273 = default;
V r_275 = default;
V c_277 = default;
{ V _t269 = ListOf(_a265);
{ V _t270 = GetIdx(_t269, 0D);
dx_271 = _t270; }
{ V _t272 = GetIdx(_t269, 1D);
dy_273 = _t272; }
{ V _t274 = GetIdx(_t269, 2D);
r_275 = _t274; }
{ V _t276 = GetIdx(_t269, 3D);
c_277 = _t276; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_21, V.Undef, Add(GetIdx(a_261, 0D), ((V)((ToNum(dx_271) * ToNum(k_262))))))).Put("cy", Call(r2_21, V.Undef, Add(GetIdx(a_261, 1D), ((V)((ToNum(dy_273) * ToNum(k_262))))))).Put("r", Call(r2_21, V.Undef, ((V)((ToNum(r_275) * ToNum(k_262)))))).Put("fill", c_277).V, sv_129);
}, 1, "", true));
}
{
double sd_279 = 0;
V rnd_280 = default;
sd_279 = 9D;
rnd_280 = Fn((V _arrowThis287, int _argc281, V _a283, V _a284, V _a285, V _a286, V[] _rest282) => {
return ((V)(((sd_279 = (((sd_279 * 9301D) + 49297D) % 233280D)) / 233280D)));
}, 0, "", true);
{
double i_288 = 0;
i_288 = 0D;
while (true) {
if (!((i_288 < 150D))) break;
double x_290 = 0;
double z_291 = 0;
V a_292 = default;
double k_293 = 0;
x_290 = ((-6.5) + (ToNum(Call(rnd_280, V.Undef)) * 13D));
z_291 = ((-0.6) + (ToNum(Call(rnd_280, V.Undef)) * (GZ_56 - 1D)));
a_292 = Call(gp_131, V.Undef, ((V)(x_290)), ((V)(z_291)));
k_293 = (ToNum(GetIdx(a_292, 2D)) / 100D);
if ((((System.Math.Abs(x_290) < 1.45) && (z_291 > (-0.05))) && (z_291 < 3.75))) {
goto _cont289;
}
if (NumTruthy((i_288 % 6D))) {
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_292, 0D)) - (3D * k_293)))))).S(" ").V(Call(r2_21, V.Undef, GetIdx(a_292, 1D))).S("q").V(Call(r2_21, V.Undef, ((V)(k_293)))).S(" ").V(Call(r2_21, V.Undef, ((V)(((-6D) * k_293))))).S(" ").V(Call(r2_21, V.Undef, ((V)((2D * k_293))))).S(" ").V(Call(r2_21, V.Undef, ((V)(((-8D) * k_293))))).S("q").V(Call(r2_21, V.Undef, ((V)((0.5 * k_293))))).S(" ").V(Call(r2_21, V.Undef, ((V)((5D * k_293))))).S(" ").V(Call(r2_21, V.Undef, ((V)((1.6 * k_293))))).S(" ").V(Call(r2_21, V.Undef, ((V)((8D * k_293))))).S("q").V(Call(r2_21, V.Undef, ((V)(k_293)))).S(" ").V(Call(r2_21, V.Undef, ((V)(((-5D) * k_293))))).S(" ").V(Call(r2_21, V.Undef, ((V)((3D * k_293))))).S(" ").V(Call(r2_21, V.Undef, ((V)(((-7D) * k_293))))).S("q").V(Call(r2_21, V.Undef, ((V)(((-0.6) * k_293))))).S(" ").V(Call(r2_21, V.Undef, ((V)((5D * k_293))))).S(" ").V(Call(r2_21, V.Undef, ((V)((0.4 * k_293))))).S(" ").V(Call(r2_21, V.Undef, ((V)((7D * k_293))))).S("Z").End()))).Put("fill", ((V)("#3f8a34"))).Put("opacity", ((V)(0.6))).V, sv_129);
} else {
{
double j_294 = 0;
j_294 = 0D;
while (true) {
if (!((j_294 < 5D))) break;
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_21, V.Undef, Add(GetIdx(a_292, 0D), ((V)(((FdLibm.Cos((j_294 * 1.2566)) * 2.4) * k_293)))))).Put("cy", Call(r2_21, V.Undef, Add(GetIdx(a_292, 1D), ((V)(((FdLibm.Sin((j_294 * 1.2566)) * 1.4) * k_293)))))).Put("r", Call(r2_21, V.Undef, ((V)((1.8 * k_293))))).Put("fill", ((V)("#ffffff"))).V, sv_129);
j_294++;
}
}
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_21, V.Undef, GetIdx(a_292, 0D))).Put("cy", Call(r2_21, V.Undef, GetIdx(a_292, 1D))).Put("r", Call(r2_21, V.Undef, ((V)((1.2 * k_293))))).Put("fill", ((V)("#ffc93a"))).V, sv_129);
}
_cont289: ;
i_288++;
}
}
}
Call(quad_69, V.Undef, Arr(Arr(((V)((-1.45))), ((V)(0.001)), ((V)((-0.05)))), Arr(((V)(1.45)), ((V)(0.001)), ((V)((-0.05)))), Arr(((V)(1.45)), ((V)(0.001)), ((V)(3.75))), Arr(((V)((-1.45))), ((V)(0.001)), ((V)(3.75)))), NewObj(1).Put("fill", ((V)("url(#ppStone)"))).V, sv_129);
Call(S_17, V.Undef, ((V)("rect")), NewObj(8).Put("x", ((V)((-160D)))).Put("y", ((V)(150D))).Put("width", Add(W_43, ((V)(320D)))).Put("height", ((V)((ToNum(H_44) - 150D)))).Put("fill", ((V)("#ffffff"))).Put("filter", ((V)("url(#ppGrain)"))).Put("clip-path", ((V)("url(#ppPatioC)"))).Put("opacity", ((V)(0.8))).V, sv_129);
{
V cp_296 = default;
cp_296 = Call(S_17, V.Undef, ((V)("clipPath")), NewObj(1).Put("id", ((V)("ppPatioC"))).V, Invoke(sv_129, "querySelector", ((V)("defs"))));
Call(quad_69, V.Undef, Arr(Arr(((V)((-1.45))), ((V)(0D)), ((V)((-0.05)))), Arr(((V)(1.45)), ((V)(0D)), ((V)((-0.05)))), Arr(((V)(1.45)), ((V)(0D)), ((V)(3.75))), Arr(((V)((-1.45))), ((V)(0D)), ((V)(3.75)))), NewObj(0).V, cp_296);
}
{
V g_297 = default;
g_297 = Call(S_17, V.Undef, ((V)("g")), NewObj(3).Put("stroke", ((V)("#9c917f"))).Put("stroke-width", ((V)(1.1))).Put("opacity", ((V)(0.85))).V, sv_129);
{
double z_298 = 0;
double r_299 = 0;
z_298 = (-0.05);
r_299 = 0D;
while (true) {
if (!((z_298 < 3.75))) break;
Call(line_70, V.Undef, Arr(Arr(((V)((-1.45))), ((V)(0.002)), ((V)(z_298))), Arr(((V)(1.45)), ((V)(0.002)), ((V)(z_298)))), NewObj(0).V, g_297);
{
double x_301 = 0;
x_301 = ((-1.45) + (NumTruthy((r_299 % 2D)) ? 0.3 : 0D));
while (true) {
if (!((x_301 < 1.45))) break;
Call(line_70, V.Undef, Arr(Arr(((V)(x_301)), ((V)(0.002)), ((V)(z_298))), Arr(((V)(x_301)), ((V)(0.002)), ((V)(Min(3.75, (z_298 + 0.42)))))), NewObj(0).V, g_297);
x_301 = (x_301 + 0.6);
}
}
z_298 = (z_298 + 0.42);
r_299++;
}
}
}
Invoke(Arr(Arr(((V)((-1.2))), ((V)(0.5))), Arr(((V)(0.9)), ((V)(2.9))), Arr(((V)((-0.3))), ((V)(3.4))), Arr(((V)(1.25)), ((V)(1.2)))), "forEach", Fn((V _arrowThis314, int _argc303, V _a305, V _a306, V _a307, V _a308, V[] _rest304) => {
V a_315 = default;
V k_316 = default;
V x_311 = default;
V z_313 = default;
{ V _t309 = ListOf(_a305);
{ V _t310 = GetIdx(_t309, 0D);
x_311 = _t310; }
{ V _t312 = GetIdx(_t309, 1D);
z_313 = _t312; }
}
a_315 = Call(gp_131, V.Undef, x_311, z_313);
k_316 = GetIdx(a_315, 2D);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_21, V.Undef, GetIdx(a_315, 0D))).Put("cy", Call(r2_21, V.Undef, GetIdx(a_315, 1D))).Put("rx", Call(r2_21, V.Undef, ((V)((0.12 * ToNum(k_316)))))).Put("ry", Call(r2_21, V.Undef, ((V)((0.03 * ToNum(k_316)))))).Put("fill", ((V)("#6f9a4a"))).Put("opacity", ((V)(0.5))).V, sv_129);
return default;
}, 1, "", true));
Call(quad_69, V.Undef, Arr(Arr(((V)((-1.5))), ((V)(0.003)), ((V)((-0.1)))), Arr(((V)(1.5)), ((V)(0.003)), ((V)((-0.1)))), Arr(((V)(1.5)), ((V)(0.003)), ((V)((-0.02)))), Arr(((V)((-1.5))), ((V)(0.003)), ((V)((-0.02))))), NewObj(1).Put("fill", ((V)("#a89e8c"))).V, sv_129);
Call(quad_69, V.Undef, Arr(Arr(((V)((-1.5))), ((V)(0.003)), ((V)(3.72))), Arr(((V)(1.5)), ((V)(0.003)), ((V)(3.72))), Arr(((V)(1.5)), ((V)(0.003)), ((V)(3.8))), Arr(((V)((-1.5))), ((V)(0.003)), ((V)(3.8)))), NewObj(1).Put("fill", ((V)("#a89e8c"))).V, sv_129);
Call(quad_69, V.Undef, Arr(Arr(((V)(((-TW_47) + 0D))), ((V)(0.004)), ((V)((Z0_48 + 0.35)))), Arr(((V)((TW_47 + 0.25))), ((V)(0.004)), ((V)((Z0_48 + 0.35)))), Arr(((V)((TW_47 + 0.45))), ((V)(0.004)), ((V)((Z1_49 - 0.1)))), Arr(((V)(((-TW_47) + 0.2))), ((V)(0.004)), ((V)((Z1_49 - 0.1))))), NewObj(2).Put("fill", ((V)("#2a2018"))).Put("opacity", ((V)(0.22))).V, sv_129);
Invoke(Arr(Arr(((V)((-1.3))), ((V)(3.55))), Arr(((V)(1.3)), ((V)(3.55)))), "forEach", Fn((V _arrowThis328, int _argc317, V _a319, V _a320, V _a321, V _a322, V[] _rest318) => {
V a_329 = default;
V k_330 = default;
V x_325 = default;
V z_327 = default;
{ V _t323 = ListOf(_a319);
{ V _t324 = GetIdx(_t323, 0D);
x_325 = _t324; }
{ V _t326 = GetIdx(_t323, 1D);
z_327 = _t326; }
}
a_329 = Call(gp_131, V.Undef, x_325, z_327);
k_330 = GetIdx(a_329, 2D);
Call(S_17, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_329, 0D)) - (0.17 * ToNum(k_330))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_329, 1D)) - (0.36 * ToNum(k_330))))))).S("H").V(Call(r2_21, V.Undef, Add(GetIdx(a_329, 0D), ((V)((0.17 * ToNum(k_330))))))).S("L").V(Call(r2_21, V.Undef, Add(GetIdx(a_329, 0D), ((V)((0.13 * ToNum(k_330))))))).S(" ").V(Call(r2_21, V.Undef, GetIdx(a_329, 1D))).S("H").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_329, 0D)) - (0.13 * ToNum(k_330))))))).S("Z").End()))).Put("fill", ((V)("#c96a44"))).V, sv_129);
Invoke(Arr(Arr(((V)((-0.12))), ((V)((-0.5))), ((V)(0.14))), Arr(((V)(0.1)), ((V)((-0.54))), ((V)(0.15))), Arr(((V)(0D)), ((V)((-0.66))), ((V)(0.15))), Arr(((V)((-0.04))), ((V)((-0.4))), ((V)(0.12)))), "forEach", Fn((V _arrowThis345, int _argc331, V _a333, V i_337, V _a335, V _a336, V[] _rest332) => {
V dx_340 = default;
V dy_342 = default;
V r_344 = default;
{ V _t338 = ListOf(_a333);
{ V _t339 = GetIdx(_t338, 0D);
dx_340 = _t339; }
{ V _t341 = GetIdx(_t338, 1D);
dy_342 = _t341; }
{ V _t343 = GetIdx(_t338, 2D);
r_344 = _t343; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_21, V.Undef, Add(GetIdx(a_329, 0D), ((V)((ToNum(dx_340) * ToNum(k_330))))))).Put("cy", Call(r2_21, V.Undef, Add(GetIdx(a_329, 1D), ((V)((ToNum(dy_342) * ToNum(k_330))))))).Put("r", Call(r2_21, V.Undef, ((V)((ToNum(r_344) * ToNum(k_330)))))).Put("fill", ((V)((NumTruthy((ToNum(i_337) % 2D)) ? "#4f9a3e" : "#5aa84a")))).V, sv_129);
}, 2, "", true));
Invoke(Arr(Arr(((V)((-0.1))), ((V)((-0.58)))), Arr(((V)(0.09)), ((V)((-0.62)))), Arr(((V)(0.02)), ((V)((-0.46))))), "forEach", Fn((V _arrowThis358, int _argc346, V _a348, V i_352, V _a350, V _a351, V[] _rest347) => {
V dx_355 = default;
V dy_357 = default;
{ V _t353 = ListOf(_a348);
{ V _t354 = GetIdx(_t353, 0D);
dx_355 = _t354; }
{ V _t356 = GetIdx(_t353, 1D);
dy_357 = _t356; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_21, V.Undef, Add(GetIdx(a_329, 0D), ((V)((ToNum(dx_355) * ToNum(k_330))))))).Put("cy", Call(r2_21, V.Undef, Add(GetIdx(a_329, 1D), ((V)((ToNum(dy_357) * ToNum(k_330))))))).Put("r", Call(r2_21, V.Undef, ((V)(((0.04 * ToNum(k_330)) + 0.4))))).Put("fill", GetK(Arr(((V)("#ff6f91")), ((V)("#ffd84a")), ((V)("#ffffff"))), i_352)).V, sv_129);
}, 2, "", true));
return default;
}, 1, "", true));
{
V a_359 = default;
V k_360 = default;
a_359 = Call(gp_131, V.Undef, ((V)(1.75)), ((V)(2.4)));
k_360 = GetIdx(a_359, 2D);
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_359, 0D)) - (0.13 * ToNum(k_360))))))).S(" ").V(Call(r2_21, V.Undef, GetIdx(a_359, 1D))).S("V").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_359, 1D)) - (0.22 * ToNum(k_360))))))).S("H").V(Call(r2_21, V.Undef, Add(GetIdx(a_359, 0D), ((V)((0.13 * ToNum(k_360))))))).S("V").V(Call(r2_21, V.Undef, GetIdx(a_359, 1D))).S("Z").End()))).Put("fill", ((V)("#4fa8e8"))).Put("stroke", ((V)("#2f78b8"))).Put("stroke-width", ((V)(0.8))).V, sv_129);
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, Add(GetIdx(a_359, 0D), ((V)((0.13 * ToNum(k_360))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_359, 1D)) - (0.18 * ToNum(k_360))))))).S("L").V(Call(r2_21, V.Undef, Add(GetIdx(a_359, 0D), ((V)((0.3 * ToNum(k_360))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_359, 1D)) - (0.32 * ToNum(k_360))))))).End()))).Put("stroke", ((V)("#2f78b8"))).Put("stroke-width", Call(r2_21, V.Undef, ((V)((0.03 * ToNum(k_360)))))).V, sv_129);
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_359, 0D)) - (0.08 * ToNum(k_360))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_359, 1D)) - (0.22 * ToNum(k_360))))))).S("Q").V(Call(r2_21, V.Undef, GetIdx(a_359, 0D))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_359, 1D)) - (0.36 * ToNum(k_360))))))).S(" ").V(Call(r2_21, V.Undef, Add(GetIdx(a_359, 0D), ((V)((0.08 * ToNum(k_360))))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(a_359, 1D)) - (0.22 * ToNum(k_360))))))).End()))).Put("stroke", ((V)("#2f78b8"))).Put("stroke-width", ((V)(1D))).Put("fill", ((V)("none"))).V, sv_129);
}
Call(S_17, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-160D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_43, ((V)(320D)))).Put("height", Add(H_44, ((V)(40D)))).Put("fill", ((V)("url(#ppSun)"))).V, sv_129);
return default;
}, 1, "drawScene", false);
newBall_114 = Fn((V _self361, int _argc362, V who_368, V _a365, V _a366, V _a367, V[] _rest363) => {
if (_self361.IsNullish) _self361 = GlobalV;
b_97 = NewObj(8).Put("x", (Truthy(who_368) ? ox_94 : ((V)((px_91 + 0.04))))).Put("y", ((V)((TY_51 + 0.3)))).Put("z", ((V)((Truthy(who_368) ? (ZO_55 - 0.02) : (ZP_54 + 0.02))))).Put("vx", ((V)(0D))).Put("vy", ((V)(0D))).Put("vz", ((V)(0D))).Put("bounces", ((V)(0D))).Put("side", ((V)((-1D)))).V;
phase_103.Set("serve");
ph0_104 = tNow_105;
serve_101 = who_368;
if (!(Truthy(who_368))) {
Invoke(ctx_40, "hint", ((V)("Tap to serve \u00b7 slide to move")));
}
return default;
}, 1, "newBall", false);
send_115 = Fn((V _self369, int _argc370, V from_376, V lx_377, V lz_378, V _a375, V[] _rest371) => {
double T_379 = 0;
double tn_380 = 0;
if (_self369.IsNullish) _self369 = GlobalV;
T_379 = (Max(0.34, (0.6 - (rally_99 * 0.012))) * (Truthy(from_376) ? 1.05 : 1D));
Set(b_97, "vx", ((V)(((ToNum(lx_377) - ToNum(Get(b_97, "x"))) / T_379))));
Set(b_97, "vz", ((V)(((ToNum(lz_378) - ToNum(Get(b_97, "z"))) / T_379))));
Set(b_97, "vy", ((V)(((((TY_51 + BR_53) - ToNum(Get(b_97, "y"))) + (((0.5 * G_46) * T_379) * T_379)) / T_379))));
tn_380 = ((ZN_50 - ToNum(Get(b_97, "z"))) / ToNum(Get(b_97, "vz")));
if (((tn_380 > 0D) && (tn_380 < T_379))) {
double yn_381 = 0;
yn_381 = (ToNum(Add(Get(b_97, "y"), ((V)((ToNum(Get(b_97, "vy")) * tn_380))))) - (((0.5 * G_46) * tn_380) * tn_380));
if ((yn_381 < (((TY_51 + NH_52) + BR_53) + 0.03))) {
OpSet(b_97, "vy", 0, ((V)((((((TY_51 + NH_52) + BR_53) + 0.05) - yn_381) / tn_380))));
}
}
Set(b_97, "bounces", ((V)(0D)));
Set(b_97, "side", from_376);
lastHit_108 = from_376;
return default;
}, 3, "send", false);
hitByMe_116 = Fn((V _self382, int _argc383, V _a385, V _a386, V _a387, V _a388, V[] _rest384) => {
double off_389 = 0;
V lx_390 = default;
double lz_391 = 0;
V s_392 = default;
if (_self382.IsNullish) _self382 = GlobalV;
off_389 = ((ToNum(Get(b_97, "x")) - px_91) / 0.11);
lx_390 = Call(cl_19, V.Undef, Add(Add(Add(Get(b_97, "x"), ((V)((off_389 * 0.35)))), ((V)((pv_93 * 0.18)))), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.06)))), ((V)(((-TW_47) + 0.06))), ((V)((TW_47 - 0.06))));
lz_391 = (2.25 + (ToNum(Invoke(G("Math"), "random")) * 0.5));
Call(send_115, V.Undef, ((V)(0D)), lx_390, ((V)(lz_391)));
rally_99++;
if (((ToNum(tNow_105) - ToNum(swingP_106)) > 250D)) {
swingP_106 = tNow_105;
}
Invoke(SFX_23, "pop");
s_392 = Call(P_45, V.Undef, Get(b_97, "x"), Get(b_97, "y"), Get(b_97, "z"));
Invoke(ctx_40, "burst", GetIdx(s_392, 0D), GetIdx(s_392, 1D), ((V)("spark")), ((V)(5D)), NewObj(2).Put("v", ((V)(70D))).Put("life", ((V)(0.35))).V);
if (((rally_99 > 1D) && ((rally_99 % 5D) == 0D))) {
Invoke(ctx_40, "toast", ((V)(JsStrBuf.Begin().S("Rally ").N(rally_99).S("!").End())), ((V)((ToNum(W_43) / 2D))), ((V)((ToNum(H_44) * 0.3))), ((V)("#ffe36e")));
}
return default;
}, 0, "hitByMe", false);
hitByOpp_117 = Fn((V _self393, int _argc394, V _a396, V _a397, V _a398, V _a399, V[] _rest395) => {
double away_400 = 0;
double aim_401 = 0;
if (_self393.IsNullish) _self393 = GlobalV;
away_400 = ((System.Math.Abs(px_91) < 0.25) ? (LtN(Invoke(G("Math"), "random"), 0.5) ? (-1D) : 1D) : (-Sign(px_91)));
aim_401 = (LtN(Invoke(G("Math"), "random"), (ToNum(skill_109) * 0.6)) ? (away_400 * (0.3 + (ToNum(Invoke(G("Math"), "random")) * 0.25))) : ((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.7));
Call(send_115, V.Undef, ((V)(1D)), Call(cl_19, V.Undef, ((V)(aim_401)), ((V)(((-TW_47) + 0.08))), ((V)((TW_47 - 0.08)))), ((V)((0.8 + (ToNum(Invoke(G("Math"), "random")) * 0.55)))));
rally_99++;
if (((ToNum(tNow_105) - ToNum(swingO_107)) > 250D)) {
swingO_107 = tNow_105;
}
Invoke(SFX_23, "tap");
return default;
}, 0, "hitByOpp", false);
point_118 = Fn((V _self402, int _argc403, V win_409, V why_410, V _a407, V _a408, V[] _rest404) => {
if (_self402.IsNullish) _self402 = GlobalV;
if (string.Equals(phase_103.Str, "point")) {
return default;
}
phase_103.Set("point");
ph0_104 = tNow_105;
IncK(pts_98, ((V)((Truthy(win_409) ? 0D : 1D))), 1D, false);
best_100 = Max(best_100, rally_99);
Call(say_113, V.Undef);
if (Truthy(win_409)) {
Invoke(ctx_40, "add", ((V)(10D)), ((V)((ToNum(W_43) / 2D))), ((V)((ToNum(H_44) * 0.42))), (why_410 is var _t411 && Truthy(_t411) ? _t411 : ((V)("Point!"))), ((V)("#ffe36e")));
Invoke(SFX_23, "score");
Invoke(me_84, "play", ((V)("happy")));
Invoke(opp_83, "play", ((V)("surprised")));
} else {
Invoke(ctx_40, "toast", (why_410 is var _t412 && Truthy(_t412) ? _t412 : ((V)(JsStrBuf.Begin().S("Point ").V(okName_82).End()))), ((V)((ToNum(W_43) / 2D))), ((V)((ToNum(H_44) * 0.42))), ((V)("#ffffff")));
Invoke(SFX_23, "miss");
Invoke(opp_83, "play", ((V)("happy")));
}
rally_99 = 0D;
skill_109 = Call(cl_19, V.Undef, ((V)(((0.5 + ((ToNum(GetIdx(pts_98, 0D)) - ToNum(GetIdx(pts_98, 1D))) * 0.06)) + (ToNum(Add(GetIdx(pts_98, 0D), GetIdx(pts_98, 1D))) * 0.015)))), ((V)(0.4)), ((V)(0.85)));
return default;
}, 2, "point", false);
swingPose_119 = Fn((V _self413, int _argc414, V wind_420, V since_421, V q_422, V _a419, V[] _rest415) => {
V R_423 = default;
V Bk_424 = default;
V Ht_425 = default;
V mix_426 = default;
V p_427 = default;
if (_self413.IsNullish) _self413 = GlobalV;
R_423 = NewObj(9).Put("a", ((V)(92D))).Put("hx", ((V)(2D))).Put("hy", ((V)(0D))).Put("hz", ((V)(0D))).Put("lean", ((V)(0.2))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.03))).Put("yaw", ((V)(0D))).Put("rot", ((V)(10D))).V;
Bk_424 = NewObj(9).Put("a", ((V)(80D))).Put("hx", ((V)(7D))).Put("hy", ((V)(2D))).Put("hz", ((V)((-9D)))).Put("lean", ((V)((-0.4)))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("yaw", ((V)(14D))).Put("rot", ((V)(35D))).V;
Ht_425 = NewObj(9).Put("a", ((V)(96D))).Put("hx", ((V)((-2D)))).Put("hy", ((V)((-1D)))).Put("hz", ((V)(11D))).Put("lean", ((V)(0.9))).Put("lift", ((V)(0.6))).Put("sq", ((V)((-0.02)))).Put("yaw", ((V)((-18D)))).Put("rot", ((V)((-5D)))).V;
mix_426 = Fn((V _arrowThis437, int _argc428, V A_434, V B2_435, V u_436, V _a433, V[] _rest429) => {
V o_438 = default;
o_438 = NewObj(0).V;
{
foreach (V _k439 in ForInKeys(A_434)) {
V k_440 = default;
k_440 = _k439;
SetK(o_438, k_440, Call(lerp_20, V.Undef, GetK(A_434, k_440), GetK(B2_435, k_440), u_436));
}
}
return o_438;
return default;
}, 3, "", true);
p_427 = Call(mix_426, V.Undef, R_423, Bk_424, Call(SM_57, V.Undef, wind_420));
if ((GeN(since_421, 0D) && LtN(since_421, 560D))) {
if (LtN(since_421, 110D)) {
p_427 = Call(mix_426, V.Undef, p_427, Ht_425, Call(eo_58, V.Undef, ((V)((ToNum(since_421) / 110D)))));
} else {
if (LtN(since_421, 260D)) {
p_427 = Ht_425;
} else {
p_427 = Call(mix_426, V.Undef, Ht_425, R_423, Call(SM_57, V.Undef, ((V)(((ToNum(since_421) - 260D) / 300D)))));
}
}
}
return p_427;
return default;
}, 3, "swingPose", false);
poseCreature_120 = Fn((V _self441, int _argc442, V c_448, V Q_449, V p_450, V run_451, V[] _rest443) => {
V E_456 = default;
V dt_452 = default;
V spin_453 = default;
V yaw0_454 = default;
V extra_455 = default;
if (_self441.IsNullish) _self441 = GlobalV;
dt_452 = (_argc442 > 4 ? _rest443[0] : V.Undef);
spin_453 = (_argc442 > 5 ? _rest443[1] : V.Undef);
yaw0_454 = (_argc442 > 6 ? _rest443[2] : V.Undef);
extra_455 = (_argc442 > 7 ? _rest443[3] : V.Undef);
E_456 = Object_assign(NewObj(3).Put("lean", Get(p_450, "lean")).Put("lift", Get(p_450, "lift")).Put("sq", Get(p_450, "sq")).V, (extra_455 is var _t457 && Truthy(_t457) ? _t457 : NewObj(0).V));
SetK(E_456, Get(Q_449, "arm"), Get(p_450, "a"));
SetK(E_456, ((V)((GtN(Get(Q_449, "side"), 0D) ? "hLx" : "hRx"))), (GtN(Get(Q_449, "side"), 0D) ? Get(p_450, "hx") : ((V)((-ToNum(Get(p_450, "hx")))))));
SetK(E_456, ((V)((GtN(Get(Q_449, "side"), 0D) ? "hLy" : "hRy"))), Get(p_450, "hy"));
SetK(E_456, ((V)((GtN(Get(Q_449, "side"), 0D) ? "hLz" : "hRz"))), Get(p_450, "hz"));
Invoke(c_448, "pose", E_456);
Set(Get(Q_449, "ws"), "run", ((V)((GtN(run_451, 0.55) ? 1D : 0D))));
if (Truthy((Get(G("window"), "HouseWalk") is var _t458 && !Truthy(_t458) ? _t458 : (GtN(run_451, 0.02) ? V.True : V.False)))) {
try {
Invoke(Get(G("window"), "HouseWalk"), "step", Get(c_448, "key"), Get(Q_449, "ws"), Get(c_448, "E"), ((V)(Min(1D, (ToNum(run_451) * 1.3)))), dt_452, ((V)((0.7 + (ToNum(run_451) * 1.6)))), spin_453);
} catch (System.Exception _ex459) {
V e_460 = default;
e_460 = Caught(_ex459);

}
}
Invoke(c_448, "yaw", Add(yaw0_454, ((V)((ToNum(Get(p_450, "yaw")) * ToNum(Get(Q_449, "side")))))));
Set(Q_449, "rot", ((V)(((GtN(Get(Q_449, "side"), 0D) ? (-25D) : 20D) + (ToNum(Get(p_450, "rot")) * ToNum(Get(Q_449, "side")))))));
return default;
}, 8, "poseCreature", false);
{ V _t461 = ctx_40;
if (_t461.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t461));
{ V _t462 = Get(_t461, "bg");
bg_41 = _t462; }
{ V _t463 = Get(_t461, "fg");
fg_42 = _t463; }
{ V _t464 = Get(_t461, "W");
W_43 = _t464; }
{ V _t465 = Get(_t461, "H");
H_44 = _t465; } }
P_45 = Invoke(YG_16, "cam", ((V)(2D)), ((V)(2.32)), ((V)(14D)), ((V)(262D)));
G_46 = 8.2;
TW_47 = 0.6;
Z0_48 = 0.55;
Z1_49 = 2.95;
ZN_50 = 1.75;
TY_51 = 0.76;
NH_52 = 0.13;
BR_53 = 0.022;
ZP_54 = 0.45;
ZO_55 = 3.06;
GZ_56 = 7D;
SM_57 = Get(YG_16, "SM");
eo_58 = Fn((V _arrowThis473, int _argc466, V u_472, V _a469, V _a470, V _a471, V[] _rest467) => {
return ((V)((1D - ((1D - ToNum(u_472)) * (1D - ToNum(u_472))))));
}, 1, "", true);
stage_59 = Get(Get(ctx_40, "crl"), "parentNode");
PAN0_60 = 0D;
PANK_61 = 0D;
KP_62 = GetIdx(Call(P_45, V.Undef, ((V)(0D)), ((V)(TY_51)), ((V)(ZP_54))), 2D);
PXM_63 = (TW_47 + 0.04);
fingerToPx_64 = Fn((V _arrowThis481, int _argc474, V x_480, V _a477, V _a478, V _a479, V[] _rest475) => {
return Call(cl_19, V.Undef, ((V)((((ToNum(x_480) - (ToNum(W_43) / 2D)) - PAN0_60) / (ToNum(KP_62) - PANK_61)))), ((V)((-PXM_63))), ((V)(PXM_63)));
}, 1, "", true);
svgL_65 = Fn((V _arrowThis488, int _argc482, V _a484, V _a485, V _a486, V _a487, V[] _rest483) => {
V e_489 = default;
e_489 = Invoke(G("document"), "createElementNS", ((V)("http://www.w3.org/2000/svg")), ((V)("svg")));
Invoke(e_489, "setAttribute", ((V)("viewBox")), ((V)(JsStrBuf.Begin().S("0 0 ").V(W_43).S(" ").V(H_44).End())));
Invoke(e_489, "setAttribute", ((V)("class")), ((V)("yg-layer")));
Invoke(e_489, "setAttribute", ((V)("preserveAspectRatio")), ((V)("none")));
Set(Get(e_489, "style"), "overflow", ((V)("visible")));
return e_489;
return default;
}, 0, "", true);
scene_66 = Call(svgL_65, V.Undef);
Invoke(stage_59, "insertBefore", scene_66, bg_41);
oppL_67 = Call(D_18, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-layer yg-crl"))).V);
tbl_68 = Call(svgL_65, V.Undef);
Invoke(stage_59, "insertBefore", oppL_67, Get(ctx_40, "crl"));
Invoke(stage_59, "insertBefore", tbl_68, Get(ctx_40, "crl"));
quad_69 = Fn((V _arrowThis499, int _argc490, V pts_496, V a_497, V p_498, V _a495, V[] _rest491) => {
return Call(S_17, V.Undef, ((V)("path")), Object_assign(NewObj(1).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_496, "map", Fn((V _arrowThis507, int _argc500, V q_506, V _a503, V _a504, V _a505, V[] _rest501) => {
V s_508 = default;
s_508 = Call(P_45, V.Undef, GetIdx(q_506, 0D), GetIdx(q_506, 1D), GetIdx(q_506, 2D));
return ((V)(JsStrBuf.Begin().V(Call(r2_21, V.Undef, GetIdx(s_508, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(s_508, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).V, a_497), p_498);
}, 3, "", true);
line_70 = Fn((V _arrowThis518, int _argc509, V pts_515, V a_516, V p_517, V _a514, V[] _rest510) => {
return Call(S_17, V.Undef, ((V)("path")), Object_assign(NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_515, "map", Fn((V _arrowThis526, int _argc519, V q_525, V _a522, V _a523, V _a524, V[] _rest520) => {
V s_527 = default;
s_527 = Call(P_45, V.Undef, GetIdx(q_525, 0D), GetIdx(q_525, 1D), GetIdx(q_525, 2D));
return ((V)(JsStrBuf.Begin().V(Call(r2_21, V.Undef, GetIdx(s_527, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(s_527, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()))).Put("fill", ((V)("none"))).V, a_516), p_517);
}, 3, "", true);
Call(drawScene_71, V.Undef, scene_66);
{
V g0_528 = default;
V ln_529 = default;
g0_528 = Call(P_45, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(((Z0_48 + Z1_49) / 2D))));
Invoke(Arr(Arr(((V)(((-TW_47) + 0.08))), ((V)((Z1_49 - 0.15)))), Arr(((V)((TW_47 - 0.08))), ((V)((Z1_49 - 0.15))))), "forEach", Fn((V _arrowThis541, int _argc530, V _a532, V _a533, V _a534, V _a535, V[] _rest531) => {
V a_542 = default;
V b2_543 = default;
V w_544 = default;
V x_538 = default;
V z_540 = default;
{ V _t536 = ListOf(_a532);
{ V _t537 = GetIdx(_t536, 0D);
x_538 = _t537; }
{ V _t539 = GetIdx(_t536, 1D);
z_540 = _t539; }
}
a_542 = Call(P_45, V.Undef, x_538, ((V)(0.05)), z_540);
b2_543 = Call(P_45, V.Undef, x_538, ((V)((TY_51 - 0.03))), z_540);
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, GetIdx(a_542, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(a_542, 1D))).S("L").V(Call(r2_21, V.Undef, GetIdx(b2_543, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(b2_543, 1D))).End()))).Put("stroke", ((V)("#2a2a34"))).Put("stroke-width", Call(r2_21, V.Undef, ((V)((0.045 * ToNum(GetIdx(a_542, 2D))))))).Put("stroke-linecap", ((V)("round"))).V, tbl_68);
w_544 = Call(P_45, V.Undef, x_538, ((V)(0.03)), z_540);
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_21, V.Undef, GetIdx(w_544, 0D))).Put("cy", Call(r2_21, V.Undef, GetIdx(w_544, 1D))).Put("r", Call(r2_21, V.Undef, ((V)((0.04 * ToNum(GetIdx(w_544, 2D))))))).Put("fill", ((V)("#1a1a22"))).V, tbl_68);
return default;
}, 1, "", true));
Call(line_70, V.Undef, Arr(Arr(((V)(((-TW_47) + 0.08))), ((V)(0.3)), ((V)((Z1_49 - 0.15)))), Arr(((V)((TW_47 - 0.08))), ((V)(0.3)), ((V)((Z1_49 - 0.15))))), NewObj(2).Put("stroke", ((V)("#2a2a34"))).Put("stroke-width", ((V)(2D))).V, tbl_68);
Call(quad_69, V.Undef, Arr(Arr(((V)((-TW_47))), ((V)((TY_51 - 0.045))), ((V)(Z0_48))), Arr(((V)(TW_47)), ((V)((TY_51 - 0.045))), ((V)(Z0_48))), Arr(((V)(TW_47)), ((V)(TY_51)), ((V)(Z0_48))), Arr(((V)((-TW_47))), ((V)(TY_51)), ((V)(Z0_48)))), NewObj(1).Put("fill", ((V)("#1d4a86"))).V, tbl_68);
Call(quad_69, V.Undef, Arr(Arr(((V)(TW_47)), ((V)((TY_51 - 0.045))), ((V)(Z0_48))), Arr(((V)(TW_47)), ((V)((TY_51 - 0.045))), ((V)(Z1_49))), Arr(((V)(TW_47)), ((V)(TY_51)), ((V)(Z1_49))), Arr(((V)(TW_47)), ((V)(TY_51)), ((V)(Z0_48)))), NewObj(1).Put("fill", ((V)("#1a4278"))).V, tbl_68);
Call(quad_69, V.Undef, Arr(Arr(((V)((-TW_47))), ((V)(TY_51)), ((V)(Z0_48))), Arr(((V)(TW_47)), ((V)(TY_51)), ((V)(Z0_48))), Arr(((V)(TW_47)), ((V)(TY_51)), ((V)(Z1_49))), Arr(((V)((-TW_47))), ((V)(TY_51)), ((V)(Z1_49)))), NewObj(1).Put("fill", ((V)("#2d6cc0"))).V, tbl_68);
ln_529 = Fn((V _arrowThis554, int _argc545, V a_551, V b2_552, V w_553, V _a550, V[] _rest546) => {
V p_555 = default;
V q_556 = default;
p_555 = Call(P_45, V.Undef, GetIdx(a_551, 0D), ((V)((TY_51 + 0.001))), GetIdx(a_551, 1D));
q_556 = Call(P_45, V.Undef, GetIdx(b2_552, 0D), ((V)((TY_51 + 0.001))), GetIdx(b2_552, 1D));
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, GetIdx(p_555, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(p_555, 1D))).S("L").V(Call(r2_21, V.Undef, GetIdx(q_556, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(q_556, 1D))).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", w_553).Put("opacity", ((V)(0.92))).V, tbl_68);
return default;
}, 3, "", true);
Call(ln_529, V.Undef, Arr(((V)(((-TW_47) + 0.015))), ((V)(Z0_48))), Arr(((V)(((-TW_47) + 0.015))), ((V)(Z1_49))), ((V)(2.4)));
Call(ln_529, V.Undef, Arr(((V)((TW_47 - 0.015))), ((V)(Z0_48))), Arr(((V)((TW_47 - 0.015))), ((V)(Z1_49))), ((V)(2.4)));
Call(ln_529, V.Undef, Arr(((V)((-TW_47))), ((V)((Z0_48 + 0.01)))), Arr(((V)(TW_47)), ((V)((Z0_48 + 0.01)))), ((V)(2.4)));
Call(ln_529, V.Undef, Arr(((V)((-TW_47))), ((V)((Z1_49 - 0.01)))), Arr(((V)(TW_47)), ((V)((Z1_49 - 0.01)))), ((V)(1.6)));
Call(ln_529, V.Undef, Arr(((V)(0D)), ((V)(Z0_48))), Arr(((V)(0D)), ((V)(Z1_49))), ((V)(1.2)));
Call(quad_69, V.Undef, Arr(Arr(((V)(((-TW_47) + 0.1))), ((V)((TY_51 + 0.001))), ((V)((Z0_48 + 0.15)))), Arr(((V)((-0.05))), ((V)((TY_51 + 0.001))), ((V)((Z0_48 + 0.15)))), Arr(((V)((-0.25))), ((V)((TY_51 + 0.001))), ((V)((Z1_49 - 0.2)))), Arr(((V)(((-TW_47) + 0.1))), ((V)((TY_51 + 0.001))), ((V)((Z1_49 - 0.2))))), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.07))).V, tbl_68);
Call(quad_69, V.Undef, Arr(Arr(((V)(0.15)), ((V)((TY_51 + 0.001))), ((V)((Z0_48 + 0.2)))), Arr(((V)((TW_47 - 0.05))), ((V)((TY_51 + 0.001))), ((V)((Z0_48 + 0.2)))), Arr(((V)((TW_47 - 0.05))), ((V)((TY_51 + 0.001))), ((V)((Z0_48 + 0.6)))), Arr(((V)(0.3)), ((V)((TY_51 + 0.001))), ((V)((Z0_48 + 0.6))))), NewObj(2).Put("fill", ((V)("#fff4d0"))).Put("opacity", ((V)(0.08))).V, tbl_68);
}
ballFarSh_72 = Call(S_17, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#10203a"))).Put("opacity", ((V)(0.3))).V, tbl_68);
ballFar_73 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, tbl_68);
netG_74 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, tbl_68);
ballNear_75 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, tbl_68);
ballBack_76 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, fg_42);
{
V a_557 = default;
V b2_558 = default;
V c_559 = default;
V d_560 = default;
JsStrBuf m_561 = null;
a_557 = Call(P_45, V.Undef, ((V)(((-TW_47) - 0.06))), ((V)(TY_51)), ((V)(ZN_50)));
b2_558 = Call(P_45, V.Undef, ((V)((TW_47 + 0.06))), ((V)(TY_51)), ((V)(ZN_50)));
c_559 = Call(P_45, V.Undef, ((V)((TW_47 + 0.06))), ((V)((TY_51 + NH_52))), ((V)(ZN_50)));
d_560 = Call(P_45, V.Undef, ((V)(((-TW_47) - 0.06))), ((V)((TY_51 + NH_52))), ((V)(ZN_50)));
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Arr(a_557, b2_558, c_559, d_560), "map", Fn((V _arrowThis569, int _argc562, V s_568, V _a565, V _a566, V _a567, V[] _rest563) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_21, V.Undef, GetIdx(s_568, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(s_568, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).Put("fill", ((V)("#eef2f8"))).Put("opacity", ((V)(0.5))).V, netG_74);
m_561 = new JsStrBuf("");
{
double i_570 = 0;
i_570 = 0D;
while (true) {
if (!((i_570 <= 30D))) break;
double x_572 = 0;
V p_573 = default;
V q_574 = default;
x_572 = (((-TW_47) - 0.06) + ((((2D * TW_47) + 0.12) * i_570) / 30D));
p_573 = Call(P_45, V.Undef, ((V)(x_572)), ((V)(TY_51)), ((V)(ZN_50)));
q_574 = Call(P_45, V.Undef, ((V)(x_572)), ((V)((TY_51 + NH_52))), ((V)(ZN_50)));
m_561.S("M").V(Call(r2_21, V.Undef, GetIdx(p_573, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(p_573, 1D))).S("L").V(Call(r2_21, V.Undef, GetIdx(q_574, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(q_574, 1D)));
i_570++;
}
}
{
double j_575 = 0;
j_575 = 1D;
while (true) {
if (!((j_575 < 4D))) break;
double y_577 = 0;
V p_578 = default;
V q_579 = default;
y_577 = (TY_51 + ((NH_52 * j_575) / 4D));
p_578 = Call(P_45, V.Undef, ((V)(((-TW_47) - 0.06))), ((V)(y_577)), ((V)(ZN_50)));
q_579 = Call(P_45, V.Undef, ((V)((TW_47 + 0.06))), ((V)(y_577)), ((V)(ZN_50)));
m_561.S("M").V(Call(r2_21, V.Undef, GetIdx(p_578, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(p_578, 1D))).S("L").V(Call(r2_21, V.Undef, GetIdx(q_579, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(q_579, 1D)));
j_575++;
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(m_561.Str))).Put("stroke", ((V)("#3a3a44"))).Put("stroke-width", ((V)(0.6))).Put("opacity", ((V)(0.6))).V, netG_74);
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, GetIdx(d_560, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(d_560, 1D))).S("L").V(Call(r2_21, V.Undef, GetIdx(c_559, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(c_559, 1D))).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(3D))).V, netG_74);
Invoke(Arr(a_557, b2_558), "forEach", Fn((V _arrowThis588, int _argc580, V s_586, V i_587, V _a584, V _a585, V[] _rest581) => {
V t_589 = default;
t_589 = GetK(Arr(d_560, c_559), i_587);
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, GetIdx(s_586, 0D))).S(" ").V(Call(r2_21, V.Undef, Add(GetIdx(s_586, 1D), ((V)(3D))))).S("L").V(Call(r2_21, V.Undef, GetIdx(t_589, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(t_589, 1D))).End()))).Put("stroke", ((V)("#3a3a44"))).Put("stroke-width", ((V)(3D))).V, netG_74);
return default;
}, 2, "", true));
}
ballSh_77 = Call(S_17, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#10203a"))).Put("opacity", ((V)(0.3))).V, ballNear_75);
ball_78 = Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("r", ((V)(5D))).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#e6dccb"))).Put("stroke-width", ((V)(0.8))).V);
trail_79 = Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(3D))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.35))).V);
PADDLE_80 = Fn((V _arrowThis598, int _argc590, V col_596, V edge_597, V _a594, V _a595, V[] _rest591) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"-0.75\" y=\"0.2\" width=\"1.5\" height=\"4.6\" rx=\"0.6\" fill=\"#c98a52\" stroke=\"#6b4426\" stroke-width=\"0.35\"/><rect x=\"-0.75\" y=\"1.7\" width=\"1.5\" height=\"0.9\" fill=\"#8a5a2c\" opacity=\"0.6\"/>").S("<ellipse cx=\"0\" cy=\"-3.2\" rx=\"3.7\" ry=\"4\" fill=\"").V(col_596).S("\" stroke=\"").V(edge_597).S("\" stroke-width=\"0.5\"/><ellipse cx=\"-1.1\" cy=\"-4.5\" rx=\"1.3\" ry=\"0.8\" fill=\"#ffffff\" opacity=\"0.3\"/>").End()));
}, 2, "", true);
ok_81 = Invoke(ctx_40, "opponent");
okName_82 = Invoke(ctx_40, "nameOf", ok_81);
opp_83 = Invoke(YG_16, "creature", oppL_67, ok_81, NewObj(1).Put("yaw", ((V)(0D))).V);
me_84 = Invoke(ctx_40, "creature", Get(ctx_40, "playerKey"), NewObj(1).Put("yaw", ((V)(150D))).V);
MESZ_85 = 140D;
OPSZ_86 = 82D;
ME_87 = NewObj(9).Put("paw", ((V)("pawL"))).Put("arm", ((V)("armL"))).Put("side", ((V)(1D))).Put("ws", NewObj(0).V).Put("off", Arr(((V)(26D)), ((V)((-36D))))).Put("offN", ((V)(0D))).Put("rot", ((V)((-25D)))).Put("pad", Call(PADDLE_80, V.Undef, ((V)("#e8483c")), ((V)("#7a1c18")))).Put("k", ((V)(2.9))).V;
OP_88 = NewObj(9).Put("paw", ((V)("pawR"))).Put("arm", ((V)("armR"))).Put("side", ((V)((-1D)))).Put("ws", NewObj(0).V).Put("off", Arr(((V)(24D)), ((V)((-38D))))).Put("offN", ((V)(0D))).Put("rot", ((V)(20D))).Put("pad", Call(PADDLE_80, V.Undef, ((V)("#2f6fe0")), ((V)("#14306e")))).Put("k", ((V)(2.3))).V;
Invoke(Arr(Arr(me_84, ME_87), Arr(opp_83, OP_88)), "forEach", Fn((V _arrowThis610, int _argc599, V _a601, V _a602, V _a603, V _a604, V[] _rest600) => {
V I_611 = default;
V c_607 = default;
V Q_609 = default;
{ V _t605 = ListOf(_a601);
{ V _t606 = GetIdx(_t605, 0D);
c_607 = _t606; }
{ V _t608 = GetIdx(_t605, 1D);
Q_609 = _t608; }
}
I_611 = Get(c_607, "I");
if (!(Truthy(I_611))) {
return default;
}
Set(I_611, "propArm", Get(Q_609, "arm"));
Set(I_611, "propFn", Fn((V _arrowThis619, int _argc612, V I2_618, V _a615, V _a616, V _a617, V[] _rest613) => {
V p_620 = default;
p_620 = (Get(I2_618, "W") is var _t621 && !Truthy(_t621) ? _t621 : GetK(Get(I2_618, "W"), Get(Q_609, "paw")));
return ((V)((Truthy(p_620) ? JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_21, V.Undef, GetIdx(p_620, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(p_620, 1D))).S(") rotate(").V(Call(r2_21, V.Undef, Get(Q_609, "rot"))).S(") scale(").V(Get(Q_609, "k")).S(")\">").V(Get(Q_609, "pad")).S("</g>").End() : "")));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
learn_89 = Fn((V _arrowThis630, int _argc622, V c_628, V Q_629, V _a626, V _a627, V[] _rest623) => {
V p_631 = default;
V o_632 = default;
p_631 = ((Get(c_628, "I") is var _t633 && !Truthy(_t633) ? _t633 : Get(Get(c_628, "I"), "W")) is var _t634 && !Truthy(_t634) ? _t634 : GetK(Get(Get(c_628, "I"), "W"), Get(Q_629, "paw")));
if (!(Truthy(p_631))) {
return default;
}
o_632 = Arr(((V)((ToNum(GetIdx(p_631, 0D)) - 50D))), ((V)((ToNum(GetIdx(p_631, 1D)) - 93D))));
Set(Q_629, "off", (Truthy(Get(Q_629, "offN")) ? Arr(Call(lerp_20, V.Undef, GetIdx(Get(Q_629, "off"), 0D), GetIdx(o_632, 0D), ((V)(0.5))), Call(lerp_20, V.Undef, GetIdx(Get(Q_629, "off"), 1D), GetIdx(o_632, 1D), ((V)(0.5)))) : o_632));
IncM(Q_629, "offN", 1D, false);
return default;
}, 2, "", true);
scoreTx_90 = Call(D_18, V.Undef, ((V)("div")), NewObj(2).Put("cls", ((V)("yg-pill"))).Put("style", ((V)("position:absolute;left:50%;top:12.5%;transform:translateX(-50%);font-size:14px;padding:6px 12px;white-space:nowrap;"))).V, Invoke(stage_59, "querySelector", ((V)(".yg-hud"))));
px_91 = 0D;
pxT_92 = ((V)(0D));
pv_93 = 0D;
ox_94 = ((V)(0D));
oxT_95 = ((V)(0D));
ov_96 = 0D;
b_97 = V.Null;
pts_98 = Arr(((V)(0D)), ((V)(0D)));
rally_99 = 0D;
best_100 = 0D;
serve_101 = ((V)(0D));
serveN_102 = 0D;
phase_103 = new JsStrBuf("serve");
ph0_104 = ((V)(0D));
tNow_105 = ((V)(0D));
swingP_106 = ((V)((-9D)));
swingO_107 = ((V)((-9D)));
lastHit_108 = ((V)(0D));
skill_109 = ((V)(0.55));
trailPts_110 = Arr();
dustAt_111 = ((V)(0D));
pvPrev_112 = 0D;
say_113 = Fn((V _arrowThis641, int _argc635, V _a637, V _a638, V _a639, V _a640, V[] _rest636) => {
Set(scoreTx_90, "textContent", ((V)(JsStrBuf.Begin().S("You ").V(GetIdx(pts_98, 0D)).S(" \u2013 ").V(GetIdx(pts_98, 1D)).S(" ").V(okName_82).End())));
Invoke(ctx_40, "timer", ((V)("")));
return default;
}, 0, "", true);
api_121 = NewObj(10).Put("oppKey", ok_81).Put("start", Fn((V _self642, int _argc643, V _a645, V _a646, V _a647, V _a648, V[] _rest644) => {
if (_self642.IsNullish) _self642 = GlobalV;
Set(api_121, "_done", (false ? V.True : V.False));
pts_98 = Arr(((V)(0D)), ((V)(0D)));
rally_99 = 0D;
best_100 = 0D;
serveN_102 = 0D;
Invoke(ctx_40, "setScore", ((V)(0D)));
Call(say_113, V.Undef);
Call(newBall_114, V.Undef, ((V)(0D)));
Invoke(me_84, "play", ((V)("idle")));
Invoke(opp_83, "play", ((V)("idle")));
return default;
}, 0, "start", false)).Put("down", Fn((V _self649, int _argc650, V p_656, V _a653, V _a654, V _a655, V[] _rest651) => {
if (_self649.IsNullish) _self649 = GlobalV;
pxT_92 = Call(fingerToPx_64, V.Undef, Get(p_656, "x"));
if (((string.Equals(phase_103.Str, "serve") && SEqN(serve_101, 0D)) && ((ToNum(tNow_105) - ToNum(ph0_104)) > 300D))) {
phase_103.Set("play");
Invoke(ctx_40, "hint", ((V)("")));
Set(b_97, "x", ((V)((px_91 + 0.04))));
Call(hitByMe_116, V.Undef);
}
return default;
}, 1, "down", false)).Put("move", Fn((V _self657, int _argc658, V p_664, V _a661, V _a662, V _a663, V[] _rest659) => {
if (_self657.IsNullish) _self657 = GlobalV;
pxT_92 = Call(fingerToPx_64, V.Undef, Get(p_664, "x"));
return default;
}, 1, "move", false)).Put("key", Fn((V _self665, int _argc666, V k_672, V dn_673, V _a670, V _a671, V[] _rest667) => {
if (_self665.IsNullish) _self665 = GlobalV;
if (!(Truthy(dn_673))) {
return default;
}
if (SEqS(k_672, "ArrowLeft")) {
pxT_92 = Call(cl_19, V.Undef, ((V)((ToNum(pxT_92) - 0.15))), ((V)((-PXM_63))), ((V)(PXM_63)));
return (true ? V.True : V.False);
}
if (SEqS(k_672, "ArrowRight")) {
pxT_92 = Call(cl_19, V.Undef, Add(pxT_92, ((V)(0.15))), ((V)((-PXM_63))), ((V)(PXM_63)));
return (true ? V.True : V.False);
}
if ((SEqS(k_672, " ") || SEqS(k_672, "ArrowUp"))) {
Invoke(api_121, "down", NewObj(1).Put("x", ((V)((((ToNum(W_43) / 2D) + PAN0_60) + (px_91 * (ToNum(KP_62) - PANK_61)))))).V);
return (true ? V.True : V.False);
}
return default;
}, 2, "key", false)).Put("_state", Fn((V _arrowThis680, int _argc674, V _a676, V _a677, V _a678, V _a679, V[] _rest675) => {
return NewObj(8).Put("phase", ((V)(phase_103.Str))).Put("pts", Invoke(pts_98, "slice")).Put("rally", ((V)(rally_99))).Put("best", ((V)(best_100))).Put("b", (b_97 is var _t689 && !Truthy(_t689) ? _t689 : Invoke(Arr(Get(b_97, "x"), Get(b_97, "y"), Get(b_97, "z")), "map", Fn((V _arrowThis688, int _argc681, V v_687, V _a684, V _a685, V _a686, V[] _rest682) => {
return ((V)(ToNum(Invoke(v_687, "toFixed", ((V)(2D))))));
}, 1, "", true)))).Put("px", ((V)(ToNum(Invoke(((V)(px_91)), "toFixed", ((V)(2D))))))).Put("off", Invoke(Get(ME_87, "off"), "map", Fn((V _arrowThis697, int _argc690, V v_696, V _a693, V _a694, V _a695, V[] _rest691) => {
return ((V)(ToNum(Invoke(v_696, "toFixed", ((V)(1D))))));
}, 1, "", true))).Put("offO", Invoke(Get(OP_88, "off"), "map", Fn((V _arrowThis705, int _argc698, V v_704, V _a701, V _a702, V _a703, V[] _rest699) => {
return ((V)(ToNum(Invoke(v_704, "toFixed", ((V)(1D))))));
}, 1, "", true))).V;
}, 0, "_state", true)).Put("_aimAt", Fn((V _arrowThis712, int _argc706, V _a708, V _a709, V _a710, V _a711, V[] _rest707) => {
if (Truthy((b_97 is var _t713 && !Truthy(_t713) ? _t713 : (LtN(Get(b_97, "vz"), 0D) ? V.True : V.False)))) {
double tz_714 = 0;
tz_714 = ((ZP_54 - ToNum(Get(b_97, "z"))) / ToNum(Get(b_97, "vz")));
pxT_92 = Call(cl_19, V.Undef, ((V)((ToNum(Add(Get(b_97, "x"), ((V)((ToNum(Get(b_97, "vx")) * tz_714))))) - 0.04))), ((V)((-PXM_63))), ((V)(PXM_63)));
}
return default;
}, 0, "_aimAt", true)).Put("celebrate", Fn((V _self715, int _argc716, V st_722, V _a719, V _a720, V _a721, V[] _rest717) => {
if (_self715.IsNullish) _self715 = GlobalV;
Set(api_121, "_done", (true ? V.True : V.False));
Invoke(me_84, "pose", NewObj(1).Put("armL", ((V)(60D))).V);
Invoke(me_84, "yaw", ((V)(0D)));
Invoke(me_84, "play", ((V)((GeN(st_722, 2D) ? "happy" : "idle"))));
return default;
}, 1, "celebrate", false)).Put("update", Fn((V _self723, int _argc724, V dt_730, V t_731, V _a728, V _a729, V[] _rest725) => {
double px0_732 = 0;
double sp_733 = 0;
V ox0_734 = default;
V windMe_735 = default;
V windOp_736 = default;
V runMe_737 = default;
V runOp_738 = default;
if (_self723.IsNullish) _self723 = GlobalV;
tNow_105 = t_731;
px0_732 = px_91;
px_91 = (px_91 + ((ToNum(pxT_92) - px_91) * (1D - FdLibm.Exp(((-ToNum(dt_730)) * 12D)))));
pv_93 = ((px_91 - px0_732) / Max(ToNum(dt_730), 0.001));
if (Truthy((((b_97 is var _t739 && !Truthy(_t739) ? _t739 : (string.Equals(phase_103.Str, "serve") ? V.True : V.False)) is var _t740 && !Truthy(_t740) ? _t740 : (SEqN(serve_101, 1D) ? V.True : V.False)) is var _t741 && !Truthy(_t741) ? _t741 : (((ToNum(t_731) - ToNum(ph0_104)) > 900D) ? V.True : V.False)))) {
phase_103.Set("play");
Call(hitByOpp_117, V.Undef);
}
if (Truthy(((b_97 is var _t742 && !Truthy(_t742) ? _t742 : (string.Equals(phase_103.Str, "serve") ? V.True : V.False)) is var _t743 && !Truthy(_t743) ? _t743 : (SEqN(serve_101, 0D) ? V.True : V.False)))) {
Set(b_97, "x", ((V)((px_91 + 0.04))));
Set(b_97, "y", ((V)(((TY_51 + 0.3) + (System.Math.Abs(FdLibm.Sin(((ToNum(t_731) - ToNum(ph0_104)) / 260D))) * 0.15)))));
Set(b_97, "z", ((V)((ZP_54 + 0.02))));
}
if (Truthy((b_97 is var _t744 && !Truthy(_t744) ? _t744 : ((string.Equals(phase_103.Str, "play") || string.Equals(phase_103.Str, "point")) ? V.True : V.False)))) {
double n_745 = 0;
n_745 = 4D;
{
double i_746 = 0;
i_746 = 0D;
while (true) {
if (!((i_746 < n_745))) break;
double h_748 = 0;
V pz_749 = default;
h_748 = (ToNum(dt_730) / n_745);
pz_749 = Get(b_97, "z");
OpSet(b_97, "vy", 1, ((V)((G_46 * h_748))));
OpSet(b_97, "x", 0, ((V)((ToNum(Get(b_97, "vx")) * h_748))));
OpSet(b_97, "y", 0, ((V)((ToNum(Get(b_97, "vy")) * h_748))));
OpSet(b_97, "z", 0, ((V)((ToNum(Get(b_97, "vz")) * h_748))));
if (((((LeN(Get(b_97, "y"), (TY_51 + BR_53)) && LtN(Get(b_97, "vy"), 0D)) && (System.Math.Abs(ToNum(Get(b_97, "x"))) <= TW_47)) && GeN(Get(b_97, "z"), Z0_48)) && LeN(Get(b_97, "z"), Z1_49))) {
double hs_750 = 0;
Set(b_97, "y", ((V)((TY_51 + BR_53))));
Set(b_97, "vy", ((V)(((-ToNum(Get(b_97, "vy"))) * 0.82))));
IncM(b_97, "bounces", 1D, false);
Invoke(SFX_23, "tap");
hs_750 = (LtN(Get(b_97, "z"), ZN_50) ? 0D : 1D);
if (string.Equals(phase_103.Str, "play")) {
if (SEqN(lastHit_108, hs_750)) {
Call(point_118, V.Undef, (SEqN(lastHit_108, 1D) ? V.True : V.False), ((V)((SEqN(lastHit_108, 1D) ? "Fault!" : "Fault"))));
} else {
if (GeN(Get(b_97, "bounces"), 2D)) {
Call(point_118, V.Undef, ((hs_750 == 1D) ? V.True : V.False), ((hs_750 == 1D) ? ((V)("Point!")) : V.Null));
}
}
}
}
if ((((string.Equals(phase_103.Str, "play") && (((ToNum(pz_749) - ZN_50) * (ToNum(Get(b_97, "z")) - ZN_50)) <= 0D)) && LtN(Get(b_97, "y"), ((TY_51 + NH_52) + BR_53))) && (System.Math.Abs(ToNum(Get(b_97, "x"))) < (TW_47 + 0.06)))) {
Set(b_97, "vz", ((V)(((-ToNum(Get(b_97, "vz"))) * 0.15))));
OpSet(b_97, "vx", 2, ((V)(0.3)));
Invoke(SFX_23, "thud");
Call(point_118, V.Undef, (SEqN(lastHit_108, 1D) ? V.True : V.False), ((V)((SEqN(lastHit_108, 1D) ? "Net!" : "Into the net"))));
}
if (LtN(Get(b_97, "y"), BR_53)) {
if ((string.Equals(phase_103.Str, "play") && SEqN(Get(b_97, "bounces"), 0D))) {
Call(point_118, V.Undef, (SEqN(lastHit_108, 1D) ? V.True : V.False), ((V)((SEqN(lastHit_108, 1D) ? "Out!" : "Out"))));
}
Set(b_97, "y", ((V)(BR_53)));
Set(b_97, "vy", ((V)(((-ToNum(Get(b_97, "vy"))) * 0.5))));
OpSet(b_97, "vx", 2, ((V)(0.7)));
OpSet(b_97, "vz", 2, ((V)(0.7)));
}
if (string.Equals(phase_103.Str, "play")) {
if ((((LtN(Get(b_97, "vz"), 0D) && GeN(pz_749, ZP_54)) && LtN(Get(b_97, "z"), ZP_54)) && LtN(Get(b_97, "y"), (TY_51 + 0.75)))) {
if ((System.Math.Abs((ToNum(Get(b_97, "x")) - px_91)) < 0.13)) {
if ((SEqN(Get(b_97, "bounces"), 1D) || (SEqN(Get(b_97, "side"), 1D) && GeN(Get(b_97, "bounces"), 1D)))) {
Call(hitByMe_116, V.Undef);
} else {
if (SEqN(Get(b_97, "bounces"), 0D)) {
Call(hitByMe_116, V.Undef);
}
}
}
}
if (LtN(Get(b_97, "z"), (ZP_54 - 0.35))) {
Call(point_118, V.Undef, (false ? V.True : V.False), V.Null);
}
if ((((GtN(Get(b_97, "vz"), 0D) && LeN(pz_749, ZO_55)) && GtN(Get(b_97, "z"), ZO_55)) && LtN(Get(b_97, "y"), (TY_51 + 0.75)))) {
V pMiss_751 = default;
pMiss_751 = Call(cl_19, V.Undef, ((V)(((0.05 + (rally_99 * 0.012)) - ((ToNum(skill_109) - 0.5) * 0.12)))), ((V)(0.03)), ((V)(0.32)));
if (((System.Math.Abs((ToNum(Get(b_97, "x")) - ToNum(ox_94))) < 0.13) && Gt(Invoke(G("Math"), "random"), pMiss_751))) {
Call(hitByOpp_117, V.Undef);
} else {
if ((System.Math.Abs((ToNum(Get(b_97, "x")) - ToNum(ox_94))) < 0.2)) {
swingO_107 = tNow_105;
}
}
}
if (GtN(Get(b_97, "z"), (ZO_55 + 0.4))) {
Call(point_118, V.Undef, (true ? V.True : V.False), ((V)("Point!")));
}
}
i_746++;
}
}
}
if ((string.Equals(phase_103.Str, "point") && ((ToNum(t_731) - ToNum(ph0_104)) > 1200D))) {
if ((GeN(GetIdx(pts_98, 0D), 7D) || GeN(GetIdx(pts_98, 1D), 7D))) {
V won_752 = default;
phase_103.Set("done");
won_752 = (Gt(GetIdx(pts_98, 0D), GetIdx(pts_98, 1D)) ? V.True : V.False);
if (Truthy(won_752)) {
Invoke(ctx_40, "add", ((V)((50D + (best_100 * 5D)))), ((V)((ToNum(W_43) / 2D))), ((V)((ToNum(H_44) * 0.46))), ((V)(JsStrBuf.Begin().S("You win! +").N((50D + (best_100 * 5D))).End())), ((V)("#ffe36e")));
} else {
Invoke(ctx_40, "add", ((V)((best_100 * 5D))));
}
Invoke(ctx_40, "finish", NewObj(3).Put("title", ((V)((Truthy(won_752) ? "You win!" : JsStrBuf.Begin().V(okName_82).S(" wins").End())))).Put("sub", ((V)(JsStrBuf.Begin().S("You ").V(GetIdx(pts_98, 0D)).S(" \u2013 ").V(GetIdx(pts_98, 1D)).S(" \u00b7 best rally ").N(best_100).End()))).Put("delay", ((V)(900D))).V);
} else {
serveN_102++;
Call(newBall_114, V.Undef, ((V)((System.Math.Floor((serveN_102 / 2D)) % 2D))));
}
}
if (Truthy(((b_97 is var _t753 && !Truthy(_t753) ? _t753 : (string.Equals(phase_103.Str, "play") ? V.True : V.False)) is var _t754 && !Truthy(_t754) ? _t754 : (GtN(Get(b_97, "vz"), 0D) ? V.True : V.False)))) {
double tz_755 = 0;
V gx_756 = default;
double err_757 = 0;
tz_755 = ((ZO_55 - ToNum(Get(b_97, "z"))) / ToNum(Get(b_97, "vz")));
gx_756 = Add(Get(b_97, "x"), ((V)((ToNum(Get(b_97, "vx")) * tz_755))));
err_757 = (((1D - ToNum(skill_109)) * 0.16) * FdLibm.Sin(((ToNum(t_731) / 300D) + rally_99)));
oxT_95 = Call(cl_19, V.Undef, Add(gx_756, ((V)(err_757))), ((V)((-TW_47))), ((V)(TW_47)));
} else {
if ((!string.Equals(phase_103.Str, "serve") || SEqN(serve_101, 0D))) {
oxT_95 = Call(lerp_20, V.Undef, oxT_95, ((V)(0D)), ((V)((1D - FdLibm.Exp(((-ToNum(dt_730)) * 2D))))));
}
}
sp_733 = (0.9 + (ToNum(skill_109) * 1.4));
ox0_734 = ox_94;
ox_94 = Add(ox_94, Call(cl_19, V.Undef, ((V)((ToNum(oxT_95) - ToNum(ox_94)))), ((V)(((-sp_733) * ToNum(dt_730)))), ((V)((sp_733 * ToNum(dt_730))))));
if ((string.Equals(phase_103.Str, "serve") && SEqN(serve_101, 1D))) {
ox_94 = Call(lerp_20, V.Undef, ox_94, ((V)(0D)), ((V)(0.1)));
Set(b_97, "x", ox_94);
Set(b_97, "y", ((V)(((TY_51 + 0.28) + (System.Math.Abs(FdLibm.Sin(((ToNum(t_731) - ToNum(ph0_104)) / 240D))) * 0.12)))));
Set(b_97, "z", ((V)((ZO_55 - 0.02))));
}
ov_96 = ((ToNum(ox_94) - ToNum(ox0_734)) / Max(ToNum(dt_730), 0.001));
windMe_735 = (Truthy((((b_97 is var _t758 && !Truthy(_t758) ? _t758 : (string.Equals(phase_103.Str, "play") ? V.True : V.False)) is var _t759 && !Truthy(_t759) ? _t759 : (LtN(Get(b_97, "vz"), 0D) ? V.True : V.False)) is var _t760 && !Truthy(_t760) ? _t760 : (GtN(Get(b_97, "z"), ZP_54) ? V.True : V.False))) ? Call(cl_19, V.Undef, ((V)((1D - ((((ToNum(Get(b_97, "z")) - ZP_54) / (-ToNum(Get(b_97, "vz")))) - 0.06) / 0.42)))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
windOp_736 = (Truthy((((b_97 is var _t761 && !Truthy(_t761) ? _t761 : (string.Equals(phase_103.Str, "play") ? V.True : V.False)) is var _t762 && !Truthy(_t762) ? _t762 : (GtN(Get(b_97, "vz"), 0D) ? V.True : V.False)) is var _t763 && !Truthy(_t763) ? _t763 : (LtN(Get(b_97, "z"), ZO_55) ? V.True : V.False))) ? Call(cl_19, V.Undef, ((V)((1D - ((((ZO_55 - ToNum(Get(b_97, "z"))) / ToNum(Get(b_97, "vz"))) - 0.06) / 0.42)))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
runMe_737 = Call(cl_19, V.Undef, ((V)((System.Math.Abs(pv_93) / 1.6))), ((V)(0D)), ((V)(1D)));
runOp_738 = Call(cl_19, V.Undef, ((V)((System.Math.Abs(ov_96) / 1.4))), ((V)(0D)), ((V)(1D)));
if (Truthy(((((b_97 is var _t764 && !Truthy(_t764) ? _t764 : (string.Equals(phase_103.Str, "play") ? V.True : V.False)) is var _t765 && !Truthy(_t765) ? _t765 : (LtN(Get(b_97, "vz"), 0D) ? V.True : V.False)) is var _t766 && !Truthy(_t766) ? _t766 : (GtN(Get(b_97, "z"), ZP_54) ? V.True : V.False)) is var _t767 && !Truthy(_t767) ? _t767 : (((ToNum(t_731) - ToNum(swingP_106)) > 600D) ? V.True : V.False)))) {
double tz_768 = 0;
V gx_769 = default;
tz_768 = ((ToNum(Get(b_97, "z")) - ZP_54) / (-ToNum(Get(b_97, "vz"))));
gx_769 = Add(Get(b_97, "x"), ((V)((ToNum(Get(b_97, "vx")) * tz_768))));
if (((tz_768 < 0.075) && (System.Math.Abs((ToNum(gx_769) - px_91)) < 0.2))) {
swingP_106 = ((V)((ToNum(Add(t_731, ((V)((tz_768 * 1000D))))) - 60D)));
}
}
if (Truthy(((((b_97 is var _t770 && !Truthy(_t770) ? _t770 : (string.Equals(phase_103.Str, "play") ? V.True : V.False)) is var _t771 && !Truthy(_t771) ? _t771 : (GtN(Get(b_97, "vz"), 0D) ? V.True : V.False)) is var _t772 && !Truthy(_t772) ? _t772 : (LtN(Get(b_97, "z"), ZO_55) ? V.True : V.False)) is var _t773 && !Truthy(_t773) ? _t773 : (((ToNum(t_731) - ToNum(swingO_107)) > 600D) ? V.True : V.False)))) {
double tz_774 = 0;
V gx_775 = default;
tz_774 = ((ZO_55 - ToNum(Get(b_97, "z"))) / ToNum(Get(b_97, "vz")));
gx_775 = Add(Get(b_97, "x"), ((V)((ToNum(Get(b_97, "vx")) * tz_774))));
if (((tz_774 < 0.075) && (System.Math.Abs((ToNum(gx_775) - ToNum(ox_94))) < 0.2))) {
swingO_107 = ((V)((ToNum(Add(t_731, ((V)((tz_774 * 1000D))))) - 60D)));
}
}
if (!(Truthy(Get(api_121, "_done")))) {
Call(poseCreature_120, V.Undef, me_84, ME_87, Call(swingPose_119, V.Undef, windMe_735, ((V)((ToNum(t_731) - ToNum(swingP_106))))), runMe_737, dt_730, ((V)(180D)), Add(((V)(150D)), Call(cl_19, V.Undef, ((V)((pv_93 * 6D))), ((V)((-14D))), ((V)(14D)))), NewObj(2).Put("tilt", Call(cl_19, V.Undef, ((V)((pv_93 * 5D))), ((V)((-7D))), ((V)(7D)))).Put("smile", ((V)((string.Equals(phase_103.Str, "point") ? 0D : 0.2)))).V);
}
Call(poseCreature_120, V.Undef, opp_83, OP_88, Call(swingPose_119, V.Undef, windOp_736, ((V)((ToNum(t_731) - ToNum(swingO_107))))), runOp_738, dt_730, ((V)(0D)), Add(Call(cl_19, V.Undef, ((V)(((-ov_96) * 6D))), ((V)((-16D))), ((V)(16D))), ((V)(8D))), NewObj(1).Put("tilt", Call(cl_19, V.Undef, ((V)(((-ov_96) * 5D))), ((V)((-7D))), ((V)(7D)))).V);
if ((((System.Math.Abs((pv_93 - pvPrev_112)) > (((9D * ToNum(dt_730)) * 60D) * 0.05)) && (System.Math.Abs(pv_93) > 1.2)) && Gt(t_731, dustAt_111))) {
V f_776 = default;
dustAt_111 = Add(t_731, ((V)(260D)));
f_776 = Call(P_45, V.Undef, ((V)((px_91 - 0.2))), ((V)(0D)), ((V)(0.2)));
Invoke(ctx_40, "burst", GetIdx(f_776, 0D), ((V)(Min((ToNum(H_44) - 40D), ToNum(GetIdx(f_776, 1D))))), ((V)("dust")), ((V)(4D)), NewObj(3).Put("v", ((V)(50D))).Put("life", ((V)(0.5))).Put("layer", fg_42).V);
}
pvPrev_112 = pv_93;
if (((((GtN(t_731, 600D) && LtN(Get(ME_87, "offN"), 6D)) && LtN(windMe_735, 0.05)) && ((ToNum(t_731) - ToNum(swingP_106)) > 700D)) && LtN(runMe_737, 0.05))) {
Call(learn_89, V.Undef, me_84, ME_87);
}
if (((((GtN(t_731, 600D) && LtN(Get(OP_88, "offN"), 6D)) && LtN(windOp_736, 0.05)) && ((ToNum(t_731) - ToNum(swingO_107)) > 700D)) && LtN(runOp_738, 0.05))) {
Call(learn_89, V.Undef, opp_83, OP_88);
}
{
V g_777 = default;
double k_778 = 0;
g_777 = Call(P_45, V.Undef, ((V)(px_91)), ((V)((TY_51 + 0.11))), ((V)(ZP_54)));
k_778 = (MESZ_85 / 100D);
Invoke(me_84, "set", ((V)((ToNum(GetIdx(g_777, 0D)) - (ToNum(GetIdx(Get(ME_87, "off"), 0D)) * k_778)))), ((V)((ToNum(GetIdx(g_777, 1D)) - (ToNum(GetIdx(Get(ME_87, "off"), 1D)) * k_778)))), ((V)(MESZ_85)));
}
{
V g_779 = default;
double k_780 = 0;
g_779 = Call(P_45, V.Undef, ox_94, ((V)((TY_51 + 0.12))), ((V)(ZO_55)));
k_780 = (OPSZ_86 / 100D);
Invoke(opp_83, "set", ((V)((ToNum(GetIdx(g_779, 0D)) - (ToNum(GetIdx(Get(OP_88, "off"), 0D)) * k_780)))), ((V)((ToNum(GetIdx(g_779, 1D)) - (ToNum(GetIdx(Get(OP_88, "off"), 1D)) * k_780)))), ((V)(OPSZ_86)));
}
{
double pan_781 = 0;
V tr_782 = default;
pan_781 = (PAN0_60 - (px_91 * PANK_61));
tr_782 = ((V)(JsStrBuf.Begin().S("translateX(").V(Call(r2_21, V.Undef, ((V)(((pan_781 / ToNum(W_43)) * 100D))))).S("%)").End()));
Invoke(Arr(scene_66, bg_41, oppL_67, tbl_68, Get(ctx_40, "crl"), fg_42), "forEach", Fn((V _arrowThis790, int _argc783, V e_789, V _a786, V _a787, V _a788, V[] _rest784) => {
if (!SEq(Get(Get(e_789, "style"), "transform"), tr_782)) {
Set(Get(e_789, "style"), "transform", tr_782);
}
return default;
}, 1, "", true));
}
if (Truthy(b_97)) {
V s_791 = default;
double r_792 = 0;
V lay_793 = default;
V onT_794 = default;
double gy_795 = 0;
V g0_796 = default;
V hk_797 = default;
s_791 = Call(P_45, V.Undef, Get(b_97, "x"), Get(b_97, "y"), Get(b_97, "z"));
r_792 = Max(2.4, (BR_53 * ToNum(GetIdx(s_791, 2D))));
Invoke(ball_78, "setAttribute", ((V)("cx")), Call(r2_21, V.Undef, GetIdx(s_791, 0D)));
Invoke(ball_78, "setAttribute", ((V)("cy")), Call(r2_21, V.Undef, GetIdx(s_791, 1D)));
Invoke(ball_78, "setAttribute", ((V)("r")), Call(r2_21, V.Undef, ((V)(r_792))));
lay_793 = (GtN(Get(b_97, "z"), ZN_50) ? ballFar_73 : (GtN(Get(b_97, "z"), 0.2) ? ballNear_75 : ballBack_76));
if (!SEq(Get(ball_78, "parentNode"), lay_793)) {
Invoke(lay_793, "appendChild", trail_79);
Invoke(lay_793, "appendChild", ball_78);
}
if (!SEq(Get(ballSh_77, "parentNode"), (GtN(Get(b_97, "z"), ZN_50) ? tbl_68 : ballNear_75))) {
if (GtN(Get(b_97, "z"), ZN_50)) {
Invoke(tbl_68, "insertBefore", ballSh_77, ballFar_73);
} else {
Invoke(ballNear_75, "insertBefore", ballSh_77, Get(ballNear_75, "firstChild"));
}
}
onT_794 = ((((System.Math.Abs(ToNum(Get(b_97, "x"))) <= TW_47) && GeN(Get(b_97, "z"), Z0_48)) && LeN(Get(b_97, "z"), Z1_49)) ? V.True : V.False);
gy_795 = (Truthy(onT_794) ? TY_51 : 0D);
g0_796 = Call(P_45, V.Undef, Get(b_97, "x"), ((V)(gy_795)), Get(b_97, "z"));
hk_797 = Call(cl_19, V.Undef, ((V)((1D - ((ToNum(Get(b_97, "y")) - gy_795) / 1D)))), ((V)(0.2)), ((V)(1D)));
Invoke(ballSh_77, "setAttribute", ((V)("cx")), Call(r2_21, V.Undef, GetIdx(g0_796, 0D)));
Invoke(ballSh_77, "setAttribute", ((V)("cy")), Call(r2_21, V.Undef, GetIdx(g0_796, 1D)));
Invoke(ballSh_77, "setAttribute", ((V)("rx")), Call(r2_21, V.Undef, ((V)(((r_792 * 1.2) * ToNum(hk_797))))));
Invoke(ballSh_77, "setAttribute", ((V)("ry")), Call(r2_21, V.Undef, ((V)(((r_792 * 0.5) * ToNum(hk_797))))));
Invoke(ballSh_77, "setAttribute", ((V)("opacity")), Call(r2_21, V.Undef, ((V)((0.35 * ToNum(hk_797))))));
Invoke(trailPts_110, "push", Arr(GetIdx(s_791, 0D), GetIdx(s_791, 1D)));
if (GtN(Get(trailPts_110, "length"), 6D)) {
Invoke(trailPts_110, "shift");
}
Invoke(trail_79, "setAttribute", ((V)("d")), ((V)((string.Equals(phase_103.Str, "play") ? JsStrBuf.Begin().S("M").V(Invoke(Invoke(trailPts_110, "map", Fn((V _arrowThis805, int _argc798, V q_804, V _a801, V _a802, V _a803, V[] _rest799) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_21, V.Undef, GetIdx(q_804, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(q_804, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).End() : ""))));
}
return default;
}, 2, "update", false)).Put("destroy", Fn((V _self806, int _argc807, V _a809, V _a810, V _a811, V _a812, V[] _rest808) => {
if (_self806.IsNullish) _self806 = GlobalV;
Invoke(Arr(bg_41, Get(ctx_40, "crl"), fg_42), "forEach", Fn((V _arrowThis820, int _argc813, V e_819, V _a816, V _a817, V _a818, V[] _rest814) => {
Set(Get(e_819, "style"), "transform", ((V)("")));
return default;
}, 1, "", true));
Invoke(Arr(me_84, opp_83), "forEach", Fn((V _arrowThis828, int _argc821, V c_827, V _a824, V _a825, V _a826, V[] _rest822) => {
if (Truthy(Get(c_827, "I"))) {
Set(Get(c_827, "I"), "propFn", V.Null);
Set(Get(c_827, "I"), "propArm", V.Null);
}
return default;
}, 1, "", true));
Invoke(opp_83, "destroy");
Invoke(oppL_67, "remove");
Invoke(tbl_68, "remove");
Invoke(scene_66, "remove");
return default;
}, 0, "destroy", false)).V;
Invoke(ballFarSh_72, "remove");
Call(newBall_114, V.Undef, ((V)(0D)));
Call(say_113, V.Undef);
return api_121;
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
