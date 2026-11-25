// yg-tramp.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_yg_tramp_js
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
if ((!(Truthy(YG_16)) || !(Truthy(Get(YG_16, "add"))))) {
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
ICON_22 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#cfeaff\"/><rect y=\"66\" width=\"120\" height=\"18\" fill=\"#9fdc6e\"/>", "<path d=\"M30 58L36 74M60 60V76M90 58L84 74\" stroke=\"#2c2f38\" stroke-width=\"3\" stroke-linecap=\"round\"/><ellipse cx=\"60\" cy=\"56\" rx=\"38\" ry=\"8\" fill=\"#9aa3b2\"/><ellipse cx=\"60\" cy=\"55\" rx=\"31\" ry=\"5.5\" fill=\"#2f3340\"/><path d=\"M29 55Q60 64 91 55\" fill=\"none\" stroke=\"#454a59\" stroke-width=\"2\"/>", "<path d=\"M55 12L57.4 18.6L64 21L57.4 23.4L55 30L52.6 23.4L46 21L52.6 18.6Z\" fill=\"#ffd84a\"/><path d=\"M76 26L77.4 29.6L81 31L77.4 32.4L76 36L74.6 32.4L71 31L74.6 29.6Z\" fill=\"#ff8fc8\"/><path d=\"M40 34Q60 26 60 44\" stroke=\"#fff\" stroke-width=\"2\" stroke-dasharray=\"2 4\" fill=\"none\"/></svg>")));
Invoke(YG_16, "add", NewObj(13).Put("id", ((V)("tramp"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Bounce Up"))).Put("item", ((V)("Trampolines"))).Put("color", ((V)("#7d8cff"))).Put("icon", ICON_22).Put("dur", ((V)(40D))).Put("stars", Arr(((V)(200D)), ((V)(450D)), ((V)(800D)))).Put("coinK", ((V)(0.08))).Put("hint", ((V)("Tap as you land = higher \u00b7 tap in the air = twirl"))).Put("how", Arr(((V)("Tap just as your creature lands on the mat to bounce higher.")), ((V)("No tap and the bounces get smaller.")), ((V)("Tap in the air to twirl for points; finish it before you land!")))).Put("options", Arr(NewObj(2).Put("id", ((V)("sport"))).Put("label", ((V)("Sport Trampoline"))).V, NewObj(2).Put("id", ((V)("old"))).Put("label", ((V)("Old Trampoline"))).V)).Put("make", Fn((V _self29, int _argc30, V ctx_36, V _a33, V _a34, V _a35, V[] _rest31) => {
V bg_37 = default;
V fg_38 = default;
V W_39 = default;
V H_40 = default;
double K_41 = 0;
double BASE_42 = 0;
double MY_43 = 0;
double G_44 = 0;
V PX_45 = default;
V sky_46 = default;
V skyG_47 = default;
V space_48 = default;
V world_49 = default;
V ground_50 = default;
V deco_51 = default;
V ruler_52 = default;
V starsG_53 = default;
V tramp_54 = default;
V clouds_55 = default;
V birds_56 = default;
V bal_57 = default;
V look_58 = default;
V matF_59 = default;
V matB_60 = default;
V pad_61 = default;
V legs_62 = default;
V drawTramp_63 = default;
V padF2_64 = default;
V padF_65 = default;
V stars_66 = default;
V seedStars_67 = default;
V best0_68 = default;
V recLine_69 = default;
V me_70 = default;
double cy_71 = 0;
double vy_72 = 0;
double cam_73 = 0;
V contact_74 = default;
double vin_75 = 0;
double sag_76 = 0;
V tapAt_77 = default;
V tw_78 = default;
double twirls_79 = 0;
double combo_80 = 0;
double maxH_81 = 0;
double lastMeter_82 = 0;
V tNow_83 = default;
double perfect_84 = 0;
double wob_85 = 0;
V started_86 = default;
double gotStars_87 = 0;
V lastJ_88 = default;
V tToMat_89 = default;
V tap_90 = default;
V api_91 = default;
if (_self29.IsNullish) _self29 = GlobalV;
drawTramp_63 = Fn((V _self92, int _argc93, V sag_99, V cam_100, V _a97, V _a98, V[] _rest94) => {
V L_101 = default;
double R_102 = 0;
V y0_103 = default;
double x0_104 = 0;
double rx_105 = 0;
double ry_106 = 0;
double sg_107 = 0;
if (_self92.IsNullish) _self92 = GlobalV;
L_101 = (SEqS(look_58, "sport") ? NewObj(4).Put("pad", ((V)("#c9ced6"))).Put("padD", ((V)("#9aa3b2"))).Put("mat", ((V)("#2f3340"))).Put("leg", ((V)("#2c2f38"))).V : NewObj(4).Put("pad", ((V)("#a7c79a"))).Put("padD", ((V)("#7c9a70"))).Put("mat", ((V)("#3a3a3a"))).Put("leg", ((V)("#7a6a58"))).V);
R_102 = 1.45;
y0_103 = GetIdx(Call(PX_45, V.Undef, ((V)(0D)), ((V)(MY_43)), cam_100), 1D);
x0_104 = (ToNum(W_39) / 2D);
rx_105 = (R_102 * K_41);
ry_106 = (0.17 * K_41);
Set(legs_62, "innerHTML", ((V)("")));
Set(pad_61, "innerHTML", ((V)("")));
Invoke(Arr(((V)((-1.25))), ((V)(0D)), ((V)(1.25))), "forEach", Fn((V _arrowThis115, int _argc108, V x_114, V _a111, V _a112, V _a113, V[] _rest109) => {
V a_116 = default;
V b_117 = default;
a_116 = Call(PX_45, V.Undef, ((V)((ToNum(x_114) * 0.95))), ((V)((MY_43 - 0.02))), cam_100);
b_117 = Call(PX_45, V.Undef, ((V)(((ToNum(x_114) * 1.05) + (Truthy(x_114) ? (Sign(ToNum(x_114)) * 0.12) : 0D)))), ((V)(0D)), cam_100);
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(a_116, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_116, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(b_117, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(b_117, 1D))).End()))).Put("stroke", Get(L_101, "leg")).Put("stroke-width", ((V)(5D))).Put("stroke-linecap", ((V)("round"))).V, legs_62);
return default;
}, 1, "", true));
{
V a_118 = default;
V b_119 = default;
a_118 = Call(PX_45, V.Undef, ((V)((-1.4))), ((V)(0.02)), cam_100);
b_119 = Call(PX_45, V.Undef, ((V)(1.4)), ((V)(0.02)), cam_100);
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(a_118, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_118, 1D))).S("Q").V(Call(r2_20, V.Undef, ((V)(x0_104)))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(a_118, 1D)) - 6D))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(b_119, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(b_119, 1D))).End()))).Put("stroke", Get(L_101, "leg")).Put("stroke-width", ((V)(4D))).Put("fill", ((V)("none"))).Put("opacity", ((V)(0.8))).V, legs_62);
Invoke(YG_16, "shadow", legs_62, ((V)(x0_104)), Add(GetIdx(a_118, 1D), ((V)(2D))), ((V)((rx_105 * 0.95))), ((V)(0.18)));
}
sg_107 = (ToNum(sag_99) * K_41);
Invoke(matB_60, "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((x0_104 - (rx_105 * 0.86)))))).S(" ").V(Call(r2_20, V.Undef, y0_103)).S("Q").V(Call(r2_20, V.Undef, ((V)(x0_104)))).S(" ").V(Call(r2_20, V.Undef, ((V)(((ToNum(y0_103) - (ry_106 * 1.5)) + (sg_107 * 0.6)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((x0_104 + (rx_105 * 0.86)))))).S(" ").V(Call(r2_20, V.Undef, y0_103)).End())));
Invoke(matB_60, "setAttribute", ((V)("fill")), Get(L_101, "mat"));
Invoke(matB_60, "setAttribute", ((V)("stroke")), ((V)("none")));
Invoke(matF_59, "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((x0_104 - (rx_105 * 0.86)))))).S(" ").V(Call(r2_20, V.Undef, y0_103)).S("Q").V(Call(r2_20, V.Undef, ((V)(x0_104)))).S(" ").V(Call(r2_20, V.Undef, Add(Add(y0_103, ((V)((ry_106 * 1.4)))), ((V)((sg_107 * 2D)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((x0_104 + (rx_105 * 0.86)))))).S(" ").V(Call(r2_20, V.Undef, y0_103)).S("Z").End())));
Invoke(matF_59, "setAttribute", ((V)("fill")), Get(L_101, "mat"));
{
double i_120 = 0;
i_120 = 0D;
while (true) {
if (!((i_120 <= 14D))) break;
double u_122 = 0;
double x_123 = 0;
V y_124 = default;
u_122 = (i_120 / 14D);
x_123 = ((x0_104 - (rx_105 * 0.92)) + ((u_122 * rx_105) * 1.84));
y_124 = Add(y0_103, ((V)(((FdLibm.Sin((u_122 * System.Math.PI)) * ry_106) * 0.85))));
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)(x_123)))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(y_124) - 3D))))).S("l2 1.5l-4 1.5l4 1.5l-2 1.5").End()))).Put("stroke", ((V)("#b8bcc6"))).Put("stroke-width", ((V)(1D))).Put("fill", ((V)("none"))).V, pad_61);
i_120++;
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((x0_104 - rx_105))))).S(" ").V(Call(r2_20, V.Undef, y0_103)).S("A").V(Call(r2_20, V.Undef, ((V)(rx_105)))).S(" ").V(Call(r2_20, V.Undef, ((V)(ry_106)))).S(" 0 0 1 ").V(Call(r2_20, V.Undef, ((V)((x0_104 + rx_105))))).S(" ").V(Call(r2_20, V.Undef, y0_103)).End()))).Put("stroke", Get(L_101, "padD")).Put("stroke-width", ((V)(9D))).Put("fill", ((V)("none"))).V, pad_61);
Invoke(padF_65, "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((x0_104 - rx_105))))).S(" ").V(Call(r2_20, V.Undef, y0_103)).S("A").V(Call(r2_20, V.Undef, ((V)(rx_105)))).S(" ").V(Call(r2_20, V.Undef, ((V)(ry_106)))).S(" 0 0 0 ").V(Call(r2_20, V.Undef, ((V)((x0_104 + rx_105))))).S(" ").V(Call(r2_20, V.Undef, y0_103)).End())));
Invoke(padF_65, "setAttribute", ((V)("stroke")), Get(L_101, "pad"));
Invoke(padF2_64, "setAttribute", ((V)("d")), Invoke(padF_65, "getAttribute", ((V)("d"))));
Invoke(padF2_64, "setAttribute", ((V)("stroke")), Get(L_101, "padD"));
return default;
}, 2, "drawTramp", false);
seedStars_67 = Fn((V _self125, int _argc126, V _a128, V _a129, V _a130, V _a131, V[] _rest127) => {
if (_self125.IsNullish) _self125 = GlobalV;
Set(starsG_53, "innerHTML", ((V)("")));
stars_66 = Arr();
{
double y_132 = 0;
y_132 = 3.2;
while (true) {
if (!((y_132 < 60D))) break;
V gold_134 = default;
V g_135 = default;
gold_134 = (LtN(Invoke(G("Math"), "random"), 0.18) ? V.True : V.False);
g_135 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, starsG_53);
Call(S_17, V.Undef, ((V)("circle")), NewObj(3).Put("r", ((V)(14D))).Put("fill", ((V)("url(#ygGlow)"))).Put("opacity", ((V)(0.8))).V, g_135);
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)("M0-11L3.2-3.4L11-2.4L5 3L6.8 11L0 6.8L-6.8 11L-5 3L-11-2.4L-3.2-3.4Z"))).Put("fill", ((V)((Truthy(gold_134) ? "#ffcf3a" : "#ffffff")))).Put("stroke", ((V)((Truthy(gold_134) ? "#e09a14" : "#ffd84a")))).Put("stroke-width", ((V)(1.5))).Put("stroke-linejoin", ((V)("round"))).V, g_135);
Invoke(stars_66, "push", NewObj(5).Put("g", g_135).Put("x", ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.5)))).Put("y", ((V)(y_132))).Put("gold", gold_134).Put("taken", ((V)(0D))).V);
y_132 = (y_132 + (1.6 + (ToNum(Invoke(G("Math"), "random")) * 1.4)));
}
}
return default;
}, 0, "seedStars", false);
tap_90 = Fn((V _self136, int _argc137, V _a139, V _a140, V _a141, V _a142, V[] _rest138) => {
V ttm_143 = default;
if (_self136.IsNullish) _self136 = GlobalV;
if (!(Truthy(Get(ctx_36, "playing")))) {
return default;
}
ttm_143 = (LtN(contact_74, 0D) ? Call(tToMat_89, V.Undef) : ((V)(0D)));
if ((GeN(contact_74, 0D) || LtN(ttm_143, 0.22))) {
tapAt_77 = tNow_83;
return default;
}
if (!(Truthy(tw_78))) {
tw_78 = NewObj(2).Put("t0", tNow_83).Put("d", ((V)(520D))).V;
Invoke(SFX_21, "whoosh");
} else {
if (!(Truthy(Get(tw_78, "q")))) {
Set(tw_78, "q", ((V)(1D)));
}
}
return default;
}, 0, "tap", false);
{ V _t144 = ctx_36;
if (_t144.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t144));
{ V _t145 = Get(_t144, "bg");
bg_37 = _t145; }
{ V _t146 = Get(_t144, "fg");
fg_38 = _t146; }
{ V _t147 = Get(_t144, "W");
W_39 = _t147; }
{ V _t148 = Get(_t144, "H");
H_40 = _t148; } }
K_41 = 80D;
BASE_42 = (ToNum(H_40) - 20D);
MY_43 = 0.78;
G_44 = (9.8 * 0.72);
PX_45 = Fn((V _arrowThis158, int _argc149, V x_155, V y_156, V cam_157, V _a154, V[] _rest150) => {
return Arr(((V)(((ToNum(W_39) / 2D) + (ToNum(x_155) * K_41)))), ((V)((BASE_42 - ((ToNum(y_156) - ToNum(cam_157)) * K_41)))));
}, 3, "", true);
sky_46 = Call(S_17, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_39, ((V)(40D)))).Put("height", Add(H_40, ((V)(40D)))).Put("fill", ((V)("#9fd6ff"))).V, bg_37);
skyG_47 = Call(S_17, V.Undef, ((V)("rect")), NewObj(6).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_39, ((V)(40D)))).Put("height", Add(H_40, ((V)(40D)))).Put("fill", ((V)("url(#ygSky)"))).Put("opacity", ((V)(1D))).V, bg_37);
space_48 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("opacity", ((V)(0D))).V, bg_37);
{
double i_159 = 0;
i_159 = 0D;
while (true) {
if (!((i_159 < 40D))) break;
Call(S_17, V.Undef, ((V)("circle")), NewObj(5).Put("cx", Call(r2_20, V.Undef, ((V)((ToNum(Invoke(G("Math"), "random")) * ToNum(W_39)))))).Put("cy", Call(r2_20, V.Undef, ((V)((ToNum(Invoke(G("Math"), "random")) * ToNum(H_40)))))).Put("r", Call(r2_20, V.Undef, ((V)((0.6 + (ToNum(Invoke(G("Math"), "random")) * 1.3)))))).Put("fill", ((V)("#ffffff"))).Put("opacity", Call(r2_20, V.Undef, ((V)((0.4 + (ToNum(Invoke(G("Math"), "random")) * 0.6)))))).V, space_48);
i_159++;
}
}
world_49 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_37);
ground_50 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, world_49);
deco_51 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, world_49);
ruler_52 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, world_49);
starsG_53 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, world_49);
tramp_54 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, world_49);
{
V g_161 = default;
g_161 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(0 ").N((BASE_42 - 250D)).S(")").End()))).V, ground_50);
Invoke(YG_16, "yard", g_161, NewObj(3).Put("hz", ((V)(196D))).Put("flowers", (false ? V.True : V.False)).Put("sky", (false ? V.True : V.False)).V);
}
clouds_55 = Arr();
{
double i_162 = 0;
i_162 = 0D;
while (true) {
if (!((i_162 < 22D))) break;
double y_164 = 0;
double x_165 = 0;
double k_166 = 0;
V g_167 = default;
y_164 = ((4D + (i_162 * 2.2)) + (ToNum(Invoke(G("Math"), "random")) * 1.2));
x_165 = ((((ToNum(Invoke(G("Math"), "random")) - 0.5) * ToNum(W_39)) / K_41) * 0.92);
k_166 = (0.5 + (ToNum(Invoke(G("Math"), "random")) * 0.7));
g_167 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("opacity", ((V)(0.85))).V, deco_51);
Invoke(Arr(Arr(((V)((-22D))), ((V)(4D)), ((V)(15D))), Arr(((V)(0D)), ((V)((-5D))), ((V)(20D))), Arr(((V)(22D)), ((V)(4D)), ((V)(15D))), Arr(((V)(8D)), ((V)(7D)), ((V)(14D)))), "forEach", Fn((V _arrowThis181, int _argc168, V _a170, V _a171, V _a172, V _a173, V[] _rest169) => {
V a_176 = default;
V b_178 = default;
V r_180 = default;
{ V _t174 = ListOf(_a170);
{ V _t175 = GetIdx(_t174, 0D);
a_176 = _t175; }
{ V _t177 = GetIdx(_t174, 1D);
b_178 = _t177; }
{ V _t179 = GetIdx(_t174, 2D);
r_180 = _t179; }
}
return Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("cx", a_176).Put("cy", b_178).Put("r", r_180).Put("fill", ((V)("#ffffff"))).V, g_167);
}, 1, "", true));
Invoke(clouds_55, "push", NewObj(5).Put("g", g_167).Put("x", ((V)(x_165))).Put("y", ((V)(y_164))).Put("k", ((V)(k_166))).Put("v", ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.25)))).V);
i_162++;
}
}
birds_56 = Invoke(Arr(((V)(7D)), ((V)(12D)), ((V)(18D))), "map", Fn((V _arrowThis190, int _argc182, V y_188, V i_189, V _a186, V _a187, V[] _rest183) => {
V g_191 = default;
g_191 = Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)("M-7 0Q-3.5 -5 0 0Q3.5 -5 7 0"))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#3a2a55"))).Put("stroke-width", ((V)(2D))).Put("stroke-linecap", ((V)("round"))).V, deco_51);
return NewObj(4).Put("g", g_191).Put("y", y_188).Put("x", Add(((V)((-2D))), i_189)).Put("v", ((V)((0.6 + (ToNum(i_189) * 0.2))))).V;
return default;
}, 2, "", true));
bal_57 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, deco_51);
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)("M0 14Q3 26 -2 40"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.2))).Put("fill", ((V)("none"))).V, bal_57);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(5).Put("cx", ((V)(0D))).Put("cy", ((V)(0D))).Put("rx", ((V)(11D))).Put("ry", ((V)(14D))).Put("fill", ((V)("#ff7fbf"))).V, bal_57);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", ((V)((-4D)))).Put("cy", ((V)((-5D)))).Put("rx", ((V)(3D))).Put("ry", ((V)(4.5))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.5))).V, bal_57);
look_58 = ((V)("sport"));
matF_59 = Call(S_17, V.Undef, ((V)("path")), NewObj(0).V, tramp_54);
matB_60 = Call(S_17, V.Undef, ((V)("path")), NewObj(0).V, tramp_54);
pad_61 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, tramp_54);
legs_62 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, tramp_54);
padF2_64 = Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke-width", ((V)(13D))).Put("stroke-linecap", ((V)("round"))).V, fg_38);
padF_65 = Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke-width", ((V)(9D))).Put("stroke-linecap", ((V)("round"))).V, fg_38);
stars_66 = Arr();
best0_68 = (Get(YG_16, "_trampBest") is var _t192 && Truthy(_t192) ? _t192 : ((V)(0D)));
recLine_69 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, world_49);
me_70 = Invoke(ctx_36, "creature", Get(ctx_36, "playerKey"), NewObj(1).Put("yaw", ((V)(0D))).V);
Invoke(me_70, "depth", ((V)(2D)));
cy_71 = MY_43;
vy_72 = 0D;
cam_73 = 0D;
contact_74 = ((V)((-1D)));
vin_75 = 0D;
sag_76 = 0D;
tapAt_77 = ((V)((-9D)));
tw_78 = V.Null;
twirls_79 = 0D;
combo_80 = 0D;
maxH_81 = 0D;
lastMeter_82 = 0D;
tNow_83 = ((V)(0D));
perfect_84 = 0D;
wob_85 = 0D;
started_86 = (false ? V.True : V.False);
gotStars_87 = 0D;
lastJ_88 = ((V)(""));
tToMat_89 = Fn((V _arrowThis199, int _argc193, V _a195, V _a196, V _a197, V _a198, V[] _rest194) => {
double a_200 = 0;
double b_201 = 0;
double c_202 = 0;
double disc_203 = 0;
double t1_204 = 0;
a_200 = ((-G_44) / 2D);
b_201 = vy_72;
c_202 = (cy_71 - MY_43);
disc_203 = ((b_201 * b_201) - ((4D * a_200) * c_202));
if ((disc_203 < 0D)) {
return ((V)(9D));
}
t1_204 = (((-b_201) - System.Math.Sqrt(disc_203)) / (2D * a_200));
return ((V)(((t1_204 > 0D) ? t1_204 : 9D)));
return default;
}, 0, "", true);
api_91 = NewObj(9).Put("option", Fn((V _self205, int _argc206, V id_212, V _a209, V _a210, V _a211, V[] _rest207) => {
if (_self205.IsNullish) _self205 = GlobalV;
look_58 = id_212;
Call(drawTramp_63, V.Undef, ((V)(0D)), ((V)(cam_73)));
return default;
}, 1, "option", false)).Put("start", Fn((V _self213, int _argc214, V _a216, V _a217, V _a218, V _a219, V[] _rest215) => {
if (_self213.IsNullish) _self213 = GlobalV;
cy_71 = 2D;
vy_72 = 0D;
cam_73 = 0D;
contact_74 = ((V)((-1D)));
twirls_79 = 0D;
combo_80 = 0D;
maxH_81 = 0D;
lastMeter_82 = 0D;
perfect_84 = 0D;
tw_78 = V.Null;
gotStars_87 = 0D;
Call(seedStars_67, V.Undef);
started_86 = (true ? V.True : V.False);
look_58 = (Get(Get(ctx_36, "G"), "_opt") is var _t220 && Truthy(_t220) ? _t220 : ((V)("sport")));
Invoke(me_70, "play", ((V)("idle")));
return default;
}, 0, "start", false)).Put("down", Fn((V _self221, int _argc222, V p_228, V _a225, V _a226, V _a227, V[] _rest223) => {
if (_self221.IsNullish) _self221 = GlobalV;
Call(tap_90, V.Undef);
return default;
}, 1, "down", false)).Put("key", Fn((V _self229, int _argc230, V k_236, V dn_237, V _a234, V _a235, V[] _rest231) => {
if (_self229.IsNullish) _self229 = GlobalV;
if (Truthy((dn_237 is var _t238 && !Truthy(_t238) ? _t238 : (((SEqS(k_236, " ") || SEqS(k_236, "ArrowUp")) || SEqS(k_236, "Enter")) ? V.True : V.False)))) {
Call(tap_90, V.Undef);
return (true ? V.True : V.False);
}
return default;
}, 2, "key", false)).Put("_tap", tap_90).Put("_state", Fn((V _arrowThis245, int _argc239, V _a241, V _a242, V _a243, V _a244, V[] _rest240) => {
return NewObj(7).Put("cy", ((V)(ToNum(Invoke(((V)(cy_71)), "toFixed", ((V)(2D))))))).Put("vy", ((V)(ToNum(Invoke(((V)(vy_72)), "toFixed", ((V)(2D))))))).Put("contact", contact_74).Put("ttm", ((V)(ToNum(Invoke(Call(tToMat_89, V.Undef), "toFixed", ((V)(2D))))))).Put("maxH", ((V)(ToNum(Invoke(((V)(maxH_81)), "toFixed", ((V)(1D))))))).Put("twirls", ((V)(twirls_79))).Put("lastJ", lastJ_88).V;
}, 0, "_state", true)).Put("timeUp", Fn((V _self246, int _argc247, V _a249, V _a250, V _a251, V _a252, V[] _rest248) => {
if (_self246.IsNullish) _self246 = GlobalV;
Invoke(ctx_36, "finish", NewObj(1).Put("sub", ((V)(JsStrBuf.Begin().S("Highest ").V(Invoke(((V)(maxH_81)), "toFixed", ((V)(1D)))).S(" m \u00b7 ").N(gotStars_87).S(" stars \u00b7 ").N(twirls_79).S(" twirls").End()))).V);
return default;
}, 0, "timeUp", false)).Put("celebrate", Fn((V _self253, int _argc254, V st_260, V _a257, V _a258, V _a259, V[] _rest255) => {
if (_self253.IsNullish) _self253 = GlobalV;
Invoke(me_70, "play", ((V)((GeN(st_260, 2D) ? "happy" : "idle"))));
return default;
}, 1, "celebrate", false)).Put("update", Fn((V _self261, int _argc262, V dt_268, V t_269, V _a266, V _a267, V[] _rest263) => {
V E_270 = default;
V up_271 = default;
double tc_272 = 0;
V p_273 = default;
V hk_274 = default;
if (_self261.IsNullish) _self261 = GlobalV;
tNow_83 = t_269;
E_270 = NewObj(0).V;
if (Truthy(started_86)) {
double hgt_275 = 0;
if (LtN(contact_74, 0D)) {
vy_72 = (vy_72 - (G_44 * ToNum(dt_268)));
cy_71 = (cy_71 + (vy_72 * ToNum(dt_268)));
if (((cy_71 <= MY_43) && (vy_72 < 0D))) {
contact_74 = ((V)(0D));
vin_75 = (-vy_72);
cy_71 = MY_43;
Invoke(SFX_21, "boing");
if (Truthy(tw_78)) {
tw_78 = V.Null;
wob_85 = 1D;
combo_80 = 0D;
Invoke(ctx_36, "toast", ((V)("Wobble!")), ((V)((ToNum(W_39) / 2D))), ((V)((ToNum(H_40) * 0.6))), ((V)("#ff7a8a")));
Set(E_270, "spin", ((V)(0D)));
}
}
}
if (GeN(contact_74, 0D)) {
double CT_276 = 0;
double u_277 = 0;
contact_74 = Add(contact_74, dt_268);
CT_276 = 0.22;
u_277 = (ToNum(contact_74) / CT_276);
sag_76 = (FdLibm.Sin((Min(1D, u_277) * System.Math.PI)) * Min(0.42, (0.08 + (vin_75 * 0.035))));
cy_71 = (MY_43 - sag_76);
if ((u_277 >= 1D)) {
double mid_278 = 0;
double d_279 = 0;
double e_280 = 0;
double boost_281 = 0;
JsStrBuf j_282 = null;
mid_278 = (ToNum(t_269) - (CT_276 * 500D));
d_279 = System.Math.Abs((ToNum(tapAt_77) - mid_278));
e_280 = 0.84;
boost_281 = 0D;
j_282 = new JsStrBuf("");
if (NumTruthy(wob_85)) {
e_280 = 0.62;
wob_85 = 0D;
j_282.Set("wobble");
} else {
if ((d_279 < 110D)) {
e_280 = 1D;
boost_281 = 1.55;
j_282.Set("Perfect!");
perfect_84++;
combo_80++;
} else {
if ((d_279 < 210D)) {
e_280 = 1D;
boost_281 = 0.6;
j_282.Set("Good");
combo_80++;
} else {
combo_80 = 0D;
}
}
}
if (Truthy((((V)(j_282.Str)) is var _t283 && !Truthy(_t283) ? _t283 : (!string.Equals(j_282.Str, "wobble") ? V.True : V.False)))) {
V p_284 = default;
p_284 = Call(PX_45, V.Undef, ((V)(0D)), ((V)(MY_43)), ((V)(cam_73)));
Invoke(ctx_36, "toast", ((V)(string.Concat(j_282.Str, ((combo_80 >= 3D) ? JsStrBuf.Begin().S(" x").N(combo_80).End() : "")))), Add(GetIdx(p_284, 0D), ((V)(70D))), ((V)((ToNum(GetIdx(p_284, 1D)) - 30D))), ((V)((string.Equals(j_282.Str, "Perfect!") ? "#ffe36e" : "#8fe0ff"))));
Invoke(SFX_21, "pop");
}
lastJ_88 = (((V)(j_282.Str)) is var _t285 && Truthy(_t285) ? _t285 : ((V)("none")));
vy_72 = Min(24D, Max(4.3, ((vin_75 * e_280) + boost_281)));
contact_74 = ((V)((-1D)));
sag_76 = 0D;
tapAt_77 = ((V)((-9D)));
}
}
hgt_275 = (cy_71 - MY_43);
if ((hgt_275 > maxH_81)) {
double m_286 = 0;
maxH_81 = hgt_275;
m_286 = System.Math.Floor(maxH_81);
if ((m_286 > lastMeter_82)) {
Invoke(ctx_36, "add", ((V)((5D * (m_286 - lastMeter_82)))));
lastMeter_82 = m_286;
if (((m_286 % 5D) == 0D)) {
Invoke(ctx_36, "toast", ((V)(JsStrBuf.Begin().N(m_286).S(" m!").End())), ((V)(((ToNum(W_39) / 2D) + 120D))), ((V)((ToNum(H_40) * 0.36))), ((V)("#ffffff")));
Invoke(SFX_21, "score");
}
}
}
{
foreach (V _k287 in new JsIter(stars_66)) {
V s_288 = default;
s_288 = _k287;
if ((!(Truthy(Get(s_288, "taken"))) && (System.Math.Abs((ToNum(Get(s_288, "y")) - (cy_71 + 0.45))) < 0.45))) {
V p_289 = default;
Set(s_288, "taken", ((V)(1D)));
gotStars_87++;
p_289 = Call(PX_45, V.Undef, Get(s_288, "x"), Get(s_288, "y"), ((V)(cam_73)));
Invoke(ctx_36, "add", ((V)((Truthy(Get(s_288, "gold")) ? 30D : 10D))), Add(GetIdx(p_289, 0D), ((V)(40D))), GetIdx(p_289, 1D), ((V)((Truthy(Get(s_288, "gold")) ? "+30" : "+10"))), ((V)((Truthy(Get(s_288, "gold")) ? "#ffcf3a" : "#ffffff"))));
Invoke(ctx_36, "burst", GetIdx(p_289, 0D), GetIdx(p_289, 1D), ((V)("star")), ((V)(8D)), NewObj(3).Put("v", ((V)(110D))).Put("life", ((V)(0.6))).Put("g", ((V)(0D))).V);
Invoke(SFX_21, "pop");
Invoke(Get(s_288, "g"), "setAttribute", ((V)("opacity")), ((V)(0D)));
}
}
}
if (Truthy(tw_78)) {
double u_290 = 0;
u_290 = ((ToNum(t_269) - ToNum(Get(tw_78, "t0"))) / ToNum(Get(tw_78, "d")));
Set(E_270, "spin", ((V)((360D * ToNum(Invoke(YG_16, "SM", ((V)(Min(1D, u_290)))))))));
if ((u_290 >= 1D)) {
double pts_291 = 0;
V p_292 = default;
twirls_79++;
pts_291 = (15D + Min(30D, (combo_80 * 3D)));
p_292 = Call(PX_45, V.Undef, ((V)(0D)), ((V)((cy_71 + 0.6))), ((V)(cam_73)));
Invoke(ctx_36, "add", ((V)(pts_291)), ((V)((ToNum(GetIdx(p_292, 0D)) - 80D))), GetIdx(p_292, 1D), ((V)(JsStrBuf.Begin().S("Twirl! +").N(pts_291).End())), ((V)("#ff8fc8")));
if (Truthy(Get(tw_78, "q"))) {
tw_78 = NewObj(2).Put("t0", t_269).Put("d", ((V)(520D))).V;
} else {
tw_78 = V.Null;
}
}
}
}
up_271 = Call(cl_18, V.Undef, ((V)((vy_72 / 10D))), ((V)((-1D))), ((V)(1D)));
if (GeN(contact_74, 0D)) {
Object_assign(E_270, NewObj(4).Put("sq", ((V)((sag_76 * 0.9)))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("close", ((V)(0.3))).V);
} else {
Object_assign(E_270, NewObj(8).Put("armL", Add(Call(lerp_19, V.Undef, ((V)(50D)), ((V)(150D)), Call(cl_18, V.Undef, up_271, ((V)(0D)), ((V)(1D)))), ((V)((LtN(up_271, 0D) ? (40D * (-ToNum(up_271))) : 0D))))).Put("armR", Add(Call(lerp_19, V.Undef, ((V)(50D)), ((V)(150D)), Call(cl_18, V.Undef, up_271, ((V)(0D)), ((V)(1D)))), ((V)((LtN(up_271, 0D) ? (40D * (-ToNum(up_271))) : 0D))))).Put("sq", ((V)(((-0.05) * System.Math.Abs(ToNum(up_271)))))).Put("smile", ((V)(0.6))).Put("hap", ((V)(((System.Math.Abs(ToNum(up_271)) < 0.3) ? 0.8 : 0.3)))).Put("open", ((V)((ToNum(Call(cl_18, V.Undef, up_271, ((V)(0D)), ((V)(1D)))) * 0.4)))).Put("footL", ((V)((2D * ToNum(Call(cl_18, V.Undef, ((V)((-ToNum(up_271)))), ((V)(0D)), ((V)(1D)))))))).Put("footR", ((V)((2D * ToNum(Call(cl_18, V.Undef, ((V)((-ToNum(up_271)))), ((V)(0D)), ((V)(1D)))))))).V);
}
Invoke(me_70, "pose", E_270);
tc_272 = Max(0D, (cy_71 - 2.6));
cam_73 = (cam_73 + ((tc_272 - cam_73) * (1D - FdLibm.Exp(((-ToNum(dt_268)) * 7D)))));
Invoke(world_49, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(0 ").V(Call(r2_20, V.Undef, ((V)((cam_73 * K_41))))).S(")").End())));
p_273 = Call(PX_45, V.Undef, ((V)(0D)), ((V)(cy_71)), ((V)(cam_73)));
Invoke(me_70, "set", GetIdx(p_273, 0D), Add(GetIdx(p_273, 1D), ((V)((K_41 * 0.02)))), ((V)((1.02 * K_41))));
Call(drawTramp_63, V.Undef, ((V)(sag_76)), ((V)(0D)));
Invoke(padF_65, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(0 ").V(Call(r2_20, V.Undef, ((V)((cam_73 * K_41))))).S(")").End())));
Invoke(padF2_64, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(0 ").V(Call(r2_20, V.Undef, ((V)((cam_73 * K_41))))).S(")").End())));
hk_274 = Call(cl_18, V.Undef, ((V)((cam_73 / 35D))), ((V)(0D)), ((V)(1D)));
Invoke(skyG_47, "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)((1D - ToNum(hk_274))))));
Invoke(sky_46, "setAttribute", ((V)("fill")), ((V)((LtN(hk_274, 0.5) ? "#8fb4ff" : "#4a3a9a"))));
Invoke(space_48, "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, Call(cl_18, V.Undef, ((V)(((cam_73 - 18D) / 15D))), ((V)(0D)), ((V)(1D)))));
Invoke(clouds_55, "forEach", Fn((V _arrowThis300, int _argc293, V c_299, V _a296, V _a297, V _a298, V[] _rest294) => {
V q_301 = default;
OpSet(c_299, "x", 0, ((V)((ToNum(Get(c_299, "v")) * ToNum(dt_268)))));
if (GtN(Get(c_299, "x"), 2.4)) {
Set(c_299, "x", ((V)((-2.4))));
}
if (LtN(Get(c_299, "x"), (-2.4))) {
Set(c_299, "x", ((V)(2.4)));
}
q_301 = Call(PX_45, V.Undef, Get(c_299, "x"), Get(c_299, "y"), ((V)(0D)));
Invoke(Get(c_299, "g"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, GetIdx(q_301, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(q_301, 1D))).S(") scale(").V(Get(c_299, "k")).S(")").End())));
return default;
}, 1, "", true));
Invoke(birds_56, "forEach", Fn((V _arrowThis309, int _argc302, V b_308, V _a305, V _a306, V _a307, V[] _rest303) => {
V q_310 = default;
OpSet(b_308, "x", 0, ((V)((ToNum(Get(b_308, "v")) * ToNum(dt_268)))));
if (GtN(Get(b_308, "x"), 2.2)) {
Set(b_308, "x", ((V)((-2.2))));
}
q_310 = Call(PX_45, V.Undef, Get(b_308, "x"), Get(b_308, "y"), ((V)(0D)));
Invoke(Get(b_308, "g"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, GetIdx(q_310, 0D))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(q_310, 1D), ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_269) / 200D))), Get(b_308, "y")))) * 3D)))))).S(") scale(1 ").V(Call(r2_20, V.Undef, ((V)((0.6 + (0.4 * System.Math.Abs(FdLibm.Sin(ToNum(Add(((V)((ToNum(t_269) / 120D))), Get(b_308, "y"))))))))))).S(")").End())));
return default;
}, 1, "", true));
{
V q_311 = default;
q_311 = Call(PX_45, V.Undef, ((V)(((-1.2) + (FdLibm.Sin((ToNum(t_269) / 3000D)) * 0.3)))), ((V)((24D + (FdLibm.Sin((ToNum(t_269) / 1700D)) * 0.4)))), ((V)(0D)));
Invoke(bal_57, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, GetIdx(q_311, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(q_311, 1D))).S(")").End())));
}
Invoke(stars_66, "forEach", Fn((V _arrowThis319, int _argc312, V s_318, V _a315, V _a316, V _a317, V[] _rest313) => {
if (!(Truthy(Get(s_318, "taken")))) {
V q_320 = default;
q_320 = Call(PX_45, V.Undef, Get(s_318, "x"), Get(s_318, "y"), ((V)(0D)));
Invoke(Get(s_318, "g"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, GetIdx(q_320, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(q_320, 1D))).S(") rotate(").V(Call(r2_20, V.Undef, ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_269) / 400D))), Get(s_318, "y")))) * 12D))))).S(") scale(").V(Call(r2_20, V.Undef, ((V)((1D + (0.08 * FdLibm.Sin(ToNum(Add(((V)((ToNum(t_269) / 250D))), Get(s_318, "y")))))))))).S(")").End())));
}
return default;
}, 1, "", true));
if (!(Truthy(Get(api_91, "_ru")))) {
Set(api_91, "_ru", ((V)(1D)));
{
double m_321 = 0;
m_321 = 1D;
while (true) {
if (!((m_321 <= 60D))) break;
V q_323 = default;
q_323 = Call(PX_45, V.Undef, ((V)(1.5)), ((V)((MY_43 + m_321))), ((V)(0D)));
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((ToNum(W_39) - (NumTruthy((m_321 % 5D)) ? 10D : 18D)))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(q_323, 1D))).S("H").V(W_39).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)((NumTruthy((m_321 % 5D)) ? 1.5 : 2.5)))).Put("opacity", ((V)(0.8))).V, ruler_52);
if (((m_321 % 5D) == 0D)) {
Set(Call(S_17, V.Undef, ((V)("text")), NewObj(7).Put("x", ((V)((ToNum(W_39) - 22D)))).Put("y", Call(r2_20, V.Undef, Add(GetIdx(q_323, 1D), ((V)(4D))))).Put("text-anchor", ((V)("end"))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)(12D))).Put("fill", ((V)("#ffffff"))).V, ruler_52), "textContent", ((V)(JsStrBuf.Begin().N(m_321).S(" m").End())));
}
m_321++;
}
}
}
Set(recLine_69, "innerHTML", ((V)("")));
if ((maxH_81 > 1D)) {
V q_324 = default;
q_324 = Call(PX_45, V.Undef, ((V)(0D)), ((V)((MY_43 + maxH_81))), ((V)(0D)));
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(JsStrBuf.Begin().S("M0 ").V(Call(r2_20, V.Undef, GetIdx(q_324, 1D))).S("H").V(W_39).End()))).Put("stroke", ((V)("#ffcf3a"))).Put("stroke-width", ((V)(2D))).Put("stroke-dasharray", ((V)("6 6"))).Put("opacity", ((V)(0.8))).V, recLine_69);
Set(Call(S_17, V.Undef, ((V)("text")), NewObj(6).Put("x", ((V)(8D))).Put("y", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(q_324, 1D)) - 5D))))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)(12D))).Put("fill", ((V)("#ffcf3a"))).V, recLine_69), "textContent", ((V)(JsStrBuf.Begin().V(Invoke(((V)(maxH_81)), "toFixed", ((V)(1D)))).S(" m").End())));
}
return default;
}, 2, "update", false)).V;
Call(drawTramp_63, V.Undef, ((V)(0D)), ((V)(0D)));
Invoke(me_70, "set", ((V)((ToNum(W_39) / 2D))), GetIdx(Call(PX_45, V.Undef, ((V)(0D)), ((V)(MY_43)), ((V)(0D))), 1D), ((V)((1.02 * K_41))));
Call(seedStars_67, V.Undef);
return api_91;
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
