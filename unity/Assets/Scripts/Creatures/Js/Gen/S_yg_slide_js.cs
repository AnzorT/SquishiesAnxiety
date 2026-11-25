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
go_8 = Fn((V _arrowThis15, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_16 = default;
V S_17 = default;
V cl_18 = default;
V lerp_19 = default;
V r2_20 = default;
V SFX_21 = default;
V TAU_22 = default;
V rad_23 = default;
V FA_24 = default;
V LA_25 = default;
V F_26 = default;
V LV_27 = default;
double HW_28 = 0;
V Wp_29 = default;
V P2_30 = default;
V G3_31 = default;
V poly_32 = default;
V quad_33 = default;
V EL_34 = default;
V gEl_35 = default;
V blob_36 = default;
V rnd_37 = default;
double KV_38 = 0;
double VB_39 = 0;
double VMAX_40 = 0;
double DEC_41 = 0;
double LMAX_42 = 0;
double RW_43 = 0;
double CS_44 = 0;
double LEN_45 = 0;
double RS_46 = 0;
double RH_47 = 0;
double SH_48 = 0;
double WH_49 = 0;
double GA_50 = 0;
double GF_51 = 0;
double K_52 = 0;
double T0_53 = 0;
double SD0_54 = 0;
double ST0_55 = 0;
V SECT_56 = default;
V secAt_57 = default;
V HS_58 = default;
V TIERS_59 = default;
V tierOf_60 = default;
V DEF_61 = default;
V LOOK_62 = default;
V ICON_63 = default;
V ART_64 = default;
V tree_65 = default;
V bush_66 = default;
V flowers_67 = default;
V pinwheel_68 = default;
V sprinkler_69 = default;
V birdhouse_70 = default;
V shed_71 = default;
V haystack_72 = default;
V sunflower_73 = default;
V lounger_74 = default;
V umbrella_75 = default;
V ball_76 = default;
V donut_77 = default;
V fence_78 = default;
V bed_79 = default;
V css_80 = default;
css_80 = Fn((V _self81, int _argc82, V _a84, V _a85, V _a86, V _a87, V[] _rest83) => {
V st_88 = default;
if (_self81.IsNullish) _self81 = GlobalV;
if (Truthy(Invoke(G("document"), "getElementById", ((V)("ygs-css"))))) {
return default;
}
st_88 = Invoke(G("document"), "createElement", ((V)("style")));
Set(st_88, "id", ((V)("ygs-css")));
Set(st_88, "textContent", ((V)(JsStrBuf.Begin().S(".ygs-spin{animation:ygsSpin 1.1s linear infinite;}@keyframes ygsSpin{to{transform:rotate(360deg);}}").S(".ygs-spr{animation:ygsSpr .6s linear infinite;}@keyframes ygsSpr{to{stroke-dashoffset:-30;}}").S(".ygs-bob{animation:ygsBob 1.8s ease-in-out infinite;}@keyframes ygsBob{50%{transform:translateY(-2.5px);}}").S(".ygs-glow{animation:ygsGlow .7s ease-in-out infinite alternate;}@keyframes ygsGlow{to{fill:#fff3b0;}}").S(".ygs-shim{animation:ygsShim 1.2s ease-in-out infinite alternate;}@keyframes ygsShim{to{fill:#b6ecff;}}").S(".ygs-tw{animation:ygsTw .9s ease-in-out infinite alternate;transform-box:fill-box;transform-origin:center;}@keyframes ygsTw{from{opacity:.3;}to{opacity:1;}}").S(".ygs-tip,.ygs-pop{transform-box:fill-box;transform-origin:50% 100%;transition:transform .35s cubic-bezier(.3,1.5,.5,1),opacity .4s;}").S(".ygs-hit .ygs-tip{transform:rotate(78deg) translateY(4px);}.ygs-hit .ygs-pop{transform:scale(1.25,0.35);opacity:0.6;}").End())));
Invoke(Get(G("document"), "head"), "appendChild", st_88);
return default;
}, 0, "css", false);
YG_16 = Get(G("window"), "YardGames");
if ((!(Truthy(YG_16)) || !(Truthy(Get(YG_16, "add"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t89 = YG_16;
if (_t89.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t89));
{ V _t90 = Get(_t89, "S");
S_17 = _t90; }
{ V _t91 = Get(_t89, "cl");
cl_18 = _t91; }
{ V _t92 = Get(_t89, "lerp");
lerp_19 = _t92; }
{ V _t93 = Get(_t89, "r2");
r2_20 = _t93; }
{ V _t94 = Get(_t89, "SFX");
SFX_21 = _t94; }
{ V _t95 = Get(_t89, "TAU");
TAU_22 = _t95; } }
rad_23 = Fn((V _arrowThis103, int _argc96, V d_102, V _a99, V _a100, V _a101, V[] _rest97) => {
return ((V)(((ToNum(d_102) * System.Math.PI) / 180D)));
}, 1, "", true);
FA_24 = Call(rad_23, V.Undef, ((V)(32D)));
LA_25 = Call(rad_23, V.Undef, ((V)((-24D))));
F_26 = Arr(((V)(FdLibm.Cos(ToNum(FA_24)))), ((V)(FdLibm.Sin(ToNum(FA_24)))));
LV_27 = Arr(((V)(FdLibm.Cos(ToNum(LA_25)))), ((V)(FdLibm.Sin(ToNum(LA_25)))));
HW_28 = 52D;
Wp_29 = Fn((V _arrowThis113, int _argc104, V s_110, V l_111, V h_112, V _a109, V[] _rest105) => {
return Arr(((V)(((ToNum(s_110) * ToNum(GetIdx(F_26, 0D))) + ((ToNum(l_111) * HW_28) * ToNum(GetIdx(LV_27, 0D)))))), ((V)((((ToNum(s_110) * ToNum(GetIdx(F_26, 1D))) + ((ToNum(l_111) * HW_28) * ToNum(GetIdx(LV_27, 1D)))) - ToNum((h_112 is var _t114 && Truthy(_t114) ? _t114 : ((V)(0D))))))));
}, 3, "", true);
P2_30 = Fn((V _arrowThis122, int _argc115, V p_121, V _a118, V _a119, V _a120, V[] _rest116) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(p_121, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_121, 1D))).End()));
}, 1, "", true);
G3_31 = Fn((V _arrowThis132, int _argc123, V ds_129, V lp_130, V h_131, V _a128, V[] _rest124) => {
return Arr(((V)(((ToNum(ds_129) * ToNum(GetIdx(F_26, 0D))) + (ToNum(lp_130) * ToNum(GetIdx(LV_27, 0D)))))), ((V)((((ToNum(ds_129) * ToNum(GetIdx(F_26, 1D))) + (ToNum(lp_130) * ToNum(GetIdx(LV_27, 1D)))) - ToNum((h_131 is var _t133 && Truthy(_t133) ? _t133 : ((V)(0D))))))));
}, 3, "", true);
poly_32 = Fn((V _arrowThis141, int _argc134, V pts_140, V _a137, V _a138, V _a139, V[] _rest135) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_140, "map", P2_30), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
quad_33 = Fn((V _arrowThis154, int _argc142, V s0_148, V s1_149, V l0_150, V l1_151, V[] _rest143) => {
V h0_152 = default;
V h1_153 = default;
h0_152 = (_argc142 > 4 ? _rest143[0] : V.Undef);
h1_153 = (_argc142 > 5 ? _rest143[1] : V.Undef);
return Call(poly_32, V.Undef, Arr(Call(Wp_29, V.Undef, s0_148, l0_150, h0_152), Call(Wp_29, V.Undef, s1_149, l0_150, (h1_153.IsNullish ? h0_152 : h1_153)), Call(Wp_29, V.Undef, s1_149, l1_151, (h1_153.IsNullish ? h0_152 : h1_153)), Call(Wp_29, V.Undef, s0_148, l1_151, h0_152)));
}, 6, "", true);
EL_34 = Call(Fn((V _arrowThis161, int _argc155, V _a157, V _a158, V _a159, V _a160, V[] _rest156) => {
double a_162 = 0;
double b_163 = 0;
double c_164 = 0;
double m_165 = 0;
double d_166 = 0;
a_162 = ((ToNum(GetIdx(F_26, 0D)) * ToNum(GetIdx(F_26, 0D))) + (ToNum(GetIdx(LV_27, 0D)) * ToNum(GetIdx(LV_27, 0D))));
b_163 = ((ToNum(GetIdx(F_26, 0D)) * ToNum(GetIdx(F_26, 1D))) + (ToNum(GetIdx(LV_27, 0D)) * ToNum(GetIdx(LV_27, 1D))));
c_164 = ((ToNum(GetIdx(F_26, 1D)) * ToNum(GetIdx(F_26, 1D))) + (ToNum(GetIdx(LV_27, 1D)) * ToNum(GetIdx(LV_27, 1D))));
m_165 = ((a_162 + c_164) / 2D);
d_166 = System.Math.Sqrt(((((a_162 - c_164) * (a_162 - c_164)) / 4D) + (b_163 * b_163)));
return NewObj(3).Put("kx", ((V)(System.Math.Sqrt((m_165 + d_166))))).Put("ky", ((V)(System.Math.Sqrt((m_165 - d_166))))).Put("rot", Call(r2_20, V.Undef, ((V)((((FdLibm.Atan2((2D * b_163), (a_162 - c_164)) / 2D) * 180D) / System.Math.PI))))).V;
return default;
}, 0, "", true), V.Undef);
gEl_35 = Fn((V _arrowThis177, int _argc167, V x_173, V y_174, V r_175, V a_176, V[] _rest168) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(r2_20, V.Undef, x_173)).S("\" cy=\"").V(Call(r2_20, V.Undef, y_174)).S("\" rx=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(r_175) * ToNum(Get(EL_34, "kx"))))))).S("\" ry=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(r_175) * ToNum(Get(EL_34, "ky"))))))).S("\" transform=\"rotate(").V(Get(EL_34, "rot")).S(" ").V(Call(r2_20, V.Undef, x_173)).S(" ").V(Call(r2_20, V.Undef, y_174)).S(")\" ").V((a_176 is var _t178 && Truthy(_t178) ? _t178 : ((V)("")))).S("/>").End()));
}, 4, "", true);
blob_36 = Fn((V _arrowThis189, int _argc179, V hs_185, V wp_186, V wob_187, V sd_188, V[] _rest180) => {
V pts_190 = default;
JsStrBuf d_191 = null;
pts_190 = Arr();
{
double i_192 = 0;
i_192 = 0D;
while (true) {
if (!((i_192 < 18D))) break;
double t_194 = 0;
double k_195 = 0;
t_194 = ((i_192 / 18D) * ToNum(TAU_22));
k_195 = ((1D + ((ToNum(wob_187) * FdLibm.Sin(ToNum(Add(((V)((t_194 * 3D))), sd_188)))) * 0.6)) + ((ToNum(wob_187) * FdLibm.Sin(((t_194 * 5D) + (ToNum(sd_188) * 2D)))) * 0.4));
Invoke(pts_190, "push", Call(G3_31, V.Undef, ((V)(((FdLibm.Cos(t_194) * ToNum(hs_185)) * k_195))), ((V)(((FdLibm.Sin(t_194) * ToNum(wp_186)) * k_195))), ((V)(0D))));
i_192++;
}
}
d_191 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(P2_30, V.Undef, GetIdx(pts_190, 0D))).End());
{
double i_196 = 0;
i_196 = 0D;
while (true) {
if (!(Lt(((V)(i_196)), Get(pts_190, "length")))) break;
V a_198 = default;
V b_199 = default;
V m_200 = default;
a_198 = GetIdx(pts_190, i_196);
b_199 = GetIdx(pts_190, ((i_196 + 1D) % ToNum(Get(pts_190, "length"))));
m_200 = Arr(((V)((ToNum(Add(GetIdx(a_198, 0D), GetIdx(b_199, 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(a_198, 1D), GetIdx(b_199, 1D))) / 2D))));
d_191.S("Q").V(Call(P2_30, V.Undef, a_198)).S(" ").V(Call(P2_30, V.Undef, m_200));
i_196++;
}
}
return ((V)(string.Concat(d_191.Str, "Z")));
return default;
}, 4, "", true);
rnd_37 = Fn((V _arrowThis208, int _argc201, V sd_207, V _a204, V _a205, V _a206, V[] _rest202) => {
return Fn((V _arrowThis215, int _argc209, V _a211, V _a212, V _a213, V _a214, V[] _rest210) => {
return ((V)((ToNum((sd_207 = ((V)((((ToNum(sd_207) * 9301D) + 49297D) % 233280D))))) / 233280D)));
}, 0, "", true);
}, 1, "", true);
KV_38 = 4D;
VB_39 = 37D;
VMAX_40 = 125D;
DEC_41 = 0.1;
LMAX_42 = 0.58;
RW_43 = 0.2;
CS_44 = 480D;
LEN_45 = 16000D;
RS_46 = (LEN_45 - 260D);
RH_47 = 40D;
SH_48 = 56D;
WH_49 = 21D;
GA_50 = 900D;
GF_51 = 560D;
K_52 = 80D;
T0_53 = (-150D);
SD0_54 = (-40D);
ST0_55 = (-96D);
SECT_56 = Arr(Arr(((V)(0D)), ((V)("meadow"))), Arr(((V)(3200D)), ((V)("garden"))), Arr(((V)(6800D)), ((V)("farm"))), Arr(((V)(10400D)), ((V)("sprinkle"))), Arr(((V)(13800D)), ((V)("final"))));
secAt_57 = Fn((V _arrowThis223, int _argc216, V s_222, V _a219, V _a220, V _a221, V[] _rest217) => {
V n_224 = default;
n_224 = ((V)("meadow"));
{
foreach (V _k225 in new JsIter(SECT_56)) {
V a_226 = default;
V b_227 = default;
{ V _t228 = ListOf(_k225);
{ V _t229 = GetIdx(_t228, 0D);
a_226 = _t229; }
{ V _t230 = GetIdx(_t228, 1D);
b_227 = _t230; }
}
if (Ge(s_222, a_226)) {
n_224 = b_227;
}
}
}
return n_224;
return default;
}, 1, "", true);
HS_58 = Fn((V _arrowThis238, int _argc231, V s_237, V _a234, V _a235, V _a236, V[] _rest232) => {
return ((V)((LeN(s_237, RS_46) ? SH_48 : (SH_48 + (RH_47 * Pow(ToNum(Call(cl_18, V.Undef, ((V)(((ToNum(s_237) - RS_46) / (LEN_45 - RS_46)))), ((V)(0D)), ((V)(1D)))), 2D))))));
}, 1, "", true);
TIERS_59 = Arr(Arr(((V)(0D)), ((V)("Splish!")), ((V)("#bfe8ff"))), Arr(((V)(42D)), ((V)("Splash!")), ((V)("#8fe0ff"))), Arr(((V)(60D)), ((V)("Big Splash!")), ((V)("#7ee0d6"))), Arr(((V)(80D)), ((V)("Mega Splash!")), ((V)("#ffe36e"))), Arr(((V)(100D)), ((V)("TIDAL WAVE!")), ((V)("#ff8fc8"))));
tierOf_60 = Fn((V _arrowThis246, int _argc239, V v_245, V _a242, V _a243, V _a244, V[] _rest240) => {
V t_247 = default;
t_247 = GetIdx(TIERS_59, 0D);
{
foreach (V _k248 in new JsIter(TIERS_59)) {
V q_249 = default;
q_249 = _k248;
if (Ge(v_245, GetIdx(q_249, 0D))) {
t_247 = q_249;
}
}
}
return t_247;
return default;
}, 1, "", true);
DEF_61 = NewObj(11).Put("rock", NewObj(4).Put("hs", ((V)(18D))).Put("hw", ((V)(0.34))).Put("hh", ((V)(26D))).Put("k", ((V)("hard"))).V).Put("gnome", NewObj(4).Put("hs", ((V)(12D))).Put("hw", ((V)(0.24))).Put("hh", ((V)(46D))).Put("k", ((V)("hard"))).V).Put("hay", NewObj(4).Put("hs", ((V)(20D))).Put("hw", ((V)(0.38))).Put("hh", ((V)(30D))).Put("k", ((V)("hard"))).V).Put("log", NewObj(4).Put("hs", ((V)(12D))).Put("hw", ((V)(0.75))).Put("hh", ((V)(18D))).Put("k", ((V)("hard"))).V).Put("bucket", NewObj(4).Put("hs", ((V)(12D))).Put("hw", ((V)(0.2))).Put("hh", ((V)(22D))).Put("k", ((V)("soft"))).V).Put("sand", NewObj(4).Put("hs", ((V)(18D))).Put("hw", ((V)(0.32))).Put("hh", ((V)(12D))).Put("k", ((V)("soft"))).V).Put("leaves", NewObj(4).Put("hs", ((V)(20D))).Put("hw", ((V)(0.34))).Put("hh", ((V)(10D))).Put("k", ((V)("soft"))).V).Put("mud", NewObj(5).Put("hs", ((V)(50D))).Put("hw", ((V)(0.44))).Put("hh", ((V)(3D))).Put("k", ((V)("mud"))).Put("flat", ((V)(1D))).V).Put("slick", NewObj(5).Put("hs", ((V)(50D))).Put("hw", ((V)(0.42))).Put("hh", ((V)(3D))).Put("k", ((V)("boost"))).Put("flat", ((V)(1D))).V).Put("gold", NewObj(5).Put("hs", ((V)(30D))).Put("hw", ((V)(0.4))).Put("hh", ((V)(3D))).Put("k", ((V)("gold"))).Put("flat", ((V)(1D))).V).Put("ramp", NewObj(5).Put("hs", ((V)(26D))).Put("hw", ((V)(0.95))).Put("hh", ((V)(18D))).Put("k", ((V)("ramp"))).Put("flat", ((V)(1D))).V).V;
LOOK_62 = NewObj(3).Put("rainbow", NewObj(12).Put("bands", Arr(((V)("#ff7a8a")), ((V)("#ffa95a")), ((V)("#ffdc5a")), ((V)("#7fd870")), ((V)("#5cb8ff")), ((V)("#a98bff")))).Put("top", ((V)("#ffffff"))).Put("face", ((V)("#e6e0f6"))).Put("side", ((V)("#cfc6ec"))).Put("seam", ((V)("#ffffff"))).Put("shine", ((V)("#ffffff"))).Put("deck", ((V)("#c9b8f2"))).Put("post", ((V)("#ffffff"))).Put("postD", ((V)("#a89ad0"))).Put("boost", ((V)(1D))).Put("hit", ((V)(1D))).Put("steer", ((V)(1.1))).V).Put("gold", NewObj(12).Put("bands", Arr(((V)("#f6c94a")), ((V)("#fbd96e")), ((V)("#f6c94a")), ((V)("#fbd96e")))).Put("top", ((V)("#fff2c0"))).Put("face", ((V)("#e8b43a"))).Put("side", ((V)("#cf9a24"))).Put("seam", ((V)("#fff6d0"))).Put("shine", ((V)("#ffffff"))).Put("deck", ((V)("#f3d27a"))).Put("post", ((V)("#f4f6fb"))).Put("postD", ((V)("#b9a060"))).Put("boost", ((V)(1.12))).Put("hit", ((V)(1D))).Put("steer", ((V)(1D))).V).Put("wood", NewObj(12).Put("planks", Arr(((V)("#d9a066")), ((V)("#cd9358")))).Put("top", ((V)("#e8b67c"))).Put("face", ((V)("#b47740"))).Put("side", ((V)("#9a6232"))).Put("seam", ((V)("#9a6232"))).Put("shine", ((V)("#fff2dc"))).Put("deck", ((V)("#e2ad74"))).Put("post", ((V)("#a46c3a"))).Put("postD", ((V)("#6b4426"))).Put("boost", ((V)(1D))).Put("hit", ((V)(0.85))).Put("steer", ((V)(1D))).V).V;
ICON_63 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#79c25c\"/><path d=\"M20 -4L44 -12L124 46L100 54Z\" fill=\"#ffffff\"/><path d=\"M26 -4L44 -10L118 44L100 50Z\" fill=\"#ff7a8a\"/><path d=\"M32 -4L44 -8L112 42L100 46Z\" fill=\"#ffdc5a\"/><path d=\"M38 -4L44 -6L106 40L100 42Z\" fill=\"#5cb8ff\"/>", "<path d=\"M40 30V54M70 52V76M100 54V80\" stroke=\"#ffffff\" stroke-width=\"3\"/><ellipse cx=\"22\" cy=\"70\" rx=\"20\" ry=\"7\" fill=\"#2a86e6\"/><ellipse cx=\"22\" cy=\"66\" rx=\"17\" ry=\"5\" fill=\"#8fe6ff\"/><path d=\"M14 64Q16 50 20 62M22 62Q25 44 28 62\" stroke=\"#ffffff\" stroke-width=\"2.6\" fill=\"none\" stroke-linecap=\"round\"/>", "<circle cx=\"58\" cy=\"18\" r=\"8\" fill=\"#ffe7c8\" stroke=\"#6b4426\" stroke-width=\"2\"/><path d=\"M38 6h-10M40 14h-12M38 22h-9\" stroke=\"#ffffff\" stroke-width=\"2.4\" stroke-linecap=\"round\" opacity=\"0.9\"/></svg>")));
ART_64 = NewObj(11).Put("rock", Fn((V _arrowThis256, int _argc250, V _a252, V _a253, V _a254, V _a255, V[] _rest251) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(22D)), ((V)("fill=\"#2d4a22\" opacity=\"0.22\"")))).S("<path d=\"M-24 2C-26 -10 -16 -24 -2 -25C12 -26 24 -16 25 -4C26 2 20 6 0 6C-16 6 -23 5 -24 2Z\" fill=\"#a3a9b2\" stroke=\"#5c6470\" stroke-width=\"2.2\"/><path d=\"M-15 -14C-9 -21 3 -22 9 -18\" stroke=\"#d2d6dc\" stroke-width=\"4.5\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M5 3C14 1 20 -4 22 -9\" stroke=\"#7e8690\" stroke-width=\"3\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M-20 -2Q-16 -8 -10 -6\" stroke=\"#7fb06a\" stroke-width=\"3\" fill=\"none\" stroke-linecap=\"round\"/>").End()));
}, 0, "rock", true)).Put("gnome", Fn((V _arrowThis263, int _argc257, V _a259, V _a260, V _a261, V _a262, V[] _rest258) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(14D)), ((V)("fill=\"#2d4a22\" opacity=\"0.22\"")))).S("<g class=\"ygs-tip\"><ellipse cx=\"-6\" cy=\"-2\" rx=\"6.5\" ry=\"4\" fill=\"#6b4426\"/><ellipse cx=\"6\" cy=\"-2\" rx=\"6.5\" ry=\"4\" fill=\"#6b4426\"/><path d=\"M-12 -4C-13 -16 -9 -22 0 -22C9 -22 13 -16 12 -4Z\" fill=\"#4f8ee8\" stroke=\"#2c5aa8\" stroke-width=\"1.6\"/><path d=\"M-11.5 -10H11.5\" stroke=\"#6b4426\" stroke-width=\"3\"/><rect x=\"-2.5\" y=\"-12\" width=\"5\" height=\"4\" rx=\"1\" fill=\"#ffd84a\"/>").S("<path d=\"M-9 -26C-13 -16 -6 -7 0 -6C6 -7 13 -16 9 -26Z\" fill=\"#ffffff\" stroke=\"#d8d2c6\" stroke-width=\"1.4\"/><ellipse cy=\"-28\" rx=\"8\" ry=\"6.2\" fill=\"#ffd2b0\"/><circle cy=\"-25.5\" r=\"2.8\" fill=\"#ff9a8a\"/><path d=\"M-4.5 -29h2.4M2.1 -29h2.4\" stroke=\"#4a3a2e\" stroke-width=\"1.5\" stroke-linecap=\"round\"/><path d=\"M-10.5 -31C-9 -39 -4 -49 2 -51C3 -44 8 -37 10.5 -31Z\" fill=\"#ff5e6c\" stroke=\"#b8304a\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/><path d=\"M-10 -31.5H10.5\" stroke=\"#b8304a\" stroke-width=\"2\" stroke-linecap=\"round\"/></g>").End()));
}, 0, "gnome", true)).Put("hay", Fn((V _arrowThis270, int _argc264, V _a266, V _a267, V _a268, V _a269, V[] _rest265) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_35, V.Undef, ((V)(4D)), ((V)(2D)), ((V)(28D)), ((V)("fill=\"#2d4a22\" opacity=\"0.22\"")))).S("<g class=\"ygs-pop\"><path d=\"M-24 -26L-12 -34L36 -34L24 -26Z\" fill=\"#fae39a\" stroke=\"#b88a2a\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/><path d=\"M24 -26L36 -34L36 -8L24 0Z\" fill=\"#dcb24e\" stroke=\"#b88a2a\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/><rect x=\"-24\" y=\"-26\" width=\"48\" height=\"26\" rx=\"4\" fill=\"#f2cf6a\" stroke=\"#b88a2a\" stroke-width=\"1.8\"/>").S("<path d=\"M-20 -20h12M-4 -18h14M-18 -9h9M2 -7h16M14 -21h7\" stroke=\"#c99a36\" stroke-width=\"1.6\" stroke-linecap=\"round\"/><path d=\"M-9 -26V0M9 -26V0M-3 -34L9 -26M15 -34L27 -26\" stroke=\"#b0453a\" stroke-width=\"2.2\"/></g>").End()));
}, 0, "hay", true)).Put("log", Fn((V _arrowThis277, int _argc271, V _a273, V _a274, V _a275, V _a276, V[] _rest272) => {
V a_278 = default;
V b_279 = default;
a_278 = Call(G3_31, V.Undef, ((V)(0D)), ((V)((-38D))), ((V)(9D)));
b_279 = Call(G3_31, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(9D)));
return ((V)(JsStrBuf.Begin().V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(30D)), ((V)("fill=\"#2d4a22\" opacity=\"0.2\"")))).S("<path d=\"M").V(Call(P2_30, V.Undef, a_278)).S("L").V(Call(P2_30, V.Undef, b_279)).S("\" stroke=\"#7a4a26\" stroke-width=\"20\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_30, V.Undef, a_278)).S("L").V(Call(P2_30, V.Undef, b_279)).S("\" stroke=\"#a46c3a\" stroke-width=\"15\" stroke-linecap=\"round\"/>").S("<path d=\"M").V(Call(P2_30, V.Undef, Arr(Add(GetIdx(a_278, 0D), ((V)(8D))), ((V)((ToNum(GetIdx(a_278, 1D)) - 7D)))))).S("L").V(Call(P2_30, V.Undef, Arr(((V)((ToNum(GetIdx(b_279, 0D)) - 4D))), ((V)((ToNum(GetIdx(b_279, 1D)) - 6D)))))).S("\" stroke=\"#c48a52\" stroke-width=\"2.4\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_30, V.Undef, Arr(Add(GetIdx(a_278, 0D), ((V)(12D))), Add(GetIdx(a_278, 1D), ((V)(1D)))))).S("L").V(Call(P2_30, V.Undef, Arr(((V)((ToNum(GetIdx(b_279, 0D)) - 10D))), Add(GetIdx(b_279, 1D), ((V)(3D)))))).S("\" stroke=\"#7a4a26\" stroke-width=\"1.8\" stroke-linecap=\"round\" opacity=\"0.7\"/>").S("<ellipse cx=\"").V(Call(r2_20, V.Undef, GetIdx(a_278, 0D))).S("\" cy=\"").V(Call(r2_20, V.Undef, GetIdx(a_278, 1D))).S("\" rx=\"7\" ry=\"9.5\" transform=\"rotate(-24 ").V(Invoke(Call(P2_30, V.Undef, a_278), "replace", ((V)(" ")), ((V)(" ")))).S(")\" fill=\"#f0c98e\" stroke=\"#7a4a26\" stroke-width=\"2\"/><ellipse cx=\"").V(Call(r2_20, V.Undef, GetIdx(a_278, 0D))).S("\" cy=\"").V(Call(r2_20, V.Undef, GetIdx(a_278, 1D))).S("\" rx=\"3.4\" ry=\"5\" transform=\"rotate(-24 ").V(Call(P2_30, V.Undef, a_278)).S(")\" fill=\"none\" stroke=\"#c49058\" stroke-width=\"1.4\"/>").S("<path d=\"M").V(Call(P2_30, V.Undef, Arr(((V)((ToNum(GetIdx(b_279, 0D)) - 14D))), ((V)((ToNum(GetIdx(b_279, 1D)) - 9D)))))).S("q3 -9 9 -8\" stroke=\"#6fbf55\" stroke-width=\"2.4\" fill=\"none\" stroke-linecap=\"round\"/><ellipse cx=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(b_279, 0D)) - 5D))))).S("\" cy=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(b_279, 1D)) - 17D))))).S("\" rx=\"4\" ry=\"2.4\" fill=\"#7fd06a\"/>").End()));
return default;
}, 0, "log", true)).Put("bucket", Fn((V _arrowThis286, int _argc280, V _a282, V _a283, V _a284, V _a285, V[] _rest281) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(13D)), ((V)("fill=\"#2d4a22\" opacity=\"0.2\"")))).S("<g class=\"ygs-tip\">").V(Call(gEl_35, V.Undef, ((V)(10D)), ((V)(0D)), ((V)(9D)), ((V)("fill=\"#f1d48a\"")))).S("<path d=\"M-10 -20L10 -20L8 0L-8 0Z\" fill=\"#4fc6c0\" stroke=\"#24877f\" stroke-width=\"1.8\" stroke-linejoin=\"round\"/><ellipse cy=\"-20\" rx=\"10\" ry=\"3.4\" fill=\"#2e9e96\" stroke=\"#24877f\" stroke-width=\"1.6\"/><path d=\"M-10 -20Q0 -34 10 -20\" stroke=\"#ff7a8a\" stroke-width=\"2.2\" fill=\"none\"/><path d=\"M-9 -12H9\" stroke=\"#ffffff\" stroke-width=\"2.4\" opacity=\"0.7\"/></g>").End()));
}, 0, "bucket", true)).Put("sand", Fn((V _arrowThis293, int _argc287, V _a289, V _a290, V _a291, V _a292, V[] _rest288) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(22D)), ((V)("fill=\"#2d4a22\" opacity=\"0.18\"")))).S("<g class=\"ygs-pop\"><path d=\"M-24 2C-20 -8 -8 -13 0 -13C10 -13 20 -8 24 2Z\" fill=\"#f1d48a\" stroke=\"#c9a456\" stroke-width=\"1.8\"/><path d=\"M-10 -6h3M2 -9h3M10 -3h3M-3 -2h3\" stroke=\"#c9a456\" stroke-width=\"1.6\" stroke-linecap=\"round\"/><path d=\"M6 -10L14 -26\" stroke=\"#ff7a8a\" stroke-width=\"2.6\" stroke-linecap=\"round\"/><path d=\"M12 -30L18 -26L14 -20L9 -24Z\" fill=\"#ffb84a\" stroke=\"#d07a20\" stroke-width=\"1.2\"/></g>").End()));
}, 0, "sand", true)).Put("leaves", Fn((V _arrowThis300, int _argc294, V _a296, V _a297, V _a298, V _a299, V[] _rest295) => {
JsStrBuf s_301 = null;
s_301 = new JsStrBuf(JsStrBuf.Begin().V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(22D)), ((V)("fill=\"#2d4a22\" opacity=\"0.15\"")))).S("<g class=\"ygs-pop\">").End());
Invoke(Arr(Arr(((V)((-14D))), ((V)((-2D))), ((V)("#ff9a3a")), ((V)(20D))), Arr(((V)((-2D))), ((V)((-6D))), ((V)("#ffcf3a")), ((V)((-30D)))), Arr(((V)(10D)), ((V)((-1D))), ((V)("#e8623a")), ((V)(60D))), Arr(((V)((-6D))), ((V)(2D)), ((V)("#ffb84a")), ((V)(100D))), Arr(((V)(4D)), ((V)((-10D))), ((V)("#d9482a")), ((V)((-70D)))), Arr(((V)(16D)), ((V)((-6D))), ((V)("#ffd84a")), ((V)(10D))), Arr(((V)((-18D))), ((V)((-8D))), ((V)("#e8623a")), ((V)(140D)))), "forEach", Fn((V _arrowThis317, int _argc302, V _a304, V _a305, V _a306, V _a307, V[] _rest303) => {
V x_310 = default;
V y_312 = default;
V c_314 = default;
V r_316 = default;
{ V _t308 = ListOf(_a304);
{ V _t309 = GetIdx(_t308, 0D);
x_310 = _t309; }
{ V _t311 = GetIdx(_t308, 1D);
y_312 = _t311; }
{ V _t313 = GetIdx(_t308, 2D);
c_314 = _t313; }
{ V _t315 = GetIdx(_t308, 3D);
r_316 = _t315; }
}
s_301.S("<path transform=\"translate(").V(x_310).S(" ").V(y_312).S(") rotate(").V(r_316).S(")\" d=\"M-8 0Q-3 -6 4 -5Q9 -2 8 0Q4 5 -3 4Q-7 3 -8 0Z\" fill=\"").V(c_314).S("\" stroke=\"#9a3a1a\" stroke-width=\"1\"/>");
return default;
}, 1, "", true));
return ((V)(string.Concat(s_301.Str, "</g>")));
return default;
}, 0, "leaves", true)).Put("mud", Fn((V _arrowThis325, int _argc318, V it_324, V _a321, V _a322, V _a323, V[] _rest319) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(Call(blob_36, V.Undef, Get(Get(DEF_61, "mud"), "hs"), ((V)((ToNum(Get(Get(DEF_61, "mud"), "hw")) * HW_28))), ((V)(0.18)), ((V)((ToNum(Get(it_324, "s")) % 7D))))).S("\" fill=\"#8a5a34\" stroke=\"#6e4426\" stroke-width=\"2\"/><path d=\"").V(Call(blob_36, V.Undef, ((V)((ToNum(Get(Get(DEF_61, "mud"), "hs")) * 0.55))), ((V)(((ToNum(Get(Get(DEF_61, "mud"), "hw")) * HW_28) * 0.5))), ((V)(0.25)), ((V)((ToNum(Get(it_324, "s")) % 5D))))).S("\" fill=\"#6e4426\" transform=\"translate(-6 2)\"/>").V(Call(gEl_35, V.Undef, ((V)((-18D))), ((V)((-2D))), ((V)(4D)), ((V)("fill=\"#a87a4e\"")))).V(Call(gEl_35, V.Undef, ((V)(14D)), ((V)(4D)), ((V)(3D)), ((V)("fill=\"#a87a4e\"")))).V(Call(gEl_35, V.Undef, ((V)(24D)), ((V)((-8D))), ((V)(2.4)), ((V)("fill=\"#c49a6a\"")))).End()));
}, 1, "mud", true)).Put("slick", Fn((V _arrowThis333, int _argc326, V it_332, V _a329, V _a330, V _a331, V[] _rest327) => {
return ((V)(JsStrBuf.Begin().S("<path class=\"ygs-shim\" d=\"").V(Call(blob_36, V.Undef, Get(Get(DEF_61, "slick"), "hs"), ((V)((ToNum(Get(Get(DEF_61, "slick"), "hw")) * HW_28))), ((V)(0.12)), ((V)((ToNum(Get(it_332, "s")) % 9D))))).S("\" fill=\"#8fdcff\" stroke=\"#ffffff\" stroke-width=\"2.5\"/><path d=\"M").V(Call(P2_30, V.Undef, Call(G3_31, V.Undef, ((V)((-30D))), ((V)((-6D)))))).S("L").V(Call(P2_30, V.Undef, Call(G3_31, V.Undef, ((V)(20D)), ((V)((-10D)))))).S("M").V(Call(P2_30, V.Undef, Call(G3_31, V.Undef, ((V)((-14D))), ((V)(10D))))).S("L").V(Call(P2_30, V.Undef, Call(G3_31, V.Undef, ((V)(30D)), ((V)(6D))))).S("\" stroke=\"#ffffff\" stroke-width=\"3\" stroke-linecap=\"round\" opacity=\"0.85\"/>").S("<path class=\"ygs-tw\" d=\"M0 -9C0.9 -3 3 -1 9 0C3 1 0.9 3 0 9C-0.9 3 -3 1 -9 0C-3 -1 -0.9 -3 0 -9Z\" fill=\"#ffffff\" transform=\"translate(").V(Call(P2_30, V.Undef, Call(G3_31, V.Undef, ((V)(8D)), ((V)(2D)), ((V)(6D))))).S(")\"/>").End()));
}, 1, "slick", true)).Put("gold", Fn((V _arrowThis340, int _argc334, V _a336, V _a337, V _a338, V _a339, V[] _rest335) => {
JsStrBuf s_341 = null;
s_341 = new JsStrBuf(JsStrBuf.Begin().S("<path class=\"ygs-glow\" d=\"").V(Call(poly_32, V.Undef, Arr(Call(G3_31, V.Undef, ((V)((-34D))), ((V)((-24D)))), Call(G3_31, V.Undef, ((V)(34D)), ((V)((-24D)))), Call(G3_31, V.Undef, ((V)(34D)), ((V)(24D))), Call(G3_31, V.Undef, ((V)((-34D))), ((V)(24D)))))).S("\" fill=\"#ffe36e\" stroke=\"#d79a22\" stroke-width=\"2.5\" stroke-linejoin=\"round\"/>").End());
Invoke(Arr(((V)((-18D))), ((V)(0D)), ((V)(18D))), "forEach", Fn((V _arrowThis349, int _argc342, V d_348, V _a345, V _a346, V _a347, V[] _rest343) => {
s_341.S("<path d=\"").V(Call(poly_32, V.Undef, Arr(Call(G3_31, V.Undef, ((V)((ToNum(d_348) - 9D))), ((V)((-14D)))), Call(G3_31, V.Undef, Add(d_348, ((V)(5D))), ((V)(0D))), Call(G3_31, V.Undef, ((V)((ToNum(d_348) - 9D))), ((V)(14D))), Call(G3_31, V.Undef, ((V)((ToNum(d_348) - 3D))), ((V)(14D))), Call(G3_31, V.Undef, Add(d_348, ((V)(11D))), ((V)(0D))), Call(G3_31, V.Undef, ((V)((ToNum(d_348) - 3D))), ((V)((-14D))))))).S("\" fill=\"#ff8a3d\" stroke=\"#ffffff\" stroke-width=\"1.4\" stroke-linejoin=\"round\"/>");
return default;
}, 1, "", true));
return ((V)(s_341.Str));
return default;
}, 0, "gold", true)).Put("ramp", Fn((V _arrowThis356, int _argc350, V _a352, V _a353, V _a354, V _a355, V[] _rest351) => {
double w_357 = 0;
V top_358 = default;
JsStrBuf s_359 = null;
w_357 = (0.95 * HW_28);
top_358 = Arr(Call(G3_31, V.Undef, ((V)((-30D))), ((V)((-w_357))), ((V)(0D))), Call(G3_31, V.Undef, ((V)(30D)), ((V)((-w_357))), ((V)(18D))), Call(G3_31, V.Undef, ((V)(30D)), ((V)(w_357)), ((V)(18D))), Call(G3_31, V.Undef, ((V)((-30D))), ((V)(w_357)), ((V)(0D))));
s_359 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Call(poly_32, V.Undef, Arr(Call(G3_31, V.Undef, ((V)((-30D))), ((V)((-w_357))), ((V)(0D))), Call(G3_31, V.Undef, ((V)(30D)), ((V)((-w_357))), ((V)(0D))), Call(G3_31, V.Undef, ((V)(30D)), ((V)((-w_357))), ((V)(18D)))))).S("\" fill=\"#9a6232\" stroke=\"#6b4426\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/>").S("<path d=\"").V(Call(poly_32, V.Undef, Arr(Call(G3_31, V.Undef, ((V)(30D)), ((V)((-w_357))), ((V)(0D))), Call(G3_31, V.Undef, ((V)(30D)), ((V)(w_357)), ((V)(0D))), Call(G3_31, V.Undef, ((V)(30D)), ((V)(w_357)), ((V)(18D))), Call(G3_31, V.Undef, ((V)(30D)), ((V)((-w_357))), ((V)(18D)))))).S("\" fill=\"#b47740\" stroke=\"#6b4426\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/><path d=\"").V(Call(poly_32, V.Undef, top_358)).S("\" fill=\"#e2ad74\" stroke=\"#6b4426\" stroke-width=\"1.8\" stroke-linejoin=\"round\"/>").End());
{
double i_360 = 0;
i_360 = 1D;
while (true) {
if (!((i_360 < 4D))) break;
double ds_362 = 0;
ds_362 = ((-30D) + (i_360 * 15D));
s_359.S("<path d=\"M").V(Call(P2_30, V.Undef, Call(G3_31, V.Undef, ((V)(ds_362)), ((V)((-w_357))), ((V)(((ds_362 + 30D) * 0.3)))))).S("L").V(Call(P2_30, V.Undef, Call(G3_31, V.Undef, ((V)(ds_362)), ((V)(w_357)), ((V)(((ds_362 + 30D) * 0.3)))))).S("\" stroke=\"#b47740\" stroke-width=\"1.4\"/>");
i_360++;
}
}
return ((V)(JsStrBuf.Begin().S(s_359.Str).S("<path d=\"").V(Call(poly_32, V.Undef, Arr(Call(G3_31, V.Undef, ((V)((-8D))), ((V)((-10D))), ((V)(6.6))), Call(G3_31, V.Undef, ((V)(8D)), ((V)(0D)), ((V)(11.4))), Call(G3_31, V.Undef, ((V)((-8D))), ((V)(10D)), ((V)(6.6)))))).S("\" fill=\"#ffd84a\" stroke=\"#ffffff\" stroke-width=\"1.2\"/>").End()));
return default;
}, 0, "ramp", true)).V;
tree_65 = Fn((V _arrowThis372, int _argc363, V k_369, V c1_370, V c2_371, V _a368, V[] _rest364) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((30D * ToNum(k_369)))), ((V)("fill=\"#2d4a22\" opacity=\"0.22\"")))).S("<rect x=\"").V(Call(r2_20, V.Undef, ((V)(((-5D) * ToNum(k_369)))))).S("\" y=\"").V(Call(r2_20, V.Undef, ((V)(((-38D) * ToNum(k_369)))))).S("\" width=\"").V(Call(r2_20, V.Undef, ((V)((10D * ToNum(k_369)))))).S("\" height=\"").V(Call(r2_20, V.Undef, ((V)((40D * ToNum(k_369)))))).S("\" rx=\"3\" fill=\"#8a5a34\"/>").V(Invoke(Invoke(Arr(Arr(((V)((-17D))), ((V)((-48D))), ((V)(21D))), Arr(((V)(15D)), ((V)((-50D))), ((V)(23D))), Arr(((V)(0D)), ((V)((-70D))), ((V)(25D))), Arr(((V)((-4D))), ((V)((-46D))), ((V)(18D)))), "map", Fn((V _arrowThis386, int _argc373, V _a375, V _a376, V _a377, V _a378, V[] _rest374) => {
V x_381 = default;
V y_383 = default;
V r_385 = default;
{ V _t379 = ListOf(_a375);
{ V _t380 = GetIdx(_t379, 0D);
x_381 = _t380; }
{ V _t382 = GetIdx(_t379, 1D);
y_383 = _t382; }
{ V _t384 = GetIdx(_t379, 2D);
r_385 = _t384; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(x_381) * ToNum(k_369)))))).S("\" cy=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(y_383) * ToNum(k_369)))))).S("\" r=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(r_385) * ToNum(k_369)))))).S("\" fill=\"").V(c1_370).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<circle cx=\"").V(Call(r2_20, V.Undef, ((V)(((-7D) * ToNum(k_369)))))).S("\" cy=\"").V(Call(r2_20, V.Undef, ((V)(((-76D) * ToNum(k_369)))))).S("\" r=\"").V(Call(r2_20, V.Undef, ((V)((10D * ToNum(k_369)))))).S("\" fill=\"").V(c2_371).S("\" opacity=\"0.9\"/><circle cx=\"").V(Call(r2_20, V.Undef, ((V)((12D * ToNum(k_369)))))).S("\" cy=\"").V(Call(r2_20, V.Undef, ((V)(((-56D) * ToNum(k_369)))))).S("\" r=\"").V(Call(r2_20, V.Undef, ((V)((7D * ToNum(k_369)))))).S("\" fill=\"").V(c2_371).S("\" opacity=\"0.7\"/>").End()));
}, 3, "", true);
bush_66 = Fn((V _arrowThis395, int _argc387, V k_393, V c_394, V _a391, V _a392, V[] _rest388) => {
return ((V)(JsStrBuf.Begin().V(Add(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((20D * ToNum(k_393)))), ((V)("fill=\"#2d4a22\" opacity=\"0.2\""))), Invoke(Invoke(Arr(Arr(((V)((-11D))), ((V)((-9D))), ((V)(11D))), Arr(((V)(9D)), ((V)((-10D))), ((V)(12D))), Arr(((V)(0D)), ((V)((-18D))), ((V)(13D)))), "map", Fn((V _arrowThis409, int _argc396, V _a398, V _a399, V _a400, V _a401, V[] _rest397) => {
V x_404 = default;
V y_406 = default;
V r_408 = default;
{ V _t402 = ListOf(_a398);
{ V _t403 = GetIdx(_t402, 0D);
x_404 = _t403; }
{ V _t405 = GetIdx(_t402, 1D);
y_406 = _t405; }
{ V _t407 = GetIdx(_t402, 2D);
r_408 = _t407; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(x_404) * ToNum(k_393)))))).S("\" cy=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(y_406) * ToNum(k_393)))))).S("\" r=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(r_408) * ToNum(k_393)))))).S("\" fill=\"#57a854\"/>").End()));
}, 1, "", true)), "join", ((V)(""))))).S("<circle cx=\"").V(Call(r2_20, V.Undef, ((V)(((-3D) * ToNum(k_393)))))).S("\" cy=\"").V(Call(r2_20, V.Undef, ((V)(((-22D) * ToNum(k_393)))))).S("\" r=\"").V(Call(r2_20, V.Undef, ((V)((5D * ToNum(k_393)))))).S("\" fill=\"#7cc46a\"/>").V((Truthy(c_394) ? Invoke(Invoke(Arr(Arr(((V)((-8D))), ((V)((-14D)))), Arr(((V)(8D)), ((V)((-18D)))), Arr(((V)(2D)), ((V)((-8D))))), "map", Fn((V _arrowThis421, int _argc410, V _a412, V _a413, V _a414, V _a415, V[] _rest411) => {
V x_418 = default;
V y_420 = default;
{ V _t416 = ListOf(_a412);
{ V _t417 = GetIdx(_t416, 0D);
x_418 = _t417; }
{ V _t419 = GetIdx(_t416, 1D);
y_420 = _t419; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(x_418) * ToNum(k_393)))))).S("\" cy=\"").V(Call(r2_20, V.Undef, ((V)((ToNum(y_420) * ToNum(k_393)))))).S("\" r=\"").V(Call(r2_20, V.Undef, ((V)((2.6 * ToNum(k_393)))))).S("\" fill=\"").V(c_394).S("\"/>").End()));
}, 1, "", true)), "join", ((V)(""))) : ((V)("")))).End()));
}, 2, "", true);
flowers_67 = Fn((V _arrowThis429, int _argc422, V sd_428, V _a425, V _a426, V _a427, V[] _rest423) => {
V R_430 = default;
JsStrBuf s_431 = null;
R_430 = Call(rnd_37, V.Undef, sd_428);
s_431 = new JsStrBuf("");
{
double i_432 = 0;
i_432 = 0D;
while (true) {
if (!((i_432 < 5D))) break;
double x_434 = 0;
double y_435 = 0;
double h_436 = 0;
V c_437 = default;
x_434 = ((ToNum(Call(R_430, V.Undef)) - 0.5) * 30D);
y_435 = ((ToNum(Call(R_430, V.Undef)) - 0.5) * 10D);
h_436 = (8D + (ToNum(Call(R_430, V.Undef)) * 8D));
c_437 = GetIdx(Arr(((V)("#ff8fc8")), ((V)("#fff3a8")), ((V)("#ffffff")), ((V)("#d9c8ff")), ((V)("#ffb0a0"))), (i_432 % 5D));
s_431.S("<path d=\"M").V(Call(r2_20, V.Undef, ((V)(x_434)))).S(" ").V(Call(r2_20, V.Undef, ((V)(y_435)))).S("V").V(Call(r2_20, V.Undef, ((V)((y_435 - h_436))))).S("\" stroke=\"#4f9a3e\" stroke-width=\"1.6\"/>");
{
double j_438 = 0;
j_438 = 0D;
while (true) {
if (!((j_438 < 5D))) break;
s_431.S("<circle cx=\"").V(Call(r2_20, V.Undef, ((V)((x_434 + (FdLibm.Cos((j_438 * 1.2566)) * 2.8)))))).S("\" cy=\"").V(Call(r2_20, V.Undef, ((V)(((y_435 - h_436) + (FdLibm.Sin((j_438 * 1.2566)) * 2.8)))))).S("\" r=\"2.2\" fill=\"").V(c_437).S("\"/>");
j_438++;
}
}
s_431.S("<circle cx=\"").V(Call(r2_20, V.Undef, ((V)(x_434)))).S("\" cy=\"").V(Call(r2_20, V.Undef, ((V)((y_435 - h_436))))).S("\" r=\"1.5\" fill=\"#ffb84a\"/>");
i_432++;
}
}
return ((V)(s_431.Str));
return default;
}, 1, "", true);
pinwheel_68 = Fn((V _arrowThis447, int _argc440, V c_446, V _a443, V _a444, V _a445, V[] _rest441) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0V-40\" stroke=\"#e8e0d4\" stroke-width=\"2.6\" stroke-linecap=\"round\"/><g transform=\"translate(0 -40)\"><g class=\"ygs-spin\">").V(Invoke(Invoke(Arr(((V)(0D)), ((V)(90D)), ((V)(180D)), ((V)(270D))), "map", Fn((V _arrowThis456, int _argc448, V a_454, V i_455, V _a452, V _a453, V[] _rest449) => {
return ((V)(JsStrBuf.Begin().S("<path transform=\"rotate(").V(a_454).S(")\" d=\"M0 0L0 -12L9 -9Z\" fill=\"").V(GetK(Arr(c_446, ((V)("#ffffff")), c_446, ((V)("#ffd84a"))), i_455)).S("\" stroke=\"#4a3a2e\" stroke-width=\"0.8\"/>").End()));
}, 2, "", true)), "join", ((V)("")))).S("</g><circle r=\"1.8\" fill=\"#ffd84a\"/></g>").End()));
}, 1, "", true);
sprinkler_69 = Fn((V _arrowThis463, int _argc457, V _a459, V _a460, V _a461, V _a462, V[] _rest458) => {
return ((V)("<ellipse cy=\"1\" rx=\"8\" ry=\"3\" fill=\"#2d4a22\" opacity=\"0.25\"/><path d=\"M-3 0V-10H3V0Z\" fill=\"#9aa0a8\"/><circle cy=\"-11\" r=\"3.4\" fill=\"#5cb8ff\"/><path class=\"ygs-spr\" d=\"M0 -12Q-26 -60 -58 -14\" stroke=\"#bfe8ff\" stroke-width=\"3.4\" fill=\"none\" stroke-linecap=\"round\" stroke-dasharray=\"6 9\"/><path class=\"ygs-spr\" d=\"M0 -12Q22 -52 50 -18\" stroke=\"#dff4ff\" stroke-width=\"2.6\" fill=\"none\" stroke-linecap=\"round\" stroke-dasharray=\"5 10\"/>"));
}, 0, "", true);
birdhouse_70 = Fn((V _arrowThis470, int _argc464, V _a466, V _a467, V _a468, V _a469, V[] _rest465) => {
return ((V)("<path d=\"M0 0V-46\" stroke=\"#a46c3a\" stroke-width=\"4\"/><path d=\"M-10 -46V-62H10V-46Z\" fill=\"#ffb0a0\" stroke=\"#b05a4a\" stroke-width=\"1.4\"/><path d=\"M-13 -60L0 -72L13 -60Z\" fill=\"#7a5ad0\" stroke=\"#4a2e8a\" stroke-width=\"1.4\" stroke-linejoin=\"round\"/><circle cy=\"-54\" r=\"3\" fill=\"#5a3a2a\"/>"));
}, 0, "", true);
shed_71 = Fn((V _arrowThis477, int _argc471, V _a473, V _a474, V _a475, V _a476, V[] _rest472) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(46D)), ((V)("fill=\"#2d4a22\" opacity=\"0.2\"")))).S("<path d=\"M-34 0V-38H22V0Z\" fill=\"#ffd2a0\" stroke=\"#b07a46\" stroke-width=\"2\"/><path d=\"M22 0V-38L40 -48V-10Z\" fill=\"#e8b67c\" stroke=\"#b07a46\" stroke-width=\"2\" stroke-linejoin=\"round\"/><path d=\"M-40 -36L-6 -62L28 -36Z\" fill=\"#e06a5a\" stroke=\"#9a3a2e\" stroke-width=\"2\" stroke-linejoin=\"round\"/><path d=\"M28 -36L-6 -62L12 -72L46 -46Z\" fill=\"#c85848\" stroke=\"#9a3a2e\" stroke-width=\"2\" stroke-linejoin=\"round\"/>").S("<rect x=\"-14\" y=\"-26\" width=\"14\" height=\"26\" rx=\"2\" fill=\"#a46c3a\"/><rect x=\"4\" y=\"-30\" width=\"12\" height=\"10\" rx=\"2\" fill=\"#bfe8ff\" stroke=\"#ffffff\" stroke-width=\"2\"/>").End()));
}, 0, "", true);
haystack_72 = Fn((V _arrowThis484, int _argc478, V _a480, V _a481, V _a482, V _a483, V[] _rest479) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(26D)), ((V)("fill=\"#2d4a22\" opacity=\"0.2\"")))).S("<path d=\"M-26 0C-26 -22 -12 -40 0 -40C12 -40 26 -22 26 0Z\" fill=\"#f2cf6a\" stroke=\"#b88a2a\" stroke-width=\"1.8\"/><path d=\"M-14 -10l6 -12M2 -6l3 -16M14 -12l-4 -10M-4 -26l2 -8\" stroke=\"#c99a36\" stroke-width=\"1.6\" stroke-linecap=\"round\"/>").End()));
}, 0, "", true);
sunflower_73 = Fn((V _arrowThis491, int _argc485, V _a487, V _a488, V _a489, V _a490, V[] _rest486) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0V-48\" stroke=\"#4f9a3e\" stroke-width=\"2.6\"/><path d=\"M0 -20Q8 -26 12 -20Q6 -16 0 -20Z\" fill=\"#57a854\"/>").V(Invoke(Invoke(new ArrBuilder().Spread(Call(G("Array"), V.Undef, ((V)(10D)))).V, "map", Fn((V _arrowThis500, int _argc492, V __498, V i_499, V _a496, V _a497, V[] _rest493) => {
return ((V)(JsStrBuf.Begin().S("<ellipse transform=\"translate(0 -52) rotate(").N((ToNum(i_499) * 36D)).S(")\" cy=\"-8\" rx=\"3.4\" ry=\"6\" fill=\"#ffd84a\"/>").End()));
}, 2, "", true)), "join", ((V)("")))).S("<circle cy=\"-52\" r=\"6\" fill=\"#8a5a34\"/>").End()));
}, 0, "", true);
lounger_74 = Fn((V _arrowThis507, int _argc501, V _a503, V _a504, V _a505, V _a506, V[] _rest502) => {
return ((V)(JsStrBuf.Begin().V(Call(gEl_35, V.Undef, ((V)(10D)), ((V)(4D)), ((V)(34D)), ((V)("fill=\"#2d4a22\" opacity=\"0.18\"")))).S("<path d=\"M-28 0V-8M28 0V-8M-28 -8H14L30 -30\" stroke=\"#e8e0d4\" stroke-width=\"3\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"M-26 -12H14L28 -32\" stroke=\"#5cb8ff\" stroke-width=\"7\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"M-20 -12H8\" stroke=\"#ffffff\" stroke-width=\"2\" stroke-dasharray=\"4 4\"/>").End()));
}, 0, "", true);
umbrella_75 = Fn((V _arrowThis514, int _argc508, V _a510, V _a511, V _a512, V _a513, V[] _rest509) => {
return ((V)("<path d=\"M0 0V-70\" stroke=\"#e8e0d4\" stroke-width=\"3\"/><path d=\"M-40 -62Q0 -96 40 -62Q30 -66 20 -62Q10 -66 0 -62Q-10 -66 -20 -62Q-30 -66 -40 -62Z\" fill=\"#ff7a8a\" stroke=\"#c8485a\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/><path d=\"M-20 -62Q-12 -84 0 -88M20 -62Q12 -84 0 -88\" stroke=\"#ffffff\" stroke-width=\"5\" fill=\"none\" opacity=\"0.85\"/>"));
}, 0, "", true);
ball_76 = Fn((V _arrowThis521, int _argc515, V _a517, V _a518, V _a519, V _a520, V[] _rest516) => {
return ((V)(JsStrBuf.Begin().S("<g class=\"ygs-bob\">").V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(11D)), ((V)("fill=\"#2d4a22\" opacity=\"0.18\"")))).S("<circle cy=\"-11\" r=\"11\" fill=\"#ffffff\" stroke=\"#c8c0b4\" stroke-width=\"1.4\"/><path d=\"M0 -22A11 11 0 0 1 11 -11L0 -11Z\" fill=\"#ff7a8a\"/><path d=\"M0 0A11 11 0 0 1 -11 -11L0 -11Z\" fill=\"#5cb8ff\"/><path d=\"M-11 -11A11 11 0 0 1 0 -22L0 -11Z\" fill=\"#ffd84a\"/><circle cx=\"-4\" cy=\"-15\" r=\"3\" fill=\"#ffffff\" opacity=\"0.7\"/></g>").End()));
}, 0, "", true);
donut_77 = Fn((V _arrowThis528, int _argc522, V _a524, V _a525, V _a526, V _a527, V[] _rest523) => {
return ((V)(JsStrBuf.Begin().S("<g class=\"ygs-bob\">").V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(26D)), ((V)("fill=\"#ff8fc8\" stroke=\"#d05a98\" stroke-width=\"2\"")))).V(Call(gEl_35, V.Undef, ((V)(0D)), ((V)((-1D))), ((V)(11D)), ((V)("fill=\"#4fb4ec\"")))).V(Call(gEl_35, V.Undef, ((V)((-6D))), ((V)((-6D))), ((V)(8D)), ((V)("fill=\"#ffffff\" opacity=\"0.4\"")))).S("</g>").End()));
}, 0, "", true);
fence_78 = Fn((V _arrowThis536, int _argc529, V len_535, V _a532, V _a533, V _a534, V[] _rest530) => {
V s_537 = default;
V a_538 = default;
V b_539 = default;
V a2_540 = default;
V b2_541 = default;
s_537 = Call(gEl_35, V.Undef, ((V)((ToNum(len_535) / 2D))), ((V)(3D)), ((V)((ToNum(len_535) * 0.42))), ((V)("fill=\"#2d4a22\" opacity=\"0.12\"")));
a_538 = Call(G3_31, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(9D)));
b_539 = Call(G3_31, V.Undef, len_535, ((V)(0D)), ((V)(9D)));
a2_540 = Call(G3_31, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(18D)));
b2_541 = Call(G3_31, V.Undef, len_535, ((V)(0D)), ((V)(18D)));
s_537 = ((V)(JsStrBuf.Begin().V(s_537).S("<path d=\"M").V(Call(P2_30, V.Undef, a_538)).S("L").V(Call(P2_30, V.Undef, b_539)).S("M").V(Call(P2_30, V.Undef, a2_540)).S("L").V(Call(P2_30, V.Undef, b2_541)).S("\" stroke=\"#e8dccb\" stroke-width=\"4\" stroke-linecap=\"round\"/>").End()));
{
double d_542 = 0;
d_542 = 0D;
while (true) {
if (!(Le(((V)(d_542)), len_535))) break;
V q_544 = default;
q_544 = Call(G3_31, V.Undef, ((V)(d_542)), ((V)(0D)), ((V)(0D)));
s_537 = ((V)(JsStrBuf.Begin().V(s_537).S("<path d=\"M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(q_544, 0D)) - 3D))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(q_544, 1D))).S("V").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(q_544, 1D)) - 22D))))).S("L").V(Call(r2_20, V.Undef, GetIdx(q_544, 0D))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(q_544, 1D)) - 26D))))).S("L").V(Call(r2_20, V.Undef, Add(GetIdx(q_544, 0D), ((V)(3D))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(q_544, 1D)) - 22D))))).S("V").V(Call(r2_20, V.Undef, GetIdx(q_544, 1D))).S("Z\" fill=\"#fffaf2\" stroke=\"#d8c9b0\" stroke-width=\"1\"/>").End()));
d_542 = (d_542 + 14D);
}
}
return s_537;
return default;
}, 1, "", true);
bed_79 = Fn((V _arrowThis552, int _argc545, V sd_551, V _a548, V _a549, V _a550, V[] _rest546) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(Call(blob_36, V.Undef, ((V)(46D)), ((V)(22D)), ((V)(0.12)), sd_551)).S("\" fill=\"#a8754a\" stroke=\"#8a5a34\" stroke-width=\"2\"/>").V(Call(flowers_67, V.Undef, sd_551)).End()));
}, 1, "", true);
Invoke(YG_16, "add", NewObj(12).Put("id", ((V)("slide"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Slide & Splash"))).Put("item", ((V)("Slides"))).Put("color", ((V)("#3fd0c0"))).Put("icon", ICON_63).Put("stars", Arr(((V)(550D)), ((V)(750D)), ((V)(950D)))).Put("coinK", ((V)(0.08))).Put("hint", ((V)("Drag up or down to switch sides \u00b7 grab splash slicks + gold arrows \u00b7 dodge the rest"))).Put("how", Arr(((V)("Slide down the big backyard slide: drag up or down (or use the arrow keys) to switch sides.")), ((V)("Splash slicks and gold arrows speed you up. Rocks, gnomes, hay, mud and sand slow you down. Wooden bumps hop you over logs.")), ((V)("At the end you fly off into the kiddie pool: the faster you go, the bigger the splash - your friends get soaked!")))).Put("options", Arr(NewObj(2).Put("id", ((V)("rainbow"))).Put("label", ((V)("Rainbow"))).V, NewObj(2).Put("id", ((V)("gold"))).Put("label", ((V)("Gold"))).V, NewObj(2).Put("id", ((V)("wood"))).Put("label", ((V)("Wooden"))).V)).Put("make", Fn((V _self553, int _argc554, V ctx_560, V _a557, V _a558, V _a559, V[] _rest555) => {
V bg_561 = default;
V fg_562 = default;
V W_563 = default;
V H_564 = default;
V look_565 = default;
V slideBg_566 = default;
V wB_567 = default;
V gStart_568 = default;
V gGround_569 = default;
V gEnd_570 = default;
V gDecal_571 = default;
V gShadow_572 = default;
V gBack_573 = default;
V scB_574 = default;
V wF_575 = default;
V gStartF_576 = default;
V gNear_577 = default;
V gEndF_578 = default;
V gFront_579 = default;
V scF_580 = default;
V speedL_581 = default;
V hud_582 = default;
V meSh_583 = default;
V stands_584 = default;
V riderD_585 = default;
V sortIn_586 = default;
V addStand_587 = default;
V dropStand_588 = default;
V chunks_589 = default;
V Lp_590 = default;
V post_591 = default;
V surface_592 = default;
V farSide_593 = default;
V farWall_594 = default;
V nearSide_595 = default;
V buildChunk_596 = default;
V dropChunk_597 = default;
V ensure_598 = default;
V buildStatic_599 = default;
V items_600 = default;
double nextI_601 = 0;
V alive_602 = default;
V gen_603 = default;
V spawn_604 = default;
V despawn_605 = default;
V feed_606 = default;
V sp_607 = default;
V ARC_608 = default;
double arcL_609 = 0;
V spArc_610 = default;
V spTx_611 = default;
V tierG_612 = default;
V tierR_613 = default;
V tierTx_614 = default;
V pg_615 = default;
V pgF_616 = default;
V pgD_617 = default;
V lines_618 = default;
V flash_619 = default;
V AU_620 = default;
V windOn_621 = default;
V windSet_622 = default;
V windOff_623 = default;
V me_624 = default;
V C0_625 = default;
V C1_626 = default;
double Z0_627 = 0;
V tNow_628 = default;
V friends_629 = default;
V pool_630 = default;
V st_631 = default;
V scr_632 = default;
V reset_633 = default;
V drag_634 = default;
V api_635 = default;
V botSteer_636 = default;
V hits_637 = default;
V launch_638 = default;
V transition_639 = default;
V poolScene_640 = default;
V camera_641 = default;
V place_642 = default;
V hud__643 = default;
if (_self553.IsNullish) _self553 = GlobalV;
sortIn_586 = Fn((V _self644, int _argc645, V o_651, V fr_652, V _a649, V _a650, V[] _rest646) => {
V par_653 = default;
V @ref_654 = default;
if (_self644.IsNullish) _self644 = GlobalV;
par_653 = (Truthy(fr_652) ? gFront_579 : gBack_573);
@ref_654 = V.Null;
{
V c_655 = default;
c_655 = Get(par_653, "firstChild");
while (true) {
if (!(Truthy(c_655))) break;
if (Gt(Get(c_655, "_d"), Get(o_651, "d"))) {
@ref_654 = c_655;
break;
}
c_655 = Get(c_655, "nextSibling");
}
}
Set(Get(o_651, "el"), "_d", Get(o_651, "d"));
Invoke(par_653, "insertBefore", Get(o_651, "el"), @ref_654);
Set(o_651, "fr", fr_652);
return default;
}, 2, "sortIn", false);
addStand_587 = Fn((V _self657, int _argc658, V html_664, V s_665, V l_666, V h_667, V[] _rest659) => {
V el_668 = default;
V o_669 = default;
if (_self657.IsNullish) _self657 = GlobalV;
el_668 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, s_665, l_666, (h_667 is var _t670 && Truthy(_t670) ? _t670 : ((V)(0D)))))).S(")").End()))).V);
Set(el_668, "innerHTML", html_664);
o_669 = NewObj(3).Put("el", el_668).Put("d", GetIdx(Call(Wp_29, V.Undef, s_665, l_666, ((V)(0D))), 1D)).Put("fr", V.Null).V;
Invoke(stands_584, "push", o_669);
Call(sortIn_586, V.Undef, o_669, (Gt(Get(o_669, "d"), riderD_585) ? V.True : V.False));
return o_669;
return default;
}, 4, "addStand", false);
dropStand_588 = Fn((V _self671, int _argc672, V o_678, V _a675, V _a676, V _a677, V[] _rest673) => {
V i_679 = default;
if (_self671.IsNullish) _self671 = GlobalV;
Invoke(Get(o_678, "el"), "remove");
i_679 = Invoke(stands_584, "indexOf", o_678);
if (GeN(i_679, 0D)) {
Invoke(stands_584, "splice", i_679, ((V)(1D)));
}
return default;
}, 1, "dropStand", false);
surface_592 = Fn((V _self680, int _argc681, V a_687, V b_688, V _a685, V _a686, V[] _rest682) => {
V L_689 = default;
JsStrBuf d_690 = null;
V R_691 = default;
if (_self680.IsNullish) _self680 = GlobalV;
L_689 = GetK(LOOK_62, look_565);
d_690 = new JsStrBuf("");
if (Le(b_688, a_687)) {
return ((V)(d_690.Str));
}
if (Truthy(Get(L_689, "bands"))) {
V n_692 = default;
n_692 = Get(Get(L_689, "bands"), "length");
Invoke(Get(L_689, "bands"), "forEach", Fn((V _arrowThis701, int _argc693, V c_699, V i_700, V _a697, V _a698, V[] _rest694) => {
d_690.S("<path d=\"").V(Call(quad_33, V.Undef, a_687, b_688, ((V)(((-1D) + ((2D * ToNum(i_700)) / ToNum(n_692))))), ((V)(((-1D) + ((2D * ToNum(Add(i_700, ((V)(1D))))) / ToNum(n_692))))), ((V)(SH_48)))).S("\" fill=\"").V(c_699).S("\" stroke=\"").V(c_699).S("\" stroke-width=\"0.7\"/>");
return default;
}, 2, "", true));
} else {
{
double s_702 = 0;
s_702 = (System.Math.Floor((ToNum(a_687) / 36D)) * 36D);
while (true) {
if (!(Lt(((V)(s_702)), b_688))) break;
double x0_704 = 0;
double x1_705 = 0;
x0_704 = Max(s_702, ToNum(a_687));
x1_705 = Min((s_702 + 36D), ToNum(b_688));
d_690.S("<path d=\"").V(Call(quad_33, V.Undef, ((V)(x0_704)), ((V)(x1_705)), ((V)((-1D))), ((V)(1D)), ((V)(SH_48)))).S("\" fill=\"").V(GetIdx(Get(L_689, "planks"), ((double)(ToInt32(Round((s_702 / 36D))) & ToInt32(1D))))).S("\" stroke=\"").V(Get(L_689, "seam")).S("\" stroke-width=\"1\"/>");
s_702 = (s_702 + 36D);
}
}
}
{
double s_706 = 0;
s_706 = (System.Math.Ceiling((ToNum(a_687) / 50D)) * 50D);
while (true) {
if (!(Lt(((V)(s_706)), b_688))) break;
V seam_708 = default;
seam_708 = (((s_706 % 150D) == 0D) ? V.True : V.False);
d_690.S("<path d=\"M").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, ((V)(s_706)), ((V)((-1D))), ((V)(SH_48))))).S("L").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, ((V)(s_706)), ((V)(1D)), ((V)(SH_48))))).S("\" stroke=\"").V(Get(L_689, "seam")).S("\" stroke-width=\"").N((Truthy(seam_708) ? 2.6 : 1.3)).S("\" opacity=\"").N((Truthy(seam_708) ? 0.6 : 0.35)).S("\"/>");
s_706 = (s_706 + 50D);
}
}
R_691 = Call(rnd_37, V.Undef, ((V)((Round(ToNum(a_687)) + 7D))));
{
double k_709 = 0;
k_709 = 0D;
while (true) {
if (!((k_709 < 4D))) break;
V s_711 = default;
double l_712 = 0;
s_711 = Add(a_687, ((V)((ToNum(Call(R_691, V.Undef)) * (ToNum(b_688) - ToNum(a_687))))));
l_712 = ((-0.8) + (ToNum(Call(R_691, V.Undef)) * 1.6));
if (Lt(Add(s_711, ((V)(40D))), b_688)) {
d_690.S("<path d=\"M").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, s_711, ((V)(l_712)), ((V)(SH_48))))).S("L").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, Add(Add(s_711, ((V)(26D))), ((V)((ToNum(Call(R_691, V.Undef)) * 20D)))), ((V)(l_712)), ((V)(SH_48))))).S("\" stroke=\"").V(Get(L_689, "shine")).S("\" stroke-width=\"2\" stroke-linecap=\"round\" opacity=\"0.5\"/>");
}
k_709++;
}
}
return ((V)(d_690.Str));
return default;
}, 2, "surface", false);
farSide_593 = Fn((V _self713, int _argc714, V a_720, V b_721, V _a718, V _a719, V[] _rest715) => {
V L_722 = default;
JsStrBuf d_723 = null;
if (_self713.IsNullish) _self713 = GlobalV;
L_722 = GetK(LOOK_62, look_565);
d_723 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Call(quad_33, V.Undef, a_720, b_721, ((V)((-1.1))), ((V)(1.1)), ((V)(0D)))).S("\" fill=\"#2a3a20\" opacity=\"0.14\"/>").End());
{
double x_724 = 0;
x_724 = (System.Math.Ceiling((ToNum(a_720) / 70D)) * 70D);
while (true) {
if (!(Lt(((V)(x_724)), b_721))) break;
d_723.V(Call(post_591, V.Undef, L_722, ((V)(x_724)), ((V)(1.06)), ((V)(0D)), ((V)((SH_48 - 6D))), ((V)(5D))));
if (((((x_724 / 70D) % 2D) == 0D) && ((x_724 + 70D) <= RS_46))) {
d_723.S("<path d=\"M").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, ((V)(x_724)), ((V)(1.06)), ((V)(6D))))).S("L").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, ((V)((x_724 + 70D))), ((V)(1.06)), ((V)((SH_48 - 12D)))))).S("\" stroke=\"").V(Get(L_722, "postD")).S("\" stroke-width=\"2.6\" opacity=\"0.7\"/>");
}
x_724 = (x_724 + 70D);
}
}
return ((V)(d_723.Str));
return default;
}, 2, "farSide", false);
nearSide_595 = Fn((V _self726, int _argc727, V a_733, V b_734, V _a731, V _a732, V[] _rest728) => {
V L_735 = default;
JsStrBuf d_736 = null;
if (_self726.IsNullish) _self726 = GlobalV;
L_735 = GetK(LOOK_62, look_565);
d_736 = new JsStrBuf("");
{
double x_737 = 0;
x_737 = (System.Math.Ceiling((ToNum(a_733) / 70D)) * 70D);
while (true) {
if (!(Lt(((V)(x_737)), b_734))) break;
d_736.V(Call(post_591, V.Undef, L_735, ((V)(x_737)), ((V)((-1.06))), ((V)(0D)), ((V)((SH_48 - 6D))), ((V)(5D))));
x_737 = (x_737 + 70D);
}
}
return ((V)(JsStrBuf.Begin().S(d_736.Str).S("<path d=\"").V(Call(poly_32, V.Undef, Arr(Call(Wp_29, V.Undef, a_733, ((V)((-1.12))), ((V)((SH_48 - 9D)))), Call(Wp_29, V.Undef, b_734, ((V)((-1.12))), ((V)((SH_48 - 9D)))), Call(Wp_29, V.Undef, b_734, ((V)((-1.12))), ((V)((SH_48 + WH_49)))), Call(Wp_29, V.Undef, a_733, ((V)((-1.12))), ((V)((SH_48 + WH_49))))))).S("\" fill=\"").V(Get(L_735, "side")).S("\"/><path d=\"").V(Call(quad_33, V.Undef, a_733, b_734, ((V)((-1.12))), ((V)((-1D))), ((V)((SH_48 + WH_49))))).S("\" fill=\"").V(Get(L_735, "top")).S("\" stroke=\"").V(Get(L_735, "side")).S("\" stroke-width=\"1\"/>").S("<path d=\"M").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, a_733, ((V)((-1.12))), ((V)((SH_48 - 9D)))))).S("L").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, b_734, ((V)((-1.12))), ((V)((SH_48 - 9D)))))).S("\" stroke=\"#000\" stroke-opacity=\"0.15\" stroke-width=\"2\"/>").End()));
return default;
}, 2, "nearSide", false);
buildChunk_596 = Fn((V _self739, int _argc740, V i_746, V _a743, V _a744, V _a745, V[] _rest741) => {
double s0_747 = 0;
double s1_748 = 0;
V R_749 = default;
V sec_750 = default;
JsStrBuf d_751 = null;
JsStrBuf dn_752 = null;
V clear_753 = default;
V g_754 = default;
V @ref_755 = default;
V gn_756 = default;
V st_757 = default;
double n_758 = 0;
if (_self739.IsNullish) _self739 = GlobalV;
s0_747 = (ToNum(i_746) * CS_44);
s1_748 = (s0_747 + CS_44);
R_749 = Call(rnd_37, V.Undef, ((V)((1000D + (ToNum(i_746) * 37D)))));
sec_750 = Call(secAt_57, V.Undef, ((V)(s0_747)));
d_751 = new JsStrBuf("");
dn_752 = new JsStrBuf("");
clear_753 = Fn((V _arrowThis767, int _argc759, V s_765, V lp_766, V _a763, V _a764, V[] _rest760) => {
return ((((LtN(s_765, 60D) && GtN(s_765, (T0_53 - 170D))) && GtN(lp_766, (-170D))) && LtN(lp_766, 120D)) ? V.True : V.False);
}, 2, "", true);
{
double k_768 = 0;
k_768 = 0D;
while (true) {
if (!((k_768 < 4D))) break;
double s_770 = 0;
double lp_771 = 0;
s_770 = (s0_747 + (ToNum(Call(R_749, V.Undef)) * CS_44));
lp_771 = ((k_768 > 1D) ? ((-90D) - (ToNum(Call(R_749, V.Undef)) * 230D)) : (90D + (ToNum(Call(R_749, V.Undef)) * 380D)));
if (Truthy(Call(clear_753, V.Undef, ((V)(s_770)), ((V)(lp_771))))) {
goto _cont769;
}
d_751.S("<path d=\"").V(Call(blob_36, V.Undef, ((V)((60D + (ToNum(Call(R_749, V.Undef)) * 60D)))), ((V)((30D + (ToNum(Call(R_749, V.Undef)) * 30D)))), ((V)(0.15)), Add(((V)(k_768)), i_746))).S("\" transform=\"translate(").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, ((V)(s_770)), Call(Lp_590, V.Undef, ((V)(lp_771))), ((V)(0D))))).S(")\" fill=\"").S((NumTruthy(((double)(ToInt32(k_768) & ToInt32(1D)))) ? "#86cc66" : "#6cb551")).S("\" opacity=\"0.55\"/>");
_cont769: ;
k_768++;
}
}
{
double k_772 = 0;
k_772 = 0D;
while (true) {
if (!((k_772 < 26D))) break;
double s_774 = 0;
double lp_775 = 0;
V p_776 = default;
double q_777 = 0;
s_774 = (s0_747 + (ToNum(Call(R_749, V.Undef)) * CS_44));
lp_775 = ((k_772 < 11D) ? ((-75D) - (ToNum(Call(R_749, V.Undef)) * 260D)) : (75D + (ToNum(Call(R_749, V.Undef)) * 420D)));
p_776 = Call(Wp_29, V.Undef, ((V)(s_774)), Call(Lp_590, V.Undef, ((V)(lp_775))), ((V)(0D)));
q_777 = (0.8 + (ToNum(Call(R_749, V.Undef)) * 0.5));
if (Truthy(Call(clear_753, V.Undef, ((V)(s_774)), ((V)(lp_775))))) {
goto _cont773;
}
d_751.S("<path d=\"M").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(p_776, 0D)) - (4D * q_777)))))).S(" ").V(Call(r2_20, V.Undef, GetIdx(p_776, 1D))).S("l").V(Call(r2_20, V.Undef, ((V)((2D * q_777))))).S(" ").V(Call(r2_20, V.Undef, ((V)(((-7D) * q_777))))).S("l").V(Call(r2_20, V.Undef, ((V)((2D * q_777))))).S(" ").V(Call(r2_20, V.Undef, ((V)((5D * q_777))))).S("l").V(Call(r2_20, V.Undef, ((V)((2D * q_777))))).S(" ").V(Call(r2_20, V.Undef, ((V)(((-8D) * q_777))))).S("l").V(Call(r2_20, V.Undef, ((V)((2D * q_777))))).S(" ").V(Call(r2_20, V.Undef, ((V)((8D * q_777))))).S("Z\" fill=\"#5aa946\" opacity=\"0.8\"/>");
_cont773: ;
k_772++;
}
}
{
double k_778 = 0;
k_778 = 0D;
while (true) {
if (!((k_778 < 8D))) break;
double s_780 = 0;
double lp_781 = 0;
V p_782 = default;
V c_783 = default;
s_780 = (s0_747 + (ToNum(Call(R_749, V.Undef)) * CS_44));
lp_781 = (LtN(Call(R_749, V.Undef), 0.4) ? ((-80D) - (ToNum(Call(R_749, V.Undef)) * 230D)) : (80D + (ToNum(Call(R_749, V.Undef)) * 380D)));
p_782 = Call(Wp_29, V.Undef, ((V)(s_780)), Call(Lp_590, V.Undef, ((V)(lp_781))), ((V)(0D)));
c_783 = GetIdx(Arr(((V)("#ffd1e8")), ((V)("#fff3a8")), ((V)("#ffffff")), ((V)("#d9c8ff"))), (k_778 % 4D));
if (Truthy(Call(clear_753, V.Undef, ((V)(s_780)), ((V)(lp_781))))) {
goto _cont779;
}
{
double j_784 = 0;
j_784 = 0D;
while (true) {
if (!((j_784 < 5D))) break;
d_751.S("<circle cx=\"").V(Call(r2_20, V.Undef, Add(GetIdx(p_782, 0D), ((V)((FdLibm.Cos((j_784 * 1.2566)) * 2.4)))))).S("\" cy=\"").V(Call(r2_20, V.Undef, Add(GetIdx(p_782, 1D), ((V)((FdLibm.Sin((j_784 * 1.2566)) * 2.4)))))).S("\" r=\"1.8\" fill=\"").V(c_783).S("\"/>");
j_784++;
}
}
_cont779: ;
k_778++;
}
}
if (SEqS(sec_750, "farm")) {
{
double k_786 = 0;
k_786 = 0D;
while (true) {
if (!((k_786 < 2D))) break;
double s_788 = 0;
double lp_789 = 0;
s_788 = (s0_747 + (ToNum(Call(R_749, V.Undef)) * CS_44));
lp_789 = (120D + (ToNum(Call(R_749, V.Undef)) * 200D));
d_751.S("<path d=\"").V(Call(blob_36, V.Undef, ((V)(70D)), ((V)(22D)), ((V)(0.1)), ((V)(k_786)))).S("\" transform=\"translate(").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, ((V)(s_788)), Call(Lp_590, V.Undef, ((V)(lp_789))), ((V)(0D))))).S(")\" fill=\"#c9a456\" opacity=\"0.35\"/>");
k_786++;
}
}
}
if (((s0_747 < RS_46) && (s1_748 > SD0_54))) {
double a_790 = 0;
double b_791 = 0;
a_790 = Max(s0_747, SD0_54);
b_791 = Min(s1_748, RS_46);
d_751.V(Add(Add(Call(farSide_593, V.Undef, ((V)(a_790)), ((V)(b_791))), Call(surface_592, V.Undef, ((V)(a_790)), ((V)(b_791)))), Call(farWall_594, V.Undef, ((V)(a_790)), ((V)(b_791)))));
dn_752.V(Call(nearSide_595, V.Undef, ((V)(a_790)), ((V)(b_791))));
}
g_754 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V);
Set(g_754, "innerHTML", ((V)(d_751.Str)));
Set(g_754, "_i", i_746);
@ref_755 = V.Null;
{
V c_792 = default;
c_792 = Get(gGround_569, "firstChild");
while (true) {
if (!(Truthy(c_792))) break;
if (Gt(Get(c_792, "_i"), i_746)) {
@ref_755 = c_792;
break;
}
c_792 = Get(c_792, "nextSibling");
}
}
Invoke(gGround_569, "insertBefore", g_754, @ref_755);
gn_756 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V);
Set(gn_756, "innerHTML", ((V)(dn_752.Str)));
Set(gn_756, "_i", i_746);
@ref_755 = V.Null;
{
V c_794 = default;
c_794 = Get(gNear_577, "firstChild");
while (true) {
if (!(Truthy(c_794))) break;
if (Gt(Get(c_794, "_i"), i_746)) {
@ref_755 = c_794;
break;
}
c_794 = Get(c_794, "nextSibling");
}
}
Invoke(gNear_577, "insertBefore", gn_756, @ref_755);
st_757 = Arr();
n_758 = (8D + System.Math.Floor((ToNum(Call(R_749, V.Undef)) * 4D)));
{
double k_796 = 0;
k_796 = 0D;
while (true) {
if (!((k_796 < n_758))) break;
double s_798 = 0;
V far_799 = default;
V r_800 = default;
V html_801 = default;
V lp_802 = default;
s_798 = (s0_747 + (ToNum(Call(R_749, V.Undef)) * CS_44));
far_799 = (LtN(Call(R_749, V.Undef), 0.62) ? V.True : V.False);
r_800 = Call(R_749, V.Undef);
html_801 = V.Undef;
lp_802 = V.Undef;
if (Truthy(far_799)) {
lp_802 = ((V)((95D + (ToNum(Call(R_749, V.Undef)) * 380D))));
html_801 = (SEqS(sec_750, "farm") ? (LtN(r_800, 0.4) ? Call(haystack_72, V.Undef) : (LtN(r_800, 0.75) ? Call(sunflower_73, V.Undef) : Call(tree_65, V.Undef, ((V)(0.9)), ((V)("#57a854")), ((V)("#7cc46a"))))) : (SEqS(sec_750, "sprinkle") ? (LtN(r_800, 0.45) ? Call(sprinkler_69, V.Undef) : (LtN(r_800, 0.7) ? Call(pinwheel_68, V.Undef, ((V)("#5cb8ff"))) : Call(tree_65, V.Undef, ((V)(1D)), ((V)("#4f9e45")), ((V)("#6cbb5c"))))) : (SEqS(sec_750, "garden") ? (LtN(r_800, 0.3) ? Call(birdhouse_70, V.Undef) : (LtN(r_800, 0.55) ? Call(bush_66, V.Undef, ((V)(1D)), ((V)("#ff8fc8"))) : ((LtN(r_800, 0.65) && GtN(lp_802, 200D)) ? Call(shed_71, V.Undef) : Call(tree_65, V.Undef, ((V)(1.05)), ((V)("#57a854")), ((V)("#7cc46a")))))) : (LtN(r_800, 0.5) ? Call(tree_65, V.Undef, ((V)((0.8 + (ToNum(Call(R_749, V.Undef)) * 0.4)))), ((V)("#57a854")), ((V)("#7cc46a"))) : (LtN(r_800, 0.75) ? Call(bush_66, V.Undef, ((V)(0.9)), ((V)("#fff3a8"))) : Call(pinwheel_68, V.Undef, ((V)("#ff7a8a"))))))));
} else {
lp_802 = ((V)(((-85D) - (ToNum(Call(R_749, V.Undef)) * 30D))));
html_801 = (LtN(r_800, 0.45) ? Call(flowers_67, V.Undef, ((V)(((ToNum(i_746) * 7D) + k_796)))) : (LtN(r_800, 0.55) ? ((V)(JsStrBuf.Begin().S("<g transform=\"scale(0.55)\">").V(Invoke(ART_64, "rock")).S("</g>").End())) : (LtN(r_800, 0.65) ? Call(pinwheel_68, V.Undef, GetIdx(Arr(((V)("#ff7a8a")), ((V)("#5cb8ff")), ((V)("#ffb84a"))), (k_796 % 3D))) : ((V)("")))));
if (GeN(r_800, 0.65)) {
lp_802 = ((V)(((-140D) - (ToNum(Call(R_749, V.Undef)) * 180D))));
html_801 = (GtN(r_800, 0.9) ? Call(tree_65, V.Undef, ((V)(0.8)), ((V)("#5fb04a")), ((V)("#7cc46a"))) : (GtN(r_800, 0.8) ? Call(bush_66, V.Undef, ((V)(1D)), ((V)((SEqS(sec_750, "garden") ? "#ff8fc8" : "#fff3a8")))) : (GtN(r_800, 0.72) ? Call(fence_78, V.Undef, ((V)((84D + (Round((ToNum(Call(R_749, V.Undef)) * 3D)) * 14D))))) : Call(bed_79, V.Undef, ((V)(((ToNum(i_746) * 5D) + k_796)))))));
}
}
if (Truthy((html_801 is var _t803 && !Truthy(_t803) ? _t803 : (!(Truthy(Call(clear_753, V.Undef, ((V)(s_798)), lp_802))) ? V.True : V.False)))) {
Invoke(st_757, "push", Call(addStand_587, V.Undef, html_801, ((V)(s_798)), Call(Lp_590, V.Undef, lp_802)));
}
k_796++;
}
}
Invoke(chunks_589, "set", i_746, NewObj(3).Put("g", g_754).Put("gn", gn_756).Put("st", st_757).V);
return default;
}, 1, "buildChunk", false);
dropChunk_597 = Fn((V _self804, int _argc805, V i_811, V _a808, V _a809, V _a810, V[] _rest806) => {
V c_812 = default;
if (_self804.IsNullish) _self804 = GlobalV;
c_812 = Invoke(chunks_589, "get", i_811);
if (!(Truthy(c_812))) {
return default;
}
Invoke(Get(c_812, "g"), "remove");
Invoke(Get(c_812, "gn"), "remove");
Invoke(Get(c_812, "st"), "forEach", dropStand_588);
Invoke(chunks_589, "delete", i_811);
return default;
}, 1, "dropChunk", false);
ensure_598 = Fn((V _self813, int _argc814, V sc_820, V z_821, V _a818, V _a819, V[] _rest815) => {
double a_822 = 0;
double b_823 = 0;
if (_self813.IsNullish) _self813 = GlobalV;
a_822 = System.Math.Floor(((ToNum(sc_820) - (700D / ToNum(z_821))) / CS_44));
b_823 = System.Math.Floor((ToNum(Add(sc_820, ((V)((1300D / ToNum(z_821)))))) / CS_44));
{
foreach (V _k824 in new JsIter(new ArrBuilder().Spread(Invoke(chunks_589, "keys")).V)) {
V i_825 = default;
i_825 = _k824;
if ((LtN(i_825, a_822) || GtN(i_825, b_823))) {
Call(dropChunk_597, V.Undef, i_825);
}
}
}
{
double i_826 = 0;
i_826 = a_822;
while (true) {
if (!((i_826 <= b_823))) break;
if (!(Truthy(Invoke(chunks_589, "has", ((V)(i_826)))))) {
Call(buildChunk_596, V.Undef, ((V)(i_826)));
}
i_826++;
}
}
return default;
}, 2, "ensure", false);
buildStatic_599 = Fn((V _self828, int _argc829, V _a831, V _a832, V _a833, V _a834, V[] _rest830) => {
V L_835 = default;
JsStrBuf b_836 = null;
JsStrBuf f_837 = null;
double a_838 = 0;
double z_839 = 0;
double lN_840 = 0;
double lF_841 = 0;
double RT_842 = 0;
V bar_843 = default;
V fp_844 = default;
double N_845 = 0;
V sAt_846 = default;
JsStrBuf lip_847 = null;
V edge_848 = default;
V rev_849 = default;
JsStrBuf lipB_850 = null;
V lipF_851 = default;
V lad_852 = default;
if (_self828.IsNullish) _self828 = GlobalV;
L_835 = GetK(LOOK_62, look_565);
b_836 = new JsStrBuf("");
f_837 = new JsStrBuf("");
a_838 = T0_53;
z_839 = SD0_54;
lN_840 = (-1.15);
lF_841 = 1.15;
RT_842 = (SH_48 + 56D);
bar_843 = Fn((V _arrowThis861, int _argc853, V pts_859, V w_860, V _a857, V _a858, V[] _rest854) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Invoke(Invoke(pts_859, "map", P2_30), "join", ((V)("L")))).S("\" stroke=\"").V(Get(L_835, "postD")).S("\" stroke-width=\"").V(Add(w_860, ((V)(2.4)))).S("\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"M").V(Invoke(Invoke(pts_859, "map", P2_30), "join", ((V)("L")))).S("\" stroke=\"").V(Get(L_835, "post")).S("\" stroke-width=\"").V(w_860).S("\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>").End()));
}, 2, "", true);
b_836.S("<path d=\"").V(Call(quad_33, V.Undef, ((V)((a_838 - 14D))), ((V)((z_839 + 20D))), ((V)((lN_840 - 0.15))), ((V)((lF_841 + 0.15))), ((V)(0D)))).S("\" fill=\"#2a3a20\" opacity=\"0.16\"/>").V(Call(post_591, V.Undef, L_835, ((V)(a_838)), ((V)(lF_841)), ((V)(0D)), ((V)(RT_842)), ((V)(7D)))).V(Call(post_591, V.Undef, L_835, ((V)(a_838)), ((V)(lN_840)), ((V)(0D)), ((V)(RT_842)), ((V)(7D)))).V(Call(post_591, V.Undef, L_835, ((V)(z_839)), ((V)(lF_841)), ((V)(0D)), ((V)(RT_842)), ((V)(7D))));
b_836.V(Add(Call(bar_843, V.Undef, Arr(Call(Wp_29, V.Undef, ((V)(a_838)), ((V)(lF_841)), ((V)(10D))), Call(Wp_29, V.Undef, ((V)(z_839)), ((V)(lF_841)), ((V)((SH_48 - 14D))))), ((V)(3.6))), Call(bar_843, V.Undef, Arr(Call(Wp_29, V.Undef, ((V)(a_838)), ((V)(lN_840)), ((V)(10D))), Call(Wp_29, V.Undef, ((V)(a_838)), ((V)(lF_841)), ((V)((SH_48 - 14D))))), ((V)(3.6)))));
b_836.S("<path d=\"").V(Call(quad_33, V.Undef, ((V)(a_838)), ((V)(z_839)), ((V)(lN_840)), ((V)(lF_841)), ((V)(SH_48)))).S("\" fill=\"").V(Get(L_835, "deck")).S("\" stroke=\"").V(Get(L_835, "postD")).S("\" stroke-width=\"1.5\" stroke-linejoin=\"round\"/>");
{
double s_862 = 0;
s_862 = (a_838 + 22D);
while (true) {
if (!((s_862 < (z_839 - 5D)))) break;
b_836.S("<path d=\"M").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, ((V)(s_862)), ((V)(lN_840)), ((V)(SH_48))))).S("L").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, ((V)(s_862)), ((V)(lF_841)), ((V)(SH_48))))).S("\" stroke=\"").V(Get(L_835, "postD")).S("\" stroke-width=\"1\" opacity=\"0.45\"/>");
s_862 = (s_862 + 22D);
}
}
Invoke(Arr(((V)(28D)), ((V)(54D))), "forEach", Fn((V _arrowThis871, int _argc864, V h_870, V _a867, V _a868, V _a869, V[] _rest865) => {
b_836.V(Call(bar_843, V.Undef, Arr(Call(Wp_29, V.Undef, ((V)(a_838)), ((V)(lN_840)), Add(((V)(SH_48)), h_870)), Call(Wp_29, V.Undef, ((V)(a_838)), ((V)(lF_841)), Add(((V)(SH_48)), h_870)), Call(Wp_29, V.Undef, ((V)(z_839)), ((V)(lF_841)), Add(((V)(SH_48)), h_870))), ((V)(4.4))));
return default;
}, 1, "", true));
{
double l_872 = 0;
l_872 = (lN_840 + 0.38);
while (true) {
if (!((l_872 < (lF_841 - 0.1)))) break;
b_836.V(Call(bar_843, V.Undef, Arr(Call(Wp_29, V.Undef, ((V)(a_838)), ((V)(l_872)), ((V)(SH_48))), Call(Wp_29, V.Undef, ((V)(a_838)), ((V)(l_872)), ((V)((SH_48 + 54D))))), ((V)(2.8))));
l_872 = (l_872 + 0.38);
}
}
{
double s_874 = 0;
s_874 = (a_838 + 30D);
while (true) {
if (!((s_874 < (z_839 - 8D)))) break;
b_836.V(Call(bar_843, V.Undef, Arr(Call(Wp_29, V.Undef, ((V)(s_874)), ((V)(lF_841)), ((V)(SH_48))), Call(Wp_29, V.Undef, ((V)(s_874)), ((V)(lF_841)), ((V)((SH_48 + 54D))))), ((V)(2.8))));
s_874 = (s_874 + 30D);
}
}
b_836.S("<circle cx=\"").V(Call(r2_20, V.Undef, GetIdx(Call(Wp_29, V.Undef, ((V)(z_839)), ((V)(lF_841)), ((V)((RT_842 + 3D)))), 0D))).S("\" cy=\"").V(Call(r2_20, V.Undef, GetIdx(Call(Wp_29, V.Undef, ((V)(z_839)), ((V)(lF_841)), ((V)((RT_842 + 3D)))), 1D))).S("\" r=\"5.5\" fill=\"").V((Truthy(Get(L_835, "bands")) ? GetIdx(Get(L_835, "bands"), 0D) : ((V)("#ff7a8a")))).S("\" stroke=\"").V(Get(L_835, "postD")).S("\" stroke-width=\"1.5\"/><circle cx=\"").V(Call(r2_20, V.Undef, GetIdx(Call(Wp_29, V.Undef, ((V)(a_838)), ((V)(lF_841)), ((V)((RT_842 + 3D)))), 0D))).S("\" cy=\"").V(Call(r2_20, V.Undef, GetIdx(Call(Wp_29, V.Undef, ((V)(a_838)), ((V)(lF_841)), ((V)((RT_842 + 3D)))), 1D))).S("\" r=\"5.5\" fill=\"").V((Truthy(Get(L_835, "bands")) ? GetIdx(Get(L_835, "bands"), 4D) : ((V)("#5cb8ff")))).S("\" stroke=\"").V(Get(L_835, "postD")).S("\" stroke-width=\"1.5\"/>");
fp_844 = Call(Wp_29, V.Undef, ((V)(a_838)), ((V)(lN_840)), ((V)(RT_842)));
b_836.S("<path d=\"M").V(Call(P2_30, V.Undef, fp_844)).S("V").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(fp_844, 1D)) - 30D))))).S("\" stroke=\"").V(Get(L_835, "postD")).S("\" stroke-width=\"2.2\"/><path d=\"M").V(Call(r2_20, V.Undef, GetIdx(fp_844, 0D))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(fp_844, 1D)) - 30D))))).S("l20 5.5l-20 6.5Z\" fill=\"#ff7a8a\" stroke=\"#c8485a\" stroke-width=\"1.3\" stroke-linejoin=\"round\"/>");
N_845 = 12D;
sAt_846 = Fn((V _arrowThis883, int _argc876, V j_882, V _a879, V _a880, V _a881, V[] _rest877) => {
return ((V)((RS_46 + (((LEN_45 - RS_46) * ToNum(j_882)) / N_845))));
}, 1, "", true);
lip_847 = new JsStrBuf("");
{
double j_884 = 0;
j_884 = 0D;
while (true) {
if (!((j_884 < N_845))) break;
V s0_886 = default;
V s1_887 = default;
V h0_888 = default;
V h1_889 = default;
s0_886 = Call(sAt_846, V.Undef, ((V)(j_884)));
s1_887 = Call(sAt_846, V.Undef, ((V)((j_884 + 1D))));
h0_888 = Call(HS_58, V.Undef, s0_886);
h1_889 = Call(HS_58, V.Undef, s1_887);
if (Truthy(Get(L_835, "bands"))) {
Invoke(Get(L_835, "bands"), "forEach", Fn((V _arrowThis898, int _argc890, V c_896, V i_897, V _a894, V _a895, V[] _rest891) => {
V n_899 = default;
n_899 = Get(Get(L_835, "bands"), "length");
lip_847.S("<path d=\"").V(Call(quad_33, V.Undef, s0_886, s1_887, ((V)(((-1D) + ((2D * ToNum(i_897)) / ToNum(n_899))))), ((V)(((-1D) + ((2D * ToNum(Add(i_897, ((V)(1D))))) / ToNum(n_899))))), h0_888, h1_889)).S("\" fill=\"").V(c_896).S("\" stroke=\"").V(c_896).S("\" stroke-width=\"0.8\"/>");
return default;
}, 2, "", true));
} else {
lip_847.S("<path d=\"").V(Call(quad_33, V.Undef, s0_886, s1_887, ((V)((-1D))), ((V)(1D)), h0_888, h1_889)).S("\" fill=\"").V(GetIdx(Get(L_835, "planks"), ((double)(ToInt32(j_884) & ToInt32(1D))))).S("\" stroke=\"").V(Get(L_835, "seam")).S("\" stroke-width=\"1\"/>");
}
lip_847.S("<path d=\"M").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, s0_886, ((V)((-1D))), h0_888))).S("L").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, s0_886, ((V)(1D)), h0_888))).S("\" stroke=\"").V(Get(L_835, "seam")).S("\" stroke-width=\"1.3\" opacity=\"0.35\"/>");
j_884++;
}
}
edge_848 = Fn((V _arrowThis908, int _argc900, V l_906, V dh_907, V _a904, V _a905, V[] _rest901) => {
V o_909 = default;
o_909 = Arr();
{
double j_910 = 0;
j_910 = 0D;
while (true) {
if (!((j_910 <= N_845))) break;
Invoke(o_909, "push", Call(Wp_29, V.Undef, Call(sAt_846, V.Undef, ((V)(j_910))), l_906, Add(Call(HS_58, V.Undef, Call(sAt_846, V.Undef, ((V)(j_910)))), dh_907)));
j_910++;
}
}
return o_909;
return default;
}, 2, "", true);
rev_849 = Fn((V _arrowThis919, int _argc912, V q_918, V _a915, V _a916, V _a917, V[] _rest913) => {
return Invoke(Invoke(q_918, "slice"), "reverse");
}, 1, "", true);
lipB_850 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Call(quad_33, V.Undef, ((V)(RS_46)), ((V)((LEN_45 + 10D))), ((V)((-1.1))), ((V)(1.1)), ((V)(0D)))).S("\" fill=\"#2a3a20\" opacity=\"0.14\"/>").V(Call(post_591, V.Undef, L_835, ((V)((RS_46 + 90D))), ((V)(1.06)), ((V)(0D)), ((V)((ToNum(Call(HS_58, V.Undef, ((V)((RS_46 + 90D))))) - 6D))), ((V)(5D)))).V(Call(post_591, V.Undef, L_835, ((V)((LEN_45 - 8D))), ((V)(1.06)), ((V)(0D)), ((V)((ToNum(Call(HS_58, V.Undef, ((V)((LEN_45 - 8D))))) - 6D))), ((V)(6D)))).End());
lipB_850.S(lip_847.Str).S("<path d=\"").V(Call(poly_32, V.Undef, Invoke(Call(edge_848, V.Undef, ((V)(1D)), ((V)(0D))), "concat", Call(rev_849, V.Undef, Call(edge_848, V.Undef, ((V)(1D)), ((V)(WH_49))))))).S("\" fill=\"").V(Get(L_835, "face")).S("\"/><path d=\"").V(Call(poly_32, V.Undef, Invoke(Call(edge_848, V.Undef, ((V)(1D)), ((V)(WH_49))), "concat", Call(rev_849, V.Undef, Call(edge_848, V.Undef, ((V)(1.12)), ((V)(WH_49))))))).S("\" fill=\"").V(Get(L_835, "top")).S("\" stroke=\"").V(Get(L_835, "side")).S("\" stroke-width=\"1\"/>");
lipF_851 = Add(Call(post_591, V.Undef, L_835, ((V)((RS_46 + 90D))), ((V)((-1.06))), ((V)(0D)), ((V)((ToNum(Call(HS_58, V.Undef, ((V)((RS_46 + 90D))))) - 6D))), ((V)(5D))), Call(post_591, V.Undef, L_835, ((V)((LEN_45 - 8D))), ((V)((-1.06))), ((V)(0D)), ((V)((ToNum(Call(HS_58, V.Undef, ((V)((LEN_45 - 8D))))) - 6D))), ((V)(6D))));
lipF_851 = ((V)(JsStrBuf.Begin().V(lipF_851).S("<path d=\"").V(Call(poly_32, V.Undef, Invoke(Call(edge_848, V.Undef, ((V)((-1.12))), ((V)((-9D)))), "concat", Call(rev_849, V.Undef, Call(edge_848, V.Undef, ((V)((-1.12))), ((V)(WH_49))))))).S("\" fill=\"").V(Get(L_835, "side")).S("\"/><path d=\"").V(Call(poly_32, V.Undef, Invoke(Call(edge_848, V.Undef, ((V)((-1.12))), ((V)(WH_49))), "concat", Call(rev_849, V.Undef, Call(edge_848, V.Undef, ((V)((-1D))), ((V)(WH_49))))))).S("\" fill=\"").V(Get(L_835, "top")).S("\" stroke=\"").V(Get(L_835, "side")).S("\" stroke-width=\"1\"/>").End()));
lipF_851 = ((V)(JsStrBuf.Begin().V(lipF_851).S("<path d=\"").V(Call(poly_32, V.Undef, Arr(Call(Wp_29, V.Undef, ((V)(LEN_45)), ((V)((-1.12))), ((V)((ToNum(Call(HS_58, V.Undef, ((V)(LEN_45)))) - 9D)))), Call(Wp_29, V.Undef, ((V)(LEN_45)), ((V)(1.12)), ((V)((ToNum(Call(HS_58, V.Undef, ((V)(LEN_45)))) - 9D)))), Call(Wp_29, V.Undef, ((V)(LEN_45)), ((V)(1.12)), Add(Call(HS_58, V.Undef, ((V)(LEN_45))), ((V)(WH_49)))), Call(Wp_29, V.Undef, ((V)(LEN_45)), ((V)((-1.12))), Add(Call(HS_58, V.Undef, ((V)(LEN_45))), ((V)(WH_49))))))).S("\" fill=\"").V(Get(L_835, "side")).S("\" stroke=\"#000\" stroke-opacity=\"0.12\" stroke-width=\"1.4\"/><path d=\"M").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, ((V)(LEN_45)), ((V)((-1D))), Add(Call(HS_58, V.Undef, ((V)(LEN_45))), ((V)(1D)))))).S("L").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, ((V)(LEN_45)), ((V)(1D)), Add(Call(HS_58, V.Undef, ((V)(LEN_45))), ((V)(1D)))))).S("\" stroke=\"#ffffff\" stroke-width=\"3\" stroke-linecap=\"round\"/>").End()));
Set(gStart_568, "innerHTML", ((V)(b_836.Str)));
Set(gEnd_570, "innerHTML", ((V)(lipB_850.Str)));
Set(gEndF_578, "innerHTML", lipF_851);
f_837.V(Add(Call(post_591, V.Undef, L_835, ((V)(a_838)), ((V)(lN_840)), ((V)(0D)), ((V)(RT_842)), ((V)(7D))), Call(post_591, V.Undef, L_835, ((V)(z_839)), ((V)(lN_840)), ((V)(0D)), ((V)(RT_842)), ((V)(7D)))));
lad_852 = Fn((V _arrowThis927, int _argc920, V s_926, V _a923, V _a924, V _a925, V[] _rest921) => {
return Arr(Call(Wp_29, V.Undef, s_926, ((V)((lN_840 - 1D))), ((V)(0D))), Call(Wp_29, V.Undef, s_926, ((V)(lN_840)), ((V)((SH_48 + 18D)))));
}, 1, "", true);
f_837.V(Add(Call(bar_843, V.Undef, Call(lad_852, V.Undef, ((V)((-128D)))), ((V)(3.8))), Call(bar_843, V.Undef, Call(lad_852, V.Undef, ((V)((-84D)))), ((V)(3.8)))));
{
double k_928 = 0;
k_928 = 1D;
while (true) {
if (!((k_928 <= 4D))) break;
double h_930 = 0;
double l_931 = 0;
h_930 = ((k_928 * SH_48) / 5D);
l_931 = ((lN_840 - 1D) + ((1D * h_930) / (SH_48 + 18D)));
f_837.V(Call(bar_843, V.Undef, Arr(Call(Wp_29, V.Undef, ((V)((-128D))), ((V)(l_931)), ((V)(h_930))), Call(Wp_29, V.Undef, ((V)((-84D))), ((V)(l_931)), ((V)(h_930)))), ((V)(3D))));
k_928++;
}
}
Set(gStartF_576, "innerHTML", ((V)(f_837.Str)));
return default;
}, 0, "buildStatic", false);
gen_603 = Fn((V _self932, int _argc933, V seed_939, V _a936, V _a937, V _a938, V[] _rest934) => {
V R_940 = default;
V @out_941 = default;
V add_942 = default;
V LN_943 = default;
double s_944 = 0;
if (_self932.IsNullish) _self932 = GlobalV;
R_940 = Call(rnd_37, V.Undef, seed_939);
@out_941 = Arr();
add_942 = Fn((V _arrowThis954, int _argc945, V t_951, V s_952, V l_953, V _a950, V[] _rest946) => {
return Invoke(@out_941, "push", Object_assign(NewObj(4).Put("t", t_951).Put("s", s_952).Put("l", l_953).Put("hit", ((V)(0D))).V, GetK(DEF_61, t_951)));
}, 3, "", true);
LN_943 = Arr(((V)((-0.5))), ((V)(0.5)));
s_944 = 520D;
while ((s_944 < (RS_46 - 600D))) {
V sec_955 = default;
V r_956 = default;
V A_957 = default;
double B_958 = 0;
V soft_959 = default;
sec_955 = Call(secAt_57, V.Undef, ((V)(s_944)));
r_956 = Call(R_940, V.Undef);
A_957 = GetIdx(LN_943, (LtN(Call(R_940, V.Undef), 0.5) ? 0D : 1D));
B_958 = (-ToNum(A_957));
soft_959 = Fn((V _arrowThis966, int _argc960, V _a962, V _a963, V _a964, V _a965, V[] _rest961) => {
return GetIdx(Arr(((V)("sand")), ((V)("leaves")), ((V)("bucket"))), System.Math.Floor((ToNum(Call(R_940, V.Undef)) * 3D)));
}, 0, "", true);
if (SEqS(sec_955, "meadow")) {
if (LtN(r_956, 0.34)) {
Call(add_942, V.Undef, Call(soft_959, V.Undef), ((V)(s_944)), A_957);
} else {
if (LtN(r_956, 0.6)) {
Call(add_942, V.Undef, ((V)("slick")), ((V)(s_944)), A_957);
} else {
if (LtN(r_956, 0.85)) {
Call(add_942, V.Undef, Call(soft_959, V.Undef), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("slick")), ((V)((s_944 + 20D))), ((V)(B_958)));
} else {
Call(add_942, V.Undef, ((V)("ramp")), ((V)(s_944)), ((V)(0D)));
}
}
}
} else {
if (SEqS(sec_955, "garden")) {
if (LtN(r_956, 0.25)) {
Call(add_942, V.Undef, ((V)("gnome")), ((V)(s_944)), A_957);
} else {
if (LtN(r_956, 0.45)) {
Call(add_942, V.Undef, ((V)("gnome")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("bucket")), ((V)((s_944 + 200D))), ((V)(B_958)));
} else {
if (LtN(r_956, 0.6)) {
Call(add_942, V.Undef, ((V)("mud")), ((V)(s_944)), A_957);
} else {
if (LtN(r_956, 0.82)) {
Call(add_942, V.Undef, ((V)("slick")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("gnome")), ((V)((s_944 + 190D))), A_957);
} else {
Call(add_942, V.Undef, ((V)("gold")), ((V)(s_944)), A_957);
}
}
}
}
} else {
if (SEqS(sec_955, "farm")) {
if (LtN(r_956, 0.25)) {
Call(add_942, V.Undef, ((V)("hay")), ((V)(s_944)), A_957);
} else {
if (LtN(r_956, 0.45)) {
Call(add_942, V.Undef, ((V)("hay")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("hay")), ((V)((s_944 + 210D))), ((V)(B_958)));
} else {
if (LtN(r_956, 0.62)) {
Call(add_942, V.Undef, ((V)("ramp")), ((V)(s_944)), ((V)(0D)));
Call(add_942, V.Undef, ((V)("log")), ((V)((s_944 + 100D))), ((V)(0D)));
} else {
if (LtN(r_956, 0.78)) {
Call(add_942, V.Undef, ((V)("mud")), ((V)(s_944)), A_957);
} else {
if (LtN(r_956, 0.92)) {
Call(add_942, V.Undef, ((V)("hay")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("slick")), ((V)(s_944)), ((V)(B_958)));
} else {
Call(add_942, V.Undef, ((V)("hay")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("gold")), ((V)((s_944 + 160D))), ((V)(B_958)));
}
}
}
}
}
} else {
if (SEqS(sec_955, "sprinkle")) {
if (LtN(r_956, 0.28)) {
Call(add_942, V.Undef, ((V)("slick")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("slick")), ((V)((s_944 + 200D))), ((V)(B_958)));
} else {
if (LtN(r_956, 0.45)) {
Call(add_942, V.Undef, ((V)("rock")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("slick")), ((V)(s_944)), ((V)(B_958)));
} else {
if (LtN(r_956, 0.62)) {
Call(add_942, V.Undef, ((V)("rock")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("rock")), ((V)((s_944 + 210D))), ((V)(B_958)));
} else {
if (LtN(r_956, 0.74)) {
Call(add_942, V.Undef, ((V)("mud")), ((V)(s_944)), A_957);
} else {
if (LtN(r_956, 0.86)) {
Call(add_942, V.Undef, ((V)("gold")), ((V)(s_944)), A_957);
} else {
Call(add_942, V.Undef, ((V)("ramp")), ((V)(s_944)), ((V)(0D)));
Call(add_942, V.Undef, ((V)("log")), ((V)((s_944 + 100D))), ((V)(0D)));
}
}
}
}
}
} else {
if (LtN(r_956, 0.3)) {
Call(add_942, V.Undef, ((V)("rock")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("gnome")), ((V)((s_944 + 210D))), ((V)(B_958)));
} else {
if (LtN(r_956, 0.55)) {
Call(add_942, V.Undef, ((V)("slick")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("rock")), ((V)((s_944 + 200D))), A_957);
} else {
if (LtN(r_956, 0.75)) {
Call(add_942, V.Undef, ((V)("hay")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("slick")), ((V)(s_944)), ((V)(B_958)));
} else {
if (LtN(r_956, 0.88)) {
Call(add_942, V.Undef, ((V)("mud")), ((V)(s_944)), A_957);
} else {
Call(add_942, V.Undef, ((V)("rock")), ((V)(s_944)), A_957);
Call(add_942, V.Undef, ((V)("gold")), ((V)((s_944 + 170D))), ((V)(B_958)));
}
}
}
}
}
}
}
}
s_944 = (s_944 + (ToNum(Call(lerp_19, V.Undef, ((V)(420D)), ((V)(330D)), ((V)((s_944 / LEN_45))))) * (0.88 + (ToNum(Call(R_940, V.Undef)) * 0.3))));
}
return Invoke(@out_941, "sort", Fn((V _arrowThis975, int _argc967, V a_973, V b_974, V _a971, V _a972, V[] _rest968) => {
return ((V)((ToNum(Get(a_973, "s")) - ToNum(Get(b_974, "s")))));
}, 2, "", true));
return default;
}, 1, "gen", false);
spawn_604 = Fn((V _self976, int _argc977, V it_983, V _a980, V _a981, V _a982, V[] _rest978) => {
V html_984 = default;
if (_self976.IsNullish) _self976 = GlobalV;
html_984 = InvokeK(ART_64, Get(it_983, "t"), it_983);
if (Truthy(Get(it_983, "flat"))) {
Set(it_983, "el", Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, Get(it_983, "s"), Get(it_983, "l"), ((V)(SH_48))))).S(")").End()))).V, gDecal_571));
Set(Get(it_983, "el"), "innerHTML", html_984);
} else {
Set(it_983, "o", Call(addStand_587, V.Undef, html_984, Get(it_983, "s"), Get(it_983, "l"), ((V)(SH_48))));
Set(it_983, "el", Get(Get(it_983, "o"), "el"));
}
Invoke(alive_602, "push", it_983);
return default;
}, 1, "spawn", false);
despawn_605 = Fn((V _self985, int _argc986, V it_992, V _a989, V _a990, V _a991, V[] _rest987) => {
if (_self985.IsNullish) _self985 = GlobalV;
if (Truthy(Get(it_992, "o"))) {
Call(dropStand_588, V.Undef, Get(it_992, "o"));
} else {
if (Truthy(Get(it_992, "el"))) {
Invoke(Get(it_992, "el"), "remove");
}
}
Set(it_992, "el", Set(it_992, "o", V.Null));
return default;
}, 1, "despawn", false);
feed_606 = Fn((V _self993, int _argc994, V sc_1000, V z_1001, V _a998, V _a999, V[] _rest995) => {
double lo_1002 = 0;
V hi_1003 = default;
if (_self993.IsNullish) _self993 = GlobalV;
lo_1002 = (ToNum(sc_1000) - (700D / ToNum(z_1001)));
hi_1003 = Add(sc_1000, ((V)((1300D / ToNum(z_1001)))));
while ((Lt(((V)(nextI_601)), Get(items_600, "length")) && Lt(Get(GetIdx(items_600, nextI_601), "s"), hi_1003))) {
if (GtN(Get(GetIdx(items_600, nextI_601), "s"), lo_1002)) {
Call(spawn_604, V.Undef, GetIdx(items_600, nextI_601));
}
nextI_601++;
}
{
double i_1004 = 0;
i_1004 = (ToNum(Get(alive_602, "length")) - 1D);
while (true) {
if (!((i_1004 >= 0D))) break;
if (LtN(Get(GetIdx(alive_602, i_1004), "s"), lo_1002)) {
Call(despawn_605, V.Undef, GetIdx(alive_602, i_1004));
Invoke(alive_602, "splice", ((V)(i_1004)), ((V)(1D)));
}
i_1004--;
}
}
return default;
}, 2, "feed", false);
windOn_621 = Fn((V _self1006, int _argc1007, V _a1009, V _a1010, V _a1011, V _a1012, V[] _rest1008) => {
if (_self1006.IsNullish) _self1006 = GlobalV;
try {
if (SEqS(Invoke(G("localStorage"), "getItem", ((V)("yardgames.v1.mute"))), "1")) {
return default;
}
} catch (System.Exception _ex1013) {
V e_1014 = default;
e_1014 = Caught(_ex1013);

}
if (Truthy(AU_620)) {
return default;
}
try {
V AC_1015 = default;
V c_1016 = default;
double n_1017 = 0;
V b_1018 = default;
V d_1019 = default;
V src_1020 = default;
V f_1021 = default;
V g_1022 = default;
AC_1015 = (Get(G("window"), "AudioContext") is var _t1023 && Truthy(_t1023) ? _t1023 : Get(G("window"), "webkitAudioContext"));
c_1016 = New(AC_1015);
n_1017 = (ToNum(Get(c_1016, "sampleRate")) * 2D);
b_1018 = Invoke(c_1016, "createBuffer", ((V)(1D)), ((V)(n_1017)), Get(c_1016, "sampleRate"));
d_1019 = Invoke(b_1018, "getChannelData", ((V)(0D)));
{
double i_1024 = 0;
i_1024 = 0D;
while (true) {
if (!((i_1024 < n_1017))) break;
SetIdx(d_1019, i_1024, ((V)(((ToNum(Invoke(G("Math"), "random")) * 2D) - 1D))));
i_1024++;
}
}
src_1020 = Invoke(c_1016, "createBufferSource");
Set(src_1020, "buffer", b_1018);
Set(src_1020, "loop", (true ? V.True : V.False));
f_1021 = Invoke(c_1016, "createBiquadFilter");
Set(f_1021, "type", ((V)("bandpass")));
Set(Get(f_1021, "Q"), "value", ((V)(0.9)));
g_1022 = Invoke(c_1016, "createGain");
Set(Get(g_1022, "gain"), "value", ((V)(0D)));
Invoke(src_1020, "connect", f_1021);
Invoke(f_1021, "connect", g_1022);
Invoke(g_1022, "connect", Get(c_1016, "destination"));
Invoke(src_1020, "start");
AU_620 = NewObj(4).Put("c", c_1016).Put("f", f_1021).Put("g", g_1022).Put("src", src_1020).V;
} catch (System.Exception _ex1026) {
V e_1027 = default;
e_1027 = Caught(_ex1026);
AU_620 = V.Null;
}
return default;
}, 0, "windOn", false);
windSet_622 = Fn((V _self1028, int _argc1029, V v_1035, V on_1036, V _a1033, V _a1034, V[] _rest1030) => {
V t_1037 = default;
if (_self1028.IsNullish) _self1028 = GlobalV;
if (!(Truthy(AU_620))) {
return default;
}
t_1037 = Get(Get(AU_620, "c"), "currentTime");
Invoke(Get(Get(AU_620, "f"), "frequency"), "setTargetAtTime", ((V)((260D + (ToNum(v_1035) * 13D)))), t_1037, ((V)(0.12)));
Invoke(Get(Get(AU_620, "g"), "gain"), "setTargetAtTime", (Truthy(on_1036) ? Call(cl_18, V.Undef, ((V)(((ToNum(v_1035) - 15D) / 110D))), ((V)(0.02)), ((V)(0.2))) : ((V)(0D))), t_1037, ((V)((Truthy(on_1036) ? 0.15 : 0.35))));
return default;
}, 2, "windSet", false);
windOff_623 = Fn((V _self1038, int _argc1039, V _a1041, V _a1042, V _a1043, V _a1044, V[] _rest1040) => {
V a_1045 = default;
if (_self1038.IsNullish) _self1038 = GlobalV;
if (!(Truthy(AU_620))) {
return default;
}
a_1045 = AU_620;
AU_620 = V.Null;
try {
Invoke(Get(Get(a_1045, "g"), "gain"), "setTargetAtTime", ((V)(0D)), Get(Get(a_1045, "c"), "currentTime"), ((V)(0.1)));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis1061, int _argc1055, V _a1057, V _a1058, V _a1059, V _a1060, V[] _rest1056) => {
try {
Invoke(Get(a_1045, "src"), "stop");
Invoke(Get(a_1045, "c"), "close");
} catch (System.Exception _ex1062) {
V e_1054 = default;
e_1054 = Caught(_ex1062);

}
return default;
}, 0, "", true), ((V)(500D)));
} catch (System.Exception _ex1063) {
V e_1064 = default;
e_1064 = Caught(_ex1063);

}
return default;
}, 0, "windOff", false);
reset_633 = Fn((V _self1065, int _argc1066, V _a1068, V _a1069, V _a1070, V _a1071, V[] _rest1067) => {
if (_self1065.IsNullish) _self1065 = GlobalV;
Object_assign(st_631, NewObj(20).Put("phase", ((V)("ready"))).Put("s", ((V)(ST0_55))).Put("l", ((V)(0D))).Put("tgt", ((V)(0D))).Put("h", ((V)(SH_48))).Put("ha", ((V)(0D))).Put("vh", ((V)(0D))).Put("v", ((V)(0D))).Put("top", ((V)(0D))).Put("lc", ((V)(0D))).Put("sc", ((V)(ST0_55))).Put("stun", ((V)(0D))).Put("boostT", ((V)(0D))).Put("punch", ((V)(0D))).Put("mud", ((V)(0D))).Put("boosts", ((V)(0D))).Put("bonks", ((V)(0D))).Put("shake", ((V)(0D))).Put("toldPool", ((V)(0D))).Put("k", ((V)(0D))).V);
Invoke(alive_602, "forEach", despawn_605);
alive_602 = Arr();
items_600 = Call(gen_603, V.Undef, ((V)((1234D + System.Math.Floor((ToNum(Invoke(G("Math"), "random")) * 9000D))))));
nextI_601 = 0D;
{
foreach (V _k1072 in new JsIter(new ArrBuilder().Spread(Invoke(chunks_589, "keys")).V)) {
V i_1073 = default;
i_1073 = _k1072;
Call(dropChunk_597, V.Undef, i_1073);
}
}
Call(buildStatic_599, V.Undef);
Invoke(me_624, "hide", (false ? V.True : V.False));
Invoke(me_624, "play", ((V)("idle")));
return default;
}, 0, "reset", false);
botSteer_636 = Fn((V _self1074, int _argc1075, V t_1081, V _a1078, V _a1079, V _a1080, V[] _rest1076) => {
V sk_1082 = default;
double ahead_1083 = 0;
V best_1084 = default;
double bs_1085 = 0;
if (_self1074.IsNullish) _self1074 = GlobalV;
if (((ToNum(t_1081) - ToNum(Get(st_631, "botT"))) < (120D - (ToNum(Get(st_631, "bot")) * 60D)))) {
return default;
}
Set(st_631, "botT", t_1081);
sk_1082 = Get(st_631, "bot");
ahead_1083 = (200D + (ToNum(sk_1082) * 260D));
best_1084 = Get(st_631, "tgt");
bs_1085 = (-1000000000D);
{
double c_1086 = 0;
c_1086 = (-LMAX_42);
while (true) {
if (!((c_1086 <= (LMAX_42 + 0.000001)))) break;
double sc_1088 = 0;
sc_1088 = ((-System.Math.Abs((c_1086 - ToNum(Get(st_631, "l"))))) * 0.6);
{
foreach (V _k1089 in new JsIter(alive_602)) {
V q_1090 = default;
q_1090 = _k1089;
double ds_1091 = 0;
V near_1092 = default;
double w_1093 = 0;
ds_1091 = (ToNum(Get(q_1090, "s")) - ToNum(Get(st_631, "s")));
if (Truthy(((((ds_1091 < (-10D)) || (ds_1091 > ahead_1083)) ? V.True : V.False) is var _t1094 && Truthy(_t1094) ? _t1094 : Get(q_1090, "hit")))) {
continue;
}
near_1092 = (Lt(((V)(System.Math.Abs((c_1086 - ToNum(Get(q_1090, "l")))))), Add(Add(Get(q_1090, "hw"), ((V)(RW_43))), ((V)(0.03)))) ? V.True : V.False);
w_1093 = (1D - ((ds_1091 / ahead_1083) * 0.5));
if (Truthy(near_1092)) {
sc_1088 = (sc_1088 + ((SEqS(Get(q_1090, "k"), "hard") ? (-10D) : (SEqS(Get(q_1090, "k"), "soft") ? (-6D) : (SEqS(Get(q_1090, "k"), "mud") ? (-7D) : (SEqS(Get(q_1090, "k"), "gold") ? 9D : (SEqS(Get(q_1090, "k"), "boost") ? 7D : 0D))))) * w_1093));
}
}
}
if ((sc_1088 > bs_1085)) {
bs_1085 = sc_1088;
best_1084 = ((V)(c_1086));
}
c_1086 = (c_1086 + 0.11);
}
}
Set(st_631, "tgt", (Lt(Invoke(G("Math"), "random"), sk_1082) ? best_1084 : Call(cl_18, V.Undef, Add(Get(st_631, "tgt"), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.5)))), ((V)((-LMAX_42))), ((V)(LMAX_42)))));
return default;
}, 1, "botSteer", false);
hits_637 = Fn((V _self1095, int _argc1096, V _a1098, V _a1099, V _a1100, V _a1101, V[] _rest1097) => {
V L_1102 = default;
if (_self1095.IsNullish) _self1095 = GlobalV;
L_1102 = GetK(LOOK_62, look_565);
{
foreach (V _k1103 in new JsIter(alive_602)) {
V q_1104 = default;
q_1104 = _k1103;
V p_1105 = default;
V hard_1106 = default;
double dv_1107 = 0;
if (Truthy(((Get(q_1104, "hit") is var _t1108 && Truthy(_t1108) ? _t1108 : (Gt(((V)(System.Math.Abs((ToNum(Get(q_1104, "s")) - ToNum(Get(st_631, "s")))))), Add(Get(q_1104, "hs"), ((V)(10D)))) ? V.True : V.False)) is var _t1109 && Truthy(_t1109) ? _t1109 : (Gt(((V)(System.Math.Abs((ToNum(Get(q_1104, "l")) - ToNum(Get(st_631, "l")))))), Add(Get(q_1104, "hw"), ((V)(RW_43)))) ? V.True : V.False)))) {
continue;
}
if ((GtN(Get(st_631, "ha"), (ToNum(Get(q_1104, "hh")) - 2D)) && !SEqS(Get(q_1104, "k"), "ramp"))) {
continue;
}
p_1105 = Call(scr_632, V.Undef, Get(st_631, "s"), Get(st_631, "l"), Get(st_631, "h"));
if (SEqS(Get(q_1104, "k"), "ramp")) {
if (LtN(Get(st_631, "ha"), 8D)) {
Set(q_1104, "hit", ((V)(1D)));
Set(st_631, "vh", ((V)(370D)));
Set(st_631, "ha", ((V)(Max(ToNum(Get(st_631, "ha")), 1D))));
Invoke(SFX_21, "boing");
Invoke(ctx_560, "toast", ((V)("Hop!")), GetIdx(p_1105, 0D), ((V)((ToNum(GetIdx(p_1105, 1D)) - 70D))), ((V)("#ffffff")));
}
continue;
}
Set(q_1104, "hit", ((V)(1D)));
if ((SEqS(Get(q_1104, "k"), "boost") || SEqS(Get(q_1104, "k"), "gold"))) {
double dv_1110 = 0;
dv_1110 = (((SEqS(Get(q_1104, "k"), "gold") ? 13D : 8D) * ToNum(Get(L_1102, "boost"))) * (1D - (ToNum(Get(st_631, "v")) / 160D)));
OpSet(st_631, "v", 0, ((V)(dv_1110)));
Set(st_631, "boostT", ((V)(0.7)));
Set(st_631, "punch", ((V)(1D)));
IncM(st_631, "boosts", 1D, false);
Invoke(SFX_21, "whoosh");
if (SEqS(Get(q_1104, "k"), "gold")) {
Invoke(SFX_21, "pop");
}
Invoke(ctx_560, "toast", ((V)(JsStrBuf.Begin().S((SEqS(Get(q_1104, "k"), "gold") ? "Turbo! +" : "Splash! +")).N(Round(dv_1110)).End())), Add(GetIdx(p_1105, 0D), ((V)(20D))), ((V)((ToNum(GetIdx(p_1105, 1D)) - 80D))), ((V)((SEqS(Get(q_1104, "k"), "gold") ? "#ffe36e" : "#bfe8ff"))));
Invoke(ctx_560, "burst", GetIdx(p_1105, 0D), ((V)((ToNum(GetIdx(p_1105, 1D)) - 10D))), ((V)((SEqS(Get(q_1104, "k"), "gold") ? "star" : "drop"))), ((V)(14D)), NewObj(2).Put("v", ((V)(160D))).Put("spread", ((V)(2.4))).V);
if (Truthy(Get(q_1104, "el"))) {
Set(Get(Get(q_1104, "el"), "style"), "opacity", ((V)(0.45)));
}
continue;
}
if (SEqS(Get(q_1104, "k"), "mud")) {
Set(st_631, "mud", ((V)(0.55)));
IncM(st_631, "bonks", 1D, false);
Invoke(SFX_21, "thud");
Invoke(ctx_560, "toast", ((V)("Mud!")), Add(GetIdx(p_1105, 0D), ((V)(20D))), ((V)((ToNum(GetIdx(p_1105, 1D)) - 80D))), ((V)("#e2b98a")));
Invoke(ctx_560, "burst", GetIdx(p_1105, 0D), ((V)((ToNum(GetIdx(p_1105, 1D)) - 6D))), ((V)("dust")), ((V)(10D)), NewObj(2).Put("col", ((V)("#8a5a34"))).Put("v", ((V)(90D))).V);
continue;
}
hard_1106 = (SEqS(Get(q_1104, "k"), "hard") ? V.True : V.False);
dv_1107 = ((Truthy(hard_1106) ? (9D + (0.25 * (ToNum(Get(st_631, "v")) - VB_39))) : (5D + (0.12 * (ToNum(Get(st_631, "v")) - VB_39)))) * ToNum(Get(L_1102, "hit")));
Set(st_631, "v", ((V)(Max((VB_39 * (Truthy(hard_1106) ? 0.7 : 0.85)), (ToNum(Get(st_631, "v")) - dv_1107)))));
Set(st_631, "stun", ((V)((Truthy(hard_1106) ? 0.6 : 0.35))));
IncM(st_631, "bonks", 1D, false);
Set(st_631, "shake", ((V)((Truthy(hard_1106) ? 7D : 3.5))));
Set(st_631, "l", Call(cl_18, V.Undef, Add(Get(st_631, "l"), ((V)((Gt(Get(st_631, "l"), Get(q_1104, "l")) ? 0.12 : (-0.12))))), ((V)((-LMAX_42))), ((V)(LMAX_42))));
if (Truthy(hard_1106)) {
Invoke(SFX_21, "thud");
Invoke(me_624, "play", ((V)("surprised")));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis1125, int _argc1119, V _a1121, V _a1122, V _a1123, V _a1124, V[] _rest1120) => {
return ((SEqS(Get(st_631, "phase"), "ride") ? V.True : V.False) is var _t1126 && !Truthy(_t1126) ? _t1126 : Invoke(me_624, "play", ((V)("idle"))));
}, 0, "", true), ((V)(650D)));
} else {
Invoke(SFX_21, "pop");
}
Invoke(ctx_560, "toast", ((V)(JsStrBuf.Begin().S((Truthy(hard_1106) ? "Bonk! -" : "Oof! -")).N(Round(dv_1107)).End())), Add(GetIdx(p_1105, 0D), ((V)(20D))), ((V)((ToNum(GetIdx(p_1105, 1D)) - 80D))), ((V)("#ffb0a0")));
Invoke(ctx_560, "burst", GetIdx(p_1105, 0D), ((V)((ToNum(GetIdx(p_1105, 1D)) - 30D))), ((V)((Truthy(hard_1106) ? "star" : "dust"))), ((V)((Truthy(hard_1106) ? 8D : 9D))), NewObj(2).Put("v", ((V)(110D))).Put("col", (SEqS(Get(q_1104, "t"), "sand") ? ((V)("#f1d48a")) : (SEqS(Get(q_1104, "t"), "leaves") ? ((V)("#ff9a3a")) : (SEqS(Get(q_1104, "t"), "hay") ? ((V)("#f2cf6a")) : V.Undef)))).V);
if (Truthy(((Get(q_1104, "el") is var _t1127 && !Truthy(_t1127) ? _t1127 : (!SEqS(Get(q_1104, "t"), "rock") ? V.True : V.False)) is var _t1128 && !Truthy(_t1128) ? _t1128 : (!SEqS(Get(q_1104, "t"), "log") ? V.True : V.False)))) {
Invoke(Get(Get(q_1104, "el"), "classList"), "add", ((V)("ygs-hit")));
}
}
}
return default;
}, 0, "hits", false);
launch_638 = Fn((V _self1129, int _argc1130, V _a1132, V _a1133, V _a1134, V _a1135, V[] _rest1131) => {
double vs_1136 = 0;
V p_1137 = default;
V tr_1138 = default;
if (_self1129.IsNullish) _self1129 = GlobalV;
Set(st_631, "phase", ((V)("fly")));
Set(st_631, "lipV", Get(st_631, "v"));
Set(st_631, "tf", tNow_628);
vs_1136 = (ToNum(Get(st_631, "v")) * KV_38);
Set(st_631, "vs", ((V)((vs_1136 * 0.45))));
Set(st_631, "vh", ((V)((360D + (0.35 * vs_1136)))));
Set(st_631, "h", Call(HS_58, V.Undef, ((V)(LEN_45))));
Invoke(SFX_21, "boing");
Invoke(SFX_21, "whoosh");
p_1137 = Call(scr_632, V.Undef, Get(st_631, "s"), Get(st_631, "l"), Get(st_631, "h"));
Invoke(ctx_560, "burst", GetIdx(p_1137, 0D), GetIdx(p_1137, 1D), ((V)("drop")), ((V)(16D)), NewObj(1).Put("v", ((V)(170D))).V);
tr_1138 = Call(tierOf_60, V.Undef, Get(st_631, "v"));
Invoke(ctx_560, "toast", ((V)(JsStrBuf.Begin().N(Round(ToNum(Get(st_631, "v")))).S(" km/h!").End())), ((V)((ToNum(W_563) / 2D))), ((V)(96D)), GetIdx(tr_1138, 2D), (true ? V.True : V.False));
if (GeN(Get(st_631, "v"), 75D)) {
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis1153, int _argc1147, V _a1149, V _a1150, V _a1151, V _a1152, V[] _rest1148) => {
return ((SEqS(Get(st_631, "phase"), "fly") ? V.True : V.False) is var _t1154 && !Truthy(_t1154) ? _t1154 : Invoke(ctx_560, "toast", ((V)("Cannonball!")), ((V)((ToNum(W_563) / 2D))), ((V)(150D)), ((V)("#ffffff"))));
}, 0, "", true), ((V)(250D)));
}
friends_629 = Invoke(Invoke(ctx_560, "opponent", ((V)(3D))), "map", Fn((V _arrowThis1163, int _argc1155, V key_1161, V i_1162, V _a1159, V _a1160, V[] _rest1156) => {
V c_1164 = default;
c_1164 = Invoke(ctx_560, "creature", key_1161, NewObj(1).Put("yaw", ((V)((SEqN(i_1162, 1D) ? (-20D) : (SEqN(i_1162, 2D) ? 20D : 0D))))).V);
Invoke(c_1164, "hide", (true ? V.True : V.False));
return NewObj(2).Put("c", c_1164).Put("key", key_1161).V;
return default;
}, 2, "", true));
Call(windSet_622, V.Undef, Get(st_631, "v"), (false ? V.True : V.False));
return default;
}, 0, "launch", false);
transition_639 = Fn((V _self1165, int _argc1166, V _a1168, V _a1169, V _a1170, V _a1171, V[] _rest1167) => {
V t0_1172 = default;
V fade_1173 = default;
if (_self1165.IsNullish) _self1165 = GlobalV;
Set(st_631, "tr", ((V)(1D)));
t0_1172 = Invoke(G("performance"), "now");
Invoke(SFX_21, "whoosh");
fade_1173 = Fn((V _arrowThis1180, int _argc1174, V _a1176, V _a1177, V _a1178, V _a1179, V[] _rest1175) => {
double u_1181 = 0;
V t1_1182 = default;
V @out_1183 = default;
u_1181 = ((ToNum(Invoke(G("performance"), "now")) - ToNum(t0_1172)) / 160D);
Invoke(flash_619, "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)(Min(1D, u_1181)))));
if ((u_1181 < 1D)) {
return Call(G("requestAnimationFrame"), V.Undef, fade_1173);
}
Invoke(Arr(slideBg_566, wB_567, wF_575, speedL_581), "forEach", Fn((V _arrowThis1191, int _argc1184, V e_1190, V _a1187, V _a1188, V _a1189, V[] _rest1185) => {
return Set(Get(e_1190, "style"), "display", ((V)("none")));
}, 1, "", true));
Set(Get(pg_615, "style"), "display", ((V)("none")));
Set(Get(sp_607, "style"), "display", ((V)("none")));
Set(stands_584, "length", ((V)(0D)));
Set(Get(scB_574, "style"), "display", ((V)("")));
Set(Get(scF_580, "style"), "display", ((V)("")));
pool_630 = Call(poolScene_640, V.Undef);
Set(st_631, "phase", ((V)("pool")));
Call(windOff_623, V.Undef);
t1_1182 = Invoke(G("performance"), "now");
@out_1183 = Fn((V _arrowThis1198, int _argc1192, V _a1194, V _a1195, V _a1196, V _a1197, V[] _rest1193) => {
double v_1199 = 0;
v_1199 = (1D - ((ToNum(Invoke(G("performance"), "now")) - ToNum(t1_1182)) / 320D));
Invoke(flash_619, "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)(Max(0D, v_1199)))));
if ((v_1199 > 0D)) {
Call(G("requestAnimationFrame"), V.Undef, @out_1183);
}
return default;
}, 0, "", true);
Call(G("requestAnimationFrame"), V.Undef, @out_1183);
return default;
}, 0, "", true);
Call(G("requestAnimationFrame"), V.Undef, fade_1173);
return default;
}, 0, "transition", false);
poolScene_640 = Fn((V _self1200, int _argc1201, V _a1203, V _a1204, V _a1205, V _a1206, V[] _rest1202) => {
V k_1207 = default;
V v_1208 = default;
V tr_1209 = default;
double pts_1210 = 0;
double PX_1211 = 0;
double PY_1212 = 0;
double RX_1213 = 0;
double RY_1214 = 0;
double TB_1215 = 0;
double IR_1216 = 0;
double WY_1217 = 0;
double LX_1218 = 0;
V ell_1219 = default;
JsStrBuf b_1220 = null;
V R_1221 = default;
V water_1222 = default;
V duck_1223 = default;
V ballS_1224 = default;
V duckG_1225 = default;
V ballG_1226 = default;
double YW_1227 = 0;
V splG_1228 = default;
V wc_1229 = default;
V waterF_1230 = default;
V ringG_1231 = default;
V rings_1232 = default;
V front_1233 = default;
V spillG_1234 = default;
JsStrBuf f_1235 = null;
V spots_1236 = default;
V T0p_1237 = default;
V fallAt_1238 = default;
V hitAt_1239 = default;
V fx_1240 = default;
V hit_1241 = default;
V col_1242 = default;
V jets_1243 = default;
double nj_1244 = 0;
V crown_1245 = default;
V shakeG_1246 = default;
V boom_1247 = default;
if (_self1200.IsNullish) _self1200 = GlobalV;
boom_1247 = Fn((V _self1248, int _argc1249, V t_1255, V _a1252, V _a1253, V _a1254, V[] _rest1250) => {
if (_self1248.IsNullish) _self1248 = GlobalV;
Invoke(SFX_21, "splash");
if (GtN(k_1207, 0.5)) {
Call(G("setTimeout"), V.Undef, Get(SFX_21, "splash"), ((V)(120D)));
}
if (GtN(k_1207, 0.85)) {
Call(G("setTimeout"), V.Undef, Get(SFX_21, "splash"), ((V)(260D)));
}
Set(st_631, "shake", ((V)((2D + (12D * ToNum(k_1207))))));
Invoke(ctx_560, "burst", ((V)(LX_1218)), ((V)((WY_1217 - 6D))), ((V)("drop")), ((V)(Round((24D + (110D * ToNum(k_1207)))))), NewObj(5).Put("v", ((V)((170D + (340D * ToNum(k_1207)))))).Put("spread", ((V)(1.4))).Put("life", ((V)((0.9 + (0.7 * ToNum(k_1207)))))).Put("g", ((V)(520D))).Put("k", ((V)((1D + (0.6 * ToNum(k_1207)))))).V);
Invoke(ctx_560, "burst", ((V)(LX_1218)), ((V)(WY_1217)), ((V)("drop")), ((V)(Round((10D + (30D * ToNum(k_1207)))))), NewObj(6).Put("v", ((V)((100D + (150D * ToNum(k_1207)))))).Put("spread", ((V)(3.2))).Put("life", ((V)(0.9))).Put("g", ((V)(420D))).Put("col", ((V)("#ffffff"))).Put("k", ((V)(1.2))).V);
Invoke(friends_629, "forEach", Fn((V _arrowThis1264, int _argc1256, V fr_1262, V i_1263, V _a1260, V _a1261, V[] _rest1257) => {
double tx_1265 = 0;
double ty_1266 = 0;
V reach_1267 = default;
double T_1268 = 0;
tx_1265 = (ToNum(Get(fr_1262, "x")) - LX_1218);
ty_1266 = ((ToNum(Get(fr_1262, "y")) - 60D) - WY_1217);
reach_1267 = (Truthy(Get(fr_1262, "in")) ? ((V)(1D)) : Call(cl_18, V.Undef, ((V)(((ToNum(k_1207) - 0.2) / 0.6))), ((V)(0D)), ((V)(1D))));
T_1268 = (0.42 + (System.Math.Abs(tx_1265) / 1400D));
if (GtN(reach_1267, 0D)) {
double vx_1269 = 0;
double vy_1270 = 0;
vx_1269 = (tx_1265 / T_1268);
vy_1270 = ((ty_1266 - (((0.5 * 520D) * T_1268) * T_1268)) / T_1268);
Invoke(ctx_560, "burst", ((V)((LX_1218 + (Sign(tx_1265) * 14D)))), ((V)((WY_1217 - 8D))), ((V)("drop")), ((V)(Round((6D + (26D * ToNum(reach_1267)))))), NewObj(6).Put("v", ((V)(Hypot(vx_1269, vy_1270)))).Put("dir", ((V)(FdLibm.Atan2(vy_1270, vx_1269)))).Put("spread", ((V)(0.22))).Put("life", ((V)((T_1268 * 1.25)))).Put("g", ((V)(520D))).Put("k", ((V)((1D + (0.5 * ToNum(k_1207)))))).V);
}
Set(fr_1262, "hitAt", Add(t_1255, ((V)((Truthy(Get(fr_1262, "in")) ? 120D : (T_1268 * 1000D))))));
Set(fr_1262, "knock", ((Truthy(Get(fr_1262, "in")) ? GeN(k_1207, 0.6) : GeN(k_1207, 0.85)) ? V.True : V.False));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis1300, int _argc1294, V _a1296, V _a1297, V _a1298, V _a1299, V[] _rest1295) => {
if (Truthy(((GeN(k_1207, 0.3) ? V.True : V.False) is var _t1301 && Truthy(_t1301) ? _t1301 : Get(fr_1262, "in")))) {
Set(fr_1262, "wet", ((V)(1D)));
Set(Get(Get(Get(fr_1262, "c"), "host"), "style"), "filter", ((V)("saturate(1.35) brightness(0.88) contrast(1.05)")));
Invoke(Get(fr_1262, "c"), "play", ((V)((Truthy(Get(fr_1262, "knock")) ? "surprised" : (GeN(k_1207, 0.3) ? "surprised" : "happy")))));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis1315, int _argc1309, V _a1311, V _a1312, V _a1313, V _a1314, V[] _rest1310) => {
return Invoke(Get(fr_1262, "c"), "play", ((V)("happy")));
}, 0, "", true), ((V)(1500D)));
Invoke(ctx_560, "burst", Get(fr_1262, "x"), ((V)((ToNum(Get(fr_1262, "y")) - 50D))), ((V)("drop")), ((V)(Round((14D + (30D * ToNum(k_1207)))))), NewObj(5).Put("v", ((V)((160D + (80D * ToNum(k_1207)))))).Put("spread", TAU_22).Put("life", ((V)(0.7))).Put("g", ((V)(400D))).Put("k", ((V)(1.4))).V);
Invoke(ctx_560, "burst", Get(fr_1262, "x"), ((V)((ToNum(Get(fr_1262, "y")) - 50D))), ((V)("drop")), ((V)(8D)), NewObj(6).Put("v", ((V)(90D))).Put("spread", TAU_22).Put("life", ((V)(0.6))).Put("g", ((V)(300D))).Put("col", ((V)("#ffffff"))).Put("k", ((V)(1.6))).V);
if (Truthy((Get(fr_1262, "knock") is var _t1316 && !Truthy(_t1316) ? _t1316 : (!(Truthy(Get(fr_1262, "in"))) ? V.True : V.False)))) {
Invoke(SFX_21, "thud");
}
} else {
Invoke(Get(fr_1262, "c"), "play", ((V)("happy")));
}
return default;
}, 0, "", true), ((V)(Max(0D, (ToNum(Get(fr_1262, "hitAt")) - ToNum(t_1255))))));
return default;
}, 2, "", true));
if (GtN(k_1207, 0.6)) {
{
double i_1317 = 0;
i_1317 = 0D;
while (true) {
if (!((i_1317 < Round((4D + ((8D * (ToNum(k_1207) - 0.6)) * 2D)))))) break;
V e_1319 = default;
e_1319 = Call(S_17, V.Undef, ((V)("circle")), NewObj(7).Put("cx", Call(r2_20, V.Undef, ((V)((40D + (ToNum(Invoke(G("Math"), "random")) * (ToNum(W_563) - 80D))))))).Put("cy", Call(r2_20, V.Undef, ((V)((40D + (ToNum(Invoke(G("Math"), "random")) * (ToNum(H_564) - 100D))))))).Put("r", Call(r2_20, V.Undef, ((V)((8D + (ToNum(Invoke(G("Math"), "random")) * 18D)))))).Put("fill", ((V)("#dff6ff"))).Put("opacity", ((V)(0.5))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2D))).V, hud_582);
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis1333, int _argc1327, V _a1329, V _a1330, V _a1331, V _a1332, V[] _rest1328) => {
return Invoke(e_1319, "remove");
}, 0, "", true), ((V)((1600D + (ToNum(Invoke(G("Math"), "random")) * 800D)))));
i_1317++;
}
}
}
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis1347, int _argc1341, V _a1343, V _a1344, V _a1345, V _a1346, V[] _rest1342) => {
Invoke(ctx_560, "toast", GetIdx(tr_1209, 1D), ((V)((ToNum(W_563) / 2D))), ((V)(70D)), GetIdx(tr_1209, 2D), (true ? V.True : V.False));
Invoke(ctx_560, "add", ((V)(pts_1210)), ((V)((ToNum(W_563) / 2D))), ((V)(124D)), ((V)(JsStrBuf.Begin().S("+").N(pts_1210).End())), GetIdx(tr_1209, 2D));
if (GtN(k_1207, 0.55)) {
Invoke(SFX_21, "score");
}
return default;
}, 0, "", true), ((V)(520D)));
return default;
}, 1, "boom", false);
k_1207 = Set(st_631, "k", Call(cl_18, V.Undef, ((V)(((ToNum(Get(st_631, "lipV")) - 25D) / 85D))), ((V)(0D)), ((V)(1.15))));
v_1208 = Get(st_631, "lipV");
tr_1209 = Call(tierOf_60, V.Undef, v_1208);
pts_1210 = (Round(ToNum(v_1208)) * 10D);
PX_1211 = 390D;
PY_1212 = 244D;
RX_1213 = 186D;
RY_1214 = 44D;
TB_1215 = 19D;
IR_1216 = 24D;
WY_1217 = (PY_1212 + 9D);
LX_1218 = 370D;
ell_1219 = Fn((V _arrowThis1359, int _argc1348, V cx_1354, V cy_1355, V rx_1356, V ry_1357, V[] _rest1349) => {
V a_1358 = default;
a_1358 = (_argc1348 > 4 ? _rest1349[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(r2_20, V.Undef, cx_1354)).S("\" cy=\"").V(Call(r2_20, V.Undef, cy_1355)).S("\" rx=\"").V(Call(r2_20, V.Undef, rx_1356)).S("\" ry=\"").V(Call(r2_20, V.Undef, ry_1357)).S("\" ").V(a_1358).S("/>").End()));
}, 5, "", true);
b_1220 = new JsStrBuf(string.Concat("<defs><linearGradient id=\"ygpSky\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#6fc0ff\"/><stop offset=\"0.7\" stop-color=\"#c4e8ff\"/><stop offset=\"1\" stop-color=\"#e6f6ff\"/></linearGradient>", "<linearGradient id=\"ygpGr\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#9fdc6e\"/><stop offset=\"1\" stop-color=\"#5aaa48\"/></linearGradient><linearGradient id=\"ygpW\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#a6ecff\"/><stop offset=\"1\" stop-color=\"#3ea8ea\"/></linearGradient>", "<linearGradient id=\"ygpBl\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#6cbcff\"/><stop offset=\"0.45\" stop-color=\"#2a86e6\"/><stop offset=\"1\" stop-color=\"#1a5fb0\"/></linearGradient><linearGradient id=\"ygpWt\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.5\" stop-color=\"#f2f6fb\"/><stop offset=\"1\" stop-color=\"#c9d6e6\"/></linearGradient>", "<radialGradient id=\"ygpSun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fffbe0\"/><stop offset=\"0.5\" stop-color=\"#ffe680\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#ffe680\" stop-opacity=\"0\"/></radialGradient></defs>"));
b_1220.S("<rect x=\"-20\" y=\"-20\" width=\"").V(Add(W_563, ((V)(40D)))).S("\" height=\"260\" fill=\"url(#ygpSky)\"/><circle cx=\"676\" cy=\"56\" r=\"70\" fill=\"url(#ygpSun)\"/><circle cx=\"676\" cy=\"56\" r=\"24\" fill=\"#fff3a0\"/>");
Invoke(Arr(Arr(((V)(110D)), ((V)(58D)), ((V)(0.9))), Arr(((V)(300D)), ((V)(38D)), ((V)(0.65))), Arr(((V)(520D)), ((V)(74D)), ((V)(0.75))), Arr(((V)(760D)), ((V)(30D)), ((V)(0.55)))), "forEach", Fn((V _arrowThis1373, int _argc1360, V _a1362, V _a1363, V _a1364, V _a1365, V[] _rest1361) => {
V x_1368 = default;
V y_1370 = default;
V s_1372 = default;
{ V _t1366 = ListOf(_a1362);
{ V _t1367 = GetIdx(_t1366, 0D);
x_1368 = _t1367; }
{ V _t1369 = GetIdx(_t1366, 1D);
y_1370 = _t1369; }
{ V _t1371 = GetIdx(_t1366, 2D);
s_1372 = _t1371; }
}
b_1220.S("<g transform=\"translate(").V(x_1368).S(" ").V(y_1370).S(") scale(").V(s_1372).S(")\" fill=\"#ffffff\" opacity=\"0.95\"><circle cx=\"-26\" cy=\"4\" r=\"18\"/><circle cx=\"0\" cy=\"-8\" r=\"25\"/><circle cx=\"27\" cy=\"2\" r=\"19\"/><circle cx=\"10\" cy=\"10\" r=\"18\"/><circle cx=\"-12\" cy=\"11\" r=\"16\"/></g>");
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)(30D)), ((V)(1.1))), Arr(((V)(130D)), ((V)(0.85))), Arr(((V)(250D)), ((V)(1D))), Arr(((V)(540D)), ((V)(0.9))), Arr(((V)(650D)), ((V)(1.15))), Arr(((V)(760D)), ((V)(0.9)))), "forEach", Fn((V _arrowThis1385, int _argc1374, V _a1376, V _a1377, V _a1378, V _a1379, V[] _rest1375) => {
V x_1382 = default;
V s_1384 = default;
{ V _t1380 = ListOf(_a1376);
{ V _t1381 = GetIdx(_t1380, 0D);
x_1382 = _t1381; }
{ V _t1383 = GetIdx(_t1380, 1D);
s_1384 = _t1383; }
}
b_1220.S("<g transform=\"translate(").V(x_1382).S(" 196) scale(").V(s_1384).S(")\"><rect x=\"-6\" y=\"-60\" width=\"12\" height=\"62\" rx=\"3\" fill=\"#8a5a34\"/><circle cx=\"-22\" cy=\"-70\" r=\"28\" fill=\"#57a854\"/><circle cx=\"20\" cy=\"-74\" r=\"30\" fill=\"#57a854\"/><circle cx=\"0\" cy=\"-98\" r=\"32\" fill=\"#6cbb5c\"/><circle cx=\"-10\" cy=\"-106\" r=\"13\" fill=\"#8fd47a\" opacity=\"0.85\"/></g>");
return default;
}, 1, "", true));
b_1220.S("<rect x=\"-20\" y=\"166\" width=\"").V(Add(W_563, ((V)(40D)))).S("\" height=\"6\" fill=\"#f3e8da\"/><rect x=\"-20\" y=\"188\" width=\"").V(Add(W_563, ((V)(40D)))).S("\" height=\"6\" fill=\"#f3e8da\"/>");
{
double x_1386 = 0;
x_1386 = (-10D);
while (true) {
if (!(Lt(((V)(x_1386)), Add(W_563, ((V)(20D)))))) break;
b_1220.S("<path d=\"M").N(x_1386).S(" 210V164L").N((x_1386 + 7D)).S(" 156L").N((x_1386 + 14D)).S(" 164V210Z\" fill=\"#fffaf2\" stroke=\"#e2cfb8\" stroke-width=\"1\"/>");
x_1386 = (x_1386 + 20D);
}
}
b_1220.S("<rect x=\"-20\" y=\"206\" width=\"").V(Add(W_563, ((V)(40D)))).S("\" height=\"").N((ToNum(H_564) - 186D)).S("\" fill=\"url(#ygpGr)\"/>");
{
double i_1388 = 0;
i_1388 = 0D;
while (true) {
if (!((i_1388 < 9D))) break;
b_1220.S("<path d=\"M").N(((i_1388 * 100D) - 60D)).S(" ").V(Add(H_564, ((V)(10D)))).S("L").N(((i_1388 * 100D) + 10D)).S(" 206H").N(((i_1388 * 100D) + 50D)).S("L").N(((i_1388 * 100D) - 10D)).S(" ").V(Add(H_564, ((V)(10D)))).S("Z\" fill=\"#ffffff\" opacity=\"0.05\"/>");
i_1388++;
}
}
R_1221 = Call(rnd_37, V.Undef, ((V)(42D)));
{
double i_1390 = 0;
i_1390 = 0D;
while (true) {
if (!((i_1390 < 70D))) break;
double x_1392 = 0;
double y_1393 = 0;
double q_1394 = 0;
x_1392 = (ToNum(Call(R_1221, V.Undef)) * ToNum(W_563));
y_1393 = (212D + (ToNum(Call(R_1221, V.Undef)) * (ToNum(H_564) - 212D)));
q_1394 = (0.7 + ((y_1393 - 206D) / 150D));
b_1220.S("<path d=\"M").V(Call(r2_20, V.Undef, ((V)((x_1392 - (3D * q_1394)))))).S(" ").V(Call(r2_20, V.Undef, ((V)(y_1393)))).S("l").V(Call(r2_20, V.Undef, ((V)((2D * q_1394))))).S(" ").V(Call(r2_20, V.Undef, ((V)(((-7D) * q_1394))))).S("l").V(Call(r2_20, V.Undef, ((V)((2D * q_1394))))).S(" ").V(Call(r2_20, V.Undef, ((V)((5D * q_1394))))).S("l").V(Call(r2_20, V.Undef, ((V)((2D * q_1394))))).S(" ").V(Call(r2_20, V.Undef, ((V)(((-8D) * q_1394))))).S("l").V(Call(r2_20, V.Undef, ((V)((2D * q_1394))))).S(" ").V(Call(r2_20, V.Undef, ((V)((8D * q_1394))))).S("Z\" fill=\"#4f9a3e\" opacity=\"0.55\"/>");
i_1390++;
}
}
Invoke(Arr(Arr(((V)(60D)), ((V)(214D))), Arr(((V)(200D)), ((V)(212D))), Arr(((V)(470D)), ((V)(213D))), Arr(((V)(600D)), ((V)(214D))), Arr(((V)(720D)), ((V)(212D)))), "forEach", Fn((V _arrowThis1407, int _argc1395, V _a1397, V i_1401, V _a1399, V _a1400, V[] _rest1396) => {
V x_1404 = default;
V y_1406 = default;
{ V _t1402 = ListOf(_a1397);
{ V _t1403 = GetIdx(_t1402, 0D);
x_1404 = _t1403; }
{ V _t1405 = GetIdx(_t1402, 1D);
y_1406 = _t1405; }
}
{
double j_1408 = 0;
j_1408 = 0D;
while (true) {
if (!((j_1408 < 6D))) break;
double fx_1410 = 0;
double fy_1411 = 0;
fx_1410 = (ToNum(Add(x_1404, ((V)((j_1408 * 9D))))) - 22D);
fy_1411 = ((ToNum(y_1406) - 6D) - ((j_1408 % 2D) * 5D));
b_1220.S("<path d=\"M").N(fx_1410).S(" ").V(Add(y_1406, ((V)(2D)))).S("V").N(fy_1411).S("\" stroke=\"#4f9a3e\" stroke-width=\"1.6\"/><circle cx=\"").N(fx_1410).S("\" cy=\"").N(fy_1411).S("\" r=\"3.2\" fill=\"").V(GetIdx(Arr(((V)("#ff8fc8")), ((V)("#fff3a8")), ((V)("#ffffff")), ((V)("#d9c8ff")), ((V)("#ffb0a0"))), (ToNum(Add(i_1401, ((V)(j_1408)))) % 5D))).S("\"/>");
j_1408++;
}
}
return default;
}, 2, "", true));
b_1220.S("<g transform=\"translate(250 350) rotate(-4)\"><rect x=\"-46\" y=\"-12\" width=\"92\" height=\"26\" rx=\"4\" fill=\"#ffffff\"/><path d=\"M-46 -6H46M-46 4H46\" stroke=\"#ff7a8a\" stroke-width=\"5\"/></g><g fill=\"#ffd84a\" stroke=\"#d09a20\" stroke-width=\"1.2\"><ellipse cx=\"36\" cy=\"350\" rx=\"9\" ry=\"4.5\"/><ellipse cx=\"56\" cy=\"353\" rx=\"9\" ry=\"4.5\"/></g>");
b_1220.S("<path d=\"M-10 300C40 312 70 290 110 296S196 262 212 240\" fill=\"none\" stroke=\"#3a9a4a\" stroke-width=\"6\" stroke-linecap=\"round\"/><path d=\"M-10 300C40 312 70 290 110 296S196 262 212 240\" fill=\"none\" stroke=\"#6fcf6a\" stroke-width=\"2\" stroke-linecap=\"round\" opacity=\"0.7\"/>");
b_1220.S("<g transform=\"translate(742 302)\"><path d=\"M-44 0V-10M44 0V-10M-44 -10H18L40 -38\" stroke=\"#e8e0d4\" stroke-width=\"3.4\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"M-42 -14H18L38 -40\" stroke=\"#5cb8ff\" stroke-width=\"9\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/></g>");
b_1220.V(Call(ell_1219, V.Undef, ((V)((PX_1211 + 6D))), ((V)(((PY_1212 + (3D * TB_1215)) + 6D))), ((V)((RX_1213 + 18D))), ((V)((RY_1214 * 0.7))), ((V)("fill=\"#2a4a20\" opacity=\"0.22\""))));
b_1220.S("<path d=\"M").N((PX_1211 - RX_1213)).S(" ").N(PY_1212).S("A").N(RX_1213).S(" ").N(RY_1214).S(" 0 1 1 ").N((PX_1211 + RX_1213)).S(" ").N(PY_1212).S("A").N(RX_1213).S(" ").N(RY_1214).S(" 0 1 1 ").N((PX_1211 - RX_1213)).S(" ").N(PY_1212).S("Z\" fill=\"#3f9af0\"/>").V(Call(ell_1219, V.Undef, ((V)(PX_1211)), ((V)((PY_1212 - 3D))), ((V)((RX_1213 - 9D))), ((V)((RY_1214 - 4D))), ((V)("fill=\"none\" stroke=\"#9ad6ff\" stroke-width=\"3\" opacity=\"0.6\""))));
b_1220.V(Call(ell_1219, V.Undef, ((V)(PX_1211)), ((V)((PY_1212 + 2D))), ((V)((RX_1213 - IR_1216))), ((V)((RY_1214 - 7D))), ((V)("fill=\"#1b5fae\""))));
water_1222 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V);
Set(water_1222, "innerHTML", ((V)(JsStrBuf.Begin().V(Add(Call(ell_1219, V.Undef, ((V)(PX_1211)), ((V)(WY_1217)), ((V)(((RX_1213 - IR_1216) - 3D))), ((V)((RY_1214 - 13D))), ((V)("fill=\"url(#ygpW)\""))), Invoke(Invoke(Arr(Arr(((V)((-70D))), ((V)((-4D)))), Arr(((V)(40D)), ((V)(6D))), Arr(((V)((-10D))), ((V)((-8D)))), Arr(((V)(80D)), ((V)((-2D)))), Arr(((V)((-40D))), ((V)(8D)))), "map", Fn((V _arrowThis1424, int _argc1412, V _a1414, V i_1418, V _a1416, V _a1417, V[] _rest1413) => {
V x_1421 = default;
V y_1423 = default;
{ V _t1419 = ListOf(_a1414);
{ V _t1420 = GetIdx(_t1419, 0D);
x_1421 = _t1420; }
{ V _t1422 = GetIdx(_t1419, 1D);
y_1423 = _t1422; }
}
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N((ToNum(Add(((V)(PX_1211)), x_1421)) - 16D)).S(" ").V(Add(((V)(WY_1217)), y_1423)).S("q8 -4 16 0t16 0\" stroke=\"#ffffff\" stroke-width=\"2\" fill=\"none\" opacity=\"0.6\" stroke-linecap=\"round\" class=\"ygs-bob\" style=\"animation-delay:").N((ToNum(i_1418) * 0.3)).S("s\"/>").End()));
}, 2, "", true)), "join", ((V)(""))))).S("<g opacity=\"0.35\" transform=\"translate(").N((PX_1211 + 60D)).S(" ").N((WY_1217 + 4D)).S(")\"><path d=\"M-4.2 0Q-1 -3 3 0Q-1 3 -4.2 0Z\" fill=\"#ff8a3a\" transform=\"scale(1.6)\"/></g><g opacity=\"0.35\" transform=\"translate(").N((PX_1211 - 90D)).S(" ").N((WY_1217 + 2D)).S(") scale(1.5)\"><path d=\"M0 -3.6L1 -1.2L3.5 -1.1L1.5 0.6L2.2 3.1L0 1.7L-2.2 3.1L-1.5 0.6L-3.5 -1.1L-1 -1.2Z\" fill=\"#ffd23a\"/></g>").End())));
duck_1223 = ((V)("<g class=\"ygs-bob\"><ellipse cx=\"0\" cy=\"2\" rx=\"13\" ry=\"4\" fill=\"#1a5fb0\" opacity=\"0.25\"/><path d=\"M-12 -2Q-12 -12 0 -12Q8 -12 10 -6Q12 -2 6 0H-8Q-12 0 -12 -2Z\" fill=\"#ffd84a\" stroke=\"#d09a20\" stroke-width=\"1.2\"/><circle cx=\"4\" cy=\"-17\" r=\"7\" fill=\"#ffd84a\" stroke=\"#d09a20\" stroke-width=\"1.2\"/><path d=\"M10 -17l6 1l-6 3Z\" fill=\"#ff8a3a\"/><circle cx=\"6\" cy=\"-19\" r=\"1.3\" fill=\"#2a1a10\"/><path d=\"M-8 -6q5 -3 9 0\" stroke=\"#e8b82a\" stroke-width=\"1.5\" fill=\"none\"/></g>"));
ballS_1224 = ((V)("<g class=\"ygs-bob\" style=\"animation-delay:.6s\"><circle cy=\"-10\" r=\"11\" fill=\"#ffffff\" stroke=\"#c8c0b4\" stroke-width=\"1.2\"/><path d=\"M0 -21A11 11 0 0 1 11 -10L0 -10Z\" fill=\"#ff7a8a\"/><path d=\"M0 1A11 11 0 0 1 -11 -10L0 -10Z\" fill=\"#5cb8ff\"/><path d=\"M-11 -10A11 11 0 0 1 0 -21L0 -10Z\" fill=\"#ffd84a\"/></g>"));
duckG_1225 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N((PX_1211 - 112D)).S(" ").N((WY_1217 + 2D)).S(")").End()))).V);
ballG_1226 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N((PX_1211 + 122D)).S(" ").N((WY_1217 + 2D)).S(")").End()))).V);
Set(duckG_1225, "innerHTML", duck_1223);
Set(ballG_1226, "innerHTML", ballS_1224);
Set(scB_574, "innerHTML", ((V)(b_1220.Str)));
Invoke(scB_574, "appendChild", water_1222);
YW_1227 = (WY_1217 + 2D);
splG_1228 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, scF_580);
wc_1229 = Call(S_17, V.Undef, ((V)("clipPath")), NewObj(1).Put("id", ((V)("ygpWc"))).V, scF_580);
Call(S_17, V.Undef, ((V)("rect")), NewObj(4).Put("x", ((V)((-20D)))).Put("y", ((V)(YW_1227))).Put("width", Add(W_563, ((V)(40D)))).Put("height", H_564).V, wc_1229);
waterF_1230 = Invoke(water_1222, "cloneNode", (true ? V.True : V.False));
Invoke(waterF_1230, "setAttribute", ((V)("clip-path")), ((V)("url(#ygpWc)")));
Invoke(scF_580, "appendChild", waterF_1230);
ringG_1231 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, scF_580);
rings_1232 = Invoke(Arr(((V)(LX_1218)), ((V)(506D))), "map", Fn((V _arrowThis1432, int _argc1425, V x_1431, V _a1428, V _a1429, V _a1430, V[] _rest1426) => {
return Call(S_17, V.Undef, ((V)("ellipse")), NewObj(9).Put("cx", x_1431).Put("cy", ((V)((YW_1227 + 1D)))).Put("rx", ((V)(32D))).Put("ry", ((V)(6.5))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).Put("opacity", ((V)(0D))).Put("class", ((V)("ygs-bob"))).V, ringG_1231);
}, 1, "", true));
Invoke(scF_580, "appendChild", duckG_1225);
Invoke(scF_580, "appendChild", ballG_1226);
front_1233 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, scF_580);
spillG_1234 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, scF_580);
f_1235 = new JsStrBuf("");
f_1235.S("<path d=\"M").N((PX_1211 - RX_1213)).S(" ").N(PY_1212).S("A").N(RX_1213).S(" ").N(RY_1214).S(" 0 0 0 ").N((PX_1211 + RX_1213)).S(" ").N(PY_1212).S("L").N(((PX_1211 + RX_1213) - IR_1216)).S(" ").N((PY_1212 + 2D)).S("A").N((RX_1213 - IR_1216)).S(" ").N((RY_1214 - 7D)).S(" 0 0 1 ").N(((PX_1211 - RX_1213) + IR_1216)).S(" ").N((PY_1212 + 2D)).S("Z\" fill=\"#3f9af0\"/>");
f_1235.S("<path d=\"M").N(((PX_1211 - RX_1213) + 8D)).S(" ").N((PY_1212 + 6D)).S("A").N((RX_1213 - 8D)).S(" ").N((RY_1214 - 2D)).S(" 0 0 0 ").N(((PX_1211 + RX_1213) - 8D)).S(" ").N((PY_1212 + 6D)).S("\" fill=\"none\" stroke=\"#9ad6ff\" stroke-width=\"3\" opacity=\"0.7\"/>");
Invoke(Arr(Arr(((V)("url(#ygpBl)")), ((V)(0D))), Arr(((V)("url(#ygpWt)")), ((V)(1D))), Arr(((V)("url(#ygpBl)")), ((V)(2D)))), "forEach", Fn((V _arrowThis1444, int _argc1433, V _a1435, V _a1436, V _a1437, V _a1438, V[] _rest1434) => {
double yt_1445 = 0;
double yb_1446 = 0;
V c_1441 = default;
V j_1443 = default;
{ V _t1439 = ListOf(_a1435);
{ V _t1440 = GetIdx(_t1439, 0D);
c_1441 = _t1440; }
{ V _t1442 = GetIdx(_t1439, 1D);
j_1443 = _t1442; }
}
yt_1445 = ((PY_1212 + 4D) + (ToNum(j_1443) * TB_1215));
yb_1446 = (yt_1445 + TB_1215);
f_1235.S("<path d=\"M").N((PX_1211 - RX_1213)).S(" ").N(yt_1445).S("A").N(RX_1213).S(" ").N(RY_1214).S(" 0 0 0 ").N((PX_1211 + RX_1213)).S(" ").N(yt_1445).S("L").N((PX_1211 + RX_1213)).S(" ").N(yb_1446).S("A").N(RX_1213).S(" ").N(RY_1214).S(" 0 0 1 ").N((PX_1211 - RX_1213)).S(" ").N(yb_1446).S("Z\" fill=\"").V(c_1441).S("\" stroke=\"").S((SEqN(j_1443, 1D) ? "#c9d6e6" : "#1a5fb0")).S("\" stroke-width=\"1\"/>").S("<circle cx=\"").N((PX_1211 - RX_1213)).S("\" cy=\"").N((yt_1445 + (TB_1215 / 2D))).S("\" r=\"").N((TB_1215 / 2D)).S("\" fill=\"").V(c_1441).S("\"/><circle cx=\"").N((PX_1211 + RX_1213)).S("\" cy=\"").N((yt_1445 + (TB_1215 / 2D))).S("\" r=\"").N((TB_1215 / 2D)).S("\" fill=\"").V(c_1441).S("\"/>").S("<path d=\"M").N(((PX_1211 - RX_1213) + 12D)).S(" ").N((yt_1445 + 5D)).S("A").N((RX_1213 - 12D)).S(" ").N(RY_1214).S(" 0 0 0 ").N(((PX_1211 + RX_1213) - 12D)).S(" ").N((yt_1445 + 5D)).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"2.6\" opacity=\"").N((SEqN(j_1443, 1D) ? 0.9 : 0.45)).S("\"/>");
return default;
}, 1, "", true));
Invoke(Arr(((V)((-0.75))), ((V)((-0.42))), ((V)((-0.1))), ((V)(0.22)), ((V)(0.55)), ((V)(0.85))), "forEach", Fn((V _arrowThis1455, int _argc1447, V u_1453, V i_1454, V _a1451, V _a1452, V[] _rest1448) => {
double x_1456 = 0;
double y_1457 = 0;
double sc_1458 = 0;
x_1456 = (PX_1211 + ((ToNum(u_1453) * RX_1213) * 0.92));
y_1457 = (((PY_1212 + 4D) + (TB_1215 * 1.5)) + ((RY_1214 * System.Math.Sqrt((1D - ((ToNum(u_1453) * ToNum(u_1453)) * 0.85)))) * 0.98));
sc_1458 = (1.25 * System.Math.Sqrt((1D - ((ToNum(u_1453) * ToNum(u_1453)) * 0.7))));
f_1235.S("<g transform=\"translate(").V(Call(r2_20, V.Undef, ((V)(x_1456)))).S(" ").V(Call(r2_20, V.Undef, ((V)(y_1457)))).S(") scale(").V(Call(r2_20, V.Undef, ((V)(sc_1458)))).S(")\">").S((NumTruthy((ToNum(i_1454) % 2D)) ? "<path d=\"M0 -3.6L1 -1.2L3.5 -1.1L1.5 0.6L2.2 3.1L0 1.7L-2.2 3.1L-1.5 0.6L-3.5 -1.1L-1 -1.2Z\" fill=\"#ffd23a\" stroke=\"#e8a81a\" stroke-width=\"0.3\"/>" : "<path d=\"M-4.2 0Q-1 -3 3 0Q-1 3 -4.2 0Z\" fill=\"#ff8a3a\"/><path d=\"M2.6 0L5.6 -2.2V2.2Z\" fill=\"#ff8a3a\"/><circle cx=\"-2.2\" cy=\"-0.5\" r=\"0.45\" fill=\"#1d2a3a\"/>")).S("</g>");
return default;
}, 2, "", true));
f_1235.S("<circle cx=\"").N((PX_1211 + (RX_1213 * 0.7))).S("\" cy=\"").N((((PY_1212 + 4D) + (TB_1215 * 0.5)) + (RY_1214 * 0.7))).S("\" r=\"2.6\" fill=\"#f6f9fc\" stroke=\"#9aa1ad\" stroke-width=\"0.8\"/>");
Set(front_1233, "innerHTML", ((V)(f_1235.Str)));
spots_1236 = Arr(NewObj(4).Put("x", ((V)(136D))).Put("y", ((V)(342D))).Put("side", ((V)((-1D)))).Put("in", ((V)(0D))).V, NewObj(4).Put("x", ((V)(650D))).Put("y", ((V)(342D))).Put("side", ((V)(1D))).Put("in", ((V)(0D))).V, NewObj(4).Put("x", ((V)(506D))).Put("y", ((V)((WY_1217 + 36D)))).Put("side", ((V)(1D))).Put("in", ((V)(1D))).V);
Invoke(friends_629, "forEach", Fn((V _arrowThis1467, int _argc1459, V fr_1465, V i_1466, V _a1463, V _a1464, V[] _rest1460) => {
return Object_assign(fr_1465, GetK(spots_1236, i_1466), NewObj(8).Put("size", ((V)(128D))).Put("wet", ((V)(0D))).Put("hitAt", ((V)(double.PositiveInfinity))).Put("knock", ((V)(0D))).Put("rot", ((V)(0D))).Put("dx", ((V)(0D))).Put("dy", ((V)(0D))).Put("dripT", ((V)(0D))).V);
}, 2, "", true));
Invoke(friends_629, "forEach", Fn((V _arrowThis1475, int _argc1468, V fr_1474, V _a1471, V _a1472, V _a1473, V[] _rest1469) => {
Invoke(Get(fr_1474, "c"), "hide", (false ? V.True : V.False));
Invoke(Get(fr_1474, "c"), "yaw", ((V)((Truthy(Get(fr_1474, "in")) ? 0D : (LtN(Get(fr_1474, "side"), 0D) ? 22D : (-22D))))));
Invoke(Get(fr_1474, "c"), "set", Get(fr_1474, "x"), Get(fr_1474, "y"), Get(fr_1474, "size"));
Invoke(Get(fr_1474, "c"), "depth", ((V)(0D)));
Invoke(Get(fr_1474, "c"), "play", ((V)("idle")));
return default;
}, 1, "", true));
Invoke(me_624, "yaw", ((V)(0D)));
Invoke(me_624, "rot", ((V)(0D)));
Invoke(me_624, "depth", ((V)(0D)));
Invoke(me_624, "hide", (false ? V.True : V.False));
Invoke(me_624, "play", ((V)("idle")));
Invoke(GetIdx(rings_1232, 1D), "setAttribute", ((V)("opacity")), ((V)(0.85)));
T0p_1237 = tNow_628;
fallAt_1238 = Add(T0p_1237, ((V)(380D)));
hitAt_1239 = Add(fallAt_1238, ((V)(560D)));
fx_1240 = NewObj(4).Put("ring", Arr()).Put("drop", Arr()).Put("sheets", Arr()).Put("spills", Arr()).V;
hit_1241 = (false ? V.True : V.False);
col_1242 = Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M-").V(Call(r2_20, V.Undef, ((V)((16D + (14D * ToNum(k_1207))))))).S(" 0C-").V(Call(r2_20, V.Undef, ((V)((18D + (16D * ToNum(k_1207))))))).S(" -55 -9 -96 0 -100C9 -96 ").V(Call(r2_20, V.Undef, ((V)((18D + (16D * ToNum(k_1207))))))).S(" -55 ").V(Call(r2_20, V.Undef, ((V)((16D + (14D * ToNum(k_1207))))))).S(" 0Z").End()))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0D))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N(LX_1218).S(" ").N(WY_1217).S(")").End()))).V, splG_1228);
jets_1243 = Arr();
nj_1244 = (2D + Round((6D * ToNum(k_1207))));
{
double j_1476 = 0;
j_1476 = 0D;
while (true) {
if (!((j_1476 < nj_1244))) break;
double a_1478 = 0;
double w_1479 = 0;
double lx_1480 = 0;
double hj_1481 = 0;
a_1478 = (((j_1476 / ToNum((((V)((nj_1244 - 1D))) is var _t1482 && Truthy(_t1482) ? _t1482 : ((V)(1D))))) - 0.5) * 2D);
w_1479 = (5D + (5D * ToNum(k_1207)));
lx_1480 = (a_1478 * (50D + (120D * ToNum(k_1207))));
hj_1481 = (((40D + (190D * ToNum(k_1207))) * (0.6 + (0.4 * System.Math.Abs(FdLibm.Sin(((j_1476 * 1.9) + 0.5)))))) / 100D);
Invoke(jets_1243, "push", NewObj(3).Put("e", Call(S_17, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((-w_1479))))).S(" 0C").V(Call(r2_20, V.Undef, ((V)((-w_1479))))).S(" -55 ").V(Call(r2_20, V.Undef, ((V)((lx_1480 - 5D))))).S(" -94 ").V(Call(r2_20, V.Undef, ((V)(lx_1480)))).S(" -100C").V(Call(r2_20, V.Undef, ((V)((lx_1480 + 5D))))).S(" -94 ").V(Call(r2_20, V.Undef, ((V)(w_1479)))).S(" -55 ").V(Call(r2_20, V.Undef, ((V)(w_1479)))).S(" 0Z").End()))).Put("fill", ((V)("#e6f8ff"))).Put("stroke", ((V)("#a8e0ff"))).Put("stroke-width", ((V)(1.2))).Put("opacity", ((V)(0D))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N(LX_1218).S(" ").N(WY_1217).S(")").End()))).V, splG_1228)).Put("hj", ((V)(hj_1481))).Put("dl", ((V)((0.03 + (System.Math.Abs(a_1478) * 0.07))))).V);
j_1476++;
}
}
crown_1245 = Call(S_17, V.Undef, ((V)("g")), NewObj(2).Put("opacity", ((V)(0D))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N(LX_1218).S(" ").N(WY_1217).S(")").End()))).V, splG_1228);
{
JsStrBuf cd_1483 = null;
double n_1484 = 0;
double cr_1485 = 0;
cd_1483 = new JsStrBuf("");
n_1484 = Round((12D + (10D * ToNum(k_1207))));
cr_1485 = (26D + (34D * ToNum(k_1207)));
{
double i_1486 = 0;
i_1486 = 0D;
while (true) {
if (!((i_1486 < n_1484))) break;
double a_1488 = 0;
double x_1489 = 0;
double y_1490 = 0;
double hh_1491 = 0;
double lean_1492 = 0;
a_1488 = ((i_1486 / n_1484) * ToNum(TAU_22));
x_1489 = (FdLibm.Cos(a_1488) * cr_1485);
y_1490 = ((FdLibm.Sin(a_1488) * cr_1485) * 0.22);
hh_1491 = ((24D + (80D * ToNum(k_1207))) * (0.6 + (0.4 * FdLibm.Sin(((i_1486 * 2.3) + 1D)))));
lean_1492 = (FdLibm.Cos(a_1488) * (10D + (30D * ToNum(k_1207))));
if ((FdLibm.Sin(a_1488) < (-0.3))) {
goto _cont1487;
}
cd_1483.S("M").V(Call(r2_20, V.Undef, ((V)((x_1489 - 6D))))).S(" ").V(Call(r2_20, V.Undef, ((V)(y_1490)))).S("Q").V(Call(r2_20, V.Undef, ((V)((x_1489 + (lean_1492 * 0.4)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((y_1490 - (hh_1491 * 0.6)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((x_1489 + lean_1492))))).S(" ").V(Call(r2_20, V.Undef, ((V)((y_1490 - hh_1491))))).S("Q").V(Call(r2_20, V.Undef, ((V)(((x_1489 + (lean_1492 * 0.5)) + 3D))))).S(" ").V(Call(r2_20, V.Undef, ((V)((y_1490 - (hh_1491 * 0.5)))))).S(" ").V(Call(r2_20, V.Undef, ((V)((x_1489 + 6D))))).S(" ").V(Call(r2_20, V.Undef, ((V)(y_1490)))).S("Z");
_cont1487: ;
i_1486++;
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)(cd_1483.Str))).Put("fill", ((V)("#e6f8ff"))).Put("stroke", ((V)("#8fd6ff"))).Put("stroke-width", ((V)(1.5))).Put("stroke-linejoin", ((V)("round"))).V, crown_1245);
}
{
double i_1493 = 0;
i_1493 = 0D;
while (true) {
if (!((i_1493 < 4D))) break;
Invoke(Get(fx_1240, "ring"), "push", Call(S_17, V.Undef, ((V)("ellipse")), NewObj(8).Put("cx", ((V)(LX_1218))).Put("cy", ((V)(WY_1217))).Put("rx", ((V)(1D))).Put("ry", ((V)(1D))).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)((3D - (i_1493 * 0.5))))).Put("opacity", ((V)(0D))).V, splG_1228));
i_1493++;
}
}
Invoke(Invoke(friends_629, "filter", Fn((V _arrowThis1518, int _argc1511, V fr_1517, V _a1514, V _a1515, V _a1516, V[] _rest1512) => {
return (!(Truthy(Get(fr_1517, "in"))) ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis1502, int _argc1495, V fr_1501, V _a1498, V _a1499, V _a1500, V[] _rest1496) => {
V e0_1503 = default;
V e_1504 = default;
V x1_1505 = default;
double y1_1506 = 0;
double mx_1507 = 0;
double my_1508 = 0;
V dd_1509 = default;
V len_1510 = default;
if (LtN(k_1207, 0.3)) {
return default;
}
e0_1503 = Call(S_17, V.Undef, ((V)("path")), NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)((10D + (16D * ToNum(k_1207))))))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0D))).Put("stroke-dasharray", ((V)("1 999"))).V, splG_1228);
e_1504 = Call(S_17, V.Undef, ((V)("path")), NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#8fd8ff"))).Put("stroke-width", Call(r2_20, V.Undef, ((V)((6D + (12D * ToNum(k_1207))))))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0D))).Put("stroke-dasharray", ((V)("1 999"))).V, splG_1228);
x1_1505 = Add(Get(fr_1501, "x"), ((V)((ToNum(Get(fr_1501, "side")) * 10D))));
y1_1506 = (ToNum(Get(fr_1501, "y")) - 50D);
mx_1507 = (ToNum(Add(((V)(LX_1218)), x1_1505)) / 2D);
my_1508 = ((Min(WY_1217, y1_1506) - 60D) - (80D * ToNum(k_1207)));
dd_1509 = ((V)(JsStrBuf.Begin().S("M").N(LX_1218).S(" ").N(WY_1217).S("Q").V(Call(r2_20, V.Undef, ((V)(mx_1507)))).S(" ").V(Call(r2_20, V.Undef, ((V)(my_1508)))).S(" ").V(Call(r2_20, V.Undef, x1_1505)).S(" ").V(Call(r2_20, V.Undef, ((V)(y1_1506)))).End()));
Invoke(e_1504, "setAttribute", ((V)("d")), dd_1509);
Invoke(e0_1503, "setAttribute", ((V)("d")), dd_1509);
len_1510 = (Truthy(Get(e_1504, "getTotalLength")) ? Invoke(e_1504, "getTotalLength") : ((V)(400D)));
Invoke(Get(fx_1240, "sheets"), "push", NewObj(3).Put("e", e_1504).Put("len", len_1510).Put("fr", fr_1501).V, NewObj(3).Put("e", e0_1503).Put("len", len_1510).Put("fr", fr_1501).V);
return default;
}, 1, "", true));
if (GeN(k_1207, 0.5)) {
Invoke(Invoke(Arr(((V)((-0.62))), ((V)((-0.2))), ((V)(0.3)), ((V)(0.7))), "slice", ((V)(0D)), ((V)((GtN(k_1207, 0.85) ? 4D : 2D)))), "forEach", Fn((V _arrowThis1527, int _argc1519, V u_1525, V i_1526, V _a1523, V _a1524, V[] _rest1520) => {
double x_1528 = 0;
double y0_1529 = 0;
V e_1530 = default;
V pd_1531 = default;
x_1528 = (PX_1211 + (ToNum(u_1525) * RX_1213));
y0_1529 = ((PY_1212 + 4D) + ((RY_1214 * System.Math.Sqrt((1D - (ToNum(u_1525) * ToNum(u_1525))))) * 0.95));
e_1530 = Call(S_17, V.Undef, ((V)("path")), NewObj(7).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, ((V)((x_1528 - 9D))))).S(" ").V(Call(r2_20, V.Undef, ((V)(y0_1529)))).S("Q").V(Call(r2_20, V.Undef, ((V)((x_1528 - 12D))))).S(" ").V(Call(r2_20, V.Undef, ((V)((y0_1529 + 26D))))).S(" ").V(Call(r2_20, V.Undef, ((V)((x_1528 - 7D))))).S(" ").V(Call(r2_20, V.Undef, ((V)((y0_1529 + 46D))))).S("H").V(Call(r2_20, V.Undef, ((V)((x_1528 + 7D))))).S("Q").V(Call(r2_20, V.Undef, ((V)((x_1528 + 12D))))).S(" ").V(Call(r2_20, V.Undef, ((V)((y0_1529 + 26D))))).S(" ").V(Call(r2_20, V.Undef, ((V)((x_1528 + 9D))))).S(" ").V(Call(r2_20, V.Undef, ((V)(y0_1529)))).S("Z").End()))).Put("fill", ((V)("#9fe0ff"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.4))).Put("opacity", ((V)(0D))).Put("transform", ((V)("scale(1 0.01)"))).Put("transform-origin", ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, ((V)(x_1528)))).S("px ").V(Call(r2_20, V.Undef, ((V)(y0_1529)))).S("px").End()))).V, spillG_1234);
pd_1531 = Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_20, V.Undef, ((V)(x_1528)))).Put("cy", Call(r2_20, V.Undef, ((V)((y0_1529 + 50D))))).Put("rx", ((V)(1D))).Put("ry", ((V)(1D))).Put("fill", ((V)("#8fd6ff"))).Put("opacity", ((V)(0.7))).V, spillG_1234);
Invoke(Get(fx_1240, "spills"), "push", NewObj(3).Put("e", e_1530).Put("pd", pd_1531).Put("dl", ((V)((0.12 + (ToNum(i_1526) * 0.07))))).V);
return default;
}, 2, "", true));
}
Invoke(friends_629, "forEach", Fn((V _arrowThis1539, int _argc1532, V fr_1538, V _a1535, V _a1536, V _a1537, V[] _rest1533) => {
Set(fr_1538, "pud", Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Get(fr_1538, "x")).Put("cy", (Truthy(Get(fr_1538, "in")) ? ((V)((-99D))) : Add(Get(fr_1538, "y"), ((V)(2D))))).Put("rx", ((V)(1D))).Put("ry", ((V)(1D))).Put("fill", ((V)("#8fd6ff"))).Put("opacity", ((V)(0.75))).V));
Invoke(scB_574, "insertBefore", Get(fr_1538, "pud"), water_1222);
Set(fr_1538, "slap", Call(S_17, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)("M-30 10C-40 -30 -20 -70 0 -76C20 -70 40 -30 30 10C14 -2 -14 -2 -30 10Z"))).Put("fill", ((V)("#bfeaff"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2D))).Put("opacity", ((V)(0D))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Get(fr_1538, "x")).S(" ").N((ToNum(Get(fr_1538, "y")) - 40D)).S(")").End()))).V, scF_580));
return default;
}, 1, "", true));
shakeG_1246 = Arr(scB_574, scF_580);
return NewObj(1).Put("update", Fn((V _self1540, int _argc1541, V dt_1547, V t_1548, V _a1545, V _a1546, V[] _rest1542) => {
double ts_1549 = 0;
if (_self1540.IsNullish) _self1540 = GlobalV;
ts_1549 = ((ToNum(t_1548) - ToNum(T0p_1237)) / 1000D);
if (!(Truthy(hit_1241))) {
V u_1550 = default;
V y_1551 = default;
u_1550 = Call(cl_18, V.Undef, ((V)(((ToNum(t_1548) - ToNum(fallAt_1238)) / (ToNum(hitAt_1239) - ToNum(fallAt_1238))))), ((V)(0D)), ((V)(1D)));
y_1551 = Call(lerp_19, V.Undef, ((V)((-100D))), ((V)((WY_1217 + 48D))), ((V)((ToNum(u_1550) * ToNum(u_1550)))));
Invoke(me_624, "set", ((V)(LX_1218)), y_1551, ((V)(128D)));
Invoke(me_624, "rot", ((V)((GeN(v_1208, 75D) ? (ToNum(u_1550) * 540D) : 0D))), ((V)(50D)), ((V)(62D)));
Invoke(me_624, "pose", (GeN(v_1208, 75D) ? NewObj(7).Put("sit", ((V)(1D))).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("sq", ((V)(0.08))).Put("close", ((V)(0.4))).Put("open", ((V)(0.6))).Put("hap", ((V)(1D))).V : NewObj(6).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).Put("open", ((V)(0.9))).Put("hap", ((V)(1D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V));
Invoke(me_624, "hide", (Lt(t_1548, fallAt_1238) ? V.True : V.False));
if (Ge(t_1548, hitAt_1239)) {
hit_1241 = (true ? V.True : V.False);
Call(boom_1247, V.Undef, t_1548);
}
} else {
double u_1552 = 0;
u_1552 = ((ToNum(t_1548) - ToNum(hitAt_1239)) / 1000D);
Invoke(me_624, "rot", ((V)(0D)));
Invoke(GetIdx(rings_1232, 0D), "setAttribute", ((V)("opacity")), ((V)(((u_1552 < 0.38) ? 0D : 0.85))));
if ((u_1552 < 0.38)) {
Invoke(me_624, "hide", (true ? V.True : V.False));
} else {
Invoke(me_624, "hide", (false ? V.True : V.False));
Invoke(me_624, "set", ((V)(LX_1218)), ((V)((((WY_1217 + 36D) + (FdLibm.Sin((u_1552 * 3D)) * 2D)) + ((u_1552 < 0.6) ? ((0.6 - u_1552) * 60D) : 0D)))), ((V)(128D)));
Invoke(me_624, "pose", NewObj(6).Put("sit", ((V)(1D))).Put("armL", ((V)((130D + (30D * FdLibm.Sin((u_1552 * 7D))))))).Put("armR", ((V)((130D - (30D * FdLibm.Sin((u_1552 * 7D))))))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).V);
}
}
if (Truthy(hit_1241)) {
double u_1553 = 0;
double ch_1554 = 0;
double hc_1555 = 0;
V cu_1556 = default;
V cf_1557 = default;
V wy_1558 = default;
double sh_1559 = 0;
double sx_1560 = 0;
double sy_1561 = 0;
u_1553 = ((ToNum(t_1548) - ToNum(hitAt_1239)) / 1000D);
ch_1554 = ((u_1553 < 0.28) ? FdLibm.Sin((((u_1553 / 0.28) * System.Math.PI) / 2D)) : Max(0D, (1D - ((u_1553 - 0.28) / (0.6 + (0.5 * ToNum(k_1207)))))));
hc_1555 = ((60D + (270D * ToNum(k_1207))) / 100D);
Invoke(col_1242, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").N(LX_1218).S(" ").N(WY_1217).S(") scale(").V(Call(r2_20, V.Undef, ((V)((1D + ((0.4 * ToNum(k_1207)) * (1D - ch_1554))))))).S(" ").V(Call(r2_20, V.Undef, ((V)(Max(0.01, (ch_1554 * hc_1555)))))).S(")").End())));
Invoke(col_1242, "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)((0.95 * Min(1D, (ch_1554 * 2.5)))))));
Invoke(jets_1243, "forEach", Fn((V _arrowThis1569, int _argc1562, V j_1568, V _a1565, V _a1566, V _a1567, V[] _rest1563) => {
double w_1570 = 0;
double c2_1571 = 0;
w_1570 = (u_1553 - ToNum(Get(j_1568, "dl")));
c2_1571 = ((w_1570 < 0D) ? 0D : ((w_1570 < 0.3) ? FdLibm.Sin((((w_1570 / 0.3) * System.Math.PI) / 2D)) : Max(0D, (1D - ((w_1570 - 0.3) / (0.55 + (0.45 * ToNum(k_1207))))))));
Invoke(Get(j_1568, "e"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").N(LX_1218).S(" ").N(WY_1217).S(") scale(1 ").V(Call(r2_20, V.Undef, ((V)(Max(0.01, (c2_1571 * ToNum(Get(j_1568, "hj")))))))).S(")").End())));
Invoke(Get(j_1568, "e"), "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)((0.88 * Min(1D, (c2_1571 * 2.5)))))));
return default;
}, 1, "", true));
cu_1556 = Call(cl_18, V.Undef, ((V)((u_1553 / 0.2))), ((V)(0D)), ((V)(1D)));
cf_1557 = ((u_1553 < 0.5) ? ((V)(1D)) : Call(cl_18, V.Undef, ((V)((1D - ((u_1553 - 0.5) / 0.45)))), ((V)(0D)), ((V)(1D))));
Invoke(crown_1245, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").N(LX_1218).S(" ").N(WY_1217).S(") scale(").V(Call(r2_20, V.Undef, ((V)((0.6 + (0.5 * ToNum(cu_1556))))))).S(" ").V(Call(r2_20, V.Undef, ((V)(Max(0.01, (ToNum(cu_1556) * ToNum(cf_1557))))))).S(")").End())));
Invoke(crown_1245, "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, cf_1557));
Invoke(Get(fx_1240, "ring"), "forEach", Fn((V _arrowThis1580, int _argc1572, V e_1578, V i_1579, V _a1576, V _a1577, V[] _rest1573) => {
double w_1581 = 0;
double r_1582 = 0;
w_1581 = (u_1553 - (ToNum(i_1579) * 0.15));
if ((w_1581 < 0D)) {
return default;
}
r_1582 = (14D + (((RX_1213 - IR_1216) - 20D) * (1D - FdLibm.Exp(((-w_1581) * 2.4)))));
Invoke(e_1578, "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)(r_1582))));
Invoke(e_1578, "setAttribute", ((V)("ry")), Call(r2_20, V.Undef, ((V)((r_1582 * 0.2)))));
Invoke(e_1578, "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)((ToNum(Call(cl_18, V.Undef, ((V)((1D - (w_1581 / 1.4)))), ((V)(0D)), ((V)(1D)))) * 0.85)))));
return default;
}, 2, "", true));
Invoke(Get(fx_1240, "sheets"), "forEach", Fn((V _arrowThis1590, int _argc1583, V q_1589, V _a1586, V _a1587, V _a1588, V[] _rest1584) => {
V w_1591 = default;
V fade_1592 = default;
w_1591 = Call(cl_18, V.Undef, ((V)(((u_1553 - 0.05) / 0.32))), ((V)(0D)), ((V)(1D)));
fade_1592 = Call(cl_18, V.Undef, ((V)((1D - ((u_1553 - 0.45) / 0.4)))), ((V)(0D)), ((V)(1D)));
Invoke(Get(q_1589, "e"), "setAttribute", ((V)("stroke-dasharray")), ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, ((V)((ToNum(Get(q_1589, "len")) * ToNum(w_1591)))))).S(" 999").End())));
Invoke(Get(q_1589, "e"), "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)((0.85 * ToNum(fade_1592))))));
return default;
}, 1, "", true));
Invoke(Get(fx_1240, "spills"), "forEach", Fn((V _arrowThis1600, int _argc1593, V q_1599, V _a1596, V _a1597, V _a1598, V[] _rest1594) => {
V w_1601 = default;
V fade_1602 = default;
w_1601 = Call(cl_18, V.Undef, ((V)(((u_1553 - ToNum(Get(q_1599, "dl"))) / 0.35))), ((V)(0D)), ((V)(1D)));
fade_1602 = Call(cl_18, V.Undef, ((V)((1D - ((u_1553 - 1.6) / 0.8)))), ((V)(0D)), ((V)(1D)));
Invoke(Get(q_1599, "e"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("scale(1 ").V(Call(r2_20, V.Undef, ((V)(Max(0.01, ToNum(w_1601)))))).S(")").End())));
Invoke(Get(q_1599, "e"), "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)((0.85 * ToNum(fade_1602))))));
Invoke(Get(q_1599, "pd"), "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)((4D + ((26D * ToNum(w_1601)) * ToNum(Add(((V)(0.5)), k_1207))))))));
Invoke(Get(q_1599, "pd"), "setAttribute", ((V)("ry")), Call(r2_20, V.Undef, ((V)((1D + ((5D * ToNum(w_1601)) * ToNum(Add(((V)(0.5)), k_1207))))))));
return default;
}, 1, "", true));
wy_1558 = ((V)(JsStrBuf.Begin().S("translate(0 ").V(Call(r2_20, V.Undef, ((V)((((FdLibm.Sin((u_1553 * 12D)) * ToNum(k_1207)) * 5D) * FdLibm.Exp(((-u_1553) * 1.6))))))).S(")").End()));
Invoke(water_1222, "setAttribute", ((V)("transform")), wy_1558);
Invoke(waterF_1230, "setAttribute", ((V)("transform")), wy_1558);
Invoke(Arr(duckG_1225, ballG_1226), "forEach", Fn((V _arrowThis1611, int _argc1603, V g_1609, V i_1610, V _a1607, V _a1608, V[] _rest1604) => {
double bx_1612 = 0;
double by_1613 = 0;
bx_1612 = ((((Truthy(i_1610) ? 1D : (-1D)) * 18D) * ToNum(k_1207)) * Min(1D, (u_1553 * 3D)));
by_1613 = (((-Max(0D, FdLibm.Sin((Min(1D, (u_1553 * 2.2)) * System.Math.PI)))) * (20D + (70D * ToNum(k_1207)))) * (GtN(k_1207, 0.4) ? 1D : 0.3));
Invoke(g_1609, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, ((V)(((Truthy(i_1610) ? (PX_1211 + 122D) : (PX_1211 - 112D)) + bx_1612))))).S(" ").V(Call(r2_20, V.Undef, ((V)(((WY_1217 + 2D) + by_1613))))).S(") rotate(").V(Call(r2_20, V.Undef, ((V)((by_1613 * (Truthy(i_1610) ? 2D : (-2D))))))).S(")").End())));
return default;
}, 2, "", true));
sh_1559 = (ToNum(Get(st_631, "shake")) * FdLibm.Exp(((-u_1553) * 4D)));
sx_1560 = ((ToNum(Invoke(G("Math"), "random")) - 0.5) * sh_1559);
sy_1561 = ((ToNum(Invoke(G("Math"), "random")) - 0.5) * sh_1559);
Invoke(shakeG_1246, "forEach", Fn((V _arrowThis1621, int _argc1614, V g_1620, V _a1617, V _a1618, V _a1619, V[] _rest1615) => {
return Invoke(g_1620, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, ((V)(sx_1560)))).S(" ").V(Call(r2_20, V.Undef, ((V)(sy_1561)))).S(")").End())));
}, 1, "", true));
}
Invoke(friends_629, "forEach", Fn((V _arrowThis1630, int _argc1622, V fr_1628, V i_1629, V _a1626, V _a1627, V[] _rest1623) => {
V c_1631 = default;
V E_1632 = default;
c_1631 = Get(fr_1628, "c");
E_1632 = NewObj(6).Put("ly", ((V)((-0.8)))).Put("lx", ((V)(((LX_1218 - ToNum(Get(fr_1628, "x"))) / 400D)))).Put("open", ((V)(0.4))).Put("armR", ((V)(110D))).Put("armL", ((V)(40D))).Put("smile", ((V)(0.6))).V;
if (Truthy(Get(fr_1628, "in"))) {
Set(E_1632, "sit", ((V)(1D)));
}
if (Truthy(hit_1241)) {
double u_1633 = 0;
double kn_1634 = 0;
u_1633 = ((ToNum(t_1548) - ToNum(Get(fr_1628, "hitAt"))) / 1000D);
if ((!(IsFiniteV(Get(fr_1628, "hitAt"))) || (u_1633 < 0D))) {
E_1632 = NewObj(7).Put("ly", ((V)((-0.3)))).Put("lx", ((V)(((LX_1218 - ToNum(Get(fr_1628, "x"))) / 300D)))).Put("open", ((V)(0.6))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("sq", ((V)(0.04))).Put("sit", ((V)((Truthy(Get(fr_1628, "in")) ? 1D : 0D)))).V;
} else {
if (LtN(k_1207, 0.3)) {
E_1632 = NewObj(6).Put("armL", ((V)((150D + (20D * FdLibm.Sin((u_1633 * 14D))))))).Put("armR", ((V)((150D - (20D * FdLibm.Sin((u_1633 * 14D))))))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.6))).Put("sit", ((V)((Truthy(Get(fr_1628, "in")) ? 1D : 0D)))).V;
} else {
double shake_1635 = 0;
shake_1635 = (((u_1633 > 1.3) && (u_1633 < 2.1)) ? ((FdLibm.Sin((u_1633 * 50D)) * 14D) * (1D - ((u_1633 - 1.3) / 0.8))) : 0D);
E_1632 = NewObj(9).Put("tilt", ((V)(shake_1635))).Put("sq", ((V)(((u_1633 < 0.25) ? 0.12 : 0.02)))).Put("armL", ((V)(((u_1633 < 1.2) ? 120D : 150D)))).Put("armR", ((V)(((u_1633 < 1.2) ? 120D : 150D)))).Put("open", ((V)(0.7))).Put("hap", ((V)(((u_1633 > 1.3) ? 1D : 0D)))).Put("smile", ((V)(((u_1633 > 1.3) ? 1D : 0D)))).Put("close", ((V)(((u_1633 < 0.5) ? 0.8 : 0D)))).Put("sit", ((V)((Truthy(Get(fr_1628, "in")) ? 1D : 0D)))).V;
if (Truthy((((V)(shake_1635)) is var _t1636 && !Truthy(_t1636) ? _t1636 : (LtN(Invoke(G("Math"), "random"), 0.5) ? V.True : V.False)))) {
Invoke(ctx_560, "burst", Add(Add(Get(fr_1628, "x"), Get(fr_1628, "dx")), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 40D)))), ((V)((ToNum(Add(Get(fr_1628, "y"), Get(fr_1628, "dy"))) - 50D))), ((V)("drop")), ((V)(2D)), NewObj(4).Put("v", ((V)(120D))).Put("spread", TAU_22).Put("life", ((V)(0.5))).Put("g", ((V)(300D))).V);
}
}
}
kn_1634 = (Truthy((Get(fr_1628, "knock") is var _t1637 && !Truthy(_t1637) ? _t1637 : ((u_1633 > 0D) ? V.True : V.False))) ? ((u_1633 < 0.25) ? (u_1633 / 0.25) : ((u_1633 < 1D) ? 1D : Max(0D, (1D - ((u_1633 - 1D) / 0.35))))) : 0D);
if (Truthy((Get(fr_1628, "in") is var _t1638 && !Truthy(_t1638) ? _t1638 : Get(fr_1628, "knock")))) {
double a_1639 = 0;
a_1639 = (((u_1633 > 0D) && (u_1633 < 1D)) ? FdLibm.Sin(((u_1633 / 1D) * System.Math.PI)) : 0D);
Set(fr_1628, "dy", ((V)(((-a_1639) * (60D + (120D * ToNum(k_1207)))))));
Invoke(c_1631, "rot", ((V)((((u_1633 > 0D) && (u_1633 < 1D)) ? (u_1633 * 360D) : 0D))), ((V)(50D)), ((V)(60D)));
Invoke(GetIdx(rings_1232, 1D), "setAttribute", ((V)("opacity")), ((V)(((a_1639 > 0.15) ? 0D : 0.85))));
} else {
double lb_1640 = 0;
lb_1640 = (((!(Truthy(Get(fr_1628, "knock"))) && GeN(k_1207, 0.55)) && (u_1633 > 0D)) ? ((u_1633 < 0.2) ? (u_1633 / 0.2) : Max(0D, (1D - ((u_1633 - 0.5) / 0.6)))) : 0D);
Set(fr_1628, "rot", ((V)((((kn_1634 * ToNum(Get(fr_1628, "side"))) * 78D) + ((lb_1640 * ToNum(Get(fr_1628, "side"))) * 16D)))));
Set(fr_1628, "dx", ((V)((((kn_1634 * ToNum(Get(fr_1628, "side"))) * 26D) + ((lb_1640 * ToNum(Get(fr_1628, "side"))) * 10D)))));
Invoke(c_1631, "rot", Get(fr_1628, "rot"), ((V)(50D)), ((V)(92D)));
}
if (Truthy((((u_1633 > 0D) ? V.True : V.False) is var _t1641 && !Truthy(_t1641) ? _t1641 : Get(fr_1628, "wet")))) {
V w_1642 = default;
w_1642 = Call(cl_18, V.Undef, ((V)((u_1633 / 0.35))), ((V)(0D)), ((V)(1D)));
Invoke(Get(fr_1628, "slap"), "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)(((0.8 * (1D - ToNum(w_1642))) * ((u_1633 < 0.35) ? 1D : 0D))))));
Invoke(Get(fr_1628, "slap"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, Add(Get(fr_1628, "x"), Get(fr_1628, "dx")))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(Add(Get(fr_1628, "y"), Get(fr_1628, "dy"))) - 30D))))).S(") scale(").V(Call(r2_20, V.Undef, ((V)((0.6 + (0.8 * ToNum(w_1642))))))).S(")").End())));
if (!(Truthy(Get(fr_1628, "in")))) {
double pw_1643 = 0;
pw_1643 = (ToNum(Call(cl_18, V.Undef, ((V)((u_1633 / 0.8))), ((V)(0D)), ((V)(1D)))) * (0.5 + (0.7 * ToNum(k_1207))));
Invoke(Get(fr_1628, "pud"), "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)((8D + (34D * pw_1643))))));
Invoke(Get(fr_1628, "pud"), "setAttribute", ((V)("ry")), Call(r2_20, V.Undef, ((V)((2D + (6D * pw_1643))))));
Invoke(Get(fr_1628, "pud"), "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, Add(Get(fr_1628, "x"), ((V)((ToNum(Get(fr_1628, "dx")) * 0.5))))));
}
}
Invoke(c_1631, "set", Add(Get(fr_1628, "x"), Get(fr_1628, "dx")), Add(Get(fr_1628, "y"), Get(fr_1628, "dy")), Get(fr_1628, "size"));
if (GtN(Get(fr_1628, "wet"), 0D)) {
OpSet(fr_1628, "dripT", 1, dt_1547);
if (LeN(Get(fr_1628, "dripT"), 0D)) {
Set(fr_1628, "dripT", ((V)(0.07)));
Invoke(ctx_560, "burst", Add(Add(Get(fr_1628, "x"), Get(fr_1628, "dx")), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 46D)))), ((V)(((ToNum(Add(Get(fr_1628, "y"), Get(fr_1628, "dy"))) - 20D) - (ToNum(Invoke(G("Math"), "random")) * 60D)))), ((V)("drop")), ((V)(2D)), NewObj(6).Put("v", ((V)(30D))).Put("dir", ((V)((System.Math.PI / 2D)))).Put("spread", ((V)(0.5))).Put("life", ((V)(0.7))).Put("g", ((V)(420D))).Put("k", ((V)(1.3))).V);
}
Set(fr_1628, "wet", ((V)(Max(0D, (ToNum(Get(fr_1628, "wet")) - (ToNum(dt_1547) * 0.2))))));
}
}
Invoke(c_1631, "pose", E_1632);
return default;
}, 2, "", true));
if (Truthy(((hit_1241 is var _t1644 && !Truthy(_t1644) ? _t1644 : (((ToNum(t_1548) - ToNum(hitAt_1239)) > 3300D) ? V.True : V.False)) is var _t1645 && !Truthy(_t1645) ? _t1645 : (!(Truthy(Get(st_631, "done"))) ? V.True : V.False)))) {
Set(st_631, "done", ((V)(1D)));
Invoke(ctx_560, "finish", NewObj(2).Put("sub", ((V)(JsStrBuf.Begin().S("Hit the pool at ").N(Round(ToNum(v_1208))).S(" km/h \u00b7 top ").N(Round(ToNum(Get(st_631, "top")))).S(" \u00b7 ").V(Get(st_631, "boosts")).S(" boosts").End()))).Put("delay", ((V)(700D))).V);
}
Call(hud__643, V.Undef, dt_1547, t_1548);
return default;
}, 2, "update", false)).V;
return default;
}, 0, "poolScene", false);
camera_641 = Fn((V _self1646, int _argc1647, V dt_1653, V t_1654, V _a1651, V _a1652, V[] _rest1648) => {
V fly_1655 = default;
V fk_1656 = default;
V ct_1657 = default;
double sx_1658 = 0;
double sy_1659 = 0;
V cam_1660 = default;
V zz_1661 = default;
V tr_1662 = default;
if (_self1646.IsNullish) _self1646 = GlobalV;
fly_1655 = (SEqS(Get(st_631, "phase"), "fly") ? V.True : V.False);
fk_1656 = Call(cl_18, V.Undef, ((V)(((ToNum(Get(st_631, "v")) - VB_39) / 70D))), ((V)(0D)), ((V)(1D)));
Set(st_631, "z", Call(lerp_19, V.Undef, Get(st_631, "z"), ((V)((Z0_627 * (1D + (0.07 * ToNum(Get(st_631, "punch"))))))), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1653)) * 6D)))))));
Set(st_631, "lc", Call(lerp_19, V.Undef, Get(st_631, "lc"), (Truthy(fly_1655) ? Get(st_631, "lc") : ((V)((0.5 * ToNum(Get(st_631, "l")))))), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1653)) * 5D)))))));
if (!(Truthy(fly_1655))) {
Set(st_631, "sc", Get(st_631, "s"));
} else {
Set(st_631, "sc", Call(lerp_19, V.Undef, Get(st_631, "sc"), ((V)((LEN_45 + 30D))), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1653)) * 3D)))))));
}
ct_1657 = Arr(Call(lerp_19, V.Undef, GetIdx(C0_625, 0D), GetIdx(C1_626, 0D), fk_1656), Call(lerp_19, V.Undef, GetIdx(C0_625, 1D), GetIdx(C1_626, 1D), fk_1656));
Set(st_631, "cx", Call(lerp_19, V.Undef, Get(st_631, "cx"), GetIdx(ct_1657, 0D), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1653)) * 2.5)))))));
Set(st_631, "cy", Call(lerp_19, V.Undef, Get(st_631, "cy"), GetIdx(ct_1657, 1D), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1653)) * 2.5)))))));
sx_1658 = 0D;
sy_1659 = 0D;
if (GtN(Get(st_631, "shake"), 0.2)) {
sx_1658 = (((ToNum(Invoke(G("Math"), "random")) - 0.5) * 2D) * ToNum(Get(st_631, "shake")));
sy_1659 = (((ToNum(Invoke(G("Math"), "random")) - 0.5) * 2D) * ToNum(Get(st_631, "shake")));
OpSet(st_631, "shake", 2, ((V)(FdLibm.Exp(((-ToNum(dt_1653)) * 7D)))));
}
if (((SEqS(Get(st_631, "phase"), "ride") || SEqS(Get(st_631, "phase"), "ramp")) && GtN(Get(st_631, "v"), 62D))) {
double a_1663 = 0;
a_1663 = (((ToNum(Get(st_631, "v")) - 62D) / 45D) * 1.4);
sx_1658 = (sx_1658 + ((ToNum(Invoke(G("Math"), "random")) - 0.5) * a_1663));
sy_1659 = (sy_1659 + ((ToNum(Invoke(G("Math"), "random")) - 0.5) * a_1663));
}
cam_1660 = Call(Wp_29, V.Undef, Get(st_631, "sc"), Get(st_631, "lc"), ((V)((SH_48 * 0.85))));
Set(st_631, "tx", ((V)((ToNum(Add(Get(st_631, "cx"), ((V)(sx_1658)))) - (ToNum(Get(st_631, "z")) * ToNum(GetIdx(cam_1660, 0D)))))));
Set(st_631, "ty", ((V)((ToNum(Add(Get(st_631, "cy"), ((V)(sy_1659)))) - (ToNum(Get(st_631, "z")) * ToNum(GetIdx(cam_1660, 1D)))))));
zz_1661 = Invoke(Get(st_631, "z"), "toFixed", ((V)(5D)));
tr_1662 = ((V)(JsStrBuf.Begin().S("matrix(").V(zz_1661).S(" 0 0 ").V(zz_1661).S(" ").V(Call(r2_20, V.Undef, Get(st_631, "tx"))).S(" ").V(Call(r2_20, V.Undef, Get(st_631, "ty"))).S(")").End()));
Invoke(wB_567, "setAttribute", ((V)("transform")), tr_1662);
Invoke(wF_575, "setAttribute", ((V)("transform")), tr_1662);
Call(ensure_598, V.Undef, Get(st_631, "sc"), Get(st_631, "z"));
Call(feed_606, V.Undef, Get(st_631, "sc"), Get(st_631, "z"));
return default;
}, 2, "camera", false);
place_642 = Fn((V _self1664, int _argc1665, V t_1671, V dt_1672, V _a1669, V _a1670, V[] _rest1666) => {
V gh_1673 = default;
V gp_1674 = default;
double air_1675 = 0;
V ride_1676 = default;
double bob_1677 = 0;
V p_1678 = default;
if (_self1664.IsNullish) _self1664 = GlobalV;
gh_1673 = (SEqS(Get(st_631, "phase"), "fly") ? (LtN(Get(st_631, "s"), LEN_45) ? Call(HS_58, V.Undef, Get(st_631, "s")) : ((V)(0D))) : Call(HS_58, V.Undef, Get(st_631, "s")));
gp_1674 = Call(Wp_29, V.Undef, Get(st_631, "s"), Get(st_631, "l"), gh_1673);
air_1675 = (ToNum(Get(st_631, "h")) - ToNum(gh_1673));
Invoke(meSh_583, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(P2_30, V.Undef, gp_1674)).S(") rotate(").V(Get(EL_34, "rot")).S(")").End())));
Invoke(meSh_583, "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)((0.22 * ToNum(Call(cl_18, V.Undef, ((V)((1D - (air_1675 / 220D)))), ((V)(0.2)), ((V)(1D)))))))));
Invoke(meSh_583, "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)(((20D * ToNum(Get(EL_34, "kx"))) * ToNum(Call(cl_18, V.Undef, ((V)((1D - (air_1675 / 300D)))), ((V)(0.5)), ((V)(1D)))))))));
riderD_585 = Add(GetIdx(Call(Wp_29, V.Undef, Get(st_631, "s"), Get(st_631, "l"), ((V)(0D))), 1D), ((V)(1D)));
{
foreach (V _k1679 in new JsIter(stands_584)) {
V o_1680 = default;
o_1680 = _k1679;
V fr_1681 = default;
fr_1681 = (Gt(Get(o_1680, "d"), riderD_585) ? V.True : V.False);
if (!SEq(fr_1681, Get(o_1680, "fr"))) {
Call(sortIn_586, V.Undef, o_1680, fr_1681);
}
}
}
ride_1676 = ((SEqS(Get(st_631, "phase"), "ride") || SEqS(Get(st_631, "phase"), "ramp")) ? V.True : V.False);
bob_1677 = (Truthy((ride_1676 is var _t1682 && !Truthy(_t1682) ? _t1682 : (LeN(Get(st_631, "ha"), 0.5) ? V.True : V.False))) ? ((FdLibm.Sin((ToNum(t_1671) / 34D)) * 0.9) * ToNum(Call(cl_18, V.Undef, ((V)((ToNum(Get(st_631, "v")) / 70D))), ((V)(0D)), ((V)(1.6))))) : 0D);
p_1678 = Call(scr_632, V.Undef, Get(st_631, "s"), Get(st_631, "l"), Get(st_631, "h"));
Invoke(me_624, "set", GetIdx(p_1678, 0D), Add(GetIdx(p_1678, 1D), ((V)(((5D + bob_1677) * ToNum(Get(st_631, "z")))))), ((V)((K_52 * ToNum(Get(st_631, "z"))))));
Invoke(me_624, "rot", (SEqS(Get(st_631, "phase"), "fly") ? (GeN(Get(st_631, "lipV"), 75D) ? ((V)(Min(360D, ((((ToNum(t_1671) - ToNum(Get(st_631, "tf"))) / 1000D) * 1.6) * 360D)))) : Call(cl_18, V.Undef, ((V)(((-ToNum(Get(st_631, "vh"))) / 18D))), ((V)((-20D))), ((V)(24D)))) : ((V)((SEqS(Get(st_631, "phase"), "ramp") ? (((-(ToNum(Call(HS_58, V.Undef, Get(st_631, "s"))) - SH_48)) / RH_47) * 16D) : 0D)))), ((V)(50D)), ((V)(((SEqS(Get(st_631, "phase"), "fly") && GeN(Get(st_631, "lipV"), 75D)) ? 62D : 80D))));
if (Truthy(((ride_1676 is var _t1683 && !Truthy(_t1683) ? _t1683 : (LeN(Get(st_631, "ha"), 1D) ? V.True : V.False)) is var _t1684 && !Truthy(_t1684) ? _t1684 : (GtN(Get(st_631, "v"), 42D) ? V.True : V.False)))) {
OpSet(st_631, "trail", 1, dt_1672);
if (LeN(Get(st_631, "trail"), 0D)) {
V q_1685 = default;
Set(st_631, "trail", ((V)(0.07)));
q_1685 = Call(scr_632, V.Undef, ((V)((ToNum(Get(st_631, "s")) - 14D))), Get(st_631, "l"), Get(st_631, "h"));
Invoke(ctx_560, "burst", GetIdx(q_1685, 0D), ((V)((ToNum(GetIdx(q_1685, 1D)) - 4D))), ((V)("drop")), ((V)((2D + (GtN(Get(st_631, "v"), 80D) ? 1D : 0D)))), NewObj(6).Put("v", ((V)((60D + (ToNum(Get(st_631, "v")) * 1.4))))).Put("dir", ((V)((FdLibm.Atan2((-ToNum(GetIdx(F_26, 1D))), (-ToNum(GetIdx(F_26, 0D)))) - 0.5)))).Put("spread", ((V)(0.9))).Put("life", ((V)(0.45))).Put("g", ((V)(300D))).Put("col", ((V)("#dff4ff"))).V);
}
}
if (Truthy((ride_1676 is var _t1686 && !Truthy(_t1686) ? _t1686 : (GtN(Get(st_631, "boostT"), 0D) ? V.True : V.False)))) {
OpSet(st_631, "sparkT", 1, dt_1672);
if (LeN(Get(st_631, "sparkT"), 0D)) {
V q_1687 = default;
Set(st_631, "sparkT", ((V)(0.05)));
q_1687 = Call(scr_632, V.Undef, ((V)((ToNum(Get(st_631, "s")) - 10D))), Get(st_631, "l"), Add(Get(st_631, "h"), ((V)(20D))));
Invoke(ctx_560, "burst", GetIdx(q_1687, 0D), GetIdx(q_1687, 1D), ((V)("star")), ((V)(1D)), NewObj(5).Put("v", ((V)(90D))).Put("dir", ((V)(FdLibm.Atan2((-ToNum(GetIdx(F_26, 1D))), (-ToNum(GetIdx(F_26, 0D))))))).Put("spread", ((V)(0.8))).Put("life", ((V)(0.5))).Put("g", ((V)(0D))).V);
}
}
return default;
}, 2, "place", false);
hud__643 = Fn((V _self1688, int _argc1689, V dt_1695, V t_1696, V _a1693, V _a1694, V[] _rest1690) => {
V v_1697 = default;
V tr_1698 = default;
V u_1699 = default;
V vt_1700 = default;
V pr_1701 = default;
V go_1702 = default;
V sk_1703 = default;
double spd_1704 = 0;
double n_1705 = 0;
V me0_1706 = default;
if (_self1688.IsNullish) _self1688 = GlobalV;
v_1697 = (SEqS(Get(st_631, "phase"), "pool") ? Get(st_631, "lipV") : Get(st_631, "v"));
tr_1698 = Call(tierOf_60, V.Undef, v_1697);
u_1699 = Call(cl_18, V.Undef, ((V)((ToNum(v_1697) / 110D))), ((V)(0D)), ((V)(1D)));
Invoke(spArc_610, "setAttribute", ((V)("stroke-dasharray")), ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, ((V)((arcL_609 * ToNum(u_1699)))))).S(" 999").End())));
Invoke(spArc_610, "setAttribute", ((V)("stroke")), ((V)((LtN(v_1697, 42D) ? "#5cc87a" : (LtN(v_1697, 60D) ? "#3fc0d8" : (LtN(v_1697, 80D) ? "#ffb020" : (LtN(v_1697, 100D) ? "#ff7a3a" : "#ff4d8a")))))));
vt_1700 = ((V)(ToStrS(((V)(Round(ToNum(v_1697)))))));
if (!SEq(Get(spTx_611, "textContent"), vt_1700)) {
Set(spTx_611, "textContent", vt_1700);
}
if (!SEq(Get(tierTx_614, "textContent"), GetIdx(tr_1698, 1D))) {
Set(tierTx_614, "textContent", GetIdx(tr_1698, 1D));
Invoke(tierR_613, "setAttribute", ((V)("fill")), GetIdx(tr_1698, 2D));
}
pr_1701 = Call(cl_18, V.Undef, ((V)((ToNum(Get(st_631, "s")) / LEN_45))), ((V)(0D)), ((V)(1D)));
Invoke(pgF_616, "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M40 0H").V(Call(r2_20, V.Undef, ((V)((40D + (274D * ToNum(pr_1701))))))).End())));
Invoke(pgD_617, "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, ((V)((40D + (274D * ToNum(pr_1701)))))));
Set(Get(hud_582, "style"), "opacity", ((V)((SEqS(Get(st_631, "phase"), "ready") ? 0D : 1D))));
if ((SEqS(Get(st_631, "phase"), "ride") || SEqS(Get(st_631, "phase"), "ramp"))) {
Invoke(ctx_560, "timer", ((V)(JsStrBuf.Begin().N(Max(0D, Round(((LEN_45 - ToNum(Get(st_631, "s"))) / 14.4)))).S(" m").End())));
} else {
if ((SEqS(Get(st_631, "phase"), "ready") || SEqS(Get(st_631, "phase"), "pool"))) {
Invoke(ctx_560, "timer", ((V)("")));
}
}
if (SEqS(Get(st_631, "phase"), "pool")) {
return default;
}
go_1702 = (((SEqS(Get(st_631, "phase"), "ride") || SEqS(Get(st_631, "phase"), "ramp")) || SEqS(Get(st_631, "phase"), "fly")) ? V.True : V.False);
sk_1703 = (Truthy(go_1702) ? Call(cl_18, V.Undef, ((V)(((ToNum(v_1697) - 42D) / 55D))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
spd_1704 = (((ToNum(v_1697) * KV_38) * ToNum(Get(st_631, "z"))) * 1.7);
n_1705 = Round((6D + (12D * ToNum(sk_1703))));
me0_1706 = Call(scr_632, V.Undef, Get(st_631, "s"), Get(st_631, "l"), Add(Get(st_631, "h"), ((V)(30D))));
Invoke(lines_618, "forEach", Fn((V _arrowThis1715, int _argc1707, V q_1713, V i_1714, V _a1711, V _a1712, V[] _rest1708) => {
V on_1716 = default;
double len_1717 = 0;
on_1716 = ((LtN(i_1714, n_1705) && GtN(sk_1703, 0D)) ? V.True : V.False);
OpSet(q_1713, "x", 1, ((V)((((ToNum(GetIdx(F_26, 0D)) * spd_1704) * ToNum(dt_1695)) * ToNum(Get(q_1713, "n"))))));
OpSet(q_1713, "y", 1, ((V)((((ToNum(GetIdx(F_26, 1D)) * spd_1704) * ToNum(dt_1695)) * ToNum(Get(q_1713, "n"))))));
if ((((LtN(Get(q_1713, "x"), (-120D)) || LtN(Get(q_1713, "y"), (-120D))) || Gt(Get(q_1713, "x"), Add(W_563, ((V)(200D))))) || Gt(Get(q_1713, "y"), Add(H_564, ((V)(200D)))))) {
if (Truthy(Get(q_1713, "near"))) {
Set(q_1713, "x", Add(Add(GetIdx(me0_1706, 0D), ((V)(40D))), ((V)((ToNum(Invoke(G("Math"), "random")) * 160D)))));
Set(q_1713, "y", ((V)(((ToNum(GetIdx(me0_1706, 1D)) - 40D) + (ToNum(Invoke(G("Math"), "random")) * 80D)))));
} else {
Set(q_1713, "x", ((V)((ToNum(W_563) * (0.25 + (ToNum(Invoke(G("Math"), "random")) * 0.9))))));
Set(q_1713, "y", ((V)((ToNum(H_564) * (0.05 + (ToNum(Invoke(G("Math"), "random")) * 1.05))))));
if (((Lt(Get(q_1713, "x"), W_563) && Lt(Get(q_1713, "y"), H_564)) && LtN(Invoke(G("Math"), "random"), 0.6))) {
Set(q_1713, "x", Add(W_563, ((V)(20D))));
}
}
}
len_1717 = ((24D + (120D * ToNum(sk_1703))) * ToNum(Get(q_1713, "n")));
Invoke(Get(q_1713, "e"), "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, Get(q_1713, "x"))).S(" ").V(Call(r2_20, V.Undef, Get(q_1713, "y"))).S("l").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(F_26, 0D)) * len_1717))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(F_26, 1D)) * len_1717))))).End())));
Invoke(Get(q_1713, "e"), "setAttribute", ((V)("opacity")), (Truthy(on_1716) ? Call(r2_20, V.Undef, ((V)(((Truthy(Get(q_1713, "near")) ? 0.85 : 0.6) * ToNum(sk_1703))))) : ((V)(0D))));
return default;
}, 2, "", true));
return default;
}, 2, "hud_", false);
{ V _t1718 = ctx_560;
if (_t1718.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1718));
{ V _t1719 = Get(_t1718, "bg");
bg_561 = _t1719; }
{ V _t1720 = Get(_t1718, "fg");
fg_562 = _t1720; }
{ V _t1721 = Get(_t1718, "W");
W_563 = _t1721; }
{ V _t1722 = Get(_t1718, "H");
H_564 = _t1722; } }
Call(css_80, V.Undef);
look_565 = (Get(Get(ctx_560, "G"), "_opt") is var _t1723 && Truthy(_t1723) ? _t1723 : ((V)("rainbow")));
slideBg_566 = Call(S_17, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", Add(W_563, ((V)(40D)))).Put("height", Add(H_564, ((V)(40D)))).Put("fill", ((V)("#79c25c"))).V, bg_561);
wB_567 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_561);
gStart_568 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, wB_567);
gGround_569 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, wB_567);
gEnd_570 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, wB_567);
gDecal_571 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, wB_567);
gShadow_572 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, wB_567);
gBack_573 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, wB_567);
scB_574 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("style", ((V)("display:none"))).V, bg_561);
wF_575 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, fg_562);
gStartF_576 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, wF_575);
gNear_577 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, wF_575);
gEndF_578 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, wF_575);
gFront_579 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, wF_575);
scF_580 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("style", ((V)("display:none"))).V, fg_562);
speedL_581 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, fg_562);
hud_582 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, fg_562);
meSh_583 = Call(S_17, V.Undef, ((V)("ellipse")), NewObj(4).Put("rx", Call(r2_20, V.Undef, ((V)((20D * ToNum(Get(EL_34, "kx"))))))).Put("ry", Call(r2_20, V.Undef, ((V)((20D * ToNum(Get(EL_34, "ky"))))))).Put("fill", ((V)("#2a3a20"))).Put("opacity", ((V)(0.22))).V, gShadow_572);
stands_584 = Arr();
riderD_585 = ((V)(0D));
chunks_589 = New(G("Map"));
Lp_590 = Fn((V _arrowThis1731, int _argc1724, V px_1730, V _a1727, V _a1728, V _a1729, V[] _rest1725) => {
return ((V)((ToNum(px_1730) / HW_28)));
}, 1, "", true);
post_591 = Fn((V _arrowThis1744, int _argc1732, V L_1738, V s_1739, V l_1740, V h0_1741, V[] _rest1733) => {
V h1_1742 = default;
V w_1743 = default;
h1_1742 = (_argc1732 > 4 ? _rest1733[0] : V.Undef);
w_1743 = (_argc1732 > 5 ? _rest1733[1] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, s_1739, l_1740, h0_1741))).S("L").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, s_1739, l_1740, h1_1742))).S("\" stroke=\"").V(Get(L_1738, "postD")).S("\" stroke-width=\"").V(Add((w_1743 is var _t1745 && Truthy(_t1745) ? _t1745 : ((V)(6D))), ((V)(2.4)))).S("\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, s_1739, l_1740, h0_1741))).S("L").V(Call(P2_30, V.Undef, Call(Wp_29, V.Undef, s_1739, l_1740, h1_1742))).S("\" stroke=\"").V(Get(L_1738, "post")).S("\" stroke-width=\"").V((w_1743 is var _t1746 && Truthy(_t1746) ? _t1746 : ((V)(6D)))).S("\" stroke-linecap=\"round\"/>").End()));
}, 6, "", true);
farWall_594 = Fn((V _arrowThis1755, int _argc1747, V a_1753, V b_1754, V _a1751, V _a1752, V[] _rest1748) => {
V L_1756 = default;
L_1756 = GetK(LOOK_62, look_565);
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(Call(poly_32, V.Undef, Arr(Call(Wp_29, V.Undef, a_1753, ((V)(1D)), ((V)(SH_48))), Call(Wp_29, V.Undef, b_1754, ((V)(1D)), ((V)(SH_48))), Call(Wp_29, V.Undef, b_1754, ((V)(1D)), ((V)((SH_48 + WH_49)))), Call(Wp_29, V.Undef, a_1753, ((V)(1D)), ((V)((SH_48 + WH_49))))))).S("\" fill=\"").V(Get(L_1756, "face")).S("\"/><path d=\"").V(Call(quad_33, V.Undef, a_1753, b_1754, ((V)(1D)), ((V)(1.12)), ((V)((SH_48 + WH_49))))).S("\" fill=\"").V(Get(L_1756, "top")).S("\" stroke=\"").V(Get(L_1756, "side")).S("\" stroke-width=\"1\"/>").End()));
return default;
}, 2, "", true);
items_600 = Arr();
nextI_601 = 0D;
alive_602 = Arr();
sp_607 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(66 ").N((ToNum(H_564) - 54D)).S(")").End()))).V, hud_582);
Call(S_17, V.Undef, ((V)("rect")), NewObj(9).Put("x", ((V)((-52D)))).Put("y", ((V)((-50D)))).Put("width", ((V)(104D))).Put("height", ((V)(72D))).Put("rx", ((V)(24D))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.94))).Put("stroke", ((V)("#4a1a73"))).Put("stroke-width", ((V)(2.5))).V, sp_607);
ARC_608 = ((V)("M-36 4A36 36 0 0 1 36 4"));
arcL_609 = (System.Math.PI * 36D);
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ARC_608).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ece6fa"))).Put("stroke-width", ((V)(9D))).Put("stroke-linecap", ((V)("round"))).V, sp_607);
spArc_610 = Call(S_17, V.Undef, ((V)("path")), NewObj(6).Put("d", ARC_608).Put("fill", ((V)("none"))).Put("stroke", ((V)("#5cc87a"))).Put("stroke-width", ((V)(9D))).Put("stroke-linecap", ((V)("round"))).Put("stroke-dasharray", ((V)("0 999"))).V, sp_607);
spTx_611 = Call(S_17, V.Undef, ((V)("text")), NewObj(6).Put("y", ((V)(0D))).Put("text-anchor", ((V)("middle"))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)(25D))).Put("fill", ((V)("#4a1a73"))).V, sp_607);
Set(spTx_611, "textContent", ((V)("0")));
Set(Call(S_17, V.Undef, ((V)("text")), NewObj(7).Put("y", ((V)(15D))).Put("text-anchor", ((V)("middle"))).Put("font-family", ((V)("Nunito, sans-serif"))).Put("font-weight", ((V)(800D))).Put("font-size", ((V)(9.5))).Put("fill", ((V)("#8a6ab0"))).Put("letter-spacing", ((V)(1D))).V, sp_607), "textContent", ((V)("KM/H")));
tierG_612 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)("translate(0 36)"))).V, sp_607);
tierR_613 = Call(S_17, V.Undef, ((V)("rect")), NewObj(8).Put("x", ((V)((-48D)))).Put("y", ((V)((-10D)))).Put("width", ((V)(96D))).Put("height", ((V)(20D))).Put("rx", ((V)(10D))).Put("fill", ((V)("#bfe8ff"))).Put("stroke", ((V)("#4a1a73"))).Put("stroke-width", ((V)(2D))).V, tierG_612);
tierTx_614 = Call(S_17, V.Undef, ((V)("text")), NewObj(6).Put("y", ((V)(4.5))).Put("text-anchor", ((V)("middle"))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)(12D))).Put("fill", ((V)("#4a1a73"))).V, tierG_612);
pg_615 = Call(S_17, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, ((V)(((ToNum(W_563) / 2D) - 177D))))).S(" ").N((ToNum(H_564) - 20D)).S(")").End()))).V, hud_582);
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)("M40 0H314"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(7D))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.85))).V, pg_615);
pgF_616 = Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)("M40 0H40"))).Put("stroke", ((V)("#ff8fc8"))).Put("stroke-width", ((V)(7D))).Put("stroke-linecap", ((V)("round"))).V, pg_615);
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)("M24 6V-12M24 -12H36L32 -7L36 -2H24"))).Put("stroke", ((V)("#4a1a73"))).Put("stroke-width", ((V)(2D))).Put("fill", ((V)("#ffd84a"))).Put("stroke-linejoin", ((V)("round"))).V, pg_615);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(7).Put("cx", ((V)(330D))).Put("cy", ((V)(1D))).Put("rx", ((V)(13D))).Put("ry", ((V)(6D))).Put("fill", ((V)("#5cc2ff"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2D))).V, pg_615);
Call(S_17, V.Undef, ((V)("path")), NewObj(5).Put("d", ((V)("M324 -1q3 -9 6 0M330 -1q3 -12 6 0"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2D))).Put("fill", ((V)("none"))).Put("stroke-linecap", ((V)("round"))).V, pg_615);
pgD_617 = Call(S_17, V.Undef, ((V)("circle")), NewObj(4).Put("r", ((V)(7D))).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#4a1a73"))).Put("stroke-width", ((V)(2.4))).V, pg_615);
lines_618 = Arr();
{
double i_1757 = 0;
i_1757 = 0D;
while (true) {
if (!((i_1757 < 18D))) break;
Invoke(lines_618, "push", NewObj(5).Put("e", Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)((NumTruthy((i_1757 % 3D)) ? 2.2 : 3.2)))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0D))).V, speedL_581)).Put("x", ((V)((ToNum(Invoke(G("Math"), "random")) * ToNum(W_563))))).Put("y", ((V)((ToNum(Invoke(G("Math"), "random")) * ToNum(H_564))))).Put("n", ((V)((0.6 + (ToNum(Invoke(G("Math"), "random")) * 0.8))))).Put("near", ((i_1757 < 6D) ? V.True : V.False)).V);
i_1757++;
}
}
flash_619 = Call(S_17, V.Undef, ((V)("rect")), NewObj(7).Put("x", ((V)((-10D)))).Put("y", ((V)((-10D)))).Put("width", Add(W_563, ((V)(20D)))).Put("height", Add(H_564, ((V)(20D)))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0D))).Put("pointer-events", ((V)("none"))).V, fg_562);
AU_620 = V.Null;
me_624 = Invoke(ctx_560, "creature", Get(ctx_560, "playerKey"), NewObj(1).Put("yaw", ((V)(58D))).V);
Invoke(me_624, "depth", ((V)(0D)));
C0_625 = Arr(((V)(186D)), ((V)(142D)));
C1_626 = Arr(((V)(150D)), ((V)(128D)));
Z0_627 = 1.08;
tNow_628 = ((V)(0D));
friends_629 = V.Null;
pool_630 = V.Null;
st_631 = NewObj(32).Put("off", ((V)(0D))).Put("phase", ((V)("ready"))).Put("s", ((V)(ST0_55))).Put("l", ((V)(0D))).Put("tgt", ((V)(0D))).Put("h", ((V)(SH_48))).Put("ha", ((V)(0D))).Put("vh", ((V)(0D))).Put("v", ((V)(0D))).Put("top", ((V)(0D))).Put("z", ((V)(Z0_627))).Put("lc", ((V)(0D))).Put("sc", ((V)(ST0_55))).Put("cx", GetIdx(C0_625, 0D)).Put("cy", GetIdx(C0_625, 1D)).Put("stun", ((V)(0D))).Put("boostT", ((V)(0D))).Put("punch", ((V)(0D))).Put("mud", ((V)(0D))).Put("key", ((V)(0D))).Put("t0", ((V)(0D))).Put("yaw", ((V)(58D))).Put("boosts", ((V)(0D))).Put("bonks", ((V)(0D))).Put("shake", ((V)(0D))).Put("toldPool", ((V)(0D))).Put("lipV", ((V)(0D))).Put("k", ((V)(0D))).Put("trail", ((V)(0D))).Put("bot", ((V)(0D))).Put("botT", ((V)(0D))).Put("sparkT", ((V)(0D))).V;
scr_632 = Fn((V _arrowThis1768, int _argc1759, V s_1765, V l_1766, V h_1767, V _a1764, V[] _rest1760) => {
V p_1769 = default;
p_1769 = Call(Wp_29, V.Undef, s_1765, l_1766, h_1767);
return Arr(Add(Get(st_631, "tx"), ((V)((ToNum(Get(st_631, "z")) * ToNum(GetIdx(p_1769, 0D)))))), Add(Get(st_631, "ty"), ((V)((ToNum(Get(st_631, "z")) * ToNum(GetIdx(p_1769, 1D)))))));
return default;
}, 3, "", true);
drag_634 = V.Null;
api_635 = NewObj(15).Put("option", Fn((V _self1770, int _argc1771, V id_1777, V _a1774, V _a1775, V _a1776, V[] _rest1772) => {
if (_self1770.IsNullish) _self1770 = GlobalV;
look_565 = id_1777;
{
foreach (V _k1778 in new JsIter(new ArrBuilder().Spread(Invoke(chunks_589, "keys")).V)) {
V i_1779 = default;
i_1779 = _k1778;
Call(dropChunk_597, V.Undef, i_1779);
}
}
Call(buildStatic_599, V.Undef);
return default;
}, 1, "option", false)).Put("start", Fn((V _self1780, int _argc1781, V _a1783, V _a1784, V _a1785, V _a1786, V[] _rest1782) => {
if (_self1780.IsNullish) _self1780 = GlobalV;
look_565 = (Get(Get(ctx_560, "G"), "_opt") is var _t1787 && Truthy(_t1787) ? _t1787 : look_565);
Call(reset_633, V.Undef);
Set(st_631, "phase", ((V)("ride")));
Set(st_631, "t0", tNow_628);
Invoke(ctx_560, "hint", ((V)("")));
Invoke(SFX_21, "whoosh");
Call(windOn_621, V.Undef);
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis1802, int _argc1796, V _a1798, V _a1799, V _a1800, V _a1801, V[] _rest1797) => {
return ((SEqS(Get(st_631, "phase"), "ride") ? V.True : V.False) is var _t1803 && !Truthy(_t1803) ? _t1803 : Invoke(ctx_560, "toast", ((V)("Drag up / down to switch sides")), ((V)((ToNum(W_563) / 2D))), ((V)((ToNum(H_564) - 70D))), ((V)("#ffffff"))));
}, 0, "", true), ((V)(900D)));
return default;
}, 0, "start", false)).Put("down", Fn((V _self1804, int _argc1805, V p_1811, V _a1808, V _a1809, V _a1810, V[] _rest1806) => {
if (_self1804.IsNullish) _self1804 = GlobalV;
drag_634 = NewObj(3).Put("x", Get(p_1811, "x")).Put("y", Get(p_1811, "y")).Put("l", Get(st_631, "tgt")).V;
return default;
}, 1, "down", false)).Put("move", Fn((V _self1812, int _argc1813, V p_1819, V _a1816, V _a1817, V _a1818, V[] _rest1814) => {
if (_self1812.IsNullish) _self1812 = GlobalV;
if (!(Truthy(drag_634))) {
return default;
}
Set(st_631, "tgt", Call(cl_18, V.Undef, Add(Get(drag_634, "l"), ((V)((((ToNum(Get(p_1819, "x")) - ToNum(Get(drag_634, "x"))) - (ToNum(Get(p_1819, "y")) - ToNum(Get(drag_634, "y")))) * 0.011)))), ((V)((-LMAX_42))), ((V)(LMAX_42))));
return default;
}, 1, "move", false)).Put("up", Fn((V _self1820, int _argc1821, V _a1823, V _a1824, V _a1825, V _a1826, V[] _rest1822) => {
if (_self1820.IsNullish) _self1820 = GlobalV;
drag_634 = V.Null;
return default;
}, 0, "up", false)).Put("key", Fn((V _self1827, int _argc1828, V k_1834, V dn_1835, V _a1832, V _a1833, V[] _rest1829) => {
double d_1836 = 0;
if (_self1827.IsNullish) _self1827 = GlobalV;
d_1836 = ((((SEqS(k_1834, "ArrowUp") || SEqS(k_1834, "ArrowRight")) || SEqS(k_1834, "w")) || SEqS(k_1834, "d")) ? 1D : ((((SEqS(k_1834, "ArrowDown") || SEqS(k_1834, "ArrowLeft")) || SEqS(k_1834, "s")) || SEqS(k_1834, "a")) ? (-1D) : 0D));
if (!(NumTruthy(d_1836))) {
return default;
}
Set(st_631, "key", (Truthy(dn_1835) ? ((V)(d_1836)) : (SEqN(Get(st_631, "key"), d_1836) ? ((V)(0D)) : Get(st_631, "key"))));
return (true ? V.True : V.False);
return default;
}, 2, "key", false)).Put("_state", Fn((V _arrowThis1843, int _argc1837, V _a1839, V _a1840, V _a1841, V _a1842, V[] _rest1838) => {
return NewObj(12).Put("phase", Get(st_631, "phase")).Put("s", ((V)(Round(ToNum(Get(st_631, "s")))))).Put("l", ((V)(ToNum(Invoke(Get(st_631, "l"), "toFixed", ((V)(2D))))))).Put("v", ((V)(ToNum(Invoke(Get(st_631, "v"), "toFixed", ((V)(1D))))))).Put("h", ((V)(Round(ToNum(Get(st_631, "h")))))).Put("top", ((V)(Round(ToNum(Get(st_631, "top")))))).Put("boosts", Get(st_631, "boosts")).Put("bonks", Get(st_631, "bonks")).Put("t", ((V)(ToNum(Invoke(((V)(((ToNum(tNow_628) - ToNum(Get(st_631, "t0"))) / 1000D))), "toFixed", ((V)(1D))))))).Put("k", ((V)(ToNum(Invoke(Get(st_631, "k"), "toFixed", ((V)(2D))))))).Put("lip", ((V)(Round(ToNum(Get(st_631, "lipV")))))).Put("z", ((V)(ToNum(Invoke(Get(st_631, "z"), "toFixed", ((V)(2D))))))).V;
}, 0, "_state", true)).Put("_bot", Fn((V _self1844, int _argc1845, V k_1851, V _a1848, V _a1849, V _a1850, V[] _rest1846) => {
if (_self1844.IsNullish) _self1844 = GlobalV;
Set(st_631, "bot", k_1851);
return default;
}, 1, "_bot", false)).Put("_setV", Fn((V _self1852, int _argc1853, V v_1859, V _a1856, V _a1857, V _a1858, V[] _rest1854) => {
if (_self1852.IsNullish) _self1852 = GlobalV;
Set(st_631, "v", v_1859);
Set(st_631, "top", ((V)(Max(ToNum(Get(st_631, "top")), ToNum(v_1859)))));
return default;
}, 1, "_setV", false)).Put("_items", Fn((V _arrowThis1866, int _argc1860, V _a1862, V _a1863, V _a1864, V _a1865, V[] _rest1861) => {
return Invoke(items_600, "map", Fn((V _arrowThis1874, int _argc1867, V q_1873, V _a1870, V _a1871, V _a1872, V[] _rest1868) => {
return Arr(Get(q_1873, "t"), ((V)(Round(ToNum(Get(q_1873, "s"))))), ((V)(ToNum(Invoke(Get(q_1873, "l"), "toFixed", ((V)(2D)))))));
}, 1, "", true));
}, 0, "_items", true)).Put("_look", Fn((V _arrowThis1881, int _argc1875, V _a1877, V _a1878, V _a1879, V _a1880, V[] _rest1876) => {
return look_565;
}, 0, "_look", true)).Put("_ff", Fn((V _self1882, int _argc1883, V sec_1889, V _a1886, V _a1887, V _a1888, V[] _rest1884) => {
double n_1890 = 0;
double tr_1891 = 0;
if (_self1882.IsNullish) _self1882 = GlobalV;
n_1890 = Round((ToNum(sec_1889) * 60D));
tr_1891 = (ToNum(tNow_628) - ToNum(Get(st_631, "off")));
{
double i_1892 = 0;
i_1892 = 0D;
while (true) {
if (!((i_1892 < n_1890))) break;
OpSet(st_631, "off", 0, ((V)((1000D / 60D))));
Invoke(api_635, "update", ((V)((1D / 60D))), ((V)(tr_1891)));
i_1892++;
}
}
return Invoke(api_635, "_state");
return default;
}, 1, "_ff", false)).Put("celebrate", Fn((V _self1894, int _argc1895, V s_1901, V _a1898, V _a1899, V _a1900, V[] _rest1896) => {
if (_self1894.IsNullish) _self1894 = GlobalV;
Invoke(me_624, "play", ((V)((GeN(s_1901, 2D) ? "happy" : "idle"))));
if (Truthy(friends_629)) {
Invoke(friends_629, "forEach", Fn((V _arrowThis1909, int _argc1902, V f_1908, V _a1905, V _a1906, V _a1907, V[] _rest1903) => {
return Invoke(Get(f_1908, "c"), "play", ((V)((GeN(s_1901, 2D) ? "happy" : "idle"))));
}, 1, "", true));
}
return default;
}, 1, "celebrate", false)).Put("destroy", Fn((V _self1910, int _argc1911, V _a1913, V _a1914, V _a1915, V _a1916, V[] _rest1912) => {
if (_self1910.IsNullish) _self1910 = GlobalV;
Call(windOff_623, V.Undef);
return default;
}, 0, "destroy", false)).Put("update", Fn((V _self1917, int _argc1918, V dt_1924, V t_1925, V _a1922, V _a1923, V[] _rest1919) => {
V L_1926 = default;
V E_1927 = default;
V fast_1928 = default;
if (_self1917.IsNullish) _self1917 = GlobalV;
t_1925 = Add(t_1925, Get(st_631, "off"));
tNow_628 = t_1925;
L_1926 = GetK(LOOK_62, look_565);
E_1927 = NewObj(5).Put("sit", ((V)(1D))).Put("armL", ((V)(64D))).Put("armR", ((V)(64D))).Put("lean", ((V)((-0.3)))).Put("smile", ((V)(0.7))).V;
if ((SEqS(Get(st_631, "phase"), "ride") || SEqS(Get(st_631, "phase"), "ramp"))) {
double ls_1929 = 0;
V dl_1930 = default;
if (Truthy(Get(st_631, "bot"))) {
Call(botSteer_636, V.Undef, t_1925);
}
if (Truthy(Get(st_631, "key"))) {
Set(st_631, "tgt", Call(cl_18, V.Undef, Add(Get(st_631, "tgt"), ((V)(((ToNum(Get(st_631, "key")) * 2.4) * ToNum(dt_1924))))), ((V)((-LMAX_42))), ((V)(LMAX_42))));
}
ls_1929 = ((GtN(Get(st_631, "stun"), 0D) ? 1.3 : 3.2) * ToNum(Get(L_1926, "steer")));
dl_1930 = Call(cl_18, V.Undef, ((V)((ToNum(Get(st_631, "tgt")) - ToNum(Get(st_631, "l"))))), ((V)(((-ls_1929) * ToNum(dt_1924)))), ((V)((ls_1929 * ToNum(dt_1924)))));
OpSet(st_631, "l", 0, dl_1930);
Set(st_631, "steer", Call(lerp_19, V.Undef, (Get(st_631, "steer") is var _t1931 && Truthy(_t1931) ? _t1931 : ((V)(0D))), ((V)(((ToNum(dl_1930) / Max(ToNum(dt_1924), 0.001)) / ls_1929))), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1924)) * 8D)))))));
if (LtN(Get(st_631, "s"), SD0_54)) {
Set(st_631, "v", ((V)(Min(14D, ToNum(Add(Get(st_631, "v"), ((V)((30D * ToNum(dt_1924))))))))));
} else {
if ((LtN(Get(st_631, "v"), (VB_39 + 8D)) && LtN(Get(st_631, "s"), 700D))) {
Set(st_631, "v", ((V)(Min((VB_39 + 8D), ToNum(Add(Get(st_631, "v"), ((V)((34D * ToNum(dt_1924))))))))));
} else {
if (LtN(Get(st_631, "v"), VB_39)) {
Set(st_631, "v", ((V)(Min(VB_39, ToNum(Add(Get(st_631, "v"), ((V)((14D * ToNum(dt_1924))))))))));
} else {
Set(st_631, "v", ((V)(Max(VB_39, (ToNum(Get(st_631, "v")) - (DEC_41 * ToNum(dt_1924)))))));
}
}
}
if (GtN(Get(st_631, "mud"), 0D)) {
Set(st_631, "v", ((V)(Max((VB_39 * 0.8), (ToNum(Get(st_631, "v")) - (24D * ToNum(dt_1924)))))));
OpSet(st_631, "mud", 1, dt_1924);
}
Set(st_631, "v", ((V)(Min(VMAX_40, ToNum(Get(st_631, "v"))))));
Set(st_631, "top", ((V)(Max(ToNum(Get(st_631, "top")), ToNum(Get(st_631, "v"))))));
OpSet(st_631, "s", 0, ((V)(((ToNum(Get(st_631, "v")) * KV_38) * ToNum(dt_1924)))));
Set(st_631, "stun", ((V)(Max(0D, (ToNum(Get(st_631, "stun")) - ToNum(dt_1924))))));
Set(st_631, "boostT", ((V)(Max(0D, (ToNum(Get(st_631, "boostT")) - ToNum(dt_1924))))));
Set(st_631, "punch", ((V)(Max(0D, (ToNum(Get(st_631, "punch")) - (ToNum(dt_1924) * 2.5))))));
if ((SEqS(Get(st_631, "phase"), "ride") && (GtN(Get(st_631, "ha"), 0D) || GtN(Get(st_631, "vh"), 0D)))) {
OpSet(st_631, "vh", 1, ((V)((GA_50 * ToNum(dt_1924)))));
OpSet(st_631, "ha", 0, ((V)((ToNum(Get(st_631, "vh")) * ToNum(dt_1924)))));
if (LeN(Get(st_631, "ha"), 0D)) {
Set(st_631, "ha", ((V)(0D)));
Set(st_631, "vh", ((V)(0D)));
OpSet(st_631, "v", 0, ((V)(2D)));
InvokeSpread(ctx_560, "burst", new ArrBuilder().Spread(Call(scr_632, V.Undef, Get(st_631, "s"), Get(st_631, "l"), Call(HS_58, V.Undef, Get(st_631, "s")))).Add(((V)("drop"))).Add(((V)(6D))).Add(NewObj(2).Put("col", ((V)("#ffffff"))).Put("v", ((V)(70D))).V).V);
Invoke(SFX_21, "tap");
}
}
if ((GeN(Get(st_631, "s"), RS_46) && SEqS(Get(st_631, "phase"), "ride"))) {
Set(st_631, "phase", ((V)("ramp")));
Set(st_631, "ha", ((V)(0D)));
Set(st_631, "vh", ((V)(0D)));
}
Set(st_631, "h", Add(Call(HS_58, V.Undef, Get(st_631, "s")), Get(st_631, "ha")));
if ((!(Truthy(Get(st_631, "toldPool"))) && GtN(Get(st_631, "s"), (RS_46 - 1500D)))) {
Set(st_631, "toldPool", ((V)(1D)));
Invoke(ctx_560, "toast", ((V)("Almost there! Go go go!")), ((V)((ToNum(W_563) / 2D))), ((V)(84D)), ((V)("#ffe36e")));
}
Call(hits_637, V.Undef);
if (GeN(Get(st_631, "s"), LEN_45)) {
Call(launch_638, V.Undef);
}
}
if (SEqS(Get(st_631, "phase"), "fly")) {
V p_1932 = default;
OpSet(st_631, "s", 0, ((V)((ToNum(Get(st_631, "vs")) * ToNum(dt_1924)))));
OpSet(st_631, "vh", 1, ((V)((GF_51 * ToNum(dt_1924)))));
OpSet(st_631, "h", 0, ((V)((ToNum(Get(st_631, "vh")) * ToNum(dt_1924)))));
p_1932 = Call(scr_632, V.Undef, Get(st_631, "s"), Get(st_631, "l"), Get(st_631, "h"));
if (((LtN(GetIdx(p_1932, 1D), (-90D)) || ((ToNum(t_1925) - ToNum(Get(st_631, "tf"))) > 1300D)) && !(Truthy(Get(st_631, "tr"))))) {
Call(transition_639, V.Undef);
}
}
fast_1928 = Call(cl_18, V.Undef, ((V)(((ToNum(Get(st_631, "v")) - 55D) / 50D))), ((V)(0D)), ((V)(1D)));
if (SEqS(Get(st_631, "phase"), "ready")) {
E_1927 = NewObj(6).Put("sit", ((V)(1D))).Put("armL", ((V)((50D + (20D * FdLibm.Sin((ToNum(t_1925) / 260D))))))).Put("armR", ((V)((50D + (20D * FdLibm.Sin(((ToNum(t_1925) / 260D) + 1.4))))))).Put("lean", ((V)((-0.2)))).Put("smile", ((V)(0.8))).Put("sq", ((V)((0.03 * FdLibm.Sin((ToNum(t_1925) / 180D)))))).V;
} else {
if ((SEqS(Get(st_631, "phase"), "ride") || SEqS(Get(st_631, "phase"), "ramp"))) {
V sw_1933 = default;
sw_1933 = (Get(st_631, "steer") is var _t1934 && Truthy(_t1934) ? _t1934 : ((V)(0D)));
E_1927 = NewObj(10).Put("sit", ((V)(1D))).Put("armL", ((V)(((60D + (ToNum(sw_1933) * 25D)) + (ToNum(fast_1928) * 70D))))).Put("armR", ((V)(((60D - (ToNum(sw_1933) * 25D)) + (ToNum(fast_1928) * 70D))))).Put("lean", ((V)(((-0.35) - ((ToNum(Get(st_631, "v")) - VB_39) / 120D))))).Put("smile", ((V)(0.7))).Put("open", ((V)((0.25 + (ToNum(fast_1928) * 0.5))))).Put("close", ((V)((ToNum(fast_1928) * 0.35)))).Put("tilt", ((V)((((-ToNum(sw_1933)) * 9D) + ((FdLibm.Sin((ToNum(t_1925) / 37D)) * ToNum(fast_1928)) * 2.5))))).Put("ly", ((V)((-0.3)))).Put("lx", ((V)(0.6))).V;
if (LtN(Get(st_631, "s"), SD0_54)) {
Object_assign(E_1927, NewObj(5).Put("armL", ((V)((20D + (22D * FdLibm.Sin((ToNum(t_1925) / 90D))))))).Put("armR", ((V)((20D - (22D * FdLibm.Sin((ToNum(t_1925) / 90D))))))).Put("lean", ((V)(0.3))).Put("smile", ((V)(0.9))).Put("sq", ((V)((0.04 * FdLibm.Sin((ToNum(t_1925) / 90D)))))).V);
}
if ((GtN(Get(st_631, "boostT"), 0D) || GtN(Get(st_631, "ha"), 4D))) {
Object_assign(E_1927, NewObj(6).Put("armL", ((V)(158D))).Put("armR", ((V)(152D))).Put("hap", ((V)(1D))).Put("open", ((V)(0.85))).Put("smile", ((V)(1D))).Put("close", ((V)(0D))).V);
}
if (GtN(Get(st_631, "stun"), 0D)) {
double u_1935 = 0;
u_1935 = (ToNum(Get(st_631, "stun")) / 0.6);
Object_assign(E_1927, NewObj(8).Put("tilt", ((V)(((FdLibm.Sin((ToNum(t_1925) / 40D)) * 12D) * u_1935)))).Put("sq", ((V)((0.1 * u_1935)))).Put("armL", ((V)(110D))).Put("armR", ((V)(40D))).Put("open", ((V)(0.5))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("close", ((V)(0D))).V);
}
if (GtN(Get(st_631, "mud"), 0D)) {
Object_assign(E_1927, NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("smile", ((V)(0D))).Put("open", ((V)(0.2))).V);
}
} else {
if (SEqS(Get(st_631, "phase"), "fly")) {
E_1927 = (GeN(Get(st_631, "lipV"), 75D) ? NewObj(8).Put("sit", ((V)(1D))).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("open", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sq", ((V)(0.08))).Put("close", ((V)(0.4))).V : NewObj(9).Put("sit", ((V)(0.6))).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).Put("open", ((V)(0.9))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("lean", ((V)((-0.5)))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V);
}
}
}
if (SEqS(Get(st_631, "phase"), "pool")) {
Invoke(pool_630, "update", dt_1924, t_1925);
return default;
}
Invoke(me_624, "pose", E_1927);
Set(st_631, "yaw", Call(lerp_19, V.Undef, Get(st_631, "yaw"), ((V)((58D + (SEqS(Get(st_631, "phase"), "ride") ? (ToNum(Call(cl_18, V.Undef, (Get(st_631, "steer") is var _t1936 && Truthy(_t1936) ? _t1936 : ((V)(0D))), ((V)((-1D))), ((V)(1D)))) * 16D) : 0D)))), ((V)((1D - FdLibm.Exp(((-ToNum(dt_1924)) * 6D)))))));
Invoke(me_624, "yaw", Get(st_631, "yaw"));
Call(camera_641, V.Undef, dt_1924, t_1925);
Call(place_642, V.Undef, t_1925, dt_1924);
Call(hud__643, V.Undef, dt_1924, t_1925);
Call(windSet_622, V.Undef, Get(st_631, "v"), ((SEqS(Get(st_631, "phase"), "ride") || SEqS(Get(st_631, "phase"), "ramp")) ? V.True : V.False));
return default;
}, 2, "update", false)).V;
Call(reset_633, V.Undef);
Call(camera_641, V.Undef, ((V)(1D)), ((V)(0D)));
Call(place_642, V.Undef, ((V)(0D)), ((V)(0D)));
Call(hud__643, V.Undef, ((V)(0D)), ((V)(0D)));
return api_635;
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
