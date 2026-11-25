// reno-plus5.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus5_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("play", "");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("(^|\\|)(on|play)$", "");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("bill", "i");
        static readonly System.Text.RegularExpressions.Regex RX3 = JsRegExp.Compile("[.@*+]", "");
        public static void Run()
        {
Call(Named(boot_81 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
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
V prism_19 = default;
V prismZ_20 = default;
V shade_21 = default;
V mix_22 = default;
V f1_23 = default;
V rep_24 = default;
V rng_25 = default;
V n4_26 = default;
V P2_27 = default;
V mtx_28 = default;
V plane_29 = default;
V planeH_30 = default;
V an_31 = default;
V atS_32 = default;
V BLUR_33 = default;
V bbOf_34 = default;
V mt_35 = default;
V wd_36 = default;
V cer_37 = default;
V pt_38 = default;
V N_39 = default;
V em_40 = default;
double PI_41 = 0;
V SA_42 = default;
V CA_43 = default;
V CH_44 = default;
V GOLD_45 = default;
V TI_46 = default;
V CG_47 = default;
V OB_48 = default;
V OB2_49 = default;
V B_50 = default;
V anK_51 = default;
V anD_52 = default;
V atK_53 = default;
V atL_54 = default;
V surf_55 = default;
V isPlay_56 = default;
V isOn_57 = default;
V modeOf_58 = default;
V kts_59 = default;
V pts_60 = default;
V G_61 = default;
V glowL_62 = default;
V polyD_63 = default;
V flash_64 = default;
V plen_65 = default;
V PL_66 = default;
V plOf_67 = default;
V plBB_68 = default;
V PAW_69 = default;
V pawS_70 = default;
V plume_71 = default;
V FGD_72 = default;
V DJV_73 = default;
V draw4_74 = default;
V DJN_75 = default;
V edit4_76 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((RD_8 is var _t77 && !Truthy(_t77) ? _t77 : Get(RD_8, "PLUS4")) is var _t78 && !Truthy(_t78) ? _t78 : Get(RD_8, "H3")) is var _t79 && !Truthy(_t79) ? _t79 : X_9) is var _t80 && !Truthy(_t80) ? _t80 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_81.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS5"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t82 = K_10;
if (_t82.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t82));
{ V _t83 = Get(_t82, "solid");
solid_11 = _t83; }
{ V _t84 = Get(_t82, "box");
box_12 = _t84; }
{ V _t85 = Get(_t82, "cyl");
cyl_13 = _t85; }
{ V _t86 = Get(_t82, "ball");
ball_14 = _t86; }
{ V _t87 = Get(_t82, "slab");
slab_15 = _t87; }
{ V _t88 = Get(_t82, "slabX");
slabX_16 = _t88; }
{ V _t89 = Get(_t82, "arcW");
arcW_17 = _t89; }
{ V _t90 = Get(_t82, "disc");
disc_18 = _t90; }
{ V _t91 = Get(_t82, "prism");
prism_19 = _t91; }
{ V _t92 = Get(_t82, "prismZ");
prismZ_20 = _t92; }
{ V _t93 = Get(_t82, "shade");
shade_21 = _t93; }
{ V _t94 = Get(_t82, "mix");
mix_22 = _t94; }
{ V _t95 = Get(_t82, "f1");
f1_23 = _t95; } }
{ V _t96 = Get(RD_8, "H3");
if (_t96.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t96));
{ V _t97 = Get(_t96, "rep");
rep_24 = _t97; }
{ V _t98 = Get(_t96, "rng");
rng_25 = _t98; }
{ V _t99 = Get(_t96, "n4");
n4_26 = _t99; }
{ V _t100 = Get(_t96, "P2");
P2_27 = _t100; }
{ V _t101 = Get(_t96, "mtx");
mtx_28 = _t101; }
{ V _t102 = Get(_t96, "plane");
plane_29 = _t102; }
{ V _t103 = Get(_t96, "planeH");
planeH_30 = _t103; }
{ V _t104 = Get(_t96, "an");
an_31 = _t104; }
{ V _t105 = Get(_t96, "atS");
atS_32 = _t105; }
{ V _t106 = Get(_t96, "BLUR");
BLUR_33 = _t106; }
{ V _t107 = Get(_t96, "bbOf");
bbOf_34 = _t107; }
{ V _t108 = Get(_t96, "mt");
mt_35 = _t108; }
{ V _t109 = Get(_t96, "wd");
wd_36 = _t109; }
{ V _t110 = Get(_t96, "cer");
cer_37 = _t110; }
{ V _t111 = Get(_t96, "pt");
pt_38 = _t111; } }
N_39 = Get(RD_8, "N");
em_40 = Get(Get(RD_8, "H"), "em");
PI_41 = System.Math.PI;
SA_42 = Get(X_9, "SA");
CA_43 = Get(X_9, "CA");
CH_44 = ((V)("#d5dde2"));
GOLD_45 = ((V)("#e2b14a"));
TI_46 = ((V)("#b8bcc4"));
CG_47 = ((V)("#cdb48a"));
OB_48 = ((V)("#141318"));
OB2_49 = ((V)("#211f28"));
B_50 = Fn((V _arrowThis119, int _argc112, V b_118, V _a115, V _a116, V _a117, V[] _rest113) => {
return ((V)((Truthy(b_118) ? JsStrBuf.Begin().S(" begin=\"").V(Call(n4_26, V.Undef, b_118)).S("s\"").End() : "")));
}, 1, "", true);
anK_51 = Fn((V _arrowThis132, int _argc120, V a_126, V v_127, V d_128, V kt_129, V[] _rest121) => {
V b_130 = default;
V dis_131 = default;
b_130 = (_argc120 > 4 ? _rest121[0] : V.Undef);
dis_131 = (_argc120 > 5 ? _rest121[1] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"").V(a_126).S("\" values=\"").V(v_127).S("\" keyTimes=\"").V(kt_129).S("\" dur=\"").V(Call(n4_26, V.Undef, d_128)).S("s\"").S((Truthy(dis_131) ? " calcMode=\"discrete\"" : "")).V(Call(B_50, V.Undef, b_130)).S(" repeatCount=\"indefinite\"/>").End()));
}, 6, "", true);
anD_52 = Fn((V _arrowThis143, int _argc133, V a_139, V v_140, V d_141, V b_142, V[] _rest134) => {
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"").V(a_139).S("\" values=\"").V(v_140).S("\" dur=\"").V(Call(n4_26, V.Undef, d_141)).S("s\" calcMode=\"discrete\"").V(Call(B_50, V.Undef, b_142)).S(" repeatCount=\"indefinite\"/>").End()));
}, 4, "", true);
atK_53 = Fn((V _arrowThis155, int _argc144, V t_150, V v_151, V d_152, V kt_153, V[] _rest145) => {
V b_154 = default;
b_154 = (_argc144 > 4 ? _rest145[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"").V(t_150).S("\" values=\"").V(v_151).S("\" keyTimes=\"").V(kt_153).S("\" dur=\"").V(Call(n4_26, V.Undef, d_152)).S("s\"").V(Call(B_50, V.Undef, b_154)).S(" repeatCount=\"indefinite\"/>").End()));
}, 5, "", true);
atL_54 = Fn((V _arrowThis166, int _argc156, V t_162, V v_163, V d_164, V b_165, V[] _rest157) => {
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"").V(t_162).S("\" values=\"").V(v_163).S("\" dur=\"").V(Call(n4_26, V.Undef, d_164)).S("s\"").V(Call(B_50, V.Undef, b_165)).S(" repeatCount=\"indefinite\"/>").End()));
}, 4, "", true);
surf_55 = Fn((V _arrowThis177, int _argc167, V p_173, V O_174, V U_175, V V_176, V[] _rest168) => {
return Call(mtx_28, V.Undef, Call(p_173, V.Undef, GetIdx(O_174, 0D), GetIdx(O_174, 1D), GetIdx(O_174, 2D)), Call(p_173, V.Undef, Add(GetIdx(O_174, 0D), GetIdx(U_175, 0D)), Add(GetIdx(O_174, 1D), GetIdx(U_175, 1D)), Add(GetIdx(O_174, 2D), GetIdx(U_175, 2D))), Call(p_173, V.Undef, Add(GetIdx(O_174, 0D), GetIdx(V_176, 0D)), Add(GetIdx(O_174, 1D), GetIdx(V_176, 1D)), Add(GetIdx(O_174, 2D), GetIdx(V_176, 2D))));
}, 4, "", true);
isPlay_56 = Fn((V _arrowThis185, int _argc178, V S_184, V _a181, V _a182, V _a183, V[] _rest179) => {
return Invoke(NewRegExp(RX0, "play", ""), "test", (Get(S_184, "st") is var _t186 && Truthy(_t186) ? _t186 : ((V)(""))));
}, 1, "", true);
isOn_57 = Fn((V _arrowThis194, int _argc187, V S_193, V _a190, V _a191, V _a192, V[] _rest188) => {
return Invoke(NewRegExp(RX1, "(^|\\|)(on|play)$", ""), "test", (Get(S_193, "st") is var _t195 && Truthy(_t195) ? _t195 : ((V)(""))));
}, 1, "", true);
modeOf_58 = Fn((V _arrowThis203, int _argc196, V S_202, V _a199, V _a200, V _a201, V[] _rest197) => {
return GetIdx(Invoke((Get(S_202, "st") is var _t204 && Truthy(_t204) ? _t204 : ((V)(""))), "split", ((V)("|"))), 0D);
}, 1, "", true);
kts_59 = Fn((V _arrowThis212, int _argc205, V a_211, V _a208, V _a209, V _a210, V[] _rest206) => {
return Invoke(Invoke(a_211, "map", n4_26), "join", ((V)(";")));
}, 1, "", true);
pts_60 = Fn((V _arrowThis220, int _argc213, V a_219, V _a216, V _a217, V _a218, V[] _rest214) => {
return Invoke(Invoke(a_219, "map", Fn((V _arrowThis228, int _argc221, V q_227, V _a224, V _a225, V _a226, V[] _rest222) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(q_227, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_227, 1D))).End()));
}, 1, "", true)), "join", ((V)(";")));
}, 1, "", true);
G_61 = Fn((V _arrowThis238, int _argc229, V id_235, V stops_236, V o_237, V _a234, V[] _rest230) => {
return ((V)(JsStrBuf.Begin().S("<").S((Truthy((o_237 is var _t239 && !Truthy(_t239) ? _t239 : Get(o_237, "r"))) ? "radialGradient" : "linearGradient")).S(" id=\"").V(id_235).S("\"").S((Truthy((o_237 is var _t240 && !Truthy(_t240) ? _t240 : Get(o_237, "a"))) ? JsStrBuf.Begin().S(" ").V(Get(o_237, "a")).End() : "")).S(">").V(Invoke(Invoke(stops_236, "map", Fn((V _arrowThis248, int _argc241, V s_247, V _a244, V _a245, V _a246, V[] _rest242) => {
return ((V)(JsStrBuf.Begin().S("<stop offset=\"").V(GetIdx(s_247, 0D)).S("\" stop-color=\"").V(GetIdx(s_247, 1D)).S("\"").S((!GetIdx(s_247, 2D).IsNullish ? JsStrBuf.Begin().S(" stop-opacity=\"").V(GetIdx(s_247, 2D)).S("\"").End() : "")).S("/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</").S((Truthy((o_237 is var _t249 && !Truthy(_t249) ? _t249 : Get(o_237, "r"))) ? "radialGradient" : "linearGradient")).S(">").End()));
}, 3, "", true);
glowL_62 = Fn((V _arrowThis260, int _argc250, V d_256, V c_257, V w_258, V f_259, V[] _rest251) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(d_256).S("\" fill=\"none\" stroke=\"").V(c_257).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(w_258) * 4.2))))).S("\" stroke-linecap=\"round\" stroke-linejoin=\"round\" opacity=\"0.14\"/><path d=\"").V(d_256).S("\" fill=\"none\" stroke=\"").V(c_257).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(w_258) * 2.6))))).S("\" stroke-linecap=\"round\" stroke-linejoin=\"round\" opacity=\"0.26\"/><path d=\"").V(d_256).S("\" fill=\"none\" stroke=\"").V(c_257).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, w_258)).S("\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"").V(d_256).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(w_258) * 0.35))))).S("\" stroke-linecap=\"round\" stroke-linejoin=\"round\" opacity=\"0.85\"/>").End()));
}, 4, "", true);
polyD_63 = Fn((V _arrowThis268, int _argc261, V a_267, V _a264, V _a265, V _a266, V[] _rest262) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(a_267, "map", P2_27), "join", ((V)("L")))).End()));
}, 1, "", true);
flash_64 = Fn((V _arrowThis279, int _argc269, V fs_275, V lo_276, V hi_277, V w_278, V[] _rest270) => {
V q_280 = default;
q_280 = Arr(Arr(((V)(0D)), lo_276));
Invoke(Invoke(Invoke(fs_275, "slice"), "sort", Fn((V _arrowThis300, int _argc292, V a_298, V b_299, V _a296, V _a297, V[] _rest293) => {
return ((V)((ToNum(a_298) - ToNum(b_299))));
}, 2, "", true)), "forEach", Fn((V _arrowThis288, int _argc281, V f_287, V _a284, V _a285, V _a286, V[] _rest282) => {
double a_289 = 0;
double b_290 = 0;
double c_291 = 0;
a_289 = Max(ToNum(Add(GetIdx(GetIdx(q_280, (ToNum(Get(q_280, "length")) - 1D)), 0D), ((V)(0.002)))), (ToNum(f_287) - 0.003));
b_290 = (a_289 + 0.003);
c_291 = Min(0.998, ToNum(Add(((V)(b_290)), w_278)));
if ((c_291 <= (b_290 + 0.001))) {
return default;
}
Invoke(q_280, "push", Arr(((V)(a_289)), lo_276), Arr(((V)(b_290)), hi_277), Arr(((V)(c_291)), lo_276));
return default;
}, 1, "", true));
Invoke(q_280, "push", Arr(((V)(1D)), lo_276));
return NewObj(2).Put("v", Invoke(Invoke(q_280, "map", Fn((V _arrowThis308, int _argc301, V x_307, V _a304, V _a305, V _a306, V[] _rest302) => {
return GetIdx(x_307, 1D);
}, 1, "", true)), "join", ((V)(";")))).Put("kt", Invoke(Invoke(q_280, "map", Fn((V _arrowThis316, int _argc309, V x_315, V _a312, V _a313, V _a314, V[] _rest310) => {
return Call(n4_26, V.Undef, GetIdx(x_315, 0D));
}, 1, "", true)), "join", ((V)(";")))).V;
return default;
}, 4, "", true);
plen_65 = Fn((V _arrowThis324, int _argc317, V P_323, V _a320, V _a321, V _a322, V[] _rest318) => {
V L_325 = default;
L_325 = Arr(((V)(0D)));
{
double i_326 = 0;
i_326 = 1D;
while (true) {
if (!(Lt(((V)(i_326)), Get(P_323, "length")))) break;
Invoke(L_325, "push", Add(GetIdx(L_325, (i_326 - 1D)), ((V)(Hypot((ToNum(GetIdx(GetIdx(P_323, i_326), 0D)) - ToNum(GetIdx(GetIdx(P_323, (i_326 - 1D)), 0D))), (ToNum(GetIdx(GetIdx(P_323, i_326), 1D)) - ToNum(GetIdx(GetIdx(P_323, (i_326 - 1D)), 1D))))))));
i_326++;
}
}
return Invoke(L_325, "map", Fn((V _arrowThis335, int _argc328, V l_334, V _a331, V _a332, V _a333, V[] _rest329) => {
return ((V)((ToNum(l_334) / ToNum(GetIdx(L_325, (ToNum(Get(L_325, "length")) - 1D))))));
}, 1, "", true));
return default;
}, 1, "", true);
PL_66 = NewObj(4).Put("pinball5", Arr(NewObj(4).Put("x", ((V)(88D))).Put("z", ((V)(2D))).Put("v", ((V)("left"))).Put("a", ((V)("pin"))).V)).Put("danceCab", Arr(NewObj(4).Put("x", ((V)((-42D)))).Put("z", ((V)(62D))).Put("v", ((V)("back"))).Put("a", ((V)("dance"))).V, NewObj(5).Put("x", ((V)(42D))).Put("z", ((V)(62D))).Put("v", ((V)("back"))).Put("a", ((V)("dance"))).Put("d", ((V)(0.5))).V)).Put("glowTable", Fn((V _arrowThis343, int _argc336, V st_342, V _a339, V _a340, V _a341, V[] _rest337) => {
return (Truthy(Invoke(NewRegExp(RX2, "bill", "i"), "test", st_342)) ? Arr(NewObj(5).Put("x", ((V)((-106D)))).Put("z", ((V)((-2D)))).Put("v", ((V)("right"))).Put("a", ((V)("watch"))).Put("b", ((V)(1D))).V, NewObj(4).Put("x", ((V)(106D))).Put("z", ((V)(4D))).Put("v", ((V)("left"))).Put("a", ((V)("pool"))).V) : Arr(NewObj(5).Put("x", ((V)((-106D)))).Put("z", ((V)((-2D)))).Put("v", ((V)("right"))).Put("a", ((V)("hockey"))).Put("b", ((V)(1D))).V, NewObj(5).Put("x", ((V)(106D))).Put("z", ((V)(4D))).Put("v", ((V)("left"))).Put("a", ((V)("hockey"))).Put("d", ((V)(0.5))).V));
}, 1, "glowTable", true)).Put("djBooth", Arr(NewObj(5).Put("x", ((V)(0D))).Put("z", ((V)((-44D)))).Put("v", ((V)("front"))).Put("a", ((V)("dj"))).Put("b", ((V)(1D))).V)).V;
plOf_67 = Fn((V _arrowThis352, int _argc344, V k_350, V st_351, V _a348, V _a349, V[] _rest345) => {
V L_353 = default;
L_353 = GetK(PL_66, k_350);
return (string.Equals(Typeof(L_353), "function") ? Call(L_353, V.Undef, (st_351 is var _t354 && Truthy(_t354) ? _t354 : ((V)("")))) : L_353);
return default;
}, 2, "", true);
plBB_68 = Fn((V _arrowThis363, int _argc355, V p_361, V L_362, V _a359, V _a360, V[] _rest356) => {
return InvokeSpread(Arr(), "concat", new ArrBuilder().Spread(Invoke(L_362, "map", Fn((V _arrowThis371, int _argc364, V o_370, V _a367, V _a368, V _a369, V[] _rest365) => {
V q_372 = default;
q_372 = Call(p_361, V.Undef, Get(o_370, "x"), ((V)(0D)), Get(o_370, "z"));
return Arr(Arr(((V)((ToNum(GetIdx(q_372, 0D)) - 40D))), ((V)((ToNum(GetIdx(q_372, 1D)) - 74D)))), Arr(Add(GetIdx(q_372, 0D), ((V)(40D))), Add(GetIdx(q_372, 1D), ((V)(6D)))));
return default;
}, 1, "", true))).V);
}, 2, "", true);
PAW_69 = ((V)("<radialGradient id=\"pwG\" cx=\"38%\" cy=\"32%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#ffd9a8\"/><stop offset=\"0.55\" stop-color=\"#eba45e\"/><stop offset=\"1\" stop-color=\"#b8692c\"/></radialGradient>"));
pawS_70 = Fn((V _arrowThis380, int _argc373, V k_379, V _a376, V _a377, V _a378, V[] _rest374) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"0\" cy=\"").V(Call(f1_23, V.Undef, ((V)((1.4 * ToNum(k_379)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((5.8 * ToNum(k_379)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((3D * ToNum(k_379)))))).S("\" fill=\"#000000\" opacity=\"0.2\"/><ellipse rx=\"").V(Call(f1_23, V.Undef, ((V)((5.4 * ToNum(k_379)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((4.2 * ToNum(k_379)))))).S("\" fill=\"url(#pwG)\" stroke=\"#a35a24\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.35 * ToNum(k_379)))))).S("\"/>").V(Invoke(Invoke(Arr(Arr(((V)((-3.1))), ((V)((-2.7)))), Arr(((V)(0D)), ((V)((-3.5)))), Arr(((V)(3.1)), ((V)((-2.7))))), "map", Fn((V _arrowThis392, int _argc381, V _a383, V _a384, V _a385, V _a386, V[] _rest382) => {
V x_389 = default;
V y_391 = default;
{ V _t387 = ListOf(_a383);
{ V _t388 = GetIdx(_t387, 0D);
x_389 = _t388; }
{ V _t390 = GetIdx(_t387, 1D);
y_391 = _t390; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(x_389) * ToNum(k_379)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(y_391) * ToNum(k_379)))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((1.55 * ToNum(k_379)))))).S("\" fill=\"url(#pwG)\" stroke=\"#a35a24\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.3 * ToNum(k_379)))))).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)(((-1.4) * ToNum(k_379)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-1.2) * ToNum(k_379)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(k_379)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((1D * ToNum(k_379)))))).S("\" fill=\"#ffffff\" opacity=\"0.45\"/>").End()));
}, 1, "", true);
Set(N_39, "pinball5", Fn((V _arrowThis400, int _argc393, V S_399, V _a396, V _a397, V _a398, V[] _rest394) => {
V play_401 = default;
V BODY_402 = default;
V TRIM_403 = default;
V NP_404 = default;
V NC_405 = default;
V NY_406 = default;
double TT_407 = 0;
V yT_408 = default;
V PF_409 = default;
V BUMP_410 = default;
V BALL_411 = default;
V FB_412 = default;
V D_413 = default;
V field_414 = default;
play_401 = Call(isPlay_56, V.Undef, S_399);
BODY_402 = ((V)("#1d1538"));
TRIM_403 = ((V)("#2e2452"));
NP_404 = ((V)("#ff4fb8"));
NC_405 = ((V)("#3ff0ff"));
NY_406 = ((V)("#ffe14f"));
TT_407 = 4.2;
yT_408 = Fn((V _arrowThis422, int _argc415, V x_421, V _a418, V _a419, V _a420, V[] _rest416) => {
return ((V)((57D - ((ToNum(Add(x_421, ((V)(59D)))) * 8D) / 118D))));
}, 1, "", true);
PF_409 = Fn((V _arrowThis430, int _argc423, V p_429, V _a426, V _a427, V _a428, V[] _rest424) => {
return Call(surf_55, V.Undef, p_429, Arr(((V)((-59D))), ((V)(57.3)), ((V)(0D))), Arr(((V)(1D)), ((V)(((-8D) / 118D))), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
}, 1, "", true);
BUMP_410 = Arr(Arr(((V)(30D)), ((V)((-7D))), ((V)("#ff4f6a"))), Arr(((V)(30D)), ((V)(8D)), ((V)("#ffd84f"))), Arr(((V)(44D)), ((V)(0.5)), ((V)("#3fb8ff"))));
BALL_411 = Arr(Arr(((V)(105D)), ((V)((-4.2)))), Arr(((V)(64D)), ((V)((-13D)))), Arr(((V)(47D)), ((V)((-5.8)))), Arr(((V)(37D)), ((V)(0.6))), Arr(((V)(27D)), ((V)(13.4))), Arr(((V)(17D)), ((V)(3D))), Arr(((V)(36D)), ((V)(15.6))), Arr(((V)(79D)), ((V)(17.4))), Arr(((V)(99.5)), ((V)(6D))), Arr(((V)(58D)), ((V)(9D))), Arr(((V)(26D)), ((V)((-15.4)))), Arr(((V)(14D)), ((V)((-5D)))), Arr(((V)(33D)), ((V)(1.8))), Arr(((V)(74D)), ((V)((-17D)))), Arr(((V)(105D)), ((V)((-4.2)))));
FB_412 = Call(plen_65, V.Undef, BALL_411);
D_413 = NewObj(2).Put("w", ((V)(150D))).Put("d", ((V)(64D))).V;
Set(D_413, "build", Fn((V _arrowThis438, int _argc431, V P_437, V _a434, V _a435, V _a436, V[] _rest432) => {
V o_439 = default;
o_439 = Arr();
Invoke(Arr(Arr(((V)(50D)), ((V)(33.4))), Arr(((V)((-50D))), ((V)(37.4)))), "forEach", Fn((V _arrowThis451, int _argc440, V _a442, V _a443, V _a444, V _a445, V[] _rest441) => {
V x_448 = default;
V h_450 = default;
{ V _t446 = ListOf(_a442);
{ V _t447 = GetIdx(_t446, 0D);
x_448 = _t447; }
{ V _t449 = GetIdx(_t446, 1D);
h_450 = _t449; }
}
return Invoke(Arr(((V)((-21D))), ((V)(21D))), "forEach", Fn((V _arrowThis459, int _argc452, V z_458, V _a455, V _a456, V _a457, V[] _rest453) => {
return Invoke(o_439, "push", Call(cyl_13, V.Undef, x_448, ((V)(0D)), z_458, ((V)(3.6)), ((V)(1.6)), ((V)("#26262c")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, x_448, ((V)(1.6)), z_458, ((V)(2D)), ((V)((ToNum(h_450) - 5.2))), CH_44, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, x_448, ((V)((ToNum(h_450) - 3.8))), z_458, ((V)(6.4)), ((V)(4D)), ((V)(6.4)), CH_44, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(o_439, "push", Call(prismZ_20, V.Undef, ((V)((-25D))), ((V)(25D)), Arr(Arr(((V)(59D)), ((V)(33D))), Arr(((V)(59D)), ((V)(49D))), Arr(((V)((-59D))), ((V)(57D))), Arr(((V)((-59D))), ((V)(37D)))), BODY_402, Call(pt_38, V.Undef)));
Invoke(o_439, "push", Call(slabX_16, V.Undef, ((V)(59.5)), ((V)(34.5)), ((V)(0D)), ((V)(1.2)), ((V)(11D)), ((V)(24D)), ((V)("#2c2c34")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slabX_16, V.Undef, ((V)(60.2)), ((V)(41.4)), ((V)((-5D))), ((V)(0.5)), ((V)(3D)), ((V)(2.2)), NY_406, Call(em_40, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(slabX_16, V.Undef, ((V)(60.2)), ((V)(41.4)), ((V)(5D)), ((V)(0.5)), ((V)(3D)), ((V)(2.2)), NY_406, Call(em_40, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(slabX_16, V.Undef, ((V)(60.2)), ((V)(36.4)), ((V)(0D)), ((V)(0.5)), ((V)(1.8)), ((V)(12D)), ((V)("#70758a")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
Invoke(o_439, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((-17D))), ((V)(45.6)))).Put("a", ((V)(0.9))).Put("b", ((V)(0.9))).Put("n", ((V)(8D))).Put("rings", Arr(Arr(((V)(59D)), ((V)(0D))), Arr(((V)(64.5)), ((V)(0D))))).Put("col", CH_44).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(66D)), ((V)(45.6)), ((V)((-17D))), ((V)(2.1)), ((V)("#e8343c")), NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V));
Invoke(o_439, "push", Call(disc_18, V.Undef, ((V)(52D)), ((V)(43.2)), ((V)(25D)), ((V)(1.9)), ((V)(1.3)), NP_404, Call(em_40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
Invoke(o_439, "push", Call(box_12, V.Undef, ((V)((-55.6))), ((V)(55.4)), ((V)(0D)), ((V)(8D)), ((V)(3.4)), ((V)(48D)), CH_44, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((-56D))), ((V)(58.6)), ((V)(0D)), ((V)(10D)), ((V)(50D)), ((V)(54D)), BODY_402, Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)((-56D))), ((V)(108.6)), ((V)(0D)), ((V)(11.4)), ((V)(2.6)), ((V)(55.4)), TRIM_403, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
return o_439;
return default;
}, 1, "", true));
field_414 = Fn((V _arrowThis467, int _argc460, V p_466, V _a463, V _a464, V _a465, V[] _rest461) => {
JsStrBuf f_468 = null;
V flip_469 = default;
f_468 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"").V(Call(PF_409, V.Undef, p_466)).S("\"><g clip-path=\"url(#pbClip)\">").End());
f_468.S("<rect x=\"8\" y=\"-23.4\" width=\"107.5\" height=\"46.8\" fill=\"url(#pbF)\"/><circle cx=\"62\" cy=\"0\" r=\"36\" fill=\"url(#pbGl)\"/>");
f_468.V(Invoke(Call(rep_24, V.Undef, ((V)(12D)), Fn((V _arrowThis477, int _argc470, V i_476, V _a473, V _a474, V _a475, V[] _rest471) => {
double a_478 = 0;
a_478 = ((ToNum(i_476) * PI_41) / 6D);
return ((V)(JsStrBuf.Begin().S("<path d=\"M62 0L").V(Call(f1_23, V.Undef, ((V)((62D + (FdLibm.Cos((a_478 - 0.09)) * 60D)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((FdLibm.Sin((a_478 - 0.09)) * 60D))))).S("L").V(Call(f1_23, V.Undef, ((V)((62D + (FdLibm.Cos((a_478 + 0.09)) * 60D)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((FdLibm.Sin((a_478 + 0.09)) * 60D))))).S("Z\" fill=\"#ffffff\" opacity=\"0.06\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)(""))));
f_468.V(Invoke(Call(rep_24, V.Undef, ((V)(26D)), Fn((V _arrowThis486, int _argc479, V i_485, V _a482, V _a483, V _a484, V[] _rest480) => {
V R2_487 = default;
R2_487 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("pbs").V(i_485).End())));
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)((10D + (ToNum(Call(R2_487, V.Undef)) * 100D)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-22D) + (ToNum(Call(R2_487, V.Undef)) * 44D)))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.25 + (ToNum(Call(R2_487, V.Undef)) * 0.4)))))).S("\" fill=\"#ffffff\" opacity=\"0.6\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>");
f_468.S("<path d=\"M40 -23 Q11 -23 11 0 Q11 23 40 23\" fill=\"none\" stroke=\"#d5dde2\" stroke-width=\"1.3\"/><path d=\"M24 -18.6H110\" stroke=\"#d5dde2\" stroke-width=\"1\"/>");
Invoke(Arr(((V)((-10D))), ((V)((-2D))), ((V)(6D)), ((V)(14D))), "forEach", Fn((V _arrowThis495, int _argc488, V b_494, V _a491, V _a492, V _a493, V[] _rest489) => {
return ((V)(f_468.S("<path d=\"M15 ").V(b_494).S("H23\" stroke=\"#d5dde2\" stroke-width=\"0.9\" stroke-linecap=\"round\"/>").Str));
}, 1, "", true));
Invoke(Arr(((V)((-6D))), ((V)(2D)), ((V)(10D))), "forEach", Fn((V _arrowThis504, int _argc496, V b_502, V i_503, V _a500, V _a501, V[] _rest497) => {
return ((V)(f_468.S("<circle cx=\"19\" cy=\"").V(b_502).S("\" r=\"1.4\" fill=\"").V(NY_406).S("\">").V(Call(anD_52, V.Undef, ((V)("opacity")), ((V)((SEqN(i_503, 0D) ? "1;0.25;0.25" : (SEqN(i_503, 1D) ? "0.25;1;0.25" : "0.25;0.25;1")))), ((V)((Truthy(play_401) ? 0.6 : 1.5))))).S("</circle>").Str));
}, 2, "", true));
Call(rep_24, V.Undef, ((V)(4D)), Fn((V _arrowThis512, int _argc505, V i_511, V _a508, V _a509, V _a510, V[] _rest506) => {
return ((V)(f_468.S("<path d=\"M").N((60D + (ToNum(i_511) * 6D))).S(" 0l4.2 -2.8v5.6Z\" fill=\"").V(GetK(Arr(NP_404, NC_405, NY_406, ((V)("#7dff6a"))), i_511)).S("\" stroke=\"#ffffff\" stroke-width=\"0.25\">").V(Call(anD_52, V.Undef, ((V)("opacity")), Invoke(Call(rep_24, V.Undef, ((V)(4D)), Fn((V _arrowThis520, int _argc513, V j_519, V _a516, V _a517, V _a518, V[] _rest514) => {
return ((V)((SEqN(j_519, (3D - ToNum(i_511))) ? 1D : 0.22)));
}, 1, "", true)), "join", ((V)(";"))), ((V)((Truthy(play_401) ? 0.5 : 1.4))))).S("</path>").Str));
}, 1, "", true));
Invoke(Arr(Arr(((V)(72D)), ((V)(12D))), Arr(((V)(72D)), ((V)((-12D))))), "forEach", Fn((V _arrowThis533, int _argc521, V _a523, V i_527, V _a525, V _a526, V[] _rest522) => {
V a_530 = default;
V b_532 = default;
{ V _t528 = ListOf(_a523);
{ V _t529 = GetIdx(_t528, 0D);
a_530 = _t529; }
{ V _t531 = GetIdx(_t528, 1D);
b_532 = _t531; }
}
return ((V)(f_468.S("<path d=\"M").V(a_530).S(" ").N((ToNum(b_532) - 3D)).S("l0.9 2.1 2.2 0.2-1.7 1.4 0.6 2.2-2-1.2-2 1.2 0.6-2.2-1.7-1.4 2.2-0.2z\" fill=\"").V((Truthy(i_527) ? NC_405 : NP_404)).S("\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("1;0.3;1")), ((V)(1.1)), ((V)(((-ToNum(i_527)) * 0.5))))).S("</path>").Str));
}, 2, "", true));
Invoke(BUMP_410, "forEach", Fn((V _arrowThis548, int _argc534, V _a536, V j_540, V _a538, V _a539, V[] _rest535) => {
V hits_549 = default;
V F_550 = default;
V a_543 = default;
V b_545 = default;
V c_547 = default;
{ V _t541 = ListOf(_a536);
{ V _t542 = GetIdx(_t541, 0D);
a_543 = _t542; }
{ V _t544 = GetIdx(_t541, 1D);
b_545 = _t544; }
{ V _t546 = GetIdx(_t541, 2D);
c_547 = _t546; }
}
hits_549 = Invoke(Invoke(BALL_411, "map", Fn((V _arrowThis567, int _argc559, V q_565, V i_566, V _a563, V _a564, V[] _rest560) => {
return ((Hypot((ToNum(GetIdx(q_565, 0D)) - ToNum(a_543)), (ToNum(GetIdx(q_565, 1D)) - ToNum(b_545))) < 9.5) ? GetK(FB_412, i_566) : ((V)((-1D))));
}, 2, "", true)), "filter", Fn((V _arrowThis558, int _argc551, V x_557, V _a554, V _a555, V _a556, V[] _rest552) => {
return (GeN(x_557, 0D) ? V.True : V.False);
}, 1, "", true));
F_550 = Call(flash_64, V.Undef, hits_549, ((V)(0.15)), ((V)(1D)), ((V)(0.08)));
f_468.S("<circle cx=\"").V(a_543).S("\" cy=\"").V(b_545).S("\" r=\"7.4\" fill=\"").V(c_547).S("\" opacity=\"0.15\">").V((Truthy(play_401) ? Call(anK_51, V.Undef, ((V)("opacity")), Get(F_550, "v"), ((V)(TT_407)), Get(F_550, "kt")) : Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.1;0.35;0.1")), ((V)(1.6)), ((V)(((-ToNum(j_540)) * 0.5)))))).S("</circle>").S("<circle cx=\"").V(Add(a_543, ((V)(0.6)))).S("\" cy=\"").V(Add(b_545, ((V)(0.6)))).S("\" r=\"5\" fill=\"#000000\" opacity=\"0.35\"/><circle cx=\"").V(a_543).S("\" cy=\"").V(b_545).S("\" r=\"4.7\" fill=\"#f2f2f6\" stroke=\"#8a8fa0\" stroke-width=\"0.4\"/><circle cx=\"").V(a_543).S("\" cy=\"").V(b_545).S("\" r=\"3.4\" fill=\"").V(c_547).S("\" stroke=\"").V(Call(shade_21, V.Undef, c_547, ((V)(0.6)))).S("\" stroke-width=\"0.4\"/><circle cx=\"").N((ToNum(a_543) - 1D)).S("\" cy=\"").N((ToNum(b_545) - 1D)).S("\" r=\"1.1\" fill=\"#ffffff\" opacity=\"0.75\"/>");
return default;
}, 2, "", true));
Invoke(Arr(((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis575, int _argc568, V sg_574, V _a571, V _a572, V _a573, V[] _rest569) => {
f_468.S("<path d=\"M80 ").N((19.5 * ToNum(sg_574))).S("L94 ").N((13D * ToNum(sg_574))).S("L82 ").N((13.4 * ToNum(sg_574))).S("Z\" fill=\"").V((GtN(sg_574, 0D) ? NP_404 : NC_405)).S("\" stroke=\"#ffffff\" stroke-width=\"1.1\" stroke-linejoin=\"round\"/><path d=\"M84 ").N((GtN(sg_574, 0D) ? 22D : (-18D))).S("L96.6 ").N((16.4 * ToNum(sg_574))).S("\" stroke=\"#d5dde2\" stroke-width=\"1.1\" stroke-linecap=\"round\"/>");
return default;
}, 1, "", true));
f_468.S("<path d=\"M108 -18.6H115.5V23.4H108Z\" fill=\"#241a48\"/><path d=\"M108 -18.6V-6L103 -2.6M108 23.4V8L103 4.4\" fill=\"none\" stroke=\"#d5dde2\" stroke-width=\"0.8\"/>");
flip_469 = Fn((V _arrowThis587, int _argc576, V px_582, V pz_583, V rest_584, V up_585, V[] _rest577) => {
V F_588 = default;
V fs_586 = default;
fs_586 = (_argc576 > 4 ? _rest577[0] : V.Undef);
F_588 = Call(flash_64, V.Undef, fs_586, rest_584, up_585, ((V)(0.06)));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(px_582).S(" ").V(pz_583).S(")\"><g transform=\"rotate(").V(rest_584).S(")\">").S((Truthy(play_401) ? JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"rotate\" values=\"").V(Get(F_588, "v")).S("\" keyTimes=\"").V(Get(F_588, "kt")).S("\" dur=\"").N(TT_407).S("s\" repeatCount=\"indefinite\"/>").End() : "")).S("<path d=\"M0.4 -1.9A2.3 2.3 0 0 0 0.4 2.7L12 1.7A1.1 1.1 0 0 0 12 -0.5Z\" fill=\"#000000\" opacity=\"0.3\"/><path d=\"M0 -2.3A2.3 2.3 0 0 0 0 2.3L11.6 1.1A1.1 1.1 0 0 0 11.6 -1.1Z\" fill=\"#f6f6f2\" stroke=\"").V(NP_404).S("\" stroke-width=\"0.7\"/><circle r=\"0.9\" fill=\"#c9ccd6\"/></g></g>").End()));
return default;
}, 5, "", true);
f_468.V(Add(Call(flip_469, V.Undef, ((V)(96D)), ((V)(15D)), ((V)((-51D))), ((V)((-93D))), Arr(GetIdx(FB_412, 8D))), Call(flip_469, V.Undef, ((V)(96D)), ((V)((-15D))), ((V)(51D)), ((V)(93D)), Arr(((V)(0.001))))));
f_468.S((Truthy(play_401) ? JsStrBuf.Begin().S("<circle r=\"1.9\" fill=\"url(#pbBl)\" stroke=\"#6a6f80\" stroke-width=\"0.2\"><animateMotion dur=\"").N(TT_407).S("s\" repeatCount=\"indefinite\" path=\"").V(Call(polyD_63, V.Undef, BALL_411)).S("\"/></circle>").End() : "<circle cx=\"111.5\" cy=\"-21\" r=\"1.9\" fill=\"url(#pbBl)\" stroke=\"#6a6f80\" stroke-width=\"0.2\"/>"));
return ((V)(string.Concat(f_468.Str, "</g>")));
return default;
}, 1, "", true);
Set(D_413, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis596, int _argc589, V P_595, V _a592, V _a593, V _a594, V[] _rest590) => {
V rl_597 = default;
rl_597 = Fn((V _arrowThis605, int _argc598, V z0_604, V _a601, V _a602, V _a603, V[] _rest599) => {
return Call(prismZ_20, V.Undef, z0_604, Add(z0_604, ((V)(2.6))), Arr(Arr(((V)(59.2)), ((V)(48.6))), Arr(((V)(59.2)), ((V)(51.4))), Arr(((V)((-51D))), Add(Call(yT_408, V.Undef, ((V)((-51D)))), ((V)(2.6)))), Arr(((V)((-51D))), ((V)((ToNum(Call(yT_408, V.Undef, ((V)((-51D))))) - 0.4))))), CH_44, Call(mt_35, V.Undef, NewObj(1).Put("shine", ((V)(1D))).V));
}, 1, "", true);
return Arr(Call(rl_597, V.Undef, ((V)(22.8))), Call(rl_597, V.Undef, ((V)((-25.4)))), Call(box_12, V.Undef, ((V)(57D)), ((V)(48.4)), ((V)(0D)), ((V)(4.6)), ((V)(3.4)), ((V)(52.4)), CH_44, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(1.4))).Put("shine", ((V)(1D))).V)));
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis614, int _argc606, V p_612, V s_613, V _a610, V _a611, V[] _rest607) => {
return Add(Call(field_414, V.Undef, p_612), s_613);
}, 2, "wrap", true)).V));
Set(D_413, "fx", Fn((V _arrowThis622, int _argc615, V c_621, V _a618, V _a619, V _a620, V[] _rest616) => {
V p_623 = default;
V k_624 = default;
JsStrBuf f_625 = null;
V FF_626 = default;
double ZS_627 = 0;
V BGV_628 = default;
V SD_629 = default;
V top_630 = default;
V bot_631 = default;
V band_632 = default;
V BG_633 = default;
JsStrBuf bg_634 = null;
V dmd_635 = default;
V fl_636 = default;
V un_637 = default;
V defs_638 = default;
p_623 = Get(c_621, "p");
k_624 = Get(c_621, "k");
f_625 = new JsStrBuf("");
f_625.S("<g transform=\"").V(Call(PF_409, V.Undef, p_623)).S("\"><rect x=\"8\" y=\"-23\" width=\"107.5\" height=\"46\" fill=\"url(#pbGlass)\"/><path d=\"M14 -21L40 21\" stroke=\"#ffffff\" stroke-width=\"0.5\" opacity=\"0.25\"/></g>");
FF_626 = Fn((V _arrowThis648, int _argc639, V O_645, V U_646, V V_647, V _a644, V[] _rest640) => {
V a_649 = default;
V b_650 = default;
V c2_651 = default;
a_649 = Call(p_623, V.Undef, GetIdx(O_645, 0D), GetIdx(O_645, 1D), GetIdx(O_645, 2D));
b_650 = Call(p_623, V.Undef, Add(GetIdx(O_645, 0D), GetIdx(U_646, 0D)), Add(GetIdx(O_645, 1D), GetIdx(U_646, 1D)), Add(GetIdx(O_645, 2D), GetIdx(U_646, 2D)));
c2_651 = Call(p_623, V.Undef, Add(GetIdx(O_645, 0D), GetIdx(V_647, 0D)), Add(GetIdx(O_645, 1D), GetIdx(V_647, 1D)), Add(GetIdx(O_645, 2D), GetIdx(V_647, 2D)));
return (((((ToNum(GetIdx(b_650, 0D)) - ToNum(GetIdx(a_649, 0D))) * (ToNum(GetIdx(c2_651, 1D)) - ToNum(GetIdx(a_649, 1D)))) - ((ToNum(GetIdx(b_650, 1D)) - ToNum(GetIdx(a_649, 1D))) * (ToNum(GetIdx(c2_651, 0D)) - ToNum(GetIdx(a_649, 0D))))) > 0D) ? V.True : V.False);
return default;
}, 3, "", true);
ZS_627 = (Truthy(Call(FF_626, V.Undef, Arr(((V)((-59D))), ((V)(0D)), ((V)(25.4))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))) ? 25.4 : (-25.4));
BGV_628 = Call(FF_626, V.Undef, Arr(((V)((-50.8))), ((V)(108.2)), ((V)(25.6))), Arr(((V)(0D)), ((V)(0D)), ((V)((-1D)))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
Set(c_621, "pbZ", ((V)(ZS_627)));
Set(c_621, "pbBG", BGV_628);
SD_629 = Call(surf_55, V.Undef, p_623, Arr(((V)((-59D))), ((V)(0D)), ((V)(ZS_627))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
top_630 = Fn((V _arrowThis659, int _argc652, V u_658, V _a655, V _a656, V _a657, V[] _rest653) => {
return ((V)((-(57D - ((ToNum(u_658) * 8D) / 118D)))));
}, 1, "", true);
bot_631 = Fn((V _arrowThis667, int _argc660, V u_666, V _a663, V _a664, V _a665, V[] _rest661) => {
return ((V)((-(37D - ((ToNum(u_666) * 4D) / 118D)))));
}, 1, "", true);
band_632 = Fn((V _arrowThis676, int _argc668, V a_674, V b_675, V _a672, V _a673, V[] _rest669) => {
return ((V)(JsStrBuf.Begin().S("M0 ").V(Call(f1_23, V.Undef, Add(Call(top_630, V.Undef, ((V)(0D))), a_674))).S("L118 ").V(Call(f1_23, V.Undef, Add(Call(top_630, V.Undef, ((V)(118D))), a_674))).S("L118 ").V(Call(f1_23, V.Undef, Add(Call(top_630, V.Undef, ((V)(118D))), b_675))).S("L0 ").V(Call(f1_23, V.Undef, Add(Call(top_630, V.Undef, ((V)(0D))), b_675))).S("Z").End()));
}, 2, "", true);
f_625.S("<g transform=\"").V(SD_629).S("\"><path d=\"").V(Call(band_632, V.Undef, ((V)(2.6)), ((V)(5.4)))).S("\" fill=\"").V(NP_404).S("\">").V((Truthy(play_401) ? Call(an_31, V.Undef, ((V)("opacity")), ((V)("1;0.55;1")), ((V)(0.8))) : ((V)("")))).S("</path><path d=\"").V(Call(band_632, V.Undef, ((V)(6.6)), ((V)(7.8)))).S("\" fill=\"").V(NC_405).S("\">").V((Truthy(play_401) ? Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.55;1;0.55")), ((V)(0.8))) : ((V)("")))).S("</path>").S("<path d=\"M28 -48l2.4 5.6 6 0.5-4.6 3.9 1.4 5.9-5.2-3.2-5.2 3.2 1.4-5.9-4.6-3.9 6-0.5z\" fill=\"").V(NY_406).S("\" stroke=\"#ffffff\" stroke-width=\"0.5\"/><path d=\"M60 -46l-6 7h4l-3 6 8-8h-4l3-5z\" fill=\"").V(NC_405).S("\"/><circle cx=\"84\" cy=\"-43\" r=\"1.3\" fill=\"#ffffff\" opacity=\"0.7\"/><circle cx=\"96\" cy=\"-40\" r=\"0.9\" fill=\"#ffffff\" opacity=\"0.6\"/>").S("<path d=\"M0 ").V(Call(f1_23, V.Undef, Call(top_630, V.Undef, ((V)(0D))))).S("L118 ").V(Call(f1_23, V.Undef, Call(top_630, V.Undef, ((V)(118D))))).S("L118 ").V(Call(f1_23, V.Undef, Call(bot_631, V.Undef, ((V)(118D))))).S("L0 ").V(Call(f1_23, V.Undef, Call(bot_631, V.Undef, ((V)(0D))))).S("Z\" fill=\"url(#pbSide)\"/></g>");
BG_633 = Call(surf_55, V.Undef, p_623, Arr(((V)((-50.8))), ((V)(108.2)), ((V)(25.6))), Arr(((V)(0D)), ((V)(0D)), ((V)((-1D)))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
bg_634 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"1.5\" y=\"1.5\" width=\"48.2\" height=\"32\" rx=\"1.5\" fill=\"url(#pbBG)\"/>").V(Invoke(Call(rep_24, V.Undef, ((V)(18D)), Fn((V _arrowThis684, int _argc677, V i_683, V _a680, V _a681, V _a682, V[] _rest678) => {
V R2_685 = default;
R2_685 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("bgs").V(i_683).End())));
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)((3D + (ToNum(Call(R2_685, V.Undef)) * 45D)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((3D + (ToNum(Call(R2_685, V.Undef)) * 28D)))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.2 + (ToNum(Call(R2_685, V.Undef)) * 0.4)))))).S("\" fill=\"#ffffff\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.3;1;0.3")), Call(n4_26, V.Undef, ((V)((1D + (ToNum(Call(R2_685, V.Undef)) * 2D))))), ((V)(((-ToNum(Call(R2_685, V.Undef))) * 2D))))).S("</circle>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).End());
bg_634.S("<circle cx=\"39\" cy=\"10\" r=\"5.6\" fill=\"url(#pbPl)\"/><ellipse cx=\"39\" cy=\"10.6\" rx=\"9\" ry=\"2\" fill=\"none\" stroke=\"").V(NY_406).S("\" stroke-width=\"0.7\" transform=\"rotate(-14 39 10.6)\"/><path d=\"M9 6l-3 6h3l-2 5 6-7h-3l2-4z\" fill=\"").V(NY_406).S("\"/>");
bg_634.S("<text x=\"25.6\" y=\"25.4\" text-anchor=\"middle\" font-family=\"Arial Black, Arial, sans-serif\" font-weight=\"900\" font-style=\"italic\" font-size=\"8.2\" fill=\"").V(NP_404).S("\" filter=\"url(#pbBl2)\" opacity=\"0.9\">STAR BALL").V((Truthy(play_401) ? Call(anD_52, V.Undef, ((V)("opacity")), ((V)("0.9;0.4")), ((V)(0.5))) : ((V)("")))).S("</text><text x=\"25.6\" y=\"25.4\" text-anchor=\"middle\" font-family=\"Arial Black, Arial, sans-serif\" font-weight=\"900\" font-style=\"italic\" font-size=\"8.2\" fill=\"#ffffff\" stroke=\"").V(NP_404).S("\" stroke-width=\"0.45\">STAR BALL</text>");
bg_634.S("<rect x=\"5\" y=\"36\" width=\"41.4\" height=\"10.6\" rx=\"0.8\" fill=\"#140900\" stroke=\"#3a2a10\" stroke-width=\"0.5\"/>");
dmd_635 = Fn((V _arrowThis694, int _argc686, V t_692, V op_693, V _a690, V _a691, V[] _rest687) => {
return ((V)(JsStrBuf.Begin().S("<text x=\"25.7\" y=\"43.6\" text-anchor=\"middle\" font-family=\"Courier New, monospace\" font-weight=\"700\" font-size=\"5.4\" fill=\"#ff9a2e\" opacity=\"").V(op_693).S("\">").V(t_692).End()));
}, 2, "", true);
if (Truthy(play_401)) {
V SC_695 = default;
V nS_696 = default;
SC_695 = Arr(((V)("1,284,500")), ((V)("1,302,750")), ((V)("1,327,000")), ((V)("1,358,250")), ((V)("JACKPOT!")));
nS_696 = Get(SC_695, "length");
Invoke(SC_695, "forEach", Fn((V _arrowThis705, int _argc697, V t_703, V i_704, V _a701, V _a702, V[] _rest698) => {
return ((V)(bg_634.V(Add(Call(dmd_635, V.Undef, t_703, ((V)((Truthy(i_704) ? 0D : 1D)))), Call(anD_52, V.Undef, ((V)("opacity")), Invoke(Call(rep_24, V.Undef, nS_696, Fn((V _arrowThis713, int _argc706, V j_712, V _a709, V _a710, V _a711, V[] _rest707) => {
return ((V)((SEq(j_712, i_704) ? 1D : 0D)));
}, 1, "", true)), "join", ((V)(";"))), ((V)((ToNum(nS_696) * 0.84)))))).S("</text>").Str));
}, 2, "", true));
} else {
Invoke(Arr(((V)("PRESS START")), ((V)("HI 9,870,120"))), "forEach", Fn((V _arrowThis722, int _argc714, V t_720, V i_721, V _a718, V _a719, V[] _rest715) => {
return ((V)(bg_634.V(Add(Call(dmd_635, V.Undef, t_720, ((V)((Truthy(i_721) ? 0D : 1D)))), Call(anD_52, V.Undef, ((V)("opacity")), ((V)((Truthy(i_721) ? "0;1" : "1;0"))), ((V)(3.2))))).S("</text>").Str));
}, 2, "", true));
}
bg_634.S("<rect x=\"5\" y=\"36\" width=\"41.4\" height=\"10.6\" fill=\"url(#pbDot)\"/>");
if (Truthy(BGV_628)) {
f_625.S("<g transform=\"").V(BG_633).S("\">").S(bg_634.Str).S("<rect x=\"1.5\" y=\"1.5\" width=\"48.2\" height=\"32\" rx=\"1.5\" fill=\"url(#pbGlass)\"/></g>");
}
Invoke(Arr(((V)((-27.4))), ((V)(27.4))), "forEach", Fn((V _arrowThis731, int _argc723, V z_729, V i_730, V _a727, V _a728, V[] _rest724) => {
V a_732 = default;
V b_733 = default;
a_732 = Call(p_623, V.Undef, ((V)((-51D))), ((V)(59D)), z_729);
b_733 = Call(p_623, V.Undef, ((V)((-51D))), ((V)(108D)), z_729);
f_625.S("<g>").V((Truthy(play_401) ? Call(an_31, V.Undef, ((V)("opacity")), ((V)("1;0.55;1")), ((V)(0.6)), ((V)(((-ToNum(i_730)) * 0.3)))) : ((V)("")))).V(Call(glowL_62, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P2_27, V.Undef, a_732)).S("L").V(Call(P2_27, V.Undef, b_733)).End())), (Truthy(i_730) ? NC_405 : NP_404), ((V)((1.1 * ToNum(k_624)))), ((V)("pbBl2")))).S("</g>");
return default;
}, 2, "", true));
{
V a_734 = default;
V b_735 = default;
a_734 = Call(p_623, V.Undef, ((V)((-51D))), ((V)(110.6)), ((V)((-27.4))));
b_735 = Call(p_623, V.Undef, ((V)((-51D))), ((V)(110.6)), ((V)(27.4)));
f_625.V(Call(glowL_62, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P2_27, V.Undef, a_734)).S("L").V(Call(P2_27, V.Undef, b_735)).End())), NY_406, ((V)((1D * ToNum(k_624)))), ((V)("pbBl2"))));
}
fl_636 = Call(p_623, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
un_637 = ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(fl_636, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(fl_636, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((80D * ToNum(k_624)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((((80D * ToNum(k_624)) * ToNum(SA_42)) * 0.55))))).S("\" fill=\"").V(NP_404).S("\" opacity=\"").N((Truthy(play_401) ? 0.24 : 0.12)).S("\" filter=\"url(#pbBl2)\">").V((Truthy(play_401) ? Call(an_31, V.Undef, ((V)("fill")), ((V)(JsStrBuf.Begin().V(NP_404).S(";").V(NC_405).S(";").V(NP_404).End())), ((V)(1.6))) : ((V)("")))).S("</ellipse>").End()));
defs_638 = ((V)(JsStrBuf.Begin().V(Add(PAW_69, Call(BLUR_33, V.Undef, ((V)("pbBl2")), ((V)(1.2))))).S("<clipPath id=\"pbClip\"><rect x=\"8\" y=\"-23.4\" width=\"107.5\" height=\"46.8\"/></clipPath>").V(Call(G_61, V.Undef, ((V)("pbF")), Arr(Arr(((V)(0D)), ((V)("#1a0f4a"))), Arr(((V)(0.55)), ((V)("#3a1678"))), Arr(((V)(1D)), ((V)("#121a52")))))).V(Call(G_61, V.Undef, ((V)("pbGl")), Arr(Arr(((V)(0D)), ((V)("#ff4fb8")), ((V)(0.45))), Arr(((V)(1D)), ((V)("#ff4fb8")), ((V)(0D)))), NewObj(1).Put("r", ((V)(1D))).V)).V(Call(G_61, V.Undef, ((V)("pbBl")), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(0.5)), ((V)("#c9ccd6"))), Arr(((V)(1D)), ((V)("#5a5f70")))), NewObj(2).Put("r", ((V)(1D))).Put("a", ((V)("cx=\"35%\" cy=\"30%\" r=\"70%\""))).V)).V(Call(G_61, V.Undef, ((V)("pbGlass")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(0.42)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(0.48)), ((V)("#ffffff")), ((V)(0.3))), Arr(((V)(0.56)), ((V)("#ffffff")), ((V)(0.05))), Arr(((V)(0.62)), ((V)("#ffffff")), ((V)(0.18))), Arr(((V)(0.68)), ((V)("#ffffff")), ((V)(0D)))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\""))).V)).V(Call(G_61, V.Undef, ((V)("pbBG")), Arr(Arr(((V)(0D)), ((V)("#2a0a5a"))), Arr(((V)(0.6)), ((V)("#8a1a8a"))), Arr(((V)(1D)), ((V)("#ff6a3c")))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\""))).V)).V(Call(G_61, V.Undef, ((V)("pbPl")), Arr(Arr(((V)(0D)), ((V)("#9fe8ff"))), Arr(((V)(1D)), ((V)("#2a5aa8")))), NewObj(2).Put("r", ((V)(1D))).Put("a", ((V)("cx=\"35%\" cy=\"30%\" r=\"75%\""))).V)).V(Call(G_61, V.Undef, ((V)("pbSide")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.16))), Arr(((V)(0.4)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(1D)), ((V)("#000000")), ((V)(0.25)))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\""))).V)).S("<pattern id=\"pbDot\" width=\"0.9\" height=\"0.9\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 0H0.9V0.9\" fill=\"none\" stroke=\"#140900\" stroke-width=\"0.28\"/></pattern>").End()));
return NewObj(4).Put("defs", defs_638).Put("under", un_637).Put("front", ((V)(f_625.Str))).Put("bb", Call(bbOf_34, V.Undef, Invoke(Arr(Call(p_623, V.Undef, ((V)((-62D))), ((V)(113D)), ((V)((-28D)))), Call(p_623, V.Undef, ((V)((-62D))), ((V)(113D)), ((V)(28D))), Call(p_623, V.Undef, ((V)(66D)), ((V)(0D)), ((V)(26D))), Call(p_623, V.Undef, ((V)(66D)), ((V)(0D)), ((V)((-26D)))), Call(p_623, V.Undef, ((V)((-62D))), ((V)(0D)), ((V)(26D)))), "concat", Call(plBB_68, V.Undef, p_623, Get(PL_66, "pinball5"))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_413;
return default;
}, 1, "", true));
Set(N_39, "danceCab", Fn((V _arrowThis743, int _argc736, V S_742, V _a739, V _a740, V _a741, V[] _rest737) => {
V play_744 = default;
V BODY_745 = default;
V WING_746 = default;
V NC_747 = default;
V NP_748 = default;
V NY_749 = default;
double BEAT_750 = 0;
double CYC_751 = 0;
V CAB_752 = default;
V WG_753 = default;
V PADX_754 = default;
double PZ_755 = 0;
double CELL_756 = 0;
V DIRC_757 = default;
V ROT_758 = default;
V STEPS_759 = default;
V ARW_760 = default;
V CELLS_761 = default;
V D_762 = default;
play_744 = Call(isPlay_56, V.Undef, S_742);
BODY_745 = ((V)("#20232c"));
WING_746 = ((V)("#c9d0d8"));
NC_747 = ((V)("#3ff0ff"));
NP_748 = ((V)("#ff4fb8"));
NY_749 = ((V)("#ffe14f"));
BEAT_750 = 0.36;
CYC_751 = (BEAT_750 * 8D);
CAB_752 = Arr(Arr(((V)((-30D))), ((V)(0D))), Arr(((V)(12D)), ((V)(0D))), Arr(((V)(12D)), ((V)(50D))), Arr(((V)(0D)), ((V)(116D))), Arr(((V)(10D)), ((V)(122D))), Arr(((V)(10D)), ((V)(150D))), Arr(((V)((-30D))), ((V)(150D))));
WG_753 = Arr(Arr(((V)((-32D))), ((V)(0D))), Arr(((V)(16D)), ((V)(0D))), Arr(((V)(16D)), ((V)(52D))), Arr(((V)(4D)), ((V)(116D))), Arr(((V)(14D)), ((V)(121D))), Arr(((V)(14D)), ((V)(152D))), Arr(((V)((-32D))), ((V)(152D))));
PADX_754 = Arr(((V)((-42D))), ((V)(42D)));
PZ_755 = 62D;
CELL_756 = 22D;
DIRC_757 = Arr(((V)("#ff5fc8")), ((V)("#5fb0ff")), ((V)("#5fffb8")), ((V)("#ffd85f")));
ROT_758 = Arr(((V)((-90D))), ((V)(180D)), ((V)(0D)), ((V)(90D)));
STEPS_759 = Arr(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(2D)), ((V)(1D)), ((V)(0D)), ((V)(3D))), Arr(((V)(3D)), ((V)(2D)), ((V)(1D)), ((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(0D))));
ARW_760 = ((V)("M0 -2.8L2.8 0H1.2V2.8H-1.2V0H-2.8Z"));
CELLS_761 = Arr(Arr(((V)((-1D))), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(1D)), ((V)(1D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(2D))), Arr(((V)(1D)), ((V)(0D)), ((V)(3D))));
D_762 = NewObj(2).Put("w", ((V)(176D))).Put("d", ((V)(140D))).V;
Set(D_762, "build", Fn((V _arrowThis770, int _argc763, V P_769, V _a766, V _a767, V _a768, V[] _rest764) => {
V o_771 = default;
o_771 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(60D)), ((V)(178D)), ((V)(5D)), ((V)(80D)), ((V)("#2a2c34")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(0.6)), ((V)(100.4)), ((V)(176D)), ((V)(3D)), ((V)(0.6)), NC_747, Call(em_40, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
Invoke(PADX_754, "forEach", Fn((V _arrowThis779, int _argc772, V px_778, V _a775, V _a776, V _a777, V[] _rest773) => {
Invoke(o_771, "push", Call(box_12, V.Undef, px_778, ((V)(5D)), ((V)(PZ_755)), ((V)(72D)), ((V)(1D)), ((V)(72D)), ((V)("#8e96a0")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
{
double i_780 = 0;
i_780 = (-1D);
while (true) {
if (!((i_780 <= 1D))) break;
{
double j_782 = 0;
j_782 = (-1D);
while (true) {
if (!((j_782 <= 1D))) break;
V arrow_784 = default;
arrow_784 = (!SEq(((i_780 == 0D) ? V.True : V.False), ((j_782 == 0D) ? V.True : V.False)) ? V.True : V.False);
Invoke(o_771, "push", Call(box_12, V.Undef, Add(px_778, ((V)((i_780 * (CELL_756 + 1D))))), ((V)(6D)), ((V)((PZ_755 + (j_782 * (CELL_756 + 1D))))), ((V)(CELL_756)), ((V)(1.3)), ((V)(CELL_756)), ((V)((Truthy(arrow_784) ? "#1a2433" : "#b9c0c8"))), (Truthy(arrow_784) ? Call(cer_37, V.Undef, NewObj(2).Put("r", ((V)(1.4))).Put("op", ((V)(0.96))).V) : Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(1.4))).Put("shine", ((V)(1D))).V))));
j_782++;
}
}
i_780++;
}
}
return default;
}, 1, "", true));
Invoke(o_771, "push", Call(prism_19, V.Undef, ((V)((-40D))), ((V)(40D)), CAB_752, BODY_745, Call(pt_38, V.Undef)), Call(prism_19, V.Undef, ((V)((-46D))), ((V)((-40D))), WG_753, WING_746, Call(mt_35, V.Undef, NewObj(1).Put("shine", ((V)(1D))).V)), Call(prism_19, V.Undef, ((V)(40D)), ((V)(46D)), WG_753, WING_746, Call(mt_35, V.Undef, NewObj(1).Put("shine", ((V)(1D))).V)));
Invoke(Arr(((V)((-22D))), ((V)(22D))), "forEach", Fn((V _arrowThis792, int _argc785, V x_791, V _a788, V _a789, V _a790, V[] _rest786) => {
return Invoke(o_771, "push", Call(disc_18, V.Undef, x_791, ((V)(28D)), ((V)(12D)), ((V)(10D)), ((V)(1D)), ((V)("#121318")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(disc_18, V.Undef, x_791, ((V)(28D)), ((V)(13D)), ((V)(7.4)), ((V)(0.8)), ((V)("#2a2c33")), NewObj(1).Put("n", ((V)(18D))).V), Call(disc_18, V.Undef, x_791, ((V)(28D)), ((V)(13.8)), ((V)(2.6)), ((V)(0.8)), ((V)("#44474f")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
}, 1, "", true));
Invoke(o_771, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(12.6)), ((V)(13D)), ((V)(14D)), ((V)(0.8)), ((V)("#3a3d48")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slab_15, V.Undef, ((V)(0D)), ((V)(15D)), ((V)(13.1)), ((V)(6D)), ((V)(1.6)), ((V)(0.4)), NY_749, Call(em_40, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(47D)), ((V)(16D)), ((V)(80D)), ((V)(4D)), ((V)(10D)), ((V)("#2c2f3a")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(cyl_13, V.Undef, ((V)((-30D))), ((V)(51D)), ((V)(16D)), ((V)(2.4)), ((V)(1.2)), NP_748, Call(em_40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, ((V)(30D)), ((V)(51D)), ((V)(16D)), ((V)(2.4)), ((V)(1.2)), NC_747, Call(em_40, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, ((V)((-24D))), ((V)(51D)), ((V)(16D)), ((V)(1.6)), ((V)(1D)), ((V)("#f4f6f8")), NewObj(1).Put("n", ((V)(10D))).V), Call(cyl_13, V.Undef, ((V)(24D)), ((V)(51D)), ((V)(16D)), ((V)(1.6)), ((V)(1D)), ((V)("#f4f6f8")), NewObj(1).Put("n", ((V)(10D))).V));
Invoke(o_771, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(123D)), ((V)(10.3)), ((V)(76D)), ((V)(25D)), ((V)(0.6)), ((V)("#140a3a")), NewObj(1).Put("r", ((V)(1D))).V));
Invoke(Arr(((V)((-43D))), ((V)(43D))), "forEach", Fn((V _arrowThis800, int _argc793, V x_799, V _a796, V _a797, V _a798, V[] _rest794) => {
return Invoke(o_771, "push", Call(cyl_13, V.Undef, x_799, ((V)(152D)), ((V)((-8D))), ((V)(3.8)), ((V)(3D)), ((V)("#2a2c34")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, x_799, ((V)(155D)), ((V)((-8D))), ((V)(3D)), ((V)(22D)), ((V)("#f2f8ff")), Call(cer_37, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("op", ((V)(0.5))).V)), Call(cyl_13, V.Undef, x_799, ((V)(177D)), ((V)((-8D))), ((V)(3.8)), ((V)(2.4)), ((V)("#2a2c34")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
}, 1, "", true));
return o_771;
return default;
}, 1, "", true));
Set(D_762, "fx", Fn((V _arrowThis808, int _argc801, V c_807, V _a804, V _a805, V _a806, V[] _rest802) => {
V p_809 = default;
V k_810 = default;
JsStrBuf f_811 = null;
JsStrBuf un_812 = null;
V SCR_813 = default;
JsStrBuf s_814 = null;
V MQ_815 = default;
JsStrBuf m_816 = null;
V bl_817 = default;
V fl_818 = default;
V defs_819 = default;
p_809 = Get(c_807, "p");
k_810 = Get(c_807, "k");
f_811 = new JsStrBuf("");
un_812 = new JsStrBuf("");
SCR_813 = Call(surf_55, V.Undef, p_809, Arr(((V)((-32D))), ((V)(112D)), ((V)(1.4))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-0.9839))), ((V)(0.1789))));
s_814 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"64\" height=\"57\" rx=\"1.5\" fill=\"url(#dcS)\"/><g transform=\"translate(32 30)\" opacity=\"0.22\"><g>").V(Call(atL_54, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(16D)))).V(Invoke(Call(rep_24, V.Undef, ((V)(8D)), Fn((V _arrowThis827, int _argc820, V i_826, V _a823, V _a824, V _a825, V[] _rest821) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0L").V(Call(f1_23, V.Undef, ((V)((FdLibm.Cos((((ToNum(i_826) * PI_41) / 4D) - 0.12)) * 50D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((FdLibm.Sin((((ToNum(i_826) * PI_41) / 4D) - 0.12)) * 50D))))).S("L").V(Call(f1_23, V.Undef, ((V)((FdLibm.Cos((((ToNum(i_826) * PI_41) / 4D) + 0.12)) * 50D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((FdLibm.Sin((((ToNum(i_826) * PI_41) / 4D) + 0.12)) * 50D))))).S("Z\" fill=\"#ffffff\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g></g>").End());
Invoke(Arr(((V)(0D)), ((V)(1D))), "forEach", Fn((V _arrowThis835, int _argc828, V pl_834, V _a831, V _a832, V _a833, V[] _rest829) => {
double x0_836 = 0;
x0_836 = (Truthy(pl_834) ? 39D : 7D);
s_814.S("<rect x=\"").N((x0_836 - 3.6)).S("\" y=\"4\" width=\"24.2\" height=\"52\" rx=\"1\" fill=\"#000000\" opacity=\"0.3\"/><rect x=\"").N((x0_836 - 3.4)).S("\" y=\"1.4\" width=\"24\" height=\"1.8\" rx=\"0.9\" fill=\"#2a2a40\"/><rect x=\"").N((x0_836 - 3.4)).S("\" y=\"1.4\" width=\"17\" height=\"1.8\" rx=\"0.9\" fill=\"url(#dcL)\">").V(Call(an_31, V.Undef, ((V)("width")), ((V)((Truthy(play_744) ? "15;21;18;23;15" : "12;14;12"))), ((V)((Truthy(play_744) ? 2.4 : 4D))))).S("</rect>");
Call(rep_24, V.Undef, ((V)(4D)), Fn((V _arrowThis844, int _argc837, V d_843, V _a840, V _a841, V _a842, V[] _rest838) => {
double lx_845 = 0;
V hit_846 = default;
lx_845 = (x0_836 + (ToNum(d_843) * 6D));
hit_846 = Invoke(Invoke(GetK(STEPS_759, pl_834), "map", Fn((V _arrowThis854, int _argc847, V v_853, V _a850, V _a851, V _a852, V[] _rest848) => {
return ((V)((SEq(v_853, d_843) ? 1D : 0.18)));
}, 1, "", true)), "join", ((V)(";")));
s_814.S("<g transform=\"translate(").N(lx_845).S(" 7) rotate(").V(GetK(ROT_758, d_843)).S(")\"><path d=\"").V(ARW_760).S("\" fill=\"none\" stroke=\"#c9d0e8\" stroke-width=\"0.6\"/><path d=\"").V(ARW_760).S("\" fill=\"").V(GetK(DIRC_757, d_843)).S("\" opacity=\"0.18\" transform=\"scale(1.25)\">").V(Call(anD_52, V.Undef, ((V)("opacity")), hit_846, ((V)(CYC_751)))).S("</path></g>");
return default;
}, 1, "", true));
Invoke(GetK(STEPS_759, pl_834), "forEach", Fn((V _arrowThis863, int _argc855, V d_861, V i_862, V _a859, V _a860, V[] _rest856) => {
double lx_864 = 0;
double b_865 = 0;
lx_864 = (x0_836 + (ToNum(d_861) * 6D));
b_865 = ((ToNum(i_862) * BEAT_750) - (CYC_751 / 2D));
s_814.S("<g transform=\"translate(").N(lx_864).S(" 56)\">").V(Call(atK_53, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().N(lx_864).S(" 56;").N(lx_864).S(" 7;").N(lx_864).S(" 7").End())), ((V)(CYC_751)), ((V)("0;0.5;1")), ((V)(b_865)))).V(Call(anK_51, V.Undef, ((V)("opacity")), ((V)("1;0")), ((V)(CYC_751)), ((V)("0;0.5")), ((V)(b_865)), ((V)(1D)))).S("<g transform=\"rotate(").V(GetK(ROT_758, d_861)).S(")\"><path d=\"").V(ARW_760).S("\" fill=\"").V(GetK(DIRC_757, d_861)).S("\" stroke=\"#ffffff\" stroke-width=\"0.4\" transform=\"scale(1.1)\"/></g></g>");
return default;
}, 2, "", true));
return default;
}, 1, "", true));
if (Truthy(play_744)) {
s_814.S("<text x=\"32\" y=\"33\" text-anchor=\"middle\" font-family=\"Arial Black, Arial, sans-serif\" font-weight=\"900\" font-style=\"italic\" font-size=\"6.4\" fill=\"#ffe14f\" stroke=\"#ff4fb8\" stroke-width=\"0.35\">PERFECT!!").V(Call(anD_52, V.Undef, ((V)("opacity")), ((V)("1;0.35")), ((V)(BEAT_750)))).S("</text><text x=\"32\" y=\"40\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"800\" font-size=\"3.6\" fill=\"#ffffff\">COMBO 128</text>");
} else {
s_814.S("<text x=\"32\" y=\"32\" text-anchor=\"middle\" font-family=\"Arial Black, Arial, sans-serif\" font-weight=\"900\" font-style=\"italic\" font-size=\"7\" fill=\"#ffffff\" stroke=\"#3ff0ff\" stroke-width=\"0.35\">BEAT STEP</text><text x=\"32\" y=\"40\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"800\" font-size=\"3.6\" fill=\"#ffe14f\">PRESS START").V(Call(anD_52, V.Undef, ((V)("opacity")), ((V)("1;0")), ((V)(1.2)))).S("</text>");
}
s_814.S("<rect width=\"64\" height=\"57\" rx=\"1.5\" fill=\"url(#dcGl)\"/><rect width=\"64\" height=\"57\" rx=\"1.5\" fill=\"none\" stroke=\"#0b0c10\" stroke-width=\"1.6\"/>");
f_811.S("<g transform=\"").V(SCR_813).S("\">").S(s_814.Str).S("</g>");
MQ_815 = Call(surf_55, V.Undef, p_809, Arr(((V)((-38D))), ((V)(147.6)), ((V)(10.95))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
m_816 = new JsStrBuf("<rect width=\"76\" height=\"23\" rx=\"1.4\" fill=\"url(#dcM)\"/><text x=\"38\" y=\"14.6\" text-anchor=\"middle\" font-family=\"Arial Black, Arial, sans-serif\" font-weight=\"900\" font-style=\"italic\" font-size=\"11\" fill=\"#ffe14f\" stroke=\"#ff4fb8\" stroke-width=\"0.6\" letter-spacing=\"0.4\">BEAT STEP</text><text x=\"38\" y=\"20\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"800\" font-size=\"3.4\" fill=\"#ffffff\" letter-spacing=\"1.2\">2 PLAYER DANCE</text>");
bl_817 = Arr();
Call(rep_24, V.Undef, ((V)(13D)), Fn((V _arrowThis873, int _argc866, V i_872, V _a869, V _a870, V _a871, V[] _rest867) => {
return Invoke(bl_817, "push", Arr(((V)((3D + (ToNum(i_872) * 5.83)))), ((V)(1.8))));
}, 1, "", true));
Call(rep_24, V.Undef, ((V)(3D)), Fn((V _arrowThis881, int _argc874, V i_880, V _a877, V _a878, V _a879, V[] _rest875) => {
return Invoke(bl_817, "push", Arr(((V)(74.2)), ((V)((6.6 + (ToNum(i_880) * 5D))))));
}, 1, "", true));
Call(rep_24, V.Undef, ((V)(13D)), Fn((V _arrowThis889, int _argc882, V i_888, V _a885, V _a886, V _a887, V[] _rest883) => {
return Invoke(bl_817, "push", Arr(((V)((73D - (ToNum(i_888) * 5.83)))), ((V)(21.2))));
}, 1, "", true));
Call(rep_24, V.Undef, ((V)(3D)), Fn((V _arrowThis897, int _argc890, V i_896, V _a893, V _a894, V _a895, V[] _rest891) => {
return Invoke(bl_817, "push", Arr(((V)(1.8)), ((V)((16.6 - (ToNum(i_896) * 5D))))));
}, 1, "", true));
Invoke(bl_817, "forEach", Fn((V _arrowThis910, int _argc898, V _a900, V i_904, V _a902, V _a903, V[] _rest899) => {
V x_907 = default;
V y_909 = default;
{ V _t905 = ListOf(_a900);
{ V _t906 = GetIdx(_t905, 0D);
x_907 = _t906; }
{ V _t908 = GetIdx(_t905, 1D);
y_909 = _t908; }
}
return ((V)(m_816.S("<circle cx=\"").V(Call(f1_23, V.Undef, x_907)).S("\" cy=\"").V(Call(f1_23, V.Undef, y_909)).S("\" r=\"0.9\" fill=\"#fff6c8\">").V(Call(anD_52, V.Undef, ((V)("opacity")), Invoke(Call(rep_24, V.Undef, ((V)(4D)), Fn((V _arrowThis918, int _argc911, V j_917, V _a914, V _a915, V _a916, V[] _rest912) => {
return ((V)((SEqN(j_917, (ToNum(i_904) % 4D)) ? 1D : 0.25)));
}, 1, "", true)), "join", ((V)(";"))), ((V)((Truthy(play_744) ? 0.32 : 0.8))))).S("</circle>").Str));
}, 2, "", true));
f_811.S("<g transform=\"").V(MQ_815).S("\">").S(m_816.Str).S("<rect width=\"76\" height=\"23\" rx=\"1.4\" fill=\"url(#dcGl)\"/></g>");
Invoke(Arr(((V)((-43D))), ((V)(43D))), "forEach", Fn((V _arrowThis927, int _argc919, V x_925, V i_926, V _a923, V _a924, V[] _rest920) => {
V pp_928 = default;
V q_929 = default;
pp_928 = Invoke(Invoke(WG_753, "slice", ((V)(1D)), ((V)(6D))), "map", Fn((V _arrowThis941, int _argc930, V _a932, V _a933, V _a934, V _a935, V[] _rest931) => {
V z_938 = default;
V y_940 = default;
{ V _t936 = ListOf(_a932);
{ V _t937 = GetIdx(_t936, 0D);
z_938 = _t937; }
{ V _t939 = GetIdx(_t936, 1D);
y_940 = _t939; }
}
return Call(p_809, V.Undef, x_925, y_940, Add(z_938, ((V)(0.4))));
}, 1, "", true));
f_811.S("<g>").V((Truthy(play_744) ? Call(an_31, V.Undef, ((V)("opacity")), ((V)("1;0.5;1")), ((V)((BEAT_750 * 2D))), ((V)(((-ToNum(i_926)) * BEAT_750)))) : ((V)("")))).V(Call(glowL_62, V.Undef, Call(polyD_63, V.Undef, pp_928), (Truthy(i_926) ? NC_747 : NP_748), ((V)((1.1 * ToNum(k_810)))), ((V)("dcB")))).S("</g>");
q_929 = Call(p_809, V.Undef, x_925, ((V)(166D)), ((V)((-8D))));
f_811.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_929, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_929, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((4.6 * ToNum(k_810)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((13D * ToNum(k_810)))))).S("\" fill=\"").V((Truthy(i_926) ? NC_747 : NP_748)).S("\" opacity=\"0.6\" filter=\"url(#dcB)\">").V(Call(an_31, V.Undef, ((V)("fill")), Invoke(Arr(NP_748, NY_749, NC_747, NP_748), "join", ((V)(";"))), ((V)((Truthy(play_744) ? 1.4 : 4D))), ((V)(((-ToNum(i_926)) * 0.7))))).S("</ellipse>");
return default;
}, 2, "", true));
if (Truthy(play_744)) {
Invoke(Arr(((V)((-22D))), ((V)(22D))), "forEach", Fn((V _arrowThis950, int _argc942, V x_948, V i_949, V _a946, V _a947, V[] _rest943) => {
V q_951 = default;
q_951 = Call(p_809, V.Undef, x_948, ((V)(28D)), ((V)(14D)));
f_811.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_951, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_951, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((10D * ToNum(k_810)))))).S("\" fill=\"none\" stroke=\"").V(NC_747).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.8 * ToNum(k_810)))))).S("\">").V(Call(an_31, V.Undef, ((V)("r")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((8D * ToNum(k_810)))))).S(";").V(Call(f1_23, V.Undef, ((V)((16D * ToNum(k_810)))))).End())), ((V)(BEAT_750)))).V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.8;0")), ((V)(BEAT_750)))).S("</circle>");
return default;
}, 2, "", true));
}
Invoke(PADX_754, "forEach", Fn((V _arrowThis960, int _argc952, V px_958, V pl_959, V _a956, V _a957, V[] _rest953) => {
return Invoke(CELLS_761, "forEach", Fn((V _arrowThis974, int _argc961, V _a963, V _a964, V _a965, V _a966, V[] _rest962) => {
V g_975 = default;
V hit_976 = default;
V idle_977 = default;
V i_969 = default;
V j_971 = default;
V d_973 = default;
{ V _t967 = ListOf(_a963);
{ V _t968 = GetIdx(_t967, 0D);
i_969 = _t968; }
{ V _t970 = GetIdx(_t967, 1D);
j_971 = _t970; }
{ V _t972 = GetIdx(_t967, 2D);
d_973 = _t972; }
}
g_975 = Call(planeH_30, V.Undef, p_809, ((V)(7.4)), Add(px_958, ((V)((ToNum(i_969) * (CELL_756 + 1D))))), ((V)((PZ_755 + (ToNum(j_971) * (CELL_756 + 1D))))));
hit_976 = Invoke(Invoke(GetK(STEPS_759, pl_959), "map", Fn((V _arrowThis985, int _argc978, V v_984, V _a981, V _a982, V _a983, V[] _rest979) => {
return ((V)((SEq(v_984, d_973) ? 1D : (Truthy(play_744) ? 0.16 : 0.3))));
}, 1, "", true)), "join", ((V)(";")));
idle_977 = Invoke(Call(rep_24, V.Undef, ((V)(8D)), Fn((V _arrowThis993, int _argc986, V t_992, V _a989, V _a990, V _a991, V[] _rest987) => {
return ((V)((((ToNum(Add(Add(t_992, d_973), pl_959)) % 4D) == 0D) ? 0.85 : 0.25)));
}, 1, "", true)), "join", ((V)(";")));
f_811.S("<g transform=\"").V(g_975).S("\"><rect x=\"-10\" y=\"-10\" width=\"20\" height=\"20\" rx=\"1.6\" fill=\"").V(GetK(DIRC_757, d_973)).S("\" opacity=\"0.3\" filter=\"url(#dcB)\">").V(Call(anD_52, V.Undef, ((V)("opacity")), (Truthy(play_744) ? hit_976 : idle_977), ((V)(CYC_751)))).S("</rect><g transform=\"rotate(").V(GetK(ROT_758, d_973)).S(") scale(2.4)\"><path d=\"").V(ARW_760).S("\" fill=\"").V(GetK(DIRC_757, d_973)).S("\" stroke=\"#ffffff\" stroke-width=\"0.25\">").V(Call(anD_52, V.Undef, ((V)("opacity")), (Truthy(play_744) ? hit_976 : idle_977), ((V)(CYC_751)))).S("</path></g></g>");
return default;
}, 1, "", true));
}, 2, "", true));
fl_818 = Call(p_809, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(60D)));
un_812.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(fl_818, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(fl_818, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((110D * ToNum(k_810)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((((110D * ToNum(k_810)) * ToNum(SA_42)) * 0.6))))).S("\" fill=\"").V(NC_747).S("\" opacity=\"").N((Truthy(play_744) ? 0.22 : 0.1)).S("\" filter=\"url(#dcB)\">").V((Truthy(play_744) ? Call(an_31, V.Undef, ((V)("fill")), ((V)(JsStrBuf.Begin().V(NC_747).S(";").V(NP_748).S(";").V(NC_747).End())), ((V)(CYC_751))) : ((V)("")))).S("</ellipse>");
defs_819 = Add(Add(Add(Add(Call(BLUR_33, V.Undef, ((V)("dcB")), ((V)(1.4))), Call(G_61, V.Undef, ((V)("dcS")), Arr(Arr(((V)(0D)), ((V)("#14093a"))), Arr(((V)(0.55)), ((V)("#3a1670"))), Arr(((V)(1D)), ((V)("#0b2a5a")))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\""))).V)), Call(G_61, V.Undef, ((V)("dcL")), Arr(Arr(((V)(0D)), ((V)("#3ff0ff"))), Arr(((V)(1D)), ((V)("#7dff6a")))))), Call(G_61, V.Undef, ((V)("dcM")), Arr(Arr(((V)(0D)), ((V)("#1a0a4a"))), Arr(((V)(0.5)), ((V)("#6a1a9a"))), Arr(((V)(1D)), ((V)("#1a0a4a")))))), Call(G_61, V.Undef, ((V)("dcGl")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.22))), Arr(((V)(0.35)), ((V)("#ffffff")), ((V)(0.02))), Arr(((V)(0.6)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(1D)), ((V)("#ffffff")), ((V)(0.06)))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\""))).V));
return NewObj(4).Put("defs", defs_819).Put("under", ((V)(un_812.Str))).Put("front", ((V)(f_811.Str))).Put("bb", Call(bbOf_34, V.Undef, Invoke(Arr(Call(p_809, V.Undef, ((V)((-47D))), ((V)(180D)), ((V)((-30D)))), Call(p_809, V.Undef, ((V)(47D)), ((V)(180D)), ((V)((-30D)))), Call(p_809, V.Undef, ((V)((-90D))), ((V)(0D)), ((V)(102D))), Call(p_809, V.Undef, ((V)(90D)), ((V)(0D)), ((V)(102D))), Call(p_809, V.Undef, ((V)(90D)), ((V)(0D)), ((V)(18D))), Call(p_809, V.Undef, ((V)((-90D))), ((V)(0D)), ((V)(18D)))), "concat", Call(plBB_68, V.Undef, p_809, Get(PL_66, "danceCab"))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_762;
return default;
}, 1, "", true));
Set(N_39, "glowTable", Fn((V _arrowThis1001, int _argc994, V S_1000, V _a997, V _a998, V _a999, V[] _rest995) => {
V bill_1002 = default;
V play_1003 = default;
V BODY_1004 = default;
V RAIL_1005 = default;
V LED_1006 = default;
V LED2_1007 = default;
V BRS_1008 = default;
double HX_1009 = 0;
double HZ_1010 = 0;
double SY_1011 = 0;
V D_1012 = default;
V art_1013 = default;
V kOf2_1014 = default;
bill_1002 = Invoke(NewRegExp(RX2, "bill", "i"), "test", Call(modeOf_58, V.Undef, S_1000));
play_1003 = Call(isPlay_56, V.Undef, S_1000);
BODY_1004 = ((V)("#4a2c1a"));
RAIL_1005 = ((V)("#5c3822"));
LED_1006 = ((V)((Truthy(bill_1002) ? "#ffb45a" : "#ffd9a0")));
LED2_1007 = ((V)("#f6c070"));
BRS_1008 = ((V)("#c8a050"));
HX_1009 = 75D;
HZ_1010 = 42D;
SY_1011 = 38.6;
D_1012 = NewObj(2).Put("w", ((V)(160D))).Put("d", ((V)(92D))).V;
Set(D_1012, "build", Fn((V _arrowThis1022, int _argc1015, V P_1021, V _a1018, V _a1019, V _a1020, V[] _rest1016) => {
V o_1023 = default;
o_1023 = Arr();
Invoke(Arr(((V)((-46D))), ((V)(46D))), "forEach", Fn((V _arrowThis1031, int _argc1024, V x_1030, V _a1027, V _a1028, V _a1029, V[] _rest1025) => {
return Invoke(o_1023, "push", Call(box_12, V.Undef, x_1030, ((V)(0D)), ((V)(0D)), ((V)(28D)), ((V)(4D)), ((V)(62D)), ((V)("#2e1c10")), Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, x_1030, ((V)(0D)), ((V)(0D)), ((V)(28.4)), ((V)(0.8)), ((V)(62.4)), BRS_1008, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, x_1030, ((V)(4D)), ((V)(0D)), ((V)(20D)), ((V)(24D)), ((V)(48D)), BODY_1004, Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, x_1030, ((V)(4D)), ((V)(0D)), ((V)(21D)), ((V)(1.4)), ((V)(49D)), BRS_1008, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, x_1030, ((V)(20D)), ((V)(24.2)), ((V)(12D)), ((V)(2.6)), ((V)(0.6)), BRS_1008, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(0.3))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_1023, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(74D)), ((V)(8D)), ((V)(14D)), BODY_1004, Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(0D)), ((V)((2D * HX_1009))), ((V)(10D)), ((V)((2D * HZ_1010))), BODY_1004, Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(27.4)), ((V)(0D)), ((V)(((2D * HX_1009) + 0.6))), ((V)(1.2)), ((V)(((2D * HZ_1010) + 0.6))), BRS_1008, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(30.6)), ((V)((HZ_1010 + 0.1))), ((V)(36D)), ((V)(5.6)), ((V)(0.8)), ((V)("#0b0c10")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
return o_1023;
return default;
}, 1, "", true));
art_1013 = Fn((V _arrowThis1039, int _argc1032, V p_1038, V _a1035, V _a1036, V _a1037, V[] _rest1033) => {
JsStrBuf f_1040 = null;
f_1040 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"").V(Call(planeH_30, V.Undef, p_1038, ((V)(SY_1011)))).S("\">").End());
if (!(Truthy(bill_1002))) {
f_1040.S("<rect x=\"-69\" y=\"-36\" width=\"138\" height=\"72\" rx=\"3\" fill=\"url(#gtI)\"/><rect x=\"-69\" y=\"-36\" width=\"138\" height=\"72\" rx=\"3\" fill=\"url(#gtH)\" opacity=\"0.6\"/>").S("<path d=\"M0 -36V36\" stroke=\"#b8323a\" stroke-width=\"1.4\"/><path d=\"M-24 -36V36M24 -36V36\" stroke=\"#2a4a8a\" stroke-width=\"0.9\"/><circle r=\"10\" fill=\"none\" stroke=\"#2a4a8a\" stroke-width=\"0.9\"/><circle r=\"1.4\" fill=\"#2a4a8a\"/>").S("<path d=\"M-69 -12A12 12 0 0 1 -69 12M69 -12A12 12 0 0 0 69 12\" fill=\"none\" stroke=\"#b8323a\" stroke-width=\"0.9\"/><rect x=\"-69.6\" y=\"-9\" width=\"2.6\" height=\"18\" fill=\"#0a0b10\"/><rect x=\"67\" y=\"-9\" width=\"2.6\" height=\"18\" fill=\"#0a0b10\"/>");
f_1040.S((Truthy(play_1003) ? "<g><animateMotion dur=\"2.4s\" repeatCount=\"indefinite\" path=\"M-60 0L-22 33L16 -33L58 3L24 33L-14 -33L-60 0\"/><ellipse cx=\"0.5\" cy=\"0.6\" rx=\"3.4\" ry=\"3.4\" fill=\"#000000\" opacity=\"0.25\"/><circle r=\"3.2\" fill=\"#ff3b5c\" stroke=\"#8a1a2a\" stroke-width=\"0.5\"/><circle r=\"1.9\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.35\" opacity=\"0.6\"/></g>" : "<circle r=\"3.2\" fill=\"#ff3b5c\" stroke=\"#8a1a2a\" stroke-width=\"0.5\"/>"));
} else {
f_1040.S("<rect x=\"-69\" y=\"-36\" width=\"138\" height=\"72\" rx=\"2\" fill=\"url(#gtF)\"/><path d=\"M34 -36V36\" stroke=\"#efe6cc\" stroke-width=\"0.4\" stroke-dasharray=\"2 2\" opacity=\"0.45\"/><circle cx=\"-34\" cy=\"0\" r=\"0.8\" fill=\"#efe6cc\"/><circle cx=\"34\" cy=\"0\" r=\"0.8\" fill=\"#efe6cc\"/>");
Invoke(Arr(Arr(((V)((-69D))), ((V)((-36D)))), Arr(((V)(0D)), ((V)((-37.5)))), Arr(((V)(69D)), ((V)((-36D)))), Arr(((V)((-69D))), ((V)(36D))), Arr(((V)(0D)), ((V)(37.5))), Arr(((V)(69D)), ((V)(36D)))), "forEach", Fn((V _arrowThis1053, int _argc1041, V _a1043, V i_1047, V _a1045, V _a1046, V[] _rest1042) => {
V x_1050 = default;
V z_1052 = default;
{ V _t1048 = ListOf(_a1043);
{ V _t1049 = GetIdx(_t1048, 0D);
x_1050 = _t1049; }
{ V _t1051 = GetIdx(_t1048, 1D);
z_1052 = _t1051; }
}
return ((V)(f_1040.S("<circle cx=\"").V(x_1050).S("\" cy=\"").V(z_1052).S("\" r=\"4.6\" fill=\"#120c08\"/><circle cx=\"").V(x_1050).S("\" cy=\"").V(z_1052).S("\" r=\"3.4\" fill=\"#2a1a10\"/><circle cx=\"").V(x_1050).S("\" cy=\"").V(z_1052).S("\" r=\"4.6\" fill=\"none\" stroke=\"").V(BRS_1008).S("\" stroke-width=\"1.1\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("1;0.75;1")), ((V)(1.6)), ((V)(((-ToNum(i_1047)) * 0.27))))).S("</circle>").Str));
}, 2, "", true));
}
f_1040.S("<rect x=\"-69\" y=\"-36\" width=\"138\" height=\"72\" rx=\"3\" fill=\"none\" stroke=\"").V(LED_1006).S("\" stroke-width=\"1.4\" opacity=\"0.4\" filter=\"url(#gtB)\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.45;0.25;0.45")), ((V)((Truthy(play_1003) ? 1.2 : 3D))))).S("</rect>");
return ((V)(string.Concat(f_1040.Str, "</g>")));
return default;
}, 1, "", true);
Set(D_1012, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1061, int _argc1054, V P_1060, V _a1057, V _a1058, V _a1059, V[] _rest1055) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(38D)), ((V)((HZ_1010 - 3D))), ((V)((2D * HX_1009))), ((V)(4.6)), ((V)(6D)), RAIL_1005, Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(1.4))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(38D)), ((V)((-(HZ_1010 - 3D)))), ((V)((2D * HX_1009))), ((V)(4.6)), ((V)(6D)), RAIL_1005, Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(1.4))).V)), Call(box_12, V.Undef, ((V)((HX_1009 - 3D))), ((V)(38D)), ((V)(0D)), ((V)(6D)), ((V)(4.6)), ((V)(((2D * HZ_1010) - 12D))), RAIL_1005, Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(1.4))).V)), Call(box_12, V.Undef, ((V)((-(HX_1009 - 3D)))), ((V)(38D)), ((V)(0D)), ((V)(6D)), ((V)(4.6)), ((V)(((2D * HZ_1010) - 12D))), RAIL_1005, Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(1.4))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1070, int _argc1062, V p_1068, V s_1069, V _a1066, V _a1067, V[] _rest1063) => {
V k_1071 = default;
JsStrBuf e_1072 = null;
k_1071 = Call(kOf2_1014, V.Undef, p_1068);
e_1072 = new JsStrBuf("");
Invoke(Arr(Arr(((V)(((-HX_1009) + 6D))), ((V)((HZ_1010 - 6D))), ((V)((HX_1009 - 6D))), ((V)((HZ_1010 - 6D)))), Arr(((V)(((-HX_1009) + 6D))), ((V)(((-HZ_1010) + 6D))), ((V)((HX_1009 - 6D))), ((V)(((-HZ_1010) + 6D)))), Arr(((V)((HX_1009 - 6D))), ((V)(((-HZ_1010) + 6D))), ((V)((HX_1009 - 6D))), ((V)((HZ_1010 - 6D)))), Arr(((V)(((-HX_1009) + 6D))), ((V)(((-HZ_1010) + 6D))), ((V)(((-HX_1009) + 6D))), ((V)((HZ_1010 - 6D))))), "forEach", Fn((V _arrowThis1089, int _argc1073, V _a1075, V i_1079, V _a1077, V _a1078, V[] _rest1074) => {
V a_1082 = default;
V b_1084 = default;
V c2_1086 = default;
V d_1088 = default;
{ V _t1080 = ListOf(_a1075);
{ V _t1081 = GetIdx(_t1080, 0D);
a_1082 = _t1081; }
{ V _t1083 = GetIdx(_t1080, 1D);
b_1084 = _t1083; }
{ V _t1085 = GetIdx(_t1080, 2D);
c2_1086 = _t1085; }
{ V _t1087 = GetIdx(_t1080, 3D);
d_1088 = _t1087; }
}
return ((V)(e_1072.V(Call(glowL_62, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P2_27, V.Undef, Call(p_1068, V.Undef, a_1082, ((V)(42.7)), b_1084))).S("L").V(Call(P2_27, V.Undef, Call(p_1068, V.Undef, c2_1086, ((V)(42.7)), d_1088))).End())), (NumTruthy((ToNum(i_1079) % 2D)) ? LED2_1007 : LED_1006), ((V)((0.7 * ToNum(k_1071)))), ((V)("gtB")))).Str));
}, 2, "", true));
if (Truthy(bill_1002)) {
Call(rep_24, V.Undef, ((V)(6D)), Fn((V _arrowThis1097, int _argc1090, V i_1096, V _a1093, V _a1094, V _a1095, V[] _rest1091) => {
double x_1098 = 0;
V a_1099 = default;
V b_1100 = default;
x_1098 = ((-50D) + (ToNum(i_1096) * 20D));
a_1099 = Call(p_1068, V.Undef, ((V)(x_1098)), ((V)(42.7)), ((V)((HZ_1010 - 3D))));
b_1100 = Call(p_1068, V.Undef, ((V)(x_1098)), ((V)(42.7)), ((V)(((-HZ_1010) + 3D))));
e_1072.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(a_1099, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(a_1099, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.8 * ToNum(k_1071)))))).S("\" fill=\"#ffffff\"/><circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(b_1100, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(b_1100, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.8 * ToNum(k_1071)))))).S("\" fill=\"#ffffff\"/>");
return default;
}, 1, "", true));
}
return ((V)(JsStrBuf.Begin().V(Add(Call(art_1013, V.Undef, p_1068), s_1069)).S(e_1072.Str).End()));
return default;
}, 2, "wrap", true)).V));
kOf2_1014 = Fn((V _arrowThis1108, int _argc1101, V p_1107, V _a1104, V _a1105, V _a1106, V[] _rest1102) => {
return ((V)(((ToNum(GetIdx(Call(p_1107, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D))), 1D)) - ToNum(GetIdx(Call(p_1107, V.Undef, ((V)(0D)), ((V)(1D)), ((V)(0D))), 1D))) / ToNum(CA_43))));
}, 1, "", true);
Set(D_1012, "fx", Fn((V _arrowThis1116, int _argc1109, V c_1115, V _a1112, V _a1113, V _a1114, V[] _rest1110) => {
V p_1117 = default;
V k_1118 = default;
JsStrBuf f_1119 = null;
V SC_1120 = default;
V fl_1121 = default;
V un_1122 = default;
V defs_1123 = default;
p_1117 = Get(c_1115, "p");
k_1118 = Get(c_1115, "k");
f_1119 = new JsStrBuf("");
if (!(Truthy(bill_1002))) {
V H_1124 = default;
V FH_1125 = default;
V f3_1126 = default;
V mallet_1127 = default;
H_1124 = Arr(Arr(((V)((-60D))), ((V)(0D))), Arr(((V)((-22D))), ((V)(33D))), Arr(((V)(16D)), ((V)((-33D)))), Arr(((V)(58D)), ((V)(3D))), Arr(((V)(24D)), ((V)(33D))), Arr(((V)((-14D))), ((V)((-33D)))), Arr(((V)((-60D))), ((V)(0D))));
FH_1125 = Call(plen_65, V.Undef, H_1124);
f3_1126 = GetIdx(FH_1125, 3D);
mallet_1127 = Fn((V _arrowThis1136, int _argc1128, V col_1134, V kf_1135, V _a1132, V _a1133, V[] _rest1129) => {
V vals_1137 = default;
vals_1137 = Invoke(kf_1135, "map", Fn((V _arrowThis1151, int _argc1138, V _a1140, V _a1141, V _a1142, V _a1143, V[] _rest1139) => {
V t_1146 = default;
V x_1148 = default;
V z_1150 = default;
{ V _t1144 = ListOf(_a1140);
{ V _t1145 = GetIdx(_t1144, 0D);
t_1146 = _t1145; }
{ V _t1147 = GetIdx(_t1144, 1D);
x_1148 = _t1147; }
{ V _t1149 = GetIdx(_t1144, 2D);
z_1150 = _t1149; }
}
return Call(p_1117, V.Undef, x_1148, ((V)(SY_1011)), z_1150);
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_27, V.Undef, GetIdx(vals_1137, 0D))).S(")\">").V((Truthy(play_1003) ? Call(atK_53, V.Undef, ((V)("translate")), Call(pts_60, V.Undef, vals_1137), ((V)(2.4)), Call(kts_59, V.Undef, Invoke(kf_1135, "map", Fn((V _arrowThis1159, int _argc1152, V q_1158, V _a1155, V _a1156, V _a1157, V[] _rest1153) => {
return GetIdx(q_1158, 0D);
}, 1, "", true)))) : ((V)("")))).S("<ellipse cx=\"0\" cy=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(k_1118)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((5D * ToNum(k_1118)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((5D * ToNum(k_1118)) * ToNum(SA_42)))))).S("\" fill=\"#000000\" opacity=\"0.25\"/><ellipse rx=\"").V(Call(f1_23, V.Undef, ((V)((4.6 * ToNum(k_1118)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((4.6 * ToNum(k_1118)) * ToNum(SA_42)))))).S("\" fill=\"").V(Call(shade_21, V.Undef, col_1134, ((V)(0.7)))).S("\"/><path d=\"M").V(Call(f1_23, V.Undef, ((V)(((-4.6) * ToNum(k_1118)))))).S(" 0V").V(Call(f1_23, V.Undef, ((V)(((-1.6) * ToNum(k_1118)))))).S("A").V(Call(f1_23, V.Undef, ((V)((4.6 * ToNum(k_1118)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((4.6 * ToNum(k_1118)) * ToNum(SA_42)))))).S(" 0 0 1 ").V(Call(f1_23, V.Undef, ((V)((4.6 * ToNum(k_1118)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-1.6) * ToNum(k_1118)))))).S("V0Z\" fill=\"").V(col_1134).S("\"/>").S("<ellipse cy=\"").V(Call(f1_23, V.Undef, ((V)(((-1.6) * ToNum(k_1118)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((4.6 * ToNum(k_1118)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((4.6 * ToNum(k_1118)) * ToNum(SA_42)))))).S("\" fill=\"").V(Call(mix_22, V.Undef, col_1134, ((V)("#ffffff")), ((V)(0.25)))).S("\"/><rect x=\"").V(Call(f1_23, V.Undef, ((V)(((-1.1) * ToNum(k_1118)))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)(((-6.4) * ToNum(k_1118)))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((2.2 * ToNum(k_1118)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((4.8 * ToNum(k_1118)))))).S("\" fill=\"").V(Call(shade_21, V.Undef, col_1134, ((V)(0.85)))).S("\"/><ellipse cy=\"").V(Call(f1_23, V.Undef, ((V)(((-6.6) * ToNum(k_1118)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(k_1118)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(k_1118)))))).S("\" fill=\"").V(col_1134).S("\"/><ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)(((-0.7) * ToNum(k_1118)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-7D) * ToNum(k_1118)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((0.8 * ToNum(k_1118)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((0.5 * ToNum(k_1118)))))).S("\" fill=\"#ffffff\" opacity=\"0.7\"/></g>").End()));
return default;
}, 2, "", true);
f_1119.V(Call(mallet_1127, V.Undef, ((V)("#ffd84f")), (Truthy(play_1003) ? Arr(Arr(((V)(0D)), ((V)((-64D))), ((V)(0D))), Arr(((V)(0.08)), ((V)((-58D))), ((V)(1D))), Arr(((V)(0.4)), ((V)((-64D))), ((V)(12D))), Arr(((V)(0.75)), ((V)((-63D))), ((V)((-10D)))), Arr(((V)(0.93)), ((V)((-67D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-64D))), ((V)(0D)))) : Arr(Arr(((V)(0D)), ((V)((-60D))), ((V)(0D)))))));
f_1119.V(Call(mallet_1127, V.Undef, ((V)("#3fdc6a")), (Truthy(play_1003) ? Arr(Arr(((V)(0D)), ((V)(64D)), ((V)((-8D)))), Arr(((V)((ToNum(f3_1126) - 0.12))), ((V)(66D)), ((V)(5D))), Arr(f3_1126, ((V)(62D)), ((V)(3D))), Arr(Add(f3_1126, ((V)(0.08))), ((V)(57D)), ((V)(2D))), Arr(((V)(0.8)), ((V)(64D)), ((V)(12D))), Arr(((V)(1D)), ((V)(64D)), ((V)((-8D))))) : Arr(Arr(((V)(0D)), ((V)(60D)), ((V)(0D)))))));
if (Truthy(play_1003)) {
Invoke(Arr(Arr(((V)(0.001)), ((V)((-60D))), ((V)(0D))), Arr(f3_1126, ((V)(58D)), ((V)(3D)))), "forEach", Fn((V _arrowThis1173, int _argc1160, V _a1162, V _a1163, V _a1164, V _a1165, V[] _rest1161) => {
V q_1174 = default;
V F_1175 = default;
V t_1168 = default;
V x_1170 = default;
V z_1172 = default;
{ V _t1166 = ListOf(_a1162);
{ V _t1167 = GetIdx(_t1166, 0D);
t_1168 = _t1167; }
{ V _t1169 = GetIdx(_t1166, 1D);
x_1170 = _t1169; }
{ V _t1171 = GetIdx(_t1166, 2D);
z_1172 = _t1171; }
}
q_1174 = Call(p_1117, V.Undef, x_1170, ((V)((SY_1011 + 2D))), z_1172);
F_1175 = Call(flash_64, V.Undef, Arr(t_1168), ((V)(0D)), ((V)(1D)), ((V)(0.06)));
f_1119.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_1174, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_1174, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((5D * ToNum(k_1118)))))).S("\" fill=\"#ffffff\" opacity=\"0\">").V(Call(anK_51, V.Undef, ((V)("opacity")), Get(F_1175, "v"), ((V)(2.4)), Get(F_1175, "kt"))).S("</circle>");
return default;
}, 1, "", true));
}
} else {
V BC_1176 = default;
V R2_1177 = default;
V rack_1178 = default;
V dst_1179 = default;
V KT_1180 = default;
V ballS_1181 = default;
JsStrBuf gd_1182 = null;
V ord_1183 = default;
BC_1176 = Arr(((V)("#ffd84f")), ((V)("#3b7bff")), ((V)("#ff3b5c")), ((V)("#b04bff")), ((V)("#ff9d3c")), ((V)("#3fdc6a")), ((V)("#ff4fb8")), ((V)("#1a1a20")), ((V)("#7df9ff")), ((V)("#c8ff4f")));
R2_1177 = Call(rng_25, V.Undef, ((V)("pool")));
rack_1178 = Arr();
{
double r_1184 = 0;
r_1184 = 0D;
while (true) {
if (!((r_1184 < 4D))) break;
{
double j_1186 = 0;
j_1186 = 0D;
while (true) {
if (!((j_1186 <= r_1184))) break;
Invoke(rack_1178, "push", Arr(((V)(((-30D) - (r_1184 * 4.6)))), ((V)(((j_1186 - (r_1184 / 2D)) * 5.3)))));
j_1186++;
}
}
r_1184++;
}
}
dst_1179 = Invoke(rack_1178, "map", Fn((V _arrowThis1196, int _argc1188, V q_1194, V i_1195, V _a1192, V _a1193, V[] _rest1189) => {
return (SEqN(i_1195, 7D) ? Arr(((V)((-69D))), ((V)((-36D)))) : (SEqN(i_1195, 3D) ? Arr(((V)(0D)), ((V)(37.5))) : Arr(((V)(((-60D) + (ToNum(Call(R2_1177, V.Undef)) * 100D)))), ((V)(((-30D) + (ToNum(Call(R2_1177, V.Undef)) * 60D)))))));
}, 2, "", true));
KT_1180 = ((V)("0;0.28;0.5;0.88;0.94;0.97;1"));
ballS_1181 = Fn((V _arrowThis1206, int _argc1197, V col_1203, V kf_1204, V op_1205, V _a1202, V[] _rest1198) => {
V vals_1207 = default;
double r_1208 = 0;
vals_1207 = Invoke(kf_1204, "map", Fn((V _arrowThis1220, int _argc1209, V _a1211, V _a1212, V _a1213, V _a1214, V[] _rest1210) => {
V x_1217 = default;
V z_1219 = default;
{ V _t1215 = ListOf(_a1211);
{ V _t1216 = GetIdx(_t1215, 0D);
x_1217 = _t1216; }
{ V _t1218 = GetIdx(_t1215, 1D);
z_1219 = _t1218; }
}
return Call(p_1117, V.Undef, x_1217, ((V)((SY_1011 + 2.6))), z_1219);
}, 1, "", true));
r_1208 = (2.6 * ToNum(k_1118));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_27, V.Undef, GetIdx(vals_1207, 0D))).S(")\">").V((Truthy(play_1003) ? Add(Call(atK_53, V.Undef, ((V)("translate")), Call(pts_60, V.Undef, vals_1207), ((V)(5D)), KT_1180), Call(anK_51, V.Undef, ((V)("opacity")), (op_1205 is var _t1221 && Truthy(_t1221) ? _t1221 : ((V)("1;1;1;1;0;0;1"))), ((V)(5D)), KT_1180)) : ((V)("")))).S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)((r_1208 * 1.8))))).S("\" fill=\"").V(col_1203).S("\" opacity=\"0.35\" filter=\"url(#gtB)\"/><circle r=\"").V(Call(f1_23, V.Undef, ((V)(r_1208)))).S("\" fill=\"url(#gtb").V(Invoke(col_1203, "slice", ((V)(1D)))).S(")\"/><circle cx=\"").V(Call(f1_23, V.Undef, ((V)(((-r_1208) * 0.35))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-r_1208) * 0.4))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((r_1208 * 0.3))))).S("\" fill=\"#ffffff\" opacity=\"0.7\"/></g>").End()));
return default;
}, 3, "", true);
gd_1182 = new JsStrBuf("");
Invoke(Invoke(BC_1176, "concat", ((V)("#f4f6f8"))), "forEach", Fn((V _arrowThis1229, int _argc1222, V c2_1228, V _a1225, V _a1226, V _a1227, V[] _rest1223) => {
return ((V)(gd_1182.V(Call(G_61, V.Undef, ((V)(JsStrBuf.Begin().S("gtb").V(Invoke(c2_1228, "slice", ((V)(1D)))).End())), Arr(Arr(((V)(0D)), Call(mix_22, V.Undef, c2_1228, ((V)("#ffffff")), ((V)(0.55)))), Arr(((V)(0.6)), c2_1228), Arr(((V)(1D)), Call(shade_21, V.Undef, c2_1228, ((V)(0.55))))), NewObj(2).Put("r", ((V)(1D))).Put("a", ((V)("cx=\"35%\" cy=\"30%\" r=\"70%\""))).V)).Str));
}, 1, "", true));
f_1119.S("<defs>").S(gd_1182.Str).S("</defs>");
ord_1183 = Invoke(Invoke(rack_1178, "map", Fn((V _arrowThis1247, int _argc1239, V q_1245, V i_1246, V _a1243, V _a1244, V[] _rest1240) => {
return i_1246;
}, 2, "", true)), "sort", Fn((V _arrowThis1238, int _argc1230, V a_1236, V b_1237, V _a1234, V _a1235, V[] _rest1231) => {
return ((V)((((ToNum(GetIdx(GetK(rack_1178, a_1236), 1D)) * 0.866) + (ToNum(GetIdx(GetK(rack_1178, a_1236), 0D)) * 0.5)) - ((ToNum(GetIdx(GetK(rack_1178, b_1237), 1D)) * 0.866) + (ToNum(GetIdx(GetK(rack_1178, b_1237), 0D)) * 0.5)))));
}, 2, "", true));
Invoke(ord_1183, "forEach", Fn((V _arrowThis1255, int _argc1248, V i_1254, V _a1251, V _a1252, V _a1253, V[] _rest1249) => {
V q_1256 = default;
V e_1257 = default;
q_1256 = GetK(rack_1178, i_1254);
e_1257 = GetK(dst_1179, i_1254);
f_1119.V(Call(ballS_1181, V.Undef, GetK(BC_1176, i_1254), (Truthy(play_1003) ? Arr(q_1256, q_1256, e_1257, e_1257, e_1257, q_1256, q_1256) : Arr(q_1256)), ((SEqN(i_1254, 7D) || SEqN(i_1254, 3D)) ? ((V)("1;1;0;0;0;0;1")) : V.Null)));
return default;
}, 1, "", true));
f_1119.V(Call(ballS_1181, V.Undef, ((V)("#f4f6f8")), (Truthy(play_1003) ? Arr(Arr(((V)(34D)), ((V)(0D))), Arr(((V)((-25D))), ((V)(0D))), Arr(((V)((-12D))), ((V)(8D))), Arr(((V)((-12D))), ((V)(8D))), Arr(((V)((-12D))), ((V)(8D))), Arr(((V)(34D)), ((V)(0D))), Arr(((V)(34D)), ((V)(0D)))) : Arr(Arr(((V)(34D)), ((V)(0D)))))));
if (Truthy(play_1003)) {
V t_1258 = default;
V u_1259 = default;
double dx_1260 = 0;
double dy_1261 = 0;
V off_1262 = default;
t_1258 = Call(p_1117, V.Undef, ((V)(37.4)), ((V)((SY_1011 + 2.6))), ((V)(0.3)));
u_1259 = Call(p_1117, V.Undef, ((V)(98D)), ((V)((SY_1011 + 7D))), ((V)(3.2)));
dx_1260 = ((ToNum(GetIdx(u_1259, 0D)) - ToNum(GetIdx(t_1258, 0D))) / Hypot((ToNum(GetIdx(u_1259, 0D)) - ToNum(GetIdx(t_1258, 0D))), (ToNum(GetIdx(u_1259, 1D)) - ToNum(GetIdx(t_1258, 1D)))));
dy_1261 = ((ToNum(GetIdx(u_1259, 1D)) - ToNum(GetIdx(t_1258, 1D))) / Hypot((ToNum(GetIdx(u_1259, 0D)) - ToNum(GetIdx(t_1258, 0D))), (ToNum(GetIdx(u_1259, 1D)) - ToNum(GetIdx(t_1258, 1D)))));
off_1262 = Fn((V _arrowThis1270, int _argc1263, V d_1269, V _a1266, V _a1267, V _a1268, V[] _rest1264) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)(((dx_1260 * ToNum(d_1269)) * ToNum(k_1118)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((dy_1261 * ToNum(d_1269)) * ToNum(k_1118)))))).End()));
}, 1, "", true);
f_1119.S("<g>").V(Call(atK_53, V.Undef, ((V)("translate")), Invoke(Invoke(Arr(((V)(6D)), ((V)(13D)), ((V)(0D)), ((V)(1.5)), ((V)(14D)), ((V)(14D)), ((V)(6D))), "map", off_1262), "join", ((V)(";"))), ((V)(5D)), ((V)("0;0.11;0.16;0.2;0.4;0.95;1")))).S("<path d=\"M").V(Call(P2_27, V.Undef, t_1258)).S("L").V(Call(P2_27, V.Undef, u_1259)).S("\" stroke=\"#5a3418\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((2.2 * ToNum(k_1118)))))).S("\" stroke-linecap=\"round\"/><path d=\"M").V(Call(P2_27, V.Undef, t_1258)).S("L").V(Call(P2_27, V.Undef, u_1259)).S("\" stroke=\"url(#gtCue)\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1.4 * ToNum(k_1118)))))).S("\" stroke-linecap=\"round\"/><circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(t_1258, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(t_1258, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.8 * ToNum(k_1118)))))).S("\" fill=\"#3b7bff\"/></g>");
}
}
SC_1120 = Call(surf_55, V.Undef, p_1117, Arr(((V)((-18D))), ((V)(35.9)), ((V)((HZ_1010 + 0.6)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
f_1119.S("<g transform=\"").V(SC_1120).S("\"><rect x=\"1\" y=\"0.6\" width=\"34\" height=\"4.4\" rx=\"0.6\" fill=\"#050608\"/>").S((Truthy(bill_1002) ? JsStrBuf.Begin().S("<text x=\"18\" y=\"4.1\" text-anchor=\"middle\" font-family=\"Courier New, monospace\" font-weight=\"700\" font-size=\"3.6\" fill=\"").V(LED_1006).S("\">8-BALL ").S((Truthy(play_1003) ? "P1" : "--")).S("</text>").End() : JsStrBuf.Begin().S("<text x=\"18\" y=\"4.1\" text-anchor=\"middle\" font-family=\"Courier New, monospace\" font-weight=\"700\" font-size=\"3.6\" fill=\"#ffb45a\">").S((Truthy(play_1003) ? "3 : 2" : "0 : 0")).V((Truthy(play_1003) ? Call(anD_52, V.Undef, ((V)("opacity")), ((V)("1;0.5")), ((V)(0.6))) : ((V)("")))).S("</text>").End())).S("</g>");
fl_1121 = Call(p_1117, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
un_1122 = ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(fl_1121, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(fl_1121, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((96D * ToNum(k_1118)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((((96D * ToNum(k_1118)) * ToNum(SA_42)) * 0.62))))).S("\" fill=\"").V(LED_1006).S("\" opacity=\"").N((Truthy(play_1003) ? 0.32 : 0.2)).S("\" filter=\"url(#gtB)\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)((Truthy(play_1003) ? "0.32;0.18;0.32" : "0.2;0.12;0.2"))), ((V)((Truthy(play_1003) ? 1.2 : 3D))))).S("</ellipse>").End()));
defs_1123 = ((V)(JsStrBuf.Begin().V(Add(Add(Add(Call(BLUR_33, V.Undef, ((V)("gtB")), ((V)(1.3))), Call(G_61, V.Undef, ((V)("gtI")), Arr(Arr(((V)(0D)), ((V)("#fffdf8"))), Arr(((V)(0.6)), ((V)("#f6f0e6"))), Arr(((V)(1D)), ((V)("#e6dccb")))), NewObj(1).Put("r", ((V)(1D))).V)), Call(G_61, V.Undef, ((V)("gtF")), Arr(Arr(((V)(0D)), ((V)("#2f7a5a"))), Arr(((V)(0.7)), ((V)("#1f5e44"))), Arr(((V)(1D)), ((V)("#154430")))), NewObj(1).Put("r", ((V)(1D))).V)), Call(G_61, V.Undef, ((V)("gtCue")), Arr(Arr(((V)(0D)), ((V)("#f4e4c0"))), Arr(((V)(0.7)), ((V)("#c99a5a"))), Arr(((V)(1D)), ((V)("#2a1a10")))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\""))).V))).S("<pattern id=\"gtH\" width=\"3.2\" height=\"3.2\" patternUnits=\"userSpaceOnUse\"><circle cx=\"1.6\" cy=\"1.6\" r=\"0.3\" fill=\"#a8987e\"/></pattern>").End()));
return NewObj(4).Put("defs", defs_1123).Put("under", un_1122).Put("front", ((V)(f_1119.Str))).Put("bb", Call(bbOf_34, V.Undef, Invoke(Arr(Call(p_1117, V.Undef, ((V)((-80D))), ((V)(44D)), ((V)((-45D)))), Call(p_1117, V.Undef, ((V)(80D)), ((V)(44D)), ((V)((-45D)))), Call(p_1117, V.Undef, ((V)(80D)), ((V)(0D)), ((V)(46D))), Call(p_1117, V.Undef, ((V)((-80D))), ((V)(0D)), ((V)(46D)))), "concat", Call(plBB_68, V.Undef, p_1117, Call(plOf_67, V.Undef, ((V)("glowTable")), Get(S_1000, "st")))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1012;
return default;
}, 1, "", true));
Set(N_39, "bubbleFan", Fn((V _arrowThis1278, int _argc1271, V S_1277, V _a1274, V _a1275, V _a1276, V[] _rest1272) => {
V on_1279 = default;
double T_1280 = 0;
double A0_1281 = 0;
double HY_1282 = 0;
double R_1283 = 0;
V PLc_1284 = default;
V PL2_1285 = default;
double NB_1286 = 0;
V D_1287 = default;
on_1279 = Call(isOn_57, V.Undef, S_1277);
T_1280 = 5.6;
A0_1281 = 34D;
HY_1282 = 80D;
R_1283 = 19D;
PLc_1284 = ((V)("#efeadf"));
PL2_1285 = ((V)("#d8d0bf"));
NB_1286 = (Truthy(on_1279) ? 30D : 14D);
D_1287 = NewObj(2).Put("w", ((V)(60D))).Put("d", ((V)(50D))).V;
Set(D_1287, "build", Fn((V _arrowThis1295, int _argc1288, V P_1294, V _a1291, V _a1292, V _a1293, V[] _rest1289) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(17D)), ((V)(2D)), PL2_1285, Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(24D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)), ((V)(16D)), ((V)(4.4)), PLc_1284, Call(pt_38, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(4.4)), ((V)(0D)), ((V)(0.72))))).V))).Spread(Call(rep_24, V.Undef, ((V)(3D)), Fn((V _arrowThis1303, int _argc1296, V i_1302, V _a1299, V _a1300, V _a1301, V[] _rest1297) => {
return Call(box_12, V.Undef, ((V)(((-5.2) + (ToNum(i_1302) * 5.2)))), ((V)(3.6)), ((V)(11.6)), ((V)(4.4)), ((V)(2.2)), ((V)(4D)), ((V)((SEqN(i_1302, (Truthy(on_1279) ? 2D : 0D)) ? "#7fd0ff" : "#f7f4ec"))), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V));
}, 1, "", true))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6.4)), ((V)(0D)), ((V)(2.6)), ((V)(30D)), CH_44, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(0D)), ((V)(3.6)), ((V)(3D)), PLc_1284, Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(12D))).V))).Add(Call(slabX_16, V.Undef, ((V)(3.6)), ((V)(37.5)), ((V)(0D)), ((V)(2.4)), ((V)(1.2)), ((V)(1.2)), PL2_1285)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(39D)), ((V)(0D)), ((V)(1.9)), ((V)(27D)), CH_44, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(64D)), ((V)(0D)), ((V)(4.4)), ((V)(5D)), PLc_1284, Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(14D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(69D)), ((V)(0D)), ((V)(2.4)), ((V)(5D)), PL2_1285, Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))).V;
}, 1, "", true));
Set(D_1287, "fx", Fn((V _arrowThis1311, int _argc1304, V c_1310, V _a1307, V _a1308, V _a1309, V[] _rest1305) => {
V p_1312 = default;
V k_1313 = default;
double NS_1314 = 0;
V th_1315 = default;
V frame_1316 = default;
JsStrBuf f_1317 = null;
V ends_1318 = default;
V defs_1319 = default;
p_1312 = Get(c_1310, "p");
k_1313 = Get(c_1310, "k");
NS_1314 = 16D;
th_1315 = Fn((V _arrowThis1327, int _argc1320, V i_1326, V _a1323, V _a1324, V _a1325, V[] _rest1321) => {
return ((V)((((A0_1281 * FdLibm.Sin((((2D * PI_41) * ToNum(i_1326)) / NS_1314))) * PI_41) / 180D)));
}, 1, "", true);
frame_1316 = Fn((V _arrowThis1335, int _argc1328, V off_1334, V _a1331, V _a1332, V _a1333, V[] _rest1329) => {
V tr_1336 = default;
V sk_1337 = default;
V sc_1338 = default;
tr_1336 = Arr();
sk_1337 = Arr();
sc_1338 = Arr();
Call(rep_24, V.Undef, ((V)((NS_1314 + 1D))), Fn((V _arrowThis1346, int _argc1339, V i_1345, V _a1342, V _a1343, V _a1344, V[] _rest1340) => {
V t_1347 = default;
V ph_1348 = default;
V d_1349 = default;
V q_1350 = default;
double a_1351 = 0;
double cc_1352 = 0;
t_1347 = Call(th_1315, V.Undef, i_1345);
ph_1348 = t_1347;
d_1349 = Arr(((V)(FdLibm.Sin(ToNum(Add(t_1347, ((V)((PI_41 / 6D)))))))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(Add(t_1347, ((V)((PI_41 / 6D)))))))));
q_1350 = Call(p_1312, V.Undef, ((V)((ToNum(GetIdx(d_1349, 0D)) * ToNum(off_1334)))), ((V)(HY_1282)), ((V)((ToNum(GetIdx(d_1349, 2D)) * ToNum(off_1334)))));
a_1351 = FdLibm.Cos(ToNum(ph_1348));
cc_1352 = ((-ToNum(SA_42)) * FdLibm.Sin(ToNum(ph_1348)));
Invoke(tr_1336, "push", Call(P2_27, V.Undef, q_1350));
Invoke(sk_1337, "push", Call(n4_26, V.Undef, ((V)(((FdLibm.Atan2(cc_1352, a_1351) * 180D) / PI_41)))));
Invoke(sc_1338, "push", ((V)(JsStrBuf.Begin().V(Call(n4_26, V.Undef, ((V)((ToNum(k_1313) * a_1351))))).S(" ").V(Call(n4_26, V.Undef, ((V)((ToNum(k_1313) * ToNum(CA_43)))))).End())));
return default;
}, 1, "", true));
return NewObj(2).Put("o", ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(GetIdx(tr_1336, 0D)).S(")\">").V(Call(atL_54, V.Undef, ((V)("translate")), Invoke(tr_1336, "join", ((V)(";"))), ((V)(T_1280)))).S("<g transform=\"skewY(").V(GetIdx(sk_1337, 0D)).S(")\">").V(Call(atL_54, V.Undef, ((V)("skewY")), Invoke(sk_1337, "join", ((V)(";"))), ((V)(T_1280)))).S("<g transform=\"scale(").V(GetIdx(sc_1338, 0D)).S(")\">").V(Call(atL_54, V.Undef, ((V)("scale")), Invoke(sc_1338, "join", ((V)(";"))), ((V)(T_1280)))).End()))).Put("c", ((V)("</g></g></g>"))).V;
return default;
}, 1, "", true);
f_1317 = new JsStrBuf("");
Invoke(Arr(((V)((-14D))), ((V)((-11D))), ((V)((-8D))), ((V)((-5D))), ((V)((-2.5)))), "forEach", Fn((V _arrowThis1361, int _argc1353, V off_1359, V i_1360, V _a1357, V _a1358, V[] _rest1354) => {
V F_1362 = default;
F_1362 = Call(frame_1316, V.Undef, off_1359);
f_1317.V(Get(F_1362, "o")).S("<circle r=\"").N((SEqN(i_1360, 0D) ? 7.5 : 9.4)).S("\" fill=\"url(#bfM)\" stroke=\"").V(Call(shade_21, V.Undef, PL2_1285, ((V)(0.8)))).S("\" stroke-width=\"0.4\"/>").S((SEqN(i_1360, 4D) ? "<circle r=\"9.4\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.5\" opacity=\"0.3\"/>" : "")).V(Get(F_1362, "c"));
return default;
}, 2, "", true));
{
V F_1363 = default;
F_1363 = Call(frame_1316, V.Undef, ((V)((-0.5))));
f_1317.V(Get(F_1363, "o")).S("<circle r=\"").N(R_1283).S("\" fill=\"#dfeaf2\" fill-opacity=\"0.18\" stroke=\"#e7e2d6\" stroke-width=\"1\"/>").V(Get(F_1363, "c"));
}
{
V F_1364 = default;
F_1364 = Call(frame_1316, V.Undef, ((V)(1.5)));
f_1317.V(Get(F_1364, "o")).S("<circle r=\"17\" fill=\"#bfe2f5\" opacity=\"0.25\"/><g>").V(Call(atL_54, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)((Truthy(on_1279) ? 0.32 : 0.5))))).V(Invoke(Call(rep_24, V.Undef, ((V)(3D)), Fn((V _arrowThis1372, int _argc1365, V i_1371, V _a1368, V _a1369, V _a1370, V[] _rest1366) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0C5 -4.5 15 -6.5 16.4 -0.6C16 4.6 7 5.4 0 0Z\" fill=\"#8fcbef\" fill-opacity=\"0.78\" stroke=\"#5a9cc4\" stroke-width=\"0.35\" transform=\"rotate(").N((ToNum(i_1371) * 120D)).S(")\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g><circle r=\"3.6\" fill=\"").V(PLc_1284).S("\" stroke=\"").V(PL2_1285).S("\" stroke-width=\"0.4\"/>").V(Get(F_1364, "c"));
}
{
V F_1373 = default;
JsStrBuf g_1374 = null;
F_1373 = Call(frame_1316, V.Undef, ((V)(4D)));
g_1374 = new JsStrBuf("");
Invoke(Arr(((V)(R_1283)), ((V)((R_1283 * 0.74))), ((V)((R_1283 * 0.48)))), "forEach", Fn((V _arrowThis1383, int _argc1375, V r_1381, V i_1382, V _a1379, V _a1380, V[] _rest1376) => {
return ((V)(g_1374.S("<circle r=\"").V(Call(f1_23, V.Undef, r_1381)).S("\" fill=\"none\" stroke=\"#f6f3ec\" stroke-width=\"").N((Truthy(i_1382) ? 0.5 : 1.3)).S("\"/>").Str));
}, 2, "", true));
Call(rep_24, V.Undef, ((V)(18D)), Fn((V _arrowThis1391, int _argc1384, V i_1390, V _a1387, V _a1388, V _a1389, V[] _rest1385) => {
double a_1392 = 0;
a_1392 = ((ToNum(i_1390) * PI_41) / 9D);
g_1374.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((FdLibm.Cos(a_1392) * 4.2))))).S(" ").V(Call(f1_23, V.Undef, ((V)((FdLibm.Sin(a_1392) * 4.2))))).S("L").V(Call(f1_23, V.Undef, ((V)((FdLibm.Cos(a_1392) * R_1283))))).S(" ").V(Call(f1_23, V.Undef, ((V)((FdLibm.Sin(a_1392) * R_1283))))).S("\" stroke=\"#f6f3ec\" stroke-width=\"0.45\"/>");
return default;
}, 1, "", true));
g_1374.S("<circle r=\"4.4\" fill=\"").V(PLc_1284).S("\" stroke=\"").V(PL2_1285).S("\" stroke-width=\"0.5\"/><circle r=\"2.6\" fill=\"none\" stroke=\"#7fd0ff\" stroke-width=\"0.6\"/><path d=\"M-12 -14A18 18 0 0 1 8 -16\" stroke=\"#ffffff\" stroke-width=\"0.8\" fill=\"none\" opacity=\"0.7\"/>");
f_1317.V(Get(F_1373, "o")).S(g_1374.Str).V(Get(F_1373, "c"));
}
{
V F_1393 = default;
JsStrBuf g_1394 = null;
F_1393 = Call(frame_1316, V.Undef, ((V)(7.5)));
g_1394 = new JsStrBuf("<path d=\"M-3 19L-4.5 27M3 19L4.5 27\" stroke=\"#2fa8b8\" stroke-width=\"1.1\"/><path d=\"M-14 25H14L12 31Q0 33 -12 31Z\" fill=\"#2fa8b8\" stroke=\"#1d7c8a\" stroke-width=\"0.4\"/><path d=\"M-13 26.4H13\" stroke=\"#bff4ff\" stroke-width=\"1.2\" opacity=\"0.8\"/>");
g_1394.S("<g transform=\"translate(0 15)\"><g>").V(Call(atL_54, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)((Truthy(on_1279) ? 3.2 : 5D))))).V(Invoke(Call(rep_24, V.Undef, ((V)(6D)), Fn((V _arrowThis1402, int _argc1395, V i_1401, V _a1398, V _a1399, V _a1400, V[] _rest1396) => {
double a_1403 = 0;
double x_1404 = 0;
double y_1405 = 0;
a_1403 = ((ToNum(i_1401) * PI_41) / 3D);
x_1404 = (FdLibm.Cos(a_1403) * 9D);
y_1405 = (FdLibm.Sin(a_1403) * 9D);
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0L").V(Call(f1_23, V.Undef, ((V)((x_1404 * 0.72))))).S(" ").V(Call(f1_23, V.Undef, ((V)((y_1405 * 0.72))))).S("\" stroke=\"#ffc93c\" stroke-width=\"0.9\"/><circle cx=\"").V(Call(f1_23, V.Undef, ((V)(x_1404)))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(y_1405)))).S("\" r=\"2.6\" fill=\"#dff4ff\" fill-opacity=\"0.35\" stroke=\"#ffc93c\" stroke-width=\"0.8\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g><circle r=\"2\" fill=\"#ff9d3c\" stroke=\"#c86a1a\" stroke-width=\"0.3\"/></g>");
f_1317.V(Get(F_1393, "o")).S(g_1394.Str).V(Get(F_1393, "c"));
}
ends_1318 = Arr();
Call(rep_24, V.Undef, ((V)(NB_1286)), Fn((V _arrowThis1413, int _argc1406, V i_1412, V _a1409, V _a1410, V _a1411, V[] _rest1407) => {
double t0_1414 = 0;
double t_1415 = 0;
V d_1416 = default;
V e1_1417 = default;
V R2_1418 = default;
double L_1419 = 0;
double sw_1420 = 0;
double rise_1421 = 0;
V at_1422 = default;
V P0_1423 = default;
V P1_1424 = default;
V P2a_1425 = default;
double r_1426 = 0;
double b_1427 = 0;
t0_1414 = ((ToNum(i_1412) * T_1280) / NB_1286);
t_1415 = ((((A0_1281 * FdLibm.Sin((((2D * PI_41) * t0_1414) / T_1280))) * PI_41) / 180D) + (PI_41 / 6D));
d_1416 = Arr(((V)(FdLibm.Sin(t_1415))), ((V)(0D)), ((V)(FdLibm.Cos(t_1415))));
e1_1417 = Arr(((V)(FdLibm.Cos(t_1415))), ((V)(0D)), ((V)((-FdLibm.Sin(t_1415)))));
R2_1418 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("bub").V(i_1412).End())));
L_1419 = (70D + (ToNum(Call(R2_1418, V.Undef)) * 60D));
sw_1420 = ((ToNum(Call(R2_1418, V.Undef)) - 0.5) * 40D);
rise_1421 = (30D + (ToNum(Call(R2_1418, V.Undef)) * 34D));
at_1422 = Fn((V _arrowThis1435, int _argc1428, V s2_1434, V _a1431, V _a1432, V _a1433, V[] _rest1429) => {
return Arr(((V)(((ToNum(GetIdx(d_1416, 0D)) * (9D + (L_1419 * ToNum(s2_1434)))) + ((ToNum(GetIdx(e1_1417, 0D)) * sw_1420) * ToNum(s2_1434))))), ((V)(((HY_1282 + 1D) + (rise_1421 * Pow(ToNum(s2_1434), 1.2))))), ((V)(((ToNum(GetIdx(d_1416, 2D)) * (9D + (L_1419 * ToNum(s2_1434)))) + ((ToNum(GetIdx(e1_1417, 2D)) * sw_1420) * ToNum(s2_1434))))));
}, 1, "", true);
P0_1423 = CallSpread(p_1312, V.Undef, new ArrBuilder().Spread(Call(at_1422, V.Undef, ((V)(0D)))).V);
P1_1424 = CallSpread(p_1312, V.Undef, new ArrBuilder().Spread(Call(at_1422, V.Undef, ((V)(0.45)))).V);
P2a_1425 = CallSpread(p_1312, V.Undef, new ArrBuilder().Spread(Call(at_1422, V.Undef, ((V)(1D)))).V);
r_1426 = ((2.2 + (ToNum(Call(R2_1418, V.Undef)) * 2.6)) * ToNum(k_1313));
Invoke(ends_1318, "push", P2a_1425);
b_1427 = (-(T_1280 - t0_1414));
f_1317.S("<g transform=\"translate(").V(Call(P2_27, V.Undef, P0_1423)).S(")\">").V(Call(atK_53, V.Undef, ((V)("translate")), Call(pts_60, V.Undef, Arr(P0_1423, P1_1424, P2a_1425, P2a_1425)), ((V)(T_1280)), ((V)("0;0.35;0.72;1")), ((V)(b_1427)))).V(Call(anK_51, V.Undef, ((V)("opacity")), ((V)("0;1;0.95;0;0")), ((V)(T_1280)), ((V)("0;0.05;0.66;0.72;1")), ((V)(b_1427)))).S("<g>").V(Call(atK_53, V.Undef, ((V)("scale")), ((V)("0.3;1;1.05;1.3;1.3")), ((V)(T_1280)), ((V)("0;0.12;0.66;0.72;1")), ((V)(b_1427)))).S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)(r_1426)))).S("\" fill=\"url(#bfB)\" stroke=\"#ffffff\" stroke-opacity=\"0.75\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.25 * ToNum(k_1313)))))).S("\"/><circle cx=\"").V(Call(f1_23, V.Undef, ((V)(((-r_1426) * 0.35))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-r_1426) * 0.4))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((r_1426 * 0.22))))).S("\" fill=\"#ffffff\" opacity=\"0.9\"/></g></g>");
return default;
}, 1, "", true));
defs_1319 = Add(Call(G_61, V.Undef, ((V)("bfM")), Arr(Arr(((V)(0D)), ((V)("#fbf8f1"))), Arr(((V)(0.6)), PLc_1284), Arr(((V)(1D)), ((V)("#b9b09c")))), NewObj(2).Put("r", ((V)(1D))).Put("a", ((V)("cx=\"38%\" cy=\"32%\" r=\"70%\""))).V), Call(G_61, V.Undef, ((V)("bfB")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.04))), Arr(((V)(0.7)), ((V)("#bfefff")), ((V)(0.12))), Arr(((V)(0.86)), ((V)("#ff9ee0")), ((V)(0.3))), Arr(((V)(1D)), ((V)("#7fe0ff")), ((V)(0.5)))), NewObj(1).Put("r", ((V)(1D))).V));
return NewObj(3).Put("defs", defs_1319).Put("front", ((V)(f_1317.Str))).Put("bb", Call(bbOf_34, V.Undef, Invoke(ends_1318, "concat", Arr(Call(p_1312, V.Undef, ((V)((-24D))), ((V)((HY_1282 + 24D))), ((V)(0D))), Call(p_1312, V.Undef, ((V)(24D)), ((V)((HY_1282 + 24D))), ((V)(0D))), Call(p_1312, V.Undef, ((V)((-20D))), ((V)((HY_1282 - 24D))), ((V)(20D))), Call(p_1312, V.Undef, ((V)(20D)), ((V)((HY_1282 - 24D))), ((V)(20D))), Call(p_1312, V.Undef, ((V)((-18D))), ((V)(0D)), ((V)(18D))), Call(p_1312, V.Undef, ((V)(18D)), ((V)(0D)), ((V)((-18D)))))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1287;
return default;
}, 1, "", true));
plume_71 = Fn((V _arrowThis1450, int _argc1436, V o_1442, V dir_1443, V n_1444, V L_1445, V[] _rest1437) => {
V col_1446 = default;
V dur_1447 = default;
V k_1448 = default;
V spread_1449 = default;
col_1446 = (_argc1436 > 4 ? _rest1437[0] : V.Undef);
dur_1447 = (_argc1436 > 5 ? _rest1437[1] : V.Undef);
k_1448 = (_argc1436 > 6 ? _rest1437[2] : V.Undef);
spread_1449 = (_argc1436 > 7 ? _rest1437[3] : V.Undef);
return Invoke(Call(rep_24, V.Undef, n_1444, Fn((V _arrowThis1458, int _argc1451, V i_1457, V _a1454, V _a1455, V _a1456, V[] _rest1452) => {
V R2_1459 = default;
double b_1460 = 0;
double sp_1461 = 0;
V ex_1462 = default;
double ey_1463 = 0;
double r0_1464 = 0;
double r1_1465 = 0;
R2_1459 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("pl").V(i_1457).V(L_1445).End())));
b_1460 = (((-ToNum(i_1457)) * ToNum(dur_1447)) / ToNum(n_1444));
sp_1461 = ((ToNum(Call(R2_1459, V.Undef)) - 0.5) * ToNum((spread_1449 is var _t1466 && Truthy(_t1466) ? _t1466 : ((V)(0.5)))));
ex_1462 = Add(GetIdx(o_1442, 0D), ((V)((ToNum(Add(GetIdx(dir_1443, 0D), ((V)((sp_1461 * ToNum(GetIdx(dir_1443, 1D))))))) * ToNum(L_1445)))));
ey_1463 = (ToNum(Add(GetIdx(o_1442, 1D), ((V)(((ToNum(GetIdx(dir_1443, 1D)) - (sp_1461 * ToNum(GetIdx(dir_1443, 0D)))) * ToNum(L_1445)))))) - (ToNum(L_1445) * 0.15));
r0_1464 = (2D * ToNum(k_1448));
r1_1465 = ((9D + (ToNum(Call(R2_1459, V.Undef)) * 6D)) * ToNum(k_1448));
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(o_1442, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(o_1442, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)(r0_1464)))).S("\" fill=\"").V(col_1446).S("\" filter=\"url(#fgB)\">").V(Call(an_31, V.Undef, ((V)("cx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(o_1442, 0D))).S(";").V(Call(f1_23, V.Undef, ex_1462)).End())), dur_1447, ((V)(b_1460)))).V(Call(an_31, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(o_1442, 1D))).S(";").V(Call(f1_23, V.Undef, ((V)(ey_1463)))).End())), dur_1447, ((V)(b_1460)))).V(Call(an_31, V.Undef, ((V)("r")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)(r0_1464)))).S(";").V(Call(f1_23, V.Undef, ((V)(r1_1465)))).End())), dur_1447, ((V)(b_1460)))).V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.85;0.5;0")), dur_1447, ((V)(b_1460)))).S("</circle>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
}, 8, "", true);
FGD_72 = Add(Call(BLUR_33, V.Undef, ((V)("fgB")), ((V)(2.2))), Call(BLUR_33, V.Undef, ((V)("fgb")), ((V)(0.9))));
Set(N_39, "fogMini", Fn((V _arrowThis1474, int _argc1467, V S_1473, V _a1470, V _a1471, V _a1472, V[] _rest1468) => {
V on_1475 = default;
V BK_1476 = default;
V OR_1477 = default;
V D_1478 = default;
on_1475 = Call(isOn_57, V.Undef, S_1473);
BK_1476 = ((V)("#1d1d22"));
OR_1477 = ((V)("#ff8a1e"));
D_1478 = NewObj(2).Put("w", ((V)(70D))).Put("d", ((V)(48D))).V;
Set(D_1478, "build", Fn((V _arrowThis1486, int _argc1479, V P_1485, V _a1482, V _a1483, V _a1484, V[] _rest1480) => {
V o_1487 = default;
o_1487 = Arr();
Invoke(Arr(Arr(((V)((-20D))), ((V)((-11D)))), Arr(((V)(16D)), ((V)((-11D)))), Arr(((V)((-20D))), ((V)(11D))), Arr(((V)(16D)), ((V)(11D)))), "forEach", Fn((V _arrowThis1499, int _argc1488, V _a1490, V _a1491, V _a1492, V _a1493, V[] _rest1489) => {
V x_1496 = default;
V z_1498 = default;
{ V _t1494 = ListOf(_a1490);
{ V _t1495 = GetIdx(_t1494, 0D);
x_1496 = _t1495; }
{ V _t1497 = GetIdx(_t1494, 1D);
z_1498 = _t1497; }
}
return Invoke(o_1487, "push", Call(cyl_13, V.Undef, x_1496, ((V)(0D)), z_1498, ((V)(2D)), ((V)(3D)), ((V)("#111114")), NewObj(1).Put("n", ((V)(10D))).V));
}, 1, "", true));
Invoke(o_1487, "push", Call(box_12, V.Undef, ((V)((-2D))), ((V)(3D)), ((V)(0D)), ((V)(44D)), ((V)(20D)), ((V)(30D)), BK_1476, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2.5))).V)), Call(box_12, V.Undef, ((V)((-2D))), ((V)(3.4)), ((V)(0D)), ((V)(44.6)), ((V)(3.6)), ((V)(30.6)), OR_1477, Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slabX_16, V.Undef, ((V)(20.4)), ((V)(7D)), ((V)(0D)), ((V)(1D)), ((V)(13D)), ((V)(22D)), ((V)("#2b2b31")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(o_1487, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(15D)))).Put("a", ((V)(3.4))).Put("b", ((V)(3.4))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)(20.6)), ((V)(0D))), Arr(((V)(25D)), ((V)(0D)), ((V)(0.92))))).Put("col", CH_44).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(15D)))).Put("a", ((V)(3D))).Put("b", ((V)(3D))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)(25D)), ((V)(0D))), Arr(((V)(26.6)), ((V)(0D)), ((V)(0.8))))).Put("col", ((V)("#c9a046"))).Put("mat", ((V)("metal"))).V));
Invoke(o_1487, "push", Call(box_12, V.Undef, ((V)((-14D))), ((V)(23D)), ((V)(0D)), ((V)(3D)), ((V)(6D)), ((V)(4D)), ((V)("#2a2a30")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(10D)), ((V)(23D)), ((V)(0D)), ((V)(3D)), ((V)(6D)), ((V)(4D)), ((V)("#2a2a30")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slabX_16, V.Undef, ((V)((-2D))), ((V)(28.4)), ((V)(0D)), ((V)(28D)), ((V)(3.2)), ((V)(5D)), ((V)("#2a2a30")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)));
Invoke(o_1487, "push", Call(box_12, V.Undef, ((V)((-14D))), ((V)(23D)), ((V)((-8D))), ((V)(12D)), ((V)(13D)), ((V)(11D)), ((V)("#e2d8ff")), Call(cer_37, V.Undef, NewObj(2).Put("op", ((V)(0.4))).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)((-14D))), ((V)(23.4)), ((V)((-8D))), ((V)(10.6)), ((V)(8.6)), ((V)(9.6)), ((V)("#8f5bd8")), Call(cer_37, V.Undef, NewObj(2).Put("op", ((V)(0.82))).Put("r", ((V)(1.6))).V)), Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(36D)), ((V)((-8D))), ((V)(2.6)), ((V)(2D)), OR_1477, Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
Invoke(o_1487, "push", Call(box_12, V.Undef, ((V)(28D)), ((V)(0D)), ((V)(24D)), ((V)(10D)), ((V)(3D)), ((V)(6.4)), ((V)("#26262b")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)), Call(cyl_13, V.Undef, ((V)(26D)), ((V)(3D)), ((V)(24D)), ((V)(1.5)), ((V)(1D)), ((V)("#e8343c")), Call(em_40, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(cyl_13, V.Undef, ((V)(31D)), ((V)(3D)), ((V)(24D)), ((V)(0.7)), ((V)(0.6)), ((V)((Truthy(on_1475) ? "#ffb43c" : "#4fdc6a"))), Call(em_40, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
return o_1487;
return default;
}, 1, "", true));
Set(D_1478, "fx", Fn((V _arrowThis1507, int _argc1500, V c_1506, V _a1503, V _a1504, V _a1505, V[] _rest1501) => {
V p_1508 = default;
V k_1509 = default;
JsStrBuf f_1510 = null;
V SD_1511 = default;
JsStrBuf g_1512 = null;
V rm_1513 = default;
V bd_1514 = default;
V nz_1515 = default;
p_1508 = Get(c_1506, "p");
k_1509 = Get(c_1506, "k");
f_1510 = new JsStrBuf("");
SD_1511 = Call(plane_29, V.Undef, p_1508, ((V)(15.3)), ((V)(22D)), ((V)((-22D))));
g_1512 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"2\" y=\"3.6\" width=\"40\" height=\"12\" rx=\"1\" fill=\"#26262c\"/>").V(Invoke(Call(rep_24, V.Undef, ((V)(7D)), Fn((V _arrowThis1523, int _argc1516, V i_1522, V _a1519, V _a1520, V _a1521, V[] _rest1517) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").N((4D + (ToNum(i_1522) * 2.4))).S("\" y=\"5.4\" width=\"1.1\" height=\"8.4\" rx=\"0.5\" fill=\"#0c0c0f\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).End());
g_1512.S("<circle cx=\"31.5\" cy=\"9.4\" r=\"5.2\" fill=\"").V(OR_1477).S("\" stroke=\"#b85a10\" stroke-width=\"0.4\"/><path d=\"M31.5 4.2q1.2-1.4 2.2-0.6\" stroke=\"#3a7a2a\" stroke-width=\"0.8\" fill=\"none\"/><path d=\"M29 8l1.4-1.4 1.4 1.4zM32.4 8l1.4-1.4 1.4 1.4zM28.6 11q2.9 2.4 5.8 0l-1 0.8-0.9-0.6-0.9 0.6-0.9-0.6-0.9 0.6z\" fill=\"#2a1406\"/>");
g_1512.S("<path d=\"M22 6q1.4-1.2 2.6 0q1.2-1.2 2.6 0q-1.3 0.2-2.6 1.4q-1.3-1.2-2.6-1.4z\" fill=\"#0c0c0f\"/><path d=\"M38 14q1-0.9 2 0q1-0.9 2 0q-1 0.2-2 1q-1-0.8-2-1z\" fill=\"#0c0c0f\"/>");
g_1512.S("<circle cx=\"40\" cy=\"6\" r=\"0.9\" fill=\"").S((Truthy(on_1475) ? "#ffb43c" : "#4fdc6a")).S("\">").V((Truthy(on_1475) ? Call(anD_52, V.Undef, ((V)("opacity")), ((V)("1;0.2")), ((V)(0.6))) : ((V)("")))).S("</circle>");
f_1510.S("<g transform=\"").V(SD_1511).S("\">").S(g_1512.Str).S("</g>");
rm_1513 = Call(p_1508, V.Undef, ((V)(28D)), ((V)(1.5)), ((V)(21D)));
bd_1514 = Call(p_1508, V.Undef, ((V)((-6D))), ((V)(3.5)), ((V)(15.4)));
f_1510.S("<path d=\"M").V(Call(P2_27, V.Undef, rm_1513)).S("Q").V(Call(f1_23, V.Undef, ((V)((ToNum(Add(GetIdx(rm_1513, 0D), GetIdx(bd_1514, 0D))) / 2D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((Max(ToNum(GetIdx(rm_1513, 1D)), ToNum(GetIdx(bd_1514, 1D))) + (10D * ToNum(k_1509))))))).S(" ").V(Call(P2_27, V.Undef, bd_1514)).S("\" fill=\"none\" stroke=\"#111114\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.9 * ToNum(k_1509)))))).S("\"/>");
nz_1515 = Call(p_1508, V.Undef, ((V)(27D)), ((V)(15D)), ((V)(0D)));
f_1510.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(nz_1515, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(nz_1515, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((1.7 * ToNum(k_1509)))))).S("\" fill=\"#0c0c0f\"/>");
if (Truthy(on_1475)) {
V o0_1524 = default;
V dv_1525 = default;
double L_1526 = 0;
o0_1524 = Call(p_1508, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
dv_1525 = Call(p_1508, V.Undef, ((V)(1D)), ((V)(0.05)), ((V)(0.3)));
L_1526 = Hypot((ToNum(GetIdx(dv_1525, 0D)) - ToNum(GetIdx(o0_1524, 0D))), (ToNum(GetIdx(dv_1525, 1D)) - ToNum(GetIdx(o0_1524, 1D))));
f_1510.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(nz_1515, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(nz_1515, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((2.6 * ToNum(k_1509)))))).S("\" fill=\"#ffb43c\" opacity=\"0.5\" filter=\"url(#fgb)\"/>").V(Call(plume_71, V.Undef, nz_1515, Arr(((V)(((ToNum(GetIdx(dv_1525, 0D)) - ToNum(GetIdx(o0_1524, 0D))) / L_1526))), ((V)(((ToNum(GetIdx(dv_1525, 1D)) - ToNum(GetIdx(o0_1524, 1D))) / L_1526)))), ((V)(7D)), ((V)((34D * ToNum(k_1509)))), ((V)("#eef1f6")), ((V)(1.6)), k_1509, ((V)(0.5))));
}
return NewObj(3).Put("defs", FGD_72).Put("front", ((V)(f_1510.Str))).Put("bb", Call(bbOf_34, V.Undef, Arr(Call(p_1508, V.Undef, ((V)((-26D))), ((V)(40D)), ((V)((-18D)))), Call(p_1508, V.Undef, ((V)(28D)), ((V)(0D)), ((V)(30D))), Call(p_1508, V.Undef, ((V)((-26D))), ((V)(0D)), ((V)(18D))), Call(p_1508, V.Undef, ((V)(70D)), ((V)(30D)), ((V)(20D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1478;
return default;
}, 1, "", true));
Set(N_39, "hazer", Fn((V _arrowThis1534, int _argc1527, V S_1533, V _a1530, V _a1531, V _a1532, V[] _rest1528) => {
V on_1535 = default;
V UV_1536 = default;
V D_1537 = default;
on_1535 = Call(isOn_57, V.Undef, S_1533);
UV_1536 = ((V)("#9a6bff"));
D_1537 = NewObj(2).Put("w", ((V)(130D))).Put("d", ((V)(80D))).V;
Set(D_1537, "build", Fn((V _arrowThis1545, int _argc1538, V P_1544, V _a1541, V _a1542, V _a1543, V[] _rest1539) => {
V o_1546 = default;
o_1546 = Arr(Call(box_12, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)(0D)), ((V)(64D)), ((V)(18D)), ((V)(40D)), ((V)("#2a2c33")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(box_12, V.Undef, ((V)((-14D))), ((V)(8.4)), ((V)(20.2)), ((V)(64D)), ((V)(1.2)), ((V)(0.6)), ((V)("#9aa3a8")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
Invoke(Arr(((V)((-44D))), ((V)(16D))), "forEach", Fn((V _arrowThis1554, int _argc1547, V x_1553, V _a1550, V _a1551, V _a1552, V[] _rest1548) => {
return Invoke(Arr(((V)((-19D))), ((V)(19D))), "forEach", Fn((V _arrowThis1562, int _argc1555, V z_1561, V _a1558, V _a1559, V _a1560, V[] _rest1556) => {
return Invoke(o_1546, "push", Call(box_12, V.Undef, Add(x_1553, ((V)((LtN(x_1553, 0D) ? 1.6 : (-1.6))))), ((V)(0D)), z_1561, ((V)(3.6)), ((V)(18D)), ((V)(3.6)), ((V)("#b9c0c6")), Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(((V)((-30D))), ((V)(2D))), "forEach", Fn((V _arrowThis1570, int _argc1563, V x_1569, V _a1566, V _a1567, V _a1568, V[] _rest1564) => {
return Invoke(o_1546, "push", Call(slab_15, V.Undef, x_1569, ((V)(10.6)), ((V)(20.6)), ((V)(6D)), ((V)(3D)), ((V)(0.8)), ((V)("#b9c0c6")), Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_1546, "push", Call(box_12, V.Undef, ((V)((-16D))), ((V)(18D)), ((V)(0D)), ((V)(52D)), ((V)(26D)), ((V)(34D)), ((V)("#18191d")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2.5))).V)), Call(slabX_16, V.Undef, ((V)(10.4)), ((V)(21D)), ((V)(0D)), ((V)(0.8)), ((V)(20D)), ((V)(26D)), ((V)("#22242a")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slabX_16, V.Undef, ((V)((-16D))), ((V)(44D)), ((V)((-12D))), ((V)(30D)), ((V)(3D)), ((V)(4D)), ((V)("#2a2c33")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)), Call(slabX_16, V.Undef, ((V)((-16D))), ((V)(44D)), ((V)(12D)), ((V)(30D)), ((V)(3D)), ((V)(4D)), ((V)("#2a2c33")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)));
Invoke(o_1546, "push", Call(box_12, V.Undef, ((V)((-46D))), ((V)(18D)), ((V)((-8D))), ((V)(10D)), ((V)(18D)), ((V)(10D)), ((V)("#f4f6f8")), Call(cer_37, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("op", ((V)(0.92))).V)), Call(box_12, V.Undef, ((V)((-46D))), ((V)(18.4)), ((V)((-8D))), ((V)(9D)), ((V)(9D)), ((V)(9D)), ((V)("#bfe4ff")), Call(cer_37, V.Undef, NewObj(2).Put("r", ((V)(2.6))).Put("op", ((V)(0.7))).V)), Call(cyl_13, V.Undef, ((V)((-46D))), ((V)(36D)), ((V)((-8D))), ((V)(2.4)), ((V)(2.4)), ((V)("#3f7fc8")), Call(pt_38, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)));
Invoke(Arr(((V)((-24D))), ((V)(24D))), "forEach", Fn((V _arrowThis1578, int _argc1571, V z_1577, V _a1574, V _a1575, V _a1576, V[] _rest1572) => {
double x_1579 = 0;
x_1579 = 44D;
Invoke(o_1546, "push", Call(cyl_13, V.Undef, ((V)(x_1579)), ((V)(0D)), z_1577, ((V)(8D)), ((V)(1.6)), ((V)("#1d1e22")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_13, V.Undef, ((V)(x_1579)), ((V)(1.6)), z_1577, ((V)(1.5)), ((V)(28D)), ((V)("#3a3c44")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(box_12, V.Undef, ((V)(x_1579)), ((V)(28D)), z_1577, ((V)(18D)), ((V)(3D)), ((V)(3D)), ((V)("#2a2c33")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(x_1579)), ((V)(30D)), z_1577, ((V)(7.4)), ((V)(13D)), ((V)("#141418")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(cyl_13, V.Undef, ((V)(x_1579)), ((V)(32D)), z_1577, ((V)(8.2)), ((V)(1.2)), ((V)("#2a2c33")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(cyl_13, V.Undef, ((V)(x_1579)), ((V)(37D)), z_1577, ((V)(8.2)), ((V)(1.2)), ((V)("#2a2c33")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(cyl_13, V.Undef, ((V)(x_1579)), ((V)(43D)), z_1577, ((V)(6.6)), ((V)(0.8)), ((V)((Truthy(on_1535) ? "#c9a6ff" : "#3a2a6a"))), Call(em_40, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
return default;
}, 1, "", true));
return o_1546;
return default;
}, 1, "", true));
Set(D_1537, "fx", Fn((V _arrowThis1587, int _argc1580, V c_1586, V _a1583, V _a1584, V _a1585, V[] _rest1581) => {
V p_1588 = default;
V k_1589 = default;
JsStrBuf f_1590 = null;
JsStrBuf un_1591 = null;
V FR_1592 = default;
V LC_1593 = default;
V defs_1594 = default;
p_1588 = Get(c_1586, "p");
k_1589 = Get(c_1586, "k");
f_1590 = new JsStrBuf("");
un_1591 = new JsStrBuf("");
FR_1592 = Call(surf_55, V.Undef, p_1588, Arr(((V)(10.9)), ((V)(31D)), ((V)(13D))), Arr(((V)(0D)), ((V)(0D)), ((V)((-1D)))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
f_1590.S("<g transform=\"").V(FR_1592).S("\"><circle cx=\"13\" cy=\"0\" r=\"9\" fill=\"#0a0a0d\"/><g transform=\"translate(13 0)\"><g>").V((Truthy(on_1535) ? Call(atL_54, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(0.25))) : ((V)("")))).V(Invoke(Call(rep_24, V.Undef, ((V)(5D)), Fn((V _arrowThis1602, int _argc1595, V i_1601, V _a1598, V _a1599, V _a1600, V[] _rest1596) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0C3 -3 7.6 -3 8 0C6 1.6 3 1.2 0 0Z\" fill=\"#3a3c44\" transform=\"rotate(").N((ToNum(i_1601) * 72D)).S(")\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>").V(Invoke(Call(rep_24, V.Undef, ((V)(4D)), Fn((V _arrowThis1610, int _argc1603, V i_1609, V _a1606, V _a1607, V _a1608, V[] _rest1604) => {
return ((V)(JsStrBuf.Begin().S("<circle r=\"").N((2.2 + (ToNum(i_1609) * 2.2))).S("\" fill=\"none\" stroke=\"#6a6f78\" stroke-width=\"0.45\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M-9 0H9M0 -9V9\" stroke=\"#6a6f78\" stroke-width=\"0.45\"/></g></g>");
LC_1593 = Call(plane_29, V.Undef, p_1588, ((V)(17.4)), ((V)(40D)), ((V)((-38D))));
f_1590.S("<g transform=\"").V(LC_1593).S("\"><rect x=\"2\" y=\"2\" width=\"20\" height=\"8\" rx=\"1\" fill=\"#0a1830\"/><text x=\"12\" y=\"7.6\" text-anchor=\"middle\" font-family=\"Courier New, monospace\" font-weight=\"700\" font-size=\"3.6\" fill=\"#6ac8ff\">").S((Truthy(on_1535) ? "HAZE 80%" : "READY")).V((Truthy(on_1535) ? Call(anD_52, V.Undef, ((V)("opacity")), ((V)("1;0.6")), ((V)(0.8))) : ((V)("")))).S("</text><rect x=\"26\" y=\"3\" width=\"4\" height=\"2.4\" rx=\"0.6\" fill=\"#3a3c44\"/><rect x=\"31\" y=\"3\" width=\"4\" height=\"2.4\" rx=\"0.6\" fill=\"#3a3c44\"/><circle cx=\"40\" cy=\"5\" r=\"1\" fill=\"").S((Truthy(on_1535) ? "#4fdc6a" : "#ff9d3c")).S("\"/>").S("<text x=\"2\" y=\"16\" font-family=\"Arial, sans-serif\" font-weight=\"800\" font-size=\"3\" fill=\"#9aa3a8\" letter-spacing=\"0.6\">HZ-1500</text></g>");
Invoke(Arr(((V)((-24D))), ((V)(24D))), "forEach", Fn((V _arrowThis1619, int _argc1611, V z_1617, V i_1618, V _a1615, V _a1616, V[] _rest1612) => {
V o_1620 = default;
o_1620 = Call(p_1588, V.Undef, ((V)(44D)), ((V)(44D)), z_1617);
if (Truthy(on_1535)) {
double L_1621 = 0;
V fl_1622 = default;
L_1621 = (120D * ToNum(k_1589));
f_1590.S("<g opacity=\"0.75\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.75;0.5;0.75")), ((V)(1.4)), ((V)(((-ToNum(i_1618)) * 0.7))))).S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(o_1620, 0D)) - (6D * ToNum(k_1589))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(o_1620, 1D))).S("L").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(o_1620, 0D)) - (38D * ToNum(k_1589))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(o_1620, 1D)) - L_1621))))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(o_1620, 0D), ((V)((38D * ToNum(k_1589))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(o_1620, 1D)) - L_1621))))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(o_1620, 0D), ((V)((6D * ToNum(k_1589))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(o_1620, 1D))).S("Z\" fill=\"url(#hzU)\"/></g>").V(Invoke(Call(rep_24, V.Undef, ((V)(12D)), Fn((V _arrowThis1630, int _argc1623, V j_1629, V _a1626, V _a1627, V _a1628, V[] _rest1624) => {
V R2_1631 = default;
V x_1632 = default;
double y_1633 = 0;
R2_1631 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("uv").V(i_1618).V(j_1629).End())));
x_1632 = Add(GetIdx(o_1620, 0D), ((V)((((ToNum(Call(R2_1631, V.Undef)) - 0.5) * 56D) * ToNum(k_1589)))));
y_1633 = (ToNum(GetIdx(o_1620, 1D)) - ((20D + (ToNum(Call(R2_1631, V.Undef)) * 90D)) * ToNum(k_1589)));
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, x_1632)).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(y_1633)))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(k_1589)))))).S("\" fill=\"").V(GetIdx(Arr(((V)("#d9ff4f")), ((V)("#ff4fb8")), ((V)("#3ff0ff"))), (ToNum(j_1629) % 3D))).S("\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0;1;0")), Call(n4_26, V.Undef, Add(((V)(1.2)), Call(R2_1631, V.Undef))), ((V)(((-ToNum(Call(R2_1631, V.Undef))) * 2D))))).S("</circle>").End()));
return default;
}, 1, "", true)), "join", ((V)(""))));
fl_1622 = Call(p_1588, V.Undef, ((V)(44D)), ((V)(0D)), z_1617);
un_1591.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(fl_1622, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(fl_1622, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((40D * ToNum(k_1589)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((((40D * ToNum(k_1589)) * ToNum(SA_42)) * 0.6))))).S("\" fill=\"").V(UV_1536).S("\" opacity=\"0.3\" filter=\"url(#fgB)\"/>");
}
f_1590.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(o_1620, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(o_1620, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((6.6 * ToNum(k_1589)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((6.6 * ToNum(k_1589)) * ToNum(SA_42)))))).S("\" fill=\"").S((Truthy(on_1535) ? "#e2d4ff" : "#4a3a7a")).S("\" opacity=\"0.9\"/>");
return default;
}, 2, "", true));
if (Truthy(on_1535)) {
V o0_1634 = default;
V dv_1635 = default;
double L_1636 = 0;
o0_1634 = Call(p_1588, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
dv_1635 = Call(p_1588, V.Undef, ((V)(1D)), ((V)(0.1)), ((V)(0.35)));
L_1636 = Hypot((ToNum(GetIdx(dv_1635, 0D)) - ToNum(GetIdx(o0_1634, 0D))), (ToNum(GetIdx(dv_1635, 1D)) - ToNum(GetIdx(o0_1634, 1D))));
f_1590.V(Call(plume_71, V.Undef, Call(p_1588, V.Undef, ((V)(12D)), ((V)(31D)), ((V)(0D))), Arr(((V)(((ToNum(GetIdx(dv_1635, 0D)) - ToNum(GetIdx(o0_1634, 0D))) / L_1636))), ((V)(((ToNum(GetIdx(dv_1635, 1D)) - ToNum(GetIdx(o0_1634, 1D))) / L_1636)))), ((V)(9D)), ((V)((40D * ToNum(k_1589)))), ((V)("#efeaff")), ((V)(2.2)), k_1589, ((V)(0.9))));
}
defs_1594 = Add(FGD_72, Call(G_61, V.Undef, ((V)("hzU")), Arr(Arr(((V)(0D)), UV_1536, ((V)(0.7))), Arr(((V)(1D)), UV_1536, ((V)(0D)))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\""))).V));
return NewObj(4).Put("defs", defs_1594).Put("under", ((V)(un_1591.Str))).Put("front", ((V)(f_1590.Str))).Put("bb", Call(bbOf_34, V.Undef, Arr(Call(p_1588, V.Undef, ((V)((-52D))), ((V)(46D)), ((V)((-22D)))), Call(p_1588, V.Undef, ((V)(54D)), ((V)(44D)), ((V)(32D))), Call(p_1588, V.Undef, ((V)((-48D))), ((V)(0D)), ((V)(22D))), Call(p_1588, V.Undef, ((V)(56D)), ((V)(0D)), ((V)((-32D)))), (Truthy(on_1535) ? Call(p_1588, V.Undef, ((V)(44D)), ((V)(160D)), ((V)(0D))) : Call(p_1588, V.Undef, ((V)(44D)), ((V)(46D)), ((V)(0D))))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1537;
return default;
}, 1, "", true));
Set(N_39, "cryoJets", Fn((V _arrowThis1644, int _argc1637, V S_1643, V _a1640, V _a1641, V _a1642, V[] _rest1638) => {
V on_1645 = default;
V JX_1646 = default;
double JZ_1647 = 0;
V D_1648 = default;
on_1645 = Call(isOn_57, V.Undef, S_1643);
JX_1646 = Arr(((V)((-40D))), ((V)(40D)));
JZ_1647 = 10D;
D_1648 = NewObj(2).Put("w", ((V)(130D))).Put("d", ((V)(76D))).V;
Set(D_1648, "build", Fn((V _arrowThis1656, int _argc1649, V P_1655, V _a1652, V _a1653, V _a1654, V[] _rest1650) => {
V o_1657 = default;
o_1657 = Arr();
Invoke(JX_1646, "forEach", Fn((V _arrowThis1665, int _argc1658, V x_1664, V _a1661, V _a1662, V _a1663, V[] _rest1659) => {
return Invoke(o_1657, "push", Call(box_12, V.Undef, x_1664, ((V)(0D)), ((V)(JZ_1647)), ((V)(22D)), ((V)(3D)), ((V)(22D)), ((V)("#1d1e22")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(box_12, V.Undef, x_1664, ((V)(3D)), ((V)(JZ_1647)), ((V)(12D)), ((V)(24D)), ((V)(12D)), ((V)("#2a2c33")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slab_15, V.Undef, x_1664, ((V)(14D)), ((V)((JZ_1647 + 6.1))), ((V)(8D)), ((V)(6D)), ((V)(0.4)), ((V)("#3f7fc8")), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(cyl_13, V.Undef, x_1664, ((V)(27D)), ((V)(JZ_1647)), ((V)(3D)), ((V)(14D)), CH_44, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, x_1664, ((V)(41D)), ((V)(JZ_1647)), ((V)(3.2)), ((V)(5D)), CH_44, Call(mt_35, V.Undef, NewObj(3).Put("n", ((V)(12D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(5D)), ((V)(0D)), ((V)(1.3))))).V)), Call(cyl_13, V.Undef, x_1664, ((V)(46D)), ((V)(JZ_1647)), ((V)(2.2)), ((V)(0.4)), ((V)("#0c0c10")), NewObj(1).Put("n", ((V)(10D))).V));
}, 1, "", true));
Invoke(o_1657, "push", Call(cyl_13, V.Undef, ((V)((-4D))), ((V)(0D)), ((V)((-22D))), ((V)(9.4)), ((V)(76D)), ((V)("#7f8f9c")), Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("shine", ((V)(1D))).V)), Call(ball_14, V.Undef, ((V)((-4D))), ((V)(76D)), ((V)((-22D))), ((V)(9.4)), ((V)("#7f8f9c")), Call(mt_35, V.Undef, NewObj(4).Put("sy", ((V)(0.5))).Put("k", ((V)(5D))).Put("n", ((V)(22D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)((-4D))), ((V)(44D)), ((V)((-22D))), ((V)(9.8)), ((V)(2D)), ((V)("#2a2c33")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)), Call(cyl_13, V.Undef, ((V)((-4D))), ((V)(80D)), ((V)((-22D))), ((V)(2.4)), ((V)(6D)), GOLD_45, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((-4D))), ((V)(85D)), ((V)((-22D))), ((V)(8D)), ((V)(2D)), ((V)(2D)), GOLD_45, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(disc_18, V.Undef, ((V)((-4D))), ((V)(84D)), ((V)((-19.6))), ((V)(3D)), ((V)(1D)), ((V)("#f4f6f8")), NewObj(1).Put("n", ((V)(14D))).V));
Invoke(o_1657, "push", Call(box_12, V.Undef, ((V)(6D)), ((V)(0D)), ((V)(24D)), ((V)(16D)), ((V)(3D)), ((V)(16D)), ((V)("#1d1e22")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(cyl_13, V.Undef, ((V)(6D)), ((V)(3D)), ((V)(24D)), ((V)(5D)), ((V)(30D)), ((V)("#161618")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_13, V.Undef, ((V)(6D)), ((V)(10D)), ((V)(24D)), ((V)(5.4)), ((V)(1.6)), GOLD_45, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(6D)), ((V)(24D)), ((V)(24D)), ((V)(5.4)), ((V)(1.6)), GOLD_45, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(6D)), ((V)(33D)), ((V)(24D)), ((V)(5.8)), ((V)(2D)), GOLD_45, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(6D)), ((V)(34.6)), ((V)(24D)), ((V)(4D)), ((V)(0.5)), ((V)("#0c0c10")), NewObj(1).Put("n", ((V)(14D))).V));
return o_1657;
return default;
}, 1, "", true));
Set(D_1648, "fx", Fn((V _arrowThis1673, int _argc1666, V c_1672, V _a1669, V _a1670, V _a1671, V[] _rest1667) => {
V p_1674 = default;
V k_1675 = default;
JsStrBuf f_1676 = null;
JsStrBuf un_1677 = null;
V t0_1678 = default;
V gg_1679 = default;
V cm_1680 = default;
V defs_1681 = default;
p_1674 = Get(c_1672, "p");
k_1675 = Get(c_1672, "k");
f_1676 = new JsStrBuf("");
un_1677 = new JsStrBuf("");
t0_1678 = Call(p_1674, V.Undef, ((V)((-4D))), ((V)(2D)), ((V)((-14D))));
Invoke(JX_1646, "forEach", Fn((V _arrowThis1689, int _argc1682, V x_1688, V _a1685, V _a1686, V _a1687, V[] _rest1683) => {
V j_1690 = default;
j_1690 = Call(p_1674, V.Undef, x_1688, ((V)(2D)), ((V)((JZ_1647 - 8D))));
f_1676.S("<path d=\"M").V(Call(P2_27, V.Undef, t0_1678)).S("Q").V(Call(f1_23, V.Undef, ((V)((ToNum(Add(GetIdx(t0_1678, 0D), GetIdx(j_1690, 0D))) / 2D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((Max(ToNum(GetIdx(t0_1678, 1D)), ToNum(GetIdx(j_1690, 1D))) + (8D * ToNum(k_1675))))))).S(" ").V(Call(P2_27, V.Undef, j_1690)).S("\" fill=\"none\" stroke=\"#0e0e12\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(k_1675)))))).S("\"/><path d=\"M").V(Call(P2_27, V.Undef, t0_1678)).S("Q").V(Call(f1_23, V.Undef, ((V)((ToNum(Add(GetIdx(t0_1678, 0D), GetIdx(j_1690, 0D))) / 2D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((Max(ToNum(GetIdx(t0_1678, 1D)), ToNum(GetIdx(j_1690, 1D))) + (8D * ToNum(k_1675))))))).S(" ").V(Call(P2_27, V.Undef, j_1690)).S("\" fill=\"none\" stroke=\"#5a5f6a\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.4 * ToNum(k_1675)))))).S("\"/>");
return default;
}, 1, "", true));
gg_1679 = Call(p_1674, V.Undef, ((V)((-4D))), ((V)(84D)), ((V)((-19D))));
f_1676.S("<path d=\"M").V(Call(P2_27, V.Undef, gg_1679)).S("l").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(k_1675)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-1.2) * ToNum(k_1675)))))).S("\" stroke=\"#e8343c\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.4 * ToNum(k_1675)))))).S("\"/>");
cm_1680 = Call(p_1674, V.Undef, ((V)(6D)), ((V)(35D)), ((V)(24D)));
Call(rep_24, V.Undef, ((V)(8D)), Fn((V _arrowThis1698, int _argc1691, V i_1697, V _a1694, V _a1695, V _a1696, V[] _rest1692) => {
V R2_1699 = default;
R2_1699 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("cf").V(i_1697).End())));
f_1676.S("<rect x=\"").V(Call(f1_23, V.Undef, Add(GetIdx(cm_1680, 0D), ((V)((((ToNum(Call(R2_1699, V.Undef)) - 0.5) * 6D) * ToNum(k_1675))))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(cm_1680, 1D)) - ((ToNum(Call(R2_1699, V.Undef)) * 1.5) * ToNum(k_1675))))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((1.2 * ToNum(k_1675)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((0.7 * ToNum(k_1675)))))).S("\" fill=\"").V(GetIdx(Arr(((V)("#ff4f6a")), ((V)("#ffd84f")), ((V)("#3ff0ff")), ((V)("#7dff6a"))), (ToNum(i_1697) % 4D))).S("\"/>");
return default;
}, 1, "", true));
if (Truthy(on_1645)) {
Invoke(JX_1646, "forEach", Fn((V _arrowThis1708, int _argc1700, V x_1706, V i_1707, V _a1704, V _a1705, V[] _rest1701) => {
V o_1709 = default;
double H_1710 = 0;
V fl_1711 = default;
o_1709 = Call(p_1674, V.Undef, x_1706, ((V)(46D)), ((V)(JZ_1647)));
H_1710 = (130D * ToNum(k_1675));
f_1676.S("<g>").V(Call(anK_51, V.Undef, ((V)("opacity")), ((V)("0;1;1;0;0")), ((V)(2.4)), ((V)("0;0.04;0.28;0.42;1")), ((V)(((-ToNum(i_1707)) * 0.08))))).S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(o_1709, 0D)) - (2D * ToNum(k_1675))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(o_1709, 1D))).S("L").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(o_1709, 0D)) - (16D * ToNum(k_1675))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(o_1709, 1D)) - H_1710))))).S("Q").V(Call(f1_23, V.Undef, GetIdx(o_1709, 0D))).S(" ").V(Call(f1_23, V.Undef, ((V)(((ToNum(GetIdx(o_1709, 1D)) - H_1710) - (14D * ToNum(k_1675))))))).S(" ").V(Call(f1_23, V.Undef, Add(GetIdx(o_1709, 0D), ((V)((16D * ToNum(k_1675))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(o_1709, 1D)) - H_1710))))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(o_1709, 0D), ((V)((2D * ToNum(k_1675))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(o_1709, 1D))).S("Z\" fill=\"url(#cjP)\" filter=\"url(#fgb)\"/>").V(Invoke(Call(rep_24, V.Undef, ((V)(7D)), Fn((V _arrowThis1719, int _argc1712, V j_1718, V _a1715, V _a1716, V _a1717, V[] _rest1713) => {
double y_1720 = 0;
double w_1721 = 0;
y_1720 = (ToNum(GetIdx(o_1709, 1D)) - (H_1710 * (0.2 + (ToNum(j_1718) * 0.12))));
w_1721 = ((5D + (ToNum(j_1718) * 2D)) * ToNum(k_1675));
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_23, V.Undef, Add(GetIdx(o_1709, 0D), ((V)(((NumTruthy((ToNum(j_1718) % 2D)) ? 2D : (-2D)) * ToNum(k_1675))))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(y_1720)))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)(w_1721)))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((w_1721 * 0.7))))).S("\" fill=\"#ffffff\" opacity=\"0.55\" filter=\"url(#fgB)\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>");
fl_1711 = Call(p_1674, V.Undef, x_1706, ((V)(0D)), ((V)(JZ_1647)));
un_1677.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(fl_1711, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(fl_1711, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((34D * ToNum(k_1675)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((((34D * ToNum(k_1675)) * ToNum(SA_42)) * 0.6))))).S("\" fill=\"#bfe8ff\" opacity=\"0.4\" filter=\"url(#fgB)\"/>");
return default;
}, 2, "", true));
Call(rep_24, V.Undef, ((V)(26D)), Fn((V _arrowThis1729, int _argc1722, V i_1728, V _a1725, V _a1726, V _a1727, V[] _rest1723) => {
V R2_1730 = default;
double vx_1731 = 0;
double H_1732 = 0;
V x1_1733 = default;
double y1_1734 = 0;
V x2_1735 = default;
double y2_1736 = 0;
double b_1737 = 0;
R2_1730 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("cft").V(i_1728).End())));
vx_1731 = (((ToNum(Call(R2_1730, V.Undef)) - 0.5) * 120D) * ToNum(k_1675));
H_1732 = ((90D + (ToNum(Call(R2_1730, V.Undef)) * 70D)) * ToNum(k_1675));
x1_1733 = Add(GetIdx(cm_1680, 0D), ((V)((vx_1731 * 0.5))));
y1_1734 = (ToNum(GetIdx(cm_1680, 1D)) - H_1732);
x2_1735 = Add(GetIdx(cm_1680, 0D), ((V)(vx_1731)));
y2_1736 = ((ToNum(GetIdx(cm_1680, 1D)) - (H_1732 * 0.3)) + ((ToNum(Call(R2_1730, V.Undef)) * 30D) * ToNum(k_1675)));
b_1737 = ((-1.2) - (ToNum(Call(R2_1730, V.Undef)) * 0.1));
f_1676.S("<rect x=\"0\" y=\"0\" width=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(k_1675)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((0.9 * ToNum(k_1675)))))).S("\" fill=\"").V(GetIdx(Arr(((V)("#ff4f6a")), ((V)("#ffd84f")), ((V)("#3ff0ff")), ((V)("#7dff6a")), ((V)("#b04bff")), ((V)("#ffffff"))), (ToNum(i_1728) % 6D))).S("\">").V(Call(atK_53, V.Undef, ((V)("translate")), Call(pts_60, V.Undef, Arr(cm_1680, cm_1680, Arr(x1_1733, ((V)(y1_1734))), Arr(x2_1735, ((V)(y2_1736))), Arr(x2_1735, ((V)(y2_1736))))), ((V)(2.4)), ((V)("0;0.5;0.66;0.98;1")), ((V)(b_1737)))).V(Call(anK_51, V.Undef, ((V)("opacity")), ((V)("0;0;1;0.9;0")), ((V)(2.4)), ((V)("0;0.5;0.52;0.95;1")), ((V)(b_1737)))).S("</rect>");
return default;
}, 1, "", true));
}
defs_1681 = Add(FGD_72, Call(G_61, V.Undef, ((V)("cjP")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.95))), Arr(((V)(0.7)), ((V)("#e6f6ff")), ((V)(0.55))), Arr(((V)(1D)), ((V)("#e6f6ff")), ((V)(0D)))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\""))).V));
return NewObj(4).Put("defs", defs_1681).Put("under", ((V)(un_1677.Str))).Put("front", ((V)(f_1676.Str))).Put("bb", Call(bbOf_34, V.Undef, Arr(Call(p_1674, V.Undef, ((V)((-58D))), ((V)(0D)), ((V)(24D))), Call(p_1674, V.Undef, ((V)(58D)), ((V)(0D)), ((V)(24D))), Call(p_1674, V.Undef, ((V)((-14D))), ((V)(90D)), ((V)((-32D)))), Call(p_1674, V.Undef, ((V)(56D)), ((V)(50D)), ((V)((-4D)))), (Truthy(on_1645) ? Call(p_1674, V.Undef, ((V)(0D)), ((V)(190D)), ((V)(0D))) : Call(p_1674, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(0D)))), (Truthy(on_1645) ? Call(p_1674, V.Undef, ((V)((-90D))), ((V)(120D)), ((V)(20D))) : Call(p_1674, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)))), (Truthy(on_1645) ? Call(p_1674, V.Undef, ((V)(90D)), ((V)(120D)), ((V)(20D))) : Call(p_1674, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D))))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1648;
return default;
}, 1, "", true));
Set(N_39, "mistMatrix", Fn((V _arrowThis1745, int _argc1738, V S_1744, V _a1741, V _a1742, V _a1743, V[] _rest1739) => {
V on_1746 = default;
V ICE_1747 = default;
V RINGS_1748 = default;
V D_1749 = default;
on_1746 = Call(isOn_57, V.Undef, S_1744);
ICE_1747 = ((V)("#e6f7ff"));
RINGS_1748 = Arr(Arr(((V)(82D)), ((V)(18D)), ((V)(0D))), Arr(((V)(96D)), ((V)(15D)), ((V)(0.9))), Arr(((V)(108D)), ((V)(11D)), ((V)(1.7))));
D_1749 = NewObj(2).Put("w", ((V)(96D))).Put("d", ((V)(96D))).V;
Set(D_1749, "build", Fn((V _arrowThis1757, int _argc1750, V P_1756, V _a1753, V _a1754, V _a1755, V[] _rest1751) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(33D)), ((V)(3.4)), ((V)("#0c0b10")), Call(cer_37, V.Undef, NewObj(1).Put("n", ((V)(30D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3.4)), ((V)(0D)), ((V)(31D)), ((V)(10D)), OB2_49, Call(cer_37, V.Undef, NewObj(2).Put("n", ((V)(30D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.9))))).V))).Add(Call(arcW_17, V.Undef, ((V)(0D)), ((V)(7.6)), ((V)(0D)), ((V)(31.4)), ((V)(31.4)), ((V)(0.8)), ((V)(0.9)), ((V)(0D)), ((V)((2D * PI_41))), CG_47, Call(em_40, V.Undef, NewObj(1).Put("n", ((V)(30D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(13.4)), ((V)(0D)), ((V)(28.4)), ((V)(1.4)), TI_46, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(30D))).Put("shine", ((V)(1D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(14.8)), ((V)(0D)), ((V)(26.6)), ((V)(2D)), OB_48, Call(cer_37, V.Undef, NewObj(1).Put("n", ((V)(28D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(16.8)), ((V)(0D)), ((V)(9.6)), ((V)(52D)), OB_48, Call(cer_37, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.08))), Arr(((V)(52D)), ((V)(0D)), ((V)(0.88))))).V))).Spread(Invoke(Arr(((V)(30D)), ((V)(48D))), "map", Fn((V _arrowThis1765, int _argc1758, V y_1764, V _a1761, V _a1762, V _a1763, V[] _rest1759) => {
return Call(cyl_13, V.Undef, ((V)(0D)), y_1764, ((V)(0D)), ((V)((9.9 - ((ToNum(y_1764) - 17D) * 0.004)))), ((V)(1.4)), TI_46, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("shine", ((V)(1D))).V));
}, 1, "", true))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(68.8)), ((V)(0D)), ((V)(12.4)), ((V)(3D)), TI_46, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(71.8)), ((V)(0D)), ((V)(10.4)), ((V)(1.4)), OB_48, Call(cer_37, V.Undef, NewObj(1).Put("n", ((V)(22D))).V))).Add(Call(arcW_17, V.Undef, ((V)(0D)), ((V)(71.8)), ((V)(0D)), ((V)(10.6)), ((V)(10.6)), ((V)(0.5)), ((V)(0.6)), ((V)(0D)), ((V)((2D * PI_41))), ICE_1747, Call(em_40, V.Undef, NewObj(1).Put("n", ((V)(22D))).V))).V;
}, 1, "", true));
Set(D_1749, "layers", Invoke(RINGS_1748, "map", Fn((V _arrowThis1779, int _argc1766, V _a1768, V _a1769, V _a1770, V _a1771, V[] _rest1767) => {
V y_1774 = default;
V r_1776 = default;
V ph_1778 = default;
{ V _t1772 = ListOf(_a1768);
{ V _t1773 = GetIdx(_t1772, 0D);
y_1774 = _t1773; }
{ V _t1775 = GetIdx(_t1772, 1D);
r_1776 = _t1775; }
{ V _t1777 = GetIdx(_t1772, 2D);
ph_1778 = _t1777; }
}
return NewObj(2).Put("anim", ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;0 -2.4;0 0\" dur=\"3.4s\" begin=\"").N((-ToNum(ph_1778))).S("s\" calcMode=\"spline\" keyTimes=\"0;0.5;1\" keySplines=\"0.42 0 0.58 1;0.42 0 0.58 1\" repeatCount=\"indefinite\"/>").End()))).Put("build", Fn((V _arrowThis1787, int _argc1780, V P_1786, V _a1783, V _a1784, V _a1785, V[] _rest1781) => {
return new ArrBuilder().Add(Call(arcW_17, V.Undef, ((V)(0D)), y_1774, ((V)(0D)), r_1776, r_1776, ((V)(2.4)), ((V)(2.2)), ((V)(0D)), ((V)((2D * PI_41))), TI_46, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).V))).Add(Call(arcW_17, V.Undef, ((V)(0D)), Add(y_1774, ((V)(2.2))), ((V)(0D)), ((V)((ToNum(r_1776) - 0.4))), ((V)((ToNum(r_1776) - 0.4))), ((V)(1.2)), ((V)(0.4)), ((V)(0D)), ((V)((2D * PI_41))), OB_48, Call(cer_37, V.Undef, NewObj(1).Put("n", ((V)(28D))).V))).Spread(Call(rep_24, V.Undef, ((V)(6D)), Fn((V _arrowThis1795, int _argc1788, V i_1794, V _a1791, V _a1792, V _a1793, V[] _rest1789) => {
V a_1796 = default;
a_1796 = Add(((V)(((ToNum(i_1794) * PI_41) / 3D))), ph_1778);
return Call(cyl_13, V.Undef, ((V)((FdLibm.Cos(ToNum(a_1796)) * ToNum(r_1776)))), Add(y_1774, ((V)(2.2))), ((V)((FdLibm.Sin(ToNum(a_1796)) * ToNum(r_1776)))), ((V)(0.9)), ((V)(1D)), ICE_1747, Call(em_40, V.Undef, NewObj(1).Put("n", ((V)(8D))).V));
return default;
}, 1, "", true))).V;
}, 1, "build", true)).V;
}, 1, "", true)));
Invoke(Get(D_1749, "layers"), "push", NewObj(2).Put("anim", ((V)("<animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;0 -3.4;0 0\" dur=\"4.2s\" calcMode=\"spline\" keyTimes=\"0;0.5;1\" keySplines=\"0.42 0 0.58 1;0.42 0 0.58 1\" repeatCount=\"indefinite\"/>"))).Put("build", Fn((V _arrowThis1804, int _argc1797, V P_1803, V _a1800, V _a1801, V _a1802, V[] _rest1798) => {
return Arr(Call(ball_14, V.Undef, ((V)(0D)), ((V)(116D)), ((V)(0D)), ((V)(9.4)), ((V)("#eef8ff")), Call(cer_37, V.Undef, NewObj(4).Put("op", ((V)(0.4))).Put("k", ((V)(6D))).Put("n", ((V)(20D))).Put("shine", ((V)(1D))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(120.4)), ((V)(0D)), ((V)(4.4)), ICE_1747, Call(em_40, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(14D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(119.6)), ((V)(0D)), ((V)(9.8)), ((V)(9.8)), ((V)(0.6)), ((V)(0.8)), ((V)(0D)), ((V)((2D * PI_41))), TI_46, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V)));
}, 1, "build", true)).V);
Set(D_1749, "fx", Fn((V _arrowThis1812, int _argc1805, V c_1811, V _a1808, V _a1809, V _a1810, V[] _rest1806) => {
V p_1813 = default;
V k_1814 = default;
JsStrBuf f_1815 = null;
JsStrBuf bk_1816 = null;
JsStrBuf un_1817 = null;
V cg_1818 = default;
V oc_1819 = default;
double nb_1820 = 0;
V fl_1821 = default;
V defs_1822 = default;
p_1813 = Get(c_1811, "p");
k_1814 = Get(c_1811, "k");
f_1815 = new JsStrBuf("");
bk_1816 = new JsStrBuf("");
un_1817 = new JsStrBuf("");
cg_1818 = Call(p_1813, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(0D)));
bk_1816.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(cg_1818, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(cg_1818, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((30D * ToNum(k_1814)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((70D * ToNum(k_1814)))))).S("\" fill=\"url(#mmH)\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)((Truthy(on_1746) ? "0.9;1;0.9" : "0.55;0.75;0.55"))), ((V)(4D)))).S("</ellipse>");
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1830, int _argc1823, V s_1829, V _a1826, V _a1827, V _a1828, V[] _rest1824) => {
V a_1831 = default;
V b_1832 = default;
a_1831 = Call(p_1813, V.Undef, ((V)((ToNum(s_1829) * 6.6))), ((V)(19D)), ((V)(6.6)));
b_1832 = Call(p_1813, V.Undef, ((V)((ToNum(s_1829) * 6D))), ((V)(66D)), ((V)(6D)));
f_1815.V(Call(glowL_62, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P2_27, V.Undef, a_1831)).S("L").V(Call(P2_27, V.Undef, b_1832)).End())), (GtN(s_1829, 0D) ? ICE_1747 : CG_47), ((V)((0.45 * ToNum(k_1814)))), ((V)("mmB"))));
return default;
}, 1, "", true));
oc_1819 = Call(p_1813, V.Undef, ((V)(0D)), ((V)(120D)), ((V)(0D)));
nb_1820 = (Truthy(on_1746) ? 22D : 12D);
Call(rep_24, V.Undef, ((V)(nb_1820)), Fn((V _arrowThis1840, int _argc1833, V i_1839, V _a1836, V _a1837, V _a1838, V[] _rest1834) => {
V R2_1841 = default;
double rx_1842 = 0;
double ry_1843 = 0;
double cy_1844 = 0;
V d_1845 = default;
double r_1846 = 0;
double b_1847 = 0;
V path_1848 = default;
R2_1841 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("mb").V(i_1839).End())));
rx_1842 = ((16D + (ToNum(Call(R2_1841, V.Undef)) * 18D)) * ToNum(k_1814));
ry_1843 = (rx_1842 * 0.32);
cy_1844 = (ToNum(GetIdx(oc_1819, 1D)) - (((ToNum(Call(R2_1841, V.Undef)) * 26D) - 10D) * ToNum(k_1814)));
d_1845 = Call(n4_26, V.Undef, ((V)((6D + (ToNum(Call(R2_1841, V.Undef)) * 6D)))));
r_1846 = ((1.4 + (ToNum(Call(R2_1841, V.Undef)) * 2.4)) * ToNum(k_1814));
b_1847 = ((-ToNum(Call(R2_1841, V.Undef))) * ToNum(d_1845));
path_1848 = ((V)(JsStrBuf.Begin().S("M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(oc_1819, 0D)) - rx_1842))))).S(" ").V(Call(f1_23, V.Undef, ((V)(cy_1844)))).S("A").V(Call(f1_23, V.Undef, ((V)(rx_1842)))).S(" ").V(Call(f1_23, V.Undef, ((V)(ry_1843)))).S(" 0 1 0 ").V(Call(f1_23, V.Undef, Add(GetIdx(oc_1819, 0D), ((V)(rx_1842))))).S(" ").V(Call(f1_23, V.Undef, ((V)(cy_1844)))).S("A").V(Call(f1_23, V.Undef, ((V)(rx_1842)))).S(" ").V(Call(f1_23, V.Undef, ((V)(ry_1843)))).S(" 0 1 0 ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(oc_1819, 0D)) - rx_1842))))).S(" ").V(Call(f1_23, V.Undef, ((V)(cy_1844)))).End()));
f_1815.S("<g><animateMotion dur=\"").V(d_1845).S("s\" begin=\"").V(Call(n4_26, V.Undef, ((V)(b_1847)))).S("s\" repeatCount=\"indefinite\" path=\"").V(path_1848).S("\"/>").V(Call(anK_51, V.Undef, ((V)("opacity")), ((V)("1;1;0.25;0.25;1")), d_1845, ((V)("0;0.44;0.54;0.94;1")), ((V)(b_1847)))).S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)(r_1846)))).S("\" fill=\"url(#mmBb)\" stroke=\"#ffffff\" stroke-opacity=\"0.7\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.2 * ToNum(k_1814)))))).S("\"/><circle cx=\"").V(Call(f1_23, V.Undef, ((V)(((-r_1846) * 0.35))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-r_1846) * 0.4))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((r_1846 * 0.24))))).S("\" fill=\"#ffffff\" opacity=\"0.9\"/></g>");
return default;
}, 1, "", true));
if (Truthy(on_1746)) {
Invoke(RINGS_1748, "forEach", Fn((V _arrowThis1863, int _argc1849, V _a1851, V j_1855, V _a1853, V _a1854, V[] _rest1850) => {
V y_1858 = default;
V r_1860 = default;
V ph_1862 = default;
{ V _t1856 = ListOf(_a1851);
{ V _t1857 = GetIdx(_t1856, 0D);
y_1858 = _t1857; }
{ V _t1859 = GetIdx(_t1856, 1D);
r_1860 = _t1859; }
{ V _t1861 = GetIdx(_t1856, 2D);
ph_1862 = _t1861; }
}
return Call(rep_24, V.Undef, ((V)(6D)), Fn((V _arrowThis1871, int _argc1864, V i_1870, V _a1867, V _a1868, V _a1869, V[] _rest1865) => {
V a_1872 = default;
V q_1873 = default;
V ex_1874 = default;
double ey_1875 = 0;
double b_1876 = 0;
a_1872 = Add(((V)(((ToNum(i_1870) * PI_41) / 3D))), ph_1862);
q_1873 = Call(p_1813, V.Undef, ((V)((FdLibm.Cos(ToNum(a_1872)) * ToNum(r_1860)))), Add(y_1858, ((V)(2.4))), ((V)((FdLibm.Sin(ToNum(a_1872)) * ToNum(r_1860)))));
ex_1874 = Add(GetIdx(q_1873, 0D), ((V)(((FdLibm.Cos((ToNum(a_1872) - (PI_41 / 6D))) * 22D) * ToNum(k_1814)))));
ey_1875 = ((ToNum(GetIdx(q_1873, 1D)) - (10D * ToNum(k_1814))) + ((FdLibm.Sin(ToNum(a_1872)) * 8D) * ToNum(k_1814)));
b_1876 = (-((ToNum(i_1870) * 0.4) + (ToNum(j_1855) * 0.2)));
f_1815.S("<path d=\"M").V(Call(P2_27, V.Undef, q_1873)).S("q").V(Call(f1_23, V.Undef, ((V)((6D * ToNum(k_1814)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-6D) * ToNum(k_1814)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(ex_1874) - ToNum(GetIdx(q_1873, 0D))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ey_1875 - ToNum(GetIdx(q_1873, 1D))))))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((2.6 * ToNum(k_1814)))))).S("\" stroke-linecap=\"round\" opacity=\"0\" filter=\"url(#mmB)\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0;0.55;0")), ((V)(2.4)), ((V)(b_1876)))).V(Call(an_31, V.Undef, ((V)("stroke-width")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((1D * ToNum(k_1814)))))).S(";").V(Call(f1_23, V.Undef, ((V)((5D * ToNum(k_1814)))))).End())), ((V)(2.4)), ((V)(b_1876)))).S("</path>");
return default;
}, 1, "", true));
}, 2, "", true));
}
fl_1821 = Call(p_1813, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
un_1817.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(fl_1821, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(fl_1821, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((60D * ToNum(k_1814)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((((60D * ToNum(k_1814)) * ToNum(SA_42)) * 0.6))))).S("\" fill=\"").V(CG_47).S("\" opacity=\"").N((Truthy(on_1746) ? 0.3 : 0.16)).S("\" filter=\"url(#mmB)\"/>");
defs_1822 = Add(Add(Call(BLUR_33, V.Undef, ((V)("mmB")), ((V)(1.2))), Call(G_61, V.Undef, ((V)("mmH")), Arr(Arr(((V)(0D)), ICE_1747, ((V)(0.45))), Arr(((V)(0.6)), ((V)("#bcd8ff")), ((V)(0.12))), Arr(((V)(1D)), ((V)("#bcd8ff")), ((V)(0D)))), NewObj(1).Put("r", ((V)(1D))).V)), Call(G_61, V.Undef, ((V)("mmBb")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.04))), Arr(((V)(0.7)), ((V)("#cfeeff")), ((V)(0.14))), Arr(((V)(0.86)), ((V)("#f6c8ff")), ((V)(0.32))), Arr(((V)(1D)), ((V)("#9fe6ff")), ((V)(0.52)))), NewObj(1).Put("r", ((V)(1D))).V));
return NewObj(5).Put("defs", defs_1822).Put("under", ((V)(un_1817.Str))).Put("back", ((V)(bk_1816.Str))).Put("front", ((V)(f_1815.Str))).Put("bb", Call(bbOf_34, V.Undef, Arr(Call(p_1813, V.Undef, ((V)((-36D))), ((V)(160D)), ((V)(0D))), Call(p_1813, V.Undef, ((V)(36D)), ((V)(160D)), ((V)(0D))), Call(p_1813, V.Undef, ((V)((-36D))), ((V)(0D)), ((V)(36D))), Call(p_1813, V.Undef, ((V)(36D)), ((V)(0D)), ((V)((-36D)))), Call(p_1813, V.Undef, ((V)((-36D))), ((V)(0D)), ((V)((-36D)))), Call(p_1813, V.Undef, ((V)(36D)), ((V)(0D)), ((V)(36D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1749;
return default;
}, 1, "", true));
Set(N_39, "bassReactor", Fn((V _arrowThis1884, int _argc1877, V S_1883, V _a1880, V _a1881, V _a1882, V[] _rest1878) => {
V play_1885 = default;
V ICE_1886 = default;
V WARM_1887 = default;
double TX_1888 = 0;
double TZ_1889 = 0;
V GM_1890 = default;
V DRV_1891 = default;
V D_1892 = default;
play_1885 = Call(isPlay_56, V.Undef, S_1883);
ICE_1886 = ((V)("#e8f4ff"));
WARM_1887 = ((V)("#f2d9a6"));
TX_1888 = 44D;
TZ_1889 = (-6D);
GM_1890 = ((V)("#3a3c44"));
DRV_1891 = Arr(((V)(26D)), ((V)(52D)), ((V)(78D)));
D_1892 = NewObj(2).Put("w", ((V)(150D))).Put("d", ((V)(70D))).V;
Set(D_1892, "build", Fn((V _arrowThis1900, int _argc1893, V P_1899, V _a1896, V _a1897, V _a1898, V[] _rest1894) => {
V o_1901 = default;
o_1901 = Arr();
Invoke(Arr(((V)((-TX_1888))), ((V)(TX_1888))), "forEach", Fn((V _arrowThis1909, int _argc1902, V x_1908, V _a1905, V _a1906, V _a1907, V[] _rest1903) => {
Invoke(o_1901, "push", Call(box_12, V.Undef, x_1908, ((V)(0D)), ((V)(TZ_1889)), ((V)(29D)), ((V)(4D)), ((V)(29D)), ((V)("#0c0c10")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, x_1908, ((V)(4D)), ((V)(TZ_1889)), ((V)(24D)), ((V)(96D)), ((V)(24D)), OB_48, Call(cer_37, V.Undef, NewObj(1).Put("r", ((V)(6D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1917, int _argc1910, V s_1916, V _a1913, V _a1914, V _a1915, V[] _rest1911) => {
return Call(rep_24, V.Undef, ((V)(6D)), Fn((V _arrowThis1925, int _argc1918, V i_1924, V _a1921, V _a1922, V _a1923, V[] _rest1919) => {
return Invoke(o_1901, "push", Call(box_12, V.Undef, Add(x_1908, ((V)((ToNum(s_1916) * 12.6)))), ((V)((14D + (ToNum(i_1924) * 13.6)))), ((V)(TZ_1889)), ((V)(1.8)), ((V)(8D)), ((V)(19D)), GM_1890, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(o_1901, "push", Call(box_12, V.Undef, x_1908, ((V)(100D)), ((V)(TZ_1889)), ((V)(25.6)), ((V)(3D)), ((V)(25.6)), TI_46, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, x_1908, ((V)(99.6)), ((V)(TZ_1889)), ((V)(26D)), ((V)(0.6)), ((V)(26D)), CG_47, Call(em_40, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(cyl_13, V.Undef, x_1908, ((V)(103D)), ((V)(TZ_1889)), ((V)(7.4)), ((V)(6D)), ((V)("#0c0c10")), Call(cer_37, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(6D)), ((V)(0D)), ((V)(1.1))))).V)), Call(cyl_13, V.Undef, x_1908, ((V)(108.6)), ((V)(TZ_1889)), ((V)(8.4)), ((V)(1.2)), TI_46, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("shine", ((V)(1D))).V)));
Invoke(DRV_1891, "forEach", Fn((V _arrowThis1933, int _argc1926, V y_1932, V _a1929, V _a1930, V _a1931, V[] _rest1927) => {
return Invoke(o_1901, "push", Call(disc_18, V.Undef, x_1908, y_1932, ((V)((TZ_1889 + 12D))), ((V)(8.8)), ((V)(1D)), TI_46, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V)), Call(disc_18, V.Undef, x_1908, y_1932, ((V)((TZ_1889 + 13D))), ((V)(7.2)), ((V)(0.8)), ((V)("#0a0a0e")), Call(cer_37, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)), Call(disc_18, V.Undef, x_1908, y_1932, ((V)((TZ_1889 + 13.8))), ((V)(2.6)), ((V)(1.4)), TI_46, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(o_1901, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(21D)), ((V)(3D)), ((V)("#0c0c10")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(28D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(4D)), ((V)(18D)), ((V)(6D)), OB2_49, Call(cer_37, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.86))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(9D)), ((V)(4D)), ((V)(15.4)), ((V)(1D)), TI_46, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(4D)), ((V)(12D)), ((V)(12D)), ((V)(0.6)), ((V)(0.4)), ((V)(0D)), ((V)((2D * PI_41))), ICE_1886, Call(em_40, V.Undef, NewObj(1).Put("n", ((V)(26D))).V)));
return o_1901;
return default;
}, 1, "", true));
Set(D_1892, "layers", Arr(NewObj(2).Put("anim", ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;0 -3;0 0\" dur=\"").N((Truthy(play_1885) ? 0.9 : 3.6)).S("s\" calcMode=\"spline\" keyTimes=\"0;0.5;1\" keySplines=\"0.42 0 0.58 1;0.42 0 0.58 1\" repeatCount=\"indefinite\"/>").End()))).Put("build", Fn((V _arrowThis1941, int _argc1934, V P_1940, V _a1937, V _a1938, V _a1939, V[] _rest1935) => {
return Arr(Call(ball_14, V.Undef, ((V)(0D)), ((V)(21D)), ((V)(4D)), ((V)(15D)), ((V)("#0d0d12")), Call(cer_37, V.Undef, NewObj(3).Put("k", ((V)(8D))).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(35.2)), ((V)(4D)), ((V)(15.3)), ((V)(15.3)), ((V)(0.9)), ((V)(1.4)), ((V)(0D)), ((V)((2D * PI_41))), TI_46, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(36.6)), ((V)(4D)), ((V)(15.4)), ((V)(15.4)), ((V)(0.4)), ((V)(0.3)), ((V)(0D)), ((V)((2D * PI_41))), WARM_1887, Call(em_40, V.Undef, NewObj(1).Put("n", ((V)(28D))).V)));
}, 1, "build", true)).V));
Set(D_1892, "fx", Fn((V _arrowThis1949, int _argc1942, V c_1948, V _a1945, V _a1946, V _a1947, V[] _rest1943) => {
V p_1950 = default;
V k_1951 = default;
JsStrBuf f_1952 = null;
JsStrBuf un_1953 = null;
V sp_1954 = default;
V fl_1955 = default;
V defs_1956 = default;
p_1950 = Get(c_1948, "p");
k_1951 = Get(c_1948, "k");
f_1952 = new JsStrBuf("");
un_1953 = new JsStrBuf("");
Invoke(Arr(((V)((-TX_1888))), ((V)(TX_1888))), "forEach", Fn((V _arrowThis1965, int _argc1957, V x_1963, V i_1964, V _a1961, V _a1962, V[] _rest1958) => {
V a_1966 = default;
V b_1967 = default;
V tp_1968 = default;
a_1966 = Call(p_1950, V.Undef, x_1963, ((V)(8D)), ((V)((TZ_1889 + 12.3))));
b_1967 = Call(p_1950, V.Undef, x_1963, ((V)(96D)), ((V)((TZ_1889 + 12.3))));
f_1952.V(Call(glowL_62, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(P2_27, V.Undef, Call(p_1950, V.Undef, ((V)((ToNum(x_1963) - 9.6))), ((V)(9D)), ((V)((TZ_1889 + 12.3)))))).S("L").V(Call(P2_27, V.Undef, Call(p_1950, V.Undef, ((V)((ToNum(x_1963) - 9.6))), ((V)(94D)), ((V)((TZ_1889 + 12.3)))))).End())), ICE_1886, ((V)((0.4 * ToNum(k_1951)))), ((V)("brB"))));
Invoke(DRV_1891, "forEach", Fn((V _arrowThis1977, int _argc1969, V y_1975, V j_1976, V _a1973, V _a1974, V[] _rest1970) => {
V g_1978 = default;
g_1978 = Call(plane_29, V.Undef, p_1950, ((V)((TZ_1889 + 14.2))), y_1975, x_1963);
f_1952.S("<g transform=\"").V(g_1978).S("\"><circle r=\"7.2\" fill=\"url(#brC)\"/><circle r=\"2.2\" fill=\"").V((Truthy(play_1885) ? ICE_1886 : ((V)("#3a3c44")))).S("\" opacity=\"").N((Truthy(play_1885) ? 0.9 : 0.6)).S("\">").V((Truthy(play_1885) ? Call(an_31, V.Undef, ((V)("r")), ((V)("1.8;3;1.8")), ((V)(0.45)), ((V)(((-ToNum(j_1976)) * 0.15)))) : ((V)("")))).S("</circle>").V((Truthy(play_1885) ? Invoke(Call(rep_24, V.Undef, ((V)(3D)), Fn((V _arrowThis1986, int _argc1979, V r2_1985, V _a1982, V _a1983, V _a1984, V[] _rest1980) => {
return ((V)(JsStrBuf.Begin().S("<circle r=\"8\" fill=\"none\" stroke=\"").V((SEqN(j_1976, 1D) ? WARM_1887 : ICE_1886)).S("\" stroke-width=\"0.6\">").V(Call(an_31, V.Undef, ((V)("r")), ((V)("8;36")), ((V)(1.35)), ((V)((((-ToNum(r2_1985)) * 0.45) - (ToNum(j_1976) * 0.2)))))).V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.8;0")), ((V)(1.35)), ((V)((((-ToNum(r2_1985)) * 0.45) - (ToNum(j_1976) * 0.2)))))).S("</circle>").End()));
}, 1, "", true)), "join", ((V)(""))) : ((V)("")))).S("</g>");
return default;
}, 2, "", true));
tp_1968 = Call(p_1950, V.Undef, x_1963, ((V)(109D)), ((V)(TZ_1889)));
if (Truthy(play_1885)) {
f_1952.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(tp_1968, 0D)) - (4D * ToNum(k_1951))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(tp_1968, 1D))).S("L").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(tp_1968, 0D)) - (16D * ToNum(k_1951))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(tp_1968, 1D)) - (90D * ToNum(k_1951))))))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(tp_1968, 0D), ((V)((16D * ToNum(k_1951))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(tp_1968, 1D)) - (90D * ToNum(k_1951))))))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(tp_1968, 0D), ((V)((4D * ToNum(k_1951))))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(tp_1968, 1D))).S("Z\" fill=\"url(#brBeam)\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("1;0.4;1")), ((V)(0.9)), ((V)(((-ToNum(i_1964)) * 0.45))))).S("</path>");
}
return default;
}, 2, "", true));
sp_1954 = Call(p_1950, V.Undef, ((V)(0D)), ((V)(21D)), ((V)(4D)));
f_1952.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(sp_1954, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(sp_1954, 1D)) - (3D * ToNum(k_1951))))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((26D * ToNum(k_1951)))))).S("\" fill=\"none\" stroke=\"").V(ICE_1886).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.35 * ToNum(k_1951)))))).S("\" opacity=\"0.4\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(k_1951)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((3D * ToNum(k_1951)))))).S("\">").V(Call(atL_54, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().S("0 ").V(Call(P2_27, V.Undef, sp_1954)).S(";360 ").V(Call(P2_27, V.Undef, sp_1954)).End())), ((V)((Truthy(play_1885) ? 4D : 16D))))).S("</circle>");
un_1953.S("<g transform=\"").V(Call(planeH_30, V.Undef, p_1950, ((V)(0.5)), ((V)(0D)), ((V)(4D)))).S("\">").V(Invoke(Call(rep_24, V.Undef, ((V)((Truthy(play_1885) ? 4D : 2D))), Fn((V _arrowThis1994, int _argc1987, V j_1993, V _a1990, V _a1991, V _a1992, V[] _rest1988) => {
return ((V)(JsStrBuf.Begin().S("<ellipse rx=\"20\" ry=\"20\" fill=\"none\" stroke=\"").V((NumTruthy((ToNum(j_1993) % 2D)) ? WARM_1887 : ICE_1886)).S("\" stroke-width=\"1.1\">").V(Call(an_31, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().S("20;").N((Truthy(play_1885) ? 90D : 46D)).End())), ((V)((Truthy(play_1885) ? 1.8 : 4D))), ((V)(((-ToNum(j_1993)) * (Truthy(play_1885) ? 0.45 : 2D)))))).V(Call(an_31, V.Undef, ((V)("ry")), ((V)(JsStrBuf.Begin().S("20;").N((Truthy(play_1885) ? 90D : 46D)).End())), ((V)((Truthy(play_1885) ? 1.8 : 4D))), ((V)(((-ToNum(j_1993)) * (Truthy(play_1885) ? 0.45 : 2D)))))).V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.7;0")), ((V)((Truthy(play_1885) ? 1.8 : 4D))), ((V)(((-ToNum(j_1993)) * (Truthy(play_1885) ? 0.45 : 2D)))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
fl_1955 = Call(p_1950, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
un_1953.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(fl_1955, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(fl_1955, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((86D * ToNum(k_1951)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((((86D * ToNum(k_1951)) * ToNum(SA_42)) * 0.55))))).S("\" fill=\"").V(ICE_1886).S("\" opacity=\"").N((Truthy(play_1885) ? 0.24 : 0.12)).S("\" filter=\"url(#brB)\"/>");
defs_1956 = Add(Add(Call(BLUR_33, V.Undef, ((V)("brB")), ((V)(1.2))), Call(G_61, V.Undef, ((V)("brC")), Arr(Arr(((V)(0D)), ((V)("#2a2c34"))), Arr(((V)(0.7)), ((V)("#0a0a0e"))), Arr(((V)(1D)), ((V)("#000000")))), NewObj(1).Put("r", ((V)(1D))).V)), Call(G_61, V.Undef, ((V)("brBeam")), Arr(Arr(((V)(0D)), ICE_1886, ((V)(0.55))), Arr(((V)(1D)), ICE_1886, ((V)(0D)))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\""))).V));
return NewObj(4).Put("defs", defs_1956).Put("under", ((V)(un_1953.Str))).Put("front", ((V)(f_1952.Str))).Put("bb", Call(bbOf_34, V.Undef, Arr(Call(p_1950, V.Undef, ((V)(((-TX_1888) - 16D))), ((V)(112D)), ((V)((TZ_1889 - 14D)))), Call(p_1950, V.Undef, ((V)((TX_1888 + 16D))), ((V)(112D)), ((V)((TZ_1889 - 14D)))), Call(p_1950, V.Undef, ((V)(((-TX_1888) - 16D))), ((V)(0D)), ((V)((TZ_1889 + 16D)))), Call(p_1950, V.Undef, ((V)((TX_1888 + 16D))), ((V)(0D)), ((V)((TZ_1889 + 16D)))), Call(p_1950, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(40D))), (Truthy(play_1885) ? Call(p_1950, V.Undef, ((V)((-TX_1888))), ((V)(200D)), ((V)(TZ_1889))) : Call(p_1950, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)))), (Truthy(play_1885) ? Call(p_1950, V.Undef, ((V)(TX_1888)), ((V)(200D)), ((V)(TZ_1889))) : Call(p_1950, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D))))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1892;
return default;
}, 1, "", true));
DJV_73 = NewObj(8).Put("table", NewObj(2).Put("body", ((V)("table"))).Put("gear", ((V)("ctrl"))).V).Put("plywood", NewObj(2).Put("body", ((V)("ply"))).Put("gear", ((V)("tt"))).V).Put("truss", NewObj(2).Put("body", ((V)("truss"))).Put("gear", ((V)("cdj"))).V).Put("altar", NewObj(2).Put("body", ((V)("altar"))).Put("gear", ((V)("cdj"))).V).Put("cyber", NewObj(2).Put("body", ((V)("cyber"))).Put("gear", ((V)("holo"))).V).Put("ctrl", NewObj(2).Put("body", ((V)("desk"))).Put("gear", ((V)("ctrl"))).V).Put("vinyl", NewObj(2).Put("body", ((V)("desk"))).Put("gear", ((V)("tt"))).V).Put("quad", NewObj(2).Put("body", ((V)("deskW"))).Put("gear", ((V)("cdj4"))).V).V;
Set(N_39, "djBooth", Fn((V _arrowThis2002, int _argc1995, V S_2001, V _a1998, V _a1999, V _a2000, V[] _rest1996) => {
V V_2003 = default;
V play_2004 = default;
double W_2005 = 0;
double HW_2006 = 0;
double DD_2007 = 0;
double TOP_2008 = 0;
V LUX_2009 = default;
V CY_2010 = default;
V MG_2011 = default;
V BRS_2012 = default;
V decks_2013 = default;
double DZ_2014 = 0;
double DR_2015 = 0;
double DY_2016 = 0;
V D_2017 = default;
V_2003 = (GetK(DJV_73, Get(S_2001, "v")) is var _t2018 && Truthy(_t2018) ? _t2018 : Get(DJV_73, "plywood"));
play_2004 = Call(isPlay_56, V.Undef, S_2001);
W_2005 = (SEqS(Get(V_2003, "body"), "deskW") ? 140D : 124D);
HW_2006 = (W_2005 / 2D);
DD_2007 = 50D;
TOP_2008 = 40D;
LUX_2009 = (((SEqS(Get(V_2003, "body"), "altar") || SEqS(Get(V_2003, "body"), "cyber")) || SEqS(Get(V_2003, "body"), "deskW")) ? V.True : V.False);
CY_2010 = ((V)((Truthy(LUX_2009) ? "#ffcf8a" : "#3ff0ff")));
MG_2011 = ((V)((Truthy(LUX_2009) ? "#ff9a8a" : "#ff4fb8")));
BRS_2012 = ((V)("#c8a050"));
decks_2013 = (SEqS(Get(V_2003, "gear"), "cdj4") ? Arr(((V)((-58D))), ((V)((-30D))), ((V)(30D)), ((V)(58D))) : (SEqS(Get(V_2003, "gear"), "tt") ? Arr(((V)((-34D))), ((V)(34D))) : (SEqS(Get(V_2003, "gear"), "ctrl") ? Arr(((V)((-22D))), ((V)(22D))) : Arr(((V)((-32D))), ((V)(32D))))));
DZ_2014 = 2D;
DR_2015 = (SEqS(Get(V_2003, "gear"), "tt") ? 12D : (SEqS(Get(V_2003, "gear"), "ctrl") ? 9D : 10.5));
DY_2016 = (TOP_2008 + (SEqS(Get(V_2003, "gear"), "tt") ? 6.6 : (SEqS(Get(V_2003, "gear"), "ctrl") ? 3.4 : (SEqS(Get(V_2003, "gear"), "holo") ? 3.6 : 7D))));
D_2017 = NewObj(2).Put("w", ((V)((W_2005 + 8D)))).Put("d", ((V)((DD_2007 + 10D)))).V;
Set(D_2017, "build", Fn((V _arrowThis2026, int _argc2019, V P_2025, V _a2022, V _a2023, V _a2024, V[] _rest2020) => {
V o_2027 = default;
V b_2028 = default;
V g_2029 = default;
o_2027 = Arr();
b_2028 = Get(V_2003, "body");
if (SEqS(b_2028, "table")) {
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(36.6)), ((V)(0D)), ((V)(W_2005)), ((V)(3D)), ((V)(DD_2007)), ((V)("#ecebe6")), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(34.6)), ((V)(0D)), ((V)((W_2005 - 8D))), ((V)(2D)), ((V)((DD_2007 - 6D))), ((V)("#8a8f96")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2037, int _argc2030, V s_2036, V _a2033, V _a2034, V _a2035, V[] _rest2031) => {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2045, int _argc2038, V t_2044, V _a2041, V _a2042, V _a2043, V[] _rest2039) => {
return Invoke(o_2027, "push", Call(cyl_13, V.Undef, ((V)((ToNum(s_2036) * (HW_2006 - 8D)))), ((V)(0D)), ((V)((ToNum(t_2044) * 19D))), ((V)(1.3)), ((V)(34.6)), ((V)("#9aa1a8")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)((ToNum(s_2036) * (HW_2006 - 8D)))), ((V)(8D)), ((V)(0D)), ((V)(1.6)), ((V)(1.6)), ((V)(38D)), ((V)("#9aa1a8")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
return default;
}, 1, "", true));
Invoke(o_2027, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(((DD_2007 / 2D) + 0.6))), ((V)((W_2005 - 6D))), ((V)(30D)), ((V)(0.6)), ((V)("#f1ece0")), NewObj(3).Put("r", ((V)(1D))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V));
} else {
if (SEqS(b_2028, "ply")) {
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(W_2005)), ((V)(38D)), ((V)(DD_2007)), ((V)("#d9b98a")), Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(0D)), ((V)((W_2005 + 2D))), ((V)(2D)), ((V)((DD_2007 + 2D))), ((V)("#c49a62")), Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((W_2005 + 1D))), ((V)(3D)), ((V)((DD_2007 + 1D))), ((V)("#2a2a2e")), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
} else {
if (SEqS(b_2028, "truss")) {
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-2D))), ((V)((W_2005 - 8D))), ((V)(36D)), ((V)((DD_2007 - 8D))), ((V)("#141519")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(0D)), ((V)((W_2005 - 2D))), ((V)(4D)), ((V)((DD_2007 - 2D))), ((V)("#1b1c21")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2053, int _argc2046, V s_2052, V _a2049, V _a2050, V _a2051, V[] _rest2047) => {
return Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2061, int _argc2054, V t_2060, V _a2057, V _a2058, V _a2059, V[] _rest2055) => {
return Invoke(Arr(((V)(0D)), ((V)(1D))), "forEach", Fn((V _arrowThis2069, int _argc2062, V e_2068, V _a2065, V _a2066, V _a2067, V[] _rest2063) => {
return Invoke(o_2027, "push", Call(cyl_13, V.Undef, ((V)((ToNum(s_2052) * ((HW_2006 - 3D) - (ToNum(e_2068) * 4D))))), ((V)(0D)), ((V)((ToNum(t_2060) * ((DD_2007 / 2D) - 3D)))), ((V)(1D)), ((V)(36D)), CH_44, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(((V)(0D)), ((V)(34D))), "forEach", Fn((V _arrowThis2077, int _argc2070, V y_2076, V _a2073, V _a2074, V _a2075, V[] _rest2071) => {
return Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2085, int _argc2078, V t_2084, V _a2081, V _a2082, V _a2083, V[] _rest2079) => {
return Invoke(o_2027, "push", Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((ToNum(t_2084) * ((DD_2007 / 2D) - 3D)))), Add(y_2076, ((V)(1D))))).Put("a", ((V)(1D))).Put("b", ((V)(1D))).Put("n", ((V)(8D))).Put("rings", Arr(Arr(((V)(((-HW_2006) + 3D))), ((V)(0D))), Arr(((V)((HW_2006 - 3D))), ((V)(0D))))).Put("col", CH_44).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V));
}, 1, "", true));
}, 1, "", true));
Invoke(o_2027, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(((DD_2007 / 2D) + 0.2))), ((V)((W_2005 - 4D))), ((V)(32D)), ((V)(1.2)), ((V)("#cfe8f2")), Call(cer_37, V.Undef, NewObj(2).Put("op", ((V)(0.26))).Put("r", ((V)(1D))).V)));
} else {
if (SEqS(b_2028, "altar")) {
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(W_2005)), ((V)(2.6)), ((V)((DD_2007 + 2D))), ((V)("#0a0a0d")), Call(cer_37, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(2.6)), ((V)(0D)), ((V)(W_2005)), ((V)(0.8)), ((V)((DD_2007 + 2D))), BRS_2012, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(3.4)), ((V)(0D)), ((V)(W_2005)), ((V)(0.6)), ((V)((DD_2007 + 2D))), ((V)("#0a0a0d")), Call(cer_37, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(prism_19, V.Undef, ((V)((-HW_2006))), ((V)(HW_2006)), Arr(Arr(((V)(((-DD_2007) / 2D))), ((V)(4D))), Arr(((V)(((DD_2007 / 2D) - 6D))), ((V)(4D))), Arr(((V)(((DD_2007 / 2D) + 1D))), ((V)(16D))), Arr(((V)(((DD_2007 / 2D) - 3D))), ((V)(38D))), Arr(((V)(((-DD_2007) / 2D))), ((V)(38D)))), OB_48, Call(cer_37, V.Undef)), Call(box_12, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(0D)), ((V)((W_2005 + 1D))), ((V)(0.8)), ((V)((DD_2007 + 1D))), BRS_2012, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(38.8)), ((V)(0D)), ((V)((W_2005 + 1D))), ((V)(1.2)), ((V)((DD_2007 + 1D))), ((V)("#2e2418")), Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("shine", ((V)(1D))).V)));
} else {
if (SEqS(b_2028, "cyber")) {
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((W_2005 + 6D))), ((V)(3.4)), ((V)((DD_2007 + 8D))), ((V)("#141216")), Call(cer_37, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(3.4)), ((V)(0D)), ((V)((W_2005 + 6D))), ((V)(0.8)), ((V)((DD_2007 + 8D))), BRS_2012, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(4.2)), ((V)(0D)), ((V)((W_2005 + 6D))), ((V)(0.8)), ((V)((DD_2007 + 8D))), ((V)("#141216")), Call(cer_37, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(((DD_2007 / 2D) + 3.6))), ((V)((W_2005 + 4D))), ((V)(0.8)), ((V)(0.6)), CY_2010, Call(em_40, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2093, int _argc2086, V s_2092, V _a2089, V _a2090, V _a2091, V[] _rest2087) => {
return Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2101, int _argc2094, V t_2100, V _a2097, V _a2098, V _a2099, V[] _rest2095) => {
return Invoke(o_2027, "push", Call(cyl_13, V.Undef, ((V)((ToNum(s_2092) * (HW_2006 - 10D)))), ((V)(5D)), ((V)((ToNum(t_2100) * 14D))), ((V)(3.2)), ((V)(6D)), BRS_2012, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)((ToNum(s_2092) * (HW_2006 - 10D)))), ((V)(11D)), ((V)((ToNum(t_2100) * 14D))), ((V)(1.8)), ((V)(4D)), CH_44, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(15D)), ((V)(0D)), ((V)(W_2005)), ((V)(1.2)), ((V)(DD_2007)), BRS_2012, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(4D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(16.2)), ((V)(0D)), ((V)(W_2005)), ((V)(21.8)), ((V)(DD_2007)), ((V)("#1a1418")), Call(cer_37, V.Undef, NewObj(1).Put("r", ((V)(4D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(15.4)), ((V)(((DD_2007 / 2D) + 0.2))), ((V)((W_2005 - 4D))), ((V)(1D)), ((V)(0.6)), CY_2010, Call(em_40, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(0D)), ((V)((W_2005 + 1D))), ((V)(0.8)), ((V)((DD_2007 + 1D))), BRS_2012, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(38.8)), ((V)(0D)), ((V)((W_2005 + 1D))), ((V)(1.2)), ((V)((DD_2007 + 1D))), ((V)("#2e2418")), Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("shine", ((V)(1D))).V)));
} else {
V gd_2102 = default;
V WN_2103 = default;
gd_2102 = (SEqS(b_2028, "deskW") ? V.True : V.False);
WN_2103 = ((V)("#4a2c1a"));
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(0D)), ((V)(W_2005)), ((V)(4D)), ((V)((DD_2007 - 4D))), (Truthy(gd_2102) ? WN_2103 : ((V)("#1d1e22"))), (Truthy(gd_2102) ? Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V) : Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V))), Call(box_12, V.Undef, ((V)(0D)), ((V)(39.6)), ((V)(0D)), ((V)((W_2005 + 0.4))), ((V)(0.6)), ((V)((DD_2007 - 3.6))), (Truthy(gd_2102) ? GOLD_45 : ((V)("#2c2e35"))), Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(1.5))).Put("shine", ((V)(1D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2111, int _argc2104, V s_2110, V _a2107, V _a2108, V _a2109, V[] _rest2105) => {
return Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)((ToNum(s_2110) * (HW_2006 - 3D)))), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(36D)), ((V)((DD_2007 - 8D))), ((V)((Truthy(gd_2102) ? "#3e2416" : "#26282e"))), (Truthy(gd_2102) ? Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(1D))).V) : Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))), Call(box_12, V.Undef, ((V)((ToNum(s_2110) * (HW_2006 - 3D)))), ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(2D)), ((V)((DD_2007 - 4D))), (Truthy(gd_2102) ? GOLD_45 : ((V)("#3a3c44"))), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "", true));
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(8D)), ((V)((-12D))), ((V)((W_2005 - 8D))), ((V)(3D)), ((V)(3D)), (Truthy(gd_2102) ? GOLD_45 : ((V)("#26282e"))), Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("shine", ((V)((Truthy(gd_2102) ? 1D : 0D)))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(33D)), ((V)(((DD_2007 / 2D) - 3D))), ((V)((W_2005 - 6D))), ((V)(1D)), ((V)(0.6)), (Truthy(gd_2102) ? GOLD_45 : CY_2010), Call(em_40, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
if (SEqS(Get(V_2003, "gear"), "tt")) {
InvokeSpread(o_2027, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(((-HW_2006) + 16D))), ((V)(0D)), ((V)(6D)), ((V)(22D)), ((V)(16D)), ((V)(18D)), ((V)("#3a2a1e")), Call(wd_36, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Spread(Call(rep_24, V.Undef, ((V)(8D)), Fn((V _arrowThis2119, int _argc2112, V i_2118, V _a2115, V _a2116, V _a2117, V[] _rest2113) => {
return Call(slab_15, V.Undef, ((V)((((-HW_2006) + 7.6) + (ToNum(i_2118) * 2.4)))), ((V)(2D)), ((V)(6D)), ((V)(0.8)), ((V)(18D)), ((V)(15D)), GetK(Arr(((V)("#d9363b")), ((V)("#3f7fc8")), ((V)("#f2c14a")), ((V)("#2c2d31")), ((V)("#4f9a4a")), ((V)("#e3946a")), ((V)("#8f7bff")), ((V)("#f4f1ea"))), i_2118), Call(pt_38, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V));
}, 1, "", true))).V);
}
}
}
}
}
}
g_2029 = Get(V_2003, "gear");
if (SEqS(g_2029, "ctrl")) {
InvokeSpread(o_2027, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(TOP_2008)), ((V)(DZ_2014)), ((V)(76D)), ((V)(3.4)), ((V)(32D)), ((V)("#1a1b20")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).Spread(Invoke(decks_2013, "map", Fn((V _arrowThis2127, int _argc2120, V x_2126, V _a2123, V _a2124, V _a2125, V[] _rest2121) => {
return Call(cyl_13, V.Undef, x_2126, ((V)((TOP_2008 + 3.4))), ((V)((DZ_2014 + 2D))), ((V)(DR_2015)), ((V)(0.1)), ((V)("#2c2e35")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(24D))).V));
}, 1, "", true))).Add(Call(box_12, V.Undef, ((V)(((-HW_2006) + 14D))), ((V)(TOP_2008)), ((V)((-10D))), ((V)(18D)), ((V)(7D)), ((V)(14D)), ((V)("#9aa3a8")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Add(Call(slab_15, V.Undef, ((V)(((-HW_2006) + 14D))), ((V)((TOP_2008 + 7D))), ((V)((-16.6))), ((V)(22D)), ((V)(13D)), ((V)(0.8)), ((V)("#2a2c33")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).V);
} else {
if (SEqS(g_2029, "tt")) {
Invoke(decks_2013, "forEach", Fn((V _arrowThis2135, int _argc2128, V x_2134, V _a2131, V _a2132, V _a2133, V[] _rest2129) => {
return Invoke(o_2027, "push", Call(box_12, V.Undef, x_2134, ((V)(TOP_2008)), ((V)(DZ_2014)), ((V)(36D)), ((V)(5D)), ((V)(32D)), ((V)("#2a2b30")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(cyl_13, V.Undef, ((V)((ToNum(x_2134) - 2D))), ((V)((TOP_2008 + 5D))), ((V)((DZ_2014 + 1D))), ((V)(13D)), ((V)(1.6)), ((V)("#c9cdd2")), Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(26D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, Add(x_2134, ((V)(13D))), ((V)((TOP_2008 + 5D))), ((V)((DZ_2014 - 10D))), ((V)(2D)), ((V)(2D)), CH_44, Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(box_12, V.Undef, Add(x_2134, ((V)(14D))), ((V)((TOP_2008 + 5D))), ((V)((DZ_2014 + 9D))), ((V)(2D)), ((V)(1D)), ((V)(7D)), ((V)("#5a5f6a")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(TOP_2008)), ((V)(DZ_2014)), ((V)(24D)), ((V)(6D)), ((V)(30D)), ((V)("#1d1e22")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)));
} else {
if ((SEqS(g_2029, "cdj") || SEqS(g_2029, "cdj4"))) {
Invoke(decks_2013, "forEach", Fn((V _arrowThis2143, int _argc2136, V x_2142, V _a2139, V _a2140, V _a2141, V[] _rest2137) => {
return Invoke(o_2027, "push", Call(box_12, V.Undef, x_2142, ((V)(TOP_2008)), ((V)(DZ_2014)), ((V)((SEqS(g_2029, "cdj4") ? 26D : 30D))), ((V)(6D)), ((V)(36D)), ((V)("#1f2026")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(cyl_13, V.Undef, x_2142, ((V)((TOP_2008 + 6D))), ((V)((DZ_2014 + 3D))), ((V)(DR_2015)), ((V)(0.8)), ((V)("#3a3c44")), Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(26D))).Put("shine", ((V)(1D))).V)), Call(slab_15, V.Undef, x_2142, ((V)((TOP_2008 + 6D))), ((V)((DZ_2014 - 13D))), ((V)((SEqS(g_2029, "cdj4") ? 18D : 22D))), ((V)(6D)), ((V)(1D)), ((V)("#0b0c10")), NewObj(1).Put("r", ((V)(0.8))).V));
}, 1, "", true));
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(TOP_2008)), ((V)(DZ_2014)), ((V)((SEqS(g_2029, "cdj4") ? 30D : 24D))), ((V)(7D)), ((V)(36D)), ((V)("#1a1b20")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)));
if (SEqS(g_2029, "cdj4")) {
Call(rep_24, V.Undef, ((V)(4D)), Fn((V _arrowThis2151, int _argc2144, V i_2150, V _a2147, V _a2148, V _a2149, V[] _rest2145) => {
return Invoke(o_2027, "push", Call(cyl_13, V.Undef, ((V)(((-9D) + (ToNum(i_2150) * 6D)))), ((V)((TOP_2008 + 7D))), ((V)((DZ_2014 - 4D))), ((V)(2.4)), ((V)(2.6)), GOLD_45, Call(mt_35, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
}
if (SEqS(Get(V_2003, "body"), "truss")) {
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(((-HW_2006) + 10D))), ((V)(TOP_2008)), ((V)((-14D))), ((V)(14D)), ((V)(6D)), ((V)(12D)), ((V)("#9aa3a8")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slab_15, V.Undef, ((V)(((-HW_2006) + 10D))), ((V)((TOP_2008 + 6D))), ((V)((-19.6))), ((V)(18D)), ((V)(11D)), ((V)(0.8)), ((V)("#2a2c33")), Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}
} else {
if (SEqS(g_2029, "holo")) {
Invoke(decks_2013, "forEach", Fn((V _arrowThis2159, int _argc2152, V x_2158, V _a2155, V _a2156, V _a2157, V[] _rest2153) => {
return Invoke(o_2027, "push", Call(box_12, V.Undef, x_2158, ((V)(TOP_2008)), ((V)(DZ_2014)), ((V)(30D)), ((V)(2.4)), ((V)(30D)), ((V)("#1a1418")), Call(cer_37, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(cyl_13, V.Undef, x_2158, ((V)((TOP_2008 + 2.4))), ((V)(DZ_2014)), ((V)(11.4)), ((V)(0.6)), CY_2010, Call(em_40, V.Undef, NewObj(2).Put("n", ((V)(26D))).Put("op", ((V)(0.6))).V)));
}, 1, "", true));
Invoke(o_2027, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(TOP_2008)), ((V)(DZ_2014)), ((V)(22D)), ((V)(3D)), ((V)(30D)), ((V)("#1a1418")), Call(cer_37, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)));
}
}
}
}
return o_2027;
return default;
}, 1, "", true));
Set(D_2017, "fx", Fn((V _arrowThis2167, int _argc2160, V c_2166, V _a2163, V _a2164, V _a2165, V[] _rest2161) => {
V p_2168 = default;
V k_2169 = default;
JsStrBuf f_2170 = null;
JsStrBuf un_2171 = null;
V bk_2172 = default;
V g_2173 = default;
double FZ_2174 = 0;
V FP_2175 = default;
V defs_2176 = default;
p_2168 = Get(c_2166, "p");
k_2169 = Get(c_2166, "k");
f_2170 = new JsStrBuf("");
un_2171 = new JsStrBuf("");
bk_2172 = ((V)(""));
g_2173 = Get(V_2003, "gear");
Invoke(decks_2013, "forEach", Fn((V _arrowThis2185, int _argc2177, V x_2183, V i_2184, V _a2181, V _a2182, V[] _rest2178) => {
V cx_2186 = default;
double cz_2187 = 0;
V M_2188 = default;
V spin_2189 = default;
JsStrBuf s_2190 = null;
cx_2186 = (SEqS(g_2173, "tt") ? ((V)((ToNum(x_2183) - 2D))) : x_2183);
cz_2187 = (DZ_2014 + (SEqS(g_2173, "tt") ? 1D : (SEqS(g_2173, "holo") ? 0D : (SEqS(g_2173, "ctrl") ? 2D : 3D))));
M_2188 = Call(planeH_30, V.Undef, p_2168, ((V)(DY_2016)), cx_2186, ((V)(cz_2187)));
spin_2189 = (Truthy(play_2004) ? Call(atL_54, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)((SEqS(g_2173, "tt") ? 1.8 : 2.4))), ((V)(((-ToNum(i_2184)) * 0.3)))) : ((V)("")));
s_2190 = new JsStrBuf("");
if (SEqS(g_2173, "tt")) {
s_2190.Set(JsStrBuf.Begin().S("<circle r=\"").N(DR_2015).S("\" fill=\"#0d0d10\"/>").V(Invoke(Call(rep_24, V.Undef, ((V)(5D)), Fn((V _arrowThis2198, int _argc2191, V j_2197, V _a2194, V _a2195, V _a2196, V[] _rest2192) => {
return ((V)(JsStrBuf.Begin().S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)(((DR_2015 - 1.6) - (ToNum(j_2197) * 1.4)))))).S("\" fill=\"none\" stroke=\"#2c2c32\" stroke-width=\"0.35\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<g>").V(spin_2189).S("<circle r=\"4.2\" fill=\"").V(GetIdx(Arr(((V)("#d9363b")), ((V)("#3f7fc8")), ((V)("#f2c14a")), ((V)("#4f9a4a"))), (ToNum(i_2184) % 4D))).S("\"/><path d=\"M0 -4.2V-").N(DR_2015).S("\" stroke=\"#ffffff\" stroke-width=\"0.5\" opacity=\"0.5\"/><path d=\"M-1.6 -2.2h3.2\" stroke=\"#ffffff\" stroke-width=\"0.5\"/></g><circle r=\"0.6\" fill=\"#d5dde2\"/><path d=\"M").V(Call(f1_23, V.Undef, ((V)(((-DR_2015) * 0.7))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-DR_2015) * 0.45))))).S("A").N(DR_2015).S(" ").N(DR_2015).S(" 0 0 1 ").V(Call(f1_23, V.Undef, ((V)((DR_2015 * 0.2))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-DR_2015) * 0.95))))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.25\"/>").End());
} else {
if (SEqS(g_2173, "holo")) {
s_2190.Set(JsStrBuf.Begin().S("<g>").V((Truthy(play_2004) ? Call(atL_54, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(1.6)), ((V)(((-ToNum(i_2184)) * 0.4)))) : Call(atL_54, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(8D))))).S("<circle r=\"").N(DR_2015).S("\" fill=\"none\" stroke=\"").V(CY_2010).S("\" stroke-width=\"0.8\" stroke-dasharray=\"3 1.4\" opacity=\"0.9\"/><circle r=\"").N((DR_2015 - 3D)).S("\" fill=\"none\" stroke=\"").V(MG_2011).S("\" stroke-width=\"0.5\" stroke-dasharray=\"1 1.6\"/></g><circle r=\"3\" fill=\"").V(CY_2010).S("\" opacity=\"0.5\"/>").End());
} else {
s_2190.Set(JsStrBuf.Begin().S("<circle r=\"").N(DR_2015).S("\" fill=\"url(#djJ)\"/><circle r=\"").V(Call(f1_23, V.Undef, ((V)((DR_2015 - 2.2))))).S("\" fill=\"#202228\" stroke=\"#4a4d58\" stroke-width=\"0.3\"/><circle r=\"").V(Call(f1_23, V.Undef, ((V)((DR_2015 * 0.42))))).S("\" fill=\"#0b0c10\" stroke=\"").V((Truthy(play_2004) ? CY_2010 : ((V)("#3a3c44")))).S("\" stroke-width=\"0.5\"/><g>").V(spin_2189).S("<path d=\"M0 ").V(Call(f1_23, V.Undef, ((V)(((-DR_2015) * 0.42))))).S("V").V(Call(f1_23, V.Undef, ((V)(((-DR_2015) * 0.2))))).S("\" stroke=\"").V((Truthy(play_2004) ? CY_2010 : ((V)("#6a6f78")))).S("\" stroke-width=\"0.7\"/><circle cx=\"0\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-DR_2015) + 1.1))))).S("\" r=\"0.5\" fill=\"#9aa3a8\"/></g>").End());
}
}
f_2170.S("<g transform=\"").V(M_2188).S("\">").S(s_2190.Str).S("</g>");
if (SEqS(g_2173, "tt")) {
V pv_2199 = default;
V tip_2200 = default;
pv_2199 = Call(p_2168, V.Undef, Add(x_2183, ((V)(13D))), ((V)((TOP_2008 + 7D))), ((V)((DZ_2014 - 10D))));
tip_2200 = Call(p_2168, V.Undef, ((V)(((ToNum(x_2183) - 2D) + (DR_2015 * 0.55)))), ((V)((DY_2016 + 0.6))), ((V)(((DZ_2014 + 1D) + (DR_2015 * 0.25)))));
f_2170.S("<path d=\"M").V(Call(P2_27, V.Undef, pv_2199)).S("L").V(Call(P2_27, V.Undef, tip_2200)).S("\" stroke=\"#d5dde2\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.7 * ToNum(k_2169)))))).S("\" stroke-linecap=\"round\"/><rect x=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(tip_2200, 0D)) - (1.2 * ToNum(k_2169))))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(tip_2200, 1D)) - (0.8 * ToNum(k_2169))))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(k_2169)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((1.4 * ToNum(k_2169)))))).S("\" fill=\"#2a2b30\"/>");
}
if ((SEqS(g_2173, "cdj") || SEqS(g_2173, "cdj4"))) {
V sc_2201 = default;
sc_2201 = Call(surf_55, V.Undef, p_2168, Arr(((V)((ToNum(x_2183) - 9D))), ((V)((TOP_2008 + 12D))), ((V)((DZ_2014 - 12.4)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
f_2170.S("<g transform=\"").V(sc_2201).S("\"><rect x=\"0.6\" y=\"0.6\" width=\"16.8\" height=\"4.8\" rx=\"0.5\" fill=\"#0a1830\"/><path d=\"M1.4 3H16.6\" stroke=\"#ff9d3c\" stroke-width=\"0.4\"/><path d=\"").V(Call(polyD_63, V.Undef, Call(rep_24, V.Undef, ((V)(16D)), Fn((V _arrowThis2209, int _argc2202, V j_2208, V _a2205, V _a2206, V _a2207, V[] _rest2203) => {
return Arr(Add(((V)(1.4)), j_2208), ((V)((3D + (FdLibm.Sin(ToNum(Add(((V)((ToNum(j_2208) * 1.7))), i_2184))) * 1.4)))));
}, 1, "", true)))).S("\" fill=\"none\" stroke=\"#6ac8ff\" stroke-width=\"0.35\"/>").S((Truthy(play_2004) ? JsStrBuf.Begin().S("<rect x=\"1.4\" y=\"1\" width=\"0.4\" height=\"4\" fill=\"#ffffff\">").V(Call(an_31, V.Undef, ((V)("x")), ((V)("1.4;16.4")), ((V)(2.4)), ((V)(((-ToNum(i_2184)) * 0.6))))).S("</rect>").End() : "")).S("</g>");
}
return default;
}, 2, "", true));
{
double mw_2210 = 0;
double my_2211 = 0;
V M_2212 = default;
JsStrBuf s_2213 = null;
double nch_2214 = 0;
mw_2210 = (SEqS(g_2173, "cdj4") ? 30D : (SEqS(g_2173, "tt") ? 24D : (SEqS(g_2173, "ctrl") ? 24D : 22D)));
my_2211 = ((TOP_2008 + (SEqS(g_2173, "tt") ? 6D : (SEqS(g_2173, "ctrl") ? 3.4 : (SEqS(g_2173, "holo") ? 3D : 7D)))) + 0.1);
M_2212 = Call(planeH_30, V.Undef, p_2168, ((V)(my_2211)), ((V)(0D)), ((V)(DZ_2014)));
s_2213 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((((-mw_2210) / 2D) + 1.4))))).S("\" y=\"-13\" width=\"").V(Call(f1_23, V.Undef, ((V)((mw_2210 - 2.8))))).S("\" height=\"26\" rx=\"1\" fill=\"").S((SEqS(g_2173, "holo") ? "#0a1a24" : "#111216")).S("\" opacity=\"0.9\"/>").End());
nch_2214 = (SEqS(g_2173, "cdj4") ? 4D : 2D);
Call(rep_24, V.Undef, ((V)(nch_2214)), Fn((V _arrowThis2222, int _argc2215, V i_2221, V _a2218, V _a2219, V _a2220, V[] _rest2216) => {
double x_2223 = 0;
x_2223 = ((((-mw_2210) / 2D) + 4D) + ((ToNum(i_2221) * (mw_2210 - 8D)) / Max(1D, (nch_2214 - 1D))));
s_2213.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)(x_2223)))).S(" -2V7\" stroke=\"#000000\" stroke-width=\"1\"/><rect x=\"").V(Call(f1_23, V.Undef, ((V)((x_2223 - 1.4))))).S("\" y=\"").N((Truthy(play_2004) ? 0D : 3D)).S("\" width=\"2.8\" height=\"1.4\" rx=\"0.3\" fill=\"#e8eaee\">").V((Truthy(play_2004) ? Call(an_31, V.Undef, ((V)("y")), ((V)("0;4;1;3;0")), ((V)(1.8)), ((V)(((-ToNum(i_2221)) * 0.4)))) : ((V)("")))).S("</rect>").V(Invoke(Call(rep_24, V.Undef, ((V)(3D)), Fn((V _arrowThis2231, int _argc2224, V j_2230, V _a2227, V _a2228, V _a2229, V[] _rest2225) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)(x_2223)))).S("\" cy=\"").N(((-11D) + (ToNum(j_2230) * 3D))).S("\" r=\"1.1\" fill=\"").V((SEqS(g_2173, "cdj4") ? GOLD_45 : ((V)("#3a3c44")))).S("\" stroke=\"#9aa3a8\" stroke-width=\"0.2\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Call(rep_24, V.Undef, ((V)(6D)), Fn((V _arrowThis2239, int _argc2232, V j_2238, V _a2235, V _a2236, V _a2237, V[] _rest2233) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((x_2223 + 2.1))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((6D - (ToNum(j_2238) * 1.3)))))).S("\" width=\"1\" height=\"0.9\" fill=\"").S((GtN(j_2238, 4D) ? "#ff3b3b" : (GtN(j_2238, 3D) ? "#ffd84f" : "#4fdc6a"))).S("\" opacity=\"0.25\">").V((Truthy(play_2004) ? Call(anD_52, V.Undef, ((V)("opacity")), Invoke(Call(rep_24, V.Undef, ((V)(5D)), Fn((V _arrowThis2247, int _argc2240, V t_2246, V _a2243, V _a2244, V _a2245, V[] _rest2241) => {
return ((V)((Ge(((V)(((((ToNum(t_2246) * 7D) + (ToNum(j_2238) * 3D)) + (ToNum(i_2221) * 5D)) % 6D))), j_2238) ? 1D : 0.2)));
}, 1, "", true)), "join", ((V)(";"))), ((V)(0.5)), ((V)(((-ToNum(i_2221)) * 0.13)))) : ((V)("")))).S("</rect>").End()));
}, 1, "", true)), "join", ((V)(""))));
return default;
}, 1, "", true));
s_2213.S("<path d=\"M-6 10.6H6\" stroke=\"#000000\" stroke-width=\"1.2\"/><g transform=\"translate(0 10.6)\"><rect x=\"-1\" y=\"-1.3\" width=\"2\" height=\"2.6\" rx=\"0.3\" fill=\"#e8eaee\">").V((Truthy(play_2004) ? Call(an_31, V.Undef, ((V)("x")), ((V)("-1;-6;3;-5;4;-1")), ((V)(1.2))) : ((V)("")))).S("</rect></g>");
f_2170.S("<g transform=\"").V(M_2212).S("\">").S(s_2213.Str).S("</g>");
}
if ((SEqS(g_2173, "ctrl") || (SEqS(g_2173, "cdj") && SEqS(Get(V_2003, "body"), "truss")))) {
double lx_2248 = 0;
double ly_2249 = 0;
double lz_2250 = 0;
V sc_2251 = default;
lx_2248 = ((-HW_2006) + (SEqS(g_2173, "ctrl") ? 14D : 10D));
ly_2249 = (TOP_2008 + (SEqS(g_2173, "ctrl") ? 7D : 6D));
lz_2250 = (SEqS(g_2173, "ctrl") ? (-16.1) : (-19.1));
sc_2251 = Call(surf_55, V.Undef, p_2168, Arr(((V)((lx_2248 - 9.5))), ((V)((ly_2249 + 11.6))), ((V)(lz_2250))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))));
f_2170.S("<g transform=\"").V(sc_2251).S("\"><rect x=\"0.6\" y=\"0.6\" width=\"17.8\" height=\"10\" rx=\"0.5\" fill=\"#0b1426\"/>").V(Invoke(Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis2259, int _argc2252, V j_2258, V _a2255, V _a2256, V _a2257, V[] _rest2253) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(Call(polyD_63, V.Undef, Call(rep_24, V.Undef, ((V)(17D)), Fn((V _arrowThis2267, int _argc2260, V t_2266, V _a2263, V _a2264, V _a2265, V[] _rest2261) => {
return Arr(Add(((V)(1.2)), t_2266), ((V)(((3.4 + (ToNum(j_2258) * 4D)) + (FdLibm.Sin(((ToNum(t_2266) * 1.3) + (ToNum(j_2258) * 2D))) * 1.2)))));
}, 1, "", true)))).S("\" fill=\"none\" stroke=\"").V((Truthy(j_2258) ? MG_2011 : CY_2010)).S("\" stroke-width=\"0.35\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S((Truthy(play_2004) ? JsStrBuf.Begin().S("<rect x=\"9\" y=\"1\" width=\"0.3\" height=\"9.4\" fill=\"#ffffff\">").V(Call(an_31, V.Undef, ((V)("x")), ((V)("2;16")), ((V)(2D)))).S("</rect>").End() : "")).S("</g>");
}
FZ_2174 = (SEqS(Get(V_2003, "body"), "table") ? ((DD_2007 / 2D) + 1D) : (SEqS(Get(V_2003, "body"), "truss") ? ((DD_2007 / 2D) + 0.9) : (SEqS(Get(V_2003, "body"), "altar") ? ((DD_2007 / 2D) + 1.1) : ((DD_2007 / 2D) + 0.25))));
FP_2175 = Fn((V _arrowThis2276, int _argc2268, V y_2274, V x0_2275, V _a2272, V _a2273, V[] _rest2269) => {
return Call(plane_29, V.Undef, p_2168, ((V)(FZ_2174)), y_2274, x0_2275);
}, 2, "", true);
if (SEqS(Get(V_2003, "body"), "table")) {
JsStrBuf s_2277 = null;
s_2277 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"M0 0H").N((W_2005 - 6D)).S("V30H0Z\" fill=\"url(#djSh)\"/>").V(Invoke(Call(rep_24, V.Undef, ((V)(6D)), Fn((V _arrowThis2285, int _argc2278, V i_2284, V _a2281, V _a2282, V _a2283, V[] _rest2279) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N((10D + (ToNum(i_2284) * 19D))).S(" 0Q").N((13D + (ToNum(i_2284) * 19D))).S(" 15 ").N((9D + (ToNum(i_2284) * 19D))).S(" 30\" stroke=\"#c9bfa8\" stroke-width=\"0.6\" fill=\"none\" opacity=\"0.6\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).End());
s_2277.S("<text x=\"").N(((W_2005 / 2D) - 3D)).S("\" y=\"19\" text-anchor=\"middle\" font-family=\"Comic Sans MS, Marker Felt, cursive\" font-weight=\"700\" font-size=\"12\" fill=\"#1d1d22\" transform=\"rotate(-3 ").N((W_2005 / 2D)).S(" 16)\">DJ SQUISH</text>").V(Invoke(Call(rep_24, V.Undef, ((V)(5D)), Fn((V _arrowThis2293, int _argc2286, V i_2292, V _a2289, V _a2290, V _a2291, V[] _rest2287) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N((34D + (ToNum(i_2292) * 13D))).S(" ").N((20D + (ToNum(i_2292) % 2D))).S("v").N((3D + (ToNum(i_2292) % 3D))).S("\" stroke=\"#1d1d22\" stroke-width=\"0.7\" stroke-linecap=\"round\"/>").End()));
}, 1, "", true)), "join", ((V)(""))));
s_2277.S("<path d=\"M92 0L95 6L91 11L96 17L93 24\" fill=\"none\" stroke=\"#8a7f68\" stroke-width=\"0.9\"/><path d=\"M92.5 0L95 6L91 11L96 17L93 24L94.6 23L97.4 16.6L92.6 11L96.6 6L94 0Z\" fill=\"#2a2620\" opacity=\"0.6\"/>");
s_2277.S("<rect x=\"-2\" y=\"-1\" width=\"10\" height=\"4\" fill=\"#b9bdc4\" opacity=\"0.92\" transform=\"rotate(-12 3 1)\"/><rect x=\"").N((W_2005 - 14D)).S("\" y=\"-1\" width=\"10\" height=\"4\" fill=\"#b9bdc4\" opacity=\"0.92\" transform=\"rotate(10 ").N((W_2005 - 9D)).S(" 1)\"/><path d=\"M14 8l1 2 2 0.2-1.6 1.4 0.6 2-2-1-1.8 1 0.4-2-1.4-1.4 2-0.2z\" fill=\"#f2c14a\"/>");
f_2170.S("<g transform=\"").V(Call(FP_2175, V.Undef, ((V)(36D)), ((V)(((-HW_2006) + 3D))))).S("\">").S(s_2277.Str).S("</g>");
} else {
if (SEqS(Get(V_2003, "body"), "ply")) {
JsStrBuf s_2294 = null;
s_2294 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"").N(W_2005).S("\" height=\"38\" fill=\"url(#djPly)\"/>").V(Invoke(Call(rep_24, V.Undef, ((V)(7D)), Fn((V _arrowThis2302, int _argc2295, V i_2301, V _a2298, V _a2299, V _a2300, V[] _rest2296) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 ").N((4D + (ToNum(i_2301) * 5D))).S("Q").N((W_2005 / 2D)).S(" ").N(((3D + (ToNum(i_2301) * 5D)) + (NumTruthy((ToNum(i_2301) % 2D)) ? 1.5 : (-1D)))).S(" ").N(W_2005).S(" ").N((5D + (ToNum(i_2301) * 5D))).S("\" stroke=\"#b8925e\" stroke-width=\"0.4\" fill=\"none\" opacity=\"0.6\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).End());
{
V BB_2303 = default;
double cx0_2304 = 0;
double cy0_2305 = 0;
BB_2303 = Arr(Arr(((V)((-16D))), ((V)(0D)), ((V)(7.4))), Arr(((V)((-6D))), ((V)((-3D))), ((V)(8.6))), Arr(((V)(5D)), ((V)((-1D))), ((V)(8D))), Arr(((V)(15D)), ((V)(1D)), ((V)(7D))), Arr(((V)((-10D))), ((V)(6D)), ((V)(6D))), Arr(((V)(9D)), ((V)(6D)), ((V)(6.4))), Arr(((V)(22D)), ((V)(4D)), ((V)(5D))));
cx0_2304 = (W_2005 / 2D);
cy0_2305 = 19D;
s_2294.S("<g transform=\"rotate(-4 ").N(cx0_2304).S(" ").N(cy0_2305).S(")\">").V(Invoke(Invoke(BB_2303, "map", Fn((V _arrowThis2319, int _argc2306, V _a2308, V _a2309, V _a2310, V _a2311, V[] _rest2307) => {
V x_2314 = default;
V y_2316 = default;
V r_2318 = default;
{ V _t2312 = ListOf(_a2308);
{ V _t2313 = GetIdx(_t2312, 0D);
x_2314 = _t2313; }
{ V _t2315 = GetIdx(_t2312, 1D);
y_2316 = _t2315; }
{ V _t2317 = GetIdx(_t2312, 2D);
r_2318 = _t2317; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Add(Add(((V)(cx0_2304)), x_2314), ((V)(1.2)))).S("\" cy=\"").V(Add(Add(((V)(cy0_2305)), y_2316), ((V)(1.4)))).S("\" r=\"").V(Add(r_2318, ((V)(1.2)))).S("\" fill=\"#1d1d22\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Invoke(BB_2303, "map", Fn((V _arrowThis2333, int _argc2320, V _a2322, V _a2323, V _a2324, V _a2325, V[] _rest2321) => {
V x_2328 = default;
V y_2330 = default;
V r_2332 = default;
{ V _t2326 = ListOf(_a2322);
{ V _t2327 = GetIdx(_t2326, 0D);
x_2328 = _t2327; }
{ V _t2329 = GetIdx(_t2326, 1D);
y_2330 = _t2329; }
{ V _t2331 = GetIdx(_t2326, 2D);
r_2332 = _t2331; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Add(((V)(cx0_2304)), x_2328)).S("\" cy=\"").V(Add(((V)(cy0_2305)), y_2330)).S("\" r=\"").V(Add(r_2332, ((V)(0.9)))).S("\" fill=\"#ffffff\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Invoke(BB_2303, "map", Fn((V _arrowThis2347, int _argc2334, V _a2336, V _a2337, V _a2338, V _a2339, V[] _rest2335) => {
V x_2342 = default;
V y_2344 = default;
V r_2346 = default;
{ V _t2340 = ListOf(_a2336);
{ V _t2341 = GetIdx(_t2340, 0D);
x_2342 = _t2341; }
{ V _t2343 = GetIdx(_t2340, 1D);
y_2344 = _t2343; }
{ V _t2345 = GetIdx(_t2340, 2D);
r_2346 = _t2345; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Add(((V)(cx0_2304)), x_2342)).S("\" cy=\"").V(Add(((V)(cy0_2305)), y_2344)).S("\" r=\"").V(r_2346).S("\" fill=\"url(#djGr)\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Invoke(BB_2303, "map", Fn((V _arrowThis2361, int _argc2348, V _a2350, V _a2351, V _a2352, V _a2353, V[] _rest2349) => {
V x_2356 = default;
V y_2358 = default;
V r_2360 = default;
{ V _t2354 = ListOf(_a2350);
{ V _t2355 = GetIdx(_t2354, 0D);
x_2356 = _t2355; }
{ V _t2357 = GetIdx(_t2354, 1D);
y_2358 = _t2357; }
{ V _t2359 = GetIdx(_t2354, 2D);
r_2360 = _t2359; }
}
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(Add(((V)(cx0_2304)), x_2356)) - (ToNum(r_2360) * 0.55)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(Add(((V)(cy0_2305)), y_2358)) - (ToNum(r_2360) * 0.2)))))).S("q").V(Call(f1_23, V.Undef, ((V)((ToNum(r_2360) * 0.2))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-ToNum(r_2360)) * 0.5))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(r_2360) * 0.6))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-ToNum(r_2360)) * 0.55))))).S("\" stroke=\"#ffffff\" stroke-width=\"0.9\" fill=\"none\" stroke-linecap=\"round\" opacity=\"0.85\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M").N((cx0_2304 - 26D)).S(" ").N((cy0_2305 - 2D)).S("l-5 -3m5 6l-6 1\" stroke=\"#1d1d22\" stroke-width=\"1\" stroke-linecap=\"round\"/><path d=\"M").N((cx0_2304 + 28D)).S(" ").N((cy0_2305 - 6D)).S("l5 -4m-4 8l6 -1\" stroke=\"#1d1d22\" stroke-width=\"1\" stroke-linecap=\"round\"/></g>");
}
Invoke(Arr(Arr(((V)(3D)), ((V)(3D))), Arr(((V)((W_2005 - 3D))), ((V)(3D))), Arr(((V)(3D)), ((V)(35D))), Arr(((V)((W_2005 - 3D))), ((V)(35D))), Arr(((V)((W_2005 / 2D))), ((V)(3D))), Arr(((V)((W_2005 / 2D))), ((V)(35D)))), "forEach", Fn((V _arrowThis2373, int _argc2362, V _a2364, V _a2365, V _a2366, V _a2367, V[] _rest2363) => {
V x_2370 = default;
V y_2372 = default;
{ V _t2368 = ListOf(_a2364);
{ V _t2369 = GetIdx(_t2368, 0D);
x_2370 = _t2369; }
{ V _t2371 = GetIdx(_t2368, 1D);
y_2372 = _t2371; }
}
return ((V)(s_2294.S("<circle cx=\"").V(x_2370).S("\" cy=\"").V(y_2372).S("\" r=\"0.8\" fill=\"#8a8f96\" stroke=\"#4a4d52\" stroke-width=\"0.25\"/><path d=\"M").N((ToNum(x_2370) - 0.5)).S(" ").V(y_2372).S("h1\" stroke=\"#4a4d52\" stroke-width=\"0.25\"/>").Str));
}, 1, "", true));
s_2294.S("<rect x=\"22\" y=\"4\" width=\"9\" height=\"6\" rx=\"0.6\" fill=\"#f4f1ea\" transform=\"rotate(8 26 7)\"/><circle cx=\"26.4\" cy=\"7\" r=\"1.8\" fill=\"#d9363b\" transform=\"rotate(8 26 7)\"/><rect x=\"").N((W_2005 - 44D)).S("\" y=\"28\" width=\"8\" height=\"8\" rx=\"4\" fill=\"#ffd84f\" opacity=\"0.9\"/><path d=\"M").N((W_2005 - 42D)).S(" 32.6q2 1.6 4 0\" stroke=\"#1d1d22\" stroke-width=\"0.5\" fill=\"none\"/>");
Call(rep_24, V.Undef, ((V)(14D)), Fn((V _arrowThis2381, int _argc2374, V i_2380, V _a2377, V _a2378, V _a2379, V[] _rest2375) => {
V R3_2382 = default;
R3_2382 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("ply").V(i_2380).End())));
s_2294.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(Call(R3_2382, V.Undef)) * W_2005))))).S(" ").V(Call(f1_23, V.Undef, ((V)((32D + (ToNum(Call(R3_2382, V.Undef)) * 6D)))))).S("l").V(Call(f1_23, V.Undef, ((V)((2D + (ToNum(Call(R3_2382, V.Undef)) * 6D)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((ToNum(Call(R3_2382, V.Undef)) - 0.5) * 1.4))))).S("\" stroke=\"#3a2a1a\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.3 + (ToNum(Call(R3_2382, V.Undef)) * 0.5)))))).S("\" opacity=\"0.35\"/>");
return default;
}, 1, "", true));
s_2294.V(Invoke(Call(rep_24, V.Undef, ((V)(9D)), Fn((V _arrowThis2390, int _argc2383, V i_2389, V _a2386, V _a2387, V _a2388, V[] _rest2384) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N((((W_2005 / 2D) - 22D) + (ToNum(i_2389) * 5.5))).S(" ").N((26D + (ToNum(i_2389) % 3D))).S("v").N((3D + ((ToNum(i_2389) * 7D) % 5D))).S("\" stroke=\"").V(GetIdx(Arr(((V)("#ff4fb8")), ((V)("#3ff0ff")), ((V)("#ffd84f"))), (ToNum(i_2389) % 3D))).S("\" stroke-width=\"0.9\" stroke-linecap=\"round\"/>").End()));
}, 1, "", true)), "join", ((V)(""))));
s_2294.S("<path d=\"M8 30q6-14 14-6t12-8\" fill=\"none\" stroke=\"#3ff0ff\" stroke-width=\"2.2\" stroke-linecap=\"round\"/><path d=\"M").N((W_2005 - 30D)).S(" 10l4 8 8 1-6 5 2 8-8-4-7 4 2-8-6-5 8-1z\" fill=\"#ffd84f\" stroke=\"#1d1d22\" stroke-width=\"0.6\"/><path d=\"M").N((W_2005 - 14D)).S(" 30c-3-6 3-10 0-16\" stroke=\"#ff4fb8\" stroke-width=\"1.8\" fill=\"none\" stroke-linecap=\"round\"/><circle cx=\"14\" cy=\"10\" r=\"3\" fill=\"#7dff6a\" opacity=\"0.85\"/>");
Call(rep_24, V.Undef, ((V)(30D)), Fn((V _arrowThis2398, int _argc2391, V i_2397, V _a2394, V _a2395, V _a2396, V[] _rest2392) => {
V R2_2399 = default;
R2_2399 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("spr").V(i_2397).End())));
s_2294.S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(Call(R2_2399, V.Undef)) * W_2005))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(Call(R2_2399, V.Undef)) * 36D))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.2 + (ToNum(Call(R2_2399, V.Undef)) * 0.4)))))).S("\" fill=\"").V(GetIdx(Arr(((V)("#ff4fb8")), ((V)("#3ff0ff")), ((V)("#1d1d22"))), (ToNum(i_2397) % 3D))).S("\" opacity=\"0.7\"/>");
return default;
}, 1, "", true));
f_2170.S("<g transform=\"").V(Call(FP_2175, V.Undef, ((V)(38D)), ((V)((-HW_2006))))).S("\">").S(s_2294.Str).S("</g>");
} else {
if (SEqS(Get(V_2003, "body"), "truss")) {
V s_2400 = default;
s_2400 = ((V)(JsStrBuf.Begin().S("<rect width=\"").N((W_2005 - 4D)).S("\" height=\"32\" rx=\"1\" fill=\"url(#djAc)\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)((Truthy(play_2004) ? "1;0.6;1" : "0.7;0.85;0.7"))), ((V)((Truthy(play_2004) ? 0.9 : 3D))))).S("</rect><text x=\"").N(((W_2005 / 2D) - 2D)).S("\" y=\"20\" text-anchor=\"middle\" font-family=\"Arial Black, Arial, sans-serif\" font-weight=\"900\" font-size=\"9\" fill=\"none\" stroke=\"#e8fdff\" stroke-width=\"0.5\" opacity=\"0.8\" letter-spacing=\"2\">SQUISH</text><rect width=\"").N((W_2005 - 4D)).S("\" height=\"32\" rx=\"1\" fill=\"none\" stroke=\"").V(CY_2010).S("\" stroke-width=\"0.8\" opacity=\"0.9\"/>").End()));
f_2170.S("<g transform=\"").V(Call(FP_2175, V.Undef, ((V)(34D)), ((V)(((-HW_2006) + 2D))))).S("\">").V(s_2400).S("</g>");
} else {
if (SEqS(Get(V_2003, "body"), "altar")) {
V R2_2401 = default;
double cols_2402 = 0;
double rows_2403 = 0;
double cw_2404 = 0;
double rh_2405 = 0;
JsStrBuf s_2406 = null;
R2_2401 = Call(rng_25, V.Undef, ((V)("alt")));
cols_2402 = 9D;
rows_2403 = 3D;
cw_2404 = (W_2005 / cols_2402);
rh_2405 = 12D;
s_2406 = new JsStrBuf("");
{
double r_2407 = 0;
r_2407 = 0D;
while (true) {
if (!((r_2407 < rows_2403))) break;
{
double i_2409 = 0;
i_2409 = 0D;
while (true) {
if (!((i_2409 < cols_2402))) break;
double x_2411 = 0;
double y_2412 = 0;
double j_2413 = 0;
V tri_2414 = default;
V tri2_2415 = default;
V mirror_2416 = default;
x_2411 = (i_2409 * cw_2404);
y_2412 = ((r_2407 * rh_2405) + ((r_2407 == 2D) ? 0D : 0D));
j_2413 = ((ToNum(Call(R2_2401, V.Undef)) - 0.5) * 3D);
tri_2414 = Arr(Arr(((V)(x_2411)), ((V)(y_2412))), Arr(((V)((x_2411 + cw_2404))), ((V)((y_2412 + (j_2413 * 0.5))))), Arr(((V)(((x_2411 + (cw_2404 * 0.5)) + j_2413))), ((V)((y_2412 + rh_2405)))));
tri2_2415 = Arr(Arr(((V)((x_2411 + cw_2404))), ((V)((y_2412 + (j_2413 * 0.5))))), Arr(((V)(((x_2411 + (cw_2404 * 1.5)) + j_2413))), ((V)((y_2412 + rh_2405)))), Arr(((V)(((x_2411 + (cw_2404 * 0.5)) + j_2413))), ((V)((y_2412 + rh_2405)))));
mirror_2416 = (LtN(Call(R2_2401, V.Undef), 0.3) ? V.True : V.False);
s_2406.S("<path d=\"").V(Call(polyD_63, V.Undef, tri_2414)).S("Z\" fill=\"").V((Truthy(mirror_2416) ? ((V)("url(#djMi)")) : Call(mix_22, V.Undef, OB_48, ((V)("#3a3026")), ((V)((ToNum(Call(R2_2401, V.Undef)) * 0.6)))))).S("\" stroke=\"#8a6c3a\" stroke-width=\"0.3\"/>").S(((i_2409 < (cols_2402 - 1D)) ? JsStrBuf.Begin().S("<path d=\"").V(Call(polyD_63, V.Undef, tri2_2415)).S("Z\" fill=\"").V(Call(mix_22, V.Undef, OB_48, ((V)("#2e261e")), Call(R2_2401, V.Undef))).S("\" stroke=\"#8a6c3a\" stroke-width=\"0.3\"/>").End() : ""));
if (Truthy(mirror_2416)) {
s_2406.S("<path d=\"").V(Call(polyD_63, V.Undef, tri_2414)).S("Z\" fill=\"#ffffff\" opacity=\"0\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0;0.6;0")), ((V)(2.6)), ((V)(((-ToNum(Call(R2_2401, V.Undef))) * 2.6))))).S("</path>");
}
i_2409++;
}
}
r_2407++;
}
}
s_2406.S("<path d=\"M0 6L").N(W_2005).S(" 30M0 30L").N(W_2005).S(" 4\" stroke=\"").S((Truthy(play_2004) ? "#ffd28a" : "#b8945a")).S("\" stroke-width=\"0.6\" stroke-dasharray=\"6 60\" fill=\"none\">").V(Call(an_31, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-132")), ((V)((Truthy(play_2004) ? 1.4 : 4D))))).S("</path>");
f_2170.S("<g transform=\"").V(Call(FP_2175, V.Undef, ((V)(37D)), ((V)((-HW_2006))))).S("\"><g clip-path=\"url(#djAlt)\">").S(s_2406.Str).S("</g></g>");
} else {
if (SEqS(Get(V_2003, "body"), "cyber")) {
V hc_2417 = default;
V fl_2418 = default;
hc_2417 = Call(p_2168, V.Undef, ((V)(0D)), ((V)((TOP_2008 + 1D))), ((V)(0D)));
f_2170.S("<g opacity=\"0.85\"><ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(hc_2417, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(hc_2417, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)(((HW_2006 + 14D) * ToNum(k_2169)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((((HW_2006 + 14D) * ToNum(k_2169)) * ToNum(SA_42)) * 0.62))))).S("\" fill=\"none\" stroke=\"").V(CY_2010).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(k_2169)))))).S("\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((5D * ToNum(k_2169)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((3D * ToNum(k_2169)))))).S("\">").V(Call(an_31, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;").V(Call(f1_23, V.Undef, ((V)(((-32D) * ToNum(k_2169)))))).End())), ((V)((Truthy(play_2004) ? 0.8 : 3D))))).S("</ellipse><ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(hc_2417, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(hc_2417, 1D)) - (8D * ToNum(k_2169))))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)(((HW_2006 + 8D) * ToNum(k_2169)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((((HW_2006 + 8D) * ToNum(k_2169)) * ToNum(SA_42)) * 0.62))))).S("\" fill=\"none\" stroke=\"").V(MG_2011).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.4 * ToNum(k_2169)))))).S("\" opacity=\"0.6\"/></g>");
fl_2418 = Call(p_2168, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(0D)));
un_2171.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(fl_2418, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(fl_2418, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)(((HW_2006 * 1.1) * ToNum(k_2169)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((((HW_2006 * 1.1) * ToNum(k_2169)) * ToNum(SA_42)) * 0.6))))).S("\" fill=\"").V(CY_2010).S("\" opacity=\"0.35\" filter=\"url(#djB)\"/>");
}
}
}
}
}
if (Truthy(play_2004)) {
double n_2419 = 0;
double ew_2420 = 0;
double x0_2421 = 0;
double bw_2422 = 0;
double ey_2423 = 0;
double eh_2424 = 0;
double yb_2425 = 0;
JsStrBuf s_2426 = null;
n_2419 = 22D;
ew_2420 = (W_2005 * 0.62);
x0_2421 = ((-ew_2420) / 2D);
bw_2422 = (ew_2420 / n_2419);
ey_2423 = (SEqS(Get(V_2003, "body"), "table") ? 3D : (SEqS(Get(V_2003, "body"), "ply") ? 3.2 : (SEqS(Get(V_2003, "body"), "altar") ? 3D : 4D)));
eh_2424 = (SEqS(Get(V_2003, "body"), "truss") ? 12D : 8D);
yb_2425 = (((TOP_2008 - ey_2423) - 1D) - eh_2424);
s_2426 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((x0_2421 - 1.2))))).S("\" y=\"0\" width=\"").V(Call(f1_23, V.Undef, ((V)((ew_2420 + 2.4))))).S("\" height=\"").N((eh_2424 + 2D)).S("\" rx=\"1\" fill=\"#08090c\" opacity=\"0.88\"/>").End());
Call(rep_24, V.Undef, ((V)(n_2419)), Fn((V _arrowThis2434, int _argc2427, V i_2433, V _a2430, V _a2431, V _a2432, V[] _rest2428) => {
V R2_2435 = default;
V hs_2436 = default;
V h0_2437 = default;
R2_2435 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("eq").V(i_2433).V(Get(S_2001, "v")).End())));
hs_2436 = Call(rep_24, V.Undef, ((V)(7D)), Fn((V _arrowThis2444, int _argc2438, V _a2440, V _a2441, V _a2442, V _a2443, V[] _rest2439) => {
return Call(f1_23, V.Undef, ((V)((1D + (ToNum(Call(R2_2435, V.Undef)) * (eh_2424 - 1D))))));
}, 0, "", true));
h0_2437 = (Truthy(play_2004) ? GetIdx(hs_2436, 0D) : ((V)("1")));
s_2426.S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)(((x0_2421 + (ToNum(i_2433) * bw_2422)) + 0.3))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)(((eh_2424 + 1D) - ToNum(h0_2437)))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((bw_2422 - 0.6))))).S("\" height=\"").V(h0_2437).S("\" fill=\"url(#").S((Truthy(LUX_2009) ? "djEqW" : "djEq")).S(")\">").V((Truthy(play_2004) ? Add(Call(an_31, V.Undef, ((V)("height")), Invoke(Invoke(hs_2436, "concat", GetIdx(hs_2436, 0D)), "join", ((V)(";"))), Call(n4_26, V.Undef, ((V)((0.7 + (ToNum(Call(R2_2435, V.Undef)) * 0.5)))))), Call(an_31, V.Undef, ((V)("y")), Invoke(Invoke(Invoke(hs_2436, "concat", GetIdx(hs_2436, 0D)), "map", Fn((V _arrowThis2452, int _argc2445, V h_2451, V _a2448, V _a2449, V _a2450, V[] _rest2446) => {
return Call(f1_23, V.Undef, ((V)(((eh_2424 + 1D) - ToNum(h_2451)))));
}, 1, "", true)), "join", ((V)(";"))), Call(n4_26, V.Undef, ((V)((0.7 + (ToNum(Call(R2_2435, V.Undef)) * 0.5))))))) : Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.4;0.8;0.4")), ((V)(2.4)), ((V)(((-ToNum(i_2433)) * 0.1)))))).S("</rect>");
return default;
}, 1, "", true));
f_2170.S("<g transform=\"").V(Call(plane_29, V.Undef, p_2168, ((V)((FZ_2174 + 0.2))), ((V)(((yb_2425 + eh_2424) + 2D))), ((V)(0D)))).S("\">").S(s_2426.Str).S("</g>");
}
if (Truthy(play_2004)) {
V fl_2453 = default;
Call(rep_24, V.Undef, ((V)(6D)), Fn((V _arrowThis2461, int _argc2454, V i_2460, V _a2457, V _a2458, V _a2459, V[] _rest2455) => {
double s_2462 = 0;
V st_2463 = default;
V R2_2464 = default;
double dx_2465 = 0;
double dy_2466 = 0;
double b_2467 = 0;
s_2462 = (NumTruthy((ToNum(i_2460) % 2D)) ? 1D : (-1D));
st_2463 = Call(p_2168, V.Undef, ((V)((s_2462 * (HW_2006 + 4D)))), ((V)((TOP_2008 + 14D))), ((V)(12D)));
R2_2464 = Call(rng_25, V.Undef, ((V)(JsStrBuf.Begin().S("nt").V(i_2460).End())));
dx_2465 = ((s_2462 * (14D + (ToNum(Call(R2_2464, V.Undef)) * 18D))) * ToNum(k_2169));
dy_2466 = ((-(50D + (ToNum(Call(R2_2464, V.Undef)) * 30D))) * ToNum(k_2169));
b_2467 = ((-ToNum(i_2460)) * 0.45);
f_2170.S("<g transform=\"translate(").V(Call(P2_27, V.Undef, st_2463)).S(")\">").V(Call(atL_54, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().V(Call(P2_27, V.Undef, st_2463)).S(";").V(Call(f1_23, V.Undef, Add(GetIdx(st_2463, 0D), ((V)(dx_2465))))).S(" ").V(Call(f1_23, V.Undef, Add(GetIdx(st_2463, 1D), ((V)(dy_2466))))).End())), ((V)(2.7)), ((V)(b_2467)))).V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0;1;1;0")), ((V)(2.7)), ((V)(b_2467)))).S("<g transform=\"scale(").V(Call(n4_26, V.Undef, ((V)((ToNum(k_2169) * 1.1))))).S(")\"><path d=\"M0 0V-7L5 -8.6V-1.6\" fill=\"none\" stroke=\"").V(GetIdx(Arr(CY_2010, MG_2011, ((V)("#ffd84f"))), (ToNum(i_2460) % 3D))).S("\" stroke-width=\"1\"/><ellipse cx=\"-1.3\" cy=\"0.2\" rx=\"1.6\" ry=\"1.2\" fill=\"").V(GetIdx(Arr(CY_2010, MG_2011, ((V)("#ffd84f"))), (ToNum(i_2460) % 3D))).S("\"/><ellipse cx=\"3.7\" cy=\"-1.4\" rx=\"1.6\" ry=\"1.2\" fill=\"").V(GetIdx(Arr(CY_2010, MG_2011, ((V)("#ffd84f"))), (ToNum(i_2460) % 3D))).S("\"/></g></g>");
return default;
}, 1, "", true));
un_2171.S("<g transform=\"").V(Call(planeH_30, V.Undef, p_2168, ((V)(0.4)), ((V)(0D)), ((V)(0D)))).S("\">").V(Invoke(Call(rep_24, V.Undef, ((V)(3D)), Fn((V _arrowThis2475, int _argc2468, V j_2474, V _a2471, V _a2472, V _a2473, V[] _rest2469) => {
return ((V)(JsStrBuf.Begin().S("<ellipse rx=\"").N(HW_2006).S("\" ry=\"").N((DD_2007 * 0.8)).S("\" fill=\"none\" stroke=\"").V((NumTruthy((ToNum(j_2474) % 2D)) ? MG_2011 : CY_2010)).S("\" stroke-width=\"1.4\">").V(Call(an_31, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().N(HW_2006).S(";").N((HW_2006 + 70D)).End())), ((V)(2.1)), ((V)(((-ToNum(j_2474)) * 0.7))))).V(Call(an_31, V.Undef, ((V)("ry")), ((V)(JsStrBuf.Begin().N((DD_2007 * 0.8)).S(";").N(((DD_2007 * 0.8) + 70D)).End())), ((V)(2.1)), ((V)(((-ToNum(j_2474)) * 0.7))))).V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.8;0")), ((V)(2.1)), ((V)(((-ToNum(j_2474)) * 0.7))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
fl_2453 = Call(p_2168, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
un_2171.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(fl_2453, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(fl_2453, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)(((HW_2006 * 1.4) * ToNum(k_2169)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((((HW_2006 * 1.4) * ToNum(k_2169)) * ToNum(SA_42)) * 0.6))))).S("\" fill=\"").V(MG_2011).S("\" opacity=\"0.2\" filter=\"url(#djB)\">").V(Call(an_31, V.Undef, ((V)("fill")), ((V)(JsStrBuf.Begin().V(MG_2011).S(";").V(CY_2010).S(";").V(MG_2011).End())), ((V)(2.4)))).S("</ellipse>");
}
defs_2176 = ((V)(JsStrBuf.Begin().V(Add(Add(Add(Add(Add(Add(Add(Add(Add(PAW_69, Call(BLUR_33, V.Undef, ((V)("djB")), ((V)(1.4)))), Call(G_61, V.Undef, ((V)("djJ")), Arr(Arr(((V)(0D)), ((V)("#5a5f6a"))), Arr(((V)(0.5)), ((V)("#2a2c33"))), Arr(((V)(1D)), ((V)("#14151a")))), NewObj(2).Put("r", ((V)(1D))).Put("a", ((V)("cx=\"40%\" cy=\"35%\" r=\"70%\""))).V)), Call(G_61, V.Undef, ((V)("djEq")), Arr(Arr(((V)(0D)), ((V)("#ff4fb8"))), Arr(((V)(0.5)), ((V)("#ffd84f"))), Arr(((V)(1D)), ((V)("#3ff0ff")))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\""))).V)), Call(G_61, V.Undef, ((V)("djEqW")), Arr(Arr(((V)(0D)), ((V)("#fff0c8"))), Arr(((V)(0.5)), ((V)("#ffd28a"))), Arr(((V)(1D)), ((V)("#e8945a")))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\""))).V)), Call(G_61, V.Undef, ((V)("djSh")), Arr(Arr(((V)(0D)), ((V)("#f6f2e8"))), Arr(((V)(0.5)), ((V)("#ece4d2"))), Arr(((V)(1D)), ((V)("#d9cfb8")))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\""))).V)), Call(G_61, V.Undef, ((V)("djPly")), Arr(Arr(((V)(0D)), ((V)("#e2c496"))), Arr(((V)(1D)), ((V)("#c9a46e")))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\""))).V)), Call(G_61, V.Undef, ((V)("djGr")), Arr(Arr(((V)(0D)), ((V)("#ff4fb8"))), Arr(((V)(0.5)), ((V)("#ffd84f"))), Arr(((V)(1D)), ((V)("#3ff0ff")))))), Call(G_61, V.Undef, ((V)("djAc")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.55))), Arr(((V)(0.5)), ((V)("#f2f0ec")), ((V)(0.3))), Arr(((V)(1D)), ((V)("#ffe6c4")), ((V)(0.5)))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\""))).V)), Call(G_61, V.Undef, ((V)("djMi")), Arr(Arr(((V)(0D)), ((V)("#fff6e6"))), Arr(((V)(0.45)), ((V)("#b8a68a"))), Arr(((V)(0.55)), ((V)("#f2e6d0"))), Arr(((V)(1D)), ((V)("#7a6a54")))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\""))).V))).S("<clipPath id=\"djAlt\"><rect width=\"").N(W_2005).S("\" height=\"34\"/></clipPath>").End()));
return NewObj(5).Put("defs", defs_2176).Put("under", ((V)(un_2171.Str))).Put("back", bk_2172).Put("front", ((V)(f_2170.Str))).Put("bb", Call(bbOf_34, V.Undef, Invoke(Arr(Call(p_2168, V.Undef, ((V)(((-HW_2006) - 6D))), ((V)((TOP_2008 + 20D))), ((V)((((-DD_2007) / 2D) - 6D)))), Call(p_2168, V.Undef, ((V)((HW_2006 + 6D))), ((V)((TOP_2008 + 20D))), ((V)((((-DD_2007) / 2D) - 6D)))), Call(p_2168, V.Undef, ((V)(((-HW_2006) - 6D))), ((V)(0D)), ((V)(((DD_2007 / 2D) + 6D)))), Call(p_2168, V.Undef, ((V)((HW_2006 + 6D))), ((V)(0D)), ((V)(((DD_2007 / 2D) + 6D)))), Call(p_2168, V.Undef, ((V)(((-HW_2006) - 30D))), ((V)((TOP_2008 + 70D))), ((V)(12D))), Call(p_2168, V.Undef, ((V)((HW_2006 + 30D))), ((V)((TOP_2008 + 70D))), ((V)(12D)))), "concat", Call(plBB_68, V.Undef, p_2168, Get(PL_66, "djBooth"))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2017;
return default;
}, 1, "", true));
Set(N_39, "microLux", Fn((V _arrowThis2483, int _argc2476, V S_2482, V _a2479, V _a2480, V _a2481, V[] _rest2477) => {
V OAK_2484 = default;
V GR_2485 = default;
V SS_2486 = default;
V D_2487 = default;
OAK_2484 = ((V)("#c99a62"));
GR_2485 = ((V)("#2b2d31"));
SS_2486 = ((V)("#cfd3d8"));
D_2487 = NewObj(2).Put("w", ((V)(58D))).Put("d", ((V)(48D))).V;
Set(D_2487, "build", Fn((V _arrowThis2495, int _argc2488, V P_2494, V _a2491, V _a2492, V _a2493, V[] _rest2489) => {
V o_2496 = default;
o_2496 = Arr();
Invoke(Arr(Arr(((V)((-12D))), ((V)((-10D)))), Arr(((V)(12D)), ((V)((-10D)))), Arr(((V)((-12D))), ((V)(10D))), Arr(((V)(12D)), ((V)(10D)))), "forEach", Fn((V _arrowThis2508, int _argc2497, V _a2499, V _a2500, V _a2501, V _a2502, V[] _rest2498) => {
V x_2505 = default;
V z_2507 = default;
{ V _t2503 = ListOf(_a2499);
{ V _t2504 = GetIdx(_t2503, 0D);
x_2505 = _t2504; }
{ V _t2506 = GetIdx(_t2503, 1D);
z_2507 = _t2506; }
}
return Invoke(o_2496, "push", Call(cyl_13, V.Undef, x_2505, ((V)(0D)), z_2507, ((V)(1.3)), ((V)(36D)), ((V)("#1d1d20")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
Invoke(o_2496, "push", Call(arcW_17, V.Undef, ((V)(0D)), ((V)(11D)), ((V)(0D)), ((V)(13.4)), ((V)(11.4)), ((V)(1.1)), ((V)(1.1)), ((V)(0D)), ((V)((2D * PI_41))), ((V)("#1d1d20")), Call(mt_35, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(0D)), ((V)(20D)), ((V)(3.2)), OAK_2484, Call(wd_36, V.Undef, NewObj(3).Put("rz", ((V)(16.5))).Put("n", ((V)(30D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.96))), Arr(((V)(2.2)), ((V)(0D)), ((V)(1D))), Arr(((V)(3.2)), ((V)(0D)), ((V)(0.97))))).V)));
Invoke(Arr(Arr(((V)((-17D))), ((V)((-11D)))), Arr(((V)(17D)), ((V)((-11D)))), Arr(((V)((-17D))), ((V)(11D))), Arr(((V)(17D)), ((V)(11D)))), "forEach", Fn((V _arrowThis2520, int _argc2509, V _a2511, V _a2512, V _a2513, V _a2514, V[] _rest2510) => {
V x_2517 = default;
V z_2519 = default;
{ V _t2515 = ListOf(_a2511);
{ V _t2516 = GetIdx(_t2515, 0D);
x_2517 = _t2516; }
{ V _t2518 = GetIdx(_t2515, 1D);
z_2519 = _t2518; }
}
return Invoke(o_2496, "push", Call(cyl_13, V.Undef, x_2517, ((V)(39.2)), z_2519, ((V)(1.4)), ((V)(0.8)), ((V)("#111114")), NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(o_2496, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(44D)), ((V)(25D)), ((V)(31D)), GR_2485, Call(mt_35, V.Undef, NewObj(1).Put("r", ((V)(3.4))).V)), Call(slab_15, V.Undef, ((V)(0D)), ((V)(40.4)), ((V)(15.6)), ((V)(43.2)), ((V)(24.2)), ((V)(0.6)), SS_2486, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(3.2))).Put("shine", ((V)(1D))).V)), Call(slab_15, V.Undef, ((V)((-5.2))), ((V)(41.4)), ((V)(16.1)), ((V)(32D)), ((V)(22.2)), ((V)(0.7)), ((V)("#0c0d10")), Call(cer_37, V.Undef, NewObj(1).Put("r", ((V)(2.2))).V)), Call(slab_15, V.Undef, ((V)(16.2)), ((V)(41.4)), ((V)(16.1)), ((V)(9.2)), ((V)(22.2)), ((V)(0.7)), ((V)("#141518")), Call(cer_37, V.Undef, NewObj(1).Put("r", ((V)(1.8))).V)), Call(box_12, V.Undef, ((V)(10.4)), ((V)(43D)), ((V)(16.6)), ((V)(0.8)), ((V)(18D)), ((V)(1.2)), SS_2486, Call(mt_35, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("shine", ((V)(1D))).V)));
return o_2496;
return default;
}, 1, "", true));
Set(D_2487, "fx", Fn((V _arrowThis2528, int _argc2521, V c_2527, V _a2524, V _a2525, V _a2526, V[] _rest2522) => {
V p_2529 = default;
V k_2530 = default;
JsStrBuf f_2531 = null;
JsStrBuf v_2532 = null;
V tp_2533 = default;
V defs_2534 = default;
p_2529 = Get(c_2527, "p");
k_2530 = Get(c_2527, "k");
f_2531 = new JsStrBuf("");
f_2531.S("<g transform=\"").V(Call(plane_29, V.Undef, p_2529, ((V)(16.9)), ((V)(61.4)), ((V)((-19D))))).S("\"><rect x=\"0.6\" y=\"0.6\" width=\"26\" height=\"17\" rx=\"1.6\" fill=\"url(#mlW)\">").V(Call(an_31, V.Undef, ((V)("opacity")), ((V)("0.8;1;0.8")), ((V)(2.2)))).S("</rect><g transform=\"translate(13.6 13.4)\"><ellipse rx=\"9\" ry=\"1.8\" fill=\"#ffffff\" opacity=\"0.3\"/><g>").V(Call(atS_32, V.Undef, ((V)("scale")), ((V)("1 1;0.6 1;1 1")), ((V)(3D)))).S("<path d=\"M-3.6 0L-3 -6Q0 -7.6 3 -6L3.6 0Z\" fill=\"#f6efdc\" stroke=\"#cbb48a\" stroke-width=\"0.3\"/><g>").V(Call(atS_32, V.Undef, ((V)("scale")), ((V)("1 1;1.06 1.12;1 1")), ((V)(1.4)))).S("<rect x=\"-2.8\" y=\"-4.6\" width=\"5.6\" height=\"1.6\" fill=\"#d9363b\"/></g></g></g>").S("<rect x=\"0.6\" y=\"0.6\" width=\"26\" height=\"17\" rx=\"1.6\" fill=\"url(#mlG)\"/><path d=\"M4 2L10 17\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.18\"/></g>");
f_2531.S("<g transform=\"").V(Call(plane_29, V.Undef, p_2529, ((V)(16.9)), ((V)(62.4)), ((V)(12.2)))).S("\"><rect x=\"0.6\" y=\"1\" width=\"7.2\" height=\"3.4\" rx=\"0.6\" fill=\"#05070a\"/><text x=\"4.2\" y=\"3.6\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"2.5\" fill=\"#7fe8ff\">1:30").V(Call(anD_52, V.Undef, ((V)("opacity")), ((V)("1;0.55")), ((V)(1D)))).S("</text>").S("<circle cx=\"4.2\" cy=\"9.4\" r=\"2.6\" fill=\"none\" stroke=\"#7fe8ff\" stroke-width=\"0.35\" opacity=\"0.8\"/><circle cx=\"4.2\" cy=\"9.4\" r=\"1.9\" fill=\"#1d1f24\" stroke=\"").V(SS_2486).S("\" stroke-width=\"0.3\"/>").V(Invoke(Call(rep_24, V.Undef, ((V)(4D)), Fn((V _arrowThis2542, int _argc2535, V i_2541, V _a2538, V _a2539, V _a2540, V[] _rest2536) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").N((1.8 + (ToNum(i_2541) * 1.6))).S("\" cy=\"14.6\" r=\"0.5\" fill=\"#9aa3a8\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<rect x=\"1.4\" y=\"17\" width=\"5.6\" height=\"2\" rx=\"0.5\" fill=\"none\" stroke=\"#4fdc6a\" stroke-width=\"0.3\"/></g>");
v_2532 = new JsStrBuf("");
Call(rep_24, V.Undef, ((V)(7D)), Fn((V _arrowThis2550, int _argc2543, V i_2549, V _a2546, V _a2547, V _a2548, V[] _rest2544) => {
return ((V)(v_2532.S("<path d=\"M").N((3D + (ToNum(i_2549) * 3.4))).S(" 4V15\" stroke=\"#1a1b1e\" stroke-width=\"0.7\" stroke-linecap=\"round\"/>").Str));
}, 1, "", true));
f_2531.S("<g transform=\"").V(Invoke(Get(RD_8, "H3"), "planeX", p_2529, ((V)(22.15)), ((V)(62D)), ((V)((-10D))))).S("\">").S(v_2532.Str).S("</g>");
tp_2533 = Call(surf_55, V.Undef, p_2529, Arr(((V)((-22D))), ((V)(65.1)), ((V)((-15.5)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
f_2531.S("<g transform=\"").V(tp_2533).S("\"><rect x=\"1\" y=\"1\" width=\"42\" height=\"29\" rx=\"3\" fill=\"url(#mlT)\"/></g>");
defs_2534 = Add(Add(Call(G_61, V.Undef, ((V)("mlW")), Arr(Arr(((V)(0D)), ((V)("#ffe6a8"))), Arr(((V)(0.6)), ((V)("#f2b45a"))), Arr(((V)(1D)), ((V)("#8a4f1e")))), NewObj(2).Put("r", ((V)(1D))).Put("a", ((V)("cx=\"50%\" cy=\"65%\" r=\"75%\""))).V), Call(G_61, V.Undef, ((V)("mlG")), Arr(Arr(((V)(0D)), ((V)("#0a0b0e")), ((V)(0.55))), Arr(((V)(0.4)), ((V)("#0a0b0e")), ((V)(0.2))), Arr(((V)(0.55)), ((V)("#ffffff")), ((V)(0.12))), Arr(((V)(0.6)), ((V)("#0a0b0e")), ((V)(0.25))), Arr(((V)(1D)), ((V)("#0a0b0e")), ((V)(0.55)))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\""))).V)), Call(G_61, V.Undef, ((V)("mlT")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.18))), Arr(((V)(0.5)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(1D)), ((V)("#000000")), ((V)(0.15)))), NewObj(1).Put("a", ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\""))).V));
return NewObj(2).Put("defs", defs_2534).Put("front", ((V)(f_2531.Str))).V;
return default;
}, 1, "", true));
return D_2487;
return default;
}, 1, "", true));
draw4_74 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis2559, int _argc2551, V r_2557, V o_2558, V _a2555, V _a2556, V[] _rest2552) => {
V res_2560 = default;
res_2560 = Call(draw4_74, V.Undef, r_2557, o_2558);
if (Truthy(((!(Truthy(res_2560)) ? V.True : V.False) is var _t2561 && Truthy(_t2561) ? _t2561 : Get(res_2560, "_p5")))) {
return res_2560;
}
Set(res_2560, "_p5", ((V)(1D)));
try {
V p_2562 = default;
V sp_2563 = default;
p_2562 = Invoke(RD_8, "projOf", ((V)(1D)));
sp_2563 = (Truthy(Get(r_2557, "spec")) ? GetIdx(Invoke(Get(r_2557, "spec"), "split", NewRegExp(RX3, "[.@*+]", "")), 0D) : ((V)("")));
if (Truthy((GetK(PL_66, sp_2563) is var _t2564 && !Truthy(_t2564) ? _t2564 : Get(res_2560, "bb")))) {
Set(res_2560, "players", Invoke(Call(plOf_67, V.Undef, sp_2563, (o_2558 is var _t2575 && !Truthy(_t2575) ? _t2575 : Get(o_2558, "st"))), "map", Fn((V _arrowThis2572, int _argc2565, V q_2571, V _a2568, V _a2569, V _a2570, V[] _rest2566) => {
V s_2573 = default;
s_2573 = Call(p_2562, V.Undef, Get(q_2571, "x"), ((V)(0D)), Get(q_2571, "z"));
return NewObj(6).Put("x", GetIdx(s_2573, 0D)).Put("y", GetIdx(s_2573, 1D)).Put("v", Get(q_2571, "v")).Put("a", Get(q_2571, "a")).Put("b", (!(!(Truthy(Get(q_2571, "b")))) ? V.True : V.False)).Put("d", (Get(q_2571, "d") is var _t2574 && Truthy(_t2574) ? _t2574 : ((V)(0D)))).V;
return default;
}, 1, "", true)));
}
if (Truthy((Get(r_2557, "fog") is var _t2576 && !Truthy(_t2576) ? _t2576 : Get(res_2560, "bb")))) {
V F_2577 = default;
V pr_2578 = default;
V o0_2579 = default;
V dv_2580 = default;
V dl_2581 = default;
F_2577 = Get(r_2557, "fog");
pr_2578 = Fn((V _arrowThis2589, int _argc2582, V q_2588, V _a2585, V _a2586, V _a2587, V[] _rest2583) => {
return Call(p_2562, V.Undef, GetIdx(q_2588, 0D), GetIdx(q_2588, 1D), GetIdx(q_2588, 2D));
}, 1, "", true);
o0_2579 = Call(p_2562, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
dv_2580 = Call(pr_2578, V.Undef, (Get(F_2577, "dir") is var _t2590 && Truthy(_t2590) ? _t2590 : Arr(((V)(1D)), ((V)(0D)), ((V)(0D)))));
dl_2581 = (((V)(Hypot((ToNum(GetIdx(dv_2580, 0D)) - ToNum(GetIdx(o0_2579, 0D))), (ToNum(GetIdx(dv_2580, 1D)) - ToNum(GetIdx(o0_2579, 1D)))))) is var _t2591 && Truthy(_t2591) ? _t2591 : ((V)(1D)));
Set(res_2560, "fog", NewObj(7).Put("t", Get(F_2577, "t")).Put("style", Get(F_2577, "style")).Put("tint", Get(F_2577, "tint")).Put("pts", Invoke(Get(F_2577, "at"), "map", pr_2578)).Put("dir", Arr(((V)(((ToNum(GetIdx(dv_2580, 0D)) - ToNum(GetIdx(o0_2579, 0D))) / ToNum(dl_2581)))), ((V)(((ToNum(GetIdx(dv_2580, 1D)) - ToNum(GetIdx(o0_2579, 1D))) / ToNum(dl_2581)))))).Put("fl", Call(pr_2578, V.Undef, (Get(F_2577, "fl") is var _t2592 && Truthy(_t2592) ? _t2592 : Arr(GetIdx(GetIdx(Get(F_2577, "at"), 0D), 0D), ((V)(0D)), GetIdx(GetIdx(Get(F_2577, "at"), 0D), 2D))))).Put("cf", (Truthy(Get(F_2577, "cf")) ? Call(pr_2578, V.Undef, Get(F_2577, "cf")) : V.Null)).V);
}
} catch (System.Exception _ex2593) {
V e_2594 = default;
e_2594 = Caught(_ex2593);
Invoke(G("console"), "warn", ((V)("reno plus5")), Get(r_2557, "id"), e_2594);
}
return res_2560;
return default;
}, 2, "", true));
DJN_75 = ((V)("Tap the booth and a creature steps up in boss shades and a studio headset: one paw holding the ear cup, the other pumping the crowd, head bobbing to the beat while the decks spin and the EQ pumps."));
Set(RD_8, "SET5", NewObj(18).Put("CLB-031", NewObj(4).Put("spec", ((V)("pinball5"))).Put("play", ((V)("pin"))).Put("live", ((V)("Playable"))).Put("note", ((V)("A classic pinball cabinet: angled playfield under glass, two flippers, three pop bumpers, slingshots, a lit backglass with a score display and neon trim. Tap to play a ball."))).V).Put("CLB-051", NewObj(4).Put("spec", ((V)("danceCab"))).Put("play", ((V)("dance"))).Put("live", ((V)("2-player"))).Put("note", ((V)("An upright rhythm cabinet with a big screen, light-up marquee and two floor pads. Arrows scroll up the screen and the pad panels light on the beat. Tap and two creatures dance."))).V).Put("CLB-071", NewObj(6).Put("spec", ((V)("glowTable"))).Put("play", ((V)("table"))).Put("live", ((V)("2-player"))).Put("modes", Arr(((V)("Air Hockey")), ((V)("Billiards")))).Put("modeLbl", ((V)("GAME"))).Put("note", ((V)("A flip-top glow table: an icy air-hockey surface or a UV billiards felt with LED pockets. Tap and two creatures play a live match."))).V).Put("CLB-010", NewObj(4).Put("spec", ((V)("bubbleFan"))).Put("live", ((V)("Blows bubbles"))).Put("fog", NewObj(4).Put("t", ((V)(1D))).Put("style", ((V)("bubble"))).Put("at", Arr(Arr(((V)(0D)), ((V)(82D)), ((V)(10D))))).Put("dir", Arr(((V)(0.5)), ((V)(0.25)), ((V)(0.87)))).V).Put("note", ((V)("A retro floor fan that turns side to side, with a bubble-wand wheel spinning through a soap tray in front of the grille. Tap to switch on more bubbles."))).V).Put("CLB-030", NewObj(4).Put("spec", ((V)("fogMini"))).Put("live", ((V)("Fog \u00b7 light"))).Put("fog", NewObj(5).Put("t", ((V)(2D))).Put("style", ((V)("jet"))).Put("at", Arr(Arr(((V)(27D)), ((V)(15D)), ((V)(0D))))).Put("dir", Arr(((V)(1D)), ((V)(0.05)), ((V)(0.3)))).Put("fl", Arr(((V)(40D)), ((V)(0D)), ((V)(10D)))).V).Put("note", ((V)("A small Halloween fog machine with a carry handle, fluid tank and wired remote. Tap for short, light puffs that clear quickly."))).V).Put("CLB-050", NewObj(4).Put("spec", ((V)("hazer"))).Put("live", ((V)("Haze \u00b7 medium"))).Put("fog", NewObj(6).Put("t", ((V)(3D))).Put("style", ((V)("haze"))).Put("at", Arr(Arr(((V)(12D)), ((V)(31D)), ((V)(0D))))).Put("dir", Arr(((V)(1D)), ((V)(0.1)), ((V)(0.35)))).Put("fl", Arr(((V)(20D)), ((V)(0D)), ((V)(20D)))).Put("tint", Arr(((V)("#f2efff")), ((V)("#d6c8ff")), ((V)("#f6f6fa")))).V).Put("note", ((V)("A pro hazer on a road case with two UV blacklight cannons. Tap for a wider haze that settles into a low fog bank under UV light."))).V).Put("CLB-070", NewObj(4).Put("spec", ((V)("cryoJets"))).Put("live", ((V)("CO2 \u00b7 heavy"))).Put("fog", NewObj(6).Put("t", ((V)(4D))).Put("style", ((V)("up"))).Put("at", Arr(Arr(((V)((-40D))), ((V)(47D)), ((V)(10D))), Arr(((V)(40D)), ((V)(47D)), ((V)(10D))))).Put("fl", Arr(((V)(0D)), ((V)(0D)), ((V)(16D)))).Put("cf", Arr(((V)(6D)), ((V)(36D)), ((V)(24D)))).Put("tint", Arr(((V)("#ffffff")), ((V)("#e6f4ff")))).V).Put("note", ((V)("Two cryo CO2 jets on a steel tank shoot freezing white columns, and a confetti cannon fires on the beat. Tap for dense bursts and a thick, lasting floor fog."))).V).Put("CLB-090", NewObj(4).Put("spec", ((V)("mistMatrix"))).Put("live", ((V)("Mist \u00b7 max"))).Put("fog", NewObj(5).Put("t", ((V)(5D))).Put("style", ((V)("mist"))).Put("at", Arr(Arr(((V)(0D)), ((V)(84D)), ((V)(0D))), Arr(((V)(0D)), ((V)(98D)), ((V)(0D))), Arr(((V)(0D)), ((V)(110D)), ((V)(0D))))).Put("fl", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("tint", Arr(((V)("#f6fbff")), ((V)("#eaf2ff")), ((V)("#fff4e6")))).V).Put("note", ((V)("An obsidian and titanium column with three floating mist rings and a zero-gravity bubble cloud. Tap for the densest, longest-lasting mist in the club."))).V).Put("CLB-082", NewObj(4).Put("spec", ((V)("bassReactor"))).Put("live", ((V)("Bass + haze"))).Put("fog", NewObj(5).Put("t", ((V)(5D))).Put("style", ((V)("ring"))).Put("at", Arr(Arr(((V)(0D)), ((V)(6D)), ((V)(4D))))).Put("fl", Arr(((V)(0D)), ((V)(0D)), ((V)(4D)))).Put("tint", Arr(((V)("#eef6ff")), ((V)("#f6ead6")))).V).Put("note", ((V)("Twin obsidian reactor towers with titanium drivers and a black-glass sub sphere levitating between them. Tap to play: sonic beams pulse and a haze ring rolls out across the floor."))).V).Put("CLB-015", NewObj(5).Put("spec", ((V)("djBooth"))).Put("sx", NewObj(1).Put("v", ((V)("table"))).V).Put("play", ((V)("dj"))).Put("live", ((V)("DJ set"))).Put("note", ((V)(JsStrBuf.Begin().S("A folding table with a cracked bed-sheet banner and a cheap 2-deck controller. ").V(DJN_75).End()))).V).Put("CLB-035", NewObj(5).Put("spec", ((V)("djBooth"))).Put("sx", NewObj(1).Put("v", ((V)("plywood"))).V).Put("play", ((V)("dj"))).Put("live", ((V)("DJ set"))).Put("note", ((V)(JsStrBuf.Begin().S("A plywood booth with a graffiti front, two turntables and a club mixer. ").V(DJN_75).End()))).V).Put("CLB-055", NewObj(5).Put("spec", ((V)("djBooth"))).Put("sx", NewObj(1).Put("v", ((V)("truss"))).V).Put("play", ((V)("dj"))).Put("live", ((V)("DJ set"))).Put("note", ((V)(JsStrBuf.Begin().S("Brushed aluminium truss with an edge-lit acrylic shield, two CDJs, a mixer and a laptop. ").V(DJN_75).End()))).V).Put("CLB-075", NewObj(5).Put("spec", ((V)("djBooth"))).Put("sx", NewObj(1).Put("v", ((V)("altar"))).V).Put("play", ((V)("dj"))).Put("live", ((V)("DJ set"))).Put("note", ((V)(JsStrBuf.Begin().S("A faceted obsidian altar with mirror shards and projection-mapped light lines. ").V(DJN_75).End()))).V).Put("CLB-095", NewObj(5).Put("spec", ((V)("djBooth"))).Put("sx", NewObj(1).Put("v", ((V)("cyber"))).V).Put("play", ((V)("dj"))).Put("live", ((V)("DJ set"))).Put("note", ((V)(JsStrBuf.Begin().S("A booth lifted on hydraulic pistons, with holographic jog rings and a 360\u00b0 hologram halo. ").V(DJN_75).End()))).V).Put("CLB-038", NewObj(5).Put("spec", ((V)("djBooth"))).Put("sx", NewObj(1).Put("v", ((V)("ctrl"))).V).Put("play", ((V)("dj"))).Put("live", ((V)("DJ set"))).Put("note", ((V)(JsStrBuf.Begin().S("A 2-channel controller and laptop on a black DJ desk. ").V(DJN_75).End()))).V).Put("CLB-058", NewObj(5).Put("spec", ((V)("djBooth"))).Put("sx", NewObj(1).Put("v", ((V)("vinyl"))).V).Put("play", ((V)("dj"))).Put("live", ((V)("DJ set"))).Put("note", ((V)(JsStrBuf.Begin().S("Two direct-drive turntables and a 4-channel mixer, with a crate of records under the desk. ").V(DJN_75).End()))).V).Put("CLB-078", NewObj(5).Put("spec", ((V)("djBooth"))).Put("sx", NewObj(1).Put("v", ((V)("quad"))).V).Put("play", ((V)("dj"))).Put("live", ((V)("DJ set"))).Put("note", ((V)(JsStrBuf.Begin().S("Four flagship CDJs around a gold rotary mixer on a wide gold-trimmed desk. ").V(DJN_75).End()))).V).Put("MOV-011", NewObj(4).Put("spec", ((V)("microLux"))).Put("name", ((V)("Compact Graphite Microwave on an Oak Stool"))).Put("live", ((V)("Popping"))).Put("note", ((V)("A modern compact microwave: graphite body, flush black-glass door, touch strip with a glowing timer, on a round oak stool. Popcorn puffs up inside."))).V).V);
edit4_76 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis2602, int _argc2595, V rows_2601, V _a2598, V _a2599, V _a2600, V[] _rest2596) => {
return Invoke(Call(edit4_76, V.Undef, rows_2601), "map", Fn((V _arrowThis2610, int _argc2603, V r_2609, V _a2606, V _a2607, V _a2608, V[] _rest2604) => {
return (Truthy(GetK(Get(RD_8, "SET5"), Get(r_2609, "id"))) ? Object_assign(NewObj(0).V, r_2609, GetK(Get(RD_8, "SET5"), Get(r_2609, "id"))) : r_2609);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "PLUS5", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
