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
go_8 = Fn((V _arrowThis15, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_16 = default;
double TAU_17 = 0;
V f_18 = default;
V esc_19 = default;
V lg_20 = default;
V rg_21 = default;
V rays_22 = default;
V spark_23 = default;
V cloud_24 = default;
V speed_25 = default;
V logo_26 = default;
V stk_27 = default;
V POOL_28 = default;
V STK_29 = default;
V badge_30 = default;
V wrap_31 = default;
V wrapL_32 = default;
V backdrop_33 = default;
V hoop_34 = default;
V soccer_35 = default;
V hop_36 = default;
V tramp_37 = default;
V slide_38 = default;
V corn_39 = default;
V pong_40 = default;
logo_26 = Fn((V _self41, int _argc42, V u_48, V lines_49, V x_50, V y_51, V[] _rest43) => {
V id_53 = default;
V lh_54 = default;
JsStrBuf s_55 = null;
V o_52 = default;
if (_self41.IsNullish) _self41 = GlobalV;
o_52 = (_argc42 > 4 ? _rest43[0] : V.Undef);
id_53 = ((V)(JsStrBuf.Begin().V(u_48).S("lg").End()));
lh_54 = (Get(o_52, "lh") is var _t56 && Truthy(_t56) ? _t56 : ((V)(54D)));
s_55 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"translate(").V(x_50).S(" ").V(y_51).S(") rotate(").V((Get(o_52, "rot") is var _t57 && Truthy(_t57) ? _t57 : ((V)(0D)))).S(")\" font-family=\"Fredoka, Nunito, system-ui, sans-serif\" font-weight=\"700\" text-anchor=\"middle\" stroke-linejoin=\"round\" letter-spacing=\"").V((Get(o_52, "ls") is var _t58 && Truthy(_t58) ? _t58 : ((V)(0.5)))).S("\">").End());
Invoke(lines_49, "forEach", Fn((V _arrowThis67, int _argc59, V t_65, V i_66, V _a63, V _a64, V[] _rest60) => {
V z_68 = default;
V yy_69 = default;
z_68 = ((GetK((Get(o_52, "sizes") is var _t70 && Truthy(_t70) ? _t70 : Arr()), i_66) is var _t71 && Truthy(_t71) ? _t71 : Get(o_52, "size")) is var _t72 && Truthy(_t72) ? _t72 : ((V)(50D)));
yy_69 = (!GetK((Get(o_52, "ys") is var _t73 && Truthy(_t73) ? _t73 : Arr()), i_66).IsNullish ? GetK(Get(o_52, "ys"), i_66) : ((V)((ToNum(i_66) * ToNum(lh_54)))));
s_55.S("<text y=\"").V(Call(f_18, V.Undef, Add(yy_69, ((V)((ToNum(z_68) * 0.1)))))).S("\" font-size=\"").V(z_68).S("\" fill=\"").V(Get(o_52, "shade")).S("\" stroke=\"").V(Get(o_52, "shade")).S("\" stroke-width=\"").V(Call(f_18, V.Undef, ((V)((ToNum(z_68) * 0.32))))).S("\">").V(Call(esc_19, V.Undef, t_65)).S("</text>").S("<text y=\"").V(Call(f_18, V.Undef, yy_69)).S("\" font-size=\"").V(z_68).S("\" fill=\"").V(Get(o_52, "ink")).S("\" stroke=\"").V(Get(o_52, "ink")).S("\" stroke-width=\"").V(Call(f_18, V.Undef, ((V)((ToNum(z_68) * 0.2))))).S("\">").V(Call(esc_19, V.Undef, t_65)).S("</text>").S("<text y=\"").V(Call(f_18, V.Undef, yy_69)).S("\" font-size=\"").V(z_68).S("\" fill=\"url(#").V(id_53).S(")\">").V(Call(esc_19, V.Undef, t_65)).S("</text>");
return default;
}, 2, "", true));
return NewObj(2).Put("defs", Call(lg_20, V.Undef, id_53, ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), (Get(o_52, "hi") is var _t74 && Truthy(_t74) ? _t74 : ((V)("#ffffff")))), Arr(((V)(0.42)), Get(o_52, "top")), Arr(((V)(1D)), Get(o_52, "bot"))))).Put("body", ((V)(string.Concat(s_55.Str, "</g>")))).V;
return default;
}, 5, "logo", false);
badge_30 = Fn((V _self75, int _argc76, V x_82, V y_83, V r_84, V word_85, V[] _rest77) => {
JsStrBuf d_90 = null;
V rot_86 = default;
V fill_87 = default;
V ink_88 = default;
V size_89 = default;
if (_self75.IsNullish) _self75 = GlobalV;
rot_86 = (_argc76 > 4 ? _rest77[0] : V.Undef);
fill_87 = (_argc76 > 5 ? _rest77[1] : V.Undef);
ink_88 = (_argc76 > 6 ? _rest77[2] : V.Undef);
size_89 = (_argc76 > 7 ? _rest77[3] : V.Undef);
d_90 = new JsStrBuf("");
{
double i_91 = 0;
i_91 = 0D;
while (true) {
if (!((i_91 < 24D))) break;
double a_93 = 0;
V rr_94 = default;
a_93 = ((i_91 / 24D) * TAU_17);
rr_94 = (NumTruthy((i_91 % 2D)) ? ((V)((ToNum(r_84) * 0.8))) : r_84);
d_90.S((NumTruthy(i_91) ? "L" : "M")).V(Call(f_18, V.Undef, Add(x_82, ((V)(((FdLibm.Cos(a_93) * ToNum(rr_94)) * 1.25)))))).S(" ").V(Call(f_18, V.Undef, Add(y_83, ((V)(((FdLibm.Sin(a_93) * ToNum(rr_94)) * 0.82))))));
i_91++;
}
}
return ((V)(JsStrBuf.Begin().S("<g transform=\"rotate(").V(rot_86).S(" ").V(x_82).S(" ").V(y_83).S(")\"><path d=\"").S(d_90.Str).S("Z\" fill=\"").V(ink_88).S("\" transform=\"translate(0 4)\"/><path d=\"").S(d_90.Str).S("Z\" fill=\"").V(fill_87).S("\" stroke=\"").V(ink_88).S("\" stroke-width=\"3.5\" stroke-linejoin=\"round\"/>").S("<text x=\"").V(x_82).S("\" y=\"").V(Call(f_18, V.Undef, Add(y_83, ((V)((ToNum(size_89) * 0.36)))))).S("\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"").V(size_89).S("\" text-anchor=\"middle\" fill=\"#ffffff\" stroke=\"").V(ink_88).S("\" stroke-width=\"").V(Call(f_18, V.Undef, ((V)((ToNum(size_89) * 0.2))))).S("\" stroke-linejoin=\"round\" paint-order=\"stroke fill\">").V(word_85).S("</text></g>").End()));
return default;
}, 8, "badge", false);
backdrop_33 = Fn((V _self95, int _argc96, V y_102, V tint_103, V op_104, V _a101, V[] _rest97) => {
JsStrBuf s_105 = null;
if (_self95.IsNullish) _self95 = GlobalV;
s_105 = new JsStrBuf(JsStrBuf.Begin().S("<g opacity=\"").V((op_104 is var _t106 && Truthy(_t106) ? _t106 : ((V)(1D)))).S("\">").End());
Invoke(Arr(Arr(((V)((-130D))), ((V)(0.85))), Arr(((V)((-60D))), ((V)(1D))), Arr(((V)(24D)), ((V)(1.1))), Arr(((V)(92D)), ((V)(0.8))), Arr(((V)(276D)), ((V)(0.9))), Arr(((V)(340D)), ((V)(1.2))), Arr(((V)(430D)), ((V)(1D))), Arr(((V)(500D)), ((V)(0.8))), Arr(((V)(600D)), ((V)(1.1))), Arr(((V)(690D)), ((V)(0.9)))), "forEach", Fn((V _arrowThis118, int _argc107, V _a109, V _a110, V _a111, V _a112, V[] _rest108) => {
V x_115 = default;
V k_117 = default;
{ V _t113 = ListOf(_a109);
{ V _t114 = GetIdx(_t113, 0D);
x_115 = _t114; }
{ V _t116 = GetIdx(_t113, 1D);
k_117 = _t116; }
}
s_105.S("<g transform=\"translate(").V(x_115).S(" ").V(y_102).S(") scale(").V(k_117).S(")\"><rect x=\"-4\" y=\"-30\" width=\"8\" height=\"32\" rx=\"3\" fill=\"#8a5a34\"/><circle cx=\"-14\" cy=\"-40\" r=\"18\" fill=\"").V(GetIdx(tint_103, 0D)).S("\"/><circle cx=\"13\" cy=\"-42\" r=\"20\" fill=\"").V(GetIdx(tint_103, 0D)).S("\"/><circle cx=\"0\" cy=\"-58\" r=\"22\" fill=\"").V(GetIdx(tint_103, 1D)).S("\"/></g>");
return default;
}, 1, "", true));
s_105.S("<rect x=\"-420\" y=\"").N((ToNum(y_102) - 22D)).S("\" width=\"1400\" height=\"5\" fill=\"#fff8ee\"/><rect x=\"-420\" y=\"").N((ToNum(y_102) - 10D)).S("\" width=\"1400\" height=\"5\" fill=\"#fff8ee\"/>");
{
double x_119 = 0;
x_119 = (-414D);
while (true) {
if (!((x_119 < 980D))) break;
s_105.S("<path d=\"M").N(x_119).S(" ").V(Add(y_102, ((V)(2D)))).S("V").N((ToNum(y_102) - 26D)).S("L").N((x_119 + 5D)).S(" ").N((ToNum(y_102) - 31D)).S("L").N((x_119 + 10D)).S(" ").N((ToNum(y_102) - 26D)).S("V").V(Add(y_102, ((V)(2D)))).S("Z\" fill=\"#fffaf2\" stroke=\"#e8d8c2\" stroke-width=\"1\"/>");
x_119 = (x_119 + 16D);
}
}
return ((V)(string.Concat(s_105.Str, "</g>")));
return default;
}, 3, "backdrop", false);
hoop_34 = Fn((V _self121, int _argc122, V u_128, V c_129, V _a126, V _a127, V[] _rest123) => {
V L_130 = default;
V defs_131 = default;
JsStrBuf b_132 = null;
JsStrBuf net_133 = null;
if (_self121.IsNullish) _self121 = GlobalV;
L_130 = Call(logo_26, V.Undef, u_128, Arr(((V)("HOOP SHOT"))), ((V)(180D)), ((V)(84D)), NewObj(7).Put("size", ((V)(52D))).Put("top", ((V)("#ffd25a"))).Put("bot", ((V)("#ff7a2a"))).Put("hi", ((V)("#fff6c8"))).Put("ink", ((V)("#5a1e3c"))).Put("shade", ((V)("#34102a"))).Put("rot", ((V)((-4D)))).V);
defs_131 = Add(Add(Add(Add(Add(Add(Get(L_130, "defs"), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_128).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#ff7a6a"))), Arr(((V)(0.45)), ((V)("#ffad6a"))), Arr(((V)(1D)), ((V)("#ffe2a2")))))), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_128).S("gd").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#efe6d8"))), Arr(((V)(1D)), ((V)("#c9bfae")))))), Call(rg_21, V.Undef, ((V)(JsStrBuf.Begin().V(u_128).S("bl").End())), ((V)("35%")), ((V)("30%")), ((V)("75%")), Arr(Arr(((V)(0D)), ((V)("#ffbb80"))), Arr(((V)(0.55)), ((V)("#f27a2c"))), Arr(((V)(1D)), ((V)("#a8400f")))))), Call(rg_21, V.Undef, ((V)(JsStrBuf.Begin().V(u_128).S("sun").End())), ((V)("50%")), ((V)("50%")), ((V)("50%")), Arr(Arr(((V)(0D)), ((V)("#fff6d0")), ((V)(0.95))), Arr(((V)(0.5)), ((V)("#ffe08a")), ((V)(0.45))), Arr(((V)(1D)), ((V)("#ffd070")), ((V)(0D)))))), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_128).S("bd").End())), ((V)(1D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(1D)), ((V)("#e6eefc")))))), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_128).S("pl").End())), ((V)(1D)), ((V)(0D)), Arr(Arr(((V)(0D)), ((V)("#2c2c36"))), Arr(((V)(0.45)), ((V)("#5a5a6a"))), Arr(((V)(1D)), ((V)("#2c2c36"))))));
b_132 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-420\" width=\"1400\" height=\"640\" fill=\"url(#").V(u_128).S("sk)\"/>").V(Call(rays_22, V.Undef, ((V)(262D)), ((V)(222D)), ((V)(20D)), ((V)("#fff4cf")), ((V)(0.2)), ((V)(0.1)))).S("<circle cx=\"262\" cy=\"222\" r=\"150\" fill=\"url(#").V(u_128).S("sun)\"/>").End());
b_132.V(Add(Call(cloud_24, V.Undef, ((V)(52D)), ((V)(150D)), ((V)(0.7)), ((V)(0.55))), Call(cloud_24, V.Undef, ((V)(320D)), ((V)(120D)), ((V)(0.5)), ((V)(0.45)))));
b_132.S("<path d=\"M-10 330V292L30 270L70 292V300L120 300V280L150 262L180 280V330Z\" fill=\"#d97a6a\" opacity=\"0.45\"/>").V(Call(backdrop_33, V.Undef, ((V)(338D)), Arr(((V)("#c9845e")), ((V)("#d99468"))), ((V)(0.55))));
b_132.S("<path d=\"M-420 336H980V640H-420Z\" fill=\"url(#").V(u_128).S("gd)\"/><path d=\"M-420 336H980\" stroke=\"#d8cdbc\" stroke-width=\"3\"/>");
b_132.S("<path d=\"M188 336L246 336L330 640L104 640Z\" fill=\"#ffffff\" opacity=\"0.18\"/><path d=\"M188 336L104 640M246 336L330 640\" stroke=\"#ffffff\" stroke-width=\"5\" opacity=\"0.85\"/><path d=\"M150 470Q217 436 284 470\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"5\" opacity=\"0.85\"/>");
b_132.S("<ellipse cx=\"322\" cy=\"346\" rx=\"34\" ry=\"7\" fill=\"#3a2a55\" opacity=\"0.25\"/><rect x=\"314\" y=\"150\" width=\"17\" height=\"198\" rx=\"5\" fill=\"url(#").V(u_128).S("pl)\"/><path d=\"M322 176L304 190\" stroke=\"#3a3a46\" stroke-width=\"9\" stroke-linecap=\"round\"/>");
b_132.S("<g transform=\"rotate(-3 258 160)\"><rect x=\"186\" y=\"104\" width=\"148\" height=\"104\" rx=\"9\" fill=\"#2a2a36\" transform=\"translate(4 5)\" opacity=\"0.35\"/><rect x=\"186\" y=\"104\" width=\"148\" height=\"104\" rx=\"9\" fill=\"url(#").V(u_128).S("bd)\" stroke=\"#e8483c\" stroke-width=\"6\"/>").S("<path d=\"M196 116L240 116L210 196L196 196Z\" fill=\"#ffffff\" opacity=\"0.8\"/><rect x=\"232\" y=\"146\" width=\"54\" height=\"42\" fill=\"none\" stroke=\"#e8483c\" stroke-width=\"5\"/></g>");
b_132.S("<rect x=\"250\" y=\"203\" width=\"16\" height=\"9\" rx=\"2.5\" fill=\"#b8481a\"/><path d=\"M216 214A44 12 0 0 1 304 214\" fill=\"none\" stroke=\"#b8481a\" stroke-width=\"7\" stroke-linecap=\"round\"/>");
b_132.S("<path d=\"M132 226Q188 40 248 178\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"5\" stroke-dasharray=\"1 12\" stroke-linecap=\"round\" opacity=\"0.95\"/>");
b_132.V(Add(Add(Call(spark_23, V.Undef, ((V)(178D)), ((V)(118D)), ((V)(9D))), Call(spark_23, V.Undef, ((V)(212D)), ((V)(138D)), ((V)(5D)))), Call(spark_23, V.Undef, ((V)(146D)), ((V)(160D)), ((V)(6D)))));
b_132.S("<g transform=\"translate(260 202)\"><circle r=\"26\" fill=\"url(#").V(u_128).S("bl)\"/><path d=\"M-26 0H26M0 -26V26M-18 -18Q0 0 -18 18M18 -18Q0 0 18 18\" stroke=\"#6e2c0c\" stroke-width=\"2.4\" fill=\"none\" opacity=\"0.9\"/><ellipse cx=\"-9\" cy=\"-11\" rx=\"9\" ry=\"5.5\" fill=\"#ffffff\" opacity=\"0.35\" transform=\"rotate(-30 -9 -11)\"/></g>");
net_133 = new JsStrBuf("");
{
double i_134 = 0;
i_134 = 0D;
while (true) {
if (!((i_134 <= 10D))) break;
double a_136 = 0;
double x0_137 = 0;
double y0_138 = 0;
double x1_139 = 0;
double y1_140 = 0;
a_136 = ((System.Math.PI * i_134) / 10D);
x0_137 = (260D - (FdLibm.Cos(a_136) * 44D));
y0_138 = (214D + (FdLibm.Sin(a_136) * 12D));
x1_139 = (260D - (FdLibm.Cos(a_136) * 26D));
y1_140 = (262D + (FdLibm.Sin(a_136) * 6D));
net_133.S("M").V(Call(f_18, V.Undef, ((V)(x0_137)))).S(" ").V(Call(f_18, V.Undef, ((V)(y0_138)))).S("L").V(Call(f_18, V.Undef, ((V)(x1_139)))).S(" ").V(Call(f_18, V.Undef, ((V)(y1_140))));
i_134++;
}
}
{
double k_141 = 0;
k_141 = 1D;
while (true) {
if (!((k_141 <= 3D))) break;
double rr_143 = 0;
double yy_144 = 0;
rr_143 = (44D - (k_141 * 6D));
yy_144 = (214D + (k_141 * 16D));
net_133.S("M").V(Call(f_18, V.Undef, ((V)((260D - rr_143))))).S(" ").N(yy_144).S("Q260 ").V(Call(f_18, V.Undef, ((V)((yy_144 + 13D))))).S(" ").V(Call(f_18, V.Undef, ((V)((260D + rr_143))))).S(" ").N(yy_144);
k_141++;
}
}
b_132.S("<path d=\"").S(net_133.Str).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"2.4\" stroke-linecap=\"round\" opacity=\"0.95\"/>");
b_132.S("<path d=\"M216 214A44 12 0 0 0 304 214\" fill=\"none\" stroke=\"#f27a2c\" stroke-width=\"8\" stroke-linecap=\"round\"/><path d=\"M222 217A40 9 0 0 0 298 217\" fill=\"none\" stroke=\"#ffc28a\" stroke-width=\"2\" opacity=\"0.8\"/>");
b_132.V(Call(badge_30, V.Undef, ((V)(66D)), ((V)(168D)), ((V)(32D)), ((V)("SWISH!")), ((V)((-10D))), ((V)("#46c0ff")), ((V)("#1e3a7a")), ((V)(19D))));
b_132.S("<ellipse cx=\"94\" cy=\"334\" rx=\"64\" ry=\"12\" fill=\"#3a2a55\" opacity=\"0.22\"/>").V(Call(stk_27, V.Undef, u_128, Get(c_129, "src"), ((V)(94D)), ((V)(338D)), ((V)(160D)), ((V)((-4D))), (false ? V.True : V.False), NewObj(10).Put("armL", ((V)(125D))).Put("armR", ((V)(150D))).Put("lift", ((V)(8D))).Put("footL", ((V)(1.4))).Put("footR", ((V)(1.4))).Put("sq", ((V)((-0.08)))).Put("ly", ((V)((-0.7)))).Put("lx", ((V)(0.5))).Put("open", ((V)(0.5))).Put("smile", ((V)(0.3))).V));
b_132.V(Add(Add(Call(spark_23, V.Undef, ((V)(308D)), ((V)(240D)), ((V)(8D)), ((V)("#fff6c8"))), Call(spark_23, V.Undef, ((V)(326D)), ((V)(212D)), ((V)(5D)), ((V)("#ffffff")))), Call(spark_23, V.Undef, ((V)(204D)), ((V)(252D)), ((V)(6D)), ((V)("#fff6c8")))));
return Call(wrap_31, V.Undef, u_128, defs_131, ((V)(JsStrBuf.Begin().S(b_132.Str).V(Get(L_130, "body")).End())));
return default;
}, 2, "hoop", false);
soccer_35 = Fn((V _self145, int _argc146, V u_152, V c_153, V _a150, V _a151, V[] _rest147) => {
V L_154 = default;
V defs_155 = default;
double GX0_156 = 0;
double GX1_157 = 0;
double GY0_158 = 0;
double GY1_159 = 0;
double BX_160 = 0;
double BY_161 = 0;
JsStrBuf b_162 = null;
double KX_163 = 0;
double KY_164 = 0;
double KW_165 = 0;
double KR_166 = 0;
double hx_167 = 0;
double hy_168 = 0;
V pent_169 = default;
double MX_170 = 0;
double MY_171 = 0;
if (_self145.IsNullish) _self145 = GlobalV;
L_154 = Call(logo_26, V.Undef, u_152, Arr(((V)("PENALTY KICK"))), ((V)(214D)), ((V)(54D)), NewObj(7).Put("size", ((V)(44D))).Put("top", ((V)("#ffffff"))).Put("bot", ((V)("#9fe0ff"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#123a7a"))).Put("shade", ((V)("#0a2050"))).Put("rot", ((V)((-3D)))).V);
defs_155 = ((V)(JsStrBuf.Begin().V(Add(Add(Add(Add(Get(L_154, "defs"), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_152).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#3aaaf6"))), Arr(((V)(0.6)), ((V)("#9fdcff"))), Arr(((V)(1D)), ((V)("#e6f8ff")))))), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_152).S("gr").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#8fd86a"))), Arr(((V)(1D)), ((V)("#4e9e3c")))))), Call(rg_21, V.Undef, ((V)(JsStrBuf.Begin().V(u_152).S("bl").End())), ((V)("36%")), ((V)("30%")), ((V)("72%")), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(0.65)), ((V)("#eef0f6"))), Arr(((V)(1D)), ((V)("#a9aec0")))))), Call(rg_21, V.Undef, ((V)(JsStrBuf.Begin().V(u_152).S("im").End())), ((V)("50%")), ((V)("50%")), ((V)("50%")), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(0.45)), ((V)("#fff3a0"))), Arr(((V)(1D)), ((V)("#ffd84a")), ((V)(0D))))))).S("<clipPath id=\"").V(u_152).S("bc\"><circle r=\"20\"/></clipPath>").End()));
GX0_156 = 174D;
GX1_157 = 424D;
GY0_158 = 104D;
GY1_159 = 276D;
BX_160 = 202D;
BY_161 = 134D;
b_162 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"780\" height=\"360\" fill=\"url(#").V(u_152).S("sk)\"/>").V(Call(rays_22, V.Undef, ((V)(BX_160)), ((V)(BY_161)), ((V)(26D)), ((V)("#ffffff")), ((V)(0.15)))).V(Call(cloud_24, V.Undef, ((V)(86D)), ((V)(120D)), ((V)(0.55)), ((V)(0.7)))).V(Call(cloud_24, V.Undef, ((V)(520D)), ((V)(66D)), ((V)(0.5)), ((V)(0.65)))).V(Call(cloud_24, V.Undef, ((V)(660D)), ((V)(120D)), ((V)(0.4)), ((V)(0.6)))).End());
b_162.V(Call(backdrop_33, V.Undef, ((V)(196D)), Arr(((V)("#4f9a3e")), ((V)("#62ad4c"))), ((V)(0.9))));
b_162.S("<path d=\"M-20 190H800V380H-20Z\" fill=\"url(#").V(u_152).S("gr)\"/>");
{
double i_172 = 0;
i_172 = (-6D);
while (true) {
if (!((i_172 < 12D))) break;
double x0_174 = 0;
x0_174 = (310D + (i_172 * 60D));
b_162.S("<path d=\"M").V(Call(f_18, V.Undef, ((V)((310D + ((x0_174 - 310D) * 0.4)))))).S(" 190L").V(Call(f_18, V.Undef, ((V)((310D + (((x0_174 + 30D) - 310D) * 0.4)))))).S(" 190L").V(Call(f_18, V.Undef, ((V)((310D + (((x0_174 + 30D) - 310D) * 2.4)))))).S(" 380L").V(Call(f_18, V.Undef, ((V)((310D + ((x0_174 - 310D) * 2.4)))))).S(" 380Z\" fill=\"#ffffff\" opacity=\"0.07\"/>");
i_172++;
}
}
b_162.S("<g fill=\"none\" stroke=\"#ffffff\" stroke-width=\"3.2\" opacity=\"0.8\" stroke-linejoin=\"round\"><path d=\"M60 ").N(GY1_159).S("H560\"/><path d=\"M150 ").N(GY1_159).S("L118 300H500L470 ").N(GY1_159).S("\"/><path d=\"M40 ").N(GY1_159).S("L-20 340\"/></g><ellipse cx=\"300\" cy=\"328\" rx=\"7\" ry=\"2.6\" fill=\"#ffffff\" opacity=\"0.9\"/>");
b_162.S("<path d=\"M").N(GX0_156).S(" ").N(GY1_159).S("L").N((GX0_156 + 22D)).S(" ").N((GY1_159 - 16D)).S("H").N((GX1_157 + 22D)).S("L").N(GX1_157).S(" ").N(GY1_159).S("Z\" fill=\"#2a4a20\" opacity=\"0.18\"/>");
b_162.S("<path d=\"M").N((GX0_156 + 22D)).S(" ").N((GY0_158 - 14D)).S("H").N((GX1_157 + 22D)).S("V").N((GY1_159 - 16D)).S("H").N((GX0_156 + 22D)).S("Z\" fill=\"#ffffff\" opacity=\"0.18\"/><g stroke=\"#ffffff\" stroke-width=\"1.3\" opacity=\"0.7\" fill=\"none\">");
{
double x_175 = 0;
x_175 = (GX0_156 + 22D);
while (true) {
if (!((x_175 <= (GX1_157 + 22D)))) break;
b_162.S("<path d=\"M").N(x_175).S(" ").N((GY0_158 - 14D)).S("V").N((GY1_159 - 16D)).S("\"/>");
x_175 = (x_175 + 13D);
}
}
{
double y_177 = 0;
y_177 = (GY0_158 - 14D);
while (true) {
if (!((y_177 <= (GY1_159 - 16D)))) break;
b_162.S("<path d=\"M").N((GX0_156 + 22D)).S(" ").N(y_177).S("H").N((GX1_157 + 22D)).S("\"/>");
y_177 = (y_177 + 13D);
}
}
{
double k_179 = 0;
k_179 = 0D;
while (true) {
if (!((k_179 <= 6D))) break;
double y_181 = 0;
y_181 = (GY0_158 + (((GY1_159 - GY0_158) * k_179) / 6D));
b_162.S("<path d=\"M").N(GX1_157).S(" ").V(Call(f_18, V.Undef, ((V)(y_181)))).S("L").N((GX1_157 + 22D)).S(" ").V(Call(f_18, V.Undef, ((V)((y_181 - 15D))))).S("\"/>");
k_179++;
}
}
b_162.S("<path d=\"M").N(GX0_156).S(" ").N(GY0_158).S("L").N((GX0_156 + 22D)).S(" ").N((GY0_158 - 14D)).S("M").N(GX1_157).S(" ").N(GY0_158).S("L").N((GX1_157 + 22D)).S(" ").N((GY0_158 - 14D)).S("\"/></g>");
b_162.S("<path d=\"M").N(GX0_156).S(" ").N((GY1_159 + 2D)).S("V").N(GY0_158).S("H").N(GX1_157).S("V").N((GY1_159 + 2D)).S("\" fill=\"none\" stroke=\"#3a4a6a\" stroke-width=\"11\" stroke-linejoin=\"round\" opacity=\"0.3\" transform=\"translate(3 4)\"/><path d=\"M").N(GX0_156).S(" ").N((GY1_159 + 2D)).S("V").N(GY0_158).S("H").N(GX1_157).S("V").N((GY1_159 + 2D)).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"10\" stroke-linejoin=\"round\"/><path d=\"M").N((GX0_156 + 3D)).S(" ").N((GY1_159 + 1D)).S("V").N((GY0_158 + 3D)).S("H").N((GX1_157 - 3D)).S("V").N((GY1_159 + 1D)).S("\" fill=\"none\" stroke=\"#dfe6f2\" stroke-width=\"2.4\"/>");
KX_163 = 328D;
KY_164 = 226D;
KW_165 = 150D;
KR_166 = (-12D);
hx_167 = (KX_163 - ((0.55 * KW_165) * FdLibm.Sin((((-KR_166) * System.Math.PI) / 180D))));
hy_168 = (KY_164 - ((0.55 * KW_165) * FdLibm.Cos(((KR_166 * System.Math.PI) / 180D))));
b_162.S("<ellipse cx=\"").N((KX_163 - 14D)).S("\" cy=\"").N((GY1_159 - 2D)).S("\" rx=\"46\" ry=\"8\" fill=\"#2a4a20\" opacity=\"0.22\"/>").V(Call(speed_25, V.Undef, ((V)((KX_163 + 30D))), ((V)((KY_164 - 70D))), ((V)((System.Math.PI + 0.25))), ((V)(3D)), ((V)(44D)), ((V)("#ffffff")), ((V)(0.8))));
b_162.V(Call(stk_27, V.Undef, u_152, ((V)("")), ((V)(KX_163)), ((V)(KY_164)), ((V)(KW_165)), ((V)(KR_166)), (false ? V.True : V.False), NewObj(10).Put("armL", ((V)(130D))).Put("armR", ((V)(150D))).Put("hLx", ((V)((-14D)))).Put("hLy", ((V)((-28D)))).Put("teary", ((V)(1D))).Put("open", ((V)(1D))).Put("footR", ((V)(5D))).Put("lx", ((V)((-1D)))).Put("ly", ((V)((-1D)))).Put("sq", ((V)((-0.04)))).V, V.Null, ((V)("opp"))));
Invoke(Arr(Arr(((V)((hx_167 + 56D))), ((V)((hy_168 - 30D))), ((V)(7D)), ((V)(20D))), Arr(((V)((hx_167 + 66D))), ((V)((hy_168 - 6D))), ((V)(5.5)), ((V)(34D))), Arr(((V)((hx_167 + 42D))), ((V)((hy_168 - 50D))), ((V)(4.5)), ((V)(8D)))), "forEach", Fn((V _arrowThis197, int _argc182, V _a184, V _a185, V _a186, V _a187, V[] _rest183) => {
V x_190 = default;
V y_192 = default;
V r_194 = default;
V a_196 = default;
{ V _t188 = ListOf(_a184);
{ V _t189 = GetIdx(_t188, 0D);
x_190 = _t189; }
{ V _t191 = GetIdx(_t188, 1D);
y_192 = _t191; }
{ V _t193 = GetIdx(_t188, 2D);
r_194 = _t193; }
{ V _t195 = GetIdx(_t188, 3D);
a_196 = _t195; }
}
b_162.S("<path transform=\"translate(").V(Call(f_18, V.Undef, x_190)).S(" ").V(Call(f_18, V.Undef, y_192)).S(") rotate(").V(a_196).S(") scale(").V(Call(f_18, V.Undef, ((V)((ToNum(r_194) / 6D))))).S(")\" d=\"M0 -9Q6 -1 6 3A6 6 0 0 1 -6 3Q-6 -1 0 -9Z\" fill=\"#bfe8ff\" stroke=\"#3f8fd0\" stroke-width=\"1.6\"/>");
return default;
}, 1, "", true));
b_162.S("<g stroke=\"#1d3a6a\" stroke-width=\"3\" stroke-linecap=\"round\">").V(Invoke(Invoke(Arr(((V)((-118D))), ((V)((-92D))), ((V)((-66D)))), "map", Fn((V _arrowThis205, int _argc198, V d_204, V _a201, V _a202, V _a203, V[] _rest199) => {
double t_206 = 0;
t_206 = ((ToNum(d_204) * System.Math.PI) / 180D);
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f_18, V.Undef, ((V)((hx_167 + (FdLibm.Cos(t_206) * 64D)))))).S(" ").V(Call(f_18, V.Undef, ((V)((hy_168 + (FdLibm.Sin(t_206) * 64D)))))).S("L").V(Call(f_18, V.Undef, ((V)((hx_167 + (FdLibm.Cos(t_206) * 80D)))))).S(" ").V(Call(f_18, V.Undef, ((V)((hy_168 + (FdLibm.Sin(t_206) * 80D)))))).S("\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>");
b_162.V(Call(badge_30, V.Undef, ((V)((hx_167 + 76D))), ((V)((hy_168 - 62D))), ((V)(19D)), ((V)("!!")), ((V)(10D)), ((V)("#ff6f7a")), ((V)("#7a1428")), ((V)(20D))));
b_162.S("<path d=\"M150 296Q164 196 ").N((BX_160 - 12D)).S(" ").N((BY_161 + 14D)).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"7\" stroke-linecap=\"round\" stroke-dasharray=\"2 13\" opacity=\"0.9\"/>").V(Call(speed_25, V.Undef, ((V)(BX_160)), ((V)(BY_161)), ((V)((-1.32))), ((V)(5D)), ((V)(70D)), ((V)("#ffffff")), ((V)(0.85))));
b_162.S("<g transform=\"translate(").N(BX_160).S(" ").N(BY_161).S(") rotate(24)\"><circle r=\"20\" fill=\"url(#").V(u_152).S("bl)\" stroke=\"#5a6078\" stroke-width=\"1.4\"/><g clip-path=\"url(#").V(u_152).S("bc)\" fill=\"#2a2a3a\">");
pent_169 = Fn((V _arrowThis217, int _argc207, V cx_213, V cy_214, V r_215, V a_216, V[] _rest208) => {
JsStrBuf d_218 = null;
d_218 = new JsStrBuf("");
{
double i_219 = 0;
i_219 = 0D;
while (true) {
if (!((i_219 < 5D))) break;
V t_221 = default;
t_221 = Add(a_216, ((V)(((i_219 / 5D) * TAU_17))));
d_218.S((NumTruthy(i_219) ? "L" : "M")).V(Call(f_18, V.Undef, Add(cx_213, ((V)((FdLibm.Cos(ToNum(t_221)) * ToNum(r_215))))))).S(" ").V(Call(f_18, V.Undef, Add(cy_214, ((V)((FdLibm.Sin(ToNum(t_221)) * ToNum(r_215)))))));
i_219++;
}
}
return ((V)(string.Concat("<path d=\"", d_218.Str, "Z\"/>")));
return default;
}, 4, "", true);
b_162.V(Call(pent_169, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(6.8)), ((V)(((-System.Math.PI) / 2D)))));
{
double i_222 = 0;
i_222 = 0D;
while (true) {
if (!((i_222 < 5D))) break;
double t_224 = 0;
t_224 = (((-System.Math.PI) / 2D) + (((i_222 + 0.5) / 5D) * TAU_17));
b_162.V(Call(pent_169, V.Undef, ((V)((FdLibm.Cos(t_224) * 19.5))), ((V)((FdLibm.Sin(t_224) * 19.5))), ((V)(6.8)), ((V)((t_224 + System.Math.PI)))));
i_222++;
}
}
b_162.S("</g><g stroke=\"#2a2a3a\" stroke-width=\"1.3\">");
{
double i_225 = 0;
i_225 = 0D;
while (true) {
if (!((i_225 < 5D))) break;
double t_227 = 0;
t_227 = (((-System.Math.PI) / 2D) + ((i_225 / 5D) * TAU_17));
b_162.S("<path d=\"M").V(Call(f_18, V.Undef, ((V)((FdLibm.Cos(t_227) * 6.8))))).S(" ").V(Call(f_18, V.Undef, ((V)((FdLibm.Sin(t_227) * 6.8))))).S("L").V(Call(f_18, V.Undef, ((V)((FdLibm.Cos(t_227) * 13.5))))).S(" ").V(Call(f_18, V.Undef, ((V)((FdLibm.Sin(t_227) * 13.5))))).S("\"/>");
i_225++;
}
}
b_162.S("</g><ellipse cx=\"-7\" cy=\"-9\" rx=\"7\" ry=\"4\" fill=\"#ffffff\" opacity=\"0.6\" transform=\"rotate(-30 -7 -9)\"/></g>");
b_162.V(Add(Add(Call(spark_23, V.Undef, ((V)((BX_160 - 30D))), ((V)((BY_161 - 28D))), ((V)(7D))), Call(spark_23, V.Undef, ((V)((BX_160 + 34D))), ((V)((BY_161 - 18D))), ((V)(5D)))), Call(spark_23, V.Undef, ((V)(440D)), ((V)(60D)), ((V)(6D)), ((V)("#fff6c8")))));
MX_170 = 96D;
MY_171 = 344D;
b_162.S("<ellipse cx=\"").N((MX_170 + 6D)).S("\" cy=\"").N((MY_171 - 2D)).S("\" rx=\"62\" ry=\"11\" fill=\"#2a4a20\" opacity=\"0.24\"/>");
b_162.S("<circle cx=\"152\" cy=\"300\" r=\"34\" fill=\"url(#").V(u_152).S("im)\"/><path d=\"M152 266L158 288L178 278L164 296L186 304L162 308L170 330L152 314L136 330L142 308L118 306L140 296L126 280L146 288Z\" fill=\"#fff6c8\" stroke=\"#ffb020\" stroke-width=\"2\" stroke-linejoin=\"round\" opacity=\"0.95\"/>");
b_162.S("<path d=\"M88 338Q118 346 140 324Q154 308 152 286\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"9\" stroke-linecap=\"round\" opacity=\"0.75\"/><path d=\"M96 330Q120 334 136 318\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"4\" stroke-linecap=\"round\" opacity=\"0.9\"/>");
b_162.V(Call(stk_27, V.Undef, u_152, Get(c_153, "src"), ((V)(MX_170)), ((V)(MY_171)), ((V)(176D)), ((V)((-8D))), (false ? V.True : V.False), NewObj(9).Put("footR", ((V)(10D))).Put("lean", ((V)(2D))).Put("armL", ((V)(40D))).Put("armR", ((V)(152D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.6))).Put("hap", ((V)(0.7))).Put("tilt", ((V)((-6D)))).Put("sq", ((V)((-0.04)))).V, V.Null, V.Null, ((V)(50D))));
return Call(wrapL_32, V.Undef, u_152, defs_155, ((V)(JsStrBuf.Begin().S(b_162.Str).V(Get(L_154, "body")).End())));
return default;
}, 2, "soccer", false);
hop_36 = Fn((V _self228, int _argc229, V u_235, V c_236, V _a233, V _a234, V[] _rest230) => {
V P_237 = default;
V L_238 = default;
V defs_239 = default;
JsStrBuf b_240 = null;
V q_241 = default;
V cells_242 = default;
V tint_243 = default;
JsStrBuf ch_244 = null;
V d1_245 = default;
V d2_246 = default;
V d3_247 = default;
V d4_248 = default;
V pb_249 = default;
V ck_250 = default;
V sh_251 = default;
if (_self228.IsNullish) _self228 = GlobalV;
P_237 = Fn((V _arrowThis260, int _argc252, V x_258, V z_259, V _a256, V _a257, V[] _rest253) => {
double s_261 = 0;
s_261 = (1D / (1D + (ToNum(z_259) * 0.2)));
return Arr(Call(f_18, V.Undef, ((V)((150D + ((ToNum(x_258) * 118D) * s_261))))), Call(f_18, V.Undef, ((V)((122D + (268D * s_261))))), ((V)(s_261)));
return default;
}, 2, "", true);
L_238 = Call(logo_26, V.Undef, u_235, Arr(((V)("HOPSCOTCH"))), ((V)(180D)), ((V)(76D)), NewObj(8).Put("size", ((V)(46D))).Put("top", ((V)("#ffe0f2"))).Put("bot", ((V)("#ff6fb8"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#6a1a52"))).Put("shade", ((V)("#3e0c30"))).Put("rot", ((V)((-3D)))).Put("ls", ((V)(1D))).V);
defs_239 = ((V)(JsStrBuf.Begin().V(Add(Add(Get(L_238, "defs"), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_235).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#ffb0d8"))), Arr(((V)(1D)), ((V)("#ffe6c8")))))), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_235).S("pv").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#cfc6cc"))), Arr(((V)(1D)), ((V)("#a99ea6"))))))).S("<filter id=\"").V(u_235).S("ch\" x=\"-5%\" y=\"-5%\" width=\"110%\" height=\"110%\"><feTurbulence type=\"fractalNoise\" baseFrequency=\"0.9\" numOctaves=\"2\" seed=\"3\" result=\"n\"/><feDisplacementMap in=\"SourceGraphic\" in2=\"n\" scale=\"2.6\" xChannelSelector=\"R\" yChannelSelector=\"G\" result=\"dd\"/><feComposite in=\"dd\" in2=\"n\" operator=\"in\"/></filter>").End()));
b_240 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-420\" width=\"1400\" height=\"640\" fill=\"url(#").V(u_235).S("sk)\"/>").V(Call(rays_22, V.Undef, ((V)(180D)), ((V)(118D)), ((V)(26D)), ((V)("#ffffff")), ((V)(0.18)))).End());
b_240.V(Call(backdrop_33, V.Undef, ((V)(122D)), Arr(((V)("#7cc06a")), ((V)("#93d07c"))), ((V)(0.75))));
q_241 = Fn((V _arrowThis270, int _argc262, V pts_268, V a_269, V _a266, V _a267, V[] _rest263) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Invoke(Invoke(pts_268, "map", Fn((V _arrowThis278, int _argc271, V p_277, V _a274, V _a275, V _a276, V[] _rest272) => {
return ((V)(JsStrBuf.Begin().V(GetIdx(p_277, 0D)).S(" ").V(GetIdx(p_277, 1D)).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z\" ").V(a_269).S("/>").End()));
}, 2, "", true);
b_240.S("<path d=\"M-420 118H980V640H-420Z\" fill=\"#7cc46a\"/>").V(Call(q_241, V.Undef, Arr(Call(P_237, V.Undef, ((V)((-1.55))), ((V)(40D))), Call(P_237, V.Undef, ((V)(1.55)), ((V)(40D))), Call(P_237, V.Undef, ((V)(1.55)), ((V)((-1.2)))), Call(P_237, V.Undef, ((V)((-1.55))), ((V)((-1.2))))), ((V)(JsStrBuf.Begin().S("fill=\"url(#").V(u_235).S("pv)\"").End()))));
{
double z_279 = 0;
z_279 = 0D;
while (true) {
if (!((z_279 < 30D))) break;
V a_281 = default;
V b2_282 = default;
a_281 = Call(P_237, V.Undef, ((V)((-1.55))), ((V)(z_279)));
b2_282 = Call(P_237, V.Undef, ((V)(1.55)), ((V)(z_279)));
b_240.S("<path d=\"M").V(GetIdx(a_281, 0D)).S(" ").V(GetIdx(a_281, 1D)).S("L").V(GetIdx(b2_282, 0D)).S(" ").V(GetIdx(b2_282, 1D)).S("\" stroke=\"#958a92\" stroke-width=\"").V(Call(f_18, V.Undef, ((V)((1.6 * ToNum(GetIdx(a_281, 2D))))))).S("\" opacity=\"0.7\"/>");
z_279 = (z_279 + 1.6);
}
}
b_240.V(Add(Call(q_241, V.Undef, Arr(Call(P_237, V.Undef, ((V)((-1.55))), ((V)(40D))), Call(P_237, V.Undef, ((V)((-1.45))), ((V)(40D))), Call(P_237, V.Undef, ((V)((-1.45))), ((V)((-1.2)))), Call(P_237, V.Undef, ((V)((-1.55))), ((V)((-1.2))))), ((V)("fill=\"#e6dde2\""))), Call(q_241, V.Undef, Arr(Call(P_237, V.Undef, ((V)(1.45)), ((V)(40D))), Call(P_237, V.Undef, ((V)(1.55)), ((V)(40D))), Call(P_237, V.Undef, ((V)(1.55)), ((V)((-1.2)))), Call(P_237, V.Undef, ((V)(1.45)), ((V)((-1.2))))), ((V)("fill=\"#e6dde2\"")))));
cells_242 = Arr(Arr(((V)((-0.5))), ((V)(0.5)), ((V)(0D)), ((V)(1D)), ((V)("1"))), Arr(((V)((-1D))), ((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)("2"))), Arr(((V)(0D)), ((V)(1D)), ((V)(1D)), ((V)(2D)), ((V)("3"))), Arr(((V)((-0.5))), ((V)(0.5)), ((V)(2D)), ((V)(3D)), ((V)("4"))), Arr(((V)((-1D))), ((V)(0D)), ((V)(3D)), ((V)(4D)), ((V)("5"))), Arr(((V)(0D)), ((V)(1D)), ((V)(3D)), ((V)(4D)), ((V)("6"))), Arr(((V)((-0.5))), ((V)(0.5)), ((V)(4D)), ((V)(5D)), ((V)("7"))), Arr(((V)((-1D))), ((V)(0D)), ((V)(5D)), ((V)(6D)), ((V)("8"))), Arr(((V)(0D)), ((V)(1D)), ((V)(5D)), ((V)(6D)), ((V)("9"))), Arr(((V)((-0.5))), ((V)(0.5)), ((V)(6D)), ((V)(7D)), ((V)("10"))));
tint_243 = Arr(((V)("#ff9fd0")), ((V)("#9fd8ff")), ((V)("#fff09a")), ((V)("#b6f0a0")));
ch_244 = new JsStrBuf("");
Invoke(cells_242, "forEach", Fn((V _arrowThis301, int _argc283, V _a285, V i_289, V _a287, V _a288, V[] _rest284) => {
V a_302 = default;
V b2_303 = default;
V cc_304 = default;
V d_305 = default;
V m_306 = default;
V x0_292 = default;
V x1_294 = default;
V z0_296 = default;
V z1_298 = default;
V n_300 = default;
{ V _t290 = ListOf(_a285);
{ V _t291 = GetIdx(_t290, 0D);
x0_292 = _t291; }
{ V _t293 = GetIdx(_t290, 1D);
x1_294 = _t293; }
{ V _t295 = GetIdx(_t290, 2D);
z0_296 = _t295; }
{ V _t297 = GetIdx(_t290, 3D);
z1_298 = _t297; }
{ V _t299 = GetIdx(_t290, 4D);
n_300 = _t299; }
}
a_302 = Call(P_237, V.Undef, x0_292, z0_296);
b2_303 = Call(P_237, V.Undef, x1_294, z0_296);
cc_304 = Call(P_237, V.Undef, x1_294, z1_298);
d_305 = Call(P_237, V.Undef, x0_292, z1_298);
m_306 = Call(P_237, V.Undef, ((V)((ToNum(Add(x0_292, x1_294)) / 2D))), ((V)((ToNum(Add(z0_296, z1_298)) / 2D))));
ch_244.V(Call(q_241, V.Undef, Arr(a_302, b2_303, cc_304, d_305), ((V)(JsStrBuf.Begin().S("fill=\"").V(GetIdx(tint_243, (ToNum(i_289) % 4D))).S("\" fill-opacity=\"0.32\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f_18, V.Undef, ((V)((4.2 * ToNum(GetIdx(a_302, 2D))))))).S("\" stroke-linejoin=\"round\"").End()))));
ch_244.S("<text x=\"").V(GetIdx(m_306, 0D)).S("\" y=\"").V(Call(f_18, V.Undef, Add(GetIdx(m_306, 1D), ((V)((9D * ToNum(GetIdx(m_306, 2D)))))))).S("\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"").V(Call(f_18, V.Undef, ((V)((27D * ToNum(GetIdx(m_306, 2D))))))).S("\" text-anchor=\"middle\" fill=\"").V(GetIdx(Arr(((V)("#ff5fae")), ((V)("#3aa8f0")), ((V)("#f0b400")), ((V)("#4cbf3a"))), (ToNum(i_289) % 4D))).S("\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f_18, V.Undef, ((V)((1.6 * ToNum(GetIdx(m_306, 2D))))))).S("\" paint-order=\"stroke fill\">").V(n_300).S("</text>");
return default;
}, 2, "", true));
{
JsStrBuf d_307 = null;
V hm_308 = default;
d_307 = new JsStrBuf("");
{
double i_309 = 0;
i_309 = 0D;
while (true) {
if (!((i_309 <= 16D))) break;
double t_311 = 0;
V p_312 = default;
t_311 = ((System.Math.PI * i_309) / 16D);
p_312 = Call(P_237, V.Undef, ((V)(((-FdLibm.Cos(t_311)) * 0.75))), ((V)((7D + (FdLibm.Sin(t_311) * 0.9)))));
d_307.S((NumTruthy(i_309) ? "L" : "M")).V(GetIdx(p_312, 0D)).S(" ").V(GetIdx(p_312, 1D));
i_309++;
}
}
hm_308 = Call(P_237, V.Undef, ((V)(0D)), ((V)(7.4)));
ch_244.S("<path d=\"").S(d_307.Str).S("Z\" fill=\"#d9b8ff\" fill-opacity=\"0.35\" stroke=\"#ffffff\" stroke-width=\"2.4\"/><text x=\"").V(GetIdx(hm_308, 0D)).S("\" y=\"").V(Call(f_18, V.Undef, Add(GetIdx(hm_308, 1D), ((V)(4D))))).S("\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"11\" text-anchor=\"middle\" fill=\"#9a5ae0\" stroke=\"#ffffff\" stroke-width=\"1\" paint-order=\"stroke fill\">HOME</text>");
}
d1_245 = Call(P_237, V.Undef, ((V)((-1.2))), ((V)(0.9)));
d2_246 = Call(P_237, V.Undef, ((V)(1.2)), ((V)(5.6)));
d3_247 = Call(P_237, V.Undef, ((V)((-1.25))), ((V)(4.4)));
d4_248 = Call(P_237, V.Undef, ((V)((-1.25))), ((V)(2.5)));
ch_244.S("<path transform=\"translate(").V(GetIdx(d1_245, 0D)).S(" ").V(GetIdx(d1_245, 1D)).S(") scale(").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(d1_245, 2D)) * 1.3))))).S(")\" d=\"M0 -13L3.8 -4.6L13 -4.2L5.8 1.6L8.2 10.6L0 5.4L-8.2 10.6L-5.8 1.6L-13 -4.2L-3.8 -4.6Z\" fill=\"none\" stroke=\"#fff09a\" stroke-width=\"2.6\" stroke-linejoin=\"round\"/>");
ch_244.S("<path transform=\"translate(").V(GetIdx(d2_246, 0D)).S(" ").V(GetIdx(d2_246, 1D)).S(") scale(").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(d2_246, 2D)) * 1.3))))).S(")\" d=\"M0 9C-14 0 -12 -12 -5 -11C-2 -10.5 0 -8 0 -6C0 -8 2 -10.5 5 -11C12 -12 14 0 0 9Z\" fill=\"none\" stroke=\"#ff9fd0\" stroke-width=\"2.6\" stroke-linejoin=\"round\"/>");
ch_244.S("<g transform=\"translate(").V(GetIdx(d3_247, 0D)).S(" ").V(GetIdx(d3_247, 1D)).S(") scale(").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(d3_247, 2D)) * 1.2))))).S(")\" fill=\"none\" stroke=\"#9fd8ff\" stroke-width=\"2.4\" stroke-linecap=\"round\"><circle r=\"6\"/><path d=\"M0 -10V-14M0 10V14M-10 0H-14M10 0H14M7 -7L10 -10M-7 7L-10 10M7 7L10 10M-7 -7L-10 -10\"/></g>");
ch_244.S("<g transform=\"translate(").V(GetIdx(d4_248, 0D)).S(" ").V(GetIdx(d4_248, 1D)).S(") scale(").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(d4_248, 2D)) * 1.2))))).S(")\" fill=\"none\" stroke=\"#b6f0a0\" stroke-width=\"2.4\" stroke-linecap=\"round\"><path d=\"M-10 6Q0 -12 10 6\"/><path d=\"M-6 6Q0 -4 6 6\"/></g>");
b_240.S("<g filter=\"url(#").V(u_235).S("ch)\">").S(ch_244.Str).S("</g>");
pb_249 = Call(P_237, V.Undef, ((V)(0.1)), ((V)(4.55)));
b_240.S("<ellipse cx=\"").V(GetIdx(pb_249, 0D)).S("\" cy=\"").V(Call(f_18, V.Undef, Add(GetIdx(pb_249, 1D), ((V)(2D))))).S("\" rx=\"").V(Call(f_18, V.Undef, ((V)((10D * ToNum(GetIdx(pb_249, 2D))))))).S("\" ry=\"").V(Call(f_18, V.Undef, ((V)((4D * ToNum(GetIdx(pb_249, 2D))))))).S("\" fill=\"#4a3a48\" opacity=\"0.3\"/><ellipse cx=\"").V(GetIdx(pb_249, 0D)).S("\" cy=\"").V(GetIdx(pb_249, 1D)).S("\" rx=\"").V(Call(f_18, V.Undef, ((V)((9D * ToNum(GetIdx(pb_249, 2D))))))).S("\" ry=\"").V(Call(f_18, V.Undef, ((V)((6D * ToNum(GetIdx(pb_249, 2D))))))).S("\" fill=\"#8a7f92\" stroke=\"#5a5064\" stroke-width=\"1\"/><ellipse cx=\"").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(pb_249, 0D)) - 2D))))).S("\" cy=\"").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(pb_249, 1D)) - 2D))))).S("\" rx=\"").V(Call(f_18, V.Undef, ((V)((3D * ToNum(GetIdx(pb_249, 2D))))))).S("\" ry=\"").V(Call(f_18, V.Undef, ((V)((1.6 * ToNum(GetIdx(pb_249, 2D))))))).S("\" fill=\"#ffffff\" opacity=\"0.5\"/>");
ck_250 = Call(P_237, V.Undef, ((V)((-1.25))), ((V)(0.2)));
b_240.S("<g transform=\"translate(").V(GetIdx(ck_250, 0D)).S(" ").V(GetIdx(ck_250, 1D)).S(") rotate(-24)\"><rect x=\"-14\" y=\"-4.5\" width=\"28\" height=\"9\" rx=\"4.5\" fill=\"#ff9fd0\"/><rect x=\"-14\" y=\"-4.5\" width=\"9\" height=\"9\" rx=\"4.5\" fill=\"#ffffff\" opacity=\"0.6\"/></g>");
sh_251 = Call(P_237, V.Undef, ((V)(1.22)), ((V)(1.2)));
b_240.S("<ellipse cx=\"").V(GetIdx(sh_251, 0D)).S("\" cy=\"").V(GetIdx(sh_251, 1D)).S("\" rx=\"").V(Call(f_18, V.Undef, ((V)((52D * ToNum(GetIdx(sh_251, 2D))))))).S("\" ry=\"").V(Call(f_18, V.Undef, ((V)((12D * ToNum(GetIdx(sh_251, 2D))))))).S("\" fill=\"#3a2040\" opacity=\"0.25\"/>");
b_240.S("<g fill=\"#ffffff\" opacity=\"0.7\"><circle cx=\"").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(sh_251, 0D)) - 40D))))).S("\" cy=\"").V(Call(f_18, V.Undef, Add(GetIdx(sh_251, 1D), ((V)(2D))))).S("\" r=\"6\"/><circle cx=\"").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(sh_251, 0D)) - 50D))))).S("\" cy=\"").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(sh_251, 1D)) - 6D))))).S("\" r=\"4\"/><circle cx=\"").V(Call(f_18, V.Undef, Add(GetIdx(sh_251, 0D), ((V)(44D))))).S("\" cy=\"").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(sh_251, 1D)) - 2D))))).S("\" r=\"5\"/></g>");
b_240.V(Call(stk_27, V.Undef, u_235, Get(c_236, "src"), GetIdx(sh_251, 0D), Call(f_18, V.Undef, ((V)((ToNum(GetIdx(sh_251, 1D)) - 40D)))), ((V)(128D)), ((V)((-8D))), (false ? V.True : V.False), NewObj(8).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(6D))).Put("footL", ((V)(3D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("tilt", ((V)(2D))).Put("smile", ((V)(0.5))).Put("open", ((V)(0.3))).V));
b_240.S("<path d=\"M").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(sh_251, 0D)) - 52D))))).S(" ").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(sh_251, 1D)) - 66D))))).S("q-10 14 -2 30M").V(Call(f_18, V.Undef, Add(GetIdx(sh_251, 0D), ((V)(54D))))).S(" ").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(sh_251, 1D)) - 70D))))).S("q10 14 2 30\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"3.5\" stroke-linecap=\"round\" opacity=\"0.85\"/>");
b_240.V(Add(Add(Call(spark_23, V.Undef, ((V)(60D)), ((V)(170D)), ((V)(7D))), Call(spark_23, V.Undef, ((V)(318D)), ((V)(168D)), ((V)(6D)))), Call(spark_23, V.Undef, ((V)(226D)), ((V)(150D)), ((V)(4D)))));
return Call(wrap_31, V.Undef, u_235, defs_239, ((V)(JsStrBuf.Begin().S(b_240.Str).V(Get(L_238, "body")).End())));
return default;
}, 2, "hop", false);
tramp_37 = Fn((V _self313, int _argc314, V u_320, V c_321, V _a318, V _a319, V[] _rest315) => {
V L_322 = default;
V defs_323 = default;
JsStrBuf b_324 = null;
if (_self313.IsNullish) _self313 = GlobalV;
L_322 = Call(logo_26, V.Undef, u_320, Arr(((V)("BOUNCE UP!"))), ((V)(180D)), ((V)(80D)), NewObj(7).Put("size", ((V)(52D))).Put("top", ((V)("#ffffff"))).Put("bot", ((V)("#b9c2ff"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#2a1f7a"))).Put("shade", ((V)("#160f48"))).Put("rot", ((V)((-4D)))).V);
defs_323 = Add(Add(Add(Get(L_322, "defs"), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_320).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#2e2f9a"))), Arr(((V)(0.38)), ((V)("#6f78f0"))), Arr(((V)(0.75)), ((V)("#a9cbff"))), Arr(((V)(1D)), ((V)("#dff0ff")))))), Call(rg_21, V.Undef, ((V)(JsStrBuf.Begin().V(u_320).S("gl").End())), ((V)("50%")), ((V)("50%")), ((V)("50%")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.7))), Arr(((V)(1D)), ((V)("#ffffff")), ((V)(0D)))))), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_320).S("mt").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#3a3a4e"))), Arr(((V)(1D)), ((V)("#1e1e2a"))))));
b_324 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-420\" width=\"1400\" height=\"640\" fill=\"url(#").V(u_320).S("sk)\"/>").V(Call(rays_22, V.Undef, ((V)(180D)), ((V)(214D)), ((V)(24D)), ((V)("#ffffff")), ((V)(0.1)))).End());
Invoke(Arr(Arr(((V)(30D)), ((V)(40D)), ((V)(5D))), Arr(((V)(76D)), ((V)(120D)), ((V)(3D))), Arr(((V)(320D)), ((V)(46D)), ((V)(4D))), Arr(((V)(286D)), ((V)(132D)), ((V)(3D))), Arr(((V)(340D)), ((V)(186D)), ((V)(3D))), Arr(((V)(24D)), ((V)(196D)), ((V)(3D))), Arr(((V)(130D)), ((V)(26D)), ((V)(3D))), Arr(((V)(232D)), ((V)(22D)), ((V)(4D)))), "forEach", Fn((V _arrowThis338, int _argc325, V _a327, V _a328, V _a329, V _a330, V[] _rest326) => {
V x_333 = default;
V y_335 = default;
V r_337 = default;
{ V _t331 = ListOf(_a327);
{ V _t332 = GetIdx(_t331, 0D);
x_333 = _t332; }
{ V _t334 = GetIdx(_t331, 1D);
y_335 = _t334; }
{ V _t336 = GetIdx(_t331, 2D);
r_337 = _t336; }
}
b_324.V(Call(spark_23, V.Undef, x_333, y_335, r_337, ((V)("#fff8d0")), ((V)(0.95))));
return default;
}, 1, "", true));
b_324.S("<g><rect x=\"12\" y=\"150\" width=\"20\" height=\"230\" rx=\"10\" fill=\"#ffffff\" opacity=\"0.25\"/>");
{
double i_339 = 0;
i_339 = 0D;
while (true) {
if (!((i_339 <= 10D))) break;
double y_341 = 0;
y_341 = (372D - (i_339 * 21.5));
b_324.S("<path d=\"M14 ").N(y_341).S("H").N((NumTruthy((i_339 % 5D)) ? 22D : 30D)).S("\" stroke=\"#ffffff\" stroke-width=\"").N((NumTruthy((i_339 % 5D)) ? 2D : 3D)).S("\" opacity=\"0.85\"/>");
i_339++;
}
}
b_324.S("<text x=\"36\" y=\"160\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"13\" fill=\"#ffffff\">10 m</text><text x=\"36\" y=\"268\" font-family=\"Fredoka, Nunito, sans-serif\" font-weight=\"700\" font-size=\"13\" fill=\"#ffffff\" opacity=\"0.8\">5 m</text></g>");
b_324.V(Add(Add(Add(Call(cloud_24, V.Undef, ((V)(296D)), ((V)(300D)), ((V)(0.95)), ((V)(0.95))), Call(cloud_24, V.Undef, ((V)(70D)), ((V)(330D)), ((V)(0.8)), ((V)(0.9)))), Call(cloud_24, V.Undef, ((V)(188D)), ((V)(352D)), ((V)(1.1)), ((V)(0.95)))), Call(cloud_24, V.Undef, ((V)(318D)), ((V)(214D)), ((V)(0.45)), ((V)(0.7)))));
b_324.S("<g transform=\"translate(180 384)\"><path d=\"M-92 4L-80 46M92 4L80 46M-30 16L-26 54M30 16L26 54\" stroke=\"#2a2a3a\" stroke-width=\"5\" stroke-linecap=\"round\"/><ellipse rx=\"104\" ry=\"24\" fill=\"#4f8fff\"/><ellipse rx=\"104\" ry=\"24\" fill=\"none\" stroke=\"#2f5fd0\" stroke-width=\"3\"/><ellipse rx=\"86\" ry=\"18\" fill=\"url(#").V(u_320).S("mt)\"/>").S("<path d=\"M-78 -2Q0 14 78 -2\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"2\" opacity=\"0.18\"/></g>");
b_324.S("<path d=\"M178 370Q160 300 176 250\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"5\" stroke-dasharray=\"1 12\" stroke-linecap=\"round\" opacity=\"0.9\"/>");
b_324.S("<circle cx=\"180\" cy=\"190\" r=\"104\" fill=\"url(#").V(u_320).S("gl)\"/>");
b_324.S("<g fill=\"none\" stroke=\"#ffffff\" stroke-linecap=\"round\" opacity=\"0.9\"><path d=\"M98 196A86 26 -14 0 0 268 158\" stroke-width=\"5\"/><path d=\"M106 226A80 22 -14 0 0 256 196\" stroke-width=\"3.5\" opacity=\"0.7\"/></g>");
b_324.V(Call(stk_27, V.Undef, u_320, Get(c_321, "src"), ((V)(182D)), ((V)(262D)), ((V)(156D)), ((V)(14D)), (false ? V.True : V.False), NewObj(7).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("hap", ((V)(1D))).Put("open", ((V)(0.7))).Put("sq", ((V)((-0.1)))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V));
b_324.S("<path d=\"M268 158A86 26 -14 0 0 98 196\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"5\" stroke-linecap=\"round\" stroke-dasharray=\"0 120 140 400\" opacity=\"0.9\"/>");
b_324.V(Add(Add(Call(spark_23, V.Undef, ((V)(270D)), ((V)(112D)), ((V)(9D)), ((V)("#fff6c8"))), Call(spark_23, V.Undef, ((V)(96D)), ((V)(140D)), ((V)(7D)), ((V)("#ffffff")))), Call(spark_23, V.Undef, ((V)(290D)), ((V)(250D)), ((V)(6D)), ((V)("#ffffff")))));
return Call(wrap_31, V.Undef, u_320, defs_323, ((V)(JsStrBuf.Begin().S(b_324.Str).V(Get(L_322, "body")).End())));
return default;
}, 2, "tramp", false);
slide_38 = Fn((V _self342, int _argc343, V u_349, V c_350, V _a347, V _a348, V[] _rest344) => {
V L_351 = default;
double A_352 = 0;
double B_353 = 0;
double FX_354 = 0;
double FY_355 = 0;
double LX_356 = 0;
double LY_357 = 0;
double HW_358 = 0;
double OX_359 = 0;
double OY_360 = 0;
V P_361 = default;
V pt_362 = default;
V pl_363 = default;
double S0_364 = 0;
double RS_365 = 0;
double LE_366 = 0;
double RH_367 = 0;
double CH_368 = 0;
V hr_369 = default;
double WH_370 = 0;
V bands_371 = default;
V ss_372 = default;
V defs_373 = default;
JsStrBuf b_374 = null;
double T0_375 = 0;
double tH_376 = 0;
V post_377 = default;
V fp_378 = default;
V pc_379 = default;
V kp_380 = default;
V edge_381 = default;
V rev_382 = default;
V gp_383 = default;
V q_384 = default;
V sp_385 = default;
V gn_386 = default;
V rk_387 = default;
V spl_388 = default;
V me_389 = default;
if (_self342.IsNullish) _self342 = GlobalV;
L_351 = Call(logo_26, V.Undef, u_349, Arr(((V)("SLIDE & SPLASH!"))), ((V)(250D)), ((V)(54D)), NewObj(7).Put("size", ((V)(44D))).Put("top", ((V)("#ffffff"))).Put("bot", ((V)("#7ff0e0"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#0e4a6a"))).Put("shade", ((V)("#072c44"))).Put("rot", ((V)((-3D)))).V);
A_352 = ((32D * System.Math.PI) / 180D);
B_353 = (((-24D) * System.Math.PI) / 180D);
FX_354 = FdLibm.Cos(A_352);
FY_355 = FdLibm.Sin(A_352);
LX_356 = FdLibm.Cos(B_353);
LY_357 = FdLibm.Sin(B_353);
HW_358 = 44D;
OX_359 = 196D;
OY_360 = 208D;
P_361 = Fn((V _arrowThis399, int _argc390, V s_396, V l_397, V h_398, V _a395, V[] _rest391) => {
return Arr(((V)(((OX_359 + (ToNum(s_396) * FX_354)) + ((ToNum(l_397) * HW_358) * LX_356)))), ((V)((((OY_360 + (ToNum(s_396) * FY_355)) + ((ToNum(l_397) * HW_358) * LY_357)) - ToNum((h_398 is var _t400 && Truthy(_t400) ? _t400 : ((V)(0D))))))));
}, 3, "", true);
pt_362 = Fn((V _arrowThis408, int _argc401, V q_407, V _a404, V _a405, V _a406, V[] _rest402) => {
return ((V)(JsStrBuf.Begin().V(Call(f_18, V.Undef, GetIdx(q_407, 0D))).S(" ").V(Call(f_18, V.Undef, GetIdx(q_407, 1D))).End()));
}, 1, "", true);
pl_363 = Fn((V _arrowThis416, int _argc409, V a_415, V _a412, V _a413, V _a414, V[] _rest410) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(a_415, "map", pt_362), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
S0_364 = (-150D);
RS_365 = 92D;
LE_366 = 162D;
RH_367 = 30D;
CH_368 = 30D;
hr_369 = Fn((V _arrowThis424, int _argc417, V s_423, V _a420, V _a421, V _a422, V[] _rest418) => {
return ((V)((CH_368 + (LeN(s_423, RS_365) ? 0D : (RH_367 * Pow(((ToNum(s_423) - RS_365) / (LE_366 - RS_365)), 2D))))));
}, 1, "", true);
WH_370 = 10D;
bands_371 = Arr(((V)("#ff7a8a")), ((V)("#ffa95a")), ((V)("#ffdc5a")), ((V)("#7fd870")), ((V)("#5cb8ff")), ((V)("#a98bff")));
ss_372 = Arr();
{
double s_425 = 0;
s_425 = S0_364;
while (true) {
if (!((s_425 <= (LE_366 + 0.1)))) break;
Invoke(ss_372, "push", ((V)(s_425)));
s_425 = (s_425 + ((s_425 < RS_365) ? (RS_365 - S0_364) : ((LE_366 - RS_365) / 10D)));
}
}
defs_373 = Add(Add(Add(Get(L_351, "defs"), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_349).S("gr").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#a6e07e"))), Arr(((V)(1D)), ((V)("#5fae4a")))))), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_349).S("wt").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#8fe0ff"))), Arr(((V)(1D)), ((V)("#3fa6e6")))))), Call(rg_21, V.Undef, ((V)(JsStrBuf.Begin().V(u_349).S("gd").End())), ((V)("50%")), ((V)("50%")), ((V)("50%")), Arr(Arr(((V)(0D)), ((V)("#fff6b0"))), Arr(((V)(1D)), ((V)("#ffd84a"))))));
b_374 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"780\" height=\"360\" fill=\"url(#").V(u_349).S("gr)\"/>").V(Call(rays_22, V.Undef, ((V)(400D)), ((V)(300D)), ((V)(26D)), ((V)("#ffffff")), ((V)(0.12)))).End());
Invoke(Arr(Arr(((V)(40D)), ((V)(300D))), Arr(((V)(120D)), ((V)(330D))), Arr(((V)(24D)), ((V)(236D))), Arr(((V)(300D)), ((V)(120D))), Arr(((V)(420D)), ((V)(160D))), Arr(((V)(470D)), ((V)(118D))), Arr(((V)(250D)), ((V)(336D))), Arr(((V)(380D)), ((V)(210D))), Arr(((V)(150D)), ((V)(270D)))), "forEach", Fn((V _arrowThis439, int _argc427, V _a429, V i_433, V _a431, V _a432, V[] _rest428) => {
V x_436 = default;
V y_438 = default;
{ V _t434 = ListOf(_a429);
{ V _t435 = GetIdx(_t434, 0D);
x_436 = _t435; }
{ V _t437 = GetIdx(_t434, 1D);
y_438 = _t437; }
}
b_374.S("<path d=\"M").N((ToNum(x_436) - 5D)).S(" ").V(y_438).S("l2 -8l3 6l3 -10l3 10l3 -7l2 9Z\" fill=\"#4f9a3e\" opacity=\"0.7\"/>");
if (NumTruthy((ToNum(i_433) % 2D))) {
{
double j_440 = 0;
j_440 = 0D;
while (true) {
if (!((j_440 < 5D))) break;
b_374.S("<circle cx=\"").V(Call(f_18, V.Undef, Add(Add(x_436, ((V)(12D))), ((V)((FdLibm.Cos((j_440 * 1.2566)) * 2.6)))))).S("\" cy=\"").V(Call(f_18, V.Undef, ((V)(((ToNum(y_438) - 4D) + (FdLibm.Sin((j_440 * 1.2566)) * 2.6)))))).S("\" r=\"2\" fill=\"").V(GetIdx(Arr(((V)("#ffd1e8")), ((V)("#fff3a8")), ((V)("#ffffff")), ((V)("#d9c8ff"))), (ToNum(i_433) % 4D))).S("\"/>");
j_440++;
}
}
}
return default;
}, 2, "", true));
Invoke(Arr(Arr(((V)(352D)), ((V)(176D)), ((V)(0.75))), Arr(((V)(430D)), ((V)(150D)), ((V)(0.95))), Arr(((V)(520D)), ((V)(120D)), ((V)(1.1)))), "forEach", Fn((V _arrowThis455, int _argc442, V _a444, V _a445, V _a446, V _a447, V[] _rest443) => {
V x_450 = default;
V y_452 = default;
V k_454 = default;
{ V _t448 = ListOf(_a444);
{ V _t449 = GetIdx(_t448, 0D);
x_450 = _t449; }
{ V _t451 = GetIdx(_t448, 1D);
y_452 = _t451; }
{ V _t453 = GetIdx(_t448, 2D);
k_454 = _t453; }
}
b_374.S("<ellipse cx=\"").V(x_450).S("\" cy=\"").V(Add(y_452, ((V)(2D)))).S("\" rx=\"").V(Call(f_18, V.Undef, ((V)((34D * ToNum(k_454)))))).S("\" ry=\"").V(Call(f_18, V.Undef, ((V)((12D * ToNum(k_454)))))).S("\" fill=\"#2d4a22\" opacity=\"0.2\"/><g transform=\"translate(").V(x_450).S(" ").V(y_452).S(") scale(").V(k_454).S(")\"><rect x=\"-5\" y=\"-38\" width=\"10\" height=\"40\" rx=\"3\" fill=\"#8a5a34\"/><circle cx=\"-17\" cy=\"-48\" r=\"21\" fill=\"#57a854\"/><circle cx=\"15\" cy=\"-50\" r=\"23\" fill=\"#57a854\"/><circle cx=\"0\" cy=\"-70\" r=\"25\" fill=\"#6cbb5c\"/><circle cx=\"-7\" cy=\"-76\" r=\"10\" fill=\"#8fd47a\" opacity=\"0.8\"/></g>");
return default;
}, 1, "", true));
T0_375 = (S0_364 - 64D);
tH_376 = CH_368;
post_377 = Fn((V _arrowThis466, int _argc456, V s_462, V l_463, V h0_464, V h1_465, V[] _rest457) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, s_462, l_463, h0_464))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, s_462, l_463, h1_465))).S("\" stroke=\"#a89ad0\" stroke-width=\"8.5\" stroke-linecap=\"round\"/><path d=\"M").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, s_462, l_463, h0_464))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, s_462, l_463, h1_465))).S("\" stroke=\"#ffffff\" stroke-width=\"6\" stroke-linecap=\"round\"/>").End()));
}, 4, "", true);
b_374.S("<path d=\"").V(Call(pl_363, V.Undef, Arr(Call(P_361, V.Undef, ((V)((T0_375 - 8D))), ((V)((-1.25))), ((V)(0D))), Call(P_361, V.Undef, ((V)((S0_364 + 14D))), ((V)((-1.25))), ((V)(0D))), Call(P_361, V.Undef, ((V)((S0_364 + 14D))), ((V)(1.25)), ((V)(0D))), Call(P_361, V.Undef, ((V)((T0_375 - 8D))), ((V)(1.25)), ((V)(0D)))))).S("\" fill=\"#2a3a20\" opacity=\"0.15\"/>").V(Call(post_377, V.Undef, ((V)(T0_375)), ((V)(1.15)), ((V)(0D)), ((V)((tH_376 + 44D))))).V(Call(post_377, V.Undef, ((V)(S0_364)), ((V)(1.15)), ((V)(0D)), ((V)((tH_376 + 44D))))).V(Call(post_377, V.Undef, ((V)(T0_375)), ((V)((-1.15))), ((V)(0D)), ((V)((tH_376 + 44D)))));
b_374.S("<path d=\"").V(Call(pl_363, V.Undef, Arr(Call(P_361, V.Undef, ((V)(T0_375)), ((V)((-1.15))), ((V)(tH_376))), Call(P_361, V.Undef, ((V)(S0_364)), ((V)((-1.15))), ((V)(tH_376))), Call(P_361, V.Undef, ((V)(S0_364)), ((V)(1.15)), ((V)(tH_376))), Call(P_361, V.Undef, ((V)(T0_375)), ((V)(1.15)), ((V)(tH_376)))))).S("\" fill=\"#c9b8f2\" stroke=\"#a89ad0\" stroke-width=\"1.5\"/><path d=\"").V(Call(pl_363, V.Undef, Arr(Call(P_361, V.Undef, ((V)(T0_375)), ((V)((-1.15))), ((V)((tH_376 - 8D)))), Call(P_361, V.Undef, ((V)(S0_364)), ((V)((-1.15))), ((V)((tH_376 - 8D)))), Call(P_361, V.Undef, ((V)(S0_364)), ((V)((-1.15))), ((V)(tH_376))), Call(P_361, V.Undef, ((V)(T0_375)), ((V)((-1.15))), ((V)(tH_376)))))).S("\" fill=\"#cfc6ec\"/>");
Invoke(Arr(((V)(22D)), ((V)(42D))), "forEach", Fn((V _arrowThis474, int _argc467, V h_473, V _a470, V _a471, V _a472, V[] _rest468) => {
b_374.S("<path d=\"M").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)(T0_375)), ((V)((-1.15))), Add(((V)(tH_376)), h_473)))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)(T0_375)), ((V)(1.15)), Add(((V)(tH_376)), h_473)))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)(S0_364)), ((V)(1.15)), Add(((V)(tH_376)), h_473)))).S("\" stroke=\"#a89ad0\" stroke-width=\"6\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"M").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)(T0_375)), ((V)((-1.15))), Add(((V)(tH_376)), h_473)))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)(T0_375)), ((V)(1.15)), Add(((V)(tH_376)), h_473)))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)(S0_364)), ((V)(1.15)), Add(((V)(tH_376)), h_473)))).S("\" stroke=\"#ffffff\" stroke-width=\"3.6\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>");
return default;
}, 1, "", true));
fp_378 = Call(P_361, V.Undef, ((V)(T0_375)), ((V)((-1.15))), ((V)((tH_376 + 44D))));
b_374.S("<path d=\"M").V(Call(pt_362, V.Undef, fp_378)).S("V").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(fp_378, 1D)) - 26D))))).S("\" stroke=\"#a89ad0\" stroke-width=\"2.2\"/><path d=\"M").V(Call(f_18, V.Undef, GetIdx(fp_378, 0D))).S(" ").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(fp_378, 1D)) - 26D))))).S("l18 5l-18 6Z\" fill=\"#ff7a8a\" stroke=\"#c8485a\" stroke-width=\"1.2\"/>");
pc_379 = Call(P_361, V.Undef, ((V)(206D)), ((V)(0.15)), ((V)(0D)));
kp_380 = Call(Fn((V _arrowThis481, int _argc475, V _a477, V _a478, V _a479, V _a480, V[] _rest476) => {
V cx_482 = default;
double cy_483 = 0;
double RXp_484 = 0;
double RYp_485 = 0;
double T_486 = 0;
V arcF_487 = default;
JsStrBuf k_488 = null;
cx_482 = GetIdx(pc_379, 0D);
cy_483 = (ToNum(GetIdx(pc_379, 1D)) - 4D);
RXp_484 = 86D;
RYp_485 = 25D;
T_486 = 9D;
arcF_487 = Fn((V _arrowThis498, int _argc489, V y_495, V rx_496, V ry_497, V _a494, V[] _rest490) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(f_18, V.Undef, ((V)((ToNum(cx_482) - ToNum(rx_496)))))).S(" ").V(Call(f_18, V.Undef, y_495)).S("A").V(rx_496).S(" ").V(ry_497).S(" 0 0 0 ").V(Call(f_18, V.Undef, Add(cx_482, rx_496))).S(" ").V(Call(f_18, V.Undef, y_495)).End()));
}, 3, "", true);
k_488 = new JsStrBuf(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f_18, V.Undef, Add(cx_482, ((V)(4D))))).S("\" cy=\"").V(Call(f_18, V.Undef, ((V)(((cy_483 + (3D * T_486)) + 8D))))).S("\" rx=\"").N((RXp_484 + 12D)).S("\" ry=\"").V(Call(f_18, V.Undef, ((V)((RYp_485 * 0.7))))).S("\" fill=\"#2a4a20\" opacity=\"0.2\"/><ellipse cx=\"").V(Call(f_18, V.Undef, cx_482)).S("\" cy=\"").V(Call(f_18, V.Undef, ((V)(cy_483)))).S("\" rx=\"").N(RXp_484).S("\" ry=\"").N(RYp_485).S("\" fill=\"#3f9af0\"/><ellipse cx=\"").V(Call(f_18, V.Undef, cx_482)).S("\" cy=\"").V(Call(f_18, V.Undef, ((V)((cy_483 + 1D))))).S("\" rx=\"").N((RXp_484 - 12D)).S("\" ry=\"").N((RYp_485 - 5D)).S("\" fill=\"#1b5fae\"/><ellipse cx=\"").V(Call(f_18, V.Undef, cx_482)).S("\" cy=\"").V(Call(f_18, V.Undef, ((V)((cy_483 + 5D))))).S("\" rx=\"").N((RXp_484 - 15D)).S("\" ry=\"").N((RYp_485 - 9D)).S("\" fill=\"url(#").V(u_349).S("wt)\"/>").End());
k_488.S("<path d=\"").V(Call(arcF_487, V.Undef, ((V)(cy_483)), ((V)(RXp_484)), ((V)(RYp_485)))).S("L").V(Call(f_18, V.Undef, ((V)((ToNum(Add(cx_482, ((V)(RXp_484)))) - 12D))))).S(" ").V(Call(f_18, V.Undef, ((V)((cy_483 + 1D))))).S("A").N((RXp_484 - 12D)).S(" ").N((RYp_485 - 5D)).S(" 0 0 1 ").V(Call(f_18, V.Undef, ((V)(((ToNum(cx_482) - RXp_484) + 12D))))).S(" ").V(Call(f_18, V.Undef, ((V)((cy_483 + 1D))))).S("Z\" fill=\"#3f9af0\"/>");
Invoke(Arr(((V)("#2a86e6")), ((V)("#f6f9fc")), ((V)("#2a86e6"))), "forEach", Fn((V _arrowThis507, int _argc499, V c_505, V j_506, V _a503, V _a504, V[] _rest500) => {
double yt_508 = 0;
double yb_509 = 0;
yt_508 = ((cy_483 + 2D) + (ToNum(j_506) * T_486));
yb_509 = (yt_508 + T_486);
k_488.S("<path d=\"").V(Call(arcF_487, V.Undef, ((V)(yt_508)), ((V)(RXp_484)), ((V)(RYp_485)))).S("L").V(Call(f_18, V.Undef, Add(cx_482, ((V)(RXp_484))))).S(" ").V(Call(f_18, V.Undef, ((V)(yb_509)))).S("A").N(RXp_484).S(" ").N(RYp_485).S(" 0 0 1 ").V(Call(f_18, V.Undef, ((V)((ToNum(cx_482) - RXp_484))))).S(" ").V(Call(f_18, V.Undef, ((V)(yb_509)))).S("Z\" fill=\"").V(c_505).S("\" stroke=\"").S((SEqN(j_506, 1D) ? "#c9d6e6" : "#1a5fb0")).S("\" stroke-width=\"1\"/><path d=\"").V(Call(arcF_487, V.Undef, ((V)((yt_508 + 3D))), ((V)((RXp_484 - 8D))), ((V)(RYp_485)))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.8\" opacity=\"").N((SEqN(j_506, 1D) ? 0.9 : 0.45)).S("\"/>");
return default;
}, 2, "", true));
Invoke(Arr(((V)((-0.6))), ((V)((-0.15))), ((V)(0.35)), ((V)(0.75))), "forEach", Fn((V _arrowThis518, int _argc510, V v_516, V i_517, V _a514, V _a515, V[] _rest511) => {
k_488.S("<g transform=\"translate(").V(Call(f_18, V.Undef, Add(cx_482, ((V)(((ToNum(v_516) * RXp_484) * 0.92)))))).S(" ").V(Call(f_18, V.Undef, ((V)((((cy_483 + 2D) + (T_486 * 1.5)) + (RYp_485 * System.Math.Sqrt((1D - ((ToNum(v_516) * ToNum(v_516)) * 0.85))))))))).S(") scale(0.9)\">").S((NumTruthy((ToNum(i_517) % 2D)) ? "<path d=\"M0 -3.6L1 -1.2L3.5 -1.1L1.5 0.6L2.2 3.1L0 1.7L-2.2 3.1L-1.5 0.6L-3.5 -1.1L-1 -1.2Z\" fill=\"#ffd23a\"/>" : "<path d=\"M-4.2 0Q-1 -3 3 0Q-1 3 -4.2 0Z\" fill=\"#ff8a3a\"/><path d=\"M2.6 0L5.6 -2.2V2.2Z\" fill=\"#ff8a3a\"/>")).S("</g>");
return default;
}, 2, "", true));
return ((V)(JsStrBuf.Begin().S(k_488.Str).S("<g transform=\"translate(").V(Call(f_18, V.Undef, ((V)((ToNum(cx_482) - 46D))))).S(" ").V(Call(f_18, V.Undef, ((V)((cy_483 + 4D))))).S(") scale(0.75)\"><path d=\"M-12 -2Q-12 -12 0 -12Q8 -12 10 -6Q12 -2 6 0H-8Q-12 0 -12 -2Z\" fill=\"#ffd84a\" stroke=\"#d09a20\" stroke-width=\"1.2\"/><circle cx=\"4\" cy=\"-17\" r=\"7\" fill=\"#ffd84a\" stroke=\"#d09a20\" stroke-width=\"1.2\"/><path d=\"M10 -17l6 1l-6 3Z\" fill=\"#ff8a3a\"/></g>").End()));
return default;
}, 0, "", true), V.Undef);
b_374.V(kp_380);
{
double s_519 = 0;
s_519 = (S0_364 + 25D);
while (true) {
if (!((s_519 < LE_366))) break;
b_374.V(Call(post_377, V.Undef, ((V)(s_519)), ((V)(1.05)), ((V)(0D)), ((V)((ToNum(Call(hr_369, V.Undef, ((V)(s_519)))) - 4D)))));
s_519 = (s_519 + 45D);
}
}
{
double j_521 = 0;
j_521 = 0D;
while (true) {
if (!((j_521 < (ToNum(Get(ss_372, "length")) - 1D)))) break;
V a_523 = default;
V z_524 = default;
a_523 = GetIdx(ss_372, j_521);
z_524 = GetIdx(ss_372, (j_521 + 1D));
Invoke(bands_371, "forEach", Fn((V _arrowThis533, int _argc525, V col_531, V i_532, V _a529, V _a530, V[] _rest526) => {
double l0_534 = 0;
double l1_535 = 0;
l0_534 = ((-1D) + (ToNum(i_532) / 3D));
l1_535 = ((-1D) + (ToNum(Add(i_532, ((V)(1D)))) / 3D));
b_374.S("<path d=\"").V(Call(pl_363, V.Undef, Arr(Call(P_361, V.Undef, a_523, ((V)(l0_534)), Call(hr_369, V.Undef, a_523)), Call(P_361, V.Undef, z_524, ((V)(l0_534)), Call(hr_369, V.Undef, z_524)), Call(P_361, V.Undef, z_524, ((V)(l1_535)), Call(hr_369, V.Undef, z_524)), Call(P_361, V.Undef, a_523, ((V)(l1_535)), Call(hr_369, V.Undef, a_523))))).S("\" fill=\"").V(col_531).S("\" stroke=\"").V(col_531).S("\" stroke-width=\"0.8\"/>");
return default;
}, 2, "", true));
j_521++;
}
}
{
double s_536 = 0;
s_536 = (S0_364 + 30D);
while (true) {
if (!((s_536 < RS_365))) break;
b_374.S("<path d=\"M").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)(s_536)), ((V)((-1D))), ((V)(CH_368))))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)(s_536)), ((V)(1D)), ((V)(CH_368))))).S("\" stroke=\"#ffffff\" stroke-width=\"2\" opacity=\"0.5\"/>");
s_536 = (s_536 + 50D);
}
}
Invoke(Arr(Arr(((V)((-60D))), ((V)(0.5))), Arr(((V)(20D)), ((V)((-0.5))))), "forEach", Fn((V _arrowThis549, int _argc538, V _a540, V _a541, V _a542, V _a543, V[] _rest539) => {
V s_546 = default;
V l_548 = default;
{ V _t544 = ListOf(_a540);
{ V _t545 = GetIdx(_t544, 0D);
s_546 = _t545; }
{ V _t547 = GetIdx(_t544, 1D);
l_548 = _t547; }
}
b_374.S("<path d=\"M").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, s_546, l_548, ((V)(CH_368))))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, Add(s_546, ((V)(60D))), l_548, ((V)(CH_368))))).S("\" stroke=\"#ffffff\" stroke-width=\"3\" stroke-linecap=\"round\" opacity=\"0.55\"/>");
return default;
}, 1, "", true));
edge_381 = Fn((V _arrowThis559, int _argc550, V l_556, V h0_557, V h1_558, V _a555, V[] _rest551) => {
return Invoke(ss_372, "map", Fn((V _arrowThis567, int _argc560, V s_566, V _a563, V _a564, V _a565, V[] _rest561) => {
return Call(P_361, V.Undef, s_566, l_556, Add(((V)((ToNum(Call(hr_369, V.Undef, s_566)) * ToNum(h0_557)))), h1_558));
}, 1, "", true));
}, 3, "", true);
rev_382 = Fn((V _arrowThis575, int _argc568, V a_574, V _a571, V _a572, V _a573, V[] _rest569) => {
return Invoke(Invoke(a_574, "slice"), "reverse");
}, 1, "", true);
b_374.S("<path d=\"").V(Call(pl_363, V.Undef, Invoke(Call(edge_381, V.Undef, ((V)(1D)), ((V)(1D)), ((V)(0D))), "concat", Call(rev_382, V.Undef, Call(edge_381, V.Undef, ((V)(1D)), ((V)(1D)), ((V)(WH_370))))))).S("\" fill=\"#e6e0f6\"/><path d=\"").V(Call(pl_363, V.Undef, Invoke(Call(edge_381, V.Undef, ((V)(1D)), ((V)(1D)), ((V)(WH_370))), "concat", Call(rev_382, V.Undef, Call(edge_381, V.Undef, ((V)(1.1)), ((V)(1D)), ((V)(WH_370))))))).S("\" fill=\"#ffffff\" stroke=\"#cfc6ec\" stroke-width=\"1.2\"/>");
gp_383 = Call(P_361, V.Undef, ((V)(52D)), ((V)(0.02)), ((V)(CH_368)));
q_384 = Fn((V _arrowThis584, int _argc576, V a_582, V w_583, V _a580, V _a581, V[] _rest577) => {
return Arr(((V)(((ToNum(a_582) * FX_354) + (ToNum(w_583) * LX_356)))), ((V)(((ToNum(a_582) * FY_355) + (ToNum(w_583) * LY_357)))));
}, 2, "", true);
b_374.S("<g transform=\"translate(").V(Call(pt_362, V.Undef, gp_383)).S(")\"><path d=\"").V(Call(pl_363, V.Undef, Arr(Call(q_384, V.Undef, ((V)((-26D))), ((V)((-19D)))), Call(q_384, V.Undef, ((V)(26D)), ((V)((-19D)))), Call(q_384, V.Undef, ((V)(26D)), ((V)(19D))), Call(q_384, V.Undef, ((V)((-26D))), ((V)(19D)))))).S("\" fill=\"url(#").V(u_349).S("gd)\" stroke=\"#d79a22\" stroke-width=\"2.4\" stroke-linejoin=\"round\"/>");
Invoke(Arr(((V)((-13D))), ((V)(2D)), ((V)(17D))), "forEach", Fn((V _arrowThis592, int _argc585, V d_591, V _a588, V _a589, V _a590, V[] _rest586) => {
b_374.S("<path d=\"").V(Call(pl_363, V.Undef, Arr(Call(q_384, V.Undef, ((V)((ToNum(d_591) - 7D))), ((V)((-11D)))), Call(q_384, V.Undef, Add(d_591, ((V)(4D))), ((V)(0D))), Call(q_384, V.Undef, ((V)((ToNum(d_591) - 7D))), ((V)(11D))), Call(q_384, V.Undef, ((V)((ToNum(d_591) - 2D))), ((V)(11D))), Call(q_384, V.Undef, Add(d_591, ((V)(9D))), ((V)(0D))), Call(q_384, V.Undef, ((V)((ToNum(d_591) - 2D))), ((V)((-11D))))))).S("\" fill=\"#ff8a3d\" stroke=\"#ffffff\" stroke-width=\"1.2\" stroke-linejoin=\"round\"/>");
return default;
}, 1, "", true));
b_374.S("</g>");
sp_385 = Call(P_361, V.Undef, ((V)((-40D))), ((V)((-0.5))), ((V)(CH_368)));
b_374.S("<ellipse cx=\"").V(Call(f_18, V.Undef, GetIdx(sp_385, 0D))).S("\" cy=\"").V(Call(f_18, V.Undef, GetIdx(sp_385, 1D))).S("\" rx=\"30\" ry=\"12\" transform=\"rotate(8 ").V(Call(pt_362, V.Undef, sp_385)).S(")\" fill=\"#9fe2ff\" stroke=\"#ffffff\" stroke-width=\"2.2\"/><path d=\"M").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(sp_385, 0D)) - 16D))))).S(" ").V(Call(f_18, V.Undef, ((V)((ToNum(GetIdx(sp_385, 1D)) - 2D))))).S("l20 2\" stroke=\"#ffffff\" stroke-width=\"2.6\" stroke-linecap=\"round\" opacity=\"0.85\"/>");
gn_386 = Call(P_361, V.Undef, ((V)((-58D))), ((V)(0.6)), ((V)(CH_368)));
b_374.S("<g transform=\"translate(").V(Call(pt_362, V.Undef, gn_386)).S(") rotate(-8) scale(0.85)\"><ellipse cy=\"2\" rx=\"15\" ry=\"5\" fill=\"#2d4a22\" opacity=\"0.22\"/><ellipse cx=\"-6\" cy=\"-2\" rx=\"6.5\" ry=\"4\" fill=\"#6b4426\"/><ellipse cx=\"6\" cy=\"-2\" rx=\"6.5\" ry=\"4\" fill=\"#6b4426\"/><path d=\"M-12 -4C-13 -16 -9 -22 0 -22C9 -22 13 -16 12 -4Z\" fill=\"#4f8ee8\" stroke=\"#2c5aa8\" stroke-width=\"1.6\"/><path d=\"M-9 -26C-13 -16 -6 -7 0 -6C6 -7 13 -16 9 -26Z\" fill=\"#ffffff\" stroke=\"#d8d2c6\" stroke-width=\"1.4\"/><ellipse cy=\"-28\" rx=\"8\" ry=\"6.2\" fill=\"#ffd2b0\"/><circle cy=\"-25.5\" r=\"2.8\" fill=\"#ff9a8a\"/><path d=\"M-4.5 -29h2.4M2.1 -29h2.4\" stroke=\"#4a3a2e\" stroke-width=\"1.5\" stroke-linecap=\"round\"/><path d=\"M-10.5 -31C-9 -39 -4 -49 2 -51C3 -44 8 -37 10.5 -31Z\" fill=\"#ff5e6c\" stroke=\"#b8304a\" stroke-width=\"1.6\" stroke-linejoin=\"round\"/></g>");
rk_387 = Call(P_361, V.Undef, ((V)(70D)), ((V)((-0.55))), ((V)(CH_368)));
b_374.S("<g transform=\"translate(").V(Call(pt_362, V.Undef, rk_387)).S(") scale(0.7)\"><ellipse cy=\"3\" rx=\"26\" ry=\"8\" fill=\"#2d4a22\" opacity=\"0.22\"/><path d=\"M-24 2C-26 -10 -16 -24 -2 -25C12 -26 24 -16 25 -4C26 2 20 6 0 6C-16 6 -23 5 -24 2Z\" fill=\"#a3a9b2\" stroke=\"#5c6470\" stroke-width=\"2.2\"/><path d=\"M-15 -14C-9 -21 3 -22 9 -18\" stroke=\"#d2d6dc\" stroke-width=\"4.5\" fill=\"none\" stroke-linecap=\"round\"/></g>");
{
double s_593 = 0;
s_593 = (S0_364 + 25D);
while (true) {
if (!((s_593 < LE_366))) break;
b_374.V(Call(post_377, V.Undef, ((V)(s_593)), ((V)((-1.05))), ((V)(0D)), ((V)((ToNum(Call(hr_369, V.Undef, ((V)(s_593)))) - 4D)))));
s_593 = (s_593 + 45D);
}
}
b_374.S("<path d=\"").V(Call(pl_363, V.Undef, Invoke(Call(edge_381, V.Undef, ((V)((-1.1))), ((V)(1D)), ((V)((-6D)))), "concat", Call(rev_382, V.Undef, Call(edge_381, V.Undef, ((V)((-1.1))), ((V)(1D)), ((V)(WH_370))))))).S("\" fill=\"#cfc6ec\"/><path d=\"").V(Call(pl_363, V.Undef, Invoke(Call(edge_381, V.Undef, ((V)((-1.1))), ((V)(1D)), ((V)(WH_370))), "concat", Call(rev_382, V.Undef, Call(edge_381, V.Undef, ((V)((-1D))), ((V)(1D)), ((V)(WH_370))))))).S("\" fill=\"#ffffff\" stroke=\"#cfc6ec\" stroke-width=\"1.2\"/>");
b_374.V(Add(Call(post_377, V.Undef, ((V)(T0_375)), ((V)((-1.15))), ((V)(0D)), ((V)((tH_376 + 44D)))), Call(post_377, V.Undef, ((V)(S0_364)), ((V)((-1.15))), ((V)(0D)), ((V)((tH_376 + 44D))))));
Invoke(Arr(((V)((T0_375 + 14D))), ((V)((T0_375 + 50D)))), "forEach", Fn((V _arrowThis602, int _argc595, V s_601, V _a598, V _a599, V _a600, V[] _rest596) => {
b_374.S("<path d=\"M").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, s_601, ((V)((-1.8))), ((V)(0D))))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, s_601, ((V)((-1.15))), ((V)((tH_376 + 16D)))))).S("\" stroke=\"#a89ad0\" stroke-width=\"6.5\" stroke-linecap=\"round\"/><path d=\"M").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, s_601, ((V)((-1.8))), ((V)(0D))))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, s_601, ((V)((-1.15))), ((V)((tH_376 + 16D)))))).S("\" stroke=\"#ffffff\" stroke-width=\"4\" stroke-linecap=\"round\"/>");
return default;
}, 1, "", true));
{
double k_603 = 0;
k_603 = 1D;
while (true) {
if (!((k_603 <= 4D))) break;
double h_605 = 0;
double l_606 = 0;
h_605 = ((k_603 * tH_376) / 5D);
l_606 = ((-1.8) + ((0.65 * h_605) / (tH_376 + 16D)));
b_374.S("<path d=\"M").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)((T0_375 + 14D))), ((V)(l_606)), ((V)(h_605))))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)((T0_375 + 50D))), ((V)(l_606)), ((V)(h_605))))).S("\" stroke=\"#ffffff\" stroke-width=\"3.4\" stroke-linecap=\"round\"/>");
k_603++;
}
}
b_374.S("<path d=\"").V(Call(pl_363, V.Undef, Arr(Call(P_361, V.Undef, ((V)(LE_366)), ((V)((-1.1))), ((V)((ToNum(Call(hr_369, V.Undef, ((V)(LE_366)))) - 6D)))), Call(P_361, V.Undef, ((V)(LE_366)), ((V)(1.1)), ((V)((ToNum(Call(hr_369, V.Undef, ((V)(LE_366)))) - 6D)))), Call(P_361, V.Undef, ((V)(LE_366)), ((V)(1.1)), Add(Call(hr_369, V.Undef, ((V)(LE_366))), ((V)(WH_370)))), Call(P_361, V.Undef, ((V)(LE_366)), ((V)((-1.1))), Add(Call(hr_369, V.Undef, ((V)(LE_366))), ((V)(WH_370))))))).S("\" fill=\"#cfc6ec\" stroke=\"#b6aadc\" stroke-width=\"1.5\"/><path d=\"M").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)(LE_366)), ((V)((-1D))), Add(Call(hr_369, V.Undef, ((V)(LE_366))), ((V)(1D)))))).S("L").V(Call(pt_362, V.Undef, Call(P_361, V.Undef, ((V)(LE_366)), ((V)(1D)), Add(Call(hr_369, V.Undef, ((V)(LE_366))), ((V)(1D)))))).S("\" stroke=\"#ffffff\" stroke-width=\"4\" stroke-linecap=\"round\"/>");
spl_388 = Arr(GetIdx(pc_379, 0D), Add(GetIdx(pc_379, 1D), ((V)(2D))));
b_374.S("<g transform=\"translate(").V(Call(pt_362, V.Undef, spl_388)).S(")\"><ellipse rx=\"50\" ry=\"15\" fill=\"#ffffff\" opacity=\"0.75\"/><ellipse rx=\"70\" ry=\"22\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"3\" opacity=\"0.7\"/><path d=\"M-16 0C-20 -70 -8 -150 2 -164C12 -150 22 -70 16 0Z\" fill=\"#ffffff\" opacity=\"0.96\"/>").V(Invoke(Invoke(Arr(Arr(((V)((-40D))), ((V)((-86D)))), Arr(((V)((-26D))), ((V)((-118D)))), Arr(((V)(28D)), ((V)((-108D)))), Arr(((V)(42D)), ((V)((-76D)))), Arr(((V)((-52D))), ((V)((-54D)))), Arr(((V)(54D)), ((V)((-48D))))), "map", Fn((V _arrowThis618, int _argc607, V _a609, V _a610, V _a611, V _a612, V[] _rest608) => {
V x_615 = default;
V h_617 = default;
{ V _t613 = ListOf(_a609);
{ V _t614 = GetIdx(_t613, 0D);
x_615 = _t614; }
{ V _t616 = GetIdx(_t613, 1D);
h_617 = _t616; }
}
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f_18, V.Undef, ((V)(((ToNum(x_615) * 0.4) - 5D))))).S(" 0C").V(Call(f_18, V.Undef, ((V)(((ToNum(x_615) * 0.4) - 6D))))).S(" ").V(Call(f_18, V.Undef, ((V)((ToNum(h_617) * 0.55))))).S(" ").V(Call(f_18, V.Undef, ((V)((ToNum(x_615) - 3D))))).S(" ").V(Call(f_18, V.Undef, ((V)((ToNum(h_617) * 0.95))))).S(" ").V(Call(f_18, V.Undef, x_615)).S(" ").V(Call(f_18, V.Undef, h_617)).S("C").V(Call(f_18, V.Undef, Add(x_615, ((V)(3D))))).S(" ").V(Call(f_18, V.Undef, ((V)((ToNum(h_617) * 0.95))))).S(" ").V(Call(f_18, V.Undef, ((V)(((ToNum(x_615) * 0.4) + 6D))))).S(" ").V(Call(f_18, V.Undef, ((V)((ToNum(h_617) * 0.55))))).S(" ").V(Call(f_18, V.Undef, ((V)(((ToNum(x_615) * 0.4) + 5D))))).S(" 0Z\" fill=\"#e6f8ff\" stroke=\"#a8e0ff\" stroke-width=\"1.2\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M-42 -2Q-52 -28 -62 -32Q-48 -24 -34 -4ZM42 -2Q54 -26 64 -30Q50 -22 34 -4Z\" fill=\"#e6f8ff\" stroke=\"#a8e0ff\" stroke-width=\"1.2\"/></g>");
Invoke(Arr(Arr(((V)((ToNum(GetIdx(spl_388, 0D)) - 48D))), ((V)((ToNum(GetIdx(spl_388, 1D)) - 136D))), ((V)(5D))), Arr(Add(GetIdx(spl_388, 0D), ((V)(38D))), ((V)((ToNum(GetIdx(spl_388, 1D)) - 160D))), ((V)(6D))), Arr(Add(GetIdx(spl_388, 0D), ((V)(58D))), ((V)((ToNum(GetIdx(spl_388, 1D)) - 100D))), ((V)(4.5))), Arr(((V)((ToNum(GetIdx(spl_388, 0D)) - 64D))), ((V)((ToNum(GetIdx(spl_388, 1D)) - 90D))), ((V)(4D))), Arr(Add(GetIdx(spl_388, 0D), ((V)(10D))), ((V)((ToNum(GetIdx(spl_388, 1D)) - 196D))), ((V)(4D))), Arr(((V)((ToNum(GetIdx(spl_388, 0D)) - 28D))), ((V)((ToNum(GetIdx(spl_388, 1D)) - 182D))), ((V)(3.5)))), "forEach", Fn((V _arrowThis632, int _argc619, V _a621, V _a622, V _a623, V _a624, V[] _rest620) => {
V x_627 = default;
V y_629 = default;
V r_631 = default;
{ V _t625 = ListOf(_a621);
{ V _t626 = GetIdx(_t625, 0D);
x_627 = _t626; }
{ V _t628 = GetIdx(_t625, 1D);
y_629 = _t628; }
{ V _t630 = GetIdx(_t625, 2D);
r_631 = _t630; }
}
b_374.S("<path transform=\"translate(").V(Call(f_18, V.Undef, x_627)).S(" ").V(Call(f_18, V.Undef, y_629)).S(") scale(").N((ToNum(r_631) / 6D)).S(")\" d=\"M0 -9Q6 -1 6 3A6 6 0 0 1 -6 3Q-6 -1 0 -9Z\" fill=\"#cdf4ff\" stroke=\"#4fb8e8\" stroke-width=\"1.4\"/>");
return default;
}, 1, "", true));
me_389 = Call(P_361, V.Undef, ((V)((-6D))), ((V)((-0.02))), ((V)(CH_368)));
b_374.S("<ellipse cx=\"").V(Call(f_18, V.Undef, Add(GetIdx(me_389, 0D), ((V)(2D))))).S("\" cy=\"").V(Call(f_18, V.Undef, Add(GetIdx(me_389, 1D), ((V)(2D))))).S("\" rx=\"40\" ry=\"13\" fill=\"#2a3a20\" opacity=\"0.2\"/>").V(Call(speed_25, V.Undef, ((V)((ToNum(GetIdx(me_389, 0D)) - 22D))), ((V)((ToNum(GetIdx(me_389, 1D)) - 56D))), ((V)(A_352)), ((V)(4D)), ((V)(56D)), ((V)("#ffffff")), ((V)(0.9))));
Invoke(Arr(Arr(((V)((-52D))), ((V)((-8D)))), Arr(((V)((-64D))), ((V)((-1D)))), Arr(((V)((-45D))), ((V)(4D))), Arr(((V)((-74D))), ((V)((-12D))))), "forEach", Fn((V _arrowThis645, int _argc633, V _a635, V i_639, V _a637, V _a638, V[] _rest634) => {
V dx_642 = default;
V dy_644 = default;
{ V _t640 = ListOf(_a635);
{ V _t641 = GetIdx(_t640, 0D);
dx_642 = _t641; }
{ V _t643 = GetIdx(_t640, 1D);
dy_644 = _t643; }
}
b_374.S("<circle cx=\"").V(Call(f_18, V.Undef, Add(GetIdx(me_389, 0D), dx_642))).S("\" cy=\"").V(Call(f_18, V.Undef, Add(GetIdx(me_389, 1D), dy_644))).S("\" r=\"").N((3.6 - (ToNum(i_639) * 0.5))).S("\" fill=\"#dff4ff\" stroke=\"#8fd6ff\" stroke-width=\"1\"/>");
return default;
}, 2, "", true));
b_374.V(Call(stk_27, V.Undef, u_349, Get(c_350, "src"), GetIdx(me_389, 0D), Add(GetIdx(me_389, 1D), ((V)(5D))), ((V)(118D)), ((V)(0D)), (false ? V.True : V.False), NewObj(7).Put("sit", ((V)(1D))).Put("armL", ((V)(155D))).Put("armR", ((V)(150D))).Put("hap", ((V)(1D))).Put("open", ((V)(0.85))).Put("smile", ((V)(1D))).Put("lean", ((V)((-0.55)))).V, V.Null, V.Null, ((V)(58D))));
b_374.V(Call(badge_30, V.Undef, ((V)(76D)), ((V)(300D)), ((V)(23D)), ((V)("WHEE!")), ((V)((-10D))), ((V)("#ffd84a")), ((V)("#7a3a10")), ((V)(17D))));
b_374.V(Add(Add(Call(spark_23, V.Undef, ((V)(110D)), ((V)(120D)), ((V)(6D))), Call(spark_23, V.Undef, ((V)(390D)), ((V)(92D)), ((V)(6D)), ((V)("#fff6c8")))), Call(spark_23, V.Undef, ((V)(300D)), ((V)(300D)), ((V)(5D)))));
return Call(wrapL_32, V.Undef, u_349, defs_373, ((V)(JsStrBuf.Begin().S(b_374.Str).V(Get(L_351, "body")).End())));
return default;
}, 2, "slide", false);
corn_39 = Fn((V _self646, int _argc647, V u_653, V c_654, V _a651, V _a652, V[] _rest648) => {
V L_655 = default;
V defs_656 = default;
JsStrBuf b_657 = null;
V top_658 = default;
V bag_659 = default;
if (_self646.IsNullish) _self646 = GlobalV;
L_655 = Call(logo_26, V.Undef, u_653, Arr(((V)("CORNHOLE"))), ((V)(180D)), ((V)(78D)), NewObj(7).Put("size", ((V)(52D))).Put("top", ((V)("#ffffff"))).Put("bot", ((V)("#ffd36a"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#1e3a8a"))).Put("shade", ((V)("#0f2258"))).Put("rot", ((V)((-4D)))).V);
defs_656 = Add(Add(Add(Add(Get(L_655, "defs"), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_653).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#5aa8ff"))), Arr(((V)(0.65)), ((V)("#b6dcff"))), Arr(((V)(1D)), ((V)("#eef8ff")))))), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_653).S("gr").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#9fdc6e"))), Arr(((V)(1D)), ((V)("#5fb04a")))))), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_653).S("bd").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#6aa4ff"))), Arr(((V)(1D)), ((V)("#3a72e0")))))), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_653).S("bg").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#ff7a6a"))), Arr(((V)(1D)), ((V)("#d63a3a"))))));
b_657 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-420\" width=\"1400\" height=\"640\" fill=\"url(#").V(u_653).S("sk)\"/>").V(Call(rays_22, V.Undef, ((V)(206D)), ((V)(242D)), ((V)(22D)), ((V)("#ffffff")), ((V)(0.17)))).V(Call(cloud_24, V.Undef, ((V)(70D)), ((V)(150D)), ((V)(0.6)), ((V)(0.8)))).V(Call(cloud_24, V.Undef, ((V)(300D)), ((V)(176D)), ((V)(0.5)), ((V)(0.7)))).End());
b_657.V(Call(backdrop_33, V.Undef, ((V)(290D)), Arr(((V)("#4f9a3e")), ((V)("#62ad4c"))), ((V)(0.9)))).S("<path d=\"M-420 286H980V640H-420Z\" fill=\"url(#").V(u_653).S("gr)\"/>");
b_657.S("<path d=\"M326 140V300\" stroke=\"#e8e0d4\" stroke-width=\"5\" stroke-linecap=\"round\"/><circle cx=\"326\" cy=\"138\" r=\"5\" fill=\"#ffd84a\"/><path d=\"M326 146C304 140 292 154 272 150C286 160 290 170 276 182C296 180 308 168 326 176Z\" fill=\"#ff5e6c\" stroke=\"#b8304a\" stroke-width=\"2\" stroke-linejoin=\"round\"/>");
b_657.S("<path d=\"M262 160h-18M258 170h-12\" stroke=\"#ffffff\" stroke-width=\"3\" stroke-linecap=\"round\" opacity=\"0.8\"/>");
top_658 = Arr(Arr(((V)(118D)), ((V)(362D))), Arr(((V)(298D)), ((V)(362D))), Arr(((V)(262D)), ((V)(214D))), Arr(((V)(154D)), ((V)(214D))));
b_657.S("<ellipse cx=\"208\" cy=\"368\" rx=\"104\" ry=\"12\" fill=\"#2a4a20\" opacity=\"0.25\"/><path d=\"M160 214L156 252M256 214L260 252\" stroke=\"#a87444\" stroke-width=\"7\" stroke-linecap=\"round\"/>");
b_657.S("<path d=\"M118 362L298 362L298 372L118 372Z\" fill=\"#c98d54\"/><path d=\"M").V(Invoke(Invoke(top_658, "map", Fn((V _arrowThis667, int _argc660, V p_666, V _a663, V _a664, V _a665, V[] _rest661) => {
return Invoke(p_666, "join", ((V)(" ")));
}, 1, "", true)), "join", ((V)("L")))).S("Z\" fill=\"url(#").V(u_653).S("bd)\" stroke=\"#2a56b8\" stroke-width=\"3\" stroke-linejoin=\"round\"/>");
b_657.S("<path d=\"M133 300L284 300L276 268L141 268Z\" fill=\"#ffffff\" opacity=\"0.9\"/><path d=\"M137 286L281 286\" stroke=\"#ff5e6c\" stroke-width=\"6\"/>");
b_657.S("<ellipse cx=\"208\" cy=\"238\" rx=\"22\" ry=\"8\" fill=\"#14224a\"/><ellipse cx=\"208\" cy=\"236\" rx=\"22\" ry=\"8\" fill=\"none\" stroke=\"#9fc4ff\" stroke-width=\"2\"/>");
bag_659 = Fn((V _arrowThis678, int _argc668, V x_674, V y_675, V k_676, V r_677, V[] _rest669) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(x_674).S(" ").V(y_675).S(") rotate(").V(r_677).S(") scale(").V(k_676).S(")\"><path d=\"M-17 -13Q0 -17 17 -13Q21 0 17 13Q0 17 -17 13Q-21 0 -17 -13Z\" fill=\"url(#").V(u_653).S("bg)\" stroke=\"#8a1c24\" stroke-width=\"2\"/><path d=\"M-13 -9Q0 -12 13 -9\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.6\" stroke-dasharray=\"2 3\" opacity=\"0.8\"/><ellipse cx=\"-5\" cy=\"-5\" rx=\"6\" ry=\"3\" fill=\"#ffffff\" opacity=\"0.35\"/></g>").End()));
}, 4, "", true);
b_657.V(Call(bag_659, V.Undef, ((V)(246D)), ((V)(252D)), ((V)(0.8)), ((V)(18D))));
b_657.S("<path d=\"M112 232Q142 70 200 220\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"5\" stroke-dasharray=\"1 12\" stroke-linecap=\"round\" opacity=\"0.95\"/>").V(Call(speed_25, V.Undef, ((V)(176D)), ((V)(150D)), ((V)(0.95)), ((V)(3D)), ((V)(46D)), ((V)("#ffffff")), ((V)(0.8)))).V(Call(bag_659, V.Undef, ((V)(184D)), ((V)(168D)), ((V)(1.15)), ((V)(34D))));
b_657.V(Call(badge_30, V.Undef, ((V)(276D)), ((V)(112D)), ((V)(30D)), ((V)("+3")), ((V)(10D)), ((V)("#ffd84a")), ((V)("#7a3a10")), ((V)(26D))));
b_657.V(Add(Add(Call(spark_23, V.Undef, ((V)(226D)), ((V)(214D)), ((V)(7D))), Call(spark_23, V.Undef, ((V)(140D)), ((V)(120D)), ((V)(6D)))), Call(spark_23, V.Undef, ((V)(196D)), ((V)(270D)), ((V)(5D)), ((V)("#ffffff")), ((V)(0.9)))));
b_657.S("<ellipse cx=\"76\" cy=\"346\" rx=\"58\" ry=\"11\" fill=\"#2a4a20\" opacity=\"0.25\"/>").V(Call(stk_27, V.Undef, u_653, Get(c_654, "src"), ((V)(76D)), ((V)(350D)), ((V)(150D)), ((V)((-6D))), (false ? V.True : V.False), NewObj(9).Put("hRx", ((V)((-2D)))).Put("hRy", ((V)((-6D)))).Put("armR", ((V)(100D))).Put("lean", ((V)(0.8))).Put("footL", ((V)(2D))).Put("sq", ((V)((-0.03)))).Put("open", ((V)(0.3))).Put("lx", ((V)(0.8))).Put("ly", ((V)((-0.2)))).V));
return Call(wrap_31, V.Undef, u_653, defs_656, ((V)(JsStrBuf.Begin().S(b_657.Str).V(Get(L_655, "body")).End())));
return default;
}, 2, "corn", false);
pong_40 = Fn((V _self679, int _argc680, V u_686, V c_687, V _a684, V _a685, V[] _rest681) => {
V L_688 = default;
V defs_689 = default;
V paddle_690 = default;
JsStrBuf b_691 = null;
if (_self679.IsNullish) _self679 = GlobalV;
L_688 = Call(logo_26, V.Undef, u_686, Arr(((V)("PING-PONG"))), ((V)(180D)), ((V)(74D)), NewObj(7).Put("size", ((V)(50D))).Put("top", ((V)("#ffffff"))).Put("bot", ((V)("#9ff0c8"))).Put("hi", ((V)("#ffffff"))).Put("ink", ((V)("#0e4a3a"))).Put("shade", ((V)("#062a20"))).Put("rot", ((V)((-4D)))).V);
defs_689 = Add(Add(Add(Add(Add(Get(L_688, "defs"), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_686).S("sk").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#1f8a62"))), Arr(((V)(0.55)), ((V)("#5fcf9a"))), Arr(((V)(1D)), ((V)("#d6f6e6")))))), Call(lg_20, V.Undef, ((V)(JsStrBuf.Begin().V(u_686).S("tb").End())), ((V)(0D)), ((V)(1D)), Arr(Arr(((V)(0D)), ((V)("#3a74e0"))), Arr(((V)(1D)), ((V)("#2a5ccc")))))), Call(rg_21, V.Undef, ((V)(JsStrBuf.Begin().V(u_686).S("pd").End())), ((V)("40%")), ((V)("35%")), ((V)("70%")), Arr(Arr(((V)(0D)), ((V)("#ff8a7a"))), Arr(((V)(1D)), ((V)("#d0303a")))))), Call(rg_21, V.Undef, ((V)(JsStrBuf.Begin().V(u_686).S("pb").End())), ((V)("40%")), ((V)("35%")), ((V)("70%")), Arr(Arr(((V)(0D)), ((V)("#7fb0ff"))), Arr(((V)(1D)), ((V)("#2a5ccc")))))), Call(rg_21, V.Undef, ((V)(JsStrBuf.Begin().V(u_686).S("ball").End())), ((V)("35%")), ((V)("30%")), ((V)("70%")), Arr(Arr(((V)(0D)), ((V)("#ffffff"))), Arr(((V)(1D)), ((V)("#e8dcc8"))))));
paddle_690 = Fn((V _arrowThis701, int _argc692, V fill_698, V rot_699, V k_700, V _a697, V[] _rest693) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"rotate(").V(rot_699).S(") scale(").V(k_700).S(")\"><rect x=\"-7\" y=\"-6\" width=\"14\" height=\"40\" rx=\"6\" fill=\"#c98d54\" stroke=\"#4a3a2e\" stroke-width=\"3\"/><rect x=\"-7\" y=\"6\" width=\"14\" height=\"5\" fill=\"#8a5a34\" opacity=\"0.5\"/><ellipse cy=\"-38\" rx=\"30\" ry=\"33\" fill=\"url(#").V(u_686).V(fill_698).S(")\" stroke=\"#4a3a2e\" stroke-width=\"3.5\"/><ellipse cx=\"-9\" cy=\"-50\" rx=\"10\" ry=\"6\" fill=\"#ffffff\" opacity=\"0.3\" transform=\"rotate(-20 -9 -50)\"/></g>").End()));
}, 3, "", true);
b_691 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-420\" width=\"1400\" height=\"640\" fill=\"url(#").V(u_686).S("sk)\"/>").V(Call(rays_22, V.Undef, ((V)(180D)), ((V)(212D)), ((V)(24D)), ((V)("#ffffff")), ((V)(0.12)))).End());
b_691.V(Call(backdrop_33, V.Undef, ((V)(226D)), Arr(((V)("#2f8a5a")), ((V)("#3fa06a"))), ((V)(0.7)))).S("<path d=\"M-420 222H980V640H-420Z\" fill=\"#e8dcc8\"/>");
{
double i_702 = 0;
i_702 = (-7D);
while (true) {
if (!((i_702 <= 7D))) break;
b_691.S("<path d=\"M").N((180D + (i_702 * 20D))).S(" 222L").N((180D + (i_702 * 90D))).S(" 640\" stroke=\"#d4c6ae\" stroke-width=\"2\"/>");
i_702++;
}
}
Invoke(Arr(((V)(236D)), ((V)(258D)), ((V)(290D)), ((V)(336D)), ((V)(404D))), "forEach", Fn((V _arrowThis711, int _argc704, V y_710, V _a707, V _a708, V _a709, V[] _rest705) => {
b_691.S("<path d=\"M-10 ").V(y_710).S("H370\" stroke=\"#d4c6ae\" stroke-width=\"2\"/>");
return default;
}, 1, "", true));
b_691.S("<ellipse cx=\"196\" cy=\"236\" rx=\"34\" ry=\"7\" fill=\"#3a2a2a\" opacity=\"0.2\"/>").V(Call(stk_27, V.Undef, u_686, ((V)("")), ((V)(196D)), ((V)(240D)), ((V)(104D)), ((V)((-3D))), (false ? V.True : V.False), NewObj(7).Put("armR", ((V)(70D))).Put("hRy", ((V)((-4D)))).Put("lift", ((V)(1D))).Put("sq", ((V)(0.04))).Put("open", ((V)(0.3))).Put("lx", ((V)(0.3))).Put("ly", ((V)(0.4))).V, NewObj(2).Put("at", ((V)("pawR"))).Put("svg", Call(paddle_690, V.Undef, ((V)("pb")), ((V)(30D)), ((V)(0.36)))).V, ((V)("opp"))));
b_691.S("<path d=\"M60 360L64 410M300 360L296 410M104 232L106 262M256 232L254 262\" stroke=\"#3a3a4a\" stroke-width=\"6\" stroke-linecap=\"round\"/>");
b_691.S("<path d=\"M24 352L336 352L336 364L24 364Z\" fill=\"#1e3e8a\"/><path d=\"M24 352L336 352L268 226L92 226Z\" fill=\"url(#").V(u_686).S("tb)\" stroke=\"#ffffff\" stroke-width=\"4\" stroke-linejoin=\"round\"/><path d=\"M180 352L180 226\" stroke=\"#ffffff\" stroke-width=\"2.5\"/>");
b_691.S("<path d=\"M62 280H298\" stroke=\"#1a2a5a\" stroke-width=\"3\" opacity=\"0.35\"/><path d=\"M58 258L302 258L302 282L58 282Z\" fill=\"#ffffff\" opacity=\"0.3\"/><g stroke=\"#ffffff\" stroke-width=\"1\" opacity=\"0.7\">");
{
double x_712 = 0;
x_712 = 64D;
while (true) {
if (!((x_712 < 302D))) break;
b_691.S("<path d=\"M").N(x_712).S(" 258V282\"/>");
x_712 = (x_712 + 8D);
}
}
b_691.S("</g><path d=\"M54 258H306\" stroke=\"#ffffff\" stroke-width=\"4\"/><path d=\"M56 256V286M304 256V286\" stroke=\"#2a2a3a\" stroke-width=\"4\" stroke-linecap=\"round\"/>");
b_691.S("<path d=\"M206 214Q194 250 176 318L168 300Q156 262 150 236\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"4\" stroke-dasharray=\"1 10\" stroke-linecap=\"round\" opacity=\"0.95\"/><ellipse cx=\"174\" cy=\"318\" rx=\"11\" ry=\"3.5\" fill=\"#ffffff\" opacity=\"0.6\"/>");
b_691.V(Call(speed_25, V.Undef, ((V)(150D)), ((V)(232D)), ((V)(1.85)), ((V)(3D)), ((V)(30D)), ((V)("#ffffff")), ((V)(0.8)))).S("<circle cx=\"150\" cy=\"228\" r=\"10\" fill=\"url(#").V(u_686).S("ball)\" stroke=\"#c8b898\" stroke-width=\"1\"/>");
b_691.S("<ellipse cx=\"236\" cy=\"452\" rx=\"74\" ry=\"14\" fill=\"#3a2a2a\" opacity=\"0.2\"/>").V(Call(stk_27, V.Undef, u_686, Get(c_687, "src"), ((V)(236D)), ((V)(456D)), ((V)(200D)), ((V)(3D)), (false ? V.True : V.False), NewObj(5).Put("armR", ((V)(120D))).Put("hRy", ((V)((-8D)))).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.04)))).Put("tilt", ((V)((-3D)))).V, NewObj(2).Put("at", ((V)("pawR"))).Put("svg", Call(paddle_690, V.Undef, ((V)("pd")), ((V)((-26D))), ((V)(0.8)))).V, V.Null, ((V)(180D))));
b_691.V(Call(badge_30, V.Undef, ((V)(70D)), ((V)(168D)), ((V)(28D)), ((V)("RALLY!")), ((V)((-8D))), ((V)("#ffd84a")), ((V)("#7a3a10")), ((V)(17D))));
b_691.V(Add(Add(Call(spark_23, V.Undef, ((V)(300D)), ((V)(182D)), ((V)(7D))), Call(spark_23, V.Undef, ((V)(46D)), ((V)(236D)), ((V)(5D)))), Call(spark_23, V.Undef, ((V)(118D)), ((V)(200D)), ((V)(5D)))));
return Call(wrap_31, V.Undef, u_686, defs_689, ((V)(JsStrBuf.Begin().S(b_691.Str).V(Get(L_688, "body")).End())));
return default;
}, 2, "pong", false);
YG_16 = Get(G("window"), "YardGames");
if ((!(Truthy(YG_16)) || !(Truthy(Get(YG_16, "add"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
TAU_17 = (System.Math.PI * 2D);
f_18 = Fn((V _arrowThis721, int _argc714, V v_720, V _a717, V _a718, V _a719, V[] _rest715) => {
return ((V)((Round((ToNum(v_720) * 10D)) / 10D)));
}, 1, "", true);
esc_19 = Fn((V _arrowThis729, int _argc722, V s_728, V _a725, V _a726, V _a727, V[] _rest723) => {
return Invoke(((V)(ToStrS((s_728.IsNullish ? ((V)("")) : s_728)))), "replace", NewRegExp(RX0, "[&<>\"]", "g"), Fn((V _arrowThis737, int _argc730, V c_736, V _a733, V _a734, V _a735, V[] _rest731) => {
return GetK(NewObj(4).Put("&", ((V)("&amp;"))).Put("<", ((V)("&lt;"))).Put(">", ((V)("&gt;"))).Put("\"", ((V)("&quot;"))).V, c_736);
}, 1, "", true));
}, 1, "", true);
lg_20 = Fn((V _arrowThis748, int _argc738, V id_744, V x2_745, V y2_746, V stops_747, V[] _rest739) => {
return ((V)(JsStrBuf.Begin().S("<linearGradient id=\"").V(id_744).S("\" x1=\"0\" y1=\"0\" x2=\"").V(x2_745).S("\" y2=\"").V(y2_746).S("\">").V(Invoke(Invoke(stops_747, "map", Fn((V _arrowThis762, int _argc749, V _a751, V _a752, V _a753, V _a754, V[] _rest750) => {
V o_757 = default;
V c_759 = default;
V a_761 = default;
{ V _t755 = ListOf(_a751);
{ V _t756 = GetIdx(_t755, 0D);
o_757 = _t756; }
{ V _t758 = GetIdx(_t755, 1D);
c_759 = _t758; }
{ V _t760 = GetIdx(_t755, 2D);
a_761 = _t760; }
}
return ((V)(JsStrBuf.Begin().S("<stop offset=\"").V(o_757).S("\" stop-color=\"").V(c_759).S("\"").S((!a_761.IsNullish ? JsStrBuf.Begin().S(" stop-opacity=\"").V(a_761).S("\"").End() : "")).S("/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</linearGradient>").End()));
}, 4, "", true);
rg_21 = Fn((V _arrowThis774, int _argc763, V id_769, V cx_770, V cy_771, V r_772, V[] _rest764) => {
V stops_773 = default;
stops_773 = (_argc763 > 4 ? _rest764[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<radialGradient id=\"").V(id_769).S("\" cx=\"").V(cx_770).S("\" cy=\"").V(cy_771).S("\" r=\"").V(r_772).S("\">").V(Invoke(Invoke(stops_773, "map", Fn((V _arrowThis788, int _argc775, V _a777, V _a778, V _a779, V _a780, V[] _rest776) => {
V o_783 = default;
V c_785 = default;
V a_787 = default;
{ V _t781 = ListOf(_a777);
{ V _t782 = GetIdx(_t781, 0D);
o_783 = _t782; }
{ V _t784 = GetIdx(_t781, 1D);
c_785 = _t784; }
{ V _t786 = GetIdx(_t781, 2D);
a_787 = _t786; }
}
return ((V)(JsStrBuf.Begin().S("<stop offset=\"").V(o_783).S("\" stop-color=\"").V(c_785).S("\"").S((!a_787.IsNullish ? JsStrBuf.Begin().S(" stop-opacity=\"").V(a_787).S("\"").End() : "")).S("/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</radialGradient>").End()));
}, 5, "", true);
rays_22 = Fn((V _arrowThis801, int _argc789, V cx_795, V cy_796, V n_797, V col_798, V[] _rest790) => {
JsStrBuf d_802 = null;
V op_799 = default;
V a0_800 = default;
op_799 = (_argc789 > 4 ? _rest790[0] : V.Undef);
a0_800 = (_argc789 > 5 ? _rest790[1] : V.Undef);
d_802 = new JsStrBuf("");
{
double i_803 = 0;
i_803 = 0D;
while (true) {
if (!(Lt(((V)(i_803)), n_797))) break;
V a_805 = default;
V b_806 = default;
a_805 = Add((a0_800 is var _t807 && Truthy(_t807) ? _t807 : ((V)(0D))), ((V)(((i_803 / ToNum(n_797)) * TAU_17))));
b_806 = Add(a_805, ((V)(((TAU_17 / ToNum(n_797)) / 2D))));
d_802.S("M").V(cx_795).S(" ").V(cy_796).S("L").V(Call(f_18, V.Undef, Add(cx_795, ((V)((FdLibm.Cos(ToNum(a_805)) * 1100D)))))).S(" ").V(Call(f_18, V.Undef, Add(cy_796, ((V)((FdLibm.Sin(ToNum(a_805)) * 1100D)))))).S("L").V(Call(f_18, V.Undef, Add(cx_795, ((V)((FdLibm.Cos(ToNum(b_806)) * 1100D)))))).S(" ").V(Call(f_18, V.Undef, Add(cy_796, ((V)((FdLibm.Sin(ToNum(b_806)) * 1100D)))))).S("Z");
i_803++;
}
}
return ((V)(JsStrBuf.Begin().S("<path d=\"").S(d_802.Str).S("\" fill=\"").V(col_798).S("\" opacity=\"").V(op_799).S("\"/>").End()));
return default;
}, 6, "", true);
spark_23 = Fn((V _arrowThis819, int _argc808, V x_814, V y_815, V r_816, V col_817, V[] _rest809) => {
V op_818 = default;
op_818 = (_argc808 > 4 ? _rest809[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<path transform=\"translate(").V(Call(f_18, V.Undef, x_814)).S(" ").V(Call(f_18, V.Undef, y_815)).S(") scale(").V(r_816).S(")\" d=\"M0 -1C0.13 -0.3 0.3 -0.13 1 0C0.3 0.13 0.13 0.3 0 1C-0.13 0.3 -0.3 0.13 -1 0C-0.3 -0.13 -0.13 -0.3 0 -1Z\" fill=\"").V((col_817 is var _t820 && Truthy(_t820) ? _t820 : ((V)("#ffffff")))).S("\"").S((!op_818.IsNullish ? JsStrBuf.Begin().S(" opacity=\"").V(op_818).S("\"").End() : "")).S("/>").End()));
}, 5, "", true);
cloud_24 = Fn((V _arrowThis831, int _argc821, V x_827, V y_828, V k_829, V op_830, V[] _rest822) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(x_827).S(" ").V(y_828).S(") scale(").V(k_829).S(")\" fill=\"#ffffff\" opacity=\"").V((op_830 is var _t832 && Truthy(_t832) ? _t832 : ((V)(0.95)))).S("\"><circle cx=\"-26\" cy=\"4\" r=\"18\"/><circle cx=\"0\" cy=\"-8\" r=\"25\"/><circle cx=\"27\" cy=\"2\" r=\"19\"/><circle cx=\"10\" cy=\"10\" r=\"18\"/><circle cx=\"-12\" cy=\"11\" r=\"16\"/></g>").End()));
}, 4, "", true);
speed_25 = Fn((V _arrowThis846, int _argc833, V x_839, V y_840, V ang_841, V n_842, V[] _rest834) => {
JsStrBuf s_847 = null;
double ca_848 = 0;
double sa_849 = 0;
V len_843 = default;
V col_844 = default;
V op_845 = default;
len_843 = (_argc833 > 4 ? _rest834[0] : V.Undef);
col_844 = (_argc833 > 5 ? _rest834[1] : V.Undef);
op_845 = (_argc833 > 6 ? _rest834[2] : V.Undef);
s_847 = new JsStrBuf("");
ca_848 = FdLibm.Cos(ToNum(ang_841));
sa_849 = FdLibm.Sin(ToNum(ang_841));
{
double i_850 = 0;
i_850 = 0D;
while (true) {
if (!(Lt(((V)(i_850)), n_842))) break;
double o_852 = 0;
double l_853 = 0;
double bx_854 = 0;
double by_855 = 0;
o_852 = ((i_850 - ((ToNum(n_842) - 1D) / 2D)) * 11D);
l_853 = (ToNum(len_843) * (0.6 + ((0.4 * ((i_850 * 37D) % 10D)) / 10D)));
bx_854 = ((ToNum(x_839) - (sa_849 * o_852)) - (ca_848 * (14D + ((i_850 % 2D) * 8D))));
by_855 = (ToNum(Add(y_840, ((V)((ca_848 * o_852))))) - (sa_849 * (14D + ((i_850 % 2D) * 8D))));
s_847.S("<path d=\"M").V(Call(f_18, V.Undef, ((V)(bx_854)))).S(" ").V(Call(f_18, V.Undef, ((V)(by_855)))).S("L").V(Call(f_18, V.Undef, ((V)((bx_854 - (ca_848 * l_853)))))).S(" ").V(Call(f_18, V.Undef, ((V)((by_855 - (sa_849 * l_853)))))).S("\" stroke=\"").V((col_844 is var _t856 && Truthy(_t856) ? _t856 : ((V)("#ffffff")))).S("\" stroke-width=\"").N((NumTruthy((i_850 % 2D)) ? 3D : 4.5)).S("\" stroke-linecap=\"round\" opacity=\"").V((op_845 is var _t857 && Truthy(_t857) ? _t857 : ((V)(0.8)))).S("\"/>");
i_850++;
}
}
return ((V)(s_847.Str));
return default;
}, 7, "", true);
stk_27 = Fn((V _arrowThis875, int _argc858, V u_864, V src_865, V x_866, V y_867, V[] _rest859) => {
V w_868 = default;
V rot_869 = default;
V flip_870 = default;
V pose_871 = default;
V prop_872 = default;
V who_873 = default;
V yaw_874 = default;
w_868 = (_argc858 > 4 ? _rest859[0] : V.Undef);
rot_869 = (_argc858 > 5 ? _rest859[1] : V.Undef);
flip_870 = (_argc858 > 6 ? _rest859[2] : V.Undef);
pose_871 = (_argc858 > 7 ? _rest859[3] : V.Undef);
prop_872 = (_argc858 > 8 ? _rest859[4] : V.Undef);
who_873 = (_argc858 > 9 ? _rest859[5] : V.Undef);
yaw_874 = (_argc858 > 10 ? _rest859[6] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(f_18, V.Undef, x_866)).S(" ").V(Call(f_18, V.Undef, y_867)).S(") rotate(").V((rot_869 is var _t876 && Truthy(_t876) ? _t876 : ((V)(0D)))).S(")").S((Truthy(flip_870) ? " scale(-1 1)" : "")).S("\"><g class=\"ygp-cr\" style=\"opacity:0;transition:opacity .25s ease\" data-w=\"").V(w_868).S("\" data-src=\"").V(Call(esc_19, V.Undef, src_865)).S("\"").S((Truthy(pose_871) ? JsStrBuf.Begin().S(" data-pose=\"").V(Call(esc_19, V.Undef, Invoke(G("JSON"), "stringify", pose_871))).S("\"").End() : "")).S((Truthy(who_873) ? JsStrBuf.Begin().S(" data-who=\"").V(who_873).S("\"").End() : "")).S((Truthy(yaw_874) ? JsStrBuf.Begin().S(" data-yaw=\"").V(yaw_874).S("\"").End() : "")).S("></g>").S((Truthy(prop_872) ? JsStrBuf.Begin().S("<g class=\"ygp-prop\" data-at=\"").V(Get(prop_872, "at")).S("\" style=\"opacity:0;transition:opacity .25s ease\">").V(Get(prop_872, "svg")).S("</g>").End() : "")).S("</g>").End()));
}, 11, "", true);
POOL_28 = Arr(((V)("biscuit")), ((V)("pip")), ((V)("mallow")), ((V)("nimbo")), ((V)("ribbit")), ((V)("bao")), ((V)("mittens")), ((V)("sealy")), ((V)("frybo")), ((V)("poppy")));
Set(YG_16, "posterRig", Fn((V _self877, int _argc878, V el_884, V key0_885, V o_886, V _a883, V[] _rest879) => {
V R_887 = default;
V SQ_888 = default;
V pool_889 = default;
V opp_890 = default;
if (_self877.IsNullish) _self877 = GlobalV;
R_887 = Get(G("window"), "RiveRig");
o_886 = (o_886 is var _t891 && Truthy(_t891) ? _t891 : NewObj(0).V);
SQ_888 = Get(G("window"), "SquishSquad");
pool_889 = (Truthy((SQ_888 is var _t910 && !Truthy(_t910) ? _t910 : Get(SQ_888, "ROSTER"))) ? Invoke(Invoke(Get(SQ_888, "ROSTER"), "filter", Fn((V _arrowThis907, int _argc900, V c_906, V _a903, V _a904, V _a905, V[] _rest901) => {
return (c_906 is var _t909 && !Truthy(_t909) ? _t909 : Invoke((Get(YG_16, "SETS") is var _t908 && Truthy(_t908) ? _t908 : Arr(((V)("snack")), ((V)("fruit")), ((V)("pet")))), "includes", Get(c_906, "set")));
}, 1, "", true)), "map", Fn((V _arrowThis899, int _argc892, V c_898, V _a895, V _a896, V _a897, V[] _rest893) => {
return Get(c_898, "key");
}, 1, "", true)) : POOL_28);
opp_890 = (Get(o_886, "opp") is var _t927 && Truthy(_t927) ? _t927 : Call(Fn((V _arrowThis926, int _argc919, V L_925, V _a922, V _a923, V _a924, V[] _rest920) => {
return GetIdx(L_925, System.Math.Floor((ToNum(Invoke(G("Math"), "random")) * ToNum(Get(L_925, "length")))));
}, 1, "", true), V.Undef, Invoke(pool_889, "filter", Fn((V _arrowThis918, int _argc911, V k_917, V _a914, V _a915, V _a916, V[] _rest912) => {
return (!SEq(k_917, key0_885) ? V.True : V.False);
}, 1, "", true))));
Invoke(Invoke(el_884, "querySelectorAll", ((V)(".ygp-cr"))), "forEach", Fn((V _arrowThis935, int _argc928, V g_934, V _a931, V _a932, V _a933, V[] _rest929) => {
double w_936 = 0;
V key_937 = default;
V flatSrc_938 = default;
V flat_939 = default;
V host_940 = default;
V C_941 = default;
V I_942 = default;
V svg_943 = default;
V prop_944 = default;
V hold_945 = default;
V t0_946 = default;
V end_947 = default;
V wait_948 = default;
w_936 = ToNum(Get(Get(g_934, "dataset"), "w"));
key_937 = (SEqS(Get(Get(g_934, "dataset"), "who"), "opp") ? opp_890 : key0_885);
flatSrc_938 = (SEqS(Get(Get(g_934, "dataset"), "who"), "opp") ? ((V)("")) : Get(Get(g_934, "dataset"), "src"));
flat_939 = Fn((V _arrowThis955, int _argc949, V _a951, V _a952, V _a953, V _a954, V[] _rest950) => {
if (!(Truthy(flatSrc_938))) {
return default;
}
if (!(Truthy(Invoke(g_934, "querySelector", ((V)("image")))))) {
Invoke(g_934, "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<image href=\"").V(Call(esc_19, V.Undef, flatSrc_938)).S("\" x=\"").V(Call(f_18, V.Undef, ((V)(((-w_936) / 2D))))).S("\" y=\"").V(Call(f_18, V.Undef, ((V)(((-w_936) * 0.95))))).S("\" width=\"").N(w_936).S("\" height=\"").N(w_936).S("\" preserveAspectRatio=\"xMidYMax meet\"/>").End())));
}
Set(Get(g_934, "style"), "opacity", ((V)(1D)));
return default;
}, 0, "", true);
if (((!(Truthy(R_887)) || !(Truthy(Get(R_887, "mount")))) || !(Truthy(key_937)))) {
return Call(flat_939, V.Undef);
}
host_940 = Invoke(G("document"), "createElement", ((V)("div")));
Set(Get(host_940, "style"), "cssText", ((V)(JsStrBuf.Begin().S("position:fixed;left:-5000px;top:0;width:").N(w_936).S("px;height:").N(w_936).S("px;pointer-events:none;").End())));
Invoke(Get(G("document"), "body"), "appendChild", host_940);
C_941 = V.Null;
try {
C_941 = Invoke(R_887, "mount", host_940, key_937, NewObj(2).Put("fidgets", (false ? V.True : V.False)).Put("look", ((V)(3D))).V);
} catch (System.Exception _ex956) {
V e_957 = default;
e_957 = Caught(_ex956);
Invoke(host_940, "remove");
return Call(flat_939, V.Undef);
}
I_942 = (C_941 is var _t958 && !Truthy(_t958) ? _t958 : Get(C_941, "_I"));
svg_943 = Invoke(host_940, "querySelector", ((V)("svg")));
if ((!(Truthy(I_942)) || !(Truthy(svg_943)))) {
try {
if (Truthy(C_941)) {
Invoke(C_941, "destroy");
}
} catch (System.Exception _ex959) {
V e_960 = default;
e_960 = Caught(_ex959);

}
Invoke(host_940, "remove");
return Call(flat_939, V.Undef);
}
Set(I_942, "fidgets", (false ? V.True : V.False));
Set(I_942, "ptr", V.Null);
Set(I_942, "blinkAt", ((V)(1000000000000000D)));
Set(I_942, "glAt", ((V)(1000000000000000D)));
Set(I_942, "blinkT", ((V)((-1000000000D))));
if (Truthy(Get(Get(g_934, "dataset"), "pose"))) {
try {
Set(I_942, "ext", Invoke(G("JSON"), "parse", Get(Get(g_934, "dataset"), "pose")));
} catch (System.Exception _ex961) {
V e_962 = default;
e_962 = Caught(_ex961);

}
}
if (Truthy(Get(Get(g_934, "dataset"), "yaw"))) {
Set(I_942, "spinOff", ((V)(ToNum(Get(Get(g_934, "dataset"), "yaw")))));
}
if (Truthy(Get(I_942, "shadow"))) {
Set(Get(Get(I_942, "shadow"), "style"), "display", ((V)("none")));
}
Invoke(svg_943, "setAttribute", ((V)("style")), ((V)("overflow:visible")));
Invoke(svg_943, "setAttribute", ((V)("x")), Call(f_18, V.Undef, ((V)(((-w_936) / 2D)))));
Invoke(svg_943, "setAttribute", ((V)("y")), Call(f_18, V.Undef, ((V)(((-w_936) * 0.93)))));
Invoke(svg_943, "setAttribute", ((V)("width")), ((V)(w_936)));
Invoke(svg_943, "setAttribute", ((V)("height")), ((V)(w_936)));
Invoke(g_934, "appendChild", svg_943);
prop_944 = (Get(g_934, "parentNode") is var _t972 && !Truthy(_t972) ? _t972 : Invoke(new ArrBuilder().Spread(Get(Get(g_934, "parentNode"), "children")).V, "find", Fn((V _arrowThis970, int _argc963, V e_969, V _a966, V _a967, V _a968, V[] _rest964) => {
return (Get(e_969, "classList") is var _t971 && !Truthy(_t971) ? _t971 : Invoke(Get(e_969, "classList"), "contains", ((V)("ygp-prop"))));
}, 1, "", true)));
hold_945 = Fn((V _arrowThis979, int _argc973, V _a975, V _a976, V _a977, V _a978, V[] _rest974) => {
V p_980 = default;
if (!(Truthy(prop_944))) {
return default;
}
p_980 = (Get(I_942, "W") is var _t981 && !Truthy(_t981) ? _t981 : GetK(Get(I_942, "W"), Get(Get(prop_944, "dataset"), "at")));
if (Truthy(p_980)) {
Invoke(prop_944, "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(f_18, V.Undef, ((V)((((-w_936) / 2D) + ((ToNum(GetIdx(p_980, 0D)) * w_936) / 100D)))))).S(" ").V(Call(f_18, V.Undef, ((V)((((-w_936) * 0.93) + ((ToNum(GetIdx(p_980, 1D)) * w_936) / 100D)))))).S(")").End())));
}
Set(Get(prop_944, "style"), "opacity", ((V)(1D)));
return default;
}, 0, "", true);
t0_946 = Invoke(G("performance"), "now");
end_947 = Fn((V _arrowThis989, int _argc982, V still_988, V _a985, V _a986, V _a987, V[] _rest983) => {
if (Truthy(still_988)) {
Call(hold_945, V.Undef);
} else {
if (Truthy(prop_944)) {
Invoke(prop_944, "remove");
}
}
try {
Invoke(C_941, "destroy");
} catch (System.Exception _ex990) {
V e_991 = default;
e_991 = Caught(_ex990);

}
Invoke(host_940, "remove");
if (!(Truthy(still_988))) {
Invoke(svg_943, "remove");
Call(flat_939, V.Undef);
}
return default;
}, 1, "", true);
wait_948 = Fn((V _arrowThis998, int _argc992, V _a994, V _a995, V _a996, V _a997, V[] _rest993) => {
double t_999 = 0;
t_999 = (ToNum(Invoke(G("performance"), "now")) - ToNum(t0_946));
if (!(Truthy(Get(g_934, "isConnected")))) {
return Call(end_947, V.Undef, (true ? V.True : V.False));
}
if (Truthy((Get(I_942, "generic") is var _t1000 && !Truthy(_t1000) ? _t1000 : (!(Truthy(Get(I_942, "ready"))) ? V.True : V.False)))) {
if ((t_999 > 8000D)) {
return Call(end_947, V.Undef, (false ? V.True : V.False));
}
return Call(G("requestAnimationFrame"), V.Undef, wait_948);
}
if (Truthy(Get(I_942, "err"))) {
return Call(end_947, V.Undef, (false ? V.True : V.False));
}
Set(I_942, "blinkAt", ((V)(1000000000000000D)));
Set(I_942, "blinkT", ((V)((-1000000000D))));
if ((t_999 > 250D)) {
Set(Get(g_934, "style"), "opacity", ((V)(1D)));
Call(hold_945, V.Undef);
}
if ((t_999 < 900D)) {
return Call(G("requestAnimationFrame"), V.Undef, wait_948);
}
Call(end_947, V.Undef, (true ? V.True : V.False));
return default;
}, 0, "", true);
Call(G("requestAnimationFrame"), V.Undef, wait_948);
return default;
}, 1, "", true));
return default;
}, 3, "", false));
STK_29 = Fn((V _arrowThis1008, int _argc1001, V u_1007, V _a1004, V _a1005, V _a1006, V[] _rest1002) => {
return ((V)(JsStrBuf.Begin().S("<filter id=\"").V(u_1007).S("stk\" x=\"-20%\" y=\"-20%\" width=\"140%\" height=\"145%\" color-interpolation-filters=\"sRGB\"><feMorphology in=\"SourceAlpha\" operator=\"dilate\" radius=\"3.4\" result=\"d\"/><feFlood flood-color=\"#ffffff\"/><feComposite in2=\"d\" operator=\"in\" result=\"w\"/>").S("<feGaussianBlur in=\"d\" stdDeviation=\"4\"/><feOffset dy=\"6\" result=\"b\"/><feFlood flood-color=\"#2a1048\" flood-opacity=\"0.32\"/><feComposite in2=\"b\" operator=\"in\" result=\"sh\"/><feMerge><feMergeNode in=\"sh\"/><feMergeNode in=\"w\"/><feMergeNode in=\"SourceGraphic\"/></feMerge></filter>").S("<filter id=\"").V(u_1007).S("soft\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"5\"/></filter>").End()));
}, 1, "", true);
wrap_31 = Fn((V _arrowThis1018, int _argc1009, V u_1015, V defs_1016, V body_1017, V _a1014, V[] _rest1010) => {
return ((V)(JsStrBuf.Begin().S("<svg viewBox=\"-40 16 780 360\" preserveAspectRatio=\"xMidYMid slice\" aria-hidden=\"true\"><defs>").V(Call(STK_29, V.Undef, u_1015)).V(Call(rg_21, V.Undef, ((V)(JsStrBuf.Begin().V(u_1015).S("vig").End())), ((V)("40%")), ((V)("45%")), ((V)("80%")), Arr(Arr(((V)(0.6)), ((V)("#000000")), ((V)(0D))), Arr(((V)(1D)), ((V)("#1a0830")), ((V)(0.26)))))).V(defs_1016).S("</defs>").V(body_1017).S("<rect x=\"-40\" y=\"16\" width=\"780\" height=\"360\" fill=\"url(#").V(u_1015).S("vig)\" pointer-events=\"none\"/></svg>").End()));
}, 3, "", true);
wrapL_32 = Fn((V _arrowThis1028, int _argc1019, V u_1025, V defs_1026, V body_1027, V _a1024, V[] _rest1020) => {
return ((V)(JsStrBuf.Begin().S("<svg viewBox=\"0 0 780 360\" preserveAspectRatio=\"xMidYMid slice\" aria-hidden=\"true\"><defs>").V(Call(STK_29, V.Undef, u_1025)).V(Call(rg_21, V.Undef, ((V)(JsStrBuf.Begin().V(u_1025).S("vig").End())), ((V)("40%")), ((V)("45%")), ((V)("80%")), Arr(Arr(((V)(0.6)), ((V)("#000000")), ((V)(0D))), Arr(((V)(1D)), ((V)("#1a0830")), ((V)(0.26)))))).V(defs_1026).S("</defs>").V(body_1027).S("<rect width=\"780\" height=\"360\" fill=\"url(#").V(u_1025).S("vig)\" pointer-events=\"none\"/></svg>").End()));
}, 3, "", true);
Set(YG_16, "POSTER", NewObj(7).Put("hoop", hoop_34).Put("soccer", soccer_35).Put("hop", hop_36).Put("tramp", tramp_37).Put("slide", slide_38).Put("corn", corn_39).Put("pong", pong_40).V);
return default;
}, 0, "", true);
Call(go_8, V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
