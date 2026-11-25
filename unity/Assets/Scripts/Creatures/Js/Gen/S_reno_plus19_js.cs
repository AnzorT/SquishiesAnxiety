// reno-plus19.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus19_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("\"", "g");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile(">", "g");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("<", "g");
        static readonly System.Text.RegularExpressions.Regex RX3 = JsRegExp.Compile("&", "g");
        static readonly System.Text.RegularExpressions.Regex RX4 = JsRegExp.Compile("stroke=\"#bdb3a0\"", "");
        static readonly System.Text.RegularExpressions.Regex RX5 = JsRegExp.Compile("fill=\"[^\"]*\"", "g");
        public static void Run()
        {
Call(Named(boot_706 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V shade_11 = default;
V N_12 = default;
V H_13 = default;
double PI_14 = 0;
V cam_15 = default;
V an_16 = default;
V at_17 = default;
V SPL_18 = default;
V f1_19 = default;
V n4_20 = default;
V rep_21 = default;
V P2_22 = default;
V rng_23 = default;
V ext_24 = default;
V DEF12_25 = default;
V WD_26 = default;
V wsh_27 = default;
V innerW_28 = default;
V tile_29 = default;
V blot_30 = default;
V outlet_31 = default;
V BB_32 = default;
V SURF12_33 = default;
V box3_34 = default;
V cyl3_35 = default;
V sph_36 = default;
V pane_37 = default;
V xe_38 = default;
V T_39 = default;
V SCRIPT_40 = default;
V HAND_41 = default;
V SERIF_42 = default;
V DEF19_43 = default;
V capBoard_44 = default;
V swPlate_45 = default;
V scuffs_46 = default;
V sPaper_47 = default;
V sSage_48 = default;
V sWain_49 = default;
V sHerr_50 = default;
V sMarb_51 = default;
V MONTHS_52 = default;
V DAYS_53 = default;
V pizzaPhoto_54 = default;
V triArt_55 = default;
V archPts_56 = default;
V archD_57 = default;
V qt_58 = default;
V qw_59 = default;
V WDEF_60 = default;
V bev_61 = default;
V ring_62 = default;
V reveal_63 = default;
V sill_64 = default;
V cloud_65 = default;
V drift_66 = default;
V tree_67 = default;
V glassRef_68 = default;
V w12_69 = default;
V w32_70 = default;
V w52_71 = default;
V w72_72 = default;
V w92_73 = default;
V WIN19_74 = default;
V WMEMO_75 = default;
V winArt_76 = default;
V draw18_77 = default;
V edit18_78 = default;
if (_self1.IsNullish) _self1 = GlobalV;
sPaper_47 = Fn((V _self79, int _argc80, V _a82, V _a83, V _a84, V _a85, V[] _rest81) => {
V R_86 = default;
JsStrBuf s_87 = null;
V sprig_88 = default;
V stain_89 = default;
V sup_90 = default;
if (_self79.IsNullish) _self79 = GlobalV;
R_86 = Call(rng_23, V.Undef, ((V)("lp19")));
s_87 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#ebe2ca\"/>").V(Call(blot_30, V.Undef, ((V)("lp19")), ((V)(30D)), Arr(((V)("#f1e9d4")), ((V)("#e1d6ba")), ((V)("#e8dec4"))), ((V)(0.3)), ((V)(3D)))).End());
{
double i_91 = 0;
i_91 = 0D;
while (true) {
if (!((i_91 < 10D))) break;
double x_93 = 0;
x_93 = (i_91 * 8D);
s_87.S(string.Concat("<rect x=\"", NumStr((x_93 + 0.6)), "\" width=\"3\" height=\"56\" fill=\"#d9cba8\" opacity=\"0.32\"/><rect x=\"", NumStr((x_93 + 5.3)), "\" width=\"0.2\" height=\"56\" fill=\"#c4b088\" opacity=\"0.5\"/><rect x=\"", NumStr((x_93 + 6.1)), "\" width=\"0.2\" height=\"56\" fill=\"#c4b088\" opacity=\"0.5\"/>"));
i_91++;
}
}
sprig_88 = Fn((V _arrowThis102, int _argc94, V x_100, V y_101, V _a98, V _a99, V[] _rest95) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_19, V.Undef, x_100)), " ", ToStr(Call(f1_19, V.Undef, y_101)), ")\"><path d=\"M0 1.3Q0.2 0.3 0 -0.6M0 0.5Q-0.6 0.2 -0.9 -0.3M0 0.7Q0.6 0.5 0.8 0\" stroke=\"#93a07a\" stroke-width=\"0.16\" fill=\"none\" opacity=\"0.75\"/><circle cy=\"-0.8\" r=\"0.45\" fill=\"#d39c98\" opacity=\"0.7\"/><circle cx=\"-0.95\" cy=\"-0.45\" r=\"0.3\" fill=\"#d39c98\" opacity=\"0.6\"/><circle cx=\"0.85\" cy=\"-0.1\" r=\"0.3\" fill=\"#d39c98\" opacity=\"0.6\"/><circle cy=\"-0.8\" r=\"0.14\" fill=\"#f3e2b0\"/></g>")));
}, 2, "", true);
{
double i_103 = 0;
i_103 = 0D;
while (true) {
if (!((i_103 < 10D))) break;
{
double j_105 = 0;
j_105 = (-1D);
while (true) {
if (!((j_105 < 8D))) break;
s_87.V(Call(sprig_88, V.Undef, ((V)(((i_103 * 8D) + 4.4))), ((V)((((j_105 * 8D) + ((i_103 % 2D) * 4D)) + 3D)))));
j_105++;
}
}
i_103++;
}
}
s_87.S("<rect width=\"80\" height=\"22\" fill=\"url(#lpy)\"/>");
Invoke(Arr(((V)(0D)), ((V)(26.67)), ((V)(53.33)), ((V)(80D))), "forEach", Fn((V _arrowThis114, int _argc107, V x_113, V _a110, V _a111, V _a112, V[] _rest108) => {
return ((V)(s_87.S(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, x_113)), " 0V56\" stroke=\"#b3a482\" stroke-width=\"0.14\" opacity=\"0.65\"/><path d=\"M", ToStr(Call(f1_19, V.Undef, Add(x_113, ((V)(0.18))))), " 0V56\" stroke=\"#ffffff\" stroke-width=\"0.12\" opacity=\"0.45\"/>")).Str));
}, 1, "", true));
s_87.S("<path d=\"M53.33 0V8.5L52.7 0Z\" fill=\"#000000\" opacity=\"0.18\" filter=\"url(#wb1)\"/><path d=\"M53.33 0V8Q54.3 4.6 55.6 0Z\" fill=\"#f7f0de\" stroke=\"#b3a482\" stroke-width=\"0.12\"/><path d=\"M53.6 0.6Q54.2 3.4 53.5 6.4\" stroke=\"#d8cba8\" stroke-width=\"0.14\" fill=\"none\"/>");
stain_89 = Fn((V _arrowThis125, int _argc115, V cx_121, V w_122, V h_123, V sd_124, V[] _rest116) => {
V Q_126 = default;
JsStrBuf d_127 = null;
Q_126 = Call(rng_23, V.Undef, sd_124);
d_127 = new JsStrBuf(string.Concat("M", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(cx_121) - (ToNum(w_122) / 2D)))))), " 0"));
{
double i_128 = 0;
i_128 = 1D;
while (true) {
if (!((i_128 < 10D))) break;
double t_130 = 0;
t_130 = (i_128 / 10D);
d_127.S(string.Concat("L", ToStr(Call(f1_19, V.Undef, ((V)(((ToNum(cx_121) - (ToNum(w_122) / 2D)) + (ToNum(w_122) * t_130)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(((ToNum(h_123) * FdLibm.Sin((PI_14 * t_130))) * (0.72 + (0.4 * ToNum(Call(Q_126, V.Undef)))))))))));
i_128++;
}
}
return ((V)(string.Concat(d_127.Str, string.Concat("L", ToStr(Call(f1_19, V.Undef, Add(cx_121, ((V)((ToNum(w_122) / 2D)))))), " 0Z"))));
return default;
}, 4, "", true);
Invoke(Arr(Arr(((V)(16D)), ((V)(15D)), ((V)(14D)), ((V)("st1"))), Arr(((V)(65D)), ((V)(9D)), ((V)(8D)), ((V)("st2")))), "forEach", Fn((V _arrowThis146, int _argc131, V _a133, V _a134, V _a135, V _a136, V[] _rest132) => {
V d1_147 = default;
V d2_148 = default;
V cx_139 = default;
V w_141 = default;
V h_143 = default;
V sd_145 = default;
{ V _t137 = ListOf(_a133);
{ V _t138 = GetIdx(_t137, 0D);
cx_139 = _t138; }
{ V _t140 = GetIdx(_t137, 1D);
w_141 = _t140; }
{ V _t142 = GetIdx(_t137, 2D);
h_143 = _t142; }
{ V _t144 = GetIdx(_t137, 3D);
sd_145 = _t144; }
}
d1_147 = Call(stain_89, V.Undef, cx_139, w_141, h_143, sd_145);
d2_148 = Call(stain_89, V.Undef, Add(cx_139, ((V)(1D))), ((V)((ToNum(w_141) * 0.62))), ((V)((ToNum(h_143) * 0.6))), ((V)(JsStrBuf.Begin().V(sd_145).S("b").End())));
s_87.S(string.Concat("<path d=\"", ToStr(d1_147), "\" fill=\"#c4a670\" opacity=\"0.26\" filter=\"url(#wb2)\"/><path d=\"", ToStr(d1_147), "\" fill=\"none\" stroke=\"#977a46\" stroke-width=\"0.35\" opacity=\"0.42\" filter=\"url(#wb1)\"/><path d=\"", ToStr(d2_148), "\" fill=\"#b5955c\" opacity=\"0.2\" filter=\"url(#wb1)\"/><path d=\"", ToStr(d2_148), "\" fill=\"none\" stroke=\"#86683a\" stroke-width=\"0.22\" opacity=\"0.38\"/>"));
return default;
}, 1, "", true));
s_87.S("<path d=\"M31.2 22.6L32.6 21.4L34.4 22L35.2 23.8L33.8 25.2L31.8 24.6Z\" fill=\"#c9c2b2\"/><path d=\"M31.2 22.6L32.6 21.4L34.4 22L35.2 23.8L33.8 25.2L31.8 24.6Z\" fill=\"none\" stroke=\"#f7f0de\" stroke-width=\"0.22\"/><path d=\"M32.2 23.6l1.2 0.3\" stroke=\"#aaa294\" stroke-width=\"0.12\"/>");
Invoke(Arr(Arr(((V)(40.5)), ((V)(15.2))), Arr(((V)(12.2)), ((V)(30.4))), Arr(((V)(45.6)), ((V)(15.4)))), "forEach", Fn((V _arrowThis160, int _argc149, V _a151, V _a152, V _a153, V _a154, V[] _rest150) => {
V x_157 = default;
V y_159 = default;
{ V _t155 = ListOf(_a151);
{ V _t156 = GetIdx(_t155, 0D);
x_157 = _t156; }
{ V _t158 = GetIdx(_t155, 1D);
y_159 = _t158; }
}
return ((V)(s_87.S(string.Concat("<circle cx=\"", ToStr(x_157), "\" cy=\"", ToStr(y_159), "\" r=\"0.2\" fill=\"#5a4c38\"/><circle cx=\"", ToStr(Add(x_157, ((V)(0.06)))), "\" cy=\"", ToStr(Add(y_159, ((V)(0.06)))), "\" r=\"0.26\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.06\" opacity=\"0.6\"/>")).Str));
}, 1, "", true));
sup_90 = ((V)(s_87.Str));
s_87.V(Call(outlet_31, V.Undef, ((V)(47.4)), ((V)(46.3)), ((V)("#efe7d4")), ((V)("#5a5244"))));
return NewObj(5).Put("mat", ((V)(s_87.Str))).Put("sup", sup_90).Put("defs", ((V)("<linearGradient id=\"lpy\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#cdb27a\" stop-opacity=\"0.16\"/><stop offset=\"1\" stop-color=\"#cdb27a\" stop-opacity=\"0\"/></linearGradient>"))).Put("board", ((V)("#dcd1b9"))).Put("ro", NewObj(3).Put("top", ((V)(0.06))).Put("ao", ((V)(0.15))).Put("board", Add(Call(capBoard_44, V.Undef, ((V)("#dcd1b9")), ((V)(0.9))), Call(scuffs_46, V.Undef, ((V)("lpb")), ((V)(16D)), ((V)("#9c917c")), ((V)("#ece4d2"))))).V).V;
return default;
}, 0, "sPaper", false);
sSage_48 = Fn((V _self161, int _argc162, V _a164, V _a165, V _a166, V _a167, V[] _rest163) => {
V R_168 = default;
JsStrBuf s_169 = null;
V sup_170 = default;
if (_self161.IsNullish) _self161 = GlobalV;
R_168 = Call(rng_23, V.Undef, ((V)("sg19")));
s_169 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#9caf8b\"/>").V(Call(blot_30, V.Undef, ((V)("sg19")), ((V)(30D)), Arr(((V)("#a7b996")), ((V)("#90a381")), ((V)("#a1b391"))), ((V)(0.32)), ((V)(3.4)))).End());
{
double i_171 = 0;
i_171 = 0D;
while (true) {
if (!((i_171 < 16D))) break;
s_169.S(string.Concat("<rect x=\"", NumStr((i_171 * 5D)), "\" width=\"5\" height=\"56\" fill=\"", (NumTruthy((i_171 % 2D)) ? "#ffffff" : "#000000"), "\" opacity=\"", ToStr(Call(f1_19, V.Undef, ((V)((0.008 + (ToNum(Call(R_168, V.Undef)) * 0.012)))))), "\"/>"));
i_171++;
}
}
s_169.S("<rect width=\"80\" height=\"56\" fill=\"url(#sgs)\"/>");
sup_170 = ((V)(s_169.Str));
s_169.V(Call(outlet_31, V.Undef, ((V)(36.2)), ((V)(46.4)), ((V)("#f3efe5")), ((V)("#6a665c"))));
if (NumTruthy(0D)) {
s_169.S("<g transform=\"translate(10.6 27.4)\"><circle cx=\"0.25\" cy=\"0.35\" r=\"1.3\" fill=\"#000000\" opacity=\"0.2\" filter=\"url(#wb1)\"/><circle r=\"1.2\" fill=\"#f3efe5\" stroke=\"#b9b3a2\" stroke-width=\"0.1\"/><circle r=\"0.78\" fill=\"#2d3b3f\"/><circle r=\"0.78\" fill=\"none\" stroke=\"#f0a64a\" stroke-width=\"0.14\" stroke-dasharray=\"1.5 3.4\"/><rect x=\"-0.34\" y=\"-0.16\" width=\"0.68\" height=\"0.3\" rx=\"0.06\" fill=\"#8fe8c4\"/><circle cx=\"-0.35\" cy=\"-0.5\" r=\"0.3\" fill=\"#ffffff\" opacity=\"0.3\"/></g>");
}
return NewObj(5).Put("mat", ((V)(s_169.Str))).Put("sup", sup_170).Put("defs", ((V)("<pattern id=\"sgs\" width=\"1.5\" height=\"1.5\" patternUnits=\"userSpaceOnUse\"><circle cx=\"0.4\" cy=\"0.5\" r=\"0.2\" fill=\"#000000\" fill-opacity=\"0.06\"/><circle cx=\"1.1\" cy=\"1.1\" r=\"0.17\" fill=\"#ffffff\" fill-opacity=\"0.07\"/></pattern>"))).Put("board", ((V)("#f2eee3"))).Put("ro", NewObj(3).Put("top", ((V)(0.07))).Put("ao", ((V)(0.12))).Put("board", Add(Call(capBoard_44, V.Undef, ((V)("#f2eee3")), ((V)(1.4))), Call(scuffs_46, V.Undef, ((V)("sgb")), ((V)(8D)), ((V)("#c9c3b4")), ((V)("#ffffff"))))).V).V;
return default;
}, 0, "sSage", false);
sWain_49 = Fn((V _self173, int _argc174, V _a176, V _a177, V _a178, V _a179, V[] _rest175) => {
V UP_180 = default;
V PN_181 = default;
double CR_182 = 0;
double y0_183 = 0;
double y1_184 = 0;
V sup_185 = default;
JsStrBuf s_186 = null;
if (_self173.IsNullish) _self173 = GlobalV;
UP_180 = ((V)("#eee2c6"));
PN_181 = ((V)("#f2ede2"));
CR_182 = 31.2;
y0_183 = (CR_182 + 2.8);
y1_184 = (ToNum(BB_32) - 2.2);
sup_185 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect width=\"80\" height=\"56\" fill=\"", ToStr(UP_180), "\"/>")).V(Call(blot_30, V.Undef, ((V)("wn19")), ((V)(26D)), Arr(((V)("#f4ead2")), ((V)("#e5d8b8")), ((V)("#ebdfc2"))), ((V)(0.3)), ((V)(3D)))).End()));
s_186 = new JsStrBuf(JsStrBuf.Begin().V(sup_185).S(string.Concat("<rect y=\"", NumStr(CR_182), "\" width=\"80\" height=\"", NumStr((56D - CR_182)), "\" fill=\"", ToStr(PN_181), "\"/>")).End());
{
double i_187 = 0;
i_187 = 0D;
while (true) {
if (!((i_187 < 8D))) break;
double a_189 = 0;
double b_190 = 0;
double e_191 = 0;
a_189 = ((i_187 * 10D) + 1.7);
b_190 = ((i_187 * 10D) + 8.3);
e_191 = 0.55;
s_186.S(string.Concat("<rect x=\"", NumStr(a_189), "\" y=\"", NumStr(y0_183), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)((b_190 - a_189))))), "\" height=\"", ToStr(Call(f1_19, V.Undef, ((V)((y1_184 - y0_183))))), "\" fill=\"", ToStr(Call(shade_11, V.Undef, PN_181, ((V)(0.96)))), "\"/>")).S(string.Concat("<path d=\"M", NumStr(a_189), " ", NumStr(y0_183), "H", NumStr(b_190), "L", ToStr(Call(f1_19, V.Undef, ((V)((b_190 - e_191))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y0_183 + e_191))))), "H", ToStr(Call(f1_19, V.Undef, ((V)((a_189 + e_191))))), "Z\" fill=\"", ToStr(Call(shade_11, V.Undef, PN_181, ((V)(0.8)))), "\"/><path d=\"M", NumStr(a_189), " ", NumStr(y0_183), "V", ToStr(Call(f1_19, V.Undef, ((V)(y1_184)))), "L", ToStr(Call(f1_19, V.Undef, ((V)((a_189 + e_191))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y1_184 - e_191))))), "V", ToStr(Call(f1_19, V.Undef, ((V)((y0_183 + e_191))))), "Z\" fill=\"", ToStr(Call(shade_11, V.Undef, PN_181, ((V)(0.87)))), "\"/>")).S(string.Concat("<path d=\"M", NumStr(b_190), " ", NumStr(y0_183), "V", ToStr(Call(f1_19, V.Undef, ((V)(y1_184)))), "L", ToStr(Call(f1_19, V.Undef, ((V)((b_190 - e_191))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y1_184 - e_191))))), "V", ToStr(Call(f1_19, V.Undef, ((V)((y0_183 + e_191))))), "Z\" fill=\"#ffffff\" opacity=\"0.75\"/><path d=\"M", NumStr(a_189), " ", ToStr(Call(f1_19, V.Undef, ((V)(y1_184)))), "H", NumStr(b_190), "L", ToStr(Call(f1_19, V.Undef, ((V)((b_190 - e_191))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y1_184 - e_191))))), "H", ToStr(Call(f1_19, V.Undef, ((V)((a_189 + e_191))))), "Z\" fill=\"", ToStr(Call(shade_11, V.Undef, PN_181, ((V)(1.04)))), "\"/>")).S(string.Concat("<rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)((a_189 + e_191))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)((y0_183 + e_191))))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)(((b_190 - a_189) - (2D * e_191)))))), "\" height=\"1.6\" fill=\"#000000\" opacity=\"0.05\"/>"));
i_187++;
}
}
s_186.S(string.Concat("<rect y=\"", ToStr(Call(f1_19, V.Undef, ((V)((CR_182 + 1.6))))), "\" width=\"80\" height=\"1.1\" fill=\"#000000\" opacity=\"0.16\" filter=\"url(#wb1)\"/><rect y=\"", NumStr(CR_182), "\" width=\"80\" height=\"1.7\" fill=\"#f6f2ea\"/><rect y=\"", NumStr(CR_182), "\" width=\"80\" height=\"0.35\" fill=\"#ffffff\"/><rect y=\"", ToStr(Call(f1_19, V.Undef, ((V)((CR_182 + 0.8))))), "\" width=\"80\" height=\"0.18\" fill=\"", ToStr(Call(shade_11, V.Undef, PN_181, ((V)(0.82)))), "\"/><rect y=\"", ToStr(Call(f1_19, V.Undef, ((V)((CR_182 + 1.5))))), "\" width=\"80\" height=\"0.2\" fill=\"", ToStr(Call(shade_11, V.Undef, PN_181, ((V)(0.72)))), "\"/><rect y=\"", ToStr(Call(f1_19, V.Undef, ((V)((CR_182 - 0.5))))), "\" width=\"80\" height=\"0.5\" fill=\"#000000\" opacity=\"0.06\"/>"));
s_186.V(Call(outlet_31, V.Undef, ((V)(9.25)), ((V)(45.6)), ((V)("#f6f2ea")), ((V)("#6a665c"))));
return NewObj(4).Put("mat", ((V)(s_186.Str))).Put("sup", sup_185).Put("board", ((V)("#f1ece0"))).Put("ro", NewObj(3).Put("top", ((V)(0.07))).Put("ao", ((V)(0.12))).Put("board", Add(Call(capBoard_44, V.Undef, ((V)("#f1ece0")), ((V)(1.2))), Call(scuffs_46, V.Undef, ((V)("wnb")), ((V)(6D)), ((V)("#cfc8b8")), ((V)("#ffffff"))))).V).V;
return default;
}, 0, "sWain", false);
sHerr_50 = Fn((V _self192, int _argc193, V _a195, V _a196, V _a197, V _a198, V[] _rest194) => {
V R_199 = default;
V PC_200 = default;
V ds_201 = default;
JsStrBuf gr_202 = null;
V s_203 = default;
JsStrBuf m_204 = null;
V Q_205 = default;
if (_self192.IsNullish) _self192 = GlobalV;
R_199 = Call(rng_23, V.Undef, ((V)("hb19")));
PC_200 = Arr(((V)("#b98a58")), ((V)("#a87a4a")), ((V)("#c69866")), ((V)("#9c6f42")), ((V)("#b48252")), ((V)("#cfa574")));
ds_201 = Invoke(PC_200, "map", Fn((V _arrowThis212, int _argc206, V _a208, V _a209, V _a210, V _a211, V[] _rest207) => {
return ((V)(""));
}, 0, "", true));
gr_202 = new JsStrBuf("");
{
double c_213 = 0;
c_213 = 0D;
while (true) {
if (!((c_213 < 10D))) break;
{
double r_215 = 0;
r_215 = (-3D);
while (true) {
if (!((r_215 < 29D))) break;
double x_217 = 0;
double y_218 = 0;
double j_219 = 0;
x_217 = (c_213 * 8D);
y_218 = (r_215 * 2D);
OpSetK(ds_201, ((V)(System.Math.Floor((ToNum(Call(R_199, V.Undef)) * 6D)))), 0, ((V)(string.Concat("M", NumStr(x_217), " ", NumStr((y_218 + 4D)), "L", NumStr((x_217 + 4D)), " ", NumStr(y_218), "V", NumStr((y_218 + 2D)), "L", NumStr(x_217), " ", NumStr((y_218 + 6D)), "Z"))));
OpSetK(ds_201, ((V)(System.Math.Floor((ToNum(Call(R_199, V.Undef)) * 6D)))), 0, ((V)(string.Concat("M", NumStr((x_217 + 4D)), " ", NumStr(y_218), "L", NumStr((x_217 + 8D)), " ", NumStr((y_218 + 4D)), "V", NumStr((y_218 + 6D)), "L", NumStr((x_217 + 4D)), " ", NumStr((y_218 + 2D)), "Z"))));
j_219 = (ToNum(Call(R_199, V.Undef)) * 0.5);
gr_202.S(string.Concat("M", ToStr(Call(f1_19, V.Undef, ((V)(((x_217 + 0.5) + j_219))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(((y_218 + 4.5) - j_219))))), "L", ToStr(Call(f1_19, V.Undef, ((V)((x_217 + 3.3))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y_218 + 1.7))))), "M", ToStr(Call(f1_19, V.Undef, ((V)((x_217 + 4.7))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(((y_218 + 1.4) + j_219))))), "L", ToStr(Call(f1_19, V.Undef, ((V)(((x_217 + 7.4) - j_219))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y_218 + 4.1)))))));
r_215++;
}
}
c_213++;
}
}
s_203 = ((V)(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#3a2414\"/>").V(Invoke(Invoke(ds_201, "map", Fn((V _arrowThis228, int _argc220, V d_226, V i_227, V _a224, V _a225, V[] _rest221) => {
return ((V)(string.Concat("<path d=\"", ToStr(d_226), "\" fill=\"", ToStr(GetK(PC_200, i_227)), "\" stroke=\"#4a2c16\" stroke-width=\"0.16\" stroke-opacity=\"0.75\"/>")));
}, 2, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"", gr_202.Str, "\" stroke=\"#6a4224\" stroke-width=\"0.12\" opacity=\"0.32\" fill=\"none\"/>")).V(Invoke(Call(rep_21, V.Undef, ((V)(10D)), Fn((V _arrowThis236, int _argc229, V c_235, V _a232, V _a233, V _a234, V[] _rest230) => {
return ((V)(string.Concat("<path d=\"M", NumStr(((ToNum(c_235) * 8D) + 4D)), " 0V56\" stroke=\"#2a1608\" stroke-width=\"0.14\" opacity=\"0.35\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("<rect width=\"80\" height=\"56\" fill=\"url(#hbg)\"/>").V(Call(blot_30, V.Undef, ((V)("hb19")), ((V)(18D)), Arr(((V)("#ffe0b0")), ((V)("#5a3418"))), ((V)(0.12)), ((V)(5D)))).End()));
m_204 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#dcd3c3\"/>").V(Call(blot_30, V.Undef, ((V)("lw19")), ((V)(26D)), Arr(((V)("#e9e2d6")), ((V)("#cbc0ad")), ((V)("#d6ccbb")), ((V)("#ece6db"))), ((V)(0.55)), ((V)(6D)))).End());
Q_205 = Call(rng_23, V.Undef, ((V)("lwb")));
m_204.S("<g filter=\"url(#wb1)\">").V(Invoke(Call(rep_21, V.Undef, ((V)(26D)), Fn((V _arrowThis243, int _argc237, V _a239, V _a240, V _a241, V _a242, V[] _rest238) => {
double x_244 = 0;
double y_245 = 0;
double l_246 = 0;
double b_247 = 0;
x_244 = (4D + (ToNum(Call(Q_205, V.Undef)) * 72D));
y_245 = (4D + (ToNum(Call(Q_205, V.Undef)) * 46D));
l_246 = (4D + (ToNum(Call(Q_205, V.Undef)) * 8D));
b_247 = ((ToNum(Call(Q_205, V.Undef)) - 0.5) * 4D);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)(x_244)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(y_245)))), "q", ToStr(Call(f1_19, V.Undef, ((V)((l_246 / 2D))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(b_247)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(l_246)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(((ToNum(Call(Q_205, V.Undef)) - 0.5) * 2D))))), "\" stroke=\"", (LtN(Call(Q_205, V.Undef), 0.5) ? "#f2ede4" : "#c2b6a2"), "\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((0.8 + (ToNum(Call(Q_205, V.Undef)) * 1.2)))))), "\" stroke-linecap=\"round\" fill=\"none\" opacity=\"0.4\"/>")));
return default;
}, 0, "", true)), "join", ((V)("")))).S("</g>");
return NewObj(5).Put("mat", s_203).Put("smat", ((V)(m_204.Str))).Put("defs", ((V)("<linearGradient id=\"hbg\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.1\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.1\"/></linearGradient>"))).Put("board", ((V)("#3d2a1c"))).Put("ro", NewObj(3).Put("top", ((V)(0.05))).Put("ao", ((V)(0.12))).Put("board", ((V)(string.Concat("<rect y=\"", ToStr(BB_32), "\" width=\"80\" height=\"0.35\" fill=\"#1a110a\"/>")))).V).V;
return default;
}, 0, "sHerr", false);
sMarb_51 = Fn((V _self248, int _argc249, V _a251, V _a252, V _a253, V _a254, V[] _rest250) => {
V R_255 = default;
V wav_256 = default;
JsStrBuf v_257 = null;
V main_258 = default;
V slab_259 = default;
JsStrBuf s_260 = null;
if (_self248.IsNullish) _self248 = GlobalV;
R_255 = Call(rng_23, V.Undef, ((V)("mv19")));
wav_256 = Fn((V _arrowThis274, int _argc261, V x0_267, V a_268, V p1_269, V b_270, V[] _rest262) => {
V p2_271 = default;
V c_272 = default;
V p3_273 = default;
p2_271 = (_argc261 > 4 ? _rest262[0] : V.Undef);
c_272 = (_argc261 > 5 ? _rest262[1] : V.Undef);
p3_273 = (_argc261 > 6 ? _rest262[2] : V.Undef);
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Call(rep_21, V.Undef, ((V)(30D)), Fn((V _arrowThis282, int _argc275, V j_281, V _a278, V _a279, V _a280, V[] _rest276) => {
double y_283 = 0;
y_283 = ((-2D) + (ToNum(j_281) * 2D));
return ((V)(JsStrBuf.Begin().V(Call(f1_19, V.Undef, Add(Add(Add(x0_267, ((V)((ToNum(a_268) * FdLibm.Sin(ToNum(Add(((V)((((2D * PI_14) * y_283) / 56D))), p1_269))))))), ((V)((ToNum(b_270) * FdLibm.Sin(ToNum(Add(((V)((((4D * PI_14) * y_283) / 56D))), p2_271))))))), ((V)((ToNum(c_272) * FdLibm.Sin(ToNum(Add(((V)((((6D * PI_14) * y_283) / 56D))), p3_273))))))))).S(" ").N(y_283).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()));
}, 7, "", true);
v_257 = new JsStrBuf(JsStrBuf.Begin().S("<g filter=\"url(#wb2)\">").V(Invoke(Invoke(Arr(Arr(((V)(12D)), ((V)(6D)), ((V)(0.4)), ((V)(3D)), ((V)(1.2)), ((V)(1D)), ((V)(2D))), Arr(((V)(28D)), ((V)(5D)), ((V)(2.4)), ((V)(2D)), ((V)(0.3)), ((V)(1.2)), ((V)(1D)))), "map", Fn((V _arrowThis291, int _argc284, V p_290, V _a287, V _a288, V _a289, V[] _rest285) => {
return ((V)(string.Concat("<path d=\"", ToStr(CallSpread(wav_256, V.Undef, new ArrBuilder().Spread(p_290).V)), "\" stroke=\"#c9c4bc\" stroke-width=\"3.4\" fill=\"none\" opacity=\"0.18\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("</g>").End());
main_258 = Arr(Arr(((V)(10D)), ((V)(7D)), ((V)(0.3)), ((V)(3D)), ((V)(1.1)), ((V)(1.2)), ((V)(2.2))), Arr(((V)(24D)), ((V)(6D)), ((V)(2.2)), ((V)(2.4)), ((V)(0.4)), ((V)(1.4)), ((V)(1D))), Arr(((V)(33D)), ((V)(3D)), ((V)(4D)), ((V)(1.6)), ((V)(2D)), ((V)(0.8)), ((V)(0.2))));
v_257.S("<g filter=\"url(#wb1)\">").V(Invoke(Invoke(main_258, "map", Fn((V _arrowThis299, int _argc292, V p_298, V _a295, V _a296, V _a297, V[] _rest293) => {
return ((V)(string.Concat("<path d=\"", ToStr(CallSpread(wav_256, V.Undef, new ArrBuilder().Spread(p_298).V)), "\" stroke=\"#b4aea4\" stroke-width=\"1\" fill=\"none\" opacity=\"0.28\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("</g>").V(Invoke(Invoke(main_258, "map", Fn((V _arrowThis307, int _argc300, V p_306, V _a303, V _a304, V _a305, V[] _rest301) => {
return ((V)(string.Concat("<path d=\"", ToStr(CallSpread(wav_256, V.Undef, new ArrBuilder().Spread(p_306).V)), "\" stroke=\"#9a948a\" stroke-width=\"0.3\" fill=\"none\" opacity=\"0.6\"/>")));
}, 1, "", true)), "join", ((V)(""))));
v_257.V(Invoke(Call(rep_21, V.Undef, ((V)(7D)), Fn((V _arrowThis314, int _argc308, V _a310, V _a311, V _a312, V _a313, V[] _rest309) => {
double x_315 = 0;
double y_316 = 0;
double l_317 = 0;
double a_318 = 0;
x_315 = (3D + (ToNum(Call(R_255, V.Undef)) * 34D));
y_316 = (ToNum(Call(R_255, V.Undef)) * 50D);
l_317 = (3D + (ToNum(Call(R_255, V.Undef)) * 6D));
a_318 = ((ToNum(Call(R_255, V.Undef)) - 0.5) * 2.4);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)(x_315)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(y_316)))), "q", ToStr(Call(f1_19, V.Undef, ((V)((l_317 * 0.4))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((l_317 * 0.5))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((l_317 * FdLibm.Sin(a_318)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(l_317)))), "\" stroke=\"#a8a297\" stroke-width=\"0.18\" fill=\"none\" opacity=\"0.6\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
v_257.V(Invoke(Call(rep_21, V.Undef, ((V)(4D)), Fn((V _arrowThis325, int _argc319, V _a321, V _a322, V _a323, V _a324, V[] _rest320) => {
return ((V)(string.Concat("<path d=\"", ToStr(Call(wav_256, V.Undef, ((V)((4D + (ToNum(Call(R_255, V.Undef)) * 32D)))), ((V)((2D + (ToNum(Call(R_255, V.Undef)) * 4D)))), ((V)((ToNum(Call(R_255, V.Undef)) * 6D))), Add(((V)(1D)), Call(R_255, V.Undef)), ((V)((ToNum(Call(R_255, V.Undef)) * 6D))), ((V)(0.5)), ((V)((ToNum(Call(R_255, V.Undef)) * 6D))))), "\" stroke=\"#d8cfa8\" stroke-width=\"0.12\" fill=\"none\" opacity=\"0.7\"/>")));
}, 0, "", true)), "join", ((V)(""))));
slab_259 = ((V)(string.Concat("<g clip-path=\"url(#mvc)\">", v_257.Str, "</g>")));
s_260 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#f2f0ec\"/>").V(Call(blot_30, V.Undef, ((V)("mv19")), ((V)(26D)), Arr(((V)("#f7f5f1")), ((V)("#e6e2dc")), ((V)("#eeebe6"))), ((V)(0.35)), ((V)(4D)))).End());
s_260.S("<rect x=\"0\" width=\"80\" height=\"56\" fill=\"url(#mvr)\"/>");
s_260.V(Invoke(Invoke(Arr(((V)(0D)), ((V)(40D)), ((V)(80D))), "map", Fn((V _arrowThis333, int _argc326, V x_332, V _a329, V _a330, V _a331, V[] _rest327) => {
return ((V)(string.Concat("<rect x=\"", NumStr((ToNum(x_332) - 0.38)), "\" width=\"0.76\" height=\"56\" fill=\"url(#mvb)\"/><rect x=\"", NumStr((ToNum(x_332) - 0.12)), "\" width=\"0.18\" height=\"56\" fill=\"#fff6d0\" opacity=\"0.8\"/>")));
}, 1, "", true)), "join", ((V)(""))));
return NewObj(4).Put("mat", ((V)(s_260.Str))).Put("defs", ((V)(string.Concat("<clipPath id=\"mvc\"><rect width=\"40\" height=\"56\"/></clipPath><linearGradient id=\"mvb\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8a6420\"/><stop offset=\"0.5\" stop-color=\"#f2d58a\"/><stop offset=\"1\" stop-color=\"#9a7228\"/></linearGradient>", "<linearGradient id=\"mvr\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0.2\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.3\" stop-color=\"#ffffff\" stop-opacity=\"0.16\"/><stop offset=\"0.36\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.7\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.76\" stop-color=\"#ffffff\" stop-opacity=\"0.12\"/><stop offset=\"0.8\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>", "<linearGradient id=\"mvs\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.38\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>")))).Put("board", ((V)("#b48a42"))).Put("ro", NewObj(3).Put("top", ((V)(0.05))).Put("ao", ((V)(0.1))).Put("board", ((V)(string.Concat("<rect y=\"", ToStr(BB_32), "\" width=\"80\" height=\"0.5\" fill=\"#f2d58a\"/><rect y=\"", ToStr(Call(f1_19, V.Undef, Add(BB_32, ((V)(0.9))))), "\" width=\"80\" height=\"0.25\" fill=\"#fff0b8\" opacity=\"0.6\"/>")))).V).V;
return default;
}, 0, "sMarb", false);
w12_69 = Fn((V _self334, int _argc335, V _a337, V _a338, V _a339, V _a340, V[] _rest336) => {
V FC_341 = default;
V R_342 = default;
JsStrBuf s_343 = null;
JsStrBuf sc_344 = null;
JsStrBuf bl_345 = null;
if (_self334.IsNullish) _self334 = GlobalV;
FC_341 = ((V)("#e7ddc6"));
R_342 = Call(rng_23, V.Undef, ((V)("w12")));
s_343 = new JsStrBuf(string.Concat("<defs>", ToStr(WDEF_60), "<linearGradient id=\"k\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#aebfca\"/><stop offset=\"1\" stop-color=\"#e3e8e2\"/></linearGradient><clipPath id=\"gc\"><rect x=\"-34.5\" y=\"9.5\" width=\"69\" height=\"51\"/></clipPath></defs>"));
s_343.S("<rect x=\"-43\" y=\"3\" width=\"88\" height=\"67\" fill=\"#000000\" opacity=\"0.2\" filter=\"url(#b2)\"/>").V(Call(ring_62, V.Undef, ((V)((-44D))), ((V)(1D)), ((V)(44D)), ((V)(66D)), ((V)(5D)), FC_341, ((V)(1.2)))).V(Call(reveal_63, V.Undef, ((V)((-39D))), ((V)(6D)), ((V)(39D)), ((V)(66D)), ((V)(2D)), ((V)("#cfc5ae"))));
sc_344 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-35\" y=\"8\" width=\"70\" height=\"54\" fill=\"url(#k)\"/>").V(Call(drift_66, V.Undef, Add(Call(cloud_65, V.Undef, ((V)((-20D))), ((V)(18D)), ((V)(1.2)), ((V)("#eef1f2"))), Call(cloud_65, V.Undef, ((V)(14D)), ((V)(14D)), ((V)(0.9)), ((V)("#e6eaec")))), ((V)(70D)), ((V)(46D)))).End());
sc_344.S("<path d=\"M-35 44L-26 38L-17 44V40H-8V44L2 36L12 44V39H20V44H35V62H-35Z\" fill=\"#8e99a5\"/><path d=\"M-35 50L-22 46L-12 50L0 47L14 51L35 48V62H-35Z\" fill=\"#7a8592\"/>").V(Invoke(Call(rep_21, V.Undef, ((V)(6D)), Fn((V _arrowThis353, int _argc346, V i_352, V _a349, V _a350, V _a351, V[] _rest347) => {
return ((V)(string.Concat("<rect x=\"", NumStr(((-31D) + (ToNum(i_352) * 11D))), "\" y=\"52\" width=\"2.2\" height=\"2.6\" fill=\"#f2d48a\" opacity=\"", NumStr((NumTruthy((ToNum(i_352) % 2D)) ? 0.8 : 0.3)), "\"/>")));
}, 1, "", true)), "join", ((V)(""))));
sc_344.S("<rect x=\"21\" y=\"18\" width=\"1.4\" height=\"44\" fill=\"#6a5a4a\"/><path d=\"M17 22H27\" stroke=\"#6a5a4a\" stroke-width=\"1\"/><path d=\"M-35 25Q-8 32 22 22Q30 20 35 23M-35 29Q-6 36 22 25\" stroke=\"#3a3a3e\" stroke-width=\"0.3\" fill=\"none\"/>");
sc_344.S(string.Concat("<g transform=\"translate(-6 30.2)\"><g>", ToStr(Call(at_17, V.Undef, ((V)("translate")), ((V)("0 0;0 -0.6;0 0;0 0")), ((V)(1.6)), ((V)(0D)), ((V)(" keyTimes=\"0;0.1;0.2;1\"")))), "<ellipse rx=\"1.4\" ry=\"1\" fill=\"#3a3330\"/><circle cx=\"1\" cy=\"-0.8\" r=\"0.7\" fill=\"#3a3330\"/><path d=\"M1.6 -0.8l0.8 0.2l-0.8 0.2Z\" fill=\"#e8a040\"/></g></g>"));
s_343.S(string.Concat("<g clip-path=\"url(#gc)\">", sc_344.Str, "<rect x=\"-35\" y=\"8\" width=\"70\" height=\"54\" fill=\"#d8cdb0\" opacity=\"0.12\"/>")).V(Call(glassRef_68, V.Undef, ((V)((-35D))), ((V)(8D)), ((V)(70D)), ((V)(54D)))).S("<path d=\"M-29 58L-21 50L-23 44L-15 36M-21 50L-11 52L-5 47M-23 44L-31 40M-15 36L-9 30\" stroke=\"#ffffff\" stroke-width=\"0.45\" fill=\"none\" opacity=\"0.85\"/><path d=\"M-28.6 58.4L-20.6 50.4L-22.6 44.4L-14.6 36.4\" stroke=\"#5a6470\" stroke-width=\"0.2\" fill=\"none\" opacity=\"0.5\"/>").S("<g transform=\"translate(-19 46) rotate(-42)\"><rect x=\"-9\" y=\"-1.8\" width=\"18\" height=\"3.6\" fill=\"#a7adb3\" opacity=\"0.92\"/><path d=\"M-9 -1.8V1.8M9 -1.8V1.8\" stroke=\"#7d848c\" stroke-width=\"0.3\" stroke-dasharray=\"0.4 0.4\"/><rect x=\"-8\" y=\"-1.2\" width=\"14\" height=\"0.6\" fill=\"#ffffff\" opacity=\"0.35\"/></g></g>");
s_343.V(Call(ring_62, V.Undef, ((V)((-37D))), ((V)(7.5)), ((V)(37D)), ((V)(62.5)), ((V)(2.6)), FC_341, ((V)(0.8))));
s_343.V(Invoke(Call(rep_21, V.Undef, ((V)(14D)), Fn((V _arrowThis360, int _argc354, V _a356, V _a357, V _a358, V _a359, V[] _rest355) => {
double x_361 = 0;
double y_362 = 0;
x_361 = ((-43D) + (ToNum(Call(R_342, V.Undef)) * 86D));
y_362 = (LtN(Call(R_342, V.Undef), 0.5) ? (2D + (ToNum(Call(R_342, V.Undef)) * 3.5)) : (61.5 + (ToNum(Call(R_342, V.Undef)) * 3.5)));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)(x_361)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(y_362)))), "l", ToStr(Call(f1_19, V.Undef, Add(((V)(0.6)), Call(R_342, V.Undef)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(0.2)))), "l-0.2 ", ToStr(Call(f1_19, V.Undef, ((V)((0.7 + (ToNum(Call(R_342, V.Undef)) * 0.5)))))), "l", ToStr(Call(f1_19, V.Undef, ((V)(((-0.8) - ToNum(Call(R_342, V.Undef))))))), " -0.2Z\" fill=\"#a98a5e\" opacity=\"0.8\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
bl_345 = new JsStrBuf("<path d=\"M-24 10V48M0 10V48M24 10V48\" stroke=\"#d6cdb8\" stroke-width=\"0.3\"/>");
{
double i_363 = 0;
i_363 = 0D;
while (true) {
if (!((i_363 < 14D))) break;
double y_365 = 0;
V d_366 = default;
y_365 = (11.2 + (i_363 * 2.6));
if ((i_363 == 11D)) {
goto _cont364;
}
d_366 = ((V)(((i_363 == 5D) ? string.Concat("M-34.5 ", NumStr(y_365), "H-6L-2 ", NumStr((y_365 + 1.6)), "L2 ", NumStr((y_365 + 0.3)), "H34.5V", NumStr((y_365 + 2D)), "H2L-2 ", NumStr((y_365 + 3.5)), "L-6 ", NumStr((y_365 + 1.9)), "H-34.5Z") : ((i_363 == 8D) ? string.Concat("M-34.5 ", NumStr(y_365), "L34.5 ", NumStr((y_365 + 1.4)), "V", NumStr((y_365 + 3.3)), "L-34.5 ", NumStr((y_365 + 1.9)), "Z") : string.Concat("M-34.5 ", NumStr(y_365), "H34.5V", NumStr((y_365 + 1.9)), "H-34.5Z")))));
bl_345.S(string.Concat("<path d=\"", ToStr(d_366), "\" fill=\"#efe9d8\"/><path d=\"M-34.5 ", NumStr((y_365 + 0.15)), "H34.5\" stroke=\"#ffffff\" stroke-width=\"0.25\" opacity=\"0.8\"/><path d=\"", ToStr(d_366), "\" fill=\"none\" stroke=\"#b9b09a\" stroke-width=\"0.18\"/>"));
_cont364: ;
i_363++;
}
}
s_343.S(bl_345.Str).V(Call(bev_61, V.Undef, ((V)((-35.5))), ((V)(8.6)), ((V)(71D)), ((V)(2.8)), ((V)("#ebe5d4")), ((V)(0.5)))).S(string.Concat("<g>", ToStr(Call(at_17, V.Undef, ((V)("rotate")), ((V)("-2.6 -34 48;-1.6 -34 48;-2.6 -34 48")), ((V)(3.6)), ((V)(0D)), Call(SPL_18, V.Undef, ((V)(2D))))), ToStr(Call(bev_61, V.Undef, ((V)((-35D))), ((V)(47.6)), ((V)(70D)), ((V)(2.4)), ((V)("#e4ddca")), ((V)(0.5)))), "</g>"));
s_343.S("<path d=\"M32.5 10.6V58\" stroke=\"#e8e2d2\" stroke-width=\"0.5\"/><path d=\"M32.5 58l-0.9 2.8h1.8Z\" fill=\"#e0d8c2\" stroke=\"#b9b09a\" stroke-width=\"0.15\"/><path d=\"M-32 10.6V30\" stroke=\"#cfc6b0\" stroke-width=\"0.8\" stroke-linecap=\"round\"/>");
s_343.V(Add(Call(sill_64, V.Undef, ((V)((-47D))), ((V)(47D)), ((V)(66D)), ((V)("#ddd2b9")), ((V)(2D))), Call(bev_61, V.Undef, ((V)((-40D))), ((V)(69D)), ((V)(80D)), ((V)(4D)), ((V)("#ddd2b9")), ((V)(0.6)))));
return NewObj(2).Put("vb", Arr(((V)((-48D))), ((V)(0D)), ((V)(96D)), ((V)(75D)))).Put("s", ((V)(s_343.Str))).V;
return default;
}, 0, "w12", false);
w32_70 = Fn((V _self367, int _argc368, V _a370, V _a371, V _a372, V _a373, V[] _rest369) => {
V FC_374 = default;
JsStrBuf s_375 = null;
JsStrBuf sc_376 = null;
JsStrBuf sh_377 = null;
if (_self367.IsNullish) _self367 = GlobalV;
FC_374 = ((V)("#f6f2ea"));
s_375 = new JsStrBuf(string.Concat(string.Concat("<defs>", ToStr(WDEF_60), "<linearGradient id=\"k\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#7fbbe8\"/><stop offset=\"1\" stop-color=\"#d6eefa\"/></linearGradient><radialGradient id=\"sun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff8d0\"/><stop offset=\"0.35\" stop-color=\"#fff0a0\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#fff0a0\" stop-opacity=\"0\"/></radialGradient>"), "<linearGradient id=\"fd\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#f6eedd\"/><stop offset=\"0.7\" stop-color=\"#e6dbc4\"/><stop offset=\"1\" stop-color=\"#c9bb9e\"/></linearGradient><pattern id=\"ln\" width=\"2\" height=\"0.7\" patternUnits=\"userSpaceOnUse\"><rect width=\"2\" height=\"0.18\" fill=\"#8a7a5a\" fill-opacity=\"0.12\"/></pattern><clipPath id=\"gc\"><rect x=\"-36.6\" y=\"-4.6\" width=\"73.2\" height=\"76.6\"/></clipPath></defs>"));
s_375.S("<rect x=\"-42\" y=\"-11\" width=\"88\" height=\"90\" fill=\"#000000\" opacity=\"0.18\" filter=\"url(#b2)\"/>").V(Call(ring_62, V.Undef, ((V)((-43D))), ((V)((-11D))), ((V)(43D)), ((V)(74D)), ((V)(5D)), FC_374, ((V)(1.2)))).V(Call(bev_61, V.Undef, ((V)((-46D))), ((V)((-15D))), ((V)(92D)), ((V)(4.6)), FC_374, ((V)(0.8)))).S("<rect x=\"-43\" y=\"-10.4\" width=\"86\" height=\"0.8\" fill=\"#000000\" opacity=\"0.15\"/>").V(Call(reveal_63, V.Undef, ((V)((-38D))), ((V)((-6D))), ((V)(38D)), ((V)(74D)), ((V)(1.4)), ((V)("#e3ddd0"))));
sc_376 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-37\" y=\"-5\" width=\"74\" height=\"78\" fill=\"url(#k)\"/><circle cx=\"24\" cy=\"2\" r=\"16\" fill=\"url(#sun)\"/><circle cx=\"24\" cy=\"2\" r=\"4.2\" fill=\"#fff6c8\"/>").V(Call(drift_66, V.Undef, Add(Call(cloud_65, V.Undef, ((V)((-18D))), ((V)(10D)), ((V)(1D)), ((V)("#ffffff"))), Call(cloud_65, V.Undef, ((V)(16D)), ((V)(20D)), ((V)(0.8)), ((V)("#ffffff")))), ((V)(74D)), ((V)(52D)))).End());
sc_376.S("<path d=\"M-37 46Q-18 38 0 44T37 40V73H-37Z\" fill=\"#9cc79e\"/><path d=\"M-37 54Q-10 48 12 54T37 52V73H-37Z\" fill=\"#7fb07a\"/>").V(Call(tree_67, V.Undef, ((V)((-24D))), ((V)(60D)), ((V)(1.6)), ((V)("#5f9a4e")), ((V)(0D)))).V(Call(tree_67, V.Undef, ((V)(26D)), ((V)(56D)), ((V)(1.1)), ((V)("#6fa85a")), ((V)(1.3))));
sc_376.V(Invoke(Call(rep_21, V.Undef, ((V)(9D)), Fn((V _arrowThis385, int _argc378, V i_384, V _a381, V _a382, V _a383, V[] _rest379) => {
return ((V)(string.Concat("<rect x=\"", NumStr(((-36D) + (ToNum(i_384) * 8.6))), "\" y=\"60\" width=\"2.4\" height=\"13\" fill=\"#ffffff\"/><path d=\"M", NumStr(((-36D) + (ToNum(i_384) * 8.6))), " 60l1.2 -1.6l1.2 1.6\" fill=\"#ffffff\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("<rect x=\"-37\" y=\"63\" width=\"74\" height=\"1.4\" fill=\"#f2f2f2\"/><rect x=\"-37\" y=\"68\" width=\"74\" height=\"1.4\" fill=\"#f2f2f2\"/>");
s_375.S(string.Concat("<g clip-path=\"url(#gc)\">", sc_376.Str, ToStr(Call(glassRef_68, V.Undef, ((V)((-37D))), ((V)((-5D))), ((V)(74D)), ((V)(78D)))), "</g>"));
s_375.V(Add(Add(Add(Add(Call(ring_62, V.Undef, ((V)((-36.6))), ((V)((-4.6))), ((V)(36.6)), ((V)(34D)), ((V)(2.8)), FC_374, ((V)(0.7))), Call(bev_61, V.Undef, ((V)((-1D))), ((V)((-1.8))), ((V)(2D)), ((V)(33D)), FC_374, ((V)(0.4)))), Call(ring_62, V.Undef, ((V)((-36.6))), ((V)(31D)), ((V)(36.6)), ((V)(72D)), ((V)(2.8)), FC_374, ((V)(0.7)))), Call(bev_61, V.Undef, ((V)((-1D))), ((V)(33.8)), ((V)(2D)), ((V)(35.4)), FC_374, ((V)(0.4)))), Call(bev_61, V.Undef, ((V)((-36.6))), ((V)(30.8)), ((V)(73.2)), ((V)(3.4)), Call(shade_11, V.Undef, FC_374, ((V)(0.98))), ((V)(0.6)))));
s_375.S("<g transform=\"translate(0 32.4)\"><ellipse rx=\"3\" ry=\"1.1\" fill=\"#b8892e\"/><path d=\"M-2.2 -0.4Q0 -2.4 2.6 -1\" stroke=\"#e8c062\" stroke-width=\"0.8\" fill=\"none\" stroke-linecap=\"round\"/><circle cx=\"2.6\" cy=\"-1\" r=\"0.7\" fill=\"#f2d07a\"/></g>");
Invoke(Arr(((V)((-20D))), ((V)(20D))), "forEach", Fn((V _arrowThis393, int _argc386, V x_392, V _a389, V _a390, V _a391, V[] _rest387) => {
return ((V)(s_375.S(string.Concat("<path d=\"M", NumStr((ToNum(x_392) - 2.4)), " 70.4Q", ToStr(x_392), " 73.4 ", ToStr(Add(x_392, ((V)(2.4)))), " 70.4\" stroke=\"#c99a3e\" stroke-width=\"0.7\" fill=\"none\"/>")).Str));
}, 1, "", true));
sh_377 = new JsStrBuf("<rect x=\"-36.6\" y=\"-4.6\" width=\"73.2\" height=\"6\" fill=\"url(#fd)\"/>");
Invoke(Arr(Arr(((V)(1.4)), ((V)(6.8))), Arr(((V)(6.8)), ((V)(12.2))), Arr(((V)(12.2)), ((V)(17.6)))), "forEach", Fn((V _arrowThis405, int _argc394, V _a396, V _a397, V _a398, V _a399, V[] _rest395) => {
V a_402 = default;
V b_404 = default;
{ V _t400 = ListOf(_a396);
{ V _t401 = GetIdx(_t400, 0D);
a_402 = _t401; }
{ V _t403 = GetIdx(_t400, 1D);
b_404 = _t403; }
}
return ((V)(sh_377.S(string.Concat("<path d=\"M-37.2 ", ToStr(a_402), "H37.2Q37.8 ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Add(a_402, b_404)) / 2D))))), " 37.2 ", ToStr(b_404), "H-37.2Q-37.8 ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Add(a_402, b_404)) / 2D))))), " -37.2 ", ToStr(a_402), "Z\" fill=\"url(#fd)\"/><path d=\"M-37.2 ", ToStr(b_404), "H37.2\" stroke=\"#a89878\" stroke-width=\"0.3\"/><path d=\"M-36 ", ToStr(Call(f1_19, V.Undef, Add(a_402, ((V)(0.6))))), "H36\" stroke=\"#ffffff\" stroke-width=\"0.35\" opacity=\"0.6\"/>")).Str));
}, 1, "", true));
sh_377.S("<rect x=\"-37\" y=\"17.4\" width=\"74\" height=\"1.6\" rx=\"0.6\" fill=\"#e2d7bf\"/><rect x=\"-36.6\" y=\"-4.6\" width=\"73.2\" height=\"23.6\" fill=\"url(#ln)\"/>");
s_375.S(string.Concat("<rect x=\"-37\" y=\"18.6\" width=\"74\" height=\"2\" fill=\"#000000\" opacity=\"0.14\" filter=\"url(#b1)\"/>", sh_377.Str));
s_375.S("<path d=\"M35 19V41Q35 43 38 43.4L41.2 44\" stroke=\"#efe8d8\" stroke-width=\"0.45\" fill=\"none\"/><rect x=\"40.4\" y=\"42.4\" width=\"1.6\" height=\"3.6\" rx=\"0.4\" fill=\"#c99a3e\"/><path d=\"M41.2 44.4l1.6 2.2\" stroke=\"#efe8d8\" stroke-width=\"0.45\"/>");
s_375.V(Add(Call(sill_64, V.Undef, ((V)((-47D))), ((V)(47D)), ((V)(74D)), ((V)("#f1ece0")), ((V)(2D))), Call(bev_61, V.Undef, ((V)((-39D))), ((V)(77D)), ((V)(78D)), ((V)(5D)), FC_374, ((V)(0.7)))));
return NewObj(2).Put("vb", Arr(((V)((-48D))), ((V)((-16D))), ((V)(96D)), ((V)(99D)))).Put("s", ((V)(s_375.Str))).V;
return default;
}, 0, "w32", false);
w52_71 = Fn((V _self406, int _argc407, V _a409, V _a410, V _a411, V _a412, V[] _rest408) => {
V FC_413 = default;
V O_414 = default;
double cpX_415 = 0;
double cpT_416 = 0;
double cpB_417 = 0;
V L_418 = default;
V Rr_419 = default;
V quad_420 = default;
JsStrBuf s_421 = null;
JsStrBuf sc_422 = null;
V drape_423 = default;
if (_self406.IsNullish) _self406 = GlobalV;
FC_413 = ((V)("#f4f0e8"));
O_414 = Arr(((V)((-82D))), ((V)((-40D))), ((V)(82D)), ((V)(98D)));
cpX_415 = 44D;
cpT_416 = (-30D);
cpB_417 = 86D;
L_418 = Fn((V _arrowThis432, int _argc424, V u_430, V v_431, V _a428, V _a429, V[] _rest425) => {
return Arr(((V)(((-82D) + (38D * ToNum(u_430))))), ((V)((((-40D) + (10D * ToNum(u_430))) + (ToNum(v_431) * ((98D - (12D * ToNum(u_430))) - ((-40D) + (10D * ToNum(u_430)))))))));
}, 2, "", true);
Rr_419 = Fn((V _arrowThis441, int _argc433, V u_439, V v_440, V _a437, V _a438, V[] _rest434) => {
V p_442 = default;
p_442 = Call(L_418, V.Undef, u_439, v_440);
return Arr(((V)((-ToNum(GetIdx(p_442, 0D))))), GetIdx(p_442, 1D));
return default;
}, 2, "", true);
quad_420 = Fn((V _arrowThis456, int _argc443, V F_449, V u0_450, V u1_451, V v0_452, V[] _rest444) => {
V v1_453 = default;
V c_454 = default;
V o_455 = default;
v1_453 = (_argc443 > 4 ? _rest444[0] : V.Undef);
c_454 = (_argc443 > 5 ? _rest444[1] : V.Undef);
o_455 = (_argc443 > 6 ? _rest444[2] : V.Undef);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, Call(F_449, V.Undef, u0_450, v0_452))), "L", ToStr(Call(P2_22, V.Undef, Call(F_449, V.Undef, u1_451, v0_452))), "L", ToStr(Call(P2_22, V.Undef, Call(F_449, V.Undef, u1_451, v1_453))), "L", ToStr(Call(P2_22, V.Undef, Call(F_449, V.Undef, u0_450, v1_453))), "Z\" fill=\"", ToStr(c_454), "\"", (Truthy(o_455) ? string.Concat(" opacity=\"", ToStr(o_455), "\"") : ""), "/>")));
}, 7, "", true);
s_421 = new JsStrBuf(string.Concat(string.Concat("<defs>", ToStr(WDEF_60), "<linearGradient id=\"k\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#6fb2e6\"/><stop offset=\"0.6\" stop-color=\"#bfe2f6\"/><stop offset=\"1\" stop-color=\"#e8f5fa\"/></linearGradient><radialGradient id=\"sun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff8d0\"/><stop offset=\"0.35\" stop-color=\"#fff0a0\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#fff0a0\" stop-opacity=\"0\"/></radialGradient>"), "<linearGradient id=\"dr\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#d9cfbc\"/><stop offset=\"0.5\" stop-color=\"#f4ede0\"/><stop offset=\"1\" stop-color=\"#cfc4ae\"/></linearGradient><linearGradient id=\"cl\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#d6cfc0\"/><stop offset=\"1\" stop-color=\"#ece6da\"/></linearGradient></defs>"));
s_421.S("<rect x=\"-84\" y=\"-42\" width=\"170\" height=\"142\" fill=\"#000000\" opacity=\"0.14\" filter=\"url(#b2)\"/>");
sc_422 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-82\" y=\"-40\" width=\"164\" height=\"138\" fill=\"url(#k)\"/><circle cx=\"54\" cy=\"-20\" r=\"26\" fill=\"url(#sun)\"/><circle cx=\"54\" cy=\"-20\" r=\"5.4\" fill=\"#fff6c8\"/>").V(Call(drift_66, V.Undef, Add(Add(Call(cloud_65, V.Undef, ((V)((-50D))), ((V)((-18D))), ((V)(1.3)), ((V)("#ffffff"))), Call(cloud_65, V.Undef, ((V)(4D)), ((V)((-26D))), ((V)(1D)), ((V)("#ffffff")))), Call(cloud_65, V.Undef, ((V)(40D)), ((V)(0D)), ((V)(0.8)), ((V)("#ffffff")))), ((V)(164D)), ((V)(70D)))).End());
sc_422.S("<path d=\"M-82 34Q-60 22 -36 30T10 26T50 30T82 24V98H-82Z\" fill=\"#8fbf8a\"/>").V(Invoke(Call(rep_21, V.Undef, ((V)(12D)), Fn((V _arrowThis464, int _argc457, V i_463, V _a460, V _a461, V _a462, V[] _rest458) => {
return Call(tree_67, V.Undef, ((V)(((-80D) + (ToNum(i_463) * 14.5)))), ((V)((34D - (ToNum(i_463) % 3D)))), ((V)((0.9 + ((ToNum(i_463) % 2D) * 0.25)))), GetIdx(Arr(((V)("#5f9a4e")), ((V)("#6aa65a")), ((V)("#548c46"))), (ToNum(i_463) % 3D)), ((V)((ToNum(i_463) * 0.4))));
}, 1, "", true)), "join", ((V)(""))));
sc_422.S("<path d=\"M-82 44Q0 38 82 44V98H-82Z\" fill=\"#9fd17e\"/>").V(Invoke(Call(rep_21, V.Undef, ((V)(8D)), Fn((V _arrowThis472, int _argc465, V i_471, V _a468, V _a469, V _a470, V[] _rest466) => {
return ((V)(string.Concat("<path d=\"M", NumStr(((-82D) + (ToNum(i_471) * 22D))), " 98L", NumStr(((-60D) + (ToNum(i_471) * 22D))), " 44H", NumStr(((-49D) + (ToNum(i_471) * 22D))), "L", NumStr(((-71D) + (ToNum(i_471) * 22D))), " 98Z\" fill=\"#ffffff\" opacity=\"0.06\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Call(tree_67, V.Undef, ((V)(58D)), ((V)(70D)), ((V)(2.6)), ((V)("#5a9448")), ((V)(0.8))));
sc_422.V(Invoke(Call(rep_21, V.Undef, ((V)(16D)), Fn((V _arrowThis480, int _argc473, V i_479, V _a476, V _a477, V _a478, V[] _rest474) => {
return ((V)(string.Concat("<circle cx=\"", NumStr(((-64D) + (ToNum(i_479) * 8D))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((76D + ((ToNum(i_479) % 3D) * 1.6)))))), "\" r=\"1.5\" fill=\"", ToStr(GetIdx(Arr(((V)("#ef8f7f")), ((V)("#f2c94c")), ((V)("#ffffff")), ((V)("#b9a6e0"))), (ToNum(i_479) % 4D))), "\"/><circle cx=\"", NumStr(((-64D) + (ToNum(i_479) * 8D))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((78.4 + ((ToNum(i_479) % 3D) * 1.6)))))), "\" r=\"1.2\" fill=\"#4f8a3e\"/>")));
}, 1, "", true)), "join", ((V)(""))));
s_421.S(sc_422.Str).V(Call(glassRef_68, V.Undef, ((V)((-82D))), ((V)((-40D))), ((V)(164D)), ((V)(138D))));
s_421.S("<path d=\"M-82 -40H82L44 -30H-44Z\" fill=\"url(#cl)\"/><path d=\"M-44 -30H44\" stroke=\"#bdb4a2\" stroke-width=\"0.4\"/>");
s_421.S("<path d=\"M-82 98H82L44 86H-44Z\" fill=\"#c4976a\"/>").V(Invoke(Call(rep_21, V.Undef, ((V)(9D)), Fn((V _arrowThis488, int _argc481, V i_487, V _a484, V _a485, V _a486, V[] _rest482) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)(((-82D) + (ToNum(i_487) * 20.5)))))), " 98L", ToStr(Call(f1_19, V.Undef, ((V)(((-44D) + (ToNum(i_487) * 11D)))))), " 86\" stroke=\"#9a7048\" stroke-width=\"0.3\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M-44 86H44\" stroke=\"#8a6440\" stroke-width=\"0.5\"/>");
s_421.S(string.Concat("<g>", ToStr(Call(an_16, V.Undef, ((V)("opacity")), ((V)("0.5;0.75;0.5")), ((V)(6D)), ((V)(0D)), Call(SPL_18, V.Undef, ((V)(2D))))), "<path d=\"M-20 97L-8 87H14L4 97Z\" fill=\"#fff4cc\" opacity=\"0.5\"/><path d=\"M14 97L22 87H36L32 97Z\" fill=\"#fff4cc\" opacity=\"0.4\"/></g>"));
Invoke(Arr(Arr(L_418, ((V)(0.9))), Arr(Rr_419, ((V)(1.06)))), "forEach", Fn((V _arrowThis500, int _argc489, V _a491, V _a492, V _a493, V _a494, V[] _rest490) => {
V c_501 = default;
V F_497 = default;
V k_499 = default;
{ V _t495 = ListOf(_a491);
{ V _t496 = GetIdx(_t495, 0D);
F_497 = _t496; }
{ V _t498 = GetIdx(_t495, 1D);
k_499 = _t498; }
}
c_501 = Call(shade_11, V.Undef, FC_413, k_499);
s_421.V(Add(Add(Add(Add(Add(Add(Call(quad_420, V.Undef, F_497, ((V)(0D)), ((V)(1D)), ((V)(0D)), ((V)(0.03)), c_501), Call(quad_420, V.Undef, F_497, ((V)(0D)), ((V)(1D)), ((V)(0.965)), ((V)(1D)), c_501)), Call(quad_420, V.Undef, F_497, ((V)(0D)), ((V)(0.05)), ((V)(0D)), ((V)(1D)), c_501)), Call(quad_420, V.Undef, F_497, ((V)(0.95)), ((V)(1D)), ((V)(0D)), ((V)(1D)), c_501)), Call(quad_420, V.Undef, F_497, ((V)(0.47)), ((V)(0.53)), ((V)(0D)), ((V)(1D)), c_501)), Call(quad_420, V.Undef, F_497, ((V)(0D)), ((V)(1D)), ((V)(0.2)), ((V)(0.215)), c_501)), Call(quad_420, V.Undef, F_497, ((V)(0D)), ((V)(1D)), ((V)(0.965)), ((V)(1D)), ((V)("#000000")), ((V)(0.12)))));
return default;
}, 1, "", true));
s_421.V(Add(Add(Call(ring_62, V.Undef, ((V)((-cpX_415))), ((V)(cpT_416)), ((V)(cpX_415)), ((V)(cpB_417)), ((V)(2.4)), FC_413, ((V)(0.5))), Call(bev_61, V.Undef, ((V)((-1.2))), ((V)((cpT_416 + 2.4))), ((V)(2.4)), ((V)(((cpB_417 - cpT_416) - 4.8))), FC_413, ((V)(0.4)))), Call(bev_61, V.Undef, ((V)(((-cpX_415) + 2.4))), ((V)((-6D))), ((V)(((2D * cpX_415) - 4.8))), ((V)(1.8)), FC_413, ((V)(0.4)))));
Invoke(Arr(((V)((-6D))), ((V)(6D))), "forEach", Fn((V _arrowThis509, int _argc502, V x_508, V _a505, V _a506, V _a507, V[] _rest503) => {
return ((V)(s_421.S(string.Concat("<rect x=\"", NumStr((ToNum(x_508) - 0.5)), "\" y=\"40\" width=\"1\" height=\"5\" rx=\"0.4\" fill=\"#c99a3e\"/>")).Str));
}, 1, "", true));
s_421.V(Call(ring_62, V.Undef, ((V)((-86D))), ((V)((-44D))), ((V)(86D)), ((V)(102D)), ((V)(4D)), FC_413, ((V)(1D)))).S("<rect x=\"-86\" y=\"98\" width=\"172\" height=\"4\" fill=\"#efe9dc\"/>");
s_421.S("<rect x=\"-100\" y=\"-48.4\" width=\"200\" height=\"2.6\" rx=\"1.3\" fill=\"url(#br19)\"/><circle cx=\"-100\" cy=\"-47.1\" r=\"2.4\" fill=\"#e2b456\" stroke=\"#8a6420\" stroke-width=\"0.3\"/><circle cx=\"100\" cy=\"-47.1\" r=\"2.4\" fill=\"#e2b456\" stroke=\"#8a6420\" stroke-width=\"0.3\"/>");
drape_423 = Fn((V _arrowThis519, int _argc510, V x0_516, V w_517, V sg_518, V _a515, V[] _rest511) => {
double pl_520 = 0;
JsStrBuf d_521 = null;
pl_520 = 6D;
d_521 = new JsStrBuf(string.Concat("<g>", ToStr(Call(at_17, V.Undef, ((V)("rotate")), ((V)(string.Concat("0 ", ToStr(Add(x0_516, ((V)((ToNum(w_517) / 2D))))), " -46;", NumStr((ToNum(sg_518) * 0.9)), " ", ToStr(Add(x0_516, ((V)((ToNum(w_517) / 2D))))), " -46;0 ", ToStr(Add(x0_516, ((V)((ToNum(w_517) / 2D))))), " -46"))), ((V)(7D)), ((V)(0D)), Call(SPL_18, V.Undef, ((V)(2D))))), "<path d=\"M", ToStr(x0_516), " -46H", ToStr(Add(x0_516, w_517)), "V100H", NumStr((ToNum(x0_516) - (ToNum(sg_518) * 1.6))), "Z\" fill=\"#000000\" opacity=\"0.15\" transform=\"translate(", NumStr((ToNum(sg_518) * 1.4)), " 1)\" filter=\"url(#b1)\"/><path d=\"M", ToStr(x0_516), " -46H", ToStr(Add(x0_516, w_517)), "L", ToStr(Add(Add(x0_516, w_517), ((V)((ToNum(sg_518) * 0.6))))), " 100H", NumStr((ToNum(x0_516) - (ToNum(sg_518) * 1.2))), "Z\" fill=\"#ede5d6\"/>"));
{
double i_522 = 0;
i_522 = 0D;
while (true) {
if (!((i_522 < pl_520))) break;
V a_524 = default;
V b_525 = default;
a_524 = Add(x0_516, ((V)(((i_522 * ToNum(w_517)) / pl_520))));
b_525 = Add(a_524, ((V)((ToNum(w_517) / pl_520))));
d_521.S(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, a_524)), " -46H", ToStr(Call(f1_19, V.Undef, b_525)), "L", ToStr(Call(f1_19, V.Undef, Add(Add(b_525, ((V)((ToNum(sg_518) * 0.3)))), ((V)(((i_522 - (pl_520 / 2D)) * 0.3)))))), " 100H", ToStr(Call(f1_19, V.Undef, Add(a_524, ((V)(((i_522 - (pl_520 / 2D)) * 0.3)))))), "Z\" fill=\"url(#dr)\" opacity=\"0.9\"/>"));
i_522++;
}
}
d_521.V(Invoke(Call(rep_21, V.Undef, ((V)((pl_520 + 1D))), Fn((V _arrowThis533, int _argc526, V i_532, V _a529, V _a530, V _a531, V[] _rest527) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_19, V.Undef, Add(x0_516, ((V)(((ToNum(i_532) * ToNum(w_517)) / pl_520)))))), "\" cy=\"-47\" r=\"1.2\" fill=\"none\" stroke=\"#b38432\" stroke-width=\"0.5\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<rect x=\"", NumStr((ToNum(x0_516) - 1D)), "\" y=\"96.6\" width=\"", ToStr(Add(w_517, ((V)(2D)))), "\" height=\"1.2\" fill=\"#d6ccb8\" opacity=\"0.8\"/></g>"));
return ((V)(d_521.Str));
return default;
}, 3, "", true);
s_421.V(Add(Call(drape_423, V.Undef, ((V)((-99D))), ((V)(24D)), ((V)((-1D)))), Call(drape_423, V.Undef, ((V)(75D)), ((V)(24D)), ((V)(1D)))));
return NewObj(2).Put("vb", Arr(((V)((-102D))), ((V)((-51D))), ((V)(204D)), ((V)(153D)))).Put("s", ((V)(s_421.Str))).V;
return default;
}, 0, "w52", false);
w72_72 = Fn((V _self534, int _argc535, V _a537, V _a538, V _a539, V _a540, V[] _rest536) => {
V FC_541 = default;
JsStrBuf s_542 = null;
JsStrBuf sc_543 = null;
V R_544 = default;
if (_self534.IsNullish) _self534 = GlobalV;
FC_541 = ((V)("#2a2c31"));
s_542 = new JsStrBuf(string.Concat(string.Concat("<defs>", ToStr(WDEF_60), "<linearGradient id=\"k\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#7cbbe8\"/><stop offset=\"0.65\" stop-color=\"#cfe6f2\"/><stop offset=\"1\" stop-color=\"#fbe2c0\"/></linearGradient><radialGradient id=\"sun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff8d0\"/><stop offset=\"0.35\" stop-color=\"#ffe7a0\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#ffe7a0\" stop-opacity=\"0\"/></radialGradient>"), "<linearGradient id=\"tn\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#1c2840\" stop-opacity=\"0.78\"/><stop offset=\"0.9\" stop-color=\"#2a3a58\" stop-opacity=\"0.62\"/><stop offset=\"1\" stop-color=\"#7fb8ff\" stop-opacity=\"0.5\"/></linearGradient><clipPath id=\"gc\"><rect x=\"-118\" y=\"-38\" width=\"236\" height=\"124\"/></clipPath></defs>"));
s_542.S("<rect x=\"-120\" y=\"-40\" width=\"244\" height=\"132\" fill=\"#000000\" opacity=\"0.16\" filter=\"url(#b2)\"/>").V(Call(reveal_63, V.Undef, ((V)((-121D))), ((V)((-41D))), ((V)(121D)), ((V)(87D)), ((V)(3D)), ((V)("#e8e4dc"))));
sc_543 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-118\" y=\"-38\" width=\"236\" height=\"124\" fill=\"url(#k)\"/><circle cx=\"80\" cy=\"-6\" r=\"30\" fill=\"url(#sun)\"/><circle cx=\"80\" cy=\"-6\" r=\"6\" fill=\"#fff4c8\"/>").V(Call(drift_66, V.Undef, Add(Add(Call(cloud_65, V.Undef, ((V)((-90D))), ((V)((-24D))), ((V)(1.3)), ((V)("#ffffff"))), Call(cloud_65, V.Undef, ((V)((-20D))), ((V)((-30D))), ((V)(1D)), ((V)("#ffffff")))), Call(cloud_65, V.Undef, ((V)(50D)), ((V)((-18D))), ((V)(0.9)), ((V)("#ffffff")))), ((V)(236D)), ((V)(90D)))).End());
sc_543.S("<path d=\"M-118 26L-90 8L-66 20L-40 2L-12 18L14 6L42 22L70 4L96 18L118 8V60H-118Z\" fill=\"#9db8d4\"/><path d=\"M-118 34L-80 22L-50 32L-20 20L20 32L60 22L118 32V60H-118Z\" fill=\"#82a2c2\"/>");
R_544 = Call(rng_23, V.Undef, ((V)("w72")));
sc_543.V(Invoke(Call(rep_21, V.Undef, ((V)(30D)), Fn((V _arrowThis552, int _argc545, V i_551, V _a548, V _a549, V _a550, V[] _rest546) => {
double x_553 = 0;
double h_554 = 0;
double w_555 = 0;
x_553 = ((-116D) + (ToNum(i_551) * 7.9));
h_554 = (8D + (ToNum(Call(R_544, V.Undef)) * 22D));
w_555 = (4D + (ToNum(Call(R_544, V.Undef)) * 3.4));
return ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)(x_553)))), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)((52D - h_554))))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)(w_555)))), "\" height=\"", ToStr(Call(f1_19, V.Undef, ((V)((h_554 + 10D))))), "\" fill=\"", ToStr(GetIdx(Arr(((V)("#6f86a2")), ((V)("#7d93ae")), ((V)("#61789a"))), (ToNum(i_551) % 3D))), "\"/>")).V(Invoke(Call(rep_21, V.Undef, ((V)(System.Math.Floor((h_554 / 3D)))), Fn((V _arrowThis563, int _argc556, V j_562, V _a559, V _a560, V _a561, V[] _rest557) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)((x_553 + 0.9))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)(((54D - h_554) + (ToNum(j_562) * 3D)))))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)((w_555 - 1.8))))), "\" height=\"0.8\" fill=\"#dfe9f2\" opacity=\"0.4\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
return default;
}, 1, "", true)), "join", ((V)(""))));
sc_543.S("<path d=\"M-118 60Q-60 50 0 58T118 54V86H-118Z\" fill=\"#7fae6e\"/>").V(Invoke(Call(rep_21, V.Undef, ((V)(14D)), Fn((V _arrowThis571, int _argc564, V i_570, V _a567, V _a568, V _a569, V[] _rest565) => {
return Call(tree_67, V.Undef, ((V)(((-114D) + (ToNum(i_570) * 17.4)))), ((V)((72D + ((ToNum(i_570) % 2D) * 4D)))), ((V)((1.1 + ((ToNum(i_570) % 3D) * 0.2)))), GetIdx(Arr(((V)("#4f8a42")), ((V)("#5c9a4c")), ((V)("#477e3a"))), (ToNum(i_570) % 3D)), ((V)((ToNum(i_570) * 0.5))));
}, 1, "", true)), "join", ((V)(""))));
sc_543.V(Invoke(Call(rep_21, V.Undef, ((V)(3D)), Fn((V _arrowThis579, int _argc572, V i_578, V _a575, V _a576, V _a577, V[] _rest573) => {
return ((V)(string.Concat("<g><animateMotion dur=\"", NumStr((14D + (ToNum(i_578) * 3D))), "s\" begin=\"", NumStr(((-ToNum(i_578)) * 5D)), "s\" repeatCount=\"indefinite\" path=\"M-130 ", NumStr(((-10D) + (ToNum(i_578) * 8D))), "Q0 ", NumStr(((-26D) + (ToNum(i_578) * 6D))), " 130 ", NumStr(((-6D) + (ToNum(i_578) * 4D))), "\"/><path d=\"M-1.6 0Q-0.8 -1 0 0Q0.8 -1 1.6 0\" stroke=\"#3a3e48\" stroke-width=\"0.4\" fill=\"none\"/></g>")));
}, 1, "", true)), "join", ((V)(""))));
sc_543.S(string.Concat("<rect x=\"-118\" y=\"-38\" width=\"236\" height=\"0\" fill=\"url(#tn)\">", ToStr(Call(an_16, V.Undef, ((V)("height")), ((V)("0;124;124;0;0")), ((V)(18D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.3;0.55;0.85;1\"")))), "</rect><rect x=\"-118\" y=\"-38\" width=\"236\" height=\"1\" fill=\"#bfe4ff\" opacity=\"0.8\">", ToStr(Call(an_16, V.Undef, ((V)("y")), ((V)("-38;86;86;-38;-38")), ((V)(18D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.3;0.55;0.85;1\"")))), "</rect>"));
s_542.S(string.Concat("<g clip-path=\"url(#gc)\">", sc_543.Str, ToStr(Call(glassRef_68, V.Undef, ((V)((-118D))), ((V)((-38D))), ((V)(236D)), ((V)(124D)))), "</g>"));
s_542.V(Add(Add(Call(ring_62, V.Undef, ((V)((-119D))), ((V)((-39D))), ((V)(119D)), ((V)(87D)), ((V)(2.2)), FC_541, ((V)(0.4))), Invoke(Invoke(Arr(((V)((-59D))), ((V)(0D)), ((V)(59D))), "map", Fn((V _arrowThis587, int _argc580, V x_586, V _a583, V _a584, V _a585, V[] _rest581) => {
return Call(bev_61, V.Undef, ((V)((ToNum(x_586) - 1D))), ((V)((-37D))), ((V)(2D)), ((V)(122D)), FC_541, ((V)(0.3)));
}, 1, "", true)), "join", ((V)("")))), Call(bev_61, V.Undef, ((V)((-117D))), ((V)(58D)), ((V)(234D)), ((V)(1.8)), FC_541, ((V)(0.3)))));
s_542.V(Invoke(Invoke(Arr(((V)((-30D))), ((V)(30D)), ((V)(88D)), ((V)((-88D)))), "map", Fn((V _arrowThis595, int _argc588, V x_594, V _a591, V _a592, V _a593, V[] _rest589) => {
return ((V)(string.Concat("<rect x=\"", NumStr((ToNum(x_594) - 0.4)), "\" y=\"66\" width=\"0.8\" height=\"7\" rx=\"0.3\" fill=\"#8a8f96\"/>")));
}, 1, "", true)), "join", ((V)(""))));
s_542.V(Call(sill_64, V.Undef, ((V)((-123D))), ((V)(123D)), ((V)(88D)), ((V)("#d9d5cc")), ((V)(2.4))));
s_542.S(string.Concat("<rect x=\"102\" y=\"64\" width=\"12\" height=\"7\" rx=\"1\" fill=\"#14161b\" stroke=\"#3a3e46\" stroke-width=\"0.3\"/><text x=\"108\" y=\"66.6\" text-anchor=\"middle\" font-family=\"Arial,Helvetica,sans-serif\" font-weight=\"700\" font-size=\"1.6\" fill=\"#9fdcff\">TINT</text><rect x=\"103.6\" y=\"68\" width=\"8.8\" height=\"1.4\" rx=\"0.7\" fill=\"#2a2e36\"/><rect x=\"103.6\" y=\"68\" width=\"1\" height=\"1.4\" rx=\"0.7\" fill=\"#5fd0ff\">", ToStr(Call(an_16, V.Undef, ((V)("width")), ((V)("1;8.8;8.8;1;1")), ((V)(18D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.3;0.55;0.85;1\"")))), "</rect>"));
return NewObj(2).Put("vb", Arr(((V)((-124D))), ((V)((-44D))), ((V)(248D)), ((V)(137D)))).Put("s", ((V)(s_542.Str))).V;
return default;
}, 0, "w72", false);
w92_73 = Fn((V _self596, int _argc597, V _a599, V _a600, V _a601, V _a602, V[] _rest598) => {
V KT_603 = default;
V VA_604 = default;
V cyc_605 = default;
double x0_606 = 0;
double y0_607 = 0;
double w_608 = 0;
double h_609 = 0;
V R_610 = default;
JsStrBuf s_611 = null;
JsStrBuf sc_612 = null;
JsStrBuf sky_613 = null;
JsStrBuf lit_614 = null;
V rain_615 = default;
V snow_616 = default;
V icons_617 = default;
if (_self596.IsNullish) _self596 = GlobalV;
KT_603 = ((V)(" keyTimes=\"0;0.2;0.25;0.45;0.5;0.7;0.75;0.95;1\""));
VA_604 = Arr(((V)("1;1;0;0;0;0;0;0;1")), ((V)("0;0;1;1;0;0;0;0;0")), ((V)("0;0;0;0;1;1;0;0;0")), ((V)("0;0;0;0;0;0;1;1;0")));
cyc_605 = Fn((V _arrowThis625, int _argc618, V i_624, V _a621, V _a622, V _a623, V[] _rest619) => {
return Call(an_16, V.Undef, ((V)("opacity")), GetK(VA_604, i_624), ((V)(32D)), ((V)(0D)), KT_603);
}, 1, "", true);
x0_606 = (-128D);
y0_607 = (-42D);
w_608 = 256D;
h_609 = 132D;
R_610 = Call(rng_23, V.Undef, ((V)("w92")));
s_611 = new JsStrBuf(string.Concat(string.Concat("<defs>", ToStr(WDEF_60), "<linearGradient id=\"s0\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#5fb0f0\"/><stop offset=\"1\" stop-color=\"#d4f0ff\"/></linearGradient><linearGradient id=\"s1\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#4f5c6c\"/><stop offset=\"1\" stop-color=\"#93a2b0\"/></linearGradient><linearGradient id=\"s2\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#070b26\"/><stop offset=\"1\" stop-color=\"#2c2664\"/></linearGradient><linearGradient id=\"s3\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#9fb0c2\"/><stop offset=\"1\" stop-color=\"#e6edf3\"/></linearGradient>"), "<radialGradient id=\"sun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff8d0\"/><stop offset=\"0.35\" stop-color=\"#ffe7a0\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#ffe7a0\" stop-opacity=\"0\"/></radialGradient><pattern id=\"scn\" width=\"4\" height=\"1.4\" patternUnits=\"userSpaceOnUse\"><rect width=\"4\" height=\"0.45\" fill=\"#9ff8ff\" fill-opacity=\"0.07\"/></pattern>", string.Concat("<linearGradient id=\"shm\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#9ff8ff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#dffcff\" stop-opacity=\"0.32\"/><stop offset=\"1\" stop-color=\"#9ff8ff\" stop-opacity=\"0\"/></linearGradient><clipPath id=\"gc\"><rect x=\"", NumStr(x0_606), "\" y=\"", NumStr(y0_607), "\" width=\"", NumStr(w_608), "\" height=\"", NumStr(h_609), "\" rx=\"5\"/></clipPath></defs>")));
s_611.S(string.Concat("<rect x=\"", NumStr((x0_606 - 6D)), "\" y=\"", NumStr((y0_607 - 6D)), "\" width=\"", NumStr((w_608 + 12D)), "\" height=\"", NumStr((h_609 + 12D)), "\" rx=\"12\" fill=\"#3fd0ff\" opacity=\"0.3\" filter=\"url(#b2)\">", ToStr(Call(an_16, V.Undef, ((V)("opacity")), ((V)("0.22;0.38;0.22")), ((V)(4D)))), "</rect><rect x=\"", NumStr((x0_606 - 2D)), "\" y=\"", NumStr((y0_607 - 1D)), "\" width=\"", NumStr((w_608 + 6D)), "\" height=\"", NumStr((h_609 + 5D)), "\" rx=\"6\" fill=\"#000000\" opacity=\"0.2\" filter=\"url(#b2)\"/>"));
sc_612 = new JsStrBuf(string.Concat("<g>", ToStr(Call(cyc_605, V.Undef, ((V)(0D)))), "<rect x=\"", NumStr(x0_606), "\" y=\"", NumStr(y0_607), "\" width=\"", NumStr(w_608), "\" height=\"", NumStr(h_609), "\" fill=\"url(#s0)\"/><circle cx=\"70\" cy=\"-14\" r=\"26\" fill=\"url(#sun)\"/><circle cx=\"70\" cy=\"-14\" r=\"6\" fill=\"#fff6c8\"/>", ToStr(Call(drift_66, V.Undef, Add(Call(cloud_65, V.Undef, ((V)((-90D))), ((V)((-20D))), ((V)(1.2)), ((V)("#ffffff"))), Call(cloud_65, V.Undef, ((V)(0D)), ((V)((-28D))), ((V)(1D)), ((V)("#ffffff")))), ((V)(w_608)), ((V)(80D)))), "</g>"));
sc_612.S(string.Concat("<g opacity=\"0\">", ToStr(Call(cyc_605, V.Undef, ((V)(1D)))), "<rect x=\"", NumStr(x0_606), "\" y=\"", NumStr(y0_607), "\" width=\"", NumStr(w_608), "\" height=\"", NumStr(h_609), "\" fill=\"url(#s1)\"/>", ToStr(Call(drift_66, V.Undef, Add(Add(Call(cloud_65, V.Undef, ((V)((-100D))), ((V)((-26D))), ((V)(2D)), ((V)("#7a8696"))), Call(cloud_65, V.Undef, ((V)((-30D))), ((V)((-30D))), ((V)(2.4)), ((V)("#6e7a8a")))), Call(cloud_65, V.Undef, ((V)(50D)), ((V)((-24D))), ((V)(2D)), ((V)("#7a8696")))), ((V)(w_608)), ((V)(60D)))), "</g>"));
sc_612.S(string.Concat("<g opacity=\"0\">", ToStr(Call(cyc_605, V.Undef, ((V)(2D)))), "<rect x=\"", NumStr(x0_606), "\" y=\"", NumStr(y0_607), "\" width=\"", NumStr(w_608), "\" height=\"", NumStr(h_609), "\" fill=\"url(#s2)\"/>", ToStr(Invoke(Call(rep_21, V.Undef, ((V)(60D)), Fn((V _arrowThis633, int _argc626, V i_632, V _a629, V _a630, V _a631, V[] _rest627) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((x0_606 + (ToNum(Call(R_610, V.Undef)) * w_608)))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((y0_607 + (ToNum(Call(R_610, V.Undef)) * 70D)))))), "\" r=\"", ToStr(Call(f1_19, V.Undef, ((V)((0.25 + (ToNum(Call(R_610, V.Undef)) * 0.45)))))), "\" fill=\"#ffffff\">", ToStr(Call(an_16, V.Undef, ((V)("opacity")), ((V)("0.3;1;0.3")), ((V)((1.5 + (ToNum(Call(R_610, V.Undef)) * 3D)))), ((V)(((-ToNum(Call(R_610, V.Undef))) * 3D))))), "</circle>")));
}, 1, "", true)), "join", ((V)("")))), "<circle cx=\"-70\" cy=\"-20\" r=\"8\" fill=\"#fff4d6\"/><circle cx=\"-66\" cy=\"-23\" r=\"7\" fill=\"#11163a\"/></g>"));
sc_612.S(string.Concat("<g opacity=\"0\">", ToStr(Call(cyc_605, V.Undef, ((V)(3D)))), "<rect x=\"", NumStr(x0_606), "\" y=\"", NumStr(y0_607), "\" width=\"", NumStr(w_608), "\" height=\"", NumStr(h_609), "\" fill=\"url(#s3)\"/></g>"));
sky_613 = new JsStrBuf("");
lit_614 = new JsStrBuf("");
{
double i_634 = 0;
i_634 = 0D;
while (true) {
if (!((i_634 < 26D))) break;
double bx_636 = 0;
double bw_637 = 0;
double bh_638 = 0;
double top_639 = 0;
V c_640 = default;
bx_636 = ((x0_606 + (i_634 * 10D)) + (ToNum(Call(R_610, V.Undef)) * 2D));
bw_637 = (6D + (ToNum(Call(R_610, V.Undef)) * 4D));
bh_638 = (26D + (ToNum(Call(R_610, V.Undef)) * 64D));
top_639 = (90D - bh_638);
c_640 = GetIdx(Arr(((V)("#34425f")), ((V)("#3c4b6a")), ((V)("#2c3a56"))), (i_634 % 3D));
sky_613.S(string.Concat("<rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)(bx_636)))), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)(top_639)))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)(bw_637)))), "\" height=\"", ToStr(Call(f1_19, V.Undef, ((V)(bh_638)))), "\" fill=\"", ToStr(c_640), "\"/><rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)(bx_636)))), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)(top_639)))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)((bw_637 * 0.3))))), "\" height=\"", ToStr(Call(f1_19, V.Undef, ((V)(bh_638)))), "\" fill=\"#ffffff\" opacity=\"0.06\"/>"));
if (((i_634 % 4D) == 1D)) {
sky_613.S(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((bx_636 + (bw_637 / 2D)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((top_639 - 8D))))), "V", ToStr(Call(f1_19, V.Undef, ((V)(top_639)))), "\" stroke=\"", ToStr(c_640), "\" stroke-width=\"0.8\"/><circle cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((bx_636 + (bw_637 / 2D)))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((top_639 - 8D))))), "\" r=\"0.7\" fill=\"#ff5a5a\">", ToStr(Call(an_16, V.Undef, ((V)("opacity")), ((V)("1;0.2;1")), ((V)(1.4)), ((V)(((-i_634) * 0.2))))), "</circle>"));
}
if (((i_634 % 5D) == 3D)) {
sky_613.S(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)(bx_636)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(top_639)))), "Q", ToStr(Call(f1_19, V.Undef, ((V)((bx_636 + (bw_637 / 2D)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((top_639 - 5D))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((bx_636 + bw_637))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(top_639)))), "Z\" fill=\"", ToStr(c_640), "\"/>"));
}
{
double j_641 = 0;
j_641 = 0D;
while (true) {
if (!((j_641 < ((bh_638 / 4D) - 1D)))) break;
{
double q_643 = 0;
q_643 = 0D;
while (true) {
if (!((q_643 < 2D))) break;
V on_645 = default;
on_645 = (LtN(Call(R_610, V.Undef), 0.55) ? V.True : V.False);
sky_613.S(string.Concat("<rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)(((bx_636 + 1D) + (q_643 * (bw_637 / 2D))))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)(((top_639 + 2D) + (j_641 * 4D)))))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)(((bw_637 / 2D) - 2D))))), "\" height=\"1.4\" fill=\"#cfe6ff\" opacity=\"0.22\"/>"));
if (Truthy(on_645)) {
lit_614.S(string.Concat("<rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)(((bx_636 + 1D) + (q_643 * (bw_637 / 2D))))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)(((top_639 + 2D) + (j_641 * 4D)))))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)(((bw_637 / 2D) - 2D))))), "\" height=\"1.4\" fill=\"#ffd77a\"/>"));
}
q_643++;
}
}
j_641++;
}
}
i_634++;
}
}
sc_612.S(sky_613.Str).S(string.Concat("<g opacity=\"0\">", ToStr(Call(cyc_605, V.Undef, ((V)(2D)))), "<rect x=\"", NumStr(x0_606), "\" y=\"", NumStr(y0_607), "\" width=\"", NumStr(w_608), "\" height=\"", NumStr(h_609), "\" fill=\"#0b1030\" opacity=\"0.35\"/>", lit_614.Str, "</g>"));
rain_615 = Invoke(Call(rep_21, V.Undef, ((V)(70D)), Fn((V _arrowThis652, int _argc646, V _a648, V _a649, V _a650, V _a651, V[] _rest647) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((x0_606 + (ToNum(Call(R_610, V.Undef)) * w_608)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y0_607 + (ToNum(Call(R_610, V.Undef)) * h_609)))))), "l-1.2 4\" stroke=\"#cfe0f0\" stroke-width=\"0.35\" opacity=\"0.7\"/>")));
}, 0, "", true)), "join", ((V)("")));
sc_612.S(string.Concat("<g opacity=\"0\">", ToStr(Call(cyc_605, V.Undef, ((V)(1D)))), "<g>", ToStr(Call(at_17, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;-6 ", NumStr(h_609)))), ((V)(0.9)))), ToStr(rain_615), "<g transform=\"translate(6 ", NumStr((-h_609)), ")\">", ToStr(rain_615), "</g></g></g>"));
snow_616 = Invoke(Call(rep_21, V.Undef, ((V)(60D)), Fn((V _arrowThis659, int _argc653, V _a655, V _a656, V _a657, V _a658, V[] _rest654) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((x0_606 + (ToNum(Call(R_610, V.Undef)) * w_608)))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((y0_607 + (ToNum(Call(R_610, V.Undef)) * h_609)))))), "\" r=\"", ToStr(Call(f1_19, V.Undef, ((V)((0.4 + (ToNum(Call(R_610, V.Undef)) * 0.6)))))), "\" fill=\"#ffffff\"/>")));
}, 0, "", true)), "join", ((V)("")));
sc_612.S(string.Concat("<g opacity=\"0\">", ToStr(Call(cyc_605, V.Undef, ((V)(3D)))), "<g>", ToStr(Call(at_17, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;8 ", NumStr(h_609)))), ((V)(9D)))), ToStr(snow_616), "<g transform=\"translate(-8 ", NumStr((-h_609)), ")\">", ToStr(snow_616), "</g></g><rect x=\"", NumStr(x0_606), "\" y=\"86\" width=\"", NumStr(w_608), "\" height=\"4\" fill=\"#ffffff\" opacity=\"0.9\"/></g>"));
sc_612.V(Invoke(Call(rep_21, V.Undef, ((V)(3D)), Fn((V _arrowThis667, int _argc660, V i_666, V _a663, V _a664, V _a665, V[] _rest661) => {
return ((V)(string.Concat("<g><animateMotion dur=\"", NumStr((9D + (ToNum(i_666) * 4D))), "s\" begin=\"", NumStr(((-ToNum(i_666)) * 3D)), "s\" repeatCount=\"indefinite\" path=\"M", NumStr((x0_606 - 10D)), " ", NumStr(((-4D) + (ToNum(i_666) * 12D))), "Q0 ", NumStr(((-14D) + (ToNum(i_666) * 10D))), " ", NumStr(((x0_606 + w_608) + 10D)), " ", NumStr((2D + (ToNum(i_666) * 10D))), "\"/><rect x=\"-2.6\" y=\"-0.9\" width=\"5.2\" height=\"1.8\" rx=\"0.9\" fill=\"#d8e4f0\"/><circle cx=\"2.4\" r=\"0.6\" fill=\"#ffe680\"/><circle cx=\"-2.4\" r=\"0.5\" fill=\"#ff5a6a\"/></g>")));
}, 1, "", true)), "join", ((V)(""))));
sc_612.S(string.Concat("<rect x=\"", NumStr(x0_606), "\" y=\"", NumStr(y0_607), "\" width=\"", NumStr(w_608), "\" height=\"", NumStr(h_609), "\" fill=\"url(#scn)\"/><rect x=\"", NumStr((x0_606 - 60D)), "\" y=\"", NumStr(y0_607), "\" width=\"40\" height=\"", NumStr(h_609), "\" fill=\"url(#shm)\" transform=\"skewX(-14)\">", ToStr(Call(at_17, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 0;", NumStr((w_608 + 120D)), " 0"))), ((V)(7D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.4;1\" additive=\"sum\"")))), "</rect>"));
s_611.S(string.Concat("<g clip-path=\"url(#gc)\">", sc_612.Str, ToStr(Call(glassRef_68, V.Undef, ((V)(x0_606)), ((V)(y0_607)), ((V)(w_608)), ((V)(h_609)))), "</g>"));
s_611.S(string.Concat("<rect x=\"", NumStr(x0_606), "\" y=\"", NumStr(y0_607), "\" width=\"", NumStr(w_608), "\" height=\"", NumStr(h_609), "\" rx=\"5\" fill=\"none\" stroke=\"#12141a\" stroke-width=\"2.4\"/><rect x=\"", NumStr((x0_606 + 1.4)), "\" y=\"", NumStr((y0_607 + 1.4)), "\" width=\"", NumStr((w_608 - 2.8)), "\" height=\"", NumStr((h_609 - 2.8)), "\" rx=\"4\" fill=\"none\" stroke=\"#5ff0ff\" stroke-width=\"0.6\">", ToStr(Call(an_16, V.Undef, ((V)("opacity")), ((V)("0.5;1;0.5")), ((V)(2.6)))), "</rect>"));
Invoke(Arr(Arr(((V)(x0_606)), ((V)(y0_607))), Arr(((V)((x0_606 + w_608))), ((V)(y0_607))), Arr(((V)(x0_606)), ((V)((y0_607 + h_609)))), Arr(((V)((x0_606 + w_608))), ((V)((y0_607 + h_609))))), "forEach", Fn((V _arrowThis679, int _argc668, V _a670, V _a671, V _a672, V _a673, V[] _rest669) => {
V x_676 = default;
V y_678 = default;
{ V _t674 = ListOf(_a670);
{ V _t675 = GetIdx(_t674, 0D);
x_676 = _t675; }
{ V _t677 = GetIdx(_t674, 1D);
y_678 = _t677; }
}
return ((V)(s_611.S(string.Concat("<circle cx=\"", ToStr(x_676), "\" cy=\"", ToStr(y_678), "\" r=\"1.6\" fill=\"#1a1d24\" stroke=\"#5ff0ff\" stroke-width=\"0.4\"/>")).Str));
}, 1, "", true));
icons_617 = Arr(((V)(JsStrBuf.Begin().S("<circle r=\"2.6\" fill=\"#ffd34a\"/>").V(Invoke(Call(rep_21, V.Undef, ((V)(8D)), Fn((V _arrowThis687, int _argc680, V i_686, V _a683, V _a684, V _a685, V[] _rest681) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((3.4 * FdLibm.Cos(((ToNum(i_686) * PI_14) / 4D))))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((3.4 * FdLibm.Sin(((ToNum(i_686) * PI_14) / 4D))))))), "l", ToStr(Call(f1_19, V.Undef, ((V)((1.2 * FdLibm.Cos(((ToNum(i_686) * PI_14) / 4D))))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((1.2 * FdLibm.Sin(((ToNum(i_686) * PI_14) / 4D))))))), "\" stroke=\"#ffd34a\" stroke-width=\"0.6\"/>")));
}, 1, "", true)), "join", ((V)("")))).End())), ((V)("<ellipse cy=\"-0.6\" rx=\"3.8\" ry=\"2\" fill=\"#cfd8e2\"/><path d=\"M-2 2l-0.6 2M0 2l-0.6 2M2 2l-0.6 2\" stroke=\"#8fd0ff\" stroke-width=\"0.5\"/>")), ((V)("<circle r=\"3\" fill=\"#fff4d6\"/><circle cx=\"1.4\" cy=\"-1\" r=\"2.6\" fill=\"#0b1a2a\"/>")), ((V)("<path d=\"M0 -3.4V3.4M-3 -1.7L3 1.7M-3 1.7L3 -1.7\" stroke=\"#ffffff\" stroke-width=\"0.6\"/>")));
s_611.S(string.Concat("<g transform=\"translate(", NumStr((x0_606 + 6D)), " ", NumStr((y0_607 + 6D)), ")\"><rect width=\"38\" height=\"12\" rx=\"3\" fill=\"#0b1a2a\" opacity=\"0.6\" stroke=\"#5ff0ff\" stroke-width=\"0.35\"/>")).V(Invoke(Invoke(icons_617, "map", Fn((V _arrowThis696, int _argc688, V ic_694, V i_695, V _a692, V _a693, V[] _rest689) => {
return ((V)(string.Concat("<g opacity=\"", NumStr((Truthy(i_695) ? 0D : 1D)), "\">", ToStr(Call(cyc_605, V.Undef, i_695)), "<g transform=\"translate(6.4 6)\">", ToStr(ic_694), "</g><text x=\"14\" y=\"7.6\" font-family=\"Arial,Helvetica,sans-serif\" font-weight=\"700\" font-size=\"4.2\" fill=\"#e8feff\">", ToStr(GetK(Arr(((V)("24\u00b0")), ((V)("17\u00b0")), ((V)("9\u00b0")), ((V)("-2\u00b0"))), i_695)), "</text></g>")));
}, 2, "", true)), "join", ((V)("")))).S("<text x=\"35\" y=\"4.6\" text-anchor=\"end\" font-family=\"Arial,Helvetica,sans-serif\" font-weight=\"700\" font-size=\"1.8\" fill=\"#5ff0ff\">LIVE SKY</text></g>");
return NewObj(2).Put("vb", Arr(((V)((-136D))), ((V)((-50D))), ((V)(272D)), ((V)(148D)))).Put("s", ((V)(s_611.Str))).V;
return default;
}, 0, "w92", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((((((((RD_8 is var _t697 && !Truthy(_t697) ? _t697 : Get(RD_8, "PLUS18")) is var _t698 && !Truthy(_t698) ? _t698 : Get(RD_8, "H12")) is var _t699 && !Truthy(_t699) ? _t699 : Get(Get(RD_8, "H12"), "tile")) is var _t700 && !Truthy(_t700) ? _t700 : Get(RD_8, "H15")) is var _t701 && !Truthy(_t701) ? _t701 : Get(RD_8, "H11")) is var _t702 && !Truthy(_t702) ? _t702 : Get(RD_8, "H10")) is var _t703 && !Truthy(_t703) ? _t703 : X_9) is var _t704 && !Truthy(_t704) ? _t704 : Get(X_9, "K")) is var _t705 && !Truthy(_t705) ? _t705 : Get(X_9, "SPEC"))))) {
Call(G("setTimeout"), V.Undef, boot_706.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS19"))) {
return default;
}
K_10 = Get(X_9, "K");
shade_11 = Get(K_10, "shade");
N_12 = Get(RD_8, "N");
H_13 = Get(RD_8, "H10");
PI_14 = System.Math.PI;
{ V _t707 = H_13;
if (_t707.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t707));
{ V _t708 = Get(_t707, "cam");
cam_15 = _t708; }
{ V _t709 = Get(_t707, "an");
an_16 = _t709; }
{ V _t710 = Get(_t707, "at");
at_17 = _t710; }
{ V _t711 = Get(_t707, "SPL");
SPL_18 = _t711; }
{ V _t712 = Get(_t707, "f1");
f1_19 = _t712; }
{ V _t713 = Get(_t707, "n4");
n4_20 = _t713; }
{ V _t714 = Get(_t707, "rep");
rep_21 = _t714; }
{ V _t715 = Get(_t707, "P2");
P2_22 = _t715; }
{ V _t716 = Get(_t707, "rng");
rng_23 = _t716; } }
{ V _t717 = Get(RD_8, "H11");
if (_t717.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t717));
{ V _t718 = Get(_t717, "ext");
ext_24 = _t718; } }
{ V _t719 = Get(RD_8, "H12");
if (_t719.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t719));
{ V _t720 = Get(_t719, "DEF12");
DEF12_25 = _t720; }
{ V _t721 = Get(_t719, "WD");
WD_26 = _t721; }
{ V _t722 = Get(_t719, "wsh");
wsh_27 = _t722; }
{ V _t723 = Get(_t719, "innerW");
innerW_28 = _t723; }
{ V _t724 = Get(_t719, "tile");
tile_29 = _t724; }
{ V _t725 = Get(_t719, "blot");
blot_30 = _t725; }
{ V _t726 = Get(_t719, "outlet");
outlet_31 = _t726; }
{ V _t727 = Get(_t719, "BB");
BB_32 = _t727; }
{ V _t728 = Get(_t719, "SURF12");
SURF12_33 = _t728; } }
{ V _t729 = Get(RD_8, "H15");
if (_t729.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t729));
{ V _t730 = Get(_t729, "box3");
box3_34 = _t730; }
{ V _t731 = Get(_t729, "cyl3");
cyl3_35 = _t731; } }
sph_36 = Fn((V _arrowThis743, int _argc732, V C_738, V q_739, V r_740, V col_741, V[] _rest733) => {
V c_744 = default;
V o_742 = default;
o_742 = (_argc732 > 4 ? _rest733[0] : V.Undef);
c_744 = Invoke(C_738, "P", q_739);
return ((V)(JsStrBuf.Begin().V(Invoke(H_13, "sph", C_738, q_739, r_740, col_741, o_742)).S(string.Concat("<circle cx=\"", ToStr(Call(f1_19, V.Undef, GetIdx(c_744, 0D))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, GetIdx(c_744, 1D))), "\" r=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(r_740) * ToNum(Get(C_738, "k"))))))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_11, V.Undef, col_741, ((V)(0.35)))), "\" stroke-width=\"0.5\"/>")).End()));
return default;
}, 5, "", true);
pane_37 = Fn((V _arrowThis758, int _argc745, V C_751, V O_752, V U_753, V V_754, V[] _rest746) => {
V w_755 = default;
V h_756 = default;
V o_757 = default;
w_755 = (_argc745 > 4 ? _rest746[0] : V.Undef);
h_756 = (_argc745 > 5 ? _rest746[1] : V.Undef);
o_757 = (_argc745 > 6 ? _rest746[2] : V.Undef);
return Invoke(Get(RD_8, "H11"), "pane", C_751, O_752, U_753, V_754, w_755, h_756, Object_assign(NewObj(0).V, o_757, NewObj(3).Put("g", ((V)(0.3))).Put("e", ((V)(0.12))).Put("t", ((V)(0.03))).V));
}, 7, "", true);
xe_38 = Fn((V _arrowThis766, int _argc759, V s_765, V _a762, V _a763, V _a764, V[] _rest760) => {
return Invoke(Invoke(Invoke(Invoke(((V)(ToStrS(s_765))), "replace", NewRegExp(RX3, "&", "g"), ((V)("&amp;"))), "replace", NewRegExp(RX2, "<", "g"), ((V)("&lt;"))), "replace", NewRegExp(RX1, ">", "g"), ((V)("&gt;"))), "replace", NewRegExp(RX0, "\"", "g"), ((V)("&quot;")));
}, 1, "", true);
T_39 = Fn((V _arrowThis779, int _argc767, V x_773, V y_774, V sz_775, V col_776, V[] _rest768) => {
V txt_777 = default;
V ex_778 = default;
txt_777 = (_argc767 > 4 ? _rest768[0] : V.Undef);
ex_778 = (_argc767 > 5 ? _rest768[1] : V.Undef);
return ((V)(string.Concat("<text x=\"", ToStr(Call(f1_19, V.Undef, x_773)), "\" y=\"", ToStr(Call(f1_19, V.Undef, y_774)), "\" text-anchor=\"middle\" font-family=\"Arial,Helvetica,sans-serif\" font-weight=\"700\" font-size=\"", ToStr(Call(f1_19, V.Undef, sz_775)), "\" fill=\"", ToStr(col_776), "\"", (Truthy(ex_778) ? JsStrBuf.Begin().S(" ").V(ex_778).End() : ""), ">", ToStr(txt_777), "</text>")));
}, 6, "", true);
SCRIPT_40 = ((V)("'Brush Script MT','Segoe Script','Lucida Handwriting',cursive"));
HAND_41 = ((V)("'Segoe Print','Comic Sans MS','Marker Felt',cursive"));
SERIF_42 = ((V)("Georgia,'Times New Roman',serif"));
DEF19_43 = ((V)(JsStrBuf.Begin().V(DEF12_25).S("<pattern id=\"tw19\" width=\"0.9\" height=\"0.9\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 0.45H0.9M0.45 0V0.9\" stroke=\"#5a4a30\" stroke-opacity=\"0.12\" stroke-width=\"0.18\"/></pattern>").S("<linearGradient id=\"br19\" x1=\"0\" y1=\"0\" x2=\"0.3\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0b0\"/><stop offset=\"0.35\" stop-color=\"#e2b456\"/><stop offset=\"0.7\" stop-color=\"#b38432\"/><stop offset=\"1\" stop-color=\"#7a5418\"/></linearGradient>").S("<linearGradient id=\"gd19\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff3c0\" stop-opacity=\"0.55\"/><stop offset=\"0.4\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.75\" stop-color=\"#5a3a08\" stop-opacity=\"0.18\"/><stop offset=\"1\" stop-color=\"#5a3a08\" stop-opacity=\"0.32\"/></linearGradient>").End()));
capBoard_44 = Fn((V _arrowThis788, int _argc780, V col_786, V h_787, V _a784, V _a785, V[] _rest781) => {
double t_789 = 0;
t_789 = (ToNum(BB_32) - ToNum(h_787));
return ((V)(string.Concat("<rect y=\"", ToStr(Call(f1_19, V.Undef, ((V)((t_789 - 0.9))))), "\" width=\"80\" height=\"0.9\" fill=\"#000000\" opacity=\"0.14\" filter=\"url(#wb1)\"/><rect y=\"", ToStr(Call(f1_19, V.Undef, ((V)(t_789)))), "\" width=\"80\" height=\"", ToStr(Call(f1_19, V.Undef, h_787)), "\" fill=\"", ToStr(col_786), "\"/><rect y=\"", ToStr(Call(f1_19, V.Undef, ((V)(t_789)))), "\" width=\"80\" height=\"0.35\" fill=\"", ToStr(Call(shade_11, V.Undef, col_786, ((V)(1.12)))), "\"/><rect y=\"", ToStr(Call(f1_19, V.Undef, ((V)((t_789 + 0.55))))), "\" width=\"80\" height=\"0.2\" fill=\"", ToStr(Call(shade_11, V.Undef, col_786, ((V)(0.8)))), "\"/><rect y=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(BB_32) - 0.25))))), "\" width=\"80\" height=\"0.25\" fill=\"", ToStr(Call(shade_11, V.Undef, col_786, ((V)(0.86)))), "\"/>")));
return default;
}, 2, "", true);
swPlate_45 = Fn((V _arrowThis799, int _argc790, V x_796, V y_797, V col_798, V _a795, V[] _rest791) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_19, V.Undef, Add(x_796, ((V)(0.25))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, Add(y_797, ((V)(0.35))))), "\" width=\"1.6\" height=\"2.5\" rx=\"0.2\" fill=\"#000000\" opacity=\"0.2\" filter=\"url(#wb1)\"/><rect x=\"", ToStr(x_796), "\" y=\"", ToStr(y_797), "\" width=\"1.6\" height=\"2.5\" rx=\"0.2\" fill=\"", ToStr(col_798), "\" stroke=\"", ToStr(Call(shade_11, V.Undef, col_798, ((V)(0.72)))), "\" stroke-width=\"0.1\"/><rect x=\"", ToStr(Call(f1_19, V.Undef, Add(x_796, ((V)(0.58))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, Add(y_797, ((V)(0.7))))), "\" width=\"0.44\" height=\"1.1\" rx=\"0.12\" fill=\"", ToStr(Call(shade_11, V.Undef, col_798, ((V)(0.93)))), "\" stroke=\"", ToStr(Call(shade_11, V.Undef, col_798, ((V)(0.7)))), "\" stroke-width=\"0.08\"/><rect x=\"", ToStr(Call(f1_19, V.Undef, Add(x_796, ((V)(0.6))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, Add(y_797, ((V)(0.72))))), "\" width=\"0.4\" height=\"0.45\" fill=\"#ffffff\" opacity=\"0.7\"/>")));
}, 3, "", true);
scuffs_46 = Fn((V _arrowThis810, int _argc800, V seed_806, V n_807, V a_808, V b_809, V[] _rest801) => {
V R_811 = default;
R_811 = Call(rng_23, V.Undef, seed_806);
return Invoke(Call(rep_21, V.Undef, n_807, Fn((V _arrowThis818, int _argc812, V _a814, V _a815, V _a816, V _a817, V[] _rest813) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_811, V.Undef)) * 78D))))), " ", ToStr(Call(f1_19, V.Undef, Add(Add(BB_32, ((V)(0.5))), ((V)((ToNum(Call(R_811, V.Undef)) * 1.6)))))), "h", ToStr(Call(f1_19, V.Undef, ((V)((0.6 + (ToNum(Call(R_811, V.Undef)) * 1.6)))))), "\" stroke=\"", ToStr((LtN(Call(R_811, V.Undef), 0.5) ? a_808 : b_809)), "\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((0.12 + (ToNum(Call(R_811, V.Undef)) * 0.16)))))), "\" stroke-linecap=\"round\" opacity=\"0.6\"/>")));
}, 0, "", true)), "join", ((V)("")));
return default;
}, 4, "", true);
Object_assign(SURF12_33, NewObj(5).Put("lpaper", sPaper_47).Put("lsage", sSage_48).Put("lwain", sWain_49).Put("lherr", sHerr_50).Put("lmarb", sMarb_51).V);
MONTHS_52 = Arr(((V)("JANUARY")), ((V)("FEBRUARY")), ((V)("MARCH")), ((V)("APRIL")), ((V)("MAY")), ((V)("JUNE")), ((V)("JULY")), ((V)("AUGUST")), ((V)("SEPTEMBER")), ((V)("OCTOBER")), ((V)("NOVEMBER")), ((V)("DECEMBER")));
DAYS_53 = Arr(((V)("Sun")), ((V)("Mon")), ((V)("Tue")), ((V)("Wed")), ((V)("Thu")), ((V)("Fri")), ((V)("Sat")));
pizzaPhoto_54 = Fn((V _arrowThis828, int _argc819, V p_825, V w_826, V h_827, V _a824, V[] _rest820) => {
double cx_829 = 0;
double cy_830 = 0;
double r_831 = 0;
double a0_832 = 0;
double a1_833 = 0;
V wedge_834 = default;
V sl_835 = default;
double sx_836 = 0;
double sy_837 = 0;
V R_838 = default;
V pep_839 = default;
cx_829 = (ToNum(w_826) * 0.4);
cy_830 = (ToNum(h_827) * 0.56);
r_831 = (ToNum(h_827) * 0.42);
a0_832 = (-0.45);
a1_833 = 0.35;
wedge_834 = Fn((V _arrowThis847, int _argc840, V rr_846, V _a843, V _a844, V _a845, V[] _rest841) => {
return ((V)(string.Concat("M", ToStr(Call(f1_19, V.Undef, ((V)(cx_829)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(cy_830)))), "L", ToStr(Call(f1_19, V.Undef, ((V)((cx_829 + (ToNum(rr_846) * FdLibm.Cos(a1_833))))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((cy_830 + (ToNum(rr_846) * FdLibm.Sin(a1_833))))))), "A", ToStr(Call(f1_19, V.Undef, rr_846)), " ", ToStr(Call(f1_19, V.Undef, rr_846)), " 0 1 1 ", ToStr(Call(f1_19, V.Undef, ((V)((cx_829 + (ToNum(rr_846) * FdLibm.Cos(a0_832))))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((cy_830 + (ToNum(rr_846) * FdLibm.Sin(a0_832))))))), "Z")));
}, 1, "", true);
sl_835 = Fn((V _arrowThis855, int _argc848, V rr_854, V _a851, V _a852, V _a853, V[] _rest849) => {
return ((V)(string.Concat("M0 0L", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(rr_854) * FdLibm.Cos(a0_832)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(rr_854) * FdLibm.Sin(a0_832)))))), "A", ToStr(Call(f1_19, V.Undef, rr_854)), " ", ToStr(Call(f1_19, V.Undef, rr_854)), " 0 0 1 ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(rr_854) * FdLibm.Cos(a1_833)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(rr_854) * FdLibm.Sin(a1_833)))))), "Z")));
}, 1, "", true);
sx_836 = (cx_829 + (r_831 * 0.42));
sy_837 = (cy_830 - (r_831 * 0.18));
R_838 = Call(rng_23, V.Undef, ((V)(JsStrBuf.Begin().S("pz").V(p_825).End())));
pep_839 = Fn((V _arrowThis865, int _argc856, V x_862, V y_863, V k_864, V _a861, V[] _rest857) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_19, V.Undef, x_862)), "\" cy=\"", ToStr(Call(f1_19, V.Undef, y_863)), "\" r=\"", ToStr(Call(f1_19, V.Undef, ((V)(((r_831 * 0.13) * ToNum(k_864)))))), "\" fill=\"#b8352a\"/><circle cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(x_862) - (r_831 * 0.03)))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(y_863) - (r_831 * 0.03)))))), "\" r=\"", ToStr(Call(f1_19, V.Undef, ((V)(((r_831 * 0.05) * ToNum(k_864)))))), "\" fill=\"#e2675a\" opacity=\"0.7\"/>")));
}, 3, "", true);
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><pattern id=\"", ToStr(p_825), "t\" width=\"3\" height=\"3\" patternUnits=\"userSpaceOnUse\"><rect width=\"3\" height=\"3\" fill=\"#f4eee4\"/><rect width=\"1.5\" height=\"1.5\" fill=\"#d9483b\"/><rect x=\"1.5\" y=\"1.5\" width=\"1.5\" height=\"1.5\" fill=\"#d9483b\"/></pattern><radialGradient id=\"", ToStr(p_825), "c\" cx=\"45%\" cy=\"40%\" r=\"62%\"><stop offset=\"0\" stop-color=\"#ffe58a\"/><stop offset=\"1\" stop-color=\"#eab348\"/></radialGradient><clipPath id=\"", ToStr(p_825), "k\"><rect width=\"", ToStr(Call(f1_19, V.Undef, w_826)), "\" height=\"", ToStr(Call(f1_19, V.Undef, h_827)), "\"/></clipPath></defs>")).S(string.Concat("<g clip-path=\"url(#", ToStr(p_825), "k)\"><rect width=\"", ToStr(Call(f1_19, V.Undef, w_826)), "\" height=\"", ToStr(Call(f1_19, V.Undef, h_827)), "\" fill=\"url(#", ToStr(p_825), "t)\"/><ellipse cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((cx_829 + 1D))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((cy_830 + 1.4))))), "\" rx=\"", ToStr(Call(f1_19, V.Undef, ((V)((r_831 * 1.02))))), "\" ry=\"", ToStr(Call(f1_19, V.Undef, ((V)((r_831 * 0.98))))), "\" fill=\"#000000\" opacity=\"0.2\"/>")).S(string.Concat("<path d=\"", ToStr(Call(wedge_834, V.Undef, ((V)(r_831)))), "\" fill=\"#d9974c\"/><path d=\"", ToStr(Call(wedge_834, V.Undef, ((V)((r_831 * 0.88))))), "\" fill=\"#c8452e\"/><path d=\"", ToStr(Call(wedge_834, V.Undef, ((V)((r_831 * 0.82))))), "\" fill=\"url(#", ToStr(p_825), "c)\"/>")).V(Invoke(Invoke(Arr(Arr(((V)((-0.5))), ((V)((-0.4)))), Arr(((V)(0.2)), ((V)((-0.62)))), Arr(((V)((-0.6))), ((V)(0.3))), Arr(((V)((-0.05))), ((V)(0.08))), Arr(((V)(0.15)), ((V)(0.6))), Arr(((V)((-0.35))), ((V)(0.68)))), "map", Fn((V _arrowThis877, int _argc866, V _a868, V _a869, V _a870, V _a871, V[] _rest867) => {
V a_874 = default;
V b_876 = default;
{ V _t872 = ListOf(_a868);
{ V _t873 = GetIdx(_t872, 0D);
a_874 = _t873; }
{ V _t875 = GetIdx(_t872, 1D);
b_876 = _t875; }
}
return Call(pep_839, V.Undef, ((V)((cx_829 + (ToNum(a_874) * r_831)))), ((V)((cy_830 + (ToNum(b_876) * r_831)))), ((V)(1D)));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Call(rep_21, V.Undef, ((V)(5D)), Fn((V _arrowThis885, int _argc878, V i_884, V _a881, V _a882, V _a883, V[] _rest879) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((cx_829 + ((ToNum(Call(R_838, V.Undef)) - 0.6) * r_831)))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((cy_830 + ((ToNum(Call(R_838, V.Undef)) - 0.5) * r_831)))))), "\" rx=\"", ToStr(Call(f1_19, V.Undef, ((V)((r_831 * 0.08))))), "\" ry=\"", ToStr(Call(f1_19, V.Undef, ((V)((r_831 * 0.04))))), "\" fill=\"#3f8a3a\" transform=\"rotate(", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_838, V.Undef)) * 180D))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(cx_829)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(cy_830)))), ")\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_19, V.Undef, ((V)((sx_836 + (r_831 * 0.3)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((sy_837 - (r_831 * 0.08)))))), ") rotate(-8)\"><path d=\"", ToStr(Call(sl_835, V.Undef, ((V)(r_831)))), "\" fill=\"#d9974c\"/><path d=\"", ToStr(Call(sl_835, V.Undef, ((V)((r_831 * 0.88))))), "\" fill=\"#c8452e\"/><path d=\"", ToStr(Call(sl_835, V.Undef, ((V)((r_831 * 0.82))))), "\" fill=\"url(#", ToStr(p_825), "c)\"/>", ToStr(Call(pep_839, V.Undef, ((V)((r_831 * 0.5))), ((V)(((-r_831) * 0.04))), ((V)(0.9)))), "</g>")).V(Invoke(Call(rep_21, V.Undef, ((V)(3D)), Fn((V _arrowThis893, int _argc886, V i_892, V _a889, V _a890, V _a891, V[] _rest887) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((cx_829 + (r_831 * 0.8)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((cy_830 - (r_831 * (0.2 - (ToNum(i_892) * 0.14)))))))), "q", ToStr(Call(f1_19, V.Undef, ((V)((r_831 * 0.12))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((r_831 * 0.05))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((r_831 * 0.3))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(((-r_831) * 0.04))))), "\" stroke=\"#ffe58a\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((r_831 * 0.05))))), "\" fill=\"none\" stroke-linecap=\"round\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Call(rep_21, V.Undef, ((V)(3D)), Fn((V _arrowThis901, int _argc894, V i_900, V _a897, V _a898, V _a899, V[] _rest895) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)(((cx_829 - (r_831 * 0.3)) + ((ToNum(i_900) * r_831) * 0.3)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((cy_830 - (r_831 * 1.08)))))), "q", ToStr(Call(f1_19, V.Undef, ((V)(((-r_831) * 0.12))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(((-r_831) * 0.15))))), " 0 ", ToStr(Call(f1_19, V.Undef, ((V)(((-r_831) * 0.3))))), "t0 ", ToStr(Call(f1_19, V.Undef, ((V)(((-r_831) * 0.3))))), "\" stroke=\"#ffffff\" stroke-width=\"0.3\" fill=\"none\" opacity=\"0.7\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<rect width=\"", ToStr(Call(f1_19, V.Undef, w_826)), "\" height=\"", ToStr(Call(f1_19, V.Undef, h_827)), "\" fill=\"#ffe9b0\" opacity=\"0.16\"/></g><rect width=\"", ToStr(Call(f1_19, V.Undef, w_826)), "\" height=\"", ToStr(Call(f1_19, V.Undef, h_827)), "\" fill=\"none\" stroke=\"#cbbd9c\" stroke-width=\"0.3\"/>")).End()));
return default;
}, 3, "", true);
Set(N_12, "cal19", Fn((V _arrowThis909, int _argc902, V S_908, V _a905, V _a906, V _a907, V[] _rest903) => {
double W_910 = 0;
double Hh_911 = 0;
double PH_912 = 0;
double Y0_913 = 0;
double YT_914 = 0;
double X0_915 = 0;
V D_916 = default;
W_910 = 44D;
Hh_911 = 72D;
PH_912 = 29D;
Y0_913 = 6D;
YT_914 = (Y0_913 + Hh_911);
X0_915 = ((-W_910) / 2D);
D_916 = NewObj(5).Put("w", ((V)(56D))).Put("d", ((V)(4D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(44D))).Put("build", Fn((V _arrowThis923, int _argc917, V _a919, V _a920, V _a921, V _a922, V[] _rest918) => {
return Arr();
}, 0, "build", true)).V;
Set(D_916, "fx", Fn((V _arrowThis931, int _argc924, V ctx_930, V _a927, V _a928, V _a929, V[] _rest925) => {
V C_932 = default;
V d_933 = default;
V Yr_934 = default;
V Mo_935 = default;
V td_936 = default;
V f0_937 = default;
V nd_938 = default;
V mk_939 = default;
V p_940 = default;
double gy_941 = 0;
V pg_942 = default;
JsStrBuf g_943 = null;
double cw_944 = 0;
V cx_945 = default;
double rows_946 = 0;
V c1_947 = default;
V c2_948 = default;
V fl_949 = default;
V d1_950 = default;
V d2_951 = default;
double nx_952 = 0;
double ny_953 = 0;
V pen_954 = default;
V s_955 = default;
V pv_956 = default;
C_932 = Call(cam_15, V.Undef, ctx_930);
d_933 = New(G("Date"));
Yr_934 = Invoke(d_933, "getFullYear");
Mo_935 = Invoke(d_933, "getMonth");
td_936 = Invoke(d_933, "getDate");
f0_937 = Invoke(New(G("Date"), Yr_934, Mo_935, ((V)(1D))), "getDay");
nd_938 = Invoke(New(G("Date"), Yr_934, Add(Mo_935, ((V)(1D))), ((V)(0D))), "getDate");
mk_939 = New(G("Set"), Invoke(Invoke(Invoke(((V)(ToStrS((Get(S_908, "ex") is var _t957 && Truthy(_t957) ? _t957 : ((V)("")))))), "split", ((V)(","))), "filter", G("Boolean")), "map", G("Number")));
p_940 = Invoke(C_932, "u", ((V)("cl")));
gy_941 = (PH_912 + 1D);
pg_942 = ((V)(string.Concat("M0 ", NumStr(gy_941), "H", NumStr(W_910), "V", NumStr((Hh_911 - 6.5)), "L", NumStr((W_910 - 6.5)), " ", NumStr(Hh_911), "H0Z")));
g_943 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<rect x=\"0.8\" y=\"", NumStr((gy_941 + 0.5)), "\" width=\"", NumStr((W_910 - 0.3)), "\" height=\"", NumStr((Hh_911 - gy_941)), "\" fill=\"#d6c9ab\"/><rect x=\"0.4\" y=\"", NumStr((gy_941 + 0.25)), "\" width=\"", NumStr((W_910 - 0.1)), "\" height=\"", NumStr((Hh_911 - gy_941)), "\" fill=\"#e8ddc3\"/>")).S(string.Concat("<rect width=\"", NumStr(W_910), "\" height=\"", NumStr(PH_912), "\" fill=\"#f8f1de\"/><g transform=\"translate(2.2 2.2)\">", ToStr(Call(pizzaPhoto_54, V.Undef, p_940, ((V)((W_910 - 4.4))), ((V)((PH_912 - 8.4))))), "</g>")).V(Call(T_39, V.Undef, ((V)((W_910 / 2D))), ((V)((PH_912 - 3.3))), ((V)(3.2)), ((V)("#c8342a")), ((V)("SQUISH PIZZA")), ((V)("letter-spacing=\"0.2\"")))).V(Call(T_39, V.Undef, ((V)((W_910 / 2D))), ((V)((PH_912 - 1D))), ((V)(1.4)), ((V)("#6b5a48")), ((V)("FREE DELIVERY \u00b7 CALL 555-0199")))).S(string.Concat("<circle cx=\"", NumStr((W_910 / 2D)), "\" cy=\"1.8\" r=\"0.95\" fill=\"#4a3a28\" opacity=\"0.7\"/><rect width=\"", NumStr(W_910), "\" height=\"", NumStr(PH_912), "\" fill=\"#e8cf8a\" opacity=\"0.12\"/>")).S(string.Concat("<path d=\"", ToStr(pg_942), "\" fill=\"#fbf6e7\"/><rect x=\"1.4\" y=\"", NumStr((gy_941 + 1.4)), "\" width=\"", NumStr((W_910 - 2.8)), "\" height=\"4.8\" fill=\"#d9483b\"/>")).V(Call(T_39, V.Undef, ((V)((W_910 / 2D))), ((V)((gy_941 + 4.9))), ((V)(2.9)), ((V)("#ffffff")), ((V)(JsStrBuf.Begin().V(GetK(MONTHS_52, Mo_935)).S(" ").V(Yr_934).End())), ((V)("letter-spacing=\"0.25\"")))).End());
cw_944 = ((W_910 - 4D) / 7D);
cx_945 = Fn((V _arrowThis965, int _argc958, V i_964, V _a961, V _a962, V _a963, V[] _rest959) => {
return ((V)((2D + (cw_944 * ToNum(Add(i_964, ((V)(0.5))))))));
}, 1, "", true);
rows_946 = System.Math.Ceiling((ToNum(Add(f0_937, nd_938)) / 7D));
Invoke(Invoke(((V)("SMTWTFS")), "split", ((V)(""))), "forEach", Fn((V _arrowThis974, int _argc966, V w_972, V i_973, V _a970, V _a971, V[] _rest967) => {
return ((V)(g_943.V(Call(T_39, V.Undef, Call(cx_945, V.Undef, i_973), ((V)((gy_941 + 9.4))), ((V)(1.9)), ((V)((Truthy(i_973) ? "#6b4426" : "#d9483b"))), w_972)).Str));
}, 2, "", true));
{
double r_975 = 0;
r_975 = 0D;
while (true) {
if (!((r_975 <= rows_946))) break;
g_943.S(string.Concat("<path d=\"M2 ", ToStr(Call(f1_19, V.Undef, ((V)(((gy_941 + 10.5) + (r_975 * 4.5)))))), "H", NumStr(((r_975 == rows_946) ? (W_910 - 7D) : (W_910 - 2D))), "\" stroke=\"#ddcfae\" stroke-width=\"0.18\"/>"));
r_975++;
}
}
{
double i_977 = 0;
i_977 = 0D;
while (true) {
if (!(Lt(((V)(i_977)), nd_938))) break;
V cell_979 = default;
V x_980 = default;
double y_981 = 0;
double day_982 = 0;
cell_979 = Add(f0_937, ((V)(i_977)));
x_980 = Call(cx_945, V.Undef, ((V)((ToNum(cell_979) % 7D))));
y_981 = ((gy_941 + 13.9) + (System.Math.Floor((ToNum(cell_979) / 7D)) * 4.5));
day_982 = (i_977 + 1D);
if (SEqN(td_936, day_982)) {
g_943.S(string.Concat("<circle cx=\"", ToStr(Call(f1_19, V.Undef, x_980)), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((y_981 - 0.8))))), "\" r=\"2\" fill=\"none\" stroke=\"#d9483b\" stroke-width=\"0.5\">", ToStr(Call(an_16, V.Undef, ((V)("r")), ((V)("2;2.35;2")), ((V)(1.6)))), "</circle>"));
}
g_943.V(Call(T_39, V.Undef, x_980, ((V)(y_981)), ((V)(2.3)), ((V)((SEqN(td_936, day_982) ? "#d9483b" : "#3b2614"))), ((V)(day_982))));
if (Lt(((V)(day_982)), td_936)) {
g_943.S(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(x_980) - 1.5))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y_981 - 2.4))))), "L", ToStr(Call(f1_19, V.Undef, Add(x_980, ((V)(1.5))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y_981 + 0.5))))), "M", ToStr(Call(f1_19, V.Undef, Add(x_980, ((V)(1.4))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y_981 - 2.5))))), "L", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(x_980) - 1.4))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y_981 + 0.6))))), "\" stroke=\"#d9483b\" stroke-width=\"0.32\" stroke-linecap=\"round\" opacity=\"0.6\"/>"));
}
if (Truthy(Invoke(mk_939, "has", ((V)(day_982))))) {
g_943.S(string.Concat("<circle cx=\"", ToStr(Call(f1_19, V.Undef, Add(x_980, ((V)(1.9))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((y_981 - 2.6))))), "\" r=\"0.95\" fill=\"#3f9a5a\" stroke=\"#ffffff\" stroke-width=\"0.25\"/>"));
}
i_977++;
}
}
g_943.V(Call(T_39, V.Undef, ((V)(((W_910 / 2D) - 3D))), ((V)((Hh_911 - 1.2))), ((V)(1.6)), ((V)("#8a5a34")), ((V)(JsStrBuf.Begin().S("Today \u00b7 ").V(GetK(DAYS_53, Invoke(d_933, "getDay"))).S(" ").V(td_936).End()))));
g_943.S(string.Concat("<circle cx=\"", NumStr((W_910 * 0.72)), "\" cy=\"", NumStr((gy_941 + 23D)), "\" r=\"4\" fill=\"none\" stroke=\"#a0703c\" stroke-width=\"0.45\" opacity=\"0.22\" stroke-dasharray=\"16 2 5 1.5\"/>"));
g_943.V(Invoke(Call(rep_21, V.Undef, ((V)(12D)), Fn((V _arrowThis990, int _argc983, V i_989, V _a986, V _a987, V _a988, V[] _rest984) => {
double x_991 = 0;
x_991 = (3D + (ToNum(i_989) * 3.45));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((x_991 + 0.4))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((PH_912 - 1D))))), "\" rx=\"0.45\" ry=\"0.32\" fill=\"#4a3a28\"/><ellipse cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((x_991 + 0.4))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((gy_941 + 1.1))))), "\" rx=\"0.45\" ry=\"0.32\" fill=\"#4a3a28\"/><path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((x_991 + 0.4))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((gy_941 + 1.1))))), "C", ToStr(Call(f1_19, V.Undef, ((V)((x_991 - 1D))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((gy_941 + 0.5))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((x_991 - 1D))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((PH_912 - 0.4))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((x_991 + 0.4))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((PH_912 - 1D))))), "\" stroke=\"#6d747c\" stroke-width=\"0.55\" fill=\"none\"/><path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((x_991 + 0.1))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((gy_941 + 0.7))))), "C", ToStr(Call(f1_19, V.Undef, ((V)((x_991 - 0.6))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((gy_941 + 0.3))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((x_991 - 0.6))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((PH_912 - 0.1))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((x_991 + 0.1))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((PH_912 - 0.6))))), "\" stroke=\"#e6eaee\" stroke-width=\"0.16\" fill=\"none\"/>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
c1_947 = Arr(((V)((W_910 - 6.5))), ((V)(Hh_911)));
c2_948 = Arr(((V)(W_910)), ((V)((Hh_911 - 6.5))));
fl_949 = Fn((V _arrowThis1001, int _argc992, V t_998, V q1_999, V q2_1000, V _a997, V[] _rest993) => {
return ((V)(string.Concat("M", ToStr(Call(P2_22, V.Undef, c1_947)), "L", ToStr(Call(P2_22, V.Undef, c2_948)), "Q", ToStr(Call(P2_22, V.Undef, q1_999)), " ", ToStr(Call(P2_22, V.Undef, t_998)), "Q", ToStr(Call(P2_22, V.Undef, q2_1000)), " ", ToStr(Call(P2_22, V.Undef, c1_947)), "Z")));
}, 3, "", true);
d1_950 = Call(fl_949, V.Undef, Arr(((V)((W_910 - 5.6))), ((V)((Hh_911 - 5.6)))), Arr(((V)((W_910 - 2.6))), ((V)((Hh_911 - 5.2)))), Arr(((V)((W_910 - 5.2))), ((V)((Hh_911 - 2.6)))));
d2_951 = Call(fl_949, V.Undef, Arr(((V)((W_910 - 4.4))), ((V)((Hh_911 - 4.6)))), Arr(((V)((W_910 - 2D))), ((V)((Hh_911 - 4.2)))), Arr(((V)((W_910 - 4.2))), ((V)((Hh_911 - 2D)))));
g_943.S(string.Concat("<path d=\"", ToStr(d1_950), "\" fill=\"#000000\" opacity=\"0.25\" transform=\"translate(-0.5 -0.6)\" filter=\"url(#m12b1)\"/><path d=\"", ToStr(d1_950), "\" fill=\"#efe6cf\" stroke=\"#cbbd9c\" stroke-width=\"0.2\"><animate attributeName=\"d\" values=\"", ToStr(d1_950), ";", ToStr(d2_951), ";", ToStr(d1_950), "\" dur=\"3.8s\" repeatCount=\"indefinite\"", ToStr(Call(SPL_18, V.Undef, ((V)(2D)))), "/></path>"));
g_943.S(string.Concat("<path d=\"M0 0H", NumStr(W_910), "V", NumStr((Hh_911 - 6.5)), "L", NumStr((W_910 - 6.5)), " ", NumStr(Hh_911), "H0Z\" fill=\"url(#m12gl)\" opacity=\"0.5\"/>"));
nx_952 = (W_910 / 2D);
ny_953 = (-1.4);
pen_954 = ((V)(string.Concat("<path d=\"M", NumStr(nx_952), " ", NumStr(ny_953), "Q", NumStr((W_910 + 2.4)), " 8 ", NumStr((W_910 + 3.2)), " 24\" stroke=\"#bdb3a0\" stroke-width=\"0.24\" fill=\"none\"/><g transform=\"translate(", NumStr((W_910 + 2.4)), " 24)\"><rect width=\"1.6\" height=\"1.6\" rx=\"0.4\" fill=\"#ef8f9c\"/><rect y=\"1.5\" width=\"1.6\" height=\"1.2\" fill=\"#c9ccd0\"/><path d=\"M0 2.1H1.6\" stroke=\"#8a8f96\" stroke-width=\"0.15\"/><rect y=\"2.7\" width=\"1.6\" height=\"10.6\" fill=\"#f2c230\"/><rect x=\"0.55\" y=\"2.7\" width=\"0.5\" height=\"10.6\" fill=\"#ffdd6a\"/><rect x=\"1.2\" y=\"2.7\" width=\"0.4\" height=\"10.6\" fill=\"#d4a21a\"/><path d=\"M0 13.3H1.6L0.8 15.6Z\" fill=\"#ecc38a\"/><path d=\"M0.5 14.7H1.1L0.8 15.6Z\" fill=\"#3a3a3a\"/></g>")));
s_955 = Call(wsh_27, V.Undef, C_932, ((V)(X0_915)), ((V)(YT_914)), ((V)(W_910)), ((V)(Hh_911)), NewObj(3).Put("dx", ((V)(1.2))).Put("dy", ((V)(2.2))).Put("op", ((V)(0.36))).V);
s_955 = Add(s_955, Call(WD_26, V.Undef, C_932, ((V)(X0_915)), ((V)(YT_914)), ((V)(0.06)), ((V)(string.Concat("<g opacity=\"0.22\" filter=\"url(#m12b1)\" transform=\"translate(1 1.6)\">", ToStr(Invoke(Invoke(pen_954, "replace", NewRegExp(RX5, "fill=\"[^\"]*\"", "g"), ((V)("fill=\"#000000\""))), "replace", NewRegExp(RX4, "stroke=\"#bdb3a0\"", ""), ((V)("stroke=\"#000000\"")))), "</g>")))));
s_955 = Add(s_955, Call(WD_26, V.Undef, C_932, ((V)(X0_915)), ((V)(YT_914)), ((V)(0.7)), ((V)(g_943.Str)), ((V)(W_910)), ((V)(Hh_911))));
pv_956 = ((V)(string.Concat(ToStr(Call(f1_19, V.Undef, ((V)(nx_952)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(ny_953)))))));
s_955 = Add(s_955, Call(WD_26, V.Undef, C_932, ((V)(X0_915)), ((V)(YT_914)), ((V)(1.1)), ((V)(string.Concat("<g>", ToStr(Call(at_17, V.Undef, ((V)("rotate")), ((V)(string.Concat("-3 ", ToStr(pv_956), ";4 ", ToStr(pv_956), ";-3 ", ToStr(pv_956)))), ((V)(4.6)), ((V)(0D)), Call(SPL_18, V.Undef, ((V)(2D))))), ToStr(pen_954), "</g>")))));
Call(ext_24, V.Undef, C_932, Arr(Arr(((V)(((X0_915 + W_910) + 5D))), ((V)((YT_914 - 42D))), ((V)(1.1)))));
s_955 = Add(s_955, Add(Call(cyl3_35, V.Undef, C_932, Arr(((V)(0D)), ((V)((YT_914 + 1.4))), ((V)(0D))), Arr(((V)(0D)), ((V)((YT_914 + 1.4))), ((V)(1.8))), ((V)(0.35)), ((V)("#8a8f96"))), Call(sph_36, V.Undef, C_932, Arr(((V)(0D)), ((V)((YT_914 + 1.4))), ((V)(1.9))), ((V)(0.85)), ((V)("#9aa0a8")))));
return NewObj(3).Put("defs", DEF19_43).Put("front", s_955).Put("bb", Invoke(C_932, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_916;
return default;
}, 1, "", true));
Set(N_12, "rmir19", Fn((V _arrowThis1009, int _argc1002, V S_1008, V _a1005, V _a1006, V _a1007, V[] _rest1003) => {
double R0_1010 = 0;
double CY_1011 = 0;
V BR_1012 = default;
V LE_1013 = default;
double PY_1014 = 0;
V D_1015 = default;
R0_1010 = 19D;
CY_1011 = 30D;
BR_1012 = ((V)("#c99a3e"));
LE_1013 = ((V)("#7a4a26"));
PY_1014 = ((CY_1011 + R0_1010) + 13D);
D_1015 = NewObj(5).Put("w", ((V)(46D))).Put("d", ((V)(6D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(52D))).Put("build", Fn((V _arrowThis1022, int _argc1016, V _a1018, V _a1019, V _a1020, V _a1021, V[] _rest1017) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1015, "fx", Fn((V _arrowThis1030, int _argc1023, V ctx_1029, V _a1026, V _a1027, V _a1028, V[] _rest1024) => {
V C_1031 = default;
V id_1032 = default;
double top_1033 = 0;
V strap_1034 = default;
V s_1035 = default;
C_1031 = Call(cam_15, V.Undef, ctx_1029);
id_1032 = Invoke(C_1031, "u", ((V)("rm")));
top_1033 = (-((CY_1011 + R0_1010) - 4.5));
strap_1034 = ((V)(string.Concat("M-10.5 ", ToStr(Call(f1_19, V.Undef, ((V)(top_1033)))), "L0 ", NumStr((-PY_1014)), "L10.5 ", ToStr(Call(f1_19, V.Undef, ((V)(top_1033)))))));
s_1035 = Call(WD_26, V.Undef, C_1031, ((V)(0D)), ((V)(0D)), ((V)(0.06)), ((V)(string.Concat("<circle cx=\"1.6\" cy=\"", NumStr(((-CY_1011) + 2.6)), "\" r=\"", NumStr(R0_1010), "\" fill=\"#000000\" opacity=\"0.38\" filter=\"url(#m10b3)\"/><path d=\"", ToStr(strap_1034), "\" transform=\"translate(0.8 1.6)\" stroke=\"#000000\" stroke-width=\"3\" fill=\"none\" opacity=\"0.22\" stroke-linejoin=\"round\" filter=\"url(#m12b1)\"/>"))));
s_1035 = Add(s_1035, Call(WD_26, V.Undef, C_1031, ((V)(0D)), ((V)(0D)), ((V)(1.6)), ((V)(string.Concat("<path d=\"", ToStr(strap_1034), "\" stroke=\"", ToStr(LE_1013), "\" stroke-width=\"3.2\" fill=\"none\" stroke-linejoin=\"round\"/><path d=\"", ToStr(strap_1034), "\" stroke=\"", ToStr(Call(shade_11, V.Undef, LE_1013, ((V)(1.25)))), "\" stroke-width=\"2.2\" fill=\"none\" stroke-linejoin=\"round\"/><path d=\"", ToStr(strap_1034), "\" stroke=\"#f0d2a4\" stroke-width=\"0.22\" stroke-dasharray=\"0.8 0.6\" fill=\"none\" stroke-linejoin=\"round\" opacity=\"0.8\"/><path d=\"M-9 ", ToStr(Call(f1_19, V.Undef, ((V)((top_1033 - 1.4))))), "L-1.4 ", NumStr(((-PY_1014) + 1.6)), "\" stroke=\"#ffffff\" stroke-width=\"0.4\" opacity=\"0.25\"/>")))));
Call(ext_24, V.Undef, C_1031, Arr(Arr(((V)((-12D))), ((V)((PY_1014 + 2D))), ((V)(0D))), Arr(((V)(12D)), ((V)((CY_1011 - R0_1010))), ((V)(0D)))));
s_1035 = Add(s_1035, Add(Call(cyl3_35, V.Undef, C_1031, Arr(((V)(0D)), ((V)(PY_1014)), ((V)(0D))), Arr(((V)(0D)), ((V)(PY_1014)), ((V)(3.2))), ((V)(1.2)), BR_1012), Call(sph_36, V.Undef, C_1031, Arr(((V)(0D)), ((V)(PY_1014)), ((V)(3.6))), ((V)(1.9)), BR_1012)));
s_1035 = Add(s_1035, Call(cyl3_35, V.Undef, C_1031, Arr(((V)(0D)), ((V)(CY_1011)), ((V)(0.5))), Arr(((V)(0D)), ((V)(CY_1011)), ((V)(3.6))), ((V)(R0_1010)), BR_1012, NewObj(4).Put("mat", ((V)("gloss"))).Put("n", ((V)(44D))).Put("capCol", BR_1012).Put("cap", Fn((V _arrowThis1043, int _argc1036, V cr_1042, V _a1039, V _a1040, V _a1041, V[] _rest1037) => {
double rg_1044 = 0;
rg_1044 = (ToNum(cr_1042) * 0.84);
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><radialGradient id=\"", ToStr(id_1032), "r\" cx=\"35%\" cy=\"28%\" r=\"80%\"><stop offset=\"0\" stop-color=\"#fff2c4\"/><stop offset=\"0.45\" stop-color=\"#dcaa4c\"/><stop offset=\"1\" stop-color=\"#8a6420\"/></radialGradient><linearGradient id=\"", ToStr(id_1032), "g\" x1=\"0\" y1=\"0\" x2=\"0.35\" y2=\"1\"><stop offset=\"0\" stop-color=\"#eef3f4\"/><stop offset=\"0.5\" stop-color=\"#c3cfd4\"/><stop offset=\"1\" stop-color=\"#93a3aa\"/></linearGradient><linearGradient id=\"", ToStr(id_1032), "s\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient><clipPath id=\"", ToStr(id_1032), "c\"><circle r=\"", ToStr(Call(f1_19, V.Undef, ((V)(rg_1044)))), "\"/></clipPath></defs>")).S(string.Concat("<circle r=\"", ToStr(Call(f1_19, V.Undef, cr_1042)), "\" fill=\"url(#", ToStr(id_1032), "r)\"/><circle r=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(cr_1042) * 0.955))))), "\" fill=\"none\" stroke=\"#fff3c8\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(cr_1042) * 0.02))))), "\" opacity=\"0.75\"/><circle r=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(cr_1042) * 0.885))))), "\" fill=\"none\" stroke=\"#7a5418\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(cr_1042) * 0.035))))), "\"/>")).S(string.Concat("<g clip-path=\"url(#", ToStr(id_1032), "c)\"><circle r=\"", ToStr(Call(f1_19, V.Undef, ((V)(rg_1044)))), "\" fill=\"url(#", ToStr(id_1032), "g)\"/><rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)((-rg_1044))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)((-rg_1044))))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)((2D * rg_1044))))), "\" height=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 1.15))))), "\" fill=\"#e9dcc0\" opacity=\"0.4\"/><rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)((-rg_1044))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.18))))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)((2D * rg_1044))))), "\" height=\"", ToStr(Call(f1_19, V.Undef, ((V)(rg_1044)))), "\" fill=\"#b98a58\" opacity=\"0.4\"/>")).S(string.Concat("<rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.72))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.82))))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.5))))), "\" height=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.72))))), "\" fill=\"#ffffff\" opacity=\"0.6\"/><path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.47))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.82))))), "V", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.1))))), "M", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.72))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.46))))), "H", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.22))))), "\" stroke=\"#d9cdb4\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.04))))), "\"/>")).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.4))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.35))))), "\" rx=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.32))))), "\" ry=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.2))))), "\" fill=\"#7f9a6e\" opacity=\"0.4\"/><g transform=\"rotate(28)\"><rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 2D))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 1.4))))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.4))))), "\" height=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 2.8))))), "\" fill=\"url(#", ToStr(id_1032), "s)\">", ToStr(Call(at_17, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 0;", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 3.6))))), " 0"))), ((V)(7.5)), ((V)(0D)), ((V)(" keyTimes=\"0;0.5;1\"")))), "</rect></g>")).S(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.75))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.2))))), "A", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.78))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.78))))), " 0 0 1 ", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.2))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(((-rg_1044) * 0.75))))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.05))))), "\" fill=\"none\" opacity=\"0.55\" stroke-linecap=\"round\"/></g>")).S(string.Concat("<circle r=\"", ToStr(Call(f1_19, V.Undef, ((V)(rg_1044)))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.04))))), "\" opacity=\"0.6\"/><circle r=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.97))))), "\" fill=\"none\" stroke=\"#5a6a70\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((rg_1044 * 0.015))))), "\" opacity=\"0.5\"/>")).End()));
return default;
}, 1, "cap", true)).V));
return NewObj(3).Put("defs", DEF19_43).Put("front", s_1035).Put("bb", Invoke(C_1031, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1015;
return default;
}, 1, "", true));
triArt_55 = Fn((V _arrowThis1051, int _argc1045, V _a1047, V _a1048, V _a1049, V _a1050, V[] _rest1046) => {
V R_1052 = default;
V imp_1053 = default;
JsStrBuf s_1054 = null;
R_1052 = Call(rng_23, V.Undef, ((V)("tri19")));
imp_1053 = Fn((V _arrowThis1066, int _argc1055, V x_1061, V y_1062, V l_1063, V a_1064, V[] _rest1056) => {
double dx_1067 = 0;
double dy_1068 = 0;
V d_1069 = default;
V col_1065 = default;
col_1065 = (_argc1055 > 4 ? _rest1056[0] : V.Undef);
dx_1067 = (ToNum(l_1063) * FdLibm.Cos(ToNum(a_1064)));
dy_1068 = (ToNum(l_1063) * FdLibm.Sin(ToNum(a_1064)));
d_1069 = ((V)(string.Concat("M", ToStr(Call(f1_19, V.Undef, x_1061)), " ", ToStr(Call(f1_19, V.Undef, y_1062)), "q", ToStr(Call(f1_19, V.Undef, ((V)(((dx_1067 / 2D) - (dy_1068 * 0.2)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(((dy_1068 / 2D) + (dx_1067 * 0.2)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)(dx_1067)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(dy_1068)))))));
return ((V)(string.Concat("<path d=\"", ToStr(d_1069), "\" stroke=\"#000000\" stroke-opacity=\"0.2\" stroke-width=\"1.5\" fill=\"none\" stroke-linecap=\"round\" transform=\"translate(0.3 0.35)\"/><path d=\"", ToStr(d_1069), "\" stroke=\"", ToStr(col_1065), "\" stroke-width=\"1.35\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"", ToStr(d_1069), "\" stroke=\"#ffffff\" stroke-opacity=\"0.4\" stroke-width=\"0.4\" fill=\"none\" stroke-linecap=\"round\" transform=\"translate(-0.25 -0.3)\"/>")));
return default;
}, 5, "", true);
s_1054 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"100\" height=\"44\" fill=\"#efe5d1\"/>").V(Invoke(Call(rep_21, V.Undef, ((V)(46D)), Fn((V _arrowThis1076, int _argc1070, V _a1072, V _a1073, V _a1074, V _a1075, V[] _rest1071) => {
double x_1077 = 0;
double y_1078 = 0;
double l_1079 = 0;
double a_1080 = 0;
x_1077 = (ToNum(Call(R_1052, V.Undef)) * 100D);
y_1078 = (ToNum(Call(R_1052, V.Undef)) * 44D);
l_1079 = (3D + (ToNum(Call(R_1052, V.Undef)) * 6D));
a_1080 = ((ToNum(Call(R_1052, V.Undef)) - 0.5) * 0.6);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)(x_1077)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(y_1078)))), "l", ToStr(Call(f1_19, V.Undef, ((V)((l_1079 * FdLibm.Cos(a_1080)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((l_1079 * FdLibm.Sin(a_1080)))))), "\" stroke=\"", (LtN(Call(R_1052, V.Undef), 0.5) ? "#f8f0e1" : "#dfd2b8"), "\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((0.6 + (ToNum(Call(R_1052, V.Undef)) * 0.9)))))), "\" stroke-linecap=\"round\" opacity=\"0.75\"/>")));
return default;
}, 0, "", true)), "join", ((V)("")))).End());
s_1054.S("<rect x=\"64\" y=\"21\" width=\"32\" height=\"23\" fill=\"#d6a03c\"/><path d=\"M5 44A25 25 0 0 1 55 44Z\" fill=\"#c25f3b\"/><path d=\"M14 44A16 16 0 0 1 46 44\" fill=\"none\" stroke=\"#e48f69\" stroke-width=\"3\"/><circle cx=\"58\" cy=\"15\" r=\"10\" fill=\"#8ca584\"/><circle cx=\"84\" cy=\"11\" r=\"4.4\" fill=\"#e7b39e\"/><path d=\"M76 34H100\" stroke=\"#efe5d1\" stroke-width=\"1.2\"/>");
{
double i_1081 = 0;
i_1081 = 0D;
while (true) {
if (!((i_1081 < 14D))) break;
double th_1083 = 0;
double rr_1084 = 0;
th_1083 = (PI_14 + (ToNum(Call(R_1052, V.Undef)) * PI_14));
rr_1084 = (5D + (ToNum(Call(R_1052, V.Undef)) * 18D));
s_1054.V(Call(imp_1053, V.Undef, ((V)((30D + (rr_1084 * FdLibm.Cos(th_1083))))), ((V)((44D + (rr_1084 * FdLibm.Sin(th_1083))))), ((V)((2.4 + (ToNum(Call(R_1052, V.Undef)) * 3D)))), ((V)((th_1083 + (PI_14 / 2D)))), Call(shade_11, V.Undef, ((V)("#c25f3b")), ((V)((0.88 + (ToNum(Call(R_1052, V.Undef)) * 0.3)))))));
i_1081++;
}
}
{
double i_1085 = 0;
i_1085 = 0D;
while (true) {
if (!((i_1085 < 8D))) break;
double th_1087 = 0;
double rr_1088 = 0;
th_1087 = ((ToNum(Call(R_1052, V.Undef)) * 2D) * PI_14);
rr_1088 = (ToNum(Call(R_1052, V.Undef)) * 8D);
s_1054.V(Call(imp_1053, V.Undef, ((V)((58D + (rr_1088 * FdLibm.Cos(th_1087))))), ((V)((15D + (rr_1088 * FdLibm.Sin(th_1087))))), ((V)((2D + (ToNum(Call(R_1052, V.Undef)) * 2.4)))), ((V)((th_1087 + (PI_14 / 2D)))), Call(shade_11, V.Undef, ((V)("#8ca584")), ((V)((0.88 + (ToNum(Call(R_1052, V.Undef)) * 0.3)))))));
i_1085++;
}
}
{
double i_1089 = 0;
i_1089 = 0D;
while (true) {
if (!((i_1089 < 9D))) break;
s_1054.V(Call(imp_1053, V.Undef, ((V)((66D + (ToNum(Call(R_1052, V.Undef)) * 26D)))), ((V)((23D + (ToNum(Call(R_1052, V.Undef)) * 18D)))), ((V)((3D + (ToNum(Call(R_1052, V.Undef)) * 3D)))), ((V)(((ToNum(Call(R_1052, V.Undef)) - 0.5) * 0.5))), Call(shade_11, V.Undef, ((V)("#d6a03c")), ((V)((0.86 + (ToNum(Call(R_1052, V.Undef)) * 0.3)))))));
i_1089++;
}
}
s_1054.S("<path d=\"M3 11C30 2 50 31 97 15\" fill=\"none\" stroke=\"#2c3b5a\" stroke-width=\"1.15\" stroke-linecap=\"round\"/><path d=\"M3 11C30 2 50 31 97 15\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.3\" stroke-opacity=\"0.35\" transform=\"translate(-0.2 -0.3)\"/>");
s_1054.V(Add(Invoke(Call(rep_21, V.Undef, ((V)(9D)), Fn((V _arrowThis1097, int _argc1091, V _a1093, V _a1094, V _a1095, V _a1096, V[] _rest1092) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_1052, V.Undef)) * 100D))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_1052, V.Undef)) * 44D))))), "l0.9 -0.4l0.5 0.8l-0.8 0.5Z\" fill=\"#e8c35a\"/>")));
}, 0, "", true)), "join", ((V)(""))), Invoke(Call(rep_21, V.Undef, ((V)(12D)), Fn((V _arrowThis1104, int _argc1098, V _a1100, V _a1101, V _a1102, V _a1103, V[] _rest1099) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_1052, V.Undef)) * 100D))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_1052, V.Undef)) * 44D))))), "\" r=\"", ToStr(Call(f1_19, V.Undef, ((V)((0.25 + (ToNum(Call(R_1052, V.Undef)) * 0.35)))))), "\" fill=\"#2c3b5a\" opacity=\"0.8\"/>")));
}, 0, "", true)), "join", ((V)("")))));
return ((V)(string.Concat(s_1054.Str, "<rect width=\"100\" height=\"44\" fill=\"url(#tw19)\"/>")));
return default;
}, 0, "", true);
Set(N_12, "trip19", Fn((V _arrowThis1112, int _argc1105, V S_1111, V _a1108, V _a1109, V _a1110, V[] _rest1106) => {
V FS_1113 = default;
double CW_1114 = 0;
double Hh_1115 = 0;
double Y0_1116 = 0;
double DP_1117 = 0;
V D_1118 = default;
FS_1113 = Arr(((V)((-35D))), ((V)(0D)), ((V)(35D)));
CW_1114 = 30D;
Hh_1115 = 44D;
Y0_1116 = 6D;
DP_1117 = 3.2;
D_1118 = NewObj(5).Put("w", ((V)(108D))).Put("d", ((V)(6D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(46D))).Put("build", Fn((V _arrowThis1125, int _argc1119, V _a1121, V _a1122, V _a1123, V _a1124, V[] _rest1120) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1118, "fx", Fn((V _arrowThis1133, int _argc1126, V ctx_1132, V _a1129, V _a1130, V _a1131, V[] _rest1127) => {
V C_1134 = default;
V aid_1135 = default;
V art_1136 = default;
JsStrBuf s_1137 = null;
JsStrBuf defs_1138 = null;
C_1134 = Call(cam_15, V.Undef, ctx_1132);
aid_1135 = Invoke(C_1134, "u", ((V)("ta")));
art_1136 = ((V)(string.Concat("<use href=\"#", ToStr(aid_1135), "\"/>")));
s_1137 = new JsStrBuf("");
defs_1138 = new JsStrBuf(string.Concat("<g id=\"", ToStr(aid_1135), "\">", ToStr(Call(triArt_55, V.Undef)), "</g>"));
Invoke(FS_1113, "forEach", Fn((V _arrowThis1147, int _argc1139, V x_1145, V i_1146, V _a1143, V _a1144, V[] _rest1140) => {
double ox_1148 = 0;
V p_1149 = default;
V sideCol_1150 = default;
V face_1151 = default;
V sideR_1152 = default;
V sideL_1153 = default;
V topF_1154 = default;
ox_1148 = (ToNum(i_1146) * 35D);
p_1149 = Invoke(C_1134, "u", ((V)("tc")));
sideCol_1150 = ((V)("#000000"));
defs_1138.S(string.Concat("<clipPath id=\"", ToStr(p_1149), "\"><rect width=\"", NumStr(CW_1114), "\" height=\"", NumStr(Hh_1115), "\"/></clipPath><clipPath id=\"", ToStr(p_1149), "s\"><rect width=\"", NumStr(DP_1117), "\" height=\"", NumStr(Hh_1115), "\"/></clipPath><clipPath id=\"", ToStr(p_1149), "t\"><rect width=\"", NumStr(CW_1114), "\" height=\"", NumStr(DP_1117), "\"/></clipPath>"));
face_1151 = ((V)(string.Concat("<g clip-path=\"url(#", ToStr(p_1149), ")\"><g transform=\"translate(", NumStr((-ox_1148)), " 0)\">", ToStr(art_1136), "</g></g><rect width=\"", NumStr(CW_1114), "\" height=\"", NumStr(Hh_1115), "\" fill=\"url(#m12gl)\" opacity=\"0.35\"/>")));
sideR_1152 = ((V)(string.Concat("<g clip-path=\"url(#", ToStr(p_1149), "s)\"><g transform=\"matrix(", NumStr((-DP_1117)), " 0 0 1 ", ToStr(Call(f1_19, V.Undef, ((V)(((ox_1148 + CW_1114) * DP_1117))))), " 0)\">", ToStr(art_1136), "</g></g><rect width=\"", NumStr(DP_1117), "\" height=\"", NumStr(Hh_1115), "\" fill=\"", ToStr(sideCol_1150), "\" opacity=\"0.16\"/>")));
sideL_1153 = ((V)(string.Concat("<g clip-path=\"url(#", ToStr(p_1149), "s)\"><g transform=\"matrix(", NumStr((-DP_1117)), " 0 0 1 ", ToStr(Call(f1_19, V.Undef, ((V)(((ox_1148 + 1D) * DP_1117))))), " 0)\">", ToStr(art_1136), "</g></g><rect width=\"", NumStr(DP_1117), "\" height=\"", NumStr(Hh_1115), "\" fill=\"", ToStr(sideCol_1150), "\" opacity=\"0.28\"/>")));
topF_1154 = ((V)(string.Concat("<g clip-path=\"url(#", ToStr(p_1149), "t)\"><g transform=\"matrix(1 0 0 ", NumStr((-DP_1117)), " ", NumStr((-ox_1148)), " ", NumStr(DP_1117), ")\">", ToStr(art_1136), "</g></g><rect width=\"", NumStr(CW_1114), "\" height=\"", NumStr(DP_1117), "\" fill=\"#ffffff\" opacity=\"0.12\"/>")));
s_1137.V(Call(wsh_27, V.Undef, C_1134, ((V)((ToNum(x_1145) - (CW_1114 / 2D)))), ((V)((Y0_1116 + Hh_1115))), ((V)(CW_1114)), ((V)(Hh_1115)), NewObj(3).Put("dx", ((V)(1.8))).Put("dy", ((V)(2.8))).Put("op", ((V)(0.42))).V));
s_1137.V(Call(box3_34, V.Undef, C_1134, NewObj(7).Put("c", Arr(x_1145, ((V)(Y0_1116)), ((V)((DP_1117 / 2D))))).Put("w", ((V)(CW_1114))).Put("h", ((V)(Hh_1115))).Put("d", ((V)(DP_1117))).Put("r", ((V)(0.2))).Put("col", ((V)("#e7dcc6"))).Put("dec", NewObj(4).Put("f", face_1151).Put("r", sideR_1152).Put("l", sideL_1153).Put("t", topF_1154).V).V));
return default;
}, 2, "", true));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(DEF19_43).S(string.Concat("<defs>", defs_1138.Str, "</defs>")).End()))).Put("front", ((V)(s_1137.Str))).Put("bb", Invoke(C_1134, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1118;
return default;
}, 1, "", true));
archPts_56 = Fn((V _arrowThis1166, int _argc1155, V x0_1161, V y0_1162, V w_1163, V h_1164, V[] _rest1156) => {
double r_1167 = 0;
double L_1168 = 0;
double A_1169 = 0;
double tot_1170 = 0;
V n_1165 = default;
n_1165 = (_argc1155 > 4 ? _rest1156[0] : V.Undef);
r_1167 = (ToNum(w_1163) / 2D);
L_1168 = (ToNum(h_1164) - r_1167);
A_1169 = (PI_14 * r_1167);
tot_1170 = ((2D * L_1168) + A_1169);
return Call(rep_21, V.Undef, Add(n_1165, ((V)(1D))), Fn((V _arrowThis1178, int _argc1171, V i_1177, V _a1174, V _a1175, V _a1176, V[] _rest1172) => {
double s_1179 = 0;
s_1179 = ((tot_1170 * ToNum(i_1177)) / ToNum(n_1165));
if ((s_1179 <= L_1168)) {
return Arr(x0_1161, ((V)((ToNum(Add(y0_1162, h_1164)) - s_1179))));
}
if ((s_1179 <= (L_1168 + A_1169))) {
double a_1180 = 0;
a_1180 = (PI_14 - ((s_1179 - L_1168) / r_1167));
return Arr(Add(Add(x0_1161, ((V)(r_1167))), ((V)((r_1167 * FdLibm.Cos(a_1180))))), ((V)((ToNum(Add(y0_1162, ((V)(r_1167)))) - (r_1167 * FdLibm.Sin(a_1180))))));
}
return Arr(Add(x0_1161, w_1163), Add(Add(y0_1162, ((V)(r_1167))), ((V)(((s_1179 - L_1168) - A_1169)))));
return default;
}, 1, "", true));
return default;
}, 5, "", true);
archD_57 = Fn((V _arrowThis1191, int _argc1181, V x0_1187, V y0_1188, V w_1189, V h_1190, V[] _rest1182) => {
return ((V)(string.Concat("M", ToStr(Call(f1_19, V.Undef, x0_1187)), " ", ToStr(Call(f1_19, V.Undef, Add(y0_1188, h_1190))), "V", ToStr(Call(f1_19, V.Undef, Add(y0_1188, ((V)((ToNum(w_1189) / 2D)))))), "A", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(w_1189) / 2D))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(w_1189) / 2D))))), " 0 0 1 ", ToStr(Call(f1_19, V.Undef, Add(x0_1187, w_1189))), " ", ToStr(Call(f1_19, V.Undef, Add(y0_1188, ((V)((ToNum(w_1189) / 2D)))))), "V", ToStr(Call(f1_19, V.Undef, Add(y0_1188, h_1190))), "Z")));
}, 4, "", true);
Set(N_12, "venet19", Fn((V _arrowThis1199, int _argc1192, V S_1198, V _a1195, V _a1196, V _a1197, V[] _rest1193) => {
double W_1200 = 0;
double Hh_1201 = 0;
double Y0_1202 = 0;
double BW_1203 = 0;
double X0_1204 = 0;
double YT_1205 = 0;
V D_1206 = default;
W_1200 = 52D;
Hh_1201 = 74D;
Y0_1202 = 6D;
BW_1203 = 7.5;
X0_1204 = ((-W_1200) / 2D);
YT_1205 = (Y0_1202 + Hh_1201);
D_1206 = NewObj(5).Put("w", ((V)(58D))).Put("d", ((V)(8D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(46D))).Put("build", Fn((V _arrowThis1213, int _argc1207, V _a1209, V _a1210, V _a1211, V _a1212, V[] _rest1208) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1206, "fx", Fn((V _arrowThis1221, int _argc1214, V ctx_1220, V _a1217, V _a1218, V _a1219, V[] _rest1215) => {
V C_1222 = default;
V id_1223 = default;
V oD_1224 = default;
V iD_1225 = default;
double n_1226 = 0;
V Po_1227 = default;
V Pi_1228 = default;
V s_1229 = default;
JsStrBuf seg_1230 = null;
V crest_1231 = default;
double fs_1232 = 0;
double tw_1233 = 0;
double ty_1234 = 0;
V txt_1235 = default;
V heart_1236 = default;
V FLK_1237 = default;
C_1222 = Call(cam_15, V.Undef, ctx_1220);
id_1223 = Invoke(C_1222, "u", ((V)("vn")));
oD_1224 = Call(archD_57, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(W_1200)), ((V)(Hh_1201)));
iD_1225 = Call(archD_57, V.Undef, ((V)(BW_1203)), ((V)(BW_1203)), ((V)((W_1200 - (2D * BW_1203)))), ((V)((Hh_1201 - (2D * BW_1203)))));
n_1226 = 22D;
Po_1227 = Call(archPts_56, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(W_1200)), ((V)(Hh_1201)), ((V)(n_1226)));
Pi_1228 = Call(archPts_56, V.Undef, ((V)(BW_1203)), ((V)(BW_1203)), ((V)((W_1200 - (2D * BW_1203)))), ((V)((Hh_1201 - (2D * BW_1203)))), ((V)(n_1226)));
s_1229 = Call(WD_26, V.Undef, C_1222, ((V)((X0_1204 - 12D))), ((V)((YT_1205 + 12D))), ((V)(0.05)), ((V)(string.Concat("<rect width=\"", NumStr((W_1200 + 24D)), "\" height=\"", NumStr((Hh_1201 + 24D)), "\" rx=\"26\" fill=\"#ff4fa0\" opacity=\"0.32\" filter=\"url(#m11b8)\">", ToStr(Call(an_16, V.Undef, ((V)("opacity")), ((V)("0.24;0.38;0.26;0.36;0.24")), ((V)(3.4)))), "</rect>"))));
s_1229 = Add(s_1229, Call(WD_26, V.Undef, C_1222, ((V)(X0_1204)), ((V)(YT_1205)), ((V)(0.06)), ((V)(string.Concat("<path d=\"", ToStr(oD_1224), "\" fill=\"#000000\" opacity=\"0.4\" transform=\"translate(1.4 2.2)\" filter=\"url(#m12b1)\"/>")))));
Invoke(Arr(((V)(0.3)), ((V)(0.7))), "forEach", Fn((V _arrowThis1246, int _argc1238, V z_1244, V i_1245, V _a1242, V _a1243, V[] _rest1239) => {
return (s_1229 = Add(s_1229, Call(WD_26, V.Undef, C_1222, ((V)(X0_1204)), ((V)(YT_1205)), z_1244, ((V)(string.Concat("<path d=\"", ToStr(oD_1224), "\" fill=\"", (Truthy(i_1245) ? "#5f666c" : "#3c4146"), "\"/>"))))));
}, 2, "", true));
seg_1230 = new JsStrBuf(string.Concat(string.Concat("<defs><linearGradient id=\"", ToStr(id_1223), "a\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#f4f8fa\"/><stop offset=\"0.5\" stop-color=\"#b9c6cc\"/><stop offset=\"1\" stop-color=\"#e3eaee\"/></linearGradient><linearGradient id=\"", ToStr(id_1223), "b\" x1=\"1\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#d8e2e6\"/><stop offset=\"0.5\" stop-color=\"#93a4ac\"/><stop offset=\"1\" stop-color=\"#c6d2d7\"/></linearGradient>"), string.Concat("<linearGradient id=\"", ToStr(id_1223), "m\" x1=\"0\" y1=\"0\" x2=\"0.4\" y2=\"1\"><stop offset=\"0\" stop-color=\"#e6edf0\"/><stop offset=\"0.55\" stop-color=\"#b6c4cb\"/><stop offset=\"1\" stop-color=\"#8f9fa7\"/></linearGradient><radialGradient id=\"", ToStr(id_1223), "p\" cx=\"50%\" cy=\"55%\" r=\"60%\"><stop offset=\"0\" stop-color=\"#ff7fbf\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#ff7fbf\" stop-opacity=\"0\"/></radialGradient>"), string.Concat("<linearGradient id=\"", ToStr(id_1223), "s\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient><clipPath id=\"", ToStr(id_1223), "c\"><path d=\"", ToStr(iD_1225), "\"/></clipPath></defs>")));
{
double i_1247 = 0;
i_1247 = 0D;
while (true) {
if (!((i_1247 < n_1226))) break;
V a_1249 = default;
V b_1250 = default;
V c_1251 = default;
V e_1252 = default;
V m_1253 = default;
a_1249 = GetIdx(Po_1227, i_1247);
b_1250 = GetIdx(Po_1227, (i_1247 + 1D));
c_1251 = GetIdx(Pi_1228, (i_1247 + 1D));
e_1252 = GetIdx(Pi_1228, i_1247);
m_1253 = Arr(((V)((ToNum(Add(Add(Add(GetIdx(a_1249, 0D), GetIdx(b_1250, 0D)), GetIdx(c_1251, 0D)), GetIdx(e_1252, 0D))) / 4D))), ((V)((ToNum(Add(Add(Add(GetIdx(a_1249, 1D), GetIdx(b_1250, 1D)), GetIdx(c_1251, 1D)), GetIdx(e_1252, 1D))) / 4D))));
seg_1230.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, a_1249)), "L", ToStr(Call(P2_22, V.Undef, b_1250)), "L", ToStr(Call(P2_22, V.Undef, c_1251)), "L", ToStr(Call(P2_22, V.Undef, e_1252)), "Z\" fill=\"url(#", ToStr(id_1223), (NumTruthy((i_1247 % 2D)) ? "a" : "b"), ")\" stroke=\"#6f7c84\" stroke-width=\"0.22\"/><path d=\"M", ToStr(Call(P2_22, V.Undef, a_1249)), "L", ToStr(Call(P2_22, V.Undef, b_1250)), "\" stroke=\"#ffffff\" stroke-width=\"0.35\" opacity=\"0.8\"/>")).S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, m_1253)), ")\" stroke=\"#ffffff\" stroke-width=\"0.22\" fill=\"none\" opacity=\"0.75\"><path d=\"M0 -1.6Q1 0 0 1.6Q-1 0 0 -1.6ZM-1.6 0Q0 1 1.6 0Q0 -1 -1.6 0Z\"/><circle r=\"0.35\"/></g>"));
i_1247++;
}
}
seg_1230.S(string.Concat("<g clip-path=\"url(#", ToStr(id_1223), "c)\"><path d=\"", ToStr(iD_1225), "\" fill=\"url(#", ToStr(id_1223), "m)\"/><rect x=\"", NumStr(BW_1203), "\" y=\"", NumStr((Hh_1201 * 0.55)), "\" width=\"", NumStr((W_1200 - (2D * BW_1203))), "\" height=\"", NumStr((Hh_1201 * 0.45)), "\" fill=\"#c9a77a\" opacity=\"0.28\"/><rect width=\"", NumStr(W_1200), "\" height=\"", NumStr(Hh_1201), "\" fill=\"url(#", ToStr(id_1223), "p)\"/>")).S(string.Concat("<g transform=\"rotate(24)\"><rect x=\"-40\" y=\"-20\" width=\"9\" height=\"", NumStr((Hh_1201 + 40D)), "\" fill=\"url(#", ToStr(id_1223), "s)\">", ToStr(Call(at_17, V.Undef, ((V)("translate")), ((V)("0 0;0 0;80 0")), ((V)(8D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.55;1\"")))), "</rect></g></g>")).S(string.Concat("<path d=\"", ToStr(iD_1225), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.7\"/><path d=\"", ToStr(Call(archD_57, V.Undef, ((V)((BW_1203 + 1.6))), ((V)((BW_1203 + 1.6))), ((V)(((W_1200 - (2D * BW_1203)) - 3.2))), ((V)(((Hh_1201 - (2D * BW_1203)) - 3.2))))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.25\" stroke-dasharray=\"0.5 0.8\" opacity=\"0.7\"/>")).S(string.Concat("<path d=\"", ToStr(oD_1224), "\" fill=\"none\" stroke=\"#56636a\" stroke-width=\"0.4\"/>"));
s_1229 = Add(s_1229, Call(WD_26, V.Undef, C_1222, ((V)(X0_1204)), ((V)(YT_1205)), ((V)(1.1)), ((V)(seg_1230.Str)), ((V)(W_1200)), ((V)(Hh_1201))));
crest_1231 = ((V)(string.Concat("M", NumStr(((W_1200 / 2D) - 9D)), " 3Q", NumStr(((W_1200 / 2D) - 8D)), " -3 ", NumStr(((W_1200 / 2D) - 4D)), " -2Q", NumStr(((W_1200 / 2D) - 3D)), " -7 ", NumStr((W_1200 / 2D)), " -7.6Q", NumStr(((W_1200 / 2D) + 3D)), " -7 ", NumStr(((W_1200 / 2D) + 4D)), " -2Q", NumStr(((W_1200 / 2D) + 8D)), " -3 ", NumStr(((W_1200 / 2D) + 9D)), " 3Z")));
s_1229 = Add(s_1229, Call(WD_26, V.Undef, C_1222, ((V)(X0_1204)), ((V)(YT_1205)), ((V)(1.3)), ((V)(string.Concat("<path d=\"", ToStr(crest_1231), "\" fill=\"url(#", ToStr(id_1223), "a)\" stroke=\"#6f7c84\" stroke-width=\"0.25\"/><path d=\"M", NumStr(((W_1200 / 2D) - 4D)), " -2Q", NumStr((W_1200 / 2D)), " 0 ", NumStr(((W_1200 / 2D) + 4D)), " -2M", NumStr((W_1200 / 2D)), " -6.4V-1\" stroke=\"#ffffff\" stroke-width=\"0.3\" fill=\"none\" opacity=\"0.8\"/>")))));
Call(ext_24, V.Undef, C_1222, Arr(Arr(((V)(0D)), ((V)((YT_1205 + 8D))), ((V)(1.3)))));
Invoke(Invoke(Po_1227, "filter", Fn((V _arrowThis1270, int _argc1262, V q_1268, V i_1269, V _a1266, V _a1267, V[] _rest1263) => {
return (((ToNum(i_1269) % 2D) == 0D) ? V.True : V.False);
}, 2, "", true)), "forEach", Fn((V _arrowThis1261, int _argc1254, V q_1260, V _a1257, V _a1258, V _a1259, V[] _rest1255) => {
return (s_1229 = Add(s_1229, Call(sph_36, V.Undef, C_1222, Arr(Add(((V)(X0_1204)), GetIdx(q_1260, 0D)), ((V)((YT_1205 - ToNum(GetIdx(q_1260, 1D))))), ((V)(1.5))), ((V)(0.8)), ((V)("#dfe8ec")))));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-12D))), ((V)(30D))), Arr(((V)(12D)), ((V)(30D))), Arr(((V)((-12D))), ((V)(58D))), Arr(((V)(12D)), ((V)(58D)))), "forEach", Fn((V _arrowThis1282, int _argc1271, V _a1273, V _a1274, V _a1275, V _a1276, V[] _rest1272) => {
V x_1279 = default;
V y_1281 = default;
{ V _t1277 = ListOf(_a1273);
{ V _t1278 = GetIdx(_t1277, 0D);
x_1279 = _t1278; }
{ V _t1280 = GetIdx(_t1277, 1D);
y_1281 = _t1280; }
}
return (s_1229 = Add(s_1229, Call(cyl3_35, V.Undef, C_1222, Arr(x_1279, Add(((V)(Y0_1202)), y_1281), ((V)(1.2))), Arr(x_1279, Add(((V)(Y0_1202)), y_1281), ((V)(3.3))), ((V)(0.5)), ((V)("#d9dce0")))));
}, 1, "", true));
fs_1232 = 10.5;
tw_1233 = ((W_1200 - (2D * BW_1203)) - 4D);
ty_1234 = (Hh_1201 * 0.52);
txt_1235 = Fn((V _arrowThis1291, int _argc1283, V st_1289, V ex_1290, V _a1287, V _a1288, V[] _rest1284) => {
return ((V)(string.Concat("<text x=\"", NumStr((W_1200 / 2D)), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)(ty_1234)))), "\" text-anchor=\"middle\" font-family=\"", ToStr(SCRIPT_40), "\" font-size=\"", NumStr(fs_1232), "\" textLength=\"", ToStr(Call(f1_19, V.Undef, ((V)(tw_1233)))), "\" lengthAdjust=\"spacingAndGlyphs\" ", ToStr(st_1289), ">", ToStr((ex_1290 is var _t1292 && Truthy(_t1292) ? _t1292 : ((V)("")))), "hey cutie</text>")));
}, 2, "", true);
heart_1236 = ((V)(string.Concat("M", NumStr((W_1200 / 2D)), " ", ToStr(Call(f1_19, V.Undef, ((V)((ty_1234 + 9.6))))), "C", NumStr(((W_1200 / 2D) - 3.6)), " ", ToStr(Call(f1_19, V.Undef, ((V)((ty_1234 + 6.8))))), " ", NumStr(((W_1200 / 2D) - 3D)), " ", ToStr(Call(f1_19, V.Undef, ((V)((ty_1234 + 3.4))))), " ", NumStr((W_1200 / 2D)), " ", ToStr(Call(f1_19, V.Undef, ((V)((ty_1234 + 5D))))), "C", NumStr(((W_1200 / 2D) + 3D)), " ", ToStr(Call(f1_19, V.Undef, ((V)((ty_1234 + 3.4))))), " ", NumStr(((W_1200 / 2D) + 3.6)), " ", ToStr(Call(f1_19, V.Undef, ((V)((ty_1234 + 6.8))))), " ", NumStr((W_1200 / 2D)), " ", ToStr(Call(f1_19, V.Undef, ((V)((ty_1234 + 9.6))))), "Z")));
FLK_1237 = Call(an_16, V.Undef, ((V)("opacity")), ((V)("1;1;0.3;1;0.5;1;1")), ((V)(7D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.78;0.79;0.81;0.82;0.84;1\"")));
s_1229 = Add(s_1229, Call(WD_26, V.Undef, C_1222, ((V)(X0_1204)), ((V)(YT_1205)), ((V)(3.4)), ((V)(JsStrBuf.Begin().S(string.Concat("<g filter=\"url(#m12b2)\" opacity=\"0.65\">", ToStr(Call(txt_1235, V.Undef, ((V)("fill=\"none\" stroke=\"#ff4fa0\" stroke-width=\"2.4\"")))), "<path d=\"", ToStr(heart_1236), "\" fill=\"none\" stroke=\"#5ff0ff\" stroke-width=\"2.2\"/></g>")).V(Call(txt_1235, V.Undef, ((V)("fill=\"#ff6fb4\" stroke=\"#ff4fa0\" stroke-width=\"0.5\"")))).V(Call(txt_1235, V.Undef, ((V)("fill=\"#ffe2f1\" opacity=\"0.7\"")))).S(string.Concat("<g>", ToStr(FLK_1237), "<path d=\"", ToStr(heart_1236), "\" fill=\"none\" stroke=\"#5ff0ff\" stroke-width=\"0.9\"/><path d=\"", ToStr(heart_1236), "\" fill=\"none\" stroke=\"#e8feff\" stroke-width=\"0.3\"/></g>")).End()))));
return NewObj(3).Put("defs", DEF19_43).Put("front", s_1229).Put("bb", Invoke(C_1222, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1206;
return default;
}, 1, "", true));
Set(N_12, "master19", Fn((V _arrowThis1300, int _argc1293, V S_1299, V _a1296, V _a1297, V _a1298, V[] _rest1294) => {
double FW_1301 = 0;
double FH_1302 = 0;
double HL_1303 = 0;
double HT_1304 = 0;
double HB_1305 = 0;
double Dp_1306 = 0;
V GOLD_1307 = default;
V D_1308 = default;
V orn_1309 = default;
FW_1301 = 128D;
FH_1302 = 102D;
HL_1303 = 12.5;
HT_1304 = 13.5;
HB_1305 = 11.5;
Dp_1306 = 6D;
GOLD_1307 = ((V)("#d2a23e"));
D_1308 = NewObj(5).Put("w", ((V)(132D))).Put("d", ((V)(18D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(34D))).Put("build", Fn((V _arrowThis1316, int _argc1310, V _a1312, V _a1313, V _a1314, V _a1315, V[] _rest1311) => {
return Arr();
}, 0, "build", true)).V;
orn_1309 = Fn((V _arrowThis1323, int _argc1317, V _a1319, V _a1320, V _a1321, V _a1322, V[] _rest1318) => {
JsStrBuf o_1324 = null;
V beads_1325 = default;
double bi_1326 = 0;
V leaf_1327 = default;
o_1324 = new JsStrBuf(string.Concat("<path d=\"M0 0H", NumStr(FW_1301), "V", NumStr(FH_1302), "H0ZM", NumStr(HL_1303), " ", NumStr(HT_1304), "V", NumStr((FH_1302 - HB_1305)), "H", NumStr((FW_1301 - HL_1303)), "V", NumStr(HT_1304), "Z\" fill=\"url(#gd19)\" fill-rule=\"evenodd\"/>"));
o_1324.S(string.Concat("<rect x=\"2.4\" y=\"2.4\" width=\"", NumStr((FW_1301 - 4.8)), "\" height=\"", NumStr((FH_1302 - 4.8)), "\" fill=\"none\" stroke=\"#8a6420\" stroke-width=\"0.5\"/><rect x=\"", NumStr((HL_1303 - 2.6)), "\" y=\"", NumStr((HT_1304 - 2.6)), "\" width=\"", NumStr(((FW_1301 - (2D * HL_1303)) + 5.2)), "\" height=\"", NumStr((((FH_1302 - HT_1304) - HB_1305) + 5.2)), "\" fill=\"none\" stroke=\"#fff1b0\" stroke-width=\"0.5\" opacity=\"0.8\"/>"));
beads_1325 = Fn((V _arrowThis1339, int _argc1328, V x0_1334, V y0_1335, V x1_1336, V y1_1337, V[] _rest1329) => {
V n_1338 = default;
n_1338 = (_argc1328 > 4 ? _rest1329[0] : V.Undef);
return Invoke(Call(rep_21, V.Undef, n_1338, Fn((V _arrowThis1347, int _argc1340, V i_1346, V _a1343, V _a1344, V _a1345, V[] _rest1341) => {
double t_1348 = 0;
V x_1349 = default;
V y_1350 = default;
t_1348 = (ToNum(Add(i_1346, ((V)(0.5)))) / ToNum(n_1338));
x_1349 = Add(x0_1334, ((V)(((ToNum(x1_1336) - ToNum(x0_1334)) * t_1348))));
y_1350 = Add(y0_1335, ((V)(((ToNum(y1_1337) - ToNum(y0_1335)) * t_1348))));
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_19, V.Undef, x_1349)), "\" cy=\"", ToStr(Call(f1_19, V.Undef, y_1350)), "\" r=\"0.65\" fill=\"#f6dc8a\" stroke=\"#8a6420\" stroke-width=\"0.18\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")));
}, 5, "", true);
bi_1326 = (HL_1303 - 1.3);
o_1324.V(Add(Add(Add(Call(beads_1325, V.Undef, ((V)(bi_1326)), ((V)((HT_1304 - 1.3))), ((V)((FW_1301 - bi_1326))), ((V)((HT_1304 - 1.3))), ((V)(46D))), Call(beads_1325, V.Undef, ((V)(bi_1326)), ((V)(((FH_1302 - HB_1305) + 1.3))), ((V)((FW_1301 - bi_1326))), ((V)(((FH_1302 - HB_1305) + 1.3))), ((V)(46D)))), Call(beads_1325, V.Undef, ((V)(bi_1326)), ((V)((HT_1304 - 1.3))), ((V)(bi_1326)), ((V)(((FH_1302 - HB_1305) + 1.3))), ((V)(36D)))), Call(beads_1325, V.Undef, ((V)((FW_1301 - bi_1326))), ((V)((HT_1304 - 1.3))), ((V)((FW_1301 - bi_1326))), ((V)(((FH_1302 - HB_1305) + 1.3))), ((V)(36D)))));
leaf_1327 = Fn((V _arrowThis1360, int _argc1351, V x_1357, V y_1358, V rot_1359, V _a1356, V[] _rest1352) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_19, V.Undef, x_1357)), " ", ToStr(Call(f1_19, V.Undef, y_1358)), ") rotate(", ToStr(rot_1359), ")\"><path d=\"M-2.2 0Q-2 -2.6 0 -3.2Q2 -2.6 2.2 0Q1 -0.6 0 0.4Q-1 -0.6 -2.2 0Z\" fill=\"#e8c062\" stroke=\"#8a6420\" stroke-width=\"0.2\"/><path d=\"M0 -2.8V0\" stroke=\"#8a6420\" stroke-width=\"0.2\"/></g>")));
}, 3, "", true);
{
double x_1361 = 0;
x_1361 = 10D;
while (true) {
if (!((x_1361 < (FW_1301 - 8D)))) break;
o_1324.V(Add(Call(leaf_1327, V.Undef, ((V)(x_1361)), ((V)(7.2)), ((V)(0D))), Call(leaf_1327, V.Undef, ((V)(x_1361)), ((V)((FH_1302 - 5.2))), ((V)(180D)))));
x_1361 = (x_1361 + 5.4);
}
}
{
double y_1363 = 0;
y_1363 = 12D;
while (true) {
if (!((y_1363 < (FH_1302 - 10D)))) break;
o_1324.V(Add(Call(leaf_1327, V.Undef, ((V)(5.2)), ((V)(y_1363)), ((V)(270D))), Call(leaf_1327, V.Undef, ((V)((FW_1301 - 5.2))), ((V)(y_1363)), ((V)(90D)))));
y_1363 = (y_1363 + 5.4);
}
}
Invoke(Arr(Arr(((V)(6D)), ((V)(6D))), Arr(((V)((FW_1301 - 6D))), ((V)(6D))), Arr(((V)(6D)), ((V)((FH_1302 - 6D)))), Arr(((V)((FW_1301 - 6D))), ((V)((FH_1302 - 6D))))), "forEach", Fn((V _arrowThis1376, int _argc1365, V _a1367, V _a1368, V _a1369, V _a1370, V[] _rest1366) => {
V x_1373 = default;
V y_1375 = default;
{ V _t1371 = ListOf(_a1367);
{ V _t1372 = GetIdx(_t1371, 0D);
x_1373 = _t1372; }
{ V _t1374 = GetIdx(_t1371, 1D);
y_1375 = _t1374; }
}
return ((V)(o_1324.S(string.Concat("<circle cx=\"", ToStr(x_1373), "\" cy=\"", ToStr(y_1375), "\" r=\"4.4\" fill=\"#e8c062\" stroke=\"#8a6420\" stroke-width=\"0.3\"/>")).V(Invoke(Call(rep_21, V.Undef, ((V)(8D)), Fn((V _arrowThis1384, int _argc1377, V i_1383, V _a1380, V _a1381, V _a1382, V[] _rest1378) => {
return ((V)(string.Concat("<path d=\"M", ToStr(x_1373), " ", ToStr(y_1375), "l", ToStr(Call(f1_19, V.Undef, ((V)((4D * FdLibm.Cos(((ToNum(i_1383) * PI_14) / 4D))))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((4D * FdLibm.Sin(((ToNum(i_1383) * PI_14) / 4D))))))), "\" stroke=\"#8a6420\" stroke-width=\"0.25\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<circle cx=\"", ToStr(x_1373), "\" cy=\"", ToStr(y_1375), "\" r=\"1.6\" fill=\"#fff1b0\" stroke=\"#8a6420\" stroke-width=\"0.25\"/>")).Str));
}, 1, "", true));
o_1324.S(string.Concat("<path d=\"M", NumStr(((FW_1301 / 2D) - 12D)), " 2.6Q", NumStr(((FW_1301 / 2D) - 6D)), " -1 ", NumStr((FW_1301 / 2D)), " 1.4Q", NumStr(((FW_1301 / 2D) + 6D)), " -1 ", NumStr(((FW_1301 / 2D) + 12D)), " 2.6Q", NumStr(((FW_1301 / 2D) + 6D)), " 6 ", NumStr((FW_1301 / 2D)), " 9Q", NumStr(((FW_1301 / 2D) - 6D)), " 6 ", NumStr(((FW_1301 / 2D) - 12D)), " 2.6Z\" fill=\"#f2d07a\" stroke=\"#8a6420\" stroke-width=\"0.3\"/><circle cx=\"", NumStr((FW_1301 / 2D)), "\" cy=\"4.6\" r=\"1.8\" fill=\"#fff1b0\" stroke=\"#8a6420\" stroke-width=\"0.25\"/>"));
o_1324.S(string.Concat("<rect x=\"", NumStr(((FW_1301 / 2D) - 15D)), "\" y=\"", NumStr((FH_1302 - 9.4)), "\" width=\"30\" height=\"5\" rx=\"0.6\" fill=\"url(#br19)\" stroke=\"#7a5418\" stroke-width=\"0.2\"/>")).V(Call(T_39, V.Undef, ((V)((FW_1301 / 2D))), ((V)((FH_1302 - 6D))), ((V)(2.4)), ((V)("#4a3410")), Invoke((Get(S_1299, "st") is var _t1385 && Truthy(_t1385) ? _t1385 : ((V)("Sunset Sea"))), "toUpperCase"), ((V)("letter-spacing=\"0.2\""))));
return ((V)(o_1324.Str));
return default;
}, 0, "", true);
Set(D_1308, "fx", Fn((V _arrowThis1393, int _argc1386, V ctx_1392, V _a1389, V _a1390, V _a1391, V[] _rest1387) => {
V C_1394 = default;
V F0_1395 = default;
JsStrBuf s_1396 = null;
V lq_1397 = default;
C_1394 = Call(cam_15, V.Undef, ctx_1392);
F0_1395 = (Invoke(Invoke(N_12, "masterpiece", S_1299), "fx", ctx_1392) is var _t1398 && Truthy(_t1398) ? _t1398 : NewObj(0).V);
s_1396 = new JsStrBuf("");
s_1396.V(Call(WD_26, V.Undef, C_1394, ((V)((((-FW_1301) / 2D) - 6D))), ((V)((FH_1302 + 14D))), ((V)(0.05)), ((V)(string.Concat("<path d=\"M", NumStr(((FW_1301 / 2D) - 14D)), " 0H", NumStr(((FW_1301 / 2D) + 32D)), "L", NumStr((FW_1301 + 12D)), " ", NumStr((FH_1302 * 0.75)), "H0Z\" fill=\"#fff0c8\" opacity=\"0.16\" filter=\"url(#m12b2)\">", ToStr(Call(an_16, V.Undef, ((V)("opacity")), ((V)("0.12;0.2;0.12")), ((V)(5D)), ((V)(0D)), Call(SPL_18, V.Undef, ((V)(2D))))), "</path>")))));
s_1396.V(Call(wsh_27, V.Undef, C_1394, ((V)(((-FW_1301) / 2D))), ((V)(FH_1302)), ((V)(FW_1301)), ((V)(FH_1302)), NewObj(3).Put("dx", ((V)(2.8))).Put("dy", ((V)(3.6))).Put("op", ((V)(0.5))).V));
s_1396.V(Call(WD_26, V.Undef, C_1394, ((V)((-54D))), ((V)(91D)), ((V)(2.6)), ((V)("<rect width=\"108\" height=\"82\" fill=\"#2a2440\"/>"))));
s_1396.V((Get(F0_1395, "front") is var _t1399 && Truthy(_t1399) ? _t1399 : ((V)(""))));
s_1396.V(Call(innerW_28, V.Undef, C_1394, ((V)((((-FW_1301) / 2D) + HL_1303))), ((V)(((FW_1301 / 2D) - HL_1303))), ((V)(HB_1305)), ((V)((FH_1302 - HT_1304))), ((V)(2.9)), ((V)(Dp_1306)), ((V)("#b88a30")), ((V)(0.9))));
s_1396.V(Call(box3_34, V.Undef, C_1394, NewObj(8).Put("c", Arr(((V)(0D)), ((V)(0D)), ((V)((Dp_1306 / 2D))))).Put("w", ((V)(FW_1301))).Put("h", ((V)(FH_1302))).Put("d", ((V)(Dp_1306))).Put("r", ((V)(0.6))).Put("col", GOLD_1307).Put("hole", NewObj(1).Put("f", Arr(((V)(HL_1303)), ((V)(HT_1304)), ((V)(HL_1303)), ((V)(HB_1305)))).V).Put("dec", NewObj(1).Put("f", Call(orn_1309, V.Undef)).V).V));
s_1396.V(Call(pane_37, V.Undef, C_1394, Arr(((V)((((-FW_1301) / 2D) + HL_1303))), ((V)((FH_1302 - HT_1304))), ((V)((Dp_1306 - 0.6)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))), ((V)((FW_1301 - (2D * HL_1303)))), ((V)(((FH_1302 - HT_1304) - HB_1305))), NewObj(3).Put("t", ((V)(0.03))).Put("g", ((V)(0.7))).Put("e", ((V)(0.2))).V));
Invoke(Arr(((V)((-22D))), ((V)(22D))), "forEach", Fn((V _arrowThis1407, int _argc1400, V x_1406, V _a1403, V _a1404, V _a1405, V[] _rest1401) => {
return ((V)(s_1396.V(Call(cyl3_35, V.Undef, C_1394, Arr(x_1406, ((V)((FH_1302 - 1D))), ((V)(3D))), Arr(x_1406, ((V)((FH_1302 + 5.5))), ((V)(11.5))), ((V)(0.55)), ((V)("#c99a3e")))).Str));
}, 1, "", true));
s_1396.V(Add(Add(Call(cyl3_35, V.Undef, C_1394, Arr(((V)((-30D))), ((V)((FH_1302 + 6.4))), ((V)(12.6))), Arr(((V)(30D)), ((V)((FH_1302 + 6.4))), ((V)(12.6))), ((V)(2.6)), ((V)("#c99a3e")), NewObj(2).Put("mat", ((V)("gloss"))).Put("n", ((V)(20D))).V), Call(sph_36, V.Undef, C_1394, Arr(((V)((-30.6))), ((V)((FH_1302 + 6.4))), ((V)(12.6))), ((V)(2.7)), ((V)("#c99a3e")))), Call(sph_36, V.Undef, C_1394, Arr(((V)(30.6)), ((V)((FH_1302 + 6.4))), ((V)(12.6))), ((V)(2.7)), ((V)("#c99a3e")))));
lq_1397 = Invoke(C_1394, "p", ((V)(0D)), ((V)((FH_1302 + 4D))), ((V)(12.6)));
s_1396.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_19, V.Undef, GetIdx(lq_1397, 0D))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, Add(GetIdx(lq_1397, 1D), Get(C_1394, "k")))), "\" rx=\"", ToStr(Call(f1_19, V.Undef, ((V)((28D * ToNum(Get(C_1394, "k"))))))), "\" ry=\"", ToStr(Call(f1_19, V.Undef, ((V)((1.3 * ToNum(Get(C_1394, "k"))))))), "\" fill=\"#fff4c8\" opacity=\"0.85\">", ToStr(Call(an_16, V.Undef, ((V)("opacity")), ((V)("0.7;0.95;0.7")), ((V)(5D)), ((V)(0D)), Call(SPL_18, V.Undef, ((V)(2D))))), "</ellipse>"));
s_1396.V(Call(WD_26, V.Undef, C_1394, ((V)((((-FW_1301) / 2D) + HL_1303))), ((V)((FH_1302 - HT_1304))), ((V)(3D)), ((V)(string.Concat("<defs><linearGradient id=\"mpw19\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0c0\" stop-opacity=\"0.32\"/><stop offset=\"0.55\" stop-color=\"#fff0c0\" stop-opacity=\"0.05\"/><stop offset=\"1\" stop-color=\"#fff0c0\" stop-opacity=\"0\"/></linearGradient></defs><path d=\"M", NumStr((((FW_1301 - (2D * HL_1303)) / 2D) - 30D)), " 0H", NumStr((((FW_1301 - (2D * HL_1303)) / 2D) + 30D)), "L", NumStr((FW_1301 - (2D * HL_1303))), " ", NumStr((((FH_1302 - HT_1304) - HB_1305) * 0.8)), "H0Z\" fill=\"url(#mpw19)\"/>")))));
return NewObj(3).Put("defs", Add(DEF19_43, (Get(F0_1395, "defs") is var _t1408 && Truthy(_t1408) ? _t1408 : ((V)(""))))).Put("front", ((V)(s_1396.Str))).Put("bb", Invoke(C_1394, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1308;
return default;
}, 1, "", true));
qt_58 = Fn((V _arrowThis1416, int _argc1409, V S_1415, V _a1412, V _a1413, V _a1414, V[] _rest1410) => {
return Invoke(((Get(S_1415, "txt") is var _t1418 && Truthy(_t1418) ? _t1418 : (Get(S_1415, "row") is var _t1417 && !Truthy(_t1417) ? _t1417 : Get(Get(S_1415, "row"), "txt0"))) is var _t1419 && Truthy(_t1419) ? _t1419 : ((V)("Home Sweet Home"))), "slice", ((V)(0D)), ((V)(26D)));
}, 1, "", true);
qw_59 = Fn((V _arrowThis1430, int _argc1420, V t_1426, V k_1427, V a_1428, V b_1429, V[] _rest1421) => {
return ((V)(Max(ToNum(a_1428), Min(ToNum(b_1429), (24D + (ToNum(Get(t_1426, "length")) * ToNum(k_1427)))))));
}, 4, "", true);
Set(N_12, "qPaper19", Fn((V _arrowThis1438, int _argc1431, V S_1437, V _a1434, V _a1435, V _a1436, V[] _rest1432) => {
V t_1439 = default;
V W_1440 = default;
double Hh_1441 = 0;
double Y0_1442 = 0;
double YT_1443 = 0;
double X0_1444 = 0;
V D_1445 = default;
t_1439 = Call(qt_58, V.Undef, S_1437);
W_1440 = Call(qw_59, V.Undef, t_1439, ((V)(5.8)), ((V)(62D)), ((V)(150D)));
Hh_1441 = 22D;
Y0_1442 = 22D;
YT_1443 = (Y0_1442 + Hh_1441);
X0_1444 = ((-ToNum(W_1440)) / 2D);
D_1445 = NewObj(5).Put("w", Add(W_1440, ((V)(18D)))).Put("d", ((V)(4D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(50D))).Put("build", Fn((V _arrowThis1452, int _argc1446, V _a1448, V _a1449, V _a1450, V _a1451, V[] _rest1447) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1445, "fx", Fn((V _arrowThis1460, int _argc1453, V ctx_1459, V _a1456, V _a1457, V _a1458, V[] _rest1454) => {
V C_1461 = default;
V ban_1462 = default;
V tw_1463 = default;
double fs_1464 = 0;
double tl_1465 = 0;
V tx_1466 = default;
V star_1467 = default;
V hrt_1468 = default;
V b_1469 = default;
V pins_1470 = default;
V sw_1471 = default;
V pv_1472 = default;
V pq_1473 = default;
V s_1474 = default;
C_1461 = Call(cam_15, V.Undef, ctx_1459);
ban_1462 = ((V)(string.Concat("M0 0H", ToStr(W_1440), "L", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1440) - 5D))))), " ", NumStr((Hh_1441 / 2D)), "L", ToStr(W_1440), " ", NumStr(Hh_1441), "H0L5 ", NumStr((Hh_1441 / 2D)), "Z")));
tw_1463 = ((V)(string.Concat("M-9 -5Q", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1440) / 2D))))), " 5 ", ToStr(Call(f1_19, V.Undef, Add(W_1440, ((V)(9D))))), " -5")));
fs_1464 = 10D;
tl_1465 = (ToNum(W_1440) - 20D);
tx_1466 = Fn((V _arrowThis1483, int _argc1475, V st_1481, V dx_1482, V _a1479, V _a1480, V[] _rest1476) => {
return ((V)(string.Concat("<text x=\"", ToStr(Call(f1_19, V.Undef, Add(((V)((ToNum(W_1440) / 2D))), (dx_1482 is var _t1484 && Truthy(_t1484) ? _t1484 : ((V)(0D)))))), "\" y=\"", ToStr(Call(f1_19, V.Undef, Add(((V)(((Hh_1441 / 2D) + 3.4))), (dx_1482 is var _t1485 && Truthy(_t1485) ? _t1485 : ((V)(0D)))))), "\" text-anchor=\"middle\" font-family=\"", ToStr(HAND_41), "\" font-weight=\"700\" font-size=\"", NumStr(fs_1464), "\" textLength=\"", ToStr(Call(f1_19, V.Undef, ((V)(tl_1465)))), "\" lengthAdjust=\"spacingAndGlyphs\" ", ToStr(st_1481), ">", ToStr(Call(xe_38, V.Undef, t_1439)), "</text>")));
}, 2, "", true);
star_1467 = Fn((V _arrowThis1496, int _argc1486, V x_1492, V y_1493, V r_1494, V c_1495, V[] _rest1487) => {
return ((V)(string.Concat("<path d=\"M", ToStr(x_1492), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(y_1493) - ToNum(r_1494)))))), "L", ToStr(Call(f1_19, V.Undef, Add(x_1492, ((V)((ToNum(r_1494) * 0.3)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(y_1493) - (ToNum(r_1494) * 0.3)))))), "L", ToStr(Call(f1_19, V.Undef, Add(x_1492, r_1494))), " ", ToStr(y_1493), "L", ToStr(Call(f1_19, V.Undef, Add(x_1492, ((V)((ToNum(r_1494) * 0.3)))))), " ", ToStr(Call(f1_19, V.Undef, Add(y_1493, ((V)((ToNum(r_1494) * 0.3)))))), "L", ToStr(x_1492), " ", ToStr(Call(f1_19, V.Undef, Add(y_1493, r_1494))), "L", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(x_1492) - (ToNum(r_1494) * 0.3)))))), " ", ToStr(Call(f1_19, V.Undef, Add(y_1493, ((V)((ToNum(r_1494) * 0.3)))))), "L", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(x_1492) - ToNum(r_1494)))))), " ", ToStr(y_1493), "L", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(x_1492) - (ToNum(r_1494) * 0.3)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(y_1493) - (ToNum(r_1494) * 0.3)))))), "Z\" fill=\"", ToStr(c_1495), "\"/>")));
}, 4, "", true);
hrt_1468 = Fn((V _arrowThis1507, int _argc1497, V x_1503, V y_1504, V r_1505, V c_1506, V[] _rest1498) => {
return ((V)(string.Concat("<path d=\"M", ToStr(x_1503), " ", ToStr(Call(f1_19, V.Undef, Add(y_1504, r_1505))), "C", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(x_1503) - (ToNum(r_1505) * 1.4)))))), " ", ToStr(Call(f1_19, V.Undef, y_1504)), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(x_1503) - ToNum(r_1505)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(y_1504) - (ToNum(r_1505) * 1.2)))))), " ", ToStr(x_1503), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(y_1504) - (ToNum(r_1505) * 0.4)))))), "C", ToStr(Call(f1_19, V.Undef, Add(x_1503, r_1505))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(y_1504) - (ToNum(r_1505) * 1.2)))))), " ", ToStr(Call(f1_19, V.Undef, Add(x_1503, ((V)((ToNum(r_1505) * 1.4)))))), " ", ToStr(y_1504), " ", ToStr(x_1503), " ", ToStr(Call(f1_19, V.Undef, Add(y_1504, r_1505))), "Z\" fill=\"", ToStr(c_1506), "\"/>")));
}, 4, "", true);
b_1469 = ((V)(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(ban_1462), "\" fill=\"#fbf6ea\" stroke=\"#d9cdb2\" stroke-width=\"0.3\"/>")).V(Invoke(Call(rep_21, V.Undef, ((V)(6D)), Fn((V _arrowThis1515, int _argc1508, V i_1514, V _a1511, V _a1512, V _a1513, V[] _rest1509) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_19, V.Undef, ((V)((5D + ((ToNum(i_1514) * (ToNum(W_1440) - 10D)) / 6D)))))), "\" width=\"", ToStr(Call(f1_19, V.Undef, ((V)(((ToNum(W_1440) - 10D) / 12D))))), "\" height=\"", NumStr(Hh_1441), "\" fill=\"#000000\" opacity=\"0.025\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Invoke(Arr(((V)((ToNum(W_1440) / 3D))), ((V)(((2D * ToNum(W_1440)) / 3D)))), "map", Fn((V _arrowThis1523, int _argc1516, V x_1522, V _a1519, V _a1520, V _a1521, V[] _rest1517) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, x_1522)), " 0.4V", NumStr((Hh_1441 - 0.4)), "\" stroke=\"#000000\" stroke-opacity=\"0.1\" stroke-width=\"0.35\"/><path d=\"M", ToStr(Call(f1_19, V.Undef, Add(x_1522, ((V)(0.35))))), " 0.4V", NumStr((Hh_1441 - 0.4)), "\" stroke=\"#ffffff\" stroke-width=\"0.3\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Call(tx_1466, V.Undef, ((V)("fill=\"#ff9fb4\"")), ((V)(0.55)))).V(Call(tx_1466, V.Undef, ((V)("fill=\"#3654a8\"")))).S(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1440) * 0.2))))), " ", NumStr((Hh_1441 - 3D)), "q", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1440) * 0.05))))), " -1.4 ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1440) * 0.1))))), " 0t", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1440) * 0.1))))), " 0t", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1440) * 0.1))))), " 0t", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1440) * 0.1))))), " 0t", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1440) * 0.1))))), " 0t", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1440) * 0.1))))), " 0\" stroke=\"#e0533a\" stroke-width=\"0.55\" fill=\"none\" stroke-linecap=\"round\"/>")).V(Call(star_1467, V.Undef, ((V)(8.6)), ((V)(4.2)), ((V)(1.6)), ((V)("#f2b632")))).V(Call(star_1467, V.Undef, ((V)((ToNum(W_1440) - 8.6))), ((V)(4.4)), ((V)(1.4)), ((V)("#f2b632")))).V(Call(hrt_1468, V.Undef, ((V)(8.8)), ((V)((Hh_1441 - 5D))), ((V)(1.6)), ((V)("#e0533a")))).V(Call(hrt_1468, V.Undef, ((V)((ToNum(W_1440) - 8.8))), ((V)((Hh_1441 - 5D))), ((V)(1.4)), ((V)("#e0533a")))).S(string.Concat("<path d=\"", ToStr(ban_1462), "\" fill=\"url(#m12gl)\" opacity=\"0.5\"/>")).End()));
pins_1470 = Arr(((V)((ToNum(W_1440) * 0.2))), ((V)((ToNum(W_1440) * 0.8))));
sw_1471 = Add(Call(WD_26, V.Undef, C_1461, ((V)(X0_1444)), ((V)(YT_1443)), ((V)(1.4)), b_1469, W_1440, ((V)(Hh_1441))), Call(WD_26, V.Undef, C_1461, ((V)(X0_1444)), ((V)(YT_1443)), ((V)(1.9)), ((V)(string.Concat("<path d=\"", ToStr(tw_1463), "\" stroke=\"#a8875a\" stroke-width=\"0.55\" fill=\"none\"/><path d=\"", ToStr(tw_1463), "\" stroke=\"#e2c79a\" stroke-width=\"0.2\" stroke-dasharray=\"0.6 0.6\" fill=\"none\"/>")))));
Invoke(pins_1470, "forEach", Fn((V _arrowThis1531, int _argc1524, V x_1530, V _a1527, V _a1528, V _a1529, V[] _rest1525) => {
return (sw_1471 = Add(sw_1471, Add(Call(box3_34, V.Undef, C_1461, NewObj(6).Put("c", Arr(Add(((V)(X0_1444)), x_1530), ((V)((YT_1443 - 3.2))), ((V)(2.1)))).Put("w", ((V)(1.9))).Put("h", ((V)(6D))).Put("d", ((V)(1.3))).Put("r", ((V)(0.3))).Put("col", ((V)("#d9b27a"))).V), Call(cyl3_35, V.Undef, C_1461, Arr(((V)((ToNum(Add(((V)(X0_1444)), x_1530)) - 1.05))), ((V)((YT_1443 + 0.6))), ((V)(2.1))), Arr(Add(Add(((V)(X0_1444)), x_1530), ((V)(1.05))), ((V)((YT_1443 + 0.6))), ((V)(2.1))), ((V)(0.35)), ((V)("#b8bcc2"))))));
}, 1, "", true));
pv_1472 = Invoke(C_1461, "p", ((V)(0D)), ((V)((YT_1443 + 1D))), ((V)(1.6)));
pq_1473 = Call(P2_22, V.Undef, pv_1472);
s_1474 = Call(WD_26, V.Undef, C_1461, ((V)(X0_1444)), ((V)(YT_1443)), ((V)(0.06)), ((V)(string.Concat("<path d=\"", ToStr(ban_1462), "\" fill=\"#000000\" opacity=\"0.28\" transform=\"translate(1 2)\" filter=\"url(#m12b1)\"/><path d=\"", ToStr(tw_1463), "\" stroke=\"#000000\" stroke-width=\"0.6\" opacity=\"0.18\" fill=\"none\" transform=\"translate(0.6 1.2)\"/>"))));
Invoke(Arr(((V)((-9D))), Add(W_1440, ((V)(9D)))), "forEach", Fn((V _arrowThis1539, int _argc1532, V x_1538, V _a1535, V _a1536, V _a1537, V[] _rest1533) => {
return (s_1474 = Add(s_1474, Call(sph_36, V.Undef, C_1461, Arr(Add(((V)(X0_1444)), x_1538), ((V)((YT_1443 + 5D))), ((V)(0.8))), ((V)(1D)), ((V)("#d9483b")))));
}, 1, "", true));
s_1474 = ((V)(JsStrBuf.Begin().V(s_1474).S(string.Concat("<g>", ToStr(Call(at_17, V.Undef, ((V)("rotate")), ((V)(string.Concat("-0.7 ", ToStr(pq_1473), ";0.7 ", ToStr(pq_1473), ";-0.7 ", ToStr(pq_1473)))), ((V)(4.4)), ((V)(0D)), Call(SPL_18, V.Undef, ((V)(2D))))), ToStr(sw_1471), "</g>")).End()));
return NewObj(3).Put("defs", DEF19_43).Put("front", s_1474).Put("bb", Invoke(C_1461, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1445;
return default;
}, 1, "", true));
Set(N_12, "qDrift19", Fn((V _arrowThis1547, int _argc1540, V S_1546, V _a1543, V _a1544, V _a1545, V[] _rest1541) => {
V t_1548 = default;
V W_1549 = default;
double Hh_1550 = 0;
double Y0_1551 = 0;
double YT_1552 = 0;
double NY_1553 = 0;
double DP_1554 = 0;
V WC_1555 = default;
V D_1556 = default;
t_1548 = Call(qt_58, V.Undef, S_1546);
W_1549 = Call(qw_59, V.Undef, t_1548, ((V)(6D)), ((V)(66D)), ((V)(156D)));
Hh_1550 = 20D;
Y0_1551 = 20D;
YT_1552 = (Y0_1551 + Hh_1550);
NY_1553 = (YT_1552 + 13D);
DP_1554 = 3.4;
WC_1555 = ((V)("#b8a68b"));
D_1556 = NewObj(5).Put("w", Add(W_1549, ((V)(10D)))).Put("d", ((V)(6D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(48D))).Put("build", Fn((V _arrowThis1563, int _argc1557, V _a1559, V _a1560, V _a1561, V _a1562, V[] _rest1558) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1556, "fx", Fn((V _arrowThis1571, int _argc1564, V ctx_1570, V _a1567, V _a1568, V _a1569, V[] _rest1565) => {
V C_1572 = default;
V R_1573 = default;
V id_1574 = default;
V gr_1575 = default;
double fs_1576 = 0;
V txt_1577 = default;
V starF_1578 = default;
double ex_1579 = 0;
V rope_1580 = default;
V ropeL_1581 = default;
V sw_1582 = default;
V rp_1583 = default;
V pq_1584 = default;
V s_1585 = default;
C_1572 = Call(cam_15, V.Undef, ctx_1570);
R_1573 = Call(rng_23, V.Undef, ((V)(JsStrBuf.Begin().S("dw").V(W_1549).End())));
id_1574 = Invoke(C_1572, "u", ((V)("dw")));
gr_1575 = Invoke(Call(rep_21, V.Undef, ((V)(9D)), Fn((V _arrowThis1593, int _argc1586, V i_1592, V _a1589, V _a1590, V _a1591, V[] _rest1587) => {
double y_1594 = 0;
y_1594 = ((2D + (ToNum(i_1592) * 2D)) + (ToNum(Call(R_1573, V.Undef)) - 0.5));
return ((V)(string.Concat("<path d=\"M0 ", ToStr(Call(f1_19, V.Undef, ((V)(y_1594)))), "C", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1549) * 0.25))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y_1594 + ((ToNum(Call(R_1573, V.Undef)) - 0.5) * 2.4)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1549) * 0.6))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((y_1594 + ((ToNum(Call(R_1573, V.Undef)) - 0.5) * 2.4)))))), " ", ToStr(W_1549), " ", ToStr(Call(f1_19, V.Undef, ((V)((y_1594 + (ToNum(Call(R_1573, V.Undef)) - 0.5)))))), "\" stroke=\"", ToStr(Call(shade_11, V.Undef, WC_1555, ((V)(0.72)))), "\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((0.2 + (ToNum(Call(R_1573, V.Undef)) * 0.25)))))), "\" fill=\"none\" opacity=\"0.6\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")));
gr_1575 = Add(gr_1575, Invoke(Call(rep_21, V.Undef, ((V)(3D)), Fn((V _arrowThis1601, int _argc1595, V _a1597, V _a1598, V _a1599, V _a1600, V[] _rest1596) => {
double x_1602 = 0;
double y_1603 = 0;
x_1602 = (6D + (ToNum(Call(R_1573, V.Undef)) * (ToNum(W_1549) - 12D)));
y_1603 = (4D + (ToNum(Call(R_1573, V.Undef)) * 12D));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_19, V.Undef, ((V)(x_1602)))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)(y_1603)))), "\" rx=\"", ToStr(Call(f1_19, V.Undef, Add(((V)(1.6)), Call(R_1573, V.Undef)))), "\" ry=\"", ToStr(Call(f1_19, V.Undef, ((V)((0.8 + (ToNum(Call(R_1573, V.Undef)) * 0.4)))))), "\" fill=\"", ToStr(Call(shade_11, V.Undef, WC_1555, ((V)(0.7)))), "\"/><ellipse cx=\"", ToStr(Call(f1_19, V.Undef, ((V)(x_1602)))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)(y_1603)))), "\" rx=\"", ToStr(Call(f1_19, V.Undef, Add(((V)(2.8)), Call(R_1573, V.Undef)))), "\" ry=\"", ToStr(Call(f1_19, V.Undef, ((V)(1.5)))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_11, V.Undef, WC_1555, ((V)(0.78)))), "\" stroke-width=\"0.25\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
gr_1575 = Add(gr_1575, Invoke(Call(rep_21, V.Undef, ((V)(14D)), Fn((V _arrowThis1610, int _argc1604, V _a1606, V _a1607, V _a1608, V _a1609, V[] _rest1605) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_1573, V.Undef)) * ToNum(W_1549)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_1573, V.Undef)) * Hh_1550))))), "h", ToStr(Call(f1_19, V.Undef, ((V)((2D + (ToNum(Call(R_1573, V.Undef)) * 5D)))))), "\" stroke=\"#ffffff\" stroke-width=\"0.35\" opacity=\"0.25\"/>")));
}, 0, "", true)), "join", ((V)(""))));
fs_1576 = 9.6;
txt_1577 = ((V)(string.Concat("<defs><mask id=\"", ToStr(id_1574), "m\"><rect width=\"", ToStr(W_1549), "\" height=\"", NumStr(Hh_1550), "\" fill=\"#ffffff\"/>", ToStr(Invoke(Call(rep_21, V.Undef, ((V)(60D)), Fn((V _arrowThis1617, int _argc1611, V _a1613, V _a1614, V _a1615, V _a1616, V[] _rest1612) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_1573, V.Undef)) * ToNum(W_1549)))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_1573, V.Undef)) * Hh_1550))))), "\" r=\"", ToStr(Call(f1_19, V.Undef, ((V)((0.2 + (ToNum(Call(R_1573, V.Undef)) * 0.5)))))), "\" fill=\"#000000\"/>")));
}, 0, "", true)), "join", ((V)("")))), "</mask></defs><g mask=\"url(#", ToStr(id_1574), "m)\"><text x=\"", NumStr((ToNum(W_1549) / 2D)), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)(((Hh_1550 / 2D) + 3.3))))), "\" text-anchor=\"middle\" font-family=\"", ToStr(SERIF_42), "\" font-style=\"italic\" font-weight=\"700\" font-size=\"", NumStr(fs_1576), "\" textLength=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1549) - 18D))))), "\" lengthAdjust=\"spacingAndGlyphs\" fill=\"#fbf8f0\">", ToStr(Call(xe_38, V.Undef, t_1548)), "</text></g>")));
starF_1578 = ((V)(string.Concat("<g transform=\"translate(", NumStr((ToNum(W_1549) - 6.5)), " ", NumStr((Hh_1550 - 5.2)), ") rotate(12)\"><path d=\"", ToStr(Invoke(Call(rep_21, V.Undef, ((V)(10D)), Fn((V _arrowThis1625, int _argc1618, V i_1624, V _a1621, V _a1622, V _a1623, V[] _rest1619) => {
double a_1626 = 0;
double r_1627 = 0;
a_1626 = (((-PI_14) / 2D) + ((ToNum(i_1624) * PI_14) / 5D));
r_1627 = (NumTruthy((ToNum(i_1624) % 2D)) ? 1.2 : 3D);
return ((V)(JsStrBuf.Begin().S((Truthy(i_1624) ? "L" : "M")).V(Call(f1_19, V.Undef, ((V)((r_1627 * FdLibm.Cos(a_1626)))))).S(" ").V(Call(f1_19, V.Undef, ((V)((r_1627 * FdLibm.Sin(a_1626)))))).End()));
return default;
}, 1, "", true)), "join", ((V)("")))), "Z\" fill=\"#e88a4a\" stroke=\"#a8552a\" stroke-width=\"0.25\" stroke-linejoin=\"round\"/>", ToStr(Invoke(Call(rep_21, V.Undef, ((V)(5D)), Fn((V _arrowThis1635, int _argc1628, V i_1634, V _a1631, V _a1632, V _a1633, V[] _rest1629) => {
double a_1636 = 0;
a_1636 = (((-PI_14) / 2D) + (((ToNum(i_1634) * 2D) * PI_14) / 5D));
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_19, V.Undef, ((V)((1.6 * FdLibm.Cos(a_1636)))))), "\" cy=\"", ToStr(Call(f1_19, V.Undef, ((V)((1.6 * FdLibm.Sin(a_1636)))))), "\" r=\"0.3\" fill=\"#ffd2a8\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))), "</g>")));
ex_1579 = ((ToNum(W_1549) / 2D) - 7D);
rope_1580 = ((V)(string.Concat("M", NumStr((-ex_1579)), " ", NumStr((YT_1552 - 0.6)), "L0 ", NumStr(NY_1553), "L", NumStr(ex_1579), " ", NumStr((YT_1552 - 0.6)))));
ropeL_1581 = Invoke(Arr(Arr(((V)((-ex_1579))), ((V)((YT_1552 - 0.6))), ((V)(2.4))), Arr(((V)(0D)), ((V)(NY_1553)), ((V)(2.4))), Arr(((V)(ex_1579)), ((V)((YT_1552 - 0.6))), ((V)(2.4)))), "map", Get(C_1572, "P"));
sw_1582 = Call(box3_34, V.Undef, C_1572, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(Y0_1551)), ((V)((DP_1554 / 2D))))).Put("w", W_1549).Put("h", ((V)(Hh_1550))).Put("d", ((V)(DP_1554))).Put("r", ((V)(1.6))).Put("col", WC_1555).Put("dec", NewObj(2).Put("f", Add(Add(gr_1575, txt_1577), starF_1578)).Put("t", Invoke(Call(rep_21, V.Undef, ((V)(5D)), Fn((V _arrowThis1643, int _argc1637, V _a1639, V _a1640, V _a1641, V _a1642, V[] _rest1638) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_1573, V.Undef)) * ToNum(W_1549)))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Call(R_1573, V.Undef)) * DP_1554))))), "h", ToStr(Call(f1_19, V.Undef, ((V)((3D + (ToNum(Call(R_1573, V.Undef)) * 6D)))))), "\" stroke=\"", ToStr(Call(shade_11, V.Undef, WC_1555, ((V)(0.7)))), "\" stroke-width=\"0.25\"/>")));
}, 0, "", true)), "join", ((V)("")))).V).V);
rp_1583 = ((V)(string.Concat("M", ToStr(Call(P2_22, V.Undef, GetIdx(ropeL_1581, 0D))), "L", ToStr(Call(P2_22, V.Undef, GetIdx(ropeL_1581, 1D))), "L", ToStr(Call(P2_22, V.Undef, GetIdx(ropeL_1581, 2D))))));
sw_1582 = ((V)(JsStrBuf.Begin().V(sw_1582).S(string.Concat("<path d=\"", ToStr(rp_1583), "\" stroke=\"#8a6a3e\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Get(C_1572, "k")) * 0.9))))), "\" fill=\"none\" stroke-linejoin=\"round\" stroke-linecap=\"round\"/><path d=\"", ToStr(rp_1583), "\" stroke=\"#d8b884\" stroke-width=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Get(C_1572, "k")) * 0.5))))), "\" stroke-dasharray=\"", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Get(C_1572, "k")) * 0.5))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(Get(C_1572, "k")) * 0.5))))), "\" fill=\"none\"/>")).End()));
Invoke(Arr(((V)((-ex_1579))), ((V)(ex_1579))), "forEach", Fn((V _arrowThis1651, int _argc1644, V x_1650, V _a1647, V _a1648, V _a1649, V[] _rest1645) => {
return (sw_1582 = Add(sw_1582, Call(sph_36, V.Undef, C_1572, Arr(x_1650, ((V)((YT_1552 - 0.4))), ((V)(2.4))), ((V)(0.9)), ((V)("#9aa0a8")))));
}, 1, "", true));
pq_1584 = Call(P2_22, V.Undef, Invoke(C_1572, "p", ((V)(0D)), ((V)(NY_1553)), ((V)(1.6))));
s_1585 = Add(Call(WD_26, V.Undef, C_1572, ((V)(((-ToNum(W_1549)) / 2D))), ((V)(YT_1552)), ((V)(0.06)), ((V)(string.Concat("<rect x=\"1.8\" y=\"2.8\" width=\"", ToStr(W_1549), "\" height=\"", NumStr(Hh_1550), "\" rx=\"2\" fill=\"#000000\" opacity=\"0.38\" filter=\"url(#m10b3)\"/>")))), Call(WD_26, V.Undef, C_1572, ((V)(0D)), ((V)(0D)), ((V)(0.06)), ((V)(string.Concat("<path d=\"M", NumStr((-ex_1579)), " ", NumStr((-YT_1552)), "L0 ", NumStr((-NY_1553)), "L", NumStr(ex_1579), " ", NumStr((-YT_1552)), "\" transform=\"translate(1 2)\" stroke=\"#000000\" stroke-width=\"0.8\" opacity=\"0.2\" fill=\"none\"/>")))));
s_1585 = ((V)(JsStrBuf.Begin().V(s_1585).S(string.Concat("<g>", ToStr(Call(at_17, V.Undef, ((V)("rotate")), ((V)(string.Concat("-1.1 ", ToStr(pq_1584), ";1.1 ", ToStr(pq_1584), ";-1.1 ", ToStr(pq_1584)))), ((V)(5.2)), ((V)(0D)), Call(SPL_18, V.Undef, ((V)(2D))))), ToStr(sw_1582), "</g>")).End()));
s_1585 = Add(s_1585, Add(Call(cyl3_35, V.Undef, C_1572, Arr(((V)(0D)), ((V)(NY_1553)), ((V)(0D))), Arr(((V)(0D)), ((V)(NY_1553)), ((V)(3D))), ((V)(0.4)), ((V)("#7d838b"))), Call(sph_36, V.Undef, C_1572, Arr(((V)(0D)), ((V)(NY_1553)), ((V)(3.1))), ((V)(1D)), ((V)("#8a8f96")))));
return NewObj(3).Put("defs", DEF19_43).Put("front", s_1585).Put("bb", Invoke(C_1572, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1556;
return default;
}, 1, "", true));
Set(N_12, "qVinyl19", Fn((V _arrowThis1659, int _argc1652, V S_1658, V _a1655, V _a1656, V _a1657, V[] _rest1653) => {
V t_1660 = default;
V W_1661 = default;
double Hh_1662 = 0;
double Y0_1663 = 0;
double YT_1664 = 0;
V D_1665 = default;
t_1660 = Call(qt_58, V.Undef, S_1658);
W_1661 = Call(qw_59, V.Undef, t_1660, ((V)(7D)), ((V)(70D)), ((V)(168D)));
Hh_1662 = 30D;
Y0_1663 = 18D;
YT_1664 = (Y0_1663 + Hh_1662);
D_1665 = NewObj(5).Put("w", Add(W_1661, ((V)(6D)))).Put("d", ((V)(2D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(54D))).Put("build", Fn((V _arrowThis1672, int _argc1666, V _a1668, V _a1669, V _a1670, V _a1671, V[] _rest1667) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1665, "fx", Fn((V _arrowThis1680, int _argc1673, V ctx_1679, V _a1676, V _a1677, V _a1678, V[] _rest1674) => {
V C_1681 = default;
V id_1682 = default;
double fs_1683 = 0;
double tl_1684 = 0;
V tx_1685 = default;
V fl_1686 = default;
V leaf_1687 = default;
V sprig_1688 = default;
V body_1689 = default;
JsStrBuf g_1690 = null;
V s_1691 = default;
C_1681 = Call(cam_15, V.Undef, ctx_1679);
id_1682 = Invoke(C_1681, "u", ((V)("vy")));
fs_1683 = 15D;
tl_1684 = (ToNum(W_1661) - 10D);
tx_1685 = Fn((V _arrowThis1699, int _argc1692, V st_1698, V _a1695, V _a1696, V _a1697, V[] _rest1693) => {
return ((V)(string.Concat("<text x=\"", NumStr((ToNum(W_1661) / 2D)), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1662 * 0.56))))), "\" text-anchor=\"middle\" font-family=\"", ToStr(SCRIPT_40), "\" font-size=\"", NumStr(fs_1683), "\" textLength=\"", ToStr(Call(f1_19, V.Undef, ((V)(tl_1684)))), "\" lengthAdjust=\"spacingAndGlyphs\" ", ToStr(st_1698), ">", ToStr(Call(xe_38, V.Undef, t_1660)), "</text>")));
}, 1, "", true);
fl_1686 = ((V)(string.Concat("M", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1661) * 0.14))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1662 * 0.8))))), "C", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1661) * 0.3))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1662 * 0.95))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1661) * 0.42))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1662 * 0.66))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1661) * 0.5))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1662 * 0.8))))), "S", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1661) * 0.72))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1662 * 0.95))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1661) * 0.84))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1662 * 0.76))))))));
leaf_1687 = Fn((V _arrowThis1709, int _argc1700, V x_1706, V y_1707, V r_1708, V _a1705, V[] _rest1701) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_19, V.Undef, x_1706)), "\" cy=\"", ToStr(Call(f1_19, V.Undef, y_1707)), "\" rx=\"2\" ry=\"0.9\" transform=\"rotate(", ToStr(r_1708), " ", ToStr(Call(f1_19, V.Undef, x_1706)), " ", ToStr(Call(f1_19, V.Undef, y_1707)), ")\" fill=\"#2f2a28\"/>")));
}, 3, "", true);
sprig_1688 = ((V)(JsStrBuf.Begin().S(string.Concat("<path d=\"M", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1661) * 0.84))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1662 * 0.76))))), "q2.6 -1.4 5 -4.6\" stroke=\"#2f2a28\" stroke-width=\"0.5\" fill=\"none\"/>")).V(Call(leaf_1687, V.Undef, ((V)(((ToNum(W_1661) * 0.84) + 2.6))), ((V)(((Hh_1662 * 0.76) - 2.2))), ((V)((-40D))))).V(Call(leaf_1687, V.Undef, ((V)(((ToNum(W_1661) * 0.84) + 4.4))), ((V)(((Hh_1662 * 0.76) - 4.6))), ((V)((-70D))))).V(Call(leaf_1687, V.Undef, ((V)(((ToNum(W_1661) * 0.84) + 1.2))), ((V)(((Hh_1662 * 0.76) - 1.4))), ((V)(20D)))).End()));
body_1689 = ((V)(JsStrBuf.Begin().V(Call(tx_1685, V.Undef, ((V)("")))).S(string.Concat("<path d=\"", ToStr(fl_1686), "\" stroke-width=\"0.8\" fill=\"none\" stroke-linecap=\"round\"/>")).V(sprig_1688).End()));
g_1690 = new JsStrBuf(string.Concat("<defs><linearGradient id=\"", ToStr(id_1682), "g\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#3d3532\"/><stop offset=\"1\" stop-color=\"#1f1a19\"/></linearGradient><linearGradient id=\"", ToStr(id_1682), "s\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.35\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient><clipPath id=\"", ToStr(id_1682), "c\">", ToStr(Call(tx_1685, V.Undef, ((V)("")))), "</clipPath></defs>"));
g_1690.S(string.Concat("<g fill=\"#000000\" stroke=\"#000000\" opacity=\"0.22\" transform=\"translate(0.16 0.26)\">", ToStr(body_1689), "</g><g fill=\"url(#", ToStr(id_1682), "g)\" stroke=\"#2f2a28\">", ToStr(body_1689), "</g>"));
g_1690.S(string.Concat("<g clip-path=\"url(#", ToStr(id_1682), "c)\"><rect x=\"-20\" y=\"0\" width=\"14\" height=\"", NumStr(Hh_1662), "\" fill=\"url(#", ToStr(id_1682), "s)\" transform=\"skewX(-20)\">", ToStr(Call(at_17, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 0;", ToStr(Call(f1_19, V.Undef, Add(W_1661, ((V)(40D))))), " 0"))), ((V)(9D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.6;1\" additive=\"sum\"")))), "</rect></g>"));
s_1691 = Call(WD_26, V.Undef, C_1681, ((V)(((-ToNum(W_1661)) / 2D))), ((V)(YT_1664)), ((V)(0.08)), ((V)(g_1690.Str)), W_1661, ((V)(Hh_1662)));
return NewObj(3).Put("defs", DEF19_43).Put("front", s_1691).Put("bb", Invoke(C_1681, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1665;
return default;
}, 1, "", true));
Set(N_12, "qBrass19", Fn((V _arrowThis1717, int _argc1710, V S_1716, V _a1713, V _a1714, V _a1715, V[] _rest1711) => {
V t_1718 = default;
V W_1719 = default;
double Hh_1720 = 0;
double Y0_1721 = 0;
double YT_1722 = 0;
V D_1723 = default;
t_1718 = Call(qt_58, V.Undef, S_1716);
W_1719 = Call(qw_59, V.Undef, t_1718, ((V)(7D)), ((V)(70D)), ((V)(168D)));
Hh_1720 = 28D;
Y0_1721 = 18D;
YT_1722 = (Y0_1721 + Hh_1720);
D_1723 = NewObj(5).Put("w", Add(W_1719, ((V)(6D)))).Put("d", ((V)(4D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(54D))).Put("build", Fn((V _arrowThis1730, int _argc1724, V _a1726, V _a1727, V _a1728, V _a1729, V[] _rest1725) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1723, "fx", Fn((V _arrowThis1738, int _argc1731, V ctx_1737, V _a1734, V _a1735, V _a1736, V[] _rest1732) => {
V C_1739 = default;
double fs_1740 = 0;
double tl_1741 = 0;
V tx_1742 = default;
V s_1743 = default;
V gl_1744 = default;
C_1739 = Call(cam_15, V.Undef, ctx_1737);
fs_1740 = 15D;
tl_1741 = (ToNum(W_1719) - 8D);
tx_1742 = Fn((V _arrowThis1752, int _argc1745, V st_1751, V _a1748, V _a1749, V _a1750, V[] _rest1746) => {
return ((V)(string.Concat("<text x=\"", NumStr((ToNum(W_1719) / 2D)), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1720 * 0.62))))), "\" text-anchor=\"middle\" font-family=\"", ToStr(SCRIPT_40), "\" font-size=\"", NumStr(fs_1740), "\" textLength=\"", ToStr(Call(f1_19, V.Undef, ((V)(tl_1741)))), "\" lengthAdjust=\"spacingAndGlyphs\" ", ToStr(st_1751), ">", ToStr(Call(xe_38, V.Undef, t_1718)), "</text>")));
}, 1, "", true);
s_1743 = Call(WD_26, V.Undef, C_1739, ((V)(((-ToNum(W_1719)) / 2D))), ((V)(YT_1722)), ((V)(0.06)), ((V)(string.Concat("<g filter=\"url(#m12b1)\" opacity=\"0.4\" transform=\"translate(0.9 1.5)\">", ToStr(Call(tx_1742, V.Undef, ((V)("fill=\"#000000\"")))), "</g>"))), W_1719, ((V)(Hh_1720)));
Invoke(Arr(Arr(((V)(0.4)), ((V)("#6a4a18"))), Arr(((V)(0.8)), ((V)("#8a6424"))), Arr(((V)(1.2)), ((V)("#a07a30")))), "forEach", Fn((V _arrowThis1764, int _argc1753, V _a1755, V _a1756, V _a1757, V _a1758, V[] _rest1754) => {
V z_1761 = default;
V c_1763 = default;
{ V _t1759 = ListOf(_a1755);
{ V _t1760 = GetIdx(_t1759, 0D);
z_1761 = _t1760; }
{ V _t1762 = GetIdx(_t1759, 1D);
c_1763 = _t1762; }
}
return (s_1743 = Add(s_1743, Call(WD_26, V.Undef, C_1739, ((V)(((-ToNum(W_1719)) / 2D))), ((V)(YT_1722)), z_1761, Call(tx_1742, V.Undef, ((V)(string.Concat("fill=\"", ToStr(c_1763), "\"")))))));
}, 1, "", true));
gl_1744 = Invoke(Call(rep_21, V.Undef, ((V)(4D)), Fn((V _arrowThis1772, int _argc1765, V i_1771, V _a1768, V _a1769, V _a1770, V[] _rest1766) => {
double x_1773 = 0;
double y_1774 = 0;
x_1773 = (ToNum(W_1719) * (0.16 + (ToNum(i_1771) * 0.22)));
y_1774 = (Hh_1720 * (0.36 + ((ToNum(i_1771) % 2D) * 0.16)));
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_19, V.Undef, ((V)(x_1773)))), " ", ToStr(Call(f1_19, V.Undef, ((V)(y_1774)))), ")\" opacity=\"0\">", ToStr(Call(an_16, V.Undef, ((V)("opacity")), ((V)("0;0;1;0;0")), ((V)(4.8)), ((V)(((-ToNum(i_1771)) * 1.2))), ((V)(" keyTimes=\"0;0.6;0.68;0.76;1\"")))), "<path d=\"M0 -2.2L0.35 -0.35L2.2 0L0.35 0.35L0 2.2L-0.35 0.35L-2.2 0L-0.35 -0.35Z\" fill=\"#ffffff\"/><circle r=\"0.6\" fill=\"#fff6d0\"/></g>")));
return default;
}, 1, "", true)), "join", ((V)("")));
s_1743 = Add(s_1743, Call(WD_26, V.Undef, C_1739, ((V)(((-ToNum(W_1719)) / 2D))), ((V)(YT_1722)), ((V)(1.6)), Add(Add(Call(tx_1742, V.Undef, ((V)("fill=\"url(#br19)\" stroke=\"#7a5418\" stroke-width=\"0.22\""))), Call(tx_1742, V.Undef, ((V)("fill=\"none\" stroke=\"#fff4c8\" stroke-width=\"0.18\" opacity=\"0.6\" transform=\"translate(-0.15 -0.2)\"")))), gl_1744)));
Invoke(Arr(((V)((((-ToNum(W_1719)) / 2D) + 3D))), ((V)(((ToNum(W_1719) / 2D) - 3D)))), "forEach", Fn((V _arrowThis1782, int _argc1775, V x_1781, V _a1778, V _a1779, V _a1780, V[] _rest1776) => {
return (s_1743 = Add(s_1743, Call(sph_36, V.Undef, C_1739, Arr(x_1781, ((V)((Y0_1721 + (Hh_1720 * 0.45)))), ((V)(1.2))), ((V)(0.5)), ((V)("#d9b25a")))));
}, 1, "", true));
return NewObj(3).Put("defs", DEF19_43).Put("front", s_1743).Put("bb", Invoke(C_1739, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1723;
return default;
}, 1, "", true));
Set(N_12, "qNeon19", Fn((V _arrowThis1790, int _argc1783, V S_1789, V _a1786, V _a1787, V _a1788, V[] _rest1784) => {
V t_1791 = default;
V W_1792 = default;
double Hh_1793 = 0;
double Y0_1794 = 0;
double YT_1795 = 0;
V COL_1796 = default;
V D_1797 = default;
t_1791 = Call(qt_58, V.Undef, S_1789);
W_1792 = Call(qw_59, V.Undef, t_1791, ((V)(7D)), ((V)(74D)), ((V)(172D)));
Hh_1793 = 32D;
Y0_1794 = 18D;
YT_1795 = (Y0_1794 + Hh_1793);
COL_1796 = ((V)("#ff5fa8"));
D_1797 = NewObj(5).Put("w", Add(W_1792, ((V)(10D)))).Put("d", ((V)(6D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(52D))).Put("build", Fn((V _arrowThis1804, int _argc1798, V _a1800, V _a1801, V _a1802, V _a1803, V[] _rest1799) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1797, "fx", Fn((V _arrowThis1812, int _argc1805, V ctx_1811, V _a1808, V _a1809, V _a1810, V[] _rest1806) => {
V C_1813 = default;
double fs_1814 = 0;
double tl_1815 = 0;
V tx_1816 = default;
V und_1817 = default;
V FLK_1818 = default;
V s_1819 = default;
C_1813 = Call(cam_15, V.Undef, ctx_1811);
fs_1814 = 15.5;
tl_1815 = (ToNum(W_1792) - 14D);
tx_1816 = Fn((V _arrowThis1827, int _argc1820, V st_1826, V _a1823, V _a1824, V _a1825, V[] _rest1821) => {
return ((V)(string.Concat("<text x=\"", NumStr((ToNum(W_1792) / 2D)), "\" y=\"", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1793 * 0.6))))), "\" text-anchor=\"middle\" font-family=\"", ToStr(SCRIPT_40), "\" font-size=\"", NumStr(fs_1814), "\" textLength=\"", ToStr(Call(f1_19, V.Undef, ((V)(tl_1815)))), "\" lengthAdjust=\"spacingAndGlyphs\" ", ToStr(st_1826), ">", ToStr(Call(xe_38, V.Undef, t_1791)), "</text>")));
}, 1, "", true);
und_1817 = ((V)(string.Concat("M", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1792) * 0.22))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1793 * 0.8))))), "Q", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1792) * 0.5))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1793 * 0.9))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(W_1792) * 0.78))))), " ", ToStr(Call(f1_19, V.Undef, ((V)((Hh_1793 * 0.8))))))));
FLK_1818 = Call(an_16, V.Undef, ((V)("opacity")), ((V)("1;1;0.25;1;0.45;1;1")), ((V)(6.5)), ((V)(0D)), ((V)(" keyTimes=\"0;0.82;0.83;0.85;0.86;0.88;1\"")));
s_1819 = Call(WD_26, V.Undef, C_1813, ((V)((((-ToNum(W_1792)) / 2D) - 14D))), ((V)((YT_1795 + 14D))), ((V)(0.05)), ((V)(string.Concat("<rect width=\"", ToStr(Add(W_1792, ((V)(28D)))), "\" height=\"", NumStr((Hh_1793 + 28D)), "\" rx=\"24\" fill=\"", ToStr(COL_1796), "\" opacity=\"0.4\" filter=\"url(#m11b8)\">", ToStr(Call(an_16, V.Undef, ((V)("opacity")), ((V)("0.32;0.46;0.34;0.44;0.32")), ((V)(3.6)))), "</rect>"))));
s_1819 = Add(s_1819, Call(WD_26, V.Undef, C_1813, ((V)(((-ToNum(W_1792)) / 2D))), ((V)(YT_1795)), ((V)(0.06)), ((V)(string.Concat("<rect x=\"1\" y=\"1.6\" width=\"", ToStr(W_1792), "\" height=\"", NumStr(Hh_1793), "\" rx=\"3\" fill=\"#000000\" opacity=\"0.12\" filter=\"url(#m12b1)\"/><path d=\"M", NumStr((ToNum(W_1792) - 6D)), " ", NumStr(Hh_1793), "Q", NumStr((ToNum(W_1792) - 4D)), " ", NumStr((Hh_1793 + 6D)), " ", NumStr((ToNum(W_1792) - 7D)), " ", NumStr((Hh_1793 + 12D)), "\" stroke=\"#2a2a2e\" stroke-width=\"0.6\" fill=\"none\"/>")))));
Call(ext_24, V.Undef, C_1813, Arr(Arr(((V)(((ToNum(W_1792) / 2D) - 9D))), ((V)((Y0_1794 - 13D))), ((V)(0D)))));
s_1819 = Add(s_1819, Call(WD_26, V.Undef, C_1813, ((V)((((-ToNum(W_1792)) / 2D) + 0.5))), ((V)((Y0_1794 - 11D))), ((V)(0.4)), ((V)("<rect width=\"6\" height=\"3.4\" rx=\"0.6\" fill=\"#24252a\"/><circle cx=\"4.6\" cy=\"1.7\" r=\"0.45\" fill=\"#7fffb0\"/>"))));
Invoke(Arr(Arr(((V)((((-ToNum(W_1792)) / 2D) + 4D))), ((V)((Y0_1794 + 4D)))), Arr(((V)(((ToNum(W_1792) / 2D) - 4D))), ((V)((Y0_1794 + 4D)))), Arr(((V)((((-ToNum(W_1792)) / 2D) + 4D))), ((V)((YT_1795 - 4D)))), Arr(((V)(((ToNum(W_1792) / 2D) - 4D))), ((V)((YT_1795 - 4D))))), "forEach", Fn((V _arrowThis1839, int _argc1828, V _a1830, V _a1831, V _a1832, V _a1833, V[] _rest1829) => {
V x_1836 = default;
V y_1838 = default;
{ V _t1834 = ListOf(_a1830);
{ V _t1835 = GetIdx(_t1834, 0D);
x_1836 = _t1835; }
{ V _t1837 = GetIdx(_t1834, 1D);
y_1838 = _t1837; }
}
return (s_1819 = Add(s_1819, Call(cyl3_35, V.Undef, C_1813, Arr(x_1836, y_1838, ((V)(0D))), Arr(x_1836, y_1838, ((V)(2.4))), ((V)(0.9)), ((V)("#d9dce0")))));
}, 1, "", true));
s_1819 = Add(s_1819, Invoke(H_13, "box3", C_1813, NewObj(11).Put("c", Arr(((V)(0D)), ((V)(Y0_1794)), ((V)(2D)))).Put("w", W_1792).Put("h", ((V)(Hh_1793))).Put("d", ((V)(0.9))).Put("r", ((V)(3D))).Put("col", ((V)("#e2f3ff"))).Put("op", ((V)(0.28))).Put("olc", ((V)("#a9c4d4"))).Put("olw", ((V)(0.5))).Put("olo", ((V)(0.8))).Put("edge", ((V)(0.6))).V));
Invoke(Arr(Arr(((V)((((-ToNum(W_1792)) / 2D) + 4D))), ((V)((Y0_1794 + 4D)))), Arr(((V)(((ToNum(W_1792) / 2D) - 4D))), ((V)((Y0_1794 + 4D)))), Arr(((V)((((-ToNum(W_1792)) / 2D) + 4D))), ((V)((YT_1795 - 4D)))), Arr(((V)(((ToNum(W_1792) / 2D) - 4D))), ((V)((YT_1795 - 4D))))), "forEach", Fn((V _arrowThis1851, int _argc1840, V _a1842, V _a1843, V _a1844, V _a1845, V[] _rest1841) => {
V x_1848 = default;
V y_1850 = default;
{ V _t1846 = ListOf(_a1842);
{ V _t1847 = GetIdx(_t1846, 0D);
x_1848 = _t1847; }
{ V _t1849 = GetIdx(_t1846, 1D);
y_1850 = _t1849; }
}
return (s_1819 = Add(s_1819, Call(sph_36, V.Undef, C_1813, Arr(x_1848, y_1850, ((V)(3.1))), ((V)(1.1)), ((V)("#e6e8ec")))));
}, 1, "", true));
s_1819 = Add(s_1819, Call(WD_26, V.Undef, C_1813, ((V)(((-ToNum(W_1792)) / 2D))), ((V)(YT_1795)), ((V)(3.3)), ((V)(string.Concat(string.Concat("<g>", ToStr(FLK_1818), "<g filter=\"url(#m12b2)\" opacity=\"0.7\">", ToStr(Call(tx_1816, V.Undef, ((V)(string.Concat("fill=\"none\" stroke=\"", ToStr(COL_1796), "\" stroke-width=\"2.6\""))))), "<path d=\"", ToStr(und_1817), "\" stroke=\"#5ff0ff\" stroke-width=\"2.4\" fill=\"none\"/></g>", ToStr(Call(tx_1816, V.Undef, ((V)(string.Concat("fill=\"", ToStr(COL_1796), "\" stroke=\"", ToStr(COL_1796), "\" stroke-width=\"0.6\""))))), ToStr(Call(tx_1816, V.Undef, ((V)("fill=\"#ffe6f3\" opacity=\"0.75\"")))), "</g>"), string.Concat("<path d=\"", ToStr(und_1817), "\" stroke=\"#5ff0ff\" stroke-width=\"1\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"", ToStr(und_1817), "\" stroke=\"#eaffff\" stroke-width=\"0.3\" fill=\"none\" stroke-linecap=\"round\"/>")))), W_1792, ((V)(Hh_1793))));
return NewObj(3).Put("defs", DEF19_43).Put("front", s_1819).Put("bb", Invoke(C_1813, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1797;
return default;
}, 1, "", true));
WDEF_60 = ((V)(string.Concat("<filter id=\"b1\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"0.6\"/></filter><filter id=\"b2\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"1.6\"/></filter>", "<linearGradient id=\"gref\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.22\"/><stop offset=\"0.35\" stop-color=\"#ffffff\" stop-opacity=\"0.02\"/><stop offset=\"0.6\" stop-color=\"#ffffff\" stop-opacity=\"0.1\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>")));
bev_61 = Fn((V _arrowThis1864, int _argc1852, V x_1858, V y_1859, V w_1860, V h_1861, V[] _rest1853) => {
V c_1862 = default;
V t_1863 = default;
c_1862 = (_argc1852 > 4 ? _rest1853[0] : V.Undef);
t_1863 = (_argc1852 > 5 ? _rest1853[1] : V.Undef);
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_19, V.Undef, x_1858)), "\" y=\"", ToStr(Call(f1_19, V.Undef, y_1859)), "\" width=\"", ToStr(Call(f1_19, V.Undef, w_1860)), "\" height=\"", ToStr(Call(f1_19, V.Undef, h_1861)), "\" fill=\"", ToStr(c_1862), "\"/><path d=\"M", ToStr(Call(f1_19, V.Undef, x_1858)), " ", ToStr(Call(f1_19, V.Undef, y_1859)), "h", ToStr(Call(f1_19, V.Undef, w_1860)), "l", NumStr((-ToNum(t_1863))), " ", ToStr(t_1863), "h", ToStr(Call(f1_19, V.Undef, ((V)((-(ToNum(w_1860) - (2D * ToNum(t_1863)))))))), "v", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(h_1861) - (2D * ToNum(t_1863))))))), "l", NumStr((-ToNum(t_1863))), " ", ToStr(t_1863), "Z\" fill=\"#ffffff\" opacity=\"0.38\"/><path d=\"M", ToStr(Call(f1_19, V.Undef, Add(x_1858, w_1860))), " ", ToStr(Call(f1_19, V.Undef, Add(y_1859, h_1861))), "h", ToStr(Call(f1_19, V.Undef, ((V)((-ToNum(w_1860)))))), "l", ToStr(t_1863), " ", NumStr((-ToNum(t_1863))), "h", ToStr(Call(f1_19, V.Undef, ((V)((ToNum(w_1860) - (2D * ToNum(t_1863))))))), "v", ToStr(Call(f1_19, V.Undef, ((V)((-(ToNum(h_1861) - (2D * ToNum(t_1863)))))))), "l", ToStr(t_1863), " ", NumStr((-ToNum(t_1863))), "Z\" fill=\"#000000\" opacity=\"0.2\"/>")));
}, 6, "", true);
ring_62 = Fn((V _arrowThis1878, int _argc1865, V x0_1871, V y0_1872, V x1_1873, V y1_1874, V[] _rest1866) => {
V t_1875 = default;
V c_1876 = default;
V e_1877 = default;
t_1875 = (_argc1865 > 4 ? _rest1866[0] : V.Undef);
c_1876 = (_argc1865 > 5 ? _rest1866[1] : V.Undef);
e_1877 = (_argc1865 > 6 ? _rest1866[2] : V.Undef);
return Add(Add(Add(Call(bev_61, V.Undef, x0_1871, y0_1872, ((V)((ToNum(x1_1873) - ToNum(x0_1871)))), t_1875, c_1876, e_1877), Call(bev_61, V.Undef, x0_1871, ((V)((ToNum(y1_1874) - ToNum(t_1875)))), ((V)((ToNum(x1_1873) - ToNum(x0_1871)))), t_1875, c_1876, e_1877)), Call(bev_61, V.Undef, x0_1871, Add(y0_1872, t_1875), t_1875, ((V)(((ToNum(y1_1874) - ToNum(y0_1872)) - (2D * ToNum(t_1875))))), c_1876, e_1877)), Call(bev_61, V.Undef, ((V)((ToNum(x1_1873) - ToNum(t_1875)))), Add(y0_1872, t_1875), t_1875, ((V)(((ToNum(y1_1874) - ToNum(y0_1872)) - (2D * ToNum(t_1875))))), c_1876, e_1877));
}, 7, "", true);
reveal_63 = Fn((V _arrowThis1891, int _argc1879, V x0_1885, V y0_1886, V x1_1887, V y1_1888, V[] _rest1880) => {
V d_1889 = default;
V c_1890 = default;
d_1889 = (_argc1879 > 4 ? _rest1880[0] : V.Undef);
c_1890 = (_argc1879 > 5 ? _rest1880[1] : V.Undef);
return ((V)(string.Concat("<path d=\"M", ToStr(x0_1885), " ", ToStr(y0_1886), "H", ToStr(x1_1887), "L", NumStr((ToNum(x1_1887) - ToNum(d_1889))), " ", ToStr(Add(y0_1886, d_1889)), "H", ToStr(Add(x0_1885, d_1889)), "Z\" fill=\"", ToStr(Call(shade_11, V.Undef, c_1890, ((V)(0.62)))), "\"/><path d=\"M", ToStr(x0_1885), " ", ToStr(y0_1886), "L", ToStr(Add(x0_1885, d_1889)), " ", ToStr(Add(y0_1886, d_1889)), "V", NumStr((ToNum(y1_1888) - ToNum(d_1889))), "L", ToStr(x0_1885), " ", ToStr(y1_1888), "Z\" fill=\"", ToStr(Call(shade_11, V.Undef, c_1890, ((V)(0.78)))), "\"/><path d=\"M", ToStr(x1_1887), " ", ToStr(y0_1886), "V", ToStr(y1_1888), "L", NumStr((ToNum(x1_1887) - ToNum(d_1889))), " ", NumStr((ToNum(y1_1888) - ToNum(d_1889))), "V", ToStr(Add(y0_1886, d_1889)), "Z\" fill=\"", ToStr(Call(shade_11, V.Undef, c_1890, ((V)(0.95)))), "\"/><path d=\"M", ToStr(x0_1885), " ", ToStr(y1_1888), "L", ToStr(Add(x0_1885, d_1889)), " ", NumStr((ToNum(y1_1888) - ToNum(d_1889))), "H", NumStr((ToNum(x1_1887) - ToNum(d_1889))), "L", ToStr(x1_1887), " ", ToStr(y1_1888), "Z\" fill=\"", ToStr(Call(shade_11, V.Undef, c_1890, ((V)(1.06)))), "\"/>")));
}, 6, "", true);
sill_64 = Fn((V _arrowThis1903, int _argc1892, V x0_1898, V x1_1899, V y_1900, V c_1901, V[] _rest1893) => {
V d_1902 = default;
d_1902 = (_argc1892 > 4 ? _rest1893[0] : V.Undef);
return ((V)(string.Concat("<rect x=\"", ToStr(x0_1898), "\" y=\"", ToStr(Add(y_1900, ((V)(2.6)))), "\" width=\"", NumStr((ToNum(x1_1899) - ToNum(x0_1898))), "\" height=\"2\" fill=\"#000000\" opacity=\"0.22\" filter=\"url(#b1)\"/><path d=\"M", ToStr(Add(x0_1898, d_1902)), " ", NumStr((ToNum(y_1900) - ToNum(d_1902))), "H", NumStr((ToNum(x1_1899) - ToNum(d_1902))), "L", ToStr(x1_1899), " ", ToStr(y_1900), "H", ToStr(x0_1898), "Z\" fill=\"", ToStr(Call(shade_11, V.Undef, c_1901, ((V)(1.08)))), "\"/><rect x=\"", ToStr(x0_1898), "\" y=\"", ToStr(y_1900), "\" width=\"", NumStr((ToNum(x1_1899) - ToNum(x0_1898))), "\" height=\"3\" fill=\"", ToStr(c_1901), "\"/><rect x=\"", ToStr(x0_1898), "\" y=\"", ToStr(y_1900), "\" width=\"", NumStr((ToNum(x1_1899) - ToNum(x0_1898))), "\" height=\"0.4\" fill=\"#ffffff\" opacity=\"0.5\"/><rect x=\"", ToStr(x0_1898), "\" y=\"", ToStr(Add(y_1900, ((V)(2.6)))), "\" width=\"", NumStr((ToNum(x1_1899) - ToNum(x0_1898))), "\" height=\"0.4\" fill=\"#000000\" opacity=\"0.2\"/>")));
}, 5, "", true);
cloud_65 = Fn((V _arrowThis1914, int _argc1904, V x_1910, V y_1911, V k_1912, V c_1913, V[] _rest1905) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_19, V.Undef, x_1910)), " ", ToStr(Call(f1_19, V.Undef, y_1911)), ") scale(", ToStr(Call(n4_20, V.Undef, k_1912)), ")\"><ellipse cx=\"0.6\" cy=\"1.4\" rx=\"7\" ry=\"2.2\" fill=\"", ToStr(Call(shade_11, V.Undef, c_1913, ((V)(0.86)))), "\"/><ellipse rx=\"7\" ry=\"2.6\" fill=\"", ToStr(c_1913), "\"/><circle cx=\"-3\" cy=\"-1.6\" r=\"3\" fill=\"", ToStr(c_1913), "\"/><circle cx=\"1.4\" cy=\"-2.8\" r=\"3.8\" fill=\"", ToStr(c_1913), "\"/><circle cx=\"4.8\" cy=\"-0.9\" r=\"2.5\" fill=\"", ToStr(c_1913), "\"/><circle cx=\"0.4\" cy=\"-3.6\" r=\"1.6\" fill=\"#ffffff\" opacity=\"0.6\"/></g>")));
}, 4, "", true);
drift_66 = Fn((V _arrowThis1924, int _argc1915, V s_1921, V w_1922, V d_1923, V _a1920, V[] _rest1916) => {
return ((V)(string.Concat("<g>", ToStr(Call(at_17, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;", ToStr(Call(f1_19, V.Undef, w_1922)), " 0"))), d_1923)), ToStr(s_1921), "<g transform=\"translate(", ToStr(Call(f1_19, V.Undef, ((V)((-ToNum(w_1922)))))), " 0)\">", ToStr(s_1921), "</g></g>")));
}, 3, "", true);
tree_67 = Fn((V _arrowThis1936, int _argc1925, V x_1931, V y_1932, V k_1933, V c_1934, V[] _rest1926) => {
V ph_1935 = default;
ph_1935 = (_argc1925 > 4 ? _rest1926[0] : V.Undef);
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_19, V.Undef, x_1931)), " ", ToStr(Call(f1_19, V.Undef, y_1932)), ") scale(", ToStr(Call(n4_20, V.Undef, k_1933)), ")\"><path d=\"M-1 0L-0.7 -10H0.7L1 0Z\" fill=\"#6a4a2e\"/><g>", ToStr(Call(at_17, V.Undef, ((V)("rotate")), ((V)("-2.5 0 -8;2.5 0 -8;-2.5 0 -8")), Add(((V)(5D)), (ph_1935 is var _t1937 && Truthy(_t1937) ? _t1937 : ((V)(0D)))), ((V)((-ToNum((ph_1935 is var _t1938 && Truthy(_t1938) ? _t1938 : ((V)(0D))))))), Call(SPL_18, V.Undef, ((V)(2D))))), "<circle cx=\"-3.6\" cy=\"-11\" r=\"4.6\" fill=\"", ToStr(Call(shade_11, V.Undef, c_1934, ((V)(0.85)))), "\"/><circle cx=\"3.4\" cy=\"-11.6\" r=\"4.4\" fill=\"", ToStr(Call(shade_11, V.Undef, c_1934, ((V)(0.9)))), "\"/><circle cy=\"-15\" r=\"5.4\" fill=\"", ToStr(c_1934), "\"/><circle cx=\"-1.6\" cy=\"-16.6\" r=\"2.2\" fill=\"", ToStr(Call(shade_11, V.Undef, c_1934, ((V)(1.2)))), "\"/><circle cx=\"2.6\" cy=\"-13\" r=\"1.8\" fill=\"", ToStr(Call(shade_11, V.Undef, c_1934, ((V)(1.12)))), "\"/></g></g>")));
}, 5, "", true);
glassRef_68 = Fn((V _arrowThis1949, int _argc1939, V x_1945, V y_1946, V w_1947, V h_1948, V[] _rest1940) => {
return ((V)(string.Concat("<rect x=\"", ToStr(x_1945), "\" y=\"", ToStr(y_1946), "\" width=\"", ToStr(w_1947), "\" height=\"", ToStr(h_1948), "\" fill=\"url(#gref)\"/><path d=\"M", ToStr(Call(f1_19, V.Undef, Add(x_1945, ((V)((ToNum(w_1947) * 0.2)))))), " ", ToStr(y_1946), "L", ToStr(Call(f1_19, V.Undef, Add(x_1945, ((V)((ToNum(w_1947) * 0.05)))))), " ", ToStr(Add(y_1946, h_1948)), "H", ToStr(Call(f1_19, V.Undef, Add(x_1945, ((V)((ToNum(w_1947) * 0.12)))))), "L", ToStr(Call(f1_19, V.Undef, Add(x_1945, ((V)((ToNum(w_1947) * 0.27)))))), " ", ToStr(y_1946), "Z\" fill=\"#ffffff\" opacity=\"0.08\"/>")));
}, 4, "", true);
WIN19_74 = NewObj(5).Put("crack", w12_69).Put("hung", w32_70).Put("bay", w52_71).Put("tint", w72_72).Put("holo", w92_73).V;
WMEMO_75 = NewObj(0).V;
winArt_76 = Fn((V _arrowThis1957, int _argc1950, V k_1956, V _a1953, V _a1954, V _a1955, V[] _rest1951) => {
return (GetK(WMEMO_75, k_1956) is var _t1966 && Truthy(_t1966) ? _t1966 : SetK(WMEMO_75, k_1956, Call(Fn((V _arrowThis1964, int _argc1958, V _a1960, V _a1961, V _a1962, V _a1963, V[] _rest1959) => {
V o_1965 = default;
o_1965 = InvokeK(WIN19_74, k_1956);
return NewObj(2).Put("vb", Get(o_1965, "vb")).Put("svg", Invoke(RD_8, "svgDoc", Invoke(Get(o_1965, "vb"), "join", ((V)(" "))), Arr(), Get(o_1965, "s"))).V;
return default;
}, 0, "", true), V.Undef)));
}, 1, "", true);
draw18_77 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis1975, int _argc1967, V r_1973, V o_1974, V _a1971, V _a1972, V[] _rest1968) => {
V res_1976 = default;
res_1976 = Call(draw18_77, V.Undef, r_1973, o_1974);
if (Truthy(((!(Truthy(res_1976)) ? V.True : V.False) is var _t1977 && Truthy(_t1977) ? _t1977 : Get(res_1976, "_p19")))) {
return res_1976;
}
try {
if (Truthy(((Get(r_1973, "w19") is var _t1978 && !Truthy(_t1978) ? _t1978 : GetK(WIN19_74, Get(r_1973, "w19"))) is var _t1979 && !Truthy(_t1979) ? _t1979 : Get(res_1976, "surf")))) {
V A_1980 = default;
A_1980 = Call(winArt_76, V.Undef, Get(r_1973, "w19"));
Set(res_1976, "_p19", ((V)(1D)));
Set(res_1976, "svg", Get(A_1980, "svg"));
Set(res_1976, "src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Get(A_1980, "svg"))).End())));
Set(res_1976, "vb", Invoke(Get(A_1980, "vb"), "join", ((V)(" "))));
Set(res_1976, "win19", Get(A_1980, "vb"));
}
} catch (System.Exception _ex1981) {
V e_1982 = default;
e_1982 = Caught(_ex1981);
Invoke(G("console"), "warn", ((V)("reno plus19")), Get(r_1973, "id"), e_1982);
}
if (Truthy((Get(r_1973, "w19") is var _t1983 && !Truthy(_t1983) ? _t1983 : Get(res_1976, "win19")))) {
V sp_1984 = default;
sp_1984 = GetK(Get(X_9, "SPEC"), ((V)(JsStrBuf.Begin().S("rv_").V(Get(r_1973, "id")).End())));
if (Truthy(sp_1984)) {
Set(sp_1984, "ir", Get(res_1976, "win19"));
}
}
return res_1976;
return default;
}, 2, "", true));
Set(RD_8, "SET19", NewObj(20).Put("LIV-001", NewObj(2).Put("s12", ((V)("lpaper"))).Put("note", ((V)("Old off-white rental wallpaper with faded stripes and tiny rose sprigs. One seam has started to lift, there are brown water stains from a ceiling leak, a few old nail holes and a little torn spot."))).V).Put("LIV-021", NewObj(2).Put("s12", ((V)("lsage"))).Put("note", ((V)("Walls rolled in a soft sage matte paint (you can see the roller texture), with a crisp white skirting board, a light switch and a little round thermostat."))).V).Put("LIV-041", NewObj(2).Put("s12", ((V)("lwain"))).Put("note", ((V)("Cream plaster on top and white shaker panels below a chair rail, every panel a real recessed square with soft shadows."))).V).Put("LIV-061", NewObj(2).Put("s12", ((V)("lherr"))).Put("note", ((V)("A herringbone oak feature wall in mixed honey and walnut planks on the back wall, and chalky limewash plaster on the side walls."))).V).Put("LIV-081", NewObj(2).Put("s12", ((V)("lmarb"))).Put("note", ((V)("Bookmatched smooth white marble with thin brass inlay strips."))).V).Put("LIV-004", NewObj(2).Put("spec", ((V)("cal19"))).Put("note", ((V)("A free calendar from Squish Pizza hanging on a nail. It always shows today, past days get crossed off, and you can tap days to mark them. A pencil on a string swings next to it."))).V).Put("LIV-024", NewObj(3).Put("spec", ((V)("rmir19"))).Put("live", ((V)("Glinting glass"))).Put("note", ((V)("A round mirror with a thick brass rim hanging from a stitched leather strap on a brass peg. A soft glint slides across the glass."))).V).Put("LIV-044", NewObj(2).Put("spec", ((V)("trip19"))).Put("note", ((V)("Three deep gallery-wrapped canvases that make one abstract painting together, with thick raised brush strokes, the paint wrapping round their sides."))).V).Put("LIV-064", NewObj(3).Put("spec", ((V)("venet19"))).Put("live", ((V)("Glowing neon"))).Put("note", ((V)("An arched Venetian mirror made of bevelled, etched glass pieces with little glass rosettes, and a pink \"hey cutie\" neon script glowing on it."))).V).Put("LIV-084", NewObj(2).Put("spec", ((V)("master19"))).Put("note", ((V)("A living painting in a carved gilt frame with a brass picture light. It moves on its own. Tap it to repaint."))).V).Put("LIV-101", NewObj(3).Put("spec", ((V)("qPaper19"))).Put("live", ((V)("Swaying banner"))).Put("note", ((V)("A hand-lettered paper banner clipped to a twine with two wooden clothespins, with marker doodles. Write any words you like."))).V).Put("LIV-102", NewObj(3).Put("spec", ((V)("qDrift19"))).Put("live", ((V)("Swinging sign"))).Put("note", ((V)("A weathered driftwood plank with distressed white painted letters and a little starfish, hanging from a jute rope. Write any words you like."))).V).Put("LIV-103", NewObj(2).Put("spec", ((V)("qVinyl19"))).Put("note", ((V)("A matte script vinyl decal with a flourish and a leaf sprig, stuck straight onto the wall. Write any words you like."))).V).Put("LIV-104", NewObj(3).Put("spec", ((V)("qBrass19"))).Put("live", ((V)("Sparkling brass"))).Put("note", ((V)("Thick cut-brass script letters standing off the wall, with little sparkles running along them. Write any words you like."))).V).Put("LIV-105", NewObj(3).Put("spec", ((V)("qNeon19"))).Put("live", ((V)("Glowing neon"))).Put("note", ((V)("Pink neon script on a clear acrylic panel with chrome standoffs. It lights up the wall and flickers now and then. Write any words you like."))).V).Put("LIV-012", NewObj(3).Put("w19", ((V)("crack"))).Put("live", ((V)("Drifting clouds"))).Put("note", ((V)("A cracked single-pane window with chipped paint and a taped crack. The bent plastic blinds are missing a slat and the bottom rail hangs crooked."))).V).Put("LIV-032", NewObj(3).Put("w19", ((V)("hung"))).Put("live", ((V)("Swaying trees"))).Put("note", ((V)("A white double-hung window with a brass sash lock and a cotton roman shade, looking out on a sunny garden."))).V).Put("LIV-052", NewObj(3).Put("w19", ((V)("bay"))).Put("live", ((V)("Swaying drapes"))).Put("note", ((V)("A floor-to-ceiling bay window with three glass walls, a sunny wood floor and long linen drapes on a brass rod."))).V).Put("LIV-072", NewObj(3).Put("w19", ((V)("tint"))).Put("live", ((V)("Smart tint"))).Put("note", ((V)("A panoramic black-steel window wall over the hills and the city. The smart tint slowly rolls down the glass and back up."))).V).Put("LIV-092", NewObj(3).Put("w19", ((V)("holo"))).Put("live", ((V)("Changing weather"))).Put("note", ((V)("A frameless holographic panorama of a future skyline that changes weather on its own: sunshine, rain, a starry night and snow."))).V).V);
edit18_78 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis1992, int _argc1985, V rows_1991, V _a1988, V _a1989, V _a1990, V[] _rest1986) => {
return Invoke(Call(edit18_78, V.Undef, rows_1991), "map", Fn((V _arrowThis2000, int _argc1993, V r_1999, V _a1996, V _a1997, V _a1998, V[] _rest1994) => {
return (Truthy(GetK(Get(RD_8, "SET19"), Get(r_1999, "id"))) ? Object_assign(NewObj(0).V, r_1999, GetK(Get(RD_8, "SET19"), Get(r_1999, "id"))) : r_1999);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H19", NewObj(3).Put("DEF19", DEF19_43).Put("WIN19", WIN19_74).Put("winArt", winArt_76).V);
Set(RD_8, "PLUS19", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
