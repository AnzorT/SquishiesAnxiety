// yg-intros.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_yg_intros_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("[&<>\"]", "g");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V go_8 = default;
if (_self1.IsNullish) _self1 = GlobalV;
go_8 = Fn((V _self1, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_15 = default;
double TAU_16 = 0;
V f_17 = default;
V esc_18 = default;
V lg_19 = default;
V rg_20 = default;
V rays_21 = default;
V spark_22 = default;
V cloud_23 = default;
V speed_24 = default;
V logo_25 = default;
V stk_26 = default;
V POOL_27 = default;
V STK_28 = default;
V badge_29 = default;
V wrap_30 = default;
V wrapL_31 = default;
V backdrop_32 = default;
V hoop_33 = default;
V soccer_34 = default;
V hop_35 = default;
V tramp_36 = default;
V slide_37 = default;
V corn_38 = default;
V pong_39 = default;
logo_25 = Fn((V _self40, int _argc41, V u_47, V lines_48, V x_49, V y_50, V[] _rest42) => {
V id_52 = default;
V lh_53 = default;
JsStrBuf s_54 = null;
V o_51 = default;
if (_self40.IsNullish) _self40 = GlobalV;
o_51 = (_argc41 > 4 ? _rest42[0] : V.Undef);
id_52 = ((V)(JsStrBuf.Begin().V(u_47).S("lg").End()));
lh_53 = (Get(o_51, "lh") is var _t55 && Truthy(_t55) ? _t55 : ((V)(54D)));
s_54 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"translate(").V(x_49).S(" ").V(y_50).S(") rotate(").V((Get(o_51, "rot") is var _t56 && Truthy(_t56) ? _t56 : ((V)(0D)))).S(")\" font-family=\"Fredoka, Nunito, system-ui, sans-serif\" font-weight=\"700\" text-anchor=\"middle\" stroke-linejoin=\"round\" letter-spacing=\"").V((Get(o_51, "ls") is var _t57 && Truthy(_t57) ? _t57 : ((V)(0.5)))).S("\">").End());
Invoke(lines_48, "forEach", Fn((V _self40, int _argc58, V t_64, V i_65, V _a62, V _a63, V[] _rest59) => {
V z_66 = default;
V yy_67 = default;
z_66 = ((GetK((Get(o_51, "sizes") is var _t68 && Truthy(_t68) ? _t68 : Arr()), i_65) is var _t69 && Truthy(_t69) ? _t69 : Get(o_51, "size")) is var _t70 && Truthy(_t70) ? _t70 : ((V)(50D)));
yy_67 = (!GetK((Get(o_51, "ys") is var _t71 && Truthy(_t71) ? _t71 : Arr()), i_65).IsNullish ? GetK(Get(o_51, "ys"), i_65) : ((V)((ToNum(i_65) * ToNum(lh_53)))));
s_54.S("<text y=\"").V(Call(f_17, V.Undef, Add(yy_67, ((V)((ToNum(z_66) * 0.1)))))).S("\" font-size=\"").V(z_66).S("\" fill=\"").V(Get(o_51, "shade")).S("\" stroke=\"").V(Get(o_51, "shade")).S("\" stroke-width=\"").V(Call(f_17, V.Undef, ((V)((ToNum(z_66) * 0.32))))).S("\">").V(Call(esc_18, V.Undef, t_64)).S("</text>").S("<text y=\"").V(Call(f_17, V.Undef, yy_67)).S("\" font-size=\"").V(z_66).S("\" fill=\"").V(Get(o_51, "ink")).S("\" stroke=\"").V(Get(o_51, "ink")).S("\" stroke-width=\"").V(Call(f_17, V.Undef, ((V)((ToNum(z_66) * 0.2))))).S("\">").V(Call(esc_18, V.Undef, t_64)).S("</text>").S("<text y=\"").V(Call(f_17, V.Undef, yy_67)).S("\" font-size=\"").V(z_66).S("\" fill=\"url(#").V(id_52).S(")\">").V(Call(esc_18, V.Undef, t_64)).S("</text>");
return default;
}, 2, "", true));
return NewObj(2).Put("defs", Call(lg_19, V.Undef, id_52, ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), (Get(o_51, "hi") is var _t72 && Truthy(_t72) ? _t72 : ((V)("#ffffff")))), Arr(((V)(0.42)), Get(o_51, "top")), Arr(((V)(1D)), Get(o_51, "bot"))))).Put("body", ((V)(string.Concat(s_54.Str, "</g>")))).V;
return default;
}, 5, "logo", false);
badge_29 = Fn((V _self73, int _argc74, V x_80, V y_81, V r_82, V word_83, V[] _rest75) => {
JsStrBuf d_88 = null;
V rot_84 = default;
V fill_85 = default;
V ink_86 = default;
V size_87 = default;
if (_self73.IsNullish) _self73 = GlobalV;
rot_84 = (_argc74 > 4 ? _rest75[0] : V.Undef);
fill_85 = (_argc74 > 5 ? _rest75[1] : V.Undef);
ink_86 = (_argc74 > 6 ? _rest75[2] : V.Undef);
size_87 = (_argc74 > 7 ? _rest75[3] : V.Undef);
d_88 = new JsStrBuf("");
{
double i_89 = 0;
i_89 = 0D;
while (true) {
if (!((i_89 < 24D))) break;
double a_91 = 0;
V rr_92 = default;
a_91 = ((i_89 / 24D) * TAU_16);
rr_92 = (NumTruthy((i_89 % 2D)) ? ((V)((ToNum(r_82) * 0.8))) : r_82);
d_88.S((NumTruthy(i_89) ? "L" : "M")).V(Call(f_17, V.Undef, Add(x_80, ((V)(((FdLibm.Cos(a_91) * ToNum(rr_92)) * 1.25)))))).S(" ").V(Call(f_17, V.Undef, Add(y_81, ((V)(((FdLibm.Sin(a_91) * ToNum(rr_92)) * 0.82))))));
i_89++;
}
}
return ((V)(JsStrBuf.Begin().S("<g transform=\"rotate(").V(rot_84).S(" ").V(x_80).S(" ").V(y_81).S(")\"><path d=\"").S(d_88.Str).S("Z\" fill=\"").V(ink_86).S("\" transform=\"translate(0 4)\"/><path d=\"").S(d_88.Str).S("Z\" fill=\"").V(fill_85).S("\" stroke=\"").V(ink_86).S("\" stroke-width=\"3.5\" stroke-linejoin=\"round\"/>").S("<text x=\"").V(x_80).S("\" y=\"").V(Call(f_17, V.Undef, Add(y_81, ((V)((ToNum(size_87) * 0.36)))))).S("\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"").V(size_87).S("\" text-anchor=\"middle\" fill=\"#ffffff\" stroke=\"").V(ink_86).S("\" stroke-width=\"").V(Call(f_17, V.Undef, ((V)((ToNum(size_87) * 0.2))))).S("\" stroke-linejoin=\"round\" paint-order=\"stroke fill\">").V(word_83).S("</text></g>").End()));
return default;
}, 8, "badge", false);
backdrop_32 = Fn((V _self93, int _argc94, V y_100, V tint_101, V op_102, V _a99, V[] _rest95) => {
JsStrBuf s_103 = null;
if (_self93.IsNullish) _self93 = GlobalV;
s_103 = new JsStrBuf(JsStrBuf.Begin().S("<g opacity=\"").V((op_102 is var _t104 && Truthy(_t104) ? _t104 : ((V)(1D)))).S("\">").End());
Invoke(Arr(Arr(((V)((-130D))), ((V)(0.85))), Arr(((V)((-60D))), ((V)(1D))), Arr(((V)(24D)), ((V)(1.1))), Arr(((V)(92D)), ((V)(0.8))), Arr(((V)(276D)), ((V)(0.9))), Arr(((V)(340D)), ((V)(1.2))), Arr(((V)(430D)), ((V)(1D))), Arr(((V)(500D)), ((V)(0.8))), Arr(((V)(600D)), ((V)(1.1))), Arr(((V)(690D)), ((V)(0.9)))), "forEach", Fn((V _self93, int _argc105, V _a107, V _a108, V _a109, V _a110, V[] _rest106) => {
V x_113 = default;
V k_115 = default;
{ V _t111 = ListOf(_a107);
{ V _t112 = GetIdx(_t111, 0D);
x_113 = _t112; }
{ V _t114 = GetIdx(_t111, 1D);
k_115 = _t114; }
}
s_103.S("<g transform=\"translate(").V(x_113).S(" ").V(y_100).S(") scale(").V(k_115).S(")\"><rect x=\"-4\" y=\"-30\" width=\"8\" height=\"32\" rx=\"3\" fill=\"#8a5a34\"/><circle cx=\"-14\" cy=\"-40\" r=\"18\" fill=\"").V(GetIdx(tint_101, 0D)).S("\"/><circle cx=\"13\" cy=\"-42\" r=\"20\" fill=\"").V(GetIdx(tint_101, 0D)).S("\"/><circle cx=\"0\" cy=\"-58\" r=\"22\" fill=\"").V(GetIdx(tint_101, 1D)).S("\"/></g>");
return default;
}, 1, "", true));
s_103.S("<rect x=\"-420\" y=\"").N((ToNum(y_100) - 22D)).S("\" width=\"1400\" height=\"5\" fill=\"#fff8ee\"/><rect x=\"-420\" y=\"").N((ToNum(y_100) - 10D)).S("\" width=\"1400\" height=\"5\" fill=\"#fff8ee\"/>");
{
double x_116 = 0;
x_116 = (-414D);
while (true) {
if (!((x_116 < 980D))) break;
s_103.S("<path d=\"M").N(x_116).S(" ").V(Add(y_100, ((V)(2D)))).S("V").N((ToNum(y_100) - 26D)).S("L").N((x_116 + 5D)).S(" ").N((ToNum(y_100) - 31D)).S("L").N((x_116 + 10D)).S(" ").N((ToNum(y_100) - 26D)).S("V").V(Add(y_100, ((V)(2D)))).S("Z\" fill=\"#fffaf2\" stroke=\"#e8d8c2\" stroke-width=\"1\"/>");
x_116 = (x_116 + 16D);
}
}
return ((V)(string.Concat(s_103.Str, "</g>")));
return default;
}, 3, "backdrop", false);
hoop_33 = Fn((V _self118, int _argc119, V u_125, V c_126, V _a123, V _a124, V[] _rest120) => {
V L_127 = default;
V defs_128 = default;
JsStrBuf b_129 = null;
JsStrBuf net_130 = null;
if (_self118.IsNullish) _self118 = GlobalV;
L_127 = Call(logo_25, V.Undef, u_125, Arr(((V)("HOOP SHOT"))), ((V)(180D)), ((V)(84D)), NewObj(7).Put("size", ((V)(52D))).Put("top", ((V)("#ffd25a"))).Put("bot", ((V)("#ff7a2a"))).Put("hi", ((V)("#fff6c8"))).Put("ink", ((V)("#5a1e3c"))).Put("shade", ((V)("#34102a"))).Put("rot", ((V)((-4D)))).V);
defs_128 = Add(Add(Add(Add(Add(Add(Get(L_127, "defs"), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_125).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#ff7a6a"))), Arr(((V)(0.45)), ((V)("#ffad6a"))), Arr(((V)(1D)), ((V)("#ffe2a2")))))), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_125).S("gd").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#efe6d8"))), Arr(((V)(1D)), ((V)("#c9bfae")))))), Call(rg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_125).S("bl").End())), ((V)("35%")), ((V)("30%")), ((V)("75%")), Arr(Arr(((V)(0D)), ((V)("#ffbb80"))), Arr(((V)(0.55)), ((V)("#f27a2c"))), Arr(((V)(1D)), ((V)("#a8400f")))))), Call(rg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_125).S("sun").End())), ((V)("50%")), ((V)("50%")), ((V)("50%")), Arr(Arr(((V)(0D)), ((V)("#fff6d0")), ((V)(0.95))), Arr(((V)(0.5)), ((V)("#ffe08a")), ((V)(0.45))), Arr(((V)(1D)), ((V)("#ffd070")), ((V)(0D)))))), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_125).S("bd").End())), ((V)(1D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(1D)), ((V)("#e6eefc")))))), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_125).S("pl").End())), ((V)(1D)), ((V)(0D)), Arr(Arr(((V)(0D)), ((V)("#2c2c36"))), Arr(((V)(0.45)), ((V)("#5a5a6a"))), Arr(((V)(1D)), ((V)("#2c2c36"))))));
b_129 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-420\" width=\"1400\" height=\"640\" fill=\"url(#").V(u_125).S("sk)\"/>").V(Call(rays_21, V.Undef, ((V)(262D)), ((V)(222D)), ((V)(20D)), ((V)("#fff4cf")), ((V)(0.2)), ((V)(0.1)))).S("<circle cx=\"262\" cy=\"222\" r=\"150\" fill=\"url(#").V(u_125).S("sun)\"/>").End());
b_129.V(Add(Call(cloud_23, V.Undef, ((V)(52D)), ((V)(150D)), ((V)(0.7)), ((V)(0.55))), Call(cloud_23, V.Undef, ((V)(320D)), ((V)(120D)), ((V)(0.5)), ((V)(0.45)))));
b_129.S("<path d=\"M-10 330V292L30 270L70 292V300L120 300V280L150 262L180 280V330Z\" fill=\"#d97a6a\" opacity=\"0.45\"/>").V(Call(backdrop_32, V.Undef, ((V)(338D)), Arr(((V)("#c9845e")), ((V)("#d99468"))), ((V)(0.55))));
b_129.S("<path d=\"M-420 336H980V640H-420Z\" fill=\"url(#").V(u_125).S("gd)\"/><path d=\"M-420 336H980\" stroke=\"#d8cdbc\" stroke-width=\"3\"/>");
b_129.S("<path d=\"M188 336L246 336L330 640L104 640Z\" fill=\"#ffffff\" opacity=\"0.18\"/><path d=\"M188 336L104 640M246 336L330 640\" stroke=\"#ffffff\" stroke-width=\"5\" opacity=\"0.85\"/><path d=\"M150 470Q217 436 284 470\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"5\" opacity=\"0.85\"/>");
b_129.S("<ellipse cx=\"322\" cy=\"346\" rx=\"34\" ry=\"7\" fill=\"#3a2a55\" opacity=\"0.25\"/><rect x=\"314\" y=\"150\" width=\"17\" height=\"198\" rx=\"5\" fill=\"url(#").V(u_125).S("pl)\"/><path d=\"M322 176L304 190\" stroke=\"#3a3a46\" stroke-width=\"9\" stroke-linecap=\"round\"/>");
b_129.S("<g transform=\"rotate(-3 258 160)\"><rect x=\"186\" y=\"104\" width=\"148\" height=\"104\" rx=\"9\" fill=\"#2a2a36\" transform=\"translate(4 5)\" opacity=\"0.35\"/><rect x=\"186\" y=\"104\" width=\"148\" height=\"104\" rx=\"9\" fill=\"url(#").V(u_125).S("bd)\" stroke=\"#e8483c\" stroke-width=\"6\"/>").S("<path d=\"M196 116L240 116L210 196L196 196Z\" fill=\"#ffffff\" opacity=\"0.8\"/><rect x=\"232\" y=\"146\" width=\"54\" height=\"42\" fill=\"none\" stroke=\"#e8483c\" stroke-width=\"5\"/></g>");
b_129.S("<rect x=\"250\" y=\"203\" width=\"16\" height=\"9\" rx=\"2.5\" fill=\"#b8481a\"/><path d=\"M216 214A44 12 0 0 1 304 214\" fill=\"none\" stroke=\"#b8481a\" stroke-width=\"7\" stroke-linecap=\"round\"/>");
b_129.S("<path d=\"M132 226Q188 40 248 178\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"5\" stroke-dasharray=\"1 12\" stroke-linecap=\"round\" opacity=\"0.95\"/>");
b_129.V(Add(Add(Call(spark_22, V.Undef, ((V)(178D)), ((V)(118D)), ((V)(9D))), Call(spark_22, V.Undef, ((V)(212D)), ((V)(138D)), ((V)(5D)))), Call(spark_22, V.Undef, ((V)(146D)), ((V)(160D)), ((V)(6D)))));
b_129.S("<g transform=\"translate(260 202)\"><circle r=\"26\" fill=\"url(#").V(u_125).S("bl)\"/><path d=\"M-26 0H26M0 -26V26M-18 -18Q0 0 -18 18M18 -18Q0 0 18 18\" stroke=\"#6e2c0c\" stroke-width=\"2.4\" fill=\"none\" opacity=\"0.9\"/><ellipse cx=\"-9\" cy=\"-11\" rx=\"9\" ry=\"5.5\" fill=\"#ffffff\" opacity=\"0.35\" transform=\"rotate(-30 -9 -11)\"/></g>");
net_130 = new JsStrBuf("");
{
double i_131 = 0;
i_131 = 0D;
while (true) {
if (!((i_131 <= 10D))) break;
double a_133 = 0;
double x0_134 = 0;
double y0_135 = 0;
double x1_136 = 0;
double y1_137 = 0;
a_133 = ((System.Math.PI * i_131) / 10D);
x0_134 = (260D - (FdLibm.Cos(a_133) * 44D));
y0_135 = (214D + (FdLibm.Sin(a_133) * 12D));
x1_136 = (260D - (FdLibm.Cos(a_133) * 26D));
y1_137 = (262D + (FdLibm.Sin(a_133) * 6D));
net_130.S("M").V(Call(f_17, V.Undef, ((V)(x0_134)))).S(" ").V(Call(f_17, V.Undef, ((V)(y0_135)))).S("L").V(Call(f_17, V.Undef, ((V)(x1_136)))).S(" ").V(Call(f_17, V.Undef, ((V)(y1_137))));
i_131++;
}
}
{
double k_138 = 0;
k_138 = 1D;
while (true) {
if (!((k_138 <= 3D))) break;
double rr_140 = 0;
double yy_141 = 0;
rr_140 = (44D - (k_138 * 6D));
yy_141 = (214D + (k_138 * 16D));
net_130.S("M").V(Call(f_17, V.Undef, ((V)((260D - rr_140))))).S(" ").N(yy_141).S("Q260 ").V(Call(f_17, V.Undef, ((V)((yy_141 + 13D))))).S(" ").V(Call(f_17, V.Undef, ((V)((260D + rr_140))))).S(" ").N(yy_141);
k_138++;
}
}
b_129.S("<path d=\"").S(net_130.Str).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"2.4\" stroke-linecap=\"round\" opacity=\"0.95\"/>");
b_129.S("<path d=\"M216 214A44 12 0 0 0 304 214\" fill=\"none\" stroke=\"#f27a2c\" stroke-width=\"8\" stroke-linecap=\"round\"/><path d=\"M222 217A40 9 0 0 0 298 217\" fill=\"none\" stroke=\"#ffc28a\" stroke-width=\"2\" opacity=\"0.8\"/>");
b_129.V(Call(badge_29, V.Undef, ((V)(66D)), ((V)(168D)), ((V)(32D)), ((V)("SWISH!")), ((V)((-10D))), ((V)("#46c0ff")), ((V)("#1e3a7a")), ((V)(19D))));
b_129.S("<ellipse cx=\"94\" cy=\"334\" rx=\"64\" ry=\"12\" fill=\"#3a2a55\" opacity=\"0.22\"/>").V(Call(stk_26, V.Undef, u_125, Get(c_126, "src"), ((V)(94D)), ((V)(338D)), ((V)(160D)), ((V)((-4D))), (false ? V.True : V.False), NewObj(10).Put("armL", ((V)(125D))).Put("armR", ((V)(150D))).Put("lift", ((V)(8D))).Put("footL", ((V)(1.4))).Put("footR", ((V)(1.4))).Put("sq", ((V)((-0.08)))).Put("ly", ((V)((-0.7)))).Put("lx", ((V)(0.5))).Put("open", ((V)(0.5))).Put("smile", ((V)(0.3))).V));
b_129.V(Add(Add(Call(spark_22, V.Undef, ((V)(308D)), ((V)(240D)), ((V)(8D)), ((V)("#fff6c8"))), Call(spark_22, V.Undef, ((V)(326D)), ((V)(212D)), ((V)(5D)), ((V)("#ffffff")))), Call(spark_22, V.Undef, ((V)(204D)), ((V)(252D)), ((V)(6D)), ((V)("#fff6c8")))));
return Call(wrap_30, V.Undef, u_125, defs_128, ((V)(JsStrBuf.Begin().S(b_129.Str).V(Get(L_127, "body")).End())));
return default;
}, 2, "hoop", false);
soccer_34 = Fn((V _self142, int _argc143, V u_149, V c_150, V _a147, V _a148, V[] _rest144) => {
V L_151 = default;
V defs_152 = default;
double GX0_153 = 0;
double GX1_154 = 0;
double GY0_155 = 0;
double GY1_156 = 0;
double BX_157 = 0;
double BY_158 = 0;
JsStrBuf b_159 = null;
double KX_160 = 0;
double KY_161 = 0;
double KW_162 = 0;
double KR_163 = 0;
double hx_164 = 0;
double hy_165 = 0;
V pent_166 = default;
double MX_167 = 0;
double MY_168 = 0;
if (_self142.IsNullish) _self142 = GlobalV;
L_151 = Call(logo_25, V.Undef, u_149, Arr(((V)("PENALTY KICK"))), ((V)(214D)), ((V)(54D)), NewObj(7).Put("size", ((V)(44D))).Put("top", ((V)("#ffffff"))).Put("bot", ((V)("#9fe0ff"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#123a7a"))).Put("shade", ((V)("#0a2050"))).Put("rot", ((V)((-3D)))).V);
defs_152 = ((V)(JsStrBuf.Begin().V(Add(Add(Add(Add(Get(L_151, "defs"), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_149).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#3aaaf6"))), Arr(((V)(0.6)), ((V)("#9fdcff"))), Arr(((V)(1D)), ((V)("#e6f8ff")))))), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_149).S("gr").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#8fd86a"))), Arr(((V)(1D)), ((V)("#4e9e3c")))))), Call(rg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_149).S("bl").End())), ((V)("36%")), ((V)("30%")), ((V)("72%")), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(0.65)), ((V)("#eef0f6"))), Arr(((V)(1D)), ((V)("#a9aec0")))))), Call(rg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_149).S("im").End())), ((V)("50%")), ((V)("50%")), ((V)("50%")), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(0.45)), ((V)("#fff3a0"))), Arr(((V)(1D)), ((V)("#ffd84a")), ((V)(0D))))))).S("<clipPath id=\"").V(u_149).S("bc\"><circle r=\"20\"/></clipPath>").End()));
GX0_153 = 174D;
GX1_154 = 424D;
GY0_155 = 104D;
GY1_156 = 276D;
BX_157 = 202D;
BY_158 = 134D;
b_159 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"780\" height=\"360\" fill=\"url(#").V(u_149).S("sk)\"/>").V(Call(rays_21, V.Undef, ((V)(BX_157)), ((V)(BY_158)), ((V)(26D)), ((V)("#ffffff")), ((V)(0.15)))).V(Call(cloud_23, V.Undef, ((V)(86D)), ((V)(120D)), ((V)(0.55)), ((V)(0.7)))).V(Call(cloud_23, V.Undef, ((V)(520D)), ((V)(66D)), ((V)(0.5)), ((V)(0.65)))).V(Call(cloud_23, V.Undef, ((V)(660D)), ((V)(120D)), ((V)(0.4)), ((V)(0.6)))).End());
b_159.V(Call(backdrop_32, V.Undef, ((V)(196D)), Arr(((V)("#4f9a3e")), ((V)("#62ad4c"))), ((V)(0.9))));
b_159.S("<path d=\"M-20 190H800V380H-20Z\" fill=\"url(#").V(u_149).S("gr)\"/>");
{
double i_169 = 0;
i_169 = (-6D);
while (true) {
if (!((i_169 < 12D))) break;
double x0_171 = 0;
x0_171 = (310D + (i_169 * 60D));
b_159.S("<path d=\"M").V(Call(f_17, V.Undef, ((V)((310D + ((x0_171 - 310D) * 0.4)))))).S(" 190L").V(Call(f_17, V.Undef, ((V)((310D + (((x0_171 + 30D) - 310D) * 0.4)))))).S(" 190L").V(Call(f_17, V.Undef, ((V)((310D + (((x0_171 + 30D) - 310D) * 2.4)))))).S(" 380L").V(Call(f_17, V.Undef, ((V)((310D + ((x0_171 - 310D) * 2.4)))))).S(" 380Z\" fill=\"#ffffff\" opacity=\"0.07\"/>");
i_169++;
}
}
b_159.S("<g fill=\"none\" stroke=\"#ffffff\" stroke-width=\"3.2\" opacity=\"0.8\" stroke-linejoin=\"round\"><path d=\"M60 ").N(GY1_156).S("H560\"/><path d=\"M150 ").N(GY1_156).S("L118 300H500L470 ").N(GY1_156).S("\"/><path d=\"M40 ").N(GY1_156).S("L-20 340\"/></g><ellipse cx=\"300\" cy=\"328\" rx=\"7\" ry=\"2.6\" fill=\"#ffffff\" opacity=\"0.9\"/>");
b_159.S("<path d=\"M").N(GX0_153).S(" ").N(GY1_156).S("L").N((GX0_153 + 22D)).S(" ").N((GY1_156 - 16D)).S("H").N((GX1_154 + 22D)).S("L").N(GX1_154).S(" ").N(GY1_156).S("Z\" fill=\"#2a4a20\" opacity=\"0.18\"/>");
b_159.S("<path d=\"M").N((GX0_153 + 22D)).S(" ").N((GY0_155 - 14D)).S("H").N((GX1_154 + 22D)).S("V").N((GY1_156 - 16D)).S("H").N((GX0_153 + 22D)).S("Z\" fill=\"#ffffff\" opacity=\"0.18\"/><g stroke=\"#ffffff\" stroke-width=\"1.3\" opacity=\"0.7\" fill=\"none\">");
{
double x_172 = 0;
x_172 = (GX0_153 + 22D);
while (true) {
if (!((x_172 <= (GX1_154 + 22D)))) break;
b_159.S("<path d=\"M").N(x_172).S(" ").N((GY0_155 - 14D)).S("V").N((GY1_156 - 16D)).S("\"/>");
x_172 = (x_172 + 13D);
}
}
{
double y_174 = 0;
y_174 = (GY0_155 - 14D);
while (true) {
if (!((y_174 <= (GY1_156 - 16D)))) break;
b_159.S("<path d=\"M").N((GX0_153 + 22D)).S(" ").N(y_174).S("H").N((GX1_154 + 22D)).S("\"/>");
y_174 = (y_174 + 13D);
}
}
{
double k_176 = 0;
k_176 = 0D;
while (true) {
if (!((k_176 <= 6D))) break;
double y_178 = 0;
y_178 = (GY0_155 + (((GY1_156 - GY0_155) * k_176) / 6D));
b_159.S("<path d=\"M").N(GX1_154).S(" ").V(Call(f_17, V.Undef, ((V)(y_178)))).S("L").N((GX1_154 + 22D)).S(" ").V(Call(f_17, V.Undef, ((V)((y_178 - 15D))))).S("\"/>");
k_176++;
}
}
b_159.S("<path d=\"M").N(GX0_153).S(" ").N(GY0_155).S("L").N((GX0_153 + 22D)).S(" ").N((GY0_155 - 14D)).S("M").N(GX1_154).S(" ").N(GY0_155).S("L").N((GX1_154 + 22D)).S(" ").N((GY0_155 - 14D)).S("\"/></g>");
b_159.S("<path d=\"M").N(GX0_153).S(" ").N((GY1_156 + 2D)).S("V").N(GY0_155).S("H").N(GX1_154).S("V").N((GY1_156 + 2D)).S("\" fill=\"none\" stroke=\"#3a4a6a\" stroke-width=\"11\" stroke-linejoin=\"round\" opacity=\"0.3\" transform=\"translate(3 4)\"/><path d=\"M").N(GX0_153).S(" ").N((GY1_156 + 2D)).S("V").N(GY0_155).S("H").N(GX1_154).S("V").N((GY1_156 + 2D)).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"10\" stroke-linejoin=\"round\"/><path d=\"M").N((GX0_153 + 3D)).S(" ").N((GY1_156 + 1D)).S("V").N((GY0_155 + 3D)).S("H").N((GX1_154 - 3D)).S("V").N((GY1_156 + 1D)).S("\" fill=\"none\" stroke=\"#dfe6f2\" stroke-width=\"2.4\"/>");
KX_160 = 328D;
KY_161 = 226D;
KW_162 = 150D;
KR_163 = (-12D);
hx_164 = (KX_160 - ((0.55 * KW_162) * FdLibm.Sin((((-KR_163) * System.Math.PI) / 180D))));
hy_165 = (KY_161 - ((0.55 * KW_162) * FdLibm.Cos(((KR_163 * System.Math.PI) / 180D))));
b_159.S("<ellipse cx=\"").N((KX_160 - 14D)).S("\" cy=\"").N((GY1_156 - 2D)).S("\" rx=\"46\" ry=\"8\" fill=\"#2a4a20\" opacity=\"0.22\"/>").V(Call(speed_24, V.Undef, ((V)((KX_160 + 30D))), ((V)((KY_161 - 70D))), ((V)((System.Math.PI + 0.25))), ((V)(3D)), ((V)(44D)), ((V)("#ffffff")), ((V)(0.8))));
b_159.V(Call(stk_26, V.Undef, u_149, ((V)("")), ((V)(KX_160)), ((V)(KY_161)), ((V)(KW_162)), ((V)(KR_163)), (false ? V.True : V.False), NewObj(10).Put("armL", ((V)(130D))).Put("armR", ((V)(150D))).Put("hLx", ((V)((-14D)))).Put("hLy", ((V)((-28D)))).Put("teary", ((V)(1D))).Put("open", ((V)(1D))).Put("footR", ((V)(5D))).Put("lx", ((V)((-1D)))).Put("ly", ((V)((-1D)))).Put("sq", ((V)((-0.04)))).V, V.Null, ((V)("opp"))));
Invoke(Arr(Arr(((V)((hx_164 + 56D))), ((V)((hy_165 - 30D))), ((V)(7D)), ((V)(20D))), Arr(((V)((hx_164 + 66D))), ((V)((hy_165 - 6D))), ((V)(5.5)), ((V)(34D))), Arr(((V)((hx_164 + 42D))), ((V)((hy_165 - 50D))), ((V)(4.5)), ((V)(8D)))), "forEach", Fn((V _self142, int _argc179, V _a181, V _a182, V _a183, V _a184, V[] _rest180) => {
V x_187 = default;
V y_189 = default;
V r_191 = default;
V a_193 = default;
{ V _t185 = ListOf(_a181);
{ V _t186 = GetIdx(_t185, 0D);
x_187 = _t186; }
{ V _t188 = GetIdx(_t185, 1D);
y_189 = _t188; }
{ V _t190 = GetIdx(_t185, 2D);
r_191 = _t190; }
{ V _t192 = GetIdx(_t185, 3D);
a_193 = _t192; }
}
b_159.S("<path transform=\"translate(").V(Call(f_17, V.Undef, x_187)).S(" ").V(Call(f_17, V.Undef, y_189)).S(") rotate(").V(a_193).S(") scale(").V(Call(f_17, V.Undef, ((V)((ToNum(r_191) / 6D))))).S(")\" d=\"M0 -9Q6 -1 6 3A6 6 0 0 1 -6 3Q-6 -1 0 -9Z\" fill=\"#bfe8ff\" stroke=\"#3f8fd0\" stroke-width=\"1.6\"/>");
return default;
}, 1, "", true));
b_159.S("<g stroke=\"#1d3a6a\" stroke-width=\"3\" stroke-linecap=\"round\">").V(Invoke(Invoke(Arr(((V)((-118D))), ((V)((-92D))), ((V)((-66D)))), "map", Fn((V _self142, int _argc194, V d_200, V _a197, V _a198, V _a199, V[] _rest195) => {
double t_201 = 0;
t_201 = ((ToNum(d_200) * System.Math.PI) / 180D);
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f_17, V.Undef, ((V)((hx_164 + (FdLibm.Cos(t_201) * 64D)))))).S(" ").V(Call(f_17, V.Undef, ((V)((hy_165 + (FdLibm.Sin(t_201) * 64D)))))).S("L").V(Call(f_17, V.Undef, ((V)((hx_164 + (FdLibm.Cos(t_201) * 80D)))))).S(" ").V(Call(f_17, V.Undef, ((V)((hy_165 + (FdLibm.Sin(t_201) * 80D)))))).S("\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>");
b_159.V(Call(badge_29, V.Undef, ((V)((hx_164 + 76D))), ((V)((hy_165 - 62D))), ((V)(19D)), ((V)("!!")), ((V)(10D)), ((V)("#ff6f7a")), ((V)("#7a1428")), ((V)(20D))));
b_159.S("<path d=\"M150 296Q164 196 ").N((BX_157 - 12D)).S(" ").N((BY_158 + 14D)).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"7\" stroke-linecap=\"round\" stroke-dasharray=\"2 13\" opacity=\"0.9\"/>").V(Call(speed_24, V.Undef, ((V)(BX_157)), ((V)(BY_158)), ((V)((-1.32))), ((V)(5D)), ((V)(70D)), ((V)("#ffffff")), ((V)(0.85))));
b_159.S("<g transform=\"translate(").N(BX_157).S(" ").N(BY_158).S(") rotate(24)\"><circle r=\"20\" fill=\"url(#").V(u_149).S("bl)\" stroke=\"#5a6078\" stroke-width=\"1.4\"/><g clip-path=\"url(#").V(u_149).S("bc)\" fill=\"#2a2a3a\">");
pent_166 = Fn((V _self142, int _argc202, V cx_208, V cy_209, V r_210, V a_211, V[] _rest203) => {
JsStrBuf d_212 = null;
d_212 = new JsStrBuf("");
{
double i_213 = 0;
i_213 = 0D;
while (true) {
if (!((i_213 < 5D))) break;
V t_215 = default;
t_215 = Add(a_211, ((V)(((i_213 / 5D) * TAU_16))));
d_212.S((NumTruthy(i_213) ? "L" : "M")).V(Call(f_17, V.Undef, Add(cx_208, ((V)((FdLibm.Cos(ToNum(t_215)) * ToNum(r_210))))))).S(" ").V(Call(f_17, V.Undef, Add(cy_209, ((V)((FdLibm.Sin(ToNum(t_215)) * ToNum(r_210)))))));
i_213++;
}
}
return ((V)(string.Concat("<path d=\"", d_212.Str, "Z\"/>")));
return default;
}, 4, "", true);
b_159.V(Call(pent_166, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(6.8)), ((V)(((-System.Math.PI) / 2D)))));
{
double i_216 = 0;
i_216 = 0D;
while (true) {
if (!((i_216 < 5D))) break;
double t_218 = 0;
t_218 = (((-System.Math.PI) / 2D) + (((i_216 + 0.5) / 5D) * TAU_16));
b_159.V(Call(pent_166, V.Undef, ((V)((FdLibm.Cos(t_218) * 19.5))), ((V)((FdLibm.Sin(t_218) * 19.5))), ((V)(6.8)), ((V)((t_218 + System.Math.PI)))));
i_216++;
}
}
b_159.S("</g><g stroke=\"#2a2a3a\" stroke-width=\"1.3\">");
{
double i_219 = 0;
i_219 = 0D;
while (true) {
if (!((i_219 < 5D))) break;
double t_221 = 0;
t_221 = (((-System.Math.PI) / 2D) + ((i_219 / 5D) * TAU_16));
b_159.S("<path d=\"M").V(Call(f_17, V.Undef, ((V)((FdLibm.Cos(t_221) * 6.8))))).S(" ").V(Call(f_17, V.Undef, ((V)((FdLibm.Sin(t_221) * 6.8))))).S("L").V(Call(f_17, V.Undef, ((V)((FdLibm.Cos(t_221) * 13.5))))).S(" ").V(Call(f_17, V.Undef, ((V)((FdLibm.Sin(t_221) * 13.5))))).S("\"/>");
i_219++;
}
}
b_159.S("</g><ellipse cx=\"-7\" cy=\"-9\" rx=\"7\" ry=\"4\" fill=\"#ffffff\" opacity=\"0.6\" transform=\"rotate(-30 -7 -9)\"/></g>");
b_159.V(Add(Add(Call(spark_22, V.Undef, ((V)((BX_157 - 30D))), ((V)((BY_158 - 28D))), ((V)(7D))), Call(spark_22, V.Undef, ((V)((BX_157 + 34D))), ((V)((BY_158 - 18D))), ((V)(5D)))), Call(spark_22, V.Undef, ((V)(440D)), ((V)(60D)), ((V)(6D)), ((V)("#fff6c8")))));
MX_167 = 96D;
MY_168 = 344D;
b_159.S("<ellipse cx=\"").N((MX_167 + 6D)).S("\" cy=\"").N((MY_168 - 2D)).S("\" rx=\"62\" ry=\"11\" fill=\"#2a4a20\" opacity=\"0.24\"/>");
b_159.S("<circle cx=\"152\" cy=\"300\" r=\"34\" fill=\"url(#").V(u_149).S("im)\"/><path d=\"M152 266L158 288L178 278L164 296L186 304L162 308L170 330L152 314L136 330L142 308L118 306L140 296L126 280L146 288Z\" fill=\"#fff6c8\" stroke=\"#ffb020\" stroke-width=\"2\" stroke-linejoin=\"round\" opacity=\"0.95\"/>");
b_159.S("<path d=\"M88 338Q118 346 140 324Q154 308 152 286\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"9\" stroke-linecap=\"round\" opacity=\"0.75\"/><path d=\"M96 330Q120 334 136 318\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"4\" stroke-linecap=\"round\" opacity=\"0.9\"/>");
b_159.V(Call(stk_26, V.Undef, u_149, Get(c_150, "src"), ((V)(MX_167)), ((V)(MY_168)), ((V)(176D)), ((V)((-8D))), (false ? V.True : V.False), NewObj(9).Put("footR", ((V)(10D))).Put("lean", ((V)(2D))).Put("armL", ((V)(40D))).Put("armR", ((V)(152D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.6))).Put("hap", ((V)(0.7))).Put("tilt", ((V)((-6D)))).Put("sq", ((V)((-0.04)))).V, V.Null, V.Null, ((V)(50D))));
return Call(wrapL_31, V.Undef, u_149, defs_152, ((V)(JsStrBuf.Begin().S(b_159.Str).V(Get(L_151, "body")).End())));
return default;
}, 2, "soccer", false);
hop_35 = Fn((V _self222, int _argc223, V u_229, V c_230, V _a227, V _a228, V[] _rest224) => {
V P_231 = default;
V L_232 = default;
V defs_233 = default;
JsStrBuf b_234 = null;
V q_235 = default;
V cells_236 = default;
V tint_237 = default;
JsStrBuf ch_238 = null;
V d1_239 = default;
V d2_240 = default;
V d3_241 = default;
V d4_242 = default;
V pb_243 = default;
V ck_244 = default;
V sh_245 = default;
if (_self222.IsNullish) _self222 = GlobalV;
P_231 = Fn((V _self222, int _argc246, V x_252, V z_253, V _a250, V _a251, V[] _rest247) => {
double s_254 = 0;
s_254 = (1D / (1D + (ToNum(z_253) * 0.2)));
return Arr(Call(f_17, V.Undef, ((V)((150D + ((ToNum(x_252) * 118D) * s_254))))), Call(f_17, V.Undef, ((V)((122D + (268D * s_254))))), ((V)(s_254)));
return default;
}, 2, "", true);
L_232 = Call(logo_25, V.Undef, u_229, Arr(((V)("HOPSCOTCH"))), ((V)(180D)), ((V)(76D)), NewObj(8).Put("size", ((V)(46D))).Put("top", ((V)("#ffe0f2"))).Put("bot", ((V)("#ff6fb8"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#6a1a52"))).Put("shade", ((V)("#3e0c30"))).Put("rot", ((V)((-3D)))).Put("ls", ((V)(1D))).V);
defs_233 = ((V)(JsStrBuf.Begin().V(Add(Add(Get(L_232, "defs"), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_229).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#ffb0d8"))), Arr(((V)(1D)), ((V)("#ffe6c8")))))), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_229).S("pv").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#cfc6cc"))), Arr(((V)(1D)), ((V)("#a99ea6"))))))).S("<filter id=\"").V(u_229).S("ch\" x=\"-5%\" y=\"-5%\" width=\"110%\" height=\"110%\"><feTurbulence type=\"fractalNoise\" baseFrequency=\"0.9\" numOctaves=\"2\" seed=\"3\" result=\"n\"/><feDisplacementMap in=\"SourceGraphic\" in2=\"n\" scale=\"2.6\" xChannelSelector=\"R\" yChannelSelector=\"G\" result=\"dd\"/><feComposite in=\"dd\" in2=\"n\" operator=\"in\"/></filter>").End()));
b_234 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-420\" width=\"1400\" height=\"640\" fill=\"url(#").V(u_229).S("sk)\"/>").V(Call(rays_21, V.Undef, ((V)(180D)), ((V)(118D)), ((V)(26D)), ((V)("#ffffff")), ((V)(0.18)))).End());
b_234.V(Call(backdrop_32, V.Undef, ((V)(122D)), Arr(((V)("#7cc06a")), ((V)("#93d07c"))), ((V)(0.75))));
q_235 = Fn((V _self222, int _argc255, V pts_261, V a_262, V _a259, V _a260, V[] _rest256) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Invoke(Invoke(pts_261, "map", Fn((V _self222, int _argc263, V p_269, V _a266, V _a267, V _a268, V[] _rest264) => {
return ((V)(JsStrBuf.Begin().V(GetIdx(p_269, 0D)).S(" ").V(GetIdx(p_269, 1D)).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z\" ").V(a_262).S("/>").End()));
}, 2, "", true);
b_234.S("<path d=\"M-420 118H980V640H-420Z\" fill=\"#7cc46a\"/>").V(Call(q_235, V.Undef, Arr(Call(P_231, V.Undef, ((V)((-1.55))), ((V)(40D))), Call(P_231, V.Undef, ((V)(1.55)), ((V)(40D))), Call(P_231, V.Undef, ((V)(1.55)), ((V)((-1.2)))), Call(P_231, V.Undef, ((V)((-1.55))), ((V)((-1.2))))), ((V)(JsStrBuf.Begin().S("fill=\"url(#").V(u_229).S("pv)\"").End()))));
{
double z_270 = 0;
z_270 = 0D;
while (true) {
if (!((z_270 < 30D))) break;
V a_272 = default;
V b2_273 = default;
a_272 = Call(P_231, V.Undef, ((V)((-1.55))), ((V)(z_270)));
b2_273 = Call(P_231, V.Undef, ((V)(1.55)), ((V)(z_270)));
b_234.S("<path d=\"M").V(GetIdx(a_272, 0D)).S(" ").V(GetIdx(a_272, 1D)).S("L").V(GetIdx(b2_273, 0D)).S(" ").V(GetIdx(b2_273, 1D)).S("\" stroke=\"#958a92\" stroke-width=\"").V(Call(f_17, V.Undef, ((V)((1.6 * ToNum(GetIdx(a_272, 2D))))))).S("\" opacity=\"0.7\"/>");
z_270 = (z_270 + 1.6);
}
}
b_234.V(Add(Call(q_235, V.Undef, Arr(Call(P_231, V.Undef, ((V)((-1.55))), ((V)(40D))), Call(P_231, V.Undef, ((V)((-1.45))), ((V)(40D))), Call(P_231, V.Undef, ((V)((-1.45))), ((V)((-1.2)))), Call(P_231, V.Undef, ((V)((-1.55))), ((V)((-1.2))))), ((V)("fill=\"#e6dde2\""))), Call(q_235, V.Undef, Arr(Call(P_231, V.Undef, ((V)(1.45)), ((V)(40D))), Call(P_231, V.Undef, ((V)(1.55)), ((V)(40D))), Call(P_231, V.Undef, ((V)(1.55)), ((V)((-1.2)))), Call(P_231, V.Undef, ((V)(1.45)), ((V)((-1.2))))), ((V)("fill=\"#e6dde2\"")))));
cells_236 = Arr(Arr(((V)((-0.5))), ((V)(0.5)), ((V)(0D)), ((V)(1D)), ((V)("1"))), Arr(((V)((-1D))), ((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)("2"))), Arr(((V)(0D)), ((V)(1D)), ((V)(1D)), ((V)(2D)), ((V)("3"))), Arr(((V)((-0.5))), ((V)(0.5)), ((V)(2D)), ((V)(3D)), ((V)("4"))), Arr(((V)((-1D))), ((V)(0D)), ((V)(3D)), ((V)(4D)), ((V)("5"))), Arr(((V)(0D)), ((V)(1D)), ((V)(3D)), ((V)(4D)), ((V)("6"))), Arr(((V)((-0.5))), ((V)(0.5)), ((V)(4D)), ((V)(5D)), ((V)("7"))), Arr(((V)((-1D))), ((V)(0D)), ((V)(5D)), ((V)(6D)), ((V)("8"))), Arr(((V)(0D)), ((V)(1D)), ((V)(5D)), ((V)(6D)), ((V)("9"))), Arr(((V)((-0.5))), ((V)(0.5)), ((V)(6D)), ((V)(7D)), ((V)("10"))));
tint_237 = Arr(((V)("#ff9fd0")), ((V)("#9fd8ff")), ((V)("#fff09a")), ((V)("#b6f0a0")));
ch_238 = new JsStrBuf("");
Invoke(cells_236, "forEach", Fn((V _self222, int _argc274, V _a276, V i_280, V _a278, V _a279, V[] _rest275) => {
V a_292 = default;
V b2_293 = default;
V cc_294 = default;
V d_295 = default;
V m_296 = default;
V x0_283 = default;
V x1_285 = default;
V z0_287 = default;
V z1_289 = default;
V n_291 = default;
{ V _t281 = ListOf(_a276);
{ V _t282 = GetIdx(_t281, 0D);
x0_283 = _t282; }
{ V _t284 = GetIdx(_t281, 1D);
x1_285 = _t284; }
{ V _t286 = GetIdx(_t281, 2D);
z0_287 = _t286; }
{ V _t288 = GetIdx(_t281, 3D);
z1_289 = _t288; }
{ V _t290 = GetIdx(_t281, 4D);
n_291 = _t290; }
}
a_292 = Call(P_231, V.Undef, x0_283, z0_287);
b2_293 = Call(P_231, V.Undef, x1_285, z0_287);
cc_294 = Call(P_231, V.Undef, x1_285, z1_289);
d_295 = Call(P_231, V.Undef, x0_283, z1_289);
m_296 = Call(P_231, V.Undef, ((V)((ToNum(Add(x0_283, x1_285)) / 2D))), ((V)((ToNum(Add(z0_287, z1_289)) / 2D))));
ch_238.V(Call(q_235, V.Undef, Arr(a_292, b2_293, cc_294, d_295), ((V)(JsStrBuf.Begin().S("fill=\"").V(GetIdx(tint_237, (ToNum(i_280) % 4D))).S("\" fill-opacity=\"0.32\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f_17, V.Undef, ((V)((4.2 * ToNum(GetIdx(a_292, 2D))))))).S("\" stroke-linejoin=\"round\"").End()))));
ch_238.S("<text x=\"").V(GetIdx(m_296, 0D)).S("\" y=\"").V(Call(f_17, V.Undef, Add(GetIdx(m_296, 1D), ((V)((9D * ToNum(GetIdx(m_296, 2D)))))))).S("\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"").V(Call(f_17, V.Undef, ((V)((27D * ToNum(GetIdx(m_296, 2D))))))).S("\" text-anchor=\"middle\" fill=\"").V(GetIdx(Arr(((V)("#ff5fae")), ((V)("#3aa8f0")), ((V)("#f0b400")), ((V)("#4cbf3a"))), (ToNum(i_280) % 4D))).S("\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f_17, V.Undef, ((V)((1.6 * ToNum(GetIdx(m_296, 2D))))))).S("\" paint-order=\"stroke fill\">").V(n_291).S("</text>");
return default;
}, 2, "", true));
{
JsStrBuf d_297 = null;
V hm_298 = default;
d_297 = new JsStrBuf("");
{
double i_299 = 0;
i_299 = 0D;
while (true) {
if (!((i_299 <= 16D))) break;
double t_301 = 0;
V p_302 = default;
t_301 = ((System.Math.PI * i_299) / 16D);
p_302 = Call(P_231, V.Undef, ((V)(((-FdLibm.Cos(t_301)) * 0.75))), ((V)((7D + (FdLibm.Sin(t_301) * 0.9)))));
d_297.S((NumTruthy(i_299) ? "L" : "M")).V(GetIdx(p_302, 0D)).S(" ").V(GetIdx(p_302, 1D));
i_299++;
}
}
hm_298 = Call(P_231, V.Undef, ((V)(0D)), ((V)(7.4)));
ch_238.S("<path d=\"").S(d_297.Str).S("Z\" fill=\"#d9b8ff\" fill-opacity=\"0.35\" stroke=\"#ffffff\" stroke-width=\"2.4\"/><text x=\"").V(GetIdx(hm_298, 0D)).S("\" y=\"").V(Call(f_17, V.Undef, Add(GetIdx(hm_298, 1D), ((V)(4D))))).S("\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"11\" text-anchor=\"middle\" fill=\"#9a5ae0\" stroke=\"#ffffff\" stroke-width=\"1\" paint-order=\"stroke fill\">HOME</text>");
}
d1_239 = Call(P_231, V.Undef, ((V)((-1.2))), ((V)(0.9)));
d2_240 = Call(P_231, V.Undef, ((V)(1.2)), ((V)(5.6)));
d3_241 = Call(P_231, V.Undef, ((V)((-1.25))), ((V)(4.4)));
d4_242 = Call(P_231, V.Undef, ((V)((-1.25))), ((V)(2.5)));
ch_238.S("<path transform=\"translate(").V(GetIdx(d1_239, 0D)).S(" ").V(GetIdx(d1_239, 1D)).S(") scale(").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(d1_239, 2D)) * 1.3))))).S(")\" d=\"M0 -13L3.8 -4.6L13 -4.2L5.8 1.6L8.2 10.6L0 5.4L-8.2 10.6L-5.8 1.6L-13 -4.2L-3.8 -4.6Z\" fill=\"none\" stroke=\"#fff09a\" stroke-width=\"2.6\" stroke-linejoin=\"round\"/>");
ch_238.S("<path transform=\"translate(").V(GetIdx(d2_240, 0D)).S(" ").V(GetIdx(d2_240, 1D)).S(") scale(").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(d2_240, 2D)) * 1.3))))).S(")\" d=\"M0 9C-14 0 -12 -12 -5 -11C-2 -10.5 0 -8 0 -6C0 -8 2 -10.5 5 -11C12 -12 14 0 0 9Z\" fill=\"none\" stroke=\"#ff9fd0\" stroke-width=\"2.6\" stroke-linejoin=\"round\"/>");
ch_238.S("<g transform=\"translate(").V(GetIdx(d3_241, 0D)).S(" ").V(GetIdx(d3_241, 1D)).S(") scale(").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(d3_241, 2D)) * 1.2))))).S(")\" fill=\"none\" stroke=\"#9fd8ff\" stroke-width=\"2.4\" stroke-linecap=\"round\"><circle r=\"6\"/><path d=\"M0 -10V-14M0 10V14M-10 0H-14M10 0H14M7 -7L10 -10M-7 7L-10 10M7 7L10 10M-7 -7L-10 -10\"/></g>");
ch_238.S("<g transform=\"translate(").V(GetIdx(d4_242, 0D)).S(" ").V(GetIdx(d4_242, 1D)).S(") scale(").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(d4_242, 2D)) * 1.2))))).S(")\" fill=\"none\" stroke=\"#b6f0a0\" stroke-width=\"2.4\" stroke-linecap=\"round\"><path d=\"M-10 6Q0 -12 10 6\"/><path d=\"M-6 6Q0 -4 6 6\"/></g>");
b_234.S("<g filter=\"url(#").V(u_229).S("ch)\">").S(ch_238.Str).S("</g>");
pb_243 = Call(P_231, V.Undef, ((V)(0.1)), ((V)(4.55)));
b_234.S("<ellipse cx=\"").V(GetIdx(pb_243, 0D)).S("\" cy=\"").V(Call(f_17, V.Undef, Add(GetIdx(pb_243, 1D), ((V)(2D))))).S("\" rx=\"").V(Call(f_17, V.Undef, ((V)((10D * ToNum(GetIdx(pb_243, 2D))))))).S("\" ry=\"").V(Call(f_17, V.Undef, ((V)((4D * ToNum(GetIdx(pb_243, 2D))))))).S("\" fill=\"#4a3a48\" opacity=\"0.3\"/><ellipse cx=\"").V(GetIdx(pb_243, 0D)).S("\" cy=\"").V(GetIdx(pb_243, 1D)).S("\" rx=\"").V(Call(f_17, V.Undef, ((V)((9D * ToNum(GetIdx(pb_243, 2D))))))).S("\" ry=\"").V(Call(f_17, V.Undef, ((V)((6D * ToNum(GetIdx(pb_243, 2D))))))).S("\" fill=\"#8a7f92\" stroke=\"#5a5064\" stroke-width=\"1\"/><ellipse cx=\"").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(pb_243, 0D)) - 2D))))).S("\" cy=\"").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(pb_243, 1D)) - 2D))))).S("\" rx=\"").V(Call(f_17, V.Undef, ((V)((3D * ToNum(GetIdx(pb_243, 2D))))))).S("\" ry=\"").V(Call(f_17, V.Undef, ((V)((1.6 * ToNum(GetIdx(pb_243, 2D))))))).S("\" fill=\"#ffffff\" opacity=\"0.5\"/>");
ck_244 = Call(P_231, V.Undef, ((V)((-1.25))), ((V)(0.2)));
b_234.S("<g transform=\"translate(").V(GetIdx(ck_244, 0D)).S(" ").V(GetIdx(ck_244, 1D)).S(") rotate(-24)\"><rect x=\"-14\" y=\"-4.5\" width=\"28\" height=\"9\" rx=\"4.5\" fill=\"#ff9fd0\"/><rect x=\"-14\" y=\"-4.5\" width=\"9\" height=\"9\" rx=\"4.5\" fill=\"#ffffff\" opacity=\"0.6\"/></g>");
sh_245 = Call(P_231, V.Undef, ((V)(1.22)), ((V)(1.2)));
b_234.S("<ellipse cx=\"").V(GetIdx(sh_245, 0D)).S("\" cy=\"").V(GetIdx(sh_245, 1D)).S("\" rx=\"").V(Call(f_17, V.Undef, ((V)((52D * ToNum(GetIdx(sh_245, 2D))))))).S("\" ry=\"").V(Call(f_17, V.Undef, ((V)((12D * ToNum(GetIdx(sh_245, 2D))))))).S("\" fill=\"#3a2040\" opacity=\"0.25\"/>");
b_234.S("<g fill=\"#ffffff\" opacity=\"0.7\"><circle cx=\"").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(sh_245, 0D)) - 40D))))).S("\" cy=\"").V(Call(f_17, V.Undef, Add(GetIdx(sh_245, 1D), ((V)(2D))))).S("\" r=\"6\"/><circle cx=\"").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(sh_245, 0D)) - 50D))))).S("\" cy=\"").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(sh_245, 1D)) - 6D))))).S("\" r=\"4\"/><circle cx=\"").V(Call(f_17, V.Undef, Add(GetIdx(sh_245, 0D), ((V)(44D))))).S("\" cy=\"").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(sh_245, 1D)) - 2D))))).S("\" r=\"5\"/></g>");
b_234.V(Call(stk_26, V.Undef, u_229, Get(c_230, "src"), GetIdx(sh_245, 0D), Call(f_17, V.Undef, ((V)((ToNum(GetIdx(sh_245, 1D)) - 40D)))), ((V)(128D)), ((V)((-8D))), (false ? V.True : V.False), NewObj(8).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(6D))).Put("footL", ((V)(3D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("tilt", ((V)(2D))).Put("smile", ((V)(0.5))).Put("open", ((V)(0.3))).V));
b_234.S("<path d=\"M").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(sh_245, 0D)) - 52D))))).S(" ").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(sh_245, 1D)) - 66D))))).S("q-10 14 -2 30M").V(Call(f_17, V.Undef, Add(GetIdx(sh_245, 0D), ((V)(54D))))).S(" ").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(sh_245, 1D)) - 70D))))).S("q10 14 2 30\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"3.5\" stroke-linecap=\"round\" opacity=\"0.85\"/>");
b_234.V(Add(Add(Call(spark_22, V.Undef, ((V)(60D)), ((V)(170D)), ((V)(7D))), Call(spark_22, V.Undef, ((V)(318D)), ((V)(168D)), ((V)(6D)))), Call(spark_22, V.Undef, ((V)(226D)), ((V)(150D)), ((V)(4D)))));
return Call(wrap_30, V.Undef, u_229, defs_233, ((V)(JsStrBuf.Begin().S(b_234.Str).V(Get(L_232, "body")).End())));
return default;
}, 2, "hop", false);
tramp_36 = Fn((V _self303, int _argc304, V u_310, V c_311, V _a308, V _a309, V[] _rest305) => {
V L_312 = default;
V defs_313 = default;
JsStrBuf b_314 = null;
if (_self303.IsNullish) _self303 = GlobalV;
L_312 = Call(logo_25, V.Undef, u_310, Arr(((V)("BOUNCE UP!"))), ((V)(180D)), ((V)(80D)), NewObj(7).Put("size", ((V)(52D))).Put("top", ((V)("#ffffff"))).Put("bot", ((V)("#b9c2ff"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#2a1f7a"))).Put("shade", ((V)("#160f48"))).Put("rot", ((V)((-4D)))).V);
defs_313 = Add(Add(Add(Get(L_312, "defs"), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_310).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#2e2f9a"))), Arr(((V)(0.38)), ((V)("#6f78f0"))), Arr(((V)(0.75)), ((V)("#a9cbff"))), Arr(((V)(1D)), ((V)("#dff0ff")))))), Call(rg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_310).S("gl").End())), ((V)("50%")), ((V)("50%")), ((V)("50%")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.7))), Arr(((V)(1D)), ((V)("#ffffff")), ((V)(0D)))))), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_310).S("mt").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#3a3a4e"))), Arr(((V)(1D)), ((V)("#1e1e2a"))))));
b_314 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-420\" width=\"1400\" height=\"640\" fill=\"url(#").V(u_310).S("sk)\"/>").V(Call(rays_21, V.Undef, ((V)(180D)), ((V)(214D)), ((V)(24D)), ((V)("#ffffff")), ((V)(0.1)))).End());
Invoke(Arr(Arr(((V)(30D)), ((V)(40D)), ((V)(5D))), Arr(((V)(76D)), ((V)(120D)), ((V)(3D))), Arr(((V)(320D)), ((V)(46D)), ((V)(4D))), Arr(((V)(286D)), ((V)(132D)), ((V)(3D))), Arr(((V)(340D)), ((V)(186D)), ((V)(3D))), Arr(((V)(24D)), ((V)(196D)), ((V)(3D))), Arr(((V)(130D)), ((V)(26D)), ((V)(3D))), Arr(((V)(232D)), ((V)(22D)), ((V)(4D)))), "forEach", Fn((V _self303, int _argc315, V _a317, V _a318, V _a319, V _a320, V[] _rest316) => {
V x_323 = default;
V y_325 = default;
V r_327 = default;
{ V _t321 = ListOf(_a317);
{ V _t322 = GetIdx(_t321, 0D);
x_323 = _t322; }
{ V _t324 = GetIdx(_t321, 1D);
y_325 = _t324; }
{ V _t326 = GetIdx(_t321, 2D);
r_327 = _t326; }
}
b_314.V(Call(spark_22, V.Undef, x_323, y_325, r_327, ((V)("#fff8d0")), ((V)(0.95))));
return default;
}, 1, "", true));
b_314.S("<g><rect x=\"12\" y=\"150\" width=\"20\" height=\"230\" rx=\"10\" fill=\"#ffffff\" opacity=\"0.25\"/>");
{
double i_328 = 0;
i_328 = 0D;
while (true) {
if (!((i_328 <= 10D))) break;
double y_330 = 0;
y_330 = (372D - (i_328 * 21.5));
b_314.S("<path d=\"M14 ").N(y_330).S("H").N((NumTruthy((i_328 % 5D)) ? 22D : 30D)).S("\" stroke=\"#ffffff\" stroke-width=\"").N((NumTruthy((i_328 % 5D)) ? 2D : 3D)).S("\" opacity=\"0.85\"/>");
i_328++;
}
}
b_314.S("<text x=\"36\" y=\"160\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"13\" fill=\"#ffffff\">10 m</text><text x=\"36\" y=\"268\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"13\" fill=\"#ffffff\" opacity=\"0.8\">5 m</text></g>");
b_314.V(Add(Add(Add(Call(cloud_23, V.Undef, ((V)(296D)), ((V)(300D)), ((V)(0.95)), ((V)(0.95))), Call(cloud_23, V.Undef, ((V)(70D)), ((V)(330D)), ((V)(0.8)), ((V)(0.9)))), Call(cloud_23, V.Undef, ((V)(188D)), ((V)(352D)), ((V)(1.1)), ((V)(0.95)))), Call(cloud_23, V.Undef, ((V)(318D)), ((V)(214D)), ((V)(0.45)), ((V)(0.7)))));
b_314.S("<g transform=\"translate(180 384)\"><path d=\"M-92 4L-80 46M92 4L80 46M-30 16L-26 54M30 16L26 54\" stroke=\"#2a2a3a\" stroke-width=\"5\" stroke-linecap=\"round\"/><ellipse rx=\"104\" ry=\"24\" fill=\"#4f8fff\"/><ellipse rx=\"104\" ry=\"24\" fill=\"none\" stroke=\"#2f5fd0\" stroke-width=\"3\"/><ellipse rx=\"86\" ry=\"18\" fill=\"url(#").V(u_310).S("mt)\"/>").S("<path d=\"M-78 -2Q0 14 78 -2\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"2\" opacity=\"0.18\"/></g>");
b_314.S("<path d=\"M178 370Q160 300 176 250\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"5\" stroke-dasharray=\"1 12\" stroke-linecap=\"round\" opacity=\"0.9\"/>");
b_314.S("<circle cx=\"180\" cy=\"190\" r=\"104\" fill=\"url(#").V(u_310).S("gl)\"/>");
b_314.S("<g fill=\"none\" stroke=\"#ffffff\" stroke-linecap=\"round\" opacity=\"0.9\"><path d=\"M98 196A86 26 -14 0 0 268 158\" stroke-width=\"5\"/><path d=\"M106 226A80 22 -14 0 0 256 196\" stroke-width=\"3.5\" opacity=\"0.7\"/></g>");
b_314.V(Call(stk_26, V.Undef, u_310, Get(c_311, "src"), ((V)(182D)), ((V)(262D)), ((V)(156D)), ((V)(14D)), (false ? V.True : V.False), NewObj(7).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("hap", ((V)(1D))).Put("open", ((V)(0.7))).Put("sq", ((V)((-0.1)))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V));
b_314.S("<path d=\"M268 158A86 26 -14 0 0 98 196\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"5\" stroke-linecap=\"round\" stroke-dasharray=\"0 120 140 400\" opacity=\"0.9\"/>");
b_314.V(Add(Add(Call(spark_22, V.Undef, ((V)(270D)), ((V)(112D)), ((V)(9D)), ((V)("#fff6c8"))), Call(spark_22, V.Undef, ((V)(96D)), ((V)(140D)), ((V)(7D)), ((V)("#ffffff")))), Call(spark_22, V.Undef, ((V)(290D)), ((V)(250D)), ((V)(6D)), ((V)("#ffffff")))));
return Call(wrap_30, V.Undef, u_310, defs_313, ((V)(JsStrBuf.Begin().S(b_314.Str).V(Get(L_312, "body")).End())));
return default;
}, 2, "tramp", false);
slide_37 = Fn((V _self331, int _argc332, V u_338, V c_339, V _a336, V _a337, V[] _rest333) => {
V L_340 = default;
double A_341 = 0;
double B_342 = 0;
double FX_343 = 0;
double FY_344 = 0;
double LX_345 = 0;
double LY_346 = 0;
double HW_347 = 0;
double OX_348 = 0;
double OY_349 = 0;
V P_350 = default;
V pt_351 = default;
V pl_352 = default;
double S0_353 = 0;
double RS_354 = 0;
double LE_355 = 0;
double RH_356 = 0;
double CH_357 = 0;
V hr_358 = default;
double WH_359 = 0;
V bands_360 = default;
V ss_361 = default;
V defs_362 = default;
JsStrBuf b_363 = null;
double T0_364 = 0;
double tH_365 = 0;
V post_366 = default;
V fp_367 = default;
V pc_368 = default;
V kp_369 = default;
V edge_370 = default;
V rev_371 = default;
V gp_372 = default;
V q_373 = default;
V sp_374 = default;
V gn_375 = default;
V rk_376 = default;
V spl_377 = default;
V me_378 = default;
if (_self331.IsNullish) _self331 = GlobalV;
L_340 = Call(logo_25, V.Undef, u_338, Arr(((V)("SLIDE & SPLASH!"))), ((V)(250D)), ((V)(54D)), NewObj(7).Put("size", ((V)(44D))).Put("top", ((V)("#ffffff"))).Put("bot", ((V)("#7ff0e0"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#0e4a6a"))).Put("shade", ((V)("#072c44"))).Put("rot", ((V)((-3D)))).V);
A_341 = ((32D * System.Math.PI) / 180D);
B_342 = (((-24D) * System.Math.PI) / 180D);
FX_343 = FdLibm.Cos(A_341);
FY_344 = FdLibm.Sin(A_341);
LX_345 = FdLibm.Cos(B_342);
LY_346 = FdLibm.Sin(B_342);
HW_347 = 44D;
OX_348 = 196D;
OY_349 = 208D;
P_350 = Fn((V _self331, int _argc379, V s_385, V l_386, V h_387, V _a384, V[] _rest380) => {
return Arr(((V)(((OX_348 + (ToNum(s_385) * FX_343)) + ((ToNum(l_386) * HW_347) * LX_345)))), ((V)((((OY_349 + (ToNum(s_385) * FY_344)) + ((ToNum(l_386) * HW_347) * LY_346)) - ToNum((h_387 is var _t388 && Truthy(_t388) ? _t388 : ((V)(0D))))))));
}, 3, "", true);
pt_351 = Fn((V _self331, int _argc389, V q_395, V _a392, V _a393, V _a394, V[] _rest390) => {
return ((V)(JsStrBuf.Begin().V(Call(f_17, V.Undef, GetIdx(q_395, 0D))).S(" ").V(Call(f_17, V.Undef, GetIdx(q_395, 1D))).End()));
}, 1, "", true);
pl_352 = Fn((V _self331, int _argc396, V a_402, V _a399, V _a400, V _a401, V[] _rest397) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(a_402, "map", pt_351), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
S0_353 = (-150D);
RS_354 = 92D;
LE_355 = 162D;
RH_356 = 30D;
CH_357 = 30D;
hr_358 = Fn((V _self331, int _argc403, V s_409, V _a406, V _a407, V _a408, V[] _rest404) => {
return ((V)((CH_357 + (LeN(s_409, RS_354) ? 0D : (RH_356 * Pow(((ToNum(s_409) - RS_354) / (LE_355 - RS_354)), 2D))))));
}, 1, "", true);
WH_359 = 10D;
bands_360 = Arr(((V)("#ff7a8a")), ((V)("#ffa95a")), ((V)("#ffdc5a")), ((V)("#7fd870")), ((V)("#5cb8ff")), ((V)("#a98bff")));
ss_361 = Arr();
{
double s_410 = 0;
s_410 = S0_353;
while (true) {
if (!((s_410 <= (LE_355 + 0.1)))) break;
Invoke(ss_361, "push", ((V)(s_410)));
s_410 = (s_410 + ((s_410 < RS_354) ? (RS_354 - S0_353) : ((LE_355 - RS_354) / 10D)));
}
}
defs_362 = Add(Add(Add(Get(L_340, "defs"), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_338).S("gr").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#a6e07e"))), Arr(((V)(1D)), ((V)("#5fae4a")))))), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_338).S("wt").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#8fe0ff"))), Arr(((V)(1D)), ((V)("#3fa6e6")))))), Call(rg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_338).S("gd").End())), ((V)("50%")), ((V)("50%")), ((V)("50%")), Arr(Arr(((V)(0D)), ((V)("#fff6b0"))), Arr(((V)(1D)), ((V)("#ffd84a"))))));
b_363 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"780\" height=\"360\" fill=\"url(#").V(u_338).S("gr)\"/>").V(Call(rays_21, V.Undef, ((V)(400D)), ((V)(300D)), ((V)(26D)), ((V)("#ffffff")), ((V)(0.12)))).End());
Invoke(Arr(Arr(((V)(40D)), ((V)(300D))), Arr(((V)(120D)), ((V)(330D))), Arr(((V)(24D)), ((V)(236D))), Arr(((V)(300D)), ((V)(120D))), Arr(((V)(420D)), ((V)(160D))), Arr(((V)(470D)), ((V)(118D))), Arr(((V)(250D)), ((V)(336D))), Arr(((V)(380D)), ((V)(210D))), Arr(((V)(150D)), ((V)(270D)))), "forEach", Fn((V _self331, int _argc412, V _a414, V i_418, V _a416, V _a417, V[] _rest413) => {
V x_421 = default;
V y_423 = default;
{ V _t419 = ListOf(_a414);
{ V _t420 = GetIdx(_t419, 0D);
x_421 = _t420; }
{ V _t422 = GetIdx(_t419, 1D);
y_423 = _t422; }
}
b_363.S("<path d=\"M").N((ToNum(x_421) - 5D)).S(" ").V(y_423).S("l2 -8l3 6l3 -10l3 10l3 -7l2 9Z\" fill=\"#4f9a3e\" opacity=\"0.7\"/>");
if (NumTruthy((ToNum(i_418) % 2D))) {
{
double j_424 = 0;
j_424 = 0D;
while (true) {
if (!((j_424 < 5D))) break;
b_363.S("<circle cx=\"").V(Call(f_17, V.Undef, Add(Add(x_421, ((V)(12D))), ((V)((FdLibm.Cos((j_424 * 1.2566)) * 2.6)))))).S("\" cy=\"").V(Call(f_17, V.Undef, ((V)(((ToNum(y_423) - 4D) + (FdLibm.Sin((j_424 * 1.2566)) * 2.6)))))).S("\" r=\"2\" fill=\"").V(GetIdx(Arr(((V)("#ffd1e8")), ((V)("#fff3a8")), ((V)("#ffffff")), ((V)("#d9c8ff"))), (ToNum(i_418) % 4D))).S("\"/>");
j_424++;
}
}
}
return default;
}, 2, "", true));
Invoke(Arr(Arr(((V)(352D)), ((V)(176D)), ((V)(0.75))), Arr(((V)(430D)), ((V)(150D)), ((V)(0.95))), Arr(((V)(520D)), ((V)(120D)), ((V)(1.1)))), "forEach", Fn((V _self331, int _argc426, V _a428, V _a429, V _a430, V _a431, V[] _rest427) => {
V x_434 = default;
V y_436 = default;
V k_438 = default;
{ V _t432 = ListOf(_a428);
{ V _t433 = GetIdx(_t432, 0D);
x_434 = _t433; }
{ V _t435 = GetIdx(_t432, 1D);
y_436 = _t435; }
{ V _t437 = GetIdx(_t432, 2D);
k_438 = _t437; }
}
b_363.S("<ellipse cx=\"").V(x_434).S("\" cy=\"").V(Add(y_436, ((V)(2D)))).S("\" rx=\"").V(Call(f_17, V.Undef, ((V)((34D * ToNum(k_438)))))).S("\" ry=\"").V(Call(f_17, V.Undef, ((V)((12D * ToNum(k_438)))))).S("\" fill=\"#2d4a22\" opacity=\"0.2\"/><g transform=\"translate(").V(x_434).S(" ").V(y_436).S(") scale(").V(k_438).S(")\"><rect x=\"-5\" y=\"-38\" width=\"10\" height=\"40\" rx=\"3\" fill=\"#8a5a34\"/><circle cx=\"-17\" cy=\"-48\" r=\"21\" fill=\"#57a854\"/><circle cx=\"15\" cy=\"-50\" r=\"23\" fill=\"#57a854\"/><circle cx=\"0\" cy=\"-70\" r=\"25\" fill=\"#6cbb5c\"/><circle cx=\"-7\" cy=\"-76\" r=\"10\" fill=\"#8fd47a\" opacity=\"0.8\"/></g>");
return default;
}, 1, "", true));
T0_364 = (S0_353 - 64D);
tH_365 = CH_357;
post_366 = Fn((V _self331, int _argc439, V s_445, V l_446, V h0_447, V h1_448, V[] _rest440) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, s_445, l_446, h0_447))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, s_445, l_446, h1_448))).S("\" stroke=\"#a89ad0\" stroke-width=\"8.5\" stroke-linecap=\"round\"/><path d=\"M").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, s_445, l_446, h0_447))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, s_445, l_446, h1_448))).S("\" stroke=\"#ffffff\" stroke-width=\"6\" stroke-linecap=\"round\"/>").End()));
}, 4, "", true);
b_363.S("<path d=\"").V(Call(pl_352, V.Undef, Arr(Call(P_350, V.Undef, ((V)((T0_364 - 8D))), ((V)((-1.25))), ((V)(0D))), Call(P_350, V.Undef, ((V)((S0_353 + 14D))), ((V)((-1.25))), ((V)(0D))), Call(P_350, V.Undef, ((V)((S0_353 + 14D))), ((V)(1.25)), ((V)(0D))), Call(P_350, V.Undef, ((V)((T0_364 - 8D))), ((V)(1.25)), ((V)(0D)))))).S("\" fill=\"#2a3a20\" opacity=\"0.15\"/>").V(Call(post_366, V.Undef, ((V)(T0_364)), ((V)(1.15)), ((V)(0D)), ((V)((tH_365 + 44D))))).V(Call(post_366, V.Undef, ((V)(S0_353)), ((V)(1.15)), ((V)(0D)), ((V)((tH_365 + 44D))))).V(Call(post_366, V.Undef, ((V)(T0_364)), ((V)((-1.15))), ((V)(0D)), ((V)((tH_365 + 44D)))));
b_363.S("<path d=\"").V(Call(pl_352, V.Undef, Arr(Call(P_350, V.Undef, ((V)(T0_364)), ((V)((-1.15))), ((V)(tH_365))), Call(P_350, V.Undef, ((V)(S0_353)), ((V)((-1.15))), ((V)(tH_365))), Call(P_350, V.Undef, ((V)(S0_353)), ((V)(1.15)), ((V)(tH_365))), Call(P_350, V.Undef, ((V)(T0_364)), ((V)(1.15)), ((V)(tH_365)))))).S("\" fill=\"#c9b8f2\" stroke=\"#a89ad0\" stroke-width=\"1.5\"/><path d=\"").V(Call(pl_352, V.Undef, Arr(Call(P_350, V.Undef, ((V)(T0_364)), ((V)((-1.15))), ((V)((tH_365 - 8D)))), Call(P_350, V.Undef, ((V)(S0_353)), ((V)((-1.15))), ((V)((tH_365 - 8D)))), Call(P_350, V.Undef, ((V)(S0_353)), ((V)((-1.15))), ((V)(tH_365))), Call(P_350, V.Undef, ((V)(T0_364)), ((V)((-1.15))), ((V)(tH_365)))))).S("\" fill=\"#cfc6ec\"/>");
Invoke(Arr(((V)(22D)), ((V)(42D))), "forEach", Fn((V _self331, int _argc449, V h_455, V _a452, V _a453, V _a454, V[] _rest450) => {
b_363.S("<path d=\"M").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)(T0_364)), ((V)((-1.15))), Add(((V)(tH_365)), h_455)))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)(T0_364)), ((V)(1.15)), Add(((V)(tH_365)), h_455)))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)(S0_353)), ((V)(1.15)), Add(((V)(tH_365)), h_455)))).S("\" stroke=\"#a89ad0\" stroke-width=\"6\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"M").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)(T0_364)), ((V)((-1.15))), Add(((V)(tH_365)), h_455)))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)(T0_364)), ((V)(1.15)), Add(((V)(tH_365)), h_455)))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)(S0_353)), ((V)(1.15)), Add(((V)(tH_365)), h_455)))).S("\" stroke=\"#ffffff\" stroke-width=\"3.6\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>");
return default;
}, 1, "", true));
fp_367 = Call(P_350, V.Undef, ((V)(T0_364)), ((V)((-1.15))), ((V)((tH_365 + 44D))));
b_363.S("<path d=\"M").V(Call(pt_351, V.Undef, fp_367)).S("V").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(fp_367, 1D)) - 26D))))).S("\" stroke=\"#a89ad0\" stroke-width=\"2.2\"/><path d=\"M").V(Call(f_17, V.Undef, GetIdx(fp_367, 0D))).S(" ").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(fp_367, 1D)) - 26D))))).S("l18 5l-18 6Z\" fill=\"#ff7a8a\" stroke=\"#c8485a\" stroke-width=\"1.2\"/>");
pc_368 = Call(P_350, V.Undef, ((V)(206D)), ((V)(0.15)), ((V)(0D)));
kp_369 = Call(Fn((V _self331, int _argc456, V _a458, V _a459, V _a460, V _a461, V[] _rest457) => {
V cx_462 = default;
double cy_463 = 0;
double RXp_464 = 0;
double RYp_465 = 0;
double T_466 = 0;
V arcF_467 = default;
JsStrBuf k_468 = null;
cx_462 = GetIdx(pc_368, 0D);
cy_463 = (ToNum(GetIdx(pc_368, 1D)) - 4D);
RXp_464 = 86D;
RYp_465 = 25D;
T_466 = 9D;
arcF_467 = Fn((V _self331, int _argc469, V y_475, V rx_476, V ry_477, V _a474, V[] _rest470) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(f_17, V.Undef, ((V)((ToNum(cx_462) - ToNum(rx_476)))))).S(" ").V(Call(f_17, V.Undef, y_475)).S("A").V(rx_476).S(" ").V(ry_477).S(" 0 0 0 ").V(Call(f_17, V.Undef, Add(cx_462, rx_476))).S(" ").V(Call(f_17, V.Undef, y_475)).End()));
}, 3, "", true);
k_468 = new JsStrBuf(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f_17, V.Undef, Add(cx_462, ((V)(4D))))).S("\" cy=\"").V(Call(f_17, V.Undef, ((V)(((cy_463 + (3D * T_466)) + 8D))))).S("\" rx=\"").N((RXp_464 + 12D)).S("\" ry=\"").V(Call(f_17, V.Undef, ((V)((RYp_465 * 0.7))))).S("\" fill=\"#2a4a20\" opacity=\"0.2\"/><ellipse cx=\"").V(Call(f_17, V.Undef, cx_462)).S("\" cy=\"").V(Call(f_17, V.Undef, ((V)(cy_463)))).S("\" rx=\"").N(RXp_464).S("\" ry=\"").N(RYp_465).S("\" fill=\"#3f9af0\"/><ellipse cx=\"").V(Call(f_17, V.Undef, cx_462)).S("\" cy=\"").V(Call(f_17, V.Undef, ((V)((cy_463 + 1D))))).S("\" rx=\"").N((RXp_464 - 12D)).S("\" ry=\"").N((RYp_465 - 5D)).S("\" fill=\"#1b5fae\"/><ellipse cx=\"").V(Call(f_17, V.Undef, cx_462)).S("\" cy=\"").V(Call(f_17, V.Undef, ((V)((cy_463 + 5D))))).S("\" rx=\"").N((RXp_464 - 15D)).S("\" ry=\"").N((RYp_465 - 9D)).S("\" fill=\"url(#").V(u_338).S("wt)\"/>").End());
k_468.S("<path d=\"").V(Call(arcF_467, V.Undef, ((V)(cy_463)), ((V)(RXp_464)), ((V)(RYp_465)))).S("L").V(Call(f_17, V.Undef, ((V)((ToNum(Add(cx_462, ((V)(RXp_464)))) - 12D))))).S(" ").V(Call(f_17, V.Undef, ((V)((cy_463 + 1D))))).S("A").N((RXp_464 - 12D)).S(" ").N((RYp_465 - 5D)).S(" 0 0 1 ").V(Call(f_17, V.Undef, ((V)(((ToNum(cx_462) - RXp_464) + 12D))))).S(" ").V(Call(f_17, V.Undef, ((V)((cy_463 + 1D))))).S("Z\" fill=\"#3f9af0\"/>");
Invoke(Arr(((V)("#2a86e6")), ((V)("#f6f9fc")), ((V)("#2a86e6"))), "forEach", Fn((V _self331, int _argc478, V c_484, V j_485, V _a482, V _a483, V[] _rest479) => {
double yt_486 = 0;
double yb_487 = 0;
yt_486 = ((cy_463 + 2D) + (ToNum(j_485) * T_466));
yb_487 = (yt_486 + T_466);
k_468.S("<path d=\"").V(Call(arcF_467, V.Undef, ((V)(yt_486)), ((V)(RXp_464)), ((V)(RYp_465)))).S("L").V(Call(f_17, V.Undef, Add(cx_462, ((V)(RXp_464))))).S(" ").V(Call(f_17, V.Undef, ((V)(yb_487)))).S("A").N(RXp_464).S(" ").N(RYp_465).S(" 0 0 1 ").V(Call(f_17, V.Undef, ((V)((ToNum(cx_462) - RXp_464))))).S(" ").V(Call(f_17, V.Undef, ((V)(yb_487)))).S("Z\" fill=\"").V(c_484).S("\" stroke=\"").S((SEqN(j_485, 1D) ? "#c9d6e6" : "#1a5fb0")).S("\" stroke-width=\"1\"/><path d=\"").V(Call(arcF_467, V.Undef, ((V)((yt_486 + 3D))), ((V)((RXp_464 - 8D))), ((V)(RYp_465)))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.8\" opacity=\"").N((SEqN(j_485, 1D) ? 0.9 : 0.45)).S("\"/>");
return default;
}, 2, "", true));
Invoke(Arr(((V)((-0.6))), ((V)((-0.15))), ((V)(0.35)), ((V)(0.75))), "forEach", Fn((V _self331, int _argc488, V v_494, V i_495, V _a492, V _a493, V[] _rest489) => {
k_468.S("<g transform=\"translate(").V(Call(f_17, V.Undef, Add(cx_462, ((V)(((ToNum(v_494) * RXp_464) * 0.92)))))).S(" ").V(Call(f_17, V.Undef, ((V)((((cy_463 + 2D) + (T_466 * 1.5)) + (RYp_465 * System.Math.Sqrt((1D - ((ToNum(v_494) * ToNum(v_494)) * 0.85))))))))).S(") scale(0.9)\">").S((NumTruthy((ToNum(i_495) % 2D)) ? "<path d=\"M0 -3.6L1 -1.2L3.5 -1.1L1.5 0.6L2.2 3.1L0 1.7L-2.2 3.1L-1.5 0.6L-3.5 -1.1L-1 -1.2Z\" fill=\"#ffd23a\"/>" : "<path d=\"M-4.2 0Q-1 -3 3 0Q-1 3 -4.2 0Z\" fill=\"#ff8a3a\"/><path d=\"M2.6 0L5.6 -2.2V2.2Z\" fill=\"#ff8a3a\"/>")).S("</g>");
return default;
}, 2, "", true));
return ((V)(JsStrBuf.Begin().S(k_468.Str).S("<g transform=\"translate(").V(Call(f_17, V.Undef, ((V)((ToNum(cx_462) - 46D))))).S(" ").V(Call(f_17, V.Undef, ((V)((cy_463 + 4D))))).S(") scale(0.75)\"><path d=\"M-12 -2Q-12 -12 0 -12Q8 -12 10 -6Q12 -2 6 0H-8Q-12 0 -12 -2Z\" fill=\"#ffd84a\" stroke=\"#d09a20\" stroke-width=\"1.2\"/><circle cx=\"4\" cy=\"-17\" r=\"7\" fill=\"#ffd84a\" stroke=\"#d09a20\" stroke-width=\"1.2\"/><path d=\"M10 -17l6 1l-6 3Z\" fill=\"#ff8a3a\"/></g>").End()));
return default;
}, 0, "", true), V.Undef);
b_363.V(kp_369);
{
double s_496 = 0;
s_496 = (S0_353 + 25D);
while (true) {
if (!((s_496 < LE_355))) break;
b_363.V(Call(post_366, V.Undef, ((V)(s_496)), ((V)(1.05)), ((V)(0D)), ((V)((ToNum(Call(hr_358, V.Undef, ((V)(s_496)))) - 4D)))));
s_496 = (s_496 + 45D);
}
}
{
double j_498 = 0;
j_498 = 0D;
while (true) {
if (!((j_498 < (ToNum(Get(ss_361, "length")) - 1D)))) break;
V a_500 = default;
V z_501 = default;
a_500 = GetIdx(ss_361, j_498);
z_501 = GetIdx(ss_361, (j_498 + 1D));
Invoke(bands_360, "forEach", Fn((V _self331, int _argc502, V col_508, V i_509, V _a506, V _a507, V[] _rest503) => {
double l0_510 = 0;
double l1_511 = 0;
l0_510 = ((-1D) + (ToNum(i_509) / 3D));
l1_511 = ((-1D) + (ToNum(Add(i_509, ((V)(1D)))) / 3D));
b_363.S("<path d=\"").V(Call(pl_352, V.Undef, Arr(Call(P_350, V.Undef, a_500, ((V)(l0_510)), Call(hr_358, V.Undef, a_500)), Call(P_350, V.Undef, z_501, ((V)(l0_510)), Call(hr_358, V.Undef, z_501)), Call(P_350, V.Undef, z_501, ((V)(l1_511)), Call(hr_358, V.Undef, z_501)), Call(P_350, V.Undef, a_500, ((V)(l1_511)), Call(hr_358, V.Undef, a_500))))).S("\" fill=\"").V(col_508).S("\" stroke=\"").V(col_508).S("\" stroke-width=\"0.8\"/>");
return default;
}, 2, "", true));
j_498++;
}
}
{
double s_512 = 0;
s_512 = (S0_353 + 30D);
while (true) {
if (!((s_512 < RS_354))) break;
b_363.S("<path d=\"M").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)(s_512)), ((V)((-1D))), ((V)(CH_357))))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)(s_512)), ((V)(1D)), ((V)(CH_357))))).S("\" stroke=\"#ffffff\" stroke-width=\"2\" opacity=\"0.5\"/>");
s_512 = (s_512 + 50D);
}
}
Invoke(Arr(Arr(((V)((-60D))), ((V)(0.5))), Arr(((V)(20D)), ((V)((-0.5))))), "forEach", Fn((V _self331, int _argc514, V _a516, V _a517, V _a518, V _a519, V[] _rest515) => {
V s_522 = default;
V l_524 = default;
{ V _t520 = ListOf(_a516);
{ V _t521 = GetIdx(_t520, 0D);
s_522 = _t521; }
{ V _t523 = GetIdx(_t520, 1D);
l_524 = _t523; }
}
b_363.S("<path d=\"M").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, s_522, l_524, ((V)(CH_357))))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, Add(s_522, ((V)(60D))), l_524, ((V)(CH_357))))).S("\" stroke=\"#ffffff\" stroke-width=\"3\" stroke-linecap=\"round\" opacity=\"0.55\"/>");
return default;
}, 1, "", true));
edge_370 = Fn((V _self331, int _argc525, V l_531, V h0_532, V h1_533, V _a530, V[] _rest526) => {
return Invoke(ss_361, "map", Fn((V _self331, int _argc534, V s_540, V _a537, V _a538, V _a539, V[] _rest535) => {
return Call(P_350, V.Undef, s_540, l_531, Add(((V)((ToNum(Call(hr_358, V.Undef, s_540)) * ToNum(h0_532)))), h1_533));
}, 1, "", true));
}, 3, "", true);
rev_371 = Fn((V _self331, int _argc541, V a_547, V _a544, V _a545, V _a546, V[] _rest542) => {
return Invoke(Invoke(a_547, "slice"), "reverse");
}, 1, "", true);
b_363.S("<path d=\"").V(Call(pl_352, V.Undef, Invoke(Call(edge_370, V.Undef, ((V)(1D)), ((V)(1D)), ((V)(0D))), "concat", Call(rev_371, V.Undef, Call(edge_370, V.Undef, ((V)(1D)), ((V)(1D)), ((V)(WH_359))))))).S("\" fill=\"#e6e0f6\"/><path d=\"").V(Call(pl_352, V.Undef, Invoke(Call(edge_370, V.Undef, ((V)(1D)), ((V)(1D)), ((V)(WH_359))), "concat", Call(rev_371, V.Undef, Call(edge_370, V.Undef, ((V)(1.1)), ((V)(1D)), ((V)(WH_359))))))).S("\" fill=\"#ffffff\" stroke=\"#cfc6ec\" stroke-width=\"1.2\"/>");
gp_372 = Call(P_350, V.Undef, ((V)(52D)), ((V)(0.02)), ((V)(CH_357)));
q_373 = Fn((V _self331, int _argc548, V a_554, V w_555, V _a552, V _a553, V[] _rest549) => {
return Arr(((V)(((ToNum(a_554) * FX_343) + (ToNum(w_555) * LX_345)))), ((V)(((ToNum(a_554) * FY_344) + (ToNum(w_555) * LY_346)))));
}, 2, "", true);
b_363.S("<g transform=\"translate(").V(Call(pt_351, V.Undef, gp_372)).S(")\"><path d=\"").V(Call(pl_352, V.Undef, Arr(Call(q_373, V.Undef, ((V)((-26D))), ((V)((-19D)))), Call(q_373, V.Undef, ((V)(26D)), ((V)((-19D)))), Call(q_373, V.Undef, ((V)(26D)), ((V)(19D))), Call(q_373, V.Undef, ((V)((-26D))), ((V)(19D)))))).S("\" fill=\"url(#").V(u_338).S("gd)\" stroke=\"#d79a22\" stroke-width=\"2.4\" stroke-linejoin=\"round\"/>");
Invoke(Arr(((V)((-13D))), ((V)(2D)), ((V)(17D))), "forEach", Fn((V _self331, int _argc556, V d_562, V _a559, V _a560, V _a561, V[] _rest557) => {
b_363.S("<path d=\"").V(Call(pl_352, V.Undef, Arr(Call(q_373, V.Undef, ((V)((ToNum(d_562) - 7D))), ((V)((-11D)))), Call(q_373, V.Undef, Add(d_562, ((V)(4D))), ((V)(0D))), Call(q_373, V.Undef, ((V)((ToNum(d_562) - 7D))), ((V)(11D))), Call(q_373, V.Undef, ((V)((ToNum(d_562) - 2D))), ((V)(11D))), Call(q_373, V.Undef, Add(d_562, ((V)(9D))), ((V)(0D))), Call(q_373, V.Undef, ((V)((ToNum(d_562) - 2D))), ((V)((-11D))))))).S("\" fill=\"#ff8a3d\" stroke=\"#ffffff\" stroke-width=\"1.2\" stroke-linejoin=\"round\"/>");
return default;
}, 1, "", true));
b_363.S("</g>");
sp_374 = Call(P_350, V.Undef, ((V)((-40D))), ((V)((-0.5))), ((V)(CH_357)));
b_363.S("<ellipse cx=\"").V(Call(f_17, V.Undef, GetIdx(sp_374, 0D))).S("\" cy=\"").V(Call(f_17, V.Undef, GetIdx(sp_374, 1D))).S("\" rx=\"30\" ry=\"12\" transform=\"rotate(8 ").V(Call(pt_351, V.Undef, sp_374)).S(")\" fill=\"#9fe2ff\" stroke=\"#ffffff\" stroke-width=\"2.2\"/><path d=\"M").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(sp_374, 0D)) - 16D))))).S(" ").V(Call(f_17, V.Undef, ((V)((ToNum(GetIdx(sp_374, 1D)) - 2D))))).S("l20 2\" stroke=\"#ffffff\" stroke-width=\"2.6\" stroke-linecap=\"round\" opacity=\"0.85\"/>");
gn_375 = Call(P_350, V.Undef, ((V)((-58D))), ((V)(0.6)), ((V)(CH_357)));
b_363.S("<g transform=\"translate(").V(Call(pt_351, V.Undef, gn_375)).S(") rotate(-8) scale(0.85)\"><ellipse cy=\"2\" rx=\"15\" ry=\"5\" fill=\"#2d4a22\" opacity=\"0.22\"/><ellipse cx=\"-6\" cy=\"-2\" rx=\"6.5\" ry=\"4\" fill=\"#6b4426\"/><ellipse cx=\"6\" cy=\"-2\" rx=\"6.5\" ry=\"4\" fill=\"#6b4426\"/><path d=\"M-12 -4C-13 -16 -9 -22 0 -22C9 -22 13 -16 12 -4Z\" fill=\"#4f8ee8\" stroke=\"#2c5aa8\" stroke-width=\"1.6\"/><path d=\"M-9 -26C-13 -16 -6 -7 0 -6C6 -7 13 -16 9 -26Z\" fill=\"#ffffff\" stroke=\"#d8d2c6\" stroke-width=\"1.4\"/><ellipse cy=\"-28\" rx=\"8\" ry=\"6.2\" fill=\"#ffd2b0\"/><circle cy=\"-25.5\" r=\"2.8\" fill=\"#ff9a8a\"/><path d=\"M-4.5 -29h2.4M2.1 -29h2.4\" stroke=\"#4a3a2e\" stroke-width=\"1.5\" stroke-linecap=\"round\"/><path d=\"M-10.5 -31C-9 -39 -4 -49 2 -51C3 -44 8 -37 10.5 -31Z\" fill=\"#ff5e6c\" stroke=\"#b8304a\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/></g>");
rk_376 = Call(P_350, V.Undef, ((V)(70D)), ((V)((-0.55))), ((V)(CH_357)));
b_363.S("<g transform=\"translate(").V(Call(pt_351, V.Undef, rk_376)).S(") scale(0.7)\"><ellipse cy=\"3\" rx=\"26\" ry=\"8\" fill=\"#2d4a22\" opacity=\"0.22\"/><path d=\"M-24 2C-26 -10 -16 -24 -2 -25C12 -26 24 -16 25 -4C26 2 20 6 0 6C-16 6 -23 5 -24 2Z\" fill=\"#a3a9b2\" stroke=\"#5c6470\" stroke-width=\"2.2\"/><path d=\"M-15 -14C-9 -21 3 -22 9 -18\" stroke=\"#d2d6dc\" stroke-width=\"4.5\" fill=\"none\" stroke-linecap=\"round\"/></g>");
{
double s_563 = 0;
s_563 = (S0_353 + 25D);
while (true) {
if (!((s_563 < LE_355))) break;
b_363.V(Call(post_366, V.Undef, ((V)(s_563)), ((V)((-1.05))), ((V)(0D)), ((V)((ToNum(Call(hr_358, V.Undef, ((V)(s_563)))) - 4D)))));
s_563 = (s_563 + 45D);
}
}
b_363.S("<path d=\"").V(Call(pl_352, V.Undef, Invoke(Call(edge_370, V.Undef, ((V)((-1.1))), ((V)(1D)), ((V)((-6D)))), "concat", Call(rev_371, V.Undef, Call(edge_370, V.Undef, ((V)((-1.1))), ((V)(1D)), ((V)(WH_359))))))).S("\" fill=\"#cfc6ec\"/><path d=\"").V(Call(pl_352, V.Undef, Invoke(Call(edge_370, V.Undef, ((V)((-1.1))), ((V)(1D)), ((V)(WH_359))), "concat", Call(rev_371, V.Undef, Call(edge_370, V.Undef, ((V)((-1D))), ((V)(1D)), ((V)(WH_359))))))).S("\" fill=\"#ffffff\" stroke=\"#cfc6ec\" stroke-width=\"1.2\"/>");
b_363.V(Add(Call(post_366, V.Undef, ((V)(T0_364)), ((V)((-1.15))), ((V)(0D)), ((V)((tH_365 + 44D)))), Call(post_366, V.Undef, ((V)(S0_353)), ((V)((-1.15))), ((V)(0D)), ((V)((tH_365 + 44D))))));
Invoke(Arr(((V)((T0_364 + 14D))), ((V)((T0_364 + 50D)))), "forEach", Fn((V _self331, int _argc565, V s_571, V _a568, V _a569, V _a570, V[] _rest566) => {
b_363.S("<path d=\"M").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, s_571, ((V)((-1.8))), ((V)(0D))))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, s_571, ((V)((-1.15))), ((V)((tH_365 + 16D)))))).S("\" stroke=\"#a89ad0\" stroke-width=\"6.5\" stroke-linecap=\"round\"/><path d=\"M").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, s_571, ((V)((-1.8))), ((V)(0D))))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, s_571, ((V)((-1.15))), ((V)((tH_365 + 16D)))))).S("\" stroke=\"#ffffff\" stroke-width=\"4\" stroke-linecap=\"round\"/>");
return default;
}, 1, "", true));
{
double k_572 = 0;
k_572 = 1D;
while (true) {
if (!((k_572 <= 4D))) break;
double h_574 = 0;
double l_575 = 0;
h_574 = ((k_572 * tH_365) / 5D);
l_575 = ((-1.8) + ((0.65 * h_574) / (tH_365 + 16D)));
b_363.S("<path d=\"M").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)((T0_364 + 14D))), ((V)(l_575)), ((V)(h_574))))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)((T0_364 + 50D))), ((V)(l_575)), ((V)(h_574))))).S("\" stroke=\"#ffffff\" stroke-width=\"3.4\" stroke-linecap=\"round\"/>");
k_572++;
}
}
b_363.S("<path d=\"").V(Call(pl_352, V.Undef, Arr(Call(P_350, V.Undef, ((V)(LE_355)), ((V)((-1.1))), ((V)((ToNum(Call(hr_358, V.Undef, ((V)(LE_355)))) - 6D)))), Call(P_350, V.Undef, ((V)(LE_355)), ((V)(1.1)), ((V)((ToNum(Call(hr_358, V.Undef, ((V)(LE_355)))) - 6D)))), Call(P_350, V.Undef, ((V)(LE_355)), ((V)(1.1)), Add(Call(hr_358, V.Undef, ((V)(LE_355))), ((V)(WH_359)))), Call(P_350, V.Undef, ((V)(LE_355)), ((V)((-1.1))), Add(Call(hr_358, V.Undef, ((V)(LE_355))), ((V)(WH_359))))))).S("\" fill=\"#cfc6ec\" stroke=\"#b6aadc\" stroke-width=\"1.5\"/><path d=\"M").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)(LE_355)), ((V)((-1D))), Add(Call(hr_358, V.Undef, ((V)(LE_355))), ((V)(1D)))))).S("L").V(Call(pt_351, V.Undef, Call(P_350, V.Undef, ((V)(LE_355)), ((V)(1D)), Add(Call(hr_358, V.Undef, ((V)(LE_355))), ((V)(1D)))))).S("\" stroke=\"#ffffff\" stroke-width=\"4\" stroke-linecap=\"round\"/>");
spl_377 = Arr(GetIdx(pc_368, 0D), Add(GetIdx(pc_368, 1D), ((V)(2D))));
b_363.S("<g transform=\"translate(").V(Call(pt_351, V.Undef, spl_377)).S(")\"><ellipse rx=\"50\" ry=\"15\" fill=\"#ffffff\" opacity=\"0.75\"/><ellipse rx=\"70\" ry=\"22\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"3\" opacity=\"0.7\"/><path d=\"M-16 0C-20 -70 -8 -150 2 -164C12 -150 22 -70 16 0Z\" fill=\"#ffffff\" opacity=\"0.96\"/>").V(Invoke(Invoke(Arr(Arr(((V)((-40D))), ((V)((-86D)))), Arr(((V)((-26D))), ((V)((-118D)))), Arr(((V)(28D)), ((V)((-108D)))), Arr(((V)(42D)), ((V)((-76D)))), Arr(((V)((-52D))), ((V)((-54D)))), Arr(((V)(54D)), ((V)((-48D))))), "map", Fn((V _self331, int _argc576, V _a578, V _a579, V _a580, V _a581, V[] _rest577) => {
V x_584 = default;
V h_586 = default;
{ V _t582 = ListOf(_a578);
{ V _t583 = GetIdx(_t582, 0D);
x_584 = _t583; }
{ V _t585 = GetIdx(_t582, 1D);
h_586 = _t585; }
}
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f_17, V.Undef, ((V)(((ToNum(x_584) * 0.4) - 5D))))).S(" 0C").V(Call(f_17, V.Undef, ((V)(((ToNum(x_584) * 0.4) - 6D))))).S(" ").V(Call(f_17, V.Undef, ((V)((ToNum(h_586) * 0.55))))).S(" ").V(Call(f_17, V.Undef, ((V)((ToNum(x_584) - 3D))))).S(" ").V(Call(f_17, V.Undef, ((V)((ToNum(h_586) * 0.95))))).S(" ").V(Call(f_17, V.Undef, x_584)).S(" ").V(Call(f_17, V.Undef, h_586)).S("C").V(Call(f_17, V.Undef, Add(x_584, ((V)(3D))))).S(" ").V(Call(f_17, V.Undef, ((V)((ToNum(h_586) * 0.95))))).S(" ").V(Call(f_17, V.Undef, ((V)(((ToNum(x_584) * 0.4) + 6D))))).S(" ").V(Call(f_17, V.Undef, ((V)((ToNum(h_586) * 0.55))))).S(" ").V(Call(f_17, V.Undef, ((V)(((ToNum(x_584) * 0.4) + 5D))))).S(" 0Z\" fill=\"#e6f8ff\" stroke=\"#a8e0ff\" stroke-width=\"1.2\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M-42 -2Q-52 -28 -62 -32Q-48 -24 -34 -4ZM42 -2Q54 -26 64 -30Q50 -22 34 -4Z\" fill=\"#e6f8ff\" stroke=\"#a8e0ff\" stroke-width=\"1.2\"/></g>");
Invoke(Arr(Arr(((V)((ToNum(GetIdx(spl_377, 0D)) - 48D))), ((V)((ToNum(GetIdx(spl_377, 1D)) - 136D))), ((V)(5D))), Arr(Add(GetIdx(spl_377, 0D), ((V)(38D))), ((V)((ToNum(GetIdx(spl_377, 1D)) - 160D))), ((V)(6D))), Arr(Add(GetIdx(spl_377, 0D), ((V)(58D))), ((V)((ToNum(GetIdx(spl_377, 1D)) - 100D))), ((V)(4.5))), Arr(((V)((ToNum(GetIdx(spl_377, 0D)) - 64D))), ((V)((ToNum(GetIdx(spl_377, 1D)) - 90D))), ((V)(4D))), Arr(Add(GetIdx(spl_377, 0D), ((V)(10D))), ((V)((ToNum(GetIdx(spl_377, 1D)) - 196D))), ((V)(4D))), Arr(((V)((ToNum(GetIdx(spl_377, 0D)) - 28D))), ((V)((ToNum(GetIdx(spl_377, 1D)) - 182D))), ((V)(3.5)))), "forEach", Fn((V _self331, int _argc587, V _a589, V _a590, V _a591, V _a592, V[] _rest588) => {
V x_595 = default;
V y_597 = default;
V r_599 = default;
{ V _t593 = ListOf(_a589);
{ V _t594 = GetIdx(_t593, 0D);
x_595 = _t594; }
{ V _t596 = GetIdx(_t593, 1D);
y_597 = _t596; }
{ V _t598 = GetIdx(_t593, 2D);
r_599 = _t598; }
}
b_363.S("<path transform=\"translate(").V(Call(f_17, V.Undef, x_595)).S(" ").V(Call(f_17, V.Undef, y_597)).S(") scale(").N((ToNum(r_599) / 6D)).S(")\" d=\"M0 -9Q6 -1 6 3A6 6 0 0 1 -6 3Q-6 -1 0 -9Z\" fill=\"#cdf4ff\" stroke=\"#4fb8e8\" stroke-width=\"1.4\"/>");
return default;
}, 1, "", true));
me_378 = Call(P_350, V.Undef, ((V)((-6D))), ((V)((-0.02))), ((V)(CH_357)));
b_363.S("<ellipse cx=\"").V(Call(f_17, V.Undef, Add(GetIdx(me_378, 0D), ((V)(2D))))).S("\" cy=\"").V(Call(f_17, V.Undef, Add(GetIdx(me_378, 1D), ((V)(2D))))).S("\" rx=\"40\" ry=\"13\" fill=\"#2a3a20\" opacity=\"0.2\"/>").V(Call(speed_24, V.Undef, ((V)((ToNum(GetIdx(me_378, 0D)) - 22D))), ((V)((ToNum(GetIdx(me_378, 1D)) - 56D))), ((V)(A_341)), ((V)(4D)), ((V)(56D)), ((V)("#ffffff")), ((V)(0.9))));
Invoke(Arr(Arr(((V)((-52D))), ((V)((-8D)))), Arr(((V)((-64D))), ((V)((-1D)))), Arr(((V)((-45D))), ((V)(4D))), Arr(((V)((-74D))), ((V)((-12D))))), "forEach", Fn((V _self331, int _argc600, V _a602, V i_606, V _a604, V _a605, V[] _rest601) => {
V dx_609 = default;
V dy_611 = default;
{ V _t607 = ListOf(_a602);
{ V _t608 = GetIdx(_t607, 0D);
dx_609 = _t608; }
{ V _t610 = GetIdx(_t607, 1D);
dy_611 = _t610; }
}
b_363.S("<circle cx=\"").V(Call(f_17, V.Undef, Add(GetIdx(me_378, 0D), dx_609))).S("\" cy=\"").V(Call(f_17, V.Undef, Add(GetIdx(me_378, 1D), dy_611))).S("\" r=\"").N((3.6 - (ToNum(i_606) * 0.5))).S("\" fill=\"#dff4ff\" stroke=\"#8fd6ff\" stroke-width=\"1\"/>");
return default;
}, 2, "", true));
b_363.V(Call(stk_26, V.Undef, u_338, Get(c_339, "src"), GetIdx(me_378, 0D), Add(GetIdx(me_378, 1D), ((V)(5D))), ((V)(118D)), ((V)(0D)), (false ? V.True : V.False), NewObj(7).Put("sit", ((V)(1D))).Put("armL", ((V)(155D))).Put("armR", ((V)(150D))).Put("hap", ((V)(1D))).Put("open", ((V)(0.85))).Put("smile", ((V)(1D))).Put("lean", ((V)((-0.55)))).V, V.Null, V.Null, ((V)(58D))));
b_363.V(Call(badge_29, V.Undef, ((V)(76D)), ((V)(300D)), ((V)(23D)), ((V)("WHEE!")), ((V)((-10D))), ((V)("#ffd84a")), ((V)("#7a3a10")), ((V)(17D))));
b_363.V(Add(Add(Call(spark_22, V.Undef, ((V)(110D)), ((V)(120D)), ((V)(6D))), Call(spark_22, V.Undef, ((V)(390D)), ((V)(92D)), ((V)(6D)), ((V)("#fff6c8")))), Call(spark_22, V.Undef, ((V)(300D)), ((V)(300D)), ((V)(5D)))));
return Call(wrapL_31, V.Undef, u_338, defs_362, ((V)(JsStrBuf.Begin().S(b_363.Str).V(Get(L_340, "body")).End())));
return default;
}, 2, "slide", false);
corn_38 = Fn((V _self612, int _argc613, V u_619, V c_620, V _a617, V _a618, V[] _rest614) => {
V L_621 = default;
V defs_622 = default;
JsStrBuf b_623 = null;
V top_624 = default;
V bag_625 = default;
if (_self612.IsNullish) _self612 = GlobalV;
L_621 = Call(logo_25, V.Undef, u_619, Arr(((V)("CORNHOLE"))), ((V)(180D)), ((V)(78D)), NewObj(7).Put("size", ((V)(52D))).Put("top", ((V)("#ffffff"))).Put("bot", ((V)("#ffd36a"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#1e3a8a"))).Put("shade", ((V)("#0f2258"))).Put("rot", ((V)((-4D)))).V);
defs_622 = Add(Add(Add(Add(Get(L_621, "defs"), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_619).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#5aa8ff"))), Arr(((V)(0.65)), ((V)("#b6dcff"))), Arr(((V)(1D)), ((V)("#eef8ff")))))), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_619).S("gr").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#9fdc6e"))), Arr(((V)(1D)), ((V)("#5fb04a")))))), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_619).S("bd").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#6aa4ff"))), Arr(((V)(1D)), ((V)("#3a72e0")))))), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_619).S("bg").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#ff7a6a"))), Arr(((V)(1D)), ((V)("#d63a3a"))))));
b_623 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-420\" width=\"1400\" height=\"640\" fill=\"url(#").V(u_619).S("sk)\"/>").V(Call(rays_21, V.Undef, ((V)(206D)), ((V)(242D)), ((V)(22D)), ((V)("#ffffff")), ((V)(0.17)))).V(Call(cloud_23, V.Undef, ((V)(70D)), ((V)(150D)), ((V)(0.6)), ((V)(0.8)))).V(Call(cloud_23, V.Undef, ((V)(300D)), ((V)(176D)), ((V)(0.5)), ((V)(0.7)))).End());
b_623.V(Call(backdrop_32, V.Undef, ((V)(290D)), Arr(((V)("#4f9a3e")), ((V)("#62ad4c"))), ((V)(0.9)))).S("<path d=\"M-420 286H980V640H-420Z\" fill=\"url(#").V(u_619).S("gr)\"/>");
b_623.S("<path d=\"M326 140V300\" stroke=\"#e8e0d4\" stroke-width=\"5\" stroke-linecap=\"round\"/><circle cx=\"326\" cy=\"138\" r=\"5\" fill=\"#ffd84a\"/><path d=\"M326 146C304 140 292 154 272 150C286 160 290 170 276 182C296 180 308 168 326 176Z\" fill=\"#ff5e6c\" stroke=\"#b8304a\" stroke-width=\"2\" stroke-linejoin=\"round\"/>");
b_623.S("<path d=\"M262 160h-18M258 170h-12\" stroke=\"#ffffff\" stroke-width=\"3\" stroke-linecap=\"round\" opacity=\"0.8\"/>");
top_624 = Arr(Arr(((V)(118D)), ((V)(362D))), Arr(((V)(298D)), ((V)(362D))), Arr(((V)(262D)), ((V)(214D))), Arr(((V)(154D)), ((V)(214D))));
b_623.S("<ellipse cx=\"208\" cy=\"368\" rx=\"104\" ry=\"12\" fill=\"#2a4a20\" opacity=\"0.25\"/><path d=\"M160 214L156 252M256 214L260 252\" stroke=\"#a87444\" stroke-width=\"7\" stroke-linecap=\"round\"/>");
b_623.S("<path d=\"M118 362L298 362L298 372L118 372Z\" fill=\"#c98d54\"/><path d=\"M").V(Invoke(Invoke(top_624, "map", Fn((V _self612, int _argc626, V p_632, V _a629, V _a630, V _a631, V[] _rest627) => {
return Invoke(p_632, "join", ((V)(" ")));
}, 1, "", true)), "join", ((V)("L")))).S("Z\" fill=\"url(#").V(u_619).S("bd)\" stroke=\"#2a56b8\" stroke-width=\"3\" stroke-linejoin=\"round\"/>");
b_623.S("<path d=\"M133 300L284 300L276 268L141 268Z\" fill=\"#ffffff\" opacity=\"0.9\"/><path d=\"M137 286L281 286\" stroke=\"#ff5e6c\" stroke-width=\"6\"/>");
b_623.S("<ellipse cx=\"208\" cy=\"238\" rx=\"22\" ry=\"8\" fill=\"#14224a\"/><ellipse cx=\"208\" cy=\"236\" rx=\"22\" ry=\"8\" fill=\"none\" stroke=\"#9fc4ff\" stroke-width=\"2\"/>");
bag_625 = Fn((V _self612, int _argc633, V x_639, V y_640, V k_641, V r_642, V[] _rest634) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(x_639).S(" ").V(y_640).S(") rotate(").V(r_642).S(") scale(").V(k_641).S(")\"><path d=\"M-17 -13Q0 -17 17 -13Q21 0 17 13Q0 17 -17 13Q-21 0 -17 -13Z\" fill=\"url(#").V(u_619).S("bg)\" stroke=\"#8a1c24\" stroke-width=\"2\"/><path d=\"M-13 -9Q0 -12 13 -9\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.6\" stroke-dasharray=\"2 3\" opacity=\"0.8\"/><ellipse cx=\"-5\" cy=\"-5\" rx=\"6\" ry=\"3\" fill=\"#ffffff\" opacity=\"0.35\"/></g>").End()));
}, 4, "", true);
b_623.V(Call(bag_625, V.Undef, ((V)(246D)), ((V)(252D)), ((V)(0.8)), ((V)(18D))));
b_623.S("<path d=\"M112 232Q142 70 200 220\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"5\" stroke-dasharray=\"1 12\" stroke-linecap=\"round\" opacity=\"0.95\"/>").V(Call(speed_24, V.Undef, ((V)(176D)), ((V)(150D)), ((V)(0.95)), ((V)(3D)), ((V)(46D)), ((V)("#ffffff")), ((V)(0.8)))).V(Call(bag_625, V.Undef, ((V)(184D)), ((V)(168D)), ((V)(1.15)), ((V)(34D))));
b_623.V(Call(badge_29, V.Undef, ((V)(276D)), ((V)(112D)), ((V)(30D)), ((V)("+3")), ((V)(10D)), ((V)("#ffd84a")), ((V)("#7a3a10")), ((V)(26D))));
b_623.V(Add(Add(Call(spark_22, V.Undef, ((V)(226D)), ((V)(214D)), ((V)(7D))), Call(spark_22, V.Undef, ((V)(140D)), ((V)(120D)), ((V)(6D)))), Call(spark_22, V.Undef, ((V)(196D)), ((V)(270D)), ((V)(5D)), ((V)("#ffffff")), ((V)(0.9)))));
b_623.S("<ellipse cx=\"76\" cy=\"346\" rx=\"58\" ry=\"11\" fill=\"#2a4a20\" opacity=\"0.25\"/>").V(Call(stk_26, V.Undef, u_619, Get(c_620, "src"), ((V)(76D)), ((V)(350D)), ((V)(150D)), ((V)((-6D))), (false ? V.True : V.False), NewObj(9).Put("hRx", ((V)((-2D)))).Put("hRy", ((V)((-6D)))).Put("armR", ((V)(100D))).Put("lean", ((V)(0.8))).Put("footL", ((V)(2D))).Put("sq", ((V)((-0.03)))).Put("open", ((V)(0.3))).Put("lx", ((V)(0.8))).Put("ly", ((V)((-0.2)))).V));
return Call(wrap_30, V.Undef, u_619, defs_622, ((V)(JsStrBuf.Begin().S(b_623.Str).V(Get(L_621, "body")).End())));
return default;
}, 2, "corn", false);
pong_39 = Fn((V _self643, int _argc644, V u_650, V c_651, V _a648, V _a649, V[] _rest645) => {
V L_652 = default;
V defs_653 = default;
V paddle_654 = default;
JsStrBuf b_655 = null;
if (_self643.IsNullish) _self643 = GlobalV;
L_652 = Call(logo_25, V.Undef, u_650, Arr(((V)("PING-PONG"))), ((V)(180D)), ((V)(74D)), NewObj(7).Put("size", ((V)(50D))).Put("top", ((V)("#ffffff"))).Put("bot", ((V)("#9ff0c8"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#0e4a3a"))).Put("shade", ((V)("#062a20"))).Put("rot", ((V)((-4D)))).V);
defs_653 = Add(Add(Add(Add(Add(Get(L_652, "defs"), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_650).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#1f8a62"))), Arr(((V)(0.55)), ((V)("#5fcf9a"))), Arr(((V)(1D)), ((V)("#d6f6e6")))))), Call(lg_19, V.Undef, ((V)(JsStrBuf.Begin().V(u_650).S("tb").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#3a74e0"))), Arr(((V)(1D)), ((V)("#2a5ccc")))))), Call(rg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_650).S("pd").End())), ((V)("40%")), ((V)("35%")), ((V)("70%")), Arr(Arr(((V)(0D)), ((V)("#ff8a7a"))), Arr(((V)(1D)), ((V)("#d0303a")))))), Call(rg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_650).S("pb").End())), ((V)("40%")), ((V)("35%")), ((V)("70%")), Arr(Arr(((V)(0D)), ((V)("#7fb0ff"))), Arr(((V)(1D)), ((V)("#2a5ccc")))))), Call(rg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_650).S("ball").End())), ((V)("35%")), ((V)("30%")), ((V)("70%")), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(1D)), ((V)("#e8dcc8"))))));
paddle_654 = Fn((V _self643, int _argc656, V fill_662, V rot_663, V k_664, V _a661, V[] _rest657) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"rotate(").V(rot_663).S(") scale(").V(k_664).S(")\"><rect x=\"-7\" y=\"-6\" width=\"14\" height=\"40\" rx=\"6\" fill=\"#c98d54\" stroke=\"#4a3a2e\" stroke-width=\"3\"/><rect x=\"-7\" y=\"6\" width=\"14\" height=\"5\" fill=\"#8a5a34\" opacity=\"0.5\"/><ellipse cy=\"-38\" rx=\"30\" ry=\"33\" fill=\"url(#").V(u_650).V(fill_662).S(")\" stroke=\"#4a3a2e\" stroke-width=\"3.5\"/><ellipse cx=\"-9\" cy=\"-50\" rx=\"10\" ry=\"6\" fill=\"#ffffff\" opacity=\"0.3\" transform=\"rotate(-20 -9 -50)\"/></g>").End()));
}, 3, "", true);
b_655 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-420\" width=\"1400\" height=\"640\" fill=\"url(#").V(u_650).S("sk)\"/>").V(Call(rays_21, V.Undef, ((V)(180D)), ((V)(212D)), ((V)(24D)), ((V)("#ffffff")), ((V)(0.12)))).End());
b_655.V(Call(backdrop_32, V.Undef, ((V)(226D)), Arr(((V)("#2f8a5a")), ((V)("#3fa06a"))), ((V)(0.7)))).S("<path d=\"M-420 222H980V640H-420Z\" fill=\"#e8dcc8\"/>");
{
double i_665 = 0;
i_665 = (-7D);
while (true) {
if (!((i_665 <= 7D))) break;
b_655.S("<path d=\"M").N((180D + (i_665 * 20D))).S(" 222L").N((180D + (i_665 * 90D))).S(" 640\" stroke=\"#d4c6ae\" stroke-width=\"2\"/>");
i_665++;
}
}
Invoke(Arr(((V)(236D)), ((V)(258D)), ((V)(290D)), ((V)(336D)), ((V)(404D))), "forEach", Fn((V _self643, int _argc667, V y_673, V _a670, V _a671, V _a672, V[] _rest668) => {
b_655.S("<path d=\"M-10 ").V(y_673).S("H370\" stroke=\"#d4c6ae\" stroke-width=\"2\"/>");
return default;
}, 1, "", true));
b_655.S("<ellipse cx=\"196\" cy=\"236\" rx=\"34\" ry=\"7\" fill=\"#3a2a2a\" opacity=\"0.2\"/>").V(Call(stk_26, V.Undef, u_650, ((V)("")), ((V)(196D)), ((V)(240D)), ((V)(104D)), ((V)((-3D))), (false ? V.True : V.False), NewObj(7).Put("armR", ((V)(70D))).Put("hRy", ((V)((-4D)))).Put("lift", ((V)(1D))).Put("sq", ((V)(0.04))).Put("open", ((V)(0.3))).Put("lx", ((V)(0.3))).Put("ly", ((V)(0.4))).V, NewObj(2).Put("at", ((V)("pawR"))).Put("svg", Call(paddle_654, V.Undef, ((V)("pb")), ((V)(30D)), ((V)(0.36)))).V, ((V)("opp"))));
b_655.S("<path d=\"M60 360L64 410M300 360L296 410M104 232L106 262M256 232L254 262\" stroke=\"#3a3a4a\" stroke-width=\"6\" stroke-linecap=\"round\"/>");
b_655.S("<path d=\"M24 352L336 352L336 364L24 364Z\" fill=\"#1e3e8a\"/><path d=\"M24 352L336 352L268 226L92 226Z\" fill=\"url(#").V(u_650).S("tb)\" stroke=\"#ffffff\" stroke-width=\"4\" stroke-linejoin=\"round\"/><path d=\"M180 352L180 226\" stroke=\"#ffffff\" stroke-width=\"2.5\"/>");
b_655.S("<path d=\"M62 280H298\" stroke=\"#1a2a5a\" stroke-width=\"3\" opacity=\"0.35\"/><path d=\"M58 258L302 258L302 282L58 282Z\" fill=\"#ffffff\" opacity=\"0.3\"/><g stroke=\"#ffffff\" stroke-width=\"1\" opacity=\"0.7\">");
{
double x_674 = 0;
x_674 = 64D;
while (true) {
if (!((x_674 < 302D))) break;
b_655.S("<path d=\"M").N(x_674).S(" 258V282\"/>");
x_674 = (x_674 + 8D);
}
}
b_655.S("</g><path d=\"M54 258H306\" stroke=\"#ffffff\" stroke-width=\"4\"/><path d=\"M56 256V286M304 256V286\" stroke=\"#2a2a3a\" stroke-width=\"4\" stroke-linecap=\"round\"/>");
b_655.S("<path d=\"M206 214Q194 250 176 318L168 300Q156 262 150 236\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"4\" stroke-dasharray=\"1 10\" stroke-linecap=\"round\" opacity=\"0.95\"/><ellipse cx=\"174\" cy=\"318\" rx=\"11\" ry=\"3.5\" fill=\"#ffffff\" opacity=\"0.6\"/>");
b_655.V(Call(speed_24, V.Undef, ((V)(150D)), ((V)(232D)), ((V)(1.85)), ((V)(3D)), ((V)(30D)), ((V)("#ffffff")), ((V)(0.8)))).S("<circle cx=\"150\" cy=\"228\" r=\"10\" fill=\"url(#").V(u_650).S("ball)\" stroke=\"#c8b898\" stroke-width=\"1\"/>");
b_655.S("<ellipse cx=\"236\" cy=\"452\" rx=\"74\" ry=\"14\" fill=\"#3a2a2a\" opacity=\"0.2\"/>").V(Call(stk_26, V.Undef, u_650, Get(c_651, "src"), ((V)(236D)), ((V)(456D)), ((V)(200D)), ((V)(3D)), (false ? V.True : V.False), NewObj(5).Put("armR", ((V)(120D))).Put("hRy", ((V)((-8D)))).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.04)))).Put("tilt", ((V)((-3D)))).V, NewObj(2).Put("at", ((V)("pawR"))).Put("svg", Call(paddle_654, V.Undef, ((V)("pd")), ((V)((-26D))), ((V)(0.8)))).V, V.Null, ((V)(180D))));
b_655.V(Call(badge_29, V.Undef, ((V)(70D)), ((V)(168D)), ((V)(28D)), ((V)("RALLY!")), ((V)((-8D))), ((V)("#ffd84a")), ((V)("#7a3a10")), ((V)(17D))));
b_655.V(Add(Add(Call(spark_22, V.Undef, ((V)(300D)), ((V)(182D)), ((V)(7D))), Call(spark_22, V.Undef, ((V)(46D)), ((V)(236D)), ((V)(5D)))), Call(spark_22, V.Undef, ((V)(118D)), ((V)(200D)), ((V)(5D)))));
return Call(wrap_30, V.Undef, u_650, defs_653, ((V)(JsStrBuf.Begin().S(b_655.Str).V(Get(L_652, "body")).End())));
return default;
}, 2, "pong", false);
YG_15 = Get(G("window"), "YardGames");
if ((!(Truthy(YG_15)) || !(Truthy(Get(YG_15, "add"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
TAU_16 = (System.Math.PI * 2D);
f_17 = Fn((V _self1, int _argc676, V v_682, V _a679, V _a680, V _a681, V[] _rest677) => {
return ((V)((Round((ToNum(v_682) * 10D)) / 10D)));
}, 1, "", true);
esc_18 = Fn((V _self1, int _argc683, V s_689, V _a686, V _a687, V _a688, V[] _rest684) => {
return Invoke(((V)(ToStrS((s_689.IsNullish ? ((V)("")) : s_689)))), "replace", NewRegExp(RX0, "[&<>\"]", "g"), Fn((V _self1, int _argc690, V c_696, V _a693, V _a694, V _a695, V[] _rest691) => {
return GetK(NewObj(4).Put("&", ((V)("&amp;"))).Put("<", ((V)("&lt;"))).Put(">", ((V)("&gt;"))).Put("\"", ((V)("&quot;"))).V, c_696);
}, 1, "", true));
}, 1, "", true);
lg_19 = Fn((V _self1, int _argc697, V id_703, V x2_704, V y2_705, V stops_706, V[] _rest698) => {
return ((V)(JsStrBuf.Begin().S("<linearGradient id=\"").V(id_703).S("\" x1=\"0\" y1=\"0\" x2=\"").V(x2_704).S("\" y2=\"").V(y2_705).S("\">").V(Invoke(Invoke(stops_706, "map", Fn((V _self1, int _argc707, V _a709, V _a710, V _a711, V _a712, V[] _rest708) => {
V o_715 = default;
V c_717 = default;
V a_719 = default;
{ V _t713 = ListOf(_a709);
{ V _t714 = GetIdx(_t713, 0D);
o_715 = _t714; }
{ V _t716 = GetIdx(_t713, 1D);
c_717 = _t716; }
{ V _t718 = GetIdx(_t713, 2D);
a_719 = _t718; }
}
return ((V)(JsStrBuf.Begin().S("<stop offset=\"").V(o_715).S("\" stop-color=\"").V(c_717).S("\"").S((!a_719.IsNullish ? JsStrBuf.Begin().S(" stop-opacity=\"").V(a_719).S("\"").End() : "")).S("/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</linearGradient>").End()));
}, 4, "", true);
rg_20 = Fn((V _self1, int _argc720, V id_726, V cx_727, V cy_728, V r_729, V[] _rest721) => {
V stops_730 = default;
stops_730 = (_argc720 > 4 ? _rest721[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<radialGradient id=\"").V(id_726).S("\" cx=\"").V(cx_727).S("\" cy=\"").V(cy_728).S("\" r=\"").V(r_729).S("\">").V(Invoke(Invoke(stops_730, "map", Fn((V _self1, int _argc731, V _a733, V _a734, V _a735, V _a736, V[] _rest732) => {
V o_739 = default;
V c_741 = default;
V a_743 = default;
{ V _t737 = ListOf(_a733);
{ V _t738 = GetIdx(_t737, 0D);
o_739 = _t738; }
{ V _t740 = GetIdx(_t737, 1D);
c_741 = _t740; }
{ V _t742 = GetIdx(_t737, 2D);
a_743 = _t742; }
}
return ((V)(JsStrBuf.Begin().S("<stop offset=\"").V(o_739).S("\" stop-color=\"").V(c_741).S("\"").S((!a_743.IsNullish ? JsStrBuf.Begin().S(" stop-opacity=\"").V(a_743).S("\"").End() : "")).S("/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</radialGradient>").End()));
}, 5, "", true);
rays_21 = Fn((V _self1, int _argc744, V cx_750, V cy_751, V n_752, V col_753, V[] _rest745) => {
JsStrBuf d_756 = null;
V op_754 = default;
V a0_755 = default;
op_754 = (_argc744 > 4 ? _rest745[0] : V.Undef);
a0_755 = (_argc744 > 5 ? _rest745[1] : V.Undef);
d_756 = new JsStrBuf("");
{
double i_757 = 0;
i_757 = 0D;
while (true) {
if (!(Lt(((V)(i_757)), n_752))) break;
V a_759 = default;
V b_760 = default;
a_759 = Add((a0_755 is var _t761 && Truthy(_t761) ? _t761 : ((V)(0D))), ((V)(((i_757 / ToNum(n_752)) * TAU_16))));
b_760 = Add(a_759, ((V)(((TAU_16 / ToNum(n_752)) / 2D))));
d_756.S("M").V(cx_750).S(" ").V(cy_751).S("L").V(Call(f_17, V.Undef, Add(cx_750, ((V)((FdLibm.Cos(ToNum(a_759)) * 1100D)))))).S(" ").V(Call(f_17, V.Undef, Add(cy_751, ((V)((FdLibm.Sin(ToNum(a_759)) * 1100D)))))).S("L").V(Call(f_17, V.Undef, Add(cx_750, ((V)((FdLibm.Cos(ToNum(b_760)) * 1100D)))))).S(" ").V(Call(f_17, V.Undef, Add(cy_751, ((V)((FdLibm.Sin(ToNum(b_760)) * 1100D)))))).S("Z");
i_757++;
}
}
return ((V)(JsStrBuf.Begin().S("<path d=\"").S(d_756.Str).S("\" fill=\"").V(col_753).S("\" opacity=\"").V(op_754).S("\"/>").End()));
return default;
}, 6, "", true);
spark_22 = Fn((V _self1, int _argc762, V x_768, V y_769, V r_770, V col_771, V[] _rest763) => {
V op_772 = default;
op_772 = (_argc762 > 4 ? _rest763[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<path transform=\"translate(").V(Call(f_17, V.Undef, x_768)).S(" ").V(Call(f_17, V.Undef, y_769)).S(") scale(").V(r_770).S(")\" d=\"M0 -1C0.13 -0.3 0.3 -0.13 1 0C0.3 0.13 0.13 0.3 0 1C-0.13 0.3 -0.3 0.13 -1 0C-0.3 -0.13 -0.13 -0.3 0 -1Z\" fill=\"").V((col_771 is var _t773 && Truthy(_t773) ? _t773 : ((V)("#ffffff")))).S("\"").S((!op_772.IsNullish ? JsStrBuf.Begin().S(" opacity=\"").V(op_772).S("\"").End() : "")).S("/>").End()));
}, 5, "", true);
cloud_23 = Fn((V _self1, int _argc774, V x_780, V y_781, V k_782, V op_783, V[] _rest775) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(x_780).S(" ").V(y_781).S(") scale(").V(k_782).S(")\" fill=\"#ffffff\" opacity=\"").V((op_783 is var _t784 && Truthy(_t784) ? _t784 : ((V)(0.95)))).S("\"><circle cx=\"-26\" cy=\"4\" r=\"18\"/><circle cx=\"0\" cy=\"-8\" r=\"25\"/><circle cx=\"27\" cy=\"2\" r=\"19\"/><circle cx=\"10\" cy=\"10\" r=\"18\"/><circle cx=\"-12\" cy=\"11\" r=\"16\"/></g>").End()));
}, 4, "", true);
speed_24 = Fn((V _self1, int _argc785, V x_791, V y_792, V ang_793, V n_794, V[] _rest786) => {
JsStrBuf s_798 = null;
double ca_799 = 0;
double sa_800 = 0;
V len_795 = default;
V col_796 = default;
V op_797 = default;
len_795 = (_argc785 > 4 ? _rest786[0] : V.Undef);
col_796 = (_argc785 > 5 ? _rest786[1] : V.Undef);
op_797 = (_argc785 > 6 ? _rest786[2] : V.Undef);
s_798 = new JsStrBuf("");
ca_799 = FdLibm.Cos(ToNum(ang_793));
sa_800 = FdLibm.Sin(ToNum(ang_793));
{
double i_801 = 0;
i_801 = 0D;
while (true) {
if (!(Lt(((V)(i_801)), n_794))) break;
double o_803 = 0;
double l_804 = 0;
double bx_805 = 0;
double by_806 = 0;
o_803 = ((i_801 - ((ToNum(n_794) - 1D) / 2D)) * 11D);
l_804 = (ToNum(len_795) * (0.6 + ((0.4 * ((i_801 * 37D) % 10D)) / 10D)));
bx_805 = ((ToNum(x_791) - (sa_800 * o_803)) - (ca_799 * (14D + ((i_801 % 2D) * 8D))));
by_806 = (ToNum(Add(y_792, ((V)((ca_799 * o_803))))) - (sa_800 * (14D + ((i_801 % 2D) * 8D))));
s_798.S("<path d=\"M").V(Call(f_17, V.Undef, ((V)(bx_805)))).S(" ").V(Call(f_17, V.Undef, ((V)(by_806)))).S("L").V(Call(f_17, V.Undef, ((V)((bx_805 - (ca_799 * l_804)))))).S(" ").V(Call(f_17, V.Undef, ((V)((by_806 - (sa_800 * l_804)))))).S("\" stroke=\"").V((col_796 is var _t807 && Truthy(_t807) ? _t807 : ((V)("#ffffff")))).S("\" stroke-width=\"").N((NumTruthy((i_801 % 2D)) ? 3D : 4.5)).S("\" stroke-linecap=\"round\" opacity=\"").V((op_797 is var _t808 && Truthy(_t808) ? _t808 : ((V)(0.8)))).S("\"/>");
i_801++;
}
}
return ((V)(s_798.Str));
return default;
}, 7, "", true);
stk_26 = Fn((V _self1, int _argc809, V u_815, V src_816, V x_817, V y_818, V[] _rest810) => {
V w_819 = default;
V rot_820 = default;
V flip_821 = default;
V pose_822 = default;
V prop_823 = default;
V who_824 = default;
V yaw_825 = default;
w_819 = (_argc809 > 4 ? _rest810[0] : V.Undef);
rot_820 = (_argc809 > 5 ? _rest810[1] : V.Undef);
flip_821 = (_argc809 > 6 ? _rest810[2] : V.Undef);
pose_822 = (_argc809 > 7 ? _rest810[3] : V.Undef);
prop_823 = (_argc809 > 8 ? _rest810[4] : V.Undef);
who_824 = (_argc809 > 9 ? _rest810[5] : V.Undef);
yaw_825 = (_argc809 > 10 ? _rest810[6] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(f_17, V.Undef, x_817)).S(" ").V(Call(f_17, V.Undef, y_818)).S(") rotate(").V((rot_820 is var _t826 && Truthy(_t826) ? _t826 : ((V)(0D)))).S(")").S((Truthy(flip_821) ? " scale(-1 1)" : "")).S("\"><g class=\"ygp-cr\" style=\"opacity:0;transition:opacity .25s ease\" data-w=\"").V(w_819).S("\" data-src=\"").V(Call(esc_18, V.Undef, src_816)).S("\"").S((Truthy(pose_822) ? JsStrBuf.Begin().S(" data-pose=\"").V(Call(esc_18, V.Undef, Invoke(G("JSON"), "stringify", pose_822))).S("\"").End() : "")).S((Truthy(who_824) ? JsStrBuf.Begin().S(" data-who=\"").V(who_824).S("\"").End() : "")).S((Truthy(yaw_825) ? JsStrBuf.Begin().S(" data-yaw=\"").V(yaw_825).S("\"").End() : "")).S("></g>").S((Truthy(prop_823) ? JsStrBuf.Begin().S("<g class=\"ygp-prop\" data-at=\"").V(Get(prop_823, "at")).S("\" style=\"opacity:0;transition:opacity .25s ease\">").V(Get(prop_823, "svg")).S("</g>").End() : "")).S("</g>").End()));
}, 11, "", true);
POOL_27 = Arr(((V)("biscuit")), ((V)("pip")), ((V)("mallow")), ((V)("nimbo")), ((V)("ribbit")), ((V)("bao")), ((V)("mittens")), ((V)("sealy")), ((V)("frybo")), ((V)("poppy")));
Set(YG_15, "posterRig", Fn((V _self827, int _argc828, V el_834, V key0_835, V o_836, V _a833, V[] _rest829) => {
V R_837 = default;
V SQ_838 = default;
V pool_839 = default;
V opp_840 = default;
if (_self827.IsNullish) _self827 = GlobalV;
R_837 = Get(G("window"), "RiveRig");
o_836 = (o_836 is var _t841 && Truthy(_t841) ? _t841 : NewObj(0).V);
SQ_838 = Get(G("window"), "SquishSquad");
pool_839 = (Truthy((SQ_838 is var _t858 && !Truthy(_t858) ? _t858 : Get(SQ_838, "ROSTER"))) ? Invoke(Invoke(Get(SQ_838, "ROSTER"), "filter", Fn((V _self827, int _argc849, V c_855, V _a852, V _a853, V _a854, V[] _rest850) => {
return (c_855 is var _t857 && !Truthy(_t857) ? _t857 : Invoke((Get(YG_15, "SETS") is var _t856 && Truthy(_t856) ? _t856 : Arr(((V)("snack")), ((V)("fruit")), ((V)("pet")))), "includes", Get(c_855, "set")));
}, 1, "", true)), "map", Fn((V _self827, int _argc842, V c_848, V _a845, V _a846, V _a847, V[] _rest843) => {
return Get(c_848, "key");
}, 1, "", true)) : POOL_27);
opp_840 = (Get(o_836, "opp") is var _t873 && Truthy(_t873) ? _t873 : Call(Fn((V _self827, int _argc866, V L_872, V _a869, V _a870, V _a871, V[] _rest867) => {
return GetIdx(L_872, System.Math.Floor((ToNum(Invoke(G("Math"), "random")) * ToNum(Get(L_872, "length")))));
}, 1, "", true), V.Undef, Invoke(pool_839, "filter", Fn((V _self827, int _argc859, V k_865, V _a862, V _a863, V _a864, V[] _rest860) => {
return (!SEq(k_865, key0_835) ? V.True : V.False);
}, 1, "", true))));
Invoke(Invoke(el_834, "querySelectorAll", ((V)(".ygp-cr"))), "forEach", Fn((V _self827, int _argc874, V g_880, V _a877, V _a878, V _a879, V[] _rest875) => {
double w_881 = 0;
V key_882 = default;
V flatSrc_883 = default;
V flat_884 = default;
V host_885 = default;
V C_886 = default;
V I_887 = default;
V svg_888 = default;
V prop_889 = default;
V hold_890 = default;
V t0_891 = default;
V end_892 = default;
V wait_893 = default;
w_881 = ToNum(Get(Get(g_880, "dataset"), "w"));
key_882 = (SEqS(Get(Get(g_880, "dataset"), "who"), "opp") ? opp_840 : key0_835);
flatSrc_883 = (SEqS(Get(Get(g_880, "dataset"), "who"), "opp") ? ((V)("")) : Get(Get(g_880, "dataset"), "src"));
flat_884 = Fn((V _self827, int _argc894, V _a896, V _a897, V _a898, V _a899, V[] _rest895) => {
if (!(Truthy(flatSrc_883))) {
return default;
}
if (!(Truthy(Invoke(g_880, "querySelector", ((V)("image")))))) {
Invoke(g_880, "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<image href=\"").V(Call(esc_18, V.Undef, flatSrc_883)).S("\" x=\"").V(Call(f_17, V.Undef, ((V)(((-w_881) / 2D))))).S("\" y=\"").V(Call(f_17, V.Undef, ((V)(((-w_881) * 0.95))))).S("\" width=\"").N(w_881).S("\" height=\"").N(w_881).S("\" preserveAspectRatio=\"xMidYMax meet\"/>").End())));
}
Set(Get(g_880, "style"), "opacity", ((V)(1D)));
return default;
}, 0, "", true);
if (((!(Truthy(R_837)) || !(Truthy(Get(R_837, "mount")))) || !(Truthy(key_882)))) {
return Call(flat_884, V.Undef);
}
host_885 = Invoke(G("document"), "createElement", ((V)("div")));
Set(Get(host_885, "style"), "cssText", ((V)(JsStrBuf.Begin().S("position:fixed;left:-5000px;top:0;width:").N(w_881).S("px;height:").N(w_881).S("px;pointer-events:none;").End())));
Invoke(Get(G("document"), "body"), "appendChild", host_885);
C_886 = V.Null;
try {
C_886 = Invoke(R_837, "mount", host_885, key_882, NewObj(2).Put("fidgets", (false ? V.True : V.False)).Put("look", ((V)(3D))).V);
} catch (System.Exception _ex900) {
V e_901 = default;
e_901 = Caught(_ex900);
Invoke(host_885, "remove");
return Call(flat_884, V.Undef);
}
I_887 = (C_886 is var _t902 && !Truthy(_t902) ? _t902 : Get(C_886, "_I"));
svg_888 = Invoke(host_885, "querySelector", ((V)("svg")));
if ((!(Truthy(I_887)) || !(Truthy(svg_888)))) {
try {
if (Truthy(C_886)) {
Invoke(C_886, "destroy");
}
} catch (System.Exception _ex903) {
V e_904 = default;
e_904 = Caught(_ex903);

}
Invoke(host_885, "remove");
return Call(flat_884, V.Undef);
}
Set(I_887, "fidgets", (false ? V.True : V.False));
Set(I_887, "ptr", V.Null);
Set(I_887, "blinkAt", ((V)(1000000000000000D)));
Set(I_887, "glAt", ((V)(1000000000000000D)));
Set(I_887, "blinkT", ((V)((-1000000000D))));
if (Truthy(Get(Get(g_880, "dataset"), "pose"))) {
try {
Set(I_887, "ext", Invoke(G("JSON"), "parse", Get(Get(g_880, "dataset"), "pose")));
} catch (System.Exception _ex905) {
V e_906 = default;
e_906 = Caught(_ex905);

}
}
if (Truthy(Get(Get(g_880, "dataset"), "yaw"))) {
Set(I_887, "spinOff", ((V)(ToNum(Get(Get(g_880, "dataset"), "yaw")))));
}
if (Truthy(Get(I_887, "shadow"))) {
Set(Get(Get(I_887, "shadow"), "style"), "display", ((V)("none")));
}
Invoke(svg_888, "setAttribute", ((V)("style")), ((V)("overflow:visible")));
Invoke(svg_888, "setAttribute", ((V)("x")), Call(f_17, V.Undef, ((V)(((-w_881) / 2D)))));
Invoke(svg_888, "setAttribute", ((V)("y")), Call(f_17, V.Undef, ((V)(((-w_881) * 0.93)))));
Invoke(svg_888, "setAttribute", ((V)("width")), ((V)(w_881)));
Invoke(svg_888, "setAttribute", ((V)("height")), ((V)(w_881)));
Invoke(g_880, "appendChild", svg_888);
prop_889 = (Get(g_880, "parentNode") is var _t915 && !Truthy(_t915) ? _t915 : Invoke(new ArrBuilder().Spread(Get(Get(g_880, "parentNode"), "children")).V, "find", Fn((V _self827, int _argc907, V e_913, V _a910, V _a911, V _a912, V[] _rest908) => {
return (Get(e_913, "classList") is var _t914 && !Truthy(_t914) ? _t914 : Invoke(Get(e_913, "classList"), "contains", ((V)("ygp-prop"))));
}, 1, "", true)));
hold_890 = Fn((V _self827, int _argc916, V _a918, V _a919, V _a920, V _a921, V[] _rest917) => {
V p_922 = default;
if (!(Truthy(prop_889))) {
return default;
}
p_922 = (Get(I_887, "W") is var _t923 && !Truthy(_t923) ? _t923 : GetK(Get(I_887, "W"), Get(Get(prop_889, "dataset"), "at")));
if (Truthy(p_922)) {
Invoke(prop_889, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(f_17, V.Undef, ((V)((((-w_881) / 2D) + ((ToNum(GetIdx(p_922, 0D)) * w_881) / 100D)))))).S(" ").V(Call(f_17, V.Undef, ((V)((((-w_881) * 0.93) + ((ToNum(GetIdx(p_922, 1D)) * w_881) / 100D)))))).S(")").End())));
}
Set(Get(prop_889, "style"), "opacity", ((V)(1D)));
return default;
}, 0, "", true);
t0_891 = Invoke(G("performance"), "now");
end_892 = Fn((V _self827, int _argc924, V still_930, V _a927, V _a928, V _a929, V[] _rest925) => {
if (Truthy(still_930)) {
Call(hold_890, V.Undef);
} else {
if (Truthy(prop_889)) {
Invoke(prop_889, "remove");
}
}
try {
Invoke(C_886, "destroy");
} catch (System.Exception _ex931) {
V e_932 = default;
e_932 = Caught(_ex931);

}
Invoke(host_885, "remove");
if (!(Truthy(still_930))) {
Invoke(svg_888, "remove");
Call(flat_884, V.Undef);
}
return default;
}, 1, "", true);
wait_893 = Fn((V _self827, int _argc933, V _a935, V _a936, V _a937, V _a938, V[] _rest934) => {
double t_939 = 0;
t_939 = (ToNum(Invoke(G("performance"), "now")) - ToNum(t0_891));
if (!(Truthy(Get(g_880, "isConnected")))) {
return Call(end_892, V.Undef, (true ? V.True : V.False));
}
if (Truthy((Get(I_887, "generic") is var _t940 && !Truthy(_t940) ? _t940 : (!(Truthy(Get(I_887, "ready"))) ? V.True : V.False)))) {
if ((t_939 > 8000D)) {
return Call(end_892, V.Undef, (false ? V.True : V.False));
}
return Call(G("requestAnimationFrame"), V.Undef, wait_893);
}
if (Truthy(Get(I_887, "err"))) {
return Call(end_892, V.Undef, (false ? V.True : V.False));
}
Set(I_887, "blinkAt", ((V)(1000000000000000D)));
Set(I_887, "blinkT", ((V)((-1000000000D))));
if ((t_939 > 250D)) {
Set(Get(g_880, "style"), "opacity", ((V)(1D)));
Call(hold_890, V.Undef);
}
if ((t_939 < 900D)) {
return Call(G("requestAnimationFrame"), V.Undef, wait_893);
}
Call(end_892, V.Undef, (true ? V.True : V.False));
return default;
}, 0, "", true);
Call(G("requestAnimationFrame"), V.Undef, wait_893);
return default;
}, 1, "", true));
return default;
}, 3, "", false));
STK_28 = Fn((V _self1, int _argc941, V u_947, V _a944, V _a945, V _a946, V[] _rest942) => {
return ((V)(JsStrBuf.Begin().S("<filter id=\"").V(u_947).S("stk\" x=\"-20%\" y=\"-20%\" width=\"140%\" height=\"145%\" color-interpolation-filters=\"sRGB\"><feMorphology in=\"SourceAlpha\" operator=\"dilate\" radius=\"3.4\" result=\"d\"/><feFlood flood-color=\"#ffffff\"/><feComposite in2=\"d\" operator=\"in\" result=\"w\"/>").S("<feGaussianBlur in=\"d\" stdDeviation=\"4\"/><feOffset dy=\"6\" result=\"b\"/><feFlood flood-color=\"#2a1048\" flood-opacity=\"0.32\"/><feComposite in2=\"b\" operator=\"in\" result=\"sh\"/><feMerge><feMergeNode in=\"sh\"/><feMergeNode in=\"w\"/><feMergeNode in=\"SourceGraphic\"/></feMerge></filter>").S("<filter id=\"").V(u_947).S("soft\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"5\"/></filter>").End()));
}, 1, "", true);
wrap_30 = Fn((V _self1, int _argc948, V u_954, V defs_955, V body_956, V _a953, V[] _rest949) => {
return ((V)(JsStrBuf.Begin().S("<svg viewBox=\"-40 16 780 360\" preserveAspectRatio=\"xMidYMid slice\" aria-hidden=\"true\"><defs>").V(Call(STK_28, V.Undef, u_954)).V(Call(rg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_954).S("vig").End())), ((V)("40%")), ((V)("45%")), ((V)("80%")), Arr(Arr(((V)(0.6)), ((V)("#000000")), ((V)(0D))), Arr(((V)(1D)), ((V)("#1a0830")), ((V)(0.26)))))).V(defs_955).S("</defs>").V(body_956).S("<rect x=\"-40\" y=\"16\" width=\"780\" height=\"360\" fill=\"url(#").V(u_954).S("vig)\" pointer-events=\"none\"/></svg>").End()));
}, 3, "", true);
wrapL_31 = Fn((V _self1, int _argc957, V u_963, V defs_964, V body_965, V _a962, V[] _rest958) => {
return ((V)(JsStrBuf.Begin().S("<svg viewBox=\"0 0 780 360\" preserveAspectRatio=\"xMidYMid slice\" aria-hidden=\"true\"><defs>").V(Call(STK_28, V.Undef, u_963)).V(Call(rg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_963).S("vig").End())), ((V)("40%")), ((V)("45%")), ((V)("80%")), Arr(Arr(((V)(0.6)), ((V)("#000000")), ((V)(0D))), Arr(((V)(1D)), ((V)("#1a0830")), ((V)(0.26)))))).V(defs_964).S("</defs>").V(body_965).S("<rect width=\"780\" height=\"360\" fill=\"url(#").V(u_963).S("vig)\" pointer-events=\"none\"/></svg>").End()));
}, 3, "", true);
Set(YG_15, "POSTER", NewObj(7).Put("hoop", hoop_33).Put("soccer", soccer_34).Put("hop", hop_35).Put("tramp", tramp_36).Put("slide", slide_37).Put("corn", corn_38).Put("pong", pong_39).V);
return default;
}, 0, "", true);
Call(go_8, V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
