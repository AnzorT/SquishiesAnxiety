// yg-soccer.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_yg_soccer_js
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
V track_21 = default;
V SFX_22 = default;
V ICON_23 = default;
YG_16 = Get(G("window"), "YardGames");
if (((!(Truthy(YG_16)) || !(Truthy(Get(YG_16, "add")))) || !(Truthy(Get(YG_16, "cam"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t24 = YG_16;
if (_t24.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t24));
{ V _t25 = Get(_t24, "S");
S_17 = _t25; }
{ V _t26 = Get(_t24, "cl");
cl_18 = _t26; }
{ V _t27 = Get(_t24, "lerp");
lerp_19 = _t27; }
{ V _t28 = Get(_t24, "r2");
r2_20 = _t28; }
{ V _t29 = Get(_t24, "track");
track_21 = _t29; }
{ V _t30 = Get(_t24, "SFX");
SFX_22 = _t30; } }
ICON_23 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#cfeaff\"/><rect y=\"46\" width=\"120\" height=\"38\" fill=\"#9fdc6e\"/>", "<path d=\"M22 58V22H98V58\" fill=\"none\" stroke=\"#fff\" stroke-width=\"4\" stroke-linejoin=\"round\"/><path d=\"M26 24L34 34V56M94 24L86 34V56M34 34H86\" fill=\"none\" stroke=\"#e8eef5\" stroke-width=\"2\"/>", "<path d=\"M26 26H94M26 32H94M26 38H94M26 44H94M26 50H94M34 24V56M44 24V56M54 24V56M64 24V56M74 24V56M84 24V56\" stroke=\"#ffffff\" stroke-width=\"0.8\" opacity=\"0.6\"/>", "<path d=\"M12 70H108\" stroke=\"#fff\" stroke-width=\"2\"/><circle cx=\"60\" cy=\"68\" r=\"9\" fill=\"#fff\" stroke=\"#3a3a44\" stroke-width=\"1.2\"/><path d=\"M60 63L64 66L62.5 71H57.5L56 66Z\" fill=\"#3a3a44\"/></svg>")));
Invoke(YG_16, "add", NewObj(11).Put("id", ((V)("soccer"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Penalty Kick"))).Put("item", ((V)("Soccer Goal"))).Put("color", ((V)("#5cc2ff"))).Put("icon", ICON_23).Put("stars", Arr(((V)(250D)), ((V)(450D)), ((V)(700D)))).Put("coinK", ((V)(0.06))).Put("hint", ((V)("Pull back to aim \u00b7 the dots show the shot \u00b7 let go to kick"))).Put("how", Arr(((V)("Pull back from anywhere, like a slingshot. Farther = higher (too far flies over the bar); to the side = aim the other way.")), ((V)("The dotted path shows where the ball will go. Let go and your creature runs up and kicks, but the keeper can still save it!")), ((V)("5 penalties. Corners and top shots score bonus points.")))).Put("make", Fn((V _self31, int _argc32, V ctx_38, V _a35, V _a36, V _a37, V[] _rest33) => {
V bg_39 = default;
V fg_40 = default;
V W_41 = default;
V H_42 = default;
V CAM_43 = default;
V P_44 = default;
double G_45 = 0;
double GZ_46 = 0;
double GW_47 = 0;
double GH_48 = 0;
double BR_49 = 0;
V B0_50 = default;
double KZ_51 = 0;
V SM_52 = default;
V toW_53 = default;
V line_54 = default;
V spot_55 = default;
V netG_56 = default;
V shG_57 = default;
V postG_58 = default;
V ballSlotBack_59 = default;
V ballL_60 = default;
V trailG_61 = default;
V ballSlot_62 = default;
V fxG_63 = default;
V aimL_64 = default;
V pathG_65 = default;
V bandG_66 = default;
double NX_67 = 0;
double NY_68 = 0;
double ND_69 = 0;
V bulge_70 = default;
V drawNet_71 = default;
V kp_72 = default;
V kpName_73 = default;
V keeper_74 = default;
V kick_75 = default;
V RUN0_76 = default;
V KICKAT_77 = default;
double KS_78 = 0;
V kShadow_79 = default;
V pShadow_80 = default;
V bShadow_81 = default;
V bG_82 = default;
V bC_83 = default;
V bP_84 = default;
double PULL_85 = 0;
double DT_86 = 0;
double LIFE_87 = 0;
double RUN_88 = 0;
V res_89 = default;
double shot_90 = 0;
JsStrBuf phase_91 = null;
V ph0_92 = default;
V tNow_93 = default;
V ball_94 = default;
V aim_95 = default;
V runFrom_96 = default;
V skill_97 = default;
V outcome_98 = default;
V wind_99 = default;
V shotS_100 = default;
V quietAt_101 = default;
V trail_102 = default;
V kickT_103 = default;
V dropAt_104 = default;
V kx_105 = default;
double kH_106 = 0;
V th_107 = default;
double kx0_108 = 0;
V dv_109 = default;
V dotsEl_110 = default;
V drawDots_111 = default;
V place_112 = default;
V resetShot_113 = default;
V stepB_114 = default;
V sim_115 = default;
V posAt_116 = default;
V pullOf_117 = default;
V drawPath_118 = default;
double D2R_119 = 0;
double PIV_120 = 0;
double REACH_121 = 0;
V pivOf_122 = default;
V pawOf_123 = default;
V segD_124 = default;
V clear_125 = default;
V reachFor_126 = default;
V plan_127 = default;
V rigPaw_128 = default;
V release_129 = default;
V launch_130 = default;
V settle_131 = default;
V kickKey_132 = default;
V api_133 = default;
if (_self31.IsNullish) _self31 = GlobalV;
drawNet_71 = Fn((V _self134, int _argc135, V t_141, V _a138, V _a139, V _a140, V[] _rest136) => {
double k_142 = 0;
V pt_143 = default;
JsStrBuf d_144 = null;
V fb_145 = default;
if (_self134.IsNullish) _self134 = GlobalV;
Set(netG_56, "innerHTML", ((V)("")));
k_142 = ((ToNum(Get(bulge_70, "a")) * FdLibm.Exp(((-(ToNum(t_141) - ToNum(Get(bulge_70, "t")))) / 420D))) * (1D + (0.2 * FdLibm.Sin(((ToNum(t_141) - ToNum(Get(bulge_70, "t"))) / 60D)))));
pt_143 = Fn((V _arrowThis154, int _argc146, V x_152, V y_153, V _a150, V _a151, V[] _rest147) => {
double back_155 = 0;
double d_156 = 0;
double push_157 = 0;
back_155 = (ND_69 * (1D - ((ToNum(y_153) / GH_48) * 0.55)));
d_156 = Hypot((ToNum(x_152) - ToNum(Get(bulge_70, "x"))), (ToNum(y_153) - ToNum(Get(bulge_70, "y"))));
push_157 = ((k_142 * FdLibm.Exp((((-d_156) * d_156) / 0.3))) * 0.6);
return Call(P_44, V.Undef, x_152, y_153, ((V)(((GZ_46 + back_155) + push_157))));
return default;
}, 2, "", true);
d_144 = new JsStrBuf("");
{
double i_158 = 0;
i_158 = 0D;
while (true) {
if (!((i_158 <= NX_67))) break;
double x_160 = 0;
x_160 = ((-GW_47) + (((2D * GW_47) * i_158) / NX_67));
{
double j_161 = 0;
j_161 = 0D;
while (true) {
if (!((j_161 <= NY_68))) break;
double y_163 = 0;
V s_164 = default;
y_163 = ((GH_48 * j_161) / NY_68);
s_164 = Call(pt_143, V.Undef, ((V)(x_160)), ((V)(y_163)));
d_144.S((NumTruthy(j_161) ? "L" : "M")).V(Call(r2_20, V.Undef, GetIdx(s_164, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_164, 1D)));
j_161++;
}
}
i_158++;
}
}
{
double j_165 = 0;
j_165 = 0D;
while (true) {
if (!((j_165 <= NY_68))) break;
double y_167 = 0;
y_167 = ((GH_48 * j_165) / NY_68);
{
double i_168 = 0;
i_168 = 0D;
while (true) {
if (!((i_168 <= NX_67))) break;
double x_170 = 0;
V s_171 = default;
x_170 = ((-GW_47) + (((2D * GW_47) * i_168) / NX_67));
s_171 = Call(pt_143, V.Undef, ((V)(x_170)), ((V)(y_167)));
d_144.S((NumTruthy(i_168) ? "L" : "M")).V(Call(r2_20, V.Undef, GetIdx(s_171, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_171, 1D)));
i_168++;
}
}
j_165++;
}
}
{
double j_172 = 0;
j_172 = 0D;
while (true) {
if (!((j_172 <= NY_68))) break;
double y_174 = 0;
V a_175 = default;
V b_176 = default;
V c_177 = default;
V e_178 = default;
y_174 = ((GH_48 * j_172) / NY_68);
a_175 = Call(P_44, V.Undef, ((V)((-GW_47))), ((V)(y_174)), ((V)(GZ_46)));
b_176 = Call(pt_143, V.Undef, ((V)((-GW_47))), ((V)(y_174)));
c_177 = Call(P_44, V.Undef, ((V)(GW_47)), ((V)(y_174)), ((V)(GZ_46)));
e_178 = Call(pt_143, V.Undef, ((V)(GW_47)), ((V)(y_174)));
d_144.S("M").V(Call(r2_20, V.Undef, GetIdx(a_175, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_175, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(b_176, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(b_176, 1D))).S("M").V(Call(r2_20, V.Undef, GetIdx(c_177, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(c_177, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(e_178, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(e_178, 1D)));
j_172++;
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(d_144.Str))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.75))).V, netG_56);
fb_145 = Arr(Call(P_44, V.Undef, ((V)((-GW_47))), ((V)(0D)), ((V)((GZ_46 + ND_69)))), Call(P_44, V.Undef, ((V)((-GW_47))), ((V)((GH_48 * 0.95))), ((V)((GZ_46 + (ND_69 * 0.48))))), Call(P_44, V.Undef, ((V)(GW_47)), ((V)((GH_48 * 0.95))), ((V)((GZ_46 + (ND_69 * 0.48))))), Call(P_44, V.Undef, ((V)(GW_47)), ((V)(0D)), ((V)((GZ_46 + ND_69)))));
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(fb_145, "map", Fn((V _arrowThis186, int _argc179, V s_185, V _a182, V _a183, V _a184, V[] _rest180) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_185, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_185, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).End()))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#dfe6ee"))).Put("stroke-width", ((V)(2.6))).V, netG_56);
return default;
}, 1, "drawNet", false);
drawDots_111 = Fn((V _self187, int _argc188, V _a190, V _a191, V _a192, V _a193, V[] _rest189) => {
if (_self187.IsNullish) _self187 = GlobalV;
Set(dotsEl_110, "innerHTML", ((V)("")));
{
double i_194 = 0;
i_194 = 0D;
while (true) {
if (!((i_194 < 5D))) break;
V s_196 = default;
s_196 = Invoke(G("document"), "createElement", ((V)("span")));
Set(s_196, "textContent", ((V)((GetIdx(res_89, i_194).IsNullish ? "\u25cb" : (Truthy(GetIdx(res_89, i_194)) ? "\u25cf" : "\u2715")))));
Set(Get(s_196, "style"), "color", ((V)((GetIdx(res_89, i_194).IsNullish ? "#b9a8d6" : (Truthy(GetIdx(res_89, i_194)) ? "#2fb24a" : "#e8483c")))));
Invoke(dotsEl_110, "appendChild", s_196);
i_194++;
}
}
return default;
}, 0, "drawDots", false);
place_112 = Fn((V _self197, int _argc198, V _a200, V _a201, V _a202, V _a203, V[] _rest199) => {
V k_204 = default;
V kk_205 = default;
if (_self197.IsNullish) _self197 = GlobalV;
k_204 = Call(P_44, V.Undef, kx_105, ((V)(0D)), ((V)(KZ_51)));
Invoke(keeper_74, "set", GetIdx(k_204, 0D), ((V)((ToNum(GetIdx(k_204, 1D)) - (kH_106 * ToNum(GetIdx(k_204, 2D)))))), ((V)((1.15 * ToNum(GetIdx(k_204, 2D))))));
Invoke(keeper_74, "rot", th_107, ((V)(50D)), ((V)(55D)));
Invoke(keeper_74, "depth", ((V)(1D)));
Invoke(kShadow_79, "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, GetIdx(k_204, 0D)));
Invoke(kShadow_79, "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, GetIdx(k_204, 1D)));
Invoke(kShadow_79, "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)(((0.36 * ToNum(GetIdx(k_204, 2D))) * (1D - (0.35 * Min(1D, kH_106))))))));
kk_205 = Call(P_44, V.Undef, Get(kick_75, "wx"), ((V)(0D)), Get(kick_75, "wz"));
Invoke(kick_75, "set", GetIdx(kk_205, 0D), GetIdx(kk_205, 1D), ((V)((KS_78 * ToNum(GetIdx(kk_205, 2D))))));
Invoke(kick_75, "depth", ((V)(3D)));
Invoke(pShadow_80, "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, GetIdx(kk_205, 0D)));
Invoke(pShadow_80, "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, GetIdx(kk_205, 1D)));
Invoke(pShadow_80, "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)((0.24 * ToNum(GetIdx(kk_205, 2D)))))));
return default;
}, 0, "place", false);
resetShot_113 = Fn((V _self206, int _argc207, V _a209, V _a210, V _a211, V _a212, V[] _rest208) => {
if (_self206.IsNullish) _self206 = GlobalV;
ball_94 = NewObj(8).Put("x", GetIdx(B0_50, 0D)).Put("y", GetIdx(B0_50, 1D)).Put("z", GetIdx(B0_50, 2D)).Put("vx", ((V)(0D))).Put("vy", ((V)(0D))).Put("vz", ((V)(0D))).Put("st", ((V)("rest"))).Put("spin", ((V)(0D))).V;
Set(kick_75, "wx", GetIdx(RUN0_76, 0D));
Set(kick_75, "wz", GetIdx(RUN0_76, 1D));
kx_105 = ((V)(0D));
kH_106 = 0D;
th_107 = ((V)(0D));
dv_109 = V.Null;
Invoke(keeper_74, "play", ((V)("idle")));
Invoke(kick_75, "play", ((V)("idle")));
phase_91.Set("aim");
outcome_98 = V.Null;
shotS_100 = V.Null;
wind_99 = ((V)(0D));
trail_102 = Arr();
Set(trailG_61, "innerHTML", ((V)("")));
skill_97 = ((V)((0.3 + (shot_90 * 0.12))));
Invoke(ctx_38, "timer", ((V)(JsStrBuf.Begin().S("Kick ").N((shot_90 + 1D)).S("/5").End())));
Call(drawDots_111, V.Undef);
return default;
}, 0, "resetShot", false);
stepB_114 = Fn((V _self213, int _argc214, V b_220, V h_221, V t_222, V @out_223, V[] _rest215) => {
V pz_224 = default;
if (_self213.IsNullish) _self213 = GlobalV;
pz_224 = Get(b_220, "z");
OpSet(b_220, "vy", 1, ((V)((G_45 * ToNum(h_221)))));
OpSet(b_220, "x", 0, ((V)((ToNum(Get(b_220, "vx")) * ToNum(h_221)))));
OpSet(b_220, "y", 0, ((V)((ToNum(Get(b_220, "vy")) * ToNum(h_221)))));
OpSet(b_220, "z", 0, ((V)((ToNum(Get(b_220, "vz")) * ToNum(h_221)))));
if (LtN(Get(b_220, "y"), BR_49)) {
if (Truthy((@out_223 is var _t225 && !Truthy(_t225) ? _t225 : ((System.Math.Abs(ToNum(Get(b_220, "vy"))) > 1.2) ? V.True : V.False)))) {
Invoke(Get(@out_223, "ev"), "push", Arr(t_222, ((V)("bounce"))));
}
Set(b_220, "y", ((V)(BR_49)));
Set(b_220, "vy", ((V)((System.Math.Abs(ToNum(Get(b_220, "vy"))) * 0.45))));
OpSet(b_220, "vx", 2, ((V)(0.8)));
OpSet(b_220, "vz", 2, ((V)(0.8)));
}
if (Truthy((((@out_223 is var _t226 && !Truthy(_t226) ? _t226 : (!(Truthy(Get(@out_223, "tK"))) ? V.True : V.False)) is var _t227 && !Truthy(_t227) ? _t227 : (LtN(pz_224, KZ_51) ? V.True : V.False)) is var _t228 && !Truthy(_t228) ? _t228 : (GeN(Get(b_220, "z"), KZ_51) ? V.True : V.False)))) {
Set(@out_223, "tK", t_222);
Set(@out_223, "kAt", Arr(Get(b_220, "x"), Get(b_220, "y")));
}
if (((SEqS(Get(b_220, "st"), "fly") && LtN(pz_224, GZ_46)) && GeN(Get(b_220, "z"), GZ_46))) {
double ax_229 = 0;
ax_229 = System.Math.Abs(ToNum(Get(b_220, "x")));
if (Truthy(@out_223)) {
Set(@out_223, "cross", Arr(Get(b_220, "x"), Get(b_220, "y")));
}
if ((((System.Math.Abs((ax_229 - GW_47)) < (BR_49 + 0.05)) && LtN(Get(b_220, "y"), (GH_48 + 0.06))) || ((System.Math.Abs((ToNum(Get(b_220, "y")) - GH_48)) < (BR_49 + 0.05)) && (ax_229 < (GW_47 + 0.06))))) {
Set(b_220, "vz", ((V)(((-System.Math.Abs(ToNum(Get(b_220, "vz")))) * 0.5))));
OpSet(b_220, "vx", 0, ((V)(((((ax_229 < GW_47) ? (-1D) : 1D) * Sign(ToNum(Get(b_220, "x")))) * 1.4))));
Set(b_220, "st", ((V)("out")));
if (Truthy(@out_223)) {
Invoke(Get(@out_223, "ev"), "push", Arr(t_222, ((V)(((System.Math.Abs((ToNum(Get(b_220, "y")) - GH_48)) < 0.2) ? "bar" : "post")))));
Set(@out_223, "res", ((V)("wood")));
Set(@out_223, "tEnd", Add(t_222, ((V)(0.3))));
}
} else {
if (((ax_229 < GW_47) && LtN(Get(b_220, "y"), GH_48))) {
Set(b_220, "st", ((V)("net")));
if (Truthy(@out_223)) {
Invoke(Get(@out_223, "ev"), "push", Arr(t_222, ((V)("goal"))));
Set(@out_223, "res", ((V)("goal")));
Set(@out_223, "tEnd", Add(t_222, ((V)(0.12))));
}
} else {
Set(b_220, "st", ((V)("out")));
if (Truthy(@out_223)) {
Invoke(Get(@out_223, "ev"), "push", Arr(t_222, ((V)((GeN(Get(b_220, "y"), GH_48) ? "over" : "wide")))));
Set(@out_223, "res", ((V)((GeN(Get(b_220, "y"), GH_48) ? "over" : "wide"))));
Set(@out_223, "tEnd", Add(t_222, ((V)(0.22))));
}
}
}
}
if (SEqS(Get(b_220, "st"), "net")) {
if (GtN(Get(b_220, "z"), (GZ_46 + 0.7))) {
Set(b_220, "z", ((V)((GZ_46 + 0.7))));
Set(b_220, "vz", ((V)((-0.3))));
OpSet(b_220, "vx", 2, ((V)(0.3)));
}
if ((System.Math.Abs(ToNum(Get(b_220, "x"))) > (GW_47 - 0.12))) {
Set(b_220, "x", ((V)((Sign(ToNum(Get(b_220, "x"))) * (GW_47 - 0.12)))));
OpSet(b_220, "vx", 2, ((V)((-0.3))));
}
if (GtN(Get(b_220, "y"), (GH_48 - 0.12))) {
Set(b_220, "y", ((V)((GH_48 - 0.12))));
Set(b_220, "vy", ((V)(((-System.Math.Abs(ToNum(Get(b_220, "vy")))) * 0.3))));
}
}
return default;
}, 4, "stepB", false);
sim_115 = Fn((V _self230, int _argc231, V k_237, V a_238, V _a235, V _a236, V[] _rest232) => {
double X_239 = 0;
double Y_240 = 0;
double T_241 = 0;
double dz_242 = 0;
V b_243 = default;
V @out_244 = default;
double n_245 = 0;
if (_self230.IsNullish) _self230 = GlobalV;
X_239 = (ToNum(a_238) * 2.4);
Y_240 = (0.15 + (ToNum(k_237) * 2.35));
T_241 = (0.88 - (0.2 * ToNum(k_237)));
dz_242 = ((GZ_46 + 0.05) - ToNum(GetIdx(B0_50, 2D)));
b_243 = NewObj(7).Put("x", GetIdx(B0_50, 0D)).Put("y", GetIdx(B0_50, 1D)).Put("z", GetIdx(B0_50, 2D)).Put("vx", ((V)(((X_239 - ToNum(GetIdx(B0_50, 0D))) / T_241)))).Put("vz", ((V)((dz_242 / T_241)))).Put("vy", ((V)((((Y_240 - ToNum(GetIdx(B0_50, 1D))) + (((0.5 * G_45) * T_241) * T_241)) / T_241)))).Put("st", ((V)("fly"))).V;
@out_244 = NewObj(9).Put("pos", Arr()).Put("ev", Arr()).Put("k", k_237).Put("a", a_238).Put("res", V.Null).Put("cross", V.Null).Put("tEnd", ((V)(1.3))).Put("tK", ((V)(0D))).Put("kAt", V.Null).V;
n_245 = Round((LIFE_87 / DT_86));
{
double i_246 = 0;
i_246 = 0D;
while (true) {
if (!((i_246 <= n_245))) break;
Invoke(Get(@out_244, "pos"), "push", Arr(Get(b_243, "x"), Get(b_243, "y"), Get(b_243, "z")));
Call(stepB_114, V.Undef, b_243, ((V)(DT_86)), ((V)((i_246 * DT_86))), @out_244);
i_246++;
}
}
return @out_244;
return default;
}, 2, "sim", false);
pullOf_117 = Fn((V _self248, int _argc249, V d_255, V _a252, V _a253, V _a254, V[] _rest250) => {
double len_256 = 0;
if (_self248.IsNullish) _self248 = GlobalV;
len_256 = Hypot(ToNum(Get(d_255, "x")), ToNum(Get(d_255, "y")));
if ((LtN(Get(d_255, "y"), 6D) || (len_256 < 16D))) {
return V.Null;
}
return NewObj(2).Put("k", Call(cl_18, V.Undef, ((V)(((len_256 - 16D) / PULL_85))), ((V)(0D)), ((V)(1D)))).Put("a", Call(cl_18, V.Undef, ((V)((((-ToNum(Get(d_255, "x"))) / Max(60D, ToNum(Get(d_255, "y")))) * 0.9))), ((V)((-1.2))), ((V)(1.2)))).V;
return default;
}, 1, "pullOf", false);
drawPath_118 = Fn((V _self257, int _argc258, V S1_264, V _a261, V _a262, V _a263, V[] _rest259) => {
if (_self257.IsNullish) _self257 = GlobalV;
Set(pathG_65, "innerHTML", ((V)("")));
Set(bandG_66, "innerHTML", ((V)("")));
if (!(Truthy(aim_95))) {
return default;
}
if (Truthy(S1_264)) {
V lx_265 = default;
V ly_266 = default;
lx_265 = ((V)((-1000000000D)));
ly_266 = ((V)(0D));
{
double t_267 = 0;
t_267 = 0.02;
while (true) {
if (!(Le(((V)(t_267)), Get(S1_264, "tEnd")))) break;
V p_269 = default;
V s_270 = default;
V r_271 = default;
p_269 = Call(posAt_116, V.Undef, S1_264, ((V)(t_267)));
s_270 = Call(P_44, V.Undef, GetIdx(p_269, 0D), GetIdx(p_269, 1D), GetIdx(p_269, 2D));
if ((Hypot((ToNum(GetIdx(s_270, 0D)) - ToNum(lx_265)), (ToNum(GetIdx(s_270, 1D)) - ToNum(ly_266))) < 11D)) {
goto _cont268;
}
lx_265 = GetIdx(s_270, 0D);
ly_266 = GetIdx(s_270, 1D);
r_271 = Call(cl_18, V.Undef, ((V)(((3.4 * ToNum(GetIdx(s_270, 2D))) / 150D))), ((V)(1.8)), ((V)(3.6)));
Call(S_17, V.Undef, ((V)("circle")), NewObj(5).Put("cx", Call(r2_20, V.Undef, GetIdx(s_270, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(s_270, 1D))).Put("r", Call(r2_20, V.Undef, Add(r_271, ((V)(1.1))))).Put("fill", ((V)("#1e1430"))).Put("opacity", ((V)(0.3))).V, pathG_65);
Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_20, V.Undef, GetIdx(s_270, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(s_270, 1D))).Put("r", Call(r2_20, V.Undef, r_271)).Put("fill", ((V)("#ffffff"))).V, pathG_65);
_cont268: ;
t_267 = (t_267 + (1D / 240D));
}
}
if (Truthy(Get(S1_264, "cross"))) {
V c_272 = default;
double r_273 = 0;
c_272 = Call(P_44, V.Undef, GetIdx(Get(S1_264, "cross"), 0D), GetIdx(Get(S1_264, "cross"), 1D), ((V)(GZ_46)));
r_273 = ((BR_49 * ToNum(GetIdx(c_272, 2D))) + 3D);
Call(S_17, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_20, V.Undef, GetIdx(c_272, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(c_272, 1D))).Put("r", Call(r2_20, V.Undef, ((V)((r_273 + 1.2))))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#1e1430"))).Put("stroke-width", ((V)(3.6))).Put("opacity", ((V)(0.25))).V, pathG_65);
Call(S_17, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_20, V.Undef, GetIdx(c_272, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(c_272, 1D))).Put("r", Call(r2_20, V.Undef, ((V)(r_273)))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.95))).V, pathG_65);
}
Call(S_17, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, Get(aim_95, "x0"))).S(" ").V(Call(r2_20, V.Undef, Get(aim_95, "y0"))).S("L").V(Call(r2_20, V.Undef, Get(aim_95, "x"))).S(" ").V(Call(r2_20, V.Undef, Get(aim_95, "y"))).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(3D))).Put("stroke-dasharray", ((V)("2 6"))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.8))).V, bandG_66);
}
Call(S_17, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_20, V.Undef, Get(aim_95, "x0"))).Put("cy", Call(r2_20, V.Undef, Get(aim_95, "y0"))).Put("r", ((V)(6D))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)((Truthy(S1_264) ? 0.85 : 0.6)))).V, bandG_66);
if (Truthy(S1_264)) {
Call(S_17, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_20, V.Undef, Get(aim_95, "x"))).Put("cy", Call(r2_20, V.Undef, Get(aim_95, "y"))).Put("r", ((V)(9D))).Put("fill", ((V)("#5cc2ff"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.95))).V, bandG_66);
}
return default;
}, 1, "drawPath", false);
segD_124 = Fn((V _self274, int _argc275, V p_281, V a_282, V b_283, V _a280, V[] _rest276) => {
double vx_284 = 0;
double vy_285 = 0;
V u_286 = default;
if (_self274.IsNullish) _self274 = GlobalV;
vx_284 = (ToNum(GetIdx(b_283, 0D)) - ToNum(GetIdx(a_282, 0D)));
vy_285 = (ToNum(GetIdx(b_283, 1D)) - ToNum(GetIdx(a_282, 1D)));
u_286 = Call(cl_18, V.Undef, ((V)(((((ToNum(GetIdx(p_281, 0D)) - ToNum(GetIdx(a_282, 0D))) * vx_284) + ((ToNum(GetIdx(p_281, 1D)) - ToNum(GetIdx(a_282, 1D))) * vy_285)) / ((vx_284 * vx_284) + (vy_285 * vy_285))))), ((V)(0D)), ((V)(1D)));
return ((V)(Hypot(((ToNum(GetIdx(p_281, 0D)) - ToNum(GetIdx(a_282, 0D))) - (vx_284 * ToNum(u_286))), ((ToNum(GetIdx(p_281, 1D)) - ToNum(GetIdx(a_282, 1D))) - (vy_285 * ToNum(u_286))))));
return default;
}, 3, "segD", false);
clear_125 = Fn((V _self287, int _argc288, V bp_294, V x_295, V h_296, V t_297, V[] _rest289) => {
V pv_299 = default;
V u_300 = default;
V a_301 = default;
V b_302 = default;
V s_298 = default;
if (_self287.IsNullish) _self287 = GlobalV;
s_298 = (_argc288 > 4 ? _rest289[0] : V.Undef);
pv_299 = Call(pivOf_122, V.Undef, x_295, h_296);
u_300 = Arr(((V)(FdLibm.Sin((ToNum(t_297) * D2R_119)))), ((V)(FdLibm.Cos((ToNum(t_297) * D2R_119)))));
a_301 = Arr(((V)((ToNum(GetIdx(pv_299, 0D)) - (ToNum(GetIdx(u_300, 0D)) * PIV_120)))), ((V)((ToNum(GetIdx(pv_299, 1D)) - (ToNum(GetIdx(u_300, 1D)) * PIV_120)))));
b_302 = Arr(Add(GetIdx(pv_299, 0D), ((V)((ToNum(GetIdx(u_300, 0D)) * 0.62)))), Add(GetIdx(pv_299, 1D), ((V)((ToNum(GetIdx(u_300, 1D)) * 0.62)))));
return ((V)((Min((ToNum(Call(segD_124, V.Undef, bp_294, a_301, b_302)) - 0.4), (Truthy(s_298) ? (Hypot((ToNum(GetIdx(bp_294, 0D)) - ToNum(GetIdx(Call(pawOf_123, V.Undef, pv_299, s_298, t_297), 0D))), (ToNum(GetIdx(bp_294, 1D)) - ToNum(GetIdx(Call(pawOf_123, V.Undef, pv_299, s_298, t_297), 1D)))) - 0.12) : 9D)) - BR_49)));
return default;
}, 5, "clear", false);
reachFor_126 = Fn((V _self303, int _argc304, V bp_310, V s_311, V _a308, V _a309, V[] _rest305) => {
V dy_312 = default;
double dx_313 = 0;
V pv_314 = default;
double phi_315 = 0;
double t_316 = 0;
double h_317 = 0;
if (_self303.IsNullish) _self303 = GlobalV;
dy_312 = Call(cl_18, V.Undef, ((V)((ToNum(GetIdx(bp_310, 1D)) - ToNum(Call(cl_18, V.Undef, ((V)((ToNum(GetIdx(bp_310, 1D)) - 0.12))), ((V)((PIV_120 + 0.06))), ((V)(1.34))))))), ((V)((-0.5))), ((V)(0.38)));
dx_313 = (ToNum(s_311) * System.Math.Sqrt(((REACH_121 * REACH_121) - (ToNum(dy_312) * ToNum(dy_312)))));
pv_314 = Arr(((V)((ToNum(GetIdx(bp_310, 0D)) - dx_313))), ((V)((ToNum(GetIdx(bp_310, 1D)) - ToNum(dy_312)))));
phi_315 = (FdLibm.Atan2(ToNum(dy_312), dx_313) / D2R_119);
t_316 = (LtN(s_311, 0D) ? (180D - phi_315) : (-phi_315));
t_316 = (((t_316 + 540D) % 360D) - 180D);
h_317 = (ToNum(GetIdx(pv_314, 1D)) - PIV_120);
if (((((System.Math.Abs(t_316) > 56D) || (h_317 < (-0.01))) || (h_317 > 0.92)) || (System.Math.Abs((ToNum(GetIdx(pv_314, 0D)) - kx0_108)) > 1.45))) {
return V.Null;
}
return Arr(GetIdx(pv_314, 0D), ((V)(Max(0D, h_317))), ((V)(t_316)));
return default;
}, 2, "reachFor", false);
plan_127 = Fn((V _self318, int _argc319, V S1_325, V _a322, V _a323, V _a324, V[] _rest320) => {
V tK_326 = default;
V bp_327 = default;
V onT_328 = default;
double side_329 = 0;
double corner_330 = 0;
V read_331 = default;
V p_332 = default;
if (_self318.IsNullish) _self318 = GlobalV;
tK_326 = (Get(S1_325, "tK") is var _t333 && Truthy(_t333) ? _t333 : ((V)(0.7)));
bp_327 = (Get(S1_325, "kAt") is var _t334 && Truthy(_t334) ? _t334 : Arr(((V)((ToNum(Get(S1_325, "a")) * 2.2))), ((V)(0.8))));
onT_328 = (SEqS(Get(S1_325, "res"), "goal") ? V.True : V.False);
side_329 = ((System.Math.Abs((ToNum(GetIdx(bp_327, 0D)) - kx0_108)) < 0.32) ? 0D : Sign((ToNum(GetIdx(bp_327, 0D)) - kx0_108)));
corner_330 = ((ToNum(Call(cl_18, V.Undef, ((V)(((System.Math.Abs(ToNum(GetIdx(bp_327, 0D))) - 0.9) / 0.9))), ((V)(0D)), ((V)(1D)))) * 0.5) + (ToNum(Call(cl_18, V.Undef, ((V)(((ToNum(GetIdx(bp_327, 1D)) - 1.1) / 0.6))), ((V)(0D)), ((V)(1D)))) * 0.35));
read_331 = (Lt(Invoke(G("Math"), "random"), skill_97) ? V.True : V.False);
p_332 = V.Null;
if (Truthy((read_331 is var _t335 && !Truthy(_t335) ? _t335 : ((V)(side_329))))) {
V r_336 = default;
r_336 = Call(reachFor_126, V.Undef, bp_327, ((V)(side_329)));
if (Truthy((r_336 is var _t337 && !Truthy(_t337) ? _t337 : (GtN(Invoke(G("Math"), "random"), corner_330) ? V.True : V.False)))) {
p_332 = NewObj(5).Put("kind", ((V)("save"))).Put("s", ((V)(side_329))).Put("x", GetIdx(r_336, 0D)).Put("h", GetIdx(r_336, 1D)).Put("t", GetIdx(r_336, 2D)).V;
} else {
V r2__338 = default;
r2__338 = ((r_336 is var _t339 && Truthy(_t339) ? _t339 : Call(reachFor_126, V.Undef, Arr(((V)(((kx0_108 + (side_329 * 1.45)) + ((side_329 * REACH_121) * 0.8)))), Call(cl_18, V.Undef, GetIdx(bp_327, 1D), ((V)(0.3)), ((V)(1.6)))), ((V)(side_329)))) is var _t340 && Truthy(_t340) ? _t340 : Arr(((V)((kx0_108 + (side_329 * 1.1)))), ((V)(0.25)), ((V)((side_329 * 30D)))));
p_332 = NewObj(5).Put("kind", ((V)("beaten"))).Put("s", ((V)(side_329))).Put("x", ((V)((ToNum(GetIdx(r2__338, 0D)) - (side_329 * 0.55))))).Put("h", GetIdx(r2__338, 1D)).Put("t", GetIdx(r2__338, 2D)).V;
}
} else {
if (Truthy((read_331 is var _t341 && Truthy(_t341) ? _t341 : (LtN(Invoke(G("Math"), "random"), 0.3) ? V.True : V.False)))) {
p_332 = NewObj(5).Put("kind", ((V)("stay"))).Put("s", ((V)(0D))).Put("x", ((V)((kx0_108 + ((ToNum(GetIdx(bp_327, 0D)) - kx0_108) * 0.3))))).Put("h", Call(cl_18, V.Undef, ((V)((ToNum(GetIdx(bp_327, 1D)) - 0.9))), ((V)(0.05)), ((V)(0.55)))).Put("t", ((V)(0D))).V;
} else {
double s_342 = 0;
s_342 = (LtN(Invoke(G("Math"), "random"), 0.5) ? (-1D) : 1D);
p_332 = NewObj(5).Put("kind", ((V)("guess"))).Put("s", ((V)(s_342))).Put("x", ((V)((kx0_108 + (s_342 * 1D))))).Put("h", ((V)(0.22))).Put("t", ((V)((s_342 * 34D)))).V;
}
}
if (!SEqS(Get(p_332, "kind"), "save")) {
V c_343 = default;
double n_344 = 0;
c_343 = Call(clear_125, V.Undef, bp_327, Get(p_332, "x"), Get(p_332, "h"), Get(p_332, "t"), Get(p_332, "s"));
n_344 = 0D;
if (SEqS(Get(p_332, "kind"), "beaten")) {
while ((LtN(c_343, 0.12) && (n_344++ < 12D))) {
OpSet(p_332, "x", 1, ((V)((ToNum(Get(p_332, "s")) * 0.08))));
c_343 = Call(clear_125, V.Undef, bp_327, Get(p_332, "x"), Get(p_332, "h"), Get(p_332, "t"), Get(p_332, "s"));
}
} else {
if (LtN(c_343, 0.05)) {
Set(p_332, "kind", ((V)("block")));
}
}
}
if ((!(Truthy(onT_328)) && SEqS(Get(p_332, "kind"), "save"))) {
Set(p_332, "kind", ((V)("tip")));
}
Set(p_332, "tK", tK_326);
Set(p_332, "bp", bp_327);
Set(p_332, "t0", ((V)((0.12 + (ToNum(Invoke(G("Math"), "random")) * 0.08)))));
Set(p_332, "dur", ((V)(Max(0.28, (ToNum(tK_326) - ToNum(Get(p_332, "t0")))))));
return p_332;
return default;
}, 1, "plan", false);
rigPaw_128 = Fn((V _self345, int _argc346, V s_352, V _a349, V _a350, V _a351, V[] _rest347) => {
V I_353 = default;
V w_354 = default;
V sz_355 = default;
double left_356 = 0;
double top_357 = 0;
V q_358 = default;
V o_359 = default;
double r_360 = 0;
double dx_361 = 0;
double dy_362 = 0;
if (_self345.IsNullish) _self345 = GlobalV;
I_353 = Get(keeper_74, "I");
w_354 = ((I_353 is var _t363 && !Truthy(_t363) ? _t363 : Get(I_353, "W")) is var _t364 && !Truthy(_t364) ? _t364 : (LtN(s_352, 0D) ? Get(Get(I_353, "W"), "pawL") : (GtN(s_352, 0D) ? Get(Get(I_353, "W"), "pawR") : V.Null)));
sz_355 = Get(keeper_74, "size");
left_356 = (ToNum(Get(keeper_74, "x")) - (ToNum(sz_355) / 2D));
top_357 = (ToNum(Get(keeper_74, "y")) - (ToNum(sz_355) * 0.93));
q_358 = (Truthy((w_354 is var _t365 && !Truthy(_t365) ? _t365 : (IsFiniteV(GetIdx(w_354, 0D)) ? V.True : V.False))) ? Arr(((V)((left_356 + ((ToNum(GetIdx(w_354, 0D)) / 100D) * ToNum(sz_355))))), ((V)((top_357 + ((ToNum(GetIdx(w_354, 1D)) / 100D) * ToNum(sz_355)))))) : Arr(((V)((left_356 + (ToNum(sz_355) * 0.5)))), ((V)((top_357 + (ToNum(sz_355) * 0.55))))));
o_359 = Arr(((V)((left_356 + (ToNum(sz_355) * 0.5)))), ((V)((top_357 + (ToNum(sz_355) * 0.55)))));
r_360 = (ToNum(th_107) * D2R_119);
dx_361 = (ToNum(GetIdx(q_358, 0D)) - ToNum(GetIdx(o_359, 0D)));
dy_362 = (ToNum(GetIdx(q_358, 1D)) - ToNum(GetIdx(o_359, 1D)));
return Call(toW_53, V.Undef, ((V)((ToNum(Add(GetIdx(o_359, 0D), ((V)((dx_361 * FdLibm.Cos(r_360)))))) - (dy_362 * FdLibm.Sin(r_360))))), Add(Add(GetIdx(o_359, 1D), ((V)((dx_361 * FdLibm.Sin(r_360))))), ((V)((dy_362 * FdLibm.Cos(r_360))))), ((V)(KZ_51)));
return default;
}, 1, "rigPaw", false);
release_129 = Fn((V _self366, int _argc367, V k_373, V a_374, V S0_375, V _a372, V[] _rest368) => {
if (_self366.IsNullish) _self366 = GlobalV;
if (!string.Equals(phase_91.Str, "aim")) {
return default;
}
shotS_100 = (Truthy(((S0_375 is var _t376 && !Truthy(_t376) ? _t376 : (SEq(Get(S0_375, "k"), k_373) ? V.True : V.False)) is var _t377 && !Truthy(_t377) ? _t377 : (SEq(Get(S0_375, "a"), a_374) ? V.True : V.False))) ? S0_375 : Call(sim_115, V.Undef, k_373, a_374));
aim_95 = V.Null;
Call(drawPath_118, V.Undef, V.Null);
phase_91.Set("run");
ph0_92 = tNow_93;
runFrom_96 = Arr(Get(kick_75, "wx"), Get(kick_75, "wz"));
Invoke(SFX_22, "tap");
return default;
}, 3, "release", false);
launch_130 = Fn((V _self378, int _argc379, V _a381, V _a382, V _a383, V _a384, V[] _rest380) => {
V s_385 = default;
if (_self378.IsNullish) _self378 = GlobalV;
Set(ball_94, "st", ((V)("fly")));
Set(ball_94, "S", shotS_100);
Set(ball_94, "tl", tNow_93);
Set(ball_94, "fired", ((V)(0D)));
Set(ball_94, "live", ((V)(0D)));
Set(ball_94, "snap", V.Null);
kickT_103 = tNow_93;
Invoke(SFX_22, "thud");
Call(G("setTimeout"), V.Undef, Get(SFX_22, "whoosh"), ((V)(40D)));
s_385 = Call(P_44, V.Undef, Get(ball_94, "x"), Get(ball_94, "y"), Get(ball_94, "z"));
Invoke(ctx_38, "burst", GetIdx(s_385, 0D), Add(GetIdx(s_385, 1D), ((V)(4D))), ((V)("dust")), ((V)(7D)), NewObj(3).Put("v", ((V)(70D))).Put("life", ((V)(0.6))).Put("layer", fxG_63).V);
Invoke(ctx_38, "burst", GetIdx(s_385, 0D), GetIdx(s_385, 1D), ((V)("star")), ((V)(6D)), NewObj(4).Put("v", ((V)(150D))).Put("life", ((V)(0.45))).Put("layer", fxG_63).Put("col", ((V)("#fff6c8"))).V);
dv_109 = Call(plan_127, V.Undef, shotS_100);
Set(dv_109, "at", tNow_93);
Set(dv_109, "from", Arr(kx_105, ((V)(kH_106)), th_107));
phase_91.Set("fly");
return default;
}, 0, "launch", false);
settle_131 = Fn((V _self386, int _argc387, V goal_393, V txt_394, V col_395, V _a392, V[] _rest388) => {
if (_self386.IsNullish) _self386 = GlobalV;
if (Truthy(outcome_98)) {
return default;
}
outcome_98 = ((V)((Truthy(goal_393) ? "goal" : "miss")));
SetIdx(res_89, shot_90, ((V)((Truthy(goal_393) ? 1D : 0D))));
Call(drawDots_111, V.Undef);
phase_91.Set("after");
ph0_92 = tNow_93;
if (Truthy(goal_393)) {
double pts_396 = 0;
V corner_397 = default;
V top_398 = default;
V g_399 = default;
pts_396 = 100D;
corner_397 = ((System.Math.Abs(ToNum(Get(ball_94, "x"))) > 1.2) ? V.True : V.False);
top_398 = (GtN(Get(ball_94, "y"), 1.25) ? V.True : V.False);
if (Truthy(corner_397)) {
pts_396 = (pts_396 + 50D);
}
if (Truthy(top_398)) {
pts_396 = (pts_396 + 50D);
}
g_399 = Call(P_44, V.Undef, Get(ball_94, "x"), Get(ball_94, "y"), ((V)(GZ_46)));
Invoke(ctx_38, "add", ((V)(pts_396)), ((V)((ToNum(W_41) / 2D))), ((V)((ToNum(H_42) * 0.42))), ((V)(JsStrBuf.Begin().S((Truthy((corner_397 is var _t400 && !Truthy(_t400) ? _t400 : top_398)) ? "Top corner! " : (Truthy(corner_397) ? "Corner! " : (Truthy(top_398) ? "Top shelf! " : "Goal! ")))).S("+").N(pts_396).End())), ((V)("#ffe36e")));
Invoke(ctx_38, "burst", GetIdx(g_399, 0D), GetIdx(g_399, 1D), ((V)("confetti")), ((V)(22D)), NewObj(2).Put("v", ((V)(170D))).Put("layer", fxG_63).V);
Invoke(SFX_22, "score");
Invoke(kick_75, "play", ((V)("happy")));
Invoke(keeper_74, "play", ((V)("surprised")));
} else {
Invoke(ctx_38, "toast", txt_394, ((V)((ToNum(W_41) / 2D))), ((V)((ToNum(H_42) * 0.42))), (col_395 is var _t401 && Truthy(_t401) ? _t401 : ((V)("#ffffff"))), (true ? V.True : V.False));
Invoke(SFX_22, "miss");
if (SEqS(txt_394, "Saved!")) {
Invoke(keeper_74, "play", ((V)("happy")));
}
Invoke(kick_75, "play", ((V)("surprised")));
}
return default;
}, 3, "settle", false);
{ V _t402 = ctx_38;
if (_t402.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t402));
{ V _t403 = Get(_t402, "bg");
bg_39 = _t403; }
{ V _t404 = Get(_t402, "fg");
fg_40 = _t404; }
{ V _t405 = Get(_t402, "W");
W_41 = _t405; }
{ V _t406 = Get(_t402, "H");
H_42 = _t406; } }
CAM_43 = Arr(((V)(4D)), ((V)(0.984)), ((V)(144D)), ((V)(198D)));
P_44 = InvokeSpread(YG_16, "cam", new ArrBuilder().Spread(CAM_43).V);
G_45 = 9.8;
GZ_46 = 7D;
GW_47 = 1.9;
GH_48 = 1.9;
BR_49 = 0.11;
B0_50 = Arr(((V)(0D)), ((V)(BR_49)), ((V)(1D)));
KZ_51 = (GZ_46 - 0.45);
SM_52 = Get(YG_16, "SM");
toW_53 = Fn((V _arrowThis416, int _argc407, V sx_413, V sy_414, V z_415, V _a412, V[] _rest408) => {
double k_417 = 0;
k_417 = ((ToNum(GetIdx(CAM_43, 0D)) / ToNum(Add(GetIdx(CAM_43, 0D), z_415))) * ToNum(GetIdx(CAM_43, 3D)));
return Arr(((V)(((ToNum(sx_413) - (ToNum(W_41) / 2D)) / k_417))), ((V)((ToNum(GetIdx(CAM_43, 1D)) - ((ToNum(sy_414) - ToNum(GetIdx(CAM_43, 2D))) / k_417)))));
return default;
}, 3, "", true);
Invoke(YG_16, "yard", bg_39, NewObj(1).Put("hz", GetIdx(CAM_43, 2D)).V);
line_54 = Fn((V _arrowThis428, int _argc418, V pts_424, V w_425, V p_426, V op_427, V[] _rest419) => {
return Call(S_17, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_424, "map", Fn((V _arrowThis436, int _argc429, V q_435, V _a432, V _a433, V _a434, V[] _rest430) => {
V s_437 = default;
s_437 = Call(P_44, V.Undef, GetIdx(q_435, 0D), ((V)(0D)), GetIdx(q_435, 1D));
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_437, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_437, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", (w_425 is var _t438 && Truthy(_t438) ? _t438 : ((V)(2.5)))).Put("opacity", (op_427 is var _t439 && Truthy(_t439) ? _t439 : ((V)(0.9)))).Put("stroke-linejoin", ((V)("round"))).V, (p_426 is var _t440 && Truthy(_t440) ? _t440 : bg_39));
}, 4, "", true);
{
double i_441 = 0;
i_441 = 0D;
while (true) {
if (!((i_441 < 9D))) break;
double z0_443 = 0;
V a_444 = default;
V b_445 = default;
V c_446 = default;
V d_447 = default;
z0_443 = ((-1.2) + (i_441 * 1.1));
a_444 = Call(P_44, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)(z0_443)));
b_445 = Call(P_44, V.Undef, ((V)(14D)), ((V)(0D)), ((V)(z0_443)));
c_446 = Call(P_44, V.Undef, ((V)(14D)), ((V)(0D)), ((V)((z0_443 + 0.55))));
d_447 = Call(P_44, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)((z0_443 + 0.55))));
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Arr(a_444, b_445, c_446, d_447), "map", Fn((V _arrowThis455, int _argc448, V s_454, V _a451, V _a452, V _a453, V[] _rest449) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_454, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_454, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.07))).V, bg_39);
i_441++;
}
}
Call(line_54, V.Undef, Arr(Arr(((V)((-6D))), ((V)(GZ_46))), Arr(((V)(6D)), ((V)(GZ_46)))));
Call(line_54, V.Undef, Arr(Arr(((V)((-3.1))), ((V)(GZ_46))), Arr(((V)((-3.1))), ((V)((GZ_46 - 2.2)))), Arr(((V)(3.1)), ((V)((GZ_46 - 2.2)))), Arr(((V)(3.1)), ((V)(GZ_46)))));
Call(line_54, V.Undef, Arr(Arr(((V)((-2.4))), ((V)(GZ_46))), Arr(((V)((-2.4))), ((V)((GZ_46 - 0.8)))), Arr(((V)(2.4)), ((V)((GZ_46 - 0.8)))), Arr(((V)(2.4)), ((V)(GZ_46)))), ((V)(2D)), bg_39, ((V)(0.7)));
Call(line_54, V.Undef, Arr(Arr(((V)((-5.2))), ((V)(GZ_46))), Arr(((V)((-5.2))), ((V)((-1.2))))), ((V)(2D)), bg_39, ((V)(0.5)));
Call(line_54, V.Undef, Arr(Arr(((V)(5.2)), ((V)(GZ_46))), Arr(((V)(5.2)), ((V)((-1.2))))), ((V)(2D)), bg_39, ((V)(0.5)));
{
JsStrBuf d_456 = null;
d_456 = new JsStrBuf("");
{
double i_457 = 0;
i_457 = 0D;
while (true) {
if (!((i_457 <= 18D))) break;
double a_459 = 0;
V s_460 = default;
a_459 = ((System.Math.PI * i_457) / 18D);
s_460 = Call(P_44, V.Undef, ((V)((FdLibm.Cos(a_459) * 1.1))), ((V)(0D)), ((V)(((GZ_46 - 2.2) - (FdLibm.Sin(a_459) * 0.7)))));
d_456.S((NumTruthy(i_457) ? "L" : "M")).V(Call(r2_20, V.Undef, GetIdx(s_460, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_460, 1D)));
i_457++;
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(d_456.Str))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.2))).Put("opacity", ((V)(0.8))).V, bg_39);
}
spot_55 = Call(P_44, V.Undef, ((V)(0D)), ((V)(0D)), GetIdx(B0_50, 2D));
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", GetIdx(spot_55, 0D)).Put("cy", GetIdx(spot_55, 1D)).Put("rx", ((V)(9D))).Put("ry", ((V)(2.6))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.9))).V, bg_39);
netG_56 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_39);
shG_57 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_39);
postG_58 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, fg_40);
ballSlotBack_59 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_39);
ballL_60 = Call(S_17, V.Undef, ((V)("svg")), NewObj(4).Put("viewBox", ((V)(JsStrBuf.Begin().S("0 0 ").V(W_41).S(" ").V(H_42).End()))).Put("class", ((V)("yg-layer"))).Put("preserveAspectRatio", ((V)("none"))).Put("style", ((V)("pointer-events:none;z-index:2"))).V, Get(fg_40, "parentNode"));
trailG_61 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, ballL_60);
ballSlot_62 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, ballL_60);
fxG_63 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, ballL_60);
aimL_64 = Call(S_17, V.Undef, ((V)("svg")), NewObj(4).Put("viewBox", ((V)(JsStrBuf.Begin().S("0 0 ").V(W_41).S(" ").V(H_42).End()))).Put("class", ((V)("yg-layer"))).Put("preserveAspectRatio", ((V)("none"))).Put("style", ((V)("pointer-events:none;z-index:4"))).V, Get(fg_40, "parentNode"));
pathG_65 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, aimL_64);
bandG_66 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, aimL_64);
NX_67 = 18D;
NY_68 = 9D;
ND_69 = 1.1;
bulge_70 = NewObj(4).Put("x", ((V)(0D))).Put("y", ((V)(0D))).Put("a", ((V)(0D))).Put("t", ((V)((-9D)))).V;
{
V a_461 = default;
V b_462 = default;
V c_463 = default;
V d_464 = default;
double w_465 = 0;
V pth_466 = default;
a_461 = Call(P_44, V.Undef, ((V)((-GW_47))), ((V)(0D)), ((V)(GZ_46)));
b_462 = Call(P_44, V.Undef, ((V)((-GW_47))), ((V)(GH_48)), ((V)(GZ_46)));
c_463 = Call(P_44, V.Undef, ((V)(GW_47)), ((V)(GH_48)), ((V)(GZ_46)));
d_464 = Call(P_44, V.Undef, ((V)(GW_47)), ((V)(0D)), ((V)(GZ_46)));
w_465 = (0.08 * ToNum(GetIdx(a_461, 2D)));
pth_466 = ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(a_461, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_461, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(b_462, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(b_462, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(c_463, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(c_463, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(d_464, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(d_464, 1D))).End()));
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", pth_466).Put("fill", ((V)("none"))).Put("stroke", ((V)("#c9d2dc"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)((w_465 + 1.6))))).Put("stroke-linejoin", ((V)("round"))).V, postG_58);
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", pth_466).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)(w_465)))).Put("stroke-linejoin", ((V)("round"))).V, postG_58);
}
kp_72 = Invoke(ctx_38, "opponent");
kpName_73 = Invoke(ctx_38, "nameOf", kp_72);
keeper_74 = Invoke(ctx_38, "creature", kp_72, NewObj(1).Put("yaw", ((V)(0D))).V);
kick_75 = Invoke(ctx_38, "creature", Get(ctx_38, "playerKey"), NewObj(1).Put("yaw", ((V)(160D))).V);
RUN0_76 = Arr(((V)((-1D))), ((V)((-0.25))));
KICKAT_77 = Arr(((V)((-0.45))), ((V)(0.8)));
KS_78 = 0.55;
kShadow_79 = Invoke(YG_16, "shadow", shG_57, ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(0.2)));
pShadow_80 = Invoke(YG_16, "shadow", shG_57, ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(0.2)));
bShadow_81 = Call(S_17, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#3a2a55"))).Put("opacity", ((V)(0.2))).V, shG_57);
bG_82 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, ballSlot_62);
bC_83 = Call(S_17, V.Undef, ((V)("circle")), NewObj(3).Put("fill", ((V)("url(#ygWhite)"))).Put("stroke", ((V)("#3a3a44"))).Put("stroke-width", ((V)(1D))).V, bG_82);
bP_84 = Call(S_17, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#3a3a44"))).V, bG_82);
PULL_85 = 150D;
DT_86 = (1D / 240D);
LIFE_87 = 2.6;
RUN_88 = 760D;
res_89 = Arr();
shot_90 = 0D;
phase_91 = new JsStrBuf("aim");
ph0_92 = ((V)(0D));
tNow_93 = ((V)(0D));
ball_94 = V.Null;
aim_95 = V.Null;
runFrom_96 = V.Null;
skill_97 = ((V)(0.35));
outcome_98 = V.Null;
wind_99 = ((V)(0D));
shotS_100 = V.Null;
quietAt_101 = ((V)(0D));
trail_102 = Arr();
kickT_103 = ((V)((-9D)));
dropAt_104 = ((V)(0D));
kx_105 = ((V)(0D));
kH_106 = 0D;
th_107 = ((V)(0D));
kx0_108 = 0D;
dv_109 = V.Null;
dotsEl_110 = Invoke(G("document"), "createElement", ((V)("div")));
Set(dotsEl_110, "className", ((V)("yg-pill")));
Set(Get(dotsEl_110, "style"), "cssText", ((V)("position:absolute;left:50%;top:12.5%;transform:translateX(-50%);display:flex;gap:6px;padding:6px 10px;font-size:14px;")));
Invoke(Invoke(Get(Get(ctx_38, "crl"), "parentNode"), "querySelector", ((V)(".yg-hud"))), "appendChild", dotsEl_110);
posAt_116 = Fn((V _arrowThis475, int _argc467, V S1_473, V t_474, V _a471, V _a472, V[] _rest468) => {
V f_476 = default;
double i_477 = 0;
double u_478 = 0;
V A_479 = default;
V B_480 = default;
f_476 = Call(cl_18, V.Undef, ((V)((ToNum(t_474) / DT_86))), ((V)(0D)), ((V)((ToNum(Get(Get(S1_473, "pos"), "length")) - 1.001))));
i_477 = System.Math.Floor(ToNum(f_476));
u_478 = (ToNum(f_476) - i_477);
A_479 = GetIdx(Get(S1_473, "pos"), i_477);
B_480 = GetIdx(Get(S1_473, "pos"), (i_477 + 1D));
return Arr(Call(lerp_19, V.Undef, GetIdx(A_479, 0D), GetIdx(B_480, 0D), ((V)(u_478))), Call(lerp_19, V.Undef, GetIdx(A_479, 1D), GetIdx(B_480, 1D), ((V)(u_478))), Call(lerp_19, V.Undef, GetIdx(A_479, 2D), GetIdx(B_480, 2D), ((V)(u_478))));
return default;
}, 2, "", true);
D2R_119 = (System.Math.PI / 180D);
PIV_120 = 0.44;
REACH_121 = 0.7;
pivOf_122 = Fn((V _arrowThis489, int _argc481, V x_487, V h_488, V _a485, V _a486, V[] _rest482) => {
return Arr(x_487, Add(h_488, ((V)(PIV_120))));
}, 2, "", true);
pawOf_123 = Fn((V _arrowThis499, int _argc490, V pv_496, V s_497, V t_498, V _a495, V[] _rest491) => {
double ph_500 = 0;
ph_500 = ((LtN(s_497, 0D) ? (180D - ToNum(t_498)) : (-ToNum(t_498))) * D2R_119);
return Arr(Add(GetIdx(pv_496, 0D), ((V)((FdLibm.Cos(ph_500) * REACH_121)))), Add(GetIdx(pv_496, 1D), ((V)((FdLibm.Sin(ph_500) * REACH_121)))));
return default;
}, 3, "", true);
kickKey_132 = Fn((V _arrowThis509, int _argc501, V k_507, V a_508, V _a505, V _a506, V[] _rest502) => {
if (string.Equals(phase_91.Str, "aim")) {
Call(release_129, V.Undef, k_507, a_508);
}
return (true ? V.True : V.False);
return default;
}, 2, "", true);
api_133 = NewObj(14).Put("start", Fn((V _self510, int _argc511, V _a513, V _a514, V _a515, V _a516, V[] _rest512) => {
if (_self510.IsNullish) _self510 = GlobalV;
shot_90 = 0D;
Set(res_89, "length", ((V)(0D)));
Invoke(ctx_38, "setScore", ((V)(0D)));
aim_95 = V.Null;
Call(resetShot_113, V.Undef);
return default;
}, 0, "start", false)).Put("down", Fn((V _self517, int _argc518, V p_524, V _a521, V _a522, V _a523, V[] _rest519) => {
if (_self517.IsNullish) _self517 = GlobalV;
if (string.Equals(phase_91.Str, "aim")) {
aim_95 = NewObj(6).Put("x0", Get(p_524, "x")).Put("y0", Get(p_524, "y")).Put("x", Get(p_524, "x")).Put("y", Get(p_524, "y")).Put("p", V.Null).Put("S", V.Null).V;
}
return default;
}, 1, "down", false)).Put("move", Fn((V _self525, int _argc526, V p_532, V _a529, V _a530, V _a531, V[] _rest527) => {
if (_self525.IsNullish) _self525 = GlobalV;
if (Truthy(aim_95)) {
Set(aim_95, "x", Get(p_532, "x"));
Set(aim_95, "y", Get(p_532, "y"));
}
return default;
}, 1, "move", false)).Put("up", Fn((V _self533, int _argc534, V p_540, V _a537, V _a538, V _a539, V[] _rest535) => {
V pp_541 = default;
V S0_542 = default;
if (_self533.IsNullish) _self533 = GlobalV;
if (!(Truthy(aim_95))) {
return default;
}
if (Truthy(p_540)) {
Set(aim_95, "x", Get(p_540, "x"));
Set(aim_95, "y", Get(p_540, "y"));
}
pp_541 = (Get(aim_95, "force") is var _t543 && Truthy(_t543) ? _t543 : Call(pullOf_117, V.Undef, NewObj(2).Put("x", ((V)((ToNum(Get(aim_95, "x")) - ToNum(Get(aim_95, "x0")))))).Put("y", ((V)((ToNum(Get(aim_95, "y")) - ToNum(Get(aim_95, "y0")))))).V));
S0_542 = Get(aim_95, "S");
if ((!(Truthy(pp_541)) || !string.Equals(phase_91.Str, "aim"))) {
aim_95 = V.Null;
Call(drawPath_118, V.Undef, V.Null);
return default;
}
Call(release_129, V.Undef, Get(pp_541, "k"), Get(pp_541, "a"), S0_542);
return default;
}, 1, "up", false)).Put("key", Fn((V _self544, int _argc545, V k_551, V dn_552, V _a549, V _a550, V[] _rest546) => {
if (_self544.IsNullish) _self544 = GlobalV;
if (!(Truthy(dn_552))) {
return default;
}
if ((SEqS(k_551, "ArrowUp") || SEqS(k_551, " "))) {
return Call(kickKey_132, V.Undef, ((V)(0.3)), ((V)(0D)));
}
if (SEqS(k_551, "ArrowLeft")) {
return Call(kickKey_132, V.Undef, ((V)(0.4)), ((V)((-0.55))));
}
if (SEqS(k_551, "ArrowRight")) {
return Call(kickKey_132, V.Undef, ((V)(0.4)), ((V)(0.55)));
}
return default;
}, 2, "key", false)).Put("_aim", Fn((V _arrowThis561, int _argc553, V k_559, V a_560, V _a557, V _a558, V[] _rest554) => {
aim_95 = NewObj(6).Put("x0", ((V)((ToNum(W_41) * 0.6)))).Put("y0", ((V)((ToNum(H_42) * 0.35)))).Put("x", ((V)(((ToNum(W_41) * 0.6) - (ToNum(a_560) * 60D))))).Put("y", ((V)((((ToNum(H_42) * 0.35) + 16D) + (ToNum(k_559) * PULL_85))))).Put("force", NewObj(2).Put("k", k_559).Put("a", a_560).V).Put("S", V.Null).V;
return default;
}, 2, "_aim", true)).Put("_shoot", Fn((V _arrowThis570, int _argc562, V k_568, V a_569, V _a566, V _a567, V[] _rest563) => {
if (string.Equals(phase_91.Str, "aim")) {
Call(release_129, V.Undef, k_568, (a_569.IsNullish ? ((V)(0D)) : a_569));
}
return default;
}, 2, "_shoot", true)).Put("_sim", Fn((V _arrowThis579, int _argc571, V k_577, V a_578, V _a575, V _a576, V[] _rest572) => {
V S1_580 = default;
S1_580 = Call(sim_115, V.Undef, k_577, a_578);
return NewObj(4).Put("res", Get(S1_580, "res")).Put("cross", (Get(S1_580, "cross") is var _t589 && !Truthy(_t589) ? _t589 : Invoke(Get(S1_580, "cross"), "map", Fn((V _arrowThis588, int _argc581, V v_587, V _a584, V _a585, V _a586, V[] _rest582) => {
return ((V)(ToNum(Invoke(v_587, "toFixed", ((V)(2D))))));
}, 1, "", true)))).Put("kAt", (Get(S1_580, "kAt") is var _t598 && !Truthy(_t598) ? _t598 : Invoke(Get(S1_580, "kAt"), "map", Fn((V _arrowThis597, int _argc590, V v_596, V _a593, V _a594, V _a595, V[] _rest591) => {
return ((V)(ToNum(Invoke(v_596, "toFixed", ((V)(2D))))));
}, 1, "", true)))).Put("tK", ((V)(ToNum(Invoke(Get(S1_580, "tK"), "toFixed", ((V)(2D))))))).V;
return default;
}, 2, "_sim", true)).Put("_skill", Fn((V _arrowThis606, int _argc599, V v_605, V _a602, V _a603, V _a604, V[] _rest600) => {
skill_97 = v_605;
return default;
}, 1, "_skill", true)).Put("_state", Fn((V _arrowThis613, int _argc607, V _a609, V _a610, V _a611, V _a612, V[] _rest608) => {
return NewObj(5).Put("phase", ((V)(phase_91.Str))).Put("shot", ((V)(shot_90))).Put("res", Invoke(res_89, "slice")).Put("ball", (ball_94 is var _t622 && !Truthy(_t622) ? _t622 : Invoke(Arr(Get(ball_94, "x"), Get(ball_94, "y"), Get(ball_94, "z")), "map", Fn((V _arrowThis621, int _argc614, V v_620, V _a617, V _a618, V _a619, V[] _rest615) => {
return ((V)(ToNum(Invoke(v_620, "toFixed", ((V)(2D))))));
}, 1, "", true)))).Put("dive", (dv_109 is var _t623 && !Truthy(_t623) ? _t623 : NewObj(5).Put("kind", Get(dv_109, "kind")).Put("s", Get(dv_109, "s")).Put("x", ((V)(ToNum(Invoke(Get(dv_109, "x"), "toFixed", ((V)(2D))))))).Put("h", ((V)(ToNum(Invoke(Get(dv_109, "h"), "toFixed", ((V)(2D))))))).Put("t", ((V)(ToNum(Invoke(Get(dv_109, "t"), "toFixed", ((V)(1D))))))).V)).V;
}, 0, "_state", true)).Put("_ready", Fn((V _arrowThis630, int _argc624, V _a626, V _a627, V _a628, V _a629, V[] _rest625) => {
return ((string.Equals(phase_91.Str, "aim") && !(Truthy(aim_95))) ? V.True : V.False);
}, 0, "_ready", true)).Put("celebrate", Fn((V _self631, int _argc632, V st_638, V _a635, V _a636, V _a637, V[] _rest633) => {
if (_self631.IsNullish) _self631 = GlobalV;
Invoke(kick_75, "play", ((V)((GeN(st_638, 2D) ? "happy" : "idle"))));
return default;
}, 1, "celebrate", false)).Put("destroy", Fn((V _self639, int _argc640, V _a642, V _a643, V _a644, V _a645, V[] _rest641) => {
if (_self639.IsNullish) _self639 = GlobalV;
Invoke(aimL_64, "remove");
Invoke(ballL_60, "remove");
return default;
}, 0, "destroy", false)).Put("update", Fn((V _self646, int _argc647, V dt_653, V t_654, V _a651, V _a652, V[] _rest648) => {
double ts_655 = 0;
V KE_656 = default;
V s_657 = default;
double r_658 = 0;
V inG_659 = default;
V front_660 = default;
V sp_661 = default;
JsStrBuf pd_662 = null;
V g0_663 = default;
V hk_664 = default;
if (_self646.IsNullish) _self646 = GlobalV;
tNow_93 = t_654;
ts_655 = (ToNum(t_654) - ToNum(ph0_92));
if (string.Equals(phase_91.Str, "aim")) {
V pp_665 = default;
pp_665 = V.Null;
if (Truthy(aim_95)) {
pp_665 = (Get(aim_95, "force") is var _t666 && Truthy(_t666) ? _t666 : Call(pullOf_117, V.Undef, NewObj(2).Put("x", ((V)((ToNum(Get(aim_95, "x")) - ToNum(Get(aim_95, "x0")))))).Put("y", ((V)((ToNum(Get(aim_95, "y")) - ToNum(Get(aim_95, "y0")))))).V));
Set(aim_95, "p", pp_665);
Set(aim_95, "S", (Truthy(pp_665) ? (Truthy(((Get(aim_95, "S") is var _t667 && !Truthy(_t667) ? _t667 : (SEq(Get(Get(aim_95, "S"), "k"), Get(pp_665, "k")) ? V.True : V.False)) is var _t668 && !Truthy(_t668) ? _t668 : (SEq(Get(Get(aim_95, "S"), "a"), Get(pp_665, "a")) ? V.True : V.False))) ? Get(aim_95, "S") : Call(sim_115, V.Undef, Get(pp_665, "k"), Get(pp_665, "a"))) : V.Null));
Call(drawPath_118, V.Undef, Get(aim_95, "S"));
}
wind_99 = Call(lerp_19, V.Undef, wind_99, ((V)((Truthy(pp_665) ? (0.35 + (0.65 * ToNum(Get(pp_665, "k")))) : 0D))), ((V)((1D - Pow(0.002, ToNum(dt_653))))));
Set(kick_75, "wx", ((V)((ToNum(GetIdx(RUN0_76, 0D)) - (0.08 * ToNum(wind_99))))));
Set(kick_75, "wz", ((V)((ToNum(GetIdx(RUN0_76, 1D)) - (0.1 * ToNum(wind_99))))));
Invoke(kick_75, "yaw", ((V)((160D + (6D * FdLibm.Sin((ToNum(t_654) / 900D)))))));
Invoke(kick_75, "pose", NewObj(5).Put("sq", ((V)((0.1 * ToNum(wind_99))))).Put("lean", ((V)(((-4D) * ToNum(wind_99))))).Put("armL", ((V)((25D + (45D * ToNum(wind_99)))))).Put("armR", ((V)((20D + (35D * ToNum(wind_99)))))).Put("footR", ((V)((2D * ToNum(wind_99))))).V);
} else {
if (string.Equals(phase_91.Str, "run")) {
V u_669 = default;
double e_670 = 0;
u_669 = Call(cl_18, V.Undef, ((V)((ts_655 / RUN_88))), ((V)(0D)), ((V)(1D)));
e_670 = (LtN(u_669, 0.85) ? (ToNum(u_669) / 0.85) : 1D);
Set(kick_75, "wx", Call(lerp_19, V.Undef, GetIdx(runFrom_96, 0D), GetIdx(KICKAT_77, 0D), ((V)(((ToNum(Call(SM_52, V.Undef, ((V)(e_670)))) * 0.2) + (e_670 * 0.8))))));
Set(kick_75, "wz", Call(lerp_19, V.Undef, GetIdx(runFrom_96, 1D), GetIdx(KICKAT_77, 1D), ((V)(((ToNum(Call(SM_52, V.Undef, ((V)(e_670)))) * 0.2) + (e_670 * 0.8))))));
Invoke(kick_75, "yaw", Call(lerp_19, V.Undef, ((V)(150D)), ((V)(172D)), u_669));
if (LtN(u_669, 0.82)) {
Invoke(kick_75, "pose", NewObj(2).Put("lean", ((V)(4D))).Put("sq", ((V)(0.02))).V);
Invoke(kick_75, "walk", ((V)((ToNum(dt_653) * 1.7))), ((V)(1D)), ((V)(160D)));
} else {
double v_671 = 0;
v_671 = ((ToNum(u_669) - 0.82) / 0.18);
Invoke(kick_75, "pose", NewObj(5).Put("lean", Call(lerp_19, V.Undef, ((V)(4D)), ((V)((-3D))), ((V)(v_671)))).Put("sq", ((V)((0.06 * v_671)))).Put("footR", Call(lerp_19, V.Undef, ((V)(0D)), ((V)((-4D))), ((V)(v_671)))).Put("armL", ((V)((40D * v_671)))).Put("armR", ((V)((70D * v_671)))).V);
}
if (GeN(u_669, 1D)) {
Call(launch_130, V.Undef);
ph0_92 = t_654;
}
} else {
double kt_672 = 0;
kt_672 = (ToNum(t_654) - ToNum(kickT_103));
Invoke(kick_75, "pose", Call(track_21, V.Undef, Arr(Arr(((V)(0D)), NewObj(5).Put("lean", ((V)(9D))).Put("sq", ((V)((-0.06)))).Put("footR", ((V)(9D))).Put("armL", ((V)(70D))).Put("armR", ((V)((-10D)))).V), Arr(((V)(140D)), NewObj(5).Put("lean", ((V)(6D))).Put("sq", ((V)(0.03))).Put("footR", ((V)(6D))).Put("armL", ((V)(80D))).Put("armR", ((V)(20D))).V), Arr(((V)(520D)), NewObj(5).Put("lean", ((V)(0D))).Put("sq", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V)), ((V)(kt_672))));
Invoke(kick_75, "yaw", ((V)(172D)));
}
}
KE_656 = NewObj(4).Put("armL", ((V)((40D + (10D * FdLibm.Sin((ToNum(t_654) / 300D))))))).Put("armR", ((V)((40D + (10D * FdLibm.Sin(((ToNum(t_654) / 300D) + 1D))))))).Put("sq", ((V)((0.06 + (0.02 * FdLibm.Sin((ToNum(t_654) / 150D))))))).Put("lean", ((V)((FdLibm.Sin((ToNum(t_654) / 700D)) * 3D)))).V;
if (!(Truthy(dv_109))) {
kx0_108 = ToNum((kx_105 = ((V)((FdLibm.Sin((ToNum(t_654) / 800D)) * 0.22)))));
kH_106 = 0D;
th_107 = ((V)(0D));
} else {
double tt_673 = 0;
V u_674 = default;
V e_675 = default;
V f_676 = default;
V side_677 = default;
V ext_678 = default;
tt_673 = ((ToNum(t_654) - ToNum(Get(dv_109, "at"))) / 1000D);
u_674 = Call(cl_18, V.Undef, ((V)(((tt_673 - ToNum(Get(dv_109, "t0"))) / ToNum(Get(dv_109, "dur"))))), ((V)(0D)), ((V)(1D)));
e_675 = Call(SM_52, V.Undef, u_674);
f_676 = Call(cl_18, V.Undef, ((V)(((tt_673 - ToNum(Get(dv_109, "tK"))) / 0.38))), ((V)(0D)), ((V)(1D)));
side_677 = Get(dv_109, "s");
kx_105 = Add(Call(lerp_19, V.Undef, GetIdx(Get(dv_109, "from"), 0D), Get(dv_109, "x"), e_675), ((V)(((ToNum(side_677) * 0.18) * ToNum(f_676)))));
kH_106 = ((LtN(u_674, 1D) ? (ToNum(Get(dv_109, "h")) * FdLibm.Sin(((ToNum(e_675) * System.Math.PI) / 2D))) : (ToNum(Get(dv_109, "h")) * (1D - (ToNum(f_676) * ToNum(f_676))))) * ((SEqS(Get(dv_109, "kind"), "stay") || SEqS(Get(dv_109, "kind"), "block")) ? 1D : 1D));
th_107 = (Truthy(side_677) ? Add(Call(lerp_19, V.Undef, ((V)(0D)), Get(dv_109, "t"), e_675), ((V)(((((ToNum(side_677) * 72D) - ToNum(Get(dv_109, "t"))) * ToNum(Call(SM_52, V.Undef, f_676))) * ((GtN(Get(dv_109, "h"), 0.12) || (System.Math.Abs(ToNum(Get(dv_109, "t"))) > 20D)) ? 1D : 0D))))) : ((V)(0D)));
ext_678 = (LtN(side_677, 0D) ? NewObj(5).Put("armL", ((V)(130D))).Put("armR", ((V)(150D))).Put("hLx", ((V)(((-14D) * ToNum(e_675))))).Put("hLy", ((V)(((-28D) * ToNum(e_675))))).Put("footR", ((V)((5D * ToNum(e_675))))).V : (GtN(side_677, 0D) ? NewObj(5).Put("armR", ((V)(130D))).Put("armL", ((V)(150D))).Put("hRx", ((V)((14D * ToNum(e_675))))).Put("hRy", ((V)(((-28D) * ToNum(e_675))))).Put("footL", ((V)((5D * ToNum(e_675))))).V : NewObj(4).Put("armL", ((V)((165D * ToNum(e_675))))).Put("armR", ((V)((165D * ToNum(e_675))))).Put("footL", ((V)((3D * ToNum(e_675))))).Put("sq", ((V)(((-0.05) * ToNum(e_675))))).V));
KE_656 = Object_assign(ext_678, ((SEqS(outcome_98, "goal") && GtN(f_676, 0.5)) ? NewObj(2).Put("open", ((V)(1D))).Put("cross", ((V)(0.6))).V : ((SEqS(outcome_98, "miss") && GtN(f_676, 0.6)) ? NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.8))).V : NewObj(2).Put("teary", e_675).Put("open", e_675).V)));
if (((Gt(((V)(tt_673)), Get(dv_109, "t0")) && Lt(((V)(tt_673)), Add(Get(dv_109, "tK"), ((V)(0.1))))) && Gt(t_654, dropAt_104))) {
double hp_679 = 0;
dropAt_104 = Add(t_654, ((V)(110D)));
hp_679 = (ToNum(Get(keeper_74, "y")) - (ToNum(Get(keeper_74, "size")) * 0.8));
Invoke(ctx_38, "burst", Add(Get(keeper_74, "x"), ((V)((((ToNum(Invoke(G("Math"), "random")) - 0.5) * ToNum(Get(keeper_74, "size"))) * 0.5)))), ((V)(hp_679)), ((V)("drop")), ((V)(1D)), NewObj(3).Put("v", ((V)(50D))).Put("life", ((V)(0.5))).Put("layer", fxG_63).V);
}
}
Invoke(keeper_74, "pose", KE_656);
Call(place_112, V.Undef);
if (Truthy((Get(ball_94, "S") is var _t680 && !Truthy(_t680) ? _t680 : (!(Truthy(Get(ball_94, "live"))) ? V.True : V.False)))) {
double tt_681 = 0;
V p_682 = default;
V touch_683 = default;
tt_681 = ((ToNum(t_654) - ToNum(Get(ball_94, "tl"))) / 1000D);
p_682 = Call(posAt_116, V.Undef, Get(ball_94, "S"), ((V)(tt_681)));
Set(ball_94, "x", GetIdx(p_682, 0D));
Set(ball_94, "y", GetIdx(p_682, 1D));
Set(ball_94, "z", GetIdx(p_682, 2D));
Set(ball_94, "spin", ((V)((tt_681 * 16D))));
touch_683 = (dv_109 is var _t684 && !Truthy(_t684) ? _t684 : (((SEqS(Get(dv_109, "kind"), "save") || SEqS(Get(dv_109, "kind"), "tip")) || SEqS(Get(dv_109, "kind"), "block")) ? V.True : V.False));
if (Truthy((touch_683 is var _t685 && !Truthy(_t685) ? _t685 : (!(Truthy(outcome_98)) ? V.True : V.False)))) {
double lead_686 = 0;
lead_686 = (ToNum(Get(dv_109, "tK")) - tt_681);
if ((lead_686 < 0.11)) {
V sn_687 = default;
V w_688 = default;
if (!(Truthy(Get(ball_94, "snap")))) {
Set(ball_94, "snap", Call(rigPaw_128, V.Undef, (SEqS(Get(dv_109, "kind"), "block") ? ((V)(0D)) : Get(dv_109, "s"))));
}
sn_687 = Call(rigPaw_128, V.Undef, (SEqS(Get(dv_109, "kind"), "block") ? ((V)(0D)) : Get(dv_109, "s")));
w_688 = Call(SM_52, V.Undef, ((V)((1D - (Max(0D, lead_686) / 0.11)))));
Set(ball_94, "x", Call(lerp_19, V.Undef, Get(ball_94, "x"), GetIdx(sn_687, 0D), w_688));
Set(ball_94, "y", Call(lerp_19, V.Undef, Get(ball_94, "y"), GetIdx(sn_687, 1D), w_688));
}
if (Ge(((V)(tt_681)), Get(dv_109, "tK"))) {
V bz_689 = default;
V s_690 = default;
bz_689 = Get(ball_94, "z");
Set(ball_94, "live", ((V)(1D)));
Set(ball_94, "z", ((V)((KZ_51 - 0.02))));
Set(ball_94, "vz", ((V)(((-2.2) - ToNum(Invoke(G("Math"), "random"))))));
Set(ball_94, "vx", ((V)((ToNum((Get(dv_109, "s") is var _t691 && Truthy(_t691) ? _t691 : ((V)((LtN(Invoke(G("Math"), "random"), 0.5) ? (-1D) : 1D))))) * ToNum(Add(((V)(1.6)), Invoke(G("Math"), "random")))))));
Set(ball_94, "vy", ((V)((SEqS(Get(dv_109, "kind"), "tip") ? 3.2 : 2.2))));
Set(ball_94, "st", ((V)("out")));
Call(settle_131, V.Undef, (false ? V.True : V.False), ((V)("Saved!")), ((V)("#8fe0ff")));
Invoke(SFX_22, "thud");
s_690 = Call(P_44, V.Undef, Get(ball_94, "x"), Get(ball_94, "y"), Get(ball_94, "z"));
Invoke(ctx_38, "burst", GetIdx(s_690, 0D), GetIdx(s_690, 1D), ((V)("star")), ((V)(7D)), NewObj(4).Put("v", ((V)(120D))).Put("life", ((V)(0.4))).Put("layer", fxG_63).Put("col", ((V)("#ffffff"))).V);
}
}
while (((!(Truthy(Get(ball_94, "live"))) && Lt(Get(ball_94, "fired"), Get(Get(Get(ball_94, "S"), "ev"), "length"))) && LeN(GetIdx(GetK(Get(Get(ball_94, "S"), "ev"), Get(ball_94, "fired")), 0D), tt_681))) {
V e_692 = default;
e_692 = GetIdx(GetIdx(Get(Get(ball_94, "S"), "ev"), IncM(ball_94, "fired", 1D, false)), 1D);
if (SEqS(e_692, "goal")) {
Set(ball_94, "st", ((V)("net")));
bulge_70 = NewObj(4).Put("x", Get(ball_94, "x")).Put("y", Get(ball_94, "y")).Put("a", ((V)(1D))).Put("t", t_654).V;
Invoke(SFX_22, "swish");
Call(settle_131, V.Undef, (true ? V.True : V.False));
} else {
if ((SEqS(e_692, "post") || SEqS(e_692, "bar"))) {
Set(ball_94, "st", ((V)("out")));
Invoke(SFX_22, "clang");
Call(settle_131, V.Undef, (false ? V.True : V.False), ((V)((SEqS(e_692, "bar") ? "Off the bar!" : "Off the post!"))));
} else {
if ((SEqS(e_692, "wide") || SEqS(e_692, "over"))) {
Set(ball_94, "st", ((V)("out")));
Call(settle_131, V.Undef, (false ? V.True : V.False), ((V)((SEqS(e_692, "over") ? "Over the bar!" : "Wide!"))));
} else {
if ((SEqS(e_692, "bounce") && Gt(t_654, quietAt_101))) {
Invoke(SFX_22, "thud");
quietAt_101 = Add(t_654, ((V)(150D)));
}
}
}
}
}
} else {
if (Truthy(Get(ball_94, "live"))) {
double n_693 = 0;
n_693 = 3D;
{
double i_694 = 0;
i_694 = 0D;
while (true) {
if (!((i_694 < n_693))) break;
Call(stepB_114, V.Undef, ball_94, ((V)((ToNum(dt_653) / n_693))), ((V)(0D)), V.Null);
i_694++;
}
}
OpSet(ball_94, "spin", 0, ((V)((ToNum(dt_653) * 14D))));
}
}
Call(drawNet_71, V.Undef, t_654);
s_657 = Call(P_44, V.Undef, Get(ball_94, "x"), Get(ball_94, "y"), Get(ball_94, "z"));
r_658 = (BR_49 * ToNum(GetIdx(s_657, 2D)));
inG_659 = (GtN(Get(ball_94, "z"), (GZ_46 - 0.02)) ? V.True : V.False);
front_660 = (LtN(Get(ball_94, "z"), (KZ_51 - 0.02)) ? V.True : V.False);
if (Truthy(inG_659)) {
if (!SEq(Get(bG_82, "parentNode"), ballSlotBack_59)) {
Invoke(ballSlotBack_59, "appendChild", bG_82);
}
} else {
if (!SEq(Get(bG_82, "parentNode"), ballSlot_62)) {
Invoke(ballSlot_62, "appendChild", bG_82);
}
}
Set(Get(ballL_60, "style"), "zIndex", ((V)((Truthy(front_660) ? 2D : 0D))));
Invoke(bC_83, "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, GetIdx(s_657, 0D)));
Invoke(bC_83, "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, GetIdx(s_657, 1D)));
Invoke(bC_83, "setAttribute", ((V)("r")), Call(r2_20, V.Undef, ((V)(r_658))));
sp_661 = Get(ball_94, "spin");
pd_662 = new JsStrBuf("");
{
double i_696 = 0;
i_696 = 0D;
while (true) {
if (!((i_696 < 5D))) break;
V a_698 = default;
a_698 = Add(sp_661, ((V)((i_696 * 1.2566))));
pd_662.S((NumTruthy(i_696) ? "L" : "M")).V(Call(r2_20, V.Undef, Add(GetIdx(s_657, 0D), ((V)(((FdLibm.Cos(ToNum(a_698)) * r_658) * 0.42)))))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(s_657, 1D), ((V)(((FdLibm.Sin(ToNum(a_698)) * r_658) * 0.42))))));
i_696++;
}
}
Invoke(bP_84, "setAttribute", ((V)("d")), ((V)(string.Concat(pd_662.Str, "Z"))));
g0_663 = Call(P_44, V.Undef, Get(ball_94, "x"), ((V)(0D)), Get(ball_94, "z"));
hk_664 = Call(cl_18, V.Undef, ((V)((1D - (ToNum(Get(ball_94, "y")) / 2.5)))), ((V)(0.3)), ((V)(1D)));
Invoke(bShadow_81, "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, GetIdx(g0_663, 0D)));
Invoke(bShadow_81, "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, GetIdx(g0_663, 1D)));
Invoke(bShadow_81, "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)((((BR_49 * ToNum(GetIdx(g0_663, 2D))) * 1.2) * ToNum(hk_664))))));
Invoke(bShadow_81, "setAttribute", ((V)("ry")), Call(r2_20, V.Undef, ((V)((((BR_49 * ToNum(GetIdx(g0_663, 2D))) * 0.35) * ToNum(hk_664))))));
if (Truthy(((Get(ball_94, "S") is var _t699 && !Truthy(_t699) ? _t699 : (!(Truthy(inG_659)) ? V.True : V.False)) is var _t700 && !Truthy(_t700) ? _t700 : (((ToNum(t_654) - ToNum(Get(ball_94, "tl"))) < 1400D) ? V.True : V.False)))) {
Invoke(trail_102, "push", Arr(GetIdx(s_657, 0D), GetIdx(s_657, 1D), ((V)(r_658)), t_654));
}
trail_102 = Invoke(trail_102, "filter", Fn((V _arrowThis708, int _argc701, V q_707, V _a704, V _a705, V _a706, V[] _rest702) => {
return (((ToNum(t_654) - ToNum(GetIdx(q_707, 3D))) < 170D) ? V.True : V.False);
}, 1, "", true));
Set(trailG_61, "innerHTML", ((V)("")));
if (GtN(Get(trail_102, "length"), 1D)) {
JsStrBuf d_709 = null;
V rr_710 = default;
d_709 = new JsStrBuf("");
Invoke(trail_102, "forEach", Fn((V _arrowThis719, int _argc711, V q_717, V i_718, V _a715, V _a716, V[] _rest712) => {
d_709.S((Truthy(i_718) ? "L" : "M")).V(Call(r2_20, V.Undef, GetIdx(q_717, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(q_717, 1D)));
return default;
}, 2, "", true));
rr_710 = GetIdx(GetIdx(trail_102, (ToNum(Get(trail_102, "length")) - 1D)), 2D);
Call(S_17, V.Undef, ((V)("path")), NewObj(7).Put("d", ((V)(d_709.Str))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)((ToNum(rr_710) * 1.5))))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).Put("opacity", ((V)(0.35))).V, trailG_61);
Call(S_17, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(d_709.Str))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)((ToNum(rr_710) * 0.6))))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.6))).V, trailG_61);
}
if ((string.Equals(phase_91.Str, "after") && (ts_655 > 1900D))) {
shot_90++;
if ((shot_90 >= 5D)) {
V g_720 = default;
phase_91.Set("done");
g_720 = Get(Invoke(res_89, "filter", G("Boolean")), "length");
Invoke(ctx_38, "finish", NewObj(1).Put("sub", ((V)(JsStrBuf.Begin().V(g_720).S("/5 goals vs ").V(kpName_73).End()))).V);
} else {
Call(resetShot_113, V.Undef);
}
}
return default;
}, 2, "update", false)).V;
Call(resetShot_113, V.Undef);
Call(place_112, V.Undef);
Call(drawNet_71, V.Undef, ((V)(0D)));
return api_133;
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
