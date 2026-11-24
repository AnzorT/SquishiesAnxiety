// yg-slide.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_yg_slide_js
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
V TAU_21 = default;
V rad_22 = default;
V FA_23 = default;
V LA_24 = default;
V F_25 = default;
V LV_26 = default;
double HW_27 = 0;
V Wp_28 = default;
V P2_29 = default;
V G3_30 = default;
V poly_31 = default;
V quad_32 = default;
V EL_33 = default;
V gEl_34 = default;
V blob_35 = default;
V rnd_36 = default;
double KV_37 = 0;
double VB_38 = 0;
double VMAX_39 = 0;
double DEC_40 = 0;
double LMAX_41 = 0;
double RW_42 = 0;
double CS_43 = 0;
double LEN_44 = 0;
double RS_45 = 0;
double RH_46 = 0;
double SH_47 = 0;
double WH_48 = 0;
double GA_49 = 0;
double GF_50 = 0;
double K_51 = 0;
double T0_52 = 0;
double SD0_53 = 0;
double ST0_54 = 0;
V SECT_55 = default;
V secAt_56 = default;
V HS_57 = default;
V TIERS_58 = default;
V tierOf_59 = default;
V DEF_60 = default;
V LOOK_61 = default;
V ICON_62 = default;
V ART_63 = default;
V tree_64 = default;
V bush_65 = default;
V flowers_66 = default;
V pinwheel_67 = default;
V sprinkler_68 = default;
V birdhouse_69 = default;
V shed_70 = default;
V haystack_71 = default;
V sunflower_72 = default;
V lounger_73 = default;
V umbrella_74 = default;
V ball_75 = default;
V donut_76 = default;
V fence_77 = default;
V bed_78 = default;
V css_79 = default;
css_79 = Fn((V _self80, int _argc81, V _a83, V _a84, V _a85, V _a86, V[] _rest82) => {
V st_87 = default;
if (_self80.IsNullish) _self80 = GlobalV;
if (Truthy(Invoke(G("document"), "getElementById", ((V)("ygs-css"))))) {
return default;
}
st_87 = Invoke(G("document"), "createElement", ((V)("style")));
Set(st_87, "id", ((V)("ygs-css")));
Set(st_87, "textContent", ((V)(JsStrBuf.Begin().S(".ygs-spin{animation:ygsSpin 1.1s linear infinite;}@keyframes ygsSpin{to{transform:rotate(360deg);}}").S(".ygs-spr{animation:ygsSpr .6s linear infinite;}@keyframes ygsSpr{to{stroke-dashoffset:-30;}}").S(".ygs-bob{animation:ygsBob 1.8s ease-in-out infinite;}@keyframes ygsBob{50%{transform:translateY(-2.5px);}}").S(".ygs-glow{animation:ygsGlow .7s ease-in-out infinite alternate;}@keyframes ygsGlow{to{fill:#fff3b0;}}").S(".ygs-shim{animation:ygsShim 1.2s ease-in-out infinite alternate;}@keyframes ygsShim{to{fill:#b6ecff;}}").S(".ygs-tw{animation:ygsTw .9s ease-in-out infinite alternate;transform-box:fill-box;transform-origin:center;}@keyframes ygsTw{from{opacity:.3;}to{opacity:1;}}").S(".ygs-tip,.ygs-pop{transform-box:fill-box;transform-origin:50% 100%;transition:transform .35s cubic-bezier(.3,1.5,.5,1),opacity .4s;}").S(".ygs-hit .ygs-tip{transform:rotate(78deg) translateY(4px);}.ygs-hit .ygs-pop{transform:scale(1.25,0.35);opacity:0.6;}").End())));
Invoke(Get(G("document"), "head"), "appendChild", st_87);
return default;
}, 0, "css", false);
YG_15 = Get(G("window"), "YardGames");
if ((!(Truthy(YG_15)) || !(Truthy(Get(YG_15, "add"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t88 = YG_15;
if (_t88.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t88));
{ V _t89 = Get(_t88, "S");
S_16 = _t89; }
{ V _t90 = Get(_t88, "cl");
cl_17 = _t90; }
{ V _t91 = Get(_t88, "lerp");
lerp_18 = _t91; }
{ V _t92 = Get(_t88, "r2");
r2_19 = _t92; }
{ V _t93 = Get(_t88, "SFX");
SFX_20 = _t93; }
{ V _t94 = Get(_t88, "TAU");
TAU_21 = _t94; } }
rad_22 = Fn((V _self1, int _argc95, V d_101, V _a98, V _a99, V _a100, V[] _rest96) => {
return ((V)(((ToNum(d_101) * System.Math.PI) / 180D)));
}, 1, "", true);
FA_23 = Call(rad_22, V.Undef, ((V)(32D)));
LA_24 = Call(rad_22, V.Undef, ((V)((-24D))));
F_25 = Arr(((V)(FdLibm.Cos(ToNum(FA_23)))), ((V)(FdLibm.Sin(ToNum(FA_23)))));
LV_26 = Arr(((V)(FdLibm.Cos(ToNum(LA_24)))), ((V)(FdLibm.Sin(ToNum(LA_24)))));
HW_27 = 52D;
Wp_28 = Fn((V _self1, int _argc102, V s_108, V l_109, V h_110, V _a107, V[] _rest103) => {
return Arr(((V)(((ToNum(s_108) * ToNum(GetIdx(F_25, 0D))) + ((ToNum(l_109) * HW_27) * ToNum(GetIdx(LV_26, 0D)))))), ((V)((((ToNum(s_108) * ToNum(GetIdx(F_25, 1D))) + ((ToNum(l_109) * HW_27) * ToNum(GetIdx(LV_26, 1D)))) - ToNum((h_110 is var _t111 && Truthy(_t111) ? _t111 : ((V)(0D))))))));
}, 3, "", true);
P2_29 = Fn((V _self1, int _argc112, V p_118, V _a115, V _a116, V _a117, V[] _rest113) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_19, V.Undef, GetIdx(p_118, 0D))).S(" ").V(Call(r2_19, V.Undef, GetIdx(p_118, 1D))).End()));
}, 1, "", true);
G3_30 = Fn((V _self1, int _argc119, V ds_125, V lp_126, V h_127, V _a124, V[] _rest120) => {
return Arr(((V)(((ToNum(ds_125) * ToNum(GetIdx(F_25, 0D))) + (ToNum(lp_126) * ToNum(GetIdx(LV_26, 0D)))))), ((V)((((ToNum(ds_125) * ToNum(GetIdx(F_25, 1D))) + (ToNum(lp_126) * ToNum(GetIdx(LV_26, 1D)))) - ToNum((h_127 is var _t128 && Truthy(_t128) ? _t128 : ((V)(0D))))))));
}, 3, "", true);
poly_31 = Fn((V _self1, int _argc129, V pts_135, V _a132, V _a133, V _a134, V[] _rest130) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_135, "map", P2_29), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
quad_32 = Fn((V _self1, int _argc136, V s0_142, V s1_143, V l0_144, V l1_145, V[] _rest137) => {
V h0_146 = default;
V h1_147 = default;
h0_146 = (_argc136 > 4 ? _rest137[0] : V.Undef);
h1_147 = (_argc136 > 5 ? _rest137[1] : V.Undef);
return Call(poly_31, V.Undef, Arr(Call(Wp_28, V.Undef, s0_142, l0_144, h0_146), Call(Wp_28, V.Undef, s1_143, l0_144, (h1_147.IsNullish ? h0_146 : h1_147)), Call(Wp_28, V.Undef, s1_143, l1_145, (h1_147.IsNullish ? h0_146 : h1_147)), Call(Wp_28, V.Undef, s0_142, l1_145, h0_146)));
}, 6, "", true);
EL_33 = Call(Fn((V _self1, int _argc148, V _a150, V _a151, V _a152, V _a153, V[] _rest149) => {
double a_154 = 0;
double b_155 = 0;
double c_156 = 0;
double m_157 = 0;
double d_158 = 0;
a_154 = ((ToNum(GetIdx(F_25, 0D)) * ToNum(GetIdx(F_25, 0D))) + (ToNum(GetIdx(LV_26, 0D)) * ToNum(GetIdx(LV_26, 0D))));
b_155 = ((ToNum(GetIdx(F_25, 0D)) * ToNum(GetIdx(F_25, 1D))) + (ToNum(GetIdx(LV_26, 0D)) * ToNum(GetIdx(LV_26, 1D))));
c_156 = ((ToNum(GetIdx(F_25, 1D)) * ToNum(GetIdx(F_25, 1D))) + (ToNum(GetIdx(LV_26, 1D)) * ToNum(GetIdx(LV_26, 1D))));
m_157 = ((a_154 + c_156) / 2D);
d_158 = System.Math.Sqrt(((((a_154 - c_156) * (a_154 - c_156)) / 4D) + (b_155 * b_155)));
return NewObj(3).Put("kx", ((V)(System.Math.Sqrt((m_157 + d_158))))).Put("ky", ((V)(System.Math.Sqrt((m_157 - d_158))))).Put("rot", Call(r2_19, V.Undef, ((V)((((FdLibm.Atan2((2D * b_155), (a_154 - c_156)) / 2D) * 180D) / System.Math.PI))))).V;
return default;
}, 0, "", true), V.Undef);
gEl_34 = Fn((V _self1, int _argc159, V x_165, V y_166, V r_167, V a_168, V[] _rest160) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(r2_19, V.Undef, x_165)).S("\" cy=\"").V(Call(r2_19, V.Undef, y_166)).S("\" rx=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(r_167) * ToNum(Get(EL_33, "kx"))))))).S("\" ry=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(r_167) * ToNum(Get(EL_33, "ky"))))))).S("\" transform=\"rotate(").V(Get(EL_33, "rot")).S(" ").V(Call(r2_19, V.Undef, x_165)).S(" ").V(Call(r2_19, V.Undef, y_166)).S(")\" ").V((a_168 is var _t169 && Truthy(_t169) ? _t169 : ((V)("")))).S("/>").End()));
}, 4, "", true);
blob_35 = Fn((V _self1, int _argc170, V hs_176, V wp_177, V wob_178, V sd_179, V[] _rest171) => {
V pts_180 = default;
JsStrBuf d_181 = null;
pts_180 = Arr();
{
double i_182 = 0;
i_182 = 0D;
while (true) {
if (!((i_182 < 18D))) break;
double t_184 = 0;
double k_185 = 0;
t_184 = ((i_182 / 18D) * ToNum(TAU_21));
k_185 = ((1D + ((ToNum(wob_178) * FdLibm.Sin(ToNum(Add(((V)((t_184 * 3D))), sd_179)))) * 0.6)) + ((ToNum(wob_178) * FdLibm.Sin(((t_184 * 5D) + (ToNum(sd_179) * 2D)))) * 0.4));
Invoke(pts_180, "push", Call(G3_30, V.Undef, ((V)(((FdLibm.Cos(t_184) * ToNum(hs_176)) * k_185))), ((V)(((FdLibm.Sin(t_184) * ToNum(wp_177)) * k_185))), ((V)(0D))));
i_182++;
}
}
d_181 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(P2_29, V.Undef, GetIdx(pts_180, 0D))).End());
{
double i_186 = 0;
i_186 = 0D;
while (true) {
if (!(Lt(((V)(i_186)), Get(pts_180, "length")))) break;
V a_188 = default;
V b_189 = default;
V m_190 = default;
a_188 = GetIdx(pts_180, i_186);
b_189 = GetIdx(pts_180, ((i_186 + 1D) % ToNum(Get(pts_180, "length"))));
m_190 = Arr(((V)((ToNum(Add(GetIdx(a_188, 0D), GetIdx(b_189, 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(a_188, 1D), GetIdx(b_189, 1D))) / 2D))));
d_181.S("Q").V(Call(P2_29, V.Undef, a_188)).S(" ").V(Call(P2_29, V.Undef, m_190));
i_186++;
}
}
return ((V)(string.Concat(d_181.Str, "Z")));
return default;
}, 4, "", true);
rnd_36 = Fn((V _self1, int _argc191, V sd_197, V _a194, V _a195, V _a196, V[] _rest192) => {
return Fn((V _self1, int _argc198, V _a200, V _a201, V _a202, V _a203, V[] _rest199) => {
return ((V)((ToNum((sd_197 = ((V)((((ToNum(sd_197) * 9301D) + 49297D) % 233280D))))) / 233280D)));
}, 0, "", true);
}, 1, "", true);
KV_37 = 4D;
VB_38 = 37D;
VMAX_39 = 125D;
DEC_40 = 0.1;
LMAX_41 = 0.58;
RW_42 = 0.2;
CS_43 = 480D;
LEN_44 = 16000D;
RS_45 = (LEN_44 - 260D);
RH_46 = 40D;
SH_47 = 56D;
WH_48 = 21D;
GA_49 = 900D;
GF_50 = 560D;
K_51 = 80D;
T0_52 = (-150D);
SD0_53 = (-40D);
ST0_54 = (-96D);
SECT_55 = Arr(Arr(((V)(0D)), ((V)("meadow"))), Arr(((V)(3200D)), ((V)("garden"))), Arr(((V)(6800D)), ((V)("farm"))), Arr(((V)(10400D)), ((V)("sprinkle"))), Arr(((V)(13800D)), ((V)("final"))));
secAt_56 = Fn((V _self1, int _argc204, V s_210, V _a207, V _a208, V _a209, V[] _rest205) => {
V n_211 = default;
n_211 = ((V)("meadow"));
{
foreach (V _k212 in new JsIter(SECT_55)) {
V a_213 = default;
V b_214 = default;
{ V _t215 = ListOf(_k212);
{ V _t216 = GetIdx(_t215, 0D);
a_213 = _t216; }
{ V _t217 = GetIdx(_t215, 1D);
b_214 = _t217; }
}
if (Ge(s_210, a_213)) {
n_211 = b_214;
}
}
}
return n_211;
return default;
}, 1, "", true);
HS_57 = Fn((V _self1, int _argc218, V s_224, V _a221, V _a222, V _a223, V[] _rest219) => {
return ((V)((LeN(s_224, RS_45) ? SH_47 : (SH_47 + (RH_46 * Pow(ToNum(Call(cl_17, V.Undef, ((V)(((ToNum(s_224) - RS_45) / (LEN_44 - RS_45)))), ((V)(0D)), ((V)(1D)))), 2D))))));
}, 1, "", true);
TIERS_58 = Arr(Arr(((V)(0D)), ((V)("Splish!")), ((V)("#bfe8ff"))), Arr(((V)(42D)), ((V)("Splash!")), ((V)("#8fe0ff"))), Arr(((V)(60D)), ((V)("Big Splash!")), ((V)("#7ee0d6"))), Arr(((V)(80D)), ((V)("Mega Splash!")), ((V)("#ffe36e"))), Arr(((V)(100D)), ((V)("TIDAL WAVE!")), ((V)("#ff8fc8"))));
tierOf_59 = Fn((V _self1, int _argc225, V v_231, V _a228, V _a229, V _a230, V[] _rest226) => {
V t_232 = default;
t_232 = GetIdx(TIERS_58, 0D);
{
foreach (V _k233 in new JsIter(TIERS_58)) {
V q_234 = default;
q_234 = _k233;
if (Ge(v_231, GetIdx(q_234, 0D))) {
t_232 = q_234;
}
}
}
return t_232;
return default;
}, 1, "", true);
DEF_60 = NewObj(11).Put("rock", NewObj(4).Put("hs", ((V)(18D))).Put("hw", ((V)(0.34))).Put("hh", ((V)(26D))).Put("k", ((V)("hard"))).V).Put("gnome", NewObj(4).Put("hs", ((V)(12D))).Put("hw", ((V)(0.24))).Put("hh", ((V)(46D))).Put("k", ((V)("hard"))).V).Put("hay", NewObj(4).Put("hs", ((V)(20D))).Put("hw", ((V)(0.38))).Put("hh", ((V)(30D))).Put("k", ((V)("hard"))).V).Put("log", NewObj(4).Put("hs", ((V)(12D))).Put("hw", ((V)(0.75))).Put("hh", ((V)(18D))).Put("k", ((V)("hard"))).V).Put("bucket", NewObj(4).Put("hs", ((V)(12D))).Put("hw", ((V)(0.2))).Put("hh", ((V)(22D))).Put("k", ((V)("soft"))).V).Put("sand", NewObj(4).Put("hs", ((V)(18D))).Put("hw", ((V)(0.32))).Put("hh", ((V)(12D))).Put("k", ((V)("soft"))).V).Put("leaves", NewObj(4).Put("hs", ((V)(20D))).Put("hw", ((V)(0.34))).Put("hh", ((V)(10D))).Put("k", ((V)("soft"))).V).Put("mud", NewObj(5).Put("hs", ((V)(50D))).Put("hw", ((V)(0.44))).Put("hh", ((V)(3D))).Put("k", ((V)("mud"))).Put("flat", ((V)(1D))).V).Put("slick", NewObj(5).Put("hs", ((V)(50D))).Put("hw", ((V)(0.42))).Put("hh", ((V)(3D))).Put("k", ((V)("boost"))).Put("flat", ((V)(1D))).V).Put("gold", NewObj(5).Put("hs", ((V)(30D))).Put("hw", ((V)(0.4))).Put("hh", ((V)(3D))).Put("k", ((V)("gold"))).Put("flat", ((V)(1D))).V).Put("ramp", NewObj(5).Put("hs", ((V)(26D))).Put("hw", ((V)(0.95))).Put("hh", ((V)(18D))).Put("k", ((V)("ramp"))).Put("flat", ((V)(1D))).V).V;
LOOK_61 = NewObj(3).Put("rainbow", NewObj(12).Put("bands", Arr(((V)("#ff7a8a")), ((V)("#ffa95a")), ((V)("#ffdc5a")), ((V)("#7fd870")), ((V)("#5cb8ff")), ((V)("#a98bff")))).Put("top", ((V)("#ffffff"))).Put("face", ((V)("#e6e0f6"))).Put("side", ((V)("#cfc6ec"))).Put("seam", ((V)("#ffffff"))).Put("shine", ((V)("#ffffff"))).Put("deck", ((V)("#c9b8f2"))).Put("post", ((V)("#ffffff"))).Put("postD", ((V)("#a89ad0"))).Put("boost", ((V)(1D))).Put("hit", ((V)(1D))).Put("steer", ((V)(1.1))).V).Put("gold", NewObj(12).Put("bands", Arr(((V)("#f6c94a")), ((V)("#fbd96e")), ((V)("#f6c94a")), ((V)("#fbd96e")))).Put("top", ((V)("#fff2c0"))).Put("face", ((V)("#e8b43a"))).Put("side", ((V)("#cf9a24"))).Put("seam", ((V)("#fff6d0"))).Put("shine", ((V)("#ffffff"))).Put("deck", ((V)("#f3d27a"))).Put("post", ((V)("#f4f6fb"))).Put("postD", ((V)("#b9a060"))).Put("boost", ((V)(1.12))).Put("hit", ((V)(1D))).Put("steer", ((V)(1D))).V).Put("wood", NewObj(12).Put("planks", Arr(((V)("#d9a066")), ((V)("#cd9358")))).Put("top", ((V)("#e8b67c"))).Put("face", ((V)("#b47740"))).Put("side", ((V)("#9a6232"))).Put("seam", ((V)("#9a6232"))).Put("shine", ((V)("#fff2dc"))).Put("deck", ((V)("#e2ad74"))).Put("post", ((V)("#a46c3a"))).Put("postD", ((V)("#6b4426"))).Put("boost", ((V)(1D))).Put("hit", ((V)(0.85))).Put("steer", ((V)(1D))).V).V;
ICON_62 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#79c25c\"/><path d=\"M20 -4L44 -12L124 46L100 54Z\" fill=\"#ffffff\"/><path d=\"M26 -4L44 -10L118 44L100 50Z\" fill=\"#ff7a8a\"/><path d=\"M32 -4L44 -8L112 42L100 46Z\" fill=\"#ffdc5a\"/><path d=\"M38 -4L44 -6L106 40L100 42Z\" fill=\"#5cb8ff\"/>", "<path d=\"M40 30V54M70 52V76M100 54V80\" stroke=\"#ffffff\" stroke-width=\"3\"/><ellipse cx=\"22\" cy=\"70\" rx=\"20\" ry=\"7\" fill=\"#2a86e6\"/><ellipse cx=\"22\" cy=\"66\" rx=\"17\" ry=\"5\" fill=\"#8fe6ff\"/><path d=\"M14 64Q16 50 20 62M22 62Q25 44 28 62\" stroke=\"#ffffff\" stroke-width=\"2.6\" fill=\"none\" stroke-linecap=\"round\"/>", "<circle cx=\"58\" cy=\"18\" r=\"8\" fill=\"#ffe7c8\" stroke=\"#6b4426\" stroke-width=\"2\"/><path d=\"M38 6h-10M40 14h-12M38 22h-9\" stroke=\"#ffffff\" stroke-width=\"2.4\" stroke-linecap=\"round\" opacity=\"0.9\"/></svg>")));
ART_63 = NewObj(11).Put("rock", Fn((V _self1, int _argc235, V _a237, V _a238, V _a239, V _a240, V[] _rest236) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(22D)), ((V)("fill=\"#2d4a22\" opacity=\"0.22\"")))).S("<path d=\"M-24 2C-26 -10 -16 -24 -2 -25C12 -26 24 -16 25 -4C26 2 20 6 0 6C-16 6 -23 5 -24 2Z\" fill=\"#a3a9b2\" stroke=\"#5c6470\" stroke-width=\"2.2\"/><path d=\"M-15 -14C-9 -21 3 -22 9 -18\" stroke=\"#d2d6dc\" stroke-width=\"4.5\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M5 3C14 1 20 -4 22 -9\" stroke=\"#7e8690\" stroke-width=\"3\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M-20 -2Q-16 -8 -10 -6\" stroke=\"#7fb06a\" stroke-width=\"3\" fill=\"none\" stroke-linecap=\"round\"/>").End()));
}, 0, "rock", true)).Put("gnome", Fn((V _self1, int _argc241, V _a243, V _a244, V _a245, V _a246, V[] _rest242) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(14D)), ((V)("fill=\"#2d4a22\" opacity=\"0.22\"")))).S("<g class=\"ygs-tip\"><ellipse cx=\"-6\" cy=\"-2\" rx=\"6.5\" ry=\"4\" fill=\"#6b4426\"/><ellipse cx=\"6\" cy=\"-2\" rx=\"6.5\" ry=\"4\" fill=\"#6b4426\"/><path d=\"M-12 -4C-13 -16 -9 -22 0 -22C9 -22 13 -16 12 -4Z\" fill=\"#4f8ee8\" stroke=\"#2c5aa8\" stroke-width=\"1.6\"/><path d=\"M-11.5 -10H11.5\" stroke=\"#6b4426\" stroke-width=\"3\"/><rect x=\"-2.5\" y=\"-12\" width=\"5\" height=\"4\" rx=\"1\" fill=\"#ffd84a\"/>").S("<path d=\"M-9 -26C-13 -16 -6 -7 0 -6C6 -7 13 -16 9 -26Z\" fill=\"#ffffff\" stroke=\"#d8d2c6\" stroke-width=\"1.4\"/><ellipse cy=\"-28\" rx=\"8\" ry=\"6.2\" fill=\"#ffd2b0\"/><circle cy=\"-25.5\" r=\"2.8\" fill=\"#ff9a8a\"/><path d=\"M-4.5 -29h2.4M2.1 -29h2.4\" stroke=\"#4a3a2e\" stroke-width=\"1.5\" stroke-linecap=\"round\"/><path d=\"M-10.5 -31C-9 -39 -4 -49 2 -51C3 -44 8 -37 10.5 -31Z\" fill=\"#ff5e6c\" stroke=\"#b8304a\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/><path d=\"M-10 -31.5H10.5\" stroke=\"#b8304a\" stroke-width=\"2\" stroke-linecap=\"round\"/></g>").End()));
}, 0, "gnome", true)).Put("hay", Fn((V _self1, int _argc247, V _a249, V _a250, V _a251, V _a252, V[] _rest248) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_34, V.Undef, ((V)(4D)), ((V)(2D)), ((V)(28D)), ((V)("fill=\"#2d4a22\" opacity=\"0.22\"")))).S("<g class=\"ygs-pop\"><path d=\"M-24 -26L-12 -34L36 -34L24 -26Z\" fill=\"#fae39a\" stroke=\"#b88a2a\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/><path d=\"M24 -26L36 -34L36 -8L24 0Z\" fill=\"#dcb24e\" stroke=\"#b88a2a\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/><rect x=\"-24\" y=\"-26\" width=\"48\" height=\"26\" rx=\"4\" fill=\"#f2cf6a\" stroke=\"#b88a2a\" stroke-width=\"1.8\"/>").S("<path d=\"M-20 -20h12M-4 -18h14M-18 -9h9M2 -7h16M14 -21h7\" stroke=\"#c99a36\" stroke-width=\"1.6\" stroke-linecap=\"round\"/><path d=\"M-9 -26V0M9 -26V0M-3 -34L9 -26M15 -34L27 -26\" stroke=\"#b0453a\" stroke-width=\"2.2\"/></g>").End()));
}, 0, "hay", true)).Put("log", Fn((V _self1, int _argc253, V _a255, V _a256, V _a257, V _a258, V[] _rest254) => {
V a_259 = default;
V b_260 = default;
a_259 = Call(G3_30, V.Undef, ((V)(0D)), ((V)((-38D))), ((V)(9D)));
b_260 = Call(G3_30, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(9D)));
return ((V)(JsStrBuf.Begin().V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(30D)), ((V)("fill=\"#2d4a22\" opacity=\"0.2\"")))).S("<path d=\"M").V(Call(P2_29, V.Undef, a_259)).S("L").V(Call(P2_29, V.Undef, b_260)).S("\" stroke=\"#7a4a26\" stroke-width=\"20\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_29, V.Undef, a_259)).S("L").V(Call(P2_29, V.Undef, b_260)).S("\" stroke=\"#a46c3a\" stroke-width=\"15\" stroke-linecap=\"round\"/>").S("<path d=\"M").V(Call(P2_29, V.Undef, Arr(Add(GetIdx(a_259, 0D), ((V)(8D))), ((V)((ToNum(GetIdx(a_259, 1D)) - 7D)))))).S("L").V(Call(P2_29, V.Undef, Arr(((V)((ToNum(GetIdx(b_260, 0D)) - 4D))), ((V)((ToNum(GetIdx(b_260, 1D)) - 6D)))))).S("\" stroke=\"#c48a52\" stroke-width=\"2.4\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_29, V.Undef, Arr(Add(GetIdx(a_259, 0D), ((V)(12D))), Add(GetIdx(a_259, 1D), ((V)(1D)))))).S("L").V(Call(P2_29, V.Undef, Arr(((V)((ToNum(GetIdx(b_260, 0D)) - 10D))), Add(GetIdx(b_260, 1D), ((V)(3D)))))).S("\" stroke=\"#7a4a26\" stroke-width=\"1.8\" stroke-linecap=\"round\" opacity=\"0.7\"/>").S("<ellipse cx=\"").V(Call(r2_19, V.Undef, GetIdx(a_259, 0D))).S("\" cy=\"").V(Call(r2_19, V.Undef, GetIdx(a_259, 1D))).S("\" rx=\"7\" ry=\"9.5\" transform=\"rotate(-24 ").V(Invoke(Call(P2_29, V.Undef, a_259), "replace", ((V)(" ")), ((V)(" ")))).S(")\" fill=\"#f0c98e\" stroke=\"#7a4a26\" stroke-width=\"2\"/><ellipse cx=\"").V(Call(r2_19, V.Undef, GetIdx(a_259, 0D))).S("\" cy=\"").V(Call(r2_19, V.Undef, GetIdx(a_259, 1D))).S("\" rx=\"3.4\" ry=\"5\" transform=\"rotate(-24 ").V(Call(P2_29, V.Undef, a_259)).S(")\" fill=\"none\" stroke=\"#c49058\" stroke-width=\"1.4\"/>").S("<path d=\"M").V(Call(P2_29, V.Undef, Arr(((V)((ToNum(GetIdx(b_260, 0D)) - 14D))), ((V)((ToNum(GetIdx(b_260, 1D)) - 9D)))))).S("q3 -9 9 -8\" stroke=\"#6fbf55\" stroke-width=\"2.4\" fill=\"none\" stroke-linecap=\"round\"/><ellipse cx=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(b_260, 0D)) - 5D))))).S("\" cy=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(b_260, 1D)) - 17D))))).S("\" rx=\"4\" ry=\"2.4\" fill=\"#7fd06a\"/>").End()));
return default;
}, 0, "log", true)).Put("bucket", Fn((V _self1, int _argc261, V _a263, V _a264, V _a265, V _a266, V[] _rest262) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(13D)), ((V)("fill=\"#2d4a22\" opacity=\"0.2\"")))).S("<g class=\"ygs-tip\">").V(Call(gEl_34, V.Undef, ((V)(10D)), ((V)(0D)), ((V)(9D)), ((V)("fill=\"#f1d48a\"")))).S("<path d=\"M-10 -20L10 -20L8 0L-8 0Z\" fill=\"#4fc6c0\" stroke=\"#24877f\" stroke-width=\"1.8\" stroke-linejoin=\"round\"/><ellipse cy=\"-20\" rx=\"10\" ry=\"3.4\" fill=\"#2e9e96\" stroke=\"#24877f\" stroke-width=\"1.6\"/><path d=\"M-10 -20Q0 -34 10 -20\" stroke=\"#ff7a8a\" stroke-width=\"2.2\" fill=\"none\"/><path d=\"M-9 -12H9\" stroke=\"#ffffff\" stroke-width=\"2.4\" opacity=\"0.7\"/></g>").End()));
}, 0, "bucket", true)).Put("sand", Fn((V _self1, int _argc267, V _a269, V _a270, V _a271, V _a272, V[] _rest268) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(22D)), ((V)("fill=\"#2d4a22\" opacity=\"0.18\"")))).S("<g class=\"ygs-pop\"><path d=\"M-24 2C-20 -8 -8 -13 0 -13C10 -13 20 -8 24 2Z\" fill=\"#f1d48a\" stroke=\"#c9a456\" stroke-width=\"1.8\"/><path d=\"M-10 -6h3M2 -9h3M10 -3h3M-3 -2h3\" stroke=\"#c9a456\" stroke-width=\"1.6\" stroke-linecap=\"round\"/><path d=\"M6 -10L14 -26\" stroke=\"#ff7a8a\" stroke-width=\"2.6\" stroke-linecap=\"round\"/><path d=\"M12 -30L18 -26L14 -20L9 -24Z\" fill=\"#ffb84a\" stroke=\"#d07a20\" stroke-width=\"1.2\"/></g>").End()));
}, 0, "sand", true)).Put("leaves", Fn((V _self1, int _argc273, V _a275, V _a276, V _a277, V _a278, V[] _rest274) => {
JsStrBuf s_279 = null;
s_279 = new JsStrBuf(JsStrBuf.Begin().V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(22D)), ((V)("fill=\"#2d4a22\" opacity=\"0.15\"")))).S("<g class=\"ygs-pop\">").End());
Invoke(Arr(Arr(((V)((-14D))), ((V)((-2D))), ((V)("#ff9a3a")), ((V)(20D))), Arr(((V)((-2D))), ((V)((-6D))), ((V)("#ffcf3a")), ((V)((-30D)))), Arr(((V)(10D)), ((V)((-1D))), ((V)("#e8623a")), ((V)(60D))), Arr(((V)((-6D))), ((V)(2D)), ((V)("#ffb84a")), ((V)(100D))), Arr(((V)(4D)), ((V)((-10D))), ((V)("#d9482a")), ((V)((-70D)))), Arr(((V)(16D)), ((V)((-6D))), ((V)("#ffd84a")), ((V)(10D))), Arr(((V)((-18D))), ((V)((-8D))), ((V)("#e8623a")), ((V)(140D)))), "forEach", Fn((V _self1, int _argc280, V _a282, V _a283, V _a284, V _a285, V[] _rest281) => {
V x_288 = default;
V y_290 = default;
V c_292 = default;
V r_294 = default;
{ V _t286 = ListOf(_a282);
{ V _t287 = GetIdx(_t286, 0D);
x_288 = _t287; }
{ V _t289 = GetIdx(_t286, 1D);
y_290 = _t289; }
{ V _t291 = GetIdx(_t286, 2D);
c_292 = _t291; }
{ V _t293 = GetIdx(_t286, 3D);
r_294 = _t293; }
}
s_279.S("<path transform=\"translate(").V(x_288).S(" ").V(y_290).S(") rotate(").V(r_294).S(")\" d=\"M-8 0Q-3 -6 4 -5Q9 -2 8 0Q4 5 -3 4Q-7 3 -8 0Z\" fill=\"").V(c_292).S("\" stroke=\"#9a3a1a\" stroke-width=\"1\"/>");
return default;
}, 1, "", true));
return ((V)(string.Concat(s_279.Str, "</g>")));
return default;
}, 0, "leaves", true)).Put("mud", Fn((V _self1, int _argc295, V it_301, V _a298, V _a299, V _a300, V[] _rest296) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(Call(blob_35, V.Undef, Get(Get(DEF_60, "mud"), "hs"), ((V)((ToNum(Get(Get(DEF_60, "mud"), "hw")) * HW_27))), ((V)(0.18)), ((V)((ToNum(Get(it_301, "s")) % 7D))))).S("\" fill=\"#8a5a34\" stroke=\"#6e4426\" stroke-width=\"2\"/><path d=\"").V(Call(blob_35, V.Undef, ((V)((ToNum(Get(Get(DEF_60, "mud"), "hs")) * 0.55))), ((V)(((ToNum(Get(Get(DEF_60, "mud"), "hw")) * HW_27) * 0.5))), ((V)(0.25)), ((V)((ToNum(Get(it_301, "s")) % 5D))))).S("\" fill=\"#6e4426\" transform=\"translate(-6 2)\"/>").V(Call(gEl_34, V.Undef, ((V)((-18D))), ((V)((-2D))), ((V)(4D)), ((V)("fill=\"#a87a4e\"")))).V(Call(gEl_34, V.Undef, ((V)(14D)), ((V)(4D)), ((V)(3D)), ((V)("fill=\"#a87a4e\"")))).V(Call(gEl_34, V.Undef, ((V)(24D)), ((V)((-8D))), ((V)(2.4)), ((V)("fill=\"#c49a6a\"")))).End()));
}, 1, "mud", true)).Put("slick", Fn((V _self1, int _argc302, V it_308, V _a305, V _a306, V _a307, V[] _rest303) => {
return ((V)(JsStrBuf.Begin().S("<path class=\"ygs-shim\" d=\"").V(Call(blob_35, V.Undef, Get(Get(DEF_60, "slick"), "hs"), ((V)((ToNum(Get(Get(DEF_60, "slick"), "hw")) * HW_27))), ((V)(0.12)), ((V)((ToNum(Get(it_308, "s")) % 9D))))).S("\" fill=\"#8fdcff\" stroke=\"#ffffff\" stroke-width=\"2.5\"/><path d=\"M").V(Call(P2_29, V.Undef, Call(G3_30, V.Undef, ((V)((-30D))), ((V)((-6D)))))).S("L").V(Call(P2_29, V.Undef, Call(G3_30, V.Undef, ((V)(20D)), ((V)((-10D)))))).S("M").V(Call(P2_29, V.Undef, Call(G3_30, V.Undef, ((V)((-14D))), ((V)(10D))))).S("L").V(Call(P2_29, V.Undef, Call(G3_30, V.Undef, ((V)(30D)), ((V)(6D))))).S("\" stroke=\"#ffffff\" stroke-width=\"3\" stroke-linecap=\"round\" opacity=\"0.85\"/>").S("<path class=\"ygs-tw\" d=\"M0 -9C0.9 -3 3 -1 9 0C3 1 0.9 3 0 9C-0.9 3 -3 1 -9 0C-3 -1 -0.9 -3 0 -9Z\" fill=\"#ffffff\" transform=\"translate(").V(Call(P2_29, V.Undef, Call(G3_30, V.Undef, ((V)(8D)), ((V)(2D)), ((V)(6D))))).S(")\"/>").End()));
}, 1, "slick", true)).Put("gold", Fn((V _self1, int _argc309, V _a311, V _a312, V _a313, V _a314, V[] _rest310) => {
JsStrBuf s_315 = null;
s_315 = new JsStrBuf(JsStrBuf.Begin().S("<path class=\"ygs-glow\" d=\"").V(Call(poly_31, V.Undef, Arr(Call(G3_30, V.Undef, ((V)((-34D))), ((V)((-24D)))), Call(G3_30, V.Undef, ((V)(34D)), ((V)((-24D)))), Call(G3_30, V.Undef, ((V)(34D)), ((V)(24D))), Call(G3_30, V.Undef, ((V)((-34D))), ((V)(24D)))))).S("\" fill=\"#ffe36e\" stroke=\"#d79a22\" stroke-width=\"2.5\" stroke-linejoin=\"round\"/>").End());
Invoke(Arr(((V)((-18D))), ((V)(0D)), ((V)(18D))), "forEach", Fn((V _self1, int _argc316, V d_322, V _a319, V _a320, V _a321, V[] _rest317) => {
s_315.S("<path d=\"").V(Call(poly_31, V.Undef, Arr(Call(G3_30, V.Undef, ((V)((ToNum(d_322) - 9D))), ((V)((-14D)))), Call(G3_30, V.Undef, Add(d_322, ((V)(5D))), ((V)(0D))), Call(G3_30, V.Undef, ((V)((ToNum(d_322) - 9D))), ((V)(14D))), Call(G3_30, V.Undef, ((V)((ToNum(d_322) - 3D))), ((V)(14D))), Call(G3_30, V.Undef, Add(d_322, ((V)(11D))), ((V)(0D))), Call(G3_30, V.Undef, ((V)((ToNum(d_322) - 3D))), ((V)((-14D))))))).S("\" fill=\"#ff8a3d\" stroke=\"#ffffff\" stroke-width=\"1.4\" stroke-linejoin=\"round\"/>");
return default;
}, 1, "", true));
return ((V)(s_315.Str));
return default;
}, 0, "gold", true)).Put("ramp", Fn((V _self1, int _argc323, V _a325, V _a326, V _a327, V _a328, V[] _rest324) => {
double w_329 = 0;
V top_330 = default;
JsStrBuf s_331 = null;
w_329 = (0.95 * HW_27);
top_330 = Arr(Call(G3_30, V.Undef, ((V)((-30D))), ((V)((-w_329))), ((V)(0D))), Call(G3_30, V.Undef, ((V)(30D)), ((V)((-w_329))), ((V)(18D))), Call(G3_30, V.Undef, ((V)(30D)), ((V)(w_329)), ((V)(18D))), Call(G3_30, V.Undef, ((V)((-30D))), ((V)(w_329)), ((V)(0D))));
s_331 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Call(poly_31, V.Undef, Arr(Call(G3_30, V.Undef, ((V)((-30D))), ((V)((-w_329))), ((V)(0D))), Call(G3_30, V.Undef, ((V)(30D)), ((V)((-w_329))), ((V)(0D))), Call(G3_30, V.Undef, ((V)(30D)), ((V)((-w_329))), ((V)(18D)))))).S("\" fill=\"#9a6232\" stroke=\"#6b4426\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/>").S("<path d=\"").V(Call(poly_31, V.Undef, Arr(Call(G3_30, V.Undef, ((V)(30D)), ((V)((-w_329))), ((V)(0D))), Call(G3_30, V.Undef, ((V)(30D)), ((V)(w_329)), ((V)(0D))), Call(G3_30, V.Undef, ((V)(30D)), ((V)(w_329)), ((V)(18D))), Call(G3_30, V.Undef, ((V)(30D)), ((V)((-w_329))), ((V)(18D)))))).S("\" fill=\"#b47740\" stroke=\"#6b4426\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/><path d=\"").V(Call(poly_31, V.Undef, top_330)).S("\" fill=\"#e2ad74\" stroke=\"#6b4426\" stroke-width=\"1.8\" stroke-linejoin=\"round\"/>").End());
{
double i_332 = 0;
i_332 = 1D;
while (true) {
if (!((i_332 < 4D))) break;
double ds_334 = 0;
ds_334 = ((-30D) + (i_332 * 15D));
s_331.S("<path d=\"M").V(Call(P2_29, V.Undef, Call(G3_30, V.Undef, ((V)(ds_334)), ((V)((-w_329))), ((V)(((ds_334 + 30D) * 0.3)))))).S("L").V(Call(P2_29, V.Undef, Call(G3_30, V.Undef, ((V)(ds_334)), ((V)(w_329)), ((V)(((ds_334 + 30D) * 0.3)))))).S("\" stroke=\"#b47740\" stroke-width=\"1.4\"/>");
i_332++;
}
}
return ((V)(JsStrBuf.Begin().S(s_331.Str).S("<path d=\"").V(Call(poly_31, V.Undef, Arr(Call(G3_30, V.Undef, ((V)((-8D))), ((V)((-10D))), ((V)(6.6))), Call(G3_30, V.Undef, ((V)(8D)), ((V)(0D)), ((V)(11.4))), Call(G3_30, V.Undef, ((V)((-8D))), ((V)(10D)), ((V)(6.6)))))).S("\" fill=\"#ffd84a\" stroke=\"#ffffff\" stroke-width=\"1.2\"/>").End()));
return default;
}, 0, "ramp", true)).V;
tree_64 = Fn((V _self1, int _argc335, V k_341, V c1_342, V c2_343, V _a340, V[] _rest336) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((30D * ToNum(k_341)))), ((V)("fill=\"#2d4a22\" opacity=\"0.22\"")))).S("<rect x=\"").V(Call(r2_19, V.Undef, ((V)(((-5D) * ToNum(k_341)))))).S("\" y=\"").V(Call(r2_19, V.Undef, ((V)(((-38D) * ToNum(k_341)))))).S("\" width=\"").V(Call(r2_19, V.Undef, ((V)((10D * ToNum(k_341)))))).S("\" height=\"").V(Call(r2_19, V.Undef, ((V)((40D * ToNum(k_341)))))).S("\" rx=\"3\" fill=\"#8a5a34\"/>").V(Invoke(Invoke(Arr(Arr(((V)((-17D))), ((V)((-48D))), ((V)(21D))), Arr(((V)(15D)), ((V)((-50D))), ((V)(23D))), Arr(((V)(0D)), ((V)((-70D))), ((V)(25D))), Arr(((V)((-4D))), ((V)((-46D))), ((V)(18D)))), "map", Fn((V _self1, int _argc344, V _a346, V _a347, V _a348, V _a349, V[] _rest345) => {
V x_352 = default;
V y_354 = default;
V r_356 = default;
{ V _t350 = ListOf(_a346);
{ V _t351 = GetIdx(_t350, 0D);
x_352 = _t351; }
{ V _t353 = GetIdx(_t350, 1D);
y_354 = _t353; }
{ V _t355 = GetIdx(_t350, 2D);
r_356 = _t355; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(x_352) * ToNum(k_341)))))).S("\" cy=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(y_354) * ToNum(k_341)))))).S("\" r=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(r_356) * ToNum(k_341)))))).S("\" fill=\"").V(c1_342).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<circle cx=\"").V(Call(r2_19, V.Undef, ((V)(((-7D) * ToNum(k_341)))))).S("\" cy=\"").V(Call(r2_19, V.Undef, ((V)(((-76D) * ToNum(k_341)))))).S("\" r=\"").V(Call(r2_19, V.Undef, ((V)((10D * ToNum(k_341)))))).S("\" fill=\"").V(c2_343).S("\" opacity=\"0.9\"/><circle cx=\"").V(Call(r2_19, V.Undef, ((V)((12D * ToNum(k_341)))))).S("\" cy=\"").V(Call(r2_19, V.Undef, ((V)(((-56D) * ToNum(k_341)))))).S("\" r=\"").V(Call(r2_19, V.Undef, ((V)((7D * ToNum(k_341)))))).S("\" fill=\"").V(c2_343).S("\" opacity=\"0.7\"/>").End()));
}, 3, "", true);
bush_65 = Fn((V _self1, int _argc357, V k_363, V c_364, V _a361, V _a362, V[] _rest358) => {
return ((V)(JsStrBuf.Begin().V(Add(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((20D * ToNum(k_363)))), ((V)("fill=\"#2d4a22\" opacity=\"0.2\""))), Invoke(Invoke(Arr(Arr(((V)((-11D))), ((V)((-9D))), ((V)(11D))), Arr(((V)(9D)), ((V)((-10D))), ((V)(12D))), Arr(((V)(0D)), ((V)((-18D))), ((V)(13D)))), "map", Fn((V _self1, int _argc365, V _a367, V _a368, V _a369, V _a370, V[] _rest366) => {
V x_373 = default;
V y_375 = default;
V r_377 = default;
{ V _t371 = ListOf(_a367);
{ V _t372 = GetIdx(_t371, 0D);
x_373 = _t372; }
{ V _t374 = GetIdx(_t371, 1D);
y_375 = _t374; }
{ V _t376 = GetIdx(_t371, 2D);
r_377 = _t376; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(x_373) * ToNum(k_363)))))).S("\" cy=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(y_375) * ToNum(k_363)))))).S("\" r=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(r_377) * ToNum(k_363)))))).S("\" fill=\"#57a854\"/>").End()));
}, 1, "", true)), "join", ((V)(""))))).S("<circle cx=\"").V(Call(r2_19, V.Undef, ((V)(((-3D) * ToNum(k_363)))))).S("\" cy=\"").V(Call(r2_19, V.Undef, ((V)(((-22D) * ToNum(k_363)))))).S("\" r=\"").V(Call(r2_19, V.Undef, ((V)((5D * ToNum(k_363)))))).S("\" fill=\"#7cc46a\"/>").V((Truthy(c_364) ? Invoke(Invoke(Arr(Arr(((V)((-8D))), ((V)((-14D)))), Arr(((V)(8D)), ((V)((-18D)))), Arr(((V)(2D)), ((V)((-8D))))), "map", Fn((V _self1, int _argc378, V _a380, V _a381, V _a382, V _a383, V[] _rest379) => {
V x_386 = default;
V y_388 = default;
{ V _t384 = ListOf(_a380);
{ V _t385 = GetIdx(_t384, 0D);
x_386 = _t385; }
{ V _t387 = GetIdx(_t384, 1D);
y_388 = _t387; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(x_386) * ToNum(k_363)))))).S("\" cy=\"").V(Call(r2_19, V.Undef, ((V)((ToNum(y_388) * ToNum(k_363)))))).S("\" r=\"").V(Call(r2_19, V.Undef, ((V)((2.6 * ToNum(k_363)))))).S("\" fill=\"").V(c_364).S("\"/>").End()));
}, 1, "", true)), "join", ((V)(""))) : ((V)("")))).End()));
}, 2, "", true);
flowers_66 = Fn((V _self1, int _argc389, V sd_395, V _a392, V _a393, V _a394, V[] _rest390) => {
V R_396 = default;
JsStrBuf s_397 = null;
R_396 = Call(rnd_36, V.Undef, sd_395);
s_397 = new JsStrBuf("");
{
double i_398 = 0;
i_398 = 0D;
while (true) {
if (!((i_398 < 5D))) break;
double x_400 = 0;
double y_401 = 0;
double h_402 = 0;
V c_403 = default;
x_400 = ((ToNum(Call(R_396, V.Undef)) - 0.5) * 30D);
y_401 = ((ToNum(Call(R_396, V.Undef)) - 0.5) * 10D);
h_402 = (8D + (ToNum(Call(R_396, V.Undef)) * 8D));
c_403 = GetIdx(Arr(((V)("#ff8fc8")), ((V)("#fff3a8")), ((V)("#ffffff")), ((V)("#d9c8ff")), ((V)("#ffb0a0"))), (i_398 % 5D));
s_397.S("<path d=\"M").V(Call(r2_19, V.Undef, ((V)(x_400)))).S(" ").V(Call(r2_19, V.Undef, ((V)(y_401)))).S("V").V(Call(r2_19, V.Undef, ((V)((y_401 - h_402))))).S("\" stroke=\"#4f9a3e\" stroke-width=\"1.6\"/>");
{
double j_404 = 0;
j_404 = 0D;
while (true) {
if (!((j_404 < 5D))) break;
s_397.S("<circle cx=\"").V(Call(r2_19, V.Undef, ((V)((x_400 + (FdLibm.Cos((j_404 * 1.2566)) * 2.8)))))).S("\" cy=\"").V(Call(r2_19, V.Undef, ((V)(((y_401 - h_402) + (FdLibm.Sin((j_404 * 1.2566)) * 2.8)))))).S("\" r=\"2.2\" fill=\"").V(c_403).S("\"/>");
j_404++;
}
}
s_397.S("<circle cx=\"").V(Call(r2_19, V.Undef, ((V)(x_400)))).S("\" cy=\"").V(Call(r2_19, V.Undef, ((V)((y_401 - h_402))))).S("\" r=\"1.5\" fill=\"#ffb84a\"/>");
i_398++;
}
}
return ((V)(s_397.Str));
return default;
}, 1, "", true);
pinwheel_67 = Fn((V _self1, int _argc406, V c_412, V _a409, V _a410, V _a411, V[] _rest407) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0V-40\" stroke=\"#e8e0d4\" stroke-width=\"2.6\" stroke-linecap=\"round\"/><g transform=\"translate(0 -40)\"><g class=\"ygs-spin\">").V(Invoke(Invoke(Arr(((V)(0D)), ((V)(90D)), ((V)(180D)), ((V)(270D))), "map", Fn((V _self1, int _argc413, V a_419, V i_420, V _a417, V _a418, V[] _rest414) => {
return ((V)(JsStrBuf.Begin().S("<path transform=\"rotate(").V(a_419).S(")\" d=\"M0 0L0 -12L9 -9Z\" fill=\"").V(GetK(Arr(c_412, ((V)("#ffffff")), c_412, ((V)("#ffd84a"))), i_420)).S("\" stroke=\"#4a3a2e\" stroke-width=\"0.8\"/>").End()));
}, 2, "", true)), "join", ((V)("")))).S("</g><circle r=\"1.8\" fill=\"#ffd84a\"/></g>").End()));
}, 1, "", true);
sprinkler_68 = Fn((V _self1, int _argc421, V _a423, V _a424, V _a425, V _a426, V[] _rest422) => {
return ((V)("<ellipse cy=\"1\" rx=\"8\" ry=\"3\" fill=\"#2d4a22\" opacity=\"0.25\"/><path d=\"M-3 0V-10H3V0Z\" fill=\"#9aa0a8\"/><circle cy=\"-11\" r=\"3.4\" fill=\"#5cb8ff\"/><path class=\"ygs-spr\" d=\"M0 -12Q-26 -60 -58 -14\" stroke=\"#bfe8ff\" stroke-width=\"3.4\" fill=\"none\" stroke-linecap=\"round\" stroke-dasharray=\"6 9\"/><path class=\"ygs-spr\" d=\"M0 -12Q22 -52 50 -18\" stroke=\"#dff4ff\" stroke-width=\"2.6\" fill=\"none\" stroke-linecap=\"round\" stroke-dasharray=\"5 10\"/>"));
}, 0, "", true);
birdhouse_69 = Fn((V _self1, int _argc427, V _a429, V _a430, V _a431, V _a432, V[] _rest428) => {
return ((V)("<path d=\"M0 0V-46\" stroke=\"#a46c3a\" stroke-width=\"4\"/><path d=\"M-10 -46V-62H10V-46Z\" fill=\"#ffb0a0\" stroke=\"#b05a4a\" stroke-width=\"1.4\"/><path d=\"M-13 -60L0 -72L13 -60Z\" fill=\"#7a5ad0\" stroke=\"#4a2e8a\" stroke-width=\"1.4\" stroke-linejoin=\"round\"/><circle cy=\"-54\" r=\"3\" fill=\"#5a3a2a\"/>"));
}, 0, "", true);
shed_70 = Fn((V _self1, int _argc433, V _a435, V _a436, V _a437, V _a438, V[] _rest434) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(46D)), ((V)("fill=\"#2d4a22\" opacity=\"0.2\"")))).S("<path d=\"M-34 0V-38H22V0Z\" fill=\"#ffd2a0\" stroke=\"#b07a46\" stroke-width=\"2\"/><path d=\"M22 0V-38L40 -48V-10Z\" fill=\"#e8b67c\" stroke=\"#b07a46\" stroke-width=\"2\" stroke-linejoin=\"round\"/><path d=\"M-40 -36L-6 -62L28 -36Z\" fill=\"#e06a5a\" stroke=\"#9a3a2e\" stroke-width=\"2\" stroke-linejoin=\"round\"/><path d=\"M28 -36L-6 -62L12 -72L46 -46Z\" fill=\"#c85848\" stroke=\"#9a3a2e\" stroke-width=\"2\" stroke-linejoin=\"round\"/>").S("<rect x=\"-14\" y=\"-26\" width=\"14\" height=\"26\" rx=\"2\" fill=\"#a46c3a\"/><rect x=\"4\" y=\"-30\" width=\"12\" height=\"10\" rx=\"2\" fill=\"#bfe8ff\" stroke=\"#ffffff\" stroke-width=\"2\"/>").End()));
}, 0, "", true);
haystack_71 = Fn((V _self1, int _argc439, V _a441, V _a442, V _a443, V _a444, V[] _rest440) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(26D)), ((V)("fill=\"#2d4a22\" opacity=\"0.2\"")))).S("<path d=\"M-26 0C-26 -22 -12 -40 0 -40C12 -40 26 -22 26 0Z\" fill=\"#f2cf6a\" stroke=\"#b88a2a\" stroke-width=\"1.8\"/><path d=\"M-14 -10l6 -12M2 -6l3 -16M14 -12l-4 -10M-4 -26l2 -8\" stroke=\"#c99a36\" stroke-width=\"1.6\" stroke-linecap=\"round\"/>").End()));
}, 0, "", true);
sunflower_72 = Fn((V _self1, int _argc445, V _a447, V _a448, V _a449, V _a450, V[] _rest446) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0V-48\" stroke=\"#4f9a3e\" stroke-width=\"2.6\"/><path d=\"M0 -20Q8 -26 12 -20Q6 -16 0 -20Z\" fill=\"#57a854\"/>").V(Invoke(Invoke(new ArrBuilder().Spread(Call(G("Array"), V.Undef, ((V)(10D)))).V, "map", Fn((V _self1, int _argc451, V __457, V i_458, V _a455, V _a456, V[] _rest452) => {
return ((V)(JsStrBuf.Begin().S("<ellipse transform=\"translate(0 -52) rotate(").N((ToNum(i_458) * 36D)).S(")\" cy=\"-8\" rx=\"3.4\" ry=\"6\" fill=\"#ffd84a\"/>").End()));
}, 2, "", true)), "join", ((V)("")))).S("<circle cy=\"-52\" r=\"6\" fill=\"#8a5a34\"/>").End()));
}, 0, "", true);
lounger_73 = Fn((V _self1, int _argc459, V _a461, V _a462, V _a463, V _a464, V[] _rest460) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_34, V.Undef, ((V)(10D)), ((V)(4D)), ((V)(34D)), ((V)("fill=\"#2d4a22\" opacity=\"0.18\"")))).S("<path d=\"M-28 0V-8M28 0V-8M-28 -8H14L30 -30\" stroke=\"#e8e0d4\" stroke-width=\"3\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"M-26 -12H14L28 -32\" stroke=\"#5cb8ff\" stroke-width=\"7\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"M-20 -12H8\" stroke=\"#ffffff\" stroke-width=\"2\" stroke-dasharray=\"4 4\"/>").End()));
}, 0, "", true);
umbrella_74 = Fn((V _self1, int _argc465, V _a467, V _a468, V _a469, V _a470, V[] _rest466) => {
return ((V)("<path d=\"M0 0V-70\" stroke=\"#e8e0d4\" stroke-width=\"3\"/><path d=\"M-40 -62Q0 -96 40 -62Q30 -66 20 -62Q10 -66 0 -62Q-10 -66 -20 -62Q-30 -66 -40 -62Z\" fill=\"#ff7a8a\" stroke=\"#c8485a\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/><path d=\"M-20 -62Q-12 -84 0 -88M20 -62Q12 -84 0 -88\" stroke=\"#ffffff\" stroke-width=\"5\" fill=\"none\" opacity=\"0.85\"/>"));
}, 0, "", true);
ball_75 = Fn((V _self1, int _argc471, V _a473, V _a474, V _a475, V _a476, V[] _rest472) => {
return ((V)(JsStrBuf.Begin().S("<g class=\"ygs-bob\">").V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(11D)), ((V)("fill=\"#2d4a22\" opacity=\"0.18\"")))).S("<circle cy=\"-11\" r=\"11\" fill=\"#ffffff\" stroke=\"#c8c0b4\" stroke-width=\"1.4\"/><path d=\"M0 -22A11 11 0 0 1 11 -11L0 -11Z\" fill=\"#ff7a8a\"/><path d=\"M0 0A11 11 0 0 1 -11 -11L0 -11Z\" fill=\"#5cb8ff\"/><path d=\"M-11 -11A11 11 0 0 1 0 -22L0 -11Z\" fill=\"#ffd84a\"/><circle cx=\"-4\" cy=\"-15\" r=\"3\" fill=\"#ffffff\" opacity=\"0.7\"/></g>").End()));
}, 0, "", true);
donut_76 = Fn((V _self1, int _argc477, V _a479, V _a480, V _a481, V _a482, V[] _rest478) => {
return ((V)(JsStrBuf.Begin().S("<g class=\"ygs-bob\">").V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(26D)), ((V)("fill=\"#ff8fc8\" stroke=\"#d05a98\" stroke-width=\"2\"")))).V(Call(gEl_34, V.Undef, ((V)(0D)), ((V)((-1D))), ((V)(11D)), ((V)("fill=\"#4fb4ec\"")))).V(Call(gEl_34, V.Undef, ((V)((-6D))), ((V)((-6D))), ((V)(8D)), ((V)("fill=\"#ffffff\" opacity=\"0.4\"")))).S("</g>").End()));
}, 0, "", true);
fence_77 = Fn((V _self1, int _argc483, V len_489, V _a486, V _a487, V _a488, V[] _rest484) => {
V s_490 = default;
V a_491 = default;
V b_492 = default;
V a2_493 = default;
V b2_494 = default;
s_490 = Call(gEl_34, V.Undef, ((V)((ToNum(len_489) / 2D))), ((V)(3D)), ((V)((ToNum(len_489) * 0.42))), ((V)("fill=\"#2d4a22\" opacity=\"0.12\"")));
a_491 = Call(G3_30, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(9D)));
b_492 = Call(G3_30, V.Undef, len_489, ((V)(0D)), ((V)(9D)));
a2_493 = Call(G3_30, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(18D)));
b2_494 = Call(G3_30, V.Undef, len_489, ((V)(0D)), ((V)(18D)));
s_490 = ((V)(JsStrBuf.Begin().V(s_490).S("<path d=\"M").V(Call(P2_29, V.Undef, a_491)).S("L").V(Call(P2_29, V.Undef, b_492)).S("M").V(Call(P2_29, V.Undef, a2_493)).S("L").V(Call(P2_29, V.Undef, b2_494)).S("\" stroke=\"#e8dccb\" stroke-width=\"4\" stroke-linecap=\"round\"/>").End()));
{
double d_495 = 0;
d_495 = 0D;
while (true) {
if (!(Le(((V)(d_495)), len_489))) break;
V q_497 = default;
q_497 = Call(G3_30, V.Undef, ((V)(d_495)), ((V)(0D)), ((V)(0D)));
s_490 = ((V)(JsStrBuf.Begin().V(s_490).S("<path d=\"M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(q_497, 0D)) - 3D))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(q_497, 1D))).S("V").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(q_497, 1D)) - 22D))))).S("L").V(Call(r2_19, V.Undef, GetIdx(q_497, 0D))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(q_497, 1D)) - 26D))))).S("L").V(Call(r2_19, V.Undef, Add(GetIdx(q_497, 0D), ((V)(3D))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(q_497, 1D)) - 22D))))).S("V").V(Call(r2_19, V.Undef, GetIdx(q_497, 1D))).S("Z\" fill=\"#fffaf2\" stroke=\"#d8c9b0\" stroke-width=\"1\"/>").End()));
d_495 = (d_495 + 14D);
}
}
return s_490;
return default;
}, 1, "", true);
bed_78 = Fn((V _self1, int _argc498, V sd_504, V _a501, V _a502, V _a503, V[] _rest499) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(Call(blob_35, V.Undef, ((V)(46D)), ((V)(22D)), ((V)(0.12)), sd_504)).S("\" fill=\"#a8754a\" stroke=\"#8a5a34\" stroke-width=\"2\"/>").V(Call(flowers_66, V.Undef, sd_504)).End()));
}, 1, "", true);
Invoke(YG_15, "add", NewObj(12).Put("id", ((V)("slide"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Slide & Splash"))).Put("item", ((V)("Slides"))).Put("color", ((V)("#3fd0c0"))).Put("icon", ICON_62).Put("stars", Arr(((V)(550D)), ((V)(750D)), ((V)(950D)))).Put("coinK", ((V)(0.08))).Put("hint", ((V)("Drag up or down to switch sides \u00b7 grab splash slicks + gold arrows \u00b7 dodge the rest"))).Put("how", Arr(((V)("Slide down the big backyard slide: drag up or down (or use the arrow keys) to switch sides.")), ((V)("Splash slicks and gold arrows speed you up. Rocks, gnomes, hay, mud and sand slow you down. Wooden bumps hop you over logs.")), ((V)("At the end you fly off into the kiddie pool: the faster you go, the bigger the splash - your friends get soaked!")))).Put("options", Arr(NewObj(2).Put("id", ((V)("rainbow"))).Put("label", ((V)("Rainbow"))).V, NewObj(2).Put("id", ((V)("gold"))).Put("label", ((V)("Gold"))).V, NewObj(2).Put("id", ((V)("wood"))).Put("label", ((V)("Wooden"))).V)).Put("make", Fn((V _self505, int _argc506, V ctx_512, V _a509, V _a510, V _a511, V[] _rest507) => {
V bg_513 = default;
V fg_514 = default;
V W_515 = default;
V H_516 = default;
V look_517 = default;
V slideBg_518 = default;
V wB_519 = default;
V gStart_520 = default;
V gGround_521 = default;
V gEnd_522 = default;
V gDecal_523 = default;
V gShadow_524 = default;
V gBack_525 = default;
V scB_526 = default;
V wF_527 = default;
V gStartF_528 = default;
V gNear_529 = default;
V gEndF_530 = default;
V gFront_531 = default;
V scF_532 = default;
V speedL_533 = default;
V hud_534 = default;
V meSh_535 = default;
V stands_536 = default;
V riderD_537 = default;
V sortIn_538 = default;
V addStand_539 = default;
V dropStand_540 = default;
V chunks_541 = default;
V Lp_542 = default;
V post_543 = default;
V surface_544 = default;
V farSide_545 = default;
V farWall_546 = default;
V nearSide_547 = default;
V buildChunk_548 = default;
V dropChunk_549 = default;
V ensure_550 = default;
V buildStatic_551 = default;
V items_552 = default;
double nextI_553 = 0;
V alive_554 = default;
V gen_555 = default;
V spawn_556 = default;
V despawn_557 = default;
V feed_558 = default;
V sp_559 = default;
V ARC_560 = default;
double arcL_561 = 0;
V spArc_562 = default;
V spTx_563 = default;
V tierG_564 = default;
V tierR_565 = default;
V tierTx_566 = default;
V pg_567 = default;
V pgF_568 = default;
V pgD_569 = default;
V lines_570 = default;
V flash_571 = default;
V AU_572 = default;
V windOn_573 = default;
V windSet_574 = default;
V windOff_575 = default;
V me_576 = default;
V C0_577 = default;
V C1_578 = default;
double Z0_579 = 0;
V tNow_580 = default;
V friends_581 = default;
V pool_582 = default;
V st_583 = default;
V scr_584 = default;
V reset_585 = default;
V drag_586 = default;
V api_587 = default;
V botSteer_588 = default;
V hits_589 = default;
V launch_590 = default;
V transition_591 = default;
V poolScene_592 = default;
V camera_593 = default;
V place_594 = default;
V hud__595 = default;
if (_self505.IsNullish) _self505 = GlobalV;
sortIn_538 = Fn((V _self596, int _argc597, V o_603, V fr_604, V _a601, V _a602, V[] _rest598) => {
V par_605 = default;
V @ref_606 = default;
if (_self596.IsNullish) _self596 = GlobalV;
par_605 = (Truthy(fr_604) ? gFront_531 : gBack_525);
@ref_606 = V.Null;
{
V c_607 = default;
c_607 = Get(par_605, "firstChild");
while (true) {
if (!(Truthy(c_607))) break;
if (Gt(Get(c_607, "_d"), Get(o_603, "d"))) {
@ref_606 = c_607;
break;
}
c_607 = Get(c_607, "nextSibling");
}
}
Set(Get(o_603, "el"), "_d", Get(o_603, "d"));
Invoke(par_605, "insertBefore", Get(o_603, "el"), @ref_606);
Set(o_603, "fr", fr_604);
return default;
}, 2, "sortIn", false);
addStand_539 = Fn((V _self609, int _argc610, V html_616, V s_617, V l_618, V h_619, V[] _rest611) => {
V el_620 = default;
V o_621 = default;
if (_self609.IsNullish) _self609 = GlobalV;
el_620 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, s_617, l_618, (h_619 is var _t622 && Truthy(_t622) ? _t622 : ((V)(0D)))))).S(")").End()))).V);
Set(el_620, "innerHTML", html_616);
o_621 = NewObj(3).Put("el", el_620).Put("d", GetIdx(Call(Wp_28, V.Undef, s_617, l_618, ((V)(0D))), 1D)).Put("fr", V.Null).V;
Invoke(stands_536, "push", o_621);
Call(sortIn_538, V.Undef, o_621, (Gt(Get(o_621, "d"), riderD_537) ? V.True : V.False));
return o_621;
return default;
}, 4, "addStand", false);
dropStand_540 = Fn((V _self623, int _argc624, V o_630, V _a627, V _a628, V _a629, V[] _rest625) => {
V i_631 = default;
if (_self623.IsNullish) _self623 = GlobalV;
Invoke(Get(o_630, "el"), "remove");
i_631 = Invoke(stands_536, "indexOf", o_630);
if (GeN(i_631, 0D)) {
Invoke(stands_536, "splice", i_631, ((V)(1D)));
}
return default;
}, 1, "dropStand", false);
surface_544 = Fn((V _self632, int _argc633, V a_639, V b_640, V _a637, V _a638, V[] _rest634) => {
V L_641 = default;
JsStrBuf d_642 = null;
V R_643 = default;
if (_self632.IsNullish) _self632 = GlobalV;
L_641 = GetK(LOOK_61, look_517);
d_642 = new JsStrBuf("");
if (Le(b_640, a_639)) {
return ((V)(d_642.Str));
}
if (Truthy(Get(L_641, "bands"))) {
V n_644 = default;
n_644 = Get(Get(L_641, "bands"), "length");
Invoke(Get(L_641, "bands"), "forEach", Fn((V _self632, int _argc645, V c_651, V i_652, V _a649, V _a650, V[] _rest646) => {
d_642.S("<path d=\"").V(Call(quad_32, V.Undef, a_639, b_640, ((V)(((-1D) + ((2D * ToNum(i_652)) / ToNum(n_644))))), ((V)(((-1D) + ((2D * ToNum(Add(i_652, ((V)(1D))))) / ToNum(n_644))))), ((V)(SH_47)))).S("\" fill=\"").V(c_651).S("\" stroke=\"").V(c_651).S("\" stroke-width=\"0.7\"/>");
return default;
}, 2, "", true));
} else {
{
double s_653 = 0;
s_653 = (System.Math.Floor((ToNum(a_639) / 36D)) * 36D);
while (true) {
if (!(Lt(((V)(s_653)), b_640))) break;
double x0_655 = 0;
double x1_656 = 0;
x0_655 = Max(s_653, ToNum(a_639));
x1_656 = Min((s_653 + 36D), ToNum(b_640));
d_642.S("<path d=\"").V(Call(quad_32, V.Undef, ((V)(x0_655)), ((V)(x1_656)), ((V)((-1D))), ((V)(1D)), ((V)(SH_47)))).S("\" fill=\"").V(GetIdx(Get(L_641, "planks"), ((double)(ToInt32(Round((s_653 / 36D))) & ToInt32(1D))))).S("\" stroke=\"").V(Get(L_641, "seam")).S("\" stroke-width=\"1\"/>");
s_653 = (s_653 + 36D);
}
}
}
{
double s_657 = 0;
s_657 = (System.Math.Ceiling((ToNum(a_639) / 50D)) * 50D);
while (true) {
if (!(Lt(((V)(s_657)), b_640))) break;
V seam_659 = default;
seam_659 = (((s_657 % 150D) == 0D) ? V.True : V.False);
d_642.S("<path d=\"M").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, ((V)(s_657)), ((V)((-1D))), ((V)(SH_47))))).S("L").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, ((V)(s_657)), ((V)(1D)), ((V)(SH_47))))).S("\" stroke=\"").V(Get(L_641, "seam")).S("\" stroke-width=\"").N((Truthy(seam_659) ? 2.6 : 1.3)).S("\" opacity=\"").N((Truthy(seam_659) ? 0.6 : 0.35)).S("\"/>");
s_657 = (s_657 + 50D);
}
}
R_643 = Call(rnd_36, V.Undef, ((V)((Round(ToNum(a_639)) + 7D))));
{
double k_660 = 0;
k_660 = 0D;
while (true) {
if (!((k_660 < 4D))) break;
V s_662 = default;
double l_663 = 0;
s_662 = Add(a_639, ((V)((ToNum(Call(R_643, V.Undef)) * (ToNum(b_640) - ToNum(a_639))))));
l_663 = ((-0.8) + (ToNum(Call(R_643, V.Undef)) * 1.6));
if (Lt(Add(s_662, ((V)(40D))), b_640)) {
d_642.S("<path d=\"M").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, s_662, ((V)(l_663)), ((V)(SH_47))))).S("L").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, Add(Add(s_662, ((V)(26D))), ((V)((ToNum(Call(R_643, V.Undef)) * 20D)))), ((V)(l_663)), ((V)(SH_47))))).S("\" stroke=\"").V(Get(L_641, "shine")).S("\" stroke-width=\"2\" stroke-linecap=\"round\" opacity=\"0.5\"/>");
}
k_660++;
}
}
return ((V)(d_642.Str));
return default;
}, 2, "surface", false);
farSide_545 = Fn((V _self664, int _argc665, V a_671, V b_672, V _a669, V _a670, V[] _rest666) => {
V L_673 = default;
JsStrBuf d_674 = null;
if (_self664.IsNullish) _self664 = GlobalV;
L_673 = GetK(LOOK_61, look_517);
d_674 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Call(quad_32, V.Undef, a_671, b_672, ((V)((-1.1))), ((V)(1.1)), ((V)(0D)))).S("\" fill=\"#2a3a20\" opacity=\"0.14\"/>").End());
{
double x_675 = 0;
x_675 = (System.Math.Ceiling((ToNum(a_671) / 70D)) * 70D);
while (true) {
if (!(Lt(((V)(x_675)), b_672))) break;
d_674.V(Call(post_543, V.Undef, L_673, ((V)(x_675)), ((V)(1.06)), ((V)(0D)), ((V)((SH_47 - 6D))), ((V)(5D))));
if (((((x_675 / 70D) % 2D) == 0D) && ((x_675 + 70D) <= RS_45))) {
d_674.S("<path d=\"M").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, ((V)(x_675)), ((V)(1.06)), ((V)(6D))))).S("L").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, ((V)((x_675 + 70D))), ((V)(1.06)), ((V)((SH_47 - 12D)))))).S("\" stroke=\"").V(Get(L_673, "postD")).S("\" stroke-width=\"2.6\" opacity=\"0.7\"/>");
}
x_675 = (x_675 + 70D);
}
}
return ((V)(d_674.Str));
return default;
}, 2, "farSide", false);
nearSide_547 = Fn((V _self677, int _argc678, V a_684, V b_685, V _a682, V _a683, V[] _rest679) => {
V L_686 = default;
JsStrBuf d_687 = null;
if (_self677.IsNullish) _self677 = GlobalV;
L_686 = GetK(LOOK_61, look_517);
d_687 = new JsStrBuf("");
{
double x_688 = 0;
x_688 = (System.Math.Ceiling((ToNum(a_684) / 70D)) * 70D);
while (true) {
if (!(Lt(((V)(x_688)), b_685))) break;
d_687.V(Call(post_543, V.Undef, L_686, ((V)(x_688)), ((V)((-1.06))), ((V)(0D)), ((V)((SH_47 - 6D))), ((V)(5D))));
x_688 = (x_688 + 70D);
}
}
return ((V)(JsStrBuf.Begin().S(d_687.Str).S("<path d=\"").V(Call(poly_31, V.Undef, Arr(Call(Wp_28, V.Undef, a_684, ((V)((-1.12))), ((V)((SH_47 - 9D)))), Call(Wp_28, V.Undef, b_685, ((V)((-1.12))), ((V)((SH_47 - 9D)))), Call(Wp_28, V.Undef, b_685, ((V)((-1.12))), ((V)((SH_47 + WH_48)))), Call(Wp_28, V.Undef, a_684, ((V)((-1.12))), ((V)((SH_47 + WH_48))))))).S("\" fill=\"").V(Get(L_686, "side")).S("\"/><path d=\"").V(Call(quad_32, V.Undef, a_684, b_685, ((V)((-1.12))), ((V)((-1D))), ((V)((SH_47 + WH_48))))).S("\" fill=\"").V(Get(L_686, "top")).S("\" stroke=\"").V(Get(L_686, "side")).S("\" stroke-width=\"1\"/>").S("<path d=\"M").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, a_684, ((V)((-1.12))), ((V)((SH_47 - 9D)))))).S("L").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, b_685, ((V)((-1.12))), ((V)((SH_47 - 9D)))))).S("\" stroke=\"#000\" stroke-opacity=\"0.15\" stroke-width=\"2\"/>").End()));
return default;
}, 2, "nearSide", false);
buildChunk_548 = Fn((V _self690, int _argc691, V i_697, V _a694, V _a695, V _a696, V[] _rest692) => {
double s0_698 = 0;
double s1_699 = 0;
V R_700 = default;
V sec_701 = default;
JsStrBuf d_702 = null;
JsStrBuf dn_703 = null;
V clear_704 = default;
V g_705 = default;
V @ref_706 = default;
V gn_707 = default;
V st_708 = default;
double n_709 = 0;
if (_self690.IsNullish) _self690 = GlobalV;
s0_698 = (ToNum(i_697) * CS_43);
s1_699 = (s0_698 + CS_43);
R_700 = Call(rnd_36, V.Undef, ((V)((1000D + (ToNum(i_697) * 37D)))));
sec_701 = Call(secAt_56, V.Undef, ((V)(s0_698)));
d_702 = new JsStrBuf("");
dn_703 = new JsStrBuf("");
clear_704 = Fn((V _self690, int _argc710, V s_716, V lp_717, V _a714, V _a715, V[] _rest711) => {
return ((((LtN(s_716, 60D) && GtN(s_716, (T0_52 - 170D))) && GtN(lp_717, (-170D))) && LtN(lp_717, 120D)) ? V.True : V.False);
}, 2, "", true);
{
double k_718 = 0;
k_718 = 0D;
while (true) {
if (!((k_718 < 4D))) break;
double s_720 = 0;
double lp_721 = 0;
s_720 = (s0_698 + (ToNum(Call(R_700, V.Undef)) * CS_43));
lp_721 = ((k_718 > 1D) ? ((-90D) - (ToNum(Call(R_700, V.Undef)) * 230D)) : (90D + (ToNum(Call(R_700, V.Undef)) * 380D)));
if (Truthy(Call(clear_704, V.Undef, ((V)(s_720)), ((V)(lp_721))))) {
goto _cont719;
}
d_702.S("<path d=\"").V(Call(blob_35, V.Undef, ((V)((60D + (ToNum(Call(R_700, V.Undef)) * 60D)))), ((V)((30D + (ToNum(Call(R_700, V.Undef)) * 30D)))), ((V)(0.15)), Add(((V)(k_718)), i_697))).S("\" transform=\"translate(").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, ((V)(s_720)), Call(Lp_542, V.Undef, ((V)(lp_721))), ((V)(0D))))).S(")\" fill=\"").S((NumTruthy(((double)(ToInt32(k_718) & ToInt32(1D)))) ? "#86cc66" : "#6cb551")).S("\" opacity=\"0.55\"/>");
_cont719: ;
k_718++;
}
}
{
double k_722 = 0;
k_722 = 0D;
while (true) {
if (!((k_722 < 26D))) break;
double s_724 = 0;
double lp_725 = 0;
V p_726 = default;
double q_727 = 0;
s_724 = (s0_698 + (ToNum(Call(R_700, V.Undef)) * CS_43));
lp_725 = ((k_722 < 11D) ? ((-75D) - (ToNum(Call(R_700, V.Undef)) * 260D)) : (75D + (ToNum(Call(R_700, V.Undef)) * 420D)));
p_726 = Call(Wp_28, V.Undef, ((V)(s_724)), Call(Lp_542, V.Undef, ((V)(lp_725))), ((V)(0D)));
q_727 = (0.8 + (ToNum(Call(R_700, V.Undef)) * 0.5));
if (Truthy(Call(clear_704, V.Undef, ((V)(s_724)), ((V)(lp_725))))) {
goto _cont723;
}
d_702.S("<path d=\"M").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(p_726, 0D)) - (4D * q_727)))))).S(" ").V(Call(r2_19, V.Undef, GetIdx(p_726, 1D))).S("l").V(Call(r2_19, V.Undef, ((V)((2D * q_727))))).S(" ").V(Call(r2_19, V.Undef, ((V)(((-7D) * q_727))))).S("l").V(Call(r2_19, V.Undef, ((V)((2D * q_727))))).S(" ").V(Call(r2_19, V.Undef, ((V)((5D * q_727))))).S("l").V(Call(r2_19, V.Undef, ((V)((2D * q_727))))).S(" ").V(Call(r2_19, V.Undef, ((V)(((-8D) * q_727))))).S("l").V(Call(r2_19, V.Undef, ((V)((2D * q_727))))).S(" ").V(Call(r2_19, V.Undef, ((V)((8D * q_727))))).S("Z\" fill=\"#5aa946\" opacity=\"0.8\"/>");
_cont723: ;
k_722++;
}
}
{
double k_728 = 0;
k_728 = 0D;
while (true) {
if (!((k_728 < 8D))) break;
double s_730 = 0;
double lp_731 = 0;
V p_732 = default;
V c_733 = default;
s_730 = (s0_698 + (ToNum(Call(R_700, V.Undef)) * CS_43));
lp_731 = (LtN(Call(R_700, V.Undef), 0.4) ? ((-80D) - (ToNum(Call(R_700, V.Undef)) * 230D)) : (80D + (ToNum(Call(R_700, V.Undef)) * 380D)));
p_732 = Call(Wp_28, V.Undef, ((V)(s_730)), Call(Lp_542, V.Undef, ((V)(lp_731))), ((V)(0D)));
c_733 = GetIdx(Arr(((V)("#ffd1e8")), ((V)("#fff3a8")), ((V)("#ffffff")), ((V)("#d9c8ff"))), (k_728 % 4D));
if (Truthy(Call(clear_704, V.Undef, ((V)(s_730)), ((V)(lp_731))))) {
goto _cont729;
}
{
double j_734 = 0;
j_734 = 0D;
while (true) {
if (!((j_734 < 5D))) break;
d_702.S("<circle cx=\"").V(Call(r2_19, V.Undef, Add(GetIdx(p_732, 0D), ((V)((FdLibm.Cos((j_734 * 1.2566)) * 2.4)))))).S("\" cy=\"").V(Call(r2_19, V.Undef, Add(GetIdx(p_732, 1D), ((V)((FdLibm.Sin((j_734 * 1.2566)) * 2.4)))))).S("\" r=\"1.8\" fill=\"").V(c_733).S("\"/>");
j_734++;
}
}
_cont729: ;
k_728++;
}
}
if (SEqS(sec_701, "farm")) {
{
double k_736 = 0;
k_736 = 0D;
while (true) {
if (!((k_736 < 2D))) break;
double s_738 = 0;
double lp_739 = 0;
s_738 = (s0_698 + (ToNum(Call(R_700, V.Undef)) * CS_43));
lp_739 = (120D + (ToNum(Call(R_700, V.Undef)) * 200D));
d_702.S("<path d=\"").V(Call(blob_35, V.Undef, ((V)(70D)), ((V)(22D)), ((V)(0.1)), ((V)(k_736)))).S("\" transform=\"translate(").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, ((V)(s_738)), Call(Lp_542, V.Undef, ((V)(lp_739))), ((V)(0D))))).S(")\" fill=\"#c9a456\" opacity=\"0.35\"/>");
k_736++;
}
}
}
if (((s0_698 < RS_45) && (s1_699 > SD0_53))) {
double a_740 = 0;
double b_741 = 0;
a_740 = Max(s0_698, SD0_53);
b_741 = Min(s1_699, RS_45);
d_702.V(Add(Add(Call(farSide_545, V.Undef, ((V)(a_740)), ((V)(b_741))), Call(surface_544, V.Undef, ((V)(a_740)), ((V)(b_741)))), Call(farWall_546, V.Undef, ((V)(a_740)), ((V)(b_741)))));
dn_703.V(Call(nearSide_547, V.Undef, ((V)(a_740)), ((V)(b_741))));
}
g_705 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V);
Set(g_705, "innerHTML", ((V)(d_702.Str)));
Set(g_705, "_i", i_697);
@ref_706 = V.Null;
{
V c_742 = default;
c_742 = Get(gGround_521, "firstChild");
while (true) {
if (!(Truthy(c_742))) break;
if (Gt(Get(c_742, "_i"), i_697)) {
@ref_706 = c_742;
break;
}
c_742 = Get(c_742, "nextSibling");
}
}
Invoke(gGround_521, "insertBefore", g_705, @ref_706);
gn_707 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V);
Set(gn_707, "innerHTML", ((V)(dn_703.Str)));
Set(gn_707, "_i", i_697);
@ref_706 = V.Null;
{
V c_744 = default;
c_744 = Get(gNear_529, "firstChild");
while (true) {
if (!(Truthy(c_744))) break;
if (Gt(Get(c_744, "_i"), i_697)) {
@ref_706 = c_744;
break;
}
c_744 = Get(c_744, "nextSibling");
}
}
Invoke(gNear_529, "insertBefore", gn_707, @ref_706);
st_708 = Arr();
n_709 = (8D + System.Math.Floor((ToNum(Call(R_700, V.Undef)) * 4D)));
{
double k_746 = 0;
k_746 = 0D;
while (true) {
if (!((k_746 < n_709))) break;
double s_748 = 0;
V far_749 = default;
V r_750 = default;
V html_751 = default;
V lp_752 = default;
s_748 = (s0_698 + (ToNum(Call(R_700, V.Undef)) * CS_43));
far_749 = (LtN(Call(R_700, V.Undef), 0.62) ? V.True : V.False);
r_750 = Call(R_700, V.Undef);
html_751 = V.Undef;
lp_752 = V.Undef;
if (Truthy(far_749)) {
lp_752 = ((V)((95D + (ToNum(Call(R_700, V.Undef)) * 380D))));
html_751 = (SEqS(sec_701, "farm") ? (LtN(r_750, 0.4) ? Call(haystack_71, V.Undef) : (LtN(r_750, 0.75) ? Call(sunflower_72, V.Undef) : Call(tree_64, V.Undef, ((V)(0.9)), ((V)("#57a854")), ((V)("#7cc46a"))))) : (SEqS(sec_701, "sprinkle") ? (LtN(r_750, 0.45) ? Call(sprinkler_68, V.Undef) : (LtN(r_750, 0.7) ? Call(pinwheel_67, V.Undef, ((V)("#5cb8ff"))) : Call(tree_64, V.Undef, ((V)(1D)), ((V)("#4f9e45")), ((V)("#6cbb5c"))))) : (SEqS(sec_701, "garden") ? (LtN(r_750, 0.3) ? Call(birdhouse_69, V.Undef) : (LtN(r_750, 0.55) ? Call(bush_65, V.Undef, ((V)(1D)), ((V)("#ff8fc8"))) : ((LtN(r_750, 0.65) && GtN(lp_752, 200D)) ? Call(shed_70, V.Undef) : Call(tree_64, V.Undef, ((V)(1.05)), ((V)("#57a854")), ((V)("#7cc46a")))))) : (LtN(r_750, 0.5) ? Call(tree_64, V.Undef, ((V)((0.8 + (ToNum(Call(R_700, V.Undef)) * 0.4)))), ((V)("#57a854")), ((V)("#7cc46a"))) : (LtN(r_750, 0.75) ? Call(bush_65, V.Undef, ((V)(0.9)), ((V)("#fff3a8"))) : Call(pinwheel_67, V.Undef, ((V)("#ff7a8a"))))))));
} else {
lp_752 = ((V)(((-85D) - (ToNum(Call(R_700, V.Undef)) * 30D))));
html_751 = (LtN(r_750, 0.45) ? Call(flowers_66, V.Undef, ((V)(((ToNum(i_697) * 7D) + k_746)))) : (LtN(r_750, 0.55) ? ((V)(JsStrBuf.Begin().S("<g transform=\"scale(0.55)\">").V(Invoke(ART_63, "rock")).S("</g>").End())) : (LtN(r_750, 0.65) ? Call(pinwheel_67, V.Undef, GetIdx(Arr(((V)("#ff7a8a")), ((V)("#5cb8ff")), ((V)("#ffb84a"))), (k_746 % 3D))) : ((V)("")))));
if (GeN(r_750, 0.65)) {
lp_752 = ((V)(((-140D) - (ToNum(Call(R_700, V.Undef)) * 180D))));
html_751 = (GtN(r_750, 0.9) ? Call(tree_64, V.Undef, ((V)(0.8)), ((V)("#5fb04a")), ((V)("#7cc46a"))) : (GtN(r_750, 0.8) ? Call(bush_65, V.Undef, ((V)(1D)), ((V)((SEqS(sec_701, "garden") ? "#ff8fc8" : "#fff3a8")))) : (GtN(r_750, 0.72) ? Call(fence_77, V.Undef, ((V)((84D + (Round((ToNum(Call(R_700, V.Undef)) * 3D)) * 14D))))) : Call(bed_78, V.Undef, ((V)(((ToNum(i_697) * 5D) + k_746)))))));
}
}
if (Truthy((html_751 is var _t753 && !Truthy(_t753) ? _t753 : (!(Truthy(Call(clear_704, V.Undef, ((V)(s_748)), lp_752))) ? V.True : V.False)))) {
Invoke(st_708, "push", Call(addStand_539, V.Undef, html_751, ((V)(s_748)), Call(Lp_542, V.Undef, lp_752)));
}
k_746++;
}
}
Invoke(chunks_541, "set", i_697, NewObj(3).Put("g", g_705).Put("gn", gn_707).Put("st", st_708).V);
return default;
}, 1, "buildChunk", false);
dropChunk_549 = Fn((V _self754, int _argc755, V i_761, V _a758, V _a759, V _a760, V[] _rest756) => {
V c_762 = default;
if (_self754.IsNullish) _self754 = GlobalV;
c_762 = Invoke(chunks_541, "get", i_761);
if (!(Truthy(c_762))) {
return default;
}
Invoke(Get(c_762, "g"), "remove");
Invoke(Get(c_762, "gn"), "remove");
Invoke(Get(c_762, "st"), "forEach", dropStand_540);
Invoke(chunks_541, "delete", i_761);
return default;
}, 1, "dropChunk", false);
ensure_550 = Fn((V _self763, int _argc764, V sc_770, V z_771, V _a768, V _a769, V[] _rest765) => {
double a_772 = 0;
double b_773 = 0;
if (_self763.IsNullish) _self763 = GlobalV;
a_772 = System.Math.Floor(((ToNum(sc_770) - (700D / ToNum(z_771))) / CS_43));
b_773 = System.Math.Floor((ToNum(Add(sc_770, ((V)((1300D / ToNum(z_771)))))) / CS_43));
{
foreach (V _k774 in new JsIter(new ArrBuilder().Spread(Invoke(chunks_541, "keys")).V)) {
V i_775 = default;
i_775 = _k774;
if ((LtN(i_775, a_772) || GtN(i_775, b_773))) {
Call(dropChunk_549, V.Undef, i_775);
}
}
}
{
double i_776 = 0;
i_776 = a_772;
while (true) {
if (!((i_776 <= b_773))) break;
if (!(Truthy(Invoke(chunks_541, "has", ((V)(i_776)))))) {
Call(buildChunk_548, V.Undef, ((V)(i_776)));
}
i_776++;
}
}
return default;
}, 2, "ensure", false);
buildStatic_551 = Fn((V _self778, int _argc779, V _a781, V _a782, V _a783, V _a784, V[] _rest780) => {
V L_785 = default;
JsStrBuf b_786 = null;
JsStrBuf f_787 = null;
double a_788 = 0;
double z_789 = 0;
double lN_790 = 0;
double lF_791 = 0;
double RT_792 = 0;
V bar_793 = default;
V fp_794 = default;
double N_795 = 0;
V sAt_796 = default;
JsStrBuf lip_797 = null;
V edge_798 = default;
V rev_799 = default;
JsStrBuf lipB_800 = null;
V lipF_801 = default;
V lad_802 = default;
if (_self778.IsNullish) _self778 = GlobalV;
L_785 = GetK(LOOK_61, look_517);
b_786 = new JsStrBuf("");
f_787 = new JsStrBuf("");
a_788 = T0_52;
z_789 = SD0_53;
lN_790 = (-1.15);
lF_791 = 1.15;
RT_792 = (SH_47 + 56D);
bar_793 = Fn((V _self778, int _argc803, V pts_809, V w_810, V _a807, V _a808, V[] _rest804) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Invoke(Invoke(pts_809, "map", P2_29), "join", ((V)("L")))).S("\" stroke=\"").V(Get(L_785, "postD")).S("\" stroke-width=\"").V(Add(w_810, ((V)(2.4)))).S("\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"M").V(Invoke(Invoke(pts_809, "map", P2_29), "join", ((V)("L")))).S("\" stroke=\"").V(Get(L_785, "post")).S("\" stroke-width=\"").V(w_810).S("\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>").End()));
}, 2, "", true);
b_786.S("<path d=\"").V(Call(quad_32, V.Undef, ((V)((a_788 - 14D))), ((V)((z_789 + 20D))), ((V)((lN_790 - 0.15))), ((V)((lF_791 + 0.15))), ((V)(0D)))).S("\" fill=\"#2a3a20\" opacity=\"0.16\"/>").V(Call(post_543, V.Undef, L_785, ((V)(a_788)), ((V)(lF_791)), ((V)(0D)), ((V)(RT_792)), ((V)(7D)))).V(Call(post_543, V.Undef, L_785, ((V)(a_788)), ((V)(lN_790)), ((V)(0D)), ((V)(RT_792)), ((V)(7D)))).V(Call(post_543, V.Undef, L_785, ((V)(z_789)), ((V)(lF_791)), ((V)(0D)), ((V)(RT_792)), ((V)(7D))));
b_786.V(Add(Call(bar_793, V.Undef, Arr(Call(Wp_28, V.Undef, ((V)(a_788)), ((V)(lF_791)), ((V)(10D))), Call(Wp_28, V.Undef, ((V)(z_789)), ((V)(lF_791)), ((V)((SH_47 - 14D))))), ((V)(3.6))), Call(bar_793, V.Undef, Arr(Call(Wp_28, V.Undef, ((V)(a_788)), ((V)(lN_790)), ((V)(10D))), Call(Wp_28, V.Undef, ((V)(a_788)), ((V)(lF_791)), ((V)((SH_47 - 14D))))), ((V)(3.6)))));
b_786.S("<path d=\"").V(Call(quad_32, V.Undef, ((V)(a_788)), ((V)(z_789)), ((V)(lN_790)), ((V)(lF_791)), ((V)(SH_47)))).S("\" fill=\"").V(Get(L_785, "deck")).S("\" stroke=\"").V(Get(L_785, "postD")).S("\" stroke-width=\"1.5\" stroke-linejoin=\"round\"/>");
{
double s_811 = 0;
s_811 = (a_788 + 22D);
while (true) {
if (!((s_811 < (z_789 - 5D)))) break;
b_786.S("<path d=\"M").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, ((V)(s_811)), ((V)(lN_790)), ((V)(SH_47))))).S("L").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, ((V)(s_811)), ((V)(lF_791)), ((V)(SH_47))))).S("\" stroke=\"").V(Get(L_785, "postD")).S("\" stroke-width=\"1\" opacity=\"0.45\"/>");
s_811 = (s_811 + 22D);
}
}
Invoke(Arr(((V)(28D)), ((V)(54D))), "forEach", Fn((V _self778, int _argc813, V h_819, V _a816, V _a817, V _a818, V[] _rest814) => {
b_786.V(Call(bar_793, V.Undef, Arr(Call(Wp_28, V.Undef, ((V)(a_788)), ((V)(lN_790)), Add(((V)(SH_47)), h_819)), Call(Wp_28, V.Undef, ((V)(a_788)), ((V)(lF_791)), Add(((V)(SH_47)), h_819)), Call(Wp_28, V.Undef, ((V)(z_789)), ((V)(lF_791)), Add(((V)(SH_47)), h_819))), ((V)(4.4))));
return default;
}, 1, "", true));
{
double l_820 = 0;
l_820 = (lN_790 + 0.38);
while (true) {
if (!((l_820 < (lF_791 - 0.1)))) break;
b_786.V(Call(bar_793, V.Undef, Arr(Call(Wp_28, V.Undef, ((V)(a_788)), ((V)(l_820)), ((V)(SH_47))), Call(Wp_28, V.Undef, ((V)(a_788)), ((V)(l_820)), ((V)((SH_47 + 54D))))), ((V)(2.8))));
l_820 = (l_820 + 0.38);
}
}
{
double s_822 = 0;
s_822 = (a_788 + 30D);
while (true) {
if (!((s_822 < (z_789 - 8D)))) break;
b_786.V(Call(bar_793, V.Undef, Arr(Call(Wp_28, V.Undef, ((V)(s_822)), ((V)(lF_791)), ((V)(SH_47))), Call(Wp_28, V.Undef, ((V)(s_822)), ((V)(lF_791)), ((V)((SH_47 + 54D))))), ((V)(2.8))));
s_822 = (s_822 + 30D);
}
}
b_786.S("<circle cx=\"").V(Call(r2_19, V.Undef, GetIdx(Call(Wp_28, V.Undef, ((V)(z_789)), ((V)(lF_791)), ((V)((RT_792 + 3D)))), 0D))).S("\" cy=\"").V(Call(r2_19, V.Undef, GetIdx(Call(Wp_28, V.Undef, ((V)(z_789)), ((V)(lF_791)), ((V)((RT_792 + 3D)))), 1D))).S("\" r=\"5.5\" fill=\"").V((Truthy(Get(L_785, "bands")) ? GetIdx(Get(L_785, "bands"), 0D) : ((V)("#ff7a8a")))).S("\" stroke=\"").V(Get(L_785, "postD")).S("\" stroke-width=\"1.5\"/><circle cx=\"").V(Call(r2_19, V.Undef, GetIdx(Call(Wp_28, V.Undef, ((V)(a_788)), ((V)(lF_791)), ((V)((RT_792 + 3D)))), 0D))).S("\" cy=\"").V(Call(r2_19, V.Undef, GetIdx(Call(Wp_28, V.Undef, ((V)(a_788)), ((V)(lF_791)), ((V)((RT_792 + 3D)))), 1D))).S("\" r=\"5.5\" fill=\"").V((Truthy(Get(L_785, "bands")) ? GetIdx(Get(L_785, "bands"), 4D) : ((V)("#5cb8ff")))).S("\" stroke=\"").V(Get(L_785, "postD")).S("\" stroke-width=\"1.5\"/>");
fp_794 = Call(Wp_28, V.Undef, ((V)(a_788)), ((V)(lN_790)), ((V)(RT_792)));
b_786.S("<path d=\"M").V(Call(P2_29, V.Undef, fp_794)).S("V").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(fp_794, 1D)) - 30D))))).S("\" stroke=\"").V(Get(L_785, "postD")).S("\" stroke-width=\"2.2\"/><path d=\"M").V(Call(r2_19, V.Undef, GetIdx(fp_794, 0D))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(fp_794, 1D)) - 30D))))).S("l20 5.5l-20 6.5Z\" fill=\"#ff7a8a\" stroke=\"#c8485a\" stroke-width=\"1.3\" stroke-linejoin=\"round\"/>");
N_795 = 12D;
sAt_796 = Fn((V _self778, int _argc824, V j_830, V _a827, V _a828, V _a829, V[] _rest825) => {
return ((V)((RS_45 + (((LEN_44 - RS_45) * ToNum(j_830)) / N_795))));
}, 1, "", true);
lip_797 = new JsStrBuf("");
{
double j_831 = 0;
j_831 = 0D;
while (true) {
if (!((j_831 < N_795))) break;
V s0_833 = default;
V s1_834 = default;
V h0_835 = default;
V h1_836 = default;
s0_833 = Call(sAt_796, V.Undef, ((V)(j_831)));
s1_834 = Call(sAt_796, V.Undef, ((V)((j_831 + 1D))));
h0_835 = Call(HS_57, V.Undef, s0_833);
h1_836 = Call(HS_57, V.Undef, s1_834);
if (Truthy(Get(L_785, "bands"))) {
Invoke(Get(L_785, "bands"), "forEach", Fn((V _self778, int _argc837, V c_843, V i_844, V _a841, V _a842, V[] _rest838) => {
V n_845 = default;
n_845 = Get(Get(L_785, "bands"), "length");
lip_797.S("<path d=\"").V(Call(quad_32, V.Undef, s0_833, s1_834, ((V)(((-1D) + ((2D * ToNum(i_844)) / ToNum(n_845))))), ((V)(((-1D) + ((2D * ToNum(Add(i_844, ((V)(1D))))) / ToNum(n_845))))), h0_835, h1_836)).S("\" fill=\"").V(c_843).S("\" stroke=\"").V(c_843).S("\" stroke-width=\"0.8\"/>");
return default;
}, 2, "", true));
} else {
lip_797.S("<path d=\"").V(Call(quad_32, V.Undef, s0_833, s1_834, ((V)((-1D))), ((V)(1D)), h0_835, h1_836)).S("\" fill=\"").V(GetIdx(Get(L_785, "planks"), ((double)(ToInt32(j_831) & ToInt32(1D))))).S("\" stroke=\"").V(Get(L_785, "seam")).S("\" stroke-width=\"1\"/>");
}
lip_797.S("<path d=\"M").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, s0_833, ((V)((-1D))), h0_835))).S("L").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, s0_833, ((V)(1D)), h0_835))).S("\" stroke=\"").V(Get(L_785, "seam")).S("\" stroke-width=\"1.3\" opacity=\"0.35\"/>");
j_831++;
}
}
edge_798 = Fn((V _self778, int _argc846, V l_852, V dh_853, V _a850, V _a851, V[] _rest847) => {
V o_854 = default;
o_854 = Arr();
{
double j_855 = 0;
j_855 = 0D;
while (true) {
if (!((j_855 <= N_795))) break;
Invoke(o_854, "push", Call(Wp_28, V.Undef, Call(sAt_796, V.Undef, ((V)(j_855))), l_852, Add(Call(HS_57, V.Undef, Call(sAt_796, V.Undef, ((V)(j_855)))), dh_853)));
j_855++;
}
}
return o_854;
return default;
}, 2, "", true);
rev_799 = Fn((V _self778, int _argc857, V q_863, V _a860, V _a861, V _a862, V[] _rest858) => {
return Invoke(Invoke(q_863, "slice"), "reverse");
}, 1, "", true);
lipB_800 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Call(quad_32, V.Undef, ((V)(RS_45)), ((V)((LEN_44 + 10D))), ((V)((-1.1))), ((V)(1.1)), ((V)(0D)))).S("\" fill=\"#2a3a20\" opacity=\"0.14\"/>").V(Call(post_543, V.Undef, L_785, ((V)((RS_45 + 90D))), ((V)(1.06)), ((V)(0D)), ((V)((ToNum(Call(HS_57, V.Undef, ((V)((RS_45 + 90D))))) - 6D))), ((V)(5D)))).V(Call(post_543, V.Undef, L_785, ((V)((LEN_44 - 8D))), ((V)(1.06)), ((V)(0D)), ((V)((ToNum(Call(HS_57, V.Undef, ((V)((LEN_44 - 8D))))) - 6D))), ((V)(6D)))).End());
lipB_800.S(lip_797.Str).S("<path d=\"").V(Call(poly_31, V.Undef, Invoke(Call(edge_798, V.Undef, ((V)(1D)), ((V)(0D))), "concat", Call(rev_799, V.Undef, Call(edge_798, V.Undef, ((V)(1D)), ((V)(WH_48))))))).S("\" fill=\"").V(Get(L_785, "face")).S("\"/><path d=\"").V(Call(poly_31, V.Undef, Invoke(Call(edge_798, V.Undef, ((V)(1D)), ((V)(WH_48))), "concat", Call(rev_799, V.Undef, Call(edge_798, V.Undef, ((V)(1.12)), ((V)(WH_48))))))).S("\" fill=\"").V(Get(L_785, "top")).S("\" stroke=\"").V(Get(L_785, "side")).S("\" stroke-width=\"1\"/>");
lipF_801 = Add(Call(post_543, V.Undef, L_785, ((V)((RS_45 + 90D))), ((V)((-1.06))), ((V)(0D)), ((V)((ToNum(Call(HS_57, V.Undef, ((V)((RS_45 + 90D))))) - 6D))), ((V)(5D))), Call(post_543, V.Undef, L_785, ((V)((LEN_44 - 8D))), ((V)((-1.06))), ((V)(0D)), ((V)((ToNum(Call(HS_57, V.Undef, ((V)((LEN_44 - 8D))))) - 6D))), ((V)(6D))));
lipF_801 = ((V)(JsStrBuf.Begin().V(lipF_801).S("<path d=\"").V(Call(poly_31, V.Undef, Invoke(Call(edge_798, V.Undef, ((V)((-1.12))), ((V)((-9D)))), "concat", Call(rev_799, V.Undef, Call(edge_798, V.Undef, ((V)((-1.12))), ((V)(WH_48))))))).S("\" fill=\"").V(Get(L_785, "side")).S("\"/><path d=\"").V(Call(poly_31, V.Undef, Invoke(Call(edge_798, V.Undef, ((V)((-1.12))), ((V)(WH_48))), "concat", Call(rev_799, V.Undef, Call(edge_798, V.Undef, ((V)((-1D))), ((V)(WH_48))))))).S("\" fill=\"").V(Get(L_785, "top")).S("\" stroke=\"").V(Get(L_785, "side")).S("\" stroke-width=\"1\"/>").End()));
lipF_801 = ((V)(JsStrBuf.Begin().V(lipF_801).S("<path d=\"").V(Call(poly_31, V.Undef, Arr(Call(Wp_28, V.Undef, ((V)(LEN_44)), ((V)((-1.12))), ((V)((ToNum(Call(HS_57, V.Undef, ((V)(LEN_44)))) - 9D)))), Call(Wp_28, V.Undef, ((V)(LEN_44)), ((V)(1.12)), ((V)((ToNum(Call(HS_57, V.Undef, ((V)(LEN_44)))) - 9D)))), Call(Wp_28, V.Undef, ((V)(LEN_44)), ((V)(1.12)), Add(Call(HS_57, V.Undef, ((V)(LEN_44))), ((V)(WH_48)))), Call(Wp_28, V.Undef, ((V)(LEN_44)), ((V)((-1.12))), Add(Call(HS_57, V.Undef, ((V)(LEN_44))), ((V)(WH_48))))))).S("\" fill=\"").V(Get(L_785, "side")).S("\" stroke=\"#000\" stroke-opacity=\"0.12\" stroke-width=\"1.4\"/><path d=\"M").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, ((V)(LEN_44)), ((V)((-1D))), Add(Call(HS_57, V.Undef, ((V)(LEN_44))), ((V)(1D)))))).S("L").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, ((V)(LEN_44)), ((V)(1D)), Add(Call(HS_57, V.Undef, ((V)(LEN_44))), ((V)(1D)))))).S("\" stroke=\"#ffffff\" stroke-width=\"3\" stroke-linecap=\"round\"/>").End()));
Set(gStart_520, "innerHTML", ((V)(b_786.Str)));
Set(gEnd_522, "innerHTML", ((V)(lipB_800.Str)));
Set(gEndF_530, "innerHTML", lipF_801);
f_787.V(Add(Call(post_543, V.Undef, L_785, ((V)(a_788)), ((V)(lN_790)), ((V)(0D)), ((V)(RT_792)), ((V)(7D))), Call(post_543, V.Undef, L_785, ((V)(z_789)), ((V)(lN_790)), ((V)(0D)), ((V)(RT_792)), ((V)(7D)))));
lad_802 = Fn((V _self778, int _argc864, V s_870, V _a867, V _a868, V _a869, V[] _rest865) => {
return Arr(Call(Wp_28, V.Undef, s_870, ((V)((lN_790 - 1D))), ((V)(0D))), Call(Wp_28, V.Undef, s_870, ((V)(lN_790)), ((V)((SH_47 + 18D)))));
}, 1, "", true);
f_787.V(Add(Call(bar_793, V.Undef, Call(lad_802, V.Undef, ((V)((-128D)))), ((V)(3.8))), Call(bar_793, V.Undef, Call(lad_802, V.Undef, ((V)((-84D)))), ((V)(3.8)))));
{
double k_871 = 0;
k_871 = 1D;
while (true) {
if (!((k_871 <= 4D))) break;
double h_873 = 0;
double l_874 = 0;
h_873 = ((k_871 * SH_47) / 5D);
l_874 = ((lN_790 - 1D) + ((1D * h_873) / (SH_47 + 18D)));
f_787.V(Call(bar_793, V.Undef, Arr(Call(Wp_28, V.Undef, ((V)((-128D))), ((V)(l_874)), ((V)(h_873))), Call(Wp_28, V.Undef, ((V)((-84D))), ((V)(l_874)), ((V)(h_873)))), ((V)(3D))));
k_871++;
}
}
Set(gStartF_528, "innerHTML", ((V)(f_787.Str)));
return default;
}, 0, "buildStatic", false);
gen_555 = Fn((V _self875, int _argc876, V seed_882, V _a879, V _a880, V _a881, V[] _rest877) => {
V R_883 = default;
V @out_884 = default;
V add_885 = default;
V LN_886 = default;
double s_887 = 0;
if (_self875.IsNullish) _self875 = GlobalV;
R_883 = Call(rnd_36, V.Undef, seed_882);
@out_884 = Arr();
add_885 = Fn((V _self875, int _argc888, V t_894, V s_895, V l_896, V _a893, V[] _rest889) => {
return Invoke(@out_884, "push", Object_assign(NewObj(4).Put("t", t_894).Put("s", s_895).Put("l", l_896).Put("hit", ((V)(0D))).V, GetK(DEF_60, t_894)));
}, 3, "", true);
LN_886 = Arr(((V)((-0.5))), ((V)(0.5)));
s_887 = 520D;
while ((s_887 < (RS_45 - 600D))) {
V sec_897 = default;
V r_898 = default;
V A_899 = default;
double B_900 = 0;
V soft_901 = default;
sec_897 = Call(secAt_56, V.Undef, ((V)(s_887)));
r_898 = Call(R_883, V.Undef);
A_899 = GetIdx(LN_886, (LtN(Call(R_883, V.Undef), 0.5) ? 0D : 1D));
B_900 = (-ToNum(A_899));
soft_901 = Fn((V _self875, int _argc902, V _a904, V _a905, V _a906, V _a907, V[] _rest903) => {
return GetIdx(Arr(((V)("sand")), ((V)("leaves")), ((V)("bucket"))), System.Math.Floor((ToNum(Call(R_883, V.Undef)) * 3D)));
}, 0, "", true);
if (SEqS(sec_897, "meadow")) {
if (LtN(r_898, 0.34)) {
Call(add_885, V.Undef, Call(soft_901, V.Undef), ((V)(s_887)), A_899);
} else {
if (LtN(r_898, 0.6)) {
Call(add_885, V.Undef, ((V)("slick")), ((V)(s_887)), A_899);
} else {
if (LtN(r_898, 0.85)) {
Call(add_885, V.Undef, Call(soft_901, V.Undef), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("slick")), ((V)((s_887 + 20D))), ((V)(B_900)));
} else {
Call(add_885, V.Undef, ((V)("ramp")), ((V)(s_887)), ((V)(0D)));
}
}
}
} else {
if (SEqS(sec_897, "garden")) {
if (LtN(r_898, 0.25)) {
Call(add_885, V.Undef, ((V)("gnome")), ((V)(s_887)), A_899);
} else {
if (LtN(r_898, 0.45)) {
Call(add_885, V.Undef, ((V)("gnome")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("bucket")), ((V)((s_887 + 200D))), ((V)(B_900)));
} else {
if (LtN(r_898, 0.6)) {
Call(add_885, V.Undef, ((V)("mud")), ((V)(s_887)), A_899);
} else {
if (LtN(r_898, 0.82)) {
Call(add_885, V.Undef, ((V)("slick")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("gnome")), ((V)((s_887 + 190D))), A_899);
} else {
Call(add_885, V.Undef, ((V)("gold")), ((V)(s_887)), A_899);
}
}
}
}
} else {
if (SEqS(sec_897, "farm")) {
if (LtN(r_898, 0.25)) {
Call(add_885, V.Undef, ((V)("hay")), ((V)(s_887)), A_899);
} else {
if (LtN(r_898, 0.45)) {
Call(add_885, V.Undef, ((V)("hay")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("hay")), ((V)((s_887 + 210D))), ((V)(B_900)));
} else {
if (LtN(r_898, 0.62)) {
Call(add_885, V.Undef, ((V)("ramp")), ((V)(s_887)), ((V)(0D)));
Call(add_885, V.Undef, ((V)("log")), ((V)((s_887 + 100D))), ((V)(0D)));
} else {
if (LtN(r_898, 0.78)) {
Call(add_885, V.Undef, ((V)("mud")), ((V)(s_887)), A_899);
} else {
if (LtN(r_898, 0.92)) {
Call(add_885, V.Undef, ((V)("hay")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("slick")), ((V)(s_887)), ((V)(B_900)));
} else {
Call(add_885, V.Undef, ((V)("hay")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("gold")), ((V)((s_887 + 160D))), ((V)(B_900)));
}
}
}
}
}
} else {
if (SEqS(sec_897, "sprinkle")) {
if (LtN(r_898, 0.28)) {
Call(add_885, V.Undef, ((V)("slick")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("slick")), ((V)((s_887 + 200D))), ((V)(B_900)));
} else {
if (LtN(r_898, 0.45)) {
Call(add_885, V.Undef, ((V)("rock")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("slick")), ((V)(s_887)), ((V)(B_900)));
} else {
if (LtN(r_898, 0.62)) {
Call(add_885, V.Undef, ((V)("rock")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("rock")), ((V)((s_887 + 210D))), ((V)(B_900)));
} else {
if (LtN(r_898, 0.74)) {
Call(add_885, V.Undef, ((V)("mud")), ((V)(s_887)), A_899);
} else {
if (LtN(r_898, 0.86)) {
Call(add_885, V.Undef, ((V)("gold")), ((V)(s_887)), A_899);
} else {
Call(add_885, V.Undef, ((V)("ramp")), ((V)(s_887)), ((V)(0D)));
Call(add_885, V.Undef, ((V)("log")), ((V)((s_887 + 100D))), ((V)(0D)));
}
}
}
}
}
} else {
if (LtN(r_898, 0.3)) {
Call(add_885, V.Undef, ((V)("rock")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("gnome")), ((V)((s_887 + 210D))), ((V)(B_900)));
} else {
if (LtN(r_898, 0.55)) {
Call(add_885, V.Undef, ((V)("slick")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("rock")), ((V)((s_887 + 200D))), A_899);
} else {
if (LtN(r_898, 0.75)) {
Call(add_885, V.Undef, ((V)("hay")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("slick")), ((V)(s_887)), ((V)(B_900)));
} else {
if (LtN(r_898, 0.88)) {
Call(add_885, V.Undef, ((V)("mud")), ((V)(s_887)), A_899);
} else {
Call(add_885, V.Undef, ((V)("rock")), ((V)(s_887)), A_899);
Call(add_885, V.Undef, ((V)("gold")), ((V)((s_887 + 170D))), ((V)(B_900)));
}
}
}
}
}
}
}
}
s_887 = (s_887 + (ToNum(Call(lerp_18, V.Undef, ((V)(420D)), ((V)(330D)), ((V)((s_887 / LEN_44))))) * (0.88 + (ToNum(Call(R_883, V.Undef)) * 0.3))));
}
return Invoke(@out_884, "sort", Fn((V _self875, int _argc908, V a_914, V b_915, V _a912, V _a913, V[] _rest909) => {
return ((V)((ToNum(Get(a_914, "s")) - ToNum(Get(b_915, "s")))));
}, 2, "", true));
return default;
}, 1, "gen", false);
spawn_556 = Fn((V _self916, int _argc917, V it_923, V _a920, V _a921, V _a922, V[] _rest918) => {
V html_924 = default;
if (_self916.IsNullish) _self916 = GlobalV;
html_924 = InvokeK(ART_63, Get(it_923, "t"), it_923);
if (Truthy(Get(it_923, "flat"))) {
Set(it_923, "el", Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, Get(it_923, "s"), Get(it_923, "l"), ((V)(SH_47))))).S(")").End()))).V, gDecal_523));
Set(Get(it_923, "el"), "innerHTML", html_924);
} else {
Set(it_923, "o", Call(addStand_539, V.Undef, html_924, Get(it_923, "s"), Get(it_923, "l"), ((V)(SH_47))));
Set(it_923, "el", Get(Get(it_923, "o"), "el"));
}
Invoke(alive_554, "push", it_923);
return default;
}, 1, "spawn", false);
despawn_557 = Fn((V _self925, int _argc926, V it_932, V _a929, V _a930, V _a931, V[] _rest927) => {
if (_self925.IsNullish) _self925 = GlobalV;
if (Truthy(Get(it_932, "o"))) {
Call(dropStand_540, V.Undef, Get(it_932, "o"));
} else {
if (Truthy(Get(it_932, "el"))) {
Invoke(Get(it_932, "el"), "remove");
}
}
Set(it_932, "el", Set(it_932, "o", V.Null));
return default;
}, 1, "despawn", false);
feed_558 = Fn((V _self933, int _argc934, V sc_940, V z_941, V _a938, V _a939, V[] _rest935) => {
double lo_942 = 0;
V hi_943 = default;
if (_self933.IsNullish) _self933 = GlobalV;
lo_942 = (ToNum(sc_940) - (700D / ToNum(z_941)));
hi_943 = Add(sc_940, ((V)((1300D / ToNum(z_941)))));
while ((Lt(((V)(nextI_553)), Get(items_552, "length")) && Lt(Get(GetIdx(items_552, nextI_553), "s"), hi_943))) {
if (GtN(Get(GetIdx(items_552, nextI_553), "s"), lo_942)) {
Call(spawn_556, V.Undef, GetIdx(items_552, nextI_553));
}
nextI_553++;
}
{
double i_944 = 0;
i_944 = (ToNum(Get(alive_554, "length")) - 1D);
while (true) {
if (!((i_944 >= 0D))) break;
if (LtN(Get(GetIdx(alive_554, i_944), "s"), lo_942)) {
Call(despawn_557, V.Undef, GetIdx(alive_554, i_944));
Invoke(alive_554, "splice", ((V)(i_944)), ((V)(1D)));
}
i_944--;
}
}
return default;
}, 2, "feed", false);
windOn_573 = Fn((V _self946, int _argc947, V _a949, V _a950, V _a951, V _a952, V[] _rest948) => {
if (_self946.IsNullish) _self946 = GlobalV;
try {
if (SEqS(Invoke(G("localStorage"), "getItem", ((V)("yardgames.v1.mute"))), "1")) {
return default;
}
} catch (System.Exception _ex953) {
V e_954 = default;
e_954 = Caught(_ex953);

}
if (Truthy(AU_572)) {
return default;
}
try {
V AC_955 = default;
V c_956 = default;
double n_957 = 0;
V b_958 = default;
V d_959 = default;
V src_960 = default;
V f_961 = default;
V g_962 = default;
AC_955 = (Get(G("window"), "AudioContext") is var _t963 && Truthy(_t963) ? _t963 : Get(G("window"), "webkitAudioContext"));
c_956 = New(AC_955);
n_957 = (ToNum(Get(c_956, "sampleRate")) * 2D);
b_958 = Invoke(c_956, "createBuffer", ((V)(1D)), ((V)(n_957)), Get(c_956, "sampleRate"));
d_959 = Invoke(b_958, "getChannelData", ((V)(0D)));
{
double i_964 = 0;
i_964 = 0D;
while (true) {
if (!((i_964 < n_957))) break;
SetIdx(d_959, i_964, ((V)(((ToNum(Invoke(G("Math"), "random")) * 2D) - 1D))));
i_964++;
}
}
src_960 = Invoke(c_956, "createBufferSource");
Set(src_960, "buffer", b_958);
Set(src_960, "loop", (true ? V.True : V.False));
f_961 = Invoke(c_956, "createBiquadFilter");
Set(f_961, "type", ((V)("bandpass")));
Set(Get(f_961, "Q"), "value", ((V)(0.9)));
g_962 = Invoke(c_956, "createGain");
Set(Get(g_962, "gain"), "value", ((V)(0D)));
Invoke(src_960, "connect", f_961);
Invoke(f_961, "connect", g_962);
Invoke(g_962, "connect", Get(c_956, "destination"));
Invoke(src_960, "start");
AU_572 = NewObj(4).Put("c", c_956).Put("f", f_961).Put("g", g_962).Put("src", src_960).V;
} catch (System.Exception _ex966) {
V e_967 = default;
e_967 = Caught(_ex966);
AU_572 = V.Null;
}
return default;
}, 0, "windOn", false);
windSet_574 = Fn((V _self968, int _argc969, V v_975, V on_976, V _a973, V _a974, V[] _rest970) => {
V t_977 = default;
if (_self968.IsNullish) _self968 = GlobalV;
if (!(Truthy(AU_572))) {
return default;
}
t_977 = Get(Get(AU_572, "c"), "currentTime");
Invoke(Get(Get(AU_572, "f"), "frequency"), "setTargetAtTime", ((V)((260D + (ToNum(v_975) * 13D)))), t_977, ((V)(0.12)));
Invoke(Get(Get(AU_572, "g"), "gain"), "setTargetAtTime", (Truthy(on_976) ? Call(cl_17, V.Undef, ((V)(((ToNum(v_975) - 15D) / 110D))), ((V)(0.02)), ((V)(0.2))) : ((V)(0D))), t_977, ((V)((Truthy(on_976) ? 0.15 : 0.35))));
return default;
}, 2, "windSet", false);
windOff_575 = Fn((V _self978, int _argc979, V _a981, V _a982, V _a983, V _a984, V[] _rest980) => {
V a_985 = default;
if (_self978.IsNullish) _self978 = GlobalV;
if (!(Truthy(AU_572))) {
return default;
}
a_985 = AU_572;
AU_572 = V.Null;
try {
Invoke(Get(Get(a_985, "g"), "gain"), "setTargetAtTime", ((V)(0D)), Get(Get(a_985, "c"), "currentTime"), ((V)(0.1)));
Call(G("setTimeout"), V.Undef, Fn((V _self978, int _argc994, V _a996, V _a997, V _a998, V _a999, V[] _rest995) => {
try {
Invoke(Get(a_985, "src"), "stop");
Invoke(Get(a_985, "c"), "close");
} catch (System.Exception _ex1000) {
V e_993 = default;
e_993 = Caught(_ex1000);

}
return default;
}, 0, "", true), ((V)(500D)));
} catch (System.Exception _ex1001) {
V e_1002 = default;
e_1002 = Caught(_ex1001);

}
return default;
}, 0, "windOff", false);
reset_585 = Fn((V _self1003, int _argc1004, V _a1006, V _a1007, V _a1008, V _a1009, V[] _rest1005) => {
if (_self1003.IsNullish) _self1003 = GlobalV;
Object_assign(st_583, NewObj(20).Put("phase", ((V)("ready"))).Put("s", ((V)(ST0_54))).Put("l", ((V)(0D))).Put("tgt", ((V)(0D))).Put("h", ((V)(SH_47))).Put("ha", ((V)(0D))).Put("vh", ((V)(0D))).Put("v", ((V)(0D))).Put("top", ((V)(0D))).Put("lc", ((V)(0D))).Put("sc", ((V)(ST0_54))).Put("stun", ((V)(0D))).Put("boostT", ((V)(0D))).Put("punch", ((V)(0D))).Put("mud", ((V)(0D))).Put("boosts", ((V)(0D))).Put("bonks", ((V)(0D))).Put("shake", ((V)(0D))).Put("toldPool", ((V)(0D))).Put("k", ((V)(0D))).V);
Invoke(alive_554, "forEach", despawn_557);
alive_554 = Arr();
items_552 = Call(gen_555, V.Undef, ((V)((1234D + System.Math.Floor((ToNum(Invoke(G("Math"), "random")) * 9000D))))));
nextI_553 = 0D;
{
foreach (V _k1010 in new JsIter(new ArrBuilder().Spread(Invoke(chunks_541, "keys")).V)) {
V i_1011 = default;
i_1011 = _k1010;
Call(dropChunk_549, V.Undef, i_1011);
}
}
Call(buildStatic_551, V.Undef);
Invoke(me_576, "hide", (false ? V.True : V.False));
Invoke(me_576, "play", ((V)("idle")));
return default;
}, 0, "reset", false);
botSteer_588 = Fn((V _self1012, int _argc1013, V t_1019, V _a1016, V _a1017, V _a1018, V[] _rest1014) => {
V sk_1020 = default;
double ahead_1021 = 0;
V best_1022 = default;
double bs_1023 = 0;
if (_self1012.IsNullish) _self1012 = GlobalV;
if (((ToNum(t_1019) - ToNum(Get(st_583, "botT"))) < (120D - (ToNum(Get(st_583, "bot")) * 60D)))) {
return default;
}
Set(st_583, "botT", t_1019);
sk_1020 = Get(st_583, "bot");
ahead_1021 = (200D + (ToNum(sk_1020) * 260D));
best_1022 = Get(st_583, "tgt");
bs_1023 = (-1000000000D);
{
double c_1024 = 0;
c_1024 = (-LMAX_41);
while (true) {
if (!((c_1024 <= (LMAX_41 + 0.000001)))) break;
double sc_1026 = 0;
sc_1026 = ((-System.Math.Abs((c_1024 - ToNum(Get(st_583, "l"))))) * 0.6);
{
foreach (V _k1027 in new JsIter(alive_554)) {
V q_1028 = default;
q_1028 = _k1027;
double ds_1029 = 0;
V near_1030 = default;
double w_1031 = 0;
ds_1029 = (ToNum(Get(q_1028, "s")) - ToNum(Get(st_583, "s")));
if (Truthy(((((ds_1029 < (-10D)) || (ds_1029 > ahead_1021)) ? V.True : V.False) is var _t1032 && Truthy(_t1032) ? _t1032 : Get(q_1028, "hit")))) {
continue;
}
near_1030 = (Lt(((V)(System.Math.Abs((c_1024 - ToNum(Get(q_1028, "l")))))), Add(Add(Get(q_1028, "hw"), ((V)(RW_42))), ((V)(0.03)))) ? V.True : V.False);
w_1031 = (1D - ((ds_1029 / ahead_1021) * 0.5));
if (Truthy(near_1030)) {
sc_1026 = (sc_1026 + ((SEqS(Get(q_1028, "k"), "hard") ? (-10D) : (SEqS(Get(q_1028, "k"), "soft") ? (-6D) : (SEqS(Get(q_1028, "k"), "mud") ? (-7D) : (SEqS(Get(q_1028, "k"), "gold") ? 9D : (SEqS(Get(q_1028, "k"), "boost") ? 7D : 0D))))) * w_1031));
}
}
}
if ((sc_1026 > bs_1023)) {
bs_1023 = sc_1026;
best_1022 = ((V)(c_1024));
}
c_1024 = (c_1024 + 0.11);
}
}
Set(st_583, "tgt", (Lt(Invoke(G("Math"), "random"), sk_1020) ? best_1022 : Call(cl_17, V.Undef, Add(Get(st_583, "tgt"), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.5)))), ((V)((-LMAX_41))), ((V)(LMAX_41)))));
return default;
}, 1, "botSteer", false);
hits_589 = Fn((V _self1033, int _argc1034, V _a1036, V _a1037, V _a1038, V _a1039, V[] _rest1035) => {
V L_1040 = default;
if (_self1033.IsNullish) _self1033 = GlobalV;
L_1040 = GetK(LOOK_61, look_517);
{
foreach (V _k1041 in new JsIter(alive_554)) {
V q_1042 = default;
q_1042 = _k1041;
V p_1043 = default;
V hard_1044 = default;
double dv_1045 = 0;
if (Truthy(((Get(q_1042, "hit") is var _t1046 && Truthy(_t1046) ? _t1046 : (Gt(((V)(System.Math.Abs((ToNum(Get(q_1042, "s")) - ToNum(Get(st_583, "s")))))), Add(Get(q_1042, "hs"), ((V)(10D)))) ? V.True : V.False)) is var _t1047 && Truthy(_t1047) ? _t1047 : (Gt(((V)(System.Math.Abs((ToNum(Get(q_1042, "l")) - ToNum(Get(st_583, "l")))))), Add(Get(q_1042, "hw"), ((V)(RW_42)))) ? V.True : V.False)))) {
continue;
}
if ((GtN(Get(st_583, "ha"), (ToNum(Get(q_1042, "hh")) - 2D)) && !SEqS(Get(q_1042, "k"), "ramp"))) {
continue;
}
p_1043 = Call(scr_584, V.Undef, Get(st_583, "s"), Get(st_583, "l"), Get(st_583, "h"));
if (SEqS(Get(q_1042, "k"), "ramp")) {
if (LtN(Get(st_583, "ha"), 8D)) {
Set(q_1042, "hit", ((V)(1D)));
Set(st_583, "vh", ((V)(370D)));
Set(st_583, "ha", ((V)(Max(ToNum(Get(st_583, "ha")), 1D))));
Invoke(SFX_20, "boing");
Invoke(ctx_512, "toast", ((V)("Hop!")), GetIdx(p_1043, 0D), ((V)((ToNum(GetIdx(p_1043, 1D)) - 70D))), ((V)("#ffffff")));
}
continue;
}
Set(q_1042, "hit", ((V)(1D)));
if ((SEqS(Get(q_1042, "k"), "boost") || SEqS(Get(q_1042, "k"), "gold"))) {
double dv_1048 = 0;
dv_1048 = (((SEqS(Get(q_1042, "k"), "gold") ? 13D : 8D) * ToNum(Get(L_1040, "boost"))) * (1D - (ToNum(Get(st_583, "v")) / 160D)));
OpSet(st_583, "v", 0, ((V)(dv_1048)));
Set(st_583, "boostT", ((V)(0.7)));
Set(st_583, "punch", ((V)(1D)));
IncM(st_583, "boosts", 1D, false);
Invoke(SFX_20, "whoosh");
if (SEqS(Get(q_1042, "k"), "gold")) {
Invoke(SFX_20, "pop");
}
Invoke(ctx_512, "toast", ((V)(JsStrBuf.Begin().S((SEqS(Get(q_1042, "k"), "gold") ? "Turbo! +" : "Splash! +")).N(Round(dv_1048)).End())), Add(GetIdx(p_1043, 0D), ((V)(20D))), ((V)((ToNum(GetIdx(p_1043, 1D)) - 80D))), ((V)((SEqS(Get(q_1042, "k"), "gold") ? "#ffe36e" : "#bfe8ff"))));
Invoke(ctx_512, "burst", GetIdx(p_1043, 0D), ((V)((ToNum(GetIdx(p_1043, 1D)) - 10D))), ((V)((SEqS(Get(q_1042, "k"), "gold") ? "star" : "drop"))), ((V)(14D)), NewObj(2).Put("v", ((V)(160D))).Put("spread", ((V)(2.4))).V);
if (Truthy(Get(q_1042, "el"))) {
Set(Get(Get(q_1042, "el"), "style"), "opacity", ((V)(0.45)));
}
continue;
}
if (SEqS(Get(q_1042, "k"), "mud")) {
Set(st_583, "mud", ((V)(0.55)));
IncM(st_583, "bonks", 1D, false);
Invoke(SFX_20, "thud");
Invoke(ctx_512, "toast", ((V)("Mud!")), Add(GetIdx(p_1043, 0D), ((V)(20D))), ((V)((ToNum(GetIdx(p_1043, 1D)) - 80D))), ((V)("#e2b98a")));
Invoke(ctx_512, "burst", GetIdx(p_1043, 0D), ((V)((ToNum(GetIdx(p_1043, 1D)) - 6D))), ((V)("dust")), ((V)(10D)), NewObj(2).Put("col", ((V)("#8a5a34"))).Put("v", ((V)(90D))).V);
continue;
}
hard_1044 = (SEqS(Get(q_1042, "k"), "hard") ? V.True : V.False);
dv_1045 = ((Truthy(hard_1044) ? (9D + (0.25 * (ToNum(Get(st_583, "v")) - VB_38))) : (5D + (0.12 * (ToNum(Get(st_583, "v")) - VB_38)))) * ToNum(Get(L_1040, "hit")));
Set(st_583, "v", ((V)(Max((VB_38 * (Truthy(hard_1044) ? 0.7 : 0.85)), (ToNum(Get(st_583, "v")) - dv_1045)))));
Set(st_583, "stun", ((V)((Truthy(hard_1044) ? 0.6 : 0.35))));
IncM(st_583, "bonks", 1D, false);
Set(st_583, "shake", ((V)((Truthy(hard_1044) ? 7D : 3.5))));
Set(st_583, "l", Call(cl_17, V.Undef, Add(Get(st_583, "l"), ((V)((Gt(Get(st_583, "l"), Get(q_1042, "l")) ? 0.12 : (-0.12))))), ((V)((-LMAX_41))), ((V)(LMAX_41))));
if (Truthy(hard_1044)) {
Invoke(SFX_20, "thud");
Invoke(me_576, "play", ((V)("surprised")));
Call(G("setTimeout"), V.Undef, Fn((V _self1033, int _argc1056, V _a1058, V _a1059, V _a1060, V _a1061, V[] _rest1057) => {
return ((SEqS(Get(st_583, "phase"), "ride") ? V.True : V.False) is var _t1062 && !Truthy(_t1062) ? _t1062 : Invoke(me_576, "play", ((V)("idle"))));
}, 0, "", true), ((V)(650D)));
} else {
Invoke(SFX_20, "pop");
}
Invoke(ctx_512, "toast", ((V)(JsStrBuf.Begin().S((Truthy(hard_1044) ? "Bonk! -" : "Oof! -")).N(Round(dv_1045)).End())), Add(GetIdx(p_1043, 0D), ((V)(20D))), ((V)((ToNum(GetIdx(p_1043, 1D)) - 80D))), ((V)("#ffb0a0")));
Invoke(ctx_512, "burst", GetIdx(p_1043, 0D), ((V)((ToNum(GetIdx(p_1043, 1D)) - 30D))), ((V)((Truthy(hard_1044) ? "star" : "dust"))), ((V)((Truthy(hard_1044) ? 8D : 9D))), NewObj(2).Put("v", ((V)(110D))).Put("col", (SEqS(Get(q_1042, "t"), "sand") ? ((V)("#f1d48a")) : (SEqS(Get(q_1042, "t"), "leaves") ? ((V)("#ff9a3a")) : (SEqS(Get(q_1042, "t"), "hay") ? ((V)("#f2cf6a")) : V.Undef)))).V);
if (Truthy(((Get(q_1042, "el") is var _t1063 && !Truthy(_t1063) ? _t1063 : (!SEqS(Get(q_1042, "t"), "rock") ? V.True : V.False)) is var _t1064 && !Truthy(_t1064) ? _t1064 : (!SEqS(Get(q_1042, "t"), "log") ? V.True : V.False)))) {
Invoke(Get(Get(q_1042, "el"), "classList"), "add", ((V)("ygs-hit")));
}
}
}
return default;
}, 0, "hits", false);
launch_590 = Fn((V _self1065, int _argc1066, V _a1068, V _a1069, V _a1070, V _a1071, V[] _rest1067) => {
double vs_1072 = 0;
V p_1073 = default;
V tr_1074 = default;
if (_self1065.IsNullish) _self1065 = GlobalV;
Set(st_583, "phase", ((V)("fly")));
Set(st_583, "lipV", Get(st_583, "v"));
Set(st_583, "tf", tNow_580);
vs_1072 = (ToNum(Get(st_583, "v")) * KV_37);
Set(st_583, "vs", ((V)((vs_1072 * 0.45))));
Set(st_583, "vh", ((V)((360D + (0.35 * vs_1072)))));
Set(st_583, "h", Call(HS_57, V.Undef, ((V)(LEN_44))));
Invoke(SFX_20, "boing");
Invoke(SFX_20, "whoosh");
p_1073 = Call(scr_584, V.Undef, Get(st_583, "s"), Get(st_583, "l"), Get(st_583, "h"));
Invoke(ctx_512, "burst", GetIdx(p_1073, 0D), GetIdx(p_1073, 1D), ((V)("drop")), ((V)(16D)), NewObj(1).Put("v", ((V)(170D))).V);
tr_1074 = Call(tierOf_59, V.Undef, Get(st_583, "v"));
Invoke(ctx_512, "toast", ((V)(JsStrBuf.Begin().N(Round(ToNum(Get(st_583, "v")))).S(" km/h!").End())), ((V)((ToNum(W_515) / 2D))), ((V)(96D)), GetIdx(tr_1074, 2D), (true ? V.True : V.False));
if (GeN(Get(st_583, "v"), 75D)) {
Call(G("setTimeout"), V.Undef, Fn((V _self1065, int _argc1082, V _a1084, V _a1085, V _a1086, V _a1087, V[] _rest1083) => {
return ((SEqS(Get(st_583, "phase"), "fly") ? V.True : V.False) is var _t1088 && !Truthy(_t1088) ? _t1088 : Invoke(ctx_512, "toast", ((V)("Cannonball!")), ((V)((ToNum(W_515) / 2D))), ((V)(150D)), ((V)("#ffffff"))));
}, 0, "", true), ((V)(250D)));
}
friends_581 = Invoke(Invoke(ctx_512, "opponent", ((V)(3D))), "map", Fn((V _self1065, int _argc1089, V key_1095, V i_1096, V _a1093, V _a1094, V[] _rest1090) => {
V c_1097 = default;
c_1097 = Invoke(ctx_512, "creature", key_1095, NewObj(1).Put("yaw", ((V)((SEqN(i_1096, 1D) ? (-20D) : (SEqN(i_1096, 2D) ? 20D : 0D))))).V);
Invoke(c_1097, "hide", (true ? V.True : V.False));
return NewObj(2).Put("c", c_1097).Put("key", key_1095).V;
return default;
}, 2, "", true));
Call(windSet_574, V.Undef, Get(st_583, "v"), (false ? V.True : V.False));
return default;
}, 0, "launch", false);
transition_591 = Fn((V _self1098, int _argc1099, V _a1101, V _a1102, V _a1103, V _a1104, V[] _rest1100) => {
V t0_1105 = default;
V fade_1106 = default;
if (_self1098.IsNullish) _self1098 = GlobalV;
Set(st_583, "tr", ((V)(1D)));
t0_1105 = Invoke(G("performance"), "now");
Invoke(SFX_20, "whoosh");
fade_1106 = Fn((V _self1098, int _argc1107, V _a1109, V _a1110, V _a1111, V _a1112, V[] _rest1108) => {
double u_1113 = 0;
V t1_1114 = default;
V @out_1115 = default;
u_1113 = ((ToNum(Invoke(G("performance"), "now")) - ToNum(t0_1105)) / 160D);
Invoke(flash_571, "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, ((V)(Min(1D, u_1113)))));
if ((u_1113 < 1D)) {
return Call(G("requestAnimationFrame"), V.Undef, fade_1106);
}
Invoke(Arr(slideBg_518, wB_519, wF_527, speedL_533), "forEach", Fn((V _self1098, int _argc1116, V e_1122, V _a1119, V _a1120, V _a1121, V[] _rest1117) => {
return Set(Get(e_1122, "style"), "display", ((V)("none")));
}, 1, "", true));
Set(Get(pg_567, "style"), "display", ((V)("none")));
Set(Get(sp_559, "style"), "display", ((V)("none")));
Set(stands_536, "length", ((V)(0D)));
Set(Get(scB_526, "style"), "display", ((V)("")));
Set(Get(scF_532, "style"), "display", ((V)("")));
pool_582 = Call(poolScene_592, V.Undef);
Set(st_583, "phase", ((V)("pool")));
Call(windOff_575, V.Undef);
t1_1114 = Invoke(G("performance"), "now");
@out_1115 = Fn((V _self1098, int _argc1123, V _a1125, V _a1126, V _a1127, V _a1128, V[] _rest1124) => {
double v_1129 = 0;
v_1129 = (1D - ((ToNum(Invoke(G("performance"), "now")) - ToNum(t1_1114)) / 320D));
Invoke(flash_571, "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, ((V)(Max(0D, v_1129)))));
if ((v_1129 > 0D)) {
Call(G("requestAnimationFrame"), V.Undef, @out_1115);
}
return default;
}, 0, "", true);
Call(G("requestAnimationFrame"), V.Undef, @out_1115);
return default;
}, 0, "", true);
Call(G("requestAnimationFrame"), V.Undef, fade_1106);
return default;
}, 0, "transition", false);
poolScene_592 = Fn((V _self1130, int _argc1131, V _a1133, V _a1134, V _a1135, V _a1136, V[] _rest1132) => {
V k_1137 = default;
V v_1138 = default;
V tr_1139 = default;
double pts_1140 = 0;
double PX_1141 = 0;
double PY_1142 = 0;
double RX_1143 = 0;
double RY_1144 = 0;
double TB_1145 = 0;
double IR_1146 = 0;
double WY_1147 = 0;
double LX_1148 = 0;
V ell_1149 = default;
JsStrBuf b_1150 = null;
V R_1151 = default;
V water_1152 = default;
V duck_1153 = default;
V ballS_1154 = default;
V duckG_1155 = default;
V ballG_1156 = default;
double YW_1157 = 0;
V splG_1158 = default;
V wc_1159 = default;
V waterF_1160 = default;
V ringG_1161 = default;
V rings_1162 = default;
V front_1163 = default;
V spillG_1164 = default;
JsStrBuf f_1165 = null;
V spots_1166 = default;
V T0p_1167 = default;
V fallAt_1168 = default;
V hitAt_1169 = default;
V fx_1170 = default;
V hit_1171 = default;
V col_1172 = default;
V jets_1173 = default;
double nj_1174 = 0;
V crown_1175 = default;
V shakeG_1176 = default;
V boom_1177 = default;
if (_self1130.IsNullish) _self1130 = GlobalV;
boom_1177 = Fn((V _self1178, int _argc1179, V t_1185, V _a1182, V _a1183, V _a1184, V[] _rest1180) => {
if (_self1178.IsNullish) _self1178 = GlobalV;
Invoke(SFX_20, "splash");
if (GtN(k_1137, 0.5)) {
Call(G("setTimeout"), V.Undef, Get(SFX_20, "splash"), ((V)(120D)));
}
if (GtN(k_1137, 0.85)) {
Call(G("setTimeout"), V.Undef, Get(SFX_20, "splash"), ((V)(260D)));
}
Set(st_583, "shake", ((V)((2D + (12D * ToNum(k_1137))))));
Invoke(ctx_512, "burst", ((V)(LX_1148)), ((V)((WY_1147 - 6D))), ((V)("drop")), ((V)(Round((24D + (110D * ToNum(k_1137)))))), NewObj(5).Put("v", ((V)((170D + (340D * ToNum(k_1137)))))).Put("spread", ((V)(1.4))).Put("life", ((V)((0.9 + (0.7 * ToNum(k_1137)))))).Put("g", ((V)(520D))).Put("k", ((V)((1D + (0.6 * ToNum(k_1137)))))).V);
Invoke(ctx_512, "burst", ((V)(LX_1148)), ((V)(WY_1147)), ((V)("drop")), ((V)(Round((10D + (30D * ToNum(k_1137)))))), NewObj(6).Put("v", ((V)((100D + (150D * ToNum(k_1137)))))).Put("spread", ((V)(3.2))).Put("life", ((V)(0.9))).Put("g", ((V)(420D))).Put("col", ((V)("#ffffff"))).Put("k", ((V)(1.2))).V);
Invoke(friends_581, "forEach", Fn((V _self1178, int _argc1186, V fr_1192, V i_1193, V _a1190, V _a1191, V[] _rest1187) => {
double tx_1194 = 0;
double ty_1195 = 0;
V reach_1196 = default;
double T_1197 = 0;
tx_1194 = (ToNum(Get(fr_1192, "x")) - LX_1148);
ty_1195 = ((ToNum(Get(fr_1192, "y")) - 60D) - WY_1147);
reach_1196 = (Truthy(Get(fr_1192, "in")) ? ((V)(1D)) : Call(cl_17, V.Undef, ((V)(((ToNum(k_1137) - 0.2) / 0.6))), ((V)(0D)), ((V)(1D))));
T_1197 = (0.42 + (System.Math.Abs(tx_1194) / 1400D));
if (GtN(reach_1196, 0D)) {
double vx_1198 = 0;
double vy_1199 = 0;
vx_1198 = (tx_1194 / T_1197);
vy_1199 = ((ty_1195 - (((0.5 * 520D) * T_1197) * T_1197)) / T_1197);
Invoke(ctx_512, "burst", ((V)((LX_1148 + (Sign(tx_1194) * 14D)))), ((V)((WY_1147 - 8D))), ((V)("drop")), ((V)(Round((6D + (26D * ToNum(reach_1196)))))), NewObj(6).Put("v", ((V)(Hypot(vx_1198, vy_1199)))).Put("dir", ((V)(FdLibm.Atan2(vy_1199, vx_1198)))).Put("spread", ((V)(0.22))).Put("life", ((V)((T_1197 * 1.25)))).Put("g", ((V)(520D))).Put("k", ((V)((1D + (0.5 * ToNum(k_1137)))))).V);
}
Set(fr_1192, "hitAt", Add(t_1185, ((V)((Truthy(Get(fr_1192, "in")) ? 120D : (T_1197 * 1000D))))));
Set(fr_1192, "knock", ((Truthy(Get(fr_1192, "in")) ? GeN(k_1137, 0.6) : GeN(k_1137, 0.85)) ? V.True : V.False));
Call(G("setTimeout"), V.Undef, Fn((V _self1178, int _argc1220, V _a1222, V _a1223, V _a1224, V _a1225, V[] _rest1221) => {
if (Truthy(((GeN(k_1137, 0.3) ? V.True : V.False) is var _t1226 && Truthy(_t1226) ? _t1226 : Get(fr_1192, "in")))) {
Set(fr_1192, "wet", ((V)(1D)));
Set(Get(Get(Get(fr_1192, "c"), "host"), "style"), "filter", ((V)("saturate(1.35) brightness(0.88) contrast(1.05)")));
Invoke(Get(fr_1192, "c"), "play", ((V)((Truthy(Get(fr_1192, "knock")) ? "surprised" : (GeN(k_1137, 0.3) ? "surprised" : "happy")))));
Call(G("setTimeout"), V.Undef, Fn((V _self1178, int _argc1233, V _a1235, V _a1236, V _a1237, V _a1238, V[] _rest1234) => {
return Invoke(Get(fr_1192, "c"), "play", ((V)("happy")));
}, 0, "", true), ((V)(1500D)));
Invoke(ctx_512, "burst", Get(fr_1192, "x"), ((V)((ToNum(Get(fr_1192, "y")) - 50D))), ((V)("drop")), ((V)(Round((14D + (30D * ToNum(k_1137)))))), NewObj(5).Put("v", ((V)((160D + (80D * ToNum(k_1137)))))).Put("spread", TAU_21).Put("life", ((V)(0.7))).Put("g", ((V)(400D))).Put("k", ((V)(1.4))).V);
Invoke(ctx_512, "burst", Get(fr_1192, "x"), ((V)((ToNum(Get(fr_1192, "y")) - 50D))), ((V)("drop")), ((V)(8D)), NewObj(6).Put("v", ((V)(90D))).Put("spread", TAU_21).Put("life", ((V)(0.6))).Put("g", ((V)(300D))).Put("col", ((V)("#ffffff"))).Put("k", ((V)(1.6))).V);
if (Truthy((Get(fr_1192, "knock") is var _t1239 && !Truthy(_t1239) ? _t1239 : (!(Truthy(Get(fr_1192, "in"))) ? V.True : V.False)))) {
Invoke(SFX_20, "thud");
}
} else {
Invoke(Get(fr_1192, "c"), "play", ((V)("happy")));
}
return default;
}, 0, "", true), ((V)(Max(0D, (ToNum(Get(fr_1192, "hitAt")) - ToNum(t_1185))))));
return default;
}, 2, "", true));
if (GtN(k_1137, 0.6)) {
{
double i_1240 = 0;
i_1240 = 0D;
while (true) {
if (!((i_1240 < Round((4D + ((8D * (ToNum(k_1137) - 0.6)) * 2D)))))) break;
V e_1242 = default;
e_1242 = Call(S_16, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_19, V.Undef, ((V)((40D + (ToNum(Invoke(G("Math"), "random")) * (ToNum(W_515) - 80D))))))).Put("cy", Call(r2_19, V.Undef, ((V)((40D + (ToNum(Invoke(G("Math"), "random")) * (ToNum(H_516) - 100D))))))).Put("r", Call(r2_19, V.Undef, ((V)((8D + (ToNum(Invoke(G("Math"), "random")) * 18D)))))).Put("fill", ((V)("#dff6ff"))).Put("opacity", ((V)(0.5))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2D))).V, hud_534);
Call(G("setTimeout"), V.Undef, Fn((V _self1178, int _argc1249, V _a1251, V _a1252, V _a1253, V _a1254, V[] _rest1250) => {
return Invoke(e_1242, "remove");
}, 0, "", true), ((V)((1600D + (ToNum(Invoke(G("Math"), "random")) * 800D)))));
i_1240++;
}
}
}
Call(G("setTimeout"), V.Undef, Fn((V _self1178, int _argc1261, V _a1263, V _a1264, V _a1265, V _a1266, V[] _rest1262) => {
Invoke(ctx_512, "toast", GetIdx(tr_1139, 1D), ((V)((ToNum(W_515) / 2D))), ((V)(70D)), GetIdx(tr_1139, 2D), (true ? V.True : V.False));
Invoke(ctx_512, "add", ((V)(pts_1140)), ((V)((ToNum(W_515) / 2D))), ((V)(124D)), ((V)(JsStrBuf.Begin().S("+").N(pts_1140).End())), GetIdx(tr_1139, 2D));
if (GtN(k_1137, 0.55)) {
Invoke(SFX_20, "score");
}
return default;
}, 0, "", true), ((V)(520D)));
return default;
}, 1, "boom", false);
k_1137 = Set(st_583, "k", Call(cl_17, V.Undef, ((V)(((ToNum(Get(st_583, "lipV")) - 25D) / 85D))), ((V)(0D)), ((V)(1.15))));
v_1138 = Get(st_583, "lipV");
tr_1139 = Call(tierOf_59, V.Undef, v_1138);
pts_1140 = (Round(ToNum(v_1138)) * 10D);
PX_1141 = 390D;
PY_1142 = 244D;
RX_1143 = 186D;
RY_1144 = 44D;
TB_1145 = 19D;
IR_1146 = 24D;
WY_1147 = (PY_1142 + 9D);
LX_1148 = 370D;
ell_1149 = Fn((V _self1130, int _argc1267, V cx_1273, V cy_1274, V rx_1275, V ry_1276, V[] _rest1268) => {
V a_1277 = default;
a_1277 = (_argc1267 > 4 ? _rest1268[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(r2_19, V.Undef, cx_1273)).S("\" cy=\"").V(Call(r2_19, V.Undef, cy_1274)).S("\" rx=\"").V(Call(r2_19, V.Undef, rx_1275)).S("\" ry=\"").V(Call(r2_19, V.Undef, ry_1276)).S("\" ").V(a_1277).S("/>").End()));
}, 5, "", true);
b_1150 = new JsStrBuf(string.Concat("<defs><linearGradient id=\"ygpSky\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#6fc0ff\"/><stop offset=\"0.7\" stop-color=\"#c4e8ff\"/><stop offset=\"1\" stop-color=\"#e6f6ff\"/></linearGradient>", "<linearGradient id=\"ygpGr\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#9fdc6e\"/><stop offset=\"1\" stop-color=\"#5aaa48\"/></linearGradient><linearGradient id=\"ygpW\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#a6ecff\"/><stop offset=\"1\" stop-color=\"#3ea8ea\"/></linearGradient>", "<linearGradient id=\"ygpBl\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#6cbcff\"/><stop offset=\"0.45\" stop-color=\"#2a86e6\"/><stop offset=\"1\" stop-color=\"#1a5fb0\"/></linearGradient><linearGradient id=\"ygpWt\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.5\" stop-color=\"#f2f6fb\"/><stop offset=\"1\" stop-color=\"#c9d6e6\"/></linearGradient>", "<radialGradient id=\"ygpSun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fffbe0\"/><stop offset=\"0.5\" stop-color=\"#ffe680\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#ffe680\" stop-opacity=\"0\"/></radialGradient></defs>"));
b_1150.S("<rect x=\"-20\" y=\"-20\" width=\"").V(Add(W_515, ((V)(40D)))).S("\" height=\"260\" fill=\"url(#ygpSky)\"/><circle cx=\"676\" cy=\"56\" r=\"70\" fill=\"url(#ygpSun)\"/><circle cx=\"676\" cy=\"56\" r=\"24\" fill=\"#fff3a0\"/>");
Invoke(Arr(Arr(((V)(110D)), ((V)(58D)), ((V)(0.9))), Arr(((V)(300D)), ((V)(38D)), ((V)(0.65))), Arr(((V)(520D)), ((V)(74D)), ((V)(0.75))), Arr(((V)(760D)), ((V)(30D)), ((V)(0.55)))), "forEach", Fn((V _self1130, int _argc1278, V _a1280, V _a1281, V _a1282, V _a1283, V[] _rest1279) => {
V x_1286 = default;
V y_1288 = default;
V s_1290 = default;
{ V _t1284 = ListOf(_a1280);
{ V _t1285 = GetIdx(_t1284, 0D);
x_1286 = _t1285; }
{ V _t1287 = GetIdx(_t1284, 1D);
y_1288 = _t1287; }
{ V _t1289 = GetIdx(_t1284, 2D);
s_1290 = _t1289; }
}
b_1150.S("<g transform=\"translate(").V(x_1286).S(" ").V(y_1288).S(") scale(").V(s_1290).S(")\" fill=\"#ffffff\" opacity=\"0.95\"><circle cx=\"-26\" cy=\"4\" r=\"18\"/><circle cx=\"0\" cy=\"-8\" r=\"25\"/><circle cx=\"27\" cy=\"2\" r=\"19\"/><circle cx=\"10\" cy=\"10\" r=\"18\"/><circle cx=\"-12\" cy=\"11\" r=\"16\"/></g>");
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)(30D)), ((V)(1.1))), Arr(((V)(130D)), ((V)(0.85))), Arr(((V)(250D)), ((V)(1D))), Arr(((V)(540D)), ((V)(0.9))), Arr(((V)(650D)), ((V)(1.15))), Arr(((V)(760D)), ((V)(0.9)))), "forEach", Fn((V _self1130, int _argc1291, V _a1293, V _a1294, V _a1295, V _a1296, V[] _rest1292) => {
V x_1299 = default;
V s_1301 = default;
{ V _t1297 = ListOf(_a1293);
{ V _t1298 = GetIdx(_t1297, 0D);
x_1299 = _t1298; }
{ V _t1300 = GetIdx(_t1297, 1D);
s_1301 = _t1300; }
}
b_1150.S("<g transform=\"translate(").V(x_1299).S(" 196) scale(").V(s_1301).S(")\"><rect x=\"-6\" y=\"-60\" width=\"12\" height=\"62\" rx=\"3\" fill=\"#8a5a34\"/><circle cx=\"-22\" cy=\"-70\" r=\"28\" fill=\"#57a854\"/><circle cx=\"20\" cy=\"-74\" r=\"30\" fill=\"#57a854\"/><circle cx=\"0\" cy=\"-98\" r=\"32\" fill=\"#6cbb5c\"/><circle cx=\"-10\" cy=\"-106\" r=\"13\" fill=\"#8fd47a\" opacity=\"0.85\"/></g>");
return default;
}, 1, "", true));
b_1150.S("<rect x=\"-20\" y=\"166\" width=\"").V(Add(W_515, ((V)(40D)))).S("\" height=\"6\" fill=\"#f3e8da\"/><rect x=\"-20\" y=\"188\" width=\"").V(Add(W_515, ((V)(40D)))).S("\" height=\"6\" fill=\"#f3e8da\"/>");
{
double x_1302 = 0;
x_1302 = (-10D);
while (true) {
if (!(Lt(((V)(x_1302)), Add(W_515, ((V)(20D)))))) break;
b_1150.S("<path d=\"M").N(x_1302).S(" 210V164L").N((x_1302 + 7D)).S(" 156L").N((x_1302 + 14D)).S(" 164V210Z\" fill=\"#fffaf2\" stroke=\"#e2cfb8\" stroke-width=\"1\"/>");
x_1302 = (x_1302 + 20D);
}
}
b_1150.S("<rect x=\"-20\" y=\"206\" width=\"").V(Add(W_515, ((V)(40D)))).S("\" height=\"").N((ToNum(H_516) - 186D)).S("\" fill=\"url(#ygpGr)\"/>");
{
double i_1304 = 0;
i_1304 = 0D;
while (true) {
if (!((i_1304 < 9D))) break;
b_1150.S("<path d=\"M").N(((i_1304 * 100D) - 60D)).S(" ").V(Add(H_516, ((V)(10D)))).S("L").N(((i_1304 * 100D) + 10D)).S(" 206H").N(((i_1304 * 100D) + 50D)).S("L").N(((i_1304 * 100D) - 10D)).S(" ").V(Add(H_516, ((V)(10D)))).S("Z\" fill=\"#ffffff\" opacity=\"0.05\"/>");
i_1304++;
}
}
R_1151 = Call(rnd_36, V.Undef, ((V)(42D)));
{
double i_1306 = 0;
i_1306 = 0D;
while (true) {
if (!((i_1306 < 70D))) break;
double x_1308 = 0;
double y_1309 = 0;
double q_1310 = 0;
x_1308 = (ToNum(Call(R_1151, V.Undef)) * ToNum(W_515));
y_1309 = (212D + (ToNum(Call(R_1151, V.Undef)) * (ToNum(H_516) - 212D)));
q_1310 = (0.7 + ((y_1309 - 206D) / 150D));
b_1150.S("<path d=\"M").V(Call(r2_19, V.Undef, ((V)((x_1308 - (3D * q_1310)))))).S(" ").V(Call(r2_19, V.Undef, ((V)(y_1309)))).S("l").V(Call(r2_19, V.Undef, ((V)((2D * q_1310))))).S(" ").V(Call(r2_19, V.Undef, ((V)(((-7D) * q_1310))))).S("l").V(Call(r2_19, V.Undef, ((V)((2D * q_1310))))).S(" ").V(Call(r2_19, V.Undef, ((V)((5D * q_1310))))).S("l").V(Call(r2_19, V.Undef, ((V)((2D * q_1310))))).S(" ").V(Call(r2_19, V.Undef, ((V)(((-8D) * q_1310))))).S("l").V(Call(r2_19, V.Undef, ((V)((2D * q_1310))))).S(" ").V(Call(r2_19, V.Undef, ((V)((8D * q_1310))))).S("Z\" fill=\"#4f9a3e\" opacity=\"0.55\"/>");
i_1306++;
}
}
Invoke(Arr(Arr(((V)(60D)), ((V)(214D))), Arr(((V)(200D)), ((V)(212D))), Arr(((V)(470D)), ((V)(213D))), Arr(((V)(600D)), ((V)(214D))), Arr(((V)(720D)), ((V)(212D)))), "forEach", Fn((V _self1130, int _argc1311, V _a1313, V i_1317, V _a1315, V _a1316, V[] _rest1312) => {
V x_1320 = default;
V y_1322 = default;
{ V _t1318 = ListOf(_a1313);
{ V _t1319 = GetIdx(_t1318, 0D);
x_1320 = _t1319; }
{ V _t1321 = GetIdx(_t1318, 1D);
y_1322 = _t1321; }
}
{
double j_1323 = 0;
j_1323 = 0D;
while (true) {
if (!((j_1323 < 6D))) break;
double fx_1325 = 0;
double fy_1326 = 0;
fx_1325 = (ToNum(Add(x_1320, ((V)((j_1323 * 9D))))) - 22D);
fy_1326 = ((ToNum(y_1322) - 6D) - ((j_1323 % 2D) * 5D));
b_1150.S("<path d=\"M").N(fx_1325).S(" ").V(Add(y_1322, ((V)(2D)))).S("V").N(fy_1326).S("\" stroke=\"#4f9a3e\" stroke-width=\"1.6\"/><circle cx=\"").N(fx_1325).S("\" cy=\"").N(fy_1326).S("\" r=\"3.2\" fill=\"").V(GetIdx(Arr(((V)("#ff8fc8")), ((V)("#fff3a8")), ((V)("#ffffff")), ((V)("#d9c8ff")), ((V)("#ffb0a0"))), (ToNum(Add(i_1317, ((V)(j_1323)))) % 5D))).S("\"/>");
j_1323++;
}
}
return default;
}, 2, "", true));
b_1150.S("<g transform=\"translate(250 350) rotate(-4)\"><rect x=\"-46\" y=\"-12\" width=\"92\" height=\"26\" rx=\"4\" fill=\"#ffffff\"/><path d=\"M-46 -6H46M-46 4H46\" stroke=\"#ff7a8a\" stroke-width=\"5\"/></g><g fill=\"#ffd84a\" stroke=\"#d09a20\" stroke-width=\"1.2\"><ellipse cx=\"36\" cy=\"350\" rx=\"9\" ry=\"4.5\"/><ellipse cx=\"56\" cy=\"353\" rx=\"9\" ry=\"4.5\"/></g>");
b_1150.S("<path d=\"M-10 300C40 312 70 290 110 296S196 262 212 240\" fill=\"none\" stroke=\"#3a9a4a\" stroke-width=\"6\" stroke-linecap=\"round\"/><path d=\"M-10 300C40 312 70 290 110 296S196 262 212 240\" fill=\"none\" stroke=\"#6fcf6a\" stroke-width=\"2\" stroke-linecap=\"round\" opacity=\"0.7\"/>");
b_1150.S("<g transform=\"translate(742 302)\"><path d=\"M-44 0V-10M44 0V-10M-44 -10H18L40 -38\" stroke=\"#e8e0d4\" stroke-width=\"3.4\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"M-42 -14H18L38 -40\" stroke=\"#5cb8ff\" stroke-width=\"9\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/></g>");
b_1150.V(Call(ell_1149, V.Undef, ((V)((PX_1141 + 6D))), ((V)(((PY_1142 + (3D * TB_1145)) + 6D))), ((V)((RX_1143 + 18D))), ((V)((RY_1144 * 0.7))), ((V)("fill=\"#2a4a20\" opacity=\"0.22\""))));
b_1150.S("<path d=\"M").N((PX_1141 - RX_1143)).S(" ").N(PY_1142).S("A").N(RX_1143).S(" ").N(RY_1144).S(" 0 1 1 ").N((PX_1141 + RX_1143)).S(" ").N(PY_1142).S("A").N(RX_1143).S(" ").N(RY_1144).S(" 0 1 1 ").N((PX_1141 - RX_1143)).S(" ").N(PY_1142).S("Z\" fill=\"#3f9af0\"/>").V(Call(ell_1149, V.Undef, ((V)(PX_1141)), ((V)((PY_1142 - 3D))), ((V)((RX_1143 - 9D))), ((V)((RY_1144 - 4D))), ((V)("fill=\"none\" stroke=\"#9ad6ff\" stroke-width=\"3\" opacity=\"0.6\""))));
b_1150.V(Call(ell_1149, V.Undef, ((V)(PX_1141)), ((V)((PY_1142 + 2D))), ((V)((RX_1143 - IR_1146))), ((V)((RY_1144 - 7D))), ((V)("fill=\"#1b5fae\""))));
water_1152 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V);
Set(water_1152, "innerHTML", ((V)(JsStrBuf.Begin().V(Add(Call(ell_1149, V.Undef, ((V)(PX_1141)), ((V)(WY_1147)), ((V)(((RX_1143 - IR_1146) - 3D))), ((V)((RY_1144 - 13D))), ((V)("fill=\"url(#ygpW)\""))), Invoke(Invoke(Arr(Arr(((V)((-70D))), ((V)((-4D)))), Arr(((V)(40D)), ((V)(6D))), Arr(((V)((-10D))), ((V)((-8D)))), Arr(((V)(80D)), ((V)((-2D)))), Arr(((V)((-40D))), ((V)(8D)))), "map", Fn((V _self1130, int _argc1327, V _a1329, V i_1333, V _a1331, V _a1332, V[] _rest1328) => {
V x_1336 = default;
V y_1338 = default;
{ V _t1334 = ListOf(_a1329);
{ V _t1335 = GetIdx(_t1334, 0D);
x_1336 = _t1335; }
{ V _t1337 = GetIdx(_t1334, 1D);
y_1338 = _t1337; }
}
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N((ToNum(Add(((V)(PX_1141)), x_1336)) - 16D)).S(" ").V(Add(((V)(WY_1147)), y_1338)).S("q8 -4 16 0t16 0\" stroke=\"#ffffff\" stroke-width=\"2\" fill=\"none\" opacity=\"0.6\" stroke-linecap=\"round\" class=\"ygs-bob\" style=\"animation-delay:").N((ToNum(i_1333) * 0.3)).S("s\"/>").End()));
}, 2, "", true)), "join", ((V)(""))))).S("<g opacity=\"0.35\" transform=\"translate(").N((PX_1141 + 60D)).S(" ").N((WY_1147 + 4D)).S(")\"><path d=\"M-4.2 0Q-1 -3 3 0Q-1 3 -4.2 0Z\" fill=\"#ff8a3a\" transform=\"scale(1.6)\"/></g><g opacity=\"0.35\" transform=\"translate(").N((PX_1141 - 90D)).S(" ").N((WY_1147 + 2D)).S(") scale(1.5)\"><path d=\"M0 -3.6L1 -1.2L3.5 -1.1L1.5 0.6L2.2 3.1L0 1.7L-2.2 3.1L-1.5 0.6L-3.5 -1.1L-1 -1.2Z\" fill=\"#ffd23a\"/></g>").End())));
duck_1153 = ((V)("<g class=\"ygs-bob\"><ellipse cx=\"0\" cy=\"2\" rx=\"13\" ry=\"4\" fill=\"#1a5fb0\" opacity=\"0.25\"/><path d=\"M-12 -2Q-12 -12 0 -12Q8 -12 10 -6Q12 -2 6 0H-8Q-12 0 -12 -2Z\" fill=\"#ffd84a\" stroke=\"#d09a20\" stroke-width=\"1.2\"/><circle cx=\"4\" cy=\"-17\" r=\"7\" fill=\"#ffd84a\" stroke=\"#d09a20\" stroke-width=\"1.2\"/><path d=\"M10 -17l6 1l-6 3Z\" fill=\"#ff8a3a\"/><circle cx=\"6\" cy=\"-19\" r=\"1.3\" fill=\"#2a1a10\"/><path d=\"M-8 -6q5 -3 9 0\" stroke=\"#e8b82a\" stroke-width=\"1.5\" fill=\"none\"/></g>"));
ballS_1154 = ((V)("<g class=\"ygs-bob\" style=\"animation-delay:.6s\"><circle cy=\"-10\" r=\"11\" fill=\"#ffffff\" stroke=\"#c8c0b4\" stroke-width=\"1.2\"/><path d=\"M0 -21A11 11 0 0 1 11 -10L0 -10Z\" fill=\"#ff7a8a\"/><path d=\"M0 1A11 11 0 0 1 -11 -10L0 -10Z\" fill=\"#5cb8ff\"/><path d=\"M-11 -10A11 11 0 0 1 0 -21L0 -10Z\" fill=\"#ffd84a\"/></g>"));
duckG_1155 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N((PX_1141 - 112D)).S(" ").N((WY_1147 + 2D)).S(")").End()))).V);
ballG_1156 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N((PX_1141 + 122D)).S(" ").N((WY_1147 + 2D)).S(")").End()))).V);
Set(duckG_1155, "innerHTML", duck_1153);
Set(ballG_1156, "innerHTML", ballS_1154);
Set(scB_526, "innerHTML", ((V)(b_1150.Str)));
Invoke(scB_526, "appendChild", water_1152);
YW_1157 = (WY_1147 + 2D);
splG_1158 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, scF_532);
wc_1159 = Call(S_16, V.Undef, ((V)("clipPath")), NewObj(1).Put("id", ((V)("ygpWc"))).V, scF_532);
Call(S_16, V.Undef, ((V)("rect")), NewObj(4).Put("x", ((V)((-20D)))).Put("y", ((V)(YW_1157))).Put("width", Add(W_515, ((V)(40D)))).Put("height", H_516).V, wc_1159);
waterF_1160 = Invoke(water_1152, "cloneNode", (true ? V.True : V.False));
Invoke(waterF_1160, "setAttribute", ((V)("clip-path")), ((V)("url(#ygpWc)")));
Invoke(scF_532, "appendChild", waterF_1160);
ringG_1161 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, scF_532);
rings_1162 = Invoke(Arr(((V)(LX_1148)), ((V)(506D))), "map", Fn((V _self1130, int _argc1339, V x_1345, V _a1342, V _a1343, V _a1344, V[] _rest1340) => {
return Call(S_16, V.Undef, ((V)("ellipse")), NewObj(9).Put("cx", x_1345).Put("cy", ((V)((YW_1157 + 1D)))).Put("rx", ((V)(32D))).Put("ry", ((V)(6.5))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0D))).Put("class", ((V)("ygs-bob"))).V, ringG_1161);
}, 1, "", true));
Invoke(scF_532, "appendChild", duckG_1155);
Invoke(scF_532, "appendChild", ballG_1156);
front_1163 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, scF_532);
spillG_1164 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, scF_532);
f_1165 = new JsStrBuf("");
f_1165.S("<path d=\"M").N((PX_1141 - RX_1143)).S(" ").N(PY_1142).S("A").N(RX_1143).S(" ").N(RY_1144).S(" 0 0 0 ").N((PX_1141 + RX_1143)).S(" ").N(PY_1142).S("L").N(((PX_1141 + RX_1143) - IR_1146)).S(" ").N((PY_1142 + 2D)).S("A").N((RX_1143 - IR_1146)).S(" ").N((RY_1144 - 7D)).S(" 0 0 1 ").N(((PX_1141 - RX_1143) + IR_1146)).S(" ").N((PY_1142 + 2D)).S("Z\" fill=\"#3f9af0\"/>");
f_1165.S("<path d=\"M").N(((PX_1141 - RX_1143) + 8D)).S(" ").N((PY_1142 + 6D)).S("A").N((RX_1143 - 8D)).S(" ").N((RY_1144 - 2D)).S(" 0 0 0 ").N(((PX_1141 + RX_1143) - 8D)).S(" ").N((PY_1142 + 6D)).S("\" fill=\"none\" stroke=\"#9ad6ff\" stroke-width=\"3\" opacity=\"0.7\"/>");
Invoke(Arr(Arr(((V)("url(#ygpBl)")), ((V)(0D))), Arr(((V)("url(#ygpWt)")), ((V)(1D))), Arr(((V)("url(#ygpBl)")), ((V)(2D)))), "forEach", Fn((V _self1130, int _argc1346, V _a1348, V _a1349, V _a1350, V _a1351, V[] _rest1347) => {
double yt_1357 = 0;
double yb_1358 = 0;
V c_1354 = default;
V j_1356 = default;
{ V _t1352 = ListOf(_a1348);
{ V _t1353 = GetIdx(_t1352, 0D);
c_1354 = _t1353; }
{ V _t1355 = GetIdx(_t1352, 1D);
j_1356 = _t1355; }
}
yt_1357 = ((PY_1142 + 4D) + (ToNum(j_1356) * TB_1145));
yb_1358 = (yt_1357 + TB_1145);
f_1165.S("<path d=\"M").N((PX_1141 - RX_1143)).S(" ").N(yt_1357).S("A").N(RX_1143).S(" ").N(RY_1144).S(" 0 0 0 ").N((PX_1141 + RX_1143)).S(" ").N(yt_1357).S("L").N((PX_1141 + RX_1143)).S(" ").N(yb_1358).S("A").N(RX_1143).S(" ").N(RY_1144).S(" 0 0 1 ").N((PX_1141 - RX_1143)).S(" ").N(yb_1358).S("Z\" fill=\"").V(c_1354).S("\" stroke=\"").S((SEqN(j_1356, 1D) ? "#c9d6e6" : "#1a5fb0")).S("\" stroke-width=\"1\"/>").S("<circle cx=\"").N((PX_1141 - RX_1143)).S("\" cy=\"").N((yt_1357 + (TB_1145 / 2D))).S("\" r=\"").N((TB_1145 / 2D)).S("\" fill=\"").V(c_1354).S("\"/><circle cx=\"").N((PX_1141 + RX_1143)).S("\" cy=\"").N((yt_1357 + (TB_1145 / 2D))).S("\" r=\"").N((TB_1145 / 2D)).S("\" fill=\"").V(c_1354).S("\"/>").S("<path d=\"M").N(((PX_1141 - RX_1143) + 12D)).S(" ").N((yt_1357 + 5D)).S("A").N((RX_1143 - 12D)).S(" ").N(RY_1144).S(" 0 0 0 ").N(((PX_1141 + RX_1143) - 12D)).S(" ").N((yt_1357 + 5D)).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"2.6\" opacity=\"").N((SEqN(j_1356, 1D) ? 0.9 : 0.45)).S("\"/>");
return default;
}, 1, "", true));
Invoke(Arr(((V)((-0.75))), ((V)((-0.42))), ((V)((-0.1))), ((V)(0.22)), ((V)(0.55)), ((V)(0.85))), "forEach", Fn((V _self1130, int _argc1359, V u_1365, V i_1366, V _a1363, V _a1364, V[] _rest1360) => {
double x_1367 = 0;
double y_1368 = 0;
double sc_1369 = 0;
x_1367 = (PX_1141 + ((ToNum(u_1365) * RX_1143) * 0.92));
y_1368 = (((PY_1142 + 4D) + (TB_1145 * 1.5)) + ((RY_1144 * System.Math.Sqrt((1D - ((ToNum(u_1365) * ToNum(u_1365)) * 0.85)))) * 0.98));
sc_1369 = (1.25 * System.Math.Sqrt((1D - ((ToNum(u_1365) * ToNum(u_1365)) * 0.7))));
f_1165.S("<g transform=\"translate(").V(Call(r2_19, V.Undef, ((V)(x_1367)))).S(" ").V(Call(r2_19, V.Undef, ((V)(y_1368)))).S(") scale(").V(Call(r2_19, V.Undef, ((V)(sc_1369)))).S(")\">").S((NumTruthy((ToNum(i_1366) % 2D)) ? "<path d=\"M0 -3.6L1 -1.2L3.5 -1.1L1.5 0.6L2.2 3.1L0 1.7L-2.2 3.1L-1.5 0.6L-3.5 -1.1L-1 -1.2Z\" fill=\"#ffd23a\" stroke=\"#e8a81a\" stroke-width=\"0.3\"/>" : "<path d=\"M-4.2 0Q-1 -3 3 0Q-1 3 -4.2 0Z\" fill=\"#ff8a3a\"/><path d=\"M2.6 0L5.6 -2.2V2.2Z\" fill=\"#ff8a3a\"/><circle cx=\"-2.2\" cy=\"-0.5\" r=\"0.45\" fill=\"#1d2a3a\"/>")).S("</g>");
return default;
}, 2, "", true));
f_1165.S("<circle cx=\"").N((PX_1141 + (RX_1143 * 0.7))).S("\" cy=\"").N((((PY_1142 + 4D) + (TB_1145 * 0.5)) + (RY_1144 * 0.7))).S("\" r=\"2.6\" fill=\"#f6f9fc\" stroke=\"#9aa1ad\" stroke-width=\"0.8\"/>");
Set(front_1163, "innerHTML", ((V)(f_1165.Str)));
spots_1166 = Arr(NewObj(4).Put("x", ((V)(136D))).Put("y", ((V)(342D))).Put("side", ((V)((-1D)))).Put("in", ((V)(0D))).V, NewObj(4).Put("x", ((V)(650D))).Put("y", ((V)(342D))).Put("side", ((V)(1D))).Put("in", ((V)(0D))).V, NewObj(4).Put("x", ((V)(506D))).Put("y", ((V)((WY_1147 + 36D)))).Put("side", ((V)(1D))).Put("in", ((V)(1D))).V);
Invoke(friends_581, "forEach", Fn((V _self1130, int _argc1370, V fr_1376, V i_1377, V _a1374, V _a1375, V[] _rest1371) => {
return Object_assign(fr_1376, GetK(spots_1166, i_1377), NewObj(8).Put("size", ((V)(128D))).Put("wet", ((V)(0D))).Put("hitAt", ((V)(double.PositiveInfinity))).Put("knock", ((V)(0D))).Put("rot", ((V)(0D))).Put("dx", ((V)(0D))).Put("dy", ((V)(0D))).Put("dripT", ((V)(0D))).V);
}, 2, "", true));
Invoke(friends_581, "forEach", Fn((V _self1130, int _argc1378, V fr_1384, V _a1381, V _a1382, V _a1383, V[] _rest1379) => {
Invoke(Get(fr_1384, "c"), "hide", (false ? V.True : V.False));
Invoke(Get(fr_1384, "c"), "yaw", ((V)((Truthy(Get(fr_1384, "in")) ? 0D : (LtN(Get(fr_1384, "side"), 0D) ? 22D : (-22D))))));
Invoke(Get(fr_1384, "c"), "set", Get(fr_1384, "x"), Get(fr_1384, "y"), Get(fr_1384, "size"));
Invoke(Get(fr_1384, "c"), "depth", ((V)(0D)));
Invoke(Get(fr_1384, "c"), "play", ((V)("idle")));
return default;
}, 1, "", true));
Invoke(me_576, "yaw", ((V)(0D)));
Invoke(me_576, "rot", ((V)(0D)));
Invoke(me_576, "depth", ((V)(0D)));
Invoke(me_576, "hide", (false ? V.True : V.False));
Invoke(me_576, "play", ((V)("idle")));
Invoke(GetIdx(rings_1162, 1D), "setAttribute", ((V)("opacity")), ((V)(0.85)));
T0p_1167 = tNow_580;
fallAt_1168 = Add(T0p_1167, ((V)(380D)));
hitAt_1169 = Add(fallAt_1168, ((V)(560D)));
fx_1170 = NewObj(4).Put("ring", Arr()).Put("drop", Arr()).Put("sheets", Arr()).Put("spills", Arr()).V;
hit_1171 = (false ? V.True : V.False);
col_1172 = Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M-").V(Call(r2_19, V.Undef, ((V)((16D + (14D * ToNum(k_1137))))))).S(" 0C-").V(Call(r2_19, V.Undef, ((V)((18D + (16D * ToNum(k_1137))))))).S(" -55 -9 -96 0 -100C9 -96 ").V(Call(r2_19, V.Undef, ((V)((18D + (16D * ToNum(k_1137))))))).S(" -55 ").V(Call(r2_19, V.Undef, ((V)((16D + (14D * ToNum(k_1137))))))).S(" 0Z").End()))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0D))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N(LX_1148).S(" ").N(WY_1147).S(")").End()))).V, splG_1158);
jets_1173 = Arr();
nj_1174 = (2D + Round((6D * ToNum(k_1137))));
{
double j_1385 = 0;
j_1385 = 0D;
while (true) {
if (!((j_1385 < nj_1174))) break;
double a_1387 = 0;
double w_1388 = 0;
double lx_1389 = 0;
double hj_1390 = 0;
a_1387 = (((j_1385 / ToNum((((V)((nj_1174 - 1D))) is var _t1391 && Truthy(_t1391) ? _t1391 : ((V)(1D))))) - 0.5) * 2D);
w_1388 = (5D + (5D * ToNum(k_1137)));
lx_1389 = (a_1387 * (50D + (120D * ToNum(k_1137))));
hj_1390 = (((40D + (190D * ToNum(k_1137))) * (0.6 + (0.4 * System.Math.Abs(FdLibm.Sin(((j_1385 * 1.9) + 0.5)))))) / 100D);
Invoke(jets_1173, "push", NewObj(3).Put("e", Call(S_16, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((-w_1388))))).S(" 0C").V(Call(r2_19, V.Undef, ((V)((-w_1388))))).S(" -55 ").V(Call(r2_19, V.Undef, ((V)((lx_1389 - 5D))))).S(" -94 ").V(Call(r2_19, V.Undef, ((V)(lx_1389)))).S(" -100C").V(Call(r2_19, V.Undef, ((V)((lx_1389 + 5D))))).S(" -94 ").V(Call(r2_19, V.Undef, ((V)(w_1388)))).S(" -55 ").V(Call(r2_19, V.Undef, ((V)(w_1388)))).S(" 0Z").End()))).Put("fill", ((V)("#e6f8ff"))).Put("stroke", ((V)("#a8e0ff"))).Put("stroke-width", ((V)(1.2))).Put("opacity", ((V)(0D))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N(LX_1148).S(" ").N(WY_1147).S(")").End()))).V, splG_1158)).Put("hj", ((V)(hj_1390))).Put("dl", ((V)((0.03 + (System.Math.Abs(a_1387) * 0.07))))).V);
j_1385++;
}
}
crown_1175 = Call(S_16, V.Undef, ((V)("g")), NewObj(2).Put("opacity", ((V)(0D))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N(LX_1148).S(" ").N(WY_1147).S(")").End()))).V, splG_1158);
{
JsStrBuf cd_1392 = null;
double n_1393 = 0;
double cr_1394 = 0;
cd_1392 = new JsStrBuf("");
n_1393 = Round((12D + (10D * ToNum(k_1137))));
cr_1394 = (26D + (34D * ToNum(k_1137)));
{
double i_1395 = 0;
i_1395 = 0D;
while (true) {
if (!((i_1395 < n_1393))) break;
double a_1397 = 0;
double x_1398 = 0;
double y_1399 = 0;
double hh_1400 = 0;
double lean_1401 = 0;
a_1397 = ((i_1395 / n_1393) * ToNum(TAU_21));
x_1398 = (FdLibm.Cos(a_1397) * cr_1394);
y_1399 = ((FdLibm.Sin(a_1397) * cr_1394) * 0.22);
hh_1400 = ((24D + (80D * ToNum(k_1137))) * (0.6 + (0.4 * FdLibm.Sin(((i_1395 * 2.3) + 1D)))));
lean_1401 = (FdLibm.Cos(a_1397) * (10D + (30D * ToNum(k_1137))));
if ((FdLibm.Sin(a_1397) < (-0.3))) {
goto _cont1396;
}
cd_1392.S("M").V(Call(r2_19, V.Undef, ((V)((x_1398 - 6D))))).S(" ").V(Call(r2_19, V.Undef, ((V)(y_1399)))).S("Q").V(Call(r2_19, V.Undef, ((V)((x_1398 + (lean_1401 * 0.4)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((y_1399 - (hh_1400 * 0.6)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((x_1398 + lean_1401))))).S(" ").V(Call(r2_19, V.Undef, ((V)((y_1399 - hh_1400))))).S("Q").V(Call(r2_19, V.Undef, ((V)(((x_1398 + (lean_1401 * 0.5)) + 3D))))).S(" ").V(Call(r2_19, V.Undef, ((V)((y_1399 - (hh_1400 * 0.5)))))).S(" ").V(Call(r2_19, V.Undef, ((V)((x_1398 + 6D))))).S(" ").V(Call(r2_19, V.Undef, ((V)(y_1399)))).S("Z");
_cont1396: ;
i_1395++;
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(cd_1392.Str))).Put("fill", ((V)("#e6f8ff"))).Put("stroke", ((V)("#8fd6ff"))).Put("stroke-width", ((V)(1.5))).Put("stroke-linejoin", ((V)("round"))).V, crown_1175);
}
{
double i_1402 = 0;
i_1402 = 0D;
while (true) {
if (!((i_1402 < 4D))) break;
Invoke(Get(fx_1170, "ring"), "push", Call(S_16, V.Undef, ((V)("ellipse")), NewObj(8).Put("cx", ((V)(LX_1148))).Put("cy", ((V)(WY_1147))).Put("rx", ((V)(1D))).Put("ry", ((V)(1D))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)((3D - (i_1402 * 0.5))))).Put("opacity", ((V)(0D))).V, splG_1158));
i_1402++;
}
}
Invoke(Invoke(friends_581, "filter", Fn((V _self1130, int _argc1419, V fr_1425, V _a1422, V _a1423, V _a1424, V[] _rest1420) => {
return (!(Truthy(Get(fr_1425, "in"))) ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _self1130, int _argc1404, V fr_1410, V _a1407, V _a1408, V _a1409, V[] _rest1405) => {
V e0_1411 = default;
V e_1412 = default;
V x1_1413 = default;
double y1_1414 = 0;
double mx_1415 = 0;
double my_1416 = 0;
V dd_1417 = default;
V len_1418 = default;
if (LtN(k_1137, 0.3)) {
return default;
}
e0_1411 = Call(S_16, V.Undef, ((V)("path")), NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", Call(r2_19, V.Undef, ((V)((10D + (16D * ToNum(k_1137))))))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0D))).Put("stroke-dasharray", ((V)("1 999"))).V, splG_1158);
e_1412 = Call(S_16, V.Undef, ((V)("path")), NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#8fd8ff"))).Put("stroke-width", Call(r2_19, V.Undef, ((V)((6D + (12D * ToNum(k_1137))))))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0D))).Put("stroke-dasharray", ((V)("1 999"))).V, splG_1158);
x1_1413 = Add(Get(fr_1410, "x"), ((V)((ToNum(Get(fr_1410, "side")) * 10D))));
y1_1414 = (ToNum(Get(fr_1410, "y")) - 50D);
mx_1415 = (ToNum(Add(((V)(LX_1148)), x1_1413)) / 2D);
my_1416 = ((Min(WY_1147, y1_1414) - 60D) - (80D * ToNum(k_1137)));
dd_1417 = ((V)(JsStrBuf.Begin().S("M").N(LX_1148).S(" ").N(WY_1147).S("Q").V(Call(r2_19, V.Undef, ((V)(mx_1415)))).S(" ").V(Call(r2_19, V.Undef, ((V)(my_1416)))).S(" ").V(Call(r2_19, V.Undef, x1_1413)).S(" ").V(Call(r2_19, V.Undef, ((V)(y1_1414)))).End()));
Invoke(e_1412, "setAttribute", ((V)("d")), dd_1417);
Invoke(e0_1411, "setAttribute", ((V)("d")), dd_1417);
len_1418 = (Truthy(Get(e_1412, "getTotalLength")) ? Invoke(e_1412, "getTotalLength") : ((V)(400D)));
Invoke(Get(fx_1170, "sheets"), "push", NewObj(3).Put("e", e_1412).Put("len", len_1418).Put("fr", fr_1410).V, NewObj(3).Put("e", e0_1411).Put("len", len_1418).Put("fr", fr_1410).V);
return default;
}, 1, "", true));
if (GeN(k_1137, 0.5)) {
Invoke(Invoke(Arr(((V)((-0.62))), ((V)((-0.2))), ((V)(0.3)), ((V)(0.7))), "slice", ((V)(0D)), ((V)((GtN(k_1137, 0.85) ? 4D : 2D)))), "forEach", Fn((V _self1130, int _argc1426, V u_1432, V i_1433, V _a1430, V _a1431, V[] _rest1427) => {
double x_1434 = 0;
double y0_1435 = 0;
V e_1436 = default;
V pd_1437 = default;
x_1434 = (PX_1141 + (ToNum(u_1432) * RX_1143));
y0_1435 = ((PY_1142 + 4D) + ((RY_1144 * System.Math.Sqrt((1D - (ToNum(u_1432) * ToNum(u_1432))))) * 0.95));
e_1436 = Call(S_16, V.Undef, ((V)("path")), NewObj(7).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, ((V)((x_1434 - 9D))))).S(" ").V(Call(r2_19, V.Undef, ((V)(y0_1435)))).S("Q").V(Call(r2_19, V.Undef, ((V)((x_1434 - 12D))))).S(" ").V(Call(r2_19, V.Undef, ((V)((y0_1435 + 26D))))).S(" ").V(Call(r2_19, V.Undef, ((V)((x_1434 - 7D))))).S(" ").V(Call(r2_19, V.Undef, ((V)((y0_1435 + 46D))))).S("H").V(Call(r2_19, V.Undef, ((V)((x_1434 + 7D))))).S("Q").V(Call(r2_19, V.Undef, ((V)((x_1434 + 12D))))).S(" ").V(Call(r2_19, V.Undef, ((V)((y0_1435 + 26D))))).S(" ").V(Call(r2_19, V.Undef, ((V)((x_1434 + 9D))))).S(" ").V(Call(r2_19, V.Undef, ((V)(y0_1435)))).S("Z").End()))).Put("fill", ((V)("#9fe0ff"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.4))).Put("opacity", ((V)(0D))).Put("transform", ((V)("scale(1 0.01)"))).Put("transform-origin", ((V)(JsStrBuf.Begin().V(Call(r2_19, V.Undef, ((V)(x_1434)))).S("px ").V(Call(r2_19, V.Undef, ((V)(y0_1435)))).S("px").End()))).V, spillG_1164);
pd_1437 = Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_19, V.Undef, ((V)(x_1434)))).Put("cy", Call(r2_19, V.Undef, ((V)((y0_1435 + 50D))))).Put("rx", ((V)(1D))).Put("ry", ((V)(1D))).Put("fill", ((V)("#8fd6ff"))).Put("opacity", ((V)(0.7))).V, spillG_1164);
Invoke(Get(fx_1170, "spills"), "push", NewObj(3).Put("e", e_1436).Put("pd", pd_1437).Put("dl", ((V)((0.12 + (ToNum(i_1433) * 0.07))))).V);
return default;
}, 2, "", true));
}
Invoke(friends_581, "forEach", Fn((V _self1130, int _argc1438, V fr_1444, V _a1441, V _a1442, V _a1443, V[] _rest1439) => {
Set(fr_1444, "pud", Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Get(fr_1444, "x")).Put("cy", (Truthy(Get(fr_1444, "in")) ? ((V)((-99D))) : Add(Get(fr_1444, "y"), ((V)(2D))))).Put("rx", ((V)(1D))).Put("ry", ((V)(1D))).Put("fill", ((V)("#8fd6ff"))).Put("opacity", ((V)(0.75))).V));
Invoke(scB_526, "insertBefore", Get(fr_1444, "pud"), water_1152);
Set(fr_1444, "slap", Call(S_16, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)("M-30 10C-40 -30 -20 -70 0 -76C20 -70 40 -30 30 10C14 -2 -14 -2 -30 10Z"))).Put("fill", ((V)("#bfeaff"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2D))).Put("opacity", ((V)(0D))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Get(fr_1444, "x")).S(" ").N((ToNum(Get(fr_1444, "y")) - 40D)).S(")").End()))).V, scF_532));
return default;
}, 1, "", true));
shakeG_1176 = Arr(scB_526, scF_532);
return NewObj(1).Put("update", Fn((V _self1445, int _argc1446, V dt_1452, V t_1453, V _a1450, V _a1451, V[] _rest1447) => {
double ts_1454 = 0;
if (_self1445.IsNullish) _self1445 = GlobalV;
ts_1454 = ((ToNum(t_1453) - ToNum(T0p_1167)) / 1000D);
if (!(Truthy(hit_1171))) {
V u_1455 = default;
V y_1456 = default;
u_1455 = Call(cl_17, V.Undef, ((V)(((ToNum(t_1453) - ToNum(fallAt_1168)) / (ToNum(hitAt_1169) - ToNum(fallAt_1168))))), ((V)(0D)), ((V)(1D)));
y_1456 = Call(lerp_18, V.Undef, ((V)((-100D))), ((V)((WY_1147 + 48D))), ((V)((ToNum(u_1455) * ToNum(u_1455)))));
Invoke(me_576, "set", ((V)(LX_1148)), y_1456, ((V)(128D)));
Invoke(me_576, "rot", ((V)((GeN(v_1138, 75D) ? (ToNum(u_1455) * 540D) : 0D))), ((V)(50D)), ((V)(62D)));
Invoke(me_576, "pose", (GeN(v_1138, 75D) ? NewObj(7).Put("sit", ((V)(1D))).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("sq", ((V)(0.08))).Put("close", ((V)(0.4))).Put("open", ((V)(0.6))).Put("hap", ((V)(1D))).V : NewObj(6).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).Put("open", ((V)(0.9))).Put("hap", ((V)(1D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V));
Invoke(me_576, "hide", (Lt(t_1453, fallAt_1168) ? V.True : V.False));
if (Ge(t_1453, hitAt_1169)) {
hit_1171 = (true ? V.True : V.False);
Call(boom_1177, V.Undef, t_1453);
}
} else {
double u_1457 = 0;
u_1457 = ((ToNum(t_1453) - ToNum(hitAt_1169)) / 1000D);
Invoke(me_576, "rot", ((V)(0D)));
Invoke(GetIdx(rings_1162, 0D), "setAttribute", ((V)("opacity")), ((V)(((u_1457 < 0.38) ? 0D : 0.85))));
if ((u_1457 < 0.38)) {
Invoke(me_576, "hide", (true ? V.True : V.False));
} else {
Invoke(me_576, "hide", (false ? V.True : V.False));
Invoke(me_576, "set", ((V)(LX_1148)), ((V)((((WY_1147 + 36D) + (FdLibm.Sin((u_1457 * 3D)) * 2D)) + ((u_1457 < 0.6) ? ((0.6 - u_1457) * 60D) : 0D)))), ((V)(128D)));
Invoke(me_576, "pose", NewObj(6).Put("sit", ((V)(1D))).Put("armL", ((V)((130D + (30D * FdLibm.Sin((u_1457 * 7D))))))).Put("armR", ((V)((130D - (30D * FdLibm.Sin((u_1457 * 7D))))))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).V);
}
}
if (Truthy(hit_1171)) {
double u_1458 = 0;
double ch_1459 = 0;
double hc_1460 = 0;
V cu_1461 = default;
V cf_1462 = default;
V wy_1463 = default;
double sh_1464 = 0;
double sx_1465 = 0;
double sy_1466 = 0;
u_1458 = ((ToNum(t_1453) - ToNum(hitAt_1169)) / 1000D);
ch_1459 = ((u_1458 < 0.28) ? FdLibm.Sin((((u_1458 / 0.28) * System.Math.PI) / 2D)) : Max(0D, (1D - ((u_1458 - 0.28) / (0.6 + (0.5 * ToNum(k_1137)))))));
hc_1460 = ((60D + (270D * ToNum(k_1137))) / 100D);
Invoke(col_1172, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").N(LX_1148).S(" ").N(WY_1147).S(") scale(").V(Call(r2_19, V.Undef, ((V)((1D + ((0.4 * ToNum(k_1137)) * (1D - ch_1459))))))).S(" ").V(Call(r2_19, V.Undef, ((V)(Max(0.01, (ch_1459 * hc_1460)))))).S(")").End())));
Invoke(col_1172, "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, ((V)((0.95 * Min(1D, (ch_1459 * 2.5)))))));
Invoke(jets_1173, "forEach", Fn((V _self1445, int _argc1467, V j_1473, V _a1470, V _a1471, V _a1472, V[] _rest1468) => {
double w_1474 = 0;
double c2_1475 = 0;
w_1474 = (u_1458 - ToNum(Get(j_1473, "dl")));
c2_1475 = ((w_1474 < 0D) ? 0D : ((w_1474 < 0.3) ? FdLibm.Sin((((w_1474 / 0.3) * System.Math.PI) / 2D)) : Max(0D, (1D - ((w_1474 - 0.3) / (0.55 + (0.45 * ToNum(k_1137))))))));
Invoke(Get(j_1473, "e"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").N(LX_1148).S(" ").N(WY_1147).S(") scale(1 ").V(Call(r2_19, V.Undef, ((V)(Max(0.01, (c2_1475 * ToNum(Get(j_1473, "hj")))))))).S(")").End())));
Invoke(Get(j_1473, "e"), "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, ((V)((0.88 * Min(1D, (c2_1475 * 2.5)))))));
return default;
}, 1, "", true));
cu_1461 = Call(cl_17, V.Undef, ((V)((u_1458 / 0.2))), ((V)(0D)), ((V)(1D)));
cf_1462 = ((u_1458 < 0.5) ? ((V)(1D)) : Call(cl_17, V.Undef, ((V)((1D - ((u_1458 - 0.5) / 0.45)))), ((V)(0D)), ((V)(1D))));
Invoke(crown_1175, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").N(LX_1148).S(" ").N(WY_1147).S(") scale(").V(Call(r2_19, V.Undef, ((V)((0.6 + (0.5 * ToNum(cu_1461))))))).S(" ").V(Call(r2_19, V.Undef, ((V)(Max(0.01, (ToNum(cu_1461) * ToNum(cf_1462))))))).S(")").End())));
Invoke(crown_1175, "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, cf_1462));
Invoke(Get(fx_1170, "ring"), "forEach", Fn((V _self1445, int _argc1476, V e_1482, V i_1483, V _a1480, V _a1481, V[] _rest1477) => {
double w_1484 = 0;
double r_1485 = 0;
w_1484 = (u_1458 - (ToNum(i_1483) * 0.15));
if ((w_1484 < 0D)) {
return default;
}
r_1485 = (14D + (((RX_1143 - IR_1146) - 20D) * (1D - FdLibm.Exp(((-w_1484) * 2.4)))));
Invoke(e_1482, "setAttribute", ((V)("rx")), Call(r2_19, V.Undef, ((V)(r_1485))));
Invoke(e_1482, "setAttribute", ((V)("ry")), Call(r2_19, V.Undef, ((V)((r_1485 * 0.2)))));
Invoke(e_1482, "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, ((V)((ToNum(Call(cl_17, V.Undef, ((V)((1D - (w_1484 / 1.4)))), ((V)(0D)), ((V)(1D)))) * 0.85)))));
return default;
}, 2, "", true));
Invoke(Get(fx_1170, "sheets"), "forEach", Fn((V _self1445, int _argc1486, V q_1492, V _a1489, V _a1490, V _a1491, V[] _rest1487) => {
V w_1493 = default;
V fade_1494 = default;
w_1493 = Call(cl_17, V.Undef, ((V)(((u_1458 - 0.05) / 0.32))), ((V)(0D)), ((V)(1D)));
fade_1494 = Call(cl_17, V.Undef, ((V)((1D - ((u_1458 - 0.45) / 0.4)))), ((V)(0D)), ((V)(1D)));
Invoke(Get(q_1492, "e"), "setAttribute", ((V)("stroke-dasharray")), ((V)(JsStrBuf.Begin().V(Call(r2_19, V.Undef, ((V)((ToNum(Get(q_1492, "len")) * ToNum(w_1493)))))).S(" 999").End())));
Invoke(Get(q_1492, "e"), "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, ((V)((0.85 * ToNum(fade_1494))))));
return default;
}, 1, "", true));
Invoke(Get(fx_1170, "spills"), "forEach", Fn((V _self1445, int _argc1495, V q_1501, V _a1498, V _a1499, V _a1500, V[] _rest1496) => {
V w_1502 = default;
V fade_1503 = default;
w_1502 = Call(cl_17, V.Undef, ((V)(((u_1458 - ToNum(Get(q_1501, "dl"))) / 0.35))), ((V)(0D)), ((V)(1D)));
fade_1503 = Call(cl_17, V.Undef, ((V)((1D - ((u_1458 - 1.6) / 0.8)))), ((V)(0D)), ((V)(1D)));
Invoke(Get(q_1501, "e"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("scale(1 ").V(Call(r2_19, V.Undef, ((V)(Max(0.01, ToNum(w_1502)))))).S(")").End())));
Invoke(Get(q_1501, "e"), "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, ((V)((0.85 * ToNum(fade_1503))))));
Invoke(Get(q_1501, "pd"), "setAttribute", ((V)("rx")), Call(r2_19, V.Undef, ((V)((4D + ((26D * ToNum(w_1502)) * ToNum(Add(((V)(0.5)), k_1137))))))));
Invoke(Get(q_1501, "pd"), "setAttribute", ((V)("ry")), Call(r2_19, V.Undef, ((V)((1D + ((5D * ToNum(w_1502)) * ToNum(Add(((V)(0.5)), k_1137))))))));
return default;
}, 1, "", true));
wy_1463 = ((V)(JsStrBuf.Begin().S("translate(0 ").V(Call(r2_19, V.Undef, ((V)((((FdLibm.Sin((u_1458 * 12D)) * ToNum(k_1137)) * 5D) * FdLibm.Exp(((-u_1458) * 1.6))))))).S(")").End()));
Invoke(water_1152, "setAttribute", ((V)("transform")), wy_1463);
Invoke(waterF_1160, "setAttribute", ((V)("transform")), wy_1463);
Invoke(Arr(duckG_1155, ballG_1156), "forEach", Fn((V _self1445, int _argc1504, V g_1510, V i_1511, V _a1508, V _a1509, V[] _rest1505) => {
double bx_1512 = 0;
double by_1513 = 0;
bx_1512 = ((((Truthy(i_1511) ? 1D : (-1D)) * 18D) * ToNum(k_1137)) * Min(1D, (u_1458 * 3D)));
by_1513 = (((-Max(0D, FdLibm.Sin((Min(1D, (u_1458 * 2.2)) * System.Math.PI)))) * (20D + (70D * ToNum(k_1137)))) * (GtN(k_1137, 0.4) ? 1D : 0.3));
Invoke(g_1510, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_19, V.Undef, ((V)(((Truthy(i_1511) ? (PX_1141 + 122D) : (PX_1141 - 112D)) + bx_1512))))).S(" ").V(Call(r2_19, V.Undef, ((V)(((WY_1147 + 2D) + by_1513))))).S(") rotate(").V(Call(r2_19, V.Undef, ((V)((by_1513 * (Truthy(i_1511) ? 2D : (-2D))))))).S(")").End())));
return default;
}, 2, "", true));
sh_1464 = (ToNum(Get(st_583, "shake")) * FdLibm.Exp(((-u_1458) * 4D)));
sx_1465 = ((ToNum(Invoke(G("Math"), "random")) - 0.5) * sh_1464);
sy_1466 = ((ToNum(Invoke(G("Math"), "random")) - 0.5) * sh_1464);
Invoke(shakeG_1176, "forEach", Fn((V _self1445, int _argc1514, V g_1520, V _a1517, V _a1518, V _a1519, V[] _rest1515) => {
return Invoke(g_1520, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_19, V.Undef, ((V)(sx_1465)))).S(" ").V(Call(r2_19, V.Undef, ((V)(sy_1466)))).S(")").End())));
}, 1, "", true));
}
Invoke(friends_581, "forEach", Fn((V _self1445, int _argc1521, V fr_1527, V i_1528, V _a1525, V _a1526, V[] _rest1522) => {
V c_1529 = default;
V E_1530 = default;
c_1529 = Get(fr_1527, "c");
E_1530 = NewObj(6).Put("ly", ((V)((-0.8)))).Put("lx", ((V)(((LX_1148 - ToNum(Get(fr_1527, "x"))) / 400D)))).Put("open", ((V)(0.4))).Put("armR", ((V)(110D))).Put("armL", ((V)(40D))).Put("smile", ((V)(0.6))).V;
if (Truthy(Get(fr_1527, "in"))) {
Set(E_1530, "sit", ((V)(1D)));
}
if (Truthy(hit_1171)) {
double u_1531 = 0;
double kn_1532 = 0;
u_1531 = ((ToNum(t_1453) - ToNum(Get(fr_1527, "hitAt"))) / 1000D);
if ((!(IsFiniteV(Get(fr_1527, "hitAt"))) || (u_1531 < 0D))) {
E_1530 = NewObj(7).Put("ly", ((V)((-0.3)))).Put("lx", ((V)(((LX_1148 - ToNum(Get(fr_1527, "x"))) / 300D)))).Put("open", ((V)(0.6))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("sq", ((V)(0.04))).Put("sit", ((V)((Truthy(Get(fr_1527, "in")) ? 1D : 0D)))).V;
} else {
if (LtN(k_1137, 0.3)) {
E_1530 = NewObj(6).Put("armL", ((V)((150D + (20D * FdLibm.Sin((u_1531 * 14D))))))).Put("armR", ((V)((150D - (20D * FdLibm.Sin((u_1531 * 14D))))))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.6))).Put("sit", ((V)((Truthy(Get(fr_1527, "in")) ? 1D : 0D)))).V;
} else {
double shake_1533 = 0;
shake_1533 = (((u_1531 > 1.3) && (u_1531 < 2.1)) ? ((FdLibm.Sin((u_1531 * 50D)) * 14D) * (1D - ((u_1531 - 1.3) / 0.8))) : 0D);
E_1530 = NewObj(9).Put("tilt", ((V)(shake_1533))).Put("sq", ((V)(((u_1531 < 0.25) ? 0.12 : 0.02)))).Put("armL", ((V)(((u_1531 < 1.2) ? 120D : 150D)))).Put("armR", ((V)(((u_1531 < 1.2) ? 120D : 150D)))).Put("open", ((V)(0.7))).Put("hap", ((V)(((u_1531 > 1.3) ? 1D : 0D)))).Put("smile", ((V)(((u_1531 > 1.3) ? 1D : 0D)))).Put("close", ((V)(((u_1531 < 0.5) ? 0.8 : 0D)))).Put("sit", ((V)((Truthy(Get(fr_1527, "in")) ? 1D : 0D)))).V;
if (Truthy((((V)(shake_1533)) is var _t1534 && !Truthy(_t1534) ? _t1534 : (LtN(Invoke(G("Math"), "random"), 0.5) ? V.True : V.False)))) {
Invoke(ctx_512, "burst", Add(Add(Get(fr_1527, "x"), Get(fr_1527, "dx")), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 40D)))), ((V)((ToNum(Add(Get(fr_1527, "y"), Get(fr_1527, "dy"))) - 50D))), ((V)("drop")), ((V)(2D)), NewObj(4).Put("v", ((V)(120D))).Put("spread", TAU_21).Put("life", ((V)(0.5))).Put("g", ((V)(300D))).V);
}
}
}
kn_1532 = (Truthy((Get(fr_1527, "knock") is var _t1535 && !Truthy(_t1535) ? _t1535 : ((u_1531 > 0D) ? V.True : V.False))) ? ((u_1531 < 0.25) ? (u_1531 / 0.25) : ((u_1531 < 1D) ? 1D : Max(0D, (1D - ((u_1531 - 1D) / 0.35))))) : 0D);
if (Truthy((Get(fr_1527, "in") is var _t1536 && !Truthy(_t1536) ? _t1536 : Get(fr_1527, "knock")))) {
double a_1537 = 0;
a_1537 = (((u_1531 > 0D) && (u_1531 < 1D)) ? FdLibm.Sin(((u_1531 / 1D) * System.Math.PI)) : 0D);
Set(fr_1527, "dy", ((V)(((-a_1537) * (60D + (120D * ToNum(k_1137)))))));
Invoke(c_1529, "rot", ((V)((((u_1531 > 0D) && (u_1531 < 1D)) ? (u_1531 * 360D) : 0D))), ((V)(50D)), ((V)(60D)));
Invoke(GetIdx(rings_1162, 1D), "setAttribute", ((V)("opacity")), ((V)(((a_1537 > 0.15) ? 0D : 0.85))));
} else {
double lb_1538 = 0;
lb_1538 = (((!(Truthy(Get(fr_1527, "knock"))) && GeN(k_1137, 0.55)) && (u_1531 > 0D)) ? ((u_1531 < 0.2) ? (u_1531 / 0.2) : Max(0D, (1D - ((u_1531 - 0.5) / 0.6)))) : 0D);
Set(fr_1527, "rot", ((V)((((kn_1532 * ToNum(Get(fr_1527, "side"))) * 78D) + ((lb_1538 * ToNum(Get(fr_1527, "side"))) * 16D)))));
Set(fr_1527, "dx", ((V)((((kn_1532 * ToNum(Get(fr_1527, "side"))) * 26D) + ((lb_1538 * ToNum(Get(fr_1527, "side"))) * 10D)))));
Invoke(c_1529, "rot", Get(fr_1527, "rot"), ((V)(50D)), ((V)(92D)));
}
if (Truthy((((u_1531 > 0D) ? V.True : V.False) is var _t1539 && !Truthy(_t1539) ? _t1539 : Get(fr_1527, "wet")))) {
V w_1540 = default;
w_1540 = Call(cl_17, V.Undef, ((V)((u_1531 / 0.35))), ((V)(0D)), ((V)(1D)));
Invoke(Get(fr_1527, "slap"), "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, ((V)(((0.8 * (1D - ToNum(w_1540))) * ((u_1531 < 0.35) ? 1D : 0D))))));
Invoke(Get(fr_1527, "slap"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_19, V.Undef, Add(Get(fr_1527, "x"), Get(fr_1527, "dx")))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(Add(Get(fr_1527, "y"), Get(fr_1527, "dy"))) - 30D))))).S(") scale(").V(Call(r2_19, V.Undef, ((V)((0.6 + (0.8 * ToNum(w_1540))))))).S(")").End())));
if (!(Truthy(Get(fr_1527, "in")))) {
double pw_1541 = 0;
pw_1541 = (ToNum(Call(cl_17, V.Undef, ((V)((u_1531 / 0.8))), ((V)(0D)), ((V)(1D)))) * (0.5 + (0.7 * ToNum(k_1137))));
Invoke(Get(fr_1527, "pud"), "setAttribute", ((V)("rx")), Call(r2_19, V.Undef, ((V)((8D + (34D * pw_1541))))));
Invoke(Get(fr_1527, "pud"), "setAttribute", ((V)("ry")), Call(r2_19, V.Undef, ((V)((2D + (6D * pw_1541))))));
Invoke(Get(fr_1527, "pud"), "setAttribute", ((V)("cx")), Call(r2_19, V.Undef, Add(Get(fr_1527, "x"), ((V)((ToNum(Get(fr_1527, "dx")) * 0.5))))));
}
}
Invoke(c_1529, "set", Add(Get(fr_1527, "x"), Get(fr_1527, "dx")), Add(Get(fr_1527, "y"), Get(fr_1527, "dy")), Get(fr_1527, "size"));
if (GtN(Get(fr_1527, "wet"), 0D)) {
OpSet(fr_1527, "dripT", 1, dt_1452);
if (LeN(Get(fr_1527, "dripT"), 0D)) {
Set(fr_1527, "dripT", ((V)(0.07)));
Invoke(ctx_512, "burst", Add(Add(Get(fr_1527, "x"), Get(fr_1527, "dx")), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 46D)))), ((V)(((ToNum(Add(Get(fr_1527, "y"), Get(fr_1527, "dy"))) - 20D) - (ToNum(Invoke(G("Math"), "random")) * 60D)))), ((V)("drop")), ((V)(2D)), NewObj(6).Put("v", ((V)(30D))).Put("dir", ((V)((System.Math.PI / 2D)))).Put("spread", ((V)(0.5))).Put("life", ((V)(0.7))).Put("g", ((V)(420D))).Put("k", ((V)(1.3))).V);
}
Set(fr_1527, "wet", ((V)(Max(0D, (ToNum(Get(fr_1527, "wet")) - (ToNum(dt_1452) * 0.2))))));
}
}
Invoke(c_1529, "pose", E_1530);
return default;
}, 2, "", true));
if (Truthy(((hit_1171 is var _t1542 && !Truthy(_t1542) ? _t1542 : (((ToNum(t_1453) - ToNum(hitAt_1169)) > 3300D) ? V.True : V.False)) is var _t1543 && !Truthy(_t1543) ? _t1543 : (!(Truthy(Get(st_583, "done"))) ? V.True : V.False)))) {
Set(st_583, "done", ((V)(1D)));
Invoke(ctx_512, "finish", NewObj(2).Put("sub", ((V)(JsStrBuf.Begin().S("Hit the pool at ").N(Round(ToNum(v_1138))).S(" km/h \u00b7 top ").N(Round(ToNum(Get(st_583, "top")))).S(" \u00b7 ").V(Get(st_583, "boosts")).S(" boosts").End()))).Put("delay", ((V)(700D))).V);
}
Call(hud__595, V.Undef, dt_1452, t_1453);
return default;
}, 2, "update", false)).V;
return default;
}, 0, "poolScene", false);
camera_593 = Fn((V _self1544, int _argc1545, V dt_1551, V t_1552, V _a1549, V _a1550, V[] _rest1546) => {
V fly_1553 = default;
V fk_1554 = default;
V ct_1555 = default;
double sx_1556 = 0;
double sy_1557 = 0;
V cam_1558 = default;
V zz_1559 = default;
V tr_1560 = default;
if (_self1544.IsNullish) _self1544 = GlobalV;
fly_1553 = (SEqS(Get(st_583, "phase"), "fly") ? V.True : V.False);
fk_1554 = Call(cl_17, V.Undef, ((V)(((ToNum(Get(st_583, "v")) - VB_38) / 70D))), ((V)(0D)), ((V)(1D)));
Set(st_583, "z", Call(lerp_18, V.Undef, Get(st_583, "z"), ((V)((Z0_579 * (1D + (0.07 * ToNum(Get(st_583, "punch"))))))), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1551)) * 6D)))))));
Set(st_583, "lc", Call(lerp_18, V.Undef, Get(st_583, "lc"), (Truthy(fly_1553) ? Get(st_583, "lc") : ((V)((0.5 * ToNum(Get(st_583, "l")))))), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1551)) * 5D)))))));
if (!(Truthy(fly_1553))) {
Set(st_583, "sc", Get(st_583, "s"));
} else {
Set(st_583, "sc", Call(lerp_18, V.Undef, Get(st_583, "sc"), ((V)((LEN_44 + 30D))), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1551)) * 3D)))))));
}
ct_1555 = Arr(Call(lerp_18, V.Undef, GetIdx(C0_577, 0D), GetIdx(C1_578, 0D), fk_1554), Call(lerp_18, V.Undef, GetIdx(C0_577, 1D), GetIdx(C1_578, 1D), fk_1554));
Set(st_583, "cx", Call(lerp_18, V.Undef, Get(st_583, "cx"), GetIdx(ct_1555, 0D), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1551)) * 2.5)))))));
Set(st_583, "cy", Call(lerp_18, V.Undef, Get(st_583, "cy"), GetIdx(ct_1555, 1D), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1551)) * 2.5)))))));
sx_1556 = 0D;
sy_1557 = 0D;
if (GtN(Get(st_583, "shake"), 0.2)) {
sx_1556 = (((ToNum(Invoke(G("Math"), "random")) - 0.5) * 2D) * ToNum(Get(st_583, "shake")));
sy_1557 = (((ToNum(Invoke(G("Math"), "random")) - 0.5) * 2D) * ToNum(Get(st_583, "shake")));
OpSet(st_583, "shake", 2, ((V)(FdLibm.Exp(((-ToNum(dt_1551)) * 7D)))));
}
if (((SEqS(Get(st_583, "phase"), "ride") || SEqS(Get(st_583, "phase"), "ramp")) && GtN(Get(st_583, "v"), 62D))) {
double a_1561 = 0;
a_1561 = (((ToNum(Get(st_583, "v")) - 62D) / 45D) * 1.4);
sx_1556 = (sx_1556 + ((ToNum(Invoke(G("Math"), "random")) - 0.5) * a_1561));
sy_1557 = (sy_1557 + ((ToNum(Invoke(G("Math"), "random")) - 0.5) * a_1561));
}
cam_1558 = Call(Wp_28, V.Undef, Get(st_583, "sc"), Get(st_583, "lc"), ((V)((SH_47 * 0.85))));
Set(st_583, "tx", ((V)((ToNum(Add(Get(st_583, "cx"), ((V)(sx_1556)))) - (ToNum(Get(st_583, "z")) * ToNum(GetIdx(cam_1558, 0D)))))));
Set(st_583, "ty", ((V)((ToNum(Add(Get(st_583, "cy"), ((V)(sy_1557)))) - (ToNum(Get(st_583, "z")) * ToNum(GetIdx(cam_1558, 1D)))))));
zz_1559 = Invoke(Get(st_583, "z"), "toFixed", ((V)(5D)));
tr_1560 = ((V)(JsStrBuf.Begin().S("matrix(").V(zz_1559).S(" 0 0 ").V(zz_1559).S(" ").V(Call(r2_19, V.Undef, Get(st_583, "tx"))).S(" ").V(Call(r2_19, V.Undef, Get(st_583, "ty"))).S(")").End()));
Invoke(wB_519, "setAttribute", ((V)("transform")), tr_1560);
Invoke(wF_527, "setAttribute", ((V)("transform")), tr_1560);
Call(ensure_550, V.Undef, Get(st_583, "sc"), Get(st_583, "z"));
Call(feed_558, V.Undef, Get(st_583, "sc"), Get(st_583, "z"));
return default;
}, 2, "camera", false);
place_594 = Fn((V _self1562, int _argc1563, V t_1569, V dt_1570, V _a1567, V _a1568, V[] _rest1564) => {
V gh_1571 = default;
V gp_1572 = default;
double air_1573 = 0;
V ride_1574 = default;
double bob_1575 = 0;
V p_1576 = default;
if (_self1562.IsNullish) _self1562 = GlobalV;
gh_1571 = (SEqS(Get(st_583, "phase"), "fly") ? (LtN(Get(st_583, "s"), LEN_44) ? Call(HS_57, V.Undef, Get(st_583, "s")) : ((V)(0D))) : Call(HS_57, V.Undef, Get(st_583, "s")));
gp_1572 = Call(Wp_28, V.Undef, Get(st_583, "s"), Get(st_583, "l"), gh_1571);
air_1573 = (ToNum(Get(st_583, "h")) - ToNum(gh_1571));
Invoke(meSh_535, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(P2_29, V.Undef, gp_1572)).S(") rotate(").V(Get(EL_33, "rot")).S(")").End())));
Invoke(meSh_535, "setAttribute", ((V)("opacity")), Call(r2_19, V.Undef, ((V)((0.22 * ToNum(Call(cl_17, V.Undef, ((V)((1D - (air_1573 / 220D)))), ((V)(0.2)), ((V)(1D)))))))));
Invoke(meSh_535, "setAttribute", ((V)("rx")), Call(r2_19, V.Undef, ((V)(((20D * ToNum(Get(EL_33, "kx"))) * ToNum(Call(cl_17, V.Undef, ((V)((1D - (air_1573 / 300D)))), ((V)(0.5)), ((V)(1D)))))))));
riderD_537 = Add(GetIdx(Call(Wp_28, V.Undef, Get(st_583, "s"), Get(st_583, "l"), ((V)(0D))), 1D), ((V)(1D)));
{
foreach (V _k1577 in new JsIter(stands_536)) {
V o_1578 = default;
o_1578 = _k1577;
V fr_1579 = default;
fr_1579 = (Gt(Get(o_1578, "d"), riderD_537) ? V.True : V.False);
if (!SEq(fr_1579, Get(o_1578, "fr"))) {
Call(sortIn_538, V.Undef, o_1578, fr_1579);
}
}
}
ride_1574 = ((SEqS(Get(st_583, "phase"), "ride") || SEqS(Get(st_583, "phase"), "ramp")) ? V.True : V.False);
bob_1575 = (Truthy((ride_1574 is var _t1580 && !Truthy(_t1580) ? _t1580 : (LeN(Get(st_583, "ha"), 0.5) ? V.True : V.False))) ? ((FdLibm.Sin((ToNum(t_1569) / 34D)) * 0.9) * ToNum(Call(cl_17, V.Undef, ((V)((ToNum(Get(st_583, "v")) / 70D))), ((V)(0D)), ((V)(1.6))))) : 0D);
p_1576 = Call(scr_584, V.Undef, Get(st_583, "s"), Get(st_583, "l"), Get(st_583, "h"));
Invoke(me_576, "set", GetIdx(p_1576, 0D), Add(GetIdx(p_1576, 1D), ((V)(((5D + bob_1575) * ToNum(Get(st_583, "z")))))), ((V)((K_51 * ToNum(Get(st_583, "z"))))));
Invoke(me_576, "rot", (SEqS(Get(st_583, "phase"), "fly") ? (GeN(Get(st_583, "lipV"), 75D) ? ((V)(Min(360D, ((((ToNum(t_1569) - ToNum(Get(st_583, "tf"))) / 1000D) * 1.6) * 360D)))) : Call(cl_17, V.Undef, ((V)(((-ToNum(Get(st_583, "vh"))) / 18D))), ((V)((-20D))), ((V)(24D)))) : ((V)((SEqS(Get(st_583, "phase"), "ramp") ? (((-(ToNum(Call(HS_57, V.Undef, Get(st_583, "s"))) - SH_47)) / RH_46) * 16D) : 0D)))), ((V)(50D)), ((V)(((SEqS(Get(st_583, "phase"), "fly") && GeN(Get(st_583, "lipV"), 75D)) ? 62D : 80D))));
if (Truthy(((ride_1574 is var _t1581 && !Truthy(_t1581) ? _t1581 : (LeN(Get(st_583, "ha"), 1D) ? V.True : V.False)) is var _t1582 && !Truthy(_t1582) ? _t1582 : (GtN(Get(st_583, "v"), 42D) ? V.True : V.False)))) {
OpSet(st_583, "trail", 1, dt_1570);
if (LeN(Get(st_583, "trail"), 0D)) {
V q_1583 = default;
Set(st_583, "trail", ((V)(0.07)));
q_1583 = Call(scr_584, V.Undef, ((V)((ToNum(Get(st_583, "s")) - 14D))), Get(st_583, "l"), Get(st_583, "h"));
Invoke(ctx_512, "burst", GetIdx(q_1583, 0D), ((V)((ToNum(GetIdx(q_1583, 1D)) - 4D))), ((V)("drop")), ((V)((2D + (GtN(Get(st_583, "v"), 80D) ? 1D : 0D)))), NewObj(6).Put("v", ((V)((60D + (ToNum(Get(st_583, "v")) * 1.4))))).Put("dir", ((V)((FdLibm.Atan2((-ToNum(GetIdx(F_25, 1D))), (-ToNum(GetIdx(F_25, 0D)))) - 0.5)))).Put("spread", ((V)(0.9))).Put("life", ((V)(0.45))).Put("g", ((V)(300D))).Put("col", ((V)("#dff4ff"))).V);
}
}
if (Truthy((ride_1574 is var _t1584 && !Truthy(_t1584) ? _t1584 : (GtN(Get(st_583, "boostT"), 0D) ? V.True : V.False)))) {
OpSet(st_583, "sparkT", 1, dt_1570);
if (LeN(Get(st_583, "sparkT"), 0D)) {
V q_1585 = default;
Set(st_583, "sparkT", ((V)(0.05)));
q_1585 = Call(scr_584, V.Undef, ((V)((ToNum(Get(st_583, "s")) - 10D))), Get(st_583, "l"), Add(Get(st_583, "h"), ((V)(20D))));
Invoke(ctx_512, "burst", GetIdx(q_1585, 0D), GetIdx(q_1585, 1D), ((V)("star")), ((V)(1D)), NewObj(5).Put("v", ((V)(90D))).Put("dir", ((V)(FdLibm.Atan2((-ToNum(GetIdx(F_25, 1D))), (-ToNum(GetIdx(F_25, 0D))))))).Put("spread", ((V)(0.8))).Put("life", ((V)(0.5))).Put("g", ((V)(0D))).V);
}
}
return default;
}, 2, "place", false);
hud__595 = Fn((V _self1586, int _argc1587, V dt_1593, V t_1594, V _a1591, V _a1592, V[] _rest1588) => {
V v_1595 = default;
V tr_1596 = default;
V u_1597 = default;
V vt_1598 = default;
V pr_1599 = default;
V go_1600 = default;
V sk_1601 = default;
double spd_1602 = 0;
double n_1603 = 0;
V me0_1604 = default;
if (_self1586.IsNullish) _self1586 = GlobalV;
v_1595 = (SEqS(Get(st_583, "phase"), "pool") ? Get(st_583, "lipV") : Get(st_583, "v"));
tr_1596 = Call(tierOf_59, V.Undef, v_1595);
u_1597 = Call(cl_17, V.Undef, ((V)((ToNum(v_1595) / 110D))), ((V)(0D)), ((V)(1D)));
Invoke(spArc_562, "setAttribute", ((V)("stroke-dasharray")), ((V)(JsStrBuf.Begin().V(Call(r2_19, V.Undef, ((V)((arcL_561 * ToNum(u_1597)))))).S(" 999").End())));
Invoke(spArc_562, "setAttribute", ((V)("stroke")), ((V)((LtN(v_1595, 42D) ? "#5cc87a" : (LtN(v_1595, 60D) ? "#3fc0d8" : (LtN(v_1595, 80D) ? "#ffb020" : (LtN(v_1595, 100D) ? "#ff7a3a" : "#ff4d8a")))))));
vt_1598 = ((V)(ToStrS(((V)(Round(ToNum(v_1595)))))));
if (!SEq(Get(spTx_563, "textContent"), vt_1598)) {
Set(spTx_563, "textContent", vt_1598);
}
if (!SEq(Get(tierTx_566, "textContent"), GetIdx(tr_1596, 1D))) {
Set(tierTx_566, "textContent", GetIdx(tr_1596, 1D));
Invoke(tierR_565, "setAttribute", ((V)("fill")), GetIdx(tr_1596, 2D));
}
pr_1599 = Call(cl_17, V.Undef, ((V)((ToNum(Get(st_583, "s")) / LEN_44))), ((V)(0D)), ((V)(1D)));
Invoke(pgF_568, "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M40 0H").V(Call(r2_19, V.Undef, ((V)((40D + (274D * ToNum(pr_1599))))))).End())));
Invoke(pgD_569, "setAttribute", ((V)("cx")), Call(r2_19, V.Undef, ((V)((40D + (274D * ToNum(pr_1599)))))));
Set(Get(hud_534, "style"), "opacity", ((V)((SEqS(Get(st_583, "phase"), "ready") ? 0D : 1D))));
if ((SEqS(Get(st_583, "phase"), "ride") || SEqS(Get(st_583, "phase"), "ramp"))) {
Invoke(ctx_512, "timer", ((V)(JsStrBuf.Begin().N(Max(0D, Round(((LEN_44 - ToNum(Get(st_583, "s"))) / 14.4)))).S(" m").End())));
} else {
if ((SEqS(Get(st_583, "phase"), "ready") || SEqS(Get(st_583, "phase"), "pool"))) {
Invoke(ctx_512, "timer", ((V)("")));
}
}
if (SEqS(Get(st_583, "phase"), "pool")) {
return default;
}
go_1600 = (((SEqS(Get(st_583, "phase"), "ride") || SEqS(Get(st_583, "phase"), "ramp")) || SEqS(Get(st_583, "phase"), "fly")) ? V.True : V.False);
sk_1601 = (Truthy(go_1600) ? Call(cl_17, V.Undef, ((V)(((ToNum(v_1595) - 42D) / 55D))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
spd_1602 = (((ToNum(v_1595) * KV_37) * ToNum(Get(st_583, "z"))) * 1.7);
n_1603 = Round((6D + (12D * ToNum(sk_1601))));
me0_1604 = Call(scr_584, V.Undef, Get(st_583, "s"), Get(st_583, "l"), Add(Get(st_583, "h"), ((V)(30D))));
Invoke(lines_570, "forEach", Fn((V _self1586, int _argc1605, V q_1611, V i_1612, V _a1609, V _a1610, V[] _rest1606) => {
V on_1613 = default;
double len_1614 = 0;
on_1613 = ((LtN(i_1612, n_1603) && GtN(sk_1601, 0D)) ? V.True : V.False);
OpSet(q_1611, "x", 1, ((V)((((ToNum(GetIdx(F_25, 0D)) * spd_1602) * ToNum(dt_1593)) * ToNum(Get(q_1611, "n"))))));
OpSet(q_1611, "y", 1, ((V)((((ToNum(GetIdx(F_25, 1D)) * spd_1602) * ToNum(dt_1593)) * ToNum(Get(q_1611, "n"))))));
if ((((LtN(Get(q_1611, "x"), (-120D)) || LtN(Get(q_1611, "y"), (-120D))) || Gt(Get(q_1611, "x"), Add(W_515, ((V)(200D))))) || Gt(Get(q_1611, "y"), Add(H_516, ((V)(200D)))))) {
if (Truthy(Get(q_1611, "near"))) {
Set(q_1611, "x", Add(Add(GetIdx(me0_1604, 0D), ((V)(40D))), ((V)((ToNum(Invoke(G("Math"), "random")) * 160D)))));
Set(q_1611, "y", ((V)(((ToNum(GetIdx(me0_1604, 1D)) - 40D) + (ToNum(Invoke(G("Math"), "random")) * 80D)))));
} else {
Set(q_1611, "x", ((V)((ToNum(W_515) * (0.25 + (ToNum(Invoke(G("Math"), "random")) * 0.9))))));
Set(q_1611, "y", ((V)((ToNum(H_516) * (0.05 + (ToNum(Invoke(G("Math"), "random")) * 1.05))))));
if (((Lt(Get(q_1611, "x"), W_515) && Lt(Get(q_1611, "y"), H_516)) && LtN(Invoke(G("Math"), "random"), 0.6))) {
Set(q_1611, "x", Add(W_515, ((V)(20D))));
}
}
}
len_1614 = ((24D + (120D * ToNum(sk_1601))) * ToNum(Get(q_1611, "n")));
Invoke(Get(q_1611, "e"), "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_19, V.Undef, Get(q_1611, "x"))).S(" ").V(Call(r2_19, V.Undef, Get(q_1611, "y"))).S("l").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(F_25, 0D)) * len_1614))))).S(" ").V(Call(r2_19, V.Undef, ((V)((ToNum(GetIdx(F_25, 1D)) * len_1614))))).End())));
Invoke(Get(q_1611, "e"), "setAttribute", ((V)("opacity")), (Truthy(on_1613) ? Call(r2_19, V.Undef, ((V)(((Truthy(Get(q_1611, "near")) ? 0.85 : 0.6) * ToNum(sk_1601))))) : ((V)(0D))));
return default;
}, 2, "", true));
return default;
}, 2, "hud_", false);
{ V _t1615 = ctx_512;
if (_t1615.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1615));
{ V _t1616 = Get(_t1615, "bg");
bg_513 = _t1616; }
{ V _t1617 = Get(_t1615, "fg");
fg_514 = _t1617; }
{ V _t1618 = Get(_t1615, "W");
W_515 = _t1618; }
{ V _t1619 = Get(_t1615, "H");
H_516 = _t1619; } }
Call(css_79, V.Undef);
look_517 = (Get(Get(ctx_512, "G"), "_opt") is var _t1620 && Truthy(_t1620) ? _t1620 : ((V)("rainbow")));
slideBg_518 = Call(S_16, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_515, ((V)(40D)))).Put("height", Add(H_516, ((V)(40D)))).Put("fill", ((V)("#79c25c"))).V, bg_513);
wB_519 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_513);
gStart_520 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, wB_519);
gGround_521 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, wB_519);
gEnd_522 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, wB_519);
gDecal_523 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, wB_519);
gShadow_524 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, wB_519);
gBack_525 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, wB_519);
scB_526 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("style", ((V)("display:none"))).V, bg_513);
wF_527 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, fg_514);
gStartF_528 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, wF_527);
gNear_529 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, wF_527);
gEndF_530 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, wF_527);
gFront_531 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, wF_527);
scF_532 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("style", ((V)("display:none"))).V, fg_514);
speedL_533 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, fg_514);
hud_534 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, fg_514);
meSh_535 = Call(S_16, V.Undef, ((V)("ellipse")), NewObj(4).Put("rx", Call(r2_19, V.Undef, ((V)((20D * ToNum(Get(EL_33, "kx"))))))).Put("ry", Call(r2_19, V.Undef, ((V)((20D * ToNum(Get(EL_33, "ky"))))))).Put("fill", ((V)("#2a3a20"))).Put("opacity", ((V)(0.22))).V, gShadow_524);
stands_536 = Arr();
riderD_537 = ((V)(0D));
chunks_541 = New(G("Map"));
Lp_542 = Fn((V _self505, int _argc1621, V px_1627, V _a1624, V _a1625, V _a1626, V[] _rest1622) => {
return ((V)((ToNum(px_1627) / HW_27)));
}, 1, "", true);
post_543 = Fn((V _self505, int _argc1628, V L_1634, V s_1635, V l_1636, V h0_1637, V[] _rest1629) => {
V h1_1638 = default;
V w_1639 = default;
h1_1638 = (_argc1628 > 4 ? _rest1629[0] : V.Undef);
w_1639 = (_argc1628 > 5 ? _rest1629[1] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, s_1635, l_1636, h0_1637))).S("L").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, s_1635, l_1636, h1_1638))).S("\" stroke=\"").V(Get(L_1634, "postD")).S("\" stroke-width=\"").V(Add((w_1639 is var _t1640 && Truthy(_t1640) ? _t1640 : ((V)(6D))), ((V)(2.4)))).S("\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, s_1635, l_1636, h0_1637))).S("L").V(Call(P2_29, V.Undef, Call(Wp_28, V.Undef, s_1635, l_1636, h1_1638))).S("\" stroke=\"").V(Get(L_1634, "post")).S("\" stroke-width=\"").V((w_1639 is var _t1641 && Truthy(_t1641) ? _t1641 : ((V)(6D)))).S("\" stroke-linecap=\"round\"/>").End()));
}, 6, "", true);
farWall_546 = Fn((V _self505, int _argc1642, V a_1648, V b_1649, V _a1646, V _a1647, V[] _rest1643) => {
V L_1650 = default;
L_1650 = GetK(LOOK_61, look_517);
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(Call(poly_31, V.Undef, Arr(Call(Wp_28, V.Undef, a_1648, ((V)(1D)), ((V)(SH_47))), Call(Wp_28, V.Undef, b_1649, ((V)(1D)), ((V)(SH_47))), Call(Wp_28, V.Undef, b_1649, ((V)(1D)), ((V)((SH_47 + WH_48)))), Call(Wp_28, V.Undef, a_1648, ((V)(1D)), ((V)((SH_47 + WH_48))))))).S("\" fill=\"").V(Get(L_1650, "face")).S("\"/><path d=\"").V(Call(quad_32, V.Undef, a_1648, b_1649, ((V)(1D)), ((V)(1.12)), ((V)((SH_47 + WH_48))))).S("\" fill=\"").V(Get(L_1650, "top")).S("\" stroke=\"").V(Get(L_1650, "side")).S("\" stroke-width=\"1\"/>").End()));
return default;
}, 2, "", true);
items_552 = Arr();
nextI_553 = 0D;
alive_554 = Arr();
sp_559 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(66 ").N((ToNum(H_516) - 54D)).S(")").End()))).V, hud_534);
Call(S_16, V.Undef, ((V)("rect")), NewObj(9).Put("x", ((V)((-52D)))).Put("y", ((V)((-50D)))).Put("width", ((V)(104D))).Put("height", ((V)(72D))).Put("rx", ((V)(24D))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.94))).Put("stroke", ((V)("#4a1a73"))).Put("stroke-width", ((V)(2.5))).V, sp_559);
ARC_560 = ((V)("M-36 4A36 36 0 0 1 36 4"));
arcL_561 = (System.Math.PI * 36D);
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ARC_560).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ece6fa"))).Put("stroke-width", ((V)(9D))).Put("stroke-linecap", ((V)("round"))).V, sp_559);
spArc_562 = Call(S_16, V.Undef, ((V)("path")), NewObj(6).Put("d", ARC_560).Put("fill", ((V)("none"))).Put("stroke", ((V)("#5cc87a"))).Put("stroke-width", ((V)(9D))).Put("stroke-linecap", ((V)("round"))).Put("stroke-dasharray", ((V)("0 999"))).V, sp_559);
spTx_563 = Call(S_16, V.Undef, ((V)("text")), NewObj(6).Put("y", ((V)(0D))).Put("text-anchor", ((V)("middle"))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)(25D))).Put("fill", ((V)("#4a1a73"))).V, sp_559);
Set(spTx_563, "textContent", ((V)("0")));
Set(Call(S_16, V.Undef, ((V)("text")), NewObj(7).Put("y", ((V)(15D))).Put("text-anchor", ((V)("middle"))).Put("font-family", ((V)("Nunito, sans-serif"))).Put("font-weight", ((V)(800D))).Put("font-size", ((V)(9.5))).Put("fill", ((V)("#8a6ab0"))).Put("letter-spacing", ((V)(1D))).V, sp_559), "textContent", ((V)("KM/H")));
tierG_564 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)("translate(0 36)"))).V, sp_559);
tierR_565 = Call(S_16, V.Undef, ((V)("rect")), NewObj(8).Put("x", ((V)((-48D)))).Put("y", ((V)((-10D)))).Put("width", ((V)(96D))).Put("height", ((V)(20D))).Put("rx", ((V)(10D))).Put("fill", ((V)("#bfe8ff"))).Put("stroke", ((V)("#4a1a73"))).Put("stroke-width", ((V)(2D))).V, tierG_564);
tierTx_566 = Call(S_16, V.Undef, ((V)("text")), NewObj(6).Put("y", ((V)(4.5))).Put("text-anchor", ((V)("middle"))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)(12D))).Put("fill", ((V)("#4a1a73"))).V, tierG_564);
pg_567 = Call(S_16, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_19, V.Undef, ((V)(((ToNum(W_515) / 2D) - 177D))))).S(" ").N((ToNum(H_516) - 20D)).S(")").End()))).V, hud_534);
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)("M40 0H314"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(7D))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.85))).V, pg_567);
pgF_568 = Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)("M40 0H40"))).Put("stroke", ((V)("#ff8fc8"))).Put("stroke-width", ((V)(7D))).Put("stroke-linecap", ((V)("round"))).V, pg_567);
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)("M24 6V-12M24 -12H36L32 -7L36 -2H24"))).Put("stroke", ((V)("#4a1a73"))).Put("stroke-width", ((V)(2D))).Put("fill", ((V)("#ffd84a"))).Put("stroke-linejoin", ((V)("round"))).V, pg_567);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(7).Put("cx", ((V)(330D))).Put("cy", ((V)(1D))).Put("rx", ((V)(13D))).Put("ry", ((V)(6D))).Put("fill", ((V)("#5cc2ff"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2D))).V, pg_567);
Call(S_16, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)("M324 -1q3 -9 6 0M330 -1q3 -12 6 0"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2D))).Put("fill", ((V)("none"))).Put("stroke-linecap", ((V)("round"))).V, pg_567);
pgD_569 = Call(S_16, V.Undef, ((V)("circle")), NewObj(4).Put("r", ((V)(7D))).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#4a1a73"))).Put("stroke-width", ((V)(2.4))).V, pg_567);
lines_570 = Arr();
{
double i_1651 = 0;
i_1651 = 0D;
while (true) {
if (!((i_1651 < 18D))) break;
Invoke(lines_570, "push", NewObj(5).Put("e", Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)((NumTruthy((i_1651 % 3D)) ? 2.2 : 3.2)))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0D))).V, speedL_533)).Put("x", ((V)((ToNum(Invoke(G("Math"), "random")) * ToNum(W_515))))).Put("y", ((V)((ToNum(Invoke(G("Math"), "random")) * ToNum(H_516))))).Put("n", ((V)((0.6 + (ToNum(Invoke(G("Math"), "random")) * 0.8))))).Put("near", ((i_1651 < 6D) ? V.True : V.False)).V);
i_1651++;
}
}
flash_571 = Call(S_16, V.Undef, ((V)("rect")), NewObj(7).Put("x", ((V)((-10D)))).Put("y", ((V)((-10D)))).Put("width", Add(W_515, ((V)(20D)))).Put("height", Add(H_516, ((V)(20D)))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0D))).Put("pointer-events", ((V)("none"))).V, fg_514);
AU_572 = V.Null;
me_576 = Invoke(ctx_512, "creature", Get(ctx_512, "playerKey"), NewObj(1).Put("yaw", ((V)(58D))).V);
Invoke(me_576, "depth", ((V)(0D)));
C0_577 = Arr(((V)(186D)), ((V)(142D)));
C1_578 = Arr(((V)(150D)), ((V)(128D)));
Z0_579 = 1.08;
tNow_580 = ((V)(0D));
friends_581 = V.Null;
pool_582 = V.Null;
st_583 = NewObj(32).Put("off", ((V)(0D))).Put("phase", ((V)("ready"))).Put("s", ((V)(ST0_54))).Put("l", ((V)(0D))).Put("tgt", ((V)(0D))).Put("h", ((V)(SH_47))).Put("ha", ((V)(0D))).Put("vh", ((V)(0D))).Put("v", ((V)(0D))).Put("top", ((V)(0D))).Put("z", ((V)(Z0_579))).Put("lc", ((V)(0D))).Put("sc", ((V)(ST0_54))).Put("cx", GetIdx(C0_577, 0D)).Put("cy", GetIdx(C0_577, 1D)).Put("stun", ((V)(0D))).Put("boostT", ((V)(0D))).Put("punch", ((V)(0D))).Put("mud", ((V)(0D))).Put("key", ((V)(0D))).Put("t0", ((V)(0D))).Put("yaw", ((V)(58D))).Put("boosts", ((V)(0D))).Put("bonks", ((V)(0D))).Put("shake", ((V)(0D))).Put("toldPool", ((V)(0D))).Put("lipV", ((V)(0D))).Put("k", ((V)(0D))).Put("trail", ((V)(0D))).Put("bot", ((V)(0D))).Put("botT", ((V)(0D))).Put("sparkT", ((V)(0D))).V;
scr_584 = Fn((V _self505, int _argc1653, V s_1659, V l_1660, V h_1661, V _a1658, V[] _rest1654) => {
V p_1662 = default;
p_1662 = Call(Wp_28, V.Undef, s_1659, l_1660, h_1661);
return Arr(Add(Get(st_583, "tx"), ((V)((ToNum(Get(st_583, "z")) * ToNum(GetIdx(p_1662, 0D)))))), Add(Get(st_583, "ty"), ((V)((ToNum(Get(st_583, "z")) * ToNum(GetIdx(p_1662, 1D)))))));
return default;
}, 3, "", true);
drag_586 = V.Null;
api_587 = NewObj(15).Put("option", Fn((V _self1663, int _argc1664, V id_1670, V _a1667, V _a1668, V _a1669, V[] _rest1665) => {
if (_self1663.IsNullish) _self1663 = GlobalV;
look_517 = id_1670;
{
foreach (V _k1671 in new JsIter(new ArrBuilder().Spread(Invoke(chunks_541, "keys")).V)) {
V i_1672 = default;
i_1672 = _k1671;
Call(dropChunk_549, V.Undef, i_1672);
}
}
Call(buildStatic_551, V.Undef);
return default;
}, 1, "option", false)).Put("start", Fn((V _self1673, int _argc1674, V _a1676, V _a1677, V _a1678, V _a1679, V[] _rest1675) => {
if (_self1673.IsNullish) _self1673 = GlobalV;
look_517 = (Get(Get(ctx_512, "G"), "_opt") is var _t1680 && Truthy(_t1680) ? _t1680 : look_517);
Call(reset_585, V.Undef);
Set(st_583, "phase", ((V)("ride")));
Set(st_583, "t0", tNow_580);
Invoke(ctx_512, "hint", ((V)("")));
Invoke(SFX_20, "whoosh");
Call(windOn_573, V.Undef);
Call(G("setTimeout"), V.Undef, Fn((V _self1673, int _argc1688, V _a1690, V _a1691, V _a1692, V _a1693, V[] _rest1689) => {
return ((SEqS(Get(st_583, "phase"), "ride") ? V.True : V.False) is var _t1694 && !Truthy(_t1694) ? _t1694 : Invoke(ctx_512, "toast", ((V)("Drag up / down to switch sides")), ((V)((ToNum(W_515) / 2D))), ((V)((ToNum(H_516) - 70D))), ((V)("#ffffff"))));
}, 0, "", true), ((V)(900D)));
return default;
}, 0, "start", false)).Put("down", Fn((V _self1695, int _argc1696, V p_1702, V _a1699, V _a1700, V _a1701, V[] _rest1697) => {
if (_self1695.IsNullish) _self1695 = GlobalV;
drag_586 = NewObj(3).Put("x", Get(p_1702, "x")).Put("y", Get(p_1702, "y")).Put("l", Get(st_583, "tgt")).V;
return default;
}, 1, "down", false)).Put("move", Fn((V _self1703, int _argc1704, V p_1710, V _a1707, V _a1708, V _a1709, V[] _rest1705) => {
if (_self1703.IsNullish) _self1703 = GlobalV;
if (!(Truthy(drag_586))) {
return default;
}
Set(st_583, "tgt", Call(cl_17, V.Undef, Add(Get(drag_586, "l"), ((V)((((ToNum(Get(p_1710, "x")) - ToNum(Get(drag_586, "x"))) - (ToNum(Get(p_1710, "y")) - ToNum(Get(drag_586, "y")))) * 0.011)))), ((V)((-LMAX_41))), ((V)(LMAX_41))));
return default;
}, 1, "move", false)).Put("up", Fn((V _self1711, int _argc1712, V _a1714, V _a1715, V _a1716, V _a1717, V[] _rest1713) => {
if (_self1711.IsNullish) _self1711 = GlobalV;
drag_586 = V.Null;
return default;
}, 0, "up", false)).Put("key", Fn((V _self1718, int _argc1719, V k_1725, V dn_1726, V _a1723, V _a1724, V[] _rest1720) => {
double d_1727 = 0;
if (_self1718.IsNullish) _self1718 = GlobalV;
d_1727 = ((((SEqS(k_1725, "ArrowUp") || SEqS(k_1725, "ArrowRight")) || SEqS(k_1725, "w")) || SEqS(k_1725, "d")) ? 1D : ((((SEqS(k_1725, "ArrowDown") || SEqS(k_1725, "ArrowLeft")) || SEqS(k_1725, "s")) || SEqS(k_1725, "a")) ? (-1D) : 0D));
if (!(NumTruthy(d_1727))) {
return default;
}
Set(st_583, "key", (Truthy(dn_1726) ? ((V)(d_1727)) : (SEqN(Get(st_583, "key"), d_1727) ? ((V)(0D)) : Get(st_583, "key"))));
return (true ? V.True : V.False);
return default;
}, 2, "key", false)).Put("_state", Fn((V _self505, int _argc1728, V _a1730, V _a1731, V _a1732, V _a1733, V[] _rest1729) => {
return NewObj(12).Put("phase", Get(st_583, "phase")).Put("s", ((V)(Round(ToNum(Get(st_583, "s")))))).Put("l", ((V)(ToNum(Invoke(Get(st_583, "l"), "toFixed", ((V)(2D))))))).Put("v", ((V)(ToNum(Invoke(Get(st_583, "v"), "toFixed", ((V)(1D))))))).Put("h", ((V)(Round(ToNum(Get(st_583, "h")))))).Put("top", ((V)(Round(ToNum(Get(st_583, "top")))))).Put("boosts", Get(st_583, "boosts")).Put("bonks", Get(st_583, "bonks")).Put("t", ((V)(ToNum(Invoke(((V)(((ToNum(tNow_580) - ToNum(Get(st_583, "t0"))) / 1000D))), "toFixed", ((V)(1D))))))).Put("k", ((V)(ToNum(Invoke(Get(st_583, "k"), "toFixed", ((V)(2D))))))).Put("lip", ((V)(Round(ToNum(Get(st_583, "lipV")))))).Put("z", ((V)(ToNum(Invoke(Get(st_583, "z"), "toFixed", ((V)(2D))))))).V;
}, 0, "_state", true)).Put("_bot", Fn((V _self1734, int _argc1735, V k_1741, V _a1738, V _a1739, V _a1740, V[] _rest1736) => {
if (_self1734.IsNullish) _self1734 = GlobalV;
Set(st_583, "bot", k_1741);
return default;
}, 1, "_bot", false)).Put("_setV", Fn((V _self1742, int _argc1743, V v_1749, V _a1746, V _a1747, V _a1748, V[] _rest1744) => {
if (_self1742.IsNullish) _self1742 = GlobalV;
Set(st_583, "v", v_1749);
Set(st_583, "top", ((V)(Max(ToNum(Get(st_583, "top")), ToNum(v_1749)))));
return default;
}, 1, "_setV", false)).Put("_items", Fn((V _self505, int _argc1750, V _a1752, V _a1753, V _a1754, V _a1755, V[] _rest1751) => {
return Invoke(items_552, "map", Fn((V _self505, int _argc1756, V q_1762, V _a1759, V _a1760, V _a1761, V[] _rest1757) => {
return Arr(Get(q_1762, "t"), ((V)(Round(ToNum(Get(q_1762, "s"))))), ((V)(ToNum(Invoke(Get(q_1762, "l"), "toFixed", ((V)(2D)))))));
}, 1, "", true));
}, 0, "_items", true)).Put("_look", Fn((V _self505, int _argc1763, V _a1765, V _a1766, V _a1767, V _a1768, V[] _rest1764) => {
return look_517;
}, 0, "_look", true)).Put("_ff", Fn((V _self1769, int _argc1770, V sec_1776, V _a1773, V _a1774, V _a1775, V[] _rest1771) => {
double n_1777 = 0;
double tr_1778 = 0;
if (_self1769.IsNullish) _self1769 = GlobalV;
n_1777 = Round((ToNum(sec_1776) * 60D));
tr_1778 = (ToNum(tNow_580) - ToNum(Get(st_583, "off")));
{
double i_1779 = 0;
i_1779 = 0D;
while (true) {
if (!((i_1779 < n_1777))) break;
OpSet(st_583, "off", 0, ((V)((1000D / 60D))));
Invoke(api_587, "update", ((V)((1D / 60D))), ((V)(tr_1778)));
i_1779++;
}
}
return Invoke(api_587, "_state");
return default;
}, 1, "_ff", false)).Put("celebrate", Fn((V _self1781, int _argc1782, V s_1788, V _a1785, V _a1786, V _a1787, V[] _rest1783) => {
if (_self1781.IsNullish) _self1781 = GlobalV;
Invoke(me_576, "play", ((V)((GeN(s_1788, 2D) ? "happy" : "idle"))));
if (Truthy(friends_581)) {
Invoke(friends_581, "forEach", Fn((V _self1781, int _argc1789, V f_1795, V _a1792, V _a1793, V _a1794, V[] _rest1790) => {
return Invoke(Get(f_1795, "c"), "play", ((V)((GeN(s_1788, 2D) ? "happy" : "idle"))));
}, 1, "", true));
}
return default;
}, 1, "celebrate", false)).Put("destroy", Fn((V _self1796, int _argc1797, V _a1799, V _a1800, V _a1801, V _a1802, V[] _rest1798) => {
if (_self1796.IsNullish) _self1796 = GlobalV;
Call(windOff_575, V.Undef);
return default;
}, 0, "destroy", false)).Put("update", Fn((V _self1803, int _argc1804, V dt_1810, V t_1811, V _a1808, V _a1809, V[] _rest1805) => {
V L_1812 = default;
V E_1813 = default;
V fast_1814 = default;
if (_self1803.IsNullish) _self1803 = GlobalV;
t_1811 = Add(t_1811, Get(st_583, "off"));
tNow_580 = t_1811;
L_1812 = GetK(LOOK_61, look_517);
E_1813 = NewObj(5).Put("sit", ((V)(1D))).Put("armL", ((V)(64D))).Put("armR", ((V)(64D))).Put("lean", ((V)((-0.3)))).Put("smile", ((V)(0.7))).V;
if ((SEqS(Get(st_583, "phase"), "ride") || SEqS(Get(st_583, "phase"), "ramp"))) {
double ls_1815 = 0;
V dl_1816 = default;
if (Truthy(Get(st_583, "bot"))) {
Call(botSteer_588, V.Undef, t_1811);
}
if (Truthy(Get(st_583, "key"))) {
Set(st_583, "tgt", Call(cl_17, V.Undef, Add(Get(st_583, "tgt"), ((V)(((ToNum(Get(st_583, "key")) * 2.4) * ToNum(dt_1810))))), ((V)((-LMAX_41))), ((V)(LMAX_41))));
}
ls_1815 = ((GtN(Get(st_583, "stun"), 0D) ? 1.3 : 3.2) * ToNum(Get(L_1812, "steer")));
dl_1816 = Call(cl_17, V.Undef, ((V)((ToNum(Get(st_583, "tgt")) - ToNum(Get(st_583, "l"))))), ((V)(((-ls_1815) * ToNum(dt_1810)))), ((V)((ls_1815 * ToNum(dt_1810)))));
OpSet(st_583, "l", 0, dl_1816);
Set(st_583, "steer", Call(lerp_18, V.Undef, (Get(st_583, "steer") is var _t1817 && Truthy(_t1817) ? _t1817 : ((V)(0D))), ((V)(((ToNum(dl_1816) / Max(ToNum(dt_1810), 0.001)) / ls_1815))), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1810)) * 8D)))))));
if (LtN(Get(st_583, "s"), SD0_53)) {
Set(st_583, "v", ((V)(Min(14D, ToNum(Add(Get(st_583, "v"), ((V)((30D * ToNum(dt_1810))))))))));
} else {
if ((LtN(Get(st_583, "v"), (VB_38 + 8D)) && LtN(Get(st_583, "s"), 700D))) {
Set(st_583, "v", ((V)(Min((VB_38 + 8D), ToNum(Add(Get(st_583, "v"), ((V)((34D * ToNum(dt_1810))))))))));
} else {
if (LtN(Get(st_583, "v"), VB_38)) {
Set(st_583, "v", ((V)(Min(VB_38, ToNum(Add(Get(st_583, "v"), ((V)((14D * ToNum(dt_1810))))))))));
} else {
Set(st_583, "v", ((V)(Max(VB_38, (ToNum(Get(st_583, "v")) - (DEC_40 * ToNum(dt_1810)))))));
}
}
}
if (GtN(Get(st_583, "mud"), 0D)) {
Set(st_583, "v", ((V)(Max((VB_38 * 0.8), (ToNum(Get(st_583, "v")) - (24D * ToNum(dt_1810)))))));
OpSet(st_583, "mud", 1, dt_1810);
}
Set(st_583, "v", ((V)(Min(VMAX_39, ToNum(Get(st_583, "v"))))));
Set(st_583, "top", ((V)(Max(ToNum(Get(st_583, "top")), ToNum(Get(st_583, "v"))))));
OpSet(st_583, "s", 0, ((V)(((ToNum(Get(st_583, "v")) * KV_37) * ToNum(dt_1810)))));
Set(st_583, "stun", ((V)(Max(0D, (ToNum(Get(st_583, "stun")) - ToNum(dt_1810))))));
Set(st_583, "boostT", ((V)(Max(0D, (ToNum(Get(st_583, "boostT")) - ToNum(dt_1810))))));
Set(st_583, "punch", ((V)(Max(0D, (ToNum(Get(st_583, "punch")) - (ToNum(dt_1810) * 2.5))))));
if ((SEqS(Get(st_583, "phase"), "ride") && (GtN(Get(st_583, "ha"), 0D) || GtN(Get(st_583, "vh"), 0D)))) {
OpSet(st_583, "vh", 1, ((V)((GA_49 * ToNum(dt_1810)))));
OpSet(st_583, "ha", 0, ((V)((ToNum(Get(st_583, "vh")) * ToNum(dt_1810)))));
if (LeN(Get(st_583, "ha"), 0D)) {
Set(st_583, "ha", ((V)(0D)));
Set(st_583, "vh", ((V)(0D)));
OpSet(st_583, "v", 0, ((V)(2D)));
InvokeSpread(ctx_512, "burst", new ArrBuilder().Spread(Call(scr_584, V.Undef, Get(st_583, "s"), Get(st_583, "l"), Call(HS_57, V.Undef, Get(st_583, "s")))).Add(((V)("drop"))).Add(((V)(6D))).Add(NewObj(2).Put("col", ((V)("#ffffff"))).Put("v", ((V)(70D))).V).V);
Invoke(SFX_20, "tap");
}
}
if ((GeN(Get(st_583, "s"), RS_45) && SEqS(Get(st_583, "phase"), "ride"))) {
Set(st_583, "phase", ((V)("ramp")));
Set(st_583, "ha", ((V)(0D)));
Set(st_583, "vh", ((V)(0D)));
}
Set(st_583, "h", Add(Call(HS_57, V.Undef, Get(st_583, "s")), Get(st_583, "ha")));
if ((!(Truthy(Get(st_583, "toldPool"))) && GtN(Get(st_583, "s"), (RS_45 - 1500D)))) {
Set(st_583, "toldPool", ((V)(1D)));
Invoke(ctx_512, "toast", ((V)("Almost there! Go go go!")), ((V)((ToNum(W_515) / 2D))), ((V)(84D)), ((V)("#ffe36e")));
}
Call(hits_589, V.Undef);
if (GeN(Get(st_583, "s"), LEN_44)) {
Call(launch_590, V.Undef);
}
}
if (SEqS(Get(st_583, "phase"), "fly")) {
V p_1818 = default;
OpSet(st_583, "s", 0, ((V)((ToNum(Get(st_583, "vs")) * ToNum(dt_1810)))));
OpSet(st_583, "vh", 1, ((V)((GF_50 * ToNum(dt_1810)))));
OpSet(st_583, "h", 0, ((V)((ToNum(Get(st_583, "vh")) * ToNum(dt_1810)))));
p_1818 = Call(scr_584, V.Undef, Get(st_583, "s"), Get(st_583, "l"), Get(st_583, "h"));
if (((LtN(GetIdx(p_1818, 1D), (-90D)) || ((ToNum(t_1811) - ToNum(Get(st_583, "tf"))) > 1300D)) && !(Truthy(Get(st_583, "tr"))))) {
Call(transition_591, V.Undef);
}
}
fast_1814 = Call(cl_17, V.Undef, ((V)(((ToNum(Get(st_583, "v")) - 55D) / 50D))), ((V)(0D)), ((V)(1D)));
if (SEqS(Get(st_583, "phase"), "ready")) {
E_1813 = NewObj(6).Put("sit", ((V)(1D))).Put("armL", ((V)((50D + (20D * FdLibm.Sin((ToNum(t_1811) / 260D))))))).Put("armR", ((V)((50D + (20D * FdLibm.Sin(((ToNum(t_1811) / 260D) + 1.4))))))).Put("lean", ((V)((-0.2)))).Put("smile", ((V)(0.8))).Put("sq", ((V)((0.03 * FdLibm.Sin((ToNum(t_1811) / 180D)))))).V;
} else {
if ((SEqS(Get(st_583, "phase"), "ride") || SEqS(Get(st_583, "phase"), "ramp"))) {
V sw_1819 = default;
sw_1819 = (Get(st_583, "steer") is var _t1820 && Truthy(_t1820) ? _t1820 : ((V)(0D)));
E_1813 = NewObj(10).Put("sit", ((V)(1D))).Put("armL", ((V)(((60D + (ToNum(sw_1819) * 25D)) + (ToNum(fast_1814) * 70D))))).Put("armR", ((V)(((60D - (ToNum(sw_1819) * 25D)) + (ToNum(fast_1814) * 70D))))).Put("lean", ((V)(((-0.35) - ((ToNum(Get(st_583, "v")) - VB_38) / 120D))))).Put("smile", ((V)(0.7))).Put("open", ((V)((0.25 + (ToNum(fast_1814) * 0.5))))).Put("close", ((V)((ToNum(fast_1814) * 0.35)))).Put("tilt", ((V)((((-ToNum(sw_1819)) * 9D) + ((FdLibm.Sin((ToNum(t_1811) / 37D)) * ToNum(fast_1814)) * 2.5))))).Put("ly", ((V)((-0.3)))).Put("lx", ((V)(0.6))).V;
if (LtN(Get(st_583, "s"), SD0_53)) {
Object_assign(E_1813, NewObj(5).Put("armL", ((V)((20D + (22D * FdLibm.Sin((ToNum(t_1811) / 90D))))))).Put("armR", ((V)((20D - (22D * FdLibm.Sin((ToNum(t_1811) / 90D))))))).Put("lean", ((V)(0.3))).Put("smile", ((V)(0.9))).Put("sq", ((V)((0.04 * FdLibm.Sin((ToNum(t_1811) / 90D)))))).V);
}
if ((GtN(Get(st_583, "boostT"), 0D) || GtN(Get(st_583, "ha"), 4D))) {
Object_assign(E_1813, NewObj(6).Put("armL", ((V)(158D))).Put("armR", ((V)(152D))).Put("hap", ((V)(1D))).Put("open", ((V)(0.85))).Put("smile", ((V)(1D))).Put("close", ((V)(0D))).V);
}
if (GtN(Get(st_583, "stun"), 0D)) {
double u_1821 = 0;
u_1821 = (ToNum(Get(st_583, "stun")) / 0.6);
Object_assign(E_1813, NewObj(8).Put("tilt", ((V)(((FdLibm.Sin((ToNum(t_1811) / 40D)) * 12D) * u_1821)))).Put("sq", ((V)((0.1 * u_1821)))).Put("armL", ((V)(110D))).Put("armR", ((V)(40D))).Put("open", ((V)(0.5))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("close", ((V)(0D))).V);
}
if (GtN(Get(st_583, "mud"), 0D)) {
Object_assign(E_1813, NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("smile", ((V)(0D))).Put("open", ((V)(0.2))).V);
}
} else {
if (SEqS(Get(st_583, "phase"), "fly")) {
E_1813 = (GeN(Get(st_583, "lipV"), 75D) ? NewObj(8).Put("sit", ((V)(1D))).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("open", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sq", ((V)(0.08))).Put("close", ((V)(0.4))).V : NewObj(9).Put("sit", ((V)(0.6))).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).Put("open", ((V)(0.9))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("lean", ((V)((-0.5)))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V);
}
}
}
if (SEqS(Get(st_583, "phase"), "pool")) {
Invoke(pool_582, "update", dt_1810, t_1811);
return default;
}
Invoke(me_576, "pose", E_1813);
Set(st_583, "yaw", Call(lerp_18, V.Undef, Get(st_583, "yaw"), ((V)((58D + (SEqS(Get(st_583, "phase"), "ride") ? (ToNum(Call(cl_17, V.Undef, (Get(st_583, "steer") is var _t1822 && Truthy(_t1822) ? _t1822 : ((V)(0D))), ((V)((-1D))), ((V)(1D)))) * 16D) : 0D)))), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1810)) * 6D)))))));
Invoke(me_576, "yaw", Get(st_583, "yaw"));
Call(camera_593, V.Undef, dt_1810, t_1811);
Call(place_594, V.Undef, t_1811, dt_1810);
Call(hud__595, V.Undef, dt_1810, t_1811);
Call(windSet_574, V.Undef, Get(st_583, "v"), ((SEqS(Get(st_583, "phase"), "ride") || SEqS(Get(st_583, "phase"), "ramp")) ? V.True : V.False));
return default;
}, 2, "update", false)).V;
Call(reset_585, V.Undef);
Call(camera_593, V.Undef, ((V)(1D)), ((V)(0D)));
Call(place_594, V.Undef, ((V)(0D)), ((V)(0D)));
Call(hud__595, V.Undef, ((V)(0D)), ((V)(0D)));
return api_587;
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
