// reno-plus6.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus6_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("play", "");
        public static void Run()
        {
Call(Named(boot_47 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V solid_11 = default;
V box_12 = default;
V cyl_13 = default;
V slab_14 = default;
V slabX_15 = default;
V disc_16 = default;
V f1_17 = default;
V rep_18 = default;
V rng_19 = default;
V n4_20 = default;
V P2_21 = default;
V plane_22 = default;
V planeX_23 = default;
V planeH_24 = default;
V an_25 = default;
V BLUR_26 = default;
V bbOf_27 = default;
V mt_28 = default;
V cer_29 = default;
V pt_30 = default;
V N_31 = default;
V CH_32 = default;
V isPlay_33 = default;
V G_34 = default;
V L_35 = default;
V once_36 = default;
V loopT_37 = default;
V pulse_38 = default;
V NOTE_39 = default;
V notes_40 = default;
V tube_41 = default;
V edit5_42 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((RD_8 is var _t43 && !Truthy(_t43) ? _t43 : Get(RD_8, "PLUS5")) is var _t44 && !Truthy(_t44) ? _t44 : Get(RD_8, "H3")) is var _t45 && !Truthy(_t45) ? _t45 : X_9) is var _t46 && !Truthy(_t46) ? _t46 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_47.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS6"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t48 = K_10;
if (_t48.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t48));
{ V _t49 = Get(_t48, "solid");
solid_11 = _t49; }
{ V _t50 = Get(_t48, "box");
box_12 = _t50; }
{ V _t51 = Get(_t48, "cyl");
cyl_13 = _t51; }
{ V _t52 = Get(_t48, "slab");
slab_14 = _t52; }
{ V _t53 = Get(_t48, "slabX");
slabX_15 = _t53; }
{ V _t54 = Get(_t48, "disc");
disc_16 = _t54; }
{ V _t55 = Get(_t48, "f1");
f1_17 = _t55; } }
{ V _t56 = Get(RD_8, "H3");
if (_t56.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t56));
{ V _t57 = Get(_t56, "rep");
rep_18 = _t57; }
{ V _t58 = Get(_t56, "rng");
rng_19 = _t58; }
{ V _t59 = Get(_t56, "n4");
n4_20 = _t59; }
{ V _t60 = Get(_t56, "P2");
P2_21 = _t60; }
{ V _t61 = Get(_t56, "plane");
plane_22 = _t61; }
{ V _t62 = Get(_t56, "planeX");
planeX_23 = _t62; }
{ V _t63 = Get(_t56, "planeH");
planeH_24 = _t63; }
{ V _t64 = Get(_t56, "an");
an_25 = _t64; }
{ V _t65 = Get(_t56, "BLUR");
BLUR_26 = _t65; }
{ V _t66 = Get(_t56, "bbOf");
bbOf_27 = _t66; }
{ V _t67 = Get(_t56, "mt");
mt_28 = _t67; }
{ V _t68 = Get(_t56, "cer");
cer_29 = _t68; }
{ V _t69 = Get(_t56, "pt");
pt_30 = _t69; } }
N_31 = Get(RD_8, "N");
CH_32 = ((V)("#d5dde2"));
isPlay_33 = Fn((V _arrowThis77, int _argc70, V S_76, V _a73, V _a74, V _a75, V[] _rest71) => {
return Invoke(NewRegExp(RX0, "play", ""), "test", (Get(S_76, "st") is var _t78 && Truthy(_t78) ? _t78 : ((V)(""))));
}, 1, "", true);
G_34 = Fn((V _arrowThis88, int _argc79, V id_85, V stops_86, V a_87, V _a84, V[] _rest80) => {
return ((V)(JsStrBuf.Begin().S("<radialGradient id=\"").V(id_85).S("\" ").V((a_87 is var _t89 && Truthy(_t89) ? _t89 : ((V)("cx=\"36%\" cy=\"32%\" r=\"72%\"")))).S(">").V(Invoke(Invoke(stops_86, "map", Fn((V _arrowThis97, int _argc90, V s_96, V _a93, V _a94, V _a95, V[] _rest91) => {
return ((V)(JsStrBuf.Begin().S("<stop offset=\"").V(GetIdx(s_96, 0D)).S("\" stop-color=\"").V(GetIdx(s_96, 1D)).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</radialGradient>").End()));
}, 3, "", true);
L_35 = Fn((V _arrowThis107, int _argc98, V id_104, V stops_105, V a_106, V _a103, V[] _rest99) => {
return ((V)(JsStrBuf.Begin().S("<linearGradient id=\"").V(id_104).S("\" ").V((a_106 is var _t108 && Truthy(_t108) ? _t108 : ((V)("x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"")))).S(">").V(Invoke(Invoke(stops_105, "map", Fn((V _arrowThis116, int _argc109, V s_115, V _a112, V _a113, V _a114, V[] _rest110) => {
return ((V)(JsStrBuf.Begin().S("<stop offset=\"").V(GetIdx(s_115, 0D)).S("\" stop-color=\"").V(GetIdx(s_115, 1D)).S("\"").S((!GetIdx(s_115, 2D).IsNullish ? JsStrBuf.Begin().S(" stop-opacity=\"").V(GetIdx(s_115, 2D)).S("\"").End() : "")).S("/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</linearGradient>").End()));
}, 3, "", true);
once_36 = Fn((V _arrowThis128, int _argc117, V type_123, V vals_124, V kt_125, V d_126, V[] _rest118) => {
V b_127 = default;
b_127 = (_argc117 > 4 ? _rest118[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"").V(type_123).S("\" values=\"").V(vals_124).S("\" keyTimes=\"").V(kt_125).S("\" dur=\"").V(d_126).S("s\"").S((Truthy(b_127) ? JsStrBuf.Begin().S(" begin=\"").V(b_127).S("s\"").End() : "")).S(" fill=\"freeze\"/>").End()));
}, 5, "", true);
loopT_37 = Fn((V _arrowThis139, int _argc129, V type_135, V vals_136, V d_137, V b_138, V[] _rest130) => {
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"").V(type_135).S("\" values=\"").V(vals_136).S("\" dur=\"").V(Call(n4_20, V.Undef, d_137)).S("s\"").S((Truthy(b_138) ? JsStrBuf.Begin().S(" begin=\"").V(Call(n4_20, V.Undef, b_138)).S("s\"").End() : "")).S(" repeatCount=\"indefinite\"/>").End()));
}, 4, "", true);
pulse_38 = Fn((V _arrowThis148, int _argc140, V d_146, V b_147, V _a144, V _a145, V[] _rest141) => {
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"scale\" values=\"1;1.07;1\" keyTimes=\"0;0.3;1\" calcMode=\"spline\" keySplines=\"0.2 0 0.4 1;0.45 0 0.55 1\" dur=\"").V(d_146).S("s\"").S((Truthy(b_147) ? JsStrBuf.Begin().S(" begin=\"").V(b_147).S("s\"").End() : "")).S(" repeatCount=\"indefinite\"/>").End()));
}, 2, "", true);
NOTE_39 = Fn((V _arrowThis156, int _argc149, V c_155, V _a152, V _a153, V _a154, V[] _rest150) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0V-7L5 -8.6V-1.6\" fill=\"none\" stroke=\"").V(c_155).S("\" stroke-width=\"1\"/><ellipse cx=\"-1.3\" cy=\"0.2\" rx=\"1.6\" ry=\"1.2\" fill=\"").V(c_155).S("\"/><ellipse cx=\"3.7\" cy=\"-1.4\" rx=\"1.6\" ry=\"1.2\" fill=\"").V(c_155).S("\"/>").End()));
}, 1, "", true);
notes_40 = Fn((V _arrowThis168, int _argc157, V o_163, V n_164, V k_165, V seed_166, V[] _rest158) => {
V b0_167 = default;
b0_167 = (_argc157 > 4 ? _rest158[0] : V.Undef);
return Invoke(Call(rep_18, V.Undef, n_164, Fn((V _arrowThis176, int _argc169, V i_175, V _a172, V _a173, V _a174, V[] _rest170) => {
V R2_177 = default;
double s_178 = 0;
double dx_179 = 0;
double dy_180 = 0;
V b_181 = default;
V c_182 = default;
R2_177 = Call(rng_19, V.Undef, Add(seed_166, i_175));
s_178 = (NumTruthy((ToNum(i_175) % 2D)) ? 1D : (-1D));
dx_179 = ((s_178 * (8D + (ToNum(Call(R2_177, V.Undef)) * 16D))) * ToNum(k_165));
dy_180 = ((-(34D + (ToNum(Call(R2_177, V.Undef)) * 22D))) * ToNum(k_165));
b_181 = Call(n4_20, V.Undef, ((V)((ToNum((b0_167 is var _t183 && Truthy(_t183) ? _t183 : ((V)(0D)))) - (ToNum(i_175) * 0.5)))));
c_182 = GetIdx(Arr(((V)("#3ff0ff")), ((V)("#ff4fb8")), ((V)("#ffe14f"))), (ToNum(i_175) % 3D));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_21, V.Undef, o_163)).S(")\"><animateTransform attributeName=\"transform\" type=\"translate\" values=\"").V(Call(P2_21, V.Undef, o_163)).S(";").V(Call(f1_17, V.Undef, Add(GetIdx(o_163, 0D), ((V)(dx_179))))).S(" ").V(Call(f1_17, V.Undef, Add(GetIdx(o_163, 1D), ((V)(dy_180))))).S("\" dur=\"2.4s\" begin=\"").V(b_181).S("s\" repeatCount=\"indefinite\"/>").V(Call(an_25, V.Undef, ((V)("opacity")), ((V)("0;1;1;0")), ((V)(2.4)), b_181)).S("<g transform=\"scale(").V(Call(n4_20, V.Undef, ((V)((ToNum(k_165) * 0.95))))).S(")\">").V(Call(NOTE_39, V.Undef, c_182)).S("</g></g>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
}, 5, "", true);
tube_41 = Fn((V _arrowThis195, int _argc184, V a_190, V b_191, V w_192, V k_193, V[] _rest185) => {
V d_196 = default;
V c_194 = default;
c_194 = (_argc184 > 4 ? _rest185[0] : V.Undef);
d_196 = ((V)(JsStrBuf.Begin().S("M").V(Call(P2_21, V.Undef, a_190)).S("L").V(Call(P2_21, V.Undef, b_191)).End()));
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(d_196).S("\" stroke=\"#0a0a0d\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)((ToNum(Add(w_192, ((V)(0.6)))) * ToNum(k_193)))))).S("\" stroke-linecap=\"round\"/><path d=\"").V(d_196).S("\" stroke=\"").V((c_194 is var _t197 && Truthy(_t197) ? _t197 : ((V)("#2c2e35")))).S("\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)((ToNum(w_192) * ToNum(k_193)))))).S("\" stroke-linecap=\"round\"/><path d=\"").V(d_196).S("\" stroke=\"#9aa1ad\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)(((ToNum(w_192) * 0.28) * ToNum(k_193)))))).S("\" stroke-linecap=\"round\" opacity=\"0.6\" transform=\"translate(").V(Call(f1_17, V.Undef, ((V)((((-0.22) * ToNum(w_192)) * ToNum(k_193)))))).S(" ").V(Call(f1_17, V.Undef, ((V)((((-0.22) * ToNum(w_192)) * ToNum(k_193)))))).S(")\"/>").End()));
return default;
}, 5, "", true);
Set(N_31, "boom80", Fn((V _arrowThis205, int _argc198, V S_204, V _a201, V _a202, V _a203, V[] _rest199) => {
V play_206 = default;
V BODY_207 = default;
V FAS_208 = default;
double IN_209 = 0;
V D_210 = default;
play_206 = Call(isPlay_33, V.Undef, S_204);
BODY_207 = ((V)("#c9cfd6"));
FAS_208 = ((V)("#1f2127"));
IN_209 = 1.4;
D_210 = NewObj(2).Put("w", ((V)(112D))).Put("d", ((V)(34D))).V;
Set(D_210, "build", Fn((V _arrowThis218, int _argc211, V P_217, V _a214, V _a215, V _a216, V[] _rest212) => {
V o_219 = default;
o_219 = Arr();
Invoke(Arr(Arr(((V)((-34D))), ((V)((-6D)))), Arr(((V)(34D)), ((V)((-6D)))), Arr(((V)((-34D))), ((V)(6D))), Arr(((V)(34D)), ((V)(6D)))), "forEach", Fn((V _arrowThis231, int _argc220, V _a222, V _a223, V _a224, V _a225, V[] _rest221) => {
V x_228 = default;
V z_230 = default;
{ V _t226 = ListOf(_a222);
{ V _t227 = GetIdx(_t226, 0D);
x_228 = _t227; }
{ V _t229 = GetIdx(_t226, 1D);
z_230 = _t229; }
}
return Invoke(o_219, "push", Call(box_12, V.Undef, x_228, ((V)(0D)), z_230, ((V)(6D)), ((V)(2D)), ((V)(4D)), ((V)("#141418")), Call(pt_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "", true));
Invoke(o_219, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)), ((V)(84D)), ((V)(46D)), ((V)(20D)), BODY_207, Call(mt_28, V.Undef, NewObj(2).Put("r", ((V)(4D))).Put("shine", ((V)(1D))).V)), Call(slab_14, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(10.05)), ((V)(80D)), ((V)(42D)), ((V)(0.6)), FAS_208, Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(2.5))).V)));
Invoke(Arr(((V)((-25D))), ((V)(25D))), "forEach", Fn((V _arrowThis239, int _argc232, V x_238, V _a235, V _a236, V _a237, V[] _rest233) => {
return Invoke(o_219, "push", Call(disc_16, V.Undef, x_238, ((V)(21D)), ((V)(10.7)), ((V)(13.4)), ((V)(1D)), CH_32, Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).V)), Call(disc_16, V.Undef, x_238, ((V)(21D)), ((V)(11.7)), ((V)(12D)), ((V)(0.4)), ((V)("#101115")), NewObj(1).Put("n", ((V)(28D))).V), Call(disc_16, V.Undef, x_238, ((V)(40.5)), ((V)(10.7)), ((V)(4.2)), ((V)(0.8)), CH_32, Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_219, "push", Call(slab_14, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(10.7)), ((V)(22D)), ((V)(22D)), ((V)(0.5)), ((V)("#2a2c33")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slab_14, V.Undef, ((V)(0D)), ((V)(32.6)), ((V)(10.7)), ((V)(22D)), ((V)(9.4)), ((V)(0.5)), ((V)("#0b0d12")), Call(cer_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis247, int _argc240, V i_246, V _a243, V _a244, V _a245, V[] _rest241) => {
double x_248 = 0;
V dn_249 = default;
x_248 = ((-13.75) + (ToNum(i_246) * 5.5));
dn_249 = (play_206 is var _t250 && !Truthy(_t250) ? _t250 : (SEqN(i_246, 1D) ? V.True : V.False));
Invoke(o_219, "push", Call(box_12, V.Undef, ((V)(x_248)), ((V)(48D)), ((V)(4.5)), ((V)(5D)), ((V)((Truthy(dn_249) ? 1D : 2.4))), ((V)(7D)), ((V)((SEqN(i_246, 1D) ? "#3a8f5a" : (SEqN(i_246, 0D) ? "#c93a3a" : "#2a2c33")))), Call(pt_30, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-24D))), ((V)(24D))), "forEach", Fn((V _arrowThis258, int _argc251, V x_257, V _a254, V _a255, V _a256, V[] _rest252) => {
return Invoke(o_219, "push", Call(cyl_13, V.Undef, x_257, ((V)(48D)), ((V)((-4.5))), ((V)(3D)), ((V)(2.4)), ((V)("#2a2c33")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_13, V.Undef, x_257, ((V)(50.4)), ((V)((-4.5))), ((V)(2.2)), ((V)(0.8)), CH_32, Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-34D))), ((V)(34D))), "forEach", Fn((V _arrowThis266, int _argc259, V x_265, V _a262, V _a263, V _a264, V[] _rest260) => {
return Invoke(o_219, "push", Call(cyl_13, V.Undef, x_265, ((V)(48D)), ((V)(0D)), ((V)(1.9)), ((V)(8D)), CH_32, Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_219, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(56.4)))).Put("a", ((V)(1.8))).Put("b", ((V)(1.8))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)((-35.5))), ((V)(0D))), Arr(((V)(35.5)), ((V)(0D))))).Put("col", CH_32).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(56.4)))).Put("a", ((V)(2.7))).Put("b", ((V)(2.7))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((-16D))), ((V)(0D))), Arr(((V)(16D)), ((V)(0D))))).Put("col", ((V)("#1d1e22"))).Put("mat", ((V)("metal"))).V));
Invoke(o_219, "push", Call(cyl_13, V.Undef, ((V)(38D)), ((V)(48D)), ((V)((-6D))), ((V)(1.7)), ((V)(2.2)), CH_32, Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)), Call(slabX_15, V.Undef, ((V)(42.1)), ((V)(8D)), ((V)(5D)), ((V)(0.5)), ((V)(8D)), ((V)(9D)), ((V)("#2a2c33")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
return o_219;
return default;
}, 1, "", true));
Set(D_210, "fx", Fn((V _arrowThis274, int _argc267, V c_273, V _a270, V _a271, V _a272, V[] _rest268) => {
V p_275 = default;
V k_276 = default;
JsStrBuf f_277 = null;
V un_278 = default;
JsStrBuf s_279 = null;
V door_280 = default;
V defs_281 = default;
p_275 = Get(c_273, "p");
k_276 = Get(c_273, "k");
f_277 = new JsStrBuf("");
un_278 = ((V)(""));
s_279 = new JsStrBuf("");
Invoke(Arr(((V)(15D)), ((V)(65D))), "forEach", Fn((V _arrowThis290, int _argc282, V cx_288, V i_289, V _a286, V _a287, V[] _rest283) => {
s_279.S("<g transform=\"translate(").V(cx_288).S(" 25)\"><g>").V((Truthy(play_206) ? Call(pulse_38, V.Undef, ((V)(0.5)), ((V)(IN_209))) : ((V)("")))).S("<circle r=\"12\" fill=\"#17181d\"/><circle r=\"11.3\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.5\" stroke-dasharray=\"9 62\" stroke-dashoffset=\"-46\" opacity=\"0.28\"/>").S("<circle r=\"10.4\" fill=\"url(#bxCone)\"/>").V(Invoke(Invoke(Arr(((V)(8.6)), ((V)(6.8))), "map", Fn((V _arrowThis298, int _argc291, V r_297, V _a294, V _a295, V _a296, V[] _rest292) => {
return ((V)(JsStrBuf.Begin().S("<circle r=\"").V(r_297).S("\" fill=\"none\" stroke=\"#2c2e36\" stroke-width=\"0.4\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M-7 -5.6A9 9 0 0 1 2 -8.8\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.7\" opacity=\"0.18\"/>").S("<circle r=\"3.6\" fill=\"url(#bxCap)\" stroke=\"#2a2c33\" stroke-width=\"0.3\"/><ellipse cx=\"-1.1\" cy=\"-1.3\" rx=\"1.3\" ry=\"0.8\" fill=\"#ffffff\" opacity=\"0.75\"/></g></g>");
s_279.S("<g transform=\"translate(").V(cx_288).S(" 5.5)\"><circle r=\"3.4\" fill=\"#141518\"/><circle r=\"2.6\" fill=\"url(#bxCap)\"/><ellipse cx=\"-0.8\" cy=\"-0.9\" rx=\"0.9\" ry=\"0.55\" fill=\"#ffffff\" opacity=\"0.7\"/></g>");
return default;
}, 2, "", true));
s_279.S("<rect x=\"29.6\" y=\"4.4\" width=\"20.8\" height=\"8.2\" rx=\"0.8\" fill=\"#0b0f1a\"/><text x=\"40\" y=\"7.4\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"1.7\" fill=\"#ffcf7a\" letter-spacing=\"0.25\">88  92  96  100  104  108</text>").V(Invoke(Call(rep_18, V.Undef, ((V)(21D)), Fn((V _arrowThis306, int _argc299, V i_305, V _a302, V _a303, V _a304, V[] _rest300) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_17, V.Undef, ((V)((31D + (ToNum(i_305) * 0.9)))))).S(" 8.1V").N((NumTruthy((ToNum(i_305) % 5D)) ? 8.6 : 9D)).S("\" stroke=\"#ffcf7a\" stroke-width=\"0.18\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M41.2 5V9.6\" stroke=\"#ff3b3b\" stroke-width=\"0.4\"/>").S("<text x=\"31\" y=\"11.8\" font-family=\"Arial, sans-serif\" font-weight=\"800\" font-size=\"1.3\" fill=\"").S((Truthy(play_206) ? "#ff5a4a" : "#5a3a3a")).S("\">FM STEREO</text>");
Call(rep_18, V.Undef, ((V)(8D)), Fn((V _arrowThis314, int _argc307, V i_313, V _a310, V _a311, V _a312, V[] _rest308) => {
V col_315 = default;
col_315 = ((V)((GtN(i_313, 6D) ? "#ff3b3b" : (GtN(i_313, 4D) ? "#ffd84f" : "#4dff7a"))));
s_279.S("<rect x=\"").V(Call(f1_17, V.Undef, ((V)((38.6 + (ToNum(i_313) * 1.4)))))).S("\" y=\"10.6\" width=\"1\" height=\"1.2\" rx=\"0.2\" fill=\"").V(col_315).S("\" opacity=\"").N((Truthy(play_206) ? 1D : 0.18)).S("\">").S((Truthy(play_206) ? JsStrBuf.Begin().S("<animate attributeName=\"opacity\" values=\"").V(Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis323, int _argc316, V t_322, V _a319, V _a320, V _a321, V[] _rest317) => {
return ((V)((Ge(((V)((((ToNum(t_322) * 5D) + (ToNum(i_313) * 3D)) % 8D))), i_313) ? 1D : 0.15)));
}, 1, "", true)), "join", ((V)(";")))).S("\" dur=\"0.5s\" calcMode=\"discrete\" repeatCount=\"indefinite\"/>").End() : "")).S("</rect>");
return default;
}, 1, "", true));
s_279.S("<text x=\"40\" y=\"15.2\" text-anchor=\"middle\" font-family=\"Arial Black, Arial, sans-serif\" font-weight=\"900\" font-style=\"italic\" font-size=\"2.3\" fill=\"url(#bxChr)\" letter-spacing=\"0.3\">SQUISH-BOX 2000</text>");
s_279.S("<rect x=\"29.4\" y=\"16.4\" width=\"21.2\" height=\"21.2\" rx=\"0.8\" fill=\"#0d0e12\"/><g clip-path=\"url(#bxWell)\"><g>").V((Truthy(play_206) ? Call(once_36, V.Undef, ((V)("translate")), ((V)("0 -18;0 -18;0 0;0 0")), ((V)("0;0.3;0.62;1")), ((V)(1.4))) : ((V)("")))).S("<rect x=\"30.6\" y=\"19\" width=\"18.8\" height=\"13.2\" rx=\"0.9\" fill=\"#26272e\" stroke=\"#0a0a0d\" stroke-width=\"0.3\"/>").S("<rect x=\"31.6\" y=\"19.8\" width=\"16.8\" height=\"3.8\" rx=\"0.4\" fill=\"#f2ead6\"/><path d=\"M31.6 22.2H48.4\" stroke=\"#e8343c\" stroke-width=\"0.6\"/><text x=\"32.4\" y=\"21.6\" font-family=\"Comic Sans MS, Marker Felt, cursive\" font-weight=\"700\" font-size=\"1.5\" fill=\"#2a2a30\">PARTY MIX</text>").S("<rect x=\"34\" y=\"24.6\" width=\"12\" height=\"5\" rx=\"2.4\" fill=\"#100f14\"/>");
Invoke(Arr(Arr(((V)(36.6)), ((V)(3D))), Arr(((V)(43.4)), ((V)(2.2)))), "forEach", Fn((V _arrowThis336, int _argc324, V _a326, V i_330, V _a328, V _a329, V[] _rest325) => {
V x_333 = default;
V r_335 = default;
{ V _t331 = ListOf(_a326);
{ V _t332 = GetIdx(_t331, 0D);
x_333 = _t332; }
{ V _t334 = GetIdx(_t331, 1D);
r_335 = _t334; }
}
s_279.S("<circle cx=\"").V(x_333).S("\" cy=\"27.1\" r=\"").V(r_335).S("\" fill=\"#4a3424\"/><g transform=\"translate(").V(x_333).S(" 27.1)\"><g>").V((Truthy(play_206) ? Call(loopT_37, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)((Truthy(i_330) ? 1.4 : 1.9))), ((V)(IN_209))) : ((V)("")))).S("<circle r=\"1.25\" fill=\"#f4f6f8\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis344, int _argc337, V j_343, V _a340, V _a341, V _a342, V[] _rest338) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"-0.18\" y=\"-1.25\" width=\"0.36\" height=\"0.5\" fill=\"#26272e\" transform=\"rotate(").N((ToNum(j_343) * 60D)).S(")\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<circle r=\"0.4\" fill=\"#26272e\"/></g></g>");
return default;
}, 2, "", true));
s_279.S("<path d=\"M33 32.2L34 30.6H46L47 32.2Z\" fill=\"#1d1e24\"/></g></g>");
door_280 = ((V)(string.Concat("<rect x=\"29.8\" y=\"16.8\" width=\"20.4\" height=\"20.6\" rx=\"0.8\" fill=\"#9fb4c8\" fill-opacity=\"0.16\" stroke=\"url(#bxChr)\" stroke-width=\"0.6\"/><path d=\"M31 18.2L37 18.2L31 26Z\" fill=\"#ffffff\" opacity=\"0.12\"/><rect x=\"33.4\" y=\"24\" width=\"13.2\" height=\"6.2\" rx=\"0.6\" fill=\"none\" stroke=\"#d5dde2\" stroke-width=\"0.25\" opacity=\"0.6\"/>", "<text x=\"40\" y=\"36.4\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"800\" font-size=\"1.25\" fill=\"#c9cdd2\" letter-spacing=\"0.4\">AUTO REVERSE</text><rect x=\"37.6\" y=\"16.8\" width=\"4.8\" height=\"0.9\" rx=\"0.3\" fill=\"url(#bxChr)\"/>")));
s_279.S("<g transform=\"translate(0 37.4)\"><g>").V((Truthy(play_206) ? Call(once_36, V.Undef, ((V)("scale")), ((V)("1 1;1 0.16;1 0.16;1 1")), ((V)("0;0.26;0.66;1")), ((V)(1.4))) : ((V)("")))).S("<g transform=\"translate(0 -37.4)\">").V(door_280).S("</g></g></g>");
Invoke(Arr(Arr(((V)(2.2)), ((V)(2.2))), Arr(((V)(77.8)), ((V)(2.2))), Arr(((V)(2.2)), ((V)(39.8))), Arr(((V)(77.8)), ((V)(39.8)))), "forEach", Fn((V _arrowThis356, int _argc345, V _a347, V _a348, V _a349, V _a350, V[] _rest346) => {
V x_353 = default;
V y_355 = default;
{ V _t351 = ListOf(_a347);
{ V _t352 = GetIdx(_t351, 0D);
x_353 = _t352; }
{ V _t354 = GetIdx(_t351, 1D);
y_355 = _t354; }
}
return ((V)(s_279.S("<circle cx=\"").V(x_353).S("\" cy=\"").V(y_355).S("\" r=\"0.55\" fill=\"url(#bxCap)\"/>").Str));
}, 1, "", true));
f_277.S("<g transform=\"").V(Call(plane_22, V.Undef, p_275, ((V)(10.95)), ((V)(46D)), ((V)((-40D))))).S("\">").S(s_279.Str).S("</g>");
{
JsStrBuf t_357 = null;
t_357 = new JsStrBuf("");
Invoke(Arr(((V)("\u25cf")), ((V)("\u25b6")), ((V)("\u25c0\u25c0")), ((V)("\u25b6\u25b6")), ((V)("\u25a0")), ((V)("\u23cf"))), "forEach", Fn((V _arrowThis366, int _argc358, V g2_364, V i_365, V _a362, V _a363, V[] _rest359) => {
return ((V)(t_357.S("<text x=\"").V(Call(f1_17, V.Undef, ((V)((26.25 + (ToNum(i_365) * 5.5)))))).S("\" y=\"0.9\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"800\" font-size=\"1.7\" fill=\"#f4f6f8\">").V(g2_364).S("</text>").Str));
}, 2, "", true));
f_277.S("<g transform=\"").V(Call(planeH_24, V.Undef, p_275, ((V)((Truthy(play_206) ? 49.1 : 50.5))), ((V)((-40D))), ((V)(4.5)))).S("\">").S(t_357.Str).S("</g>");
}
{
V a_367 = default;
V b_368 = default;
V cc_369 = default;
V d_370 = default;
a_367 = Call(p_275, V.Undef, ((V)(38D)), ((V)(50.2)), ((V)((-6D))));
b_368 = Call(p_275, V.Undef, ((V)(45D)), ((V)(68D)), ((V)((-9D))));
cc_369 = Call(p_275, V.Undef, ((V)(51D)), ((V)(84D)), ((V)((-11.5))));
d_370 = Call(p_275, V.Undef, ((V)(56D)), ((V)(98D)), ((V)((-13.5))));
f_277.S("<path d=\"M").V(Call(P2_21, V.Undef, a_367)).S("L").V(Call(P2_21, V.Undef, b_368)).S("\" stroke=\"#6a6f7a\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)((1.5 * ToNum(k_276)))))).S("\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_21, V.Undef, a_367)).S("L").V(Call(P2_21, V.Undef, b_368)).S("\" stroke=\"").V(CH_32).S("\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)((1.1 * ToNum(k_276)))))).S("\" stroke-linecap=\"round\"/>").S("<path d=\"M").V(Call(P2_21, V.Undef, b_368)).S("L").V(Call(P2_21, V.Undef, cc_369)).S("\" stroke=\"").V(CH_32).S("\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)((0.8 * ToNum(k_276)))))).S("\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_21, V.Undef, cc_369)).S("L").V(Call(P2_21, V.Undef, d_370)).S("\" stroke=\"").V(CH_32).S("\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)((0.55 * ToNum(k_276)))))).S("\" stroke-linecap=\"round\"/><circle cx=\"").V(Call(f1_17, V.Undef, GetIdx(d_370, 0D))).S("\" cy=\"").V(Call(f1_17, V.Undef, GetIdx(d_370, 1D))).S("\" r=\"").V(Call(f1_17, V.Undef, ((V)((1D * ToNum(k_276)))))).S("\" fill=\"url(#bxCap)\"/>");
}
{
V j0_371 = default;
V j1_372 = default;
V j2_373 = default;
V fl_374 = default;
V mid_375 = default;
JsStrBuf cl_376 = null;
j0_371 = Call(p_275, V.Undef, ((V)(42.4)), ((V)(12D)), ((V)(7D)));
j1_372 = Call(p_275, V.Undef, ((V)(45.2)), ((V)(12D)), ((V)(7D)));
j2_373 = Call(p_275, V.Undef, ((V)(49.4)), ((V)(12D)), ((V)(7D)));
fl_374 = Call(p_275, V.Undef, ((V)(55.6)), ((V)(0.6)), ((V)(9D)));
mid_375 = Call(p_275, V.Undef, ((V)(53D)), ((V)(6D)), ((V)(8D)));
f_277.S("<path d=\"M").V(Call(P2_21, V.Undef, j2_373)).S("Q").V(Call(P2_21, V.Undef, mid_375)).S(" ").V(Call(P2_21, V.Undef, fl_374)).S("\" fill=\"none\" stroke=\"#141418\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)((1.3 * ToNum(k_276)))))).S("\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_21, V.Undef, j2_373)).S("Q").V(Call(P2_21, V.Undef, mid_375)).S(" ").V(Call(P2_21, V.Undef, fl_374)).S("\" fill=\"none\" stroke=\"#5a5f6a\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)((0.35 * ToNum(k_276)))))).S("\" stroke-linecap=\"round\" transform=\"translate(").V(Call(f1_17, V.Undef, ((V)(((-0.3) * ToNum(k_276)))))).S(" ").V(Call(f1_17, V.Undef, ((V)(((-0.3) * ToNum(k_276)))))).S(")\"/>").S("<path d=\"M").V(Call(P2_21, V.Undef, j0_371)).S("L").V(Call(P2_21, V.Undef, j1_372)).S("\" stroke=\"url(#bxCapL)\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)((1.3 * ToNum(k_276)))))).S("\" stroke-linecap=\"butt\"/><path d=\"M").V(Call(P2_21, V.Undef, j1_372)).S("L").V(Call(P2_21, V.Undef, j2_373)).S("\" stroke=\"#1d1e22\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)((2.3 * ToNum(k_276)))))).S("\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_21, V.Undef, j1_372)).S("L").V(Call(P2_21, V.Undef, j2_373)).S("\" stroke=\"#4a4d58\" stroke-width=\"").V(Call(f1_17, V.Undef, ((V)((0.5 * ToNum(k_276)))))).S("\" stroke-linecap=\"round\" transform=\"translate(0 ").V(Call(f1_17, V.Undef, ((V)(((-0.6) * ToNum(k_276)))))).S(")\"/>");
cl_376 = new JsStrBuf("");
Invoke(Arr(((V)(7.6)), ((V)(5.9)), ((V)(4.2))), "forEach", Fn((V _arrowThis384, int _argc377, V r_383, V _a380, V _a381, V _a382, V[] _rest378) => {
return ((V)(cl_376.S("<circle r=\"").V(r_383).S("\" fill=\"none\" stroke=\"#141418\" stroke-width=\"1.1\"/><circle r=\"").V(r_383).S("\" fill=\"none\" stroke=\"#6a6f7c\" stroke-width=\"0.32\" stroke-dasharray=\"").V(Call(f1_17, V.Undef, ((V)((ToNum(r_383) * 1.6))))).S(" ").V(Call(f1_17, V.Undef, ((V)((ToNum(r_383) * 4.7))))).S("\" stroke-dashoffset=\"").V(Call(f1_17, V.Undef, ((V)((ToNum(r_383) * 3.2))))).S("\"/>").Str));
}, 1, "", true));
cl_376.S("<rect x=\"-1.4\" y=\"3.4\" width=\"2.8\" height=\"5\" rx=\"0.5\" fill=\"#e8343c\" stroke=\"#8a1a24\" stroke-width=\"0.3\"/><path d=\"M-1.4 5.9H1.4\" stroke=\"#ffffff\" stroke-width=\"0.3\" opacity=\"0.5\"/><path d=\"M-2.6 -2.2L-0.8 -0.6\" stroke=\"url(#bxCapL)\" stroke-width=\"1.1\"/><path d=\"M-4 -3.4L-2.6 -2.2\" stroke=\"#1d1e22\" stroke-width=\"1.9\"/>");
f_277.S("<g transform=\"").V(Call(planeH_24, V.Undef, p_275, ((V)(0.6)), ((V)(62.6)), ((V)(9D)))).S("\">").S(cl_376.Str).S("</g>");
}
if (Truthy(play_206)) {
Invoke(Arr(((V)((-25D))), ((V)(25D))), "forEach", Fn((V _arrowThis393, int _argc385, V x_391, V i_392, V _a389, V _a390, V[] _rest386) => {
f_277.S("<g transform=\"").V(Call(plane_22, V.Undef, p_275, ((V)(11.4)), ((V)(21D)), x_391)).S("\">").V(Invoke(Call(rep_18, V.Undef, ((V)(2D)), Fn((V _arrowThis401, int _argc394, V j_400, V _a397, V _a398, V _a399, V[] _rest395) => {
return ((V)(JsStrBuf.Begin().S("<circle r=\"13\" fill=\"none\" stroke=\"").S((Truthy(i_392) ? "#ff4fb8" : "#3ff0ff")).S("\" stroke-width=\"0.8\" opacity=\"0\">").S("<animate attributeName=\"r\" values=\"13;26\" dur=\"1s\" begin=\"").V(Call(n4_20, V.Undef, ((V)((IN_209 + (ToNum(j_400) * 0.5)))))).S("s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.75;0\" dur=\"1s\" begin=\"").V(Call(n4_20, V.Undef, ((V)((IN_209 + (ToNum(j_400) * 0.5)))))).S("s\" repeatCount=\"indefinite\"/></circle>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
return default;
}, 2, "", true));
f_277.V(Call(notes_40, V.Undef, Call(p_275, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(6D))), ((V)(5D)), k_276, ((V)("bx")), ((V)(IN_209))));
}
defs_281 = ((V)(JsStrBuf.Begin().V(Add(Add(Add(Call(G_34, V.Undef, ((V)("bxCone")), Arr(Arr(((V)(0D)), ((V)("#4a4d58"))), Arr(((V)(0.55)), ((V)("#1f2027"))), Arr(((V)(1D)), ((V)("#0a0a0d")))), ((V)("cx=\"38%\" cy=\"34%\" r=\"70%\""))), Call(G_34, V.Undef, ((V)("bxCap")), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(0.45)), ((V)("#c9cfd6"))), Arr(((V)(1D)), ((V)("#4a4f58")))))), Call(L_35, V.Undef, ((V)("bxCapL")), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(0.5)), ((V)("#c9cfd6"))), Arr(((V)(1D)), ((V)("#6a6f7a")))))), Call(L_35, V.Undef, ((V)("bxChr")), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(0.45)), ((V)("#c9cfd6"))), Arr(((V)(0.55)), ((V)("#8a919c"))), Arr(((V)(1D)), ((V)("#e8edf2"))))))).S("<clipPath id=\"bxWell\"><rect x=\"29.4\" y=\"16.4\" width=\"21.2\" height=\"21.2\"/></clipPath>").End()));
return NewObj(4).Put("defs", defs_281).Put("under", un_278).Put("front", ((V)(f_277.Str))).Put("bb", Call(bbOf_27, V.Undef, Invoke(Arr(Call(p_275, V.Undef, ((V)((-44D))), ((V)(0D)), ((V)(12D))), Call(p_275, V.Undef, ((V)(44D)), ((V)(0D)), ((V)(12D))), Call(p_275, V.Undef, ((V)((-44D))), ((V)(60D)), ((V)((-11D)))), Call(p_275, V.Undef, ((V)(44D)), ((V)(60D)), ((V)((-11D)))), Call(p_275, V.Undef, ((V)(58D)), ((V)(100D)), ((V)((-14D)))), Call(p_275, V.Undef, ((V)(72D)), ((V)(0D)), ((V)(18D))), Call(p_275, V.Undef, ((V)(72D)), ((V)(0D)), ((V)(0D))), Call(p_275, V.Undef, ((V)(56D)), ((V)(0D)), ((V)((-2D))))), "concat", (Truthy(play_206) ? Arr(Call(p_275, V.Undef, ((V)((-30D))), ((V)(112D)), ((V)(6D))), Call(p_275, V.Undef, ((V)(30D)), ((V)(112D)), ((V)(6D))), Call(p_275, V.Undef, ((V)((-52D))), ((V)(21D)), ((V)(12D))), Call(p_275, V.Undef, ((V)(52D)), ((V)(21D)), ((V)(12D)))) : Arr())), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_210;
return default;
}, 1, "", true));
Set(N_31, "paPro", Fn((V _arrowThis409, int _argc402, V S_408, V _a405, V _a406, V _a407, V[] _rest403) => {
V play_410 = default;
double HUB_411 = 0;
V FEET_412 = default;
V KN_413 = default;
V D_414 = default;
play_410 = Call(isPlay_33, V.Undef, S_408);
HUB_411 = 33D;
FEET_412 = Invoke(Arr(((V)(90D)), ((V)(210D)), ((V)(330D))), "map", Fn((V _arrowThis422, int _argc415, V a_421, V _a418, V _a419, V _a420, V[] _rest416) => {
return Arr(((V)((24D * FdLibm.Cos(((ToNum(a_421) * System.Math.PI) / 180D))))), ((V)(0D)), ((V)((24D * FdLibm.Sin(((ToNum(a_421) * System.Math.PI) / 180D))))));
}, 1, "", true));
KN_413 = Arr(Arr(((V)((-8D))), ((V)(136D)), ((V)(2.3)), ((V)("VOL")), ((V)((Truthy(play_410) ? 70D : (-60D))))), Arr(((V)((-1.5))), ((V)(136D)), ((V)(2.3)), ((V)("GAIN")), ((V)(20D))), Arr(((V)(5D)), ((V)(136D)), ((V)(2.3)), ((V)("MIC")), ((V)((-30D)))), Arr(((V)((-8D))), ((V)(126.6)), ((V)(1.6)), ((V)("HI")), ((V)(0D))), Arr(((V)((-3.2))), ((V)(126.6)), ((V)(1.6)), ((V)("MID")), ((V)(10D))), Arr(((V)(1.6)), ((V)(126.6)), ((V)(1.6)), ((V)("LO")), ((V)(35D))));
D_414 = NewObj(2).Put("w", ((V)(56D))).Put("d", ((V)(54D))).V;
Set(D_414, "build", Fn((V _arrowThis430, int _argc423, V P_429, V _a426, V _a427, V _a428, V[] _rest424) => {
V o_431 = default;
o_431 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(1.9)), ((V)(60D)), ((V)("#23252b")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(3.4)), ((V)(6D)), ((V)("#1a1b20")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(15D)), ((V)(0D)), ((V)(2.6)), ((V)(2.4)), ((V)("#1a1b20")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(68D)), ((V)(0D)), ((V)(2.8)), ((V)(4D)), ((V)("#1a1b20")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(box_12, V.Undef, ((V)(4.2)), ((V)(69D)), ((V)(0D)), ((V)(3.4)), ((V)(1.8)), ((V)(1.8)), ((V)("#2a2c33")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(72D)), ((V)(0D)), ((V)(1.4)), ((V)(22D)), CH_32, Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(94D)), ((V)(0D)), ((V)(3.2)), ((V)(3D)), ((V)("#1a1b20")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)));
Invoke(o_431, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(97D)), ((V)(0D)), ((V)(36D)), ((V)(56D)), ((V)(30D)), ((V)("#1b1c21")), Call(pt_30, V.Undef, NewObj(1).Put("r", ((V)(4D))).V)), Call(slab_14, V.Undef, ((V)(0D)), ((V)(99.5)), ((V)(15.15)), ((V)(33D)), ((V)(51D)), ((V)(0.7)), ((V)("#2c2e35")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(153D)), ((V)((-3D))), ((V)(18D)), ((V)(2.6)), ((V)(7D)), ((V)("#26272d")), Call(pt_30, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)), Call(slabX_15, V.Undef, ((V)(18.2)), ((V)(106D)), ((V)((-1D))), ((V)(0.6)), ((V)(38D)), ((V)(24D)), ((V)("#2a2c33")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1.6))).V)));
Invoke(KN_413, "forEach", Fn((V _arrowThis445, int _argc432, V _a434, V _a435, V _a436, V _a437, V[] _rest433) => {
V z_440 = default;
V y_442 = default;
V r_444 = default;
{ V _t438 = ListOf(_a434);
{ V _t439 = GetIdx(_t438, 0D);
z_440 = _t439; }
{ V _t441 = GetIdx(_t438, 1D);
y_442 = _t441; }
{ V _t443 = GetIdx(_t438, 2D);
r_444 = _t443; }
}
return Invoke(o_431, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(z_440, y_442)).Put("a", r_444).Put("b", r_444).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)(18.5)), ((V)(0D))), Arr(Add(((V)(18.5)), r_444), ((V)(0D)), ((V)(0.9))))).Put("col", ((V)("#16171c"))).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V));
}, 1, "", true));
Invoke(o_431, "push", Call(slabX_15, V.Undef, ((V)(18.6)), ((V)(108.4)), ((V)(6.4)), ((V)(0.8)), ((V)(3.4)), ((V)(2.2)), ((V)("#16171c")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
return o_431;
return default;
}, 1, "", true));
Set(D_414, "fx", Fn((V _arrowThis453, int _argc446, V c_452, V _a449, V _a450, V _a451, V[] _rest447) => {
V p_454 = default;
V k_455 = default;
JsStrBuf f_456 = null;
JsStrBuf bk_457 = null;
JsStrBuf un_458 = null;
V hub_459 = default;
V legs_460 = default;
V g_461 = default;
V defs_462 = default;
p_454 = Get(c_452, "p");
k_455 = Get(c_452, "k");
f_456 = new JsStrBuf("");
bk_457 = new JsStrBuf("");
un_458 = new JsStrBuf("");
hub_459 = Call(p_454, V.Undef, ((V)(0D)), ((V)(HUB_411)), ((V)(0D)));
legs_460 = Invoke(FEET_412, "map", Fn((V _arrowThis470, int _argc463, V q_469, V _a466, V _a467, V _a468, V[] _rest464) => {
V ft_471 = default;
V br_472 = default;
ft_471 = CallSpread(p_454, V.Undef, new ArrBuilder().Spread(q_469).V);
br_472 = Call(p_454, V.Undef, ((V)((ToNum(GetIdx(q_469, 0D)) * 0.55))), ((V)(14.9)), ((V)((ToNum(GetIdx(q_469, 2D)) * 0.55))));
return NewObj(2).Put("front", (GtN(GetIdx(q_469, 2D), 0D) ? V.True : V.False)).Put("s", ((V)(JsStrBuf.Begin().V(Add(Call(tube_41, V.Undef, hub_459, ft_471, ((V)(1.7)), k_455), Call(tube_41, V.Undef, Call(p_454, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D))), br_472, ((V)(1D)), k_455))).S("<ellipse cx=\"").V(Call(f1_17, V.Undef, GetIdx(ft_471, 0D))).S("\" cy=\"").V(Call(f1_17, V.Undef, Add(GetIdx(ft_471, 1D), ((V)((0.4 * ToNum(k_455))))))).S("\" rx=\"").V(Call(f1_17, V.Undef, ((V)((2.6 * ToNum(k_455)))))).S("\" ry=\"").V(Call(f1_17, V.Undef, ((V)((1.2 * ToNum(k_455)))))).S("\" fill=\"#0c0c0f\"/>").End()))).V;
return default;
}, 1, "", true));
Invoke(legs_460, "forEach", Fn((V _arrowThis480, int _argc473, V l_479, V _a476, V _a477, V _a478, V[] _rest474) => {
if (Truthy(Get(l_479, "front"))) {
f_456.V(Get(l_479, "s"));
} else {
bk_457.V(Get(l_479, "s"));
}
return default;
}, 1, "", true));
g_461 = ((V)(JsStrBuf.Begin().S("<rect x=\"0.4\" y=\"0.4\" width=\"32.2\" height=\"50.2\" rx=\"2.4\" fill=\"#26282e\"/><path d=\"M6 4.6H27L21.4 15.4H11.6Z\" fill=\"#121317\" stroke=\"#34363e\" stroke-width=\"0.4\"/><ellipse cx=\"16.5\" cy=\"7.6\" rx=\"2.4\" ry=\"1.4\" fill=\"#0a0a0d\"/>").S("<g transform=\"translate(16.5 34)\"><g>").V((Truthy(play_410) ? Call(pulse_38, V.Undef, ((V)(0.5))) : ((V)("")))).S("<circle r=\"13\" fill=\"#141519\"/><circle r=\"12.2\" fill=\"none\" stroke=\"#3a3c44\" stroke-width=\"0.6\"/><circle r=\"9.6\" fill=\"url(#paCone)\"/><circle r=\"3.4\" fill=\"#2a2c33\"/></g></g>").S("<rect x=\"0.4\" y=\"0.4\" width=\"32.2\" height=\"50.2\" rx=\"2.4\" fill=\"url(#paHole)\"/><rect x=\"0.4\" y=\"0.4\" width=\"32.2\" height=\"50.2\" rx=\"2.4\" fill=\"url(#paGl)\"/><rect x=\"0.4\" y=\"0.4\" width=\"32.2\" height=\"50.2\" rx=\"2.4\" fill=\"none\" stroke=\"#4a4d58\" stroke-width=\"0.5\"/>").S("<rect x=\"21.4\" y=\"45.6\" width=\"9.6\" height=\"3.2\" rx=\"0.6\" fill=\"url(#paChr)\"/><text x=\"26.2\" y=\"47.9\" text-anchor=\"middle\" font-family=\"Arial Black, Arial, sans-serif\" font-weight=\"900\" font-size=\"1.7\" fill=\"#1d1e22\" letter-spacing=\"0.2\">SQUISH</text>").S("<circle cx=\"4.2\" cy=\"47.3\" r=\"2.2\" fill=\"#4dff7a\" opacity=\"0.55\" filter=\"url(#paB)\"/><circle cx=\"4.2\" cy=\"47.3\" r=\"0.85\" fill=\"#c8ffd6\" stroke=\"#2a9a4a\" stroke-width=\"0.25\"/>").End()));
f_456.S("<g transform=\"").V(Call(plane_22, V.Undef, p_454, ((V)(15.95)), ((V)(150.5)), ((V)((-16.5))))).S("\">").V(g_461).S("</g>");
f_456.S("<g transform=\"").V(Call(planeX_23, V.Undef, p_454, ((V)(18.55)), ((V)(142.4)), ((V)((-12D))))).S("\"><text x=\"0\" y=\"0\" font-family=\"Arial, sans-serif\" font-weight=\"800\" font-size=\"1.4\" fill=\"#c9cdd2\" letter-spacing=\"0.3\">ACTIVE 2-WAY \u00b7 400W</text></g>");
Invoke(Arr(Arr(((V)((-7D))), ((V)(117D))), Arr(((V)(0.5)), ((V)(117D)))), "forEach", Fn((V _arrowThis492, int _argc481, V _a483, V _a484, V _a485, V _a486, V[] _rest482) => {
V z_489 = default;
V y_491 = default;
{ V _t487 = ListOf(_a483);
{ V _t488 = GetIdx(_t487, 0D);
z_489 = _t488; }
{ V _t490 = GetIdx(_t487, 1D);
y_491 = _t490; }
}
return ((V)(f_456.S("<g transform=\"").V(Call(planeX_23, V.Undef, p_454, ((V)(18.55)), y_491, z_489)).S("\"><circle r=\"2.7\" fill=\"#0c0c10\" stroke=\"#9aa1ad\" stroke-width=\"0.35\"/><circle r=\"1.6\" fill=\"#1d1e24\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis500, int _argc493, V i_499, V _a496, V _a497, V _a498, V[] _rest494) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_17, V.Undef, ((V)((FdLibm.Cos(((ToNum(i_499) * 2.1) - 1.6)) * 0.95))))).S("\" cy=\"").V(Call(f1_17, V.Undef, ((V)((FdLibm.Sin(((ToNum(i_499) * 2.1) - 1.6)) * 0.95))))).S("\" r=\"0.3\" fill=\"#9aa1ad\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>").Str));
}, 1, "", true));
f_456.S("<g transform=\"").V(Call(planeX_23, V.Undef, p_454, ((V)(19.45)), ((V)(111.8)), ((V)(6.4)))).S("\"><text x=\"0\" y=\"2.8\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"800\" font-size=\"1\" fill=\"#c9cdd2\">I</text><rect x=\"-1\" y=\"0.2\" width=\"2\" height=\"1.4\" fill=\"#e8343c\" opacity=\"0.85\"/></g>");
Invoke(KN_413, "forEach", Fn((V _arrowThis519, int _argc501, V _a503, V i_507, V _a505, V _a506, V[] _rest502) => {
V t_520 = default;
V cap_521 = default;
V z_510 = default;
V y_512 = default;
V r_514 = default;
V lab_516 = default;
V ang_518 = default;
{ V _t508 = ListOf(_a503);
{ V _t509 = GetIdx(_t508, 0D);
z_510 = _t509; }
{ V _t511 = GetIdx(_t508, 1D);
y_512 = _t511; }
{ V _t513 = GetIdx(_t508, 2D);
r_514 = _t513; }
{ V _t515 = GetIdx(_t508, 3D);
lab_516 = _t515; }
{ V _t517 = GetIdx(_t508, 4D);
ang_518 = _t517; }
}
t_520 = Invoke(Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis529, int _argc522, V j_528, V _a525, V _a526, V _a527, V[] _rest523) => {
double q_530 = 0;
double s0_531 = 0;
double c0_532 = 0;
q_530 = ((((-135D) + (ToNum(j_528) * 45D)) * System.Math.PI) / 180D);
s0_531 = FdLibm.Sin(q_530);
c0_532 = (-FdLibm.Cos(q_530));
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_17, V.Undef, ((V)((s0_531 * ToNum(Add(r_514, ((V)(0.6))))))))).S(" ").V(Call(f1_17, V.Undef, ((V)((c0_532 * ToNum(Add(r_514, ((V)(0.6))))))))).S("L").V(Call(f1_17, V.Undef, ((V)((s0_531 * ToNum(Add(r_514, ((V)(1.2))))))))).S(" ").V(Call(f1_17, V.Undef, ((V)((c0_532 * ToNum(Add(r_514, ((V)(1.2))))))))).S("\" stroke=\"#c9cdd2\" stroke-width=\"0.25\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
t_520 = ((V)(JsStrBuf.Begin().V(t_520).S("<text x=\"0\" y=\"").V(Call(f1_17, V.Undef, Add(r_514, ((V)(2.6))))).S("\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"800\" font-size=\"1.15\" fill=\"#c9cdd2\">").V(lab_516).S("</text>").End()));
f_456.S("<g transform=\"").V(Call(planeX_23, V.Undef, p_454, ((V)(18.55)), y_512, z_510)).S("\">").V(t_520).S("</g>");
cap_521 = ((V)(JsStrBuf.Begin().S("<circle r=\"").V(Call(f1_17, V.Undef, ((V)((ToNum(r_514) * 0.86))))).S("\" fill=\"url(#paKnob)\"/><g transform=\"rotate(").V((Truthy(((SEqN(i_507, 0D) ? V.True : V.False) is var _t533 && !Truthy(_t533) ? _t533 : play_410)) ? ((V)((-60D))) : ang_518)).S(")\">").V((Truthy(((SEqN(i_507, 0D) ? V.True : V.False) is var _t534 && !Truthy(_t534) ? _t534 : play_410)) ? Call(once_36, V.Undef, ((V)("rotate")), ((V)("-60;-60;70")), ((V)("0;0.35;1")), ((V)(0.9))) : ((V)("")))).S("<path d=\"M0 ").V(Call(f1_17, V.Undef, ((V)(((-ToNum(r_514)) * 0.25))))).S("V").V(Call(f1_17, V.Undef, ((V)(((-ToNum(r_514)) * 0.82))))).S("\" stroke=\"#f4f6f8\" stroke-width=\"0.45\" stroke-linecap=\"round\"/></g>").End()));
f_456.S("<g transform=\"").V(Call(planeX_23, V.Undef, p_454, Add(Add(((V)(18.5)), r_514), ((V)(0.05))), y_512, z_510)).S("\">").V(cap_521).S("</g>");
return default;
}, 2, "", true));
Invoke(Arr(Arr(((V)(137D)), ((V)("#4dff7a")), ((V)("PWR")), ((V)(1D))), Arr(((V)(132.4)), ((V)("#3ff0ff")), ((V)("SIG")), ((V)(0D))), Arr(((V)(127.8)), ((V)("#ff3b3b")), ((V)("LIM")), ((V)(0D)))), "forEach", Fn((V _arrowThis551, int _argc535, V _a537, V i_541, V _a539, V _a540, V[] _rest536) => {
V lit_552 = default;
V y_544 = default;
V col_546 = default;
V lab_548 = default;
V on_550 = default;
{ V _t542 = ListOf(_a537);
{ V _t543 = GetIdx(_t542, 0D);
y_544 = _t543; }
{ V _t545 = GetIdx(_t542, 1D);
col_546 = _t545; }
{ V _t547 = GetIdx(_t542, 2D);
lab_548 = _t547; }
{ V _t549 = GetIdx(_t542, 3D);
on_550 = _t549; }
}
lit_552 = ((V)((Truthy(on_550) ? "" : (Truthy(play_410) ? JsStrBuf.Begin().S("<animate attributeName=\"opacity\" values=\"").S((SEqN(i_541, 1D) ? "1;0.25;1;0.6;1;0.2" : "0.12;0.12;0.12;1;0.12;0.12;0.12;0.12")).S("\" dur=\"").N((SEqN(i_541, 1D) ? 0.5 : 2D)).S("s\" calcMode=\"discrete\" repeatCount=\"indefinite\"/>").End() : ""))));
f_456.S("<g transform=\"").V(Call(planeX_23, V.Undef, p_454, ((V)(18.6)), y_544, ((V)(9D)))).S("\"><circle r=\"1.9\" fill=\"").V(col_546).S("\" filter=\"url(#paB)\" opacity=\"").N((Truthy((on_550 is var _t553 && Truthy(_t553) ? _t553 : play_410)) ? 0.6 : 0D)).S("\">").V(lit_552).S("</circle><circle r=\"0.75\" fill=\"").V(col_546).S("\" opacity=\"").N((Truthy((on_550 is var _t554 && Truthy(_t554) ? _t554 : play_410)) ? 1D : 0.22)).S("\" stroke=\"#000000\" stroke-width=\"0.2\">").V(lit_552).S("</circle><text x=\"-2.2\" y=\"0.45\" text-anchor=\"end\" font-family=\"Arial, sans-serif\" font-weight=\"800\" font-size=\"1.05\" fill=\"#c9cdd2\">").V(lab_548).S("</text></g>");
return default;
}, 2, "", true));
if (Truthy(play_410)) {
V fl_555 = default;
f_456.S("<g transform=\"").V(Call(plane_22, V.Undef, p_454, ((V)(16.4)), ((V)(116.5)), ((V)(0D)))).S("\">").V(Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis563, int _argc556, V j_562, V _a559, V _a560, V _a561, V[] _rest557) => {
return ((V)(JsStrBuf.Begin().S("<ellipse rx=\"15\" ry=\"15\" fill=\"none\" stroke=\"").V(GetK(Arr(((V)("#3ff0ff")), ((V)("#ff4fb8")), ((V)("#ffe14f"))), j_562)).S("\" stroke-width=\"0.9\" opacity=\"0\"><animate attributeName=\"rx\" values=\"15;34\" dur=\"1.5s\" begin=\"").V(Call(n4_20, V.Undef, ((V)(((-ToNum(j_562)) * 0.5))))).S("s\" repeatCount=\"indefinite\"/><animate attributeName=\"ry\" values=\"15;34\" dur=\"1.5s\" begin=\"").V(Call(n4_20, V.Undef, ((V)(((-ToNum(j_562)) * 0.5))))).S("s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.8;0\" dur=\"1.5s\" begin=\"").V(Call(n4_20, V.Undef, ((V)(((-ToNum(j_562)) * 0.5))))).S("s\" repeatCount=\"indefinite\"/></ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
f_456.V(Call(notes_40, V.Undef, Call(p_454, V.Undef, ((V)(0D)), ((V)(156D)), ((V)(8D))), ((V)(4D)), k_455, ((V)("pa")), ((V)(0D))));
fl_555 = Call(p_454, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
un_458.S("<ellipse cx=\"").V(Call(f1_17, V.Undef, GetIdx(fl_555, 0D))).S("\" cy=\"").V(Call(f1_17, V.Undef, GetIdx(fl_555, 1D))).S("\" rx=\"").V(Call(f1_17, V.Undef, ((V)((40D * ToNum(k_455)))))).S("\" ry=\"").V(Call(f1_17, V.Undef, ((V)((((40D * ToNum(k_455)) * ToNum(Get(X_9, "SA"))) * 0.6))))).S("\" fill=\"#3ff0ff\" opacity=\"0.18\" filter=\"url(#paB)\"/>");
}
defs_462 = ((V)(JsStrBuf.Begin().V(Add(Add(Add(Add(Call(BLUR_26, V.Undef, ((V)("paB")), ((V)(1.1))), Call(G_34, V.Undef, ((V)("paCone")), Arr(Arr(((V)(0D)), ((V)("#3a3c46"))), Arr(((V)(0.6)), ((V)("#16171c"))), Arr(((V)(1D)), ((V)("#0a0a0d")))))), Call(G_34, V.Undef, ((V)("paKnob")), Arr(Arr(((V)(0D)), ((V)("#6a6e7a"))), Arr(((V)(0.5)), ((V)("#26272e"))), Arr(((V)(1D)), ((V)("#0c0c10")))))), Call(L_35, V.Undef, ((V)("paChr")), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(0.45)), ((V)("#c9cfd6"))), Arr(((V)(0.55)), ((V)("#8a919c"))), Arr(((V)(1D)), ((V)("#e8edf2")))))), Call(L_35, V.Undef, ((V)("paGl")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.12))), Arr(((V)(0.35)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(1D)), ((V)("#000000")), ((V)(0.2))))))).S("<pattern id=\"paHole\" width=\"1.5\" height=\"1.3\" patternUnits=\"userSpaceOnUse\"><circle cx=\"0.4\" cy=\"0.35\" r=\"0.42\" fill=\"#0b0c10\" opacity=\"0.85\"/><circle cx=\"1.15\" cy=\"1\" r=\"0.42\" fill=\"#0b0c10\" opacity=\"0.85\"/><circle cx=\"0.25\" cy=\"0.2\" r=\"0.16\" fill=\"#ffffff\" opacity=\"0.08\"/></pattern>").End()));
return NewObj(5).Put("defs", defs_462).Put("under", ((V)(un_458.Str))).Put("back", ((V)(bk_457.Str))).Put("front", ((V)(f_456.Str))).Put("bb", Call(bbOf_27, V.Undef, Invoke(Invoke(FEET_412, "map", Fn((V _arrowThis571, int _argc564, V q_570, V _a567, V _a568, V _a569, V[] _rest565) => {
return Call(p_454, V.Undef, ((V)((ToNum(GetIdx(q_570, 0D)) * 1.12))), ((V)(0D)), ((V)((ToNum(GetIdx(q_570, 2D)) * 1.12))));
}, 1, "", true)), "concat", Arr(Call(p_454, V.Undef, ((V)((-19D))), ((V)(156D)), ((V)((-16D)))), Call(p_454, V.Undef, ((V)(19D)), ((V)(156D)), ((V)((-16D)))), Call(p_454, V.Undef, ((V)((-19D))), ((V)(97D)), ((V)(16D))), Call(p_454, V.Undef, ((V)(23D)), ((V)(140D)), ((V)(14D)))), (Truthy(play_410) ? Arr(Call(p_454, V.Undef, ((V)((-34D))), ((V)(200D)), ((V)(8D))), Call(p_454, V.Undef, ((V)(34D)), ((V)(200D)), ((V)(8D))), Call(p_454, V.Undef, ((V)((-36D))), ((V)(116D)), ((V)(16D))), Call(p_454, V.Undef, ((V)(36D)), ((V)(116D)), ((V)(16D)))) : Arr())), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_414;
return default;
}, 1, "", true));
Set(RD_8, "SET6", NewObj(5).Put("CLB-018", NewObj(4).Put("spec", ((V)("boom80"))).Put("role", ((V)("spk"))).Put("live", ((V)("Tap to play"))).Put("note", ((V)("A clean 80s chrome boombox: two big speaker cones with chrome rings, tweeters, a tuner window and a smoked cassette door. Tap to play: the door flips down, the tape drops in, the reels roll and the cones pump. The aux cable is neatly coiled with a red strap."))).V).Put("CLB-002", NewObj(3).Put("spec", ((V)("paPro"))).Put("live", ((V)("Sound check"))).Put("note", ((V)("A modern active PA cabinet on a sturdy steel tripod: perforated steel grille over the woofer and horn, an amp panel with volume, gain, mic and EQ knobs, combo jacks and a glowing green power LED. Tap for a clean sound check: the volume knob turns up, the signal light dances and the woofer pumps."))).V).Put("CLB-045", NewObj(2).Put("live", ((V)("Live LED"))).Put("note", ((V)("Big 70s acrylic light-up squares in a chrome grid. They run the same neon colour wave as the Black LED floor, all the time."))).V).Put("CLB-065", NewObj(2).Put("live", ((V)("Live LED"))).Put("note", ((V)("A fine RGB pixel-matrix floor. It runs the same neon colour wave as the Black LED floor in one steady loop, with no step flashes."))).V).Put("CLB-085", NewObj(2).Put("live", ((V)("Live LED"))).Put("note", ((V)("Floating light plates over a black base. They run the same neon colour wave as the Black LED floor in one steady loop, with no step flashes."))).V).V);
edit5_42 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis579, int _argc572, V rows_578, V _a575, V _a576, V _a577, V[] _rest573) => {
return Invoke(Call(edit5_42, V.Undef, rows_578), "map", Fn((V _arrowThis587, int _argc580, V r_586, V _a583, V _a584, V _a585, V[] _rest581) => {
return (Truthy(GetK(Get(RD_8, "SET6"), Get(r_586, "id"))) ? Object_assign(NewObj(0).V, r_586, GetK(Get(RD_8, "SET6"), Get(r_586, "id"))) : r_586);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "PLUS6", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
