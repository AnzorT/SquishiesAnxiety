// reno-plus18.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus18_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("noise", "");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("ch(\\d)", "");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("out", "");
        public static void Run()
        {
Call(Named(boot_68 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V shade_11 = default;
V slab_12 = default;
V N_13 = default;
V H_14 = default;
double PI_15 = 0;
V cam_16 = default;
V FR_17 = default;
V an_18 = default;
V at_19 = default;
V SPL_20 = default;
V f1_21 = default;
V n4_22 = default;
V rep_23 = default;
V P2_24 = default;
V FONT_25 = default;
V shadow_26 = default;
V isPlay_27 = default;
V yawA_28 = default;
V sph_29 = default;
V ext_30 = default;
V zsort_31 = default;
V WD_32 = default;
V DEF15_33 = default;
V cone_34 = default;
V curve_35 = default;
V box3_36 = default;
V cyl3_37 = default;
V NZ_38 = default;
V DEF18__39 = default;
V DEF18_40 = default;
V ONCE_41 = default;
V note_42 = default;
V toon_43 = default;
V noise_44 = default;
V tvState_45 = default;
V tvPic_46 = default;
V glass_47 = default;
V scr_48 = default;
V knob_49 = default;
V led_50 = default;
double UID_51 = 0;
V artPic_52 = default;
V mascot_53 = default;
V notes_54 = default;
V waves_55 = default;
V robot_56 = default;
V draw0_57 = default;
V TV_58 = default;
V ADD18_59 = default;
V edit17_60 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((((((RD_8 is var _t61 && !Truthy(_t61) ? _t61 : Get(RD_8, "PLUS17")) is var _t62 && !Truthy(_t62) ? _t62 : Get(RD_8, "H15")) is var _t63 && !Truthy(_t63) ? _t63 : Get(RD_8, "H12")) is var _t64 && !Truthy(_t64) ? _t64 : Get(RD_8, "H11")) is var _t65 && !Truthy(_t65) ? _t65 : Get(RD_8, "H10")) is var _t66 && !Truthy(_t66) ? _t66 : X_9) is var _t67 && !Truthy(_t67) ? _t67 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_68.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS18"))) {
return default;
}
K_10 = Get(X_9, "K");
shade_11 = Get(K_10, "shade");
slab_12 = Get(K_10, "slab");
N_13 = Get(RD_8, "N");
H_14 = Get(RD_8, "H10");
PI_15 = System.Math.PI;
{ V _t69 = H_14;
if (_t69.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t69));
{ V _t70 = Get(_t69, "cam");
cam_16 = _t70; }
{ V _t71 = Get(_t69, "FR");
FR_17 = _t71; }
{ V _t72 = Get(_t69, "an");
an_18 = _t72; }
{ V _t73 = Get(_t69, "at");
at_19 = _t73; }
{ V _t74 = Get(_t69, "SPL");
SPL_20 = _t74; }
{ V _t75 = Get(_t69, "f1");
f1_21 = _t75; }
{ V _t76 = Get(_t69, "n4");
n4_22 = _t76; }
{ V _t77 = Get(_t69, "rep");
rep_23 = _t77; }
{ V _t78 = Get(_t69, "P2");
P2_24 = _t78; }
{ V _t79 = Get(_t69, "FONT");
FONT_25 = _t79; }
{ V _t80 = Get(_t69, "shadow");
shadow_26 = _t80; }
{ V _t81 = Get(_t69, "isPlay");
isPlay_27 = _t81; }
{ V _t82 = Get(_t69, "yawA");
yawA_28 = _t82; }
{ V _t83 = Get(_t69, "sph");
sph_29 = _t83; } }
{ V _t84 = Get(RD_8, "H11");
if (_t84.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t84));
{ V _t85 = Get(_t84, "ext");
ext_30 = _t85; }
{ V _t86 = Get(_t84, "zsort");
zsort_31 = _t86; } }
{ V _t87 = Get(RD_8, "H12");
if (_t87.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t87));
{ V _t88 = Get(_t87, "WD");
WD_32 = _t88; } }
{ V _t89 = Get(RD_8, "H15");
if (_t89.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t89));
{ V _t90 = Get(_t89, "DEF15");
DEF15_33 = _t90; }
{ V _t91 = Get(_t89, "cone");
cone_34 = _t91; }
{ V _t92 = Get(_t89, "curve");
curve_35 = _t92; }
{ V _t93 = Get(_t89, "box3");
box3_36 = _t93; }
{ V _t94 = Get(_t89, "cyl3");
cyl3_37 = _t94; } }
NZ_38 = ((V)(""));
DEF18__39 = Fn((V _arrowThis101, int _argc95, V _a97, V _a98, V _a99, V _a100, V[] _rest96) => {
return ((V)(JsStrBuf.Begin().V(DEF15_33).S("<linearGradient id=\"q18gl\" x1=\"0\" y1=\"0\" x2=\"0.5\" y2=\"1\"><stop offset=\"0\" stop-color=\"#3a4150\"/><stop offset=\"0.55\" stop-color=\"#14171f\"/><stop offset=\"1\" stop-color=\"#07080c\"/></linearGradient>").S("<radialGradient id=\"q18crt\" cx=\"42%\" cy=\"38%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#5d6f68\"/><stop offset=\"0.6\" stop-color=\"#2c3733\"/><stop offset=\"1\" stop-color=\"#121815\"/></radialGradient>").S("<radialGradient id=\"q18vg\" cx=\"50%\" cy=\"50%\" r=\"70%\"><stop offset=\"0.55\" stop-color=\"#000000\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.55\"/></radialGradient>").S("<linearGradient id=\"q18sky\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#78cdfc\"/><stop offset=\"1\" stop-color=\"#e6f8ff\"/></linearGradient>").S("<linearGradient id=\"q18rf\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.45\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.16\"/><stop offset=\"0.62\" stop-color=\"#ffffff\" stop-opacity=\"0.05\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>").S("<radialGradient id=\"q18glw\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#ffb347\" stop-opacity=\"0.95\"/><stop offset=\"0.5\" stop-color=\"#ff7a1a\" stop-opacity=\"0.45\"/><stop offset=\"1\" stop-color=\"#ff7a1a\" stop-opacity=\"0\"/></radialGradient>").S("<radialGradient id=\"q18cy\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#8ff6ff\" stop-opacity=\"0.9\"/><stop offset=\"0.5\" stop-color=\"#3fd0ff\" stop-opacity=\"0.35\"/><stop offset=\"1\" stop-color=\"#3fd0ff\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"q18bm\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8ff6ff\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#8ff6ff\" stop-opacity=\"0.04\"/></linearGradient>").S("<pattern id=\"q18cl\" width=\"1.6\" height=\"1.6\" patternUnits=\"userSpaceOnUse\"><rect width=\"1.6\" height=\"1.6\" fill=\"#d9772e\"/><path d=\"M0 0.4H1.6M0 1.2H1.6\" stroke=\"#a9521a\" stroke-width=\"0.35\"/><path d=\"M0.4 0V1.6M1.2 0V1.6\" stroke=\"#f0a050\" stroke-width=\"0.25\" stroke-opacity=\"0.7\"/></pattern>").S("<pattern id=\"q18gr\" width=\"1.4\" height=\"1.4\" patternUnits=\"userSpaceOnUse\"><rect width=\"1.4\" height=\"1.4\" fill=\"#6a4a30\"/><circle cx=\"0.7\" cy=\"0.7\" r=\"0.42\" fill=\"#3a2614\"/></pattern>").S("<pattern id=\"q18mg\" width=\"1.2\" height=\"1.2\" patternUnits=\"userSpaceOnUse\"><rect width=\"1.2\" height=\"1.2\" fill=\"#1d1f24\"/><circle cx=\"0.6\" cy=\"0.6\" r=\"0.36\" fill=\"#3a3d45\"/></pattern>").S("<pattern id=\"q18sl\" width=\"2\" height=\"2\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 0.5H2\" stroke=\"#000000\" stroke-opacity=\"0.28\" stroke-width=\"0.7\"/></pattern>").S("<pattern id=\"q18fl\" width=\"3\" height=\"4\" patternUnits=\"userSpaceOnUse\"><rect width=\"3\" height=\"4\" fill=\"#ffffff\" fill-opacity=\"0.06\"/><rect x=\"2.2\" width=\"0.8\" height=\"4\" fill=\"#000000\" fill-opacity=\"0.28\"/></pattern>").End()));
}, 0, "", true);
{
double h_102 = 0;
V rnd_103 = default;
h_102 = 9D;
rnd_103 = Fn((V _arrowThis110, int _argc104, V _a106, V _a107, V _a108, V _a109, V[] _rest105) => {
h_102 = ((double)(ToInt32(((h_102 * 1103515245D) + 12345D)) | ToInt32(0D)));
return ((V)((((double)(ToInt32(((double)(ToUint32(h_102) >> (int)(ToUint32(8D) & 31)))) & ToInt32(65535D))) / 65536D)));
return default;
}, 0, "", true);
NZ_38 = Invoke(Call(rep_23, V.Undef, ((V)(3D)), Fn((V _arrowThis118, int _argc111, V i_117, V _a114, V _a115, V _a116, V[] _rest112) => {
return ((V)(JsStrBuf.Begin().S("<pattern id=\"q18n").V(i_117).S("\" width=\"12\" height=\"12\" patternUnits=\"userSpaceOnUse\">").V(Invoke(Call(rep_23, V.Undef, ((V)(46D)), Fn((V _arrowThis125, int _argc119, V _a121, V _a122, V _a123, V _a124, V[] _rest120) => {
double g_126 = 0;
g_126 = Round((40D + (ToNum(Call(rnd_103, V.Undef)) * 215D)));
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_21, V.Undef, ((V)((ToNum(Call(rnd_103, V.Undef)) * 12D))))).S("\" y=\"").V(Call(f1_21, V.Undef, ((V)((ToNum(Call(rnd_103, V.Undef)) * 12D))))).S("\" width=\"").V(Call(f1_21, V.Undef, ((V)((0.5 + (ToNum(Call(rnd_103, V.Undef)) * 1.2)))))).S("\" height=\"0.7\" fill=\"rgb(").N(g_126).S(",").N(g_126).S(",").N(g_126).S(")\"/>").End()));
return default;
}, 0, "", true)), "join", ((V)("")))).S("</pattern>").End()));
}, 1, "", true)), "join", ((V)("")));
}
DEF18_40 = Add(Call(DEF18__39, V.Undef), NZ_38);
ONCE_41 = Fn((V _arrowThis136, int _argc127, V v_133, V d_134, V b_135, V _a132, V[] _rest128) => {
return ((V)(string.Concat("<animateTransform attributeName=\"transform\" type=\"translate\" values=\"", ToStr(v_133), "\" dur=\"", ToStr(Call(n4_22, V.Undef, d_134)), "s\" begin=\"", ToStr(Call(n4_22, V.Undef, (b_135 is var _t137 && Truthy(_t137) ? _t137 : ((V)(0D))))), "s\" fill=\"freeze\" calcMode=\"spline\" keyTimes=\"0;1\" keySplines=\"0.3 0 0.2 1\"/>")));
}, 3, "", true);
note_42 = Fn((V _arrowThis150, int _argc138, V C_144, V x_145, V y_146, V z_147, V[] _rest139) => {
V q_151 = default;
V k_152 = default;
double d_153 = 0;
V b_154 = default;
V i_148 = default;
V col_149 = default;
i_148 = (_argc138 > 4 ? _rest139[0] : V.Undef);
col_149 = (_argc138 > 5 ? _rest139[1] : V.Undef);
q_151 = Invoke(C_144, "p", x_145, y_146, z_147);
k_152 = Get(C_144, "k");
d_153 = (2.4 + ((ToNum(i_148) % 3D) * 0.4));
b_154 = Call(n4_22, V.Undef, ((V)(((-ToNum(i_148)) * 0.8))));
return ((V)(string.Concat("<text x=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_151, 0D))), "\" y=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_151, 1D))), "\" font-size=\"", ToStr(Call(f1_21, V.Undef, ((V)((6D * ToNum(k_152)))))), "\" ", ToStr(FONT_25), " fill=\"", ToStr((col_149 is var _t155 && Truthy(_t155) ? _t155 : ((V)("#5a3a8a")))), "\" opacity=\"0\">", (NumTruthy((ToNum(i_148) % 2D)) ? "\u266b" : "\u266a"), ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("0;1;0")), ((V)(d_153)), b_154)), ToStr(Call(an_18, V.Undef, ((V)("y")), ((V)(JsStrBuf.Begin().V(Call(f1_21, V.Undef, GetIdx(q_151, 1D))).S(";").V(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_151, 1D)) - (16D * ToNum(k_152))))))).End())), ((V)(d_153)), b_154)), ToStr(Call(an_18, V.Undef, ((V)("x")), ((V)(JsStrBuf.Begin().V(Call(f1_21, V.Undef, GetIdx(q_151, 0D))).S(";").V(Call(f1_21, V.Undef, Add(GetIdx(q_151, 0D), ((V)(((NumTruthy((ToNum(i_148) % 2D)) ? 5D : (-5D)) * ToNum(k_152))))))).End())), ((V)(d_153)), b_154)), "</text>")));
return default;
}, 6, "", true);
toon_43 = Fn((V _arrowThis168, int _argc156, V C_162, V W_163, V Hh_164, V look_165, V[] _rest157) => {
V cid_169 = default;
double sx_170 = 0;
double sy_171 = 0;
double T_172 = 0;
V hop_173 = default;
V sq_174 = default;
V cloud_175 = default;
V flower_176 = default;
V eyes_177 = default;
V SC1_178 = default;
V SC2_179 = default;
V SC3_180 = default;
V CHN_181 = default;
V n_182 = default;
JsStrBuf s_183 = null;
V R_166 = default;
V ch_167 = default;
R_166 = (_argc156 > 4 ? _rest157[0] : V.Undef);
ch_167 = (_argc156 > 5 ? _rest157[1] : V.Undef);
cid_169 = Invoke(C_162, "u", ((V)("tc")));
sx_170 = (ToNum(W_163) / 160D);
sy_171 = (ToNum(Hh_164) / 90D);
T_172 = 8D;
hop_173 = ((V)(string.Concat(ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)("0 0;0 -15;0 0")), ((V)(1D)), ((V)(0D)), ((V)(" calcMode=\"spline\" keyTimes=\"0;0.45;1\" keySplines=\"0.2 0.6 0.4 1;0.6 0 0.8 0.4\"")))), "")));
sq_174 = ((V)(string.Concat(ToStr(Call(at_19, V.Undef, ((V)("scale")), ((V)("1.18 0.82;0.9 1.12;1 1;1.18 0.82")), ((V)(1D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.2;0.55;1\"")))), "")));
cloud_175 = Fn((V _arrowThis194, int _argc184, V y_190, V s_191, V d_192, V b_193, V[] _rest185) => {
return ((V)(string.Concat("<g>", ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)(string.Concat("-50 ", ToStr(y_190), ";190 ", ToStr(y_190)))), d_192, b_193)), "<g transform=\"scale(", ToStr(s_191), ")\"><ellipse cx=\"0\" cy=\"0\" rx=\"12\" ry=\"5\" fill=\"#ffffff\"/><circle cx=\"-4\" cy=\"-3\" r=\"5\" fill=\"#ffffff\"/><circle cx=\"4\" cy=\"-4\" r=\"6\" fill=\"#ffffff\"/></g></g>")));
}, 4, "", true);
flower_176 = Fn((V _arrowThis203, int _argc195, V x_201, V c_202, V _a199, V _a200, V[] _rest196) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(x_201), " 78)\"><path d=\"M0 0V-6\" stroke=\"#3f9a3a\" stroke-width=\"0.8\"/><g transform=\"translate(0 -7)\">", ToStr(Call(at_19, V.Undef, ((V)("rotate")), ((V)("-8;8;-8")), ((V)(2.2)), ((V)(((-ToNum(x_201)) / 40D))))), ToStr(Invoke(Call(rep_23, V.Undef, ((V)(5D)), Fn((V _arrowThis211, int _argc204, V i_210, V _a207, V _a208, V _a209, V[] _rest205) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Cos((ToNum(i_210) * 1.2566)) * 1.8))))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Sin((ToNum(i_210) * 1.2566)) * 1.8))))), "\" r=\"1.3\" fill=\"", ToStr(c_202), "\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<circle r=\"1\" fill=\"#ffd34a\"/></g></g>")));
}, 2, "", true);
eyes_177 = Fn((V _arrowThis220, int _argc212, V dx_218, V dy_219, V _a216, V _a217, V[] _rest213) => {
return ((V)(string.Concat("<g>", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("1;1;0;1;1")), ((V)(3.1)), ((V)(0D)), ((V)(" keyTimes=\"0;0.9;0.93;0.96;1\"")))), "<ellipse cx=\"", NumStr((-ToNum(dx_218))), "\" cy=\"", ToStr(dy_219), "\" rx=\"1.2\" ry=\"1.9\" fill=\"#2a1a2a\"/><ellipse cx=\"", ToStr(dx_218), "\" cy=\"", ToStr(dy_219), "\" rx=\"1.2\" ry=\"1.9\" fill=\"#2a1a2a\"/><circle cx=\"", NumStr(((-ToNum(dx_218)) + 0.4)), "\" cy=\"", NumStr((ToNum(dy_219) - 0.8)), "\" r=\"0.45\" fill=\"#ffffff\"/><circle cx=\"", ToStr(Add(dx_218, ((V)(0.4)))), "\" cy=\"", NumStr((ToNum(dy_219) - 0.8)), "\" r=\"0.45\" fill=\"#ffffff\"/></g>")));
}, 2, "", true);
SC1_178 = Fn((V _arrowThis227, int _argc221, V _a223, V _a224, V _a225, V _a226, V[] _rest222) => {
return ((V)(JsStrBuf.Begin().S("").S(string.Concat("<rect width=\"160\" height=\"90\" fill=\"url(#q18sky)\"/>", "")).S(string.Concat("<g transform=\"translate(134 20)\"><g>", ToStr(Call(at_19, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(14D)))), ToStr(Invoke(Call(rep_23, V.Undef, ((V)(8D)), Fn((V _arrowThis235, int _argc228, V i_234, V _a231, V _a232, V _a233, V[] _rest229) => {
return ((V)(string.Concat("<path d=\"M-1.8 -11L0 -16.5L1.8 -11Z\" fill=\"#ffc93a\" transform=\"rotate(", NumStr((ToNum(i_234) * 45D)), ")\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g><circle r=\"8.4\" fill=\"#ffd84a\" stroke=\"#f0a92a\" stroke-width=\"0.8\"/><circle cx=\"-2.8\" cy=\"-1\" r=\"0.95\" fill=\"#5a3a10\"/><circle cx=\"2.8\" cy=\"-1\" r=\"0.95\" fill=\"#5a3a10\"/><path d=\"M-2.8 2.4Q0 4.8 2.8 2.4\" stroke=\"#5a3a10\" stroke-width=\"0.8\" fill=\"none\" stroke-linecap=\"round\"/></g>")).V(Call(cloud_175, V.Undef, ((V)(16D)), ((V)(1D)), ((V)(16D)), ((V)(0D)))).V(Call(cloud_175, V.Undef, ((V)(30D)), ((V)(0.7)), ((V)(22D)), ((V)((-11D))))).V(Call(cloud_175, V.Undef, ((V)(12D)), ((V)(0.55)), ((V)(19D)), ((V)((-6D))))).S(string.Concat("<path d=\"M0 62Q30 46 62 58T124 54T160 56V90H0Z\" fill=\"#9adf7a\"/><path d=\"M0 72Q42 60 84 70T160 68V90H0Z\" fill=\"#63c25a\"/><path d=\"M0 80Q60 74 160 80V90H0Z\" fill=\"#4fae4c\"/>", "")).V(Call(flower_176, V.Undef, ((V)(18D)), ((V)("#ff7aa8")))).V(Call(flower_176, V.Undef, ((V)(58D)), ((V)("#ffffff")))).V(Call(flower_176, V.Undef, ((V)(104D)), ((V)("#b88aff")))).V(Call(flower_176, V.Undef, ((V)(146D)), ((V)("#ff9a4a")))).S(string.Concat("<g transform=\"translate(118 79)\"><ellipse cy=\"0.6\" rx=\"9\" ry=\"1.6\" fill=\"#000000\" opacity=\"0.15\"/><g>", ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)("0 0;0 -1.2;0 0")), ((V)(0.9)))), "<path d=\"M-8 0Q-9 -16 0 -16Q9 -16 8 0Z\" fill=\"#7ab8ff\" stroke=\"#3f7fc8\" stroke-width=\"0.8\"/><g transform=\"translate(7 -9)\"><g>", ToStr(Call(at_19, V.Undef, ((V)("rotate")), ((V)("-20;-80;-20")), ((V)(0.7)))), "<ellipse cx=\"0\" cy=\"-4\" rx=\"2\" ry=\"4.4\" fill=\"#7ab8ff\" stroke=\"#3f7fc8\" stroke-width=\"0.7\"/></g></g>", ToStr(Call(eyes_177, V.Undef, ((V)(2.8)), ((V)((-9D))))), "<path d=\"M-2.4 -4.6Q0 -2.4 2.4 -4.6\" stroke=\"#2a1a2a\" stroke-width=\"0.7\" fill=\"none\" stroke-linecap=\"round\"/><circle cx=\"-5\" cy=\"-5.6\" r=\"1.2\" fill=\"#ff8fb4\" opacity=\"0.7\"/><circle cx=\"5\" cy=\"-5.6\" r=\"1.2\" fill=\"#ff8fb4\" opacity=\"0.7\"/></g></g>")).S(string.Concat("<g transform=\"translate(0 80)\"><g>", ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)("-24 0;184 0")), ((V)(T_172)))), "<ellipse cy=\"0.6\" rx=\"8\" ry=\"1.5\" fill=\"#000000\" opacity=\"0.15\"/><g>", ToStr(hop_173), "<g>", ToStr(sq_174), "<path d=\"M-10 0Q-11 -18 0 -18Q11 -18 10 0Z\" fill=\"#ff9cc8\" stroke=\"#d25a90\" stroke-width=\"0.8\"/><path d=\"M-6 -16Q-8 -22 -4 -21Q-3 -18 -3 -17Z\" fill=\"#ff9cc8\" stroke=\"#d25a90\" stroke-width=\"0.6\"/><path d=\"M6 -16Q8 -22 4 -21Q3 -18 3 -17Z\" fill=\"#ff9cc8\" stroke=\"#d25a90\" stroke-width=\"0.6\"/>", ToStr(Call(eyes_177, V.Undef, ((V)(3.4)), ((V)((-10D))))), "<path d=\"M-3 -5.6Q0 -2 3 -5.6Z\" fill=\"#7a1f3a\"/><circle cx=\"-6.4\" cy=\"-6.6\" r=\"1.4\" fill=\"#ff5f8f\" opacity=\"0.6\"/><circle cx=\"6.4\" cy=\"-6.6\" r=\"1.4\" fill=\"#ff5f8f\" opacity=\"0.6\"/></g></g></g></g>")).S(string.Concat("<g transform=\"translate(6 11)\"><g>", ToStr(Call(at_19, V.Undef, ((V)("scale")), ((V)("1;1.06;1")), ((V)(1.6)))), "<text x=\"0\" y=\"0\" font-size=\"7\" font-family=\"'Fredoka','Comic Sans MS',sans-serif\" font-weight=\"700\" fill=\"#ffffff\" stroke=\"#d25a90\" stroke-width=\"1.4\" paint-order=\"stroke\">SQUISH TOONS</text></g></g>")).End()));
}, 0, "", true);
SC2_179 = Fn((V _arrowThis242, int _argc236, V _a238, V _a239, V _a240, V _a241, V[] _rest237) => {
V KT_243 = default;
KT_243 = ((V)(" keyTimes=\"0;0.45;0.62;0.7;1\""));
return ((V)(JsStrBuf.Begin().S(string.Concat("<rect width=\"160\" height=\"90\" fill=\"#6fc0ff\"/><rect width=\"160\" height=\"26\" fill=\"#3a3f6a\"/>", "")).V(Invoke(Call(rep_23, V.Undef, ((V)(22D)), Fn((V _arrowThis251, int _argc244, V i_250, V _a247, V _a248, V _a249, V[] _rest245) => {
V c_252 = default;
double x_253 = 0;
c_252 = GetIdx(Arr(((V)("#ff9a4a")), ((V)("#7ab8ff")), ((V)("#ffd84a")), ((V)("#ff7aa8")), ((V)("#9adf7a"))), (ToNum(i_250) % 5D));
x_253 = (4D + (ToNum(i_250) * 7.2));
return ((V)(string.Concat("<g>", ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)("0 0;0 0;0 -3.5;0 0;0 -3.5;0 0")), ((V)(T_172)), ((V)(0D)), ((V)(" keyTimes=\"0;0.62;0.68;0.74;0.8;1\"")))), "<circle cx=\"", ToStr(Call(f1_21, V.Undef, ((V)(x_253)))), "\" cy=\"", NumStr((18D + ((ToNum(i_250) % 2D) * 3D))), "\" r=\"2.6\" fill=\"", ToStr(c_252), "\"/><circle cx=\"", ToStr(Call(f1_21, V.Undef, ((V)((x_253 - 0.8))))), "\" cy=\"", NumStr((17.6 + ((ToNum(i_250) % 2D) * 3D))), "\" r=\"0.4\" fill=\"#2a1a2a\"/><circle cx=\"", ToStr(Call(f1_21, V.Undef, ((V)((x_253 + 0.8))))), "\" cy=\"", NumStr((17.6 + ((ToNum(i_250) % 2D) * 3D))), "\" r=\"0.4\" fill=\"#2a1a2a\"/></g>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<rect y=\"26\" width=\"160\" height=\"64\" fill=\"#5cbf4a\"/>", "")).V(Invoke(Call(rep_23, V.Undef, ((V)(6D)), Fn((V _arrowThis261, int _argc254, V i_260, V _a257, V _a258, V _a259, V[] _rest255) => {
return ((V)(string.Concat("<rect x=\"", NumStr((ToNum(i_260) * 28D)), "\" y=\"26\" width=\"14\" height=\"64\" fill=\"#52b040\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M0 30H160M80 30V90\" stroke=\"#ffffff\" stroke-opacity=\"0.7\" stroke-width=\"0.8\"/><ellipse cx=\"80\" cy=\"60\" rx=\"16\" ry=\"9\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.7\" stroke-width=\"0.8\"/>", "")).S(string.Concat("<g transform=\"translate(140 40)\"><path d=\"M0 0H14V38\" stroke=\"#ffffff\" stroke-width=\"1.6\" fill=\"none\"/><path d=\"M0 0V38\" stroke=\"#ffffff\" stroke-width=\"1.6\"/><rect x=\"1\" y=\"1\" width=\"12\" height=\"36\" fill=\"url(#q18sl)\" opacity=\"0.5\"/></g>", "")).S(string.Concat("<g>", ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)("0 0;0 0;0 -9;0 -2;0 0")), ((V)(T_172)), ((V)(0D)), KT_243)), "<g transform=\"translate(138 74)\"><path d=\"M-7 0Q-8 -14 0 -14Q8 -14 7 0Z\" fill=\"#7ab8ff\" stroke=\"#3f7fc8\" stroke-width=\"0.8\"/>", ToStr(Call(eyes_177, V.Undef, ((V)(2.6)), ((V)((-8D))))), "<path d=\"M-2 -3.6Q0 -4.6 2 -3.6\" stroke=\"#2a1a2a\" stroke-width=\"0.6\" fill=\"none\"/><path d=\"M-9 -9L-7 -7M9 -9L7 -7\" stroke=\"#3f7fc8\" stroke-width=\"1.4\" stroke-linecap=\"round\"/></g></g>")).S(string.Concat("<g>", ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)("-20 0;72 0;72 0;72 0;-20 0")), ((V)(T_172)), ((V)(0D)), ((V)(" keyTimes=\"0;0.4;0.7;0.95;1\"")))), "<g transform=\"translate(20 80)\"><ellipse cy=\"0.6\" rx=\"8\" ry=\"1.5\" fill=\"#000000\" opacity=\"0.15\"/><g>", ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)("0 0;0 -3;0 0")), ((V)(0.5)))), "<path d=\"M-9 0Q-10 -17 0 -17Q10 -17 9 0Z\" fill=\"#ff9a4a\" stroke=\"#d2692a\" stroke-width=\"0.8\"/>", ToStr(Call(eyes_177, V.Undef, ((V)(3.2)), ((V)((-10D))))), "<path d=\"M-2.6 -5Q0 -2.4 2.6 -5Z\" fill=\"#7a1f3a\"/><text x=\"0\" y=\"-1.6\" text-anchor=\"middle\" font-size=\"4\" ", ToStr(FONT_25), " fill=\"#ffffff\">9</text></g></g></g>")).S(string.Concat("<g><animateMotion dur=\"", NumStr(T_172), "s\" repeatCount=\"indefinite\" keyPoints=\"0;0.42;0.62;0.62;1\" keyTimes=\"0;0.4;0.6;0.95;1\" calcMode=\"linear\" path=\"M8 84L92 84Q118 70 146 62L146 62\"/>", ToStr(Call(at_19, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(0.6)))), "<circle r=\"2.6\" fill=\"#ffffff\" stroke=\"#2a2a2a\" stroke-width=\"0.4\"/><path d=\"M0 -1.2L1.1 -0.4L0.7 0.9H-0.7L-1.1 -0.4Z\" fill=\"#2a2a2a\"/></g>")).S(string.Concat("<g opacity=\"0\">", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("0;0;1;1;0;0")), ((V)(T_172)), ((V)(0D)), ((V)(" keyTimes=\"0;0.6;0.63;0.88;0.92;1\"")))), "<g transform=\"translate(80 44)\"><g>", ToStr(Call(at_19, V.Undef, ((V)("scale")), ((V)("0.4;1.15;1")), ((V)(0.5)), ((V)(0D)), ((V)(" keyTimes=\"0;0.6;1\"")))), "<text x=\"0\" y=\"0\" text-anchor=\"middle\" font-size=\"16\" font-family=\"'Fredoka','Comic Sans MS',sans-serif\" font-weight=\"700\" fill=\"#ffd84a\" stroke=\"#d2692a\" stroke-width=\"2\" paint-order=\"stroke\">GOAL!</text></g></g></g>")).S(string.Concat("<g transform=\"translate(4 4)\"><rect width=\"38\" height=\"8\" rx=\"2\" fill=\"#1d1f2a\" opacity=\"0.9\"/><circle cx=\"5\" cy=\"4\" r=\"2.2\" fill=\"#ff9a4a\"/><circle cx=\"33\" cy=\"4\" r=\"2.2\" fill=\"#7ab8ff\"/><text x=\"19\" y=\"6.2\" text-anchor=\"middle\" font-size=\"5.4\" ", ToStr(FONT_25), " fill=\"#ffffff\">0 - 0", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("1;1;0;0")), ((V)(T_172)), ((V)(0D)), ((V)(" keyTimes=\"0;0.62;0.63;1\"")))), "</text><text x=\"19\" y=\"6.2\" text-anchor=\"middle\" font-size=\"5.4\" ", ToStr(FONT_25), " fill=\"#ffd84a\" opacity=\"0\">1 - 0", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("0;0;1;1")), ((V)(T_172)), ((V)(0D)), ((V)(" keyTimes=\"0;0.62;0.63;1\"")))), "</text></g>")).End()));
return default;
}, 0, "", true);
SC3_180 = Fn((V _arrowThis268, int _argc262, V _a264, V _a265, V _a266, V _a267, V[] _rest263) => {
return ((V)(JsStrBuf.Begin().S("<rect width=\"160\" height=\"90\" fill=\"#141a3e\"/><rect width=\"160\" height=\"90\" fill=\"#3a2a7a\" opacity=\"0.45\"/>").V(Invoke(Call(rep_23, V.Undef, ((V)(36D)), Fn((V _arrowThis276, int _argc269, V i_275, V _a272, V _a273, V _a274, V[] _rest270) => {
double x_277 = 0;
double y_278 = 0;
double r_279 = 0;
x_277 = ((ToNum(i_275) * 47D) % 160D);
y_278 = (((ToNum(i_275) * 29D) + 7D) % 90D);
r_279 = (0.35 + ((ToNum(i_275) % 3D) * 0.25));
return ((V)(string.Concat("<circle cx=\"", NumStr(x_277), "\" cy=\"", NumStr(y_278), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)(r_279)))), "\" fill=\"#ffffff\">", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("0.3;1;0.3")), ((V)((1.6 + ((ToNum(i_275) % 5D) * 0.4)))), ((V)(((-ToNum(i_275)) * 0.3))))), "</circle>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<g transform=\"translate(118 62)\"><circle r=\"17\" fill=\"#ff9cc8\"/><path d=\"M-17 0A17 17 0 0 0 17 0\" fill=\"#e86fa8\" opacity=\"0.6\"/><g>", ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)("-6 0;6 0;-6 0")), ((V)(8D)))), "<ellipse cx=\"-4\" cy=\"-6\" rx=\"4\" ry=\"2.2\" fill=\"#ffd0e6\" opacity=\"0.7\"/><ellipse cx=\"5\" cy=\"5\" rx=\"3\" ry=\"1.6\" fill=\"#c9508a\" opacity=\"0.6\"/></g><ellipse rx=\"27\" ry=\"6\" fill=\"none\" stroke=\"#ffd84a\" stroke-width=\"2.2\" transform=\"rotate(-14)\"/><path d=\"M-17 -2A17 17 0 0 1 17 -2\" fill=\"#ff9cc8\" transform=\"rotate(-14)\"/></g>")).S(string.Concat("<g transform=\"translate(24 20)\"><circle r=\"7\" fill=\"#d9dde2\"/><circle cx=\"-2\" cy=\"-1.6\" r=\"1.6\" fill=\"#b9bec6\"/><circle cx=\"2.4\" cy=\"2\" r=\"1.1\" fill=\"#b9bec6\"/></g>", "")).S(string.Concat("<path d=\"M0 0L-14 -4\" stroke=\"#ffffff\" stroke-width=\"0.8\" stroke-linecap=\"round\" opacity=\"0\">", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("0;0;1;0;0")), ((V)(T_172)), ((V)(0D)), ((V)(" keyTimes=\"0;0.3;0.34;0.42;1\"")))), "<animateMotion dur=\"", NumStr(T_172), "s\" repeatCount=\"indefinite\" path=\"M150 6L90 26\"/></path>")).S(string.Concat("<g><animateMotion dur=\"", NumStr(T_172), "s\" repeatCount=\"indefinite\" rotate=\"auto\" path=\"M-20 60C30 20 70 80 110 40S170 10 190 30\"/><g transform=\"rotate(90)\"><path d=\"M-4 6L-8 12H-2Z M4 6L8 12H2Z\" fill=\"#ff5a5a\"/><path d=\"M0 -12Q6 -6 5 8H-5Q-6 -6 0 -12Z\" fill=\"#f4f6fa\" stroke=\"#9aa0a6\" stroke-width=\"0.6\"/><circle cy=\"-2\" r=\"3\" fill=\"#7ab8ff\" stroke=\"#3f7fc8\" stroke-width=\"0.6\"/><circle cy=\"-2\" r=\"2\" fill=\"#ffb26a\"/><path d=\"M-1.4 -3.6L-1 -2.6M1.4 -3.6L1 -2.6\" stroke=\"#2a1a2a\" stroke-width=\"0.4\"/><path d=\"M-3 8Q0 ", ToStr(Call(f1_21, V.Undef, ((V)(16D)))), " 3 8\" fill=\"#ffd84a\">", ToStr(Call(an_18, V.Undef, ((V)("d")), ((V)("M-3 8Q0 16 3 8;M-3 8Q0 13 3 8;M-3 8Q0 16 3 8")), ((V)(0.25)))), "</path></g></g>")).S(string.Concat("<g transform=\"translate(6 11)\"><g>", ToStr(Call(at_19, V.Undef, ((V)("scale")), ((V)("1;1.06;1")), ((V)(1.6)))), "<text x=\"0\" y=\"0\" font-size=\"7\" font-family=\"'Fredoka','Comic Sans MS',sans-serif\" font-weight=\"700\" fill=\"#ffffff\" stroke=\"#6a4ad8\" stroke-width=\"1.4\" paint-order=\"stroke\">SPACE TRIP</text></g></g>")).End()));
}, 0, "", true);
CHN_181 = Arr(((V)("")), ((V)("SQUISH TOONS")), ((V)("SQUISH CUP")), ((V)("SPACE TRIP")));
n_182 = ((SEqN(ch_167, 2D) || SEqN(ch_167, 3D)) ? ch_167 : ((V)(1D)));
s_183 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<defs><clipPath id=\"", ToStr(cid_169), "\"><rect width=\"", ToStr(Call(f1_21, V.Undef, W_163)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_164)), "\" rx=\"", ToStr((R_166 is var _t280 && Truthy(_t280) ? _t280 : ((V)(0D)))), "\"/></clipPath></defs><g clip-path=\"url(#", ToStr(cid_169), ")\"><g transform=\"scale(", ToStr(Call(n4_22, V.Undef, ((V)(sx_170)))), " ", ToStr(Call(n4_22, V.Undef, ((V)(sy_171)))), ")\">")).V((SEqN(n_182, 2D) ? Call(SC2_179, V.Undef) : (SEqN(n_182, 3D) ? Call(SC3_180, V.Undef) : Call(SC1_178, V.Undef)))).S(string.Concat("<g opacity=\"0\">", "<animate attributeName=\"opacity\" values=\"1;1;0\" keyTimes=\"0;0.8;1\" dur=\"2.6s\" fill=\"freeze\"/>", "<rect x=\"122\" y=\"4\" width=\"34\" height=\"9\" rx=\"1.6\" fill=\"#000000\" opacity=\"0.45\"/><text x=\"139\" y=\"10.6\" text-anchor=\"middle\" font-size=\"5.6\" ", ToStr(FONT_25), " fill=\"#7dff9e\">CH ", ToStr(n_182), "</text></g>")).End());
if (SEqS(look_165, "crt")) {
s_183.S(string.Concat("<rect width=\"160\" height=\"90\" fill=\"#7dffb0\" opacity=\"0.1\"/><rect width=\"160\" height=\"90\" fill=\"url(#q18sl)\"/><rect y=\"-20\" width=\"160\" height=\"12\" fill=\"#ffffff\" opacity=\"0.1\">", ToStr(Call(an_18, V.Undef, ((V)("y")), ((V)("-20;100")), ((V)(3.6)))), "</rect><rect width=\"160\" height=\"90\" fill=\"#ffffff\" opacity=\"0\">", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("0;0;0.2;0;0")), ((V)(5.3)), ((V)(0D)), ((V)(" keyTimes=\"0;0.6;0.62;0.65;1\"")))), "</rect>"));
}
if (SEqS(look_165, "vint")) {
s_183.S(string.Concat("<rect width=\"160\" height=\"90\" fill=\"#ffae5a\" opacity=\"0.16\"/><rect width=\"160\" height=\"90\" fill=\"url(#q18sl)\" opacity=\"0.5\"/>", ""));
}
if (SEqS(look_165, "holo")) {
s_183.S(string.Concat("<rect width=\"160\" height=\"90\" fill=\"#3fe6ff\" opacity=\"0.2\"/><rect width=\"160\" height=\"90\" fill=\"url(#q18sl)\" opacity=\"0.6\"/><rect y=\"-10\" width=\"160\" height=\"5\" fill=\"#bffaff\" opacity=\"0.35\">", ToStr(Call(an_18, V.Undef, ((V)("y")), ((V)("-10;95")), ((V)(2.6)))), "</rect>"));
}
s_183.S(string.Concat("</g>", "")).S(((SEqS(look_165, "crt") || SEqS(look_165, "vint")) ? string.Concat("<rect width=\"", ToStr(Call(f1_21, V.Undef, W_163)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_164)), "\" fill=\"url(#q18vg)\"/>") : "")).S(string.Concat("<rect width=\"", ToStr(Call(f1_21, V.Undef, W_163)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_164)), "\" fill=\"url(#q18rf)\"/></g>"));
return ((V)((SEqS(look_165, "holo") ? string.Concat("<g opacity=\"0.88\">", s_183.Str, "</g>") : s_183.Str)));
return default;
}, 6, "", true);
noise_44 = Fn((V _arrowThis292, int _argc281, V C_287, V W_288, V Hh_289, V R_290, V[] _rest282) => {
V cid_293 = default;
V look_291 = default;
look_291 = (_argc281 > 4 ? _rest282[0] : V.Undef);
cid_293 = Invoke(C_287, "u", ((V)("nz")));
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><clipPath id=\"", ToStr(cid_293), "\"><rect width=\"", ToStr(Call(f1_21, V.Undef, W_288)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_289)), "\" rx=\"", ToStr((R_290 is var _t294 && Truthy(_t294) ? _t294 : ((V)(0D)))), "\"/></clipPath></defs><g clip-path=\"url(#", ToStr(cid_293), ")\"><rect width=\"", ToStr(Call(f1_21, V.Undef, W_288)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_289)), "\" fill=\"#8a8f96\"/>")).V(Invoke(Call(rep_23, V.Undef, ((V)(3D)), Fn((V _arrowThis302, int _argc295, V i_301, V _a298, V _a299, V _a300, V[] _rest296) => {
return ((V)(string.Concat("<rect width=\"", ToStr(Call(f1_21, V.Undef, W_288)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_289)), "\" fill=\"url(#q18n", ToStr(i_301), ")\" opacity=\"", NumStr((Truthy(i_301) ? 0D : 1D)), "\"><animate attributeName=\"opacity\" values=\"", ToStr(GetK(Arr(((V)("1;0;0")), ((V)("0;1;0")), ((V)("0;0;1"))), i_301)), "\" dur=\"0.18s\" calcMode=\"discrete\" repeatCount=\"indefinite\"/></rect>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<rect y=\"-10\" width=\"", ToStr(Call(f1_21, V.Undef, W_288)), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(Hh_289) * 0.18))))), "\" fill=\"#ffffff\" opacity=\"0.18\">", ToStr(Call(an_18, V.Undef, ((V)("y")), ((V)(string.Concat(ToStr(Call(f1_21, V.Undef, ((V)(((-ToNum(Hh_289)) * 0.2))))), ";", ToStr(Call(f1_21, V.Undef, Hh_289))))), ((V)(1.4)))), "</rect><rect width=\"", ToStr(Call(f1_21, V.Undef, W_288)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_289)), "\" fill=\"url(#q18sl)\" opacity=\"0.5\"/>")).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(W_288) / 2D))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(Hh_289) / 2D))))), ") scale(", ToStr(Call(n4_22, V.Undef, ((V)(Min((ToNum(W_288) / 160D), (ToNum(Hh_289) / 90D)))))), ")\"><rect x=\"-38\" y=\"-9\" width=\"76\" height=\"18\" rx=\"3\" fill=\"#000000\" opacity=\"0.55\"/><text x=\"0\" y=\"-1\" text-anchor=\"middle\" font-size=\"7\" ", ToStr(FONT_25), " fill=\"#ffffff\">NO SOUND</text><text x=\"0\" y=\"6\" text-anchor=\"middle\" font-size=\"4.4\" ", ToStr(FONT_25), " fill=\"#ffd84a\">add speakers to watch</text></g>")).S(((SEqS(look_291, "crt") || SEqS(look_291, "vint")) ? string.Concat("<rect width=\"", ToStr(Call(f1_21, V.Undef, W_288)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_289)), "\" fill=\"url(#q18vg)\"/>") : "")).S("</g>").End()));
return default;
}, 5, "", true);
tvState_45 = Fn((V _arrowThis310, int _argc303, V S_309, V _a306, V _a307, V _a308, V[] _rest304) => {
V st_311 = default;
V m_312 = default;
st_311 = (Get(S_309, "st") is var _t313 && Truthy(_t313) ? _t313 : ((V)("")));
if (Truthy(Invoke(NewRegExp(RX0, "noise", ""), "test", st_311))) {
return NewObj(3).Put("on", ((V)(1D))).Put("ch", ((V)(0D))).Put("nz", ((V)(1D))).V;
}
if (!(Truthy(Call(isPlay_27, V.Undef, S_309)))) {
return NewObj(2).Put("on", ((V)(0D))).Put("ch", ((V)(0D))).V;
}
m_312 = Invoke(NewRegExp(RX1, "ch(\\d)", ""), "exec", st_311);
return NewObj(2).Put("on", ((V)(1D))).Put("ch", ((V)((Truthy(m_312) ? ToNum(GetIdx(m_312, 1D)) : 1D)))).V;
return default;
}, 1, "", true);
tvPic_46 = Fn((V _arrowThis327, int _argc314, V C_320, V W_321, V Hh_322, V look_323, V[] _rest315) => {
V R_324 = default;
V T_325 = default;
V off_326 = default;
R_324 = (_argc314 > 4 ? _rest315[0] : V.Undef);
T_325 = (_argc314 > 5 ? _rest315[1] : V.Undef);
off_326 = (_argc314 > 6 ? _rest315[2] : V.Undef);
return (Truthy(Get(T_325, "nz")) ? Call(noise_44, V.Undef, C_320, W_321, Hh_322, R_324, look_323) : (Truthy(Get(T_325, "ch")) ? Call(toon_43, V.Undef, C_320, W_321, Hh_322, look_323, R_324, Get(T_325, "ch")) : off_326));
}, 7, "", true);
glass_47 = Fn((V _arrowThis338, int _argc328, V W_334, V Hh_335, V R_336, V fill_337, V[] _rest329) => {
return ((V)(string.Concat("<rect width=\"", ToStr(Call(f1_21, V.Undef, W_334)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_335)), "\" rx=\"", ToStr((R_336 is var _t339 && Truthy(_t339) ? _t339 : ((V)(0D)))), "\" fill=\"", ToStr((fill_337 is var _t340 && Truthy(_t340) ? _t340 : ((V)("url(#q18gl)")))), "\"/><path d=\"M", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(W_334) * 0.56))))), " 0H", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(W_334) * 0.74))))), "L", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(W_334) * 0.46))))), " ", ToStr(Call(f1_21, V.Undef, Hh_335)), "H", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(W_334) * 0.28))))), "Z\" fill=\"#ffffff\" opacity=\"0.06\"/><rect x=\"0.3\" y=\"0.3\" width=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(W_334) - 0.6))))), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(Hh_335) - 0.6))))), "\" rx=\"", ToStr((R_336 is var _t341 && Truthy(_t341) ? _t341 : ((V)(0D)))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.1\" stroke-width=\"0.5\"/>")));
}, 4, "", true);
scr_48 = Fn((V _arrowThis353, int _argc342, V x_348, V y_349, V z_350, V w_351, V[] _rest343) => {
V h_352 = default;
h_352 = (_argc342 > 4 ? _rest343[0] : V.Undef);
return Call(slab_12, V.Undef, x_348, y_349, z_350, w_351, h_352, ((V)(0.2)), ((V)("#000000")), NewObj(5).Put("scr", ((V)(1D))).Put("r", ((V)(0.3))).Put("emit", ((V)(1D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0D))).V);
}, 5, "", true);
knob_49 = Fn((V _arrowThis364, int _argc354, V x_360, V y_361, V r_362, V on_363, V[] _rest355) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(x_360), "\" cy=\"", ToStr(y_361), "\" r=\"", ToStr(Call(f1_21, V.Undef, r_362)), "\" fill=\"#2a2622\"/><circle cx=\"", ToStr(x_360), "\" cy=\"", ToStr(y_361), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(r_362) * 0.78))))), "\" fill=\"#c9c2b0\"/>", ToStr(Invoke(Call(rep_23, V.Undef, ((V)(8D)), Fn((V _arrowThis372, int _argc365, V i_371, V _a368, V _a369, V _a370, V[] _rest366) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_21, V.Undef, Add(x_360, ((V)(((FdLibm.Cos((ToNum(i_371) * 0.785)) * ToNum(r_362)) * 0.78)))))), " ", ToStr(Call(f1_21, V.Undef, Add(y_361, ((V)(((FdLibm.Sin((ToNum(i_371) * 0.785)) * ToNum(r_362)) * 0.78)))))), "L", ToStr(Call(f1_21, V.Undef, Add(x_360, ((V)(((FdLibm.Cos((ToNum(i_371) * 0.785)) * ToNum(r_362)) * 0.55)))))), " ", ToStr(Call(f1_21, V.Undef, Add(y_361, ((V)(((FdLibm.Sin((ToNum(i_371) * 0.785)) * ToNum(r_362)) * 0.55)))))), "\" stroke=\"#7a7262\" stroke-width=\"0.3\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<path d=\"M", ToStr(x_360), " ", ToStr(y_361), "L", ToStr(Call(f1_21, V.Undef, Add(x_360, ((V)((ToNum(r_362) * 0.4)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(y_361) - (ToNum(r_362) * 0.6)))))), "\" stroke=\"#3a342a\" stroke-width=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(r_362) * 0.2))))), "\" stroke-linecap=\"round\"/><circle cx=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(x_360) - (ToNum(r_362) * 0.3)))))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(y_361) - (ToNum(r_362) * 0.35)))))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(r_362) * 0.2))))), "\" fill=\"#ffffff\" opacity=\"0.5\"/>")));
}, 4, "", true);
led_50 = Fn((V _arrowThis383, int _argc373, V x_379, V y_380, V on_381, V c_382, V[] _rest374) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(x_379), "\" cy=\"", ToStr(y_380), "\" r=\"0.6\" fill=\"", ToStr((Truthy(on_381) ? (c_382 is var _t384 && Truthy(_t384) ? _t384 : ((V)("#5dff7a"))) : ((V)("#ff5a4a")))), "\"/><circle cx=\"", ToStr(x_379), "\" cy=\"", ToStr(y_380), "\" r=\"1.5\" fill=\"", ToStr((Truthy(on_381) ? (c_382 is var _t385 && Truthy(_t385) ? _t385 : ((V)("#5dff7a"))) : ((V)("#ff5a4a")))), "\" opacity=\"0.25\"/>")));
}, 4, "", true);
Set(N_13, "rabbit18", Fn((V _arrowThis393, int _argc386, V S_392, V _a389, V _a390, V _a391, V[] _rest387) => {
V T_394 = default;
V on_395 = default;
V mu_396 = default;
V TB_397 = default;
double TW_398 = 0;
double TH_399 = 0;
double TD_400 = 0;
double SY_401 = 0;
double ST_402 = 0;
V D_403 = default;
V face_404 = default;
V top_405 = default;
V side_406 = default;
T_394 = Call(tvState_45, V.Undef, S_392);
on_395 = Get(T_394, "on");
mu_396 = (GtN(Get(T_394, "ch"), 0D) ? V.True : V.False);
TB_397 = ((V)("#a9d3c2"));
TW_398 = 44D;
TH_399 = 32D;
TD_400 = 30D;
SY_401 = 34D;
ST_402 = 3.2;
D_403 = NewObj(5).Put("w", ((V)(46D))).Put("d", ((V)(40D))).Put("act", ((V)("watch"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(100D))).V).Put("build", Fn((V _arrowThis413, int _argc407, V _a409, V _a410, V _a411, V _a412, V[] _rest408) => {
return Arr(Call(scr_48, V.Undef, ((V)((-5D))), ((V)((SY_401 + 5D))), ((V)(((TD_400 / 2D) + 0.3))), ((V)(30D)), ((V)(22D))));
}, 0, "build", true)).V;
face_404 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"1.4\" y=\"1.4\" width=\"", NumStr((TW_398 - 2.8)), "\" height=\"", NumStr((TH_399 - 2.8)), "\" rx=\"3\" fill=\"", ToStr(Call(shade_11, V.Undef, TB_397, ((V)(0.92)))), "\"/>")).S(string.Concat("<rect x=\"2.2\" y=\"2.4\" width=\"32\" height=\"24\" rx=\"5\" fill=\"#2a2e2a\"/><g transform=\"translate(3.2 3.4)\">", ToStr(Call(tvPic_46, V.Undef, NewObj(1).Put("u", Fn((V _arrowThis421, int _argc414, V s_420, V _a417, V _a418, V _a419, V[] _rest415) => {
return ((V)(JsStrBuf.Begin().S("q18").V(s_420).N(++UID_51).End()));
}, 1, "u", true)).V, ((V)(30D)), ((V)(22D)), ((V)("crt")), ((V)(4D)), T_394, Call(glass_47, V.Undef, ((V)(30D)), ((V)(22D)), ((V)(4D)), ((V)("url(#q18crt)"))))), "</g>")).S(string.Concat("<rect x=\"36\" y=\"2.4\" width=\"6.2\" height=\"24\" rx=\"1.2\" fill=\"", ToStr(Call(shade_11, V.Undef, TB_397, ((V)(0.8)))), "\"/>")).V(Call(knob_49, V.Undef, ((V)(39.1)), ((V)(7.2)), ((V)(2.5)))).V(Call(knob_49, V.Undef, ((V)(39.1)), ((V)(14.2)), ((V)(2D)))).V(Invoke(Call(rep_23, V.Undef, ((V)(5D)), Fn((V _arrowThis429, int _argc422, V i_428, V _a425, V _a426, V _a427, V[] _rest423) => {
return ((V)(string.Concat("<rect x=\"36.9\" y=\"", ToStr(Call(f1_21, V.Undef, ((V)((18.6 + (ToNum(i_428) * 1.5)))))), "\" width=\"4.4\" height=\"0.7\" rx=\"0.35\" fill=\"#3d4a44\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Call(led_50, V.Undef, ((V)(39.1)), ((V)(28.4)), on_395)).S(string.Concat("<text x=\"18.2\" y=\"30\" text-anchor=\"middle\" ", ToStr(FONT_25), " font-size=\"2.1\" letter-spacing=\"0.6\" fill=\"#4a6a5c\">SQUISH\u00b7TV</text>")).S(string.Concat("<g transform=\"rotate(-38 3 3)\"><rect x=\"-4\" y=\"1.6\" width=\"13\" height=\"3.4\" fill=\"#b9bcc1\" opacity=\"0.92\"/><path d=\"M-4 2.2H9M-4 3.2H9M-4 4.2H9\" stroke=\"#8e9298\" stroke-width=\"0.15\"/></g>", "")).End()));
top_405 = ((V)(JsStrBuf.Begin().S(string.Concat("<path d=\"M3 4H", NumStr((TW_398 - 3D)), "M3 ", NumStr((TD_400 - 4D)), "H", NumStr((TW_398 - 3D)), "\" stroke=\"#000000\" stroke-opacity=\"0.1\" stroke-width=\"0.5\"/>")).V(Invoke(Call(rep_23, V.Undef, ((V)(6D)), Fn((V _arrowThis437, int _argc430, V i_436, V _a433, V _a434, V _a435, V[] _rest431) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_21, V.Undef, ((V)((20D + (ToNum(i_436) * 2.6)))))), "\" y=\"", NumStr((TD_400 - 9D)), "\" width=\"1.2\" height=\"6\" rx=\"0.6\" fill=\"#000000\" fill-opacity=\"0.22\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
side_406 = Invoke(Call(rep_23, V.Undef, ((V)(5D)), Fn((V _arrowThis445, int _argc438, V i_444, V _a441, V _a442, V _a443, V[] _rest439) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_21, V.Undef, ((V)((6D + (ToNum(i_444) * 3.6)))))), "\" y=\"20\" width=\"1.4\" height=\"8\" rx=\"0.7\" fill=\"#000000\" fill-opacity=\"0.22\"/>")));
}, 1, "", true)), "join", ((V)("")));
Set(D_403, "fx", Fn((V _arrowThis453, int _argc446, V ctx_452, V _a449, V _a450, V _a451, V[] _rest447) => {
V C_454 = default;
V L_455 = default;
V s_456 = default;
V ab_457 = default;
V tip1_458 = default;
V tip2_459 = default;
V ears_460 = default;
V ap_461 = default;
V tv_462 = default;
C_454 = Call(cam_16, V.Undef, ctx_452);
L_455 = Arr();
s_456 = Call(shadow_26, V.Undef, C_454, ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(18D)), ((V)(0.8)));
Call(rep_23, V.Undef, ((V)(3D)), Fn((V _arrowThis470, int _argc463, V i_469, V _a466, V _a467, V _a468, V[] _rest464) => {
double t_471 = 0;
double bx_472 = 0;
double bz_473 = 0;
double tx_474 = 0;
double tz_475 = 0;
t_471 = (((PI_15 / 2D) + (((ToNum(i_469) * 2D) * PI_15) / 3D)) + PI_15);
bx_472 = (FdLibm.Cos(t_471) * 17D);
bz_473 = (FdLibm.Sin(t_471) * 17D);
tx_474 = (FdLibm.Cos(t_471) * 11D);
tz_475 = (FdLibm.Sin(t_471) * 11D);
Invoke(L_455, "push", NewObj(2).Put("q", Arr(((V)(bx_472)), ((V)(10D)), ((V)(bz_473)))).Put("s", Add(Call(cyl3_37, V.Undef, C_454, Arr(((V)(bx_472)), ((V)(0D)), ((V)(bz_473))), Arr(((V)(tx_474)), ((V)((SY_401 - ST_402))), ((V)(tz_475))), ((V)(1.6)), ((V)("#b8834d")), NewObj(1).Put("r2", ((V)(2D))).V), Call(cyl3_37, V.Undef, C_454, Arr(((V)(bx_472)), ((V)((-0.1))), ((V)(bz_473))), Arr(((V)((bx_472 * 1.02))), ((V)(1.2)), ((V)((bz_473 * 1.02)))), ((V)(1.9)), ((V)("#3a3d44"))))).V);
return default;
}, 1, "", true));
Call(rep_23, V.Undef, ((V)(3D)), Fn((V _arrowThis483, int _argc476, V i_482, V _a479, V _a480, V _a481, V[] _rest477) => {
double t0_484 = 0;
double t1_485 = 0;
double r_486 = 0;
double y_487 = 0;
t0_484 = (((PI_15 / 2D) + (((ToNum(i_482) * 2D) * PI_15) / 3D)) + PI_15);
t1_485 = (t0_484 + ((2D * PI_15) / 3D));
r_486 = 14.6;
y_487 = 13D;
Invoke(L_455, "push", NewObj(2).Put("q", Arr(((V)((((FdLibm.Cos(t0_484) + FdLibm.Cos(t1_485)) * r_486) / 2D))), ((V)(y_487)), ((V)((((FdLibm.Sin(t0_484) + FdLibm.Sin(t1_485)) * r_486) / 2D))))).Put("s", Call(cyl3_37, V.Undef, C_454, Arr(((V)((FdLibm.Cos(t0_484) * r_486))), ((V)(y_487)), ((V)((FdLibm.Sin(t0_484) * r_486)))), Arr(((V)((FdLibm.Cos(t1_485) * r_486))), ((V)(y_487)), ((V)((FdLibm.Sin(t1_485) * r_486)))), ((V)(0.9)), ((V)("#a8743f")))).V);
return default;
}, 1, "", true));
s_456 = Add(s_456, Call(zsort_31, V.Undef, C_454, L_455));
s_456 = ((V)(JsStrBuf.Begin().V(s_456).V(Call(cyl3_37, V.Undef, C_454, Arr(((V)(0D)), ((V)((SY_401 - ST_402))), ((V)(0D))), Arr(((V)(0D)), ((V)(SY_401)), ((V)(0D))), ((V)(17D)), ((V)("#c99257")), NewObj(1).Put("r2", ((V)(17D))).V)).S(string.Concat("<g transform=\"", ToStr(Call(FR_17, V.Undef, C_454, Arr(((V)(0D)), ((V)((SY_401 + 0.03))), ((V)(0D))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><circle r=\"15.5\" fill=\"none\" stroke=\"#a8743f\" stroke-width=\"0.4\"/><circle r=\"10\" fill=\"none\" stroke=\"#a8743f\" stroke-width=\"0.3\" stroke-opacity=\"0.6\"/><path d=\"M-12 -3Q-2 -6 12 -2\" stroke=\"#e8b47a\" stroke-width=\"0.4\" fill=\"none\"/></g>")).End()));
ab_457 = Arr(((V)(5D)), ((V)((SY_401 + TH_399))), ((V)((-3D))));
tip1_458 = Arr(((V)((-14D))), ((V)(((SY_401 + TH_399) + 34D))), ((V)((-9D))));
tip2_459 = Arr(((V)(24D)), ((V)(((SY_401 + TH_399) + 30D))), ((V)((-6D))));
ears_460 = ((V)(JsStrBuf.Begin().V(Add(Add(Add(Add(Add(Add(Call(sph_29, V.Undef, C_454, ab_457, ((V)(4D)), ((V)("#33363d"))), Call(cyl3_37, V.Undef, C_454, ab_457, tip1_458, ((V)(0.5)), ((V)("#d9dde2")))), Call(cyl3_37, V.Undef, C_454, Arr(((V)((ToNum(Add(GetIdx(ab_457, 0D), GetIdx(tip1_458, 0D))) * 0.5))), ((V)((ToNum(Add(GetIdx(ab_457, 1D), GetIdx(tip1_458, 1D))) * 0.5))), ((V)((-6D)))), tip1_458, ((V)(0.35)), ((V)("#eef0f2")))), Call(sph_29, V.Undef, C_454, tip1_458, ((V)(1D)), ((V)("#c9ced3")))), Call(cyl3_37, V.Undef, C_454, ab_457, Arr(((V)(16D)), ((V)(((SY_401 + TH_399) + 18D))), ((V)((-4D)))), ((V)(0.5)), ((V)("#d9dde2")))), Call(cyl3_37, V.Undef, C_454, Arr(((V)(16D)), ((V)(((SY_401 + TH_399) + 18D))), ((V)((-4D)))), tip2_459, ((V)(0.4)), ((V)("#eef0f2")))), Call(sph_29, V.Undef, C_454, tip2_459, ((V)(2.8)), ((V)("#dfe3e8")), NewObj(0).V))).S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_24, V.Undef, Invoke(C_454, "p", GetIdx(tip2_459, 0D), GetIdx(tip2_459, 1D), GetIdx(tip2_459, 2D)))), ")\"><path d=\"M", ToStr(Call(f1_21, V.Undef, ((V)(((-1.6) * ToNum(Get(C_454, "k"))))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((-0.6) * ToNum(Get(C_454, "k"))))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((1.2 * ToNum(Get(C_454, "k"))))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((0.8 * ToNum(Get(C_454, "k"))))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((1.4 * ToNum(Get(C_454, "k"))))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((-1D) * ToNum(Get(C_454, "k"))))))), "\" stroke=\"#9aa0a6\" stroke-width=\"", ToStr(Call(f1_21, V.Undef, ((V)((0.3 * ToNum(Get(C_454, "k"))))))), "\" fill=\"none\"/></g>")).End()));
ap_461 = Invoke(C_454, "p", GetIdx(ab_457, 0D), GetIdx(ab_457, 1D), GetIdx(ab_457, 2D));
tv_462 = Call(box3_36, V.Undef, C_454, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(SY_401)), ((V)(0D)))).Put("w", ((V)(TW_398))).Put("h", ((V)(TH_399))).Put("d", ((V)(TD_400))).Put("r", ((V)(4D))).Put("col", TB_397).Put("dec", NewObj(4).Put("f", face_404).Put("t", top_405).Put("r", side_406).Put("l", side_406).V).V);
s_456 = ((V)(JsStrBuf.Begin().V(s_456).V(tv_462).S(string.Concat("<g>", ToStr(Call(at_19, V.Undef, ((V)("rotate")), ((V)(string.Concat("-1.6 ", ToStr(Call(P2_24, V.Undef, ap_461)), ";1.8 ", ToStr(Call(P2_24, V.Undef, ap_461)), ";-1.6 ", ToStr(Call(P2_24, V.Undef, ap_461))))), ((V)(4.2)), ((V)(0D)), Call(SPL_20, V.Undef, ((V)(2D))))), ToStr(ears_460), "</g>")).End()));
s_456 = Add(s_456, Call(curve_35, V.Undef, C_454, Arr(Arr(((V)(16D)), ((V)((SY_401 + 6D))), ((V)(((-TD_400) / 2D)))), Arr(((V)(24D)), ((V)((SY_401 - 10D))), ((V)((-20D)))), Arr(((V)(20D)), ((V)(4D)), ((V)((-24D)))), Arr(((V)(30D)), ((V)(0.3)), ((V)((-18D))))), ((V)("#2a2a2e")), ((V)(1.2))));
if (Truthy(mu_396)) {
s_456 = Add(s_456, Invoke(Call(rep_23, V.Undef, ((V)(3D)), Fn((V _arrowThis495, int _argc488, V i_494, V _a491, V _a492, V _a493, V[] _rest489) => {
return Call(note_42, V.Undef, C_454, ((V)((24D + (ToNum(i_494) * 3D)))), ((V)(((SY_401 + TH_399) + 4D))), ((V)(8D)), i_494, ((V)("#3a7a5c")));
}, 1, "", true)), "join", ((V)(""))));
}
Call(ext_30, V.Undef, C_454, Arr(Arr(((V)((ToNum(GetIdx(tip1_458, 0D)) - 4D))), Add(GetIdx(tip1_458, 1D), ((V)(4D))), GetIdx(tip1_458, 2D)), Arr(Add(GetIdx(tip2_459, 0D), ((V)(4D))), Add(GetIdx(tip2_459, 1D), ((V)(4D))), GetIdx(tip2_459, 2D))));
return NewObj(3).Put("defs", DEF18_40).Put("front", s_456).Put("bb", Invoke(C_454, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_403;
return default;
}, 1, "", true));
UID_51 = 0D;
artPic_52 = Fn((V _arrowThis505, int _argc496, V W_502, V Hh_503, V id_504, V _a501, V[] _rest497) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><clipPath id=\"", ToStr(id_504), "\"><rect width=\"", ToStr(Call(f1_21, V.Undef, W_502)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_503)), "\"/></clipPath></defs><g clip-path=\"url(#", ToStr(id_504), ")\"><g transform=\"scale(", ToStr(Call(n4_22, V.Undef, ((V)((ToNum(W_502) / 160D))))), " ", ToStr(Call(n4_22, V.Undef, ((V)((ToNum(Hh_503) / 90D))))), ")\">")).S(string.Concat("<rect width=\"160\" height=\"90\" fill=\"#f6ead3\"/><circle cx=\"104\" cy=\"36\" r=\"17\" fill=\"#f08a6a\"/><circle cx=\"104\" cy=\"36\" r=\"24\" fill=\"#f08a6a\" opacity=\"0.18\"/>", "")).S(string.Concat("<path d=\"M0 60Q34 38 72 54T160 48V90H0Z\" fill=\"#8fb39a\"/><path d=\"M0 70Q48 54 96 66T160 62V90H0Z\" fill=\"#3f7f78\"/><path d=\"M0 80Q60 70 120 78T160 76V90H0Z\" fill=\"#e3b24f\"/>", "")).S(string.Concat("<path d=\"M30 26l3 2 3 -2M44 20l2.4 1.6 2.4 -1.6M52 30l2 1.4 2 -1.4\" stroke=\"#5a4a3a\" stroke-width=\"0.9\" fill=\"none\" stroke-linecap=\"round\"/>", "")).V(Invoke(Call(rep_23, V.Undef, ((V)(16D)), Fn((V _arrowThis513, int _argc506, V i_512, V _a509, V _a510, V _a511, V[] _rest507) => {
return ((V)(string.Concat("<path d=\"M", NumStr(((ToNum(i_512) * 37D) % 160D)), " ", NumStr(((ToNum(i_512) * 23D) % 90D)), "l2 1\" stroke=\"#8a7050\" stroke-opacity=\"0.18\" stroke-width=\"0.4\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("</g><rect x=\"-60\" width=\"34\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_503)), "\" fill=\"url(#p15shn)\" opacity=\"0.28\" transform=\"skewX(-16)\">", ToStr(Call(an_18, V.Undef, ((V)("x")), ((V)(string.Concat("-60;", ToStr(Call(f1_21, V.Undef, Add(W_502, ((V)(80D)))))))), ((V)(11D)))), "</rect></g>")).End()));
}, 3, "", true);
Set(N_13, "frame18", Fn((V _arrowThis521, int _argc514, V S_520, V _a517, V _a518, V _a519, V[] _rest515) => {
V T_522 = default;
V on_523 = default;
double SW_524 = 0;
double SH_525 = 0;
double MT_526 = 0;
double FB_527 = 0;
double FW_528 = 0;
double FH_529 = 0;
double ZF_530 = 0;
V OAK_531 = default;
V D_532 = default;
T_522 = Call(tvState_45, V.Undef, S_520);
on_523 = Get(T_522, "on");
SW_524 = 120D;
SH_525 = 67.5;
MT_526 = 3.4;
FB_527 = 5.6;
FW_528 = (SW_524 + (2D * (MT_526 + FB_527)));
FH_529 = (SH_525 + (2D * (MT_526 + FB_527)));
ZF_530 = 3.6;
OAK_531 = ((V)("#d2a66c"));
D_532 = NewObj(7).Put("w", ((V)((FW_528 + 6D)))).Put("d", ((V)(8D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(40D))).Put("act", ((V)("watch"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(150D))).V).Put("build", Fn((V _arrowThis539, int _argc533, V _a535, V _a536, V _a537, V _a538, V[] _rest534) => {
return Arr(Call(scr_48, V.Undef, ((V)(0D)), ((V)((FB_527 + MT_526))), ((V)((ZF_530 + 0.3))), ((V)(SW_524)), ((V)(SH_525))));
}, 0, "build", true)).V;
Set(D_532, "fx", Fn((V _arrowThis547, int _argc540, V ctx_546, V _a543, V _a544, V _a545, V[] _rest541) => {
V C_548 = default;
V sid_549 = default;
JsStrBuf s_550 = null;
V pic_551 = default;
V f_552 = default;
V lp_553 = default;
C_548 = Call(cam_16, V.Undef, ctx_546);
sid_549 = Invoke(C_548, "u", ((V)("ar")));
s_550 = new JsStrBuf("");
s_550.V(Call(WD_32, V.Undef, C_548, ((V)((((-FW_528) / 2D) + 1.6))), ((V)((FH_529 - 3D))), ((V)(0.1)), ((V)(string.Concat("<rect width=\"", ToStr(Call(f1_21, V.Undef, ((V)((FW_528 + 4D))))), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)((FH_529 + 5D))))), "\" rx=\"2\" fill=\"#000000\" opacity=\"0.1\"/><rect x=\"1.6\" y=\"1.6\" width=\"", ToStr(Call(f1_21, V.Undef, ((V)(FW_528)))), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)((FH_529 + 1.6))))), "\" rx=\"1.4\" fill=\"#000000\" opacity=\"0.14\"/>"))), ((V)(FW_528)), ((V)(FH_529))));
pic_551 = Call(tvPic_46, V.Undef, NewObj(1).Put("u", Fn((V _arrowThis561, int _argc554, V q_560, V _a557, V _a558, V _a559, V[] _rest555) => {
return Add(Add(sid_549, q_560), ((V)(++UID_51)));
}, 1, "u", true)).V, ((V)(SW_524)), ((V)(SH_525)), ((V)("clean")), ((V)(0D)), T_522, Call(artPic_52, V.Undef, ((V)(SW_524)), ((V)(SH_525)), sid_549));
f_552 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect width=\"", ToStr(Call(f1_21, V.Undef, ((V)(FW_528)))), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)(FH_529)))), "\" fill=\"", ToStr(OAK_531), "\"/>")).V(Invoke(Call(rep_23, V.Undef, ((V)(7D)), Fn((V _arrowThis569, int _argc562, V i_568, V _a565, V _a566, V _a567, V[] _rest563) => {
return ((V)(string.Concat("<path d=\"M0 ", ToStr(Call(f1_21, V.Undef, ((V)((1D + (ToNum(i_568) * 0.7)))))), "H", ToStr(Call(f1_21, V.Undef, ((V)(FW_528)))), "\" stroke=\"#b5864e\" stroke-opacity=\"0.35\" stroke-width=\"0.25\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M0 0H", ToStr(Call(f1_21, V.Undef, ((V)(FW_528)))), "V", ToStr(Call(f1_21, V.Undef, ((V)(FH_529)))), "H0Z M", NumStr(FB_527), " ", NumStr(FB_527), "V", ToStr(Call(f1_21, V.Undef, ((V)((FH_529 - FB_527))))), "H", ToStr(Call(f1_21, V.Undef, ((V)((FW_528 - FB_527))))), "V", NumStr(FB_527), "Z\" fill=\"#000000\" fill-opacity=\"0\" stroke=\"#8a5e2e\" stroke-opacity=\"0.5\" stroke-width=\"0.4\"/>")).S(string.Concat("<path d=\"M", NumStr(FB_527), " ", NumStr(FB_527), "L", ToStr(Call(f1_21, V.Undef, ((V)((FB_527 - 1.2))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((FB_527 - 1.2))))), "M", ToStr(Call(f1_21, V.Undef, ((V)((FW_528 - FB_527))))), " ", NumStr(FB_527), "L", ToStr(Call(f1_21, V.Undef, ((V)(((FW_528 - FB_527) + 1.2))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((FB_527 - 1.2))))), "M", NumStr(FB_527), " ", ToStr(Call(f1_21, V.Undef, ((V)((FH_529 - FB_527))))), "L", ToStr(Call(f1_21, V.Undef, ((V)((FB_527 - 1.2))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((FH_529 - FB_527) + 1.2))))), "M", ToStr(Call(f1_21, V.Undef, ((V)((FW_528 - FB_527))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((FH_529 - FB_527))))), "L", ToStr(Call(f1_21, V.Undef, ((V)(((FW_528 - FB_527) + 1.2))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((FH_529 - FB_527) + 1.2))))), "\" stroke=\"#8a5e2e\" stroke-opacity=\"0.45\" stroke-width=\"0.3\"/>")).S(string.Concat("<rect x=\"", NumStr(FB_527), "\" y=\"", NumStr(FB_527), "\" width=\"", ToStr(Call(f1_21, V.Undef, ((V)((FW_528 - (2D * FB_527)))))), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)((FH_529 - (2D * FB_527)))))), "\" fill=\"#fbf7ee\"/><rect x=\"", NumStr(FB_527), "\" y=\"", NumStr(FB_527), "\" width=\"", ToStr(Call(f1_21, V.Undef, ((V)((FW_528 - (2D * FB_527)))))), "\" height=\"1.2\" fill=\"#000000\" opacity=\"0.08\"/><rect x=\"", NumStr(FB_527), "\" y=\"", NumStr(FB_527), "\" width=\"1\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)((FH_529 - (2D * FB_527)))))), "\" fill=\"#000000\" opacity=\"0.06\"/>")).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_21, V.Undef, ((V)((FB_527 + MT_526))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((FB_527 + MT_526))))), ")\">", ToStr(pic_551), "<rect width=\"", NumStr(SW_524), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)(SH_525)))), "\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.18\" stroke-width=\"0.4\"/></g>")).S(string.Concat("<path d=\"M", ToStr(Call(f1_21, V.Undef, ((V)((FW_528 - 2D))))), " 1H1V", ToStr(Call(f1_21, V.Undef, ((V)((FH_529 - 2D))))), "\" stroke=\"#ffffff\" stroke-opacity=\"0.35\" stroke-width=\"0.5\" fill=\"none\"/>")).End()));
s_550.V(Call(box3_36, V.Undef, C_548, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)((ZF_530 / 2D))))).Put("w", ((V)(FW_528))).Put("h", ((V)(FH_529))).Put("d", ((V)(ZF_530))).Put("r", ((V)(0.6))).Put("col", OAK_531).Put("dec", NewObj(2).Put("f", f_552).Put("t", Invoke(Call(rep_23, V.Undef, ((V)(5D)), Fn((V _arrowThis577, int _argc570, V i_576, V _a573, V _a574, V _a575, V[] _rest571) => {
return ((V)(string.Concat("<path d=\"M0 ", ToStr(Call(f1_21, V.Undef, ((V)((0.5 + (ToNum(i_576) * 0.6)))))), "H", ToStr(Call(f1_21, V.Undef, ((V)(FW_528)))), "\" stroke=\"#b5864e\" stroke-opacity=\"0.4\" stroke-width=\"0.2\"/>")));
}, 1, "", true)), "join", ((V)("")))).V).V));
lp_553 = Invoke(C_548, "p", ((V)(0D)), ((V)((-1.6))), ((V)(ZF_530)));
s_550.S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(lp_553, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(lp_553, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((0.6 * ToNum(Get(C_548, "k"))))))), "\" fill=\"", (Truthy(on_523) ? "#9dffb8" : "#fff4d6"), "\">", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)((Truthy(on_523) ? "1;1" : "0.35;0.9;0.35"))), ((V)(3.2)))), "</circle>"));
return NewObj(3).Put("defs", DEF18_40).Put("front", ((V)(s_550.Str))).Put("bb", Invoke(C_548, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_532;
return default;
}, 1, "", true));
Set(N_13, "console18", Fn((V _arrowThis585, int _argc578, V S_584, V _a581, V _a582, V _a583, V[] _rest579) => {
V T_586 = default;
V on_587 = default;
V nz_588 = default;
V WAL_589 = default;
double CW_590 = 0;
double CH_591 = 0;
double CD_592 = 0;
double LG_593 = 0;
double TY_594 = 0;
V CRM_595 = default;
double TW_596 = 0;
double TH_597 = 0;
double TD_598 = 0;
double PY_599 = 0;
V D_600 = default;
V grill_601 = default;
V front_602 = default;
V topD_603 = default;
V tvF_604 = default;
V tvS_605 = default;
T_586 = Call(tvState_45, V.Undef, S_584);
on_587 = (GtN(Get(T_586, "ch"), 0D) ? V.True : V.False);
nz_588 = (!(!(Truthy(Get(T_586, "nz")))) ? V.True : V.False);
WAL_589 = ((V)("#8b5a34"));
CW_590 = 152D;
CH_591 = 30D;
CD_592 = 34D;
LG_593 = 12D;
TY_594 = (LG_593 + CH_591);
CRM_595 = ((V)("#efe3c4"));
TW_596 = 64D;
TH_597 = 44D;
TD_598 = 26D;
PY_599 = (TY_594 + 2.6);
D_600 = NewObj(6).Put("w", ((V)((CW_590 + 4D)))).Put("d", ((V)((CD_592 + 6D)))).Put("act", ((V)("watch"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(110D))).V).Put("topH", ((V)(TY_594))).Put("build", Fn((V _arrowThis612, int _argc606, V _a608, V _a609, V _a610, V _a611, V[] _rest607) => {
return Arr(Call(scr_48, V.Undef, ((V)((-6D))), ((V)((PY_599 + 4.4))), ((V)(((TD_598 / 2D) + 0.3))), ((V)(46D)), ((V)(32D))));
}, 0, "build", true)).V;
grill_601 = Fn((V _arrowThis621, int _argc613, V x0_619, V w_620, V _a617, V _a618, V[] _rest614) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"", ToStr(x0_619), "\" y=\"3\" width=\"", ToStr(w_620), "\" height=\"", NumStr((CH_591 - 6D)), "\" rx=\"1.6\" fill=\"url(#q18cl)\"/><rect x=\"", ToStr(x0_619), "\" y=\"3\" width=\"", ToStr(w_620), "\" height=\"", NumStr((CH_591 - 6D)), "\" rx=\"1.6\" fill=\"none\" stroke=\"#5a3a1c\" stroke-width=\"0.6\"/>")).V(Invoke(Call(rep_23, V.Undef, ((V)(5D)), Fn((V _arrowThis629, int _argc622, V i_628, V _a625, V _a626, V _a627, V[] _rest623) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_21, V.Undef, Add(x0_619, ((V)(2D))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((6D + (ToNum(i_628) * 4.4)))))), "H", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(Add(x0_619, w_620)) - 2D))))), "\" stroke=\"#7a3d12\" stroke-opacity=\"0.35\" stroke-width=\"0.5\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
}, 2, "", true);
front_602 = ((V)(JsStrBuf.Begin().V(Add(Call(grill_601, V.Undef, ((V)(4D)), ((V)(42D))), Call(grill_601, V.Undef, ((V)((CW_590 - 46D))), ((V)(42D))))).S(string.Concat("<rect x=\"50\" y=\"3\" width=\"25\" height=\"", NumStr((CH_591 - 6D)), "\" rx=\"1\" fill=\"", ToStr(Call(shade_11, V.Undef, WAL_589, ((V)(1.08)))), "\" stroke=\"#5a3a1c\" stroke-width=\"0.4\"/><rect x=\"77\" y=\"3\" width=\"25\" height=\"", NumStr((CH_591 - 6D)), "\" rx=\"1\" fill=\"", ToStr(Call(shade_11, V.Undef, WAL_589, ((V)(1.08)))), "\" stroke=\"#5a3a1c\" stroke-width=\"0.4\"/>")).V(Invoke(Call(rep_23, V.Undef, ((V)(9D)), Fn((V _arrowThis637, int _argc630, V i_636, V _a633, V _a634, V _a635, V[] _rest631) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_21, V.Undef, ((V)((52D + (ToNum(i_636) * 2.6)))))), " 4.5V", NumStr((CH_591 - 4.5)), "M", ToStr(Call(f1_21, V.Undef, ((V)((79D + (ToNum(i_636) * 2.6)))))), " 4.5V", NumStr((CH_591 - 4.5)), "\" stroke=\"#5a3a1c\" stroke-opacity=\"0.35\" stroke-width=\"0.4\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<circle cx=\"73\" cy=\"15\" r=\"1.5\" fill=\"#d9b25a\" stroke=\"#8a6420\" stroke-width=\"0.4\"/><circle cx=\"79\" cy=\"15\" r=\"1.5\" fill=\"#d9b25a\" stroke=\"#8a6420\" stroke-width=\"0.4\"/>", "")).S(string.Concat("<path d=\"M2 ", NumStr((CH_591 - 1.4)), "H", NumStr((CW_590 - 2D)), "\" stroke=\"#d9b25a\" stroke-width=\"0.7\"/>")).End()));
topD_603 = Invoke(Call(rep_23, V.Undef, ((V)(6D)), Fn((V _arrowThis645, int _argc638, V i_644, V _a641, V _a642, V _a643, V[] _rest639) => {
return ((V)(string.Concat("<path d=\"M2 ", ToStr(Call(f1_21, V.Undef, ((V)((3D + (ToNum(i_644) * 5.4)))))), "Q", NumStr((CW_590 / 2D)), " ", ToStr(Call(f1_21, V.Undef, ((V)(((1D + (ToNum(i_644) * 5.4)) + ((ToNum(i_644) % 2D) * 2D)))))), " ", NumStr((CW_590 - 2D)), " ", ToStr(Call(f1_21, V.Undef, ((V)((3D + (ToNum(i_644) * 5.4)))))), "\" stroke=\"#5a3a1c\" stroke-opacity=\"0.25\" stroke-width=\"0.35\" fill=\"none\"/>")));
}, 1, "", true)), "join", ((V)("")));
tvF_604 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"2.4\" y=\"2.4\" width=\"", NumStr((TW_596 - 4.8)), "\" height=\"", NumStr((TH_597 - 4.8)), "\" rx=\"6\" fill=\"", ToStr(Call(shade_11, V.Undef, CRM_595, ((V)(0.94)))), "\"/><rect x=\"3.4\" y=\"3.4\" width=\"48\" height=\"34\" rx=\"7\" fill=\"#3a3226\"/>")).S(string.Concat("<g transform=\"translate(4.4 4.4)\">", ToStr(Call(tvPic_46, V.Undef, NewObj(1).Put("u", Fn((V _arrowThis653, int _argc646, V q_652, V _a649, V _a650, V _a651, V[] _rest647) => {
return ((V)(JsStrBuf.Begin().S("cv").V(q_652).N(++UID_51).End()));
}, 1, "u", true)).V, ((V)(46D)), ((V)(32D)), ((V)("vint")), ((V)(6D)), T_586, Call(glass_47, V.Undef, ((V)(46D)), ((V)(32D)), ((V)(6D)), ((V)("url(#q18crt)"))))), "</g>")).S(string.Concat("<rect x=\"53.4\" y=\"3.4\" width=\"8\" height=\"34\" rx=\"2\" fill=\"", ToStr(WAL_589), "\"/>")).V(Call(knob_49, V.Undef, ((V)(57.4)), ((V)(9D)), ((V)(2.6)))).V(Call(knob_49, V.Undef, ((V)(57.4)), ((V)(17D)), ((V)(2.1)))).V(Invoke(Call(rep_23, V.Undef, ((V)(6D)), Fn((V _arrowThis661, int _argc654, V i_660, V _a657, V _a658, V _a659, V[] _rest655) => {
return ((V)(string.Concat("<rect x=\"54.8\" y=\"", ToStr(Call(f1_21, V.Undef, ((V)((22.4 + (ToNum(i_660) * 1.9)))))), "\" width=\"5.2\" height=\"0.9\" rx=\"0.45\" fill=\"#3a2614\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<text x=\"27.4\" y=\"41.2\" text-anchor=\"middle\" font-size=\"2.3\" font-family=\"'Fredoka','Comic Sans MS',sans-serif\" font-weight=\"700\" letter-spacing=\"0.5\" fill=\"#8b5a34\">Squish-o-Vision</text>", "")).V(Call(led_50, V.Undef, ((V)(50.6)), ((V)(40.4)), on_587, ((V)("#ffb347")))).End()));
tvS_605 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect width=\"", NumStr(TD_598), "\" height=\"", NumStr(TH_597), "\" fill=\"", ToStr(WAL_589), "\"/>")).V(Invoke(Call(rep_23, V.Undef, ((V)(5D)), Fn((V _arrowThis669, int _argc662, V i_668, V _a665, V _a666, V _a667, V[] _rest663) => {
return ((V)(string.Concat("<path d=\"M0 ", ToStr(Call(f1_21, V.Undef, ((V)((4D + (ToNum(i_668) * 8D)))))), "Q", NumStr((TD_598 / 2D)), " ", ToStr(Call(f1_21, V.Undef, ((V)((2D + (ToNum(i_668) * 8D)))))), " ", NumStr(TD_598), " ", ToStr(Call(f1_21, V.Undef, ((V)((5D + (ToNum(i_668) * 8D)))))), "\" stroke=\"#5a3a1c\" stroke-opacity=\"0.35\" stroke-width=\"0.35\" fill=\"none\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
Set(D_600, "fx", Fn((V _arrowThis677, int _argc670, V ctx_676, V _a673, V _a674, V _a675, V[] _rest671) => {
V C_678 = default;
V L_679 = default;
V s_680 = default;
double tx_681 = 0;
double tz_682 = 0;
double ty_683 = 0;
V rec_684 = default;
V pv_685 = default;
V hd_686 = default;
double ax_687 = 0;
double az_688 = 0;
V vu_689 = default;
V a0_690 = default;
C_678 = Call(cam_16, V.Undef, ctx_676);
L_679 = Arr();
s_680 = Call(shadow_26, V.Undef, C_678, ((V)(0D)), ((V)(0D)), ((V)(((CW_590 / 2D) + 4D))), ((V)(((CD_592 / 2D) + 4D))), ((V)(0.75)));
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis702, int _argc691, V _a693, V _a694, V _a695, V _a696, V[] _rest692) => {
double x_703 = 0;
double z_704 = 0;
V sx_699 = default;
V sz_701 = default;
{ V _t697 = ListOf(_a693);
{ V _t698 = GetIdx(_t697, 0D);
sx_699 = _t698; }
{ V _t700 = GetIdx(_t697, 1D);
sz_701 = _t700; }
}
x_703 = (ToNum(sx_699) * ((CW_590 / 2D) - 8D));
z_704 = (ToNum(sz_701) * ((CD_592 / 2D) - 5D));
Invoke(L_679, "push", NewObj(2).Put("q", Arr(((V)(x_703)), ((V)(4D)), ((V)(z_704)))).Put("s", Add(Call(cyl3_37, V.Undef, C_678, Arr(((V)((x_703 + (ToNum(sx_699) * 3D)))), ((V)(0D)), ((V)((z_704 + (ToNum(sz_701) * 2D))))), Arr(((V)(x_703)), ((V)(LG_593)), ((V)(z_704))), ((V)(1.1)), WAL_589, NewObj(1).Put("r2", ((V)(2.2))).V), Call(cyl3_37, V.Undef, C_678, Arr(((V)((x_703 + (ToNum(sx_699) * 3D)))), ((V)(0D)), ((V)((z_704 + (ToNum(sz_701) * 2D))))), Arr(((V)((x_703 + (ToNum(sx_699) * 2.8)))), ((V)(1.8)), ((V)((z_704 + (ToNum(sz_701) * 1.9))))), ((V)(1.25)), ((V)("#d9b25a")), NewObj(1).Put("mat", ((V)("gloss"))).V))).V);
return default;
}, 1, "", true));
s_680 = Add(s_680, Call(zsort_31, V.Undef, C_678, L_679));
s_680 = Add(s_680, Call(box3_36, V.Undef, C_678, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(LG_593)), ((V)(0D)))).Put("w", ((V)(CW_590))).Put("h", ((V)(CH_591))).Put("d", ((V)(CD_592))).Put("r", ((V)(2D))).Put("col", WAL_589).Put("dec", NewObj(2).Put("f", front_602).Put("t", topD_603).V).V));
tx_681 = (-50D);
tz_682 = 1D;
ty_683 = (TY_594 + 4D);
s_680 = Add(s_680, Call(box3_36, V.Undef, C_678, NewObj(7).Put("c", Arr(((V)(tx_681)), ((V)(TY_594)), ((V)(tz_682)))).Put("w", ((V)(40D))).Put("h", ((V)(4D))).Put("d", ((V)(30D))).Put("r", ((V)(1.4))).Put("col", ((V)("#c79a64"))).Put("dec", NewObj(1).Put("f", ((V)(string.Concat("<circle cx=\"34\" cy=\"2\" r=\"0.8\" fill=\"", (Truthy(on_587) ? "#ff5a4a" : "#5a3a1c"), "\"/><text x=\"6\" y=\"2.8\" ", ToStr(FONT_25), " font-size=\"1.6\" fill=\"#5a3a1c\">33 \u00b7 45</text>")))).V).V));
s_680 = Add(s_680, Call(cyl3_37, V.Undef, C_678, Arr(((V)((tx_681 - 4D))), ((V)(ty_683)), ((V)(tz_682))), Arr(((V)((tx_681 - 4D))), ((V)((ty_683 + 1.3))), ((V)(tz_682))), ((V)(13D)), ((V)("#c9ced6")), NewObj(1).Put("mat", ((V)("gloss"))).V));
rec_684 = ((V)(JsStrBuf.Begin().S(string.Concat("<circle r=\"12\" fill=\"#17161a\"/>", "")).V(Invoke(Call(rep_23, V.Undef, ((V)(6D)), Fn((V _arrowThis712, int _argc705, V i_711, V _a708, V _a709, V _a710, V[] _rest706) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_21, V.Undef, ((V)((5.6 + (ToNum(i_711) * 1.05)))))), "\" fill=\"none\" stroke=\"#2c2b31\" stroke-width=\"0.35\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M-9 -6A11 11 0 0 1 -2 -11\" stroke=\"#ffffff\" stroke-opacity=\"0.22\" stroke-width=\"0.7\" fill=\"none\"/>", "")).S(string.Concat("<circle r=\"4.2\" fill=\"#e8504a\"/><path d=\"M-2.6 -0.6H2.6\" stroke=\"#ffffff\" stroke-width=\"0.6\"/><circle r=\"0.6\" fill=\"#d9dde2\"/>", "")).End()));
s_680 = ((V)(JsStrBuf.Begin().V(s_680).S(string.Concat("<g transform=\"", ToStr(Call(FR_17, V.Undef, C_678, Arr(((V)((tx_681 - 4D))), ((V)((ty_683 + 1.35))), ((V)(tz_682))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><g>", ToStr((Truthy(on_587) ? Call(at_19, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(1.8))) : ((V)("")))), ToStr(rec_684), "</g></g>")).End()));
pv_685 = Arr(((V)((tx_681 + 14D))), ((V)((ty_683 + 1.5))), ((V)((tz_682 - 10D))));
hd_686 = (Truthy(on_587) ? Arr(((V)((tx_681 - 1D))), ((V)((ty_683 + 2.4))), ((V)((tz_682 + 2D)))) : Arr(((V)((tx_681 + 15D))), ((V)((ty_683 + 2D))), ((V)((tz_682 + 8D)))));
s_680 = Add(s_680, Add(Add(Call(cyl3_37, V.Undef, C_678, Arr(GetIdx(pv_685, 0D), ((V)(ty_683)), GetIdx(pv_685, 2D)), pv_685, ((V)(1.6)), ((V)("#9aa0a6"))), Call(cyl3_37, V.Undef, C_678, pv_685, hd_686, ((V)(0.4)), ((V)("#e4e7ea")))), Call(box3_36, V.Undef, C_678, NewObj(6).Put("c", Arr(GetIdx(hd_686, 0D), ((V)((ToNum(GetIdx(hd_686, 1D)) - 1D))), GetIdx(hd_686, 2D))).Put("w", ((V)(2.2))).Put("h", ((V)(1.2))).Put("d", ((V)(3D))).Put("r", ((V)(0.3))).Put("col", ((V)("#3a3d44"))).V)));
ax_687 = 52D;
az_688 = (-1D);
vu_689 = Fn((V _arrowThis721, int _argc713, V x_719, V ph_720, V _a717, V _a718, V[] _rest714) => {
return ((V)(string.Concat("<rect x=\"", ToStr(x_719), "\" y=\"1.6\" width=\"9\" height=\"5\" rx=\"0.6\" fill=\"#f4e6c0\" stroke=\"#5a4a2a\" stroke-width=\"0.3\"/><path d=\"M", ToStr(Add(x_719, ((V)(1.2)))), " 5.6A3.6 3.6 0 0 1 ", ToStr(Add(x_719, ((V)(7.8)))), " 5.6\" stroke=\"#c0392b\" stroke-width=\"0.25\" fill=\"none\"/><g transform=\"translate(", ToStr(Add(x_719, ((V)(4.5)))), " 6.2)\"><path d=\"M0 0L0 -3.8\" stroke=\"#2a2a2a\" stroke-width=\"0.35\">", ToStr((Truthy(on_587) ? Call(at_19, V.Undef, ((V)("rotate")), ((V)("-40;30;-10;40;-30;-40")), ((V)(1.3)), ph_720, ((V)(""))) : ((V)("<animateTransform attributeName=\"transform\" type=\"rotate\" values=\"-42;-42\" dur=\"1s\"/>")))), "</path></g>")));
}, 2, "", true);
s_680 = Add(s_680, Call(box3_36, V.Undef, C_678, NewObj(7).Put("c", Arr(((V)(ax_687)), ((V)(TY_594)), ((V)(az_688)))).Put("w", ((V)(34D))).Put("h", ((V)(9D))).Put("d", ((V)(22D))).Put("r", ((V)(1.2))).Put("col", ((V)("#2f2a26"))).Put("dec", NewObj(1).Put("f", ((V)(JsStrBuf.Begin().V(Add(Add(Call(vu_689, V.Undef, ((V)(3D)), ((V)(0D))), Call(vu_689, V.Undef, ((V)(13D)), ((V)((-0.4))))), Call(knob_49, V.Undef, ((V)(27.5)), ((V)(4.5)), ((V)(2.2))))).S(string.Concat("<path d=\"M2 8.2H32\" stroke=\"#d9b25a\" stroke-width=\"0.4\"/>", "")).End()))).V).V));
Call(rep_23, V.Undef, ((V)(3D)), Fn((V _arrowThis729, int _argc722, V i_728, V _a725, V _a726, V _a727, V[] _rest723) => {
double x_730 = 0;
double z_731 = 0;
double y0_732 = 0;
V gp_733 = default;
x_730 = ((ax_687 - 9D) + (ToNum(i_728) * 9D));
z_731 = (az_688 - 4D);
y0_732 = (TY_594 + 9D);
gp_733 = Invoke(C_678, "p", ((V)(x_730)), ((V)((y0_732 + 4.4))), ((V)(z_731)));
s_680 = ((V)(JsStrBuf.Begin().V(s_680).V(Call(cyl3_37, V.Undef, C_678, Arr(((V)(x_730)), ((V)(y0_732)), ((V)(z_731))), Arr(((V)(x_730)), ((V)((y0_732 + 1.6))), ((V)(z_731))), ((V)(2.4)), ((V)("#1d1e22")))).S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(gp_733, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(gp_733, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((3.4 * ToNum(Get(C_678, "k"))))))), "\" fill=\"url(#q18glw)\" opacity=\"", NumStr((Truthy(on_587) ? 0.9 : 0.35)), "\">", ToStr((Truthy(on_587) ? Call(an_18, V.Undef, ((V)("opacity")), ((V)("0.7;1;0.8;0.95;0.7")), ((V)((1.1 + (ToNum(i_728) * 0.2))))) : ((V)("")))), "</circle>")).V(Call(cyl3_37, V.Undef, C_678, Arr(((V)(x_730)), ((V)((y0_732 + 1.6))), ((V)(z_731))), Arr(((V)(x_730)), ((V)((y0_732 + 8.4))), ((V)(z_731))), ((V)(2D)), ((V)("#fff1d6")), NewObj(1).Put("op", ((V)(0.55))).V)).V(Invoke(Call(sph_29, V.Undef, C_678, Arr(((V)(x_730)), ((V)((y0_732 + 8.4))), ((V)(z_731))), ((V)(2D)), ((V)("#fff1d6")), NewObj(0).V), "replace", ((V)("<circle")), ((V)("<circle opacity=\"0.55\"")))).End()));
return default;
}, 1, "", true));
s_680 = Add(s_680, Call(cyl3_37, V.Undef, C_678, Arr(((V)(0D)), ((V)(TY_594)), ((V)((-1D)))), Arr(((V)(0D)), ((V)(PY_599)), ((V)((-1D)))), ((V)(7D)), ((V)("#d9b25a")), NewObj(1).Put("mat", ((V)("gloss"))).V));
s_680 = Add(s_680, Call(box3_36, V.Undef, C_678, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(PY_599)), ((V)((-1D))))).Put("w", ((V)(TW_596))).Put("h", ((V)(TH_597))).Put("d", ((V)(TD_598))).Put("r", ((V)(7D))).Put("col", CRM_595).Put("dec", NewObj(4).Put("f", tvF_604).Put("r", tvS_605).Put("l", tvS_605).Put("t", ((V)(string.Concat("<path d=\"M8 6H", NumStr((TW_596 - 8D)), "\" stroke=\"#000000\" stroke-opacity=\"0.08\" stroke-width=\"0.6\"/>")))).V).V));
a0_690 = Arr(((V)(6D)), ((V)((PY_599 + TH_597))), ((V)((-4D))));
s_680 = Add(s_680, Add(Add(Add(Add(Call(sph_29, V.Undef, C_678, a0_690, ((V)(2.4)), ((V)("#d9b25a"))), Call(cyl3_37, V.Undef, C_678, a0_690, Arr(((V)((-10D))), ((V)(((PY_599 + TH_597) + 18D))), ((V)((-8D)))), ((V)(0.4)), ((V)("#e4e7ea")))), Call(cyl3_37, V.Undef, C_678, a0_690, Arr(((V)(20D)), ((V)(((PY_599 + TH_597) + 16D))), ((V)((-8D)))), ((V)(0.4)), ((V)("#e4e7ea")))), Call(sph_29, V.Undef, C_678, Arr(((V)((-10D))), ((V)(((PY_599 + TH_597) + 18D))), ((V)((-8D)))), ((V)(0.9)), ((V)("#d9b25a")))), Call(sph_29, V.Undef, C_678, Arr(((V)(20D)), ((V)(((PY_599 + TH_597) + 16D))), ((V)((-8D)))), ((V)(0.9)), ((V)("#d9b25a")))));
if (Truthy(on_587)) {
s_680 = Add(s_680, Invoke(Call(rep_23, V.Undef, ((V)(3D)), Fn((V _arrowThis741, int _argc734, V i_740, V _a737, V _a738, V _a739, V[] _rest735) => {
return Call(note_42, V.Undef, C_678, ((V)(((-60D) + (ToNum(i_740) * 7D)))), ((V)((TY_594 + 18D))), ((V)(6D)), i_740, ((V)("#8b4a1a")));
}, 1, "", true)), "join", ((V)(""))));
}
return NewObj(3).Put("defs", DEF18_40).Put("front", s_680).Put("bb", Invoke(C_678, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_600;
return default;
}, 1, "", true));
Set(N_13, "oled18", Fn((V _arrowThis749, int _argc742, V S_748, V _a745, V _a746, V _a747, V[] _rest743) => {
V T_750 = default;
V on_751 = default;
double CW_752 = 0;
double CH_753 = 0;
double CD_754 = 0;
double PH_755 = 0;
double TY_756 = 0;
double SW_757 = 0;
double SH_758 = 0;
double BZ_759 = 0;
double PW_760 = 0;
double PB_761 = 0;
double SZ_762 = 0;
V WAL_763 = default;
V GOLD_764 = default;
V D_765 = default;
V flutes_766 = default;
double pw_767 = 0;
V front_768 = default;
V topD_769 = default;
T_750 = Call(tvState_45, V.Undef, S_748);
on_751 = Get(T_750, "on");
CW_752 = 216D;
CH_753 = 30D;
CD_754 = 38D;
PH_755 = 4D;
TY_756 = (PH_755 + CH_753);
SW_757 = 200D;
SH_758 = 112.5;
BZ_759 = 1.3;
PW_760 = (SW_757 + (2D * BZ_759));
PB_761 = (TY_756 - 1.2);
SZ_762 = (-10D);
WAL_763 = ((V)("#3e2b22"));
GOLD_764 = ((V)("#d4af5a"));
D_765 = NewObj(5).Put("w", ((V)((CW_752 + 4D)))).Put("d", ((V)((CD_754 + 6D)))).Put("act", ((V)("watch"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(150D))).V).Put("build", Fn((V _arrowThis776, int _argc770, V _a772, V _a773, V _a774, V _a775, V[] _rest771) => {
return Arr(Call(scr_48, V.Undef, ((V)(0D)), ((V)((PB_761 + BZ_759))), ((V)((SZ_762 + 1D))), ((V)(SW_757)), ((V)(SH_758))));
}, 0, "build", true)).V;
flutes_766 = Fn((V _arrowThis785, int _argc777, V x0_783, V w_784, V _a781, V _a782, V[] _rest778) => {
return ((V)(string.Concat("<rect x=\"", ToStr(x0_783), "\" y=\"2\" width=\"", ToStr(w_784), "\" height=\"", NumStr((CH_753 - 5D)), "\" fill=\"url(#q18fl)\"/><rect x=\"", ToStr(x0_783), "\" y=\"2\" width=\"", ToStr(w_784), "\" height=\"", NumStr((CH_753 - 5D)), "\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.35\" stroke-width=\"0.4\"/>")));
}, 2, "", true);
pw_767 = ((CW_752 - 10D) / 4D);
front_768 = ((V)(JsStrBuf.Begin().V(Add(Add(Invoke(Call(rep_23, V.Undef, ((V)(4D)), Fn((V _arrowThis793, int _argc786, V i_792, V _a789, V _a790, V _a791, V[] _rest787) => {
return Call(flutes_766, V.Undef, ((V)((2D + (ToNum(i_792) * (pw_767 + 2D))))), ((V)(pw_767)));
}, 1, "", true)), "join", ((V)(""))), Invoke(Call(rep_23, V.Undef, ((V)(3D)), Fn((V _arrowThis801, int _argc794, V i_800, V _a797, V _a798, V _a799, V[] _rest795) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_21, V.Undef, ((V)(((1D + (ToNum(Add(i_800, ((V)(1D)))) * (pw_767 + 2D))) - 0.4))))), "\" y=\"1\" width=\"1.2\" height=\"", NumStr((CH_753 - 2.6)), "\" fill=\"", ToStr(GOLD_764), "\"/>")));
}, 1, "", true)), "join", ((V)("")))), Invoke(Invoke(Arr(((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis809, int _argc802, V i_808, V _a805, V _a806, V _a807, V[] _rest803) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_21, V.Undef, ((V)(((ToNum(i_808) * (pw_767 + 2D)) - 1.6))))), "\" y=\"10\" width=\"0.9\" height=\"8\" rx=\"0.45\" fill=\"", ToStr(GOLD_764), "\"/><rect x=\"", ToStr(Call(f1_21, V.Undef, ((V)(((ToNum(i_808) * (pw_767 + 2D)) + 2.5))))), "\" y=\"10\" width=\"0.9\" height=\"8\" rx=\"0.45\" fill=\"", ToStr(GOLD_764), "\"/>")));
}, 1, "", true)), "join", ((V)(""))))).S(string.Concat("<path d=\"M0 0.6H", NumStr(CW_752), "\" stroke=\"", ToStr(GOLD_764), "\" stroke-width=\"0.8\"/>")).S(string.Concat("<circle cx=\"", NumStr((CW_752 / 2D)), "\" cy=\"", NumStr((CH_753 - 1.6)), "\" r=\"0.55\" fill=\"", (Truthy(on_751) ? "#9dffb8" : "#ffffff"), "\">", ToStr((Truthy(on_751) ? ((V)("")) : Call(an_18, V.Undef, ((V)("opacity")), ((V)("0.25;0.9;0.25")), ((V)(3.4))))), "</circle>")).End()));
topD_769 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"", ToStr(Call(f1_21, V.Undef, ((V)((((CW_752 - PW_760) / 2D) - 1.6))))), "\" y=\"", ToStr(Call(f1_21, V.Undef, ((V)((((CD_754 / 2D) + SZ_762) - 2.2))))), "\" width=\"", ToStr(Call(f1_21, V.Undef, ((V)((PW_760 + 3.2))))), "\" height=\"4.4\" rx=\"1.4\" fill=\"#0d0b0a\"/><path d=\"M", ToStr(Call(f1_21, V.Undef, ((V)((((CW_752 - PW_760) / 2D) - 1.6))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((((CD_754 / 2D) + SZ_762) + 2.2))))), "H", ToStr(Call(f1_21, V.Undef, ((V)((((CW_752 + PW_760) / 2D) + 1.6))))), "\" stroke=\"", ToStr(GOLD_764), "\" stroke-width=\"0.5\"/>")).V(Invoke(Call(rep_23, V.Undef, ((V)(6D)), Fn((V _arrowThis817, int _argc810, V i_816, V _a813, V _a814, V _a815, V[] _rest811) => {
return ((V)(string.Concat("<path d=\"M2 ", ToStr(Call(f1_21, V.Undef, ((V)((4D + (ToNum(i_816) * 5.6)))))), "Q", NumStr((CW_752 / 2D)), " ", ToStr(Call(f1_21, V.Undef, ((V)((2D + (ToNum(i_816) * 5.6)))))), " ", NumStr((CW_752 - 2D)), " ", ToStr(Call(f1_21, V.Undef, ((V)((4D + (ToNum(i_816) * 5.6)))))), "\" stroke=\"#000000\" stroke-opacity=\"0.2\" stroke-width=\"0.35\" fill=\"none\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
Set(D_765, "fx", Fn((V _arrowThis825, int _argc818, V ctx_824, V _a821, V _a822, V _a823, V[] _rest819) => {
V C_826 = default;
V k_827 = default;
V s_828 = default;
V panel_829 = default;
V scrS_830 = default;
C_826 = Call(cam_16, V.Undef, ctx_824);
k_827 = Get(C_826, "k");
s_828 = Call(shadow_26, V.Undef, C_826, ((V)(0D)), ((V)(0D)), ((V)(((CW_752 / 2D) + 6D))), ((V)(((CD_754 / 2D) + 6D))), ((V)(0.8)));
if (Truthy(on_751)) {
s_828 = ((V)(JsStrBuf.Begin().V(s_828).S(string.Concat("<g opacity=\"0.55\">", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("0.4;0.65;0.4")), ((V)(4D)))), ToStr(Call(WD_32, V.Undef, C_826, ((V)((((-PW_760) / 2D) - 24D))), ((V)(((PB_761 + SH_758) + 30D))), ((V)((SZ_762 - 6D))), ((V)(string.Concat("<rect width=\"", ToStr(Call(f1_21, V.Undef, ((V)((PW_760 + 48D))))), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)((SH_758 + 40D))))), "\" rx=\"30\" fill=\"url(#q18cy)\"/>"))))), "</g>")).End()));
}
panel_829 = ((V)(string.Concat(string.Concat("<rect width=\"", ToStr(Call(f1_21, V.Undef, ((V)(PW_760)))), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)((SH_758 + (2D * BZ_759)))))), "\" rx=\"0.8\" fill=\"#08080b\"/><g transform=\"translate(", NumStr(BZ_759), " ", NumStr(BZ_759), ")\">", ToStr((Truthy(Get(T_750, "on")) ? Call(tvPic_46, V.Undef, NewObj(1).Put("u", Fn((V _arrowThis838, int _argc831, V q_837, V _a834, V _a835, V _a836, V[] _rest832) => {
return ((V)(JsStrBuf.Begin().S("ol").V(q_837).N(++UID_51).End()));
}, 1, "u", true)).V, ((V)(SW_757)), ((V)(SH_758)), ((V)("clean")), ((V)(0.4)), T_750, ((V)(""))) : Call(glass_47, V.Undef, ((V)(SW_757)), ((V)(SH_758)), ((V)(0.4))))), "</g>"), (Truthy(on_751) ? "" : string.Concat("<rect x=\"-60\" y=\"", NumStr(BZ_759), "\" width=\"40\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)(SH_758)))), "\" fill=\"url(#p15shn)\" opacity=\"0.12\" transform=\"skewX(-14)\">", ToStr(Call(an_18, V.Undef, ((V)("x")), ((V)(string.Concat("-60;", ToStr(Call(f1_21, V.Undef, ((V)((PW_760 + 80D)))))))), ((V)(10D)))), "</rect>")), string.Concat("<rect x=\"0.25\" y=\"0.25\" width=\"", ToStr(Call(f1_21, V.Undef, ((V)((PW_760 - 0.5))))), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)(((SH_758 + (2D * BZ_759)) - 0.5))))), "\" rx=\"0.8\" fill=\"none\" stroke=\"", ToStr(GOLD_764), "\" stroke-width=\"0.5\" stroke-opacity=\"0.85\"/>"))));
scrS_830 = Call(box3_36, V.Undef, C_826, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(PB_761)), ((V)(SZ_762)))).Put("w", ((V)(PW_760))).Put("h", ((V)((SH_758 + (2D * BZ_759))))).Put("d", ((V)(1.6))).Put("r", ((V)(0.3))).Put("col", ((V)("#141418"))).Put("dec", NewObj(2).Put("f", panel_829).Put("t", ((V)(string.Concat("<path d=\"M0 0.5H", ToStr(Call(f1_21, V.Undef, ((V)(PW_760)))), "\" stroke=\"", ToStr(GOLD_764), "\" stroke-width=\"0.6\"/>")))).V).V);
if (Truthy((on_751 is var _t840 && !Truthy(_t840) ? _t840 : ((SEqN(Get(T_750, "ch"), 1D) ? V.True : V.False) is var _t839 && Truthy(_t839) ? _t839 : Get(T_750, "nz"))))) {
V a_841 = default;
V b_842 = default;
V cid_843 = default;
double up_844 = 0;
a_841 = Invoke(C_826, "p", ((V)((((-CW_752) / 2D) - 4D))), ((V)(TY_756)), ((V)(SZ_762)));
b_842 = Invoke(C_826, "p", ((V)(((CW_752 / 2D) + 4D))), ((V)(TY_756)), ((V)(SZ_762)));
cid_843 = Invoke(C_826, "u", ((V)("rc")));
up_844 = 400D;
s_828 = ((V)(JsStrBuf.Begin().V(s_828).S(string.Concat("<defs><clipPath id=\"", ToStr(cid_843), "\"><path d=\"M", ToStr(Call(P2_24, V.Undef, a_841)), "L", ToStr(Call(P2_24, V.Undef, b_842)), "L", ToStr(Call(f1_21, V.Undef, GetIdx(b_842, 0D))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(b_842, 1D)) - up_844))))), "L", ToStr(Call(f1_21, V.Undef, GetIdx(a_841, 0D))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(a_841, 1D)) - up_844))))), "Z\"/></clipPath></defs><g clip-path=\"url(#", ToStr(cid_843), ")\"><g>", ToStr(Call(ONCE_41, V.Undef, ((V)(string.Concat("0 ", ToStr(Call(f1_21, V.Undef, ((V)(((SH_758 + 4D) * ToNum(k_827)))))), ";0 0"))), ((V)(2.2)))), ToStr(scrS_830), "</g></g>")).End()));
} else {
s_828 = Add(s_828, scrS_830);
}
s_828 = Add(s_828, Call(box3_36, V.Undef, C_826, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("w", ((V)((CW_752 - 8D)))).Put("h", ((V)(PH_755))).Put("d", ((V)((CD_754 - 6D)))).Put("r", ((V)(1D))).Put("col", GOLD_764).Put("dec", NewObj(0).V).V));
s_828 = Add(s_828, Call(box3_36, V.Undef, C_826, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(PH_755)), ((V)(0D)))).Put("w", ((V)(CW_752))).Put("h", ((V)(CH_753))).Put("d", ((V)(CD_754))).Put("r", ((V)(2D))).Put("col", WAL_763).Put("dec", NewObj(2).Put("f", front_768).Put("t", topD_769).V).V));
return NewObj(3).Put("defs", DEF18_40).Put("front", s_828).Put("bb", Invoke(C_826, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_765;
return default;
}, 1, "", true));
mascot_53 = Fn((V _arrowThis854, int _argc845, V W_851, V Hh_852, V id_853, V _a850, V[] _rest846) => {
double cx_855 = 0;
double by_856 = 0;
double sc_857 = 0;
cx_855 = (ToNum(W_851) / 2D);
by_856 = (ToNum(Hh_852) * 0.86);
sc_857 = (ToNum(Hh_852) / 70D);
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><clipPath id=\"", ToStr(id_853), "\"><rect width=\"", ToStr(Call(f1_21, V.Undef, W_851)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_852)), "\"/></clipPath></defs><g clip-path=\"url(#", ToStr(id_853), ")\"><rect width=\"", ToStr(Call(f1_21, V.Undef, W_851)), "\" height=\"", ToStr(Call(f1_21, V.Undef, Hh_852)), "\" fill=\"#0a2a3a\" opacity=\"0.35\"/>")).V(Invoke(Call(rep_23, V.Undef, ((V)(9D)), Fn((V _arrowThis865, int _argc858, V i_864, V _a861, V _a862, V _a863, V[] _rest859) => {
return ((V)(string.Concat("<path d=\"M0 ", ToStr(Call(f1_21, V.Undef, ((V)(((ToNum(Hh_852) * ToNum(Add(i_864, ((V)(1D))))) / 10D))))), "H", ToStr(Call(f1_21, V.Undef, W_851)), "\" stroke=\"#8ff6ff\" stroke-opacity=\"0.12\" stroke-width=\"0.4\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_21, V.Undef, ((V)(cx_855)))), " ", ToStr(Call(f1_21, V.Undef, ((V)(by_856)))), ") scale(", ToStr(Call(n4_22, V.Undef, ((V)(sc_857)))), ")\"><ellipse rx=\"22\" ry=\"4\" fill=\"none\" stroke=\"#8ff6ff\" stroke-width=\"0.8\" opacity=\"0.7\">", ToStr(Call(an_18, V.Undef, ((V)("rx")), ((V)("18;24;18")), ((V)(2D)))), "</ellipse>")).S(string.Concat("<g>", ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)("0 0;0 -6;0 0")), ((V)(1.2)), ((V)(0D)), Call(SPL_20, V.Undef, ((V)(2D))))), "<g>", ToStr(Call(at_19, V.Undef, ((V)("rotate")), ((V)("-8;8;-8")), ((V)(2.4)), ((V)(0D)), Call(SPL_20, V.Undef, ((V)(2D))))), "<path d=\"M-16 0Q-18 -34 0 -34Q18 -34 16 0Z\" fill=\"#8ff6ff\" fill-opacity=\"0.45\" stroke=\"#c9fbff\" stroke-width=\"1\"/>")).S(string.Concat("<path d=\"M-10 -30Q-14 -42 -6 -40Q-5 -34 -5 -32Z M10 -30Q14 -42 6 -40Q5 -34 5 -32Z\" fill=\"#8ff6ff\" fill-opacity=\"0.45\" stroke=\"#c9fbff\" stroke-width=\"0.8\"/>", "")).S(string.Concat("<g>", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("1;1;0;1;1")), ((V)(3D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.9;0.93;0.96;1\"")))), "<ellipse cx=\"-6\" cy=\"-18\" rx=\"2\" ry=\"3\" fill=\"#0a3a4a\"/><ellipse cx=\"6\" cy=\"-18\" rx=\"2\" ry=\"3\" fill=\"#0a3a4a\"/></g><path d=\"M-5 -9Q0 -4 5 -9\" stroke=\"#0a3a4a\" stroke-width=\"1.4\" fill=\"none\" stroke-linecap=\"round\"/>")).S(string.Concat("<g transform=\"translate(15 -16)\"><g>", ToStr(Call(at_19, V.Undef, ((V)("rotate")), ((V)("10;-60;10")), ((V)(0.8)))), "<ellipse cy=\"-5\" rx=\"3\" ry=\"6\" fill=\"#8ff6ff\" fill-opacity=\"0.45\" stroke=\"#c9fbff\" stroke-width=\"0.8\"/></g></g></g></g>")).S(string.Concat("<text x=\"0\" y=\"-48\" text-anchor=\"middle\" font-size=\"7\" ", ToStr(FONT_25), " fill=\"#c9fbff\" opacity=\"0.8\">HELLO!", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("0;0.9;0.9;0")), ((V)(3D)))), "</text></g>")).S(string.Concat("<rect y=\"-6\" width=\"", ToStr(Call(f1_21, V.Undef, W_851)), "\" height=\"4\" fill=\"#bffaff\" opacity=\"0.25\">", ToStr(Call(an_18, V.Undef, ((V)("y")), ((V)(string.Concat("-6;", ToStr(Call(f1_21, V.Undef, Add(Hh_852, ((V)(4D)))))))), ((V)(3D)))), "</rect></g>")).End()));
return default;
}, 3, "", true);
Set(N_13, "holo18", Fn((V _arrowThis873, int _argc866, V S_872, V _a869, V _a870, V _a871, V[] _rest867) => {
V T_874 = default;
V on_875 = default;
V mu_876 = default;
double PR_877 = 0;
double PHt_878 = 0;
double SW_879 = 0;
double SH_880 = 0;
double Y0_881 = 0;
double FINR_882 = 0;
V D_883 = default;
T_874 = Call(tvState_45, V.Undef, S_872);
on_875 = Get(T_874, "on");
mu_876 = (GtN(Get(T_874, "ch"), 0D) ? V.True : V.False);
PR_877 = 64D;
PHt_878 = 7D;
SW_879 = 208D;
SH_880 = 117D;
Y0_881 = 30D;
FINR_882 = 82D;
D_883 = NewObj(5).Put("w", ((V)((Max(SW_879, (FINR_882 * 2D)) + 10D)))).Put("d", ((V)(((PR_877 * 2D) + 10D)))).Put("act", ((V)("watch"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(170D))).V).Put("build", Fn((V _arrowThis890, int _argc884, V _a886, V _a887, V _a888, V _a889, V[] _rest885) => {
return Arr(Call(scr_48, V.Undef, ((V)(0D)), ((V)(Y0_881)), ((V)(1D)), ((V)(SW_879)), ((V)(SH_880))));
}, 0, "build", true)).V;
Set(D_883, "fx", Fn((V _arrowThis898, int _argc891, V ctx_897, V _a894, V _a895, V _a896, V[] _rest892) => {
V C_899 = default;
V k_900 = default;
V L_901 = default;
V s_902 = default;
V e0_903 = default;
V e1_904 = default;
V b0_905 = default;
V b1_906 = default;
V sid_907 = default;
V pic_908 = default;
V o0_909 = default;
V scrG_910 = default;
C_899 = Call(cam_16, V.Undef, ctx_897);
k_900 = Get(C_899, "k");
L_901 = Arr();
s_902 = Call(shadow_26, V.Undef, C_899, ((V)(0D)), ((V)(0D)), ((V)((PR_877 + 12D))), ((V)((PR_877 + 8D))), ((V)(0.7)));
Call(rep_23, V.Undef, ((V)(13D)), Fn((V _arrowThis918, int _argc911, V i_917, V _a914, V _a915, V _a916, V[] _rest912) => {
double t_919 = 0;
double x_920 = 0;
double z_921 = 0;
double h_922 = 0;
double yaw_923 = 0;
V tip_924 = default;
t_919 = (PI_15 * (1.04 + ((0.92 * ToNum(i_917)) / 12D)));
x_920 = (FdLibm.Cos(t_919) * FINR_882);
z_921 = (((FdLibm.Sin(t_919) * FINR_882) * 0.62) - 6D);
h_922 = ((70D + (70D * Pow(FdLibm.Sin(((PI_15 * ToNum(Add(i_917, ((V)(0.5))))) / 13D)), 1.3))) + ((ToNum(i_917) % 2D) * 8D));
yaw_923 = (-(t_919 + (PI_15 / 2D)));
tip_924 = ((V)(string.Concat("<rect x=\"0\" y=\"0\" width=\"4\" height=\"1.6\" fill=\"#8ff6ff\">", ToStr((Truthy(on_875) ? Call(an_18, V.Undef, ((V)("opacity")), ((V)("0.4;1;0.4")), ((V)((0.48 * (1D + ((ToNum(i_917) % 3D) * 0.5))))), ((V)(((-ToNum(i_917)) * 0.11)))) : Call(an_18, V.Undef, ((V)("opacity")), ((V)("0.5;0.9;0.5")), ((V)(3D)), ((V)(((-ToNum(i_917)) * 0.2)))))), "</rect>")));
Invoke(L_901, "push", NewObj(2).Put("q", Arr(((V)(x_920)), ((V)((h_922 / 2D))), ((V)(z_921)))).Put("s", Call(box3_36, V.Undef, C_899, NewObj(8).Put("c", Arr(((V)(x_920)), ((V)(0D)), ((V)(z_921)))).Put("ax", Call(yawA_28, V.Undef, ((V)(yaw_923)))).Put("w", ((V)(5D))).Put("h", ((V)(h_922))).Put("d", ((V)(11D))).Put("r", ((V)(0.8))).Put("col", ((V)((NumTruthy((ToNum(i_917) % 2D)) ? "#8b5a34" : "#a06a3e")))).Put("dec", NewObj(2).Put("f", tip_924).Put("l", Invoke(Call(rep_23, V.Undef, ((V)(4D)), Fn((V _arrowThis932, int _argc925, V j_931, V _a928, V _a929, V _a930, V[] _rest926) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_21, V.Undef, ((V)((1D + (ToNum(j_931) * 2.6)))))), " 2V", ToStr(Call(f1_21, V.Undef, ((V)((h_922 - 2D))))), "\" stroke=\"#5a3a1c\" stroke-opacity=\"0.3\" stroke-width=\"0.35\"/>")));
}, 1, "", true)), "join", ((V)("")))).V).V)).V);
return default;
}, 1, "", true));
s_902 = Add(s_902, Call(zsort_31, V.Undef, C_899, L_901));
s_902 = Add(s_902, Call(cyl3_37, V.Undef, C_899, Arr(((V)(0D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(PHt_878)), ((V)(0D))), ((V)(PR_877)), ((V)("#1f2129")), NewObj(1).Put("mat", ((V)("gloss"))).V));
s_902 = ((V)(JsStrBuf.Begin().V(s_902).S(string.Concat("<g transform=\"", ToStr(Call(FR_17, V.Undef, C_899, Arr(((V)(0D)), ((V)((PHt_878 + 0.04))), ((V)(0D))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><circle r=\"", NumStr((PR_877 - 3D)), "\" fill=\"#15161c\"/><circle r=\"", NumStr((PR_877 - 6D)), "\" fill=\"none\" stroke=\"#3fd0ff\" stroke-width=\"1.2\" stroke-dasharray=\"3 5\">", ToStr(Call(an_18, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-32")), ((V)((Truthy(on_875) ? 1.2 : 4D))))), "</circle>")).S(string.Concat("<circle r=\"", NumStr((PR_877 - 12D)), "\" fill=\"none\" stroke=\"#8ff6ff\" stroke-width=\"0.6\" stroke-opacity=\"0.6\"/><circle r=\"20\" fill=\"url(#q18cy)\">", ToStr(Call(an_18, V.Undef, ((V)("r")), ((V)("18;24;18")), ((V)((Truthy(on_875) ? 0.96 : 3D))))), "</circle><circle r=\"9\" fill=\"#0c3a4a\" stroke=\"#8ff6ff\" stroke-width=\"0.8\"/><circle r=\"4\" fill=\"#dffcff\"/></g>")).End()));
e0_903 = Invoke(C_899, "p", ((V)((-12D))), ((V)(PHt_878)), ((V)(0D)));
e1_904 = Invoke(C_899, "p", ((V)(12D)), ((V)(PHt_878)), ((V)(0D)));
b0_905 = Invoke(C_899, "p", ((V)(((-SW_879) / 2D))), ((V)(Y0_881)), ((V)(0D)));
b1_906 = Invoke(C_899, "p", ((V)((SW_879 / 2D))), ((V)(Y0_881)), ((V)(0D)));
s_902 = ((V)(JsStrBuf.Begin().V(s_902).S(string.Concat("<path d=\"M", ToStr(Call(P2_24, V.Undef, e0_903)), "L", ToStr(Call(P2_24, V.Undef, b0_905)), "L", ToStr(Call(P2_24, V.Undef, b1_906)), "L", ToStr(Call(P2_24, V.Undef, e1_904)), "Z\" fill=\"url(#q18bm)\">", ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.7;0.9;0.6")), ((V)(2.6)))), "</path>")).End()));
sid_907 = Invoke(C_899, "u", ((V)("hm")));
pic_908 = Call(tvPic_46, V.Undef, NewObj(1).Put("u", Fn((V _arrowThis940, int _argc933, V q_939, V _a936, V _a937, V _a938, V[] _rest934) => {
return ((V)(JsStrBuf.Begin().S("hs").V(q_939).N(++UID_51).End()));
}, 1, "u", true)).V, ((V)(SW_879)), ((V)(SH_880)), ((V)("holo")), ((V)(1D)), T_874, Call(mascot_53, V.Undef, ((V)(SW_879)), ((V)(SH_880)), sid_907));
o0_909 = Invoke(C_899, "p", ((V)(((-SW_879) / 2D))), ((V)((Y0_881 + SH_880))), ((V)(0D)));
scrG_910 = ((V)(string.Concat(string.Concat("<g transform=\"", ToStr(Call(FR_17, V.Undef, C_899, Arr(((V)(((-SW_879) / 2D))), ((V)((Y0_881 + SH_880))), ((V)(0D))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", NumStr(SW_879), "\" height=\"", NumStr(SH_880), "\" rx=\"1.4\" fill=\"#06202c\" opacity=\"0.55\"/>", ToStr(pic_908)), string.Concat("<rect width=\"", NumStr(SW_879), "\" height=\"", NumStr(SH_880), "\" rx=\"1.4\" fill=\"none\" stroke=\"#8ff6ff\" stroke-width=\"1.2\">", ToStr(Call(an_18, V.Undef, ((V)("stroke-opacity")), ((V)("0.5;1;0.5")), ((V)(2.2)))), "</rect><path d=\"M0 8V0H8M", NumStr((SW_879 - 8D)), " 0H", NumStr(SW_879), "V8M0 ", NumStr((SH_880 - 8D)), "V", NumStr(SH_880), "H8M", NumStr((SW_879 - 8D)), " ", NumStr(SH_880), "H", NumStr(SW_879), "V", NumStr((SH_880 - 8D)), "\" stroke=\"#dffcff\" stroke-width=\"1.6\" fill=\"none\"/></g>"))));
s_902 = ((V)(JsStrBuf.Begin().V(s_902).S(string.Concat("<g>", ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 ", ToStr(Call(f1_21, V.Undef, ((V)(((-2D) * ToNum(k_900)))))), ";0 0"))), ((V)(3.6)), ((V)(0D)), Call(SPL_20, V.Undef, ((V)(2D))))), ToStr(scrG_910), "</g>")).End()));
Call(ext_30, V.Undef, C_899, Arr(Arr(((V)(((-SW_879) / 2D))), ((V)(((Y0_881 + SH_880) + 3D))), ((V)(0D))), Arr(((V)((SW_879 / 2D))), ((V)(((Y0_881 + SH_880) + 3D))), ((V)(0D)))));
s_902 = Add(s_902, Invoke(Call(rep_23, V.Undef, ((V)(10D)), Fn((V _arrowThis948, int _argc941, V i_947, V _a944, V _a945, V _a946, V[] _rest942) => {
double x_949 = 0;
V p_950 = default;
double d_951 = 0;
x_949 = (((-SW_879) / 2D) + ((SW_879 * ToNum(Add(i_947, ((V)(0.5))))) / 10D));
p_950 = Invoke(C_899, "p", ((V)(x_949)), ((V)(((Y0_881 + SH_880) + 1D))), ((V)(0D)));
d_951 = (2.8 + (((ToNum(i_947) * 7D) % 5D) * 0.5));
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_21, V.Undef, ((V)((0.8 * ToNum(k_900)))))), "\" fill=\"#dffcff\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0.95;0\" dur=\"", ToStr(Call(n4_22, V.Undef, ((V)(d_951)))), "s\" begin=\"", ToStr(Call(n4_22, V.Undef, ((V)(((-ToNum(i_947)) * 0.41))))), "s\" repeatCount=\"indefinite\"/><animateMotion dur=\"", ToStr(Call(n4_22, V.Undef, ((V)(d_951)))), "s\" begin=\"", ToStr(Call(n4_22, V.Undef, ((V)(((-ToNum(i_947)) * 0.41))))), "s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(P2_24, V.Undef, p_950)), "l", ToStr(Call(f1_21, V.Undef, ((V)(((((ToNum(i_947) % 3D) - 1D) * 2D) * ToNum(k_900)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((-16D) * ToNum(k_900)))))), "\"/></circle>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
if (Truthy(mu_876)) {
s_902 = Add(s_902, Invoke(Call(rep_23, V.Undef, ((V)(4D)), Fn((V _arrowThis959, int _argc952, V i_958, V _a955, V _a956, V _a957, V[] _rest953) => {
return Call(note_42, V.Undef, C_899, ((V)(((((-SW_879) / 2D) + 20D) + (ToNum(i_958) * 54D)))), ((V)(((Y0_881 + SH_880) + 6D))), ((V)(0D)), i_958, ((V)("#3fd0ff")));
}, 1, "", true)), "join", ((V)(""))));
}
_ = o0_909;
return NewObj(3).Put("defs", DEF18_40).Put("front", s_902).Put("bb", Invoke(C_899, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_883;
return default;
}, 1, "", true));
notes_54 = Fn((V _arrowThis970, int _argc960, V C_966, V on_967, V P_968, V col_969, V[] _rest961) => {
return (Truthy(on_967) ? Invoke(Invoke(P_968, "map", Fn((V _arrowThis979, int _argc971, V q_977, V i_978, V _a975, V _a976, V[] _rest972) => {
return Call(note_42, V.Undef, C_966, GetIdx(q_977, 0D), GetIdx(q_977, 1D), GetIdx(q_977, 2D), i_978, col_969);
}, 2, "", true)), "join", ((V)(""))) : ((V)("")));
}, 4, "", true);
waves_55 = Fn((V _arrowThis990, int _argc980, V C_986, V on_987, V P_988, V col_989, V[] _rest981) => {
return (Truthy(on_987) ? Invoke(Invoke(P_988, "map", Fn((V _arrowThis1007, int _argc991, V _a993, V j_997, V _a995, V _a996, V[] _rest992) => {
V q_1008 = default;
V k_1009 = default;
V x_1000 = default;
V y_1002 = default;
V z_1004 = default;
V r0_1006 = default;
{ V _t998 = ListOf(_a993);
{ V _t999 = GetIdx(_t998, 0D);
x_1000 = _t999; }
{ V _t1001 = GetIdx(_t998, 1D);
y_1002 = _t1001; }
{ V _t1003 = GetIdx(_t998, 2D);
z_1004 = _t1003; }
{ V _t1005 = GetIdx(_t998, 3D);
r0_1006 = _t1005; }
}
q_1008 = Invoke(C_986, "p", x_1000, y_1002, z_1004);
k_1009 = Get(C_986, "k");
Call(ext_30, V.Undef, C_986, Arr(Arr(((V)(((ToNum(x_1000) - ToNum(r0_1006)) - 14D))), y_1002, z_1004), Arr(Add(Add(x_1000, r0_1006), ((V)(14D))), y_1002, z_1004)));
return Invoke(Call(rep_23, V.Undef, ((V)(3D)), Fn((V _arrowThis1017, int _argc1010, V i_1016, V _a1013, V _a1014, V _a1015, V[] _rest1011) => {
V b_1018 = default;
b_1018 = Call(n4_22, V.Undef, ((V)((((-ToNum(i_1016)) * 0.5) - (ToNum(j_997) * 0.17)))));
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_1008, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_1008, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(r0_1006) * ToNum(k_1009)))))), "\" fill=\"none\" stroke=\"", ToStr(col_989), "\" stroke-width=\"", ToStr(Call(f1_21, V.Undef, ((V)((1.1 * ToNum(k_1009)))))), "\" opacity=\"0\">", ToStr(Call(an_18, V.Undef, ((V)("r")), ((V)(JsStrBuf.Begin().V(Call(f1_21, V.Undef, ((V)((ToNum(r0_1006) * ToNum(k_1009)))))).S(";").V(Call(f1_21, V.Undef, ((V)((ToNum(Add(r0_1006, ((V)(13D)))) * ToNum(k_1009)))))).End())), ((V)(1.5)), b_1018)), ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("0.85;0")), ((V)(1.5)), b_1018)), ToStr(Call(an_18, V.Undef, ((V)("stroke-width")), ((V)(JsStrBuf.Begin().V(Call(f1_21, V.Undef, ((V)((1.3 * ToNum(k_1009)))))).S(";").V(Call(f1_21, V.Undef, ((V)((0.3 * ToNum(k_1009)))))).End())), ((V)(1.5)), b_1018)), "</circle>")));
return default;
}, 1, "", true)), "join", ((V)("")));
return default;
}, 2, "", true)), "join", ((V)(""))) : ((V)("")));
}, 4, "", true);
Set(N_13, "spkJunk18", Fn((V _arrowThis1026, int _argc1019, V S_1025, V _a1022, V _a1023, V _a1024, V[] _rest1020) => {
V on_1027 = default;
V D_1028 = default;
on_1027 = Call(isPlay_27, V.Undef, S_1025);
D_1028 = NewObj(4).Put("w", ((V)(52D))).Put("d", ((V)(20D))).Put("zs", ((V)(1.3))).Put("build", Fn((V _arrowThis1035, int _argc1029, V _a1031, V _a1032, V _a1033, V _a1034, V[] _rest1030) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1028, "fx", Fn((V _arrowThis1043, int _argc1036, V ctx_1042, V _a1039, V _a1040, V _a1041, V[] _rest1037) => {
V C_1044 = default;
V L_1045 = default;
V brick_1046 = default;
V wood_1047 = default;
V plas_1048 = default;
V s_1049 = default;
C_1044 = Call(cam_16, V.Undef, ctx_1042);
L_1045 = Arr();
brick_1046 = Fn((V _arrowThis1058, int _argc1050, V x_1056, V yaw_1057, V _a1054, V _a1055, V[] _rest1051) => {
return Call(box3_36, V.Undef, C_1044, NewObj(8).Put("c", Arr(x_1056, ((V)(0D)), ((V)(0D)))).Put("ax", Call(yawA_28, V.Undef, yaw_1057)).Put("w", ((V)(18D))).Put("h", ((V)(6D))).Put("d", ((V)(10D))).Put("r", ((V)(0.4))).Put("col", ((V)("#b5523b"))).Put("dec", NewObj(2).Put("f", ((V)(string.Concat("<path d=\"M0 3H18M9 0V3M4.5 3V6M13.5 3V6\" stroke=\"#7a2e1e\" stroke-width=\"0.4\"/>", "")))).Put("t", ((V)(string.Concat("<rect x=\"3\" y=\"3\" width=\"3.4\" height=\"4\" rx=\"0.6\" fill=\"#7a2e1e\"/><rect x=\"7.3\" y=\"3\" width=\"3.4\" height=\"4\" rx=\"0.6\" fill=\"#7a2e1e\"/><rect x=\"11.6\" y=\"3\" width=\"3.4\" height=\"4\" rx=\"0.6\" fill=\"#7a2e1e\"/>", "")))).V).V);
}, 2, "", true);
wood_1047 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"1.2\" y=\"1.2\" width=\"13.6\" height=\"20.6\" rx=\"1\" fill=\"url(#q18gr)\"/>", "")).V(Call(cone_34, V.Undef, ((V)(8D)), ((V)(7D)), ((V)(3D)), on_1027, ((V)(0.1)))).V(Call(cone_34, V.Undef, ((V)(8D)), ((V)(15.4)), ((V)(4.6)), on_1027, ((V)(0D)))).S(string.Concat("<circle cx=\"13\" cy=\"20.4\" r=\"0.5\" fill=\"", (Truthy(on_1027) ? "#5dff7a" : "#553311"), "\"/>")).End()));
plas_1048 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"1\" y=\"1\" width=\"12\" height=\"16\" rx=\"1.4\" fill=\"#26272b\"/>", "")).V(Call(cone_34, V.Undef, ((V)(7D)), ((V)(5.4)), ((V)(2.6)), on_1027, ((V)(0.2)))).V(Call(cone_34, V.Undef, ((V)(7D)), ((V)(12D)), ((V)(3.6)), on_1027, ((V)(0.15)))).S(string.Concat("<path d=\"M12.6 1.4L10 4.4L11.6 5.4L9.4 8\" stroke=\"#e9e9ee\" stroke-width=\"0.35\" fill=\"none\"/><g transform=\"rotate(35 3 14)\"><rect x=\"-1\" y=\"12.8\" width=\"9\" height=\"2.6\" fill=\"#b9bcc1\" opacity=\"0.95\"/></g><g transform=\"rotate(-35 3 14)\"><rect x=\"-1\" y=\"12.8\" width=\"9\" height=\"2.6\" fill=\"#b9bcc1\" opacity=\"0.95\"/></g>", "")).End()));
Invoke(L_1045, "push", NewObj(2).Put("q", Arr(((V)((-15D))), ((V)(6D)), ((V)(0D)))).Put("s", Add(Add(Call(shadow_26, V.Undef, C_1044, ((V)((-15D))), ((V)(0D)), ((V)(11D)), ((V)(8D)), ((V)(0.8))), Call(brick_1046, V.Undef, ((V)((-15D))), ((V)(0.1)))), Call(box3_36, V.Undef, C_1044, NewObj(8).Put("c", Arr(((V)((-15D))), ((V)(6D)), ((V)(0D)))).Put("ax", Call(yawA_28, V.Undef, ((V)(0.24)))).Put("w", ((V)(16D))).Put("h", ((V)(23D))).Put("d", ((V)(13D))).Put("r", ((V)(1D))).Put("col", ((V)("#b07a45"))).Put("dec", NewObj(2).Put("f", wood_1047).Put("t", ((V)(string.Concat("<path d=\"M2 6H14\" stroke=\"#7a4e25\" stroke-width=\"0.3\"/>", "")))).V).V))).V);
Invoke(L_1045, "push", NewObj(2).Put("q", Arr(((V)(15D)), ((V)(6D)), ((V)(1D)))).Put("s", ((V)(JsStrBuf.Begin().V(Add(Call(shadow_26, V.Undef, C_1044, ((V)(15D)), ((V)(1D)), ((V)(10D)), ((V)(8D)), ((V)(0.8))), Call(brick_1046, V.Undef, ((V)(15D)), ((V)((-0.12)))))).S(string.Concat("<g>", ToStr((Truthy(on_1027) ? ((V)("")) : Call(at_19, V.Undef, ((V)("translate")), ((V)("0 0;0 0;0.3 0;-0.3 0;0 0;0 0")), ((V)(3.2)), ((V)(0D)), ((V)(" keyTimes=\"0;0.6;0.64;0.68;0.72;1\""))))), ToStr(Call(box3_36, V.Undef, C_1044, NewObj(8).Put("c", Arr(((V)(15D)), ((V)(6D)), ((V)(1D)))).Put("ax", Call(yawA_28, V.Undef, ((V)((-0.26))))).Put("w", ((V)(14D))).Put("h", ((V)(18D))).Put("d", ((V)(12D))).Put("r", ((V)(1.4))).Put("col", ((V)("#2f3035"))).Put("dec", NewObj(1).Put("f", plas_1048).V).V)), "</g>")).End()))).V);
s_1049 = Add(Add(Add(Call(curve_35, V.Undef, C_1044, Arr(Arr(((V)((-9D))), ((V)(12D)), ((V)((-6D)))), Arr(((V)((-4D))), ((V)(0.3)), ((V)((-12D)))), Arr(((V)(6D)), ((V)(0.3)), ((V)((-12D)))), Arr(((V)(10D)), ((V)(10D)), ((V)((-5D))))), ((V)("#d9c2a0")), ((V)(0.9))), Call(zsort_31, V.Undef, C_1044, L_1045)), Call(waves_55, V.Undef, C_1044, on_1027, Arr(Arr(((V)((-15D))), ((V)(13.6)), ((V)(7D)), ((V)(4.6))), Arr(((V)(15D)), ((V)(12D)), ((V)(8D)), ((V)(3.6)))), ((V)("#ffffff")))), Call(notes_54, V.Undef, C_1044, on_1027, Arr(Arr(((V)((-15D))), ((V)(34D)), ((V)(4D))), Arr(((V)(14D)), ((V)(30D)), ((V)(4D))), Arr(((V)(0D)), ((V)(36D)), ((V)(6D)))), ((V)("#8a4a1a"))));
Call(ext_30, V.Undef, C_1044, Arr(Arr(((V)(0D)), ((V)(44D)), ((V)(0D)))));
return NewObj(3).Put("defs", DEF18_40).Put("front", s_1049).Put("bb", Invoke(C_1044, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1028;
return default;
}, 1, "", true));
Set(N_13, "spkShelf18", Fn((V _arrowThis1066, int _argc1059, V S_1065, V _a1062, V _a1063, V _a1064, V[] _rest1060) => {
V on_1067 = default;
V D_1068 = default;
on_1067 = Call(isPlay_27, V.Undef, S_1065);
D_1068 = NewObj(3).Put("w", ((V)(64D))).Put("d", ((V)(22D))).Put("build", Fn((V _arrowThis1075, int _argc1069, V _a1071, V _a1072, V _a1073, V _a1074, V[] _rest1070) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1068, "fx", Fn((V _arrowThis1083, int _argc1076, V ctx_1082, V _a1079, V _a1080, V _a1081, V[] _rest1077) => {
V C_1084 = default;
V L_1085 = default;
V s_1086 = default;
C_1084 = Call(cam_16, V.Undef, ctx_1082);
L_1085 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1094, int _argc1087, V sg_1093, V _a1090, V _a1091, V _a1092, V[] _rest1088) => {
double x_1095 = 0;
double yaw_1096 = 0;
double SY_1097 = 0;
V f_1098 = default;
x_1095 = (ToNum(sg_1093) * 22D);
yaw_1096 = ((-ToNum(sg_1093)) * 0.2);
SY_1097 = 30D;
f_1098 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"0.8\" y=\"0.8\" width=\"13.4\" height=\"21.4\" rx=\"1.2\" fill=\"#d6ad78\"/>", "")).V(Invoke(Call(rep_23, V.Undef, ((V)(4D)), Fn((V _arrowThis1106, int _argc1099, V i_1105, V _a1102, V _a1103, V _a1104, V[] _rest1100) => {
return ((V)(string.Concat("<path d=\"M1 ", ToStr(Call(f1_21, V.Undef, ((V)((3D + (ToNum(i_1105) * 5D)))))), "Q7 ", ToStr(Call(f1_21, V.Undef, ((V)((2D + (ToNum(i_1105) * 5D)))))), " 14 ", ToStr(Call(f1_21, V.Undef, ((V)((3.4 + (ToNum(i_1105) * 5D)))))), "\" stroke=\"#b5864e\" stroke-opacity=\"0.45\" stroke-width=\"0.3\" fill=\"none\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Call(cone_34, V.Undef, ((V)(7.5)), ((V)(5.4)), ((V)(2.4)), on_1067, ((V)((GtN(sg_1093, 0D) ? 0.2 : 0D))))).V(Call(cone_34, V.Undef, ((V)(7.5)), ((V)(14.4)), ((V)(5D)), on_1067, ((V)((GtN(sg_1093, 0D) ? 0.1 : 0D))))).V((LtN(sg_1093, 0D) ? Call(led_50, V.Undef, ((V)(12.6)), ((V)(20.6)), (true ? V.True : V.False), ((V)((Truthy(on_1067) ? "#5ab8ff" : "#ffffff")))) : ((V)("")))).End()));
Invoke(L_1085, "push", NewObj(2).Put("q", Arr(((V)(x_1095)), ((V)(15D)), ((V)(0D)))).Put("s", Add(Add(Add(Add(Call(shadow_26, V.Undef, C_1084, ((V)(x_1095)), ((V)(0D)), ((V)(9D)), ((V)(8D)), ((V)(0.8))), Call(box3_36, V.Undef, C_1084, NewObj(7).Put("c", Arr(((V)(x_1095)), ((V)(0D)), ((V)(0D)))).Put("ax", Call(yawA_28, V.Undef, ((V)(yaw_1096)))).Put("w", ((V)(14D))).Put("h", ((V)(1.6))).Put("d", ((V)(14D))).Put("r", ((V)(1D))).Put("col", ((V)("#2a2b30"))).V)), Call(cyl3_37, V.Undef, C_1084, Arr(((V)(x_1095)), ((V)(1.6)), ((V)(0D))), Arr(((V)(x_1095)), ((V)((SY_1097 - 1.4))), ((V)(0D))), ((V)(1.5)), ((V)("#2a2b30")))), Call(box3_36, V.Undef, C_1084, NewObj(7).Put("c", Arr(((V)(x_1095)), ((V)((SY_1097 - 1.4))), ((V)(0D)))).Put("ax", Call(yawA_28, V.Undef, ((V)(yaw_1096)))).Put("w", ((V)(12D))).Put("h", ((V)(1.4))).Put("d", ((V)(12D))).Put("r", ((V)(0.8))).Put("col", ((V)("#2a2b30"))).V)), Call(box3_36, V.Undef, C_1084, NewObj(8).Put("c", Arr(((V)(x_1095)), ((V)(SY_1097)), ((V)(0D)))).Put("ax", Call(yawA_28, V.Undef, ((V)(yaw_1096)))).Put("w", ((V)(15D))).Put("h", ((V)(23D))).Put("d", ((V)(15D))).Put("r", ((V)(1.6))).Put("col", ((V)("#f4f1ea"))).Put("dec", NewObj(2).Put("f", f_1098).Put("t", ((V)(string.Concat("<circle cx=\"7.5\" cy=\"10\" r=\"0.6\" fill=\"#c9c2b0\"/>", "")))).V).V))).V);
return default;
}, 1, "", true));
s_1086 = Add(Add(Add(Call(zsort_31, V.Undef, C_1084, L_1085), Call(curve_35, V.Undef, C_1084, Arr(Arr(((V)((-20D))), ((V)(2D)), ((V)((-6D)))), Arr(((V)((-8D))), ((V)(0.3)), ((V)((-10D)))), Arr(((V)(8D)), ((V)(0.3)), ((V)((-10D)))), Arr(((V)(20D)), ((V)(2D)), ((V)((-6D))))), ((V)("#3a3b40")), ((V)(0.7)))), Call(waves_55, V.Undef, C_1084, on_1067, Arr(Arr(((V)((-22D))), ((V)(38.6)), ((V)(8D)), ((V)(5D))), Arr(((V)(22D)), ((V)(38.6)), ((V)(8D)), ((V)(5D)))), ((V)("#7ab8ff")))), Call(notes_54, V.Undef, C_1084, on_1067, Arr(Arr(((V)((-22D))), ((V)(60D)), ((V)(4D))), Arr(((V)(22D)), ((V)(58D)), ((V)(4D))), Arr(((V)(0D)), ((V)(62D)), ((V)(4D)))), ((V)("#3f7fc8"))));
Call(ext_30, V.Undef, C_1084, Arr(Arr(((V)(0D)), ((V)(66D)), ((V)(0D)))));
return NewObj(3).Put("defs", DEF18_40).Put("front", s_1086).Put("bb", Invoke(C_1084, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1068;
return default;
}, 1, "", true));
Set(N_13, "spkTower18", Fn((V _arrowThis1114, int _argc1107, V S_1113, V _a1110, V _a1111, V _a1112, V[] _rest1108) => {
V on_1115 = default;
V WAL_1116 = default;
V D_1117 = default;
on_1115 = Call(isPlay_27, V.Undef, S_1113);
WAL_1116 = ((V)("#8b5a34"));
D_1117 = NewObj(3).Put("w", ((V)(68D))).Put("d", ((V)(26D))).Put("build", Fn((V _arrowThis1124, int _argc1118, V _a1120, V _a1121, V _a1122, V _a1123, V[] _rest1119) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1117, "fx", Fn((V _arrowThis1132, int _argc1125, V ctx_1131, V _a1128, V _a1129, V _a1130, V[] _rest1126) => {
V C_1133 = default;
V L_1134 = default;
V s_1135 = default;
C_1133 = Call(cam_16, V.Undef, ctx_1131);
L_1134 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1143, int _argc1136, V sg_1142, V _a1139, V _a1140, V _a1141, V[] _rest1137) => {
double x_1144 = 0;
double yaw_1145 = 0;
double LY_1146 = 0;
double TH_1147 = 0;
double ph_1148 = 0;
V f_1149 = default;
V g_1150 = default;
x_1144 = (ToNum(sg_1142) * 24D);
yaw_1145 = ((-ToNum(sg_1142)) * 0.18);
LY_1146 = 7D;
TH_1147 = 92D;
ph_1148 = (GtN(sg_1142, 0D) ? 0.12 : 0D);
f_1149 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"1.4\" y=\"1.4\" width=\"17.2\" height=\"", NumStr((TH_1147 - 2.8)), "\" rx=\"1.6\" fill=\"", ToStr(Call(shade_11, V.Undef, WAL_1116, ((V)(0.82)))), "\"/><rect x=\"2.6\" y=\"2.6\" width=\"14.8\" height=\"30\" rx=\"1.4\" fill=\"url(#q18cl)\"/><rect x=\"2.6\" y=\"2.6\" width=\"14.8\" height=\"30\" rx=\"1.4\" fill=\"none\" stroke=\"#5a3a1c\" stroke-width=\"0.4\"/>")).S(string.Concat("<circle cx=\"10\" cy=\"39\" r=\"2.6\" fill=\"none\" stroke=\"#d9b25a\" stroke-width=\"0.6\"/>", "")).V(Call(cone_34, V.Undef, ((V)(10D)), ((V)(39D)), ((V)(2.2)), on_1115, ((V)(ph_1148)))).V(Invoke(Invoke(Arr(((V)(51D)), ((V)(64D)), ((V)(77D))), "map", Fn((V _arrowThis1159, int _argc1151, V y_1157, V j_1158, V _a1155, V _a1156, V[] _rest1152) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<circle cx=\"10\" cy=\"", ToStr(y_1157), "\" r=\"5.6\" fill=\"none\" stroke=\"#d9b25a\" stroke-width=\"0.7\"/>")).V(Call(cone_34, V.Undef, ((V)(10D)), y_1157, ((V)(5D)), on_1115, ((V)((ph_1148 + (0.05 * ToNum(Add(j_1158, ((V)(1D)))))))))).End()));
}, 2, "", true)), "join", ((V)("")))).S(string.Concat("<text x=\"10\" y=\"", NumStr((TH_1147 - 2.6)), "\" text-anchor=\"middle\" font-size=\"1.5\" ", ToStr(FONT_25), " fill=\"#d9b25a\">SQUISH</text>")).End()));
g_1150 = Call(shadow_26, V.Undef, C_1133, ((V)(x_1144)), ((V)(0D)), ((V)(12D)), ((V)(10D)), ((V)(0.8)));
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis1171, int _argc1160, V _a1162, V _a1163, V _a1164, V _a1165, V[] _rest1161) => {
V a_1168 = default;
V b_1170 = default;
{ V _t1166 = ListOf(_a1162);
{ V _t1167 = GetIdx(_t1166, 0D);
a_1168 = _t1167; }
{ V _t1169 = GetIdx(_t1166, 1D);
b_1170 = _t1169; }
}
g_1150 = Add(g_1150, Call(cyl3_37, V.Undef, C_1133, Arr(((V)((x_1144 + (ToNum(a_1168) * 7.4)))), ((V)(0D)), ((V)((ToNum(b_1170) * 6.4)))), Arr(((V)((x_1144 + (ToNum(a_1168) * 6D)))), ((V)(LY_1146)), ((V)((ToNum(b_1170) * 5.4)))), ((V)(0.8)), WAL_1116, NewObj(1).Put("r2", ((V)(1.4))).V));
return default;
}, 1, "", true));
g_1150 = Add(g_1150, Call(box3_36, V.Undef, C_1133, NewObj(8).Put("c", Arr(((V)(x_1144)), ((V)(LY_1146)), ((V)(0D)))).Put("ax", Call(yawA_28, V.Undef, ((V)(yaw_1145)))).Put("w", ((V)(20D))).Put("h", ((V)(TH_1147))).Put("d", ((V)(20D))).Put("r", ((V)(2.2))).Put("col", WAL_1116).Put("dec", NewObj(3).Put("f", f_1149).Put("t", ((V)(string.Concat("<path d=\"M2 4H18M2 16H18\" stroke=\"#5a3a1c\" stroke-opacity=\"0.3\" stroke-width=\"0.3\"/>", "")))).Put("r", Invoke(Call(rep_23, V.Undef, ((V)(5D)), Fn((V _arrowThis1179, int _argc1172, V i_1178, V _a1175, V _a1176, V _a1177, V[] _rest1173) => {
return ((V)(string.Concat("<path d=\"M0 ", ToStr(Call(f1_21, V.Undef, ((V)((8D + (ToNum(i_1178) * 12D)))))), "Q10 ", ToStr(Call(f1_21, V.Undef, ((V)((6D + (ToNum(i_1178) * 12D)))))), " 20 ", ToStr(Call(f1_21, V.Undef, ((V)((9D + (ToNum(i_1178) * 12D)))))), "\" stroke=\"#5a3a1c\" stroke-opacity=\"0.3\" stroke-width=\"0.35\" fill=\"none\"/>")));
}, 1, "", true)), "join", ((V)("")))).V).V));
Invoke(L_1134, "push", NewObj(2).Put("q", Arr(((V)(x_1144)), ((V)(30D)), ((V)(0D)))).Put("s", g_1150).V);
return default;
}, 1, "", true));
s_1135 = Add(Add(Call(zsort_31, V.Undef, C_1133, L_1134), Call(waves_55, V.Undef, C_1133, on_1115, Arr(Arr(((V)((-24D))), ((V)(35D)), ((V)(11D)), ((V)(5D))), Arr(((V)(24D)), ((V)(35D)), ((V)(11D)), ((V)(5D))), Arr(((V)((-24D))), ((V)(61D)), ((V)(11D)), ((V)(5D))), Arr(((V)(24D)), ((V)(61D)), ((V)(11D)), ((V)(5D)))), ((V)("#ffd28a")))), Call(notes_54, V.Undef, C_1133, on_1115, Arr(Arr(((V)((-24D))), ((V)(108D)), ((V)(4D))), Arr(((V)(24D)), ((V)(106D)), ((V)(4D))), Arr(((V)(0D)), ((V)(110D)), ((V)(4D)))), ((V)("#8b4a1a"))));
Call(ext_30, V.Undef, C_1133, Arr(Arr(((V)(0D)), ((V)(114D)), ((V)(0D)))));
return NewObj(3).Put("defs", DEF18_40).Put("front", s_1135).Put("bb", Invoke(C_1133, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1117;
return default;
}, 1, "", true));
Set(N_13, "spkPiano18", Fn((V _arrowThis1187, int _argc1180, V S_1186, V _a1183, V _a1184, V _a1185, V[] _rest1181) => {
V on_1188 = default;
V GOLD_1189 = default;
V BK_1190 = default;
V D_1191 = default;
V drv_1192 = default;
on_1188 = Call(isPlay_27, V.Undef, S_1186);
GOLD_1189 = ((V)("#d4af5a"));
BK_1190 = ((V)("#16161a"));
D_1191 = NewObj(3).Put("w", ((V)(104D))).Put("d", ((V)(30D))).Put("build", Fn((V _arrowThis1199, int _argc1193, V _a1195, V _a1196, V _a1197, V _a1198, V[] _rest1194) => {
return Arr();
}, 0, "build", true)).V;
drv_1192 = Fn((V _arrowThis1210, int _argc1200, V cx_1206, V cy_1207, V r_1208, V ph_1209, V[] _rest1201) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<circle cx=\"", ToStr(cx_1206), "\" cy=\"", ToStr(cy_1207), "\" r=\"", ToStr(Call(f1_21, V.Undef, Add(r_1208, ((V)(1.1))))), "\" fill=\"", ToStr(GOLD_1189), "\"/><circle cx=\"", ToStr(cx_1206), "\" cy=\"", ToStr(cy_1207), "\" r=\"", ToStr(Call(f1_21, V.Undef, Add(r_1208, ((V)(0.4))))), "\" fill=\"#0a0a0c\"/>")).V(Call(cone_34, V.Undef, cx_1206, cy_1207, r_1208, on_1188, ph_1209)).End()));
}, 4, "", true);
Set(D_1191, "fx", Fn((V _arrowThis1218, int _argc1211, V ctx_1217, V _a1214, V _a1215, V _a1216, V[] _rest1212) => {
V C_1219 = default;
V L_1220 = default;
V sf_1221 = default;
V s_1222 = default;
C_1219 = Call(cam_16, V.Undef, ctx_1217);
L_1220 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1230, int _argc1223, V sg_1229, V _a1226, V _a1227, V _a1228, V[] _rest1224) => {
double x_1231 = 0;
double yaw_1232 = 0;
double TH_1233 = 0;
double ph_1234 = 0;
V f_1235 = default;
V g_1236 = default;
x_1231 = (ToNum(sg_1229) * 40D);
yaw_1232 = ((-ToNum(sg_1229)) * 0.16);
TH_1233 = 116D;
ph_1234 = (GtN(sg_1229, 0D) ? 0.1 : 0D);
f_1235 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"0.8\" y=\"0.8\" width=\"20.4\" height=\"", NumStr((TH_1233 - 1.6)), "\" rx=\"1.4\" fill=\"#0f0f12\"/>")).V(Call(drv_1192, V.Undef, ((V)(11D)), ((V)(10D)), ((V)(2.6)), ((V)(ph_1234)))).V(Call(drv_1192, V.Undef, ((V)(11D)), ((V)(21D)), ((V)(2.6)), ((V)(ph_1234)))).V(Call(drv_1192, V.Undef, ((V)(11D)), ((V)(38D)), ((V)(6.4)), ((V)(ph_1234)))).V(Call(drv_1192, V.Undef, ((V)(11D)), ((V)(57D)), ((V)(6.4)), ((V)((ph_1234 + 0.05))))).V(Call(drv_1192, V.Undef, ((V)(11D)), ((V)(76D)), ((V)(6.4)), ((V)((ph_1234 + 0.1))))).V(Call(drv_1192, V.Undef, ((V)(11D)), ((V)(95D)), ((V)(6.4)), ((V)((ph_1234 + 0.15))))).S(string.Concat("<path d=\"M3 0.8L9 0.8L3 ", NumStr((TH_1233 * 0.5)), "Z\" fill=\"#ffffff\" opacity=\"0.06\"/><rect x=\"5\" y=\"", NumStr((TH_1233 - 6D)), "\" width=\"12\" height=\"2.6\" rx=\"0.6\" fill=\"", ToStr(GOLD_1189), "\"/><text x=\"11\" y=\"", NumStr((TH_1233 - 4.1)), "\" text-anchor=\"middle\" font-size=\"1.6\" ", ToStr(FONT_25), " fill=\"#16161a\">SQUISH</text>")).End()));
g_1236 = Add(Call(shadow_26, V.Undef, C_1219, ((V)(x_1231)), ((V)(0D)), ((V)(14D)), ((V)(12D)), ((V)(0.85))), Call(box3_36, V.Undef, C_1219, NewObj(7).Put("c", Arr(((V)(x_1231)), ((V)(0D)), ((V)(0D)))).Put("ax", Call(yawA_28, V.Undef, ((V)(yaw_1232)))).Put("w", ((V)(24D))).Put("h", ((V)(3D))).Put("d", ((V)(24D))).Put("r", ((V)(1.2))).Put("col", GOLD_1189).V));
g_1236 = Add(g_1236, Call(box3_36, V.Undef, C_1219, NewObj(8).Put("c", Arr(((V)(x_1231)), ((V)(3D)), ((V)(0D)))).Put("ax", Call(yawA_28, V.Undef, ((V)(yaw_1232)))).Put("w", ((V)(22D))).Put("h", ((V)(TH_1233))).Put("d", ((V)(22D))).Put("r", ((V)(2.6))).Put("col", BK_1190).Put("dec", NewObj(4).Put("f", f_1235).Put("t", ((V)(string.Concat("<path d=\"M1 1H21\" stroke=\"", ToStr(GOLD_1189), "\" stroke-width=\"0.6\"/>")))).Put("r", ((V)(string.Concat("<path d=\"M3 2L8 2L3 ", NumStr((TH_1233 * 0.6)), "Z\" fill=\"#ffffff\" opacity=\"0.07\"/>")))).Put("l", ((V)(string.Concat("<path d=\"M3 2L8 2L3 ", NumStr((TH_1233 * 0.6)), "Z\" fill=\"#ffffff\" opacity=\"0.07\"/>")))).V).V));
Invoke(L_1220, "push", NewObj(2).Put("q", Arr(((V)(x_1231)), ((V)(56D)), ((V)(0D)))).Put("s", g_1236).V);
return default;
}, 1, "", true));
sf_1221 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"1\" y=\"1\" width=\"28\" height=\"28\" rx=\"2\" fill=\"#0f0f12\"/>", "")).V(Call(drv_1192, V.Undef, ((V)(15D)), ((V)(15D)), ((V)(10D)), ((V)(0.2)))).S(string.Concat("<text x=\"15\" y=\"28\" text-anchor=\"middle\" font-size=\"1.4\" ", ToStr(FONT_25), " fill=\"", ToStr(GOLD_1189), "\">SUB</text>")).End()));
Invoke(L_1220, "push", NewObj(2).Put("q", Arr(((V)(0D)), ((V)(14D)), ((V)((-4D))))).Put("s", ((V)(JsStrBuf.Begin().V(Call(shadow_26, V.Undef, C_1219, ((V)(0D)), ((V)((-4D))), ((V)(18D)), ((V)(16D)), ((V)(0.85)))).S(string.Concat("<g>", ToStr(Call(box3_36, V.Undef, C_1219, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)((-4D))))).Put("w", ((V)(30D))).Put("h", ((V)(30D))).Put("d", ((V)(30D))).Put("r", ((V)(2.4))).Put("col", BK_1190).Put("dec", NewObj(2).Put("f", sf_1221).Put("t", ((V)(string.Concat("<path d=\"M2 2H28\" stroke=\"", ToStr(GOLD_1189), "\" stroke-width=\"0.5\"/>")))).V).V)), "</g>")).End()))).V);
s_1222 = Add(Add(Call(zsort_31, V.Undef, C_1219, L_1220), Call(waves_55, V.Undef, C_1219, on_1188, Arr(Arr(((V)((-40D))), ((V)(62D)), ((V)(12D)), ((V)(6.4))), Arr(((V)(40D)), ((V)(62D)), ((V)(12D)), ((V)(6.4))), Arr(((V)((-40D))), ((V)(43D)), ((V)(12D)), ((V)(6.4))), Arr(((V)(40D)), ((V)(43D)), ((V)(12D)), ((V)(6.4))), Arr(((V)(0D)), ((V)(15D)), ((V)(12D)), ((V)(10D)))), ((V)("#ffe29a")))), Call(notes_54, V.Undef, C_1219, on_1188, Arr(Arr(((V)((-40D))), ((V)(130D)), ((V)(4D))), Arr(((V)(40D)), ((V)(128D)), ((V)(4D))), Arr(((V)(0D)), ((V)(44D)), ((V)(12D)))), ((V)("#b8872a"))));
Call(ext_30, V.Undef, C_1219, Arr(Arr(((V)(0D)), ((V)(134D)), ((V)(0D)))));
return NewObj(3).Put("defs", DEF18_40).Put("front", s_1222).Put("bb", Invoke(C_1219, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1191;
return default;
}, 1, "", true));
Set(N_13, "spkOrb18", Fn((V _arrowThis1244, int _argc1237, V S_1243, V _a1240, V _a1241, V _a1242, V[] _rest1238) => {
V on_1245 = default;
V D_1246 = default;
on_1245 = Call(isPlay_27, V.Undef, S_1243);
D_1246 = NewObj(4).Put("w", ((V)(70D))).Put("d", ((V)(24D))).Put("zs", ((V)(1.6))).Put("build", Fn((V _arrowThis1253, int _argc1247, V _a1249, V _a1250, V _a1251, V _a1252, V[] _rest1248) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1246, "fx", Fn((V _arrowThis1261, int _argc1254, V ctx_1260, V _a1257, V _a1258, V _a1259, V[] _rest1255) => {
V C_1262 = default;
V k_1263 = default;
V L_1264 = default;
V s_1265 = default;
C_1262 = Call(cam_16, V.Undef, ctx_1260);
k_1263 = Get(C_1262, "k");
L_1264 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1273, int _argc1266, V sg_1272, V _a1269, V _a1270, V _a1271, V[] _rest1267) => {
double x_1274 = 0;
double OY_1275 = 0;
double R_1276 = 0;
double ph_1277 = 0;
V cp_1278 = default;
JsStrBuf g_1279 = null;
V lp_1280 = default;
V orb_1281 = default;
V ring_1282 = default;
x_1274 = (ToNum(sg_1272) * 26D);
OY_1275 = 34D;
R_1276 = 11D;
ph_1277 = (GtN(sg_1272, 0D) ? (-1.1) : 0D);
cp_1278 = Invoke(C_1262, "p", ((V)(x_1274)), ((V)(OY_1275)), ((V)(0D)));
g_1279 = new JsStrBuf(JsStrBuf.Begin().V(Add(Add(Call(shadow_26, V.Undef, C_1262, ((V)(x_1274)), ((V)(0D)), ((V)(10D)), ((V)(9D)), ((V)(0.7))), Call(cyl3_37, V.Undef, C_1262, Arr(((V)(x_1274)), ((V)(0D)), ((V)(0D))), Arr(((V)(x_1274)), ((V)(2D)), ((V)(0D))), ((V)(9D)), ((V)("#c9ced6")), NewObj(1).Put("mat", ((V)("gloss"))).V)), Call(cyl3_37, V.Undef, C_1262, Arr(((V)(x_1274)), ((V)(2D)), ((V)(0D))), Arr(((V)(x_1274)), ((V)(5D)), ((V)(0D))), ((V)(6D)), ((V)("#e4e7ec")), NewObj(1).Put("mat", ((V)("gloss"))).V))).S(string.Concat("<g transform=\"", ToStr(Call(FR_17, V.Undef, C_1262, Arr(((V)(x_1274)), ((V)(5.05)), ((V)(0D))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><circle r=\"4.4\" fill=\"url(#q18cy)\">", ToStr(Call(an_18, V.Undef, ((V)("r")), ((V)("3.6;5.4;3.6")), ((V)((Truthy(on_1245) ? 0.48 : 2.6))), ((V)(ph_1277)))), "</circle><circle r=\"2\" fill=\"#dffcff\"/></g>")).End());
lp_1280 = Invoke(C_1262, "p", ((V)(x_1274)), ((V)(5D)), ((V)(0D)));
g_1279.S(string.Concat("<path d=\"M", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(lp_1280, 0D)) - (3D * ToNum(k_1263))))))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(lp_1280, 1D))), "L", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(cp_1278, 0D)) - (8D * ToNum(k_1263))))))), " ", ToStr(Call(f1_21, V.Undef, Add(GetIdx(cp_1278, 1D), ((V)((6D * ToNum(k_1263))))))), "L", ToStr(Call(f1_21, V.Undef, Add(GetIdx(cp_1278, 0D), ((V)((8D * ToNum(k_1263))))))), " ", ToStr(Call(f1_21, V.Undef, Add(GetIdx(cp_1278, 1D), ((V)((6D * ToNum(k_1263))))))), "L", ToStr(Call(f1_21, V.Undef, Add(GetIdx(lp_1280, 0D), ((V)((3D * ToNum(k_1263))))))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(lp_1280, 1D))), "Z\" fill=\"url(#q18bm)\" opacity=\"0.6\"/>"));
orb_1281 = ((V)(JsStrBuf.Begin().V(Call(sph_29, V.Undef, C_1262, Arr(((V)(x_1274)), ((V)(OY_1275)), ((V)(0D))), ((V)(R_1276)), ((V)("#e9eef8")))).S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_24, V.Undef, cp_1278)), ")\"><ellipse rx=\"", ToStr(Call(f1_21, V.Undef, ((V)(((R_1276 * 0.9) * ToNum(k_1263)))))), "\" ry=\"", ToStr(Call(f1_21, V.Undef, ((V)(((R_1276 * 0.9) * ToNum(k_1263)))))), "\" fill=\"url(#q18mg)\" opacity=\"0.55\" transform=\"scale(0.55 1)\"/>")).V(Call(cone_34, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(((R_1276 * 0.4) * ToNum(k_1263)))), on_1245, ((V)(ph_1277)))).S(string.Concat("</g>", "")).End()));
ring_1282 = Fn((V _arrowThis1293, int _argc1283, V r_1289, V tilt_1290, V d_1291, V op_1292, V[] _rest1284) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_24, V.Undef, cp_1278)), ") rotate(", ToStr(tilt_1290), ")\"><ellipse rx=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(r_1289) * ToNum(k_1263)))))), "\" ry=\"", ToStr(Call(f1_21, V.Undef, ((V)(((ToNum(r_1289) * 0.3) * ToNum(k_1263)))))), "\" fill=\"none\" stroke=\"#5ff0ff\" stroke-width=\"", ToStr(Call(f1_21, V.Undef, ((V)((0.8 * ToNum(k_1263)))))), "\" stroke-dasharray=\"", ToStr(Call(f1_21, V.Undef, ((V)((6D * ToNum(k_1263)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((4D * ToNum(k_1263)))))), "\" opacity=\"", ToStr(op_1292), "\">", ToStr(Call(an_18, V.Undef, ((V)("stroke-dashoffset")), ((V)(string.Concat("0;", ToStr(Call(f1_21, V.Undef, ((V)(((-40D) * ToNum(k_1263))))))))), d_1291)), ToStr(Call(an_18, V.Undef, ((V)("stroke")), ((V)("#5ff0ff;#b98aff;#ff7ac8;#5ff0ff")), ((V)(6D)), ((V)(ph_1277)))), "</ellipse></g>")));
}, 4, "", true);
orb_1281 = Add(Call(ring_1282, V.Undef, ((V)((R_1276 + 4D))), ((V)((ToNum(sg_1272) * (-12D)))), ((V)((Truthy(on_1245) ? 0.9 : 3D))), ((V)(0.9))), orb_1281);
if (Truthy(on_1245)) {
orb_1281 = ((V)(JsStrBuf.Begin().V(orb_1281).S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(cp_1278, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(cp_1278, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((R_1276 * ToNum(k_1263)))))), "\" fill=\"none\" stroke=\"#8ff6ff\" stroke-width=\"", ToStr(Call(f1_21, V.Undef, ((V)((0.6 * ToNum(k_1263)))))), "\" opacity=\"0\">", ToStr(Call(an_18, V.Undef, ((V)("r")), ((V)(string.Concat(ToStr(Call(f1_21, V.Undef, ((V)((R_1276 * ToNum(k_1263)))))), ";", ToStr(Call(f1_21, V.Undef, ((V)(((R_1276 + 14D) * ToNum(k_1263))))))))), ((V)(0.96)), ((V)((ph_1277 * 0.3))))), ToStr(Call(an_18, V.Undef, ((V)("opacity")), ((V)("0.8;0")), ((V)(0.96)), ((V)((ph_1277 * 0.3))))), "</circle>")).End()));
}
g_1279.S(string.Concat("<g>", ToStr(Call(at_19, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 ", ToStr(Call(f1_21, V.Undef, ((V)(((-2.4) * ToNum(k_1263)))))), ";0 0"))), ((V)(3D)), ((V)(ph_1277)), Call(SPL_20, V.Undef, ((V)(2D))))), ToStr(orb_1281), "</g>"));
Invoke(L_1264, "push", NewObj(2).Put("q", Arr(((V)(x_1274)), ((V)(20D)), ((V)(0D)))).Put("s", ((V)(g_1279.Str))).V);
return default;
}, 1, "", true));
s_1265 = Add(Call(zsort_31, V.Undef, C_1262, L_1264), Call(notes_54, V.Undef, C_1262, on_1245, Arr(Arr(((V)((-26D))), ((V)(56D)), ((V)(4D))), Arr(((V)(26D)), ((V)(54D)), ((V)(4D))), Arr(((V)(0D)), ((V)(60D)), ((V)(4D)))), ((V)("#3fb8e0"))));
Call(ext_30, V.Undef, C_1262, Arr(Arr(((V)(0D)), ((V)(62D)), ((V)(0D))), Arr(((V)((-44D))), ((V)(34D)), ((V)(0D))), Arr(((V)(44D)), ((V)(34D)), ((V)(0D)))));
return NewObj(3).Put("defs", DEF18_40).Put("front", s_1265).Put("bb", Invoke(C_1262, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1246;
return default;
}, 1, "", true));
robot_56 = Fn((V _arrowThis1306, int _argc1294, V C_1300, V x_1301, V y_1302, V z_1303, V[] _rest1295) => {
V k_1307 = default;
double R_1308 = 0;
V BL_1309 = default;
V s_1310 = default;
V mv_1304 = default;
V dk_1305 = default;
mv_1304 = (_argc1294 > 4 ? _rest1295[0] : V.Undef);
dk_1305 = (_argc1294 > 5 ? _rest1295[1] : V.Undef);
k_1307 = Get(C_1300, "k");
R_1308 = 15D;
BL_1309 = (mv_1304 is var _t1311 && Truthy(_t1311) ? _t1311 : (SEqN(dk_1305, 2D) ? V.True : V.False));
s_1310 = Call(shadow_26, V.Undef, C_1300, x_1301, z_1303, ((V)((R_1308 + 1.5))), ((V)(R_1308)), ((V)(0.85)), ((V)(0.05)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1319, int _argc1312, V sg_1318, V _a1315, V _a1316, V _a1317, V[] _rest1313) => {
s_1310 = ((V)(JsStrBuf.Begin().V(s_1310).S(string.Concat("<g transform=\"", ToStr(Call(FR_17, V.Undef, C_1300, Arr(Add(x_1301, ((V)((ToNum(sg_1318) * 9.4)))), ((V)(0.35)), Add(z_1303, ((V)(9.6)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><g>", ToStr((Truthy(mv_1304) ? Call(at_19, V.Undef, ((V)("rotate")), ((V)((LtN(sg_1318, 0D) ? "0;-360" : "0;360"))), ((V)(0.4))) : ((V)("")))), ToStr(Invoke(Call(rep_23, V.Undef, ((V)(3D)), Fn((V _arrowThis1327, int _argc1320, V i_1326, V _a1323, V _a1324, V _a1325, V[] _rest1321) => {
double t_1328 = 0;
t_1328 = ((ToNum(i_1326) * 2.094) + (ToNum(sg_1318) * 0.4));
return ((V)(string.Concat("<path d=\"M0 0L", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Cos(t_1328) * 8D))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Sin(t_1328) * 8D))))), "\" stroke=\"#3a3f4a\" stroke-width=\"0.7\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Cos(t_1328) * 5D))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Sin(t_1328) * 5D))))), "L", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Cos((t_1328 + 0.18)) * 8.2))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Sin((t_1328 + 0.18)) * 8.2))))), "M", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Cos(t_1328) * 5D))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Sin(t_1328) * 5D))))), "L", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Cos((t_1328 - 0.18)) * 8.2))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((FdLibm.Sin((t_1328 - 0.18)) * 8.2))))), "\" stroke=\"#5a606c\" stroke-width=\"0.35\" stroke-linecap=\"round\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))), "<circle r=\"1.4\" fill=\"#3fb8ff\"/></g></g>")).End()));
return default;
}, 1, "", true));
s_1310 = Add(s_1310, Call(cyl3_37, V.Undef, C_1300, Arr(x_1301, Add(y_1302, ((V)(0.4))), z_1303), Arr(x_1301, Add(y_1302, ((V)(1.6))), z_1303), ((V)((R_1308 - 1D))), ((V)("#2a2e38"))));
s_1310 = Add(s_1310, Add(Call(cyl3_37, V.Undef, C_1300, Arr(x_1301, Add(y_1302, ((V)(1.6))), z_1303), Arr(x_1301, Add(y_1302, ((V)(3.8))), z_1303), ((V)(R_1308)), ((V)("#9fb4cc")), NewObj(1).Put("noCap", ((V)(1D))).V), Call(cyl3_37, V.Undef, C_1300, Arr(x_1301, Add(y_1302, ((V)(3.8))), z_1303), Arr(x_1301, Add(y_1302, ((V)(6.4))), z_1303), ((V)(R_1308)), ((V)("#ffffff")), NewObj(1).Put("capCol", ((V)("#fbfcfe"))).V)));
s_1310 = ((V)(JsStrBuf.Begin().V(s_1310).S(string.Concat("<g transform=\"", ToStr(Call(FR_17, V.Undef, C_1300, Arr(x_1301, Add(y_1302, ((V)(6.45))), z_1303), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><circle r=\"", NumStr((R_1308 - 1.6)), "\" fill=\"none\" stroke=\"#dde2ea\" stroke-width=\"0.5\"/><path d=\"M", NumStr(((-R_1308) + 2D)), " 3A", NumStr((R_1308 - 2D)), " ", NumStr((R_1308 - 2D)), " 0 0 0 ", NumStr((R_1308 - 2D)), " 3\" stroke=\"#e6eaf0\" stroke-width=\"0.9\" fill=\"none\"/>")).S(string.Concat("<rect x=\"-6\" y=\"4.4\" width=\"12\" height=\"5.4\" rx=\"2.7\" fill=\"#161a22\"/>", ToStr(Invoke(Invoke(Arr(((V)((-2.6))), ((V)(2.6))), "map", Fn((V _arrowThis1336, int _argc1329, V ex_1335, V _a1332, V _a1333, V _a1334, V[] _rest1330) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(ex_1335), "\" cy=\"6.6\" rx=\"0.95\" ry=\"1.25\" fill=\"", (Truthy(BL_1309) ? "#7ff0ff" : "#7dffb0"), "\"><animate attributeName=\"ry\" values=\"1.25;1.25;0.2;1.25;1.25\" keyTimes=\"0;0.9;0.94;0.98;1\" dur=\"3.6s\" repeatCount=\"indefinite\"/></ellipse>")));
}, 1, "", true)), "join", ((V)("")))), "<path d=\"M-1.4 8.2Q0 9.2 1.4 8.2\" stroke=\"", (Truthy(BL_1309) ? "#7ff0ff" : "#7dffb0"), "\" stroke-width=\"0.5\" fill=\"none\" stroke-linecap=\"round\"/>")).S(string.Concat("<circle cx=\"0\" cy=\"-11\" r=\"1.6\" fill=\"#e6eaf0\" stroke=\"#aab2be\" stroke-width=\"0.35\"/><circle cx=\"0\" cy=\"-11\" r=\"0.9\" fill=\"none\" stroke=\"", (SEqN(dk_1305, 1D) ? "#5dff7a" : "#3fb8ff"), "\" stroke-width=\"0.45\">", ToStr(Call(an_18, V.Undef, ((V)("stroke-opacity")), ((V)((Truthy(mv_1304) ? "1;0.4;1" : "0.3;1;0.3"))), ((V)((Truthy(mv_1304) ? 0.8 : 2.2))))), "</circle></g>")).End()));
s_1310 = Add(s_1310, Call(cyl3_37, V.Undef, C_1300, Arr(x_1301, Add(y_1302, ((V)(6.4))), ((V)((ToNum(z_1303) - 4.6)))), Arr(x_1301, Add(y_1302, ((V)(9.4))), ((V)((ToNum(z_1303) - 4.6)))), ((V)(4.8)), ((V)("#2a2e38"))));
s_1310 = ((V)(JsStrBuf.Begin().V(s_1310).S(string.Concat("<g transform=\"", ToStr(Call(FR_17, V.Undef, C_1300, Arr(x_1301, Add(y_1302, ((V)(9.45))), ((V)((ToNum(z_1303) - 4.6)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><circle r=\"4.2\" fill=\"#1a1d24\"/><g>", ToStr((Truthy(mv_1304) ? Call(at_19, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(1.2))) : ((V)("")))), "<path d=\"M0 0L0 -4.2A4.2 4.2 0 0 1 3 -2.9Z\" fill=\"#3fb8ff\" opacity=\"", NumStr((Truthy(mv_1304) ? 0.55 : 0.2)), "\"/></g><circle r=\"1.6\" fill=\"#3a3f4a\"/><path d=\"M-0.9 -0.9A1.3 1.3 0 0 1 0.9 -0.9\" stroke=\"#ffffff\" stroke-opacity=\"0.4\" stroke-width=\"0.35\" fill=\"none\"/></g>")).End()));
_ = k_1307;
return s_1310;
return default;
}, 6, "", true);
Set(N_13, "vac18", Fn((V _arrowThis1344, int _argc1337, V S_1343, V _a1340, V _a1341, V _a1342, V[] _rest1338) => {
V st_1345 = default;
V play_1346 = default;
V @out_1347 = default;
double RZ_1348 = 0;
double RY_1349 = 0;
double TW_1350 = 0;
double TH_1351 = 0;
double TD_1352 = 0;
double TZ_1353 = 0;
V D_1354 = default;
V LC_1355 = default;
V dockF_1356 = default;
V dockT_1357 = default;
V side_1358 = default;
st_1345 = (Get(S_1343, "st") is var _t1359 && Truthy(_t1359) ? _t1359 : ((V)("")));
play_1346 = Call(isPlay_27, V.Undef, S_1343);
@out_1347 = Invoke(NewRegExp(RX2, "out", ""), "test", st_1345);
RZ_1348 = 15D;
RY_1349 = 1.2;
TW_1350 = 38D;
TH_1351 = 46D;
TD_1352 = 16D;
TZ_1353 = (-9D);
D_1354 = NewObj(5).Put("w", ((V)(44D))).Put("d", ((V)(50D))).Put("zs", ((V)(1.5))).Put("noBlock", ((V)(1D))).Put("build", Fn((V _arrowThis1366, int _argc1360, V _a1362, V _a1363, V _a1364, V _a1365, V[] _rest1361) => {
return Arr();
}, 0, "build", true)).V;
LC_1355 = ((V)((Truthy(@out_1347) ? "#3fb8ff" : "#5dff7a")));
dockF_1356 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"5\" y=\"4\" width=\"", NumStr((TW_1350 - 10D)), "\" height=\"15\" rx=\"4\" fill=\"#1c2230\"/><rect x=\"6.4\" y=\"12\" width=\"", NumStr((TW_1350 - 12.8)), "\" height=\"5.6\" rx=\"2.4\" fill=\"#5a5f6a\" opacity=\"0.7\"/><path d=\"M8 12.6Q12 10.6 16 12.4T24 12T30 12.6\" stroke=\"#8a8f98\" stroke-width=\"0.4\" fill=\"none\"/>")).S(string.Concat("<path d=\"M6.4 5.4H", NumStr((TW_1350 - 6.4)), "\" stroke=\"#ffffff\" stroke-opacity=\"0.25\" stroke-width=\"0.7\"/><text x=\"", NumStr((TW_1350 / 2D)), "\" y=\"9.6\" text-anchor=\"middle\" font-size=\"3\" font-family=\"'Fredoka','Comic Sans MS',sans-serif\" font-weight=\"700\" fill=\"#8fe0ff\">SQUISH VAC</text>")).S(string.Concat("<circle cx=\"", NumStr((TW_1350 / 2D)), "\" cy=\"25.6\" r=\"3.6\" fill=\"#e6eaf0\" stroke=\"#b9c0cc\" stroke-width=\"0.4\"/><circle cx=\"", NumStr((TW_1350 / 2D)), "\" cy=\"25.6\" r=\"2.4\" fill=\"none\" stroke=\"", ToStr(LC_1355), "\" stroke-width=\"0.8\">", ToStr(Call(an_18, V.Undef, ((V)("stroke-opacity")), ((V)("0.25;1;0.25")), ((V)((Truthy(@out_1347) ? 1D : 2.4))))), "</circle>")).S(string.Concat("<path d=\"M", NumStr(((TW_1350 / 2D) + 0.5)), " 23.8L", NumStr(((TW_1350 / 2D) - 1D)), " 26H", NumStr(((TW_1350 / 2D) + 0.2)), "L", NumStr(((TW_1350 / 2D) - 0.5)), " 27.6L", NumStr(((TW_1350 / 2D) + 1.1)), " 25.2H", NumStr(((TW_1350 / 2D) - 0.1)), "Z\" fill=\"", ToStr(LC_1355), "\"/>")).S(string.Concat("<path d=\"M5 ", NumStr((TH_1351 - 3D)), "V", NumStr((TH_1351 - 10D)), "Q5 ", NumStr((TH_1351 - 15D)), " 10 ", NumStr((TH_1351 - 15D)), "H", NumStr((TW_1350 - 10D)), "Q", NumStr((TW_1350 - 5D)), " ", NumStr((TH_1351 - 15D)), " ", NumStr((TW_1350 - 5D)), " ", NumStr((TH_1351 - 10D)), "V", NumStr((TH_1351 - 3D)), "Z\" fill=\"#2a2e38\"/><path d=\"M8 ", NumStr((TH_1351 - 3D)), "V", NumStr((TH_1351 - 9D)), "Q8 ", NumStr((TH_1351 - 12D)), " 11 ", NumStr((TH_1351 - 12D)), "H", NumStr((TW_1350 - 11D)), "Q", NumStr((TW_1350 - 8D)), " ", NumStr((TH_1351 - 12D)), " ", NumStr((TW_1350 - 8D)), " ", NumStr((TH_1351 - 9D)), "V", NumStr((TH_1351 - 3D)), "Z\" fill=\"#14171e\"/>")).V(Invoke(Call(rep_23, V.Undef, ((V)(2D)), Fn((V _arrowThis1374, int _argc1367, V i_1373, V _a1370, V _a1371, V _a1372, V[] _rest1368) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_21, V.Undef, ((V)((((TW_1350 / 2D) - 6D) + (ToNum(i_1373) * 9D)))))), "\" y=\"", NumStr((TH_1351 - 6D)), "\" width=\"3\" height=\"1.6\" rx=\"0.6\" fill=\"#c9ced6\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
dockT_1357 = ((V)(string.Concat("<rect x=\"9\" y=\"4\" width=\"", NumStr((TW_1350 - 18D)), "\" height=\"5\" rx=\"2.5\" fill=\"#d6dbe3\"/><rect x=\"12\" y=\"5.2\" width=\"", NumStr((TW_1350 - 24D)), "\" height=\"2.6\" rx=\"1.3\" fill=\"#b9c0cc\"/>")));
side_1358 = ((V)(JsStrBuf.Begin().S(string.Concat("<path d=\"M3 6V", NumStr((TH_1351 - 4D)), "\" stroke=\"#d6dbe3\" stroke-width=\"0.6\"/>")).V(Invoke(Call(rep_23, V.Undef, ((V)(4D)), Fn((V _arrowThis1382, int _argc1375, V i_1381, V _a1378, V _a1379, V _a1380, V[] _rest1376) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_21, V.Undef, ((V)((5D + (ToNum(i_1381) * 2.2)))))), "\" y=\"30\" width=\"1\" height=\"8\" rx=\"0.5\" fill=\"#c3cad5\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
Set(D_1354, "fx", Fn((V _arrowThis1390, int _argc1383, V ctx_1389, V _a1386, V _a1387, V _a1388, V[] _rest1384) => {
V C_1391 = default;
V s_1392 = default;
V C2_1393 = default;
V body_1394 = default;
V hm_1395 = default;
V b_1396 = default;
V vb_1397 = default;
V svg_1398 = default;
C_1391 = Call(cam_16, V.Undef, ctx_1389);
s_1392 = Call(shadow_26, V.Undef, C_1391, ((V)(0D)), ((V)(6D)), ((V)(28D)), ((V)(22D)), ((V)(0.75)));
s_1392 = Add(s_1392, Call(box3_36, V.Undef, C_1391, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)(9D)))).Put("w", ((V)(44D))).Put("h", ((V)(RY_1349))).Put("d", ((V)(34D))).Put("r", ((V)(5D))).Put("col", ((V)("#d3d9e2"))).Put("dec", NewObj(1).Put("t", ((V)(string.Concat("<rect x=\"15.4\" y=\"16\" width=\"4\" height=\"7\" rx=\"1.2\" fill=\"#aeb6c2\"/><rect x=\"24.6\" y=\"16\" width=\"4\" height=\"7\" rx=\"1.2\" fill=\"#aeb6c2\"/><path d=\"M6 31H38\" stroke=\"#b9c0cc\" stroke-width=\"0.5\"/><path d=\"M19 27L22 29.4L25 27\" stroke=\"#9aa4b4\" stroke-width=\"0.7\" fill=\"none\" stroke-linecap=\"round\"/>", "")))).V).V));
s_1392 = Add(s_1392, Call(box3_36, V.Undef, C_1391, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)(TZ_1353)))).Put("w", ((V)(TW_1350))).Put("h", ((V)(TH_1351))).Put("d", ((V)(TD_1352))).Put("r", ((V)(5D))).Put("col", ((V)("#f3f5f8"))).Put("dec", NewObj(4).Put("f", dockF_1356).Put("t", dockT_1357).Put("r", side_1358).Put("l", side_1358).V).V));
if (!(Truthy(@out_1347))) {
if (Truthy(play_1346)) {
V h_1399 = default;
V P_1400 = default;
h_1399 = Invoke(C_1391, "p", ((V)(0D)), ((V)(RY_1349)), ((V)(RZ_1348)));
P_1400 = Invoke(Arr(Arr(((V)((-34D))), ((V)(0D)), ((V)(38D))), Arr(((V)(0D)), ((V)(0D)), ((V)(60D))), Arr(((V)(34D)), ((V)(0D)), ((V)(38D))), Arr(((V)(0D)), ((V)(0D)), ((V)(RZ_1348)))), "map", Fn((V _arrowThis1408, int _argc1401, V q_1407, V _a1404, V _a1405, V _a1406, V[] _rest1402) => {
V v_1409 = default;
v_1409 = Invoke(C_1391, "p", GetIdx(q_1407, 0D), GetIdx(q_1407, 1D), GetIdx(q_1407, 2D));
return ((V)(JsStrBuf.Begin().V(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(v_1409, 0D)) - ToNum(GetIdx(h_1399, 0D))))))).S(" ").V(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(v_1409, 1D)) - ToNum(GetIdx(h_1399, 1D))))))).End()));
return default;
}, 1, "", true));
s_1392 = ((V)(JsStrBuf.Begin().V(s_1392).S(string.Concat("<g><animateMotion dur=\"9s\" repeatCount=\"indefinite\" path=\"M0 0C", ToStr(GetIdx(P_1400, 0D)), " ", ToStr(GetIdx(P_1400, 1D)), " ", ToStr(GetIdx(P_1400, 1D)), "S", ToStr(GetIdx(P_1400, 2D)), " ", ToStr(GetIdx(P_1400, 3D)), "\"/>", ToStr(Call(robot_56, V.Undef, C_1391, ((V)(0D)), ((V)(RY_1349)), ((V)(RZ_1348)), ((V)(1D)), ((V)(0D)))), "</g>")).End()));
} else {
s_1392 = Add(s_1392, Call(robot_56, V.Undef, C_1391, ((V)(0D)), ((V)(RY_1349)), ((V)(RZ_1348)), ((V)(0D)), ((V)(1D))));
}
}
C2_1393 = Call(cam_16, V.Undef, ctx_1389);
body_1394 = Call(robot_56, V.Undef, C2_1393, ((V)(0D)), ((V)(RY_1349)), ((V)(RZ_1348)), ((V)(1D)), ((V)(0D)));
hm_1395 = Invoke(C2_1393, "p", ((V)(0D)), ((V)(0D)), ((V)(RZ_1348)));
b_1396 = Invoke(C2_1393, "bb", ((V)(2D)));
vb_1397 = Arr(((V)((ToNum(GetIdx(b_1396, 0D)) - ToNum(GetIdx(hm_1395, 0D))))), ((V)((ToNum(GetIdx(b_1396, 1D)) - ToNum(GetIdx(hm_1395, 1D))))), ((V)((ToNum(GetIdx(b_1396, 2D)) - ToNum(GetIdx(b_1396, 0D))))), ((V)((ToNum(GetIdx(b_1396, 3D)) - ToNum(GetIdx(b_1396, 1D))))));
svg_1398 = ((V)(string.Concat("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"", ToStr(Call(f1_21, V.Undef, GetIdx(b_1396, 0D))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(b_1396, 1D))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(vb_1397, 2D))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(vb_1397, 3D))), "\"><defs>", ToStr(DEF18_40), "</defs>", ToStr(body_1394), "</svg>")));
Set(RD_8, "_vac", NewObj(3).Put("src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, svg_1398)).End()))).Put("bb", Invoke(vb_1397, "map", Fn((V _arrowThis1417, int _argc1410, V v_1416, V _a1413, V _a1414, V _a1415, V[] _rest1411) => {
return ((V)(ToNum(Call(f1_21, V.Undef, v_1416))));
}, 1, "", true))).Put("home", Arr(((V)(ToNum(Call(f1_21, V.Undef, GetIdx(hm_1395, 0D))))), ((V)(ToNum(Call(f1_21, V.Undef, GetIdx(hm_1395, 1D))))))).V);
Call(ext_30, V.Undef, C_1391, Arr(Arr(((V)((-38D))), ((V)(0D)), ((V)(62D))), Arr(((V)(38D)), ((V)(0D)), ((V)(62D)))));
return NewObj(3).Put("defs", DEF18_40).Put("front", s_1392).Put("bb", Invoke(C_1391, "bb", ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1354;
return default;
}, 1, "", true));
draw0_57 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis1426, int _argc1418, V r_1424, V o_1425, V _a1422, V _a1423, V[] _rest1419) => {
V res_1427 = default;
Set(RD_8, "_vac", V.Null);
res_1427 = Call(draw0_57, V.Undef, r_1424, o_1425);
if (Truthy(((Get(RD_8, "_vac") is var _t1428 && !Truthy(_t1428) ? _t1428 : res_1427) is var _t1429 && !Truthy(_t1429) ? _t1429 : (!(Truthy(Get(res_1427, "vac"))) ? V.True : V.False)))) {
Set(res_1427, "vac", Get(RD_8, "_vac"));
}
Set(RD_8, "_vac", V.Null);
return res_1427;
return default;
}, 2, "", true));
TV_58 = NewObj(5).Put("role", ((V)("tv"))).Put("play", ((V)("show"))).Put("playL", ((V)("Turn on the TV"))).Put("stopL", ((V)("Turn off the TV"))).Put("playS", ((V)("Squish Toons is on \u00b7 tap to turn it off"))).V;
Set(RD_8, "SET18", NewObj(5).Put("LIV-011", Object_assign(NewObj(2).Put("spec", ((V)("rabbit18"))).Put("note", ((V)("Needs speakers in the room for sound: without them it only shows static. With speakers, tap to flip through 3 channels (Squish Toons, Squish Cup football, Space Trip) and off. A chunky mint CRT with two channel dials sits on a three-legged pine stool. The rabbit-ear antenna sways a little, one ear has a tinfoil ball on the tip, and a strip of duct tape holds a corner together. Tap it: Squish Toons comes on with fuzzy scanlines and a rolling bar."))).V, TV_58)).Put("LIV-031", Object_assign(NewObj(2).Put("spec", ((V)("frame18"))).Put("note", ((V)("A slim TV in a light oak picture frame with a white mat. When it is off it shows a sunrise painting (art mode) with a soft sheen sweeping over it; tap it and the painting turns into Squish Toons."))).V, TV_58)).Put("LIV-051", Object_assign(NewObj(3).Put("name", ((V)("Retro Walnut TV Console & Turntable"))).Put("spec", ((V)("console18"))).Put("note", ((V)("A mid-century walnut console on brass-capped legs with orange grille-cloth speakers, a cream Squish-o-Vision TV on a brass swivel, a turntable and a little tube amp. Tap it: the TV warms up, the record spins, the tubes glow and the VU needles dance."))).V, TV_58)).Put("LIV-071", Object_assign(NewObj(2).Put("spec", ((V)("oled18"))).Put("note", ((V)("A smoked-walnut credenza with fluted doors and gold trim. Its huge 200-unit OLED screen (the biggest TV in the house) rolls up out of the slot on top when you turn it on, and the wall behind it glows."))).V, TV_58)).Put("LIV-091", Object_assign(NewObj(3).Put("name", ((V)("Floating Holo-Screen & Acoustic Sculpture"))).Put("spec", ((V)("holo18"))).Put("note", ((V)("A giant see-through holo-screen floats over a glowing emitter, wrapped by a ring of walnut acoustic fins with cyan tips. When it is off a little hologram mascot waves hello; tap it for Squish Toons in holo colour."))).V, TV_58)).V);
ADD18_59 = Arr(Arr(((V)(131D)), ((V)(1D)), ((V)("Mismatched Garage-Sale Speakers")), ((V)("spkJunk18")), ((V)(80D)), ((V)("One wooden speaker and one cracked plastic one held together with duct tape, each propped on a brick. The plastic one buzzes now and then. They give the TV its sound: when a TV in the room is on, sound waves pulse out of them."))), Arr(((V)(132D)), ((V)(2D)), ((V)("Bookshelf Speakers on Stands")), ((V)("spkShelf18")), ((V)(360D)), ((V)("Two white bookshelf speakers with oak fronts on slim black stands, toed in toward the sofa. They give the TV its sound: when a TV in the room is on, sound waves pulse out of them."))), Arr(((V)(133D)), ((V)(3D)), ((V)("Walnut Tower Speakers")), ((V)("spkTower18")), ((V)(1400D)), ((V)("Tall walnut towers on tapered legs with orange grille cloth and brass-ringed drivers. They give the TV its sound: when a TV in the room is on, sound waves pulse out of them."))), Arr(((V)(134D)), ((V)(4D)), ((V)("Piano-Black Towers & Subwoofer")), ((V)("spkPiano18")), ((V)(5200D)), ((V)("Glossy piano-black floor speakers on gold plinths with gold-ringed drivers, plus a subwoofer cube that thumps in the middle. They give the TV its sound: when a TV in the room is on, sound waves pulse out of them."))), Arr(((V)(135D)), ((V)(5D)), ((V)("Levitating Orb Speakers")), ((V)("spkOrb18")), ((V)(26000D)), ((V)("Two pearl orb speakers float over glowing pedestals inside colour-shifting light rings; when music plays, sound rings pulse out of them. They give the TV its sound: when a TV in the room is on, sound waves pulse out of them."))));
edit17_60 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis1437, int _argc1430, V rows_1436, V _a1433, V _a1434, V _a1435, V[] _rest1431) => {
V R_1438 = default;
V @base_1439 = default;
V TF_1440 = default;
R_1438 = Invoke(Call(edit17_60, V.Undef, rows_1436), "map", Fn((V _arrowThis1448, int _argc1441, V r_1447, V _a1444, V _a1445, V _a1446, V[] _rest1442) => {
return (Truthy(GetK(Get(RD_8, "SET18"), Get(r_1447, "id"))) ? Object_assign(NewObj(0).V, r_1447, GetK(Get(RD_8, "SET18"), Get(r_1447, "id"))) : r_1447);
}, 1, "", true));
if (Truthy(Invoke(R_1438, "some", Fn((V _arrowThis1456, int _argc1449, V r_1455, V _a1452, V _a1453, V _a1454, V[] _rest1450) => {
return (SEqS(Get(r_1455, "id"), "LIV-131") ? V.True : V.False);
}, 1, "", true)))) {
return R_1438;
}
@base_1439 = Fn((V _arrowThis1464, int _argc1457, V t_1463, V _a1460, V _a1461, V _a1462, V[] _rest1458) => {
return (Invoke(R_1438, "find", Fn((V _arrowThis1472, int _argc1465, V r_1471, V _a1468, V _a1469, V _a1470, V[] _rest1466) => {
return (((SEqS(Get(r_1471, "room"), "LIV") && SEq(Get(r_1471, "tier"), t_1463)) && SEqN(Get(r_1471, "slot"), 15D)) ? V.True : V.False);
}, 1, "", true)) is var _t1481 && Truthy(_t1481) ? _t1481 : Invoke(R_1438, "find", Fn((V _arrowThis1480, int _argc1473, V r_1479, V _a1476, V _a1477, V _a1478, V[] _rest1474) => {
return ((SEqS(Get(r_1479, "room"), "LIV") && SEq(Get(r_1479, "tier"), t_1463)) ? V.True : V.False);
}, 1, "", true)));
}, 1, "", true);
Invoke(ADD18_59, "forEach", Fn((V _arrowThis1501, int _argc1482, V _a1484, V _a1485, V _a1486, V _a1487, V[] _rest1483) => {
V b_1502 = default;
V n_1490 = default;
V t_1492 = default;
V name_1494 = default;
V spec_1496 = default;
V cost_1498 = default;
V note_1500 = default;
{ V _t1488 = ListOf(_a1484);
{ V _t1489 = GetIdx(_t1488, 0D);
n_1490 = _t1489; }
{ V _t1491 = GetIdx(_t1488, 1D);
t_1492 = _t1491; }
{ V _t1493 = GetIdx(_t1488, 2D);
name_1494 = _t1493; }
{ V _t1495 = GetIdx(_t1488, 3D);
spec_1496 = _t1495; }
{ V _t1497 = GetIdx(_t1488, 4D);
cost_1498 = _t1497; }
{ V _t1499 = GetIdx(_t1488, 5D);
note_1500 = _t1499; }
}
b_1502 = Call(@base_1439, V.Undef, t_1492);
if (Truthy(b_1502)) {
Invoke(R_1438, "push", Object_assign(NewObj(0).V, b_1502, NewObj(14).Put("id", ((V)(JsStrBuf.Begin().S("LIV-").V(n_1490).End()))).Put("slot", ((V)(21D))).Put("slotName", ((V)("Speakers"))).Put("name", name_1494).Put("spec", spec_1496).Put("cost", cost_1498).Put("note", note_1500).Put("role", ((V)("tvspk"))).Put("add", ((V)(1D))).Put("play", V.Undef).Put("playL", V.Undef).Put("stopL", V.Undef).Put("playS", V.Undef).Put("live", V.Undef).V));
}
return default;
}, 1, "", true));
{
V b_1503 = default;
b_1503 = Call(@base_1439, V.Undef, ((V)(3D)));
if (Truthy(b_1503)) {
Invoke(R_1438, "push", Object_assign(NewObj(0).V, b_1503, NewObj(16).Put("id", ((V)("LIV-136"))).Put("slot", ((V)(22D))).Put("slotName", ((V)("Robot Vacuum"))).Put("catO", ((V)("Electronics"))).Put("name", ((V)("Robo-Vac & Charging Dock"))).Put("spec", ((V)("vac18"))).Put("cost", ((V)(1450D))).Put("vac", ((V)(1D))).Put("role", V.Undef).Put("play", ((V)("show"))).Put("playL", ((V)("Start cleaning"))).Put("stopL", ((V)("Send it home"))).Put("playS", ((V)("Cleaning\u2026 tap to send it home"))).Put("live", V.Undef).Put("add", ((V)(1D))).Put("note", ((V)("A little white robot vacuum with blinking LED eyes, a spinning lidar puck and a side brush, parked on its charging dock. Tap it: it rolls out and cleans the whole room by itself, then after 5 minutes it drives back into the dock to charge."))).V));
}
}
TF_1440 = Arr(((V)("tier")), ((V)("tierName")), ((V)("rarity")), ((V)("lv")), ((V)("cost")), ((V)("bonus")), ((V)("statVal")));
Invoke(Arr(Arr(((V)("LIV-031")), ((V)("LIV-051"))), Arr(((V)("LIV-132")), ((V)("LIV-133")))), "forEach", Fn((V _arrowThis1515, int _argc1504, V _a1506, V _a1507, V _a1508, V _a1509, V[] _rest1505) => {
V i_1516 = default;
V j_1517 = default;
V A_1518 = default;
V B_1519 = default;
V pa_1520 = default;
V pb_1521 = default;
V x_1512 = default;
V y_1514 = default;
{ V _t1510 = ListOf(_a1506);
{ V _t1511 = GetIdx(_t1510, 0D);
x_1512 = _t1511; }
{ V _t1513 = GetIdx(_t1510, 1D);
y_1514 = _t1513; }
}
i_1516 = Invoke(R_1438, "findIndex", Fn((V _arrowThis1529, int _argc1522, V r_1528, V _a1525, V _a1526, V _a1527, V[] _rest1523) => {
return (SEq(Get(r_1528, "id"), x_1512) ? V.True : V.False);
}, 1, "", true));
j_1517 = Invoke(R_1438, "findIndex", Fn((V _arrowThis1537, int _argc1530, V r_1536, V _a1533, V _a1534, V _a1535, V[] _rest1531) => {
return (SEq(Get(r_1536, "id"), y_1514) ? V.True : V.False);
}, 1, "", true));
if (Truthy((((LtN(i_1516, 0D) || LtN(j_1517, 0D)) ? V.True : V.False) is var _t1538 && Truthy(_t1538) ? _t1538 : Get(GetK(R_1438, i_1516), "sw18")))) {
return default;
}
A_1518 = GetK(R_1438, i_1516);
B_1519 = GetK(R_1438, j_1517);
pa_1520 = NewObj(0).V;
pb_1521 = NewObj(0).V;
Invoke(TF_1440, "forEach", Fn((V _arrowThis1546, int _argc1539, V f_1545, V _a1542, V _a1543, V _a1544, V[] _rest1540) => {
if (HasProperty(B_1519, f_1545)) {
SetK(pa_1520, f_1545, GetK(B_1519, f_1545));
}
if (HasProperty(A_1518, f_1545)) {
SetK(pb_1521, f_1545, GetK(A_1518, f_1545));
}
return default;
}, 1, "", true));
SetK(R_1438, i_1516, Object_assign(NewObj(0).V, A_1518, pa_1520, NewObj(1).Put("sw18", ((V)(1D))).V));
SetK(R_1438, j_1517, Object_assign(NewObj(0).V, B_1519, pb_1521, NewObj(1).Put("sw18", ((V)(1D))).V));
return default;
}, 1, "", true));
return R_1438;
return default;
}, 1, "", true));
Set(RD_8, "H18", NewObj(3).Put("DEF18", DEF18_40).Put("toon", toon_43).Put("robot", robot_56).V);
Set(RD_8, "PLUS18", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
