// reno-plus11.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus11_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("d=\"([^\"]+)\"", "");
        public static void Run()
        {
Call(Named(boot_77 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V slab_11 = default;
V shade_12 = default;
V N_13 = default;
double PI_14 = 0;
V H_15 = default;
V PAT_16 = default;
V cam_17 = default;
V box3_18 = default;
V cyl3_19 = default;
V sph_20 = default;
V shadow_21 = default;
V tanF_22 = default;
V FR_23 = default;
V flip_24 = default;
V KV_25 = default;
V easeA_26 = default;
V mist_27 = default;
V vis_28 = default;
V yawA_29 = default;
V DEF10_30 = default;
V can3_31 = default;
V puffAt_32 = default;
V add_33 = default;
V sub_34 = default;
V mul_35 = default;
V dot_36 = default;
V rng_37 = default;
V isPlay_38 = default;
V an_39 = default;
V at_40 = default;
V SPL_41 = default;
V f1_42 = default;
V n4_43 = default;
V rep_44 = default;
V P2_45 = default;
V FONT_46 = default;
V pth_47 = default;
V hull_48 = default;
V DEF11_49 = default;
V ext_50 = default;
V zsort_51 = default;
V loopF_52 = default;
V slide_53 = default;
V pane_54 = default;
V FACES_55 = default;
V glassBox_56 = default;
V woof_57 = default;
V twt_58 = default;
V baffle_59 = default;
V byDepth_60 = default;
V heap_61 = default;
V CHIP_62 = default;
V chips_63 = default;
V planeE_64 = default;
V BST_65 = default;
V band_66 = default;
V OPEN_67 = default;
V SHOW_68 = default;
V cart11_69 = default;
V PUFF0_70 = default;
V edit10_71 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((((RD_8 is var _t72 && !Truthy(_t72) ? _t72 : Get(RD_8, "PLUS10")) is var _t73 && !Truthy(_t73) ? _t73 : Get(RD_8, "H10")) is var _t74 && !Truthy(_t74) ? _t74 : Get(Get(RD_8, "H10"), "PAT")) is var _t75 && !Truthy(_t75) ? _t75 : X_9) is var _t76 && !Truthy(_t76) ? _t76 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_77.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS11"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t78 = K_10;
if (_t78.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t78));
{ V _t79 = Get(_t78, "slab");
slab_11 = _t79; }
{ V _t80 = Get(_t78, "shade");
shade_12 = _t80; } }
N_13 = Get(RD_8, "N");
PI_14 = System.Math.PI;
H_15 = Get(RD_8, "H10");
{ V _t81 = H_15;
if (_t81.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t81));
{ V _t82 = Get(_t81, "PAT");
PAT_16 = _t82; }
{ V _t83 = Get(_t81, "cam");
cam_17 = _t83; }
{ V _t84 = Get(_t81, "box3");
box3_18 = _t84; }
{ V _t85 = Get(_t81, "cyl3");
cyl3_19 = _t85; }
{ V _t86 = Get(_t81, "sph");
sph_20 = _t86; }
{ V _t87 = Get(_t81, "shadow");
shadow_21 = _t87; }
{ V _t88 = Get(_t81, "tanF");
tanF_22 = _t88; }
{ V _t89 = Get(_t81, "FR");
FR_23 = _t89; }
{ V _t90 = Get(_t81, "flip");
flip_24 = _t90; }
{ V _t91 = Get(_t81, "KV");
KV_25 = _t91; }
{ V _t92 = Get(_t81, "easeA");
easeA_26 = _t92; }
{ V _t93 = Get(_t81, "mist");
mist_27 = _t93; }
{ V _t94 = Get(_t81, "vis");
vis_28 = _t94; }
{ V _t95 = Get(_t81, "yawA");
yawA_29 = _t95; }
{ V _t96 = Get(_t81, "DEF10");
DEF10_30 = _t96; }
{ V _t97 = Get(_t81, "can3");
can3_31 = _t97; }
{ V _t98 = Get(_t81, "puffAt");
puffAt_32 = _t98; }
{ V _t99 = Get(_t81, "add");
add_33 = _t99; }
{ V _t100 = Get(_t81, "sub");
sub_34 = _t100; }
{ V _t101 = Get(_t81, "mul");
mul_35 = _t101; }
{ V _t102 = Get(_t81, "dot");
dot_36 = _t102; }
{ V _t103 = Get(_t81, "rng");
rng_37 = _t103; }
{ V _t104 = Get(_t81, "isPlay");
isPlay_38 = _t104; }
{ V _t105 = Get(_t81, "an");
an_39 = _t105; }
{ V _t106 = Get(_t81, "at");
at_40 = _t106; }
{ V _t107 = Get(_t81, "SPL");
SPL_41 = _t107; }
{ V _t108 = Get(_t81, "f1");
f1_42 = _t108; }
{ V _t109 = Get(_t81, "n4");
n4_43 = _t109; }
{ V _t110 = Get(_t81, "rep");
rep_44 = _t110; }
{ V _t111 = Get(_t81, "P2");
P2_45 = _t111; }
{ V _t112 = Get(_t81, "FONT");
FONT_46 = _t112; }
{ V _t113 = Get(_t81, "pth");
pth_47 = _t113; }
{ V _t114 = Get(_t81, "hull");
hull_48 = _t114; } }
Object_assign(PAT_16, NewObj(4).Put("wood", ((V)("m11wood"))).Put("marb", ((V)("m11marb"))).Put("qz", ((V)("m11qz"))).Put("fab", ((V)("m11fab"))).V);
DEF11_49 = ((V)(JsStrBuf.Begin().V(DEF10_30).S("<pattern id=\"m11wood\" width=\"46\" height=\"6.4\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 1.1C9 0.5 20 1.9 31 1S42 0.7 46 1.1\" stroke=\"#2a1404\" stroke-opacity=\"0.26\" stroke-width=\"0.35\" fill=\"none\"/><path d=\"M0 3.4C11 4.2 23 2.8 34 3.7S43 3.2 46 3.4\" stroke=\"#2a1404\" stroke-opacity=\"0.16\" stroke-width=\"0.7\" fill=\"none\"/><path d=\"M0 5.4C14 5 27 6 46 5.4\" stroke=\"#ffe2b8\" stroke-opacity=\"0.13\" stroke-width=\"0.3\" fill=\"none\"/></pattern>").S("<pattern id=\"m11marb\" width=\"64\" height=\"44\" patternUnits=\"userSpaceOnUse\"><path d=\"M-2 20C18 24 40 16 66 22\" stroke=\"#ddd7cc\" stroke-opacity=\"0.55\" stroke-width=\"2.6\" fill=\"none\"/><path d=\"M-2 8C10 10 16 4 26 9S44 18 52 12 62 8 66 10\" stroke=\"#8f897f\" stroke-opacity=\"0.4\" stroke-width=\"0.45\" fill=\"none\"/><path d=\"M4 30C14 26 22 34 34 29S50 36 66 31\" stroke=\"#a39c90\" stroke-opacity=\"0.32\" stroke-width=\"0.3\" fill=\"none\"/><path d=\"M26 9C28 16 24 22 30 29\" stroke=\"#a39c90\" stroke-opacity=\"0.26\" stroke-width=\"0.25\" fill=\"none\"/><path d=\"M8 40C20 38 30 43 44 40\" stroke=\"#c4a160\" stroke-opacity=\"0.34\" stroke-width=\"0.35\" fill=\"none\"/></pattern>").S("<pattern id=\"m11qz\" width=\"4\" height=\"4\" patternUnits=\"userSpaceOnUse\"><circle cx=\"0.8\" cy=\"1\" r=\"0.22\" fill=\"#4a4a4a\" fill-opacity=\"0.35\"/><circle cx=\"2.9\" cy=\"2.6\" r=\"0.16\" fill=\"#ffffff\" fill-opacity=\"0.75\"/><circle cx=\"1.9\" cy=\"3.4\" r=\"0.18\" fill=\"#7a7570\" fill-opacity=\"0.3\"/><circle cx=\"3.4\" cy=\"0.6\" r=\"0.12\" fill=\"#2a2a2a\" fill-opacity=\"0.3\"/></pattern>").S("<pattern id=\"m11fab\" width=\"0.9\" height=\"0.9\" patternUnits=\"userSpaceOnUse\"><rect width=\"0.45\" height=\"0.45\" fill=\"#ffffff\" fill-opacity=\"0.07\"/><rect x=\"0.45\" y=\"0.45\" width=\"0.45\" height=\"0.45\" fill=\"#000000\" fill-opacity=\"0.14\"/></pattern>").S("<pattern id=\"m11str\" width=\"2.2\" height=\"2\" patternUnits=\"userSpaceOnUse\"><rect width=\"1.1\" height=\"2\" fill=\"#d8283c\" fill-opacity=\"0.85\"/></pattern>").S("<pattern id=\"m11rib\" width=\"4\" height=\"1.6\" patternUnits=\"userSpaceOnUse\"><rect width=\"4\" height=\"0.6\" fill=\"#000000\" fill-opacity=\"0.22\"/><rect y=\"0.6\" width=\"4\" height=\"0.3\" fill=\"#ffffff\" fill-opacity=\"0.3\"/></pattern>").S("<filter id=\"m11b8\" x=\"-60%\" y=\"-60%\" width=\"220%\" height=\"220%\"><feGaussianBlur stdDeviation=\"8\"/></filter><filter id=\"m11b4\" x=\"-60%\" y=\"-60%\" width=\"220%\" height=\"220%\"><feGaussianBlur stdDeviation=\"4\"/></filter>").S("<linearGradient id=\"m11gl\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.3\"/><stop offset=\"0.28\" stop-color=\"#ffffff\" stop-opacity=\"0.03\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.15\"/><stop offset=\"0.56\" stop-color=\"#ffffff\" stop-opacity=\"0.02\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0.1\"/></linearGradient>").S("<radialGradient id=\"m11warm\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#ffd27a\" stop-opacity=\"0.9\"/><stop offset=\"0.5\" stop-color=\"#ffab3a\" stop-opacity=\"0.32\"/><stop offset=\"1\" stop-color=\"#ff8a1a\" stop-opacity=\"0\"/></radialGradient>").S("<radialGradient id=\"m11cy\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#8ff6ff\" stop-opacity=\"0.85\"/><stop offset=\"0.5\" stop-color=\"#3fd0ff\" stop-opacity=\"0.28\"/><stop offset=\"1\" stop-color=\"#3fd0ff\" stop-opacity=\"0\"/></radialGradient>").S("<radialGradient id=\"wfc11\" cx=\"45%\" cy=\"40%\" r=\"62%\"><stop offset=\"0\" stop-color=\"#5c6066\"/><stop offset=\"0.7\" stop-color=\"#202125\"/><stop offset=\"1\" stop-color=\"#0c0c0e\"/></radialGradient>").S("<radialGradient id=\"wfk11\" cx=\"42%\" cy=\"38%\" r=\"64%\"><stop offset=\"0\" stop-color=\"#e0a254\"/><stop offset=\"0.6\" stop-color=\"#9a5a22\"/><stop offset=\"1\" stop-color=\"#3a1e08\"/></radialGradient>").S("<radialGradient id=\"wfd11\" cx=\"36%\" cy=\"30%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#a9aeb6\"/><stop offset=\"0.45\" stop-color=\"#3c3f45\"/><stop offset=\"1\" stop-color=\"#101113\"/></radialGradient>").S("<radialGradient id=\"twd11\" cx=\"35%\" cy=\"30%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#e2e4e7\"/><stop offset=\"0.5\" stop-color=\"#6c6f74\"/><stop offset=\"1\" stop-color=\"#232427\"/></radialGradient>").End()));
ext_50 = Fn((V _arrowThis123, int _argc115, V C_121, V P_122, V _a119, V _a120, V[] _rest116) => {
return Invoke(P_122, "forEach", Fn((V _arrowThis131, int _argc124, V q_130, V _a127, V _a128, V _a129, V[] _rest125) => {
return Invoke(C_121, "P", q_130);
}, 1, "", true));
}, 2, "", true);
zsort_51 = Fn((V _arrowThis140, int _argc132, V C_138, V L_139, V _a136, V _a137, V[] _rest133) => {
return Invoke(Invoke(Invoke(L_139, "sort", Fn((V _arrowThis157, int _argc149, V a_155, V b_156, V _a153, V _a154, V[] _rest150) => {
return ((V)((ToNum(Call(dot_36, V.Undef, Get(a_155, "q"), Get(C_138, "v"))) - ToNum(Call(dot_36, V.Undef, Get(b_156, "q"), Get(C_138, "v"))))));
}, 2, "", true)), "map", Fn((V _arrowThis148, int _argc141, V o_147, V _a144, V _a145, V _a146, V[] _rest142) => {
return Get(o_147, "s");
}, 1, "", true)), "join", ((V)("")));
}, 2, "", true);
loopF_52 = Fn((V _arrowThis167, int _argc158, V frames_164, V T_165, V b_166, V _a163, V[] _rest159) => {
V n_168 = default;
V bg_169 = default;
n_168 = Get(frames_164, "length");
if (LtN(n_168, 2D)) {
return Invoke(frames_164, "join", ((V)("")));
}
bg_169 = ((V)((Truthy(b_166) ? string.Concat(" begin=\"", ToStr(Call(n4_43, V.Undef, b_166)), "s\"") : "")));
return Invoke(Invoke(Invoke(frames_164, "concat", Arr(GetIdx(frames_164, 0D))), "map", Fn((V _arrowThis178, int _argc170, V s_176, V i_177, V _a174, V _a175, V[] _rest171) => {
V P_179 = default;
P_179 = (SEqN(i_177, 0D) ? Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)((0.5 / ToNum(n_168)))), ((V)(1D))), Arr(((V)((1D / ToNum(n_168)))), ((V)(0D))), Arr(((V)(1D)), ((V)(0D)))) : (SEq(i_177, n_168) ? Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(((ToNum(n_168) - 1D) / ToNum(n_168)))), ((V)(0D))), Arr(((V)(((ToNum(n_168) - 0.5) / ToNum(n_168)))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))) : Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(((ToNum(i_177) - 1D) / ToNum(n_168)))), ((V)(0D))), Arr(((V)(((ToNum(i_177) - 0.5) / ToNum(n_168)))), ((V)(1D))), Arr(((V)((ToNum(Add(i_177, ((V)(0.5)))) / ToNum(n_168)))), ((V)(1D))), Arr(((V)((ToNum(Add(i_177, ((V)(1D)))) / ToNum(n_168)))), ((V)(0D))), Arr(((V)(1D)), ((V)(0D))))));
return ((V)(string.Concat("<g opacity=\"", NumStr((Truthy(i_177) ? 0D : 1D)), "\"><animate attributeName=\"opacity\" ", ToStr(Call(KV_25, V.Undef, P_179)), " dur=\"", ToStr(Call(n4_43, V.Undef, T_165)), "s\"", ToStr(bg_169), " repeatCount=\"indefinite\"/>", ToStr(s_176), "</g>")));
return default;
}, 2, "", true)), "join", ((V)("")));
return default;
}, 3, "", true);
slide_53 = Fn((V _arrowThis193, int _argc180, V C_186, V s_187, V O_188, V keys_189, V[] _rest181) => {
V q0_194 = default;
V V_195 = default;
V kt_190 = default;
V T_191 = default;
V o_192 = default;
kt_190 = (_argc180 > 4 ? _rest181[0] : V.Undef);
T_191 = (_argc180 > 5 ? _rest181[1] : V.Undef);
o_192 = (_argc180 > 6 ? _rest181[2] : V.Undef);
q0_194 = Invoke(C_186, "P", O_188);
V_195 = Invoke(keys_189, "map", Fn((V _arrowThis203, int _argc196, V d_202, V _a199, V _a200, V _a201, V[] _rest197) => {
V q_204 = default;
q_204 = Invoke(C_186, "P", Arr(Add(GetIdx(O_188, 0D), GetIdx(d_202, 0D)), Add(GetIdx(O_188, 1D), GetIdx(d_202, 1D)), Add(GetIdx(O_188, 2D), GetIdx(d_202, 2D))));
return ((V)(JsStrBuf.Begin().V(Call(f1_42, V.Undef, ((V)((ToNum(GetIdx(q_204, 0D)) - ToNum(GetIdx(q0_194, 0D))))))).S(" ").V(Call(f1_42, V.Undef, ((V)((ToNum(GetIdx(q_204, 1D)) - ToNum(GetIdx(q0_194, 1D))))))).End()));
return default;
}, 1, "", true));
return ((V)(string.Concat("<g", (Truthy((o_192 is var _t205 && !Truthy(_t205) ? _t205 : Get(o_192, "once"))) ? string.Concat(" transform=\"translate(", ToStr(GetIdx(V_195, (ToNum(Get(V_195, "length")) - 1D))), ")\"") : ""), "><animateTransform attributeName=\"transform\" type=\"translate\" values=\"", ToStr(Invoke(V_195, "join", ((V)(";")))), "\" keyTimes=\"", ToStr(kt_190), "\" dur=\"", ToStr(Call(n4_43, V.Undef, T_191)), "s\" calcMode=\"spline\" keySplines=\"", ToStr(Invoke(Call(rep_44, V.Undef, ((V)((ToNum(Get(keys_189, "length")) - 1D))), Fn((V _arrowThis212, int _argc206, V _a208, V _a209, V _a210, V _a211, V[] _rest207) => {
return ((V)("0.42 0 0.58 1"));
}, 0, "", true)), "join", ((V)(";")))), "\"", (Truthy((o_192 is var _t213 && !Truthy(_t213) ? _t213 : Get(o_192, "once"))) ? " fill=\"freeze\"" : " repeatCount=\"indefinite\""), "/>", ToStr(s_187), "</g>")));
return default;
}, 7, "", true);
pane_54 = Fn((V _arrowThis227, int _argc214, V C_220, V O_221, V U_222, V V_223, V[] _rest215) => {
V w_224 = default;
V h_225 = default;
V o_226 = default;
w_224 = (_argc214 > 4 ? _rest215[0] : V.Undef);
h_225 = (_argc214 > 5 ? _rest215[1] : V.Undef);
o_226 = (_argc214 > 6 ? _rest215[2] : V.Undef);
o_226 = (o_226 is var _t228 && Truthy(_t228) ? _t228 : NewObj(0).V);
return ((V)(string.Concat(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_220, O_221, U_222, V_223)), "\"><rect width=\"", ToStr(Call(f1_42, V.Undef, w_224)), "\" height=\"", ToStr(Call(f1_42, V.Undef, h_225)), "\" fill=\"", ToStr((Get(o_226, "tint") is var _t229 && Truthy(_t229) ? _t229 : ((V)("#d6eef6")))), "\" opacity=\"", ToStr((Get(o_226, "t").IsNullish ? ((V)(0.1)) : Get(o_226, "t"))), "\"/><rect width=\"", ToStr(Call(f1_42, V.Undef, w_224)), "\" height=\"", ToStr(Call(f1_42, V.Undef, h_225)), "\" fill=\"url(#m11gl)\" opacity=\"", ToStr((Get(o_226, "g").IsNullish ? ((V)(1D)) : Get(o_226, "g"))), "\"/>"), string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(w_224) * 0.2))))), " 0L", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(w_224) * 0.06))))), " ", ToStr(Call(f1_42, V.Undef, h_225)), "H", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(w_224) * 0.13))))), "L", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(w_224) * 0.27))))), " 0Z\" fill=\"#ffffff\" opacity=\"", NumStr((Get(o_226, "g").IsNullish ? 0.1 : (0.1 * ToNum(Get(o_226, "g"))))), "\"/><rect width=\"", ToStr(Call(f1_42, V.Undef, w_224)), "\" height=\"", ToStr(Call(f1_42, V.Undef, h_225)), "\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"", ToStr((Get(o_226, "e").IsNullish ? ((V)(0.45)) : Get(o_226, "e"))), "\" stroke-width=\"0.35\"/></g>"))));
return default;
}, 7, "", true);
FACES_55 = Fn((V _arrowThis240, int _argc230, V c_236, V w_237, V h_238, V d_239, V[] _rest231) => {
double hw_241 = 0;
double hd_242 = 0;
V y_243 = default;
hw_241 = (ToNum(w_237) / 2D);
hd_242 = (ToNum(d_239) / 2D);
y_243 = Add(GetIdx(c_236, 1D), h_238);
return Arr(NewObj(4).Put("n", Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))).Put("O", Arr(((V)((ToNum(GetIdx(c_236, 0D)) - hw_241))), y_243, Add(GetIdx(c_236, 2D), ((V)(hd_242))))).Put("U", Arr(((V)(1D)), ((V)(0D)), ((V)(0D)))).Put("W", w_237).V, NewObj(4).Put("n", Arr(((V)(1D)), ((V)(0D)), ((V)(0D)))).Put("O", Arr(Add(GetIdx(c_236, 0D), ((V)(hw_241))), y_243, Add(GetIdx(c_236, 2D), ((V)(hd_242))))).Put("U", Arr(((V)(0D)), ((V)(0D)), ((V)((-1D))))).Put("W", d_239).V, NewObj(4).Put("n", Arr(((V)(0D)), ((V)(0D)), ((V)((-1D))))).Put("O", Arr(Add(GetIdx(c_236, 0D), ((V)(hw_241))), y_243, ((V)((ToNum(GetIdx(c_236, 2D)) - hd_242))))).Put("U", Arr(((V)((-1D))), ((V)(0D)), ((V)(0D)))).Put("W", w_237).V, NewObj(4).Put("n", Arr(((V)((-1D))), ((V)(0D)), ((V)(0D)))).Put("O", Arr(((V)((ToNum(GetIdx(c_236, 0D)) - hw_241))), y_243, ((V)((ToNum(GetIdx(c_236, 2D)) - hd_242))))).Put("U", Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))).Put("W", d_239).V);
return default;
}, 4, "", true);
glassBox_56 = Fn((V _arrowThis256, int _argc244, V C_250, V c_251, V w_252, V h_253, V[] _rest245) => {
JsStrBuf back_257 = null;
JsStrBuf front_258 = null;
V d_254 = default;
V o_255 = default;
d_254 = (_argc244 > 4 ? _rest245[0] : V.Undef);
o_255 = (_argc244 > 5 ? _rest245[1] : V.Undef);
back_257 = new JsStrBuf("");
front_258 = new JsStrBuf("");
Invoke(Call(FACES_55, V.Undef, c_251, w_252, h_253, d_254), "forEach", Fn((V _arrowThis266, int _argc259, V F_265, V _a262, V _a263, V _a264, V[] _rest260) => {
if (Truthy(Call(vis_28, V.Undef, C_250, Get(F_265, "n")))) {
front_258.V(Call(pane_54, V.Undef, C_250, Get(F_265, "O"), Get(F_265, "U"), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))), Get(F_265, "W"), h_253, o_255));
} else {
back_257.V(Call(pane_54, V.Undef, C_250, Get(F_265, "O"), Get(F_265, "U"), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))), Get(F_265, "W"), h_253, Object_assign(NewObj(0).V, o_255, NewObj(3).Put("t", ((V)(0.05))).Put("g", ((V)(0.35))).Put("e", ((V)(0.22))).V)));
}
return default;
}, 1, "", true));
if (Truthy((o_255 is var _t267 && !Truthy(_t267) ? _t267 : Get(o_255, "top")))) {
V T_268 = default;
T_268 = Arr(((V)((ToNum(GetIdx(c_251, 0D)) - (ToNum(w_252) / 2D)))), Add(GetIdx(c_251, 1D), h_253), ((V)((ToNum(GetIdx(c_251, 2D)) - (ToNum(d_254) / 2D)))));
front_258.V(Call(pane_54, V.Undef, C_250, T_268, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), w_252, d_254, NewObj(3).Put("t", ((V)(0.06))).Put("g", ((V)(0.5))).Put("e", ((V)(0.4))).V));
}
Call(ext_50, V.Undef, C_250, Arr(Arr(((V)((ToNum(GetIdx(c_251, 0D)) - (ToNum(w_252) / 2D)))), GetIdx(c_251, 1D), ((V)((ToNum(GetIdx(c_251, 2D)) - (ToNum(d_254) / 2D))))), Arr(Add(GetIdx(c_251, 0D), ((V)((ToNum(w_252) / 2D)))), Add(GetIdx(c_251, 1D), h_253), Add(GetIdx(c_251, 2D), ((V)((ToNum(d_254) / 2D)))))));
return NewObj(2).Put("back", ((V)(back_257.Str))).Put("front", ((V)(front_258.Str))).V;
return default;
}, 6, "", true);
woof_57 = Fn((V _arrowThis281, int _argc269, V cx_275, V cy_276, V r_277, V on_278, V[] _rest270) => {
V ph_279 = default;
V cu_280 = default;
ph_279 = (_argc269 > 4 ? _rest270[0] : V.Undef);
cu_280 = (_argc269 > 5 ? _rest270[1] : V.Undef);
return ((V)(string.Concat(string.Concat("<g transform=\"translate(", ToStr(Call(f1_42, V.Undef, cx_275)), " ", ToStr(Call(f1_42, V.Undef, cy_276)), ")\"><circle r=\"", ToStr(Call(f1_42, V.Undef, r_277)), "\" fill=\"#0a0a0b\"/><circle r=\"", ToStr(Call(f1_42, V.Undef, r_277)), "\" fill=\"none\" stroke=\"", (Truthy(cu_280) ? "#8c6a34" : "#55585e"), "\" stroke-width=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_277) * 0.07))))), "\"/>"), string.Concat("<g>", ToStr((Truthy(on_278) ? Call(at_40, V.Undef, ((V)("scale")), ((V)("1;1.07;0.97;1")), ((V)(0.46)), (ph_279 is var _t282 && Truthy(_t282) ? _t282 : ((V)(0D))), Call(SPL_41, V.Undef, ((V)(3D)))) : ((V)("")))), "<circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_277) * 0.86))))), "\" fill=\"#26272b\"/><circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_277) * 0.8))))), "\" fill=\"none\" stroke=\"#3d3f44\" stroke-width=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_277) * 0.1))))), "\"/><circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_277) * 0.7))))), "\" fill=\"url(#", (Truthy(cu_280) ? "wfk11" : "wfc11"), ")\"/><circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_277) * 0.28))))), "\" fill=\"url(#wfd11)\"/>"), string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(r_277)) * 0.62))))), " ", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(r_277)) * 0.42))))), "A", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_277) * 0.78))))), " ", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_277) * 0.78))))), " 0 0 1 ", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_277) * 0.42))))), " ", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(r_277)) * 0.64))))), "\" stroke=\"#ffffff\" stroke-opacity=\"0.2\" stroke-width=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_277) * 0.07))))), "\" fill=\"none\"/></g></g>"))));
}, 6, "", true);
twt_58 = Fn((V _arrowThis293, int _argc283, V cx_289, V cy_290, V r_291, V gold_292, V[] _rest284) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_42, V.Undef, cx_289)), " ", ToStr(Call(f1_42, V.Undef, cy_290)), ")\"><circle r=\"", ToStr(Call(f1_42, V.Undef, r_291)), "\" fill=\"#141416\" stroke=\"", (Truthy(gold_292) ? "#b8913f" : "#4a4c51"), "\" stroke-width=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_291) * 0.14))))), "\"/><circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_291) * 0.6))))), "\" fill=\"url(#twd11)\"/><circle cx=\"", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(r_291)) * 0.2))))), "\" cy=\"", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(r_291)) * 0.22))))), "\" r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(r_291) * 0.15))))), "\" fill=\"#ffffff\" opacity=\"0.75\"/></g>")));
}, 4, "", true);
baffle_59 = Fn((V _arrowThis303, int _argc294, V w_300, V h_301, V c_302, V _a299, V[] _rest295) => {
return ((V)(string.Concat("<rect width=\"", ToStr(Call(f1_42, V.Undef, w_300)), "\" height=\"", ToStr(Call(f1_42, V.Undef, h_301)), "\" rx=\"0.8\" fill=\"", ToStr((c_302 is var _t304 && Truthy(_t304) ? _t304 : ((V)("#18191c")))), "\"/><rect width=\"", ToStr(Call(f1_42, V.Undef, w_300)), "\" height=\"", ToStr(Call(f1_42, V.Undef, h_301)), "\" rx=\"0.8\" fill=\"url(#m10noise)\"/><rect width=\"", ToStr(Call(f1_42, V.Undef, w_300)), "\" height=\"", ToStr(Call(f1_42, V.Undef, h_301)), "\" rx=\"0.8\" fill=\"url(#m10v)\"/><rect x=\"0.35\" y=\"0.35\" width=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(w_300) - 0.7))))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(h_301) - 0.7))))), "\" rx=\"0.6\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.6\" stroke-width=\"0.3\"/>")));
}, 3, "", true);
byDepth_60 = Fn((V _arrowThis313, int _argc305, V C_311, V L_312, V _a309, V _a310, V[] _rest306) => {
return Invoke(L_312, "sort", Fn((V _arrowThis322, int _argc314, V a_320, V b_321, V _a318, V _a319, V[] _rest315) => {
return ((V)((ToNum(Call(dot_36, V.Undef, a_320, Get(C_311, "v"))) - ToNum(Call(dot_36, V.Undef, b_321, Get(C_311, "v"))))));
}, 2, "", true));
}, 2, "", true);
heap_61 = Fn((V _arrowThis339, int _argc323, V C_329, V cx_330, V cz_331, V rx_332, V[] _rest324) => {
V R_340 = default;
V rz_333 = default;
V y0_334 = default;
V hg_335 = default;
V n_336 = default;
V seed_337 = default;
V sc_338 = default;
rz_333 = (_argc323 > 4 ? _rest324[0] : V.Undef);
y0_334 = (_argc323 > 5 ? _rest324[1] : V.Undef);
hg_335 = (_argc323 > 6 ? _rest324[2] : V.Undef);
n_336 = (_argc323 > 7 ? _rest324[3] : V.Undef);
seed_337 = (_argc323 > 8 ? _rest324[4] : V.Undef);
sc_338 = (_argc323 > 9 ? _rest324[5] : V.Undef);
R_340 = Call(rng_37, V.Undef, seed_337);
return Invoke(Invoke(Call(byDepth_60, V.Undef, C_329, Call(rep_44, V.Undef, n_336, Fn((V _arrowThis355, int _argc349, V _a351, V _a352, V _a353, V _a354, V[] _rest350) => {
double a_356 = 0;
double d_357 = 0;
a_356 = ((ToNum(Call(R_340, V.Undef)) * 2D) * PI_14);
d_357 = System.Math.Sqrt(ToNum(Call(R_340, V.Undef)));
return Arr(Add(cx_330, ((V)(((d_357 * ToNum(rx_332)) * FdLibm.Cos(a_356))))), Add(Add(y0_334, ((V)((ToNum(hg_335) * (1D - (d_357 * d_357)))))), ((V)((ToNum(Call(R_340, V.Undef)) * 1.1)))), Add(cz_331, ((V)(((d_357 * ToNum(rz_333)) * FdLibm.Sin(a_356))))), ((V)((ToNum(Call(R_340, V.Undef)) * 360D))), ((V)((ToNum((sc_338 is var _t358 && Truthy(_t358) ? _t358 : ((V)(1D)))) * (0.9 + (ToNum(Call(R_340, V.Undef)) * 0.3))))));
return default;
}, 0, "", true))), "map", Fn((V _arrowThis348, int _argc341, V q_347, V _a344, V _a345, V _a346, V[] _rest342) => {
return Call(puffAt_32, V.Undef, C_329, q_347, GetIdx(q_347, 4D), GetIdx(q_347, 3D));
}, 1, "", true)), "join", ((V)("")));
return default;
}, 10, "", true);
CHIP_62 = ((V)("<path d=\"M-1.7 1.1L1.8 0.7L0.1 -1.9Z\" fill=\"#f0bf4c\" stroke=\"#b9801c\" stroke-width=\"0.2\" stroke-linejoin=\"round\"/><path d=\"M-0.6 0.4l0.5 -0.9\" stroke=\"#ffe39a\" stroke-width=\"0.3\"/><circle cx=\"0.6\" cy=\"0.1\" r=\"0.18\" fill=\"#c98a2a\"/>"));
chips_63 = Fn((V _arrowThis374, int _argc359, V C_365, V cx_366, V cz_367, V rx_368, V[] _rest360) => {
V R_375 = default;
V rz_369 = default;
V y0_370 = default;
V hg_371 = default;
V n_372 = default;
V seed_373 = default;
rz_369 = (_argc359 > 4 ? _rest360[0] : V.Undef);
y0_370 = (_argc359 > 5 ? _rest360[1] : V.Undef);
hg_371 = (_argc359 > 6 ? _rest360[2] : V.Undef);
n_372 = (_argc359 > 7 ? _rest360[3] : V.Undef);
seed_373 = (_argc359 > 8 ? _rest360[4] : V.Undef);
R_375 = Call(rng_37, V.Undef, seed_373);
return Invoke(Invoke(Call(byDepth_60, V.Undef, C_365, Call(rep_44, V.Undef, n_372, Fn((V _arrowThis391, int _argc385, V _a387, V _a388, V _a389, V _a390, V[] _rest386) => {
double a_392 = 0;
double d_393 = 0;
a_392 = ((ToNum(Call(R_375, V.Undef)) * 2D) * PI_14);
d_393 = System.Math.Sqrt(ToNum(Call(R_375, V.Undef)));
return Arr(Add(cx_366, ((V)(((d_393 * ToNum(rx_368)) * FdLibm.Cos(a_392))))), Add(Add(y0_370, ((V)((ToNum(hg_371) * (1D - (d_393 * d_393)))))), ((V)((ToNum(Call(R_375, V.Undef)) * 0.8)))), Add(cz_367, ((V)(((d_393 * ToNum(rz_369)) * FdLibm.Sin(a_392))))), ((V)((ToNum(Call(R_375, V.Undef)) * 360D))), ((V)((0.9 + (ToNum(Call(R_375, V.Undef)) * 0.4)))));
return default;
}, 0, "", true))), "map", Fn((V _arrowThis383, int _argc376, V q_382, V _a379, V _a380, V _a381, V[] _rest377) => {
V c_384 = default;
c_384 = Invoke(C_365, "P", q_382);
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_45, V.Undef, c_384)), ") rotate(", ToStr(Call(f1_42, V.Undef, GetIdx(q_382, 3D))), ") scale(", ToStr(Call(n4_43, V.Undef, ((V)((ToNum(Get(C_365, "k")) * ToNum(GetIdx(q_382, 4D))))))), ")\">", ToStr(CHIP_62), "</g>")));
return default;
}, 1, "", true)), "join", ((V)("")));
return default;
}, 9, "", true);
planeE_64 = Fn((V _arrowThis409, int _argc394, V C_400, V x_401, V y_402, V z_403, V[] _rest395) => {
V rx_404 = default;
V rz_405 = default;
V fill_406 = default;
V op_407 = default;
V ex_408 = default;
rx_404 = (_argc394 > 4 ? _rest395[0] : V.Undef);
rz_405 = (_argc394 > 5 ? _rest395[1] : V.Undef);
fill_406 = (_argc394 > 6 ? _rest395[2] : V.Undef);
op_407 = (_argc394 > 7 ? _rest395[3] : V.Undef);
ex_408 = (_argc394 > 8 ? _rest395[4] : V.Undef);
return ((V)(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_400, Arr(x_401, y_402, z_403), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><ellipse rx=\"", ToStr(Call(f1_42, V.Undef, rx_404)), "\" ry=\"", ToStr(Call(f1_42, V.Undef, rz_405)), "\" fill=\"", ToStr(fill_406), "\"", (!op_407.IsNullish ? string.Concat(" opacity=\"", ToStr(op_407), "\"") : ""), ">", ToStr((ex_408 is var _t410 && Truthy(_t410) ? _t410 : ((V)("")))), "</ellipse></g>")));
}, 9, "", true);
BST_65 = NewObj(2).Put("chrome", Arr(Arr(((V)(0D)), ((V)(0.55))), Arr(((V)(0.12)), ((V)(1.6))), Arr(((V)(0.25)), ((V)(0.9))), Arr(((V)(0.45)), ((V)(0.45))), Arr(((V)(0.6)), ((V)(1.3))), Arr(((V)(0.78)), ((V)(0.6))), Arr(((V)(0.9)), ((V)(1.4))), Arr(((V)(1D)), ((V)(0.5))))).Put("gloss", Arr(Arr(((V)(0D)), ((V)(0.75))), Arr(((V)(0.2)), ((V)(1.35))), Arr(((V)(0.5)), ((V)(1D))), Arr(((V)(1D)), ((V)(0.7))))).V;
band_66 = Fn((V _arrowThis425, int _argc411, V C_417, V c_418, V y0_419, V y1_420, V[] _rest412) => {
double n_426 = 0;
V P0_427 = default;
V P1_428 = default;
V id_429 = default;
V a_430 = default;
V b_431 = default;
V r_421 = default;
V col_422 = default;
V mat_423 = default;
V back_424 = default;
r_421 = (_argc411 > 4 ? _rest412[0] : V.Undef);
col_422 = (_argc411 > 5 ? _rest412[1] : V.Undef);
mat_423 = (_argc411 > 6 ? _rest412[2] : V.Undef);
back_424 = (_argc411 > 7 ? _rest412[3] : V.Undef);
n_426 = 40D;
P0_427 = Arr();
P1_428 = Arr();
{
double i_432 = 0;
i_432 = 0D;
while (true) {
if (!((i_432 <= n_426))) break;
V t_434 = default;
double sx_435 = 0;
double sz_436 = 0;
t_434 = Add(Add(Get(C_417, "thV"), ((V)((Truthy(back_424) ? (PI_14 / 2D) : ((-PI_14) / 2D))))), ((V)(((i_432 / n_426) * PI_14))));
sx_435 = FdLibm.Sin(ToNum(t_434));
sz_436 = FdLibm.Cos(ToNum(t_434));
Invoke(P1_428, "push", Invoke(C_417, "p", Add(GetIdx(c_418, 0D), ((V)((ToNum(r_421) * sx_435)))), y1_420, Add(GetIdx(c_418, 2D), ((V)((ToNum(r_421) * sz_436))))));
Invoke(P0_427, "push", Invoke(C_417, "p", Add(GetIdx(c_418, 0D), ((V)((ToNum(r_421) * sx_435)))), y0_419, Add(GetIdx(c_418, 2D), ((V)((ToNum(r_421) * sz_436))))));
i_432++;
}
}
id_429 = Invoke(C_417, "u", ((V)("b")));
a_430 = GetIdx(P1_428, 0D);
b_431 = GetIdx(P1_428, n_426);
return ((V)(string.Concat("<defs><linearGradient id=\"", ToStr(id_429), "\" gradientUnits=\"userSpaceOnUse\" x1=\"", ToStr(Call(f1_42, V.Undef, GetIdx(a_430, 0D))), "\" y1=\"", ToStr(Call(f1_42, V.Undef, GetIdx(a_430, 1D))), "\" x2=\"", ToStr(Call(f1_42, V.Undef, GetIdx(b_431, 0D))), "\" y2=\"", ToStr(Call(f1_42, V.Undef, GetIdx(b_431, 1D))), "\">", ToStr(Invoke(Invoke((GetK(BST_65, mat_423) is var _t449 && Truthy(_t449) ? _t449 : Get(BST_65, "gloss")), "map", Fn((V _arrowThis448, int _argc437, V _a439, V _a440, V _a441, V _a442, V[] _rest438) => {
V t_445 = default;
V f_447 = default;
{ V _t443 = ListOf(_a439);
{ V _t444 = GetIdx(_t443, 0D);
t_445 = _t444; }
{ V _t446 = GetIdx(_t443, 1D);
f_447 = _t446; }
}
return ((V)(string.Concat("<stop offset=\"", ToStr(t_445), "\" stop-color=\"", ToStr(Call(shade_12, V.Undef, col_422, ((V)((ToNum(f_447) * (Truthy(back_424) ? 0.7 : 1D)))))), "\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</linearGradient></defs><path d=\"M", ToStr(Invoke(Invoke(P1_428, "map", P2_45), "join", ((V)("L")))), "L", ToStr(Invoke(Invoke(Invoke(P0_427, "reverse"), "map", P2_45), "join", ((V)("L")))), "Z\" fill=\"url(#", ToStr(id_429), ")\" stroke=\"", ToStr(Call(shade_12, V.Undef, col_422, ((V)(0.45)))), "\" stroke-width=\"0.25\" stroke-opacity=\"0.6\"/>")));
return default;
}, 8, "", true);
OPEN_67 = Fn((V _arrowThis460, int _argc450, V l_456, V s_457, V note_458, V ex_459, V[] _rest451) => {
return Object_assign(NewObj(7).Put("play", ((V)("open"))).Put("playL", ((V)(JsStrBuf.Begin().S("Open the ").V(l_456).End()))).Put("stopL", ((V)(JsStrBuf.Begin().S("Close the ").V(l_456).End()))).Put("playS", s_457).Put("idleS", ((V)(JsStrBuf.Begin().S("Tap to open the ").V(l_456).End()))).Put("live", ((V)("Opens"))).Put("note", note_458).V, (ex_459 is var _t461 && Truthy(_t461) ? _t461 : NewObj(0).V));
}, 4, "", true);
SHOW_68 = Fn((V _arrowThis474, int _argc462, V pl_468, V sl_469, V s_470, V idle_471, V[] _rest463) => {
V note_472 = default;
V ex_473 = default;
note_472 = (_argc462 > 4 ? _rest463[0] : V.Undef);
ex_473 = (_argc462 > 5 ? _rest463[1] : V.Undef);
return Object_assign(NewObj(7).Put("play", ((V)("show"))).Put("playL", pl_468).Put("stopL", sl_469).Put("playS", s_470).Put("idleS", idle_471).Put("live", ((V)("Tap to run"))).Put("note", note_472).V, (ex_473 is var _t475 && Truthy(_t475) ? _t475 : NewObj(0).V));
}, 6, "", true);
Set(N_13, "qled11", Fn((V _arrowThis483, int _argc476, V S_482, V _a479, V _a480, V _a481, V[] _rest477) => {
double TW_484 = 0;
double TH_485 = 0;
double TD_486 = 0;
double ZB_487 = 0;
double ZF_488 = 0;
double BZ_489 = 0;
double BB_490 = 0;
double SW_491 = 0;
double SH_492 = 0;
V D_493 = default;
V front_494 = default;
TW_484 = 190D;
TH_485 = 108D;
TD_486 = 2.2;
ZB_487 = 3.4;
ZF_488 = (ZB_487 + TD_486);
BZ_489 = 1.4;
BB_490 = 2.8;
SW_491 = (TW_484 - (2D * BZ_489));
SH_492 = ((TH_485 - BZ_489) - BB_490);
D_493 = NewObj(6).Put("w", ((V)(196D))).Put("d", ((V)(10D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(30D))).Put("act", ((V)("watch"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(160D))).V).V;
Set(D_493, "build", Fn((V _arrowThis501, int _argc495, V _a497, V _a498, V _a499, V _a500, V[] _rest496) => {
return Arr(Call(slab_11, V.Undef, ((V)(0D)), ((V)(BB_490)), ((V)((ZF_488 + 0.05))), ((V)(SW_491)), ((V)(SH_492)), ((V)(0.2)), ((V)("#000000")), NewObj(5).Put("scr", ((V)(1D))).Put("r", ((V)(0.3))).Put("emit", ((V)(1D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0D))).V));
}, 0, "", true));
front_494 = ((V)(JsStrBuf.Begin().S(string.Concat("<defs><linearGradient id=\"ql11s\" x1=\"0\" y1=\"0\" x2=\"0.3\" y2=\"1\"><stop offset=\"0\" stop-color=\"#262a31\"/><stop offset=\"0.45\" stop-color=\"#101216\"/><stop offset=\"1\" stop-color=\"#050506\"/></linearGradient><linearGradient id=\"ql11r\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.075\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient></defs>", "")).S(string.Concat("<rect width=\"", NumStr(TW_484), "\" height=\"", NumStr(TH_485), "\" fill=\"#0c0d10\"/><rect x=\"", NumStr(BZ_489), "\" y=\"", NumStr(BZ_489), "\" width=\"", ToStr(Call(f1_42, V.Undef, ((V)(SW_491)))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(SH_492)))), "\" fill=\"url(#ql11s)\"/>")).S(string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((BZ_489 + (SW_491 * 0.5)))))), " ", NumStr(BZ_489), "H", ToStr(Call(f1_42, V.Undef, ((V)((BZ_489 + (SW_491 * 0.72)))))), "L", ToStr(Call(f1_42, V.Undef, ((V)((BZ_489 + (SW_491 * 0.5)))))), " ", ToStr(Call(f1_42, V.Undef, ((V)((BZ_489 + SH_492))))), "H", ToStr(Call(f1_42, V.Undef, ((V)((BZ_489 + (SW_491 * 0.28)))))), "Z\" fill=\"url(#ql11r)\"/><path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((BZ_489 + (SW_491 * 0.76)))))), " ", NumStr(BZ_489), "H", ToStr(Call(f1_42, V.Undef, ((V)((BZ_489 + (SW_491 * 0.8)))))), "L", ToStr(Call(f1_42, V.Undef, ((V)((BZ_489 + (SW_491 * 0.58)))))), " ", ToStr(Call(f1_42, V.Undef, ((V)((BZ_489 + SH_492))))), "H", ToStr(Call(f1_42, V.Undef, ((V)((BZ_489 + (SW_491 * 0.54)))))), "Z\" fill=\"#ffffff\" opacity=\"0.025\"/>")).S(string.Concat("<rect x=\"", NumStr(BZ_489), "\" y=\"", NumStr(BZ_489), "\" width=\"", ToStr(Call(f1_42, V.Undef, ((V)(SW_491)))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)((SH_492 * 0.22))))), "\" fill=\"#ffffff\" opacity=\"0.018\"/><path d=\"M", NumStr(BZ_489), " ", NumStr((BZ_489 + 0.15)), "H", ToStr(Call(f1_42, V.Undef, ((V)((TW_484 - BZ_489))))), "\" stroke=\"#ffffff\" stroke-opacity=\"0.1\" stroke-width=\"0.3\"/>")).S(string.Concat("<text x=\"", NumStr((TW_484 / 2D)), "\" y=\"", ToStr(Call(f1_42, V.Undef, ((V)((TH_485 - 0.75))))), "\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"1.5\" letter-spacing=\"0.6\" fill=\"#7d838b\">QLED</text><circle cx=\"", NumStr(((TW_484 / 2D) + 60D)), "\" cy=\"", ToStr(Call(f1_42, V.Undef, ((V)((TH_485 - 1.3))))), "\" r=\"0.32\" fill=\"#ffffff\" opacity=\"0.55\"/>")).End()));
Set(D_493, "fx", Fn((V _arrowThis509, int _argc502, V ctx_508, V _a505, V _a506, V _a507, V[] _rest503) => {
V C_510 = default;
V QC_511 = default;
JsStrBuf s_512 = null;
C_510 = Call(cam_17, V.Undef, ctx_508);
QC_511 = ((V)("#5b6cff;#b04dff;#ff5a8a;#ffb347;#33c9d6;#5b6cff"));
s_512 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_510, Arr(((V)(((-TW_484) / 2D))), ((V)(TH_485)), ((V)(0.1))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\" color=\"#5b6cff\">", ToStr(Call(an_39, V.Undef, ((V)("color")), QC_511, ((V)(18D)))))).V(Invoke(Invoke(Arr(Arr(((V)(30D)), ((V)(0.07))), Arr(((V)(22D)), ((V)(0.1))), Arr(((V)(15D)), ((V)(0.14))), Arr(((V)(9D)), ((V)(0.2))), Arr(((V)(4D)), ((V)(0.26)))), "map", Fn((V _arrowThis524, int _argc513, V _a515, V _a516, V _a517, V _a518, V[] _rest514) => {
V e_521 = default;
V op_523 = default;
{ V _t519 = ListOf(_a515);
{ V _t520 = GetIdx(_t519, 0D);
e_521 = _t520; }
{ V _t522 = GetIdx(_t519, 1D);
op_523 = _t522; }
}
return ((V)(string.Concat("<rect x=\"", NumStr((-ToNum(e_521))), "\" y=\"", NumStr((-ToNum(e_521))), "\" width=\"", NumStr((TW_484 + (2D * ToNum(e_521)))), "\" height=\"", NumStr((TH_485 + (2D * ToNum(e_521)))), "\" rx=\"", ToStr(Add(e_521, ((V)(2D)))), "\" fill=\"currentColor\" opacity=\"", ToStr(op_523), "\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("</g>").S(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_510, Arr(((V)(((-TW_484) / 2D))), ((V)(TH_485)), ((V)(0.15))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect x=\"1\" y=\"2.5\" width=\"", NumStr((TW_484 + 3D)), "\" height=\"", NumStr((TH_485 + 3D)), "\" rx=\"3\" fill=\"#000000\" opacity=\"0.12\"/><rect x=\"2.2\" y=\"3.6\" width=\"", NumStr(TW_484), "\" height=\"", NumStr(TH_485), "\" rx=\"2\" fill=\"#000000\" opacity=\"0.14\"/></g>")).End());
s_512.V(Call(box3_18, V.Undef, C_510, NewObj(8).Put("c", Arr(((V)(0D)), ((V)(30D)), ((V)((ZB_487 / 2D))))).Put("w", ((V)(70D))).Put("h", ((V)(44D))).Put("d", ((V)(ZB_487))).Put("r", ((V)(0.6))).Put("col", ((V)("#26282c"))).Put("mat", ((V)("brush"))).Put("olw", ((V)(0.3))).V));
s_512.V(Call(box3_18, V.Undef, C_510, NewObj(12).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)((ZB_487 + (TD_486 / 2D)))))).Put("w", ((V)(TW_484))).Put("h", ((V)(TH_485))).Put("d", ((V)(TD_486))).Put("r", ((V)(0.5))).Put("col", ((V)("#35383e"))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.6))).Put("dec", NewObj(1).Put("f", front_494).V).Put("olc", ((V)("#050506"))).Put("olw", ((V)(0.5))).Put("edge", ((V)(0.4))).V));
Call(ext_50, V.Undef, C_510, Arr(Arr(((V)((((-TW_484) / 2D) - 24D))), ((V)((TH_485 + 24D))), ((V)(0D))), Arr(((V)(((TW_484 / 2D) + 24D))), ((V)((-20D))), ((V)(0D)))));
return NewObj(3).Put("defs", DEF11_49).Put("front", ((V)(s_512.Str))).Put("bb", Invoke(C_510, "bb", ((V)(2D)))).V;
return default;
}, 1, "", true));
return D_493;
return default;
}, 1, "", true));
Set(N_13, "ust11", Fn((V _arrowThis532, int _argc525, V S_531, V _a528, V _a529, V _a530, V[] _rest526) => {
double W_533 = 0;
double Hh_534 = 0;
double Dd_535 = 0;
V D_536 = default;
V front_537 = default;
V top_538 = default;
V side_539 = default;
W_533 = 62D;
Hh_534 = 13D;
Dd_535 = 36D;
D_536 = NewObj(3).Put("w", ((V)(74D))).Put("d", ((V)(44D))).Put("build", Fn((V _arrowThis546, int _argc540, V _a542, V _a543, V _a544, V _a545, V[] _rest541) => {
return Arr();
}, 0, "build", true)).V;
front_537 = ((V)(string.Concat(string.Concat("<rect x=\"2.6\" y=\"2.8\" width=\"", NumStr((W_533 - 5.2)), "\" height=\"", NumStr((Hh_534 - 4.6)), "\" rx=\"1.4\" fill=\"#34363b\"/><rect x=\"2.6\" y=\"2.8\" width=\"", NumStr((W_533 - 5.2)), "\" height=\"", NumStr((Hh_534 - 4.6)), "\" rx=\"1.4\" fill=\"url(#m11fab)\"/><rect x=\"2.6\" y=\"2.8\" width=\"", NumStr((W_533 - 5.2)), "\" height=\"", NumStr((Hh_534 - 4.6)), "\" rx=\"1.4\" fill=\"url(#m10v)\"/><path d=\"M3.4 3.1H", NumStr((W_533 - 3.4)), "\" stroke=\"#ffffff\" stroke-opacity=\"0.14\" stroke-width=\"0.3\"/>"), string.Concat("<rect x=\"", NumStr(((W_533 / 2D) - 4D)), "\" y=\"", NumStr((Hh_534 - 3.7)), "\" width=\"8\" height=\"1.2\" rx=\"0.5\" fill=\"#c9ccd0\"/><text x=\"", NumStr((W_533 / 2D)), "\" y=\"", NumStr((Hh_534 - 2.8)), "\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"0.8\" fill=\"#3a3c40\" letter-spacing=\"0.3\">LASER TV</text>"))));
top_538 = ((V)(string.Concat(string.Concat("<defs><linearGradient id=\"us11w\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#2a2d36\"/><stop offset=\"0.5\" stop-color=\"#0b0c10\"/><stop offset=\"1\" stop-color=\"#1a1c22\"/></linearGradient></defs><rect x=\"7\" y=\"3\" width=\"", NumStr((W_533 - 14D)), "\" height=\"9.6\" rx=\"3\" fill=\"#c9c9c5\"/><rect x=\"7.6\" y=\"3.5\" width=\"", NumStr((W_533 - 15.2)), "\" height=\"8.6\" rx=\"2.6\" fill=\"url(#us11w)\"/>"), string.Concat("<rect x=\"", NumStr(((W_533 / 2D) - 13D)), "\" y=\"6.6\" width=\"26\" height=\"1.6\" rx=\"0.8\" fill=\"#bfe2ff\" opacity=\"0.3\">", ToStr(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.18;0.45;0.18")), ((V)(4.5)))), "</rect><path d=\"M9 4.6H", NumStr((W_533 - 20D)), "\" stroke=\"#ffffff\" stroke-opacity=\"0.35\" stroke-width=\"0.35\"/><path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((W_533 * 0.62))))), " 3.6L", ToStr(Call(f1_42, V.Undef, ((V)((W_533 * 0.55))))), " 12\" stroke=\"#ffffff\" stroke-opacity=\"0.12\" stroke-width=\"1.6\"/>"), string.Concat("<g transform=\"translate(", NumStr((W_533 - 11D)), " ", NumStr((Dd_535 - 8D)), ")\">", ToStr(Invoke(Invoke(Arr(((V)(0D)), ((V)(3.4)), ((V)(6.8))), "map", Fn((V _arrowThis554, int _argc547, V x_553, V _a550, V _a551, V _a552, V[] _rest548) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(x_553) - 3.4))))), "\" r=\"1\" fill=\"#dcdcd8\" stroke=\"#a9aaa6\" stroke-width=\"0.2\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<circle cx=\"-7\" r=\"0.35\" fill=\"#ffffff\">", ToStr(Call(an_39, V.Undef, ((V)("opacity")), ((V)("1;0.3;1")), ((V)(3D)))), "</circle></g><text x=\"10\" y=\"", NumStr((Dd_535 - 6.6)), "\" ", ToStr(FONT_46), " font-size=\"1.6\" fill=\"#b4b5b1\" letter-spacing=\"0.8\">LUMEN</text>"))));
side_539 = Invoke(Call(rep_44, V.Undef, ((V)(9D)), Fn((V _arrowThis562, int _argc555, V i_561, V _a558, V _a559, V _a560, V[] _rest556) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_42, V.Undef, ((V)((8D + (ToNum(i_561) * 2.2)))))), "\" y=\"4\" width=\"1\" height=\"5.4\" rx=\"0.5\" fill=\"#000000\" fill-opacity=\"0.22\"/>")));
}, 1, "", true)), "join", ((V)("")));
Set(D_536, "fx", Fn((V _arrowThis570, int _argc563, V ctx_569, V _a566, V _a567, V _a568, V[] _rest564) => {
V C_571 = default;
V s_572 = default;
C_571 = Call(cam_17, V.Undef, ctx_569);
s_572 = Call(shadow_21, V.Undef, C_571, ((V)(0D)), ((V)(0D)), ((V)(36D)), ((V)(22D)), ((V)(0.85)));
Invoke(Arr(Arr(((V)((-24D))), ((V)((-13D)))), Arr(((V)(24D)), ((V)((-13D)))), Arr(((V)((-24D))), ((V)(13D))), Arr(((V)(24D)), ((V)(13D)))), "forEach", Fn((V _arrowThis584, int _argc573, V _a575, V _a576, V _a577, V _a578, V[] _rest574) => {
V x_581 = default;
V z_583 = default;
{ V _t579 = ListOf(_a575);
{ V _t580 = GetIdx(_t579, 0D);
x_581 = _t580; }
{ V _t582 = GetIdx(_t579, 1D);
z_583 = _t582; }
}
return (s_572 = Add(s_572, Call(cyl3_19, V.Undef, C_571, Arr(x_581, ((V)(0D)), z_583), Arr(x_581, ((V)(1.2)), z_583), ((V)(1.8)), ((V)("#2a2b2e")), NewObj(2).Put("mat", ((V)("matte"))).Put("ol", ((V)(0D))).V)));
}, 1, "", true));
s_572 = Add(s_572, Call(box3_18, V.Undef, C_571, NewObj(11).Put("c", Arr(((V)(0D)), ((V)(1.2)), ((V)(0D)))).Put("w", ((V)(W_533))).Put("h", ((V)(Hh_534))).Put("d", ((V)(Dd_535))).Put("r", ((V)(6.5))).Put("col", ((V)("#e8e7e3"))).Put("gl", ((V)(0.25))).Put("mat", ((V)("noise"))).Put("dec", NewObj(3).Put("f", front_537).Put("t", top_538).Put("r", side_539).V).Put("olw", ((V)(0.4))).Put("olo", ((V)(0.5))).V));
s_572 = Add(s_572, Add(Call(shadow_21, V.Undef, C_571, ((V)(40D)), ((V)(14D)), ((V)(5D)), ((V)(9D)), ((V)(0.6))), Call(box3_18, V.Undef, C_571, NewObj(10).Put("c", Arr(((V)(40D)), ((V)(0D)), ((V)(14D)))).Put("ax", Call(yawA_29, V.Undef, ((V)(0.35)))).Put("w", ((V)(4.4))).Put("h", ((V)(1.3))).Put("d", ((V)(15D))).Put("r", ((V)(1.8))).Put("col", ((V)("#1c1d20"))).Put("gl", ((V)(0.5))).Put("dec", NewObj(1).Put("t", ((V)(JsStrBuf.Begin().S(string.Concat("<circle cx=\"2.2\" cy=\"2.6\" r=\"0.7\" fill=\"#c23a32\"/>", "")).V(Invoke(Call(rep_44, V.Undef, ((V)(3D)), Fn((V _arrowThis592, int _argc585, V i_591, V _a588, V _a589, V _a590, V[] _rest586) => {
return ((V)(string.Concat("<circle cx=\"1.3\" cy=\"", ToStr(Call(f1_42, V.Undef, ((V)((5.4 + (ToNum(i_591) * 1.8)))))), "\" r=\"0.45\" fill=\"#45474c\"/><circle cx=\"3.1\" cy=\"", ToStr(Call(f1_42, V.Undef, ((V)((5.4 + (ToNum(i_591) * 1.8)))))), "\" r=\"0.45\" fill=\"#45474c\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<circle cx=\"2.2\" cy=\"11.6\" r=\"1.1\" fill=\"none\" stroke=\"#55575c\" stroke-width=\"0.35\"/>", "")).End()))).V).Put("olw", ((V)(0.3))).V)));
return NewObj(3).Put("defs", DEF11_49).Put("front", s_572).Put("bb", Invoke(C_571, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_536;
return default;
}, 1, "", true));
Set(N_13, "spk11", Fn((V _arrowThis600, int _argc593, V S_599, V _a596, V _a597, V _a598, V[] _rest594) => {
V on_601 = default;
V WAL_602 = default;
V D_603 = default;
V fF_604 = default;
V fS_605 = default;
V fC_606 = default;
V fW_607 = default;
on_601 = Call(isPlay_38, V.Undef, S_599);
WAL_602 = ((V)("#7a4724"));
D_603 = NewObj(3).Put("w", ((V)(150D))).Put("d", ((V)(70D))).Put("build", Fn((V _arrowThis614, int _argc608, V _a610, V _a611, V _a612, V _a613, V[] _rest609) => {
return Arr();
}, 0, "build", true)).V;
fF_604 = ((V)(JsStrBuf.Begin().V(Add(Add(Call(baffle_59, V.Undef, ((V)(15D)), ((V)(24D))), Call(twt_58, V.Undef, ((V)(7.5)), ((V)(5D)), ((V)(2.4)))), Call(woof_57, V.Undef, ((V)(7.5)), ((V)(14.2)), ((V)(5.4)), on_601, ((V)(0D))))).S(string.Concat("<rect x=\"5\" y=\"20.8\" width=\"5\" height=\"1.4\" rx=\"0.7\" fill=\"#000000\"/><text x=\"7.5\" y=\"23.4\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"0.75\" fill=\"#9a9da2\" letter-spacing=\"0.3\">ARIA</text>")).End()));
fS_605 = Add(Add(Call(baffle_59, V.Undef, ((V)(10D)), ((V)(16D))), Call(twt_58, V.Undef, ((V)(5D)), ((V)(4D)), ((V)(1.8)))), Call(woof_57, V.Undef, ((V)(5D)), ((V)(10.6)), ((V)(3.7)), on_601, ((V)(0.3))));
fC_606 = ((V)(JsStrBuf.Begin().V(Add(Add(Add(Call(baffle_59, V.Undef, ((V)(36D)), ((V)(11D))), Call(woof_57, V.Undef, ((V)(8D)), ((V)(5.5)), ((V)(4.2)), on_601, ((V)(0.1)))), Call(twt_58, V.Undef, ((V)(18D)), ((V)(5.5)), ((V)(2.2)))), Call(woof_57, V.Undef, ((V)(28D)), ((V)(5.5)), ((V)(4.2)), on_601, ((V)(0.2))))).S(string.Concat("<text x=\"18\" y=\"10.2\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"0.75\" fill=\"#9a9da2\" letter-spacing=\"0.3\">ARIA</text>")).End()));
fW_607 = ((V)(JsStrBuf.Begin().V(Add(Call(baffle_59, V.Undef, ((V)(24D)), ((V)(26D)), ((V)("#1b1b1e"))), Call(woof_57, V.Undef, ((V)(12D)), ((V)(12D)), ((V)(9.6)), on_601, ((V)(0.05))))).S(string.Concat("<rect x=\"7\" y=\"23\" width=\"10\" height=\"1.6\" rx=\"0.8\" fill=\"#000000\"/><text x=\"12\" y=\"2.4\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"1\" fill=\"#7c7f84\" letter-spacing=\"0.6\">SUB 10</text><circle cx=\"21\" cy=\"24\" r=\"0.4\" fill=\"", (Truthy(on_601) ? "#3fa8ff" : "#2a4a6a"), "\"/>")).End()));
Set(D_603, "fx", Fn((V _arrowThis622, int _argc615, V ctx_621, V _a618, V _a619, V _a620, V[] _rest616) => {
V C_623 = default;
V L_624 = default;
V stand_625 = default;
V wbox_626 = default;
C_623 = Call(cam_17, V.Undef, ctx_621);
L_624 = Arr();
stand_625 = Fn((V _arrowThis636, int _argc627, V x_633, V z_634, V h_635, V _a632, V[] _rest628) => {
return Add(Add(Add(Call(shadow_21, V.Undef, C_623, x_633, z_634, ((V)(10D)), ((V)(10D)), ((V)(0.7))), Call(box3_18, V.Undef, C_623, NewObj(8).Put("c", Arr(x_633, ((V)(0D)), z_634)).Put("w", ((V)(14D))).Put("h", ((V)(1.4))).Put("d", ((V)(14D))).Put("r", ((V)(1D))).Put("col", ((V)("#1c1c1f"))).Put("gl", ((V)(0.3))).Put("olw", ((V)(0.3))).V)), Call(cyl3_19, V.Undef, C_623, Arr(x_633, ((V)(1.4)), z_634), Arr(x_633, ((V)((ToNum(h_635) - 1.2))), z_634), ((V)(1.6)), ((V)("#2c2d31")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.3))).V)), Call(box3_18, V.Undef, C_623, NewObj(7).Put("c", Arr(x_633, ((V)((ToNum(h_635) - 1.2))), z_634)).Put("w", ((V)(12D))).Put("h", ((V)(1.2))).Put("d", ((V)(14D))).Put("r", ((V)(0.8))).Put("col", ((V)("#1c1c1f"))).Put("olw", ((V)(0.3))).V));
}, 3, "", true);
wbox_626 = Fn((V _arrowThis650, int _argc637, V x_643, V y_644, V z_645, V w_646, V[] _rest638) => {
V h_647 = default;
V d_648 = default;
V f_649 = default;
h_647 = (_argc637 > 4 ? _rest638[0] : V.Undef);
d_648 = (_argc637 > 5 ? _rest638[1] : V.Undef);
f_649 = (_argc637 > 6 ? _rest638[2] : V.Undef);
return Call(box3_18, V.Undef, C_623, NewObj(11).Put("c", Arr(x_643, y_644, z_645)).Put("w", w_646).Put("h", h_647).Put("d", d_648).Put("r", ((V)(1D))).Put("col", WAL_602).Put("mat", ((V)("wood"))).Put("gl", ((V)(0.35))).Put("dec", NewObj(1).Put("f", f_649).V).Put("olc", ((V)("#2a1608"))).Put("olw", ((V)(0.4))).V);
}, 7, "", true);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis658, int _argc651, V sg_657, V _a654, V _a655, V _a656, V[] _rest652) => {
Invoke(L_624, "push", NewObj(2).Put("q", Arr(((V)((ToNum(sg_657) * 42D))), ((V)(30D)), ((V)((-2D))))).Put("s", Add(Call(stand_625, V.Undef, ((V)((ToNum(sg_657) * 42D))), ((V)((-2D))), ((V)(26D))), Call(wbox_626, V.Undef, ((V)((ToNum(sg_657) * 42D))), ((V)(26D)), ((V)((-2D))), ((V)(15D)), ((V)(24D)), ((V)(18D)), fF_604))).V);
Invoke(L_624, "push", NewObj(2).Put("q", Arr(((V)((ToNum(sg_657) * 64D))), ((V)(36D)), ((V)((-24D))))).Put("s", Add(Call(stand_625, V.Undef, ((V)((ToNum(sg_657) * 64D))), ((V)((-24D))), ((V)(36D))), Call(wbox_626, V.Undef, ((V)((ToNum(sg_657) * 64D))), ((V)(36D)), ((V)((-24D))), ((V)(10D)), ((V)(16D)), ((V)(10D)), fS_605))).V);
return default;
}, 1, "", true));
Invoke(L_624, "push", NewObj(2).Put("q", Arr(((V)(0D)), ((V)(6D)), ((V)(16D)))).Put("s", Add(Add(Call(shadow_21, V.Undef, C_623, ((V)(0D)), ((V)(16D)), ((V)(22D)), ((V)(9D)), ((V)(0.75))), Invoke(Invoke(Arr(((V)((-14D))), ((V)(14D))), "map", Fn((V _arrowThis666, int _argc659, V x_665, V _a662, V _a663, V _a664, V[] _rest660) => {
return Call(cyl3_19, V.Undef, C_623, Arr(x_665, ((V)(0D)), ((V)(16D))), Arr(x_665, ((V)(1.2)), ((V)(16D))), ((V)(1.2)), ((V)("#151517")), NewObj(2).Put("mat", ((V)("matte"))).Put("ol", ((V)(0D))).V);
}, 1, "", true)), "join", ((V)("")))), Call(wbox_626, V.Undef, ((V)(0D)), ((V)(1.2)), ((V)(16D)), ((V)(36D)), ((V)(11D)), ((V)(15D)), fC_606))).V);
Invoke(L_624, "push", NewObj(2).Put("q", Arr(((V)(0D)), ((V)(13D)), ((V)((-20D))))).Put("s", Add(Call(shadow_21, V.Undef, C_623, ((V)(0D)), ((V)((-20D))), ((V)(17D)), ((V)(15D)), ((V)(0.8))), Call(box3_18, V.Undef, C_623, NewObj(12).Put("c", Arr(((V)(0D)), ((V)(1.4)), ((V)((-20D))))).Put("w", ((V)(24D))).Put("h", ((V)(26D))).Put("d", ((V)(24D))).Put("r", ((V)(1.6))).Put("col", ((V)("#1d1d20"))).Put("mat", ((V)("noise"))).Put("gl", ((V)(0.2))).Put("dec", NewObj(1).Put("f", fW_607).V).Put("olc", ((V)("#060607"))).Put("olw", ((V)(0.45))).Put("edge", ((V)(0.2))).V))).V);
return NewObj(3).Put("defs", DEF11_49).Put("front", Call(zsort_51, V.Undef, C_623, L_624)).Put("bb", Invoke(C_623, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_603;
return default;
}, 1, "", true));
cart11_69 = Fn((V _arrowThis675, int _argc667, V S_673, V R_674, V _a671, V _a672, V[] _rest668) => {
V on_676 = default;
double W_677 = 0;
double Dd_678 = 0;
double Y0_679 = 0;
double BH_680 = 0;
double Y1_681 = 0;
double GH_682 = 0;
double Y2_683 = 0;
double RH_684 = 0;
double GW_685 = 0;
double GD_686 = 0;
V BODY_687 = default;
V GOLD_688 = default;
V POST_689 = default;
V MET_690 = default;
V KET_691 = default;
V D_692 = default;
V curl_693 = default;
V corners_694 = default;
V crown_695 = default;
V fK_696 = default;
V fR_697 = default;
V sideD_698 = default;
V bulbs_699 = default;
V awn_700 = default;
V roofD_701 = default;
V signF_702 = default;
V wheel_703 = default;
V kettle_704 = default;
on_676 = Call(isPlay_38, V.Undef, S_673);
W_677 = 62D;
Dd_678 = 36D;
Y0_679 = 14D;
BH_680 = 30D;
Y1_681 = (Y0_679 + BH_680);
GH_682 = 40D;
Y2_683 = (Y1_681 + GH_682);
RH_684 = 5D;
GW_685 = 58D;
GD_686 = 32D;
BODY_687 = ((V)((Truthy(R_674) ? "#6d1226" : "#c4222b")));
GOLD_688 = ((V)("#d4a640"));
POST_689 = (Truthy(R_674) ? GOLD_688 : ((V)("#c4222b")));
MET_690 = (Truthy(R_674) ? GOLD_688 : ((V)("#c9ced3")));
KET_691 = ((V)((Truthy(R_674) ? "#d79a3c" : "#c9ced3")));
D_692 = NewObj(3).Put("w", ((V)(96D))).Put("d", ((V)(50D))).Put("build", Fn((V _arrowThis711, int _argc705, V _a707, V _a708, V _a709, V _a710, V[] _rest706) => {
return Arr();
}, 0, "build", true)).V;
curl_693 = Fn((V _arrowThis723, int _argc712, V x_718, V y_719, V sx_720, V sy_721, V[] _rest713) => {
V c_722 = default;
c_722 = (_argc712 > 4 ? _rest713[0] : V.Undef);
return ((V)(string.Concat("<path transform=\"translate(", ToStr(x_718), " ", ToStr(y_719), ") scale(", ToStr(sx_720), " ", ToStr(sy_721), ")\" d=\"M0 0c3 -0.4 5 1.2 4.6 3.4c-0.3 1.6 -2.4 1.8 -2.6 0.5c-0.1 -0.8 0.9 -1.1 1.2 -0.5\" stroke=\"", ToStr(c_722), "\" stroke-width=\"0.5\" fill=\"none\" stroke-linecap=\"round\"/>")));
}, 5, "", true);
corners_694 = Fn((V _arrowThis733, int _argc724, V w_730, V h_731, V c_732, V _a729, V[] _rest725) => {
return Add(Add(Add(Call(curl_693, V.Undef, ((V)(3.4)), ((V)(3.4)), ((V)(1D)), ((V)(1D)), c_732), Call(curl_693, V.Undef, ((V)((ToNum(w_730) - 3.4))), ((V)(3.4)), ((V)((-1D))), ((V)(1D)), c_732)), Call(curl_693, V.Undef, ((V)(3.4)), ((V)((ToNum(h_731) - 3.4))), ((V)(1D)), ((V)((-1D))), c_732)), Call(curl_693, V.Undef, ((V)((ToNum(w_730) - 3.4))), ((V)((ToNum(h_731) - 3.4))), ((V)((-1D))), ((V)((-1D))), c_732));
}, 3, "", true);
crown_695 = Fn((V _arrowThis743, int _argc734, V cx_740, V cy_741, V s_742, V _a739, V[] _rest735) => {
return ((V)(string.Concat("<path transform=\"translate(", ToStr(cx_740), " ", ToStr(cy_741), ") scale(", ToStr(s_742), ")\" d=\"M-5 2L-6 -3L-3 0L0 -4L3 0L6 -3L5 2Z\" fill=\"", ToStr(GOLD_688), "\" stroke=\"#8a6420\" stroke-width=\"0.3\"/>")));
}, 3, "", true);
fK_696 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"2.4\" y=\"2.4\" width=\"57.2\" height=\"25.2\" rx=\"2\" fill=\"none\" stroke=\"#f6efe0\" stroke-width=\"0.7\"/><rect x=\"3.6\" y=\"3.6\" width=\"54.8\" height=\"22.8\" rx=\"1.4\" fill=\"none\" stroke=\"#f6efe0\" stroke-opacity=\"0.55\" stroke-width=\"0.3\"/>", "")).V(Call(corners_694, V.Undef, ((V)(W_677)), ((V)(BH_680)), ((V)("#f6efe0")))).S(string.Concat("<ellipse cx=\"31\" cy=\"15\" rx=\"19\" ry=\"8.6\" fill=\"#f7f0de\" stroke=\"#d9b45a\" stroke-width=\"0.8\"/><ellipse cx=\"31\" cy=\"15\" rx=\"17.4\" ry=\"7.1\" fill=\"none\" stroke=\"#c4222b\" stroke-width=\"0.35\"/><text x=\"31\" y=\"9.9\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"1.4\" letter-spacing=\"0.5\" fill=\"#8a6a3a\">\u2605 FRESH \u2605</text>")).S(string.Concat("<text x=\"31\" y=\"15\" text-anchor=\"middle\" font-family=\"Georgia,'Times New Roman',serif\" font-style=\"italic\" font-weight=\"700\" font-size=\"5\" fill=\"#b81d26\">Kettle</text><text x=\"31\" y=\"20.2\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"3.6\" letter-spacing=\"1.4\" fill=\"#2b1a10\">CORN</text>")).End()));
fR_697 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"2\" y=\"2\" width=\"58\" height=\"26\" rx=\"1\" fill=\"none\" stroke=\"#e8c463\" stroke-width=\"1\"/><rect x=\"3.6\" y=\"3.6\" width=\"54.8\" height=\"22.8\" fill=\"none\" stroke=\"#e8c463\" stroke-opacity=\"0.6\" stroke-width=\"0.35\"/>", "")).V(Call(corners_694, V.Undef, ((V)(W_677)), ((V)(BH_680)), ((V)("#e8c463")))).V(Call(crown_695, V.Undef, ((V)(31D)), ((V)(9.6)), ((V)(0.62)))).S(string.Concat("<text x=\"31\" y=\"17\" text-anchor=\"middle\" font-family=\"Georgia,'Times New Roman',serif\" font-weight=\"700\" font-size=\"4.6\" letter-spacing=\"0.8\" fill=\"#f2d27a\">ROYAL</text><text x=\"31\" y=\"22.2\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"2.6\" letter-spacing=\"1.6\" fill=\"#e8c463\">POPCORN</text>")).End()));
sideD_698 = Fn((V _arrowThis751, int _argc744, V w_750, V _a747, V _a748, V _a749, V[] _rest745) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"2.4\" y=\"2.4\" width=\"", NumStr((ToNum(w_750) - 4.8)), "\" height=\"25.2\" rx=\"", NumStr((Truthy(R_674) ? 1D : 2D)), "\" fill=\"none\" stroke=\"", (Truthy(R_674) ? "#e8c463" : "#f6efe0"), "\" stroke-width=\"", NumStr((Truthy(R_674) ? 0.9 : 0.7)), "\"/>")).V(Call(corners_694, V.Undef, w_750, ((V)(BH_680)), ((V)((Truthy(R_674) ? "#e8c463" : "#f6efe0"))))).V((Truthy(R_674) ? Call(crown_695, V.Undef, ((V)((ToNum(w_750) / 2D))), ((V)(15D)), ((V)(0.7))) : ((V)(string.Concat("<circle cx=\"", NumStr((ToNum(w_750) / 2D)), "\" cy=\"15\" r=\"5\" fill=\"#f7f0de\" stroke=\"#d9b45a\" stroke-width=\"0.6\"/><text x=\"", NumStr((ToNum(w_750) / 2D)), "\" y=\"16.4\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"3.4\" fill=\"#b81d26\">\u2605</text>"))))).End()));
}, 1, "", true);
bulbs_699 = Fn((V _arrowThis762, int _argc752, V w_758, V y_759, V n_760, V off_761, V[] _rest753) => {
return Invoke(Call(rep_44, V.Undef, n_760, Fn((V _arrowThis770, int _argc763, V i_769, V _a766, V _a767, V _a768, V[] _rest764) => {
V x_771 = default;
x_771 = Call(f1_42, V.Undef, ((V)((2D + (((ToNum(w_758) - 4D) * ToNum(i_769)) / (ToNum(n_760) - 1D))))));
return ((V)(string.Concat("<circle cx=\"", ToStr(x_771), "\" cy=\"", ToStr(y_759), "\" r=\"1.4\" fill=\"#ffcf5a\" opacity=\"0.35\"/><circle cx=\"", ToStr(x_771), "\" cy=\"", ToStr(y_759), "\" r=\"0.75\" fill=\"#fff6c8\">", ToStr((Truthy(on_676) ? Call(an_39, V.Undef, ((V)("fill-opacity")), ((V)("1;0.25;1")), ((V)(0.9)), ((V)(((-(ToNum(Add(i_769, (off_761 is var _t772 && Truthy(_t772) ? _t772 : ((V)(0D))))) % 6D)) * 0.15)))) : ((V)("")))), "</circle>")));
return default;
}, 1, "", true)), "join", ((V)("")));
}, 4, "", true);
awn_700 = Fn((V _arrowThis780, int _argc773, V w_779, V _a776, V _a777, V _a778, V[] _rest774) => {
double n_781 = 0;
double sw_782 = 0;
n_781 = Round((ToNum(w_779) / 4D));
sw_782 = (ToNum(w_779) / n_781);
return ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_44, V.Undef, ((V)(n_781)), Fn((V _arrowThis790, int _argc783, V i_789, V _a786, V _a787, V _a788, V[] _rest784) => {
return ((V)((NumTruthy((ToNum(i_789) % 2D)) ? string.Concat("<rect x=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(i_789) * sw_782))))), "\" width=\"", ToStr(Call(f1_42, V.Undef, ((V)(sw_782)))), "\" height=\"", NumStr(RH_684), "\" fill=\"#f6efe2\"/><path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(i_789) * sw_782))))), " ", NumStr(RH_684), "a", ToStr(Call(f1_42, V.Undef, ((V)((sw_782 / 2D))))), " ", ToStr(Call(f1_42, V.Undef, ((V)((sw_782 / 2D))))), " 0 0 0 ", ToStr(Call(f1_42, V.Undef, ((V)(sw_782)))), " 0Z\" fill=\"#f6efe2\"/>") : string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(i_789) * sw_782))))), " ", NumStr(RH_684), "a", ToStr(Call(f1_42, V.Undef, ((V)((sw_782 / 2D))))), " ", ToStr(Call(f1_42, V.Undef, ((V)((sw_782 / 2D))))), " 0 0 0 ", ToStr(Call(f1_42, V.Undef, ((V)(sw_782)))), " 0Z\" fill=\"#c4222b\"/>"))));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M0 0.3H", ToStr(w_779), "\" stroke=\"#ffffff\" stroke-opacity=\"0.5\" stroke-width=\"0.4\"/>")).End()));
return default;
}, 1, "", true);
roofD_701 = Fn((V _arrowThis798, int _argc791, V w_797, V _a794, V _a795, V _a796, V[] _rest792) => {
return (Truthy(R_674) ? ((V)(JsStrBuf.Begin().S(string.Concat("<rect width=\"", ToStr(w_797), "\" height=\"", NumStr(RH_684), "\" fill=\"url(#m10v)\"/>")).V(Call(bulbs_699, V.Undef, w_797, ((V)((RH_684 / 2D))), ((V)(Round((ToNum(w_797) / 5D)))))).End())) : Call(awn_700, V.Undef, w_797));
}, 1, "", true);
signF_702 = ((V)((Truthy(R_674) ? JsStrBuf.Begin().S(string.Concat("<rect x=\"0.8\" y=\"0.8\" width=\"42.4\" height=\"10.4\" rx=\"1\" fill=\"none\" stroke=\"#e8c463\" stroke-width=\"0.8\"/>", "")).V(Call(bulbs_699, V.Undef, ((V)(44D)), ((V)(0.9)), ((V)(12D)))).S(string.Concat("<text x=\"22\" y=\"8\" text-anchor=\"middle\" font-family=\"Georgia,'Times New Roman',serif\" font-weight=\"700\" font-size=\"4.4\" letter-spacing=\"0.6\" fill=\"#f2d27a\">Grand Cinema</text>", "")).End() : string.Concat("<rect x=\"0.8\" y=\"0.8\" width=\"42.4\" height=\"10.4\" rx=\"1.6\" fill=\"none\" stroke=\"#c4222b\" stroke-width=\"0.8\"/><text x=\"22\" y=\"7.4\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"4.6\" letter-spacing=\"0.8\" fill=\"#c4222b\">KETTLE CORN</text><text x=\"22\" y=\"10.1\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"1.4\" letter-spacing=\"0.8\" fill=\"#6a4a2a\">HOT \u00b7 SWEET \u00b7 SALTY</text>"))));
wheel_703 = Fn((V _arrowThis808, int _argc799, V C_805, V xw_806, V sg_807, V _a804, V[] _rest800) => {
double Rw_809 = 0;
double yc_810 = 0;
double zc_811 = 0;
V U_812 = default;
V V_813 = default;
V tyre_814 = default;
V rim_815 = default;
double ns_816 = 0;
V spk_817 = default;
V ring_818 = default;
Rw_809 = 17D;
yc_810 = 17D;
zc_811 = (-5D);
U_812 = Arr(((V)(0D)), ((V)(0D)), ((V)((-ToNum(sg_807)))));
V_813 = Arr(((V)(0D)), ((V)((-1D))), ((V)(0D)));
tyre_814 = ((V)((Truthy(R_674) ? "#2a1c10" : "#1d1b1a")));
rim_815 = (Truthy(R_674) ? GOLD_688 : ((V)("#c4222b")));
ns_816 = (Truthy(R_674) ? 16D : 12D);
spk_817 = Invoke(Call(rep_44, V.Undef, ((V)(ns_816)), Fn((V _arrowThis826, int _argc819, V i_825, V _a822, V _a823, V _a824, V[] _rest820) => {
double a_827 = 0;
a_827 = (((ToNum(i_825) / ns_816) * 2D) * PI_14);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((2.6 * FdLibm.Cos(a_827)))))), " ", ToStr(Call(f1_42, V.Undef, ((V)((2.6 * FdLibm.Sin(a_827)))))), "L", ToStr(Call(f1_42, V.Undef, ((V)(((Rw_809 - 2D) * FdLibm.Cos(a_827)))))), " ", ToStr(Call(f1_42, V.Undef, ((V)(((Rw_809 - 2D) * FdLibm.Sin(a_827)))))), "\" stroke=\"", ToStr(rim_815), "\" stroke-width=\"", NumStr((Truthy(R_674) ? 0.8 : 1.05)), "\" stroke-linecap=\"round\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")));
ring_818 = Fn((V _arrowThis836, int _argc828, V c1_834, V c2_835, V _a832, V _a833, V[] _rest829) => {
return ((V)(string.Concat("<circle r=\"", NumStr(Rw_809), "\" fill=\"none\" stroke=\"", ToStr(c1_834), "\" stroke-width=\"2.4\"/><circle r=\"", NumStr((Rw_809 - 1.7)), "\" fill=\"none\" stroke=\"", ToStr(c2_835), "\" stroke-width=\"1.3\"/>")));
}, 2, "", true);
return ((V)(string.Concat(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_805, Arr(((V)((ToNum(xw_806) - (ToNum(sg_807) * 1.3)))), ((V)(yc_810)), ((V)(zc_811))), U_812, V_813)), "\">", ToStr(Call(ring_818, V.Undef, Call(shade_12, V.Undef, tyre_814, ((V)(0.7))), Call(shade_12, V.Undef, rim_815, ((V)(0.55))))), "</g><g transform=\"", ToStr(Call(FR_23, V.Undef, C_805, Arr(Add(xw_806, ((V)((ToNum(sg_807) * 1.3)))), ((V)(yc_810)), ((V)(zc_811))), U_812, V_813)), "\">", ToStr(Call(ring_818, V.Undef, tyre_814, rim_815)), ToStr(spk_817), (Truthy(R_674) ? string.Concat("<circle r=\"", NumStr((Rw_809 * 0.55)), "\" fill=\"none\" stroke=\"", ToStr(GOLD_688), "\" stroke-width=\"0.6\"/>") : "")), string.Concat("<circle r=\"3\" fill=\"", ToStr((Truthy(R_674) ? GOLD_688 : ((V)("#d6b04a")))), "\" stroke=\"#7a5a1a\" stroke-width=\"0.3\"/><circle r=\"1.1\" fill=\"", (Truthy(R_674) ? "#6d1226" : "#8a6a2a"), "\"/><path d=\"M", NumStr(((-Rw_809) + 0.6)), " -2A", NumStr(Rw_809), " ", NumStr(Rw_809), " 0 0 1 -2 ", NumStr(((-Rw_809) + 0.6)), "\" stroke=\"#ffffff\" stroke-opacity=\"0.3\" stroke-width=\"0.6\" fill=\"none\"/></g>"))));
return default;
}, 3, "", true);
kettle_704 = Fn((V _arrowThis845, int _argc837, V C_843, V t_844, V _a841, V _a842, V[] _rest838) => {
V P0_846 = default;
V rot_847 = default;
V b_848 = default;
V a_849 = default;
P0_846 = Arr(((V)(0D)), ((V)((Y2_683 - 12D))), ((V)(0D)));
rot_847 = Fn((V _arrowThis857, int _argc850, V q_856, V _a853, V _a854, V _a855, V[] _rest851) => {
return Arr(GetIdx(q_856, 0D), ((V)((ToNum(Add(GetIdx(P0_846, 1D), ((V)((ToNum(GetIdx(q_856, 1D)) * FdLibm.Cos(ToNum(t_844))))))) - (ToNum(GetIdx(q_856, 2D)) * FdLibm.Sin(ToNum(t_844)))))), Add(Add(GetIdx(P0_846, 2D), ((V)((ToNum(GetIdx(q_856, 1D)) * FdLibm.Sin(ToNum(t_844)))))), ((V)((ToNum(GetIdx(q_856, 2D)) * FdLibm.Cos(ToNum(t_844)))))));
}, 1, "", true);
b_848 = Call(rot_847, V.Undef, Arr(((V)(0D)), ((V)((-14D))), ((V)(0D))));
a_849 = Call(rot_847, V.Undef, Arr(((V)(0D)), ((V)((-3D))), ((V)(0D))));
return Add(Add(Add(Invoke(Invoke(Arr(((V)((-11.4))), ((V)(11.4))), "map", Fn((V _arrowThis865, int _argc858, V x_864, V _a861, V _a862, V _a863, V[] _rest859) => {
return Call(cyl3_19, V.Undef, C_843, Arr(x_864, ((V)(Y2_683)), ((V)(0D))), Arr(x_864, ((V)((Y2_683 - 12D))), ((V)(0D))), ((V)(0.55)), MET_690, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.25))).V);
}, 1, "", true)), "join", ((V)(""))), Call(cyl3_19, V.Undef, C_843, Arr(((V)((-11.6))), ((V)((Y2_683 - 12D))), ((V)(0D))), Arr(((V)(11.6)), ((V)((Y2_683 - 12D))), ((V)(0D))), ((V)(0.7)), MET_690, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.25))).V)), Call(cyl3_19, V.Undef, C_843, b_848, a_849, ((V)(6.2)), KET_691, NewObj(4).Put("r2", ((V)(10.4))).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.4))).Put("cap", Fn((V _arrowThis873, int _argc866, V cr_872, V _a869, V _a870, V _a871, V[] _rest867) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(cr_872) * 0.92))))), "\" fill=\"#6a4a22\"/><circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(cr_872) * 0.92))))), "\" fill=\"url(#m10in)\"/>")).V(Invoke(Call(rep_44, V.Undef, ((V)(9D)), Fn((V _arrowThis881, int _argc874, V i_880, V _a877, V _a878, V _a879, V[] _rest875) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_42, V.Undef, ((V)((((FdLibm.Cos((ToNum(i_880) * 2.4)) * ToNum(cr_872)) * 0.55) * (((ToNum(i_880) % 3D) / 3D) + 0.3)))))), "\" cy=\"", ToStr(Call(f1_42, V.Undef, ((V)((((FdLibm.Sin((ToNum(i_880) * 2.4)) * ToNum(cr_872)) * 0.55) * (((ToNum(i_880) % 3D) / 3D) + 0.3)))))), "\" r=\"0.9\" fill=\"", (NumTruthy((ToNum(i_880) % 2D)) ? "#fff4d6" : "#e8b44a"), "\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
}, 1, "cap", true)).V)), Call(cyl3_19, V.Undef, C_843, Call(rot_847, V.Undef, Arr(((V)(0D)), ((V)((-2.6))), ((V)((-4D))))), Call(rot_847, V.Undef, Arr(((V)(0D)), ((V)((-1.4))), ((V)((-4D))))), ((V)(4.6)), KET_691, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.3))).V));
return default;
}, 2, "", true);
Set(D_692, "fx", Fn((V _arrowThis889, int _argc882, V ctx_888, V _a885, V _a886, V _a887, V[] _rest883) => {
V C_890 = default;
V s_891 = default;
V after_892 = default;
V wh_893 = default;
double hx_894 = 0;
double hy_895 = 0;
V handle_896 = default;
V G_897 = default;
V posts_898 = default;
V c0_899 = default;
V lp_900 = default;
C_890 = Call(cam_17, V.Undef, ctx_888);
s_891 = Call(shadow_21, V.Undef, C_890, ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)(28D)), ((V)(0.85)));
after_892 = Arr();
wh_893 = Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis908, int _argc901, V sg_907, V _a904, V _a905, V _a906, V[] _rest902) => {
return NewObj(2).Put("sg", sg_907).Put("s", Call(wheel_703, V.Undef, C_890, ((V)((ToNum(sg_907) * ((W_677 / 2D) + 2.6)))), sg_907)).V;
}, 1, "", true));
Invoke(wh_893, "forEach", Fn((V _arrowThis916, int _argc909, V w_915, V _a912, V _a913, V _a914, V[] _rest910) => {
if (Truthy(Call(vis_28, V.Undef, C_890, Arr(Get(w_915, "sg"), ((V)(0D)), ((V)(0D)))))) {
Invoke(after_892, "push", Get(w_915, "s"));
} else {
s_891 = Add(s_891, Get(w_915, "s"));
}
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis924, int _argc917, V sg_923, V _a920, V _a921, V _a922, V[] _rest918) => {
return (s_891 = Add(s_891, Add(Call(cyl3_19, V.Undef, C_890, Arr(((V)((ToNum(sg_923) * ((W_677 / 2D) - 5D)))), ((V)(0.8)), ((V)(((Dd_678 / 2D) - 4D)))), Arr(((V)((ToNum(sg_923) * ((W_677 / 2D) - 5D)))), ((V)(Y0_679)), ((V)(((Dd_678 / 2D) - 4D)))), ((V)(1.1)), MET_690, NewObj(2).Put("mat", ((V)((Truthy(R_674) ? "metal" : "chrome")))).Put("olw", ((V)(0.25))).V), Call(cyl3_19, V.Undef, C_890, Arr(((V)((ToNum(sg_923) * ((W_677 / 2D) - 5D)))), ((V)(0D)), ((V)(((Dd_678 / 2D) - 4D)))), Arr(((V)((ToNum(sg_923) * ((W_677 / 2D) - 5D)))), ((V)(1.2)), ((V)(((Dd_678 / 2D) - 4D)))), ((V)(2D)), ((V)("#2a2a2c")), NewObj(2).Put("mat", ((V)("matte"))).Put("olw", ((V)(0.25))).V))));
}, 1, "", true));
hx_894 = (((-W_677) / 2D) - 12D);
hy_895 = (Y1_681 - 2D);
handle_896 = Add(Invoke(Invoke(Arr(((V)((-10D))), ((V)(10D))), "map", Fn((V _arrowThis932, int _argc925, V z_931, V _a928, V _a929, V _a930, V[] _rest926) => {
return Call(cyl3_19, V.Undef, C_890, Arr(((V)((((-W_677) / 2D) + 0.5))), ((V)((Y1_681 - 7D))), z_931), Arr(((V)(hx_894)), ((V)(hy_895)), z_931), ((V)(0.9)), MET_690, NewObj(2).Put("mat", ((V)((Truthy(R_674) ? "metal" : "chrome")))).Put("olw", ((V)(0.25))).V);
}, 1, "", true)), "join", ((V)(""))), Call(cyl3_19, V.Undef, C_890, Arr(((V)(hx_894)), ((V)(hy_895)), ((V)((-11.6)))), Arr(((V)(hx_894)), ((V)(hy_895)), ((V)(11.6))), ((V)(1.2)), ((V)((Truthy(R_674) ? "#3a1a10" : "#1d1d1f"))), NewObj(2).Put("mat", ((V)("matte"))).Put("olw", ((V)(0.3))).V));
if (Truthy(Call(vis_28, V.Undef, C_890, Arr(((V)((-1D))), ((V)(0D)), ((V)(0D)))))) {
Invoke(after_892, "push", handle_896);
} else {
s_891 = Add(s_891, handle_896);
}
s_891 = Add(s_891, Call(box3_18, V.Undef, C_890, NewObj(9).Put("c", Arr(((V)(0D)), ((V)((Y0_679 - 2D))), ((V)(0D)))).Put("w", ((V)((W_677 + 2D)))).Put("h", ((V)(2.2))).Put("d", ((V)((Dd_678 + 2D)))).Put("r", ((V)(1.6))).Put("col", (Truthy(R_674) ? GOLD_688 : ((V)("#d9dde0")))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.8))).Put("olw", ((V)(0.3))).V));
s_891 = Add(s_891, Call(box3_18, V.Undef, C_890, NewObj(9).Put("c", Arr(((V)(0D)), ((V)(Y0_679)), ((V)(0D)))).Put("w", ((V)(W_677))).Put("h", ((V)(BH_680))).Put("d", ((V)(Dd_678))).Put("r", ((V)(1.6))).Put("col", BODY_687).Put("gl", ((V)((Truthy(R_674) ? 0.5 : 0.85)))).Put("dec", NewObj(4).Put("f", (Truthy(R_674) ? fR_697 : fK_696)).Put("b", (Truthy(R_674) ? fR_697 : fK_696)).Put("r", Call(sideD_698, V.Undef, ((V)(Dd_678)))).Put("l", Call(sideD_698, V.Undef, ((V)(Dd_678)))).V).Put("olw", ((V)(0.45))).V));
s_891 = Add(s_891, Call(box3_18, V.Undef, C_890, NewObj(9).Put("c", Arr(((V)(0D)), ((V)((Y1_681 - 0.4))), ((V)(0D)))).Put("w", ((V)((W_677 + 1.6)))).Put("h", ((V)(2D))).Put("d", ((V)((Dd_678 + 1.6)))).Put("r", ((V)(1.6))).Put("col", (Truthy(R_674) ? GOLD_688 : ((V)("#d9dde0")))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.8))).Put("olw", ((V)(0.3))).V));
s_891 = Add(s_891, Invoke(after_892, "join", ((V)(""))));
G_897 = Call(glassBox_56, V.Undef, C_890, Arr(((V)(0D)), ((V)((Y1_681 + 1.6))), ((V)(0D))), ((V)(GW_685)), ((V)((GH_682 - 1.6))), ((V)(GD_686)));
posts_898 = Invoke(Arr(((V)((-1D))), ((V)(1D))), "flatMap", Fn((V _arrowThis940, int _argc933, V sx_939, V _a936, V _a937, V _a938, V[] _rest934) => {
return Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis948, int _argc941, V sz_947, V _a944, V _a945, V _a946, V[] _rest942) => {
double x_949 = 0;
double z_950 = 0;
x_949 = ((ToNum(sx_939) * GW_685) / 2D);
z_950 = ((ToNum(sz_947) * GD_686) / 2D);
return NewObj(2).Put("q", Arr(((V)(x_949)), ((V)(Y1_681)), ((V)(z_950)))).Put("s", Add(Call(cyl3_19, V.Undef, C_890, Arr(((V)(x_949)), ((V)((Y1_681 + 1.6))), ((V)(z_950))), Arr(((V)(x_949)), ((V)(Y2_683)), ((V)(z_950))), ((V)((Truthy(R_674) ? 1.5 : 1.3))), POST_689, NewObj(2).Put("mat", ((V)((Truthy(R_674) ? "metal" : "gloss")))).Put("olw", ((V)(0.3))).V), (Truthy(R_674) ? Call(sph_20, V.Undef, C_890, Arr(((V)(x_949)), ((V)((Y1_681 + 2.4))), ((V)(z_950))), ((V)(1.9)), GOLD_688) : ((V)(""))))).V;
return default;
}, 1, "", true));
}, 1, "", true));
c0_899 = Call(dot_36, V.Undef, Arr(((V)(0D)), ((V)(Y1_681)), ((V)(0D))), Get(C_890, "v"));
s_891 = Add(s_891, Add(Get(G_897, "back"), Invoke(Invoke(Invoke(posts_898, "filter", Fn((V _arrowThis966, int _argc959, V p_965, V _a962, V _a963, V _a964, V[] _rest960) => {
return (Lt(Call(dot_36, V.Undef, Get(p_965, "q"), Get(C_890, "v")), c0_899) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis958, int _argc951, V p_957, V _a954, V _a955, V _a956, V[] _rest952) => {
return Get(p_957, "s");
}, 1, "", true)), "join", ((V)("")))));
s_891 = Add(s_891, Call(heap_61, V.Undef, C_890, ((V)(0D)), ((V)(0D)), ((V)(((GW_685 / 2D) - 3D))), ((V)(((GD_686 / 2D) - 3D))), ((V)((Y1_681 + 1.6))), ((V)(10D)), ((V)(120D)), ((V)((Truthy(R_674) ? "rcart" : "kcart"))), ((V)(1.05))));
s_891 = Add(s_891, Call(box3_18, V.Undef, C_890, NewObj(9).Put("c", Arr(((V)(0D)), ((V)((Y2_683 - 6.5))), ((V)(0D)))).Put("w", ((V)(10D))).Put("h", ((V)(6D))).Put("d", ((V)(8D))).Put("r", ((V)(1.2))).Put("col", MET_690).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.5))).Put("olw", ((V)(0.3))).V));
if (Truthy(on_676)) {
V R2_967 = default;
V m0_968 = default;
s_891 = Add(s_891, Call(loopF_52, V.Undef, Invoke(Call(rep_44, V.Undef, ((V)(12D)), Fn((V _arrowThis984, int _argc977, V j_983, V _a980, V _a981, V _a982, V[] _rest978) => {
return ((V)((0.23 * (1D - FdLibm.Cos((((2D * PI_14) * ToNum(j_983)) / 12D))))));
}, 1, "", true)), "map", Fn((V _arrowThis976, int _argc969, V t_975, V _a972, V _a973, V _a974, V[] _rest970) => {
return Call(kettle_704, V.Undef, C_890, t_975);
}, 1, "", true)), ((V)(2.4))));
R2_967 = Call(rng_37, V.Undef, ((V)(string.Concat("pop", (Truthy(R_674) ? "r" : "k")))));
m0_968 = Invoke(C_890, "p", ((V)(0D)), ((V)((Y2_683 - 16D))), ((V)(4D)));
s_891 = Add(s_891, Invoke(Call(rep_44, V.Undef, ((V)(8D)), Fn((V _arrowThis992, int _argc985, V i_991, V _a988, V _a989, V _a990, V[] _rest986) => {
V e_993 = default;
V c_994 = default;
double d_995 = 0;
double b_996 = 0;
e_993 = Invoke(C_890, "p", ((V)(((ToNum(Call(R2_967, V.Undef)) - 0.5) * 40D))), ((V)(((Y1_681 + 5D) + (ToNum(Call(R2_967, V.Undef)) * 3D)))), ((V)(((ToNum(Call(R2_967, V.Undef)) - 0.5) * 20D))));
c_994 = Arr(((V)(((ToNum(Add(GetIdx(m0_968, 0D), GetIdx(e_993, 0D))) / 2D) + ((ToNum(Call(R2_967, V.Undef)) - 0.5) * 10D)))), ((V)(((Min(ToNum(GetIdx(m0_968, 1D)), ToNum(GetIdx(e_993, 1D))) - 5D) - (ToNum(Call(R2_967, V.Undef)) * 6D)))));
d_995 = (0.9 + (ToNum(Call(R2_967, V.Undef)) * 0.5));
b_996 = ((-ToNum(i_991)) * 0.3);
return ((V)(string.Concat("<g opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;1;1;0\" keyTimes=\"0;0.08;0.85;1\" dur=\"", ToStr(Call(n4_43, V.Undef, ((V)(d_995)))), "s\" begin=\"", ToStr(Call(n4_43, V.Undef, ((V)(b_996)))), "s\" repeatCount=\"indefinite\"/><animateMotion dur=\"", ToStr(Call(n4_43, V.Undef, ((V)(d_995)))), "s\" begin=\"", ToStr(Call(n4_43, V.Undef, ((V)(b_996)))), "s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(P2_45, V.Undef, m0_968)), "Q", ToStr(Call(P2_45, V.Undef, c_994)), " ", ToStr(Call(P2_45, V.Undef, e_993)), "\"/><g transform=\"scale(", ToStr(Call(n4_43, V.Undef, ((V)((ToNum(Get(C_890, "k")) * 1.05))))), ")\"><g>", ToStr(Call(at_40, V.Undef, ((V)("rotate")), ((V)(string.Concat("0;", NumStr((GtN(Call(R2_967, V.Undef), 0.5) ? 360D : (-360D)))))), ((V)((d_995 * 0.9))))), ToStr(PUFF0_70), "</g></g></g>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
} else {
s_891 = Add(s_891, Call(kettle_704, V.Undef, C_890, ((V)(0D))));
}
lp_900 = Invoke(C_890, "p", ((V)(0D)), ((V)((Y2_683 - 1D))), ((V)(0D)));
s_891 = ((V)(JsStrBuf.Begin().V(s_891).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_42, V.Undef, GetIdx(lp_900, 0D))), "\" cy=\"", ToStr(Call(f1_42, V.Undef, Add(GetIdx(lp_900, 1D), ((V)((6D * ToNum(Get(C_890, "k")))))))), "\" rx=\"", ToStr(Call(f1_42, V.Undef, ((V)((26D * ToNum(Get(C_890, "k"))))))), "\" ry=\"", ToStr(Call(f1_42, V.Undef, ((V)((14D * ToNum(Get(C_890, "k"))))))), "\" fill=\"url(#m11warm)\" opacity=\"", NumStr((Truthy(on_676) ? 0.7 : 0.32)), "\">", ToStr((Truthy(on_676) ? Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.55;0.85;0.6;0.8;0.55")), ((V)(1.6))) : ((V)("")))), "</ellipse>")).End()));
s_891 = Add(s_891, Add(Get(G_897, "front"), Invoke(Invoke(Invoke(posts_898, "filter", Fn((V _arrowThis1012, int _argc1005, V p_1011, V _a1008, V _a1009, V _a1010, V[] _rest1006) => {
return (Ge(Call(dot_36, V.Undef, Get(p_1011, "q"), Get(C_890, "v")), c0_899) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis1004, int _argc997, V p_1003, V _a1000, V _a1001, V _a1002, V[] _rest998) => {
return Get(p_1003, "s");
}, 1, "", true)), "join", ((V)("")))));
s_891 = Add(s_891, Call(box3_18, V.Undef, C_890, NewObj(10).Put("c", Arr(((V)(0D)), ((V)(Y2_683)), ((V)(0D)))).Put("w", ((V)((GW_685 + 8D)))).Put("h", ((V)(RH_684))).Put("d", ((V)((GD_686 + 8D)))).Put("r", ((V)(1.2))).Put("col", (Truthy(R_674) ? GOLD_688 : ((V)("#c4222b")))).Put("mat", (Truthy(R_674) ? ((V)("brush")) : V.Undef)).Put("gl", ((V)(0.8))).Put("dec", NewObj(4).Put("f", Call(roofD_701, V.Undef, ((V)((GW_685 + 8D))))).Put("b", Call(roofD_701, V.Undef, ((V)((GW_685 + 8D))))).Put("r", Call(roofD_701, V.Undef, ((V)((GD_686 + 8D))))).Put("l", Call(roofD_701, V.Undef, ((V)((GD_686 + 8D))))).V).Put("olw", ((V)(0.35))).V));
s_891 = Add(s_891, Call(box3_18, V.Undef, C_890, NewObj(9).Put("c", Arr(((V)(0D)), ((V)((Y2_683 + RH_684))), ((V)(0D)))).Put("w", ((V)(44D))).Put("h", ((V)(12D))).Put("d", ((V)(1.6))).Put("r", ((V)(0.4))).Put("col", ((V)((Truthy(R_674) ? "#6d1226" : "#f6efe0")))).Put("gl", ((V)(0.5))).Put("dec", NewObj(2).Put("f", signF_702).Put("b", signF_702).V).Put("olw", ((V)(0.35))).V));
if (Truthy(R_674)) {
double y_1013 = 0;
y_1013 = ((Y2_683 + RH_684) + 11.4);
s_891 = Add(s_891, Add(Add(Add(Call(sph_20, V.Undef, C_890, Arr(((V)(0D)), ((V)((y_1013 + 3.4))), ((V)(0D))), ((V)(3.4)), ((V)("#9a1530"))), Call(cyl3_19, V.Undef, C_890, Arr(((V)(0D)), ((V)(y_1013)), ((V)(0D))), Arr(((V)(0D)), ((V)((y_1013 + 3D))), ((V)(0D))), ((V)(4.6)), GOLD_688, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.3))).V)), Call(zsort_51, V.Undef, C_890, Call(rep_44, V.Undef, ((V)(5D)), Fn((V _arrowThis1021, int _argc1014, V i_1020, V _a1017, V _a1018, V _a1019, V[] _rest1015) => {
V a_1022 = default;
V q_1023 = default;
a_1022 = Add(Get(C_890, "thV"), ((V)(((ToNum(i_1020) - 2D) * 0.62))));
q_1023 = Arr(((V)((4.3 * FdLibm.Sin(ToNum(a_1022))))), ((V)((y_1013 + 3D))), ((V)((4.3 * FdLibm.Cos(ToNum(a_1022))))));
return NewObj(2).Put("q", q_1023).Put("s", Add(Call(cyl3_19, V.Undef, C_890, q_1023, Call(add_33, V.Undef, q_1023, Arr(((V)(0D)), ((V)(3.6)), ((V)(0D)))), ((V)(0.9)), GOLD_688, NewObj(3).Put("r2", ((V)(0.15))).Put("mat", ((V)("metal"))).Put("ol", ((V)(0D))).V), Call(sph_20, V.Undef, C_890, Call(add_33, V.Undef, q_1023, Arr(((V)(0D)), ((V)(3.8)), ((V)(0D)))), ((V)(0.6)), ((V)("#fff1b0"))))).V;
return default;
}, 1, "", true)))), Call(sph_20, V.Undef, C_890, Arr(((V)(0D)), ((V)((y_1013 + 7.6))), ((V)(0D))), ((V)(1.1)), GOLD_688)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1031, int _argc1024, V sx_1030, V _a1027, V _a1028, V _a1029, V[] _rest1025) => {
return Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1039, int _argc1032, V sz_1038, V _a1035, V _a1036, V _a1037, V[] _rest1033) => {
return (s_891 = Add(s_891, Call(sph_20, V.Undef, C_890, Arr(((V)((ToNum(sx_1030) * ((GW_685 / 2D) + 3D)))), ((V)(((Y2_683 + RH_684) + 1.2))), ((V)((ToNum(sz_1038) * ((GD_686 / 2D) + 3D))))), ((V)(1.7)), GOLD_688)));
}, 1, "", true));
}, 1, "", true));
} else {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1047, int _argc1040, V sx_1046, V _a1043, V _a1044, V _a1045, V[] _rest1041) => {
return Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1055, int _argc1048, V sz_1054, V _a1051, V _a1052, V _a1053, V[] _rest1049) => {
return (s_891 = Add(s_891, Call(sph_20, V.Undef, C_890, Arr(((V)((ToNum(sx_1046) * ((GW_685 / 2D) + 3D)))), ((V)(((Y2_683 + RH_684) + 1.2))), ((V)((ToNum(sz_1054) * ((GD_686 / 2D) + 3D))))), ((V)(1.5)), ((V)("#e8c24a")))));
}, 1, "", true));
}, 1, "", true));
}
if (Truthy(on_676)) {
s_891 = Add(s_891, Call(mist_27, V.Undef, C_890, ((V)(0D)), ((V)(((Y2_683 + RH_684) + 4D))), ((V)(0D)), ((V)(4D)), ((V)(1.1))));
}
return NewObj(3).Put("defs", DEF11_49).Put("front", s_891).Put("bb", Invoke(C_890, "bb", ((V)(8D)))).V;
return default;
}, 1, "", true));
return D_692;
return default;
}, 2, "", true);
PUFF0_70 = Get(H_15, "PUFF");
Set(N_13, "kcart11", Fn((V _arrowThis1063, int _argc1056, V S_1062, V _a1059, V _a1060, V _a1061, V[] _rest1057) => {
return Call(cart11_69, V.Undef, S_1062, ((V)(0D)));
}, 1, "", true));
Set(N_13, "rcart11", Fn((V _arrowThis1071, int _argc1064, V S_1070, V _a1067, V _a1068, V _a1069, V[] _rest1065) => {
return Call(cart11_69, V.Undef, S_1070, ((V)(1D)));
}, 1, "", true));
Set(N_13, "cola11", Fn((V _arrowThis1079, int _argc1072, V S_1078, V _a1075, V _a1076, V _a1077, V[] _rest1073) => {
V open_1080 = default;
V RED_1081 = default;
double W_1082 = 0;
double Dd_1083 = 0;
double H_1084 = 0;
double FT_1085 = 0;
double DT_1086 = 0;
double Z0_1087 = 0;
double ZF_1088 = 0;
double ID_1089 = 0;
double WL_1090 = 0;
double WT_1091 = 0;
double WR_1092 = 0;
double WB_1093 = 0;
V D_1094 = default;
V doorF_1095 = default;
V liner_1096 = default;
V doorAt_1097 = default;
V bottle_1098 = default;
V shelf_1099 = default;
open_1080 = Call(isPlay_38, V.Undef, S_1078);
RED_1081 = ((V)("#c41e27"));
W_1082 = 40D;
Dd_1083 = 32D;
H_1084 = 56D;
FT_1085 = 5D;
DT_1086 = 3.4;
Z0_1087 = (-16D);
ZF_1088 = 13D;
ID_1089 = 2.8;
WL_1090 = 4D;
WT_1091 = 15D;
WR_1092 = 4D;
WB_1093 = 5.5;
D_1094 = NewObj(3).Put("w", ((V)(48D))).Put("d", ((V)(44D))).Put("build", Fn((V _arrowThis1106, int _argc1100, V _a1102, V _a1103, V _a1104, V _a1105, V[] _rest1101) => {
return Arr();
}, 0, "build", true)).V;
doorF_1095 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"", NumStr((WL_1090 - 1D)), "\" y=\"", NumStr((WT_1091 - 1D)), "\" width=\"", NumStr((((W_1082 - WL_1090) - WR_1092) + 2D)), "\" height=\"", NumStr((((H_1084 - WT_1091) - WB_1093) + 2D)), "\" rx=\"1\" fill=\"none\" stroke=\"#e6e9ec\" stroke-width=\"1.6\"/><rect x=\"", NumStr((WL_1090 - 1.8)), "\" y=\"", NumStr((WT_1091 - 1.8)), "\" width=\"", NumStr((((W_1082 - WL_1090) - WR_1092) + 3.6)), "\" height=\"", NumStr((((H_1084 - WT_1091) - WB_1093) + 3.6)), "\" rx=\"1.4\" fill=\"none\" stroke=\"#7d8288\" stroke-width=\"0.3\"/>")).S(string.Concat("<text x=\"", NumStr((W_1082 / 2D)), "\" y=\"7\" text-anchor=\"middle\" font-family=\"Georgia,'Times New Roman',serif\" font-style=\"italic\" font-weight=\"700\" font-size=\"4.6\" fill=\"#ffffff\">Ice Cold</text><rect x=\"", NumStr(((W_1082 / 2D) - 9D)), "\" y=\"8.4\" width=\"18\" height=\"4.2\" rx=\"2.1\" fill=\"#ffffff\"/><text x=\"", NumStr((W_1082 / 2D)), "\" y=\"11.65\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"3.2\" letter-spacing=\"1.2\" fill=\"", ToStr(RED_1081), "\">COLA</text>")).V(Invoke(Call(rep_44, V.Undef, ((V)(8D)), Fn((V _arrowThis1114, int _argc1107, V i_1113, V _a1110, V _a1111, V _a1112, V[] _rest1108) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_42, V.Undef, ((V)((9D + (ToNum(i_1113) * 2.9)))))), "\" y=\"", NumStr((H_1084 - 4D)), "\" width=\"1.7\" height=\"2.6\" rx=\"0.5\" fill=\"#2a0a0c\" opacity=\"0.65\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
liner_1096 = ((V)(string.Concat("<rect x=\"1.5\" y=\"1.5\" width=\"", NumStr((W_1082 - 3D)), "\" height=\"", NumStr((H_1084 - 3D)), "\" rx=\"2\" fill=\"#f1f2f0\"/><rect x=\"1.5\" y=\"1.5\" width=\"", NumStr((W_1082 - 3D)), "\" height=\"", NumStr((H_1084 - 3D)), "\" rx=\"2\" fill=\"none\" stroke=\"#a7aaa8\" stroke-width=\"1.1\"/>")));
doorAt_1097 = Fn((V _arrowThis1123, int _argc1115, V C_1121, V th_1122, V _a1119, V _a1120, V[] _rest1116) => {
double t_1124 = 0;
V ex_1125 = default;
V ez_1126 = default;
V hg_1127 = default;
V L_1128 = default;
double hu_1129 = 0;
V s_1130 = default;
V h1_1131 = default;
V h2_1132 = default;
V o1_1133 = default;
V o2_1134 = default;
t_1124 = ((ToNum(th_1122) * PI_14) / 180D);
ex_1125 = Arr(((V)(FdLibm.Cos(t_1124))), ((V)(0D)), ((V)(FdLibm.Sin(t_1124))));
ez_1126 = Arr(((V)((-FdLibm.Sin(t_1124)))), ((V)(0D)), ((V)(FdLibm.Cos(t_1124))));
hg_1127 = Arr(((V)(((-W_1082) / 2D))), ((V)(FT_1085)), ((V)(ZF_1088)));
L_1128 = Fn((V _arrowThis1144, int _argc1135, V u_1141, V y_1142, V sd_1143, V _a1140, V[] _rest1136) => {
return Call(add_33, V.Undef, Call(add_33, V.Undef, hg_1127, Call(mul_35, V.Undef, ex_1125, u_1141)), Call(add_33, V.Undef, Call(mul_35, V.Undef, ez_1126, sd_1143), Arr(((V)(0D)), y_1142, ((V)(0D)))));
}, 3, "", true);
hu_1129 = (W_1082 - 3.6);
s_1130 = Call(box3_18, V.Undef, C_1121, NewObj(11).Put("c", Call(add_33, V.Undef, hg_1127, Call(add_33, V.Undef, Call(mul_35, V.Undef, ex_1125, ((V)((W_1082 / 2D)))), Call(mul_35, V.Undef, ez_1126, ((V)((DT_1086 / 2D))))))).Put("ax", Arr(ex_1125, Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), ez_1126)).Put("w", ((V)(W_1082))).Put("h", ((V)(H_1084))).Put("d", ((V)(DT_1086))).Put("r", ((V)(2D))).Put("col", RED_1081).Put("gl", ((V)(0.85))).Put("dec", NewObj(2).Put("f", doorF_1095).Put("b", liner_1096).V).Put("hole", NewObj(2).Put("f", Arr(((V)(WL_1090)), ((V)(WT_1091)), ((V)(WR_1092)), ((V)(WB_1093)))).Put("b", Arr(((V)(WR_1092)), ((V)(WT_1091)), ((V)(WL_1090)), ((V)(WB_1093)))).V).Put("olw", ((V)(0.45))).V);
s_1130 = Add(s_1130, Call(pane_54, V.Undef, C_1121, Call(L_1128, V.Undef, ((V)(WL_1090)), ((V)((H_1084 - WT_1091))), ((V)((DT_1086 * 0.6)))), ex_1125, Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))), ((V)(((W_1082 - WL_1090) - WR_1092))), ((V)(((H_1084 - WT_1091) - WB_1093))), NewObj(2).Put("t", ((V)(0.12))).Put("tint", ((V)("#cfe9f2"))).V));
h1_1131 = Call(L_1128, V.Undef, ((V)(hu_1129)), ((V)(18D)), ((V)(DT_1086)));
h2_1132 = Call(L_1128, V.Undef, ((V)(hu_1129)), ((V)(40D)), ((V)(DT_1086)));
o1_1133 = Call(L_1128, V.Undef, ((V)(hu_1129)), ((V)(18D)), ((V)((DT_1086 + 2D))));
o2_1134 = Call(L_1128, V.Undef, ((V)(hu_1129)), ((V)(40D)), ((V)((DT_1086 + 2D))));
s_1130 = Add(s_1130, Add(Add(Call(cyl3_19, V.Undef, C_1121, h1_1131, o1_1133, ((V)(0.7)), ((V)("#cfd4d8")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V), Call(cyl3_19, V.Undef, C_1121, h2_1132, o2_1134, ((V)(0.7)), ((V)("#cfd4d8")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V)), Call(cyl3_19, V.Undef, C_1121, Call(add_33, V.Undef, o1_1133, Arr(((V)(0D)), ((V)((-1D))), ((V)(0D)))), Call(add_33, V.Undef, o2_1134, Arr(((V)(0D)), ((V)(1D)), ((V)(0D)))), ((V)(0.95)), ((V)("#d9dde0")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.25))).V)));
return s_1130;
return default;
}, 2, "", true);
bottle_1098 = Fn((V _arrowThis1155, int _argc1145, V C_1151, V x_1152, V y_1153, V z_1154, V[] _rest1146) => {
return ((V)(JsStrBuf.Begin().V(Add(Add(Add(Call(cyl3_19, V.Undef, C_1151, Arr(x_1152, y_1153, z_1154), Arr(x_1152, Add(y_1153, ((V)(6.6))), z_1154), ((V)(2D)), ((V)("#4b1d0e")), NewObj(4).Put("mat", ((V)("gloss"))).Put("op", ((V)(0.94))).Put("olw", ((V)(0.25))).Put("noCap", ((V)(1D))).V), Call(cyl3_19, V.Undef, C_1151, Arr(x_1152, Add(y_1153, ((V)(6.6))), z_1154), Arr(x_1152, Add(y_1153, ((V)(9.8))), z_1154), ((V)(2D)), ((V)("#5a2412")), NewObj(5).Put("r2", ((V)(0.85))).Put("mat", ((V)("gloss"))).Put("op", ((V)(0.94))).Put("olw", ((V)(0.25))).Put("noCap", ((V)(1D))).V)), Call(cyl3_19, V.Undef, C_1151, Arr(x_1152, Add(y_1153, ((V)(9.8))), z_1154), Arr(x_1152, Add(y_1153, ((V)(11.6))), z_1154), ((V)(0.85)), ((V)("#5a2412")), NewObj(4).Put("mat", ((V)("gloss"))).Put("op", ((V)(0.94))).Put("noCap", ((V)(1D))).Put("olw", ((V)(0.2))).V)), Call(cyl3_19, V.Undef, C_1151, Arr(x_1152, Add(y_1153, ((V)(11.6))), z_1154), Arr(x_1152, Add(y_1153, ((V)(12.4))), z_1154), ((V)(1.05)), ((V)("#d8322f")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.2))).V))).S(string.Concat("<g transform=\"", ToStr(Call(tanF_22, V.Undef, C_1151, x_1152, z_1154, ((V)(2.02)), Get(C_1151, "thV"), Add(y_1153, ((V)(4.2))))), "\"><path d=\"M-1.8 0q0.9 -0.8 1.8 0t1.8 0\" stroke=\"#ffffff\" stroke-width=\"0.55\" fill=\"none\"/></g>")).End()));
}, 4, "", true);
shelf_1099 = Fn((V _arrowThis1168, int _argc1156, V C_1162, V xi_1163, V y_1164, V zi_1165, V[] _rest1157) => {
V IW_1166 = default;
V IDp_1167 = default;
IW_1166 = (_argc1156 > 4 ? _rest1157[0] : V.Undef);
IDp_1167 = (_argc1156 > 5 ? _rest1157[1] : V.Undef);
return ((V)(JsStrBuf.Begin().S(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_1162, Arr(xi_1163, y_1164, zi_1165), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\">")).V(Invoke(Call(rep_44, V.Undef, ((V)(12D)), Fn((V _arrowThis1176, int _argc1169, V i_1175, V _a1172, V _a1173, V _a1174, V[] _rest1170) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((0.6 + ((ToNum(i_1175) * (ToNum(IW_1166) - 1.2)) / 11D)))))), " 0.4V", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(IDp_1167) - 0.6))))), "\" stroke=\"#80898e\" stroke-width=\"0.5\"/><path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((0.45 + ((ToNum(i_1175) * (ToNum(IW_1166) - 1.2)) / 11D)))))), " 0.4V", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(IDp_1167) - 0.6))))), "\" stroke=\"#eef2f4\" stroke-width=\"0.26\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M0 ", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(IDp_1167) - 0.8))))), "H", ToStr(Call(f1_42, V.Undef, IW_1166)), "\" stroke=\"#dfe5e8\" stroke-width=\"1\"/></g>")).End()));
}, 6, "", true);
Set(D_1094, "fx", Fn((V _arrowThis1184, int _argc1177, V ctx_1183, V _a1180, V _a1181, V _a1182, V[] _rest1178) => {
V C_1185 = default;
V s_1186 = default;
double xi_1187 = 0;
double yb_1188 = 0;
double yt_1189 = 0;
double zi_1190 = 0;
double IW_1191 = 0;
double IH_1192 = 0;
double IDp_1193 = 0;
V IN_1194 = default;
double L_1195 = 0;
C_1185 = Call(cam_17, V.Undef, ctx_1183);
s_1186 = Call(shadow_21, V.Undef, C_1185, ((V)(0D)), ((V)((-1D))), ((V)(26D)), ((V)(22D)), ((V)(0.85)));
Invoke(Arr(Arr(((V)((-15D))), ((V)((-12D)))), Arr(((V)(15D)), ((V)((-12D)))), Arr(((V)((-15D))), ((V)(10D))), Arr(((V)(15D)), ((V)(10D)))), "forEach", Fn((V _arrowThis1207, int _argc1196, V _a1198, V _a1199, V _a1200, V _a1201, V[] _rest1197) => {
V x_1204 = default;
V z_1206 = default;
{ V _t1202 = ListOf(_a1198);
{ V _t1203 = GetIdx(_t1202, 0D);
x_1204 = _t1203; }
{ V _t1205 = GetIdx(_t1202, 1D);
z_1206 = _t1205; }
}
return (s_1186 = Add(s_1186, Call(cyl3_19, V.Undef, C_1185, Arr(x_1204, ((V)(0D)), z_1206), Arr(x_1204, ((V)(FT_1085)), z_1206), ((V)(1.5)), ((V)("#d5dadd")), NewObj(3).Put("r2", ((V)(1D))).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.25))).V)));
}, 1, "", true));
s_1186 = Add(s_1186, Call(box3_18, V.Undef, C_1185, NewObj(9).Put("c", Arr(((V)(0D)), ((V)((FT_1085 - 1.2))), ((V)(((Z0_1087 + ZF_1088) / 2D))))).Put("w", ((V)((W_1082 - 2D)))).Put("h", ((V)(1.4))).Put("d", ((V)(((ZF_1088 - Z0_1087) - 2D)))).Put("r", ((V)(5D))).Put("col", ((V)("#d5dadd"))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.8))).Put("olw", ((V)(0.25))).V));
xi_1187 = (((-W_1082) / 2D) + ID_1089);
yb_1188 = (FT_1085 + ID_1089);
yt_1189 = ((FT_1085 + H_1084) - ID_1089);
zi_1190 = (Z0_1087 + ID_1089);
IW_1191 = (W_1082 - (2D * ID_1089));
IH_1192 = (yt_1189 - yb_1188);
IDp_1193 = (ZF_1088 - zi_1190);
IN_1194 = ((V)("#f4f6f7"));
L_1195 = (Truthy(open_1080) ? 1.06 : 0.96);
s_1186 = ((V)(JsStrBuf.Begin().V(s_1186).S(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_1185, Arr(((V)(xi_1187)), ((V)(yt_1189)), ((V)(zi_1190))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)(IW_1191)))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(IH_1192)))), "\" fill=\"", ToStr(Call(shade_12, V.Undef, IN_1194, ((V)((0.92 * L_1195))))), "\"/><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)(IW_1191)))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(IH_1192)))), "\" fill=\"url(#m10in)\" opacity=\"0.5\"/><rect x=\"3\" y=\"0.8\" width=\"", ToStr(Call(f1_42, V.Undef, ((V)((IW_1191 - 6D))))), "\" height=\"1.2\" rx=\"0.6\" fill=\"#fff8e0\"/><ellipse cx=\"", ToStr(Call(f1_42, V.Undef, ((V)((IW_1191 / 2D))))), "\" cy=\"3\" rx=\"", ToStr(Call(f1_42, V.Undef, ((V)((IW_1191 * 0.45))))), "\" ry=\"10\" fill=\"#fff6d8\" opacity=\"0.4\"/></g>")).S(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_1185, Arr(((V)(xi_1187)), ((V)(yt_1189)), ((V)(zi_1190))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)(IDp_1193)))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(IH_1192)))), "\" fill=\"", ToStr(Call(shade_12, V.Undef, IN_1194, ((V)((0.8 * L_1195))))), "\"/><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)(IDp_1193)))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(IH_1192)))), "\" fill=\"url(#m10in)\" opacity=\"0.5\"/></g>")).S(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_1185, Arr(((V)(xi_1187)), ((V)(yb_1188)), ((V)(zi_1190))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)(IW_1191)))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(IDp_1193)))), "\" fill=\"", ToStr(Call(shade_12, V.Undef, IN_1194, ((V)((0.86 * L_1195))))), "\"/></g>")).End()));
Invoke(Arr(((V)((-11D))), ((V)((-3.7))), ((V)(3.7)), ((V)(11D))), "forEach", Fn((V _arrowThis1216, int _argc1208, V x_1214, V i_1215, V _a1212, V _a1213, V[] _rest1209) => {
return (s_1186 = Add(s_1186, Call(can3_31, V.Undef, C_1185, x_1214, ((V)(yb_1188)), ((V)((-1D))), ((V)(3D)), ((V)(8D)), GetK(Arr(((V)(0D)), ((V)(1D)), ((V)(0D)), ((V)(1D))), i_1215))));
}, 2, "", true));
s_1186 = Add(s_1186, Call(shelf_1099, V.Undef, C_1185, ((V)(xi_1187)), ((V)((FT_1085 + 21D))), ((V)(zi_1190)), ((V)(IW_1191)), ((V)(IDp_1193))));
Invoke(Arr(((V)((-10.5))), ((V)((-3.5))), ((V)(3.5)), ((V)(10.5))), "forEach", Fn((V _arrowThis1224, int _argc1217, V x_1223, V _a1220, V _a1221, V _a1222, V[] _rest1218) => {
return (s_1186 = Add(s_1186, Call(bottle_1098, V.Undef, C_1185, x_1223, ((V)((FT_1085 + 21D))), ((V)((-1D))))));
}, 1, "", true));
s_1186 = Add(s_1186, Call(shelf_1099, V.Undef, C_1185, ((V)(xi_1187)), ((V)((FT_1085 + 34.5))), ((V)(zi_1190)), ((V)(IW_1191)), ((V)(IDp_1193))));
Invoke(Arr(((V)((-10.5))), ((V)((-3.5))), ((V)(3.5)), ((V)(10.5))), "forEach", Fn((V _arrowThis1232, int _argc1225, V x_1231, V _a1228, V _a1229, V _a1230, V[] _rest1226) => {
return (s_1186 = Add(s_1186, Call(bottle_1098, V.Undef, C_1185, x_1231, ((V)((FT_1085 + 34.5))), ((V)((-1D))))));
}, 1, "", true));
if (Truthy(open_1080)) {
s_1186 = ((V)(JsStrBuf.Begin().V(s_1186).S(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_1185, Arr(((V)(xi_1187)), ((V)(yt_1189)), ((V)(ZF_1088))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)(IW_1191)))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(IH_1192)))), "\" fill=\"url(#m10cold)\">", ToStr(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.8;1;0.8")), ((V)(3D)))), "</rect></g>")).V(Call(mist_27, V.Undef, C_1185, ((V)(0D)), ((V)((FT_1085 + 10D))), ((V)((ZF_1088 + 2D))), ((V)(3D)), ((V)(0.9)))).End()));
}
s_1186 = Add(s_1186, Call(box3_18, V.Undef, C_1185, NewObj(10).Put("c", Arr(((V)(0D)), ((V)(FT_1085)), ((V)(((Z0_1087 + ZF_1088) / 2D))))).Put("w", ((V)(W_1082))).Put("h", ((V)(H_1084))).Put("d", ((V)((ZF_1088 - Z0_1087)))).Put("r", ((V)(6D))).Put("col", RED_1081).Put("gl", ((V)(0.85))).Put("hole", NewObj(1).Put("f", Arr(((V)(ID_1089)), ((V)(ID_1089)), ((V)(ID_1089)), ((V)(ID_1089)))).V).Put("dec", NewObj(1).Put("r", ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_44, V.Undef, ((V)(6D)), Fn((V _arrowThis1240, int _argc1233, V i_1239, V _a1236, V _a1237, V _a1238, V[] _rest1234) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_42, V.Undef, ((V)((8D + (ToNum(i_1239) * 2.6)))))), "\" y=\"", NumStr((H_1084 - 9D)), "\" width=\"1.2\" height=\"6\" rx=\"0.6\" fill=\"#000000\" fill-opacity=\"0.28\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M3 ", NumStr((H_1084 - 1.2)), "H", NumStr(((ZF_1088 - Z0_1087) - 3D)), "\" stroke=\"#ffffff\" stroke-opacity=\"0.3\" stroke-width=\"0.4\"/>")).End()))).V).Put("olw", ((V)(0.45))).V));
if (!(Truthy(open_1080))) {
s_1186 = Add(s_1186, Call(doorAt_1097, V.Undef, C_1185, ((V)(0D))));
} else {
V A_1241 = default;
A_1241 = Call(easeA_26, V.Undef, ((V)(110D)), ((V)(10D)));
s_1186 = Add(s_1186, Call(flip_24, V.Undef, Invoke(A_1241, "map", Fn((V _arrowThis1250, int _argc1242, V a_1248, V i_1249, V _a1246, V _a1247, V[] _rest1243) => {
return NewObj(2).Put("i", i_1249).Put("s", Call(doorAt_1097, V.Undef, C_1185, a_1248)).V;
}, 2, "", true)), Get(A_1241, "length"), ((V)(0.7))));
}
return NewObj(3).Put("defs", DEF11_49).Put("front", s_1186).Put("bb", Invoke(C_1185, "bb", ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_1094;
return default;
}, 1, "", true));
Set(N_13, "rig11", Fn((V _arrowThis1258, int _argc1251, V S_1257, V _a1254, V _a1255, V _a1256, V[] _rest1252) => {
V D_1259 = default;
V GR_1260 = default;
V lens_1261 = default;
V unit_1262 = default;
V rackF_1263 = default;
V headF_1264 = default;
V headR_1265 = default;
V headT_1266 = default;
D_1259 = NewObj(3).Put("w", ((V)(84D))).Put("d", ((V)(74D))).Put("build", Fn((V _arrowThis1273, int _argc1267, V _a1269, V _a1270, V _a1271, V _a1272, V[] _rest1268) => {
return Arr();
}, 0, "build", true)).V;
GR_1260 = ((V)("#2d3036"));
lens_1261 = Fn((V _arrowThis1281, int _argc1274, V cr_1280, V _a1277, V _a1278, V _a1279, V[] _rest1275) => {
return ((V)(string.Concat(string.Concat("<defs><radialGradient id=\"rg11l\" cx=\"42%\" cy=\"38%\" r=\"62%\"><stop offset=\"0\" stop-color=\"#5a5fb0\"/><stop offset=\"0.45\" stop-color=\"#1b2046\"/><stop offset=\"1\" stop-color=\"#04050a\"/></radialGradient></defs><circle r=\"", ToStr(Call(f1_42, V.Undef, cr_1280)), "\" fill=\"#0f1013\"/><circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(cr_1280) * 0.8))))), "\" fill=\"url(#rg11l)\"/><circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(cr_1280) * 0.8))))), "\" fill=\"none\" stroke=\"#3a3d44\" stroke-width=\"0.35\"/>"), string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(cr_1280)) * 0.6))))), " ", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(cr_1280)) * 0.12))))), "A", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(cr_1280) * 0.62))))), " ", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(cr_1280) * 0.62))))), " 0 0 1 ", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(cr_1280) * 0.12))))), " ", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(cr_1280)) * 0.6))))), "\" stroke=\"#7affc8\" stroke-opacity=\"0.45\" stroke-width=\"0.4\" fill=\"none\"/><ellipse cx=\"", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(cr_1280)) * 0.28))))), "\" cy=\"", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(cr_1280)) * 0.3))))), "\" rx=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(cr_1280) * 0.22))))), "\" ry=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(cr_1280) * 0.12))))), "\" fill=\"#ffffff\" opacity=\"0.75\" transform=\"rotate(-35 ", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(cr_1280)) * 0.28))))), " ", ToStr(Call(f1_42, V.Undef, ((V)(((-ToNum(cr_1280)) * 0.3))))), ")\"/><circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(cr_1280) * 0.5))))), "\" fill=\"#cfe4ff\" opacity=\"0.12\">", ToStr(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.06;0.2;0.08;0.16;0.06")), ((V)(2.2)))), "</circle>"))));
}, 1, "", true);
unit_1262 = Fn((V _arrowThis1291, int _argc1282, V y_1288, V h_1289, V k_1290, V _a1287, V[] _rest1283) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"2\" y=\"", ToStr(y_1288), "\" width=\"50\" height=\"", ToStr(h_1289), "\" rx=\"0.5\" fill=\"#1a1c20\" stroke=\"#000000\" stroke-width=\"0.3\"/><rect x=\"2\" y=\"", ToStr(y_1288), "\" width=\"50\" height=\"0.5\" fill=\"#ffffff\" opacity=\"0.1\"/><circle cx=\"3.4\" cy=\"", ToStr(Call(f1_42, V.Undef, Add(y_1288, ((V)(1.2))))), "\" r=\"0.45\" fill=\"#8a8f96\"/><circle cx=\"50.6\" cy=\"", ToStr(Call(f1_42, V.Undef, Add(y_1288, ((V)(1.2))))), "\" r=\"0.45\" fill=\"#8a8f96\"/>")).V((SEqN(k_1290, 0D) ? ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"8\" y=\"", ToStr(Call(f1_42, V.Undef, Add(y_1288, ((V)(2D))))), "\" width=\"14\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(h_1289) - 4D))))), "\" rx=\"0.5\" fill=\"#0a1a2a\"/><text x=\"15\" y=\"", ToStr(Call(f1_42, V.Undef, Add(Add(y_1288, ((V)((ToNum(h_1289) / 2D)))), ((V)(0.8))))), "\" text-anchor=\"middle\" font-family=\"monospace\" font-size=\"2.2\" fill=\"#5fd0ff\">48fps 4K</text>")).V(Invoke(Call(rep_44, V.Undef, ((V)(6D)), Fn((V _arrowThis1299, int _argc1292, V i_1298, V _a1295, V _a1296, V _a1297, V[] _rest1293) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_42, V.Undef, ((V)((28D + (ToNum(i_1298) * 3D)))))), "\" cy=\"", ToStr(Call(f1_42, V.Undef, Add(y_1288, ((V)((ToNum(h_1289) / 2D)))))), "\" r=\"0.55\" fill=\"", ToStr(GetK(Arr(((V)("#3fff8a")), ((V)("#3fff8a")), ((V)("#ffb43f")), ((V)("#3fff8a")), ((V)("#3fd0ff")), ((V)("#ff4a4a"))), i_1298)), "\">", ToStr(Call(an_39, V.Undef, ((V)("opacity")), ((V)("1;0.3;1")), ((V)((1D + (ToNum(i_1298) * 0.37)))), ((V)(((-ToNum(i_1298)) * 0.2))))), "</circle>")));
}, 1, "", true)), "join", ((V)("")))).End())) : Invoke(Call(rep_44, V.Undef, ((V)(16D)), Fn((V _arrowThis1307, int _argc1300, V i_1306, V _a1303, V _a1304, V _a1305, V[] _rest1301) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_42, V.Undef, ((V)((6D + (ToNum(i_1306) * 2.7)))))), "\" y=\"", ToStr(Call(f1_42, V.Undef, Add(y_1288, ((V)(1.5))))), "\" width=\"1.4\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(h_1289) - 3D))))), "\" rx=\"0.5\" fill=\"#000000\" opacity=\"0.6\"/>")));
}, 1, "", true)), "join", ((V)(""))))).End()));
}, 3, "", true);
rackF_1263 = Add(Add(Add(Call(unit_1262, V.Undef, ((V)(1.5)), ((V)(8D)), ((V)(0D))), Call(unit_1262, V.Undef, ((V)(10.5)), ((V)(8D)), ((V)(1D)))), Call(unit_1262, V.Undef, ((V)(19.5)), ((V)(6D)), ((V)(0D)))), Call(unit_1262, V.Undef, ((V)(26.5)), ((V)(6D)), ((V)(1D))));
headF_1264 = ((V)(string.Concat(string.Concat("<circle cx=\"20\" cy=\"14\" r=\"10.2\" fill=\"#121316\"/><circle cx=\"50\" cy=\"14\" r=\"10.2\" fill=\"#121316\"/><circle cx=\"20\" cy=\"14\" r=\"10.2\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.2\" stroke-width=\"0.35\"/><circle cx=\"50\" cy=\"14\" r=\"10.2\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.2\" stroke-width=\"0.35\"/>", ""), string.Concat("<rect x=\"2\" y=\"22.6\" width=\"66\" height=\"3.6\" rx=\"0.6\" fill=\"url(#m10perf)\"/><text x=\"4\" y=\"4.4\" ", ToStr(FONT_46), " font-size=\"2.2\" letter-spacing=\"0.8\" fill=\"#d9dde2\">CINEMAX</text><rect x=\"58\" y=\"2\" width=\"9\" height=\"3.6\" rx=\"0.6\" fill=\"#c4262c\"/><text x=\"62.5\" y=\"4.8\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"2.6\" fill=\"#ffffff\">3D</text>"))));
headR_1265 = ((V)(JsStrBuf.Begin().S(string.Concat("<circle cx=\"20\" cy=\"14\" r=\"9.4\" fill=\"#0d0e10\"/><g transform=\"translate(20 14)\"><g>", ToStr(Call(at_40, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(0.5)))), ToStr(Invoke(Call(rep_44, V.Undef, ((V)(7D)), Fn((V _arrowThis1315, int _argc1308, V i_1314, V _a1311, V _a1312, V _a1313, V[] _rest1309) => {
return ((V)(string.Concat("<path d=\"M0 0Q3.6 -2.6 2.4 -8.2L-1 -8Q0.8 -3.8 0 0Z\" fill=\"#4a4e55\" transform=\"rotate(", NumStr((ToNum(i_1314) * 51.4)), ")\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g><circle r=\"2\" fill=\"#2a2d32\"/></g><circle cx=\"20\" cy=\"14\" r=\"9.4\" fill=\"url(#m10perf)\"/><circle cx=\"20\" cy=\"14\" r=\"9.4\" fill=\"none\" stroke=\"#5a5e65\" stroke-width=\"0.6\"/>")).S(string.Concat("<rect x=\"36\" y=\"5\" width=\"20\" height=\"9\" rx=\"0.8\" fill=\"#0a1626\" stroke=\"#4a4e55\" stroke-width=\"0.4\"/><text x=\"46\" y=\"9\" text-anchor=\"middle\" font-family=\"monospace\" font-size=\"2.2\" fill=\"#5fd0ff\">3D \u25b6 READY</text><text x=\"46\" y=\"12.2\" text-anchor=\"middle\" font-family=\"monospace\" font-size=\"1.8\" fill=\"#3fff8a\">LAMP 98%</text>", "")).V(Invoke(Call(rep_44, V.Undef, ((V)(8D)), Fn((V _arrowThis1323, int _argc1316, V i_1322, V _a1319, V _a1320, V _a1321, V[] _rest1317) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_42, V.Undef, ((V)((36D + (ToNum(i_1322) * 2.5)))))), "\" y=\"17\" width=\"1.3\" height=\"7\" rx=\"0.6\" fill=\"#000000\" opacity=\"0.55\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
headT_1266 = ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_44, V.Undef, ((V)(10D)), Fn((V _arrowThis1331, int _argc1324, V i_1330, V _a1327, V _a1328, V _a1329, V[] _rest1325) => {
return ((V)(string.Concat("<path d=\"M4 ", ToStr(Call(f1_42, V.Undef, ((V)((8D + (ToNum(i_1330) * 5D)))))), "H66\" stroke=\"#000000\" stroke-opacity=\"0.25\" stroke-width=\"0.5\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<rect x=\"44\" y=\"44\" width=\"16\" height=\"7\" rx=\"0.6\" fill=\"#f2c230\"/><text x=\"52\" y=\"48.6\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"1.6\" fill=\"#1a1a1a\">\u26a0 HOT \u00b7 UV</text>")).End()));
Set(D_1259, "fx", Fn((V _arrowThis1339, int _argc1332, V ctx_1338, V _a1335, V _a1336, V _a1337, V[] _rest1333) => {
V C_1340 = default;
V s_1341 = default;
V cb_1342 = default;
V cd_1343 = default;
C_1340 = Call(cam_17, V.Undef, ctx_1338);
s_1341 = Call(shadow_21, V.Undef, C_1340, ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)(38D)), ((V)(0.9)));
Invoke(Arr(Arr(((V)((-28D))), ((V)((-24D)))), Arr(((V)(28D)), ((V)((-24D)))), Arr(((V)((-28D))), ((V)(24D))), Arr(((V)(28D)), ((V)(24D)))), "forEach", Fn((V _arrowThis1355, int _argc1344, V _a1346, V _a1347, V _a1348, V _a1349, V[] _rest1345) => {
V x_1352 = default;
V z_1354 = default;
{ V _t1350 = ListOf(_a1346);
{ V _t1351 = GetIdx(_t1350, 0D);
x_1352 = _t1351; }
{ V _t1353 = GetIdx(_t1350, 1D);
z_1354 = _t1353; }
}
return (s_1341 = Add(s_1341, Add(Call(box3_18, V.Undef, C_1340, NewObj(7).Put("c", Arr(x_1352, ((V)(3.5)), z_1354)).Put("w", ((V)(3.6))).Put("h", ((V)(3.6))).Put("d", ((V)(3.6))).Put("r", ((V)(0.4))).Put("col", ((V)("#3a3d42"))).Put("olw", ((V)(0.25))).V), Call(cyl3_19, V.Undef, C_1340, Arr(((V)((ToNum(x_1352) - 1.4))), ((V)(3.2)), z_1354), Arr(Add(x_1352, ((V)(1.4))), ((V)(3.2)), z_1354), ((V)(3.2)), ((V)("#17171a")), NewObj(2).Put("mat", ((V)("matte"))).Put("olw", ((V)(0.3))).V))));
}, 1, "", true));
s_1341 = Add(s_1341, Call(box3_18, V.Undef, C_1340, NewObj(8).Put("c", Arr(((V)(0D)), ((V)(7D)), ((V)(0D)))).Put("w", ((V)(64D))).Put("h", ((V)(5D))).Put("d", ((V)(58D))).Put("r", ((V)(1D))).Put("col", ((V)("#26282c"))).Put("mat", ((V)("brush"))).Put("olw", ((V)(0.35))).V));
s_1341 = Add(s_1341, Call(box3_18, V.Undef, C_1340, NewObj(9).Put("c", Arr(((V)(0D)), ((V)(12D)), ((V)((-2D))))).Put("w", ((V)(54D))).Put("h", ((V)(35D))).Put("d", ((V)(48D))).Put("r", ((V)(1D))).Put("col", ((V)("#202226"))).Put("mat", ((V)("brush"))).Put("dec", NewObj(1).Put("f", rackF_1263).V).Put("olw", ((V)(0.35))).V));
s_1341 = Add(s_1341, Call(box3_18, V.Undef, C_1340, NewObj(12).Put("c", Arr(((V)(0D)), ((V)(47D)), ((V)(0D)))).Put("w", ((V)(70D))).Put("h", ((V)(28D))).Put("d", ((V)(62D))).Put("r", ((V)(3D))).Put("col", GR_1260).Put("gl", ((V)(0.4))).Put("mat", ((V)("noise"))).Put("dec", NewObj(4).Put("f", headF_1264).Put("r", headR_1265).Put("l", headR_1265).Put("t", headT_1266).V).Put("olc", ((V)("#0a0a0c"))).Put("olw", ((V)(0.45))).Put("edge", ((V)(0.3))).V));
Invoke(Arr(((V)((-15D))), ((V)(15D))), "forEach", Fn((V _arrowThis1363, int _argc1356, V x_1362, V _a1359, V _a1360, V _a1361, V[] _rest1357) => {
return (s_1341 = Add(s_1341, Add(Add(Call(cyl3_19, V.Undef, C_1340, Arr(x_1362, ((V)(61D)), ((V)(30.6))), Arr(x_1362, ((V)(61D)), ((V)(37D))), ((V)(8.2)), ((V)("#1c1d21")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.35))).V), Call(cyl3_19, V.Undef, C_1340, Arr(x_1362, ((V)(61D)), ((V)(37D))), Arr(x_1362, ((V)(61D)), ((V)(38.4))), ((V)(8.6)), ((V)("#3a3d43")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.3))).V)), Call(cyl3_19, V.Undef, C_1340, Arr(x_1362, ((V)(61D)), ((V)(38.4))), Arr(x_1362, ((V)(61D)), ((V)(41D))), ((V)(7.4)), ((V)("#141517")), NewObj(3).Put("mat", ((V)("gloss"))).Put("cap", lens_1261).Put("olw", ((V)(0.35))).V))));
}, 1, "", true));
s_1341 = Add(s_1341, Call(box3_18, V.Undef, C_1340, NewObj(9).Put("c", Arr(((V)(0D)), ((V)(55D)), ((V)(33D)))).Put("w", ((V)(9D))).Put("h", ((V)(12D))).Put("d", ((V)(5D))).Put("r", ((V)(1D))).Put("col", ((V)("#1b1c20"))).Put("gl", ((V)(0.5))).Put("dec", NewObj(1).Put("f", ((V)(string.Concat("<circle cx=\"4.5\" cy=\"3.6\" r=\"1.6\" fill=\"#ff3b4a\" opacity=\"0.85\"/><circle cx=\"4.5\" cy=\"8.2\" r=\"1.6\" fill=\"#3b7bff\" opacity=\"0.85\"/><circle cx=\"4\" cy=\"3.1\" r=\"0.5\" fill=\"#ffffff\" opacity=\"0.6\"/><circle cx=\"4\" cy=\"7.7\" r=\"0.5\" fill=\"#ffffff\" opacity=\"0.6\"/>", "")))).V).Put("olw", ((V)(0.3))).V));
Invoke(Arr(((V)((-18D))), ((V)(18D))), "forEach", Fn((V _arrowThis1371, int _argc1364, V z_1370, V _a1367, V _a1368, V _a1369, V[] _rest1365) => {
return (s_1341 = Add(s_1341, Add(Add(Call(cyl3_19, V.Undef, C_1340, Arr(((V)((-22D))), ((V)(75D)), z_1370), Arr(((V)((-22D))), ((V)(79D)), z_1370), ((V)(0.9)), ((V)("#3a3d43")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.25))).V), Call(cyl3_19, V.Undef, C_1340, Arr(((V)(22D)), ((V)(75D)), z_1370), Arr(((V)(22D)), ((V)(79D)), z_1370), ((V)(0.9)), ((V)("#3a3d43")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.25))).V)), Call(cyl3_19, V.Undef, C_1340, Arr(((V)((-22D))), ((V)(79D)), z_1370), Arr(((V)(22D)), ((V)(79D)), z_1370), ((V)(1D)), ((V)("#4a4d53")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.25))).V))));
}, 1, "", true));
s_1341 = Add(s_1341, Call(cyl3_19, V.Undef, C_1340, Arr(((V)(6D)), ((V)(75D)), ((V)((-18D)))), Arr(((V)(6D)), ((V)(94D)), ((V)((-18D)))), ((V)(7D)), ((V)("#bfc4ca")), NewObj(3).Put("mat", ((V)("metal"))).Put("pat", ((V)("m11rib"))).Put("olw", ((V)(0.35))).V));
cb_1342 = Invoke(Arr(Arr(((V)((-30D))), ((V)(52D)), ((V)((-28D)))), Arr(((V)((-36D))), ((V)(40D)), ((V)((-30D)))), Arr(((V)((-30D))), ((V)(26D)), ((V)((-28D)))), Arr(((V)((-27D))), ((V)(18D)), ((V)((-26D))))), "map", Fn((V _arrowThis1379, int _argc1372, V q_1378, V _a1375, V _a1376, V _a1377, V[] _rest1373) => {
return InvokeSpread(C_1340, "p", new ArrBuilder().Spread(q_1378).V);
}, 1, "", true));
cd_1343 = ((V)(string.Concat("M", ToStr(Call(P2_45, V.Undef, GetIdx(cb_1342, 0D))), "C", ToStr(Call(P2_45, V.Undef, GetIdx(cb_1342, 1D))), " ", ToStr(Call(P2_45, V.Undef, GetIdx(cb_1342, 2D))), " ", ToStr(Call(P2_45, V.Undef, GetIdx(cb_1342, 3D))))));
s_1341 = ((V)(JsStrBuf.Begin().V(s_1341).S(string.Concat("<path d=\"", ToStr(cd_1343), "\" stroke=\"#0e0f11\" stroke-width=\"2.2\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"", ToStr(cd_1343), "\" stroke=\"#4a4d52\" stroke-width=\"0.6\" fill=\"none\" transform=\"translate(-0.5 -0.3)\"/>")).End()));
return NewObj(3).Put("defs", DEF11_49).Put("front", s_1341).Put("bb", Invoke(C_1340, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1259;
return default;
}, 1, "", true));
Set(N_13, "tower11", Fn((V _arrowThis1387, int _argc1380, V S_1386, V _a1383, V _a1384, V _a1385, V[] _rest1381) => {
V on_1388 = default;
V D_1389 = default;
V tF_1390 = default;
V tS_1391 = default;
V subF_1392 = default;
V cF_1393 = default;
on_1388 = Call(isPlay_38, V.Undef, S_1386);
D_1389 = NewObj(3).Put("w", ((V)(124D))).Put("d", ((V)(44D))).Put("build", Fn((V _arrowThis1400, int _argc1394, V _a1396, V _a1397, V _a1398, V _a1399, V[] _rest1395) => {
return Arr();
}, 0, "build", true)).V;
tF_1390 = ((V)(JsStrBuf.Begin().V(Add(Add(Add(Call(baffle_59, V.Undef, ((V)(16D)), ((V)(104D)), ((V)("#0f1012"))), Call(twt_58, V.Undef, ((V)(8D)), ((V)(8.5)), ((V)(2.6)), ((V)(1D)))), Call(woof_57, V.Undef, ((V)(8D)), ((V)(19.5)), ((V)(4.4)), on_1388, ((V)(0.05)), ((V)(1D)))), Invoke(Invoke(Arr(((V)(33D)), ((V)(46.5)), ((V)(60D)), ((V)(73.5))), "map", Fn((V _arrowThis1409, int _argc1401, V y_1407, V i_1408, V _a1405, V _a1406, V[] _rest1402) => {
return Call(woof_57, V.Undef, ((V)(8D)), y_1407, ((V)(5.6)), on_1388, ((V)((ToNum(i_1408) * 0.06))), ((V)(1D)));
}, 2, "", true)), "join", ((V)(""))))).S(string.Concat("<rect x=\"5\" y=\"86\" width=\"6\" height=\"1.6\" rx=\"0.8\" fill=\"#000000\"/><rect x=\"5\" y=\"91\" width=\"6\" height=\"1.6\" rx=\"0.8\" fill=\"#000000\"/><rect x=\"4\" y=\"98\" width=\"8\" height=\"2.4\" rx=\"0.4\" fill=\"#b9bec4\"/><text x=\"8\" y=\"99.8\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"1.3\" fill=\"#2a2c30\" letter-spacing=\"0.4\">ARRAY</text>")).End()));
tS_1391 = ((V)(string.Concat("<rect x=\"0\" y=\"0\" width=\"1.4\" height=\"104\" fill=\"#c9ced3\"/><rect x=\"18.6\" y=\"0\" width=\"1.4\" height=\"104\" fill=\"#c9ced3\"/>", "")));
subF_1392 = ((V)(JsStrBuf.Begin().V(Call(baffle_59, V.Undef, ((V)(24D)), ((V)(24D)), ((V)("#141518")))).S((Truthy(on_1388) ? string.Concat("<circle cx=\"12\" cy=\"12\" r=\"10.4\" fill=\"none\" stroke=\"#3fd0ff\" stroke-width=\"0.4\">", ToStr(Call(an_39, V.Undef, ((V)("stroke-opacity")), ((V)("0.9;0.3;0.9")), ((V)(0.46)))), "</circle>") : "")).V(Call(woof_57, V.Undef, ((V)(12D)), ((V)(12D)), ((V)(9.4)), on_1388, ((V)(0D)), ((V)(1D)))).End()));
cF_1393 = Add(Add(Add(Add(Add(Call(baffle_59, V.Undef, ((V)(50D)), ((V)(9D)), ((V)("#0f1012"))), Call(woof_57, V.Undef, ((V)(7D)), ((V)(4.5)), ((V)(3.4)), on_1388, ((V)(0.1)), ((V)(1D)))), Call(woof_57, V.Undef, ((V)(15D)), ((V)(4.5)), ((V)(3.4)), on_1388, ((V)(0.12)), ((V)(1D)))), Call(twt_58, V.Undef, ((V)(25D)), ((V)(4.5)), ((V)(2.2)), ((V)(1D)))), Call(woof_57, V.Undef, ((V)(35D)), ((V)(4.5)), ((V)(3.4)), on_1388, ((V)(0.14)), ((V)(1D)))), Call(woof_57, V.Undef, ((V)(43D)), ((V)(4.5)), ((V)(3.4)), on_1388, ((V)(0.16)), ((V)(1D))));
Set(D_1389, "fx", Fn((V _arrowThis1417, int _argc1410, V ctx_1416, V _a1413, V _a1414, V _a1415, V[] _rest1411) => {
V C_1418 = default;
V L_1419 = default;
V glow_1420 = default;
C_1418 = Call(cam_17, V.Undef, ctx_1416);
L_1419 = Arr();
glow_1420 = Fn((V _arrowThis1431, int _argc1421, V x_1427, V z_1428, V rx_1429, V rz_1430, V[] _rest1422) => {
return Call(planeE_64, V.Undef, C_1418, x_1427, ((V)(0.06)), z_1428, rx_1429, rz_1430, ((V)("url(#m11cy)")), ((V)((Truthy(on_1388) ? 0.8 : 0.4))), (Truthy(on_1388) ? Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.5;0.95;0.5")), ((V)(0.46))) : ((V)(""))));
}, 4, "", true);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1439, int _argc1432, V sg_1438, V _a1435, V _a1436, V _a1437, V[] _rest1433) => {
double x_1440 = 0;
double a_1441 = 0;
V ax_1442 = default;
x_1440 = (ToNum(sg_1438) * 46D);
a_1441 = 0.34;
ax_1442 = Arr(Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(FdLibm.Cos(a_1441))), ((V)(FdLibm.Sin(a_1441)))), Arr(((V)(0D)), ((V)((-FdLibm.Sin(a_1441)))), ((V)(FdLibm.Cos(a_1441)))));
Invoke(L_1419, "push", NewObj(2).Put("q", Arr(((V)(x_1440)), ((V)(50D)), ((V)(0D)))).Put("s", Add(Add(Add(Add(Call(glow_1420, V.Undef, ((V)(x_1440)), ((V)(0D)), ((V)(18D)), ((V)(15D))), Call(shadow_21, V.Undef, C_1418, ((V)(x_1440)), ((V)(0D)), ((V)(13D)), ((V)(15D)), ((V)(0.8)))), Call(box3_18, V.Undef, C_1418, NewObj(9).Put("c", Arr(((V)(x_1440)), ((V)(0D)), ((V)(0D)))).Put("w", ((V)(20D))).Put("h", ((V)(3D))).Put("d", ((V)(24D))).Put("r", ((V)(1D))).Put("col", ((V)("#b9bec4"))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.8))).Put("olw", ((V)(0.3))).V)), Call(box3_18, V.Undef, C_1418, NewObj(11).Put("c", Arr(((V)(x_1440)), ((V)(3D)), ((V)(0D)))).Put("w", ((V)(16D))).Put("h", ((V)(104D))).Put("d", ((V)(20D))).Put("r", ((V)(2.4))).Put("col", ((V)("#121316"))).Put("gl", ((V)(0.95))).Put("dec", NewObj(3).Put("f", tF_1390).Put("r", tS_1391).Put("l", tS_1391).V).Put("olc", ((V)("#000000"))).Put("olw", ((V)(0.45))).Put("edge", ((V)(0.3))).V)), Call(box3_18, V.Undef, C_1418, NewObj(11).Put("c", Arr(((V)(x_1440)), ((V)(106.4)), ((V)((-1.5))))).Put("ax", ax_1442).Put("w", ((V)(15D))).Put("h", ((V)(6D))).Put("d", ((V)(16D))).Put("r", ((V)(2D))).Put("col", ((V)("#141518"))).Put("gl", ((V)(0.8))).Put("dec", NewObj(1).Put("t", ((V)(JsStrBuf.Begin().S(string.Concat("<rect width=\"15\" height=\"16\" rx=\"2\" fill=\"#0d0d0f\"/>", "")).V(Call(woof_57, V.Undef, ((V)(7.5)), ((V)(8D)), ((V)(5.2)), on_1388, ((V)(0.2)), ((V)(1D)))).End()))).V).Put("olc", ((V)("#000000"))).Put("olw", ((V)(0.4))).V))).V);
return default;
}, 1, "", true));
Invoke(Arr(((V)((-14D))), ((V)(14D))), "forEach", Fn((V _arrowThis1451, int _argc1443, V x_1449, V i_1450, V _a1447, V _a1448, V[] _rest1444) => {
return Invoke(L_1419, "push", NewObj(2).Put("q", Arr(x_1449, ((V)(12D)), ((V)((-8D))))).Put("s", Add(Add(Call(glow_1420, V.Undef, x_1449, ((V)((-8D))), ((V)(15D)), ((V)(15D))), Call(shadow_21, V.Undef, C_1418, x_1449, ((V)((-8D))), ((V)(14D)), ((V)(14D)), ((V)(0.8)))), Call(box3_18, V.Undef, C_1418, NewObj(11).Put("c", Arr(x_1449, ((V)(0D)), ((V)((-8D))))).Put("w", ((V)(24D))).Put("h", ((V)(24D))).Put("d", ((V)(24D))).Put("r", ((V)(1.6))).Put("col", ((V)("#141518"))).Put("mat", ((V)("noise"))).Put("gl", ((V)(0.5))).Put("dec", NewObj(1).Put("f", subF_1392).V).Put("olc", ((V)("#000000"))).Put("olw", ((V)(0.45))).V))).V);
}, 2, "", true));
Invoke(L_1419, "push", NewObj(2).Put("q", Arr(((V)(0D)), ((V)(28D)), ((V)((-6D))))).Put("s", Call(box3_18, V.Undef, C_1418, NewObj(10).Put("c", Arr(((V)(0D)), ((V)(24D)), ((V)((-6D))))).Put("w", ((V)(50D))).Put("h", ((V)(9D))).Put("d", ((V)(16D))).Put("r", ((V)(1.6))).Put("col", ((V)("#121316"))).Put("gl", ((V)(0.95))).Put("dec", NewObj(1).Put("f", cF_1393).V).Put("olc", ((V)("#000000"))).Put("olw", ((V)(0.45))).V)).V);
return NewObj(3).Put("defs", DEF11_49).Put("front", Call(zsort_51, V.Undef, C_1418, L_1419)).Put("bb", Invoke(C_1418, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1389;
return default;
}, 1, "", true));
Set(N_13, "conc11", Fn((V _arrowThis1459, int _argc1452, V S_1458, V _a1455, V _a1456, V _a1457, V[] _rest1453) => {
V on_1460 = default;
double W_1461 = 0;
double Dd_1462 = 0;
double Hc_1463 = 0;
double TY_1464 = 0;
V D_1465 = default;
double BH_1466 = 0;
V flute_1467 = default;
V warmF_1468 = default;
V pumpAt_1469 = default;
V glass_1470 = default;
on_1460 = Call(isPlay_38, V.Undef, S_1458);
W_1461 = 120D;
Dd_1462 = 40D;
Hc_1463 = 40D;
TY_1464 = (Hc_1463 + 3.6);
D_1465 = NewObj(3).Put("w", ((V)(134D))).Put("d", ((V)(54D))).Put("build", Fn((V _arrowThis1477, int _argc1471, V _a1473, V _a1474, V _a1475, V _a1476, V[] _rest1472) => {
return Arr();
}, 0, "build", true)).V;
BH_1466 = (Hc_1463 - 4D);
flute_1467 = ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_44, V.Undef, ((V)(29D)), Fn((V _arrowThis1485, int _argc1478, V i_1484, V _a1481, V _a1482, V _a1483, V[] _rest1479) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((4D + (ToNum(i_1484) * 4D)))))), " 7V", NumStr((BH_1466 - 3D)), "\" stroke=\"#000000\" stroke-opacity=\"0.35\" stroke-width=\"0.7\"/><path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((4.9 + (ToNum(i_1484) * 4D)))))), " 7V", NumStr((BH_1466 - 3D)), "\" stroke=\"#ffd9a8\" stroke-opacity=\"0.16\" stroke-width=\"0.5\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<rect x=\"0\" y=\"1.6\" width=\"", NumStr(W_1461), "\" height=\"3.4\" fill=\"#c99a44\"/><rect x=\"0\" y=\"1.6\" width=\"", NumStr(W_1461), "\" height=\"1\" fill=\"#fff0c0\" opacity=\"0.4\"/><text x=\"", NumStr((W_1461 / 2D)), "\" y=\"4.25\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"2.2\" letter-spacing=\"2.4\" fill=\"#3a2414\">CONCESSIONS</text>")).End()));
warmF_1468 = ((V)(string.Concat("<rect x=\"2\" y=\"0.8\" width=\"28\" height=\"3.8\" rx=\"0.8\" fill=\"#c4262c\"/><text x=\"16\" y=\"3.7\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"3\" fill=\"#ffd34a\" letter-spacing=\"1\">NACHOS</text>")));
pumpAt_1469 = Fn((V _arrowThis1494, int _argc1486, V C_1492, V p_1493, V _a1490, V _a1491, V[] _rest1487) => {
return Add(Call(cyl3_19, V.Undef, C_1492, Arr(((V)((-8D))), ((V)((TY_1464 + 17D))), ((V)((-8D)))), Arr(((V)((-8D))), ((V)(((TY_1464 + 21D) - ToNum(p_1493)))), ((V)((-8D)))), ((V)(0.9)), ((V)("#d5d9dd")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V), Call(box3_18, V.Undef, C_1492, NewObj(8).Put("c", Arr(((V)((-8D))), ((V)(((TY_1464 + 21D) - ToNum(p_1493)))), ((V)((-6D))))).Put("w", ((V)(3.4))).Put("h", ((V)(2D))).Put("d", ((V)(9D))).Put("r", ((V)(0.8))).Put("col", ((V)("#1d1e21"))).Put("gl", ((V)(0.5))).Put("olw", ((V)(0.25))).V));
}, 2, "", true);
glass_1470 = Fn((V _arrowThis1506, int _argc1495, V C_1501, V x_1502, V z_1503, V col_1504, V[] _rest1496) => {
V R_1507 = default;
V b_1508 = default;
V seed_1505 = default;
seed_1505 = (_argc1495 > 4 ? _rest1496[0] : V.Undef);
R_1507 = Call(rng_37, V.Undef, seed_1505);
b_1508 = Call(byDepth_60, V.Undef, C_1501, Call(rep_44, V.Undef, ((V)(36D)), Fn((V _arrowThis1515, int _argc1509, V _a1511, V _a1512, V _a1513, V _a1514, V[] _rest1510) => {
double a_1516 = 0;
double d_1517 = 0;
a_1516 = ((ToNum(Call(R_1507, V.Undef)) * 2D) * PI_14);
d_1517 = (System.Math.Sqrt(ToNum(Call(R_1507, V.Undef))) * 3.3);
return Arr(Add(x_1502, ((V)((d_1517 * FdLibm.Cos(a_1516))))), ((V)(((TY_1464 + 1D) + (ToNum(Call(R_1507, V.Undef)) * 7.5)))), Add(z_1503, ((V)((d_1517 * FdLibm.Sin(a_1516))))), Call(R_1507, V.Undef));
return default;
}, 0, "", true)));
return ((V)(JsStrBuf.Begin().V(Add(Add(Call(cyl3_19, V.Undef, C_1501, Arr(x_1502, ((V)(TY_1464)), z_1503), Arr(x_1502, ((V)((TY_1464 + 11D))), z_1503), ((V)(4.2)), ((V)("#e6f2f6")), NewObj(6).Put("op", ((V)(0.18))).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("olc", ((V)("#8aa5b0"))).Put("olw", ((V)(0.3))).Put("olo", ((V)(0.5))).V), Invoke(Invoke(b_1508, "map", Fn((V _arrowThis1525, int _argc1518, V q_1524, V _a1521, V _a1522, V _a1523, V[] _rest1519) => {
V c_1526 = default;
c_1526 = Invoke(C_1501, "P", q_1524);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_42, V.Undef, GetIdx(c_1526, 0D))), "\" cy=\"", ToStr(Call(f1_42, V.Undef, GetIdx(c_1526, 1D))), "\" r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_1501, "k")) * 0.95))))), "\" fill=\"", ToStr(GetIdx(col_1504, System.Math.Floor((ToNum(GetIdx(q_1524, 3D)) * ToNum(Get(col_1504, "length")))))), "\"/><circle cx=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(GetIdx(c_1526, 0D)) - (ToNum(Get(C_1501, "k")) * 0.3)))))), "\" cy=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(GetIdx(c_1526, 1D)) - (ToNum(Get(C_1501, "k")) * 0.3)))))), "\" r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_1501, "k")) * 0.3))))), "\" fill=\"#ffffff\" opacity=\"0.6\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))), Call(cyl3_19, V.Undef, C_1501, Arr(x_1502, ((V)(TY_1464)), z_1503), Arr(x_1502, ((V)((TY_1464 + 11D))), z_1503), ((V)(4.2)), ((V)("#e6f2f6")), NewObj(4).Put("op", ((V)(0.16))).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("ol", ((V)(0D))).V))).S(string.Concat("<g transform=\"", ToStr(Call(tanF_22, V.Undef, C_1501, x_1502, z_1503, ((V)(4.25)), ((V)((ToNum(Get(C_1501, "thV")) - 0.6))), ((V)((TY_1464 + 10D))))), "\"><rect x=\"-0.4\" width=\"0.8\" height=\"8.5\" rx=\"0.4\" fill=\"#ffffff\" opacity=\"0.5\"/></g>")).V(Call(cyl3_19, V.Undef, C_1501, Arr(x_1502, ((V)((TY_1464 + 11D))), z_1503), Arr(x_1502, ((V)((TY_1464 + 12.6))), z_1503), ((V)(4.4)), ((V)("#d5d9dd")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.25))).V)).V(Call(sph_20, V.Undef, C_1501, Arr(x_1502, ((V)((TY_1464 + 13.4))), z_1503), ((V)(1D)), ((V)("#d5d9dd")))).End()));
return default;
}, 5, "", true);
Set(D_1465, "fx", Fn((V _arrowThis1534, int _argc1527, V ctx_1533, V _a1530, V _a1531, V _a1532, V[] _rest1528) => {
V C_1535 = default;
V s_1536 = default;
V L_1537 = default;
C_1535 = Call(cam_17, V.Undef, ctx_1533);
s_1536 = Add(Call(shadow_21, V.Undef, C_1535, ((V)(0D)), ((V)(2D)), ((V)(70D)), ((V)(30D)), ((V)(0.85))), Call(planeE_64, V.Undef, C_1535, ((V)(0D)), ((V)(0.08)), ((V)(((Dd_1462 / 2D) + 6D))), ((V)(56D)), ((V)(7D)), ((V)("url(#m11warm)")), ((V)(0.5))));
s_1536 = Add(s_1536, Call(box3_18, V.Undef, C_1535, NewObj(9).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("w", ((V)((W_1461 - 2D)))).Put("h", ((V)(4D))).Put("d", ((V)((Dd_1462 - 2D)))).Put("r", ((V)(0.8))).Put("col", ((V)("#b88a3c"))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.9))).Put("olw", ((V)(0.3))).V));
s_1536 = Add(s_1536, Call(box3_18, V.Undef, C_1535, NewObj(11).Put("c", Arr(((V)(0D)), ((V)(4D)), ((V)(0D)))).Put("w", ((V)(W_1461))).Put("h", ((V)(BH_1466))).Put("d", ((V)(Dd_1462))).Put("r", ((V)(0.8))).Put("col", ((V)("#4a2c18"))).Put("mat", ((V)("wood"))).Put("gl", ((V)(0.35))).Put("dec", NewObj(3).Put("f", flute_1467).Put("r", Invoke(Call(rep_44, V.Undef, ((V)(9D)), Fn((V _arrowThis1545, int _argc1538, V i_1544, V _a1541, V _a1542, V _a1543, V[] _rest1539) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((4D + (ToNum(i_1544) * 4D)))))), " 7V", NumStr((BH_1466 - 3D)), "\" stroke=\"#000000\" stroke-opacity=\"0.35\" stroke-width=\"0.7\"/>")));
}, 1, "", true)), "join", ((V)("")))).Put("l", Invoke(Call(rep_44, V.Undef, ((V)(9D)), Fn((V _arrowThis1553, int _argc1546, V i_1552, V _a1549, V _a1550, V _a1551, V[] _rest1547) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((4D + (ToNum(i_1552) * 4D)))))), " 7V", NumStr((BH_1466 - 3D)), "\" stroke=\"#000000\" stroke-opacity=\"0.35\" stroke-width=\"0.7\"/>")));
}, 1, "", true)), "join", ((V)("")))).V).Put("olc", ((V)("#1a0d04"))).Put("olw", ((V)(0.45))).V));
s_1536 = Add(s_1536, Add(Invoke(Invoke(Arr(((V)((-50D))), ((V)(0D)), ((V)(50D))), "map", Fn((V _arrowThis1561, int _argc1554, V x_1560, V _a1557, V _a1558, V _a1559, V[] _rest1555) => {
return Call(cyl3_19, V.Undef, C_1535, Arr(x_1560, ((V)(8D)), ((V)((Dd_1462 / 2D)))), Arr(x_1560, ((V)(8D)), ((V)(((Dd_1462 / 2D) + 4D)))), ((V)(0.8)), ((V)("#c9993f")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.2))).V);
}, 1, "", true)), "join", ((V)(""))), Call(cyl3_19, V.Undef, C_1535, Arr(((V)((-57D))), ((V)(8D)), ((V)(((Dd_1462 / 2D) + 4D)))), Arr(((V)(57D)), ((V)(8D)), ((V)(((Dd_1462 / 2D) + 4D)))), ((V)(1.3)), ((V)("#d4a64a")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.3))).V)));
s_1536 = Add(s_1536, Call(box3_18, V.Undef, C_1535, NewObj(11).Put("c", Arr(((V)(0D)), ((V)(Hc_1463)), ((V)(1D)))).Put("w", ((V)((W_1461 + 6D)))).Put("h", ((V)(3.6))).Put("d", ((V)((Dd_1462 + 6D)))).Put("r", ((V)(1D))).Put("col", ((V)("#f2efe9"))).Put("mat", ((V)("marb"))).Put("gl", ((V)(0.5))).Put("edge", ((V)(0.6))).Put("olc", ((V)("#8f8a80"))).Put("olw", ((V)(0.4))).V));
L_1537 = Arr();
{
V G_1562 = default;
V lp_1563 = default;
G_1562 = Call(glassBox_56, V.Undef, C_1535, Arr(((V)((-36D))), ((V)((TY_1464 + 4D))), ((V)((-4D)))), ((V)(30D)), ((V)(17D)), ((V)(22D)));
lp_1563 = Invoke(C_1535, "p", ((V)((-36D))), ((V)((TY_1464 + 18D))), ((V)((-4D))));
Invoke(L_1537, "push", NewObj(2).Put("q", Arr(((V)((-36D))), ((V)((TY_1464 + 10D))), ((V)((-4D))))).Put("s", ((V)(JsStrBuf.Begin().V(Add(Add(Call(box3_18, V.Undef, C_1535, NewObj(9).Put("c", Arr(((V)((-36D))), ((V)(TY_1464)), ((V)((-4D))))).Put("w", ((V)(32D))).Put("h", ((V)(4D))).Put("d", ((V)(24D))).Put("r", ((V)(0.8))).Put("col", ((V)("#c9ced3"))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.6))).Put("olw", ((V)(0.3))).V), Get(G_1562, "back")), Call(chips_63, V.Undef, C_1535, ((V)((-36D))), ((V)((-4D))), ((V)(12D)), ((V)(8.5)), ((V)((TY_1464 + 4.2))), ((V)(7D)), ((V)(64D)), ((V)("nacho"))))).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_42, V.Undef, GetIdx(lp_1563, 0D))), "\" cy=\"", ToStr(Call(f1_42, V.Undef, Add(GetIdx(lp_1563, 1D), ((V)((5D * ToNum(Get(C_1535, "k")))))))), "\" rx=\"", ToStr(Call(f1_42, V.Undef, ((V)((16D * ToNum(Get(C_1535, "k"))))))), "\" ry=\"", ToStr(Call(f1_42, V.Undef, ((V)((9D * ToNum(Get(C_1535, "k"))))))), "\" fill=\"url(#m11warm)\" opacity=\"", NumStr((Truthy(on_1460) ? 0.85 : 0.45)), "\">", ToStr((Truthy(on_1460) ? Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.65;1;0.7;0.95;0.65")), ((V)(1.4))) : ((V)("")))), "</ellipse>")).V(Get(G_1562, "front")).V(Call(box3_18, V.Undef, C_1535, NewObj(10).Put("c", Arr(((V)((-36D))), ((V)((TY_1464 + 21D))), ((V)((-4D))))).Put("w", ((V)(32D))).Put("h", ((V)(5.4))).Put("d", ((V)(24D))).Put("r", ((V)(0.8))).Put("col", ((V)("#c9ced3"))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.6))).Put("dec", NewObj(1).Put("f", warmF_1468).V).Put("olw", ((V)(0.3))).V)).V((Truthy(on_1460) ? Call(mist_27, V.Undef, C_1535, ((V)((-36D))), ((V)((TY_1464 + 26D))), ((V)((-4D))), ((V)(3D)), ((V)(0.8))) : ((V)("")))).End()))).V);
}
{
V cw_1564 = default;
V n0_1565 = default;
V n1_1566 = default;
cw_1564 = ((V)(string.Concat("<rect x=\"2.5\" y=\"4\" width=\"7\" height=\"9\" rx=\"1\" fill=\"#2a2a2a\"/><rect x=\"3\" y=\"", NumStr((Truthy(on_1460) ? 7.8 : 6.6)), "\" width=\"6\" height=\"", NumStr((Truthy(on_1460) ? 4.8 : 6D)), "\" rx=\"0.8\" fill=\"#f2a21c\"/><rect x=\"3\" y=\"", NumStr((Truthy(on_1460) ? 7.8 : 6.6)), "\" width=\"2\" height=\"", NumStr((Truthy(on_1460) ? 4.8 : 6D)), "\" fill=\"#ffffff\" opacity=\"0.25\"/><text x=\"6\" y=\"2.8\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"1.5\" fill=\"#c4262c\">CHEESE</text>")));
Invoke(L_1537, "push", NewObj(2).Put("q", Arr(((V)((-8D))), ((V)((TY_1464 + 8D))), ((V)((-8D))))).Put("s", Add(Add(Add(Call(box3_18, V.Undef, C_1535, NewObj(10).Put("c", Arr(((V)((-8D))), ((V)(TY_1464)), ((V)((-8D))))).Put("w", ((V)(12D))).Put("h", ((V)(17D))).Put("d", ((V)(13D))).Put("r", ((V)(1D))).Put("col", ((V)("#d5d9dd"))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.5))).Put("dec", NewObj(1).Put("f", cw_1564).V).Put("olw", ((V)(0.3))).V), (Truthy(on_1460) ? Add(Call(cyl3_19, V.Undef, C_1535, Arr(((V)((-8D))), ((V)((TY_1464 + 17D))), ((V)((-8D)))), Arr(((V)((-8D))), ((V)((TY_1464 + 19.2))), ((V)((-8D)))), ((V)(0.9)), ((V)("#d5d9dd")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V), Call(slide_53, V.Undef, C_1535, Add(Call(cyl3_19, V.Undef, C_1535, Arr(((V)((-8D))), ((V)((TY_1464 + 19.2))), ((V)((-8D)))), Arr(((V)((-8D))), ((V)((TY_1464 + 21D))), ((V)((-8D)))), ((V)(0.9)), ((V)("#d5d9dd")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V), Call(box3_18, V.Undef, C_1535, NewObj(8).Put("c", Arr(((V)((-8D))), ((V)((TY_1464 + 21D))), ((V)((-6D))))).Put("w", ((V)(3.4))).Put("h", ((V)(2D))).Put("d", ((V)(9D))).Put("r", ((V)(0.8))).Put("col", ((V)("#1d1e21"))).Put("gl", ((V)(0.5))).Put("olw", ((V)(0.25))).V)), Arr(((V)((-8D))), ((V)((TY_1464 + 21D))), ((V)((-6D)))), Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1.8))), ((V)(0D))), Arr(((V)(0D)), ((V)((-1.8))), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))), ((V)("0;0.3;0.62;1")), ((V)(0.9)))) : Call(pumpAt_1469, V.Undef, C_1535, ((V)(0D))))), Call(cyl3_19, V.Undef, C_1535, Arr(((V)((-8D))), ((V)((TY_1464 + 14D))), ((V)((-1.6)))), Arr(((V)((-8D))), ((V)((TY_1464 + 14D))), ((V)(2.6))), ((V)(0.85)), ((V)("#d5d9dd")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V)), Call(cyl3_19, V.Undef, C_1535, Arr(((V)((-8D))), ((V)((TY_1464 + 14D))), ((V)(2.6))), Arr(((V)((-8D))), ((V)((TY_1464 + 12.4))), ((V)(2.6))), ((V)(0.7)), ((V)("#d5d9dd")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V))).V);
n0_1565 = Invoke(C_1535, "p", ((V)((-8D))), ((V)((TY_1464 + 12.4))), ((V)(2.6)));
n1_1566 = Invoke(C_1535, "p", ((V)((-8D))), ((V)((TY_1464 + 2.8))), ((V)(2.6)));
Invoke(L_1537, "push", NewObj(2).Put("q", Arr(((V)((-8D))), ((V)((TY_1464 + 2D))), ((V)(5D)))).Put("s", ((V)(JsStrBuf.Begin().V(Add(Add(Call(box3_18, V.Undef, C_1535, NewObj(9).Put("c", Arr(((V)((-8D))), ((V)(TY_1464)), ((V)(5D)))).Put("w", ((V)(13D))).Put("h", ((V)(2.4))).Put("d", ((V)(8D))).Put("r", ((V)(1D))).Put("col", ((V)("#151517"))).Put("gl", ((V)(0.4))).Put("hole", NewObj(1).Put("t", ((V)(0.6))).V).Put("olw", ((V)(0.3))).V), Call(chips_63, V.Undef, C_1535, ((V)((-8D))), ((V)(5D)), ((V)(5D)), ((V)(3D)), ((V)((TY_1464 + 2.2))), ((V)(1.6)), ((V)(22D)), ((V)("tray")))), Call(planeE_64, V.Undef, C_1535, ((V)((-8D))), ((V)((TY_1464 + 3.4))), ((V)(4.6)), ((V)((Truthy(on_1460) ? 3.6 : 2D))), ((V)((Truthy(on_1460) ? 2.4 : 1.3))), ((V)("#f5a41c")), ((V)(0.95)), (Truthy(on_1460) ? Add(Call(an_39, V.Undef, ((V)("rx")), ((V)("2;3.8;3.8")), ((V)(3D))), Call(an_39, V.Undef, ((V)("ry")), ((V)("1.3;2.5;2.5")), ((V)(3D)))) : ((V)("")))))).S((Truthy(on_1460) ? JsStrBuf.Begin().S(string.Concat("<path d=\"M", ToStr(Call(P2_45, V.Undef, n0_1565)), "L", ToStr(Call(P2_45, V.Undef, n1_1566)), "\" stroke=\"#f5a41c\" stroke-width=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_1535, "k")) * 0.9))))), "\" stroke-linecap=\"round\" stroke-dasharray=\"1.6 0.6\">", ToStr(Call(an_39, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-4.4")), ((V)(0.4)))), "</path>")).V(Call(mist_27, V.Undef, C_1535, ((V)((-8D))), ((V)((TY_1464 + 5D))), ((V)(5D)), ((V)(2D)), ((V)(0.5)))).End() : "")).End()))).V);
}
Invoke(Arr(Arr(((V)(11D)), ((V)((-13D)))), Arr(((V)(18D)), ((V)((-13D)))), Arr(((V)(14.5)), ((V)((-6D))))), "forEach", Fn((V _arrowThis1578, int _argc1567, V _a1569, V _a1570, V _a1571, V _a1572, V[] _rest1568) => {
V x_1575 = default;
V z_1577 = default;
{ V _t1573 = ListOf(_a1569);
{ V _t1574 = GetIdx(_t1573, 0D);
x_1575 = _t1574; }
{ V _t1576 = GetIdx(_t1573, 1D);
z_1577 = _t1576; }
}
return Invoke(L_1537, "push", NewObj(2).Put("q", Arr(x_1575, ((V)((TY_1464 + 6D))), z_1577)).Put("s", Call(cyl3_19, V.Undef, C_1535, Arr(x_1575, ((V)(TY_1464)), z_1577), Arr(x_1575, ((V)((TY_1464 + 12D))), z_1577), ((V)(3.3)), ((V)("#f4f2ec")), NewObj(4).Put("r2", ((V)(2.7))).Put("mat", ((V)("gloss"))).Put("pat", ((V)("m11str"))).Put("olw", ((V)(0.3))).V)).V);
}, 1, "", true));
Invoke(L_1537, "push", NewObj(2).Put("q", Arr(((V)(25D)), ((V)((TY_1464 + 5D))), ((V)((-5D))))).Put("s", Add(Invoke(Call(rep_44, V.Undef, ((V)(7D)), Fn((V _arrowThis1586, int _argc1579, V i_1585, V _a1582, V _a1583, V _a1584, V[] _rest1580) => {
double a_1587 = 0;
V p_1588 = default;
V q_1589 = default;
a_1587 = (ToNum(i_1585) * 0.9);
p_1588 = Invoke(C_1535, "p", ((V)((25D + (FdLibm.Cos(a_1587) * 1.2)))), ((V)((TY_1464 + 10D))), ((V)(((-5D) + (FdLibm.Sin(a_1587) * 1.2)))));
q_1589 = Invoke(C_1535, "p", ((V)((25D + (FdLibm.Cos(a_1587) * 2D)))), ((V)(((TY_1464 + 15D) + (ToNum(i_1585) % 3D)))), ((V)(((-5D) + (FdLibm.Sin(a_1587) * 2D)))));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(P2_45, V.Undef, p_1588)), "L", ToStr(Call(P2_45, V.Undef, q_1589)), "\" stroke=\"", ToStr(GetIdx(Arr(((V)("#d8283c")), ((V)("#ffffff")), ((V)("#2f6fe0")), ((V)("#f2c230"))), (ToNum(i_1585) % 4D))), "\" stroke-width=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_1535, "k")) * 0.5))))), "\" stroke-linecap=\"round\"/>")));
return default;
}, 1, "", true)), "join", ((V)(""))), Call(cyl3_19, V.Undef, C_1535, Arr(((V)(25D)), ((V)(TY_1464)), ((V)((-5D)))), Arr(((V)(25D)), ((V)((TY_1464 + 10D))), ((V)((-5D)))), ((V)(2.4)), ((V)("#e6f2f6")), NewObj(3).Put("op", ((V)(0.3))).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.3))).V))).V);
Invoke(Arr(Arr(((V)(36D)), ((V)((-11D))), Arr(((V)("#d8283c")), ((V)("#f2c230")), ((V)("#3fbf5a")))), Arr(((V)(47D)), ((V)((-11D))), Arr(((V)("#ff7ac8")), ((V)("#ffffff")), ((V)("#8fd8ff")))), Arr(((V)(41.5)), ((V)((-2D))), Arr(((V)("#5a2a12")), ((V)("#f5e6c8")), ((V)("#c98a2a"))))), "forEach", Fn((V _arrowThis1604, int _argc1590, V _a1592, V i_1596, V _a1594, V _a1595, V[] _rest1591) => {
V x_1599 = default;
V z_1601 = default;
V cl_1603 = default;
{ V _t1597 = ListOf(_a1592);
{ V _t1598 = GetIdx(_t1597, 0D);
x_1599 = _t1598; }
{ V _t1600 = GetIdx(_t1597, 1D);
z_1601 = _t1600; }
{ V _t1602 = GetIdx(_t1597, 2D);
cl_1603 = _t1602; }
}
return Invoke(L_1537, "push", NewObj(2).Put("q", Arr(x_1599, ((V)((TY_1464 + 6D))), z_1601)).Put("s", Add(Call(shadow_21, V.Undef, C_1535, x_1599, z_1601, ((V)(5D)), ((V)(5D)), ((V)(0.5)), ((V)((TY_1464 + 0.05)))), Call(glass_1470, V.Undef, C_1535, x_1599, z_1601, cl_1603, ((V)(JsStrBuf.Begin().S("jar").V(i_1596).End()))))).V);
}, 2, "", true));
s_1536 = Add(s_1536, Call(zsort_51, V.Undef, C_1535, L_1537));
return NewObj(3).Put("defs", DEF11_49).Put("front", s_1536).Put("bb", Invoke(C_1535, "bb", ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_1465;
return default;
}, 1, "", true));
Set(N_13, "wine11", Fn((V _arrowThis1612, int _argc1605, V S_1611, V _a1608, V _a1609, V _a1610, V[] _rest1606) => {
V open_1613 = default;
double W_1614 = 0;
double Hc_1615 = 0;
double Dd_1616 = 0;
double PL_1617 = 0;
double DT_1618 = 0;
double ZF_1619 = 0;
double ID_1620 = 0;
double DW_1621 = 0;
double DH_1622 = 0;
V SS_1623 = default;
V D_1624 = default;
V doorAt_1625 = default;
V wineB_1626 = default;
V wglass_1627 = default;
V auger_1628 = default;
V augerA_1629 = default;
open_1613 = Call(isPlay_38, V.Undef, S_1611);
W_1614 = 80D;
Hc_1615 = 42D;
Dd_1616 = 34D;
PL_1617 = 4D;
DT_1618 = 2.4;
ZF_1619 = (Dd_1616 / 2D);
ID_1620 = 2.2;
DW_1621 = 38.8;
DH_1622 = ((Hc_1615 - PL_1617) - 1D);
SS_1623 = ((V)("#c3c8cd"));
D_1624 = NewObj(3).Put("w", ((V)(92D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis1636, int _argc1630, V _a1632, V _a1633, V _a1634, V _a1635, V[] _rest1631) => {
return Arr();
}, 0, "build", true)).V;
doorAt_1625 = Fn((V _arrowThis1646, int _argc1637, V C_1643, V sg_1644, V th_1645, V _a1642, V[] _rest1638) => {
double t_1647 = 0;
V E_1648 = default;
V Z_1649 = default;
V hg_1650 = default;
V L_1651 = default;
V s_1652 = default;
V a1_1653 = default;
V a2_1654 = default;
V b1_1655 = default;
V b2_1656 = default;
t_1647 = ((ToNum(th_1645) * PI_14) / 180D);
E_1648 = Arr(((V)(((-ToNum(sg_1644)) * FdLibm.Cos(t_1647)))), ((V)(0D)), ((V)(FdLibm.Sin(t_1647))));
Z_1649 = Arr(((V)((ToNum(sg_1644) * FdLibm.Sin(t_1647)))), ((V)(0D)), ((V)(FdLibm.Cos(t_1647))));
hg_1650 = Arr(((V)(((ToNum(sg_1644) * W_1614) / 2D))), ((V)((PL_1617 + 0.5))), ((V)(ZF_1619)));
L_1651 = Fn((V _arrowThis1666, int _argc1657, V u_1663, V y_1664, V sd_1665, V _a1662, V[] _rest1658) => {
return Call(add_33, V.Undef, Call(add_33, V.Undef, hg_1650, Call(mul_35, V.Undef, E_1648, u_1663)), Call(add_33, V.Undef, Call(mul_35, V.Undef, Z_1649, sd_1665), Arr(((V)(0D)), y_1664, ((V)(0D)))));
}, 3, "", true);
s_1652 = Call(box3_18, V.Undef, C_1643, NewObj(11).Put("c", Call(add_33, V.Undef, hg_1650, Call(add_33, V.Undef, Call(mul_35, V.Undef, E_1648, ((V)((DW_1621 / 2D)))), Call(mul_35, V.Undef, Z_1649, ((V)((DT_1618 / 2D))))))).Put("ax", Arr(E_1648, Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), Z_1649)).Put("w", ((V)(DW_1621))).Put("h", ((V)(DH_1622))).Put("d", ((V)(DT_1618))).Put("r", ((V)(0.8))).Put("col", SS_1623).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.6))).Put("hole", NewObj(2).Put("f", Arr(((V)(3D)), ((V)(3D)), ((V)(3D)), ((V)(3D)))).Put("b", Arr(((V)(3D)), ((V)(3D)), ((V)(3D)), ((V)(3D)))).V).Put("olw", ((V)(0.35))).V);
s_1652 = Add(s_1652, Call(pane_54, V.Undef, C_1643, Call(L_1651, V.Undef, ((V)(3D)), ((V)((DH_1622 - 3D))), ((V)((DT_1618 * 0.5)))), E_1648, Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))), ((V)((DW_1621 - 6D))), ((V)((DH_1622 - 6D))), NewObj(3).Put("t", ((V)(0.26))).Put("tint", ((V)("#3c4a56"))).Put("g", ((V)(0.8))).V));
a1_1653 = Call(L_1651, V.Undef, ((V)((DW_1621 - 3.4))), ((V)(9D)), ((V)(DT_1618)));
a2_1654 = Call(L_1651, V.Undef, ((V)((DW_1621 - 3.4))), ((V)(29D)), ((V)(DT_1618)));
b1_1655 = Call(L_1651, V.Undef, ((V)((DW_1621 - 3.4))), ((V)(9D)), ((V)((DT_1618 + 2D))));
b2_1656 = Call(L_1651, V.Undef, ((V)((DW_1621 - 3.4))), ((V)(29D)), ((V)((DT_1618 + 2D))));
s_1652 = Add(s_1652, Add(Add(Call(cyl3_19, V.Undef, C_1643, a1_1653, b1_1655, ((V)(0.6)), ((V)("#d9dde0")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V), Call(cyl3_19, V.Undef, C_1643, a2_1654, b2_1656, ((V)(0.6)), ((V)("#d9dde0")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V)), Call(cyl3_19, V.Undef, C_1643, b1_1655, b2_1656, ((V)(0.85)), ((V)("#e2e5e8")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.25))).V)));
return s_1652;
return default;
}, 3, "", true);
wineB_1626 = Fn((V _arrowThis1678, int _argc1667, V C_1673, V x_1674, V y_1675, V z0_1676, V[] _rest1668) => {
V cap_1677 = default;
cap_1677 = (_argc1667 > 4 ? _rest1668[0] : V.Undef);
return Add(Add(Call(cyl3_19, V.Undef, C_1673, Arr(x_1674, y_1675, z0_1676), Arr(x_1674, y_1675, Add(z0_1676, ((V)(16D)))), ((V)(2.9)), ((V)("#1f3a26")), NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.25))).V), Call(cyl3_19, V.Undef, C_1673, Arr(x_1674, y_1675, Add(z0_1676, ((V)(16D)))), Arr(x_1674, y_1675, Add(z0_1676, ((V)(19D)))), ((V)(2.9)), ((V)("#1f3a26")), NewObj(4).Put("r2", ((V)(1.05))).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("olw", ((V)(0.25))).V)), Call(cyl3_19, V.Undef, C_1673, Arr(x_1674, y_1675, Add(z0_1676, ((V)(19D)))), Arr(x_1674, y_1675, Add(z0_1676, ((V)(21.6)))), ((V)(1.15)), cap_1677, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.2))).V));
}, 5, "", true);
wglass_1627 = Fn((V _arrowThis1690, int _argc1679, V C_1685, V x_1686, V y_1687, V z_1688, V[] _rest1680) => {
V fill_1689 = default;
fill_1689 = (_argc1679 > 4 ? _rest1680[0] : V.Undef);
return Add(Add(Add(Call(cyl3_19, V.Undef, C_1685, Arr(x_1686, y_1687, z_1688), Arr(x_1686, Add(y_1687, ((V)(0.4))), z_1688), ((V)(2.2)), ((V)("#e6f2f6")), NewObj(3).Put("op", ((V)(0.5))).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.2))).V), Call(cyl3_19, V.Undef, C_1685, Arr(x_1686, Add(y_1687, ((V)(0.4))), z_1688), Arr(x_1686, Add(y_1687, ((V)(5.2))), z_1688), ((V)(0.32)), ((V)("#e6f2f6")), NewObj(3).Put("op", ((V)(0.6))).Put("mat", ((V)("gloss"))).Put("ol", ((V)(0D))).V)), (Truthy(fill_1689) ? Call(cyl3_19, V.Undef, C_1685, Arr(x_1686, Add(y_1687, ((V)(5.4))), z_1688), Arr(x_1686, Add(y_1687, ((V)(7.4))), z_1688), ((V)(1.5)), ((V)("#6a0f1e")), NewObj(4).Put("r2", ((V)(2.05))).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.15))).Put("capCol", ((V)("#8a1626"))).V) : ((V)("")))), Call(cyl3_19, V.Undef, C_1685, Arr(x_1686, Add(y_1687, ((V)(5.2))), z_1688), Arr(x_1686, Add(y_1687, ((V)(10.6))), z_1688), ((V)(1.5)), ((V)("#e6f2f6")), NewObj(7).Put("r2", ((V)(2.7))).Put("op", ((V)(0.25))).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("olc", ((V)("#9ab5c0"))).Put("olw", ((V)(0.25))).Put("olo", ((V)(0.6))).V));
}, 5, "", true);
auger_1628 = Fn((V _arrowThis1700, int _argc1691, V C_1697, V x_1698, V ph_1699, V _a1696, V[] _rest1692) => {
V P_1701 = default;
P_1701 = Call(rep_44, V.Undef, ((V)(40D)), Fn((V _arrowThis1709, int _argc1702, V i_1708, V _a1705, V _a1706, V _a1707, V[] _rest1703) => {
double z_1710 = 0;
V a_1711 = default;
z_1710 = ((-12D) + (ToNum(i_1708) * 0.36));
a_1711 = Add(((V)((z_1710 * 1.1))), ph_1699);
return Invoke(C_1697, "p", Add(x_1698, ((V)((3.2 * FdLibm.Cos(ToNum(a_1711)))))), ((V)(((Hc_1615 + 18D) + (3.2 * FdLibm.Sin(ToNum(a_1711)))))), ((V)(z_1710)));
return default;
}, 1, "", true));
return ((V)(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(P_1701, "map", P2_45), "join", ((V)("L")))), "\" stroke=\"#ffffff\" stroke-opacity=\"0.6\" stroke-width=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_1697, "k")) * 0.55))))), "\" fill=\"none\" stroke-linecap=\"round\"/>")));
return default;
}, 3, "", true);
augerA_1629 = Fn((V _arrowThis1721, int _argc1712, V C_1718, V x_1719, V ph_1720, V _a1717, V[] _rest1713) => {
V ds_1722 = default;
ds_1722 = Call(rep_44, V.Undef, ((V)(13D)), Fn((V _arrowThis1730, int _argc1723, V j_1729, V _a1726, V _a1727, V _a1728, V[] _rest1724) => {
return GetIdx(Invoke(Call(auger_1628, V.Undef, C_1718, x_1719, Add(ph_1720, ((V)((((2D * PI_14) * ToNum(j_1729)) / 12D))))), "match", NewRegExp(RX0, "d=\"([^\"]+)\"", "")), 1D);
}, 1, "", true));
return ((V)(string.Concat("<path d=\"", ToStr(GetIdx(ds_1722, 0D)), "\" stroke=\"#ffffff\" stroke-opacity=\"0.6\" stroke-width=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_1718, "k")) * 0.55))))), "\" fill=\"none\" stroke-linecap=\"round\"><animate attributeName=\"d\" values=\"", ToStr(Invoke(ds_1722, "join", ((V)(";")))), "\" dur=\"0.8s\" repeatCount=\"indefinite\"/></path>")));
return default;
}, 3, "", true);
Set(D_1624, "fx", Fn((V _arrowThis1738, int _argc1731, V ctx_1737, V _a1734, V _a1735, V _a1736, V[] _rest1732) => {
V C_1739 = default;
V s_1740 = default;
double xl_1741 = 0;
double yb_1742 = 0;
double yt_1743 = 0;
double zi_1744 = 0;
double IH_1745 = 0;
double IDp_1746 = 0;
V IN_1747 = default;
V WB_1748 = default;
double T_1749 = 0;
V L_1750 = default;
V tank_1751 = default;
C_1739 = Call(cam_17, V.Undef, ctx_1737);
s_1740 = Call(shadow_21, V.Undef, C_1739, ((V)(0D)), ((V)(0D)), ((V)(46D)), ((V)(24D)), ((V)(0.85)));
s_1740 = Add(s_1740, Call(box3_18, V.Undef, C_1739, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)((-1D))))).Put("w", ((V)((W_1614 - 2D)))).Put("h", ((V)(PL_1617))).Put("d", ((V)((Dd_1616 - 2D)))).Put("r", ((V)(0.5))).Put("col", ((V)("#111214"))).Put("olw", ((V)(0.3))).V));
xl_1741 = (((-W_1614) / 2D) + ID_1620);
yb_1742 = (PL_1617 + ID_1620);
yt_1743 = (Hc_1615 - ID_1620);
zi_1744 = (((-Dd_1616) / 2D) + ID_1620);
IH_1745 = (yt_1743 - yb_1742);
IDp_1746 = (ZF_1619 - zi_1744);
IN_1747 = ((V)("#1b1e24"));
s_1740 = ((V)(JsStrBuf.Begin().V(s_1740).S(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_1739, Arr(((V)(xl_1741)), ((V)(yt_1743)), ((V)(zi_1744))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)((W_1614 - (2D * ID_1620)))))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(IH_1745)))), "\" fill=\"", ToStr(IN_1747), "\"/><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)((W_1614 - (2D * ID_1620)))))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(IH_1745)))), "\" fill=\"url(#m10in)\"/><rect x=\"2\" y=\"0.6\" width=\"", ToStr(Call(f1_42, V.Undef, ((V)(((W_1614 - (2D * ID_1620)) - 4D))))), "\" height=\"1\" rx=\"0.5\" fill=\"#7fd8ff\" opacity=\"", NumStr((Truthy(open_1613) ? 1D : 0.8)), "\"/><ellipse cx=\"", ToStr(Call(f1_42, V.Undef, ((V)(((W_1614 - (2D * ID_1620)) / 2D))))), "\" cy=\"2\" rx=\"", ToStr(Call(f1_42, V.Undef, ((V)((W_1614 * 0.45))))), "\" ry=\"9\" fill=\"#5fc8ff\" opacity=\"0.14\"/></g>")).S(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_1739, Arr(((V)(xl_1741)), ((V)(yt_1743)), ((V)(zi_1744))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)(IDp_1746)))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(IH_1745)))), "\" fill=\"", ToStr(Call(shade_12, V.Undef, IN_1747, ((V)(0.8)))), "\"/></g><g transform=\"", ToStr(Call(FR_23, V.Undef, C_1739, Arr(((V)(xl_1741)), ((V)(yb_1742)), ((V)(zi_1744))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)((W_1614 - (2D * ID_1620)))))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(IDp_1746)))), "\" fill=\"", ToStr(Call(shade_12, V.Undef, IN_1747, ((V)(1.2)))), "\"/></g>")).End()));
WB_1748 = Arr();
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "forEach", Fn((V _arrowThis1759, int _argc1752, V r_1758, V _a1755, V _a1756, V _a1757, V[] _rest1753) => {
double y_1760 = 0;
y_1760 = ((yb_1742 + 1D) + (ToNum(r_1758) * 9D));
Invoke(WB_1748, "push", NewObj(2).Put("q", Arr(((V)((-20D))), ((V)((y_1760 - 0.5))), ((V)((-2D))))).Put("s", Call(box3_18, V.Undef, C_1739, NewObj(8).Put("c", Arr(((V)((-20D))), ((V)(y_1760)), ((V)((-2D))))).Put("w", ((V)((((W_1614 / 2D) - ID_1620) - 1.6)))).Put("h", ((V)(0.9))).Put("d", ((V)((IDp_1746 - 2D)))).Put("r", ((V)(0.3))).Put("col", ((V)("#d9b07a"))).Put("mat", ((V)("wood"))).Put("olw", ((V)(0.2))).V)).V);
Invoke(Arr(((V)((-33D))), ((V)((-25D))), ((V)((-17D))), ((V)((-9D)))), "forEach", Fn((V _arrowThis1769, int _argc1761, V x_1767, V j_1768, V _a1765, V _a1766, V[] _rest1762) => {
return Invoke(WB_1748, "push", NewObj(2).Put("q", Arr(x_1767, ((V)((y_1760 + 3.8))), ((V)(2D)))).Put("s", Call(wineB_1626, V.Undef, C_1739, x_1767, ((V)((y_1760 + 3.8))), ((V)((-12D))), ((V)((NumTruthy((ToNum(Add(r_1758, j_1768)) % 2D)) ? "#c9a24a" : "#7a1c2a"))))).V);
}, 2, "", true));
return default;
}, 1, "", true));
s_1740 = Add(s_1740, Call(zsort_51, V.Undef, C_1739, WB_1748));
s_1740 = ((V)(JsStrBuf.Begin().V(s_1740).S(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_1739, Arr(((V)((ID_1620 + 1.2))), ((V)((yb_1742 + 18D))), ((V)(zi_1744))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)((((W_1614 / 2D) - (2D * ID_1620)) - 1.2))))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)((IDp_1746 - 1D))))), "\" fill=\"#cfe6ee\" opacity=\"0.4\"/><path d=\"M0 ", ToStr(Call(f1_42, V.Undef, ((V)((IDp_1746 - 1.2))))), "H", ToStr(Call(f1_42, V.Undef, ((V)((((W_1614 / 2D) - (2D * ID_1620)) - 1.2))))), "\" stroke=\"#ffffff\" stroke-opacity=\"0.7\" stroke-width=\"0.6\"/></g>")).End()));
Invoke(Arr(((V)(8D)), ((V)(15.5)), ((V)(23D)), ((V)(30.5))), "forEach", Fn((V _arrowThis1778, int _argc1770, V x_1776, V i_1777, V _a1774, V _a1775, V[] _rest1771) => {
return (s_1740 = Add(s_1740, Call(can3_31, V.Undef, C_1739, x_1776, ((V)(yb_1742)), ((V)(2D)), ((V)(2.9)), ((V)(8.5)), GetK(Arr(((V)(4D)), ((V)(2D)), ((V)(3D)), ((V)(5D))), i_1777))));
}, 2, "", true));
Invoke(Arr(((V)(10D)), ((V)(19D)), ((V)(28D))), "forEach", Fn((V _arrowThis1787, int _argc1779, V x_1785, V i_1786, V _a1783, V _a1784, V[] _rest1780) => {
return (s_1740 = Add(s_1740, Add(Add(Call(cyl3_19, V.Undef, C_1739, Arr(x_1785, ((V)((yb_1742 + 18D))), ((V)(2D))), Arr(x_1785, ((V)((yb_1742 + 26D))), ((V)(2D))), ((V)(2.2)), GetK(Arr(((V)("#ff8a2a")), ((V)("#7ed04a")), ((V)("#ff4f8a"))), i_1786), NewObj(3).Put("mat", ((V)("gloss"))).Put("op", ((V)(0.85))).Put("olw", ((V)(0.25))).V), Call(cyl3_19, V.Undef, C_1739, Arr(x_1785, ((V)((yb_1742 + 26D))), ((V)(2D))), Arr(x_1785, ((V)((yb_1742 + 29D))), ((V)(2D))), ((V)(2.2)), ((V)("#e8eef2")), NewObj(5).Put("r2", ((V)(0.9))).Put("mat", ((V)("gloss"))).Put("op", ((V)(0.6))).Put("noCap", ((V)(1D))).Put("olw", ((V)(0.2))).V)), Call(cyl3_19, V.Undef, C_1739, Arr(x_1785, ((V)((yb_1742 + 29D))), ((V)(2D))), Arr(x_1785, ((V)((yb_1742 + 30.4))), ((V)(2D))), ((V)(1D)), ((V)("#2a2c30")), NewObj(2).Put("mat", ((V)("matte"))).Put("olw", ((V)(0.2))).V))));
}, 2, "", true));
if (Truthy(open_1613)) {
s_1740 = ((V)(JsStrBuf.Begin().V(s_1740).S(string.Concat("<g transform=\"", ToStr(Call(FR_23, V.Undef, C_1739, Arr(((V)(xl_1741)), ((V)(yt_1743)), ((V)(ZF_1619))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><rect width=\"", ToStr(Call(f1_42, V.Undef, ((V)((W_1614 - (2D * ID_1620)))))), "\" height=\"", ToStr(Call(f1_42, V.Undef, ((V)(IH_1745)))), "\" fill=\"url(#m10cold)\">", ToStr(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.6;0.85;0.6")), ((V)(3D)))), "</rect></g>")).V(Call(mist_27, V.Undef, C_1739, ((V)((-18D))), ((V)((PL_1617 + 8D))), ((V)((ZF_1619 + 2D))), ((V)(3D)), ((V)(0.8)))).V(Call(mist_27, V.Undef, C_1739, ((V)(18D)), ((V)((PL_1617 + 8D))), ((V)((ZF_1619 + 2D))), ((V)(3D)), ((V)(0.8)))).End()));
}
s_1740 = Add(s_1740, Call(box3_18, V.Undef, C_1739, NewObj(10).Put("c", Arr(((V)(0D)), ((V)(PL_1617)), ((V)(0D)))).Put("w", ((V)(W_1614))).Put("h", ((V)((Hc_1615 - PL_1617)))).Put("d", ((V)(Dd_1616))).Put("r", ((V)(1D))).Put("col", ((V)("#2a2d32"))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.3))).Put("hole", NewObj(1).Put("f", Arr(((V)(ID_1620)), ((V)(ID_1620)), ((V)(ID_1620)), ((V)(ID_1620)))).V).Put("olw", ((V)(0.4))).V));
s_1740 = Add(s_1740, Call(box3_18, V.Undef, C_1739, NewObj(8).Put("c", Arr(((V)(0D)), ((V)(PL_1617)), ((V)((ZF_1619 - 1D))))).Put("w", ((V)(2.4))).Put("h", ((V)((Hc_1615 - PL_1617)))).Put("d", ((V)(2D))).Put("r", ((V)(0.3))).Put("col", ((V)("#2a2d32"))).Put("mat", ((V)("brush"))).Put("olw", ((V)(0.25))).V));
if (!(Truthy(open_1613))) {
s_1740 = Add(s_1740, Add(Call(doorAt_1625, V.Undef, C_1739, ((V)((-1D))), ((V)(0D))), Call(doorAt_1625, V.Undef, C_1739, ((V)(1D)), ((V)(0D)))));
} else {
V A_1788 = default;
A_1788 = Call(easeA_26, V.Undef, ((V)(100D)), ((V)(9D)));
s_1740 = Add(s_1740, Call(flip_24, V.Undef, Invoke(A_1788, "map", Fn((V _arrowThis1797, int _argc1789, V a_1795, V i_1796, V _a1793, V _a1794, V[] _rest1790) => {
return NewObj(2).Put("i", i_1796).Put("s", Add(Call(doorAt_1625, V.Undef, C_1739, ((V)((-1D))), a_1795), Call(doorAt_1625, V.Undef, C_1739, ((V)(1D)), a_1795))).V;
}, 2, "", true)), Get(A_1788, "length"), ((V)(0.7))));
}
s_1740 = Add(s_1740, Call(box3_18, V.Undef, C_1739, NewObj(11).Put("c", Arr(((V)(0D)), ((V)(Hc_1615)), ((V)(1D)))).Put("w", ((V)((W_1614 + 4D)))).Put("h", ((V)(3D))).Put("d", ((V)((Dd_1616 + 4D)))).Put("r", ((V)(0.8))).Put("col", ((V)("#dcdad5"))).Put("mat", ((V)("qz"))).Put("gl", ((V)(0.45))).Put("edge", ((V)(0.6))).Put("olc", ((V)("#7a7873"))).Put("olw", ((V)(0.35))).V));
T_1749 = (Hc_1615 + 3D);
L_1750 = Arr();
Invoke(L_1750, "push", NewObj(2).Put("q", Arr(((V)((-30D))), ((V)((T_1749 + 8D))), ((V)((-6D))))).Put("s", ((V)(JsStrBuf.Begin().V(Add(Add(Add(Call(shadow_21, V.Undef, C_1739, ((V)((-30D))), ((V)((-6D))), ((V)(4D)), ((V)(4D)), ((V)(0.5)), ((V)((T_1749 + 0.05)))), Call(cyl3_19, V.Undef, C_1739, Arr(((V)((-30D))), ((V)(T_1749)), ((V)((-6D)))), Arr(((V)((-30D))), ((V)((T_1749 + 12D))), ((V)((-6D)))), ((V)(3D)), ((V)("#1f3a26")), NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.3))).V)), Call(cyl3_19, V.Undef, C_1739, Arr(((V)((-30D))), ((V)((T_1749 + 12D))), ((V)((-6D)))), Arr(((V)((-30D))), ((V)((T_1749 + 15D))), ((V)((-6D)))), ((V)(3D)), ((V)("#1f3a26")), NewObj(4).Put("r2", ((V)(1.1))).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("olw", ((V)(0.25))).V)), Call(cyl3_19, V.Undef, C_1739, Arr(((V)((-30D))), ((V)((T_1749 + 15D))), ((V)((-6D)))), Arr(((V)((-30D))), ((V)((T_1749 + 19D))), ((V)((-6D)))), ((V)(1.1)), ((V)("#7a1c2a")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.2))).V))).S(string.Concat("<g transform=\"", ToStr(Call(tanF_22, V.Undef, C_1739, ((V)((-30D))), ((V)((-6D))), ((V)(3.02)), Get(C_1739, "thV"), ((V)((T_1749 + 9D))))), "\"><rect x=\"-2.2\" width=\"4.4\" height=\"5\" rx=\"0.4\" fill=\"#f3ead6\"/><text y=\"2.6\" text-anchor=\"middle\" font-family=\"Georgia,serif\" font-size=\"1.3\" fill=\"#5a1a1a\">Rouge</text><path d=\"M-1.5 3.6h3\" stroke=\"#b8913f\" stroke-width=\"0.3\"/></g>")).End()))).V);
Invoke(L_1750, "push", NewObj(2).Put("q", Arr(((V)((-21D))), ((V)((T_1749 + 5D))), ((V)(3D)))).Put("s", Call(wglass_1627, V.Undef, C_1739, ((V)((-21D))), ((V)(T_1749)), ((V)(3D)), ((V)(1D)))).V, NewObj(2).Put("q", Arr(((V)((-14D))), ((V)((T_1749 + 5D))), ((V)((-3D))))).Put("s", Call(wglass_1627, V.Undef, C_1739, ((V)((-14D))), ((V)(T_1749)), ((V)((-3D))), ((V)(1D)))).V);
tank_1751 = Fn((V _arrowThis1807, int _argc1798, V x_1804, V col_1805, V ph_1806, V _a1803, V[] _rest1799) => {
return Add(Add(Add(Add(Add(Call(box3_18, V.Undef, C_1739, NewObj(9).Put("c", Arr(x_1804, ((V)((T_1749 + 9D))), ((V)((-5D))))).Put("w", ((V)(11.4))).Put("h", ((V)(13D))).Put("d", ((V)(16D))).Put("r", ((V)(3D))).Put("col", col_1805).Put("gl", ((V)(0.6))).Put("olw", ((V)(0.25))).Put("olc", Call(shade_12, V.Undef, col_1805, ((V)(0.5)))).V), Call(augerA_1629, V.Undef, C_1739, x_1804, ph_1806)), Call(box3_18, V.Undef, C_1739, NewObj(12).Put("c", Arr(x_1804, ((V)((T_1749 + 8D))), ((V)((-5D))))).Put("w", ((V)(13D))).Put("h", ((V)(19D))).Put("d", ((V)(18D))).Put("r", ((V)(4D))).Put("col", ((V)("#eef6fa"))).Put("op", ((V)(0.24))).Put("gl", ((V)(1D))).Put("edge", ((V)(0.8))).Put("olc", ((V)("#8aa5b0"))).Put("olw", ((V)(0.3))).Put("olo", ((V)(0.6))).V)), Call(box3_18, V.Undef, C_1739, NewObj(8).Put("c", Arr(x_1804, ((V)((T_1749 + 27D))), ((V)((-5D))))).Put("w", ((V)(13.6))).Put("h", ((V)(3.4))).Put("d", ((V)(18.6))).Put("r", ((V)(4D))).Put("col", ((V)("#f4f5f6"))).Put("gl", ((V)(0.5))).Put("olw", ((V)(0.3))).V)), Call(box3_18, V.Undef, C_1739, NewObj(8).Put("c", Arr(x_1804, ((V)((T_1749 + 3.2))), ((V)(7.4)))).Put("w", ((V)(2.6))).Put("h", ((V)(4D))).Put("d", ((V)(1.8))).Put("r", ((V)(0.6))).Put("col", col_1805).Put("gl", ((V)(0.6))).Put("olw", ((V)(0.2))).V)), Call(cyl3_19, V.Undef, C_1739, Arr(x_1804, ((V)((T_1749 + 3D))), ((V)(6.2))), Arr(x_1804, ((V)((T_1749 + 1.6))), ((V)(6.2))), ((V)(0.7)), ((V)("#2a2c30")), NewObj(2).Put("mat", ((V)("matte"))).Put("olw", ((V)(0.2))).V));
}, 3, "", true);
Invoke(L_1750, "push", NewObj(2).Put("q", Arr(((V)(18D)), ((V)((T_1749 + 10D))), ((V)((-4D))))).Put("s", Add(Add(Add(Add(Call(shadow_21, V.Undef, C_1739, ((V)(18D)), ((V)((-2D))), ((V)(18D)), ((V)(14D)), ((V)(0.6)), ((V)((T_1749 + 0.05)))), Call(box3_18, V.Undef, C_1739, NewObj(10).Put("c", Arr(((V)(18D)), ((V)(T_1749)), ((V)((-4D))))).Put("w", ((V)(30D))).Put("h", ((V)(8D))).Put("d", ((V)(22D))).Put("r", ((V)(1.2))).Put("col", ((V)("#d0d4d8"))).Put("mat", ((V)("brush"))).Put("gl", ((V)(0.6))).Put("dec", NewObj(1).Put("f", ((V)(string.Concat("<text x=\"7.5\" y=\"6\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"1.6\" fill=\"#c4262c\">CHERRY</text><text x=\"22.5\" y=\"6\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"1.6\" fill=\"#2f6fe0\">BLUE RAZZ</text>")))).V).Put("olw", ((V)(0.3))).V)), Call(box3_18, V.Undef, C_1739, NewObj(8).Put("c", Arr(((V)(18D)), ((V)(T_1749)), ((V)(9.4)))).Put("w", ((V)(26D))).Put("h", ((V)(1.6))).Put("d", ((V)(5D))).Put("r", ((V)(0.6))).Put("col", ((V)("#3a3c40"))).Put("olw", ((V)(0.25))).Put("dec", NewObj(1).Put("t", Invoke(Call(rep_44, V.Undef, ((V)(9D)), Fn((V _arrowThis1815, int _argc1808, V i_1814, V _a1811, V _a1812, V _a1813, V[] _rest1809) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)((2D + (ToNum(i_1814) * 2.75)))))), " 0.8V4.2\" stroke=\"#1a1b1d\" stroke-width=\"0.6\"/>")));
}, 1, "", true)), "join", ((V)("")))).V).V)), Call(tank_1751, V.Undef, ((V)(10.5)), ((V)("#d8283c")), ((V)(0D)))), Call(tank_1751, V.Undef, ((V)(25.5)), ((V)("#2f7ff0")), ((V)(0.8))))).V);
s_1740 = Add(s_1740, Call(zsort_51, V.Undef, C_1739, L_1750));
return NewObj(3).Put("defs", DEF11_49).Put("front", s_1740).Put("bb", Invoke(C_1739, "bb", ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_1624;
return default;
}, 1, "", true));
Set(N_13, "chef11", Fn((V _arrowThis1823, int _argc1816, V S_1822, V _a1819, V _a1820, V _a1821, V[] _rest1817) => {
V on_1824 = default;
double W_1825 = 0;
double Hb_1826 = 0;
double Dd_1827 = 0;
double TY_1828 = 0;
V D_1829 = default;
V scr_1830 = default;
V baseF_1831 = default;
V backF_1832 = default;
V tube_1833 = default;
V arm_1834 = default;
V KP_1835 = default;
on_1824 = Call(isPlay_38, V.Undef, S_1822);
W_1825 = 100D;
Hb_1826 = 40D;
Dd_1827 = 46D;
TY_1828 = (Hb_1826 + 3D);
D_1829 = NewObj(3).Put("w", ((V)(112D))).Put("d", ((V)(58D))).Put("build", Fn((V _arrowThis1842, int _argc1836, V _a1838, V _a1839, V _a1840, V _a1841, V[] _rest1837) => {
return Arr();
}, 0, "build", true)).V;
scr_1830 = ((V)((Truthy(on_1824) ? string.Concat("<text x=\"50\" y=\"12.4\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"2.6\" fill=\"#8ff6ff\">Preparing your snack\u2026</text><rect x=\"36\" y=\"15.6\" width=\"28\" height=\"1.6\" rx=\"0.8\" fill=\"#1d3a48\"/><rect x=\"36\" y=\"15.6\" width=\"28\" height=\"1.6\" rx=\"0.8\" fill=\"#5ff0ff\">", ToStr(Call(an_39, V.Undef, ((V)("width")), ((V)("0;28")), ((V)(4.8)))), "</rect>") : string.Concat("<text x=\"50\" y=\"12.6\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"3.6\" letter-spacing=\"1.2\" fill=\"#8ff6ff\">AI CHEF</text><text x=\"50\" y=\"17\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"1.8\" fill=\"#bfefff\">Tap to order</text>"))));
baseF_1831 = ((V)(JsStrBuf.Begin().S(string.Concat("<defs><linearGradient id=\"ch11s\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#16202c\"/><stop offset=\"1\" stop-color=\"#05070a\"/></linearGradient></defs><rect x=\"32\" y=\"5.4\" width=\"36\" height=\"19\" rx=\"2\" fill=\"url(#ch11s)\" stroke=\"#c9d3dc\" stroke-width=\"0.5\"/>", ToStr(scr_1830))).V(Invoke(Invoke(Arr(Arr(((V)("#ff7ac8")), ((V)(38D))), Arr(((V)("#f2c230")), ((V)(46D))), Arr(((V)("#5ff0ff")), ((V)(54D))), Arr(((V)("#9b7bff")), ((V)(62D)))), "map", Fn((V _arrowThis1854, int _argc1843, V _a1845, V _a1846, V _a1847, V _a1848, V[] _rest1844) => {
V c_1851 = default;
V x_1853 = default;
{ V _t1849 = ListOf(_a1845);
{ V _t1850 = GetIdx(_t1849, 0D);
c_1851 = _t1850; }
{ V _t1852 = GetIdx(_t1849, 1D);
x_1853 = _t1852; }
}
return ((V)(string.Concat("<circle cx=\"", ToStr(x_1853), "\" cy=\"21.4\" r=\"1.3\" fill=\"", ToStr(c_1851), "\" opacity=\"0.85\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M34 6.4H66\" stroke=\"#ffffff\" stroke-opacity=\"0.18\" stroke-width=\"0.4\"/>", "")).S(string.Concat("<rect x=\"7\" y=\"8\" width=\"18\" height=\"15\" rx=\"2\" fill=\"#0d1218\"/><rect x=\"7\" y=\"8\" width=\"18\" height=\"15\" rx=\"2\" fill=\"none\" stroke=\"#5ff0ff\" stroke-opacity=\"0.7\" stroke-width=\"0.5\"/><text x=\"16\" y=\"27\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"1.6\" letter-spacing=\"0.6\" fill=\"#7d8b98\">PICK UP</text>")).S(string.Concat("<path d=\"M3 1.4H", NumStr((W_1825 - 3D)), "\" stroke=\"#5ff0ff\" stroke-width=\"0.9\" stroke-linecap=\"round\"", (Truthy(on_1824) ? " stroke-dasharray=\"4 3\"" : ""), ">", ToStr((Truthy(on_1824) ? Call(an_39, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-14")), ((V)(0.8))) : ((V)("")))), "</path><rect x=\"0\" y=\"", NumStr((Hb_1826 - 3D)), "\" width=\"", NumStr(W_1825), "\" height=\"3\" fill=\"#000000\" opacity=\"0.08\"/>")).V(Invoke(Call(rep_44, V.Undef, ((V)(6D)), Fn((V _arrowThis1862, int _argc1855, V i_1861, V _a1858, V _a1859, V _a1860, V[] _rest1856) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_42, V.Undef, ((V)((76D + (ToNum(i_1861) * 3D)))))), "\" y=\"10\" width=\"1.4\" height=\"12\" rx=\"0.7\" fill=\"#000000\" opacity=\"0.12\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
backF_1832 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"4\" y=\"4\" width=\"92\" height=\"46\" rx=\"2\" fill=\"#0e131a\"/><rect x=\"4\" y=\"4\" width=\"92\" height=\"46\" rx=\"2\" fill=\"url(#m10v)\"/><text x=\"72\" y=\"12\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"4\" letter-spacing=\"1.6\" fill=\"#ff7ac8\" opacity=\"0.95\">CANDY LAB</text><text x=\"72\" y=\"12\" text-anchor=\"middle\" ", ToStr(FONT_46), " font-size=\"4\" letter-spacing=\"1.6\" fill=\"#ff7ac8\" opacity=\"0.35\" filter=\"url(#m10b1)\">CANDY LAB</text>")).V(Invoke(Call(rep_44, V.Undef, ((V)(8D)), Fn((V _arrowThis1870, int _argc1863, V i_1869, V _a1866, V _a1867, V _a1868, V[] _rest1864) => {
return ((V)(string.Concat("<path d=\"M4 ", ToStr(Call(f1_42, V.Undef, ((V)((16D + (ToNum(i_1869) * 4.4)))))), "H96\" stroke=\"#5ff0ff\" stroke-opacity=\"0.05\" stroke-width=\"0.3\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
tube_1833 = Fn((V _arrowThis1882, int _argc1871, V C_1877, V x_1878, V z_1879, V cl_1880, V[] _rest1872) => {
V R_1883 = default;
double y0_1884 = 0;
double y1_1885 = 0;
V b_1886 = default;
V seed_1881 = default;
seed_1881 = (_argc1871 > 4 ? _rest1872[0] : V.Undef);
R_1883 = Call(rng_37, V.Undef, seed_1881);
y0_1884 = (TY_1828 + 20D);
y1_1885 = (TY_1828 + 50D);
b_1886 = Call(byDepth_60, V.Undef, C_1877, Call(rep_44, V.Undef, ((V)(64D)), Fn((V _arrowThis1893, int _argc1887, V _a1889, V _a1890, V _a1891, V _a1892, V[] _rest1888) => {
double a_1894 = 0;
double d_1895 = 0;
a_1894 = ((ToNum(Call(R_1883, V.Undef)) * 2D) * PI_14);
d_1895 = (System.Math.Sqrt(ToNum(Call(R_1883, V.Undef))) * 3.4);
return Arr(Add(x_1878, ((V)((d_1895 * FdLibm.Cos(a_1894))))), ((V)(((y0_1884 + 0.8) + (ToNum(Call(R_1883, V.Undef)) * ((y1_1885 - y0_1884) - 6D))))), Add(z_1879, ((V)((d_1895 * FdLibm.Sin(a_1894))))), Call(R_1883, V.Undef));
return default;
}, 0, "", true)));
return ((V)(JsStrBuf.Begin().V(Add(Add(Call(cyl3_19, V.Undef, C_1877, Arr(x_1878, ((V)(y0_1884)), z_1879), Arr(x_1878, ((V)(y1_1885)), z_1879), ((V)(4.2)), ((V)("#e6f2f6")), NewObj(4).Put("op", ((V)(0.16))).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("ol", ((V)(0D))).V), Invoke(Invoke(b_1886, "map", Fn((V _arrowThis1903, int _argc1896, V q_1902, V _a1899, V _a1900, V _a1901, V[] _rest1897) => {
V c_1904 = default;
c_1904 = Invoke(C_1877, "P", q_1902);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_42, V.Undef, GetIdx(c_1904, 0D))), "\" cy=\"", ToStr(Call(f1_42, V.Undef, GetIdx(c_1904, 1D))), "\" r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_1877, "k")) * 1.05))))), "\" fill=\"", ToStr(GetIdx(cl_1880, System.Math.Floor((ToNum(GetIdx(q_1902, 3D)) * ToNum(Get(cl_1880, "length")))))), "\"/><circle cx=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(GetIdx(c_1904, 0D)) - (ToNum(Get(C_1877, "k")) * 0.32)))))), "\" cy=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(GetIdx(c_1904, 1D)) - (ToNum(Get(C_1877, "k")) * 0.34)))))), "\" r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_1877, "k")) * 0.32))))), "\" fill=\"#ffffff\" opacity=\"0.65\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))), Call(cyl3_19, V.Undef, C_1877, Arr(x_1878, ((V)(y0_1884)), z_1879), Arr(x_1878, ((V)(y1_1885)), z_1879), ((V)(4.2)), ((V)("#e6f2f6")), NewObj(6).Put("op", ((V)(0.14))).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("olc", ((V)("#9ab5c0"))).Put("olw", ((V)(0.3))).Put("olo", ((V)(0.5))).V))).S(string.Concat("<g transform=\"", ToStr(Call(tanF_22, V.Undef, C_1877, x_1878, z_1879, ((V)(4.25)), ((V)((ToNum(Get(C_1877, "thV")) - 0.6))), ((V)((y1_1885 - 1D))))), "\"><rect x=\"-0.4\" width=\"0.8\" height=\"26\" rx=\"0.4\" fill=\"#ffffff\" opacity=\"0.5\"/></g>")).V(Call(cyl3_19, V.Undef, C_1877, Arr(x_1878, ((V)(y1_1885)), z_1879), Arr(x_1878, ((V)((y1_1885 + 2D))), z_1879), ((V)(4.6)), ((V)("#dfe5ea")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.25))).V)).V(Call(cyl3_19, V.Undef, C_1877, Arr(x_1878, ((V)((y0_1884 - 1.6))), z_1879), Arr(x_1878, ((V)(y0_1884)), z_1879), ((V)(4.6)), ((V)("#dfe5ea")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.25))).V)).V(Call(cyl3_19, V.Undef, C_1877, Arr(x_1878, ((V)((y0_1884 - 1.6))), z_1879), Arr(x_1878, ((V)((TY_1828 + 15D))), z_1879), ((V)(2.4)), ((V)("#dfe5ea")), NewObj(3).Put("r2", ((V)(1.1))).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.25))).V)).End()));
return default;
}, 5, "", true);
arm_1834 = Fn((V _arrowThis1916, int _argc1905, V C_1911, V ps_1912, V al_1913, V be_1914, V[] _rest1906) => {
V B_1917 = default;
V dir_1918 = default;
V P1_1919 = default;
V P2v_1920 = default;
V P3_1921 = default;
V s_1922 = default;
V hold_1915 = default;
hold_1915 = (_argc1905 > 4 ? _rest1906[0] : V.Undef);
B_1917 = Arr(((V)(4D)), ((V)((TY_1828 + 8D))), ((V)(2D)));
dir_1918 = Fn((V _arrowThis1930, int _argc1923, V a_1929, V _a1926, V _a1927, V _a1928, V[] _rest1924) => {
return Arr(((V)((FdLibm.Sin(ToNum(a_1929)) * FdLibm.Sin(ToNum(ps_1912))))), ((V)(FdLibm.Cos(ToNum(a_1929)))), ((V)((FdLibm.Sin(ToNum(a_1929)) * FdLibm.Cos(ToNum(ps_1912))))));
}, 1, "", true);
P1_1919 = Call(add_33, V.Undef, B_1917, Call(mul_35, V.Undef, Call(dir_1918, V.Undef, al_1913), ((V)(18D))));
P2v_1920 = Call(add_33, V.Undef, P1_1919, Call(mul_35, V.Undef, Call(dir_1918, V.Undef, Add(al_1913, be_1914)), ((V)(16D))));
P3_1921 = Call(add_33, V.Undef, P2v_1920, Arr(((V)(0D)), ((V)((-3D))), ((V)(0D))));
s_1922 = Add(Add(Add(Add(Call(cyl3_19, V.Undef, C_1911, B_1917, P1_1919, ((V)(3.2)), ((V)("#f4f6f8")), NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.3))).V), Call(sph_20, V.Undef, C_1911, P1_1919, ((V)(3.8)), ((V)("#b7c0ca")))), Call(cyl3_19, V.Undef, C_1911, P1_1919, P2v_1920, ((V)(2.6)), ((V)("#f4f6f8")), NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.3))).V)), Call(sph_20, V.Undef, C_1911, P2v_1920, ((V)(2.8)), ((V)("#b7c0ca")))), Call(cyl3_19, V.Undef, C_1911, P2v_1920, P3_1921, ((V)(1.2)), ((V)("#8f99a3")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.25))).V));
if (Truthy(hold_1915)) {
s_1922 = Add(s_1922, Add(Call(cyl3_19, V.Undef, C_1911, Call(add_33, V.Undef, P3_1921, Arr(((V)(0D)), ((V)((-9D))), ((V)(0D)))), Call(add_33, V.Undef, P3_1921, Arr(((V)(0D)), ((V)((-1.6))), ((V)(0D)))), ((V)(2.6)), ((V)("#f4f2ec")), NewObj(4).Put("r2", ((V)(3.5))).Put("mat", ((V)("gloss"))).Put("pat", ((V)("m11str"))).Put("olw", ((V)(0.3))).V), Call(heap_61, V.Undef, C_1911, GetIdx(P3_1921, 0D), GetIdx(P3_1921, 2D), ((V)(2.6)), ((V)(2.6)), ((V)((ToNum(GetIdx(P3_1921, 1D)) - 2D))), ((V)(2D)), ((V)(9D)), ((V)("bk")), ((V)(0.85)))));
}
return Add(s_1922, Invoke(Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis1938, int _argc1931, V sg_1937, V _a1934, V _a1935, V _a1936, V[] _rest1932) => {
return Call(cyl3_19, V.Undef, C_1911, P3_1921, Call(add_33, V.Undef, P3_1921, Arr(((V)(((ToNum(sg_1937) * 1.6) * FdLibm.Cos(ToNum(ps_1912))))), ((V)((-2.6))), ((V)((((-ToNum(sg_1937)) * 1.6) * FdLibm.Sin(ToNum(ps_1912))))))), ((V)(0.5)), ((V)("#5a646e")), NewObj(2).Put("mat", ((V)("metal"))).Put("ol", ((V)(0D))).V);
}, 1, "", true)), "join", ((V)(""))));
return default;
}, 5, "", true);
KP_1835 = Arr(Arr(((V)(0.25)), ((V)(0.5)), ((V)(1.5)), ((V)(0D))), Arr(((V)((-1.75))), ((V)(1.15)), ((V)(0.65)), ((V)(0D))), Arr(((V)((-1.75))), ((V)(1.05)), ((V)(0.75)), ((V)(0D))), Arr(((V)((-0.4))), ((V)(0.75)), ((V)(1.1)), ((V)(0D))), Arr(((V)(1.75)), ((V)(1D)), ((V)(0.7)), ((V)(0D))), Arr(((V)(1.75)), ((V)(1D)), ((V)(0.75)), ((V)(1D))), Arr(((V)(0.6)), ((V)(0.85)), ((V)(0.9)), ((V)(1D))), Arr(((V)(0.25)), ((V)(0.95)), ((V)(0.75)), ((V)(1D))), Arr(((V)(0.25)), ((V)(0.5)), ((V)(1.5)), ((V)(0D))));
Set(D_1829, "fx", Fn((V _arrowThis1946, int _argc1939, V ctx_1945, V _a1942, V _a1943, V _a1944, V[] _rest1940) => {
V C_1947 = default;
V s_1948 = default;
V L_1949 = default;
V fr_1950 = default;
C_1947 = Call(cam_17, V.Undef, ctx_1945);
s_1948 = Add(Call(shadow_21, V.Undef, C_1947, ((V)(0D)), ((V)(0D)), ((V)(58D)), ((V)(32D)), ((V)(0.85))), Call(planeE_64, V.Undef, C_1947, ((V)(0D)), ((V)(0.06)), ((V)(0D)), ((V)(56D)), ((V)(30D)), ((V)("url(#m11cy)")), ((V)((Truthy(on_1824) ? 0.6 : 0.35))), (Truthy(on_1824) ? Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.4;0.7;0.4")), ((V)(2D))) : ((V)("")))));
s_1948 = Add(s_1948, Call(box3_18, V.Undef, C_1947, NewObj(10).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("w", ((V)(W_1825))).Put("h", ((V)(Hb_1826))).Put("d", ((V)(Dd_1827))).Put("r", ((V)(5D))).Put("col", ((V)("#f3f5f7"))).Put("gl", ((V)(0.8))).Put("dec", NewObj(1).Put("f", baseF_1831).V).Put("olw", ((V)(0.4))).Put("olo", ((V)(0.5))).V));
s_1948 = Add(s_1948, Call(box3_18, V.Undef, C_1947, NewObj(10).Put("c", Arr(((V)(0D)), ((V)(Hb_1826)), ((V)(1D)))).Put("w", ((V)((W_1825 + 4D)))).Put("h", ((V)(3D))).Put("d", ((V)((Dd_1827 + 4D)))).Put("r", ((V)(5.5))).Put("col", ((V)("#e3e8ed"))).Put("gl", ((V)(0.9))).Put("dec", NewObj(1).Put("f", ((V)(string.Concat("<path d=\"M5 2.2H", NumStr((W_1825 - 1D)), "\" stroke=\"#5ff0ff\" stroke-width=\"0.6\" stroke-opacity=\"0.8\"/>")))).V).Put("olw", ((V)(0.35))).Put("olo", ((V)(0.5))).V));
s_1948 = Add(s_1948, Call(box3_18, V.Undef, C_1947, NewObj(10).Put("c", Arr(((V)(0D)), ((V)(TY_1828)), ((V)((((-Dd_1827) / 2D) + 4D))))).Put("w", ((V)(W_1825))).Put("h", ((V)(54D))).Put("d", ((V)(8D))).Put("r", ((V)(3D))).Put("col", ((V)("#f3f5f7"))).Put("gl", ((V)(0.7))).Put("dec", NewObj(1).Put("f", backF_1832).V).Put("olw", ((V)(0.35))).Put("olo", ((V)(0.5))).V));
L_1949 = Arr();
Invoke(Arr(Arr(((V)((-42D))), Arr(((V)("#ff5a8a")), ((V)("#ff9ac0")), ((V)("#ffffff")))), Arr(((V)((-31D))), Arr(((V)("#f2c230")), ((V)("#ff8a2a")), ((V)("#ffe9a0")))), Arr(((V)((-20D))), Arr(((V)("#5ff0ff")), ((V)("#9b7bff")), ((V)("#7ed04a"))))), "forEach", Fn((V _arrowThis1963, int _argc1951, V _a1953, V i_1957, V _a1955, V _a1956, V[] _rest1952) => {
V x_1960 = default;
V cl_1962 = default;
{ V _t1958 = ListOf(_a1953);
{ V _t1959 = GetIdx(_t1958, 0D);
x_1960 = _t1959; }
{ V _t1961 = GetIdx(_t1958, 1D);
cl_1962 = _t1961; }
}
return Invoke(L_1949, "push", NewObj(2).Put("q", Arr(x_1960, ((V)((TY_1828 + 30D))), ((V)((-12D))))).Put("s", Call(tube_1833, V.Undef, C_1947, x_1960, ((V)((-12D))), cl_1962, ((V)(JsStrBuf.Begin().S("tb").V(i_1957).End())))).V);
}, 2, "", true));
Invoke(L_1949, "push", NewObj(2).Put("q", Arr(((V)((-31D))), ((V)((TY_1828 + 3D))), ((V)((-12D))))).Put("s", Add(Call(cyl3_19, V.Undef, C_1947, Arr(((V)((-31D))), ((V)(TY_1828)), ((V)((-12D)))), Arr(((V)((-31D))), ((V)((TY_1828 + 7D))), ((V)((-12D)))), ((V)(2.4)), ((V)("#f4f2ec")), NewObj(4).Put("r2", ((V)(3.2))).Put("mat", ((V)("gloss"))).Put("pat", ((V)("m11str"))).Put("olw", ((V)(0.3))).V), (Truthy(on_1824) ? Invoke(Call(rep_44, V.Undef, ((V)(4D)), Fn((V _arrowThis1971, int _argc1964, V i_1970, V _a1967, V _a1968, V _a1969, V[] _rest1965) => {
V a_1972 = default;
V b_1973 = default;
V c_1974 = default;
a_1972 = Invoke(C_1947, "p", ((V)((-31D))), ((V)((TY_1828 + 14.6))), ((V)((-12D))));
b_1973 = Invoke(C_1947, "p", ((V)((-31D))), ((V)((TY_1828 + 6.5))), ((V)((-12D))));
c_1974 = GetK(Arr(((V)("#ff5a8a")), ((V)("#f2c230")), ((V)("#5ff0ff")), ((V)("#7ed04a"))), i_1970);
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_1947, "k")) * 0.9))))), "\" fill=\"", ToStr(c_1974), "\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;1;1;0\" keyTimes=\"0;0.1;0.9;1\" dur=\"0.6s\" begin=\"", ToStr(Call(n4_43, V.Undef, ((V)(((-ToNum(i_1970)) * 0.15))))), "s\" repeatCount=\"indefinite\"/><animateMotion dur=\"0.6s\" begin=\"", ToStr(Call(n4_43, V.Undef, ((V)(((-ToNum(i_1970)) * 0.15))))), "s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(P2_45, V.Undef, a_1972)), "L", ToStr(Call(P2_45, V.Undef, b_1973)), "\"/></circle>")));
return default;
}, 1, "", true)), "join", ((V)(""))) : ((V)(""))))).V);
{
V ring_1975 = default;
V dome_1976 = default;
ring_1975 = Fn((V _arrowThis1985, int _argc1977, V y_1983, V r_1984, V _a1981, V _a1982, V[] _rest1978) => {
return Call(rep_44, V.Undef, ((V)(24D)), Fn((V _arrowThis1993, int _argc1986, V i_1992, V _a1989, V _a1990, V _a1991, V[] _rest1987) => {
double t_1994 = 0;
t_1994 = (((ToNum(i_1992) / 24D) * 2D) * PI_14);
return Invoke(C_1947, "p", ((V)((36D + (ToNum(r_1984) * FdLibm.Cos(t_1994))))), y_1983, ((V)(((-6D) + (ToNum(r_1984) * FdLibm.Sin(t_1994))))));
return default;
}, 1, "", true));
}, 2, "", true);
dome_1976 = Call(hull_48, V.Undef, InvokeSpread(Arr(), "concat", new ArrBuilder().Add(Call(ring_1975, V.Undef, ((V)((TY_1828 + 5D))), ((V)(9.4)))).Spread(Invoke(Arr(((V)(0.3)), ((V)(0.6)), ((V)(0.85)), ((V)(1D))), "map", Fn((V _arrowThis2002, int _argc1995, V k_2001, V _a1998, V _a1999, V _a2000, V[] _rest1996) => {
return Call(ring_1975, V.Undef, ((V)(((TY_1828 + 13D) + (9.4 * FdLibm.Sin(((ToNum(k_2001) * PI_14) / 2D)))))), ((V)((9.4 * FdLibm.Cos((((ToNum(k_2001) * PI_14) / 2D) * 0.98))))));
}, 1, "", true))).V));
Invoke(L_1949, "push", NewObj(2).Put("q", Arr(((V)(36D)), ((V)((TY_1828 + 8D))), ((V)((-6D))))).Put("s", ((V)(JsStrBuf.Begin().V(Add(Call(cyl3_19, V.Undef, C_1947, Arr(((V)(36D)), ((V)(TY_1828)), ((V)((-6D)))), Arr(((V)(36D)), ((V)((TY_1828 + 5D))), ((V)((-6D)))), ((V)(10D)), ((V)("#dfe5ea")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.3))).V), Call(heap_61, V.Undef, C_1947, ((V)(36D)), ((V)((-6D))), ((V)(7.4)), ((V)(7.4)), ((V)((TY_1828 + 5D))), ((V)(7D)), ((V)(46D)), ((V)("dome")), ((V)(1D))))).S(string.Concat("<path d=\"", ToStr(Call(pth_47, V.Undef, dome_1976)), "\" fill=\"#e6f2f6\" opacity=\"0.16\" stroke=\"#9ab5c0\" stroke-opacity=\"0.55\" stroke-width=\"0.35\"/><path d=\"", ToStr(Call(pth_47, V.Undef, dome_1976)), "\" fill=\"url(#m11gl)\" opacity=\"0.8\"/>")).V(Call(sph_20, V.Undef, C_1947, Arr(((V)(36D)), ((V)((TY_1828 + 23.4))), ((V)((-6D)))), ((V)(1.4)), ((V)("#dfe5ea")))).End()))).V);
}
Invoke(L_1949, "push", NewObj(2).Put("q", Arr(((V)(4D)), ((V)((TY_1828 + 2D))), ((V)(2D)))).Put("s", Add(Add(Add(Call(cyl3_19, V.Undef, C_1947, Arr(((V)(4D)), ((V)(TY_1828)), ((V)(2D))), Arr(((V)(4D)), ((V)((TY_1828 + 3D))), ((V)(2D))), ((V)(6.4)), ((V)("#dfe4ea")), NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.3))).V), Call(cyl3_19, V.Undef, C_1947, Arr(((V)(4D)), ((V)((TY_1828 + 3D))), ((V)(2D))), Arr(((V)(4D)), ((V)((TY_1828 + 8D))), ((V)(2D))), ((V)(4.2)), ((V)("#f4f6f8")), NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.3))).V)), Invoke(Call(planeE_64, V.Undef, C_1947, ((V)(4D)), ((V)((TY_1828 + 3.1))), ((V)(2D)), ((V)(5.4)), ((V)(5.4)), ((V)("none")), ((V)(1D))), "replace", ((V)("fill=\"none\"")), ((V)("fill=\"none\" stroke=\"#5ff0ff\" stroke-width=\"0.5\"")))), Call(sph_20, V.Undef, C_1947, Arr(((V)(4D)), ((V)((TY_1828 + 8D))), ((V)(2D))), ((V)(3.6)), ((V)("#c9d0d8"))))).V);
fr_1950 = Arr();
if (Truthy(on_1824)) {
{
double i_2003 = 0;
i_2003 = 0D;
while (true) {
if (!((i_2003 < (ToNum(Get(KP_1835, "length")) - 1D)))) break;
{
double k_2005 = 0;
k_2005 = 0D;
while (true) {
if (!((k_2005 < 4D))) break;
V a_2007 = default;
V b_2008 = default;
double t_2009 = 0;
a_2007 = GetIdx(KP_1835, i_2003);
b_2008 = GetIdx(KP_1835, (i_2003 + 1D));
t_2009 = (k_2005 / 4D);
Invoke(fr_1950, "push", Call(arm_1834, V.Undef, C_1947, Add(GetIdx(a_2007, 0D), ((V)(((ToNum(GetIdx(b_2008, 0D)) - ToNum(GetIdx(a_2007, 0D))) * t_2009)))), Add(GetIdx(a_2007, 1D), ((V)(((ToNum(GetIdx(b_2008, 1D)) - ToNum(GetIdx(a_2007, 1D))) * t_2009)))), Add(GetIdx(a_2007, 2D), ((V)(((ToNum(GetIdx(b_2008, 2D)) - ToNum(GetIdx(a_2007, 2D))) * t_2009)))), (NumTruthy(k_2005) ? (GetIdx(b_2008, 3D) is var _t2010 && !Truthy(_t2010) ? _t2010 : GetIdx(a_2007, 3D)) : GetIdx(a_2007, 3D))));
k_2005++;
}
}
i_2003++;
}
}
}
Invoke(L_1949, "push", NewObj(2).Put("q", Arr(((V)(4D)), ((V)((TY_1828 + 10D))), ((V)(4D)))).Put("s", (Truthy(on_1824) ? Call(loopF_52, V.Undef, fr_1950, ((V)(6.4))) : Call(arm_1834, V.Undef, C_1947, GetIdx(GetIdx(KP_1835, 0D), 0D), GetIdx(GetIdx(KP_1835, 0D), 1D), GetIdx(GetIdx(KP_1835, 0D), 2D), ((V)(0D))))).V);
s_1948 = Add(s_1948, Call(zsort_51, V.Undef, C_1947, L_1949));
return NewObj(3).Put("defs", DEF11_49).Put("front", s_1948).Put("bb", Invoke(C_1947, "bb", ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_1829;
return default;
}, 1, "", true));
Set(N_13, "mock11", Fn((V _arrowThis2018, int _argc2011, V S_2017, V _a2014, V _a2015, V _a2016, V[] _rest2012) => {
V open_2019 = default;
V D_2020 = default;
double Y_2021 = 0;
double RD0_2022 = 0;
V SC_2023 = default;
open_2019 = Call(isPlay_38, V.Undef, S_2017);
D_2020 = NewObj(3).Put("w", ((V)(64D))).Put("d", ((V)(64D))).Put("build", Fn((V _arrowThis2030, int _argc2024, V _a2026, V _a2027, V _a2028, V _a2029, V[] _rest2025) => {
return Arr();
}, 0, "build", true)).V;
Y_2021 = 35D;
RD0_2022 = 19.5;
SC_2023 = Arr(Arr(((V)("#ff4fa0")), ((V)("#ffd0e6"))), Arr(((V)("#9bff4a")), ((V)("#eaffd0"))), Arr(((V)("#3fb6ff")), ((V)("#d6f2ff"))));
Set(D_2020, "fx", Fn((V _arrowThis2038, int _argc2031, V ctx_2037, V _a2034, V _a2035, V _a2036, V[] _rest2032) => {
V C_2039 = default;
V th_2040 = default;
V s_2041 = default;
V defs_2042 = default;
double gl0_2043 = 0;
V liq_2044 = default;
double oy_2045 = 0;
V orb_2046 = default;
V op_2047 = default;
V dome_2048 = default;
C_2039 = Call(cam_17, V.Undef, ctx_2037);
th_2040 = Get(C_2039, "thV");
s_2041 = Add(Call(planeE_64, V.Undef, C_2039, ((V)(0D)), ((V)(0.06)), ((V)(0D)), ((V)(34D)), ((V)(34D)), ((V)("url(#m11cy)")), ((V)(0.55)), Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.4;0.65;0.4")), ((V)(3D)))), Call(shadow_21, V.Undef, C_2039, ((V)(0D)), ((V)(0D)), ((V)(28D)), ((V)(28D)), ((V)(0.7))));
defs_2042 = Invoke(Invoke(SC_2023, "map", Fn((V _arrowThis2061, int _argc2049, V _a2051, V i_2055, V _a2053, V _a2054, V[] _rest2050) => {
V a_2058 = default;
V b_2060 = default;
{ V _t2056 = ListOf(_a2051);
{ V _t2057 = GetIdx(_t2056, 0D);
a_2058 = _t2057; }
{ V _t2059 = GetIdx(_t2056, 1D);
b_2060 = _t2059; }
}
return ((V)(string.Concat("<radialGradient id=\"mk11g", ToStr(i_2055), "\" cx=\"35%\" cy=\"30%\" r=\"70%\"><stop offset=\"0\" stop-color=\"", ToStr(b_2060), "\"/><stop offset=\"0.35\" stop-color=\"", ToStr(a_2058), "\"/><stop offset=\"1\" stop-color=\"", ToStr(Call(shade_12, V.Undef, a_2058, ((V)(0.45)))), "\"/></radialGradient>")));
}, 2, "", true)), "join", ((V)("")));
s_2041 = Add(s_2041, Add(Call(cyl3_19, V.Undef, C_2039, Arr(((V)(0D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(32D)), ((V)(0D))), ((V)(24D)), ((V)("#f2f4f7")), NewObj(5).Put("r2", ((V)(20D))).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("olw", ((V)(0.4))).Put("olo", ((V)(0.5))).V), Call(cyl3_19, V.Undef, C_2039, Arr(((V)(0D)), ((V)(27.5)), ((V)(0D))), Arr(((V)(0D)), ((V)(29.2)), ((V)(0D))), ((V)(20.9)), ((V)("#5ff0ff")), NewObj(4).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("ol", ((V)(0D))).Put("f", ((V)(1.2))).V)));
{
V c_2062 = default;
c_2062 = Invoke(C_2039, "p", ((V)(0D)), ((V)(28.3)), ((V)(0D)));
s_2041 = ((V)(JsStrBuf.Begin().V(s_2041).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_42, V.Undef, GetIdx(c_2062, 0D))), "\" cy=\"", ToStr(Call(f1_42, V.Undef, GetIdx(c_2062, 1D))), "\" rx=\"", ToStr(Call(f1_42, V.Undef, ((V)((24D * ToNum(Get(C_2039, "k"))))))), "\" ry=\"", ToStr(Call(f1_42, V.Undef, ((V)((9D * ToNum(Get(C_2039, "k"))))))), "\" fill=\"url(#m11cy)\" opacity=\"0.5\">", ToStr(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.3;0.6;0.3")), ((V)(2.4)))), "</ellipse>")).End()));
}
s_2041 = Add(s_2041, Call(cyl3_19, V.Undef, C_2039, Arr(((V)(0D)), ((V)(32D)), ((V)(0D))), Arr(((V)(0D)), ((V)(Y_2021)), ((V)(0D))), ((V)(21.5)), ((V)("#d9dee3")), NewObj(3).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.35))).Put("cap", Fn((V _arrowThis2070, int _argc2063, V cr_2069, V _a2066, V _a2067, V _a2068, V[] _rest2064) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(cr_2069) * 0.9))))), "\" fill=\"none\" stroke=\"#9aa3ab\" stroke-width=\"0.5\"/>")).V(Invoke(Call(rep_44, V.Undef, ((V)(12D)), Fn((V _arrowThis2078, int _argc2071, V i_2077, V _a2074, V _a2075, V _a2076, V[] _rest2072) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_42, V.Undef, ((V)(((ToNum(cr_2069) * 0.2) * FdLibm.Cos(((ToNum(i_2077) * PI_14) / 6D))))))), " ", ToStr(Call(f1_42, V.Undef, ((V)(((ToNum(cr_2069) * 0.2) * FdLibm.Sin(((ToNum(i_2077) * PI_14) / 6D))))))), "L", ToStr(Call(f1_42, V.Undef, ((V)(((ToNum(cr_2069) * 0.5) * FdLibm.Cos(((ToNum(i_2077) * PI_14) / 6D))))))), " ", ToStr(Call(f1_42, V.Undef, ((V)(((ToNum(cr_2069) * 0.5) * FdLibm.Sin(((ToNum(i_2077) * PI_14) / 6D))))))), "\" stroke=\"#aab2ba\" stroke-width=\"0.6\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
}, 1, "cap", true)).V));
Invoke(Arr(((V)((-0.6))), ((V)(0D)), ((V)(0.6))), "forEach", Fn((V _arrowThis2087, int _argc2079, V da_2085, V i_2086, V _a2083, V _a2084, V[] _rest2080) => {
V a_2088 = default;
V o_2089 = default;
V e_2090 = default;
a_2088 = Add(th_2040, da_2085);
o_2089 = Arr(((V)((20D * FdLibm.Sin(ToNum(a_2088))))), ((V)(31D)), ((V)((20D * FdLibm.Cos(ToNum(a_2088))))));
e_2090 = Arr(((V)((25D * FdLibm.Sin(ToNum(a_2088))))), ((V)(31D)), ((V)((25D * FdLibm.Cos(ToNum(a_2088))))));
s_2041 = Add(s_2041, Add(Add(Call(cyl3_19, V.Undef, C_2039, o_2089, e_2090, ((V)(1D)), ((V)("#d9dee3")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.25))).V), Call(cyl3_19, V.Undef, C_2039, e_2090, Call(add_33, V.Undef, e_2090, Arr(((V)(0D)), ((V)((-3D))), ((V)(0D)))), ((V)(0.75)), ((V)("#d9dee3")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.2))).V)), Call(sph_20, V.Undef, C_2039, Call(add_33, V.Undef, o_2089, Arr(((V)(0D)), ((V)(2.6)), ((V)(0D)))), ((V)(1.3)), GetIdx(GetK(SC_2023, i_2086), 0D))));
return default;
}, 2, "", true));
s_2041 = Add(s_2041, Call(cyl3_19, V.Undef, C_2039, Arr(((V)(0D)), ((V)(Y_2021)), ((V)(0D))), Arr(((V)(0D)), ((V)((Y_2021 + 4D))), ((V)(0D))), ((V)(3D)), ((V)("#d9dee3")), NewObj(2).Put("mat", ((V)("chrome"))).Put("olw", ((V)(0.25))).V));
gl0_2043 = (Y_2021 + 4.6);
liq_2044 = Fn((V _arrowThis2098, int _argc2091, V L_2097, V _a2094, V _a2095, V _a2096, V[] _rest2092) => {
return Call(cyl3_19, V.Undef, C_2039, Arr(((V)(0D)), ((V)(gl0_2043)), ((V)(0D))), Arr(((V)(0D)), Add(((V)(gl0_2043)), L_2097), ((V)(0D))), ((V)(3.1)), ((V)("#ff4fa0")), NewObj(5).Put("r2", ((V)((3.1 + (ToNum(L_2097) * 0.05))))).Put("mat", ((V)("gloss"))).Put("op", ((V)(0.88))).Put("olw", ((V)(0.2))).Put("capCol", ((V)("#ff86c0"))).V);
}, 1, "", true);
s_2041 = Add(s_2041, Call(cyl3_19, V.Undef, C_2039, Arr(((V)(0D)), ((V)((Y_2021 + 4D))), ((V)(0D))), Arr(((V)(0D)), ((V)((Y_2021 + 4.6))), ((V)(0D))), ((V)(3.6)), ((V)("#e6f2f6")), NewObj(3).Put("op", ((V)(0.5))).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.2))).V));
if (Truthy(open_2019)) {
V LV_2099 = default;
V g0_2100 = default;
LV_2099 = Call(rep_44, V.Undef, ((V)(10D)), Fn((V _arrowThis2108, int _argc2101, V i_2107, V _a2104, V _a2105, V _a2106, V[] _rest2102) => {
return Add(((V)(5D)), i_2107);
}, 1, "", true));
s_2041 = Add(s_2041, Call(flip_24, V.Undef, Invoke(LV_2099, "map", Fn((V _arrowThis2117, int _argc2109, V l_2115, V i_2116, V _a2113, V _a2114, V[] _rest2110) => {
return NewObj(2).Put("i", i_2116).Put("s", Call(liq_2044, V.Undef, l_2115)).V;
}, 2, "", true)), Get(LV_2099, "length"), ((V)(2.4))));
g0_2100 = Invoke(C_2039, "p", ((V)(0D)), ((V)((gl0_2043 + 1D))), ((V)(0D)));
s_2041 = Add(s_2041, Invoke(Call(rep_44, V.Undef, ((V)(6D)), Fn((V _arrowThis2125, int _argc2118, V i_2124, V _a2121, V _a2122, V _a2123, V[] _rest2119) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_2039, "k")) * 0.35))))), "\" fill=\"#ffffff\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0.8;0\" dur=\"1.4s\" begin=\"", ToStr(Call(n4_43, V.Undef, ((V)(((-ToNum(i_2124)) * 0.23))))), "s\" repeatCount=\"indefinite\"/><animateMotion dur=\"1.4s\" begin=\"", ToStr(Call(n4_43, V.Undef, ((V)(((-ToNum(i_2124)) * 0.23))))), "s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(f1_42, V.Undef, Add(GetIdx(g0_2100, 0D), ((V)(((((ToNum(i_2124) % 3D) - 1D) * ToNum(Get(C_2039, "k"))) * 1.4)))))), " ", ToStr(Call(f1_42, V.Undef, GetIdx(g0_2100, 1D))), "v", ToStr(Call(f1_42, V.Undef, ((V)(((-11D) * ToNum(Get(C_2039, "k"))))))), "\"/></circle>")));
}, 1, "", true)), "join", ((V)(""))));
} else {
s_2041 = Add(s_2041, Call(liq_2044, V.Undef, ((V)(4D))));
}
s_2041 = Add(s_2041, Call(cyl3_19, V.Undef, C_2039, Arr(((V)(0D)), ((V)((Y_2021 + 4.6))), ((V)(0D))), Arr(((V)(0D)), ((V)((Y_2021 + 20D))), ((V)(0D))), ((V)(3.5)), ((V)("#e6f2f6")), NewObj(7).Put("r2", ((V)(4.3))).Put("op", ((V)(0.22))).Put("mat", ((V)("gloss"))).Put("noCap", ((V)(1D))).Put("olc", ((V)("#9ab5c0"))).Put("olw", ((V)(0.25))).Put("olo", ((V)(0.6))).V));
oy_2045 = (Truthy(open_2019) ? 58D : 52D);
orb_2046 = Call(rep_44, V.Undef, ((V)(32D)), Fn((V _arrowThis2133, int _argc2126, V i_2132, V _a2129, V _a2130, V _a2131, V[] _rest2127) => {
double t_2134 = 0;
t_2134 = (((ToNum(i_2132) / 32D) * 2D) * PI_14);
return Invoke(C_2039, "p", ((V)((11D * FdLibm.Cos(t_2134)))), ((V)((oy_2045 + (1.6 * FdLibm.Sin((t_2134 * 2D)))))), ((V)((11D * FdLibm.Sin(t_2134)))));
return default;
}, 1, "", true));
op_2047 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(orb_2046, "map", P2_45), "join", ((V)("L")))).S("Z").End()));
s_2041 = Add(s_2041, Invoke(Invoke(SC_2023, "map", Fn((V _arrowThis2143, int _argc2135, V c_2141, V i_2142, V _a2139, V _a2140, V[] _rest2136) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_2039, "k")) * 2.7))))), "\" fill=\"url(#mk11g", ToStr(i_2142), ")\"><animateMotion dur=\"", NumStr((Truthy(open_2019) ? 2.4 : 6D)), "s\" begin=\"", ToStr(Call(n4_43, V.Undef, ((V)(((-ToNum(i_2142)) * (Truthy(open_2019) ? 0.8 : 2D)))))), "s\" repeatCount=\"indefinite\" path=\"", ToStr(op_2047), "\"/></circle>")));
}, 2, "", true)), "join", ((V)(""))));
if (Truthy(open_2019)) {
V g_2144 = default;
g_2144 = Invoke(C_2039, "p", ((V)(0D)), ((V)((gl0_2043 + 15D))), ((V)(0D)));
s_2041 = Add(s_2041, Invoke(Call(rep_44, V.Undef, ((V)(6D)), Fn((V _arrowThis2152, int _argc2145, V i_2151, V _a2148, V _a2149, V _a2150, V[] _rest2146) => {
V st_2153 = default;
st_2153 = Invoke(C_2039, "p", ((V)((11D * FdLibm.Cos(ToNum(i_2151))))), ((V)(oy_2045)), ((V)((11D * FdLibm.Sin(ToNum(i_2151))))));
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Get(C_2039, "k")) * 0.9))))), "\" fill=\"url(#mk11g", NumStr((ToNum(i_2151) % 3D)), ")\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;1;1;0\" keyTimes=\"0;0.1;0.85;1\" dur=\"1.2s\" begin=\"", ToStr(Call(n4_43, V.Undef, ((V)(((-ToNum(i_2151)) * 0.2))))), "s\" repeatCount=\"indefinite\"/><animateMotion dur=\"1.2s\" begin=\"", ToStr(Call(n4_43, V.Undef, ((V)(((-ToNum(i_2151)) * 0.2))))), "s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(P2_45, V.Undef, st_2153)), "Q", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(Add(GetIdx(st_2153, 0D), GetIdx(g_2144, 0D))) / 2D))))), " ", ToStr(Call(f1_42, V.Undef, ((V)((ToNum(GetIdx(st_2153, 1D)) - 6D))))), " ", ToStr(Call(P2_45, V.Undef, g_2144)), "\"/></circle>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
}
dome_2048 = Fn((V _arrowThis2161, int _argc2154, V dy_2160, V _a2157, V _a2158, V _a2159, V[] _rest2155) => {
V ring_2162 = default;
V y0_2163 = default;
V y1_2164 = default;
V P_2165 = default;
ring_2162 = Fn((V _arrowThis2174, int _argc2166, V y_2172, V r_2173, V _a2170, V _a2171, V[] _rest2167) => {
return Call(rep_44, V.Undef, ((V)(28D)), Fn((V _arrowThis2182, int _argc2175, V i_2181, V _a2178, V _a2179, V _a2180, V[] _rest2176) => {
double t_2183 = 0;
t_2183 = (((ToNum(i_2181) / 28D) * 2D) * PI_14);
return Invoke(C_2039, "p", ((V)((ToNum(r_2173) * FdLibm.Cos(t_2183)))), y_2172, ((V)((ToNum(r_2173) * FdLibm.Sin(t_2183)))));
return default;
}, 1, "", true));
}, 2, "", true);
y0_2163 = Add(((V)(Y_2021)), dy_2160);
y1_2164 = Add(((V)((Y_2021 + 26D))), dy_2160);
P_2165 = Call(hull_48, V.Undef, InvokeSpread(Arr(), "concat", new ArrBuilder().Add(Call(ring_2162, V.Undef, y0_2163, ((V)(RD0_2022)))).Add(Call(ring_2162, V.Undef, y1_2164, ((V)(RD0_2022)))).Spread(Invoke(Arr(((V)(0.25)), ((V)(0.5)), ((V)(0.72)), ((V)(0.9)), ((V)(1D))), "map", Fn((V _arrowThis2191, int _argc2184, V k_2190, V _a2187, V _a2188, V _a2189, V[] _rest2185) => {
return Call(ring_2162, V.Undef, Add(y1_2164, ((V)(((RD0_2022 * 0.8) * FdLibm.Sin(((ToNum(k_2190) * PI_14) / 2D)))))), ((V)((RD0_2022 * FdLibm.Cos((((ToNum(k_2190) * PI_14) / 2D) * 0.97))))));
}, 1, "", true))).V));
return ((V)(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(Call(pth_47, V.Undef, P_2165)), "\" fill=\"#dff4ff\" opacity=\"0.15\"/><path d=\"", ToStr(Call(pth_47, V.Undef, P_2165)), "\" fill=\"url(#m11gl)\" opacity=\"0.75\"/><path d=\"", ToStr(Call(pth_47, V.Undef, P_2165)), "\" fill=\"none\" stroke=\"#9ab5c0\" stroke-opacity=\"0.6\" stroke-width=\"0.35\"/>")).S(string.Concat("<g transform=\"", ToStr(Call(tanF_22, V.Undef, C_2039, ((V)(0D)), ((V)(0D)), ((V)((RD0_2022 + 0.05))), ((V)((ToNum(th_2040) - 0.7))), Add(y1_2164, ((V)(4D))))), "\"><rect x=\"-0.6\" width=\"1.2\" height=\"26\" rx=\"0.6\" fill=\"#ffffff\" opacity=\"0.45\"/></g>")).V(Call(band_66, V.Undef, C_2039, Arr(((V)(0D)), ((V)(0D)), ((V)(0D))), y0_2163, Add(y0_2163, ((V)(2D))), ((V)((RD0_2022 + 0.4))), ((V)("#d9dee3")), ((V)("chrome")))).V(Call(sph_20, V.Undef, C_2039, Arr(((V)(0D)), Add(Add(y1_2164, ((V)((RD0_2022 * 0.8)))), ((V)(1.4))), ((V)(0D))), ((V)(1.6)), ((V)("#d9dee3")))).End()));
return default;
}, 1, "", true);
if (!(Truthy(open_2019))) {
s_2041 = Add(s_2041, Call(dome_2048, V.Undef, ((V)(0D))));
} else {
s_2041 = Add(s_2041, Call(slide_53, V.Undef, C_2039, Call(dome_2048, V.Undef, ((V)(0D))), Arr(((V)(0D)), ((V)(Y_2021)), ((V)(0D))), Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(26D)), ((V)(0D)))), ((V)("0;1")), ((V)(0.9)), NewObj(1).Put("once", ((V)(1D))).V));
}
Call(ext_50, V.Undef, C_2039, Arr(Arr(((V)(0D)), ((V)((((Y_2021 + 26D) + 26D) + RD0_2022))), ((V)(0D)))));
return NewObj(3).Put("defs", Add(DEF11_49, defs_2042)).Put("front", s_2041).Put("bb", Invoke(C_2039, "bb", ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_2020;
return default;
}, 1, "", true));
Set(RD_8, "SET11", NewObj(12).Put("MOV-042", NewObj(2).Put("spec", ((V)("qled11"))).Put("note", ((V)("A razor-thin 85-inch QLED with a brushed-metal edge and a deep black glass screen that mirrors the room. An ambient backlight glows on the wall behind it, slowly drifting through blue, violet, pink, amber and teal."))).V).Put("MOV-046", NewObj(2).Put("spec", ((V)("ust11"))).Put("note", ((V)("A satin-white ultra-short-throw laser projector that sits right under the screen: charcoal fabric speaker front, glossy laser window on top with a soft light inside, touch buttons, a breathing status light and its remote beside it."))).V).Put("MOV-050", NewObj(2).Put("spec", ((V)("spk11"))).Put("note", ((V)("A walnut 5.1 kit: two bookshelf speakers on steel stands, two surround speakers on taller stands, a centre speaker and a black 10-inch subwoofer. Every driver has a real cone, surround and dust cap. Tap it to play music: all the cones pump to the beat."))).V).Put("MOV-051", Call(SHOW_68, V.Undef, ((V)("Start the kettle")), ((V)("Stop the kettle")), ((V)("Kettle stirring \u00b7 corn popping\u2026 tap to stop")), ((V)("Tap to pop kettle corn")), ((V)("A glossy red kettle-corn cart with spoked wagon wheels, a push handle, pinstriped panels, a striped awning and a glass cabinet piled with popcorn. Tap it: the heat lamp glows, the steel kettle rocks and popcorn flies out into the cabinet.")), NewObj(2).Put("spec", ((V)("kcart11"))).Put("sx", NewObj(0).V).V)).Put("MOV-054", Object_assign(NewObj(1).Put("spec", ((V)("cola11"))).V, Call(OPEN_67, V.Undef, ((V)("door")), ((V)("Door open \u00b7 ice cold \u00b7 tap to close")), ((V)("A glossy red retro mini-fridge on chrome legs with an \"Ice Cold COLA\" door, a chrome-framed glass window and a chrome bar handle. Inside you can see glass cola bottles on wire shelves and cans below. Tap it: the door swings open and cold mist rolls out. Tap again to close it."))))).Put("MOV-066", NewObj(2).Put("spec", ((V)("rig11"))).Put("note", ((V)("A commercial dual-lens 3D cinema projector on a rolling rack: graphite head with two big coated lenses and a red/blue 3D modulator between them, a spinning cooling fan behind the side grille, a status screen, a ribbed exhaust duct, carry rails and a rack of blinking media servers below."))).V).Put("MOV-070", NewObj(2).Put("spec", ((V)("tower11"))).Put("note", ((V)("Two piano-black tower speakers on brushed plinths with gold-ringed tweeters, copper cones and angled up-firing Atmos modules on top, two subwoofers and a wide centre speaker on top of them, plus a cyan floor glow. Tap it to play music: cones pump and the glow pulses."))).V).Put("MOV-071", Call(SHOW_68, V.Undef, ((V)("Serve nachos")), ((V)("Stop serving")), ((V)("Heat lamp on \u00b7 cheese pumping\u2026 tap to stop")), ((V)("Tap to serve nachos")), ((V)("A built-in concession bar: fluted walnut front, brass CONCESSIONS band, brass footrail and kick plate, a veined white marble top, a glass nacho warmer, a cheese pump over a tray of chips, striped cup stacks, straws and three candy jars. Tap it: the heat lamp glows, the pump presses and hot cheese pours onto the nachos.")), NewObj(2).Put("spec", ((V)("conc11"))).Put("sx", NewObj(0).V).V)).Put("MOV-074", Object_assign(NewObj(1).Put("spec", ((V)("wine11"))).V, Call(OPEN_67, V.Undef, ((V)("doors")), ((V)("Doors open \u00b7 cold air rolling\u2026 tap to close")), ((V)("An under-counter bar with a speckled quartz top: wine bottles on beech racks behind the left smoked-glass door, cans and juice bottles behind the right one, and a two-tank cherry / blue-razz slushie machine on top with augers always churning. Tap it: both doors swing open. Tap again to close them."))))).Put("MOV-091", Call(SHOW_68, V.Undef, ((V)("Order a snack")), ((V)("Stop the chef")), ((V)("Robot chef at work\u2026 tap to stop")), ((V)("Tap to order a snack")), ((V)("A glossy white AI snack kiosk: three candy tubes, a popcorn dome, a pick-up window, a touch screen and a white robot arm with a gripper. Tap it: candy drops into the cup, the arm swings round, scoops a striped bucket of popcorn and serves it, and the screen shows the progress.")), NewObj(2).Put("spec", ((V)("chef11"))).Put("live", ((V)("Tap to order"))).V)).Put("MOV-094", Object_assign(NewObj(1).Put("spec", ((V)("mock11"))).V, Call(OPEN_67, V.Undef, ((V)("dome")), ((V)("Dome open \u00b7 glass filling\u2026 tap to close")), ((V)("A white pedestal fountain with a cyan glow ring and three chrome taps under a glass dome. Inside, three flavour spheres float in orbit around a tall glass. Tap it: the dome rises, the spheres speed up, pearls drop into the glass and it fills with fizzy pink mocktail. Tap again to close it."))))).Put("MOV-102", Call(SHOW_68, V.Undef, ((V)("Start the carriage")), ((V)("Stop the carriage")), ((V)("Bulbs chasing \u00b7 kettle popping\u2026 tap to stop")), ((V)("Tap to start the carriage")), ((V)("A gilded royal popcorn carriage: burgundy panels with gold scrollwork and crowns, gold spoked wheels, twisted gold columns, a marquee roof and sign ringed with bulbs and a velvet crown on top. Tap it: the bulbs chase, the copper kettle rocks and popcorn bursts out.")), NewObj(2).Put("spec", ((V)("rcart11"))).Put("sx", NewObj(0).V).V)).V);
edit10_71 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis2199, int _argc2192, V rows_2198, V _a2195, V _a2196, V _a2197, V[] _rest2193) => {
return Invoke(Call(edit10_71, V.Undef, rows_2198), "map", Fn((V _arrowThis2207, int _argc2200, V r_2206, V _a2203, V _a2204, V _a2205, V[] _rest2201) => {
return (Truthy(GetK(Get(RD_8, "SET11"), Get(r_2206, "id"))) ? Object_assign(NewObj(0).V, r_2206, GetK(Get(RD_8, "SET11"), Get(r_2206, "id"))) : r_2206);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H11", NewObj(14).Put("DEF11", DEF11_49).Put("ext", ext_50).Put("zsort", zsort_51).Put("loopF", loopF_52).Put("pane", pane_54).Put("glassBox", glassBox_56).Put("woof", woof_57).Put("twt", twt_58).Put("baffle", baffle_59).Put("heap", heap_61).Put("chips", chips_63).Put("planeE", planeE_64).Put("OPEN", OPEN_67).Put("SHOW", SHOW_68).V);
Set(RD_8, "PLUS11", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
