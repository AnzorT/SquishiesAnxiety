// reno-plus9.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus9_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("<ellipse cy=\"0.2\"[^>]*\\/>", "");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("[.@*+]", "");
        public static void Run()
        {
Call(Named(boot_100 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V solid_11 = default;
V box_12 = default;
V cyl_13 = default;
V ball_14 = default;
V arcW_15 = default;
V prism_16 = default;
V prismZ_17 = default;
V f1_18 = default;
V rep_19 = default;
V rng_20 = default;
V n4_21 = default;
V P2_22 = default;
V planeH_23 = default;
V plane_24 = default;
V planeX_25 = default;
V an_26 = default;
V BLUR_27 = default;
V bbOf_28 = default;
V mt_29 = default;
V wd_30 = default;
V cer_31 = default;
V pt_32 = default;
V tex_33 = default;
V atV_34 = default;
V once_35 = default;
V onceT_36 = default;
V G_37 = default;
V L_38 = default;
V ellPts_39 = default;
V lp_40 = default;
V sp_41 = default;
V quad_42 = default;
V planeT_43 = default;
V facing_44 = default;
V tube_45 = default;
V curve_46 = default;
V water_47 = default;
V WP_48 = default;
V WDEF_49 = default;
V FDEF_50 = default;
V smoke_51 = default;
V glowE_52 = default;
V isPlay_53 = default;
V stream_54 = default;
V flames_55 = default;
V fb_56 = default;
V kOf_57 = default;
V LEAF_58 = default;
V LEAFT_59 = default;
V sprinkle_60 = default;
V sway_61 = default;
V flower5_62 = default;
V N_63 = default;
double PI_64 = 0;
V GOLD_65 = default;
V CH_66 = default;
V B_67 = default;
V amo_68 = default;
V amoK_69 = default;
V pathOf_70 = default;
V arc3_71 = default;
V at_72 = default;
V PLATE_73 = default;
V GLASS_74 = default;
V WINE_75 = default;
V BOTTLE_76 = default;
V CANDLE_77 = default;
V BOWL_78 = default;
V SALAD_79 = default;
V BURGERS_80 = default;
V MELON_81 = default;
V CHICKEN_82 = default;
V BREAD_83 = default;
V SUSHI_84 = default;
V CHEESE_85 = default;
V CROISS_86 = default;
V COOKIES_87 = default;
V PITCHER_88 = default;
V PL9_89 = default;
V BALL_90 = default;
V turf_91 = default;
V ballFly_92 = default;
V draw8_93 = default;
V GAME_94 = default;
V edit8_95 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((RD_8 is var _t96 && !Truthy(_t96) ? _t96 : Get(RD_8, "PLUS8")) is var _t97 && !Truthy(_t97) ? _t97 : Get(RD_8, "H8")) is var _t98 && !Truthy(_t98) ? _t98 : X_9) is var _t99 && !Truthy(_t99) ? _t99 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_100.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS9"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t101 = K_10;
if (_t101.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t101));
{ V _t102 = Get(_t101, "solid");
solid_11 = _t102; }
{ V _t103 = Get(_t101, "box");
box_12 = _t103; }
{ V _t104 = Get(_t101, "cyl");
cyl_13 = _t104; }
{ V _t105 = Get(_t101, "ball");
ball_14 = _t105; }
{ V _t106 = Get(_t101, "arcW");
arcW_15 = _t106; }
{ V _t107 = Get(_t101, "prism");
prism_16 = _t107; }
{ V _t108 = Get(_t101, "prismZ");
prismZ_17 = _t108; }
{ V _t109 = Get(_t101, "f1");
f1_18 = _t109; } }
{ V _t110 = Get(RD_8, "H3");
if (_t110.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t110));
{ V _t111 = Get(_t110, "rep");
rep_19 = _t111; }
{ V _t112 = Get(_t110, "rng");
rng_20 = _t112; }
{ V _t113 = Get(_t110, "n4");
n4_21 = _t113; }
{ V _t114 = Get(_t110, "P2");
P2_22 = _t114; }
{ V _t115 = Get(_t110, "planeH");
planeH_23 = _t115; }
{ V _t116 = Get(_t110, "plane");
plane_24 = _t116; }
{ V _t117 = Get(_t110, "planeX");
planeX_25 = _t117; }
{ V _t118 = Get(_t110, "an");
an_26 = _t118; }
{ V _t119 = Get(_t110, "BLUR");
BLUR_27 = _t119; }
{ V _t120 = Get(_t110, "bbOf");
bbOf_28 = _t120; }
{ V _t121 = Get(_t110, "mt");
mt_29 = _t121; }
{ V _t122 = Get(_t110, "wd");
wd_30 = _t122; }
{ V _t123 = Get(_t110, "cer");
cer_31 = _t123; }
{ V _t124 = Get(_t110, "pt");
pt_32 = _t124; }
{ V _t125 = Get(_t110, "tex");
tex_33 = _t125; } }
{ V _t126 = Get(RD_8, "H7");
if (_t126.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t126));
{ V _t127 = Get(_t126, "atV");
atV_34 = _t127; }
{ V _t128 = Get(_t126, "once");
once_35 = _t128; }
{ V _t129 = Get(_t126, "onceT");
onceT_36 = _t129; }
{ V _t130 = Get(_t126, "G");
G_37 = _t130; }
{ V _t131 = Get(_t126, "L");
L_38 = _t131; }
{ V _t132 = Get(_t126, "ellPts");
ellPts_39 = _t132; }
{ V _t133 = Get(_t126, "lp");
lp_40 = _t133; }
{ V _t134 = Get(_t126, "sp");
sp_41 = _t134; }
{ V _t135 = Get(_t126, "quad");
quad_42 = _t135; }
{ V _t136 = Get(_t126, "planeT");
planeT_43 = _t136; }
{ V _t137 = Get(_t126, "facing");
facing_44 = _t137; }
{ V _t138 = Get(_t126, "tube");
tube_45 = _t138; }
{ V _t139 = Get(_t126, "curve");
curve_46 = _t139; }
{ V _t140 = Get(_t126, "water");
water_47 = _t140; }
{ V _t141 = Get(_t126, "WP");
WP_48 = _t141; }
{ V _t142 = Get(_t126, "WDEF");
WDEF_49 = _t142; }
{ V _t143 = Get(_t126, "FDEF");
FDEF_50 = _t143; }
{ V _t144 = Get(_t126, "smoke");
smoke_51 = _t144; }
{ V _t145 = Get(_t126, "glowE");
glowE_52 = _t145; }
{ V _t146 = Get(_t126, "isPlay");
isPlay_53 = _t146; }
{ V _t147 = Get(_t126, "stream");
stream_54 = _t147; }
{ V _t148 = Get(_t126, "flames");
flames_55 = _t148; } }
{ V _t149 = Get(RD_8, "H8");
if (_t149.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t149));
{ V _t150 = Get(_t149, "fb");
fb_56 = _t150; }
{ V _t151 = Get(_t149, "kOf");
kOf_57 = _t151; }
{ V _t152 = Get(_t149, "LEAF");
LEAF_58 = _t152; }
{ V _t153 = Get(_t149, "LEAFT");
LEAFT_59 = _t153; }
{ V _t154 = Get(_t149, "sprinkle");
sprinkle_60 = _t154; }
{ V _t155 = Get(_t149, "sway");
sway_61 = _t155; }
{ V _t156 = Get(_t149, "flower5");
flower5_62 = _t156; } }
N_63 = Get(RD_8, "N");
PI_64 = System.Math.PI;
GOLD_65 = ((V)("#e2b14a"));
CH_66 = ((V)("#d5dde2"));
B_67 = Fn((V _arrowThis164, int _argc157, V b_163, V _a160, V _a161, V _a162, V[] _rest158) => {
return ((V)((Truthy(b_163) ? string.Concat(" begin=\"", ToStr(Call(n4_21, V.Undef, b_163)), "s\"") : "")));
}, 1, "", true);
amo_68 = Fn((V _arrowThis175, int _argc165, V path_171, V d_172, V b_173, V rot_174, V[] _rest166) => {
return ((V)(string.Concat("<animateMotion dur=\"", ToStr(Call(n4_21, V.Undef, d_172)), "s\"", ToStr(Call(B_67, V.Undef, b_173)), " repeatCount=\"indefinite\"", (Truthy(rot_174) ? " rotate=\"auto\"" : ""), " path=\"", ToStr(path_171), "\"/>")));
}, 4, "", true);
amoK_69 = Fn((V _arrowThis186, int _argc176, V path_182, V d_183, V kt_184, V b_185, V[] _rest177) => {
return ((V)(string.Concat("<animateMotion dur=\"", ToStr(Call(n4_21, V.Undef, d_183)), "s\"", ToStr(Call(B_67, V.Undef, b_185)), " repeatCount=\"indefinite\" keyPoints=\"", ToStr(GetIdx(kt_184, 0D)), "\" keyTimes=\"", ToStr(GetIdx(kt_184, 1D)), "\" calcMode=\"linear\" path=\"", ToStr(path_182), "\"/>")));
}, 4, "", true);
pathOf_70 = Fn((V _arrowThis195, int _argc187, V p_193, V pts_194, V _a191, V _a192, V[] _rest188) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_194, "map", Fn((V _arrowThis203, int _argc196, V q_202, V _a199, V _a200, V _a201, V[] _rest197) => {
return Call(P2_22, V.Undef, CallSpread(p_193, V.Undef, new ArrBuilder().Spread(q_202).V));
}, 1, "", true)), "join", ((V)("L")))).End()));
}, 2, "", true);
arc3_71 = Fn((V _arrowThis214, int _argc204, V a_210, V b_211, V h_212, V n_213, V[] _rest205) => {
return Call(rep_19, V.Undef, Add(n_213, ((V)(1D))), Fn((V _arrowThis222, int _argc215, V i_221, V _a218, V _a219, V _a220, V[] _rest216) => {
double t_223 = 0;
t_223 = (ToNum(i_221) / ToNum(n_213));
return Arr(Add(GetIdx(a_210, 0D), ((V)(((ToNum(GetIdx(b_211, 0D)) - ToNum(GetIdx(a_210, 0D))) * t_223)))), Add(Add(GetIdx(a_210, 1D), ((V)(((ToNum(GetIdx(b_211, 1D)) - ToNum(GetIdx(a_210, 1D))) * t_223)))), ((V)((((ToNum(h_212) * 4D) * t_223) * (1D - t_223))))), Add(GetIdx(a_210, 2D), ((V)(((ToNum(GetIdx(b_211, 2D)) - ToNum(GetIdx(a_210, 2D))) * t_223)))));
return default;
}, 1, "", true));
}, 4, "", true);
at_72 = Fn((V _arrowThis237, int _argc224, V p_230, V k_231, V x_232, V y_233, V[] _rest225) => {
V z_234 = default;
V s_235 = default;
V body_236 = default;
z_234 = (_argc224 > 4 ? _rest225[0] : V.Undef);
s_235 = (_argc224 > 5 ? _rest225[1] : V.Undef);
body_236 = (_argc224 > 6 ? _rest225[2] : V.Undef);
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, Call(p_230, V.Undef, x_232, y_233, z_234))), ") scale(", ToStr(Call(n4_21, V.Undef, ((V)((ToNum(k_231) * ToNum((s_235 is var _t238 && Truthy(_t238) ? _t238 : ((V)(1D))))))))), ")\">", ToStr(body_236), "</g>")));
}, 7, "", true);
PLATE_73 = Fn((V _arrowThis247, int _argc239, V r_245, V inner_246, V _a243, V _a244, V[] _rest240) => {
return ((V)(string.Concat("<ellipse cy=\"0.3\" rx=\"", ToStr(Add(r_245, ((V)(0.6)))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(Add(r_245, ((V)(0.6)))) * 0.5))))), "\" fill=\"#000000\" opacity=\"0.15\"/><ellipse rx=\"", ToStr(r_245), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_245) * 0.5))))), "\" fill=\"#fbfaf6\" stroke=\"#c9c3b6\" stroke-width=\"0.3\"/><ellipse rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_245) * 0.72))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_245) * 0.36))))), "\" fill=\"#f1eee6\"/>", ToStr((inner_246 is var _t248 && Truthy(_t248) ? _t248 : ((V)("")))))));
}, 2, "", true);
GLASS_74 = Fn((V _arrowThis257, int _argc249, V col_255, V h_256, V _a253, V _a254, V[] _rest250) => {
h_256 = (h_256 is var _t258 && Truthy(_t258) ? _t258 : ((V)(6D)));
return ((V)(string.Concat("<ellipse cy=\"0.2\" rx=\"2\" ry=\"0.8\" fill=\"#000000\" opacity=\"0.15\"/><path d=\"M-1.8 ", NumStr((-ToNum(h_256))), "H1.8L1.5 0H-1.5Z\" fill=\"", ToStr(col_255), "\" opacity=\"0.85\"/><path d=\"M-1.8 ", NumStr((-ToNum(h_256))), "H1.8L1.5 0H-1.5Z\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.3\" opacity=\"0.8\"/><ellipse cy=\"", NumStr((-ToNum(h_256))), "\" rx=\"1.8\" ry=\"0.6\" fill=\"#ffffff\" opacity=\"0.5\"/><path d=\"M-1 ", NumStr(((-ToNum(h_256)) + 1D)), "V-1\" stroke=\"#ffffff\" stroke-width=\"0.4\" opacity=\"0.6\"/>")));
return default;
}, 2, "", true);
WINE_75 = Fn((V _arrowThis266, int _argc259, V col_265, V _a262, V _a263, V _a264, V[] _rest260) => {
return ((V)(string.Concat("<ellipse cy=\"0.2\" rx=\"1.6\" ry=\"0.6\" fill=\"#000000\" opacity=\"0.15\"/><path d=\"M-1.4 0H1.4M0 0V-3.4\" stroke=\"#e8f4f8\" stroke-width=\"0.5\"/><path d=\"M-1.8 -7.6Q-1.8 -3.4 0 -3.4Q1.8 -3.4 1.8 -7.6Z\" fill=\"#e8f4f8\" opacity=\"0.5\"/><path d=\"M-1.6 -6Q-1.4 -3.8 0 -3.8Q1.4 -3.8 1.6 -6Z\" fill=\"", ToStr(col_265), "\"/>")));
}, 1, "", true);
BOTTLE_76 = Fn((V _arrowThis275, int _argc267, V col_273, V lab_274, V _a271, V _a272, V[] _rest268) => {
return ((V)(string.Concat("<ellipse cy=\"0.2\" rx=\"1.8\" ry=\"0.7\" fill=\"#000000\" opacity=\"0.18\"/><path d=\"M-1.6 0V-6Q-1.6 -7.6 -0.6 -8.4V-11H0.6V-8.4Q1.6 -7.6 1.6 -6V0Z\" fill=\"", ToStr(col_273), "\"/><rect x=\"-1.6\" y=\"-5\" width=\"3.2\" height=\"2.6\" fill=\"", ToStr((lab_274 is var _t276 && Truthy(_t276) ? _t276 : ((V)("#f4efe6")))), "\"/><path d=\"M-0.9 -7.6V-1\" stroke=\"#ffffff\" stroke-width=\"0.4\" opacity=\"0.5\"/><rect x=\"-0.7\" y=\"-11.6\" width=\"1.4\" height=\"0.8\" fill=\"#c9a24a\"/>")));
}, 2, "", true);
CANDLE_77 = Fn((V _arrowThis284, int _argc277, V b_283, V _a280, V _a281, V _a282, V[] _rest278) => {
return ((V)(string.Concat("<rect x=\"-1\" y=\"-5\" width=\"2\" height=\"5\" rx=\"0.4\" fill=\"#fbf6e8\"/><ellipse cy=\"-6.4\" rx=\"0.7\" ry=\"1.4\" fill=\"#ffd27a\">", ToStr(Call(an_26, V.Undef, ((V)("ry")), ((V)("1.2;1.6;1.3;1.5;1.2")), ((V)(0.9)), b_283)), "</ellipse><ellipse cy=\"-6.2\" rx=\"0.3\" ry=\"0.6\" fill=\"#ffffff\"/><circle cy=\"-6\" r=\"3\" fill=\"url(#f7g)\" opacity=\"0.7\"/>")));
}, 1, "", true);
BOWL_78 = Fn((V _arrowThis293, int _argc285, V r_291, V cols_292, V _a289, V _a290, V[] _rest286) => {
return ((V)(string.Concat("<ellipse cy=\"0.4\" rx=\"", ToStr(Add(r_291, ((V)(0.5)))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_291) * 0.42))))), "\" fill=\"#000000\" opacity=\"0.15\"/><path d=\"M", NumStr((-ToNum(r_291))), " -1Q", NumStr((-ToNum(r_291))), " ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_291) * 0.55))))), " 0 ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_291) * 0.55))))), "Q", ToStr(r_291), " ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_291) * 0.55))))), " ", ToStr(r_291), " -1Z\" fill=\"#f4efe6\" stroke=\"#c9c3b6\" stroke-width=\"0.3\"/>", ToStr(Invoke(Invoke(cols_292, "map", Fn((V _arrowThis302, int _argc294, V c_300, V i_301, V _a298, V _a299, V[] _rest295) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, ((V)(((((ToNum(i_301) % 3D) - 1D) * ToNum(r_291)) * 0.42))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)(((-1.6) - (System.Math.Floor((ToNum(i_301) / 3D)) * 1.4)))))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_291) * 0.32))))), "\" fill=\"", ToStr(c_300), "\"/><circle cx=\"", ToStr(Call(f1_18, V.Undef, ((V)((((((ToNum(i_301) % 3D) - 1D) * ToNum(r_291)) * 0.42) - (ToNum(r_291) * 0.1)))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)(((-1.9) - (System.Math.Floor((ToNum(i_301) / 3D)) * 1.4)))))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_291) * 0.1))))), "\" fill=\"#ffffff\" opacity=\"0.5\"/>")));
}, 2, "", true)), "join", ((V)("")))))));
}, 2, "", true);
SALAD_79 = Fn((V _arrowThis310, int _argc303, V r_309, V _a306, V _a307, V _a308, V[] _rest304) => {
return Call(BOWL_78, V.Undef, r_309, Arr(((V)("#7ac050")), ((V)("#9ad86a")), ((V)("#e8343c")), ((V)("#5aa844")), ((V)("#f2c14a")), ((V)("#7ac050"))));
}, 1, "", true);
BURGERS_80 = ((V)(string.Concat(ToStr(Call(PLATE_73, V.Undef, ((V)(6D)), Invoke(Invoke(Arr(Arr(((V)((-2.4))), ((V)((-0.6)))), Arr(((V)(2.2)), ((V)(0.4))), Arr(((V)(0D)), ((V)((-1.6))))), "map", Fn((V _arrowThis322, int _argc311, V _a313, V _a314, V _a315, V _a316, V[] _rest312) => {
V x_319 = default;
V y_321 = default;
{ V _t317 = ListOf(_a313);
{ V _t318 = GetIdx(_t317, 0D);
x_319 = _t318; }
{ V _t320 = GetIdx(_t317, 1D);
y_321 = _t320; }
}
return ((V)(string.Concat("<g transform=\"translate(", ToStr(x_319), " ", ToStr(y_321), ")\"><ellipse rx=\"2.2\" ry=\"1.1\" fill=\"#7a4a2a\"/><ellipse cy=\"-0.6\" rx=\"2.3\" ry=\"1.2\" fill=\"#d89a4a\"/><ellipse cy=\"-0.9\" rx=\"1.2\" ry=\"0.4\" fill=\"#f2c47a\" opacity=\"0.7\"/><path d=\"M-2.1 0H2.1\" stroke=\"#5aa844\" stroke-width=\"0.4\"/></g>")));
}, 1, "", true)), "join", ((V)(""))))), "")));
MELON_81 = ((V)(string.Concat(ToStr(Call(PLATE_73, V.Undef, ((V)(6D)), Invoke(Invoke(Arr(((V)((-2.4))), ((V)(0D)), ((V)(2.4))), "map", Fn((V _arrowThis331, int _argc323, V x_329, V i_330, V _a327, V _a328, V[] _rest324) => {
return ((V)(string.Concat("<path d=\"M", NumStr((ToNum(x_329) - 2D)), " 0.6Q", ToStr(x_329), " -3.2 ", ToStr(Add(x_329, ((V)(2D)))), " 0.6Z\" fill=\"#e8344a\" transform=\"rotate(", NumStr(((ToNum(i_330) - 1D) * 8D)), " ", ToStr(x_329), " 0)\"/><path d=\"M", NumStr((ToNum(x_329) - 2D)), " 0.6Q", ToStr(x_329), " 1.1 ", ToStr(Add(x_329, ((V)(2D)))), " 0.6\" stroke=\"#3f8a34\" stroke-width=\"0.7\" fill=\"none\"/><circle cx=\"", NumStr((ToNum(x_329) - 0.4)), "\" cy=\"-0.6\" r=\"0.18\" fill=\"#1d1e22\"/><circle cx=\"", ToStr(Add(x_329, ((V)(0.5)))), "\" cy=\"-0.2\" r=\"0.18\" fill=\"#1d1e22\"/>")));
}, 2, "", true)), "join", ((V)(""))))), "")));
CHICKEN_82 = ((V)(string.Concat(ToStr(Call(PLATE_73, V.Undef, ((V)(7D)), ((V)("<ellipse cy=\"-1.2\" rx=\"4.4\" ry=\"2.4\" fill=\"#c8782e\"/><ellipse cx=\"-1\" cy=\"-2\" rx=\"2.4\" ry=\"1\" fill=\"#e8a24a\" opacity=\"0.8\"/><path d=\"M3.6 -1.4Q6 -2 6 -0.6\" stroke=\"#c8782e\" stroke-width=\"1.2\" stroke-linecap=\"round\" fill=\"none\"/><circle cx=\"6.2\" cy=\"-0.6\" r=\"0.6\" fill=\"#fbf6e8\"/><circle cx=\"-3\" cy=\"0.6\" r=\"0.7\" fill=\"#5aa844\"/><circle cx=\"3\" cy=\"0.8\" r=\"0.6\" fill=\"#e8343c\"/>")))), "")));
BREAD_83 = ((V)(string.Concat("<ellipse cy=\"0.3\" rx=\"5\" ry=\"1.4\" fill=\"#000000\" opacity=\"0.15\"/><rect x=\"-5.4\" y=\"-0.4\" width=\"10.8\" height=\"1.2\" rx=\"0.4\" fill=\"#a8743a\"/><path d=\"M-4.4 -0.4Q-4.4 -3.4 0 -3.6Q4.4 -3.4 4.4 -0.4Z\" fill=\"#d8954a\"/>", ToStr(Invoke(Invoke(Arr(((V)((-2.4))), ((V)(0D)), ((V)(2.4))), "map", Fn((V _arrowThis339, int _argc332, V x_338, V _a335, V _a336, V _a337, V[] _rest333) => {
return ((V)(string.Concat("<path d=\"M", NumStr((ToNum(x_338) - 0.8)), " -2.6L", ToStr(Add(x_338, ((V)(0.8)))), " -1.4\" stroke=\"#f2c47a\" stroke-width=\"0.4\"/>")));
}, 1, "", true)), "join", ((V)("")))))));
SUSHI_84 = ((V)(string.Concat(ToStr(Call(PLATE_73, V.Undef, ((V)(6.4)), Invoke(Invoke(Arr(((V)((-3D))), ((V)((-1D))), ((V)(1D)), ((V)(3D))), "map", Fn((V _arrowThis348, int _argc340, V x_346, V i_347, V _a344, V _a345, V[] _rest341) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(x_346), " ", NumStr((NumTruthy((ToNum(i_347) % 2D)) ? 0.6 : (-0.6))), ")\"><ellipse rx=\"1.1\" ry=\"0.7\" fill=\"#1d2a1d\"/><ellipse cy=\"-0.4\" rx=\"0.9\" ry=\"0.5\" fill=\"#fbfaf6\"/><ellipse cy=\"-0.5\" rx=\"0.5\" ry=\"0.3\" fill=\"", ToStr(GetK(Arr(((V)("#ff7a5a")), ((V)("#ffb347")), ((V)("#e8344a")), ((V)("#7ac050"))), i_347)), "\"/></g>")));
}, 2, "", true)), "join", ((V)(""))))), "")));
CHEESE_85 = ((V)(string.Concat("<ellipse cy=\"0.3\" rx=\"6\" ry=\"2.6\" fill=\"#000000\" opacity=\"0.15\"/><rect x=\"-6\" y=\"-2.2\" width=\"12\" height=\"4.4\" rx=\"1\" fill=\"#b98a52\" stroke=\"#7a5430\" stroke-width=\"0.3\"/><path d=\"M-4.4 -1L-1.4 -1.6L-2 0.6Z\" fill=\"#f2c14a\"/><path d=\"M-0.6 0.6L2 -1.4L2.6 0.4Z\" fill=\"#f6e6b0\"/><circle cx=\"3.6\" cy=\"-0.6\" r=\"0.6\" fill=\"#7a2a5a\"/><circle cx=\"4.4\" cy=\"0.2\" r=\"0.6\" fill=\"#7a2a5a\"/><circle cx=\"3.8\" cy=\"0.6\" r=\"0.6\" fill=\"#9a3a6a\"/>", "")));
CROISS_86 = ((V)(string.Concat(ToStr(Call(PLATE_73, V.Undef, ((V)(4.6)), Invoke(Invoke(Arr(((V)((-1.6))), ((V)(1.6))), "map", Fn((V _arrowThis356, int _argc349, V x_355, V _a352, V _a353, V _a354, V[] _rest350) => {
return ((V)(string.Concat("<path d=\"M", NumStr((ToNum(x_355) - 2D)), " 0.2Q", ToStr(x_355), " -2.6 ", ToStr(Add(x_355, ((V)(2D)))), " 0.2Q", ToStr(x_355), " -0.6 ", NumStr((ToNum(x_355) - 2D)), " 0.2Z\" fill=\"#d8954a\" stroke=\"#a8743a\" stroke-width=\"0.2\"/>")));
}, 1, "", true)), "join", ((V)(""))))), "")));
COOKIES_87 = ((V)(string.Concat(ToStr(Call(PLATE_73, V.Undef, ((V)(4.4)), Invoke(Invoke(Arr(Arr(((V)((-1.6))), ((V)((-0.4)))), Arr(((V)(1.4)), ((V)((-0.2)))), Arr(((V)(0D)), ((V)((-1.4))))), "map", Fn((V _arrowThis368, int _argc357, V _a359, V _a360, V _a361, V _a362, V[] _rest358) => {
V x_365 = default;
V y_367 = default;
{ V _t363 = ListOf(_a359);
{ V _t364 = GetIdx(_t363, 0D);
x_365 = _t364; }
{ V _t366 = GetIdx(_t363, 1D);
y_367 = _t366; }
}
return ((V)(string.Concat("<ellipse cx=\"", ToStr(x_365), "\" cy=\"", ToStr(y_367), "\" rx=\"1.5\" ry=\"0.8\" fill=\"#c88a4a\"/><circle cx=\"", NumStr((ToNum(x_365) - 0.4)), "\" cy=\"", NumStr((ToNum(y_367) - 0.2)), "\" r=\"0.25\" fill=\"#4a2a18\"/><circle cx=\"", ToStr(Add(x_365, ((V)(0.5)))), "\" cy=\"", ToStr(Add(y_367, ((V)(0.1)))), "\" r=\"0.25\" fill=\"#4a2a18\"/>")));
}, 1, "", true)), "join", ((V)(""))))), "")));
PITCHER_88 = ((V)(string.Concat("<ellipse cy=\"0.3\" rx=\"2.8\" ry=\"1\" fill=\"#000000\" opacity=\"0.15\"/><path d=\"M-2.4 0V-7Q-2.4 -8.4 -1.6 -8.6H2L2.6 -9.4V-8Q2.4 -7 2.4 -6V0Z\" fill=\"#fff2a0\" opacity=\"0.85\"/><path d=\"M-2.4 -8.6H2\" stroke=\"#ffffff\" stroke-width=\"0.4\"/><path d=\"M2.4 -6.6Q4.6 -6 4 -3Q3.6 -1.6 2.4 -1.6\" stroke=\"#e8f4f8\" stroke-width=\"0.7\" fill=\"none\"/><circle cx=\"-0.8\" cy=\"-4\" r=\"0.9\" fill=\"#ffd23a\"/><circle cx=\"0.8\" cy=\"-6\" r=\"0.8\" fill=\"#ffffff\" opacity=\"0.6\"/>", "")));
Set(N_63, "stump8", Fn((V _arrowThis376, int _argc369, V S_375, V _a372, V _a373, V _a374, V[] _rest370) => {
double H_377 = 0;
double R0_378 = 0;
V D_379 = default;
H_377 = 22D;
R0_378 = 13D;
D_379 = NewObj(5).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).Put("topH", ((V)(H_377))).Put("topW", ((V)(16D))).V;
Set(D_379, "build", Fn((V _arrowThis387, int _argc380, V P_386, V _a383, V _a384, V _a385, V[] _rest381) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(R0_378)), ((V)(H_377)), ((V)("#6a4a30")), Call(wd_30, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.4))), Arr(((V)(2D)), ((V)(0D)), ((V)(1.15))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))), Arr(((V)((H_377 - 1D))), ((V)(0D)), ((V)(1D))), Arr(((V)(H_377)), ((V)(0D)), ((V)(0.97))))).V))).Spread(Invoke(Arr(((V)(0.4)), ((V)(2.2)), ((V)(4.1)), ((V)(5.5))), "map", Fn((V _arrowThis396, int _argc388, V a_394, V i_395, V _a392, V _a393, V[] _rest389) => {
return Call(ball_14, V.Undef, ((V)(((FdLibm.Sin(ToNum(a_394)) * R0_378) * 1.2))), ((V)(0D)), ((V)(((FdLibm.Cos(ToNum(a_394)) * R0_378) * 1.2))), ((V)((4D - (ToNum(i_395) % 2D)))), ((V)("#5a3e28")), Call(wd_30, V.Undef, NewObj(5).Put("sx", ((V)(1.4))).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("yaw", ((V)((-ToNum(a_394))))).V));
}, 2, "", true))).V;
}, 1, "", true));
Set(D_379, "fx", Fn((V _arrowThis404, int _argc397, V c_403, V _a400, V _a401, V _a402, V[] _rest398) => {
V p_405 = default;
V k_406 = default;
JsStrBuf f_407 = null;
p_405 = Get(c_403, "p");
k_406 = Get(c_403, "k");
f_407 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(20D)), Fn((V _arrowThis415, int _argc408, V i_414, V _a411, V _a412, V _a413, V[] _rest409) => {
double th_416 = 0;
V pts_417 = default;
th_416 = (((ToNum(i_414) / 20D) * 2D) * PI_64);
if (LtN(Call(facing_44, V.Undef, ((V)(th_416))), 0.05)) {
return default;
}
pts_417 = Call(rep_19, V.Undef, ((V)(6D)), Fn((V _arrowThis425, int _argc418, V j_424, V _a421, V _a422, V _a423, V[] _rest419) => {
return Call(p_405, V.Undef, ((V)(((R0_378 + 0.15) * FdLibm.Sin((th_416 + (FdLibm.Sin(ToNum(Add(j_424, i_414))) * 0.03)))))), ((V)((1.5 + ((ToNum(j_424) * (H_377 - 3D)) / 5D)))), ((V)(((R0_378 + 0.15) * FdLibm.Cos((th_416 + (FdLibm.Sin(ToNum(Add(j_424, i_414))) * 0.03)))))));
}, 1, "", true));
f_407.S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(pts_417, "map", P2_22), "join", ((V)("L")))), "\" fill=\"none\" stroke=\"", (NumTruthy((ToNum(i_414) % 2D)) ? "#3a2818" : "#8a6a4a"), "\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)(((NumTruthy((ToNum(i_414) % 2D)) ? 0.7 : 0.4) * ToNum(k_406)))))), "\" opacity=\"0.75\"/>"));
return default;
}, 1, "", true));
f_407.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_405, ((V)((H_377 + 0.05))))), "\"><circle r=\"", NumStr((R0_378 * 0.97)), "\" fill=\"#d8b07a\"/><circle r=\"", NumStr((R0_378 * 0.97)), "\" fill=\"none\" stroke=\"#7a5030\" stroke-width=\"1.2\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(6D)), Fn((V _arrowThis433, int _argc426, V i_432, V _a429, V _a430, V _a431, V[] _rest427) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.4 + (ToNum(i_432) * 1.8)))))), "\" fill=\"none\" stroke=\"#b08050\" stroke-width=\"0.35\" opacity=\"0.8\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<path d=\"M0 0L9 -4M0 0L-6 7\" stroke=\"#7a5030\" stroke-width=\"0.4\"/></g>"));
f_407.V(Add(Call(at_72, V.Undef, p_405, k_406, ((V)((-3D))), ((V)(H_377)), ((V)(2D)), ((V)(1D)), COOKIES_87), Call(at_72, V.Undef, p_405, k_406, ((V)(4.6)), ((V)(H_377)), ((V)((-2.4))), ((V)(1D)), ((V)(JsStrBuf.Begin().V(Call(GLASS_74, V.Undef, ((V)("#ffd86a")), ((V)(6D)))).S("<circle cx=\"1\" cy=\"-6.2\" r=\"0.9\" fill=\"#ffd23a\"/>").End())))));
return NewObj(3).Put("defs", FDEF_50).Put("front", ((V)(f_407.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_405, V.Undef, ((V)((-20D))), ((V)(0D)), ((V)((-20D)))), Call(p_405, V.Undef, ((V)(20D)), ((V)(0D)), ((V)(20D))), Call(p_405, V.Undef, ((V)((-20D))), ((V)(0D)), ((V)(20D))), Call(p_405, V.Undef, ((V)(20D)), ((V)(0D)), ((V)((-20D)))), Call(p_405, V.Undef, ((V)(0D)), ((V)((H_377 + 10D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_379;
return default;
}, 1, "", true));
Set(N_63, "mosaic8", Fn((V _arrowThis441, int _argc434, V S_440, V _a437, V _a438, V _a439, V[] _rest435) => {
double H_442 = 0;
double R0_443 = 0;
V IR_444 = default;
V D_445 = default;
H_442 = 30D;
R0_443 = 20D;
IR_444 = ((V)("#1f2124"));
D_445 = NewObj(5).Put("w", ((V)(50D))).Put("d", ((V)(50D))).Put("round", ((V)(1D))).Put("topH", ((V)((H_442 + 1.4)))).Put("topW", ((V)(26D))).V;
Set(D_445, "build", Fn((V _arrowThis453, int _argc446, V P_452, V _a449, V _a450, V _a451, V[] _rest447) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(H_442)), ((V)(0D)), ((V)(R0_443)), ((V)(1.6)), ((V)("#e8e2d4")), Call(cer_31, V.Undef, NewObj(1).Put("n", ((V)(30D))).V)), Call(arcW_15, V.Undef, ((V)(0D)), ((V)((H_442 - 0.4))), ((V)(0D)), ((V)((R0_443 + 0.8))), ((V)((R0_443 + 0.8))), ((V)(1.6)), ((V)(2.4)), ((V)(4.4)), ((V)((4.4 + (2D * PI_64)))), IR_444, Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(30D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(1.6)), ((V)((H_442 - 6D))), IR_444, Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(0D)), ((V)(2.6)), ((V)(3D)), IR_444, Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)));
}, 1, "", true));
Set(D_445, "fx", Fn((V _arrowThis461, int _argc454, V c_460, V _a457, V _a458, V _a459, V[] _rest455) => {
V p_462 = default;
V k_463 = default;
JsStrBuf f_464 = null;
JsStrBuf bk_465 = null;
JsStrBuf m_466 = null;
V C_467 = default;
p_462 = Get(c_460, "p");
k_463 = Get(c_460, "k");
f_464 = new JsStrBuf("");
bk_465 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis475, int _argc468, V i_474, V _a471, V _a472, V _a473, V[] _rest469) => {
double th_476 = 0;
V pts_477 = default;
V s_478 = default;
th_476 = ((((ToNum(i_474) / 3D) * 2D) * PI_64) + 0.3);
pts_477 = Invoke(Call(curve_46, V.Undef, Arr(((V)(0D)), ((V)(8D)), ((V)(0D))), Arr(((V)((FdLibm.Sin(th_476) * 10D))), ((V)(4D)), ((V)((FdLibm.Cos(th_476) * 10D)))), Arr(((V)((FdLibm.Sin(th_476) * 16D))), ((V)(0.6)), ((V)((FdLibm.Cos(th_476) * 16D)))), ((V)(6D))), "map", Fn((V _arrowThis486, int _argc479, V q_485, V _a482, V _a483, V _a484, V[] _rest480) => {
return CallSpread(p_462, V.Undef, new ArrBuilder().Spread(q_485).V);
}, 1, "", true));
s_478 = Add(Call(tube_45, V.Undef, pts_477, ((V)(1.4)), k_463, IR_444, ((V)("#6a6e76"))), Call(tube_45, V.Undef, Invoke(Call(rep_19, V.Undef, ((V)(8D)), Fn((V _arrowThis502, int _argc495, V j_501, V _a498, V _a499, V _a500, V[] _rest496) => {
double a_503 = 0;
a_503 = (((ToNum(j_501) / 7D) * 1.6) * PI_64);
return Arr(((V)((FdLibm.Sin(th_476) * (16D + (FdLibm.Cos(a_503) * 1.6))))), ((V)((2.6 + (FdLibm.Sin(a_503) * 1.6)))), ((V)((FdLibm.Cos(th_476) * (16D + (FdLibm.Cos(a_503) * 1.6))))));
return default;
}, 1, "", true)), "map", Fn((V _arrowThis494, int _argc487, V q_493, V _a490, V _a491, V _a492, V[] _rest488) => {
return CallSpread(p_462, V.Undef, new ArrBuilder().Spread(q_493).V);
}, 1, "", true)), ((V)(0.6)), k_463, IR_444, ((V)("#6a6e76"))));
if (GtN(Call(facing_44, V.Undef, ((V)(th_476))), 0D)) {
f_464.V(s_478);
} else {
bk_465.V(s_478);
}
return default;
}, 1, "", true));
m_466 = new JsStrBuf(string.Concat("<circle r=\"", NumStr(R0_443), "\" fill=\"#efe8da\"/>"));
C_467 = Arr(((V)("#2a5aa8")), ((V)("#c4683a")), ((V)("#f2c14a")), ((V)("#fbfaf6")), ((V)("#2fa89a")));
Invoke(Arr(Arr(((V)(3D)), ((V)(6D)), ((V)(0D))), Arr(((V)(7.4)), ((V)(12D)), ((V)(1D))), Arr(((V)(11.6)), ((V)(18D)), ((V)(2D))), Arr(((V)(15.8)), ((V)(24D)), ((V)(3D)))), "forEach", Fn((V _arrowThis517, int _argc504, V _a506, V _a507, V _a508, V _a509, V[] _rest505) => {
V r_512 = default;
V n_514 = default;
V ri_516 = default;
{ V _t510 = ListOf(_a506);
{ V _t511 = GetIdx(_t510, 0D);
r_512 = _t511; }
{ V _t513 = GetIdx(_t510, 1D);
n_514 = _t513; }
{ V _t515 = GetIdx(_t510, 2D);
ri_516 = _t515; }
}
return Call(rep_19, V.Undef, n_514, Fn((V _arrowThis525, int _argc518, V i_524, V _a521, V _a522, V _a523, V[] _rest519) => {
double a_526 = 0;
a_526 = (((ToNum(i_524) / ToNum(n_514)) * 2D) * PI_64);
m_466.S(string.Concat("<rect x=\"-1.4\" y=\"-1.4\" width=\"2.8\" height=\"2.8\" rx=\"0.4\" fill=\"", ToStr(GetIdx(C_467, (ToNum(Add(i_524, ri_516)) % (SEqN(ri_516, 3D) ? 2D : 5D)))), "\" transform=\"translate(", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_512) * FdLibm.Cos(a_526)))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_512) * FdLibm.Sin(a_526)))))), ") rotate(", ToStr(Call(f1_18, V.Undef, ((V)((((a_526 * 180D) / PI_64) + 45D))))), ")\"/>"));
return default;
}, 1, "", true));
}, 1, "", true));
m_466.S(string.Concat("<circle r=\"1.8\" fill=\"#c4683a\"/><circle r=\"", NumStr((R0_443 - 0.3)), "\" fill=\"none\" stroke=\"#2a5aa8\" stroke-width=\"0.8\"/>"));
f_464.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_462, ((V)((H_442 + 1.65))))), "\">", m_466.Str, "</g>")).V(Call(at_72, V.Undef, p_462, k_463, ((V)((-6D))), ((V)((H_442 + 1.6))), ((V)(3D)), ((V)(1D)), CHEESE_85)).V(Call(at_72, V.Undef, p_462, k_463, ((V)(6D)), ((V)((H_442 + 1.6))), ((V)((-4D))), ((V)(1D)), CROISS_86)).V(Call(at_72, V.Undef, p_462, k_463, ((V)(2D)), ((V)((H_442 + 1.6))), ((V)(9D)), ((V)(1D)), Call(GLASS_74, V.Undef, ((V)("#d8b46a")), ((V)(6D))))).V(Call(at_72, V.Undef, p_462, k_463, ((V)((-2D))), ((V)((H_442 + 1.6))), ((V)((-9D))), ((V)(1D)), Call(GLASS_74, V.Undef, ((V)("#ffd86a")), ((V)(6D)))));
return NewObj(4).Put("defs", FDEF_50).Put("back", ((V)(bk_465.Str))).Put("front", ((V)(f_464.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_462, V.Undef, ((V)((-24D))), ((V)(0D)), ((V)((-24D)))), Call(p_462, V.Undef, ((V)(24D)), ((V)(0D)), ((V)(24D))), Call(p_462, V.Undef, ((V)((-24D))), ((V)(0D)), ((V)(24D))), Call(p_462, V.Undef, ((V)(24D)), ((V)(0D)), ((V)((-24D)))), Call(p_462, V.Undef, ((V)(0D)), ((V)((H_442 + 12D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_445;
return default;
}, 1, "", true));
Set(N_63, "limeBench", Fn((V _arrowThis534, int _argc527, V S_533, V _a530, V _a531, V _a532, V[] _rest528) => {
V LS_535 = default;
double R0_536 = 0;
double A0_537 = 0;
double A1_538 = 0;
V D_539 = default;
LS_535 = ((V)("#ddd3bf"));
R0_536 = 60D;
A0_537 = (((-PI_64) / 2D) - 0.62);
A1_538 = (((-PI_64) / 2D) + 0.62);
D_539 = NewObj(3).Put("w", ((V)(90D))).Put("d", ((V)(40D))).Put("seats", Invoke(Arr(NewObj(3).Put("x", ((V)((-18D)))).Put("z", ((V)((-50D)))).Put("h", ((V)(18D))).V, NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)((-54D)))).Put("h", ((V)(18D))).V, NewObj(3).Put("x", ((V)(18D))).Put("z", ((V)((-50D)))).Put("h", ((V)(18D))).V), "map", Fn((V _arrowThis547, int _argc540, V s_546, V _a543, V _a544, V _a545, V[] _rest541) => {
return NewObj(3).Put("x", Get(s_546, "x")).Put("z", Add(Get(s_546, "z"), ((V)(52D)))).Put("h", Get(s_546, "h")).V;
}, 1, "", true))).V;
Set(D_539, "build", Fn((V _arrowThis555, int _argc548, V P_554, V _a551, V _a552, V _a553, V[] _rest549) => {
return new ArrBuilder().Add(Call(arcW_15, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(60D)), ((V)((R0_536 + 6D))), ((V)((R0_536 + 6D))), ((V)(14D)), ((V)(4D)), ((V)(A0_537)), ((V)(A1_538)), LS_535, Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))).Spread(Invoke(Arr(((V)((-0.42))), ((V)(0D)), ((V)(0.42))), "map", Fn((V _arrowThis563, int _argc556, V a_562, V _a559, V _a560, V _a561, V[] _rest557) => {
V t_564 = default;
t_564 = Add(((V)(((-PI_64) / 2D))), a_562);
return Call(box_12, V.Undef, ((V)(((R0_536 - 1D) * FdLibm.Cos(ToNum(t_564))))), ((V)(0D)), ((V)((60D + ((R0_536 - 1D) * FdLibm.Sin(ToNum(t_564)))))), ((V)(9D)), ((V)(14D)), ((V)(11D)), ((V)("#cfc4ae")), Call(pt_32, V.Undef, NewObj(2).Put("r", ((V)(1.2))).Put("yaw", ((V)(((-ToNum(t_564)) - (PI_64 / 2D))))).V));
return default;
}, 1, "", true))).V;
}, 1, "", true));
Set(D_539, "fx", Fn((V _arrowThis572, int _argc565, V c_571, V _a568, V _a569, V _a570, V[] _rest566) => {
V p_573 = default;
V k_574 = default;
JsStrBuf f_575 = null;
V R_576 = default;
p_573 = Get(c_571, "p");
k_574 = Get(c_571, "k");
f_575 = new JsStrBuf("");
Invoke(Arr(((V)((-0.42))), ((V)(0.42))), "forEach", Fn((V _arrowThis584, int _argc577, V a_583, V _a580, V _a581, V _a582, V[] _rest578) => {
V t_585 = default;
V q_586 = default;
t_585 = Add(((V)(((-PI_64) / 2D))), a_583);
q_586 = Call(p_573, V.Undef, ((V)(((R0_536 + 4.6) * FdLibm.Cos(ToNum(t_585))))), ((V)(7D)), ((V)((60D + ((R0_536 + 4.6) * FdLibm.Sin(ToNum(t_585)))))));
f_575.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_586)), ") scale(", ToStr(Call(n4_21, V.Undef, k_574)), ")\"><path d=\"M-2.6 -4C-3.6 -1 -1 1 0 -1C1 1 3.6 -1 2.6 -4\" stroke=\"#a89a80\" stroke-width=\"0.5\" fill=\"none\"/><circle cy=\"2\" r=\"1\" fill=\"none\" stroke=\"#a89a80\" stroke-width=\"0.4\"/></g>"));
return default;
}, 1, "", true));
R_576 = Call(rng_20, V.Undef, ((V)("lich")));
Call(rep_19, V.Undef, ((V)(10D)), Fn((V _arrowThis594, int _argc587, V i_593, V _a590, V _a591, V _a592, V[] _rest588) => {
double t_595 = 0;
V q_596 = default;
t_595 = (A0_537 + (ToNum(Call(R_576, V.Undef)) * (A1_538 - A0_537)));
q_596 = Call(p_573, V.Undef, ((V)(((R0_536 + 6.1) * FdLibm.Cos(t_595)))), ((V)((14.6 + (ToNum(Call(R_576, V.Undef)) * 3D)))), ((V)((60D + ((R0_536 + 6.1) * FdLibm.Sin(t_595))))));
f_575.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q_596, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q_596, 1D))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(Add(((V)(1D)), Call(R_576, V.Undef))) * ToNum(k_574)))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.6 * ToNum(k_574)))))), "\" fill=\"", (NumTruthy((ToNum(i_593) % 2D)) ? "#9aa86a" : "#c8b86a"), "\" opacity=\"0.6\"/>"));
return default;
}, 1, "", true));
f_575.V(Add(Call(at_72, V.Undef, p_573, k_574, ((V)((-22D))), ((V)(18D)), ((V)((-1D))), ((V)(1D)), ((V)(JsStrBuf.Begin().S("<ellipse cy=\"0.3\" rx=\"6\" ry=\"1.6\" fill=\"#000000\" opacity=\"0.15\"/><path d=\"M-5 -5H5L4.2 0H-4.2Z\" fill=\"#c9965a\" stroke=\"#7a5430\" stroke-width=\"0.3\"/>").V(Invoke(Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis604, int _argc597, V j_603, V _a600, V _a601, V _a602, V[] _rest598) => {
return ((V)(string.Concat("<path d=\"M-4.8 ", NumStr(((-3.8) + (ToNum(j_603) * 1.4))), "H4.8\" stroke=\"#9a6a3a\" stroke-width=\"0.35\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M-5 -5H5\" stroke=\"#e8343c\" stroke-width=\"0.8\"/><rect x=\"-5\" y=\"-5.6\" width=\"10\" height=\"1.4\" fill=\"url(#lb8g)\"/><path d=\"M-3.4 -5Q0 -11 3.4 -5\" stroke=\"#9a6a3a\" stroke-width=\"0.8\" fill=\"none\"/>").End()))), Call(at_72, V.Undef, p_573, k_574, ((V)(12D)), ((V)(18D)), ((V)((-1D))), ((V)(1D)), ((V)(JsStrBuf.Begin().S("<ellipse cy=\"0.3\" rx=\"6\" ry=\"2\" fill=\"#000000\" opacity=\"0.15\"/><rect x=\"-6\" y=\"-2\" width=\"12\" height=\"3.6\" rx=\"0.8\" fill=\"#c9a24a\"/><path d=\"M-3.4 0V-4Q-3.4 -6 -1 -6H0.6Q2 -6 2 -4V0Z\" fill=\"#fbfaf6\" stroke=\"#c9c3b6\" stroke-width=\"0.3\"/><path d=\"M2 -4.4Q4 -4.4 3.4 -2.4\" stroke=\"#fbfaf6\" stroke-width=\"0.8\" fill=\"none\"/><path d=\"M-3.4 -3H2\" stroke=\"#2a5aa8\" stroke-width=\"0.5\"/>").V(Invoke(Invoke(Invoke(Invoke(Invoke(Call(GLASS_74, V.Undef, ((V)("#c8782e")), ((V)(3D))), "replace", NewRegExp(RX0, "<ellipse cy=\"0.2\"[^>]*\\/>", ""), ((V)(""))), "split", ((V)(""))), "join", ((V)(""))), "replace", ((V)("M-1.8")), ((V)("M2.6"))), "replace", ((V)("H1.8L1.5 0H-1.5Z")), ((V)("H6.2L5.9 0H3Z")))).End())))));
return NewObj(3).Put("defs", Invoke(Call(L_38, V.Undef, ((V)("lb8g")), Arr(Arr(((V)(0D)), ((V)("#e8343c"))), Arr(((V)(0.5)), ((V)("#ffffff"))), Arr(((V)(1D)), ((V)("#e8343c")))), ((V)("x1=\"0\" y1=\"0\" x2=\"0.2\" y2=\"0\""))), "replace", ((V)("<linearGradient")), ((V)("<linearGradient spreadMethod=\"repeat\"")))).Put("front", ((V)(f_575.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_573, V.Undef, ((V)((-44D))), ((V)(0D)), ((V)((-16D)))), Call(p_573, V.Undef, ((V)(44D)), ((V)(0D)), ((V)((-16D)))), Call(p_573, V.Undef, ((V)((-48D))), ((V)(0D)), ((V)(16D))), Call(p_573, V.Undef, ((V)(48D)), ((V)(0D)), ((V)(16D))), Call(p_573, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D))), Call(p_573, V.Undef, ((V)((-22D))), ((V)(30D)), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_539;
return default;
}, 1, "", true));
Set(N_63, "picnic8", Fn((V _arrowThis612, int _argc605, V S_611, V _a608, V _a609, V _a610, V[] _rest606) => {
V RW_613 = default;
V RW2_614 = default;
double W_615 = 0;
double TY_616 = 0;
V D_617 = default;
RW_613 = ((V)("#9a4a32"));
RW2_614 = ((V)("#b45a3c"));
W_615 = 46D;
TY_616 = 28D;
D_617 = NewObj(5).Put("w", ((V)(110D))).Put("d", ((V)(76D))).Put("topH", ((V)((TY_616 + 2.6)))).Put("topW", ((V)(70D))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-16D)))).Put("z", ((V)(24D))).Put("h", ((V)(17D))).V, NewObj(3).Put("x", ((V)(16D))).Put("z", ((V)(24D))).Put("h", ((V)(17D))).V, NewObj(3).Put("x", ((V)((-16D)))).Put("z", ((V)((-24D)))).Put("h", ((V)(17D))).V, NewObj(3).Put("x", ((V)(16D))).Put("z", ((V)((-24D)))).Put("h", ((V)(17D))).V)).V;
Set(D_617, "build", Fn((V _arrowThis625, int _argc618, V P_624, V _a621, V _a622, V _a623, V[] _rest619) => {
V o_626 = default;
o_626 = Arr();
Call(rep_19, V.Undef, ((V)(5D)), Fn((V _arrowThis634, int _argc627, V i_633, V _a630, V _a631, V _a632, V[] _rest628) => {
return Invoke(o_626, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(TY_616)), ((V)(((-12D) + (ToNum(i_633) * 6D)))), ((V)((2D * W_615))), ((V)(2.6)), ((V)(5.4)), (NumTruthy((ToNum(i_633) % 2D)) ? RW_613 : RW2_614), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis642, int _argc635, V s_641, V _a638, V _a639, V _a640, V[] _rest636) => {
return Call(rep_19, V.Undef, ((V)(2D)), Fn((V _arrowThis650, int _argc643, V i_649, V _a646, V _a647, V _a648, V[] _rest644) => {
return Invoke(o_626, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(15D)), ((V)((ToNum(s_641) * (22D + (ToNum(i_649) * 5.6))))), ((V)(((2D * W_615) - 4D))), ((V)(2.4)), ((V)(5D)), (Truthy(i_649) ? RW_613 : RW2_614), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(((V)(((-W_615) + 8D))), ((V)((W_615 - 8D)))), "forEach", Fn((V _arrowThis658, int _argc651, V x_657, V _a654, V _a655, V _a656, V[] _rest652) => {
Invoke(o_626, "push", Call(prism_16, V.Undef, ((V)((ToNum(x_657) - 1.6))), Add(x_657, ((V)(1.6))), Arr(Arr(((V)((-30D))), ((V)(0D))), Arr(((V)((-26D))), ((V)(0D))), Arr(((V)((-1.6))), ((V)(TY_616))), Arr(((V)(1.6)), ((V)(TY_616))), Arr(((V)(26D)), ((V)(0D))), Arr(((V)(30D)), ((V)(0D))), Arr(((V)(3D)), ((V)((TY_616 + 0.4)))), Arr(((V)((-3D))), ((V)((TY_616 + 0.4))))), RW_613, Call(wd_30, V.Undef, NewObj(0).V)), Call(box_12, V.Undef, x_657, ((V)(12.6)), ((V)(0D)), ((V)(3.4)), ((V)(2.4)), ((V)(60D)), RW_613, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_12, V.Undef, x_657, ((V)(20D)), ((V)(0D)), ((V)(3D)), ((V)(2D)), ((V)(30D)), RW_613, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
return default;
}, 1, "", true));
return o_626;
return default;
}, 1, "", true));
Set(D_617, "fx", Fn((V _arrowThis666, int _argc659, V c_665, V _a662, V _a663, V _a664, V[] _rest660) => {
V p_667 = default;
V k_668 = default;
JsStrBuf f_669 = null;
p_667 = Get(c_665, "p");
k_668 = Get(c_665, "k");
f_669 = new JsStrBuf("");
f_669.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_667, ((V)((TY_616 + 2.65))))), "\"><rect x=\"-26\" y=\"-11\" width=\"52\" height=\"22\" fill=\"url(#pc8g)\" opacity=\"0.92\"/><path d=\"M-26 -11H26M-26 11H26\" stroke=\"#ffffff\" stroke-width=\"0.4\" opacity=\"0.6\"/></g>"));
f_669.V(Add(Add(Add(Add(Add(Add(Call(at_72, V.Undef, p_667, k_668, ((V)((-16D))), ((V)((TY_616 + 2.6))), ((V)((-3D))), ((V)(1D)), MELON_81), Call(at_72, V.Undef, p_667, k_668, ((V)(6D)), ((V)((TY_616 + 2.6))), ((V)((-4D))), ((V)(1D)), BURGERS_80)), Call(at_72, V.Undef, p_667, k_668, ((V)(22D)), ((V)((TY_616 + 2.6))), ((V)(4D)), ((V)(1D)), PITCHER_88)), Call(at_72, V.Undef, p_667, k_668, ((V)((-2D))), ((V)((TY_616 + 2.6))), ((V)(6D)), ((V)(1D)), Call(BOWL_78, V.Undef, ((V)(4D)), Arr(((V)("#f2c14a")), ((V)("#f2c14a")), ((V)("#e8b03a")))))), Call(at_72, V.Undef, p_667, k_668, ((V)((-24D))), ((V)((TY_616 + 2.6))), ((V)(7D)), ((V)(1D)), Call(GLASS_74, V.Undef, ((V)("#fff2a0")), ((V)(5D))))), Call(at_72, V.Undef, p_667, k_668, ((V)(14D)), ((V)((TY_616 + 2.6))), ((V)(9D)), ((V)(1D)), Call(GLASS_74, V.Undef, ((V)("#fff2a0")), ((V)(5D))))), Call(at_72, V.Undef, p_667, k_668, ((V)(30D)), ((V)((TY_616 + 2.6))), ((V)((-6D))), ((V)(1D)), ((V)("<rect x=\"-1.2\" y=\"-8\" width=\"2.4\" height=\"8\" rx=\"0.8\" fill=\"#d8242c\"/><rect x=\"-0.5\" y=\"-9.6\" width=\"1\" height=\"1.6\" fill=\"#ffffff\"/><rect x=\"-1.2\" y=\"-5\" width=\"2.4\" height=\"1.6\" fill=\"#ffffff\"/>")))));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(FDEF_50).S(string.Concat("<pattern id=\"pc8g\" width=\"4\" height=\"4\" patternUnits=\"userSpaceOnUse\"><rect width=\"4\" height=\"4\" fill=\"#fbfaf6\"/><rect width=\"2\" height=\"4\" fill=\"#e8343c\" opacity=\"0.55\"/><rect width=\"4\" height=\"2\" fill=\"#e8343c\" opacity=\"0.55\"/></pattern>", "")).End()))).Put("front", ((V)(f_669.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_667, V.Undef, ((V)(((-W_615) - 2D))), ((V)(0D)), ((V)((-34D)))), Call(p_667, V.Undef, ((V)((W_615 + 2D))), ((V)(0D)), ((V)(34D))), Call(p_667, V.Undef, ((V)(((-W_615) - 2D))), ((V)(0D)), ((V)(34D))), Call(p_667, V.Undef, ((V)((W_615 + 2D))), ((V)(0D)), ((V)((-34D)))), Call(p_667, V.Undef, ((V)(0D)), ((V)((TY_616 + 16D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_617;
return default;
}, 1, "", true));
Set(N_63, "teak8", Fn((V _arrowThis677, int _argc670, V S_676, V _a673, V _a674, V _a675, V[] _rest671) => {
V TK_678 = default;
V TK2_679 = default;
double W_680 = 0;
double DZ_681 = 0;
double TY_682 = 0;
V D_683 = default;
TK_678 = ((V)("#8a5a34"));
TK2_679 = ((V)("#a46e40"));
W_680 = 78D;
DZ_681 = 20D;
TY_682 = 30D;
D_683 = NewObj(4).Put("w", ((V)(170D))).Put("d", ((V)(56D))).Put("topH", ((V)((TY_682 + 4D)))).Put("topW", ((V)(140D))).V;
Set(D_683, "build", Fn((V _arrowThis691, int _argc684, V P_690, V _a687, V _a688, V _a689, V[] _rest685) => {
return new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(TY_682)), ((V)(0D)), ((V)((2D * W_680))), ((V)(4D)), ((V)((2D * DZ_681))), TK2_679, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V))).Spread(Invoke(Arr(((V)(((-W_680) + 10D))), ((V)((W_680 - 10D)))), "map", Fn((V _arrowThis699, int _argc692, V x_698, V _a695, V _a696, V _a697, V[] _rest693) => {
return Call(box_12, V.Undef, x_698, ((V)(0D)), ((V)(0D)), ((V)(7D)), ((V)(TY_682)), ((V)(7D)), TK_678, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V));
}, 1, "", true))).Spread(Invoke(Arr(((V)(((-W_680) + 10D))), ((V)((W_680 - 10D)))), "map", Fn((V _arrowThis707, int _argc700, V x_706, V _a703, V _a704, V _a705, V[] _rest701) => {
return Call(box_12, V.Undef, x_706, ((V)(0D)), ((V)(0D)), ((V)(7D)), ((V)(3D)), ((V)(((2D * DZ_681) - 6D))), TK_678, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V));
}, 1, "", true))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(9D)), ((V)(0D)), ((V)(((2D * W_680) - 26D))), ((V)(4D)), ((V)(4D)), TK_678, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V))).V;
}, 1, "", true));
Set(D_683, "fx", Fn((V _arrowThis715, int _argc708, V c_714, V _a711, V _a712, V _a713, V[] _rest709) => {
V p_716 = default;
V k_717 = default;
JsStrBuf f_718 = null;
V items_719 = default;
V deco_720 = default;
V cand_721 = default;
p_716 = Get(c_714, "p");
k_717 = Get(c_714, "k");
f_718 = new JsStrBuf("");
f_718.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_716, ((V)((TY_682 + 4.05))))), "\">", ToStr(Invoke(Invoke(Arr(((V)((-10D))), ((V)(0D)), ((V)(10D))), "map", Fn((V _arrowThis729, int _argc722, V z_728, V _a725, V _a726, V _a727, V[] _rest723) => {
return ((V)(string.Concat("<path d=\"M", NumStr((-W_680)), " ", ToStr(z_728), "H", NumStr(W_680), "\" stroke=\"#5a3a1e\" stroke-width=\"0.4\" opacity=\"0.7\"/>")));
}, 1, "", true)), "join", ((V)("")))), ToStr(Invoke(Call(rep_19, V.Undef, ((V)(9D)), Fn((V _arrowThis737, int _argc730, V i_736, V _a733, V _a734, V _a735, V[] _rest731) => {
return ((V)(string.Concat("<path d=\"M", NumStr((((-W_680) + 6D) + (ToNum(i_736) * 18D))), " ", NumStr((((-DZ_681) + 2D) + ((ToNum(i_736) % 3D) * 5D))), "q4 -0.6 8 0\" stroke=\"#6a4424\" stroke-width=\"0.3\" fill=\"none\" opacity=\"0.6\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<rect x=\"", NumStr(((-W_680) + 6D)), "\" y=\"-5\" width=\"", NumStr(((2D * W_680) - 12D)), "\" height=\"10\" fill=\"#e8dcc0\" opacity=\"0.92\"/><path d=\"M", NumStr(((-W_680) + 6D)), " -5H", NumStr((W_680 - 6D)), "M", NumStr(((-W_680) + 6D)), " 5H", NumStr((W_680 - 6D)), "\" stroke=\"#8a7a5a\" stroke-width=\"0.4\"/></g>"));
items_719 = Arr(Arr(((V)((-56D))), ((V)(2D)), CHICKEN_82, ((V)(1.1))), Arr(((V)((-34D))), ((V)((-8D))), Call(SALAD_79, V.Undef, ((V)(4.4))), ((V)(1D))), Arr(((V)((-14D))), ((V)(3D)), BREAD_83, ((V)(1.1))), Arr(((V)(8D)), ((V)((-6D))), Call(BOWL_78, V.Undef, ((V)(4.4)), Arr(((V)("#e8343c")), ((V)("#ff8a2a")), ((V)("#9ad86a")), ((V)("#7a2a5a")), ((V)("#f2c14a")))), ((V)(1D))), Arr(((V)(28D)), ((V)(4D)), CHEESE_85, ((V)(1D))), Arr(((V)(50D)), ((V)((-4D))), CHICKEN_82, ((V)(1D))));
deco_720 = Arr(Arr(((V)((-44D))), ((V)(10D)), Call(BOTTLE_76, V.Undef, ((V)("#3a1a24")))), Arr(((V)((-24D))), ((V)(11D)), Call(WINE_75, V.Undef, ((V)("#7a1a2a")))), Arr(((V)((-4D))), ((V)((-12D))), Call(WINE_75, V.Undef, ((V)("#7a1a2a")))), Arr(((V)(18D)), ((V)(12D)), Call(WINE_75, V.Undef, ((V)("#f2d27a")))), Arr(((V)(38D)), ((V)((-12D))), Call(BOTTLE_76, V.Undef, ((V)("#2f5a2a")))), Arr(((V)(62D)), ((V)(10D)), Call(WINE_75, V.Undef, ((V)("#7a1a2a")))));
cand_721 = Arr(Arr(((V)((-46D))), ((V)((-10D)))), Arr(((V)((-2D))), ((V)(10D))), Arr(((V)(40D)), ((V)(12D))));
Invoke(Invoke(Invoke(Invoke(items_719, "concat", deco_720), "concat", Invoke(cand_721, "map", Fn((V _arrowThis776, int _argc764, V _a766, V i_770, V _a768, V _a769, V[] _rest765) => {
V x_773 = default;
V z_775 = default;
{ V _t771 = ListOf(_a766);
{ V _t772 = GetIdx(_t771, 0D);
x_773 = _t772; }
{ V _t774 = GetIdx(_t771, 1D);
z_775 = _t774; }
}
return Arr(x_773, z_775, Call(CANDLE_77, V.Undef, ((V)(((-ToNum(i_770)) * 0.3)))), ((V)(1D)));
}, 2, "", true))), "sort", Fn((V _arrowThis763, int _argc755, V a_761, V b_762, V _a759, V _a760, V[] _rest756) => {
return ((V)((((ToNum(GetIdx(a_761, 0D)) * 0.5) + (ToNum(GetIdx(a_761, 1D)) * 0.866)) - ((ToNum(GetIdx(b_762, 0D)) * 0.5) + (ToNum(GetIdx(b_762, 1D)) * 0.866)))));
}, 2, "", true)), "forEach", Fn((V _arrowThis753, int _argc738, V _a740, V _a741, V _a742, V _a743, V[] _rest739) => {
V x_746 = default;
V z_748 = default;
V body_750 = default;
V s_752 = default;
{ V _t744 = ListOf(_a740);
{ V _t745 = GetIdx(_t744, 0D);
x_746 = _t745; }
{ V _t747 = GetIdx(_t744, 1D);
z_748 = _t747; }
{ V _t749 = GetIdx(_t744, 2D);
body_750 = _t749; }
{ V _t751 = GetIdx(_t744, 3D);
s_752 = _t751; }
}
return ((V)(f_718.V(Call(at_72, V.Undef, p_716, k_717, x_746, ((V)((TY_682 + 4D))), z_748, (s_752 is var _t754 && Truthy(_t754) ? _t754 : ((V)(1D))), body_750)).Str));
}, 1, "", true));
return NewObj(3).Put("defs", FDEF_50).Put("front", ((V)(f_718.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_716, V.Undef, ((V)(((-W_680) - 2D))), ((V)(0D)), ((V)(((-DZ_681) - 2D)))), Call(p_716, V.Undef, ((V)((W_680 + 2D))), ((V)(0D)), ((V)((DZ_681 + 2D)))), Call(p_716, V.Undef, ((V)(((-W_680) - 2D))), ((V)(0D)), ((V)((DZ_681 + 2D)))), Call(p_716, V.Undef, ((V)((W_680 + 2D))), ((V)(0D)), ((V)(((-DZ_681) - 2D)))), Call(p_716, V.Undef, ((V)(0D)), ((V)((TY_682 + 18D))), ((V)(0D))), Call(p_716, V.Undef, ((V)((-W_680))), ((V)((TY_682 + 18D))), ((V)(0D))), Call(p_716, V.Undef, ((V)(W_680)), ((V)((TY_682 + 18D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_683;
return default;
}, 1, "", true));
Set(N_63, "onyx8", Fn((V _arrowThis784, int _argc777, V S_783, V _a780, V _a781, V _a782, V[] _rest778) => {
double W_785 = 0;
double DZ_786 = 0;
double TY_787 = 0;
V BR_788 = default;
V D_789 = default;
W_785 = 74D;
DZ_786 = 22D;
TY_787 = 30D;
BR_788 = ((V)("#8a6a3a"));
D_789 = NewObj(5).Put("w", ((V)(170D))).Put("d", ((V)(60D))).Put("topH", ((V)((TY_787 + 4D)))).Put("topW", ((V)(130D))).Put("glow", Fn((V _arrowThis796, int _argc790, V _a792, V _a793, V _a794, V _a795, V[] _rest791) => {
return NewObj(2).Put("y", ((V)(30D))).Put("r", ((V)(90D))).V;
}, 0, "glow", true)).V;
Set(D_789, "build", Fn((V _arrowThis804, int _argc797, V P_803, V _a800, V _a801, V _a802, V[] _rest798) => {
return new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(TY_787)), ((V)(0D)), ((V)((2D * W_785))), ((V)(4D)), ((V)((2D * DZ_786))), ((V)("#f2c47a")), NewObj(4).Put("mat", ((V)("cer"))).Put("shine", ((V)(1D))).Put("emit", ((V)(1D))).Put("r", ((V)(1D))).V)).Spread(Invoke(Arr(((V)(((-W_785) + 16D))), ((V)((W_785 - 16D)))), "map", Fn((V _arrowThis812, int _argc805, V x_811, V _a808, V _a809, V _a810, V[] _rest806) => {
return Call(box_12, V.Undef, x_811, ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(TY_787)), ((V)(((2D * DZ_786) - 12D))), BR_788, Call(mt_29, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("shine", ((V)(1D))).V));
}, 1, "", true))).Add(Call(cyl_13, V.Undef, ((V)((W_785 + 8D))), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(8D)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V))).V;
}, 1, "", true));
Set(D_789, "fx", Fn((V _arrowThis820, int _argc813, V c_819, V _a816, V _a817, V _a818, V[] _rest814) => {
V p_821 = default;
V k_822 = default;
JsStrBuf f_823 = null;
JsStrBuf un_824 = null;
JsStrBuf o_825 = null;
V R_826 = default;
V Wt_827 = default;
V Wb_828 = default;
V items_829 = default;
p_821 = Get(c_819, "p");
k_822 = Get(c_819, "k");
f_823 = new JsStrBuf("");
un_824 = new JsStrBuf("");
o_825 = new JsStrBuf(string.Concat("<rect x=\"", NumStr((-W_785)), "\" y=\"", NumStr((-DZ_786)), "\" width=\"", NumStr((2D * W_785)), "\" height=\"", NumStr((2D * DZ_786)), "\" fill=\"url(#ox8)\"/>"));
R_826 = Call(rng_20, V.Undef, ((V)("onx")));
Call(rep_19, V.Undef, ((V)(9D)), Fn((V _arrowThis837, int _argc830, V i_836, V _a833, V _a834, V _a835, V[] _rest831) => {
double z_838 = 0;
z_838 = (((-DZ_786) + 3D) + (ToNum(Call(R_826, V.Undef)) * ((2D * DZ_786) - 6D)));
o_825.S(string.Concat("<path d=\"M", NumStr((-W_785)), " ", ToStr(Call(f1_18, V.Undef, ((V)(z_838)))), "Q", ToStr(Call(f1_18, V.Undef, ((V)(((-W_785) / 2D))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((z_838 + ((ToNum(Call(R_826, V.Undef)) - 0.5) * 10D)))))), " 0 ", ToStr(Call(f1_18, V.Undef, ((V)((z_838 + ((ToNum(Call(R_826, V.Undef)) - 0.5) * 6D)))))), "T", NumStr(W_785), " ", ToStr(Call(f1_18, V.Undef, ((V)((z_838 + ((ToNum(Call(R_826, V.Undef)) - 0.5) * 8D)))))), "\" stroke=\"", (NumTruthy((ToNum(i_836) % 2D)) ? "#fff6dc" : "#c8862e"), "\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, Add(((V)(0.4)), Call(R_826, V.Undef)))), "\" fill=\"none\" opacity=\"0.6\"/>"));
return default;
}, 1, "", true));
f_823.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_821, ((V)((TY_787 + 4.05))))), "\">", o_825.Str, "<rect x=\"", NumStr((-W_785)), "\" y=\"-3.4\" width=\"", NumStr((2D * W_785)), "\" height=\"6.8\" fill=\"#2a2b30\"/></g>"));
Wt_827 = Call(water_47, V.Undef, p_821, NewObj(6).Put("sh", NewObj(1).Put("pts", Arr(Arr(((V)(((-W_785) + 2D))), ((V)((-2.6)))), Arr(((V)((W_785 + 1D))), ((V)((-2.6)))), Arr(((V)((W_785 + 1D))), ((V)(2.6))), Arr(((V)(((-W_785) + 2D))), ((V)(2.6))))).V).Put("y", ((V)((TY_787 + 3.4)))).Put("pal", Arr(((V)("#1a6a7a")), ((V)("#2ab4c8")), ((V)("#9af0f8")), ((V)("#ffffff")))).Put("flow", ((V)(1D))).Put("gl", ((V)(6D))).Put("wave", ((V)(0.8))).V);
f_823.V(Get(Wt_827, "svg"));
f_823.V(Invoke(Get(RD_8, "H7"), "fall", p_821, k_822, Arr(Arr(((V)((W_785 + 1D))), ((V)((TY_787 + 3.4))), ((V)((-2.4)))), Arr(((V)((W_785 + 1D))), ((V)((TY_787 + 3.4))), ((V)(0D))), Arr(((V)((W_785 + 1D))), ((V)((TY_787 + 3.4))), ((V)(2.4)))), Arr(Arr(((V)((W_785 + 6D))), ((V)((TY_787 - 4D))), ((V)((-2.4)))), Arr(((V)((W_785 + 6D))), ((V)((TY_787 - 4D))), ((V)(0D))), Arr(((V)((W_785 + 6D))), ((V)((TY_787 - 4D))), ((V)(2.4)))), Arr(Arr(((V)((W_785 + 8D))), ((V)(8D)), ((V)((-3D)))), Arr(((V)((W_785 + 8D))), ((V)(8D)), ((V)(0D))), Arr(((V)((W_785 + 8D))), ((V)(8D)), ((V)(3D)))), NewObj(2).Put("streaks", ((V)(6D))).Put("mw", ((V)(8D))).V));
Wb_828 = Call(water_47, V.Undef, p_821, NewObj(6).Put("sh", NewObj(2).Put("cx", ((V)((W_785 + 8D)))).Put("rx", ((V)(8.6))).V).Put("y", ((V)(7.6))).Put("rim", NewObj(2).Put("y", ((V)(8D))).Put("sh", NewObj(2).Put("cx", ((V)((W_785 + 8D)))).Put("rx", ((V)(8.6))).V).V).Put("pal", Get(WP_48, "lagoon")).Put("rip", Arr(Arr(((V)((W_785 + 8D))), ((V)(0D)), ((V)(6D)), ((V)(1.3)), ((V)(0D))))).Put("gl", ((V)(2D))).V);
f_823.V(Get(Wb_828, "svg"));
items_829 = Arr(Arr(((V)((-54D))), ((V)((-12D))), SUSHI_84), Arr(((V)((-30D))), ((V)(12D)), Call(BOWL_78, V.Undef, ((V)(5D)), Arr(((V)("#ff8a2a")), ((V)("#e8343c")), ((V)("#9ad86a")), ((V)("#7a2a5a")), ((V)("#f2c14a")), ((V)("#ff8a2a"))))), Arr(((V)((-8D))), ((V)((-13D))), CHEESE_85), Arr(((V)(16D)), ((V)(12D)), SUSHI_84), Arr(((V)(40D)), ((V)((-12D))), Call(BOWL_78, V.Undef, ((V)(4.6)), Arr(((V)("#f2c14a")), ((V)("#e8343c")), ((V)("#7a2a5a"))))), Arr(((V)((-44D))), ((V)(13D)), Call(WINE_75, V.Undef, ((V)("#f2d27a")))), Arr(((V)((-20D))), ((V)((-11D))), Call(WINE_75, V.Undef, ((V)("#f2d27a")))), Arr(((V)(4D)), ((V)(13D)), Call(WINE_75, V.Undef, ((V)("#f2d27a")))), Arr(((V)(28D)), ((V)((-13D))), Call(WINE_75, V.Undef, ((V)("#f2d27a")))), Arr(((V)(56D)), ((V)(12D)), Call(CANDLE_77, V.Undef, ((V)(0D)))), Arr(((V)((-62D))), ((V)(10D)), Call(CANDLE_77, V.Undef, ((V)((-0.5))))));
Invoke(Invoke(items_829, "sort", Fn((V _arrowThis861, int _argc853, V a_859, V b_860, V _a857, V _a858, V[] _rest854) => {
return ((V)((((ToNum(GetIdx(a_859, 0D)) * 0.5) + (ToNum(GetIdx(a_859, 1D)) * 0.866)) - ((ToNum(GetIdx(b_860, 0D)) * 0.5) + (ToNum(GetIdx(b_860, 1D)) * 0.866)))));
}, 2, "", true)), "forEach", Fn((V _arrowThis852, int _argc839, V _a841, V _a842, V _a843, V _a844, V[] _rest840) => {
V x_847 = default;
V z_849 = default;
V body_851 = default;
{ V _t845 = ListOf(_a841);
{ V _t846 = GetIdx(_t845, 0D);
x_847 = _t846; }
{ V _t848 = GetIdx(_t845, 1D);
z_849 = _t848; }
{ V _t850 = GetIdx(_t845, 2D);
body_851 = _t850; }
}
return ((V)(f_823.V(Call(at_72, V.Undef, p_821, k_822, x_847, ((V)((TY_787 + 4D))), z_849, ((V)(1D)), body_851)).Str));
}, 1, "", true));
un_824.V(Call(glowE_52, V.Undef, p_821, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((W_785 + 10D))), ((V)((DZ_786 + 14D))), ((V)("#ffc870")), ((V)(0.4)), ((V)(1D))));
return NewObj(4).Put("defs", Add(Add(Add(Add(WDEF_49, FDEF_50), Get(Wt_827, "defs")), Get(Wb_828, "defs")), Call(G_37, V.Undef, ((V)("ox8")), Arr(Arr(((V)(0D)), ((V)("#fff2c8"))), Arr(((V)(0.45)), ((V)("#f8c870"))), Arr(((V)(1D)), ((V)("#d8862e")))), ((V)("cx=\"50%\" cy=\"50%\" r=\"70%\""))))).Put("under", ((V)(un_824.Str))).Put("front", ((V)(f_823.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_821, V.Undef, ((V)(((-W_785) - 2D))), ((V)(0D)), ((V)(((-DZ_786) - 2D)))), Call(p_821, V.Undef, ((V)((W_785 + 20D))), ((V)(0D)), ((V)((DZ_786 + 2D)))), Call(p_821, V.Undef, ((V)(((-W_785) - 2D))), ((V)(0D)), ((V)((DZ_786 + 2D)))), Call(p_821, V.Undef, ((V)((W_785 + 20D))), ((V)(0D)), ((V)(((-DZ_786) - 2D)))), Call(p_821, V.Undef, ((V)(0D)), ((V)((TY_787 + 18D))), ((V)(0D))), Call(p_821, V.Undef, ((V)((-W_785))), ((V)((TY_787 + 16D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_789;
return default;
}, 1, "", true));
Set(N_63, "globe8", Fn((V _arrowThis869, int _argc862, V S_868, V _a865, V _a866, V _a867, V[] _rest863) => {
double GY_870 = 0;
double GR_871 = 0;
V D_872 = default;
GY_870 = 50D;
GR_871 = 16D;
D_872 = NewObj(4).Put("w", ((V)(50D))).Put("d", ((V)(50D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis879, int _argc873, V _a875, V _a876, V _a877, V _a878, V[] _rest874) => {
return NewObj(2).Put("y", ((V)(50D))).Put("r", ((V)(40D))).V;
}, 0, "glow", true)).V;
Set(D_872, "build", Fn((V _arrowThis887, int _argc880, V P_886, V _a883, V _a884, V _a885, V[] _rest881) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(13D)), ((V)(4D)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.86))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(3D)), ((V)(22D)), ((V)("#c9d0d6")), Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(12D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.2))), Arr(((V)(22D)), ((V)(0D)), ((V)(0.8))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(7D)), ((V)(3D)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(29D)), ((V)(0D)), ((V)(5D)), ((V)(1.2)), ((V)("#7ef6ff")), NewObj(2).Put("emit", ((V)(1D))).Put("n", ((V)(16D))).V));
}, 1, "", true));
Set(D_872, "fx", Fn((V _arrowThis895, int _argc888, V c_894, V _a891, V _a892, V _a893, V[] _rest889) => {
V p_896 = default;
V k_897 = default;
JsStrBuf f_898 = null;
JsStrBuf g_899 = null;
V C_900 = default;
double r_901 = 0;
V R_902 = default;
JsStrBuf stars_903 = null;
p_896 = Get(c_894, "p");
k_897 = Get(c_894, "k");
f_898 = new JsStrBuf("");
g_899 = new JsStrBuf("");
C_900 = Call(p_896, V.Undef, ((V)(0D)), ((V)(GY_870)), ((V)(0D)));
r_901 = (GR_871 * ToNum(k_897));
g_899.S(string.Concat("<circle r=\"", ToStr(Call(f1_18, V.Undef, ((V)(r_901)))), "\" fill=\"url(#gb8)\"/>"));
Call(rep_19, V.Undef, ((V)(5D)), Fn((V _arrowThis911, int _argc904, V i_910, V _a907, V _a908, V _a909, V[] _rest905) => {
double ry_912 = 0;
ry_912 = (r_901 * (0.15 + (ToNum(i_910) * 0.2)));
g_899.S(string.Concat("<ellipse rx=\"", ToStr(Call(f1_18, V.Undef, ((V)(System.Math.Sqrt(Max(0D, ((r_901 * r_901) - Pow(((r_901 * (ToNum(i_910) - 2D)) * 0.36), 2D)))))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((ry_912 * 0.25))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)(((r_901 * (ToNum(i_910) - 2D)) * 0.36))))), "\" fill=\"none\" stroke=\"#7ef6ff\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.25 * ToNum(k_897)))))), "\" opacity=\"0.7\"/>"));
return default;
}, 1, "", true));
Call(rep_19, V.Undef, ((V)(6D)), Fn((V _arrowThis920, int _argc913, V i_919, V _a916, V _a917, V _a918, V[] _rest914) => {
return ((V)(g_899.S(string.Concat("<ellipse rx=\"", ToStr(Call(f1_18, V.Undef, ((V)(r_901)))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)(r_901)))), "\" fill=\"none\" stroke=\"#7ef6ff\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.25 * ToNum(k_897)))))), "\" opacity=\"0.6\"><animate attributeName=\"rx\" values=\"", ToStr(Call(f1_18, V.Undef, ((V)(r_901)))), ";", ToStr(Call(f1_18, V.Undef, ((V)((r_901 * 0.02))))), ";", ToStr(Call(f1_18, V.Undef, ((V)(r_901)))), "\" dur=\"8s\"", ToStr(Call(B_67, V.Undef, ((V)((((-ToNum(i_919)) * 8D) / 6D))))), " repeatCount=\"indefinite\"/></ellipse>")).Str));
}, 1, "", true));
R_902 = Call(rng_20, V.Undef, ((V)("gst")));
stars_903 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(18D)), Fn((V _arrowThis928, int _argc921, V i_927, V _a924, V _a925, V _a926, V[] _rest922) => {
double a_929 = 0;
double e_930 = 0;
double x_931 = 0;
double y_932 = 0;
a_929 = ((ToNum(Call(R_902, V.Undef)) * 2D) * PI_64);
e_930 = (((ToNum(Call(R_902, V.Undef)) - 0.5) * PI_64) * 0.9);
x_931 = ((FdLibm.Cos(e_930) * FdLibm.Cos(a_929)) * r_901);
y_932 = (FdLibm.Sin(e_930) * r_901);
stars_903.S(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, ((V)(x_931)))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)(y_932)))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)(((0.4 + (ToNum(Call(R_902, V.Undef)) * 0.5)) * ToNum(k_897)))))), "\" fill=\"#ffffff\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.4;1;0.4")), Call(n4_21, V.Undef, ((V)((1.4 + (ToNum(Call(R_902, V.Undef)) * 2D))))), ((V)(((-ToNum(Call(R_902, V.Undef))) * 2D))))), "</circle>"));
return default;
}, 1, "", true));
g_899.S(string.Concat("<g>", ToStr(Call(atV_34, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)(string.Concat(ToStr(Call(f1_18, V.Undef, ((V)((r_901 * 0.3))))), " 0"))), ((V)("0 0"))), ((V)(8D)))), stars_903.Str, "<path d=\"M", ToStr(Call(f1_18, V.Undef, ((V)(((-r_901) * 0.5))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-r_901) * 0.3))))), "L", ToStr(Call(f1_18, V.Undef, ((V)(((-r_901) * 0.1))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-r_901) * 0.5))))), "L", ToStr(Call(f1_18, V.Undef, ((V)((r_901 * 0.3))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-r_901) * 0.2))))), "L", ToStr(Call(f1_18, V.Undef, ((V)((r_901 * 0.5))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((r_901 * 0.2))))), "\" stroke=\"#bff8ff\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_897)))))), "\" fill=\"none\" opacity=\"0.8\"/></g>"));
g_899.S(string.Concat("<rect x=\"", ToStr(Call(f1_18, V.Undef, ((V)((-r_901))))), "\" y=\"", ToStr(Call(f1_18, V.Undef, ((V)((-r_901))))), "\" width=\"", ToStr(Call(f1_18, V.Undef, ((V)((2D * r_901))))), "\" height=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.2 * ToNum(k_897)))))), "\" fill=\"#bff8ff\" opacity=\"0.35\">", ToStr(Call(an_26, V.Undef, ((V)("y")), ((V)(string.Concat(ToStr(Call(f1_18, V.Undef, ((V)((-r_901))))), ";", ToStr(Call(f1_18, V.Undef, ((V)(r_901))))))), ((V)(2.4)))), "</rect>"));
f_898.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, Call(p_896, V.Undef, ((V)((-4D))), ((V)(30D)), ((V)(0D))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_896, V.Undef, ((V)(((-GR_871) * 0.9))), ((V)(GY_870)), ((V)(0D))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_896, V.Undef, ((V)((GR_871 * 0.9))), ((V)(GY_870)), ((V)(0D))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_896, V.Undef, ((V)(4D)), ((V)(30D)), ((V)(0D))))), "Z\" fill=\"#7ef6ff\" opacity=\"0.14\"/>"));
f_898.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, C_900)), ")\"><g>", ToStr(Call(atV_34, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)(string.Concat("0 ", ToStr(Call(f1_18, V.Undef, ((V)(((-2D) * ToNum(k_897))))))))), ((V)("0 0"))), ((V)(4D)))), "<g clip-path=\"url(#gb8c)\">", g_899.Str, "</g><circle r=\"", ToStr(Call(f1_18, V.Undef, ((V)(r_901)))), "\" fill=\"none\" stroke=\"#bff8ff\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.5 * ToNum(k_897)))))), "\" opacity=\"0.8\"/>", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.85;1;0.7;1;0.85")), ((V)(3D)))), "</g></g>"));
f_898.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, Call(p_896, V.Undef, ((V)(20D)), ((V)(36D)), ((V)(10D))))), ") scale(", ToStr(Call(n4_21, V.Undef, k_897)), ")\"><g>", ToStr(Call(atV_34, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)("0 -2.4")), ((V)("0 0"))), ((V)(3.2)), ((V)((-1D))))), "<ellipse cy=\"5\" rx=\"4\" ry=\"1.2\" fill=\"#7ef6ff\" opacity=\"0.3\"/><path d=\"M-3.6 0Q-4.6 -6 -1.4 -8V-12H1.4V-8Q4.6 -6 3.6 0Z\" fill=\"#e8fbff\" opacity=\"0.45\" stroke=\"#ffffff\" stroke-width=\"0.3\"/><path d=\"M-3.4 -1Q-3.8 -4 -2 -5.4H2Q3.8 -4 3.4 -1Z\" fill=\"#b48aff\" opacity=\"0.7\"/><path d=\"M-1.8 -7V-2\" stroke=\"#ffffff\" stroke-width=\"0.5\" opacity=\"0.7\"/></g></g>"));
f_898.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, Call(p_896, V.Undef, ((V)((-18D))), ((V)(32D)), ((V)(14D))))), ") scale(", ToStr(Call(n4_21, V.Undef, k_897)), ")\"><g>", ToStr(Call(atV_34, V.Undef, ((V)("translate")), Arr(((V)("0 -1")), ((V)("0 1")), ((V)("0 -1"))), ((V)(2.6)))), ToStr(Call(GLASS_74, V.Undef, ((V)("#b48aff")), ((V)(5D)))), "</g></g>"));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(Add(FDEF_50, Call(G_37, V.Undef, ((V)("gb8")), Arr(Arr(((V)(0D)), ((V)("#7ef6ff")), ((V)(0.15))), Arr(((V)(0.7)), ((V)("#2a8aff")), ((V)(0.18))), Arr(((V)(1D)), ((V)("#7ef6ff")), ((V)(0.45)))), ((V)("cx=\"45%\" cy=\"40%\" r=\"60%\""))))).S(string.Concat("<clipPath id=\"gb8c\"><circle r=\"", ToStr(Call(f1_18, V.Undef, ((V)((r_901 + 0.2))))), "\"/></clipPath>")).End()))).Put("front", ((V)(f_898.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_896, V.Undef, ((V)((-24D))), ((V)(0D)), ((V)((-24D)))), Call(p_896, V.Undef, ((V)(24D)), ((V)(0D)), ((V)(24D))), Call(p_896, V.Undef, ((V)((-24D))), ((V)(0D)), ((V)(24D))), Call(p_896, V.Undef, ((V)(24D)), ((V)(0D)), ((V)((-24D)))), Call(p_896, V.Undef, ((V)(0D)), ((V)(((GY_870 + GR_871) + 6D))), ((V)(0D))), Call(p_896, V.Undef, ((V)(((-GR_871) - 4D))), ((V)(GY_870)), ((V)(0D))), Call(p_896, V.Undef, ((V)((GR_871 + 4D))), ((V)(GY_870)), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_872;
return default;
}, 1, "", true));
Set(N_63, "pedestal8", Fn((V _arrowThis940, int _argc933, V S_939, V _a936, V _a937, V _a938, V[] _rest934) => {
double TY_941 = 0;
V D_942 = default;
TY_941 = 34D;
D_942 = NewObj(4).Put("w", ((V)(46D))).Put("d", ((V)(46D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis949, int _argc943, V _a945, V _a946, V _a947, V _a948, V[] _rest944) => {
return NewObj(2).Put("y", ((V)(30D))).Put("r", ((V)(40D))).V;
}, 0, "glow", true)).V;
Set(D_942, "build", Fn((V _arrowThis957, int _argc950, V P_956, V _a953, V _a954, V _a955, V[] _rest951) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(4D)), ((V)("#26272b")), Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.9))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(6D)), ((V)(10D)), ((V)("#2f3136")), Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(16D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.2))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.8))))).V)));
}, 1, "", true));
Set(D_942, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis965, int _argc958, V P_964, V _a961, V _a962, V _a963, V[] _rest959) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)((TY_941 - 3D))), ((V)(0D)), ((V)(14D)), ((V)(3D)), ((V)("#e8ecf0")), Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(3D)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((TY_941 - 3.6))), ((V)(0D)), ((V)(8D)), ((V)(0.6)), ((V)("#7ef6ff")), NewObj(2).Put("emit", ((V)(1D))).Put("n", ((V)(20D))).V));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis974, int _argc966, V p_972, V s_973, V _a970, V _a971, V[] _rest967) => {
V k_975 = default;
V items_976 = default;
k_975 = Call(kOf_57, V.Undef, p_972);
items_976 = Add(Call(at_72, V.Undef, p_972, k_975, ((V)((-4D))), ((V)(TY_941)), ((V)(2D)), ((V)(1D)), ((V)(JsStrBuf.Begin().V(Call(GLASS_74, V.Undef, ((V)("#ff9a3a")), ((V)(7D)))).S("<path d=\"M0.6 -7L2.4 -11\" stroke=\"#ff4fb8\" stroke-width=\"0.4\"/><circle cx=\"-1\" cy=\"-7.2\" r=\"0.9\" fill=\"#ff5a3a\"/>").End()))), Call(at_72, V.Undef, p_972, k_975, ((V)(5D)), ((V)(TY_941)), ((V)((-3D))), ((V)(1D)), Call(WINE_75, V.Undef, ((V)("#7ef6ff")))));
return ((V)(string.Concat("<g>", ToStr(Call(atV_34, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)(string.Concat("0 ", ToStr(Call(f1_18, V.Undef, ((V)(((-3D) * ToNum(k_975))))))))), ((V)("0 0"))), ((V)(3.6)))), ToStr(s_973), ToStr(items_976), "</g>")));
return default;
}, 2, "wrap", true)).V));
Set(D_942, "fx", Fn((V _arrowThis984, int _argc977, V c_983, V _a980, V _a981, V _a982, V[] _rest978) => {
V p_985 = default;
V k_986 = default;
JsStrBuf f_987 = null;
V bk_988 = default;
p_985 = Get(c_983, "p");
k_986 = Get(c_983, "k");
f_987 = new JsStrBuf("");
bk_988 = ((V)(""));
f_987.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_985, ((V)(4.05)))), "\"><circle r=\"14.6\" fill=\"#1a2a4a\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(6D)), Fn((V _arrowThis996, int _argc989, V i_995, V _a992, V _a993, V _a994, V[] _rest990) => {
return ((V)(string.Concat("<path d=\"M", NumStr(((-12D) + (ToNum(i_995) * 4.8))), " -12V12M-12 ", NumStr(((-12D) + (ToNum(i_995) * 4.8))), "H12\" stroke=\"#4a7ad8\" stroke-width=\"0.4\" opacity=\"0.8\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<circle r=\"14.6\" fill=\"url(#pd8)\"/><circle r=\"6.4\" fill=\"#2f3136\"/></g>"));
Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis1004, int _argc997, V i_1003, V _a1000, V _a1001, V _a1002, V[] _rest998) => {
double y_1005 = 0;
y_1005 = (16D + (ToNum(i_1003) * 5D));
f_987.S(string.Concat("<path d=\"", ToStr(Call(sp_41, V.Undef, p_985, Call(ellPts_39, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(9D)), ((V)(9D)), ((V)(30D))), ((V)(y_1005)))), "\" fill=\"none\" stroke=\"#7ef6ff\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.5 * ToNum(k_986)))))), "\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0.8;0\" dur=\"1.8s\"", ToStr(Call(B_67, V.Undef, ((V)(((-ToNum(i_1003)) * 0.6))))), " repeatCount=\"indefinite\"/></path>"));
return default;
}, 1, "", true));
f_987.V(Call(glowE_52, V.Undef, p_985, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(10D)), ((V)(10D)), ((V)("#7ef6ff")), ((V)(0.5)), ((V)(1D))));
return NewObj(4).Put("defs", Add(FDEF_50, Call(G_37, V.Undef, ((V)("pd8")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(0.7)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(0.9)), ((V)("#ffffff")), ((V)(0.25))), Arr(((V)(1D)), ((V)("#ffffff")), ((V)(0D)))), ((V)("cx=\"40%\" cy=\"35%\" r=\"65%\""))))).Put("back", bk_988).Put("front", ((V)(f_987.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_985, V.Undef, ((V)((-20D))), ((V)(0D)), ((V)((-20D)))), Call(p_985, V.Undef, ((V)(20D)), ((V)(0D)), ((V)(20D))), Call(p_985, V.Undef, ((V)((-20D))), ((V)(0D)), ((V)(20D))), Call(p_985, V.Undef, ((V)(20D)), ((V)(0D)), ((V)((-20D)))), Call(p_985, V.Undef, ((V)(0D)), ((V)((TY_941 + 16D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_942;
return default;
}, 1, "", true));
Set(N_63, "tub8", Fn((V _arrowThis1013, int _argc1006, V S_1012, V _a1009, V _a1010, V _a1011, V[] _rest1007) => {
double RX_1014 = 0;
double RZ_1015 = 0;
double H_1016 = 0;
V GV_1017 = default;
V D_1018 = default;
RX_1014 = 24D;
RZ_1015 = 15D;
H_1016 = 18D;
GV_1017 = ((V)("#b8c0c6"));
D_1018 = NewObj(2).Put("w", ((V)(70D))).Put("d", ((V)(44D))).V;
Set(D_1018, "build", Fn((V _arrowThis1026, int _argc1019, V P_1025, V _a1022, V _a1023, V _a1024, V[] _rest1020) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(RX_1014)), ((V)(H_1016)), GV_1017, Call(mt_29, V.Undef, NewObj(4).Put("rz", ((V)(RZ_1015))).Put("n", ((V)(32D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(H_1016)), ((V)(0D)), ((V)(1D))))).V))).Add(Call(arcW_15, V.Undef, ((V)(0D)), ((V)((H_1016 - 1D))), ((V)(0D)), ((V)((RX_1014 + 0.8))), ((V)((RZ_1015 + 0.8))), ((V)(1.4)), ((V)(1.6)), ((V)(4.4)), ((V)((4.4 + (2D * PI_64)))), ((V)("#d5dde2")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(32D))).Put("shine", ((V)(1D))).V))).Spread(Invoke(Arr(((V)(4D)), ((V)(10D))), "map", Fn((V _arrowThis1034, int _argc1027, V y_1033, V _a1030, V _a1031, V _a1032, V[] _rest1028) => {
return Call(arcW_15, V.Undef, ((V)(0D)), y_1033, ((V)(0D)), ((V)(((RX_1014 * (0.9 + ((ToNum(y_1033) / H_1016) * 0.1))) + 0.5))), ((V)(((RZ_1015 * (0.9 + ((ToNum(y_1033) / H_1016) * 0.1))) + 0.5))), ((V)(0.8)), ((V)(1.2)), ((V)(4.4)), ((V)((4.4 + (2D * PI_64)))), ((V)("#9aa3a8")), Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(32D))).V));
}, 1, "", true))).V;
}, 1, "", true));
Set(D_1018, "fx", Fn((V _arrowThis1042, int _argc1035, V c_1041, V _a1038, V _a1039, V _a1040, V[] _rest1036) => {
V p_1043 = default;
V k_1044 = default;
JsStrBuf f_1045 = null;
JsStrBuf ice_1046 = null;
V R_1047 = default;
V nq_1048 = default;
p_1043 = Get(c_1041, "p");
k_1044 = Get(c_1041, "k");
f_1045 = new JsStrBuf("");
ice_1046 = new JsStrBuf(string.Concat("<ellipse rx=\"", NumStr((RX_1014 - 1.4)), "\" ry=\"", NumStr((RZ_1015 - 1.2)), "\" fill=\"#d8eef4\"/>"));
R_1047 = Call(rng_20, V.Undef, ((V)("ice")));
Call(rep_19, V.Undef, ((V)(26D)), Fn((V _arrowThis1056, int _argc1049, V i_1055, V _a1052, V _a1053, V _a1054, V[] _rest1050) => {
double a_1057 = 0;
double r_1058 = 0;
double x_1059 = 0;
double z_1060 = 0;
a_1057 = ((ToNum(Call(R_1047, V.Undef)) * 2D) * PI_64);
r_1058 = System.Math.Sqrt(ToNum(Call(R_1047, V.Undef)));
x_1059 = ((FdLibm.Cos(a_1057) * r_1058) * (RX_1014 - 4D));
z_1060 = ((FdLibm.Sin(a_1057) * r_1058) * (RZ_1015 - 3D));
ice_1046.S(string.Concat("<rect x=\"", ToStr(Call(f1_18, V.Undef, ((V)((x_1059 - 1.6))))), "\" y=\"", ToStr(Call(f1_18, V.Undef, ((V)((z_1060 - 1.4))))), "\" width=\"3.2\" height=\"2.8\" rx=\"0.7\" fill=\"#f4fbff\" stroke=\"#a8d4e4\" stroke-width=\"0.25\" transform=\"rotate(", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(Call(R_1047, V.Undef)) * 90D))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(x_1059)))), " ", ToStr(Call(f1_18, V.Undef, ((V)(z_1060)))), ")\" opacity=\"0.92\"/>"));
return default;
}, 1, "", true));
f_1045.S(string.Concat("<g clip-path=\"url(#tb8c)\"><g transform=\"", ToStr(Call(planeH_23, V.Undef, p_1043, ((V)((H_1016 - 2D))))), "\">", ice_1046.Str, "</g></g>"));
Invoke(Arr(Arr(((V)((-12D))), ((V)((-4D))), Call(BOTTLE_76, V.Undef, ((V)("#3f7a34")), ((V)("#f2c14a"))), ((V)((-12D)))), Arr(((V)((-4D))), ((V)((-6D))), Call(BOTTLE_76, V.Undef, ((V)("#7a4a26")), ((V)("#f4efe6"))), ((V)(6D))), Arr(((V)(6D)), ((V)((-3D))), Call(BOTTLE_76, V.Undef, ((V)("#2f86c8")), ((V)("#ffffff"))), ((V)((-8D)))), Arr(((V)(14D)), ((V)((-5D))), Call(BOTTLE_76, V.Undef, ((V)("#3f7a34")), ((V)("#e8343c"))), ((V)(14D))), Arr(((V)((-8D))), ((V)(4D)), ((V)("<rect x=\"-1.8\" y=\"-6\" width=\"3.6\" height=\"6\" rx=\"0.6\" fill=\"#e8343c\"/><rect x=\"-1.8\" y=\"-4.4\" width=\"3.6\" height=\"1.6\" fill=\"#ffffff\"/>")), ((V)(0D))), Arr(((V)(8D)), ((V)(5D)), ((V)("<rect x=\"-1.8\" y=\"-6\" width=\"3.6\" height=\"6\" rx=\"0.6\" fill=\"#2fa89a\"/><rect x=\"-1.8\" y=\"-4.6\" width=\"3.6\" height=\"2\" fill=\"#f2c14a\"/>")), ((V)(10D)))), "forEach", Fn((V _arrowThis1076, int _argc1061, V _a1063, V _a1064, V _a1065, V _a1066, V[] _rest1062) => {
V x_1069 = default;
V z_1071 = default;
V body_1073 = default;
V rot_1075 = default;
{ V _t1067 = ListOf(_a1063);
{ V _t1068 = GetIdx(_t1067, 0D);
x_1069 = _t1068; }
{ V _t1070 = GetIdx(_t1067, 1D);
z_1071 = _t1070; }
{ V _t1072 = GetIdx(_t1067, 2D);
body_1073 = _t1072; }
{ V _t1074 = GetIdx(_t1067, 3D);
rot_1075 = _t1074; }
}
return ((V)(f_1045.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, Call(p_1043, V.Undef, x_1069, ((V)((H_1016 - 2.6))), z_1071))), ") scale(", ToStr(Call(n4_21, V.Undef, ((V)((ToNum(k_1044) * 1.25))))), ") rotate(", ToStr(rot_1075), ")\">", ToStr(body_1073), "</g>")).Str));
}, 1, "", true));
Call(rep_19, V.Undef, ((V)(9D)), Fn((V _arrowThis1084, int _argc1077, V i_1083, V _a1080, V _a1081, V _a1082, V[] _rest1078) => {
double th_1085 = 0;
V q0_1086 = default;
V q1_1087 = default;
double d_1088 = 0;
th_1085 = (((PI_64 / 6D) - 1D) + (ToNum(i_1083) * 0.25));
q0_1086 = Call(p_1043, V.Undef, ((V)(((RX_1014 * FdLibm.Sin(th_1085)) * 1.01))), ((V)((H_1016 - 2D))), ((V)(((RZ_1015 * FdLibm.Cos(th_1085)) * 1.01))));
q1_1087 = Call(p_1043, V.Undef, ((V)(((RX_1014 * FdLibm.Sin(th_1085)) * 0.92))), ((V)(2D)), ((V)(((RZ_1015 * FdLibm.Cos(th_1085)) * 0.92))));
d_1088 = (2.4 + ((ToNum(i_1083) % 3D) * 0.7));
f_1045.S(string.Concat("<ellipse rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.5 * ToNum(k_1044)))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.7 * ToNum(k_1044)))))), "\" fill=\"#ffffff\" opacity=\"0.8\"><animate attributeName=\"cx\" values=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q0_1086, 0D))), ";", ToStr(Call(f1_18, V.Undef, GetIdx(q1_1087, 0D))), "\" dur=\"", NumStr(d_1088), "s\"", ToStr(Call(B_67, V.Undef, ((V)(((-ToNum(i_1083)) * 0.5))))), " repeatCount=\"indefinite\"/><animate attributeName=\"cy\" values=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q0_1086, 1D))), ";", ToStr(Call(f1_18, V.Undef, GetIdx(q1_1087, 1D))), "\" dur=\"", NumStr(d_1088), "s\"", ToStr(Call(B_67, V.Undef, ((V)(((-ToNum(i_1083)) * 0.5))))), " repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0;0.85;0.85;0\" dur=\"", NumStr(d_1088), "s\"", ToStr(Call(B_67, V.Undef, ((V)(((-ToNum(i_1083)) * 0.5))))), " repeatCount=\"indefinite\"/></ellipse>"));
return default;
}, 1, "", true));
Call(rep_19, V.Undef, ((V)(5D)), Fn((V _arrowThis1096, int _argc1089, V i_1095, V _a1092, V _a1093, V _a1094, V[] _rest1090) => {
double th_1097 = 0;
V q_1098 = default;
th_1097 = (((PI_64 / 6D) - 0.8) + (ToNum(i_1095) * 0.4));
q_1098 = Call(p_1043, V.Undef, ((V)((RX_1014 * FdLibm.Sin(th_1097)))), ((V)(H_1016)), ((V)((RZ_1015 * FdLibm.Cos(th_1097)))));
f_1045.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q_1098, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q_1098, 1D))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((5D * ToNum(k_1044)))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((2D * ToNum(k_1044)))))), "\" fill=\"#ffffff\" filter=\"url(#f7s)\" opacity=\"0\"><animate attributeName=\"cy\" values=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q_1098, 1D))), ";", ToStr(Call(f1_18, V.Undef, Add(GetIdx(q_1098, 1D), ((V)((10D * ToNum(k_1044))))))), "\" dur=\"3.4s\"", ToStr(Call(B_67, V.Undef, ((V)(((-ToNum(i_1095)) * 0.7))))), " repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0;0.5;0\" dur=\"3.4s\"", ToStr(Call(B_67, V.Undef, ((V)(((-ToNum(i_1095)) * 0.7))))), " repeatCount=\"indefinite\"/></ellipse>"));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1106, int _argc1099, V s_1105, V _a1102, V _a1103, V _a1104, V[] _rest1100) => {
return ((V)(f_1045.V(Call(tube_45, V.Undef, Arr(Call(p_1043, V.Undef, ((V)((ToNum(s_1105) * (RX_1014 + 0.6)))), ((V)((H_1016 - 4D))), ((V)(0D))), Call(p_1043, V.Undef, ((V)((ToNum(s_1105) * (RX_1014 + 4D)))), ((V)((H_1016 - 2D))), ((V)(0D))), Call(p_1043, V.Undef, ((V)((ToNum(s_1105) * (RX_1014 + 0.6)))), ((V)(H_1016)), ((V)(0D)))), ((V)(0.9)), k_1044, ((V)("#c9d0d6")))).Str));
}, 1, "", true));
nq_1048 = Call(p_1043, V.Undef, ((V)(34D)), ((V)(0D)), ((V)(10D)));
f_1045.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, nq_1048)), ") scale(", ToStr(Call(n4_21, V.Undef, k_1044)), ")\"><rect x=\"-4\" y=\"-6\" width=\"8\" height=\"6\" rx=\"0.6\" fill=\"#c9d0d6\" stroke=\"#7a8088\" stroke-width=\"0.3\"/><path d=\"M-3.4 -6Q-3 -11 0 -10Q3 -11 3.4 -6Z\" fill=\"url(#tbg)\"/></g>"));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(FDEF_50).S(string.Concat("<clipPath id=\"tb8c\"><path d=\"", ToStr(Call(sp_41, V.Undef, p_1043, Call(ellPts_39, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((RX_1014 - 0.6))), ((V)((RZ_1015 - 0.6))), ((V)(40D))), ((V)(H_1016)))), "\"/></clipPath><pattern id=\"tbg\" width=\"2\" height=\"2\" patternUnits=\"userSpaceOnUse\"><rect width=\"2\" height=\"2\" fill=\"#fbfaf6\"/><rect width=\"1\" height=\"2\" fill=\"#e8343c\" opacity=\"0.5\"/><rect width=\"2\" height=\"1\" fill=\"#e8343c\" opacity=\"0.5\"/></pattern>")).End()))).Put("front", ((V)(f_1045.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1043, V.Undef, ((V)(((-RX_1014) - 6D))), ((V)(0D)), ((V)((-RZ_1015)))), Call(p_1043, V.Undef, ((V)((RX_1014 + 6D))), ((V)(0D)), ((V)(RZ_1015))), Call(p_1043, V.Undef, ((V)(((-RX_1014) - 6D))), ((V)(0D)), ((V)(RZ_1015))), Call(p_1043, V.Undef, ((V)((RX_1014 + 6D))), ((V)(0D)), ((V)((-RZ_1015)))), Call(p_1043, V.Undef, ((V)(0D)), ((V)((H_1016 + 14D))), ((V)(0D))), Call(p_1043, V.Undef, ((V)(40D)), ((V)(0D)), ((V)(12D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1018;
return default;
}, 1, "", true));
Set(N_63, "chime8", Fn((V _arrowThis1114, int _argc1107, V S_1113, V _a1110, V _a1111, V _a1112, V[] _rest1108) => {
V CU_1115 = default;
double HY_1116 = 0;
V D_1117 = default;
CU_1115 = ((V)("#c8783e"));
HY_1116 = 92D;
D_1117 = NewObj(2).Put("w", ((V)(70D))).Put("d", ((V)(40D))).V;
Set(D_1117, "build", Fn((V _arrowThis1125, int _argc1118, V P_1124, V _a1121, V _a1122, V _a1123, V[] _rest1119) => {
return Arr(Call(box_12, V.Undef, ((V)((-20D))), ((V)(0D)), ((V)(0D)), ((V)(3D)), ((V)(64D)), ((V)(3D)), ((V)("#7a5a3a")), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_12, V.Undef, ((V)((-20D))), ((V)(64D)), ((V)(0D)), ((V)(16D)), ((V)(12D)), ((V)(14D)), ((V)("#e8dcc0")), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(prism_16, V.Undef, ((V)((-29D))), ((V)((-11D))), Arr(Arr(((V)((-9D))), ((V)(75D))), Arr(((V)(9D)), ((V)(75D))), Arr(((V)(0D)), ((V)(84D)))), ((V)("#3a6a8a")), Call(wd_30, V.Undef, NewObj(0).V)), Call(box_12, V.Undef, ((V)((-20D))), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(1.2)), ((V)(10D)), ((V)("#5a4632")), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Set(D_1117, "fx", Fn((V _arrowThis1133, int _argc1126, V c_1132, V _a1129, V _a1130, V _a1131, V[] _rest1127) => {
V p_1134 = default;
V k_1135 = default;
JsStrBuf f_1136 = null;
JsStrBuf bk_1137 = null;
V hk_1138 = default;
JsStrBuf ch_1139 = null;
V top_1140 = default;
V cl_1141 = default;
V sl_1142 = default;
p_1134 = Get(c_1132, "p");
k_1135 = Get(c_1132, "k");
f_1136 = new JsStrBuf("");
bk_1137 = new JsStrBuf("");
f_1136.S(string.Concat("<g transform=\"", ToStr(Call(plane_24, V.Undef, p_1134, ((V)(7.05)), ((V)(74D)), ((V)((-28D))))), "\"><circle cx=\"8\" cy=\"5\" r=\"2.2\" fill=\"#2a1c12\"/><rect x=\"7.4\" y=\"7.6\" width=\"1.2\" height=\"3\" fill=\"#7a5a3a\"/><path d=\"M3 2H13\" stroke=\"#c8b898\" stroke-width=\"0.4\"/></g>"));
f_1136.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, Call(p_1134, V.Undef, ((V)((-20D))), ((V)(69D)), ((V)(7.3))))), ") scale(", ToStr(Call(n4_21, V.Undef, k_1135)), ")\"><g>", ToStr(Call(atV_34, V.Undef, ((V)("translate")), Arr(((V)("0 3")), ((V)("0 3")), ((V)("0 0")), ((V)("0 0")), ((V)("0 3"))), ((V)(7D)))), "<circle r=\"1.8\" fill=\"#e8743a\"/><circle cx=\"-0.6\" cy=\"-0.4\" r=\"0.35\" fill=\"#1d1e22\"/><path d=\"M1.4 0L3 0.4L1.4 0.8Z\" fill=\"#f2c14a\"/></g></g>"));
bk_1137.V(Call(tube_45, V.Undef, Invoke(Invoke(Call(curve_46, V.Undef, Arr(((V)(18D)), ((V)(0D)), ((V)(0D))), Arr(((V)(18D)), ((V)(70D)), ((V)(0D))), Arr(((V)(18D)), ((V)(94D)), ((V)(0D))), ((V)(6D))), "concat", Invoke(Call(curve_46, V.Undef, Arr(((V)(18D)), ((V)(94D)), ((V)(0D))), Arr(((V)(18D)), ((V)(102D)), ((V)(0D))), Arr(((V)(8D)), ((V)(98D)), ((V)(0D))), ((V)(5D))), "slice", ((V)(1D)))), "map", Fn((V _arrowThis1150, int _argc1143, V q_1149, V _a1146, V _a1147, V _a1148, V[] _rest1144) => {
return CallSpread(p_1134, V.Undef, new ArrBuilder().Spread(q_1149).V);
}, 1, "", true)), ((V)(1.2)), k_1135, ((V)("#2a2b30")), ((V)("#8a8f98"))));
hk_1138 = Call(p_1134, V.Undef, ((V)(8D)), ((V)(HY_1116)), ((V)(0D)));
ch_1139 = new JsStrBuf(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, hk_1138)), "L", ToStr(Call(P2_22, V.Undef, Call(p_1134, V.Undef, ((V)(8D)), ((V)((HY_1116 - 6D))), ((V)(0D))))), "\" stroke=\"#4a4e56\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1135)))))), "\"/>"));
top_1140 = Call(p_1134, V.Undef, ((V)(8D)), ((V)((HY_1116 - 6D))), ((V)(0D)));
ch_1139.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(top_1140, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(top_1140, 1D))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((6D * ToNum(k_1135)))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((2.2 * ToNum(k_1135)))))), "\" fill=\"", ToStr(CU_1115), "\" stroke=\"#7a3a1a\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1135)))))), "\"/>"));
Call(rep_19, V.Undef, ((V)(6D)), Fn((V _arrowThis1158, int _argc1151, V i_1157, V _a1154, V _a1155, V _a1156, V[] _rest1152) => {
double a_1159 = 0;
double x_1160 = 0;
double z_1161 = 0;
double L0_1162 = 0;
V a0_1163 = default;
V a1_1164 = default;
V b1_1165 = default;
a_1159 = (((ToNum(i_1157) / 6D) * 2D) * PI_64);
x_1160 = (8D + (FdLibm.Cos(a_1159) * 4.6));
z_1161 = (FdLibm.Sin(a_1159) * 4.6);
L0_1162 = (14D + ((ToNum(i_1157) % 3D) * 5D));
a0_1163 = Call(p_1134, V.Undef, ((V)(x_1160)), ((V)((HY_1116 - 6.6))), ((V)(z_1161)));
a1_1164 = Call(p_1134, V.Undef, ((V)(x_1160)), ((V)((HY_1116 - 10D))), ((V)(z_1161)));
b1_1165 = Call(p_1134, V.Undef, ((V)(x_1160)), ((V)(((HY_1116 - 10D) - L0_1162))), ((V)(z_1161)));
ch_1139.S(string.Concat("<g><animateTransform attributeName=\"transform\" type=\"rotate\" values=\"", ToStr(Invoke(Invoke(Arr(((V)((-6D))), ((V)(7D)), ((V)((-4D))), ((V)(5D)), ((V)((-6D)))), "map", Fn((V _arrowThis1173, int _argc1166, V v_1172, V _a1169, V _a1170, V _a1171, V[] _rest1167) => {
return ((V)(JsStrBuf.Begin().N((ToNum(v_1172) * (1D + ((ToNum(i_1157) % 2D) * 0.4)))).S(" ").V(Call(P2_22, V.Undef, a0_1163)).End()));
}, 1, "", true)), "join", ((V)(";")))), "\" dur=\"", ToStr(Call(n4_21, V.Undef, ((V)((2.6 + (ToNum(i_1157) * 0.37)))))), "s\" repeatCount=\"indefinite\" calcMode=\"spline\" keyTimes=\"0;0.25;0.5;0.75;1\" keySplines=\"0.45 0 0.55 1;0.45 0 0.55 1;0.45 0 0.55 1;0.45 0 0.55 1\"/><path d=\"M", ToStr(Call(P2_22, V.Undef, a0_1163)), "L", ToStr(Call(P2_22, V.Undef, a1_1164)), "\" stroke=\"#4a4e56\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.25 * ToNum(k_1135)))))), "\"/><path d=\"M", ToStr(Call(P2_22, V.Undef, a1_1164)), "L", ToStr(Call(P2_22, V.Undef, b1_1165)), "\" stroke=\"#7a3a1a\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.9 * ToNum(k_1135)))))), "\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Call(P2_22, V.Undef, a1_1164)), "L", ToStr(Call(P2_22, V.Undef, b1_1165)), "\" stroke=\"", ToStr(CU_1115), "\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.4 * ToNum(k_1135)))))), "\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Call(P2_22, V.Undef, a1_1164)), "L", ToStr(Call(P2_22, V.Undef, b1_1165)), "\" stroke=\"#ffd0a0\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.4 * ToNum(k_1135)))))), "\" stroke-linecap=\"round\" transform=\"translate(", ToStr(Call(f1_18, V.Undef, ((V)(((-0.4) * ToNum(k_1135)))))), " 0)\"/></g>"));
return default;
}, 1, "", true));
cl_1141 = Call(p_1134, V.Undef, ((V)(8D)), ((V)((HY_1116 - 22D))), ((V)(0D)));
sl_1142 = Call(p_1134, V.Undef, ((V)(8D)), ((V)((HY_1116 - 34D))), ((V)(0D)));
ch_1139.S(string.Concat("<g><animateTransform attributeName=\"transform\" type=\"rotate\" values=\"-10 ", ToStr(Call(P2_22, V.Undef, top_1140)), ";12 ", ToStr(Call(P2_22, V.Undef, top_1140)), ";-10 ", ToStr(Call(P2_22, V.Undef, top_1140)), "\" dur=\"2.2s\" repeatCount=\"indefinite\" calcMode=\"spline\" keyTimes=\"0;0.5;1\" keySplines=\"0.45 0 0.55 1;0.45 0 0.55 1\"/><path d=\"M", ToStr(Call(P2_22, V.Undef, top_1140)), "L", ToStr(Call(P2_22, V.Undef, sl_1142)), "\" stroke=\"#4a4e56\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.25 * ToNum(k_1135)))))), "\"/><ellipse cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(cl_1141, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(cl_1141, 1D))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((2.4 * ToNum(k_1135)))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.9 * ToNum(k_1135)))))), "\" fill=\"#a85a2a\"/><path d=\"M", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(sl_1142, 0D)) - (2.6 * ToNum(k_1135))))))), " ", ToStr(Call(f1_18, V.Undef, GetIdx(sl_1142, 1D))), "L", ToStr(Call(f1_18, V.Undef, Add(GetIdx(sl_1142, 0D), ((V)((2.6 * ToNum(k_1135))))))), " ", ToStr(Call(f1_18, V.Undef, GetIdx(sl_1142, 1D))), "L", ToStr(Call(f1_18, V.Undef, GetIdx(sl_1142, 0D))), " ", ToStr(Call(f1_18, V.Undef, Add(GetIdx(sl_1142, 1D), ((V)((6D * ToNum(k_1135))))))), "Z\" fill=\"", ToStr(CU_1115), "\" stroke=\"#7a3a1a\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1135)))))), "\"/></g>"));
ch_1139.V(Invoke(Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis1181, int _argc1174, V i_1180, V _a1177, V _a1178, V _a1179, V[] _rest1175) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(cl_1141, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(cl_1141, 1D))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((3D * ToNum(k_1135)))))), "\" fill=\"none\" stroke=\"#ffd0a0\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.4 * ToNum(k_1135)))))), "\" opacity=\"0\"><animate attributeName=\"r\" values=\"", ToStr(Call(f1_18, V.Undef, ((V)((3D * ToNum(k_1135)))))), ";", ToStr(Call(f1_18, V.Undef, ((V)((14D * ToNum(k_1135)))))), "\" dur=\"1.1s\"", ToStr(Call(B_67, V.Undef, ((V)((ToNum(i_1180) * 0.73))))), " repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.8;0\" dur=\"1.1s\"", ToStr(Call(B_67, V.Undef, ((V)((ToNum(i_1180) * 0.73))))), " repeatCount=\"indefinite\"/></circle>")));
}, 1, "", true)), "join", ((V)(""))));
f_1136.S(ch_1139.Str);
return NewObj(4).Put("defs", ((V)(""))).Put("back", ((V)(bk_1137.Str))).Put("front", ((V)(f_1136.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1134, V.Undef, ((V)((-30D))), ((V)(0D)), ((V)((-10D)))), Call(p_1134, V.Undef, ((V)(24D)), ((V)(0D)), ((V)(10D))), Call(p_1134, V.Undef, ((V)((-30D))), ((V)(86D)), ((V)(0D))), Call(p_1134, V.Undef, ((V)(24D)), ((V)(104D)), ((V)(0D))), Call(p_1134, V.Undef, ((V)(8D)), ((V)(40D)), ((V)(10D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1117;
return default;
}, 1, "", true));
Set(N_63, "bucket8", Fn((V _arrowThis1189, int _argc1182, V S_1188, V _a1185, V _a1186, V _a1187, V[] _rest1183) => {
V tip_1190 = default;
V OR_1191 = default;
double H_1192 = 0;
double R0_1193 = 0;
V D_1194 = default;
V body_1195 = default;
tip_1190 = Call(isPlay_53, V.Undef, S_1188);
OR_1191 = ((V)("#f27a1a"));
H_1192 = 30D;
R0_1193 = 13D;
D_1194 = NewObj(3).Put("w", ((V)(60D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).V;
body_1195 = Fn((V _arrowThis1202, int _argc1196, V _a1198, V _a1199, V _a1200, V _a1201, V[] _rest1197) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((R0_1193 + 1.2))), ((V)(3D)), ((V)("#e86a10")), Call(pt_32, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(R0_1193)), ((V)((H_1192 - 3D))), OR_1191, Call(pt_32, V.Undef, NewObj(3).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)((H_1192 - 3D))), ((V)(0D)), ((V)(0.84))))).V))).Spread(Invoke(Arr(((V)(6D)), ((V)(9D))), "map", Fn((V _arrowThis1210, int _argc1203, V y_1209, V _a1206, V _a1207, V _a1208, V[] _rest1204) => {
return Call(arcW_15, V.Undef, ((V)(0D)), y_1209, ((V)(0D)), ((V)((R0_1193 + 0.6))), ((V)((R0_1193 + 0.6))), ((V)(0.8)), ((V)(1.2)), ((V)(4.4)), ((V)((4.4 + (2D * PI_64)))), ((V)("#e86a10")), Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(24D))).V));
}, 1, "", true))).V;
}, 0, "", true);
Set(D_1194, "build", Fn((V _arrowThis1218, int _argc1211, V P_1217, V _a1214, V _a1215, V _a1216, V[] _rest1212) => {
return (Truthy(tip_1190) ? Arr() : Call(body_1195, V.Undef));
}, 1, "", true));
if (Truthy(tip_1190)) {
Set(D_1194, "build", Fn((V _arrowThis1226, int _argc1219, V P_1225, V _a1222, V _a1223, V _a1224, V[] _rest1220) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)(0.1)), ((V)(1D)), ((V)("#000000")), NewObj(1).Put("op", ((V)(0D))).V));
}, 1, "", true));
}
Set(D_1194, "layers", (Truthy(tip_1190) ? Arr(NewObj(2).Put("build", body_1195).Put("wrap", Fn((V _arrowThis1235, int _argc1227, V p_1233, V s_1234, V _a1231, V _a1232, V[] _rest1228) => {
V piv_1236 = default;
V k_1237 = default;
V end_1238 = default;
piv_1236 = Call(p_1233, V.Undef, ((V)(R0_1193)), ((V)(0D)), ((V)(0D)));
k_1237 = Call(kOf_57, V.Undef, p_1233);
end_1238 = ((V)(string.Concat("90 ", ToStr(Call(P2_22, V.Undef, piv_1236)))));
return ((V)(JsStrBuf.Begin().V(Invoke(((V)(string.Concat("<g>", ToStr(Call(onceT_36, V.Undef, ((V)("rotate")), ((V)(string.Concat("0 ", ToStr(Call(P2_22, V.Undef, piv_1236)), ";-12 ", ToStr(Call(P2_22, V.Undef, piv_1236)), ";95 ", ToStr(Call(P2_22, V.Undef, piv_1236)), ";86 ", ToStr(Call(P2_22, V.Undef, piv_1236)), ";90 ", ToStr(Call(P2_22, V.Undef, piv_1236))))), ((V)("0;0.2;0.62;0.8;1")), ((V)(1.1)))), "<g transform=\"translate(0 0)\">", ToStr(s_1234), "</g></g>"))), "replace", ((V)("<g transform=\"translate(0 0)\">")), ((V)(string.Concat("<g>", ""))))).S("").End()));
return default;
}, 2, "wrap", true)).V) : Arr()));
Set(D_1194, "fx", Fn((V _arrowThis1246, int _argc1239, V c_1245, V _a1242, V _a1243, V _a1244, V[] _rest1240) => {
V p_1247 = default;
V k_1248 = default;
JsStrBuf f_1249 = null;
JsStrBuf un_1250 = null;
p_1247 = Get(c_1245, "p");
k_1248 = Get(c_1245, "k");
f_1249 = new JsStrBuf("");
un_1250 = new JsStrBuf("");
if (!(Truthy(tip_1190))) {
V q_1251 = default;
q_1251 = Call(p_1247, V.Undef, ((V)(0D)), ((V)(H_1192)), ((V)(0D)));
f_1249.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_1247, ((V)((H_1192 + 0.05))))), "\"><circle r=\"", ToStr(Call(f1_18, V.Undef, ((V)((R0_1193 * 0.84))))), "\" fill=\"#f8923a\"/><circle r=\"", ToStr(Call(f1_18, V.Undef, ((V)((R0_1193 * 0.6))))), "\" fill=\"none\" stroke=\"#d85a08\" stroke-width=\"0.6\"/><text x=\"0\" y=\"1.6\" text-anchor=\"middle\" font-family=\"Arial Black, Arial\" font-size=\"4\" font-weight=\"900\" fill=\"#d85a08\">5 GAL</text></g>"));
_ = q_1251;
} else {
un_1250.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_1247, ((V)(0.3)))), "\"><ellipse cx=\"-14\" cy=\"6\" rx=\"2\" ry=\"1.4\" fill=\"#7ac8e8\" opacity=\"0.7\">", ToStr(Call(once_35, V.Undef, ((V)("rx")), ((V)("2;30;34")), ((V)("0;0.7;1")), ((V)(1.6)), ((V)(0.6)))), ToStr(Call(once_35, V.Undef, ((V)("ry")), ((V)("1.4;14;16")), ((V)("0;0.7;1")), ((V)(1.6)), ((V)(0.6)))), "</ellipse><ellipse cx=\"-14\" cy=\"6\" rx=\"1\" ry=\"1\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0\">", ToStr(Call(once_35, V.Undef, ((V)("opacity")), ((V)("0;0.8;0.3")), ((V)("0;0.3;1")), ((V)(1.8)), ((V)(0.7)))), ToStr(Call(once_35, V.Undef, ((V)("rx")), ((V)("1;24")), ((V)("0;1")), ((V)(1.8)), ((V)(0.7)))), ToStr(Call(once_35, V.Undef, ((V)("ry")), ((V)("1;11")), ((V)("0;1")), ((V)(1.8)), ((V)(0.7)))), "</ellipse></g>"));
Call(rep_19, V.Undef, ((V)(6D)), Fn((V _arrowThis1259, int _argc1252, V i_1258, V _a1255, V _a1256, V _a1257, V[] _rest1253) => {
V a_1260 = default;
V b_1261 = default;
V cc_1262 = default;
a_1260 = Call(p_1247, V.Undef, ((V)((-2D))), ((V)((6D + (ToNum(i_1258) * 1.2)))), ((V)(0D)));
b_1261 = Call(p_1247, V.Undef, ((V)(((-18D) - (ToNum(i_1258) * 3D)))), ((V)(0.3)), ((V)((4D + ((ToNum(i_1258) % 3D) * 3D)))));
cc_1262 = Arr(((V)((ToNum(Add(GetIdx(a_1260, 0D), GetIdx(b_1261, 0D))) / 2D))), ((V)((ToNum(GetIdx(a_1260, 1D)) - (6D * ToNum(k_1248))))));
f_1249.S(string.Concat("<circle r=\"", ToStr(Call(f1_18, V.Undef, ((V)(((0.8 + ((ToNum(i_1258) % 3D) * 0.3)) * ToNum(k_1248)))))), "\" fill=\"#bfe8f8\" opacity=\"0\"><animateMotion dur=\"0.7s\" begin=\"", ToStr(Call(n4_21, V.Undef, ((V)((0.55 + (ToNum(i_1258) * 0.08)))))), "s\" fill=\"freeze\" path=\"M", ToStr(Call(P2_22, V.Undef, a_1260)), "Q", ToStr(Call(f1_18, V.Undef, GetIdx(cc_1262, 0D))), " ", ToStr(Call(f1_18, V.Undef, GetIdx(cc_1262, 1D))), " ", ToStr(Call(P2_22, V.Undef, b_1261)), "\"/>", ToStr(Call(once_35, V.Undef, ((V)("opacity")), ((V)("0;1;0")), ((V)("0;0.3;1")), ((V)(0.7)), ((V)((0.55 + (ToNum(i_1258) * 0.08)))))), "</circle>"));
return default;
}, 1, "", true));
f_1249.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, Call(p_1247, V.Undef, ((V)((-26D))), ((V)(0D)), ((V)(12D))))), ") scale(", ToStr(Call(n4_21, V.Undef, k_1248)), ")\"><g opacity=\"0\">", ToStr(Call(once_35, V.Undef, ((V)("opacity")), ((V)("0;1")), ((V)("0;1")), ((V)(0.2)), ((V)(0.9)))), "<g>", ToStr(Call(onceT_36, V.Undef, ((V)("translate")), ((V)("18 -4;0 0")), ((V)("0;1")), ((V)(0.8)), ((V)(0.9)))), "<rect x=\"-3.4\" y=\"-3\" width=\"6.8\" height=\"3.4\" rx=\"0.8\" fill=\"#f2d23a\"/><rect x=\"-3.4\" y=\"-3.6\" width=\"6.8\" height=\"1.2\" rx=\"0.5\" fill=\"#3f8a34\"/></g></g></g>"));
}
return NewObj(4).Put("defs", ((V)(""))).Put("under", ((V)(un_1250.Str))).Put("front", ((V)(f_1249.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1247, V.Undef, ((V)((-40D))), ((V)(0D)), ((V)((-14D)))), Call(p_1247, V.Undef, ((V)(40D)), ((V)(0D)), ((V)(20D))), Call(p_1247, V.Undef, ((V)((-40D))), ((V)(0D)), ((V)(20D))), Call(p_1247, V.Undef, ((V)(16D)), ((V)((H_1192 + 6D))), ((V)(0D))), Call(p_1247, V.Undef, ((V)((H_1192 + 14D))), ((V)(18D)), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1194;
return default;
}, 1, "", true));
Set(N_63, "zapper8", Fn((V _arrowThis1270, int _argc1263, V S_1269, V _a1266, V _a1267, V _a1268, V[] _rest1264) => {
double BY_1271 = 0;
V D_1272 = default;
BY_1271 = 70D;
D_1272 = NewObj(4).Put("w", ((V)(30D))).Put("d", ((V)(30D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis1279, int _argc1273, V _a1275, V _a1276, V _a1277, V _a1278, V[] _rest1274) => {
return NewObj(2).Put("y", ((V)(BY_1271))).Put("r", ((V)(40D))).V;
}, 0, "glow", true)).V;
Set(D_1272, "build", Fn((V _arrowThis1287, int _argc1280, V P_1286, V _a1283, V _a1284, V _a1285, V[] _rest1281) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(7D)), ((V)(2D)), ((V)("#6a6a6a")), Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)), ((V)(1.8)), ((V)((BY_1271 - 8D))), ((V)("#7a5a3a")), Call(wd_30, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(box_12, V.Undef, ((V)(4D)), ((V)((BY_1271 - 8D))), ((V)(0D)), ((V)(9D)), ((V)(2D)), ((V)(2D)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(cyl_13, V.Undef, ((V)(10D)), ((V)((BY_1271 - 10D))), ((V)(0D)), ((V)(2.6)), ((V)(4D)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
}, 1, "", true));
Set(D_1272, "fx", Fn((V _arrowThis1295, int _argc1288, V c_1294, V _a1291, V _a1292, V _a1293, V[] _rest1289) => {
V p_1296 = default;
V k_1297 = default;
JsStrBuf f_1298 = null;
V q_1299 = default;
V u_1300 = default;
p_1296 = Get(c_1294, "p");
k_1297 = Get(c_1294, "k");
f_1298 = new JsStrBuf("");
q_1299 = Call(p_1296, V.Undef, ((V)(10D)), ((V)((BY_1271 - 13D))), ((V)(0D)));
u_1300 = k_1297;
f_1298.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_1299)), ") scale(", ToStr(Call(n4_21, V.Undef, u_1300)), ")\"><circle cy=\"7\" r=\"16\" fill=\"#7a5aff\" opacity=\"0.18\" filter=\"url(#f7s)\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.14;0.24;0.14")), ((V)(1.6)))), "</circle><path d=\"M-5 0Q-6.4 7 -4 13Q0 16 4 13Q6.4 7 5 0Z\" fill=\"#cfe0ff\" opacity=\"0.55\"/><path d=\"M-4 2Q-5 7 -3 12Q0 14.4 3 12Q5 7 4 2Z\" fill=\"#8a7aff\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.75;1;0.8")), ((V)(0.4)))), "</path>")).V(Invoke(Call(rep_19, V.Undef, ((V)(5D)), Fn((V _arrowThis1308, int _argc1301, V i_1307, V _a1304, V _a1305, V _a1306, V[] _rest1302) => {
return ((V)(string.Concat("<path d=\"M-4 ", NumStr((2.6 + (ToNum(i_1307) * 2.2))), "Q0 ", NumStr((3.6 + (ToNum(i_1307) * 2.2))), " 4 ", NumStr((2.6 + (ToNum(i_1307) * 2.2))), "\" stroke=\"#e8e0ff\" stroke-width=\"0.35\" fill=\"none\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Call(rep_19, V.Undef, ((V)(7D)), Fn((V _arrowThis1316, int _argc1309, V i_1315, V _a1312, V _a1313, V _a1314, V[] _rest1310) => {
return ((V)(string.Concat("<path d=\"M", NumStr(((-5D) + (ToNum(i_1315) * 1.66))), " 0V13\" stroke=\"#3a3c42\" stroke-width=\"0.4\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("<rect x=\"-5.2\" y=\"-1\" width=\"10.4\" height=\"1.6\" rx=\"0.4\" fill=\"#2a2b30\"/><circle cy=\"15.6\" r=\"1\" fill=\"#2a2b30\"/>").S(string.Concat("<g opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0;1;0;0.8;0;0\" keyTimes=\"0;0.6;0.62;0.66;0.68;0.72;1\" dur=\"3.2s\" repeatCount=\"indefinite\"/><circle cy=\"7\" r=\"9\" fill=\"#ffffff\" filter=\"url(#f7b)\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(6D)), Fn((V _arrowThis1324, int _argc1317, V i_1323, V _a1320, V _a1321, V _a1322, V[] _rest1318) => {
double a_1325 = 0;
a_1325 = (((ToNum(i_1323) / 6D) * 2D) * PI_64);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_18, V.Undef, ((V)((FdLibm.Cos(a_1325) * 3D))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((7D + (FdLibm.Sin(a_1325) * 3D)))))), "L", ToStr(Call(f1_18, V.Undef, ((V)((FdLibm.Cos((a_1325 + 0.3)) * 7D))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((7D + (FdLibm.Sin((a_1325 + 0.3)) * 6D)))))), "L", ToStr(Call(f1_18, V.Undef, ((V)((FdLibm.Cos(a_1325) * 10D))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((7D + (FdLibm.Sin(a_1325) * 9D)))))), "\" stroke=\"#ffffff\" stroke-width=\"0.6\" fill=\"none\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))), "<circle cx=\"3\" cy=\"4\" r=\"2.4\" fill=\"#4a4a4a\" opacity=\"0.5\" filter=\"url(#f7b)\"/></g></g>"));
Call(rep_19, V.Undef, ((V)(4D)), Fn((V _arrowThis1333, int _argc1326, V i_1332, V _a1329, V _a1330, V _a1331, V[] _rest1327) => {
double rx_1334 = 0;
double ry_1335 = 0;
double d_1336 = 0;
V pth_1337 = default;
rx_1334 = ((12D + (ToNum(i_1332) * 3D)) * ToNum(k_1297));
ry_1335 = ((6D + (ToNum(i_1332) * 1.6)) * ToNum(k_1297));
d_1336 = (2.6 + (ToNum(i_1332) * 0.7));
pth_1337 = ((V)(string.Concat("M", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(q_1299, 0D)) - rx_1334))))), " ", ToStr(Call(f1_18, V.Undef, Add(GetIdx(q_1299, 1D), ((V)((7D * ToNum(k_1297))))))), "a", ToStr(Call(f1_18, V.Undef, ((V)(rx_1334)))), " ", ToStr(Call(f1_18, V.Undef, ((V)(ry_1335)))), " 0 1 ", NumStr((ToNum(i_1332) % 2D)), " ", ToStr(Call(f1_18, V.Undef, ((V)((2D * rx_1334))))), " 0a", ToStr(Call(f1_18, V.Undef, ((V)(rx_1334)))), " ", ToStr(Call(f1_18, V.Undef, ((V)(ry_1335)))), " 0 1 ", NumStr((ToNum(i_1332) % 2D)), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-2D) * rx_1334))))), " 0")));
f_1298.S(string.Concat("<g>", string.Concat("<animateMotion dur=\"", NumStr(d_1336), "s\" repeatCount=\"indefinite\" path=\"", ToStr(pth_1337), "\"/>"), "<g transform=\"scale(", ToStr(Call(n4_21, V.Undef, k_1297)), ")\"><ellipse rx=\"0.8\" ry=\"0.5\" fill=\"#5a4a3a\"/><path d=\"M0 0L-1.6 -1.4L-0.6 0L-1.6 1.4Z\" fill=\"#cbb89a\" opacity=\"0.85\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.9;0.3;0.9")), ((V)(0.12)))), "</path><path d=\"M0 0L1.6 -1.4L0.6 0L1.6 1.4Z\" fill=\"#cbb89a\" opacity=\"0.85\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.3;0.9;0.3")), ((V)(0.12)))), "</path></g></g>"));
return default;
}, 1, "", true));
return NewObj(3).Put("defs", FDEF_50).Put("front", ((V)(f_1298.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1296, V.Undef, ((V)((-12D))), ((V)(0D)), ((V)((-10D)))), Call(p_1296, V.Undef, ((V)(12D)), ((V)(0D)), ((V)(10D))), Call(p_1296, V.Undef, ((V)((-20D))), ((V)((BY_1271 + 10D))), ((V)(0D))), Call(p_1296, V.Undef, ((V)(36D)), ((V)((BY_1271 + 10D))), ((V)(0D))), Call(p_1296, V.Undef, ((V)(10D)), ((V)((BY_1271 - 30D))), ((V)(0D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1272;
return default;
}, 1, "", true));
Set(N_63, "drones8", Fn((V _arrowThis1345, int _argc1338, V S_1344, V _a1341, V _a1342, V _a1343, V[] _rest1339) => {
V D_1346 = default;
D_1346 = NewObj(4).Put("w", ((V)(80D))).Put("d", ((V)(80D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis1353, int _argc1347, V _a1349, V _a1350, V _a1351, V _a1352, V[] _rest1348) => {
return NewObj(2).Put("y", ((V)(30D))).Put("r", ((V)(60D))).V;
}, 0, "glow", true)).V;
Set(D_1346, "build", Fn((V _arrowThis1361, int _argc1354, V P_1360, V _a1357, V _a1358, V _a1359, V[] _rest1355) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(12D)), ((V)(3D)), ((V)("#26272b")), Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.85))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(8D)), ((V)(1D)), ((V)("#c9ff7a")), NewObj(2).Put("emit", ((V)(1D))).Put("n", ((V)(20D))).V));
}, 1, "", true));
Set(D_1346, "fx", Fn((V _arrowThis1369, int _argc1362, V c_1368, V _a1365, V _a1366, V _a1367, V[] _rest1363) => {
V p_1370 = default;
V k_1371 = default;
JsStrBuf f_1372 = null;
V R_1373 = default;
p_1370 = Get(c_1368, "p");
k_1371 = Get(c_1368, "k");
f_1372 = new JsStrBuf("");
R_1373 = Call(rng_20, V.Undef, ((V)("drn")));
Call(rep_19, V.Undef, ((V)(18D)), Fn((V _arrowThis1381, int _argc1374, V i_1380, V _a1377, V _a1378, V _a1379, V[] _rest1375) => {
double g_1382 = 0;
double cx_1383 = 0;
double cy_1384 = 0;
double ph_1385 = 0;
double rr_1386 = 0;
double d_1387 = 0;
V pts_1388 = default;
V pth_1389 = default;
V col_1390 = default;
g_1382 = (ToNum(i_1380) % 3D);
cx_1383 = 0D;
cy_1384 = (34D + (g_1382 * 10D));
ph_1385 = (((ToNum(i_1380) / 18D) * 2D) * PI_64);
rr_1386 = (18D + (g_1382 * 8D));
d_1387 = (9D + (g_1382 * 3D));
pts_1388 = Call(rep_19, V.Undef, ((V)(25D)), Fn((V _arrowThis1398, int _argc1391, V j_1397, V _a1394, V _a1395, V _a1396, V[] _rest1392) => {
double t_1399 = 0;
t_1399 = (((ToNum(j_1397) / 24D) * 2D) * PI_64);
return Call(p_1370, V.Undef, ((V)((cx_1383 + (FdLibm.Cos((t_1399 + ph_1385)) * rr_1386)))), ((V)((cy_1384 + (FdLibm.Sin(((2D * t_1399) + ph_1385)) * (6D + (g_1382 * 2D)))))), ((V)((((FdLibm.Sin((t_1399 + ph_1385)) * rr_1386) * 0.9) * ((g_1382 == 1D) ? (-1D) : 1D)))));
return default;
}, 1, "", true));
pth_1389 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_1388, "map", P2_22), "join", ((V)("L")))).S("Z").End()));
col_1390 = GetIdx(Arr(((V)("#c9ff7a")), ((V)("#ffe66a")), ((V)("#9af0ff"))), g_1382);
f_1372.S(string.Concat("<g>", ToStr(Call(amo_68, V.Undef, pth_1389, ((V)(d_1387)), ((V)((((-ToNum(i_1380)) * d_1387) / 18D))))), "<circle r=\"", ToStr(Call(f1_18, V.Undef, ((V)((4D * ToNum(k_1371)))))), "\" fill=\"", ToStr(col_1390), "\" opacity=\"0.25\" filter=\"url(#f7b)\"/><g transform=\"scale(", ToStr(Call(n4_21, V.Undef, k_1371)), ")\"><ellipse rx=\"2.2\" ry=\"0.5\" fill=\"#9aa1ad\" opacity=\"0.5\">", ToStr(Call(an_26, V.Undef, ((V)("rx")), ((V)("2.2;1.2;2.2")), ((V)(0.1)))), "</ellipse><circle r=\"0.9\" fill=\"#2a2b30\"/><circle cy=\"0.6\" r=\"0.6\" fill=\"", ToStr(col_1390), "\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("1;0.5;1")), Call(n4_21, V.Undef, Add(((V)(1D)), Call(R_1373, V.Undef))), ((V)((-ToNum(Call(R_1373, V.Undef))))))), "</circle></g></g>"));
return default;
}, 1, "", true));
f_1372.S(string.Concat("<path d=\"", ToStr(Call(sp_41, V.Undef, p_1370, Call(ellPts_39, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(11D)), ((V)(11D)), ((V)(30D))), ((V)(3D)))), "\" fill=\"none\" stroke=\"#c9ff7a\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.6 * ToNum(k_1371)))))), "\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.4;1;0.4")), ((V)(2D)))), "</path>"));
return NewObj(3).Put("defs", FDEF_50).Put("front", ((V)(f_1372.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1370, V.Undef, ((V)((-40D))), ((V)(0D)), ((V)((-40D)))), Call(p_1370, V.Undef, ((V)(40D)), ((V)(0D)), ((V)(40D))), Call(p_1370, V.Undef, ((V)((-40D))), ((V)(70D)), ((V)(0D))), Call(p_1370, V.Undef, ((V)(40D)), ((V)(70D)), ((V)(0D))), Call(p_1370, V.Undef, ((V)(0D)), ((V)(80D)), ((V)(0D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1346;
return default;
}, 1, "", true));
PL9_89 = NewObj(0).V;
BALL_90 = Fn((V _arrowThis1408, int _argc1400, V r_1406, V kind_1407, V _a1404, V _a1405, V[] _rest1401) => {
return ((V)((SEqS(kind_1407, "soccer") ? string.Concat("<circle r=\"", ToStr(r_1406), "\" fill=\"#fbfbf6\" stroke=\"#1d1e22\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.08))))), "\"/><path d=\"M0 ", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.38))))), "L", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.36))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.12))))), "L", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.22))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.3))))), "L", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.22))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.3))))), "L", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.36))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.12))))), "Z\" fill=\"#1d1e22\"/><circle cx=\"", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.35))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.4))))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.25))))), "\" fill=\"#ffffff\" opacity=\"0.5\"/>") : (SEqS(kind_1407, "bball") ? string.Concat("<circle r=\"", ToStr(r_1406), "\" fill=\"#e8742a\" stroke=\"#5a2a10\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.08))))), "\"/><path d=\"M", NumStr((-ToNum(r_1406))), " 0H", ToStr(r_1406), "M0 ", NumStr((-ToNum(r_1406))), "V", ToStr(r_1406), "M", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.7))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.7))))), "Q0 0 ", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.7))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.7))))), "M", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.7))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.7))))), "Q0 0 ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.7))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.7))))), "\" stroke=\"#5a2a10\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.08))))), "\" fill=\"none\"/>") : (SEqS(kind_1407, "tennis") ? string.Concat("<circle r=\"", ToStr(r_1406), "\" fill=\"#d8f23a\" stroke=\"#8aa81a\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.08))))), "\"/><path d=\"M", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.8))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.5))))), "Q0 ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.2))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.8))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.5))))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.12))))), "\" fill=\"none\"/>") : string.Concat("<circle r=\"", ToStr(r_1406), "\" fill=\"", ToStr((kind_1407 is var _t1409 && Truthy(_t1409) ? _t1409 : ((V)("#ffffff")))), "\" stroke=\"#4a4a4a\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.08))))), "\"/><circle cx=\"", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.35))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)(((-ToNum(r_1406)) * 0.35))))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(r_1406) * 0.3))))), "\" fill=\"#ffffff\" opacity=\"0.55\"/>"))))));
}, 2, "", true);
turf_91 = Fn((V _arrowThis1423, int _argc1410, V p_1416, V x_1417, V z_1418, V hx_1419, V[] _rest1411) => {
V hz_1420 = default;
V c1_1421 = default;
V c2_1422 = default;
hz_1420 = (_argc1410 > 4 ? _rest1411[0] : V.Undef);
c1_1421 = (_argc1410 > 5 ? _rest1411[1] : V.Undef);
c2_1422 = (_argc1410 > 6 ? _rest1411[2] : V.Undef);
return ((V)(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_1416, ((V)(0.3)))), "\"><rect x=\"", NumStr((ToNum(x_1417) - ToNum(hx_1419))), "\" y=\"", NumStr((ToNum(z_1418) - ToNum(hz_1420))), "\" width=\"", NumStr((2D * ToNum(hx_1419))), "\" height=\"", NumStr((2D * ToNum(hz_1420))), "\" rx=\"3\" fill=\"", ToStr(c1_1421), "\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(System.Math.Floor((ToNum(hx_1419) / 6D)))), Fn((V _arrowThis1431, int _argc1424, V i_1430, V _a1427, V _a1428, V _a1429, V[] _rest1425) => {
return ((V)((NumTruthy((ToNum(i_1430) % 2D)) ? "" : string.Concat("<rect x=\"", NumStr(((ToNum(x_1417) - ToNum(hx_1419)) + (ToNum(i_1430) * 12D))), "\" y=\"", NumStr((ToNum(z_1418) - ToNum(hz_1420))), "\" width=\"12\" height=\"", NumStr((2D * ToNum(hz_1420))), "\" fill=\"", ToStr(c2_1422), "\" opacity=\"0.5\"/>"))));
}, 1, "", true)), "join", ((V)("")))), "</g>")));
}, 7, "", true);
ballFly_92 = Fn((V _arrowThis1445, int _argc1432, V p_1438, V k_1439, V pts_1440, V d_1441, V[] _rest1433) => {
V body_1442 = default;
V s_1443 = default;
V b_1444 = default;
body_1442 = (_argc1432 > 4 ? _rest1433[0] : V.Undef);
s_1443 = (_argc1432 > 5 ? _rest1433[1] : V.Undef);
b_1444 = (_argc1432 > 6 ? _rest1433[2] : V.Undef);
return ((V)(string.Concat("<g>", ToStr(Call(amo_68, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_1440, "map", Fn((V _arrowThis1453, int _argc1446, V q_1452, V _a1449, V _a1450, V _a1451, V[] _rest1447) => {
return Call(P2_22, V.Undef, CallSpread(p_1438, V.Undef, new ArrBuilder().Spread(q_1452).V));
}, 1, "", true)), "join", ((V)("L")))).End())), d_1441, b_1444)), "<g transform=\"scale(", ToStr(Call(n4_21, V.Undef, ((V)((ToNum(k_1439) * ToNum((s_1443 is var _t1454 && Truthy(_t1454) ? _t1454 : ((V)(1D))))))))), ")\">", ToStr(body_1442), "</g></g>")));
}, 7, "", true);
Set(N_63, "goal8", Fn((V _arrowThis1462, int _argc1455, V S_1461, V _a1458, V _a1459, V _a1460, V[] _rest1456) => {
double W_1463 = 0;
double H_1464 = 0;
double DP_1465 = 0;
V pl_1466 = default;
V D_1467 = default;
W_1463 = 44D;
H_1464 = 32D;
DP_1465 = 22D;
pl_1466 = Call(isPlay_53, V.Undef, S_1461);
D_1467 = NewObj(2).Put("w", ((V)(140D))).Put("d", ((V)(120D))).V;
Set(D_1467, "build", Fn((V _arrowThis1475, int _argc1468, V P_1474, V _a1471, V _a1472, V _a1473, V[] _rest1469) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(0.1)), ((V)(2D)), ((V)("#ffffff")), NewObj(1).Put("op", ((V)(0D))).V));
}, 1, "", true));
Set(D_1467, "fx", Fn((V _arrowThis1483, int _argc1476, V c_1482, V _a1479, V _a1480, V _a1481, V[] _rest1477) => {
V p_1484 = default;
V k_1485 = default;
JsStrBuf f_1486 = null;
JsStrBuf bk_1487 = null;
V un_1488 = default;
V post_1489 = default;
V bx_1490 = default;
JsStrBuf net_1491 = null;
V NET_1492 = default;
p_1484 = Get(c_1482, "p");
k_1485 = Get(c_1482, "k");
f_1486 = new JsStrBuf("");
bk_1487 = new JsStrBuf("");
un_1488 = ((V)(JsStrBuf.Begin().V(Call(turf_91, V.Undef, p_1484, ((V)(0D)), ((V)(22D)), ((V)(66D)), ((V)(46D)), ((V)("#5aa844")), ((V)("#6fbf54")))).S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_1484, ((V)(0.35)))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1\"><path d=\"M", NumStr(((-W_1463) - 12D)), " 0V22H", NumStr((W_1463 + 12D)), "V0M", NumStr(((-W_1463) + 8D)), " 0V9H", NumStr((W_1463 - 8D)), "V0\"/><path d=\"M-14 22A14 10 0 0 0 14 22\"/><circle cx=\"0\" cy=\"16\" r=\"0.9\" fill=\"#ffffff\"/></g>")).End()));
post_1489 = Arr(Arr(((V)((-W_1463))), ((V)(0D)), ((V)(0D))), Arr(((V)((-W_1463))), ((V)(H_1464)), ((V)(0D))), Arr(((V)(W_1463)), ((V)(H_1464)), ((V)(0D))), Arr(((V)(W_1463)), ((V)(0D)), ((V)(0D))));
bx_1490 = Arr(Arr(((V)((-W_1463))), ((V)((H_1464 - 6D))), ((V)((-DP_1465)))), Arr(((V)(W_1463)), ((V)((H_1464 - 6D))), ((V)((-DP_1465)))));
net_1491 = new JsStrBuf("");
NET_1492 = ((V)("#f4f4f0"));
Call(rep_19, V.Undef, ((V)(12D)), Fn((V _arrowThis1500, int _argc1493, V i_1499, V _a1496, V _a1497, V _a1498, V[] _rest1494) => {
double x_1501 = 0;
x_1501 = ((-W_1463) + (ToNum(i_1499) * ((2D * W_1463) / 11D)));
net_1491.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, Call(p_1484, V.Undef, ((V)(x_1501)), ((V)(H_1464)), ((V)(0D))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_1484, V.Undef, ((V)(x_1501)), ((V)((H_1464 - 6D))), ((V)((-DP_1465)))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_1484, V.Undef, ((V)(x_1501)), ((V)(0D)), ((V)(((-DP_1465) - 4D)))))), "\" stroke=\"", ToStr(NET_1492), "\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1485)))))), "\" fill=\"none\" opacity=\"0.8\"/>"));
return default;
}, 1, "", true));
Call(rep_19, V.Undef, ((V)(7D)), Fn((V _arrowThis1509, int _argc1502, V i_1508, V _a1505, V _a1506, V _a1507, V[] _rest1503) => {
double t_1510 = 0;
t_1510 = (ToNum(i_1508) / 6D);
net_1491.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, Call(p_1484, V.Undef, ((V)((-W_1463))), ((V)((H_1464 * (1D - t_1510)))), ((V)((((-DP_1465) * ((t_1510 < 0.2) ? (t_1510 * 5D) : 1D)) - (4D * t_1510))))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_1484, V.Undef, ((V)(W_1463)), ((V)((H_1464 * (1D - t_1510)))), ((V)((((-DP_1465) * ((t_1510 < 0.2) ? (t_1510 * 5D) : 1D)) - (4D * t_1510))))))), "\" stroke=\"", ToStr(NET_1492), "\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1485)))))), "\" opacity=\"0.8\"/>"));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-W_1463))), ((V)(W_1463))), "forEach", Fn((V _arrowThis1518, int _argc1511, V x_1517, V _a1514, V _a1515, V _a1516, V[] _rest1512) => {
Call(rep_19, V.Undef, ((V)(6D)), Fn((V _arrowThis1526, int _argc1519, V i_1525, V _a1522, V _a1523, V _a1524, V[] _rest1520) => {
double t_1527 = 0;
t_1527 = (ToNum(i_1525) / 5D);
net_1491.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, Call(p_1484, V.Undef, x_1517, ((V)((H_1464 * t_1527))), ((V)(0D))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_1484, V.Undef, x_1517, ((V)(((H_1464 - 6D) * t_1527))), ((V)(((-DP_1465) - (4D * (1D - t_1527)))))))), "\" stroke=\"", ToStr(NET_1492), "\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1485)))))), "\" opacity=\"0.7\"/>"));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
bk_1487.S(string.Concat("<g>", ToStr((Truthy(pl_1466) ? Call(atV_34, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)("0 0")), ((V)(string.Concat(ToStr(Call(f1_18, V.Undef, ((V)(((-1D) * ToNum(k_1485)))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-2D) * ToNum(k_1485))))))))), ((V)("0 0")), ((V)("0 0"))), ((V)(4D))) : ((V)("")))), net_1491.Str, "</g>")).V(Call(tube_45, V.Undef, Invoke(bx_1490, "map", Fn((V _arrowThis1535, int _argc1528, V q_1534, V _a1531, V _a1532, V _a1533, V[] _rest1529) => {
return CallSpread(p_1484, V.Undef, new ArrBuilder().Spread(q_1534).V);
}, 1, "", true)), ((V)(0.8)), k_1485, ((V)("#d8d8d4")))).V(Call(tube_45, V.Undef, Arr(Call(p_1484, V.Undef, ((V)((-W_1463))), ((V)(0D)), ((V)(((-DP_1465) - 4D)))), Call(p_1484, V.Undef, ((V)((-W_1463))), ((V)((H_1464 - 6D))), ((V)((-DP_1465)))), Call(p_1484, V.Undef, ((V)((-W_1463))), ((V)(H_1464)), ((V)(0D)))), ((V)(0.8)), k_1485, ((V)("#d8d8d4")))).V(Call(tube_45, V.Undef, Arr(Call(p_1484, V.Undef, ((V)(W_1463)), ((V)(0D)), ((V)(((-DP_1465) - 4D)))), Call(p_1484, V.Undef, ((V)(W_1463)), ((V)((H_1464 - 6D))), ((V)((-DP_1465)))), Call(p_1484, V.Undef, ((V)(W_1463)), ((V)(H_1464)), ((V)(0D)))), ((V)(0.8)), k_1485, ((V)("#d8d8d4"))));
f_1486.V(Call(tube_45, V.Undef, Invoke(post_1489, "map", Fn((V _arrowThis1543, int _argc1536, V q_1542, V _a1539, V _a1540, V _a1541, V[] _rest1537) => {
return CallSpread(p_1484, V.Undef, new ArrBuilder().Spread(q_1542).V);
}, 1, "", true)), ((V)(1.8)), k_1485, ((V)("#ffffff")), ((V)("#ffffff")), ((V)("#6a6a60"))));
if (Truthy(pl_1466)) {
f_1486.V(Call(ballFly_92, V.Undef, p_1484, k_1485, Arr(Arr(((V)((-30D))), ((V)(2.2)), ((V)(54D))), Arr(((V)((-10D))), ((V)(2.2)), ((V)(46D))), Arr(((V)((-10D))), ((V)(2.2)), ((V)(46D))), Arr(((V)(18D)), ((V)(2.2)), ((V)(40D))), Arr(((V)(18D)), ((V)(2.2)), ((V)(40D))), Arr(((V)(8D)), ((V)(12D)), ((V)(18D))), Arr(((V)(6D)), ((V)(18D)), ((V)((-4D)))), Arr(((V)(4D)), ((V)(3D)), ((V)((-16D)))), Arr(((V)(0D)), ((V)(2.2)), ((V)(54D))), Arr(((V)((-30D))), ((V)(2.2)), ((V)(54D)))), ((V)(4D)), Call(BALL_90, V.Undef, ((V)(2.6)), ((V)("soccer")))));
} else {
f_1486.V(Call(at_72, V.Undef, p_1484, k_1485, ((V)(0D)), ((V)(2.6)), ((V)(16D)), ((V)(1D)), Call(BALL_90, V.Undef, ((V)(2.6)), ((V)("soccer")))));
}
return NewObj(5).Put("defs", ((V)(""))).Put("under", un_1488).Put("back", ((V)(bk_1487.Str))).Put("front", ((V)(f_1486.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1484, V.Undef, ((V)((-66D))), ((V)(0D)), ((V)((-26D)))), Call(p_1484, V.Undef, ((V)(66D)), ((V)(0D)), ((V)(70D))), Call(p_1484, V.Undef, ((V)((-66D))), ((V)(0D)), ((V)(70D))), Call(p_1484, V.Undef, ((V)(66D)), ((V)(0D)), ((V)((-26D)))), Call(p_1484, V.Undef, ((V)((-W_1463))), ((V)((H_1464 + 8D))), ((V)(0D))), Call(p_1484, V.Undef, ((V)(W_1463)), ((V)((H_1464 + 8D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1467;
return default;
}, 1, "", true));
Set(PL9_89, "goal8", Fn((V _arrowThis1550, int _argc1544, V _a1546, V _a1547, V _a1548, V _a1549, V[] _rest1545) => {
return Arr(NewObj(4).Put("x", ((V)(0D))).Put("z", ((V)(6D))).Put("v", ((V)("front"))).Put("a", ((V)("gkeep"))).V, NewObj(4).Put("x", ((V)((-24D)))).Put("z", ((V)(52D))).Put("v", ((V)("back"))).Put("a", ((V)("grun"))).V, NewObj(5).Put("x", ((V)(20D))).Put("z", ((V)(42D))).Put("v", ((V)("back"))).Put("a", ((V)("gkick"))).Put("d", ((V)(0.3))).V);
}, 0, "", true));
Set(N_63, "hoop8", Fn((V _arrowThis1558, int _argc1551, V S_1557, V _a1554, V _a1555, V _a1556, V[] _rest1552) => {
V pl_1559 = default;
double RY_1560 = 0;
double BZ_1561 = 0;
V D_1562 = default;
pl_1559 = Call(isPlay_53, V.Undef, S_1557);
RY_1560 = 64D;
BZ_1561 = (-30D);
D_1562 = NewObj(2).Put("w", ((V)(110D))).Put("d", ((V)(110D))).V;
Set(D_1562, "build", Fn((V _arrowThis1570, int _argc1563, V P_1569, V _a1566, V _a1567, V _a1568, V[] _rest1564) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((BZ_1561 - 8D))), ((V)(4D)), ((V)(2D)), ((V)("#3a3c42")), Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((BZ_1561 - 8D))), ((V)(1.8)), ((V)((RY_1560 + 14D))), ((V)("#3a3c42")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((RY_1560 - 2D))), ((V)((BZ_1561 + 0.6))), ((V)(34D)), ((V)(22D)), ((V)(1.2)), ((V)("#e8f4f8")), NewObj(4).Put("op", ((V)(0.55))).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).Put("r", ((V)(1D))).V), Call(box_12, V.Undef, ((V)(0D)), ((V)((RY_1560 + 2D))), ((V)((BZ_1561 - 4D))), ((V)(6D)), ((V)(2D)), ((V)(8D)), ((V)("#3a3c42")), Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Set(D_1562, "fx", Fn((V _arrowThis1578, int _argc1571, V c_1577, V _a1574, V _a1575, V _a1576, V[] _rest1572) => {
V p_1579 = default;
V k_1580 = default;
JsStrBuf f_1581 = null;
V un_1582 = default;
V rim_1583 = default;
JsStrBuf net_1584 = null;
p_1579 = Get(c_1577, "p");
k_1580 = Get(c_1577, "k");
f_1581 = new JsStrBuf("");
un_1582 = ((V)(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_1579, ((V)(0.3)))), "\"><rect x=\"-50\" y=\"-36\" width=\"100\" height=\"90\" rx=\"2\" fill=\"#bdb8ae\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(8D)), Fn((V _arrowThis1592, int _argc1585, V i_1591, V _a1588, V _a1589, V _a1590, V[] _rest1586) => {
return ((V)(string.Concat("<path d=\"M-50 ", NumStr(((-36D) + (ToNum(i_1591) * 12D))), "H50\" stroke=\"#a8a398\" stroke-width=\"0.4\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<path d=\"M-14 -34V8H14V-34M-14 8A14 14 0 0 0 14 8M-44 -34V-10A44 44 0 0 0 44 -10V-34\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1\"/></g>")));
f_1581.S(string.Concat("<g transform=\"", ToStr(Call(plane_24, V.Undef, p_1579, ((V)((BZ_1561 + 1.25))), ((V)((RY_1560 + 20D))), ((V)((-17D))))), "\"><rect x=\"0.6\" y=\"0.6\" width=\"32.8\" height=\"20.8\" rx=\"1\" fill=\"none\" stroke=\"#e8343c\" stroke-width=\"1.2\"/><rect x=\"11\" y=\"9\" width=\"12\" height=\"9\" fill=\"none\" stroke=\"#e8343c\" stroke-width=\"0.9\"/></g>"));
rim_1583 = Invoke(Call(ellPts_39, V.Undef, ((V)(0D)), ((V)((BZ_1561 + 9D))), ((V)(7D)), ((V)(7D)), ((V)(24D))), "map", Fn((V _arrowThis1604, int _argc1593, V _a1595, V _a1596, V _a1597, V _a1598, V[] _rest1594) => {
V x_1601 = default;
V z_1603 = default;
{ V _t1599 = ListOf(_a1595);
{ V _t1600 = GetIdx(_t1599, 0D);
x_1601 = _t1600; }
{ V _t1602 = GetIdx(_t1599, 1D);
z_1603 = _t1602; }
}
return Call(p_1579, V.Undef, x_1601, ((V)(RY_1560)), z_1603);
}, 1, "", true));
net_1584 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(12D)), Fn((V _arrowThis1612, int _argc1605, V i_1611, V _a1608, V _a1609, V _a1610, V[] _rest1606) => {
double a_1613 = 0;
V t0_1614 = default;
V t1_1615 = default;
a_1613 = (((ToNum(i_1611) / 12D) * 2D) * PI_64);
t0_1614 = Call(p_1579, V.Undef, ((V)((7D * FdLibm.Cos(a_1613)))), ((V)(RY_1560)), ((V)(((BZ_1561 + 9D) + (7D * FdLibm.Sin(a_1613))))));
t1_1615 = Call(p_1579, V.Undef, ((V)((4D * FdLibm.Cos((a_1613 + 0.4))))), ((V)((RY_1560 - 10D))), ((V)(((BZ_1561 + 9D) + (4D * FdLibm.Sin((a_1613 + 0.4)))))));
net_1584.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, t0_1614)), "L", ToStr(Call(P2_22, V.Undef, t1_1615)), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1580)))))), "\" opacity=\"0.9\"/>"));
return default;
}, 1, "", true));
net_1584.V(Invoke(Invoke(Arr(((V)(3.4)), ((V)(6.8))), "map", Fn((V _arrowThis1623, int _argc1616, V dy_1622, V _a1619, V _a1620, V _a1621, V[] _rest1617) => {
return ((V)(string.Concat("<path d=\"", ToStr(Call(sp_41, V.Undef, p_1579, Call(ellPts_39, V.Undef, ((V)(0D)), ((V)((BZ_1561 + 9D))), ((V)((7D - (ToNum(dy_1622) * 0.3)))), ((V)((7D - (ToNum(dy_1622) * 0.3)))), ((V)(20D))), ((V)((RY_1560 - ToNum(dy_1622)))))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1580)))))), "\" opacity=\"0.8\"/>")));
}, 1, "", true)), "join", ((V)(""))));
f_1581.S(string.Concat("<g>", ToStr((Truthy(pl_1559) ? Call(atV_34, V.Undef, ((V)("scale")), Arr(((V)("1 1")), ((V)("1 1")), ((V)("1 1.08")), ((V)("1 1")), ((V)("1 1"))), ((V)(3.2))) : ((V)("")))), net_1584.Str, "</g><path d=\"M", ToStr(Invoke(Invoke(rim_1583, "map", P2_22), "join", ((V)("L")))), "Z\" fill=\"none\" stroke=\"#e8642a\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((1D * ToNum(k_1580)))))), "\"/>"));
if (Truthy(pl_1559)) {
V sh_1624 = default;
sh_1624 = Arr(Arr(((V)((-24D))), ((V)(34D)), ((V)(30D))), Arr(((V)((-12D))), ((V)(70D)), ((V)(8D))), Arr(((V)(0D)), ((V)((RY_1560 + 4D))), ((V)((BZ_1561 + 9D)))), Arr(((V)(0D)), ((V)((RY_1560 - 8D))), ((V)((BZ_1561 + 9D)))), Arr(((V)(0D)), ((V)(2.6)), ((V)((BZ_1561 + 14D)))), Arr(((V)(4D)), ((V)(10D)), ((V)((BZ_1561 + 24D)))), Arr(((V)(12D)), ((V)(2.6)), ((V)(6D))), Arr(((V)(18D)), ((V)(12D)), ((V)(18D))), Arr(((V)(22D)), ((V)(2.6)), ((V)(26D))), Arr(((V)((-10D))), ((V)(20D)), ((V)(30D))), Arr(((V)((-24D))), ((V)(34D)), ((V)(30D))));
f_1581.V(Call(ballFly_92, V.Undef, p_1579, k_1580, sh_1624, ((V)(3.2)), Call(BALL_90, V.Undef, ((V)(2.6)), ((V)("bball")))));
} else {
f_1581.V(Call(at_72, V.Undef, p_1579, k_1580, ((V)(10D)), ((V)(2.6)), ((V)(6D)), ((V)(1D)), Call(BALL_90, V.Undef, ((V)(2.6)), ((V)("bball")))));
}
return NewObj(4).Put("defs", ((V)(""))).Put("under", un_1582).Put("front", ((V)(f_1581.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1579, V.Undef, ((V)((-50D))), ((V)(0D)), ((V)((-36D)))), Call(p_1579, V.Undef, ((V)(50D)), ((V)(0D)), ((V)(54D))), Call(p_1579, V.Undef, ((V)((-50D))), ((V)(0D)), ((V)(54D))), Call(p_1579, V.Undef, ((V)(50D)), ((V)(0D)), ((V)((-36D)))), Call(p_1579, V.Undef, ((V)(0D)), ((V)((RY_1560 + 24D))), ((V)(BZ_1561))), Call(p_1579, V.Undef, ((V)((-17D))), ((V)((RY_1560 + 22D))), ((V)(BZ_1561)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1562;
return default;
}, 1, "", true));
Set(PL9_89, "hoop8", Fn((V _arrowThis1631, int _argc1625, V _a1627, V _a1628, V _a1629, V _a1630, V[] _rest1626) => {
return Arr(NewObj(4).Put("x", ((V)((-24D)))).Put("z", ((V)(30D))).Put("v", ((V)("back"))).Put("a", ((V)("gjump"))).V, NewObj(5).Put("x", ((V)(16D))).Put("z", ((V)(22D))).Put("v", ((V)("back"))).Put("a", ((V)("grun"))).Put("d", ((V)(0.4))).V, NewObj(5).Put("x", ((V)(0D))).Put("z", ((V)((-6D)))).Put("v", ((V)("front"))).Put("a", ((V)("gjump"))).Put("d", ((V)(0.6))).V);
}, 0, "", true));
Set(N_63, "golf8", Fn((V _arrowThis1639, int _argc1632, V S_1638, V _a1635, V _a1636, V _a1637, V[] _rest1633) => {
V pl_1640 = default;
V D_1641 = default;
pl_1640 = Call(isPlay_53, V.Undef, S_1638);
D_1641 = NewObj(2).Put("w", ((V)(160D))).Put("d", ((V)(110D))).V;
Set(D_1641, "build", Fn((V _arrowThis1649, int _argc1642, V P_1648, V _a1645, V _a1646, V _a1647, V[] _rest1643) => {
return Arr(Call(box_12, V.Undef, ((V)(46D)), ((V)(0D)), ((V)((-40D))), ((V)(4D)), ((V)(44D)), ((V)(4D)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)((46D + 48D))), ((V)(0D)), ((V)((-40D))), ((V)(4D)), ((V)(44D)), ((V)(4D)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)(70D)), ((V)(18D)), ((V)((-40D))), ((V)(52D)), ((V)(28D)), ((V)(2D)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}, 1, "", true));
Set(D_1641, "fx", Fn((V _arrowThis1657, int _argc1650, V c_1656, V _a1653, V _a1654, V _a1655, V[] _rest1651) => {
V p_1658 = default;
V k_1659 = default;
JsStrBuf f_1660 = null;
V blob_1661 = default;
V un_1662 = default;
V sc_1663 = default;
p_1658 = Get(c_1656, "p");
k_1659 = Get(c_1656, "k");
f_1660 = new JsStrBuf("");
blob_1661 = Call(rep_19, V.Undef, ((V)(20D)), Fn((V _arrowThis1671, int _argc1664, V i_1670, V _a1667, V _a1668, V _a1669, V[] _rest1665) => {
double a_1672 = 0;
a_1672 = (((ToNum(i_1670) / 20D) * 2D) * PI_64);
return Arr(((V)(((-10D) + (FdLibm.Cos(a_1672) * (62D + (FdLibm.Sin((a_1672 * 3D)) * 6D)))))), ((V)((4D + (FdLibm.Sin(a_1672) * (40D + (FdLibm.Cos((a_1672 * 2D)) * 5D)))))));
return default;
}, 1, "", true));
un_1662 = ((V)(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_1658, ((V)(0.3)))), "\"><path d=\"", ToStr(Call(lp_40, V.Undef, Invoke(blob_1661, "map", Fn((V _arrowThis1684, int _argc1673, V _a1675, V _a1676, V _a1677, V _a1678, V[] _rest1674) => {
V x_1681 = default;
V z_1683 = default;
{ V _t1679 = ListOf(_a1675);
{ V _t1680 = GetIdx(_t1679, 0D);
x_1681 = _t1680; }
{ V _t1682 = GetIdx(_t1679, 1D);
z_1683 = _t1682; }
}
return Arr(((V)((ToNum(x_1681) * 1.08))), ((V)((ToNum(z_1683) * 1.1))));
}, 1, "", true)))), "\" fill=\"#4f9a3e\"/><path d=\"", ToStr(Call(lp_40, V.Undef, blob_1661)), "\" fill=\"#6fbf54\"/><path d=\"", ToStr(Call(lp_40, V.Undef, blob_1661)), "\" fill=\"url(#gf8)\"/>", ToStr(Invoke(Invoke(Arr(Arr(((V)((-48D))), ((V)(20D))), Arr(((V)((-10D))), ((V)((-18D)))), Arr(((V)(26D)), ((V)(24D)))), "map", Fn((V _arrowThis1696, int _argc1685, V _a1687, V _a1688, V _a1689, V _a1690, V[] _rest1686) => {
V x_1693 = default;
V z_1695 = default;
{ V _t1691 = ListOf(_a1687);
{ V _t1692 = GetIdx(_t1691, 0D);
x_1693 = _t1692; }
{ V _t1694 = GetIdx(_t1691, 1D);
z_1695 = _t1694; }
}
return ((V)(string.Concat("<ellipse cx=\"", ToStr(x_1693), "\" cy=\"", ToStr(z_1695), "\" rx=\"2.2\" ry=\"2.2\" fill=\"#1d2a1d\"/><ellipse cx=\"", ToStr(x_1693), "\" cy=\"", ToStr(z_1695), "\" rx=\"2.2\" ry=\"2.2\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.4\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g>")));
Invoke(Arr(Arr(((V)((-48D))), ((V)(20D)), ((V)(1D))), Arr(((V)((-10D))), ((V)((-18D))), ((V)(2D))), Arr(((V)(26D)), ((V)(24D)), ((V)(3D)))), "forEach", Fn((V _arrowThis1711, int _argc1697, V _a1699, V i_1703, V _a1701, V _a1702, V[] _rest1698) => {
V b_1712 = default;
V t_1713 = default;
V x_1706 = default;
V z_1708 = default;
V n_1710 = default;
{ V _t1704 = ListOf(_a1699);
{ V _t1705 = GetIdx(_t1704, 0D);
x_1706 = _t1705; }
{ V _t1707 = GetIdx(_t1704, 1D);
z_1708 = _t1707; }
{ V _t1709 = GetIdx(_t1704, 2D);
n_1710 = _t1709; }
}
b_1712 = Call(p_1658, V.Undef, x_1706, ((V)(0D)), z_1708);
t_1713 = Call(p_1658, V.Undef, x_1706, ((V)(24D)), z_1708);
f_1660.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, b_1712)), "L", ToStr(Call(P2_22, V.Undef, t_1713)), "\" stroke=\"#f4f4f0\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.6 * ToNum(k_1659)))))), "\"/><g transform=\"translate(", ToStr(Call(P2_22, V.Undef, t_1713)), ") scale(", ToStr(Call(n4_21, V.Undef, k_1659)), ")\"><path d=\"M0 0L9 2L0 5Z\" fill=\"", ToStr(GetK(Arr(((V)("#e8343c")), ((V)("#f2c14a")), ((V)("#2f86c8"))), i_1703)), "\">", ToStr(Call(atV_34, V.Undef, ((V)("skewY")), Arr(((V)("0")), ((V)("-8")), ((V)("4")), ((V)("0"))), ((V)(1.6)), ((V)(((-ToNum(i_1703)) * 0.4))))), "</path><text x=\"3\" y=\"3.6\" font-family=\"Arial\" font-size=\"2.8\" font-weight=\"800\" fill=\"#ffffff\">", ToStr(n_1710), "</text></g>"));
return default;
}, 2, "", true));
sc_1663 = ((V)(string.Concat("<rect x=\"0\" y=\"0\" width=\"48\" height=\"25\" fill=\"#0e1018\"/><rect x=\"1\" y=\"1\" width=\"46\" height=\"23\" fill=\"url(#gf8s)\"/><circle cx=\"12\" cy=\"14\" r=\"5\" fill=\"#ffd23a\">", ToStr(Call(an_26, V.Undef, ((V)("cx")), ((V)("8;40;8")), ((V)(6D)))), "</circle><rect x=\"1\" y=\"19\" width=\"46\" height=\"5\" fill=\"#5aa844\"/><path d=\"M30 19L36 9L42 19Z\" fill=\"#3f7a34\"/>")));
f_1660.S(string.Concat("<g transform=\"", ToStr(Call(plane_24, V.Undef, p_1658, ((V)((-38.9))), ((V)(45.5)), ((V)(46D)))), "\">", ToStr(sc_1663), "</g>"));
if (Truthy(pl_1640)) {
f_1660.V(Add(Call(ballFly_92, V.Undef, p_1658, k_1659, Arr(Arr(((V)((-30D))), ((V)(1.2)), ((V)(36D))), Arr(((V)((-38D))), ((V)(1.2)), ((V)(30D))), Arr(((V)((-46D))), ((V)(1.2)), ((V)(22D))), Arr(((V)((-48D))), ((V)(0D)), ((V)(20D))), Arr(((V)((-48D))), ((V)(0D)), ((V)(20D))), Arr(((V)((-30D))), ((V)(1.2)), ((V)(36D)))), ((V)(5D)), Call(BALL_90, V.Undef, ((V)(1.2)), ((V)("#ffffff")))), Call(ballFly_92, V.Undef, p_1658, k_1659, Arr(Arr(((V)(6D)), ((V)(1.2)), ((V)(6D))), Arr(((V)((-2D))), ((V)(1.2)), ((V)((-6D)))), Arr(((V)((-8D))), ((V)(1.2)), ((V)((-14D)))), Arr(((V)((-10D))), ((V)(0D)), ((V)((-18D)))), Arr(((V)((-10D))), ((V)(0D)), ((V)((-18D)))), Arr(((V)(6D)), ((V)(1.2)), ((V)(6D)))), ((V)(5D)), Call(BALL_90, V.Undef, ((V)(1.2)), ((V)("#ffffff"))), ((V)(1D)), ((V)((-2.4))))));
} else {
f_1660.V(Call(at_72, V.Undef, p_1658, k_1659, ((V)((-30D))), ((V)(1.2)), ((V)(36D)), ((V)(1D)), Call(BALL_90, V.Undef, ((V)(1.2)), ((V)("#ffffff")))));
}
return NewObj(4).Put("defs", Add(Call(G_37, V.Undef, ((V)("gf8")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.18))), Arr(((V)(1D)), ((V)("#000000")), ((V)(0.1)))), ((V)("cx=\"40%\" cy=\"40%\" r=\"70%\""))), Call(L_38, V.Undef, ((V)("gf8s")), Arr(Arr(((V)(0D)), ((V)("#7ac8ff"))), Arr(((V)(1D)), ((V)("#d8f2ff"))))))).Put("under", un_1662).Put("front", ((V)(f_1660.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1658, V.Undef, ((V)((-80D))), ((V)(0D)), ((V)((-50D)))), Call(p_1658, V.Undef, ((V)(70D)), ((V)(0D)), ((V)(52D))), Call(p_1658, V.Undef, ((V)((-80D))), ((V)(0D)), ((V)(52D))), Call(p_1658, V.Undef, ((V)(98D)), ((V)(48D)), ((V)((-40D)))), Call(p_1658, V.Undef, ((V)(44D)), ((V)(48D)), ((V)((-40D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1641;
return default;
}, 1, "", true));
Set(PL9_89, "golf8", Fn((V _arrowThis1720, int _argc1714, V _a1716, V _a1717, V _a1718, V _a1719, V[] _rest1715) => {
return Arr(NewObj(4).Put("x", ((V)((-30D)))).Put("z", ((V)(42D))).Put("v", ((V)("left"))).Put("a", ((V)("gswing"))).V, NewObj(5).Put("x", ((V)(8D))).Put("z", ((V)(12D))).Put("v", ((V)("left"))).Put("a", ((V)("gswing"))).Put("d", ((V)(0.5))).V);
}, 0, "", true));
Set(N_63, "dome8", Fn((V _arrowThis1728, int _argc1721, V S_1727, V _a1724, V _a1725, V _a1726, V[] _rest1722) => {
double R0_1729 = 0;
V D_1730 = default;
R0_1729 = 40D;
D_1730 = NewObj(3).Put("w", ((V)(100D))).Put("d", ((V)(100D))).Put("round", ((V)(1D))).V;
Set(D_1730, "build", Fn((V _arrowThis1738, int _argc1731, V P_1737, V _a1734, V _a1735, V _a1736, V[] _rest1732) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((R0_1729 + 8D))), ((V)(1.2)), ((V)("#b86a3a")), Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(36D))).V)));
}, 1, "", true));
Set(D_1730, "fx", Fn((V _arrowThis1746, int _argc1739, V c_1745, V _a1742, V _a1743, V _a1744, V[] _rest1740) => {
V p_1747 = default;
V k_1748 = default;
JsStrBuf f_1749 = null;
JsStrBuf bk_1750 = null;
V RG_1751 = default;
V E_1752 = default;
V COL_1753 = default;
p_1747 = Get(c_1745, "p");
k_1748 = Get(c_1745, "k");
f_1749 = new JsStrBuf("");
bk_1750 = new JsStrBuf("");
RG_1751 = Invoke(Arr(Arr(((V)(0D)), ((V)(10D))), Arr(((V)(18D)), ((V)(10D))), Arr(((V)(36D)), ((V)(10D))), Arr(((V)(56D)), ((V)(5D))), Arr(((V)(90D)), ((V)(1D)))), "map", Fn((V _arrowThis1766, int _argc1754, V _a1756, V i_1760, V _a1758, V _a1759, V[] _rest1755) => {
V e_1763 = default;
V n_1765 = default;
{ V _t1761 = ListOf(_a1756);
{ V _t1762 = GetIdx(_t1761, 0D);
e_1763 = _t1762; }
{ V _t1764 = GetIdx(_t1761, 1D);
n_1765 = _t1764; }
}
return Call(rep_19, V.Undef, n_1765, Fn((V _arrowThis1774, int _argc1767, V j_1773, V _a1770, V _a1771, V _a1772, V[] _rest1768) => {
double a_1775 = 0;
double el_1776 = 0;
a_1775 = ((((ToNum(j_1773) / ToNum(n_1765)) * 2D) * PI_64) + (((ToNum(i_1760) % 2D) * PI_64) / ToNum(n_1765)));
el_1776 = ((ToNum(e_1763) * PI_64) / 180D);
return Arr(((V)(((R0_1729 * FdLibm.Cos(el_1776)) * FdLibm.Cos(a_1775)))), ((V)((R0_1729 * FdLibm.Sin(el_1776)))), ((V)(((R0_1729 * FdLibm.Cos(el_1776)) * FdLibm.Sin(a_1775)))));
return default;
}, 1, "", true));
}, 2, "", true));
E_1752 = Arr();
Invoke(RG_1751, "forEach", Fn((V _arrowThis1785, int _argc1777, V ring_1783, V i_1784, V _a1781, V _a1782, V[] _rest1778) => {
return Invoke(ring_1783, "forEach", Fn((V _arrowThis1794, int _argc1786, V q_1792, V j_1793, V _a1790, V _a1791, V[] _rest1787) => {
V nx_1795 = default;
if (GtN(Get(ring_1783, "length"), 1D)) {
Invoke(E_1752, "push", Arr(q_1792, GetIdx(ring_1783, (ToNum(Add(j_1793, ((V)(1D)))) % ToNum(Get(ring_1783, "length"))))));
}
nx_1795 = GetK(RG_1751, Add(i_1784, ((V)(1D))));
if (Truthy(nx_1795)) {
V near_1796 = default;
near_1796 = Invoke(Invoke(Invoke(nx_1795, "map", Fn((V _arrowThis1813, int _argc1806, V v_1812, V _a1809, V _a1810, V _a1811, V[] _rest1807) => {
return Arr(v_1812, ((V)(Hypot((ToNum(GetIdx(v_1812, 0D)) - ToNum(GetIdx(q_1792, 0D))), (ToNum(GetIdx(v_1812, 1D)) - ToNum(GetIdx(q_1792, 1D))), (ToNum(GetIdx(v_1812, 2D)) - ToNum(GetIdx(q_1792, 2D)))))));
}, 1, "", true)), "sort", Fn((V _arrowThis1805, int _argc1797, V a_1803, V b_1804, V _a1801, V _a1802, V[] _rest1798) => {
return ((V)((ToNum(GetIdx(a_1803, 1D)) - ToNum(GetIdx(b_1804, 1D)))));
}, 2, "", true)), "slice", ((V)(0D)), ((V)((GtN(Get(nx_1795, "length"), 2D) ? 2D : 1D))));
Invoke(near_1796, "forEach", Fn((V _arrowThis1823, int _argc1814, V _a1816, V _a1817, V _a1818, V _a1819, V[] _rest1815) => {
V v_1822 = default;
{ V _t1820 = ListOf(_a1816);
{ V _t1821 = GetIdx(_t1820, 0D);
v_1822 = _t1821; }
}
return Invoke(E_1752, "push", Arr(q_1792, v_1822));
}, 1, "", true));
}
return default;
}, 2, "", true));
}, 2, "", true));
COL_1753 = Arr(((V)("#e8343c")), ((V)("#2f86e6")), ((V)("#f2c14a")), ((V)("#3faa5a")));
Invoke(E_1752, "forEach", Fn((V _arrowThis1836, int _argc1824, V _a1826, V i_1830, V _a1828, V _a1829, V[] _rest1825) => {
V m_1837 = default;
double fr_1838 = 0;
V t_1839 = default;
V a_1833 = default;
V b_1835 = default;
{ V _t1831 = ListOf(_a1826);
{ V _t1832 = GetIdx(_t1831, 0D);
a_1833 = _t1832; }
{ V _t1834 = GetIdx(_t1831, 1D);
b_1835 = _t1834; }
}
m_1837 = Arr(((V)((ToNum(Add(GetIdx(a_1833, 0D), GetIdx(b_1835, 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(a_1833, 1D), GetIdx(b_1835, 1D))) / 2D))), ((V)((ToNum(Add(GetIdx(a_1833, 2D), GetIdx(b_1835, 2D))) / 2D))));
fr_1838 = (((ToNum(GetIdx(m_1837, 0D)) * 0.5) + (ToNum(GetIdx(m_1837, 2D)) * 0.866)) / R0_1729);
t_1839 = Call(tube_45, V.Undef, Arr(CallSpread(p_1747, V.Undef, new ArrBuilder().Spread(a_1833).V), CallSpread(p_1747, V.Undef, new ArrBuilder().Spread(b_1835).V)), ((V)(1.3)), k_1748, GetIdx(COL_1753, (ToNum(i_1830) % 4D)), ((V)("#ffffff")), ((V)("#2a2b30")));
if ((fr_1838 < (-0.05))) {
bk_1750.S(string.Concat("<g opacity=\"0.85\">", ToStr(t_1839), "</g>"));
} else {
f_1749.V(t_1839);
}
return default;
}, 2, "", true));
Invoke(Invoke(RG_1751, "flat"), "forEach", Fn((V _arrowThis1847, int _argc1840, V q_1846, V _a1843, V _a1844, V _a1845, V[] _rest1841) => {
V s_1848 = default;
double fr_1849 = 0;
V n_1850 = default;
s_1848 = CallSpread(p_1747, V.Undef, new ArrBuilder().Spread(q_1846).V);
fr_1849 = (((ToNum(GetIdx(q_1846, 0D)) * 0.5) + (ToNum(GetIdx(q_1846, 2D)) * 0.866)) / R0_1729);
n_1850 = ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(s_1848, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(s_1848, 1D))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.4 * ToNum(k_1748)))))), "\" fill=\"#3a3c42\"/>")));
if ((fr_1849 < (-0.05))) {
bk_1750.V(n_1850);
} else {
f_1749.V(n_1850);
}
return default;
}, 1, "", true));
return NewObj(4).Put("defs", ((V)(""))).Put("back", ((V)(bk_1750.Str))).Put("front", ((V)(f_1749.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1747, V.Undef, ((V)(((-R0_1729) - 8D))), ((V)(0D)), ((V)(((-R0_1729) - 8D)))), Call(p_1747, V.Undef, ((V)((R0_1729 + 8D))), ((V)(0D)), ((V)((R0_1729 + 8D)))), Call(p_1747, V.Undef, ((V)(((-R0_1729) - 8D))), ((V)(0D)), ((V)((R0_1729 + 8D)))), Call(p_1747, V.Undef, ((V)((R0_1729 + 8D))), ((V)(0D)), ((V)(((-R0_1729) - 8D)))), Call(p_1747, V.Undef, ((V)(0D)), ((V)((R0_1729 + 4D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1730;
return default;
}, 1, "", true));
Set(PL9_89, "dome8", Fn((V _arrowThis1857, int _argc1851, V _a1853, V _a1854, V _a1855, V _a1856, V[] _rest1852) => {
return Arr(NewObj(5).Put("x", ((V)(0D))).Put("y", ((V)(40D))).Put("z", ((V)(0D))).Put("v", ((V)("front"))).Put("a", ((V)("gclimb"))).V, NewObj(6).Put("x", ((V)((-24D)))).Put("y", ((V)(20D))).Put("z", ((V)(22D))).Put("v", ((V)("front"))).Put("a", ((V)("gclimb"))).Put("d", ((V)(0.3))).V, NewObj(6).Put("x", ((V)(26D))).Put("y", ((V)(14D))).Put("z", ((V)(26D))).Put("v", ((V)("right"))).Put("a", ((V)("gclimb"))).Put("d", ((V)(0.6))).V, NewObj(6).Put("x", ((V)(34D))).Put("y", ((V)(0D))).Put("z", ((V)(34D))).Put("v", ((V)("front"))).Put("a", ((V)("gjump"))).Put("d", ((V)(0.2))).V);
}, 0, "", true));
Set(N_63, "bounce8", Fn((V _arrowThis1865, int _argc1858, V S_1864, V _a1861, V _a1862, V _a1863, V[] _rest1859) => {
V pl_1866 = default;
double R0_1867 = 0;
V D_1868 = default;
pl_1866 = Call(isPlay_53, V.Undef, S_1864);
R0_1867 = 34D;
D_1868 = NewObj(3).Put("w", ((V)(110D))).Put("d", ((V)(90D))).Put("glow", Fn((V _arrowThis1875, int _argc1869, V _a1871, V _a1872, V _a1873, V _a1874, V[] _rest1870) => {
return NewObj(2).Put("y", ((V)(20D))).Put("r", ((V)(60D))).V;
}, 0, "glow", true)).V;
Set(D_1868, "build", Fn((V _arrowThis1883, int _argc1876, V P_1882, V _a1879, V _a1880, V _a1881, V[] _rest1877) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((R0_1867 + 4D))), ((V)(4D)), ((V)("#26272b")), Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(36D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.95))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(R0_1867)), ((V)(0.8)), ((V)("#7ef6ff")), NewObj(2).Put("emit", ((V)(1D))).Put("n", ((V)(36D))).V), Call(cyl_13, V.Undef, ((V)(52D)), ((V)(0D)), ((V)(18D)), ((V)(7D)), ((V)(10D)), ((V)("#e8ecf0")), Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.8))))).V)), Call(cyl_13, V.Undef, ((V)(52D)), ((V)(10D)), ((V)(18D)), ((V)(4D)), ((V)(6D)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
Set(D_1868, "fx", Fn((V _arrowThis1891, int _argc1884, V c_1890, V _a1887, V _a1888, V _a1889, V[] _rest1885) => {
V p_1892 = default;
V k_1893 = default;
JsStrBuf f_1894 = null;
V bk_1895 = default;
V C_1896 = default;
double Rr_1897 = 0;
V top_1898 = default;
V dome_1899 = default;
p_1892 = Get(c_1890, "p");
k_1893 = Get(c_1890, "k");
f_1894 = new JsStrBuf("");
bk_1895 = ((V)(""));
C_1896 = Call(p_1892, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)));
Rr_1897 = (R0_1867 * ToNum(k_1893));
top_1898 = Call(p_1892, V.Undef, ((V)(0D)), ((V)((4D + R0_1867))), ((V)(0D)));
dome_1899 = ((V)(string.Concat("M", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(C_1896, 0D)) - Rr_1897))))), " ", ToStr(Call(f1_18, V.Undef, GetIdx(C_1896, 1D))), "A", ToStr(Call(f1_18, V.Undef, ((V)(Rr_1897)))), " ", ToStr(Call(f1_18, V.Undef, ((V)((Rr_1897 * 1.05))))), " 0 0 1 ", ToStr(Call(f1_18, V.Undef, Add(GetIdx(C_1896, 0D), ((V)(Rr_1897))))), " ", ToStr(Call(f1_18, V.Undef, GetIdx(C_1896, 1D))), "A", ToStr(Call(f1_18, V.Undef, ((V)(Rr_1897)))), " ", ToStr(Call(f1_18, V.Undef, ((V)((Rr_1897 * ToNum(Get(X_9, "SA"))))))), " 0 0 1 ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(C_1896, 0D)) - Rr_1897))))), " ", ToStr(Call(f1_18, V.Undef, GetIdx(C_1896, 1D))), "Z")));
_ = top_1898;
f_1894.S(string.Concat("<path d=\"", ToStr(dome_1899), "\" fill=\"url(#bd8)\"/><path d=\"", ToStr(dome_1899), "\" fill=\"url(#bd8h)\" opacity=\"0.9\"/><path d=\"", ToStr(dome_1899), "\" fill=\"none\" stroke=\"#bff8ff\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.6 * ToNum(k_1893)))))), "\" opacity=\"0.8\"/><path d=\"M", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(C_1896, 0D)) - (Rr_1897 * 0.7)))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(C_1896, 1D)) - (Rr_1897 * 0.5)))))), "Q", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(C_1896, 0D)) - (Rr_1897 * 0.4)))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(C_1896, 1D)) - (Rr_1897 * 0.95)))))), " ", ToStr(Call(f1_18, V.Undef, GetIdx(C_1896, 0D))), " ", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(C_1896, 1D)) - Rr_1897))))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.4 * ToNum(k_1893)))))), "\" fill=\"none\" opacity=\"0.5\"/>"));
Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis1907, int _argc1900, V i_1906, V _a1903, V _a1904, V _a1905, V[] _rest1901) => {
return ((V)(f_1894.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, Call(p_1892, V.Undef, ((V)(((-12D) + (ToNum(i_1906) * 12D)))), ((V)((22D + (ToNum(i_1906) * 4D)))), ((V)(((-6D) + (ToNum(i_1906) * 4D))))))), ") scale(", ToStr(Call(n4_21, V.Undef, k_1893)), ")\"><g>", ToStr(Call(atV_34, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)("0 -5")), ((V)("0 0"))), ((V)((2.4 + (ToNum(i_1906) * 0.5)))), ((V)((-ToNum(i_1906)))))), ToStr(Call(BALL_90, V.Undef, ((V)(2.4)), GetK(Arr(((V)("#ff4fb8")), ((V)("#7ef6ff")), ((V)("#ffe66a"))), i_1906))), "</g></g>")).Str));
}, 1, "", true));
if (Truthy(pl_1866)) {
f_1894.V(Call(ballFly_92, V.Undef, p_1892, k_1893, Invoke(Call(arc3_71, V.Undef, Arr(((V)(52D)), ((V)(18D)), ((V)(18D))), Arr(((V)(0D)), ((V)(6D)), ((V)(0D))), ((V)(40D)), ((V)(14D))), "concat", Invoke(Call(arc3_71, V.Undef, Arr(((V)(0D)), ((V)(6D)), ((V)(0D))), Arr(((V)(52D)), ((V)(18D)), ((V)(18D))), ((V)(30D)), ((V)(10D))), "slice", ((V)(1D)))), ((V)(3D)), ((V)(string.Concat("<circle r=\"4\" fill=\"#7ef6ff\" opacity=\"0.4\" filter=\"url(#f7b)\"/>", ToStr(Call(BALL_90, V.Undef, ((V)(2.2)), ((V)("#c9ff7a")))))))));
}
return NewObj(4).Put("defs", ((V)(JsStrBuf.Begin().V(Add(FDEF_50, Call(G_37, V.Undef, ((V)("bd8")), Arr(Arr(((V)(0D)), ((V)("#bff8ff")), ((V)(0.12))), Arr(((V)(0.7)), ((V)("#3a9aff")), ((V)(0.22))), Arr(((V)(1D)), ((V)("#7ef6ff")), ((V)(0.55)))), ((V)("cx=\"42%\" cy=\"62%\" r=\"62%\""))))).S(string.Concat("<pattern id=\"bd8h\" width=\"8\" height=\"7\" patternUnits=\"userSpaceOnUse\"><path d=\"M2 0L6 0L8 3.5L6 7L2 7L0 3.5Z\" fill=\"none\" stroke=\"#7ef6ff\" stroke-width=\"0.3\" opacity=\"0.6\"/></pattern>", "")).End()))).Put("back", bk_1895).Put("front", ((V)(f_1894.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1892, V.Undef, ((V)(((-R0_1867) - 6D))), ((V)(0D)), ((V)(((-R0_1867) - 6D)))), Call(p_1892, V.Undef, ((V)((R0_1867 + 6D))), ((V)(0D)), ((V)((R0_1867 + 6D)))), Call(p_1892, V.Undef, ((V)(((-R0_1867) - 6D))), ((V)(0D)), ((V)((R0_1867 + 6D)))), Call(p_1892, V.Undef, ((V)(60D)), ((V)(0D)), ((V)(26D))), Call(p_1892, V.Undef, ((V)(0D)), ((V)((R0_1867 + 10D))), ((V)(0D))), Call(p_1892, V.Undef, ((V)(30D)), ((V)(50D)), ((V)(10D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1868;
return default;
}, 1, "", true));
Set(PL9_89, "bounce8", Fn((V _arrowThis1914, int _argc1908, V _a1910, V _a1911, V _a1912, V _a1913, V[] _rest1909) => {
return Arr(NewObj(5).Put("x", ((V)(0D))).Put("y", ((V)(8D))).Put("z", ((V)(4D))).Put("v", ((V)("front"))).Put("a", ((V)("gbounce"))).V);
}, 0, "", true));
Set(N_63, "agility8", Fn((V _arrowThis1922, int _argc1915, V S_1921, V _a1918, V _a1919, V _a1920, V[] _rest1916) => {
V pl_1923 = default;
V D_1924 = default;
pl_1923 = Call(isPlay_53, V.Undef, S_1921);
D_1924 = NewObj(2).Put("w", ((V)(150D))).Put("d", ((V)(90D))).V;
Set(D_1924, "build", Fn((V _arrowThis1932, int _argc1925, V P_1931, V _a1928, V _a1929, V _a1930, V[] _rest1926) => {
return new ArrBuilder().Add(Call(box_12, V.Undef, ((V)((-36D))), ((V)(0D)), ((V)((-12D))), ((V)(3D)), ((V)(40D)), ((V)(3D)), ((V)("#3f8ad8")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V))).Add(Call(box_12, V.Undef, ((V)((-36D))), ((V)(0D)), ((V)(16D)), ((V)(3D)), ((V)(40D)), ((V)(3D)), ((V)("#3f8ad8")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V))).Add(Call(box_12, V.Undef, ((V)((-36D))), ((V)(40D)), ((V)(2D)), ((V)(3D)), ((V)(3D)), ((V)(31D)), ((V)("#3f8ad8")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V))).Add(Call(box_12, V.Undef, ((V)((-36D))), ((V)(0D)), ((V)(2D)), ((V)(16D)), ((V)(1.6)), ((V)(34D)), ((V)("#3f8ad8")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V))).Add(Call(prism_16, V.Undef, ((V)(26D)), ((V)(34D)), Arr(Arr(((V)((-6D))), ((V)(0D))), Arr(((V)(6D)), ((V)(0D))), Arr(((V)(0D)), ((V)(10D)))), ((V)("#f2c14a")), Call(pt_32, V.Undef, NewObj(0).V))).Spread(Call(rep_19, V.Undef, ((V)(5D)), Fn((V _arrowThis1940, int _argc1933, V i_1939, V _a1936, V _a1937, V _a1938, V[] _rest1934) => {
return Call(cyl_13, V.Undef, ((V)(((-4D) + (ToNum(i_1939) * 7D)))), ((V)(0D)), ((V)(30D)), ((V)(1D)), ((V)(26D)), ((V)((NumTruthy((ToNum(i_1939) % 2D)) ? "#e8343c" : "#ffffff"))), Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true))).V;
}, 1, "", true));
Set(D_1924, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1948, int _argc1941, V P_1947, V _a1944, V _a1945, V _a1946, V[] _rest1942) => {
return Arr(Call(box_12, V.Undef, ((V)(30D)), ((V)(10D)), ((V)(0D)), ((V)(76D)), ((V)(2.2)), ((V)(12D)), ((V)("#e8343c")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)(30D)), ((V)(12.2)), ((V)(0D)), ((V)(76D)), ((V)(0.4)), ((V)(10D)), ((V)("#f4f4f0")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1957, int _argc1949, V p_1955, V s_1956, V _a1953, V _a1954, V[] _rest1950) => {
V pv_1958 = default;
pv_1958 = Call(p_1955, V.Undef, ((V)(30D)), ((V)(10D)), ((V)(0D)));
return ((V)(string.Concat("<g>", ToStr(Call(atV_34, V.Undef, ((V)("rotate")), Arr(((V)(string.Concat("-7 ", ToStr(Call(P2_22, V.Undef, pv_1958))))), ((V)(string.Concat("7 ", ToStr(Call(P2_22, V.Undef, pv_1958))))), ((V)(string.Concat("-7 ", ToStr(Call(P2_22, V.Undef, pv_1958)))))), ((V)(2.6)))), ToStr(s_1956), "</g>")));
return default;
}, 2, "wrap", true)).V));
Set(D_1924, "fx", Fn((V _arrowThis1966, int _argc1959, V c_1965, V _a1962, V _a1963, V _a1964, V[] _rest1960) => {
V p_1967 = default;
V k_1968 = default;
JsStrBuf f_1969 = null;
V un_1970 = default;
V tc_1971 = default;
p_1967 = Get(c_1965, "p");
k_1968 = Get(c_1965, "k");
f_1969 = new JsStrBuf("");
un_1970 = Call(turf_91, V.Undef, p_1967, ((V)(0D)), ((V)(6D)), ((V)(74D)), ((V)(44D)), ((V)("#5aa844")), ((V)("#6fbf54")));
tc_1971 = Call(p_1967, V.Undef, ((V)((-36D))), ((V)(24D)), ((V)(2D)));
f_1969.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, Call(p_1967, V.Undef, ((V)((-36D))), ((V)(40D)), ((V)((-6D)))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_1967, V.Undef, ((V)((-36D))), ((V)(34D)), ((V)((-6D)))))), "M", ToStr(Call(P2_22, V.Undef, Call(p_1967, V.Undef, ((V)((-36D))), ((V)(40D)), ((V)(10D))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_1967, V.Undef, ((V)((-36D))), ((V)(34D)), ((V)(10D))))), "\" stroke=\"#2a2b30\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.6 * ToNum(k_1968)))))), "\"/><g transform=\"translate(", ToStr(Call(P2_22, V.Undef, tc_1971)), ") scale(", ToStr(Call(n4_21, V.Undef, k_1968)), ")\"><ellipse rx=\"4.6\" ry=\"11\" fill=\"none\" stroke=\"#1d1e22\" stroke-width=\"4\"/><ellipse rx=\"4.6\" ry=\"11\" fill=\"none\" stroke=\"#3a3c42\" stroke-width=\"1.2\"/><ellipse cx=\"-0.6\" rx=\"3.6\" ry=\"9.6\" fill=\"none\" stroke=\"#e8343c\" stroke-width=\"0.5\" stroke-dasharray=\"2 2\"/></g>"));
if (Truthy(pl_1923)) {
f_1969.V(Call(ballFly_92, V.Undef, p_1967, k_1968, Arr(Arr(((V)((-60D))), ((V)(2D)), ((V)(2D))), Arr(((V)((-36D))), ((V)(24D)), ((V)(2D))), Arr(((V)((-12D))), ((V)(2D)), ((V)(2D))), Arr(((V)((-12D))), ((V)(2D)), ((V)(2D))), Arr(((V)((-60D))), ((V)(2D)), ((V)(2D)))), ((V)(5D)), Call(BALL_90, V.Undef, ((V)(2D)), ((V)("tennis")))));
}
return NewObj(4).Put("defs", ((V)(""))).Put("under", un_1970).Put("front", ((V)(f_1969.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1967, V.Undef, ((V)((-74D))), ((V)(0D)), ((V)((-40D)))), Call(p_1967, V.Undef, ((V)(74D)), ((V)(0D)), ((V)(50D))), Call(p_1967, V.Undef, ((V)((-74D))), ((V)(0D)), ((V)(50D))), Call(p_1967, V.Undef, ((V)(74D)), ((V)(0D)), ((V)((-40D)))), Call(p_1967, V.Undef, ((V)((-36D))), ((V)(48D)), ((V)(2D))), Call(p_1967, V.Undef, ((V)(68D)), ((V)(20D)), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1924;
return default;
}, 1, "", true));
Set(PL9_89, "agility8", Fn((V _arrowThis1978, int _argc1972, V _a1974, V _a1975, V _a1976, V _a1977, V[] _rest1973) => {
return Arr(NewObj(5).Put("x", ((V)(52D))).Put("y", ((V)(14D))).Put("z", ((V)(0D))).Put("v", ((V)("front"))).Put("a", ((V)("gsee"))).V, NewObj(5).Put("x", ((V)((-52D)))).Put("z", ((V)(2D))).Put("v", ((V)("right"))).Put("a", ((V)("gjump"))).Put("d", ((V)(0.4))).V);
}, 0, "", true));
Set(N_63, "bocce8", Fn((V _arrowThis1986, int _argc1979, V S_1985, V _a1982, V _a1983, V _a1984, V[] _rest1980) => {
V pl_1987 = default;
V CED_1988 = default;
V D_1989 = default;
pl_1987 = Call(isPlay_53, V.Undef, S_1985);
CED_1988 = ((V)("#b9733e"));
D_1989 = NewObj(2).Put("w", ((V)(170D))).Put("d", ((V)(110D))).V;
Set(D_1989, "build", Fn((V _arrowThis1997, int _argc1990, V P_1996, V _a1993, V _a1994, V _a1995, V[] _rest1991) => {
return new ArrBuilder().Add(Call(box_12, V.Undef, ((V)((-30D))), ((V)(0D)), ((V)(30D)), ((V)(110D)), ((V)(4D)), ((V)(4D)), CED_1988, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V))).Add(Call(box_12, V.Undef, ((V)((-30D))), ((V)(0D)), ((V)(60D)), ((V)(110D)), ((V)(4D)), ((V)(4D)), CED_1988, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V))).Add(Call(box_12, V.Undef, ((V)((-85D))), ((V)(0D)), ((V)(45D)), ((V)(4D)), ((V)(4D)), ((V)(34D)), CED_1988, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V))).Add(Call(box_12, V.Undef, ((V)(25D)), ((V)(0D)), ((V)(45D)), ((V)(4D)), ((V)(4D)), ((V)(34D)), CED_1988, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V))).Add(Call(box_12, V.Undef, ((V)((-30D))), ((V)(0D)), ((V)(45D)), ((V)(106D)), ((V)(1.6)), ((V)(26D)), ((V)("#d8c49a")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V))).Add(Call(box_12, V.Undef, ((V)(10D)), ((V)(22D)), ((V)((-22D))), ((V)(76D)), ((V)(2D)), ((V)(40D)), ((V)("#1f5a8a")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V))).Spread(Invoke(Arr(Arr(((V)((-24D))), ((V)((-38D)))), Arr(((V)(44D)), ((V)((-38D)))), Arr(((V)((-24D))), ((V)((-6D)))), Arr(((V)(44D)), ((V)((-6D))))), "map", Fn((V _arrowThis2009, int _argc1998, V _a2000, V _a2001, V _a2002, V _a2003, V[] _rest1999) => {
V x_2006 = default;
V z_2008 = default;
{ V _t2004 = ListOf(_a2000);
{ V _t2005 = GetIdx(_t2004, 0D);
x_2006 = _t2005; }
{ V _t2007 = GetIdx(_t2004, 1D);
z_2008 = _t2007; }
}
return Call(box_12, V.Undef, x_2006, ((V)(0D)), z_2008, ((V)(2.6)), ((V)(22D)), ((V)(2.6)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
}, 1, "", true))).Add(Call(box_12, V.Undef, ((V)(10D)), ((V)(24D)), ((V)((-22D))), ((V)(0.8)), ((V)(6D)), ((V)(42D)), ((V)("#f4f4f0")), NewObj(2).Put("op", ((V)(0.75))).Put("mat", ((V)("fab"))).V)).V;
}, 1, "", true));
Set(D_1989, "fx", Fn((V _arrowThis2017, int _argc2010, V c_2016, V _a2013, V _a2014, V _a2015, V[] _rest2011) => {
V p_2018 = default;
V k_2019 = default;
JsStrBuf f_2020 = null;
p_2018 = Get(c_2016, "p");
k_2019 = Get(c_2016, "k");
f_2020 = new JsStrBuf("");
f_2020.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_2018, ((V)(24.05)))), "\"><rect x=\"-27.6\" y=\"-41.6\" width=\"75.2\" height=\"39.2\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.7\"/><path d=\"M-27.6 -22H47.6\" stroke=\"#ffffff\" stroke-width=\"0.4\"/></g>"));
f_2020.V(Add(Invoke(Invoke(Arr(Arr(((V)((-70D))), ((V)(40D)), ((V)("#c81e2a"))), Arr(((V)((-64D))), ((V)(50D)), ((V)("#c81e2a"))), Arr(((V)((-6D))), ((V)(42D)), ((V)("#2f6a3a"))), Arr(((V)(4D)), ((V)(52D)), ((V)("#2f6a3a")))), "map", Fn((V _arrowThis2034, int _argc2021, V _a2023, V _a2024, V _a2025, V _a2026, V[] _rest2022) => {
V x_2029 = default;
V z_2031 = default;
V c2_2033 = default;
{ V _t2027 = ListOf(_a2023);
{ V _t2028 = GetIdx(_t2027, 0D);
x_2029 = _t2028; }
{ V _t2030 = GetIdx(_t2027, 1D);
z_2031 = _t2030; }
{ V _t2032 = GetIdx(_t2027, 2D);
c2_2033 = _t2032; }
}
return Call(at_72, V.Undef, p_2018, k_2019, x_2029, ((V)(4.6)), z_2031, ((V)(1D)), Call(BALL_90, V.Undef, ((V)(3.2)), c2_2033));
}, 1, "", true)), "join", ((V)(""))), Call(at_72, V.Undef, p_2018, k_2019, ((V)((-20D))), ((V)(2.4)), ((V)(46D)), ((V)(1D)), Call(BALL_90, V.Undef, ((V)(1.4)), ((V)("#fbfbf6"))))));
if (Truthy(pl_1987)) {
f_2020.V(Call(ballFly_92, V.Undef, p_2018, k_2019, Arr(Arr(((V)((-20D))), ((V)(25D)), ((V)((-26D)))), Arr(((V)((-2D))), ((V)(32D)), ((V)((-24D)))), Arr(((V)(10D)), ((V)(30D)), ((V)((-22D)))), Arr(((V)(24D)), ((V)(25D)), ((V)((-20D)))), Arr(((V)(38D)), ((V)(31D)), ((V)((-18D)))), Arr(((V)(44D)), ((V)(26D)), ((V)((-18D)))), Arr(((V)(30D)), ((V)(31D)), ((V)((-20D)))), Arr(((V)(10D)), ((V)(30D)), ((V)((-22D)))), Arr(((V)((-6D))), ((V)(25D)), ((V)((-24D)))), Arr(((V)((-20D))), ((V)(25D)), ((V)((-26D))))), ((V)(1.6)), Call(BALL_90, V.Undef, ((V)(1D)), ((V)("#ffffff")))));
f_2020.V(Call(ballFly_92, V.Undef, p_2018, k_2019, Arr(Arr(((V)((-80D))), ((V)(4.6)), ((V)(45D))), Arr(((V)((-50D))), ((V)(4.6)), ((V)(46D))), Arr(((V)((-24D))), ((V)(4.6)), ((V)(46D))), Arr(((V)((-22D))), ((V)(4.6)), ((V)(46D))), Arr(((V)((-22D))), ((V)(4.6)), ((V)(46D))), Arr(((V)((-80D))), ((V)(4.6)), ((V)(45D)))), ((V)(6D)), Call(BALL_90, V.Undef, ((V)(3.2)), ((V)("#c81e2a")))));
}
return NewObj(3).Put("defs", ((V)(""))).Put("front", ((V)(f_2020.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2018, V.Undef, ((V)((-88D))), ((V)(0D)), ((V)(64D))), Call(p_2018, V.Undef, ((V)(28D)), ((V)(0D)), ((V)(64D))), Call(p_2018, V.Undef, ((V)((-88D))), ((V)(0D)), ((V)(26D))), Call(p_2018, V.Undef, ((V)(48D)), ((V)(0D)), ((V)((-40D)))), Call(p_2018, V.Undef, ((V)((-26D))), ((V)(34D)), ((V)((-40D)))), Call(p_2018, V.Undef, ((V)(48D)), ((V)(34D)), ((V)((-4D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1989;
return default;
}, 1, "", true));
Set(PL9_89, "bocce8", Fn((V _arrowThis2041, int _argc2035, V _a2037, V _a2038, V _a2039, V _a2040, V[] _rest2036) => {
return Arr(NewObj(4).Put("x", ((V)((-38D)))).Put("z", ((V)((-22D)))).Put("v", ((V)("right"))).Put("a", ((V)("gswing"))).V, NewObj(5).Put("x", ((V)(58D))).Put("z", ((V)((-22D)))).Put("v", ((V)("left"))).Put("a", ((V)("gswing"))).Put("d", ((V)(0.5))).V);
}, 0, "", true));
Set(N_63, "tether8", Fn((V _arrowThis2049, int _argc2042, V S_2048, V _a2045, V _a2046, V _a2047, V[] _rest2043) => {
V pl_2050 = default;
double TOP_2051 = 0;
V D_2052 = default;
pl_2050 = Call(isPlay_53, V.Undef, S_2048);
TOP_2051 = 78D;
D_2052 = NewObj(3).Put("w", ((V)(90D))).Put("d", ((V)(90D))).Put("round", ((V)(1D))).V;
Set(D_2052, "build", Fn((V _arrowThis2060, int _argc2053, V P_2059, V _a2056, V _a2057, V _a2058, V[] _rest2054) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(4D)), ((V)("#a9a8a2")), Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(1.6)), ((V)((TOP_2051 - 4D))), ((V)("#e8e4dc")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(TOP_2051)), ((V)(0D)), ((V)(2.2)), ((V)(1.4)), ((V)("#e8343c")), Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)));
}, 1, "", true));
Set(D_2052, "fx", Fn((V _arrowThis2068, int _argc2061, V c_2067, V _a2064, V _a2065, V _a2066, V[] _rest2062) => {
V p_2069 = default;
V k_2070 = default;
JsStrBuf f_2071 = null;
V tp_2072 = default;
p_2069 = Get(c_2067, "p");
k_2070 = Get(c_2067, "k");
f_2071 = new JsStrBuf("");
f_2071.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_2069, ((V)(0.3)))), "\"><circle r=\"36\" fill=\"none\" stroke=\"#f4f4f0\" stroke-width=\"1\" stroke-dasharray=\"3 2\"/><path d=\"M-36 0H36\" stroke=\"#f4f4f0\" stroke-width=\"0.8\" stroke-dasharray=\"3 2\"/></g>"));
tp_2072 = Call(p_2069, V.Undef, ((V)(0D)), ((V)((TOP_2051 - 2D))), ((V)(0D)));
if (Truthy(pl_2050)) {
V pts_2073 = default;
V pth_2074 = default;
pts_2073 = Call(rep_19, V.Undef, ((V)(25D)), Fn((V _arrowThis2082, int _argc2075, V i_2081, V _a2078, V _a2079, V _a2080, V[] _rest2076) => {
double a_2083 = 0;
a_2083 = (((ToNum(i_2081) / 24D) * 2D) * PI_64);
return Call(p_2069, V.Undef, ((V)((FdLibm.Cos(a_2083) * 26D))), ((V)((46D + (FdLibm.Sin((a_2083 * 2D)) * 3D)))), ((V)((FdLibm.Sin(a_2083) * 26D))));
return default;
}, 1, "", true));
pth_2074 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_2073, "map", P2_22), "join", ((V)("L")))).S("Z").End()));
f_2071.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, tp_2072)), "L", ToStr(Call(P2_22, V.Undef, GetIdx(pts_2073, 0D))), "\" stroke=\"#f4efe6\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.6 * ToNum(k_2070)))))), "\"><animate attributeName=\"d\" values=\"", ToStr(Invoke(Invoke(pts_2073, "map", Fn((V _arrowThis2091, int _argc2084, V q_2090, V _a2087, V _a2088, V _a2089, V[] _rest2085) => {
return ((V)(string.Concat("M", ToStr(Call(P2_22, V.Undef, tp_2072)), "L", ToStr(Call(P2_22, V.Undef, q_2090)))));
}, 1, "", true)), "join", ((V)(";")))), "\" dur=\"2.4s\" repeatCount=\"indefinite\"/></path>")).S(string.Concat("<g>", ToStr(Call(amo_68, V.Undef, pth_2074, ((V)(2.4)), ((V)(0D)))), "<g transform=\"scale(", ToStr(Call(n4_21, V.Undef, k_2070)), ")\">", ToStr(Call(BALL_90, V.Undef, ((V)(4.4)), ((V)("#f2d23a")))), "<path d=\"M-3 -1Q0 -3 3 -1\" stroke=\"#c8a81a\" stroke-width=\"0.5\" fill=\"none\"/></g></g>"));
} else {
V b_2092 = default;
b_2092 = Call(p_2069, V.Undef, ((V)(4D)), ((V)(30D)), ((V)(4D)));
f_2071.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, tp_2072)), "Q", ToStr(Call(P2_22, V.Undef, Call(p_2069, V.Undef, ((V)(2D)), ((V)(50D)), ((V)(2D))))), " ", ToStr(Call(P2_22, V.Undef, b_2092)), "\" stroke=\"#f4efe6\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.6 * ToNum(k_2070)))))), "\" fill=\"none\"/>")).V(Call(at_72, V.Undef, p_2069, k_2070, ((V)(4D)), ((V)(30D)), ((V)(4D)), ((V)(1D)), Call(BALL_90, V.Undef, ((V)(4.4)), ((V)("#f2d23a")))));
}
return NewObj(3).Put("defs", ((V)(""))).Put("front", ((V)(f_2071.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2069, V.Undef, ((V)((-38D))), ((V)(0D)), ((V)((-38D)))), Call(p_2069, V.Undef, ((V)(38D)), ((V)(0D)), ((V)(38D))), Call(p_2069, V.Undef, ((V)((-38D))), ((V)(0D)), ((V)(38D))), Call(p_2069, V.Undef, ((V)(38D)), ((V)(0D)), ((V)((-38D)))), Call(p_2069, V.Undef, ((V)(0D)), ((V)((TOP_2051 + 4D))), ((V)(0D))), Call(p_2069, V.Undef, ((V)((-30D))), ((V)(52D)), ((V)(0D))), Call(p_2069, V.Undef, ((V)(30D)), ((V)(52D)), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2052;
return default;
}, 1, "", true));
Set(PL9_89, "tether8", Fn((V _arrowThis2099, int _argc2093, V _a2095, V _a2096, V _a2097, V _a2098, V[] _rest2094) => {
return Arr(NewObj(4).Put("x", ((V)((-24D)))).Put("z", ((V)(18D))).Put("v", ((V)("right"))).Put("a", ((V)("gteth"))).V, NewObj(5).Put("x", ((V)(26D))).Put("z", ((V)((-16D)))).Put("v", ((V)("left"))).Put("a", ((V)("gteth"))).Put("d", ((V)(0.5))).V);
}, 0, "", true));
Set(N_63, "villa8", Fn((V _arrowThis2107, int _argc2100, V S_2106, V _a2103, V _a2104, V _a2105, V[] _rest2101) => {
V pl_2108 = default;
V WT_2109 = default;
V RF_2110 = default;
V D_2111 = default;
pl_2108 = Call(isPlay_53, V.Undef, S_2106);
WT_2109 = ((V)("#f6f2ea"));
RF_2110 = ((V)("#2f5a8a"));
D_2111 = NewObj(2).Put("w", ((V)(160D))).Put("d", ((V)(110D))).V;
Set(D_2111, "build", Fn((V _arrowThis2119, int _argc2112, V P_2118, V _a2115, V _a2116, V _a2117, V[] _rest2113) => {
return new ArrBuilder().Add(Call(box_12, V.Undef, ((V)((-34D))), ((V)(0D)), ((V)((-20D))), ((V)(60D)), ((V)(40D)), ((V)(36D)), WT_2109, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Add(Call(box_12, V.Undef, ((V)((-34D))), ((V)(40D)), ((V)((-20D))), ((V)(64D)), ((V)(3D)), ((V)(40D)), ((V)("#e8e2d4")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V))).Add(Call(prism_16, V.Undef, ((V)((-68D))), ((V)(0D)), Arr(Arr(((V)((-42D))), ((V)(43D))), Arr(((V)(2D)), ((V)(43D))), Arr(((V)((-20D))), ((V)(62D)))), RF_2110, Call(pt_32, V.Undef, NewObj(0).V))).Add(Call(box_12, V.Undef, ((V)((-34D))), ((V)(0D)), ((V)((-1.4))), ((V)(18D)), ((V)(26D)), ((V)(2D)), ((V)("#e8e2d4")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V))).Spread(Invoke(Arr(((V)((-58D))), ((V)((-46D))), ((V)((-22D))), ((V)((-10D)))), "map", Fn((V _arrowThis2127, int _argc2120, V x_2126, V _a2123, V _a2124, V _a2125, V[] _rest2121) => {
return Call(cyl_13, V.Undef, x_2126, ((V)(0D)), ((V)(0D)), ((V)(1.8)), ((V)(40D)), WT_2109, Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(10D))).V));
}, 1, "", true))).Add(Call(box_12, V.Undef, ((V)((-34D))), ((V)(40D)), ((V)(2D)), ((V)(30D)), ((V)(1.6)), ((V)(8D)), ((V)("#e8e2d4")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))).Add(Call(box_12, V.Undef, ((V)((-34D))), ((V)(0D)), ((V)(2D)), ((V)(70D)), ((V)(1.6)), ((V)(10D)), ((V)("#d8cfbe")), Call(cer_31, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))).Add(Call(box_12, V.Undef, ((V)(36D)), ((V)(0D)), ((V)(16D)), ((V)(80D)), ((V)(1D)), ((V)(70D)), ((V)("#7ac8e8")), Call(cer_31, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("shine", ((V)(1D))).V))).V;
}, 1, "", true));
Set(D_2111, "fx", Fn((V _arrowThis2135, int _argc2128, V c_2134, V _a2131, V _a2132, V _a2133, V[] _rest2129) => {
V p_2136 = default;
V k_2137 = default;
JsStrBuf f_2138 = null;
V Wp_2139 = default;
p_2136 = Get(c_2134, "p");
k_2137 = Get(c_2134, "k");
f_2138 = new JsStrBuf("");
f_2138.S(string.Concat("<g transform=\"", ToStr(Call(plane_24, V.Undef, p_2136, ((V)((-1.75))), ((V)(26D)), ((V)((-43D))))), "\"><rect x=\"3\" y=\"4\" width=\"12\" height=\"22\" rx=\"6\" fill=\"#1d2a3a\"/><rect x=\"3\" y=\"4\" width=\"12\" height=\"22\" rx=\"6\" fill=\"none\" stroke=\"", ToStr(GOLD_65), "\" stroke-width=\"0.8\"/><circle cx=\"9\" cy=\"13\" r=\"1.4\" fill=\"#ffe8a0\"/></g>"));
Invoke(Arr(Arr(((V)((-62D))), ((V)(30D))), Arr(((V)((-14D))), ((V)(30D))), Arr(((V)((-62D))), ((V)(12D))), Arr(((V)((-14D))), ((V)(12D)))), "forEach", Fn((V _arrowThis2151, int _argc2140, V _a2142, V _a2143, V _a2144, V _a2145, V[] _rest2141) => {
V x_2148 = default;
V y_2150 = default;
{ V _t2146 = ListOf(_a2142);
{ V _t2147 = GetIdx(_t2146, 0D);
x_2148 = _t2147; }
{ V _t2149 = GetIdx(_t2146, 1D);
y_2150 = _t2149; }
}
return ((V)(f_2138.S(string.Concat("<g transform=\"", ToStr(Call(plane_24, V.Undef, p_2136, ((V)((-1.95))), y_2150, x_2148)), "\"><rect x=\"0\" y=\"0\" width=\"8\" height=\"9\" rx=\"4\" fill=\"#9ad8f2\"/><path d=\"M4 0V9M0 4.5H8\" stroke=\"", ToStr(WT_2109), "\" stroke-width=\"0.8\"/><rect x=\"-0.6\" y=\"9\" width=\"9.2\" height=\"1.4\" fill=\"#e8e2d4\"/></g>")).Str));
}, 1, "", true));
f_2138.S(string.Concat("<g transform=\"", ToStr(Call(plane_24, V.Undef, p_2136, ((V)(2.05)), ((V)(56D)), ((V)((-34D))))), "\"><circle r=\"3\" fill=\"", ToStr(GOLD_65), "\"/><path d=\"M-1.6 0.4Q0 2 1.6 0.4\" stroke=\"#ffffff\" stroke-width=\"0.5\" fill=\"none\"/></g>"));
Wp_2139 = Call(water_47, V.Undef, p_2136, NewObj(6).Put("sh", NewObj(5).Put("cx", ((V)(36D))).Put("cz", ((V)(16D))).Put("hx", ((V)(39D))).Put("hz", ((V)(34D))).Put("r", ((V)(3D))).V).Put("y", ((V)(1.1))).Put("pal", Arr(((V)("#4fb8e0")), ((V)("#7ad8f2")), ((V)("#c8f4ff")), ((V)("#ffffff")))).Put("caust", ((V)(0.5))).Put("gl", ((V)(8D))).Put("rip", Arr(Arr(((V)(20D)), ((V)(0D)), ((V)(6D)), ((V)(1.4)), ((V)(0D))), Arr(((V)(52D)), ((V)(0D)), ((V)(6D)), ((V)(1.6)), ((V)((-0.5)))), Arr(((V)(20D)), ((V)(30D)), ((V)(6D)), ((V)(1.5)), ((V)((-1D)))), Arr(((V)(52D)), ((V)(30D)), ((V)(6D)), ((V)(1.3)), ((V)((-0.3)))), Arr(((V)(36D)), ((V)(16D)), ((V)(8D)), ((V)(1.8)), ((V)((-0.8)))))).V);
f_2138.V(Get(Wp_2139, "svg"));
Invoke(Arr(Arr(((V)(20D)), ((V)(0D))), Arr(((V)(52D)), ((V)(0D))), Arr(((V)(20D)), ((V)(30D))), Arr(((V)(52D)), ((V)(30D))), Arr(((V)(36D)), ((V)(16D)))), "forEach", Fn((V _arrowThis2164, int _argc2152, V _a2154, V i_2158, V _a2156, V _a2157, V[] _rest2153) => {
double h_2165 = 0;
V x_2161 = default;
V z_2163 = default;
{ V _t2159 = ListOf(_a2154);
{ V _t2160 = GetIdx(_t2159, 0D);
x_2161 = _t2160; }
{ V _t2162 = GetIdx(_t2159, 1D);
z_2163 = _t2162; }
}
h_2165 = ((SEqN(i_2158, 4D) ? 30D : 18D) * (Truthy(pl_2108) ? 1D : 0.55));
Call(rep_19, V.Undef, ((V)(4D)), Fn((V _arrowThis2173, int _argc2166, V j_2172, V _a2169, V _a2170, V _a2171, V[] _rest2167) => {
V a_2174 = default;
a_2174 = Add(((V)((((ToNum(j_2172) / 4D) * 2D) * PI_64))), i_2158);
f_2138.V(Call(stream_54, V.Undef, p_2136, k_2137, Arr(x_2161, ((V)(1.2)), z_2163), Arr(Add(x_2161, ((V)((FdLibm.Cos(ToNum(a_2174)) * 3D)))), ((V)((h_2165 + 6D))), Add(z_2163, ((V)((FdLibm.Sin(ToNum(a_2174)) * 3D))))), Arr(Add(x_2161, ((V)((FdLibm.Cos(ToNum(a_2174)) * 8D)))), ((V)(1.2)), Add(z_2163, ((V)((FdLibm.Sin(ToNum(a_2174)) * 8D))))), ((V)(0.8)), ((V)(0.7)), ((V)((((-ToNum(j_2172)) * 0.17) - (ToNum(i_2158) * 0.1))))));
return default;
}, 1, "", true));
f_2138.S(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(Call(p_2136, V.Undef, x_2161, ((V)(1.2)), z_2163), 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(Call(p_2136, V.Undef, x_2161, ((V)(1.2)), z_2163), 1D))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.2 * ToNum(k_2137)))))), "\" fill=\"#c9d0d6\"/>"));
return default;
}, 2, "", true));
return NewObj(3).Put("defs", Add(WDEF_49, Get(Wp_2139, "defs"))).Put("front", ((V)(f_2138.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2136, V.Undef, ((V)((-70D))), ((V)(0D)), ((V)((-40D)))), Call(p_2136, V.Undef, ((V)(78D)), ((V)(0D)), ((V)(52D))), Call(p_2136, V.Undef, ((V)((-70D))), ((V)(0D)), ((V)(52D))), Call(p_2136, V.Undef, ((V)(78D)), ((V)(0D)), ((V)((-20D)))), Call(p_2136, V.Undef, ((V)((-20D))), ((V)(66D)), ((V)((-20D)))), Call(p_2136, V.Undef, ((V)(36D)), ((V)(36D)), ((V)(16D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2111;
return default;
}, 1, "", true));
Set(PL9_89, "villa8", Fn((V _arrowThis2181, int _argc2175, V _a2177, V _a2178, V _a2179, V _a2180, V[] _rest2176) => {
return Arr(NewObj(5).Put("x", ((V)(30D))).Put("y", ((V)(1D))).Put("z", ((V)(10D))).Put("v", ((V)("front"))).Put("a", ((V)("gsplash"))).V, NewObj(6).Put("x", ((V)(48D))).Put("y", ((V)(1D))).Put("z", ((V)(26D))).Put("v", ((V)("front"))).Put("a", ((V)("gsplash"))).Put("d", ((V)(0.4))).V, NewObj(5).Put("x", ((V)((-34D)))).Put("y", ((V)(0D))).Put("z", ((V)(10D))).Put("v", ((V)("front"))).Put("a", ((V)("grest"))).V);
}, 0, "", true));
Set(N_63, "cornhole8", Fn((V _arrowThis2189, int _argc2182, V S_2188, V _a2185, V _a2186, V _a2187, V[] _rest2183) => {
V pl_2190 = default;
V D_2191 = default;
V board_2192 = default;
pl_2190 = Call(isPlay_53, V.Undef, S_2188);
D_2191 = NewObj(2).Put("w", ((V)(170D))).Put("d", ((V)(60D))).V;
board_2192 = Fn((V _arrowThis2202, int _argc2193, V o_2199, V x_2200, V dir_2201, V _a2198, V[] _rest2194) => {
Invoke(o_2199, "push", Call(prism_16, V.Undef, ((V)((ToNum(x_2200) - (12D * ToNum(dir_2201))))), Add(x_2200, ((V)((12D * ToNum(dir_2201))))), Invoke(Arr(Arr(((V)((-11D))), ((V)(0D))), Arr(((V)(11D)), ((V)(0D))), Arr(((V)(11D)), ((V)(1.6))), Arr(((V)((-11D))), ((V)(1.6)))), "map", Fn((V _arrowThis2210, int _argc2203, V q_2209, V _a2206, V _a2207, V _a2208, V[] _rest2204) => {
return q_2209;
}, 1, "", true)), ((V)("#e8dcc0")), Call(wd_30, V.Undef, NewObj(0).V)));
Invoke(o_2199, "push", Call(solid_11, V.Undef, NewObj(7).Put("ax", ((V)("z"))).Put("sh", ((V)("poly"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("pts", Invoke(Arr(Arr(((V)((ToNum(x_2200) - (24D * ToNum(dir_2201))))), ((V)(2D))), Arr(Add(x_2200, ((V)((24D * ToNum(dir_2201))))), ((V)(12D))), Arr(Add(x_2200, ((V)((24D * ToNum(dir_2201))))), ((V)(14D))), Arr(((V)((ToNum(x_2200) - (24D * ToNum(dir_2201))))), ((V)(4D)))), "map", Fn((V _arrowThis2218, int _argc2211, V q_2217, V _a2214, V _a2215, V _a2216, V[] _rest2212) => {
return q_2217;
}, 1, "", true))).Put("rings", Arr(Arr(((V)((-12D))), ((V)(0D))), Arr(((V)(12D)), ((V)(0D))))).Put("col", ((V)((GtN(dir_2201, 0D) ? "#2f6fb0" : "#c81e2a")))).Put("mat", ((V)("paint"))).V));
return default;
}, 3, "", true);
Set(D_2191, "build", Fn((V _arrowThis2226, int _argc2219, V P_2225, V _a2222, V _a2223, V _a2224, V[] _rest2220) => {
V o_2227 = default;
o_2227 = Arr();
Invoke(Arr(Arr(((V)((-56D))), ((V)(1D))), Arr(((V)(56D)), ((V)((-1D))))), "forEach", Fn((V _arrowThis2239, int _argc2228, V _a2230, V _a2231, V _a2232, V _a2233, V[] _rest2229) => {
V x_2236 = default;
V d_2238 = default;
{ V _t2234 = ListOf(_a2230);
{ V _t2235 = GetIdx(_t2234, 0D);
x_2236 = _t2235; }
{ V _t2237 = GetIdx(_t2234, 1D);
d_2238 = _t2237; }
}
Invoke(o_2227, "push", Call(solid_11, V.Undef, NewObj(7).Put("ax", ((V)("z"))).Put("sh", ((V)("poly"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("pts", (GtN(d_2238, 0D) ? Arr(Arr(((V)((ToNum(x_2236) - 24D))), ((V)(0D))), Arr(Add(x_2236, ((V)(24D))), ((V)(10D))), Arr(Add(x_2236, ((V)(24D))), ((V)(12.4))), Arr(((V)((ToNum(x_2236) - 24D))), ((V)(2.4)))) : Arr(Arr(((V)((ToNum(x_2236) - 24D))), ((V)(10D))), Arr(Add(x_2236, ((V)(24D))), ((V)(0D))), Arr(Add(x_2236, ((V)(24D))), ((V)(2.4))), Arr(((V)((ToNum(x_2236) - 24D))), ((V)(12.4)))))).Put("rings", Arr(Arr(((V)((-12D))), ((V)(0D))), Arr(((V)(12D)), ((V)(0D))))).Put("col", ((V)((GtN(d_2238, 0D) ? "#2f6fb0" : "#c81e2a")))).Put("mat", ((V)("paint"))).V), Call(box_12, V.Undef, Add(x_2236, ((V)((ToNum(d_2238) * 22D)))), ((V)(0D)), ((V)((-10D))), ((V)(2D)), ((V)(10D)), ((V)(2D)), ((V)("#a8875a")), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_12, V.Undef, Add(x_2236, ((V)((ToNum(d_2238) * 22D)))), ((V)(0D)), ((V)(10D)), ((V)(2D)), ((V)(10D)), ((V)(2D)), ((V)("#a8875a")), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
return default;
}, 1, "", true));
_ = board_2192;
return o_2227;
return default;
}, 1, "", true));
Set(D_2191, "fx", Fn((V _arrowThis2247, int _argc2240, V c_2246, V _a2243, V _a2244, V _a2245, V[] _rest2241) => {
V p_2248 = default;
V k_2249 = default;
JsStrBuf f_2250 = null;
p_2248 = Get(c_2246, "p");
k_2249 = Get(c_2246, "k");
f_2250 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-56D))), ((V)(1D))), Arr(((V)(56D)), ((V)((-1D))))), "forEach", Fn((V _arrowThis2262, int _argc2251, V _a2253, V _a2254, V _a2255, V _a2256, V[] _rest2252) => {
V hx_2263 = default;
double y_2264 = 0;
V yy_2265 = default;
V h_2266 = default;
V x_2259 = default;
V d_2261 = default;
{ V _t2257 = ListOf(_a2253);
{ V _t2258 = GetIdx(_t2257, 0D);
x_2259 = _t2258; }
{ V _t2260 = GetIdx(_t2257, 1D);
d_2261 = _t2260; }
}
hx_2263 = Add(x_2259, ((V)((ToNum(d_2261) * 12D))));
y_2264 = (GtN(d_2261, 0D) ? ((2.4 + ((36D / 48D) * 10D)) + 0.1) : ((2.4 + ((12D / 48D) * 10D)) + 0.1));
_ = y_2264;
yy_2265 = Fn((V _arrowThis2274, int _argc2267, V xx_2273, V _a2270, V _a2271, V _a2272, V[] _rest2268) => {
return ((V)((GtN(d_2261, 0D) ? (2.4 + (((ToNum(xx_2273) - (ToNum(x_2259) - 24D)) / 48D) * 10D)) : (2.4 + (((ToNum(Add(x_2259, ((V)(24D)))) - ToNum(xx_2273)) / 48D) * 10D)))));
}, 1, "", true);
h_2266 = Call(p_2248, V.Undef, hx_2263, Add(Call(yy_2265, V.Undef, hx_2263), ((V)(0.05))), ((V)(0D)));
f_2250.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(h_2266, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(h_2266, 1D))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((3.4 * ToNum(k_2249)))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((2.6 * ToNum(k_2249)))))), "\" fill=\"#1d1e22\"/><path d=\"M", ToStr(Call(P2_22, V.Undef, Call(p_2248, V.Undef, ((V)((ToNum(x_2259) - 24D))), Add(Call(yy_2265, V.Undef, ((V)((ToNum(x_2259) - 24D)))), ((V)(0.05))), ((V)((-9D)))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_2248, V.Undef, Add(x_2259, ((V)(24D))), Add(Call(yy_2265, V.Undef, Add(x_2259, ((V)(24D)))), ((V)(0.05))), ((V)((-9D)))))), "M", ToStr(Call(P2_22, V.Undef, Call(p_2248, V.Undef, ((V)((ToNum(x_2259) - 24D))), Add(Call(yy_2265, V.Undef, ((V)((ToNum(x_2259) - 24D)))), ((V)(0.05))), ((V)(9D))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_2248, V.Undef, Add(x_2259, ((V)(24D))), Add(Call(yy_2265, V.Undef, Add(x_2259, ((V)(24D)))), ((V)(0.05))), ((V)(9D))))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.7 * ToNum(k_2249)))))), "\" opacity=\"0.8\"/>"));
Invoke(Arr(Arr(((V)((ToNum(x_2259) - (ToNum(d_2261) * 6D)))), ((V)(3D))), Arr(Add(x_2259, ((V)((ToNum(d_2261) * 4D)))), ((V)((-4D))))), "forEach", Fn((V _arrowThis2287, int _argc2275, V _a2277, V j_2281, V _a2279, V _a2280, V[] _rest2276) => {
V bx_2284 = default;
V bz_2286 = default;
{ V _t2282 = ListOf(_a2277);
{ V _t2283 = GetIdx(_t2282, 0D);
bx_2284 = _t2283; }
{ V _t2285 = GetIdx(_t2282, 1D);
bz_2286 = _t2285; }
}
return ((V)(f_2250.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, Call(p_2248, V.Undef, bx_2284, Add(Call(yy_2265, V.Undef, bx_2284), ((V)(0.6))), bz_2286))), ") scale(", ToStr(Call(n4_21, V.Undef, k_2249)), ")\"><rect x=\"-2.4\" y=\"-1.2\" width=\"4.8\" height=\"2.4\" rx=\"0.9\" fill=\"", (NumTruthy((ToNum(Add(j_2281, ((V)((GtN(d_2261, 0D) ? 0D : 1D))))) % 2D)) ? "#c81e2a" : "#2f6fb0"), "\"/></g>")).Str));
}, 2, "", true));
return default;
}, 1, "", true));
if (Truthy(pl_2190)) {
Invoke(Arr(Arr(Arr(((V)((-34D))), ((V)(18D)), ((V)(0D))), Arr(((V)(40D)), ((V)(3D)), ((V)(0D)))), Arr(Arr(((V)(34D)), ((V)(18D)), ((V)(0D))), Arr(((V)((-44D))), ((V)(3D)), ((V)(2D))))), "forEach", Fn((V _arrowThis2300, int _argc2288, V _a2290, V i_2294, V _a2292, V _a2293, V[] _rest2289) => {
V a_2297 = default;
V b_2299 = default;
{ V _t2295 = ListOf(_a2290);
{ V _t2296 = GetIdx(_t2295, 0D);
a_2297 = _t2296; }
{ V _t2298 = GetIdx(_t2295, 1D);
b_2299 = _t2298; }
}
return ((V)(f_2250.V(Call(ballFly_92, V.Undef, p_2248, k_2249, Invoke(Call(arc3_71, V.Undef, a_2297, b_2299, ((V)(26D)), ((V)(12D))), "concat", Arr(b_2299, b_2299, b_2299)), ((V)(2.6)), ((V)(string.Concat("<rect x=\"-2.4\" y=\"-1.2\" width=\"4.8\" height=\"2.4\" rx=\"0.9\" fill=\"", (Truthy(i_2294) ? "#2f6fb0" : "#c81e2a"), "\"/>"))), ((V)(1D)), ((V)(((-ToNum(i_2294)) * 1.3))))).Str));
}, 2, "", true));
}
return NewObj(3).Put("defs", ((V)(""))).Put("front", ((V)(f_2250.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2248, V.Undef, ((V)((-84D))), ((V)(0D)), ((V)((-14D)))), Call(p_2248, V.Undef, ((V)(84D)), ((V)(0D)), ((V)(14D))), Call(p_2248, V.Undef, ((V)((-84D))), ((V)(0D)), ((V)(14D))), Call(p_2248, V.Undef, ((V)(84D)), ((V)(0D)), ((V)((-14D)))), Call(p_2248, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2191;
return default;
}, 1, "", true));
Set(PL9_89, "cornhole8", Fn((V _arrowThis2307, int _argc2301, V _a2303, V _a2304, V _a2305, V _a2306, V[] _rest2302) => {
return Arr(NewObj(4).Put("x", ((V)((-36D)))).Put("z", ((V)(18D))).Put("v", ((V)("right"))).Put("a", ((V)("gtoss"))).V, NewObj(5).Put("x", ((V)(36D))).Put("z", ((V)((-18D)))).Put("v", ((V)("left"))).Put("a", ((V)("gtoss"))).Put("d", ((V)(0.5))).V);
}, 0, "", true));
Set(N_63, "hop8", Fn((V _arrowThis2315, int _argc2308, V S_2314, V _a2311, V _a2312, V _a2313, V[] _rest2309) => {
V pl_2316 = default;
V D_2317 = default;
pl_2316 = Call(isPlay_53, V.Undef, S_2314);
D_2317 = NewObj(2).Put("w", ((V)(150D))).Put("d", ((V)(70D))).V;
Set(D_2317, "build", Fn((V _arrowThis2325, int _argc2318, V P_2324, V _a2321, V _a2322, V _a2323, V[] _rest2319) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(148D)), ((V)(0.8)), ((V)(66D)), ((V)("#a9a8a2")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
Set(D_2317, "fx", Fn((V _arrowThis2333, int _argc2326, V c_2332, V _a2329, V _a2330, V _a2331, V[] _rest2327) => {
V p_2334 = default;
V k_2335 = default;
JsStrBuf f_2336 = null;
V SQ_2337 = default;
V CC_2338 = default;
JsStrBuf g_2339 = null;
p_2334 = Get(c_2332, "p");
k_2335 = Get(c_2332, "k");
f_2336 = new JsStrBuf("");
SQ_2337 = Arr(Arr(((V)((-50D))), ((V)(0D)), ((V)(1D))), Arr(((V)((-34D))), ((V)(0D)), ((V)(2D))), Arr(((V)((-18D))), ((V)((-8D))), ((V)(3D))), Arr(((V)((-18D))), ((V)(8D)), ((V)(4D))), Arr(((V)((-2D))), ((V)(0D)), ((V)(5D))), Arr(((V)(14D)), ((V)((-8D))), ((V)(6D))), Arr(((V)(14D)), ((V)(8D)), ((V)(7D))), Arr(((V)(30D)), ((V)(0D)), ((V)(8D))), Arr(((V)(46D)), ((V)((-8D))), ((V)(9D))), Arr(((V)(46D)), ((V)(8D)), ((V)(10D))));
CC_2338 = Arr(((V)("#ff6a8a")), ((V)("#ffd23a")), ((V)("#6ad8ff")), ((V)("#9af06a")), ((V)("#c89aff")));
g_2339 = new JsStrBuf(string.Concat("<rect x=\"-74\" y=\"-33\" width=\"148\" height=\"66\" fill=\"url(#hp8)\" opacity=\"0.5\"/>", ""));
Invoke(SQ_2337, "forEach", Fn((V _arrowThis2354, int _argc2340, V _a2342, V i_2346, V _a2344, V _a2345, V[] _rest2341) => {
double w_2355 = 0;
double h_2356 = 0;
V x_2349 = default;
V z_2351 = default;
V n_2353 = default;
{ V _t2347 = ListOf(_a2342);
{ V _t2348 = GetIdx(_t2347, 0D);
x_2349 = _t2348; }
{ V _t2350 = GetIdx(_t2347, 1D);
z_2351 = _t2350; }
{ V _t2352 = GetIdx(_t2347, 2D);
n_2353 = _t2352; }
}
w_2355 = 15D;
h_2356 = (GtN(Get(Invoke(SQ_2337, "filter", Fn((V _arrowThis2364, int _argc2357, V q_2363, V _a2360, V _a2361, V _a2362, V[] _rest2358) => {
return (SEq(GetIdx(q_2363, 0D), x_2349) ? V.True : V.False);
}, 1, "", true)), "length"), 1D) ? 15D : 15D);
g_2339.S(string.Concat("<rect x=\"", NumStr((ToNum(x_2349) - (w_2355 / 2D))), "\" y=\"", NumStr((ToNum(z_2351) - (h_2356 / 2D))), "\" width=\"", NumStr(w_2355), "\" height=\"", NumStr(h_2356), "\" fill=\"", ToStr(GetIdx(CC_2338, (ToNum(i_2346) % 5D))), "\" opacity=\"0.18\"/><rect x=\"", NumStr((ToNum(x_2349) - (w_2355 / 2D))), "\" y=\"", NumStr((ToNum(z_2351) - (h_2356 / 2D))), "\" width=\"", NumStr(w_2355), "\" height=\"", NumStr(h_2356), "\" fill=\"none\" stroke=\"#fbfbf6\" stroke-width=\"1.1\" stroke-dasharray=\"6 0.6 3 0.4\" opacity=\"0.92\"/><text x=\"", ToStr(x_2349), "\" y=\"", ToStr(Add(z_2351, ((V)(2.4)))), "\" text-anchor=\"middle\" font-family=\"Comic Sans MS, Marker Felt, cursive\" font-size=\"7\" font-weight=\"700\" fill=\"", ToStr(GetIdx(CC_2338, (ToNum(i_2346) % 5D))), "\" opacity=\"0.95\">", ToStr(n_2353), "</text>"));
return default;
}, 2, "", true));
g_2339.S(string.Concat("<path d=\"M58 -8A10 10 0 0 1 58 8\" fill=\"none\" stroke=\"#fbfbf6\" stroke-width=\"1.1\"/><text x=\"64\" y=\"2.4\" text-anchor=\"middle\" font-family=\"Comic Sans MS, Marker Felt, cursive\" font-size=\"5\" fill=\"#ffd23a\">HOME</text>", ""));
f_2336.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_2334, ((V)(0.85)))), "\">", g_2339.Str, "</g>"));
f_2336.V(Call(at_72, V.Undef, p_2334, k_2335, ((V)((-66D))), ((V)(0.9)), ((V)(26D)), ((V)(1D)), ((V)("<rect x=\"-3\" y=\"-0.8\" width=\"6\" height=\"1.6\" rx=\"0.8\" fill=\"#ff6a8a\"/><rect x=\"1\" y=\"1\" width=\"5\" height=\"1.4\" rx=\"0.7\" fill=\"#6ad8ff\"/>"))));
if (Truthy(pl_2316)) {
f_2336.V(Call(ballFly_92, V.Undef, p_2334, k_2335, Invoke(Call(arc3_71, V.Undef, Arr(((V)((-64D))), ((V)(1.4)), ((V)(20D))), Arr(((V)((-18D))), ((V)(1.4)), ((V)(8D))), ((V)(14D)), ((V)(10D))), "concat", Arr(Arr(((V)((-18D))), ((V)(1.4)), ((V)(8D))), Arr(((V)((-18D))), ((V)(1.4)), ((V)(8D))), Arr(((V)((-18D))), ((V)(1.4)), ((V)(8D))), Arr(((V)((-18D))), ((V)(1.4)), ((V)(8D))), Arr(((V)((-64D))), ((V)(1.4)), ((V)(20D))))), ((V)(6D)), ((V)("<ellipse rx=\"1.8\" ry=\"1\" fill=\"#6a6a64\"/><ellipse cx=\"-0.4\" cy=\"-0.3\" rx=\"0.7\" ry=\"0.35\" fill=\"#9a9a94\"/>"))));
} else {
f_2336.V(Call(at_72, V.Undef, p_2334, k_2335, ((V)((-18D))), ((V)(1.4)), ((V)(8D)), ((V)(1D)), ((V)("<ellipse rx=\"1.8\" ry=\"1\" fill=\"#6a6a64\"/>"))));
}
return NewObj(3).Put("defs", ((V)(string.Concat("<pattern id=\"hp8\" width=\"5\" height=\"5\" patternUnits=\"userSpaceOnUse\"><circle cx=\"1\" cy=\"1\" r=\"0.4\" fill=\"#8a8984\"/><circle cx=\"3.4\" cy=\"3\" r=\"0.3\" fill=\"#c8c7c0\"/></pattern>", "")))).Put("front", ((V)(f_2336.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2334, V.Undef, ((V)((-76D))), ((V)(0D)), ((V)((-35D)))), Call(p_2334, V.Undef, ((V)(76D)), ((V)(0D)), ((V)(35D))), Call(p_2334, V.Undef, ((V)((-76D))), ((V)(0D)), ((V)(35D))), Call(p_2334, V.Undef, ((V)(76D)), ((V)(0D)), ((V)((-35D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2317;
return default;
}, 1, "", true));
Set(PL9_89, "hop8", Fn((V _arrowThis2371, int _argc2365, V _a2367, V _a2368, V _a2369, V _a2370, V[] _rest2366) => {
return Arr(NewObj(4).Put("x", ((V)((-52D)))).Put("z", ((V)(2D))).Put("v", ((V)("right"))).Put("a", ((V)("ghop"))).V, NewObj(5).Put("x", ((V)((-66D)))).Put("z", ((V)(24D))).Put("v", ((V)("front"))).Put("a", ((V)("grest"))).Put("d", ((V)(0.3))).V, NewObj(5).Put("x", ((V)((-64D)))).Put("z", ((V)((-22D)))).Put("v", ((V)("front"))).Put("a", ((V)("gjump"))).Put("d", ((V)(0.6))).V);
}, 0, "", true));
Set(N_63, "shoe8", Fn((V _arrowThis2379, int _argc2372, V S_2378, V _a2375, V _a2376, V _a2377, V[] _rest2373) => {
V pl_2380 = default;
V D_2381 = default;
pl_2380 = Call(isPlay_53, V.Undef, S_2378);
D_2381 = NewObj(2).Put("w", ((V)(170D))).Put("d", ((V)(50D))).V;
Set(D_2381, "build", Fn((V _arrowThis2389, int _argc2382, V P_2388, V _a2385, V _a2386, V _a2387, V[] _rest2383) => {
return new ArrBuilder().Spread(Invoke(Arr(((V)((-60D))), ((V)(60D))), "map", Fn((V _arrowThis2397, int _argc2390, V x_2396, V _a2393, V _a2394, V _a2395, V[] _rest2391) => {
return Call(box_12, V.Undef, x_2396, ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(2.4)), ((V)(22D)), ((V)("#c8a878")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V));
}, 1, "", true))).Spread(Invoke(Arr(((V)((-60D))), ((V)(60D))), "map", Fn((V _arrowThis2405, int _argc2398, V x_2404, V _a2401, V _a2402, V _a2403, V[] _rest2399) => {
return Call(box_12, V.Undef, x_2404, ((V)(0D)), ((V)(0D)), ((V)(34D)), ((V)(3D)), ((V)(2D)), ((V)("#8a5a34")), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
}, 1, "", true))).Spread(Invoke(Arr(((V)((-60D))), ((V)(60D))), "map", Fn((V _arrowThis2413, int _argc2406, V x_2412, V _a2409, V _a2410, V _a2411, V[] _rest2407) => {
return Call(cyl_13, V.Undef, x_2412, ((V)(2.4)), ((V)(0D)), ((V)(0.7)), ((V)(12D)), ((V)("#5a5e66")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V));
}, 1, "", true))).V;
}, 1, "", true));
Set(D_2381, "fx", Fn((V _arrowThis2421, int _argc2414, V c_2420, V _a2417, V _a2418, V _a2419, V[] _rest2415) => {
V p_2422 = default;
V k_2423 = default;
JsStrBuf f_2424 = null;
V SHOE_2425 = default;
p_2422 = Get(c_2420, "p");
k_2423 = Get(c_2420, "k");
f_2424 = new JsStrBuf("");
SHOE_2425 = ((V)("<path d=\"M-2.6 1.6V-0.6A2.6 2.6 0 0 1 2.6 -0.6V1.6\" fill=\"none\" stroke=\"#3a3c42\" stroke-width=\"1.3\" stroke-linecap=\"round\"/><path d=\"M-2.6 1.6V-0.6A2.6 2.6 0 0 1 2.6 -0.6V1.6\" fill=\"none\" stroke=\"#9aa1ad\" stroke-width=\"0.4\"/>"));
Invoke(Arr(Arr(((V)((-60D))), ((V)(6D)), ((V)(4D))), Arr(((V)((-54D))), ((V)((-5D))), ((V)(40D))), Arr(((V)(62D)), ((V)(3D)), ((V)(120D))), Arr(((V)(56D)), ((V)((-6D))), ((V)(200D)))), "forEach", Fn((V _arrowThis2439, int _argc2426, V _a2428, V _a2429, V _a2430, V _a2431, V[] _rest2427) => {
V x_2434 = default;
V z_2436 = default;
V r_2438 = default;
{ V _t2432 = ListOf(_a2428);
{ V _t2433 = GetIdx(_t2432, 0D);
x_2434 = _t2433; }
{ V _t2435 = GetIdx(_t2432, 1D);
z_2436 = _t2435; }
{ V _t2437 = GetIdx(_t2432, 2D);
r_2438 = _t2437; }
}
return ((V)(f_2424.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, Call(p_2422, V.Undef, x_2434, ((V)(2.6)), z_2436))), ") scale(", ToStr(Call(n4_21, V.Undef, ((V)((ToNum(k_2423) * 1.3))))), ") rotate(", ToStr(r_2438), ") scale(1 0.55)\">", ToStr(SHOE_2425), "</g>")).Str));
}, 1, "", true));
if (Truthy(pl_2380)) {
Invoke(Arr(Arr(Arr(((V)((-48D))), ((V)(18D)), ((V)(4D))), Arr(((V)(60D)), ((V)(6D)), ((V)(0D)))), Arr(Arr(((V)(48D)), ((V)(18D)), ((V)((-4D)))), Arr(((V)((-60D))), ((V)(6D)), ((V)(0D))))), "forEach", Fn((V _arrowThis2452, int _argc2440, V _a2442, V i_2446, V _a2444, V _a2445, V[] _rest2441) => {
V a_2449 = default;
V b_2451 = default;
{ V _t2447 = ListOf(_a2442);
{ V _t2448 = GetIdx(_t2447, 0D);
a_2449 = _t2448; }
{ V _t2450 = GetIdx(_t2447, 1D);
b_2451 = _t2450; }
}
f_2424.V(Call(ballFly_92, V.Undef, p_2422, ((V)((ToNum(k_2423) * 1.3))), Invoke(Call(arc3_71, V.Undef, a_2449, b_2451, ((V)(34D)), ((V)(14D))), "concat", Arr(b_2451, b_2451, b_2451, b_2451)), ((V)(3D)), ((V)(string.Concat("<g>", ToStr(Call(atV_34, V.Undef, ((V)("rotate")), Arr(((V)("0")), ((V)("360"))), ((V)(0.6)))), ToStr(SHOE_2425), "</g>"))), ((V)(1D)), ((V)(((-ToNum(i_2446)) * 1.5)))));
f_2424.S(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(CallSpread(p_2422, V.Undef, new ArrBuilder().Spread(b_2451).V), 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(CallSpread(p_2422, V.Undef, new ArrBuilder().Spread(b_2451).V), 1D))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((2D * ToNum(k_2423)))))), "\" fill=\"#ffe8a0\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0;0;1;0;0\" keyTimes=\"0;0.6;0.62;0.66;0.75;1\" dur=\"3s\"", ToStr(Call(B_67, V.Undef, ((V)(((-ToNum(i_2446)) * 1.5))))), " repeatCount=\"indefinite\"/></circle>"));
return default;
}, 2, "", true));
}
return NewObj(3).Put("defs", ((V)(""))).Put("front", ((V)(f_2424.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2422, V.Undef, ((V)((-80D))), ((V)(0D)), ((V)((-14D)))), Call(p_2422, V.Undef, ((V)(80D)), ((V)(0D)), ((V)(14D))), Call(p_2422, V.Undef, ((V)((-80D))), ((V)(0D)), ((V)(14D))), Call(p_2422, V.Undef, ((V)(80D)), ((V)(0D)), ((V)((-14D)))), Call(p_2422, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2381;
return default;
}, 1, "", true));
Set(PL9_89, "shoe8", Fn((V _arrowThis2459, int _argc2453, V _a2455, V _a2456, V _a2457, V _a2458, V[] _rest2454) => {
return Arr(NewObj(4).Put("x", ((V)((-38D)))).Put("z", ((V)(18D))).Put("v", ((V)("right"))).Put("a", ((V)("gtoss"))).V, NewObj(5).Put("x", ((V)(38D))).Put("z", ((V)((-18D)))).Put("v", ((V)("left"))).Put("a", ((V)("gtoss"))).Put("d", ((V)(0.5))).V);
}, 0, "", true));
Set(N_63, "tunnel8", Fn((V _arrowThis2467, int _argc2460, V S_2466, V _a2463, V _a2464, V _a2465, V[] _rest2461) => {
V pl_2468 = default;
double L0_2469 = 0;
double R0_2470 = 0;
V D_2471 = default;
pl_2468 = Call(isPlay_53, V.Undef, S_2466);
L0_2469 = 90D;
R0_2470 = 13D;
D_2471 = NewObj(2).Put("w", ((V)(120D))).Put("d", ((V)(50D))).V;
Set(D_2471, "build", Fn((V _arrowThis2479, int _argc2472, V P_2478, V _a2475, V _a2476, V _a2477, V[] _rest2473) => {
return Arr(Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(R0_2470)))).Put("a", ((V)(R0_2470))).Put("b", ((V)(R0_2470))).Put("n", ((V)(22D))).Put("rings", Call(rep_19, V.Undef, ((V)(9D)), Fn((V _arrowThis2487, int _argc2480, V i_2486, V _a2483, V _a2484, V _a2485, V[] _rest2481) => {
return Arr(((V)((((-L0_2469) / 2D) + ((ToNum(i_2486) * L0_2469) / 8D)))), ((V)(0D)), ((V)((NumTruthy((ToNum(i_2486) % 2D)) ? 0.94 : 1D))));
}, 1, "", true))).Put("col", ((V)("#3f8ad8"))).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V));
}, 1, "", true));
Set(D_2471, "fx", Fn((V _arrowThis2495, int _argc2488, V c_2494, V _a2491, V _a2492, V _a2493, V[] _rest2489) => {
V p_2496 = default;
V k_2497 = default;
JsStrBuf f_2498 = null;
p_2496 = Get(c_2494, "p");
k_2497 = Get(c_2494, "k");
f_2498 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(9D)), Fn((V _arrowThis2506, int _argc2499, V i_2505, V _a2502, V _a2503, V _a2504, V[] _rest2500) => {
double x_2507 = 0;
V pts_2508 = default;
x_2507 = (((-L0_2469) / 2D) + ((ToNum(i_2505) * L0_2469) / 8D));
pts_2508 = Call(rep_19, V.Undef, ((V)(13D)), Fn((V _arrowThis2516, int _argc2509, V j_2515, V _a2512, V _a2513, V _a2514, V[] _rest2510) => {
double a_2517 = 0;
a_2517 = (((-PI_64) * 0.15) + (((ToNum(j_2515) / 12D) * PI_64) * 1.1));
return Call(p_2496, V.Undef, ((V)(x_2507)), ((V)((((((R0_2470 + (((FdLibm.Sin((a_2517 + (PI_64 / 2D))) * R0_2470) * (NumTruthy((ToNum(i_2505) % 2D)) ? 0.94 : 1D)) * 0D)) + ((R0_2470 * FdLibm.Cos(a_2517)) * 0D)) + ((R0_2470 * FdLibm.Sin(((-a_2517) + PI_64))) * 0D)) + (((R0_2470 * (NumTruthy((ToNum(i_2505) % 2D)) ? 0.94 : 1D)) * FdLibm.Cos((a_2517 - (PI_64 / 2D)))) * 0D)) + ((R0_2470 * FdLibm.Sin(a_2517)) * (NumTruthy((ToNum(i_2505) % 2D)) ? 0.94 : 1D))))), ((V)(((R0_2470 * FdLibm.Cos(a_2517)) * (NumTruthy((ToNum(i_2505) % 2D)) ? 0.94 : 1D)))));
return default;
}, 1, "", true));
if (!(NumTruthy((ToNum(i_2505) % 2D)))) {
f_2498.S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(pts_2508, "map", P2_22), "join", ((V)("L")))), "\" fill=\"none\" stroke=\"#1f4a8a\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.9 * ToNum(k_2497)))))), "\" opacity=\"0.7\"/>"));
}
return default;
}, 1, "", true));
f_2498.S(string.Concat("<g transform=\"", ToStr(Call(planeX_25, V.Undef, p_2496, ((V)(((L0_2469 / 2D) + 0.05))), ((V)(R0_2470)), ((V)(0D)))), "\"><ellipse rx=\"", NumStr(R0_2470), "\" ry=\"", NumStr(R0_2470), "\" fill=\"#1a2a4a\"/><ellipse rx=\"", NumStr((R0_2470 * 0.8)), "\" ry=\"", NumStr((R0_2470 * 0.8)), "\" fill=\"#0e1830\"/><ellipse rx=\"", NumStr(R0_2470), "\" ry=\"", NumStr(R0_2470), "\" fill=\"none\" stroke=\"#f2c14a\" stroke-width=\"1.6\"/></g>"));
Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis2525, int _argc2518, V i_2524, V _a2521, V _a2522, V _a2523, V[] _rest2519) => {
double x_2526 = 0;
x_2526 = ((((-L0_2469) / 2D) + 12D) + (ToNum(i_2524) * 32D));
f_2498.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, Call(p_2496, V.Undef, ((V)(x_2526)), ((V)((R0_2470 * 1.6))), ((V)((R0_2470 * 0.8)))))), ") scale(", ToStr(Call(n4_21, V.Undef, k_2497)), ")\"><circle r=\"2\" fill=\"#f2c14a\" opacity=\"0.9\"/><circle r=\"1\" fill=\"#ffffff\"/></g>"));
return default;
}, 1, "", true));
if (Truthy(pl_2468)) {
f_2498.V(Call(ballFly_92, V.Undef, p_2496, k_2497, Arr(Arr(((V)(((L0_2469 / 2D) + 20D))), ((V)(2D)), ((V)(10D))), Arr(((V)(((L0_2469 / 2D) + 4D))), ((V)(2D)), ((V)(4D))), Arr(((V)(((L0_2469 / 2D) - 4D))), ((V)(2D)), ((V)(0D))), Arr(((V)(((L0_2469 / 2D) + 20D))), ((V)(2D)), ((V)(10D)))), ((V)(3.4)), Call(BALL_90, V.Undef, ((V)(2.2)), ((V)("tennis")))));
} else {
f_2498.V(Call(at_72, V.Undef, p_2496, k_2497, ((V)(((L0_2469 / 2D) + 14D))), ((V)(2.2)), ((V)(10D)), ((V)(1D)), Call(BALL_90, V.Undef, ((V)(2.2)), ((V)("tennis")))));
}
return NewObj(3).Put("defs", ((V)(""))).Put("front", ((V)(f_2498.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2496, V.Undef, ((V)((((-L0_2469) / 2D) - 4D))), ((V)(0D)), ((V)((-R0_2470)))), Call(p_2496, V.Undef, ((V)(((L0_2469 / 2D) + 24D))), ((V)(0D)), ((V)((R0_2470 + 10D)))), Call(p_2496, V.Undef, ((V)(((-L0_2469) / 2D))), ((V)(((2D * R0_2470) + 4D))), ((V)(0D))), Call(p_2496, V.Undef, ((V)((L0_2469 / 2D))), ((V)(((2D * R0_2470) + 4D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2471;
return default;
}, 1, "", true));
Set(PL9_89, "tunnel8", Fn((V _arrowThis2533, int _argc2527, V _a2529, V _a2530, V _a2531, V _a2532, V[] _rest2528) => {
return Arr(NewObj(4).Put("x", ((V)(54D))).Put("z", ((V)(14D))).Put("v", ((V)("left"))).Put("a", ((V)("gcrawl"))).V, NewObj(5).Put("x", ((V)((-56D)))).Put("z", ((V)(10D))).Put("v", ((V)("right"))).Put("a", ((V)("gcrawl"))).Put("d", ((V)(0.5))).V);
}, 0, "", true));
Set(N_63, "aframe8", Fn((V _arrowThis2541, int _argc2534, V S_2540, V _a2537, V _a2538, V _a2539, V[] _rest2535) => {
V pl_2542 = default;
V WD_2543 = default;
V D_2544 = default;
pl_2542 = Call(isPlay_53, V.Undef, S_2540);
WD_2543 = ((V)("#c08a52"));
D_2544 = NewObj(2).Put("w", ((V)(140D))).Put("d", ((V)(90D))).V;
Set(D_2544, "build", Fn((V _arrowThis2552, int _argc2545, V P_2551, V _a2548, V _a2549, V _a2550, V[] _rest2546) => {
return Arr(Call(box_12, V.Undef, ((V)((-26D))), ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)(1.4)), ((V)(44D)), ((V)("#a8683a")), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(prismZ_17, V.Undef, ((V)((-18D))), ((V)(18D)), Arr(Arr(((V)((-44D))), ((V)(1.4))), Arr(((V)((-8D))), ((V)(1.4))), Arr(((V)((-26D))), ((V)(33D)))), WD_2543, Call(wd_30, V.Undef, NewObj(0).V)), Call(prismZ_17, V.Undef, ((V)((-20D))), ((V)(20D)), Arr(Arr(((V)((-46.4))), ((V)(0.6))), Arr(((V)((-43D))), ((V)(0.6))), Arr(((V)((-24.4))), ((V)(35D))), Arr(((V)((-27.6))), ((V)(35D)))), ((V)("#7a4a2a")), Call(wd_30, V.Undef, NewObj(0).V)), Call(prismZ_17, V.Undef, ((V)((-20D))), ((V)(20D)), Arr(Arr(((V)((-9D))), ((V)(0.6))), Arr(((V)((-5.6))), ((V)(0.6))), Arr(((V)((-24.4))), ((V)(35D))), Arr(((V)((-27.6))), ((V)(35D)))), ((V)("#7a4a2a")), Call(wd_30, V.Undef, NewObj(0).V)));
}, 1, "", true));
Set(D_2544, "fx", Fn((V _arrowThis2560, int _argc2553, V c_2559, V _a2556, V _a2557, V _a2558, V[] _rest2554) => {
V p_2561 = default;
V k_2562 = default;
JsStrBuf f_2563 = null;
V un_2564 = default;
V FR_2565 = default;
p_2561 = Get(c_2559, "p");
k_2562 = Get(c_2559, "k");
f_2563 = new JsStrBuf("");
un_2564 = Call(turf_91, V.Undef, p_2561, ((V)(26D)), ((V)(6D)), ((V)(40D)), ((V)(40D)), ((V)("#5aa844")), ((V)("#6fbf54")));
f_2563.S(string.Concat("<g transform=\"", ToStr(Call(plane_24, V.Undef, p_2561, ((V)(18.05)), ((V)(33D)), ((V)((-44D))))), "\"><path d=\"M9 31.6V20A9 9 0 0 1 27 20V31.6Z\" fill=\"#2a1a10\"/><path d=\"M9 31.6V20A9 9 0 0 1 27 20V31.6\" fill=\"none\" stroke=\"#7a4a2a\" stroke-width=\"0.8\"/><rect x=\"11\" y=\"9\" width=\"14\" height=\"5\" rx=\"1\" fill=\"#f4efe6\" stroke=\"#7a4a2a\" stroke-width=\"0.4\"/><text x=\"18\" y=\"12.9\" text-anchor=\"middle\" font-family=\"Georgia, serif\" font-size=\"3.4\" font-weight=\"700\" fill=\"#7a4a2a\">SQUISH</text>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(5D)), Fn((V _arrowThis2573, int _argc2566, V i_2572, V _a2569, V _a2570, V _a2571, V[] _rest2567) => {
return ((V)(string.Concat("<path d=\"M", NumStr((5D + (ToNum(i_2572) * 6.5))), " ", NumStr((31D - (ToNum(i_2572) * 0D))), " L18 ", NumStr(0.6), "\" stroke=\"#8a5a30\" stroke-width=\"0.3\" opacity=\"0.45\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g>"));
FR_2565 = ((V)("<ellipse rx=\"4\" ry=\"1.6\" fill=\"#ff4fb8\"/><ellipse rx=\"2.6\" ry=\"0.9\" fill=\"#ff8ad0\"/>"));
if (Truthy(pl_2542)) {
f_2563.V(Call(ballFly_92, V.Undef, p_2561, k_2562, Invoke(Call(arc3_71, V.Undef, Arr(((V)(0D)), ((V)(6D)), ((V)(10D))), Arr(((V)(56D)), ((V)(6D)), ((V)(0D))), ((V)(16D)), ((V)(12D))), "concat", Invoke(Call(arc3_71, V.Undef, Arr(((V)(56D)), ((V)(6D)), ((V)(0D))), Arr(((V)(0D)), ((V)(6D)), ((V)(10D))), ((V)(10D)), ((V)(10D))), "slice", ((V)(1D)))), ((V)(4D)), ((V)(string.Concat("<g>", ToStr(Call(atV_34, V.Undef, ((V)("scale")), Arr(((V)("1 1")), ((V)("1 0.7")), ((V)("1 1"))), ((V)(0.3)))), ToStr(FR_2565), "</g>")))));
} else {
f_2563.V(Call(at_72, V.Undef, p_2561, k_2562, ((V)(30D)), ((V)(0.6)), ((V)(14D)), ((V)(1D)), FR_2565));
}
return NewObj(4).Put("defs", ((V)(""))).Put("under", un_2564).Put("front", ((V)(f_2563.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2561, V.Undef, ((V)((-50D))), ((V)(0D)), ((V)((-22D)))), Call(p_2561, V.Undef, ((V)(66D)), ((V)(0D)), ((V)(46D))), Call(p_2561, V.Undef, ((V)((-50D))), ((V)(0D)), ((V)(22D))), Call(p_2561, V.Undef, ((V)(66D)), ((V)(0D)), ((V)((-34D)))), Call(p_2561, V.Undef, ((V)((-26D))), ((V)(36D)), ((V)(0D))), Call(p_2561, V.Undef, ((V)(30D)), ((V)(26D)), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2544;
return default;
}, 1, "", true));
Set(PL9_89, "aframe8", Fn((V _arrowThis2580, int _argc2574, V _a2576, V _a2577, V _a2578, V _a2579, V[] _rest2575) => {
return Arr(NewObj(4).Put("x", ((V)(50D))).Put("z", ((V)(6D))).Put("v", ((V)("left"))).Put("a", ((V)("gfetch"))).V);
}, 0, "", true));
draw8_93 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis2589, int _argc2581, V r_2587, V o_2588, V _a2585, V _a2586, V[] _rest2582) => {
V res_2590 = default;
res_2590 = Call(draw8_93, V.Undef, r_2587, o_2588);
if (Truthy(((!(Truthy(res_2590)) ? V.True : V.False) is var _t2591 && Truthy(_t2591) ? _t2591 : Get(res_2590, "_p9")))) {
return res_2590;
}
Set(res_2590, "_p9", ((V)(1D)));
try {
V sp0_2592 = default;
sp0_2592 = (Truthy(Get(r_2587, "spec")) ? GetIdx(Invoke(Get(r_2587, "spec"), "split", NewRegExp(RX1, "[.@*+]", "")), 0D) : ((V)("")));
if (Truthy((GetK(PL9_89, sp0_2592) is var _t2593 && !Truthy(_t2593) ? _t2593 : Get(res_2590, "bb")))) {
V p_2594 = default;
p_2594 = Invoke(RD_8, "projOf", ((V)(1D)));
Set(res_2590, "players", Invoke(InvokeK(PL9_89, sp0_2592, (o_2588 is var _t2606 && !Truthy(_t2606) ? _t2606 : Get(o_2588, "st"))), "map", Fn((V _arrowThis2602, int _argc2595, V q_2601, V _a2598, V _a2599, V _a2600, V[] _rest2596) => {
V s_2603 = default;
s_2603 = Call(p_2594, V.Undef, Get(q_2601, "x"), (Get(q_2601, "y") is var _t2604 && Truthy(_t2604) ? _t2604 : ((V)(0D))), Get(q_2601, "z"));
return NewObj(6).Put("x", GetIdx(s_2603, 0D)).Put("y", GetIdx(s_2603, 1D)).Put("v", Get(q_2601, "v")).Put("a", Get(q_2601, "a")).Put("b", (!(!(Truthy(Get(q_2601, "b")))) ? V.True : V.False)).Put("d", (Get(q_2601, "d") is var _t2605 && Truthy(_t2605) ? _t2605 : ((V)(0D)))).V;
return default;
}, 1, "", true)));
}
} catch (System.Exception _ex2607) {
V e_2608 = default;
e_2608 = Caught(_ex2607);
Invoke(G("console"), "warn", ((V)("reno plus9")), Get(r_2587, "id"), e_2608);
}
return res_2590;
return default;
}, 2, "", true));
GAME_94 = Fn((V _arrowThis2621, int _argc2609, V spec_2615, V need_2616, V loop_2617, V live_2618, V[] _rest2610) => {
V note_2619 = default;
V extra_2620 = default;
note_2619 = (_argc2609 > 4 ? _rest2610[0] : V.Undef);
extra_2620 = (_argc2609 > 5 ? _rest2610[1] : V.Undef);
return Object_assign(NewObj(6).Put("spec", spec_2615).Put("play", ((V)("game"))).Put("need", need_2616).Put("loop", loop_2617).Put("live", live_2618).Put("note", note_2619).V, (extra_2620 is var _t2622 && Truthy(_t2622) ? _t2622 : NewObj(0).V));
}, 6, "", true);
Set(RD_8, "SET9", NewObj(27).Put("YRD-039", NewObj(2).Put("spec", ((V)("stump8"))).Put("note", ((V)("A rough-cut stump with flared roots, deep bark ridges and a sanded top that shows its growth rings. Set with a plate of cookies and a glass of lemonade."))).V).Put("YRD-056", NewObj(2).Put("spec", ((V)("mosaic8"))).Put("note", ((V)("A round bistro table with a hand-laid mosaic top (cobalt, terracotta, saffron and white tesserae in rings) on a scrolled wrought-iron base. Set with a cheese board, croissants and iced tea."))).V).Put("YRD-053", NewObj(2).Put("spec", ((V)("limeBench"))).Put("note", ((V)("A curved English limestone bench on three carved pedestals, with lichen spots and scroll detail. A picnic basket and a tea tray sit on it. Seats 3."))).V).Put("YRD-036", NewObj(2).Put("spec", ((V)("picnic8"))).Put("note", ((V)("A redwood A-frame picnic table with attached benches, set with a red gingham runner, watermelon slices, a burger platter, corn, a lemonade pitcher, glasses and ketchup. Seats 4."))).V).Put("YRD-076", NewObj(2).Put("spec", ((V)("teak8"))).Put("note", ((V)("A 10-foot reclaimed teak harvest table on chunky trestle legs, with a linen runner and a full feast: two roast chickens, salad, a bread loaf, a fruit bowl, cheese board, wine and candles."))).V).Put("YRD-096", NewObj(3).Put("spec", ((V)("onyx8"))).Put("live", ((V)("Glowing \u00b7 water flowing"))).Put("note", ((V)("A backlit honey-onyx banquet slab on bronze plinths. A water channel runs down the middle and spills off the end into a small basin. Set with sushi platters, fruit, cheese, champagne flutes and candles."))).V).Put("YRD-088", NewObj(3).Put("spec", ((V)("globe8"))).Put("live", ((V)("Hologram spinning"))).Put("note", ((V)("A chrome pedestal projecting a spinning holographic star-map globe (meridians turning, twinkling stars, constellation line, scan line) next to a floating crystal carafe and glass that bob in the air."))).V).Put("YRD-099", NewObj(3).Put("spec", ((V)("pedestal8"))).Put("live", ((V)("Floating"))).Put("note", ((V)("A solar-cell base that levitates a round drinks tray on a cyan magnetic field: pulsing field rings, a glow underneath, and two drinks riding the floating tray as it bobs."))).V).Put("YRD-028", NewObj(3).Put("spec", ((V)("tub8"))).Put("live", ((V)("Ice cold"))).Put("note", ((V)("A ribbed galvanized drinks tub packed with ice cubes, bottles and cans. Condensation drops slide down the outside and cold mist spills over the rim. A gingham napkin holder sits beside it."))).V).Put("YRD-024", NewObj(3).Put("spec", ((V)("chime8"))).Put("live", ((V)("Swaying \u00b7 ringing"))).Put("note", ((V)("Six copper chime tubes on a shepherd hook, each swinging on its own string, with a clapper and wind sail that ring them (sound rings ripple out). Beside it a painted birdhouse on a post with a little bird peeking out."))).V).Put("YRD-019", NewObj(4).Put("spec", ((V)("bucket8"))).Put("play", ((V)("tip"))).Put("live", ((V)("Tap to tip"))).Put("note", ((V)("An orange 5-gallon bucket turned upside down as a stool. Tap it: it tips over and rolls onto its side, trapped water gushes out into a spreading puddle and a sponge rolls out. Tap again to stand it back up."))).V).Put("YRD-003", NewObj(3).Put("spec", ((V)("zapper8"))).Put("live", ((V)("Zapping"))).Put("note", ((V)("A UV bug-zapper bulb on a post: violet glow behind a steel cage, moths circling the light, and every few seconds a bright zap flash with sparks."))).V).Put("YRD-083", NewObj(3).Put("spec", ((V)("drones8"))).Put("live", ((V)("Swarm flying"))).Put("note", ((V)("A docking hub that sends out a swarm of tiny glowing micro-drones. They fly smooth figure-eight loops in three colour layers, lights pulsing like fireflies."))).V).Put("YRD-104", Call(GAME_94, V.Undef, ((V)("goal8")), ((V)(3D)), ((V)(120D)), ((V)("Needs 3 players")), ((V)("A regulation-style white goal with a full net, back stanchions and painted box lines on striped turf. Needs 3 players (a keeper and two strikers): they dribble, pass and shoot into the net in a 2-minute match that loops.")))).Put("YRD-102", Call(GAME_94, V.Undef, ((V)("hoop8")), ((V)(3D)), ((V)(120D)), ((V)("Needs 3 players")), ((V)("A driveway hoop: steel pole, glass backboard with the red square, orange rim and white net over a concrete court with a key. Needs 3 players for a 2-minute pickup game that loops.")))).Put("YRD-077", Call(GAME_94, V.Undef, ((V)("golf8")), ((V)(2D)), ((V)(60D)), ((V)("Needs 2 players")), ((V)("A three-hole putting green (fringe, cups, numbered flags) with an outdoor cinema screen on a black frame playing a cartoon. Needs 2 players: they putt while the movie plays, looping every minute.")))).Put("YRD-105", Call(GAME_94, V.Undef, ((V)("dome8")), ((V)(4D)), ((V)(60D)), ((V)("Needs 4 players")), ((V)("A sturdy geodesic climbing dome in four colours on a rubber mulch pad. Fits 4 players who climb and play on it in a 1-minute loop.")))).Put("YRD-094", Call(GAME_94, V.Undef, ((V)("bounce8")), ((V)(1D)), ((V)(60D)), ((V)("1 player")), ((V)("A glass anti-gravity dome with a glowing ring base and floating orbs inside, plus an automated fetch launcher that lobs a glowing ball. 1 player bounces and fetches in a 1-minute loop.")))).Put("YRD-054", Call(GAME_94, V.Undef, ((V)("agility8")), ((V)(2D)), ((V)(60D)), ((V)("Needs 2 players")), ((V)("An agility course: a tire jump in a blue frame, a red seesaw on a yellow fulcrum that rocks without stopping, and weave poles on turf. Needs 2 players.")))).Put("YRD-057", Call(GAME_94, V.Undef, ((V)("bocce8")), ((V)(2D)), ((V)(120D)), ((V)("Needs 2 players")), ((V)("A cedar-framed bocce court with red and green balls and a pallino, next to a blue ping-pong table with net. Needs 2 players for a 2-minute rally + bocce match that loops.")))).Put("YRD-103", Call(GAME_94, V.Undef, ((V)("tether8")), ((V)(2D)), ((V)(120D)), ((V)("Needs 2 players")), ((V)("A tetherball pole in a concrete base with a chalk circle. Needs 2 players: the yellow ball whips round the pole on its rope as they strike it, round after round.")))).Put("YRD-074", Call(GAME_94, V.Undef, ((V)("villa8")), ((V)(1D)), ((V)(120D)), ((V)("Up to 3 players")), ((V)("A white mini-mansion for pets: columns, a blue roof with a gold crest, arched door, windows and a balcony, beside a splash pad of rising water jets and ripples. Fits up to 3 for a 2-minute splash-and-play loop.")), NewObj(1).Put("max", ((V)(3D))).V)).Put("YRD-037", Call(GAME_94, V.Undef, ((V)("cornhole8")), ((V)(2D)), ((V)(120D)), ((V)("Needs 2 players")), ((V)("Two angled cornhole boards (blue and red) with holes and edge lines, and beanbags. Needs 2 players: beanbags arc across and land on the boards in a 2-minute match that loops.")))).Put("YRD-101", Call(GAME_94, V.Undef, ((V)("hop8")), ((V)(3D)), ((V)(120D)), ((V)("Needs 3 players")), ((V)("A clean chalk hopscotch court on concrete: numbered squares 1 to 10 in bright chalk colours and a HOME arc. Needs 3 players: one hops, one tosses the stone, one waits, in a 2-minute loop.")))).Put("YRD-017", Call(GAME_94, V.Undef, ((V)("shoe8")), ((V)(2D)), ((V)(120D)), ((V)("Needs 2 players")), ((V)("Two horseshoe pits with sand boxes, wooden backstops and steel stakes. Needs 2 players: horseshoes spin through the air and ring the stakes in a 2-minute match that loops.")), NewObj(1).Put("name", ((V)("Horseshoe Pits with Steel Stakes"))).V)).Put("YRD-014", Call(GAME_94, V.Undef, ((V)("tunnel8")), ((V)(2D)), ((V)(60D)), ((V)("Needs 2 players")), ((V)("A blue pop-up pet tunnel with wire rings and a tennis ball. Needs 2 players who crawl through after the ball in a 1-minute loop.")), NewObj(1).Put("name", ((V)("Pop-Up Pet Tunnel & Tennis Ball"))).V)).Put("YRD-034", Call(GAME_94, V.Undef, ((V)("aframe8")), ((V)(1D)), ((V)(60D)), ((V)("1 player")), ((V)("A cedar A-frame pet house with an arched door and name plate, on a frisbee turf patch. 1 player catches the frisbee and rests in a 1-minute loop.")))).V);
edit8_95 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis2630, int _argc2623, V rows_2629, V _a2626, V _a2627, V _a2628, V[] _rest2624) => {
return Invoke(Call(edit8_95, V.Undef, rows_2629), "map", Fn((V _arrowThis2638, int _argc2631, V r_2637, V _a2634, V _a2635, V _a2636, V[] _rest2632) => {
return (Truthy(GetK(Get(RD_8, "SET9"), Get(r_2637, "id"))) ? Object_assign(NewObj(0).V, r_2637, GetK(Get(RD_8, "SET9"), Get(r_2637, "id"))) : r_2637);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "PLUS9", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
