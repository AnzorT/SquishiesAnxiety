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
go_8 = Fn((V _self1, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_15 = default;
V S_16 = default;
V cl_17 = default;
V lerp_18 = default;
V r2_19 = default;
V track_20 = default;
V SFX_21 = default;
V ICON_22 = default;
YG_15 = Get(G("window"), "YardGames");
if (((!(Truthy(YG_15)) || !(Truthy(Get(YG_15, "add")))) || !(Truthy(Get(YG_15, "cam"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t23 = YG_15;
if (_t23.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t23));
{ V _t24 = Get(_t23, "S");
S_16 = _t24; }
{ V _t25 = Get(_t23, "cl");
cl_17 = _t25; }
{ V _t26 = Get(_t23, "lerp");
lerp_18 = _t26; }
{ V _t27 = Get(_t23, "r2");
r2_19 = _t27; }
{ V _t28 = Get(_t23, "track");
track_20 = _t28; }
{ V _t29 = Get(_t23, "SFX");
SFX_21 = _t29; } }
ICON_22 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#cfeaff\"/><rect y=\"46\" width=\"120\" height=\"38\" fill=\"#9fdc6e\"/>", "<path d=\"M22 58V22H98V58\" fill=\"none\" stroke=\"#fff\" stroke-width=\"4\" stroke-linejoin=\"round\"/><path d=\"M26 24L34 34V56M94 24L86 34V56M34 34H86\" fill=\"none\" stroke=\"#e8eef5\" stroke-width=\"2\"/>", "<path d=\"M26 26H94M26 32H94M26 38H94M26 44H94M26 50H94M34 24V56M44 24V56M54 24V56M64 24V56M74 24V56M84 24V56\" stroke=\"#ffffff\" stroke-width=\"0.8\" opacity=\"0.6\"/>", "<path d=\"M12 70H108\" stroke=\"#fff\" stroke-width=\"2\"/><circle cx=\"60\" cy=\"68\" r=\"9\" fill=\"#fff\" stroke=\"#3a3a44\" stroke-width=\"1.2\"/><path d=\"M60 63L64 66L62.5 71H57.5L56 66Z\" fill=\"#3a3a44\"/></svg>")));
Invoke(YG_15, "add", NewObj(11).Put("id", ((V)("soccer"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Penalty Kick"))).Put("item", ((V)("Soccer Goal"))).Put("color", ((V)("#5cc2ff"))).Put("icon", ICON_22).Put("stars", Arr(((V)(250D)), ((V)(450D)), ((V)(700D)))).Put("coinK", ((V)(0.06))).Put("hint", ((V)("Pull back to aim \u00b7 the dots show the shot \u00b7 let go to kick"))).Put("how", Arr(((V)("Pull back from anywhere, like a slingshot. Farther = higher (too far flies over the bar); to the side = aim the other way.")), ((V)("The dotted path shows where the ball will go. Let go and your creature runs up and kicks, but the keeper can still save it!")), ((V)("5 penalties. Corners and top shots score bonus points.")))).Put("make", Fn((V _self30, int _argc31, V ctx_37, V _a34, V _a35, V _a36, V[] _rest32) => {
V bg_38 = default;
V fg_39 = default;
V W_40 = default;
V H_41 = default;
V CAM_42 = default;
V P_43 = default;
double G_44 = 0;
double GZ_45 = 0;
double GW_46 = 0;
double GH_47 = 0;
double BR_48 = 0;
V B0_49 = default;
double KZ_50 = 0;
V SM_51 = default;
V toW_52 = default;
V line_53 = default;
V spot_54 = default;
V netG_55 = default;
V shG_56 = default;
V postG_57 = default;
V ballSlotBack_58 = default;
V ballL_59 = default;
V trailG_60 = default;
V ballSlot_61 = default;
V fxG_62 = default;
V aimL_63 = default;
V pathG_64 = default;
V bandG_65 = default;
double NX_66 = 0;
double NY_67 = 0;
double ND_68 = 0;
V bulge_69 = default;
V drawNet_70 = default;
V kp_71 = default;
V kpName_72 = default;
V keeper_73 = default;
V kick_74 = default;
V RUN0_75 = default;
V KICKAT_76 = default;
double KS_77 = 0;
V kShadow_78 = default;
V pShadow_79 = default;
V bShadow_80 = default;
V bG_81 = default;
V bC_82 = default;
V bP_83 = default;
double PULL_84 = 0;
double DT_85 = 0;
double LIFE_86 = 0;
double RUN_87 = 0;
V res_88 = default;
double shot_89 = 0;
JsStrBuf phase_90 = null;
V ph0_91 = default;
V tNow_92 = default;
V ball_93 = default;
V aim_94 = default;
V runFrom_95 = default;
V skill_96 = default;
V outcome_97 = default;
V wind_98 = default;
V shotS_99 = default;
V quietAt_100 = default;
V trail_101 = default;
V kickT_102 = default;
V dropAt_103 = default;
V kx_104 = default;
double kH_105 = 0;
V th_106 = default;
double kx0_107 = 0;
V dv_108 = default;
V dotsEl_109 = default;
V drawDots_110 = default;
V place_111 = default;
V resetShot_112 = default;
V stepB_113 = default;
V sim_114 = default;
V posAt_115 = default;
V pullOf_116 = default;
V drawPath_117 = default;
double D2R_118 = 0;
double PIV_119 = 0;
double REACH_120 = 0;
V pivOf_121 = default;
V pawOf_122 = default;
V segD_123 = default;
V clear_124 = default;
V reachFor_125 = default;
V plan_126 = default;
V rigPaw_127 = default;
V release_128 = default;
V launch_129 = default;
V settle_130 = default;
V kickKey_131 = default;
V api_132 = default;
if (_self30.IsNullish) _self30 = GlobalV;
drawNet_70 = Fn((V _self133, int _argc134, V t_140, V _a137, V _a138, V _a139, V[] _rest135) => {
double k_141 = 0;
V pt_142 = default;
JsStrBuf d_143 = null;
V fb_144 = default;
if (_self133.IsNullish) _self133 = GlobalV;
Set(netG_55, "innerHTML", ((V)("")));
k_141 = ((ToNum(Get(bulge_69, "a")) * FdLibm.Exp(((-(ToNum(t_140) - ToNum(Get(bulge_69, "t")))) / 420D))) * (1D + (0.2 * FdLibm.Sin(((ToNum(t_140) - ToNum(Get(bulge_69, "t"))) / 60D)))));
pt_142 = Fn((V _self133, int _argc145, V x_151, V y_152, V _a149, V _a150, V[] _rest146) => {
double back_153 = 0;
double d_154 = 0;
double push_155 = 0;
back_153 = (ND_68 * (1D - ((ToNum(y_152) / GH_47) * 0.55)));
d_154 = Hypot((ToNum(x_151) - ToNum(Get(bulge_69, "x"))), (ToNum(y_152) - ToNum(Get(bulge_69, "y"))));
push_155 = ((k_141 * FdLibm.Exp((((-d_154) * d_154) / 0.3))) * 0.6);
return Call(P_43, V.Undef, x_151, y_152, ((V)(((GZ_45 + back_153) + push_155))));
return default;
}, 2, "", true);
d_143 = new JsStrBuf("");
{
double i_156 = 0;
i_156 = 0D;
while (true) {
if (!((i_156 <= NX_66))) break;
double x_158 = 0;
x_158 = ((-GW_46) + (((2D * GW_46) * i_156) / NX_66));
{
double j_159 = 0;
j_159 = 0D;
while (true) {
if (!((j_159 <= NY_67))) break;
double y_161 = 0;
V s_162 = default;
y_161 = ((GH_47 * j_159) / NY_67);
s_162 = Call(pt_142, V.Undef, ((V)(x_158)), ((V)(y_161)));
d_143.S((NumTruthy(j_159) ? "L" : "M")).V(Call(r2_19, V.Undef, GetIdx(s_162, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(s_162, 1D)));
j_159++;
}
}
i_156++;
}
}
{
double j_163 = 0;
j_163 = 0D;
while (true) {
if (!((j_163 <= NY_67))) break;
double y_165 = 0;
y_165 = ((GH_47 * j_163) / NY_67);
{
double i_166 = 0;
i_166 = 0D;
while (true) {
if (!((i_166 <= NX_66))) break;
double x_168 = 0;
V s_169 = default;
x_168 = ((-GW_46) + (((2D * GW_46) * i_166) / NX_66));
s_169 = Call(pt_142, V.Undef, ((V)(x_168)), ((V)(y_165)));
d_143.S((NumTruthy(i_166) ? "L" : "M")).V(Call(r2_19, V.Undef, GetIdx(s_169, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(s_169, 1D)));
i_166++;
}
}
j_163++;
}
}
{
double j_170 = 0;
j_170 = 0D;
while (true) {
if (!((j_170 <= NY_67))) break;
double y_172 = 0;
V a_173 = default;
V b_174 = default;
V c_175 = default;
V e_176 = default;
y_172 = ((GH_47 * j_170) / NY_67);
a_173 = Call(P_43, V.Undef, ((V)((-GW_46))), ((V)(y_172)), ((V)(GZ_45)));
b_174 = Call(pt_142, V.Undef, ((V)((-GW_46))), ((V)(y_172)));
c_175 = Call(P_43, V.Undef, ((V)(GW_46)), ((V)(y_172)), ((V)(GZ_45)));
e_176 = Call(pt_142, V.Undef, ((V)(GW_46)), ((V)(y_172)));
d_143.S("M").V(Call(r2_19, V.Undef, GetIdx(a_173, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(a_173, 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(b_174, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(b_174, 1D))).S("M").V(Call(r2_19, V.Undef, GetIdx(c_175, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(c_175, 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(e_176, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(e_176, 1D)));
j_170++;
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(d_143.Str))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.75))).V, netG_55);
fb_144 = Arr(Call(P_43, V.Undef, ((V)((-GW_46))), ((V)(0D)), ((V)((GZ_45 + ND_68)))), Call(P_43, V.Undef, ((V)((-GW_46))), ((V)((GH_47 * 0.95))), ((V)((GZ_45 + (ND_68 * 0.48))))), Call(P_43, V.Undef, ((V)(GW_46)), ((V)((GH_47 * 0.95))), ((V)((GZ_45 + (ND_68 * 0.48))))), Call(P_43, V.Undef, ((V)(GW_46)), ((V)(0D)), ((V)((GZ_45 + ND_68)))));
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(fb_144, "map", Fn((V _self133, int _argc177, V s_183, V _a180, V _a181, V _a182, V[] _rest178) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_19, V.Undef, GetIdx(s_183, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(s_183, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).End()))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#dfe6ee"))).Put("stroke-width", ((V)(2.6))).V, netG_55);
return default;
}, 1, "drawNet", false);
drawDots_110 = Fn((V _self184, int _argc185, V _a187, V _a188, V _a189, V _a190, V[] _rest186) => {
if (_self184.IsNullish) _self184 = GlobalV;
Set(dotsEl_109, "innerHTML", ((V)("")));
{
double i_191 = 0;
i_191 = 0D;
while (true) {
if (!((i_191 < 5D))) break;
V s_193 = default;
s_193 = Invoke(G("document"), "createElement", ((V)("span")));
Set(s_193, "textContent", ((V)((GetIdx(res_88, i_191).IsNullish ? "\u25cb" : (Truthy(GetIdx(res_88, i_191)) ? "\u25cf" : "\u2715")))));
Set(Get(s_193, "style"), "color", ((V)((GetIdx(res_88, i_191).IsNullish ? "#b9a8d6" : (Truthy(GetIdx(res_88, i_191)) ? "#2fb24a" : "#e8483c")))));
Invoke(dotsEl_109, "appendChild", s_193);
i_191++;
}
}
return default;
}, 0, "drawDots", false);
place_111 = Fn((V _self194, int _argc195, V _a197, V _a198, V _a199, V _a200, V[] _rest196) => {
V k_201 = default;
V kk_202 = default;
if (_self194.IsNullish) _self194 = GlobalV;
k_201 = Call(P_43, V.Undef, kx_104, ((V)(0D)), ((V)(KZ_50)));
Invoke(keeper_73, "set", GetIdx(k_201, 0D), ((V)((ToNum(GetIdx(k_201, 1D)) - (kH_105 * ToNum(GetIdx(k_201, 2D)))))), ((V)((1.15 * ToNum(GetIdx(k_201, 2D))))));
Invoke(keeper_73, "rot", th_106, ((V)(50D)), ((V)(55D)));
Invoke(keeper_73, "depth", ((V)(1D)));
Invoke(kShadow_78, "setAttribute", ((V)("cx")), Call(r2_19, V.Undef, GetIdx(k_201, 0D)));
Invoke(kShadow_78, "setAttribute", ((V)("cy")), Call(r2_19, V.Undef, GetIdx(k_201, 1D)));
Invoke(kShadow_78, "setAttribute", ((V)("rx")), Call(r2_19, V.Undef, ((V)(((0.36 * ToNum(GetIdx(k_201, 2D))) * (1D - (0.35 * Min(1D, kH_105))))))));
kk_202 = Call(P_43, V.Undef, Get(kick_74, "wx"), ((V)(0D)), Get(kick_74, "wz"));
Invoke(kick_74, "set", GetIdx(kk_202, 0D), GetIdx(kk_202, 1D), ((V)((KS_77 * ToNum(GetIdx(kk_202, 2D))))));
Invoke(kick_74, "depth", ((V)(3D)));
Invoke(pShadow_79, "setAttribute", ((V)("cx")), Call(r2_19, V.Undef, GetIdx(kk_202, 0D)));
Invoke(pShadow_79, "setAttribute", ((V)("cy")), Call(r2_19, V.Undef, GetIdx(kk_202, 1D)));
Invoke(pShadow_79, "setAttribute", ((V)("rx")), Call(r2_19, V.Undef, ((V)((0.24 * ToNum(GetIdx(kk_202, 2D)))))));
return default;
}, 0, "place", false);
resetShot_112 = Fn((V _self203, int _argc204, V _a206, V _a207, V _a208, V _a209, V[] _rest205) => {
if (_self203.IsNullish) _self203 = GlobalV;
ball_93 = NewObj(8).Put("x", GetIdx(B0_49, 0D)).Put("y", GetIdx(B0_49, 1D)).Put("z", GetIdx(B0_49, 2D)).Put("vx", ((V)(0D))).Put("vy", ((V)(0D))).Put("vz", ((V)(0D))).Put("st", ((V)("rest"))).Put("spin", ((V)(0D))).V;
Set(kick_74, "wx", GetIdx(RUN0_75, 0D));
Set(kick_74, "wz", GetIdx(RUN0_75, 1D));
kx_104 = ((V)(0D));
kH_105 = 0D;
th_106 = ((V)(0D));
dv_108 = V.Null;
Invoke(keeper_73, "play", ((V)("idle")));
Invoke(kick_74, "play", ((V)("idle")));
phase_90.Set("aim");
outcome_97 = V.Null;
shotS_99 = V.Null;
wind_98 = ((V)(0D));
trail_101 = Arr();
Set(trailG_60, "innerHTML", ((V)("")));
skill_96 = ((V)((0.3 + (shot_89 * 0.12))));
Invoke(ctx_37, "timer", ((V)(JsStrBuf.Begin().S("Kick ").N((shot_89 + 1D)).S("/5").End())));
Call(drawDots_110, V.Undef);
return default;
}, 0, "resetShot", false);
stepB_113 = Fn((V _self210, int _argc211, V b_217, V h_218, V t_219, V @out_220, V[] _rest212) => {
V pz_221 = default;
if (_self210.IsNullish) _self210 = GlobalV;
pz_221 = Get(b_217, "z");
OpSet(b_217, "vy", 1, ((V)((G_44 * ToNum(h_218)))));
OpSet(b_217, "x", 0, ((V)((ToNum(Get(b_217, "vx")) * ToNum(h_218)))));
OpSet(b_217, "y", 0, ((V)((ToNum(Get(b_217, "vy")) * ToNum(h_218)))));
OpSet(b_217, "z", 0, ((V)((ToNum(Get(b_217, "vz")) * ToNum(h_218)))));
if (LtN(Get(b_217, "y"), BR_48)) {
if (Truthy((@out_220 is var _t222 && !Truthy(_t222) ? _t222 : ((System.Math.Abs(ToNum(Get(b_217, "vy"))) > 1.2) ? V.True : V.False)))) {
Invoke(Get(@out_220, "ev"), "push", Arr(t_219, ((V)("bounce"))));
}
Set(b_217, "y", ((V)(BR_48)));
Set(b_217, "vy", ((V)((System.Math.Abs(ToNum(Get(b_217, "vy"))) * 0.45))));
OpSet(b_217, "vx", 2, ((V)(0.8)));
OpSet(b_217, "vz", 2, ((V)(0.8)));
}
if (Truthy((((@out_220 is var _t223 && !Truthy(_t223) ? _t223 : (!(Truthy(Get(@out_220, "tK"))) ? V.True : V.False)) is var _t224 && !Truthy(_t224) ? _t224 : (LtN(pz_221, KZ_50) ? V.True : V.False)) is var _t225 && !Truthy(_t225) ? _t225 : (GeN(Get(b_217, "z"), KZ_50) ? V.True : V.False)))) {
Set(@out_220, "tK", t_219);
Set(@out_220, "kAt", Arr(Get(b_217, "x"), Get(b_217, "y")));
}
if (((SEqS(Get(b_217, "st"), "fly") && LtN(pz_221, GZ_45)) && GeN(Get(b_217, "z"), GZ_45))) {
double ax_226 = 0;
ax_226 = System.Math.Abs(ToNum(Get(b_217, "x")));
if (Truthy(@out_220)) {
Set(@out_220, "cross", Arr(Get(b_217, "x"), Get(b_217, "y")));
}
if ((((System.Math.Abs((ax_226 - GW_46)) < (BR_48 + 0.05)) && LtN(Get(b_217, "y"), (GH_47 + 0.06))) || ((System.Math.Abs((ToNum(Get(b_217, "y")) - GH_47)) < (BR_48 + 0.05)) && (ax_226 < (GW_46 + 0.06))))) {
Set(b_217, "vz", ((V)(((-System.Math.Abs(ToNum(Get(b_217, "vz")))) * 0.5))));
OpSet(b_217, "vx", 0, ((V)(((((ax_226 < GW_46) ? (-1D) : 1D) * Sign(ToNum(Get(b_217, "x")))) * 1.4))));
Set(b_217, "st", ((V)("out")));
if (Truthy(@out_220)) {
Invoke(Get(@out_220, "ev"), "push", Arr(t_219, ((V)(((System.Math.Abs((ToNum(Get(b_217, "y")) - GH_47)) < 0.2) ? "bar" : "post")))));
Set(@out_220, "res", ((V)("wood")));
Set(@out_220, "tEnd", Add(t_219, ((V)(0.3))));
}
} else {
if (((ax_226 < GW_46) && LtN(Get(b_217, "y"), GH_47))) {
Set(b_217, "st", ((V)("net")));
if (Truthy(@out_220)) {
Invoke(Get(@out_220, "ev"), "push", Arr(t_219, ((V)("goal"))));
Set(@out_220, "res", ((V)("goal")));
Set(@out_220, "tEnd", Add(t_219, ((V)(0.12))));
}
} else {
Set(b_217, "st", ((V)("out")));
if (Truthy(@out_220)) {
Invoke(Get(@out_220, "ev"), "push", Arr(t_219, ((V)((GeN(Get(b_217, "y"), GH_47) ? "over" : "wide")))));
Set(@out_220, "res", ((V)((GeN(Get(b_217, "y"), GH_47) ? "over" : "wide"))));
Set(@out_220, "tEnd", Add(t_219, ((V)(0.22))));
}
}
}
}
if (SEqS(Get(b_217, "st"), "net")) {
if (GtN(Get(b_217, "z"), (GZ_45 + 0.7))) {
Set(b_217, "z", ((V)((GZ_45 + 0.7))));
Set(b_217, "vz", ((V)((-0.3))));
OpSet(b_217, "vx", 2, ((V)(0.3)));
}
if ((System.Math.Abs(ToNum(Get(b_217, "x"))) > (GW_46 - 0.12))) {
Set(b_217, "x", ((V)((Sign(ToNum(Get(b_217, "x"))) * (GW_46 - 0.12)))));
OpSet(b_217, "vx", 2, ((V)((-0.3))));
}
if (GtN(Get(b_217, "y"), (GH_47 - 0.12))) {
Set(b_217, "y", ((V)((GH_47 - 0.12))));
Set(b_217, "vy", ((V)(((-System.Math.Abs(ToNum(Get(b_217, "vy")))) * 0.3))));
}
}
return default;
}, 4, "stepB", false);
sim_114 = Fn((V _self227, int _argc228, V k_234, V a_235, V _a232, V _a233, V[] _rest229) => {
double X_236 = 0;
double Y_237 = 0;
double T_238 = 0;
double dz_239 = 0;
V b_240 = default;
V @out_241 = default;
double n_242 = 0;
if (_self227.IsNullish) _self227 = GlobalV;
X_236 = (ToNum(a_235) * 2.4);
Y_237 = (0.15 + (ToNum(k_234) * 2.35));
T_238 = (0.88 - (0.2 * ToNum(k_234)));
dz_239 = ((GZ_45 + 0.05) - ToNum(GetIdx(B0_49, 2D)));
b_240 = NewObj(7).Put("x", GetIdx(B0_49, 0D)).Put("y", GetIdx(B0_49, 1D)).Put("z", GetIdx(B0_49, 2D)).Put("vx", ((V)(((X_236 - ToNum(GetIdx(B0_49, 0D))) / T_238)))).Put("vz", ((V)((dz_239 / T_238)))).Put("vy", ((V)((((Y_237 - ToNum(GetIdx(B0_49, 1D))) + (((0.5 * G_44) * T_238) * T_238)) / T_238)))).Put("st", ((V)("fly"))).V;
@out_241 = NewObj(9).Put("pos", Arr()).Put("ev", Arr()).Put("k", k_234).Put("a", a_235).Put("res", V.Null).Put("cross", V.Null).Put("tEnd", ((V)(1.3))).Put("tK", ((V)(0D))).Put("kAt", V.Null).V;
n_242 = Round((LIFE_86 / DT_85));
{
double i_243 = 0;
i_243 = 0D;
while (true) {
if (!((i_243 <= n_242))) break;
Invoke(Get(@out_241, "pos"), "push", Arr(Get(b_240, "x"), Get(b_240, "y"), Get(b_240, "z")));
Call(stepB_113, V.Undef, b_240, ((V)(DT_85)), ((V)((i_243 * DT_85))), @out_241);
i_243++;
}
}
return @out_241;
return default;
}, 2, "sim", false);
pullOf_116 = Fn((V _self245, int _argc246, V d_252, V _a249, V _a250, V _a251, V[] _rest247) => {
double len_253 = 0;
if (_self245.IsNullish) _self245 = GlobalV;
len_253 = Hypot(ToNum(Get(d_252, "x")), ToNum(Get(d_252, "y")));
if ((LtN(Get(d_252, "y"), 6D) || (len_253 < 16D))) {
return V.Null;
}
return NewObj(2).Put("k", Call(cl_17, V.Undef, ((V)(((len_253 - 16D) / PULL_84))), ((V)(0D)), ((V)(1D)))).Put("a", Call(cl_17, V.Undef, ((V)((((-ToNum(Get(d_252, "x"))) / Max(60D, ToNum(Get(d_252, "y")))) * 0.9))), ((V)((-1.2))), ((V)(1.2)))).V;
return default;
}, 1, "pullOf", false);
drawPath_117 = Fn((V _self254, int _argc255, V S1_261, V _a258, V _a259, V _a260, V[] _rest256) => {
if (_self254.IsNullish) _self254 = GlobalV;
Set(pathG_64, "innerHTML", ((V)("")));
Set(bandG_65, "innerHTML", ((V)("")));
if (!(Truthy(aim_94))) {
return default;
}
if (Truthy(S1_261)) {
V lx_262 = default;
V ly_263 = default;
lx_262 = ((V)((-1000000000D)));
ly_263 = ((V)(0D));
{
double t_264 = 0;
t_264 = 0.02;
while (true) {
if (!(Le(((V)(t_264)), Get(S1_261, "tEnd")))) break;
V p_266 = default;
V s_267 = default;
V r_268 = default;
p_266 = Call(posAt_115, V.Undef, S1_261, ((V)(t_264)));
s_267 = Call(P_43, V.Undef, GetIdx(p_266, 0D), GetIdx(p_266, 1D), GetIdx(p_266, 2D));
if ((Hypot((ToNum(GetIdx(s_267, 0D)) - ToNum(lx_262)), (ToNum(GetIdx(s_267, 1D)) - ToNum(ly_263))) < 11D)) {
goto _cont265;
}
lx_262 = GetIdx(s_267, 0D);
ly_263 = GetIdx(s_267, 1D);
r_268 = Call(cl_17, V.Undef, ((V)(((3.4 * ToNum(GetIdx(s_267, 2D))) / 150D))), ((V)(1.8)), ((V)(3.6)));
Call(S_16, V.Undef, ((V)("circle")), NewObj(5).Put("cx", Call(r2_19, V.Undef, GetIdx(s_267, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(s_267, 1D))).Put("r", Call(r2_19, V.Undef, Add(r_268, ((V)(1.1))))).Put("fill", ((V)("#1e1430"))).Put("opacity", ((V)(0.3))).V, pathG_64);
Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_19, V.Undef, GetIdx(s_267, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(s_267, 1D))).Put("r", Call(r2_19, V.Undef, r_268)).Put("fill", ((V)("#ffffff"))).V, pathG_64);
_cont265: ;
t_264 = (t_264 + (1D / 240D));
}
}
if (Truthy(Get(S1_261, "cross"))) {
V c_269 = default;
double r_270 = 0;
c_269 = Call(P_43, V.Undef, GetIdx(Get(S1_261, "cross"), 0D), GetIdx(Get(S1_261, "cross"), 1D), ((V)(GZ_45)));
r_270 = ((BR_48 * ToNum(GetIdx(c_269, 2D))) + 3D);
Call(S_16, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_19, V.Undef, GetIdx(c_269, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(c_269, 1D))).Put("r", Call(r2_19, V.Undef, ((V)((r_270 + 1.2))))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#1e1430"))).Put("stroke-width", ((V)(3.6))).Put("opacity", ((V)(0.25))).V, pathG_64);
Call(S_16, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_19, V.Undef, GetIdx(c_269, 0D))).Put("cy", Call(r2_19, V.Undef, GetIdx(c_269, 1D))).Put("r", Call(r2_19, V.Undef, ((V)(r_270)))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.95))).V, pathG_64);
}
Call(S_16, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, Get(aim_94, "x0"))).S(" ").V(Call(r2_19, V.Undef, Get(aim_94, "y0"))).S("L").V(Call(r2_19, V.Undef, Get(aim_94, "x"))).S(" ").V(Call(r2_19, V.Undef, Get(aim_94, "y"))).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(3D))).Put("stroke-dasharray", ((V)("2 6"))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.8))).V, bandG_65);
}
Call(S_16, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_19, V.Undef, Get(aim_94, "x0"))).Put("cy", Call(r2_19, V.Undef, Get(aim_94, "y0"))).Put("r", ((V)(6D))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)((Truthy(S1_261) ? 0.85 : 0.6)))).V, bandG_65);
if (Truthy(S1_261)) {
Call(S_16, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_19, V.Undef, Get(aim_94, "x"))).Put("cy", Call(r2_19, V.Undef, Get(aim_94, "y"))).Put("r", ((V)(9D))).Put("fill", ((V)("#5cc2ff"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0.95))).V, bandG_65);
}
return default;
}, 1, "drawPath", false);
segD_123 = Fn((V _self271, int _argc272, V p_278, V a_279, V b_280, V _a277, V[] _rest273) => {
double vx_281 = 0;
double vy_282 = 0;
V u_283 = default;
if (_self271.IsNullish) _self271 = GlobalV;
vx_281 = (ToNum(GetIdx(b_280, 0D)) - ToNum(GetIdx(a_279, 0D)));
vy_282 = (ToNum(GetIdx(b_280, 1D)) - ToNum(GetIdx(a_279, 1D)));
u_283 = Call(cl_17, V.Undef, ((V)(((((ToNum(GetIdx(p_278, 0D)) - ToNum(GetIdx(a_279, 0D))) * vx_281) + ((ToNum(GetIdx(p_278, 1D)) - ToNum(GetIdx(a_279, 1D))) * vy_282)) / ((vx_281 * vx_281) + (vy_282 * vy_282))))), ((V)(0D)), ((V)(1D)));
return ((V)(Hypot(((ToNum(GetIdx(p_278, 0D)) - ToNum(GetIdx(a_279, 0D))) - (vx_281 * ToNum(u_283))), ((ToNum(GetIdx(p_278, 1D)) - ToNum(GetIdx(a_279, 1D))) - (vy_282 * ToNum(u_283))))));
return default;
}, 3, "segD", false);
clear_124 = Fn((V _self284, int _argc285, V bp_291, V x_292, V h_293, V t_294, V[] _rest286) => {
V pv_296 = default;
V u_297 = default;
V a_298 = default;
V b_299 = default;
V s_295 = default;
if (_self284.IsNullish) _self284 = GlobalV;
s_295 = (_argc285 > 4 ? _rest286[0] : V.Undef);
pv_296 = Call(pivOf_121, V.Undef, x_292, h_293);
u_297 = Arr(((V)(FdLibm.Sin((ToNum(t_294) * D2R_118)))), ((V)(FdLibm.Cos((ToNum(t_294) * D2R_118)))));
a_298 = Arr(((V)((ToNum(GetIdx(pv_296, 0D)) - (ToNum(GetIdx(u_297, 0D)) * PIV_119)))), ((V)((ToNum(GetIdx(pv_296, 1D)) - (ToNum(GetIdx(u_297, 1D)) * PIV_119)))));
b_299 = Arr(Add(GetIdx(pv_296, 0D), ((V)((ToNum(GetIdx(u_297, 0D)) * 0.62)))), Add(GetIdx(pv_296, 1D), ((V)((ToNum(GetIdx(u_297, 1D)) * 0.62)))));
return ((V)((Min((ToNum(Call(segD_123, V.Undef, bp_291, a_298, b_299)) - 0.4), (Truthy(s_295) ? (Hypot((ToNum(GetIdx(bp_291, 0D)) - ToNum(GetIdx(Call(pawOf_122, V.Undef, pv_296, s_295, t_294), 0D))), (ToNum(GetIdx(bp_291, 1D)) - ToNum(GetIdx(Call(pawOf_122, V.Undef, pv_296, s_295, t_294), 1D)))) - 0.12) : 9D)) - BR_48)));
return default;
}, 5, "clear", false);
reachFor_125 = Fn((V _self300, int _argc301, V bp_307, V s_308, V _a305, V _a306, V[] _rest302) => {
V dy_309 = default;
double dx_310 = 0;
V pv_311 = default;
double phi_312 = 0;
double t_313 = 0;
double h_314 = 0;
if (_self300.IsNullish) _self300 = GlobalV;
dy_309 = Call(cl_17, V.Undef, ((V)((ToNum(GetIdx(bp_307, 1D)) - ToNum(Call(cl_17, V.Undef, ((V)((ToNum(GetIdx(bp_307, 1D)) - 0.12))), ((V)((PIV_119 + 0.06))), ((V)(1.34))))))), ((V)((-0.5))), ((V)(0.38)));
dx_310 = (ToNum(s_308) * System.Math.Sqrt(((REACH_120 * REACH_120) - (ToNum(dy_309) * ToNum(dy_309)))));
pv_311 = Arr(((V)((ToNum(GetIdx(bp_307, 0D)) - dx_310))), ((V)((ToNum(GetIdx(bp_307, 1D)) - ToNum(dy_309)))));
phi_312 = (FdLibm.Atan2(ToNum(dy_309), dx_310) / D2R_118);
t_313 = (LtN(s_308, 0D) ? (180D - phi_312) : (-phi_312));
t_313 = (((t_313 + 540D) % 360D) - 180D);
h_314 = (ToNum(GetIdx(pv_311, 1D)) - PIV_119);
if (((((System.Math.Abs(t_313) > 56D) || (h_314 < (-0.01))) || (h_314 > 0.92)) || (System.Math.Abs((ToNum(GetIdx(pv_311, 0D)) - kx0_107)) > 1.45))) {
return V.Null;
}
return Arr(GetIdx(pv_311, 0D), ((V)(Max(0D, h_314))), ((V)(t_313)));
return default;
}, 2, "reachFor", false);
plan_126 = Fn((V _self315, int _argc316, V S1_322, V _a319, V _a320, V _a321, V[] _rest317) => {
V tK_323 = default;
V bp_324 = default;
V onT_325 = default;
double side_326 = 0;
double corner_327 = 0;
V read_328 = default;
V p_329 = default;
if (_self315.IsNullish) _self315 = GlobalV;
tK_323 = (Get(S1_322, "tK") is var _t330 && Truthy(_t330) ? _t330 : ((V)(0.7)));
bp_324 = (Get(S1_322, "kAt") is var _t331 && Truthy(_t331) ? _t331 : Arr(((V)((ToNum(Get(S1_322, "a")) * 2.2))), ((V)(0.8))));
onT_325 = (SEqS(Get(S1_322, "res"), "goal") ? V.True : V.False);
side_326 = ((System.Math.Abs((ToNum(GetIdx(bp_324, 0D)) - kx0_107)) < 0.32) ? 0D : Sign((ToNum(GetIdx(bp_324, 0D)) - kx0_107)));
corner_327 = ((ToNum(Call(cl_17, V.Undef, ((V)(((System.Math.Abs(ToNum(GetIdx(bp_324, 0D))) - 0.9) / 0.9))), ((V)(0D)), ((V)(1D)))) * 0.5) + (ToNum(Call(cl_17, V.Undef, ((V)(((ToNum(GetIdx(bp_324, 1D)) - 1.1) / 0.6))), ((V)(0D)), ((V)(1D)))) * 0.35));
read_328 = (Lt(Invoke(G("Math"), "random"), skill_96) ? V.True : V.False);
p_329 = V.Null;
if (Truthy((read_328 is var _t332 && !Truthy(_t332) ? _t332 : ((V)(side_326))))) {
V r_333 = default;
r_333 = Call(reachFor_125, V.Undef, bp_324, ((V)(side_326)));
if (Truthy((r_333 is var _t334 && !Truthy(_t334) ? _t334 : (GtN(Invoke(G("Math"), "random"), corner_327) ? V.True : V.False)))) {
p_329 = NewObj(5).Put("kind", ((V)("save"))).Put("s", ((V)(side_326))).Put("x", GetIdx(r_333, 0D)).Put("h", GetIdx(r_333, 1D)).Put("t", GetIdx(r_333, 2D)).V;
} else {
V r2__335 = default;
r2__335 = ((r_333 is var _t336 && Truthy(_t336) ? _t336 : Call(reachFor_125, V.Undef, Arr(((V)(((kx0_107 + (side_326 * 1.45)) + ((side_326 * REACH_120) * 0.8)))), Call(cl_17, V.Undef, GetIdx(bp_324, 1D), ((V)(0.3)), ((V)(1.6)))), ((V)(side_326)))) is var _t337 && Truthy(_t337) ? _t337 : Arr(((V)((kx0_107 + (side_326 * 1.1)))), ((V)(0.25)), ((V)((side_326 * 30D)))));
p_329 = NewObj(5).Put("kind", ((V)("beaten"))).Put("s", ((V)(side_326))).Put("x", ((V)((ToNum(GetIdx(r2__335, 0D)) - (side_326 * 0.55))))).Put("h", GetIdx(r2__335, 1D)).Put("t", GetIdx(r2__335, 2D)).V;
}
} else {
if (Truthy((read_328 is var _t338 && Truthy(_t338) ? _t338 : (LtN(Invoke(G("Math"), "random"), 0.3) ? V.True : V.False)))) {
p_329 = NewObj(5).Put("kind", ((V)("stay"))).Put("s", ((V)(0D))).Put("x", ((V)((kx0_107 + ((ToNum(GetIdx(bp_324, 0D)) - kx0_107) * 0.3))))).Put("h", Call(cl_17, V.Undef, ((V)((ToNum(GetIdx(bp_324, 1D)) - 0.9))), ((V)(0.05)), ((V)(0.55)))).Put("t", ((V)(0D))).V;
} else {
double s_339 = 0;
s_339 = (LtN(Invoke(G("Math"), "random"), 0.5) ? (-1D) : 1D);
p_329 = NewObj(5).Put("kind", ((V)("guess"))).Put("s", ((V)(s_339))).Put("x", ((V)((kx0_107 + (s_339 * 1D))))).Put("h", ((V)(0.22))).Put("t", ((V)((s_339 * 34D)))).V;
}
}
if (!SEqS(Get(p_329, "kind"), "save")) {
V c_340 = default;
double n_341 = 0;
c_340 = Call(clear_124, V.Undef, bp_324, Get(p_329, "x"), Get(p_329, "h"), Get(p_329, "t"), Get(p_329, "s"));
n_341 = 0D;
if (SEqS(Get(p_329, "kind"), "beaten")) {
while ((LtN(c_340, 0.12) && (n_341++ < 12D))) {
OpSet(p_329, "x", 1, ((V)((ToNum(Get(p_329, "s")) * 0.08))));
c_340 = Call(clear_124, V.Undef, bp_324, Get(p_329, "x"), Get(p_329, "h"), Get(p_329, "t"), Get(p_329, "s"));
}
} else {
if (LtN(c_340, 0.05)) {
Set(p_329, "kind", ((V)("block")));
}
}
}
if ((!(Truthy(onT_325)) && SEqS(Get(p_329, "kind"), "save"))) {
Set(p_329, "kind", ((V)("tip")));
}
Set(p_329, "tK", tK_323);
Set(p_329, "bp", bp_324);
Set(p_329, "t0", ((V)((0.12 + (ToNum(Invoke(G("Math"), "random")) * 0.08)))));
Set(p_329, "dur", ((V)(Max(0.28, (ToNum(tK_323) - ToNum(Get(p_329, "t0")))))));
return p_329;
return default;
}, 1, "plan", false);
rigPaw_127 = Fn((V _self342, int _argc343, V s_349, V _a346, V _a347, V _a348, V[] _rest344) => {
V I_350 = default;
V w_351 = default;
V sz_352 = default;
double left_353 = 0;
double top_354 = 0;
V q_355 = default;
V o_356 = default;
double r_357 = 0;
double dx_358 = 0;
double dy_359 = 0;
if (_self342.IsNullish) _self342 = GlobalV;
I_350 = Get(keeper_73, "I");
w_351 = ((I_350 is var _t360 && !Truthy(_t360) ? _t360 : Get(I_350, "W")) is var _t361 && !Truthy(_t361) ? _t361 : (LtN(s_349, 0D) ? Get(Get(I_350, "W"), "pawL") : (GtN(s_349, 0D) ? Get(Get(I_350, "W"), "pawR") : V.Null)));
sz_352 = Get(keeper_73, "size");
left_353 = (ToNum(Get(keeper_73, "x")) - (ToNum(sz_352) / 2D));
top_354 = (ToNum(Get(keeper_73, "y")) - (ToNum(sz_352) * 0.93));
q_355 = (Truthy((w_351 is var _t362 && !Truthy(_t362) ? _t362 : (IsFiniteV(GetIdx(w_351, 0D)) ? V.True : V.False))) ? Arr(((V)((left_353 + ((ToNum(GetIdx(w_351, 0D)) / 100D) * ToNum(sz_352))))), ((V)((top_354 + ((ToNum(GetIdx(w_351, 1D)) / 100D) * ToNum(sz_352)))))) : Arr(((V)((left_353 + (ToNum(sz_352) * 0.5)))), ((V)((top_354 + (ToNum(sz_352) * 0.55))))));
o_356 = Arr(((V)((left_353 + (ToNum(sz_352) * 0.5)))), ((V)((top_354 + (ToNum(sz_352) * 0.55)))));
r_357 = (ToNum(th_106) * D2R_118);
dx_358 = (ToNum(GetIdx(q_355, 0D)) - ToNum(GetIdx(o_356, 0D)));
dy_359 = (ToNum(GetIdx(q_355, 1D)) - ToNum(GetIdx(o_356, 1D)));
return Call(toW_52, V.Undef, ((V)((ToNum(Add(GetIdx(o_356, 0D), ((V)((dx_358 * FdLibm.Cos(r_357)))))) - (dy_359 * FdLibm.Sin(r_357))))), Add(Add(GetIdx(o_356, 1D), ((V)((dx_358 * FdLibm.Sin(r_357))))), ((V)((dy_359 * FdLibm.Cos(r_357))))), ((V)(KZ_50)));
return default;
}, 1, "rigPaw", false);
release_128 = Fn((V _self363, int _argc364, V k_370, V a_371, V S0_372, V _a369, V[] _rest365) => {
if (_self363.IsNullish) _self363 = GlobalV;
if (!string.Equals(phase_90.Str, "aim")) {
return default;
}
shotS_99 = (Truthy(((S0_372 is var _t373 && !Truthy(_t373) ? _t373 : (SEq(Get(S0_372, "k"), k_370) ? V.True : V.False)) is var _t374 && !Truthy(_t374) ? _t374 : (SEq(Get(S0_372, "a"), a_371) ? V.True : V.False))) ? S0_372 : Call(sim_114, V.Undef, k_370, a_371));
aim_94 = V.Null;
Call(drawPath_117, V.Undef, V.Null);
phase_90.Set("run");
ph0_91 = tNow_92;
runFrom_95 = Arr(Get(kick_74, "wx"), Get(kick_74, "wz"));
Invoke(SFX_21, "tap");
return default;
}, 3, "release", false);
launch_129 = Fn((V _self375, int _argc376, V _a378, V _a379, V _a380, V _a381, V[] _rest377) => {
V s_382 = default;
if (_self375.IsNullish) _self375 = GlobalV;
Set(ball_93, "st", ((V)("fly")));
Set(ball_93, "S", shotS_99);
Set(ball_93, "tl", tNow_92);
Set(ball_93, "fired", ((V)(0D)));
Set(ball_93, "live", ((V)(0D)));
Set(ball_93, "snap", V.Null);
kickT_102 = tNow_92;
Invoke(SFX_21, "thud");
Call(G("setTimeout"), V.Undef, Get(SFX_21, "whoosh"), ((V)(40D)));
s_382 = Call(P_43, V.Undef, Get(ball_93, "x"), Get(ball_93, "y"), Get(ball_93, "z"));
Invoke(ctx_37, "burst", GetIdx(s_382, 0D), Add(GetIdx(s_382, 1D), ((V)(4D))), ((V)("dust")), ((V)(7D)), NewObj(3).Put("v", ((V)(70D))).Put("life", ((V)(0.6))).Put("layer", fxG_62).V);
Invoke(ctx_37, "burst", GetIdx(s_382, 0D), GetIdx(s_382, 1D), ((V)("star")), ((V)(6D)), NewObj(4).Put("v", ((V)(150D))).Put("life", ((V)(0.45))).Put("layer", fxG_62).Put("col", ((V)("#fff6c8"))).V);
dv_108 = Call(plan_126, V.Undef, shotS_99);
Set(dv_108, "at", tNow_92);
Set(dv_108, "from", Arr(kx_104, ((V)(kH_105)), th_106));
phase_90.Set("fly");
return default;
}, 0, "launch", false);
settle_130 = Fn((V _self383, int _argc384, V goal_390, V txt_391, V col_392, V _a389, V[] _rest385) => {
if (_self383.IsNullish) _self383 = GlobalV;
if (Truthy(outcome_97)) {
return default;
}
outcome_97 = ((V)((Truthy(goal_390) ? "goal" : "miss")));
SetIdx(res_88, shot_89, ((V)((Truthy(goal_390) ? 1D : 0D))));
Call(drawDots_110, V.Undef);
phase_90.Set("after");
ph0_91 = tNow_92;
if (Truthy(goal_390)) {
double pts_393 = 0;
V corner_394 = default;
V top_395 = default;
V g_396 = default;
pts_393 = 100D;
corner_394 = ((System.Math.Abs(ToNum(Get(ball_93, "x"))) > 1.2) ? V.True : V.False);
top_395 = (GtN(Get(ball_93, "y"), 1.25) ? V.True : V.False);
if (Truthy(corner_394)) {
pts_393 = (pts_393 + 50D);
}
if (Truthy(top_395)) {
pts_393 = (pts_393 + 50D);
}
g_396 = Call(P_43, V.Undef, Get(ball_93, "x"), Get(ball_93, "y"), ((V)(GZ_45)));
Invoke(ctx_37, "add", ((V)(pts_393)), ((V)((ToNum(W_40) / 2D))), ((V)((ToNum(H_41) * 0.42))), ((V)(JsStrBuf.Begin().S((Truthy((corner_394 is var _t397 && !Truthy(_t397) ? _t397 : top_395)) ? "Top corner! " : (Truthy(corner_394) ? "Corner! " : (Truthy(top_395) ? "Top shelf! " : "Goal! ")))).S("+").N(pts_393).End())), ((V)("#ffe36e")));
Invoke(ctx_37, "burst", GetIdx(g_396, 0D), GetIdx(g_396, 1D), ((V)("confetti")), ((V)(22D)), NewObj(2).Put("v", ((V)(170D))).Put("layer", fxG_62).V);
Invoke(SFX_21, "score");
Invoke(kick_74, "play", ((V)("happy")));
Invoke(keeper_73, "play", ((V)("surprised")));
} else {
Invoke(ctx_37, "toast", txt_391, ((V)((ToNum(W_40) / 2D))), ((V)((ToNum(H_41) * 0.42))), (col_392 is var _t398 && Truthy(_t398) ? _t398 : ((V)("#ffffff"))), (true ? V.True : V.False));
Invoke(SFX_21, "miss");
if (SEqS(txt_391, "Saved!")) {
Invoke(keeper_73, "play", ((V)("happy")));
}
Invoke(kick_74, "play", ((V)("surprised")));
}
return default;
}, 3, "settle", false);
{ V _t399 = ctx_37;
if (_t399.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t399));
{ V _t400 = Get(_t399, "bg");
bg_38 = _t400; }
{ V _t401 = Get(_t399, "fg");
fg_39 = _t401; }
{ V _t402 = Get(_t399, "W");
W_40 = _t402; }
{ V _t403 = Get(_t399, "H");
H_41 = _t403; } }
CAM_42 = Arr(((V)(4D)), ((V)(0.984)), ((V)(144D)), ((V)(198D)));
P_43 = InvokeSpread(YG_15, "cam", new ArrBuilder().Spread(CAM_42).V);
G_44 = 9.8;
GZ_45 = 7D;
GW_46 = 1.9;
GH_47 = 1.9;
BR_48 = 0.11;
B0_49 = Arr(((V)(0D)), ((V)(BR_48)), ((V)(1D)));
KZ_50 = (GZ_45 - 0.45);
SM_51 = Get(YG_15, "SM");
toW_52 = Fn((V _self30, int _argc404, V sx_410, V sy_411, V z_412, V _a409, V[] _rest405) => {
double k_413 = 0;
k_413 = ((ToNum(GetIdx(CAM_42, 0D)) / ToNum(Add(GetIdx(CAM_42, 0D), z_412))) * ToNum(GetIdx(CAM_42, 3D)));
return Arr(((V)(((ToNum(sx_410) - (ToNum(W_40) / 2D)) / k_413))), ((V)((ToNum(GetIdx(CAM_42, 1D)) - ((ToNum(sy_411) - ToNum(GetIdx(CAM_42, 2D))) / k_413)))));
return default;
}, 3, "", true);
Invoke(YG_15, "yard", bg_38, NewObj(1).Put("hz", GetIdx(CAM_42, 2D)).V);
line_53 = Fn((V _self30, int _argc414, V pts_420, V w_421, V p_422, V op_423, V[] _rest415) => {
return Call(S_16, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_420, "map", Fn((V _self30, int _argc424, V q_430, V _a427, V _a428, V _a429, V[] _rest425) => {
V s_431 = default;
s_431 = Call(P_43, V.Undef, GetIdx(q_430, 0D), ((V)(0D)), GetIdx(q_430, 1D));
return ((V)(JsStrBuf.Begin().V(Call(r2_19, V.Undef, GetIdx(s_431, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(s_431, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", (w_421 is var _t432 && Truthy(_t432) ? _t432 : ((V)(2.5)))).Put("opacity", (op_423 is var _t433 && Truthy(_t433) ? _t433 : ((V)(0.9)))).Put("stroke-linejoin", ((V)("round"))).V, (p_422 is var _t434 && Truthy(_t434) ? _t434 : bg_38));
}, 4, "", true);
{
double i_435 = 0;
i_435 = 0D;
while (true) {
if (!((i_435 < 9D))) break;
double z0_437 = 0;
V a_438 = default;
V b_439 = default;
V c_440 = default;
V d_441 = default;
z0_437 = ((-1.2) + (i_435 * 1.1));
a_438 = Call(P_43, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)(z0_437)));
b_439 = Call(P_43, V.Undef, ((V)(14D)), ((V)(0D)), ((V)(z0_437)));
c_440 = Call(P_43, V.Undef, ((V)(14D)), ((V)(0D)), ((V)((z0_437 + 0.55))));
d_441 = Call(P_43, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)((z0_437 + 0.55))));
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Arr(a_438, b_439, c_440, d_441), "map", Fn((V _self30, int _argc442, V s_448, V _a445, V _a446, V _a447, V[] _rest443) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_19, V.Undef, GetIdx(s_448, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(s_448, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.07))).V, bg_38);
i_435++;
}
}
Call(line_53, V.Undef, Arr(Arr(((V)((-6D))), ((V)(GZ_45))), Arr(((V)(6D)), ((V)(GZ_45)))));
Call(line_53, V.Undef, Arr(Arr(((V)((-3.1))), ((V)(GZ_45))), Arr(((V)((-3.1))), ((V)((GZ_45 - 2.2)))), Arr(((V)(3.1)), ((V)((GZ_45 - 2.2)))), Arr(((V)(3.1)), ((V)(GZ_45)))));
Call(line_53, V.Undef, Arr(Arr(((V)((-2.4))), ((V)(GZ_45))), Arr(((V)((-2.4))), ((V)((GZ_45 - 0.8)))), Arr(((V)(2.4)), ((V)((GZ_45 - 0.8)))), Arr(((V)(2.4)), ((V)(GZ_45)))), ((V)(2D)), bg_38, ((V)(0.7)));
Call(line_53, V.Undef, Arr(Arr(((V)((-5.2))), ((V)(GZ_45))), Arr(((V)((-5.2))), ((V)((-1.2))))), ((V)(2D)), bg_38, ((V)(0.5)));
Call(line_53, V.Undef, Arr(Arr(((V)(5.2)), ((V)(GZ_45))), Arr(((V)(5.2)), ((V)((-1.2))))), ((V)(2D)), bg_38, ((V)(0.5)));
{
JsStrBuf d_449 = null;
d_449 = new JsStrBuf("");
{
double i_450 = 0;
i_450 = 0D;
while (true) {
if (!((i_450 <= 18D))) break;
double a_452 = 0;
V s_453 = default;
a_452 = ((System.Math.PI * i_450) / 18D);
s_453 = Call(P_43, V.Undef, ((V)((FdLibm.Cos(a_452) * 1.1))), ((V)(0D)), ((V)(((GZ_45 - 2.2) - (FdLibm.Sin(a_452) * 0.7)))));
d_449.S((NumTruthy(i_450) ? "L" : "M")).V(Call(r2_19, V.Undef, GetIdx(s_453, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(s_453, 1D)));
i_450++;
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(d_449.Str))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.2))).Put("opacity", ((V)(0.8))).V, bg_38);
}
spot_54 = Call(P_43, V.Undef, ((V)(0D)), ((V)(0D)), GetIdx(B0_49, 2D));
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", GetIdx(spot_54, 0D)).Put("cy", GetIdx(spot_54, 1D)).Put("rx", ((V)(9D))).Put("ry", ((V)(2.6))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.9))).V, bg_38);
netG_55 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_38);
shG_56 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_38);
postG_57 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, fg_39);
ballSlotBack_58 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_38);
ballL_59 = Call(S_16, V.Undef, ((V)("svg")), NewObj(4).Put("viewBox", ((V)(JsStrBuf.Begin().S("0 0 ").V(W_40).S(" ").V(H_41).End()))).Put("class", ((V)("yg-layer"))).Put("preserveAspectRatio", ((V)("none"))).Put("style", ((V)("pointer-events:none;z-index:2"))).V, Get(fg_39, "parentNode"));
trailG_60 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, ballL_59);
ballSlot_61 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, ballL_59);
fxG_62 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, ballL_59);
aimL_63 = Call(S_16, V.Undef, ((V)("svg")), NewObj(4).Put("viewBox", ((V)(JsStrBuf.Begin().S("0 0 ").V(W_40).S(" ").V(H_41).End()))).Put("class", ((V)("yg-layer"))).Put("preserveAspectRatio", ((V)("none"))).Put("style", ((V)("pointer-events:none;z-index:4"))).V, Get(fg_39, "parentNode"));
pathG_64 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, aimL_63);
bandG_65 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, aimL_63);
NX_66 = 18D;
NY_67 = 9D;
ND_68 = 1.1;
bulge_69 = NewObj(4).Put("x", ((V)(0D))).Put("y", ((V)(0D))).Put("a", ((V)(0D))).Put("t", ((V)((-9D)))).V;
{
V a_454 = default;
V b_455 = default;
V c_456 = default;
V d_457 = default;
double w_458 = 0;
V pth_459 = default;
a_454 = Call(P_43, V.Undef, ((V)((-GW_46))), ((V)(0D)), ((V)(GZ_45)));
b_455 = Call(P_43, V.Undef, ((V)((-GW_46))), ((V)(GH_47)), ((V)(GZ_45)));
c_456 = Call(P_43, V.Undef, ((V)(GW_46)), ((V)(GH_47)), ((V)(GZ_45)));
d_457 = Call(P_43, V.Undef, ((V)(GW_46)), ((V)(0D)), ((V)(GZ_45)));
w_458 = (0.08 * ToNum(GetIdx(a_454, 2D)));
pth_459 = ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, GetIdx(a_454, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(a_454, 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(b_455, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(b_455, 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(c_456, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(c_456, 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(d_457, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(d_457, 1D))).End()));
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", pth_459).Put("fill", ((V)("none"))).Put("stroke", ((V)("#c9d2dc"))).Put("stroke-width", Call(r2_19, V.Undef, ((V)((w_458 + 1.6))))).Put("stroke-linejoin", ((V)("round"))).V, postG_57);
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", pth_459).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", Call(r2_19, V.Undef, ((V)(w_458)))).Put("stroke-linejoin", ((V)("round"))).V, postG_57);
}
kp_71 = Invoke(ctx_37, "opponent");
kpName_72 = Invoke(ctx_37, "nameOf", kp_71);
keeper_73 = Invoke(ctx_37, "creature", kp_71, NewObj(1).Put("yaw", ((V)(0D))).V);
kick_74 = Invoke(ctx_37, "creature", Get(ctx_37, "playerKey"), NewObj(1).Put("yaw", ((V)(160D))).V);
RUN0_75 = Arr(((V)((-1D))), ((V)((-0.25))));
KICKAT_76 = Arr(((V)((-0.45))), ((V)(0.8)));
KS_77 = 0.55;
kShadow_78 = Invoke(YG_15, "shadow", shG_56, ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(0.2)));
pShadow_79 = Invoke(YG_15, "shadow", shG_56, ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(0.2)));
bShadow_80 = Call(S_16, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#3a2a55"))).Put("opacity", ((V)(0.2))).V, shG_56);
bG_81 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, ballSlot_61);
bC_82 = Call(S_16, V.Undef, ((V)("circle")), NewObj(3).Put("fill", ((V)("url(#ygWhite)"))).Put("stroke", ((V)("#3a3a44"))).Put("stroke-width", ((V)(1D))).V, bG_81);
bP_83 = Call(S_16, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#3a3a44"))).V, bG_81);
PULL_84 = 150D;
DT_85 = (1D / 240D);
LIFE_86 = 2.6;
RUN_87 = 760D;
res_88 = Arr();
shot_89 = 0D;
phase_90 = new JsStrBuf("aim");
ph0_91 = ((V)(0D));
tNow_92 = ((V)(0D));
ball_93 = V.Null;
aim_94 = V.Null;
runFrom_95 = V.Null;
skill_96 = ((V)(0.35));
outcome_97 = V.Null;
wind_98 = ((V)(0D));
shotS_99 = V.Null;
quietAt_100 = ((V)(0D));
trail_101 = Arr();
kickT_102 = ((V)((-9D)));
dropAt_103 = ((V)(0D));
kx_104 = ((V)(0D));
kH_105 = 0D;
th_106 = ((V)(0D));
kx0_107 = 0D;
dv_108 = V.Null;
dotsEl_109 = Invoke(G("document"), "createElement", ((V)("div")));
Set(dotsEl_109, "className", ((V)("yg-pill")));
Set(Get(dotsEl_109, "style"), "cssText", ((V)("position:absolute;left:50%;top:12.5%;transform:translateX(-50%);display:flex;gap:6px;padding:6px 10px;font-size:14px;")));
Invoke(Invoke(Get(Get(ctx_37, "crl"), "parentNode"), "querySelector", ((V)(".yg-hud"))), "appendChild", dotsEl_109);
posAt_115 = Fn((V _self30, int _argc460, V S1_466, V t_467, V _a464, V _a465, V[] _rest461) => {
V f_468 = default;
double i_469 = 0;
double u_470 = 0;
V A_471 = default;
V B_472 = default;
f_468 = Call(cl_17, V.Undef, ((V)((ToNum(t_467) / DT_85))), ((V)(0D)), ((V)((ToNum(Get(Get(S1_466, "pos"), "length")) - 1.001))));
i_469 = System.Math.Floor(ToNum(f_468));
u_470 = (ToNum(f_468) - i_469);
A_471 = GetIdx(Get(S1_466, "pos"), i_469);
B_472 = GetIdx(Get(S1_466, "pos"), (i_469 + 1D));
return Arr(Call(lerp_18, V.Undef, GetIdx(A_471, 0D), GetIdx(B_472, 0D), ((V)(u_470))), Call(lerp_18, V.Undef, GetIdx(A_471, 1D), GetIdx(B_472, 1D), ((V)(u_470))), Call(lerp_18, V.Undef, GetIdx(A_471, 2D), GetIdx(B_472, 2D), ((V)(u_470))));
return default;
}, 2, "", true);
D2R_118 = (System.Math.PI / 180D);
PIV_119 = 0.44;
REACH_120 = 0.7;
pivOf_121 = Fn((V _self30, int _argc473, V x_479, V h_480, V _a477, V _a478, V[] _rest474) => {
return Arr(x_479, Add(h_480, ((V)(PIV_119))));
}, 2, "", true);
pawOf_122 = Fn((V _self30, int _argc481, V pv_487, V s_488, V t_489, V _a486, V[] _rest482) => {
double ph_490 = 0;
ph_490 = ((LtN(s_488, 0D) ? (180D - ToNum(t_489)) : (-ToNum(t_489))) * D2R_118);
return Arr(Add(GetIdx(pv_487, 0D), ((V)((FdLibm.Cos(ph_490) * REACH_120)))), Add(GetIdx(pv_487, 1D), ((V)((FdLibm.Sin(ph_490) * REACH_120)))));
return default;
}, 3, "", true);
kickKey_131 = Fn((V _self30, int _argc491, V k_497, V a_498, V _a495, V _a496, V[] _rest492) => {
if (string.Equals(phase_90.Str, "aim")) {
Call(release_128, V.Undef, k_497, a_498);
}
return (true ? V.True : V.False);
return default;
}, 2, "", true);
api_132 = NewObj(14).Put("start", Fn((V _self499, int _argc500, V _a502, V _a503, V _a504, V _a505, V[] _rest501) => {
if (_self499.IsNullish) _self499 = GlobalV;
shot_89 = 0D;
Set(res_88, "length", ((V)(0D)));
Invoke(ctx_37, "setScore", ((V)(0D)));
aim_94 = V.Null;
Call(resetShot_112, V.Undef);
return default;
}, 0, "start", false)).Put("down", Fn((V _self506, int _argc507, V p_513, V _a510, V _a511, V _a512, V[] _rest508) => {
if (_self506.IsNullish) _self506 = GlobalV;
if (string.Equals(phase_90.Str, "aim")) {
aim_94 = NewObj(6).Put("x0", Get(p_513, "x")).Put("y0", Get(p_513, "y")).Put("x", Get(p_513, "x")).Put("y", Get(p_513, "y")).Put("p", V.Null).Put("S", V.Null).V;
}
return default;
}, 1, "down", false)).Put("move", Fn((V _self514, int _argc515, V p_521, V _a518, V _a519, V _a520, V[] _rest516) => {
if (_self514.IsNullish) _self514 = GlobalV;
if (Truthy(aim_94)) {
Set(aim_94, "x", Get(p_521, "x"));
Set(aim_94, "y", Get(p_521, "y"));
}
return default;
}, 1, "move", false)).Put("up", Fn((V _self522, int _argc523, V p_529, V _a526, V _a527, V _a528, V[] _rest524) => {
V pp_530 = default;
V S0_531 = default;
if (_self522.IsNullish) _self522 = GlobalV;
if (!(Truthy(aim_94))) {
return default;
}
if (Truthy(p_529)) {
Set(aim_94, "x", Get(p_529, "x"));
Set(aim_94, "y", Get(p_529, "y"));
}
pp_530 = (Get(aim_94, "force") is var _t532 && Truthy(_t532) ? _t532 : Call(pullOf_116, V.Undef, NewObj(2).Put("x", ((V)((ToNum(Get(aim_94, "x")) - ToNum(Get(aim_94, "x0")))))).Put("y", ((V)((ToNum(Get(aim_94, "y")) - ToNum(Get(aim_94, "y0")))))).V));
S0_531 = Get(aim_94, "S");
if ((!(Truthy(pp_530)) || !string.Equals(phase_90.Str, "aim"))) {
aim_94 = V.Null;
Call(drawPath_117, V.Undef, V.Null);
return default;
}
Call(release_128, V.Undef, Get(pp_530, "k"), Get(pp_530, "a"), S0_531);
return default;
}, 1, "up", false)).Put("key", Fn((V _self533, int _argc534, V k_540, V dn_541, V _a538, V _a539, V[] _rest535) => {
if (_self533.IsNullish) _self533 = GlobalV;
if (!(Truthy(dn_541))) {
return default;
}
if ((SEqS(k_540, "ArrowUp") || SEqS(k_540, " "))) {
return Call(kickKey_131, V.Undef, ((V)(0.3)), ((V)(0D)));
}
if (SEqS(k_540, "ArrowLeft")) {
return Call(kickKey_131, V.Undef, ((V)(0.4)), ((V)((-0.55))));
}
if (SEqS(k_540, "ArrowRight")) {
return Call(kickKey_131, V.Undef, ((V)(0.4)), ((V)(0.55)));
}
return default;
}, 2, "key", false)).Put("_aim", Fn((V _self30, int _argc542, V k_548, V a_549, V _a546, V _a547, V[] _rest543) => {
aim_94 = NewObj(6).Put("x0", ((V)((ToNum(W_40) * 0.6)))).Put("y0", ((V)((ToNum(H_41) * 0.35)))).Put("x", ((V)(((ToNum(W_40) * 0.6) - (ToNum(a_549) * 60D))))).Put("y", ((V)((((ToNum(H_41) * 0.35) + 16D) + (ToNum(k_548) * PULL_84))))).Put("force", NewObj(2).Put("k", k_548).Put("a", a_549).V).Put("S", V.Null).V;
return default;
}, 2, "_aim", true)).Put("_shoot", Fn((V _self30, int _argc550, V k_556, V a_557, V _a554, V _a555, V[] _rest551) => {
if (string.Equals(phase_90.Str, "aim")) {
Call(release_128, V.Undef, k_556, (a_557.IsNullish ? ((V)(0D)) : a_557));
}
return default;
}, 2, "_shoot", true)).Put("_sim", Fn((V _self30, int _argc558, V k_564, V a_565, V _a562, V _a563, V[] _rest559) => {
V S1_566 = default;
S1_566 = Call(sim_114, V.Undef, k_564, a_565);
return NewObj(4).Put("res", Get(S1_566, "res")).Put("cross", (Get(S1_566, "cross") is var _t574 && !Truthy(_t574) ? _t574 : Invoke(Get(S1_566, "cross"), "map", Fn((V _self30, int _argc567, V v_573, V _a570, V _a571, V _a572, V[] _rest568) => {
return ((V)(ToNum(Invoke(v_573, "toFixed", ((V)(2D))))));
}, 1, "", true)))).Put("kAt", (Get(S1_566, "kAt") is var _t582 && !Truthy(_t582) ? _t582 : Invoke(Get(S1_566, "kAt"), "map", Fn((V _self30, int _argc575, V v_581, V _a578, V _a579, V _a580, V[] _rest576) => {
return ((V)(ToNum(Invoke(v_581, "toFixed", ((V)(2D))))));
}, 1, "", true)))).Put("tK", ((V)(ToNum(Invoke(Get(S1_566, "tK"), "toFixed", ((V)(2D))))))).V;
return default;
}, 2, "_sim", true)).Put("_skill", Fn((V _self30, int _argc583, V v_589, V _a586, V _a587, V _a588, V[] _rest584) => {
skill_96 = v_589;
return default;
}, 1, "_skill", true)).Put("_state", Fn((V _self30, int _argc590, V _a592, V _a593, V _a594, V _a595, V[] _rest591) => {
return NewObj(5).Put("phase", ((V)(phase_90.Str))).Put("shot", ((V)(shot_89))).Put("res", Invoke(res_88, "slice")).Put("ball", (ball_93 is var _t603 && !Truthy(_t603) ? _t603 : Invoke(Arr(Get(ball_93, "x"), Get(ball_93, "y"), Get(ball_93, "z")), "map", Fn((V _self30, int _argc596, V v_602, V _a599, V _a600, V _a601, V[] _rest597) => {
return ((V)(ToNum(Invoke(v_602, "toFixed", ((V)(2D))))));
}, 1, "", true)))).Put("dive", (dv_108 is var _t604 && !Truthy(_t604) ? _t604 : NewObj(5).Put("kind", Get(dv_108, "kind")).Put("s", Get(dv_108, "s")).Put("x", ((V)(ToNum(Invoke(Get(dv_108, "x"), "toFixed", ((V)(2D))))))).Put("h", ((V)(ToNum(Invoke(Get(dv_108, "h"), "toFixed", ((V)(2D))))))).Put("t", ((V)(ToNum(Invoke(Get(dv_108, "t"), "toFixed", ((V)(1D))))))).V)).V;
}, 0, "_state", true)).Put("_ready", Fn((V _self30, int _argc605, V _a607, V _a608, V _a609, V _a610, V[] _rest606) => {
return ((string.Equals(phase_90.Str, "aim") && !(Truthy(aim_94))) ? V.True : V.False);
}, 0, "_ready", true)).Put("celebrate", Fn((V _self611, int _argc612, V st_618, V _a615, V _a616, V _a617, V[] _rest613) => {
if (_self611.IsNullish) _self611 = GlobalV;
Invoke(kick_74, "play", ((V)((GeN(st_618, 2D) ? "happy" : "idle"))));
return default;
}, 1, "celebrate", false)).Put("destroy", Fn((V _self619, int _argc620, V _a622, V _a623, V _a624, V _a625, V[] _rest621) => {
if (_self619.IsNullish) _self619 = GlobalV;
Invoke(aimL_63, "remove");
Invoke(ballL_59, "remove");
return default;
}, 0, "destroy", false)).Put("update", Fn((V _self626, int _argc627, V dt_633, V t_634, V _a631, V _a632, V[] _rest628) => {
double ts_635 = 0;
V KE_636 = default;
V s_637 = default;
double r_638 = 0;
V inG_639 = default;
V front_640 = default;
V sp_641 = default;
JsStrBuf pd_642 = null;
V g0_643 = default;
V hk_644 = default;
if (_self626.IsNullish) _self626 = GlobalV;
tNow_92 = t_634;
ts_635 = (ToNum(t_634) - ToNum(ph0_91));
if (string.Equals(phase_90.Str, "aim")) {
V pp_645 = default;
pp_645 = V.Null;
if (Truthy(aim_94)) {
pp_645 = (Get(aim_94, "force") is var _t646 && Truthy(_t646) ? _t646 : Call(pullOf_116, V.Undef, NewObj(2).Put("x", ((V)((ToNum(Get(aim_94, "x")) - ToNum(Get(aim_94, "x0")))))).Put("y", ((V)((ToNum(Get(aim_94, "y")) - ToNum(Get(aim_94, "y0")))))).V));
Set(aim_94, "p", pp_645);
Set(aim_94, "S", (Truthy(pp_645) ? (Truthy(((Get(aim_94, "S") is var _t647 && !Truthy(_t647) ? _t647 : (SEq(Get(Get(aim_94, "S"), "k"), Get(pp_645, "k")) ? V.True : V.False)) is var _t648 && !Truthy(_t648) ? _t648 : (SEq(Get(Get(aim_94, "S"), "a"), Get(pp_645, "a")) ? V.True : V.False))) ? Get(aim_94, "S") : Call(sim_114, V.Undef, Get(pp_645, "k"), Get(pp_645, "a"))) : V.Null));
Call(drawPath_117, V.Undef, Get(aim_94, "S"));
}
wind_98 = Call(lerp_18, V.Undef, wind_98, ((V)((Truthy(pp_645) ? (0.35 + (0.65 * ToNum(Get(pp_645, "k")))) : 0D))), ((V)((1D - Pow(0.002, ToNum(dt_633))))));
Set(kick_74, "wx", ((V)((ToNum(GetIdx(RUN0_75, 0D)) - (0.08 * ToNum(wind_98))))));
Set(kick_74, "wz", ((V)((ToNum(GetIdx(RUN0_75, 1D)) - (0.1 * ToNum(wind_98))))));
Invoke(kick_74, "yaw", ((V)((160D + (6D * FdLibm.Sin((ToNum(t_634) / 900D)))))));
Invoke(kick_74, "pose", NewObj(5).Put("sq", ((V)((0.1 * ToNum(wind_98))))).Put("lean", ((V)(((-4D) * ToNum(wind_98))))).Put("armL", ((V)((25D + (45D * ToNum(wind_98)))))).Put("armR", ((V)((20D + (35D * ToNum(wind_98)))))).Put("footR", ((V)((2D * ToNum(wind_98))))).V);
} else {
if (string.Equals(phase_90.Str, "run")) {
V u_649 = default;
double e_650 = 0;
u_649 = Call(cl_17, V.Undef, ((V)((ts_635 / RUN_87))), ((V)(0D)), ((V)(1D)));
e_650 = (LtN(u_649, 0.85) ? (ToNum(u_649) / 0.85) : 1D);
Set(kick_74, "wx", Call(lerp_18, V.Undef, GetIdx(runFrom_95, 0D), GetIdx(KICKAT_76, 0D), ((V)(((ToNum(Call(SM_51, V.Undef, ((V)(e_650)))) * 0.2) + (e_650 * 0.8))))));
Set(kick_74, "wz", Call(lerp_18, V.Undef, GetIdx(runFrom_95, 1D), GetIdx(KICKAT_76, 1D), ((V)(((ToNum(Call(SM_51, V.Undef, ((V)(e_650)))) * 0.2) + (e_650 * 0.8))))));
Invoke(kick_74, "yaw", Call(lerp_18, V.Undef, ((V)(150D)), ((V)(172D)), u_649));
if (LtN(u_649, 0.82)) {
Invoke(kick_74, "pose", NewObj(2).Put("lean", ((V)(4D))).Put("sq", ((V)(0.02))).V);
Invoke(kick_74, "walk", ((V)((ToNum(dt_633) * 1.7))), ((V)(1D)), ((V)(160D)));
} else {
double v_651 = 0;
v_651 = ((ToNum(u_649) - 0.82) / 0.18);
Invoke(kick_74, "pose", NewObj(5).Put("lean", Call(lerp_18, V.Undef, ((V)(4D)), ((V)((-3D))), ((V)(v_651)))).Put("sq", ((V)((0.06 * v_651)))).Put("footR", Call(lerp_18, V.Undef, ((V)(0D)), ((V)((-4D))), ((V)(v_651)))).Put("armL", ((V)((40D * v_651)))).Put("armR", ((V)((70D * v_651)))).V);
}
if (GeN(u_649, 1D)) {
Call(launch_129, V.Undef);
ph0_91 = t_634;
}
} else {
double kt_652 = 0;
kt_652 = (ToNum(t_634) - ToNum(kickT_102));
Invoke(kick_74, "pose", Call(track_20, V.Undef, Arr(Arr(((V)(0D)), NewObj(5).Put("lean", ((V)(9D))).Put("sq", ((V)((-0.06)))).Put("footR", ((V)(9D))).Put("armL", ((V)(70D))).Put("armR", ((V)((-10D)))).V), Arr(((V)(140D)), NewObj(5).Put("lean", ((V)(6D))).Put("sq", ((V)(0.03))).Put("footR", ((V)(6D))).Put("armL", ((V)(80D))).Put("armR", ((V)(20D))).V), Arr(((V)(520D)), NewObj(5).Put("lean", ((V)(0D))).Put("sq", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V)), ((V)(kt_652))));
Invoke(kick_74, "yaw", ((V)(172D)));
}
}
KE_636 = NewObj(4).Put("armL", ((V)((40D + (10D * FdLibm.Sin((ToNum(t_634) / 300D))))))).Put("armR", ((V)((40D + (10D * FdLibm.Sin(((ToNum(t_634) / 300D) + 1D))))))).Put("sq", ((V)((0.06 + (0.02 * FdLibm.Sin((ToNum(t_634) / 150D))))))).Put("lean", ((V)((FdLibm.Sin((ToNum(t_634) / 700D)) * 3D)))).V;
if (!(Truthy(dv_108))) {
kx0_107 = ToNum((kx_104 = ((V)((FdLibm.Sin((ToNum(t_634) / 800D)) * 0.22)))));
kH_105 = 0D;
th_106 = ((V)(0D));
} else {
double tt_653 = 0;
V u_654 = default;
V e_655 = default;
V f_656 = default;
V side_657 = default;
V ext_658 = default;
tt_653 = ((ToNum(t_634) - ToNum(Get(dv_108, "at"))) / 1000D);
u_654 = Call(cl_17, V.Undef, ((V)(((tt_653 - ToNum(Get(dv_108, "t0"))) / ToNum(Get(dv_108, "dur"))))), ((V)(0D)), ((V)(1D)));
e_655 = Call(SM_51, V.Undef, u_654);
f_656 = Call(cl_17, V.Undef, ((V)(((tt_653 - ToNum(Get(dv_108, "tK"))) / 0.38))), ((V)(0D)), ((V)(1D)));
side_657 = Get(dv_108, "s");
kx_104 = Add(Call(lerp_18, V.Undef, GetIdx(Get(dv_108, "from"), 0D), Get(dv_108, "x"), e_655), ((V)(((ToNum(side_657) * 0.18) * ToNum(f_656)))));
kH_105 = ((LtN(u_654, 1D) ? (ToNum(Get(dv_108, "h")) * FdLibm.Sin(((ToNum(e_655) * System.Math.PI) / 2D))) : (ToNum(Get(dv_108, "h")) * (1D - (ToNum(f_656) * ToNum(f_656))))) * ((SEqS(Get(dv_108, "kind"), "stay") || SEqS(Get(dv_108, "kind"), "block")) ? 1D : 1D));
th_106 = (Truthy(side_657) ? Add(Call(lerp_18, V.Undef, ((V)(0D)), Get(dv_108, "t"), e_655), ((V)(((((ToNum(side_657) * 72D) - ToNum(Get(dv_108, "t"))) * ToNum(Call(SM_51, V.Undef, f_656))) * ((GtN(Get(dv_108, "h"), 0.12) || (System.Math.Abs(ToNum(Get(dv_108, "t"))) > 20D)) ? 1D : 0D))))) : ((V)(0D)));
ext_658 = (LtN(side_657, 0D) ? NewObj(5).Put("armL", ((V)(130D))).Put("armR", ((V)(150D))).Put("hLx", ((V)(((-14D) * ToNum(e_655))))).Put("hLy", ((V)(((-28D) * ToNum(e_655))))).Put("footR", ((V)((5D * ToNum(e_655))))).V : (GtN(side_657, 0D) ? NewObj(5).Put("armR", ((V)(130D))).Put("armL", ((V)(150D))).Put("hRx", ((V)((14D * ToNum(e_655))))).Put("hRy", ((V)(((-28D) * ToNum(e_655))))).Put("footL", ((V)((5D * ToNum(e_655))))).V : NewObj(4).Put("armL", ((V)((165D * ToNum(e_655))))).Put("armR", ((V)((165D * ToNum(e_655))))).Put("footL", ((V)((3D * ToNum(e_655))))).Put("sq", ((V)(((-0.05) * ToNum(e_655))))).V));
KE_636 = Object_assign(ext_658, ((SEqS(outcome_97, "goal") && GtN(f_656, 0.5)) ? NewObj(2).Put("open", ((V)(1D))).Put("cross", ((V)(0.6))).V : ((SEqS(outcome_97, "miss") && GtN(f_656, 0.6)) ? NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.8))).V : NewObj(2).Put("teary", e_655).Put("open", e_655).V)));
if (((Gt(((V)(tt_653)), Get(dv_108, "t0")) && Lt(((V)(tt_653)), Add(Get(dv_108, "tK"), ((V)(0.1))))) && Gt(t_634, dropAt_103))) {
double hp_659 = 0;
dropAt_103 = Add(t_634, ((V)(110D)));
hp_659 = (ToNum(Get(keeper_73, "y")) - (ToNum(Get(keeper_73, "size")) * 0.8));
Invoke(ctx_37, "burst", Add(Get(keeper_73, "x"), ((V)((((ToNum(Invoke(G("Math"), "random")) - 0.5) * ToNum(Get(keeper_73, "size"))) * 0.5)))), ((V)(hp_659)), ((V)("drop")), ((V)(1D)), NewObj(3).Put("v", ((V)(50D))).Put("life", ((V)(0.5))).Put("layer", fxG_62).V);
}
}
Invoke(keeper_73, "pose", KE_636);
Call(place_111, V.Undef);
if (Truthy((Get(ball_93, "S") is var _t660 && !Truthy(_t660) ? _t660 : (!(Truthy(Get(ball_93, "live"))) ? V.True : V.False)))) {
double tt_661 = 0;
V p_662 = default;
V touch_663 = default;
tt_661 = ((ToNum(t_634) - ToNum(Get(ball_93, "tl"))) / 1000D);
p_662 = Call(posAt_115, V.Undef, Get(ball_93, "S"), ((V)(tt_661)));
Set(ball_93, "x", GetIdx(p_662, 0D));
Set(ball_93, "y", GetIdx(p_662, 1D));
Set(ball_93, "z", GetIdx(p_662, 2D));
Set(ball_93, "spin", ((V)((tt_661 * 16D))));
touch_663 = (dv_108 is var _t664 && !Truthy(_t664) ? _t664 : (((SEqS(Get(dv_108, "kind"), "save") || SEqS(Get(dv_108, "kind"), "tip")) || SEqS(Get(dv_108, "kind"), "block")) ? V.True : V.False));
if (Truthy((touch_663 is var _t665 && !Truthy(_t665) ? _t665 : (!(Truthy(outcome_97)) ? V.True : V.False)))) {
double lead_666 = 0;
lead_666 = (ToNum(Get(dv_108, "tK")) - tt_661);
if ((lead_666 < 0.11)) {
V sn_667 = default;
V w_668 = default;
if (!(Truthy(Get(ball_93, "snap")))) {
Set(ball_93, "snap", Call(rigPaw_127, V.Undef, (SEqS(Get(dv_108, "kind"), "block") ? ((V)(0D)) : Get(dv_108, "s"))));
}
sn_667 = Call(rigPaw_127, V.Undef, (SEqS(Get(dv_108, "kind"), "block") ? ((V)(0D)) : Get(dv_108, "s")));
w_668 = Call(SM_51, V.Undef, ((V)((1D - (Max(0D, lead_666) / 0.11)))));
Set(ball_93, "x", Call(lerp_18, V.Undef, Get(ball_93, "x"), GetIdx(sn_667, 0D), w_668));
Set(ball_93, "y", Call(lerp_18, V.Undef, Get(ball_93, "y"), GetIdx(sn_667, 1D), w_668));
}
if (Ge(((V)(tt_661)), Get(dv_108, "tK"))) {
V bz_669 = default;
V s_670 = default;
bz_669 = Get(ball_93, "z");
Set(ball_93, "live", ((V)(1D)));
Set(ball_93, "z", ((V)((KZ_50 - 0.02))));
Set(ball_93, "vz", ((V)(((-2.2) - ToNum(Invoke(G("Math"), "random"))))));
Set(ball_93, "vx", ((V)((ToNum((Get(dv_108, "s") is var _t671 && Truthy(_t671) ? _t671 : ((V)((LtN(Invoke(G("Math"), "random"), 0.5) ? (-1D) : 1D))))) * ToNum(Add(((V)(1.6)), Invoke(G("Math"), "random")))))));
Set(ball_93, "vy", ((V)((SEqS(Get(dv_108, "kind"), "tip") ? 3.2 : 2.2))));
Set(ball_93, "st", ((V)("out")));
Call(settle_130, V.Undef, (false ? V.True : V.False), ((V)("Saved!")), ((V)("#8fe0ff")));
Invoke(SFX_21, "thud");
s_670 = Call(P_43, V.Undef, Get(ball_93, "x"), Get(ball_93, "y"), Get(ball_93, "z"));
Invoke(ctx_37, "burst", GetIdx(s_670, 0D), GetIdx(s_670, 1D), ((V)("star")), ((V)(7D)), NewObj(4).Put("v", ((V)(120D))).Put("life", ((V)(0.4))).Put("layer", fxG_62).Put("col", ((V)("#ffffff"))).V);
}
}
while (((!(Truthy(Get(ball_93, "live"))) && Lt(Get(ball_93, "fired"), Get(Get(Get(ball_93, "S"), "ev"), "length"))) && LeN(GetIdx(GetK(Get(Get(ball_93, "S"), "ev"), Get(ball_93, "fired")), 0D), tt_661))) {
V e_672 = default;
e_672 = GetIdx(GetIdx(Get(Get(ball_93, "S"), "ev"), IncM(ball_93, "fired", 1D, false)), 1D);
if (SEqS(e_672, "goal")) {
Set(ball_93, "st", ((V)("net")));
bulge_69 = NewObj(4).Put("x", Get(ball_93, "x")).Put("y", Get(ball_93, "y")).Put("a", ((V)(1D))).Put("t", t_634).V;
Invoke(SFX_21, "swish");
Call(settle_130, V.Undef, (true ? V.True : V.False));
} else {
if ((SEqS(e_672, "post") || SEqS(e_672, "bar"))) {
Set(ball_93, "st", ((V)("out")));
Invoke(SFX_21, "clang");
Call(settle_130, V.Undef, (false ? V.True : V.False), ((V)((SEqS(e_672, "bar") ? "Off the bar!" : "Off the post!"))));
} else {
if ((SEqS(e_672, "wide") || SEqS(e_672, "over"))) {
Set(ball_93, "st", ((V)("out")));
Call(settle_130, V.Undef, (false ? V.True : V.False), ((V)((SEqS(e_672, "over") ? "Over the bar!" : "Wide!"))));
} else {
if ((SEqS(e_672, "bounce") && Gt(t_634, quietAt_100))) {
Invoke(SFX_21, "thud");
quietAt_100 = Add(t_634, ((V)(150D)));
}
}
}
}
}
} else {
if (Truthy(Get(ball_93, "live"))) {
double n_673 = 0;
n_673 = 3D;
{
double i_674 = 0;
i_674 = 0D;
while (true) {
if (!((i_674 < n_673))) break;
Call(stepB_113, V.Undef, ball_93, ((V)((ToNum(dt_633) / n_673))), ((V)(0D)), V.Null);
i_674++;
}
}
OpSet(ball_93, "spin", 0, ((V)((ToNum(dt_633) * 14D))));
}
}
Call(drawNet_70, V.Undef, t_634);
s_637 = Call(P_43, V.Undef, Get(ball_93, "x"), Get(ball_93, "y"), Get(ball_93, "z"));
r_638 = (BR_48 * ToNum(GetIdx(s_637, 2D)));
inG_639 = (GtN(Get(ball_93, "z"), (GZ_45 - 0.02)) ? V.True : V.False);
front_640 = (LtN(Get(ball_93, "z"), (KZ_50 - 0.02)) ? V.True : V.False);
if (Truthy(inG_639)) {
if (!SEq(Get(bG_81, "parentNode"), ballSlotBack_58)) {
Invoke(ballSlotBack_58, "appendChild", bG_81);
}
} else {
if (!SEq(Get(bG_81, "parentNode"), ballSlot_61)) {
Invoke(ballSlot_61, "appendChild", bG_81);
}
}
Set(Get(ballL_59, "style"), "zIndex", ((V)((Truthy(front_640) ? 2D : 0D))));
Invoke(bC_82, "setAttribute", ((V)("cx")), Call(r2_19, V.Undef, GetIdx(s_637, 0D)));
Invoke(bC_82, "setAttribute", ((V)("cy")), Call(r2_19, V.Undef, GetIdx(s_637, 1D)));
Invoke(bC_82, "setAttribute", ((V)("r")), Call(r2_19, V.Undef, ((V)(r_638))));
sp_641 = Get(ball_93, "spin");
pd_642 = new JsStrBuf("");
{
double i_676 = 0;
i_676 = 0D;
while (true) {
if (!((i_676 < 5D))) break;
V a_678 = default;
a_678 = Add(sp_641, ((V)((i_676 * 1.2566))));
pd_642.S((NumTruthy(i_676) ? "L" : "M")).V(Call(r2_19, V.Undef, Add(GetIdx(s_637, 0D), ((V)(((FdLibm.Cos(ToNum(a_678)) * r_638) * 0.42)))))).S(" ").V(Call(r2_19, V.Undef, Add(GetIdx(s_637, 1D), ((V)(((FdLibm.Sin(ToNum(a_678)) * r_638) * 0.42))))));
i_676++;
}
}
Invoke(bP_83, "setAttribute", ((V)("d")), ((V)(string.Concat(pd_642.Str, "Z"))));
g0_643 = Call(P_43, V.Undef, Get(ball_93, "x"), ((V)(0D)), Get(ball_93, "z"));
hk_644 = Call(cl_17, V.Undef, ((V)((1D - (ToNum(Get(ball_93, "y")) / 2.5)))), ((V)(0.3)), ((V)(1D)));
Invoke(bShadow_80, "setAttribute", ((V)("cx")), Call(r2_19, V.Undef, GetIdx(g0_643, 0D)));
Invoke(bShadow_80, "setAttribute", ((V)("cy")), Call(r2_19, V.Undef, GetIdx(g0_643, 1D)));
Invoke(bShadow_80, "setAttribute", ((V)("rx")), Call(r2_19, V.Undef, ((V)((((BR_48 * ToNum(GetIdx(g0_643, 2D))) * 1.2) * ToNum(hk_644))))));
Invoke(bShadow_80, "setAttribute", ((V)("ry")), Call(r2_19, V.Undef, ((V)((((BR_48 * ToNum(GetIdx(g0_643, 2D))) * 0.35) * ToNum(hk_644))))));
if (Truthy(((Get(ball_93, "S") is var _t679 && !Truthy(_t679) ? _t679 : (!(Truthy(inG_639)) ? V.True : V.False)) is var _t680 && !Truthy(_t680) ? _t680 : (((ToNum(t_634) - ToNum(Get(ball_93, "tl"))) < 1400D) ? V.True : V.False)))) {
Invoke(trail_101, "push", Arr(GetIdx(s_637, 0D), GetIdx(s_637, 1D), ((V)(r_638)), t_634));
}
trail_101 = Invoke(trail_101, "filter", Fn((V _self626, int _argc681, V q_687, V _a684, V _a685, V _a686, V[] _rest682) => {
return (((ToNum(t_634) - ToNum(GetIdx(q_687, 3D))) < 170D) ? V.True : V.False);
}, 1, "", true));
Set(trailG_60, "innerHTML", ((V)("")));
if (GtN(Get(trail_101, "length"), 1D)) {
JsStrBuf d_688 = null;
V rr_689 = default;
d_688 = new JsStrBuf("");
Invoke(trail_101, "forEach", Fn((V _self626, int _argc690, V q_696, V i_697, V _a694, V _a695, V[] _rest691) => {
d_688.S((Truthy(i_697) ? "L" : "M")).V(Call(r2_19, V.Undef, GetIdx(q_696, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(q_696, 1D)));
return default;
}, 2, "", true));
rr_689 = GetIdx(GetIdx(trail_101, (ToNum(Get(trail_101, "length")) - 1D)), 2D);
Call(S_16, V.Undef, ((V)("path")), NewObj(7).Put("d", ((V)(d_688.Str))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", Call(r2_19, V.Undef, ((V)((ToNum(rr_689) * 1.5))))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).Put("opacity", ((V)(0.35))).V, trailG_60);
Call(S_16, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(d_688.Str))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", Call(r2_19, V.Undef, ((V)((ToNum(rr_689) * 0.6))))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.6))).V, trailG_60);
}
if ((string.Equals(phase_90.Str, "after") && (ts_635 > 1900D))) {
shot_89++;
if ((shot_89 >= 5D)) {
V g_698 = default;
phase_90.Set("done");
g_698 = Get(Invoke(res_88, "filter", G("Boolean")), "length");
Invoke(ctx_37, "finish", NewObj(1).Put("sub", ((V)(JsStrBuf.Begin().V(g_698).S("/5 goals vs ").V(kpName_72).End()))).V);
} else {
Call(resetShot_112, V.Undef);
}
}
return default;
}, 2, "update", false)).V;
Call(resetShot_112, V.Undef);
Call(place_111, V.Undef);
Call(drawNet_70, V.Undef, ((V)(0D)));
return api_132;
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
