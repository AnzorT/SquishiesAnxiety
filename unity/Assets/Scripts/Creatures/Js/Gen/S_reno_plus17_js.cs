// reno-plus17.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus17_js
    {

        public static void Run()
        {
Call(Named(boot_66 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V solid_11 = default;
V box_12 = default;
V cyl_13 = default;
V ball_14 = default;
V slab_15 = default;
V slabX_16 = default;
V arcW_17 = default;
V disc_18 = default;
V pillowY_19 = default;
V pillowZ_20 = default;
V shade_21 = default;
V mix_22 = default;
V f1_23 = default;
V N_24 = default;
double PI_25 = 0;
V GOLD_26 = default;
V CH_27 = default;
V xf_28 = default;
V tilt_29 = default;
V tiltAll_30 = default;
V rotF_31 = default;
V rod_32 = default;
V pipe_33 = default;
V fxEll_34 = default;
V frame_35 = default;
V kern_36 = default;
V cup_37 = default;
V holder_38 = default;
V an_39 = default;
V FONT_40 = default;
V W__41 = default;
V M__42 = default;
V F__43 = default;
V L__44 = default;
V PL_45 = default;
V G__46 = default;
V em_47 = default;
V rep_48 = default;
V P2_49 = default;
V n4_50 = default;
V R0_51 = default;
V CASE_52 = default;
V spark_53 = default;
V puffs_54 = default;
V can_55 = default;
V slTilt_56 = default;
V SLP_57 = default;
V slAt_58 = default;
double TX_59 = 0;
double STY_60 = 0;
V edit16_61 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((RD_8 is var _t62 && !Truthy(_t62) ? _t62 : Get(RD_8, "PLUS16")) is var _t63 && !Truthy(_t63) ? _t63 : Get(RD_8, "H16")) is var _t64 && !Truthy(_t64) ? _t64 : X_9) is var _t65 && !Truthy(_t65) ? _t65 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_66.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS17"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t67 = K_10;
if (_t67.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t67));
{ V _t68 = Get(_t67, "solid");
solid_11 = _t68; }
{ V _t69 = Get(_t67, "box");
box_12 = _t69; }
{ V _t70 = Get(_t67, "cyl");
cyl_13 = _t70; }
{ V _t71 = Get(_t67, "ball");
ball_14 = _t71; }
{ V _t72 = Get(_t67, "slab");
slab_15 = _t72; }
{ V _t73 = Get(_t67, "slabX");
slabX_16 = _t73; }
{ V _t74 = Get(_t67, "arcW");
arcW_17 = _t74; }
{ V _t75 = Get(_t67, "disc");
disc_18 = _t75; }
{ V _t76 = Get(_t67, "pillowY");
pillowY_19 = _t76; }
{ V _t77 = Get(_t67, "pillowZ");
pillowZ_20 = _t77; }
{ V _t78 = Get(_t67, "shade");
shade_21 = _t78; }
{ V _t79 = Get(_t67, "mix");
mix_22 = _t79; }
{ V _t80 = Get(_t67, "f1");
f1_23 = _t80; } }
N_24 = Get(RD_8, "N");
PI_25 = System.Math.PI;
GOLD_26 = ((V)("#e2b14a"));
CH_27 = ((V)("#d5dde2"));
{ V _t81 = Get(RD_8, "H16");
if (_t81.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t81));
{ V _t82 = Get(_t81, "xf");
xf_28 = _t82; }
{ V _t83 = Get(_t81, "tilt");
tilt_29 = _t83; }
{ V _t84 = Get(_t81, "tiltAll");
tiltAll_30 = _t84; }
{ V _t85 = Get(_t81, "rotF");
rotF_31 = _t85; }
{ V _t86 = Get(_t81, "rod");
rod_32 = _t86; }
{ V _t87 = Get(_t81, "pipe");
pipe_33 = _t87; }
{ V _t88 = Get(_t81, "fxEll");
fxEll_34 = _t88; }
{ V _t89 = Get(_t81, "frame");
frame_35 = _t89; }
{ V _t90 = Get(_t81, "kern");
kern_36 = _t90; }
{ V _t91 = Get(_t81, "cup");
cup_37 = _t91; }
{ V _t92 = Get(_t81, "holder");
holder_38 = _t92; }
{ V _t93 = Get(_t81, "an");
an_39 = _t93; }
{ V _t94 = Get(_t81, "FONT");
FONT_40 = _t94; }
{ V _t95 = Get(_t81, "W_");
W__41 = _t95; }
{ V _t96 = Get(_t81, "M_");
M__42 = _t96; }
{ V _t97 = Get(_t81, "F_");
F__43 = _t97; }
{ V _t98 = Get(_t81, "L_");
L__44 = _t98; }
{ V _t99 = Get(_t81, "PL");
PL_45 = _t99; }
{ V _t100 = Get(_t81, "G_");
G__46 = _t100; }
{ V _t101 = Get(_t81, "em");
em_47 = _t101; }
{ V _t102 = Get(_t81, "rep");
rep_48 = _t102; } }
P2_49 = Fn((V _arrowThis110, int _argc103, V q_109, V _a106, V _a107, V _a108, V[] _rest104) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(q_109, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_109, 1D))).End()));
}, 1, "", true);
n4_50 = Fn((V _arrowThis118, int _argc111, V v_117, V _a114, V _a115, V _a116, V[] _rest112) => {
return ((V)((Round((ToNum(v_117) * 10000D)) / 10000D)));
}, 1, "", true);
R0_51 = Fn((V _arrowThis126, int _argc119, V s_125, V _a122, V _a123, V _a124, V[] _rest120) => {
V h_127 = default;
h_127 = ((V)(7D));
{
foreach (V _k128 in new JsIter(((V)(ToStrS(s_125))))) {
V ch_129 = default;
ch_129 = _k128;
h_127 = ((V)(((double)(ToInt32(ToNum(Add(((V)((ToNum(h_127) * 31D))), Invoke(ch_129, "charCodeAt", ((V)(0D)))))) | ToInt32(0D)))));
}
}
h_127 = (((V)(System.Math.Abs(ToNum(h_127)))) is var _t130 && Truthy(_t130) ? _t130 : ((V)(1D)));
return Fn((V _arrowThis137, int _argc131, V _a133, V _a134, V _a135, V _a136, V[] _rest132) => {
h_127 = ((V)(((double)(ToInt32(((ToNum(h_127) * 1103515245D) + 12345D)) | ToInt32(0D)))));
return ((V)((((double)(ToInt32(((double)(ToUint32(ToNum(h_127)) >> (int)(ToUint32(8D) & 31)))) & ToInt32(65535D))) / 65536D)));
return default;
}, 0, "", true);
return default;
}, 1, "", true);
CASE_52 = Arr(((V)("#d9363b")), ((V)("#3f7fc8")), ((V)("#f2c94c")), ((V)("#4f9a4a")), ((V)("#8a55c8")), ((V)("#ff9d4a")), ((V)("#2a2d34")), ((V)("#e86fa8")), ((V)("#3fc0c8")));
spark_53 = Fn((V _arrowThis151, int _argc138, V c_144, V x_145, V y_146, V z_147, V[] _rest139) => {
V s_148 = default;
V b_149 = default;
V col_150 = default;
s_148 = (_argc138 > 4 ? _rest139[0] : V.Undef);
b_149 = (_argc138 > 5 ? _rest139[1] : V.Undef);
col_150 = (_argc138 > 6 ? _rest139[2] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_49, V.Undef, Invoke(c_144, "p", x_145, y_146, z_147))).S(") scale(").V(Call(f1_23, V.Undef, ((V)((ToNum(Get(c_144, "k")) * ToNum((s_148 is var _t152 && Truthy(_t152) ? _t152 : ((V)(1D))))))))).S(")\"><path d=\"M0 -4L1 -1L4 0L1 1L0 4L-1 1L-4 0L-1 -1Z\" fill=\"").V((col_150 is var _t153 && Truthy(_t153) ? _t153 : ((V)("#ffffff")))).S("\" opacity=\"0\">").V(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0;1;0;0")), ((V)(1.8)), b_149)).S("</path></g>").End()));
}, 7, "", true);
puffs_54 = Fn((V _arrowThis167, int _argc154, V c_160, V x_161, V y_162, V z_163, V[] _rest155) => {
V n_164 = default;
V col_165 = default;
V d_166 = default;
n_164 = (_argc154 > 4 ? _rest155[0] : V.Undef);
col_165 = (_argc154 > 5 ? _rest155[1] : V.Undef);
d_166 = (_argc154 > 6 ? _rest155[2] : V.Undef);
return Invoke(Call(rep_48, V.Undef, n_164, Fn((V _arrowThis175, int _argc168, V i_174, V _a171, V _a172, V _a173, V[] _rest169) => {
V q_176 = default;
V b_177 = default;
q_176 = Invoke(c_160, "p", Add(x_161, ((V)((((ToNum(i_174) % 3D) - 1D) * 2.4)))), y_162, z_163);
b_177 = Call(n4_50, V.Undef, ((V)((((-ToNum(i_174)) * ToNum((d_166 is var _t178 && Truthy(_t178) ? _t178 : ((V)(2.4))))) / ToNum(n_164)))));
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_176, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_176, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(Get(c_160, "k"))))))).S("\" fill=\"").V((col_165 is var _t179 && Truthy(_t179) ? _t179 : ((V)("#ffffff")))).S("\" opacity=\"0\">").V(Call(an_39, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(q_176, 1D))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_176, 1D)) - (14D * ToNum(Get(c_160, "k")))))))).End())), (d_166 is var _t180 && Truthy(_t180) ? _t180 : ((V)(2.4))), b_177)).V(Call(an_39, V.Undef, ((V)("r")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((1.2 * ToNum(Get(c_160, "k"))))))).S(";").V(Call(f1_23, V.Undef, ((V)((3.4 * ToNum(Get(c_160, "k"))))))).End())), (d_166 is var _t181 && Truthy(_t181) ? _t181 : ((V)(2.4))), b_177)).V(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0;0.55;0")), (d_166 is var _t182 && Truthy(_t182) ? _t182 : ((V)(2.4))), b_177)).S("</circle>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
}, 7, "", true);
can_55 = Fn((V _arrowThis194, int _argc183, V x_189, V y_190, V z_191, V col_192, V[] _rest184) => {
V h_193 = default;
h_193 = (_argc183 > 4 ? _rest184[0] : V.Undef);
return Arr(Call(cyl_13, V.Undef, x_189, y_190, z_191, ((V)(3.2)), (h_193 is var _t195 && Truthy(_t195) ? _t195 : ((V)(10D))), col_192, Call(M__42, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.86))), Arr(((V)(0.8)), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum((h_193 is var _t196 && Truthy(_t196) ? _t196 : ((V)(10D)))) - 0.8))), ((V)(0D)), ((V)(1D))), Arr((h_193 is var _t197 && Truthy(_t197) ? _t197 : ((V)(10D))), ((V)(0D)), ((V)(0.8))))).V)), Call(cyl_13, V.Undef, x_189, Add(y_190, ((V)((ToNum((h_193 is var _t198 && Truthy(_t198) ? _t198 : ((V)(10D)))) * 0.42)))), z_191, ((V)(3.25)), ((V)(2D)), ((V)("#ffffff")), NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V), Call(cyl_13, V.Undef, x_189, Add(y_190, (h_193 is var _t199 && Truthy(_t199) ? _t199 : ((V)(10D)))), z_191, ((V)(2.6)), ((V)(0.3)), CH_27, Call(M__42, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).V)));
}, 5, "", true);
Set(N_24, "crate17", Fn((V _arrowThis207, int _argc200, V S_206, V _a203, V _a204, V _a205, V[] _rest201) => {
return NewObj(5).Put("w", ((V)(98D))).Put("d", ((V)(50D))).Put("topH", ((V)(31D))).Put("topW", ((V)(60D))).Put("build", Fn((V _arrowThis214, int _argc208, V _a210, V _a211, V _a212, V _a213, V[] _rest209) => {
V o_215 = default;
V BL_216 = default;
V BD_217 = default;
V PLY_218 = default;
o_215 = Arr();
BL_216 = ((V)("#3f7fc8"));
BD_217 = Call(shade_21, V.Undef, BL_216, ((V)(0.68)));
PLY_218 = ((V)("#d9b98a"));
Invoke(Arr(((V)((-21D))), ((V)(21D))), "forEach", Fn((V _arrowThis226, int _argc219, V x_225, V _a222, V _a223, V _a224, V[] _rest220) => {
double w_227 = 0;
double h_228 = 0;
double d_229 = 0;
w_227 = 40D;
h_228 = 28D;
d_229 = 38D;
Invoke(o_215, "push", Call(box_12, V.Undef, x_225, ((V)(0D)), ((V)(0D)), ((V)(w_227)), ((V)(h_228)), ((V)(d_229)), BL_216, Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("bev", ((V)(1.2))).V)), Call(box_12, V.Undef, x_225, ((V)(0D)), ((V)(0D)), ((V)((w_227 + 1.4))), ((V)(3.4)), ((V)((d_229 + 1.4))), Call(shade_21, V.Undef, BL_216, ((V)(0.88))), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(3.4))).V)), Call(box_12, V.Undef, x_225, ((V)((h_228 - 3.4))), ((V)(0D)), ((V)((w_227 + 1.4))), ((V)(3.4)), ((V)((d_229 + 1.4))), Call(shade_21, V.Undef, BL_216, ((V)(0.88))), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(3.4))).V)));
Call(rep_48, V.Undef, ((V)(3D)), Fn((V _arrowThis237, int _argc230, V i_236, V _a233, V _a234, V _a235, V[] _rest231) => {
return Call(rep_48, V.Undef, ((V)(2D)), Fn((V _arrowThis245, int _argc238, V j_244, V _a241, V _a242, V _a243, V[] _rest239) => {
return Invoke(o_215, "push", Call(box_12, V.Undef, ((V)(((ToNum(x_225) - 12D) + (ToNum(i_236) * 12D)))), ((V)((6D + (ToNum(j_244) * 9.6)))), ((V)(((d_229 / 2D) + 0.05))), ((V)(8.4)), ((V)(6.6)), ((V)(0.4)), BD_217, NewObj(3).Put("r", ((V)(1.6))).Put("noOut", ((V)(1D))).Put("mat", ((V)("pl"))).V));
}, 1, "", true));
}, 1, "", true));
Call(rep_48, V.Undef, ((V)(3D)), Fn((V _arrowThis253, int _argc246, V i_252, V _a249, V _a250, V _a251, V[] _rest247) => {
return Call(rep_48, V.Undef, ((V)(2D)), Fn((V _arrowThis261, int _argc254, V j_260, V _a257, V _a258, V _a259, V[] _rest255) => {
return Invoke(o_215, "push", Call(box_12, V.Undef, Add(Add(x_225, ((V)((w_227 / 2D)))), ((V)(0.05))), ((V)((6D + (ToNum(j_260) * 9.6)))), ((V)(((-12D) + (ToNum(i_252) * 12D)))), ((V)(0.4)), ((V)(6.6)), ((V)(8.4)), BD_217, NewObj(3).Put("r", ((V)(1.6))).Put("noOut", ((V)(1D))).Put("mat", ((V)("pl"))).V));
}, 1, "", true));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(o_215, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(1D)), ((V)(94D)), ((V)(2.4)), ((V)(46D)), PLY_218, Call(W__41, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)(0.035))).V)), Call(cyl_13, V.Undef, ((V)(26D)), ((V)(30.45)), ((V)((-10D))), ((V)(5D)), ((V)(0.1)), ((V)("#8a6a40")), NewObj(3).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.35))).V));
Invoke(o_215, "push", Call(box_12, V.Undef, ((V)((-16D))), ((V)(30.4)), ((V)(3D)), ((V)(32D)), ((V)(3.8)), ((V)(30D)), ((V)("#ead6ae")), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)((-0.14)))).V)), Call(cyl_13, V.Undef, ((V)((-16D))), ((V)(34.2)), ((V)(3D)), ((V)(6.4)), ((V)(0.25)), ((V)("#d9363b")), NewObj(2).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)((-16D))), ((V)(34.5)), ((V)(3D)), ((V)(4D)), ((V)(0.2)), ((V)("#ffffff")), NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)((-24D))), ((V)(34.25)), ((V)(10D)), ((V)(3D)), ((V)(0.1)), ((V)("#c9a060")), NewObj(3).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.5))).V));
Invoke(Call(can_55, V.Undef, ((V)(20D)), ((V)(30.4)), ((V)(8D)), ((V)("#4f9a4a"))), "forEach", Fn((V _arrowThis269, int _argc262, V s_268, V _a265, V _a266, V _a267, V[] _rest263) => {
return Invoke(o_215, "push", s_268);
}, 1, "", true));
Invoke(o_215, "push", Call(ball_14, V.Undef, ((V)(33D)), ((V)(30.4)), ((V)(12D)), ((V)(3.2)), ((V)("#ffffff")), NewObj(5).Put("sy", ((V)(0.8))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("shine", ((V)(0D))).Put("mat", ((V)("fab"))).V), Call(ball_14, V.Undef, ((V)(31D)), ((V)(30.4)), ((V)(15D)), ((V)(2.4)), ((V)("#f3f3f3")), NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).Put("mat", ((V)("fab"))).V));
return o_215;
return default;
}, 0, "build", true)).V;
}, 1, "", true));
Set(N_24, "lift17", Fn((V _arrowThis277, int _argc270, V S_276, V _a273, V _a274, V _a275, V[] _rest271) => {
double W_278 = 0;
double D2_279 = 0;
V OAK_280 = default;
V WH_281 = default;
V LG_282 = default;
double FL_283 = 0;
double TY_284 = 0;
double TZ_285 = 0;
double TD_286 = 0;
W_278 = 96D;
D2_279 = 50D;
OAK_280 = ((V)("#d9a066"));
WH_281 = ((V)("#f4efe6"));
LG_282 = ((V)("#b98048"));
FL_283 = 13D;
TY_284 = 40D;
TZ_285 = (-14D);
TD_286 = 30D;
return NewObj(6).Put("w", ((V)((W_278 + 6D)))).Put("d", ((V)((D2_279 + 14D)))).Put("topH", ((V)((TY_284 + 3D)))).Put("topZ", ((V)(TZ_285))).Put("topW", ((V)(50D))).Put("build", Fn((V _arrowThis293, int _argc287, V _a289, V _a290, V _a291, V _a292, V[] _rest288) => {
V o_294 = default;
double BX_295 = 0;
double BZ_296 = 0;
V R_297 = default;
o_294 = Arr();
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis309, int _argc298, V _a300, V _a301, V _a302, V _a303, V[] _rest299) => {
V sx_306 = default;
V sz_308 = default;
{ V _t304 = ListOf(_a300);
{ V _t305 = GetIdx(_t304, 0D);
sx_306 = _t305; }
{ V _t307 = GetIdx(_t304, 1D);
sz_308 = _t307; }
}
return Invoke(o_294, "push", Call(cyl_13, V.Undef, ((V)((ToNum(sx_306) * ((W_278 / 2D) - 7D)))), ((V)(0D)), ((V)((ToNum(sz_308) * ((D2_279 / 2D) - 7D)))), ((V)(2.6)), ((V)(6D)), LG_282, Call(W__41, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))))).V)));
}, 1, "", true));
Invoke(o_294, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(W_278)), ((V)((FL_283 - 6D))), ((V)(D2_279)), WH_281, Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("bev", ((V)(1.2))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(FL_283)), ((V)(0D)), ((V)((W_278 - 6D))), ((V)(0.4)), ((V)((D2_279 - 6D))), ((V)("#4a3a40")), NewObj(3).Put("r", ((V)(0.6))).Put("noOut", ((V)(1D))).Put("mat", ((V)("fab"))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis317, int _argc310, V sz_316, V _a313, V _a314, V _a315, V[] _rest311) => {
return Invoke(o_294, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(FL_283)), ((V)((ToNum(sz_316) * ((D2_279 / 2D) - 1.5)))), ((V)(W_278)), ((V)((26D - FL_283))), ((V)(3D)), WH_281, Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis325, int _argc318, V sx_324, V _a321, V _a322, V _a323, V[] _rest319) => {
return Invoke(o_294, "push", Call(box_12, V.Undef, ((V)((ToNum(sx_324) * ((W_278 / 2D) - 1.5)))), ((V)(FL_283)), ((V)(0D)), ((V)(3D)), ((V)((26D - FL_283))), ((V)((D2_279 - 6D))), WH_281, Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "", true));
Invoke(o_294, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)(9D)), ((V)(((D2_279 / 2D) + 0.05))), ((V)((W_278 - 12D))), ((V)(0.6)), ((V)(0.4)), Call(shade_21, V.Undef, WH_281, ((V)(0.85))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis333, int _argc326, V sz_332, V _a329, V _a330, V _a331, V[] _rest327) => {
return Invoke(o_294, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(26D)), ((V)((ToNum(sz_332) * ((D2_279 / 2D) - 1.6)))), ((V)((W_278 + 1D))), ((V)(2.2)), ((V)(3.4)), OAK_280, Call(W__41, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis341, int _argc334, V sx_340, V _a337, V _a338, V _a339, V[] _rest335) => {
return Invoke(o_294, "push", Call(box_12, V.Undef, ((V)((ToNum(sx_340) * ((W_278 / 2D) - 1.6)))), ((V)(26D)), ((V)(0D)), ((V)(3.4)), ((V)(2.2)), ((V)((D2_279 - 5D))), OAK_280, Call(W__41, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "", true));
Call(rep_48, V.Undef, ((V)(9D)), Fn((V _arrowThis349, int _argc342, V i_348, V _a345, V _a346, V _a347, V[] _rest343) => {
return Invoke(o_294, "push", Call(box_12, V.Undef, ((V)(((-38D) + (ToNum(i_348) * 3.1)))), ((V)((FL_283 + 0.4))), ((V)(6D)), ((V)(2.4)), ((V)(12.6)), ((V)(11D)), GetIdx(CASE_52, (ToNum(i_348) % 9D)), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("yaw", ((V)((((ToNum(i_348) % 3D) - 1D) * 0.05)))).V)));
}, 1, "", true));
Call(rep_48, V.Undef, ((V)(7D)), Fn((V _arrowThis357, int _argc350, V i_356, V _a353, V _a354, V _a355, V[] _rest351) => {
return Invoke(o_294, "push", Call(box_12, V.Undef, ((V)((8D + (ToNum(i_356) * 3.1)))), ((V)((FL_283 + 0.4))), ((V)(6D)), ((V)(2.4)), ((V)(12.6)), ((V)(11D)), GetIdx(CASE_52, (ToNum(Add(i_356, ((V)(4D)))) % 9D)), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("yaw", ((V)(((ToNum(i_356) % 2D) * 0.06)))).V)));
}, 1, "", true));
Invoke(o_294, "push", Call(box_12, V.Undef, ((V)((-2D))), ((V)((FL_283 + 0.4))), ((V)(9D)), ((V)(10D)), ((V)(1.6)), ((V)(13D)), ((V)("#2a2d34")), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("yaw", ((V)(0.2))).V)), Call(box_12, V.Undef, ((V)((-1.5))), ((V)((FL_283 + 2D))), ((V)(9D)), ((V)(9.4)), ((V)(1.4)), ((V)(12.4)), ((V)("#e86fa8")), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("yaw", ((V)(0.32))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis365, int _argc358, V sg_364, V _a361, V _a362, V _a363, V[] _rest359) => {
double x_366 = 0;
x_366 = (ToNum(sg_364) * 41.5);
Invoke(o_294, "push", Call(rod_32, V.Undef, Arr(((V)(x_366)), ((V)((FL_283 + 1.8))), ((V)((-4D)))), Arr(((V)(x_366)), ((V)((TY_284 - 1.8))), ((V)((TZ_285 - 10D)))), ((V)(0.8)), CH_27, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(rod_32, V.Undef, Arr(((V)(x_366)), ((V)((FL_283 + 1.8))), ((V)((-18D)))), Arr(((V)(x_366)), ((V)((TY_284 - 1.8))), ((V)((TZ_285 + 8D)))), ((V)(0.8)), CH_27, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(ball_14, V.Undef, ((V)(x_366)), ((V)((((FL_283 + TY_284) / 2D) - 0.9))), ((V)((-11D))), ((V)(1.3)), CH_27, Call(M__42, V.Undef, NewObj(2).Put("k", ((V)(2D))).Put("n", ((V)(8D))).V)), Call(box_12, V.Undef, ((V)(x_366)), ((V)(FL_283)), ((V)((-11D))), ((V)(3D)), ((V)(1D)), ((V)(16D)), CH_27, Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_12, V.Undef, ((V)(x_366)), ((V)((TY_284 - 1D))), ((V)(TZ_285)), ((V)(3D)), ((V)(1D)), ((V)(24D)), CH_27, Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
return default;
}, 1, "", true));
Invoke(o_294, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(TY_284)), ((V)((TZ_285 - 2D))), ((V)((W_278 - 2D))), ((V)(3D)), ((V)(TD_286)), OAK_280, Call(W__41, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
BX_295 = (-12D);
BZ_296 = (TZ_285 + 4D);
Invoke(o_294, "push", Call(cyl_13, V.Undef, ((V)(BX_295)), ((V)((TY_284 + 3D))), ((V)(BZ_296)), ((V)(8.4)), ((V)(4.6)), ((V)("#e86f5a")), Call(PL_45, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.62))), Arr(((V)(4.6)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_13, V.Undef, ((V)(BX_295)), ((V)((TY_284 + 7.2))), ((V)(BZ_296)), ((V)(7.6)), ((V)(0.4)), ((V)("#a8402c")), NewObj(2).Put("n", ((V)(16D))).Put("noOut", ((V)(1D))).V));
R_297 = Call(R0_51, V.Undef, ((V)("chips")));
Call(rep_48, V.Undef, ((V)(9D)), Fn((V _arrowThis374, int _argc367, V i_373, V _a370, V _a371, V _a372, V[] _rest368) => {
return Invoke(o_294, "push", Call(ball_14, V.Undef, ((V)((BX_295 + ((ToNum(Call(R_297, V.Undef)) - 0.5) * 10D)))), ((V)(((TY_284 + 7.2) + (ToNum(Call(R_297, V.Undef)) * 2D)))), ((V)((BZ_296 + ((ToNum(Call(R_297, V.Undef)) - 0.5) * 8D)))), ((V)(2.4)), ((V)((NumTruthy((ToNum(i_373) % 2D)) ? "#f2c94c" : "#e8b23a"))), NewObj(4).Put("sy", ((V)(0.32))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).V));
}, 1, "", true));
Invoke(Call(can_55, V.Undef, ((V)(14D)), ((V)((TY_284 + 3D))), ((V)((TZ_285 + 2D))), ((V)("#d9363b"))), "forEach", Fn((V _arrowThis382, int _argc375, V s_381, V _a378, V _a379, V _a380, V[] _rest376) => {
return Invoke(o_294, "push", s_381);
}, 1, "", true));
Invoke(o_294, "push", Call(box_12, V.Undef, ((V)(30D)), ((V)((TY_284 + 3D))), ((V)((TZ_285 - 2D))), ((V)(5D)), ((V)(1.8)), ((V)(14D)), ((V)("#3a3b40")), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(1.4))).Put("yaw", ((V)(0.3))).V)));
return o_294;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "glass17", Fn((V _arrowThis390, int _argc383, V S_389, V _a386, V _a387, V _a388, V[] _rest384) => {
double W_391 = 0;
double D2_392 = 0;
double H_393 = 0;
V ST_394 = default;
V GL_395 = default;
W_391 = 100D;
D2_392 = 52D;
H_393 = 28D;
ST_394 = ((V)("#26272b"));
GL_395 = ((V)("#5a6470"));
return NewObj(5).Put("w", ((V)((W_391 + 6D)))).Put("d", ((V)((D2_392 + 6D)))).Put("topH", ((V)((H_393 + 1.6)))).Put("topW", ((V)(60D))).Put("build", Fn((V _arrowThis402, int _argc396, V _a398, V _a399, V _a400, V _a401, V[] _rest397) => {
V o_403 = default;
V R_404 = default;
o_403 = Arr();
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis416, int _argc405, V _a407, V _a408, V _a409, V _a410, V[] _rest406) => {
V sx_413 = default;
V sz_415 = default;
{ V _t411 = ListOf(_a407);
{ V _t412 = GetIdx(_t411, 0D);
sx_413 = _t412; }
{ V _t414 = GetIdx(_t411, 1D);
sz_415 = _t414; }
}
return Invoke(o_403, "push", Call(box_12, V.Undef, ((V)((ToNum(sx_413) * ((W_391 / 2D) - 2D)))), ((V)(0D)), ((V)((ToNum(sz_415) * ((D2_392 / 2D) - 2D)))), ((V)(3D)), ((V)(H_393)), ((V)(3D)), ST_394, Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}, 1, "", true));
Invoke(Arr(((V)((H_393 - 2.4))), ((V)(5D))), "forEach", Fn((V _arrowThis424, int _argc417, V y_423, V _a420, V _a421, V _a422, V[] _rest418) => {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis432, int _argc425, V sz_431, V _a428, V _a429, V _a430, V[] _rest426) => {
return Invoke(o_403, "push", Call(slabX_16, V.Undef, ((V)(0D)), y_423, ((V)((ToNum(sz_431) * ((D2_392 / 2D) - 2D)))), ((V)((W_391 - 4D))), ((V)(2.4)), ((V)(2.4)), ST_394, Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis440, int _argc433, V sx_439, V _a436, V _a437, V _a438, V[] _rest434) => {
return Invoke(o_403, "push", Call(box_12, V.Undef, ((V)((ToNum(sx_439) * ((W_391 / 2D) - 2D)))), y_423, ((V)(0D)), ((V)(2.4)), ((V)(2.4)), ((V)((D2_392 - 4D))), ST_394, Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(o_403, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(7.4)), ((V)(0D)), ((V)((W_391 - 6D))), ((V)(1.2)), ((V)((D2_392 - 6D))), GL_395, NewObj(3).Put("r", ((V)(1D))).Put("op", ((V)(0.5))).Put("shine", ((V)(1D))).V));
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis448, int _argc441, V i_447, V _a444, V _a445, V _a446, V[] _rest442) => {
return Invoke(o_403, "push", Call(box_12, V.Undef, ((V)(((-24D) + (ToNum(i_447) * 2D)))), ((V)((8.6 + (ToNum(i_447) * 1.6)))), ((V)(2D)), ((V)(18D)), ((V)(1.6)), ((V)(13D)), GetK(Arr(((V)("#3f7fc8")), ((V)("#2a2d34")), ((V)("#d9363b"))), i_447), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("yaw", ((V)(((ToNum(i_447) * 0.12) - 0.1)))).V)));
}, 1, "", true));
Invoke(o_403, "push", Call(box_12, V.Undef, ((V)(22D)), ((V)(8.6)), ((V)(4D)), ((V)(16D)), ((V)(3D)), ((V)(9D)), ((V)("#2a2c33")), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("yaw", ((V)((-0.3)))).V)), Call(ball_14, V.Undef, ((V)(18D)), ((V)(11.4)), ((V)(2D)), ((V)(1D)), ((V)("#4fd06a")), NewObj(3).Put("k", ((V)(2D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(26D)), ((V)(11.4)), ((V)(6D)), ((V)(1D)), ((V)("#ff5a4a")), NewObj(3).Put("k", ((V)(2D))).Put("n", ((V)(6D))).Put("noOut", ((V)(1D))).V));
Invoke(o_403, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(H_393)), ((V)(0D)), ((V)(W_391)), ((V)(1.6)), ((V)(D2_392)), GL_395, NewObj(3).Put("r", ((V)(2D))).Put("op", ((V)(0.55))).Put("shine", ((V)(1D))).V));
Invoke(o_403, "push", Call(cyl_13, V.Undef, ((V)((-20D))), ((V)((H_393 + 1.6))), ((V)((-6D))), ((V)(9D)), ((V)(5D)), ((V)("#cfe8f2")), NewObj(4).Put("n", ((V)(18D))).Put("op", ((V)(0.55))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))))).V));
R_404 = Call(R0_51, V.Undef, ((V)("candy")));
Call(rep_48, V.Undef, ((V)(10D)), Fn((V _arrowThis456, int _argc449, V i_455, V _a452, V _a453, V _a454, V[] _rest450) => {
return Invoke(o_403, "push", Call(ball_14, V.Undef, ((V)(((-20D) + ((ToNum(Call(R_404, V.Undef)) - 0.5) * 11D)))), ((V)(((H_393 + 3D) + (ToNum(Call(R_404, V.Undef)) * 2D)))), ((V)(((-6D) + ((ToNum(Call(R_404, V.Undef)) - 0.5) * 9D)))), ((V)(1.6)), GetIdx(CASE_52, (ToNum(i_455) % 6D)), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(o_403, "push", Call(cyl_13, V.Undef, ((V)(24D)), ((V)((H_393 + 1.6))), ((V)((-8D))), ((V)(4.6)), ((V)(6D)), ((V)("#e9e2d4")), NewObj(3).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))))).V));
Call(rep_48, V.Undef, ((V)(5D)), Fn((V _arrowThis464, int _argc457, V i_463, V _a460, V _a461, V _a462, V[] _rest458) => {
return Invoke(o_403, "push", Call(ball_14, V.Undef, ((V)((24D + (FdLibm.Cos((ToNum(i_463) * 1.26)) * 2.4)))), ((V)(((H_393 + 7D) + ((ToNum(i_463) % 2D) * 2D)))), ((V)(((-8D) + (FdLibm.Sin((ToNum(i_463) * 1.26)) * 2.4)))), ((V)(2.4)), ((V)((NumTruthy((ToNum(i_463) % 2D)) ? "#6fae5a" : "#86c46a"))), NewObj(3).Put("sy", ((V)(1.3))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(Arr(Arr(((V)(8D)), ((V)(12D))), Arr(((V)((-6D))), ((V)(14D)))), "forEach", Fn((V _arrowThis476, int _argc465, V _a467, V _a468, V _a469, V _a470, V[] _rest466) => {
V x_473 = default;
V z_475 = default;
{ V _t471 = ListOf(_a467);
{ V _t472 = GetIdx(_t471, 0D);
x_473 = _t472; }
{ V _t474 = GetIdx(_t471, 1D);
z_475 = _t474; }
}
return Invoke(o_403, "push", Call(cyl_13, V.Undef, x_473, ((V)((H_393 + 1.6))), z_475, ((V)(4D)), ((V)(0.5)), ((V)("#c9a87a")), NewObj(1).Put("n", ((V)(14D))).V));
}, 1, "", true));
return o_403;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "fridgeT17", Fn((V _arrowThis484, int _argc477, V S_483, V _a480, V _a481, V _a482, V[] _rest478) => {
double W_485 = 0;
double D2_486 = 0;
V BODY_487 = default;
V TOPC_488 = default;
V CANS_489 = default;
W_485 = 120D;
D2_486 = 56D;
BODY_487 = ((V)("#2b2d33"));
TOPC_488 = ((V)("#14161c"));
CANS_489 = Arr(((V)("#d9363b")), ((V)("#3f7fc8")), ((V)("#f2c94c")), ((V)("#4f9a4a")), ((V)("#ff9d4a")), ((V)("#e86fa8")));
return NewObj(7).Put("w", ((V)((W_485 + 6D)))).Put("d", ((V)((D2_486 + 14D)))).Put("topH", ((V)(36.4))).Put("topW", ((V)(70D))).Put("glow", Fn((V _arrowThis496, int _argc490, V _a492, V _a493, V _a494, V _a495, V[] _rest491) => {
return NewObj(3).Put("y", ((V)(18D))).Put("r", ((V)(70D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis503, int _argc497, V _a499, V _a500, V _a501, V _a502, V[] _rest498) => {
V o_504 = default;
o_504 = Arr();
Invoke(o_504, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((W_485 - 10D))), ((V)(4D)), ((V)((D2_486 - 10D))), ((V)("#141519")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(1.4)), ((V)(((D2_486 / 2D) - 4.6))), ((V)((W_485 - 14D))), ((V)(1.2)), ((V)(0.5)), ((V)("#5fc8ff")), Call(em_47, V.Undef)));
Invoke(o_504, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(W_485)), ((V)(30D)), ((V)(D2_486)), BODY_487, Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)((W_485 + 2D))), ((V)(2.4)), ((V)((D2_486 + 2D))), TOPC_488, Call(G__46, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis512, int _argc505, V sg_511, V _a508, V _a509, V _a510, V[] _rest506) => {
double x_513 = 0;
double zf_514 = 0;
x_513 = (ToNum(sg_511) * 29D);
zf_514 = (D2_486 / 2D);
Invoke(o_504, "push", Call(box_12, V.Undef, ((V)(x_513)), ((V)(6.4)), ((V)((zf_514 + 2.4))), ((V)(52D)), ((V)(24D)), ((V)(5D)), ((V)("#3a3d44")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(x_513)), ((V)(8.4)), ((V)((zf_514 + 4.95))), ((V)(47D)), ((V)(20D)), ((V)(0.4)), ((V)("#cfeeff")), Call(em_47, V.Undef, NewObj(1).Put("op", ((V)(0.95))).V)));
Invoke(Arr(Arr(((V)(10.4)), ((V)(0D))), Arr(((V)(19.6)), ((V)(1D)))), "forEach", Fn((V _arrowThis526, int _argc515, V _a517, V _a518, V _a519, V _a520, V[] _rest516) => {
V y_523 = default;
V j_525 = default;
{ V _t521 = ListOf(_a517);
{ V _t522 = GetIdx(_t521, 0D);
y_523 = _t522; }
{ V _t524 = GetIdx(_t521, 1D);
j_525 = _t524; }
}
return Call(rep_48, V.Undef, ((V)(6D)), Fn((V _arrowThis534, int _argc527, V i_533, V _a530, V _a531, V _a532, V[] _rest528) => {
return Invoke(o_504, "push", Call(cyl_13, V.Undef, ((V)(((x_513 - 18.5) + (ToNum(i_533) * 7.4)))), y_523, ((V)((zf_514 + 7.6))), ((V)(2.8)), ((V)(8D)), GetIdx(CANS_489, (ToNum(Add(Add(i_533, ((V)((ToNum(j_525) * 2D)))), ((V)((GtN(sg_511, 0D) ? 3D : 0D))))) % 6D)), Call(M__42, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.85))), Arr(((V)(0.7)), ((V)(0D)), ((V)(1D))), Arr(((V)(8D)), ((V)(0D)), ((V)(0.85))))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(o_504, "push", Call(box_12, V.Undef, ((V)(x_513)), ((V)(6.4)), ((V)((zf_514 + 10.6))), ((V)(52D)), ((V)(24D)), ((V)(0.8)), ((V)("#d8f0ff")), NewObj(3).Put("r", ((V)(1.6))).Put("op", ((V)(0.28))).Put("shine", ((V)(1D))).V), Call(slabX_16, V.Undef, ((V)(x_513)), ((V)(27.2)), ((V)((zf_514 + 11.8))), ((V)(34D)), ((V)(1.6)), ((V)(1.6)), CH_27, Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
Invoke(Arr(((V)(6.4)), ((V)(29.4))), "forEach", Fn((V _arrowThis542, int _argc535, V y_541, V _a538, V _a539, V _a540, V[] _rest536) => {
return Invoke(o_504, "push", Call(slabX_16, V.Undef, ((V)(x_513)), y_541, ((V)((zf_514 + 10.8))), ((V)(52D)), ((V)(1D)), ((V)(1.2)), ((V)("#4a4d55")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(o_504, "push", Call(cyl_13, V.Undef, ((V)(32D)), ((V)(36.4)), ((V)((-8D))), ((V)(9D)), ((V)(0.6)), ((V)("#1d1f26")), NewObj(1).Put("n", ((V)(20D))).V), Call(arcW_17, V.Undef, ((V)(32D)), ((V)(36.6)), ((V)((-8D))), ((V)(8.4)), ((V)(8.4)), ((V)(0.8)), ((V)(0.4)), ((V)(0D)), ((V)((2D * PI_25))), ((V)("#5fc8ff")), Call(em_47, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(box_12, V.Undef, ((V)(32D)), ((V)(37.2)), ((V)((-8D))), ((V)(7.4)), ((V)(0.9)), ((V)(13.6)), ((V)("#23252c")), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(1.6))).Put("yaw", ((V)(0.25))).V)), Call(box_12, V.Undef, ((V)(32D)), ((V)(38.1)), ((V)((-8D))), ((V)(6D)), ((V)(0.2)), ((V)(11.6)), ((V)("#3fa8ff")), Call(em_47, V.Undef, NewObj(3).Put("r", ((V)(1D))).Put("yaw", ((V)(0.25))).Put("op", ((V)(0.75))).V)));
Invoke(o_504, "push", Call(cyl_13, V.Undef, ((V)((-30D))), ((V)(36.4)), ((V)((-6D))), ((V)(10D)), ((V)(4D)), ((V)("#f4efe6")), NewObj(3).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.65))), Arr(((V)(4D)), ((V)(0D)), ((V)(1D))))).V));
Call(rep_48, V.Undef, ((V)(8D)), Fn((V _arrowThis550, int _argc543, V i_549, V _a546, V _a547, V _a548, V[] _rest544) => {
return Invoke(Call(kern_36, V.Undef, ((V)(((-30D) + (FdLibm.Cos((ToNum(i_549) * 0.8)) * 5D)))), ((V)((39.4 + ((ToNum(i_549) % 3D) * 0.8)))), ((V)(((-6D) + (FdLibm.Sin((ToNum(i_549) * 0.8)) * 4D)))), ((V)(1.7)), i_549), "forEach", Fn((V _arrowThis558, int _argc551, V s_557, V _a554, V _a555, V _a556, V[] _rest552) => {
return Invoke(o_504, "push", s_557);
}, 1, "", true));
}, 1, "", true));
return o_504;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis566, int _argc559, V c_565, V _a562, V _a563, V _a564, V[] _rest560) => {
V q_567 = default;
q_567 = Invoke(c_565, "p", ((V)(32D)), ((V)(36.8)), ((V)((-8D))));
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_567, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_567, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((11D * ToNum(Get(c_565, "k"))))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((11D * ToNum(Get(c_565, "k"))) * ToNum(Get(X_9, "SA"))))))).S("\" fill=\"none\" stroke=\"#7fd8ff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.8 * ToNum(Get(c_565, "k"))))))).S("\">").V(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0;0.9;0")), ((V)(2D)))).V(Call(an_39, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((8D * ToNum(Get(c_565, "k"))))))).S(";").V(Call(f1_23, V.Undef, ((V)((13D * ToNum(Get(c_565, "k"))))))).End())), ((V)(2D)))).V(Call(an_39, V.Undef, ((V)("ry")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)(((8D * ToNum(Get(c_565, "k"))) * ToNum(Get(X_9, "SA"))))))).S(";").V(Call(f1_23, V.Undef, ((V)(((13D * ToNum(Get(c_565, "k"))) * ToNum(Get(X_9, "SA"))))))).End())), ((V)(2D)))).S("</ellipse>").V(Call(puffs_54, V.Undef, c_565, ((V)((-29D))), ((V)(30D)), ((V)(((D2_486 / 2D) + 12D))), ((V)(4D)), ((V)("#e8f8ff")), ((V)(3D)))).V(Call(puffs_54, V.Undef, c_565, ((V)(29D)), ((V)(30D)), ((V)(((D2_486 / 2D) + 12D))), ((V)(4D)), ((V)("#e8f8ff")), ((V)(3D)))).End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "holoT17", Fn((V _arrowThis575, int _argc568, V S_574, V _a571, V _a572, V _a573, V[] _rest569) => {
V WH_576 = default;
double R_577 = 0;
WH_576 = ((V)("#f2f4f8"));
R_577 = 32D;
return NewObj(6).Put("w", ((V)(((2D * R_577) + 8D)))).Put("d", ((V)(((2D * R_577) + 8D)))).Put("topH", ((V)(30D))).Put("topW", ((V)(44D))).Put("build", Fn((V _arrowThis584, int _argc578, V _a580, V _a581, V _a582, V _a583, V[] _rest579) => {
V o_585 = default;
o_585 = Arr();
Invoke(o_585, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(18D)), ((V)(3D)), WH_576, Call(G__46, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.86))))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(2.6)), ((V)(0D)), ((V)(18.4)), ((V)(18.4)), ((V)(0.9)), ((V)(0.8)), ((V)(0D)), ((V)((2D * PI_25))), ((V)("#7ff0ff")), Call(em_47, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)));
Invoke(o_585, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(6D)), ((V)(23D)), WH_576, Call(G__46, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(23D)), ((V)(0D)), ((V)(1.4))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(0D)), ((V)(12D)), ((V)(1D)), ((V)("#7ff0ff")), Call(em_47, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)));
Invoke(o_585, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(25D)), ((V)(0D)), ((V)(R_577)), ((V)(3.4)), WH_576, Call(G__46, V.Undef, NewObj(2).Put("n", ((V)(30D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(1.2)), ((V)(0D)), ((V)(1D))), Arr(((V)(3.4)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(28.4)), ((V)(0D)), ((V)((R_577 - 1.6))), ((V)(1.2)), ((V)("#bfefff")), NewObj(3).Put("n", ((V)(30D))).Put("op", ((V)(0.5))).Put("shine", ((V)(1D))).V), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(28.6)), ((V)(0D)), ((V)((R_577 - 0.4))), ((V)((R_577 - 0.4))), ((V)(0.8)), ((V)(0.6)), ((V)(0D)), ((V)((2D * PI_25))), ((V)("#7ff0ff")), Call(em_47, V.Undef, NewObj(1).Put("n", ((V)(30D))).V)));
Call(rep_48, V.Undef, ((V)(8D)), Fn((V _arrowThis593, int _argc586, V i_592, V _a589, V _a590, V _a591, V[] _rest587) => {
double t_594 = 0;
V col_595 = default;
t_594 = (((ToNum(i_592) * PI_25) / 4D) + (PI_25 / 8D));
col_595 = GetIdx(Arr(((V)("#7ff0ff")), ((V)("#ff6fae")), ((V)("#ffd66b")), ((V)("#8fff9e"))), (ToNum(i_592) % 4D));
Invoke(o_585, "push", Call(box_12, V.Undef, ((V)((FdLibm.Cos(t_594) * (R_577 - 7D)))), ((V)(29.7)), ((V)((FdLibm.Sin(t_594) * (R_577 - 7D)))), ((V)(5D)), ((V)(0.3)), ((V)(3D)), col_595, Call(em_47, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("yaw", ((V)((t_594 + (PI_25 / 2D))))).V)));
return default;
}, 1, "", true));
Invoke(o_585, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(29.6)), ((V)(0D)), ((V)(5D)), ((V)(0.6)), ((V)("#1a1d2a")), NewObj(1).Put("n", ((V)(16D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(30.2)), ((V)(0D)), ((V)(3.6)), ((V)(0.3)), ((V)("#7ff0ff")), Call(em_47, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)));
return o_585;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis603, int _argc596, V c_602, V _a599, V _a600, V _a601, V[] _rest597) => {
V b_604 = default;
V t_605 = default;
V k_606 = default;
V cx_607 = default;
V cy_608 = default;
JsStrBuf f_609 = null;
double rr_610 = 0;
V hole_611 = default;
b_604 = Invoke(c_602, "p", ((V)(0D)), ((V)(30.4)), ((V)(0D)));
t_605 = Invoke(c_602, "p", ((V)(0D)), ((V)(62D)), ((V)(0D)));
k_606 = Get(c_602, "k");
cx_607 = Call(f1_23, V.Undef, GetIdx(t_605, 0D));
cy_608 = Call(f1_23, V.Undef, Add(GetIdx(t_605, 1D), ((V)((6D * ToNum(k_606))))));
f_609 = new JsStrBuf("<defs><linearGradient id=\"p17hb\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8ff6ff\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#8ff6ff\" stop-opacity=\"0\"/></linearGradient><pattern id=\"p17sc\" width=\"4\" height=\"1.6\" patternUnits=\"userSpaceOnUse\"><rect width=\"4\" height=\"0.7\" fill=\"#ffffff\" opacity=\"0.35\"/></pattern></defs>");
f_609.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(b_604, 0D)) - (3.6 * ToNum(k_606))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(b_604, 1D))).S("L").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(t_605, 0D)) - (16D * ToNum(k_606))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(t_605, 1D))).S("H").V(Call(f1_23, V.Undef, Add(GetIdx(t_605, 0D), ((V)((16D * ToNum(k_606))))))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(b_604, 0D), ((V)((3.6 * ToNum(k_606))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(b_604, 1D))).S("Z\" fill=\"url(#p17hb)\">").V(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.7;0.95;0.6")), ((V)(2.2)))).S("</path>");
rr_610 = (12D * ToNum(k_606));
hole_611 = Fn((V _arrowThis619, int _argc612, V i_618, V _a615, V _a616, V _a617, V[] _rest613) => {
double a_620 = 0;
a_620 = (((ToNum(i_618) * 2D) * PI_25) / 5D);
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)(((FdLibm.Cos(a_620) * rr_610) * 0.55))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((FdLibm.Sin(a_620) * rr_610) * 0.55))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((rr_610 * 0.2))))).S("\" fill=\"#0d3a4a\" fill-opacity=\"0.55\"/>").End()));
return default;
}, 1, "", true);
f_609.S("<g transform=\"translate(").V(cx_607).S(" ").V(cy_608).S(")\" opacity=\"0.9\">").V(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.85;0.95;0.6;0.95;0.85")), ((V)(1.7)))).S("<g>").S("<animateTransform attributeName=\"transform\" type=\"rotate\" values=\"0;360\" dur=\"6s\" repeatCount=\"indefinite\"/>").S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)(rr_610)))).S("\" fill=\"#8ff6ff\" fill-opacity=\"0.45\" stroke=\"#dffcff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(k_606)))))).S("\"/>").V(Invoke(Call(rep_48, V.Undef, ((V)(5D)), hole_611), "join", ((V)("")))).S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)((rr_610 * 0.16))))).S("\" fill=\"#dffcff\"/></g>").S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)(rr_610)))).S("\" fill=\"url(#p17sc)\"/>").S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((rr_610 * 0.9))))).S(" ").V(Call(f1_23, V.Undef, ((V)((rr_610 * 0.7))))).S("q").V(Call(f1_23, V.Undef, ((V)((rr_610 * 0.6))))).S(" ").V(Call(f1_23, V.Undef, ((V)((rr_610 * 0.3))))).S(" ").V(Call(f1_23, V.Undef, ((V)((rr_610 * 1.1))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-rr_610) * 0.1))))).S("\" stroke=\"#8ff6ff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1.2 * ToNum(k_606)))))).S("\" fill=\"none\" stroke-linecap=\"round\" opacity=\"0.7\"/></g>");
Call(rep_48, V.Undef, ((V)(3D)), Fn((V _arrowThis628, int _argc621, V i_627, V _a624, V _a625, V _a626, V[] _rest622) => {
V a_629 = default;
a_629 = Invoke(c_602, "p", ((V)(((-20D) + (ToNum(i_627) * 20D)))), ((V)((44D + ((ToNum(i_627) % 2D) * 6D)))), ((V)(6D)));
f_609.S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(a_629, 0D)) - (4D * ToNum(k_606))))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(a_629, 1D)) - (2.4 * ToNum(k_606))))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((8D * ToNum(k_606)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((4.8 * ToNum(k_606)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1D * ToNum(k_606)))))).S("\" fill=\"#8ff6ff\" fill-opacity=\"0.18\" stroke=\"#8ff6ff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.4 * ToNum(k_606)))))).S("\">").V(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.3;1;0.3")), ((V)((2D + (ToNum(i_627) * 0.4)))), ((V)(((-ToNum(i_627)) * 0.5))))).S("</rect>");
return default;
}, 1, "", true));
return NewObj(2).Put("front", ((V)(f_609.Str))).Put("bb", Arr(((V)((ToNum(GetIdx(t_605, 0D)) - (26D * ToNum(k_606))))), ((V)((ToNum(GetIdx(t_605, 1D)) - (10D * ToNum(k_606))))), Add(GetIdx(t_605, 0D), ((V)((26D * ToNum(k_606))))), Add(GetIdx(t_605, 1D), ((V)((30D * ToNum(k_606))))))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "tray17", Fn((V _arrowThis637, int _argc630, V S_636, V _a633, V _a634, V _a635, V[] _rest631) => {
V MU_638 = default;
V GT_639 = default;
MU_638 = ((V)("#e8a23a"));
GT_639 = ((V)("#d8b04a"));
return NewObj(5).Put("w", ((V)(50D))).Put("d", ((V)(40D))).Put("topH", ((V)(33.6))).Put("topW", ((V)(26D))).Put("build", Fn((V _arrowThis646, int _argc640, V _a642, V _a643, V _a644, V _a645, V[] _rest641) => {
V o_647 = default;
o_647 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis655, int _argc648, V sx_654, V _a651, V _a652, V _a653, V[] _rest649) => {
double x_656 = 0;
x_656 = (ToNum(sx_654) * 17D);
Invoke(o_647, "push", Call(rod_32, V.Undef, Arr(((V)(x_656)), ((V)(0D)), ((V)((-13D)))), Arr(((V)(x_656)), ((V)(29.4)), ((V)(11D))), ((V)(0.9)), GT_639, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(rod_32, V.Undef, Arr(((V)(x_656)), ((V)(0D)), ((V)(13D))), Arr(((V)(x_656)), ((V)(29.4)), ((V)((-11D)))), ((V)(0.9)), GT_639, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
Invoke(Arr(((V)((-13D))), ((V)(13D))), "forEach", Fn((V _arrowThis664, int _argc657, V z_663, V _a660, V _a661, V _a662, V[] _rest658) => {
return Invoke(o_647, "push", Call(ball_14, V.Undef, ((V)(x_656)), ((V)((-0.4))), z_663, ((V)(1.4)), ((V)("#3a3530")), NewObj(4).Put("k", ((V)(3D))).Put("n", ((V)(6D))).Put("sy", ((V)(0.6))).Put("shine", ((V)(0D))).V));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(o_647, "push", Call(rod_32, V.Undef, Arr(((V)((-17D))), ((V)(3.4)), ((V)((-12D)))), Arr(((V)(17D)), ((V)(3.4)), ((V)((-12D)))), ((V)(0.8)), GT_639, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
Invoke(o_647, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(44D)), ((V)(1.6)), ((V)(32D)), MU_638, Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis672, int _argc665, V s_671, V _a668, V _a669, V _a670, V[] _rest666) => {
Invoke(o_647, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)(31.6)), ((V)((ToNum(s_671) * 15.4))), ((V)(44D)), ((V)(1.6)), ((V)(1.2)), Call(shade_21, V.Undef, MU_638, ((V)(0.82))), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
Invoke(o_647, "push", Call(box_12, V.Undef, ((V)((ToNum(s_671) * 21.4))), ((V)(31.6)), ((V)(0D)), ((V)(1.2)), ((V)(1.6)), ((V)(30D)), Call(shade_21, V.Undef, MU_638, ((V)(0.82))), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-14D))), ((V)((-9D)))), Arr(((V)(14D)), ((V)(8D))), Arr(((V)((-15D))), ((V)(9D))), Arr(((V)(15D)), ((V)((-9D))))), "forEach", Fn((V _arrowThis684, int _argc673, V _a675, V _a676, V _a677, V _a678, V[] _rest674) => {
V x_681 = default;
V z_683 = default;
{ V _t679 = ListOf(_a675);
{ V _t680 = GetIdx(_t679, 0D);
x_681 = _t680; }
{ V _t682 = GetIdx(_t679, 1D);
z_683 = _t682; }
}
Invoke(o_647, "push", Call(cyl_13, V.Undef, x_681, ((V)(31.62)), z_683, ((V)(3.4)), ((V)(0.1)), ((V)("#fff3dc")), NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V), Call(cyl_13, V.Undef, x_681, ((V)(31.7)), z_683, ((V)(1.3)), ((V)(0.1)), ((V)("#e86f2a")), NewObj(2).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).V));
return default;
}, 1, "", true));
Invoke(o_647, "push", Call(box_12, V.Undef, ((V)(1D)), ((V)(31.6)), ((V)(0D)), ((V)(26D)), ((V)(2.2)), ((V)(19D)), ((V)("#c9ced3")), Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(1.6))).V)), Call(slabX_16, V.Undef, ((V)(1D)), ((V)(31.9)), ((V)((-1D))), ((V)(24D)), ((V)(1.8)), ((V)(0.5)), ((V)("#aeb4ba")), Call(M__42, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((-4D))), ((V)(31.9)), ((V)(4.6)), ((V)(0.5)), ((V)(1.8)), ((V)(8D)), ((V)("#aeb4ba")), Call(M__42, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
Invoke(o_647, "push", Call(ball_14, V.Undef, ((V)(5D)), ((V)(33.2)), ((V)((-5D))), ((V)(4.4)), ((V)("#fffaf0")), NewObj(5).Put("sy", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).Put("shine", ((V)(0D))).Put("mat", ((V)("fab"))).V), Call(ball_14, V.Undef, ((V)(4D)), ((V)(35D)), ((V)((-5.6))), ((V)(1D)), ((V)("#ffd34a")), NewObj(3).Put("k", ((V)(2D))).Put("n", ((V)(6D))).Put("sy", ((V)(0.5))).V));
Call(rep_48, V.Undef, ((V)(7D)), Fn((V _arrowThis692, int _argc685, V i_691, V _a688, V _a689, V _a690, V[] _rest686) => {
return Invoke(o_647, "push", Call(ball_14, V.Undef, ((V)(((-9D) + ((ToNum(i_691) % 4D) * 2.2)))), ((V)((33.4 + (GtN(i_691, 3D) ? 0.4 : 0D)))), ((V)((3D + (System.Math.Floor((ToNum(i_691) / 4D)) * 2.6)))), ((V)(1.05)), ((V)("#6fbf4a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
}, 1, "", true));
Invoke(Arr(Arr(((V)(7D)), ((V)(4D))), Arr(((V)(10.4)), ((V)(5D))), Arr(((V)(8.5)), ((V)(7.4)))), "forEach", Fn((V _arrowThis704, int _argc693, V _a695, V _a696, V _a697, V _a698, V[] _rest694) => {
V x_701 = default;
V z_703 = default;
{ V _t699 = ListOf(_a695);
{ V _t700 = GetIdx(_t699, 0D);
x_701 = _t700; }
{ V _t702 = GetIdx(_t699, 1D);
z_703 = _t702; }
}
return Invoke(o_647, "push", Call(ball_14, V.Undef, x_701, ((V)(33.4)), z_703, ((V)(2D)), ((V)("#c8823a")), NewObj(4).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).V));
}, 1, "", true));
Invoke(o_647, "push", Call(rod_32, V.Undef, Arr(((V)((-11D))), ((V)(32.6)), ((V)((-4D)))), Arr(((V)((-11D))), ((V)(32.6)), ((V)(9D))), ((V)(0.45)), ((V)("#e9ecef")), Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)), Call(box_12, V.Undef, ((V)((-11D))), ((V)(32.4)), ((V)((-6D))), ((V)(2.2)), ((V)(0.4)), ((V)(3.4)), ((V)("#e9ecef")), Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
return o_647;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "ctable17", Fn((V _arrowThis712, int _argc705, V S_711, V _a708, V _a709, V _a710, V[] _rest706) => {
V BR_713 = default;
V WAL_714 = default;
BR_713 = ((V)("#d4a548"));
WAL_714 = ((V)("#7a4a2a"));
return NewObj(5).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("topH", ((V)(38.6))).Put("topW", ((V)(22D))).Put("build", Fn((V _arrowThis721, int _argc715, V _a717, V _a718, V _a719, V _a720, V[] _rest716) => {
V o_722 = default;
o_722 = Arr();
Invoke(o_722, "push", Call(box_12, V.Undef, ((V)((-2D))), ((V)(0D)), ((V)(0D)), ((V)(28D)), ((V)(2D)), ((V)(26D)), BR_713, Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(8D))).V)), Call(box_12, V.Undef, ((V)((-15D))), ((V)(2D)), ((V)(0D)), ((V)(3D)), ((V)(34D)), ((V)(16D)), BR_713, Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)), Call(box_12, V.Undef, ((V)((-9D))), ((V)(34D)), ((V)(0D)), ((V)(13D)), ((V)(2D)), ((V)(16D)), BR_713, Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)));
Invoke(o_722, "push", Call(cyl_13, V.Undef, ((V)(1D)), ((V)(36D)), ((V)(0D)), ((V)(17D)), ((V)(2.6)), WAL_714, Call(W__41, V.Undef, NewObj(1).Put("n", ((V)(26D))).V)), Call(arcW_17, V.Undef, ((V)(1D)), ((V)(36D)), ((V)(0D)), ((V)(17.4)), ((V)(17.4)), ((V)(0.7)), ((V)(2.6)), ((V)(0D)), ((V)((2D * PI_25))), BR_713, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(26D))).V)));
Invoke(o_722, "push", Call(cyl_13, V.Undef, ((V)(6D)), ((V)(38.6)), ((V)(4D)), ((V)(5.2)), ((V)(0.7)), ((V)("#b98a58")), NewObj(2).Put("n", ((V)(16D))).Put("mat", ((V)("fab"))).V), Call(cyl_13, V.Undef, ((V)(6D)), ((V)(39.3)), ((V)(4D)), ((V)(3.6)), ((V)(12D)), ((V)("#e8f6ff")), NewObj(4).Put("n", ((V)(14D))).Put("op", ((V)(0.5))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.86))), Arr(((V)(12D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_13, V.Undef, ((V)(6D)), ((V)(39.7)), ((V)(4D)), ((V)(3.1)), ((V)(9D)), ((V)("#6a2a12")), NewObj(2).Put("n", ((V)(14D))).Put("op", ((V)(0.85))).V));
Invoke(o_722, "push", Call(box_12, V.Undef, ((V)(5D)), ((V)(46.6)), ((V)(3D)), ((V)(2.2)), ((V)(2.2)), ((V)(2.2)), ((V)("#ffffff")), NewObj(3).Put("r", ((V)(0.4))).Put("op", ((V)(0.8))).Put("yaw", ((V)(0.4))).V), Call(box_12, V.Undef, ((V)(7D)), ((V)(47.4)), ((V)(5D)), ((V)(2D)), ((V)(2D)), ((V)(2D)), ((V)("#ffffff")), NewObj(3).Put("r", ((V)(0.4))).Put("op", ((V)(0.8))).Put("yaw", ((V)(1D))).V), Call(rod_32, V.Undef, Arr(((V)(6.6)), ((V)(49D)), ((V)(4D))), Arr(((V)(8.4)), ((V)(56D)), ((V)(2.6))), ((V)(0.5)), ((V)("#ff5a7a")), Call(PL_45, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)));
Invoke(o_722, "push", Call(cyl_13, V.Undef, ((V)((-6D))), ((V)(38.6)), ((V)((-5D))), ((V)(6D)), ((V)(4D)), ((V)("#ffffff")), NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(4D)), ((V)(0D)), ((V)(1D))))).V));
Call(rep_48, V.Undef, ((V)(6D)), Fn((V _arrowThis730, int _argc723, V i_729, V _a726, V _a727, V _a728, V[] _rest724) => {
return Invoke(Call(kern_36, V.Undef, ((V)(((-6D) + (FdLibm.Cos(ToNum(i_729)) * 3D)))), ((V)((41.6 + (ToNum(i_729) % 2D)))), ((V)(((-5D) + (FdLibm.Sin(ToNum(i_729)) * 2.6)))), ((V)(1.5)), i_729), "forEach", Fn((V _arrowThis738, int _argc731, V s_737, V _a734, V _a735, V _a736, V[] _rest732) => {
return Invoke(o_722, "push", s_737);
}, 1, "", true));
}, 1, "", true));
return o_722;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "marbleT17", Fn((V _arrowThis746, int _argc739, V S_745, V _a742, V _a743, V _a744, V[] _rest740) => {
V MB_747 = default;
MB_747 = ((V)("#f3efe8"));
return NewObj(6).Put("w", ((V)(44D))).Put("d", ((V)(44D))).Put("topH", ((V)(34D))).Put("topW", ((V)(26D))).Put("build", Fn((V _arrowThis754, int _argc748, V _a750, V _a751, V _a752, V _a753, V[] _rest749) => {
V o_755 = default;
o_755 = Arr();
Invoke(o_755, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(2.6)), GOLD_26, Call(M__42, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(2.6)), ((V)(0D)), ((V)(0.82))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2.6)), ((V)(0D)), ((V)(5D)), ((V)(26D)), GOLD_26, Call(M__42, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.3))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(22D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(26D)), ((V)(0D)), ((V)(1.5))))).V)));
Call(rep_48, V.Undef, ((V)(8D)), Fn((V _arrowThis763, int _argc756, V i_762, V _a759, V _a760, V _a761, V[] _rest757) => {
double t_764 = 0;
t_764 = ((ToNum(i_762) * PI_25) / 4D);
Invoke(o_755, "push", Call(rod_32, V.Undef, Arr(((V)((FdLibm.Cos(t_764) * 4.7))), ((V)(6.6)), ((V)((FdLibm.Sin(t_764) * 4.7)))), Arr(((V)((FdLibm.Cos(t_764) * 4.7))), ((V)(24.6)), ((V)((FdLibm.Sin(t_764) * 4.7)))), ((V)(0.45)), Call(shade_21, V.Undef, GOLD_26, ((V)(0.78))), Call(M__42, V.Undef, NewObj(2).Put("n", ((V)(4D))).Put("noOut", ((V)(1D))).V)));
return default;
}, 1, "", true));
Invoke(o_755, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(28.6)), ((V)(0D)), ((V)(10D)), ((V)(2.4)), GOLD_26, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(31D)), ((V)(0D)), ((V)(19D)), ((V)(3D)), MB_747, NewObj(2).Put("n", ((V)(28D))).Put("mat", ((V)("cer"))).V), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(31D)), ((V)(0D)), ((V)(19.4)), ((V)(19.4)), ((V)(0.8)), ((V)(3D)), ((V)(0D)), ((V)((2D * PI_25))), GOLD_26, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(28D))).V)));
Invoke(o_755, "push", Call(cyl_13, V.Undef, ((V)(4D)), ((V)(34D)), ((V)(2D)), ((V)(6D)), ((V)(0.8)), ((V)("#7fd8ff")), Call(em_47, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_13, V.Undef, ((V)(4D)), ((V)(34.8)), ((V)(2D)), ((V)(3.8)), ((V)(12D)), ((V)("#e8f6ff")), NewObj(4).Put("n", ((V)(14D))).Put("op", ((V)(0.55))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.82))), Arr(((V)(12D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_13, V.Undef, ((V)(4D)), ((V)(35.2)), ((V)(2D)), ((V)(3.2)), ((V)(8.6)), ((V)("#7a3216")), NewObj(2).Put("n", ((V)(14D))).Put("op", ((V)(0.85))).V));
Invoke(o_755, "push", Call(box_12, V.Undef, ((V)(3D)), ((V)(42.4)), ((V)(1.4)), ((V)(2.4)), ((V)(2.4)), ((V)(2.4)), ((V)("#f4fbff")), NewObj(3).Put("r", ((V)(0.5))).Put("op", ((V)(0.85))).Put("yaw", ((V)(0.5))).V), Call(box_12, V.Undef, ((V)(5.4)), ((V)(43D)), ((V)(3D)), ((V)(2D)), ((V)(2D)), ((V)(2D)), ((V)("#f4fbff")), NewObj(3).Put("r", ((V)(0.5))).Put("op", ((V)(0.85))).Put("yaw", ((V)(1.1))).V), Call(disc_18, V.Undef, ((V)(4.6)), ((V)(46.4)), ((V)(5.6)), ((V)(2.6)), ((V)(0.6)), ((V)("#f2d23a")), NewObj(1).Put("n", ((V)(12D))).V));
return o_755;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis772, int _argc765, V c_771, V _a768, V _a769, V _a770, V[] _rest766) => {
V q_773 = default;
V V_774 = default;
V veins_775 = default;
q_773 = Invoke(c_771, "p", ((V)(4D)), ((V)(34.6)), ((V)(2D)));
V_774 = ((V)("<path d=\"M-3 0Q0 -1 3 0\" stroke=\"#b8b2a8\" stroke-width=\"0.5\" fill=\"none\" stroke-linecap=\"round\"/>"));
veins_775 = Invoke(Invoke(Arr(Arr(((V)((-10D))), ((V)((-6D))), ((V)(0.3))), Arr(((V)((-4D))), ((V)(8D)), ((V)((-0.4)))), Arr(((V)(9D)), ((V)((-9D))), ((V)(0.8)))), "map", Fn((V _arrowThis789, int _argc776, V _a778, V _a779, V _a780, V _a781, V[] _rest777) => {
V o_790 = default;
V x_784 = default;
V z_786 = default;
V a_788 = default;
{ V _t782 = ListOf(_a778);
{ V _t783 = GetIdx(_t782, 0D);
x_784 = _t783; }
{ V _t785 = GetIdx(_t782, 1D);
z_786 = _t785; }
{ V _t787 = GetIdx(_t782, 2D);
a_788 = _t787; }
}
o_790 = Invoke(c_771, "p", x_784, ((V)(34.05)), z_786);
return ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(frame_35, V.Undef, Get(c_771, "p"), Arr(x_784, ((V)(34.05)), z_786), Arr(((V)((FdLibm.Cos(ToNum(a_788)) * 2D))), ((V)(0D)), ((V)((FdLibm.Sin(ToNum(a_788)) * 2D)))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))).S("\" opacity=\"0.6\">").V(V_774).S("</g>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().V(veins_775).S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_773, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_773, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((8D * ToNum(Get(c_771, "k"))))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((8D * ToNum(Get(c_771, "k"))) * ToNum(Get(X_9, "SA"))))))).S("\" fill=\"#7fd8ff\" opacity=\"0.3\">").V(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.15;0.45;0.15")), ((V)(2.4)))).S("</ellipse>").V(Call(puffs_54, V.Undef, c_771, ((V)(4D)), ((V)(36D)), ((V)(6.4)), ((V)(5D)), ((V)("#ffffff")), ((V)(3D)))).V(Call(spark_53, V.Undef, c_771, ((V)(1D)), ((V)(44D)), ((V)(6D)), ((V)(0.4)), ((V)((-0.3))))).V(Call(spark_53, V.Undef, c_771, ((V)(8D)), ((V)(40D)), ((V)(6D)), ((V)(0.35)), ((V)((-1.1))))).End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "bot17", Fn((V _arrowThis798, int _argc791, V S_797, V _a794, V _a795, V _a796, V[] _rest792) => {
V WH_799 = default;
V CY_800 = default;
WH_799 = ((V)("#f2f4f8"));
CY_800 = ((V)("#5fe0ff"));
return NewObj(5).Put("w", ((V)(44D))).Put("d", ((V)(48D))).Put("roam", ((V)(1D))).Put("build", Fn((V _arrowThis807, int _argc801, V _a803, V _a804, V _a805, V _a806, V[] _rest802) => {
V o_808 = default;
o_808 = Arr();
Invoke(o_808, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(1.6)), ((V)(0D)), ((V)(15D)), ((V)(5D)), ((V)("#3a3d44")), Call(PL_45, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(1.4)), ((V)(0D)), ((V)(1D))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.92))))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(15.4)), ((V)(15.4)), ((V)(0.9)), ((V)(1D)), ((V)(0D)), ((V)((2D * PI_25))), CY_800, Call(em_47, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)));
Call(rep_48, V.Undef, ((V)(3D)), Fn((V _arrowThis816, int _argc809, V i_815, V _a812, V _a813, V _a814, V[] _rest810) => {
double t_817 = 0;
t_817 = ((((ToNum(i_815) * 2D) * PI_25) / 3D) + (PI_25 / 2D));
Invoke(o_808, "push", Call(ball_14, V.Undef, ((V)((FdLibm.Cos(t_817) * 10D))), ((V)(0D)), ((V)((FdLibm.Sin(t_817) * 10D))), ((V)(2.2)), ((V)("#1d1e22")), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).V));
return default;
}, 1, "", true));
Invoke(o_808, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(15D)), WH_799, Call(G__46, V.Undef, NewObj(3).Put("sy", ((V)(1.22))).Put("k", ((V)(8D))).Put("n", ((V)(20D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(14D)), ((V)(10D)), ((V)(8D)), ((V)(1.4)), ((V)("#1a1d2a")), NewObj(1).Put("r", ((V)(2.4))).V), Call(box_12, V.Undef, ((V)((-2.4))), ((V)(22D)), ((V)(14.8)), ((V)(1.8)), ((V)(1.8)), ((V)(0.4)), ((V)("#ff6fae")), Call(em_47, V.Undef, NewObj(1).Put("r", ((V)(0.9))).V)), Call(box_12, V.Undef, ((V)(1.2)), ((V)(22D)), ((V)(14.8)), ((V)(1.8)), ((V)(1.8)), ((V)(0.4)), CY_800, Call(em_47, V.Undef, NewObj(1).Put("r", ((V)(0.9))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(19D)), ((V)(14.8)), ((V)(7D)), ((V)(1.2)), ((V)(0.4)), ((V)("#8fff9e")), Call(em_47, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
Invoke(o_808, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(41D)), ((V)(0D)), ((V)(7D)), ((V)(3D)), ((V)("#c9ced3")), Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(43D)), ((V)(0D)), ((V)(13D)), WH_799, Call(G__46, V.Undef, NewObj(3).Put("sy", ((V)(0.86))).Put("k", ((V)(7D))).Put("n", ((V)(20D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(47D)), ((V)(9.6)), ((V)(17D)), ((V)(10D)), ((V)(2D)), ((V)("#1a1d2a")), NewObj(1).Put("r", ((V)(4.6))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis825, int _argc818, V sg_824, V _a821, V _a822, V _a823, V[] _rest819) => {
return Invoke(o_808, "push", Call(ball_14, V.Undef, ((V)((ToNum(sg_824) * 12.6))), ((V)(52D)), ((V)(0D)), ((V)(2.6)), ((V)("#c9ced3")), Call(M__42, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(10D))).Put("sx", ((V)(0.6))).V)));
}, 1, "", true));
Invoke(o_808, "push", Call(rod_32, V.Undef, Arr(((V)(0D)), ((V)(64.6)), ((V)(0D))), Arr(((V)(0D)), ((V)(71D)), ((V)((-1D)))), ((V)(0.6)), ((V)("#9aa0a6")), Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(70D)), ((V)((-1D))), ((V)(1.8)), ((V)("#ff5a7a")), Call(em_47, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis833, int _argc826, V sg_832, V _a829, V _a830, V _a831, V[] _rest827) => {
return Invoke(Call(pipe_33, V.Undef, Arr(Arr(((V)((ToNum(sg_832) * 13.6))), ((V)(30D)), ((V)(3D))), Arr(((V)((ToNum(sg_832) * 17D))), ((V)(26D)), ((V)(10D))), Arr(((V)((ToNum(sg_832) * 11D))), ((V)(32D)), ((V)(18D)))), ((V)(1.4)), ((V)("#c9ced3")), Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), "forEach", Fn((V _arrowThis841, int _argc834, V s_840, V _a837, V _a838, V _a839, V[] _rest835) => {
return Invoke(o_808, "push", s_840);
}, 1, "", true));
}, 1, "", true));
Invoke(o_808, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(33.4)), ((V)(18D)), ((V)(13D)), ((V)(1.4)), CH_27, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(34.8)), ((V)(18D)), ((V)(13D)), ((V)(13D)), ((V)(0.8)), ((V)(1D)), ((V)(0D)), ((V)((2D * PI_25))), CH_27, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)));
Invoke(Call(cup_37, V.Undef, ((V)((-5D))), ((V)(34.8)), ((V)(18D)), ((V)(3.4)), ((V)(10D)), ((V)("#d9363b"))), "forEach", Fn((V _arrowThis849, int _argc842, V s_848, V _a845, V _a846, V _a847, V[] _rest843) => {
return Invoke(o_808, "push", s_848);
}, 1, "", true));
Invoke(o_808, "push", Call(cyl_13, V.Undef, ((V)(5D)), ((V)(34.8)), ((V)(19D)), ((V)(4D)), ((V)(7D)), ((V)("#ffffff")), Call(PL_45, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(7D)), ((V)(0D)), ((V)(1D))))).V)));
Call(rep_48, V.Undef, ((V)(6D)), Fn((V _arrowThis857, int _argc850, V i_856, V _a853, V _a854, V _a855, V[] _rest851) => {
return Invoke(Call(kern_36, V.Undef, ((V)((5D + (((ToNum(i_856) % 3D) - 1D) * 2.4)))), ((V)((41.6 + (GtN(i_856, 2D) ? 1.4 : 0D)))), ((V)((19D + (GtN(i_856, 2D) ? 1.6 : (-1D))))), ((V)(1.4)), i_856), "forEach", Fn((V _arrowThis865, int _argc858, V s_864, V _a861, V _a862, V _a863, V[] _rest859) => {
return Invoke(o_808, "push", s_864);
}, 1, "", true));
}, 1, "", true));
return o_808;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis873, int _argc866, V c_872, V _a869, V _a870, V _a871, V[] _rest867) => {
V M_874 = default;
V eye_875 = default;
V a_876 = default;
M_874 = Call(frame_35, V.Undef, Get(c_872, "p"), Arr(((V)(0D)), ((V)(52D)), ((V)(10.7))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
eye_875 = Fn((V _arrowThis884, int _argc877, V x_883, V _a880, V _a881, V _a882, V[] _rest878) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").N((ToNum(x_883) - 1.8)).S("\" y=\"-2.4\" width=\"3.6\" height=\"4.4\" rx=\"1.8\" fill=\"#7ff0ff\"><animate attributeName=\"height\" values=\"4.4;4.4;0.6;4.4;4.4\" keyTimes=\"0;0.9;0.94;0.98;1\" dur=\"3.4s\" repeatCount=\"indefinite\"/><animate attributeName=\"y\" values=\"-2.4;-2.4;-0.3;-2.4;-2.4\" keyTimes=\"0;0.9;0.94;0.98;1\" dur=\"3.4s\" repeatCount=\"indefinite\"/></rect>").End()));
}, 1, "", true);
a_876 = Invoke(c_872, "p", ((V)(0D)), ((V)(72.6)), ((V)((-1D))));
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(M_874).S("\">").V(Call(eye_875, V.Undef, ((V)((-4D))))).V(Call(eye_875, V.Undef, ((V)(4D)))).S("<path d=\"M-2.4 3Q0 4.8 2.4 3\" stroke=\"#7ff0ff\" stroke-width=\"0.8\" fill=\"none\" stroke-linecap=\"round\"/><circle cx=\"-6.6\" cy=\"2.6\" r=\"1.1\" fill=\"#ff8fb4\" opacity=\"0.6\"/><circle cx=\"6.6\" cy=\"2.6\" r=\"1.1\" fill=\"#ff8fb4\" opacity=\"0.6\"/></g>").S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(a_876, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, Add(GetIdx(a_876, 1D), ((V)((1.6 * ToNum(Get(c_872, "k")))))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((3.6 * ToNum(Get(c_872, "k"))))))).S("\" fill=\"#ff5a7a\" opacity=\"0\">").V(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0;0.6;0")), ((V)(1.4)))).S("</circle>").End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "brick17", Fn((V _arrowThis892, int _argc885, V S_891, V _a888, V _a889, V _a890, V[] _rest886) => {
V CB_893 = default;
V PN_894 = default;
double W_895 = 0;
double Dd_896 = 0;
double BH_897 = 0;
double TH_898 = 0;
CB_893 = ((V)("#a9a7a1"));
PN_894 = ((V)("#dcb37a"));
W_895 = 104D;
Dd_896 = 24D;
BH_897 = 11D;
TH_898 = 2.4;
return NewObj(5).Put("w", ((V)((W_895 + 6D)))).Put("d", ((V)((Dd_896 + 6D)))).Put("topH", ((V)((3D * (BH_897 + TH_898))))).Put("topW", ((V)(50D))).Put("build", Fn((V _arrowThis905, int _argc899, V _a901, V _a902, V _a903, V _a904, V[] _rest900) => {
V o_906 = default;
V R_907 = default;
V tape_908 = default;
o_906 = Arr();
R_907 = Call(R0_51, V.Undef, ((V)("vhs")));
Call(rep_48, V.Undef, ((V)(3D)), Fn((V _arrowThis916, int _argc909, V l_915, V _a912, V _a913, V _a914, V[] _rest910) => {
double y_917 = 0;
y_917 = (ToNum(l_915) * (BH_897 + TH_898));
Invoke(Arr(((V)((-40D))), ((V)(40D))), "forEach", Fn((V _arrowThis925, int _argc918, V x_924, V _a921, V _a922, V _a923, V[] _rest919) => {
Invoke(o_906, "push", Call(box_12, V.Undef, x_924, ((V)(y_917)), ((V)(0D)), ((V)(18D)), ((V)(BH_897)), ((V)((Dd_896 - 2D))), Call(shade_21, V.Undef, CB_893, ((V)((1D - (ToNum(l_915) * 0.03))))), NewObj(2).Put("r", ((V)(0.8))).Put("mat", ((V)("paint"))).V));
Invoke(Arr(((V)((-4.2))), ((V)(4.2))), "forEach", Fn((V _arrowThis933, int _argc926, V dx_932, V _a929, V _a930, V _a931, V[] _rest927) => {
return Invoke(o_906, "push", Call(box_12, V.Undef, Add(x_924, dx_932), ((V)((y_917 + 2.2))), ((V)((((Dd_896 - 2D) / 2D) + 0.05))), ((V)(6D)), ((V)((BH_897 - 4.4))), ((V)(0.3)), ((V)("#5a5853")), NewObj(2).Put("r", ((V)(0.8))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(o_906, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((y_917 + BH_897))), ((V)(0D)), ((V)(W_895)), ((V)(TH_898)), ((V)(Dd_896)), PN_894, Call(W__41, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
return default;
}, 1, "", true));
tape_908 = Fn((V _arrowThis945, int _argc934, V x_940, V y_941, V z_942, V yaw_943, V[] _rest935) => {
V col_944 = default;
col_944 = (_argc934 > 4 ? _rest935[0] : V.Undef);
return Arr(Call(box_12, V.Undef, x_940, y_941, z_942, ((V)(3.4)), ((V)(11.4)), ((V)(17D)), ((V)("#1d1d21")), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("yaw", yaw_943).V)), Call(box_12, V.Undef, x_940, Add(y_941, ((V)(1.2))), Add(z_942, ((V)(8.55))), ((V)(3D)), ((V)(9D)), ((V)(0.2)), col_944, NewObj(3).Put("r", ((V)(0.2))).Put("yaw", yaw_943).Put("noOut", ((V)(1D))).V));
}, 5, "", true);
Call(rep_48, V.Undef, ((V)(7D)), Fn((V _arrowThis953, int _argc946, V i_952, V _a949, V _a950, V _a951, V[] _rest947) => {
return Invoke(Call(tape_908, V.Undef, ((V)(((-30D) + (ToNum(i_952) * 4.2)))), ((V)((BH_897 + TH_898))), ((V)(0D)), ((V)(0D)), GetK(CASE_52, i_952)), "forEach", Fn((V _arrowThis961, int _argc954, V s_960, V _a957, V _a958, V _a959, V[] _rest955) => {
return Invoke(o_906, "push", s_960);
}, 1, "", true));
}, 1, "", true));
Invoke(Call(tiltAll_30, V.Undef, Call(tape_908, V.Undef, ((V)(1.6)), ((V)((BH_897 + TH_898))), ((V)(0D)), ((V)(0D)), ((V)("#ffffff"))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)((-0.4))), Arr(((V)(3.4)), ((V)((BH_897 + TH_898))), ((V)(0D)))), "forEach", Fn((V _arrowThis969, int _argc962, V s_968, V _a965, V _a966, V _a967, V[] _rest963) => {
return Invoke(o_906, "push", s_968);
}, 1, "", true));
Call(rep_48, V.Undef, ((V)(4D)), Fn((V _arrowThis977, int _argc970, V i_976, V _a973, V _a974, V _a975, V[] _rest971) => {
return Invoke(o_906, "push", Call(box_12, V.Undef, ((V)(((-18D) + ((ToNum(i_976) % 2D) * 1.4)))), ((V)(((2D * (BH_897 + TH_898)) + (ToNum(i_976) * 3.4)))), ((V)(0D)), ((V)(19D)), ((V)(3.4)), ((V)(11D)), ((V)((NumTruthy((ToNum(i_976) % 2D)) ? "#26262a" : "#1d1d21"))), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("yaw", ((V)(((ToNum(Call(R_907, V.Undef)) - 0.5) * 0.3)))).V)), Call(box_12, V.Undef, ((V)(((-18D) + ((ToNum(i_976) % 2D) * 1.4)))), ((V)((((2D * (BH_897 + TH_898)) + (ToNum(i_976) * 3.4)) + 0.6))), ((V)(5.55)), ((V)(15D)), ((V)(2.2)), ((V)(0.2)), GetK(CASE_52, Add(i_976, ((V)(3D)))), NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
Invoke(o_906, "push", Call(cyl_13, V.Undef, ((V)(16D)), ((V)((2D * (BH_897 + TH_898)))), ((V)(2D)), ((V)(4.4)), ((V)(8D)), ((V)("#c9ced3")), Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_13, V.Undef, ((V)(16D)), ((V)(((2D * (BH_897 + TH_898)) + 3D))), ((V)(2D)), ((V)(4.5)), ((V)(2.6)), ((V)("#d9363b")), NewObj(2).Put("n", ((V)(14D))).Put("noOut", ((V)(1D))).V));
Call(rep_48, V.Undef, ((V)(5D)), Fn((V _arrowThis985, int _argc978, V i_984, V _a981, V _a982, V _a983, V[] _rest979) => {
double t_986 = 0;
t_986 = (ToNum(i_984) * 1.25);
Invoke(o_906, "push", Call(ball_14, V.Undef, ((V)((16D + (FdLibm.Cos(t_986) * 2.2)))), ((V)((((2D * (BH_897 + TH_898)) + 8D) + ((ToNum(i_984) % 2D) * 3D)))), ((V)((2D + (FdLibm.Sin(t_986) * 2.2)))), ((V)(2.6)), ((V)((NumTruthy((ToNum(i_984) % 2D)) ? "#5fa84a" : "#79c25a"))), NewObj(3).Put("sy", ((V)(1.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
return default;
}, 1, "", true));
{
double y_987 = 0;
y_987 = (3D * (BH_897 + TH_898));
Invoke(o_906, "push", Call(box_12, V.Undef, ((V)((-10D))), ((V)(y_987)), ((V)(0D)), ((V)(5D)), ((V)(14D)), ((V)(19D)), ((V)("#f7f3ea")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)((-10D))), ((V)((y_987 + 2D))), ((V)(9.55)), ((V)(4.6)), ((V)(10D)), ((V)(0.2)), ((V)("#ff9d4a")), NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V), Call(box_12, V.Undef, ((V)((-4D))), ((V)(y_987)), ((V)(0D)), ((V)(5D)), ((V)(14D)), ((V)(19D)), ((V)("#26262a")), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("yaw", ((V)(0.06))).V)));
}
Invoke(o_906, "push", Call(box_12, V.Undef, ((V)(24D)), ((V)((3D * (BH_897 + TH_898)))), ((V)(0D)), ((V)(22D)), ((V)(9D)), ((V)(10D)), ((V)("#4a4c52")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(1.4))).V)), Call(cyl_13, V.Undef, ((V)(18D)), ((V)(((3D * (BH_897 + TH_898)) + 4.5))), ((V)(5.1)), ((V)(3.2)), ((V)(0.4)), ((V)("#2a2a2e")), NewObj(1).Put("n", ((V)(14D))).V));
Invoke(o_906, "push", Call(disc_18, V.Undef, ((V)(18D)), ((V)(((3D * (BH_897 + TH_898)) + 4.5))), ((V)(5.1)), ((V)(3.2)), ((V)(0.5)), ((V)("#2a2a2e")), NewObj(1).Put("n", ((V)(14D))).V), Call(disc_18, V.Undef, ((V)(30D)), ((V)(((3D * (BH_897 + TH_898)) + 4.5))), ((V)(5.1)), ((V)(3.2)), ((V)(0.5)), ((V)("#2a2a2e")), NewObj(1).Put("n", ((V)(14D))).V), Call(box_12, V.Undef, ((V)(24D)), ((V)(((3D * (BH_897 + TH_898)) + 7D))), ((V)(5.2)), ((V)(5D)), ((V)(1.4)), ((V)(0.3)), ((V)("#7dff9e")), Call(em_47, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(rod_32, V.Undef, Arr(((V)(16D)), ((V)(((3D * (BH_897 + TH_898)) + 9D))), ((V)(0D))), Arr(((V)(32D)), ((V)(((3D * (BH_897 + TH_898)) + 9D))), ((V)(0D))), ((V)(0.6)), ((V)("#9aa0a6")), Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)));
return o_906;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "dvd17", Fn((V _arrowThis995, int _argc988, V S_994, V _a991, V _a992, V _a993, V[] _rest989) => {
V ST_996 = default;
V TY_997 = default;
double RR_998 = 0;
ST_996 = ((V)("#2c2e33"));
TY_997 = Arr(((V)(6D)), ((V)(28D)), ((V)(50D)), ((V)(72D)));
RR_998 = 13D;
return NewObj(3).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis1005, int _argc999, V _a1001, V _a1002, V _a1003, V _a1004, V[] _rest1000) => {
V o_1006 = default;
o_1006 = Arr();
Invoke(o_1006, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(2.4)), ST_996, Call(M__42, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(2.4)), ((V)(0D)), ((V)(0.9))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2.4)), ((V)(0D)), ((V)(1.4)), ((V)(92D)), CH_27, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(93D)), ((V)(0D)), ((V)(3D)), ((V)("#d9363b")), Call(G__46, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)));
Invoke(TY_997, "forEach", Fn((V _arrowThis1015, int _argc1007, V y_1013, V l_1014, V _a1011, V _a1012, V[] _rest1008) => {
Invoke(o_1006, "push", Call(cyl_13, V.Undef, ((V)(0D)), y_1013, ((V)(0D)), ((V)((RR_998 + 1D))), ((V)(1D)), ST_996, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), Add(y_1013, ((V)(13D))), ((V)(0D)), ((V)((RR_998 + 1D))), ((V)((RR_998 + 1D))), ((V)(0.8)), ((V)(0.8)), ((V)(0D)), ((V)((2D * PI_25))), ST_996, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)));
Call(rep_48, V.Undef, ((V)(10D)), Fn((V _arrowThis1023, int _argc1016, V i_1022, V _a1019, V _a1020, V _a1021, V[] _rest1017) => {
double t_1024 = 0;
V col_1025 = default;
t_1024 = ((((ToNum(i_1022) * 2D) * PI_25) / 10D) + (ToNum(l_1014) * 0.3));
col_1025 = GetIdx(CASE_52, (ToNum(Add(i_1022, ((V)((ToNum(l_1014) * 3D))))) % ToNum(Get(CASE_52, "length"))));
Invoke(o_1006, "push", Call(box_12, V.Undef, ((V)((FdLibm.Cos(t_1024) * (RR_998 - 2D)))), Add(y_1013, ((V)(1D))), ((V)((FdLibm.Sin(t_1024) * (RR_998 - 2D)))), ((V)(7.4)), ((V)(11D)), ((V)(1.4)), col_1025, Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("yaw", ((V)((t_1024 + (PI_25 / 2D))))).V)), Call(box_12, V.Undef, ((V)((FdLibm.Cos(t_1024) * (RR_998 - 1.25)))), Add(y_1013, ((V)(7D))), ((V)((FdLibm.Sin(t_1024) * (RR_998 - 1.25)))), ((V)(5D)), ((V)(3D)), ((V)(0.1)), ((V)("#ffffff")), NewObj(4).Put("r", ((V)(0.3))).Put("yaw", ((V)((t_1024 + (PI_25 / 2D))))).Put("noOut", ((V)(1D))).Put("op", ((V)(0.75))).V));
return default;
}, 1, "", true));
Call(rep_48, V.Undef, ((V)(4D)), Fn((V _arrowThis1033, int _argc1026, V i_1032, V _a1029, V _a1030, V _a1031, V[] _rest1027) => {
double t_1034 = 0;
t_1034 = (((ToNum(i_1032) * PI_25) / 2D) + (PI_25 / 4D));
Invoke(o_1006, "push", Call(rod_32, V.Undef, Arr(((V)((FdLibm.Cos(t_1034) * (RR_998 + 0.6)))), Add(y_1013, ((V)(1D))), ((V)((FdLibm.Sin(t_1034) * (RR_998 + 0.6))))), Arr(((V)((FdLibm.Cos(t_1034) * (RR_998 + 0.6)))), Add(y_1013, ((V)(13.4))), ((V)((FdLibm.Sin(t_1034) * (RR_998 + 0.6))))), ((V)(0.4)), ST_996, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)));
return default;
}, 1, "", true));
return default;
}, 2, "", true));
return o_1006;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "console17", Fn((V _arrowThis1042, int _argc1035, V S_1041, V _a1038, V _a1039, V _a1040, V[] _rest1036) => {
double W_1043 = 0;
double Dd_1044 = 0;
V WAL_1045 = default;
V WL_1046 = default;
V WD_1047 = default;
V BR_1048 = default;
W_1043 = 140D;
Dd_1044 = 40D;
WAL_1045 = ((V)("#7a4a2a"));
WL_1046 = Call(shade_21, V.Undef, WAL_1045, ((V)(1.18)));
WD_1047 = Call(shade_21, V.Undef, WAL_1045, ((V)(0.72)));
BR_1048 = ((V)("#d4a548"));
return NewObj(5).Put("w", ((V)((W_1043 + 8D)))).Put("d", ((V)((Dd_1044 + 8D)))).Put("topH", ((V)(42.4))).Put("topW", ((V)(80D))).Put("build", Fn((V _arrowThis1055, int _argc1049, V _a1051, V _a1052, V _a1053, V _a1054, V[] _rest1050) => {
V o_1056 = default;
o_1056 = Arr();
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis1068, int _argc1057, V _a1059, V _a1060, V _a1061, V _a1062, V[] _rest1058) => {
V sx_1065 = default;
V sz_1067 = default;
{ V _t1063 = ListOf(_a1059);
{ V _t1064 = GetIdx(_t1063, 0D);
sx_1065 = _t1064; }
{ V _t1066 = GetIdx(_t1063, 1D);
sz_1067 = _t1066; }
}
return Invoke(o_1056, "push", Call(rod_32, V.Undef, Arr(((V)((ToNum(sx_1065) * ((W_1043 / 2D) - 9D)))), ((V)(12D)), ((V)((ToNum(sz_1067) * ((Dd_1044 / 2D) - 7D))))), Arr(((V)((ToNum(sx_1065) * ((W_1043 / 2D) - 4D)))), ((V)(0D)), ((V)((ToNum(sz_1067) * ((Dd_1044 / 2D) - 3D))))), ((V)(1.8)), WD_1047, Call(W__41, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
Invoke(o_1056, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(W_1043)), ((V)(28D)), ((V)(Dd_1044)), WAL_1045, Call(W__41, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)((W_1043 + 2D))), ((V)(2.4)), ((V)((Dd_1044 + 2D))), WL_1046, Call(W__41, V.Undef, NewObj(1).Put("r", ((V)(1.6))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1076, int _argc1069, V sg_1075, V _a1072, V _a1073, V _a1074, V[] _rest1070) => {
double x_1077 = 0;
x_1077 = (ToNum(sg_1075) * 46D);
Invoke(o_1056, "push", Call(box_12, V.Undef, ((V)(x_1077)), ((V)(14D)), ((V)(((Dd_1044 / 2D) + 0.4))), ((V)(44D)), ((V)(24D)), ((V)(1D)), WL_1046, Call(W__41, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Call(rep_48, V.Undef, ((V)(10D)), Fn((V _arrowThis1085, int _argc1078, V i_1084, V _a1081, V _a1082, V _a1083, V[] _rest1079) => {
return Invoke(o_1056, "push", Call(box_12, V.Undef, ((V)(((x_1077 - 19.8) + (ToNum(i_1084) * 4.4)))), ((V)(15D)), ((V)(((Dd_1044 / 2D) + 1.1))), ((V)(2.4)), ((V)(22D)), ((V)(0.8)), (NumTruthy((ToNum(i_1084) % 2D)) ? WAL_1045 : Call(shade_21, V.Undef, WAL_1045, ((V)(0.88)))), Call(W__41, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}, 1, "", true));
Invoke(o_1056, "push", Call(ball_14, V.Undef, ((V)((x_1077 - (ToNum(sg_1075) * 18D)))), ((V)(25.4)), ((V)(((Dd_1044 / 2D) + 2.2))), ((V)(1.2)), BR_1048, Call(M__42, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sz", ((V)(0.6))).V)));
return default;
}, 1, "", true));
Invoke(Arr(((V)(14D)), ((V)(26D))), "forEach", Fn((V _arrowThis1093, int _argc1086, V y_1092, V _a1089, V _a1090, V _a1091, V[] _rest1087) => {
Invoke(o_1056, "push", Call(box_12, V.Undef, ((V)(0D)), y_1092, ((V)(((Dd_1044 / 2D) + 0.4))), ((V)(44D)), ((V)(11D)), ((V)(1.2)), WL_1046, Call(W__41, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slabX_16, V.Undef, ((V)(0D)), Add(y_1092, ((V)(7.4))), ((V)(((Dd_1044 / 2D) + 1.4))), ((V)(12D)), ((V)(1.4)), ((V)(1D)), BR_1048, Call(M__42, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
return default;
}, 1, "", true));
Invoke(o_1056, "push", Call(cyl_13, V.Undef, ((V)((-50D))), ((V)(42.4)), ((V)((-4D))), ((V)(5D)), ((V)(9D)), ((V)("#e9e2d4")), NewObj(3).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V));
Call(rep_48, V.Undef, ((V)(7D)), Fn((V _arrowThis1101, int _argc1094, V i_1100, V _a1097, V _a1098, V _a1099, V[] _rest1095) => {
double t_1102 = 0;
t_1102 = (ToNum(i_1100) * 0.9);
Invoke(o_1056, "push", Call(tilt_29, V.Undef, Call(box_12, V.Undef, ((V)(((-50D) + (FdLibm.Cos(t_1102) * 2.4)))), ((V)(50D)), ((V)(((-4D) + (FdLibm.Sin(t_1102) * 2.4)))), ((V)(2.4)), ((V)(14D)), ((V)(1D)), ((V)((NumTruthy((ToNum(i_1100) % 2D)) ? "#5fa84a" : "#79c25a"))), NewObj(1).Put("r", ((V)(1D))).V), Arr(((V)(FdLibm.Sin(t_1102))), ((V)(0D)), ((V)((-FdLibm.Cos(t_1102))))), ((V)(0.45)), Arr(((V)((-50D))), ((V)(50D)), ((V)((-4D))))));
return default;
}, 1, "", true));
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis1110, int _argc1103, V i_1109, V _a1106, V _a1107, V _a1108, V[] _rest1104) => {
return Invoke(o_1056, "push", Call(box_12, V.Undef, ((V)((40D + (ToNum(i_1109) * 0.8)))), ((V)((42.4 + (ToNum(i_1109) * 1.8)))), ((V)((-2D))), ((V)(16D)), ((V)(1.8)), ((V)(12D)), GetK(Arr(((V)("#3f7fc8")), ((V)("#d9363b")), ((V)("#2a2d34"))), i_1109), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("yaw", ((V)(((ToNum(i_1109) * 0.15) - 0.1)))).V)));
}, 1, "", true));
Invoke(o_1056, "push", Call(cyl_13, V.Undef, ((V)(14D)), ((V)(42.4)), ((V)((-8D))), ((V)(9D)), ((V)(1.4)), ((V)("#1a1a1d")), NewObj(1).Put("n", ((V)(20D))).V), Call(cyl_13, V.Undef, ((V)(14D)), ((V)(43.8)), ((V)((-8D))), ((V)(2D)), ((V)(0.6)), ((V)("#e86f5a")), NewObj(1).Put("n", ((V)(10D))).V), Call(box_12, V.Undef, ((V)((-6D))), ((V)(42.4)), ((V)((-6D))), ((V)(16D)), ((V)(3D)), ((V)(12D)), ((V)("#26272b")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(1.4))).V)), Call(ball_14, V.Undef, ((V)((-2D))), ((V)(45.4)), ((V)((-1D))), ((V)(0.8)), ((V)("#5fe0ff")), Call(em_47, V.Undef, NewObj(2).Put("k", ((V)(2D))).Put("n", ((V)(6D))).V)));
return o_1056;
return default;
}, 0, "build", true)).V;
return default;
}, 1, "", true));
Set(N_24, "vault17", Fn((V _arrowThis1118, int _argc1111, V S_1117, V _a1114, V _a1115, V _a1116, V[] _rest1112) => {
double W_1119 = 0;
double Dd_1120 = 0;
double H_1121 = 0;
V FR_1122 = default;
V STL_1123 = default;
W_1119 = 92D;
Dd_1120 = 34D;
H_1121 = 150D;
FR_1122 = ((V)("#1e1d22"));
STL_1123 = Arr(((V)("#aab3bb")), ((V)("#7d858e")), ((V)("#d4a548")), ((V)("#9a3a3a")), ((V)("#3f6aa8")), ((V)("#c9ced3")), ((V)("#5a5e66")), ((V)("#b07a3a")));
return NewObj(4).Put("w", ((V)((W_1119 + 6D)))).Put("d", ((V)((Dd_1120 + 8D)))).Put("build", Fn((V _arrowThis1130, int _argc1124, V _a1126, V _a1127, V _a1128, V _a1129, V[] _rest1125) => {
V o_1131 = default;
V sh_1132 = default;
o_1131 = Arr();
Invoke(o_1131, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(W_1119)), ((V)(8D)), ((V)(Dd_1120)), FR_1122, Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((H_1121 - 6D))), ((V)(0D)), ((V)((W_1119 + 2D))), ((V)(6D)), ((V)((Dd_1120 + 2D))), FR_1122, Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(slab_15, V.Undef, ((V)(0D)), ((V)(8D)), ((V)((((-Dd_1120) / 2D) + 1.5))), ((V)((W_1119 - 4D))), ((V)((H_1121 - 14D))), ((V)(2D)), ((V)("#2c2a36")), NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("pl"))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1140, int _argc1133, V sg_1139, V _a1136, V _a1137, V _a1138, V[] _rest1134) => {
return Invoke(o_1131, "push", Call(box_12, V.Undef, ((V)((ToNum(sg_1139) * ((W_1119 / 2D) - 2D)))), ((V)(8D)), ((V)(0D)), ((V)(4D)), ((V)((H_1121 - 14D))), ((V)(Dd_1120)), FR_1122, Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
sh_1132 = Arr(((V)(8D)), ((V)(35D)), ((V)(62D)), ((V)(89D)), ((V)(116D)));
Invoke(sh_1132, "forEach", Fn((V _arrowThis1149, int _argc1141, V y_1147, V l_1148, V _a1145, V _a1146, V[] _rest1142) => {
if (Truthy(l_1148)) {
Invoke(o_1131, "push", Call(box_12, V.Undef, ((V)(0D)), y_1147, ((V)(0D)), ((V)((W_1119 - 8D))), ((V)(1.2)), ((V)((Dd_1120 - 4D))), ((V)("#cfe8f2")), NewObj(3).Put("r", ((V)(0.5))).Put("op", ((V)(0.45))).Put("shine", ((V)(1D))).V));
}
Invoke(o_1131, "push", Call(slabX_16, V.Undef, ((V)(0D)), Add(y_1147, ((V)(26D))), ((V)(((Dd_1120 / 2D) - 4D))), ((V)((W_1119 - 10D))), ((V)(0.8)), ((V)(0.8)), ((V)("#fff2c8")), Call(em_47, V.Undef)));
Call(rep_48, V.Undef, ((V)(6D)), Fn((V _arrowThis1157, int _argc1150, V i_1156, V _a1153, V _a1154, V _a1155, V[] _rest1151) => {
double x_1158 = 0;
V col_1159 = default;
double yaw_1160 = 0;
V front_1161 = default;
x_1158 = ((((-W_1119) / 2D) + 13D) + (ToNum(i_1156) * 13.2));
col_1159 = GetIdx(STL_1123, (ToNum(Add(i_1156, ((V)((ToNum(l_1148) * 3D))))) % ToNum(Get(STL_1123, "length"))));
yaw_1160 = ((SEqN(i_1156, 2D) || SEqN(i_1156, 5D)) ? 0.35 : 0D);
front_1161 = ((yaw_1160 == 0D) ? V.True : V.False);
Invoke(o_1131, "push", Call(box_12, V.Undef, ((V)(x_1158)), Add(y_1147, ((V)(1.2))), ((V)((Truthy(front_1161) ? (-4D) : (-2D)))), ((V)(10D)), ((V)((16D - ((ToNum(i_1156) % 2D) * 1.6)))), ((V)(1.6)), col_1159, Call(M__42, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("yaw", ((V)(yaw_1160))).V)), Call(box_12, V.Undef, ((V)(x_1158)), Add(Add(y_1147, ((V)(4D))), ((V)((ToNum(i_1156) % 2D)))), ((V)(((Truthy(front_1161) ? (-4D) : (-2D)) + 0.85))), ((V)(7D)), ((V)(6D)), ((V)(0.2)), Call(shade_21, V.Undef, col_1159, ((V)(1.35))), NewObj(3).Put("r", ((V)(0.6))).Put("yaw", ((V)(yaw_1160))).Put("noOut", ((V)(1D))).V));
if (!(Truthy(front_1161))) {
Invoke(o_1131, "push", Call(box_12, V.Undef, ((V)(x_1158)), Add(y_1147, ((V)(1.2))), ((V)(0.6)), ((V)(7D)), ((V)(2D)), ((V)(4D)), ((V)("#2c2e33")), Call(PL_45, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("yaw", ((V)(yaw_1160))).V)));
}
return default;
}, 1, "", true));
return default;
}, 2, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1169, int _argc1162, V sg_1168, V _a1165, V _a1166, V _a1167, V[] _rest1163) => {
double x_1170 = 0;
x_1170 = (ToNum(sg_1168) * ((W_1119 / 4D) - 0.6));
Invoke(o_1131, "push", Call(box_12, V.Undef, ((V)(x_1170)), ((V)(9D)), ((V)(((Dd_1120 / 2D) + 0.8))), ((V)(((W_1119 / 2D) - 3.6))), ((V)((H_1121 - 16D))), ((V)(0.8)), ((V)("#d6eef8")), NewObj(4).Put("r", ((V)(1D))).Put("op", ((V)(0.2))).Put("shine", ((V)(1D))).Put("noOut", ((V)(1D))).V));
Invoke(Arr(((V)(9D)), ((V)((H_1121 - 9D)))), "forEach", Fn((V _arrowThis1178, int _argc1171, V y_1177, V _a1174, V _a1175, V _a1176, V[] _rest1172) => {
return Invoke(o_1131, "push", Call(slabX_16, V.Undef, ((V)(x_1170)), ((V)((ToNum(y_1177) - 0.8))), ((V)(((Dd_1120 / 2D) + 1D))), ((V)(((W_1119 / 2D) - 3.6))), ((V)(1.6)), ((V)(1.4)), FR_1122, Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Invoke(Arr(((V)((x_1170 - (ToNum(sg_1168) * ((W_1119 / 4D) - 2.4))))), ((V)((x_1170 + (ToNum(sg_1168) * ((W_1119 / 4D) - 2.4)))))), "forEach", Fn((V _arrowThis1186, int _argc1179, V xx_1185, V _a1182, V _a1183, V _a1184, V[] _rest1180) => {
return Invoke(o_1131, "push", Call(box_12, V.Undef, xx_1185, ((V)(9D)), ((V)(((Dd_1120 / 2D) + 1D))), ((V)(1.6)), ((V)((H_1121 - 18D))), ((V)(1.4)), FR_1122, Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Invoke(o_1131, "push", Call(rod_32, V.Undef, Arr(((V)((ToNum(sg_1168) * 3.4))), ((V)(60D)), ((V)(((Dd_1120 / 2D) + 3D)))), Arr(((V)((ToNum(sg_1168) * 3.4))), ((V)(92D)), ((V)(((Dd_1120 / 2D) + 3D)))), ((V)(0.8)), GOLD_26, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(rod_32, V.Undef, Arr(((V)((ToNum(sg_1168) * 3.4))), ((V)(60D)), ((V)(((Dd_1120 / 2D) + 1.6)))), Arr(((V)((ToNum(sg_1168) * 3.4))), ((V)(60D)), ((V)(((Dd_1120 / 2D) + 3D)))), ((V)(0.6)), GOLD_26, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)), Call(rod_32, V.Undef, Arr(((V)((ToNum(sg_1168) * 3.4))), ((V)(92D)), ((V)(((Dd_1120 / 2D) + 1.6)))), Arr(((V)((ToNum(sg_1168) * 3.4))), ((V)(92D)), ((V)(((Dd_1120 / 2D) + 3D)))), ((V)(0.6)), GOLD_26, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(4D))).V)));
return default;
}, 1, "", true));
Invoke(o_1131, "push", Call(box_12, V.Undef, ((V)(((W_1119 / 2D) + 0.4))), ((V)(70D)), ((V)(((Dd_1120 / 2D) - 6D))), ((V)(1.2)), ((V)(9D)), ((V)(6D)), ((V)("#26272b")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)(((W_1119 / 2D) + 1.1))), ((V)(76D)), ((V)(((Dd_1120 / 2D) - 6D))), ((V)(0.3)), ((V)(1.6)), ((V)(4D)), ((V)("#7dff9e")), Call(em_47, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
return o_1131;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1194, int _argc1187, V c_1193, V _a1190, V _a1191, V _a1192, V[] _rest1188) => {
V A_1195 = default;
V B_1196 = default;
V k_1197 = default;
A_1195 = Invoke(c_1193, "p", ((V)((((-W_1119) / 2D) + 4D))), ((V)((H_1121 - 10D))), ((V)(((Dd_1120 / 2D) + 1.4))));
B_1196 = Invoke(c_1193, "p", ((V)(((W_1119 / 2D) - 4D))), ((V)(10D)), ((V)(((Dd_1120 / 2D) + 1.4))));
k_1197 = Get(c_1193, "k");
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<defs><clipPath id=\"p17vc\"><path d=\"M").V(Call(P2_49, V.Undef, Invoke(c_1193, "p", ((V)((((-W_1119) / 2D) + 3D))), ((V)((H_1121 - 9D))), ((V)(((Dd_1120 / 2D) + 1.4)))))).S("L").V(Call(P2_49, V.Undef, Invoke(c_1193, "p", ((V)(((W_1119 / 2D) - 3D))), ((V)((H_1121 - 9D))), ((V)(((Dd_1120 / 2D) + 1.4)))))).S("L").V(Call(P2_49, V.Undef, Invoke(c_1193, "p", ((V)(((W_1119 / 2D) - 3D))), ((V)(9D)), ((V)(((Dd_1120 / 2D) + 1.4)))))).S("L").V(Call(P2_49, V.Undef, Invoke(c_1193, "p", ((V)((((-W_1119) / 2D) + 3D))), ((V)(9D)), ((V)(((Dd_1120 / 2D) + 1.4)))))).S("Z\"/></clipPath></defs><g clip-path=\"url(#p17vc)\"><rect x=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(A_1195, 0D)) - (30D * ToNum(k_1197))))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((Min(ToNum(GetIdx(A_1195, 1D)), ToNum(GetIdx(B_1196, 1D))) - (20D * ToNum(k_1197))))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((16D * ToNum(k_1197)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((System.Math.Abs((ToNum(GetIdx(B_1196, 1D)) - ToNum(GetIdx(A_1195, 1D)))) + (60D * ToNum(k_1197))))))).S("\" fill=\"#ffffff\" opacity=\"0.22\" transform=\"skewX(-20)\">").V(Call(an_39, V.Undef, ((V)("x")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(A_1195, 0D)) - (60D * ToNum(k_1197))))))).S(";").V(Call(f1_23, V.Undef, Add(GetIdx(B_1196, 0D), ((V)((60D * ToNum(k_1197))))))).End())), ((V)(6D)))).S("</rect></g>").End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "holoLib17", Fn((V _arrowThis1205, int _argc1198, V S_1204, V _a1201, V _a1202, V _a1203, V[] _rest1199) => {
V WH_1206 = default;
WH_1206 = ((V)("#eef1f6"));
return NewObj(5).Put("w", ((V)(56D))).Put("d", ((V)(56D))).Put("glow", Fn((V _arrowThis1213, int _argc1207, V _a1209, V _a1210, V _a1211, V _a1212, V[] _rest1208) => {
return NewObj(3).Put("y", ((V)(40D))).Put("r", ((V)(60D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1220, int _argc1214, V _a1216, V _a1217, V _a1218, V _a1219, V[] _rest1215) => {
V o_1221 = default;
o_1221 = Arr();
Invoke(o_1221, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(4D)), WH_1206, Call(G__46, V.Undef, NewObj(2).Put("n", ((V)(26D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.9))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(15D)), ((V)(7D)), WH_1206, Call(G__46, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(7D)), ((V)(0D)), ((V)(0.82))))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(3.6)), ((V)(0D)), ((V)(22.4)), ((V)(22.4)), ((V)(1D)), ((V)(0.8)), ((V)(0D)), ((V)((2D * PI_25))), ((V)("#7ff0ff")), Call(em_47, V.Undef, NewObj(1).Put("n", ((V)(26D))).V)));
Invoke(o_1221, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(11D)), ((V)(0D)), ((V)(11D)), ((V)(1D)), ((V)("#1a1d2a")), NewObj(1).Put("n", ((V)(20D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(8D)), ((V)(0.6)), ((V)("#7ff0ff")), Call(em_47, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
Call(rep_48, V.Undef, ((V)(3D)), Fn((V _arrowThis1229, int _argc1222, V i_1228, V _a1225, V _a1226, V _a1227, V[] _rest1223) => {
return Invoke(o_1221, "push", Call(box_12, V.Undef, ((V)(((-6D) + (ToNum(i_1228) * 6D)))), ((V)(6D)), ((V)(13.6)), ((V)(3.4)), ((V)(1.4)), ((V)(0.6)), GetK(Arr(((V)("#7ff0ff")), ((V)("#ff6fae")), ((V)("#ffd66b"))), i_1228), Call(em_47, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}, 1, "", true));
return o_1221;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1237, int _argc1230, V c_1236, V _a1233, V _a1234, V _a1235, V[] _rest1231) => {
V k_1238 = default;
V b_1239 = default;
V t_1240 = default;
V ring_1241 = default;
JsStrBuf f_1242 = null;
V s_1243 = default;
k_1238 = Get(c_1236, "k");
b_1239 = Invoke(c_1236, "p", ((V)(0D)), ((V)(12.6)), ((V)(0D)));
t_1240 = Invoke(c_1236, "p", ((V)(0D)), ((V)(86D)), ((V)(0D)));
ring_1241 = Fn((V _arrowThis1258, int _argc1244, V y_1250, V r_1251, V n_1252, V d_1253, V[] _rest1245) => {
V q_1259 = default;
double rx_1260 = 0;
double ry_1261 = 0;
V path_1262 = default;
V rev_1254 = default;
V w_1255 = default;
V h_1256 = default;
V sh_1257 = default;
rev_1254 = (_argc1244 > 4 ? _rest1245[0] : V.Undef);
w_1255 = (_argc1244 > 5 ? _rest1245[1] : V.Undef);
h_1256 = (_argc1244 > 6 ? _rest1245[2] : V.Undef);
sh_1257 = (_argc1244 > 7 ? _rest1245[3] : V.Undef);
q_1259 = Invoke(c_1236, "p", ((V)(0D)), y_1250, ((V)(0D)));
rx_1260 = (ToNum(r_1251) * ToNum(k_1238));
ry_1261 = ((ToNum(r_1251) * ToNum(k_1238)) * ToNum(Get(X_9, "SA")));
path_1262 = ((V)(JsStrBuf.Begin().S("M").V(Call(f1_23, V.Undef, Add(GetIdx(q_1259, 0D), ((V)((Truthy(rev_1254) ? (-rx_1260) : rx_1260)))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_1259, 1D))).S("A").V(Call(f1_23, V.Undef, ((V)(rx_1260)))).S(" ").V(Call(f1_23, V.Undef, ((V)(ry_1261)))).S(" 0 1 ").N((Truthy(rev_1254) ? 0D : 1D)).S(" ").V(Call(f1_23, V.Undef, Add(GetIdx(q_1259, 0D), ((V)((Truthy(rev_1254) ? rx_1260 : (-rx_1260))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_1259, 1D))).S("A").V(Call(f1_23, V.Undef, ((V)(rx_1260)))).S(" ").V(Call(f1_23, V.Undef, ((V)(ry_1261)))).S(" 0 1 ").N((Truthy(rev_1254) ? 0D : 1D)).S(" ").V(Call(f1_23, V.Undef, Add(GetIdx(q_1259, 0D), ((V)((Truthy(rev_1254) ? (-rx_1260) : rx_1260)))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_1259, 1D))).End()));
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_1259, 0D)) - rx_1260))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_1259, 1D))).S("a").V(Call(f1_23, V.Undef, ((V)(rx_1260)))).S(" ").V(Call(f1_23, V.Undef, ((V)(ry_1261)))).S(" 0 1 0 ").V(Call(f1_23, V.Undef, ((V)((2D * rx_1260))))).S(" 0a").V(Call(f1_23, V.Undef, ((V)(rx_1260)))).S(" ").V(Call(f1_23, V.Undef, ((V)(ry_1261)))).S(" 0 1 0 ").V(Call(f1_23, V.Undef, ((V)(((-2D) * rx_1260))))).S(" 0\" fill=\"none\" stroke=\"#8ff6ff\" stroke-opacity=\"0.35\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.5 * ToNum(k_1238)))))).S("\"/>").V(Invoke(Call(rep_48, V.Undef, n_1252, Fn((V _arrowThis1270, int _argc1263, V i_1269, V _a1266, V _a1267, V _a1268, V[] _rest1264) => {
V bg_1271 = default;
V col_1272 = default;
bg_1271 = Call(n4_50, V.Undef, ((V)((((-ToNum(i_1269)) * ToNum(d_1253)) / ToNum(n_1252)))));
col_1272 = GetIdx(CASE_52, (ToNum(Add(i_1269, sh_1257)) % ToNum(Get(CASE_52, "length"))));
return ((V)(JsStrBuf.Begin().S("<g opacity=\"1\"><animateMotion dur=\"").V(d_1253).S("s\" begin=\"").V(bg_1271).S("s\" repeatCount=\"indefinite\" path=\"").V(path_1262).S("\"/><animate attributeName=\"opacity\" values=\"1;1;0.35;0.35;1\" keyTimes=\"0;0.42;0.55;0.92;1\" dur=\"").V(d_1253).S("s\" begin=\"").V(bg_1271).S("s\" repeatCount=\"indefinite\"/>").S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((((-ToNum(w_1255)) / 2D) * ToNum(k_1238)))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((((-ToNum(h_1256)) / 2D) * ToNum(k_1238)))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(w_1255) * ToNum(k_1238)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(h_1256) * ToNum(k_1238)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((0.8 * ToNum(k_1238)))))).S("\" fill=\"").V(col_1272).S("\" fill-opacity=\"0.75\" stroke=\"#dffcff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.4 * ToNum(k_1238)))))).S("\"/><rect x=\"").V(Call(f1_23, V.Undef, ((V)(((((-ToNum(w_1255)) / 2D) * ToNum(k_1238)) + (1.2 * ToNum(k_1238))))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((((ToNum(h_1256) / 2D) * ToNum(k_1238)) - (3.6 * ToNum(k_1238))))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)(((ToNum(w_1255) - 2.4) * ToNum(k_1238)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(k_1238)))))).S("\" fill=\"#ffffff\" fill-opacity=\"0.7\"/><circle cx=\"0\" cy=\"").V(Call(f1_23, V.Undef, ((V)((((-ToNum(h_1256)) * 0.12) * ToNum(k_1238)))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)(((ToNum(w_1255) * 0.22) * ToNum(k_1238)))))).S("\" fill=\"#ffffff\" fill-opacity=\"0.45\"/></g>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).End()));
return default;
}, 8, "", true);
f_1242 = new JsStrBuf("<defs><linearGradient id=\"p17lb\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8ff6ff\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#8ff6ff\" stop-opacity=\"0\"/></linearGradient></defs>");
f_1242.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(b_1239, 0D)) - (8D * ToNum(k_1238))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(b_1239, 1D))).S("L").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(t_1240, 0D)) - (14D * ToNum(k_1238))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(t_1240, 1D))).S("H").V(Call(f1_23, V.Undef, Add(GetIdx(t_1240, 0D), ((V)((14D * ToNum(k_1238))))))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(b_1239, 0D), ((V)((8D * ToNum(k_1238))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(b_1239, 1D))).S("Z\" fill=\"url(#p17lb)\">").V(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.75;0.95;0.6")), ((V)(2.6)))).S("</path>");
f_1242.V(Add(Call(ring_1241, V.Undef, ((V)(34D)), ((V)(24D)), ((V)(8D)), ((V)(12D)), ((V)(0D)), ((V)(8D)), ((V)(11D)), ((V)(0D))), Call(ring_1241, V.Undef, ((V)(60D)), ((V)(18D)), ((V)(6D)), ((V)(9D)), ((V)(1D)), ((V)(7D)), ((V)(9.6)), ((V)(3D)))));
s_1243 = Invoke(c_1236, "p", ((V)(0D)), ((V)(80D)), ((V)(0D)));
f_1242.S("<g transform=\"translate(").V(Call(P2_49, V.Undef, s_1243)).S(")\"><g>").S("<animateTransform attributeName=\"transform\" type=\"scale\" values=\"1 1;0.15 1;1 1\" dur=\"3s\" repeatCount=\"indefinite\"/><circle r=\"").V(Call(f1_23, V.Undef, ((V)((5D * ToNum(k_1238)))))).S("\" fill=\"#8ff6ff\" fill-opacity=\"0.3\" stroke=\"#dffcff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.5 * ToNum(k_1238)))))).S("\"/><path d=\"M").V(Call(f1_23, V.Undef, ((V)(((-1.6) * ToNum(k_1238)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-2.6) * ToNum(k_1238)))))).S("L").V(Call(f1_23, V.Undef, ((V)((2.8 * ToNum(k_1238)))))).S(" 0L").V(Call(f1_23, V.Undef, ((V)(((-1.6) * ToNum(k_1238)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((2.6 * ToNum(k_1238)))))).S("Z\" fill=\"#ffffff\"/></g></g>");
return NewObj(1).Put("front", ((V)(f_1242.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "candy17", Fn((V _arrowThis1280, int _argc1273, V S_1279, V _a1276, V _a1277, V _a1278, V[] _rest1274) => {
return NewObj(5).Put("w", ((V)(62D))).Put("d", ((V)(40D))).Put("small", ((V)(1D))).Put("build", Fn((V _arrowThis1287, int _argc1281, V _a1283, V _a1284, V _a1285, V _a1286, V[] _rest1282) => {
V o_1288 = default;
V CC_1289 = default;
double gx_1290 = 0;
double gz_1291 = 0;
o_1288 = Arr();
CC_1289 = Arr(((V)("#d9363b")), ((V)("#f2c94c")), ((V)("#3f7fc8")), ((V)("#4f9a4a")), ((V)("#ff9d4a")), ((V)("#8a55c8")), ((V)("#ff7fb0")));
Invoke(o_1288, "push", Call(box_12, V.Undef, ((V)((-10D))), ((V)(0D)), ((V)(0D)), ((V)(28D)), ((V)(8D)), ((V)(18D)), ((V)("#d9363b")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)), Call(box_12, V.Undef, ((V)((-10D))), ((V)(7.6)), ((V)(0D)), ((V)(26D)), ((V)(0.6)), ((V)(16D)), ((V)("#7a1a1e")), NewObj(2).Put("r", ((V)(0.8))).Put("noOut", ((V)(1D))).V), Call(slabX_16, V.Undef, ((V)((-10D))), ((V)(3D)), ((V)(9.05)), ((V)(24D)), ((V)(2D)), ((V)(0.2)), ((V)("#f2c94c")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
Invoke(Call(tiltAll_30, V.Undef, Arr(Call(slab_15, V.Undef, ((V)((-10D))), ((V)(8D)), ((V)((-9D))), ((V)(28D)), ((V)(13D)), ((V)(0.8)), ((V)("#f2c94c")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slab_15, V.Undef, ((V)((-10D))), ((V)(10D)), ((V)((-8.55))), ((V)(22D)), ((V)(9D)), ((V)(0.2)), ((V)("#d9363b")), NewObj(2).Put("r", ((V)(2D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.4))), Arr(((V)((-10D))), ((V)(8D)), ((V)((-9D))))), "forEach", Fn((V _arrowThis1299, int _argc1292, V s_1298, V _a1295, V _a1296, V _a1297, V[] _rest1293) => {
return Invoke(o_1288, "push", s_1298);
}, 1, "", true));
Call(rep_48, V.Undef, ((V)(16D)), Fn((V _arrowThis1307, int _argc1300, V i_1306, V _a1303, V _a1304, V _a1305, V[] _rest1301) => {
return Invoke(o_1288, "push", Call(ball_14, V.Undef, ((V)((((-20D) + ((ToNum(i_1306) % 6D) * 4D)) + ((System.Math.Floor((ToNum(i_1306) / 6D)) % 2D) * 2D)))), ((V)(7.2)), ((V)(((-5D) + (System.Math.Floor((ToNum(i_1306) / 6D)) * 4.6)))), ((V)(1.9)), GetIdx(CC_1289, (ToNum(i_1306) % ToNum(Get(CC_1289, "length")))), NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(Arr(Arr(((V)(8D)), ((V)(12D))), Arr(((V)(11D)), ((V)(7D))), Arr(((V)(4D)), ((V)(16D))), Arr(((V)((-24D))), ((V)(13D)))), "forEach", Fn((V _arrowThis1320, int _argc1308, V _a1310, V i_1314, V _a1312, V _a1313, V[] _rest1309) => {
V x_1317 = default;
V z_1319 = default;
{ V _t1315 = ListOf(_a1310);
{ V _t1316 = GetIdx(_t1315, 0D);
x_1317 = _t1316; }
{ V _t1318 = GetIdx(_t1315, 1D);
z_1319 = _t1318; }
}
return Invoke(o_1288, "push", Call(ball_14, V.Undef, x_1317, ((V)(0D)), z_1319, ((V)(1.9)), GetIdx(CC_1289, (ToNum(Add(i_1314, ((V)(2D)))) % ToNum(Get(CC_1289, "length")))), NewObj(3).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 2, "", true));
gx_1290 = 20D;
gz_1291 = 8D;
Invoke(o_1288, "push", Call(slab_15, V.Undef, ((V)(gx_1290)), ((V)(2.2)), ((V)(gz_1291)), ((V)(20D)), ((V)(7D)), ((V)(0.8)), ((V)("#f5f2ea")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(1.6))).V)), Call(slab_15, V.Undef, ((V)((gx_1290 - 5D))), ((V)(3.4)), ((V)((gz_1291 + 0.5))), ((V)(7D)), ((V)(4.6)), ((V)(0.3)), ((V)("#ff4a5a")), NewObj(4).Put("r", ((V)(1.4))).Put("op", ((V)(0.85))).Put("noOut", ((V)(1D))).Put("shine", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)((gx_1290 + 5D))), ((V)(3.4)), ((V)((gz_1291 + 0.5))), ((V)(7D)), ((V)(4.6)), ((V)(0.3)), ((V)("#3fd0ff")), NewObj(4).Put("r", ((V)(1.4))).Put("op", ((V)(0.85))).Put("noOut", ((V)(1D))).Put("shine", ((V)(1D))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1328, int _argc1321, V sg_1327, V _a1324, V _a1325, V _a1326, V[] _rest1322) => {
return Invoke(o_1288, "push", Call(tilt_29, V.Undef, Call(box_12, V.Undef, ((V)((gx_1290 + (ToNum(sg_1327) * 9.6)))), ((V)(0D)), ((V)((gz_1291 - 8D))), ((V)(0.8)), ((V)(3.4)), ((V)(16D)), ((V)("#f5f2ea")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)(0.05)), Arr(((V)(gx_1290)), ((V)(0D)), ((V)(gz_1291)))));
}, 1, "", true));
return o_1288;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1336, int _argc1329, V c_1335, V _a1332, V _a1333, V _a1334, V[] _rest1330) => {
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(frame_35, V.Undef, Get(c_1335, "p"), Invoke(Call(Call(rotF_31, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.4)))), V.Undef, Arr(((V)(0D)), ((V)(6.2)), ((V)(0.9)))), "map", Fn((V _arrowThis1345, int _argc1337, V v_1343, V i_1344, V _a1341, V _a1342, V[] _rest1338) => {
return Add(v_1343, GetK(Arr(((V)((-10D))), ((V)(8D)), ((V)((-9D)))), i_1344));
}, 2, "", true)), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Call(Call(rotF_31, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.4)))), V.Undef, Arr(((V)(0D)), ((V)((-1D))), ((V)(0D)))))).S("\"><text x=\"0\" y=\"1.4\" text-anchor=\"middle\" ").V(FONT_40).S(" font-size=\"4\" fill=\"#ffffff\" stroke=\"#7a1a1e\" stroke-width=\"0.3\" paint-order=\"stroke\">CANDY</text></g>").End()))).V;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "pop17", Fn((V _arrowThis1353, int _argc1346, V S_1352, V _a1349, V _a1350, V _a1351, V[] _rest1347) => {
return NewObj(5).Put("w", ((V)(56D))).Put("d", ((V)(46D))).Put("small", ((V)(1D))).Put("build", Fn((V _arrowThis1360, int _argc1354, V _a1356, V _a1357, V _a1358, V _a1359, V[] _rest1355) => {
V o_1361 = default;
V RED_1362 = default;
V R_1363 = default;
o_1361 = Arr();
RED_1362 = ((V)("#d9363b"));
R_1363 = Call(R0_51, V.Undef, ((V)("pop")));
Invoke(o_1361, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(12D)), ((V)(24D)), ((V)("#fbf6ec")), Call(PL_45, V.Undef, NewObj(3).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(24D)), ((V)(0D)), ((V)(1D))))).Put("r", ((V)(15D))).V)));
Invoke(o_1361, "push", Call(arcW_17, V.Undef, ((V)(0D)), ((V)(23D)), ((V)(0D)), ((V)(12.6)), ((V)(12.6)), ((V)(1.6)), ((V)(1.8)), ((V)(0D)), ((V)((2D * PI_25))), ((V)("#ffffff")), Call(PL_45, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)));
Call(rep_48, V.Undef, ((V)(30D)), Fn((V _arrowThis1371, int _argc1364, V i_1370, V _a1367, V _a1368, V _a1369, V[] _rest1365) => {
double a_1372 = 0;
double rr_1373 = 0;
double h_1374 = 0;
a_1372 = ((ToNum(Call(R_1363, V.Undef)) * 2D) * PI_25);
rr_1373 = (System.Math.Sqrt(ToNum(Call(R_1363, V.Undef))) * 11D);
h_1374 = ((24D + ((1D - ((rr_1373 / 11D) * (rr_1373 / 11D))) * 9D)) + (ToNum(Call(R_1363, V.Undef)) * 2D));
Invoke(Call(kern_36, V.Undef, ((V)((FdLibm.Cos(a_1372) * rr_1373))), ((V)((h_1374 - 2D))), ((V)((FdLibm.Sin(a_1372) * rr_1373))), ((V)(2.3)), i_1370), "forEach", Fn((V _arrowThis1382, int _argc1375, V s_1381, V _a1378, V _a1379, V _a1380, V[] _rest1376) => {
return Invoke(o_1361, "push", s_1381);
}, 1, "", true));
return default;
}, 1, "", true));
Call(rep_48, V.Undef, ((V)(4D)), Fn((V _arrowThis1390, int _argc1383, V i_1389, V _a1386, V _a1387, V _a1388, V[] _rest1384) => {
return Invoke(o_1361, "push", Call(ball_14, V.Undef, ((V)(((ToNum(Call(R_1363, V.Undef)) - 0.5) * 10D))), ((V)((30D + (ToNum(Call(R_1363, V.Undef)) * 4D)))), ((V)(((ToNum(Call(R_1363, V.Undef)) - 0.2) * 8D))), ((V)(1.2)), ((V)("#ffd34a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(Arr(Arr(((V)(16D)), ((V)(0D)), ((V)(12D))), Arr(((V)((-15D))), ((V)(0D)), ((V)(14D))), Arr(((V)(19D)), ((V)(0D)), ((V)((-2D))))), "forEach", Fn((V _arrowThis1405, int _argc1391, V _a1393, V i_1397, V _a1395, V _a1396, V[] _rest1392) => {
V x_1400 = default;
V y_1402 = default;
V z_1404 = default;
{ V _t1398 = ListOf(_a1393);
{ V _t1399 = GetIdx(_t1398, 0D);
x_1400 = _t1399; }
{ V _t1401 = GetIdx(_t1398, 1D);
y_1402 = _t1401; }
{ V _t1403 = GetIdx(_t1398, 2D);
z_1404 = _t1403; }
}
return Invoke(Call(kern_36, V.Undef, x_1400, y_1402, z_1404, ((V)(2D)), i_1397), "forEach", Fn((V _arrowThis1413, int _argc1406, V s_1412, V _a1409, V _a1410, V _a1411, V[] _rest1407) => {
return Invoke(o_1361, "push", s_1412);
}, 1, "", true));
}, 2, "", true));
Invoke(Arr(Arr(((V)(18D)), ((V)(12D)), ((V)(0.4)), ((V)("#f2932c"))), Arr(((V)(24D)), ((V)(4D)), ((V)((-0.3))), ((V)("#ffd66b")))), "forEach", Fn((V _arrowThis1429, int _argc1414, V _a1416, V _a1417, V _a1418, V _a1419, V[] _rest1415) => {
V x_1422 = default;
V z_1424 = default;
V yw_1426 = default;
V col_1428 = default;
{ V _t1420 = ListOf(_a1416);
{ V _t1421 = GetIdx(_t1420, 0D);
x_1422 = _t1421; }
{ V _t1423 = GetIdx(_t1420, 1D);
z_1424 = _t1423; }
{ V _t1425 = GetIdx(_t1420, 2D);
yw_1426 = _t1425; }
{ V _t1427 = GetIdx(_t1420, 3D);
col_1428 = _t1427; }
}
return Invoke(o_1361, "push", Call(box_12, V.Undef, x_1422, ((V)(0D)), z_1424, ((V)(15D)), ((V)(0.6)), ((V)(7D)), col_1428, Call(PL_45, V.Undef, NewObj(2).Put("yaw", yw_1426).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)((ToNum(x_1422) - (4.4 * FdLibm.Cos(ToNum(yw_1426)))))), ((V)(0.6)), ((V)((ToNum(z_1424) - (4.4 * FdLibm.Sin(ToNum(yw_1426)))))), ((V)(0.4)), ((V)(0.15)), ((V)(6.4)), ((V)("#ffffff")), NewObj(3).Put("yaw", yw_1426).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
return o_1361;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1437, int _argc1430, V c_1436, V _a1433, V _a1434, V _a1435, V[] _rest1431) => {
V k_1438 = default;
V rA_1439 = default;
V P_1440 = default;
V fac_1441 = default;
double Y0_1442 = 0;
double Y1_1443 = 0;
double st_1444 = 0;
V vis_1445 = default;
V xs_1446 = default;
V x0_1447 = default;
V x1_1448 = default;
V U_1449 = default;
V band_1450 = default;
V inV_1451 = default;
JsStrBuf red_1452 = null;
V hl_1453 = default;
JsStrBuf f_1454 = null;
k_1438 = Get(c_1436, "k");
rA_1439 = Fn((V _arrowThis1462, int _argc1455, V y_1461, V _a1458, V _a1459, V _a1460, V[] _rest1456) => {
return ((V)(((12D * (0.8 + ((0.2 * ToNum(y_1461)) / 24D))) + 0.15)));
}, 1, "", true);
P_1440 = Fn((V _arrowThis1472, int _argc1463, V t_1469, V y_1470, V dr_1471, V _a1468, V[] _rest1464) => {
V r_1473 = default;
r_1473 = Add(Call(rA_1439, V.Undef, y_1470), (dr_1471 is var _t1474 && Truthy(_t1474) ? _t1474 : ((V)(0D))));
return Invoke(c_1436, "p", ((V)((FdLibm.Cos(ToNum(t_1469)) * ToNum(r_1473)))), y_1470, ((V)((FdLibm.Sin(ToNum(t_1469)) * ToNum(r_1473)))));
return default;
}, 3, "", true);
fac_1441 = Fn((V _arrowThis1482, int _argc1475, V t_1481, V _a1478, V _a1479, V _a1480, V[] _rest1476) => {
return (((ToNum(GetIdx(Call(P_1440, V.Undef, t_1481, ((V)(12D)), ((V)(2D))), 1D)) - ToNum(GetIdx(Call(P_1440, V.Undef, t_1481, ((V)(12D))), 1D))) > (0.02 * ToNum(k_1438))) ? V.True : V.False);
}, 1, "", true);
Y0_1442 = 0.7;
Y1_1443 = 22.9;
st_1444 = (PI_25 / 96D);
vis_1445 = Arr();
{
double t_1483 = 0;
t_1483 = 0D;
while (true) {
if (!((t_1483 < (2D * PI_25)))) break;
if (Truthy(Call(fac_1441, V.Undef, ((V)(t_1483))))) {
Invoke(vis_1445, "push", ((V)(t_1483)));
}
t_1483 = (t_1483 + st_1444);
}
}
if (!(Truthy(Get(vis_1445, "length")))) {
return NewObj(0).V;
}
xs_1446 = Invoke(vis_1445, "map", Fn((V _arrowThis1492, int _argc1485, V t_1491, V _a1488, V _a1489, V _a1490, V[] _rest1486) => {
return GetIdx(Call(P_1440, V.Undef, t_1491, ((V)(12D))), 0D);
}, 1, "", true));
x0_1447 = InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_1446).V);
x1_1448 = InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_1446).V);
U_1449 = Fn((V _arrowThis1500, int _argc1493, V t_1499, V _a1496, V _a1497, V _a1498, V[] _rest1494) => {
return ((V)(((ToNum(GetIdx(Call(P_1440, V.Undef, t_1499, ((V)(12D))), 0D)) - ToNum(x0_1447)) / Max(0.001, (ToNum(x1_1448) - ToNum(x0_1447))))));
}, 1, "", true);
band_1450 = Fn((V _arrowThis1508, int _argc1501, V ts_1507, V _a1504, V _a1505, V _a1506, V[] _rest1502) => {
return ((V)((LtN(Get(ts_1507, "length"), 2D) ? "" : JsStrBuf.Begin().S("M").V(Invoke(Invoke(ts_1507, "map", Fn((V _arrowThis1516, int _argc1509, V t_1515, V _a1512, V _a1513, V _a1514, V[] _rest1510) => {
return Call(P2_49, V.Undef, Call(P_1440, V.Undef, t_1515, ((V)(Y0_1442))));
}, 1, "", true)), "join", ((V)("L")))).S("L").V(Invoke(Invoke(Invoke(Invoke(ts_1507, "slice"), "reverse"), "map", Fn((V _arrowThis1524, int _argc1517, V t_1523, V _a1520, V _a1521, V _a1522, V[] _rest1518) => {
return Call(P2_49, V.Undef, Call(P_1440, V.Undef, t_1523, ((V)(Y1_1443))));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End())));
}, 1, "", true);
inV_1451 = Fn((V _arrowThis1533, int _argc1525, V a_1531, V b_1532, V _a1529, V _a1530, V[] _rest1526) => {
V r_1534 = default;
r_1534 = Arr();
{
V t_1535 = default;
t_1535 = a_1531;
while (true) {
if (!(Le(t_1535, Add(b_1532, ((V)(0.000001)))))) break;
double tt_1537 = 0;
tt_1537 = (((ToNum(t_1535) % (2D * PI_25)) + (2D * PI_25)) % (2D * PI_25));
if (Truthy(Call(fac_1441, V.Undef, ((V)(tt_1537))))) {
Invoke(r_1534, "push", t_1535);
}
t_1535 = Add(t_1535, ((V)((st_1444 / 2D))));
}
}
return r_1534;
return default;
}, 2, "", true);
red_1452 = new JsStrBuf("");
Call(rep_48, V.Undef, ((V)(8D)), Fn((V _arrowThis1545, int _argc1538, V s_1544, V _a1541, V _a1542, V _a1543, V[] _rest1539) => {
double a_1546 = 0;
a_1546 = ((PI_25 / 16D) + ((ToNum(s_1544) * PI_25) / 4D));
red_1452.V(Call(band_1450, V.Undef, Call(inV_1451, V.Undef, ((V)(a_1546)), ((V)((a_1546 + (PI_25 / 8D)))))));
return default;
}, 1, "", true));
hl_1453 = Call(band_1450, V.Undef, Invoke(Invoke(vis_1445, "filter", Fn((V _arrowThis1563, int _argc1556, V t_1562, V _a1559, V _a1560, V _a1561, V[] _rest1557) => {
V u_1564 = default;
u_1564 = Call(U_1449, V.Undef, t_1562);
return ((GtN(u_1564, 0.2) && LtN(u_1564, 0.3)) ? V.True : V.False);
return default;
}, 1, "", true)), "sort", Fn((V _arrowThis1555, int _argc1547, V a_1553, V b_1554, V _a1551, V _a1552, V[] _rest1548) => {
return ((V)((ToNum(a_1553) - ToNum(b_1554))));
}, 2, "", true)));
f_1454 = new JsStrBuf(JsStrBuf.Begin().S("<defs><linearGradient id=\"p17pk\" gradientUnits=\"userSpaceOnUse\" x1=\"").V(Call(f1_23, V.Undef, x0_1447)).S("\" y1=\"0\" x2=\"").V(Call(f1_23, V.Undef, x1_1448)).S("\" y2=\"0\"><stop offset=\"0\" stop-color=\"#f0574c\"/><stop offset=\"0.3\" stop-color=\"#e2403b\"/><stop offset=\"0.75\" stop-color=\"#c62a2d\"/><stop offset=\"1\" stop-color=\"#9c1d24\"/></linearGradient></defs>").End());
f_1454.S("<path d=\"").S(red_1452.Str).S("\" fill=\"url(#p17pk)\"/>").S((Truthy(hl_1453) ? JsStrBuf.Begin().S("<path d=\"").V(hl_1453).S("\" fill=\"#ffffff\" opacity=\"0.22\"/>").End() : ""));
if (Truthy(Call(fac_1441, V.Undef, ((V)((PI_25 / 2D)))))) {
V ts_1565 = default;
ts_1565 = Arr();
{
double t_1566 = 0;
t_1566 = ((PI_25 / 2D) - 0.44);
while (true) {
if (!((t_1566 <= ((PI_25 / 2D) + 0.44)))) break;
Invoke(ts_1565, "push", ((V)(t_1566)));
t_1566 = (t_1566 + 0.04);
}
}
f_1454.S("<path d=\"M").V(Invoke(Invoke(ts_1565, "map", Fn((V _arrowThis1575, int _argc1568, V t_1574, V _a1571, V _a1572, V _a1573, V[] _rest1569) => {
return Call(P2_49, V.Undef, Call(P_1440, V.Undef, t_1574, ((V)(9.4)), ((V)(0.1))));
}, 1, "", true)), "join", ((V)("L")))).S("L").V(Invoke(Invoke(Invoke(Invoke(ts_1565, "slice"), "reverse"), "map", Fn((V _arrowThis1583, int _argc1576, V t_1582, V _a1579, V _a1580, V _a1581, V[] _rest1577) => {
return Call(P2_49, V.Undef, Call(P_1440, V.Undef, t_1582, ((V)(17.4)), ((V)(0.1))));
}, 1, "", true)), "join", ((V)("L")))).S("Z\" fill=\"#ffd23f\" stroke=\"#c8202a\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.5 * ToNum(k_1438)))))).S("\" stroke-linejoin=\"round\"/>").S("<g transform=\"").V(Call(frame_35, V.Undef, Get(c_1436, "p"), Arr(((V)(0D)), ((V)(13.4)), Add(Call(rA_1439, V.Undef, ((V)(13.4))), ((V)(0.3)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))).S("\"><text x=\"0\" y=\"1.3\" text-anchor=\"middle\" ").V(FONT_40).S(" font-size=\"3.6\" fill=\"#c8202a\">POP</text></g>");
}
return NewObj(1).Put("front", ((V)(f_1454.Str))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
slTilt_56 = Call(rotF_31, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.22))));
SLP_57 = Arr(((V)((-6D))), ((V)(0D)), ((V)(0D)));
slAt_58 = Fn((V _arrowThis1591, int _argc1584, V v_1590, V _a1587, V _a1588, V _a1589, V[] _rest1585) => {
return Invoke(Call(slTilt_56, V.Undef, v_1590), "map", Fn((V _arrowThis1600, int _argc1592, V a_1598, V i_1599, V _a1596, V _a1597, V[] _rest1593) => {
return Add(a_1598, GetK(SLP_57, i_1599));
}, 2, "", true));
}, 1, "", true);
Set(N_24, "director17", Fn((V _arrowThis1608, int _argc1601, V S_1607, V _a1604, V _a1605, V _a1606, V[] _rest1602) => {
return NewObj(6).Put("w", ((V)(70D))).Put("d", ((V)(40D))).Put("small", ((V)(1D))).Put("build", Fn((V _arrowThis1615, int _argc1609, V _a1611, V _a1612, V _a1613, V _a1614, V[] _rest1610) => {
V o_1616 = default;
V RED_1617 = default;
V mg_1618 = default;
o_1616 = Arr();
RED_1617 = ((V)("#d9363b"));
Invoke(o_1616, "push", Call(box_12, V.Undef, ((V)((-6D))), ((V)(0D)), ((V)(4D)), ((V)(22D)), ((V)(2D)), ((V)(12D)), ((V)("#4a3a2a")), Call(W__41, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(Call(tiltAll_30, V.Undef, Arr(Call(slab_15, V.Undef, ((V)((-6D))), ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(21D)), ((V)(2D)), ((V)("#1d1d21")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)), Call(slab_15, V.Undef, ((V)((-6D))), ((V)(19.2)), ((V)(0D)), ((V)(30D)), ((V)(2.6)), ((V)(2.2)), ((V)("#f4f4f4")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.22))), SLP_57), "forEach", Fn((V _arrowThis1626, int _argc1619, V s_1625, V _a1622, V _a1623, V _a1624, V[] _rest1620) => {
return Invoke(o_1616, "push", s_1625);
}, 1, "", true));
mg_1618 = Arr(Call(solid_11, V.Undef, Call(PL_45, V.Undef, NewObj(8).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(7D)))).Put("a", ((V)(2.6))).Put("b", ((V)(2.6))).Put("n", ((V)(16D))).Put("rings", Arr(Arr(((V)(12D)), ((V)(0D)), ((V)(1D))), Arr(((V)(16D)), ((V)(0D)), ((V)(1.3))), Arr(((V)(30D)), ((V)(0D)), ((V)(2.5))), Arr(((V)(31D)), ((V)(0D)), ((V)(2.7))))).Put("col", RED_1617).V)), Call(solid_11, V.Undef, Call(PL_45, V.Undef, NewObj(8).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(7D)))).Put("a", ((V)(7.4))).Put("b", ((V)(7.4))).Put("n", ((V)(18D))).Put("rings", Arr(Arr(((V)(30.4)), ((V)(0D)), ((V)(1D))), Arr(((V)(32.2)), ((V)(0D)), ((V)(1D))))).Put("col", ((V)("#ffffff"))).V)), Call(solid_11, V.Undef, Call(PL_45, V.Undef, NewObj(8).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(7D)))).Put("a", ((V)(2.2))).Put("b", ((V)(2.2))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)(8D)), ((V)(0D)), ((V)(1D))), Arr(((V)(12D)), ((V)(0D)), ((V)(1D))))).Put("col", ((V)("#26272b"))).V)), Call(box_12, V.Undef, ((V)(19D)), ((V)(0.8)), ((V)(0D)), ((V)(3D)), ((V)(4.4)), ((V)(2.4)), ((V)("#26272b")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(solid_11, V.Undef, Call(PL_45, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(7D)))).Put("a", ((V)(6.2))).Put("b", ((V)(6.2))).Put("n", ((V)(18D))).Put("rings", Arr(Arr(((V)(32.3)), ((V)(0D)), ((V)(1D))), Arr(((V)(32.5)), ((V)(0D)), ((V)(1D))))).Put("col", ((V)("#3a3b40"))).Put("noOut", ((V)(1D))).V)));
Invoke(Call(tiltAll_30, V.Undef, mg_1618, Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), ((V)((-0.5))), Arr(((V)(20D)), ((V)(0D)), ((V)(0D)))), "forEach", Fn((V _arrowThis1634, int _argc1627, V s_1633, V _a1630, V _a1631, V _a1632, V[] _rest1628) => {
return Invoke(o_1616, "push", Call(xf_28, V.Undef, s_1633, Fn((V _arrowThis1642, int _argc1635, V v_1641, V _a1638, V _a1639, V _a1640, V[] _rest1636) => {
return v_1641;
}, 1, "", true), V.Null, Arr(((V)((-2D))), ((V)(0D)), ((V)(12D)))));
}, 1, "", true));
return o_1616;
return default;
}, 0, "build", true)).Put("layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1649, int _argc1643, V _a1645, V _a1646, V _a1647, V _a1648, V[] _rest1644) => {
V L_1650 = default;
L_1650 = Arr(Call(box_12, V.Undef, ((V)((-6D))), ((V)(21.8)), ((V)(0D)), ((V)(30D)), ((V)(3.4)), ((V)(2.2)), ((V)("#1d1d21")), Call(PL_45, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
Call(rep_48, V.Undef, ((V)(5D)), Fn((V _arrowThis1658, int _argc1651, V i_1657, V _a1654, V _a1655, V _a1656, V[] _rest1652) => {
return Invoke(L_1650, "push", Call(tilt_29, V.Undef, Call(box_12, V.Undef, ((V)(((-17D) + (ToNum(i_1657) * 5.6)))), ((V)(22D)), ((V)(1.15)), ((V)(2.6)), ((V)(3D)), ((V)(0.2)), ((V)("#f4f4f4")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(0.6)), Arr(((V)(((-17D) + (ToNum(i_1657) * 5.6)))), ((V)(23.5)), ((V)(1.15)))));
}, 1, "", true));
return Call(tiltAll_30, V.Undef, L_1650, Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), ((V)((-0.22))), SLP_57);
return default;
}, 0, "build", true)).Put("wrap", Fn((V _arrowThis1667, int _argc1659, V p_1665, V s_1666, V _a1663, V _a1664, V[] _rest1660) => {
V h_1668 = default;
V q_1669 = default;
h_1668 = Call(slAt_58, V.Undef, Arr(((V)((-20.6))), ((V)(21.8)), ((V)(0D))));
q_1669 = Call(p_1665, V.Undef, GetIdx(h_1668, 0D), GetIdx(h_1668, 1D), GetIdx(h_1668, 2D));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_49, V.Undef, q_1669)).S(")\"><g><animateTransform attributeName=\"transform\" type=\"rotate\" values=\"0;-24;-24;0;0\" keyTimes=\"0;0.18;0.62;0.68;1\" dur=\"2.8s\" calcMode=\"spline\" keySplines=\"0.3 0 0.4 1;0 0 1 1;0.7 0 1 1;0 0 1 1\" repeatCount=\"indefinite\"/><g transform=\"translate(").V(Call(f1_23, V.Undef, ((V)((-ToNum(GetIdx(q_1669, 0D))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((-ToNum(GetIdx(q_1669, 1D))))))).S(")\">").V(s_1666).S("</g></g></g>").End()));
return default;
}, 2, "wrap", true)).V)).Put("fx", Fn((V _arrowThis1677, int _argc1670, V c_1676, V _a1673, V _a1674, V _a1675, V[] _rest1671) => {
V O_1678 = default;
V M_1679 = default;
V h_1680 = default;
V q_1681 = default;
V k_1682 = default;
V pop_1683 = default;
O_1678 = Call(slAt_58, V.Undef, Arr(((V)((-6D))), ((V)(14D)), ((V)(1.15))));
M_1679 = Call(frame_35, V.Undef, Get(c_1676, "p"), O_1678, Call(slTilt_56, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D)))), Call(slTilt_56, V.Undef, Arr(((V)(0D)), ((V)((-1D))), ((V)(0D)))));
h_1680 = Call(slAt_58, V.Undef, Arr(((V)((-6D))), ((V)(24D)), ((V)(1.4))));
q_1681 = Invoke(c_1676, "p", GetIdx(h_1680, 0D), GetIdx(h_1680, 1D), GetIdx(h_1680, 2D));
k_1682 = Get(c_1676, "k");
pop_1683 = Invoke(Call(rep_48, V.Undef, ((V)(5D)), Fn((V _arrowThis1691, int _argc1684, V i_1690, V _a1687, V _a1688, V _a1689, V[] _rest1685) => {
double a_1692 = 0;
a_1692 = ((-PI_25) * (0.15 + (ToNum(i_1690) * 0.17)));
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_23, V.Undef, Add(GetIdx(q_1681, 0D), ((V)(((FdLibm.Cos(a_1692) * 18D) * ToNum(k_1682))))))).S(" ").V(Call(f1_23, V.Undef, Add(GetIdx(q_1681, 1D), ((V)(((FdLibm.Sin(a_1692) * 9D) * ToNum(k_1682))))))).S("l").V(Call(f1_23, V.Undef, ((V)(((FdLibm.Cos(a_1692) * 4D) * ToNum(k_1682)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((FdLibm.Sin(a_1692) * 4D) * ToNum(k_1682)))))).S("\" stroke=\"#ffd23f\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.9 * ToNum(k_1682)))))).S("\" stroke-linecap=\"round\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0;1;0;0\" keyTimes=\"0;0.67;0.7;0.82;1\" dur=\"2.8s\" repeatCount=\"indefinite\"/></path>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<g transform=\"").V(M_1679).S("\" fill=\"none\" stroke=\"#f4f4f4\" stroke-width=\"0.35\" stroke-linecap=\"round\"><path d=\"M-13 -5H13M-13 1H13M0 -5V7\"/><text x=\"-12\" y=\"-1.4\" ").V(FONT_40).S(" font-size=\"2.6\" fill=\"#f4f4f4\" stroke=\"none\">SCENE 1</text><text x=\"1.4\" y=\"-1.4\" ").V(FONT_40).S(" font-size=\"2.6\" fill=\"#f4f4f4\" stroke=\"none\">TAKE 3</text><text x=\"-12\" y=\"5\" ").V(FONT_40).S(" font-size=\"2.4\" fill=\"#f4f4f4\" stroke=\"none\">SQUISH</text><text x=\"1.4\" y=\"5\" ").V(FONT_40).S(" font-size=\"2.4\" fill=\"#f4f4f4\" stroke=\"none\">MOVIE</text></g>").V(pop_1683).End()))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
TX_59 = (-8D);
STY_60 = 46D;
Set(N_24, "trophy17", Fn((V _arrowThis1700, int _argc1693, V S_1699, V _a1696, V _a1697, V _a1698, V[] _rest1694) => {
return NewObj(5).Put("w", ((V)(58D))).Put("d", ((V)(40D))).Put("small", ((V)(1D))).Put("build", Fn((V _arrowThis1707, int _argc1701, V _a1703, V _a1704, V _a1705, V _a1706, V[] _rest1702) => {
V o_1708 = default;
V BLK_1709 = default;
V GD_1710 = default;
V GL_1711 = default;
V GLS_1712 = default;
V AMB_1713 = default;
double DX_1714 = 0;
double DZ_1715 = 0;
o_1708 = Arr();
BLK_1709 = ((V)("#24202a"));
GD_1710 = Call(shade_21, V.Undef, GOLD_26, ((V)(0.8)));
GL_1711 = Call(shade_21, V.Undef, GOLD_26, ((V)(1.16)));
GLS_1712 = ((V)("#e6f4fb"));
AMB_1713 = ((V)("#c26a1e"));
Invoke(o_1708, "push", Call(box_12, V.Undef, ((V)(TX_59)), ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(5D)), ((V)(18D)), BLK_1709, NewObj(3).Put("r", ((V)(1.6))).Put("bev", ((V)(1D))).Put("mat", ((V)("cer"))).V), Call(box_12, V.Undef, ((V)(TX_59)), ((V)(5D)), ((V)(0D)), ((V)(15D)), ((V)(4D)), ((V)(13D)), BLK_1709, NewObj(3).Put("r", ((V)(1.4))).Put("bev", ((V)(0.8))).Put("mat", ((V)("cer"))).V), Call(box_12, V.Undef, ((V)(TX_59)), ((V)(1.2)), ((V)(9.05)), ((V)(12D)), ((V)(2.6)), ((V)(0.4)), GOLD_26, Call(M__42, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("noOut", ((V)(1D))).V)));
Invoke(o_1708, "push", Call(cyl_13, V.Undef, ((V)(TX_59)), ((V)(9D)), ((V)(0D)), ((V)(5.4)), ((V)(2D)), GOLD_26, Call(M__42, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(0.9)), ((V)(0D)), ((V)(1D))), Arr(((V)(2D)), ((V)(0D)), ((V)(0.62))))).V)), Call(cyl_13, V.Undef, ((V)(TX_59)), ((V)(10.8)), ((V)(0D)), ((V)(1.7)), ((V)(5D)), GD_1710, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(ball_14, V.Undef, ((V)(TX_59)), ((V)(12.2)), ((V)(0D)), ((V)(2.6)), GOLD_26, Call(M__42, V.Undef, NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(12D))).Put("sy", ((V)(0.8))).V)));
Invoke(o_1708, "push", Call(cyl_13, V.Undef, ((V)(TX_59)), ((V)(16D)), ((V)(0D)), ((V)(9D)), ((V)(15D)), GOLD_26, Call(G__46, V.Undef, NewObj(3).Put("mat", ((V)("metal"))).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.2))), Arr(((V)(2D)), ((V)(0D)), ((V)(0.52))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.78))), Arr(((V)(9D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(13D)), ((V)(0D)), ((V)(1D))), Arr(((V)(15D)), ((V)(0D)), ((V)(1.04))))).V)));
Invoke(o_1708, "push", Call(cyl_13, V.Undef, ((V)(TX_59)), ((V)(30.6)), ((V)(0D)), ((V)(9.8)), ((V)(1.4)), GL_1711, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(ball_14, V.Undef, ((V)(TX_59)), ((V)(31.8)), ((V)(0D)), ((V)(8.6)), GOLD_26, Call(M__42, V.Undef, NewObj(3).Put("sy", ((V)(0.42))).Put("k", ((V)(5D))).Put("n", ((V)(22D))).V)), Call(cyl_13, V.Undef, ((V)(TX_59)), ((V)(35.2)), ((V)(0D)), ((V)(1.4)), ((V)(3.6)), GD_1710, Call(M__42, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(ball_14, V.Undef, ((V)(TX_59)), ((V)(37.8)), ((V)(0D)), ((V)(2D)), GL_1711, Call(M__42, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)));
DX_1714 = 15D;
DZ_1715 = (-7D);
Invoke(o_1708, "push", Call(box_12, V.Undef, ((V)(DX_1714)), ((V)(0D)), ((V)(DZ_1715)), ((V)(11D)), ((V)(9.6)), ((V)(11D)), AMB_1713, NewObj(4).Put("r", ((V)(1.8))).Put("bev", ((V)(1D))).Put("op", ((V)(0.9))).Put("mat", ((V)("pl"))).V), Call(box_12, V.Undef, ((V)(DX_1714)), ((V)(0D)), ((V)(DZ_1715)), ((V)(12D)), ((V)(15D)), ((V)(12D)), GLS_1712, Call(G__46, V.Undef, NewObj(3).Put("r", ((V)(2.4))).Put("bev", ((V)(3.4))).Put("op", ((V)(0.48))).V)));
Invoke(o_1708, "push", Call(cyl_13, V.Undef, ((V)(DX_1714)), ((V)(15D)), ((V)(DZ_1715)), ((V)(2.2)), ((V)(4.4)), GLS_1712, Call(G__46, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("op", ((V)(0.6))).V)), Call(cyl_13, V.Undef, ((V)(DX_1714)), ((V)(19D)), ((V)(DZ_1715)), ((V)(3D)), ((V)(1D)), GLS_1712, Call(G__46, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("op", ((V)(0.7))).V)), Call(ball_14, V.Undef, ((V)(DX_1714)), ((V)(19.8)), ((V)(DZ_1715)), ((V)(3.4)), GLS_1712, Call(G__46, V.Undef, NewObj(4).Put("k", ((V)(2D))).Put("n", ((V)(8D))).Put("sy", ((V)(1.15))).Put("op", ((V)(0.8))).V)));
Invoke(o_1708, "push", Call(cyl_13, V.Undef, ((V)((DX_1714 + 4D))), ((V)(0D)), ((V)(10D)), ((V)(3.2)), ((V)(3.4)), AMB_1713, NewObj(3).Put("n", ((V)(14D))).Put("op", ((V)(0.9))).Put("mat", ((V)("pl"))).V), Call(box_12, V.Undef, ((V)((DX_1714 + 4D))), ((V)(2.4)), ((V)(10D)), ((V)(2.4)), ((V)(2.4)), ((V)(2.4)), ((V)("#f4fbff")), NewObj(3).Put("r", ((V)(0.5))).Put("op", ((V)(0.9))).Put("yaw", ((V)(0.4))).V), Call(cyl_13, V.Undef, ((V)((DX_1714 + 4D))), ((V)(0D)), ((V)(10D)), ((V)(3.7)), ((V)(6.4)), GLS_1712, Call(G__46, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("op", ((V)(0.45))).V)));
return o_1708;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1723, int _argc1716, V c_1722, V _a1719, V _a1720, V _a1721, V[] _rest1717) => {
V q_1724 = default;
V k_1725 = default;
double R1_1726 = 0;
double R2_1727 = 0;
V T_1728 = default;
V V_1729 = default;
V pt_1730 = default;
V outl_1731 = default;
V back_1732 = default;
JsStrBuf fac_1733 = null;
V stem_1734 = default;
V o0_1735 = default;
V e1_1736 = default;
double sT_1737 = 0;
V hd_1738 = default;
V nearR_1739 = default;
V hb_1740 = default;
V hB_1741 = default;
V hF_1742 = default;
V bb_1743 = default;
double cT_1744 = 0;
double ac_1745 = 0;
double N2_1746 = 0;
V ON_1747 = default;
V top_1748 = default;
V bot_1749 = default;
JsStrBuf holes_1750 = null;
V band_1751 = default;
q_1724 = Invoke(c_1722, "p", ((V)(TX_59)), ((V)(STY_60)), ((V)(0D)));
k_1725 = Get(c_1722, "k");
R1_1726 = (7.6 * ToNum(k_1725));
R2_1727 = (3.1 * ToNum(k_1725));
T_1728 = Call(rep_48, V.Undef, ((V)(5D)), Fn((V _arrowThis1759, int _argc1752, V i_1758, V _a1755, V _a1756, V _a1757, V[] _rest1753) => {
double a_1760 = 0;
a_1760 = (((-PI_25) / 2D) + (((ToNum(i_1758) * 2D) * PI_25) / 5D));
return Arr(Add(GetIdx(q_1724, 0D), ((V)((FdLibm.Cos(a_1760) * R1_1726)))), Add(GetIdx(q_1724, 1D), ((V)((FdLibm.Sin(a_1760) * R1_1726)))));
return default;
}, 1, "", true));
V_1729 = Call(rep_48, V.Undef, ((V)(5D)), Fn((V _arrowThis1768, int _argc1761, V i_1767, V _a1764, V _a1765, V _a1766, V[] _rest1762) => {
double a_1769 = 0;
a_1769 = ((((-PI_25) / 2D) + (PI_25 / 5D)) + (((ToNum(i_1767) * 2D) * PI_25) / 5D));
return Arr(Add(GetIdx(q_1724, 0D), ((V)((FdLibm.Cos(a_1769) * R2_1727)))), Add(GetIdx(q_1724, 1D), ((V)((FdLibm.Sin(a_1769) * R2_1727)))));
return default;
}, 1, "", true));
pt_1730 = Fn((V _arrowThis1777, int _argc1770, V p_1776, V _a1773, V _a1774, V _a1775, V[] _rest1771) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(p_1776, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(p_1776, 1D))).End()));
}, 1, "", true);
outl_1731 = Invoke(Call(rep_48, V.Undef, ((V)(5D)), Fn((V _arrowThis1785, int _argc1778, V i_1784, V _a1781, V _a1782, V _a1783, V[] _rest1779) => {
return ((V)(JsStrBuf.Begin().V(Call(pt_1730, V.Undef, GetK(T_1728, i_1784))).S("L").V(Call(pt_1730, V.Undef, GetK(V_1729, i_1784))).End()));
}, 1, "", true)), "join", ((V)("L")));
back_1732 = Invoke(Call(rep_48, V.Undef, ((V)(5D)), Fn((V _arrowThis1793, int _argc1786, V i_1792, V _a1789, V _a1790, V _a1791, V[] _rest1787) => {
return ((V)(JsStrBuf.Begin().V(Call(pt_1730, V.Undef, Arr(Add(GetIdx(GetK(T_1728, i_1792), 0D), ((V)((0.9 * ToNum(k_1725))))), Add(GetIdx(GetK(T_1728, i_1792), 1D), ((V)((1.1 * ToNum(k_1725)))))))).S("L").V(Call(pt_1730, V.Undef, Arr(Add(GetIdx(GetK(V_1729, i_1792), 0D), ((V)((0.9 * ToNum(k_1725))))), Add(GetIdx(GetK(V_1729, i_1792), 1D), ((V)((1.1 * ToNum(k_1725)))))))).End()));
}, 1, "", true)), "join", ((V)("L")));
fac_1733 = new JsStrBuf("");
Call(rep_48, V.Undef, ((V)(5D)), Fn((V _arrowThis1801, int _argc1794, V i_1800, V _a1797, V _a1798, V _a1799, V[] _rest1795) => {
double a_1802 = 0;
a_1802 = (((-PI_25) / 2D) + (((ToNum(i_1800) * 2D) * PI_25) / 5D));
Invoke(Arr(Arr(GetIdx(V_1729, (ToNum(Add(i_1800, ((V)(4D)))) % 5D)), ((V)((a_1802 - 0.32)))), Arr(GetK(V_1729, i_1800), ((V)((a_1802 + 0.32))))), "forEach", Fn((V _arrowThis1814, int _argc1803, V _a1805, V _a1806, V _a1807, V _a1808, V[] _rest1804) => {
double l_1815 = 0;
V col_1816 = default;
V v_1811 = default;
V m_1813 = default;
{ V _t1809 = ListOf(_a1805);
{ V _t1810 = GetIdx(_t1809, 0D);
v_1811 = _t1810; }
{ V _t1812 = GetIdx(_t1809, 1D);
m_1813 = _t1812; }
}
l_1815 = (0.5 - (0.5 * ((FdLibm.Cos(ToNum(m_1813)) * 0.6) + (FdLibm.Sin(ToNum(m_1813)) * 0.8))));
col_1816 = Call(mix_22, V.Undef, ((V)("#b8801a")), ((V)("#fff3b0")), ((V)(l_1815)));
fac_1733.S("<path d=\"M").V(Call(pt_1730, V.Undef, q_1724)).S("L").V(Call(pt_1730, V.Undef, GetK(T_1728, i_1800))).S("L").V(Call(pt_1730, V.Undef, v_1811)).S("Z\" fill=\"").V(col_1816).S("\"/>");
return default;
}, 1, "", true));
return default;
}, 1, "", true));
stem_1734 = Invoke(c_1722, "p", ((V)(TX_59)), ((V)(39.6)), ((V)(0D)));
o0_1735 = Invoke(c_1722, "p", ((V)(0D)), ((V)(0D)), ((V)(0D)));
e1_1736 = Invoke(c_1722, "p", ((V)(1D)), ((V)(0D)), ((V)(0D)));
sT_1737 = ((-(ToNum(GetIdx(e1_1736, 1D)) - ToNum(GetIdx(o0_1735, 1D)))) / (ToNum(k_1725) * ToNum(Get(X_9, "SA"))));
hd_1738 = Fn((V _arrowThis1824, int _argc1817, V sg_1823, V _a1820, V _a1821, V _a1822, V[] _rest1818) => {
V P_1825 = default;
JsStrBuf d_1826 = null;
P_1825 = Invoke(Arr(Arr(((V)(8.2)), ((V)(28.4))), Arr(((V)(12.6)), ((V)(29.6))), Arr(((V)(15D)), ((V)(26.2))), Arr(((V)(13.4)), ((V)(21.2))), Arr(((V)(7.4)), ((V)(18.6)))), "map", Fn((V _arrowThis1838, int _argc1827, V _a1829, V _a1830, V _a1831, V _a1832, V[] _rest1828) => {
V x_1835 = default;
V y_1837 = default;
{ V _t1833 = ListOf(_a1829);
{ V _t1834 = GetIdx(_t1833, 0D);
x_1835 = _t1834; }
{ V _t1836 = GetIdx(_t1833, 1D);
y_1837 = _t1836; }
}
return Invoke(c_1722, "p", ((V)((TX_59 + (ToNum(sg_1823) * ToNum(x_1835))))), y_1837, ((V)(0D)));
}, 1, "", true));
Invoke(P_1825, "forEach", Fn((V _arrowThis1846, int _argc1839, V p_1845, V _a1842, V _a1843, V _a1844, V[] _rest1840) => {
return Invoke(hb_1740, "push", p_1845);
}, 1, "", true));
d_1826 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(pt_1730, V.Undef, GetIdx(P_1825, 0D))).End());
{
double i_1847 = 0;
i_1847 = 0D;
while (true) {
if (!((i_1847 < (ToNum(Get(P_1825, "length")) - 1D)))) break;
V a_1849 = default;
V b_1850 = default;
V e_1851 = default;
V f_1852 = default;
a_1849 = GetIdx(P_1825, Max(0D, (i_1847 - 1D)));
b_1850 = GetIdx(P_1825, i_1847);
e_1851 = GetIdx(P_1825, (i_1847 + 1D));
f_1852 = GetIdx(P_1825, Min((ToNum(Get(P_1825, "length")) - 1D), (i_1847 + 2D)));
d_1826.S("C").V(Call(pt_1730, V.Undef, Arr(Add(GetIdx(b_1850, 0D), ((V)(((ToNum(GetIdx(e_1851, 0D)) - ToNum(GetIdx(a_1849, 0D))) / 6D)))), Add(GetIdx(b_1850, 1D), ((V)(((ToNum(GetIdx(e_1851, 1D)) - ToNum(GetIdx(a_1849, 1D))) / 6D))))))).S(" ").V(Call(pt_1730, V.Undef, Arr(((V)((ToNum(GetIdx(e_1851, 0D)) - ((ToNum(GetIdx(f_1852, 0D)) - ToNum(GetIdx(b_1850, 0D))) / 6D)))), ((V)((ToNum(GetIdx(e_1851, 1D)) - ((ToNum(GetIdx(f_1852, 1D)) - ToNum(GetIdx(b_1850, 1D))) / 6D))))))).S(" ").V(Call(pt_1730, V.Undef, e_1851));
i_1847++;
}
}
return ((V)(JsStrBuf.Begin().S("<g fill=\"none\" stroke-linecap=\"round\"><path d=\"").S(d_1826.Str).S("\" stroke=\"#7a5410\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((3.6 * ToNum(k_1725)))))).S("\"/><path d=\"").S(d_1826.Str).S("\" stroke=\"").V(GOLD_26).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((2.3 * ToNum(k_1725)))))).S("\"/><path d=\"").S(d_1826.Str).S("\" stroke=\"#fff3b0\" stroke-opacity=\"0.8\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.7 * ToNum(k_1725)))))).S("\" transform=\"translate(").V(Call(f1_23, V.Undef, ((V)(((-0.4) * ToNum(k_1725)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-0.5) * ToNum(k_1725)))))).S(")\"/></g>").End()));
return default;
}, 1, "", true);
nearR_1739 = (((-sT_1737) > 0D) ? V.True : V.False);
hb_1740 = Arr(Arr(((V)(((ToNum(GetIdx(q_1724, 0D)) - R1_1726) - (2D * ToNum(k_1725))))), ((V)(((ToNum(GetIdx(q_1724, 1D)) - R1_1726) - (3D * ToNum(k_1725)))))), Arr(Add(Add(GetIdx(q_1724, 0D), ((V)(R1_1726))), ((V)((4D * ToNum(k_1725))))), GetIdx(q_1724, 1D)));
hB_1741 = Call(hd_1738, V.Undef, ((V)((Truthy(nearR_1739) ? (-1D) : 1D))));
hF_1742 = Call(hd_1738, V.Undef, ((V)((Truthy(nearR_1739) ? 1D : (-1D)))));
bb_1743 = Arr(((V)((ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(Invoke(hb_1740, "map", Fn((V _arrowThis1860, int _argc1853, V p_1859, V _a1856, V _a1857, V _a1858, V[] _rest1854) => {
return GetIdx(p_1859, 0D);
}, 1, "", true))).V)) - (3D * ToNum(k_1725))))), ((V)((ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(Invoke(hb_1740, "map", Fn((V _arrowThis1868, int _argc1861, V p_1867, V _a1864, V _a1865, V _a1866, V[] _rest1862) => {
return GetIdx(p_1867, 1D);
}, 1, "", true))).V)) - (3D * ToNum(k_1725))))), Add(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(Invoke(hb_1740, "map", Fn((V _arrowThis1876, int _argc1869, V p_1875, V _a1872, V _a1873, V _a1874, V[] _rest1870) => {
return GetIdx(p_1875, 0D);
}, 1, "", true))).V), ((V)((3D * ToNum(k_1725))))), Add(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(Invoke(hb_1740, "map", Fn((V _arrowThis1884, int _argc1877, V p_1883, V _a1880, V _a1881, V _a1882, V[] _rest1878) => {
return GetIdx(p_1883, 1D);
}, 1, "", true))).V), ((V)((3D * ToNum(k_1725))))));
cT_1744 = ((ToNum(GetIdx(e1_1736, 0D)) - ToNum(GetIdx(o0_1735, 0D))) / ToNum(k_1725));
ac_1745 = FdLibm.Atan2(cT_1744, (-sT_1737));
N2_1746 = 24D;
ON_1747 = Fn((V _arrowThis1894, int _argc1885, V a_1891, V y_1892, V r_1893, V _a1890, V[] _rest1886) => {
return Invoke(c_1722, "p", ((V)((TX_59 + (FdLibm.Cos(ToNum(a_1891)) * ToNum(r_1893))))), y_1892, ((V)((FdLibm.Sin(ToNum(a_1891)) * ToNum(r_1893)))));
}, 3, "", true);
top_1748 = Call(rep_48, V.Undef, ((V)((N2_1746 + 1D))), Fn((V _arrowThis1902, int _argc1895, V i_1901, V _a1898, V _a1899, V _a1900, V[] _rest1896) => {
return Call(ON_1747, V.Undef, ((V)(((ac_1745 - (PI_25 / 2D)) + ((ToNum(i_1901) * PI_25) / N2_1746)))), ((V)(27D)), ((V)(8.9)));
}, 1, "", true));
bot_1749 = Call(rep_48, V.Undef, ((V)((N2_1746 + 1D))), Fn((V _arrowThis1910, int _argc1903, V i_1909, V _a1906, V _a1907, V _a1908, V[] _rest1904) => {
return Call(ON_1747, V.Undef, ((V)(((ac_1745 + (PI_25 / 2D)) - ((ToNum(i_1909) * PI_25) / N2_1746)))), ((V)(23.6)), ((V)(8.1)));
}, 1, "", true));
holes_1750 = new JsStrBuf("");
Call(rep_48, V.Undef, ((V)(13D)), Fn((V _arrowThis1918, int _argc1911, V i_1917, V _a1914, V _a1915, V _a1916, V[] _rest1912) => {
double a_1919 = 0;
double w_1920 = 0;
a_1919 = ((ac_1745 - (PI_25 / 2D)) + ((ToNum(Add(i_1917, ((V)(0.5)))) * PI_25) / 13D));
w_1920 = FdLibm.Cos((a_1919 - ac_1745));
if ((w_1920 < 0.25)) {
return default;
}
Invoke(Arr(Arr(((V)(24.4)), ((V)(8.3))), Arr(((V)(26.2)), ((V)(8.75)))), "forEach", Fn((V _arrowThis1932, int _argc1921, V _a1923, V _a1924, V _a1925, V _a1926, V[] _rest1922) => {
V p_1933 = default;
V y_1929 = default;
V r_1931 = default;
{ V _t1927 = ListOf(_a1923);
{ V _t1928 = GetIdx(_t1927, 0D);
y_1929 = _t1928; }
{ V _t1930 = GetIdx(_t1927, 1D);
r_1931 = _t1930; }
}
p_1933 = Call(ON_1747, V.Undef, ((V)(a_1919)), y_1929, r_1931);
holes_1750.S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(p_1933, 0D)) - ((0.45 * ToNum(k_1725)) * w_1920)))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(p_1933, 1D)) - (0.35 * ToNum(k_1725))))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)(((0.9 * ToNum(k_1725)) * w_1920))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((0.7 * ToNum(k_1725)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((0.15 * ToNum(k_1725)))))).S("\" fill=\"#f4efe2\"/>");
return default;
}, 1, "", true));
return default;
}, 1, "", true));
band_1751 = ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Invoke(Invoke(Invoke(top_1748, "concat", bot_1749), "map", pt_1730), "join", ((V)("L")))).S("Z\" fill=\"#2b2a30\" stroke=\"#121116\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(k_1725)))))).S("\" stroke-linejoin=\"round\"/><path d=\"M").V(Invoke(Invoke(top_1748, "map", pt_1730), "join", ((V)("L")))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.25\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.4 * ToNum(k_1725)))))).S("\" transform=\"translate(0 ").V(Call(f1_23, V.Undef, ((V)((0.5 * ToNum(k_1725)))))).S(")\"/>").S(holes_1750.Str).End()));
return NewObj(3).Put("bb", bb_1743).Put("back", hB_1741).Put("front", ((V)(JsStrBuf.Begin().V(Add(band_1751, hF_1742)).S("<path d=\"M").V(Call(pt_1730, V.Undef, stem_1734)).S("L").V(Call(pt_1730, V.Undef, Arr(GetIdx(q_1724, 0D), Add(GetIdx(q_1724, 1D), ((V)((R2_1727 * 0.6))))))).S("\" stroke=\"#b8801a\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1.4 * ToNum(k_1725)))))).S("\"/><path d=\"M").V(back_1732).S("Z\" fill=\"#7a5410\" stroke=\"#5e400a\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(k_1725)))))).S("\" stroke-linejoin=\"round\"/>").S(fac_1733.Str).S("<path d=\"M").V(outl_1731).S("Z\" fill=\"none\" stroke=\"#7a5410\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.7 * ToNum(k_1725)))))).S("\" stroke-linejoin=\"round\"/><circle cx=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_1724, 0D)) - (1.4 * ToNum(k_1725))))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_1724, 1D)) - (1.6 * ToNum(k_1725))))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.9 * ToNum(k_1725)))))).S("\" fill=\"#ffffff\" opacity=\"0.85\"/>").V(Invoke(Call(rep_48, V.Undef, ((V)(5D)), Fn((V _arrowThis1941, int _argc1934, V i_1940, V _a1937, V _a1938, V _a1939, V[] _rest1935) => {
return Call(spark_53, V.Undef, c_1722, Add(((V)(TX_59)), GetK(Arr(((V)((-11D))), ((V)(10D)), ((V)((-13D))), ((V)(13D)), ((V)(2D))), i_1940)), GetK(Arr(((V)(50D)), ((V)(44D)), ((V)(27D)), ((V)(20D)), ((V)(56D))), i_1940), ((V)(0D)), ((V)(0.6)), ((V)(((-ToNum(i_1940)) * 0.38))), ((V)("#fff6c8")));
}, 1, "", true)), "join", ((V)("")))).End()))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "mascot17", Fn((V _arrowThis1949, int _argc1942, V S_1948, V _a1945, V _a1946, V _a1947, V[] _rest1943) => {
return NewObj(5).Put("w", ((V)(36D))).Put("d", ((V)(36D))).Put("small", ((V)(1D))).Put("build", Fn((V _arrowThis1956, int _argc1950, V _a1952, V _a1953, V _a1954, V _a1955, V[] _rest1951) => {
V o_1957 = default;
o_1957 = Arr();
Invoke(o_1957, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(4D)), ((V)("#2c2e36")), Call(M__42, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3D)), ((V)(0D)), ((V)(1D))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.86))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(5D)), ((V)(0.5)), ((V)("#7ff0ff")), Call(em_47, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(8.4)), ((V)(8.4)), ((V)(0.6)), ((V)(0.3)), ((V)(0D)), ((V)((2D * PI_25))), ((V)("#7ff0ff")), Call(em_47, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)));
Call(rep_48, V.Undef, ((V)(3D)), Fn((V _arrowThis1965, int _argc1958, V i_1964, V _a1961, V _a1962, V _a1963, V[] _rest1959) => {
return Invoke(o_1957, "push", Call(box_12, V.Undef, ((V)(((-3D) + (ToNum(i_1964) * 3D)))), ((V)(1.6)), ((V)(9.7)), ((V)(1.6)), ((V)(0.9)), ((V)(0.3)), GetK(Arr(((V)("#7dff9e")), ((V)("#7ff0ff")), ((V)("#ff6fae"))), i_1964), Call(em_47, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
return o_1957;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis1973, int _argc1966, V c_1972, V _a1969, V _a1970, V _a1971, V[] _rest1967) => {
V k_1974 = default;
V b_1975 = default;
V q_1976 = default;
V u_1977 = default;
V body_1978 = default;
V arm_1979 = default;
k_1974 = Get(c_1972, "k");
b_1975 = Invoke(c_1972, "p", ((V)(0D)), ((V)(4.6)), ((V)(0D)));
q_1976 = Invoke(c_1972, "p", ((V)(0D)), ((V)(22D)), ((V)(0D)));
u_1977 = k_1974;
body_1978 = ((V)(JsStrBuf.Begin().S("<ellipse cx=\"0\" cy=\"2\" rx=\"").V(Call(f1_23, V.Undef, ((V)((7D * ToNum(u_1977)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((6.4 * ToNum(u_1977)))))).S("\"/><circle cx=\"").V(Call(f1_23, V.Undef, ((V)(((-4.6) * ToNum(u_1977)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-4D) * ToNum(u_1977)))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(u_1977)))))).S("\"/><circle cx=\"").V(Call(f1_23, V.Undef, ((V)((4.6 * ToNum(u_1977)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-4D) * ToNum(u_1977)))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(u_1977)))))).S("\"/>").End()));
arm_1979 = ((V)(JsStrBuf.Begin().S("<g><animateTransform attributeName=\"transform\" type=\"rotate\" values=\"0 ").V(Call(f1_23, V.Undef, ((V)((6D * ToNum(u_1977)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(u_1977)))))).S(";-40 ").V(Call(f1_23, V.Undef, ((V)((6D * ToNum(u_1977)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(u_1977)))))).S(";0 ").V(Call(f1_23, V.Undef, ((V)((6D * ToNum(u_1977)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(u_1977)))))).S("\" dur=\"1.2s\" repeatCount=\"indefinite\"/><ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)((8.6 * ToNum(u_1977)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(u_1977)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((2.6 * ToNum(u_1977)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(u_1977)))))).S("\"/></g>").End()));
return NewObj(1).Put("front", ((V)(JsStrBuf.Begin().S("<defs><linearGradient id=\"p17mb\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8ff6ff\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#8ff6ff\" stop-opacity=\"0\"/></linearGradient><pattern id=\"p17ms\" width=\"4\" height=\"1.4\" patternUnits=\"userSpaceOnUse\"><rect width=\"4\" height=\"0.6\" fill=\"#ffffff\" opacity=\"0.4\"/></pattern></defs>").S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(b_1975, 0D)) - (4D * ToNum(k_1974))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(b_1975, 1D))).S("L").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_1976, 0D)) - (11D * ToNum(k_1974))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_1976, 1D)) - (10D * ToNum(k_1974))))))).S("H").V(Call(f1_23, V.Undef, Add(GetIdx(q_1976, 0D), ((V)((11D * ToNum(k_1974))))))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(b_1975, 0D), ((V)((4D * ToNum(k_1974))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(b_1975, 1D))).S("Z\" fill=\"url(#p17mb)\">").V(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.7;0.95;0.6")), ((V)(2.2)))).S("</path>").S("<g transform=\"translate(").V(Call(P2_49, V.Undef, q_1976)).S(")\"><g>").S("<animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;0 ").V(Call(f1_23, V.Undef, ((V)(((-1.6) * ToNum(k_1974)))))).S(";0 0\" dur=\"2s\" repeatCount=\"indefinite\"/>").V(Call(an_39, V.Undef, ((V)("opacity")), ((V)("0.9;0.95;0.55;0.95;0.9")), ((V)(1.9)))).S("<g fill=\"#8ff6ff\" fill-opacity=\"0.55\" stroke=\"#dffcff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.45 * ToNum(u_1977)))))).S("\">").V(body_1978).V(arm_1979).S("</g><g fill=\"url(#p17ms)\">").V(body_1978).S("</g>").S("<g fill=\"#0d3a4a\"><ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)(((-2.4) * ToNum(u_1977)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((1D * ToNum(u_1977)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1D * ToNum(u_1977)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((1.3 * ToNum(u_1977)))))).S("\"/><ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(u_1977)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((1D * ToNum(u_1977)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1D * ToNum(u_1977)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((1.3 * ToNum(u_1977)))))).S("\"/></g><path d=\"M").V(Call(f1_23, V.Undef, ((V)(((-1.4) * ToNum(u_1977)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((3.6 * ToNum(u_1977)))))).S("Q0 ").V(Call(f1_23, V.Undef, ((V)((5D * ToNum(u_1977)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((1.4 * ToNum(u_1977)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((3.6 * ToNum(u_1977)))))).S("\" stroke=\"#0d3a4a\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.5 * ToNum(u_1977)))))).S("\" fill=\"none\" stroke-linecap=\"round\"/></g></g>").End()))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(RD_8, "SET17", NewObj(19).Put("MOV-003", NewObj(2).Put("spec", ((V)("crate17"))).Put("note", ((V)("Two blue milk crates turned upside down with a crooked plywood board on top. A pizza box, a can of soda and a crumpled napkin sit on it."))).V).Put("MOV-023", NewObj(2).Put("spec", ((V)("lift17"))).Put("note", ((V)("A white coffee table whose oak top lifts up and back toward the sofa on chrome scissor arms, opening a storage well packed with movies. A bowl of chips, a soda and the remote wait on the raised top."))).V).Put("MOV-043", NewObj(2).Put("spec", ((V)("glass17"))).Put("note", ((V)("A black steel table with a smoked glass top and a glass shelf underneath holding movie cases and a game controller. A candy bowl, a little plant and two coasters on top."))).V).Put("MOV-063", NewObj(3).Put("spec", ((V)("fridgeT17"))).Put("live", ((V)("Chilled"))).Put("note", ((V)("A charcoal coffee table with two lit glass fridge drawers full of cold cans (a little cold mist drifts out), a wireless charging pad with a phone that pulses, and a bowl of popcorn."))).V).Put("MOV-083", NewObj(3).Put("spec", ((V)("holoT17"))).Put("live", ((V)("Hologram"))).Put("note", ((V)("A round white table on a glowing pedestal, with touch lights round the glass top and a spinning film-reel hologram beaming up from the middle."))).V).Put("MOV-007", NewObj(2).Put("spec", ((V)("tray17"))).Put("note", ((V)("A mustard folding TV tray with flower prints on gold legs, holding a TV dinner: mashed potato, peas, nuggets and a fork."))).V).Put("MOV-047", NewObj(2).Put("spec", ((V)("ctable17"))).Put("note", ((V)("A brass C-shaped side table that slides under the sofa, with a round walnut top, a cola on ice and a bowl of popcorn."))).V).Put("MOV-067", NewObj(3).Put("spec", ((V)("marbleT17"))).Put("live", ((V)("Chilled coaster"))).Put("note", ((V)("A white marble table on a fluted gold pedestal. Its blue glowing coaster keeps a frosty soda with ice and lemon ice-cold, with little puffs of cold rising."))).V).Put("MOV-087", NewObj(3).Put("spec", ((V)("bot17"))).Put("live", ((V)("Rolls around"))).Put("note", ((V)("A round little robot butler on glowing wheels. It blinks, flashes its antenna and carries a tray with a soda and popcorn."))).V).Put("MOV-017", NewObj(2).Put("spec", ((V)("brick17"))).Put("note", ((V)("Grey cinder blocks and pine boards stacked into a shelf, full of VHS tapes (one has tipped over), a plant in a tin can, a SQUISH tape box and an old tape player."))).V).Put("MOV-037", NewObj(2).Put("spec", ((V)("dvd17"))).Put("note", ((V)("A tall wire tower with four round racks of colourful DVDs all the way round, topped with a red knob."))).V).Put("MOV-057", NewObj(2).Put("spec", ((V)("console17"))).Put("note", ((V)("A low walnut media console on splayed legs, with slatted doors, two drawers with brass pulls, and a plant, a record and a stack of movies on top."))).V).Put("MOV-077", NewObj(3).Put("spec", ((V)("vault17"))).Put("live", ((V)("Glass glare"))).Put("note", ((V)("A tall black cabinet with glass doors and lit glass shelves full of shiny metal movie cases, gold handles and a glowing keypad lock."))).V).Put("MOV-097", NewObj(3).Put("spec", ((V)("holoLib17"))).Put("live", ((V)("Orbiting covers"))).Put("note", ((V)("A white pedestal that beams up a hologram library: two rings of glowing movie covers orbit round it and a play button spins on top."))).V).Put("MOV-008", NewObj(2).Put("spec", ((V)("candy17"))).Put("note", ((V)("An open box of colourful candy with its lid flipped up (a few pieces spilled) and a pair of red-and-blue 3D glasses."))).V).Put("MOV-028", NewObj(2).Put("spec", ((V)("pop17"))).Put("note", ((V)("A red-and-white striped bucket overflowing with buttery popcorn, with a few pieces dropped and two ticket stubs."))).V).Put("MOV-048", NewObj(3).Put("spec", ((V)("director17"))).Put("live", ((V)("Clapping"))).Put("note", ((V)("A movie clapperboard (SCENE 1, TAKE 3) that keeps snapping shut with a clap, next to a red director megaphone."))).V).Put("MOV-068", NewObj(3).Put("spec", ((V)("trophy17"))).Put("live", ((V)("Sparkles"))).Put("note", ((V)("A shiny gold award cup with curly handles, a film-strip band and a bevelled gold star on its lid, on a black base with a gold plate, next to a crystal decanter and a glass."))).V).Put("MOV-088", NewObj(3).Put("spec", ((V)("mascot17"))).Put("live", ((V)("Hologram"))).Put("note", ((V)("A little projector puck that beams up a waving hologram buddy."))).V).V);
edit16_61 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis1987, int _argc1980, V rows_1986, V _a1983, V _a1984, V _a1985, V[] _rest1981) => {
return Invoke(Call(edit16_61, V.Undef, rows_1986), "map", Fn((V _arrowThis1995, int _argc1988, V r_1994, V _a1991, V _a1992, V _a1993, V[] _rest1989) => {
return (Truthy(GetK(Get(RD_8, "SET17"), Get(r_1994, "id"))) ? Object_assign(NewObj(0).V, r_1994, GetK(Get(RD_8, "SET17"), Get(r_1994, "id"))) : r_1994);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "PLUS17", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
