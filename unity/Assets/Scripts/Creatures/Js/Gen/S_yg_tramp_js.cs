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
go_8 = Fn((V _self1, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_15 = default;
V S_16 = default;
V cl_17 = default;
V lerp_18 = default;
V r2_19 = default;
V SFX_20 = default;
V ICON_21 = default;
YG_15 = Get(G("window"), "YardGames");
if ((!(Truthy(YG_15)) || !(Truthy(Get(YG_15, "add"))))) {
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
ICON_21 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#cfeaff\"/><rect y=\"66\" width=\"120\" height=\"18\" fill=\"#9fdc6e\"/>", "<path d=\"M30 58L36 74M60 60V76M90 58L84 74\" stroke=\"#2c2f38\" stroke-width=\"3\" stroke-linecap=\"round\"/><ellipse cx=\"60\" cy=\"56\" rx=\"38\" ry=\"8\" fill=\"#9aa3b2\"/><ellipse cx=\"60\" cy=\"55\" rx=\"31\" ry=\"5.5\" fill=\"#2f3340\"/><path d=\"M29 55Q60 64 91 55\" fill=\"none\" stroke=\"#454a59\" stroke-width=\"2\"/>", "<path d=\"M55 12L57.4 18.6L64 21L57.4 23.4L55 30L52.6 23.4L46 21L52.6 18.6Z\" fill=\"#ffd84a\"/><path d=\"M76 26L77.4 29.6L81 31L77.4 32.4L76 36L74.6 32.4L71 31L74.6 29.6Z\" fill=\"#ff8fc8\"/><path d=\"M40 34Q60 26 60 44\" stroke=\"#fff\" stroke-width=\"2\" stroke-dasharray=\"2 4\" fill=\"none\"/></svg>")));
Invoke(YG_15, "add", NewObj(13).Put("id", ((V)("tramp"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Bounce Up"))).Put("item", ((V)("Trampolines"))).Put("color", ((V)("#7d8cff"))).Put("icon", ICON_21).Put("dur", ((V)(40D))).Put("stars", Arr(((V)(200D)), ((V)(450D)), ((V)(800D)))).Put("coinK", ((V)(0.08))).Put("hint", ((V)("Tap as you land = higher \u00b7 tap in the air = twirl"))).Put("how", Arr(((V)("Tap just as your creature lands on the mat to bounce higher.")), ((V)("No tap and the bounces get smaller.")), ((V)("Tap in the air to twirl for points; finish it before you land!")))).Put("options", Arr(NewObj(2).Put("id", ((V)("sport"))).Put("label", ((V)("Sport Trampoline"))).V, NewObj(2).Put("id", ((V)("old"))).Put("label", ((V)("Old Trampoline"))).V)).Put("make", Fn((V _self28, int _argc29, V ctx_35, V _a32, V _a33, V _a34, V[] _rest30) => {
V bg_36 = default;
V fg_37 = default;
V W_38 = default;
V H_39 = default;
double K_40 = 0;
double BASE_41 = 0;
double MY_42 = 0;
double G_43 = 0;
V PX_44 = default;
V sky_45 = default;
V skyG_46 = default;
V space_47 = default;
V world_48 = default;
V ground_49 = default;
V deco_50 = default;
V ruler_51 = default;
V starsG_52 = default;
V tramp_53 = default;
V clouds_54 = default;
V birds_55 = default;
V bal_56 = default;
V look_57 = default;
V matF_58 = default;
V matB_59 = default;
V pad_60 = default;
V legs_61 = default;
V drawTramp_62 = default;
V padF2_63 = default;
V padF_64 = default;
V stars_65 = default;
V seedStars_66 = default;
V best0_67 = default;
V recLine_68 = default;
V me_69 = default;
double cy_70 = 0;
double vy_71 = 0;
double cam_72 = 0;
V contact_73 = default;
double vin_74 = 0;
double sag_75 = 0;
V tapAt_76 = default;
V tw_77 = default;
double twirls_78 = 0;
double combo_79 = 0;
double maxH_80 = 0;
double lastMeter_81 = 0;
V tNow_82 = default;
double perfect_83 = 0;
double wob_84 = 0;
V started_85 = default;
double gotStars_86 = 0;
V lastJ_87 = default;
V tToMat_88 = default;
V tap_89 = default;
V api_90 = default;
if (_self28.IsNullish) _self28 = GlobalV;
drawTramp_62 = Fn((V _self91, int _argc92, V sag_98, V cam_99, V _a96, V _a97, V[] _rest93) => {
V L_100 = default;
double R_101 = 0;
V y0_102 = default;
double x0_103 = 0;
double rx_104 = 0;
double ry_105 = 0;
double sg_106 = 0;
if (_self91.IsNullish) _self91 = GlobalV;
L_100 = (SEqS(look_57, "sport") ? NewObj(4).Put("pad", ((V)("#c9ced6"))).Put("padD", ((V)("#9aa3b2"))).Put("mat", ((V)("#2f3340"))).Put("leg", ((V)("#2c2f38"))).V : NewObj(4).Put("pad", ((V)("#a7c79a"))).Put("padD", ((V)("#7c9a70"))).Put("mat", ((V)("#3a3a3a"))).Put("leg", ((V)("#7a6a58"))).V);
R_101 = 1.45;
y0_102 = GetIdx(Call(PX_44, V.Undef, ((V)(0D)), ((V)(MY_42)), cam_99), 1D);
x0_103 = (ToNum(W_38) / 2D);
rx_104 = (R_101 * K_40);
ry_105 = (0.17 * K_40);
Set(legs_61, "innerHTML", ((V)("")));
Set(pad_60, "innerHTML", ((V)("")));
Invoke(Arr(((V)((-1.25))), ((V)(0D)), ((V)(1.25))), "forEach", Fn((V _self91, int _argc107, V x_113, V _a110, V _a111, V _a112, V[] _rest108) => {
V a_114 = default;
V b_115 = default;
a_114 = Call(PX_44, V.Undef, ((V)((ToNum(x_113) * 0.95))), ((V)((MY_42 - 0.02))), cam_99);
b_115 = Call(PX_44, V.Undef, ((V)(((ToNum(x_113) * 1.05) + (Truthy(x_113) ? (Sign(ToNum(x_113)) * 0.12) : 0D)))), ((V)(0D)), cam_99);
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, GetIdx(a_114, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(a_114, 1D))).S("L").V(Call(r2_19, V.Undef, GetIdx(b_115, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(b_115, 1D))).End()))).Put("stroke", Get(L_100, "leg")).Put("stroke-width", ((V)(5D))).Put("stroke-linecap", ((V)("round"))).V, legs_61);
return default;
}, 1, "", true));
{
V a_116 = default;
V b_117 = default;
a_116 = Call(PX_44, V.Undef, ((V)((-1.4))), ((V)(0.02)), cam_99);
b_117 = Call(PX_44, V.Undef, ((V)(1.4)), ((V)(0.02)), cam_99);
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, GetIdx(a_116, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(a_116, 1D))).S("Q").V(Call(r2_19, V.Undef, ((V)(x0_103)))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(a_116, 1D)) - 6D))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(b_117, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(b_117, 1D))).End()))).Put("stroke", Get(L_100, "leg")).Put("stroke-width", ((V)(4D))).Put("fill", ((V)("none"))).Put("opacity", ((V)(0.8))).V, legs_61);
Invoke(YG_15, "shadow", legs_61, ((V)(x0_103)), Add(GetIdx(a_116, 1D), ((V)(2D))), ((V)((rx_104 * 0.95))), ((V)(0.18)));
}
sg_106 = (ToNum(sag_98) * K_40);
Invoke(matB_59, "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((x0_103 - (rx_104 * 0.86)))))).S(" ").V(Call(r2_19, V.Undef, y0_102)).S("Q").V(Call(r2_19, V.Undef, ((V)(x0_103)))).S(" ").V(Call(r2_19, V.Undef, ((V)(((ToNum(y0_102) - (ry_105 * 1.5)) + (sg_106 * 0.6)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((x0_103 + (rx_104 * 0.86)))))).S(" ").V(Call(r2_19, V.Undef, y0_102)).End())));
Invoke(matB_59, "setAttribute", ((V)("fill")), Get(L_100, "mat"));
Invoke(matB_59, "setAttribute", ((V)("stroke")), ((V)("none")));
Invoke(matF_58, "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((x0_103 - (rx_104 * 0.86)))))).S(" ").V(Call(r2_19, V.Undef, y0_102)).S("Q").V(Call(r2_19, V.Undef, ((V)(x0_103)))).S(" ").V(Call(r2_19, V.Undef, Add(Add(y0_102, ((V)((ry_105 * 1.4)))), ((V)((sg_106 * 2D)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((x0_103 + (rx_104 * 0.86)))))).S(" ").V(Call(r2_19, V.Undef, y0_102)).S("Z").End())));
Invoke(matF_58, "setAttribute", ((V)("fill")), Get(L_100, "mat"));
{
double i_118 = 0;
i_118 = 0D;
while (true) {
if (!((i_118 <= 14D))) break;
double u_120 = 0;
double x_121 = 0;
V y_122 = default;
u_120 = (i_118 / 14D);
x_121 = ((x0_103 - (rx_104 * 0.92)) + ((u_120 * rx_104) * 1.84));
y_122 = Add(y0_102, ((V)(((FdLibm.Sin((u_120 * System.Math.PI)) * ry_105) * 0.85))));
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)(x_121)))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(y_122) - 3D))))).S("l2 1.5l-4 1.5l4 1.5l-2 1.5").End()))).Put("stroke", ((V)("#b8bcc6"))).Put("stroke-width", ((V)(1D))).Put("fill", ((V)("none"))).V, pad_60);
i_118++;
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((x0_103 - rx_104))))).S(" ").V(Call(r2_19, V.Undef, y0_102)).S("A").V(Call(r2_19, V.Undef, ((V)(rx_104)))).S(" ").V(Call(r2_19, V.Undef, ((V)(ry_105)))).S(" 0 0 1 ").V(Call(r2_19, V.Undef, ((V)((x0_103 + rx_104))))).S(" ").V(Call(r2_19, V.Undef, y0_102)).End()))).Put("stroke", Get(L_100, "padD")).Put("stroke-width", ((V)(9D))).Put("fill", ((V)("none"))).V, pad_60);
Invoke(padF_64, "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((x0_103 - rx_104))))).S(" ").V(Call(r2_19, V.Undef, y0_102)).S("A").V(Call(r2_19, V.Undef, ((V)(rx_104)))).S(" ").V(Call(r2_19, V.Undef, ((V)(ry_105)))).S(" 0 0 0 ").V(Call(r2_19, V.Undef, ((V)((x0_103 + rx_104))))).S(" ").V(Call(r2_19, V.Undef, y0_102)).End())));
Invoke(padF_64, "setAttribute", ((V)("stroke")), Get(L_100, "pad"));
Invoke(padF2_63, "setAttribute", ((V)("d")), Invoke(padF_64, "getAttribute", ((V)("d"))));
Invoke(padF2_63, "setAttribute", ((V)("stroke")), Get(L_100, "padD"));
return default;
}, 2, "drawTramp", false);
seedStars_66 = Fn((V _self123, int _argc124, V _a126, V _a127, V _a128, V _a129, V[] _rest125) => {
if (_self123.IsNullish) _self123 = GlobalV;
Set(starsG_52, "innerHTML", ((V)("")));
stars_65 = Arr();
{
double y_130 = 0;
y_130 = 3.2;
while (true) {
if (!((y_130 < 60D))) break;
V gold_132 = default;
V g_133 = default;
gold_132 = (LtN(Invoke(G("Math"), "random"), 0.18) ? V.True : V.False);
g_133 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, starsG_52);
Call(S_16, V.Undef, ((V)("circle")), NewObj(3).Put("r", ((V)(14D))).Put("fill", ((V)("url(#ygGlow)"))).Put("opacity", ((V)(0.8))).V, g_133);
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)("M0-11L3.2-3.4L11-2.4L5 3L6.8 11L0 6.8L-6.8 11L-5 3L-11-2.4L-3.2-3.4Z"))).Put("fill", ((V)((Truthy(gold_132) ? "#ffcf3a" : "#ffffff")))).Put("stroke", ((V)((Truthy(gold_132) ? "#e09a14" : "#ffd84a")))).Put("stroke-width", ((V)(1.5))).Put("stroke-linejoin", ((V)("round"))).V, g_133);
Invoke(stars_65, "push", NewObj(5).Put("g", g_133).Put("x", ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.5)))).Put("y", ((V)(y_130))).Put("gold", gold_132).Put("taken", ((V)(0D))).V);
y_130 = (y_130 + (1.6 + (ToNum(Invoke(G("Math"), "random")) * 1.4)));
}
}
return default;
}, 0, "seedStars", false);
tap_89 = Fn((V _self134, int _argc135, V _a137, V _a138, V _a139, V _a140, V[] _rest136) => {
V ttm_141 = default;
if (_self134.IsNullish) _self134 = GlobalV;
if (!(Truthy(Get(ctx_35, "playing")))) {
return default;
}
ttm_141 = (LtN(contact_73, 0D) ? Call(tToMat_88, V.Undef) : ((V)(0D)));
if ((GeN(contact_73, 0D) || LtN(ttm_141, 0.22))) {
tapAt_76 = tNow_82;
return default;
}
if (!(Truthy(tw_77))) {
tw_77 = NewObj(2).Put("t0", tNow_82).Put("d", ((V)(520D))).V;
Invoke(SFX_20, "whoosh");
} else {
if (!(Truthy(Get(tw_77, "q")))) {
Set(tw_77, "q", ((V)(1D)));
}
}
return default;
}, 0, "tap", false);
{ V _t142 = ctx_35;
if (_t142.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t142));
{ V _t143 = Get(_t142, "bg");
bg_36 = _t143; }
{ V _t144 = Get(_t142, "fg");
fg_37 = _t144; }
{ V _t145 = Get(_t142, "W");
W_38 = _t145; }
{ V _t146 = Get(_t142, "H");
H_39 = _t146; } }
K_40 = 80D;
BASE_41 = (ToNum(H_39) - 20D);
MY_42 = 0.78;
G_43 = (9.8 * 0.72);
PX_44 = Fn((V _self28, int _argc147, V x_153, V y_154, V cam_155, V _a152, V[] _rest148) => {
return Arr(((V)(((ToNum(W_38) / 2D) + (ToNum(x_153) * K_40)))), ((V)((BASE_41 - ((ToNum(y_154) - ToNum(cam_155)) * K_40)))));
}, 3, "", true);
sky_45 = Call(S_16, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_38, ((V)(40D)))).Put("height", Add(H_39, ((V)(40D)))).Put("fill", ((V)("#9fd6ff"))).V, bg_36);
skyG_46 = Call(S_16, V.Undef, ((V)("rect")), NewObj(6).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_38, ((V)(40D)))).Put("height", Add(H_39, ((V)(40D)))).Put("fill", ((V)("url(#ygSky)"))).Put("opacity", ((V)(1D))).V, bg_36);
space_47 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("opacity", ((V)(0D))).V, bg_36);
{
double i_156 = 0;
i_156 = 0D;
while (true) {
if (!((i_156 < 40D))) break;
Call(S_16, V.Undef, ((V)("circle")), NewObj(5).Put("cx", Call(r2_19, V.Undef, ((V)((ToNum(Invoke(G("Math"), "random")) * ToNum(W_38)))))).Put("cy", Call(r2_19, V.Undef, ((V)((ToNum(Invoke(G("Math"), "random")) * ToNum(H_39)))))).Put("r", Call(r2_19, V.Undef, ((V)((0.6 + (ToNum(Invoke(G("Math"), "random")) * 1.3)))))).Put("fill", ((V)("#ffffff"))).Put("opacity", Call(r2_19, V.Undef, ((V)((0.4 + (ToNum(Invoke(G("Math"), "random")) * 0.6)))))).V, space_47);
i_156++;
}
}
world_48 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_36);
ground_49 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, world_48);
deco_50 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, world_48);
ruler_51 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, world_48);
starsG_52 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, world_48);
tramp_53 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, world_48);
{
V g_158 = default;
g_158 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(0 ").N((BASE_41 - 250D)).S(")").End()))).V, ground_49);
Invoke(YG_15, "yard", g_158, NewObj(3).Put("hz", ((V)(196D))).Put("flowers", (false ? V.True : V.False)).Put("sky", (false ? V.True : V.False)).V);
}
clouds_54 = Arr();
{
double i_159 = 0;
i_159 = 0D;
while (true) {
if (!((i_159 < 22D))) break;
double y_161 = 0;
double x_162 = 0;
double k_163 = 0;
V g_164 = default;
y_161 = ((4D + (i_159 * 2.2)) + (ToNum(Invoke(G("Math"), "random")) * 1.2));
x_162 = ((((ToNum(Invoke(G("Math"), "random")) - 0.5) * ToNum(W_38)) / K_40) * 0.92);
k_163 = (0.5 + (ToNum(Invoke(G("Math"), "random")) * 0.7));
g_164 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("opacity", ((V)(0.85))).V, deco_50);
Invoke(Arr(Arr(((V)((-22D))), ((V)(4D)), ((V)(15D))), Arr(((V)(0D)), ((V)((-5D))), ((V)(20D))), Arr(((V)(22D)), ((V)(4D)), ((V)(15D))), Arr(((V)(8D)), ((V)(7D)), ((V)(14D)))), "forEach", Fn((V _self28, int _argc165, V _a167, V _a168, V _a169, V _a170, V[] _rest166) => {
V a_173 = default;
V b_175 = default;
V r_177 = default;
{ V _t171 = ListOf(_a167);
{ V _t172 = GetIdx(_t171, 0D);
a_173 = _t172; }
{ V _t174 = GetIdx(_t171, 1D);
b_175 = _t174; }
{ V _t176 = GetIdx(_t171, 2D);
r_177 = _t176; }
}
return Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("cx", a_173).Put("cy", b_175).Put("r", r_177).Put("fill", ((V)("#ffffff"))).V, g_164);
}, 1, "", true));
Invoke(clouds_54, "push", NewObj(5).Put("g", g_164).Put("x", ((V)(x_162))).Put("y", ((V)(y_161))).Put("k", ((V)(k_163))).Put("v", ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.25)))).V);
i_159++;
}
}
birds_55 = Invoke(Arr(((V)(7D)), ((V)(12D)), ((V)(18D))), "map", Fn((V _self28, int _argc178, V y_184, V i_185, V _a182, V _a183, V[] _rest179) => {
V g_186 = default;
g_186 = Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)("M-7 0Q-3.5 -5 0 0Q3.5 -5 7 0"))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#3a2a55"))).Put("stroke-width", ((V)(2D))).Put("stroke-linecap", ((V)("round"))).V, deco_50);
return NewObj(4).Put("g", g_186).Put("y", y_184).Put("x", Add(((V)((-2D))), i_185)).Put("v", ((V)((0.6 + (ToNum(i_185) * 0.2))))).V;
return default;
}, 2, "", true));
bal_56 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, deco_50);
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)("M0 14Q3 26 -2 40"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.2))).Put("fill", ((V)("none"))).V, bal_56);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(5).Put("cx", ((V)(0D))).Put("cy", ((V)(0D))).Put("rx", ((V)(11D))).Put("ry", ((V)(14D))).Put("fill", ((V)("#ff7fbf"))).V, bal_56);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", ((V)((-4D)))).Put("cy", ((V)((-5D)))).Put("rx", ((V)(3D))).Put("ry", ((V)(4.5))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.5))).V, bal_56);
look_57 = ((V)("sport"));
matF_58 = Call(S_16, V.Undef, ((V)("path")), NewObj(0).V, tramp_53);
matB_59 = Call(S_16, V.Undef, ((V)("path")), NewObj(0).V, tramp_53);
pad_60 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, tramp_53);
legs_61 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, tramp_53);
padF2_63 = Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke-width", ((V)(13D))).Put("stroke-linecap", ((V)("round"))).V, fg_37);
padF_64 = Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke-width", ((V)(9D))).Put("stroke-linecap", ((V)("round"))).V, fg_37);
stars_65 = Arr();
best0_67 = (Get(YG_15, "_trampBest") is var _t187 && Truthy(_t187) ? _t187 : ((V)(0D)));
recLine_68 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, world_48);
me_69 = Invoke(ctx_35, "creature", Get(ctx_35, "playerKey"), NewObj(1).Put("yaw", ((V)(0D))).V);
Invoke(me_69, "depth", ((V)(2D)));
cy_70 = MY_42;
vy_71 = 0D;
cam_72 = 0D;
contact_73 = ((V)((-1D)));
vin_74 = 0D;
sag_75 = 0D;
tapAt_76 = ((V)((-9D)));
tw_77 = V.Null;
twirls_78 = 0D;
combo_79 = 0D;
maxH_80 = 0D;
lastMeter_81 = 0D;
tNow_82 = ((V)(0D));
perfect_83 = 0D;
wob_84 = 0D;
started_85 = (false ? V.True : V.False);
gotStars_86 = 0D;
lastJ_87 = ((V)(""));
tToMat_88 = Fn((V _self28, int _argc188, V _a190, V _a191, V _a192, V _a193, V[] _rest189) => {
double a_194 = 0;
double b_195 = 0;
double c_196 = 0;
double disc_197 = 0;
double t1_198 = 0;
a_194 = ((-G_43) / 2D);
b_195 = vy_71;
c_196 = (cy_70 - MY_42);
disc_197 = ((b_195 * b_195) - ((4D * a_194) * c_196));
if ((disc_197 < 0D)) {
return ((V)(9D));
}
t1_198 = (((-b_195) - System.Math.Sqrt(disc_197)) / (2D * a_194));
return ((V)(((t1_198 > 0D) ? t1_198 : 9D)));
return default;
}, 0, "", true);
api_90 = NewObj(9).Put("option", Fn((V _self199, int _argc200, V id_206, V _a203, V _a204, V _a205, V[] _rest201) => {
if (_self199.IsNullish) _self199 = GlobalV;
look_57 = id_206;
Call(drawTramp_62, V.Undef, ((V)(0D)), ((V)(cam_72)));
return default;
}, 1, "option", false)).Put("start", Fn((V _self207, int _argc208, V _a210, V _a211, V _a212, V _a213, V[] _rest209) => {
if (_self207.IsNullish) _self207 = GlobalV;
cy_70 = 2D;
vy_71 = 0D;
cam_72 = 0D;
contact_73 = ((V)((-1D)));
twirls_78 = 0D;
combo_79 = 0D;
maxH_80 = 0D;
lastMeter_81 = 0D;
perfect_83 = 0D;
tw_77 = V.Null;
gotStars_86 = 0D;
Call(seedStars_66, V.Undef);
started_85 = (true ? V.True : V.False);
look_57 = (Get(Get(ctx_35, "G"), "_opt") is var _t214 && Truthy(_t214) ? _t214 : ((V)("sport")));
Invoke(me_69, "play", ((V)("idle")));
return default;
}, 0, "start", false)).Put("down", Fn((V _self215, int _argc216, V p_222, V _a219, V _a220, V _a221, V[] _rest217) => {
if (_self215.IsNullish) _self215 = GlobalV;
Call(tap_89, V.Undef);
return default;
}, 1, "down", false)).Put("key", Fn((V _self223, int _argc224, V k_230, V dn_231, V _a228, V _a229, V[] _rest225) => {
if (_self223.IsNullish) _self223 = GlobalV;
if (Truthy((dn_231 is var _t232 && !Truthy(_t232) ? _t232 : (((SEqS(k_230, " ") || SEqS(k_230, "ArrowUp")) || SEqS(k_230, "Enter")) ? V.True : V.False)))) {
Call(tap_89, V.Undef);
return (true ? V.True : V.False);
}
return default;
}, 2, "key", false)).Put("_tap", tap_89).Put("_state", Fn((V _self28, int _argc233, V _a235, V _a236, V _a237, V _a238, V[] _rest234) => {
return NewObj(7).Put("cy", ((V)(ToNum(Invoke(((V)(cy_70)), "toFixed", ((V)(2D))))))).Put("vy", ((V)(ToNum(Invoke(((V)(vy_71)), "toFixed", ((V)(2D))))))).Put("contact", contact_73).Put("ttm", ((V)(ToNum(Invoke(Call(tToMat_88, V.Undef), "toFixed", ((V)(2D))))))).Put("maxH", ((V)(ToNum(Invoke(((V)(maxH_80)), "toFixed", ((V)(1D))))))).Put("twirls", ((V)(twirls_78))).Put("lastJ", lastJ_87).V;
}, 0, "_state", true)).Put("timeUp", Fn((V _self239, int _argc240, V _a242, V _a243, V _a244, V _a245, V[] _rest241) => {
if (_self239.IsNullish) _self239 = GlobalV;
Invoke(ctx_35, "finish", NewObj(1).Put("sub", ((V)(JsStrBuf.Begin().S("Highest ").V(Invoke(((V)(maxH_80)), "toFixed", ((V)(1D)))).S(" m \u00b7 ").N(gotStars_86).S(" stars \u00b7 ").N(twirls_78).S(" twirls").End()))).V);
return default;
}, 0, "timeUp", false)).Put("celebrate", Fn((V _self246, int _argc247, V st_253, V _a250, V _a251, V _a252, V[] _rest248) => {
if (_self246.IsNullish) _self246 = GlobalV;
Invoke(me_69, "play", ((V)((GeN(st_253, 2D) ? "happy" : "idle"))));
return default;
}, 1, "celebrate", false)).Put("update", Fn((V _self254, int _argc255, V dt_261, V t_262, V _a259, V _a260, V[] _rest256) => {
V E_263 = default;
V up_264 = default;
double tc_265 = 0;
V p_266 = default;
V hk_267 = default;
if (_self254.IsNullish) _self254 = GlobalV;
tNow_82 = t_262;
E_263 = NewObj(0).V;
if (Truthy(started_85)) {
double hgt_268 = 0;
if (LtN(contact_73, 0D)) {
vy_71 = (vy_71 - (G_43 * ToNum(dt_261)));
cy_70 = (cy_70 + (vy_71 * ToNum(dt_261)));
if (((cy_70 <= MY_42) && (vy_71 < 0D))) {
contact_73 = ((V)(0D));
vin_74 = (-vy_71);
cy_70 = MY_42;
Invoke(SFX_20, "boing");
if (Truthy(tw_77)) {
tw_77 = V.Null;
wob_84 = 1D;
combo_79 = 0D;
Invoke(ctx_35, "toast", ((V)("Wobble!")), ((V)((ToNum(W_38) / 2D))), ((V)((ToNum(H_39) * 0.6))), ((V)("#ff7a8a")));
Set(E_263, "spin", ((V)(0D)));
}
}
}
if (GeN(contact_73, 0D)) {
double CT_269 = 0;
double u_270 = 0;
contact_73 = Add(contact_73, dt_261);
CT_269 = 0.22;
u_270 = (ToNum(contact_73) / CT_269);
sag_75 = (FdLibm.Sin((Min(1D, u_270) * System.Math.PI)) * Min(0.42, (0.08 + (vin_74 * 0.035))));
cy_70 = (MY_42 - sag_75);
if ((u_270 >= 1D)) {
double mid_271 = 0;
double d_272 = 0;
double e_273 = 0;
double boost_274 = 0;
JsStrBuf j_275 = null;
mid_271 = (ToNum(t_262) - (CT_269 * 500D));
d_272 = System.Math.Abs((ToNum(tapAt_76) - mid_271));
e_273 = 0.84;
boost_274 = 0D;
j_275 = new JsStrBuf("");
if (NumTruthy(wob_84)) {
e_273 = 0.62;
wob_84 = 0D;
j_275.Set("wobble");
} else {
if ((d_272 < 110D)) {
e_273 = 1D;
boost_274 = 1.55;
j_275.Set("Perfect!");
perfect_83++;
combo_79++;
} else {
if ((d_272 < 210D)) {
e_273 = 1D;
boost_274 = 0.6;
j_275.Set("Good");
combo_79++;
} else {
combo_79 = 0D;
}
}
}
if (Truthy((((V)(j_275.Str)) is var _t276 && !Truthy(_t276) ? _t276 : (!string.Equals(j_275.Str, "wobble") ? V.True : V.False)))) {
V p_277 = default;
p_277 = Call(PX_44, V.Undef, ((V)(0D)), ((V)(MY_42)), ((V)(cam_72)));
Invoke(ctx_35, "toast", ((V)(string.Concat(j_275.Str, ((combo_79 >= 3D) ? JsStrBuf.Begin().S(" x").N(combo_79).End() : "")))), Add(GetIdx(p_277, 0D), ((V)(70D))), ((V)((ToNum(GetIdx(p_277, 1D)) - 30D))), ((V)((string.Equals(j_275.Str, "Perfect!") ? "#ffe36e" : "#8fe0ff"))));
Invoke(SFX_20, "pop");
}
lastJ_87 = (((V)(j_275.Str)) is var _t278 && Truthy(_t278) ? _t278 : ((V)("none")));
vy_71 = Min(24D, Max(4.3, ((vin_74 * e_273) + boost_274)));
contact_73 = ((V)((-1D)));
sag_75 = 0D;
tapAt_76 = ((V)((-9D)));
}
}
hgt_268 = (cy_70 - MY_42);
if ((hgt_268 > maxH_80)) {
double m_279 = 0;
maxH_80 = hgt_268;
m_279 = System.Math.Floor(maxH_80);
if ((m_279 > lastMeter_81)) {
Invoke(ctx_35, "add", ((V)((5D * (m_279 - lastMeter_81)))));
lastMeter_81 = m_279;
if (((m_279 % 5D) == 0D)) {
Invoke(ctx_35, "toast", ((V)(JsStrBuf.Begin().N(m_279).S(" m!").End())), ((V)(((ToNum(W_38) / 2D) + 120D))), ((V)((ToNum(H_39) * 0.36))), ((V)("#ffffff")));
Invoke(SFX_20, "score");
}
}
}
{
foreach (V _k280 in new JsIter(stars_65)) {
V s_281 = default;
s_281 = _k280;
if ((!(Truthy(Get(s_281, "taken"))) && (System.Math.Abs((ToNum(Get(s_281, "y")) - (cy_70 + 0.45))) < 0.45))) {
V p_282 = default;
Set(s_281, "taken", ((V)(1D)));
gotStars_86++;
p_282 = Call(PX_44, V.Undef, Get(s_281, "x"), Get(s_281, "y"), ((V)(cam_72)));
Invoke(ctx_35, "add", ((V)((Truthy(Get(s_281, "gold")) ? 30D : 10D))), Add(GetIdx(p_282, 0D), ((V)(40D))), GetIdx(p_282, 1D), ((V)((Truthy(Get(s_281, "gold")) ? "+30" : "+10"))), ((V)((Truthy(Get(s_281, "gold")) ? "#ffcf3a" : "#ffffff"))));
Invoke(ctx_35, "burst", GetIdx(p_282, 0D), GetIdx(p_282, 1D), ((V)("star")), ((V)(8D)), NewObj(3).Put("v", ((V)(110D))).Put("life", ((V)(0.6))).Put("g", ((V)(0D))).V);
Invoke(SFX_20, "pop");
Invoke(Get(s_281, "g"), "setAttribute", ((V)("opacity")), ((V)(0D)));
}
}
}
if (Truthy(tw_77)) {
double u_283 = 0;
u_283 = ((ToNum(t_262) - ToNum(Get(tw_77, "t0"))) / ToNum(Get(tw_77, "d")));
Set(E_263, "spin", ((V)((360D * ToNum(Invoke(YG_15, "SM", ((V)(Min(1D, u_283)))))))));
if ((u_283 >= 1D)) {
double pts_284 = 0;
V p_285 = default;
twirls_78++;
pts_284 = (15D + Min(30D, (combo_79 * 3D)));
p_285 = Call(PX_44, V.Undef, ((V)(0D)), ((V)((cy_70 + 0.6))), ((V)(cam_72)));
Invoke(ctx_35, "add", ((V)(pts_284)), ((V)((ToNum(GetIdx(p_285, 0D)) - 80D))), GetIdx(p_285, 1D), ((V)(JsStrBuf.Begin().S("Twirl! +").N(pts_284).End())), ((V)("#ff8fc8")));
if (Truthy(Get(tw_77, "q"))) {
tw_77 = NewObj(2).Put("t0", t_262).Put("d", ((V)(520D))).V;
} else {
tw_77 = V.Null;
}
}
}
}
up_264 = Call(cl_17, V.Undef, ((V)((vy_71 / 10D))), ((V)((-1D))), ((V)(1D)));
if (GeN(contact_73, 0D)) {
Object_assign(E_263, NewObj(4).Put("sq", ((V)((sag_75 * 0.9)))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("close", ((V)(0.3))).V);
} else {
Object_assign(E_263, NewObj(8).Put("armL", Add(Call(lerp_18, V.Undef, ((V)(50D)), ((V)(150D)), Call(cl_17, V.Undef, up_264, ((V)(0D)), ((V)(1D)))), ((V)((LtN(up_264, 0D) ? (40D * (-ToNum(up_264))) : 0D))))).Put("armR", Add(Call(lerp_18, V.Undef, ((V)(50D)), ((V)(150D)), Call(cl_17, V.Undef, up_264, ((V)(0D)), ((V)(1D)))), ((V)((LtN(up_264, 0D) ? (40D * (-ToNum(up_264))) : 0D))))).Put("sq", ((V)(((-0.05) * System.Math.Abs(ToNum(up_264)))))).Put("smile", ((V)(0.6))).Put("hap", ((V)(((System.Math.Abs(ToNum(up_264)) < 0.3) ? 0.8 : 0.3)))).Put("open", ((V)((ToNum(Call(cl_17, V.Undef, up_264, ((V)(0D)), ((V)(1D)))) * 0.4)))).Put("footL", ((V)((2D * ToNum(Call(cl_17, V.Undef, ((V)((-ToNum(up_264)))), ((V)(0D)), ((V)(1D)))))))).Put("footR", ((V)((2D * ToNum(Call(cl_17, V.Undef, ((V)((-ToNum(up_264)))), ((V)(0D)), ((V)(1D)))))))).V);
}
Invoke(me_69, "pose", E_263);
tc_265 = Max(0D, (cy_70 - 2.6));
cam_72 = (cam_72 + ((tc_265 - cam_72) * (1D - FdLibm.Exp(((-ToNum(dt_261)) * 7D)))));
Invoke(world_48, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(0 ").V(Call(r2_19, V.Undef, ((V)((cam_72 * K_40))))).S(")").End())));
p_266 = Call(PX_44, V.Undef, ((V)(0D)), ((V)(cy_70)), ((V)(cam_72)));
Invoke(me_69, "set", GetIdx(p_266, 0D), Add(GetIdx(p_266, 1D), ((V)((K_40 * 0.02)))), ((V)((1.02 * K_40))));
Call(drawTramp_62, V.Undef, ((V)(sag_75)), ((V)(0D)));
Invoke(padF_64, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(0 ").V(Call(r2_19, V.Undef, ((V)((cam_72 * K_40))))).S(")").End())));
Invoke(padF2_63, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(0 ").V(Call(r2_19, V.Undef, ((V)((cam_72 * K_40))))).S(")").End())));
hk_267 = Call(cl_17, V.Undef, ((V)((cam_72 / 35D))), ((V)(0D)), ((V)(1D)));
Invoke(skyG_46, "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, ((V)((1D - ToNum(hk_267))))));
Invoke(sky_45, "setAttribute", ((V)("fill")), ((V)((LtN(hk_267, 0.5) ? "#8fb4ff" : "#4a3a9a"))));
Invoke(space_47, "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, Call(cl_17, V.Undef, ((V)(((cam_72 - 18D) / 15D))), ((V)(0D)), ((V)(1D)))));
Invoke(clouds_54, "forEach", Fn((V _self254, int _argc286, V c_292, V _a289, V _a290, V _a291, V[] _rest287) => {
V q_293 = default;
OpSet(c_292, "x", 0, ((V)((ToNum(Get(c_292, "v")) * ToNum(dt_261)))));
if (GtN(Get(c_292, "x"), 2.4)) {
Set(c_292, "x", ((V)((-2.4))));
}
if (LtN(Get(c_292, "x"), (-2.4))) {
Set(c_292, "x", ((V)(2.4)));
}
q_293 = Call(PX_44, V.Undef, Get(c_292, "x"), Get(c_292, "y"), ((V)(0D)));
Invoke(Get(c_292, "g"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_19, V.Undef, GetIdx(q_293, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(q_293, 1D))).S(") scale(").V(Get(c_292, "k")).S(")").End())));
return default;
}, 1, "", true));
Invoke(birds_55, "forEach", Fn((V _self254, int _argc294, V b_300, V _a297, V _a298, V _a299, V[] _rest295) => {
V q_301 = default;
OpSet(b_300, "x", 0, ((V)((ToNum(Get(b_300, "v")) * ToNum(dt_261)))));
if (GtN(Get(b_300, "x"), 2.2)) {
Set(b_300, "x", ((V)((-2.2))));
}
q_301 = Call(PX_44, V.Undef, Get(b_300, "x"), Get(b_300, "y"), ((V)(0D)));
Invoke(Get(b_300, "g"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_19, V.Undef, GetIdx(q_301, 0D))).S(" ").V(Call(r2_19, V.Undef, Add(GetIdx(q_301, 1D), ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_262) / 200D))), Get(b_300, "y")))) * 3D)))))).S(") scale(1 ").V(Call(r2_19, V.Undef, ((V)((0.6 + (0.4 * System.Math.Abs(FdLibm.Sin(ToNum(Add(((V)((ToNum(t_262) / 120D))), Get(b_300, "y"))))))))))).S(")").End())));
return default;
}, 1, "", true));
{
V q_302 = default;
q_302 = Call(PX_44, V.Undef, ((V)(((-1.2) + (FdLibm.Sin((ToNum(t_262) / 3000D)) * 0.3)))), ((V)((24D + (FdLibm.Sin((ToNum(t_262) / 1700D)) * 0.4)))), ((V)(0D)));
Invoke(bal_56, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_19, V.Undef, GetIdx(q_302, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(q_302, 1D))).S(")").End())));
}
Invoke(stars_65, "forEach", Fn((V _self254, int _argc303, V s_309, V _a306, V _a307, V _a308, V[] _rest304) => {
if (!(Truthy(Get(s_309, "taken")))) {
V q_310 = default;
q_310 = Call(PX_44, V.Undef, Get(s_309, "x"), Get(s_309, "y"), ((V)(0D)));
Invoke(Get(s_309, "g"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_19, V.Undef, GetIdx(q_310, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(q_310, 1D))).S(") rotate(").V(Call(r2_19, V.Undef, ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_262) / 400D))), Get(s_309, "y")))) * 12D))))).S(") scale(").V(Call(r2_19, V.Undef, ((V)((1D + (0.08 * FdLibm.Sin(ToNum(Add(((V)((ToNum(t_262) / 250D))), Get(s_309, "y")))))))))).S(")").End())));
}
return default;
}, 1, "", true));
if (!(Truthy(Get(api_90, "_ru")))) {
Set(api_90, "_ru", ((V)(1D)));
{
double m_311 = 0;
m_311 = 1D;
while (true) {
if (!((m_311 <= 60D))) break;
V q_313 = default;
q_313 = Call(PX_44, V.Undef, ((V)(1.5)), ((V)((MY_42 + m_311))), ((V)(0D)));
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((ToNum(W_38) - (NumTruthy((m_311 % 5D)) ? 10D : 18D)))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(q_313, 1D))).S("H").V(W_38).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)((NumTruthy((m_311 % 5D)) ? 1.5 : 2.5)))).Put("opacity", ((V)(0.8))).V, ruler_51);
if (((m_311 % 5D) == 0D)) {
Set(Call(S_16, V.Undef, ((V)("text")), NewObj(7).Put("x", ((V)((ToNum(W_38) - 22D)))).Put("y", Call(r2_19, V.Undef, Add(GetIdx(q_313, 1D), ((V)(4D))))).Put("text-anchor", ((V)("end"))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)(12D))).Put("fill", ((V)("#ffffff"))).V, ruler_51), "textContent", ((V)(JsStrBuf.Begin().N(m_311).S(" m").End())));
}
m_311++;
}
}
}
Set(recLine_68, "innerHTML", ((V)("")));
if ((maxH_80 > 1D)) {
V q_314 = default;
q_314 = Call(PX_44, V.Undef, ((V)(0D)), ((V)((MY_42 + maxH_80))), ((V)(0D)));
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(JsStrBuf.Begin().S("M0 ").V(Call(r2_19, V.Undef, GetIdx(q_314, 1D))).S("H").V(W_38).End()))).Put("stroke", ((V)("#ffcf3a"))).Put("stroke-width", ((V)(2D))).Put("stroke-dasharray", ((V)("6 6"))).Put("opacity", ((V)(0.8))).V, recLine_68);
Set(Call(S_16, V.Undef, ((V)("text")), NewObj(6).Put("x", ((V)(8D))).Put("y", Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(q_314, 1D)) - 5D))))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)(12D))).Put("fill", ((V)("#ffcf3a"))).V, recLine_68), "textContent", ((V)(JsStrBuf.Begin().V(Invoke(((V)(maxH_80)), "toFixed", ((V)(1D)))).S(" m").End())));
}
return default;
}, 2, "update", false)).V;
Call(drawTramp_62, V.Undef, ((V)(0D)), ((V)(0D)));
Invoke(me_69, "set", ((V)((ToNum(W_38) / 2D))), GetIdx(Call(PX_44, V.Undef, ((V)(0D)), ((V)(MY_42)), ((V)(0D))), 1D), ((V)((1.02 * K_40))));
Call(seedStars_66, V.Undef);
return api_90;
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
