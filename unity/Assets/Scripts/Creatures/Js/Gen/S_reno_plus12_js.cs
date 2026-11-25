// reno-plus12.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus12_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("(-?\\d*\\.?\\d+) (-?\\d*\\.?\\d+)", "g");
        public static void Run()
        {
Call(Named(boot_250 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V shade_11 = default;
V N_12 = default;
double PI_13 = 0;
V H_14 = default;
V cam_15 = default;
V FR_16 = default;
V vis_17 = default;
V lit_18 = default;
V add_19 = default;
V mul_20 = default;
V rng_21 = default;
V an_22 = default;
V at_23 = default;
V SPL_24 = default;
V f1_25 = default;
V n4_26 = default;
V rep_27 = default;
V P2_28 = default;
V FONT_29 = default;
V pth_30 = default;
V DEF11_31 = default;
V ext_32 = default;
V box3_33 = default;
V cyl3_34 = default;
V sph_35 = default;
V pane_36 = default;
V DEF12_37 = default;
V WD_38 = default;
V wsh_39 = default;
V innerW_40 = default;
V T_41 = default;
V paperFx_42 = default;
V per_43 = default;
V ln_44 = default;
V NZ_45 = default;
V NR_46 = default;
V BL_47 = default;
V BLR_48 = default;
V blot_49 = default;
double BB_50 = 0;
V room_51 = default;
V tile_52 = default;
V outlet_53 = default;
V sDry_54 = default;
V sChar_55 = default;
V sSlat_56 = default;
V sStar_57 = default;
V SURF12_58 = default;
V draw11_59 = default;
V artSpace_60 = default;
V artRocket_61 = default;
V artSaucer_62 = default;
V artRobot_63 = default;
V artMoon_64 = default;
V aNeb_65 = default;
V aInk_66 = default;
V aSq_67 = default;
V GL_68 = default;
V GS_69 = default;
V word_70 = default;
V tube_71 = default;
V edit11_72 = default;
if (_self1.IsNullish) _self1 = GlobalV;
sDry_54 = Fn((V _self73, int _argc74, V _a76, V _a77, V _a78, V _a79, V[] _rest75) => {
V R_80 = default;
JsStrBuf s_81 = null;
V stain_82 = default;
V flake_83 = default;
V crt_84 = default;
if (_self73.IsNullish) _self73 = GlobalV;
R_80 = Call(rng_21, V.Undef, ((V)("dry13")));
s_81 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#c5c3bc\"/>").V(Call(blot_49, V.Undef, ((V)("dry")), ((V)(34D)), Arr(((V)("#d2d0c9")), ((V)("#b6b4ac")), ((V)("#bfbdb5"))), ((V)(0.55)), ((V)(3D)))).End());
Invoke(Arr(((V)(0D)), ((V)(26.67)), ((V)(53.33)), ((V)(80D))), "forEach", Fn((V _arrowThis92, int _argc85, V x_91, V _a88, V _a89, V _a90, V[] _rest86) => {
return ((V)(s_81.S("<rect x=\"").V(Call(f1_25, V.Undef, ((V)((ToNum(x_91) - 1.1))))).S("\" width=\"2.2\" height=\"56\" fill=\"#d5d3cc\" opacity=\"0.8\"/><path d=\"M").V(Call(f1_25, V.Undef, ((V)((ToNum(x_91) - 1.1))))).S(" 0V56M").V(Call(f1_25, V.Undef, Add(x_91, ((V)(1.1))))).S(" 0V56\" stroke=\"#adaba3\" stroke-width=\"0.12\" opacity=\"0.7\"/>").Str));
}, 1, "", true));
Invoke(Arr(((V)(8.9)), ((V)(17.8)), ((V)(35.6)), ((V)(44.4)), ((V)(62.2)), ((V)(71.1))), "forEach", Fn((V _arrowThis100, int _argc93, V x_99, V _a96, V _a97, V _a98, V[] _rest94) => {
{
double y_101 = 0;
y_101 = 3.2;
while (true) {
if (!((y_101 < 53D))) break;
s_81.S("<circle cx=\"").V(Call(f1_25, V.Undef, x_99)).S("\" cy=\"").V(Call(f1_25, V.Undef, ((V)(y_101)))).S("\" r=\"0.26\" fill=\"#a4a29a\"/><circle cx=\"").V(Call(f1_25, V.Undef, ((V)((ToNum(x_99) - 0.07))))).S("\" cy=\"").V(Call(f1_25, V.Undef, ((V)((y_101 - 0.07))))).S("\" r=\"0.1\" fill=\"#e4e2dc\"/>");
y_101 = (y_101 + 6.4);
}
}
return default;
}, 1, "", true));
stain_82 = Fn((V _arrowThis112, int _argc103, V x0_109, V w_110, V h_111, V _a108, V[] _rest104) => {
JsStrBuf d_113 = null;
d_113 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(f1_25, V.Undef, x0_109)).S(" 56").End());
Call(rep_27, V.Undef, ((V)(7D)), Fn((V _arrowThis121, int _argc114, V i_120, V _a117, V _a118, V _a119, V[] _rest115) => {
d_113.S("L").V(Call(f1_25, V.Undef, Add(x0_109, ((V)(((ToNum(w_110) * ToNum(i_120)) / 6D)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((54D - ((ToNum(h_111) * Pow(FdLibm.Sin(((PI_13 * ToNum(i_120)) / 6D)), 0.6)) * (0.8 + (0.2 * ToNum(Call(R_80, V.Undef))))))))));
return default;
}, 1, "", true));
d_113.S("L").V(Call(f1_25, V.Undef, Add(x0_109, w_110))).S(" 56Z");
return ((V)(JsStrBuf.Begin().S("<path d=\"").S(d_113.Str).S("\" fill=\"#9d9174\" opacity=\"0.22\" filter=\"url(#wb2)\"/><path d=\"").S(d_113.Str).S("\" fill=\"none\" stroke=\"#857553\" stroke-width=\"0.3\" opacity=\"0.32\" filter=\"url(#wb1)\"/>").End()));
return default;
}, 3, "", true);
s_81.V(Add(Call(stain_82, V.Undef, ((V)(3D)), ((V)(16D)), ((V)(8D))), Call(stain_82, V.Undef, ((V)(57D)), ((V)(9D)), ((V)(4.5)))));
flake_83 = Fn((V _arrowThis131, int _argc122, V x_128, V y_129, V r_130, V _a127, V[] _rest123) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_25, V.Undef, ((V)((ToNum(x_128) - ToNum(r_130)))))).S(" ").V(Call(f1_25, V.Undef, y_129)).S("Q").V(Call(f1_25, V.Undef, ((V)((ToNum(x_128) - (ToNum(r_130) * 0.4)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((ToNum(y_129) - (ToNum(r_130) * 0.9)))))).S(" ").V(Call(f1_25, V.Undef, Add(x_128, ((V)((ToNum(r_130) * 0.6)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((ToNum(y_129) - (ToNum(r_130) * 0.6)))))).S("Q").V(Call(f1_25, V.Undef, Add(x_128, r_130))).S(" ").V(Call(f1_25, V.Undef, Add(y_129, ((V)((ToNum(r_130) * 0.2)))))).S(" ").V(Call(f1_25, V.Undef, Add(x_128, ((V)((ToNum(r_130) * 0.2)))))).S(" ").V(Call(f1_25, V.Undef, Add(y_129, ((V)((ToNum(r_130) * 0.7)))))).S("Q").V(Call(f1_25, V.Undef, ((V)((ToNum(x_128) - (ToNum(r_130) * 0.6)))))).S(" ").V(Call(f1_25, V.Undef, Add(y_129, ((V)((ToNum(r_130) * 0.8)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((ToNum(x_128) - ToNum(r_130)))))).S(" ").V(Call(f1_25, V.Undef, y_129)).S("Z\" fill=\"#aa9878\"/>").S("<path d=\"M").V(Call(f1_25, V.Undef, Add(x_128, ((V)((ToNum(r_130) * 0.6)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((ToNum(y_129) - (ToNum(r_130) * 0.6)))))).S("Q").V(Call(f1_25, V.Undef, Add(x_128, ((V)((ToNum(r_130) * 1.5)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((ToNum(y_129) - (ToNum(r_130) * 1.2)))))).S(" ").V(Call(f1_25, V.Undef, Add(x_128, ((V)((ToNum(r_130) * 1.4)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((ToNum(y_129) - (ToNum(r_130) * 0.1)))))).S("Q").V(Call(f1_25, V.Undef, Add(x_128, r_130))).S(" ").V(Call(f1_25, V.Undef, ((V)((ToNum(y_129) - (ToNum(r_130) * 0.5)))))).S(" ").V(Call(f1_25, V.Undef, Add(x_128, ((V)((ToNum(r_130) * 0.6)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((ToNum(y_129) - (ToNum(r_130) * 0.6)))))).S("Z\" fill=\"#eeece6\" stroke=\"#b1afa7\" stroke-width=\"0.1\"/>").End()));
}, 3, "", true);
s_81.V(Add(Add(Add(Call(flake_83, V.Undef, ((V)(23.5)), ((V)(11D)), ((V)(1D))), Call(flake_83, V.Undef, ((V)(50.5)), ((V)(37D)), ((V)(0.75)))), Call(flake_83, V.Undef, ((V)(9.5)), ((V)(29D)), ((V)(0.65)))), Call(flake_83, V.Undef, ((V)(75D)), ((V)(42D)), ((V)(0.6)))));
crt_84 = Fn((V _arrowThis141, int _argc132, V x_138, V y_139, V rot_140, V _a137, V[] _rest133) => {
JsStrBuf o_142 = null;
o_142 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"translate(").V(x_138).S(" ").V(y_139).S(") rotate(").V(rot_140).S(" 3 2.1)\"><rect x=\"0.35\" y=\"0.5\" width=\"6\" height=\"4.2\" rx=\"0.4\" fill=\"#000000\" opacity=\"0.24\" filter=\"url(#wb1)\"/><rect width=\"6\" height=\"4.2\" rx=\"0.4\" fill=\"#8c8e8d\"/>").End());
{
double j_143 = 0;
j_143 = 0D;
while (true) {
if (!((j_143 < 2D))) break;
{
double i_145 = 0;
i_145 = 0D;
while (true) {
if (!((i_145 < 3D))) break;
o_142.S("<circle cx=\"").N((1D + (i_145 * 2D))).S("\" cy=\"").V(Call(f1_25, V.Undef, ((V)((1.05 + (j_143 * 2.1)))))).S("\" r=\"0.82\" fill=\"url(#dpk)\"/>");
i_145++;
}
}
j_143++;
}
}
return ((V)(string.Concat(o_142.Str, "<rect width=\"6\" height=\"0.35\" rx=\"0.2\" fill=\"#ffffff\" opacity=\"0.2\"/></g>")));
return default;
}, 3, "", true);
Invoke(Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0D))), Arr(((V)(1D)), ((V)(0D)), ((V)(1D))), Arr(((V)(2D)), ((V)(0D)), ((V)((-1D)))), Arr(((V)(0D)), ((V)(1D)), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)), ((V)(0D)))), "forEach", Fn((V _arrowThis160, int _argc147, V _a149, V _a150, V _a151, V _a152, V[] _rest148) => {
V i_155 = default;
V j_157 = default;
V r_159 = default;
{ V _t153 = ListOf(_a149);
{ V _t154 = GetIdx(_t153, 0D);
i_155 = _t154; }
{ V _t156 = GetIdx(_t153, 1D);
j_157 = _t156; }
{ V _t158 = GetIdx(_t153, 2D);
r_159 = _t158; }
}
return ((V)(s_81.V(Call(crt_84, V.Undef, ((V)((30D + (ToNum(i_155) * 6.3)))), ((V)((21D + (ToNum(j_157) * 4.5)))), r_159)).Str));
}, 1, "", true));
s_81.V(Add(Add(Call(crt_84, V.Undef, ((V)(44.2)), ((V)(30.8)), ((V)(9D))), Call(crt_84, V.Undef, ((V)(66D)), ((V)(13.6)), ((V)((-3D))))), Call(crt_84, V.Undef, ((V)(72.4)), ((V)(14.1)), ((V)(2D)))));
s_81.V(Call(outlet_53, V.Undef, ((V)(60.5)), ((V)(46.2)), ((V)("#e6e4dd")), ((V)("#5a5852"))));
return NewObj(4).Put("mat", ((V)(s_81.Str))).Put("defs", ((V)("<radialGradient id=\"dpk\" cx=\"38%\" cy=\"34%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#a9acb0\"/><stop offset=\"1\" stop-color=\"#6a6d72\"/></radialGradient>"))).Put("board", ((V)("#a7a59e"))).Put("ro", NewObj(3).Put("top", ((V)(0.07))).Put("ao", ((V)(0.12))).Put("board", Invoke(Call(rep_27, V.Undef, ((V)(26D)), Fn((V _arrowThis167, int _argc161, V _a163, V _a164, V _a165, V _a166, V[] _rest162) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_25, V.Undef, ((V)((ToNum(Call(R_80, V.Undef)) * 80D))))).S("\" cy=\"").V(Call(f1_25, V.Undef, ((V)(((BB_50 + 0.6) + (ToNum(Call(R_80, V.Undef)) * 1.6)))))).S("\" r=\"").V(Call(f1_25, V.Undef, ((V)((0.14 + (ToNum(Call(R_80, V.Undef)) * 0.16)))))).S("\" fill=\"").S((LtN(Call(R_80, V.Undef), 0.5) ? "#8d8b84" : "#c9c7c0")).S("\"/>").End()));
}, 0, "", true)), "join", ((V)("")))).V).V;
return default;
}, 0, "sDry", false);
sChar_55 = Fn((V _self168, int _argc169, V _a171, V _a172, V _a173, V _a174, V[] _rest170) => {
V R_175 = default;
JsStrBuf s_176 = null;
if (_self168.IsNullish) _self168 = GlobalV;
R_175 = Call(rng_21, V.Undef, ((V)("char13")));
s_176 = new JsStrBuf("<rect width=\"80\" height=\"56\" fill=\"#4a4e57\"/>");
{
double i_177 = 0;
i_177 = 0D;
while (true) {
if (!((i_177 < 16D))) break;
s_176.S("<rect x=\"").N((i_177 * 5D)).S("\" width=\"5\" height=\"56\" fill=\"").S((NumTruthy((i_177 % 2D)) ? "#ffffff" : "#000000")).S("\" opacity=\"").V(Call(f1_25, V.Undef, ((V)((0.005 + (ToNum(Call(R_175, V.Undef)) * 0.008)))))).S("\"/>");
i_177++;
}
}
s_176.V(Call(blot_49, V.Undef, ((V)("char")), ((V)(28D)), Arr(((V)("#535761")), ((V)("#40444c"))), ((V)(0.5)), ((V)(3D)))).S("<rect width=\"80\" height=\"56\" fill=\"url(#chs)\"/>");
s_176.V(Call(outlet_53, V.Undef, ((V)(21D)), ((V)(46.4)), ((V)("#3c3f46")), ((V)("#16171a"))));
s_176.S("<g filter=\"url(#wb2)\"><ellipse cx=\"61\" cy=\"52.6\" rx=\"3.4\" ry=\"1.6\" fill=\"#ffc27a\" opacity=\"0.35\">").V(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.3;0.42;0.3")), ((V)(4D)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))).S("</ellipse></g><rect x=\"60\" y=\"49.6\" width=\"2\" height=\"1.1\" rx=\"0.25\" fill=\"#1c1d21\"/><rect x=\"60.3\" y=\"50.15\" width=\"1.4\" height=\"0.4\" rx=\"0.15\" fill=\"#ffd9a0\"/>");
return NewObj(4).Put("mat", ((V)(s_176.Str))).Put("defs", ((V)("<pattern id=\"chs\" width=\"1.6\" height=\"1.6\" patternUnits=\"userSpaceOnUse\"><circle cx=\"0.4\" cy=\"0.5\" r=\"0.2\" fill=\"#000000\" fill-opacity=\"0.1\"/><circle cx=\"1.2\" cy=\"1.2\" r=\"0.16\" fill=\"#ffffff\" fill-opacity=\"0.05\"/></pattern>"))).Put("board", ((V)("#2a2d32"))).Put("ro", NewObj(3).Put("top", ((V)(0.05))).Put("ao", ((V)(0.1))).Put("board", ((V)(JsStrBuf.Begin().S("<rect y=\"").N((BB_50 + 0.45)).S("\" width=\"80\" height=\"0.35\" fill=\"#5a5e66\" opacity=\"0.55\"/>").End()))).V).V;
return default;
}, 0, "sChar", false);
sSlat_56 = Fn((V _self179, int _argc180, V _a182, V _a183, V _a184, V _a185, V[] _rest181) => {
double PD_186 = 0;
double SW_187 = 0;
V PC_188 = default;
V R_189 = default;
V defs_190 = default;
JsStrBuf s_191 = null;
if (_self179.IsNullish) _self179 = GlobalV;
PD_186 = 3.2;
SW_187 = 2.3;
PC_188 = Arr(((V)("#704329")), ((V)("#7c4a2c")), ((V)("#663c24")), ((V)("#82502f")), ((V)("#6b4027")));
R_189 = Call(rng_21, V.Undef, ((V)("slat13")));
defs_190 = ((V)(JsStrBuf.Begin().S("<linearGradient id=\"sg\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffcf7a\" stop-opacity=\"0.75\"/><stop offset=\"0.25\" stop-color=\"#ffab3a\" stop-opacity=\"0.28\"/><stop offset=\"0.65\" stop-color=\"#ff9a2a\" stop-opacity=\"0.22\"/><stop offset=\"0.95\" stop-color=\"#ffcf7a\" stop-opacity=\"0.95\"/></linearGradient>").V(Invoke(Invoke(PC_188, "map", Fn((V _arrowThis200, int _argc192, V c_198, V i_199, V _a196, V _a197, V[] _rest193) => {
return ((V)(JsStrBuf.Begin().S("<linearGradient id=\"sw").V(i_199).S("\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"").V(Call(shade_11, V.Undef, c_198, ((V)(1.24)))).S("\"/><stop offset=\"0.35\" stop-color=\"").V(c_198).S("\"/><stop offset=\"1\" stop-color=\"").V(Call(shade_11, V.Undef, c_198, ((V)(0.74)))).S("\"/></linearGradient>").End()));
}, 2, "", true)), "join", ((V)("")))).End()));
s_191 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#1d120b\"/><g>").V(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.65;1;0.65")), ((V)(7D)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))).S("<rect width=\"80\" height=\"56\" fill=\"url(#sg)\"/></g>").End());
{
double i_201 = 0;
i_201 = 0D;
while (true) {
if (!((i_201 < 25D))) break;
double x0_203 = 0;
double c_204 = 0;
x0_203 = ((i_201 * PD_186) + ((PD_186 - SW_187) / 2D));
c_204 = (i_201 % 5D);
s_191.S("<rect x=\"").V(Call(f1_25, V.Undef, ((V)((x0_203 + SW_187))))).S("\" width=\"0.35\" height=\"56\" fill=\"#000000\" opacity=\"0.35\"/><rect x=\"").V(Call(f1_25, V.Undef, ((V)(x0_203)))).S("\" width=\"").N(SW_187).S("\" height=\"56\" fill=\"url(#sw").N(c_204).S(")\"/><path d=\"").V(Call(ln_44, V.Undef, Call(per_43, V.Undef, ((V)(((x0_203 + 0.7) + (ToNum(Call(R_189, V.Undef)) * 0.9)))), ((V)(0.12)), ((V)((ToNum(Call(R_189, V.Undef)) * 6D)))))).S("\" stroke=\"").V(Call(shade_11, V.Undef, GetIdx(PC_188, c_204), ((V)(0.68)))).S("\" stroke-opacity=\"0.5\" stroke-width=\"0.14\" fill=\"none\"/>");
i_201++;
}
}
return NewObj(4).Put("mat", ((V)(s_191.Str))).Put("defs", defs_190).Put("board", ((V)("#3b2213"))).Put("ro", NewObj(3).Put("top", ((V)(0.05))).Put("ao", ((V)(0.08))).Put("board", ((V)(JsStrBuf.Begin().S("<rect y=\"").N((BB_50 - 3D)).S("\" width=\"80\" height=\"3\" fill=\"#ffcf7a\" opacity=\"0.4\" filter=\"url(#wb2)\">").V(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.3;0.55;0.3")), ((V)(4D)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))).S("</rect><rect y=\"").N((BB_50 - 0.5)).S("\" width=\"80\" height=\"0.5\" fill=\"#ffe7b8\"/>").End()))).V).V;
return default;
}, 0, "sSlat", false);
sStar_57 = Fn((V _self205, int _argc206, V _a208, V _a209, V _a210, V _a211, V[] _rest207) => {
V R_212 = default;
JsStrBuf s_213 = null;
V COL_214 = default;
double n_215 = 0;
if (_self205.IsNullish) _self205 = GlobalV;
R_212 = Call(rng_21, V.Undef, ((V)("star13")));
s_213 = new JsStrBuf("<rect width=\"80\" height=\"56\" fill=\"#0c0a16\"/>");
{
double j_216 = 0;
j_216 = 0D;
while (true) {
if (!((j_216 < 7D))) break;
{
double i_218 = 0;
i_218 = 0D;
while (true) {
if (!((i_218 < 10D))) break;
double x_220 = 0;
double y_221 = 0;
x_220 = ((i_218 * 8D) + 0.3);
y_221 = ((j_216 * 8D) + 0.3);
s_213.S("<rect x=\"").V(Call(f1_25, V.Undef, ((V)(x_220)))).S("\" y=\"").V(Call(f1_25, V.Undef, ((V)(y_221)))).S("\" width=\"7.4\" height=\"7.4\" rx=\"1.3\" fill=\"url(#spg)\"/><rect x=\"").V(Call(f1_25, V.Undef, ((V)((x_220 + 0.6))))).S("\" y=\"").V(Call(f1_25, V.Undef, ((V)((y_221 + 0.5))))).S("\" width=\"6.2\" height=\"2.4\" rx=\"1\" fill=\"#ffffff\" opacity=\"0.05\"/><circle cx=\"").V(Call(f1_25, V.Undef, ((V)((x_220 + 3.7))))).S("\" cy=\"").V(Call(f1_25, V.Undef, ((V)((y_221 + 3.7))))).S("\" r=\"0.22\" fill=\"#0c0a16\" opacity=\"0.55\"/>");
i_218++;
}
}
j_216++;
}
}
s_213.S("<path d=\"").V(Invoke(Call(rep_27, V.Undef, ((V)(10D)), Fn((V _arrowThis229, int _argc222, V i_228, V _a225, V _a226, V _a227, V[] _rest223) => {
return ((V)(JsStrBuf.Begin().S("M").N((ToNum(i_228) * 8D)).S(" 0V56").End()));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Call(rep_27, V.Undef, ((V)(7D)), Fn((V _arrowThis237, int _argc230, V j_236, V _a233, V _a234, V _a235, V[] _rest231) => {
return ((V)(JsStrBuf.Begin().S("M0 ").N((ToNum(j_236) * 8D)).S("H80").End()));
}, 1, "", true)), "join", ((V)("")))).S("\" stroke=\"#7a6cff\" stroke-width=\"0.14\" fill=\"none\" opacity=\"0.3\">").V(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.18;0.4;0.18")), ((V)(4D)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))).S("</path>");
COL_214 = Arr(((V)("#fff4dc")), ((V)("#cfe6ff")), ((V)("#ffffff")), ((V)("#ffd6ef")));
n_215 = 0D;
while ((n_215 < 90D)) {
double x_238 = 0;
double y_239 = 0;
double mx_240 = 0;
double my_241 = 0;
V col_242 = default;
V A_243 = default;
x_238 = (0.6 + (ToNum(Call(R_212, V.Undef)) * 78.8));
y_239 = (0.6 + (ToNum(Call(R_212, V.Undef)) * 52D));
mx_240 = (x_238 % 8D);
my_241 = (y_239 % 8D);
if ((((((mx_240 < 0.9) || (mx_240 > 7.1)) || (my_241 < 0.9)) || (my_241 > 7.1)) || ((System.Math.Abs((mx_240 - 3.7)) < 0.5) && (System.Math.Abs((my_241 - 3.7)) < 0.5)))) {
continue;
}
n_215++;
col_242 = GetIdx(COL_214, (n_215 % 4D));
A_243 = Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.2;1;0.2")), Call(n4_26, V.Undef, ((V)((1.8 + (ToNum(Call(R_212, V.Undef)) * 3D))))), Call(n4_26, V.Undef, ((V)(((-ToNum(Call(R_212, V.Undef))) * 4D)))));
if (((n_215 % 9D) == 0D)) {
double r_244 = 0;
r_244 = 0.55;
s_213.S("<path d=\"M").V(Call(f1_25, V.Undef, ((V)(x_238)))).S(" ").V(Call(f1_25, V.Undef, ((V)((y_239 - r_244))))).S("Q").V(Call(f1_25, V.Undef, ((V)((x_238 + (r_244 * 0.18)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((y_239 - (r_244 * 0.18)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((x_238 + r_244))))).S(" ").V(Call(f1_25, V.Undef, ((V)(y_239)))).S("Q").V(Call(f1_25, V.Undef, ((V)((x_238 + (r_244 * 0.18)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((y_239 + (r_244 * 0.18)))))).S(" ").V(Call(f1_25, V.Undef, ((V)(x_238)))).S(" ").V(Call(f1_25, V.Undef, ((V)((y_239 + r_244))))).S("Q").V(Call(f1_25, V.Undef, ((V)((x_238 - (r_244 * 0.18)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((y_239 + (r_244 * 0.18)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((x_238 - r_244))))).S(" ").V(Call(f1_25, V.Undef, ((V)(y_239)))).S("Q").V(Call(f1_25, V.Undef, ((V)((x_238 - (r_244 * 0.18)))))).S(" ").V(Call(f1_25, V.Undef, ((V)((y_239 - (r_244 * 0.18)))))).S(" ").V(Call(f1_25, V.Undef, ((V)(x_238)))).S(" ").V(Call(f1_25, V.Undef, ((V)((y_239 - r_244))))).S("Z\" fill=\"").V(col_242).S("\">").V(A_243).S("</path>");
} else {
s_213.S("<circle cx=\"").V(Call(f1_25, V.Undef, ((V)(x_238)))).S("\" cy=\"").V(Call(f1_25, V.Undef, ((V)(y_239)))).S("\" r=\"").V(Call(f1_25, V.Undef, ((V)((0.12 + (ToNum(Call(R_212, V.Undef)) * 0.18)))))).S("\" fill=\"").V(col_242).S("\">").V(A_243).S("</circle>");
}
}
s_213.S("<g opacity=\"0\"><path d=\"M0 0L-3.6 -0.25L-3.6 0.25Z\" fill=\"#ffffff\" transform=\"translate(18 9) rotate(22)\"/><circle cx=\"18\" cy=\"9\" r=\"0.3\" fill=\"#ffffff\"/>").V(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0;0;1;0;0")), ((V)(13D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.84;0.87;0.92;1\"")))).V(Call(at_23, V.Undef, ((V)("translate")), ((V)("0 0;0 0;6 2.5;11 4.5;11 4.5")), ((V)(13D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.84;0.87;0.92;1\"")))).S("</g>");
return NewObj(4).Put("mat", ((V)(s_213.Str))).Put("defs", ((V)("<linearGradient id=\"spg\" x1=\"0\" y1=\"0\" x2=\"0.3\" y2=\"1\"><stop offset=\"0\" stop-color=\"#2f2852\"/><stop offset=\"1\" stop-color=\"#1a1530\"/></linearGradient>"))).Put("board", ((V)("#0e0b1e"))).Put("ro", NewObj(3).Put("top", ((V)(0.05))).Put("ao", ((V)(0.08))).Put("board", ((V)(JsStrBuf.Begin().S("<rect y=\"").N((BB_50 - 2.4)).S("\" width=\"80\" height=\"2.6\" fill=\"#7a6cff\" opacity=\"0.35\" filter=\"url(#wb2)\">").V(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.2;0.5;0.2")), ((V)(4D)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))).S("</rect><rect y=\"").N((BB_50 + 0.5)).S("\" width=\"80\" height=\"0.35\" fill=\"#a49bff\"/>").End()))).V).V;
return default;
}, 0, "sStar", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((((RD_8 is var _t245 && !Truthy(_t245) ? _t245 : Get(RD_8, "PLUS11")) is var _t246 && !Truthy(_t246) ? _t246 : Get(RD_8, "H11")) is var _t247 && !Truthy(_t247) ? _t247 : Get(RD_8, "H10")) is var _t248 && !Truthy(_t248) ? _t248 : X_9) is var _t249 && !Truthy(_t249) ? _t249 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_250.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS12"))) {
return default;
}
K_10 = Get(X_9, "K");
shade_11 = Get(K_10, "shade");
N_12 = Get(RD_8, "N");
PI_13 = System.Math.PI;
H_14 = Get(RD_8, "H10");
{ V _t251 = H_14;
if (_t251.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t251));
{ V _t252 = Get(_t251, "cam");
cam_15 = _t252; }
{ V _t253 = Get(_t251, "FR");
FR_16 = _t253; }
{ V _t254 = Get(_t251, "vis");
vis_17 = _t254; }
{ V _t255 = Get(_t251, "lit");
lit_18 = _t255; }
{ V _t256 = Get(_t251, "add");
add_19 = _t256; }
{ V _t257 = Get(_t251, "mul");
mul_20 = _t257; }
{ V _t258 = Get(_t251, "rng");
rng_21 = _t258; }
{ V _t259 = Get(_t251, "an");
an_22 = _t259; }
{ V _t260 = Get(_t251, "at");
at_23 = _t260; }
{ V _t261 = Get(_t251, "SPL");
SPL_24 = _t261; }
{ V _t262 = Get(_t251, "f1");
f1_25 = _t262; }
{ V _t263 = Get(_t251, "n4");
n4_26 = _t263; }
{ V _t264 = Get(_t251, "rep");
rep_27 = _t264; }
{ V _t265 = Get(_t251, "P2");
P2_28 = _t265; }
{ V _t266 = Get(_t251, "FONT");
FONT_29 = _t266; }
{ V _t267 = Get(_t251, "pth");
pth_30 = _t267; } }
{ V _t268 = Get(RD_8, "H11");
if (_t268.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t268));
{ V _t269 = Get(_t268, "DEF11");
DEF11_31 = _t269; }
{ V _t270 = Get(_t268, "ext");
ext_32 = _t270; } }
box3_33 = Fn((V _arrowThis279, int _argc271, V C_277, V o_278, V _a275, V _a276, V[] _rest272) => {
return Invoke(H_14, "box3", C_277, Object_assign(NewObj(0).V, o_278, NewObj(7).Put("mat", V.Null).Put("tpat", V.Null).Put("gl", ((V)((Truthy(Get(o_278, "gl")) ? Min(ToNum(Get(o_278, "gl")), 0.2) : 0D)))).Put("olw", ((V)(1D))).Put("olo", ((V)(0.95))).Put("olc", (Truthy((((Get(o_278, "olc") is var _t280 && !Truthy(_t280) ? _t280 : (!SEqS(Get(o_278, "olc"), "#050506") ? V.True : V.False)) is var _t281 && !Truthy(_t281) ? _t281 : (!SEqS(Get(o_278, "olc"), "#050608") ? V.True : V.False)) is var _t282 && !Truthy(_t282) ? _t282 : (!SEqS(Get(o_278, "olc"), "#020203") ? V.True : V.False))) ? Get(o_278, "olc") : Call(shade_11, V.Undef, Get(o_278, "col"), ((V)(0.32))))).Put("edge", ((V)(0.5))).V));
}, 2, "", true);
cyl3_34 = Fn((V _arrowThis295, int _argc283, V C_289, V a_290, V b_291, V r_292, V[] _rest284) => {
V col_293 = default;
V o_294 = default;
col_293 = (_argc283 > 4 ? _rest284[0] : V.Undef);
o_294 = (_argc283 > 5 ? _rest284[1] : V.Undef);
return Invoke(H_14, "cyl3", C_289, a_290, b_291, r_292, col_293, Object_assign(NewObj(0).V, (o_294 is var _t296 && Truthy(_t296) ? _t296 : NewObj(0).V), NewObj(4).Put("mat", ((V)((Truthy((o_294 is var _t297 && !Truthy(_t297) ? _t297 : (SEqS(Get(o_294, "mat"), "gloss") ? V.True : V.False))) ? "gloss" : "plastic")))).Put("pat", V.Null).Put("olw", ((V)(0.8))).Put("olo", ((V)(0.95))).V));
}, 6, "", true);
sph_35 = Fn((V _arrowThis309, int _argc298, V C_304, V q_305, V r_306, V col_307, V[] _rest299) => {
V c_310 = default;
V o_308 = default;
o_308 = (_argc298 > 4 ? _rest299[0] : V.Undef);
c_310 = Invoke(C_304, "P", q_305);
return ((V)(JsStrBuf.Begin().V(Invoke(H_14, "sph", C_304, q_305, r_306, col_307, o_308)).S(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, GetIdx(c_310, 0D))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, GetIdx(c_310, 1D))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(r_306) * ToNum(Get(C_304, "k"))))))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_11, V.Undef, col_307, ((V)(0.35)))), "\" stroke-width=\"0.5\"/>")).End()));
return default;
}, 5, "", true);
pane_36 = Fn((V _arrowThis324, int _argc311, V C_317, V O_318, V U_319, V V_320, V[] _rest312) => {
V w_321 = default;
V h_322 = default;
V o_323 = default;
w_321 = (_argc311 > 4 ? _rest312[0] : V.Undef);
h_322 = (_argc311 > 5 ? _rest312[1] : V.Undef);
o_323 = (_argc311 > 6 ? _rest312[2] : V.Undef);
return Invoke(Get(RD_8, "H11"), "pane", C_317, O_318, U_319, V_320, w_321, h_322, Object_assign(NewObj(0).V, o_323, NewObj(3).Put("g", ((V)(0.3))).Put("e", ((V)(0.12))).Put("t", ((V)(0.03))).V));
}, 7, "", true);
DEF12_37 = ((V)(JsStrBuf.Begin().V(DEF11_31).S("<pattern id=\"m12ht\" width=\"1.4\" height=\"1.4\" patternUnits=\"userSpaceOnUse\"><circle cx=\"0.7\" cy=\"0.7\" r=\"0.32\" fill=\"#3a2a10\" fill-opacity=\"0.13\"/></pattern>").S("<pattern id=\"m12scan\" width=\"2\" height=\"0.9\" patternUnits=\"userSpaceOnUse\"><rect width=\"2\" height=\"0.3\" fill=\"#ffffff\" fill-opacity=\"0.08\"/></pattern>").S("<linearGradient id=\"m12sh\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#d8fcff\" stop-opacity=\"0.3\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>").S("<linearGradient id=\"m12rt\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"0.42\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0\"/></linearGradient>").S("<linearGradient id=\"m12rl\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"0.32\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0\"/></linearGradient>").S("<linearGradient id=\"m12gl\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.12\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.14\"/></linearGradient>").S("<filter id=\"m12b1\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"0.55\"/></filter><filter id=\"m12b2\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"1.4\"/></filter>").End()));
WD_38 = Fn((V _arrowThis338, int _argc325, V C_331, V x_332, V y_333, V z_334, V[] _rest326) => {
V s_335 = default;
V w_336 = default;
V h_337 = default;
s_335 = (_argc325 > 4 ? _rest326[0] : V.Undef);
w_336 = (_argc325 > 5 ? _rest326[1] : V.Undef);
h_337 = (_argc325 > 6 ? _rest326[2] : V.Undef);
if (Truthy(w_336)) {
Call(ext_32, V.Undef, C_331, Arr(Arr(x_332, y_333, z_334), Arr(Add(x_332, w_336), ((V)((ToNum(y_333) - ToNum(h_337)))), z_334)));
}
return ((V)(string.Concat("<g transform=\"", ToStr(Call(FR_16, V.Undef, C_331, Arr(x_332, y_333, z_334), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\">", ToStr(s_335), "</g>")));
return default;
}, 7, "", true);
wsh_39 = Fn((V _arrowThis351, int _argc339, V C_345, V x_346, V y_347, V w_348, V[] _rest340) => {
V h_349 = default;
V o_350 = default;
h_349 = (_argc339 > 4 ? _rest340[0] : V.Undef);
o_350 = (_argc339 > 5 ? _rest340[1] : V.Undef);
return Call(WD_38, V.Undef, C_345, Add(x_346, (Get(o_350, "dx").IsNullish ? ((V)(1.6)) : Get(o_350, "dx"))), ((V)((ToNum(y_347) - ToNum((Get(o_350, "dy").IsNullish ? ((V)(2.4)) : Get(o_350, "dy")))))), ((V)(0.06)), ((V)(string.Concat("<rect width=\"", ToStr(Call(f1_25, V.Undef, w_348)), "\" height=\"", ToStr(Call(f1_25, V.Undef, h_349)), "\" rx=\"", ToStr((Get(o_350, "r") is var _t352 && Truthy(_t352) ? _t352 : ((V)(1D)))), "\" fill=\"#000000\" opacity=\"", ToStr((Get(o_350, "op") is var _t353 && Truthy(_t353) ? _t353 : ((V)(0.4)))), "\" filter=\"url(#", ToStr((Get(o_350, "f") is var _t354 && Truthy(_t354) ? _t354 : ((V)("m10b3")))), ")\"/>"))));
}, 6, "", true);
innerW_40 = Fn((V _arrowThis370, int _argc355, V C_361, V x0_362, V x1_363, V yb_364, V[] _rest356) => {
V yt_365 = default;
V z0_366 = default;
V z1_367 = default;
V col_368 = default;
V f_369 = default;
yt_365 = (_argc355 > 4 ? _rest356[0] : V.Undef);
z0_366 = (_argc355 > 5 ? _rest356[1] : V.Undef);
z1_367 = (_argc355 > 6 ? _rest356[2] : V.Undef);
col_368 = (_argc355 > 7 ? _rest356[3] : V.Undef);
f_369 = (_argc355 > 8 ? _rest356[4] : V.Undef);
return Invoke(Invoke(Invoke(Arr(Arr(Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), Arr(Arr(x0_362, yb_364, z0_366), Arr(x1_363, yb_364, z0_366), Arr(x1_363, yb_364, z1_367), Arr(x0_362, yb_364, z1_367))), Arr(Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))), Arr(Arr(x0_362, yt_365, z0_366), Arr(x1_363, yt_365, z0_366), Arr(x1_363, yt_365, z1_367), Arr(x0_362, yt_365, z1_367))), Arr(Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(Arr(x0_362, yb_364, z0_366), Arr(x0_362, yt_365, z0_366), Arr(x0_362, yt_365, z1_367), Arr(x0_362, yb_364, z1_367))), Arr(Arr(((V)((-1D))), ((V)(0D)), ((V)(0D))), Arr(Arr(x1_363, yb_364, z0_366), Arr(x1_363, yt_365, z0_366), Arr(x1_363, yt_365, z1_367), Arr(x1_363, yb_364, z1_367)))), "filter", Fn((V _arrowThis394, int _argc385, V _a387, V _a388, V _a389, V _a390, V[] _rest386) => {
V n_393 = default;
{ V _t391 = ListOf(_a387);
{ V _t392 = GetIdx(_t391, 0D);
n_393 = _t392; }
}
return Call(vis_17, V.Undef, C_361, n_393);
}, 1, "", true)), "map", Fn((V _arrowThis382, int _argc371, V _a373, V _a374, V _a375, V _a376, V[] _rest372) => {
V c_383 = default;
V n_379 = default;
V Q_381 = default;
{ V _t377 = ListOf(_a373);
{ V _t378 = GetIdx(_t377, 0D);
n_379 = _t378; }
{ V _t380 = GetIdx(_t377, 1D);
Q_381 = _t380; }
}
c_383 = Call(shade_11, V.Undef, col_368, ((V)((ToNum(Call(lit_18, V.Undef, C_361, n_379)) * ToNum((f_369 is var _t384 && Truthy(_t384) ? _t384 : ((V)(0.85))))))));
return ((V)(string.Concat("<path d=\"", ToStr(Call(pth_30, V.Undef, Invoke(Q_381, "map", Get(C_361, "P")))), "\" fill=\"", ToStr(c_383), "\" stroke=\"", ToStr(c_383), "\" stroke-width=\"0.2\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")));
}, 9, "", true);
T_41 = Fn((V _arrowThis407, int _argc395, V x_401, V y_402, V sz_403, V col_404, V[] _rest396) => {
V txt_405 = default;
V ex_406 = default;
txt_405 = (_argc395 > 4 ? _rest396[0] : V.Undef);
ex_406 = (_argc395 > 5 ? _rest396[1] : V.Undef);
return ((V)(string.Concat("<text x=\"", ToStr(Call(f1_25, V.Undef, x_401)), "\" y=\"", ToStr(Call(f1_25, V.Undef, y_402)), "\" text-anchor=\"middle\" ", ToStr(FONT_29), " font-size=\"", ToStr(Call(f1_25, V.Undef, sz_403)), "\" fill=\"", ToStr(col_404), "\"", (Truthy(ex_406) ? JsStrBuf.Begin().S(" ").V(ex_406).End() : ""), ">", ToStr(txt_405), "</text>")));
}, 6, "", true);
paperFx_42 = Fn((V _arrowThis418, int _argc408, V p_414, V w_415, V h_416, V ht_417, V[] _rest409) => {
return ((V)(string.Concat(string.Concat("<defs><radialGradient id=\"", ToStr(p_414), "v\" cx=\"50%\" cy=\"46%\" r=\"72%\"><stop offset=\"0.55\" stop-color=\"#7a5a2a\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#7a5a2a\" stop-opacity=\"0.45\"/></radialGradient></defs>"), string.Concat("<rect width=\"", ToStr(Call(f1_25, V.Undef, w_415)), "\" height=\"", ToStr(Call(f1_25, V.Undef, h_416)), "\" fill=\"url(#m12gl)\" opacity=\"0.6\"/>"))));
}, 4, "", true);
per_43 = Fn((V _arrowThis430, int _argc419, V x0_425, V a_426, V ph_427, V b_428, V[] _rest420) => {
V ph2_429 = default;
ph2_429 = (_argc419 > 4 ? _rest420[0] : V.Undef);
return Call(rep_27, V.Undef, ((V)(29D)), Fn((V _arrowThis438, int _argc431, V j_437, V _a434, V _a435, V _a436, V[] _rest432) => {
double y_439 = 0;
y_439 = (ToNum(j_437) * 2D);
return Arr(Add(Add(x0_425, ((V)((ToNum(a_426) * FdLibm.Sin(ToNum(Add(((V)((((2D * PI_13) * y_439) / 56D))), ph_427))))))), ((V)((ToNum((b_428 is var _t440 && Truthy(_t440) ? _t440 : ((V)(0D)))) * FdLibm.Sin(ToNum(Add(((V)((((4D * PI_13) * y_439) / 56D))), (ph2_429 is var _t441 && Truthy(_t441) ? _t441 : ((V)(0D)))))))))), ((V)(y_439)));
return default;
}, 1, "", true));
}, 5, "", true);
ln_44 = Fn((V _arrowThis449, int _argc442, V P_448, V _a445, V _a446, V _a447, V[] _rest443) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(P_448, "map", P2_28), "join", ((V)("L")))).End()));
}, 1, "", true);
NZ_45 = Fn((V _arrowThis464, int _argc450, V id_456, V bf_457, V oct_458, V seed_459, V[] _rest451) => {
V c_460 = default;
V ch_461 = default;
V a_462 = default;
V b_463 = default;
c_460 = (_argc450 > 4 ? _rest451[0] : V.Undef);
ch_461 = (_argc450 > 5 ? _rest451[1] : V.Undef);
a_462 = (_argc450 > 6 ? _rest451[2] : V.Undef);
b_463 = (_argc450 > 7 ? _rest451[3] : V.Undef);
return ((V)(string.Concat(string.Concat("<filter id=\"", ToStr(id_456), "\" filterUnits=\"userSpaceOnUse\" x=\"0\" y=\"0\" width=\"80\" height=\"56\" color-interpolation-filters=\"sRGB\"><feTurbulence type=\"fractalNoise\" baseFrequency=\"", ToStr(bf_457), "\" numOctaves=\"", ToStr(oct_458), "\" seed=\"", ToStr(seed_459), "\" stitchTiles=\"stitch\"/>"), string.Concat("<feColorMatrix values=\"0 0 0 0 ", ToStr(c_460), " 0 0 0 0 ", ToStr(c_460), " 0 0 0 0 ", ToStr(c_460), " ", ToStr((SEqN(ch_461, 0D) ? a_462 : ((V)(0D)))), " ", ToStr((SEqN(ch_461, 1D) ? a_462 : ((V)(0D)))), " ", ToStr((SEqN(ch_461, 2D) ? a_462 : ((V)(0D)))), " 0 ", ToStr(b_463), "\"/></filter>"))));
}, 8, "", true);
NR_46 = Fn((V _arrowThis474, int _argc465, V id_471, V op_472, V clip_473, V _a470, V[] _rest466) => {
return ((V)(string.Concat("<rect width=\"80\" height=\"56\" filter=\"url(#", ToStr(id_471), ")\" opacity=\"", ToStr(op_472), "\"", (Truthy(clip_473) ? string.Concat(" clip-path=\"url(#", ToStr(clip_473), ")\"") : ""), "/>")));
}, 3, "", true);
BL_47 = Fn((V _arrowThis483, int _argc475, V id_481, V s_482, V _a479, V _a480, V[] _rest476) => {
return ((V)(string.Concat("<filter id=\"", ToStr(id_481), "\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"", ToStr(s_482), "\"/></filter>")));
}, 2, "", true);
BLR_48 = ((V)("<filter id=\"wb2\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"1.3\"/></filter><filter id=\"wb1\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"0.45\"/></filter>"));
blot_49 = Fn((V _arrowThis495, int _argc484, V seed_490, V n_491, V cols_492, V op_493, V[] _rest485) => {
V R_496 = default;
JsStrBuf o_497 = null;
V sz_494 = default;
sz_494 = (_argc484 > 4 ? _rest485[0] : V.Undef);
R_496 = Call(rng_21, V.Undef, seed_490);
o_497 = new JsStrBuf("<g filter=\"url(#wb2)\">");
Call(rep_27, V.Undef, n_491, Fn((V _arrowThis505, int _argc498, V i_504, V _a501, V _a502, V _a503, V[] _rest499) => {
double x_506 = 0;
double y_507 = 0;
double rx_508 = 0;
double ry_509 = 0;
x_506 = (ToNum(Call(R_496, V.Undef)) * 80D);
y_507 = (ToNum(Call(R_496, V.Undef)) * 56D);
rx_508 = (ToNum((sz_494 is var _t510 && Truthy(_t510) ? _t510 : ((V)(3D)))) * (0.6 + (ToNum(Call(R_496, V.Undef)) * 0.9)));
ry_509 = (rx_508 * (0.5 + (ToNum(Call(R_496, V.Undef)) * 0.3)));
Invoke(Arr(((V)((-80D))), ((V)(0D)), ((V)(80D))), "forEach", Fn((V _arrowThis518, int _argc511, V dx_517, V _a514, V _a515, V _a516, V[] _rest512) => {
return Invoke(Arr(((V)((-56D))), ((V)(0D)), ((V)(56D))), "forEach", Fn((V _arrowThis526, int _argc519, V dy_525, V _a522, V _a523, V _a524, V[] _rest520) => {
V cx_527 = default;
V cy_528 = default;
cx_527 = Add(((V)(x_506)), dx_517);
cy_528 = Add(((V)(y_507)), dy_525);
if ((((LtN(Add(cx_527, ((V)(rx_508))), (-3D)) || ((ToNum(cx_527) - rx_508) > 83D)) || LtN(Add(cy_528, ((V)(ry_509))), (-3D))) || ((ToNum(cy_528) - ry_509) > 59D))) {
return default;
}
o_497.S("<ellipse cx=\"").V(Call(f1_25, V.Undef, cx_527)).S("\" cy=\"").V(Call(f1_25, V.Undef, cy_528)).S("\" rx=\"").V(Call(f1_25, V.Undef, ((V)(rx_508)))).S("\" ry=\"").V(Call(f1_25, V.Undef, ((V)(ry_509)))).S("\" fill=\"").V(GetIdx(cols_492, (ToNum(i_504) % ToNum(Get(cols_492, "length"))))).S("\" opacity=\"").V(op_493).S("\"/>");
return default;
}, 1, "", true));
}, 1, "", true));
return default;
}, 1, "", true));
return ((V)(string.Concat(o_497.Str, "</g>")));
return default;
}, 5, "", true);
BB_50 = 53.6;
room_51 = Fn((V _arrowThis537, int _argc529, V board_535, V o_536, V _a533, V _a534, V[] _rest530) => {
V lip_538 = default;
V dk_539 = default;
o_536 = (o_536 is var _t540 && Truthy(_t540) ? _t540 : NewObj(0).V);
lip_538 = Call(shade_11, V.Undef, board_535, ((V)(1.35)));
dk_539 = Call(shade_11, V.Undef, board_535, ((V)(0.7)));
return ((V)(JsStrBuf.Begin().S("<defs><linearGradient id=\"wsh\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\">").S((Truthy(Get(o_536, "side")) ? "<stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/>" : "<stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"0.2\"/><stop offset=\"0.07\" stop-color=\"#000000\" stop-opacity=\"0\"/>")).S("<stop offset=\"0.22\" stop-color=\"#ffffff\" stop-opacity=\"").V((Get(o_536, "top") is var _t541 && Truthy(_t541) ? _t541 : ((V)(0.06)))).S("\"/><stop offset=\"0.55\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.84\" stop-color=\"#000000\" stop-opacity=\"0\"/><stop offset=\"0.957\" stop-color=\"#000000\" stop-opacity=\"").V((Get(o_536, "ao") is var _t542 && Truthy(_t542) ? _t542 : ((V)(0.13)))).S("\"/></linearGradient></defs>").S("<rect width=\"80\" height=\"56\" fill=\"url(#wsh)\"/><rect y=\"").N((BB_50 - 0.8)).S("\" width=\"80\" height=\"1\" fill=\"#000000\" opacity=\"0.18\" filter=\"url(#wb1)\"/>").S("<rect y=\"").N(BB_50).S("\" width=\"80\" height=\"").V(Call(f1_25, V.Undef, ((V)((56D - BB_50))))).S("\" fill=\"").V(board_535).S("\"/><rect y=\"").N(BB_50).S("\" width=\"80\" height=\"0.45\" fill=\"").V(lip_538).S("\"/><rect y=\"55.35\" width=\"80\" height=\"0.65\" fill=\"").V(dk_539).S("\"/>").V((Get(o_536, "board") is var _t543 && Truthy(_t543) ? _t543 : ((V)("")))).End()));
return default;
}, 2, "", true);
tile_52 = Fn((V _arrowThis552, int _argc544, V S_550, V side_551, V _a548, V _a549, V[] _rest545) => {
V m_553 = default;
V mu_554 = default;
V d_555 = default;
m_553 = ((V)(JsStrBuf.Begin().S("<g clip-path=\"url(#wtc)\">").V(((side_551 is var _t556 && !Truthy(_t556) ? _t556 : Get(S_550, "smat")) is var _t557 && Truthy(_t557) ? _t557 : Get(S_550, "mat"))).S("</g>").End()));
mu_554 = (Truthy((side_551 is var _t558 && !Truthy(_t558) ? _t558 : Get(S_550, "sup"))) ? ((V)(JsStrBuf.Begin().S("<g clip-path=\"url(#wtc)\">").V(Get(S_550, "sup")).S("</g>").End())) : m_553);
d_555 = ((V)(JsStrBuf.Begin().S("<defs>").V(BLR_48).S("<clipPath id=\"wtc\"><rect width=\"80\" height=\"56\"/></clipPath>").V((Get(S_550, "defs") is var _t559 && Truthy(_t559) ? _t559 : ((V)("")))).S("</defs>").End()));
return Add(Add(Add(d_555, (Truthy(side_551) ? Invoke(Call(rep_27, V.Undef, ((V)(4D)), Fn((V _arrowThis567, int _argc560, V i_566, V _a563, V _a564, V _a565, V[] _rest561) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(0 ").N(((-56D) * ToNum(Add(i_566, ((V)(1D)))))).S(")\">").V(mu_554).S("</g>").End()));
}, 1, "", true)), "join", ((V)(""))) : ((V)("")))), m_553), Call(room_51, V.Undef, Get(S_550, "board"), Object_assign(NewObj(0).V, Get(S_550, "ro"), (Truthy(side_551) ? NewObj(1).Put("side", ((V)(1D))).V : NewObj(0).V))));
return default;
}, 2, "", true);
outlet_53 = Fn((V _arrowThis578, int _argc568, V x_574, V y_575, V pl_576, V sl_577, V[] _rest569) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(x_574).S("\" y=\"").V(y_575).S("\" width=\"1.5\" height=\"2.3\" rx=\"0.22\" fill=\"").V(pl_576).S("\" stroke=\"").V(Call(shade_11, V.Undef, pl_576, ((V)(0.7)))).S("\" stroke-width=\"0.12\"/>").V(Invoke(Invoke(Arr(((V)(0.55)), ((V)(1.45))), "map", Fn((V _arrowThis586, int _argc579, V dy_585, V _a582, V _a583, V _a584, V[] _rest580) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_25, V.Undef, Add(x_574, ((V)(0.45))))).S("\" y=\"").V(Call(f1_25, V.Undef, Add(y_575, dy_585))).S("\" width=\"0.16\" height=\"0.38\" fill=\"").V(sl_577).S("\"/><rect x=\"").V(Call(f1_25, V.Undef, Add(x_574, ((V)(0.9))))).S("\" y=\"").V(Call(f1_25, V.Undef, Add(y_575, dy_585))).S("\" width=\"0.16\" height=\"0.38\" fill=\"").V(sl_577).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).End()));
}, 4, "", true);
SURF12_58 = NewObj(4).Put("dry", sDry_54).Put("char", sChar_55).Put("slat", sSlat_56).Put("star", sStar_57).V;
draw11_59 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis595, int _argc587, V r_593, V o_594, V _a591, V _a592, V[] _rest588) => {
V res_596 = default;
res_596 = Call(draw11_59, V.Undef, r_593, o_594);
if (Truthy(((!(Truthy(res_596)) ? V.True : V.False) is var _t597 && Truthy(_t597) ? _t597 : Get(res_596, "_p12")))) {
return res_596;
}
try {
V f_598 = default;
f_598 = (Get(r_593, "s12") is var _t599 && !Truthy(_t599) ? _t599 : GetK(SURF12_58, Get(r_593, "s12")));
if (Truthy((f_598 is var _t600 && !Truthy(_t600) ? _t600 : Get(res_596, "surf")))) {
V S_601 = default;
S_601 = Call(f_598, V.Undef);
Set(res_596, "_p12", ((V)(1D)));
Set(res_596, "vb", ((V)("0 0 80 56")));
Set(res_596, "svg", Invoke(RD_8, "svgDoc", ((V)("0 0 80 56")), Arr(), Call(tile_52, V.Undef, S_601)));
Set(res_596, "src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Get(res_596, "svg"))).End())));
Set(res_596, "side", Invoke(RD_8, "svgDoc", ((V)("0 -224 80 280")), Arr(), Call(tile_52, V.Undef, S_601, ((V)(1D)))));
Set(res_596, "board", Get(S_601, "board"));
Set(res_596, "tile", ((V)(1D)));
}
} catch (System.Exception _ex602) {
V e_603 = default;
e_603 = Caught(_ex602);
Invoke(G("console"), "warn", ((V)("reno plus12")), Get(r_593, "id"), e_603);
}
return res_596;
return default;
}, 2, "", true));
artSpace_60 = Fn((V _arrowThis613, int _argc604, V p_610, V w_611, V h_612, V _a609, V[] _rest605) => {
V R_614 = default;
double px_615 = 0;
double py_616 = 0;
double pr_617 = 0;
V ring_618 = default;
R_614 = Call(rng_21, V.Undef, ((V)(JsStrBuf.Begin().S("sp").V(p_610).End())));
px_615 = (ToNum(w_611) * 0.72);
py_616 = (ToNum(h_612) * 0.36);
pr_617 = (ToNum(w_611) * 0.17);
ring_618 = Fn((V _arrowThis626, int _argc619, V sw_625, V _a622, V _a623, V _a624, V[] _rest620) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)((px_615 - (pr_617 * 1.7)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)(py_616)))), "A", ToStr(Call(f1_25, V.Undef, ((V)((pr_617 * 1.7))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((pr_617 * 0.42))))), " 0 0 ", ToStr(sw_625), " ", ToStr(Call(f1_25, V.Undef, ((V)((px_615 + (pr_617 * 1.7)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)(py_616)))), "\" fill=\"none\" stroke=\"#f6d49a\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((pr_617 * 0.16))))), "\" opacity=\"0.85\" transform=\"rotate(-14 ", ToStr(Call(f1_25, V.Undef, ((V)(px_615)))), " ", ToStr(Call(f1_25, V.Undef, ((V)(py_616)))), ")\"/>")));
}, 1, "", true);
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><linearGradient id=\"", ToStr(p_610), "k\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#151a3e\"/><stop offset=\"0.5\" stop-color=\"#3b2060\"/><stop offset=\"0.8\" stop-color=\"#a5356b\"/><stop offset=\"1\" stop-color=\"#ee8a4a\"/></linearGradient><radialGradient id=\"", ToStr(p_610), "p\" cx=\"34%\" cy=\"30%\" r=\"72%\"><stop offset=\"0\" stop-color=\"#ffd9a0\"/><stop offset=\"0.5\" stop-color=\"#e8863c\"/><stop offset=\"1\" stop-color=\"#6a2618\"/></radialGradient><linearGradient id=\"", ToStr(p_610), "f\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff6b0\"/><stop offset=\"0.5\" stop-color=\"#ffb02e\"/><stop offset=\"1\" stop-color=\"#ff5a1a\" stop-opacity=\"0\"/></linearGradient></defs>")).S(string.Concat("<rect width=\"", ToStr(w_611), "\" height=\"", ToStr(h_612), "\" fill=\"url(#", ToStr(p_610), "k)\"/>")).V(Invoke(Call(rep_27, V.Undef, ((V)(36D)), Fn((V _arrowThis633, int _argc627, V _a629, V _a630, V _a631, V _a632, V[] _rest628) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Call(R_614, V.Undef)) * ToNum(w_611)))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)(((ToNum(Call(R_614, V.Undef)) * ToNum(h_612)) * 0.7))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((0.12 + (ToNum(Call(R_614, V.Undef)) * 0.28)))))), "\" fill=\"#fff6e0\" opacity=\"", ToStr(Call(f1_25, V.Undef, ((V)((0.4 + (ToNum(Call(R_614, V.Undef)) * 0.6)))))), "\"/>")));
}, 0, "", true)), "join", ((V)("")))).V(Call(ring_618, V.Undef, ((V)(1D)))).S(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)(px_615)))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)(py_616)))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)(pr_617)))), "\" fill=\"url(#", ToStr(p_610), "p)\"/>")).V(Call(ring_618, V.Undef, ((V)(0D)))).S(string.Concat("<path d=\"M0 ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_612) * 0.86))))), "Q", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_611) * 0.2))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_612) * 0.78))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_611) * 0.42))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_612) * 0.84))))), "T", ToStr(Call(f1_25, V.Undef, w_611)), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_612) * 0.8))))), "V", ToStr(h_612), "H0Z\" fill=\"#2a1238\"/>")).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_611) * 0.34))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_612) * 0.6))))), ") rotate(-32) scale(", ToStr(Call(n4_26, V.Undef, ((V)((ToNum(w_611) / 50D))))), ")\"><path d=\"M-2.6 9Q0 19 2.6 9Z\" fill=\"url(#", ToStr(p_610), "f)\"/><path d=\"M0 -12C4 -8 4.2 0 3 9H-3C-4.2 0 -4 -8 0 -12Z\" fill=\"#e8e2d4\"/><path d=\"M0 -12C2 -10 2.6 -7.6 2.8 -6H-2.8C-2.6 -7.6 -2 -10 0 -12Z\" fill=\"#d6363a\"/><path d=\"M-3 3L-6.5 9.5L-3 8.6ZM3 3L6.5 9.5L3 8.6Z\" fill=\"#d6363a\"/><circle cy=\"-2\" r=\"1.6\" fill=\"#7fd6ff\" stroke=\"#5a5f6a\" stroke-width=\"0.6\"/><path d=\"M-1.8 -9.6C-2.9 -6 -3 -1 -2.4 7\" stroke=\"#ffffff\" stroke-opacity=\"0.5\" stroke-width=\"0.5\" fill=\"none\"/></g>")).V(Call(T_41, V.Undef, ((V)((ToNum(w_611) / 2D))), ((V)((ToNum(h_612) * 0.11))), ((V)((ToNum(w_611) * 0.11))), ((V)("#f6e7c8")), ((V)("SPACE")), ((V)(string.Concat("letter-spacing=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_611) * 0.03))))), "\""))))).V(Call(T_41, V.Undef, ((V)((ToNum(w_611) / 2D))), ((V)((ToNum(h_612) * 0.235))), ((V)((ToNum(w_611) * 0.2))), ((V)("#ffd34a")), ((V)("SQUISH")), ((V)(string.Concat("stroke=\"#7a1d2a\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_611) * 0.014))))), "\" paint-order=\"stroke\""))))).V(Call(T_41, V.Undef, ((V)((ToNum(w_611) / 2D))), ((V)((ToNum(h_612) * 0.905))), ((V)((ToNum(w_611) * 0.042))), ((V)("#ffe7b8")), ((V)("THE BLOB THAT ATE THE MOON!")))).V(Invoke(Call(rep_27, V.Undef, ((V)(3D)), Fn((V _arrowThis641, int _argc634, V i_640, V _a637, V _a638, V _a639, V[] _rest635) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_611) * (0.18 + (ToNum(i_640) * 0.02))))))), "\" y=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_612) * (0.925 + (ToNum(i_640) * 0.022))))))), "\" width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_611) * (0.64 - (ToNum(i_640) * 0.04))))))), "\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_612) * 0.009))))), "\" fill=\"#e9d6c0\" opacity=\"0.7\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
return default;
}, 3, "", true);
artRocket_61 = Fn((V _arrowThis651, int _argc642, V p_648, V w_649, V h_650, V _a647, V[] _rest643) => {
double k_652 = 0;
k_652 = (ToNum(w_649) / 24D);
return ((V)(JsStrBuf.Begin().S(string.Concat("<rect width=\"", ToStr(Call(f1_25, V.Undef, w_649)), "\" height=\"", ToStr(Call(f1_25, V.Undef, h_650)), "\" fill=\"#f1e4c4\"/><circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_649) / 2D))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_650) * 0.48))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_649) * 0.4))))), "\" fill=\"#e8b13c\"/>")).V(Invoke(Call(rep_27, V.Undef, ((V)(8D)), Fn((V _arrowThis660, int _argc653, V i_659, V _a656, V _a657, V _a658, V[] _rest654) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_649) / 2D))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_650) * 0.48))))), "L", ToStr(Call(f1_25, V.Undef, ((V)(((ToNum(w_649) / 2D) + (ToNum(w_649) * FdLibm.Cos(((ToNum(i_659) * PI_13) / 4D)))))))), " ", ToStr(Call(f1_25, V.Undef, ((V)(((ToNum(h_650) * 0.48) + (ToNum(w_649) * FdLibm.Sin(((ToNum(i_659) * PI_13) / 4D)))))))), "\" stroke=\"#f1e4c4\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((k_652 * 0.5))))), "\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M0 ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_650) * 0.84))))), "Q", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_649) * 0.5))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_650) * 0.74))))), " ", ToStr(Call(f1_25, V.Undef, w_649)), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_650) * 0.84))))), "V", ToStr(Call(f1_25, V.Undef, h_650)), "H0Z\" fill=\"#2f8f8a\"/>")).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_649) / 2D))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_650) * 0.46))))), ") scale(", ToStr(Call(n4_26, V.Undef, ((V)(k_652)))), ")\" stroke=\"#233047\" stroke-width=\"0.5\" stroke-linejoin=\"round\"><path d=\"M-2.2 11Q0 19 2.2 11Z\" fill=\"#e8b13c\"/><path d=\"M-1.1 11Q0 15.6 1.1 11Z\" fill=\"#fff3c0\" stroke=\"none\"/><path d=\"M0 -13C4.5 -8 4.6 4 3.2 9H-3.2C-4.6 4 -4.5 -8 0 -13Z\" fill=\"#e0533a\"/><path d=\"M-4.3 -1H4.3V1.2H-4.3Z\" fill=\"#f1e4c4\" stroke=\"none\"/><circle cy=\"-5\" r=\"2\" fill=\"#2f8f8a\"/><circle cx=\"-0.6\" cy=\"-5.6\" r=\"0.6\" fill=\"#ffffff\" stroke=\"none\"/><path d=\"M-3.2 4L-7.5 11L-3.2 9ZM3.2 4L7.5 11L3.2 9Z\" fill=\"#2f8f8a\"/><path d=\"M-2 9H2L2.6 11H-2.6Z\" fill=\"#233047\"/></g>")).V(Invoke(Call(rep_27, V.Undef, ((V)(5D)), Fn((V _arrowThis668, int _argc661, V i_667, V _a664, V _a665, V _a666, V[] _rest662) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_649) * (0.14 + (ToNum(i_667) * 0.18))))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)(((ToNum(h_650) * 0.83) - (((ToNum(i_667) % 2D) * k_652) * 1.2)))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((k_652 * (2.2 + ((ToNum(i_667) % 2D) * 0.6))))))), "\" fill=\"#f8efd8\" stroke=\"#233047\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((k_652 * 0.3))))), "\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Call(T_41, V.Undef, ((V)((ToNum(w_649) / 2D))), ((V)((ToNum(h_650) * 0.13))), ((V)((ToNum(w_649) * 0.19))), ((V)("#233047")), ((V)("ROCKET")))).V(Call(T_41, V.Undef, ((V)((ToNum(w_649) / 2D))), ((V)((ToNum(h_650) * 0.96))), ((V)((ToNum(w_649) * 0.15))), ((V)("#e0533a")), ((V)("RANGERS")))).End()));
return default;
}, 3, "", true);
artSaucer_62 = Fn((V _arrowThis678, int _argc669, V p_675, V w_676, V h_677, V _a674, V[] _rest670) => {
V R_679 = default;
double k_680 = 0;
double sx_681 = 0;
double sy_682 = 0;
R_679 = Call(rng_21, V.Undef, ((V)(JsStrBuf.Begin().S("sau").V(p_675).End())));
k_680 = (ToNum(w_676) / 28D);
sx_681 = (ToNum(w_676) / 2D);
sy_682 = (ToNum(h_677) * 0.42);
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><linearGradient id=\"", ToStr(p_675), "n\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#1c2740\"/><stop offset=\"1\" stop-color=\"#3e5272\"/></linearGradient></defs><rect width=\"", ToStr(Call(f1_25, V.Undef, w_676)), "\" height=\"", ToStr(Call(f1_25, V.Undef, h_677)), "\" fill=\"url(#", ToStr(p_675), "n)\"/>")).V(Invoke(Call(rep_27, V.Undef, ((V)(22D)), Fn((V _arrowThis689, int _argc683, V _a685, V _a686, V _a687, V _a688, V[] _rest684) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Call(R_679, V.Undef)) * ToNum(w_676)))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)(((ToNum(Call(R_679, V.Undef)) * ToNum(h_677)) * 0.6))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((0.15 + (ToNum(Call(R_679, V.Undef)) * 0.25)))))), "\" fill=\"#f1e4c4\"/>")));
}, 0, "", true)), "join", ((V)("")))).S(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_676) * 0.2))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_677) * 0.24))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((3.2 * k_680))))), "\" fill=\"#f1e4c4\"/><circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)(((ToNum(w_676) * 0.2) + (k_680 * 1.2)))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)(((ToNum(h_677) * 0.24) - (k_680 * 0.6)))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((2.6 * k_680))))), "\" fill=\"#1c2740\" opacity=\"0.25\"/>")).S(string.Concat("<path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)((sx_681 - (4D * k_680)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((sy_682 + k_680))))), "L", ToStr(Call(f1_25, V.Undef, ((V)((sx_681 - (10D * k_680)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_677) * 0.86))))), "H", ToStr(Call(f1_25, V.Undef, ((V)((sx_681 + (10D * k_680)))))), "L", ToStr(Call(f1_25, V.Undef, ((V)((sx_681 + (4D * k_680)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((sy_682 + k_680))))), "Z\" fill=\"#f1e4c4\" opacity=\"0.3\"/>")).S(string.Concat("<path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)((sx_681 - (4.6 * k_680)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)(sy_682)))), "A", ToStr(Call(f1_25, V.Undef, ((V)((4.6 * k_680))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((3.8 * k_680))))), " 0 0 1 ", ToStr(Call(f1_25, V.Undef, ((V)((sx_681 + (4.6 * k_680)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)(sy_682)))), "Z\" fill=\"#bfe8e0\" stroke=\"#233047\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((k_680 * 0.3))))), "\"/><ellipse cx=\"", ToStr(Call(f1_25, V.Undef, ((V)(sx_681)))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)(sy_682)))), "\" rx=\"", ToStr(Call(f1_25, V.Undef, ((V)((9.5 * k_680))))), "\" ry=\"", ToStr(Call(f1_25, V.Undef, ((V)((2.4 * k_680))))), "\" fill=\"#2f8f8a\" stroke=\"#141c2b\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((k_680 * 0.3))))), "\"/>")).V(Invoke(Call(rep_27, V.Undef, ((V)(5D)), Fn((V _arrowThis697, int _argc690, V i_696, V _a693, V _a694, V _a695, V[] _rest691) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((sx_681 + (((ToNum(i_696) - 2D) * 3.4) * k_680)))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((sy_682 + (k_680 * 0.5)))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((k_680 * 0.6))))), "\" fill=\"#e8b13c\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Call(rep_27, V.Undef, ((V)(7D)), Fn((V _arrowThis705, int _argc698, V i_704, V _a701, V _a702, V _a703, V[] _rest699) => {
double bw_706 = 0;
double bh_707 = 0;
double x_708 = 0;
bw_706 = (ToNum(w_676) / 7D);
bh_707 = (ToNum(h_677) * (0.12 + (((ToNum(i_704) * 37D) % 5D) * 0.035)));
x_708 = (ToNum(i_704) * bw_706);
return ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"", ToStr(Call(f1_25, V.Undef, ((V)(x_708)))), "\" y=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_677) - bh_707))))), "\" width=\"", ToStr(Call(f1_25, V.Undef, ((V)((bw_706 + 0.2))))), "\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)(bh_707)))), "\" fill=\"#141c2b\"/>")).V(Invoke(Call(rep_27, V.Undef, ((V)(3D)), Fn((V _arrowThis716, int _argc709, V j_715, V _a712, V _a713, V _a714, V[] _rest710) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_25, V.Undef, ((V)((x_708 + (bw_706 * 0.25)))))), "\" y=\"", ToStr(Call(f1_25, V.Undef, ((V)((((ToNum(h_677) - bh_707) + 1.2) + (ToNum(j_715) * 2.2)))))), "\" width=\"", ToStr(Call(f1_25, V.Undef, ((V)((bw_706 * 0.18))))), "\" height=\"0.9\" fill=\"#e8b13c\" opacity=\"", NumStr((NumTruthy((ToNum(Add(i_704, j_715)) % 3D)) ? 0.9 : 0.25)), "\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
return default;
}, 1, "", true)), "join", ((V)("")))).V(Call(T_41, V.Undef, ((V)((ToNum(w_676) / 2D))), ((V)((ToNum(h_677) * 0.11))), ((V)((ToNum(w_676) * 0.17))), ((V)("#f1e4c4")), ((V)("SAUCER")))).V(Call(T_41, V.Undef, ((V)((ToNum(w_676) / 2D))), ((V)((ToNum(h_677) * 0.7))), ((V)((ToNum(w_676) * 0.16))), ((V)("#e8b13c")), ((V)("SUMMER")), ((V)("stroke=\"#1c2740\" stroke-width=\"0.5\" paint-order=\"stroke\"")))).End()));
return default;
}, 3, "", true);
artRobot_63 = Fn((V _arrowThis726, int _argc717, V p_723, V w_724, V h_725, V _a722, V[] _rest718) => {
double k_727 = 0;
double cx_728 = 0;
double cy_729 = 0;
k_727 = (ToNum(w_724) / 24D);
cx_728 = (ToNum(w_724) / 2D);
cy_729 = (ToNum(h_725) * 0.52);
return ((V)(JsStrBuf.Begin().S(string.Concat("<rect width=\"", ToStr(Call(f1_25, V.Undef, w_724)), "\" height=\"", ToStr(Call(f1_25, V.Undef, h_725)), "\" fill=\"#e8b13c\"/>")).V(Invoke(Call(rep_27, V.Undef, ((V)(12D)), Fn((V _arrowThis737, int _argc730, V i_736, V _a733, V _a734, V _a735, V[] _rest731) => {
double a_738 = 0;
double b_739 = 0;
a_738 = ((ToNum(i_736) * PI_13) / 6D);
b_739 = (a_738 + (PI_13 / 12D));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)(cx_728)))), " ", ToStr(Call(f1_25, V.Undef, ((V)(cy_729)))), "L", ToStr(Call(f1_25, V.Undef, ((V)((cx_728 + (ToNum(h_725) * FdLibm.Cos(a_738))))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((cy_729 + (ToNum(h_725) * FdLibm.Sin(a_738))))))), "L", ToStr(Call(f1_25, V.Undef, ((V)((cx_728 + (ToNum(h_725) * FdLibm.Cos(b_739))))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((cy_729 + (ToNum(h_725) * FdLibm.Sin(b_739))))))), "Z\" fill=\"#f2c763\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_25, V.Undef, ((V)(cx_728)))), " ", ToStr(Call(f1_25, V.Undef, ((V)(cy_729)))), ") scale(", ToStr(Call(n4_26, V.Undef, ((V)(k_727)))), ")\" stroke=\"#233047\" stroke-width=\"0.5\" stroke-linejoin=\"round\"><path d=\"M0 -12V-14.5\" fill=\"none\"/><circle cy=\"-15\" r=\"1\" fill=\"#e0533a\"/><rect x=\"-5\" y=\"-12\" width=\"10\" height=\"8\" rx=\"1.4\" fill=\"#c9d3d6\"/><circle cx=\"-2.2\" cy=\"-8.4\" r=\"1.5\" fill=\"#2f8f8a\"/><circle cx=\"2.2\" cy=\"-8.4\" r=\"1.5\" fill=\"#2f8f8a\"/><path d=\"M-2.4 -5.6H2.4M-2.4 -5.6V-4.8M-0.8 -5.6V-4.8M0.8 -5.6V-4.8M2.4 -5.6V-4.8\" fill=\"none\"/>")).S(string.Concat("<rect x=\"-6\" y=\"-3\" width=\"12\" height=\"10\" rx=\"1.2\" fill=\"#e0533a\"/><circle cx=\"-2.4\" cy=\"0.6\" r=\"1.4\" fill=\"#f1e4c4\"/><circle cx=\"2.4\" cy=\"0.6\" r=\"1.4\" fill=\"#2f8f8a\"/><rect x=\"-3\" y=\"3.4\" width=\"6\" height=\"1.6\" fill=\"#f1e4c4\"/><path d=\"M-6 -1L-9.5 4.5M6 -1L9.5 -5\" fill=\"none\" stroke-width=\"1.6\"/><path d=\"M-11 4.6L-9.5 4.5L-9.4 6.2M8.2 -6.2L9.5 -5L11 -5.4\" fill=\"none\"/>", "")).S(string.Concat("<path d=\"M-3.5 7V11.5M3.5 7V11.5\" fill=\"none\" stroke-width=\"1.6\"/><rect x=\"-6\" y=\"11.5\" width=\"4.6\" height=\"1.8\" rx=\"0.6\" fill=\"#233047\"/><rect x=\"1.4\" y=\"11.5\" width=\"4.6\" height=\"1.8\" rx=\"0.6\" fill=\"#233047\"/></g>", "")).V(Call(T_41, V.Undef, ((V)((ToNum(w_724) / 2D))), ((V)((ToNum(h_725) * 0.15))), ((V)((ToNum(w_724) * 0.24))), ((V)("#233047")), ((V)("ROBO")))).V(Call(T_41, V.Undef, ((V)((ToNum(w_724) / 2D))), ((V)((ToNum(h_725) * 0.95))), ((V)((ToNum(w_724) * 0.22))), ((V)("#e0533a")), ((V)("PAL")), ((V)("stroke=\"#233047\" stroke-width=\"0.4\" paint-order=\"stroke\"")))).End()));
return default;
}, 3, "", true);
artMoon_64 = Fn((V _arrowThis749, int _argc740, V p_746, V w_747, V h_748, V _a745, V[] _rest741) => {
V R_750 = default;
double hz_751 = 0;
R_750 = Call(rng_21, V.Undef, ((V)(JsStrBuf.Begin().S("moon").V(p_746).End())));
hz_751 = (ToNum(h_748) * 0.62);
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><linearGradient id=\"", ToStr(p_746), "s\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#1b1446\"/><stop offset=\"0.55\" stop-color=\"#6a2a7a\"/><stop offset=\"1\" stop-color=\"#ff8a4a\"/></linearGradient><linearGradient id=\"", ToStr(p_746), "w\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#4a2160\"/><stop offset=\"1\" stop-color=\"#140b2a\"/></linearGradient><radialGradient id=\"", ToStr(p_746), "m\" cx=\"42%\" cy=\"38%\" r=\"60%\"><stop offset=\"0\" stop-color=\"#fffdf0\"/><stop offset=\"0.8\" stop-color=\"#ffe6b0\"/><stop offset=\"1\" stop-color=\"#f2c27a\"/></radialGradient><radialGradient id=\"", ToStr(p_746), "g\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff1c4\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#fff1c4\" stop-opacity=\"0\"/></radialGradient></defs>")).S(string.Concat("<rect width=\"", ToStr(Call(f1_25, V.Undef, w_747)), "\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)(hz_751)))), "\" fill=\"url(#", ToStr(p_746), "s)\"/>")).V(Invoke(Call(rep_27, V.Undef, ((V)(26D)), Fn((V _arrowThis758, int _argc752, V _a754, V _a755, V _a756, V _a757, V[] _rest753) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Call(R_750, V.Undef)) * ToNum(w_747)))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)(((ToNum(Call(R_750, V.Undef)) * hz_751) * 0.7))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((0.15 + (ToNum(Call(R_750, V.Undef)) * 0.25)))))), "\" fill=\"#fff6e0\" opacity=\"", ToStr(Call(f1_25, V.Undef, ((V)((0.5 + (ToNum(Call(R_750, V.Undef)) * 0.5)))))), "\"/>")));
}, 0, "", true)), "join", ((V)("")))).S(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) / 2D))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_748) * 0.38))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.4))))), "\" fill=\"url(#", ToStr(p_746), "g)\"/><circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) / 2D))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_748) * 0.38))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.2))))), "\" fill=\"url(#", ToStr(p_746), "m)\"/><circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.45))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_748) * 0.35))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.035))))), "\" fill=\"#e8c890\" opacity=\"0.6\"/><circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.56))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_748) * 0.41))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.025))))), "\" fill=\"#e8c890\" opacity=\"0.5\"/>")).S(string.Concat("<rect y=\"", ToStr(Call(f1_25, V.Undef, ((V)(hz_751)))), "\" width=\"", ToStr(Call(f1_25, V.Undef, w_747)), "\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_748) - hz_751))))), "\" fill=\"url(#", ToStr(p_746), "w)\"/>")).V(Invoke(Call(rep_27, V.Undef, ((V)(8D)), Fn((V _arrowThis766, int _argc759, V i_765, V _a762, V _a763, V _a764, V[] _rest760) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_25, V.Undef, ((V)(((ToNum(w_747) / 2D) - (ToNum(w_747) * (0.16 - (ToNum(i_765) * 0.012)))))))), "\" y=\"", ToStr(Call(f1_25, V.Undef, ((V)(((hz_751 + 1.2) + (ToNum(i_765) * 2.2)))))), "\" width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * (0.32 - (ToNum(i_765) * 0.024))))))), "\" height=\"0.6\" rx=\"0.3\" fill=\"#fff1c4\" opacity=\"", ToStr(Call(f1_25, V.Undef, ((V)((0.75 - (ToNum(i_765) * 0.07)))))), "\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.18))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((hz_751 - 0.4))))), "h", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.2))))), "l-", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.03))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.04))))), "h-", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.14))))), "Z M", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.27))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((hz_751 - 0.4))))), "V", ToStr(Call(f1_25, V.Undef, ((V)((hz_751 - (ToNum(w_747) * 0.17)))))), "L", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.35))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((hz_751 - 0.8))))), "Z\" fill=\"#140b2a\"/>")).V(Call(T_41, V.Undef, ((V)((ToNum(w_747) / 2D))), ((V)((ToNum(h_748) * 0.1))), ((V)((ToNum(w_747) * 0.16))), ((V)("#fff1c4")), ((V)("MOONLIT")), ((V)(string.Concat("letter-spacing=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.02))))), "\""))))).V(Call(T_41, V.Undef, ((V)((ToNum(w_747) / 2D))), ((V)((ToNum(h_748) * 0.19))), ((V)((ToNum(w_747) * 0.16))), ((V)("#ffb36a")), ((V)("MATINEE")), ((V)(string.Concat("letter-spacing=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.02))))), "\""))))).V(Call(T_41, V.Undef, ((V)((ToNum(w_747) / 2D))), ((V)((ToNum(h_748) * 0.9))), ((V)((ToNum(w_747) * 0.065))), ((V)("#fff1c4")), ((V)("TONIGHT ONLY")), ((V)(string.Concat("letter-spacing=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * 0.02))))), "\""))))).V(Invoke(Call(rep_27, V.Undef, ((V)(2D)), Fn((V _arrowThis774, int _argc767, V i_773, V _a770, V _a771, V _a772, V[] _rest768) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * (0.2 + (ToNum(i_773) * 0.04))))))), "\" y=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_748) * (0.93 + (ToNum(i_773) * 0.025))))))), "\" width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_747) * (0.6 - (ToNum(i_773) * 0.08))))))), "\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_748) * 0.008))))), "\" fill=\"#e9d6c0\" opacity=\"0.6\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
return default;
}, 3, "", true);
Set(N_12, "torn12", Fn((V _arrowThis782, int _argc775, V S_781, V _a778, V _a779, V _a780, V[] _rest776) => {
double W_783 = 0;
double Hh_784 = 0;
double Z_785 = 0;
double X0_786 = 0;
V D_787 = default;
W_783 = 56D;
Hh_784 = 80D;
Z_785 = 0.25;
X0_786 = ((-W_783) / 2D);
D_787 = NewObj(5).Put("w", ((V)(62D))).Put("d", ((V)(4D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(48D))).Put("build", Fn((V _arrowThis794, int _argc788, V _a790, V _a791, V _a792, V _a793, V[] _rest789) => {
return Arr();
}, 0, "build", true)).V;
Set(D_787, "fx", Fn((V _arrowThis802, int _argc795, V ctx_801, V _a798, V _a799, V _a800, V[] _rest796) => {
V C_803 = default;
V R_804 = default;
V jag_805 = default;
V c0_806 = default;
V c1_807 = default;
V c2_808 = default;
V c3_809 = default;
V c4_810 = default;
V c5_811 = default;
V r0_812 = default;
V r1_813 = default;
V r2_814 = default;
V torn_815 = default;
V O_816 = default;
V od_817 = default;
V fl_818 = default;
V d1_819 = default;
V d2_820 = default;
V tape_821 = default;
V crease_822 = default;
V wr_823 = default;
V defs_824 = default;
V s_825 = default;
C_803 = Call(cam_15, V.Undef, ctx_801);
R_804 = Call(rng_21, V.Undef, ((V)("torn12")));
jag_805 = Fn((V _arrowThis836, int _argc826, V a_832, V b_833, V n_834, V j_835, V[] _rest827) => {
return Call(rep_27, V.Undef, n_834, Fn((V _arrowThis844, int _argc837, V i_843, V _a840, V _a841, V _a842, V[] _rest838) => {
double t_845 = 0;
double nx_846 = 0;
double ny_847 = 0;
V l_848 = default;
double o_849 = 0;
t_845 = (ToNum(Add(i_843, ((V)(1D)))) / ToNum(Add(n_834, ((V)(1D)))));
nx_846 = (ToNum(GetIdx(a_832, 1D)) - ToNum(GetIdx(b_833, 1D)));
ny_847 = (ToNum(GetIdx(b_833, 0D)) - ToNum(GetIdx(a_832, 0D)));
l_848 = (((V)(Hypot(nx_846, ny_847))) is var _t850 && Truthy(_t850) ? _t850 : ((V)(1D)));
o_849 = (((ToNum(Call(R_804, V.Undef)) - 0.5) * 2D) * ToNum(j_835));
return Arr(Add(Add(GetIdx(a_832, 0D), ((V)(((ToNum(GetIdx(b_833, 0D)) - ToNum(GetIdx(a_832, 0D))) * t_845)))), ((V)(((nx_846 / ToNum(l_848)) * o_849)))), Add(Add(GetIdx(a_832, 1D), ((V)(((ToNum(GetIdx(b_833, 1D)) - ToNum(GetIdx(a_832, 1D))) * t_845)))), ((V)(((ny_847 / ToNum(l_848)) * o_849)))));
return default;
}, 1, "", true));
}, 4, "", true);
c0_806 = Arr(((V)(0.4)), ((V)(0.5)));
c1_807 = Arr(((V)((W_783 - 8D))), ((V)(0.2)));
c2_808 = Arr(((V)((W_783 - 0.1))), ((V)(8D)));
c3_809 = Arr(((V)((W_783 - 0.3))), ((V)((Hh_784 - 15D))));
c4_810 = Arr(((V)((W_783 - 16D))), ((V)((Hh_784 - 0.3))));
c5_811 = Arr(((V)(0.5)), ((V)((Hh_784 - 0.4))));
r0_812 = Arr(((V)(0.3)), ((V)((Hh_784 * 0.64))));
r1_813 = Arr(((V)(3.4)), ((V)((Hh_784 * 0.615))));
r2_814 = Arr(((V)(0.2)), ((V)((Hh_784 * 0.59))));
torn_815 = new ArrBuilder().Add(c3_809).Spread(Call(jag_805, V.Undef, c3_809, c4_810, ((V)(9D)), ((V)(0.9)))).Add(c4_810).V;
O_816 = new ArrBuilder().Add(c0_806).Spread(Call(jag_805, V.Undef, c0_806, c1_807, ((V)(14D)), ((V)(0.22)))).Add(c1_807).Add(c2_808).Spread(Call(jag_805, V.Undef, c2_808, c3_809, ((V)(12D)), ((V)(0.22)))).Spread(torn_815).Spread(Call(jag_805, V.Undef, c4_810, c5_811, ((V)(10D)), ((V)(0.3)))).Add(c5_811).Spread(Call(jag_805, V.Undef, c5_811, r0_812, ((V)(4D)), ((V)(0.2)))).Add(r0_812).Add(r1_813).Add(r2_814).Spread(Call(jag_805, V.Undef, r2_814, c0_806, ((V)(8D)), ((V)(0.22)))).V;
od_817 = Call(pth_30, V.Undef, O_816);
fl_818 = Fn((V _arrowThis860, int _argc851, V Tp_857, V q1_858, V q2_859, V _a856, V[] _rest852) => {
return ((V)(string.Concat("M", ToStr(Call(P2_28, V.Undef, c1_807)), "L", ToStr(Call(P2_28, V.Undef, c2_808)), "Q", ToStr(Call(P2_28, V.Undef, q1_858)), " ", ToStr(Call(P2_28, V.Undef, Tp_857)), "Q", ToStr(Call(P2_28, V.Undef, q2_859)), " ", ToStr(Call(P2_28, V.Undef, c1_807)), "Z")));
}, 3, "", true);
d1_819 = Call(fl_818, V.Undef, Arr(((V)((W_783 - 7.6))), ((V)(7.6))), Arr(((V)((W_783 - 3D))), ((V)(7D))), Arr(((V)((W_783 - 7D))), ((V)(3.4))));
d2_820 = Call(fl_818, V.Undef, Arr(((V)((W_783 - 6.2))), ((V)(6.2))), Arr(((V)((W_783 - 2.6))), ((V)(5.9))), Arr(((V)((W_783 - 6D))), ((V)(2.9))));
tape_821 = Fn((V _arrowThis873, int _argc861, V x_867, V y_868, V L_869, V Wd_870, V[] _rest862) => {
double hl_874 = 0;
double hw_875 = 0;
V rt_876 = default;
V lf_877 = default;
V d_878 = default;
V rot_871 = default;
V op_872 = default;
rot_871 = (_argc861 > 4 ? _rest862[0] : V.Undef);
op_872 = (_argc861 > 5 ? _rest862[1] : V.Undef);
hl_874 = (ToNum(L_869) / 2D);
hw_875 = (ToNum(Wd_870) / 2D);
rt_876 = Invoke(Call(rep_27, V.Undef, ((V)(4D)), Fn((V _arrowThis886, int _argc879, V i_885, V _a882, V _a883, V _a884, V[] _rest880) => {
return ((V)(string.Concat("L", ToStr(Call(f1_25, V.Undef, ((V)((hl_874 + (NumTruthy((ToNum(i_885) % 2D)) ? 0D : 0.45)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)(((-hw_875) + ((ToNum(Add(i_885, ((V)(1D)))) * ToNum(Wd_870)) / 4D)))))))));
}, 1, "", true)), "join", ((V)("")));
lf_877 = Invoke(Call(rep_27, V.Undef, ((V)(4D)), Fn((V _arrowThis894, int _argc887, V i_893, V _a890, V _a891, V _a892, V[] _rest888) => {
return ((V)(string.Concat("L", ToStr(Call(f1_25, V.Undef, ((V)(((-hl_874) - (NumTruthy((ToNum(i_893) % 2D)) ? 0D : 0.45)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((hw_875 - ((ToNum(Add(i_893, ((V)(1D)))) * ToNum(Wd_870)) / 4D)))))))));
}, 1, "", true)), "join", ((V)("")));
d_878 = ((V)(string.Concat("M", ToStr(Call(f1_25, V.Undef, ((V)((-hl_874))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((-hw_875))))), "H", ToStr(Call(f1_25, V.Undef, ((V)(hl_874)))), ToStr(rt_876), "L", ToStr(Call(f1_25, V.Undef, ((V)((-hl_874))))), " ", ToStr(Call(f1_25, V.Undef, ((V)(hw_875)))), ToStr(lf_877), "Z")));
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_25, V.Undef, x_867)), " ", ToStr(Call(f1_25, V.Undef, y_868)), ") rotate(", ToStr(rot_871), ")\" opacity=\"", ToStr((op_872 is var _t895 && Truthy(_t895) ? _t895 : ((V)(1D)))), "\"><path d=\"", ToStr(d_878), "\" fill=\"#fff6c8\" opacity=\"0.8\" stroke=\"#c9b67a\" stroke-width=\"0.35\" stroke-linejoin=\"round\"/><path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)(((-hl_874) * 0.6))))), " ", ToStr(Call(f1_25, V.Undef, ((V)(((-hw_875) * 0.45))))), "H", ToStr(Call(f1_25, V.Undef, ((V)((hl_874 * 0.3))))), "\" stroke=\"#ffffff\" stroke-width=\"0.5\" stroke-linecap=\"round\"/></g>")));
return default;
}, 6, "", true);
crease_822 = ((V)(string.Concat("<path d=\"M", NumStr((W_783 / 2D)), " 0V", NumStr(Hh_784), "M0 ", NumStr((Hh_784 / 2D)), "H", NumStr(W_783), "\" stroke=\"#000000\" stroke-opacity=\"0.2\" stroke-width=\"0.5\"/><path d=\"M", NumStr(((W_783 / 2D) + 0.45)), " 0V", NumStr(Hh_784), "M0 ", NumStr(((Hh_784 / 2D) + 0.45)), "H", NumStr(W_783), "\" stroke=\"#ffffff\" stroke-opacity=\"0.24\" stroke-width=\"0.35\"/><rect x=\"", NumStr((W_783 / 2D)), "\" width=\"", NumStr((W_783 / 2D)), "\" height=\"", NumStr(Hh_784), "\" fill=\"#000000\" opacity=\"0.04\"/><rect y=\"", NumStr((Hh_784 / 2D)), "\" width=\"", NumStr(W_783), "\" height=\"", NumStr((Hh_784 / 2D)), "\" fill=\"#ffffff\" opacity=\"0.03\"/>")));
wr_823 = ((V)("<g filter=\"url(#m12b2)\"><path d=\"M7 54Q16 47 25 49\" stroke=\"#000000\" stroke-opacity=\"0.16\" stroke-width=\"1.3\" fill=\"none\"/><path d=\"M7.6 55.2Q16.6 48.2 25.6 50.2\" stroke=\"#ffffff\" stroke-opacity=\"0.14\" stroke-width=\"1\" fill=\"none\"/><path d=\"M36 16Q42 24 40 33\" stroke=\"#000000\" stroke-opacity=\"0.12\" stroke-width=\"1.2\" fill=\"none\"/><path d=\"M37.2 16Q43.2 24 41.2 33\" stroke=\"#ffffff\" stroke-opacity=\"0.12\" stroke-width=\"0.9\" fill=\"none\"/></g>"));
defs_824 = ((V)(JsStrBuf.Begin().S("<defs><clipPath id=\"tpc\"><path d=\"").V(od_817).S("\"/></clipPath><linearGradient id=\"tpg\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.45\" stop-color=\"#ffffff\" stop-opacity=\"0.55\"/><stop offset=\"0.6\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0.2\"/></linearGradient>").S(string.Concat("<linearGradient id=\"tpb\" gradientUnits=\"userSpaceOnUse\" x1=\"", NumStr((W_783 - 3.5)), "\" y1=\"3.5\" x2=\"", NumStr((W_783 - 7.6)), "\" y2=\"7.6\"><stop offset=\"0\" stop-color=\"#cfc5ab\"/><stop offset=\"1\" stop-color=\"#f4eddc\"/></linearGradient></defs>")).End()));
s_825 = Call(WD_38, V.Undef, C_803, ((V)(X0_786)), ((V)(Hh_784)), ((V)(0.06)), ((V)(string.Concat("<path d=\"", ToStr(od_817), "\" fill=\"#000000\" opacity=\"0.35\" transform=\"translate(0.5 0.9)\" filter=\"url(#m12b1)\"/>"))));
s_825 = Add(s_825, Call(WD_38, V.Undef, C_803, ((V)(X0_786)), ((V)(Hh_784)), ((V)(Z_785)), ((V)(JsStrBuf.Begin().V(defs_824).S(string.Concat("<g clip-path=\"url(#tpc)\">", ToStr(Call(artSpace_60, V.Undef, ((V)("tp")), ((V)(W_783)), ((V)(Hh_784)))), ToStr(Call(paperFx_42, V.Undef, ((V)("tp")), ((V)(W_783)), ((V)(Hh_784)), ((V)(1D)))), "<path d=\"M", NumStr((W_783 / 2D)), " 0V", NumStr(Hh_784), "M0 ", NumStr((Hh_784 / 2D)), "H", NumStr(W_783), "\" stroke=\"#ffffff\" stroke-opacity=\"0.18\" stroke-width=\"0.5\"/></g>")).S(string.Concat("<path d=\"", ToStr(od_817), "\" fill=\"none\" stroke=\"#3a2a2e\" stroke-width=\"0.8\" stroke-linejoin=\"round\"/>")).S(string.Concat("<path d=\"", ToStr(d1_819), "\" fill=\"#000000\" opacity=\"0.32\" transform=\"translate(0.8 1)\" filter=\"url(#m12b1)\"/><path d=\"", ToStr(d1_819), "\" fill=\"url(#tpb)\" stroke=\"#3a2a2e\" stroke-width=\"0.6\" stroke-linejoin=\"round\"><animate attributeName=\"d\" values=\"", ToStr(d1_819), ";", ToStr(d2_820), ";", ToStr(d1_819), "\" dur=\"3.4s\" repeatCount=\"indefinite\"", ToStr(Call(SPL_24, V.Undef, ((V)(2D)))), "/></path>")).V(Call(tape_821, V.Undef, ((V)(2.6)), ((V)(2.8)), ((V)(12D)), ((V)(4D)), ((V)((-42D))))).V(Call(tape_821, V.Undef, ((V)(3D)), ((V)((Hh_784 - 3.2))), ((V)(11D)), ((V)(4D)), ((V)(38D)))).V(Call(tape_821, V.Undef, ((V)((W_783 - 1.2))), ((V)((Hh_784 * 0.46))), ((V)(10D)), ((V)(3.6)), ((V)(84D)))).V(Call(tape_821, V.Undef, ((V)((W_783 - 1.6))), ((V)(1.8)), ((V)(6D)), ((V)(3D)), ((V)(45D)), ((V)(0.6)))).End())), ((V)(W_783)), ((V)(Hh_784))));
return NewObj(3).Put("defs", DEF12_37).Put("front", s_825).Put("bb", Invoke(C_803, "bb", ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_787;
return default;
}, 1, "", true));
Set(N_12, "trio12", Fn((V _arrowThis903, int _argc896, V S_902, V _a899, V _a900, V _a901, V[] _rest897) => {
V FS_904 = default;
double FD_905 = 0;
double FB_906 = 0;
double MI_907 = 0;
V FC_908 = default;
V D_909 = default;
FS_904 = Arr(NewObj(5).Put("x", ((V)((-44D)))).Put("w", ((V)(36D))).Put("h", ((V)(50D))).Put("y", ((V)(5D))).Put("a", artRocket_61).V, NewObj(5).Put("x", ((V)(0D))).Put("w", ((V)(40D))).Put("h", ((V)(58D))).Put("y", ((V)(1D))).Put("a", artSaucer_62).V, NewObj(5).Put("x", ((V)(44D))).Put("w", ((V)(36D))).Put("h", ((V)(50D))).Put("y", ((V)(5D))).Put("a", artRobot_63).V);
FD_905 = 2.6;
FB_906 = 2.4;
MI_907 = 3.2;
FC_908 = ((V)("#1c1b1e"));
D_909 = NewObj(5).Put("w", ((V)(136D))).Put("d", ((V)(6D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(44D))).Put("build", Fn((V _arrowThis916, int _argc910, V _a912, V _a913, V _a914, V _a915, V[] _rest911) => {
return Arr();
}, 0, "build", true)).V;
Set(D_909, "fx", Fn((V _arrowThis924, int _argc917, V ctx_923, V _a920, V _a921, V _a922, V[] _rest918) => {
V C_925 = default;
JsStrBuf s_926 = null;
C_925 = Call(cam_15, V.Undef, ctx_923);
s_926 = new JsStrBuf("");
Invoke(FS_904, "forEach", Fn((V _arrowThis935, int _argc927, V F_933, V i_934, V _a931, V _a932, V[] _rest928) => {
double x0_936 = 0;
V yt_937 = default;
double ow_938 = 0;
double oh_939 = 0;
double aw_940 = 0;
double ah_941 = 0;
V p_942 = default;
double e_943 = 0;
V bev_944 = default;
x0_936 = (ToNum(Get(F_933, "x")) - (ToNum(Get(F_933, "w")) / 2D));
yt_937 = Add(Get(F_933, "y"), Get(F_933, "h"));
ow_938 = (ToNum(Get(F_933, "w")) - (2D * FB_906));
oh_939 = (ToNum(Get(F_933, "h")) - (2D * FB_906));
aw_940 = (ow_938 - (2D * MI_907));
ah_941 = (oh_939 - (2D * MI_907));
p_942 = ((V)(JsStrBuf.Begin().S("tr").V(i_934).End()));
e_943 = 0.6;
s_926.V(Call(wsh_39, V.Undef, C_925, ((V)(x0_936)), yt_937, Get(F_933, "w"), Get(F_933, "h"), NewObj(3).Put("dx", ((V)(1.8))).Put("dy", ((V)(2.8))).Put("op", ((V)(0.42))).V));
bev_944 = ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 - e_943))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 - e_943))))), "H", ToStr(Call(f1_25, V.Undef, ((V)(((MI_907 + aw_940) + e_943))))), "L", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 + aw_940))))), " ", NumStr(MI_907), "H", NumStr(MI_907), "Z\" fill=\"#d6ccb6\"/><path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 - e_943))))), " ", ToStr(Call(f1_25, V.Undef, ((V)(((MI_907 + ah_941) + e_943))))), "H", ToStr(Call(f1_25, V.Undef, ((V)(((MI_907 + aw_940) + e_943))))), "L", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 + aw_940))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 + ah_941))))), "H", NumStr(MI_907), "Z\" fill=\"#fffaf0\"/><path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 - e_943))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 - e_943))))), "V", ToStr(Call(f1_25, V.Undef, ((V)(((MI_907 + ah_941) + e_943))))), "L", NumStr(MI_907), " ", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 + ah_941))))), "V", NumStr(MI_907), "Z\" fill=\"#e6ddc9\"/><path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)(((MI_907 + aw_940) + e_943))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 - e_943))))), "V", ToStr(Call(f1_25, V.Undef, ((V)(((MI_907 + ah_941) + e_943))))), "L", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 + aw_940))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((MI_907 + ah_941))))), "V", NumStr(MI_907), "Z\" fill=\"#f8f1e2\"/>")));
s_926.V(Call(WD_38, V.Undef, C_925, ((V)((x0_936 + FB_906))), ((V)((ToNum(yt_937) - FB_906))), ((V)(0.5)), ((V)(string.Concat(string.Concat("<rect width=\"", ToStr(Call(f1_25, V.Undef, ((V)(ow_938)))), "\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)(oh_939)))), "\" fill=\"#efe6d2\"/>", ToStr(bev_944), "<g transform=\"translate(", NumStr(MI_907), " ", NumStr(MI_907), ")\"><clipPath id=\"", ToStr(p_942), "c\"><rect width=\"", ToStr(Call(f1_25, V.Undef, ((V)(aw_940)))), "\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)(ah_941)))), "\"/></clipPath><g clip-path=\"url(#", ToStr(p_942), "c)\">", ToStr(Invoke(F_933, "a", p_942, ((V)(aw_940)), ((V)(ah_941)))), ToStr(Call(paperFx_42, V.Undef, p_942, ((V)(aw_940)), ((V)(ah_941)), ((V)(1D)))), "</g></g>"), string.Concat("<rect width=\"", ToStr(Call(f1_25, V.Undef, ((V)(ow_938)))), "\" height=\"2.6\" fill=\"url(#m12rt)\"/><rect width=\"2.2\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)(oh_939)))), "\" fill=\"url(#m12rl)\"/>")))), ((V)(ow_938)), ((V)(oh_939))));
s_926.V(Call(innerW_40, V.Undef, C_925, ((V)((x0_936 + FB_906))), ((V)((ToNum(Add(((V)(x0_936)), Get(F_933, "w"))) - FB_906))), Add(Get(F_933, "y"), ((V)(FB_906))), ((V)((ToNum(yt_937) - FB_906))), ((V)(0.5)), ((V)(FD_905)), FC_908, ((V)(0.95))));
s_926.V(Call(box3_33, V.Undef, C_925, NewObj(12).Put("c", Arr(Get(F_933, "x"), Get(F_933, "y"), ((V)((FD_905 / 2D))))).Put("w", Get(F_933, "w")).Put("h", Get(F_933, "h")).Put("d", ((V)(FD_905))).Put("r", ((V)(0.3))).Put("col", FC_908).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.5))).Put("hole", NewObj(1).Put("f", Arr(((V)(FB_906)), ((V)(FB_906)), ((V)(FB_906)), ((V)(FB_906)))).V).Put("olc", ((V)("#050506"))).Put("olw", ((V)(0.35))).Put("edge", ((V)(0.3))).V));
s_926.V(Call(pane_36, V.Undef, C_925, Arr(((V)((x0_936 + FB_906))), ((V)((ToNum(yt_937) - FB_906))), ((V)((FD_905 - 0.5)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))), ((V)(ow_938)), ((V)(oh_939)), NewObj(3).Put("t", ((V)(0.04))).Put("g", ((V)(0.85))).Put("e", ((V)(0.25))).V));
return default;
}, 2, "", true));
return NewObj(3).Put("defs", DEF12_37).Put("front", ((V)(s_926.Str))).Put("bb", Invoke(C_925, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_909;
return default;
}, 1, "", true));
Set(N_12, "lbox12", Fn((V _arrowThis952, int _argc945, V S_951, V _a948, V _a949, V _a950, V[] _rest946) => {
double W_953 = 0;
double Hh_954 = 0;
double Dp_955 = 0;
double BW_956 = 0;
double HW_957 = 0;
double HH_958 = 0;
V D_959 = default;
V BP_960 = default;
double L0_961 = 0;
double L1_962 = 0;
double B0_963 = 0;
double B1_964 = 0;
W_953 = 70D;
Hh_954 = 100D;
Dp_955 = 6D;
BW_956 = 9D;
HW_957 = 60D;
HH_958 = 13D;
D_959 = NewObj(5).Put("w", ((V)(80D))).Put("d", ((V)(10D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(30D))).Put("build", Fn((V _arrowThis971, int _argc965, V _a967, V _a968, V _a969, V _a970, V[] _rest966) => {
return Arr();
}, 0, "build", true)).V;
BP_960 = Arr();
L0_961 = (((-W_953) / 2D) + 4.5);
L1_962 = ((W_953 / 2D) - 4.5);
B0_963 = 4.5;
B1_964 = (Hh_954 - 4.5);
{
double i_972 = 0;
i_972 = 0D;
while (true) {
if (!((i_972 < 9D))) break;
Invoke(BP_960, "push", Arr(((V)((L0_961 + (((L1_962 - L0_961) * i_972) / 8D)))), ((V)(B1_964))));
i_972++;
}
}
{
double i_974 = 0;
i_974 = 1D;
while (true) {
if (!((i_974 < 12D))) break;
Invoke(BP_960, "push", Arr(((V)(L1_962)), ((V)((B1_964 - (((B1_964 - B0_963) * i_974) / 12D))))));
i_974++;
}
}
{
double i_976 = 0;
i_976 = 8D;
while (true) {
if (!((i_976 >= 0D))) break;
Invoke(BP_960, "push", Arr(((V)((L0_961 + (((L1_962 - L0_961) * i_976) / 8D)))), ((V)(B0_963))));
i_976--;
}
}
{
double i_978 = 0;
i_978 = 11D;
while (true) {
if (!((i_978 >= 1D))) break;
Invoke(BP_960, "push", Arr(((V)(L0_961)), ((V)((B1_964 - (((B1_964 - B0_963) * i_978) / 12D))))));
i_978--;
}
}
Set(D_959, "fx", Fn((V _arrowThis987, int _argc980, V ctx_986, V _a983, V _a984, V _a985, V[] _rest981) => {
V C_988 = default;
double ow_989 = 0;
double oh_990 = 0;
JsStrBuf s_991 = null;
V sock_992 = default;
V hdr_993 = default;
C_988 = Call(cam_15, V.Undef, ctx_986);
ow_989 = (W_953 - (2D * BW_956));
oh_990 = (Hh_954 - (2D * BW_956));
s_991 = new JsStrBuf("");
s_991.V(Call(WD_38, V.Undef, C_988, ((V)((((-W_953) / 2D) - 12D))), ((V)(((Hh_954 + HH_958) + 12D))), ((V)(0.05)), ((V)(string.Concat("<rect width=\"", NumStr((W_953 + 24D)), "\" height=\"", NumStr(((Hh_954 + HH_958) + 24D)), "\" rx=\"14\" fill=\"#ffc870\" opacity=\"0.3\" filter=\"url(#m11b8)\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.22;0.34;0.22")), ((V)(3.2)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))), "</rect>")))));
s_991.V(Call(wsh_39, V.Undef, C_988, ((V)(((-W_953) / 2D))), ((V)((Hh_954 + HH_958))), ((V)(W_953)), ((V)((Hh_954 + HH_958))), NewObj(3).Put("dx", ((V)(2.2))).Put("dy", ((V)(3.2))).Put("op", ((V)(0.5))).V));
s_991.V(Call(WD_38, V.Undef, C_988, ((V)((((-W_953) / 2D) + BW_956))), ((V)((Hh_954 - BW_956))), ((V)(1.2)), ((V)(string.Concat(string.Concat("<defs><radialGradient id=\"lbh\" cx=\"50%\" cy=\"45%\" r=\"60%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.3\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></radialGradient></defs>", ToStr(Call(artMoon_64, V.Undef, ((V)("lb")), ((V)(ow_989)), ((V)(oh_990)))), "<rect width=\"", NumStr(ow_989), "\" height=\"", NumStr(oh_990), "\" fill=\"url(#lbh)\"/>"), string.Concat("<rect x=\"0.6\" y=\"0.6\" width=\"", NumStr((ow_989 - 1.2)), "\" height=\"", NumStr((oh_990 - 1.2)), "\" fill=\"none\" stroke=\"#e2e5e8\" stroke-width=\"1.2\"/><rect x=\"1.2\" y=\"1.2\" width=\"", NumStr((ow_989 - 2.4)), "\" height=\"", NumStr((oh_990 - 2.4)), "\" fill=\"none\" stroke=\"#8a8f95\" stroke-width=\"0.25\"/>")))), ((V)(ow_989)), ((V)(oh_990))));
s_991.V(Call(innerW_40, V.Undef, C_988, ((V)((((-W_953) / 2D) + BW_956))), ((V)(((W_953 / 2D) - BW_956))), ((V)(BW_956)), ((V)((Hh_954 - BW_956))), ((V)(1.2)), ((V)(Dp_955)), ((V)("#d4d8dc")), ((V)(0.95))));
sock_992 = Invoke(Invoke(BP_960, "map", Fn((V _arrowThis1005, int _argc994, V _a996, V _a997, V _a998, V _a999, V[] _rest995) => {
V x_1002 = default;
V y_1004 = default;
{ V _t1000 = ListOf(_a996);
{ V _t1001 = GetIdx(_t1000, 0D);
x_1002 = _t1001; }
{ V _t1003 = GetIdx(_t1000, 1D);
y_1004 = _t1003; }
}
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, Add(x_1002, ((V)((W_953 / 2D)))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((Hh_954 - ToNum(y_1004)))))), "\" r=\"1.9\" fill=\"#232326\" stroke=\"#c9a24a\" stroke-width=\"0.3\"/>")));
}, 1, "", true)), "join", ((V)("")));
s_991.V(Call(box3_33, V.Undef, C_988, NewObj(12).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)((Dp_955 / 2D))))).Put("w", ((V)(W_953))).Put("h", ((V)(Hh_954))).Put("d", ((V)(Dp_955))).Put("r", ((V)(0.8))).Put("col", ((V)("#141416"))).Put("gl", ((V)(0.5))).Put("hole", NewObj(1).Put("f", Arr(((V)(BW_956)), ((V)(BW_956)), ((V)(BW_956)), ((V)(BW_956)))).V).Put("dec", NewObj(1).Put("f", ((V)(string.Concat("<rect x=\"1.2\" y=\"1.2\" width=\"", NumStr((W_953 - 2.4)), "\" height=\"", NumStr((Hh_954 - 2.4)), "\" rx=\"0.6\" fill=\"none\" stroke=\"#c9a24a\" stroke-width=\"0.45\"/><rect x=\"", NumStr((BW_956 - 1D)), "\" y=\"", NumStr((BW_956 - 1D)), "\" width=\"", NumStr((ow_989 + 2D)), "\" height=\"", NumStr((oh_990 + 2D)), "\" fill=\"none\" stroke=\"#c9a24a\" stroke-width=\"0.45\"/>", ToStr(sock_992))))).V).Put("olc", ((V)("#050506"))).Put("olw", ((V)(0.4))).Put("edge", ((V)(0.3))).V));
hdr_993 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"2.4\" y=\"2.2\" width=\"", NumStr((HW_957 - 4.8)), "\" height=\"8.6\" rx=\"0.8\" fill=\"#fff8e6\"/><rect x=\"2.4\" y=\"2.2\" width=\"", NumStr((HW_957 - 4.8)), "\" height=\"8.6\" rx=\"0.8\" fill=\"url(#lbh)\"/>")).V(Call(T_41, V.Undef, ((V)((HW_957 / 2D))), ((V)(8.6)), ((V)(5.4)), ((V)("#c8202a")), ((V)("NOW PLAYING")), ((V)("letter-spacing=\"0.5\"")))).S(string.Concat("<rect x=\"2.4\" y=\"2.2\" width=\"", NumStr((HW_957 - 4.8)), "\" height=\"8.6\" rx=\"0.8\" fill=\"none\" stroke=\"#c9a24a\" stroke-width=\"0.4\"/>")).End()));
s_991.V(Call(box3_33, V.Undef, C_988, NewObj(11).Put("c", Arr(((V)(0D)), ((V)(Hh_954)), ((V)(2.6)))).Put("w", ((V)(HW_957))).Put("h", ((V)(HH_958))).Put("d", ((V)(5.2))).Put("r", ((V)(0.8))).Put("col", ((V)("#141416"))).Put("gl", ((V)(0.5))).Put("dec", NewObj(1).Put("f", hdr_993).V).Put("olc", ((V)("#050506"))).Put("olw", ((V)(0.4))).Put("edge", ((V)(0.3))).V));
s_991.V(Call(pane_36, V.Undef, C_988, Arr(((V)((((-W_953) / 2D) + BW_956))), ((V)((Hh_954 - BW_956))), ((V)((Dp_955 - 0.6)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))), ((V)(ow_989)), ((V)(oh_990)), NewObj(3).Put("t", ((V)(0.03))).Put("g", ((V)(0.6))).Put("e", ((V)(0.2))).V));
Invoke(BP_960, "forEach", Fn((V _arrowThis1018, int _argc1006, V _a1008, V i_1012, V _a1010, V _a1011, V[] _rest1007) => {
V q_1019 = default;
V c_1020 = default;
double ph_1021 = 0;
V x_1015 = default;
V y_1017 = default;
{ V _t1013 = ListOf(_a1008);
{ V _t1014 = GetIdx(_t1013, 0D);
x_1015 = _t1014; }
{ V _t1016 = GetIdx(_t1013, 1D);
y_1017 = _t1016; }
}
q_1019 = Arr(x_1015, y_1017, ((V)((Dp_955 + 1.1))));
c_1020 = Invoke(C_988, "P", q_1019);
ph_1021 = (ToNum(i_1012) % 4D);
s_991.V(Call(sph_35, V.Undef, C_988, q_1019, ((V)(1.3)), ((V)("#9c875c")))).S(string.Concat("<g opacity=\"1\"><animate attributeName=\"opacity\" values=\"1;1;0.08;0.08\" keyTimes=\"0;0.25;0.5;0.75\" calcMode=\"discrete\" dur=\"1.6s\" begin=\"", ToStr(Call(n4_26, V.Undef, ((V)(((-ph_1021) * 0.4))))), "s\" repeatCount=\"indefinite\"/><circle cx=\"", ToStr(Call(f1_25, V.Undef, GetIdx(c_1020, 0D))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, GetIdx(c_1020, 1D))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_988, "k")) * 3.8))))), "\" fill=\"url(#m11warm)\"/>", ToStr(Call(sph_35, V.Undef, C_988, q_1019, ((V)(1.3)), ((V)("#fff2c4")))), "</g>"));
return default;
}, 2, "", true));
return NewObj(3).Put("defs", DEF12_37).Put("front", ((V)(s_991.Str))).Put("bb", Invoke(C_988, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_959;
return default;
}, 1, "", true));
Set(N_12, "sbox12", Fn((V _arrowThis1029, int _argc1022, V S_1028, V _a1025, V _a1026, V _a1027, V[] _rest1023) => {
double W_1030 = 0;
double Hh_1031 = 0;
double Dp_1032 = 0;
double Tk_1033 = 0;
V WO_1034 = default;
V BR_1035 = default;
V D_1036 = default;
W_1030 = 64D;
Hh_1031 = 82D;
Dp_1032 = 11D;
Tk_1033 = 5D;
WO_1034 = ((V)("#5a3420"));
BR_1035 = ((V)("#d4a640"));
D_1036 = NewObj(5).Put("w", ((V)(70D))).Put("d", ((V)(18D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(40D))).Put("build", Fn((V _arrowThis1043, int _argc1037, V _a1039, V _a1040, V _a1041, V _a1042, V[] _rest1038) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1036, "fx", Fn((V _arrowThis1051, int _argc1044, V ctx_1050, V _a1047, V _a1048, V _a1049, V[] _rest1045) => {
V C_1052 = default;
double iw_1053 = 0;
double ih_1054 = 0;
V rail_1055 = default;
JsStrBuf s_1056 = null;
V photo_1057 = default;
V plq_1058 = default;
double hx_1059 = 0;
double hz_1060 = 0;
C_1052 = Call(cam_15, V.Undef, ctx_1050);
iw_1053 = (W_1030 - (2D * Tk_1033));
ih_1054 = (Hh_1031 - (2D * Tk_1033));
rail_1055 = Fn((V _arrowThis1071, int _argc1061, V c_1067, V w_1068, V h_1069, V f_1070, V[] _rest1062) => {
return Call(box3_33, V.Undef, C_1052, NewObj(12).Put("c", c_1067).Put("w", w_1068).Put("h", h_1069).Put("d", ((V)(Dp_1032))).Put("r", ((V)(0.5))).Put("col", WO_1034).Put("mat", ((V)("wood"))).Put("gl", ((V)(0.35))).Put("dec", (Truthy(f_1070) ? NewObj(1).Put("f", f_1070).V : V.Null)).Put("olc", ((V)("#1e0f06"))).Put("olw", ((V)(0.35))).Put("edge", ((V)(0.25))).V);
}, 4, "", true);
s_1056 = new JsStrBuf("");
s_1056.V(Call(wsh_39, V.Undef, C_1052, ((V)(((-W_1030) / 2D))), ((V)(Hh_1031)), ((V)(W_1030)), ((V)(Hh_1031)), NewObj(3).Put("dx", ((V)(2.6))).Put("dy", ((V)(3.6))).Put("op", ((V)(0.5))).V));
photo_1057 = ((V)(string.Concat(string.Concat("<defs><linearGradient id=\"sbp\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#9c9c9c\"/><stop offset=\"1\" stop-color=\"#3a3a3a\"/></linearGradient><radialGradient id=\"sbf\" cx=\"40%\" cy=\"35%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#f2f2f2\"/><stop offset=\"1\" stop-color=\"#9a9a9a\"/></radialGradient></defs><g transform=\"rotate(-4 11 14)\"><rect x=\"0.5\" y=\"0.8\" width=\"22\" height=\"28\" fill=\"#000000\" opacity=\"0.4\" filter=\"url(#m12b1)\"/><rect width=\"22\" height=\"28\" fill=\"#f4efe4\"/><rect x=\"1.6\" y=\"1.6\" width=\"18.8\" height=\"20\" fill=\"url(#sbp)\"/>", ""), string.Concat("<path d=\"M3.6 21.6Q4.6 15.6 11 15.2Q17.4 15.6 18.4 21.6Z\" fill=\"#2a2a2a\"/><ellipse cx=\"11\" cy=\"10\" rx=\"3.6\" ry=\"4.4\" fill=\"url(#sbf)\"/><path d=\"M7.2 9.4Q7 4.6 11.2 4.8Q15.4 5 14.8 9.6Q13.6 6.8 11 7.2Q8.6 7.4 7.2 9.4Z\" fill=\"#1a1a1a\"/><path d=\"M9.4 15.2L11 18L12.6 15.2\" fill=\"#e8e8e8\"/><path d=\"M8.8 8.9Q9.6 8.4 10.3 8.9M11.7 8.9Q12.4 8.4 13.2 8.9\" stroke=\"#3a3a3a\" stroke-width=\"0.3\" fill=\"none\"/><ellipse cx=\"9.6\" cy=\"9.6\" rx=\"0.5\" ry=\"0.32\" fill=\"#3a3a3a\"/><ellipse cx=\"12.4\" cy=\"9.6\" rx=\"0.5\" ry=\"0.32\" fill=\"#3a3a3a\"/><path d=\"M11 10.2L10.7 11.6H11.3\" stroke=\"#8a8a8a\" stroke-width=\"0.2\" fill=\"none\"/><path d=\"M10 12.6Q11 13.3 12 12.6Q11 12.2 10 12.6Z\" fill=\"#5a5a5a\"/><path d=\"M14.2 9.6Q15.6 12 14.6 14.4Q16.4 12 15 8.4Z\" fill=\"#1a1a1a\"/>", ""), string.Concat("<path d=\"M3 25.4c2 -3 3 1 4.5 -1s2 -2 2.6 0.5c0.6 1.6 2 -2.4 3.4 -0.6s1.6 0.8 3.4 -1.2M4 26.6c4 -0.6 9 -0.8 13 -0.2\" stroke=\"#1d3a9a\" stroke-width=\"0.45\" fill=\"none\" stroke-linecap=\"round\"/><rect width=\"22\" height=\"28\" fill=\"url(#m12gl)\"/></g>", ""))));
s_1056.V(Call(WD_38, V.Undef, C_1052, ((V)(((-iw_1053) / 2D))), ((V)((Hh_1031 - Tk_1033))), ((V)(0.3)), ((V)(string.Concat(string.Concat("<defs><radialGradient id=\"sbl\" cx=\"50%\" cy=\"4%\" r=\"95%\"><stop offset=\"0\" stop-color=\"#fff0c8\" stop-opacity=\"0.38\"/><stop offset=\"0.6\" stop-color=\"#fff0c8\" stop-opacity=\"0.05\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.3\"/></radialGradient></defs><rect width=\"", NumStr(iw_1053), "\" height=\"", NumStr(ih_1054), "\" fill=\"#1f3a2d\"/><rect width=\"", NumStr(iw_1053), "\" height=\"", NumStr(ih_1054), "\" fill=\"url(#sbl)\"/>"), string.Concat("<g transform=\"translate(3 4)\">", ToStr(photo_1057), "</g><rect width=\"", NumStr(iw_1053), "\" height=\"4\" fill=\"url(#m12rt)\"/><rect width=\"3\" height=\"", NumStr(ih_1054), "\" fill=\"url(#m12rl)\"/>")))), ((V)(iw_1053)), ((V)(ih_1054))));
plq_1058 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"", NumStr(((W_1030 / 2D) - 13D)), "\" y=\"1\" width=\"26\" height=\"3\" rx=\"0.4\" fill=\"url(#sbb)\"/><rect x=\"", NumStr(((W_1030 / 2D) - 13D)), "\" y=\"1\" width=\"26\" height=\"3\" rx=\"0.4\" fill=\"none\" stroke=\"#7a5a1c\" stroke-width=\"0.2\"/>")).V(Call(T_41, V.Undef, ((V)((W_1030 / 2D))), ((V)(3D)), ((V)(1.35)), ((V)("#4a3410")), ((V)("GOLDEN AGE \u00b7 SIGNED REPLICA \u00b7 1939")), ((V)("letter-spacing=\"0.15\"")))).End()));
s_1056.S(string.Concat("<defs><linearGradient id=\"sbb\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#f6dc8a\"/><stop offset=\"0.5\" stop-color=\"#c99a3a\"/><stop offset=\"1\" stop-color=\"#8a6420\"/></linearGradient></defs>", ""));
s_1056.V(Add(Add(Call(rail_1055, V.Undef, Arr(((V)(0D)), ((V)(0D)), ((V)((Dp_1032 / 2D)))), ((V)(W_1030)), ((V)(Tk_1033)), plq_1058), Call(rail_1055, V.Undef, Arr(((V)((((-W_1030) / 2D) + (Tk_1033 / 2D)))), ((V)(Tk_1033)), ((V)((Dp_1032 / 2D)))), ((V)(Tk_1033)), ((V)(ih_1054)))), Call(rail_1055, V.Undef, Arr(((V)(((W_1030 / 2D) - (Tk_1033 / 2D)))), ((V)(Tk_1033)), ((V)((Dp_1032 / 2D)))), ((V)(Tk_1033)), ((V)(ih_1054)))));
s_1056.V(Add(Add(Add(Add(Invoke(H_14, "shadow", C_1052, ((V)(13D)), ((V)(4D)), ((V)(3D)), ((V)(2D)), ((V)(0.7)), ((V)((Tk_1033 + 0.02)))), Call(cyl3_34, V.Undef, C_1052, Arr(((V)(15D)), ((V)(Tk_1033)), ((V)(4.2))), Arr(((V)(6D)), ((V)(((Hh_1031 - Tk_1033) - 6D))), ((V)(2.6))), ((V)(0.85)), ((V)("#141416")), NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.25))).V)), Call(cyl3_34, V.Undef, C_1052, Arr(((V)(15D)), ((V)(Tk_1033)), ((V)(4.2))), Arr(((V)(14.7)), ((V)((Tk_1033 + 2.4))), ((V)(4.15))), ((V)(0.95)), BR_1035, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.2))).V)), Call(cyl3_34, V.Undef, C_1052, Arr(((V)(6.6)), ((V)(((Hh_1031 - Tk_1033) - 10.2))), ((V)(2.7))), Arr(((V)(6.3)), ((V)(((Hh_1031 - Tk_1033) - 8.2))), ((V)(2.65))), ((V)(1D)), ((V)("#d9dce0")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V)), Call(sph_35, V.Undef, C_1052, Arr(((V)(6D)), ((V)(((Hh_1031 - Tk_1033) - 6D))), ((V)(2.6))), ((V)(2.1)), BR_1035)));
hx_1059 = (-10D);
hz_1060 = 5.5;
s_1056.V(Add(Add(Add(Invoke(H_14, "shadow", C_1052, ((V)((hx_1059 + 1D))), ((V)((hz_1060 + 0.6))), ((V)(6.2)), ((V)(4D)), ((V)(0.9)), ((V)((Tk_1033 + 0.02)))), Call(cyl3_34, V.Undef, C_1052, Arr(((V)(hx_1059)), ((V)(Tk_1033)), ((V)(hz_1060))), Arr(((V)(hx_1059)), ((V)((Tk_1033 + 0.7))), ((V)(hz_1060))), ((V)(5.4)), ((V)("#1b1b1e")), NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.3))).V)), Call(cyl3_34, V.Undef, C_1052, Arr(((V)(hx_1059)), ((V)((Tk_1033 + 0.7))), ((V)(hz_1060))), Arr(((V)(hx_1059)), ((V)((Tk_1033 + 12D))), ((V)(hz_1060))), ((V)(3.8)), ((V)("#141417")), NewObj(3).Put("r2", ((V)(4.1))).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.3))).V)), Call(cyl3_34, V.Undef, C_1052, Arr(((V)(hx_1059)), ((V)((Tk_1033 + 0.7))), ((V)(hz_1060))), Arr(((V)(hx_1059)), ((V)((Tk_1033 + 3D))), ((V)(hz_1060))), ((V)(3.86)), ((V)("#6a1a2a")), NewObj(4).Put("r2", ((V)(3.92))).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("olw", ((V)(0.2))).V)));
s_1056.V(Call(rail_1055, V.Undef, Arr(((V)(0D)), ((V)((Hh_1031 - Tk_1033))), ((V)((Dp_1032 / 2D)))), ((V)(W_1030)), ((V)(Tk_1033))));
s_1056.V(Call(pane_36, V.Undef, C_1052, Arr(((V)(((-iw_1053) / 2D))), ((V)((Hh_1031 - Tk_1033))), ((V)((Dp_1032 - 0.4)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))), ((V)(iw_1053)), ((V)(ih_1054)), NewObj(3).Put("t", ((V)(0.05))).Put("g", ((V)(0.9))).Put("e", ((V)(0.3))).V));
s_1056.V(Call(WD_38, V.Undef, C_1052, ((V)(((-iw_1053) / 2D))), ((V)((Hh_1031 - Tk_1033))), ((V)((Dp_1032 - 0.3))), ((V)(string.Concat("<defs><linearGradient id=\"sbw\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffe4a8\" stop-opacity=\"0.3\"/><stop offset=\"1\" stop-color=\"#ffe4a8\" stop-opacity=\"0\"/></linearGradient></defs><path d=\"M", NumStr(((iw_1053 / 2D) - 14D)), " 0H", NumStr(((iw_1053 / 2D) + 14D)), "L", NumStr(iw_1053), " ", NumStr((ih_1054 * 0.6)), "H0Z\" fill=\"url(#sbw)\"/>")))));
Invoke(Arr(((V)((-10D))), ((V)(10D))), "forEach", Fn((V _arrowThis1079, int _argc1072, V x_1078, V _a1075, V _a1076, V _a1077, V[] _rest1073) => {
return ((V)(s_1056.V(Call(cyl3_34, V.Undef, C_1052, Arr(x_1078, ((V)((Hh_1031 - 1.6))), ((V)(Dp_1032))), Arr(x_1078, ((V)((Hh_1031 + 2.4))), ((V)((Dp_1032 + 3.6)))), ((V)(0.5)), BR_1035, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.2))).V)).Str));
}, 1, "", true));
s_1056.V(Call(cyl3_34, V.Undef, C_1052, Arr(((V)((-14D))), ((V)((Hh_1031 + 2.9))), ((V)((Dp_1032 + 4.2)))), Arr(((V)(14D)), ((V)((Hh_1031 + 2.9))), ((V)((Dp_1032 + 4.2)))), ((V)(1.8)), BR_1035, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.3))).V));
return NewObj(3).Put("defs", DEF12_37).Put("front", ((V)(s_1056.Str))).Put("bb", Invoke(C_1052, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1036;
return default;
}, 1, "", true));
aNeb_65 = Fn((V _arrowThis1089, int _argc1080, V p_1086, V w_1087, V h_1088, V _a1085, V[] _rest1081) => {
V R_1090 = default;
V st_1091 = default;
V field_1092 = default;
R_1090 = Call(rng_21, V.Undef, ((V)(JsStrBuf.Begin().S("neb").V(p_1086).End())));
st_1091 = Call(rep_27, V.Undef, ((V)(26D)), Fn((V _arrowThis1099, int _argc1093, V _a1095, V _a1096, V _a1097, V _a1098, V[] _rest1094) => {
return Arr(((V)((ToNum(Call(R_1090, V.Undef)) * ToNum(w_1087)))), ((V)((ToNum(Call(R_1090, V.Undef)) * ToNum(h_1088)))), ((V)((0.6 + (ToNum(Call(R_1090, V.Undef)) * 1.8)))), Call(R_1090, V.Undef));
}, 0, "", true));
field_1092 = Fn((V _arrowThis1107, int _argc1100, V dy_1106, V _a1103, V _a1104, V _a1105, V[] _rest1101) => {
return Invoke(Invoke(st_1091, "map", Fn((V _arrowThis1123, int _argc1108, V _a1110, V _a1111, V _a1112, V _a1113, V[] _rest1109) => {
V x_1116 = default;
V y_1118 = default;
V l_1120 = default;
V o_1122 = default;
{ V _t1114 = ListOf(_a1110);
{ V _t1115 = GetIdx(_t1114, 0D);
x_1116 = _t1115; }
{ V _t1117 = GetIdx(_t1114, 1D);
y_1118 = _t1117; }
{ V _t1119 = GetIdx(_t1114, 2D);
l_1120 = _t1119; }
{ V _t1121 = GetIdx(_t1114, 3D);
o_1122 = _t1121; }
}
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_25, V.Undef, x_1116)), " ", ToStr(Call(f1_25, V.Undef, Add(y_1118, dy_1106))), "v", ToStr(Call(f1_25, V.Undef, l_1120)), "\" stroke=\"#dff6ff\" stroke-opacity=\"", ToStr(Call(f1_25, V.Undef, ((V)((0.35 + (ToNum(o_1122) * 0.6)))))), "\" stroke-width=\"0.35\" stroke-linecap=\"round\"/>")));
}, 1, "", true)), "join", ((V)("")));
}, 1, "", true);
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><radialGradient id=\"", ToStr(p_1086), "b\" cx=\"50%\" cy=\"45%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#3a1f7a\"/><stop offset=\"0.55\" stop-color=\"#160c3a\"/><stop offset=\"1\" stop-color=\"#05030f\"/></radialGradient><radialGradient id=\"", ToStr(p_1086), "n\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#ff5fb4\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#ff5fb4\" stop-opacity=\"0\"/></radialGradient></defs><rect width=\"", ToStr(Call(f1_25, V.Undef, w_1087)), "\" height=\"", ToStr(Call(f1_25, V.Undef, h_1088)), "\" fill=\"url(#", ToStr(p_1086), "b)\"/>")).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_1087) * 0.3))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1088) * 0.66))))), "\" rx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_1087) * 0.5))))), "\" ry=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1088) * 0.2))))), "\" fill=\"url(#", ToStr(p_1086), "n)\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.6")), ((V)(5D)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))), "</ellipse>")).S(string.Concat("<g>", ToStr(Call(at_23, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 ", ToStr(Call(f1_25, V.Undef, h_1088))))), ((V)(2.6)))), ToStr(Call(field_1092, V.Undef, ((V)(0D)))), ToStr(Call(field_1092, V.Undef, ((V)((-ToNum(h_1088)))))), "</g>")).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_1087) / 2D))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1088) * 0.56))))), ") scale(", ToStr(Call(n4_26, V.Undef, ((V)((ToNum(w_1087) / 30D))))), ")\"><g>", ToStr(Call(at_23, V.Undef, ((V)("translate")), ((V)("0 -1;0 1;0 -1")), ((V)(2.2)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))), "<g transform=\"translate(0 9)\"><g>", ToStr(Call(at_23, V.Undef, ((V)("scale")), ((V)("1 1;1 1.4;1 0.85;1 1")), ((V)(0.32)))), "<path d=\"M-2.4 0Q0 9 2.4 0Z\" fill=\"#ffb02e\"/><path d=\"M-1.2 0Q0 5 1.2 0Z\" fill=\"#fff6c0\"/></g></g>")).S(string.Concat("<path d=\"M0 -12C4 -8 4.2 0 3 9H-3C-4.2 0 -4 -8 0 -12Z\" fill=\"#e8eef6\"/><path d=\"M0 -12C2 -10 2.6 -7.6 2.8 -6H-2.8C-2.6 -7.6 -2 -10 0 -12Z\" fill=\"#3fd0ff\"/><path d=\"M-3 3L-6.5 9.5L-3 8.6ZM3 3L6.5 9.5L3 8.6Z\" fill=\"#3fd0ff\"/><circle cy=\"-2\" r=\"1.6\" fill=\"#ff5fb4\" stroke=\"#5a5f6a\" stroke-width=\"0.5\"/></g></g>", "")).V(Call(T_41, V.Undef, ((V)((ToNum(w_1087) / 2D))), ((V)((ToNum(h_1088) * 0.12))), ((V)((ToNum(w_1087) * 0.11))), ((V)("#7ff0ff")), ((V)("NEBULA RUN")), ((V)("letter-spacing=\"0.3\"")))).End()));
return default;
}, 3, "", true);
aInk_66 = Fn((V _arrowThis1133, int _argc1124, V p_1130, V w_1131, V h_1132, V _a1129, V[] _rest1125) => {
double P_1134 = 0;
V wave_1135 = default;
P_1134 = (ToNum(w_1131) / 2D);
wave_1135 = Fn((V _arrowThis1148, int _argc1136, V yb_1142, V amp_1143, V col_1144, V op_1145, V[] _rest1137) => {
JsStrBuf d_1149 = null;
V dur_1146 = default;
V rev_1147 = default;
dur_1146 = (_argc1136 > 4 ? _rest1137[0] : V.Undef);
rev_1147 = (_argc1136 > 5 ? _rest1137[1] : V.Undef);
d_1149 = new JsStrBuf(string.Concat("M", ToStr(Call(f1_25, V.Undef, ((V)((-ToNum(w_1131)))))), " ", ToStr(Call(f1_25, V.Undef, yb_1142)), "Q", ToStr(Call(f1_25, V.Undef, ((V)(((-ToNum(w_1131)) + (P_1134 / 4D)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(yb_1142) - ToNum(amp_1143)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)(((-ToNum(w_1131)) + (P_1134 / 2D)))))), " ", ToStr(Call(f1_25, V.Undef, yb_1142))));
{
double x_1150 = 0;
x_1150 = ((-ToNum(w_1131)) + P_1134);
while (true) {
if (!((x_1150 <= ((2D * ToNum(w_1131)) + 0.01)))) break;
d_1149.S(string.Concat("T", ToStr(Call(f1_25, V.Undef, ((V)(x_1150)))), " ", ToStr(Call(f1_25, V.Undef, yb_1142))));
x_1150 = (x_1150 + (P_1134 / 2D));
}
}
d_1149.S(string.Concat("V", ToStr(Call(f1_25, V.Undef, Add(h_1132, ((V)(2D))))), "H", ToStr(Call(f1_25, V.Undef, ((V)((-ToNum(w_1131)))))), "Z"));
return ((V)(string.Concat("<path d=\"", d_1149.Str, "\" fill=\"", ToStr(col_1144), "\" opacity=\"", ToStr(op_1145), "\">", ToStr(Call(at_23, V.Undef, ((V)("translate")), ((V)((Truthy(rev_1147) ? string.Concat(ToStr(Call(f1_25, V.Undef, ((V)(P_1134)))), " 0;0 0") : string.Concat("0 0;", ToStr(Call(f1_25, V.Undef, ((V)(P_1134)))), " 0")))), dur_1146)), "</path>")));
return default;
}, 6, "", true);
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><linearGradient id=\"", ToStr(p_1130), "b\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#0b1430\"/><stop offset=\"1\" stop-color=\"#1b2d5a\"/></linearGradient><radialGradient id=\"", ToStr(p_1130), "g\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff1c8\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#fff1c8\" stop-opacity=\"0\"/></radialGradient></defs><rect width=\"", ToStr(Call(f1_25, V.Undef, w_1131)), "\" height=\"", ToStr(Call(f1_25, V.Undef, h_1132)), "\" fill=\"url(#", ToStr(p_1130), "b)\"/>")).S(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_1131) * 0.68))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1132) * 0.3))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_1131) * 0.3))))), "\" fill=\"url(#", ToStr(p_1130), "g)\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.6")), ((V)(4D)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))), "</circle><circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_1131) * 0.68))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1132) * 0.3))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_1131) * 0.12))))), "\" fill=\"#fff1c8\"/>")).V(Invoke(Call(rep_27, V.Undef, ((V)(2D)), Fn((V _arrowThis1159, int _argc1152, V i_1158, V _a1155, V _a1156, V _a1157, V[] _rest1153) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_1131) * (0.28 + (ToNum(i_1158) * 0.12))))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1132) * (0.4 + (ToNum(i_1158) * 0.06))))))), "\" r=\"1\" fill=\"none\" stroke=\"#8fd4ff\" stroke-width=\"0.4\"><animate attributeName=\"r\" values=\"0.5;", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_1131) * 0.3))))), "\" dur=\"4s\" begin=\"", NumStr(((-ToNum(i_1158)) * 2D)), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.8;0\" dur=\"4s\" begin=\"", NumStr(((-ToNum(i_1158)) * 2D)), "s\" repeatCount=\"indefinite\"/></circle>")));
}, 1, "", true)), "join", ((V)("")))).V(Call(wave_1135, V.Undef, ((V)((ToNum(h_1132) * 0.6))), ((V)(1.6)), ((V)("#2a5aa8")), ((V)(0.75)), ((V)(7D)))).V(Call(wave_1135, V.Undef, ((V)((ToNum(h_1132) * 0.7))), ((V)(2D)), ((V)("#3f86d8")), ((V)(0.8)), ((V)(5D)), ((V)(1D)))).V(Call(wave_1135, V.Undef, ((V)((ToNum(h_1132) * 0.82))), ((V)(2.4)), ((V)("#8fd4ff")), ((V)(0.9)), ((V)(3.6)))).V(Call(T_41, V.Undef, ((V)((ToNum(w_1131) / 2D))), ((V)((ToNum(h_1132) * 0.12))), ((V)((ToNum(w_1131) * 0.12))), ((V)("#ffe9a8")), ((V)("INK TIDE")), ((V)("letter-spacing=\"0.4\"")))).End()));
return default;
}, 3, "", true);
aSq_67 = Fn((V _arrowThis1169, int _argc1160, V p_1166, V w_1167, V h_1168, V _a1165, V[] _rest1161) => {
double k_1170 = 0;
double cx_1171 = 0;
double by_1172 = 0;
k_1170 = (ToNum(w_1167) / 34D);
cx_1171 = (ToNum(w_1167) / 2D);
by_1172 = (ToNum(h_1168) * 0.8);
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><radialGradient id=\"", ToStr(p_1166), "b\" cx=\"50%\" cy=\"55%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#ffb3d6\"/><stop offset=\"1\" stop-color=\"#c2408a\"/></radialGradient><radialGradient id=\"", ToStr(p_1166), "c\" cx=\"36%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#c8a8ff\"/><stop offset=\"0.6\" stop-color=\"#8a5cff\"/><stop offset=\"1\" stop-color=\"#5a2fc8\"/></radialGradient></defs><rect width=\"", ToStr(Call(f1_25, V.Undef, w_1167)), "\" height=\"", ToStr(Call(f1_25, V.Undef, h_1168)), "\" fill=\"url(#", ToStr(p_1166), "b)\"/>")).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_25, V.Undef, ((V)(cx_1171)))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1168) * 0.56))))), ")\"><g>", ToStr(Call(at_23, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(24D)))), ToStr(Invoke(Call(rep_27, V.Undef, ((V)(12D)), Fn((V _arrowThis1180, int _argc1173, V i_1179, V _a1176, V _a1177, V _a1178, V[] _rest1174) => {
double a_1181 = 0;
double b_1182 = 0;
a_1181 = ((ToNum(i_1179) * PI_13) / 6D);
b_1182 = (a_1181 + (PI_13 / 12D));
return ((V)(string.Concat("<path d=\"M0 0L", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1168) * FdLibm.Cos(a_1181)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1168) * FdLibm.Sin(a_1181)))))), "L", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1168) * FdLibm.Cos(b_1182)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1168) * FdLibm.Sin(b_1182)))))), "Z\" fill=\"#ffffff\" opacity=\"0.13\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))), "</g></g>")).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_25, V.Undef, ((V)(cx_1171)))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((by_1172 + 0.6))))), "\" rx=\"", ToStr(Call(f1_25, V.Undef, ((V)((9D * k_1170))))), "\" ry=\"", ToStr(Call(f1_25, V.Undef, ((V)((1.6 * k_1170))))), "\" fill=\"#5a1a4a\" opacity=\"0.35\"><animate attributeName=\"rx\" values=\"", ToStr(Call(f1_25, V.Undef, ((V)((9D * k_1170))))), ";", ToStr(Call(f1_25, V.Undef, ((V)((6D * k_1170))))), ";", ToStr(Call(f1_25, V.Undef, ((V)((9D * k_1170))))), "\" dur=\"1.1s\" repeatCount=\"indefinite\"", ToStr(Call(SPL_24, V.Undef, ((V)(2D)))), "/></ellipse>")).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_25, V.Undef, ((V)(cx_1171)))), " ", ToStr(Call(f1_25, V.Undef, ((V)(by_1172)))), ")\"><g>", ToStr(Call(at_23, V.Undef, ((V)("translate")), ((V)("0 0;0 -6;0 0")), ((V)(1.1)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))), "<g>", ToStr(Call(at_23, V.Undef, ((V)("scale")), ((V)("1.12 0.88;0.95 1.06;1.12 0.88")), ((V)(1.1)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))), "<g transform=\"scale(", ToStr(Call(n4_26, V.Undef, ((V)(k_1170)))), ")\">")).S(string.Concat("<path d=\"M-9 0C-9.5 -8 -5.5 -13 0 -13C5.5 -13 9.5 -8 9 0Z\" fill=\"url(#", ToStr(p_1166), "c)\"/><ellipse cx=\"-3.6\" cy=\"-9.6\" rx=\"2.4\" ry=\"1.4\" fill=\"#ffffff\" opacity=\"0.45\"/><ellipse cx=\"-5\" cy=\"-4\" rx=\"1.4\" ry=\"0.8\" fill=\"#ff8ac8\" opacity=\"0.7\"/><ellipse cx=\"5\" cy=\"-4\" rx=\"1.4\" ry=\"0.8\" fill=\"#ff8ac8\" opacity=\"0.7\"/>")).S(string.Concat("<g transform=\"translate(0 -7)\"><g><animateTransform attributeName=\"transform\" type=\"scale\" values=\"1 1;1 1;1 0.1;1 1\" keyTimes=\"0;0.9;0.95;1\" dur=\"3.2s\" repeatCount=\"indefinite\"/><circle cx=\"-3\" r=\"1.7\" fill=\"#ffffff\"/><circle cx=\"3\" r=\"1.7\" fill=\"#ffffff\"/><circle cx=\"-2.7\" cy=\"0.3\" r=\"0.95\" fill=\"#2a1450\"/><circle cx=\"3.3\" cy=\"0.3\" r=\"0.95\" fill=\"#2a1450\"/></g></g>", "")).S(string.Concat("<path d=\"M-2 -3.4Q0 -1.4 2 -3.4\" stroke=\"#2a1450\" stroke-width=\"0.6\" fill=\"none\" stroke-linecap=\"round\"/></g></g></g></g>", "")).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_1167) / 2D))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(h_1168) * 0.15))))), ")\"><g>", ToStr(Call(at_23, V.Undef, ((V)("scale")), ((V)("1;1.08;1")), ((V)(1.1)), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))), ToStr(Call(T_41, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((ToNum(w_1167) * 0.17))), ((V)("#ffffff")), ((V)("SQUISH!")), ((V)(string.Concat("stroke=\"#6a2fc8\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(w_1167) * 0.02))))), "\" paint-order=\"stroke\""))))), "</g></g>")).End()));
return default;
}, 3, "", true);
Set(N_12, "holo12", Fn((V _arrowThis1190, int _argc1183, V S_1189, V _a1186, V _a1187, V _a1188, V[] _rest1184) => {
V FS_1191 = default;
double FD_1192 = 0;
double FB_1193 = 0;
V D_1194 = default;
FS_1191 = Arr(NewObj(6).Put("x", ((V)((-44D)))).Put("w", ((V)(34D))).Put("h", ((V)(48D))).Put("y", ((V)(6D))).Put("a", aNeb_65).Put("c", ((V)("#3fd0ff"))).V, NewObj(6).Put("x", ((V)(0D))).Put("w", ((V)(38D))).Put("h", ((V)(56D))).Put("y", ((V)(2D))).Put("a", aInk_66).Put("c", ((V)("#7f8cff"))).V, NewObj(6).Put("x", ((V)(44D))).Put("w", ((V)(34D))).Put("h", ((V)(48D))).Put("y", ((V)(6D))).Put("a", aSq_67).Put("c", ((V)("#ff5fb4"))).V);
FD_1192 = 1.6;
FB_1193 = 1.4;
D_1194 = NewObj(5).Put("w", ((V)(132D))).Put("d", ((V)(6D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(44D))).Put("build", Fn((V _arrowThis1201, int _argc1195, V _a1197, V _a1198, V _a1199, V _a1200, V[] _rest1196) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1194, "fx", Fn((V _arrowThis1209, int _argc1202, V ctx_1208, V _a1205, V _a1206, V _a1207, V[] _rest1203) => {
V C_1210 = default;
JsStrBuf s_1211 = null;
C_1210 = Call(cam_15, V.Undef, ctx_1208);
s_1211 = new JsStrBuf("");
Invoke(FS_1191, "forEach", Fn((V _arrowThis1220, int _argc1212, V F_1218, V i_1219, V _a1216, V _a1217, V[] _rest1213) => {
double x0_1221 = 0;
V yt_1222 = default;
double ow_1223 = 0;
double oh_1224 = 0;
V p_1225 = default;
x0_1221 = (ToNum(Get(F_1218, "x")) - (ToNum(Get(F_1218, "w")) / 2D));
yt_1222 = Add(Get(F_1218, "y"), Get(F_1218, "h"));
ow_1223 = (ToNum(Get(F_1218, "w")) - (2D * FB_1193));
oh_1224 = (ToNum(Get(F_1218, "h")) - (2D * FB_1193));
p_1225 = ((V)(JsStrBuf.Begin().S("hg").V(i_1219).End()));
s_1211.V(Call(WD_38, V.Undef, C_1210, ((V)((x0_1221 - 4D))), Add(yt_1222, ((V)(4D))), ((V)(0.05)), ((V)(string.Concat("<rect width=\"", ToStr(Add(Get(F_1218, "w"), ((V)(8D)))), "\" height=\"", ToStr(Add(Get(F_1218, "h"), ((V)(8D)))), "\" rx=\"5\" fill=\"", ToStr(Get(F_1218, "c")), "\" opacity=\"0.5\" filter=\"url(#m11b4)\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.35;0.6;0.35")), ((V)((3D + (ToNum(i_1219) * 0.6)))), ((V)(0D)), Call(SPL_24, V.Undef, ((V)(2D))))), "</rect>")))));
s_1211.V(Call(wsh_39, V.Undef, C_1210, ((V)(x0_1221)), yt_1222, Get(F_1218, "w"), Get(F_1218, "h"), NewObj(3).Put("dx", ((V)(1.2))).Put("dy", ((V)(2D))).Put("op", ((V)(0.4))).V));
s_1211.V(Call(WD_38, V.Undef, C_1210, ((V)((x0_1221 + FB_1193))), ((V)((ToNum(yt_1222) - FB_1193))), ((V)(0.7)), ((V)(string.Concat(string.Concat("<clipPath id=\"", ToStr(p_1225), "c\"><rect width=\"", ToStr(Call(f1_25, V.Undef, ((V)(ow_1223)))), "\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)(oh_1224)))), "\"/></clipPath><g clip-path=\"url(#", ToStr(p_1225), "c)\">", ToStr(Invoke(F_1218, "a", p_1225, ((V)(ow_1223)), ((V)(oh_1224)))), "<rect width=\"", ToStr(Call(f1_25, V.Undef, ((V)(ow_1223)))), "\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)(oh_1224)))), "\" fill=\"url(#m12scan)\"/><rect x=\"", ToStr(Call(f1_25, V.Undef, ((V)(((-ow_1223) * 0.6))))), "\" width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ow_1223 * 0.45))))), "\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)(oh_1224)))), "\" fill=\"url(#m12sh)\" transform=\"skewX(-18)\">", ToStr(Call(at_23, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 0;", ToStr(Call(f1_25, V.Undef, ((V)((ow_1223 * 2.4))))), " 0"))), ((V)(5.5)), ((V)(((-ToNum(i_1219)) * 1.7))), ((V)(" keyTimes=\"0;0.55;1\" additive=\"sum\"")))), "</rect></g>"), string.Concat("<rect x=\"0.25\" y=\"0.25\" width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ow_1223 - 0.5))))), "\" height=\"", ToStr(Call(f1_25, V.Undef, ((V)((oh_1224 - 0.5))))), "\" fill=\"none\" stroke=\"", ToStr(Get(F_1218, "c")), "\" stroke-width=\"0.5\" opacity=\"0.8\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.5;0.95;0.5")), ((V)((2.4 + (ToNum(i_1219) * 0.4)))))), "</rect>")))), ((V)(ow_1223)), ((V)(oh_1224))));
s_1211.V(Call(innerW_40, V.Undef, C_1210, ((V)((x0_1221 + FB_1193))), ((V)((ToNum(Add(((V)(x0_1221)), Get(F_1218, "w"))) - FB_1193))), Add(Get(F_1218, "y"), ((V)(FB_1193))), ((V)((ToNum(yt_1222) - FB_1193))), ((V)(0.7)), ((V)(FD_1192)), ((V)("#16171c")), ((V)(0.9))));
s_1211.V(Call(box3_33, V.Undef, C_1210, NewObj(11).Put("c", Arr(Get(F_1218, "x"), Get(F_1218, "y"), ((V)((FD_1192 / 2D))))).Put("w", Get(F_1218, "w")).Put("h", Get(F_1218, "h")).Put("d", ((V)(FD_1192))).Put("r", ((V)(0.3))).Put("col", ((V)("#101116"))).Put("gl", ((V)(0.9))).Put("hole", NewObj(1).Put("f", Arr(((V)(FB_1193)), ((V)(FB_1193)), ((V)(FB_1193)), ((V)(FB_1193)))).V).Put("olc", ((V)("#020203"))).Put("olw", ((V)(0.3))).Put("edge", ((V)(0.4))).V));
s_1211.V(Call(pane_36, V.Undef, C_1210, Arr(((V)((x0_1221 + FB_1193))), ((V)((ToNum(yt_1222) - FB_1193))), ((V)((FD_1192 - 0.3)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))), ((V)(ow_1223)), ((V)(oh_1224)), NewObj(3).Put("t", ((V)(0.02))).Put("g", ((V)(0.7))).Put("e", ((V)(0.2))).V));
return default;
}, 2, "", true));
return NewObj(3).Put("defs", DEF12_37).Put("front", ((V)(s_1211.Str))).Put("bb", Invoke(C_1210, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1194;
return default;
}, 1, "", true));
Set(N_12, "lant12", Fn((V _arrowThis1233, int _argc1226, V S_1232, V _a1229, V _a1230, V _a1231, V[] _rest1227) => {
V COL_1234 = default;
double HX_1235 = 0;
double HY_1236 = 0;
double SAG_1237 = 0;
V XS_1238 = default;
V D_1239 = default;
COL_1234 = Arr(((V)("#fff0cc")), ((V)("#ffb8cb")), ((V)("#c4f2d8")), ((V)("#c4e2ff")), ((V)("#dccbff")), ((V)("#ffd3aa")), ((V)("#fff2a6")));
HX_1235 = 76D;
HY_1236 = 100D;
SAG_1237 = 17D;
XS_1238 = Arr(((V)((-57D))), ((V)((-38D))), ((V)((-19D))), ((V)(0D)), ((V)(19D)), ((V)(38D)), ((V)(57D)));
D_1239 = NewObj(5).Put("w", ((V)(160D))).Put("d", ((V)(16D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(24D))).Put("build", Fn((V _arrowThis1246, int _argc1240, V _a1242, V _a1243, V _a1244, V _a1245, V[] _rest1241) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1239, "fx", Fn((V _arrowThis1254, int _argc1247, V ctx_1253, V _a1250, V _a1251, V _a1252, V[] _rest1248) => {
V C_1255 = default;
V cy_1256 = default;
V cz_1257 = default;
V defs_1258 = default;
JsStrBuf s_1259 = null;
V cp_1260 = default;
V cd_1261 = default;
C_1255 = Call(cam_15, V.Undef, ctx_1253);
cy_1256 = Fn((V _arrowThis1269, int _argc1262, V x_1268, V _a1265, V _a1266, V _a1267, V[] _rest1263) => {
return ((V)((HY_1236 - (SAG_1237 * (1D - Pow((ToNum(x_1268) / HX_1235), 2D))))));
}, 1, "", true);
cz_1257 = Fn((V _arrowThis1277, int _argc1270, V x_1276, V _a1273, V _a1274, V _a1275, V[] _rest1271) => {
return ((V)((1.4 + (3.4 * (1D - Pow((ToNum(x_1276) / HX_1235), 2D))))));
}, 1, "", true);
defs_1258 = Invoke(Invoke(COL_1234, "map", Fn((V _arrowThis1286, int _argc1278, V c_1284, V i_1285, V _a1282, V _a1283, V[] _rest1279) => {
return ((V)(string.Concat("<radialGradient id=\"ln", ToStr(i_1285), "\" cx=\"44%\" cy=\"40%\" r=\"62%\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.3\" stop-color=\"", ToStr(Call(shade_11, V.Undef, c_1284, ((V)(1.06)))), "\"/><stop offset=\"0.8\" stop-color=\"", ToStr(c_1284), "\"/><stop offset=\"1\" stop-color=\"", ToStr(Call(shade_11, V.Undef, c_1284, ((V)(0.7)))), "\"/></radialGradient><radialGradient id=\"lw", ToStr(i_1285), "\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"", ToStr(c_1284), "\" stop-opacity=\"0.75\"/><stop offset=\"0.45\" stop-color=\"", ToStr(c_1284), "\" stop-opacity=\"0.22\"/><stop offset=\"1\" stop-color=\"", ToStr(c_1284), "\" stop-opacity=\"0\"/></radialGradient>")));
}, 2, "", true)), "join", ((V)("")));
s_1259 = new JsStrBuf(string.Concat("<defs>", ToStr(defs_1258), "</defs>"));
Invoke(XS_1238, "forEach", Fn((V _arrowThis1295, int _argc1287, V x_1293, V i_1294, V _a1291, V _a1292, V[] _rest1288) => {
double r_1296 = 0;
double ly_1297 = 0;
r_1296 = (NumTruthy((ToNum(i_1294) % 2D)) ? 6D : 7D);
ly_1297 = ((ToNum(Call(cy_1256, V.Undef, x_1293)) - 2.6) - r_1296);
s_1259.V(Call(WD_38, V.Undef, C_1255, ((V)((ToNum(x_1293) - 18D))), ((V)((ly_1297 + 18D))), ((V)(0.05)), ((V)(string.Concat("<circle cx=\"18\" cy=\"18\" r=\"18\" fill=\"url(#lw", ToStr(i_1294), ")\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.8;1;0.85;1;0.8")), ((V)((3D + (ToNum(i_1294) * 0.37)))))), "</circle>"))), ((V)(36D)), ((V)(36D))));
return default;
}, 2, "", true));
cp_1260 = Call(rep_27, V.Undef, ((V)(41D)), Fn((V _arrowThis1305, int _argc1298, V j_1304, V _a1301, V _a1302, V _a1303, V[] _rest1299) => {
double x_1306 = 0;
x_1306 = ((-HX_1235) + (((ToNum(j_1304) * 2D) * HX_1235) / 40D));
return Invoke(C_1255, "p", ((V)(x_1306)), Call(cy_1256, V.Undef, ((V)(x_1306))), Call(cz_1257, V.Undef, ((V)(x_1306))));
return default;
}, 1, "", true));
cd_1261 = Call(ln_44, V.Undef, cp_1260);
s_1259.S(string.Concat("<path d=\"", ToStr(cd_1261), "\" stroke=\"#000000\" stroke-opacity=\"0.2\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_1255, "k")) * 0.9))))), "\" fill=\"none\" transform=\"translate(", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_1255, "k")) * 0.8))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_1255, "k")) * 1.8))))), ")\" filter=\"url(#m12b1)\"/><path d=\"", ToStr(cd_1261), "\" stroke=\"#2c2622\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_1255, "k")) * 0.55))))), "\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"", ToStr(cd_1261), "\" stroke=\"#8a7a6a\" stroke-opacity=\"0.5\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_1255, "k")) * 0.18))))), "\" fill=\"none\" transform=\"translate(0 ", ToStr(Call(f1_25, V.Undef, ((V)(((-ToNum(Get(C_1255, "k"))) * 0.15))))), ")\"/>"));
Invoke(Arr(((V)((-HX_1235))), ((V)(HX_1235))), "forEach", Fn((V _arrowThis1314, int _argc1307, V x_1313, V _a1310, V _a1311, V _a1312, V[] _rest1308) => {
return ((V)(s_1259.V(Add(Call(cyl3_34, V.Undef, C_1255, Arr(x_1313, ((V)(HY_1236)), ((V)(0D))), Arr(x_1313, ((V)(HY_1236)), ((V)(1.8))), ((V)(0.55)), ((V)("#c9ccd0")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V), Call(sph_35, V.Undef, C_1255, Arr(x_1313, ((V)(HY_1236)), ((V)(1.9))), ((V)(0.8)), ((V)("#d9dce0"))))).Str));
}, 1, "", true));
Invoke(XS_1238, "forEach", Fn((V _arrowThis1323, int _argc1315, V x_1321, V i_1322, V _a1319, V _a1320, V[] _rest1316) => {
double r_1324 = 0;
V c_1325 = default;
V q0_1326 = default;
V ctr_1327 = default;
double R_1328 = 0;
double ry_1329 = 0;
double wy_1330 = 0;
double a_1331 = 0;
JsStrBuf L_1332 = null;
r_1324 = (NumTruthy((ToNum(i_1322) % 2D)) ? 6D : 7D);
c_1325 = GetK(COL_1234, i_1322);
q0_1326 = Invoke(C_1255, "p", x_1321, Call(cy_1256, V.Undef, x_1321), Call(cz_1257, V.Undef, x_1321));
ctr_1327 = Invoke(C_1255, "p", x_1321, ((V)(((ToNum(Call(cy_1256, V.Undef, x_1321)) - 2.6) - (r_1324 * 0.92)))), Add(Call(cz_1257, V.Undef, x_1321), ((V)(0.6))));
R_1328 = (r_1324 * ToNum(Get(C_1255, "k")));
ry_1329 = (R_1328 * 0.92);
wy_1330 = (ToNum(GetIdx(ctr_1327, 1D)) - ry_1329);
a_1331 = (3D + (ToNum(i_1322) % 3D));
L_1332 = new JsStrBuf(string.Concat(string.Concat("<path d=\"M", ToStr(Call(P2_28, V.Undef, q0_1326)), "L", ToStr(Call(f1_25, V.Undef, GetIdx(ctr_1327, 0D))), " ", ToStr(Call(f1_25, V.Undef, ((V)(wy_1330)))), "\" stroke=\"#3a332c\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_1255, "k")) * 0.22))))), "\"/><ellipse cx=\"", ToStr(Call(f1_25, V.Undef, GetIdx(ctr_1327, 0D))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, GetIdx(ctr_1327, 1D))), "\" rx=\"", ToStr(Call(f1_25, V.Undef, ((V)(R_1328)))), "\" ry=\"", ToStr(Call(f1_25, V.Undef, ((V)(ry_1329)))), "\" fill=\"url(#ln", ToStr(i_1322), ")\"/>"), string.Concat("<ellipse cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(GetIdx(ctr_1327, 0D)) - (R_1328 * 0.08)))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(GetIdx(ctr_1327, 1D)) - (ry_1329 * 0.06)))))), "\" rx=\"", ToStr(Call(f1_25, V.Undef, ((V)((R_1328 * 0.42))))), "\" ry=\"", ToStr(Call(f1_25, V.Undef, ((V)((ry_1329 * 0.42))))), "\" fill=\"#ffffff\" opacity=\"0.35\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.22;0.45;0.3;0.42;0.22")), ((V)((2.2 + (ToNum(i_1322) * 0.3)))))), "</ellipse>")));
{
double k_1333 = 0;
k_1333 = (-2D);
while (true) {
if (!((k_1333 <= 2D))) break;
V yy_1335 = default;
double hw_1336 = 0;
yy_1335 = Add(GetIdx(ctr_1327, 1D), ((V)(((k_1333 * ry_1329) * 0.34))));
hw_1336 = (R_1328 * System.Math.Sqrt(Max(0D, (1D - Pow((k_1333 * 0.34), 2D)))));
L_1332.S(string.Concat("<path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(GetIdx(ctr_1327, 0D)) - hw_1336))))), " ", ToStr(Call(f1_25, V.Undef, yy_1335)), "Q", ToStr(Call(f1_25, V.Undef, GetIdx(ctr_1327, 0D))), " ", ToStr(Call(f1_25, V.Undef, Add(yy_1335, ((V)((R_1328 * 0.12)))))), " ", ToStr(Call(f1_25, V.Undef, Add(GetIdx(ctr_1327, 0D), ((V)(hw_1336))))), " ", ToStr(Call(f1_25, V.Undef, yy_1335)), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_11, V.Undef, c_1325, ((V)(0.6)))), "\" stroke-opacity=\"0.42\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_1255, "k")) * 0.16))))), "\"/>"));
k_1333++;
}
}
L_1332.S(string.Concat("<path d=\"M", ToStr(Call(f1_25, V.Undef, GetIdx(ctr_1327, 0D))), " ", ToStr(Call(f1_25, V.Undef, ((V)(wy_1330)))), "Q", ToStr(Call(f1_25, V.Undef, Add(GetIdx(ctr_1327, 0D), ((V)((R_1328 * 0.1)))))), " ", ToStr(Call(f1_25, V.Undef, GetIdx(ctr_1327, 1D))), " ", ToStr(Call(f1_25, V.Undef, GetIdx(ctr_1327, 0D))), " ", ToStr(Call(f1_25, V.Undef, Add(GetIdx(ctr_1327, 1D), ((V)(ry_1329))))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_11, V.Undef, c_1325, ((V)(0.6)))), "\" stroke-opacity=\"0.2\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_1255, "k")) * 0.14))))), "\"/><ellipse cx=\"", ToStr(Call(f1_25, V.Undef, GetIdx(ctr_1327, 0D))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, GetIdx(ctr_1327, 1D))), "\" rx=\"", ToStr(Call(f1_25, V.Undef, ((V)(R_1328)))), "\" ry=\"", ToStr(Call(f1_25, V.Undef, ((V)(ry_1329)))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_11, V.Undef, c_1325, ((V)(0.4)))), "\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_1255, "k")) * 0.45))))), "\"/>")).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_25, V.Undef, GetIdx(ctr_1327, 0D))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((wy_1330 + (R_1328 * 0.04)))))), "\" rx=\"", ToStr(Call(f1_25, V.Undef, ((V)((R_1328 * 0.34))))), "\" ry=\"", ToStr(Call(f1_25, V.Undef, ((V)((R_1328 * 0.12))))), "\" fill=\"#2a2420\"/><ellipse cx=\"", ToStr(Call(f1_25, V.Undef, GetIdx(ctr_1327, 0D))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Add(GetIdx(ctr_1327, 1D), ((V)(ry_1329)))) - (R_1328 * 0.04)))))), "\" rx=\"", ToStr(Call(f1_25, V.Undef, ((V)((R_1328 * 0.3))))), "\" ry=\"", ToStr(Call(f1_25, V.Undef, ((V)((R_1328 * 0.11))))), "\" fill=\"#2a2420\"/><path d=\"M", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(GetIdx(ctr_1327, 0D)) - (R_1328 * 0.25)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)(wy_1330)))), "H", ToStr(Call(f1_25, V.Undef, Add(GetIdx(ctr_1327, 0D), ((V)((R_1328 * 0.1)))))), "\" stroke=\"#7a6a5a\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_1255, "k")) * 0.15))))), "\"/>"));
s_1259.S(string.Concat("<g><animateTransform attributeName=\"transform\" type=\"rotate\" values=\"", NumStr((-a_1331)), " ", ToStr(Call(P2_28, V.Undef, q0_1326)), ";", NumStr(a_1331), " ", ToStr(Call(P2_28, V.Undef, q0_1326)), ";", NumStr((-a_1331)), " ", ToStr(Call(P2_28, V.Undef, q0_1326)), "\" dur=\"", ToStr(Call(n4_26, V.Undef, ((V)((3.2 + (ToNum(i_1322) * 0.41)))))), "s\" begin=\"", ToStr(Call(n4_26, V.Undef, ((V)(((-ToNum(i_1322)) * 0.7))))), "s\" repeatCount=\"indefinite\"", ToStr(Call(SPL_24, V.Undef, ((V)(2D)))), "/>", L_1332.Str, "</g>"));
return default;
}, 2, "", true));
Call(ext_32, V.Undef, C_1255, Arr(Arr(((V)(((-HX_1235) - 2D))), ((V)((HY_1236 + 3D))), ((V)(0D))), Arr(((V)((HX_1235 + 2D))), ((V)((ToNum(Call(cy_1256, V.Undef, ((V)(0D)))) - 20D))), ((V)(0D)))));
return NewObj(3).Put("defs", DEF12_37).Put("front", ((V)(s_1259.Str))).Put("bb", Invoke(C_1255, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1239;
return default;
}, 1, "", true));
GL_68 = NewObj(7).Put("N", Arr(((V)(0.62)), ((V)("M0 1L0 0L1 1L1 0")))).Put("O", Arr(((V)(0.7)), ((V)("M0.5 0C0.1 0 0 0.3 0 0.5C0 0.7 0.1 1 0.5 1C0.9 1 1 0.7 1 0.5C1 0.3 0.9 0 0.5 0Z")))).Put("W", Arr(((V)(0.9)), ((V)("M0 0L0.25 1L0.5 0.35L0.75 1L1 0")))).Put("S", Arr(((V)(0.55)), ((V)("M0.95 0.15C0.8 0 0.2 -0.02 0.08 0.2C-0.02 0.42 0.3 0.48 0.5 0.52C0.75 0.57 1.02 0.62 0.94 0.82C0.85 1.04 0.2 1.02 0.04 0.85")))).Put("H", Arr(((V)(0.6)), ((V)("M0 0L0 1M1 0L1 1M0 0.5L1 0.5")))).Put("I", Arr(((V)(0D)), ((V)("M0 0L0 1")))).Put("G", Arr(((V)(0.68)), ((V)("M0.95 0.18C0.85 0.04 0.7 0 0.5 0C0.15 0 0 0.25 0 0.5C0 0.78 0.18 1 0.5 1C0.8 1 1 0.82 1 0.55L0.55 0.55")))).V;
GS_69 = Fn((V _arrowThis1348, int _argc1337, V d_1343, V x0_1344, V y0_1345, V w_1346, V[] _rest1338) => {
V h_1347 = default;
h_1347 = (_argc1337 > 4 ? _rest1338[0] : V.Undef);
return Invoke(d_1343, "replace", NewRegExp(RX0, "(-?\\d*\\.?\\d+) (-?\\d*\\.?\\d+)", "g"), Fn((V _arrowThis1358, int _argc1349, V m_1355, V a_1356, V b_1357, V _a1354, V[] _rest1350) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_25, V.Undef, Add(x0_1344, ((V)((ToNum(a_1356) * ToNum(w_1346))))))).S(" ").V(Call(f1_25, V.Undef, Add(y0_1345, ((V)((ToNum(b_1357) * ToNum(h_1347))))))).End()));
}, 3, "", true));
}, 5, "", true);
word_70 = Fn((V _arrowThis1370, int _argc1359, V str_1365, V cx_1366, V y_1367, V hg_1368, V[] _rest1360) => {
V ws_1371 = default;
V tw_1372 = default;
V x_1373 = default;
JsStrBuf d_1374 = null;
V gap_1369 = default;
gap_1369 = (_argc1359 > 4 ? _rest1360[0] : V.Undef);
ws_1371 = Invoke(Invoke(str_1365, "split", ((V)(""))), "map", Fn((V _arrowThis1382, int _argc1375, V ch_1381, V _a1378, V _a1379, V _a1380, V[] _rest1376) => {
return ((V)((ToNum(GetIdx(GetK(GL_68, ch_1381), 0D)) * ToNum(hg_1368))));
}, 1, "", true));
tw_1372 = Add(Invoke(ws_1371, "reduce", Fn((V _arrowThis1391, int _argc1383, V a_1389, V b_1390, V _a1387, V _a1388, V[] _rest1384) => {
return Add(a_1389, b_1390);
}, 2, "", true), ((V)(0D))), ((V)((ToNum(gap_1369) * (ToNum(Get(str_1365, "length")) - 1D)))));
x_1373 = ((V)((ToNum(cx_1366) - (ToNum(tw_1372) / 2D))));
d_1374 = new JsStrBuf("");
Invoke(Invoke(str_1365, "split", ((V)(""))), "forEach", Fn((V _arrowThis1400, int _argc1392, V ch_1398, V i_1399, V _a1396, V _a1397, V[] _rest1393) => {
d_1374.V(Call(GS_69, V.Undef, GetIdx(GetK(GL_68, ch_1398), 1D), x_1373, y_1367, GetK(ws_1371, i_1399), hg_1368));
x_1373 = Add(x_1373, Add(GetK(ws_1371, i_1399), gap_1369));
return default;
}, 2, "", true));
return ((V)(d_1374.Str));
return default;
}, 5, "", true);
tube_71 = Fn((V _arrowThis1410, int _argc1401, V d_1407, V col_1408, V ex_1409, V _a1406, V[] _rest1402) => {
return ((V)(string.Concat("<g fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\">", ToStr((ex_1409 is var _t1411 && Truthy(_t1411) ? _t1411 : ((V)("")))), "<path d=\"", ToStr(d_1407), "\" stroke=\"", ToStr(col_1408), "\" stroke-width=\"4.6\" opacity=\"0.35\" filter=\"url(#m12b2)\"/><path d=\"", ToStr(d_1407), "\" stroke=\"", ToStr(col_1408), "\" stroke-width=\"2.2\"/><path d=\"", ToStr(d_1407), "\" stroke=\"#ffffff\" stroke-width=\"0.7\" opacity=\"0.8\"/></g>")));
}, 3, "", true);
Set(N_12, "neon12", Fn((V _arrowThis1419, int _argc1412, V S_1418, V _a1415, V _a1416, V _a1417, V[] _rest1413) => {
double W_1420 = 0;
double Hh_1421 = 0;
V D_1422 = default;
W_1420 = 118D;
Hh_1421 = 62D;
D_1422 = NewObj(5).Put("w", ((V)(124D))).Put("d", ((V)(10D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(50D))).Put("build", Fn((V _arrowThis1429, int _argc1423, V _a1425, V _a1426, V _a1427, V _a1428, V[] _rest1424) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1422, "fx", Fn((V _arrowThis1437, int _argc1430, V ctx_1436, V _a1433, V _a1434, V _a1435, V[] _rest1431) => {
V C_1438 = default;
V bd_1439 = default;
V nw_1440 = default;
V sw_1441 = default;
V FLK_1442 = default;
V chev_1443 = default;
V tubes_1444 = default;
V s_1445 = default;
C_1438 = Call(cam_15, V.Undef, ctx_1436);
bd_1439 = ((V)("M10 4.5H108Q113.5 4.5 113.5 10V52Q113.5 57.5 108 57.5H10Q4.5 57.5 4.5 52V10Q4.5 4.5 10 4.5Z"));
nw_1440 = Call(word_70, V.Undef, ((V)("NOW")), ((V)(59D)), ((V)(9D)), ((V)(20D)), ((V)(4D)));
sw_1441 = Call(word_70, V.Undef, ((V)("SHOWING")), ((V)(59D)), ((V)(36D)), ((V)(12D)), ((V)(3D)));
FLK_1442 = Call(an_22, V.Undef, ((V)("opacity")), ((V)("1;1;0.25;1;0.4;1;1")), ((V)(6D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.8;0.81;0.83;0.84;0.86;1\"")));
chev_1443 = Fn((V _arrowThis1455, int _argc1446, V x_1452, V dir_1453, V i_1454, V _a1451, V[] _rest1447) => {
return ((V)(string.Concat("<g opacity=\"0.2\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.15;1;0.15")), ((V)(1.2)), ((V)((-(ToNum((GtN(dir_1453, 0D) ? i_1454 : ((V)((2D - ToNum(i_1454)))))) * 0.4)))))), ToStr(Call(tube_71, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_25, V.Undef, x_1452)), " 38.5L", ToStr(Call(f1_25, V.Undef, Add(x_1452, ((V)((2.6 * ToNum(dir_1453))))))), " 42L", ToStr(Call(f1_25, V.Undef, x_1452)), " 45.5"))), ((V)("#ffb347")))), "</g>")));
}, 3, "", true);
tubes_1444 = Add(Add(Add(Call(tube_71, V.Undef, bd_1439, ((V)("#ffb347"))), Call(tube_71, V.Undef, nw_1440, ((V)("#ff4fa0")), FLK_1442)), Call(tube_71, V.Undef, sw_1441, ((V)("#3fe0ff")))), Invoke(Call(rep_27, V.Undef, ((V)(3D)), Fn((V _arrowThis1463, int _argc1456, V i_1462, V _a1459, V _a1460, V _a1461, V[] _rest1457) => {
return Add(Call(chev_1443, V.Undef, ((V)((16.5 - (ToNum(i_1462) * 3.6)))), ((V)((-1D))), i_1462), Call(chev_1443, V.Undef, ((V)((101.5 + (ToNum(i_1462) * 3.6)))), ((V)(1D)), i_1462));
}, 1, "", true)), "join", ((V)(""))));
s_1445 = Call(WD_38, V.Undef, C_1438, ((V)((((-W_1420) / 2D) - 16D))), ((V)((Hh_1421 + 16D))), ((V)(0.05)), ((V)(string.Concat("<defs><linearGradient id=\"ngw\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ff4fa0\"/><stop offset=\"1\" stop-color=\"#3fe0ff\"/></linearGradient></defs><rect width=\"", NumStr((W_1420 + 32D)), "\" height=\"", NumStr((Hh_1421 + 32D)), "\" rx=\"22\" fill=\"url(#ngw)\" opacity=\"0.4\" filter=\"url(#m11b8)\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.32;0.45;0.32")), ((V)(4D)))), "</rect>"))));
s_1445 = Add(s_1445, Call(wsh_39, V.Undef, C_1438, ((V)(((-W_1420) / 2D))), ((V)(Hh_1421)), ((V)(W_1420)), ((V)(Hh_1421)), NewObj(3).Put("dx", ((V)(1.4))).Put("dy", ((V)(2.2))).Put("op", ((V)(0.45))).V));
s_1445 = Add(s_1445, Call(box3_33, V.Undef, C_1438, NewObj(11).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)(1.6)))).Put("w", ((V)(W_1420))).Put("h", ((V)(Hh_1421))).Put("d", ((V)(2.4))).Put("r", ((V)(2.4))).Put("col", ((V)("#16151b"))).Put("mat", ((V)("noise"))).Put("gl", ((V)(0.55))).Put("olc", ((V)("#050506"))).Put("olw", ((V)(0.35))).Put("edge", ((V)(0.3))).V));
s_1445 = Add(s_1445, Call(WD_38, V.Undef, C_1438, ((V)(((-W_1420) / 2D))), ((V)(Hh_1421)), ((V)(2.85)), ((V)(string.Concat("<g opacity=\"0.5\" filter=\"url(#m11b4)\" fill=\"none\" stroke-width=\"3\"><path d=\"", ToStr(bd_1439), "\" stroke=\"#ffb347\"/><path d=\"", ToStr(nw_1440), "\" stroke=\"#ff4fa0\">", ToStr(FLK_1442), "</path><path d=\"", ToStr(sw_1441), "\" stroke=\"#3fe0ff\"/></g>"))), ((V)(W_1420)), ((V)(Hh_1421))));
Invoke(Arr(Arr(((V)((-54D))), ((V)(4D))), Arr(((V)(54D)), ((V)(4D))), Arr(((V)((-54D))), ((V)(58D))), Arr(((V)(54D)), ((V)(58D)))), "forEach", Fn((V _arrowThis1475, int _argc1464, V _a1466, V _a1467, V _a1468, V _a1469, V[] _rest1465) => {
V x_1472 = default;
V y_1474 = default;
{ V _t1470 = ListOf(_a1466);
{ V _t1471 = GetIdx(_t1470, 0D);
x_1472 = _t1471; }
{ V _t1473 = GetIdx(_t1470, 1D);
y_1474 = _t1473; }
}
return (s_1445 = Add(s_1445, Call(cyl3_34, V.Undef, C_1438, Arr(x_1472, y_1474, ((V)(2.8))), Arr(x_1472, y_1474, ((V)(3.8))), ((V)(1.4)), ((V)("#d9dce0")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V)));
}, 1, "", true));
s_1445 = Add(s_1445, Call(WD_38, V.Undef, C_1438, ((V)(((-W_1420) / 2D))), ((V)(Hh_1421)), ((V)(4.2)), tubes_1444, ((V)(W_1420)), ((V)(Hh_1421))));
return NewObj(3).Put("defs", DEF12_37).Put("front", s_1445).Put("bb", Invoke(C_1438, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1422;
return default;
}, 1, "", true));
Set(N_12, "bron12", Fn((V _arrowThis1483, int _argc1476, V S_1482, V _a1479, V _a1480, V _a1481, V[] _rest1477) => {
V BZ_1484 = default;
V SX_1485 = default;
double Y0_1486 = 0;
double Y1_1487 = 0;
double ZC_1488 = 0;
double RR_1489 = 0;
V D_1490 = default;
BZ_1484 = ((V)("#8e6334"));
SX_1485 = Arr(((V)((-27D))), ((V)(27D)));
Y0_1486 = 44D;
Y1_1487 = 68D;
ZC_1488 = 8D;
RR_1489 = 5.4;
D_1490 = NewObj(5).Put("w", ((V)(86D))).Put("d", ((V)(16D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(28D))).Put("build", Fn((V _arrowThis1497, int _argc1491, V _a1493, V _a1494, V _a1495, V _a1496, V[] _rest1492) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1490, "fx", Fn((V _arrowThis1505, int _argc1498, V ctx_1504, V _a1501, V _a1502, V _a1503, V[] _rest1499) => {
V C_1506 = default;
JsStrBuf s_1507 = null;
C_1506 = Call(cam_15, V.Undef, ctx_1504);
s_1507 = new JsStrBuf("<defs><linearGradient id=\"bmU\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffdca0\" stop-opacity=\"0.95\"/><stop offset=\"0.35\" stop-color=\"#ffc870\" stop-opacity=\"0.45\"/><stop offset=\"1\" stop-color=\"#ffd690\" stop-opacity=\"0\"/></linearGradient><linearGradient id=\"bmD\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffdca0\" stop-opacity=\"0.9\"/><stop offset=\"0.35\" stop-color=\"#ffc870\" stop-opacity=\"0.4\"/><stop offset=\"1\" stop-color=\"#ffd690\" stop-opacity=\"0\"/></linearGradient><radialGradient id=\"bmH\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff6de\" stop-opacity=\"0.95\"/><stop offset=\"1\" stop-color=\"#fff6de\" stop-opacity=\"0\"/></radialGradient></defs>");
Invoke(SX_1485, "forEach", Fn((V _arrowThis1515, int _argc1508, V x_1514, V _a1511, V _a1512, V _a1513, V[] _rest1509) => {
V t_1516 = default;
V b_1517 = default;
s_1507.V(Add(Call(WD_38, V.Undef, C_1506, ((V)((ToNum(x_1514) - 17D))), ((V)((Y1_1487 + 40D))), ((V)(0.05)), ((V)(string.Concat("<path d=\"M12.4 40L0 5Q17 -3 34 5L21.6 40Z\" fill=\"url(#bmU)\"/><ellipse cx=\"17\" cy=\"40\" rx=\"8\" ry=\"3.4\" fill=\"url(#bmH)\"/>", ""))), ((V)(34D)), ((V)(44D))), Call(WD_38, V.Undef, C_1506, ((V)((ToNum(x_1514) - 15D))), ((V)(Y0_1486)), ((V)(0.05)), ((V)(string.Concat("<path d=\"M12.6 0L0 32Q15 38 30 32L17.4 0Z\" fill=\"url(#bmD)\"/><ellipse cx=\"15\" cy=\"0\" rx=\"7\" ry=\"3\" fill=\"url(#bmH)\"/>", ""))), ((V)(30D)), ((V)(36D)))));
s_1507.V(Add(Call(box3_33, V.Undef, C_1506, NewObj(9).Put("c", Arr(x_1514, ((V)(49D)), ((V)(0.45)))).Put("w", ((V)(7.6))).Put("h", ((V)(14D))).Put("d", ((V)(0.9))).Put("r", ((V)(0.9))).Put("col", BZ_1484).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.4))).Put("olw", ((V)(0.25))).V), Call(cyl3_34, V.Undef, C_1506, Arr(x_1514, ((V)(56D)), ((V)(0.9))), Arr(x_1514, ((V)(56D)), ((V)(((ZC_1488 - RR_1489) + 0.4)))), ((V)(1.5)), BZ_1484, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.25))).V)));
s_1507.V(Call(cyl3_34, V.Undef, C_1506, Arr(x_1514, ((V)(Y0_1486)), ((V)(ZC_1488))), Arr(x_1514, ((V)(Y1_1487)), ((V)(ZC_1488))), ((V)(RR_1489)), BZ_1484, NewObj(4).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.35))).Put("capCol", ((V)("#fff0cc"))).Put("cap", Fn((V _arrowThis1525, int _argc1518, V cr_1524, V _a1521, V _a1522, V _a1523, V[] _rest1519) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(cr_1524) * 0.86))))), "\" fill=\"none\" stroke=\"#5a3c1c\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(cr_1524) * 0.14))))), "\"/><circle r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(cr_1524) * 0.5))))), "\" fill=\"#ffffff\" opacity=\"0.75\"/>")));
}, 1, "cap", true)).V));
Invoke(Arr(((V)((Y0_1486 + 2.4))), ((V)((Y1_1487 - 3.2)))), "forEach", Fn((V _arrowThis1533, int _argc1526, V y_1532, V _a1529, V _a1530, V _a1531, V[] _rest1527) => {
return ((V)(s_1507.V(Call(cyl3_34, V.Undef, C_1506, Arr(x_1514, y_1532, ((V)(ZC_1488))), Arr(x_1514, Add(y_1532, ((V)(0.8))), ((V)(ZC_1488))), ((V)((RR_1489 + 0.25))), Call(shade_11, V.Undef, BZ_1484, ((V)(0.72))), NewObj(3).Put("mat", ((V)("metal"))).Put("noCap", ((V)(1D))).Put("olw", ((V)(0.2))).V)).Str));
}, 1, "", true));
t_1516 = Invoke(C_1506, "p", x_1514, ((V)(Y1_1487)), ((V)(ZC_1488)));
b_1517 = Invoke(C_1506, "p", x_1514, ((V)(Y0_1486)), ((V)(ZC_1488)));
s_1507.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_25, V.Undef, GetIdx(t_1516, 0D))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, GetIdx(t_1516, 1D))), "\" rx=\"", ToStr(Call(f1_25, V.Undef, ((V)(((RR_1489 * ToNum(Get(C_1506, "k"))) * 1.6))))), "\" ry=\"", ToStr(Call(f1_25, V.Undef, ((V)(((RR_1489 * ToNum(Get(C_1506, "k"))) * 0.7))))), "\" fill=\"url(#bmH)\" opacity=\"0.55\"/><ellipse cx=\"", ToStr(Call(f1_25, V.Undef, GetIdx(b_1517, 0D))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, Add(GetIdx(b_1517, 1D), ((V)((ToNum(Get(C_1506, "k")) * 0.6)))))), "\" rx=\"", ToStr(Call(f1_25, V.Undef, ((V)(((RR_1489 * ToNum(Get(C_1506, "k"))) * 1.1))))), "\" ry=\"", ToStr(Call(f1_25, V.Undef, ((V)(((RR_1489 * ToNum(Get(C_1506, "k"))) * 0.45))))), "\" fill=\"url(#bmH)\" opacity=\"0.45\"/>"));
return default;
}, 1, "", true));
return NewObj(3).Put("defs", DEF12_37).Put("front", ((V)(s_1507.Str))).Put("bb", Invoke(C_1506, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1490;
return default;
}, 1, "", true));
Set(N_12, "rgbw12", Fn((V _arrowThis1541, int _argc1534, V S_1540, V _a1537, V _a1538, V _a1539, V[] _rest1535) => {
V BX_1542 = default;
double Y0_1543 = 0;
double BH_1544 = 0;
V D_1545 = default;
V STO_1546 = default;
V G_1547 = default;
BX_1542 = Arr(((V)((-42D))), ((V)(42D)));
Y0_1543 = 6D;
BH_1544 = 88D;
D_1545 = NewObj(5).Put("w", ((V)(110D))).Put("d", ((V)(10D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(26D))).Put("build", Fn((V _arrowThis1554, int _argc1548, V _a1550, V _a1551, V _a1552, V _a1553, V[] _rest1549) => {
return Arr();
}, 0, "build", true)).V;
STO_1546 = ((V)("<stop offset=\"0\" stop-color=\"#ff3b7a\"/><stop offset=\"0.2\" stop-color=\"#ffb13b\"/><stop offset=\"0.38\" stop-color=\"#f4ffef\"/><stop offset=\"0.55\" stop-color=\"#3bffb0\"/><stop offset=\"0.75\" stop-color=\"#3bb4ff\"/><stop offset=\"0.9\" stop-color=\"#a64bff\"/><stop offset=\"1\" stop-color=\"#ff3b7a\"/>"));
G_1547 = Fn((V _arrowThis1565, int _argc1555, V id_1561, V L_1562, V rev_1563, V dur_1564, V[] _rest1556) => {
return ((V)(string.Concat("<linearGradient id=\"", ToStr(id_1561), "\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"", ToStr(L_1562), "\" spreadMethod=\"repeat\">", ToStr(STO_1546), "<animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"", (Truthy(rev_1563) ? string.Concat("0 ", ToStr(L_1562), ";0 0") : string.Concat("0 0;0 ", ToStr(L_1562))), "\" dur=\"", ToStr(dur_1564), "s\" repeatCount=\"indefinite\"/></linearGradient>")));
}, 4, "", true);
Set(D_1545, "fx", Fn((V _arrowThis1573, int _argc1566, V ctx_1572, V _a1569, V _a1570, V _a1571, V[] _rest1567) => {
V C_1574 = default;
JsStrBuf s_1575 = null;
JsStrBuf defs_1576 = null;
V hub_1577 = default;
C_1574 = Call(cam_15, V.Undef, ctx_1572);
s_1575 = new JsStrBuf("");
defs_1576 = new JsStrBuf("");
Invoke(BX_1542, "forEach", Fn((V _arrowThis1586, int _argc1578, V x_1584, V i_1585, V _a1582, V _a1583, V[] _rest1579) => {
V dec_1587 = default;
defs_1576.V(Add(Call(G_1547, V.Undef, ((V)(JsStrBuf.Begin().S("rg").V(i_1585).End())), ((V)(44D)), i_1585, ((V)(6D))), Call(G_1547, V.Undef, ((V)(JsStrBuf.Begin().S("rw").V(i_1585).End())), ((V)(44D)), i_1585, ((V)(6D)))));
s_1575.V(Call(WD_38, V.Undef, C_1574, ((V)((ToNum(x_1584) - 16D))), ((V)(((Y0_1543 + BH_1544) + 8D))), ((V)(0.05)), ((V)(string.Concat("<g opacity=\"0.55\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.38;0.62;0.42;0.7;0.38")), ((V)(1.7)))), "<rect width=\"32\" height=\"", NumStr((BH_1544 + 16D)), "\" rx=\"16\" fill=\"url(#rw", ToStr(i_1585), ")\" filter=\"url(#m11b8)\"/></g>"))), ((V)(32D)), ((V)((BH_1544 + 16D)))));
s_1575.V(Call(wsh_39, V.Undef, C_1574, ((V)((ToNum(x_1584) - 2.3))), ((V)((Y0_1543 + BH_1544))), ((V)(4.6)), ((V)(BH_1544)), NewObj(4).Put("dx", ((V)(0.8))).Put("dy", ((V)(1.4))).Put("op", ((V)(0.35))).Put("f", ((V)("m12b2"))).V));
dec_1587 = ((V)(string.Concat("<rect x=\"0.8\" y=\"1.2\" width=\"3\" height=\"", NumStr((BH_1544 - 2.4)), "\" rx=\"1.3\" fill=\"url(#rg", ToStr(i_1585), ")\"/><rect x=\"0.8\" y=\"1.2\" width=\"3\" height=\"", NumStr((BH_1544 - 2.4)), "\" rx=\"1.3\" fill=\"#ffffff\" opacity=\"0.26\"/><rect x=\"2\" y=\"1.6\" width=\"0.6\" height=\"", NumStr((BH_1544 - 3.2)), "\" rx=\"0.3\" fill=\"#ffffff\" opacity=\"0.6\"/>")));
s_1575.V(Call(box3_33, V.Undef, C_1574, NewObj(8).Put("c", Arr(x_1584, ((V)((Y0_1543 - 1.2))), ((V)(1.8)))).Put("w", ((V)(5D))).Put("h", ((V)(1.2))).Put("d", ((V)(3.6))).Put("r", ((V)(1D))).Put("col", ((V)("#2a2c30"))).Put("gl", ((V)(0.4))).Put("olw", ((V)(0.25))).V));
s_1575.V(Call(box3_33, V.Undef, C_1574, NewObj(11).Put("c", Arr(x_1584, ((V)(Y0_1543)), ((V)(1.7)))).Put("w", ((V)(4.6))).Put("h", ((V)(BH_1544))).Put("d", ((V)(3.4))).Put("r", ((V)(1D))).Put("col", ((V)("#b9bec4"))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.7))).Put("dec", NewObj(1).Put("f", dec_1587).V).Put("olw", ((V)(0.3))).Put("edge", ((V)(0.4))).V));
s_1575.V(Call(box3_33, V.Undef, C_1574, NewObj(8).Put("c", Arr(x_1584, ((V)((Y0_1543 + BH_1544))), ((V)(1.8)))).Put("w", ((V)(5D))).Put("h", ((V)(1.2))).Put("d", ((V)(3.6))).Put("r", ((V)(1D))).Put("col", ((V)("#2a2c30"))).Put("gl", ((V)(0.4))).Put("olw", ((V)(0.25))).V));
return default;
}, 2, "", true));
hub_1577 = Add(Invoke(Call(rep_27, V.Undef, ((V)(5D)), Fn((V _arrowThis1595, int _argc1588, V i_1594, V _a1591, V _a1592, V _a1593, V[] _rest1589) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)((3.2 + (ToNum(i_1594) * 2.4)))))), "\" cy=\"2.6\" r=\"0.6\" fill=\"", ToStr(GetK(Arr(((V)("#ff3b7a")), ((V)("#ffb13b")), ((V)("#3bffb0")), ((V)("#3bb4ff")), ((V)("#a64bff"))), i_1594)), "\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.25;1;0.25")), ((V)(0.85)), ((V)(((-ToNum(i_1594)) * 0.17))))), "</circle>")));
}, 1, "", true)), "join", ((V)(""))), Call(T_41, V.Undef, ((V)(8D)), ((V)(5.6)), ((V)(1.5)), ((V)("#7d838b")), ((V)("SYNC")), ((V)("letter-spacing=\"0.4\""))));
s_1575.V(Call(box3_33, V.Undef, C_1574, NewObj(9).Put("c", Arr(((V)(0D)), ((V)(42D)), ((V)(0.8)))).Put("w", ((V)(16D))).Put("h", ((V)(7D))).Put("d", ((V)(1.6))).Put("r", ((V)(1.4))).Put("col", ((V)("#1d1f24"))).Put("gl", ((V)(0.6))).Put("dec", NewObj(1).Put("f", hub_1577).V).Put("olw", ((V)(0.3))).V));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(DEF12_37).S(defs_1576.Str).End()))).Put("front", ((V)(s_1575.Str))).Put("bb", Invoke(C_1574, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1545;
return default;
}, 1, "", true));
Set(N_12, "reel12", Fn((V _arrowThis1603, int _argc1596, V S_1602, V _a1599, V _a1600, V _a1601, V[] _rest1597) => {
V RL_1604 = default;
V D_1605 = default;
V reel_1606 = default;
RL_1604 = Arr(NewObj(4).Put("c", Arr(((V)((-30D))), ((V)(62D)), ((V)(13D)))).Put("r", ((V)(17D))).Put("yaw", ((V)(0.42))).Put("T", ((V)(5D))).V, NewObj(4).Put("c", Arr(((V)(31D)), ((V)(72D)), ((V)(10D)))).Put("r", ((V)(12.5))).Put("yaw", ((V)((-0.38)))).Put("T", ((V)(3.6))).V);
D_1605 = NewObj(5).Put("w", ((V)(124D))).Put("d", ((V)(30D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(36D))).Put("build", Fn((V _arrowThis1613, int _argc1607, V _a1609, V _a1610, V _a1611, V _a1612, V[] _rest1608) => {
return Arr();
}, 0, "build", true)).V;
reel_1606 = Fn((V _arrowThis1621, int _argc1614, V r_1620, V _a1617, V _a1618, V _a1619, V[] _rest1615) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<circle r=\"", ToStr(Call(f1_25, V.Undef, r_1620)), "\" fill=\"#5ff0ff\" fill-opacity=\"0.1\" stroke=\"#9ff8ff\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(r_1620) * 0.05))))), "\"/><circle r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(r_1620) * 0.8))))), "\" fill=\"#0b4a5a\" fill-opacity=\"0.35\" stroke=\"#5ff0ff\" stroke-opacity=\"0.6\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(r_1620) * 0.02))))), "\"/>")).V(Invoke(Invoke(Arr(((V)(0.62)), ((V)(0.7)), ((V)(0.76))), "map", Fn((V _arrowThis1629, int _argc1622, V k_1628, V _a1625, V _a1626, V _a1627, V[] _rest1623) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(r_1620) * ToNum(k_1628)))))), "\" fill=\"none\" stroke=\"#8ff6ff\" stroke-opacity=\"0.2\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(r_1620) * 0.012))))), "\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Call(rep_27, V.Undef, ((V)(5D)), Fn((V _arrowThis1637, int _argc1630, V i_1636, V _a1633, V _a1634, V _a1635, V[] _rest1631) => {
double a_1638 = 0;
a_1638 = (((ToNum(i_1636) * 72D) * PI_13) / 180D);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_25, V.Undef, ((V)(((ToNum(r_1620) * 0.5) * FdLibm.Cos(a_1638)))))), "\" cy=\"", ToStr(Call(f1_25, V.Undef, ((V)(((ToNum(r_1620) * 0.5) * FdLibm.Sin(a_1638)))))), "\" r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(r_1620) * 0.18))))), "\" fill=\"#02141a\" fill-opacity=\"0.55\" stroke=\"#c8fbff\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(r_1620) * 0.03))))), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<circle r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(r_1620) * 0.16))))), "\" fill=\"#c8fbff\" fill-opacity=\"0.5\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(r_1620) * 0.03))))), "\"/><circle r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(r_1620) * 0.06))))), "\" fill=\"#ffffff\"/>")).End()));
}, 1, "", true);
Set(D_1605, "fx", Fn((V _arrowThis1646, int _argc1639, V ctx_1645, V _a1642, V _a1643, V _a1644, V[] _rest1640) => {
V C_1647 = default;
JsStrBuf s_1648 = null;
V lens_1649 = default;
V U_1650 = default;
V R1_1651 = default;
V R2_1652 = default;
V u1_1653 = default;
V u2_1654 = default;
V A_1655 = default;
V B_1656 = default;
V k_1657 = default;
V fd_1658 = default;
C_1647 = Call(cam_15, V.Undef, ctx_1645);
s_1648 = new JsStrBuf("");
s_1648.V(Call(WD_38, V.Undef, C_1647, ((V)((-64D))), ((V)(96D)), ((V)(0.05)), ((V)(string.Concat("<rect width=\"128\" height=\"70\" rx=\"30\" fill=\"#3fd0ff\" opacity=\"0.18\" filter=\"url(#m11b8)\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.12;0.24;0.15;0.22;0.12")), ((V)(3.4)))), "</rect>")))));
s_1648.V(Call(wsh_39, V.Undef, C_1647, ((V)((-56D))), ((V)(35D)), ((V)(112D)), ((V)(5D)), NewObj(4).Put("dx", ((V)(1D))).Put("dy", ((V)(1.6))).Put("op", ((V)(0.45))).Put("f", ((V)("m12b2"))).V));
lens_1649 = Invoke(Invoke(RL_1604, "map", Fn((V _arrowThis1666, int _argc1659, V R_1665, V _a1662, V _a1663, V _a1664, V[] _rest1660) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_25, V.Undef, Add(GetIdx(Get(R_1665, "c"), 0D), ((V)(56D))))), "\" cy=\"2.2\" rx=\"2.4\" ry=\"1.5\" fill=\"#dffcff\"/><ellipse cx=\"", ToStr(Call(f1_25, V.Undef, Add(GetIdx(Get(R_1665, "c"), 0D), ((V)(56D))))), "\" cy=\"2.2\" rx=\"1.2\" ry=\"0.7\" fill=\"#ffffff\"/>")));
}, 1, "", true)), "join", ((V)("")));
s_1648.V(Call(box3_33, V.Undef, C_1647, NewObj(11).Put("c", Arr(((V)(0D)), ((V)(30D)), ((V)(2.2)))).Put("w", ((V)(112D))).Put("h", ((V)(5D))).Put("d", ((V)(4.4))).Put("r", ((V)(1.6))).Put("col", ((V)("#1e2129"))).Put("gl", ((V)(0.6))).Put("dec", NewObj(2).Put("f", ((V)(string.Concat("<rect x=\"5\" y=\"2\" width=\"102\" height=\"1\" rx=\"0.5\" fill=\"#8ff6ff\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.6")), ((V)(2.2)))), "</rect>")))).Put("t", lens_1649).V).Put("olc", ((V)("#050608"))).Put("olw", ((V)(0.35))).Put("edge", ((V)(0.3))).V));
U_1650 = Fn((V _arrowThis1674, int _argc1667, V R_1673, V _a1670, V _a1671, V _a1672, V[] _rest1668) => {
return Arr(((V)(FdLibm.Cos(ToNum(Get(R_1673, "yaw"))))), ((V)(0D)), ((V)((-FdLibm.Sin(ToNum(Get(R_1673, "yaw")))))));
}, 1, "", true);
Invoke(RL_1604, "forEach", Fn((V _arrowThis1682, int _argc1675, V R_1681, V _a1678, V _a1679, V _a1680, V[] _rest1676) => {
V u_1683 = default;
V e0_1684 = default;
V e1_1685 = default;
V a_1686 = default;
V b_1687 = default;
V id_1688 = default;
V m_1689 = default;
V c_1690 = default;
u_1683 = Call(U_1650, V.Undef, R_1681);
e0_1684 = Invoke(C_1647, "p", ((V)((ToNum(GetIdx(Get(R_1681, "c"), 0D)) - 2.4))), ((V)(35D)), ((V)(2.2)));
e1_1685 = Invoke(C_1647, "p", Add(GetIdx(Get(R_1681, "c"), 0D), ((V)(2.4))), ((V)(35D)), ((V)(2.2)));
a_1686 = Invoke(C_1647, "P", Call(add_19, V.Undef, Get(R_1681, "c"), Call(add_19, V.Undef, Call(mul_20, V.Undef, u_1683, ((V)(((-ToNum(Get(R_1681, "r"))) * 0.85)))), Arr(((V)(0D)), ((V)(((-ToNum(Get(R_1681, "r"))) * 0.5))), ((V)(0D))))));
b_1687 = Invoke(C_1647, "P", Call(add_19, V.Undef, Get(R_1681, "c"), Call(add_19, V.Undef, Call(mul_20, V.Undef, u_1683, ((V)((ToNum(Get(R_1681, "r")) * 0.85)))), Arr(((V)(0D)), ((V)(((-ToNum(Get(R_1681, "r"))) * 0.5))), ((V)(0D))))));
id_1688 = Invoke(C_1647, "u", ((V)("bm")));
s_1648.S(string.Concat("<defs><linearGradient id=\"", ToStr(id_1688), "\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"", ToStr(Call(f1_25, V.Undef, GetIdx(e0_1684, 1D))), "\" x2=\"0\" y2=\"", ToStr(Call(f1_25, V.Undef, GetIdx(a_1686, 1D))), "\"><stop offset=\"0\" stop-color=\"#8ff6ff\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#8ff6ff\" stop-opacity=\"0.03\"/></linearGradient></defs><path d=\"M", ToStr(Call(P2_28, V.Undef, e0_1684)), "L", ToStr(Call(P2_28, V.Undef, a_1686)), "L", ToStr(Call(P2_28, V.Undef, b_1687)), "L", ToStr(Call(P2_28, V.Undef, e1_1685)), "Z\" fill=\"url(#", ToStr(id_1688), ")\">", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.7;1;0.6;0.95;0.7")), ((V)(2.6)))), "</path>"));
m_1689 = Invoke(C_1647, "p", GetIdx(Get(R_1681, "c"), 0D), ((V)(35D)), ((V)(2.2)));
c_1690 = Invoke(C_1647, "P", Get(R_1681, "c"));
s_1648.V(Invoke(Call(rep_27, V.Undef, ((V)(5D)), Fn((V _arrowThis1698, int _argc1691, V i_1697, V _a1694, V _a1695, V _a1696, V[] _rest1692) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(Get(C_1647, "k")) * 0.45))))), "\" fill=\"#dffcff\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0.9;0\" dur=\"1.8s\" begin=\"", ToStr(Call(n4_26, V.Undef, ((V)(((-ToNum(i_1697)) * 0.36))))), "s\" repeatCount=\"indefinite\"/><animateMotion dur=\"1.8s\" begin=\"", ToStr(Call(n4_26, V.Undef, ((V)(((-ToNum(i_1697)) * 0.36))))), "s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(f1_25, V.Undef, Add(GetIdx(m_1689, 0D), ((V)((((ToNum(i_1697) - 2D) * ToNum(Get(C_1647, "k"))) * 1.4)))))), " ", ToStr(Call(f1_25, V.Undef, GetIdx(m_1689, 1D))), "L", ToStr(Call(f1_25, V.Undef, Add(GetIdx(c_1690, 0D), ((V)((((ToNum(i_1697) - 2D) * ToNum(Get(C_1647, "k"))) * 3D)))))), " ", ToStr(Call(f1_25, V.Undef, Add(GetIdx(c_1690, 1D), ((V)(((ToNum(Get(R_1681, "r")) * ToNum(Get(C_1647, "k"))) * 0.4)))))), "\"/></circle>")));
}, 1, "", true)), "join", ((V)(""))));
return default;
}, 1, "", true));
{ V _t1699 = RL_1604;
{ V _t1700 = ListOf(_t1699);
{ V _t1701 = GetIdx(_t1700, 0D);
R1_1651 = _t1701; }
{ V _t1702 = GetIdx(_t1700, 1D);
R2_1652 = _t1702; }
} }
u1_1653 = Call(U_1650, V.Undef, R1_1651);
u2_1654 = Call(U_1650, V.Undef, R2_1652);
A_1655 = Invoke(C_1647, "P", Call(add_19, V.Undef, Get(R1_1651, "c"), Call(add_19, V.Undef, Call(mul_20, V.Undef, u1_1653, ((V)((ToNum(Get(R1_1651, "r")) * 0.7)))), Arr(((V)(0D)), ((V)(((-ToNum(Get(R1_1651, "r"))) * 0.7))), ((V)(0D))))));
B_1656 = Invoke(C_1647, "P", Call(add_19, V.Undef, Get(R2_1652, "c"), Call(add_19, V.Undef, Call(mul_20, V.Undef, u2_1654, ((V)(((-ToNum(Get(R2_1652, "r"))) * 0.7)))), Arr(((V)(0D)), ((V)(((-ToNum(Get(R2_1652, "r"))) * 0.7))), ((V)(0D))))));
k_1657 = Get(C_1647, "k");
fd_1658 = ((V)(string.Concat("M", ToStr(Call(P2_28, V.Undef, A_1655)), "C", ToStr(Call(f1_25, V.Undef, Add(GetIdx(A_1655, 0D), ((V)((12D * ToNum(k_1657))))))), " ", ToStr(Call(f1_25, V.Undef, Add(GetIdx(A_1655, 1D), ((V)((10D * ToNum(k_1657))))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((ToNum(GetIdx(B_1656, 0D)) - (10D * ToNum(k_1657))))))), " ", ToStr(Call(f1_25, V.Undef, Add(GetIdx(B_1656, 1D), ((V)((12D * ToNum(k_1657))))))), " ", ToStr(Call(P2_28, V.Undef, B_1656)))));
s_1648.S(string.Concat("<path d=\"", ToStr(fd_1658), "\" fill=\"none\" stroke=\"#5ff0ff\" stroke-opacity=\"0.24\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((3.4 * ToNum(k_1657)))))), "\"/><path d=\"", ToStr(fd_1658), "\" fill=\"none\" stroke=\"#dffcff\" stroke-opacity=\"0.5\" stroke-width=\"", ToStr(Call(f1_25, V.Undef, ((V)((2.4 * ToNum(k_1657)))))), "\" stroke-dasharray=\"", ToStr(Call(f1_25, V.Undef, ((V)((0.45 * ToNum(k_1657)))))), " ", ToStr(Call(f1_25, V.Undef, ((V)((1.2 * ToNum(k_1657)))))), "\">", ToStr(Call(an_22, V.Undef, ((V)("stroke-dashoffset")), ((V)(string.Concat("0;", ToStr(Call(f1_25, V.Undef, ((V)(((-1.65) * ToNum(k_1657))))))))), ((V)(0.5)))), "</path>"));
Invoke(RL_1604, "forEach", Fn((V _arrowThis1710, int _argc1703, V R_1709, V _a1706, V _a1707, V _a1708, V[] _rest1704) => {
V sp_1711 = default;
Call(ext_32, V.Undef, C_1647, Arr(Call(add_19, V.Undef, Get(R_1709, "c"), Arr(((V)((-ToNum(Get(R_1709, "r"))))), ((V)((-ToNum(Get(R_1709, "r"))))), ((V)(0D)))), Call(add_19, V.Undef, Get(R_1709, "c"), Arr(Get(R_1709, "r"), Get(R_1709, "r"), ((V)(0D))))));
sp_1711 = ((V)(string.Concat("<g>", ToStr(Call(at_23, V.Undef, ((V)("rotate")), ((V)("0;360")), Get(R_1709, "T"))), ToStr(Call(reel_1606, V.Undef, Get(R_1709, "r"))), "</g>")));
s_1648.S(string.Concat("<g transform=\"", ToStr(Call(FR_16, V.Undef, C_1647, Get(R_1709, "c"), Call(U_1650, V.Undef, R_1709), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><g opacity=\"0.55\" filter=\"url(#m11b4)\">", ToStr(sp_1711), "</g><g>", ToStr(Call(an_22, V.Undef, ((V)("opacity")), ((V)("0.85;1;0.9;1;0.85")), ((V)(2.3)))), ToStr(sp_1711), "</g></g>"));
return default;
}, 1, "", true));
return NewObj(3).Put("defs", DEF12_37).Put("front", ((V)(s_1648.Str))).Put("bb", Invoke(C_1647, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1605;
return default;
}, 1, "", true));
Set(RD_8, "SET12", NewObj(14).Put("MOV-001", NewObj(2).Put("s12", ((V)("dry"))).Put("note", ((V)("Old grey drywall with a taped seam, mudded screw heads, a brown water stain and a patch where the paint is peeling off. Two charcoal egg-crate foam panels are glued on as DIY soundproofing (one a little crooked)."))).V).Put("MOV-021", NewObj(2).Put("s12", ((V)("char"))).Put("note", ((V)("Walls rolled in a deep matte charcoal that swallows stray light. You can see the fine roller stipple and soft lap marks up close."))).V).Put("MOV-061", NewObj(3).Put("s12", ((V)("slat"))).Put("live", ((V)("Glowing slats"))).Put("note", ((V)("Vertical walnut slats with real grain over black acoustic felt. Amber LED strips behind them glow through the gaps and slowly breathe brighter and dimmer."))).V).Put("MOV-081", NewObj(4).Put("s3", V.Null).Put("s12", ((V)("star"))).Put("live", ((V)("Twinkling stars"))).Put("note", ((V)("Padded obsidian fabric panels with hundreds of fibre-optic stars in warm and cool white. They twinkle at their own pace, and now and then a shooting star streaks past."))).V).Put("MOV-004", NewObj(3).Put("spec", ((V)("torn12"))).Put("live", ((V)("Corner flutters"))).Put("note", ((V)("A sun-faded \"Space Squish\" B-movie poster with fold creases, wrinkles and a torn-off bottom corner, held up with yellowed scotch tape. The top corner has come loose, folded over, and flutters in the draft."))).V).Put("MOV-024", NewObj(2).Put("spec", ((V)("trio12"))).Put("note", ((V)("Three retro sci-fi posters (Rocket Rangers, Saucer Summer, Robo Pal) in satin black frames with cream bevel-cut mats and glass that catches the light. They are printed in faded halftone inks."))).V).Put("MOV-044", NewObj(3).Put("spec", ((V)("lbox12"))).Put("live", ((V)("Chasing bulbs"))).Put("note", ((V)("A black marquee lightbox with a NOW PLAYING header and a backlit \"Moonlit Matinee\" poster behind acrylic. A ring of warm bulbs chases around the frame."))).V).Put("MOV-064", NewObj(2).Put("spec", ((V)("sbox12"))).Put("note", ((V)("A deep walnut shadowbox lined with green velvet: a replica silk top hat and gold-topped cane, a signed black-and-white star photo and an engraved brass plaque, under glass and a brass picture light."))).V).Put("MOV-084", NewObj(3).Put("spec", ((V)("holo12"))).Put("live", ((V)("Animated posters"))).Put("note", ((V)("Three slim glowing frames with living posters: a rocket blasting through streaking stars, ink waves rolling under a pulsing moon, and a bouncy Squish blob that blinks. Holo shimmer sweeps across the glass."))).V).Put("MOV-018", NewObj(3).Put("spec", ((V)("lant12"))).Put("live", ((V)("Swaying lanterns"))).Put("note", ((V)("A drooping cord of seven ribbed paper lanterns in soft pastel colours, hung from two wall hooks. Each one glows from inside, flickers a little and sways on its own."))).V).Put("MOV-038", NewObj(3).Put("spec", ((V)("neon12"))).Put("live", ((V)("Flickering neon"))).Put("note", ((V)("Glass neon tubes on a black backer with chrome standoffs: pink NOW over cyan SHOWING inside an amber border, with chasing arrows. The NOW tube flickers now and then, and the whole sign glows on the wall."))).V).Put("MOV-058", NewObj(2).Put("spec", ((V)("bron12"))).Put("note", ((V)("A pair of brushed-bronze cylinder sconces on wall plates. Each one throws a warm fan of light up the wall and another one down."))).V).Put("MOV-078", NewObj(3).Put("spec", ((V)("rgbw12"))).Put("live", ((V)("Colour waves"))).Put("note", ((V)("Two aluminium light bars with frosted diffusers. Rainbow colour waves run up and down them and wash the wall, pulsing to the beat, with a small SYNC hub between them."))).V).Put("MOV-098", NewObj(3).Put("spec", ((V)("reel12"))).Put("live", ((V)("Spinning reels"))).Put("note", ((V)("Two see-through holographic film reels float above a wall emitter bar and spin. A strip of film runs between them, light beams rise from the emitter, and the reels flicker like a hologram."))).V).V);
edit11_72 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis1719, int _argc1712, V rows_1718, V _a1715, V _a1716, V _a1717, V[] _rest1713) => {
return Invoke(Call(edit11_72, V.Undef, rows_1718), "map", Fn((V _arrowThis1727, int _argc1720, V r_1726, V _a1723, V _a1724, V _a1725, V[] _rest1721) => {
return (Truthy(GetK(Get(RD_8, "SET12"), Get(r_1726, "id"))) ? Object_assign(NewObj(0).V, r_1726, GetK(Get(RD_8, "SET12"), Get(r_1726, "id"))) : r_1726);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H12", NewObj(16).Put("DEF12", DEF12_37).Put("WD", WD_38).Put("wsh", wsh_39).Put("innerW", innerW_40).Put("paperFx", paperFx_42).Put("NZ", NZ_45).Put("NR", NR_46).Put("BL", BL_47).Put("tube", tube_71).Put("word", word_70).Put("tile", tile_52).Put("room", room_51).Put("blot", blot_49).Put("outlet", outlet_53).Put("BB", ((V)(BB_50))).Put("SURF12", SURF12_58).V);
Set(RD_8, "PLUS12", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
